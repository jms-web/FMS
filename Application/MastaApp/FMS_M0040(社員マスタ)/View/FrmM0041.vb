Imports JMS_COMMON.ClsPubMethod

Public Class FrmM0041

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
    Public Property PrPKeys As String

    ''' <summary>
    ''' 一覧の選択行データ
    ''' </summary>
    Public Property PrdgvCellCollection As DataGridViewCellCollection

#End Region

#Region "FORMイベント"
    Private Sub Frm_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        Try
            '-----フォーム共通設定
            Call FunFormCommonSetting(pub_APP_INFO, pub_SYAIN_INFO)

            '-----ウィンドウ設定
            Me.FormBorderStyle = Windows.Forms.FormBorderStyle.FixedDialog
            Me.ControlBox = False

            '-----位置・サイズ
            Me.Height = 400
            Me.Top = Me.Owner.Top + (Me.Owner.Height - Me.Height) - 26 ' / 2
            Me.Left = Me.Owner.Left + (Me.Owner.Width - Me.Width) / 2

            '-----コントロールデータソース設定
            'Me.cmbKA_CD.SetDataSource(tblBU.ExcludeDeleted, True)
            'Me.cmbBUSYO_CD.SetDataSource(tblKA.ExcludeDeleted, True)
            'Me.cmbYAKUSYOKU_KB.SetDataSource(tblYAKU_KBN.ExcludeDeleted, True)
            'Me.cmbCYOKKAN_KB.SetDataSource(tblCYOKKAN_KBN.ExcludeDeleted, True)

            '-----処理モード別画面初期化
            Call FunInitializeControls(PrMODE)

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
                    Me.Text = pub_APP_INFO.strTitle & "（追加）"
                    Me.lblTytle.Text = Me.Text
                    Me.cmdFunc1.Text = "追加(F1)"

                    Me.mtxTANTO_NAME.Enabled = True
                    Me.mtxSYOKUBAN.Enabled = True

                    ''Me.mtxTANTO_CD.Text = "<新規>"
                    Me.mtxTANTO_CD.Enabled = True
                    ' Me.mtxTANTO_CD.ReadOnly = True

                    Me.lbllblEDIT_YMDHNS.Visible = False
                    Me.lblEDIT_YMDHNS.Visible = False

                Case ENM_DATA_OPERATION_MODE._2_ADDREF
                    Call FunSetEntityValues(PrdgvCellCollection)

                    Me.Text = pub_APP_INFO.strTitle & "（類似追加）"
                    Me.lblTytle.Text = Me.Text
                    Me.cmdFunc1.Text = "追加(F1)"

                    Me.mtxTANTO_NAME.Enabled = True
                    Me.mtxSYOKUBAN.Enabled = True

                    'Me.mtxTANTO_CD.Text = "<新規>"
                    'Me.mtxTANTO_CD.ReadOnly = True
                    Me.mtxTANTO_CD.Enabled = True
                    Me.lbllblEDIT_YMDHNS.Visible = False
                    Me.lblEDIT_YMDHNS.Visible = False

                Case ENM_DATA_OPERATION_MODE._3_UPDATE
                    Call FunSetEntityValues(PrdgvCellCollection)

                    Me.Text = pub_APP_INFO.strTitle & "（変更）"
                    Me.lblTytle.Text = Me.Text
                    Me.cmdFunc1.Text = "変更(F1)"

                    Me.mtxTANTO_CD.Enabled = False
                    Me.mtxTANTO_NAME.Enabled = True
                    Me.mtxSYOKUBAN.Enabled = True

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
    Private Function FunSetEntityValues(dgvCol As DataGridViewCellCollection) As Boolean

        Try
            '-----コントロールに値をセット
            With dgvCol
                '担当者CD
                Me.mtxTANTO_CD.Text = .Item("TANTO_CD").Value.ToString.Trim
                '職番
                Me.mtxSYOKUBAN.Text = .Item("SYOKUBAN").Value.ToString.Trim
                '担当者名
                Me.mtxTANTO_NAME.Text = .Item("TANTO_NAME").Value.ToString.Trim
                '担当者名カナ
                Me.mtxTANTO_NAME_KANA.Text = .Item("TANTO_NAME_KANA").Value.ToString.Trim
                '直間区分
                Me.cmbCYOKKAN_KB.Text = .Item("CYOKKAN_KB_DISP").Value.ToString.Trim
                '入社日
                Me.dtbNYUSYA_YMD.Text = .Item("NYUSYA_YMD").Value.ToString.Trim
                '退社日
                Me.dtbTAISYA_YMD.Text = .Item("TAISYA_YMD").Value.ToString.Trim
                '役職区分
                Me.cmbYAKUSYOKU_KB.Text = .Item("YAKUSYOKU_KB_DISP").Value.ToString.Trim
                '部CD      
                Me.cmbBUSYO_CD.Text = .Item("BU_CD").Value
                '課CD
                Me.cmbKA_CD.Text = .Item("KA_CD").Value
                '生年月日
                Me.dtbBIRTHDAY.Text = .Item("BIRTHDAY").Value.ToString.Trim
                '更新日時
                Dim dt As DateTime
                dt = DateTime.ParseExact(.Item("EDIT_YMDHNS").Value.ToString, "yyyyMMddHHmmss", Nothing)
                Me.lblEDIT_YMDHNS.Text = dt.ToString("yyyy/MM/dd HH:mm:ss")
                '更新担当者CD
                Me.lblEDIT_SYAIN_ID.Text = .Item("EDIT_TANTO_CD").Value & " " & Fun_GetUSER_NAME(.Item("EDIT_TANTO_CD").Value)

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
                        Me.PrPKeys = Me.mtxTANTO_CD.Text.Trim
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
                    sbSQL.Append("SELECT * FROM M03_TANTO ")
                    sbSQL.Append(" WHERE TANTO_CD ='" & Me.mtxTANTO_CD.Text.Trim & "'")

                    dsList = DB.GetDataSet(sbSQL.ToString, conblnNonMsg)
                    If dsList.Tables(0).Rows.Count > 0 Then '存在時
                        If MessageBox.Show(String.Format(My.Resources.infoTilteDuplicateData, "担当CD"), My.Resources.infoTilteDuplicateCheck, MessageBoxButtons.OKCancel, MessageBoxIcon.Exclamation) <> DialogResult.OK Then
                            Return False
                        End If
                    End If

                    ''Dim intNewTANTO_CD As Integer = FunGetNextTANTO_CD()
                    ''Me.mtxTANTO_CD.Text = intNewTANTO_CD

                    '-----INSERT
                    sbSQL.Remove(0, sbSQL.Length)
                    sbSQL.Append("INSERT INTO M03_TANTO(")
                    sbSQL.Append("  TANTO_CD ")
                    sbSQL.Append(" ,SYOKUBAN")
                    sbSQL.Append(" ,TANTO_NAME")
                    sbSQL.Append(" ,TANTO_NAME_KANA")
                    sbSQL.Append(" ,CYOKKAN_KB")
                    sbSQL.Append(" ,NYUSYA_YMD")
                    sbSQL.Append(" ,TAISYA_YMD")
                    sbSQL.Append(" ,YAKUSYOKU_KB")
                    sbSQL.Append(" ,BU_CD")
                    sbSQL.Append(" ,KA_CD")
                    sbSQL.Append(" ,BIRTHDAY")
                    sbSQL.Append(" ,PASSWORD")
                    sbSQL.Append(" ,ADD_YMDHNS")
                    sbSQL.Append(" ,ADD_TANTO_CD")
                    sbSQL.Append(" ,EDIT_YMDHNS")
                    sbSQL.Append(" ,EDIT_TANTO_CD")
                    sbSQL.Append(" ,DEL_YMDHNS")
                    sbSQL.Append(" ,DEL_TANTO_CD")
                    sbSQL.Append(" ) VALUES ( ")
                    '担当者CD
                    'sbSQL.Append(" " & intNewTANTO_CD & "")
                    sbSQL.Append(" " & Nz(Me.mtxTANTO_CD.Text.Trim, " ") & "")
                    '職番
                    sbSQL.Append(" ," & Me.mtxSYOKUBAN.Text.Trim & "")
                    '担当者名
                    sbSQL.Append(" ,'" & Me.mtxTANTO_NAME.Text.Trim & "'")
                    '担当者名カナ
                    sbSQL.Append(" ,'" & Me.mtxTANTO_NAME_KANA.Text.Trim & "'")
                    '直間区分
                    sbSQL.Append(" ,'" & Me.cmbCYOKKAN_KB.SelectedValue & "'")
                    '入社日
                    sbSQL.Append(" ,'" & Nz(Me.dtbNYUSYA_YMD.Text.Trim.Replace("/", ""), " ") & "'")
                    '退社日
                    sbSQL.Append(" ,'" & Nz(Me.dtbTAISYA_YMD.Text.Trim.Replace("/", ""), " ") & "'")
                    '役職区分
                    sbSQL.Append(" ,'" & Me.cmbYAKUSYOKU_KB.SelectedValue & "'")
                    '部CD
                    sbSQL.Append(" ," & Nz(Me.cmbBUSYO_CD.SelectedValue, " ") & "")
                    '課CD
                    sbSQL.Append(" ," & Nz(Me.cmbKA_CD.SelectedValue, " ") & "")
                    '生年月日
                    sbSQL.Append(" ,'" & Nz(Me.dtbBIRTHDAY.Text.Trim.Replace("/", ""), " ") & "'")
                    'パスワード
                    sbSQL.Append(" ,'" & Me.mtxPASSWORD.Text.Trim & "'")
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
                    sbSQL.Append("SELECT * FROM M03_TANTO ")
                    sbSQL.Append(" WHERE")
                    sbSQL.Append(" TANTO_CD =" & Nz(Me.mtxTANTO_CD.Text.Trim & ""))
                    sbSQL.Append(" AND EDIT_YMDHNS ='" & PrdgvCellCollection.Item("EDIT_YMDHNS").Value.ToString & "' ")
                    dsList = DB.GetDataSet(sbSQL.ToString)
                    If dsList.Tables(0).Rows.Count = 0 Then '非存在時
                        MessageBox.Show(String.Format(My.Resources.infoSearchDataChange), My.Resources.infoTilteDuplicateCheck, MessageBoxButtons.OK, MessageBoxIcon.Information)
                        Return False
                    End If

                    '-----UPDATE
                    sbSQL.Remove(0, sbSQL.Length)
                    sbSQL.Append("UPDATE M03_TANTO SET")
                    sbSQL.Append(" SYOKUBAN =" & Me.mtxSYOKUBAN.Text.Trim & "")
                    sbSQL.Append(" ,TANTO_NAME ='" & Me.mtxTANTO_NAME.Text.Trim & "'")
                    sbSQL.Append(" ,TANTO_NAME_KANA ='" & Me.mtxTANTO_NAME_KANA.Text.Trim & "'")
                    sbSQL.Append(" ,CYOKKAN_KB ='" & Me.cmbCYOKKAN_KB.SelectedValue & "'")
                    sbSQL.Append(" ,NYUSYA_YMD ='" & Nz(Me.dtbNYUSYA_YMD.Text.Trim.Replace("/", ""), " ") & "'")
                    sbSQL.Append(" ,TAISYA_YMD ='" & Nz(Me.dtbTAISYA_YMD.Text.Trim.Replace("/", ""), " ") & "'")
                    sbSQL.Append(" ,YAKUSYOKU_KB ='" & Me.cmbYAKUSYOKU_KB.SelectedValue & "'")
                    sbSQL.Append(" ,BU_CD =" & Nz(Me.cmbBUSYO_CD.SelectedValue, " ") & "")
                    sbSQL.Append(" ,KA_CD =" & Nz(Me.cmbKA_CD.SelectedValue, " ") & "")
                    sbSQL.Append(" ,BIRTHDAY ='" & Nz(Me.dtbBIRTHDAY.Text.Trim.Replace("/", ""), " ") & "'")
                    sbSQL.Append(" ,EDIT_YMDHNS = dbo.GetSysDateString() ")
                    sbSQL.Append(" WHERE")
                    sbSQL.Append(" TANTO_CD =" & Nz(Me.mtxTANTO_CD.Text.Trim, " "))

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
    Public Function FunInitFuncButtonEnabled(ByRef frm As FrmM0040) As Boolean

        Try
            For intFunc As Integer = 1 To 12
                With frm.Controls("cmdFunc" & intFunc)
                    If .Text.Length = 0 OrElse .Text.Substring(0, .Text.IndexOf("(")).Trim = "" Then
                        .Text = ""
                        .Visible = False
                    End If
                End With
            Next intFunc

            If frm.dgvDATA.RowCount > 0 Then
                frm.cmdFunc1.Enabled = True
                frm.cmdFunc2.Enabled = True
                frm.cmdFunc3.Enabled = True
                frm.cmdFunc4.Enabled = True
                frm.cmdFunc5.Enabled = True
                frm.cmdFunc10.Enabled = True
            Else
                frm.cmdFunc1.Enabled = True
                frm.cmdFunc2.Enabled = True
                frm.cmdFunc3.Enabled = False
                frm.cmdFunc4.Enabled = False
                frm.cmdFunc5.Enabled = False
                frm.cmdFunc10.Enabled = False
            End If

            Dim dgv As DataGridView = DirectCast(frm.Controls("dgvDATA"), DataGridView)
            If dgv.SelectedRows.Count > 0 Then
                If dgv.CurrentRow IsNot Nothing AndAlso dgv.CurrentRow.Cells.Item("DEF_FLG").Value <> "" Then
                    '削除済データの場合
                    frm.cmdFunc4.Enabled = False
                    frm.cmdFunc5.Text = "完全削除(F5)"
                    frm.cmdFunc5.Tag = ENM_DATA_OPERATION_MODE._6_DELETE

                    '復元
                    frm.cmdFunc6.Text = "復元(F6)"
                    frm.cmdFunc6.Visible = True
                    frm.cmdFunc6.Tag = ENM_DATA_OPERATION_MODE._5_RESTORE
                Else
                    frm.cmdFunc5.Text = "削除(F5)"
                    frm.cmdFunc5.Tag = ENM_DATA_OPERATION_MODE._4_DISABLE

                    frm.cmdFunc6.Text = ""
                    frm.cmdFunc6.Visible = False
                    frm.cmdFunc6.Tag = ""
                End If
            Else
                frm.cmdFunc6.Visible = False
            End If

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
            '担当者CD
            If Me.mtxTANTO_CD.Text.Trim = "" Then
                MessageBox.Show(String.Format(My.Resources.infoMsgRequireInput, "担当者CD"), My.Resources.infoTitleInputCheck, MessageBoxButtons.OK, MessageBoxIcon.Information)
                Me.mtxTANTO_CD.Focus()
                Return False
            End If

            '職番
            If Me.mtxSYOKUBAN.Text.Trim = "" Then
                MessageBox.Show(String.Format(My.Resources.infoMsgRequireInput, "職番"), My.Resources.infoTitleInputCheck, MessageBoxButtons.OK, MessageBoxIcon.Information)
                Me.mtxSYOKUBAN.Focus()
                Return False
            End If

            '担当者名
            If Me.mtxTANTO_NAME.Text = "" Then
                MessageBox.Show(String.Format(My.Resources.infoMsgRequireInput, "担当者名"), My.Resources.infoTitleInputCheck, MessageBoxButtons.OK, MessageBoxIcon.Information)
                Me.mtxTANTO_NAME.Focus()
                Return False
            End If

            '部CD
            If Me.cmbBUSYO_CD.SelectedValue = "" Then
                MessageBox.Show(String.Format(My.Resources.infoMsgRequireSelect, "部CD"), My.Resources.infoTitleInputCheck, MessageBoxButtons.OK, MessageBoxIcon.Information)
                Me.cmbBUSYO_CD.Focus()
                Return False
            End If

            '課CD
            If Me.cmbKA_CD.SelectedValue = "" Then
                MessageBox.Show(String.Format(My.Resources.infoMsgRequireSelect, "課CD"), My.Resources.infoTitleInputCheck, MessageBoxButtons.OK, MessageBoxIcon.Information)
                Me.cmbKA_CD.Focus()
                Return False
            End If

            Return True
        Catch ex As Exception
            EM.ErrorSyori(ex, False, conblnNonMsg)
            Return False
        End Try
    End Function


#Region "ローカル関数"

    Private Function FunGetNextTANTO_CD() As Integer

        Dim dsList As New System.Data.DataSet
        Try
            Dim intRET As Integer
            Dim sbSQL As New System.Text.StringBuilder

            sbSQL.Remove(0, sbSQL.Length)
            sbSQL.Append("SELECT MAX(TANTO_CD) FROM M03_TANTO ")
            Using DB As ClsDbUtility = DBOpen()
                dsList = DB.GetDataSet(sbSQL.ToString, conblnNonMsg)
            End Using

            intRET = Val(dsList.Tables(0).Rows(0).Item(0)) + 1

            Return intRET
        Catch ex As Exception
            EM.ErrorSyori(ex, False, conblnNonMsg)
            Return -1
        Finally
            dsList.Dispose()
        End Try
    End Function


#End Region
#End Region

End Class
