Imports JMS_COMMON.ClsPubMethod

Public Class FrmM0041

#Region "変数・定数"
    Private IsValidated As Boolean
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

    Public Property PrDataRow As C1.Win.C1FlexGrid.Row

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
            Me.Height = 430
            Me.Top = Me.Owner.Top + (Me.Owner.Height - Me.Height) - 26 ' / 2
            Me.Left = Me.Owner.Left + (Me.Owner.Width - Me.Width) / 2

            '-----コントロールデータソース設定
            Me.cmbSYAIN_KB.SetDataSource(tblSYAIN_KB.ExcludeDeleted, ENM_COMBO_SELECT_VALUE_TYPE._0_Required)
            Me.cmbYAKUSYOKU_KB.SetDataSource(tblYAKUSYOKU_KB.ExcludeDeleted, True)
            Me.cmbDAIKO.SetDataSource(tblDAIKO_KB.ExcludeDeleted, True)

            '-----処理モード別画面初期化
            Call FunInitializeControls(PrMODE)

            '-----ダイアログウィンドウ設定
            Me.FormBorderStyle = Windows.Forms.FormBorderStyle.FixedDialog
            Me.ControlBox = False

            Dim blnSysAdmin As Boolean = IsSysAdminUser(pub_SYAIN_INFO.SYAIN_ID)
            chkADMIN_SYS.Enabled = blnSysAdmin
            chkADMIN_OP.Enabled = blnSysAdmin


        Catch ex As Exception
            EM.ErrorSyori(ex, False, conblnNonMsg)

        End Try
    End Sub

