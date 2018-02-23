Imports JMS_COMMON.ClsPubMethod


'UNDONE: 検索フィールド、マスタ登録エリアのMaskedTextBoxの下の枠線がたまに一部消えてしまう？ フォーカスが当該コントロールを前後すると発生する？

Public Class FrmFMS_G010

#Region "定数・変数"
    'DATAGRIDVIEWセル編集前の値
    Private pri_objPrevCellValue As Object
    Private pri_blnUpdateCellValue As Boolean

#End Region

#Region "コンストラクタ"
    ''' <summary>
    ''' コンストラクタ
    ''' </summary>
    ''' <remarks>コンストラクタ</remarks>
    Public Sub New()

        ' この呼び出しはデザイナーで必要です。
        InitializeComponent()

        'ツールチップメッセージ
        MyBase.ToolTip.SetToolTip(Me.cmdFunc4, My.Resources.infoToolTipMsgNotFoundModifiedData)
        MyBase.ToolTip.SetToolTip(Me.cmdFunc7, My.Resources.infoToolTipMsgNotFoundData)
        MyBase.ToolTip.SetToolTip(Me.cmdFunc8, My.Resources.infoToolTipMsgNotFoundData)
        MyBase.ToolTip.SetToolTip(Me.cmdFunc9, My.Resources.infoToolTipMsgNotFoundData)
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
            'Call FunInitializeDataGridView(Me.dgvDATA)

            ''-----グリッド列作成
            'Call FunSetDgvCulumns(Me.dgvDATA)

            '-----コントロールデータソース設定
            'Me.cmbTOKUI.SetDataSource(tblTOKUI.ExcludeDeleted, False)

            'システム年月を設定
            'Me.dtYM.Value = Today.ToString("yyyy/MM")
            'Dim dtYM_N As Date
            'If DateTime.TryParseExact(Me.dtYM.Text & "01", "yyyy/MMdd", Nothing, Nothing, dtYM_N) = True Then
            '    '列名設定
            '    Me.dgvDATA.Columns("NAIJI_SU_N").HeaderText = String.Format("{0}内示", dtYM_N.ToString("yyyy年MM月"))
            '    Me.dgvDATA.Columns("NAIJI_SU_N_PLUS1").HeaderText = String.Format("{0}内示", dtYM_N.AddMonths(1).ToString("yyyy年MM月"))
            '    Me.dgvDATA.Columns("NAIJI_SU_N_PLUS2").HeaderText = String.Format("{0}内示", dtYM_N.AddMonths(2).ToString("yyyy年MM月"))
            'End If

            ''-----イベントハンドラ設定
            'AddHandler Me.cmbTOKUI.SelectedValueChanged, AddressOf SearchFilterValueChanged
            'AddHandler Me.dtYM.TxtChanged, AddressOf SearchFilterValueChanged

            ''検索実行
            'Me.cmdFunc1.PerformClick()

        Finally
        End Try
    End Sub


#End Region

#Region "DataGridView関連"

    'フィールド定義
    Private Function FunSetDgvCulumns(ByVal dgv As DataGridView) As Boolean

        Try
            With dgv
                Call EnableDoubleBuffering(Me.dgvDATA)
                .MultiSelect = False
                .SelectionMode = Windows.Forms.DataGridViewSelectionMode.CellSelect
                .StandardTab = False
                .ReadOnly = False

                .AutoGenerateColumns = False

                .Columns.Add("", "設備名")

                .Columns.Add("NAIJI_SU_N_PLUS2", "N+2月内示")
                .Columns(.ColumnCount - 1).Width = 130
                .Columns(.ColumnCount - 1).DefaultCellStyle.Alignment = Windows.Forms.DataGridViewContentAlignment.MiddleRight
                .Columns(.ColumnCount - 1).DefaultCellStyle.Format = "#,0"
                .Columns(.ColumnCount - 1).DefaultCellStyle.BackColor = clrCanEditCellBackColor
                .Columns(.ColumnCount - 1).DefaultCellStyle.SelectionBackColor = clrCanEditCellBackColor

                '日付
                For i = 1 To 31
                    .Columns.Add("DAY" & i.ToString("00"), "DAY" & i.ToString("00"))
                    .Columns(.ColumnCount - 1).Width = 60
                    .Columns(.ColumnCount - 1).DefaultCellStyle.Alignment = Windows.Forms.DataGridViewContentAlignment.MiddleRight
                    .Columns(.ColumnCount - 1).DefaultCellStyle.Format = "#,0"
                    .Columns(.ColumnCount - 1).ValueType = GetType(Integer)
                    DirectCast(.Columns(.ColumnCount - 1), DataGridViewTextBoxColumn).MaxInputLength = 6
                Next i

            End With

            Return True
        Catch ex As Exception
            EM.ErrorSyori(ex, False, conblnNonMsg)
            Return False
        End Try
    End Function

#Region "ソート"
    'ソート値比較
    Private Sub DgvDATA_SortCompare(ByVal sender As Object, ByVal e As DataGridViewSortCompareEventArgs)
        Try
            Select Case e.Column.Name
                Case "NAIJI_SU_N", "NAIJI_SU_N_PLUS1", "NAIJI_SU_N_PLUS2"
                    '数値列としてソート
                Case Else
                    Exit Sub
            End Select

            Dim a As Decimal = Val(System.Text.RegularExpressions.Regex.Replace(e.CellValue1, "[^.0-9]", ""))
            Dim b As Decimal = Val(System.Text.RegularExpressions.Regex.Replace(e.CellValue2, "[^.0-9]", ""))

            Dim c As Decimal = a - b
            If c < 0 Then
                e.SortResult = -1
            ElseIf c > 0 Then
                e.SortResult = 1
            Else
                e.SortResult = 0
            End If

            e.Handled = True
        Catch ex As Exception
            EM.ErrorSyori(ex, False, True)
            e.Handled = False
        End Try
    End Sub

    ''ソート
    'Private Sub DgvDATA_Sorted(sender As Object, e As EventArgs) Handles dgvDATA.Sorted

    '    Try
    '        '編集済み(未確定)セル書式設定
    '        For intCNT As Integer = 0 To Me.dgvDATA.DataSource.Rows.Count - 1
    '            'N
    '            If Me.dgvDATA.Rows(intCNT).Cells("MODIFIED_STATUS").Value.ToString.Contains("N") = True Then
    '                Me.dgvDATA.Rows(intCNT).Cells("NAIJI_SU_N").Style.ForeColor = clrEditedCellForeColor
    '                Me.dgvDATA.Rows(intCNT).Cells("NAIJI_SU_N").Style.SelectionForeColor = clrEditedCellForeColor
    '            End If
    '            'N+1
    '            If Me.dgvDATA.Rows(intCNT).Cells("MODIFIED_STATUS").Value.ToString.Contains("O") = True Then
    '                Me.dgvDATA.Rows(intCNT).Cells("NAIJI_SU_N_PLUS1").Style.ForeColor = clrEditedCellForeColor
    '                Me.dgvDATA.Rows(intCNT).Cells("NAIJI_SU_N_PLUS1").Style.SelectionForeColor = clrEditedCellForeColor
    '            End If
    '            'N+2
    '            If Me.dgvDATA.Rows(intCNT).Cells("MODIFIED_STATUS").Value.ToString.Contains("P") = True Then
    '                Me.dgvDATA.Rows(intCNT).Cells("NAIJI_SU_N_PLUS2").Style.ForeColor = clrEditedCellForeColor
    '                Me.dgvDATA.Rows(intCNT).Cells("NAIJI_SU_N_PLUS2").Style.SelectionForeColor = clrEditedCellForeColor
    '            End If
    '        Next

    '    Catch ex As Exception
    '        EM.ErrorSyori(ex, False, conblnNonMsg)
    '    End Try
    'End Sub

