Imports System.Threading.Tasks
Imports C1.Win.C1FlexGrid
Imports JMS_COMMON.ClsPubMethod
Imports MODEL

''' <summary>
''' FCCB����
''' </summary>
Public Class FrmG0020_List

#Region "�萔�E�ϐ�"

    Private mDataView As DataView

#End Region

#Region "�R���X�g���N�^"

    ''' <summary>
    ''' �R���X�g���N�^
    ''' </summary>
    ''' <remarks>�R���X�g���N�^</remarks>
    Public Sub New()

        ' ���̌Ăяo���̓f�U�C�i�[�ŕK�v�ł��B
        InitializeComponent()

        Me.Icon = My.Resources._icoAppForm32x32
        Me.ShowIcon = True

        '�c�[���`�b�v���b�Z�[�W
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
            Case ENM_OPEN_MODE._1_�V�K�쐬, ENM_OPEN_MODE._2_���u��ʋN��
                Me.WindowState = FormWindowState.Minimized
        End Select

    End Sub

#End Region

#Region "Form�֘A"

    Private Sub FrmLoad(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        Try
            Me.Visible = False

            '-----�t�H�[�������ݒ�(�e�t�H�[������Ăяo��)
            Call FunFormCommonSetting(pub_APP_INFO, pub_SYAIN_INFO, My.Application.Info.Version.ToString)

            '-----�O���b�h�����ݒ�(�e�t�H�[������Ăяo��)
            Call FunInitializeFlexGrid(flxDATA)

            '-----�R���g���[���\�[�X�ݒ�
            cmbBUMON.SetDataSource(tblBUMON.ExcludeDeleted, ENM_COMBO_SELECT_VALUE_TYPE._1_Filter)
            cmbADD_TANTO.SetDataSource(tblTANTO.ExcludeDeleted, ENM_COMBO_SELECT_VALUE_TYPE._1_Filter)
            cmbKISYU.SetDataSource(tblKISYU.LazyLoad("�@��"), ENM_COMBO_SELECT_VALUE_TYPE._1_Filter)
            cmbBUHIN_BANGO.SetDataSource(tblBUHIN.LazyLoad("���i�ԍ�"), ENM_COMBO_SELECT_VALUE_TYPE._1_Filter)
            cmbSYANAI_CD.SetDataSource(tblSYANAI_CD.LazyLoad("�Г�CD").ExcludeDeleted, ENM_COMBO_SELECT_VALUE_TYPE._1_Filter)

            '----�R���g���[���C�x���g�n���h��
            AddHandler cmbBUMON.SelectedValueChanged, AddressOf CmbBUMON_SelectedValueChanged
            AddHandler cmbKISYU.SelectedValueChanged, AddressOf CmbKISYU_SelectedValueChanged
            AddHandler cmbSYANAI_CD.SelectedValueChanged, AddressOf CmbSYANAI_CD_SelectedValueChanged
            AddHandler cmbBUHIN_BANGO.SelectedValueChanged, AddressOf CmbBUHIN_BANGO_SelectedValueChanged

            '-----����l�ݒ�
            Dim dtGEN_TANTO As DataTable = Nothing
            Dim blnIsAdmin As Boolean = IsSysAdminUser(pub_SYAIN_INFO.SYAIN_ID)
            If blnIsAdmin Then
                '�V�X�e���Ǘ��҂̂ݐ�������
                dtGEN_TANTO = FunGetSYONIN_SYOZOKU_SYAIN(cmbBUMON.SelectedValue)
            Else
                Select Case pub_SYAIN_INFO.BUMON_KB
                    Case Context.ENM_BUMON_KB._1_���h, Context.ENM_BUMON_KB._2_LP
                        Dim dt As DataTable = DirectCast(cmbBUMON.DataSource, DataTable).
                                                    AsEnumerable.
                                                    Where(Function(r) r.Field(Of String)("VALUE") = "1" Or r.Field(Of String)("VALUE") = "2").
                                                    CopyToDataTable
                        cmbBUMON.SetDataSource(dt, ENM_COMBO_SELECT_VALUE_TYPE._1_Filter)
                        cmbBUMON.SelectedValue = pub_SYAIN_INFO.BUMON_KB

                        dtGEN_TANTO = FunGetSYONIN_SYOZOKU_SYAIN(pub_SYAIN_INFO.BUMON_KB)

                    Case Context.ENM_BUMON_KB._3_������
                        Dim dt As DataTable = DirectCast(cmbBUMON.DataSource, DataTable).
                                                    AsEnumerable.
                                                    Where(Function(r) r.Field(Of String)("VALUE") = pub_SYAIN_INFO.BUMON_KB).
                                                    CopyToDataTable
                        cmbBUMON.SetDataSource(dt, ENM_COMBO_SELECT_VALUE_TYPE._1_Filter)
                        cmbBUMON.SelectedValue = pub_SYAIN_INFO.BUMON_KB

                        dtGEN_TANTO = FunGetSYONIN_SYOZOKU_SYAIN(cmbBUMON.SelectedValue)
                    Case Else
                        '#255 ���h,LP,�����ވȊO�̕��及���҂͑S����{���̂�
                        dtGEN_TANTO = FunGetSYONIN_SYOZOKU_SYAIN(cmbBUMON.SelectedValue)
                End Select

                cmbGEN_TANTO.SetDataSource(dtGEN_TANTO, ENM_COMBO_SELECT_VALUE_TYPE._1_Filter)

                'If Not IsOPAdminUser(pub_SYAIN_INFO.SYAIN_ID) And pub_SYAIN_INFO.BUMON_KB <= Context.ENM_BUMON_KB._3_������ Then
                '    cmbGEN_TANTO.SelectedValue = pub_SYAIN_INFO.SYAIN_ID
                'End If
            End If

            ''-----�C�x���g�n���h���ݒ�
            AddHandler cmbKISYU.SelectedValueChanged, AddressOf SearchFilterValueChanged
            AddHandler cmbSYANAI_CD.SelectedValueChanged, AddressOf SearchFilterValueChanged
            AddHandler cmbGEN_TANTO.SelectedValueChanged, AddressOf SearchFilterValueChanged
            AddHandler mtxHOKUKO_NO.Validated, AddressOf SearchFilterValueChanged
            AddHandler cmbBUHIN_BANGO.SelectedValueChanged, AddressOf SearchFilterValueChanged
            AddHandler cmbADD_TANTO.SelectedValueChanged, AddressOf SearchFilterValueChanged
            AddHandler mtxHINMEI.Validated, AddressOf SearchFilterValueChanged
            AddHandler chkDeleteRowVisibled.CheckedChanged, AddressOf SearchFilterValueChanged
            AddHandler chkClosedRowVisibled.CheckedChanged, AddressOf SearchFilterValueChanged

            '�N�����[�h�ʏ���
            Using DB = DBOpen()
                lblTytle.Text = FunGetCodeMastaValue(DB, "PG_TITLE", Me.GetType.ToString)
            End Using
            Select Case pub_intOPEN_MODE
                Case ENM_OPEN_MODE._0_�ʏ�
                Case ENM_OPEN_MODE._1_�V�K�쐬
                    If FunUpdateEntity(ENM_DATA_OPERATION_MODE._1_ADD) = True Then
                        Call FunSRCH(flxDATA, FunGetListData())
                    End If
                Case ENM_OPEN_MODE._2_���u��ʋN��

                    Me.cmdFunc1.PerformClick()
                    Me.cmdFunc4.PerformClick()

                Case Else
                    Me.cmdFunc1.PerformClick()
            End Select

            '�t�@���N�V�����{�^���X�e�[�^�X�X�V
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
        ''   �{�^���ʒu�A�T�C�Y�ݒ�
        ''===================================
        'Call SetButtonSize(Me.Width, cmdFunc)
        'MyBase.FrmBaseStsBtn_Resize(Me, e)
    End Sub

#End Region

#Region "FlexGrid�֘A"

    '������
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

            '�ȉ���K�p����ɂ�VisualStyle��Custom�ɂ���
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

                    ''�ؗ�
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

#Region "DataGridView�֘A"

#Region "�t�B�[���h��`"

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
                .HeaderText = "�I��",
                .DataPropertyName = .Name
                }
                cmbclmn1.DefaultCellStyle.Alignment = Windows.Forms.DataGridViewContentAlignment.MiddleCenter
                .Columns.Add(cmbclmn1)
                .Columns(.ColumnCount - 1).SortMode = DataGridViewColumnSortMode.Automatic
                .Columns(.ColumnCount - 1).Width = 30

                .Columns.Add(NameOf(_Model.SYONIN_HOKOKUSYO_ID), "���F�񍐏�ID")
                .Columns(.ColumnCount - 1).DataPropertyName = .Columns(.ColumnCount - 1).Name
                .Columns(.ColumnCount - 1).Visible = False

                .Columns.Add(NameOf(_Model.BUMON_NAME), $"���i{vbCrLf}�敪")
                .Columns(.ColumnCount - 1).Width = 60
                .Columns(.ColumnCount - 1).DefaultCellStyle.Alignment = Windows.Forms.DataGridViewContentAlignment.MiddleLeft
                .Columns(.ColumnCount - 1).DataPropertyName = .Columns(.ColumnCount - 1).Name
                .Columns(.ColumnCount - 1).ReadOnly = True

                .Columns.Add(NameOf(_Model.HOKOKU_NO), "�񍐏�No")
                .Columns(.ColumnCount - 1).Width = 80
                .Columns(.ColumnCount - 1).DefaultCellStyle.Alignment = Windows.Forms.DataGridViewContentAlignment.MiddleCenter
                .Columns(.ColumnCount - 1).DataPropertyName = .Columns(.ColumnCount - 1).Name
                .Columns(.ColumnCount - 1).ReadOnly = True

                .Columns.Add(NameOf(_Model.CLOSE_FG), "Closed")
                .Columns(.ColumnCount - 1).DataPropertyName = .Columns(.ColumnCount - 1).Name
                .Columns(.ColumnCount - 1).Visible = False

                .Columns.Add(NameOf(_Model.SYONIN_JUN), "���F��")
                .Columns(.ColumnCount - 1).DataPropertyName = .Columns(.ColumnCount - 1).Name
                .Columns(.ColumnCount - 1).Visible = False

                .Columns.Add(NameOf(_Model.SYONIN_NAIYO), "�X�e�[�W")
                .Columns(.ColumnCount - 1).Width = 210
                .Columns(.ColumnCount - 1).DefaultCellStyle.Alignment = Windows.Forms.DataGridViewContentAlignment.MiddleLeft
                .Columns(.ColumnCount - 1).DataPropertyName = .Columns(.ColumnCount - 1).Name
                .Columns(.ColumnCount - 1).ReadOnly = True

                .Columns.Add(NameOf(_Model.SYONIN_HOKOKUSYO_R_NAME), "����")
                .Columns(.ColumnCount - 1).Width = 60
                .Columns(.ColumnCount - 1).DefaultCellStyle.Alignment = Windows.Forms.DataGridViewContentAlignment.MiddleCenter
                .Columns(.ColumnCount - 1).DataPropertyName = .Columns(.ColumnCount - 1).Name
                .Columns(.ColumnCount - 1).ReadOnly = True

                .Columns.Add(NameOf(_Model.GEN_TANTO_NAME), "���u�S����")
                .Columns(.ColumnCount - 1).Width = 120
                .Columns(.ColumnCount - 1).DefaultCellStyle.Alignment = Windows.Forms.DataGridViewContentAlignment.MiddleLeft
                .Columns(.ColumnCount - 1).DataPropertyName = .Columns(.ColumnCount - 1).Name
                .Columns(.ColumnCount - 1).ReadOnly = True

                .Columns.Add(NameOf(_Model.TAIRYU_FG), "�ؗ��t���O")
                .Columns(.ColumnCount - 1).DataPropertyName = .Columns(.ColumnCount - 1).Name
                .Columns(.ColumnCount - 1).Visible = False

                .Columns.Add(NameOf(_Model.TAIRYU_NISSU), $"�ؗ�{vbCrLf}����")
                .Columns(.ColumnCount - 1).Width = 60
                .Columns(.ColumnCount - 1).DefaultCellStyle.Alignment = Windows.Forms.DataGridViewContentAlignment.MiddleRight
                .Columns(.ColumnCount - 1).DataPropertyName = .Columns(.ColumnCount - 1).Name
                .Columns(.ColumnCount - 1).ReadOnly = True

                .Columns.Add(NameOf(_Model.KISYU_NAME), "�@��")
                .Columns(.ColumnCount - 1).Width = 120
                .Columns(.ColumnCount - 1).DefaultCellStyle.Alignment = Windows.Forms.DataGridViewContentAlignment.MiddleLeft
                .Columns(.ColumnCount - 1).DataPropertyName = .Columns(.ColumnCount - 1).Name
                .Columns(.ColumnCount - 1).ReadOnly = True

                .Columns.Add(NameOf(_Model.BUHIN_BANGO), "���i�ԍ�")
                .Columns(.ColumnCount - 1).Width = 180
                .Columns(.ColumnCount - 1).DefaultCellStyle.Alignment = Windows.Forms.DataGridViewContentAlignment.MiddleLeft
                .Columns(.ColumnCount - 1).DataPropertyName = .Columns(.ColumnCount - 1).Name
                '.Columns(.ColumnCount - 1).Frozen = True
                .Columns(.ColumnCount - 1).ReadOnly = True

                .Columns.Add(NameOf(_Model.SYANAI_CD), "�Г��R�[�h")
                .Columns(.ColumnCount - 1).Width = 150
                .Columns(.ColumnCount - 1).DefaultCellStyle.Alignment = Windows.Forms.DataGridViewContentAlignment.MiddleLeft
                .Columns(.ColumnCount - 1).DataPropertyName = .Columns(.ColumnCount - 1).Name
                '.Columns(.ColumnCount - 1).Frozen = True
                .Columns(.ColumnCount - 1).ReadOnly = True

                .Columns.Add(NameOf(_Model.BUHIN_NAME), "���i��")
                .Columns(.ColumnCount - 1).Width = 180
                .Columns(.ColumnCount - 1).DefaultCellStyle.Alignment = Windows.Forms.DataGridViewContentAlignment.MiddleLeft
                .Columns(.ColumnCount - 1).DataPropertyName = .Columns(.ColumnCount - 1).Name
                .Columns(.ColumnCount - 1).ReadOnly = True

                .Columns.Add(NameOf(_Model.GOKI), "���@")
                .Columns(.ColumnCount - 1).Width = 100
                .Columns(.ColumnCount - 1).DefaultCellStyle.Alignment = Windows.Forms.DataGridViewContentAlignment.MiddleLeft
                .Columns(.ColumnCount - 1).DataPropertyName = .Columns(.ColumnCount - 1).Name
                .Columns(.ColumnCount - 1).ReadOnly = True

                .Columns.Add(NameOf(_Model.SYONIN_HOKOKUSYO_NAME), "�񍐏�����")
                .Columns(.ColumnCount - 1).Width = 180
                .Columns(.ColumnCount - 1).DefaultCellStyle.Alignment = Windows.Forms.DataGridViewContentAlignment.MiddleLeft
                .Columns(.ColumnCount - 1).DataPropertyName = .Columns(.ColumnCount - 1).Name
                .Columns(.ColumnCount - 1).ReadOnly = True
                .Columns(.ColumnCount - 1).Visible = False

                .Columns.Add(NameOf(_Model.JIZEN_SINSA_HANTEI_NAME), "���O����敪")
                .Columns(.ColumnCount - 1).Width = 140
                .Columns(.ColumnCount - 1).DefaultCellStyle.Alignment = Windows.Forms.DataGridViewContentAlignment.MiddleLeft
                .Columns(.ColumnCount - 1).DataPropertyName = .Columns(.ColumnCount - 1).Name
                .Columns(.ColumnCount - 1).ReadOnly = True

                .Columns.Add(NameOf(_Model.SAISIN_IINKAI_HANTEI_NAME), "�ĐR����敪")
                .Columns(.ColumnCount - 1).Width = 140
                .Columns(.ColumnCount - 1).DefaultCellStyle.Alignment = Windows.Forms.DataGridViewContentAlignment.MiddleLeft
                .Columns(.ColumnCount - 1).DataPropertyName = .Columns(.ColumnCount - 1).Name
                .Columns(.ColumnCount - 1).ReadOnly = True

                .Columns.Add(NameOf(_Model.HASSEI_YMD), "������")
                .Columns(.ColumnCount - 1).Width = 100
                .Columns(.ColumnCount - 1).DefaultCellStyle.Alignment = Windows.Forms.DataGridViewContentAlignment.MiddleCenter
                .Columns(.ColumnCount - 1).DataPropertyName = .Columns(.ColumnCount - 1).Name
                .Columns(.ColumnCount - 1).ReadOnly = True

                .Columns.Add(NameOf(_Model.SYONIN_YMDHNS), $"�O����{vbCrLf}���{��")
                .Columns(.ColumnCount - 1).Width = 100
                .Columns(.ColumnCount - 1).DefaultCellStyle.Alignment = Windows.Forms.DataGridViewContentAlignment.MiddleCenter
                .Columns(.ColumnCount - 1).DataPropertyName = .Columns(.ColumnCount - 1).Name
                .Columns(.ColumnCount - 1).ReadOnly = True

                .Columns.Add(NameOf(_Model.SASIMOTO_SYONIN_JUN), "���ߏ��F��")
                .Columns(.ColumnCount - 1).DataPropertyName = .Columns(.ColumnCount - 1).Name
                .Columns(.ColumnCount - 1).Visible = False

                .Columns.Add(NameOf(_Model.SASIMOTO_SYONIN_NAIYO), "���ߌ��X�e�[�W")
                .Columns(.ColumnCount - 1).Width = 180
                .Columns(.ColumnCount - 1).DefaultCellStyle.Alignment = Windows.Forms.DataGridViewContentAlignment.MiddleLeft
                .Columns(.ColumnCount - 1).DataPropertyName = .Columns(.ColumnCount - 1).Name
                .Columns(.ColumnCount - 1).ReadOnly = True

                .Columns.Add(NameOf(_Model.RIYU), "���ߗ��R")
                .Columns(.ColumnCount - 1).Width = 180
                .Columns(.ColumnCount - 1).DefaultCellStyle.Alignment = Windows.Forms.DataGridViewContentAlignment.MiddleLeft
                .Columns(.ColumnCount - 1).DataPropertyName = .Columns(.ColumnCount - 1).Name
                .Columns(.ColumnCount - 1).ReadOnly = True

                .Columns.Add(NameOf(_Model.SASIMOTO_SYONIN_JUN), "���ߏ��F��")
                .Columns(.ColumnCount - 1).Visible = False
                .Columns(.ColumnCount - 1).DataPropertyName = .Columns(.ColumnCount - 1).Name
                .Columns(.ColumnCount - 1).ReadOnly = True

                .Columns.Add(NameOf(_Model.DEL_YMDHNS), "�폜����")
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

                .Columns.Add("SYONIN_NAIYO", "�X�e�[�W��")
                .Columns(.ColumnCount - 1).Width = 305
                .Columns(.ColumnCount - 1).DefaultCellStyle.Alignment = Windows.Forms.DataGridViewContentAlignment.MiddleLeft
                .Columns(.ColumnCount - 1).DataPropertyName = .Columns(.ColumnCount - 1).Name
                .Columns(.ColumnCount - 1).ReadOnly = True

                .Columns.Add("COUNT", "����")
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

    '�O���b�h�Z��(�s)�_�u���N���b�N���C�x���g
    Private Sub DgvDATA_CellDoubleClick(sender As System.Object, e As DataGridViewCellEventArgs) Handles dgvDATA.CellDoubleClick
        Try
            '�w�b�_�ȊO�̃Z���_�u���N���b�N��
            If e.RowIndex >= 0 Then
                '�Y���s�̕ύX���������s����
                Me.cmdFunc4.PerformClick()
            End If
        Catch ex As Exception
            EM.ErrorSyori(ex, False, conblnNonMsg)
        End Try
    End Sub

    '�s�I�����C�x���g
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

    '�\�[�g���C�x���g
    Private Sub DgvDATA_Sorted(sender As Object, e As EventArgs) Handles dgvDATA.Sorted
        'Call FunSetDgvCellFormat(sender)
    End Sub

    '�s����
    Private Function FunSetDgvCellFormat(ByVal dgv As DataGridView) As Boolean
        Dim _Model As New MODEL.ST02_FUTEKIGO_ICHIRAN
        Try
            For i As Integer = 0 To dgv.Rows.Count - 1

                '#55
                ''�����߂�
                'If dgvDATA.Rows(i).Cells(NameOf(_Model.SASIMOTO_SYONIN_JUN)).Value > 0 Then
                '    Me.dgvDATA.Rows(i).DefaultCellStyle.BackColor = clrCautionCellBackColor
                'End If

                ''�ؗ�
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

#Region "�@�O���b�h�ҏW�֘A"

    ''' <summary>
    ''' �O���b�h�ҏW�O����
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks>�O���b�h�ҏW�O����</remarks>
    Private Sub DgvDATA_CellBeginEdit(sender As Object, e As System.Windows.Forms.DataGridViewCellCancelEventArgs)

        ' �ҏW�O�̒l��Ҕ����Ă���
        'pri_intPrevCellValue = Val(Me.dgvDATA.CurrentCell.Value)
    End Sub

    '�Z���ҏW�����C�x���g
    Private Sub DgvDATA_CellEndEdit(sender As Object, e As DataGridViewCellEventArgs)
        Try

            'Dim intEditedCellValue As Integer
            'intEditedCellValue = Val(Me.dgvDATA.CurrentCell.Value)

            'If pri_intPrevCellValue <> intEditedCellValue Then
            '    '�J�����g�Z�������ύX
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

    '�Z���N���b�N���C�x���g
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
                            '    '�I��s��
                            '    Me.dgvDATA.CurrentRow.Cells("SELECTED").Value = False
                            '    MessageBox.Show("�������f�[�^�ȊO�͑I���o���܂���B", "�I��s��", MessageBoxButtons.OK, MessageBoxIcon.Information)
                        End If
                End Select

            End If
        Catch ex As Exception
            EM.ErrorSyori(ex, False, conblnNonMsg)
        Finally
            FunInitFuncButtonEnabled()
        End Try
    End Sub

#Region "�ҏW�\�Z��OnMouse���J�[�\���ύX"

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

#Region "���͐���"

    'EditingControlShowing�C�x���g
    Private Sub DataGridView1_EditingControlShowing(ByVal sender As Object, ByVal e As DataGridViewEditingControlShowingEventArgs)
        '�\������Ă���R���g���[����DataGridViewTextBoxEditingControl�����ׂ�
        If TypeOf e.Control Is DataGridViewTextBoxEditingControl Then
            Dim dgv As DataGridView = CType(sender, DataGridView)

            '�ҏW�̂��߂ɕ\������Ă���R���g���[�����擾
            Dim tb As DataGridViewTextBoxEditingControl =
                CType(e.Control, DataGridViewTextBoxEditingControl)

            '�C�x���g�n���h�����폜
            RemoveHandler tb.KeyPress, AddressOf DataGridViewTextBox_KeyPress

            '�Y������񂩒��ׂ�
            Select Case dgv.CurrentCell.OwningColumn.Name
                Case "TANKA", "HACYU_SU"
                    'KeyPress�C�x���g�n���h����ǉ�
                    AddHandler tb.KeyPress, AddressOf DataGridViewTextBox_KeyPress
                Case Else
                    '
            End Select
        End If
    End Sub

    'DataGridView�ɕ\������Ă���e�L�X�g�{�b�N�X��KeyPress�C�x���g�n���h��
    Private Sub DataGridViewTextBox_KeyPress(ByVal sender As Object, ByVal e As KeyPressEventArgs)
        '����(+BACKSPACE)�������͂ł��Ȃ��悤�ɂ���
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

#Region "FunctionButton�֘A"

#Region "�{�^���N���b�N�C�x���g"

    Private Sub CmdFunc_Click(ByVal sender As Object, ByVal e As EventArgs) Handles cmdFunc1.Click, cmdFunc2.Click, cmdFunc3.Click, cmdFunc4.Click, cmdFunc5.Click, cmdFunc6.Click, cmdFunc7.Click, cmdFunc8.Click, cmdFunc9.Click, cmdFunc10.Click, cmdFunc11.Click, cmdFunc12.Click
        Dim intFUNC As Integer
        Dim intCNT As Integer

        Try
            '[������]
            Me.PrPG_STATUS = ENM_PG_STATUS._3_PROCESSING
            Me.Cursor = Cursors.WaitCursor

            '�{�^���s��/�{�^��INDEX�擾
            For intCNT = 0 To Me.cmdFunc.Length - 1
                Me.cmdFunc(intCNT).Enabled = False
                If cmdFunc(intCNT) Is sender Then intFUNC = intCNT + 1
            Next

            '�{�^��INDEX���̏���
            Select Case intFUNC
                Case 1  '����

                    If IsValidatedSearchFilter() Then
                        Call FunSRCH(flxDATA, FunGetListData())
                    End If

                Case 2  '�ǉ�

                    If FunUpdateEntity(ENM_DATA_OPERATION_MODE._1_ADD) = True Then
                        Call FunSRCH(flxDATA, FunGetListData())
                    End If

                Case 4  '�ύX

                    If FunUpdateEntity(ENM_DATA_OPERATION_MODE._3_UPDATE) = True Then
                        Call FunSRCH(flxDATA, FunGetListData())
                    End If

                Case 5  '�폜/����/���S�폜

                    'If MessageBox.Show("�I�����ꂽ�f�[�^���폜���܂���?", "�폜�m�F", MessageBoxButtons.OKCancel, MessageBoxIcon.Information) = DialogResult.OK Then
                    If OpenFormEdit() Then
                        Dim dr As DataRow = DirectCast(flxDATA.Rows(flxDATA.Row).DataSource, DataRowView).Row
                        If FunDEL(Context.ENM_SYONIN_HOKOKUSYO_ID._4_FCCB.Value, dr.Item(NameOf(ST04_FCCB_ICHIRAN.FCCB_NO))) Then
                            Call FunSRCH(flxDATA, FunGetListData())
                        End If
                    End If

                Case 6 '����
                    If flxDATA.Rows(flxDATA.RowSel) IsNot Nothing Then
                        If MessageBox.Show("�I�����ꂽ�f�[�^�𕜌����܂���?", "�����m�F", MessageBoxButtons.OKCancel, MessageBoxIcon.Information) = DialogResult.OK Then
                            Dim dr As DataRow = DirectCast(flxDATA.Rows(flxDATA.Row).DataSource, DataRowView).Row
                            If FunRESTORE(Context.ENM_SYONIN_HOKOKUSYO_ID._4_FCCB.Value, dr.Item(NameOf(ST04_FCCB_ICHIRAN.FCCB_NO))) Then
                                Call FunSRCH(flxDATA, FunGetListData())
                            End If
                        End If
                    Else
                        MessageBox.Show("�Y���f�[�^���I������Ă��܂���B", "", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    End If

                Case 8 'CSV�o��
                    Dim strFileName As String
                    strFileName = $"{"FCCB"}_{DateTime.Now:yyyyMMddHHmmss}.CSV"

                    Call FunCSV_OUTviaFlexGrid(flxDATA, strFileName, pub_APP_INFO.strOUTPUT_PATH)
                    'Call FunCSV_OUT(DirectCast(flxDATA.DataSource, DataView).Table, strFileName, pub_APP_INFO.strOUTPUT_PATH)
                Case 9 '���[�����M

                    Call FunMailSending()
                Case 10  '���
                    Call FunOpenReport()

                    'Dim strFileName As String = pub_APP_INFO.strTitle & "_" & DateTime.Today.ToString("yyyyMMdd") & ".CSV"
                    'Call FunCSV_OUT(Me.dgvDATA.DataSource, strFileName, pub_APP_INFO.strOUTPUT_PATH)

                Case 11 '����\��

                    Call OpenFormRIREKI()

                Case 12 '����
                    Me.Close()
            End Select
        Catch ex As Exception
            EM.ErrorSyori(ex, False, conblnNonMsg)
        Finally
            '�{�^����
            System.Windows.Forms.Application.DoEvents()
            For intCNT = 0 To Me.cmdFunc.Length - 1
                Me.cmdFunc(intCNT).Enabled = True
            Next

            '�t�@���N�V�����L�[�L����������
            If intFUNC <> 12 Then Call FunInitFuncButtonEnabled()

            '[�A�N�e�B�u]
            Me.PrPG_STATUS = ENM_PG_STATUS._2_ACTIVE

            Me.Cursor = Cursors.Default
        End Try

    End Sub

#End Region

#Region "����"

    Private Function FunGetListData() As DataTable
        Try

            'SPEC: PF01.2-(1) A ��������

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
                                    '�����̂݉��H
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

            'CHECK: ���咊�o�����K�p ���O�C�����[�U�[�̏����ƈقȂ镔������̏ꍇ�E�E�E(���ׂ�)���܂�
            Dim blnIsAdmin As Boolean = IsSysAdminUser(pub_SYAIN_INFO.SYAIN_ID)
            If blnIsAdmin Then
                '�V�X�e���Ǘ��҂̂ݐ�������
            Else
                'If pub_SYAIN_INFO.BUMON_KB <> ParamModel.BUMON_KB Then
                Select Case pub_SYAIN_INFO.BUMON_KB
                    Case Context.ENM_BUMON_KB._1_���h, Context.ENM_BUMON_KB._2_LP
                        Dim qdt = tplDataModel.dt.AsEnumerable.Where(Function(r) r.Field(Of String)("BUMON_KB") = 1 Or r.Field(Of String)("BUMON_KB") = 2).ToList
                        If qdt.Count > 0 Then
                            tplDataModel.dt = qdt.CopyToDataTable
                        End If

                    Case Context.ENM_BUMON_KB._3_������
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
                '-----�I���s�ݒ�
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

#Region "�ǉ��E�ύX"

    ''' <summary>
    ''' ���R�[�h�ǉ��ύX����
    ''' </summary>
    ''' <param name="intMODE">�������[�h</param>
    ''' <returns></returns>
    Private Function FunUpdateEntity(ByVal intMODE As ENM_DATA_OPERATION_MODE) As Boolean

        Dim dlgRET As DialogResult

        Try

            Using frmFCCB As New FrmG0021_Detail
                frmFCCB.PrMODE = intMODE
                Select Case intMODE
                    Case ENM_DATA_OPERATION_MODE._1_ADD
                        frmFCCB.PrCurrentStage = ENM_FCCB_STAGE._10_�N������
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

