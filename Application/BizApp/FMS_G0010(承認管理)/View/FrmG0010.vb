Imports System.ComponentModel
Imports System.Threading.Tasks
Imports C1.Win.C1FlexGrid
Imports JMS_COMMON.ClsPubMethod
Imports MODEL
Imports ST02 = MODEL.ST02_FUTEKIGO_ICHIRAN
Imports ST03 = MODEL.ST03_FUTEKIGO_ICHIRAN_SUMMARY

'Imports Spire.Xls
'Imports Spire.Pdf
'Imports Spire.Xls.Converter

''' <summary>
''' 不適合検索画面
''' </summary>
Public Class FrmG0010

#Region "定数・変数"

    Private ParamModel As New ST02_ParamModel
    Private IsValidated As Boolean = True

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

        '日付空欄許可
        dtJisiFrom.Nullable = True
        dtJisiTo.Nullable = True

        '先頭ウォーターマーク+バインドが必要なコンボボックスのための設定
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

    'Loadイベント
    Private Sub FrmLoad(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        Try
            Me.Visible = False

            '-----フォーム初期設定(親フォームから呼び出し)
            Call FunFormCommonSetting(pub_APP_INFO, pub_SYAIN_INFO, My.Application.Info.Version.ToString)

            'Call EnableDoubleBuffering(dgvDATA)
            Call EnableDoubleBuffering(dgvNCR)
            Call EnableDoubleBuffering(dgvCAR)
            Call EnableDoubleBuffering(dgvCTS)

            '-----グリッド初期設定(親フォームから呼び出し)
            'Call FunInitializeDataGridView(dgvDATA)
            Call FunInitializeFlexGrid(flxDATA)
            Call FunInitializeFlexGrid(_flexGroup.Grid)
            Call FunInitializeDataGridView(dgvNCR)
            Call FunInitializeDataGridView(dgvCAR)
            Call FunInitializeDataGridView(dgvCTS)
            dgvNCR.Anchor = AnchorStyles.Top Or AnchorStyles.Left
            dgvCAR.Anchor = AnchorStyles.Top Or AnchorStyles.Left
            dgvCTS.Anchor = AnchorStyles.Top Or AnchorStyles.Left

            '-----グリッド列作成
            'Call FunSetDgvCulumns(dgvDATA)
            Call FunSetDgvCulumnsHOKOKUSYO_StageFilter(dgvNCR)
            Call FunSetDgvCulumnsHOKOKUSYO_StageFilter(dgvCAR)
            Call FunSetDgvCulumnsHOKOKUSYO_StageFilter(dgvCTS)

            'SPEC: PF01.2-(1) A データソース

            '-----コントロールソース設定
            '共通
            cmbBUMON.SetDataSource(tblBUMON.ExcludeDeleted, ENM_COMBO_SELECT_VALUE_TYPE._1_Filter)
            cmbADD_TANTO.SetDataSource(tblTANTO.ExcludeDeleted, ENM_COMBO_SELECT_VALUE_TYPE._1_Filter)
            cmbKISYU.SetDataSource(tblKISYU_J, ENM_COMBO_SELECT_VALUE_TYPE._1_Filter)
            cmbHOKOKUSYO_ID.NullValue = 0
            cmbHOKOKUSYO_ID.SetDataSource(tblSYONIN_HOKOKUSYO_ID, ENM_COMBO_SELECT_VALUE_TYPE._0_Required)

            cmbBUHIN_BANGO.SetDataSource(tblBUHIN_J, ENM_COMBO_SELECT_VALUE_TYPE._1_Filter)
            'cmbFUTEKIGO_KB.SetDataSource(tblFUTEKIGO_KB.ExcludeDeleted, ENM_COMBO_SELECT_VALUE_TYPE._1_Filter)
            cmbFUTEKIGO_JYOTAI_KB.SetDataSource(tblFUTEKIGO_STATUS_KB.ExcludeDeleted, ENM_COMBO_SELECT_VALUE_TYPE._1_Filter)
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
                        ParamModel.BUMON_KB = pub_SYAIN_INFO.BUMON_KB
                        dtGEN_TANTO = FunGetSYONIN_SYOZOKU_SYAIN(pub_SYAIN_INFO.BUMON_KB)

                    Case Context.ENM_BUMON_KB._3_複合材
                        Dim dt As DataTable = DirectCast(cmbBUMON.DataSource, DataTable).
                                                    AsEnumerable.
                                                    Where(Function(r) r.Field(Of String)("VALUE") = pub_SYAIN_INFO.BUMON_KB).
                                                    CopyToDataTable
                        cmbBUMON.SetDataSource(dt, ENM_COMBO_SELECT_VALUE_TYPE._1_Filter)
                        cmbBUMON.SelectedValue = pub_SYAIN_INFO.BUMON_KB
                        ParamModel.BUMON_KB = pub_SYAIN_INFO.BUMON_KB
                        dtGEN_TANTO = FunGetSYONIN_SYOZOKU_SYAIN(cmbBUMON.SelectedValue)
                    Case Else

                End Select

                cmbGEN_TANTO.SetDataSource(dtGEN_TANTO, ENM_COMBO_SELECT_VALUE_TYPE._1_Filter)

                If Not IsOPAdminUser(pub_SYAIN_INFO.SYAIN_ID) Then
                    cmbGEN_TANTO.SelectedValue = pub_SYAIN_INFO.SYAIN_ID
                End If

                If cmbGEN_TANTO.SelectedValue IsNot Nothing AndAlso cmbGEN_TANTO.SelectedValue <> 0 Then ParamModel.SYOCHI_TANTO = pub_SYAIN_INFO.SYAIN_ID
            End If

            ''-----イベントハンドラ設定
            'AddHandler cmbBUMON.SelectedValueChanged, AddressOf SearchFilterValueChanged
            AddHandler cmbKISYU.SelectedValueChanged, AddressOf SearchFilterValueChanged
            AddHandler cmbSYANAI_CD.SelectedValueChanged, AddressOf SearchFilterValueChanged
            AddHandler cmbGEN_TANTO.SelectedValueChanged, AddressOf SearchFilterValueChanged
            AddHandler cmbFUTEKIGO_KB.SelectedValueChanged, AddressOf SearchFilterValueChanged
            AddHandler cmbFUTEKIGO_JYOTAI_KB.SelectedValueChanged, AddressOf SearchFilterValueChanged

            AddHandler mtxHOKUKO_NO.Validated, AddressOf SearchFilterValueChanged
            AddHandler mtxGOKI.Validated, AddressOf SearchFilterValueChanged
            AddHandler cmbBUHIN_BANGO.SelectedValueChanged, AddressOf SearchFilterValueChanged
            AddHandler dtJisiFrom.TxtChanged, AddressOf SearchFilterValueChanged
            AddHandler dtJisiTo.TxtChanged, AddressOf SearchFilterValueChanged
            AddHandler cmbFUTEKIGO_S_KB.SelectedValueChanged, AddressOf SearchFilterValueChanged
            AddHandler cmbADD_TANTO.SelectedValueChanged, AddressOf SearchFilterValueChanged
            AddHandler mtxHINMEI.Validated, AddressOf SearchFilterValueChanged
            AddHandler chkDeleteRowVisibled.CheckedChanged, AddressOf SearchFilterValueChanged
            AddHandler chkClosedRowVisibled.CheckedChanged, AddressOf SearchFilterValueChanged

            AddHandler cmbJIZEN_SINSA_HANTEI_KB.SelectedValueChanged, AddressOf SearchFilterValueChanged
            AddHandler cmbZESEI_SYOCHI_YOHI_KB.SelectedValueChanged, AddressOf SearchFilterValueChanged
            AddHandler cmbSAISIN_IINKAI_HANTEI_KB.SelectedValueChanged, AddressOf SearchFilterValueChanged
            AddHandler cmbKOKYAKU_HANTEI_SIJI_KB.SelectedValueChanged, AddressOf SearchFilterValueChanged
            AddHandler cmbKOKYAKU_SAISYU_HANTEI_KB.SelectedValueChanged, AddressOf SearchFilterValueChanged
            AddHandler cmbKENSA_KEKKA_KB.SelectedValueChanged, AddressOf SearchFilterValueChanged

            'Call FunInitFuncButtonEnabled()
            Call SetStageList()

            '起動モード別処理

            Using DB As ClsDbUtility = DBOpen()
                lblTytle.Text = FunGetCodeMastaValue(DB, "PG_TITLE", Me.GetType.ToString)
            End Using
            Select Case pub_intOPEN_MODE
                Case ENM_OPEN_MODE._0_通常

                    chkDispBUMON.Checked = True
                    chkDispADD_TANTO.Checked = True
                    chkDispKISYU.Checked = True
                    chkDispBUHIN_BANGO.Checked = True
                    chkDispHINMEI.Checked = True
                    chkDispGOKI.Checked = True
                    chkDispSYANAI_CD.Checked = True
                    chkDispHASSEI_YMD.Checked = True
                    chkDispFUTEKIGO_KB.Checked = True
                    chkDispFUTEKIGO_S_KB.Checked = True
                    chkDispFUTEKIGO_JYOTAI_KB.Checked = True

                    chkDispJIZEN_SINSA_HANTEI_KB.Checked = True
                    chkDispSAISIN_IINKAI_HANTEI_KB.Checked = True
                    chkDispKOKYAKU_SAISYU_HANTEI_KB.Checked = True
                    chkDispZESEI_SYOCHI_YOHI_KB.Checked = True
                    chkDispKOKYAKU_HANTEI_SIJI_KB.Checked = True
                    chkDispKENSA_KEKKA_KB.Checked = True
                    chkDispYOIN1.Checked = True
                    chkDispYOIN2.Checked = True
                    chkDispKISEKI_KOTEI_KB.Checked = True
                    chkDispGENIN1.Checked = True
                    chkDispGENIN2.Checked = True

                    Me.cmdFunc7.PerformClick()

                Case ENM_OPEN_MODE._1_新規作成

                    chkDispBUMON.Checked = True
                    chkDispADD_TANTO.Checked = True
                    chkDispKISYU.Checked = True
                    chkDispBUHIN_BANGO.Checked = True
                    chkDispHINMEI.Checked = True
                    chkDispGOKI.Checked = True
                    chkDispSYANAI_CD.Checked = True
                    chkDispHASSEI_YMD.Checked = True
                    chkDispFUTEKIGO_KB.Checked = True
                    chkDispFUTEKIGO_S_KB.Checked = True
                    chkDispFUTEKIGO_JYOTAI_KB.Checked = True

                    chkDispJIZEN_SINSA_HANTEI_KB.Checked = True
                    chkDispSAISIN_IINKAI_HANTEI_KB.Checked = True
                    chkDispKOKYAKU_SAISYU_HANTEI_KB.Checked = True
                    chkDispZESEI_SYOCHI_YOHI_KB.Checked = True
                    chkDispKOKYAKU_HANTEI_SIJI_KB.Checked = True
                    chkDispKENSA_KEKKA_KB.Checked = True
                    chkDispYOIN1.Checked = True
                    chkDispYOIN2.Checked = True
                    chkDispKISEKI_KOTEI_KB.Checked = True
                    chkDispGENIN1.Checked = True
                    chkDispGENIN2.Checked = True

                    If FunUpdateEntity(ENM_DATA_OPERATION_MODE._1_ADD) = True Then
                        Call FunSRCH(flxDATA, FunGetListData())
                    End If

                Case ENM_OPEN_MODE._2_処置画面起動
                    ParamModel.HOKOKU_NO = pub_PrHOKOKU_NO
                    ParamModel.SYONIN_HOKOKUSYO_ID = pub_PrSYONIN_HOKOKUSYO_ID
                    Me.cmdFunc1.PerformClick()
                    Me.cmdFunc4.PerformClick()

                Case ENM_OPEN_MODE._3_分析集計
                    Using DB As ClsDbUtility = DBOpen()
                        lblTytle.Text = "不適合集計画面"
                    End Using

                    cmdFunc2.Text = ""
                    cmdFunc4.Text = ""
                    cmdFunc5.Text = ""
                    cmdFunc9.Enabled = False
                    cmdFunc9.Text = ""
                    cmdFunc10.Text = ""
                    cmdFunc11.Text = ""

                    lblHOKOKUSYO_ID.Visible = True
                    cmbHOKOKUSYO_ID.Visible = True

                    chkDispHOKOKUSYO_ID.Visible = True
                    chkDispHOKOKUSYO_ID.Checked = True
                    chkDispHOKOKUSYO_ID.Enabled = False
                    chkDispKISYU.Visible = True
                    chkDispGOKI.Visible = True
                    lblGEN_TANTO.Visible = False
                    cmbGEN_TANTO.Visible = False
                    chkDispFUTEKIGO_KB.Visible = True

                    lblHOKUKO_NO.Visible = False
                    mtxHOKUKO_NO.Visible = False
                    chkDispBUHIN_BANGO.Visible = True
                    chkDispSYANAI_CD.Visible = True
                    chkDispFUTEKIGO_JYOTAI_KB.Visible = True
                    chkDispFUTEKIGO_S_KB.Visible = True
                    chkDispBUMON.Visible = True
                    chkDispHINMEI.Visible = True
                    chkDispHASSEI_YMD.Visible = True
                    lblJisiYMD.Visible = False
                    dtJisiFrom.Visible = False
                    lblJisi.Visible = False
                    dtJisiTo.Visible = False

                    chkDispJIZEN_SINSA_HANTEI_KB.Visible = True
                    chkDispSAISIN_IINKAI_HANTEI_KB.Visible = True
                    chkDispKOKYAKU_SAISYU_HANTEI_KB.Visible = True
                    chkDispZESEI_SYOCHI_YOHI_KB.Visible = True
                    chkDispKOKYAKU_HANTEI_SIJI_KB.Visible = True
                    chkDispKENSA_KEKKA_KB.Visible = True
                    chkDispYOIN1.Visible = True
                    chkDispYOIN2.Visible = True
                    chkDispKISEKI_KOTEI_KB.Visible = True
                    chkDispGENIN1.Visible = True
                    chkDispGENIN2.Visible = True

                    chkDispADD_TANTO.Visible = True
                    chkDeleteRowVisibled.Visible = False
                    chkClosedRowVisibled.Checked = True
                    chkClosedRowVisibled.Visible = False
                    chkTairyu.Visible = False

                    dgvCAR.Visible = False
                    dgvNCR.Visible = False
                    dgvCTS.Visible = False

                    cmbKISYU.Enabled = False
                    mtxGOKI.Enabled = False
                    cmbFUTEKIGO_KB.Enabled = False
                    cmbBUHIN_BANGO.Enabled = False
                    cmbSYANAI_CD.Enabled = False
                    cmbFUTEKIGO_JYOTAI_KB.Enabled = False
                    cmbFUTEKIGO_S_KB.Enabled = False
                    cmbBUMON.Enabled = False
                    mtxHINMEI.Enabled = False
                    dtHASSEI_YMD_FROM.Enabled = False
                    dtHASSEI_YMD_TO.Enabled = False
                    dtHASSEI_YMD_FROM.DisplayFormat = DateTextBoxEx.EnumType.yyyyMM
                    dtHASSEI_YMD_TO.DisplayFormat = DateTextBoxEx.EnumType.yyyyMM

                    cmbJIZEN_SINSA_HANTEI_KB.Enabled = False
                    cmbSAISIN_IINKAI_HANTEI_KB.Enabled = False
                    cmbKOKYAKU_SAISYU_HANTEI_KB.Enabled = False
                    cmbZESEI_SYOCHI_YOHI_KB.Enabled = False
                    cmbKOKYAKU_HANTEI_SIJI_KB.Enabled = False
                    cmbKENSA_KEKKA_KB.Enabled = False
                    cmbYOIN1.Enabled = False
                    cmbYOIN2.Enabled = False
                    cmbKISEKI_KOTEI_KB.Enabled = False
                    chkDispGENIN1.Checked = False
                    chkDispGENIN2.Checked = False
                    cmbADD_TANTO.Enabled = False

                Case Else
                    Me.cmdFunc1.PerformClick()
            End Select

            'ファンクションボタンステータス更新
            Call FunInitFuncButtonEnabled()
            Me.WindowState = FormWindowState.Maximized
        Finally
            Me.Visible = True
        End Try
    End Sub

    Private Sub FrmG0010_Activated(sender As Object, e As EventArgs) Handles MyBase.Activated
        Refresh()

    End Sub

#End Region

#Region "FlexGrid関連"

    '初期化
    Private Function FunInitializeFlexGrid(ByVal flxgrd As C1.Win.C1FlexGrid.C1FlexGrid) As Boolean
        With flxgrd
            .Rows(0).Height = 30
            .AutoGenerateColumns = False
            .AutoResize = True
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

            .Cols("HASSEI_YMD").Filter = New DateFilter
            .Cols("SYOCHI_YOTEI_YMD").Filter = New DateFilter
            .VisualStyle = C1.Win.C1FlexGrid.VisualStyle.Office2010Silver 'Custom

            '以下を適用するにはVisualStyleをCustomにする
            '.Styles.Alternate.BackColor = clrRowEvenColor
            '.Styles.Normal.BackColor = clrRowOddColor
            .Styles.Focus.BackColor = clrRowEnterColor
        End With
    End Function

    Private Sub FlxDATA_RowColChange(sender As Object, e As EventArgs) Handles flxDATA.RowColChange
        Call FunInitFuncButtonEnabled()
    End Sub

    Private Sub FlxDATA_AfterFilter(sender As Object, e As EventArgs) Handles flxDATA.AfterFilter
        Dim flx As C1.Win.C1FlexGrid.C1FlexGrid = DirectCast(sender, C1.Win.C1FlexGrid.C1FlexGrid)
        Dim intCNT As Integer

        For Each r As C1.Win.C1FlexGrid.Row In flx.Rows
            If r.Visible = True Then
                intCNT += 1
            End If
        Next
        intCNT -= flx.Rows.Fixed

        If intCNT > 0 Then
            Me.lblRecordCount.Text = String.Format(My.Resources.infoToolTipMsgFoundData, intCNT)
        Else
            Me.lblRecordCount.Text = My.Resources.infoSearchResultNotFound
        End If
    End Sub

    'Private Sub flxDATA_Click(sender As Object, e As EventArgs) Handles flxDATA.Click
    '    If flxDATA.ColSel = 1 Then
    '        Dim dr As DataRow = DirectCast(bindsrc.Current, DataRowView).Row
    '        dr.Item(0) = Not CBool(dr.Item(0))
    '    End If
    'End Sub

    'グリッドセル(行)ダブルクリック時イベント
    Private Sub FlxDATA_DoubleClick(sender As Object, e As EventArgs) Handles flxDATA.DoubleClick
        If flxDATA.RowSel > 0 Then
            Me.cmdFunc4.PerformClick()
        End If
    End Sub

    Private Sub flxDATA_AfterSort(sender As Object, e As C1.Win.C1FlexGrid.SortColEventArgs) Handles flxDATA.AfterSort
        Call FunSetGridCellFormat(flxDATA)
    End Sub

    Private Function FunSetGridCellFormat(ByVal flx As C1.Win.C1FlexGrid.C1FlexGrid) As Boolean

        Try

            If pub_intOPEN_MODE = ENM_OPEN_MODE._3_分析集計 Then
                flxDATA.Cols(NameOf(ST03.SELECTED)).Visible = False
                flxDATA.Cols(NameOf(ST03.HOKOKU_NO)).Visible = False
                flxDATA.Cols(NameOf(ST03.SYONIN_HOKOKUSYO_R_NAME)).Visible = True
                flxDATA.Cols(NameOf(ST03.SYONIN_NAIYO)).Visible = False
                flxDATA.Cols(NameOf(ST03.GEN_TANTO_NAME)).Visible = False
                flxDATA.Cols(NameOf(ST03.TAIRYU_NISSU)).Visible = False
                flxDATA.Cols(NameOf(ST03.JIZEN_SINSA_HANTEI_NAME)).Visible = False
                flxDATA.Cols(NameOf(ST03.SAISIN_IINKAI_HANTEI_NAME)).Visible = False
                flxDATA.Cols(NameOf(ST03.SYOCHI_YOTEI_YMD)).Visible = False
                flxDATA.Cols(NameOf(ST03.SASIMOTO_SYONIN_NAIYO)).Visible = False
                flxDATA.Cols(NameOf(ST03.RIYU)).Visible = False

                flxDATA.Cols(NameOf(ST03.KISYU_NAME)).Visible = chkDispKISYU.Checked
                flxDATA.Cols(NameOf(ST03.GOKI)).Visible = chkDispGOKI.Checked
                flxDATA.Cols(NameOf(ST03.FUTEKIGO_NAME)).Visible = chkDispFUTEKIGO_KB.Checked
                flxDATA.Cols(NameOf(ST03.BUHIN_BANGO)).Visible = chkDispBUHIN_BANGO.Checked
                flxDATA.Cols(NameOf(ST03.SYANAI_CD)).Visible = chkDispSYANAI_CD.Checked
                flxDATA.Cols(NameOf(ST03.FUTEKIGO_JYOTAI_NAME)).Visible = chkDispFUTEKIGO_JYOTAI_KB.Checked
                flxDATA.Cols(NameOf(ST03.FUTEKIGO_S_NAME)).Visible = chkDispFUTEKIGO_S_KB.Checked
                flxDATA.Cols(NameOf(ST03.BUMON_NAME)).Visible = chkDispBUMON.Checked
                flxDATA.Cols(NameOf(ST03.BUHIN_NAME)).Visible = chkDispHINMEI.Checked
                flxDATA.Cols(NameOf(ST03.HASSEI_YMD)).Visible = chkDispHASSEI_YMD.Checked
                flxDATA.Cols(NameOf(ST03.HASSEI_YMD)).DataType = GetType(Date)
                flxDATA.Cols(NameOf(ST03.HASSEI_YMD)).Format = "yyyy/MM"

                flxDATA.Cols(NameOf(ST03.SURYO)).Visible = True
                flxDATA.Cols(NameOf(ST03.SURYO)).Style.BackColor = Color.LightSkyBlue

                flxDATA.Cols(NameOf(ST03.KISO_KENSU)).Visible = True
                flxDATA.Cols(NameOf(ST03.SYOCHI_KENSU)).Visible = True
                flxDATA.Cols(NameOf(ST03.SYOCHI_ZANSU)).Visible = True
            Else

                Dim delStyle As C1.Win.C1FlexGrid.CellStyle = flx.Styles("delStyle")

                For Each r As C1.Win.C1FlexGrid.Row In flx.Rows
                    If r.Index > 0 Then

                        'Closed
                        If Val(r.Item(NameOf(MODEL.ST02_FUTEKIGO_ICHIRAN.CLOSE_FG))) > 0 Or r.Item(NameOf(MODEL.ST02_FUTEKIGO_ICHIRAN.DEL_YMDHNS)) <> "" Then
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
                            flx.SetCellStyle(r.Index, NameOf(MODEL.ST02_FUTEKIGO_ICHIRAN.TAIRYU_NISSU), delStyle)
                        Else
                            flx.SetCellStyle(r.Index, NameOf(MODEL.ST02_FUTEKIGO_ICHIRAN.TAIRYU_NISSU), Nothing)
                        End If
                    End If
                Next

                flxDATA.Cols(NameOf(ST03.SELECTED)).Visible = True
                flxDATA.Cols(NameOf(ST03.HOKOKU_NO)).Visible = True
                flxDATA.Cols(NameOf(ST03.SYONIN_HOKOKUSYO_R_NAME)).Visible = True
                flxDATA.Cols(NameOf(ST03.BUMON_NAME)).Visible = True
                flxDATA.Cols(NameOf(ST03.SYONIN_NAIYO)).Visible = True
                flxDATA.Cols(NameOf(ST03.GEN_TANTO_NAME)).Visible = True
                flxDATA.Cols(NameOf(ST03.TAIRYU_NISSU)).Visible = True
                flxDATA.Cols(NameOf(ST03.JIZEN_SINSA_HANTEI_NAME)).Visible = True
                flxDATA.Cols(NameOf(ST03.SAISIN_IINKAI_HANTEI_NAME)).Visible = True
                flxDATA.Cols(NameOf(ST03.SYOCHI_YOTEI_YMD)).Visible = True
                flxDATA.Cols(NameOf(ST03.SASIMOTO_SYONIN_NAIYO)).Visible = True
                flxDATA.Cols(NameOf(ST03.RIYU)).Visible = True

                flxDATA.Cols(NameOf(ST03.SURYO)).Visible = True
                flxDATA.Cols(NameOf(ST03.SURYO)).Style.BackColor = Color.White

                flxDATA.Cols(NameOf(ST03.KISO_KENSU)).Visible = False
                flxDATA.Cols(NameOf(ST03.SYOCHI_KENSU)).Visible = False
                flxDATA.Cols(NameOf(ST03.SYOCHI_ZANSU)).Visible = False
            End If
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

    Private Sub flex_BeforeMouseDown(ByVal sender As Object, ByVal e As C1.Win.C1FlexGrid.BeforeMouseDownEventArgs) Handles flxDATA.BeforeMouseDown
        ' 右クリック時
        If e.Button = Windows.Forms.MouseButtons.Right Then
            ' クリックされた位置を取得
            Dim h As C1.Win.C1FlexGrid.HitTestInfo
            h = flxDATA.HitTest(e.X, e.Y)
            ' カレントセルを移動
            flxDATA.Select(h.Row, h.Column)

            Dim selctValue As Object = flxDATA.Rows(flxDATA.RowSel).Item(flxDATA.ColSel)

            EqualFilter.Text = $"""{selctValue}"" に等しい"
            NotEqualFilter.Text = $"""{selctValue}"" に等しくない"
            IncludeFilter.Text = $"""{selctValue}"" を含む"
            NotIncludeFilter.Text = $"""{selctValue}"" を含まない"
            Dim tpl = (flxDATA.ColSel, selctValue)
            FlexContextMenu.Tag = tpl
            flxDATA.ContextMenuStrip = FlexContextMenu
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

    Private Sub dgv_ColumnHeaderMouseClick(ByVal sender As System.Object,
                ByVal e As System.Windows.Forms.DataGridViewCellMouseEventArgs) Handles dgvNCR.ColumnHeaderMouseClick, dgvCAR.ColumnHeaderMouseClick, dgvCTS.ColumnHeaderMouseClick
        Call dgv_Check(sender, e)
    End Sub

    Private Sub dgv_ColumnHeaderMouseDoubleClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellMouseEventArgs) Handles dgvNCR.ColumnHeaderMouseDoubleClick, dgvCAR.ColumnHeaderMouseDoubleClick, dgvCTS.ColumnHeaderMouseDoubleClick
        Call dgv_Check(sender, e)
    End Sub

    Private Sub dgv_Check(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellMouseEventArgs)
        Dim dgv As DataGridView
        Select Case sender.Name
            Case "dgvNCR"
                dgv = dgvNCR
            Case "dgvCAR"
                dgv = dgvCAR
            Case "dgvCTS"
                dgv = dgvCTS
            Case Else
                Exit Sub
        End Select

        dgv.Visible = False
        If dgv.Columns(e.ColumnIndex).Name = "SELECTED" Then
            Dim cell As _DataGridViewCustomCheckBoxHeaderCell = DirectCast(dgv.Columns(e.ColumnIndex).HeaderCell, _DataGridViewCustomCheckBoxHeaderCell)

            For Each dRow As DataGridViewRow In dgv.Rows
                dRow.Cells("SELECTED").Value = cell.Checked
            Next dRow
        End If
        dgv.Visible = True
    End Sub

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
                        If FunDEL(dr.Item(NameOf(MODEL.ST02_FUTEKIGO_ICHIRAN.SYONIN_HOKOKUSYO_ID)), dr.Item(NameOf(MODEL.ST02_FUTEKIGO_ICHIRAN.HOKOKU_NO))) = True Then
                            Call FunSRCH(flxDATA, FunGetListData())
                        End If
                    End If

                Case 6 '復元
                    If flxDATA.Rows(flxDATA.RowSel) IsNot Nothing Then
                        If MessageBox.Show("選択されたデータを復元しますか?", "復元確認", MessageBoxButtons.OKCancel, MessageBoxIcon.Information) = DialogResult.OK Then
                            Dim dr As DataRow = DirectCast(flxDATA.Rows(flxDATA.Row).DataSource, DataRowView).Row
                            If FunRESTORE(dr.Item(NameOf(MODEL.ST02_FUTEKIGO_ICHIRAN.SYONIN_HOKOKUSYO_ID)), dr.Item(NameOf(MODEL.ST02_FUTEKIGO_ICHIRAN.HOKOKU_NO))) = True Then
                                Call FunSRCH(flxDATA, FunGetListData())
                            End If
                        End If
                    Else
                        MessageBox.Show("該当データが選択されていません。", "", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    End If

                Case 7 '検索条件変更

                    Call SetStageList()

                Case 8 'CSV出力
                    Dim strFileName As String

                    If pub_intOPEN_MODE = ENM_OPEN_MODE._3_分析集計 Then
                        strFileName = $"不適合集計_{DateTime.Now:yyyyMMddHHmmss}.CSV"
                    Else
                        strFileName = $"{pub_APP_INFO.strTitle}_{DateTime.Now:yyyyMMddHHmmss}.CSV"
                    End If

                    Call FunCSV_OUT(flxDATA.DataSource, strFileName, pub_APP_INFO.strOUTPUT_PATH)

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

            Dim dtBUFF As DataTable = FunGetDtST02_FUTEKIGO_ICHIRAN(ParamModel, pub_intOPEN_MODE)
            If dtBUFF Is Nothing Then Return Nothing
            If dtBUFF.Rows.Count > pub_APP_INFO.intSEARCHMAX Then
                If MessageBox.Show(My.Resources.infoSearchCountOver, "", MessageBoxButtons.YesNo, MessageBoxIcon.Information) = Windows.Forms.DialogResult.No Then
                    Return Nothing
                End If
            End If

            '------DataTableに変換
            Dim t As Type
            If pub_intOPEN_MODE = ENM_OPEN_MODE._3_分析集計 Then
                t = GetType(ST03_FUTEKIGO_ICHIRAN_SUMMARY)
            Else
                t = GetType(ST02_FUTEKIGO_ICHIRAN)

                'UNDONE: 削除済み表示切替 可能ならストアドパラメータに条件設定を移行したい
                If chkDeleteRowVisibled.Checked Then
                Else
                    Dim drs As List(Of DataRow) = dtBUFF.AsEnumerable.Where(Function(r) r.Field(Of String)("DEL_YMDHNS").IsNulOrWS).ToList
                    If drs.Count > 0 Then
                        dtBUFF = drs.CopyToDataTable
                    Else
                        Return Nothing
                    End If
                End If

                'ステージ検索条件
                Dim dtWK = dtBUFF.AsEnumerable.Take(0)
                Dim NCR_Filter = DirectCast(Me.dgvNCR.DataSource, DataTable).AsEnumerable.Where(Function(r) r.Field(Of Boolean)("SELECTED") = True).ToList
                For Each row In NCR_Filter
                    dtWK = dtWK.AsEnumerable.
                            Union(dtBUFF.AsEnumerable.Where(Function(r) r.Field(Of Integer)("SYONIN_HOKOKUSYO_ID") = Context.ENM_SYONIN_HOKOKUSYO_ID._1_NCR And
                                                                        r.Field(Of Integer)("SYONIN_JUN") = row.Item("SYONIN_JUN")))
                Next row
                Dim CAR_Filter = DirectCast(Me.dgvCAR.DataSource, DataTable).AsEnumerable.Where(Function(r) r.Field(Of Boolean)("SELECTED") = True).ToList
                For Each row In CAR_Filter
                    dtWK = dtWK.AsEnumerable.
                     Union(dtBUFF.AsEnumerable.Where(Function(r) r.Field(Of Integer)("SYONIN_HOKOKUSYO_ID") = Context.ENM_SYONIN_HOKOKUSYO_ID._2_CAR And
                                                                 r.Field(Of Integer)("SYONIN_JUN") = row.Item("SYONIN_JUN")))
                Next row

                Dim CTS_Filter = DirectCast(Me.dgvCTS.DataSource, DataTable).AsEnumerable.Where(Function(r) r.Field(Of Boolean)("SELECTED") = True).ToList
                For Each row In CTS_Filter
                    dtWK = dtWK.AsEnumerable.
                     Union(dtBUFF.AsEnumerable.Where(Function(r) r.Field(Of Integer)("SYONIN_HOKOKUSYO_ID") = Context.ENM_SYONIN_HOKOKUSYO_ID._3_CTS And
                                                                 r.Field(Of Integer)("SYONIN_JUN") = row.Item("SYONIN_JUN")))
                Next row

                If dtWK.Count > 0 Then dtBUFF = dtWK.CopyToDataTable
            End If

            Dim tplDataModel = FunGetTableFromModel(t)

            With dtBUFF
                For Each row As DataRow In .Rows
                    Dim Trow As DataRow = tplDataModel.dt.NewRow()
                    For Each p As Reflection.PropertyInfo In tplDataModel.properties
                        If IsAutoGenerateField(t, p.Name) = True Then

                            If pub_intOPEN_MODE = ENM_OPEN_MODE._3_分析集計 And row.Table.Columns.Contains(p.Name) = False Then
                                '非表示列スキップ
                                Continue For
                            End If

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
                                                Trow(p.Name) = DateTime.ParseExact(row.Item(p.Name), "yyyyMM", Nothing)
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
                If pub_SYAIN_INFO.BUMON_KB <> ParamModel.BUMON_KB Then
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
                End If
            End If

            Return tplDataModel.dt

            'Dim _Model As New MODEL.ModelInfo(Of MODEL.ST02_FUTEKIGO_ICHIRAN)(srcDATA:=tplDataModel.dt)
            'Return _Model.Entities
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

            panelMan.SelectedPanel = panelMan.ManagedPanels(NameOf(mpnlDataGrid))
            lblRecordCount.Visible = True
            'Call FunSetDgvCellFormat(dgv)

            Return True
        Catch ex As Exception
            EM.ErrorSyori(ex, False, conblnNonMsg)
            Return False
        Finally
        End Try
    End Function

    Private Function FunSRCH(ByVal flx As C1.Win.C1FlexGrid.C1FlexGrid, ByVal dt As DataTable) As Boolean
        'Dim intCURROW As Integer
        Try

            '-----選択行記憶
            'If flx.Rows.Count > 1 Then
            '    intCURROW = flx.RowSel
            'End If

            flx.BeginUpdate()

            If dt IsNot Nothing Then

                flx.DataSource = dt

            End If

            flx.ClearFilter()
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

            panelMan.SelectedPanel = panelMan.ManagedPanels(NameOf(mpnlDataGrid))
            lblRecordCount.Visible = True
            'btnSummaryPage.Visible = True

            Return True
        Catch ex As Exception
            EM.ErrorSyori(ex, False, conblnNonMsg)
            Return False
        Finally

            '-----一覧可視
            'dgv.Visible = True
            flx.EndUpdate()
        End Try
    End Function

    Private Function FunSetStageList(dgv As DataGridView, SYONIN_HOKOKUSYO_ID As Context.ENM_SYONIN_HOKOKUSYO_ID) As Boolean
        Try

            Dim dtWK As DataTable
            If dgv.DataSource IsNot Nothing Then dtWK = dgv.DataSource
            ParamModel.SYONIN_HOKOKUSYO_ID = SYONIN_HOKOKUSYO_ID
            Dim dtBUFF As DataTable = FunGetDtST02_FUTEKIGO_ICHIRAN(ParamModel)

            Dim stageLlist As DataTable
            Select Case SYONIN_HOKOKUSYO_ID
                Case Context.ENM_SYONIN_HOKOKUSYO_ID._1_NCR
                    stageLlist = tblNCR
                Case Context.ENM_SYONIN_HOKOKUSYO_ID._2_CAR
                    stageLlist = tblCAR
                Case Context.ENM_SYONIN_HOKOKUSYO_ID._3_CTS
                    stageLlist = tblCTS
                Case Else
                    Return False
            End Select

            Dim JISSEKI_LIST As IEnumerable(Of IGrouping(Of Tuple(Of Integer, Integer, String), DataRow))

            If chkDeleteRowVisibled.Checked Then
                JISSEKI_LIST = dtBUFF.AsEnumerable.
                                    GroupBy(Function(g) Tuple.Create(g.Field(Of Integer)(NameOf(ParamModel.SYONIN_HOKOKUSYO_ID)),
                                                                     g.Field(Of Integer)("SYONIN_JUN"),
                                                                     g.Field(Of String)("SYONIN_NAIYO")))
            Else
                JISSEKI_LIST = dtBUFF.AsEnumerable.
                                    Where(Function(r) r.Field(Of String)("DEL_YMDHNS").IsNulOrWS = Not chkDeleteRowVisibled.Checked).
                                    GroupBy(Function(g) Tuple.Create(g.Field(Of Integer)(NameOf(ParamModel.SYONIN_HOKOKUSYO_ID)),
                                                                     g.Field(Of Integer)("SYONIN_JUN"),
                                                                     g.Field(Of String)("SYONIN_NAIYO")))
            End If

            Dim retTable As New DataTable
            retTable.Columns.Add("SELECTED", GetType(Boolean))
            retTable.Columns.Add("SYONIN_JUN", GetType(Integer))
            retTable.Columns.Add("SYONIN_NAIYO", GetType(String))
            retTable.Columns.Add("COUNT", GetType(Integer))

            retTable.PrimaryKey = {retTable.Columns("SYONIN_JUN")}

            For Each g In JISSEKI_LIST
                Dim dr As DataRow = retTable.NewRow

                dr("SELECTED") = True
                dr("SYONIN_JUN") = g.Key.Item2
                dr("SYONIN_NAIYO") = g.Key.Item3
                dr("COUNT") = g.Count
                retTable.Rows.Add(dr)
            Next g
            retTable.AcceptChanges()
            For Each s As DataRow In stageLlist.Rows
                If retTable.Rows.Contains(s.Item("VALUE")) = False Then
                    Dim dr As DataRow = retTable.NewRow
                    dr("SELECTED") = True
                    dr("SYONIN_JUN") = s.Item("VALUE")
                    dr("SYONIN_NAIYO") = s.Item("DISP")
                    dr("COUNT") = 0
                    retTable.Rows.Add(dr)
                End If
            Next s
            retTable.AcceptChanges()

            dgv.DataSource = retTable.AsEnumerable.OrderBy(Function(r) r.Field(Of Integer)("SYONIN_JUN")).CopyToDataTable

            Return True
        Catch ex As Exception
            Throw
            Return False
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
        Dim frmNCR As New FrmG0011
        Dim frmCAR As New FrmG0012
        Dim frmFCR As New FrmG0021
        Dim dlgRET As DialogResult

        Try

            Dim hokokusyo_id As Integer
            If flxDATA.Rows.Count > 1 Then
                hokokusyo_id = flxDATA.Rows(flxDATA.RowSel).Item(NameOf(ST02.SYONIN_HOKOKUSYO_ID))
            Else
                hokokusyo_id = 1
            End If
            Select Case hokokusyo_id
                Case Context.ENM_SYONIN_HOKOKUSYO_ID._1_NCR.Value
                    frmNCR.PrMODE = intMODE
                    If intMODE = ENM_DATA_OPERATION_MODE._1_ADD Then
                        'SPEC: 2.(3).B.②
                        frmNCR.PrCurrentStage = ENM_NCR_STAGE._10_起草入力
                        'frmNCR.PrDataRow = Nothing
                    Else
                        'frmNCR.PrDataRow = dgvDATA.GetDataRow()
                        frmNCR.PrHOKOKU_NO = flxDATA.Rows(flxDATA.Row).Item("HOKOKU_NO")
                        frmNCR.PrCurrentStage = IIf(flxDATA.Rows(flxDATA.Row).Item("SYONIN_JUN") = 0, 999, flxDATA.Rows(flxDATA.Row).Item("SYONIN_JUN"))
                    End If
                    dlgRET = frmNCR.ShowDialog(Me)
                    If dlgRET = Windows.Forms.DialogResult.Cancel Then
                        Return False
                    Else
                        '再不適合登録
                        If frmNCR.PrSAI_FUTEKIGO Then

                            Dim HOKOKU_NO As String = frmNCR.PrHOKOKU_NO
                            Dim CurrentStage As String = frmNCR.PrCurrentStage
                            frmNCR.Dispose()
                            frmNCR = New FrmG0011 With {
                                .PrMODE = intMODE,
                                .PrHOKOKU_NO = HOKOKU_NO,
                                .PrCurrentStage = CurrentStage
                            }

                            dlgRET = frmNCR.ShowDialog(Me)
                            If dlgRET = Windows.Forms.DialogResult.Cancel Then
                                Return False
                            End If
                        End If

                        Return True
                    End If

                Case Context.ENM_SYONIN_HOKOKUSYO_ID._2_CAR.Value
                    frmCAR.PrDataRow = DirectCast(flxDATA.Rows(flxDATA.Row).DataSource, DataRowView).Row
                    frmCAR.PrHOKOKU_NO = flxDATA.Rows(flxDATA.Row).Item("HOKOKU_NO")
                    frmCAR.PrCurrentStage = IIf(flxDATA.Rows(flxDATA.Row).Item("SYONIN_JUN") = 0, 999, flxDATA.Rows(flxDATA.Row).Item("SYONIN_JUN"))
                    dlgRET = frmCAR.ShowDialog(Me)
                    If dlgRET = Windows.Forms.DialogResult.Cancel Then
                        Return False
                    Else
                        Return True
                    End If
                Case Context.ENM_SYONIN_HOKOKUSYO_ID._3_CTS.Value
                    frmFCR.PrDataRow = DirectCast(flxDATA.Rows(flxDATA.Row).DataSource, DataRowView).Row
                    frmFCR.PrHOKOKU_NO = flxDATA.Rows(flxDATA.Row).Item("HOKOKU_NO")
                    frmFCR.PrCurrentStage = IIf(flxDATA.Rows(flxDATA.Row).Item("SYONIN_JUN") = 0, 999, flxDATA.Rows(flxDATA.Row).Item("SYONIN_JUN"))
                    dlgRET = frmFCR.ShowDialog(Me)
                    If dlgRET = Windows.Forms.DialogResult.Cancel Then
                        Return False
                    Else
                        Return True
                    End If

            End Select
        Catch ex As Exception
            EM.ErrorSyori(ex, False, conblnNonMsg)
            Return False
        Finally
            If frmNCR IsNot Nothing Then frmNCR.Dispose()

            If frmCAR IsNot Nothing Then frmCAR.Dispose()

            If frmFCR IsNot Nothing Then frmFCR.Dispose()

            Me.Visible = True
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
                Case Context.ENM_SYONIN_HOKOKUSYO_ID._1_NCR
                    sbSQL.Append($"UPDATE {NameOf(MODEL.D003_NCR_J)} SET")
                Case Context.ENM_SYONIN_HOKOKUSYO_ID._2_CAR
                    sbSQL.Append($"UPDATE {NameOf(MODEL.D005_CAR_J)} SET")
                Case Context.ENM_SYONIN_HOKOKUSYO_ID._3_CTS
                    sbSQL.Append($"UPDATE {NameOf(MODEL.D007_FCR_J)} SET")
            End Select
            sbSQL.Append($" {NameOf(MODEL.D003_NCR_J.DEL_SYAIN_ID)}={pub_SYAIN_INFO.SYAIN_ID}")
            sbSQL.Append($" ,{NameOf(MODEL.D003_NCR_J.DEL_YMDHNS)}=dbo.GetSysDateString()")
            sbSQL.Append($" WHERE {NameOf(MODEL.D003_NCR_J.HOKOKU_NO)}='{strHOKOKU_NO.ConvertSqlEscape}'")

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
            Select Case intSYONIN_HOKOKUSYO_ID
                Case Context.ENM_SYONIN_HOKOKUSYO_ID._1_NCR
                    sbSQL.Append($"UPDATE {NameOf(MODEL.D003_NCR_J)} SET")
                Case Context.ENM_SYONIN_HOKOKUSYO_ID._2_CAR
                    sbSQL.Append($"UPDATE {NameOf(MODEL.D005_CAR_J)} SET")
            End Select
            sbSQL.Append($" {NameOf(MODEL.D003_NCR_J.DEL_SYAIN_ID)}={0}")
            sbSQL.Append($" ,{NameOf(MODEL.D003_NCR_J.DEL_YMDHNS)}=''")
            sbSQL.Append($" WHERE {NameOf(MODEL.D003_NCR_J.HOKOKU_NO)}='{strHOKOKU_NO.ConvertSqlEscape}'")

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
        Dim frmDLG As New FrmG0020
        Dim dlgRET As DialogResult

        Try

            With flxDATA.Rows(flxDATA.RowSel)
                frmDLG.PrSYORI_NAME = "取消登録"
                frmDLG.PrSYONIN_HOKOKUSYO_ID = .Item(NameOf(V007_NCR_CAR.SYONIN_HOKOKUSYO_ID))
                frmDLG.PrHOKOKU_NO = .Item(NameOf(V007_NCR_CAR.HOKOKU_NO))
                frmDLG.PrBUMON_KB = .Item(NameOf(V007_NCR_CAR.BUMON_KB))
                frmDLG.PrBUHIN_BANGO = .Item(NameOf(V007_NCR_CAR.BUHIN_BANGO))
                'frmDLG.PrKISO_YMD = .Item(NameOf(V007_NCR_CAR.KISO_YMD)) 'DateTime.ParseExact(.Item(NameOf(V007_NCR_CAR.KISO_YMD)), "yyyyMMdd", Nothing).ToString("yyyy/MM/dd")
                frmDLG.PrKISYU_NAME = tblKISYU.AsEnumerable.Where(Function(r) r.Field(Of Integer)("VALUE") = .Item(NameOf(V007_NCR_CAR.KISYU_ID))).FirstOrDefault?.Item("DISP")
                frmDLG.PrCurrentStage = .Item(NameOf(V007_NCR_CAR.SYONIN_JUN))
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

#Region "全選択"

    Private Function FunSelectAll() As Boolean

        Try
            Dim rows = DirectCast(Me.flxDATA.DataSource, DataTable).AsEnumerable.Where(Function(r) r.Field(Of String)("CLOSE_FG") = "0" And r.Field(Of String)("DEL_YMDHNS").IsNulOrWS).ToList
            If rows.Count > 0 Then
                For Each row As DataRow In rows
                    row.Item("SELECTED") = True '"●"
                Next row

                '表示更新
                FunSetDgvCellFormat(Me.dgvDATA)
            Else
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

            'Dim dt As DataTable = DirectCast(Me.dgvDATA.DataSource, DataTable)
            Dim dt As DataTable = DirectCast(Me.flxDATA.DataSource, DataTable)
            dt.AsEnumerable.Where(Function(r) r.Field(Of Boolean)("SELECTED") = True).ForEach(Sub(r) r.Item("SELECTED") = False)
            flxDATA.Update()
            Return True
        Catch ex As Exception
            EM.ErrorSyori(ex, False, conblnNonMsg)
            Return False
        End Try
    End Function

#End Region

#Region "メール送信"

    Private Function FunMailSending() As Boolean
        Try
            Me.Cursor = Cursors.WaitCursor
            Dim dt = DirectCast(flxDATA.DataSource, DataTable).AsEnumerable.
                                    Where(Function(r) r.Field(Of Boolean)("SELECTED") = True)
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
                                Dim strEXEParam As String = $"{dr.Item(NameOf(ST02.GEN_TANTO_ID))},{ENM_OPEN_MODE._2_処置画面起動},{dr.Item(NameOf(ST02.SYONIN_HOKOKUSYO_ID))},{dr.Item(NameOf(ST02.HOKOKU_NO))}"
                                Dim strSubject As String = $"【不適合品処置依頼】[{dr.Item("SYONIN_HOKOKUSYO_R_NAME")}] {dr.Item(NameOf(ST02.KISYU_NAME))}・{dr.Item(NameOf(ST02.BUHIN_BANGO))}"
                                Dim strBody As String = <body><![CDATA[
                                {0} 殿<br />
                                <br />
                                　不適合製品の処置依頼から【滞留日数】{1}日が経過しています。<br />
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
                                dr.Item(NameOf(ST02.GEN_TANTO_NAME)),
                                dr.Item("TAIRYU_NISSU"),
                                dr.Item("SYONIN_HOKOKUSYO_R_NAME"),
                                dr.Item("HOKOKU_NO"),
                                dr.Item("KISO_YMD").ToString,
                                dr.Item("KISYU_NAME"),
                                dr.Item("BUHIN_BANGO"),
                                Fun_GetUSER_NAME(pub_SYAIN_INFO.SYAIN_ID),
                                dr.Item(NameOf(MODEL.ST02_FUTEKIGO_ICHIRAN.GEN_TANTO_ID)),
                                "FMS_G0010.exe",
                                strEXEParam)

                                If FunSendMailFutekigo(strSubject, strBody, ToSYAIN_ID:=dr.Item("GEN_TANTO_ID")) Then
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

                            '全選択解除
                            Call FunUnSelectAll()

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
                                    dr.Item(NameOf(MODEL.ST02_FUTEKIGO_ICHIRAN.GEN_TANTO_NAME))

                If MessageBox.Show(strMsg, "処置滞留通知メール送信", MessageBoxButtons.OKCancel, MessageBoxIcon.Information) = DialogResult.OK Then

                    Dim strEXEParam As String = dr.Item(NameOf(MODEL.ST02_FUTEKIGO_ICHIRAN.GEN_TANTO_ID)) & "," & ENM_OPEN_MODE._2_処置画面起動 & "," & dr.Item(NameOf(MODEL.ST02_FUTEKIGO_ICHIRAN.SYONIN_HOKOKUSYO_ID)) & "," & dr.Item(NameOf(MODEL.ST02_FUTEKIGO_ICHIRAN.HOKOKU_NO))
                    Dim strSubject As String = $"【不適合品処置依頼】[{dr.Item("SYONIN_HOKOKUSYO_R_NAME")}] {dr.Item(NameOf(ST02.KISYU_NAME))}・{dr.Item(NameOf(ST02.BUHIN_BANGO))}"
                    Dim strBody As String = <body><![CDATA[
                    {0} 殿<br />
                    <br />
                    　不適合製品の処置依頼から【滞留日数】{1}日が経過しています。<br />
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
                                dr.Item("GEN_TANTO_NAME"),
                                dr.Item("TAIRYU_NISSU"),
                                dr.Item("SYONIN_HOKOKUSYO_R_NAME"),
                                dr.Item("HOKOKU_NO"),
                                dr.Item("KISO_YMD").ToString,
                                dr.Item("KISYU_NAME"),
                                dr.Item("BUHIN_BANGO"),
                                Fun_GetUSER_NAME(pub_SYAIN_INFO.SYAIN_ID),
                                dr.Item(NameOf(MODEL.ST02_FUTEKIGO_ICHIRAN.GEN_TANTO_ID)),
                                "FMS_G0010.exe",
                                strEXEParam)

                    If FunSendMailFutekigo(strSubject, strBody, ToSYAIN_ID:=dr.Item(NameOf(MODEL.ST02_FUTEKIGO_ICHIRAN.GEN_TANTO_ID))) Then

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
        'UNDONE: MERGE INTO に変更

        '---存在確認
        'Dim dsList As New DataSet
        'Dim blnExist As Boolean
        'sbSQL.Append("SELECT HOKOKU_NO FROM " & NameOf(MODEL.R001_HOKOKU_SOUSA) & "")
        'sbSQL.Append(" WHERE HOKOKU_NO ='" & dr.Item("HOKOKU_NO") & "'")
        'dsList = DB.GetDataSet(sbSQL.ToString, conblnNonMsg)
        'If dsList.Tables(0).Rows.Count > 0 Then
        '    blnExist = True
        'End If

        '-----データモデル更新
        _R001_HOKOKU_SOUSA.Clear()
        _R001_HOKOKU_SOUSA.SYONIN_HOKOKUSYO_ID = dr.Item(NameOf(MODEL.ST02_FUTEKIGO_ICHIRAN.SYONIN_HOKOKUSYO_ID))
        _R001_HOKOKU_SOUSA.HOKOKU_NO = dr.Item(NameOf(MODEL.ST02_FUTEKIGO_ICHIRAN.HOKOKU_NO))
        _R001_HOKOKU_SOUSA.SYONIN_JUN = dr.Item(NameOf(MODEL.ST02_FUTEKIGO_ICHIRAN.SYONIN_JUN))
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
            Dim strHOKOKU_NO As String = flxDATA.Rows(flxDATA.RowSel).Item(NameOf(MODEL.ST02_FUTEKIGO_ICHIRAN.HOKOKU_NO))
            Me.Cursor = Cursors.WaitCursor
            Select Case flxDATA.Rows(flxDATA.RowSel).Item(NameOf(MODEL.ST02_FUTEKIGO_ICHIRAN.SYONIN_HOKOKUSYO_ID))
                Case Context.ENM_SYONIN_HOKOKUSYO_ID._1_NCR
                    'ファイル名
                    strOutputFileName = $"NCR_{strHOKOKU_NO}_Work.xls"

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

                Case Context.ENM_SYONIN_HOKOKUSYO_ID._2_CAR
                    'ファイル名
                    strOutputFileName = "CAR_" & strHOKOKU_NO & "_Work.xls"

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

                Case Context.ENM_SYONIN_HOKOKUSYO_ID._3_CTS
                    'ファイル名
                    strOutputFileName = "CTS_" & strHOKOKU_NO & "_Work.xls"

                    '既存ファイル削除
                    If FunDELETE_FILE(pub_APP_INFO.strOUTPUT_PATH & strOutputFileName) = False Then
                        Return False
                    End If

                    Using iniIF As New IniFile(FunGetRootPath() & "\INI\" & CON_TEMPLATE_INI)
                        strTEMPFILE = FunConvRootPath(iniIF.GetIniString("CTS", "FILEPATH"))
                    End Using

                    'エクセル出力ファイル用意
                    If OUT_EXCEL_READY(strTEMPFILE, pub_APP_INFO.strOUTPUT_PATH, strOutputFileName) = False Then
                        Return False
                    End If
                    '-----書込処理
                    If FunMakeReportCTS(pub_APP_INFO.strOUTPUT_PATH & strOutputFileName, strHOKOKU_NO) = False Then
                        Return False
                    End If
                Case Else
                    'err
                    Return False
            End Select
        Catch ex As Exception
            EM.ErrorSyori(ex, False, conblnNonMsg)
            Return False
        Finally
            Me.Cursor = Cursors.Default
        End Try
    End Function

    Private Function FunMakeReportNCR_SP(ByVal strFilePath As String, ByVal strHOKOKU_NO As String) As Boolean

        'Dim Workbook As New Spire.Xls.Workbook
        'Dim Sheet As Spire.Xls.Worksheet

        'Try

        '    Dim _V002_NCR_J As MODEL.V002_NCR_J = FunGetV002Model(strHOKOKU_NO)
        '    Dim _V003_SYONIN_J_KANRI_List As List(Of MODEL.V003_SYONIN_J_KANRI) = FunGetV003Model(Context.ENM_SYONIN_HOKOKUSYO_ID._1_NCR, strHOKOKU_NO)

        '    Workbook.LoadFromFile(strFilePath)
        '    Sheet = Workbook.Worksheets(0)

        '    'レコードフレーム初期化
        '    'spWork.Range("RECORD_FRAME").ClearContents()
        '    Sheet.Range(NameOf(_V002_NCR_J.BUHIN_BANGO)).Value = _V002_NCR_J.BUHIN_BANGO
        '    Sheet.Range(NameOf(_V002_NCR_J.BUHIN_NAME)).Value = _V002_NCR_J.BUHIN_NAME
        '    If Not _V002_NCR_J.FUTEKIGO_JYOTAI_KB.IsNullOrWhiteSpace Then
        '        Sheet.Range(NameOf(_V002_NCR_J.FUTEKIGO_JYOTAI_KB) & _V002_NCR_J.FUTEKIGO_JYOTAI_KB).Value = "TRUE"
        '    End If
        '    Sheet.Range(NameOf(_V002_NCR_J.FUTEKIGO_NAIYO)).Value = _V002_NCR_J.FUTEKIGO_NAIYO
        '    Sheet.Range(NameOf(_V002_NCR_J.GOKI)).Value = _V002_NCR_J.GOKI
        '    Sheet.Range(NameOf(_V002_NCR_J.HAIKYAKU_HOUHOU)).Value = "(その他の内容：" & _V002_NCR_J.HAIKYAKU_HOUHOU.PadRight(30) & ")"
        '    Sheet.Range(NameOf(_V002_NCR_J.HAIKYAKU_KB_NAME)).Value = _V002_NCR_J.HAIKYAKU_KB_NAME
        '    Sheet.Range(NameOf(_V002_NCR_J.HAIKYAKU_TANTO_NAME)).Value = _V002_NCR_J.HAIKYAKU_TANTO_NAME
        '    Sheet.Range(NameOf(_V002_NCR_J.HAIKYAKU_YMD)).Value = _V002_NCR_J.HAIKYAKU_YMD
        '    Sheet.Range(NameOf(_V002_NCR_J.HASSEI_KOTEI_GL_SYAIN_NAME)).Value = _V002_NCR_J.HASSEI_KOTEI_GL_SYAIN_NAME
        '    Sheet.Range(NameOf(_V002_NCR_J.HASSEI_KOTEI_GL_YMD)).Value = _V002_NCR_J.HASSEI_KOTEI_GL_YMD
        '    Sheet.Range(NameOf(_V002_NCR_J.HENKYAKU_BIKO)).Value = _V002_NCR_J.HENKYAKU_BIKO
        '    Sheet.Range(NameOf(_V002_NCR_J.HENKYAKU_SAKI)).Value = _V002_NCR_J.HENKYAKU_SAKI
        '    Sheet.Range(NameOf(_V002_NCR_J.HENKYAKU_TANTO_NAME)).Value = _V002_NCR_J.HENKYAKU_TANTO_NAME
        '    Sheet.Range(NameOf(_V002_NCR_J.HENKYAKU_YMD)).Value = _V002_NCR_J.HENKYAKU_YMD
        '    Sheet.Range(NameOf(_V002_NCR_J.HOKOKU_NO)).Value = _V002_NCR_J.HOKOKU_NO
        '    Sheet.Range(NameOf(_V002_NCR_J.ITAG_NO)).Value = _V002_NCR_J.ITAG_NO
        '    If Not _V002_NCR_J.JIZEN_SINSA_HANTEI_KB.IsNullOrWhiteSpace Then
        '        Sheet.Range(NameOf(_V002_NCR_J.JIZEN_SINSA_HANTEI_KB) & _V002_NCR_J.JIZEN_SINSA_HANTEI_KB).Value = "TRUE"
        '    End If
        '    Sheet.Range(NameOf(_V002_NCR_J.JIZEN_SINSA_SYAIN_NAME)).Value = _V002_NCR_J.JIZEN_SINSA_SYAIN_NAME
        '    Sheet.Range(NameOf(_V002_NCR_J.JIZEN_SINSA_YMD)).Value = _V002_NCR_J.JIZEN_SINSA_YMD
        '    Sheet.Range(NameOf(_V002_NCR_J.KANSATU_KEKKA)).Value = _V002_NCR_J.KANSATU_KEKKA
        '    Sheet.Range(NameOf(_V002_NCR_J.KENSA_KEKKA_NAME)).Value = _V002_NCR_J.KENSA_KEKKA_NAME
        '    Sheet.Range(NameOf(_V002_NCR_J.KENSA_TANTO_NAME)).Value = _V002_NCR_J.KENSA_TANTO_NAME
        '    Sheet.Range(NameOf(_V002_NCR_J.KISYU)).Value = _V002_NCR_J.KISYU
        '    Sheet.Range(NameOf(_V002_NCR_J.KOKYAKU_HANTEI_SIJI_NAME)).Value = _V002_NCR_J.KOKYAKU_HANTEI_SIJI_NAME
        '    Sheet.Range(NameOf(_V002_NCR_J.KOKYAKU_HANTEI_SIJI_YMD)).Value = _V002_NCR_J.KOKYAKU_HANTEI_SIJI_YMD
        '    Sheet.Range(NameOf(_V002_NCR_J.SAIHATU)).Value = _V002_NCR_J.SAIHATU
        '    Sheet.Range(NameOf(_V002_NCR_J.SAIKAKO_KENSA_YMD)).Value = _V002_NCR_J.SAIKAKO_KENSA_YMD
        '    Sheet.Range(NameOf(_V002_NCR_J.SAIKAKO_SAGYO_KAN_YMD)).Value = _V002_NCR_J.SAIKAKO_SAGYO_KAN_YMD
        '    Sheet.Range(NameOf(_V002_NCR_J.SAIKAKO_SIJI_NO)).Value = _V002_NCR_J.SAIKAKO_SIJI_NO
        '    Sheet.Range(NameOf(_V002_NCR_J.SAISIN_GIJYUTU_SYAIN_NAME)).Value = _V002_NCR_J.SAISIN_GIJYUTU_SYAIN_NAME
        '    Sheet.Range(NameOf(_V002_NCR_J.SAISIN_HINSYO_SYAIN_NAME)).Value = _V002_NCR_J.SAISIN_HINSYO_SYAIN_NAME
        '    Sheet.Range(NameOf(_V002_NCR_J.SAISIN_HINSYO_YMD)).Value = _V002_NCR_J.SAISIN_HINSYO_YMD
        '    If Not _V002_NCR_J.SAISIN_IINKAI_HANTEI_KB.IsNullOrWhiteSpace Then
        '        Sheet.Range(NameOf(_V002_NCR_J.SAISIN_IINKAI_HANTEI_KB) & _V002_NCR_J.SAISIN_IINKAI_HANTEI_KB).Value = "TRUE"
        '    End If
        '    Sheet.Range(NameOf(_V002_NCR_J.SAISIN_IINKAI_SIRYO_NO)).Value = _V002_NCR_J.SAISIN_IINKAI_SIRYO_NO
        '    Sheet.Range(NameOf(_V002_NCR_J.SAISIN_KAKUNIN_SYAIN_NAME)).Value = _V002_NCR_J.SAISIN_KAKUNIN_SYAIN_NAME
        '    Sheet.Range(NameOf(_V002_NCR_J.SAISIN_KAKUNIN_YMD)).Value = _V002_NCR_J.SAISIN_KAKUNIN_YMD
        '    Sheet.Range(NameOf(_V002_NCR_J.SEIGI_TANTO_NAME)).Value = _V002_NCR_J.SEIGI_TANTO_NAME
        '    Sheet.Range(NameOf(_V002_NCR_J.SEIZO_TANTO_NAME)).Value = _V002_NCR_J.SEIZO_TANTO_NAME
        '    Sheet.Range(NameOf(_V002_NCR_J.SURYO)).Value = _V002_NCR_J.SURYO
        '    Sheet.Range(NameOf(_V002_NCR_J.SYOCHI_D_SYOCHI_KIROKU)).Value = _V002_NCR_J.SYOCHI_D_SYOCHI_KIROKU
        '    Sheet.Range(NameOf(_V002_NCR_J.SYOCHI_D_UMU_NAME)).Value = _V002_NCR_J.SYOCHI_D_UMU_NAME
        '    Sheet.Range(NameOf(_V002_NCR_J.SYOCHI_D_YOHI_NAME)).Value = _V002_NCR_J.SYOCHI_D_YOHI_NAME
        '    Sheet.Range(NameOf(_V002_NCR_J.SYOCHI_E_SYOCHI_KIROKU)).Value = _V002_NCR_J.SYOCHI_E_SYOCHI_KIROKU
        '    Sheet.Range(NameOf(_V002_NCR_J.SYOCHI_E_UMU_NAME)).Value = _V002_NCR_J.SYOCHI_E_UMU_NAME
        '    Sheet.Range(NameOf(_V002_NCR_J.SYOCHI_E_YOHI_NAME)).Value = _V002_NCR_J.SYOCHI_E_YOHI_NAME
        '    Sheet.Range(NameOf(_V002_NCR_J.SYOCHI_KEKKA_A_NAME)).Value = _V002_NCR_J.SYOCHI_KEKKA_A_NAME
        '    Sheet.Range(NameOf(_V002_NCR_J.SYOCHI_KEKKA_B_NAME)).Value = _V002_NCR_J.SYOCHI_KEKKA_B_NAME
        '    Sheet.Range(NameOf(_V002_NCR_J.SYOCHI_KEKKA_C_NAME)).Value = _V002_NCR_J.SYOCHI_KEKKA_C_NAME
        '    Sheet.Range(NameOf(_V002_NCR_J.TENYO_BUHIN_BANGO)).Value = _V002_NCR_J.TENYO_BUHIN_BANGO
        '    Sheet.Range(NameOf(_V002_NCR_J.TENYO_GOKI)).Value = _V002_NCR_J.TENYO_GOKI
        '    Sheet.Range(NameOf(_V002_NCR_J.TENYO_KISYU)).Value = _V002_NCR_J.TENYO_KISYU
        '    Sheet.Range(NameOf(_V002_NCR_J.TENYO_YMD)).Value = _V002_NCR_J.TENYO_YMD
        '    Sheet.Range(NameOf(_V002_NCR_J.YOKYU_NAIYO)).Value = _V002_NCR_J.YOKYU_NAIYO
        '    Sheet.Range(NameOf(_V002_NCR_J.ZUMEN_KIKAKU)).Value = "(図面/規格　： " & _V002_NCR_J.ZUMEN_KIKAKU.PadRight(50) & ")"

        '    Sheet.Range("SYONIN_NAME10").Value = _V003_SYONIN_J_KANRI_List.Where(Function(r) r.SYONIN_JUN = ENM_NCR_STAGE._10_起草入力).FirstOrDefault?.SYAIN_NAME
        '    Sheet.Range("SYONIN_NAME20").Value = _V003_SYONIN_J_KANRI_List.Where(Function(r) r.SYONIN_JUN = ENM_NCR_STAGE._20_起草確認製造GL).FirstOrDefault?.SYAIN_NAME
        '    Sheet.Range("SYONIN_NAME30").Value = _V003_SYONIN_J_KANRI_List.Where(Function(r) r.SYONIN_JUN = ENM_NCR_STAGE._30_起草確認検査).FirstOrDefault?.SYAIN_NAME
        '    Sheet.Range("SYONIN_NAME90").Value = _V003_SYONIN_J_KANRI_List.Where(Function(r) r.SYONIN_JUN = ENM_NCR_STAGE._90_処置実施確認_管理T).FirstOrDefault?.SYAIN_NAME
        '    Sheet.Range("SYONIN_NAME100").Value = _V003_SYONIN_J_KANRI_List.Where(Function(r) r.SYONIN_JUN = ENM_NCR_STAGE._100_処置実施決裁_製造課長).FirstOrDefault?.SYAIN_NAME
        '    Sheet.Range("SYONIN_NAME110").Value = _V003_SYONIN_J_KANRI_List.Where(Function(r) r.SYONIN_JUN = ENM_NCR_STAGE._110_abcde処置担当).FirstOrDefault?.SYAIN_NAME
        '    Sheet.Range("SYONIN_NAME120").Value = _V003_SYONIN_J_KANRI_List.Where(Function(r) r.SYONIN_JUN = ENM_NCR_STAGE._120_abcde処置確認).FirstOrDefault?.SYAIN_NAME
        '    Sheet.Range("SYONIN_YMD20").Value = _V003_SYONIN_J_KANRI_List.Where(Function(r) r.SYONIN_JUN = ENM_NCR_STAGE._20_起草確認製造GL And r.SYONIN_HANTEI_KB = ENM_SYONIN_HANTEI_KB._1_承認).FirstOrDefault?.SYONIN_YMDHNS
        '    Sheet.Range("SYONIN_YMD30").Value = _V003_SYONIN_J_KANRI_List.Where(Function(r) r.SYONIN_JUN = ENM_NCR_STAGE._30_起草確認検査 And r.SYONIN_HANTEI_KB = ENM_SYONIN_HANTEI_KB._1_承認).FirstOrDefault?.SYONIN_YMDHNS
        '    Sheet.Range("SYONIN_YMD90").Value = _V003_SYONIN_J_KANRI_List.Where(Function(r) r.SYONIN_JUN = ENM_NCR_STAGE._90_処置実施確認_管理T And r.SYONIN_HANTEI_KB = ENM_SYONIN_HANTEI_KB._1_承認).FirstOrDefault?.SYONIN_YMDHNS
        '    Sheet.Range("SYONIN_YMD100").Value = _V003_SYONIN_J_KANRI_List.Where(Function(r) r.SYONIN_JUN = ENM_NCR_STAGE._100_処置実施決裁_製造課長 And r.SYONIN_HANTEI_KB = ENM_SYONIN_HANTEI_KB._1_承認).FirstOrDefault?.SYONIN_YMDHNS
        '    Sheet.Range("SYONIN_YMD110").Value = _V003_SYONIN_J_KANRI_List.Where(Function(r) r.SYONIN_JUN = ENM_NCR_STAGE._110_abcde処置担当 And r.SYONIN_HANTEI_KB = ENM_SYONIN_HANTEI_KB._1_承認).FirstOrDefault?.SYONIN_YMDHNS

        '    Dim pd As New System.Drawing.Printing.PrintDocument
        '    'プリンタ名の取得
        '    Dim defaultPrinterName As String = pd.PrinterSettings.PrinterName

        '    '-----ファイル保存
        '    Dim pdfDocument As New PdfDocument
        '    pdfDocument.PageSettings.Orientation = PdfPageOrientation.Landscape
        '    Dim pdfConverter As New PdfConverter(Workbook)
        '    Dim settings As New PdfConverterSettings With {
        '        .TemplateDocument = pdfDocument
        '    }

        '    Dim pdfFilePath As String
        '    pdfFilePath = System.IO.Path.GetDirectoryName(strFilePath) & "\" & System.IO.Path.GetFileNameWithoutExtension(strFilePath) & ".pdf"
        '    Workbook.SaveToPdf(pdfFilePath, settings)

        '    ''PDF表示
        '    System.Diagnostics.Process.Start(pdfFilePath)

        '    'Excel作業ファイルを削除
        '    Try
        '        'System.IO.File.Delete(strFilePath)
        '    Catch ex As UnauthorizedAccessException
        '    End Try

        '    Return True

        'Catch ex As Exception
        '    EM.ErrorSyori(ex, False, conblnNonMsg)
        '    Return False
        'Finally
        '    Sheet = Nothing
        '    Workbook = Nothing
        'End Try
    End Function

#End Region

#Region "履歴"

    Private Function OpenFormRIREKI() As Boolean
        Dim frmDLG As New FrmG0017
        Dim dlgRET As DialogResult

        Try

            If flxDATA.Rows(flxDATA.RowSel) IsNot Nothing Then
                frmDLG.PrSYONIN_HOKOKUSYO_ID = flxDATA.Rows(flxDATA.RowSel).Item(NameOf(MODEL.ST02_FUTEKIGO_ICHIRAN.SYONIN_HOKOKUSYO_ID))
                frmDLG.PrHOKOKU_NO = flxDATA.Rows(flxDATA.RowSel).Item(NameOf(MODEL.ST02_FUTEKIGO_ICHIRAN.HOKOKU_NO))
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

            If pub_intOPEN_MODE = ENM_OPEN_MODE._3_分析集計 Then
                If flxDATA.RowSel > 0 And panelMan.SelectedIndex = 1 Then
                    cmdFunc8.Enabled = True
                Else
                    cmdFunc8.Enabled = False
                End If
            Else
                cmdFunc2.Enabled = True

                If flxDATA.RowSel > 0 And panelMan.SelectedIndex = 1 Then
                    cmdFunc1.Enabled = False
                    cmdFunc3.Enabled = True
                    cmdFunc4.Enabled = True
                    cmdFunc5.Enabled = True
                    cmdFunc7.Enabled = True
                    cmdFunc8.Enabled = True
                    cmdFunc9.Enabled = True
                    cmdFunc10.Enabled = True
                    cmdFunc11.Enabled = True

                    '選択行がClosedの場合
                    If Val(flxDATA.Rows(flxDATA.RowSel).Item(NameOf(_D003_NCR_J.CLOSE_FG))) = 1 Then

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
                    'If FunblnAllowSyonin() Then
                    '    cmdFunc4.Enabled = True
                    'Else
                    '    cmdFunc4.Enabled = False
                    '    MyBase.ToolTip.SetToolTip(Me.cmdFunc4, "変更承認権限がありません")
                    'End If

                    '削除ボタン
                    If HasDeleteAuth(pub_SYAIN_INFO.SYAIN_ID,
                                     flxDATA.Rows(flxDATA.RowSel).Item(NameOf(V007_NCR_CAR.SYONIN_HOKOKUSYO_ID)),
                                     flxDATA.Rows(flxDATA.RowSel).Item(NameOf(V007_NCR_CAR.HOKOKU_NO))) Then

                        If flxDATA.Rows(flxDATA.RowSel).Item(NameOf(_D003_NCR_J.CLOSE_FG)) = 1 Then
                            '削除済み
                            'cmdFunc4.Enabled = False
                            'MyBase.ToolTip.SetToolTip(Me.cmdFunc4, "取消済みデータです")
                            cmdFunc5.Enabled = False
                            MyBase.ToolTip.SetToolTip(Me.cmdFunc5, "取消済みデータです")
                            'flxDATA.Rows(flxDATA.RowSel).Item("SELECTED").ReadOnly = True
                            cmdFunc6.Enabled = True
                        Else cmdFunc5.Enabled = True

                        End If
                    Else

                        If flxDATA.Rows(flxDATA.RowSel).Item(NameOf(_D003_NCR_J.DEL_YMDHNS)).ToString.Trim <> "" Then
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

                    cmdFunc7.Enabled = (panelMan.SelectedIndex = 1) 'False
                    cmdFunc6.Enabled = False
                    cmdFunc8.Enabled = False
                    cmdFunc9.Enabled = False
                    cmdFunc10.Enabled = False
                    cmdFunc11.Enabled = False
                End If

                'cmdFunc1.Enabled = Not (panelMan.SelectedIndex = 1)

                'cmdFunc4.Enabled *= Not (panelMan.SelectedIndex = 1)
                'cmdFunc5.Enabled *= Not (panelMan.SelectedIndex = 1)
                'cmdFunc6.Enabled *= Not (panelMan.SelectedIndex = 1)
                'cmdFunc7.Enabled *= (panelMan.SelectedIndex = 1)
                'cmdFunc8.Enabled *= Not (panelMan.SelectedIndex = 1)
                'cmdFunc9.Enabled *= Not (panelMan.SelectedIndex = 1)
                'cmdFunc10.Enabled *= Not (panelMan.SelectedIndex = 1)
                'cmdFunc11.Enabled *= Not (panelMan.SelectedIndex = 1)
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
    Private Sub chkClosedRowVisibled_Click(sender As Object, e As EventArgs) Handles chkClosedRowVisibled.Click
        If chkClosedRowVisibled.Checked Then
            RemoveHandler cmbGEN_TANTO.SelectedValueChanged, AddressOf SearchFilterValueChanged
            cmbGEN_TANTO.SelectedValue = 0
            AddHandler cmbGEN_TANTO.SelectedValueChanged, AddressOf SearchFilterValueChanged
        End If
    End Sub

    Private Async Sub chkTairyu_CheckedChanged(sender As Object, e As EventArgs) Handles chkTairyu.CheckedChanged

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

    Private Sub btnSummaryPage_Click(sender As Object, e As EventArgs) Handles btnSummaryPage.Click
        _flexGroup.Grid.DataSource = flxDATA.DataSource
        panelMan.SelectedPanel = panelMan.ManagedPanels(NameOf(mpSummaryGrid))
    End Sub

#Region "検索条件クリア"

    Private Sub btnClearSrchFilter_Click(sender As Object, e As EventArgs) Handles btnClearSrchFilter.Click
        ParamModel.Clear()
        RemoveHandler chkDeleteRowVisibled.CheckedChanged, AddressOf SearchFilterValueChanged
        chkDeleteRowVisibled.Checked = False
        AddHandler chkDeleteRowVisibled.CheckedChanged, AddressOf SearchFilterValueChanged

        chkDispBUMON.Checked = False
        chkDispADD_TANTO.Checked = False
        chkDispKISYU.Checked = False
        chkDispBUHIN_BANGO.Checked = False
        chkDispHINMEI.Checked = False
        chkDispGOKI.Checked = False
        chkDispSYANAI_CD.Checked = False
        chkDispHASSEI_YMD.Checked = False
        chkDispFUTEKIGO_JYOTAI_KB.Checked = False
        chkDispFUTEKIGO_KB.Checked = False
        chkDispFUTEKIGO_S_KB.Checked = False

        chkDispFUTEKIGO_JYOTAI_KB.Checked = False
        chkDispFUTEKIGO_KB.Checked = False
        chkDispFUTEKIGO_S_KB.Checked = False

        btnSummaryPage.Visible = False
        Call SetStageList()
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
                            ParamModel.SYOCHI_TANTO = 0
                            ParamModel.BUMON_KB = ""
                        Case Context.ENM_BUMON_KB._2_LP
                            lblSyanaiCD.Visible = True
                            cmbSYANAI_CD.Visible = True
                            chkDispSYANAI_CD.Visible = (pub_intOPEN_MODE = ENM_OPEN_MODE._3_分析集計)
                        Case Else
                            lblSyanaiCD.Visible = False
                            cmbSYANAI_CD.Visible = False
                            chkDispSYANAI_CD.Visible = False
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

                    'UNDONE:

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
                    cmbGEN_TANTO.DataBindings.Add(New Binding(NameOf(cmbGEN_TANTO.SelectedValue), ParamModel, NameOf(ParamModel.SYOCHI_TANTO), False, DataSourceUpdateMode.OnPropertyChanged, 0))

                    Dim blnSelected As Boolean = (cmb.SelectedValue IsNot Nothing AndAlso Not cmb.SelectedValue.ToString.IsNulOrWS)

                    '機種
                    RemoveHandler cmbKISYU.SelectedValueChanged, AddressOf CmbKISYU_SelectedValueChanged
                    If blnSelected Then
                        Dim drs = tblKISYU_J.AsEnumerable.Where(Function(r) r.Field(Of String)(NameOf(ParamModel.BUMON_KB)) = cmb.SelectedValue)
                        If drs.Count > 0 Then
                            Dim dt As DataTable = drs.CopyToDataTable
                            cmbKISYU.SetDataSource(dt, ENM_COMBO_SELECT_VALUE_TYPE._1_Filter)
                            ParamModel.KISYU_ID = 0
                        End If
                    Else
                        cmbKISYU.SetDataSource(tblKISYU_J, ENM_COMBO_SELECT_VALUE_TYPE._1_Filter)
                    End If
                    AddHandler cmbKISYU.SelectedValueChanged, AddressOf CmbKISYU_SelectedValueChanged

                    '部品番号
                    RemoveHandler cmbBUHIN_BANGO.SelectedValueChanged, AddressOf CmbBUHIN_BANGO_SelectedValueChanged
                    If blnSelected Then
                        Dim drs = tblBUHIN_J.AsEnumerable.Where(Function(r) r.Field(Of String)(NameOf(ParamModel.BUMON_KB)) = cmb.SelectedValue)
                        If drs.Count > 0 Then
                            Dim dt As DataTable = drs.CopyToDataTable
                            cmbBUHIN_BANGO.SetDataSource(dt, ENM_COMBO_SELECT_VALUE_TYPE._1_Filter)
                            ParamModel.BUHIN_BANGO = ""
                        End If
                    Else
                        cmbBUHIN_BANGO.SetDataSource(tblBUHIN_J, ENM_COMBO_SELECT_VALUE_TYPE._1_Filter)
                    End If
                    AddHandler cmbBUHIN_BANGO.SelectedValueChanged, AddressOf CmbBUHIN_BANGO_SelectedValueChanged

                    '社内コード
                    RemoveHandler cmbSYANAI_CD.SelectedValueChanged, AddressOf CmbSYANAI_CD_SelectedValueChanged
                    cmbSYANAI_CD.DataBindings.Clear()
                    If blnSelected Then
                        If Val(cmb.SelectedValue) = Context.ENM_BUMON_KB._2_LP Then
                            Dim drs = tblSYANAI_CD_J.AsEnumerable.Where(Function(r) r.Field(Of String)(NameOf(ParamModel.BUMON_KB)) = cmb.SelectedValue)
                            If drs.Count > 0 Then
                                Dim dt As DataTable = drs.CopyToDataTable
                                cmbSYANAI_CD.SetDataSource(dt, ENM_COMBO_SELECT_VALUE_TYPE._1_Filter)
                            Else
                                cmbSYANAI_CD.DataSource = Nothing
                            End If
                        Else
                            'cmbSYANAI_CD.DataSource = Nothing
                        End If
                        ParamModel.SYANAI_CD = ""
                    Else
                        cmbSYANAI_CD.SetDataSource(tblSYANAI_CD_J, ENM_COMBO_SELECT_VALUE_TYPE._1_Filter)
                    End If
                    AddHandler cmbSYANAI_CD.SelectedValueChanged, AddressOf CmbSYANAI_CD_SelectedValueChanged
                    cmbSYANAI_CD.DataBindings.Add(New Binding(NameOf(cmbSYANAI_CD.SelectedValue), ParamModel, NameOf(ParamModel.SYANAI_CD), False, DataSourceUpdateMode.OnPropertyChanged, ""))

                    RemoveHandler cmbFUTEKIGO_KB.SelectedValueChanged, AddressOf CmbFUTEKIGO_KB_SelectedValueChanged
                    Dim dtx As DataTableEx = FunGetFUTEKIGO_KB(cmb.SelectedValue)
                    cmbFUTEKIGO_KB.SetDataSource(dtx.ExcludeDeleted, ENM_COMBO_SELECT_VALUE_TYPE._1_Filter)
                    AddHandler cmbFUTEKIGO_KB.SelectedValueChanged, AddressOf CmbFUTEKIGO_KB_SelectedValueChanged

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
                        Dim drs = tblBUHIN_J.AsEnumerable.Where(Function(r) r.Field(Of Integer)(NameOf(_D003_NCR_J.KISYU_ID)) = cmb.SelectedValue)
                        If drs.Count > 0 Then
                            Dim dt As DataTable = drs.CopyToDataTable
                            Dim _selectedValue As String = cmbBUHIN_BANGO.SelectedValue

                            cmbBUHIN_BANGO.SetDataSource(dt, ENM_COMBO_SELECT_VALUE_TYPE._1_Filter)
                            If Not cmbBUHIN_BANGO.NullValue = cmbBUHIN_BANGO.SelectedValue Then
                                ParamModel.BUHIN_BANGO = _selectedValue
                            End If
                        End If
                    Else
                        cmbBUHIN_BANGO.SetDataSource(tblBUHIN_J, ENM_COMBO_SELECT_VALUE_TYPE._1_Filter)
                    End If
                    AddHandler cmbBUHIN_BANGO.SelectedValueChanged, AddressOf CmbBUHIN_BANGO_SelectedValueChanged
                    cmbBUHIN_BANGO.DataBindings.Add(New Binding(NameOf(cmbBUHIN_BANGO.SelectedValue), ParamModel, NameOf(ParamModel.BUHIN_BANGO), False, DataSourceUpdateMode.OnPropertyChanged, ""))

                    If Val(cmbBUMON.SelectedValue) = ENM_BUMON_KB._2_LP Then
                        '社内コード
                        RemoveHandler cmbSYANAI_CD.SelectedValueChanged, AddressOf CmbSYANAI_CD_SelectedValueChanged
                        cmbSYANAI_CD.DataBindings.Clear()

                        If cmb.IsSelected Then
                            If Val(cmb.SelectedValue) = Context.ENM_BUMON_KB._2_LP Then
                                Dim drs = tblSYANAI_CD_J.AsEnumerable.Where(Function(r) r.Field(Of Integer)(NameOf(_D003_NCR_J.KISYU_ID)) = cmb.SelectedValue)
                                If drs.Count > 0 Then
                                    Dim dt As DataTable = drs.CopyToDataTable
                                    Dim _selectedValue As String = cmbSYANAI_CD.SelectedValue

                                    cmbSYANAI_CD.SetDataSource(dt, ENM_COMBO_SELECT_VALUE_TYPE._1_Filter)
                                    If Not cmbSYANAI_CD.NullValue = _selectedValue Then
                                        ParamModel.SYANAI_CD = _selectedValue
                                    End If
                                End If
                            Else
                                'cmbSYANAI_CD.DataSource = Nothing
                            End If
                            ParamModel.SYANAI_CD = ""
                        Else
                            cmbSYANAI_CD.SetDataSource(tblSYANAI_CD_J, ENM_COMBO_SELECT_VALUE_TYPE._1_Filter)
                        End If
                        AddHandler cmbSYANAI_CD.SelectedValueChanged, AddressOf CmbSYANAI_CD_SelectedValueChanged
                        cmbSYANAI_CD.DataBindings.Add(New Binding(NameOf(cmbSYANAI_CD.SelectedValue), ParamModel, NameOf(ParamModel.SYANAI_CD), False, DataSourceUpdateMode.OnPropertyChanged, ""))
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
                            Dim drs = tblBUHIN_J.AsEnumerable.Where(Function(r) r.Field(Of String)(NameOf(ParamModel.SYANAI_CD)) = cmb.SelectedValue).ToList
                            If drs.Count > 0 Then cmbBUHIN_BANGO.SetDataSource(drs.CopyToDataTable, ENM_COMBO_SELECT_VALUE_TYPE._1_Filter)
                        Else
                            cmbBUHIN_BANGO.SetDataSource(tblBUHIN_J, ENM_COMBO_SELECT_VALUE_TYPE._1_Filter)
                        End If
                        AddHandler cmbBUHIN_BANGO.SelectedValueChanged, AddressOf CmbBUHIN_BANGO_SelectedValueChanged

                        '抽出
                        RemoveHandler cmbBUHIN_BANGO.SelectedValueChanged, AddressOf CmbBUHIN_BANGO_SelectedValueChanged
                        RemoveHandler cmbKISYU.SelectedValueChanged, AddressOf CmbKISYU_SelectedValueChanged
                        cmbSYANAI_CD.DataBindings.Clear()
                        If cmb.IsSelected Then
                            Dim dr = DirectCast(cmbSYANAI_CD.DataSource, DataTable).AsEnumerable.
                                                                Where(Function(r) r.Field(Of String)("VALUE") = cmb.SelectedValue).
                                                                FirstOrDefault
                            If dr IsNot Nothing Then

                                ParamModel.BUHIN_BANGO = dr.Item("BUHIN_BANGO")
                                ParamModel.BUHIN_NAME = dr.Item("BUHIN_NAME")
                                ParamModel.KISYU_ID = dr.Item("KISYU_ID")
                            End If
                        Else
                            ParamModel.BUHIN_BANGO = ""
                            ParamModel.BUHIN_NAME = ""
                            ParamModel.KISYU_ID = 0
                        End If
                        AddHandler cmbBUHIN_BANGO.SelectedValueChanged, AddressOf CmbBUHIN_BANGO_SelectedValueChanged
                        AddHandler cmbKISYU.SelectedValueChanged, AddressOf CmbKISYU_SelectedValueChanged

                        AddHandler cmbSYANAI_CD.SelectedValueChanged, AddressOf CmbSYANAI_CD_SelectedValueChanged
                        cmbSYANAI_CD.DataBindings.Add(New Binding(NameOf(cmbSYANAI_CD.SelectedValue), ParamModel, NameOf(ParamModel.SYANAI_CD), False, DataSourceUpdateMode.OnPropertyChanged, ""))
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
                                                 Dim drs = tblSYANAI_CD.AsEnumerable.Where(Function(r) r.Field(Of String)(NameOf(ParamModel.BUHIN_BANGO)) = cmb.SelectedValue).ToList
                                                 If drs.Count > 0 Then
                                                     Dim dt As DataTable = drs.CopyToDataTable
                                                     Dim _selectedValue As String = cmbSYANAI_CD.SelectedValue
                                                     cmbSYANAI_CD.DisplayMember = "DISP"
                                                     cmbSYANAI_CD.ValueMember = "VALUE"
                                                     cmbSYANAI_CD.SetDataSource(dt, ENM_COMBO_SELECT_VALUE_TYPE._1_Filter)
                                                     ParamModel.SYANAI_CD = _selectedValue
                                                 End If
                                             Else
                                                 ParamModel.SYANAI_CD = ""
                                                 'cmbSYANAI_CD.DataSource = Nothing
                                             End If
                                             'cmbSYANAI_CD.DataBindings.Add(New Binding(NameOf(cmbSYANAI_CD.SelectedValue), ParamModel, NameOf(ParamModel.SYANAI_CD), False, DataSourceUpdateMode.OnPropertyChanged, ""))
                                         Else
                                             cmbSYANAI_CD.SetDataSource(tblSYANAI_CD.ExcludeDeleted, ENM_COMBO_SELECT_VALUE_TYPE._1_Filter)
                                         End If
                                         'AddHandler cmbSYANAI_CD.SelectedValueChanged, AddressOf CmbSYANAI_CD_SelectedValueChanged

                                         '抽出
                                         If cmb.IsSelected Then
                                             Dim dr As DataRow = DirectCast(cmbBUHIN_BANGO.DataSource, DataTable).
                                                                    AsEnumerable.Where(Function(r) r.Field(Of String)("VALUE") = cmbBUHIN_BANGO.SelectedValue).
                                                                    FirstOrDefault

                                             If Val(cmb.SelectedValue) = Context.ENM_BUMON_KB._2_LP Then
                                                 'RemoveHandler cmbSYANAI_CD.SelectedValueChanged, AddressOf CmbSYANAI_CD_SelectedValueChanged
                                                 ParamModel.SYANAI_CD = dr.Item("SYANAI_CD")
                                                 'AddHandler cmbSYANAI_CD.SelectedValueChanged, AddressOf CmbSYANAI_CD_SelectedValueChanged
                                             End If
                                             ParamModel.BUHIN_NAME = dr.Item("BUHIN_NAME")

                                             'RemoveHandler cmbKISYU.SelectedValueChanged, AddressOf CmbKISYU_SelectedValueChanged
                                             If dr.Item("KISYU_ID") <> 0 Then
                                                 ParamModel.KISYU_ID = dr.Item("KISYU_ID")
                                             End If
                                             'AddHandler cmbKISYU.SelectedValueChanged, AddressOf CmbKISYU_SelectedValueChanged
                                         Else
                                             ParamModel.SYANAI_CD = ""
                                             ParamModel.BUHIN_NAME = ""
                                             ParamModel.KISYU_ID = 0
                                         End If
                                         'AddHandler cmbBUHIN_BANGO.SelectedValueChanged, AddressOf CmbBUHIN_BANGO_SelectedValueChanged
                                     End Sub)
                       End Sub)
    End Sub

#End Region

#Region "不適合区分"

    Private Sub CmbFUTEKIGO_KB_SelectedValueChanged(sender As Object, e As EventArgs) Handles cmbFUTEKIGO_KB.SelectedValueChanged

        If cmbFUTEKIGO_KB.IsSelected Then
            Dim dt As DataTableEx = FunGetFUTEKIGO_S_KB(cmbBUMON.SelectedValue, cmbFUTEKIGO_KB.SelectedValue)
            'Using DB As ClsDbUtility = DBOpen()
            '    FunGetCodeDataTable(DB, $"不適合{cmbFUTEKIGO_KB.Text.Replace("・", "")}区分", dt)
            'End Using
            cmbFUTEKIGO_S_KB.SetDataSource(dt.ExcludeDeleted, ENM_COMBO_SELECT_VALUE_TYPE._1_Filter)
        Else
            cmbFUTEKIGO_S_KB.DataSource = Nothing
        End If
    End Sub

#End Region

#End Region

#Region "CAR検索条件"

    Private Sub CmbYOIN1_SelectedValueChanged(sender As Object, e As EventArgs) Handles cmbYOIN1.SelectedValueChanged
        If cmbYOIN1.SelectedIndex > 0 Then
            'btnSearchGENIN1.Enabled = True
            mtxGENIN1_DISP.Enabled = True
            btnClearGenin1.Enabled = True
            btnSelectGenin1.Enabled = True
        Else
            'btnSearchGENIN1.Enabled = False
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
            'btnSearchGENIN2.Enabled = True
            mtxGENIN2_DISP.Enabled = True
            btnClearGenin2.Enabled = True
            btnSelectGenin2.Enabled = True
        Else
            'btnSearchGENIN2.Enabled = False
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
                DirectCast(frmDLG, FrmG0013).PrMODE = 0
                DirectCast(frmDLG, FrmG0013).PrYOIN = (cmbYOIN1.SelectedValue, cmbYOIN1.Text)
                DirectCast(frmDLG, FrmG0013).PrSelectedList = PrGenin1
            Else
                frmDLG = New FrmG0014
                DirectCast(frmDLG, FrmG0014).PrMODE = 0
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
                        If mtxGENIN1_DISP.Text.IsNulOrWS Then
                            mtxGENIN1_DISP.Text = item.ITEM_DISP
                        Else
                            mtxGENIN1_DISP.Text &= ", " & item.ITEM_DISP
                        End If

                        sbWhere.Append($" AND (GENIN_BUNSEKI_KB='{item.ITEM_NAME}' AND GENIN_BUNSEKI_S_KB='{item.ITEM_VALUE}')")

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
                        If mtxGENIN2_DISP.Text.IsNulOrWS Then
                            mtxGENIN2_DISP.Text = item.ITEM_DISP
                        Else
                            mtxGENIN2_DISP.Text &= ", " & item.ITEM_DISP
                        End If

                        sbWhere.Append($" AND (GENIN_BUNSEKI_KB='{item.ITEM_NAME}' AND GENIN_BUNSEKI_S_KB='{item.ITEM_VALUE}')")
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

#End Region

#Region "入力チェック"

    Private Sub CmbHOKOKUSYO_ID_Validating(sender As Object, e As System.ComponentModel.CancelEventArgs) Handles cmbHOKOKUSYO_ID.Validating
        If pub_intOPEN_MODE <> ENM_OPEN_MODE._3_分析集計 Then Return

        Dim cmb As ComboboxEx = DirectCast(sender, ComboboxEx)
        IsValidated *= ErrorProvider.UpdateErrorInfo(cmb, cmb.IsSelected, String.Format(My.Resources.infoMsgRequireSelectOrInput, "報告書名"))

    End Sub

    Private Sub CmbBUMON_Validating(sender As Object, e As CancelEventArgs) 'Handles cmbBUMON.Validating
        If pub_intOPEN_MODE <> ENM_OPEN_MODE._3_分析集計 Then Return

        'Dim cmb As ComboboxEx = DirectCast(sender, ComboboxEx)
        'IsValidated *= ErrorProvider.UpdateErrorInfo(cmb, cmb.IsSelected, String.Format(My.Resources.infoMsgRequireSelectOrInput, "製品区分"))
    End Sub

    Private Sub CmbADD_TANTO_Validating(sender As Object, e As CancelEventArgs) 'Handles cmbADD_TANTO.Validating
        If pub_intOPEN_MODE <> ENM_OPEN_MODE._3_分析集計 Then Return

        'Dim cmb As ComboboxEx = DirectCast(sender, ComboboxEx)
        'IsValidated *= ErrorProvider.UpdateErrorInfo(cmb, cmb.IsSelected, String.Format(My.Resources.infoMsgRequireSelectOrInput, "起草者"))
    End Sub

    Private Sub CmbKISYU_Validating(sender As Object, e As CancelEventArgs) 'Handles cmbKISYU.Validating
        If pub_intOPEN_MODE <> ENM_OPEN_MODE._3_分析集計 Then Return

        'Dim cmb As ComboboxEx = DirectCast(sender, ComboboxEx)
        'IsValidated *= ErrorProvider.UpdateErrorInfo(cmb, cmb.IsSelected, String.Format(My.Resources.infoMsgRequireSelectOrInput, "機種"))
    End Sub

    Private Sub CmbBUHIN_BANGO_Validating(sender As Object, e As CancelEventArgs) 'Handles cmbBUHIN_BANGO.Validating
        If pub_intOPEN_MODE <> ENM_OPEN_MODE._3_分析集計 Then Return

        'Dim cmb As ComboboxEx = DirectCast(sender, ComboboxEx)
        'IsValidated *= ErrorProvider.UpdateErrorInfo(cmb, cmb.IsSelected, String.Format(My.Resources.infoMsgRequireSelectOrInput, "部品番号"))
    End Sub

    Private Sub MtxHINMEI_Validating(sender As Object, e As CancelEventArgs) 'Handles mtxHINMEI.Validating
        If pub_intOPEN_MODE <> ENM_OPEN_MODE._3_分析集計 Then Return

        'Dim mtx As MaskedTextBoxEx = DirectCast(sender, MaskedTextBoxEx)
        'IsValidated *= ErrorProvider.UpdateErrorInfo(mtx, Not mtx.Text.IsNulOrWS, String.Format(My.Resources.infoMsgRequireSelectOrInput, "部品名称"))
    End Sub

    Private Sub MtxGOKI_Validating(sender As Object, e As CancelEventArgs) 'Handles mtxGOKI.Validating
        If pub_intOPEN_MODE <> ENM_OPEN_MODE._3_分析集計 Then Return

        'Dim mtx As MaskedTextBoxEx = DirectCast(sender, MaskedTextBoxEx)
        'IsValidated *= ErrorProvider.UpdateErrorInfo(mtx, mtx.Text.IsNulOrWS, String.Format(My.Resources.infoMsgRequireSelectOrInput, "製造番号(号機)"))
    End Sub

    Private Sub CmbSYANAI_CD_Validating(sender As Object, e As CancelEventArgs) 'Handles cmbSYANAI_CD.Validating
        If pub_intOPEN_MODE <> ENM_OPEN_MODE._3_分析集計 Then Return

        'Dim cmb As ComboboxEx = DirectCast(sender, ComboboxEx)
        'IsValidated *= ErrorProvider.UpdateErrorInfo(cmb, cmb.IsSelected, String.Format(My.Resources.infoMsgRequireSelectOrInput, "社内コード"))
    End Sub

    Private Sub CmbFUTEKIGO_JYOTAI_KB_Validating(sender As Object, e As CancelEventArgs) 'Handles cmbFUTEKIGO_JYOTAI_KB.Validating
        If pub_intOPEN_MODE <> ENM_OPEN_MODE._3_分析集計 Then Return

        'Dim cmb As ComboboxEx = DirectCast(sender, ComboboxEx)
        'IsValidated *= ErrorProvider.UpdateErrorInfo(cmb, cmb.IsSelected, String.Format(My.Resources.infoMsgRequireSelectOrInput, "状態区分"))
    End Sub

    Private Sub CmbFUTEKIGO_KB_Validating(sender As Object, e As CancelEventArgs) 'Handles cmbFUTEKIGO_KB.Validating
        If pub_intOPEN_MODE <> ENM_OPEN_MODE._3_分析集計 Then Return

        'Dim cmb As ComboboxEx = DirectCast(sender, ComboboxEx)
        'IsValidated *= ErrorProvider.UpdateErrorInfo(cmb, cmb.IsSelected, String.Format(My.Resources.infoMsgRequireSelectOrInput, "不適合区分"))
    End Sub

    Private Sub CmbFUTEKIGO_S_KB_Validating(sender As Object, e As CancelEventArgs) 'Handles cmbFUTEKIGO_S_KB.Validating
        If pub_intOPEN_MODE <> ENM_OPEN_MODE._3_分析集計 Then Return

        'Dim cmb As ComboboxEx = DirectCast(sender, ComboboxEx)
        'IsValidated *= ErrorProvider.UpdateErrorInfo(cmb, cmb.IsSelected, String.Format(My.Resources.infoMsgRequireSelectOrInput, "不適合詳細区分"))
    End Sub

    Private Sub CmbJIZEN_SINSA_HANTEI_KB_Validating(sender As Object, e As CancelEventArgs) 'Handles cmbJIZEN_SINSA_HANTEI_KB.Validating
        If pub_intOPEN_MODE <> ENM_OPEN_MODE._3_分析集計 Then Return

        'Dim cmb As ComboboxEx = DirectCast(sender, ComboboxEx)
        'IsValidated *= ErrorProvider.UpdateErrorInfo(cmb, cmb.IsSelected, String.Format(My.Resources.infoMsgRequireSelectOrInput, "事前審査判定区分"))
    End Sub

    Private Sub CmbZESEI_SYOCHI_YOHI_KB_Validating(sender As Object, e As CancelEventArgs) 'Handles cmbZESEI_SYOCHI_YOHI_KB.Validating
        If pub_intOPEN_MODE <> ENM_OPEN_MODE._3_分析集計 Then Return

        'Dim cmb As ComboboxEx = DirectCast(sender, ComboboxEx)
        'IsValidated *= ErrorProvider.UpdateErrorInfo(cmb, cmb.IsSelected, String.Format(My.Resources.infoMsgRequireSelectOrInput, "是正処置要否判定区分"))
    End Sub

    Private Sub CmbSAISIN_IINKAI_HANTEI_KB_Validating(sender As Object, e As CancelEventArgs) 'Handles cmbSAISIN_IINKAI_HANTEI_KB.Validating
        If pub_intOPEN_MODE <> ENM_OPEN_MODE._3_分析集計 Then Return

        'Dim cmb As ComboboxEx = DirectCast(sender, ComboboxEx)
        'IsValidated *= ErrorProvider.UpdateErrorInfo(cmb, cmb.IsSelected, String.Format(My.Resources.infoMsgRequireSelectOrInput, "再審委員会判定区分"))
    End Sub

    Private Sub CmbKOKYAKU_HANTEI_SIJI_KB_Validating(sender As Object, e As CancelEventArgs) 'Handles cmbKOKYAKU_HANTEI_SIJI_KB.Validating
        If pub_intOPEN_MODE <> ENM_OPEN_MODE._3_分析集計 Then Return

        'Dim cmb As ComboboxEx = DirectCast(sender, ComboboxEx)
        'IsValidated *= ErrorProvider.UpdateErrorInfo(cmb, cmb.IsSelected, String.Format(My.Resources.infoMsgRequireSelectOrInput, "顧客判定指示区分"))
    End Sub

    Private Sub CmbKOKYAKU_SAISYU_HANTEI_KB_Validating(sender As Object, e As CancelEventArgs) Handles cmbKOKYAKU_SAISYU_HANTEI_KB.Validating
        If pub_intOPEN_MODE <> ENM_OPEN_MODE._3_分析集計 Then Return

        'Dim cmb As ComboboxEx = DirectCast(sender, ComboboxEx)
        'IsValidated *= ErrorProvider.UpdateErrorInfo(cmb, cmb.IsSelected, String.Format(My.Resources.infoMsgRequireSelectOrInput, "顧客最終判定区分"))
    End Sub

    Private Sub CmbKENSA_KEKKA_KB_Validating(sender As Object, e As CancelEventArgs) 'Handles cmbKENSA_KEKKA_KB.Validating
        If pub_intOPEN_MODE <> ENM_OPEN_MODE._3_分析集計 Then Return

        'Dim cmb As ComboboxEx = DirectCast(sender, ComboboxEx)
        'IsValidated *= ErrorProvider.UpdateErrorInfo(cmb, cmb.IsSelected, String.Format(My.Resources.infoMsgRequireSelectOrInput, "検査結果"))
    End Sub

    Private Sub CmbYOIN1_Validating(sender As Object, e As CancelEventArgs) 'Handles cmbYOIN1.Validating
        If pub_intOPEN_MODE <> ENM_OPEN_MODE._3_分析集計 Then Return

        'Dim cmb As ComboboxEx = DirectCast(sender, ComboboxEx)
        'IsValidated *= ErrorProvider.UpdateErrorInfo(cmb, cmb.IsSelected, String.Format(My.Resources.infoMsgRequireSelectOrInput, "要因1"))
    End Sub

    Private Sub CmbYOIN2_Validating(sender As Object, e As CancelEventArgs) 'Handles cmbYOIN2.Validating
        If pub_intOPEN_MODE <> ENM_OPEN_MODE._3_分析集計 Then Return

        'Dim cmb As ComboboxEx = DirectCast(sender, ComboboxEx)
        'IsValidated *= ErrorProvider.UpdateErrorInfo(cmb, cmb.IsSelected, String.Format(My.Resources.infoMsgRequireSelectOrInput, "要因2"))
    End Sub

    Private Sub CmbKISEKI_KOTEI_KB_Validating(sender As Object, e As CancelEventArgs) 'Handles cmbKISEKI_KOTEI_KB.Validating
        If pub_intOPEN_MODE <> ENM_OPEN_MODE._3_分析集計 Then Return

        'Dim cmb As ComboboxEx = DirectCast(sender, ComboboxEx)
        'IsValidated *= ErrorProvider.UpdateErrorInfo(cmb, cmb.IsSelected, String.Format(My.Resources.infoMsgRequireSelectOrInput, "帰責工程"))
    End Sub

    Private Sub MtxGENIN1_Validating(sender As Object, e As CancelEventArgs) 'Handles mtxGENIN1.Validating
        If pub_intOPEN_MODE <> ENM_OPEN_MODE._3_分析集計 Then Return

        'Dim mtx As MaskedTextBoxEx = DirectCast(sender, MaskedTextBoxEx)
        'IsValidated *= ErrorProvider.UpdateErrorInfo(mtx, Not mtx.Text.IsNulOrWS, String.Format(My.Resources.infoMsgRequireSelectOrInput, "原因1"))
    End Sub

    Private Sub MtxGENIN2_Validating(sender As Object, e As CancelEventArgs) 'Handles mtxGENIN2.Validating
        If pub_intOPEN_MODE <> ENM_OPEN_MODE._3_分析集計 Then Return

        'Dim mtx As MaskedTextBoxEx = DirectCast(sender, MaskedTextBoxEx)
        'IsValidated *= ErrorProvider.UpdateErrorInfo(mtx, Not mtx.Text.IsNulOrWS, String.Format(My.Resources.infoMsgRequireSelectOrInput, "原因2"))
    End Sub

    Private Function IsValidatedSearchFilter() As Boolean
        IsValidated = True
        Call CmbHOKOKUSYO_ID_Validating(cmbHOKOKUSYO_ID, Nothing)

        'If chkDispBUMON.Checked Then Call CmbBUMON_Validating(cmbBUMON, Nothing)
        'If chkDispADD_TANTO.Checked Then Call CmbADD_TANTO_Validating(cmbADD_TANTO, Nothing)
        'If chkDispKISYU.Checked Then Call CmbKISYU_Validating(cmbKISYU, Nothing)
        'If chkDispBUHIN_BANGO.Checked Then Call CmbBUHIN_BANGO_Validating(cmbBUHIN_BANGO, Nothing)

        'If chkDispHINMEI.Checked Then Call MtxHINMEI_Validating(mtxHINMEI, Nothing)
        'If chkDispGOKI.Checked Then Call MtxGOKI_Validating(mtxGOKI, Nothing)
        'If chkDispSYANAI_CD.Checked Then Call CmbSYANAI_CD_Validating(cmbSYANAI_CD, Nothing)
        'If chkDispHASSEI_YMD.Checked Then

        'End If
        'If chkDispFUTEKIGO_JYOTAI_KB.Checked Then Call CmbFUTEKIGO_JYOTAI_KB_Validating(cmbFUTEKIGO_JYOTAI_KB, Nothing)
        'If chkDispFUTEKIGO_KB.Checked Then Call CmbFUTEKIGO_KB_Validating(cmbFUTEKIGO_KB, Nothing)
        'If chkDispFUTEKIGO_S_KB.Checked Then Call CmbFUTEKIGO_S_KB_Validating(cmbFUTEKIGO_S_KB, Nothing)

        'If chkDispJIZEN_SINSA_HANTEI_KB.Checked Then Call CmbJIZEN_SINSA_HANTEI_KB_Validating(cmbJIZEN_SINSA_HANTEI_KB, Nothing)
        'If chkDispZESEI_SYOCHI_YOHI_KB.Checked Then Call CmbZESEI_SYOCHI_YOHI_KB_Validating(cmbZESEI_SYOCHI_YOHI_KB, Nothing)
        'If chkDispSAISIN_IINKAI_HANTEI_KB.Checked Then Call CmbSAISIN_IINKAI_HANTEI_KB_Validating(cmbSAISIN_IINKAI_HANTEI_KB, Nothing)
        'If chkDispKOKYAKU_HANTEI_SIJI_KB.Checked Then Call CmbKOKYAKU_HANTEI_SIJI_KB_Validating(cmbKOKYAKU_HANTEI_SIJI_KB, Nothing)
        'If chkDispKOKYAKU_SAISYU_HANTEI_KB.Checked Then Call CmbKOKYAKU_SAISYU_HANTEI_KB_Validating(cmbKOKYAKU_SAISYU_HANTEI_KB, Nothing)
        'If chkDispKENSA_KEKKA_KB.Checked Then Call CmbKENSA_KEKKA_KB_Validating(cmbKENSA_KEKKA_KB, Nothing)
        'If chkDispYOIN1.Checked Then Call CmbYOIN1_Validating(cmbYOIN1, Nothing)
        'If chkDispYOIN2.Checked Then Call CmbYOIN2_Validating(cmbYOIN2, Nothing)
        'If chkDispKISEKI_KOTEI_KB.Checked Then Call CmbKISEKI_KOTEI_KB_Validating(cmbKISEKI_KOTEI_KB, Nothing)
        'If chkDispGENIN1.Checked Then Call MtxGENIN1_Validating(mtxGENIN1, Nothing)
        'If chkDispGENIN2.Checked Then Call MtxGENIN2_Validating(mtxGENIN2, Nothing)

        If pub_intOPEN_MODE = ENM_OPEN_MODE._3_分析集計 AndAlso IsValidated = False Then
            Return False
        End If

        Return True

    End Function

#End Region

#Region "集計条件フィルタ チェックボックス"

    Private Sub ChkDispKISYU_CheckedChanged(sender As Object, e As EventArgs) Handles chkDispKISYU.CheckedChanged
        Dim chk = DirectCast(sender, CheckBox)
        Dim cmb = cmbKISYU

        Call CmbKISYU_Validating(cmb, Nothing)
        cmb.Enabled = chk.Checked
        If Not chk.Checked Then cmb.SelectedValue = 0
    End Sub

    Private Sub ChkDispBUMON_CheckedChanged(sender As Object, e As EventArgs) Handles chkDispBUMON.CheckedChanged
        Dim chk = DirectCast(sender, CheckBox)
        Dim cmb = cmbBUMON

        Call CmbBUMON_Validating(cmb, Nothing)
        cmb.Enabled = chk.Checked
        If Not chk.Checked Then cmb.SelectedValue = ""
    End Sub

    Private Sub ChkDispADD_TANTO_CheckedChanged(sender As Object, e As EventArgs) Handles chkDispADD_TANTO.CheckedChanged

        Try
            Dim chk = DirectCast(sender, CheckBox)
            Dim cmb = cmbADD_TANTO

            Call CmbADD_TANTO_Validating(cmb, Nothing)
            cmb.Enabled = chk.Checked
            If Not chk.Checked Then cmb.SelectedValue = 0
        Catch ex As Exception
            Throw
        End Try
    End Sub

    Private Sub ChkDispBUHIN_BANGO_CheckedChanged(sender As Object, e As EventArgs) Handles chkDispBUHIN_BANGO.CheckedChanged
        Dim chk = DirectCast(sender, CheckBox)
        Dim cmb = cmbBUHIN_BANGO

        Call CmbBUHIN_BANGO_Validating(cmb, Nothing)
        cmb.Enabled = chk.Checked
        If Not chk.Checked Then cmb.SelectedValue = ""
    End Sub

    Private Sub ChkDispHINMEI_CheckedChanged(sender As Object, e As EventArgs) Handles chkDispHINMEI.CheckedChanged
        Dim chk = DirectCast(sender, CheckBox)
        Dim mtx = mtxHINMEI

        Call MtxHINMEI_Validating(mtx, Nothing)
        mtx.Enabled = chk.Checked
        If Not chk.Checked Then mtx.Text = ""
    End Sub

    Private Sub ChkDispGOKI_CheckedChanged(sender As Object, e As EventArgs) Handles chkDispGOKI.CheckedChanged
        Dim chk = DirectCast(sender, CheckBox)
        Dim mtx = mtxGOKI

        Call MtxGOKI_Validating(mtx, Nothing)
        mtx.Enabled = chk.Checked
        If Not chk.Checked Then mtx.Text = ""
    End Sub

    Private Sub ChkDispSYANAI_CD_CheckedChanged(sender As Object, e As EventArgs) Handles chkDispSYANAI_CD.CheckedChanged
        Dim chk = DirectCast(sender, CheckBox)
        Dim cmb = cmbSYANAI_CD

        Call CmbSYANAI_CD_Validating(cmb, Nothing)
        cmb.Enabled = chk.Checked
        If Not chk.Checked Then cmb.SelectedValue = ""
    End Sub

    Private Sub ChkDispFUTEKIGO_JYOTAI_KB_CheckedChanged(sender As Object, e As EventArgs) Handles chkDispFUTEKIGO_JYOTAI_KB.CheckedChanged
        Dim chk = DirectCast(sender, CheckBox)
        Dim cmb = cmbFUTEKIGO_JYOTAI_KB

        Call CmbFUTEKIGO_JYOTAI_KB_Validating(cmb, Nothing)
        cmb.Enabled = chk.Checked
        If Not chk.Checked Then cmb.SelectedValue = ""
    End Sub

    Private Sub ChkDispFUTEKIGO_KB_CheckedChanged(sender As Object, e As EventArgs) Handles chkDispFUTEKIGO_KB.CheckedChanged
        Dim chk = DirectCast(sender, CheckBox)
        Dim cmb = cmbFUTEKIGO_KB

        Call CmbFUTEKIGO_KB_Validating(cmb, Nothing)
        cmb.Enabled = chk.Checked
        If Not chk.Checked Then cmb.SelectedValue = ""
    End Sub

    Private Sub ChkDispFUTEKIGO_S_KB_CheckedChanged(sender As Object, e As EventArgs) Handles chkDispFUTEKIGO_S_KB.CheckedChanged
        Dim chk = DirectCast(sender, CheckBox)
        Dim cmb = cmbFUTEKIGO_S_KB

        Call CmbFUTEKIGO_S_KB_Validating(cmb, Nothing)
        cmb.Enabled = chk.Checked
        If Not chk.Checked Then cmb.SelectedValue = ""
    End Sub

    Private Sub ChkDispJIZEN_SINSA_HANTEI_KB_CheckedChanged(sender As Object, e As EventArgs) Handles chkDispJIZEN_SINSA_HANTEI_KB.CheckedChanged
        Dim chk = DirectCast(sender, CheckBox)
        Dim cmb = cmbJIZEN_SINSA_HANTEI_KB

        Call CmbJIZEN_SINSA_HANTEI_KB_Validating(cmb, Nothing)
        cmb.Enabled = chk.Checked
        If Not chk.Checked Then cmb.SelectedValue = ""
    End Sub

    Private Sub ChkDispZESEI_SYOCHI_YOHI_KB_CheckedChanged(sender As Object, e As EventArgs) Handles chkDispZESEI_SYOCHI_YOHI_KB.CheckedChanged
        Dim chk = DirectCast(sender, CheckBox)
        Dim cmb = cmbZESEI_SYOCHI_YOHI_KB

        Call CmbZESEI_SYOCHI_YOHI_KB_Validating(cmb, Nothing)
        cmb.Enabled = chk.Checked
        If Not chk.Checked Then cmb.SelectedValue = ""
    End Sub

    Private Sub ChkDispSAISIN_IINKAI_HANTEI_KB_CheckedChanged(sender As Object, e As EventArgs) Handles chkDispSAISIN_IINKAI_HANTEI_KB.CheckedChanged
        Dim chk = DirectCast(sender, CheckBox)
        Dim cmb = cmbSAISIN_IINKAI_HANTEI_KB

        Call CmbSAISIN_IINKAI_HANTEI_KB_Validating(cmb, Nothing)
        cmb.Enabled = chk.Checked
        If Not chk.Checked Then cmb.SelectedValue = ""
    End Sub

    Private Sub ChkDispKOKYAKU_HANTEI_SIJI_KB_CheckedChanged(sender As Object, e As EventArgs) Handles chkDispKOKYAKU_HANTEI_SIJI_KB.CheckedChanged
        Dim chk = DirectCast(sender, CheckBox)
        Dim cmb = cmbKOKYAKU_HANTEI_SIJI_KB

        Call CmbKOKYAKU_HANTEI_SIJI_KB_Validating(cmb, Nothing)
        cmb.Enabled = chk.Checked
        If Not chk.Checked Then cmb.SelectedValue = ""
    End Sub

    Private Sub ChkDispKOKYAKU_SAISYU_HANTEI_KB_CheckedChanged(sender As Object, e As EventArgs) Handles chkDispKOKYAKU_SAISYU_HANTEI_KB.CheckedChanged
        Dim chk = DirectCast(sender, CheckBox)
        Dim cmb = cmbKOKYAKU_SAISYU_HANTEI_KB

        Call CmbKOKYAKU_SAISYU_HANTEI_KB_Validating(cmb, Nothing)
        cmb.Enabled = chk.Checked
        If Not chk.Checked Then cmb.SelectedValue = ""
    End Sub

    Private Sub ChkDispKENSA_KEKKA_KB_CheckedChanged(sender As Object, e As EventArgs) Handles chkDispKENSA_KEKKA_KB.CheckedChanged
        Dim chk = DirectCast(sender, CheckBox)
        Dim cmb = cmbKENSA_KEKKA_KB

        Call CmbKENSA_KEKKA_KB_Validating(cmb, Nothing)
        cmb.Enabled = chk.Checked
        If Not chk.Checked Then cmb.SelectedValue = ""
    End Sub

    Private Sub ChkDispYOIN1_CheckedChanged(sender As Object, e As EventArgs) Handles chkDispYOIN1.CheckedChanged
        Dim chk = DirectCast(sender, CheckBox)
        Dim cmb = cmbYOIN1

        Call CmbYOIN1_Validating(cmb, Nothing)
        cmb.Enabled = chk.Checked
        If Not chk.Checked Then cmb.SelectedValue = ""
    End Sub

    Private Sub ChkDispYOIN2_CheckStateChanged(sender As Object, e As EventArgs) Handles chkDispYOIN2.CheckStateChanged
        Dim chk = DirectCast(sender, CheckBox)
        Dim cmb = cmbYOIN2

        Call CmbYOIN2_Validating(cmb, Nothing)
        cmb.Enabled = chk.Checked
        If Not chk.Checked Then cmb.SelectedValue = ""
    End Sub

    Private Sub ChkDispKISEKI_KOTEI_KB_CheckedChanged(sender As Object, e As EventArgs) Handles chkDispKISEKI_KOTEI_KB.CheckedChanged
        Dim chk = DirectCast(sender, CheckBox)
        Dim cmb = cmbKISEKI_KOTEI_KB

        Call CmbKISEKI_KOTEI_KB_Validating(cmb, Nothing)
        cmb.Enabled = chk.Checked
        If Not chk.Checked Then cmb.SelectedValue = ""
    End Sub

    Private Sub ChkDispGENIN1_CheckedChanged(sender As Object, e As EventArgs) Handles chkDispGENIN1.CheckedChanged

    End Sub

    Private Sub ChkDispGENIN2_CheckedChanged(sender As Object, e As EventArgs) Handles chkDispGENIN2.CheckedChanged

    End Sub

    Private Sub ChkDispHASSEI_YMD_CheckedChanged(sender As Object, e As EventArgs) Handles chkDispHASSEI_YMD.CheckedChanged

        dtHASSEI_YMD_FROM.Enabled = chkDispHASSEI_YMD.Checked
        dtHASSEI_YMD_TO.Enabled = chkDispHASSEI_YMD.Checked
    End Sub

#End Region

#End Region

#Region "ローカル関数"

#Region "バインディング"

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

        dtHASSEI_YMD_FROM.DataBindings.Add(New Binding(NameOf(dtHASSEI_YMD_FROM.ValueNonFormat), ParamModel, NameOf(ParamModel.HASSEI_FROM), False, DataSourceUpdateMode.OnPropertyChanged, ""))
        dtHASSEI_YMD_TO.DataBindings.Add(New Binding(NameOf(dtHASSEI_YMD_TO.ValueNonFormat), ParamModel, NameOf(ParamModel.HASSEI_TO), False, DataSourceUpdateMode.OnPropertyChanged, ""))

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

#End Region

    Public Function FunGetDtST02_FUTEKIGO_ICHIRAN(ParamModel As ST02_ParamModel, Optional mode As Integer = ENM_OPEN_MODE._0_通常) As DataTable

        Dim sbSQL As New System.Text.StringBuilder
        Dim sbParam As New System.Text.StringBuilder
        Dim dsList As New DataSet

        Select Case mode
            Case ENM_OPEN_MODE._3_分析集計

                If chkDispBUMON.Checked Then
                    sbParam.Append($" '{ParamModel.BUMON_KB}'")
                Else
                    sbParam.Append($" DEFAULT")
                End If
                If cmbHOKOKUSYO_ID.IsSelected Then
                    sbParam.Append($",{Nz(cmbHOKOKUSYO_ID.SelectedValue, 0)}")
                Else
                    sbParam.Append($",DEFAULT")
                End If

                If chkDispKISYU.Checked Then
                    sbParam.Append($",{Nz(cmbKISYU.SelectedValue, 0)}")
                Else
                    sbParam.Append($",DEFAULT")
                End If

                If chkDispBUHIN_BANGO.Checked Then
                    If Not cmbBUHIN_BANGO.Text.IsNulOrWS And cmbBUHIN_BANGO.SelectedValue <> cmbBUHIN_BANGO.NullValue Then
                        sbParam.Append($",'{cmbBUHIN_BANGO.Text.Trim}'")
                    Else
                        sbParam.Append($",'{ParamModel.BUHIN_BANGO}'")
                    End If
                Else
                    sbParam.Append($",DEFAULT")
                End If
                If chkDispSYANAI_CD.Checked Then
                    sbParam.Append($",'{ParamModel.SYANAI_CD}'")
                Else
                    sbParam.Append($",DEFAULT")
                End If
                If chkDispHINMEI.Checked Then
                    sbParam.Append($",'{ParamModel.BUHIN_NAME}'")
                Else
                    sbParam.Append($",DEFAULT")
                End If
                If chkDispGOKI.Checked Then
                    sbParam.Append($",'{ParamModel.GOUKI}'")
                Else
                    sbParam.Append($",DEFAULT")
                End If

                sbParam.Append($",{Nz(cmbGEN_TANTO.SelectedValue, 0)}")
                sbParam.Append($",'{ParamModel.JISI_YMD_FROM}'")
                sbParam.Append($",'{ParamModel.JISI_YMD_TO}'")
                sbParam.Append($",'{ParamModel.HOKOKU_NO}'")

                If chkDispADD_TANTO.Checked Then
                    sbParam.Append($",{ParamModel.ADD_TANTO}")
                Else
                    sbParam.Append($",DEFAULT")
                End If

                sbParam.Append($",'{IIf(chkClosedRowVisibled.Checked, "", 0)}'")
                sbParam.Append($",'{IIf(ParamModel._VISIBLE_TAIRYU = 1, ParamModel._VISIBLE_TAIRYU, "")}'")

                If chkDispFUTEKIGO_KB.Checked Then
                    sbParam.Append($",'{ParamModel.FUTEKIGO_KB}'")
                Else
                    sbParam.Append($",DEFAULT")
                End If
                If chkDispFUTEKIGO_S_KB.Checked Then

                    sbParam.Append($",'{ParamModel.FUTEKIGO_S_KB}'")
                Else
                    sbParam.Append($",DEFAULT")
                End If
                If chkDispFUTEKIGO_JYOTAI_KB.Checked Then
                    sbParam.Append($",'{ParamModel.FUTEKIGO_JYOTAI_KB}'")
                Else
                    sbParam.Append($",DEFAULT")
                End If

                'NCR
                If chkDispJIZEN_SINSA_HANTEI_KB.Checked Then
                    sbParam.Append($",'{ParamModel.JIZEN_SINSA_HANTEI_KB}'")
                Else
                    sbParam.Append($",DEFAULT")
                End If

                If chkDispZESEI_SYOCHI_YOHI_KB.Checked Then
                    sbParam.Append($",'{ParamModel.ZESEI_SYOCHI_YOHI_KB}'")
                Else
                    sbParam.Append($",DEFAULT")
                End If
                If chkDispSAISIN_IINKAI_HANTEI_KB.Checked Then
                    sbParam.Append($",'{ParamModel.SAISIN_IINKAI_HANTEI_KB}'")
                Else
                    sbParam.Append($",DEFAULT")
                End If
                If chkDispKENSA_KEKKA_KB.Checked Then
                    sbParam.Append($",'{ParamModel.KENSA_KEKKA_KB}'")
                Else
                    sbParam.Append($",DEFAULT")
                End If

                'CAR
                If chkDispYOIN1.Checked Then
                    sbParam.Append($",'{ParamModel.KONPON_YOIN_KB1}'")
                Else
                    sbParam.Append($",DEFAULT")
                End If
                If chkDispYOIN2.Checked Then
                    sbParam.Append($",'{ParamModel.KONPON_YOIN_KB2}'")
                Else
                    sbParam.Append($",DEFAULT")
                End If
                If chkDispKISEKI_KOTEI_KB.Checked Then
                    sbParam.Append($",'{ParamModel.KISEKI_KOTEI_KB}'")
                Else
                    sbParam.Append($",DEFAULT")
                End If
                If chkDispKOKYAKU_HANTEI_SIJI_KB.Checked Then
                    sbParam.Append($",'{ParamModel.KOKYAKU_HANTEI_SIJI_KB}'")
                Else
                    sbParam.Append($",DEFAULT")
                End If
                If chkDispKOKYAKU_SAISYU_HANTEI_KB.Checked Then
                    sbParam.Append($",'{ParamModel.KOKYAKU_SAISYU_HANTEI_KB}'")
                Else
                    sbParam.Append($",DEFAULT")
                End If
                If chkDispGENIN1.Checked Then
                    sbParam.Append($",'{ParamModel.GENIN1}'")
                Else
                    sbParam.Append($",DEFAULT")
                End If
                If chkDispGENIN2.Checked Then
                    sbParam.Append($",'{ParamModel.GENIN2}'")
                Else
                    sbParam.Append($",DEFAULT")
                End If

                If chkDispHASSEI_YMD.Checked Then
                    sbParam.Append($",'{ParamModel.HASSEI_FROM}'")
                    sbParam.Append($",'{ParamModel.HASSEI_TO}'")
                Else
                    sbParam.Append($",DEFAULT")
                    sbParam.Append($",DEFAULT")
                End If

                sbSQL.Append($"EXEC dbo.{NameOf(MODEL.ST03_FUTEKIGO_ICHIRAN_SUMMARY)} {sbParam.ToString}")
            Case Else
                '共通
                sbParam.Append($" '{ParamModel.BUMON_KB}'")

                sbParam.Append($",{ParamModel.SYONIN_HOKOKUSYO_ID}")
                sbParam.Append($",{Nz(cmbKISYU.SelectedValue, 0)}")

                If Not cmbBUHIN_BANGO.Text.IsNulOrWS And cmbBUHIN_BANGO.SelectedValue <> cmbBUHIN_BANGO.NullValue Then
                    sbParam.Append($",'{cmbBUHIN_BANGO.Text.Trim}'")
                Else
                    sbParam.Append($",'{ParamModel.BUHIN_BANGO}'")
                End If

                sbParam.Append($",'{ParamModel.SYANAI_CD}'")
                sbParam.Append($",'{ParamModel.BUHIN_NAME}'")
                sbParam.Append($",'{ParamModel.GOUKI}'")
                sbParam.Append($",{Nz(cmbGEN_TANTO.SelectedValue, 0)}")
                sbParam.Append($",'{ParamModel.JISI_YMD_FROM}'")
                sbParam.Append($",'{ParamModel.JISI_YMD_TO}'")
                sbParam.Append($",'{ParamModel.HOKOKU_NO}'")
                sbParam.Append($",{ParamModel.ADD_TANTO}")
                sbParam.Append($",'{IIf(chkClosedRowVisibled.Checked, "", 0)}'")
                sbParam.Append($",'{IIf(ParamModel._VISIBLE_TAIRYU = 1, ParamModel._VISIBLE_TAIRYU, "")}'")
                sbParam.Append($",'{ParamModel.FUTEKIGO_KB}'")
                sbParam.Append($",'{ParamModel.FUTEKIGO_S_KB}'")
                sbParam.Append($",'{ParamModel.FUTEKIGO_JYOTAI_KB}'")

                'NCR
                sbParam.Append($",'{ParamModel.JIZEN_SINSA_HANTEI_KB}'")
                sbParam.Append($",'{ParamModel.ZESEI_SYOCHI_YOHI_KB}'")
                sbParam.Append($",'{ParamModel.SAISIN_IINKAI_HANTEI_KB}'")
                sbParam.Append($",'{ParamModel.KENSA_KEKKA_KB}'")

                'CAR
                sbParam.Append($",'{ParamModel.KONPON_YOIN_KB1}'")
                sbParam.Append($",'{ParamModel.KONPON_YOIN_KB2}'")
                sbParam.Append($",'{ParamModel.KISEKI_KOTEI_KB}'")
                sbParam.Append($",'{ParamModel.KOKYAKU_HANTEI_SIJI_KB}'")
                sbParam.Append($",'{ParamModel.KOKYAKU_SAISYU_HANTEI_KB}'")
                sbParam.Append($",'{ParamModel.GENIN1}'")
                sbParam.Append($",'{ParamModel.GENIN2}'")
                sbParam.Append($",'{ParamModel.HASSEI_FROM}'")
                sbParam.Append($",'{ParamModel.HASSEI_TO}'")

                sbSQL.Append($"EXEC dbo.{NameOf(MODEL.ST02_FUTEKIGO_ICHIRAN)} {sbParam.ToString}")
        End Select

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
        'Application.DoEvents()

        'flxDATA.DataSource = Nothing
        btnSummaryPage.Visible = False
        panelMan.SelectedPanel = panelMan.ManagedPanels(NameOf(mpnlCondition))
        'Me.Refresh()
        lblRecordCount.Visible = False

        If pub_intOPEN_MODE <> ENM_OPEN_MODE._3_分析集計 Then
            Call FunSetStageList(dgvNCR, Context.ENM_SYONIN_HOKOKUSYO_ID._1_NCR)
            Call FunSetStageList(dgvCAR, Context.ENM_SYONIN_HOKOKUSYO_ID._2_CAR)
            Call FunSetStageList(dgvCTS, Context.ENM_SYONIN_HOKOKUSYO_ID._3_CTS)
            ParamModel.SYONIN_HOKOKUSYO_ID = 0
        End If

        'Application.DoEvents()
    End Sub

#Region "削除ボタン使用権限判定"

    Private Function HasDeleteAuth(SYAIN_ID As Integer, HOKOKUSYO_ID As Integer, HOKOKU_NO As String) As Boolean

        Try
            'システムユーザーか
            If IsSysAdminUser(SYAIN_ID) Then Return True

            '指定の業務グループか
            If HasGYOMUGroupAuth(SYAIN_ID, {ENM_GYOMU_GROUP_ID._3_検査, ENM_GYOMU_GROUP_ID._4_品証}) Then Return True

            '起草者
            If IsIssuedUser(SYAIN_ID, HOKOKUSYO_ID, HOKOKU_NO) Then Return True

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
            If dsList.Tables(0).Rows(0).Item(0) = ENM_CAR_STAGE._10_起草入力.Value Then Return True

            Return False
        Catch ex As Exception
            Throw
            Return False
        End Try
    End Function

#End Region

#End Region

End Class