#End Region
#Region "処理モード別画面初期化"
    Private Function FunInitializeControls(ByVal intMODE As Integer) As Boolean

        Try

            Select Case intMODE
                Case ENM_DATA_OPERATION_MODE._1_ADD
                    lblTytle.Text &= "（追加）"
                    Me.cmdFunc1.Text = "追加(F1)"
                    Me.mtxSIMEI.Enabled = True
                    Me.mtxSYAIN_NO.Enabled = True
                    Me.lbllblEDIT_YMDHNS.Visible = False
                    Me.lblEDIT_YMDHNS.Visible = False

                Case ENM_DATA_OPERATION_MODE._2_ADDREF

                    Call FunSetEntityValues(PrDataRow)

                    lblTytle.Text &= "（類似追加）"
                    Me.cmdFunc1.Text = "追加(F1)"
                    Me.mtxSYAIN_ID.Text = ""
                    Me.mtxSYAIN_NO.Text = ""
                    Me.lbllblEDIT_YMDHNS.Visible = False
                    Me.lblEDIT_YMDHNS.Visible = False

                Case ENM_DATA_OPERATION_MODE._3_UPDATE

                    Call FunSetEntityValues(PrDataRow)

                    lblTytle.Text &= "（変更）"
                    Me.cmdFunc1.Text = "変更(F1)"

                    Me.mtxSYAIN_ID.Enabled = False
                    Me.mtxSYAIN_NO.Enabled = False
                    Me.mtxSIMEI.Enabled = True

                    Me.lbllblEDIT_YMDHNS.Visible = True
                    Me.lblEDIT_YMDHNS.Visible = True

                Case Else
                    Throw New ArgumentException(My.Resources.ErrMsgException, intMODE.ToString)
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
    Private Function FunSetEntityValues(row As C1.Win.C1FlexGrid.Row) As Boolean
        Dim _model As New MODEL.VWM004_SYAIN
        Try
            '-----コントロールに値をセット
            With row

                '社員ID
                Me.mtxSYAIN_ID.Text = .Item(NameOf(_model.SYAIN_ID)) '.Item("SYAIN_ID").Value.ToString.Trim
                '社員NO（職番）
                Me.mtxSYAIN_NO.Text = .Item(NameOf(_model.SYAIN_NO))
                '担当者名
                Me.mtxSIMEI.Text = .Item(NameOf(_model.SIMEI))
                '担当者名カナ
                Me.mtxSIMEI_KANA.Text = .Item(NameOf(_model.SIMEI_KANA))
                '入社日
                Me.dtbNYUSYA_YMD.Text = .Item(NameOf(_model.NYUSYA_YMD))
                '退社日
                Me.dtbTAISYA_YMD.Text = .Item(NameOf(_model.TAISYA_YMD))
                '役職区分
                Me.cmbYAKUSYOKU_KB.SelectedValue = .Item(NameOf(_model.YAKUSYOKU_KB))
                '生年月日
                Me.dtbBIRTHDAY.Text = .Item(NameOf(_model.BIRTH_YMD))
                'パスワード
                Me.mtxPASS.Text = .Item(NameOf(_model.PASS))
                '社員区分
                Me.cmbSYAIN_KB.SelectedValue = .Item(NameOf(_model.SYAIN_KB))
                '役職区分
                Me.cmbYAKUSYOKU_KB.SelectedValue = .Item(NameOf(_model.YAKUSYOKU_KB))
                '代行区分
                Me.cmbDAIKO.SelectedValue = .Item(NameOf(_model.DAIKO_KB))
                'メールアドレス
                Me.mtxMAIL_ADD.Text = .Item(NameOf(_model.MAIL_ADDRESS))
                'TEL
                Me.mtxTEL.Text = .Item(NameOf(_model.TEL))

                '運用権限
                chkADMIN_OP.Checked = .Item(NameOf(_model.ADMIN_OP)) = "1"
                'システム権限
                chkADMIN_SYS.Checked = .Item(NameOf(_model.ADMIN_SYS)) = "1"

                '更新日時
                If Not row.Item(NameOf(_model.UPD_YMDHNS)).ToString.IsNulOrWS Then
                    Dim dt As DateTime
                    dt = DateTime.ParseExact(.Item(NameOf(_model.UPD_YMDHNS)).ToString, "yyyy/MM/dd HH:mm:ss", Nothing)
                    Me.lblEDIT_YMDHNS.Text = dt.ToString("yyyy/MM/dd HH:mm:ss")
                End If


                '更新担当
                Me.lblEDIT_SYAIN_ID.Text = .Item(NameOf(_model.UPD_SYAIN_NAME)).ToString

            End With
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
                    Select Case PrMODE
                        Case ENM_DATA_OPERATION_MODE._1_ADD, ENM_DATA_OPERATION_MODE._2_ADDREF
                            blnRET = FunINS()
                        Case ENM_DATA_OPERATION_MODE._3_UPDATE
                            blnRET = FunUPD()
                        Case Else
                            Throw New ArgumentException(My.Resources.ErrMsgException, PrMODE.ToString)
                    End Select

                    If blnRET = True Then
                        'プロパティに対象レコードのキーを設定
                        'Me.PrPKeys = Me.mtxTANTO_CD.Text.Trim
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

