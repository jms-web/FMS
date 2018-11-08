<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class FrmM0110
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
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmM0110))
        Me.SaveFileDialog = New System.Windows.Forms.SaveFileDialog()
        Me.OpenFileDialog = New System.Windows.Forms.OpenFileDialog()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.cmbGYOMU_GROUP = New JMS_COMMON.ComboboxEx()
        Me.gbxFilter = New System.Windows.Forms.GroupBox()
        Me.tlpFilter = New System.Windows.Forms.TableLayoutPanel()
        Me.flxDATA = New C1.Win.C1FlexGrid.C1FlexGrid()
        Me.VWM011SYAINGYOMUBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.TableLayoutPanel1 = New System.Windows.Forms.TableLayoutPanel()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.mtxSIMEI = New JMS_COMMON.MaskedTextBoxEx()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.cmbYAKUSYOKU_KB = New JMS_COMMON.ComboboxEx()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.cmbSYAIN_KB = New JMS_COMMON.ComboboxEx()
        Me.mtxSIMEI_KANA = New JMS_COMMON.MaskedTextBoxEx()
        Me.flxDATA_SYAIN = New C1.Win.C1FlexGrid.C1FlexGrid()
        Me.VWM004SYAINBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        CType(Me.ErrorProvider, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.gbxFilter.SuspendLayout()
        Me.tlpFilter.SuspendLayout()
        CType(Me.flxDATA, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.VWM011SYAINGYOMUBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.TableLayoutPanel1.SuspendLayout()
        CType(Me.flxDATA_SYAIN, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.VWM004SYAINBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox1.SuspendLayout()
        Me.SuspendLayout()
        '
        'lblRecordCount
        '
        Me.lblRecordCount.ForeColor = System.Drawing.SystemColors.ControlText
        Me.lblRecordCount.Location = New System.Drawing.Point(12, 565)
        '
        'cmdFunc1
        '
        Me.cmdFunc1.Image = Global.FMS.My.Resources.Resources._imgSearch32x32
        Me.cmdFunc1.Location = New System.Drawing.Point(1126, 162)
        Me.cmdFunc1.Size = New System.Drawing.Size(122, 42)
        Me.cmdFunc1.Text = "検索(F1)"
        '
        'cmdFunc2
        '
        Me.cmdFunc2.Location = New System.Drawing.Point(216, 595)
        Me.cmdFunc2.Visible = False
        '
        'cmdFunc3
        '
        Me.cmdFunc3.Image = Global.FMS.My.Resources.Resources._imgApplication_form_add32x32
        Me.cmdFunc3.Location = New System.Drawing.Point(606, 318)
        Me.cmdFunc3.Size = New System.Drawing.Size(178, 42)
        Me.cmdFunc3.Text = "←追加(F3)"
        '
        'cmdFunc4
        '
        Me.cmdFunc4.Location = New System.Drawing.Point(627, 595)
        '
        'cmdFunc5
        '
        Me.cmdFunc5.Image = Global.FMS.My.Resources.Resources._imgStatusAnnotations_Blocked_32x32_MD
        Me.cmdFunc5.Location = New System.Drawing.Point(606, 382)
        Me.cmdFunc5.Size = New System.Drawing.Size(178, 42)
        Me.cmdFunc5.Text = "選択削除(F5)"
        '
        'cmdFunc6
        '
        Me.cmdFunc6.Location = New System.Drawing.Point(1044, 595)
        '
        'cmdFunc12
        '
        Me.cmdFunc12.Image = Global.FMS.My.Resources.Resources._imgLog_Out32x32
        Me.cmdFunc12.Location = New System.Drawing.Point(1044, 643)
        Me.cmdFunc12.Text = "閉じる(F12)"
        '
        'cmdFunc11
        '
        Me.cmdFunc11.Location = New System.Drawing.Point(837, 643)
        '
        'cmdFunc10
        '
        Me.cmdFunc10.Image = Global.FMS.My.Resources.Resources._imgExportToExcel32x32
        Me.cmdFunc10.Location = New System.Drawing.Point(630, 643)
        Me.cmdFunc10.Text = "CSV出力(F10)"
        '
        'cmdFunc7
        '
        Me.cmdFunc7.Location = New System.Drawing.Point(9, 643)
        '
        'cmdFunc9
        '
        Me.cmdFunc9.Image = Global.FMS.My.Resources.Resources._imgPreview32x32
        Me.cmdFunc9.Location = New System.Drawing.Point(423, 643)
        Me.cmdFunc9.Text = "社員業務一覧(F9)"
        '
        'cmdFunc8
        '
        Me.cmdFunc8.Location = New System.Drawing.Point(216, 643)
        '
        'lblTytle
        '
        Me.lblTytle.Font = New System.Drawing.Font("Meiryo UI", 24.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTytle.ForeColor = System.Drawing.SystemColors.ControlText
        Me.lblTytle.Text = "社員業務グループマスタ"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Label3.Font = New System.Drawing.Font("Meiryo UI", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label3.Location = New System.Drawing.Point(3, 0)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(94, 35)
        Me.Label3.TabIndex = 54
        Me.Label3.Text = "業務グループ*"
        Me.Label3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'cmbGYOMU_GROUP
        '
        Me.cmbGYOMU_GROUP.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cmbGYOMU_GROUP.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cmbGYOMU_GROUP.BackColor = System.Drawing.SystemColors.Window
        Me.cmbGYOMU_GROUP.Cursor = System.Windows.Forms.Cursors.Default
        Me.cmbGYOMU_GROUP.DisplayMember = "DISP"
        Me.cmbGYOMU_GROUP.Dock = System.Windows.Forms.DockStyle.Fill
        Me.cmbGYOMU_GROUP.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbGYOMU_GROUP.Font = New System.Drawing.Font("Meiryo UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.cmbGYOMU_GROUP.ForeColor = System.Drawing.SystemColors.ControlText
        Me.cmbGYOMU_GROUP.FormattingEnabled = True
        Me.cmbGYOMU_GROUP.HorizontalContentAlignment = System.Drawing.StringAlignment.Near
        Me.cmbGYOMU_GROUP.ImeMode = System.Windows.Forms.ImeMode.Disable
        Me.cmbGYOMU_GROUP.IsSelected = False
        Me.cmbGYOMU_GROUP.Location = New System.Drawing.Point(103, 3)
        Me.cmbGYOMU_GROUP.Name = "cmbGYOMU_GROUP"
        Me.cmbGYOMU_GROUP.NullValue = " "
        Me.cmbGYOMU_GROUP.SelectAllText = False
        Me.cmbGYOMU_GROUP.Size = New System.Drawing.Size(163, 25)
        Me.cmbGYOMU_GROUP.TabIndex = 0
        Me.cmbGYOMU_GROUP.ValueMember = "VALUE"
        '
        'gbxFilter
        '
        Me.gbxFilter.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.gbxFilter.Controls.Add(Me.tlpFilter)
        Me.gbxFilter.Font = New System.Drawing.Font("Meiryo UI", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.gbxFilter.Location = New System.Drawing.Point(14, 60)
        Me.gbxFilter.Name = "gbxFilter"
        Me.gbxFilter.Size = New System.Drawing.Size(523, 61)
        Me.gbxFilter.TabIndex = 59
        Me.gbxFilter.TabStop = False
        Me.gbxFilter.Text = "業務グループ社員　検索条件"
        '
        'tlpFilter
        '
        Me.tlpFilter.ColumnCount = 4
        Me.tlpFilter.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 100.0!))
        Me.tlpFilter.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 169.0!))
        Me.tlpFilter.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.tlpFilter.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 84.0!))
        Me.tlpFilter.Controls.Add(Me.Label3, 0, 0)
        Me.tlpFilter.Controls.Add(Me.cmbGYOMU_GROUP, 1, 0)
        Me.tlpFilter.Location = New System.Drawing.Point(3, 20)
        Me.tlpFilter.Name = "tlpFilter"
        Me.tlpFilter.RowCount = 1
        Me.tlpFilter.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 35.0!))
        Me.tlpFilter.Size = New System.Drawing.Size(460, 35)
        Me.tlpFilter.TabIndex = 56
        '
        'flxDATA
        '
        Me.flxDATA.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.flxDATA.ColumnInfo = resources.GetString("flxDATA.ColumnInfo")
        Me.flxDATA.DataSource = Me.VWM011SYAINGYOMUBindingSource
        Me.flxDATA.Font = New System.Drawing.Font("Meiryo UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.flxDATA.Location = New System.Drawing.Point(14, 127)
        Me.flxDATA.Name = "flxDATA"
        Me.flxDATA.Rows.Count = 1
        Me.flxDATA.Rows.DefaultSize = 23
        Me.flxDATA.Size = New System.Drawing.Size(573, 424)
        Me.flxDATA.StyleInfo = resources.GetString("flxDATA.StyleInfo")
        Me.flxDATA.TabIndex = 60
        Me.flxDATA.VisualStyle = C1.Win.C1FlexGrid.VisualStyle.Office2010Silver
        '
        'VWM011SYAINGYOMUBindingSource
        '
        Me.VWM011SYAINGYOMUBindingSource.DataSource = GetType(MODEL.VWM011_SYAIN_GYOMU)
        '
        'TableLayoutPanel1
        '
        Me.TableLayoutPanel1.ColumnCount = 4
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 67.0!))
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 115.0!))
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 92.0!))
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel1.Controls.Add(Me.Label4, 0, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.mtxSIMEI, 1, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.Label8, 2, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.cmbYAKUSYOKU_KB, 3, 1)
        Me.TableLayoutPanel1.Controls.Add(Me.Label5, 2, 1)
        Me.TableLayoutPanel1.Controls.Add(Me.Label7, 0, 1)
        Me.TableLayoutPanel1.Controls.Add(Me.cmbSYAIN_KB, 1, 1)
        Me.TableLayoutPanel1.Controls.Add(Me.mtxSIMEI_KANA, 3, 0)
        Me.TableLayoutPanel1.Location = New System.Drawing.Point(6, 23)
        Me.TableLayoutPanel1.Name = "TableLayoutPanel1"
        Me.TableLayoutPanel1.RowCount = 2
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel1.Size = New System.Drawing.Size(431, 61)
        Me.TableLayoutPanel1.TabIndex = 73
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Label4.Font = New System.Drawing.Font("Meiryo UI", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label4.Location = New System.Drawing.Point(3, 0)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(61, 30)
        Me.Label4.TabIndex = 54
        Me.Label4.Text = "担当者名"
        Me.Label4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'mtxSIMEI
        '
        Me.mtxSIMEI.BackColor = System.Drawing.SystemColors.Window
        Me.mtxSIMEI.Font = New System.Drawing.Font("Meiryo UI", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.mtxSIMEI.GotFocusedColor = System.Drawing.Color.FromArgb(CType(CType(190, Byte), Integer), CType(CType(180, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.mtxSIMEI.ImeMode = System.Windows.Forms.ImeMode.[On]
        Me.mtxSIMEI.InputRequired = False
        Me.mtxSIMEI.Location = New System.Drawing.Point(70, 3)
        Me.mtxSIMEI.MaxByteLength = 100
        Me.mtxSIMEI.Name = "mtxSIMEI"
        Me.mtxSIMEI.SelectAllText = False
        Me.mtxSIMEI.Size = New System.Drawing.Size(109, 24)
        Me.mtxSIMEI.TabIndex = 0
        Me.mtxSIMEI.WatermarkColor = System.Drawing.Color.Empty
        Me.mtxSIMEI.WatermarkText = Nothing
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Label8.Font = New System.Drawing.Font("Meiryo UI", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label8.Location = New System.Drawing.Point(185, 0)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(86, 30)
        Me.Label8.TabIndex = 57
        Me.Label8.Text = "担当者名カナ"
        Me.Label8.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'cmbYAKUSYOKU_KB
        '
        Me.cmbYAKUSYOKU_KB.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cmbYAKUSYOKU_KB.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cmbYAKUSYOKU_KB.BackColor = System.Drawing.SystemColors.Window
        Me.cmbYAKUSYOKU_KB.Cursor = System.Windows.Forms.Cursors.Default
        Me.cmbYAKUSYOKU_KB.DisplayMember = "DISP"
        Me.cmbYAKUSYOKU_KB.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbYAKUSYOKU_KB.Font = New System.Drawing.Font("Meiryo UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.cmbYAKUSYOKU_KB.ForeColor = System.Drawing.SystemColors.ControlText
        Me.cmbYAKUSYOKU_KB.FormattingEnabled = True
        Me.cmbYAKUSYOKU_KB.HorizontalContentAlignment = System.Drawing.StringAlignment.Near
        Me.cmbYAKUSYOKU_KB.ImeMode = System.Windows.Forms.ImeMode.Disable
        Me.cmbYAKUSYOKU_KB.IsSelected = False
        Me.cmbYAKUSYOKU_KB.Location = New System.Drawing.Point(277, 33)
        Me.cmbYAKUSYOKU_KB.Name = "cmbYAKUSYOKU_KB"
        Me.cmbYAKUSYOKU_KB.NullValue = " "
        Me.cmbYAKUSYOKU_KB.SelectAllText = False
        Me.cmbYAKUSYOKU_KB.Size = New System.Drawing.Size(137, 25)
        Me.cmbYAKUSYOKU_KB.TabIndex = 63
        Me.cmbYAKUSYOKU_KB.ValueMember = "VALUE"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Label5.Font = New System.Drawing.Font("Meiryo UI", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label5.Location = New System.Drawing.Point(185, 30)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(86, 31)
        Me.Label5.TabIndex = 62
        Me.Label5.Text = "役職区分"
        Me.Label5.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Label7.Font = New System.Drawing.Font("Meiryo UI", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label7.Location = New System.Drawing.Point(3, 30)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(61, 31)
        Me.Label7.TabIndex = 60
        Me.Label7.Text = "社員区分"
        Me.Label7.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'cmbSYAIN_KB
        '
        Me.cmbSYAIN_KB.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cmbSYAIN_KB.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cmbSYAIN_KB.BackColor = System.Drawing.SystemColors.Window
        Me.cmbSYAIN_KB.Cursor = System.Windows.Forms.Cursors.Default
        Me.cmbSYAIN_KB.DisplayMember = "DISP"
        Me.cmbSYAIN_KB.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbSYAIN_KB.Font = New System.Drawing.Font("Meiryo UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.cmbSYAIN_KB.ForeColor = System.Drawing.SystemColors.ControlText
        Me.cmbSYAIN_KB.FormattingEnabled = True
        Me.cmbSYAIN_KB.HorizontalContentAlignment = System.Drawing.StringAlignment.Near
        Me.cmbSYAIN_KB.ImeMode = System.Windows.Forms.ImeMode.Disable
        Me.cmbSYAIN_KB.IsSelected = False
        Me.cmbSYAIN_KB.Location = New System.Drawing.Point(70, 33)
        Me.cmbSYAIN_KB.Name = "cmbSYAIN_KB"
        Me.cmbSYAIN_KB.NullValue = " "
        Me.cmbSYAIN_KB.SelectAllText = False
        Me.cmbSYAIN_KB.Size = New System.Drawing.Size(109, 25)
        Me.cmbSYAIN_KB.TabIndex = 61
        Me.cmbSYAIN_KB.ValueMember = "VALUE"
        '
        'mtxSIMEI_KANA
        '
        Me.mtxSIMEI_KANA.BackColor = System.Drawing.SystemColors.Window
        Me.mtxSIMEI_KANA.Font = New System.Drawing.Font("Meiryo UI", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.mtxSIMEI_KANA.GotFocusedColor = System.Drawing.Color.FromArgb(CType(CType(190, Byte), Integer), CType(CType(180, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.mtxSIMEI_KANA.ImeMode = System.Windows.Forms.ImeMode.[On]
        Me.mtxSIMEI_KANA.InputRequired = False
        Me.mtxSIMEI_KANA.Location = New System.Drawing.Point(277, 3)
        Me.mtxSIMEI_KANA.MaxByteLength = 100
        Me.mtxSIMEI_KANA.Name = "mtxSIMEI_KANA"
        Me.mtxSIMEI_KANA.SelectAllText = False
        Me.mtxSIMEI_KANA.Size = New System.Drawing.Size(151, 24)
        Me.mtxSIMEI_KANA.TabIndex = 58
        Me.mtxSIMEI_KANA.WatermarkColor = System.Drawing.Color.Empty
        Me.mtxSIMEI_KANA.WatermarkText = Nothing
        '
        'flxDATA_SYAIN
        '
        Me.flxDATA_SYAIN.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.flxDATA_SYAIN.ColumnInfo = resources.GetString("flxDATA_SYAIN.ColumnInfo")
        Me.flxDATA_SYAIN.DataSource = Me.VWM004SYAINBindingSource
        Me.flxDATA_SYAIN.Font = New System.Drawing.Font("Meiryo UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.flxDATA_SYAIN.Location = New System.Drawing.Point(795, 210)
        Me.flxDATA_SYAIN.Name = "flxDATA_SYAIN"
        Me.flxDATA_SYAIN.Rows.Count = 1
        Me.flxDATA_SYAIN.Rows.DefaultSize = 23
        Me.flxDATA_SYAIN.Size = New System.Drawing.Size(453, 341)
        Me.flxDATA_SYAIN.StyleInfo = resources.GetString("flxDATA_SYAIN.StyleInfo")
        Me.flxDATA_SYAIN.TabIndex = 74
        Me.flxDATA_SYAIN.VisualStyle = C1.Win.C1FlexGrid.VisualStyle.Office2010Silver
        '
        'VWM004SYAINBindingSource
        '
        Me.VWM004SYAINBindingSource.DataSource = GetType(MODEL.VWM004_SYAIN)
        '
        'GroupBox1
        '
        Me.GroupBox1.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GroupBox1.Controls.Add(Me.TableLayoutPanel1)
        Me.GroupBox1.Font = New System.Drawing.Font("Meiryo UI", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.GroupBox1.Location = New System.Drawing.Point(795, 60)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(453, 96)
        Me.GroupBox1.TabIndex = 75
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "社員一覧　検索条件"
        '
        'FrmM0110
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.ClientSize = New System.Drawing.Size(1264, 712)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.flxDATA_SYAIN)
        Me.Controls.Add(Me.flxDATA)
        Me.Controls.Add(Me.gbxFilter)
        Me.HelpButton = True
        Me.Name = "FrmM0110"
        Me.ShowStatusBar = True
        Me.Text = ""
        Me.Controls.SetChildIndex(Me.gbxFilter, 0)
        Me.Controls.SetChildIndex(Me.flxDATA, 0)
        Me.Controls.SetChildIndex(Me.lblRecordCount, 0)
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
        Me.Controls.SetChildIndex(Me.flxDATA_SYAIN, 0)
        Me.Controls.SetChildIndex(Me.GroupBox1, 0)
        CType(Me.ErrorProvider, System.ComponentModel.ISupportInitialize).EndInit()
        Me.gbxFilter.ResumeLayout(False)
        Me.tlpFilter.ResumeLayout(False)
        Me.tlpFilter.PerformLayout()
        CType(Me.flxDATA, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.VWM011SYAINGYOMUBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        Me.TableLayoutPanel1.ResumeLayout(False)
        Me.TableLayoutPanel1.PerformLayout()
        CType(Me.flxDATA_SYAIN, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.VWM004SYAINBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox1.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents SaveFileDialog As System.Windows.Forms.SaveFileDialog
    Friend WithEvents OpenFileDialog As System.Windows.Forms.OpenFileDialog
    Friend WithEvents Label3 As Label
    Friend WithEvents cmbGYOMU_GROUP As ComboboxEx
    Friend WithEvents gbxFilter As GroupBox
    Friend WithEvents tlpFilter As TableLayoutPanel
    Friend WithEvents flxDATA As C1.Win.C1FlexGrid.C1FlexGrid
    Friend WithEvents TableLayoutPanel1 As TableLayoutPanel
    Friend WithEvents Label4 As Label
    Friend WithEvents mtxSIMEI As MaskedTextBoxEx
    Friend WithEvents Label8 As Label
    Friend WithEvents cmbYAKUSYOKU_KB As ComboboxEx
    Friend WithEvents Label5 As Label
    Friend WithEvents Label7 As Label
    Friend WithEvents cmbSYAIN_KB As ComboboxEx
    Friend WithEvents mtxSIMEI_KANA As MaskedTextBoxEx
    Friend WithEvents flxDATA_SYAIN As C1.Win.C1FlexGrid.C1FlexGrid
    Friend WithEvents GroupBox1 As GroupBox
    Friend WithEvents VWM004SYAINBindingSource As BindingSource
    Friend WithEvents VWM011SYAINGYOMUBindingSource As BindingSource
End Class
