Imports JMS_COMMON.ClsPubMethod

Public Class FrmM0041

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

#Region "コンストラクタ"

    ''' <summary>
    ''' コンストラクタ
    ''' </summary>
    ''' <remarks>コンストラクタ</remarks>
    Public Sub New()

        ' この呼び出しはデザイナーで必要です。
        InitializeComponent()

        CmbAuth1.NullValue = 0
        CmbAuth2.NullValue = 0
        CmbAuth3.NullValue = 0
        CmbAuth4.NullValue = 0

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
            Me.Height = 530
            Me.Top = Me.Owner.Top + (Me.Owner.Height - Me.Height) - 26 ' / 2
            Me.Left = Me.Owner.Left + (Me.Owner.Width - Me.Width) / 2

            '-----コントロールデータソース設定
            Me.cmbSYAIN_KB.SetDataSource(tblSYAIN_KB.ExcludeDeleted, ENM_COMBO_SELECT_VALUE_TYPE._0_Required)
            Me.cmbYAKUSYOKU_KB.SetDataSource(tblYAKUSYOKU_KB.ExcludeDeleted, True)
            Me.cmbDAIKO.SetDataSource(tblDAIKO_KB.ExcludeDeleted, True)

            Me.CmbAuth1.SetDataSource(tblKENGEN, False)
            Me.CmbAuth2.SetDataSource(tblKENGEN2, False)
            Me.CmbAuth3.SetDataSource(tblKENGEN3, False)
            Me.CmbAuth4.SetDataSource(tblKENGEN4, False)

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

                '
                'chkADMIN_AUTH.Checked = .Item(NameOf(_model.ADMIN_AUTH)) = "1"
                ''
                'chkMAILSEND_AUTH.Checked = .Item(NameOf(_model.MAILSEND_AUTH)) = "1"

                Me.mtxCARD_ID.Text = .Item(NameOf(_model.IC_CARD_ID))

                Me.CmbAuth1.SelectedValue = .Item(NameOf(_model.AUTH1)).ToString.ToVal
                Me.CmbAuth2.SelectedValue = .Item(NameOf(_model.AUTH2)).ToString.ToVal
                Me.CmbAuth3.SelectedValue = .Item(NameOf(_model.AUTH3)).ToString.ToVal
                Me.CmbAuth4.SelectedValue = .Item(NameOf(_model.AUTH4)).ToString.ToVal

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
                    sbSQL.Append(" ,IC_CARD_ID")
                    sbSQL.Append(" ,AUTH1")
                    sbSQL.Append(" ,AUTH2")
                    sbSQL.Append(" ,AUTH3")
                    sbSQL.Append(" ,AUTH4")
                    sbSQL.Append(" ,ADD_YMDHNS")
                    sbSQL.Append(" ,ADD_SYAIN_ID")
                    sbSQL.Append(" ,UPD_YMDHNS")
                    sbSQL.Append(" ,UPD_SYAIN_ID")
                    sbSQL.Append(" ,DEL_YMDHNS")
                    sbSQL.Append(" ,DEL_SYAIN_ID")
                    sbSQL.Append(" ) VALUES ( ")
                    '社員ID
                    sbSQL.Append(" (SELECT MAX(SYAIN_ID)+1 FROM M004_SYAIN WHERE SYAIN_ID <= 999990)")
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

                    'IC_CARD_ID
                    sbSQL.Append(" ,'" & Me.mtxCARD_ID.Text.Trim & "'")
                    '権限1
                    sbSQL.Append(" ," & 0 & "")
                    '権限2
                    sbSQL.Append(" ," & 0 & "")
                    '権限3
                    sbSQL.Append(" ," & 0 & "")
                    '権限4
                    sbSQL.Append(" ," & 0 & "")

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

            Using DB = DBOpen()
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

                    sbSQL.Append(" ,IC_CARD_ID   ='" & Me.mtxCARD_ID.Text.Trim & "'")
                    sbSQL.Append(" ,AUTH1   =" & Me.CmbAuth1.SelectedValue & "")
                    sbSQL.Append(" ,AUTH2   =" & Me.CmbAuth2.SelectedValue & "")
                    sbSQL.Append(" ,AUTH3   =" & Me.CmbAuth3.SelectedValue & "")
                    sbSQL.Append(" ,AUTH4   =" & Me.CmbAuth4.SelectedValue & "")

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

                    '管理者権限 登録最大値取得

                    '管理者権限 登録

                    'メール再送信権限 登録最大値取得

                    'メール再送信権限 登録
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