#Region "�폜"

    Private Function FunDEL(ByVal intSYONIN_HOKOKUSYO_ID As Integer, ByVal strHOKOKU_NO As String) As Boolean
        Dim sbSQL As New System.Text.StringBuilder

        Try

            '-----UPDATE
            sbSQL.Append($"UPDATE {NameOf(D009_FCCB_J)} SET")
            sbSQL.Append($" {NameOf(D009_FCCB_J.DEL_SYAIN_ID)}={pub_SYAIN_INFO.SYAIN_ID}")
            sbSQL.Append($" ,{NameOf(D009_FCCB_J.DEL_YMDHNS)}=dbo.GetSysDateString()")
            sbSQL.Append($" WHERE {NameOf(D009_FCCB_J.FCCB_NO)}='{strHOKOKU_NO.ConvertSqlEscape}'")

            'CHECK: �ꗗ�폜�{�^�� D004��R001���̕ҏW�����͂ǂ����邩

            '-----SQL���s
            Using DB As ClsDbUtility = DBOpen()
                Dim sqlEx As New Exception
                Dim blnErr As Boolean
                Dim intRET As Integer
                Try
                    DB.BeginTransaction()

                    intRET = DB.ExecuteNonQuery(sbSQL.ToString, conblnNonMsg, sqlEx)
                    If intRET <> 1 Then
                        '-----�G���[���O�o��
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

            'CHECK: �ꗗ�폜�{�^�� D004��R001���̕ҏW�����͂ǂ����邩

            '-----SQL���s
            Using DB As ClsDbUtility = DBOpen()
                Dim sqlEx As New Exception
                Dim blnErr As Boolean
                Dim intRET As Integer
                Try
                    DB.BeginTransaction()

                    intRET = DB.ExecuteNonQuery(sbSQL.ToString, conblnNonMsg, sqlEx)
                    If intRET <> 1 Then
                        '-----�G���[���O�o��
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

