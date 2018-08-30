Imports JMS_COMMON.ClsPubMethod

Public Class FrmM1010

#Region "定数・変数"
    Private pri_objPrevCellValue As Object
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
        MyBase.ToolTip.SetToolTip(Me.cmdFunc10, My.Resources.infoToolTipMsgNotFoundData)

        Me.Icon = My.Resources._icoBase_cog32x32
        Me.ShowIcon = True
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
            Call FunInitializeDataGridView(dgvTORI_ZOKUSEI)
            '-----グリッド列作成
            Call FunSetDgvCulumns(dgvDATA)
            Call FunSetDgvCulumnsZOKUSEI(dgvTORI_ZOKUSEI)
            '-----コントロールデータソース設定
            cmbTORI_SYU.SetDataSource(tblTORI_SYU.ExcludeDeleted, ENM_COMBO_SELECT_VALUE_TYPE._1_Filter)
            '-----コンボボックス既定値の設定
            'cmbTORI_KBN.SetDefaultValue()
            '-----イベントハンドラ設定
            AddHandler cmbTORI_SYU.SelectedValueChanged, AddressOf SearchFilterValueChanged
            AddHandler chkDeletedRowVisibled.CheckedChanged, AddressOf SearchFilterValueChanged

            'TODO: データソースをTK01に変更
            Dim dv As DataView = tblZOKUSEI.DefaultView
            dv.Sort = "DISP_ORDER"
            dgvTORI_ZOKUSEI.DataSource = dv

            '検索実行
            Me.cmdFunc1.PerformClick()

        Catch ex As Exception
            EM.ErrorSyori(ex, False, conblnNonMsg)
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

                .Columns.Add("TORI_CD", "取引先CD")
                .Columns(.ColumnCount - 1).Width = 90
                .Columns(.ColumnCount - 1).DefaultCellStyle.Alignment = Windows.Forms.DataGridViewContentAlignment.MiddleRight

                .Columns.Add("TORI_SYU_DISP", "取引種別")
                .Columns(.ColumnCount - 1).Width = 80
                .Columns(.ColumnCount - 1).DefaultCellStyle.Alignment = Windows.Forms.DataGridViewContentAlignment.MiddleCenter

                .Columns.Add("SIIRE_GAICYU_KB_DISP", "仕入外注区分")
                .Columns(.ColumnCount - 1).Width = 60
                .Columns(.ColumnCount - 1).DefaultCellStyle.Alignment = Windows.Forms.DataGridViewContentAlignment.MiddleCenter

                Dim cmbclmn2 As New DataGridViewCheckBoxColumn With {
                .Name = "SYOKUCHI_FLG",
                .HeaderText = "諸口フラグ",
                .Width = 30
                }
                cmbclmn2.DefaultCellStyle.Alignment = Windows.Forms.DataGridViewContentAlignment.MiddleCenter
                .Columns.Add(cmbclmn2)
                .Columns(.ColumnCount - 1).SortMode = DataGridViewColumnSortMode.Automatic

                .Columns.Add("TORI_NAME", "取引先名称")
                .Columns(.ColumnCount - 1).Width = 210
                .Columns(.ColumnCount - 1).DefaultCellStyle.Alignment = Windows.Forms.DataGridViewContentAlignment.MiddleLeft

                .Columns.Add("FURIGANA", "フリガナ")
                .Columns(.ColumnCount - 1).Width = 190
                .Columns(.ColumnCount - 1).DefaultCellStyle.Alignment = Windows.Forms.DataGridViewContentAlignment.MiddleLeft

                .Columns.Add("TORI_R_NAME", "取引先略名")
                .Columns(.ColumnCount - 1).Width = 140
                .Columns(.ColumnCount - 1).DefaultCellStyle.Alignment = Windows.Forms.DataGridViewContentAlignment.MiddleLeft

                .Columns.Add("TORI_SITEN_NAME", "取引先支店名")
                .Columns(.ColumnCount - 1).Width = 120
                .Columns(.ColumnCount - 1).DefaultCellStyle.Alignment = Windows.Forms.DataGridViewContentAlignment.MiddleLeft

                .Columns.Add("TORI_TANTO_NAME", "取引先担当者名")
                .Columns(.ColumnCount - 1).Width = 120
                .Columns(.ColumnCount - 1).DefaultCellStyle.Alignment = Windows.Forms.DataGridViewContentAlignment.MiddleLeft

                .Columns.Add("YUBIN", "郵便番号")
                .Columns(.ColumnCount - 1).Width = 80
                .Columns(.ColumnCount - 1).DefaultCellStyle.Alignment = Windows.Forms.DataGridViewContentAlignment.MiddleCenter

                .Columns.Add("ADDRESS1", "住所1")
                .Columns(.ColumnCount - 1).Width = 180
                .Columns(.ColumnCount - 1).DefaultCellStyle.Alignment = Windows.Forms.DataGridViewContentAlignment.MiddleLeft

                .Columns.Add("ADDRESS2", "住所2")
                .Columns(.ColumnCount - 1).Width = 180
                .Columns(.ColumnCount - 1).DefaultCellStyle.Alignment = Windows.Forms.DataGridViewContentAlignment.MiddleLeft

                .Columns.Add("ADDRESS3", "住所3")
                .Columns(.ColumnCount - 1).Width = 180
                .Columns(.ColumnCount - 1).DefaultCellStyle.Alignment = Windows.Forms.DataGridViewContentAlignment.MiddleLeft

                .Columns.Add("TEL", "TEL")
                .Columns(.ColumnCount - 1).Width = 120
                .Columns(.ColumnCount - 1).DefaultCellStyle.Alignment = Windows.Forms.DataGridViewContentAlignment.MiddleCenter

                .Columns.Add("FAX", "FAX")
                .Columns(.ColumnCount - 1).Width = 120
                .Columns(.ColumnCount - 1).DefaultCellStyle.Alignment = Windows.Forms.DataGridViewContentAlignment.MiddleCenter

                .Columns.Add("S_TANTO_NAME", "社内担当者")
                .Columns(.ColumnCount - 1).Width = 110
                .Columns(.ColumnCount - 1).DefaultCellStyle.Alignment = Windows.Forms.DataGridViewContentAlignment.MiddleLeft

                .Columns.Add("SEIKYU_TORI_NAME", "請求先")
                .Columns(.ColumnCount - 1).Width = 180
                .Columns(.ColumnCount - 1).DefaultCellStyle.Alignment = Windows.Forms.DataGridViewContentAlignment.MiddleLeft

                .Columns.Add("URIZEI_KB_DISP", "売税区分")
                .Columns(.ColumnCount - 1).Width = 80
                .Columns(.ColumnCount - 1).DefaultCellStyle.Alignment = Windows.Forms.DataGridViewContentAlignment.MiddleCenter

                .Columns.Add("URI_TAX_HASU_KB_DISP", "売税端数処理区分")
                .Columns(.ColumnCount - 1).Width = 100
                .Columns(.ColumnCount - 1).DefaultCellStyle.Alignment = Windows.Forms.DataGridViewContentAlignment.MiddleCenter

                .Columns.Add("SIZEI_KB_DISP", "仕税区分")
                .Columns(.ColumnCount - 1).Width = 80
                .Columns(.ColumnCount - 1).DefaultCellStyle.Alignment = Windows.Forms.DataGridViewContentAlignment.MiddleCenter

                .Columns.Add("SIIRE_TAX_HASU_KB_DISP", "仕税端数処理区分")
                .Columns(.ColumnCount - 1).Width = 100
                .Columns(.ColumnCount - 1).DefaultCellStyle.Alignment = Windows.Forms.DataGridViewContentAlignment.MiddleCenter

                .Columns.Add("LEAD_TIME", "リードタイム")
                .Columns(.ColumnCount - 1).Width = 90
                .Columns(.ColumnCount - 1).DefaultCellStyle.Alignment = Windows.Forms.DataGridViewContentAlignment.MiddleRight
                .Columns(.ColumnCount - 1).DefaultCellStyle.Format = "#,0"

                .Columns.Add("SIME_DAY", "締日")
                .Columns(.ColumnCount - 1).Width = 50
                .Columns(.ColumnCount - 1).DefaultCellStyle.Alignment = Windows.Forms.DataGridViewContentAlignment.MiddleRight

                .Columns.Add("SIHARAI_DAY", "支払日")
                .Columns(.ColumnCount - 1).Width = 50
                .Columns(.ColumnCount - 1).DefaultCellStyle.Alignment = Windows.Forms.DataGridViewContentAlignment.MiddleRight

                .Columns.Add("MEMO", "メモ")
                .Columns(.ColumnCount - 1).Width = 200
                .Columns(.ColumnCount - 1).DefaultCellStyle.Alignment = Windows.Forms.DataGridViewContentAlignment.MiddleLeft

                .Columns.Add("TORI_FUGO", "取引先符号")
                .Columns(.ColumnCount - 1).Width = 100
                .Columns(.ColumnCount - 1).DefaultCellStyle.Alignment = Windows.Forms.DataGridViewContentAlignment.MiddleLeft

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

                '-----バインディング
                .AutoGenerateColumns = False
                .Columns("TORI_CD").DataPropertyName = "TORI_CD"
                .Columns("TORI_SYU_DISP").DataPropertyName = "TORI_SYU_DISP"
                .Columns("SIIRE_GAICYU_KB_DISP").DataPropertyName = "SIIRE_GAICYU_KB_DISP"
                .Columns("SYOKUCHI_FLG").DataPropertyName = "SYOKUCHI_FLG"
                .Columns("TORI_NAME").DataPropertyName = "TORI_NAME"
                .Columns("FURIGANA").DataPropertyName = "FURIGANA"
                .Columns("TORI_R_NAME").DataPropertyName = "TORI_R_NAME"
                .Columns("TORI_SITEN_NAME").DataPropertyName = "TORI_SITEN_NAME"
                .Columns("TORI_TANTO_NAME").DataPropertyName = "TORI_TANTO_NAME"
                .Columns("TORI_FUGO").DataPropertyName = "TORI_FUGO"
                .Columns("YUBIN").DataPropertyName = "YUBIN"
                .Columns("ADDRESS1").DataPropertyName = "ADDRESS1"
                .Columns("ADDRESS2").DataPropertyName = "ADDRESS2"
                .Columns("ADDRESS3").DataPropertyName = "ADDRESS3"
                .Columns("TEL").DataPropertyName = "TEL"
                .Columns("FAX").DataPropertyName = "FAX"
                .Columns("S_TANTO_NAME").DataPropertyName = "S_TANTO_NAME"
                .Columns("SEIKYU_TORI_NAME").DataPropertyName = "SEIKYU_TORI_NAME"
                .Columns("URIZEI_KB_DISP").DataPropertyName = "URIZEI_KB_DISP"
                .Columns("URI_TAX_HASU_KB_DISP").DataPropertyName = "URI_TAX_HASU_KB_DISP"
                .Columns("SIZEI_KB_DISP").DataPropertyName = "SIZEI_KB_DISP"
                .Columns("SIIRE_TAX_HASU_KB_DISP").DataPropertyName = "SIIRE_TAX_HASU_KB_DISP"
                .Columns("LEAD_TIME").DataPropertyName = "LEAD_TIME"
                .Columns("SIME_DAY").DataPropertyName = "SIME_DAY"
                .Columns("SIHARAI_DAY").DataPropertyName = "SIHARAI_DAY"
                .Columns("MEMO").DataPropertyName = "MEMO"
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