#End Region

#Region "セル編集関連"
    'セルクリック時イベント
    Private Sub DgvDATA_CellClick(sender As System.Object, e As DataGridViewCellEventArgs)
        Dim dgv As DataGridView = DirectCast(sender, DataGridView)

        If e.RowIndex >= 0 AndAlso dgv(e.ColumnIndex, e.RowIndex).ReadOnly = False Then
            Me.dgvDATA.BeginEdit(True)
        End If
    End Sub


    'セル編集開始イベント
    Private Sub DgvDATA_CellBeginEdit(sender As Object, e As DataGridViewCellCancelEventArgs)
        Try
            pri_objPrevCellValue = Val(Me.dgvDATA.CurrentCell.Value)

        Catch ex As Exception
            EM.ErrorSyori(ex, False, conblnNonMsg)
        End Try
    End Sub

    'セル編集完了イベント
    Private Sub DgvDATA_CellEndEdit(sender As Object, e As DataGridViewCellEventArgs)
        Try
            If Me.dgvDATA.CurrentCell.Value Is DBNull.Value Then
                Me.dgvDATA.CurrentCell.Value = 0
            End If

            Dim intEditedCellValue As Integer
            intEditedCellValue = Val(Me.dgvDATA.CurrentCell.Value)

            If pri_objPrevCellValue <> intEditedCellValue Then
                'カレントセル書式変更
                Me.dgvDATA.CurrentCell.Style.ForeColor = clrEditedCellForeColor
                Me.dgvDATA.CurrentCell.Style.SelectionForeColor = clrEditedCellForeColor

                Dim strBUFF As String
                Select Case Me.dgvDATA.Columns(e.ColumnIndex).Name
                    Case "NAIJI_SU_N"
                        strBUFF = "N"
                    Case "NAIJI_SU_N_PLUS1"
                        strBUFF = "O"
                    Case "NAIJI_SU_N_PLUS2"
                        strBUFF = "P"
                    Case Else
                        '対象外
                        Exit Sub
                End Select

                Me.dgvDATA.CurrentRow.Cells("MODIFIED_STATUS").Value &= strBUFF

                Me.pri_blnUpdateCellValue = True
            End If

        Catch ex As Exception
            EM.ErrorSyori(ex, False, conblnNonMsg)
        Finally
            'ファンクションキー有効化初期化
            Call FunInitFuncButtonEnabled(Me)
        End Try
    End Sub

#Region "編集可能セルOnMouse時カーソル変更"
    Private Sub Dgv_CellMouseMove(sender As Object, e As DataGridViewCellMouseEventArgs)
        Dim dgv As DataGridView = DirectCast(sender, DataGridView)
        If e.RowIndex >= 0 AndAlso dgv(e.ColumnIndex, e.RowIndex).ReadOnly = False Then
            Select Case dgv.Columns(e.ColumnIndex).Name
                Case "NAIJI_SU_N", "NAIJI_SU_N_PLUS1", "NAIJI_SU_N_PLUS2"
                    dgv.Cursor = Cursors.IBeam
                Case Else
                    dgv.Cursor = Cursors.Default
            End Select
        End If
    End Sub

    Private Sub Dgv_CellMouseLeave(sender As Object, e As DataGridViewCellEventArgs)
        Dim dgv As DataGridView = DirectCast(sender, DataGridView)
        dgv.Cursor = Cursors.Default
    End Sub

#End Region

#Region "入力制限"
    'EditingControlShowingイベント
    Private Sub DataGridView1_EditingControlShowing(ByVal sender As Object, ByVal e As DataGridViewEditingControlShowingEventArgs)
        '表示されているコントロールがDataGridViewTextBoxEditingControlか調べる
        If TypeOf e.Control Is DataGridViewTextBoxEditingControl Then
            Dim dgv As DataGridView = CType(sender, DataGridView)

            '編集のために表示されているコントロールを取得
            Dim tb As DataGridViewTextBoxEditingControl =
                CType(e.Control, DataGridViewTextBoxEditingControl)

            'イベントハンドラを削除
            RemoveHandler tb.KeyPress, AddressOf DataGridViewTextBox_KeyPress

            '該当する列か調べる
            Select Case dgv.CurrentCell.OwningColumn.Name
                Case "NAIJI_SU_N", "NAIJI_SU_N_PLUS1", "NAIJI_SU_N_PLUS2"
                    'KeyPressイベントハンドラを追加
                    AddHandler tb.KeyPress, AddressOf DataGridViewTextBox_KeyPress
                Case Else
                    '
            End Select
        End If
    End Sub

    'DataGridViewに表示されているテキストボックスのKeyPressイベントハンドラ
    Private Sub DataGridViewTextBox_KeyPress(ByVal sender As Object, ByVal e As KeyPressEventArgs)
        '数字(+BACKSPACE)しか入力できないようにする
        If (e.KeyChar < "0"c Or e.KeyChar > "9"c) AndAlso e.KeyChar <> ControlChars.Back Then
            e.Handled = True
        End If
    End Sub

#End Region

#End Region

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
                    If FunblnHasUnappliedData(sender) = True Then
                        Call FunSRCH()
                    End If

                Case 4  '更新
                    '[処理中]
                    MyBase.PrPG_STATUS = ENM_PG_STATUS._3_PROCESSING

                    If FunUpd() = True Then
                        Call FunSRCH()
                    End If
                Case 7  '出荷計画
                    '[処理中]
                    MyBase.PrPG_STATUS = ENM_PG_STATUS._3_PROCESSING

                    Call FunOpenAppSyuKkaKeikaku()

                Case 8  '3ヶ月内示レポート出力
                    '[処理中]
                    MyBase.PrPG_STATUS = ENM_PG_STATUS._3_PROCESSING

                    Call FunOpenReportNaiji()

                Case 9  '工程不可一覧出力
                    '[処理中]
                    MyBase.PrPG_STATUS = ENM_PG_STATUS._3_PROCESSING

                    Call FunOpenReportKoteiFuka()

                Case 10  'CSV出力
                    '[処理中]
                    MyBase.PrPG_STATUS = ENM_PG_STATUS._3_PROCESSING

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
            MyBase.PrPG_STATUS = ENM_PG_STATUS._2_ACTIVE

        End Try

    End Sub

#End Region