#Region "�폜���R�_�C�A���O"

    Private Function OpenFormEdit() As Boolean
        Dim frmDLG As New FrmG0024_EditComment
        Dim dlgRET As DialogResult

        Try

            With flxDATA.Rows(flxDATA.RowSel)
                frmDLG.PrSYORI_NAME = "����o�^"
                frmDLG.PrSYONIN_HOKOKUSYO_ID = .Item(NameOf(V013_FCCB_ICHIRAN.SYONIN_HOKOKUSYO_ID))
                frmDLG.PrHOKOKU_NO = .Item(NameOf(V013_FCCB_ICHIRAN.FCCB_NO))
                frmDLG.PrBUMON_KB = .Item(NameOf(V013_FCCB_ICHIRAN.BUMON_KB))
                frmDLG.PrBUHIN_BANGO = .Item(NameOf(V013_FCCB_ICHIRAN.BUHIN_BANGO))
                frmDLG.PrKISYU_NAME = tblKISYU.LazyLoad("�@��").AsEnumerable.Where(Function(r) r.Field(Of Integer)("VALUE") = .Item(NameOf(V013_FCCB_ICHIRAN.KISYU_ID))).FirstOrDefault?.Item("DISP")
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

#Region "���[�����M"

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

                        Dim strMsg As String = "�ȉ��̒S���҂ɏ��u�ؗ��ʒm���[���𑗐M���܂��B" & vbCrLf &
                                                   "��낵���ł����H" & vbCrLf &
                                                   vbCrLf &
                                                   strTantoNameList
                        If MessageBox.Show(strMsg, "���u�ؗ��ʒm���[�����M", MessageBoxButtons.OKCancel, MessageBoxIcon.Information) = DialogResult.OK Then
                            For Each dr As DataRow In dt.CopyToDataTable.Rows
                                Dim strEXEParam As String = $"{dr.Item(NameOf(ST04_FCCB_ICHIRAN.GEN_TANTO_ID))},{ENM_OPEN_MODE._2_���u��ʋN��},{dr.Item(NameOf(ST04_FCCB_ICHIRAN.SYONIN_HOKOKUSYO_ID))},{dr.Item(NameOf(ST04_FCCB_ICHIRAN.FCCB_NO))}"
                                Dim strSubject As String = $"�yFCCB���u�˗��zFCCB-NO:{dr.Item("FCCB_NO")} {dr.Item(NameOf(ST04_FCCB_ICHIRAN.KISYU_NAME))}�E{dr.Item(NameOf(ST04_FCCB_ICHIRAN.BUHIN_BANGO))}"
                                Dim strBody As String = <body><![CDATA[
                                {0} �a<br />
                                <br />
                                �@FCCB�L�^���̏��u�˗�����y�ؗ������z{1}�����o�߂��Ă��܂��B<br />
                                �@���}�ɑΉ������肢���܂��B<br />
                                <br />
                                �@�@�y�� �� ���z{2}<br />
                                �@�@�y�񍐏�No�z{3}<br />
                                �@�@�y�N �� ���z{4}<br />
                                �@�@�y�@�@  ��z{5}<br />
                                �@�@�y���i�ԍ��z{6}<br />
                                �@�@�y�� �� �ҁz{7}<br />
                                <br />
                                <a href = "http://sv04:8000/CLICKONCE_FMS.application" > �V�X�e���N��</a><br />
                                <br />
                                �����̃��[���͔z�M��p�ł��B(�ԐM�ł��܂���)<br />
                                �ԐM����ꍇ�́A�e�S���҂̃��[���A�h���X���g�p���ĉ������B<br />
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
                                    "FCCB�L�^���Ǘ��V�X�e��",
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
                                    MessageBox.Show("���[�����M�Ɏ��s���܂����B", "���[�����M���s", MessageBoxButtons.OK, MessageBoxIcon.Information)
                                    blnErr = True
                                    Return False
                                End If
                            Next dr

                            MessageBox.Show("���u�˗����[���𑗐M���܂����B", "���[�����M����", MessageBoxButtons.OK, MessageBoxIcon.Information)

                            ''�S�I������
                            'Call FunUnSelectAll()

                            Return True
                        End If
                    Finally
                        DB.Commit(Not blnErr)
                    End Try
                End Using
            Else
                Dim dr As DataRow = DirectCast(flxDATA.Rows(flxDATA.Row).DataSource, DataRowView).Row

                '�I���`�F�b�N�͓����Ă��Ȃ��ꍇ�A�I���s�̂�
                Dim strMsg As String = "�ȉ��̒S���҂ɏ��u�ؗ��ʒm���[���𑗐M���܂��B" & vbCrLf &
                                    "��낵���ł����H" & vbCrLf &
                                    vbCrLf &
                                    dr.Item(NameOf(ST04_FCCB_ICHIRAN.GEN_TANTO_NAME))

                If MessageBox.Show(strMsg, "���u�ؗ��ʒm���[�����M", MessageBoxButtons.OKCancel, MessageBoxIcon.Information) = DialogResult.OK Then

                    Dim strEXEParam As String = dr.Item(NameOf(ST04_FCCB_ICHIRAN.GEN_TANTO_ID)) & "," & ENM_OPEN_MODE._2_���u��ʋN�� & "," & dr.Item(NameOf(ST04_FCCB_ICHIRAN.SYONIN_HOKOKUSYO_ID)) & "," & dr.Item(NameOf(MODEL.ST02_FUTEKIGO_ICHIRAN.HOKOKU_NO))
                    Dim strSubject As String = $"�yFCCB���u�˗��zFCCB-NO:{dr.Item(NameOf(ST04_FCCB_ICHIRAN.FCCB_NO))} {dr.Item(NameOf(ST04_FCCB_ICHIRAN.KISYU_NAME))}�E{dr.Item(NameOf(ST04_FCCB_ICHIRAN.BUHIN_BANGO))}"
                    Dim strBody As String = <body><![CDATA[
                    {0} �a<br />
                    <br />
                    �@FCCB�L�^���̏��u�˗�����y�ؗ������z{1}�����o�߂��Ă��܂��B<br />
                    �@���}�ɑΉ������肢���܂��B<br />
                    <br />
                    �y�񍐏�No�z{3}<br />
                    �y�N �� ���z{4}<br />
                    �y�@�@  ��z{5}<br />
                    �y���i�ԍ��z{6}<br />
                    �y�� �� �ҁz{7}<br />
                    <br />
                    <a href = "http://sv04:8000/CLICKONCE_FMS.application" > �V�X�e���N��</a><br />
                    <br />
                    �����̃��[���͔z�M��p�ł��B(�ԐM�ł��܂���)<br />
                    �ԐM����ꍇ�́A�e�S���҂̃��[���A�h���X���g�p���ĉ������B<br />
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
                        MessageBox.Show("���[�����M�Ɏ��s���܂����B", "���[�����M���s", MessageBoxButtons.OK, MessageBoxIcon.Information)
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
    ''' �񍐏����엚���X�V
    ''' </summary>
    ''' <param name="DB"></param>
    ''' <param name="enmSAVE_MODE"></param>
    ''' <returns></returns>
    Private Function FunSAVE_R001(ByRef DB As ClsDbUtility, ByVal dr As DataRow) As Boolean
        Dim sbSQL As New System.Text.StringBuilder
        Dim intRET As Integer
        Dim sqlEx As New Exception
        Dim strSysDate As String = DB.GetSysDateString
        'MERGE INTO �ɕύX

        '-----�f�[�^���f���X�V
        _R001_HOKOKU_SOUSA.Clear()
        _R001_HOKOKU_SOUSA.SYONIN_HOKOKUSYO_ID = dr.Item(NameOf(ST04_FCCB_ICHIRAN.SYONIN_HOKOKUSYO_ID))
        _R001_HOKOKU_SOUSA.HOKOKU_NO = dr.Item(NameOf(ST04_FCCB_ICHIRAN.FCCB_NO))
        _R001_HOKOKU_SOUSA.SYONIN_JUN = dr.Item(NameOf(ST04_FCCB_ICHIRAN.SYONIN_JUN))
        _R001_HOKOKU_SOUSA.SYAIN_ID = pub_SYAIN_INFO.SYAIN_ID
        _R001_HOKOKU_SOUSA.SOUSA_KB = ENM_SOUSA_KB._4_���[�����M
        _R001_HOKOKU_SOUSA.SYONIN_HANTEI_KB = ENM_SYONIN_HANTEI_KB._0_�����F
        _R001_HOKOKU_SOUSA.RIYU = "���u�ؗ��ʒm���M"
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

        '-----SQL���s
        intRET = DB.ExecuteNonQuery(sbSQL.ToString, conblnNonMsg, sqlEx)
        If intRET <> 1 Then
            '-----�G���[���O�o��
            Dim strErrMsg As String = My.Resources.ErrLogSqlExecutionFailure & sbSQL.ToString & "|" & sqlEx.Message
            WL.WriteLogDat(strErrMsg)
            Return False
        Else
            Return True
        End If
    End Function

#End Region

#Region "���"

    Private Function FunOpenReport() As Boolean
        Dim strOutputFileName As String
        Dim strTEMPFILE As String
        'Dim intRET As Integer
        Try
            Dim strHOKOKU_NO As String = flxDATA.Rows(flxDATA.RowSel).Item(NameOf(ST04_FCCB_ICHIRAN.FCCB_NO))
            Me.Cursor = Cursors.WaitCursor

            '�t�@�C����
            strOutputFileName = "FCCB_" & strHOKOKU_NO & "_Work.xlsx"

            '�����t�@�C���폜
            If FunDELETE_FILE(pub_APP_INFO.strOUTPUT_PATH & strOutputFileName) = False Then
                Return False
            End If

            Using iniIF As New IniFile(FunGetRootPath() & "\INI\" & CON_TEMPLATE_INI)
                strTEMPFILE = FunConvRootPath(iniIF.GetIniString("FCCB", "FILEPATH"))
            End Using

            '�G�N�Z���o�̓t�@�C���p��
            If OUT_EXCEL_READY(strTEMPFILE, pub_APP_INFO.strOUTPUT_PATH, strOutputFileName) = False Then
                Return False
            End If
            '-----��������
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

#Region "����"

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

#Region "FuncButton�L�������ؑ�"

    ''' <summary>
    ''' �g�p���Ȃ��{�^���̃L���v�V�������Ȃ����A���񊈐��ɂ���B
    ''' �t�@���N�V�����L�[������(F**)�ȊO�̕������Ȃ��ꍇ�́A���g�p�Ƃ݂Ȃ�
    ''' </summary>
    ''' <param name="frm">�Ώۃt�H�[��</param>
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

                '�I���s��Closed�̏ꍇ
                If Val(flxDATA.Rows(flxDATA.RowSel).Item(NameOf(_D009.CLOSE_FG))) = 1 Then

                    If HasEditingRight(pub_SYAIN_INFO.SYAIN_ID) Then
                        cmdFunc4.Text = "�C��(F4)"
                    Else
                        cmdFunc4.Text = "���e�m�F(F4)"
                    End If

                    'cmdFunc5.Enabled = False
                    'MyBase.ToolTip.SetToolTip(Me.cmdFunc5, "�N���[�Y�ς̂��ߎ���o���܂���")
                Else
                    cmdFunc4.Text = "�ύX�E���F(F4)"
                    'MyBase.ToolTip.SetToolTip(Me.cmdFunc5, My.Resources.infoToolTipMsgNotFoundData)
                End If

                '�폜�{�^��
                If HasDeleteAuth(pub_SYAIN_INFO.SYAIN_ID,
                                     flxDATA.Rows(flxDATA.RowSel).Item(NameOf(ST04_FCCB_ICHIRAN.SYONIN_HOKOKUSYO_ID)),
                                     flxDATA.Rows(flxDATA.RowSel).Item(NameOf(ST04_FCCB_ICHIRAN.FCCB_NO))) Then

                    If flxDATA.Rows(flxDATA.RowSel).Item(NameOf(ST04_FCCB_ICHIRAN.CLOSE_FG)) = 1 Then
                        cmdFunc5.Enabled = False
                        MyBase.ToolTip.SetToolTip(Me.cmdFunc5, "Close�ς̃f�[�^�ł�")
                        cmdFunc6.Enabled = True
                    ElseIf flxDATA.Rows(flxDATA.RowSel).Item(NameOf(_D009.DEL_YMDHNS)).ToString.Trim <> "" Then
                        cmdFunc5.Enabled = False
                        MyBase.ToolTip.SetToolTip(Me.cmdFunc5, "����ς݃f�[�^�ł�")
                        cmdFunc6.Enabled = True
                    Else
                        cmdFunc5.Enabled = True
                    End If
                Else

                    If flxDATA.Rows(flxDATA.RowSel).Item(NameOf(ST04_FCCB_ICHIRAN.DEL_YMDHNS)).ToString.Trim <> "" Then
                        '�폜�ς�
                        'cmdFunc4.Enabled = False
                        'MyBase.ToolTip.SetToolTip(Me.cmdFunc4, "����ς݃f�[�^�ł�")
                        cmdFunc5.Enabled = False
                        MyBase.ToolTip.SetToolTip(Me.cmdFunc5, "����ς݃f�[�^�ł�")
                        'flxDATA.Rows(flxDATA.RowSel).Item("SELECTED").ReadOnly = True
                    End If
                    'cmdFunc6.Visible = False
                    cmdFunc5.Enabled = False
                    MyBase.ToolTip.SetToolTip(Me.cmdFunc5, "����@�\�̎g�p����������܂���")
                End If

                If FunblnAllowTairyuMailSend() Then
                    cmdFunc9.Enabled = True
                    MyBase.ToolTip.SetToolTip(Me.cmdFunc9, My.Resources.infoToolTipMsgNotFoundData)
                Else
                    cmdFunc9.Enabled = False
                    MyBase.ToolTip.SetToolTip(Me.cmdFunc9, "�ؗ��ʒm���[�����M����������܂���")
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

#Region "�R���g���[���C�x���g"

    '�����t�B���^�ύX��
    Private Sub SearchFilterValueChanged(sender As System.Object, e As System.EventArgs)
        Call SetStageList()
    End Sub

    'Close�ς�
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

#Region "���������N���A"

    Private Sub btnClearSrchFilter_Click(sender As Object, e As EventArgs) Handles btnClearSrchFilter.Click

        RemoveHandler chkDeleteRowVisibled.CheckedChanged, AddressOf SearchFilterValueChanged
        chkDeleteRowVisibled.Checked = False
        AddHandler chkDeleteRowVisibled.CheckedChanged, AddressOf SearchFilterValueChanged

    End Sub

#End Region

#Region "���ʌ�������"

#Region "���i�敪(����敪)"

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

                    '�@��
                    RemoveHandler cmbKISYU.SelectedValueChanged, AddressOf CmbKISYU_SelectedValueChanged
                    If blnSelected Then
                        Dim drs = tblKISYU_J.LazyLoad("�@�����").AsEnumerable.Where(Function(r) r.Field(Of String)(NameOf(ST04_FCCB_ICHIRAN.BUMON_KB)) = cmb.SelectedValue)
                        If drs.Count > 0 Then
                            Dim dt As DataTable = drs.CopyToDataTable
                            cmbKISYU.SetDataSource(dt, ENM_COMBO_SELECT_VALUE_TYPE._1_Filter)
                            cmbKISYU.SelectedValue = 0
                        End If
                    Else
                        cmbKISYU.SetDataSource(tblKISYU_J.LazyLoad("�@�����"), ENM_COMBO_SELECT_VALUE_TYPE._1_Filter)
                    End If
                    AddHandler cmbKISYU.SelectedValueChanged, AddressOf CmbKISYU_SelectedValueChanged

                    '���i�ԍ�
                    RemoveHandler cmbBUHIN_BANGO.SelectedValueChanged, AddressOf CmbBUHIN_BANGO_SelectedValueChanged
                    If blnSelected Then
                        Dim drs = tblBUHIN_J.LazyLoad("���i�ԍ�����").AsEnumerable.Where(Function(r) r.Field(Of String)(NameOf(ST04_FCCB_ICHIRAN.BUMON_KB)) = cmb.SelectedValue)
                        If drs.Count > 0 Then
                            Dim dt As DataTable = drs.CopyToDataTable
                            cmbBUHIN_BANGO.SetDataSource(dt, ENM_COMBO_SELECT_VALUE_TYPE._1_Filter)
                            cmbBUHIN_BANGO.SelectedValue = ""
                        End If
                    Else
                        cmbBUHIN_BANGO.SetDataSource(tblBUHIN_J.LazyLoad("���i�ԍ�����"), ENM_COMBO_SELECT_VALUE_TYPE._1_Filter)
                    End If
                    AddHandler cmbBUHIN_BANGO.SelectedValueChanged, AddressOf CmbBUHIN_BANGO_SelectedValueChanged

                    '�Г��R�[�h
                    RemoveHandler cmbSYANAI_CD.SelectedValueChanged, AddressOf CmbSYANAI_CD_SelectedValueChanged
                    cmbSYANAI_CD.DataBindings.Clear()
                    If blnSelected Then
                        If Val(cmb.SelectedValue) = Context.ENM_BUMON_KB._2_LP Then
                            Dim drs = tblSYANAI_CD_J.LazyLoad("�Г�CD����").AsEnumerable.Where(Function(r) r.Field(Of String)(NameOf(ST04_FCCB_ICHIRAN.BUMON_KB)) = cmb.SelectedValue)
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
                        cmbSYANAI_CD.SetDataSource(tblSYANAI_CD_J.LazyLoad("�Г�CD����"), ENM_COMBO_SELECT_VALUE_TYPE._1_Filter)
                    End If
                    AddHandler cmbSYANAI_CD.SelectedValueChanged, AddressOf CmbSYANAI_CD_SelectedValueChanged

                End Sub)
            End Sub)

    End Sub

#End Region

#Region "�@��"

    Private Async Sub CmbKISYU_SelectedValueChanged(sender As Object, e As EventArgs)
        Dim cmb As ComboboxEx = DirectCast(sender, ComboboxEx)

        Await Task.Run(
            Sub()
                Me.Invoke(
                Sub()
                    '���i�ԍ�

                    RemoveHandler cmbBUHIN_BANGO.SelectedValueChanged, AddressOf CmbBUHIN_BANGO_SelectedValueChanged
                    cmbBUHIN_BANGO.DataBindings.Clear()
                    If cmb.IsSelected Then
                        Dim drs = tblBUHIN_J.LazyLoad("���i�ԍ�����").AsEnumerable.Where(Function(r) r.Field(Of Integer)(NameOf(_D009.KISYU_ID)) = cmb.SelectedValue)
                        If drs.Count > 0 Then
                            Dim dt As DataTable = drs.CopyToDataTable
                            Dim _selectedValue As String = cmbBUHIN_BANGO.SelectedValue

                            cmbBUHIN_BANGO.SetDataSource(dt, ENM_COMBO_SELECT_VALUE_TYPE._1_Filter)
                            If Not cmbBUHIN_BANGO.NullValue = cmbBUHIN_BANGO.SelectedValue Then
                                'ParamModel.BUHIN_BANGO = _selectedValue
                            End If
                        End If
                    Else
                        cmbBUHIN_BANGO.SetDataSource(tblBUHIN_J.LazyLoad("���i�ԍ�����"), ENM_COMBO_SELECT_VALUE_TYPE._1_Filter)
                    End If
                    AddHandler cmbBUHIN_BANGO.SelectedValueChanged, AddressOf CmbBUHIN_BANGO_SelectedValueChanged

                    If Val(cmbBUMON.SelectedValue) = ENM_BUMON_KB._2_LP Then
                        '�Г��R�[�h
                        RemoveHandler cmbSYANAI_CD.SelectedValueChanged, AddressOf CmbSYANAI_CD_SelectedValueChanged
                        cmbSYANAI_CD.DataBindings.Clear()

                        If cmb.IsSelected Then
                            If Val(cmb.SelectedValue) = Context.ENM_BUMON_KB._2_LP Then
                                Dim drs = tblSYANAI_CD_J.LazyLoad("�Г�CD����").AsEnumerable.Where(Function(r) r.Field(Of Integer)(NameOf(ST04_FCCB_ICHIRAN.KISYU_ID)) = cmb.SelectedValue)
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
                            cmbSYANAI_CD.SetDataSource(tblSYANAI_CD_J.LazyLoad("�Г�CD����"), ENM_COMBO_SELECT_VALUE_TYPE._1_Filter)
                        End If
                        AddHandler cmbSYANAI_CD.SelectedValueChanged, AddressOf CmbSYANAI_CD_SelectedValueChanged

                    End If

                End Sub)
            End Sub)

    End Sub

#End Region

#Region "�Г��R�[�h"

    Private Async Sub CmbSYANAI_CD_SelectedValueChanged(sender As Object, e As EventArgs)
        Dim cmb As ComboboxEx = DirectCast(sender, ComboboxEx)
        Try

            RemoveHandler cmbSYANAI_CD.SelectedValueChanged, AddressOf CmbSYANAI_CD_SelectedValueChanged

            Await Task.Run(
                Sub()
                    Me.Invoke(
                    Sub()
                        '���i�ԍ�
                        RemoveHandler cmbBUHIN_BANGO.SelectedValueChanged, AddressOf CmbBUHIN_BANGO_SelectedValueChanged
                        If cmb.IsSelected Then
                            Dim drs = tblBUHIN_J.LazyLoad("���i�ԍ�����").AsEnumerable.Where(Function(r) r.Field(Of String)(NameOf(ST04_FCCB_ICHIRAN.SYANAI_CD)) = cmb.SelectedValue).ToList
                            If drs.Count > 0 Then cmbBUHIN_BANGO.SetDataSource(drs.CopyToDataTable, ENM_COMBO_SELECT_VALUE_TYPE._1_Filter)
                        Else
                            cmbBUHIN_BANGO.SetDataSource(tblBUHIN_J.LazyLoad("���i�ԍ�����"), ENM_COMBO_SELECT_VALUE_TYPE._1_Filter)
                        End If
                        AddHandler cmbBUHIN_BANGO.SelectedValueChanged, AddressOf CmbBUHIN_BANGO_SelectedValueChanged

                        '���o
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

#Region "���i�ԍ�"

    Private Async Sub CmbBUHIN_BANGO_SelectedValueChanged(sender As Object, e As EventArgs)
        Dim cmb As ComboboxEx = DirectCast(sender, ComboboxEx)

        'RemoveHandler cmbBUHIN_BANGO.SelectedValueChanged, AddressOf CmbBUHIN_BANGO_SelectedValueChanged
        'RemoveHandler cmbSYANAI_CD.SelectedValueChanged, AddressOf CmbSYANAI_CD_SelectedValueChanged

        Await Task.Run(Sub()
                           Me.Invoke(Sub()

                                         '�Г��R�[�h
                                         If cmb.IsSelected Then
                                             cmbSYANAI_CD.DataBindings.Clear()
                                             If Val(cmb.SelectedValue) = Context.ENM_BUMON_KB._2_LP Then
                                                 Dim drs = tblSYANAI_CD.LazyLoad("�Г�CD").AsEnumerable.Where(Function(r) r.Field(Of String)(NameOf(ST04_FCCB_ICHIRAN.BUHIN_BANGO)) = cmb.SelectedValue).ToList
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
                                             cmbSYANAI_CD.SetDataSource(tblSYANAI_CD.LazyLoad("�Г�CD").ExcludeDeleted, ENM_COMBO_SELECT_VALUE_TYPE._1_Filter)
                                         End If
                                         'AddHandler cmbSYANAI_CD.SelectedValueChanged, AddressOf CmbSYANAI_CD_SelectedValueChanged

                                         '���o
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

#Region "���̓`�F�b�N"

    Private Sub CmbHOKOKUSYO_ID_Validating(sender As Object, e As System.ComponentModel.CancelEventArgs)
        If pub_intOPEN_MODE <> ENM_OPEN_MODE._3_���͏W�v Then Return

        Dim cmb As ComboboxEx = DirectCast(sender, ComboboxEx)
        If IsCheckRequired Then
            IsValidated *= ErrorProvider.UpdateErrorInfo(cmb, cmb.IsSelected, String.Format(My.Resources.infoMsgRequireSelectOrInput, "�񍐏���"))
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

#Region "���[�J���֐�"

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
        sbSQL.Append($" WHERE {NameOf(MODEL.VWM001_SETTING.ITEM_NAME)}='�ؗ����[�����M����'")
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

#Region "�폜�{�^���g�p��������"

    Private Function HasDeleteAuth(SYAIN_ID As Integer, HOKOKUSYO_ID As Integer, HOKOKU_NO As String) As Boolean

        Try
            '�V�X�e�����[�U�[��
            If IsSysAdminUser(SYAIN_ID) Then
                Return True
            End If

            '�w��̋Ɩ��O���[�v��
            If HasGYOMUGroupAuth(SYAIN_ID, {ENM_GYOMU_GROUP_ID._3_����, ENM_GYOMU_GROUP_ID._4_�i��}) Then
                Return True
            End If

            '#250 �ĕs�K���̕񍐏��͋N���ҁA���N���ł�����s�Ƃ���
            If HOKOKU_NO.Substring(HOKOKU_NO.Length - 1, 1).ToVal > 0 Then
                Return False
            End If

            '�N����
            If IsIssuedUser(SYAIN_ID, HOKOKUSYO_ID, HOKOKU_NO) Then
                Return True
            End If

            '���N��(ST1 �ꎞ�ۑ����]��)�͒N�ł�����
            Dim sbSQL As New System.Text.StringBuilder
            Dim dsList As New DataSet
            sbSQL.Append($"SELECT ISNULL(MAX({NameOf(D004_SYONIN_J_KANRI.SYONIN_JUN)}),0)")
            sbSQL.Append($" FROM {NameOf(D004_SYONIN_J_KANRI)} ")
            sbSQL.Append($" WHERE {NameOf(D004_SYONIN_J_KANRI.HOKOKU_NO)}='{HOKOKU_NO}'")
            sbSQL.Append($" AND {NameOf(D004_SYONIN_J_KANRI.SYONIN_HOKOKUSYO_ID)}={HOKOKUSYO_ID}")
            sbSQL.Append($" AND {NameOf(D004_SYONIN_J_KANRI.SYONIN_HANTEI_KB)}='{ENM_SYONIN_HANTEI_KB._0_�����F.Value}'")

            Using DB As ClsDbUtility = DBOpen()
                dsList = DB.GetDataSet(sbSQL.ToString, conblnNonMsg)
            End Using
            If dsList.Tables(0).Rows(0).Item(0) = ENM_FCCB_STAGE._10_�N������.Value Then
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