#Region "入力チェック"

    Public Function FunCheckInput() As Boolean

        Try
            IsValidated = True
            IsCheckRequired = True

            '職番
            Call MtxSYAIN_NO_Validating(mtxSYAIN_NO, Nothing)

            '社員区分
            Call CmbSYAIN_KB_Validating(cmbSYAIN_KB, Nothing)

            '担当者名
            Call MtxSIMEI_Validating(mtxSIMEI, Nothing)

            '担当者名カナ
            Call MtxSIMEI_KANA_Validating(mtxSIMEI_KANA, Nothing)

            'パスワード
            Call MtxPASS_Validating(mtxPASS, Nothing)

            Return IsValidated
        Catch ex As Exception
            Throw
        Finally
            IsCheckRequired = False
        End Try
    End Function

    Private Sub MtxSYAIN_NO_Validating(sender As Object, e As System.ComponentModel.CancelEventArgs) Handles mtxSYAIN_NO.Validating
        Dim mtx As MaskedTextBoxEx = DirectCast(sender, MaskedTextBoxEx)
        If IsCheckRequired Then
            IsValidated *= ErrorProvider.UpdateErrorInfo(mtx, Not mtx.Text.IsNulOrWS, String.Format(My.Resources.infoMsgRequireSelectOrInput, "職番"))
        End If
    End Sub

    Private Sub CmbSYAIN_KB_Validating(sender As Object, e As System.ComponentModel.CancelEventArgs) Handles cmbSYAIN_KB.Validating
        Dim cmb As ComboboxEx = DirectCast(sender, ComboboxEx)
        If IsCheckRequired Then
            IsValidated *= ErrorProvider.UpdateErrorInfo(cmb, cmb.IsSelected, String.Format(My.Resources.infoMsgRequireSelectOrInput, "社員区分"))
        End If
    End Sub

    Private Sub MtxSIMEI_Validating(sender As Object, e As System.ComponentModel.CancelEventArgs) Handles mtxSIMEI.Validating
        Dim mtx As MaskedTextBoxEx = DirectCast(sender, MaskedTextBoxEx)
        If IsCheckRequired Then
            IsValidated *= ErrorProvider.UpdateErrorInfo(mtx, Not mtx.Text.IsNulOrWS, String.Format(My.Resources.infoMsgRequireSelectOrInput, "氏名"))
        End If
    End Sub

    Private Sub MtxSIMEI_KANA_Validating(sender As Object, e As System.ComponentModel.CancelEventArgs) Handles mtxSIMEI_KANA.Validating
        Dim mtx As MaskedTextBoxEx = DirectCast(sender, MaskedTextBoxEx)
        If IsCheckRequired Then
            IsValidated *= ErrorProvider.UpdateErrorInfo(mtx, Not mtx.Text.IsNulOrWS, String.Format(My.Resources.infoMsgRequireSelectOrInput, "氏名カナ"))
        End If
    End Sub

    Private Sub MtxPASS_Validating(sender As Object, e As System.ComponentModel.CancelEventArgs) Handles mtxPASS.Validating
        Dim mtx As MaskedTextBoxEx = DirectCast(sender, MaskedTextBoxEx)
        If IsCheckRequired Then
            IsValidated *= ErrorProvider.UpdateErrorInfo(mtx, Not mtx.Text.IsNulOrWS, String.Format(My.Resources.infoMsgRequireSelectOrInput, "パスワード"))
        End If
    End Sub

    Private Sub ChkADMIN_SYS_CheckedChanged(sender As Object, e As EventArgs) Handles chkADMIN_SYS.CheckedChanged
        If chkADMIN_SYS.Checked Then chkADMIN_OP.Checked = True
    End Sub

#End Region

    Private Sub btnReadCard_Click(sender As Object, e As EventArgs) Handles btnReadCard.Click
        Dim strCARD_ID As String
        Dim dr As DataRow

        Try
            'サウンド再生
            'Call PlaySound(pub_buttonSound)

            'カードID読取
            strCARD_ID = FunGET_ID(blnErrDisp:=False)

            If strCARD_ID = "" Then
                MessageBox.Show("カードIDが取得できませんでした。")
                Me.mtxCARD_ID.Text = ""
                Exit Sub
            End If

            'カード重複チェック
            Dim syainNo = GetUserNo(strCARD_ID)
            If Not syainNo.IsNulOrWS Then
                '既に同じカードが登録済みの場合
                MessageBox.Show("このカードは既に別のユーザーが使用しています", "登録済みカード", MessageBoxButtons.OK)
                Me.mtxCARD_ID.Text = ""
            Else
                'カードIDを記録
                Me.mtxCARD_ID.Text = strCARD_ID
                'Me.mtxCARD_ID.Tag = strCARD_ID
            End If
            'dr = FunGetUSER(strCARD_ID)
            'If dr IsNot Nothing Then
            '    '既に同じカードが登録済みの場合
            '    MessageBox.Show("このカードは既に別のユーザーが使用しています。" & vbCrLf & "別のカードを使用して下さい。", "登録済みカード", MessageBoxButtons.OK)
            '    Me.mtxCARD_ID.Text = ""
            'Else
            '    'カードIDを記録
            '    Me.mtxCARD_ID.Text = strCARD_ID
            'End If
        Catch ex As Exception
            EM.ErrorSyori(ex)
        End Try
    End Sub

    Private Function MaskCardNo(CARD_ID As String) As String
        Dim result As String
        If CARD_ID.IsNulOrWS Then
            Return ""
        Else
            result = Strings.Right(Strings.StrDup(CARD_ID.Length, "*") & Strings.Right(CARD_ID, 5), CARD_ID.Length)
        End If

        Return result
    End Function

    Private Sub btnCLEAR_Click(sender As Object, e As EventArgs) Handles btnCLEAR.Click
        Me.mtxCARD_ID.Text = ""
    End Sub

End Class