#Region "検索"
    Private Function FunSRCH() As Boolean
        Dim dsList As New System.Data.DataSet
        Dim sbSQL As New System.Text.StringBuilder
        Dim sbSQLWHERE As New System.Text.StringBuilder
        Dim waitDlg As WaitDialog = Nothing
        Dim lngCURROW As Long = 0

        Try
            '変更
            Me.pri_blnUpdateCellValue = False

            Dim dtYM_N As Date
            If DateTime.TryParseExact(Me.dtYM.Text & "01", "yyyy/MMdd", Nothing, Nothing, dtYM_N) = True Then
                '列名設定
                Me.dgvDATA.Columns("NAIJI_SU_N").HeaderText = String.Format("{0}内示", dtYM_N.ToString("yyyy年MM月"))
                Me.dgvDATA.Columns("NAIJI_SU_N_PLUS1").HeaderText = String.Format("{0}内示", dtYM_N.AddMonths(1).ToString("yyyy年MM月"))
                Me.dgvDATA.Columns("NAIJI_SU_N_PLUS2").HeaderText = String.Format("{0}内示", dtYM_N.AddMonths(2).ToString("yyyy年MM月"))
            End If

            '-----選択行記憶
            If dgvDATA.RowCount > 0 Then
                lngCURROW = dgvDATA.CurrentRow.Index
            End If

            '検索時入力チェック
            If FunCheckSrchInput() = False Then
                Return False
            End If

            Me.dgvDATA.DataSource = Nothing


            'WHERE句作成----
            sbSQLWHERE.Remove(0, sbSQLWHERE.Length)
            sbSQLWHERE.Append(" WHERE TOKUI_CD = " & Me.cmbMonthRange.SelectedValue & " ")
            sbSQLWHERE.Append(" AND (")
            sbSQLWHERE.Append(" (YM >= '" & Me.dtYM.ValueNonFormat & "' ")
            sbSQLWHERE.Append(" AND YM <= '" & DateTime.ParseExact(Me.dtYM.Value, "yyyy/MM/dd", Nothing).AddMonths(2).ToString("yyyyMM") & "') ")
            sbSQLWHERE.Append(" OR YM IS NULL ")
            sbSQLWHERE.Append(" )")

            Using DB As ClsDbUtility = DBOpen()
                sbSQL.Remove(0, sbSQL.Length)
                sbSQL.Append("SELECT *")
                sbSQL.Append(" FROM " & Context.CON_V_V01_NAIJI & " ")
                sbSQL.Append(sbSQLWHERE)
                sbSQL.Append(" ORDER BY SEIHIN_CD")
                dsList = DB.GetDataSet(sbSQL.ToString, conblnNonMsg)
            End Using

            If dsList.Tables(0).Rows.Count > pub_APP_INFO.intSEARCHMAX Then

                If MessageBox.Show(My.Resources.infoSearchCountOver, "", MessageBoxButtons.YesNo, MessageBoxIcon.Information) = Windows.Forms.DialogResult.No Then
                    Return False
                End If
            ElseIf dsList.Tables(0).Rows.Count = 0 Then
                Me.lblRecordCount.Text = My.Resources.infoSearchResultNotFound
                Return False
            End If

            '-----進行状況ダイアログ
            waitDlg = New WaitDialog()
            With waitDlg
                .Owner = Me
                .MainMsg = My.Resources.infoMsgProgressStatus
                .ProgressMax = dsList.Tables(0).Rows.Count  ' 全体の処理件数
                .ProgressMin = 0 ' 処理件数の最小値（0件から開始）
                .ProgressStep = 1 ' 何件ごとにメーターを進めるか
                .ProgressValue = 0 ' 最初の件数
                .SubMsg = ""
                .ProgressMsg = My.Resources.infoToolTipMsgSearching
                '表示
                waitDlg.Show()
            End With

            Application.DoEvents()

            '-----一覧不可視
            Me.dgvDATA.Visible = False

            Dim dt As New DataTable
            dt.Columns.Add("YM", GetType(String))
            dt.Columns.Add("SEIHIN_CD", GetType(Integer))
            dt.Columns.Add("DANMEN_NAME", GetType(String))
            dt.Columns.Add("HINBAN", GetType(String))
            dt.Columns.Add("SEBAN", GetType(String))
            dt.Columns.Add("NAIJI_SU_N", GetType(Integer))
            dt.Columns.Add("NAIJI_SU_N_PLUS1", GetType(Integer))
            dt.Columns.Add("NAIJI_SU_N_PLUS2", GetType(Integer))
            dt.Columns.Add("ADD_YMDHNS", GetType(String))
            dt.Columns.Add("EDIT_YMDHNS", GetType(String))
            dt.Columns.Add("SYAIN_ID", GetType(Integer))
            dt.Columns.Add("MODIFIED_STATUS", GetType(String))

            'dtYM_N = DateTime.ParseExact(Me.dtYM.Value, "yyyy/MM/dd", Nothing)

            With dsList.Tables(0)
                For intCNT As Integer = 0 To .Rows.Count - 1
                    Dim intSEIHIN_CD As Integer = .Rows(intCNT).Item("SEIHIN_CD")

                    Dim row As DataRow = dt.AsEnumerable().
                                    Where(Function(r) r.Field(Of Integer)("SEIHIN_CD") = intSEIHIN_CD).FirstOrDefault

                    If row IsNot Nothing Then
                        Select Case DateTime.ParseExact(.Rows(intCNT).Item("YM") & "01", "yyyyMMdd", Nothing)
                            Case dtYM_N
                                row.Item("NAIJI_SU_N") = .Rows(intCNT).Item("NAIJI_SU")
                            Case dtYM_N.AddMonths(1)
                                row.Item("NAIJI_SU_N_PLUS1") = .Rows(intCNT).Item("NAIJI_SU")
                            Case dtYM_N.AddMonths(2)
                                row.Item("NAIJI_SU_N_PLUS2") = .Rows(intCNT).Item("NAIJI_SU")
                            Case Else
                                Throw New ArgumentException(My.Resources.ErrMsgException, .Rows(intCNT).Item("YM").ToString)
                        End Select
                        row.AcceptChanges()
                    Else
                        Dim Trow As DataRow = dt.NewRow()
                        If IsDBNull(.Rows(intCNT).Item("YM")) Then
                            Trow("YM") = Me.dtYM.ValueNonFormat
                        Else
                            Trow("YM") = .Rows(intCNT).Item("YM")
                        End If
                        Trow("SEIHIN_CD") = .Rows(intCNT).Item("SEIHIN_CD")
                        Trow("DANMEN_NAME") = .Rows(intCNT).Item("DANMEN_NAME")
                        Trow("HINBAN") = .Rows(intCNT).Item("HINBAN")
                        Trow("SEBAN") = .Rows(intCNT).Item("SEBAN")
                        Select Case DateTime.ParseExact(Trow("YM") & "01", "yyyyMMdd", Nothing)
                            Case dtYM_N
                                Trow("NAIJI_SU_N") = .Rows(intCNT).Item("NAIJI_SU")
                                Trow("NAIJI_SU_N_PLUS1") = 0
                                Trow("NAIJI_SU_N_PLUS2") = 0
                            Case dtYM_N.AddMonths(1)
                                Trow("NAIJI_SU_N") = 0
                                Trow("NAIJI_SU_N_PLUS1") = .Rows(intCNT).Item("NAIJI_SU")
                                Trow("NAIJI_SU_N_PLUS2") = 0
                            Case dtYM_N.AddMonths(2)
                                Trow("NAIJI_SU_N") = 0
                                Trow("NAIJI_SU_N_PLUS1") = 0
                                Trow("NAIJI_SU_N_PLUS2") = .Rows(intCNT).Item("NAIJI_SU")
                            Case Else
                                Throw New ArgumentException(My.Resources.ErrMsgException, .Rows(intCNT).Item("NAIJI_SU").ToString)
                        End Select
                        Trow("ADD_YMDHNS") = .Rows(intCNT).Item("ADD_YMDHNS")
                        Trow("EDIT_YMDHNS") = .Rows(intCNT).Item("EDIT_YMDHNS")
                        Trow("SYAIN_ID") = pub_SYAIN_INFO.SYAIN_ID
                        Trow("MODIFIED_STATUS") = ""
                        dt.Rows.Add(Trow)
                    End If

                    '-----進行状況ダイアログ
                    '処理中止かどうかをチェック
                    If waitDlg.IsAborting = True Then
                        Exit For
                    End If
                    If intCNT Mod 10 = 0 Then
                        waitDlg.SubMsg = ""
                        waitDlg.ProgressMsg = (intCNT + 1) & "/" & .Rows.Count '進行状況ダイアログのメーターを設定
                        waitDlg.ProgressValue = intCNT ' 処理カウントを1ステップ進める
                        Application.DoEvents()
                    End If
                Next intCNT
                dt.AcceptChanges()
            End With

            '
            Me.dgvDATA.DataSource = dt

            If Me.dgvDATA.RowCount > 0 Then
                '-----選択行設定
                Try
                    Me.dgvDATA.CurrentCell = Me.dgvDATA.Rows(lngCURROW).Cells(2)
                Catch dgvEx As Exception
                End Try

                Me.lblRecordCount.Text = String.Format(My.Resources.infoToolTipMsgFoundData, Me.dgvDATA.RowCount.ToString)  '.PadLeft(5)
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
            dsList.Dispose()

            '-----一覧可視
            Me.dgvDATA.Visible = True
        End Try
    End Function

    ''' <summary>
    ''' 検索時入力チェック
    ''' </summary>
    ''' <returns></returns>
    Private Function FunCheckSrchInput() As Boolean
        Try

            '年月
            If Me.dtYM.Value = "" Then
                MessageBox.Show(String.Format(My.Resources.infoMsgRequireInput, "年月"), My.Resources.infoTitleInputCheck, MessageBoxButtons.OK, MessageBoxIcon.Information)
                Me.dtYM.Focus()
                Return False
            End If

            '得意先
            If Me.cmbMonthRange.SelectedValue = "" Then
                MessageBox.Show(String.Format(My.Resources.infoMsgRequireSelect, "得意先"), My.Resources.infoTitleInputCheck, MessageBoxButtons.OK, MessageBoxIcon.Information)
                Me.cmbMonthRange.Focus()
                Return False
            End If

            Return True
        Catch ex As Exception
            EM.ErrorSyori(ex, False, conblnNonMsg)
            Return False
        End Try
    End Function

