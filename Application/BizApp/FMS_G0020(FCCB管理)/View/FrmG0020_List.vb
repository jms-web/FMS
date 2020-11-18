Imports System.Threading.Tasks
Imports C1.Win.C1FlexGrid
Imports JMS_COMMON.ClsPubMethod
Imports MODEL

''' <summary>
''' FCCB検索
''' </summary>
Public Class FrmG0020_List

#Region "定数・変数"

    Private mDataView As DataView

#End Region

#Region "コンストラクタ"

    ''' <summary>
    ''' コンストラクタ
    ''' </summary>
    ''' <remarks>コンストラクタ</remarks>
    Public Sub New()

        ' この呼び出しはデザイナーで必要です。
        InitializeComponent()

        Me.Icon = My.Resources._icoAppForm32x32
        Me.ShowIcon = True

        'ツールチップメッセージ
        MyBase.ToolTip.SetToolTip(Me.cmdFunc3, My.Resources.infoToolTipMsgNotFoundData)
        MyBase.ToolTip.SetToolTip(Me.cmdFunc4, My.Resources.infoToolTipMsgNotFoundData)
        MyBase.ToolTip.SetToolTip(Me.cmdFunc5, My.Resources.infoToolTipMsgNotFoundData)
        MyBase.ToolTip.SetToolTip(Me.cmdFunc7, My.Resources.infoToolTipMsgNotFoundData)
        MyBase.ToolTip.SetToolTip(Me.cmdFunc8, My.Resources.infoToolTipMsgNotFoundData)
        MyBase.ToolTip.SetToolTip(Me.cmdFunc9, My.Resources.infoToolTipMsgNotFoundData)
        MyBase.ToolTip.SetToolTip(Me.cmdFunc10, My.Resources.infoToolTipMsgNotFoundData)
        MyBase.ToolTip.SetToolTip(Me.cmdFunc11, My.Resources.infoToolTipMsgNotFoundData)

        cmbADD_TANTO.NullValue = 0
        cmbKISYU.NullValue = 0
        cmbGEN_TANTO.NullValue = 0

        Select Case pub_intOPEN_MODE
            Case ENM_OPEN_MODE._1_新規作成, ENM_OPEN_MODE._2_処置画面起動
                Me.WindowState = FormWindowState.Minimized
        End Select

    End Sub

#End Region

#Region "Form関連"

    Private Sub FrmLoad(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        Try
            Me.Visible = False

            '-----フォーム初期設定(親フォームから呼び出し)
            Call FunFormCommonSetting(pub_APP_INFO, pub_SYAIN_INFO, My.Application.Info.Version.ToString)

            '-----グリッド初期設定(親フォームから呼び出し)
            Call FunInitializeFlexGrid(flxDATA)

            '-----コントロールソース設定
            cmbBUMON.SetDataSource(tblBUMON.ExcludeDeleted, ENM_COMBO_SELECT_VALUE_TYPE._1_Filter)
            cmbADD_TANTO.SetDataSource(tblTANTO.ExcludeDeleted, ENM_COMBO_SELECT_VALUE_TYPE._1_Filter)
            cmbKISYU.SetDataSource(tblKISYU.LazyLoad("機種"), ENM_COMBO_SELECT_VALUE_TYPE._1_Filter)
            cmbBUHIN_BANGO.SetDataSource(tblBUHIN.LazyLoad("部品番号"), ENM_COMBO_SELECT_VALUE_TYPE._1_Filter)
            cmbSYANAI_CD.SetDataSource(tblSYANAI_CD.LazyLoad("社内CD").ExcludeDeleted, ENM_COMBO_SELECT_VALUE_TYPE._1_Filter)

            '----コントロールイベントハンドラ
            AddHandler cmbBUMON.SelectedValueChanged, AddressOf CmbBUMON_SelectedValueChanged
            AddHandler cmbKISYU.SelectedValueChanged, AddressOf CmbKISYU_SelectedValueChanged
            AddHandler cmbSYANAI_CD.SelectedValueChanged, AddressOf CmbSYANAI_CD_SelectedValueChanged
            AddHandler cmbBUHIN_BANGO.SelectedValueChanged, AddressOf CmbBUHIN_BANGO_SelectedValueChanged

            '-----既定値設定
            Dim dtGEN_TANTO As DataTable = Nothing
            Dim blnIsAdmin As Boolean = IsSysAdminUser(pub_SYAIN_INFO.SYAIN_ID)
            If blnIsAdmin Then
                'システム管理者のみ制限解除
                dtGEN_TANTO = FunGetSYONIN_SYOZOKU_SYAIN(cmbBUMON.SelectedValue)
            Else
                Select Case pub_SYAIN_INFO.BUMON_KB
                    Case Context.ENM_BUMON_KB._1_風防, Context.ENM_BUMON_KB._2_LP
                        Dim dt As DataTable = DirectCast(cmbBUMON.DataSource, DataTable).
                                                    AsEnumerable.
                                                    Where(Function(r) r.Field(Of String)("VALUE") = "1" Or r.Field(Of String)("VALUE") = "2").
                                                    CopyToDataTable
                        cmbBUMON.SetDataSource(dt, ENM_COMBO_SELECT_VALUE_TYPE._1_Filter)
                        cmbBUMON.SelectedValue = pub_SYAIN_INFO.BUMON_KB

                        dtGEN_TANTO = FunGetSYONIN_SYOZOKU_SYAIN(pub_SYAIN_INFO.BUMON_KB)

                    Case Context.ENM_BUMON_KB._3_複合材
                        Dim dt As DataTable = DirectCast(cmbBUMON.DataSource, DataTable).
                                                    AsEnumerable.
                                                    Where(Function(r) r.Field(Of String)("VALUE") = pub_SYAIN_INFO.BUMON_KB).
                                                    CopyToDataTable
                        cmbBUMON.SetDataSource(dt, ENM_COMBO_SELECT_VALUE_TYPE._1_Filter)
                        cmbBUMON.SelectedValue = pub_SYAIN_INFO.BUMON_KB

                        dtGEN_TANTO = FunGetSYONIN_SYOZOKU_SYAIN(cmbBUMON.SelectedValue)
                    Case Else
                        '#255 風防,LP,複合材以外の部門所属者は全部門閲覧のみ
                        dtGEN_TANTO = FunGetSYONIN_SYOZOKU_SYAIN(cmbBUMON.SelectedValue)
                End Select

                cmbGEN_TANTO.SetDataSource(dtGEN_TANTO, ENM_COMBO_SELECT_VALUE_TYPE._1_Filter)

                'If Not IsOPAdminUser(pub_SYAIN_INFO.SYAIN_ID) And pub_SYAIN_INFO.BUMON_KB <= Context.ENM_BUMON_KB._3_複合材 Then
                '    cmbGEN_TANTO.SelectedValue = pub_SYAIN_INFO.SYAIN_ID
                'End If
            End If

            ''-----イベントハンドラ設定
            AddHandler cmbKISYU.SelectedValueChanged, AddressOf SearchFilterValueChanged
            AddHandler cmbSYANAI_CD.SelectedValueChanged, AddressOf SearchFilterValueChanged
            AddHandler cmbGEN_TANTO.SelectedValueChanged, AddressOf SearchFilterValueChanged
            AddHandler mtxHOKUKO_NO.Validated, AddressOf SearchFilterValueChanged
            AddHandler cmbBUHIN_BANGO.SelectedValueChanged, AddressOf SearchFilterValueChanged
            AddHandler cmbADD_TANTO.SelectedValueChanged, AddressOf SearchFilterValueChanged
            AddHandler mtxHINMEI.Validated, AddressOf SearchFilterValueChanged
            AddHandler chkDeleteRowVisibled.CheckedChanged, AddressOf SearchFilterValueChanged
            AddHandler chkClosedRowVisibled.CheckedChanged, AddressOf SearchFilterValueChanged

            '起動モード別処理
            Using DB = DBOpen()
                lblTytle.Text = FunGetCodeMastaValue(DB, "PG_TITLE", Me.GetType.ToString)
            End Using
            Select Case pub_intOPEN_MODE
                Case ENM_OPEN_MODE._0_通常
                Case ENM_OPEN_MODE._1_新規作成
                    If FunUpdateEntity(ENM_DATA_OPERATION_MODE._1_ADD) = True Then
                        Call FunSRCH(flxDATA, FunGetListData())
                    End If
                Case ENM_OPEN_MODE._2_処置画面起動

                    Me.cmdFunc1.PerformClick()
                    Me.cmdFunc4.PerformClick()

                Case Else
                    Me.cmdFunc1.PerformClick()
            End Select

            'ファンクションボタンステータス更新
            Call FunInitFuncButtonEnabled()
            Me.WindowState = FormWindowState.Maximized

            cmdFunc1.PerformClick()
        Catch ex As Exception
            Throw
        Finally
            Me.Visible = True
        End Try
    End Sub

    Private Sub FrmG0010_Activated(sender As Object, e As EventArgs) Handles MyBase.Activated
        Call FunInitFuncButtonEnabled()
    End Sub

    Overrides Sub FrmBaseStsBtn_Resize(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Resize
        If Me.Visible = False Then Exit Sub

        If Me.DesignMode = True Then Exit Sub

        ''===================================
        ''   ボタン位置、サイズ設定
        ''===================================
        'Call SetButtonSize(Me.Width, cmdFunc)
        'MyBase.FrmBaseStsBtn_Resize(Me, e)
    End Sub

#End Region

#Region "FlexGrid関連"

    '初期化
    Private Function FunInitializeFlexGrid(ByVal flxgrd As C1.Win.C1FlexGrid.C1FlexGrid) As Boolean
        With flxgrd
            .Rows(0).Height = 30
            .AutoGenerateColumns = False
            .AutoResize = False
            .AllowEditing = True
            .AllowDragging = C1.Win.C1FlexGrid.AllowDraggingEnum.None
            .AllowDelete = False
            .AllowResizing = C1.Win.C1FlexGrid.AllowResizingEnum.Columns
            .AllowSorting = C1.Win.C1FlexGrid.AllowSortingEnum.SingleColumn
            '.AllowMerging = C1.Win.C1FlexGrid.AllowMergingEnum.RestrictRows
            .AllowFiltering = True
            .ShowCellLabels = True
            .SelectionMode = C1.Win.C1FlexGrid.SelectionModeEnum.Row

            .FocusRect = C1.Win.C1FlexGrid.FocusRectEnum.None

            .Font = New Font("Meiryo UI", 9, FontStyle.Regular, GraphicsUnit.Point, CType(128, Byte))

            .Styles.Add("DeletedRow")
            .Styles("DeletedRow").BackColor = clrDeletedRowBackColor
            .Styles("DeletedRow").ForeColor = clrDeletedRowForeColor

            .Styles.Add("delStyle")
            .Styles("delStyle").ForeColor = Color.Red

            .VisualStyle = C1.Win.C1FlexGrid.VisualStyle.Office2010Silver

            '以下を適用するにはVisualStyleをCustomにする
            .Styles.Focus.BackColor = clrRowEnterColor

            For i As Integer = 1 To .Cols.Count - 1
                If .Cols(i).Name.Contains("YMD") Then
                    .Cols(i).Format = "yyyy/MM/dd"
                End If
            Next

        End With
    End Function

    Private Sub FlxDATA_RowColChange(sender As Object, e As EventArgs)
        Call FunInitFuncButtonEnabled()
    End Sub

    Private Function FunSetGridCellFormat(ByVal flx As C1.Win.C1FlexGrid.C1FlexGrid) As Boolean

        Try
            Dim delStyle As C1.Win.C1FlexGrid.CellStyle = flx.Styles("delStyle")

            For Each r As C1.Win.C1FlexGrid.Row In flx.Rows
                If r.Index > 0 Then

                    'Closed
                    If Val(r.Item(NameOf(MODEL.ST02_FUTEKIGO_ICHIRAN.CLOSE_FG))) > 0 Or r.Item(NameOf(ST02_FUTEKIGO_ICHIRAN.DEL_YMDHNS)) <> "" Then
                        r.Style = flx.Styles("DeletedRow")
                    Else
                        r.Style = Nothing
                    End If

                    ''Deleted
                    'If r.Item(NameOf(MODEL.ST02_FUTEKIGO_ICHIRAN.DEL_YMDHNS)) <> "" Then
                    '    r.Style = flx.Styles("DeletedRow")
                    'Else
                    '    r.Style = Nothing
                    'End If

                    ''滞留
                    If r.Item(NameOf(MODEL.ST02_FUTEKIGO_ICHIRAN.TAIRYU_FG)) = 1 Then
                        flx.SetCellStyle(r.Index, NameOf(ST02_FUTEKIGO_ICHIRAN.TAIRYU_NISSU), delStyle)
                    Else
                        flx.SetCellStyle(r.Index, NameOf(ST02_FUTEKIGO_ICHIRAN.TAIRYU_NISSU), Nothing)
                    End If
                End If
            Next
        Catch ex As Exception
            EM.ErrorSyori(ex, False, conblnNonMsg)
        End Try
    End Function

    Private Sub EqualFilter_Click(sender As Object, e As EventArgs) Handles EqualFilter.Click, NotEqualFilter.Click, IncludeFilter.Click, NotIncludeFilter.Click
        Dim filter = New C1.Win.C1FlexGrid.ConditionFilter
        Select Case DirectCast(sender, ToolStripMenuItem).Name
            Case NameOf(EqualFilter)
                filter.Condition1.Operator = ConditionOperator.Equals
            Case NameOf(NotEqualFilter)
                filter.Condition1.Operator = ConditionOperator.NotEquals
            Case NameOf(IncludeFilter)
                filter.Condition1.Operator = ConditionOperator.Contains
            Case NameOf(NotIncludeFilter)
                filter.Condition1.Operator = ConditionOperator.DoesNotContain
        End Select

        Dim tpl = CType(FlexContextMenu.Tag, (ColSel As Integer, selctValue As Object))
        filter.Condition1.Parameter = tpl.selctValue
        flxDATA.Cols(tpl.ColSel).Filter = filter
        flxDATA.ApplyFilters()
    End Sub

    Private Sub FlxDATA_DoubleClick(sender As Object, e As EventArgs) Handles flxDATA.DoubleClick
        If flxDATA.RowSel > 0 Then
            Me.cmdFunc4.PerformClick()
        End If
    End Sub
#End Region

#Region "DataGridView関連"

#Region "フィールド定義"

    Private Shared Function FunSetDgvCulumns(ByVal dgv As DataGridView) As Boolean
        Dim _Model As New MODEL.ST02_FUTEKIGO_ICHIRAN
        Try
            With dgv
                .AutoGenerateColumns = False
                .ReadOnly = False
                .Font = New Font("Meiryo UI", 9, FontStyle.Regular, GraphicsUnit.Point, CType(128, Byte))
                .ColumnHeadersDefaultCellStyle.Font = New Font("Meiryo UI", 9, FontStyle.Bold, GraphicsUnit.Point, CType(128, Byte))
                .RowsDefaultCellStyle.BackColor = Color.White
                .AlternatingRowsDefaultCellStyle.BackColor = Color.White
                .AllowUserToOrderColumns = True
                .AllowUserToResizeColumns = True

                Dim cmbclmn1 As New DataGridViewCheckBoxColumn With {
                .Name = "SELECTED",'NameOf(_Model.SELECTED),
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

                .Columns.Add(NameOf(_Model.BUMON_NAME), $"製品{vbCrLf}区分")
                .Columns(.ColumnCount - 1).Width = 60
                .Columns(.ColumnCount - 1).DefaultCellStyle.Alignment = Windows.Forms.DataGridViewContentAlignment.MiddleLeft
                .Columns(.ColumnCount - 1).DataPropertyName = .Columns(.ColumnCount - 1).Name
                .Columns(.ColumnCount - 1).ReadOnly = True

                .Columns.Add(NameOf(_Model.HOKOKU_NO), "報告書No")
                .Columns(.ColumnCount - 1).Width = 80
                .Columns(.ColumnCount - 1).DefaultCellStyle.Alignment = Windows.Forms.DataGridViewContentAlignment.MiddleCenter
                .Columns(.ColumnCount - 1).DataPropertyName = .Columns(.ColumnCount - 1).Name
                .Columns(.ColumnCount - 1).ReadOnly = True

                .Columns.Add(NameOf(_Model.CLOSE_FG), "Closed")
                .Columns(.ColumnCount - 1).DataPropertyName = .Columns(.ColumnCount - 1).Name
                .Columns(.ColumnCount - 1).Visible = False

                .Columns.Add(NameOf(_Model.SYONIN_JUN), "承認順")
                .Columns(.ColumnCount - 1).DataPropertyName = .Columns(.ColumnCount - 1).Name
                .Columns(.ColumnCount - 1).Visible = False

                .Columns.Add(NameOf(_Model.SYONIN_NAIYO), "ステージ")
                .Columns(.ColumnCount - 1).Width = 210
                .Columns(.ColumnCount - 1).DefaultCellStyle.Alignment = Windows.Forms.DataGridViewContentAlignment.MiddleLeft
                .Columns(.ColumnCount - 1).DataPropertyName = .Columns(.ColumnCount - 1).Name
                .Columns(.ColumnCount - 1).ReadOnly = True

                .Columns.Add(NameOf(_Model.SYONIN_HOKOKUSYO_R_NAME), "略名")
                .Columns(.ColumnCount - 1).Width = 60
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

                .Columns.Add(NameOf(_Model.TAIRYU_NISSU), $"滞留{vbCrLf}日数")
                .Columns(.ColumnCount - 1).Width = 60
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
                '.Columns(.ColumnCount - 1).Frozen = True
                .Columns(.ColumnCount - 1).ReadOnly = True

                .Columns.Add(NameOf(_Model.SYANAI_CD), "社内コード")
                .Columns(.ColumnCount - 1).Width = 150
                .Columns(.ColumnCount - 1).DefaultCellStyle.Alignment = Windows.Forms.DataGridViewContentAlignment.MiddleLeft
                .Columns(.ColumnCount - 1).DataPropertyName = .Columns(.ColumnCount - 1).Name
                '.Columns(.ColumnCount - 1).Frozen = True
                .Columns(.ColumnCount - 1).ReadOnly = True

                .Columns.Add(NameOf(_Model.BUHIN_NAME), "部品名")
                .Columns(.ColumnCount - 1).Width = 180
                .Columns(.ColumnCount - 1).DefaultCellStyle.Alignment = Windows.Forms.DataGridViewContentAlignment.MiddleLeft
                .Columns(.ColumnCount - 1).DataPropertyName = .Columns(.ColumnCount - 1).Name
                .Columns(.ColumnCount - 1).ReadOnly = True

                .Columns.Add(NameOf(_Model.GOKI), "号機")
                .Columns(.ColumnCount - 1).Width = 100
                .Columns(.ColumnCount - 1).DefaultCellStyle.Alignment = Windows.Forms.DataGridViewContentAlignment.MiddleLeft
                .Columns(.ColumnCount - 1).DataPropertyName = .Columns(.ColumnCount - 1).Name
                .Columns(.ColumnCount - 1).ReadOnly = True

                .Columns.Add(NameOf(_Model.SYONIN_HOKOKUSYO_NAME), "報告書名称")
                .Columns(.ColumnCount - 1).Width = 180
                .Columns(.ColumnCount - 1).DefaultCellStyle.Alignment = Windows.Forms.DataGridViewContentAlignment.MiddleLeft
                .Columns(.ColumnCount - 1).DataPropertyName = .Columns(.ColumnCount - 1).Name
                .Columns(.ColumnCount - 1).ReadOnly = True
                .Columns(.ColumnCount - 1).Visible = False

                .Columns.Add(NameOf(_Model.JIZEN_SINSA_HANTEI_NAME), "事前判定区分")
                .Columns(.ColumnCount - 1).Width = 140
                .Columns(.ColumnCount - 1).DefaultCellStyle.Alignment = Windows.Forms.DataGridViewContentAlignment.MiddleLeft
                .Columns(.ColumnCount - 1).DataPropertyName = .Columns(.ColumnCount - 1).Name
                .Columns(.ColumnCount - 1).ReadOnly = True

                .Columns.Add(NameOf(_Model.SAISIN_IINKAI_HANTEI_NAME), "再審判定区分")
                .Columns(.ColumnCount - 1).Width = 140
                .Columns(.ColumnCount - 1).DefaultCellStyle.Alignment = Windows.Forms.DataGridViewContentAlignment.MiddleLeft
                .Columns(.ColumnCount - 1).DataPropertyName = .Columns(.ColumnCount - 1).Name
                .Columns(.ColumnCount - 1).ReadOnly = True

                .Columns.Add(NameOf(_Model.HASSEI_YMD), "発生日")
                .Columns(.ColumnCount - 1).Width = 100
                .Columns(.ColumnCount - 1).DefaultCellStyle.Alignment = Windows.Forms.DataGridViewContentAlignment.MiddleCenter
                .Columns(.ColumnCount - 1).DataPropertyName = .Columns(.ColumnCount - 1).Name
                .Columns(.ColumnCount - 1).ReadOnly = True

                .Columns.Add(NameOf(_Model.SYONIN_YMDHNS), $"前処理{vbCrLf}実施日")
                .Columns(.ColumnCount - 1).Width = 100
                .Columns(.ColumnCount - 1).DefaultCellStyle.Alignment = Windows.Forms.DataGridViewContentAlignment.MiddleCenter
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

                .Columns.Add(NameOf(_Model.DEL_YMDHNS), "削除日時")
                .Columns(.ColumnCount - 1).Visible = False
                .Columns(.ColumnCount - 1).DataPropertyName = .Columns(.ColumnCount - 1).Name

                '.Columns(.ColumnCount - 1).DefaultCellStyle.Format = "#,0"
            End With

            Return True
        Finally
        End Try
    End Function

    Private Shared Function FunSetDgvCulumnsHOKOKUSYO_StageFilter(ByVal dgv As DataGridView) As Boolean

        Try
            With dgv
                .AutoGenerateColumns = False
                .ReadOnly = False
                .Font = New Font("Meiryo UI", 9, FontStyle.Regular, GraphicsUnit.Point, CType(128, Byte))
                .ColumnHeadersDefaultCellStyle.Font = New Font("Meiryo UI", 9, FontStyle.Bold, GraphicsUnit.Point, CType(128, Byte))
                .RowsDefaultCellStyle.BackColor = Color.White
                .AlternatingRowsDefaultCellStyle.BackColor = Color.White
                .ColumnHeadersHeight = 30

                Dim cmbclmn1 As New DataGridViewCustomCheckBoxHeaderColumn With {
                .Name = "SELECTED",
                .HeaderText = "",
                .DataPropertyName = .Name
                }
                cmbclmn1.DefaultCellStyle.Alignment = Windows.Forms.DataGridViewContentAlignment.MiddleCenter
                .Columns.Add(cmbclmn1)
                .Columns(.ColumnCount - 1).SortMode = DataGridViewColumnSortMode.Automatic
                .Columns(.ColumnCount - 1).Width = 30

                .Columns.Add("SYONIN_JUN", "")
                .Columns(.ColumnCount - 1).Width = 45
                .Columns(.ColumnCount - 1).DefaultCellStyle.Alignment = Windows.Forms.DataGridViewContentAlignment.MiddleRight
                .Columns(.ColumnCount - 1).DataPropertyName = .Columns(.ColumnCount - 1).Name
                .Columns(.ColumnCount - 1).Visible = False

                .Columns.Add("SYONIN_NAIYO", "ステージ名")
                .Columns(.ColumnCount - 1).Width = 305
                .Columns(.ColumnCount - 1).DefaultCellStyle.Alignment = Windows.Forms.DataGridViewContentAlignment.MiddleLeft
                .Columns(.ColumnCount - 1).DataPropertyName = .Columns(.ColumnCount - 1).Name
                .Columns(.ColumnCount - 1).ReadOnly = True

                .Columns.Add("COUNT", "件数")
                .Columns(.ColumnCount - 1).Width = 50
                .Columns(.ColumnCount - 1).DefaultCellStyle.Alignment = Windows.Forms.DataGridViewContentAlignment.MiddleRight
                .Columns(.ColumnCount - 1).DataPropertyName = .Columns(.ColumnCount - 1).Name
                .Columns(.ColumnCount - 1).ReadOnly = True

                For Each c As DataGridViewColumn In .Columns
                    c.SortMode = DataGridViewColumnSortMode.NotSortable
                Next c
            End With

            Return True
        Finally
        End Try
    End Function

#End Region

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
    Private Overloads Sub DgvDATA_SelectionChanged(sender As System.Object, e As System.EventArgs) Handles dgvDATA.SelectionChanged
        Try
            If Me.dgvDATA.CurrentRow IsNot Nothing Then
                If Me.dgvDATA.CurrentRow.Cells(NameOf(MODEL.ST02_FUTEKIGO_ICHIRAN.CLOSE_FG)).Value = "1" Or Me.dgvDATA.CurrentRow.Cells(NameOf(MODEL.ST02_FUTEKIGO_ICHIRAN.DEL_YMDHNS)).Value.ToString.IsNulOrWS Then
                    Me.dgvDATA.CurrentRow.ReadOnly = True
                Else
                    Me.dgvDATA.CurrentRow.ReadOnly = False
                End If
            End If
        Finally
            Call FunInitFuncButtonEnabled()
        End Try
    End Sub

    'ソート時イベント
    Private Sub DgvDATA_Sorted(sender As Object, e As EventArgs) Handles dgvDATA.Sorted
        'Call FunSetDgvCellFormat(sender)
    End Sub

    '行書式
    Private Function FunSetDgvCellFormat(ByVal dgv As DataGridView) As Boolean
        Dim _Model As New MODEL.ST02_FUTEKIGO_ICHIRAN
        Try
            For i As Integer = 0 To dgv.Rows.Count - 1

                '#55
                ''差し戻し
                'If dgvDATA.Rows(i).Cells(NameOf(_Model.SASIMOTO_SYONIN_JUN)).Value > 0 Then
                '    Me.dgvDATA.Rows(i).DefaultCellStyle.BackColor = clrCautionCellBackColor
                'End If

                ''滞留
                If dgvDATA.Rows(i).Cells(NameOf(_Model.TAIRYU_FG)).Value = 1 Then
                    'Me.dgvDATA.Rows(i).DefaultCellStyle.BackColor = clrWarningCellBackColor
                    Me.dgvDATA.Rows(i).Cells(NameOf(_Model.TAIRYU_NISSU)).Style.ForeColor = Color.Red
                    Me.dgvDATA.Rows(i).Cells(NameOf(_Model.TAIRYU_NISSU)).Style.SelectionForeColor = Color.Red
                End If

                'Closed
                If Val(Me.dgvDATA.Rows(i).Cells(NameOf(_Model.CLOSE_FG)).Value) > 0 Then
                    Me.dgvDATA.Rows(i).DefaultCellStyle.ForeColor = clrDeletedRowForeColor
                    Me.dgvDATA.Rows(i).DefaultCellStyle.BackColor = clrDeletedRowBackColor
                    Me.dgvDATA.Rows(i).DefaultCellStyle.SelectionForeColor = clrDeletedRowForeColor
                End If

                'Deleted
                If dgvDATA.Rows(i).Cells(NameOf(_Model.DEL_YMDHNS)).Value <> "" Then
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

#Region "　グリッド編集関連"

    ''' <summary>
    ''' グリッド編集前処理
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks>グリッド編集前処理</remarks>
    Private Sub DgvDATA_CellBeginEdit(sender As Object, e As System.Windows.Forms.DataGridViewCellCancelEventArgs)

        ' 編集前の値を待避しておく
        'pri_intPrevCellValue = Val(Me.dgvDATA.CurrentCell.Value)
    End Sub

    'セル編集完了イベント
    Private Sub DgvDATA_CellEndEdit(sender As Object, e As DataGridViewCellEventArgs)
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
    Private Sub DgvDATA_CellClick(sender As System.Object, e As DataGridViewCellEventArgs)

        Try
            Dim dgv As DataGridView = DirectCast(sender, DataGridView)

            If e.RowIndex >= 0 Then
                Select Case dgv.Columns(e.ColumnIndex).Name
                    Case "SELECTED"
                        If Me.dgvDATA.CurrentRow.Cells(NameOf(MODEL.ST02_FUTEKIGO_ICHIRAN.CLOSE_FG)).Value = "1" Or Me.dgvDATA.CurrentRow.Cells(NameOf(MODEL.ST02_FUTEKIGO_ICHIRAN.DEL_YMDHNS)).Value.ToString.Trim <> "" Then
                            Me.dgvDATA.CurrentRow.Cells("SELECTED").Value = False 'Not CBool(Me.dgvDATA.CurrentRow.Cells("SELECTED").Value)
                        Else
                            Me.dgvDATA.CurrentRow.Cells("SELECTED").Value = Not CBool(Me.dgvDATA.CurrentRow.Cells("SELECTED").Value)
                            '    '選択不可
                            '    Me.dgvDATA.CurrentRow.Cells("SELECTED").Value = False
                            '    MessageBox.Show("未発注データ以外は選択出来ません。", "選択不可", MessageBoxButtons.OK, MessageBoxIcon.Information)
                        End If
                End Select

            End If
        Catch ex As Exception
            EM.ErrorSyori(ex, False, conblnNonMsg)
        Finally
            FunInitFuncButtonEnabled()
        End Try
    End Sub

#Region "編集可能セルOnMouse時カーソル変更"

    Private Sub Dgv_CellMouseMove(sender As Object, e As DataGridViewCellMouseEventArgs)
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
            Me.Cursor = Cursors.WaitCursor

            'ボタン不可/ボタンINDEX取得
            For intCNT = 0 To Me.cmdFunc.Length - 1
                Me.cmdFunc(intCNT).Enabled = False
                If cmdFunc(intCNT) Is sender Then intFUNC = intCNT + 1
            Next

            'ボタンINDEX毎の処理
            Select Case intFUNC
                Case 1  '検索

                    If IsValidatedSearchFilter() Then
                        Call FunSRCH(flxDATA, FunGetListData())
                    End If

                Case 2  '追加

                    If FunUpdateEntity(ENM_DATA_OPERATION_MODE._1_ADD) = True Then
                        Call FunSRCH(flxDATA, FunGetListData())
                    End If

                Case 4  '変更

                    If FunUpdateEntity(ENM_DATA_OPERATION_MODE._3_UPDATE) = True Then
                        Call FunSRCH(flxDATA, FunGetListData())
                    End If

                Case 5  '削除/復元/完全削除

                    'If MessageBox.Show("選択されたデータを削除しますか?", "削除確認", MessageBoxButtons.OKCancel, MessageBoxIcon.Information) = DialogResult.OK Then
                    If OpenFormEdit() Then
                        Dim dr As DataRow = DirectCast(flxDATA.Rows(flxDATA.Row).DataSource, DataRowView).Row
                        If FunDEL(Context.ENM_SYONIN_HOKOKUSYO_ID._4_FCCB.Value, dr.Item(NameOf(ST04_FCCB_ICHIRAN.FCCB_NO))) Then
                            Call FunSRCH(flxDATA, FunGetListData())
                        End If
                    End If

                Case 6 '復元
                    If flxDATA.Rows(flxDATA.RowSel) IsNot Nothing Then
                        If MessageBox.Show("選択されたデータを復元しますか?", "復元確認", MessageBoxButtons.OKCancel, MessageBoxIcon.Information) = DialogResult.OK Then
                            Dim dr As DataRow = DirectCast(flxDATA.Rows(flxDATA.Row).DataSource, DataRowView).Row
                            If FunRESTORE(Context.ENM_SYONIN_HOKOKUSYO_ID._4_FCCB.Value, dr.Item(NameOf(ST04_FCCB_ICHIRAN.FCCB_NO))) Then
                                Call FunSRCH(flxDATA, FunGetListData())
                            End If
                        End If
                    Else
                        MessageBox.Show("該当データが選択されていません。", "", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    End If

                Case 8 'CSV出力
                    Dim strFileName As String
                    strFileName = $"{"FCCB"}_{DateTime.Now:yyyyMMddHHmmss}.CSV"

                    Call FunCSV_OUTviaFlexGrid(flxDATA, strFileName, pub_APP_INFO.strOUTPUT_PATH)
                    'Call FunCSV_OUT(DirectCast(flxDATA.DataSource, DataView).Table, strFileName, pub_APP_INFO.strOUTPUT_PATH)
                Case 9 'メール送信

                    Call FunMailSending()
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
            If intFUNC <> 12 Then Call FunInitFuncButtonEnabled()

            '[アクティブ]
            Me.PrPG_STATUS = ENM_PG_STATUS._2_ACTIVE

            Me.Cursor = Cursors.Default
        End Try

    End Sub

#End Region

#Region "検索"

    Private Function FunGetListData() As DataTable
        Try

            'SPEC: PF01.2-(1) A 検索条件

            Dim dtBUFF = GetST04_FCCB_ICHIRAN()
            If dtBUFF Is Nothing Then Return Nothing
            If dtBUFF.Rows.Count > pub_APP_INFO.intSEARCHMAX Then
                If MessageBox.Show(My.Resources.infoSearchCountOver, "", MessageBoxButtons.YesNo, MessageBoxIcon.Information) = Windows.Forms.DialogResult.No Then
                    Return Nothing
                End If
            End If

            Dim t = GetType(ST04_FCCB_ICHIRAN)
            Dim tplDataModel = FunGetTableFromModel(t)

            If dtBUFF.Rows.Count = 0 Then Return tplDataModel.dt

            With dtBUFF
                For Each row As DataRow In .Rows
                    Dim Trow As DataRow = tplDataModel.dt.NewRow()
                    For Each p As Reflection.PropertyInfo In tplDataModel.properties
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
                                    If row.Item(p.Name).ToString.IsNulOrWS = False Then
                                        Select Case row.Item(p.Name).ToString.Length
                                            Case 6 'yyyyMM
                                                Trow(p.Name) = DateTime.ParseExact(row.Item(p.Name), "yyyyMM", Nothing).ToString("yyyy/MM")
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
                                    '特定列のみ加工
                                    Select Case p.Name
                                        'Case "SYONIN_NAIYO"
                                        '    Trow(p.Name) = row.Item("SYONIN_JUN") & "." & row.Item(p.Name).ToString.Trim
                                        Case "SASIMOTO_SYONIN_NAIYO"
                                            If row.Item("SASIMOTO_SYONIN_JUN") = "0" Then
                                                Trow(p.Name) = ""
                                            Else
                                                Trow(p.Name) = row.Item("SASIMOTO_SYONIN_JUN") & "." & row.Item(p.Name).ToString.Trim
                                            End If

                                        Case "KISO_YMD"
                                            Trow(p.Name) = If(row.Item(p.Name).ToString.IsNulOrWS, "", DateTime.ParseExact(row.Item(p.Name), "yyyyMMdd", Nothing).ToString("yyyy/MM/dd"))
                                        Case Else
                                            Trow(p.Name) = row.Item(p.Name).ToString.Trim
                                    End Select
                            End Select
                        End If
                    Next p
                    tplDataModel.dt.Rows.Add(Trow)
                Next row
                tplDataModel.dt.AcceptChanges()
            End With

            'CHECK: 部門抽出条件適用 ログインユーザーの所属と異なる部門条件の場合・・・(すべて)を含む
            Dim blnIsAdmin As Boolean = IsSysAdminUser(pub_SYAIN_INFO.SYAIN_ID)
            If blnIsAdmin Then
                'システム管理者のみ制限解除
            Else
                'If pub_SYAIN_INFO.BUMON_KB <> ParamModel.BUMON_KB Then
                Select Case pub_SYAIN_INFO.BUMON_KB
                    Case Context.ENM_BUMON_KB._1_風防, Context.ENM_BUMON_KB._2_LP
                        Dim qdt = tplDataModel.dt.AsEnumerable.Where(Function(r) r.Field(Of String)("BUMON_KB") = 1 Or r.Field(Of String)("BUMON_KB") = 2).ToList
                        If qdt.Count > 0 Then
                            tplDataModel.dt = qdt.CopyToDataTable
                        End If

                    Case Context.ENM_BUMON_KB._3_複合材
                        Dim qdt = tplDataModel.dt.AsEnumerable.Where(Function(r) r.Field(Of String)("BUMON_KB") = 3).ToList
                        If qdt.Count > 0 Then
                            tplDataModel.dt = qdt.CopyToDataTable
                        End If
                End Select
                'End If
            End If

            Return tplDataModel.dt

            'Dim _Model As New MODEL.ModelInfo(Of MODEL.ST02_FUTEKIGO_ICHIRAN)(srcDATA:=tplDataModel.dt)
            'Return _Model.Entities
        Catch ex As Exception
            EM.ErrorSyori(ex, False, conblnNonMsg)
            Return Nothing
        End Try
    End Function

    Private Function FunSRCH(ByVal flx As C1.Win.C1FlexGrid.C1FlexGrid, ByVal dt As DataTable) As Boolean
        Try

            flx.BeginUpdate()

            If dt IsNot Nothing Then

                mDataView = dt.DefaultView
                flx.DataSource = mDataView

                'flx.DataSource = dt
            Else
                mDataView = Nothing
                flx.DataSource = Nothing
            End If

            Call FunSetGridCellFormat(flx)

            If flx.Rows.Count > 1 Then
                '-----選択行設定
                Try

                    'flx.RowSel = intCURROW
                Catch dgvEx As Exception
                End Try
                Me.lblRecordCount.Text = String.Format(My.Resources.infoToolTipMsgFoundData, flx.Rows.Count - flx.Rows.Fixed.ToString)
            Else
                Me.lblRecordCount.Text = My.Resources.infoSearchResultNotFound
            End If

            lblRecordCount.Visible = True

            Return True
        Catch ex As Exception
            EM.ErrorSyori(ex, False, conblnNonMsg)
            Return False
        Finally

            flx.EndUpdate()
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

        Dim dlgRET As DialogResult

        Try

            Using frmFCCB As New FrmG0021_Detail
                frmFCCB.PrMODE = intMODE
                Select Case intMODE
                    Case ENM_DATA_OPERATION_MODE._1_ADD
                        frmFCCB.PrCurrentStage = ENM_FCCB_STAGE._10_起草入力
                    Case ENM_DATA_OPERATION_MODE._2_ADDREF, ENM_DATA_OPERATION_MODE._3_UPDATE
                        frmFCCB.PrDataRow = DirectCast(flxDATA.Rows(flxDATA.Row).DataSource, DataRowView).Row
                        frmFCCB.PrFCCB_NO = flxDATA.Rows(flxDATA.Row).Item(NameOf(ST04_FCCB_ICHIRAN.FCCB_NO))
                        frmFCCB.PrCurrentStage = IIf(flxDATA.Rows(flxDATA.Row).Item("SYONIN_JUN") = 0, 999, flxDATA.Rows(flxDATA.Row).Item("SYONIN_JUN"))
                End Select
                dlgRET = frmFCCB.ShowDialog(Me)
                Me.Refresh()

                If dlgRET = Windows.Forms.DialogResult.Cancel Then
                    Return False
                Else
                    Return True
                End If
            End Using
        Catch ex As Exception
            Throw
        Finally
            Me.Visible = True
        End Try
    End Function

#End Region

#Region "削除"

    Private Function FunDEL(ByVal intSYONIN_HOKOKUSYO_ID As Integer, ByVal strHOKOKU_NO As String) As Boolean
        Dim sbSQL As New System.Text.StringBuilder

        Try

            '-----UPDATE
            sbSQL.Append($"UPDATE {NameOf(D009_FCCB_J)} SET")
            sbSQL.Append($" {NameOf(D009_FCCB_J.DEL_SYAIN_ID)}={pub_SYAIN_INFO.SYAIN_ID}")
            sbSQL.Append($" ,{NameOf(D009_FCCB_J.DEL_YMDHNS)}=dbo.GetSysDateString()")
            sbSQL.Append($" WHERE {NameOf(D009_FCCB_J.FCCB_NO)}='{strHOKOKU_NO.ConvertSqlEscape}'")

            'CHECK: 一覧削除ボタン D004やR001等の編集履歴はどうするか

            '-----SQL実行
            Using DB As ClsDbUtility = DBOpen()
                Dim sqlEx As New Exception
                Dim blnErr As Boolean
                Dim intRET As Integer
                Try
                    DB.BeginTransaction()

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

    Private Function FunRESTORE(ByVal intSYONIN_HOKOKUSYO_ID As Integer, ByVal strHOKOKU_NO As String) As Boolean
        Dim sbSQL As New System.Text.StringBuilder

        Try

            '-----UPDATE
            sbSQL.Remove(0, sbSQL.Length)
            sbSQL.Append($"UPDATE {NameOf(D009_FCCB_J)} SET")
            sbSQL.Append($" {NameOf(D009_FCCB_J.DEL_SYAIN_ID)}={0}")
            sbSQL.Append($" ,{NameOf(D009_FCCB_J.DEL_YMDHNS)}=''")
            sbSQL.Append($" WHERE {NameOf(D009_FCCB_J.FCCB_NO)}='{strHOKOKU_NO.ConvertSqlEscape}'")

            'CHECK: 一覧削除ボタン D004やR001等の編集履歴はどうするか

            '-----SQL実行
            Using DB As ClsDbUtility = DBOpen()
                Dim sqlEx As New Exception
                Dim blnErr As Boolean
                Dim intRET As Integer
                Try
                    DB.BeginTransaction()

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

#Region "削除理由ダイアログ"

    Private Function OpenFormEdit() As Boolean
        Dim frmDLG As New FrmG0024_EditComment
        Dim dlgRET As DialogResult

        Try

            With flxDATA.Rows(flxDATA.RowSel)
                frmDLG.PrSYORI_NAME = "取消登録"
                frmDLG.PrSYONIN_HOKOKUSYO_ID = .Item(NameOf(V013_FCCB_ICHIRAN.SYONIN_HOKOKUSYO_ID))
                frmDLG.PrHOKOKU_NO = .Item(NameOf(V013_FCCB_ICHIRAN.FCCB_NO))
                frmDLG.PrBUMON_KB = .Item(NameOf(V013_FCCB_ICHIRAN.BUMON_KB))
                frmDLG.PrBUHIN_BANGO = .Item(NameOf(V013_FCCB_ICHIRAN.BUHIN_BANGO))
                frmDLG.PrKISYU_NAME = tblKISYU.LazyLoad("機種").AsEnumerable.Where(Function(r) r.Field(Of Integer)("VALUE") = .Item(NameOf(V013_FCCB_ICHIRAN.KISYU_ID))).FirstOrDefault?.Item("DISP")
                frmDLG.PrCurrentStage = .Item(NameOf(V013_FCCB_ICHIRAN.SYONIN_JUN))
            End With

            dlgRET = frmDLG.ShowDialog(Me)

            If dlgRET = Windows.Forms.DialogResult.OK Then
                Me.DialogResult = DialogResult.OK
                Return True
            Else
                Return False
            End If
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

#Region "メール送信"

    Private Function FunMailSending() As Boolean
        Try
            Me.Cursor = Cursors.WaitCursor
            Dim dt = DirectCast(flxDATA.DataSource, DataView).Table.AsEnumerable.
                                    Where(Function(r) r.Field(Of Integer)(NameOf(ST04_FCCB_ICHIRAN.TAIRYU_NISSU)) >= 6 And
                                                      r.Field(Of String)(NameOf(ST04_FCCB_ICHIRAN.GEN_TANTO_NAME)).ToString.IsNulOrWS = False)
            Dim strTantoNameList As String = ""

            If dt.Count > 0 Then
                For Each dr As DataRow In dt.CopyToDataTable.Rows
                    If strTantoNameList.IsNulOrWS Then
                        strTantoNameList = dr.Item(NameOf(MODEL.ST02_FUTEKIGO_ICHIRAN.GEN_TANTO_NAME))
                    Else
                        If Not strTantoNameList.Contains(dr.Item(NameOf(MODEL.ST02_FUTEKIGO_ICHIRAN.GEN_TANTO_NAME))) Then
                            strTantoNameList &= vbCrLf & dr.Item(NameOf(MODEL.ST02_FUTEKIGO_ICHIRAN.GEN_TANTO_NAME))
                        End If
                    End If
                Next dr

                Using DB As ClsDbUtility = DBOpen()
                    Dim blnErr As Boolean
                    Try
                        DB.BeginTransaction()

                        Dim strMsg As String = "以下の担当者に処置滞留通知メールを送信します。" & vbCrLf &
                                                   "よろしいですか？" & vbCrLf &
                                                   vbCrLf &
                                                   strTantoNameList
                        If MessageBox.Show(strMsg, "処置滞留通知メール送信", MessageBoxButtons.OKCancel, MessageBoxIcon.Information) = DialogResult.OK Then
                            For Each dr As DataRow In dt.CopyToDataTable.Rows
                                Dim strEXEParam As String = $"{dr.Item(NameOf(ST04_FCCB_ICHIRAN.GEN_TANTO_ID))},{ENM_OPEN_MODE._2_処置画面起動},{dr.Item(NameOf(ST04_FCCB_ICHIRAN.SYONIN_HOKOKUSYO_ID))},{dr.Item(NameOf(ST04_FCCB_ICHIRAN.FCCB_NO))}"
                                Dim strSubject As String = $"【FCCB処置依頼】FCCB-NO:{dr.Item("FCCB_NO")} {dr.Item(NameOf(ST04_FCCB_ICHIRAN.KISYU_NAME))}・{dr.Item(NameOf(ST04_FCCB_ICHIRAN.BUHIN_BANGO))}"
                                Dim strBody As String = <body><![CDATA[
                                {0} 殿<br />
                                <br />
                                　FCCB記録書の処置依頼から【滞留日数】{1}日が経過しています。<br />
                                　早急に対応をお願いします。<br />
                                <br />
                                　　【報 告 書】{2}<br />
                                　　【報告書No】{3}<br />
                                　　【起 草 日】{4}<br />
                                　　【機　  種】{5}<br />
                                　　【部品番号】{6}<br />
                                　　【依 頼 者】{7}<br />
                                <br />
                                <a href = "http://sv04:8000/CLICKONCE_FMS.application" > システム起動</a><br />
                                <br />
                                ※このメールは配信専用です。(返信できません)<br />
                                返信する場合は、各担当者のメールアドレスを使用して下さい。<br />
                                ]]></body>.Value.Trim

                                'http://sv116:8000/CLICKONCE_FMS.application?SYAIN_ID={7}&EXEPATH={8}&PARAMS={9}

                                strBody = String.Format(strBody,
                                    dr.Item("GEN_TANTO_NAME").ToString.Trim,
                                    dr.Item("TAIRYU_NISSU").ToString.Trim,
                                    dr.Item("SYONIN_HOKOKUSYO_R_NAME").ToString.Trim,
                                    dr.Item("FCCB_NO").ToString.Trim,
                                    dr.Item("KISO_YMD").ToString,
                                    dr.Item("KISYU_NAME").ToString.Trim,
                                    dr.Item("BUHIN_BANGO").ToString.Trim,
                                    "FCCB記録書管理システム",
                                    dr.Item("GEN_TANTO_ID"),
                                    "FMS_G0020.exe",
                                    strEXEParam)

                                Dim users As New List(Of Integer)
                                users.Add(dr.Item("GEN_TANTO_ID"))

                                If FunSendMailFCCB(strSubject, strBody, users) Then
                                    If FunSAVE_R001(DB, dr) Then
                                    Else
                                        blnErr = True
                                        Return False
                                    End If
                                Else
                                    MessageBox.Show("メール送信に失敗しました。", "メール送信失敗", MessageBoxButtons.OK, MessageBoxIcon.Information)
                                    blnErr = True
                                    Return False
                                End If
                            Next dr

                            MessageBox.Show("処置依頼メールを送信しました。", "メール送信完了", MessageBoxButtons.OK, MessageBoxIcon.Information)

                            ''全選択解除
                            'Call FunUnSelectAll()

                            Return True
                        End If
                    Finally
                        DB.Commit(Not blnErr)
                    End Try
                End Using
            Else
                Dim dr As DataRow = DirectCast(flxDATA.Rows(flxDATA.Row).DataSource, DataRowView).Row

                '選択チェックは入っていない場合、選択行のみ
                Dim strMsg As String = "以下の担当者に処置滞留通知メールを送信します。" & vbCrLf &
                                    "よろしいですか？" & vbCrLf &
                                    vbCrLf &
                                    dr.Item(NameOf(ST04_FCCB_ICHIRAN.GEN_TANTO_NAME))

                If MessageBox.Show(strMsg, "処置滞留通知メール送信", MessageBoxButtons.OKCancel, MessageBoxIcon.Information) = DialogResult.OK Then

                    Dim strEXEParam As String = dr.Item(NameOf(ST04_FCCB_ICHIRAN.GEN_TANTO_ID)) & "," & ENM_OPEN_MODE._2_処置画面起動 & "," & dr.Item(NameOf(ST04_FCCB_ICHIRAN.SYONIN_HOKOKUSYO_ID)) & "," & dr.Item(NameOf(MODEL.ST02_FUTEKIGO_ICHIRAN.HOKOKU_NO))
                    Dim strSubject As String = $"【FCCB処置依頼】FCCB-NO:{dr.Item(NameOf(ST04_FCCB_ICHIRAN.FCCB_NO))} {dr.Item(NameOf(ST04_FCCB_ICHIRAN.KISYU_NAME))}・{dr.Item(NameOf(ST04_FCCB_ICHIRAN.BUHIN_BANGO))}"
                    Dim strBody As String = <body><![CDATA[
                    {0} 殿<br />
                    <br />
                    　FCCB記録書の処置依頼から【滞留日数】{1}日が経過しています。<br />
                    　早急に対応をお願いします。<br />
                    <br />
                    【報告書No】{3}<br />
                    【起 草 日】{4}<br />
                    【機　  種】{5}<br />
                    【部品番号】{6}<br />
                    【依 頼 者】{7}<br />
                    <br />
                    <a href = "http://sv04:8000/CLICKONCE_FMS.application" > システム起動</a><br />
                    <br />
                    ※このメールは配信専用です。(返信できません)<br />
                    返信する場合は、各担当者のメールアドレスを使用して下さい。<br />
                    ]]></body>.Value.Trim

                    'http://sv116:8000/CLICKONCE_FMS.application?SYAIN_ID={7}&EXEPATH={8}&PARAMS={9}

                    strBody = String.Format(strBody,
                                dr.Item("GEN_TANTO_NAME"),
                                dr.Item("TAIRYU_NISSU"),
                                dr.Item("SYONIN_HOKOKUSYO_R_NAME"),
                                dr.Item("HOKOKU_NO"),
                                dr.Item("KISO_YMD").ToString,
                                dr.Item("KISYU_NAME"),
                                dr.Item("BUHIN_BANGO"),
                                Fun_GetUSER_NAME(pub_SYAIN_INFO.SYAIN_ID),
                                dr.Item(NameOf(MODEL.ST02_FUTEKIGO_ICHIRAN.GEN_TANTO_ID)),
                                "FMS_G0020.exe",
                                strEXEParam)

                    Dim users As New List(Of Integer)
                    users.Add(dr.Item(NameOf(MODEL.ST02_FUTEKIGO_ICHIRAN.GEN_TANTO_ID)))

                    If FunSendMailFCCB(strSubject, strBody, users) Then

                        Using DB As ClsDbUtility = DBOpen()
                            Dim blnErr As Boolean
                            Try
                                DB.BeginTransaction()

                                If FunSAVE_R001(DB, dr) Then
                                    Return True
                                Else
                                    blnErr = True
                                    Return False
                                End If
                            Finally
                                DB.Commit(Not blnErr)
                            End Try
                        End Using
                    Else
                        MessageBox.Show("メール送信に失敗しました。", "メール送信失敗", MessageBoxButtons.OK, MessageBoxIcon.Information)
                        Return False
                    End If
                End If
            End If
        Catch ex As Exception
            EM.ErrorSyori(ex, False, conblnNonMsg)
        Finally
            Me.Cursor = Cursors.Default
        End Try
    End Function

    ''' <summary>
    ''' 報告書操作履歴更新
    ''' </summary>
    ''' <param name="DB"></param>
    ''' <param name="enmSAVE_MODE"></param>
    ''' <returns></returns>
    Private Function FunSAVE_R001(ByRef DB As ClsDbUtility, ByVal dr As DataRow) As Boolean
        Dim sbSQL As New System.Text.StringBuilder
        Dim intRET As Integer
        Dim sqlEx As New Exception
        Dim strSysDate As String = DB.GetSysDateString
        'MERGE INTO に変更

        '-----データモデル更新
        _R001_HOKOKU_SOUSA.Clear()
        _R001_HOKOKU_SOUSA.SYONIN_HOKOKUSYO_ID = dr.Item(NameOf(ST04_FCCB_ICHIRAN.SYONIN_HOKOKUSYO_ID))
        _R001_HOKOKU_SOUSA.HOKOKU_NO = dr.Item(NameOf(ST04_FCCB_ICHIRAN.FCCB_NO))
        _R001_HOKOKU_SOUSA.SYONIN_JUN = dr.Item(NameOf(ST04_FCCB_ICHIRAN.SYONIN_JUN))
        _R001_HOKOKU_SOUSA.SYAIN_ID = pub_SYAIN_INFO.SYAIN_ID
        _R001_HOKOKU_SOUSA.SOUSA_KB = ENM_SOUSA_KB._4_メール送信
        _R001_HOKOKU_SOUSA.SYONIN_HANTEI_KB = ENM_SYONIN_HANTEI_KB._0_未承認
        _R001_HOKOKU_SOUSA.RIYU = "処置滞留通知送信"
        _R001_HOKOKU_SOUSA.ADD_YMDHNS = strSysDate 'Now.ToString("yyyyMMddHHmmss")

        '-----INSERT R001
        sbSQL.Remove(0, sbSQL.Length)
        sbSQL.Append("INSERT INTO " & NameOf(MODEL.R001_HOKOKU_SOUSA) & "(")
        sbSQL.Append("  " & NameOf(_R001_HOKOKU_SOUSA.SYONIN_HOKOKUSYO_ID))
        sbSQL.Append(" ," & NameOf(_R001_HOKOKU_SOUSA.HOKOKU_NO))
        sbSQL.Append(" ," & NameOf(_R001_HOKOKU_SOUSA.ADD_YMDHNS))
        sbSQL.Append(" ," & NameOf(_R001_HOKOKU_SOUSA.SYONIN_JUN))
        sbSQL.Append(" ," & NameOf(_R001_HOKOKU_SOUSA.SOUSA_KB))
        sbSQL.Append(" ," & NameOf(_R001_HOKOKU_SOUSA.SYAIN_ID))
        sbSQL.Append(" ," & NameOf(_R001_HOKOKU_SOUSA.SYONIN_HANTEI_KB))
        sbSQL.Append(" ," & NameOf(_R001_HOKOKU_SOUSA.RIYU))
        sbSQL.Append(" ) VALUES(")
        sbSQL.Append("  " & _R001_HOKOKU_SOUSA.SYONIN_HOKOKUSYO_ID)
        sbSQL.Append(" ,'" & _R001_HOKOKU_SOUSA.HOKOKU_NO & "'")
        sbSQL.Append(" ,'" & _R001_HOKOKU_SOUSA.ADD_YMDHNS & "'")
        sbSQL.Append(" ," & _R001_HOKOKU_SOUSA.SYONIN_JUN)
        sbSQL.Append(" ,'" & _R001_HOKOKU_SOUSA.SOUSA_KB & "'")
        sbSQL.Append(" ," & _R001_HOKOKU_SOUSA.SYAIN_ID)
        sbSQL.Append(" ,'" & _R001_HOKOKU_SOUSA.SYONIN_HANTEI_KB & "'")
        sbSQL.Append(" ,'" & _R001_HOKOKU_SOUSA.RIYU.ConvertSqlEscape & "'")
        sbSQL.Append(")")

        '-----SQL実行
        intRET = DB.ExecuteNonQuery(sbSQL.ToString, conblnNonMsg, sqlEx)
        If intRET <> 1 Then
            '-----エラーログ出力
            Dim strErrMsg As String = My.Resources.ErrLogSqlExecutionFailure & sbSQL.ToString & "|" & sqlEx.Message
            WL.WriteLogDat(strErrMsg)
            Return False
        Else
            Return True
        End If
    End Function

#End Region

#Region "印刷"

    Private Function FunOpenReport() As Boolean
        Dim strOutputFileName As String
        Dim strTEMPFILE As String
        'Dim intRET As Integer
        Try
            Dim strHOKOKU_NO As String = flxDATA.Rows(flxDATA.RowSel).Item(NameOf(ST04_FCCB_ICHIRAN.FCCB_NO))
            Me.Cursor = Cursors.WaitCursor

            'ファイル名
            strOutputFileName = "FCCB_" & strHOKOKU_NO & "_Work.xlsx"

            '既存ファイル削除
            If FunDELETE_FILE(pub_APP_INFO.strOUTPUT_PATH & strOutputFileName) = False Then
                Return False
            End If

            Using iniIF As New IniFile(FunGetRootPath() & "\INI\" & CON_TEMPLATE_INI)
                strTEMPFILE = FunConvRootPath(iniIF.GetIniString("FCCB", "FILEPATH"))
            End Using

            'エクセル出力ファイル用意
            If OUT_EXCEL_READY(strTEMPFILE, pub_APP_INFO.strOUTPUT_PATH, strOutputFileName) = False Then
                Return False
            End If
            '-----書込処理
            If FunMakeReportFCCB(pub_APP_INFO.strOUTPUT_PATH & strOutputFileName, strHOKOKU_NO) = False Then
                Return False
            End If
        Catch ex As Exception
            EM.ErrorSyori(ex, False, conblnNonMsg)
            Return False
        Finally
            Me.Cursor = Cursors.Default
        End Try
    End Function

#End Region

#Region "履歴"

    Private Function OpenFormRIREKI() As Boolean
        Dim frmDLG As New FrmG0022_Rireki
        Dim dlgRET As DialogResult

        Try

            If flxDATA.Rows(flxDATA.RowSel) IsNot Nothing Then
                frmDLG.PrSYONIN_HOKOKUSYO_ID = flxDATA.Rows(flxDATA.RowSel).Item(NameOf(ST04_FCCB_ICHIRAN.SYONIN_HOKOKUSYO_ID))
                frmDLG.PrHOKOKU_NO = flxDATA.Rows(flxDATA.RowSel).Item(NameOf(ST04_FCCB_ICHIRAN.FCCB_NO))
                frmDLG.PrDatarow = DirectCast(flxDATA.Rows(flxDATA.Row).DataSource, DataRowView).Row
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
            Me.Visible = True
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
                    If .Text.Length = 0 OrElse .Text.Substring(0, .Text.IndexOf("(")).IsNulOrWS Then
                        .Text = ""
                        .Visible = False
                    End If
                End With
            Next intFunc

            cmdFunc1.Enabled = True
            cmdFunc2.Enabled = True
            cmdFunc12.Enabled = True

            If flxDATA.RowSel > 0 Then
                cmdFunc3.Enabled = True
                cmdFunc4.Enabled = True
                cmdFunc5.Enabled = True
                cmdFunc7.Enabled = True
                cmdFunc8.Enabled = True
                cmdFunc10.Enabled = True
                cmdFunc11.Enabled = True

                '選択行がClosedの場合
                If Val(flxDATA.Rows(flxDATA.RowSel).Item(NameOf(_D009.CLOSE_FG))) = 1 Then

                    If HasEditingRight(pub_SYAIN_INFO.SYAIN_ID) Then
                        cmdFunc4.Text = "修正(F4)"
                    Else
                        cmdFunc4.Text = "内容確認(F4)"
                    End If

                    'cmdFunc5.Enabled = False
                    'MyBase.ToolTip.SetToolTip(Me.cmdFunc5, "クローズ済のため取消出来ません")
                Else
                    cmdFunc4.Text = "変更・承認(F4)"
                    'MyBase.ToolTip.SetToolTip(Me.cmdFunc5, My.Resources.infoToolTipMsgNotFoundData)
                End If

                '削除ボタン
                If HasDeleteAuth(pub_SYAIN_INFO.SYAIN_ID,
                                     flxDATA.Rows(flxDATA.RowSel).Item(NameOf(ST04_FCCB_ICHIRAN.SYONIN_HOKOKUSYO_ID)),
                                     flxDATA.Rows(flxDATA.RowSel).Item(NameOf(ST04_FCCB_ICHIRAN.FCCB_NO))) Then

                    If flxDATA.Rows(flxDATA.RowSel).Item(NameOf(ST04_FCCB_ICHIRAN.CLOSE_FG)) = 1 Then
                        cmdFunc5.Enabled = False
                        MyBase.ToolTip.SetToolTip(Me.cmdFunc5, "Close済のデータです")
                        cmdFunc6.Enabled = True
                    ElseIf flxDATA.Rows(flxDATA.RowSel).Item(NameOf(_D009.DEL_YMDHNS)).ToString.Trim <> "" Then
                        cmdFunc5.Enabled = False
                        MyBase.ToolTip.SetToolTip(Me.cmdFunc5, "取消済みデータです")
                        cmdFunc6.Enabled = True
                    Else
                        cmdFunc5.Enabled = True
                    End If
                Else

                    If flxDATA.Rows(flxDATA.RowSel).Item(NameOf(ST04_FCCB_ICHIRAN.DEL_YMDHNS)).ToString.Trim <> "" Then
                        '削除済み
                        'cmdFunc4.Enabled = False
                        'MyBase.ToolTip.SetToolTip(Me.cmdFunc4, "取消済みデータです")
                        cmdFunc5.Enabled = False
                        MyBase.ToolTip.SetToolTip(Me.cmdFunc5, "取消済みデータです")
                        'flxDATA.Rows(flxDATA.RowSel).Item("SELECTED").ReadOnly = True
                    End If
                    'cmdFunc6.Visible = False
                    cmdFunc5.Enabled = False
                    MyBase.ToolTip.SetToolTip(Me.cmdFunc5, "取消機能の使用権限がありません")
                End If

                If FunblnAllowTairyuMailSend() Then
                    cmdFunc9.Enabled = True
                    MyBase.ToolTip.SetToolTip(Me.cmdFunc9, My.Resources.infoToolTipMsgNotFoundData)
                Else
                    cmdFunc9.Enabled = False
                    MyBase.ToolTip.SetToolTip(Me.cmdFunc9, "滞留通知メール送信権限がありません")
                End If
            Else
                    cmdFunc3.Enabled = False
                cmdFunc4.Enabled = False
                cmdFunc5.Enabled = False

                cmdFunc6.Enabled = False
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
        Call SetStageList()
    End Sub

    'Close済み
    Private Sub ChkClosedRowVisibled_Click(sender As Object, e As EventArgs) Handles chkClosedRowVisibled.Click
        If chkClosedRowVisibled.Checked Then
            RemoveHandler cmbGEN_TANTO.SelectedValueChanged, AddressOf SearchFilterValueChanged
            cmbGEN_TANTO.SelectedValue = 0
            AddHandler cmbGEN_TANTO.SelectedValueChanged, AddressOf SearchFilterValueChanged
        End If
    End Sub

    Private Async Sub ChkTairyu_CheckedChanged(sender As Object, e As EventArgs) Handles chkTairyu.CheckedChanged

        If chkTairyu.Checked Then
            'RemoveHandler chkDleteRowVisibled.CheckedChanged, AddressOf SearchFilterValueChanged
            'RemoveHandler chkClosedRowVisibled.CheckedChanged, AddressOf SearchFilterValueChanged

            Await Task.Run(Sub()
                               Me.Invoke(Sub()
                                             chkClosedRowVisibled.Checked = False
                                             chkDeleteRowVisibled.Checked = False
                                         End Sub)
                           End Sub)
            'AddHandler chkDleteRowVisibled.CheckedChanged, AddressOf SearchFilterValueChanged
            'AddHandler chkClosedRowVisibled.CheckedChanged, AddressOf SearchFilterValueChanged
        End If

        Call SetStageList()

    End Sub

#Region "検索条件クリア"

    Private Sub btnClearSrchFilter_Click(sender As Object, e As EventArgs) Handles btnClearSrchFilter.Click

        RemoveHandler chkDeleteRowVisibled.CheckedChanged, AddressOf SearchFilterValueChanged
        chkDeleteRowVisibled.Checked = False
        AddHandler chkDeleteRowVisibled.CheckedChanged, AddressOf SearchFilterValueChanged

    End Sub

#End Region

#Region "共通検索条件"

#Region "製品区分(部門区分)"

    Private Async Sub CmbBUMON_SelectedValueChanged(sender As Object, e As EventArgs)
        Dim cmb As ComboboxEx = DirectCast(sender, ComboboxEx)

        Await Task.Run(
            Sub()
                Me.Invoke(
                Sub()

                    Select Case cmb.SelectedValue?.ToString.Trim
                        Case ""

                            cmbGEN_TANTO.SelectedValue = 0
                            cmbBUMON.SelectedValue = ""
                        Case Context.ENM_BUMON_KB._2_LP
                            lblSyanaiCD.Visible = True
                            cmbSYANAI_CD.Visible = True

                        Case Else
                            lblSyanaiCD.Visible = False
                            cmbSYANAI_CD.Visible = False

                    End Select

                    Dim intBUFF As Integer
                    intBUFF = cmbADD_TANTO.SelectedValue
                    RemoveHandler cmbADD_TANTO.SelectedValueChanged, AddressOf SearchFilterValueChanged
                    Dim dtBUFF As DataTable = FunGetSYOZOKU_SYAIN(cmbBUMON.SelectedValue)
                    Dim dtADD_TANTO As New DataTableEx

                    Dim Trow2 As DataRow = dtADD_TANTO.NewRow()
                    If Not dtADD_TANTO.Rows.Contains(pub_SYAIN_INFO.SYAIN_ID) Then
                        Trow2("VALUE") = pub_SYAIN_INFO.SYAIN_ID
                        Trow2("DISP") = pub_SYAIN_INFO.SYAIN_NAME
                        dtADD_TANTO.Rows.Add(Trow2)
                    End If
                    For Each row As DataRow In dtBUFF.Rows
                        Dim Trow As DataRow = dtADD_TANTO.NewRow()
                        If Not dtADD_TANTO.Rows.Contains(row.Item("VALUE")) Then
                            Trow("VALUE") = row.Item("VALUE")
                            Trow("DISP") = row.Item("DISP")
                            dtADD_TANTO.Rows.Add(Trow)
                        End If
                    Next row

                    cmbADD_TANTO.SetDataSource(dtADD_TANTO, ENM_COMBO_SELECT_VALUE_TYPE._1_Filter)
                    cmbADD_TANTO.SelectedValue = intBUFF
                    AddHandler cmbADD_TANTO.SelectedValueChanged, AddressOf SearchFilterValueChanged

                    intBUFF = cmbGEN_TANTO.SelectedValue
                    RemoveHandler cmbGEN_TANTO.SelectedValueChanged, AddressOf SearchFilterValueChanged
                    cmbGEN_TANTO.DataBindings.Clear()
                    Dim dtGEN_TANTO As DataTable = FunGetSYONIN_SYOZOKU_SYAIN(cmbBUMON.SelectedValue)
                    cmbGEN_TANTO.SetDataSource(dtGEN_TANTO, ENM_COMBO_SELECT_VALUE_TYPE._1_Filter)
                    cmbGEN_TANTO.SelectedValue = intBUFF
                    AddHandler cmbGEN_TANTO.SelectedValueChanged, AddressOf SearchFilterValueChanged

                    Dim blnSelected As Boolean = (cmb.SelectedValue IsNot Nothing AndAlso Not cmb.SelectedValue.ToString.IsNulOrWS)

                    '機種
                    RemoveHandler cmbKISYU.SelectedValueChanged, AddressOf CmbKISYU_SelectedValueChanged
                    If blnSelected Then
                        Dim drs = tblKISYU_J.LazyLoad("機種実績").AsEnumerable.Where(Function(r) r.Field(Of String)(NameOf(ST04_FCCB_ICHIRAN.BUMON_KB)) = cmb.SelectedValue)
                        If drs.Count > 0 Then
                            Dim dt As DataTable = drs.CopyToDataTable
                            cmbKISYU.SetDataSource(dt, ENM_COMBO_SELECT_VALUE_TYPE._1_Filter)
                            cmbKISYU.SelectedValue = 0
                        End If
                    Else
                        cmbKISYU.SetDataSource(tblKISYU_J.LazyLoad("機種実績"), ENM_COMBO_SELECT_VALUE_TYPE._1_Filter)
                    End If
                    AddHandler cmbKISYU.SelectedValueChanged, AddressOf CmbKISYU_SelectedValueChanged

                    '部品番号
                    RemoveHandler cmbBUHIN_BANGO.SelectedValueChanged, AddressOf CmbBUHIN_BANGO_SelectedValueChanged
                    If blnSelected Then
                        Dim drs = tblBUHIN_J.LazyLoad("部品番号実績").AsEnumerable.Where(Function(r) r.Field(Of String)(NameOf(ST04_FCCB_ICHIRAN.BUMON_KB)) = cmb.SelectedValue)
                        If drs.Count > 0 Then
                            Dim dt As DataTable = drs.CopyToDataTable
                            cmbBUHIN_BANGO.SetDataSource(dt, ENM_COMBO_SELECT_VALUE_TYPE._1_Filter)
                            cmbBUHIN_BANGO.SelectedValue = ""
                        End If
                    Else
                        cmbBUHIN_BANGO.SetDataSource(tblBUHIN_J.LazyLoad("部品番号実績"), ENM_COMBO_SELECT_VALUE_TYPE._1_Filter)
                    End If
                    AddHandler cmbBUHIN_BANGO.SelectedValueChanged, AddressOf CmbBUHIN_BANGO_SelectedValueChanged

                    '社内コード
                    RemoveHandler cmbSYANAI_CD.SelectedValueChanged, AddressOf CmbSYANAI_CD_SelectedValueChanged
                    cmbSYANAI_CD.DataBindings.Clear()
                    If blnSelected Then
                        If Val(cmb.SelectedValue) = Context.ENM_BUMON_KB._2_LP Then
                            Dim drs = tblSYANAI_CD_J.LazyLoad("社内CD実績").AsEnumerable.Where(Function(r) r.Field(Of String)(NameOf(ST04_FCCB_ICHIRAN.BUMON_KB)) = cmb.SelectedValue)
                            If drs.Count > 0 Then
                                Dim dt As DataTable = drs.CopyToDataTable
                                cmbSYANAI_CD.SetDataSource(dt, ENM_COMBO_SELECT_VALUE_TYPE._1_Filter)
                            Else
                                cmbSYANAI_CD.DataSource = Nothing
                            End If
                        Else
                            'cmbSYANAI_CD.DataSource = Nothing
                        End If
                        cmbSYANAI_CD.SelectedValue = ""
                    Else
                        cmbSYANAI_CD.SetDataSource(tblSYANAI_CD_J.LazyLoad("社内CD実績"), ENM_COMBO_SELECT_VALUE_TYPE._1_Filter)
                    End If
                    AddHandler cmbSYANAI_CD.SelectedValueChanged, AddressOf CmbSYANAI_CD_SelectedValueChanged

                End Sub)
            End Sub)

    End Sub

#End Region

#Region "機種"

    Private Async Sub CmbKISYU_SelectedValueChanged(sender As Object, e As EventArgs)
        Dim cmb As ComboboxEx = DirectCast(sender, ComboboxEx)

        Await Task.Run(
            Sub()
                Me.Invoke(
                Sub()
                    '部品番号

                    RemoveHandler cmbBUHIN_BANGO.SelectedValueChanged, AddressOf CmbBUHIN_BANGO_SelectedValueChanged
                    cmbBUHIN_BANGO.DataBindings.Clear()
                    If cmb.IsSelected Then
                        Dim drs = tblBUHIN_J.LazyLoad("部品番号実績").AsEnumerable.Where(Function(r) r.Field(Of Integer)(NameOf(_D009.KISYU_ID)) = cmb.SelectedValue)
                        If drs.Count > 0 Then
                            Dim dt As DataTable = drs.CopyToDataTable
                            Dim _selectedValue As String = cmbBUHIN_BANGO.SelectedValue

                            cmbBUHIN_BANGO.SetDataSource(dt, ENM_COMBO_SELECT_VALUE_TYPE._1_Filter)
                            If Not cmbBUHIN_BANGO.NullValue = cmbBUHIN_BANGO.SelectedValue Then
                                'ParamModel.BUHIN_BANGO = _selectedValue
                            End If
                        End If
                    Else
                        cmbBUHIN_BANGO.SetDataSource(tblBUHIN_J.LazyLoad("部品番号実績"), ENM_COMBO_SELECT_VALUE_TYPE._1_Filter)
                    End If
                    AddHandler cmbBUHIN_BANGO.SelectedValueChanged, AddressOf CmbBUHIN_BANGO_SelectedValueChanged

                    If Val(cmbBUMON.SelectedValue) = ENM_BUMON_KB._2_LP Then
                        '社内コード
                        RemoveHandler cmbSYANAI_CD.SelectedValueChanged, AddressOf CmbSYANAI_CD_SelectedValueChanged
                        cmbSYANAI_CD.DataBindings.Clear()

                        If cmb.IsSelected Then
                            If Val(cmb.SelectedValue) = Context.ENM_BUMON_KB._2_LP Then
                                Dim drs = tblSYANAI_CD_J.LazyLoad("社内CD実績").AsEnumerable.Where(Function(r) r.Field(Of Integer)(NameOf(ST04_FCCB_ICHIRAN.KISYU_ID)) = cmb.SelectedValue)
                                If drs.Count > 0 Then
                                    Dim dt As DataTable = drs.CopyToDataTable
                                    Dim _selectedValue As String = cmbSYANAI_CD.SelectedValue

                                    cmbSYANAI_CD.SetDataSource(dt, ENM_COMBO_SELECT_VALUE_TYPE._1_Filter)
                                    If Not cmbSYANAI_CD.NullValue = _selectedValue Then
                                        'ParamModel.SYANAI_CD = _selectedValue
                                    End If
                                End If
                            Else
                                'cmbSYANAI_CD.DataSource = Nothing
                            End If
                            'ParamModel.SYANAI_CD = ""
                        Else
                            cmbSYANAI_CD.SetDataSource(tblSYANAI_CD_J.LazyLoad("社内CD実績"), ENM_COMBO_SELECT_VALUE_TYPE._1_Filter)
                        End If
                        AddHandler cmbSYANAI_CD.SelectedValueChanged, AddressOf CmbSYANAI_CD_SelectedValueChanged

                    End If

                End Sub)
            End Sub)

    End Sub

#End Region

#Region "社内コード"

    Private Async Sub CmbSYANAI_CD_SelectedValueChanged(sender As Object, e As EventArgs)
        Dim cmb As ComboboxEx = DirectCast(sender, ComboboxEx)
        Try

            RemoveHandler cmbSYANAI_CD.SelectedValueChanged, AddressOf CmbSYANAI_CD_SelectedValueChanged

            Await Task.Run(
                Sub()
                    Me.Invoke(
                    Sub()
                        '部品番号
                        RemoveHandler cmbBUHIN_BANGO.SelectedValueChanged, AddressOf CmbBUHIN_BANGO_SelectedValueChanged
                        If cmb.IsSelected Then
                            Dim drs = tblBUHIN_J.LazyLoad("部品番号実績").AsEnumerable.Where(Function(r) r.Field(Of String)(NameOf(ST04_FCCB_ICHIRAN.SYANAI_CD)) = cmb.SelectedValue).ToList
                            If drs.Count > 0 Then cmbBUHIN_BANGO.SetDataSource(drs.CopyToDataTable, ENM_COMBO_SELECT_VALUE_TYPE._1_Filter)
                        Else
                            cmbBUHIN_BANGO.SetDataSource(tblBUHIN_J.LazyLoad("部品番号実績"), ENM_COMBO_SELECT_VALUE_TYPE._1_Filter)
                        End If
                        AddHandler cmbBUHIN_BANGO.SelectedValueChanged, AddressOf CmbBUHIN_BANGO_SelectedValueChanged

                        '抽出
                        RemoveHandler cmbBUHIN_BANGO.SelectedValueChanged, AddressOf CmbBUHIN_BANGO_SelectedValueChanged
                        RemoveHandler cmbKISYU.SelectedValueChanged, AddressOf CmbKISYU_SelectedValueChanged

                        If cmb.IsSelected Then
                            Dim dr = DirectCast(cmbSYANAI_CD.DataSource, DataTable).AsEnumerable.
                                                                Where(Function(r) r.Field(Of String)("VALUE") = cmb.SelectedValue).
                                                                FirstOrDefault
                            If dr IsNot Nothing Then

                                cmbBUHIN_BANGO.SelectedValue = dr.Item("BUHIN_BANGO")
                                mtxHINMEI.Text = dr.Item("BUHIN_NAME")
                                cmbKISYU.SelectedValue = dr.Item("KISYU_ID")
                            End If
                        Else
                            cmbBUHIN_BANGO.SelectedValue = ""
                            mtxHINMEI.Text = ""
                            cmbKISYU.SelectedValue = 0
                        End If
                        AddHandler cmbBUHIN_BANGO.SelectedValueChanged, AddressOf CmbBUHIN_BANGO_SelectedValueChanged
                        AddHandler cmbKISYU.SelectedValueChanged, AddressOf CmbKISYU_SelectedValueChanged

                        AddHandler cmbSYANAI_CD.SelectedValueChanged, AddressOf CmbSYANAI_CD_SelectedValueChanged

                    End Sub)
                End Sub)
        Catch ex As Exception
            Stop
        End Try
    End Sub

#End Region

#Region "部品番号"

    Private Async Sub CmbBUHIN_BANGO_SelectedValueChanged(sender As Object, e As EventArgs)
        Dim cmb As ComboboxEx = DirectCast(sender, ComboboxEx)

        'RemoveHandler cmbBUHIN_BANGO.SelectedValueChanged, AddressOf CmbBUHIN_BANGO_SelectedValueChanged
        'RemoveHandler cmbSYANAI_CD.SelectedValueChanged, AddressOf CmbSYANAI_CD_SelectedValueChanged

        Await Task.Run(Sub()
                           Me.Invoke(Sub()

                                         '社内コード
                                         If cmb.IsSelected Then
                                             cmbSYANAI_CD.DataBindings.Clear()
                                             If Val(cmb.SelectedValue) = Context.ENM_BUMON_KB._2_LP Then
                                                 Dim drs = tblSYANAI_CD.LazyLoad("社内CD").AsEnumerable.Where(Function(r) r.Field(Of String)(NameOf(ST04_FCCB_ICHIRAN.BUHIN_BANGO)) = cmb.SelectedValue).ToList
                                                 If drs.Count > 0 Then
                                                     Dim dt As DataTable = drs.CopyToDataTable
                                                     Dim _selectedValue As String = cmbSYANAI_CD.SelectedValue
                                                     cmbSYANAI_CD.DisplayMember = "DISP"
                                                     cmbSYANAI_CD.ValueMember = "VALUE"
                                                     cmbSYANAI_CD.SetDataSource(dt, ENM_COMBO_SELECT_VALUE_TYPE._1_Filter)
                                                     cmbSYANAI_CD.SelectedValue = _selectedValue
                                                 End If
                                             Else
                                                 cmbSYANAI_CD.SelectedValue = ""
                                                 'cmbSYANAI_CD.DataSource = Nothing
                                             End If
                                             'cmbSYANAI_CD.DataBindings.Add(New Binding(NameOf(cmbSYANAI_CD.SelectedValue), ParamModel, NameOf(ParamModel.SYANAI_CD), False, DataSourceUpdateMode.OnPropertyChanged, ""))
                                         Else
                                             cmbSYANAI_CD.SetDataSource(tblSYANAI_CD.LazyLoad("社内CD").ExcludeDeleted, ENM_COMBO_SELECT_VALUE_TYPE._1_Filter)
                                         End If
                                         'AddHandler cmbSYANAI_CD.SelectedValueChanged, AddressOf CmbSYANAI_CD_SelectedValueChanged

                                         '抽出
                                         If cmb.IsSelected Then
                                             Dim dr As DataRow = DirectCast(cmbBUHIN_BANGO.DataSource, DataTable).
                                                                    AsEnumerable.Where(Function(r) r.Field(Of String)("VALUE") = cmbBUHIN_BANGO.SelectedValue).
                                                                    FirstOrDefault

                                             If Val(cmb.SelectedValue) = Context.ENM_BUMON_KB._2_LP Then
                                                 'RemoveHandler cmbSYANAI_CD.SelectedValueChanged, AddressOf CmbSYANAI_CD_SelectedValueChanged
                                                 cmbSYANAI_CD.SelectedValue = dr.Item("SYANAI_CD")
                                                 'AddHandler cmbSYANAI_CD.SelectedValueChanged, AddressOf CmbSYANAI_CD_SelectedValueChanged
                                             End If
                                             mtxHINMEI.Text = dr.Item("BUHIN_NAME")

                                             'RemoveHandler cmbKISYU.SelectedValueChanged, AddressOf CmbKISYU_SelectedValueChanged
                                             If dr.Item("KISYU_ID") <> 0 Then
                                                 cmbKISYU.SelectedValue = dr.Item("KISYU_ID")
                                             End If
                                             'AddHandler cmbKISYU.SelectedValueChanged, AddressOf CmbKISYU_SelectedValueChanged
                                         Else
                                             cmbSYANAI_CD.SelectedValue = ""
                                             mtxHINMEI.Text = ""
                                             cmbKISYU.SelectedValue = 0
                                         End If
                                         'AddHandler cmbBUHIN_BANGO.SelectedValueChanged, AddressOf CmbBUHIN_BANGO_SelectedValueChanged
                                     End Sub)
                       End Sub)
    End Sub

#End Region

#End Region

#Region "入力チェック"

    Private Sub CmbHOKOKUSYO_ID_Validating(sender As Object, e As System.ComponentModel.CancelEventArgs)
        If pub_intOPEN_MODE <> ENM_OPEN_MODE._3_分析集計 Then Return

        Dim cmb As ComboboxEx = DirectCast(sender, ComboboxEx)
        If IsCheckRequired Then
            IsValidated *= ErrorProvider.UpdateErrorInfo(cmb, cmb.IsSelected, String.Format(My.Resources.infoMsgRequireSelectOrInput, "報告書名"))
        End If
    End Sub

    Private Function IsValidatedSearchFilter() As Boolean
        Try

            IsValidated = True
            IsCheckRequired = True

            Return True
        Catch ex As Exception
            Throw
        Finally
            IsCheckRequired = False
        End Try
    End Function

#End Region

#End Region

#Region "ローカル関数"

    Public Function GetST04_FCCB_ICHIRAN() As DataTable

        Dim sbSQL As New System.Text.StringBuilder
        Dim dsList As New DataSet

        sbSQL.Append($"SELECT * FROM {NameOf(V013_FCCB_ICHIRAN)}")
        sbSQL.Append($" WHERE 1=1")
        If Not mtxHOKUKO_NO.Text.IsNulOrWS Then
            sbSQL.Append($" AND {NameOf(V013_FCCB_ICHIRAN.FCCB_NO)} LIKE '%{mtxHOKUKO_NO.Text.Trim}%'")
        End If
        If cmbBUMON.IsSelected Then
            sbSQL.Append($" AND {NameOf(V013_FCCB_ICHIRAN.BUMON_KB)} ='{cmbBUMON.SelectedValue}'")
        End If
        If cmbADD_TANTO.IsSelected Then
            sbSQL.Append($" AND {NameOf(V013_FCCB_ICHIRAN.KISO_TANTO_ID)} = {cmbADD_TANTO.SelectedValue}")
        End If
        If cmbKISYU.IsSelected Then
            sbSQL.Append($" AND {NameOf(V013_FCCB_ICHIRAN.KISYU_ID)} = {cmbKISYU.SelectedValue}")
        End If
        If cmbBUHIN_BANGO.IsSelected Then
            sbSQL.Append($" AND {NameOf(V013_FCCB_ICHIRAN.BUHIN_BANGO)} LIKE '%{cmbBUHIN_BANGO.SelectedValue}%'")
        End If
        If cmbGEN_TANTO.IsSelected Then
            sbSQL.Append($" AND {NameOf(V013_FCCB_ICHIRAN.GEN_TANTO_ID)} = {cmbGEN_TANTO.SelectedValue}")
        End If
        If cmbSYANAI_CD.IsSelected Then
            sbSQL.Append($" AND {NameOf(V013_FCCB_ICHIRAN.SYANAI_CD)} LIKE '%{cmbSYANAI_CD.SelectedValue}%'")
        End If
        If Not mtxHINMEI.Text.IsNulOrWS Then
            sbSQL.Append($" AND {NameOf(V013_FCCB_ICHIRAN.BUHIN_NAME)} LIKE '%{mtxHINMEI.Text.Trim}%'")
        End If
        If chkTairyu.Checked Then
            sbSQL.Append($" AND {NameOf(V013_FCCB_ICHIRAN.TAIRYU_FG)} > '0'")
        End If
        If Not chkClosedRowVisibled.Checked Then
            sbSQL.Append($" AND {NameOf(V013_FCCB_ICHIRAN.CLOSE_FG)} = '0'")
        End If
        If Not chkDeleteRowVisibled.Checked Then
            sbSQL.Append($" AND RTRIM({NameOf(V013_FCCB_ICHIRAN.DEL_YMDHNS)}) = ''")
        End If

        Using DB As ClsDbUtility = DBOpen()
            dsList = DB.GetDataSet(sbSQL.ToString, conblnNonMsg)
        End Using

        Return dsList?.Tables(0)
    End Function

    Private Function FunblnAllowKIHYO() As Boolean
        Dim sbSQL As New System.Text.StringBuilder
        Dim dsList As New DataSet

        sbSQL.Remove(0, sbSQL.Length)
        sbSQL.Append("SELECT")
        sbSQL.Append(" *")
        sbSQL.Append($" FROM {NameOf(M016_SYONIN_TANTO)} ")
        sbSQL.Append($" WHERE {NameOf(M016_SYONIN_TANTO.SYONIN_HOKOKUSYO_ID)} ")
        sbSQL.Append($" IN({Context.ENM_SYONIN_HOKOKUSYO_ID._1_NCR.Value},{Context.ENM_SYONIN_HOKOKUSYO_ID._2_CAR.Value},{Context.ENM_SYONIN_HOKOKUSYO_ID._3_CTS.Value})")
        sbSQL.Append($" AND {NameOf(M016_SYONIN_TANTO.SYONIN_JUN)}=10")
        sbSQL.Append($" AND {NameOf(M016_SYONIN_TANTO.SYAIN_ID)}={pub_SYAIN_INFO.SYAIN_ID}")
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
        sbSQL.Append($" FROM {NameOf(M016_SYONIN_TANTO)} ")
        sbSQL.Append($" WHERE {NameOf(M016_SYONIN_TANTO.SYONIN_HOKOKUSYO_ID)} ")
        sbSQL.Append($" IN({Context.ENM_SYONIN_HOKOKUSYO_ID._1_NCR.Value},{Context.ENM_SYONIN_HOKOKUSYO_ID._2_CAR.Value},{Context.ENM_SYONIN_HOKOKUSYO_ID._3_CTS.Value})")
        sbSQL.Append($" AND {NameOf(M016_SYONIN_TANTO.SYONIN_JUN)}>10")
        sbSQL.Append($" AND {NameOf(M016_SYONIN_TANTO.SYAIN_ID)}={pub_SYAIN_INFO.SYAIN_ID}")
        Using DBa As ClsDbUtility = DBOpen()
            dsList = DBa.GetDataSet(sbSQL.ToString, conblnNonMsg)
        End Using

        If dsList.Tables(0).Rows.Count > 0 Then
            Return True
        Else
            Return False
        End If
    End Function

    Private Function FunblnAllowTairyuMailSend() As Boolean
        Dim sbSQL As New System.Text.StringBuilder
        Dim dsList As New DataSet

        sbSQL.Remove(0, sbSQL.Length)
        sbSQL.Append("SELECT")
        sbSQL.Append(" *")
        sbSQL.Append($" FROM {NameOf(MODEL.VWM001_SETTING)} ")
        sbSQL.Append($" WHERE {NameOf(MODEL.VWM001_SETTING.ITEM_NAME)}='滞留メール送信権限'")
        sbSQL.Append($" AND {NameOf(MODEL.VWM001_SETTING.ITEM_DISP)}='{pub_SYAIN_INFO.SYAIN_ID}'")
        Using DB As ClsDbUtility = DBOpen()
            dsList = DB.GetDataSet(sbSQL.ToString, conblnNonMsg)
        End Using

        If dsList.Tables(0).Rows.Count > 0 Then
            Return True
        Else
            Return False
        End If
    End Function

    Private Sub SetStageList()

    End Sub

#Region "削除ボタン使用権限判定"

    Private Function HasDeleteAuth(SYAIN_ID As Integer, HOKOKUSYO_ID As Integer, HOKOKU_NO As String) As Boolean

        Try
            'システムユーザーか
            If IsSysAdminUser(SYAIN_ID) Then
                Return True
            End If

            '指定の業務グループか
            If HasGYOMUGroupAuth(SYAIN_ID, {ENM_GYOMU_GROUP_ID._3_検査, ENM_GYOMU_GROUP_ID._4_品証}) Then
                Return True
            End If

            '#250 再不適合の報告書は起草者、未起草でも取消不可とする
            If HOKOKU_NO.Substring(HOKOKU_NO.Length - 1, 1).ToVal > 0 Then
                Return False
            End If

            '起草者
            If IsIssuedUser(SYAIN_ID, HOKOKUSYO_ID, HOKOKU_NO) Then
                Return True
            End If

            '未起草(ST1 一時保存か転送)は誰でも許可
            Dim sbSQL As New System.Text.StringBuilder
            Dim dsList As New DataSet
            sbSQL.Append($"SELECT ISNULL(MAX({NameOf(D004_SYONIN_J_KANRI.SYONIN_JUN)}),0)")
            sbSQL.Append($" FROM {NameOf(D004_SYONIN_J_KANRI)} ")
            sbSQL.Append($" WHERE {NameOf(D004_SYONIN_J_KANRI.HOKOKU_NO)}='{HOKOKU_NO}'")
            sbSQL.Append($" AND {NameOf(D004_SYONIN_J_KANRI.SYONIN_HOKOKUSYO_ID)}={HOKOKUSYO_ID}")
            sbSQL.Append($" AND {NameOf(D004_SYONIN_J_KANRI.SYONIN_HANTEI_KB)}='{ENM_SYONIN_HANTEI_KB._0_未承認.Value}'")

            Using DB As ClsDbUtility = DBOpen()
                dsList = DB.GetDataSet(sbSQL.ToString, conblnNonMsg)
            End Using
            If dsList.Tables(0).Rows(0).Item(0) = ENM_FCCB_STAGE._10_起草入力.Value Then
                Return True
            End If

            Return False
        Catch ex As Exception
            Throw
            Return False
        End Try
    End Function



#End Region

#End Region

End Class