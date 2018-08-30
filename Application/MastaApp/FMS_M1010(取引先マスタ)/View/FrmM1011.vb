Imports JMS_COMMON.ClsPubMethod

Public Class FrmM1011

#Region "変数・定数"
    '入力必須コントロール検証判定
    Private pri_blnValidated As Boolean

    Private _M02 As New Model.M02_TORIHIKI
#End Region

#Region "プロパティ"
    ''' <summary>
    ''' 処理モード
    ''' </summary>
    Public Property PrMODE As Integer
        Get
            Return _intMODE
        End Get
        Set(value As Integer)
            _intMODE = value
        End Set
    End Property
    Private _intMODE As Integer      '処理モード

    ''' <summary>
    ''' 新規追加レコードのキー
    ''' </summary>
    Public Property PrPKeys As Integer
        Get
            Return _PKs
        End Get
        Set(value As Integer)
            _PKs = value
        End Set
    End Property
    Private _PKs As String

    ''' <summary>
    ''' 一覧選択レコード
    ''' </summary>
    ''' <returns></returns>
    Public Property PrDataRow As DataRow

#End Region

#Region "FORMイベント"
    Private Sub Frm_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        Try
            '-----フォーム共通設定
            Call FunFormCommonSetting(pub_APP_INFO, pub_SYAIN_INFO)

            '-----位置・サイズ
            Me.Height = 700
            Me.Top = Me.Owner.Top + (Me.Owner.Height - Me.Height) - 26 ' / 2
            Me.Left = Me.Owner.Left + (Me.Owner.Width - Me.Width) / 2

            '-----各コントロールのデータソースを設定
            Me.cmbTORI_SYU.SetDataSource(tblTORI_SYU.ExcludeDeleted, ENM_COMBO_SELECT_VALUE_TYPE._0_Required)
            Me.cmbSEIKYU_CD.SetDataSource(tblHACYU_CD.ExcludeDeleted, ENM_COMBO_SELECT_VALUE_TYPE._0_Required)
            Me.cmbSIIRE_GAICYU_KB.SetDataSource(tblNAIGAI_KB.ExcludeDeleted, ENM_COMBO_SELECT_VALUE_TYPE._0_Required)
            Me.cmbURIZEI_KB.SetDataSource(tblURI_KBN.ExcludeDeleted, ENM_COMBO_SELECT_VALUE_TYPE._0_Required)
            Me.cmbSIZEI_KB.SetDataSource(tblSHI_KBN.ExcludeDeleted, ENM_COMBO_SELECT_VALUE_TYPE._0_Required)
            Me.cmbURI_TAX_HASU_KB.SetDataSource(tblTAX_HASU_KB.ExcludeDeleted, ENM_COMBO_SELECT_VALUE_TYPE._0_Required)
            Me.cmbSIIRE_TAX_HASU_KB.SetDataSource(tblTAX_HASU_KB.ExcludeDeleted, ENM_COMBO_SELECT_VALUE_TYPE._0_Required)
            Me.cmbS_TANTOU_CD.SetDataSource(tblTANTO.ExcludeDeleted, ENM_COMBO_SELECT_VALUE_TYPE._0_Required)

            Dim intTORI_SYU As Integer
            For Each item As Integer In [Enum].GetValues(GetType(Context.ENM_TORI_SYU))
                intTORI_SYU = intTORI_SYU + item
            Next


            Call FunSetBinding()

            '-----処理モード別画面初期化
            If FunInitializeControls(PrMODE) = False Then
                Me.Close()
            End If
            '-----ダイアログウィンドウ設定
            Me.FormBorderStyle = Windows.Forms.FormBorderStyle.FixedDialog
            Me.ControlBox = False

        Catch ex As Exception
            EM.ErrorSyori(ex, False, conblnNonMsg)
        End Try
    End Sub

#End Region

#Region "FUNCTIONボタン関連"