#End Region

#Region "更新"
    Private Function FunUpd() As Boolean
        Dim blnErr As Boolean
        Dim strYM As String
        Dim strNaijiField As String

        Try
            Using DB As ClsDbUtility = DBOpen()
                Try
                    DB.BeginTransaction()

                    Dim dt As DataTable = DirectCast(Me.dgvDATA.DataSource, DataTable)
                    Dim rows = dt.AsEnumerable().
                                    Where(Function(row) row.RowState = DataRowState.Modified)
                    For Each row As DataRow In rows

                        If row.Item("MODIFIED_STATUS").ToString.Contains("N") = True Then
                            strYM = Me.dtYM.ValueNonFormat 'row.Item("YM")
                            strNaijiField = "NAIJI_SU_N"
                            If FunExecMergeSql(DB, row, strYM, strNaijiField) = False Then
                                blnErr = True
                                Return False
                            End If
                        End If
                        If row.Item("MODIFIED_STATUS").ToString.Contains("O") = True Then
                            strYM = DateTime.ParseExact(Me.dtYM.ValueNonFormat & "01", "yyyyMMdd", Nothing).AddMonths(1).ToString("yyyyMM")
                            strNaijiField = "NAIJI_SU_N_PLUS1"
                            If FunExecMergeSql(DB, row, strYM, strNaijiField) = False Then
                                blnErr = True
                                Return False
                            End If
                        End If
                        If row.Item("MODIFIED_STATUS").ToString.Contains("P") = True Then
                            strYM = DateTime.ParseExact(Me.dtYM.ValueNonFormat & "01", "yyyyMMdd", Nothing).AddMonths(2).ToString("yyyyMM")
                            strNaijiField = "NAIJI_SU_N_PLUS2"
                            If FunExecMergeSql(DB, row, strYM, strNaijiField) = False Then
                                blnErr = True
                                Return False
                            End If
                        End If
                    Next row

                Finally
                    DB.Commit(Not blnErr)
                End Try
            End Using

            Me.pri_blnUpdateCellValue = False

            Return True
        Catch ex As Exception
            EM.ErrorSyori(ex, False, conblnNonMsg)
            Return False
        End Try
    End Function

    Private Function FunExecMergeSql(ByRef DB As ClsDbUtility, ByVal row As DataRow, ByVal strYM As String, ByVal strNaijiField As String) As Boolean
        Dim sbSQL As New System.Text.StringBuilder
        Dim intRET As Integer
        Dim sqlEx As New Exception
        Try

            sbSQL.Remove(0, sbSQL.Length)
            sbSQL.Append("MERGE INTO " & Context.CON_T_J01_NAIJI & " AS SrcT")
            sbSQL.Append(" USING (")
            sbSQL.Append(" SELECT")
            'YM
            sbSQL.Append(" '" & strYM & "' AS YM")
            'SEIHIN_CD
            sbSQL.Append(" ," & Val(row.Item("SEIHIN_CD")) & " AS SEIHIN_CD")
            'NAIJI_SU
            sbSQL.Append(" ," & Val(row.Item(strNaijiField)) & " AS NAIJI_SU")
            'ADD_YMDHNS
            sbSQL.Append(" ,dbo.GetSysDateString() AS ADD_YMDHNS")
            'EDIT_YMDHNS
            sbSQL.Append(" ,dbo.GetSysDateString() AS EDIT_YMDHNS")
            'SYAIN_ID
            sbSQL.Append(" ," & pub_SYAIN_INFO.SYAIN_ID & " AS SYAIN_ID")
            sbSQL.Append(" ) AS WK")
            sbSQL.Append(" ON (SrcT.YM = WK.YM And SrcT.SEIHIN_CD = WK.SEIHIN_CD)")
            sbSQL.Append(" WHEN MATCHED AND WK.NAIJI_SU = 0 THEN ")
            sbSQL.Append(" DELETE ")
            sbSQL.Append(" WHEN MATCHED THEN ")
            sbSQL.Append(" UPDATE ")
            sbSQL.Append(" SET SrcT.NAIJI_SU = WK.NAIJI_SU")
            sbSQL.Append(" ,SrcT.EDIT_YMDHNS = WK.EDIT_YMDHNS")
            sbSQL.Append(" ,SYAIN_ID = WK.SYAIN_ID")
            sbSQL.Append(" WHEN NOT MATCHED THEN ")
            sbSQL.Append(" INSERT(YM, SEIHIN_CD, NAIJI_SU, ADD_YMDHNS, EDIT_YMDHNS, SYAIN_ID) ")
            sbSQL.Append(" VALUES(WK.YM, WK.SEIHIN_CD, WK.NAIJI_SU, WK.ADD_YMDHNS, WK.EDIT_YMDHNS, WK.SYAIN_ID);")

            intRET = DB.ExecuteNonQuery(sbSQL.ToString, conblnNonMsg, sqlEx)
            If intRET <> 1 Then
                'エラーログ出力
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

