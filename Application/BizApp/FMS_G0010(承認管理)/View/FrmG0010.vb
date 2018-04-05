Imports JMS_COMMON.ClsPubMethod
Imports C1.Win.C1FlexGrid

Public Class FrmG0010

    Public Property PrDt As DataTable


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
        MyBase.ToolTip.SetToolTip(Me.cmdFunc7, My.Resources.infoToolTipMsgNotFoundData)
        MyBase.ToolTip.SetToolTip(Me.cmdFunc8, My.Resources.infoToolTipMsgNotFoundData)
        MyBase.ToolTip.SetToolTip(Me.cmdFunc9, My.Resources.infoToolTipMsgNotFoundData)
        MyBase.ToolTip.SetToolTip(Me.cmdFunc10, My.Resources.infoToolTipMsgNotFoundData)
        MyBase.ToolTip.SetToolTip(Me.cmdFunc11, My.Resources.infoToolTipMsgNotFoundData)

    End Sub

#End Region

#Region "Form関連"

    'Loadイベント
    Private Sub FrmLoad(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        Try
            '-----フォーム初期設定(親フォームから呼び出し)
            Call FunFormCommonSetting(pub_APP_INFO, pub_SYAIN_INFO, My.Application.Info.Version.ToString)

            '-----グリッド初期設定(親フォームから呼び出し)
            Call FunInitializeDataGridView(dgvDATA)

            '-----グリッド列作成
            Call FunSetDgvCulumns(dgvDATA)

            '-----コントロールソース設定
            cmbBUMON.SetDataSource(tblBUMON.ExcludeDeleted, ENM_COMBO_SELECT_VALUE_TYPE._1_Filter)

            cmbKISYU.SetDataSource(tblKISYU.ExcludeDeleted, ENM_COMBO_SELECT_VALUE_TYPE._1_Filter)
            cmbTANTO.SetDataSource(tblTANTO.ExcludeDeleted, ENM_COMBO_SELECT_VALUE_TYPE._1_Filter)
            cmbJIZEN_SINSA_HANTEI_KB.SetDataSource(tblJIZEN_SINSA_HANTEI_KB.ExcludeDeleted, ENM_COMBO_SELECT_VALUE_TYPE._1_Filter)
            cmbSAISIN_IINKAI_HANTEI_KB.SetDataSource(tblSAISIN_IINKAI_HANTEI_KB.ExcludeDeleted, ENM_COMBO_SELECT_VALUE_TYPE._1_Filter)
            cmbBUHIN_BANGO.SetDataSource(tblBUHIN.ExcludeDeleted, ENM_COMBO_SELECT_VALUE_TYPE._1_Filter)

            '既定値設定
            cmbTANTO.SelectedValue = pub_SYAIN_INFO.SYAIN_ID


            ''-----イベントハンドラ設定
            AddHandler Me.cmbTANTO.SelectedValueChanged, AddressOf SearchFilterValueChanged
            AddHandler Me.cmbBUHIN_BANGO.SelectedValueChanged, AddressOf SearchFilterValueChanged
            AddHandler Me.chkClosedRowVisibled.CheckedChanged, AddressOf SearchFilterValueChanged


            '検索実行
            Me.cmdFunc1.PerformClick()
        Finally

        End Try
    End Sub

#End Region

#Region "DataGridView関連"

    'フィールド定義()
    Private Shared Function FunSetDgvCulumns(ByVal dgv As DataGridView) As Boolean
        Dim _Model As New MODEL.TV01_FUTEKIGO_ICHIRAN
        Try
            With dgv
                .AutoGenerateColumns = False
                .ReadOnly = False

                .RowsDefaultCellStyle.BackColor = Color.White
                .AlternatingRowsDefaultCellStyle.BackColor = Color.White

                Dim cmbclmn1 As New DataGridViewCheckBoxColumn With {
                .Name = NameOf(_Model.SELECTED),
                .HeaderText = "選択",
                .DataPropertyName = .Name
                }
                cmbclmn1.DefaultCellStyle.Alignment = Windows.Forms.DataGridViewContentAlignment.MiddleCenter
                .Columns.Add(cmbclmn1)
                .Columns(.ColumnCount - 1).SortMode = DataGridViewColumnSortMode.Automatic
                .Columns(.ColumnCount - 1).Width = 30

                .Columns.Add(NameOf(_Model.HOKOKUSYO_NO), "報告書No")
                .Columns(.ColumnCount - 1).Width = 70
                .Columns(.ColumnCount - 1).DefaultCellStyle.Alignment = Windows.Forms.DataGridViewContentAlignment.MiddleLeft
                .Columns(.ColumnCount - 1).DataPropertyName = .Columns(.ColumnCount - 1).Name
                .Columns(.ColumnCount - 1).ReadOnly = True

                .Columns.Add(NameOf(_Model.CLOSE_FLG), "Closed")
                .Columns(.ColumnCount - 1).DataPropertyName = .Columns(.ColumnCount - 1).Name
                .Columns(.ColumnCount - 1).Visible = False

                .Columns.Add(NameOf(_Model.SYONIN_JUN), "承認順")
                .Columns(.ColumnCount - 1).DataPropertyName = .Columns(.ColumnCount - 1).Name
                .Columns(.ColumnCount - 1).Visible = False

                .Columns.Add(NameOf(_Model.SYONIN_NAIYO), "ステージ")
                .Columns(.ColumnCount - 1).Width = 180
                .Columns(.ColumnCount - 1).DefaultCellStyle.Alignment = Windows.Forms.DataGridViewContentAlignment.MiddleLeft
                .Columns(.ColumnCount - 1).DataPropertyName = .Columns(.ColumnCount - 1).Name
                .Columns(.ColumnCount - 1).ReadOnly = True

                .Columns.Add(NameOf(_Model.SYONIN_HOKOKUSYO_R_NAME), "略名")
                .Columns(.ColumnCount - 1).Width = 70
                .Columns(.ColumnCount - 1).DefaultCellStyle.Alignment = Windows.Forms.DataGridViewContentAlignment.MiddleCenter
                .Columns(.ColumnCount - 1).DataPropertyName = .Columns(.ColumnCount - 1).Name
                .Columns(.ColumnCount - 1).ReadOnly = True

                .Columns.Add(NameOf(_Model.SYOCHI_SYAIN_NAME), "処置担当者")
                .Columns(.ColumnCount - 1).Width = 120
                .Columns(.ColumnCount - 1).DefaultCellStyle.Alignment = Windows.Forms.DataGridViewContentAlignment.MiddleLeft
                .Columns(.ColumnCount - 1).DataPropertyName = .Columns(.ColumnCount - 1).Name
                .Columns(.ColumnCount - 1).ReadOnly = True

                .Columns.Add(NameOf(_Model.TAIRYU), "滞留日数")
                .Columns(.ColumnCount - 1).Width = 80
                .Columns(.ColumnCount - 1).DefaultCellStyle.Alignment = Windows.Forms.DataGridViewContentAlignment.MiddleRight
                .Columns(.ColumnCount - 1).DataPropertyName = .Columns(.ColumnCount - 1).Name
                .Columns(.ColumnCount - 1).ReadOnly = True

                .Columns.Add(NameOf(_Model.KISYU), "機種")
                .Columns(.ColumnCount - 1).Width = 120
                .Columns(.ColumnCount - 1).DefaultCellStyle.Alignment = Windows.Forms.DataGridViewContentAlignment.MiddleLeft
                .Columns(.ColumnCount - 1).DataPropertyName = .Columns(.ColumnCount - 1).Name
                .Columns(.ColumnCount - 1).ReadOnly = True

                .Columns.Add(NameOf(_Model.BUHIN_BANGO), "部品番号")
                .Columns(.ColumnCount - 1).Width = 180
                .Columns(.ColumnCount - 1).DefaultCellStyle.Alignment = Windows.Forms.DataGridViewContentAlignment.MiddleLeft
                .Columns(.ColumnCount - 1).DataPropertyName = .Columns(.ColumnCount - 1).Name
                .Columns(.ColumnCount - 1).ReadOnly = True

                .Columns.Add(NameOf(_Model.BUHIN_NAME), "部品名")
                .Columns(.ColumnCount - 1).Width = 180
                .Columns(.ColumnCount - 1).DefaultCellStyle.Alignment = Windows.Forms.DataGridViewContentAlignment.MiddleLeft
                .Columns(.ColumnCount - 1).DataPropertyName = .Columns(.ColumnCount - 1).Name
                .Columns(.ColumnCount - 1).ReadOnly = True

                .Columns.Add(NameOf(_Model.SYONIN_HOKOKUSYO_NAME), "名称")
                .Columns(.ColumnCount - 1).Width = 180
                .Columns(.ColumnCount - 1).DefaultCellStyle.Alignment = Windows.Forms.DataGridViewContentAlignment.MiddleLeft
                .Columns(.ColumnCount - 1).DataPropertyName = .Columns(.ColumnCount - 1).Name
                .Columns(.ColumnCount - 1).ReadOnly = True

                .Columns.Add(NameOf(_Model.JIZEN_SINSA_HANTEI_KB_DISP), "事前判定区分")
                .Columns(.ColumnCount - 1).Width = 180
                .Columns(.ColumnCount - 1).DefaultCellStyle.Alignment = Windows.Forms.DataGridViewContentAlignment.MiddleLeft
                .Columns(.ColumnCount - 1).DataPropertyName = .Columns(.ColumnCount - 1).Name
                .Columns(.ColumnCount - 1).ReadOnly = True

                .Columns.Add(NameOf(_Model.SAISIN_IINKAI_HANTEI_KB_DISP), "再審判定区分")
                .Columns(.ColumnCount - 1).Width = 180
                .Columns(.ColumnCount - 1).DefaultCellStyle.Alignment = Windows.Forms.DataGridViewContentAlignment.MiddleLeft
                .Columns(.ColumnCount - 1).DataPropertyName = .Columns(.ColumnCount - 1).Name
                .Columns(.ColumnCount - 1).ReadOnly = True

                .Columns.Add(NameOf(_Model.ADD_YMD), "起草日")
                .Columns(.ColumnCount - 1).Width = 180
                .Columns(.ColumnCount - 1).DefaultCellStyle.Alignment = Windows.Forms.DataGridViewContentAlignment.MiddleLeft
                .Columns(.ColumnCount - 1).DataPropertyName = .Columns(.ColumnCount - 1).Name
                .Columns(.ColumnCount - 1).ReadOnly = True

                .Columns.Add(NameOf(_Model.SYOCHI_YMD), "前処理実施日")
                .Columns(.ColumnCount - 1).Width = 180
                .Columns(.ColumnCount - 1).DefaultCellStyle.Alignment = Windows.Forms.DataGridViewContentAlignment.MiddleLeft
                .Columns(.ColumnCount - 1).DataPropertyName = .Columns(.ColumnCount - 1).Name
                .Columns(.ColumnCount - 1).ReadOnly = True

                .Columns.Add(NameOf(_Model.MODOSI_SYONIN_NAIYO), "差戻元ステージ")
                .Columns(.ColumnCount - 1).Width = 180
                .Columns(.ColumnCount - 1).DefaultCellStyle.Alignment = Windows.Forms.DataGridViewContentAlignment.MiddleLeft
                .Columns(.ColumnCount - 1).DataPropertyName = .Columns(.ColumnCount - 1).Name
                .Columns(.ColumnCount - 1).ReadOnly = True

                .Columns.Add(NameOf(_Model.MODOSI_RIYU), "差戻理由")
                .Columns(.ColumnCount - 1).Width = 180
                .Columns(.ColumnCount - 1).DefaultCellStyle.Alignment = Windows.Forms.DataGridViewContentAlignment.MiddleLeft
                .Columns(.ColumnCount - 1).DataPropertyName = .Columns(.ColumnCount - 1).Name
                .Columns(.ColumnCount - 1).ReadOnly = True

                .Columns.Add(NameOf(_Model.MODOSI_SYONIN_JUN), "差戻承認順")
                .Columns(.ColumnCount - 1).Visible = False
                .Columns(.ColumnCount - 1).DataPropertyName = .Columns(.ColumnCount - 1).Name
                .Columns(.ColumnCount - 1).ReadOnly = True

                '.Columns(.ColumnCount - 1).DefaultCellStyle.Format = "#,0"
            End With


            Return True
        Finally

        End Try
    End Function

    'グリッドセル(行)ダブルクリック時イベント
    Private Sub DgvDATA_CellDoubleClick(sender As System.Object, e As DataGridViewCellEventArgs) Handles dgvDATA.CellDoubleClick
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
    Private Overloads Sub DgvDATA_SelectionChanged(sender As System.Object, e As System.EventArgs)
        Try
            Dim dgv As DataGridView = DirectCast(sender, DataGridView)

        Finally
            Call FunInitFuncButtonEnabled()
        End Try
    End Sub

    'ソート時イベント
    Private Sub DgvDATA_Sorted(sender As Object, e As EventArgs) Handles dgvDATA.Sorted
        Call FunSetDgvCellFormat(sender)
    End Sub


#Region "　グリッド編集関連"

    ''' <summary>
    ''' グリッド編集前処理
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks>グリッド編集前処理</remarks>
    Private Sub DgvDATA_CellBeginEdit(sender As Object, e As System.Windows.Forms.DataGridViewCellCancelEventArgs) Handles dgvDATA.CellBeginEdit

        ' 編集前の値を待避しておく
        'pri_intPrevCellValue = Val(Me.dgvDATA.CurrentCell.Value)
    End Sub

    'セル編集完了イベント
    Private Sub DgvDATA_CellEndEdit(sender As Object, e As DataGridViewCellEventArgs) Handles dgvDATA.CellEndEdit
        Try

            'Dim intEditedCellValue As Integer
            'intEditedCellValue = Val(Me.dgvDATA.CurrentCell.Value)

            'If pri_intPrevCellValue <> intEditedCellValue Then
            '    'カレントセル書式変更
            '    Me.dgvDATA.CurrentCell.Style.ForeColor = clrEditedCellForeColor
            '    Me.dgvDATA.CurrentCell.Style.SelectionForeColor = clrEditedCellForeColor

            '    If Me.dgvDATA.Columns(e.ColumnIndex).Name = "SELECTROW" Then
            '    Else
            '        Me.dgvDATA.CurrentRow.Cells("MODIFIED_STATUS").Value = True
            '        Me.pri_blnUpdateCellValue = True
            '    End If
            'End If

        Catch ex As Exception
            EM.ErrorSyori(ex, False, conblnNonMsg)
        Finally
            'FunInitFuncButtonEnabled(Me)
        End Try
    End Sub

    'セルクリック時イベント
    Private Sub DgvDATA_CellClick(sender As System.Object, e As DataGridViewCellEventArgs) Handles dgvDATA.CellClick

        Try
            Dim dgv As DataGridView = DirectCast(sender, DataGridView)

            If e.RowIndex >= 0 Then
                Select Case dgv.Columns(e.ColumnIndex).Name
                    Case "SELECTED"
                        'If Me.dgvDATA.CurrentRow.Cells("STATUS").Value = Context.ENM_HACCYU_STATUS._0_未発注 Then
                        '    If Me.dgvDATA.CurrentRow.Cells("MODIFIED_STATUS").Value = True Then
                        '        '数量・単価変更時、は更新するまで選択処理は不可
                        '        Me.dgvDATA.CurrentRow.Cells("SELECTROW").Value = False
                        '        MessageBox.Show("数量・単価が変更されています。先に変更内容を確定して下さい", "変更未確定", MessageBoxButtons.OK, MessageBoxIcon.Information)
                        '        Exit Sub
                        '    Else
                        Me.dgvDATA.CurrentRow.Cells("SELECTED").Value = Not CBool(Me.dgvDATA.CurrentRow.Cells("SELECTED").Value)
                        '    End If
                        'Else
                        '    '選択不可
                        '    Me.dgvDATA.CurrentRow.Cells("SELECTED").Value = False
                        '    MessageBox.Show("未発注データ以外は選択出来ません。", "選択不可", MessageBoxButtons.OK, MessageBoxIcon.Information)
                        'End If

                        'Case "HACYU_SU", "TANKA"
                        '    If dgv(e.ColumnIndex, e.RowIndex).ReadOnly = True Then
                        '        Select Case Me.dgvDATA.CurrentRow.Cells("STATUS").Value
                        '            Case Context.ENM_HACCYU_STATUS._1_発注済, Context.ENM_HACCYU_STATUS._2_入荷済
                        '                MessageBox.Show("既に発注済みのため数量・単価は変更できません。" & vbCrLf & "変更が必要な場合は既存の発注を取消後、発注計画を再登録して下さい。", "変更不可", MessageBoxButtons.OK, MessageBoxIcon.Information)
                        '            Case Context.ENM_HACCYU_STATUS._9_取消
                        '                MessageBox.Show("既に取消済みのため数量・単価は変更できません。" & vbCrLf & "変更が必要な場合は、発注計画を再登録して下さい。", "変更不可", MessageBoxButtons.OK, MessageBoxIcon.Information)
                        '        End Select
                        '        Exit Sub
                        '    Else
                        '        Me.dgvDATA.BeginEdit(True)
                        '    End If
                End Select

            End If
        Catch ex As Exception
            EM.ErrorSyori(ex, False, conblnNonMsg)
        Finally
            FunInitFuncButtonEnabled()
        End Try
    End Sub


#Region "編集可能セルOnMouse時カーソル変更"
    Private Sub Dgv_CellMouseMove(sender As Object, e As DataGridViewCellMouseEventArgs) Handles dgvDATA.CellMouseMove
        Dim dgv As DataGridView = DirectCast(sender, DataGridView)
        If e.RowIndex >= 0 Then
            Select Case dgv.Columns(e.ColumnIndex).Name
                Case "SELECTED"
                    dgv.Cursor = Cursors.Hand
                    'Case "TANKA", "HACYU_SU"
                    '    If dgv(e.ColumnIndex, e.RowIndex).ReadOnly = False Then
                    '        dgv.Cursor = Cursors.IBeam
                    '    Else
                    '        dgv.Cursor = Cursors.No
                    '    End If
                Case Else
                    dgv.Cursor = Cursors.Default
            End Select
        End If
    End Sub

    Private Sub Dgv_CellMouseLeave(sender As Object, e As DataGridViewCellEventArgs) Handles dgvDATA.CellMouseLeave
        Dim dgv As DataGridView = DirectCast(sender, DataGridView)
        dgv.Cursor = Cursors.Default
    End Sub

#End Region

#Region "入力制限"
    'EditingControlShowingイベント
    Private Sub DataGridView1_EditingControlShowing(ByVal sender As Object, ByVal e As DataGridViewEditingControlShowingEventArgs) Handles dgvDATA.EditingControlShowing
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
                Case "TANKA", "HACYU_SU"
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
        Dim tb As DataGridViewTextBoxEditingControl = DirectCast(sender, DataGridViewTextBoxEditingControl)

        If (e.KeyChar < "0"c Or e.KeyChar > "9"c) _
            AndAlso e.KeyChar <> ControlChars.Back _
            AndAlso e.KeyChar <> "."c _
            AndAlso (e.KeyChar = "."c And tb.Text.Contains("."c)) Then
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
            '[処理中]
            Me.PrPG_STATUS = ENM_PG_STATUS._3_PROCESSING

            'ボタン不可/ボタンINDEX取得
            For intCNT = 0 To Me.cmdFunc.Length - 1
                Me.cmdFunc(intCNT).Enabled = False
                If cmdFunc(intCNT) Is sender Then intFUNC = intCNT + 1
            Next

            'ボタンINDEX毎の処理
            Select Case intFUNC
                Case 1  '検索
                    Call FunSRCH(dgvDATA, FunGetListData())
                Case 2  '追加

                    If FunUpdateEntity(ENM_DATA_OPERATION_MODE._1_ADD) = True Then
                        Call FunSRCH(dgvDATA, FunGetListData())
                    End If

                Case 4  '変更

                    If FunUpdateEntity(ENM_DATA_OPERATION_MODE._3_UPDATE) = True Then
                        Call FunSRCH(dgvDATA, FunGetListData())
                    End If
                Case 5, 6  '削除/復元/完全削除

                    'Dim btn As Button = DirectCast(sender, Button)
                    'Dim ENM_MODE As ENM_DATA_OPERATION_MODE = DirectCast(btn.Tag, ENM_DATA_OPERATION_MODE)
                    If FunDEL() = True Then
                        'Call FunSRCH(dgvDATA, FunGetListData())
                    End If

                Case 7 '全選択

                    Call FunSelectAll()

                Case 8 '全選択解除

                    Call FunUnSelectAll()

                Case 9 'メール送信
                    MessageBox.Show("未実装")
                Case 10  '印刷
                    Call OpenReport()

                    'Dim strFileName As String = pub_APP_INFO.strTitle & "_" & DateTime.Today.ToString("yyyyMMdd") & ".CSV"
                    'Call FunCSV_OUT(Me.dgvDATA.DataSource, strFileName, pub_APP_INFO.strOUTPUT_PATH)

                Case 11 '履歴表示
                    Call OpenFormRIREKI()

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
            Call FunInitFuncButtonEnabled()

            '[アクティブ]
            Me.PrPG_STATUS = ENM_PG_STATUS._2_ACTIVE
        End Try

    End Sub

#End Region

#Region "検索"

    Private Function FunGetListData() As DataTable
        Try
            Dim sbSQL As New System.Text.StringBuilder
            Dim dsList As New DataSet
            Dim sbSQLWHERE As New System.Text.StringBuilder
            Dim sbParam As New System.Text.StringBuilder


            sbParam.Append("'','',0,'','','','" & intREGISTERED_STAGE & "',''")

            If chkClosedRowVisibled.Checked Then
            Else
                If sbSQLWHERE.Length = 0 Then
                    sbSQLWHERE.Append(" WHERE CLOSE_FLG = '0'")
                Else
                    sbSQLWHERE.Append(" AND CLOSE_FLG = '0'")
                End If
            End If

            If cmbTANTO.SelectedValue <> "" Then
                If sbSQLWHERE.Length = 0 Then
                    sbSQLWHERE.Append(" WHERE SYOCHI_SYAIN_ID = " & cmbTANTO.SelectedValue)
                Else
                    sbSQLWHERE.Append(" AND SYOCHI_SYAIN_ID = " & cmbTANTO.SelectedValue)
                End If
            Else
            End If

            If cmbBUHIN_BANGO.SelectedValue <> "" Then
                If sbSQLWHERE.Length = 0 Then
                    sbSQLWHERE.Append(" WHERE BUHIN_BANGO = '" & cmbBUHIN_BANGO.SelectedValue & "'")
                Else
                    sbSQLWHERE.Append(" AND BUHIN_BANGO = '" & cmbBUHIN_BANGO.SelectedValue & "'")
                End If
            Else
            End If

            sbSQL.Remove(0, sbSQL.Length)
            sbSQL.Append("SELECT")
            sbSQL.Append(" *")
            sbSQL.Append(" FROM " & NameOf(MODEL.TV01_FUTEKIGO_ICHIRAN) & "(" & sbParam.ToString & ")")
            sbSQL.Append(" " & sbSQLWHERE.ToString)
            sbSQL.Append(" ORDER BY HOKOKUSYO_NO ")
            Using DBa As ClsDbUtility = DBOpen()
                dsList = DBa.GetDataSet(sbSQL.ToString, conblnNonMsg)
            End Using

            If dsList.Tables(0).Rows.Count > pub_APP_INFO.intSEARCHMAX Then
                If MessageBox.Show(My.Resources.infoSearchCountOver, "", MessageBoxButtons.YesNo, MessageBoxIcon.Information) = Windows.Forms.DialogResult.No Then
                    Return Nothing
                End If
            End If

            '------DataTableに変換
            Dim dt As New DataTable

            Dim t As Type = GetType(MODEL.TV01_FUTEKIGO_ICHIRAN)
            Dim properties As Reflection.PropertyInfo() = t.GetProperties(
                 Reflection.BindingFlags.Public Or
                 Reflection.BindingFlags.NonPublic Or
                 Reflection.BindingFlags.Instance Or
                 Reflection.BindingFlags.Static)

            For Each p As Reflection.PropertyInfo In properties
                If IsAutoGenerateField(t, p.Name) = True Then
                    Dim dc As New DataColumn With {.ColumnName = p.Name,
                                                   .DataType = p.PropertyType,
                                                   .Caption = p.DisplayName}
                    dt.Columns.Add(dc)
                End If
            Next p

            With dsList.Tables(0)
                For Each row As DataRow In .Rows
                    Dim Trow As DataRow = dt.NewRow()
                    For Each p As Reflection.PropertyInfo In properties
                        If IsAutoGenerateField(t, p.Name) = True Then
                            Select Case p.PropertyType
                                Case GetType(Integer)
                                    Trow(p.Name) = Val(row.Item(p.Name))
                                Case GetType(Decimal)
                                    Trow(p.Name) = CDec(row.Item(p.Name))
                                Case GetType(Boolean)
                                    If p.Name = "SELECTED" Then
                                        Trow(p.Name) = False
                                    Else
                                        Trow(p.Name) = CBool(row.Item(p.Name))
                                    End If

                                Case GetType(Date), GetType(DateTime)
                                    If row.Item(p.Name).ToString.IsNullOrWhiteSpace = False Then
                                        Select Case row.Item(p.Name).ToString.Length
                                            Case 8
                                                Trow(p.Name) = DateTime.ParseExact(row.Item(p.Name), "yyyyMMdd", Nothing)
                                            Case 14
                                                Trow(p.Name) = DateTime.ParseExact(row.Item(p.Name), "yyyyMMddHHmmss", Nothing)
                                            Case Else
                                                'Err
                                                Trow(p.Name) = Nothing
                                        End Select
                                    End If
                                Case Else
                                    Trow(p.Name) = row.Item(p.Name)
                            End Select
                        End If
                    Next p
                    dt.Rows.Add(Trow)
                Next row
                dt.AcceptChanges()
            End With

            Return dt
        Catch ex As Exception
            EM.ErrorSyori(ex, False, conblnNonMsg)
            Return Nothing
        End Try
    End Function

    Private Function FunSRCH(ByVal dgv As DataGridView, ByVal dt As DataTable) As Boolean
        Dim intCURROW As Integer
        Try
            '-----選択行記憶
            If dgv.RowCount > 0 Then
                intCURROW = dgv.CurrentRow.Index
            End If
            PrDt = dt
            dgv.DataSource = dt

            Call FunSetDgvCellFormat(dgv)

            If dgv.RowCount > 1 Then
                '-----選択行設定
                Try
                    dgv.CurrentCell = dgv.Rows(intCURROW).Cells(0)
                Catch dgvEx As Exception
                End Try
                Me.lblRecordCount.Text = String.Format(My.Resources.infoToolTipMsgFoundData, dgv.Rows.Count)
            Else
                Me.lblRecordCount.Text = My.Resources.infoSearchResultNotFound
            End If

            Return True
        Catch ex As Exception
            EM.ErrorSyori(ex, False, conblnNonMsg)
            Return False
        Finally
        End Try
    End Function

    Private Function FunSetDgvCellFormat(ByVal dgv As DataGridView) As Boolean

        Try
            'UNDONE: ステージ別の滞留警告日数を取得
            Dim intWarningNotification As Integer
            Using DB As ClsDbUtility = DBOpen()
                intWarningNotification = FunGetCodeMastaValue(DB, "承認関連設定", "滞留警告日数")
            End Using

            Dim _Model As New MODEL.TV01_FUTEKIGO_ICHIRAN
            For i As Integer = 0 To dgv.Rows.Count - 1
                With dgv.Rows(i)
                    If Me.dgvDATA.Rows(i).Cells(NameOf(_Model.TAIRYU)).Value >= intWarningNotification Then
                        Me.dgvDATA.Rows(i).DefaultCellStyle.BackColor = clrWarningCellBackColor
                    End If

                    If Me.dgvDATA.Rows(i).Cells(NameOf(_Model.MODOSI_SYONIN_JUN)).Value > 0 Then
                        Me.dgvDATA.Rows(i).DefaultCellStyle.BackColor = clrCautionCellBackColor
                    End If

                    If Me.dgvDATA.Rows(i).Cells(NameOf(_Model.CLOSE_FLG)).Value > 0 Then
                        Me.dgvDATA.Rows(i).DefaultCellStyle.ForeColor = clrDeletedRowForeColor
                        Me.dgvDATA.Rows(i).DefaultCellStyle.BackColor = clrDeletedRowBackColor
                        Me.dgvDATA.Rows(i).DefaultCellStyle.SelectionForeColor = clrDeletedRowForeColor
                    End If

                End With

            Next i
        Catch ex As Exception
            EM.ErrorSyori(ex, False, conblnNonMsg)
        End Try
    End Function

#End Region

#Region "追加・変更"

    ''' <summary>
    ''' レコード追加変更処理
    ''' </summary>
    ''' <param name="intMODE">処理モード</param>
    ''' <returns></returns>
    Private Function FunUpdateEntity(ByVal intMODE As ENM_DATA_OPERATION_MODE) As Boolean
        Dim frmDLG As New FrmG0011
        Dim frmCAR As New FrmG0012
        Dim dlgRET As DialogResult

        Try
            If intMODE = ENM_DATA_OPERATION_MODE._3_UPDATE And dgvDATA.CurrentRow.Cells(5).Value = "CAR" Then
                dlgRET = frmCAR.ShowDialog(Me)

                If dlgRET = Windows.Forms.DialogResult.Cancel Then
                    Return False
                Else

                End If
            Else
                frmDLG.PrMODE = intMODE
                If dgvDATA.CurrentRow IsNot Nothing Then
                    frmDLG.PrdgvCellCollection = dgvDATA.CurrentRow.Cells
                    frmDLG.PrDataRow = dgvDATA.GetDataRow()
                Else
                    frmDLG.PrdgvCellCollection = Nothing
                    frmDLG.PrDataRow = Nothing
                End If
                frmDLG.PrDt = Me.PrDt
                dlgRET = frmDLG.ShowDialog(Me)

                If dlgRET = Windows.Forms.DialogResult.Cancel Then
                    Return False
                Else
                    dgvDATA.DataSource = frmDLG.PrDt
                End If
            End If



            Return True
        Catch ex As Exception
            EM.ErrorSyori(ex, False, conblnNonMsg)
            Return False
        Finally
            If frmDLG IsNot Nothing Then
                frmDLG.Dispose()
            End If
        End Try
    End Function

#End Region

#Region "削除"

    Private Function FunDEL() As Boolean
        Dim sbSQL As New System.Text.StringBuilder
        Dim strComboVal As String
        Dim strMsg As String
        Dim strTitle As String

        Try
            MessageBox.Show("未実装")

            ''コンボボックスの選択値
            'strComboVal = Me.cmbSTAGE_NCR.Text.Trim

            ''-----SQL
            'sbSQL.Remove(0, sbSQL.Length)
            'Select Case ENM_MODE
            '    Case ENM_DATA_OPERATION_MODE._4_DISABLE
            '        '-----更新
            '        sbSQL.Append("UPDATE " & NameOf(MODEL.M001_SETTING) & " SET ")
            '        '削除日時
            '        sbSQL.Append(" DEL_YMDHNS = dbo.GetSysDateString(), ")
            '        '削除担当者
            '        sbSQL.Append(" DEL_TANTO_CD = " & pub_SYAIN_INFO.SYAIN_ID & "")



            '        strMsg = My.Resources.infoMsgDeleteOperationDisable
            '        strTitle = My.Resources.infoTitleDeleteOperationDisable

            '    Case ENM_DATA_OPERATION_MODE._5_RESTORE
            '        '-----更新
            '        sbSQL.Append("UPDATE " & NameOf(MODEL.M001_SETTING) & " SET ")
            '        '削除日時
            '        sbSQL.Append(" DEL_YMDHNS = ' ', ")
            '        '削除担当者
            '        sbSQL.Append(" DEL_TANTO_CD = " & pub_SYAIN_INFO.SYAIN_ID & "")

            '        strMsg = My.Resources.infoMsgDeleteOperationRestore
            '        strTitle = My.Resources.infoTitleDeleteOperationRestore

            '    Case ENM_DATA_OPERATION_MODE._6_DELETE

            '        '-----削除
            '        sbSQL.Append("DELETE FROM " & NameOf(MODEL.M001_SETTING) & " ")

            '        strMsg = My.Resources.infoMsgDeleteOperationDelete
            '        strTitle = My.Resources.infoTitleDeleteOperationDelete

            '    Case Else
            '        'UNDONE: argument null exception
            '        Return False
            'End Select
            'sbSQL.Append("WHERE")
            ''sbSQL.Append(" KOMO_NM = '" & Me.dgvDATA.CurrentRow.Cells.Item("KOMO_NM").Value.ToString & "' ")
            ''sbSQL.Append(" AND VALUE = '" & Me.dgvDATA.CurrentRow.Cells.Item("VALUE").Value.ToString & "' ")

            ''確認メッセージ表示
            'If MessageBox.Show(strMsg, strTitle, MessageBoxButtons.YesNo, MessageBoxIcon.Question) <> Windows.Forms.DialogResult.Yes Then
            '    Me.DialogResult = Windows.Forms.DialogResult.Cancel
            '    'Me.Close()
            '    Return False
            'End If

            'Using DB As ClsDbUtility = DBOpen()
            '    Dim blnErr As Boolean
            '    Dim intRET As Integer
            '    Dim sqlEx As Exception = Nothing

            '    Try
            '        DB.BeginTransaction()

            '        '-----SQL実行
            '        intRET = DB.ExecuteNonQuery(sbSQL.ToString, conblnNonMsg, sqlEx)
            '        If intRET <> 1 Then
            '            'エラーログ
            '            Dim strErrMsg As String = My.Resources.ErrLogSqlExecutionFailure & "|" & sbSQL.ToString & "|" & sqlEx.Message
            '            WL.WriteLogDat(strErrMsg)
            '            blnErr = True
            '            Return False
            '        End If
            '    Finally
            '        DB.Commit(Not blnErr)
            '    End Try

            '    '検索フィルタデータソース更新
            '    Call FunGetCodeDataTable(DB, "項目名", tblKOMO_NM)
            'End Using
            'Me.cmbSTAGE_NCR.SetDataSource(tblKOMO_NM.ExcludeDeleted, True)

            'If strComboVal <> "" Then
            '    Me.cmbSTAGE_NCR.Text = strComboVal
            'End If
            'If Me.cmbSTAGE_NCR.SelectedIndex <= 0 Then
            '    Me.cmbSTAGE_NCR.Text = ""
            'End If

            Return True
        Catch ex As Exception
            EM.ErrorSyori(ex, False, conblnNonMsg)
            Return False
        End Try
    End Function

#End Region

#Region "全選択"

    Private Function FunSelectAll() As Boolean

        Try
            'UNDONE: G050 全選択解除
            Dim dt As DataTable = DirectCast(Me.dgvDATA.DataSource, DataTable)
            Dim rows = dt.Rows 'AsEnumerable().Where(Function(r) r.Field(Of String)("STA") = Context.ENM_HACCYU_STATUS._0_未発注)

            If rows.Count > 0 Then
                For Each row As DataRow In rows
                    row.Item("SELECTED") = True '"●"
                Next row

                '表示更新
                FunSetDgvCellFormat(Me.dgvDATA)
            Else
                'MessageBox.Show("未発注データはありません。", "全選択", MessageBoxButtons.OK, MessageBoxIcon.Information)
            End If

            Return True
        Catch ex As Exception
            EM.ErrorSyori(ex, False, conblnNonMsg)
            Return False
        End Try
    End Function

#End Region

#Region "全選択解除"

    Private Function FunUnSelectAll() As Boolean

        Try
            'UNDONE: G050 全選択解除
            Dim dt As DataTable = DirectCast(Me.dgvDATA.DataSource, DataTable)
            Dim rows = dt.Rows 'AsEnumerable().Where(Function(r) r.Field(Of String)("STA") = Context.ENM_HACCYU_STATUS._0_未発注)

            If rows.Count > 0 Then
                For Each row As DataRow In rows
                    row.Item("SELECTED") = False '"●"
                Next row

                '表示更新
                FunSetDgvCellFormat(Me.dgvDATA)
            Else
                'MessageBox.Show("未発注データはありません。", "全選択", MessageBoxButtons.OK, MessageBoxIcon.Information)
            End If

            Return True
        Catch ex As Exception
            EM.ErrorSyori(ex, False, conblnNonMsg)
            Return False
        End Try
    End Function

#End Region

#Region "レポート印刷"
    Private Function OpenReport() As Boolean
        Dim frmDLG As New FrmG0013
        'Dim dlgRET As DialogResult
        'Dim PKeys As String

        Try

            'If Me.dgvDATA.CurrentRow IsNot Nothing Then
            '    frmDLG.PrdgvCellCollection = Me.dgvDATA.CurrentRow.Cells
            '    frmDLG.PrDataRow = Me.dgvDATA.GetDataRow()
            'Else
            '    frmDLG.PrdgvCellCollection = Nothing
            '    frmDLG.PrDataRow = Nothing
            'End If
            'dlgRET = frmDLG.ShowDialog(Me)
            'PKeys = frmDLG.PrPKeys

            'If dlgRET = Windows.Forms.DialogResult.Cancel Then
            '    Return False
            'Else
            '    '追加選択行選択
            'End If

            Dim strFilePath As String = FunGetRootPath() & "\TEMPLATE\17065 T-4FC歪不良.pdf"

            Dim hProcess As New System.Diagnostics.Process
            If System.IO.File.Exists(strFilePath) = True Then
                'hProcess = System.Diagnostics.Process.Start(strEXE, strARG)
                hProcess.StartInfo.FileName = strFilePath
                hProcess.SynchronizingObject = Me
                hProcess.EnableRaisingEvents = True
                hProcess.Start()

            Else
                Dim strMsg As String
                strMsg = "下記ファイルが見つかりません。" & vbCrLf & "システム管理者にご連絡下さい。" &
                            vbCrLf & vbCrLf & strFilePath
                MessageBox.Show(strMsg, My.Application.Info.AssemblyName, MessageBoxButtons.OK, MessageBoxIcon.Information)
            End If

            Return True
        Catch ex As Exception
            EM.ErrorSyori(ex, False, conblnNonMsg)
            Return False
        Finally
            If frmDLG IsNot Nothing Then
                frmDLG.Dispose()
            End If
        End Try
    End Function
#End Region

#Region "履歴"
    Private Function OpenFormRIREKI() As Boolean
        Dim frmDLG As New FrmG0013
        Dim dlgRET As DialogResult
        Dim PKeys As String

        Try

            'If Me.dgvDATA.CurrentRow IsNot Nothing Then
            '    frmDLG.PrdgvCellCollection = Me.dgvDATA.CurrentRow.Cells
            '    frmDLG.PrDataRow = Me.dgvDATA.GetDataRow()
            'Else
            '    frmDLG.PrdgvCellCollection = Nothing
            '    frmDLG.PrDataRow = Nothing
            'End If
            'dlgRET = frmDLG.ShowDialog(Me)
            'PKeys = frmDLG.PrPKeys

            'If dlgRET = Windows.Forms.DialogResult.Cancel Then
            '    Return False
            'Else
            '    '追加選択行選択
            'End If

            Dim strFilePath As String = FunGetRootPath() & "\TEMPLATE\処置履歴.xlsx"

            Dim hProcess As New System.Diagnostics.Process
            If System.IO.File.Exists(strFilePath) = True Then
                'hProcess = System.Diagnostics.Process.Start(strEXE, strARG)
                hProcess.StartInfo.FileName = strFilePath
                hProcess.SynchronizingObject = Me
                hProcess.EnableRaisingEvents = True
                hProcess.Start()

            Else
                Dim strMsg As String
                strMsg = "下記ファイルが見つかりません。" & vbCrLf & "システム管理者にご連絡下さい。" &
                            vbCrLf & vbCrLf & strFilePath
                MessageBox.Show(strMsg, My.Application.Info.AssemblyName, MessageBoxButtons.OK, MessageBoxIcon.Information)
            End If

            Return True
        Catch ex As Exception
            EM.ErrorSyori(ex, False, conblnNonMsg)
            Return False
        Finally
            If frmDLG IsNot Nothing Then
                frmDLG.Dispose()
            End If
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
                With Me.Controls("cmdFunc" & intFunc)
                    If .Text.Length = 0 OrElse .Text.Substring(0, .Text.IndexOf("(")).Trim = "" Then
                        .Text = ""
                        .Visible = False
                    End If
                End With
            Next intFunc

            If dgvDATA.RowCount > 0 Then
                cmdFunc3.Enabled = True
                cmdFunc4.Enabled = True
                cmdFunc5.Enabled = True
                'cmdFunc6.Enabled = True
                cmdFunc7.Enabled = True
                cmdFunc8.Enabled = True
                cmdFunc9.Enabled = True
                cmdFunc10.Enabled = True
                cmdFunc11.Enabled = True


                '選択行がClosedの場合
                If dgvDATA.CurrentRow.Cells.Item("CLOSE_FLG").Value = 1 Then
                    cmdFunc4.Enabled = False
                    cmdFunc5.Enabled = False
                    MyBase.ToolTip.SetToolTip(Me.cmdFunc4, "クローズ済のため変更出来ません")
                    MyBase.ToolTip.SetToolTip(Me.cmdFunc5, "クローズ済のため削除出来ません")
                Else
                    MyBase.ToolTip.SetToolTip(Me.cmdFunc4, My.Resources.infoToolTipMsgNotFoundData)
                    MyBase.ToolTip.SetToolTip(Me.cmdFunc5, My.Resources.infoToolTipMsgNotFoundData)
                End If

                'If dgvDATA.CurrentRow IsNot Nothing AndAlso dgvDATA.CurrentRow.Cells.Item("DEL_FLG").Value = True Then
                '    '削除済データの場合
                '    cmdFunc4.Enabled = False
                '    cmdFunc5.Text = "完全削除(F5)"
                '    cmdFunc5.Tag = ENM_DATA_OPERATION_MODE._6_DELETE

                '    '復元
                '    cmdFunc6.Text = "復元(F6)"
                '    cmdFunc6.Visible = True
                '    cmdFunc6.Tag = ENM_DATA_OPERATION_MODE._5_RESTORE
                'Else
                '    cmdFunc5.Text = "削除(F5)"
                '    cmdFunc5.Tag = ENM_DATA_OPERATION_MODE._4_DISABLE

                '    cmdFunc6.Text = ""
                '    cmdFunc6.Visible = False
                '    cmdFunc6.Tag = ""
                'End If

            Else
                cmdFunc3.Enabled = False
                cmdFunc4.Enabled = False
                cmdFunc5.Enabled = False
                cmdFunc7.Enabled = False
                cmdFunc6.Enabled = False
                cmdFunc6.Visible = False
                cmdFunc8.Enabled = False
                cmdFunc9.Enabled = False
                cmdFunc10.Enabled = False
                cmdFunc11.Enabled = False
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

    '


#End Region


End Class