#Region "ボタンクリックイベント"
    Private Sub CmdFunc_Click(ByVal sender As Object, ByVal e As EventArgs) Handles cmdFunc1.Click, cmdFunc2.Click, cmdFunc3.Click, cmdFunc4.Click, cmdFunc5.Click, cmdFunc6.Click, cmdFunc7.Click, cmdFunc8.Click, cmdFunc9.Click, cmdFunc10.Click, cmdFunc11.Click, cmdFunc12.Click
        Dim intFUNC As Integer
        Dim intCNT As Integer
        'Dim blnRET As Boolean

        Try
            'ボタン不可/ボタンINDEX取得
            For intCNT = 0 To Me.cmdFunc.Length - 1
                Me.cmdFunc(intCNT).Enabled = False
                If cmdFunc(intCNT) Is sender Then intFUNC = intCNT + 1
            Next

            'ボタンINDEX毎の処理
            Select Case intFUNC
                Case 1  '追加変更
                    If FunSAVE() Then
                        'プロパティに対象レコードのキーを設定
                        Me.PrPKeys = _M02.TORI_CD

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

                    strSysDate = DB.GetSysDateString()

                    Dim ModelInfo As New Model.ModelInfo(Of Model.M02_TORIHIKI) With {.OnlyAutoGenerateField = True}
                    _M02.ADD_YMDHNS = strSysDate
                    _M02.ADD_TANTO_CD = pub_SYAIN_INFO.SYAIN_ID
                    _M02.EDIT_TANTO_CD = pub_SYAIN_INFO.SYAIN_ID
                    'Select Case PrMODE
                    '    Case ENM_DATA_OPERATION_MODE._1_ADD, ENM_DATA_OPERATION_MODE._2_ADDREF
                    '        _M02.TORI_CD = FunGetNextTORI_CD()
                    '    Case Else
                    'End Select

                    '-----MERGE
                    sbSQL.Remove(0, sbSQL.Length)
                    sbSQL.Append($"MERGE INTO {ModelInfo.Name} AS TARGET")
                    sbSQL.Append($" USING (SELECT")

                    sbSQL.Append($" {_M02.TORI_CD} AS {NameOf(_M02.TORI_CD)}")
                    sbSQL.Append($",'{_M02.TORI_NAME}' AS {NameOf(_M02.TORI_NAME)}")

                    'UNDONE: すべてのフィールドを追加
                    sbSQL.Append($",'{_M02.TORI_SYU}' AS {NameOf(_M02.TORI_SYU)}")
                    sbSQL.Append($",'{_M02.SIIRE_GAICYU_KB}' AS {NameOf(_M02.SIIRE_GAICYU_KB)}")
                    'FLG
                    sbSQL.Append($",'{Val(_M02._SYOKUCHI_FLG)}' AS {NameOf(_M02.SYOKUCHI_FLG)}")
                    sbSQL.Append($",'{_M02.FURIGANA}' AS {NameOf(_M02.FURIGANA)}")
                    sbSQL.Append($",'{_M02.TORI_R_NAME}' AS {NameOf(_M02.TORI_R_NAME)}")
                    sbSQL.Append($",'{_M02.TORI_SITEN_NAME}' AS {NameOf(_M02.TORI_SITEN_NAME)}")
                    sbSQL.Append($",'{_M02.TORI_TANTO_NAME}' AS {NameOf(_M02.TORI_TANTO_NAME)}")
                    sbSQL.Append($",'{_M02.YUBIN}' AS {NameOf(_M02.YUBIN)}")
                    sbSQL.Append($",'{_M02.ADDRESS1}' AS {NameOf(_M02.ADDRESS1)}")
                    sbSQL.Append($",'{_M02.ADDRESS2}' AS {NameOf(_M02.ADDRESS2)}")
                    sbSQL.Append($",'{_M02.ADDRESS3}' AS {NameOf(_M02.ADDRESS3)}")
                    sbSQL.Append($",'{_M02.TEL}' AS {NameOf(_M02.TEL)}")
                    sbSQL.Append($",'{_M02.FAX}' AS {NameOf(_M02.FAX)}")
                    sbSQL.Append($",{_M02.S_TANTO_CD} AS {NameOf(_M02.S_TANTO_CD)}")
                    sbSQL.Append($",{_M02.SEIKYU_CD} AS {NameOf(_M02.SEIKYU_CD)}")
                    sbSQL.Append($",'{_M02.URIZEI_KB}' AS {NameOf(_M02.URIZEI_KB)}")
                    sbSQL.Append($",'{_M02.URI_TAX_HASU_KB}' AS {NameOf(_M02.URI_TAX_HASU_KB)}")
                    sbSQL.Append($",'{_M02.SIZEI_KB}' AS {NameOf(_M02.SIZEI_KB)}")
                    sbSQL.Append($",'{_M02.SIIRE_TAX_HASU_KB}' AS {NameOf(_M02.SIIRE_TAX_HASU_KB)}")
                    sbSQL.Append($",{_M02.LEAD_TIME} AS {NameOf(_M02.LEAD_TIME)}")
                    sbSQL.Append($",'{_M02.SIME_DAY}' AS {NameOf(_M02.SIME_DAY)}")
                    sbSQL.Append($",'{_M02.SIHARAI_DAY}' AS {NameOf(_M02.SIHARAI_DAY)}")
                    sbSQL.Append($",'{_M02.MEMO}' AS {NameOf(_M02.MEMO)}")
                    sbSQL.Append($",'{_M02.TORI_FUGO}' AS {NameOf(_M02.TORI_FUGO)}")

                    sbSQL.Append($",'{_M02.ADD_YMDHNS}' AS {NameOf(_M02.ADD_YMDHNS)}")
                    sbSQL.Append($",{_M02.ADD_TANTO_CD} AS {NameOf(_M02.ADD_TANTO_CD)}")
                    sbSQL.Append($",'{_M02.EDIT_YMDHNS}' AS {NameOf(_M02.EDIT_YMDHNS)}")
                    sbSQL.Append($",{_M02.EDIT_TANTO_CD} AS {NameOf(_M02.EDIT_TANTO_CD)}")
                    sbSQL.Append($",'{_M02.DEL_YMDHNS}' AS {NameOf(_M02.DEL_YMDHNS)}")
                    sbSQL.Append($",{_M02.DEL_TANTO_CD} AS {NameOf(_M02.DEL_TANTO_CD)}")

                    sbSQL.Append($" ) AS WK")
                    'テーブルのキー
                    sbSQL.Append($" ON (TARGET.{NameOf(_M02.TORI_CD)} = WK.{NameOf(_M02.TORI_CD)})")

                    '---UPDATE 排他制御 更新日時が変更されていない場合のみ
                    sbSQL.Append($" WHEN MATCHED AND TARGET.{NameOf(_M02.EDIT_YMDHNS)} = WK.{NameOf(_M02.EDIT_YMDHNS)} THEN ")
                    sbSQL.Append($" UPDATE SET")
                    sbSQL.Append($" TARGET.{NameOf(_M02.TORI_NAME)} = WK.{NameOf(_M02.TORI_NAME)}")

                    'UNDONE: キー項目と追加削除担当者・日時を除くフィールドを追加
                    sbSQL.Append($" ,TARGET.{NameOf(_M02.TORI_SYU)} = WK.{NameOf(_M02.TORI_SYU)}")
                    sbSQL.Append($" ,TARGET.{NameOf(_M02.SIIRE_GAICYU_KB)} = WK.{NameOf(_M02.SIIRE_GAICYU_KB)}")
                    sbSQL.Append($" ,TARGET.{NameOf(_M02.SYOKUCHI_FLG)} = WK.{NameOf(_M02.SYOKUCHI_FLG)}")
                    sbSQL.Append($" ,TARGET.{NameOf(_M02.FURIGANA)} = WK.{NameOf(_M02.FURIGANA)}")
                    sbSQL.Append($" ,TARGET.{NameOf(_M02.TORI_R_NAME)} = WK.{NameOf(_M02.TORI_R_NAME)}")
                    sbSQL.Append($" ,TARGET.{NameOf(_M02.TORI_SITEN_NAME)} = WK.{NameOf(_M02.TORI_SITEN_NAME)}")
                    sbSQL.Append($" ,TARGET.{NameOf(_M02.TORI_TANTO_NAME)} = WK.{NameOf(_M02.TORI_TANTO_NAME)}")
                    sbSQL.Append($" ,TARGET.{NameOf(_M02.YUBIN)} = WK.{NameOf(_M02.YUBIN)}")
                    sbSQL.Append($" ,TARGET.{NameOf(_M02.ADDRESS1)} = WK.{NameOf(_M02.ADDRESS1)}")
                    sbSQL.Append($" ,TARGET.{NameOf(_M02.ADDRESS2)} = WK.{NameOf(_M02.ADDRESS2)}")
                    sbSQL.Append($" ,TARGET.{NameOf(_M02.ADDRESS3)} = WK.{NameOf(_M02.ADDRESS3)}")
                    sbSQL.Append($" ,TARGET.{NameOf(_M02.TEL)} = WK.{NameOf(_M02.TEL)}")
                    sbSQL.Append($" ,TARGET.{NameOf(_M02.FAX)} = WK.{NameOf(_M02.FAX)}")
                    sbSQL.Append($" ,TARGET.{NameOf(_M02.S_TANTO_CD)} = WK.{NameOf(_M02.S_TANTO_CD)}")
                    sbSQL.Append($" ,TARGET.{NameOf(_M02.SEIKYU_CD)} = WK.{NameOf(_M02.SEIKYU_CD)}")
                    sbSQL.Append($" ,TARGET.{NameOf(_M02.URIZEI_KB)} = WK.{NameOf(_M02.URIZEI_KB)}")
                    sbSQL.Append($" ,TARGET.{NameOf(_M02.URI_TAX_HASU_KB)} = WK.{NameOf(_M02.URI_TAX_HASU_KB)}")
                    sbSQL.Append($" ,TARGET.{NameOf(_M02.SIZEI_KB)} = WK.{NameOf(_M02.SIZEI_KB)}")
                    sbSQL.Append($" ,TARGET.{NameOf(_M02.SIIRE_TAX_HASU_KB)} = WK.{NameOf(_M02.SIIRE_TAX_HASU_KB)}")
                    sbSQL.Append($" ,TARGET.{NameOf(_M02.LEAD_TIME)} = WK.{NameOf(_M02.LEAD_TIME)}")
                    sbSQL.Append($" ,TARGET.{NameOf(_M02.SIME_DAY)} = WK.{NameOf(_M02.SIME_DAY)}")
                    sbSQL.Append($" ,TARGET.{NameOf(_M02.SIHARAI_DAY)} = WK.{NameOf(_M02.SIHARAI_DAY)}")
                    sbSQL.Append($" ,TARGET.{NameOf(_M02.MEMO)} = WK.{NameOf(_M02.MEMO)}")
                    sbSQL.Append($" ,TARGET.{NameOf(_M02.TORI_FUGO)} = WK.{NameOf(_M02.TORI_FUGO)}")

                    sbSQL.Append($",TARGET.{NameOf(_M02.EDIT_YMDHNS)} = '{strSysDate}'")
                    sbSQL.Append($",TARGET.{NameOf(_M02.EDIT_TANTO_CD)} = WK.{NameOf(_M02.EDIT_TANTO_CD)}")

                    '---INSERT
                    sbSQL.Append($" WHEN NOT MATCHED THEN ")
                    sbSQL.Append($" INSERT(")
                    ModelInfo.Properties.Take(1).ForEach(Sub(p) sbSQL.Append($" {p.Name}"))
                    ModelInfo.Properties.Skip(1).ForEach(Sub(p) sbSQL.Append($",{p.Name}"))
                    sbSQL.Append($" ) VALUES(")
                    ModelInfo.Properties.Take(1).ForEach(Sub(p) sbSQL.Append($" WK.{p.Name}"))
                    ModelInfo.Properties.Skip(1).ForEach(Sub(p) sbSQL.Append($",WK.{p.Name}"))
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
        Finally
        End Try
    End Function

