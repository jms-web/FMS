Imports JMS_COMMON.ClsPubMethod

Public Class FrmM0161
    Private IsValidated As Boolean
    Private _M016 As New MODEL.M016_SYONIN_TANTO

#Region "変数・定数"

#End Region

#Region "プロパティ"
    ''' <summary>
    ''' 処理モード
    ''' </summary>
    Public Property PrMODE As Integer

    ''' <summary>
    ''' 新規追加レコードのキー
    ''' </summary>
    Public Property PrPKeys As (ITEM_NAME As String, ITEM_VALUE As String)

    ''' <summary>
    ''' 一覧の選択行データ
    ''' </summary>
    Public Property PrViewModel As MODEL.VWM016_SYONIN_TANTO

#End Region

#Region "コンストラクタ"
    ''' <summary>
    ''' コンストラクタ
    ''' </summary>
    ''' <remarks>コンストラクタ</remarks>
    Public Sub New()

        ' この呼び出しはデザイナーで必要です。
        InitializeComponent()

        CmbSYAIN_ID.NullValue = 0
        CmbSYONIN_HOKOKUSYO_ID.NullValue = 0
        CmbSYONIN_JUN.NullValue = 0
    End Sub
#End Region

#Region "FORMイベント"
    Private Sub Frm_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        Try
            '-----フォーム共通設定
            Call FunFormCommonSetting(pub_APP_INFO, pub_SYAIN_INFO)
            Using DB As ClsDbUtility = DBOpen()
                lblTytle.Text = FunGetCodeMastaValue(DB, "PG_TITLE", Me.GetType.ToString)
            End Using

            '-----ウィンドウ設定
            Me.FormBorderStyle = Windows.Forms.FormBorderStyle.FixedDialog
            Me.ControlBox = False

            '-----位置・サイズ
            Me.Height = 400
            Me.Top = Me.Owner.Top + (Me.Owner.Height - Me.Height) - 26 ' / 2
            Me.Left = Me.Owner.Left + (Me.Owner.Width - Me.Width) / 2

            '-----コントロールデータソース設定
            CmbSYONIN_HOKOKUSYO_ID.SetDataSource(tblSYONIN_HOKOKUSYO_ID, ENM_COMBO_SELECT_VALUE_TYPE._1_Filter)
            CmbSYAIN_ID.SetDataSource(tblTANTO, ENM_COMBO_SELECT_VALUE_TYPE._1_Filter)

            Call FunSetBinding()

            '-----処理モード別画面初期化
            Call FunInitializeControls()

        Catch ex As Exception
            EM.ErrorSyori(ex, False, conblnNonMsg)

        End Try
    End Sub

#End Region

#Region "処理モード別画面初期化"
    Private Function FunInitializeControls() As Boolean

        Try
            Select Case PrMODE
                Case ENM_DATA_OPERATION_MODE._1_ADD
                    lblTytle.Text &= "（追加）"
                    Me.cmdFunc1.Text = "追加(F1)"

                    Me.lbllblEDIT_YMDHNS.Visible = False
                    Me.lblEDIT_YMDHNS.Visible = False

                Case ENM_DATA_OPERATION_MODE._2_ADDREF
                    _M016.Properties.ForEach(Sub(p) _M016(p.Name) = PrViewModel(p.Name))
                    _M016.SYAIN_ID = 0

                    lblTytle.Text &= "（類似追加）"
                    Me.cmdFunc1.Text = "追加(F1)"

                    Me.lbllblEDIT_YMDHNS.Visible = False
                    Me.lblEDIT_YMDHNS.Visible = False

                Case ENM_DATA_OPERATION_MODE._3_UPDATE
                    CmbSYONIN_HOKOKUSYO_ID.SelectedValue = PrViewModel(NameOf(_M016.SYONIN_HOKOKUSYO_ID))
                    CmbSYONIN_JUN.SelectedValue = PrViewModel(NameOf(_M016.SYONIN_JUN))

                    lblTytle.Text &= "（変更）"
                    Me.cmdFunc1.Text = "変更(F1)"

                    CmbSYONIN_HOKOKUSYO_ID.ReadOnly = True
                    CmbSYONIN_JUN.ReadOnly = True
                    'Me.lbllblEDIT_YMDHNS.Visible = True
                    'Me.lblEDIT_YMDHNS.Visible = True

                Case Else
                    Throw New ArgumentException(My.Resources.ErrMsgException, PrMODE.ToString)
            End Select

            Return True

        Catch ex As Exception
            EM.ErrorSyori(ex, False, conblnNonMsg)
            Return False
        End Try
    End Function

#End Region

#Region "FUNCTIONボタンCLICK"

#Region "ボタンクリックイベント"
    Private Sub CmdFunc_Click(ByVal sender As Object, ByVal e As EventArgs) Handles cmdFunc1.Click, cmdFunc2.Click, cmdFunc3.Click, cmdFunc4.Click, cmdFunc5.Click, cmdFunc6.Click, cmdFunc7.Click, cmdFunc8.Click, cmdFunc9.Click, cmdFunc10.Click, cmdFunc11.Click, cmdFunc12.Click

        Dim intFUNC As Integer
        Dim intCNT As Integer

        Try
            'ボタン不可/ボタンINDEX取得
            For intCNT = 0 To Me.cmdFunc.Length - 1
                Me.cmdFunc(intCNT).Enabled = False
                If cmdFunc(intCNT) Is sender Then intFUNC = intCNT + 1
            Next

            'ボタンINDEX毎の処理
            Select Case intFUNC
                Case 1  '追加
                    If FunSAVE() Then
                        'プロパティに対象レコードのキーを設定
                        'Me.PrPKeys = _M105.KISYU_ID

                        Me.DialogResult = Windows.Forms.DialogResult.OK
                        Me.Close()
                    End If

                Case 12 '戻る
                    Me.DialogResult = Windows.Forms.DialogResult.Cancel
                    Me.Close()
            End Select

        Catch ex As Exception
            EM.ErrorSyori(ex)
        Finally
            'ボタン可
            System.Windows.Forms.Application.DoEvents()
            For intCNT = 0 To Me.cmdFunc.Length - 1
                Me.cmdFunc(intCNT).Enabled = True
            Next
        End Try
    End Sub

#End Region

#Region "更新"

    Private Function FunSAVE() As Boolean
        Dim sbSQL As New System.Text.StringBuilder
        Dim strRET As String
        Dim sqlEx As New Exception
        Dim strSysDate As String
        Try

            '入力チェック
            If FunCheckInput() = False Then Return False

            Using DB As ClsDbUtility = DBOpen()
                Dim blnErr As Boolean
                Try
                    DB.BeginTransaction()

                    strSysDate = DB.GetSysDateString

                    '-----MERGE
                    sbSQL.Remove(0, sbSQL.Length)
                    sbSQL.Append($"MERGE INTO {NameOf(MODEL.M016_SYONIN_TANTO)} AS TARGET")
                    sbSQL.Append($" USING (SELECT")
                    sbSQL.Append($" {_M016.SYONIN_HOKOKUSYO_ID} AS {NameOf(_M016.SYONIN_HOKOKUSYO_ID)}")
                    sbSQL.Append($",'{_M016.SYONIN_JUN}' AS {NameOf(_M016.SYONIN_JUN)}")
                    sbSQL.Append($",'{_M016.SYAIN_ID}' AS {NameOf(_M016.SYAIN_ID)}")
                    sbSQL.Append($",'{strSysDate}' AS {NameOf(_M016.ADD_YMDHNS)}")
                    sbSQL.Append($",{pub_SYAIN_INFO.SYAIN_ID} AS {NameOf(_M016.ADD_SYAIN_ID)}")

                    sbSQL.Append($" ) AS WK ON (")
                    sbSQL.Append($" TARGET.{NameOf(_M016.SYONIN_HOKOKUSYO_ID)} = WK.{NameOf(_M016.SYONIN_HOKOKUSYO_ID)}")
                    sbSQL.Append($" AND TARGET.{NameOf(_M016.SYONIN_JUN)} = WK.{NameOf(_M016.SYONIN_JUN)}")
                    sbSQL.Append($" AND TARGET.{NameOf(_M016.SYAIN_ID)} = WK.{NameOf(_M016.SYAIN_ID)}")
                    sbSQL.Append($" )")

                    '---UPDATE 排他制御 更新日時が変更されていない場合のみ
                    sbSQL.Append($" WHEN MATCHED AND TARGET.{NameOf(_M016.ADD_YMDHNS)} = WK.{NameOf(_M016.ADD_YMDHNS)} THEN ")
                    sbSQL.Append($" UPDATE SET")
                    sbSQL.Append($" TARGET.{NameOf(_M016.ADD_YMDHNS)} = '{strSysDate}'")
                    sbSQL.Append($",TARGET.{NameOf(_M016.ADD_SYAIN_ID)} = WK.{NameOf(_M016.ADD_SYAIN_ID)}")

                    '---INSERT
                    sbSQL.Append($" WHEN NOT MATCHED THEN ")
                    sbSQL.Append($" INSERT(")
                    _M016.Properties.Take(1).ForEach(Sub(p) sbSQL.Append($" {p.Name}"))
                    _M016.Properties.Skip(1).ForEach(Sub(p) sbSQL.Append($",{p.Name}"))
                    sbSQL.Append($" ) VALUES(")
                    _M016.Properties.Take(1).ForEach(Sub(p) sbSQL.Append($" WK.{p.Name}"))
                    _M016.Properties.Skip(1).ForEach(Sub(p) sbSQL.Append($",WK.{p.Name}"))
                    sbSQL.Append(" )")
                    sbSQL.Append("OUTPUT $action As RESULT;")

                    strRET = DB.ExecuteScalar(sbSQL.ToString, conblnNonMsg, sqlEx)
                    Select Case strRET
                        Case "INSERT"

                        Case "UPDATE"

                        Case Else
                            If sqlEx.Source IsNot Nothing Then
                                '-----エラーログ出力
                                Dim strErrMsg As String = $"{My.Resources.ErrLogSqlExecutionFailure}{sbSQL.ToString}|{sqlEx.Message}"
                                WL.WriteLogDat(strErrMsg)
                            Else
                                '---排他制御
                                Dim strMsg As String = $"既に他の担当者によって変更されているため保存出来ません。{vbCrLf}再度登録し直して下さい。"
                                MessageBox.Show(strMsg, "同時更新無効", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                            End If
                            Return False
                    End Select
                Finally
                    DB.Commit(Not blnErr)
                End Try
            End Using

            Return True
        Catch ex As Exception
            EM.ErrorSyori(ex, False, conblnNonMsg)
            Return False
        Finally
        End Try
    End Function

#End Region

#Region "FuncButton有効無効切替"
    ''' <summary>
    ''' 使用しないボタンのキャプションをなくす、かつ非活性にする。
    ''' ファンクションキーを示す(F**)以外の文字がない場合は、未使用とみなす
    ''' </summary>
    ''' <param name="frm">対象フォーム</param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function FunInitFuncButtonEnabled() As Boolean

        Try
            For intFunc As Integer = 1 To 12
                With Me.Controls("cmdFunc" & intFunc)
                    If .Text.Length = 0 OrElse .Text.Substring(0, .Text.IndexOf("(")).IsNullOrWhiteSpace Then
                        .Text = ""
                        .Visible = False
                    End If
                End With
            Next intFunc


            Return True
        Catch ex As Exception
            EM.ErrorSyori(ex, False, conblnNonMsg)
            Return False
        End Try
    End Function