#Region "属性"
    Private Function FunSetDgvCulumnsZOKUSEI(ByVal dgv As DataGridView) As Boolean

        Try
            With dgv
                .ReadOnly = False
                .AutoGenerateColumns = False
                .AllowUserToResizeColumns = False
                .ColumnHeadersHeight = 30

                .Columns.Add("ZOKUSEI_CD", "属性CD")
                .Columns(.ColumnCount - 1).Visible = False
                .Columns(.ColumnCount - 1).DataPropertyName = "VALUE"

                .Columns.Add("ZOKUSEI_DISP", "属性分類")
                .Columns(.ColumnCount - 1).Width = 120
                .Columns(.ColumnCount - 1).DefaultCellStyle.Alignment = Windows.Forms.DataGridViewContentAlignment.MiddleLeft
                .Columns(.ColumnCount - 1).DataPropertyName = "DISP"
                .Columns(.ColumnCount - 1).ReadOnly = True
                .Columns(.ColumnCount - 1).SortMode = DataGridViewColumnSortMode.NotSortable

                'ValueMemberをZOKUSEI_K_CDにするとキー情報不足で項目を特定出来なくなるので、複合キーをValueMemberにする
                Dim column As New DataGridViewComboBoxColumn With {
                    .DataPropertyName = "ZOKUSEI_K_CD",
                    .Name = "ZOKUSEI_K_CD",
                    .Width = 140,
                    .DataSource = tblZOKUSEI_K.AddBlankRow,
                    .HeaderText = "条件",
                    .ValueMember = "COMP_KEY",
                    .DisplayMember = "DISP",
                    .DisplayStyle = DataGridViewComboBoxDisplayStyle.DropDownButton,
                    .DisplayStyleForCurrentCellOnly = True
                }
                column.DefaultCellStyle.Alignment = Windows.Forms.DataGridViewContentAlignment.MiddleLeft
                .Columns.Add(column)
                .Columns(.ColumnCount - 1).DataPropertyName = "COMP_KEY"

            End With

            Return True
        Catch ex As Exception
            EM.ErrorSyori(ex, False, conblnNonMsg)
            Return False
        End Try
    End Function