#End Region

#End Region

#Region "コントロールイベント"
    Private Sub MtxYUBIN_Validated(sender As Object, e As EventArgs) Handles mtxYUBIN.Validated
        Call BtnSrchYubin_Click(Nothing, Nothing)
    End Sub

    '住所検索
    Private Sub BtnSrchYubin_Click(sender As Object, e As EventArgs) Handles btnSrchYubin.Click
        Dim sbSQL As New System.Text.StringBuilder
        Dim dsList As New System.Data.DataSet

        Try
            If Me.mtxYUBIN.Text.Replace("〒", "").Replace(" ", "").Replace("-", "").Length < 7 And Me.mtxYUBIN.Text.Replace("〒", "").Replace(" ", "").Replace("-", "").Length > 0 Then
                MessageBox.Show("郵便番号が不正です。", "住所検索", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Me.mtxYUBIN.Focus()
                Exit Sub
            ElseIf Me.mtxYUBIN.Text.Replace("〒", "").Replace(" ", "").Replace("-", "").Length = 0 Then
                Exit Sub
            End If

            'SQL
            sbSQL.Remove(0, sbSQL.Length)
            sbSQL.Append("SELECT ")
            sbSQL.Append(" 郵便番号7, ")
            sbSQL.Append(" 都道府県名, ")
            sbSQL.Append(" 市区町村名, ")
            sbSQL.Append(" 町域名 ")
            sbSQL.Append(" FROM " & "PostalCode" & " ")
            sbSQL.Append(" Where 郵便番号7='" & Me.mtxYUBIN.Text.Replace("〒", "").Replace("-", "") & "' ")
            Using DB As ClsDbUtility = DBOpen()
                dsList = DB.GetDataSet(sbSQL.ToString, conblnNonMsg)
            End Using

            With dsList.Tables(0)
                If .Rows.Count > 0 Then
                    Me.mtxADDRESS1.Text = .Rows(0).Item("都道府県名").ToString & .Rows(0).Item("市区町村名").ToString & .Rows(0).Item("町域名").ToString
                    Me.mtxADDRESS1.Focus()
                    SendKeys.Send("{RIGHT}")
                Else
                    MessageBox.Show("入力された郵便番号に該当する住所が存在しません。", "住所検索", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    Me.mtxYUBIN.Focus()
                End If
            End With

        Catch ex As Exception
            EM.ErrorSyori(ex, False, conblnNonMsg)
        Finally
            dsList.Dispose()
        End Try
    End Sub

#End Region

#Region "入力チェック"
    Public Function FunCheckInput() As Boolean

        Try
            pri_blnValidated = True

            '取引種別
            Call CmbTORI_SYU_Validating(cmbTORI_SYU, Nothing)

            '仕入先外注区分
            Call CmbSIIRE_GAICYU_KB_Validating(cmbSIIRE_GAICYU_KB, Nothing)

            '取引先名
            Call MtxTORI_NAME_Validating(mtxTORI_NAME, Nothing)

            '請求先
            Call CmbSEIKYU_CD_Validating(cmbSEIKYU_CD, Nothing)

            '売税区分
            Call CmbURIZEI_KB_Validating(cmbURIZEI_KB, Nothing)

            '仕税区分
            Call CmbSIZEI_KB_Validating(cmbSIZEI_KB, Nothing)

            '売税端数処理区分
            Call CmbURI_TAX_HASU_KB_Validating(cmbURI_TAX_HASU_KB, Nothing)

            '仕税端数処理区分
            Call CmbSIIRE_TAX_HASU_KB_Validating(cmbSIIRE_TAX_HASU_KB, Nothing)

            '社内担当者
            Call CmbS_TANTOU_CD_Validating(cmbS_TANTOU_CD, Nothing)

            Call MtxLEAD_TIME_Validated(mtxLEAD_TIME, Nothing)
            Call MtxSIME_DAY_Validated(mtxSIME_DAY, Nothing)
            Call MtxSIHARAI_DAY_Validated(mtxSIHARAI_DAY, Nothing)

            Return pri_blnValidated
        Catch ex As Exception
            EM.ErrorSyori(ex, False, conblnNonMsg)
            Return False

        End Try
    End Function

#End Region

#Region "ローカル関数"

    Private Function FunGetNextTORI_CD() As Integer
        Dim dsList As New System.Data.DataSet
        Try
            Dim intRET As Integer
            Dim sbSQL As New System.Text.StringBuilder
            Using DB As ClsDbUtility = DBOpen()
                sbSQL.Remove(0, sbSQL.Length)
                sbSQL.Append("SELECT TORI_CD FROM " & NameOf(Model.VWM02_TORIHIKI) & "")
                dsList = DB.GetDataSet(sbSQL.ToString, conblnNonMsg)

                If dsList.Tables(0).Rows.Count > 0 Then
                    sbSQL.Remove(0, sbSQL.Length)
                    sbSQL.Append("SELECT MAX(TORI_CD) FROM " & NameOf(Model.VWM02_TORIHIKI) & "")

                    dsList = DB.GetDataSet(sbSQL.ToString, conblnNonMsg)

                    intRET = Val(dsList.Tables(0).Rows(0).Item(0)) + 1
                Else
                    intRET = 1
                End If
            End Using
            Return intRET
        Catch ex As Exception
            EM.ErrorSyori(ex, False, conblnNonMsg)
            Return -1
        Finally
            dsList.Dispose()
        End Try
    End Function

#Region "バインディング"

    Private Function FunSetBinding() As Boolean

        cmbSIIRE_GAICYU_KB.DataBindings.Add(New Binding(NameOf(cmbSIIRE_GAICYU_KB.SelectedValue), _M02, NameOf(_M02.SIIRE_GAICYU_KB), False, DataSourceUpdateMode.OnPropertyChanged, ""))
        cmbTORI_SYU.DataBindings.Add(New Binding(NameOf(cmbTORI_SYU.SelectedValue), _M02, NameOf(_M02.TORI_SYU), False, DataSourceUpdateMode.OnPropertyChanged, ""))
        cbSYOKUCHI_FG.DataBindings.Add(New Binding(NameOf(cbSYOKUCHI_FG.Checked), _M02, NameOf(_M02.SYOKUCHI_FLG), False, DataSourceUpdateMode.OnPropertyChanged, False))
        mtxTORI_NAME.DataBindings.Add(New Binding(NameOf(mtxTORI_NAME.Text), _M02, NameOf(_M02.TORI_NAME), False, DataSourceUpdateMode.OnPropertyChanged, ""))
        mtxFURIGANA.DataBindings.Add(New Binding(NameOf(mtxFURIGANA.Text), _M02, NameOf(_M02.FURIGANA), False, DataSourceUpdateMode.OnPropertyChanged, ""))
        mtxTORI_R_NAME.DataBindings.Add(New Binding(NameOf(mtxTORI_R_NAME.Text), _M02, NameOf(_M02.TORI_R_NAME), False, DataSourceUpdateMode.OnPropertyChanged, ""))
        mtxTORI_FUGO.DataBindings.Add(New Binding(NameOf(mtxTORI_FUGO.Text), _M02, NameOf(_M02.TORI_FUGO), False, DataSourceUpdateMode.OnPropertyChanged, ""))
        mtxTORI_SITEN_NAME.DataBindings.Add(New Binding(NameOf(mtxTORI_SITEN_NAME.Text), _M02, NameOf(_M02.TORI_SITEN_NAME), False, DataSourceUpdateMode.OnPropertyChanged, ""))
        mtxTORI_TANTO_NAME.DataBindings.Add(New Binding(NameOf(mtxTORI_TANTO_NAME.Text), _M02, NameOf(_M02.TORI_TANTO_NAME), False, DataSourceUpdateMode.OnPropertyChanged, ""))
        cmbSEIKYU_CD.DataBindings.Add(New Binding(NameOf(cmbSEIKYU_CD.SelectedValue), _M02, NameOf(_M02.SEIKYU_CD), False, DataSourceUpdateMode.OnPropertyChanged, 0))
        mtxLEAD_TIME.DataBindings.Add(New Binding(NameOf(mtxLEAD_TIME.Text), _M02, NameOf(_M02.LEAD_TIME), False, DataSourceUpdateMode.OnPropertyChanged, 0))

        cmbURIZEI_KB.DataBindings.Add(New Binding(NameOf(cmbURIZEI_KB.SelectedValue), _M02, NameOf(_M02.URIZEI_KB), False, DataSourceUpdateMode.OnPropertyChanged, ""))
        cmbURI_TAX_HASU_KB.DataBindings.Add(New Binding(NameOf(cmbURI_TAX_HASU_KB.SelectedValue), _M02, NameOf(_M02.URI_TAX_HASU_KB), False, DataSourceUpdateMode.OnPropertyChanged, ""))
        cmbSIZEI_KB.DataBindings.Add(New Binding(NameOf(cmbSIZEI_KB.SelectedValue), _M02, NameOf(_M02.SIZEI_KB), False, DataSourceUpdateMode.OnPropertyChanged, ""))
        cmbSIIRE_TAX_HASU_KB.DataBindings.Add(New Binding(NameOf(cmbSIIRE_TAX_HASU_KB.SelectedValue), _M02, NameOf(_M02.SIIRE_TAX_HASU_KB), False, DataSourceUpdateMode.OnPropertyChanged, ""))

        mtxSIME_DAY.DataBindings.Add(New Binding(NameOf(mtxSIME_DAY.Text), _M02, NameOf(_M02.SIME_DAY), False, DataSourceUpdateMode.OnPropertyChanged, ""))
        mtxSIHARAI_DAY.DataBindings.Add(New Binding(NameOf(mtxSIHARAI_DAY.Text), _M02, NameOf(_M02.SIHARAI_DAY), False, DataSourceUpdateMode.OnPropertyChanged, ""))

        mtxYUBIN.DataBindings.Add(New Binding(NameOf(mtxYUBIN.Text), _M02, NameOf(_M02.YUBIN), False, DataSourceUpdateMode.OnPropertyChanged, ""))
        mtxADDRESS1.DataBindings.Add(New Binding(NameOf(mtxADDRESS1.Text), _M02, NameOf(_M02.ADDRESS1), False, DataSourceUpdateMode.OnPropertyChanged, ""))
        mtxADDRESS2.DataBindings.Add(New Binding(NameOf(mtxADDRESS2.Text), _M02, NameOf(_M02.ADDRESS2), False, DataSourceUpdateMode.OnPropertyChanged, ""))
        mtxADDRESS3.DataBindings.Add(New Binding(NameOf(mtxADDRESS3.Text), _M02, NameOf(_M02.ADDRESS3), False, DataSourceUpdateMode.OnPropertyChanged, ""))

        mtxTEL1.DataBindings.Add(New Binding(NameOf(mtxTEL1.Text), _M02, NameOf(_M02.TEL_P1), False, DataSourceUpdateMode.OnPropertyChanged, ""))
        mtxTEL2.DataBindings.Add(New Binding(NameOf(mtxTEL2.Text), _M02, NameOf(_M02.TEL_P2), False, DataSourceUpdateMode.OnPropertyChanged, ""))
        mtxTEL3.DataBindings.Add(New Binding(NameOf(mtxTEL3.Text), _M02, NameOf(_M02.TEL_P3), False, DataSourceUpdateMode.OnPropertyChanged, ""))
        mtxFAX1.DataBindings.Add(New Binding(NameOf(mtxFAX1.Text), _M02, NameOf(_M02.FAX_P1), False, DataSourceUpdateMode.OnPropertyChanged, ""))
        mtxFAX2.DataBindings.Add(New Binding(NameOf(mtxFAX2.Text), _M02, NameOf(_M02.FAX_P2), False, DataSourceUpdateMode.OnPropertyChanged, ""))
        mtxFAX3.DataBindings.Add(New Binding(NameOf(mtxFAX3.Text), _M02, NameOf(_M02.FAX_P3), False, DataSourceUpdateMode.OnPropertyChanged, ""))

        cmbS_TANTOU_CD.DataBindings.Add(New Binding(NameOf(cmbS_TANTOU_CD.SelectedValue), _M02, NameOf(_M02.S_TANTO_CD), False, DataSourceUpdateMode.OnPropertyChanged, 0))
        mtxMEMO.DataBindings.Add(New Binding(NameOf(mtxMEMO.Text), _M02, NameOf(_M02.MEMO), False, DataSourceUpdateMode.OnPropertyChanged, ""))

    End Function

#End Region

#Region "処理モード別画面初期化"
    ''' <summary>
    ''' 処理モード別画面初期化
    ''' </summary>
    ''' <param name="intMODE"></param>
    ''' <returns></returns>
    Private Function FunInitializeControls(ByVal intMODE As Integer) As Boolean

        Try
            Dim _Model = New Model.ModelInfo(Of Model.M02_TORIHIKI)(_OnlyAutoGenerateField:=True)

            Select Case intMODE
                Case ENM_DATA_OPERATION_MODE._1_ADD
                    Me.Text = pub_APP_INFO.strTitle & "（追加）"
                    Me.lblTytle.Text = Me.Text
                    Me.cmdFunc1.Text = "追加(F1)"

                    Me.lbllblEDIT_YMDHNS.Visible = False
                    Me.lblEDIT_YMDHNS.Visible = False
                    Me.lblEDIT_SYAIN_ID.Visible = False
                    Me.lbllblEDIT_SYAIN_ID.Visible = False

                    Me.cmbTORI_SYU.SelectedValue = "1"
                    Me.cmbSIZEI_KB.SelectedValue = "1"
                    Me.cmbSIIRE_GAICYU_KB.SelectedValue = "1"
                    Me.cmbSIIRE_TAX_HASU_KB.SelectedValue = "1"
                    Me.cmbURIZEI_KB.SelectedValue = "1"
                    Me.cmbURI_TAX_HASU_KB.SelectedValue = "1"
                    Me.mtxLEAD_TIME.Text = 0
                    Me.mtxSIME_DAY.Text = 0
                    Me.mtxSIHARAI_DAY.Text = 0
                    'Me.mtxTORI_CD.Text = "<新規>"
                    'Me.mtxTORI_CD.ReadOnly = True
                Case ENM_DATA_OPERATION_MODE._2_ADDREF
                    '一覧選択行のデータをモデルに読込
                    _Model.Properties.ForEach(Sub(p) _M02(p.Name) = PrDataRow.Item(p.Name))

                    Me.Text = pub_APP_INFO.strTitle & "（類似追加）"
                    Me.lblTytle.Text = Me.Text
                    Me.cmdFunc1.Text = "追加(F1)"

                    Me.lbllblEDIT_YMDHNS.Visible = False
                    Me.lblEDIT_YMDHNS.Visible = False
                    Me.lblEDIT_SYAIN_ID.Visible = False
                    Me.lbllblEDIT_SYAIN_ID.Visible = False

                    cbSYOKUCHI_FG.Text = "諸口"
                    'Me.mtxTORI_CD.Text = "<新規>"
                    'Me.mtxTORI_CD.ReadOnly = True

                Case ENM_DATA_OPERATION_MODE._3_UPDATE
                    mtxTORI_CD.DataBindings.Add(New Binding(NameOf(mtxTORI_CD.Text), _M02, NameOf(_M02.TORI_CD), False, DataSourceUpdateMode.OnPropertyChanged, 0))

                    '一覧選択行のデータをモデルに読込
                    _Model.Properties.ForEach(Sub(p) _M02(p.Name) = PrDataRow.Item(p.Name))

                    Me.Text = pub_APP_INFO.strTitle & "（変更）"
                    Me.lblTytle.Text = Me.Text
                    Me.cmdFunc1.Text = "変更(F1)"

                    cbSYOKUCHI_FG.Text = "諸口"
                    Me.mtxTORI_CD.Enabled = False
                    Me.mtxTORI_NAME.Enabled = False
                    Me.lbllblEDIT_YMDHNS.Visible = True
                    Me.lblEDIT_YMDHNS.Visible = True
                    Me.lblEDIT_SYAIN_ID.Visible = True
                    Me.lbllblEDIT_SYAIN_ID.Visible = True

                Case Else
                    'UNDONE:エラーMsg
                    Return False
            End Select

            Return True

        Catch ex As Exception
            EM.ErrorSyori(ex, False, conblnNonMsg)
            Return False
        End Try
    End Function

    ''' <summary>
    ''' 一覧選択行の値をセット
    ''' </summary>
    ''' <param name="dgvCol"></param>
    ''' <returns></returns>
    Private Function FunSetEntityValues(dgvCol As DataGridViewCellCollection) As Boolean
        Try
            '-----コントロールに値をセット
            With dgvCol
                '取引先CD
                Me.mtxTORI_CD.Text = .Item("TORI_CD").Value
                '取引種別
                Me.cmbTORI_SYU.Text = .Item("TORI_SYU_DISP").Value.ToString.Trim
                '仕入外注区分
                Me.cmbSIIRE_GAICYU_KB.Text = .Item("SIIRE_GAICYU_KB_DISP").Value.ToString.Trim
                '諸口フラグ
                Me.cbSYOKUCHI_FG.Checked = CBool(.Item("SYOKUCHI_FLG").Value)
                '取引先名称
                Me.mtxTORI_NAME.Text = .Item("TORI_NAME").Value.ToString.Trim
                'フリガナ
                Me.mtxFURIGANA.Text = .Item("FURIGANA").Value.ToString.Trim
                '取引先略名
                Me.mtxTORI_R_NAME.Text = .Item("TORI_R_NAME").Value.ToString.Trim
                '取引先支店名
                Me.mtxTORI_SITEN_NAME.Text = .Item("TORI_SITEN_NAME").Value.ToString.Trim
                '取引先担当者名
                Me.mtxTORI_TANTO_NAME.Text = .Item("TORI_TANTO_NAME").Value.ToString.Trim
                '郵便番号
                Me.mtxYUBIN.Text = .Item("YUBIN").Value
                '住所1-3
                Me.mtxADDRESS1.Text = .Item("ADDRESS1").Value.ToString.Trim
                Me.mtxADDRESS2.Text = .Item("ADDRESS2").Value.ToString.Trim
                Me.mtxADDRESS3.Text = .Item("ADDRESS3").Value.ToString.Trim
                'TEL
                If .Item("TEL").Value.ToString.IsNullOrWhiteSpace = False Then
                    Me.mtxTEL1.Text = .Item("TEL").Value.ToString.Split("-")(0)
                    Me.mtxTEL2.Text = .Item("TEL").Value.ToString.Split("-")(1)
                    Me.mtxTEL3.Text = .Item("TEL").Value.ToString.Split("-")(2)
                End If
                'FAX
                If .Item("FAX").Value.ToString.IsNullOrWhiteSpace = False Then
                    Me.mtxFAX1.Text = .Item("FAX").Value.ToString.Split("-")(0)
                    Me.mtxFAX2.Text = .Item("FAX").Value.ToString.Split("-")(1)
                    Me.mtxFAX3.Text = .Item("FAX").Value.ToString.Split("-")(2)
                End If
                '社内担当者CD
                Me.cmbS_TANTOU_CD.Text = .Item("S_TANTO_NAME").Value.ToString.Trim
                '請求先CD
                Me.cmbSEIKYU_CD.Text = .Item("SEIKYU_TORI_NAME").Value.ToString.Trim
                '売税区分
                Me.cmbURIZEI_KB.Text = .Item("URIZEI_KB_DISP").Value
                '売税端数処理区分
                Me.cmbURI_TAX_HASU_KB.Text = .Item("URI_TAX_HASU_KB_DISP").Value
                '仕税区分
                Me.cmbSIZEI_KB.Text = .Item("SIZEI_KB_DISP").Value
                '仕税端数処理区分
                Me.cmbSIIRE_TAX_HASU_KB.Text = .Item("SIIRE_TAX_HASU_KB_DISP").Value
                'リードタイム
                Me.mtxLEAD_TIME.Text = .Item("LEAD_TIME").Value.ToString.Trim
                '締日
                Me.mtxSIME_DAY.Text = .Item("SIME_DAY").Value
                '支払日
                Me.mtxSIHARAI_DAY.Text = .Item("SIHARAI_DAY").Value
                '------メモ
                Me.mtxMEMO.Text = .Item("MEMO").Value
                '取引先符号
                Me.mtxTORI_FUGO.Text = .Item("TORI_FUGO").Value
                '更新日時
                Dim dt As DateTime
                dt = DateTime.ParseExact(.Item("EDIT_YMDHNS").Value.ToString, "yyyyMMddHHmmss", Nothing)
                Me.lblEDIT_YMDHNS.Text = dt.ToString("yyyy/MM/dd HH:mm:ss")
                '更新担当者コード
                Me.lblEDIT_SYAIN_ID.Text = .Item("EDIT_TANTO_CD").Value.ToString.Trim & " " & Fun_GetUSER_NAME(.Item("EDIT_TANTO_CD").Value.ToString.Trim)

            End With

            Return True
        Catch ex As Exception
            Throw
            Return False
        End Try
    End Function

#End Region

#End Region

#Region "テキストボックスが空欄の場合、0を入力する"
    'リードタイム
    Private Sub MtxLEAD_TIME_Validated(sender As Object, e As EventArgs) Handles mtxLEAD_TIME.Validated
        If mtxLEAD_TIME.Text.IsNullOrWhiteSpace = True Then
            Me.mtxLEAD_TIME.Text = 0
        Else
        End If
    End Sub
    '締日
    Private Sub MtxSIME_DAY_Validated(sender As Object, e As EventArgs) Handles mtxSIME_DAY.Validated
        Select Case Val(mtxSIME_DAY.Text)
            Case 1 To 31
            Case Else
                mtxSIME_DAY.Text = 0
        End Select
    End Sub
    '支払日
    Private Sub MtxSIHARAI_DAY_Validated(sender As Object, e As EventArgs) Handles mtxSIHARAI_DAY.Validated
        Select Case Val(mtxSIME_DAY.Text)
            Case 1 To 31
            Case Else
                mtxSIME_DAY.Text = 0
        End Select
    End Sub
    '取引種別
    Private Sub CmbTORI_SYU_Validating(sender As Object, e As System.ComponentModel.CancelEventArgs) Handles cmbTORI_SYU.Validating
        Dim cmb As ComboboxEx = DirectCast(sender, ComboboxEx)

        If cmb.IsSelected Then
            ErrorProvider.ClearError(cmb)
            pri_blnValidated = (pri_blnValidated AndAlso True)
        Else
            ErrorProvider.SetError(cmb, String.Format(My.Resources.infoMsgRequireSelectOrInput, "取引種別"), ErrorIconAlignment.MiddleLeft)
            pri_blnValidated = False
        End If
    End Sub
    '仕入外注区分
    Private Sub CmbSIIRE_GAICYU_KB_Validating(sender As Object, e As System.ComponentModel.CancelEventArgs) Handles cmbSIIRE_GAICYU_KB.Validating
        Dim cmb As ComboboxEx = DirectCast(sender, ComboboxEx)

        If cmb.IsSelected Then
            ErrorProvider.ClearError(cmb)
            pri_blnValidated = (pri_blnValidated AndAlso True)
        Else
            ErrorProvider.SetError(cmb, String.Format(My.Resources.infoMsgRequireSelectOrInput, "仕入外注区分"), ErrorIconAlignment.MiddleLeft)
            pri_blnValidated = False
        End If
    End Sub
    '取引先名
    Private Sub MtxTORI_NAME_Validating(sender As Object, e As System.ComponentModel.CancelEventArgs) Handles mtxTORI_NAME.Validating
        Dim mtx As MaskedTextBoxEx = DirectCast(sender, MaskedTextBoxEx)

        If mtx.Text.IsNullOrWhiteSpace = False Then
            ErrorProvider.ClearError(mtx)
            pri_blnValidated = (pri_blnValidated AndAlso True)
        Else
            ErrorProvider.SetError(mtx, String.Format(My.Resources.infoMsgRequireSelectOrInput, "取引先名"), ErrorIconAlignment.MiddleLeft)
            pri_blnValidated = False
        End If
    End Sub
    '請求先
    Private Sub CmbSEIKYU_CD_Validating(sender As Object, e As System.ComponentModel.CancelEventArgs) Handles cmbSEIKYU_CD.Validating
        Dim cmb As ComboboxEx = DirectCast(sender, ComboboxEx)

        If cmb.IsSelected Then
            ErrorProvider.ClearError(cmb)
            pri_blnValidated = (pri_blnValidated AndAlso True)
        Else
            ErrorProvider.SetError(cmb, String.Format(My.Resources.infoMsgRequireSelectOrInput, "請求先"), ErrorIconAlignment.MiddleLeft)
            pri_blnValidated = False
        End If
    End Sub
    '売税区分
    Private Sub CmbURIZEI_KB_Validating(sender As Object, e As System.ComponentModel.CancelEventArgs) Handles cmbURIZEI_KB.Validating
        Dim cmb As ComboboxEx = DirectCast(sender, ComboboxEx)

        If cmb.IsSelected Then
            ErrorProvider.ClearError(cmb)
            pri_blnValidated = (pri_blnValidated AndAlso True)
        Else
            ErrorProvider.SetError(cmb, String.Format(My.Resources.infoMsgRequireSelectOrInput, "売税区分"), ErrorIconAlignment.MiddleLeft)
            pri_blnValidated = False
        End If
    End Sub
    '仕税区分
    Private Sub CmbSIZEI_KB_Validating(sender As Object, e As System.ComponentModel.CancelEventArgs) Handles cmbSIZEI_KB.Validating
        Dim cmb As ComboboxEx = DirectCast(sender, ComboboxEx)

        If cmb.IsSelected Then
            ErrorProvider.ClearError(cmb)
            pri_blnValidated = (pri_blnValidated AndAlso True)
        Else
            ErrorProvider.SetError(cmb, String.Format(My.Resources.infoMsgRequireSelectOrInput, "仕税区分"), ErrorIconAlignment.MiddleLeft)
            pri_blnValidated = False
        End If
    End Sub
    '売税端数処理区分
    Private Sub CmbURI_TAX_HASU_KB_Validating(sender As Object, e As System.ComponentModel.CancelEventArgs) Handles cmbURI_TAX_HASU_KB.Validating
        Dim cmb As ComboboxEx = DirectCast(sender, ComboboxEx)

        If cmb.IsSelected Then
            ErrorProvider.ClearError(cmb)
            pri_blnValidated = (pri_blnValidated AndAlso True)
        Else
            ErrorProvider.SetError(cmb, String.Format(My.Resources.infoMsgRequireSelectOrInput, "売税端数処理区分"), ErrorIconAlignment.MiddleLeft)
            pri_blnValidated = False
        End If
    End Sub
    '仕税端数処理区分
    Private Sub CmbSIIRE_TAX_HASU_KB_Validating(sender As Object, e As System.ComponentModel.CancelEventArgs) Handles cmbSIIRE_TAX_HASU_KB.Validating
        Dim cmb As ComboboxEx = DirectCast(sender, ComboboxEx)

        If cmb.IsSelected Then
            ErrorProvider.ClearError(cmb)
            pri_blnValidated = (pri_blnValidated AndAlso True)
        Else
            ErrorProvider.SetError(cmb, String.Format(My.Resources.infoMsgRequireSelectOrInput, "仕税端数処理区分"), ErrorIconAlignment.MiddleLeft)
            pri_blnValidated = False
        End If
    End Sub
    '社内担当者名
    Private Sub CmbS_TANTOU_CD_Validating(sender As Object, e As System.ComponentModel.CancelEventArgs) Handles cmbS_TANTOU_CD.Validating
        Dim cmb As ComboboxEx = DirectCast(sender, ComboboxEx)

        If cmb.IsSelected Then
            ErrorProvider.ClearError(cmb)
            pri_blnValidated = (pri_blnValidated AndAlso True)
        Else
            ErrorProvider.SetError(cmb, String.Format(My.Resources.infoMsgRequireSelectOrInput, "社内担当者名"), ErrorIconAlignment.MiddleLeft)
            pri_blnValidated = False
        End If
    End Sub

#End Region

End Class