#End Region

#End Region

#Region "コントロールイベント"
    Private Sub CmbSYONIN_HOKOKUSYO_ID_SelectedValueChanged(sender As Object, e As EventArgs) Handles CmbSYONIN_HOKOKUSYO_ID.SelectedValueChanged
        Dim cmb As ComboboxEx = DirectCast(sender, ComboboxEx)

        CmbSYONIN_JUN.DataBindings.Clear()

        Using DB As ClsDbUtility = DBOpen()
            Select Case cmb.SelectedValue
                Case Context.ENM_SYONIN_HOKOKUSYO_ID._1_NCR
                    Call FunGetCodeDataTable(DB, "NCR", tblNCR)
                    CmbSYONIN_JUN.SetDataSource(tblNCR, ENM_COMBO_SELECT_VALUE_TYPE._1_Filter)
                Case Context.ENM_SYONIN_HOKOKUSYO_ID._2_CAR
                    Call FunGetCodeDataTable(DB, "CAR", tblCAR)
                    CmbSYONIN_JUN.SetDataSource(tblCAR, ENM_COMBO_SELECT_VALUE_TYPE._1_Filter)
                Case Else
                    CmbSYONIN_JUN.DataSource = Nothing
            End Select
        End Using
        CmbSYONIN_JUN.DataBindings.Add(New Binding(NameOf(CmbSYONIN_JUN.SelectedValue), _M016, NameOf(_M016.SYONIN_JUN), False, DataSourceUpdateMode.OnPropertyChanged, 0))
    End Sub