#Region "3ヶ月内示レポート表示"

    Private Function FunOpenReportNaiji() As Boolean
        Dim strOutputFileName As String
        Dim strTEMPFILE As String

        Try


            'ファイル名
            strOutputFileName = "3ヶ月内示レポート_" & DateTime.ParseExact(Me.dtYM.Value, "yyyy/MM/dd", Nothing).ToString("yyyy年MM月") & ".xlsx"

            '既存ファイル削除
            If FunDELETE_FILE(pub_APP_INFO.strOUTPUT_PATH & strOutputFileName) = False Then
                Return False
            End If

            Using iniIF As New IniFile(FunGetRootPath() & "\INI\" & CON_TEMPLATE_INI)
                strTEMPFILE = FunConvRootPath(iniIF.GetIniString("内示", "FILEPATH"))
            End Using

            'エクセル出力ファイル用意
            If OUT_EXCEL_READY(strTEMPFILE, pub_APP_INFO.strOUTPUT_PATH, strOutputFileName) = False Then
                Return False
            End If
            '-----書込処理
            If FunMakeReportNaiji(pub_APP_INFO.strOUTPUT_PATH & strOutputFileName) = False Then
                Return False
            End If

            'Excel起動
            Return FunOpenExcelApp(pub_APP_INFO.strOUTPUT_PATH & strOutputFileName)

        Catch ex As Exception
            EM.ErrorSyori(ex, False, conblnNonMsg)
            Return False
        Finally

        End Try
    End Function

    Private Function FunMakeReportNaiji(strFilePath As String) As Boolean
        Dim dsList As New DataSet
        Dim sbSQL As New System.Text.StringBuilder

        Dim intCurrentRowIndex As Integer = 10
        Dim strRange As String

        Dim spWorkbook As SpreadsheetGear.IWorkbook
        Dim spWorksheets As SpreadsheetGear.IWorksheets
        Dim spSheet1 As SpreadsheetGear.IWorksheet
        Dim spWork As SpreadsheetGear.IWorksheet
        Dim spRangeFrom As SpreadsheetGear.IRange
        Dim spRangeTo As SpreadsheetGear.IRange

        Try
            spWorkbook = SpreadsheetGear.Factory.GetWorkbook(strFilePath, System.Globalization.CultureInfo.CurrentCulture)

            spWorkbook.WorkbookSet.GetLock()
            spWorksheets = spWorkbook.Worksheets
            spSheet1 = spWorksheets.Item(0) 'sheet1
            spWork = spWorksheets.Item(1) 'Work

            '
            sbSQL.Remove(0, sbSQL.Length)
            sbSQL.Append("SELECT * FROM " & Context.CON_S_TB06_SIIRE_NAIJI_ICHIRAN & "('" & Me.dtYM.ValueNonFormat & "','" & Me.cmbMonthRange.SelectedValue & "')")
            sbSQL.Append(" ORDER BY MAKER_NAME,HINMEI,YM")

            Using DB As ClsDbUtility = DBOpen()
                dsList = DB.GetDataSet(sbSQL.ToString)
            End Using

            Dim dt As New DataTable
            dt.Columns.Add("YM", GetType(String))
            dt.Columns.Add("MAKER_CD", GetType(String))
            dt.Columns.Add("MAKER_NAME", GetType(String))
            dt.Columns.Add("ZAIRYO_CD", GetType(Integer))
            dt.Columns.Add("ZAIRYO_NAME", GetType(String))
            dt.Columns.Add("NAIJI_SU_N", GetType(Integer))
            dt.Columns.Add("NAIJI_SU_N_PLUS1", GetType(Integer))
            dt.Columns.Add("NAIJI_SU_N_PLUS2", GetType(Integer))

            With dsList.Tables(0)
                For i As Integer = 0 To .Rows.Count - 1
                    Dim dtYM_N As Date = Me.dtYM.ValueDate
                    Dim strMakerCD As String = .Rows(i).Item("MAKER_CD")
                    Dim intZairyoCD As Integer = .Rows(i).Item("ZAIRYO_CD")
                    Dim row As DataRow = dt.AsEnumerable().
                                            Where(Function(r) r.Field(Of String)("MAKER_CD") = strMakerCD And r.Field(Of Integer)("ZAIRYO_CD") = intZairyoCD).FirstOrDefault

                    If row IsNot Nothing Then
                        Select Case DateTime.ParseExact(.Rows(i).Item("YM") & "01", "yyyyMMdd", Nothing)
                            Case dtYM_N
                                row.Item("NAIJI_SU_N") = .Rows(i).Item("NAIJI_SU")
                            Case dtYM_N.AddMonths(1)
                                row.Item("NAIJI_SU_N_PLUS1") = .Rows(i).Item("NAIJI_SU")
                            Case dtYM_N.AddMonths(2)
                                row.Item("NAIJI_SU_N_PLUS2") = .Rows(i).Item("NAIJI_SU")
                            Case Else
                                '----yyyyMMddもいれるか
                                Throw New ArgumentException(My.Resources.ErrMsgException, .Rows(i).Item("YM").ToString)
                        End Select
                        row.AcceptChanges()
                    Else
                        Dim Trow As DataRow = dt.NewRow()
                        Trow("YM") = .Rows(i).Item("YM")
                        Trow("MAKER_CD") = .Rows(i).Item("MAKER_CD")
                        Trow("MAKER_NAME") = .Rows(i).Item("MAKER_NAME")
                        Trow("ZAIRYO_CD") = .Rows(i).Item("ZAIRYO_CD")
                        Trow("ZAIRYO_NAME") = .Rows(i).Item("HINMEI")
                        Select Case DateTime.ParseExact(.Rows(i).Item("YM") & "01", "yyyyMMdd", Nothing)
                            Case dtYM_N
                                Trow("NAIJI_SU_N") = .Rows(i).Item("NAIJI_SU")
                            Case dtYM_N.AddMonths(1)
                                Trow("NAIJI_SU_N_PLUS1") = .Rows(i).Item("NAIJI_SU")
                            Case dtYM_N.AddMonths(2)
                                Trow("NAIJI_SU_N_PLUS2") = .Rows(i).Item("NAIJI_SU")
                            Case Else
                                Throw New ArgumentException(My.Resources.ErrMsgException, .Rows(i).Item("YM").ToString)
                        End Select
                        dt.Rows.Add(Trow)
                    End If
                Next i
                dt.AcceptChanges()
            End With

            For i As Integer = 0 To dt.Rows.Count - 1
                'レコードフレーム初期化
                spWork.Range("RECORD_FRAME").ClearContents()

                spWork.Range("MAKER_NAME").Value = dt.Rows(i).Item("MAKER_NAME")
                spWork.Range("ZAIRYO_NAME").Value = dt.Rows(i).Item("ZAIRYO_NAME")
                spWork.Range("NAIJI_SU_N").Value = Nz(dt.Rows(i).Item("NAIJI_SU_N"), 0)
                spWork.Range("NAIJI_SU_N_PLUS1").Value = Nz(dt.Rows(i).Item("NAIJI_SU_N_PLUS1"), 0)
                spWork.Range("NAIJI_SU_N_PLUS2").Value = Nz(dt.Rows(i).Item("NAIJI_SU_N_PLUS2"), 0)

                '-----レコードフレームを本シートにコピー
                strRange = String.Format("A{0}:E{1}", intCurrentRowIndex, intCurrentRowIndex + 1)
                spRangeFrom = spWork.Cells("A3:E3").EntireRow
                spRangeTo = spSheet1.Cells(strRange).EntireRow
                spRangeFrom.Copy(spRangeTo, SpreadsheetGear.PasteType.All, SpreadsheetGear.PasteOperation.None, False, False)

                'カレント行を更新
                intCurrentRowIndex += 1
            Next i

            'ヘッダ更新
            spSheet1.Range("YM").Value = Me.dtYM.Value
            Using DB As ClsDbUtility = DBOpen()
                Dim dtCompany As New DataTableEx
                Call FunGetCodeDataTable(DB, "自社情報", dtCompany)
                spSheet1.Range("SYAMEI").Value = dtCompany.Rows(0).Item("TORI_NAME") & " 業務部"
                spSheet1.Range("JYUSYO").Value = dtCompany.Rows(0).Item("JYUSYO1")
                spSheet1.Range("TEL").Value = "TEL " & dtCompany.Rows(0).Item("TEL")
                spSheet1.Range("FAX").Value = "FAX " & dtCompany.Rows(0).Item("FAX")
            End Using


            'フッタ更新

            spWork.Range("SUM_NAIJI_SU_N").Formula = "=SUM($C$10:$C$" & (intCurrentRowIndex - 1) & ")"
            spWork.Range("SUM_NAIJI_SU_N_PLUS1").Formula = "=SUM($D$10:$D$" & (intCurrentRowIndex - 1) & ")"
            spWork.Range("SUM_NAIJI_SU_N_PLUS2").Formula = "=SUM($E$10:$E$" & (intCurrentRowIndex - 1) & ")"
            spRangeFrom = spWork.Cells("A8:E8").EntireRow
            spRangeTo = spSheet1.Cells(String.Format("A{0}:E{1}", intCurrentRowIndex, intCurrentRowIndex)).EntireRow
            spRangeFrom.Copy(spRangeTo, SpreadsheetGear.PasteType.All, SpreadsheetGear.PasteOperation.None, False, False)

            '印刷範囲指定
            spSheet1.PageSetup.PrintArea = spSheet1.Name & "!$A$1:$E$" & (intCurrentRowIndex)
            '印刷タイトル行
            spSheet1.PageSetup.PrintTitleRows = spSheet1.Name & "!$1:$9"

            '-----ファイル保存
            spWork.Delete()
            spWorksheets(0).Cells("A1").Select()
            spSheet1.SaveAs(filename:=strFilePath, fileFormat:=SpreadsheetGear.FileFormat.OpenXMLWorkbook)
            spWorkbook.WorkbookSet.ReleaseLock()

            Return True

        Catch ex As Exception
            EM.ErrorSyori(ex, False, conblnNonMsg)
            Return False
        Finally
            spRangeFrom = Nothing
            spRangeTo = Nothing
            spSheet1 = Nothing
            spWork = Nothing
            spWorksheets = Nothing
            spWorkbook = Nothing
        End Try
    End Function

#End Region

#Region "工程負荷一覧表示"
    Private Function FunOpenReportKoteiFuka() As Boolean
        Dim strOutputFileName As String
        Dim strTEMPFILE As String
        'Dim intRET As Integer

        Try


            'ファイル名
            strOutputFileName = "工程負荷一覧_" & DateTime.ParseExact(Me.dtYM.Value, "yyyy/MM/dd", Nothing).ToString("yyyy年MM月") & ".xlsx"

            '既存ファイル削除
            If FunDELETE_FILE(pub_APP_INFO.strOUTPUT_PATH & strOutputFileName) = False Then
                Return False
            End If

            Using iniIF As New IniFile(FunGetRootPath() & "\INI\" & CON_TEMPLATE_INI)
                strTEMPFILE = FunConvRootPath(iniIF.GetIniString("工程負荷", "FILEPATH"))
            End Using

            Using DB As ClsDbUtility = DBOpen()
                Call FunGetCodeDataTable(DB, "工程種別", tblKOTEI_SYUBETU)
            End Using

            'エクセル出力ファイル用意
            If OUT_EXCEL_READY(strTEMPFILE, pub_APP_INFO.strOUTPUT_PATH, strOutputFileName) = False Then
                Return False
            End If
            '-----書込処理
            For i As Integer = 0 To tblKOTEI_SYUBETU.Rows.Count - 1
                If FunMakeReportKoteiFuka(Me.dtYM.ValueDate.ToString("yyyyMM"), tblKOTEI_SYUBETU.Rows(i).Item("VALUE"), pub_APP_INFO.strOUTPUT_PATH & strOutputFileName) = False Then
                    Return False
                End If
            Next i

            'Excel起動
            Return FunOpenExcelApp(pub_APP_INFO.strOUTPUT_PATH & strOutputFileName)

        Catch ex As Exception
            EM.ErrorSyori(ex, False, conblnNonMsg)
            Return False
        Finally

        End Try
    End Function

    Private Function FunMakeReportKoteiFuka(ByVal strYM As String, ByVal strKOTEI_SYUBETU As String, ByVal strFilePath As String) As Boolean
        Dim dsList As New DataSet
        Dim sbSQL As New System.Text.StringBuilder

        Dim intCurrentRowIndex As Integer = 7
        Dim intKOTEI_TopRowIndex As Integer = 7
        Dim strRange As String

        Dim spWorkbook As SpreadsheetGear.IWorkbook
        Dim spWorksheets As SpreadsheetGear.IWorksheets
        Dim spSheet1 As SpreadsheetGear.IWorksheet
        Dim spSheetMain As SpreadsheetGear.IWorksheet
        Dim spWork As SpreadsheetGear.IWorksheet
        Dim spRangeFrom As SpreadsheetGear.IRange
        Dim spRangeTo As SpreadsheetGear.IRange

        Try
            '
            sbSQL.Remove(0, sbSQL.Length)
            sbSQL.Append("SELECT * FROM " & Context.CON_S_TB04_KOTEI_FUKA_ICHIRAN & "('" & Me.dtYM.ValueNonFormat & "','" & strKOTEI_SYUBETU & "')")
            sbSQL.Append(" ORDER BY KOTEI_R_NAME,DANMEN_NAME")

            Using DB As ClsDbUtility = DBOpen()
                dsList = DB.GetDataSet(sbSQL.ToString)
            End Using

            With dsList.Tables(0)
                If .Rows.Count = 0 Then
                    Return True
                End If

                spWorkbook = SpreadsheetGear.Factory.GetWorkbook(strFilePath, System.Globalization.CultureInfo.CurrentCulture)

                spWorkbook.WorkbookSet.GetLock()
                spWorksheets = spWorkbook.Worksheets
                spSheet1 = spWorksheets.Item("sheet1") 'sheet1
                spSheet1.Visible = SpreadsheetGear.SheetVisibility.Visible
                spWork = spWorksheets.Item("Work") 'Work
                spWork.Visible = SpreadsheetGear.SheetVisibility.Visible
                spSheetMain = spSheet1.CopyBefore(spWork)


                For i As Integer = 0 To .Rows.Count - 1
                    If spWork.Range("KOTEI").Value <> "" And spWork.Range("KOTEI").Value <> .Rows(i).Item("KOTEI_R_NAME") Then
                        '-----フッタ更新
                        spWork.Range("SUM_LABEL").Value = "小　　　　　　計"
                        If .Rows(0).Item("SEISAN_KEISU") > 0 Then
                            spWork.Range("SEISAN_KEISU").Value = String.Format("稼働率{0}%基準ライン負荷", CDec(100 / .Rows(0).Item("SEISAN_KEISU")).RoundingToSpecifiedLength(0))
                        End If
                        spWork.Range("SUM_JUCHU_N").Formula = "=SUM($D$7:$D$" & (intCurrentRowIndex - 1) & ")"
                        spWork.Range("SUM_TIME_N").Formula = "=SUM($E$7:$E$" & (intCurrentRowIndex - 1) & ")"
                        spWork.Range("SUM_JUCHU_N_PLUS1").Formula = "=SUM($F$7:$F$" & (intCurrentRowIndex - 1) & ")"
                        spWork.Range("SUM_TIME_N_PLUS1").Formula = "=SUM($G$7:$G$" & (intCurrentRowIndex - 1) & ")"
                        spWork.Range("SUM_JUCHU_N_PLUS2").Formula = "=SUM($H$7:$H$" & (intCurrentRowIndex - 1) & ")"
                        spWork.Range("SUM_TIME_N_PLUS2").Formula = "=SUM($I$7:$I$" & (intCurrentRowIndex - 1) & ")"

                        spRangeFrom = spWork.Cells("B7:I8") '.EntireRow
                        spRangeTo = spSheetMain.Cells(String.Format("B{0}:I{1}", intCurrentRowIndex, intCurrentRowIndex)) '.EntireRow
                        spRangeFrom.Copy(spRangeTo, SpreadsheetGear.PasteType.All, SpreadsheetGear.PasteOperation.None, False, False)

                        'カレント行を更新
                        intCurrentRowIndex += 2
                        '工程列結合
                        If intKOTEI_TopRowIndex <> intCurrentRowIndex - 1 Then
                            spSheetMain.Cells(String.Format("A{0}:A{1}", intKOTEI_TopRowIndex, intCurrentRowIndex - 1)).Merge()
                        End If
                        spSheetMain.Cells(String.Format("A{0}:A{1}", intKOTEI_TopRowIndex, intCurrentRowIndex - 1)).Orientation = SpreadsheetGear.Orientation.Vertical

                        '次の工程の開始行を更新
                        intKOTEI_TopRowIndex = intCurrentRowIndex

                        'フッタをクリア
                        spWork.Range("B7:I8").ClearContents()
                    Else
                        'レコードフレーム初期化
                        spWork.Range("RECORD_FRAME").ClearContents()
                    End If

                    spWork.Range("KOTEI").Value = .Rows(i).Item("KOTEI_R_NAME")
                    spWork.Range("KATABAN").Value = .Rows(i).Item("HINBAN")
                    spWork.Range("SPEED").Value = .Rows(i).Item("NORYOKU") 'UNDONE: 能力単位を揃える計算
                    spWork.Range("JUCHU_N").Value = .Rows(i).Item("JUCHU_RYOU_N")
                    spWork.Range("TIME_N").Value = .Rows(i).Item("KADO_JIKAN_N")
                    spWork.Range("JUCHU_N_PLUS1").Value = .Rows(i).Item("JUCHU_RYOU_N1")
                    spWork.Range("TIME_N_PLUS1").Value = .Rows(i).Item("KADO_JIKAN_N1")
                    spWork.Range("JUCHU_N_PLUS2").Value = .Rows(i).Item("JUCHU_RYOU_N2")
                    spWork.Range("TIME_N_PLUS2").Value = .Rows(i).Item("KADO_JIKAN_N2")

                    '-----レコードフレームを本シートにコピー
                    strRange = String.Format("A{0}:I{1}", intCurrentRowIndex, intCurrentRowIndex)
                    spRangeFrom = spWork.Cells("RECORD_FRAME").EntireRow
                    spRangeTo = spSheetMain.Cells(strRange).EntireRow
                    spRangeFrom.Copy(spRangeTo, SpreadsheetGear.PasteType.All, SpreadsheetGear.PasteOperation.None, False, False)

                    'カレント行を更新
                    intCurrentRowIndex += 1
                Next i


                '工程列結合
                If intKOTEI_TopRowIndex <> intCurrentRowIndex Then
                    spSheetMain.Cells(String.Format("A{0}:A{1}", intKOTEI_TopRowIndex, intCurrentRowIndex)).Merge()
                    spSheetMain.Cells(String.Format("A{0}:A{1}", intKOTEI_TopRowIndex, intCurrentRowIndex)).ShrinkToFit = True
                End If
                spSheetMain.Cells(String.Format("A{0}:A{1}", intKOTEI_TopRowIndex, intCurrentRowIndex)).Orientation = SpreadsheetGear.Orientation.Vertical

                '-----フッタ更新
                spWork.Range("SUM_LABEL").Value = "小　　　　　　計"
                If .Rows(0).Item("SEISAN_KEISU") > 0 Then
                    spWork.Range("SEISAN_KEISU").Value = String.Format("稼働率{0}%基準ライン負荷", CDec(100 / .Rows(0).Item("SEISAN_KEISU")).RoundingToSpecifiedLength(0))
                End If
                spWork.Range("SUM_JUCHU_N").Formula = "=SUM($D$7:$D$" & (intCurrentRowIndex - 1) & ")"
                spWork.Range("SUM_TIME_N").Formula = "=SUM($E$7:$E$" & (intCurrentRowIndex - 1) & ")"
                spWork.Range("SUM_JUCHU_N_PLUS1").Formula = "=SUM($F$7:$F$" & (intCurrentRowIndex - 1) & ")"
                spWork.Range("SUM_TIME_N_PLUS1").Formula = "=SUM($G$7:$G$" & (intCurrentRowIndex - 1) & ")"
                spWork.Range("SUM_JUCHU_N_PLUS2").Formula = "=SUM($H$7:$H$" & (intCurrentRowIndex - 1) & ")"
                spWork.Range("SUM_TIME_N_PLUS2").Formula = "=SUM($I$7:$I$" & (intCurrentRowIndex - 1) & ")"

                spRangeFrom = spWork.Cells("B7:I8") '.EntireRow
                spRangeTo = spSheetMain.Cells(String.Format("B{0}:I{1}", intCurrentRowIndex, intCurrentRowIndex)) '.EntireRow
                spRangeFrom.Copy(spRangeTo, SpreadsheetGear.PasteType.All, SpreadsheetGear.PasteOperation.None, False, False)

                'カレント行を更新
                intCurrentRowIndex += 2
                '工程列結合
                If intKOTEI_TopRowIndex <> intCurrentRowIndex - 1 Then
                    spSheetMain.Cells(String.Format("A{0}:A{1}", intKOTEI_TopRowIndex, intCurrentRowIndex - 1)).Merge()
                End If
                spSheetMain.Cells(String.Format("A{0}:A{1}", intKOTEI_TopRowIndex, intCurrentRowIndex - 1)).Orientation = SpreadsheetGear.Orientation.Vertical

                '次の工程の開始行を更新
                intKOTEI_TopRowIndex = intCurrentRowIndex

                'レコードフレーム初期化
                spWork.Range("RECORD_FRAME").ClearContents()
                spWork.Range("B7:I8").ClearContents()
                '-----

                '外枠罫線
                Dim border As SpreadsheetGear.IBorder = spSheetMain.Cells("A5:A" & intCurrentRowIndex - 1).Borders(SpreadsheetGear.BordersIndex.EdgeLeft)
                border.LineStyle = SpreadsheetGear.LineStyle.Continuous
                border.Weight = SpreadsheetGear.BorderWeight.Medium
                'CHECK: spreadseetgear border color
                'border.Color = SpreadsheetGear.Colors.Black
                Dim border2 As SpreadsheetGear.IBorder = spSheetMain.Cells("A5:A" & intCurrentRowIndex - 1).Borders(SpreadsheetGear.BordersIndex.EdgeBottom)
                border2.LineStyle = SpreadsheetGear.LineStyle.Continuous
                border2.Weight = SpreadsheetGear.BorderWeight.Medium

                Dim border3 As SpreadsheetGear.IBorder = spSheetMain.Cells("A5:A" & intCurrentRowIndex - 1).Borders(SpreadsheetGear.BordersIndex.InsideHorizontal)
                border3.LineStyle = SpreadsheetGear.LineStyle.Continuous
                border3.Weight = SpreadsheetGear.BorderWeight.Medium
            End With

            'ヘッダ更新
            Dim strKOTEI_SYUBETU_NAME As String = tblKOTEI_SYUBETU.Select("VALUE='" & strKOTEI_SYUBETU & "'")(0).Item("DISP")
            spSheetMain.Range("YM").Value = Me.dtYM.Value
            spSheetMain.Range("TITLE").Value = Me.dtYM.ValueDate.ToString("yyyy年MM月度") & " " & strKOTEI_SYUBETU_NAME & " 負荷明細" 'タイトル

            'シート名            
            spSheetMain.Name = strKOTEI_SYUBETU_NAME

            '印刷範囲指定
            spSheetMain.PageSetup.PrintArea = spSheetMain.Name & "!$A$1:$I$" & (intCurrentRowIndex - 1)
            '印刷タイトル行
            spSheetMain.PageSetup.PrintTitleRows = spSheetMain.Name & "!$1:$6"

            '-----ファイル保存
            spWork.Visible = SpreadsheetGear.SheetVisibility.VeryHidden '非表示(再表示一覧にも表示しない)
            spSheet1.Visible = SpreadsheetGear.SheetVisibility.VeryHidden '非表示(再表示一覧にも表示しない)
            spWorksheets(0).Cells("A1").Select()
            spSheetMain.SaveAs(filename:=strFilePath, fileFormat:=SpreadsheetGear.FileFormat.OpenXMLWorkbook)
            spWorkbook.WorkbookSet.ReleaseLock()

            Return True

        Catch ex As Exception
            EM.ErrorSyori(ex, False, conblnNonMsg)
            Return False
        Finally
            spRangeFrom = Nothing
            spRangeTo = Nothing
            spSheet1 = Nothing
            spWork = Nothing
            spSheetMain = Nothing
            spWorksheets = Nothing
            spWorkbook = Nothing

            '-----開放
            dsList.Dispose()
        End Try
    End Function


#End Region

#Region "出荷計画画面表示"

    Private Function FunOpenAppSyuKkaKeikaku() As Boolean

        Try
            Dim strEXE As String = FunGetRootPath() & FunGetEXEPath() & Context.CON_PG_G020
            Dim strParam As String = pub_SYAIN_INFO.SYAIN_ID & Space(1) &
                                     Me.dtYM.ValueNonFormat & Space(1) &
                                     Me.cmbMonthRange.SelectedValue

            Call FunCallEXE(strEXE, strParam, 1)

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
    Public Function FunInitFuncButtonEnabled(ByVal frm As FrmFMS_G010) As Boolean
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
                frm.cmdFunc7.Enabled = True
                frm.cmdFunc10.Enabled = True
            Else
                frm.cmdFunc7.Enabled = False
                frm.cmdFunc10.Enabled = False
            End If

            '変更確定
            frm.cmdFunc4.Enabled = pri_blnUpdateCellValue

            Dim blnExistNaiji As Boolean = FunIsExistNAIJI()
            '3ヶ月内示レポート
            frm.cmdFunc8.Enabled = blnExistNaiji
            frm.cmdFunc9.Enabled = blnExistNaiji

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
        '変更未確定データの存在チェック
        If FunblnHasUnappliedData(sender) = True Then
            '
            pri_blnUpdateCellValue = False
            '検索
            Me.cmdFunc1.PerformClick()
        End If
    End Sub

#End Region

#Region "ローカル関数"

    '内示存在チェック
    Private Function FunIsExistNAIJI() As Boolean
        Dim dsList As New DataSet
        Dim sbSQL As New System.Text.StringBuilder

        Try
            sbSQL.Remove(0, sbSQL.Length)
            sbSQL.Append("SELECT * FROM " & Context.CON_S_TB06_SIIRE_NAIJI_ICHIRAN & "('" & Me.dtYM.ValueNonFormat & "','" & Me.cmbMonthRange.SelectedValue & "')")
            sbSQL.Append(" ORDER BY MAKER_NAME,HINMEI,YM")

            Using DB As ClsDbUtility = DBOpen()
                dsList = DB.GetDataSet(sbSQL.ToString)
            End Using

            If dsList.Tables(0).Rows.Count > 0 Then
                Return True
            Else
                Return False
            End If

        Catch ex As Exception
            EM.ErrorSyori(ex, False, conblnNonMsg)
            Return False
        Finally
            dsList.Dispose()
        End Try
    End Function


    ''' <summary>
    ''' 変更未確定データ存在チェック(+Control.Undo)
    ''' </summary>
    ''' <returns></returns>
    Private Function FunblnHasUnappliedData(ByVal sender As Object) As Boolean
        '未反映の更新内容が存在する場合
        If pri_blnUpdateCellValue = True Then
            If MessageBox.Show(My.Resources.infoSearchUnsettledData, My.Resources.infoTitleResetChange, MessageBoxButtons.YesNo, MessageBoxIcon.Information) = Windows.Forms.DialogResult.Yes Then
                Return True
            Else
                '各コントロールの値を変更前に戻す
                Select Case True
                    Case TypeOf sender Is CheckBox
                        Dim ctrlCheckBox As CheckBox = DirectCast(sender, CheckBox)
                        RemoveHandler ctrlCheckBox.CheckedChanged, AddressOf SearchFilterValueChanged
                        ctrlCheckBox.Checked = Not ctrlCheckBox.Checked
                        AddHandler ctrlCheckBox.CheckedChanged, AddressOf SearchFilterValueChanged

                    Case TypeOf sender Is ComboboxEx
                        Dim ctrlCombobox As ComboboxEx = DirectCast(sender, ComboboxEx)
                        RemoveHandler ctrlCombobox.SelectedValueChanged, AddressOf SearchFilterValueChanged
                        ctrlCombobox.Undo()
                        AddHandler ctrlCombobox.SelectedValueChanged, AddressOf SearchFilterValueChanged

                    Case TypeOf sender Is DateTextBoxEx
                        Dim ctrlDateTextBox As DateTextBoxEx = DirectCast(sender, DateTextBoxEx)
                        RemoveHandler ctrlDateTextBox.TxtChanged, AddressOf SearchFilterValueChanged
                        ctrlDateTextBox.Undo()
                        AddHandler ctrlDateTextBox.TxtChanged, AddressOf SearchFilterValueChanged

                    Case TypeOf sender Is MaskedTextBoxEx
                        Dim ctrlMaskedTextBox As MaskedTextBoxEx = DirectCast(sender, MaskedTextBoxEx)
                        RemoveHandler ctrlMaskedTextBox.Validated, AddressOf SearchFilterValueChanged
                        ctrlMaskedTextBox.Undo()
                        AddHandler ctrlMaskedTextBox.Validated, AddressOf SearchFilterValueChanged

                    Case Else

                End Select

                Return False
            End If
        Else
            Return True
        End If
    End Function

    Private Sub CmbKOTEI_SelectedValueChanged(sender As Object, e As EventArgs) Handles cmbKOTEI.SelectedValueChanged
        If cmbKOTEI.SelectedValue IsNot Nothing Then
            C1DataSource.ViewSources(0).FilterDescriptors(0).Value = cmbKOTEI.SelectedValue
        End If
    End Sub



#End Region

End Class
