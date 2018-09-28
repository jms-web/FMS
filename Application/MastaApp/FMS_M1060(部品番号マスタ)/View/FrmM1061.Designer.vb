<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class FrmM1061
    Inherits JMS_COMMON.frmBaseBtn

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
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.TableLayoutPanel1 = New System.Windows.Forms.TableLayoutPanel()
        Me.lblEDIT_YMDHNS = New System.Windows.Forms.Label()
        Me.lblEDIT_SYAIN_ID = New System.Windows.Forms.Label()
        Me.lbllblEDIT_YMDHNS = New System.Windows.Forms.Label()
        Me.lbllblEDIT_SYAIN_ID = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.mtxBUHIN_BANGO = New JMS_COMMON.MaskedTextBoxEx()
        Me.cmbTOKUI_ID = New JMS_COMMON.ComboboxEx()
        Me.mtxBUHIN_NAME = New JMS_COMMON.MaskedTextBoxEx()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.mtxSYANAI_CD = New JMS_COMMON.MaskedTextBoxEx()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.cmbBUMON_KB = New JMS_COMMON.ComboboxEx()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.cmbKEIYAKU_KB = New JMS_COMMON.ComboboxEx()
        Me.cmbRIKUKAIKU_KB = New JMS_COMMON.ComboboxEx()
        Me.mtxTANKA = New JMS_COMMON.MaskedTextBoxEx()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.chkTachiai = New System.Windows.Forms.CheckBox()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.lblSELECTED_COLOR = New System.Windows.Forms.Label()
        Me.btnCOLOR_SELECT = New System.Windows.Forms.Button()
        Me.mtxZUBAN_C = New JMS_COMMON.MaskedTextBoxEx()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.mtxHINSYU_BANGO = New JMS_COMMON.MaskedTextBoxEx()
        Me.ColorDialog1 = New System.Windows.Forms.ColorDialog()
        CType(Me.ErrorProvider, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox1.SuspendLayout()
        Me.TableLayoutPanel1.SuspendLayout()
        Me.SuspendLayout()
        '
        'cmdFunc1
        '
        Me.cmdFunc1.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.cmdFunc1.Image = Global.FMS.My.Resources.Resources._imgBase_floppydisk32x32
        Me.cmdFunc1.Location = New System.Drawing.Point(12, 204)
        Me.cmdFunc1.Size = New System.Drawing.Size(156, 42)
        Me.cmdFunc1.TabIndex = 0
        Me.cmdFunc1.Text = "追加(F1)"
        '
        'cmdFunc2
        '
        Me.cmdFunc2.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.cmdFunc2.Location = New System.Drawing.Point(338, 213)
        Me.cmdFunc2.Size = New System.Drawing.Size(23, 33)
        Me.cmdFunc2.Visible = False
        '
        'cmdFunc3
        '
        Me.cmdFunc3.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.cmdFunc3.Location = New System.Drawing.Point(499, 213)
        Me.cmdFunc3.Size = New System.Drawing.Size(23, 33)
        Me.cmdFunc3.Visible = False
        '
        'cmdFunc4
        '
        Me.cmdFunc4.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.cmdFunc4.Location = New System.Drawing.Point(660, 213)
        Me.cmdFunc4.Size = New System.Drawing.Size(23, 33)
        Me.cmdFunc4.Visible = False
        '
        'cmdFunc5
        '
        Me.cmdFunc5.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.cmdFunc5.Location = New System.Drawing.Point(821, 213)
        Me.cmdFunc5.Size = New System.Drawing.Size(23, 33)
        Me.cmdFunc5.Visible = False
        '
        'cmdFunc6
        '
        Me.cmdFunc6.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.cmdFunc6.Location = New System.Drawing.Point(982, 213)
        Me.cmdFunc6.Size = New System.Drawing.Size(23, 33)
        Me.cmdFunc6.Visible = False
        '
        'cmdFunc12
        '
        Me.cmdFunc12.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.cmdFunc12.Image = Global.FMS.My.Resources.Resources._imgLog_Out32x32
        Me.cmdFunc12.Location = New System.Drawing.Point(1096, 204)
        Me.cmdFunc12.Size = New System.Drawing.Size(156, 42)
        Me.cmdFunc12.TabIndex = 1
        Me.cmdFunc12.Text = "キャンセル(F12)"
        '
        'cmdFunc11
        '
        Me.cmdFunc11.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.cmdFunc11.Location = New System.Drawing.Point(821, 213)
        Me.cmdFunc11.Size = New System.Drawing.Size(23, 33)
        Me.cmdFunc11.Visible = False
        '
        'cmdFunc10
        '
        Me.cmdFunc10.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.cmdFunc10.Location = New System.Drawing.Point(660, 213)
        Me.cmdFunc10.Size = New System.Drawing.Size(23, 33)
        Me.cmdFunc10.Visible = False
        '
        'cmdFunc7
        '
        Me.cmdFunc7.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.cmdFunc7.Location = New System.Drawing.Point(177, 213)
        Me.cmdFunc7.Size = New System.Drawing.Size(23, 33)
        Me.cmdFunc7.Visible = False
        '
        'cmdFunc9
        '
        Me.cmdFunc9.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.cmdFunc9.Location = New System.Drawing.Point(499, 213)
        Me.cmdFunc9.Size = New System.Drawing.Size(23, 33)
        Me.cmdFunc9.Visible = False
        '
        'cmdFunc8
        '
        Me.cmdFunc8.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.cmdFunc8.Location = New System.Drawing.Point(338, 213)
        Me.cmdFunc8.Size = New System.Drawing.Size(23, 33)
        Me.cmdFunc8.Visible = False
        '
        'lblTytle
        '
        Me.lblTytle.Size = New System.Drawing.Size(1240, 45)
        Me.lblTytle.Text = "追加/変更"
        '
        'ToolTip
        '
        Me.ToolTip.InitialDelay = 700
        '
        'ErrorProvider
        '
        Me.ErrorProvider.BlinkStyle = System.Windows.Forms.ErrorBlinkStyle.NeverBlink
        '
        'GroupBox1
        '
        Me.GroupBox1.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GroupBox1.Controls.Add(Me.TableLayoutPanel1)
        Me.GroupBox1.Font = New System.Drawing.Font("ＭＳ ゴシック", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.GroupBox1.Location = New System.Drawing.Point(12, 60)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(1240, 138)
        Me.GroupBox1.TabIndex = 31
        Me.GroupBox1.TabStop = False
        '
        'TableLayoutPanel1
        '
        Me.TableLayoutPanel1.ColumnCount = 8
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 100.0!))
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 191.0!))
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 88.0!))
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 249.0!))
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 83.0!))
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 117.0!))
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 210.0!))
        Me.TableLayoutPanel1.Controls.Add(Me.lblEDIT_YMDHNS, 7, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.lblEDIT_SYAIN_ID, 7, 1)
        Me.TableLayoutPanel1.Controls.Add(Me.lbllblEDIT_YMDHNS, 6, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.lbllblEDIT_SYAIN_ID, 6, 1)
        Me.TableLayoutPanel1.Controls.Add(Me.Label6, 0, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.Label1, 2, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.Label3, 0, 1)
        Me.TableLayoutPanel1.Controls.Add(Me.Label4, 2, 1)
        Me.TableLayoutPanel1.Controls.Add(Me.mtxBUHIN_BANGO, 1, 1)
        Me.TableLayoutPanel1.Controls.Add(Me.cmbTOKUI_ID, 3, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.mtxBUHIN_NAME, 3, 1)
        Me.TableLayoutPanel1.Controls.Add(Me.Label7, 4, 1)
        Me.TableLayoutPanel1.Controls.Add(Me.mtxSYANAI_CD, 5, 1)
        Me.TableLayoutPanel1.Controls.Add(Me.Label2, 0, 2)
        Me.TableLayoutPanel1.Controls.Add(Me.Label8, 2, 2)
        Me.TableLayoutPanel1.Controls.Add(Me.cmbBUMON_KB, 1, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.Label5, 4, 2)
        Me.TableLayoutPanel1.Controls.Add(Me.cmbKEIYAKU_KB, 1, 2)
        Me.TableLayoutPanel1.Controls.Add(Me.cmbRIKUKAIKU_KB, 3, 2)
        Me.TableLayoutPanel1.Controls.Add(Me.mtxTANKA, 1, 3)
        Me.TableLayoutPanel1.Controls.Add(Me.Label9, 0, 3)
        Me.TableLayoutPanel1.Controls.Add(Me.chkTachiai, 3, 3)
        Me.TableLayoutPanel1.Controls.Add(Me.Label10, 4, 3)
        Me.TableLayoutPanel1.Controls.Add(Me.lblSELECTED_COLOR, 6, 3)
        Me.TableLayoutPanel1.Controls.Add(Me.btnCOLOR_SELECT, 5, 3)
        Me.TableLayoutPanel1.Controls.Add(Me.mtxZUBAN_C, 5, 2)
        Me.TableLayoutPanel1.Controls.Add(Me.Label11, 6, 2)
        Me.TableLayoutPanel1.Controls.Add(Me.mtxHINSYU_BANGO, 7, 2)
        Me.TableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TableLayoutPanel1.Font = New System.Drawing.Font("Meiryo UI", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.TableLayoutPanel1.Location = New System.Drawing.Point(3, 18)
        Me.TableLayoutPanel1.Name = "TableLayoutPanel1"
        Me.TableLayoutPanel1.RowCount = 4
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 26.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 29.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20.0!))
        Me.TableLayoutPanel1.Size = New System.Drawing.Size(1234, 117)
        Me.TableLayoutPanel1.TabIndex = 47
        '
        'lblEDIT_YMDHNS
        '
        Me.lblEDIT_YMDHNS.BackColor = System.Drawing.Color.Transparent
        Me.lblEDIT_YMDHNS.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblEDIT_YMDHNS.Dock = System.Windows.Forms.DockStyle.Fill
        Me.lblEDIT_YMDHNS.Enabled = False
        Me.lblEDIT_YMDHNS.Font = New System.Drawing.Font("Meiryo UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.lblEDIT_YMDHNS.Location = New System.Drawing.Point(1027, 0)
        Me.lblEDIT_YMDHNS.Name = "lblEDIT_YMDHNS"
        Me.lblEDIT_YMDHNS.Size = New System.Drawing.Size(204, 30)
        Me.lblEDIT_YMDHNS.TabIndex = 43
        Me.lblEDIT_YMDHNS.Text = "yyyy/MM/dd HH:mm:ss"
        Me.lblEDIT_YMDHNS.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.lblEDIT_YMDHNS.Visible = False
        '
        'lblEDIT_SYAIN_ID
        '
        Me.lblEDIT_SYAIN_ID.BackColor = System.Drawing.Color.Transparent
        Me.lblEDIT_SYAIN_ID.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblEDIT_SYAIN_ID.Dock = System.Windows.Forms.DockStyle.Fill
        Me.lblEDIT_SYAIN_ID.Enabled = False
        Me.lblEDIT_SYAIN_ID.Font = New System.Drawing.Font("Meiryo UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.lblEDIT_SYAIN_ID.Location = New System.Drawing.Point(1027, 30)
        Me.lblEDIT_SYAIN_ID.Name = "lblEDIT_SYAIN_ID"
        Me.lblEDIT_SYAIN_ID.Size = New System.Drawing.Size(204, 30)
        Me.lblEDIT_SYAIN_ID.TabIndex = 66
        Me.lblEDIT_SYAIN_ID.Text = "xxx xxx"
        Me.lblEDIT_SYAIN_ID.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.lblEDIT_SYAIN_ID.Visible = False
        '
        'lbllblEDIT_YMDHNS
        '
        Me.lbllblEDIT_YMDHNS.Dock = System.Windows.Forms.DockStyle.Fill
        Me.lbllblEDIT_YMDHNS.Font = New System.Drawing.Font("Meiryo UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.lbllblEDIT_YMDHNS.Location = New System.Drawing.Point(910, 0)
        Me.lbllblEDIT_YMDHNS.Name = "lbllblEDIT_YMDHNS"
        Me.lbllblEDIT_YMDHNS.Size = New System.Drawing.Size(111, 30)
        Me.lbllblEDIT_YMDHNS.TabIndex = 56
        Me.lbllblEDIT_YMDHNS.Text = "最終更新日時:"
        Me.lbllblEDIT_YMDHNS.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'lbllblEDIT_SYAIN_ID
        '
        Me.lbllblEDIT_SYAIN_ID.Dock = System.Windows.Forms.DockStyle.Fill
        Me.lbllblEDIT_SYAIN_ID.Font = New System.Drawing.Font("Meiryo UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.lbllblEDIT_SYAIN_ID.Location = New System.Drawing.Point(910, 30)
        Me.lbllblEDIT_SYAIN_ID.Name = "lbllblEDIT_SYAIN_ID"
        Me.lbllblEDIT_SYAIN_ID.Size = New System.Drawing.Size(111, 30)
        Me.lbllblEDIT_SYAIN_ID.TabIndex = 65
        Me.lbllblEDIT_SYAIN_ID.Text = "最終更新者:"
        Me.lbllblEDIT_SYAIN_ID.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.lbllblEDIT_SYAIN_ID.Visible = False
        '
        'Label6
        '
        Me.Label6.Font = New System.Drawing.Font("Meiryo UI", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label6.Location = New System.Drawing.Point(3, 0)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(94, 30)
        Me.Label6.TabIndex = 39
        Me.Label6.Text = "部門区分*:"
        Me.Label6.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label1
        '
        Me.Label1.Font = New System.Drawing.Font("Meiryo UI", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label1.Location = New System.Drawing.Point(294, 0)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(82, 30)
        Me.Label1.TabIndex = 67
        Me.Label1.Text = "得意先*:"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label3
        '
        Me.Label3.Font = New System.Drawing.Font("Meiryo UI", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label3.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.Label3.Location = New System.Drawing.Point(3, 30)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(94, 30)
        Me.Label3.TabIndex = 69
        Me.Label3.Text = "部品番号*:"
        Me.Label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label4
        '
        Me.Label4.Font = New System.Drawing.Font("Meiryo UI", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label4.Location = New System.Drawing.Point(294, 30)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(82, 30)
        Me.Label4.TabIndex = 71
        Me.Label4.Text = "部品名:"
        Me.Label4.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'mtxBUHIN_BANGO
        '
        Me.mtxBUHIN_BANGO.BackColor = System.Drawing.SystemColors.Window
        Me.mtxBUHIN_BANGO.GotFocusedColor = System.Drawing.Color.FromArgb(CType(CType(190, Byte), Integer), CType(CType(180, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.mtxBUHIN_BANGO.ImeMode = System.Windows.Forms.ImeMode.Off
        Me.mtxBUHIN_BANGO.InputRequired = False
        Me.mtxBUHIN_BANGO.Location = New System.Drawing.Point(103, 33)
        Me.mtxBUHIN_BANGO.MaxByteLength = 60
        Me.mtxBUHIN_BANGO.Name = "mtxBUHIN_BANGO"
        Me.mtxBUHIN_BANGO.Size = New System.Drawing.Size(184, 23)
        Me.mtxBUHIN_BANGO.TabIndex = 70
        Me.mtxBUHIN_BANGO.WatermarkColor = System.Drawing.Color.Empty
        Me.mtxBUHIN_BANGO.WatermarkText = Nothing
        '
        'cmbTOKUI_ID
        '
        Me.cmbTOKUI_ID.BackColor = System.Drawing.SystemColors.Window
        Me.cmbTOKUI_ID.Cursor = System.Windows.Forms.Cursors.Default
        Me.cmbTOKUI_ID.DisplayMember = "DISP"
        Me.cmbTOKUI_ID.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbTOKUI_ID.FormattingEnabled = True
        Me.cmbTOKUI_ID.GotFocusedColor = System.Drawing.Color.Empty
        Me.cmbTOKUI_ID.ImeMode = System.Windows.Forms.ImeMode.Disable
        Me.cmbTOKUI_ID.Location = New System.Drawing.Point(382, 3)
        Me.cmbTOKUI_ID.Name = "cmbTOKUI_ID"
        Me.cmbTOKUI_ID.NullValue = " "
        Me.cmbTOKUI_ID.ReadOnly = False
        Me.cmbTOKUI_ID.IsSelected = False
        Me.cmbTOKUI_ID.Size = New System.Drawing.Size(243, 23)
        Me.cmbTOKUI_ID.TabIndex = 68
        Me.cmbTOKUI_ID.ValueMember = "VALUE"
        '
        'mtxBUHIN_NAME
        '
        Me.mtxBUHIN_NAME.BackColor = System.Drawing.SystemColors.Window
        Me.mtxBUHIN_NAME.GotFocusedColor = System.Drawing.Color.FromArgb(CType(CType(190, Byte), Integer), CType(CType(180, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.mtxBUHIN_NAME.ImeMode = System.Windows.Forms.ImeMode.[On]
        Me.mtxBUHIN_NAME.InputRequired = False
        Me.mtxBUHIN_NAME.Location = New System.Drawing.Point(382, 33)
        Me.mtxBUHIN_NAME.MaxByteLength = 80
        Me.mtxBUHIN_NAME.Name = "mtxBUHIN_NAME"
        Me.mtxBUHIN_NAME.Size = New System.Drawing.Size(243, 23)
        Me.mtxBUHIN_NAME.TabIndex = 72
        Me.mtxBUHIN_NAME.WatermarkColor = System.Drawing.Color.Empty
        Me.mtxBUHIN_NAME.WatermarkText = Nothing
        '
        'Label7
        '
        Me.Label7.Font = New System.Drawing.Font("Meiryo UI", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label7.Location = New System.Drawing.Point(631, 30)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(71, 30)
        Me.Label7.TabIndex = 73
        Me.Label7.Text = "社内コード:"
        Me.Label7.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'mtxSYANAI_CD
        '
        Me.mtxSYANAI_CD.BackColor = System.Drawing.SystemColors.Window
        Me.mtxSYANAI_CD.GotFocusedColor = System.Drawing.Color.FromArgb(CType(CType(190, Byte), Integer), CType(CType(180, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.mtxSYANAI_CD.ImeMode = System.Windows.Forms.ImeMode.Off
        Me.mtxSYANAI_CD.InputRequired = False
        Me.mtxSYANAI_CD.Location = New System.Drawing.Point(714, 33)
        Me.mtxSYANAI_CD.MaxByteLength = 10
        Me.mtxSYANAI_CD.Name = "mtxSYANAI_CD"
        Me.mtxSYANAI_CD.Size = New System.Drawing.Size(145, 23)
        Me.mtxSYANAI_CD.TabIndex = 74
        Me.mtxSYANAI_CD.WatermarkColor = System.Drawing.Color.Empty
        Me.mtxSYANAI_CD.WatermarkText = Nothing
        '
        'Label2
        '
        Me.Label2.Font = New System.Drawing.Font("Meiryo UI", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label2.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.Label2.Location = New System.Drawing.Point(3, 60)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(94, 26)
        Me.Label2.TabIndex = 45
        Me.Label2.Text = "契約区分:"
        Me.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label8
        '
        Me.Label8.Font = New System.Drawing.Font("Meiryo UI", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label8.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.Label8.Location = New System.Drawing.Point(294, 60)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(82, 26)
        Me.Label8.TabIndex = 75
        Me.Label8.Text = "陸海空区分:"
        Me.Label8.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'cmbBUMON_KB
        '
        Me.cmbBUMON_KB.BackColor = System.Drawing.SystemColors.Window
        Me.cmbBUMON_KB.Cursor = System.Windows.Forms.Cursors.Default
        Me.cmbBUMON_KB.DisplayMember = "DISP"
        Me.cmbBUMON_KB.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbBUMON_KB.FormattingEnabled = True
        Me.cmbBUMON_KB.GotFocusedColor = System.Drawing.Color.Empty
        Me.cmbBUMON_KB.ImeMode = System.Windows.Forms.ImeMode.Disable
        Me.cmbBUMON_KB.Location = New System.Drawing.Point(103, 3)
        Me.cmbBUMON_KB.Name = "cmbBUMON_KB"
        Me.cmbBUMON_KB.NullValue = " "
        Me.cmbBUMON_KB.ReadOnly = False
        Me.cmbBUMON_KB.IsSelected = False
        Me.cmbBUMON_KB.Size = New System.Drawing.Size(126, 23)
        Me.cmbBUMON_KB.TabIndex = 49
        Me.cmbBUMON_KB.ValueMember = "VALUE"
        '
        'Label5
        '
        Me.Label5.Font = New System.Drawing.Font("Meiryo UI", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label5.Location = New System.Drawing.Point(631, 60)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(77, 26)
        Me.Label5.TabIndex = 38
        Me.Label5.Text = "図番C:"
        Me.Label5.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'cmbKEIYAKU_KB
        '
        Me.cmbKEIYAKU_KB.BackColor = System.Drawing.SystemColors.Window
        Me.cmbKEIYAKU_KB.Cursor = System.Windows.Forms.Cursors.Default
        Me.cmbKEIYAKU_KB.DisplayMember = "DISP"
        Me.cmbKEIYAKU_KB.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbKEIYAKU_KB.FormattingEnabled = True
        Me.cmbKEIYAKU_KB.GotFocusedColor = System.Drawing.Color.Empty
        Me.cmbKEIYAKU_KB.ImeMode = System.Windows.Forms.ImeMode.Disable
        Me.cmbKEIYAKU_KB.Location = New System.Drawing.Point(103, 63)
        Me.cmbKEIYAKU_KB.Name = "cmbKEIYAKU_KB"
        Me.cmbKEIYAKU_KB.NullValue = " "
        Me.cmbKEIYAKU_KB.ReadOnly = False
        Me.cmbKEIYAKU_KB.IsSelected = False
        Me.cmbKEIYAKU_KB.Size = New System.Drawing.Size(126, 23)
        Me.cmbKEIYAKU_KB.TabIndex = 77
        Me.cmbKEIYAKU_KB.ValueMember = "VALUE"
        '
        'cmbRIKUKAIKU_KB
        '
        Me.cmbRIKUKAIKU_KB.BackColor = System.Drawing.SystemColors.Window
        Me.cmbRIKUKAIKU_KB.Cursor = System.Windows.Forms.Cursors.Default
        Me.cmbRIKUKAIKU_KB.DisplayMember = "DISP"
        Me.cmbRIKUKAIKU_KB.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbRIKUKAIKU_KB.FormattingEnabled = True
        Me.cmbRIKUKAIKU_KB.GotFocusedColor = System.Drawing.Color.Empty
        Me.cmbRIKUKAIKU_KB.ImeMode = System.Windows.Forms.ImeMode.Disable
        Me.cmbRIKUKAIKU_KB.Location = New System.Drawing.Point(382, 63)
        Me.cmbRIKUKAIKU_KB.Name = "cmbRIKUKAIKU_KB"
        Me.cmbRIKUKAIKU_KB.NullValue = " "
        Me.cmbRIKUKAIKU_KB.ReadOnly = False
        Me.cmbRIKUKAIKU_KB.IsSelected = False
        Me.cmbRIKUKAIKU_KB.Size = New System.Drawing.Size(102, 23)
        Me.cmbRIKUKAIKU_KB.TabIndex = 78
        Me.cmbRIKUKAIKU_KB.ValueMember = "VALUE"
        '
        'mtxTANKA
        '
        Me.mtxTANKA.BackColor = System.Drawing.SystemColors.Window
        Me.mtxTANKA.GotFocusedColor = System.Drawing.Color.FromArgb(CType(CType(190, Byte), Integer), CType(CType(180, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.mtxTANKA.ImeMode = System.Windows.Forms.ImeMode.Off
        Me.mtxTANKA.InputRequired = False
        Me.mtxTANKA.Location = New System.Drawing.Point(103, 89)
        Me.mtxTANKA.MaxByteLength = 60
        Me.mtxTANKA.Name = "mtxTANKA"
        Me.mtxTANKA.Size = New System.Drawing.Size(114, 23)
        Me.mtxTANKA.TabIndex = 51
        Me.mtxTANKA.WatermarkColor = System.Drawing.Color.Empty
        Me.mtxTANKA.WatermarkText = Nothing
        '
        'Label9
        '
        Me.Label9.Font = New System.Drawing.Font("Meiryo UI", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label9.Location = New System.Drawing.Point(3, 86)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(77, 26)
        Me.Label9.TabIndex = 79
        Me.Label9.Text = "単価*:"
        Me.Label9.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'chkTachiai
        '
        Me.chkTachiai.AutoSize = True
        Me.chkTachiai.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.chkTachiai.Cursor = System.Windows.Forms.Cursors.Hand
        Me.chkTachiai.Font = New System.Drawing.Font("Meiryo UI", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.chkTachiai.Location = New System.Drawing.Point(382, 89)
        Me.chkTachiai.Name = "chkTachiai"
        Me.chkTachiai.Size = New System.Drawing.Size(79, 21)
        Me.chkTachiai.TabIndex = 81
        Me.chkTachiai.Text = "立会検査"
        Me.chkTachiai.UseVisualStyleBackColor = True
        '
        'Label10
        '
        Me.Label10.Font = New System.Drawing.Font("Meiryo UI", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label10.Location = New System.Drawing.Point(631, 86)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(77, 26)
        Me.Label10.TabIndex = 82
        Me.Label10.Text = "色コード:"
        Me.Label10.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'lblSELECTED_COLOR
        '
        Me.lblSELECTED_COLOR.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblSELECTED_COLOR.AutoSize = True
        Me.lblSELECTED_COLOR.Font = New System.Drawing.Font("Meiryo UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.lblSELECTED_COLOR.Location = New System.Drawing.Point(910, 86)
        Me.lblSELECTED_COLOR.Name = "lblSELECTED_COLOR"
        Me.lblSELECTED_COLOR.Size = New System.Drawing.Size(111, 31)
        Me.lblSELECTED_COLOR.TabIndex = 84
        Me.lblSELECTED_COLOR.Text = "選択された色"
        Me.lblSELECTED_COLOR.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'btnCOLOR_SELECT
        '
        Me.btnCOLOR_SELECT.Location = New System.Drawing.Point(714, 89)
        Me.btnCOLOR_SELECT.Name = "btnCOLOR_SELECT"
        Me.btnCOLOR_SELECT.Size = New System.Drawing.Size(180, 23)
        Me.btnCOLOR_SELECT.TabIndex = 83
        Me.btnCOLOR_SELECT.Text = "色選択"
        Me.btnCOLOR_SELECT.UseVisualStyleBackColor = True
        '
        'mtxZUBAN_C
        '
        Me.mtxZUBAN_C.BackColor = System.Drawing.SystemColors.Window
        Me.mtxZUBAN_C.GotFocusedColor = System.Drawing.Color.FromArgb(CType(CType(190, Byte), Integer), CType(CType(180, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.mtxZUBAN_C.ImeMode = System.Windows.Forms.ImeMode.Off
        Me.mtxZUBAN_C.InputRequired = False
        Me.mtxZUBAN_C.Location = New System.Drawing.Point(714, 63)
        Me.mtxZUBAN_C.MaxByteLength = 20
        Me.mtxZUBAN_C.Name = "mtxZUBAN_C"
        Me.mtxZUBAN_C.Size = New System.Drawing.Size(145, 23)
        Me.mtxZUBAN_C.TabIndex = 85
        Me.mtxZUBAN_C.WatermarkColor = System.Drawing.Color.Empty
        Me.mtxZUBAN_C.WatermarkText = Nothing
        '
        'Label11
        '
        Me.Label11.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Label11.Font = New System.Drawing.Font("Meiryo UI", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label11.Location = New System.Drawing.Point(910, 60)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(111, 26)
        Me.Label11.TabIndex = 86
        Me.Label11.Text = "品種番号:"
        Me.Label11.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'mtxHINSYU_BANGO
        '
        Me.mtxHINSYU_BANGO.BackColor = System.Drawing.SystemColors.Window
        Me.mtxHINSYU_BANGO.GotFocusedColor = System.Drawing.Color.FromArgb(CType(CType(190, Byte), Integer), CType(CType(180, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.mtxHINSYU_BANGO.ImeMode = System.Windows.Forms.ImeMode.Off
        Me.mtxHINSYU_BANGO.InputRequired = False
        Me.mtxHINSYU_BANGO.Location = New System.Drawing.Point(1027, 63)
        Me.mtxHINSYU_BANGO.MaxByteLength = 20
        Me.mtxHINSYU_BANGO.Name = "mtxHINSYU_BANGO"
        Me.mtxHINSYU_BANGO.Size = New System.Drawing.Size(160, 23)
        Me.mtxHINSYU_BANGO.TabIndex = 87
        Me.mtxHINSYU_BANGO.WatermarkColor = System.Drawing.Color.Empty
        Me.mtxHINSYU_BANGO.WatermarkText = Nothing
        '
        'FrmM1061
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.BackColor = System.Drawing.SystemColors.Control
        Me.ClientSize = New System.Drawing.Size(1264, 712)
        Me.Controls.Add(Me.GroupBox1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.HelpButton = True
        Me.MinimumSize = New System.Drawing.Size(1280, 300)
        Me.Name = "FrmM1061"
        Me.ShowInTaskbar = False
        Me.Controls.SetChildIndex(Me.GroupBox1, 0)
        Me.Controls.SetChildIndex(Me.lblTytle, 0)
        Me.Controls.SetChildIndex(Me.cmdFunc8, 0)
        Me.Controls.SetChildIndex(Me.cmdFunc9, 0)
        Me.Controls.SetChildIndex(Me.cmdFunc7, 0)
        Me.Controls.SetChildIndex(Me.cmdFunc10, 0)
        Me.Controls.SetChildIndex(Me.cmdFunc11, 0)
        Me.Controls.SetChildIndex(Me.cmdFunc6, 0)
        Me.Controls.SetChildIndex(Me.cmdFunc5, 0)
        Me.Controls.SetChildIndex(Me.cmdFunc4, 0)
        Me.Controls.SetChildIndex(Me.cmdFunc3, 0)
        Me.Controls.SetChildIndex(Me.cmdFunc2, 0)
        Me.Controls.SetChildIndex(Me.cmdFunc1, 0)
        Me.Controls.SetChildIndex(Me.cmdFunc12, 0)
        CType(Me.ErrorProvider, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox1.ResumeLayout(False)
        Me.TableLayoutPanel1.ResumeLayout(False)
        Me.TableLayoutPanel1.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents lbllblEDIT_YMDHNS As Label
    Public WithEvents lblEDIT_SYAIN_ID As Label
    Friend WithEvents lbllblEDIT_SYAIN_ID As Label
    Public WithEvents lblEDIT_YMDHNS As Label
    Friend WithEvents TableLayoutPanel1 As TableLayoutPanel
    Friend WithEvents Label5 As Label
    Friend WithEvents Label6 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents cmbBUMON_KB As ComboboxEx
    Friend WithEvents mtxTANKA As MaskedTextBoxEx
    Friend WithEvents Label1 As Label
    Friend WithEvents Label3 As Label
    Friend WithEvents Label4 As Label
    Friend WithEvents mtxBUHIN_BANGO As MaskedTextBoxEx
    Friend WithEvents Label7 As Label
    Friend WithEvents mtxSYANAI_CD As MaskedTextBoxEx
    Friend WithEvents Label8 As Label
    Friend WithEvents cmbKEIYAKU_KB As ComboboxEx
    Friend WithEvents Label9 As Label
    Friend WithEvents Label10 As Label
    Friend WithEvents btnCOLOR_SELECT As Button
    Friend WithEvents lblSELECTED_COLOR As Label
    Friend WithEvents ColorDialog1 As ColorDialog
    Friend WithEvents cmbTOKUI_ID As ComboboxEx
    Friend WithEvents mtxBUHIN_NAME As MaskedTextBoxEx
    Friend WithEvents cmbRIKUKAIKU_KB As ComboboxEx
    Friend WithEvents chkTachiai As CheckBox
    Friend WithEvents mtxZUBAN_C As MaskedTextBoxEx
    Friend WithEvents Label11 As Label
    Friend WithEvents mtxHINSYU_BANGO As MaskedTextBoxEx
End Class
