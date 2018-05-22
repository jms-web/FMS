Imports JMS_COMMON.ClsPubMethod

''' <summary>
''' 不適合検索画面
''' </summary>
Public Class FrmG0010

#Region "定数・変数"

    Private ParamModel As New ST02_ParamModel
#End Region

#Region "プロパティ"
    ''' <summary>
    ''' 
    ''' </summary>
    ''' <returns></returns>
    Public Property PrDt As DataTable

    ''' <summary>
    ''' CAR検索条件 原因1
    ''' </summary>
    ''' <returns></returns>
    Public Property PrGenin1 As New List(Of (ITEM_NAME As String, ITEM_VALUE As String, ITEM_DISP As String))

    ''' <summary>
    ''' CAR検索条件 原因2
    ''' </summary>
    ''' <returns></returns>
    Public Property PrGenin2 As New List(Of (ITEM_NAME As String, ITEM_VALUE As String, ITEM_DISP As String))

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
        MyBase.ToolTip.SetToolTip(Me.cmdFunc3, My.Resources.infoToolTipMsgNotFoundData)
        MyBase.ToolTip.SetToolTip(Me.cmdFunc4, My.Resources.infoToolTipMsgNotFoundData)
        MyBase.ToolTip.SetToolTip(Me.cmdFunc5, My.Resources.infoToolTipMsgNotFoundData)
        MyBase.ToolTip.SetToolTip(Me.cmdFunc7, My.Resources.infoToolTipMsgNotFoundData)
        MyBase.ToolTip.SetToolTip(Me.cmdFunc8, My.Resources.infoToolTipMsgNotFoundData)
        MyBase.ToolTip.SetToolTip(Me.cmdFunc9, My.Resources.infoToolTipMsgNotFoundData)
        MyBase.ToolTip.SetToolTip(Me.cmdFunc10, My.Resources.infoToolTipMsgNotFoundData)
        MyBase.ToolTip.SetToolTip(Me.cmdFunc11, My.Resources.infoToolTipMsgNotFoundData)

        '日付空欄許可
        dtJisiFrom.Nullable = True
        dtJisiTo.Nullable = True

        '先頭ウォーターマーク+バインドが必要なコンボボックスのための設定
        cmbADD_TANTO.NullValue = 0
        cmbKISYU.NullValue = 0
        cmbGEN_TANTO.NullValue = 0
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


            'SPEC: PF01.2-(1) A データソース

            '-----コントロールソース設定
            '共通
            cmbBUMON.SetDataSource(tblBUMON.ExcludeDeleted, ENM_COMBO_SELECT_VALUE_TYPE._1_Filter)
            Dim dtAddTANTO As DataTable = tblTANTO_SYONIN.
                                            ExcludeDeleted.
                                            AsEnumerable.
                                            Where(Function(r) r.Field(Of Integer)("SYONIN_JUN") = ENM_NCR_STAGE._10_起草入力 And r.Field(Of Integer)("SYONIN_HOKOKUSYO_ID") = ENM_SYONIN_HOKOKUSYO_ID._1_NCR).
                                            CopyToDataTable

            cmbADD_TANTO.SetDataSource(dtAddTANTO, ENM_COMBO_SELECT_VALUE_TYPE._1_Filter)
            cmbKISYU.SetDataSource(tblKISYU.ExcludeDeleted, ENM_COMBO_SELECT_VALUE_TYPE._1_Filter)
            cmbGEN_TANTO.SetDataSource(tblTANTO.ExcludeDeleted, ENM_COMBO_SELECT_VALUE_TYPE._1_Filter)
            cmbBUHIN_BANGO.SetDataSource(tblBUHIN.ExcludeDeleted, ENM_COMBO_SELECT_VALUE_TYPE._1_Filter)
            cmbFUTEKIGO_KB.SetDataSource(tblFUTEKIGO_KB.ExcludeDeleted, ENM_COMBO_SELECT_VALUE_TYPE._1_Filter)
            cmbFUTEKIGO_JYOTAI_KB.SetDataSource(tblJIZEN_SINSA_HANTEI_KB.ExcludeDeleted, ENM_COMBO_SELECT_VALUE_TYPE._1_Filter)
            cmbSYANAI_CD.SetDataSource(tblSYANAI_CD.ExcludeDeleted, ENM_COMBO_SELECT_VALUE_TYPE._1_Filter)

            'NCR
            cmbJIZEN_SINSA_HANTEI_KB.SetDataSource(tblJIZEN_SINSA_HANTEI_KB.ExcludeDeleted, ENM_COMBO_SELECT_VALUE_TYPE._1_Filter)
            cmbSAISIN_IINKAI_HANTEI_KB.SetDataSource(tblSAISIN_IINKAI_HANTEI_KB.ExcludeDeleted, ENM_COMBO_SELECT_VALUE_TYPE._1_Filter)
            cmbZESEI_SYOCHI_YOHI_KB.SetDataSource(tblYOHI_KB.ExcludeDeleted, ENM_COMBO_SELECT_VALUE_TYPE._1_Filter)
            cmbKOKYAKU_HANTEI_SIJI_KB.SetDataSource(tblKOKYAKU_HANTEI_SIJI_KB.ExcludeDeleted, ENM_COMBO_SELECT_VALUE_TYPE._1_Filter)
            cmbKOKYAKU_SAISYU_HANTEI_KB.SetDataSource(tblKOKYAKU_SAISYU_HANTEI_KB.ExcludeDeleted, ENM_COMBO_SELECT_VALUE_TYPE._1_Filter)
            cmbKENSA_KEKKA_KB.SetDataSource(tblKENSA_KEKKA_KB.ExcludeDeleted, ENM_COMBO_SELECT_VALUE_TYPE._1_Filter)

            'CAR
            cmbYOIN1.SetDataSource(tblKONPON_YOIN_KB.ExcludeDeleted, ENM_COMBO_SELECT_VALUE_TYPE._1_Filter)
            cmbYOIN2.SetDataSource(tblKONPON_YOIN_KB.ExcludeDeleted, ENM_COMBO_SELECT_VALUE_TYPE._1_Filter)
            cmbKISEKI_KOTEI_KB.SetDataSource(tblKISEKI_KOUTEI_KB.ExcludeDeleted, ENM_COMBO_SELECT_VALUE_TYPE._1_Filter)

            '-----バインディング
            Call FunSetBinding()

            '既定値設定
            If pub_SYAIN_INFO.BUMON_KB.IsNullOrWhiteSpace = False Then cmbBUMON.SelectedValue = pub_SYAIN_INFO.BUMON_KB
            cmbGEN_TANTO.SelectedValue = pub_SYAIN_INFO.SYAIN_ID

            ''-----イベントハンドラ設定
            AddHandler cmbBUMON.SelectedValueChanged, AddressOf SearchFilterValueChanged
            AddHandler cmbKISYU.SelectedValueChanged, AddressOf SearchFilterValueChanged
            AddHandler cmbSYANAI_CD.SelectedValueChanged, AddressOf SearchFilterValueChanged
            AddHandler cmbGEN_TANTO.SelectedValueChanged, AddressOf SearchFilterValueChanged
            AddHandler cmbFUTEKIGO_KB.SelectedValueChanged, AddressOf SearchFilterValueChanged
            AddHandler cmbFUTEKIGO_JYOTAI_KB.SelectedValueChanged, AddressOf SearchFilterValueChanged

            AddHandler mtxHOKUKO_NO.Validated, AddressOf SearchFilterValueChanged
            AddHandler mtxGOKI.Validated, AddressOf SearchFilterValueChanged
            AddHandler cmbBUHIN_BANGO.SelectedValueChanged, AddressOf SearchFilterValueChanged
            AddHandler dtJisiFrom.Validated, AddressOf SearchFilterValueChanged
            AddHandler dtJisiTo.Validated, AddressOf SearchFilterValueChanged
            AddHandler cmbFUTEKIGO_S_KB.SelectedValueChanged, AddressOf SearchFilterValueChanged
            AddHandler cmbADD_TANTO.SelectedValueChanged, AddressOf SearchFilterValueChanged
            AddHandler mtxHINMEI.Validated, AddressOf SearchFilterValueChanged
            AddHandler chkClosedRowVisibled.CheckedChanged, AddressOf SearchFilterValueChanged
            AddHandler chkTairyu.CheckedChanged, AddressOf SearchFilterValueChanged

            '起動モード別処理
            Select Case pub_intOPEN_MODE
                Case ENM_OPEN_MODE._0_通常
                    Me.cmdFunc1.PerformClick()
                Case ENM_OPEN_MODE._1_新規作成
                    Me.cmdFunc2.PerformClick()
                Case Else
                    'Err
                    Throw New ArgumentException("起動モードパラメータが取得出来ませんでした")
            End Select
        Finally
            'ファンクションボタンステータス更新
            Call FunInitFuncButtonEnabled()
        End Try
    End Sub

#End Region

#Region "DataGridView関連"

    'フィールド定義
    Private Shared Function FunSetDgvCulumns(ByVal dgv As DataGridView) As Boolean
        Dim _Model As New MODEL.ST02_FUTEKIGO_ICHIRAN
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


                .Columns.Add(NameOf(_Model.SYONIN_HOKOKUSYO_ID), "承認報告書ID")
                .Columns(.ColumnCount - 1).DataPropertyName = .Columns(.ColumnCount - 1).Name
                .Columns(.ColumnCount - 1).Visible = False

                .Columns.Add(NameOf(_Model.HOKOKU_NO), "報告書No")
                .Columns(.ColumnCount - 1).Width = 80
                .Columns(.ColumnCount - 1).DefaultCellStyle.Alignment = Windows.Forms.DataGridViewContentAlignment.MiddleLeft
                .Columns(.ColumnCount - 1).DataPropertyName = .Columns(.ColumnCount - 1).Name
                .Columns(.ColumnCount - 1).ReadOnly = True

                .Columns.Add(NameOf(_Model.CLOSE_FG), "Closed")
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

                .Columns.Add(NameOf(_Model.GEN_TANTO_NAME), "処置担当者")
                .Columns(.ColumnCount - 1).Width = 120
                .Columns(.ColumnCount - 1).DefaultCellStyle.Alignment = Windows.Forms.DataGridViewContentAlignment.MiddleLeft
                .Columns(.ColumnCount - 1).DataPropertyName = .Columns(.ColumnCount - 1).Name
                .Columns(.ColumnCount - 1).ReadOnly = True

                .Columns.Add(NameOf(_Model.TAIRYU_FG), "滞留フラグ")
                .Columns(.ColumnCount - 1).DataPropertyName = .Columns(.ColumnCount - 1).Name
                .Columns(.ColumnCount - 1).Visible = False

                .Columns.Add(NameOf(_Model.TAIRYU_NISSU), "滞留日数")
                .Columns(.ColumnCount - 1).Width = 80
                .Columns(.ColumnCount - 1).DefaultCellStyle.Alignment = Windows.Forms.DataGridViewContentAlignment.MiddleRight
                .Columns(.ColumnCount - 1).DataPropertyName = .Columns(.ColumnCount - 1).Name
                .Columns(.ColumnCount - 1).ReadOnly = True

                .Columns.Add(NameOf(_Model.KISYU_NAME), "機種")
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

                .Columns.Add(NameOf(_Model.JIZEN_SINSA_HANTEI_NAME), "事前判定区分")
                .Columns(.ColumnCount - 1).Width = 180
                .Columns(.ColumnCount - 1).DefaultCellStyle.Alignment = Windows.Forms.DataGridViewContentAlignment.MiddleLeft
                .Columns(.ColumnCount - 1).DataPropertyName = .Columns(.ColumnCount - 1).Name
                .Columns(.ColumnCount - 1).ReadOnly = True

                .Columns.Add(NameOf(_Model.SAISIN_IINKAI_HANTEI_NAME), "再審判定区分")
                .Columns(.ColumnCount - 1).Width = 180
                .Columns(.ColumnCount - 1).DefaultCellStyle.Alignment = Windows.Forms.DataGridViewContentAlignment.MiddleLeft
                .Columns(.ColumnCount - 1).DataPropertyName = .Columns(.ColumnCount - 1).Name
                .Columns(.ColumnCount - 1).ReadOnly = True

                .Columns.Add(NameOf(_Model.KISO_YMD), "起草日")
                .Columns(.ColumnCount - 1).Width = 180
                .Columns(.ColumnCount - 1).DefaultCellStyle.Alignment = Windows.Forms.DataGridViewContentAlignment.MiddleLeft
                .Columns(.ColumnCount - 1).DataPropertyName = .Columns(.ColumnCount - 1).Name
                .Columns(.ColumnCount - 1).ReadOnly = True

                .Columns.Add(NameOf(_Model.SYONIN_YMDHNS), "前処理実施日")
                .Columns(.ColumnCount - 1).Width = 180
                .Columns(.ColumnCount - 1).DefaultCellStyle.Alignment = Windows.Forms.DataGridViewContentAlignment.MiddleLeft
                .Columns(.ColumnCount - 1).DataPropertyName = .Columns(.ColumnCount - 1).Name
                .Columns(.ColumnCount - 1).ReadOnly = True

                .Columns.Add(NameOf(_Model.SASIMOTO_SYONIN_JUN), "差戻承認順")
                .Columns(.ColumnCount - 1).DataPropertyName = .Columns(.ColumnCount - 1).Name
                .Columns(.ColumnCount - 1).Visible = False


                .Columns.Add(NameOf(_Model.SASIMOTO_SYONIN_NAIYO), "差戻元ステージ")
                .Columns(.ColumnCount - 1).Width = 180
                .Columns(.ColumnCount - 1).DefaultCellStyle.Alignment = Windows.Forms.DataGridViewContentAlignment.MiddleLeft
                .Columns(.ColumnCount - 1).DataPropertyName = .Columns(.ColumnCount - 1).Name
                .Columns(.ColumnCount - 1).ReadOnly = True

                .Columns.Add(NameOf(_Model.RIYU), "差戻理由")
                .Columns(.ColumnCount - 1).Width = 180
                .Columns(.ColumnCount - 1).DefaultCellStyle.Alignment = Windows.Forms.DataGridViewContentAlignment.MiddleLeft
                .Columns(.ColumnCount - 1).DataPropertyName = .Columns(.ColumnCount - 1).Name
                .Columns(.ColumnCount - 1).ReadOnly = True

                .Columns.Add(NameOf(_Model.SASIMOTO_SYONIN_JUN), "差戻承認順")
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

                    If dgvDATA.CurrentRow IsNot Nothing Then
                        If MessageBox.Show("選択されたデータを削除しますか?", "削除確認", MessageBoxButtons.OKCancel, MessageBoxIcon.Information) = DialogResult.OK Then
                            Dim dr As DataRow = dgvDATA.GetDataRow()
                            If FunDEL(dr.Item("SYONIN_HOKOKUSYO_ID"), dr.Item("HOKOKU_NO")) = True Then
                                Call FunSRCH(dgvDATA, FunGetListData())
                            End If
                        End If
                    Else
                        MessageBox.Show("該当データが選択されていません。", "", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    End If

                Case 7 '全選択

                    Call FunSelectAll()

                Case 8 '全選択解除

                    Call FunUnSelectAll()

                Case 9 'メール送信

                    Dim dr As DataRow = dgvDATA.GetDataRow()

                    If dr IsNot Nothing Then
                        Dim strSubject As String = "【テスト】不適合管理システム テストメール"
                        Dim strBody As String = "送信テスト"

                        Dim strSyainName As String = Fun_GetUSER_NAME(dr.Item("GEN_TANTO_ID"))

                        If MessageBox.Show(strSyainName & "さんに確認メールを送信します。" & vbCrLf & "", "", MessageBoxButtons.OKCancel, MessageBoxIcon.Information) = DialogResult.OK Then
                            Call FunSendMailFutekigo(strSubject, strBody, dr.Item("GEN_TANTO_ID"))
                        End If
                    End If

                Case 10  '印刷
                    Call FunOpenReport()

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

            'SPEC: PF01.2-(1) A 検索条件

#Region "old 検索条件"

            'Dim sbSQL As New System.Text.StringBuilder
            'Dim dsList As New DataSet
            'Dim sbParam As New System.Text.StringBuilder

            '#Region "           共通検索条件"

            '            '部門、機種、部品番号、部品名称 パラメータ

            '            '社内CD
            '            If mtxSyanaiCD.Text.IsNullOrWhiteSpace Then
            '            Else
            '                sbSQLWHERE.Append(IIf(sbSQLWHERE.Length = 0, " WHERE ", " AND "))
            '                sbSQLWHERE.Append("SYANAI_CD LIKE '%" & mtxSyanaiCD.Text & "%'")
            '            End If

            '            '号機
            '            If mtxGOUKI.Text.IsNullOrWhiteSpace Then
            '            Else
            '                sbSQLWHERE.Append(IIf(sbSQLWHERE.Length = 0, " WHERE ", " AND "))
            '                sbSQLWHERE.Append("GOUKI LIKE '%" & mtxGOUKI.Text & "%'")
            '            End If

            '            '現処置担当者
            '            If cmbTANTO.SelectedValue <> "" Then
            '                sbSQLWHERE.Append(IIf(sbSQLWHERE.Length = 0, " WHERE ", " AND "))
            '                sbSQLWHERE.Append("SYOCHI_SYAIN_ID = " & cmbTANTO.SelectedValue)
            '            Else
            '            End If

            '            '処置実施日
            '            If dtJisiFrom.Text.IsNullOrWhiteSpace Then
            '            Else
            '                sbSQLWHERE.Append(IIf(sbSQLWHERE.Length = 0, " WHERE ", " AND "))
            '                sbSQLWHERE.Append("SYOCHI_YMD <= '" & dtJisiFrom.ValueDate.ToString("yyyyMMdd") & "'")
            '            End If
            '            If dtJisiTo.Text.IsNullOrWhiteSpace Then
            '            Else
            '                sbSQLWHERE.Append(IIf(sbSQLWHERE.Length = 0, " WHERE ", " AND "))
            '                sbSQLWHERE.Append("SYOCHI_YMD > '" & dtJisiFrom.ValueDate.ToString("yyyyMMdd") & "'")
            '            End If

            '            '報告書No パラメータ


            '            '起草者
            '            If cmbADD_TANTO.SelectedValue <> "" Then
            '                sbSQLWHERE.Append(IIf(sbSQLWHERE.Length = 0, " WHERE ", " AND "))
            '                sbSQLWHERE.Append(" AND ADD_SYAIN_ID = " & cmbADD_TANTO.SelectedValue)
            '            Else
            '            End If

            '            'クローズ除く パラメータ

            '            '滞留を表示
            '            If chkTairyu.Checked Then
            '                sbSQLWHERE.Append(IIf(sbSQLWHERE.Length = 0, " WHERE ", " AND "))
            '                sbSQLWHERE.Append(" WHERE TAIRYU > 0")
            '            Else
            '            End If

            '            '不適合区分
            '            If cmbFUTEKIGO_KB.SelectedValue <> "" Then
            '                sbSQLWHERE.Append(IIf(sbSQLWHERE.Length = 0, " WHERE ", " AND "))
            '                sbSQLWHERE.Append(" AND FUTEKIGO_KB = '" & cmbFUTEKIGO_KB.SelectedValue & "'")
            '            Else
            '            End If

            '            '不適合詳細区分
            '            If cmbFUKEKIGO_S_KB.SelectedValue <> "" Then
            '                sbSQLWHERE.Append(IIf(sbSQLWHERE.Length = 0, " WHERE ", " AND "))
            '                sbSQLWHERE.Append(" AND FUKEKIGO_S_KB = '" & cmbFUKEKIGO_S_KB.SelectedValue & "'")
            '            Else
            '            End If

            '            '不適合状態区分
            '            If cmbFUTEKIGO_JYOTAI_KB.SelectedValue <> "" Then
            '                sbSQLWHERE.Append(IIf(sbSQLWHERE.Length = 0, " WHERE ", " AND "))
            '                sbSQLWHERE.Append(" AND FUTEKIGO_JYOTAI_KB = '" & cmbFUTEKIGO_JYOTAI_KB.SelectedValue & "'")
            '            Else
            '            End If

            '#End Region

            '#Region "           NCR検索条件"

            '            '事前審査判定 パラメータ

            '            '是正処置要否確認
            '            If cmbZESEI_SYOCHI_YOHI_KB.SelectedValue <> "" Then
            '                sbSQLWHERE.Append(IIf(sbSQLWHERE.Length = 0, " WHERE ", " AND "))
            '                sbSQLWHERE.Append(" AND ZESEI_SYOCHI_YOHI_KB = '" & cmbZESEI_SYOCHI_YOHI_KB.SelectedValue & "'")
            '            Else
            '            End If

            '            '再審委員会判定 パラメータ

            '            '顧客判定指示 
            '            If cmbKOKYAKU_HANTEI_SIJI_KB.SelectedValue <> "" Then
            '                sbSQLWHERE.Append(IIf(sbSQLWHERE.Length = 0, " WHERE ", " AND "))
            '                sbSQLWHERE.Append(" AND KOKYAKU_HANTEI_SIJI_KB = '" & cmbKOKYAKU_HANTEI_SIJI_KB.SelectedValue & "'")
            '            Else
            '            End If

            '            '顧客最終判定区分
            '            If cmbKOKYAKU_SAISYU_HANTEI_KB.SelectedValue <> "" Then
            '                sbSQLWHERE.Append(IIf(sbSQLWHERE.Length = 0, " WHERE ", " AND "))
            '                sbSQLWHERE.Append(" AND KOKYAKU_SAISYU_HANTEI_KB = '" & cmbKOKYAKU_SAISYU_HANTEI_KB.SelectedValue & "'")
            '            Else
            '            End If

            '            '検査結果 
            '            If cmbKENSA_KEKKA_KB.SelectedValue <> "" Then
            '                sbSQLWHERE.Append(IIf(sbSQLWHERE.Length = 0, " WHERE ", " AND "))
            '                sbSQLWHERE.Append(" AND KENSA_KEKKA_KB = '" & cmbKENSA_KEKKA_KB.SelectedValue & "'")
            '            Else
            '            End If

            '#End Region

            '#Region "           CAR検索条件"

            '            '要因1
            '            '要因2
            '            '作業者名


            '            '帰責工程
            '            If cmbKISEKI_KOTEI_KB.SelectedValue <> "" Then
            '                sbSQLWHERE.Append(IIf(sbSQLWHERE.Length = 0, " WHERE ", " AND "))
            '                sbSQLWHERE.Append(" AND KISEKI_KOTEI_KB = '" & cmbKISEKI_KOTEI_KB.SelectedValue & "'")
            '            Else
            '            End If

            '#End Region
#End Region

            Dim dtBUFF As DataTable = FunGetDtST02_FUTEKIGO_ICHIRAN(ParamModel)
            If dtBUFF Is Nothing Then Return Nothing
            If dtBUFF.Rows.Count > pub_APP_INFO.intSEARCHMAX Then
                If MessageBox.Show(My.Resources.infoSearchCountOver, "", MessageBoxButtons.YesNo, MessageBoxIcon.Information) = Windows.Forms.DialogResult.No Then
                    Return Nothing
                End If
            End If

            '------DataTableに変換
            Dim dt As New DataTable

            Dim t As Type = GetType(MODEL.ST02_FUTEKIGO_ICHIRAN)
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

            With dtBUFF
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
                                            Case 8 'yyyyMMdd
                                                Trow(p.Name) = DateTime.ParseExact(row.Item(p.Name), "yyyyMMdd", Nothing)
                                            Case 14 'yyyyMMddHHmmss
                                                Trow(p.Name) = DateTime.ParseExact(row.Item(p.Name), "yyyyMMddHHmmss", Nothing)
                                            Case Else
                                                'Err
                                                Trow(p.Name) = Nothing
                                        End Select
                                    End If
                                Case Else
                                    Trow(p.Name) = row.Item(p.Name).ToString.Trim
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

            If dgv.RowCount > 0 Then
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
        Dim _Model As New MODEL.ST02_FUTEKIGO_ICHIRAN
        Try
            For i As Integer = 0 To dgv.Rows.Count - 1
                If dgvDATA.Rows(i).Cells(NameOf(_Model.TAIRYU_FG)).Value = 1 Then
                    Me.dgvDATA.Rows(i).DefaultCellStyle.BackColor = clrWarningCellBackColor
                End If

                If dgvDATA.Rows(i).Cells(NameOf(_Model.SASIMOTO_SYONIN_JUN)).Value > 0 Then
                    Me.dgvDATA.Rows(i).DefaultCellStyle.BackColor = clrCautionCellBackColor
                End If

                If Me.dgvDATA.Rows(i).Cells(NameOf(_Model.CLOSE_FG)).Value > 0 Then
                    Me.dgvDATA.Rows(i).DefaultCellStyle.ForeColor = clrDeletedRowForeColor
                    Me.dgvDATA.Rows(i).DefaultCellStyle.BackColor = clrDeletedRowBackColor
                    Me.dgvDATA.Rows(i).DefaultCellStyle.SelectionForeColor = clrDeletedRowForeColor
                End If
            Next i
        Catch ex As Exception
            EM.ErrorSyori(ex, False, conblnNonMsg)
        Finally
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
            If intMODE = ENM_DATA_OPERATION_MODE._3_UPDATE AndAlso dgvDATA.CurrentRow.Cells(5).Value = "CAR" Then

                dlgRET = frmCAR.ShowDialog(Me)

                If dlgRET = Windows.Forms.DialogResult.Cancel Then
                    Return False
                Else

                End If
            Else
                frmDLG.PrMODE = intMODE
                If dgvDATA.CurrentRow IsNot Nothing Then
                    frmDLG.PrDataRow = dgvDATA.GetDataRow()
                Else
                    frmDLG.PrDataRow = Nothing
                End If
                dlgRET = frmDLG.ShowDialog(Me)

                If dlgRET = Windows.Forms.DialogResult.Cancel Then
                    Return False
                Else

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

    Private Function FunDEL(ByVal intSYONIN_HOKOKUSYO_ID As Integer, ByVal strHOKOKU_NO As String) As Boolean
        Dim sbSQL As New System.Text.StringBuilder

        Try

            '-----UPDATE
            sbSQL.Remove(0, sbSQL.Length)
            Select Case intSYONIN_HOKOKUSYO_ID
                Case ENM_SYONIN_HOKOKUSYO_ID._1_NCR
                    sbSQL.Append("UPDATE " & NameOf(MODEL.D003_NCR_J) & " SET")
                Case ENM_SYONIN_HOKOKUSYO_ID._2_CAR
                    sbSQL.Append("UPDATE " & NameOf(MODEL.D005_CAR_J) & " SET")
            End Select
            sbSQL.Append(" DEL_SYAIN_ID=" & pub_SYAIN_INFO.SYAIN_ID & "")
            sbSQL.Append(" ,DEL_YMDHNS=dbo.GetSysDateString()")
            sbSQL.Append(" ," & NameOf(_R001_HOKOKU_SOUSA.ADD_YMDHNS))
            sbSQL.Append(" ," & NameOf(_R001_HOKOKU_SOUSA.SYONIN_JUN))
            sbSQL.Append(" ," & NameOf(_R001_HOKOKU_SOUSA.SOUSA_KB))
            sbSQL.Append(" WHERE SYONIN_HOKOKUSYO_ID=" & intSYONIN_HOKOKUSYO_ID & "")
            sbSQL.Append(" AND HOKOKU_NO='" & strHOKOKU_NO & "'")
            sbSQL.Append(")")


            'CHECK: 一覧削除ボタン D004やR001等の編集履歴はどうするか

            '-----SQL実行
            Using DB As ClsDbUtility = DBOpen()
                Dim sqlEx As New Exception
                Dim blnErr As Boolean
                Dim intRET As Integer
                Try
                    intRET = DB.ExecuteNonQuery(sbSQL.ToString, conblnNonMsg, sqlEx)
                    If intRET <> 1 Then
                        '-----エラーログ出力
                        Dim strErrMsg As String = My.Resources.ErrLogSqlExecutionFailure & sbSQL.ToString & "|" & sqlEx.Message
                        WL.WriteLogDat(strErrMsg)
                        blnErr = True
                        Return False
                    End If
                Finally
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

#Region "全選択"

    Private Function FunSelectAll() As Boolean

        Try
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

#Region "印刷"
    Private Function FunOpenReport() As Boolean
        Dim strOutputFileName As String
        Dim strTEMPFILE As String
        'Dim intRET As Integer
        Try
            Dim strHOKOKU_NO As String = dgvDATA.GetDataRow().Item("HOKOKU_NO")

            Select Case dgvDATA.GetDataRow().Item("SYONIN_HOKOKUSYO_ID")
                Case ENM_SYONIN_HOKOKUSYO_ID._1_NCR
                    'ファイル名
                    strOutputFileName = "NCR_" & _D003_NCR_J.HOKOKU_NO & "_Work.xlsx"

                    '既存ファイル削除
                    If FunDELETE_FILE(pub_APP_INFO.strOUTPUT_PATH & strOutputFileName) = False Then
                        Return False
                    End If

                    Using iniIF As New IniFile(FunGetRootPath() & "\INI\" & CON_TEMPLATE_INI)
                        strTEMPFILE = FunConvRootPath(iniIF.GetIniString("NCR", "FILEPATH"))
                    End Using

                    'エクセル出力ファイル用意
                    If OUT_EXCEL_READY(strTEMPFILE, pub_APP_INFO.strOUTPUT_PATH, strOutputFileName) = False Then
                        Return False
                    End If
                    '-----書込処理
                    If FunMakeReportNCR(pub_APP_INFO.strOUTPUT_PATH & strOutputFileName, strHOKOKU_NO) = False Then
                        Return False
                    End If
                Case ENM_SYONIN_HOKOKUSYO_ID._2_CAR
                    'ファイル名
                    strOutputFileName = "CAR_" & _D003_NCR_J.HOKOKU_NO & "_Work.xlsx"

                    '既存ファイル削除
                    If FunDELETE_FILE(pub_APP_INFO.strOUTPUT_PATH & strOutputFileName) = False Then
                        Return False
                    End If

                    Using iniIF As New IniFile(FunGetRootPath() & "\INI\" & CON_TEMPLATE_INI)
                        strTEMPFILE = FunConvRootPath(iniIF.GetIniString("CAR", "FILEPATH"))
                    End Using

                    'エクセル出力ファイル用意
                    If OUT_EXCEL_READY(strTEMPFILE, pub_APP_INFO.strOUTPUT_PATH, strOutputFileName) = False Then
                        Return False
                    End If
                    '-----書込処理
                    If FunMakeReportCAR(pub_APP_INFO.strOUTPUT_PATH & strOutputFileName, strHOKOKU_NO) = False Then
                        Return False
                    End If
                Case Else
                    'err
                    Return False
            End Select

            'Excel起動
            'Return FunOpenExcelApp(pub_APP_INFO.strOUTPUT_PATH & strOutputFileName)

        Catch ex As Exception
            EM.ErrorSyori(ex, False, conblnNonMsg)
            Return False
        Finally
            Me.PrPG_STATUS = ENM_PG_STATUS._2_ACTIVE
        End Try
    End Function

    Private Function FunMakeReportNCR(ByVal strFilePath As String, ByVal strHOKOKU_NO As String) As Boolean

        Dim ssgWorkbook As SpreadsheetGear.IWorkbook
        Dim ssgWorksheets As SpreadsheetGear.IWorksheets
        Dim ssgSheet1 As SpreadsheetGear.IWorksheet
        Dim ssgRangeFrom As SpreadsheetGear.IRange
        Dim ssgRangeTo As SpreadsheetGear.IRange

        Try

            Dim _V002_NCR_J As MODEL.V002_NCR_J = FunGetV002Model(strHOKOKU_NO)
            Dim _V003_SYONIN_J_KANRI_List As List(Of MODEL.V003_SYONIN_J_KANRI) = FunGetV003Model(ENM_SYONIN_HOKOKUSYO_ID._1_NCR, strHOKOKU_NO)

            ssgWorkbook = SpreadsheetGear.Factory.GetWorkbook(strFilePath, System.Globalization.CultureInfo.CurrentCulture)
            ssgWorkbook.WorkbookSet.GetLock()
            ssgWorksheets = ssgWorkbook.Worksheets
            ssgSheet1 = ssgWorksheets.Item(0) 'sheet1

            'レコードフレーム初期化
            'spWork.Range("RECORD_FRAME").ClearContents()
            ssgSheet1.Range(NameOf(_V002_NCR_J.BUHIN_BANGO)).Value = _V002_NCR_J.BUHIN_BANGO
            ssgSheet1.Range(NameOf(_V002_NCR_J.BUHIN_NAME)).Value = _V002_NCR_J.BUHIN_NAME
            ssgSheet1.Range(NameOf(_V002_NCR_J.FUTEKIGO_JYOTAI_KB) & _V002_NCR_J.FUTEKIGO_JYOTAI_KB).Value = "TRUE"
            ssgSheet1.Range(NameOf(_V002_NCR_J.FUTEKIGO_NAIYO)).Value = _V002_NCR_J.FUTEKIGO_NAIYO
            ssgSheet1.Range(NameOf(_V002_NCR_J.GOKI)).Value = _V002_NCR_J.GOKI
            ssgSheet1.Range(NameOf(_V002_NCR_J.HAIKYAKU_HOUHOU)).Value = "(その他の内容：" & _V002_NCR_J.HAIKYAKU_HOUHOU.PadRight(30) & ")"
            ssgSheet1.Range(NameOf(_V002_NCR_J.HAIKYAKU_KB_NAME)).Value = _V002_NCR_J.HAIKYAKU_KB_NAME
            ssgSheet1.Range(NameOf(_V002_NCR_J.HAIKYAKU_TANTO_NAME)).Value = _V002_NCR_J.HAIKYAKU_TANTO_NAME
            ssgSheet1.Range(NameOf(_V002_NCR_J.HAIKYAKU_YMD)).Value = _V002_NCR_J.HAIKYAKU_YMD
            ssgSheet1.Range(NameOf(_V002_NCR_J.HASSEI_KOTEI_GL_NAME)).Value = _V002_NCR_J.HASSEI_KOTEI_GL_NAME
            ssgSheet1.Range(NameOf(_V002_NCR_J.HASSEI_KOTEI_GL_YMD)).Value = _V002_NCR_J.HASSEI_KOTEI_GL_YMD
            ssgSheet1.Range(NameOf(_V002_NCR_J.HENKYAKU_BIKO)).Value = _V002_NCR_J.HENKYAKU_BIKO
            ssgSheet1.Range(NameOf(_V002_NCR_J.HENKYAKU_SAKI)).Value = _V002_NCR_J.HENKYAKU_SAKI
            ssgSheet1.Range(NameOf(_V002_NCR_J.HENKYAKU_TANTO_NAME)).Value = _V002_NCR_J.HENKYAKU_TANTO_NAME
            ssgSheet1.Range(NameOf(_V002_NCR_J.HENKYAKU_YMD)).Value = _V002_NCR_J.HENKYAKU_YMD
            ssgSheet1.Range(NameOf(_V002_NCR_J.HOKOKU_NO)).Value = _V002_NCR_J.HOKOKU_NO
            ssgSheet1.Range(NameOf(_V002_NCR_J.ITAG_NO)).Value = _V002_NCR_J.ITAG_NO
            ssgSheet1.Range(NameOf(_V002_NCR_J.JIZEN_SINSA_HANTEI_KB) & _V002_NCR_J.JIZEN_SINSA_HANTEI_KB).Value = "TRUE"
            ssgSheet1.Range(NameOf(_V002_NCR_J.JIZEN_SINSA_SYAIN_NAME)).Value = _V002_NCR_J.JIZEN_SINSA_SYAIN_NAME
            ssgSheet1.Range(NameOf(_V002_NCR_J.JIZEN_SINSA_YMD)).Value = _V002_NCR_J.JIZEN_SINSA_YMD
            ssgSheet1.Range(NameOf(_V002_NCR_J.KANSATU_KEKKA)).Value = _V002_NCR_J.KANSATU_KEKKA
            ssgSheet1.Range(NameOf(_V002_NCR_J.KENSA_KEKKA_NAME)).Value = _V002_NCR_J.KENSA_KEKKA_NAME
            ssgSheet1.Range(NameOf(_V002_NCR_J.KENSA_TANTO_NAME)).Value = _V002_NCR_J.KENSA_TANTO_NAME
            ssgSheet1.Range(NameOf(_V002_NCR_J.KISYU)).Value = _V002_NCR_J.KISYU
            ssgSheet1.Range(NameOf(_V002_NCR_J.KOKYAKU_HANTEI_SIJI_NAME)).Value = _V002_NCR_J.KOKYAKU_HANTEI_SIJI_NAME
            ssgSheet1.Range(NameOf(_V002_NCR_J.KOKYAKU_HANTEI_SIJI_YMD)).Value = _V002_NCR_J.KOKYAKU_HANTEI_SIJI_YMD
            ssgSheet1.Range(NameOf(_V002_NCR_J.SAIHATU)).Value = _V002_NCR_J.SAIHATU
            ssgSheet1.Range(NameOf(_V002_NCR_J.SAIKAKO_KENSA_YMD)).Value = _V002_NCR_J.SAIKAKO_KENSA_YMD
            ssgSheet1.Range(NameOf(_V002_NCR_J.SAIKAKO_SAGYO_KAN_YMD)).Value = _V002_NCR_J.SAIKAKO_SAGYO_KAN_YMD
            ssgSheet1.Range(NameOf(_V002_NCR_J.SAIKAKO_SIJI_NO)).Value = _V002_NCR_J.SAIKAKO_SIJI_NO
            ssgSheet1.Range(NameOf(_V002_NCR_J.SAISIN_GIJYUTU_SYAIN_NAME)).Value = _V002_NCR_J.SAISIN_GIJYUTU_SYAIN_NAME
            ssgSheet1.Range(NameOf(_V002_NCR_J.SAISIN_HINSYO_SYAIN_NAME)).Value = _V002_NCR_J.SAISIN_HINSYO_SYAIN_NAME
            ssgSheet1.Range(NameOf(_V002_NCR_J.SAISIN_HINSYO_YMD)).Value = _V002_NCR_J.SAISIN_HINSYO_YMD
            ssgSheet1.Range(NameOf(_V002_NCR_J.SAISIN_IINKAI_HANTEI_KB) & _V002_NCR_J.SAISIN_IINKAI_HANTEI_KB).Value = "TRUE"
            ssgSheet1.Range(NameOf(_V002_NCR_J.SAISIN_IINKAI_SIRYO_NO)).Value = _V002_NCR_J.SAISIN_IINKAI_SIRYO_NO
            ssgSheet1.Range(NameOf(_V002_NCR_J.SAISIN_KAKUNIN_SYAIN_NAME)).Value = _V002_NCR_J.SAISIN_KAKUNIN_SYAIN_NAME
            ssgSheet1.Range(NameOf(_V002_NCR_J.SAISIN_KAKUNIN_YMD)).Value = _V002_NCR_J.SAISIN_KAKUNIN_YMD
            ssgSheet1.Range(NameOf(_V002_NCR_J.SEIGI_TANTO_NAME)).Value = _V002_NCR_J.SEIGI_TANTO_NAME
            ssgSheet1.Range(NameOf(_V002_NCR_J.SEIZO_TANTO_NAME)).Value = _V002_NCR_J.SEIZO_TANTO_NAME
            ssgSheet1.Range(NameOf(_V002_NCR_J.SURYO)).Value = _V002_NCR_J.SURYO
            ssgSheet1.Range(NameOf(_V002_NCR_J.SYOCHI_D_SYOCHI_KIROKU)).Value = _V002_NCR_J.SYOCHI_D_SYOCHI_KIROKU
            ssgSheet1.Range(NameOf(_V002_NCR_J.SYOCHI_D_UMU_NAME)).Value = _V002_NCR_J.SYOCHI_D_UMU_NAME
            ssgSheet1.Range(NameOf(_V002_NCR_J.SYOCHI_D_YOHI_NAME)).Value = _V002_NCR_J.SYOCHI_D_YOHI_NAME
            ssgSheet1.Range(NameOf(_V002_NCR_J.SYOCHI_E_SYOCHI_KIROKU)).Value = _V002_NCR_J.SYOCHI_E_SYOCHI_KIROKU
            ssgSheet1.Range(NameOf(_V002_NCR_J.SYOCHI_E_UMU_NAME)).Value = _V002_NCR_J.SYOCHI_E_UMU_NAME
            ssgSheet1.Range(NameOf(_V002_NCR_J.SYOCHI_E_YOHI_NAME)).Value = _V002_NCR_J.SYOCHI_E_YOHI_NAME
            ssgSheet1.Range(NameOf(_V002_NCR_J.SYOCHI_KEKKA_A_NAME)).Value = _V002_NCR_J.SYOCHI_KEKKA_A_NAME
            ssgSheet1.Range(NameOf(_V002_NCR_J.SYOCHI_KEKKA_B_NAME)).Value = _V002_NCR_J.SYOCHI_KEKKA_B_NAME
            ssgSheet1.Range(NameOf(_V002_NCR_J.SYOCHI_KEKKA_C_NAME)).Value = _V002_NCR_J.SYOCHI_KEKKA_C_NAME
            ssgSheet1.Range(NameOf(_V002_NCR_J.TENYO_BUHIN_BANGO)).Value = _V002_NCR_J.TENYO_BUHIN_BANGO
            ssgSheet1.Range(NameOf(_V002_NCR_J.TENYO_GOKI)).Value = _V002_NCR_J.TENYO_GOKI
            ssgSheet1.Range(NameOf(_V002_NCR_J.TENYO_KISYU)).Value = _V002_NCR_J.TENYO_KISYU
            ssgSheet1.Range(NameOf(_V002_NCR_J.TENYO_YMD)).Value = _V002_NCR_J.TENYO_YMD
            ssgSheet1.Range(NameOf(_V002_NCR_J.YOKYU_NAIYO)).Value = _V002_NCR_J.YOKYU_NAIYO
            ssgSheet1.Range(NameOf(_V002_NCR_J.ZUMEN_KIKAKU)).Value = "(図面/規格　： " & _V002_NCR_J.ZUMEN_KIKAKU.PadRight(50) & ")"

            ssgSheet1.Range("SYONIN_NAME10").Value = _V003_SYONIN_J_KANRI_List.Where(Function(r) r.SYONIN_JUN = ENM_NCR_STAGE._10_起草入力).FirstOrDefault?.SYAIN_NAME
            ssgSheet1.Range("SYONIN_NAME20").Value = _V003_SYONIN_J_KANRI_List.Where(Function(r) r.SYONIN_JUN = ENM_NCR_STAGE._20_起草確認製造GL).FirstOrDefault?.SYAIN_NAME
            ssgSheet1.Range("SYONIN_NAME30").Value = _V003_SYONIN_J_KANRI_List.Where(Function(r) r.SYONIN_JUN = ENM_NCR_STAGE._30_起草確認検査).FirstOrDefault?.SYAIN_NAME
            ssgSheet1.Range("SYONIN_NAME90").Value = _V003_SYONIN_J_KANRI_List.Where(Function(r) r.SYONIN_JUN = ENM_NCR_STAGE._90_処置実施確認_管理T).FirstOrDefault?.SYAIN_NAME
            ssgSheet1.Range("SYONIN_NAME100").Value = _V003_SYONIN_J_KANRI_List.Where(Function(r) r.SYONIN_JUN = ENM_NCR_STAGE._100_処置実施決裁_製造課長).FirstOrDefault?.SYAIN_NAME
            ssgSheet1.Range("SYONIN_NAME110").Value = _V003_SYONIN_J_KANRI_List.Where(Function(r) r.SYONIN_JUN = ENM_NCR_STAGE._110_abcde処置担当).FirstOrDefault?.SYAIN_NAME
            ssgSheet1.Range("SYONIN_NAME120").Value = _V003_SYONIN_J_KANRI_List.Where(Function(r) r.SYONIN_JUN = ENM_NCR_STAGE._120_abcde処置確認).FirstOrDefault?.SYAIN_NAME
            ssgSheet1.Range("SYONIN_YMD20").Value = _V003_SYONIN_J_KANRI_List.Where(Function(r) r.SYONIN_JUN = ENM_NCR_STAGE._20_起草確認製造GL And r.SYONIN_HANTEI_KB = ENM_SYONIN_HANTEI_KB._1_承認).FirstOrDefault?.SYONIN_YMDHNS
            ssgSheet1.Range("SYONIN_YMD30").Value = _V003_SYONIN_J_KANRI_List.Where(Function(r) r.SYONIN_JUN = ENM_NCR_STAGE._30_起草確認検査 And r.SYONIN_HANTEI_KB = ENM_SYONIN_HANTEI_KB._1_承認).FirstOrDefault?.SYONIN_YMDHNS
            ssgSheet1.Range("SYONIN_YMD90").Value = _V003_SYONIN_J_KANRI_List.Where(Function(r) r.SYONIN_JUN = ENM_NCR_STAGE._90_処置実施確認_管理T And r.SYONIN_HANTEI_KB = ENM_SYONIN_HANTEI_KB._1_承認).FirstOrDefault?.SYONIN_YMDHNS
            ssgSheet1.Range("SYONIN_YMD100").Value = _V003_SYONIN_J_KANRI_List.Where(Function(r) r.SYONIN_JUN = ENM_NCR_STAGE._100_処置実施決裁_製造課長 And r.SYONIN_HANTEI_KB = ENM_SYONIN_HANTEI_KB._1_承認).FirstOrDefault?.SYONIN_YMDHNS
            ssgSheet1.Range("SYONIN_YMD110").Value = _V003_SYONIN_J_KANRI_List.Where(Function(r) r.SYONIN_JUN = ENM_NCR_STAGE._110_abcde処置担当 And r.SYONIN_HANTEI_KB = ENM_SYONIN_HANTEI_KB._1_承認).FirstOrDefault?.SYONIN_YMDHNS

            '-----SpereasheetGera印刷
            Dim ssgPrintDocument As SpreadsheetGear.Drawing.Printing.WorkbookPrintDocument = New SpreadsheetGear.Drawing.Printing.WorkbookPrintDocument(ssgSheet1, SpreadsheetGear.Printing.PrintWhat.Sheet)
            'printDocument.PrinterSettings.PrinterName = "PrinterName"
            ssgPrintDocument.Print()

            '-----ファイル保存
            'spWork.Delete()
            'spWorksheets(0).Cells("A1").Select()
            ssgSheet1.SaveAs(filename:=strFilePath, fileFormat:=SpreadsheetGear.FileFormat.OpenXMLWorkbook)
            ssgWorkbook.WorkbookSet.ReleaseLock()

            '-----Spire版 直接PDF発行するならこっち
            'Dim workbook As New Spire.Xls.Workbook
            'workbook.LoadFromFile(strFilePath)
            'Dim pdfFilePath As String
            'pdfFilePath = System.IO.Path.GetDirectoryName(strFilePath) & "\" & System.IO.Path.GetFileNameWithoutExtension(strFilePath) & ".pdf"
            'workbook.SaveToFile(pdfFilePath, Spire.Xls.FileFormat.PDF)

            ''Spire PDF編集
            ''Dim pdfDoc As New Spire.Pdf.PdfDocument
            ''pdfDoc.PageSettings.Orientation = Spire.Pdf.PdfPageOrientation.Landscape
            ''pdfDoc.PageSettings.Width = "970"
            ''pdfDoc.PageSettings.Height = "850"

            ''PDF表示
            'System.Diagnostics.Process.Start(pdfFilePath)

            'Excel作業ファイルを削除
            Try
                System.IO.File.Delete(strFilePath)
            Catch ex As UnauthorizedAccessException
            End Try

            Return True

        Catch ex As Exception
            EM.ErrorSyori(ex, False, conblnNonMsg)
            Return False
        Finally
            ssgRangeFrom = Nothing
            ssgRangeTo = Nothing
            ssgSheet1 = Nothing
            ssgWorksheets = Nothing
            ssgWorkbook = Nothing
        End Try
    End Function

    Private Function FunMakeReportCAR(ByVal strFilePath As String, ByVal strHOKOKU_NO As String) As Boolean

        Dim spWorkbook As SpreadsheetGear.IWorkbook
        Dim spWorksheets As SpreadsheetGear.IWorksheets
        Dim spSheet1 As SpreadsheetGear.IWorksheet
        Dim spRangeFrom As SpreadsheetGear.IRange
        Dim spRangeTo As SpreadsheetGear.IRange

        Try
            spWorkbook = SpreadsheetGear.Factory.GetWorkbook(strFilePath, System.Globalization.CultureInfo.CurrentCulture)

            spWorkbook.WorkbookSet.GetLock()
            spWorksheets = spWorkbook.Worksheets
            spSheet1 = spWorksheets.Item(0) 'sheet1

            Dim spprint As SpreadsheetGear.Printing.PrintWhat = SpreadsheetGear.Printing.PrintWhat.Sheet


            'レコードフレーム初期化

            Dim _V005_CAR_J As MODEL.V005_CAR_J = FunGetV005Model(strHOKOKU_NO)

            spSheet1.Range(NameOf(_V005_CAR_J.GOKI)).Value = _V005_CAR_J.GOKI
            spSheet1.Range(NameOf(_V005_CAR_J.HOKOKU_NO)).Value = _V005_CAR_J.HOKOKU_NO
            spSheet1.Range(NameOf(_V005_CAR_J.KAITO_1)).Value = _V005_CAR_J.KAITO_1
            spSheet1.Range(NameOf(_V005_CAR_J.KAITO_2)).Value = _V005_CAR_J.KAITO_2
            spSheet1.Range(NameOf(_V005_CAR_J.KAITO_3)).Value = _V005_CAR_J.KAITO_3
            spSheet1.Range(NameOf(_V005_CAR_J.KAITO_4)).Value = _V005_CAR_J.KAITO_4
            spSheet1.Range(NameOf(_V005_CAR_J.KAITO_5)).Value = _V005_CAR_J.KAITO_5
            spSheet1.Range(NameOf(_V005_CAR_J.KAITO_6)).Value = _V005_CAR_J.KAITO_6
            spSheet1.Range(NameOf(_V005_CAR_J.KAITO_7)).Value = _V005_CAR_J.KAITO_7
            spSheet1.Range(NameOf(_V005_CAR_J.KAITO_8)).Value = _V005_CAR_J.KAITO_8
            spSheet1.Range(NameOf(_V005_CAR_J.KAITO_9)).Value = _V005_CAR_J.KAITO_9
            spSheet1.Range(NameOf(_V005_CAR_J.KAITO_10)).Value = _V005_CAR_J.KAITO_10
            spSheet1.Range(NameOf(_V005_CAR_J.KAITO_11)).Value = _V005_CAR_J.KAITO_11
            spSheet1.Range(NameOf(_V005_CAR_J.KAITO_12)).Value = _V005_CAR_J.KAITO_12
            spSheet1.Range(NameOf(_V005_CAR_J.KAITO_13)).Value = _V005_CAR_J.KAITO_13
            If CBool(_V005_CAR_J.KAITO_14) Then
                spSheet1.Range(NameOf(_V005_CAR_J.KAITO_14) & "_YOU").Value = "TRUE"
            Else
                spSheet1.Range(NameOf(_V005_CAR_J.KAITO_14) & "_HI").Value = "TRUE"
            End If
            spSheet1.Range(NameOf(_V005_CAR_J.KAITO_15)).Value = _V005_CAR_J.KAITO_15
            spSheet1.Range(NameOf(_V005_CAR_J.KAITO_16)).Value = _V005_CAR_J.KAITO_16
            spSheet1.Range(NameOf(_V005_CAR_J.KAITO_17)).Value = _V005_CAR_J.KAITO_17
            spSheet1.Range(NameOf(_V005_CAR_J.KAITO_18)).Value = _V005_CAR_J.KAITO_18
            spSheet1.Range(NameOf(_V005_CAR_J.KAITO_19)).Value = _V005_CAR_J.KAITO_19
            spSheet1.Range(NameOf(_V005_CAR_J.KAITO_20)).Value = _V005_CAR_J.KAITO_20
            spSheet1.Range(NameOf(_V005_CAR_J.KAITO_21)).Value = _V005_CAR_J.KAITO_21
            spSheet1.Range(NameOf(_V005_CAR_J.KAITO_22)).Value = _V005_CAR_J.KAITO_22
            spSheet1.Range(NameOf(_V005_CAR_J.KAITO_23)).Value = _V005_CAR_J.KAITO_23
            spSheet1.Range(NameOf(_V005_CAR_J.KAITO_24)).Value = _V005_CAR_J.KAITO_24
            spSheet1.Range(NameOf(_V005_CAR_J.KAITO_25)).Value = _V005_CAR_J.KAITO_25

            spSheet1.Range(NameOf(_V005_CAR_J.KENSA_GL_SYAIN_NAME)).Value = _V005_CAR_J.KENSA_GL_SYAIN_NAME
            spSheet1.Range(NameOf(_V005_CAR_J.KENSA_GL_YMDHNS)).Value = _V005_CAR_J.KENSA_GL_YMDHNS
            spSheet1.Range(NameOf(_V005_CAR_J.KENSA_TANTO_NAME)).Value = _V005_CAR_J.KENSA_TANTO_NAME
            spSheet1.Range(NameOf(_V005_CAR_J.KENSA_TOROKU_YMDHNS)).Value = _V005_CAR_J.KENSA_TOROKU_YMDHNS
            spSheet1.Range(NameOf(_V005_CAR_J.KISYU)).Value = _V005_CAR_J.KISYU
            spSheet1.Range(NameOf(_V005_CAR_J.SYOCHI_A_SYAIN_NAME)).Value = _V005_CAR_J.SYOCHI_A_SYAIN_NAME
            spSheet1.Range(NameOf(_V005_CAR_J.SYOCHI_A_YMDHNS)).Value = _V005_CAR_J.SYOCHI_A_YMDHNS
            spSheet1.Range(NameOf(_V005_CAR_J.SYOCHI_B_SYAIN_NAME)).Value = _V005_CAR_J.SYOCHI_B_SYAIN_NAME
            spSheet1.Range(NameOf(_V005_CAR_J.SYOCHI_B_YMDHNS)).Value = _V005_CAR_J.SYOCHI_B_YMDHNS
            spSheet1.Range(NameOf(_V005_CAR_J.SYOCHI_C_SYAIN_NAME)).Value = _V005_CAR_J.SYOCHI_C_SYAIN_NAME
            spSheet1.Range(NameOf(_V005_CAR_J.SYOCHI_C_YMDHNS)).Value = _V005_CAR_J.SYOCHI_C_YMDHNS
            spSheet1.Range("SYONIN_NAME10").Value = _V005_CAR_J.GOKI
            spSheet1.Range("SYONIN_NAME20").Value = _V005_CAR_J.GOKI
            spSheet1.Range("SYONIN_NAME30").Value = _V005_CAR_J.GOKI
            spSheet1.Range("SYONIN_NAME40").Value = _V005_CAR_J.GOKI
            spSheet1.Range("SYONIN_NAME50").Value = _V005_CAR_J.GOKI
            spSheet1.Range("SYONIN_NAME60").Value = _V005_CAR_J.GOKI
            spSheet1.Range("SYONIN_NAME90").Value = _V005_CAR_J.GOKI
            spSheet1.Range("SYONIN_NAME100").Value = _V005_CAR_J.GOKI
            spSheet1.Range("SYONIN_NAME120").Value = _V005_CAR_J.GOKI
            spSheet1.Range("SYONIN_YMD10").Value = _V005_CAR_J.GOKI
            spSheet1.Range("SYONIN_YMD20").Value = _V005_CAR_J.GOKI
            spSheet1.Range("SYONIN_YMD30").Value = _V005_CAR_J.GOKI
            spSheet1.Range("SYONIN_YMD40").Value = _V005_CAR_J.GOKI
            spSheet1.Range("SYONIN_YMD50").Value = _V005_CAR_J.GOKI
            spSheet1.Range("SYONIN_YMD60").Value = _V005_CAR_J.GOKI
            spSheet1.Range("SYONIN_YMD90").Value = _V005_CAR_J.GOKI
            spSheet1.Range("SYONIN_YMD100").Value = _V005_CAR_J.GOKI
            spSheet1.Range("SYONIN_YMD120").Value = _V005_CAR_J.GOKI
            spSheet1.Range(NameOf(_V005_CAR_J.SYOSAI_FILE_PATH)).Value = _V005_CAR_J.SYOSAI_FILE_PATH
            spSheet1.Range(NameOf(_V005_CAR_J.ZESEI_SYOCHI_YUKO_UMU_NAME)).Value = _V005_CAR_J.ZESEI_SYOCHI_YUKO_UMU_NAME

            '-----SpereasheetGera印刷
            Dim ssgPrintDocument As SpreadsheetGear.Drawing.Printing.WorkbookPrintDocument = New SpreadsheetGear.Drawing.Printing.WorkbookPrintDocument(spSheet1, SpreadsheetGear.Printing.PrintWhat.Sheet)
            'printDocument.PrinterSettings.PrinterName = "PrinterName"
            ssgPrintDocument.Print()

            '-----ファイル保存
            'spWork.Delete()
            'spWorksheets(0).Cells("A1").Select()
            spSheet1.SaveAs(filename:=strFilePath, fileFormat:=SpreadsheetGear.FileFormat.OpenXMLWorkbook)
            spWorkbook.WorkbookSet.ReleaseLock()

            '-----Spire版 直接PDF発行するならこっち
            'Dim workbook As New Spire.Xls.Workbook
            'workbook.LoadFromFile(strFilePath)
            'Dim pdfFilePath As String
            'pdfFilePath = System.IO.Path.GetDirectoryName(strFilePath) & "\" & System.IO.Path.GetFileNameWithoutExtension(strFilePath) & ".pdf"
            'workbook.SaveToFile(pdfFilePath, Spire.Xls.FileFormat.PDF)

            ''Spire PDF編集
            ''Dim pdfDoc As New Spire.Pdf.PdfDocument
            ''pdfDoc.PageSettings.Orientation = Spire.Pdf.PdfPageOrientation.Landscape
            ''pdfDoc.PageSettings.Width = "970"
            ''pdfDoc.PageSettings.Height = "850"

            ''PDF表示
            'System.Diagnostics.Process.Start(pdfFilePath)

            'Excel作業ファイルを削除
            Try
                System.IO.File.Delete(strFilePath)
            Catch ex As UnauthorizedAccessException
            End Try

            Return True

        Catch ex As Exception
            EM.ErrorSyori(ex, False, conblnNonMsg)
            Return False
        Finally
            spRangeFrom = Nothing
            spRangeTo = Nothing
            spSheet1 = Nothing
            spWorksheets = Nothing
            spWorkbook = Nothing

        End Try
    End Function

#End Region

#Region "履歴"
    Private Function OpenFormRIREKI() As Boolean
        Dim frmDLG As New FrmG0017
        Dim dlgRET As DialogResult

        Try

            If dgvDATA.CurrentRow IsNot Nothing Then
                frmDLG.PrSYONIN_HOKOKUSYO_ID = dgvDATA.GetDataRow().Item("SYONIN_HOKOKUSYO_ID")
                frmDLG.PrHOKOKU_NO = dgvDATA.GetDataRow().Item("HOKOKU_NO")
            Else
                'parameter error
                Return False
            End If
            dlgRET = frmDLG.ShowDialog(Me)

            If dlgRET = Windows.Forms.DialogResult.Cancel Then
                Return False
            Else
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
                    If .Text.Length = 0 OrElse .Text.Substring(0, .Text.IndexOf("(")).IsNullOrWhiteSpace Then
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
                If dgvDATA.CurrentRow.Cells.Item(NameOf(_D003_NCR_J.CLOSE_FG)).Value = 1 Then
                    cmdFunc4.Enabled = False
                    cmdFunc5.Enabled = False
                    MyBase.ToolTip.SetToolTip(Me.cmdFunc4, "クローズ済のため変更出来ません")
                    MyBase.ToolTip.SetToolTip(Me.cmdFunc5, "クローズ済のため削除出来ません")
                Else
                    MyBase.ToolTip.SetToolTip(Me.cmdFunc4, My.Resources.infoToolTipMsgNotFoundData)
                    MyBase.ToolTip.SetToolTip(Me.cmdFunc5, My.Resources.infoToolTipMsgNotFoundData)
                End If

                '権限により
                Dim blnAllowKIHYO As Boolean = FunblnAllowKIHYO()
                Dim blnAllowSyonin As Boolean = FunblnAllowSyonin()

                cmdFunc2.Enabled = blnAllowKIHYO
                cmdFunc5.Enabled = blnAllowKIHYO
                cmdFunc4.Enabled = FunblnAllowSyonin()
                cmdFunc9.Enabled = FunblnAllowSyonin()


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

    '検索フィルタ変更時
    Private Sub SearchFilterValueChanged(sender As System.Object, e As System.EventArgs)
        '検索
        Me.cmdFunc1.PerformClick()

    End Sub

#Region "共通検索条件"
    '部門変更時
    Private Sub CmbBUMON_SelectedValueChanged(sender As Object, e As EventArgs) Handles cmbBUMON.SelectedValueChanged

        Select Case cmbBUMON.SelectedValue
            Case Context.ENM_BUMON_KB._4_LP.ToString
                lblSyanaiCD.Visible = True
                cmbSYANAI_CD.Visible = True
            Case Else
                lblSyanaiCD.Visible = False
                cmbSYANAI_CD.Visible = False
                ParamModel.SYANAI_CD = ""
        End Select
    End Sub
#End Region

#Region "CAR検索条件"

    Private Sub CmbYOIN1_SelectedValueChanged(sender As Object, e As EventArgs) Handles cmbYOIN1.SelectedValueChanged
        If cmbYOIN1.SelectedIndex > 0 Then
            mtxGENIN1_DISP.Enabled = True
            btnClearGenin1.Enabled = True
            btnSelectGenin1.Enabled = True
        Else
            mtxGENIN1_DISP.Enabled = False
            btnClearGenin1.Enabled = False
            btnSelectGenin1.Enabled = False
        End If
        PrGenin1.Clear()
        mtxGENIN1.Text = ""
        mtxGENIN1_DISP.Text = ""
    End Sub

    Private Sub CmbYOIN2_SelectedValueChanged(sender As Object, e As EventArgs) Handles cmbYOIN2.SelectedValueChanged
        If cmbYOIN2.SelectedIndex > 0 Then
            mtxGENIN2_DISP.Enabled = True
            btnClearGenin2.Enabled = True
            btnSelectGenin2.Enabled = True
        Else
            mtxGENIN2_DISP.Enabled = False
            btnClearGenin2.Enabled = False
            btnSelectGenin2.Enabled = False
        End If
        PrGenin2.Clear()
        mtxGENIN2.Text = ""
        mtxGENIN2_DISP.Text = ""
    End Sub

    '原因1クリア
    Private Sub BtnClearGenin1_Click(sender As Object, e As EventArgs) Handles btnClearGenin1.Click
        mtxGENIN1.Text = ""
        mtxGENIN1_DISP.Text = ""
        PrGenin1.Clear()
    End Sub

    '原因2クリア
    Private Sub BtnClearGenin2_Click(sender As Object, e As EventArgs) Handles btnClearGenin2.Click
        mtxGENIN2.Text = ""
        mtxGENIN2_DISP.Text = ""
        PrGenin2.Clear()
    End Sub

    '原因1区分選択画面呼び出し
    Private Sub BtnSelectGenin1_Click(sender As Object, e As EventArgs) Handles btnSelectGenin1.Click

        Dim frmDLG As New Form
        Dim dlgRET As DialogResult
        Try
            If cmbYOIN1.SelectedValue = 0 Then
                frmDLG = New FrmG0013
                DirectCast(frmDLG, FrmG0013).PrYOIN = (cmbYOIN1.SelectedValue, cmbYOIN1.Text)
                DirectCast(frmDLG, FrmG0013).PrSelectedList = PrGenin1
            Else
                frmDLG = New FrmG0014
                DirectCast(frmDLG, FrmG0014).PrYOIN = (cmbYOIN1.SelectedValue, cmbYOIN1.Text)
                DirectCast(frmDLG, FrmG0014).PrSelectedList = PrGenin1
            End If

            dlgRET = frmDLG.ShowDialog(Me)

            If dlgRET = Windows.Forms.DialogResult.Cancel Then
                Exit Sub
            Else
                '検索条件文字列作成
                Dim sbWhere As New System.Text.StringBuilder
                Dim strWhereBase As String = <sql><![CDATA[
                        EXISTS
                        (
                        SELECT HOKOKU_NO FROM D006_CAR_GENIN WHERE 
                        V007_NCR_CAR.HOKOKU_NO = D006_CAR_GENIN.HOKOKU_NO
                        {0}
                        )                            
                        ]]></sql>.Value.Trim


                mtxGENIN1_DISP.Text = ""
                If PrGenin1.Count > 0 Then
                    For Each item In PrGenin1
                        If mtxGENIN1_DISP.Text.IsNullOrWhiteSpace Then
                            mtxGENIN1_DISP.Text = item.ITEM_DISP
                        Else
                            mtxGENIN1_DISP.Text &= ", " & item.ITEM_DISP
                        End If

                        sbWhere.Append(" AND (GENIN_BUNSEKI_KB='" & item.ITEM_NAME & "' AND GENIN_BUNSEKI_S_KB='" & item.ITEM_VALUE & "')")

                    Next item
                    ParamModel.GENIN1 = String.Format(strWhereBase, sbWhere.ToString)
                Else
                    ParamModel.GENIN1 = ""
                End If
            End If


        Catch ex As Exception
            EM.ErrorSyori(ex, False, conblnNonMsg)
        Finally
            If frmDLG IsNot Nothing Then
                frmDLG.Dispose()
            End If
        End Try
    End Sub

    '原因2区分選択画面呼び出し
    Private Sub BtnSelectGenin2_Click(sender As Object, e As EventArgs) Handles btnSelectGenin2.Click
        Dim frmDLG As New Form
        Dim dlgRET As DialogResult
        Try
            If cmbYOIN2.SelectedValue = 0 Then
                frmDLG = New FrmG0013
                DirectCast(frmDLG, FrmG0013).PrYOIN = (cmbYOIN2.SelectedValue, cmbYOIN2.Text)
                DirectCast(frmDLG, FrmG0013).PrSelectedList = PrGenin2
            Else
                frmDLG = New FrmG0014
                DirectCast(frmDLG, FrmG0014).PrYOIN = (cmbYOIN2.SelectedValue, cmbYOIN2.Text)
                DirectCast(frmDLG, FrmG0014).PrSelectedList = PrGenin2
            End If

            dlgRET = frmDLG.ShowDialog(Me)

            If dlgRET = Windows.Forms.DialogResult.Cancel Then
                Exit Sub
            Else
                '検索条件文字列作成
                Dim sbWhere As New System.Text.StringBuilder
                Dim strWhereBase As String = <sql><![CDATA[
                    EXISTS
                    (
                    SELECT HOKOKU_NO FROM D006_CAR_GENIN WHERE 
                    V007_NCR_CAR.HOKOKU_NO = D006_CAR_GENIN.HOKOKU_NO
                    {0}
                    )
                    ]]></sql>.Value.Trim

                mtxGENIN2_DISP.Text = ""
                If PrGenin2.Count > 0 Then
                    For Each item In PrGenin2
                        If mtxGENIN2_DISP.Text.IsNullOrWhiteSpace Then
                            mtxGENIN2_DISP.Text = item.ITEM_DISP
                        Else
                            mtxGENIN2_DISP.Text &= ", " & item.ITEM_DISP
                        End If

                        sbWhere.Append(" AND (GENIN_BUNSEKI_KB='" & item.ITEM_NAME & "' AND GENIN_BUNSEKI_S_KB='" & item.ITEM_VALUE & "')")
                    Next item
                    ParamModel.GENIN2 = String.Format(strWhereBase, sbWhere.ToString)
                Else
                    ParamModel.GENIN2 = ""
                End If
            End If

        Catch ex As Exception
            EM.ErrorSyori(ex, False, conblnNonMsg)
        Finally
            If frmDLG IsNot Nothing Then
                frmDLG.Dispose()
            End If
        End Try
    End Sub

    '不適合区分
    Private Sub CmbFUTEKIGO_KB_SelectedValueChanged(sender As Object, e As EventArgs) Handles cmbFUTEKIGO_KB.SelectedValueChanged

        If cmbFUTEKIGO_KB.SelectedValue <> "" Then
            Dim dt As New DataTableEx
            Using DB As ClsDbUtility = DBOpen()
                FunGetCodeDataTable(DB, "不適合" & cmbFUTEKIGO_KB.Text.Replace("・", "") & "区分", dt)
            End Using
            cmbFUTEKIGO_S_KB.SetDataSource(dt.ExcludeDeleted, ENM_COMBO_SELECT_VALUE_TYPE._1_Filter)
        Else
            cmbFUTEKIGO_S_KB.DataSource = Nothing
        End If

    End Sub
#End Region

#End Region

#Region "ローカル関数"

    Private Function FunSetBinding() As Boolean

        '共通
        cmbBUMON.DataBindings.Add(New Binding(NameOf(cmbBUMON.SelectedValue), ParamModel, NameOf(ParamModel.BUMON_KB), False, DataSourceUpdateMode.OnPropertyChanged, ""))
        mtxHOKUKO_NO.DataBindings.Add(New Binding(NameOf(mtxHOKUKO_NO.Text), ParamModel, NameOf(ParamModel.HOKOKU_NO), False, DataSourceUpdateMode.OnPropertyChanged, ""))
        cmbADD_TANTO.DataBindings.Add(New Binding(NameOf(cmbADD_TANTO.SelectedValue), ParamModel, NameOf(ParamModel.ADD_TANTO), False, DataSourceUpdateMode.OnPropertyChanged, 0))
        cmbKISYU.DataBindings.Add(New Binding(NameOf(cmbKISYU.SelectedValue), ParamModel, NameOf(ParamModel.KISYU_ID), False, DataSourceUpdateMode.OnPropertyChanged, 0))
        mtxGOKI.DataBindings.Add(New Binding(NameOf(mtxGOKI.Text), ParamModel, NameOf(ParamModel.GOUKI), False, DataSourceUpdateMode.OnPropertyChanged, ""))
        cmbSYANAI_CD.DataBindings.Add(New Binding(NameOf(cmbSYANAI_CD.SelectedValue), ParamModel, NameOf(ParamModel.SYANAI_CD), False, DataSourceUpdateMode.OnPropertyChanged, ""))
        cmbBUHIN_BANGO.DataBindings.Add(New Binding(NameOf(cmbBUHIN_BANGO.SelectedValue), ParamModel, NameOf(ParamModel.BUHIN_BANGO), False, DataSourceUpdateMode.OnPropertyChanged, ""))
        mtxHINMEI.DataBindings.Add(New Binding(NameOf(mtxHINMEI.Text), ParamModel, NameOf(ParamModel.BUHIN_NAME), False, DataSourceUpdateMode.OnPropertyChanged, ""))

        cmbGEN_TANTO.DataBindings.Add(New Binding(NameOf(cmbGEN_TANTO.SelectedValue), ParamModel, NameOf(ParamModel.SYOCHI_TANTO), False, DataSourceUpdateMode.OnPropertyChanged, 0))
        dtJisiFrom.DataBindings.Add(New Binding(NameOf(dtJisiFrom.ValueNonFormat), ParamModel, NameOf(ParamModel.JISI_YMD_FROM), False, DataSourceUpdateMode.OnPropertyChanged, ""))
        dtJisiTo.DataBindings.Add(New Binding(NameOf(dtJisiTo.ValueNonFormat), ParamModel, NameOf(ParamModel.JISI_YMD_TO), False, DataSourceUpdateMode.OnPropertyChanged, ""))
        cmbFUTEKIGO_KB.DataBindings.Add(New Binding(NameOf(cmbFUTEKIGO_KB.SelectedValue), ParamModel, NameOf(ParamModel.FUTEKIGO_KB), False, DataSourceUpdateMode.OnPropertyChanged, ""))
        cmbFUTEKIGO_S_KB.DataBindings.Add(New Binding(NameOf(cmbFUTEKIGO_S_KB.SelectedValue), ParamModel, NameOf(ParamModel.FUTEKIGO_S_KB), False, DataSourceUpdateMode.OnPropertyChanged, ""))
        cmbFUTEKIGO_JYOTAI_KB.DataBindings.Add(New Binding(NameOf(cmbFUTEKIGO_JYOTAI_KB.SelectedValue), ParamModel, NameOf(ParamModel.FUTEKIGO_JYOTAI_KB), False, DataSourceUpdateMode.OnPropertyChanged, ""))
        chkClosedRowVisibled.DataBindings.Add(New Binding(NameOf(chkClosedRowVisibled.Checked), ParamModel, NameOf(ParamModel.VISIBLE_CLOSE), False, DataSourceUpdateMode.OnPropertyChanged, False))
        chkTairyu.DataBindings.Add(New Binding(NameOf(chkTairyu.Checked), ParamModel, NameOf(ParamModel.VISIBLE_TAIRYU), False, DataSourceUpdateMode.OnPropertyChanged, False))
        'NCR
        cmbJIZEN_SINSA_HANTEI_KB.DataBindings.Add(New Binding(NameOf(cmbJIZEN_SINSA_HANTEI_KB.SelectedValue), ParamModel, NameOf(ParamModel.JIZEN_SINSA_HANTEI_KB), False, DataSourceUpdateMode.OnPropertyChanged, ""))
        cmbZESEI_SYOCHI_YOHI_KB.DataBindings.Add(New Binding(NameOf(cmbZESEI_SYOCHI_YOHI_KB.SelectedValue), ParamModel, NameOf(ParamModel.ZESEI_SYOCHI_YOHI_KB), False, DataSourceUpdateMode.OnPropertyChanged, ""))
        cmbSAISIN_IINKAI_HANTEI_KB.DataBindings.Add(New Binding(NameOf(cmbSAISIN_IINKAI_HANTEI_KB.SelectedValue), ParamModel, NameOf(ParamModel.SAISIN_IINKAI_HANTEI_KB), False, DataSourceUpdateMode.OnPropertyChanged, ""))
        cmbKOKYAKU_HANTEI_SIJI_KB.DataBindings.Add(New Binding(NameOf(cmbKOKYAKU_HANTEI_SIJI_KB.SelectedValue), ParamModel, NameOf(ParamModel.KOKYAKU_HANTEI_SIJI_KB), False, DataSourceUpdateMode.OnPropertyChanged, ""))
        cmbKOKYAKU_SAISYU_HANTEI_KB.DataBindings.Add(New Binding(NameOf(cmbKOKYAKU_SAISYU_HANTEI_KB.SelectedValue), ParamModel, NameOf(ParamModel.KOKYAKU_SAISYU_HANTEI_KB), False, DataSourceUpdateMode.OnPropertyChanged, ""))
        cmbKENSA_KEKKA_KB.DataBindings.Add(New Binding(NameOf(cmbKENSA_KEKKA_KB.SelectedValue), ParamModel, NameOf(ParamModel.KENSA_KEKKA_KB), False, DataSourceUpdateMode.OnPropertyChanged, ""))
        'CAR
        mtxGENIN1.DataBindings.Add(New Binding(NameOf(mtxGENIN1.Text), ParamModel, NameOf(ParamModel.GENIN1), False, DataSourceUpdateMode.OnPropertyChanged, ""))
        mtxGENIN2.DataBindings.Add(New Binding(NameOf(mtxGENIN2.Text), ParamModel, NameOf(ParamModel.GENIN2), False, DataSourceUpdateMode.OnPropertyChanged, ""))
        cmbKISEKI_KOTEI_KB.DataBindings.Add(New Binding(NameOf(cmbKISEKI_KOTEI_KB.SelectedValue), ParamModel, NameOf(ParamModel.KISEKI_KOTEI_KB), False, DataSourceUpdateMode.OnPropertyChanged, ""))

    End Function

    Private Function FunblnAllowKIHYO() As Boolean
        Dim sbSQL As New System.Text.StringBuilder
        Dim dsList As New DataSet

        sbSQL.Remove(0, sbSQL.Length)
        sbSQL.Append("SELECT")
        sbSQL.Append(" *")
        sbSQL.Append(" FROM " & NameOf(MODEL.M016_SYONIN_TANTO) & " ")
        sbSQL.Append(" WHERE SYONIN_HOKOKUSYO_ID IN(1,2)")
        sbSQL.Append(" AND SYONIN_JUN=10")
        sbSQL.Append(" AND SYAIN_ID=" & pub_SYAIN_INFO.SYAIN_ID)
        Using DBa As ClsDbUtility = DBOpen()
            dsList = DBa.GetDataSet(sbSQL.ToString, conblnNonMsg)
        End Using

        If dsList.Tables(0).Rows.Count > 0 Then
            Return True
        Else
            Return False
        End If

    End Function

    Private Function FunblnAllowSyonin() As Boolean
        Dim sbSQL As New System.Text.StringBuilder
        Dim dsList As New DataSet

        sbSQL.Remove(0, sbSQL.Length)
        sbSQL.Append("SELECT")
        sbSQL.Append(" *")
        sbSQL.Append(" FROM " & NameOf(MODEL.M016_SYONIN_TANTO) & " ")
        sbSQL.Append(" WHERE SYONIN_HOKOKUSYO_ID IN(1,2)")
        sbSQL.Append(" AND SYONIN_JUN>10")
        sbSQL.Append(" AND SYAIN_ID=" & pub_SYAIN_INFO.SYAIN_ID)
        Using DBa As ClsDbUtility = DBOpen()
            dsList = DBa.GetDataSet(sbSQL.ToString, conblnNonMsg)
        End Using

        If dsList.Tables(0).Rows.Count > 0 Then
            Return True
        Else
            Return False
        End If
    End Function



#End Region


End Class