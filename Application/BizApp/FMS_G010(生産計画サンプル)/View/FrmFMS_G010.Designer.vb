
<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class FrmFMS_G010
    Inherits JMS_COMMON.FrmBaseStsBtnDgv

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()>
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        If disposing AndAlso components IsNot Nothing Then
            components.Dispose()
        End If
        MyBase.Dispose(disposing)
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Dim EntityViewSourceProperties1 As C1.Win.Data.Entities.EntityViewSourceProperties = New C1.Win.Data.Entities.EntityViewSourceProperties()
        Dim FilterDescriptorProperties1 As C1.Win.Data.FilterDescriptorProperties = New C1.Win.Data.FilterDescriptorProperties()
        Dim ControlHandler2 As C1.Win.Data.ControlHandler = New C1.Win.Data.ControlHandler()
        Dim ControlHandler1 As C1.Win.Data.ControlHandler = New C1.Win.Data.ControlHandler()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmFMS_G010))
        Dim ControlHandler3 As C1.Win.Data.ControlHandler = New C1.Win.Data.ControlHandler()
        Me.SaveFileDialog = New System.Windows.Forms.SaveFileDialog()
        Me.OpenFileDialog = New System.Windows.Forms.OpenFileDialog()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.cmbMonthRange = New JMS_COMMON.ComboboxEx()
        Me.gbxFilter = New System.Windows.Forms.GroupBox()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.tlpFilter = New System.Windows.Forms.TableLayoutPanel()
        Me.dtYM = New JMS_COMMON.DateTextBoxEx()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.cmbKOTEI = New JMS_COMMON.ComboboxEx()
        Me.C1DataSource = New C1.Win.Data.Entities.C1DataSource()
        Me.dgvDATA = New System.Windows.Forms.DataGridView()
        Me.dgvMaintenance = New System.Windows.Forms.DataGridView()
        Me.fgdKEIKAKU = New C1.Win.C1FlexGrid.C1FlexGrid()
        Me.TableLayoutPanel1 = New System.Windows.Forms.TableLayoutPanel()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.cmbFilter = New JMS_COMMON.ComboboxEx()
        Me.cmbBUHIN = New JMS_COMMON.ComboboxEx()
        Me.C1SplitContainer1 = New C1.Win.C1SplitContainer.C1SplitContainer()
        Me.C1SplitterPanel1 = New C1.Win.C1SplitContainer.C1SplitterPanel()
        Me.C1SplitterPanel2 = New C1.Win.C1SplitContainer.C1SplitterPanel()
        Me.C1SplitContainer2 = New C1.Win.C1SplitContainer.C1SplitContainer()
        Me.sptPanel_dgvHINBAN = New C1.Win.C1SplitContainer.C1SplitterPanel()
        Me.sptPanel_FlexGrid = New C1.Win.C1SplitContainer.C1SplitterPanel()
        Me.gbxFilter.SuspendLayout()
        Me.tlpFilter.SuspendLayout()
        CType(Me.C1DataSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dgvDATA, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dgvMaintenance, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.fgdKEIKAKU, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.TableLayoutPanel1.SuspendLayout()
        CType(Me.C1SplitContainer1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.C1SplitContainer1.SuspendLayout()
        Me.C1SplitterPanel1.SuspendLayout()
        Me.C1SplitterPanel2.SuspendLayout()
        CType(Me.C1SplitContainer2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.C1SplitContainer2.SuspendLayout()
        Me.sptPanel_dgvHINBAN.SuspendLayout()
        Me.sptPanel_FlexGrid.SuspendLayout()
        Me.SuspendLayout()
        '
        'cmdFunc1
        '
        Me.cmdFunc1.Image = Global.FMS.My.Resources.Resources._imgBase_floppydisk32x32
        Me.cmdFunc1.Location = New System.Drawing.Point(10, 658)
        Me.cmdFunc1.Margin = New System.Windows.Forms.Padding(4, 6, 4, 6)
        Me.cmdFunc1.Size = New System.Drawing.Size(153, 30)
        Me.cmdFunc1.Text = "ìoò^(F1)"
        '
        'cmdFunc2
        '
        Me.cmdFunc2.Image = Global.FMS.My.Resources.Resources._imgStatusAnnotations_Blocked_32x32_MD
        Me.cmdFunc2.Location = New System.Drawing.Point(323, 658)
        Me.cmdFunc2.Margin = New System.Windows.Forms.Padding(4, 6, 4, 6)
        Me.cmdFunc2.Size = New System.Drawing.Size(153, 30)
        Me.cmdFunc2.Text = "çÌèú(F2)"
        '
        'cmdFunc3
        '
        Me.cmdFunc3.Location = New System.Drawing.Point(478, 658)
        Me.cmdFunc3.Margin = New System.Windows.Forms.Padding(4, 6, 4, 6)
        Me.cmdFunc3.Size = New System.Drawing.Size(153, 30)
        '
        'cmdFunc4
        '
        Me.cmdFunc4.Location = New System.Drawing.Point(632, 658)
        Me.cmdFunc4.Margin = New System.Windows.Forms.Padding(4, 6, 4, 6)
        Me.cmdFunc4.Size = New System.Drawing.Size(16, 30)
        Me.cmdFunc4.Visible = False
        '
        'cmdFunc5
        '
        Me.cmdFunc5.Location = New System.Drawing.Point(655, 659)
        Me.cmdFunc5.Margin = New System.Windows.Forms.Padding(4, 6, 4, 6)
        Me.cmdFunc5.Size = New System.Drawing.Size(16, 30)
        Me.cmdFunc5.Visible = False
        '
        'cmdFunc6
        '
        Me.cmdFunc6.Location = New System.Drawing.Point(678, 659)
        Me.cmdFunc6.Margin = New System.Windows.Forms.Padding(4, 6, 4, 6)
        Me.cmdFunc6.Size = New System.Drawing.Size(16, 30)
        Me.cmdFunc6.Visible = False
        '
        'cmdFunc12
        '
        Me.cmdFunc12.Image = Global.FMS.My.Resources.Resources._imgLog_Out32x32
        Me.cmdFunc12.Location = New System.Drawing.Point(940, 658)
        Me.cmdFunc12.Margin = New System.Windows.Forms.Padding(4, 6, 4, 6)
        Me.cmdFunc12.Size = New System.Drawing.Size(153, 30)
        Me.cmdFunc12.Text = "ï¬Ç∂ÇÈ(F12)"
        '
        'cmdFunc11
        '
        Me.cmdFunc11.Location = New System.Drawing.Point(791, 658)
        Me.cmdFunc11.Margin = New System.Windows.Forms.Padding(4, 6, 4, 6)
        Me.cmdFunc11.Size = New System.Drawing.Size(16, 30)
        Me.cmdFunc11.Visible = False
        '
        'cmdFunc10
        '
        Me.cmdFunc10.Location = New System.Drawing.Point(768, 658)
        Me.cmdFunc10.Margin = New System.Windows.Forms.Padding(4, 6, 4, 6)
        Me.cmdFunc10.Size = New System.Drawing.Size(16, 30)
        Me.cmdFunc10.Visible = False
        '
        'cmdFunc7
        '
        Me.cmdFunc7.Location = New System.Drawing.Point(544, 659)
        Me.cmdFunc7.Margin = New System.Windows.Forms.Padding(4, 6, 4, 6)
        Me.cmdFunc7.Size = New System.Drawing.Size(16, 30)
        Me.cmdFunc7.Visible = False
        '
        'cmdFunc9
        '
        Me.cmdFunc9.Location = New System.Drawing.Point(744, 659)
        Me.cmdFunc9.Margin = New System.Windows.Forms.Padding(4, 6, 4, 6)
        Me.cmdFunc9.Size = New System.Drawing.Size(16, 30)
        Me.cmdFunc9.Visible = False
        '
        'cmdFunc8
        '
        Me.cmdFunc8.Location = New System.Drawing.Point(721, 659)
        Me.cmdFunc8.Margin = New System.Windows.Forms.Padding(4, 6, 4, 6)
        Me.cmdFunc8.Size = New System.Drawing.Size(16, 30)
        Me.cmdFunc8.Visible = False
        '
        'lblTytle
        '
        Me.lblTytle.Font = New System.Drawing.Font("Meiryo UI", 24.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTytle.Location = New System.Drawing.Point(10, 12)
        Me.lblTytle.Margin = New System.Windows.Forms.Padding(4, 6, 4, 0)
        Me.lblTytle.Size = New System.Drawing.Size(1243, 35)
        Me.lblTytle.Text = "çHíˆï ê∂éYåvâÊ"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.tlpFilter.SetColumnSpan(Me.Label3, 3)
        Me.Label3.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Label3.Font = New System.Drawing.Font("Meiryo UI", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label3.Location = New System.Drawing.Point(3, 0)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(39, 21)
        Me.Label3.TabIndex = 54
        Me.Label3.Text = "îNåéÅñ"
        Me.Label3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'cmbMonthRange
        '
        Me.cmbMonthRange.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.cmbMonthRange.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cmbMonthRange.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.tlpFilter.SetColumnSpan(Me.cmbMonthRange, 4)
        Me.cmbMonthRange.Cursor = System.Windows.Forms.Cursors.Hand
        Me.cmbMonthRange.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbMonthRange.Font = New System.Drawing.Font("Meiryo UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.cmbMonthRange.FormattingEnabled = True
        Me.cmbMonthRange.Location = New System.Drawing.Point(213, 3)
        Me.cmbMonthRange.Name = "cmbMonthRange"
        Me.cmbMonthRange.Size = New System.Drawing.Size(54, 25)
        Me.cmbMonthRange.TabIndex = 0
        '
        'gbxFilter
        '
        Me.gbxFilter.Controls.Add(Me.Button1)
        Me.gbxFilter.Controls.Add(Me.tlpFilter)
        Me.gbxFilter.Dock = System.Windows.Forms.DockStyle.Fill
        Me.gbxFilter.Font = New System.Drawing.Font("Meiryo UI", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.gbxFilter.Location = New System.Drawing.Point(0, 0)
        Me.gbxFilter.Name = "gbxFilter"
        Me.gbxFilter.Size = New System.Drawing.Size(1241, 44)
        Me.gbxFilter.TabIndex = 59
        Me.gbxFilter.TabStop = False
        Me.gbxFilter.Text = "åüçıÉIÉvÉVÉáÉì(ÅñÇÕïKê{çÄñ⁄)"
        '
        'Button1
        '
        Me.Button1.Cursor = System.Windows.Forms.Cursors.Hand
        Me.Button1.Dock = System.Windows.Forms.DockStyle.Right
        Me.Button1.Image = Global.FMS.My.Resources.Resources._imgSearch32x32
        Me.Button1.Location = New System.Drawing.Point(1160, 20)
        Me.Button1.Margin = New System.Windows.Forms.Padding(2)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(78, 21)
        Me.Button1.TabIndex = 63
        Me.Button1.Text = "åüçı"
        Me.Button1.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.Button1.UseVisualStyleBackColor = True
        '
        'tlpFilter
        '
        Me.tlpFilter.ColumnCount = 50
        Me.tlpFilter.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 15.0!))
        Me.tlpFilter.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 15.0!))
        Me.tlpFilter.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 15.0!))
        Me.tlpFilter.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 15.0!))
        Me.tlpFilter.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 15.0!))
        Me.tlpFilter.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 15.0!))
        Me.tlpFilter.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 15.0!))
        Me.tlpFilter.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 15.0!))
        Me.tlpFilter.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 15.0!))
        Me.tlpFilter.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 15.0!))
        Me.tlpFilter.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 15.0!))
        Me.tlpFilter.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 15.0!))
        Me.tlpFilter.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 15.0!))
        Me.tlpFilter.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 15.0!))
        Me.tlpFilter.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 15.0!))
        Me.tlpFilter.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 15.0!))
        Me.tlpFilter.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 15.0!))
        Me.tlpFilter.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 15.0!))
        Me.tlpFilter.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 15.0!))
        Me.tlpFilter.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 15.0!))
        Me.tlpFilter.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 15.0!))
        Me.tlpFilter.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 15.0!))
        Me.tlpFilter.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 15.0!))
        Me.tlpFilter.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 15.0!))
        Me.tlpFilter.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 15.0!))
        Me.tlpFilter.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 15.0!))
        Me.tlpFilter.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 15.0!))
        Me.tlpFilter.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 15.0!))
        Me.tlpFilter.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 15.0!))
        Me.tlpFilter.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 15.0!))
        Me.tlpFilter.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 15.0!))
        Me.tlpFilter.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 15.0!))
        Me.tlpFilter.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 15.0!))
        Me.tlpFilter.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 15.0!))
        Me.tlpFilter.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 15.0!))
        Me.tlpFilter.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 15.0!))
        Me.tlpFilter.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 15.0!))
        Me.tlpFilter.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 15.0!))
        Me.tlpFilter.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 15.0!))
        Me.tlpFilter.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 15.0!))
        Me.tlpFilter.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 15.0!))
        Me.tlpFilter.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 15.0!))
        Me.tlpFilter.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 15.0!))
        Me.tlpFilter.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 15.0!))
        Me.tlpFilter.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 15.0!))
        Me.tlpFilter.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 15.0!))
        Me.tlpFilter.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 15.0!))
        Me.tlpFilter.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 15.0!))
        Me.tlpFilter.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 15.0!))
        Me.tlpFilter.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.tlpFilter.Controls.Add(Me.Label3, 0, 0)
        Me.tlpFilter.Controls.Add(Me.dtYM, 3, 0)
        Me.tlpFilter.Controls.Add(Me.Label1, 9, 0)
        Me.tlpFilter.Controls.Add(Me.cmbMonthRange, 14, 0)
        Me.tlpFilter.Controls.Add(Me.Label5, 19, 0)
        Me.tlpFilter.Controls.Add(Me.cmbKOTEI, 22, 0)
        Me.tlpFilter.Dock = System.Windows.Forms.DockStyle.Left
        Me.tlpFilter.Location = New System.Drawing.Point(3, 20)
        Me.tlpFilter.Name = "tlpFilter"
        Me.tlpFilter.RowCount = 2
        Me.tlpFilter.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 21.0!))
        Me.tlpFilter.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.tlpFilter.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 14.0!))
        Me.tlpFilter.Size = New System.Drawing.Size(838, 21)
        Me.tlpFilter.TabIndex = 56
        '
        'dtYM
        '
        Me.dtYM.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.tlpFilter.SetColumnSpan(Me.dtYM, 5)
        Me.dtYM.DisplayFormat = JMS_COMMON.DateTextBoxEx.EnumType.yyyyMM
        Me.dtYM.Location = New System.Drawing.Point(48, 3)
        Me.dtYM.MaxDate = New Date(9998, 12, 31, 0, 0, 0, 0)
        Me.dtYM.MinDate = New Date(1753, 1, 1, 0, 0, 0, 0)
        Me.dtYM.Name = "dtYM"
        Me.dtYM.Size = New System.Drawing.Size(69, 15)
        Me.dtYM.TabIndex = 56
        Me.dtYM.Value = ""
        Me.dtYM.ValueNonFormat = ""
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.tlpFilter.SetColumnSpan(Me.Label1, 5)
        Me.Label1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Label1.Font = New System.Drawing.Font("Meiryo UI", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label1.Location = New System.Drawing.Point(138, 0)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(69, 21)
        Me.Label1.TabIndex = 55
        Me.Label1.Text = "ï\é¶åéêîÅñ"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.tlpFilter.SetColumnSpan(Me.Label5, 3)
        Me.Label5.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Label5.Font = New System.Drawing.Font("Meiryo UI", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label5.Location = New System.Drawing.Point(288, 0)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(39, 21)
        Me.Label5.TabIndex = 55
        Me.Label5.Text = "çHíˆÅñ"
        Me.Label5.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'cmbKOTEI
        '
        Me.cmbKOTEI.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.cmbKOTEI.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cmbKOTEI.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.tlpFilter.SetColumnSpan(Me.cmbKOTEI, 8)
        Me.cmbKOTEI.Cursor = System.Windows.Forms.Cursors.Hand
        Me.cmbKOTEI.DataSource = Me.C1DataSource
        Me.cmbKOTEI.DisplayMember = "M001_SETTING.ITEM_NAME"
        Me.cmbKOTEI.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbKOTEI.Font = New System.Drawing.Font("Meiryo UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.cmbKOTEI.FormattingEnabled = True
        Me.cmbKOTEI.Location = New System.Drawing.Point(333, 3)
        Me.cmbKOTEI.Name = "cmbKOTEI"
        Me.cmbKOTEI.Size = New System.Drawing.Size(114, 25)
        Me.cmbKOTEI.TabIndex = 0
        Me.cmbKOTEI.ValueMember = "M001_SETTING.ITEM_NAME"
        '
        'C1DataSource
        '
        Me.C1DataSource.ContextType = GetType(FMS_MODEL.FMS_Context)
        EntityViewSourceProperties1.EntitySetName = "M001_SETTING"
        FilterDescriptorProperties1.Operator = C1.Data.DataSource.FilterOperator.IsNotEqualTo
        FilterDescriptorProperties1.PropertyPath = "ITEM_NAME"
        EntityViewSourceProperties1.FilterDescriptors.Add(FilterDescriptorProperties1)
        EntityViewSourceProperties1.Include = ""
        Me.C1DataSource.ViewSourceCollection.Add(EntityViewSourceProperties1)
        '
        'dgvDATA
        '
        Me.dgvDATA.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.TableLayoutPanel1.SetColumnSpan(Me.dgvDATA, 2)
        ControlHandler2.AutoLookup = False
        ControlHandler2.VirtualMode = False
        Me.C1DataSource.SetControlHandler(Me.dgvDATA, ControlHandler2)
        Me.dgvDATA.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dgvDATA.Location = New System.Drawing.Point(3, 38)
        Me.dgvDATA.Name = "dgvDATA"
        Me.dgvDATA.RowTemplate.Height = 21
        Me.dgvDATA.Size = New System.Drawing.Size(313, 355)
        Me.dgvDATA.TabIndex = 61
        '
        'dgvMaintenance
        '
        Me.dgvMaintenance.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.TableLayoutPanel1.SetColumnSpan(Me.dgvMaintenance, 2)
        ControlHandler1.AutoLookup = False
        ControlHandler1.VirtualMode = False
        Me.C1DataSource.SetControlHandler(Me.dgvMaintenance, ControlHandler1)
        Me.dgvMaintenance.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dgvMaintenance.Location = New System.Drawing.Point(3, 399)
        Me.dgvMaintenance.Name = "dgvMaintenance"
        Me.dgvMaintenance.RowTemplate.Height = 21
        Me.dgvMaintenance.Size = New System.Drawing.Size(313, 100)
        Me.dgvMaintenance.TabIndex = 61
        '
        'fgdKEIKAKU
        '
        Me.fgdKEIKAKU.AllowAddNew = True
        Me.fgdKEIKAKU.AllowDelete = True
        Me.fgdKEIKAKU.AllowFiltering = True
        Me.fgdKEIKAKU.ColumnInfo = resources.GetString("fgdKEIKAKU.ColumnInfo")
        ControlHandler3.AutoLookup = True
        ControlHandler3.VirtualMode = False
        Me.C1DataSource.SetControlHandler(Me.fgdKEIKAKU, ControlHandler3)
        Me.fgdKEIKAKU.DataMember = "M001_SETTING"
        Me.fgdKEIKAKU.DataSource = Me.C1DataSource
        Me.fgdKEIKAKU.Dock = System.Windows.Forms.DockStyle.Fill
        Me.fgdKEIKAKU.Location = New System.Drawing.Point(0, 0)
        Me.fgdKEIKAKU.Margin = New System.Windows.Forms.Padding(2)
        Me.fgdKEIKAKU.Name = "fgdKEIKAKU"
        Me.fgdKEIKAKU.Rows.Count = 1
        Me.fgdKEIKAKU.Rows.DefaultSize = 23
        Me.fgdKEIKAKU.Size = New System.Drawing.Size(910, 502)
        Me.fgdKEIKAKU.TabIndex = 0
        '
        'TableLayoutPanel1
        '
        Me.TableLayoutPanel1.BackColor = System.Drawing.Color.Transparent
        Me.TableLayoutPanel1.ColumnCount = 2
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 59.62963!))
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 40.37037!))
        Me.TableLayoutPanel1.Controls.Add(Me.Label2, 0, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.dgvDATA, 0, 2)
        Me.TableLayoutPanel1.Controls.Add(Me.dgvMaintenance, 0, 3)
        Me.TableLayoutPanel1.Controls.Add(Me.Label4, 1, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.cmbFilter, 1, 1)
        Me.TableLayoutPanel1.Controls.Add(Me.cmbBUHIN, 0, 1)
        Me.TableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TableLayoutPanel1.Location = New System.Drawing.Point(0, 0)
        Me.TableLayoutPanel1.Margin = New System.Windows.Forms.Padding(2)
        Me.TableLayoutPanel1.Name = "TableLayoutPanel1"
        Me.TableLayoutPanel1.RowCount = 4
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 14.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 21.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 106.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 14.0!))
        Me.TableLayoutPanel1.Size = New System.Drawing.Size(319, 502)
        Me.TableLayoutPanel1.TabIndex = 62
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Label2.Font = New System.Drawing.Font("Meiryo UI", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label2.Location = New System.Drawing.Point(3, 0)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(184, 14)
        Me.Label2.TabIndex = 54
        Me.Label2.Text = "ïîïiî‘çÜ"
        Me.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Label4.Font = New System.Drawing.Font("Meiryo UI", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label4.Location = New System.Drawing.Point(193, 0)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(123, 14)
        Me.Label4.TabIndex = 54
        Me.Label4.Text = "ÉtÉBÉãÉ^"
        Me.Label4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'cmbFilter
        '
        Me.cmbFilter.Dock = System.Windows.Forms.DockStyle.Fill
        Me.cmbFilter.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbFilter.FormattingEnabled = True
        Me.cmbFilter.Location = New System.Drawing.Point(192, 16)
        Me.cmbFilter.Margin = New System.Windows.Forms.Padding(2)
        Me.cmbFilter.Name = "cmbFilter"
        Me.cmbFilter.Size = New System.Drawing.Size(125, 20)
        Me.cmbFilter.TabIndex = 62
        '
        'cmbBUHIN
        '
        Me.cmbBUHIN.Dock = System.Windows.Forms.DockStyle.Fill
        Me.cmbBUHIN.FormattingEnabled = True
        Me.cmbBUHIN.Location = New System.Drawing.Point(2, 16)
        Me.cmbBUHIN.Margin = New System.Windows.Forms.Padding(2)
        Me.cmbBUHIN.Name = "cmbBUHIN"
        Me.cmbBUHIN.Size = New System.Drawing.Size(186, 20)
        Me.cmbBUHIN.TabIndex = 62
        '
        'C1SplitContainer1
        '
        Me.C1SplitContainer1.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.C1SplitContainer1.AutoSizeElement = C1.Framework.AutoSizeElement.Both
        Me.C1SplitContainer1.BackColor = System.Drawing.Color.FromArgb(CType(CType(240, Byte), Integer), CType(CType(240, Byte), Integer), CType(CType(240, Byte), Integer))
        Me.C1SplitContainer1.BorderColor = System.Drawing.Color.Black
        Me.C1SplitContainer1.CollapsingCueColor = System.Drawing.Color.FromArgb(CType(CType(133, Byte), Integer), CType(CType(133, Byte), Integer), CType(CType(150, Byte), Integer))
        Me.C1SplitContainer1.EnlargeCollapsingHandle = True
        Me.C1SplitContainer1.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.C1SplitContainer1.HeaderHeight = 16
        Me.C1SplitContainer1.Location = New System.Drawing.Point(10, 49)
        Me.C1SplitContainer1.Margin = New System.Windows.Forms.Padding(2)
        Me.C1SplitContainer1.Name = "C1SplitContainer1"
        Me.C1SplitContainer1.Panels.Add(Me.C1SplitterPanel1)
        Me.C1SplitContainer1.Panels.Add(Me.C1SplitterPanel2)
        Me.C1SplitContainer1.Size = New System.Drawing.Size(1241, 558)
        Me.C1SplitContainer1.SplitterWidth = 3
        Me.C1SplitContainer1.TabIndex = 63
        '
        'C1SplitterPanel1
        '
        Me.C1SplitterPanel1.Collapsible = True
        Me.C1SplitterPanel1.Controls.Add(Me.gbxFilter)
        Me.C1SplitterPanel1.Height = 55
        Me.C1SplitterPanel1.KeepRelativeSize = False
        Me.C1SplitterPanel1.Location = New System.Drawing.Point(0, 0)
        Me.C1SplitterPanel1.MinHeight = 29
        Me.C1SplitterPanel1.MinWidth = 29
        Me.C1SplitterPanel1.Name = "C1SplitterPanel1"
        Me.C1SplitterPanel1.Resizable = False
        Me.C1SplitterPanel1.Size = New System.Drawing.Size(1241, 44)
        Me.C1SplitterPanel1.SizeRatio = 9.874R
        Me.C1SplitterPanel1.TabIndex = 0
        Me.C1SplitterPanel1.Width = 1241
        '
        'C1SplitterPanel2
        '
        Me.C1SplitterPanel2.Controls.Add(Me.C1SplitContainer2)
        Me.C1SplitterPanel2.Height = 502
        Me.C1SplitterPanel2.Location = New System.Drawing.Point(0, 56)
        Me.C1SplitterPanel2.MinHeight = 29
        Me.C1SplitterPanel2.MinWidth = 29
        Me.C1SplitterPanel2.Name = "C1SplitterPanel2"
        Me.C1SplitterPanel2.Size = New System.Drawing.Size(1241, 502)
        Me.C1SplitterPanel2.TabIndex = 1
        Me.C1SplitterPanel2.Width = 1241
        '
        'C1SplitContainer2
        '
        Me.C1SplitContainer2.AutoSizeElement = C1.Framework.AutoSizeElement.Both
        Me.C1SplitContainer2.BorderColor = System.Drawing.Color.Black
        Me.C1SplitContainer2.CollapsingCueColor = System.Drawing.Color.FromArgb(CType(CType(133, Byte), Integer), CType(CType(133, Byte), Integer), CType(CType(150, Byte), Integer))
        Me.C1SplitContainer2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.C1SplitContainer2.EnlargeCollapsingHandle = True
        Me.C1SplitContainer2.HeaderHeight = 16
        Me.C1SplitContainer2.Location = New System.Drawing.Point(0, 0)
        Me.C1SplitContainer2.Margin = New System.Windows.Forms.Padding(2)
        Me.C1SplitContainer2.Name = "C1SplitContainer2"
        Me.C1SplitContainer2.Panels.Add(Me.sptPanel_dgvHINBAN)
        Me.C1SplitContainer2.Panels.Add(Me.sptPanel_FlexGrid)
        Me.C1SplitContainer2.Size = New System.Drawing.Size(1241, 502)
        Me.C1SplitContainer2.SplitterWidth = 1
        Me.C1SplitContainer2.TabIndex = 64
        '
        'sptPanel_dgvHINBAN
        '
        Me.sptPanel_dgvHINBAN.Collapsible = True
        Me.sptPanel_dgvHINBAN.Controls.Add(Me.TableLayoutPanel1)
        Me.sptPanel_dgvHINBAN.Dock = C1.Win.C1SplitContainer.PanelDockStyle.Left
        Me.sptPanel_dgvHINBAN.Height = 502
        Me.sptPanel_dgvHINBAN.KeepRelativeSize = False
        Me.sptPanel_dgvHINBAN.Location = New System.Drawing.Point(0, 0)
        Me.sptPanel_dgvHINBAN.MinHeight = 29
        Me.sptPanel_dgvHINBAN.MinWidth = 240
        Me.sptPanel_dgvHINBAN.Name = "sptPanel_dgvHINBAN"
        Me.sptPanel_dgvHINBAN.ResizeWhileDragging = True
        Me.sptPanel_dgvHINBAN.Size = New System.Drawing.Size(319, 502)
        Me.sptPanel_dgvHINBAN.SizeRatio = 26.895R
        Me.sptPanel_dgvHINBAN.TabIndex = 0
        Me.sptPanel_dgvHINBAN.Width = 330
        '
        'sptPanel_FlexGrid
        '
        Me.sptPanel_FlexGrid.Controls.Add(Me.fgdKEIKAKU)
        Me.sptPanel_FlexGrid.Height = 502
        Me.sptPanel_FlexGrid.Location = New System.Drawing.Point(331, 0)
        Me.sptPanel_FlexGrid.MinHeight = 29
        Me.sptPanel_FlexGrid.MinWidth = 29
        Me.sptPanel_FlexGrid.Name = "sptPanel_FlexGrid"
        Me.sptPanel_FlexGrid.Size = New System.Drawing.Size(910, 502)
        Me.sptPanel_FlexGrid.TabIndex = 1
        Me.sptPanel_FlexGrid.Width = 910
        '
        'FrmFMS_G010
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.ClientSize = New System.Drawing.Size(1264, 712)
        Me.Controls.Add(Me.C1SplitContainer1)
        Me.HelpButton = True
        Me.Margin = New System.Windows.Forms.Padding(4, 8, 4, 8)
        Me.Name = "FrmFMS_G010"
        Me.Text = ""
        Me.Controls.SetChildIndex(Me.cmdFunc2, 0)
        Me.Controls.SetChildIndex(Me.cmdFunc3, 0)
        Me.Controls.SetChildIndex(Me.cmdFunc4, 0)
        Me.Controls.SetChildIndex(Me.cmdFunc5, 0)
        Me.Controls.SetChildIndex(Me.cmdFunc6, 0)
        Me.Controls.SetChildIndex(Me.cmdFunc1, 0)
        Me.Controls.SetChildIndex(Me.lblTytle, 0)
        Me.Controls.SetChildIndex(Me.cmdFunc9, 0)
        Me.Controls.SetChildIndex(Me.cmdFunc8, 0)
        Me.Controls.SetChildIndex(Me.cmdFunc10, 0)
        Me.Controls.SetChildIndex(Me.cmdFunc7, 0)
        Me.Controls.SetChildIndex(Me.cmdFunc11, 0)
        Me.Controls.SetChildIndex(Me.cmdFunc12, 0)
        Me.Controls.SetChildIndex(Me.C1SplitContainer1, 0)
        Me.gbxFilter.ResumeLayout(False)
        Me.tlpFilter.ResumeLayout(False)
        Me.tlpFilter.PerformLayout()
        CType(Me.C1DataSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dgvDATA, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dgvMaintenance, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.fgdKEIKAKU, System.ComponentModel.ISupportInitialize).EndInit()
        Me.TableLayoutPanel1.ResumeLayout(False)
        Me.TableLayoutPanel1.PerformLayout()
        CType(Me.C1SplitContainer1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.C1SplitContainer1.ResumeLayout(False)
        Me.C1SplitterPanel1.ResumeLayout(False)
        Me.C1SplitterPanel2.ResumeLayout(False)
        CType(Me.C1SplitContainer2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.C1SplitContainer2.ResumeLayout(False)
        Me.sptPanel_dgvHINBAN.ResumeLayout(False)
        Me.sptPanel_FlexGrid.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents SaveFileDialog As System.Windows.Forms.SaveFileDialog
    Friend WithEvents OpenFileDialog As System.Windows.Forms.OpenFileDialog
    Friend WithEvents Label3 As Label
    Friend WithEvents cmbMonthRange As ComboboxEx
    Friend WithEvents gbxFilter As GroupBox
    Friend WithEvents tlpFilter As TableLayoutPanel
    Friend WithEvents Label1 As Label
    Friend WithEvents dtYM As DateTextBoxEx
    Friend WithEvents dgvDATA As DataGridView
    Friend WithEvents TableLayoutPanel1 As TableLayoutPanel
    Friend WithEvents dgvMaintenance As DataGridView
    Friend WithEvents Label2 As Label
    Friend WithEvents Label4 As Label
    Friend WithEvents cmbFilter As ComboboxEx
    Friend WithEvents cmbBUHIN As ComboboxEx
    Friend WithEvents Label5 As Label
    Friend WithEvents cmbKOTEI As ComboboxEx
    Friend WithEvents Button1 As Button
    Friend WithEvents C1SplitContainer1 As C1.Win.C1SplitContainer.C1SplitContainer
    Friend WithEvents C1SplitterPanel1 As C1.Win.C1SplitContainer.C1SplitterPanel
    Friend WithEvents C1SplitterPanel2 As C1.Win.C1SplitContainer.C1SplitterPanel
    Friend WithEvents C1SplitContainer2 As C1.Win.C1SplitContainer.C1SplitContainer
    Friend WithEvents sptPanel_dgvHINBAN As C1.Win.C1SplitContainer.C1SplitterPanel
    Friend WithEvents sptPanel_FlexGrid As C1.Win.C1SplitContainer.C1SplitterPanel
    Friend WithEvents fgdKEIKAKU As C1.Win.C1FlexGrid.C1FlexGrid
    Friend WithEvents C1DataSource As C1.Win.Data.Entities.C1DataSource
End Class