#End Region

    Private dgvComboboxControl As DataGridViewComboBoxEditingControl = Nothing

    Private Sub Dgv_CellEnter(ByVal sender As Object, ByVal e As DataGridViewCellEventArgs) Handles dgvTORI_ZOKUSEI.CellEnter
        Dim dgv As DataGridView = CType(sender, DataGridView)

        If dgv.Columns(e.ColumnIndex).Name = "ZOKUSEI_K_CD" AndAlso
        TypeOf dgv.Columns(e.ColumnIndex) Is DataGridViewComboBoxColumn Then
            'セルクリック時、明示的に編集コントロールを表示
            dgv.BeginEdit(False)
            dgvComboboxControl = dgv.EditingControl
            dgvComboboxControl.DroppedDown = True
        End If
    End Sub

    Private Sub Dgv_CellBeginEdit(sender As Object, e As System.Windows.Forms.DataGridViewCellCancelEventArgs) Handles dgvTORI_ZOKUSEI.CellBeginEdit

        '選択済みの値をセットするため、変更前の値を控えておく
        'valueMemberは {ZOKUSEI_CD,ZOKUSEI_K_CD}なので、そこからZOKUSEI_K_CDだけを控える
        If dgvTORI_ZOKUSEI.Rows(e.RowIndex).Cells(e.ColumnIndex).Value IsNot Nothing Then
            pri_objPrevCellValue = dgvTORI_ZOKUSEI.Rows(e.RowIndex).Cells(e.ColumnIndex).Value.ToString.Split(",")(1)
        Else
            pri_objPrevCellValue = Nothing
        End If

    End Sub

    Private Sub Dgv_EditingControlShowing(ByVal sender As Object, ByVal e As DataGridViewEditingControlShowingEventArgs) Handles dgvTORI_ZOKUSEI.EditingControlShowing

        Try
            '表示されているコントロールがDataGridViewComboBoxEditingControlか調べる
            If TypeOf e.Control Is DataGridViewComboBoxEditingControl Then
                Dim dgv As DataGridView = CType(sender, DataGridView)
                Select Case dgv.CurrentCell.OwningColumn.Name
                    Case "ZOKUSEI_K_CD"
                        '編集のために表示されているコントロールを取得
                        dgvComboboxControl = CType(e.Control, DataGridViewComboBoxEditingControl)
                        'dgvComboboxControl.DropDownStyle = ComboBoxStyle.DropDownList
                        'dgvComboboxControl.AutoCompleteMode = AutoCompleteMode.SuggestAppend
                        Dim ZOKUSEI_CD As Integer = dgv.CurrentRow.Cells("ZOKUSEI_CD").Value

                        Dim dr As List(Of DataRow) = tblZOKUSEI_K.AsEnumerable.Where(Function(r) r.Field(Of Integer)("ZOKUSEI_CD") = ZOKUSEI_CD).ToList
                        If dr.Count > 0 Then
                            dgvComboboxControl.DataSource = dr.CopyToDataTable.AddBlankRow
                            dgvComboboxControl.DisplayMember = "DISP"
                            dgvComboboxControl.ValueMember = "VALUE"
                            If pri_objPrevCellValue IsNot Nothing Then
                                'データソースを変更すると選択済みの値がクリアされてしまうので、編集開始時の値を呼び戻す
                                dgvComboboxControl.SelectedValue = pri_objPrevCellValue
                            End If
                        Else
                            dgvComboboxControl.DataSource = Nothing
                        End If
                End Select
            End If
        Catch ex As Exception
            EM.ErrorSyori(ex, False, conblnNonMsg)

        End Try
    End Sub