#Region "追加"
    Private Function FunINS() As Boolean

        Dim dsList As New System.Data.DataSet
        Dim sbSQL As New System.Text.StringBuilder
        Try
            '-----入力チェック
            If FunCheckInput() = False Then
                Return False
            End If

            Using DB As ClsDbUtility = DBOpen()
                Dim intRET As Integer
                Dim sqlEx As New Exception
                Dim blnErr As Boolean
                Try
                    'トランザクション
                    DB.BeginTransaction()
                    '-----存在チェック
                    sbSQL.Remove(0, sbSQL.Length)
                    sbSQL.Append("SELECT * FROM M004_SYAIN ")
                    sbSQL.Append(" WHERE SYAIN_NO ='" & Me.mtxSYAIN_NO.Text.Trim & "'")
                    sbSQL.Append(" AND TAISYA_YMD <> ' '")

                    dsList = DB.GetDataSet(sbSQL.ToString, conblnNonMsg)
                    If dsList.Tables(0).Rows.Count > 0 Then '存在時
                        If MessageBox.Show(String.Format(My.Resources.infoTilteDuplicateData, "未退職の職番"), My.Resources.infoTilteDuplicateCheck, MessageBoxButtons.OKCancel, MessageBoxIcon.Exclamation) <> DialogResult.OK Then
                            Return False
                        End If
                    End If

                    ''Dim intNewTANTO_CD As Integer = FunGetNextTANTO_CD()
                    ''Me.mtxTANTO_CD.Text = intNewTANTO_CD

                    '-----INSERT
                    sbSQL.Remove(0, sbSQL.Length)
                    sbSQL.Append("INSERT INTO M004_SYAIN(")
                    sbSQL.Append("  SYAIN_ID ")
                    sbSQL.Append(" ,SYAIN_NO ")
                    sbSQL.Append(" ,SIMEI")
                    sbSQL.Append(" ,SIMEI_KANA")
                    sbSQL.Append(" ,SYAIN_KB")
                    sbSQL.Append(" ,YAKUSYOKU_KB")
                    sbSQL.Append(" ,DAIKO_KB")
                    sbSQL.Append(" ,BIRTH_YMD")
                    sbSQL.Append(" ,TEL")
                    sbSQL.Append(" ,MAIL_ADDRESS")
                    sbSQL.Append(" ,NYUSYA_YMD")
                    sbSQL.Append(" ,TAISYA_YMD")
                    sbSQL.Append(" ,PASS")
                    sbSQL.Append(" ,ADMIN_OP")
                    sbSQL.Append(" ,ADMIN_SYS")
                    sbSQL.Append(" ,ADD_YMDHNS")
                    sbSQL.Append(" ,ADD_SYAIN_ID")
                    sbSQL.Append(" ,UPD_YMDHNS")
                    sbSQL.Append(" ,UPD_SYAIN_ID")
                    sbSQL.Append(" ,DEL_YMDHNS")
                    sbSQL.Append(" ,DEL_SYAIN_ID")
                    sbSQL.Append(" ) VALUES ( ")
                    '社員ID
                    sbSQL.Append(" (SELECT MAX(SYAIN_ID)+1 FROM M004_SYAIN WHERE SYAIN_ID<999999)")
                    '社員NO
                    sbSQL.Append(" ,'" & Me.mtxSYAIN_NO.Text.Trim & "'")
                    '氏名
                    sbSQL.Append(" ,'" & Me.mtxSIMEI.Text.Trim & "'")
                    '氏名カナ
                    sbSQL.Append(" ,'" & Me.mtxSIMEI_KANA.Text.Trim & "'")
                    '社員区分
                    sbSQL.Append(" ,'" & Me.cmbSYAIN_KB.SelectedValue & "'")
                    '役職区分
                    sbSQL.Append(" ,'" & Me.cmbYAKUSYOKU_KB.SelectedValue & "'")
                    '承認代行区分
                    sbSQL.Append(" ,'" & Me.cmbDAIKO.SelectedValue & "'")
                    '生年月日
                    sbSQL.Append(" ,'" & Me.dtbBIRTHDAY.ValueNonFormat & "'")
                    'TEL
                    sbSQL.Append(" ,'" & Me.mtxTEL.Text.Trim & "'")
                    'メールアドレス
                    sbSQL.Append(" ,'" & Me.mtxMAIL_ADD.Text.Trim & "'")
                    '入社年月日
                    sbSQL.Append(" ,'" & Me.dtbNYUSYA_YMD.ValueNonFormat & "'")
                    '退社年月日
                    sbSQL.Append(" ,'" & Me.dtbTAISYA_YMD.ValueNonFormat & "'")
                    'パスワード
                    sbSQL.Append(" ,'" & Me.mtxPASS.Text.Trim & "'")
                    '運用権限
                    sbSQL.Append(" ,'" & If(chkADMIN_OP.Checked, "1", "0") & "'")
                    'システム権限
                    sbSQL.Append(" ,'" & If(chkADMIN_SYS.Checked, "1", "0") & "'")
                    '追加日時
                    sbSQL.Append(" ,dbo.GetSysDateString()")
                    '追加担当者
                    sbSQL.Append(" ," & pub_SYAIN_INFO.SYAIN_ID & "")
                    '更新日時
                    sbSQL.Append(" ,dbo.GetSysDateString()")
                    '更新担当者
                    sbSQL.Append(" ," & pub_SYAIN_INFO.SYAIN_ID & "")
                    '削除日時
                    sbSQL.Append(" ,''")
                    '削除担当者
                    sbSQL.Append(" ,0")
                    sbSQL.Append(" )")

                    intRET = DB.ExecuteNonQuery(sbSQL.ToString, conblnNonMsg, sqlEx)
                    If intRET <> 1 Then
                        'エラーログ出力
                        Dim strErrMsg As String = My.Resources.ErrLogSqlExecutionFailure & sbSQL.ToString & "|" & sqlEx.Message
                        WL.WriteLogDat(strErrMsg)
                        blnErr = True
                        Return False
                    End If
                Finally
                    'トランザクション
                    DB.Commit(Not blnErr)
                End Try
            End Using

            Return True
        Catch ex As Exception
            Throw
            Return False
        Finally
            dsList.Dispose()
        End Try
    End Function
