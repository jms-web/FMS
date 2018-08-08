Imports JMS_COMMON.ClsPubMethod

Public Class FrmM0051

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
    End Sub

#End Region

#Region "FORMイベント"
    Private Sub Frm_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        Try
            '-----フォーム共通設定
            Call FunFormCommonSetting(pub_APP_INFO, pub_SYAIN_INFO)

            '-----位置・サイズ
            Me.Height = 360
            Me.MinimumSize = New Size(1280, 360)
            Me.Top = Me.Owner.Top + (Me.Owner.Height - Me.Height) - 30 ' / 2
            Me.Left = Me.Owner.Left + (Me.Owner.Width - Me.Width) / 2


            '-----各コントロールのデータソースを設定
            Me.cmbKOMO_NM.SetDataSource(tblKOMO_NM.ExcludeDeleted, False)

            'イベントハンドラ設定
            AddHandler cmbKOMO_NM.TextChanged, AddressOf CmbKOMO_NM_TextChanged

            '-----処理モード別画面初期化
            Call FunInitializeControls(PrMODE)

            '-----ダイアログウィンドウ設定
            Me.FormBorderStyle = Windows.Forms.FormBorderStyle.FixedDialog
            Me.ControlBox = False

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
                        Me.PrPKeys = (Me.cmbKOMO_NM.Text.Trim, Me.mtxVALUE.Text.Trim)

                        Me.DialogResult = Windows.Forms.DialogResult.OK
                        Me.Close()
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

