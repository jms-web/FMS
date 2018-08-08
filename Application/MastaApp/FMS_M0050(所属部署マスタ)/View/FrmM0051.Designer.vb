<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class FrmM0051
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
        Me.tlpFields = New System.Windows.Forms.TableLayoutPanel()
        Me.lbllblEDIT_YMDHNS = New System.Windows.Forms.Label()
        Me.lbllblEDIT_SYAIN_ID = New System.Windows.Forms.Label()
        Me.lblEDIT_SYAIN_ID = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.chkDefaultVaue = New System.Windows.Forms.CheckBox()
        Me.lblEDIT_YMDHNS = New System.Windows.Forms.Label()
        Me.mtxBIKOU = New JMS_COMMON.MaskedTextBoxEx()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.cmbJYUN = New JMS_COMMON.ComboboxEx()
        Me.mtxDISP = New JMS_COMMON.MaskedTextBoxEx()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.mtxVALUE = New JMS_COMMON.MaskedTextBoxEx()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.cmbKOMO_NM = New JMS_COMMON.ComboboxEx()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.mtxKOMO_GROUP = New JMS_COMMON.MaskedTextBoxEx()
        CType(Me.ErrorProvider, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox1.SuspendLayout()
        Me.tlpFields.SuspendLayout()
        Me.SuspendLayout()
        '
        'cmdFunc1
        '
        Me.cmdFunc1.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.cmdFunc1.Image = Global.FMS.My.Resources.Resources._imgBase_floppydisk32x32
        Me.cmdFunc1.Location = New System.Drawing.Point(20, 265)
        Me.cmdFunc1.TabIndex = 0
        Me.cmdFunc1.Text = "追加(F1)"
        '
        'cmdFunc2
        '
        Me.cmdFunc2.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.cmdFunc2.Location = New System.Drawing.Point(223, 265)
        Me.cmdFunc2.Size = New System.Drawing.Size(20, 42)
        Me.cmdFunc2.Visible = False
        '
        'cmdFunc3
        '
        Me.cmdFunc3.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.cmdFunc3.Location = New System.Drawing.Point(426, 266)
        Me.cmdFunc3.Size = New System.Drawing.Size(20, 42)
        Me.cmdFunc3.Visible = False
        '
        'cmdFunc4
        '
        Me.cmdFunc4.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.cmdFunc4.Location = New System.Drawing.Point(629, 266)
        Me.cmdFunc4.Size = New System.Drawing.Size(20, 42)
        Me.cmdFunc4.Visible = False
        '
        'cmdFunc5
        '
        Me.cmdFunc5.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.cmdFunc5.Location = New System.Drawing.Point(832, 266)
        Me.cmdFunc5.Size = New System.Drawing.Size(20, 42)
        Me.cmdFunc5.Visible = False
        '
        'cmdFunc6
        '
        Me.cmdFunc6.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.cmdFunc6.Location = New System.Drawing.Point(894, 266)
        Me.cmdFunc6.Size = New System.Drawing.Size(120, 42)
        Me.cmdFunc6.TabIndex = 1
        Me.cmdFunc6.Visible = False
        '
        'cmdFunc12
        '
        Me.cmdFunc12.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.cmdFunc12.Image = Global.FMS.My.Resources.Resources._imgLog_Out32x32
        Me.cmdFunc12.Location = New System.Drawing.Point(1085, 265)
        Me.cmdFunc12.Text = "キャンセル(F12)"
        '
        'cmdFunc11
        '
        Me.cmdFunc11.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.cmdFunc11.Location = New System.Drawing.Point(832, 266)
        Me.cmdFunc11.Size = New System.Drawing.Size(20, 42)
        Me.cmdFunc11.Visible = False
        '
        'cmdFunc10
        '
        Me.cmdFunc10.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.cmdFunc10.Location = New System.Drawing.Point(629, 266)
        Me.cmdFunc10.Size = New System.Drawing.Size(20, 42)
        Me.cmdFunc10.Visible = False
        '
        'cmdFunc7
        '
        Me.cmdFunc7.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.cmdFunc7.Location = New System.Drawing.Point(249, 266)
        Me.cmdFunc7.Size = New System.Drawing.Size(18, 42)
        Me.cmdFunc7.Visible = False
        '
        'cmdFunc9
        '
        Me.cmdFunc9.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.cmdFunc9.Location = New System.Drawing.Point(426, 266)
        Me.cmdFunc9.Size = New System.Drawing.Size(20, 42)
        Me.cmdFunc9.Visible = False
        '
        'cmdFunc8
        '
        Me.cmdFunc8.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.cmdFunc8.Location = New System.Drawing.Point(223, 265)
        Me.cmdFunc8.Size = New System.Drawing.Size(20, 42)
        Me.cmdFunc8.Visible = False
        '
        'lblTytle
        '
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
        Me.GroupBox1.Controls.Add(Me.tlpFields)
        Me.GroupBox1.Font = New System.Drawing.Font("ＭＳ ゴシック", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.GroupBox1.Location = New System.Drawing.Point(13, 60)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(1238, 200)
        Me.GroupBox1.TabIndex = 31
        Me.GroupBox1.TabStop = False
        '
        'tlpFields
        '
        Me.tlpFields.ColumnCount = 5
        Me.tlpFields.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 90.0!))
        Me.tlpFields.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 550.0!))
        Me.tlpFields.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.tlpFields.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 100.0!))
        Me.tlpFields.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 180.0!))
        Me.tlpFields.Controls.Add(Me.lbllblEDIT_YMDHNS, 3, 0)
        Me.tlpFields.Controls.Add(Me.lbllblEDIT_SYAIN_ID, 3, 1)
        Me.tlpFields.Controls.Add(Me.lblEDIT_SYAIN_ID, 4, 1)
        Me.tlpFields.Controls.Add(Me.Label4, 0, 5)
        Me.tlpFields.Controls.Add(Me.chkDefaultVaue, 2, 5)
        Me.tlpFields.Controls.Add(Me.lblEDIT_YMDHNS, 4, 0)
        Me.tlpFields.Controls.Add(Me.mtxBIKOU, 1, 5)
        Me.tlpFields.Controls.Add(Me.Label1, 0, 4)
        Me.tlpFields.Controls.Add(Me.cmbJYUN, 1, 4)
        Me.tlpFields.Controls.Add(Me.mtxDISP, 1, 3)
        Me.tlpFields.Controls.Add(Me.Label3, 0, 3)
        Me.tlpFields.Controls.Add(Me.mtxVALUE, 1, 2)
        Me.tlpFields.Controls.Add(Me.Label11, 0, 2)
        Me.tlpFields.Controls.Add(Me.Label2, 0, 1)
        Me.tlpFields.Controls.Add(Me.cmbKOMO_NM, 1, 1)
        Me.tlpFields.Controls.Add(Me.Label5, 0, 0)
        Me.tlpFields.Controls.Add(Me.mtxKOMO_GROUP, 1, 0)
        Me.tlpFields.Dock = System.Windows.Forms.DockStyle.Fill
        Me.tlpFields.Location = New System.Drawing.Point(3, 18)
        Me.tlpFields.Name = "tlpFields"
        Me.tlpFields.RowCount = 6
        Me.tlpFields.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30.0!))
        Me.tlpFields.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30.0!))
        Me.tlpFields.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30.0!))
        Me.tlpFields.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30.0!))
        Me.tlpFields.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30.0!))
        Me.tlpFields.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.tlpFields.Size = New System.Drawing.Size(1232, 179)
        Me.tlpFields.TabIndex = 0
        '
        'lbllblEDIT_YMDHNS
        '
        Me.lbllblEDIT_YMDHNS.Font = New System.Drawing.Font("Meiryo UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.lbllblEDIT_YMDHNS.Location = New System.Drawing.Point(955, 0)
        Me.lbllblEDIT_YMDHNS.Name = "lbllblEDIT_YMDHNS"
        Me.lbllblEDIT_YMDHNS.Size = New System.Drawing.Size(94, 30)
        Me.lbllblEDIT_YMDHNS.TabIndex = 56
        Me.lbllblEDIT_YMDHNS.Text = "最終更新日時:"
        Me.lbllblEDIT_YMDHNS.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'lbllblEDIT_SYAIN_ID
        '
        Me.lbllblEDIT_SYAIN_ID.Font = New System.Drawing.Font("Meiryo UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.lbllblEDIT_SYAIN_ID.Location = New System.Drawing.Point(955, 30)
        Me.lbllblEDIT_SYAIN_ID.Name = "lbllblEDIT_SYAIN_ID"
        Me.lbllblEDIT_SYAIN_ID.Size = New System.Drawing.Size(94, 30)
        Me.lbllblEDIT_SYAIN_ID.TabIndex = 65
        Me.lbllblEDIT_SYAIN_ID.Text = "最終更新者:"
        Me.lbllblEDIT_SYAIN_ID.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.lbllblEDIT_SYAIN_ID.Visible = False
        '
        'lblEDIT_SYAIN_ID
        '
        Me.lblEDIT_SYAIN_ID.BackColor = System.Drawing.Color.Transparent
        Me.lblEDIT_SYAIN_ID.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblEDIT_SYAIN_ID.Enabled = False
        Me.lblEDIT_SYAIN_ID.Font = New System.Drawing.Font("Meiryo UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.lblEDIT_SYAIN_ID.Location = New System.Drawing.Point(1055, 30)
        Me.lblEDIT_SYAIN_ID.Name = "lblEDIT_SYAIN_ID"
        Me.lblEDIT_SYAIN_ID.Size = New System.Drawing.Size(174, 30)
        Me.lblEDIT_SYAIN_ID.TabIndex = 66
        Me.lblEDIT_SYAIN_ID.Text = "xxx xxx"
        Me.lblEDIT_SYAIN_ID.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.lblEDIT_SYAIN_ID.Visible = False
        '
        'Label4
        '
        Me.Label4.Font = New System.Drawing.Font("Meiryo UI", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label4.Location = New System.Drawing.Point(3, 150)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(84, 28)
        Me.Label4.TabIndex = 45
        Me.Label4.Text = "備考:"
        Me.Label4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'chkDefaultVaue
        '
        Me.chkDefaultVaue.AutoSize = True
        Me.chkDefaultVaue.Cursor = System.Windows.Forms.Cursors.Hand
        Me.chkDefaultVaue.Font = New System.Drawing.Font("Meiryo UI", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.chkDefaultVaue.Location = New System.Drawing.Point(643, 153)
        Me.chkDefaultVaue.Name = "chkDefaultVaue"
        Me.chkDefaultVaue.Size = New System.Drawing.Size(66, 21)
        Me.chkDefaultVaue.TabIndex = 6
        Me.chkDefaultVaue.Text = "既定値"
        Me.chkDefaultVaue.UseVisualStyleBackColor = True
        '
        'lblEDIT_YMDHNS
        '
        Me.lblEDIT_YMDHNS.BackColor = System.Drawing.Color.Transparent
        Me.lblEDIT_YMDHNS.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblEDIT_YMDHNS.Enabled = False
        Me.lblEDIT_YMDHNS.Font = New System.Drawing.Font("Meiryo UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.lblEDIT_YMDHNS.Location = New System.Drawing.Point(1055, 0)
        Me.lblEDIT_YMDHNS.Name = "lblEDIT_YMDHNS"
        Me.lblEDIT_YMDHNS.Size = New System.Drawing.Size(174, 30)
        Me.lblEDIT_YMDHNS.TabIndex = 43
        Me.lblEDIT_YMDHNS.Text = "yyyy/MM/dd HH:mm:ss"
        Me.lblEDIT_YMDHNS.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.lblEDIT_YMDHNS.Visible = False
        '
        'mtxBIKOU
        '
        Me.mtxBIKOU.BackColor = System.Drawing.SystemColors.Window
        Me.mtxBIKOU.Font = New System.Drawing.Font("Meiryo UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.mtxBIKOU.GotFocusedColor = System.Drawing.Color.FromArgb(CType(CType(190, Byte), Integer), CType(CType(180, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.mtxBIKOU.ImeMode = System.Windows.Forms.ImeMode.[On]
        Me.mtxBIKOU.InputRequired = False
        Me.mtxBIKOU.Location = New System.Drawing.Point(93, 153)
        Me.mtxBIKOU.MaxByteLength = 200
        Me.mtxBIKOU.Name = "mtxBIKOU"
        Me.mtxBIKOU.Size = New System.Drawing.Size(544, 24)
        Me.mtxBIKOU.TabIndex = 5
        Me.mtxBIKOU.WatermarkColor = System.Drawing.Color.Empty
        Me.mtxBIKOU.WatermarkText = Nothing
        '
        'Label1
        '
        Me.Label1.Font = New System.Drawing.Font("Meiryo UI", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label1.Location = New System.Drawing.Point(3, 120)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(84, 30)
        Me.Label1.TabIndex = 44
        Me.Label1.Text = "表示順:"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'cmbJYUN
        '
        Me.cmbJYUN.BackColor = System.Drawing.SystemColors.Window
        Me.cmbJYUN.Cursor = System.Windows.Forms.Cursors.Hand
        Me.cmbJYUN.DisplayMember = "DISP"
        Me.cmbJYUN.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbJYUN.Font = New System.Drawing.Font("Meiryo UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.cmbJYUN.ForeColor = System.Drawing.SystemColors.ControlText
        Me.cmbJYUN.FormattingEnabled = True
        Me.cmbJYUN.GotFocusedColor = System.Drawing.Color.FromArgb(CType(CType(190, Byte), Integer), CType(CType(180, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.cmbJYUN.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.cmbJYUN.Location = New System.Drawing.Point(93, 123)
        Me.cmbJYUN.MaxLength = 30
        Me.cmbJYUN.Name = "cmbJYUN"
        Me.cmbJYUN.NullValue = " "
        Me.cmbJYUN.ReadOnly = False
        Me.cmbJYUN.Selected = False
        Me.cmbJYUN.Size = New System.Drawing.Size(71, 25)
        Me.cmbJYUN.TabIndex = 4
        Me.cmbJYUN.ValueMember = "VALUE"
        '
        'mtxDISP
        '
        Me.mtxDISP.BackColor = System.Drawing.SystemColors.Window
        Me.mtxDISP.Font = New System.Drawing.Font("Meiryo UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.mtxDISP.GotFocusedColor = System.Drawing.Color.FromArgb(CType(CType(190, Byte), Integer), CType(CType(180, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.mtxDISP.ImeMode = System.Windows.Forms.ImeMode.[On]
        Me.mtxDISP.InputRequired = False
        Me.mtxDISP.Location = New System.Drawing.Point(93, 93)
        Me.mtxDISP.MaxByteLength = 200
        Me.mtxDISP.Name = "mtxDISP"
        Me.mtxDISP.Size = New System.Drawing.Size(544, 24)
        Me.mtxDISP.TabIndex = 3
        Me.mtxDISP.WatermarkColor = System.Drawing.Color.Empty
        Me.mtxDISP.WatermarkText = Nothing
        '
        'Label3
        '
        Me.Label3.Font = New System.Drawing.Font("Meiryo UI", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label3.Location = New System.Drawing.Point(3, 90)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(84, 30)
        Me.Label3.TabIndex = 36
        Me.Label3.Text = "表示値:"
        Me.Label3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'mtxVALUE
        '
        Me.mtxVALUE.BackColor = System.Drawing.SystemColors.Window
        Me.mtxVALUE.Font = New System.Drawing.Font("Meiryo UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.mtxVALUE.GotFocusedColor = System.Drawing.Color.FromArgb(CType(CType(190, Byte), Integer), CType(CType(180, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.mtxVALUE.ImeMode = System.Windows.Forms.ImeMode.[On]
        Me.mtxVALUE.InputRequired = False
        Me.mtxVALUE.Location = New System.Drawing.Point(93, 63)
        Me.mtxVALUE.MaxByteLength = 60
        Me.mtxVALUE.Name = "mtxVALUE"
        Me.mtxVALUE.Size = New System.Drawing.Size(237, 24)
        Me.mtxVALUE.TabIndex = 2
        Me.mtxVALUE.WatermarkColor = System.Drawing.Color.Empty
        Me.mtxVALUE.WatermarkText = Nothing
        '
        'Label11
        '
        Me.Label11.Font = New System.Drawing.Font("Meiryo UI", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label11.Location = New System.Drawing.Point(3, 60)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(84, 30)
        Me.Label11.TabIndex = 38
        Me.Label11.Text = "項目値:＊"
        Me.Label11.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label2
        '
        Me.Label2.Font = New System.Drawing.Font("Meiryo UI", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label2.Location = New System.Drawing.Point(3, 30)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(84, 30)
        Me.Label2.TabIndex = 37
        Me.Label2.Text = "項目名:＊"
        Me.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'cmbKOMO_NM
        '
        Me.cmbKOMO_NM.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cmbKOMO_NM.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cmbKOMO_NM.BackColor = System.Drawing.SystemColors.Window
        Me.cmbKOMO_NM.Cursor = System.Windows.Forms.Cursors.Hand
        Me.cmbKOMO_NM.DisplayMember = "DISP"
        Me.cmbKOMO_NM.Font = New System.Drawing.Font("Meiryo UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.cmbKOMO_NM.ForeColor = System.Drawing.SystemColors.ControlText
        Me.cmbKOMO_NM.FormattingEnabled = True
        Me.cmbKOMO_NM.GotFocusedColor = System.Drawing.Color.FromArgb(CType(CType(190, Byte), Integer), CType(CType(180, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.cmbKOMO_NM.ImeMode = System.Windows.Forms.ImeMode.[On]
        Me.cmbKOMO_NM.Location = New System.Drawing.Point(93, 33)
        Me.cmbKOMO_NM.MaxLength = 30
        Me.cmbKOMO_NM.Name = "cmbKOMO_NM"
        Me.cmbKOMO_NM.NullValue = " "
        Me.cmbKOMO_NM.ReadOnly = False
        Me.cmbKOMO_NM.Selected = False
        Me.cmbKOMO_NM.Size = New System.Drawing.Size(403, 25)
        Me.cmbKOMO_NM.TabIndex = 1
        Me.cmbKOMO_NM.Text = "(選択)"
        Me.cmbKOMO_NM.ValueMember = "VALUE"
        '
        'Label5
        '
        Me.Label5.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Label5.Font = New System.Drawing.Font("Meiryo UI", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label5.Location = New System.Drawing.Point(3, 0)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(84, 30)
        Me.Label5.TabIndex = 67
        Me.Label5.Text = "項目グループ:"
        Me.Label5.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'mtxKOMO_GROUP
        '
        Me.mtxKOMO_GROUP.BackColor = System.Drawing.SystemColors.Window
        Me.mtxKOMO_GROUP.Font = New System.Drawing.Font("Meiryo UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.mtxKOMO_GROUP.GotFocusedColor = System.Drawing.Color.FromArgb(CType(CType(190, Byte), Integer), CType(CType(180, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.mtxKOMO_GROUP.ImeMode = System.Windows.Forms.ImeMode.[On]
        Me.mtxKOMO_GROUP.InputRequired = False
        Me.mtxKOMO_GROUP.Location = New System.Drawing.Point(93, 3)
        Me.mtxKOMO_GROUP.MaxByteLength = 60
        Me.mtxKOMO_GROUP.Name = "mtxKOMO_GROUP"
        Me.mtxKOMO_GROUP.Size = New System.Drawing.Size(237, 24)
        Me.mtxKOMO_GROUP.TabIndex = 0
        Me.mtxKOMO_GROUP.WatermarkColor = System.Drawing.Color.Empty
        Me.mtxKOMO_GROUP.WatermarkText = Nothing
        '
        'FrmM0011
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.BackColor = System.Drawing.SystemColors.Control
        Me.ClientSize = New System.Drawing.Size(1264, 712)
        Me.Controls.Add(Me.GroupBox1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.HelpButton = True
        Me.MinimumSize = New System.Drawing.Size(1280, 360)
        Me.Name = "FrmM0011"
        Me.Controls.SetChildIndex(Me.GroupBox1, 0)
        Me.Controls.SetChildIndex(Me.lblTytle, 0)
        Me.Controls.SetChildIndex(Me.cmdFunc8, 0)
        Me.Controls.SetChildIndex(Me.cmdFunc9, 0)
        Me.Controls.SetChildIndex(Me.cmdFunc7, 0)
        Me.Controls.SetChildIndex(Me.cmdFunc10, 0)
        Me.Controls.SetChildIndex(Me.cmdFunc11, 0)
        Me.Controls.SetChildIndex(Me.cmdFunc12, 0)
        Me.Controls.SetChildIndex(Me.cmdFunc6, 0)
        Me.Controls.SetChildIndex(Me.cmdFunc5, 0)
        Me.Controls.SetChildIndex(Me.cmdFunc4, 0)
        Me.Controls.SetChildIndex(Me.cmdFunc3, 0)
        Me.Controls.SetChildIndex(Me.cmdFunc2, 0)
        Me.Controls.SetChildIndex(Me.cmdFunc1, 0)
        CType(Me.ErrorProvider, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox1.ResumeLayout(False)
        Me.tlpFields.ResumeLayout(False)
        Me.tlpFields.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents tlpFields As TableLayoutPanel
    Friend WithEvents Label2 As Label
    Friend WithEvents Label11 As Label
    Friend WithEvents chkDefaultVaue As CheckBox
    Friend WithEvents Label3 As Label
    Public WithEvents cmbJYUN As ComboboxEx
    Friend WithEvents Label1 As Label
    Friend WithEvents mtxDISP As MaskedTextBoxEx
    Public WithEvents cmbKOMO_NM As ComboboxEx
    Friend WithEvents mtxVALUE As MaskedTextBoxEx
    Friend WithEvents lbllblEDIT_YMDHNS As Label
    Public WithEvents lblEDIT_SYAIN_ID As Label
    Friend WithEvents lbllblEDIT_SYAIN_ID As Label
    Public WithEvents lblEDIT_YMDHNS As Label
    Friend WithEvents mtxBIKOU As MaskedTextBoxEx
    Friend WithEvents Label4 As Label
    Friend WithEvents Label5 As Label
    Friend WithEvents mtxKOMO_GROUP As MaskedTextBoxEx
End Class