#End Region

#Region "更新"
    Private Function FunUPD() As Boolean

        Dim sbSQL As New System.Text.StringBuilder
        Dim dsList As New DataSet
        Dim intRET As Integer
        Dim sqlEx As Exception = Nothing
        Dim blnErr As Boolean
        Try
            '入力チェック
            If FunCheckInput() = False Then
                Return False
            End If

            Using DB As ClsDbUtility = DBOpen()
                Try
                    'トランザクション
                    DB.BeginTransaction()
                    '-----存在チェック
                    sbSQL.Append("SELECT * FROM M004_SYAIN ")
                    sbSQL.Append(" WHERE")
                    sbSQL.Append(" SYAIN_ID =" & Nz(Me.mtxSYAIN_ID.Text.Trim & ""))

                    dsList = DB.GetDataSet(sbSQL.ToString)
                    If dsList.Tables(0).Rows.Count = 0 Then '非存在時
                        MessageBox.Show(String.Format(My.Resources.infoSearchDataChange), My.Resources.infoTilteDuplicateCheck, MessageBoxButtons.OK, MessageBoxIcon.Information)
                        Return False
                    End If

                    '-----UPDATE
                    sbSQL.Remove(0, sbSQL.Length)
                    sbSQL.Append("UPDATE M004_SYAIN SET")
                    sbSQL.Append("  SIMEI        ='" & Me.mtxSIMEI.Text.Trim & "'")
                    sbSQL.Append(" ,SIMEI_KANA   ='" & Me.mtxSIMEI_KANA.Text.Trim & "'")
                    sbSQL.Append(" ,SYAIN_KB     ='" & Me.cmbSYAIN_KB.SelectedValue & "'")
                    sbSQL.Append(" ,YAKUSYOKU_KB ='" & Me.cmbYAKUSYOKU_KB.SelectedValue & "'")
                    sbSQL.Append(" ,DAIKO_KB     ='" & Me.cmbDAIKO.SelectedValue & "'")
                    sbSQL.Append(" ,BIRTH_YMD    ='" & Me.dtbBIRTHDAY.ValueNonFormat & "'")
                    sbSQL.Append(" ,TEL          ='" & Me.mtxTEL.Text.Trim & "'")
                    sbSQL.Append(" ,MAIL_ADDRESS ='" & Me.mtxMAIL_ADD.Text.Trim & "'")
                    sbSQL.Append(" ,NYUSYA_YMD   ='" & Me.dtbNYUSYA_YMD.ValueNonFormat & "'")
                    sbSQL.Append(" ,TAISYA_YMD   ='" & Me.dtbTAISYA_YMD.ValueNonFormat & "'")
                    sbSQL.Append(" ,PASS         ='" & Me.mtxPASS.Text.Trim & "'")
                    sbSQL.Append(" ,ADMIN_OP     ='" & If(chkADMIN_OP.Checked, "1", "0") & "'")
                    sbSQL.Append(" ,ADMIN_SYS    ='" & If(chkADMIN_SYS.Checked, "1", "0") & "'")
                    sbSQL.Append(" ,UPD_YMDHNS   = dbo.GetSysDateString() ")
                    sbSQL.Append(" ,UPD_SYAIN_ID = " & pub_SYAIN_INFO.SYAIN_ID & " ")
                    sbSQL.Append(" WHERE")
                    sbSQL.Append(" SYAIN_ID =" & Nz(Me.mtxSYAIN_ID.Text.Trim, " "))

                    intRET = DB.ExecuteNonQuery(sbSQL.ToString, conblnNonMsg, sqlEx)
                    If intRET <> 1 Then
                        'エラーログ
                        Dim strErrMsg As String = My.Resources.ErrLogSqlExecutionFailure & sbSQL.ToString & "|" & sqlEx.Message
                        WL.WriteLogDat(strErrMsg)
                        blnErr = True
                        Return False
                    End If

                Finally
                    'トランザクション
                    DB.Commit(Not blnErr)
                End Try
            End Using

            Return True
        Catch ex As Exception
            Throw
            Return False
        Finally
            dsList.Dispose()
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
                    If cmd IsNot Nothing AndAlso .Text.Length = 0 OrElse .Text.Substring(0, .Text.IndexOf("(")).IsNulOrWS Then
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