#Region "追加"
    Private Function FunINS() As Boolean
        Dim dsList As New DataSet
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
                    DB.BeginTransaction()

                    '-----存在チェック
                    sbSQL.Remove(0, sbSQL.Length)
                    sbSQL.Append("SELECT * FROM " & NameOf(MODEL.M001_SETTING) & "")
                    sbSQL.Append(" WHERE ITEM_NAME ='" & Me.cmbKOMO_NM.Text.Trim & "' ")
                    sbSQL.Append(" AND ITEM_VALUE ='" & Me.mtxVALUE.Text.Trim & "' ")
                    dsList = DB.GetDataSet(sbSQL.ToString, conblnNonMsg)
                    If dsList.Tables(0).Rows.Count > 0 Then '存在時
                        MessageBox.Show("既に登録済みのデータです。" & vbCrLf & "入力データを確認して下さい。", "存在チェック", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                        Return False
                    End If

                    '同一項目名の既定値を解除
                    If Me.chkDefaultVaue.Checked = True Then
                        sbSQL.Remove(0, sbSQL.Length)
                        sbSQL.Append("UPDATE " & NameOf(MODEL.M001_SETTING) & " SET")
                        sbSQL.Append(" DEF_FLG='0'")
                        sbSQL.Append("WHERE ITEM_NAME ='" & Me.cmbKOMO_NM.Text.Trim & "' ")
                        sbSQL.Append(" AND ITEM_VALUE <>'" & Me.mtxVALUE.Text.Trim & "' ")

                        intRET = DB.ExecuteNonQuery(sbSQL.ToString, conblnNonMsg, sqlEx)
                        If sqlEx.InnerException IsNot Nothing Then
                            'エラーログ出力
                            Dim strErrMsg As String = My.Resources.ErrLogSqlExecutionFailure & sbSQL.ToString & "|" & sqlEx.Message
                            WL.WriteLogDat(strErrMsg)
                            blnErr = True
                            Return False
                        End If
                    End If

                    '-----INSERT
                    sbSQL.Remove(0, sbSQL.Length)
                    sbSQL.Append("INSERT INTO " & NameOf(MODEL.M001_SETTING) & " (")
                    sbSQL.Append("  ITEM_GROUP")
                    sbSQL.Append(" ,ITEM_NAME")
                    sbSQL.Append(" ,ITEM_VALUE")
                    sbSQL.Append(" ,ITEM_DISP")
                    sbSQL.Append(" ,DISP_ORDER")
                    sbSQL.Append(" ,DEF_FLG")
                    sbSQL.Append(" ,BIKOU")
                    sbSQL.Append(" ,ADD_YMDHNS")
                    sbSQL.Append(" ,ADD_SYAIN_ID")
                    sbSQL.Append(" ,UPD_YMDHNS")
                    sbSQL.Append(" ,UPD_SYAIN_ID")
                    sbSQL.Append(" ,DEL_YMDHNS")
                    sbSQL.Append(" ,DEL_SYAIN_ID")
                    sbSQL.Append(" ) VALUES ( ")
                    '項目グループ
                    sbSQL.Append(" '" & Me.mtxKOMO_GROUP.Text.Trim & "'")
                    '項目名
                    sbSQL.Append(" ,'" & Me.cmbKOMO_NM.Text.Trim & "'")
                    '項目値
                    sbSQL.Append(" ,'" & Me.mtxVALUE.Text.Trim & "'")
                    '表示値
                    sbSQL.Append(" ,'" & Nz(Me.mtxDISP.Text.Trim, " ") & "'")
                    '表示順
                    sbSQL.Append(" ," & Me.cmbJYUN.SelectedValue & "")
                    '既定値フラグ
                    sbSQL.Append(" ,'" & IIf(Me.chkDefaultVaue.Checked = True, "1", "0") & "'")
                    '備考
                    sbSQL.Append(" ,'" & Nz(Me.mtxBIKOU.Text.Trim, " ") & "'")
                    '追加日時
                    sbSQL.Append(" ,dbo.GetSysDateString()")
                    '追加日時
                    sbSQL.Append(" ," & pub_SYAIN_INFO.SYAIN_ID & "")
                    '追加担当者
                    sbSQL.Append(" ,dbo.GetSysDateString()")
                    '更新担当者
                    sbSQL.Append(" ," & pub_SYAIN_INFO.SYAIN_ID & "")
                    '削除日時
                    sbSQL.Append(" ,' '")
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
        Dim dsList As New System.Data.DataSet

        Try
            '入力チェック
            If FunCheckInput() = False Then
                Return False
            End If

            Using DB As ClsDbUtility = DBOpen()
                Dim intRET As Integer
                Dim sqlEx As Exception = Nothing
                Dim blnErr As Boolean

                Try
                    'トランザクション
                    DB.BeginTransaction()

                    '-----存在チェック
                    sbSQL.Append("SELECT * FROM " & NameOf(MODEL.M001_SETTING) & " ")
                    sbSQL.Append("WHERE")
                    sbSQL.Append(" ITEM_NAME ='" & Me.cmbKOMO_NM.Text.Trim & "' ")
                    sbSQL.Append(" AND ITEM_VALUE ='" & Me.mtxVALUE.Text.Trim & "' ")
                    sbSQL.Append(" AND UPD_YMDHNS ='" & PrDataRow.Item("UPD_YMDHNS").ToString & "' ")
                    dsList = DB.GetDataSet(sbSQL.ToString)
                    If dsList.Tables(0).Rows.Count = 0 Then '非存在時
                        MessageBox.Show(String.Format(My.Resources.infoSearchDataChange), My.Resources.infoTilteDuplicateCheck, MessageBoxButtons.OK, MessageBoxIcon.Information)
                        Return False
                    End If

                    '-----同一項目名の既定値を解除
                    If Me.chkDefaultVaue.Checked = True Then
                        sbSQL.Remove(0, sbSQL.Length)
                        sbSQL.Append("UPDATE " & NameOf(MODEL.M001_SETTING) & " SET")
                        sbSQL.Append(" DEF_FLG='0' ")
                        sbSQL.Append(" WHERE ITEM_NAME ='" & Me.cmbKOMO_NM.Text.Trim & "' ")
                        sbSQL.Append(" AND ITEM_VALUE <>'" & Me.mtxVALUE.Text.Trim & "' ")

                        intRET = DB.ExecuteNonQuery(sbSQL.ToString, conblnNonMsg, sqlEx)
                        If sqlEx IsNot Nothing Then
                            'エラーログ
                            Dim strErrMsg As String = My.Resources.ErrLogSqlExecutionFailure & sbSQL.ToString & "|" & sqlEx.Message
                            WL.WriteLogDat(strErrMsg)
                            blnErr = True
                            Return False
                        End If
                    End If

                    'TODO: 表示順最終行の表示順が変更出来ない不具合の修正

                    '-----UPDATE(表示順)
                    If PrDataRow.Item("DISP_ORDER") <> Me.cmbJYUN.SelectedValue Then
                        If FunUpdateDispOrder(DB, PrDataRow.Item("DISP_ORDER"), Me.cmbJYUN.SelectedValue) = False Then
                            blnErr = True
                            Return False
                        End If
                    End If

                    '-----UPDATE(表示順以外)
                    sbSQL.Remove(0, sbSQL.Length)
                    sbSQL.Append("UPDATE " & NameOf(MODEL.M001_SETTING) & " SET")
                    sbSQL.Append(" ITEM_DISP ='" & Me.mtxDISP.Text.Trim & "'")
                    sbSQL.Append(" ,DEF_FLG ='" & IIf(Me.chkDefaultVaue.Checked = True, "1", "0") & "'")
                    sbSQL.Append(" ,BIKOU ='" & Me.mtxBIKOU.Text.Trim & "'")
                    sbSQL.Append(" ,UPD_SYAIN_ID = " & pub_SYAIN_INFO.SYAIN_ID)
                    sbSQL.Append(" ,UPD_YMDHNS = dbo.GetSysDateString()")
                    sbSQL.Append("WHERE")
                    sbSQL.Append(" ITEM_NAME ='" & Me.cmbKOMO_NM.Text.Trim & "' ")
                    sbSQL.Append(" AND ITEM_VALUE ='" & Me.mtxVALUE.Text.Trim & "' ")

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

    '項目名コンボボックス変更時イベント
    Private Sub CmbKOMO_NM_TextChanged(sender As Object, e As EventArgs)
        Dim dsList As New DataSet
        Dim sbSQL As New System.Text.StringBuilder
        Dim intMaxOrder As Integer

        Try

            If cmbKOMO_NM.Text.IsNullOrWhiteSpace = False Then

                Me.cmbJYUN.DataSource = Nothing

                Using DB As ClsDbUtility = DBOpen()
                    sbSQL.Append("SELECT ITEM_VALUE")
                    sbSQL.Append(" FROM " & NameOf(MODEL.M001_SETTING) & "")
                    sbSQL.Append(" WHERE ITEM_NAME ='" & cmbKOMO_NM.Text & "'")
                    dsList = DB.GetDataSet(sbSQL.ToString, conblnNonMsg)
                End Using

                intMaxOrder = dsList.Tables(0).Rows.Count

                Dim intModeDiff As Integer
                Select Case PrMODE
                    Case ENM_DATA_OPERATION_MODE._1_ADD, ENM_DATA_OPERATION_MODE._2_ADDREF
                        intModeDiff = 1
                    Case ENM_DATA_OPERATION_MODE._3_UPDATE
                        intModeDiff = 0
                    Case Else
                        Throw New ArgumentException(My.Resources.ErrMsgException, PrMODE.ToString)
                End Select

                Dim dt As New DataTableEx
                For i As Integer = 1 To intMaxOrder + intModeDiff
                    Dim Trow As DataRow = dt.NewRow()
                    Trow("DISP") = i
                    Trow("VALUE") = i
                    Trow("DEL_FLG") = False
                    dt.Rows.Add(Trow)
                Next i

                Call cmbJYUN.SetDataSource(dt, False)

                Select Case PrMODE
                    Case ENM_DATA_OPERATION_MODE._1_ADD, ENM_DATA_OPERATION_MODE._2_ADDREF
                        cmbJYUN.SelectedValue = intMaxOrder + intModeDiff
                    Case ENM_DATA_OPERATION_MODE._3_UPDATE
                        cmbJYUN.SelectedValue = PrDataRow.Item("DISP_ORDER")
                    Case Else
                        Throw New ArgumentException(My.Resources.ErrMsgException, PrMODE.ToString)
                End Select
            End If

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
            'TODO: 入力チェック通知はDialogからErrorProviderに変更

            '項目名
            If cmbKOMO_NM.Text.IsNullOrWhiteSpace Then
                MessageBox.Show(String.Format(My.Resources.infoMsgRequireSelectOrInput, "項目名"), My.Resources.infoTitleInputCheck, MessageBoxButtons.OK, MessageBoxIcon.Information)
                Me.cmbKOMO_NM.Focus()
                Return False
            End If

            '項目値
            If Me.mtxVALUE.Text.IsNullOrWhiteSpace Then
                MessageBox.Show(String.Format(My.Resources.infoMsgRequireInput, "項目値"), My.Resources.infoTitleInputCheck, MessageBoxButtons.OK, MessageBoxIcon.Information)
                Me.mtxVALUE.Focus()
                Return False
            End If

            Return True
        Catch ex As Exception
            EM.ErrorSyori(ex, False, conblnNonMsg)
            Return False
        End Try
    End Function
#End Region

#Region "ローカル関数"

#Region "処理モード別画面初期化"
    Private Function FunInitializeControls(ByVal intMODE As Integer) As Boolean
        Try

            Select Case intMODE
                Case ENM_DATA_OPERATION_MODE._1_ADD
                    lblTytle.Text &= "（追加）"
                    Me.cmdFunc1.Text = "追加(F1)"

                    Me.cmbKOMO_NM.Enabled = True
                    Me.mtxVALUE.Enabled = True
                    Me.mtxDISP.Enabled = True

                    Me.lbllblEDIT_YMDHNS.Visible = False
                    Me.lblEDIT_YMDHNS.Visible = False
                    Me.lbllblEDIT_SYAIN_ID.Visible = False
                    Me.lblEDIT_SYAIN_ID.Visible = False

                Case ENM_DATA_OPERATION_MODE._2_ADDREF
                    Call FunSetEntityValues(PrDataRow)

                    lblTytle.Text &= "（類似追加）"
                    Me.cmdFunc1.Text = "追加(F1)"

                    Me.cmbKOMO_NM.Enabled = True
                    Me.mtxVALUE.Enabled = True
                    Me.mtxDISP.Enabled = True

                    Me.lbllblEDIT_YMDHNS.Visible = False
                    Me.lblEDIT_YMDHNS.Visible = False
                    Me.lbllblEDIT_SYAIN_ID.Visible = False
                    Me.lblEDIT_SYAIN_ID.Visible = False

                Case ENM_DATA_OPERATION_MODE._3_UPDATE
                    Call FunSetEntityValues(PrDataRow)

                    lblTytle.Text &= "（変更）"
                    Me.cmdFunc1.Text = "変更(F1)"

                    Me.mtxKOMO_GROUP.Enabled = False
                    Me.cmbKOMO_NM.Enabled = False
                    Me.mtxVALUE.Enabled = False
                    Me.mtxDISP.Enabled = True

                    Me.lbllblEDIT_YMDHNS.Visible = True
                    Me.lblEDIT_YMDHNS.Visible = True
                    Me.lbllblEDIT_SYAIN_ID.Visible = True
                    Me.lblEDIT_SYAIN_ID.Visible = True

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
    ''' <param name="row"></param>
    ''' <returns></returns>
    Private Function FunSetEntityValues(row As C1.Win.C1FlexGrid.Row) As Boolean
        Dim _model As New MODEL.VWM001_SETTING
        Try

            '-----コントロールに値をセット
            With row
                '項目グループ
                Me.mtxKOMO_GROUP.Text = .Item(NameOf(_model.ITEM_GROUP))
                '項目名
                Call FunSetComboboxValue(Me.cmbKOMO_NM, tblKOMO_NM, .Item(NameOf(_model.ITEM_NAME)))
                '項目値
                Me.mtxVALUE.Text = .Item(NameOf(_model.ITEM_VALUE)).ToString.Trim
                '表示値
                Me.mtxDISP.Text = .Item(NameOf(_model.ITEM_DISP)).ToString.Trim
                '表示順
                Me.cmbJYUN.SelectedValue = .Item(NameOf(_model.DISP_ORDER))
                '既定値フラグ
                Me.chkDefaultVaue.Checked = .Item(NameOf(_model.DEF_FLG))

                '備考
                Me.mtxBIKOU.Text = .Item(NameOf(_model.BIKOU)).ToString.Trim

                '更新日時
                Dim dt As DateTime
                dt = DateTime.ParseExact(.Item(NameOf(_model.UPD_YMDHNS)).ToString, "yyyyMMddHHmmss", Nothing)
                Me.lblEDIT_YMDHNS.Text = dt.ToString("yyyy/MM/dd HH:mm:ss")

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

#Region "表示順更新"
    Private Function FunUpdateDispOrder(ByRef DB As ClsDbUtility, ByVal intBeforeValue As Integer, ByVal intAfterValue As Integer) As Boolean
        Dim sbSQL As New System.Text.StringBuilder
        Dim intRET As Integer
        Dim dsList As New System.Data.DataSet
        Dim sqlEx As New Exception
        Try

            '-----同一項目名内に同じ表示順が存在する場合、intTergetJyun以降の表示順を全て更新する
            If intBeforeValue < intAfterValue Then
                sbSQL.Remove(0, sbSQL.Length)
                sbSQL.Append("UPDATE " & nameof(model.M001_SETTING) & " SET")
                sbSQL.Append(" DISP_ORDER = DISP_ORDER-1 ")
                sbSQL.Append("WHERE")
                sbSQL.Append(" ITEM_NAME ='" & Me.cmbKOMO_NM.Text.Trim & "' ")
                sbSQL.Append(" AND DISP_ORDER >" & intBeforeValue & " ")
                sbSQL.Append(" AND DISP_ORDER <=" & intAfterValue & " ")
            Else
                '元の表示順より小さくした場合、他の項目を1つ後ろにずらす
                sbSQL.Remove(0, sbSQL.Length)
                sbSQL.Append("UPDATE " & nameof(model.M001_SETTING) & " SET")
                sbSQL.Append(" DISP_ORDER = DISP_ORDER+1 ")
                sbSQL.Append("WHERE")
                sbSQL.Append(" ITEM_NAME ='" & Me.cmbKOMO_NM.Text.Trim & "' ")
                sbSQL.Append(" AND DISP_ORDER >=" & intAfterValue & " ")
                sbSQL.Append(" AND DISP_ORDER <" & intBeforeValue & " ")
            End If

            intRET = DB.ExecuteNonQuery(sbSQL.ToString, conblnNonMsg, sqlEx)
            If intRET = 0 Then
                'エラーログ
                Dim strErrMsg As String = My.Resources.ErrLogSqlExecutionFailure & sbSQL.ToString & "|" & sqlEx.Message
                WL.WriteLogDat(strErrMsg)
                Return False
            End If

            '-----UPDATE
            sbSQL.Remove(0, sbSQL.Length)
            sbSQL.Append("UPDATE " & nameof(model.M001_SETTING) & " SET")
            sbSQL.Append(" DISP_ORDER ='" & intAfterValue & "' ")
            sbSQL.Append("WHERE")
            sbSQL.Append(" ITEM_NAME ='" & Me.cmbKOMO_NM.Text.Trim & "' ")
            sbSQL.Append(" AND ITEM_VALUE ='" & Me.mtxVALUE.Text.Trim & "' ")
            sbSQL.Append(" AND DISP_ORDER =" & intBeforeValue & " ")

            intRET = DB.ExecuteNonQuery(sbSQL.ToString, conblnNonMsg, sqlEx)
            If intRET <> 1 Then
                'エラーログ
                Dim strErrMsg As String = My.Resources.ErrLogSqlExecutionFailure & sbSQL.ToString & "|" & sqlEx.Message
                WL.WriteLogDat(strErrMsg)
                Return False
            End If

            Return True
        Catch ex As Exception
            EM.ErrorSyori(ex, False, conblnNonMsg)
            Return False
        End Try
    End Function

#End Region


#End Region


End Class