#Region "編集可能セルOnMouse時カーソル変更"
    Private Sub Dgv_CellMouseMove(sender As Object, e As DataGridViewCellMouseEventArgs)
        Dim dgv As DataGridView = DirectCast(sender, DataGridView)
        If e.RowIndex >= 0 AndAlso dgv(e.ColumnIndex, e.RowIndex).ReadOnly = False Then
            Select Case dgv.Columns(e.ColumnIndex).Name
                Case "ZOKUSEI_K_CD"
                    dgv.Cursor = Cursors.Hand
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
            Me.PrPG_STATUS = ENM_PG_STATUS._2_ACTIVE
        End Try

    End Sub

#End Region

#Region "検索"
    Private Function FunSRCH() As DataTable
        Dim dsList As New System.Data.DataSet
        Dim sbSQL As New System.Text.StringBuilder
        Dim sbSQLWHERE As New System.Text.StringBuilder
        Dim waitDlg As WaitDialog = Nothing
        'Dim lngCURROW As Long = 0
        '-----件数確認
        sbSQL.Remove(0, sbSQL.Length)
        sbSQL.Append("SELECT COUNT(*) FROM " & NameOf(Model.VWM02_TORIHIKI) & "")
        sbSQL.Append(sbSQLWHERE)
        '----WHERE句作成
        sbSQLWHERE.Remove(0, sbSQLWHERE.Length)

        '取引種別
        If Me.cmbTORI_SYU.IsSelected Then
            If sbSQLWHERE.Length = 0 Then
                sbSQLWHERE.Append(" WHERE TORI_SYU = '" & Me.cmbTORI_SYU.SelectedValue & "' ")
            Else
                sbSQLWHERE.Append(" AND TORI_SYU =  '" & Me.cmbTORI_SYU.SelectedValue & "' ")

            End If
        Else
            If cmbTORI_SYU.Text.IsNullOrWhiteSpace = False Then

                If sbSQLWHERE.Length = 0 Then
                    sbSQLWHERE.Append(" WHERE TORI_SYU  LIKE '%" & Me.cmbTORI_SYU.Text.Trim & "%' ")
                Else
                    sbSQLWHERE.Append(" AND TORI_SYU  LIKE '%" & Me.cmbTORI_SYU.Text.Trim & "%' ")

                End If
            End If
        End If
        '取引先略名検索
        If mtxTORI_R_NAME.Text.IsNullOrWhiteSpace = False Then

            If sbSQLWHERE.Length = 0 Then
                sbSQLWHERE.Append(" WHERE TORI_R_NAME LIKE '%" & Me.mtxTORI_R_NAME.Text.Trim & "%' ")
            Else
                sbSQLWHERE.Append(" AND TORI_R_NAME LIKE '%" & Me.mtxTORI_R_NAME.Text.Trim & "%' ")

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
        sbSQL.Append(" FROM " & priTableName & " ")
        sbSQL.Append(sbSQLWHERE)
        sbSQL.Append(" ORDER BY TORI_CD ")

        Using DB As ClsDbUtility = DBOpen()
            dsList = DB.GetDataSet(sbSQL.ToString, conblnNonMsg)
        End Using

        If dsList.Tables(0).Rows.Count > pub_APP_INFO.intSEARCHMAX Then
            If MessageBox.Show(My.Resources.infoSearchCountOver, "", MessageBoxButtons.YesNo, MessageBoxIcon.Information) = Windows.Forms.DialogResult.No Then
                Return Nothing
            End If
        End If


        '------DataTableに変換
        Dim _Model As New Model.ModelInfo(Of Model.VWM02_TORIHIKI)(srcDATA:=dsList.Tables(0))
        Return _Model.Data

    End Function

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

            ' Call DgvDATA_SelectionChanged(Me.dgvDATA, Nothing)
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


    Private Function FunGetZOKUSEI_ConditionString(ByVal dgv As DataGridView) As String
        Dim strRET As String = ""
        Dim sbSQL As New System.Text.StringBuilder

        Dim ar = [Enum].GetValues(GetType(Context.ENM_ZOKUSEI_KB))


        For Each row As DataGridViewRow In dgv.Rows
            If row.Cells("ZOKUSEI_K_CD").Value <> "" Then
                If sbSQL.Length > 0 Then
                    sbSQL.Append(" OR ")
                End If
                sbSQL.Append(String.Format("(ZOKUSEI_CD={0} AND ZOKUSEI_K_CD={1})",
                                row.Cells("ZOKUSEI_CD").Value,
                                row.Cells("ZOKUSEI_K_CD").Value.ToString.Split(",")(1)))
            End If
        Next row

        If sbSQL.Length > 0 Then
            strRET = " AND (" & sbSQL.ToString & ")"
        End If
        Return strRET
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
    ''' <param name="intMODE">処理モード</param>
    ''' <returns></returns>
    Private Function FunUpdateEntity(ByVal intMODE As ENM_DATA_OPERATION_MODE) As Boolean

        Dim dlgRET As DialogResult
        Dim PKeys As Integer
        Try
            Using frmDLG As New FrmM1011
                frmDLG.PrMODE = intMODE
                If Me.dgvDATA.CurrentRow IsNot Nothing Then
                    frmDLG.PrDataRow = dgvDATA.GetDataRow
                Else
                    frmDLG.PrDataRow = Nothing
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