#End Region

#Region "入力チェック"
    Public Function FunCheckInput() As Boolean

        Try
            IsValidated = True

            '職番
            Call mtxSYAIN_NO_Validating(mtxSYAIN_NO, Nothing)

            '社員区分
            Call cmbSYAIN_KB_Validating(cmbSYAIN_KB, Nothing)

            '担当者名
            Call mtxSIMEI_Validating(mtxSIMEI, Nothing)

            '担当者名カナ
            Call mtxSIMEI_KANA_Validating(mtxSIMEI_KANA, Nothing)

            'パスワード
            Call mtxPASS_Validating(mtxPASS, Nothing)


            Return IsValidated
        Catch ex As Exception
            EM.ErrorSyori(ex, False, conblnNonMsg)
            Return False
        End Try
    End Function

    Private Sub mtxSYAIN_NO_Validating(sender As Object, e As System.ComponentModel.CancelEventArgs) Handles mtxSYAIN_NO.Validating
        Dim mtx As MaskedTextBoxEx = DirectCast(sender, MaskedTextBoxEx)
        IsValidated *= ErrorProvider.UpdateErrorInfo(mtx, Not mtx.Text.IsNulOrWS, String.Format(My.Resources.infoMsgRequireSelectOrInput, "職番"))
    End Sub

    Private Sub cmbSYAIN_KB_Validating(sender As Object, e As System.ComponentModel.CancelEventArgs) Handles cmbSYAIN_KB.Validating
        Dim cmb As ComboboxEx = DirectCast(sender, ComboboxEx)
        IsValidated *= ErrorProvider.UpdateErrorInfo(cmb, cmb.IsSelected, String.Format(My.Resources.infoMsgRequireSelectOrInput, "社員区分"))
    End Sub

    Private Sub mtxSIMEI_Validating(sender As Object, e As System.ComponentModel.CancelEventArgs) Handles mtxSIMEI.Validating
        Dim mtx As MaskedTextBoxEx = DirectCast(sender, MaskedTextBoxEx)
        IsValidated *= ErrorProvider.UpdateErrorInfo(mtx, Not mtx.Text.IsNulOrWS, String.Format(My.Resources.infoMsgRequireSelectOrInput, "氏名"))
    End Sub

    Private Sub mtxSIMEI_KANA_Validating(sender As Object, e As System.ComponentModel.CancelEventArgs) Handles mtxSIMEI_KANA.Validating
        Dim mtx As MaskedTextBoxEx = DirectCast(sender, MaskedTextBoxEx)
        IsValidated *= ErrorProvider.UpdateErrorInfo(mtx, Not mtx.Text.IsNulOrWS, String.Format(My.Resources.infoMsgRequireSelectOrInput, "氏名カナ"))
    End Sub

    Private Sub mtxPASS_Validating(sender As Object, e As System.ComponentModel.CancelEventArgs) Handles mtxPASS.Validating
        Dim mtx As MaskedTextBoxEx = DirectCast(sender, MaskedTextBoxEx)
        IsValidated *= ErrorProvider.UpdateErrorInfo(mtx, Not mtx.Text.IsNulOrWS, String.Format(My.Resources.infoMsgRequireSelectOrInput, "パスワード"))
    End Sub

    Private Sub chkADMIN_SYS_CheckedChanged(sender As Object, e As EventArgs) Handles chkADMIN_SYS.CheckedChanged
        If chkADMIN_SYS.Checked Then chkADMIN_OP.Checked = True

    End Sub

#Region "ローカル関数"




#End Region

#End Region

End Class