#End Region

#Region "入力チェック"
    Public Function FunCheckInput() As Boolean
        IsValidated = True

        Call CmbSYONIN_HOKOKUSYO_ID_Validating(CmbSYONIN_HOKOKUSYO_ID, Nothing)
        Call CmbSYONIN_JUN_Validating(CmbSYONIN_JUN, Nothing)
        Call CmbSYAIN_ID_Validating(CmbSYAIN_ID, Nothing)

        Return IsValidated
    End Function



    Private Sub CmbSYONIN_HOKOKUSYO_ID_Validating(sender As Object, e As System.ComponentModel.CancelEventArgs) Handles CmbSYONIN_HOKOKUSYO_ID.Validating
        Dim cmb As ComboboxEx = DirectCast(sender, ComboboxEx)

        If cmb.Selected Then
            ErrorProvider.ClearError(cmb)
            IsValidated = (IsValidated AndAlso True)
        Else
            ErrorProvider.SetError(cmb, String.Format(My.Resources.infoMsgRequireSelectOrInput, "承認報告書"), ErrorIconAlignment.MiddleLeft)
            IsValidated = False
        End If
    End Sub

    Private Sub CmbSYONIN_JUN_Validating(sender As Object, e As System.ComponentModel.CancelEventArgs) Handles CmbSYONIN_JUN.Validating
        Dim cmb As ComboboxEx = DirectCast(sender, ComboboxEx)

        If cmb.Selected Then
            ErrorProvider.ClearError(cmb)
            IsValidated = (IsValidated AndAlso True)
        Else
            ErrorProvider.SetError(cmb, String.Format(My.Resources.infoMsgRequireSelectOrInput, "承認順"), ErrorIconAlignment.MiddleLeft)
            IsValidated = False
        End If
    End Sub

    Private Sub CmbSYAIN_ID_Validating(sender As Object, e As System.ComponentModel.CancelEventArgs) Handles CmbSYAIN_ID.Validating
        Dim cmb As ComboboxEx = DirectCast(sender, ComboboxEx)

        If cmb.Selected Then
            ErrorProvider.ClearError(cmb)
            IsValidated = (IsValidated AndAlso True)
        Else
            ErrorProvider.SetError(cmb, String.Format(My.Resources.infoMsgRequireSelectOrInput, "社員"), ErrorIconAlignment.MiddleLeft)
            IsValidated = False
        End If
    End Sub
#End Region

#Region "ローカル関数"

#Region "バインディング"

    Private Function FunSetBinding() As Boolean
        CmbSYONIN_HOKOKUSYO_ID.DataBindings.Add(New Binding(NameOf(CmbSYONIN_HOKOKUSYO_ID.SelectedValue), _M016, NameOf(_M016.SYONIN_HOKOKUSYO_ID), False, DataSourceUpdateMode.OnPropertyChanged, 0))
        CmbSYAIN_ID.DataBindings.Add(New Binding(NameOf(CmbSYAIN_ID.SelectedValue), _M016, NameOf(_M016.SYAIN_ID), False, DataSourceUpdateMode.OnPropertyChanged, 0))
    End Function

#End Region


#End Region

End Class