#End Region

#Region "削除"
    Private Function FunDEL(ByVal ENM_MODE As ENM_DATA_OPERATION_MODE) As Boolean
        Dim sbSQL As New System.Text.StringBuilder
        Dim strMsg As String
        Dim strTitle As String
        Try
            sbSQL.Remove(0, sbSQL.Length)
            Select Case ENM_MODE
                Case ENM_DATA_OPERATION_MODE._4_DISABLE
                    sbSQL.Append("UPDATE " & NameOf(Model.M02_TORIHIKI) & " SET ")
                    '変更日時
                    sbSQL.Append(" EDIT_YMDHNS = dbo.GetSysDateString() ")
                    '削除日時
                    sbSQL.Append(" ,DEL_YMDHNS = dbo.GetSysDateString() ")
                    '更新社員ID
                    sbSQL.Append(" ,DEL_TANTO_CD = " & pub_SYAIN_INFO.SYAIN_ID & "")

                    strMsg = My.Resources.infoMsgDeleteOperationDisable
                    strTitle = My.Resources.infoTitleDeleteOperationDisable

                Case ENM_DATA_OPERATION_MODE._5_RESTORE
                    sbSQL.Append("UPDATE " & NameOf(Model.VWM02_TORIHIKI) & " SET ")
                    '変更日時
                    sbSQL.Append(" EDIT_YMDHNS = dbo.GetSysDateString() ")
                    '削除日時
                    sbSQL.Append(" ,DEL_YMDHNS = ' ' ")
                    '更新社員ID
                    sbSQL.Append(" ,DEL_TANTO_CD = " & pub_SYAIN_INFO.SYAIN_ID & "")

                    strMsg = My.Resources.infoMsgDeleteOperationRestore
                    strTitle = My.Resources.infoTitleDeleteOperationRestore

                Case ENM_DATA_OPERATION_MODE._6_DELETE

                    sbSQL.Append("DELETE FROM " & NameOf(Model.VWM02_TORIHIKI) & " ")

                    strMsg = My.Resources.infoMsgDeleteOperationDelete
                    strTitle = My.Resources.infoTitleDeleteOperationDelete

                Case Else
                    'UNDONE: argument null exception
                    Return False
            End Select
            sbSQL.Append(" WHERE")
            sbSQL.Append(" TORI_CD = '" & Me.dgvDATA.CurrentRow.Cells.Item("TORI_CD").Value & "' ")

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
                    '-----トランザクション開始
                    DB.BeginTransaction()

                    intRET = DB.ExecuteNonQuery(sbSQL.ToString, conblnNonMsg, sqlEx)
                    If intRET <> 1 Then
                        'エラーログ
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
            Throw
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
    Public Function FunInitFuncButtonEnabled(ByVal frm As FrmM1010) As Boolean

        Try
            For intFunc As Integer = 1 To 12
                With frm.Controls("cmdFunc" & intFunc)
                    If .Text.Length = 0 OrElse .Text.Substring(0, .Text.IndexOf("(")).Trim.IsNullOrWhiteSpace = True Then
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

            'MyBase.ToolTip.SetToolTip(Me.cmdFunc5, My.Resources.infoToolTipMsgNotFoundData)

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
    '検索フィルタクリア
    Private Sub BtnClearSrchFilter_Click(sender As Object, e As EventArgs) Handles btnClearSrchFilter.Click

        mtxTORI_R_NAME.Clear()
        chkDeletedRowVisibled.Checked = False
        Me.cmdFunc1.PerformClick()
    End Sub

#End Region
End Class
