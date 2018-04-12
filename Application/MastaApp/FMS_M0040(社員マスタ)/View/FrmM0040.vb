Imports JMS_COMMON.ClsPubMethod

Public Class FrmM0040

#Region "コンストラクタ"
    ''' <summary>
    ''' コンストラクタ
    ''' </summary>
    ''' <remarks>コンストラクタ</remarks>
    Public Sub New()

        ' この呼び出しはデザイナーで必要です。
        InitializeComponent()

        'ツールチップメッセージ
        MyBase.ToolTip.SetToolTip(Me.cmdFunc3, My.Resources.infoToolTipMsgNotFoundData)
        MyBase.ToolTip.SetToolTip(Me.cmdFunc4, My.Resources.infoToolTipMsgNotFoundData)
        MyBase.ToolTip.SetToolTip(Me.cmdFunc5, My.Resources.infoToolTipMsgNotFoundData)
        MyBase.ToolTip.SetToolTip(Me.cmdFunc10, My.Resources.infoToolTipMsgNotFoundData)

    End Sub
#End Region

#Region "Form関連"

    'Loadイベント
    Private Sub FrmLoad(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        Try
            '-----フォーム初期設定(親フォームから呼び出し)
            Call FunFormCommonSetting(pub_APP_INFO, pub_SYAIN_INFO, My.Application.Info.Version.ToString)

            '-----グリッド初期設定(親フォームから呼び出し)
            Call FunInitializeDataGridView(Me.dgvDATA)

            '-----グリッド列作成
            Call FunSetDgvCulumns(Me.dgvDATA)

            '-----コントロールデータソース設定
            'cmbSYOKUBAN.SetDataSource(tblSYOKUBAN.ExcludeDeleted, True)

            '-----イベントハンドラ設定
            AddHandler cmbSYOKUBAN.SelectedValueChanged, AddressOf SearchFilterValueChanged
            AddHandler Me.chkDeletedRowVisibled.CheckedChanged, AddressOf SearchFilterValueChanged

            '検索実行
            Me.cmdFunc1.PerformClick()

        Finally

        End Try
    End Sub

#End Region

#Region "DataGridView関連"

    'フィールド定義
    Private Function FunSetDgvCulumns(ByVal dgv As DataGridView) As Boolean

        Try
            With dgv
                .RowCount = 0
                .ColumnCount = 0

                .Columns.Add("TANTO_CD", "担当者コード")
                .Columns(.ColumnCount - 1).Width = 80
                .Columns(.ColumnCount - 1).DefaultCellStyle.Alignment = Windows.Forms.DataGridViewContentAlignment.MiddleRight

                .Columns.Add("SYOKUBAN", "職番")
                .Columns(.ColumnCount - 1).DefaultCellStyle.Alignment = Windows.Forms.DataGridViewContentAlignment.MiddleRight

                .Columns.Add("TANTO_NAME", "担当者名")
                .Columns(.ColumnCount - 1).Width = 150
                .Columns(.ColumnCount - 1).DefaultCellStyle.Alignment = Windows.Forms.DataGridViewContentAlignment.MiddleLeft

                .Columns.Add("TANTO_NAME_KANA", "担当者名カナ")
                .Columns(.ColumnCount - 1).Width = 100
                .Columns(.ColumnCount - 1).DefaultCellStyle.Alignment = Windows.Forms.DataGridViewContentAlignment.MiddleLeft

                .Columns.Add("CYOKKAN_KB_DISP", "直間区分")
                .Columns(.ColumnCount - 1).Width = 80
                .Columns(.ColumnCount - 1).DefaultCellStyle.Alignment = Windows.Forms.DataGridViewContentAlignment.MiddleCenter

                .Columns.Add("NYUSYA_YMD", "入社日")
                .Columns(.ColumnCount - 1).Width = 90
                .Columns(.ColumnCount - 1).DefaultCellStyle.Alignment = Windows.Forms.DataGridViewContentAlignment.MiddleRight

                .Columns.Add("TAISYA_YMD", "退社日")
                .Columns(.ColumnCount - 1).Width = 90
                .Columns(.ColumnCount - 1).DefaultCellStyle.Alignment = Windows.Forms.DataGridViewContentAlignment.MiddleRight

                .Columns.Add("YAKUSYOKU_KB_DISP", "役職区分")
                .Columns(.ColumnCount - 1).Width = 80
                .Columns(.ColumnCount - 1).DefaultCellStyle.Alignment = Windows.Forms.DataGridViewContentAlignment.MiddleCenter

                .Columns.Add("BU_CD", "部コード")
                .Columns(.ColumnCount - 1).Width = 80
                .Columns(.ColumnCount - 1).DefaultCellStyle.Alignment = Windows.Forms.DataGridViewContentAlignment.MiddleRight

                .Columns.Add("KA_CD", "課コード")
                .Columns(.ColumnCount - 1).Width = 80
                .Columns(.ColumnCount - 1).DefaultCellStyle.Alignment = Windows.Forms.DataGridViewContentAlignment.MiddleRight

                .Columns.Add("BIRTHDAY", "生年月日")
                .Columns(.ColumnCount - 1).Width = 90
                .Columns(.ColumnCount - 1).DefaultCellStyle.Alignment = Windows.Forms.DataGridViewContentAlignment.MiddleCenter

                .Columns.Add("PASSWORD", "パスワード")
                .Columns(.ColumnCount - 1).Visible = False

                .Columns.Add("ADD_YMDHNS", "追加日時")
                .Columns(.ColumnCount - 1).Visible = False

                .Columns.Add("ADD_TANTO_CD", "追加担当者コード")
                .Columns(.ColumnCount - 1).Visible = False

                .Columns.Add("EDIT_YMDHNS", "更新日時")
                .Columns(.ColumnCount - 1).Visible = False

                .Columns.Add("EDIT_TANTO_CD", "更新担当者コード")
                .Columns(.ColumnCount - 1).Visible = False

                Dim cmbclmn1 As New DataGridViewCheckBoxColumn With {
                .Name = "DEL_FLG",
                .HeaderText = "削除済",
                .Width = 30
                }
                cmbclmn1.DefaultCellStyle.Alignment = Windows.Forms.DataGridViewContentAlignment.MiddleCenter
                .Columns.Add(cmbclmn1)
                .Columns(.ColumnCount - 1).SortMode = DataGridViewColumnSortMode.Automatic

                .Columns.Add("DEL_YMDHNS", "削除日時")
                .Columns(.ColumnCount - 1).Visible = False

                .Columns.Add("DEL_TANTO_CD", "削除担当者コード")
                .Columns(.ColumnCount - 1).Visible = False

                'バインディング
                .AutoGenerateColumns = False
                .Columns("TANTO_CD").DataPropertyName = "TANTO_CD"
                .Columns("SYOKUBAN").DataPropertyName = "SYOKUBAN"
                .Columns("TANTO_NAME").DataPropertyName = "TANTO_NAME"
                .Columns("TANTO_NAME_KANA").DataPropertyName = "TANTO_NAME_KANA"
                .Columns("CYOKKAN_KB_DISP").DataPropertyName = "CYOKKAN_KB_DISP"
                .Columns("NYUSYA_YMD").DataPropertyName = "NYUSYA_YMD"
                .Columns("TAISYA_YMD").DataPropertyName = "TAISYA_YMD"
                .Columns("YAKUSYOKU_KB_DISP").DataPropertyName = "YAKUSYOKU_KB_DISP"
                .Columns("BU_CD").DataPropertyName = "BU_CD"
                .Columns("KA_CD").DataPropertyName = "KA_CD"
                .Columns("BIRTHDAY").DataPropertyName = "BIRTHDAY"
                .Columns("PASSWORD").DataPropertyName = "PASSWORD"
                .Columns("ADD_YMDHNS").DataPropertyName = "ADD_YMDHNS"
                .Columns("ADD_TANTO_CD").DataPropertyName = "ADD_TANTO_CD"
                .Columns("EDIT_YMDHNS").DataPropertyName = "EDIT_YMDHNS"
                .Columns("EDIT_TANTO_CD").DataPropertyName = "EDIT_TANTO_CD"
                .Columns("DEL_YMDHNS").DataPropertyName = "DEL_YMDHNS"
                .Columns("DEL_TANTO_CD").DataPropertyName = "DEL_TANTO_CD"
                .Columns("DEL_FLG").DataPropertyName = "DEL_FLG"

            End With

            Return True
        Catch ex As Exception
            EM.ErrorSyori(ex, False, conblnNonMsg)
            Return False
        End Try
    End Function

    'グリッドセル(行)ダブルクリック時イベント
    Private Sub DgvDATA_CellDoubleClick(sender As System.Object, e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvDATA.CellDoubleClick
        Try
            'ヘッダ以外のセルダブルクリック時
            If e.RowIndex >= 0 Then
                '該当行の変更処理を実行する
                Me.cmdFunc4.PerformClick()
            End If

        Catch ex As Exception
            EM.ErrorSyori(ex, False, conblnNonMsg)
        End Try
    End Sub

    '行選択時イベント
    Private Overloads Sub DgvDATA_SelectionChanged(sender As System.Object, e As System.EventArgs) Handles dgvDATA.SelectionChanged
        Try
        Finally
            Call FunInitFuncButtonEnabled(Me)
        End Try
    End Sub

#End Region

#Region "FunctionButton関連"

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
                Case 1  '検索
                    Call FunSetDgvData(Me.dgvDATA, FunSRCH())
                Case 2  '追加
                    '[処理中]
                    Me.PrPG_STATUS = ENM_PG_STATUS._3_PROCESSING

                    If FunUpdateEntity(ENM_DATA_OPERATION_MODE._1_ADD) = True Then

                        Call FunSetDgvData(Me.dgvDATA, FunSRCH())
                    End If

                Case 3  '参照追加
                    '[処理中]
                    Me.PrPG_STATUS = ENM_PG_STATUS._3_PROCESSING

                    If FunUpdateEntity(ENM_DATA_OPERATION_MODE._2_ADDREF) = True Then

                        Call FunSetDgvData(Me.dgvDATA, FunSRCH())
                    End If

                Case 4  '変更
                    '[処理中]
                    Me.PrPG_STATUS = ENM_PG_STATUS._3_PROCESSING

                    If FunUpdateEntity(ENM_DATA_OPERATION_MODE._3_UPDATE) = True Then

                        Call FunSetDgvData(Me.dgvDATA, FunSRCH())
                    End If

                Case 5, 6  '削除/復元/完全削除
                    '[処理中]
                    Me.PrPG_STATUS = ENM_PG_STATUS._3_PROCESSING

                    Dim btn As Button = DirectCast(sender, Button)
                    Dim ENM_MODE As ENM_DATA_OPERATION_MODE = DirectCast(btn.Tag, ENM_DATA_OPERATION_MODE)
                    If FunDEL(ENM_MODE) = True Then
                        Call FunSetDgvData(Me.dgvDATA, FunSRCH())
                    End If
                Case 10  'CSV出力
                    '[処理中]
                    Me.PrPG_STATUS = ENM_PG_STATUS._3_PROCESSING

                    Dim strFileName As String = pub_APP_INFO.strTitle & "_" & DateTime.Today.ToString("yyyyMMdd") & ".CSV"
                    Call FunCSV_OUT(Me.dgvDATA.DataSource, strFileName, pub_APP_INFO.strOUTPUT_PATH)

                Case 12 '閉じる
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

            'ファンクションキー有効化初期化
            Call FunInitFuncButtonEnabled(Me)

            '[アクティブ]
            Me.PrPG_STATUS = ENM_PG_STATUS._2_ACTIVE
        End Try

    End Sub
#End Region

#Region "検索"
    Private Function FunSRCH() As DataTable
        Dim dsList As New System.Data.DataSet
        Dim sbSQL As New System.Text.StringBuilder
        Dim sbSQLWHERE As New System.Text.StringBuilder

        '----WHERE句作成
        sbSQLWHERE.Remove(0, sbSQLWHERE.Length)

        '---職番検索
        If Me.cmbSYOKUBAN.SelectedValue <> "" Then
            If sbSQLWHERE.Length = 0 Then
                sbSQLWHERE.Append(" WHERE SYOKUBAN = '" & Me.cmbSYOKUBAN.SelectedValue & "' ")
            Else
                sbSQLWHERE.Append(" AND SYOKUBAN =  '" & Me.cmbSYOKUBAN.SelectedValue & "' ")

            End If
        Else
            If cmbSYOKUBAN.Text.ToString.IsNullOrWhiteSpace = False Then

                If sbSQLWHERE.Length = 0 Then
                    sbSQLWHERE.Append(" WHERE SYOKUBAN  LIKE '%" & Me.cmbSYOKUBAN.Text.Trim & "%' ")
                Else
                    sbSQLWHERE.Append(" AND SYOKUBAN  LIKE '%" & Me.cmbSYOKUBAN.Text.Trim & "%' ")

                End If
            End If
        End If

        '---担当者名検索
        If Me.mtxTANTO_NAME.Text <> "" Then
            If sbSQLWHERE.Length = 0 Then
                sbSQLWHERE.Append(" WHERE TANTO_NAME LIKE '%" & Me.mtxTANTO_NAME.Text.Trim & "%'")
            End If
        End If

        If Me.chkDeletedRowVisibled.Checked = False Then
            If sbSQLWHERE.Length = 0 Then
                sbSQLWHERE.Append(" WHERE DEL_FLG <> 1 ")
            Else
                sbSQLWHERE.Append(" AND DEL_FLG <> 1 ")
            End If
            dgvDATA.Columns("DEL_FLG").Visible = False
        Else
            dgvDATA.Columns("DEL_FLG").Visible = True
        End If

        'SQL
        sbSQL.Remove(0, sbSQL.Length)
        sbSQL.Append("SELECT")
        sbSQL.Append(" *")
        sbSQL.Append(" FROM " & NameOf(MODEL.VWM004_SYAIN) & " ")
        sbSQL.Append(sbSQLWHERE)
        sbSQL.Append(" ORDER BY SYOKUBAN ")

        Using DB As ClsDbUtility = DBOpen()
            dsList = DB.GetDataSet(sbSQL.ToString, conblnNonMsg)
        End Using

        If dsList.Tables(0).Rows.Count > pub_APP_INFO.intSEARCHMAX Then
            If MessageBox.Show(My.Resources.infoSearchCountOver, "", MessageBoxButtons.YesNo, MessageBoxIcon.Information) = Windows.Forms.DialogResult.No Then
                Return Nothing
            End If
        End If

        Dim dt As New DataTable
        dt.Columns.Add("TANTO_CD", GetType(Decimal))
        dt.Columns.Add("SYOKUBAN", GetType(Integer))
        dt.Columns.Add("TANTO_NAME", GetType(String))
        dt.Columns.Add("TANTO_NAME_KANA", GetType(String))
        dt.Columns.Add("CYOKKAN_KB_DISP", GetType(String))
        dt.Columns.Add("NYUSYA_YMD", GetType(String))
        dt.Columns.Add("TAISYA_YMD", GetType(String))
        dt.Columns.Add("YAKUSYOKU_KB_DISP", GetType(String))
        dt.Columns.Add("BU_CD", GetType(Decimal))
        dt.Columns.Add("KA_CD", GetType(Decimal))
        dt.Columns.Add("BIRTHDAY", GetType(String))
        dt.Columns.Add("PASSWORD", GetType(String))
        dt.Columns.Add("EDIT_YMDHNS", GetType(String))
        dt.Columns.Add("DEL_YMDHNS", GetType(String))
        dt.Columns.Add("DEL_TANTO_CD", GetType(String))
        dt.Columns.Add("DEL_FLG", GetType(Boolean))

        With dsList.Tables(0)
            For intCNT As Integer = 0 To .Rows.Count - 1
                Dim Trow As DataRow = dt.NewRow()
                Trow("TANTO_CD") = .Rows(intCNT).Item("TANTO_CD")
                Trow("SYOKUBAN") = .Rows(intCNT).Item("SYOKUBAN")
                Trow("TANTO_NAME") = .Rows(intCNT).Item("TANTO_NAME")
                Trow("TANTO_NAME_KANA") = .Rows(intCNT).Item("TANTO_NAME_KANA")
                Trow("CYOKKAN_KB_DISP") = .Rows(intCNT).Item("CYOKKAN_KB_DISP")

                If .Rows(intCNT).Item("NYUSYA_YMD").ToString.Trim = "/" Then
                    Trow("NYUSYA_YMD") = ""
                Else
                    Trow("NYUSYA_YMD") = .Rows(intCNT).Item("NYUSYA_YMD")
                End If
                If .Rows(intCNT).Item("NYUSYA_YMD").ToString.Trim <> "" Then
                    Trow("NYUSYA_YMD") = String.Format("{0}/{1}/{2}", .Rows(intCNT).Item("NYUSYA_YMD").ToString.Substring(0, 4),
                                                                .Rows(intCNT).Item("NYUSYA_YMD").ToString.Substring(4, 2),
                                                                .Rows(intCNT).Item("NYUSYA_YMD").ToString.Substring(6, 2))
                End If
                If .Rows(intCNT).Item("TAISYA_YMD").ToString.Trim = "/" Then
                    Trow("TAISYA_YMD") = ""
                Else
                    Trow("TAISYA_YMD") = .Rows(intCNT).Item("TAISYA_YMD")
                End If
                If .Rows(intCNT).Item("TAISYA_YMD").ToString.Trim <> "" Then
                    Trow("TAISYA_YMD") = String.Format("{0}/{1}/{2}", .Rows(intCNT).Item("TAISYA_YMD").ToString.Substring(0, 4),
                                                                .Rows(intCNT).Item("TAISYA_YMD").ToString.Substring(4, 2),
                                                                .Rows(intCNT).Item("TAISYA_YMD").ToString.Substring(6, 2))
                End If
                Trow("YAKUSYOKU_KB_DISP") = .Rows(intCNT).Item("YAKUSYOKU_KB_DISP")
                Trow("BU_CD") = .Rows(intCNT).Item("BU_CD")
                Trow("KA_CD") = .Rows(intCNT).Item("KA_CD")
                Trow("BIRTHDAY") = .Rows(intCNT).Item("BIRTHDAY")
                If .Rows(intCNT).Item("BIRTHDAY").ToString.Trim = "/" Then
                    Trow("BIRTHDAY") = ""
                Else
                    Trow("BIRTHDAY") = .Rows(intCNT).Item("BIRTHDAY")
                End If
                If .Rows(intCNT).Item("BIRTHDAY").ToString.Trim <> "" Then
                    Trow("BIRTHDAY") = String.Format("{0}/{1}/{2}", .Rows(intCNT).Item("BIRTHDAY").ToString.Substring(0, 4),
                                                                .Rows(intCNT).Item("BIRTHDAY").ToString.Substring(4, 2),
                                                                .Rows(intCNT).Item("BIRTHDAY").ToString.Substring(6, 2))
                End If
                Trow("PASSWORD") = .Rows(intCNT).Item("PASSWORD")
                Trow("EDIT_YMDHNS") = .Rows(intCNT).Item("EDIT_YMDHNS")
                Trow("DEL_YMDHNS") = .Rows(intCNT).Item("DEL_YMDHNS")
                Trow("DEL_TANTO_CD") = .Rows(intCNT).Item("DEL_TANTO_CD")
                Trow("DEL_FLG") = CBool(.Rows(intCNT).Item("DEL_FLG"))

                dt.Rows.Add(Trow)

            Next intCNT
            dt.AcceptChanges()
        End With
        Return dt
    End Function
#End Region
    Private Function FunSetDgvData(ByVal dgv As DataGridView, ByVal dt As DataTable) As Boolean

        Dim waitDlg As WaitDialog = Nothing
        Dim lngCURROW As Long = 0
        Try
            If dt Is Nothing Then
                Return False
            End If

            '-----選択行記憶
            If dgv.RowCount > 0 Then
                lngCURROW = dgv.CurrentRow.Index
            End If

            '-----進行状況ダイアログ
            waitDlg = New WaitDialog()
            With waitDlg
                .Owner = Me
                .MainMsg = My.Resources.infoMsgProgressStatus
                .ProgressMax = 0  ' 全体の処理件数
                .ProgressMin = 0 ' 処理件数の最小値（0件から開始）
                .ProgressStep = 1 ' 何件ごとにメーターを進めるか
                .ProgressValue = 0 ' 最初の件数
                .SubMsg = ""
                .ProgressMsg = My.Resources.infoToolTipMsgSearching
                '表示
                waitDlg.Show()
            End With

            Me.dgvDATA.DataSource = dt

            Call FunSetDgvCellFormat(Me.dgvDATA)
            If dgv.RowCount > 0 Then
                '-----選択行設定
                Try
                    dgv.CurrentCell = dgv.Rows(lngCURROW).Cells(0)
                Catch dgvEx As Exception
                End Try

                Me.lblRecordCount.Text = String.Format(My.Resources.infoToolTipMsgFoundData, dgv.RowCount.ToString) '.PadLeft(5)
            Else
                Me.lblRecordCount.Text = My.Resources.infoSearchResultNotFound
            End If

            Return True

        Catch ex As Exception
            EM.ErrorSyori(ex, False, conblnNonMsg)
            Return False

        Finally
            '-----開放
            If waitDlg IsNot Nothing Then
                waitDlg.Close()
            End If

            '-----一覧可視
            dgv.Visible = True
        End Try
    End Function

    Private Function FunSetDgvCellFormat(ByVal dgv As DataGridView) As Boolean

        Try
            Dim strFieldList As New List(Of String)
            strFieldList.AddRange(New String() {"DEL_FLG"})

            For i As Integer = 0 To dgv.Rows.Count - 1
                With dgv.Rows(i)
                    For Each field As String In strFieldList

                        If Me.dgvDATA.Rows(i).Cells("DEL_FLG").Value = True Then
                            Me.dgvDATA.Rows(i).DefaultCellStyle.ForeColor = clrDeletedRowForeColor
                            Me.dgvDATA.Rows(i).DefaultCellStyle.BackColor = clrDeletedRowBackColor
                            Me.dgvDATA.Rows(i).DefaultCellStyle.SelectionForeColor = clrDeletedRowForeColor
                        Else
                        End If
                    Next
                End With
            Next i

        Catch ex As Exception
            EM.ErrorSyori(ex, False, conblnNonMsg)
        End Try
    End Function
#Region "追加・変更"
    ''' <summary>
    ''' レコード追加変更処理
    ''' </summary>
    ''' <returns></returns>
    Private Function FunUpdateEntity(ByVal intMODE As ENM_DATA_OPERATION_MODE) As Boolean

        Dim dlgRET As DialogResult
        Dim PKeys As String
        Dim DB As ClsDbUtility = Nothing
        Try
            Using frmDLG As New FrmM0041
                frmDLG.PrMODE = intMODE
                If Me.dgvDATA.CurrentRow IsNot Nothing Then
                    frmDLG.PrdgvCellCollection = Me.dgvDATA.CurrentRow.Cells
                Else
                    ''' <param name="intMODE">処理モード</param>
                    frmDLG.PrdgvCellCollection = Nothing
                End If
                dlgRET = frmDLG.ShowDialog(Me)
                PKeys = frmDLG.PrPKeys
            End Using

            If dlgRET = Windows.Forms.DialogResult.Cancel Then
                Return False
            Else

                '追加したコードの行を選択する
                For i As Integer = 0 To Me.dgvDATA.RowCount - 1
                    With Me.dgvDATA.Rows(i)
                        If .Cells(0).Value = PKeys Then
                            Me.dgvDATA.CurrentCell = .Cells(0)
                            Exit For
                        End If
                    End With
                Next i

            End If

            Return True
        Catch ex As Exception
            EM.ErrorSyori(ex, False, conblnNonMsg)
            Return False
        End Try
    End Function

#End Region

#Region "削除"
    Private Function FunDEL(ByVal ENM_MODE As ENM_DATA_OPERATION_MODE) As Boolean

        Dim sbSQL As New System.Text.StringBuilder
        Dim strMsg As String
        Dim strTitle As String
        Dim blnDeleteSubTable As Boolean
        Try
            '-----SQL
            sbSQL.Remove(0, sbSQL.Length)
            Select Case ENM_MODE
                Case ENM_DATA_OPERATION_MODE._4_DISABLE
                    sbSQL.Append("UPDATE M03_TANTO SET ")
                    '変更日時
                    sbSQL.Append(" EDIT_YMDHNS = dbo.GetSysDateString() ")
                    '削除日時
                    sbSQL.Append(" ,DEL_YMDHNS = dbo.GetSysDateString() ")
                    '更新社員ID
                    sbSQL.Append(" ,DEL_TANTO_CD = " & pub_SYAIN_INFO.SYAIN_ID & "")

                    strMsg = My.Resources.infoMsgDeleteOperationDisable
                    strTitle = My.Resources.infoTitleDeleteOperationDisable

                Case ENM_DATA_OPERATION_MODE._5_RESTORE
                    sbSQL.Append("UPDATE M03_TANTO SET ")
                    '削除日時
                    sbSQL.Append(" DEL_YMDHNS = ' ' ")
                    '更新社員ID
                    sbSQL.Append(" ,DEL_TANTO_CD = " & pub_SYAIN_INFO.SYAIN_ID & "")

                    strMsg = My.Resources.infoMsgDeleteOperationRestore
                    strTitle = My.Resources.infoTitleDeleteOperationRestore

                Case ENM_DATA_OPERATION_MODE._6_DELETE

                    sbSQL.Append("DELETE FROM M03_TANTO ")

                    strMsg = My.Resources.infoMsgDeleteOperationDelete
                    strTitle = My.Resources.infoTitleDeleteOperationDelete
                    blnDeleteSubTable = True
                Case Else
                    ' argument null exception
                    Return False
            End Select
            sbSQL.Append(" WHERE")
            sbSQL.Append(" TANTO_CD = '" & Me.dgvDATA.CurrentRow.Cells.Item("TANTO_CD").Value & "' ")

            '確認メッセージ表示
            If MessageBox.Show(strMsg, strTitle, MessageBoxButtons.YesNo, MessageBoxIcon.Question) <> Windows.Forms.DialogResult.Yes Then
                Me.DialogResult = Windows.Forms.DialogResult.Cancel
                'Me.Close()
                Return False
            End If

            Using DB As ClsDbUtility = DBOpen()
                Dim intRET As Integer
                Dim blnErr As Boolean
                Dim sqlEx As Exception = Nothing
                Try
                    'トランザクション
                    DB.BeginTransaction()
                    '-----SQL実行
                    intRET = DB.ExecuteNonQuery(sbSQL.ToString, conblnNonMsg, sqlEx)
                    If intRET <> 1 Then
                        'エラーログ
                        Dim strErrMsg As String = My.Resources.ErrLogSqlExecutionFailure & sbSQL.ToString & "|" & sqlEx.Message
                        WL.WriteLogDat(strErrMsg)
                        blnErr = True
                        Return False
                    End If
                Finally
                    '-----トランザクション
                    DB.Commit(Not blnErr)
                End Try
            End Using

            Return True
        Catch ex As Exception
            EM.ErrorSyori(ex, False, conblnNonMsg)
            Return False
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
                If dgv.CurrentRow IsNot Nothing AndAlso dgv.CurrentRow.Cells.Item("DEL_FLG").Value = True Then
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

    '検索フィルタ変更
    Private Sub SearchFilterValueChanged(sender As System.Object, e As System.EventArgs)
        '検索
        Me.cmdFunc1.PerformClick()
    End Sub

#End Region

End Class
