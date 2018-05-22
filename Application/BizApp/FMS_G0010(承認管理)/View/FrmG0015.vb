Imports JMS_COMMON.ClsPubMethod

''' <summary>
''' 転送画面
''' </summary>
Public Class FrmG0015

#Region "変数・定数"
    '入力必須コントロール検証判定
    Private pri_blnValidated As Boolean
#End Region

#Region "プロパティ"

    Public Property PrSYONIN_HOKOKUSYO_ID As Integer

    Public Property PrHOKOKU_NO As String

    Public Property PrCurrentStage As Integer
#End Region

#Region "コンストラクタ"

    ''' <summary>
    ''' コンストラクタ
    ''' </summary>
    ''' <remarks>コンストラクタ</remarks>
    Public Sub New()

        ' この呼び出しはデザイナーで必要です。
        InitializeComponent()

        cmbTENSO_SAKI.NullValue = 0
    End Sub

#End Region

#Region "FORMイベント"
    Private Sub Frm_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        Try
            '-----フォーム共通設定
            Call FunFormCommonSetting(pub_APP_INFO, pub_SYAIN_INFO)
            Me.Text = "転送登録"
            Me.lblTytle.Text = Me.Text

            '-----位置・サイズ
            Me.Height = 300
            Me.Width = 800
            Me.MinimumSize = New Size(800, 300)
            Me.Top = Me.Owner.Top + (Me.Owner.Height - Me.Height) / 2
            Me.Left = Me.Owner.Left + (Me.Owner.Width - Me.Width) / 2

            '-----ダイアログウィンドウ設定
            Me.FormBorderStyle = Windows.Forms.FormBorderStyle.FixedDialog
            Me.ControlBox = False

            '-----各コントロールのデータソースを設定
            Dim tbl As DataTable = tblTANTO_SYONIN.AsEnumerable.
                                    Where(Function(r) r.Field(Of Integer)("SYONIN_HOKOKUSYO_ID") = PrSYONIN_HOKOKUSYO_ID _
                                    And r.Field(Of Integer)("SYONIN_JUN") = PrCurrentStage _
                                    And r.Field(Of Integer)("VALUE") <> pub_SYAIN_INFO.SYAIN_ID).
                                    CopyToDataTable
            Me.cmbTENSO_SAKI.SetDataSource(tbl, ENM_COMBO_SELECT_VALUE_TYPE._0_Required)

            'バインディング
            Call FunSetBinding()

        Catch ex As Exception
            EM.ErrorSyori(ex, False, conblnNonMsg)
        Finally
            Call FunInitFuncButtonEnabled()
        End Try
    End Sub

#End Region

#Region "FUNCTIONボタン関連"

#Region "FUNCTIONボタンCLICKイベント"
    Private Sub CmdFunc_Click(ByVal sender As Object, ByVal e As EventArgs) Handles cmdFunc9.Click, cmdFunc8.Click, cmdFunc7.Click, cmdFunc6.Click, cmdFunc5.Click, cmdFunc4.Click, cmdFunc3.Click, cmdFunc2.Click, cmdFunc12.Click, cmdFunc11.Click, cmdFunc10.Click, cmdFunc1.Click
        Dim intFUNC As Integer
        Dim intCNT As Integer
        Dim blnRET As Boolean

        Try
            'ボタン不可/ボタンINDEX取得
            For intCNT = 0 To Me.cmdFunc.Length - 1
                Me.cmdFunc(intCNT).Enabled = False
                If cmdFunc(intCNT) Is sender Then intFUNC = intCNT + 1
            Next

            'ボタンINDEX毎の処理
            Select Case intFUNC
                Case 1  '追加
                    If FunCheckInput() Then
                        If FunSAVE() Then
                            Me.DialogResult = Windows.Forms.DialogResult.OK
                            Me.Close()
                        End If
                    End If

                Case 12 '戻る
                    Me.DialogResult = Windows.Forms.DialogResult.Cancel
                    Me.Close()
            End Select

        Catch ex As Exception
            EM.ErrorSyori(ex, False, conblnNonMsg)

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
        Dim dsList As New DataSet
        Dim sbSQL As New System.Text.StringBuilder

        Try

            'SPEC: 2.(3).D.①.レコード更新
            Using DB As ClsDbUtility = DBOpen()
                Dim intRET As Integer
                Dim sqlEx As New Exception
                Dim blnErr As Boolean

                Try
                    '-----トランザクション
                    DB.BeginTransaction()

                    '-----UPDATE D004
                    sbSQL.Remove(0, sbSQL.Length)
                    sbSQL.Append("UPDATE " & NameOf(MODEL.D004_SYONIN_J_KANRI) & " SET")
                    sbSQL.Append(" " & NameOf(_D004_SYONIN_J_KANRI.SYAIN_ID) & "=" & _D004_SYONIN_J_KANRI.SYAIN_ID & "")
                    sbSQL.Append(" ," & NameOf(_D004_SYONIN_J_KANRI.RIYU) & "='" & _D004_SYONIN_J_KANRI.RIYU & "'")
                    sbSQL.Append(" WHERE " & NameOf(_D004_SYONIN_J_KANRI.SYONIN_HOKOKUSYO_ID) & "=" & PrSYONIN_HOKOKUSYO_ID & "")
                    sbSQL.Append(" AND " & NameOf(_D004_SYONIN_J_KANRI.HOKOKU_NO) & "='" & PrHOKOKU_NO & "'")
                    sbSQL.Append(" AND " & NameOf(_D004_SYONIN_J_KANRI.SYONIN_JUN) & "=" & PrCurrentStage & "")

                    '-----SQL実行
                    intRET = DB.ExecuteNonQuery(sbSQL.ToString, conblnNonMsg, sqlEx)
                    If intRET <> 1 Then
                        '-----エラーログ出力
                        Dim strErrMsg As String = My.Resources.ErrLogSqlExecutionFailure & sbSQL.ToString & "|" & sqlEx.Message
                        WL.WriteLogDat(strErrMsg)
                        blnErr = True
                        Return False
                    End If

                    '-----データモデル更新
                    _R001_HOKOKU_SOUSA.SYONIN_HOKOKUSYO_ID = PrSYONIN_HOKOKUSYO_ID
                    _R001_HOKOKU_SOUSA.HOKOKU_NO = PrHOKOKU_NO
                    _R001_HOKOKU_SOUSA.SYONIN_JUN = PrCurrentStage
                    _R001_HOKOKU_SOUSA.SYAIN_ID = pub_SYAIN_INFO.SYAIN_ID
                    _R001_HOKOKU_SOUSA.SOUSA_KB = ENM_SOUSA_KB._5_転送
                    _R001_HOKOKU_SOUSA.SYONIN_HANTEI_KB = ENM_SYONIN_HANTEI_KB._1_承認
                    '_R001_HOKOKU_SOUSA.RIYU = ""
                    '-----INSERT R001
                    sbSQL.Remove(0, sbSQL.Length)
                    sbSQL.Append("INSERT INTO " & NameOf(MODEL.R001_HOKOKU_SOUSA) & "(")
                    sbSQL.Append("  " & NameOf(_R001_HOKOKU_SOUSA.SYONIN_HOKOKUSYO_ID))
                    sbSQL.Append(" ," & NameOf(_R001_HOKOKU_SOUSA.HOKOKU_NO))
                    sbSQL.Append(" ," & NameOf(_R001_HOKOKU_SOUSA.ADD_YMDHNS))
                    sbSQL.Append(" ," & NameOf(_R001_HOKOKU_SOUSA.SYONIN_JUN))
                    sbSQL.Append(" ," & NameOf(_R001_HOKOKU_SOUSA.SOUSA_KB))
                    sbSQL.Append(" ," & NameOf(_R001_HOKOKU_SOUSA.SYAIN_ID))
                    sbSQL.Append(" ," & NameOf(_R001_HOKOKU_SOUSA.SYONIN_HANTEI_KB))
                    sbSQL.Append(" ," & NameOf(_R001_HOKOKU_SOUSA.RIYU))
                    sbSQL.Append(" ) VALUES(")
                    sbSQL.Append("  " & (_R001_HOKOKU_SOUSA.SYONIN_HOKOKUSYO_ID))
                    sbSQL.Append(" ,'" & (_R001_HOKOKU_SOUSA.HOKOKU_NO) & "'")
                    sbSQL.Append(" ,dbo.GetSysDateString()") 'ADD_YMDHNS
                    sbSQL.Append(" ," & (_R001_HOKOKU_SOUSA.SYONIN_JUN))
                    sbSQL.Append(" ,'" & (_R001_HOKOKU_SOUSA.SOUSA_KB) & "'")
                    sbSQL.Append(" ," & (_R001_HOKOKU_SOUSA.SYAIN_ID))
                    sbSQL.Append(" ,'" & (_R001_HOKOKU_SOUSA.SYONIN_HANTEI_KB) & "'")
                    sbSQL.Append(" ,'" & (_R001_HOKOKU_SOUSA.RIYU) & "'")
                    sbSQL.Append(")")

                    '-----SQL実行
                    intRET = DB.ExecuteNonQuery(sbSQL.ToString, conblnNonMsg, sqlEx)
                    If intRET <> 1 Then
                        '-----エラーログ出力
                        Dim strErrMsg As String = My.Resources.ErrLogSqlExecutionFailure & sbSQL.ToString & "|" & sqlEx.Message
                        WL.WriteLogDat(strErrMsg)
                        Return False
                    End If
                Finally
                    '-----トランザクション
                    DB.Commit(Not blnErr)
                End Try
            End Using


            Return True
        Catch ex As Exception
            Throw
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
    Private Function FunInitFuncButtonEnabled() As Boolean
        Try

            For intFunc As Integer = 1 To 12
                Dim cmd As Button = DirectCast(Me.Controls.Find("cmdFunc" & intFunc, True)(0), Button)
                With cmd
                    If cmd IsNot Nothing AndAlso .Text.Length = 0 OrElse .Text.Substring(0, .Text.IndexOf("(")).IsNullOrWhiteSpace Then
                        .Text = ""
                        '.Visible = False
                        .Enabled = False
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

    Private Sub CmbMODOSI_SAKI_Validating(sender As Object, e As System.ComponentModel.CancelEventArgs) Handles cmbTENSO_SAKI.Validating
        Dim cmb As ComboboxEx = DirectCast(sender, ComboboxEx)

        If cmb.SelectedValue = cmb.NullValue Then
            'e.Cancel = True
            ErrorProvider.SetError(cmb, String.Format(My.Resources.infoMsgRequireSelectOrInput, "転送先"))
            ErrorProvider.SetIconAlignment(cmb, ErrorIconAlignment.MiddleLeft)
            pri_blnValidated = False
        Else
            ErrorProvider.ClearError(cmb)
            pri_blnValidated = True
        End If
    End Sub

    Private Sub MtxMODOSI_RIYU_Validating(sender As Object, e As System.ComponentModel.CancelEventArgs) Handles mtxTENSO_RIYU.Validating
        Dim mtx As MaskedTextBoxEx = DirectCast(sender, MaskedTextBoxEx)

        If mtx.Text.IsNullOrWhiteSpace = True Then
            'e.Cancel = True
            ErrorProvider.SetError(mtx, String.Format(My.Resources.infoMsgRequireSelectOrInput, "転送理由"))
            ErrorProvider.SetIconAlignment(mtx, ErrorIconAlignment.MiddleLeft)
            pri_blnValidated = False
        Else
            ErrorProvider.ClearError(mtx)
            pri_blnValidated = True
        End If
    End Sub
#End Region

#Region "入力チェック"
    Public Function FunCheckInput() As Boolean
        Try
            Call CmbMODOSI_SAKI_Validating(cmbTENSO_SAKI, Nothing)
            Call MtxMODOSI_RIYU_Validating(mtxTENSO_RIYU, Nothing)

            Return pri_blnValidated
        Catch ex As Exception
            EM.ErrorSyori(ex, False, conblnNonMsg)
            Return False
        End Try
    End Function
#End Region

#Region "ローカル関数"
    Private Function FunSetBinding() As Boolean
        cmbTENSO_SAKI.DataBindings.Add(New Binding(NameOf(cmbTENSO_SAKI.SelectedValue), _D004_SYONIN_J_KANRI, NameOf(_D004_SYONIN_J_KANRI.SYAIN_ID), False, DataSourceUpdateMode.OnPropertyChanged, 0))
        mtxTENSO_RIYU.DataBindings.Add(New Binding(NameOf(mtxTENSO_RIYU.Text), _D004_SYONIN_J_KANRI, NameOf(_D004_SYONIN_J_KANRI.RIYU), False, DataSourceUpdateMode.OnPropertyChanged, ""))
    End Function
#End Region


End Class
