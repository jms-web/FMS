<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class FrmM0021
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
        Me.lblEDIT_YMDHNS = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.cmbBUSYO_KB = New JMS_COMMON.ComboboxEx()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.mtxTEL = New JMS_COMMON.MaskedTextBoxEx()
        Me.cmbBUMON_KB = New JMS_COMMON.ComboboxEx()
        Me.chkYUKO_YMD = New System.Windows.Forms.CheckBox()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.cmbSYOZOKUCYO = New JMS_COMMON.ComboboxEx()
        Me.mtxBUSYO_NAME = New JMS_COMMON.MaskedTextBoxEx()
        Me.cmbOYA_BUSYO = New JMS_COMMON.ComboboxEx()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.cmbOYA_BUSYO_KB = New JMS_COMMON.ComboboxEx()
        Me.datYUKO_YMD = New JMS_COMMON.DateTextBoxEx()
        CType(Me.ErrorProvider, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox1.SuspendLayout()
        Me.tlpFields.SuspendLayout()
        Me.SuspendLayout()
        '
        'cmdFunc1
        '
        Me.cmdFunc1.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.cmdFunc1.Image = Global.FMS.My.Resources.Resources._imgBase_floppydisk32x32
        Me.cmdFunc1.Location = New System.Drawing.Point(22, 309)
        Me.cmdFunc1.TabIndex = 0
        Me.cmdFunc1.Text = "追加(F1)"
        '
        'cmdFunc2
        '
        Me.cmdFunc2.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.cmdFunc2.Location = New System.Drawing.Point(223, 309)
        Me.cmdFunc2.Size = New System.Drawing.Size(20, 42)
        Me.cmdFunc2.Visible = False
        '
        'cmdFunc3
        '
        Me.cmdFunc3.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.cmdFunc3.Location = New System.Drawing.Point(431, 309)
        Me.cmdFunc3.Size = New System.Drawing.Size(20, 42)
        Me.cmdFunc3.Visible = False
        '
        'cmdFunc4
        '
        Me.cmdFunc4.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.cmdFunc4.Location = New System.Drawing.Point(629, 312)
        Me.cmdFunc4.Size = New System.Drawing.Size(20, 42)
        Me.cmdFunc4.Visible = False
        '
        'cmdFunc5
        '
        Me.cmdFunc5.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.cmdFunc5.Location = New System.Drawing.Point(832, 309)
        Me.cmdFunc5.Size = New System.Drawing.Size(20, 42)
        Me.cmdFunc5.Visible = False
        '
        'cmdFunc6
        '
        Me.cmdFunc6.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.cmdFunc6.Location = New System.Drawing.Point(892, 309)
        Me.cmdFunc6.Size = New System.Drawing.Size(120, 42)
        Me.cmdFunc6.TabIndex = 1
        Me.cmdFunc6.Visible = False
        '
        'cmdFunc12
        '
        Me.cmdFunc12.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.cmdFunc12.Image = Global.FMS.My.Resources.Resources._imgLog_Out32x32
        Me.cmdFunc12.Location = New System.Drawing.Point(1086, 309)
        Me.cmdFunc12.Text = "キャンセル(F12)"
        '
        'cmdFunc11
        '
        Me.cmdFunc11.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.cmdFunc11.Location = New System.Drawing.Point(832, 312)
        Me.cmdFunc11.Size = New System.Drawing.Size(20, 42)
        Me.cmdFunc11.Visible = False
        '
        'cmdFunc10
        '
        Me.cmdFunc10.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.cmdFunc10.Location = New System.Drawing.Point(629, 309)
        Me.cmdFunc10.Size = New System.Drawing.Size(20, 42)
        Me.cmdFunc10.Visible = False
        '
        'cmdFunc7
        '
        Me.cmdFunc7.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.cmdFunc7.Location = New System.Drawing.Point(249, 309)
        Me.cmdFunc7.Size = New System.Drawing.Size(18, 42)
        Me.cmdFunc7.Visible = False
        '
        'cmdFunc9
        '
        Me.cmdFunc9.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.cmdFunc9.Location = New System.Drawing.Point(431, 309)
        Me.cmdFunc9.Size = New System.Drawing.Size(20, 42)
        Me.cmdFunc9.Visible = False
        '
        'cmdFunc8
        '
        Me.cmdFunc8.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.cmdFunc8.Location = New System.Drawing.Point(223, 296)
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
        Me.GroupBox1.Size = New System.Drawing.Size(1239, 243)
        Me.GroupBox1.TabIndex = 31
        Me.GroupBox1.TabStop = False
        '
        'tlpFields
        '
        Me.tlpFields.ColumnCount = 6
        Me.tlpFields.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 90.0!))
        Me.tlpFields.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 171.0!))
        Me.tlpFields.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 105.0!))
        Me.tlpFields.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.tlpFields.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 100.0!))
        Me.tlpFields.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 180.0!))
        Me.tlpFields.Controls.Add(Me.lbllblEDIT_YMDHNS, 4, 0)
        Me.tlpFields.Controls.Add(Me.lbllblEDIT_SYAIN_ID, 4, 1)
        Me.tlpFields.Controls.Add(Me.lblEDIT_SYAIN_ID, 5, 1)
        Me.tlpFields.Controls.Add(Me.lblEDIT_YMDHNS, 5, 0)
        Me.tlpFields.Controls.Add(Me.Label2, 0, 1)
        Me.tlpFields.Controls.Add(Me.cmbBUSYO_KB, 1, 1)
        Me.tlpFields.Controls.Add(Me.Label5, 0, 0)
        Me.tlpFields.Controls.Add(Me.Label4, 0, 6)
        Me.tlpFields.Controls.Add(Me.Label1, 0, 5)
        Me.tlpFields.Controls.Add(Me.Label6, 0, 2)
        Me.tlpFields.Controls.Add(Me.mtxTEL, 1, 6)
        Me.tlpFields.Controls.Add(Me.cmbBUMON_KB, 1, 0)
        Me.tlpFields.Controls.Add(Me.chkYUKO_YMD, 2, 2)
        Me.tlpFields.Controls.Add(Me.Label11, 0, 4)
        Me.tlpFields.Controls.Add(Me.cmbSYOZOKUCYO, 1, 5)
        Me.tlpFields.Controls.Add(Me.mtxBUSYO_NAME, 1, 4)
        Me.tlpFields.Controls.Add(Me.cmbOYA_BUSYO, 3, 3)
        Me.tlpFields.Controls.Add(Me.Label3, 2, 3)
        Me.tlpFields.Controls.Add(Me.Label7, 0, 3)
        Me.tlpFields.Controls.Add(Me.cmbOYA_BUSYO_KB, 1, 3)
        Me.tlpFields.Controls.Add(Me.datYUKO_YMD, 1, 2)
        Me.tlpFields.Dock = System.Windows.Forms.DockStyle.Fill
        Me.tlpFields.Location = New System.Drawing.Point(3, 18)
        Me.tlpFields.Name = "tlpFields"
        Me.tlpFields.RowCount = 7
        Me.tlpFields.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30.0!))
        Me.tlpFields.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30.0!))
        Me.tlpFields.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30.0!))
        Me.tlpFields.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30.0!))
        Me.tlpFields.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30.0!))
        Me.tlpFields.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.tlpFields.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 39.0!))
        Me.tlpFields.Size = New System.Drawing.Size(1233, 222)
        Me.tlpFields.TabIndex = 0
        '
        'lbllblEDIT_YMDHNS
        '
        Me.lbllblEDIT_YMDHNS.Font = New System.Drawing.Font("Meiryo UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.lbllblEDIT_YMDHNS.Location = New System.Drawing.Point(956, 0)
        Me.lbllblEDIT_YMDHNS.Name = "lbllblEDIT_YMDHNS"
        Me.lbllblEDIT_YMDHNS.Size = New System.Drawing.Size(94, 30)
        Me.lbllblEDIT_YMDHNS.TabIndex = 56
        Me.lbllblEDIT_YMDHNS.Text = "最終更新日時:"
        Me.lbllblEDIT_YMDHNS.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'lbllblEDIT_SYAIN_ID
        '
        Me.lbllblEDIT_SYAIN_ID.Font = New System.Drawing.Font("Meiryo UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.lbllblEDIT_SYAIN_ID.Location = New System.Drawing.Point(956, 30)
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
        Me.lblEDIT_SYAIN_ID.Location = New System.Drawing.Point(1056, 30)
        Me.lblEDIT_SYAIN_ID.Name = "lblEDIT_SYAIN_ID"
        Me.lblEDIT_SYAIN_ID.Size = New System.Drawing.Size(174, 30)
        Me.lblEDIT_SYAIN_ID.TabIndex = 66
        Me.lblEDIT_SYAIN_ID.Text = "xxx xxx"
        Me.lblEDIT_SYAIN_ID.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.lblEDIT_SYAIN_ID.Visible = False
        '
        'lblEDIT_YMDHNS
        '
        Me.lblEDIT_YMDHNS.BackColor = System.Drawing.Color.Transparent
        Me.lblEDIT_YMDHNS.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblEDIT_YMDHNS.Enabled = False
        Me.lblEDIT_YMDHNS.Font = New System.Drawing.Font("Meiryo UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.lblEDIT_YMDHNS.Location = New System.Drawing.Point(1056, 0)
        Me.lblEDIT_YMDHNS.Name = "lblEDIT_YMDHNS"
        Me.lblEDIT_YMDHNS.Size = New System.Drawing.Size(174, 30)
        Me.lblEDIT_YMDHNS.TabIndex = 43
        Me.lblEDIT_YMDHNS.Text = "yyyy/MM/dd HH:mm:ss"
        Me.lblEDIT_YMDHNS.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.lblEDIT_YMDHNS.Visible = False
        '
        'Label2
        '
        Me.Label2.Font = New System.Drawing.Font("Meiryo UI", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label2.Location = New System.Drawing.Point(3, 30)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(84, 30)
        Me.Label2.TabIndex = 37
        Me.Label2.Text = "部署区分:＊"
        Me.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'cmbBUSYO_KB
        '
        Me.cmbBUSYO_KB.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cmbBUSYO_KB.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cmbBUSYO_KB.BackColor = System.Drawing.SystemColors.Window
        Me.cmbBUSYO_KB.Cursor = System.Windows.Forms.Cursors.Default
        Me.cmbBUSYO_KB.DisplayMember = "DISP"
        Me.cmbBUSYO_KB.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbBUSYO_KB.Font = New System.Drawing.Font("Meiryo UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.cmbBUSYO_KB.ForeColor = System.Drawing.SystemColors.ControlText
        Me.cmbBUSYO_KB.FormattingEnabled = True
        Me.cmbBUSYO_KB.GotFocusedColor = System.Drawing.Color.FromArgb(CType(CType(190, Byte), Integer), CType(CType(180, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.cmbBUSYO_KB.ImeMode = System.Windows.Forms.ImeMode.[On]
        Me.cmbBUSYO_KB.Location = New System.Drawing.Point(93, 33)
        Me.cmbBUSYO_KB.MaxLength = 30
        Me.cmbBUSYO_KB.Name = "cmbBUSYO_KB"
        Me.cmbBUSYO_KB.NullValue = " "
        Me.cmbBUSYO_KB.ReadOnly = False
        Me.cmbBUSYO_KB.Selected = False
        Me.cmbBUSYO_KB.Size = New System.Drawing.Size(158, 25)
        Me.cmbBUSYO_KB.TabIndex = 1
        Me.cmbBUSYO_KB.ValueMember = "VALUE"
        '
        'Label5
        '
        Me.Label5.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Label5.Font = New System.Drawing.Font("Meiryo UI", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label5.Location = New System.Drawing.Point(3, 0)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(84, 30)
        Me.Label5.TabIndex = 67
        Me.Label5.Text = "製品区分:＊"
        Me.Label5.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label4
        '
        Me.Label4.Font = New System.Drawing.Font("Meiryo UI", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label4.Location = New System.Drawing.Point(3, 183)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(84, 28)
        Me.Label4.TabIndex = 45
        Me.Label4.Text = "TEL:"
        Me.Label4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label1
        '
        Me.Label1.Font = New System.Drawing.Font("Meiryo UI", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label1.Location = New System.Drawing.Point(3, 150)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(84, 30)
        Me.Label1.TabIndex = 44
        Me.Label1.Text = "所属長社員:"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label6
        '
        Me.Label6.Font = New System.Drawing.Font("Meiryo UI", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label6.Location = New System.Drawing.Point(3, 60)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(84, 28)
        Me.Label6.TabIndex = 68
        Me.Label6.Text = "有効期限"
        Me.Label6.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'mtxTEL
        '
        Me.mtxTEL.BackColor = System.Drawing.SystemColors.Window
        Me.mtxTEL.Font = New System.Drawing.Font("Meiryo UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.mtxTEL.GotFocusedColor = System.Drawing.Color.FromArgb(CType(CType(190, Byte), Integer), CType(CType(180, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.mtxTEL.ImeMode = System.Windows.Forms.ImeMode.[On]
        Me.mtxTEL.InputRequired = False
        Me.mtxTEL.Location = New System.Drawing.Point(93, 186)
        Me.mtxTEL.MaxByteLength = 16
        Me.mtxTEL.Name = "mtxTEL"
        Me.mtxTEL.Size = New System.Drawing.Size(165, 24)
        Me.mtxTEL.TabIndex = 0
        Me.mtxTEL.WatermarkColor = System.Drawing.Color.Empty
        Me.mtxTEL.WatermarkText = Nothing
        '
        'cmbBUMON_KB
        '
        Me.cmbBUMON_KB.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cmbBUMON_KB.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cmbBUMON_KB.BackColor = System.Drawing.SystemColors.Window
        Me.cmbBUMON_KB.Cursor = System.Windows.Forms.Cursors.Default
        Me.cmbBUMON_KB.DisplayMember = "DISP"
        Me.cmbBUMON_KB.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbBUMON_KB.Font = New System.Drawing.Font("Meiryo UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.cmbBUMON_KB.ForeColor = System.Drawing.SystemColors.ControlText
        Me.cmbBUMON_KB.FormattingEnabled = True
        Me.cmbBUMON_KB.GotFocusedColor = System.Drawing.Color.FromArgb(CType(CType(190, Byte), Integer), CType(CType(180, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.cmbBUMON_KB.ImeMode = System.Windows.Forms.ImeMode.[On]
        Me.cmbBUMON_KB.Location = New System.Drawing.Point(93, 3)
        Me.cmbBUMON_KB.MaxLength = 30
        Me.cmbBUMON_KB.Name = "cmbBUMON_KB"
        Me.cmbBUMON_KB.NullValue = " "
        Me.cmbBUMON_KB.ReadOnly = False
        Me.cmbBUMON_KB.Selected = False
        Me.cmbBUMON_KB.Size = New System.Drawing.Size(158, 25)
        Me.cmbBUMON_KB.TabIndex = 69
        Me.cmbBUMON_KB.ValueMember = "VALUE"
        '
        'chkYUKO_YMD
        '
        Me.chkYUKO_YMD.AutoSize = True
        Me.chkYUKO_YMD.Checked = True
        Me.chkYUKO_YMD.CheckState = System.Windows.Forms.CheckState.Checked
        Me.chkYUKO_YMD.Location = New System.Drawing.Point(264, 63)
        Me.chkYUKO_YMD.Name = "chkYUKO_YMD"
        Me.chkYUKO_YMD.Size = New System.Drawing.Size(94, 19)
        Me.chkYUKO_YMD.TabIndex = 71
        Me.chkYUKO_YMD.Text = "期限なし"
        Me.chkYUKO_YMD.UseVisualStyleBackColor = True
        '
        'Label11
        '
        Me.Label11.Font = New System.Drawing.Font("Meiryo UI", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label11.Location = New System.Drawing.Point(3, 120)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(84, 30)
        Me.Label11.TabIndex = 38
        Me.Label11.Text = "部署名:＊"
        Me.Label11.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'cmbSYOZOKUCYO
        '
        Me.cmbSYOZOKUCYO.BackColor = System.Drawing.SystemColors.Window
        Me.tlpFields.SetColumnSpan(Me.cmbSYOZOKUCYO, 2)
        Me.cmbSYOZOKUCYO.Cursor = System.Windows.Forms.Cursors.Default
        Me.cmbSYOZOKUCYO.DisplayMember = "DISP"
        Me.cmbSYOZOKUCYO.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbSYOZOKUCYO.Font = New System.Drawing.Font("Meiryo UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.cmbSYOZOKUCYO.ForeColor = System.Drawing.SystemColors.ControlText
        Me.cmbSYOZOKUCYO.FormattingEnabled = True
        Me.cmbSYOZOKUCYO.GotFocusedColor = System.Drawing.Color.FromArgb(CType(CType(190, Byte), Integer), CType(CType(180, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.cmbSYOZOKUCYO.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.cmbSYOZOKUCYO.Location = New System.Drawing.Point(93, 153)
        Me.cmbSYOZOKUCYO.MaxLength = 30
        Me.cmbSYOZOKUCYO.Name = "cmbSYOZOKUCYO"
        Me.cmbSYOZOKUCYO.NullValue = " "
        Me.cmbSYOZOKUCYO.ReadOnly = False
        Me.cmbSYOZOKUCYO.Selected = False
        Me.cmbSYOZOKUCYO.Size = New System.Drawing.Size(270, 25)
        Me.cmbSYOZOKUCYO.TabIndex = 72
        Me.cmbSYOZOKUCYO.ValueMember = "VALUE"
        '
        'mtxBUSYO_NAME
        '
        Me.mtxBUSYO_NAME.BackColor = System.Drawing.SystemColors.Window
        Me.tlpFields.SetColumnSpan(Me.mtxBUSYO_NAME, 2)
        Me.mtxBUSYO_NAME.Font = New System.Drawing.Font("Meiryo UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.mtxBUSYO_NAME.GotFocusedColor = System.Drawing.Color.FromArgb(CType(CType(190, Byte), Integer), CType(CType(180, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.mtxBUSYO_NAME.ImeMode = System.Windows.Forms.ImeMode.[On]
        Me.mtxBUSYO_NAME.InputRequired = False
        Me.mtxBUSYO_NAME.Location = New System.Drawing.Point(93, 123)
        Me.mtxBUSYO_NAME.MaxByteLength = 200
        Me.mtxBUSYO_NAME.Name = "mtxBUSYO_NAME"
        Me.mtxBUSYO_NAME.Size = New System.Drawing.Size(270, 24)
        Me.mtxBUSYO_NAME.TabIndex = 3
        Me.mtxBUSYO_NAME.WatermarkColor = System.Drawing.Color.Empty
        Me.mtxBUSYO_NAME.WatermarkText = Nothing
        '
        'cmbOYA_BUSYO
        '
        Me.cmbOYA_BUSYO.BackColor = System.Drawing.SystemColors.Window
        Me.tlpFields.SetColumnSpan(Me.cmbOYA_BUSYO, 2)
        Me.cmbOYA_BUSYO.Cursor = System.Windows.Forms.Cursors.Default
        Me.cmbOYA_BUSYO.DisplayMember = "DISP"
        Me.cmbOYA_BUSYO.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbOYA_BUSYO.Font = New System.Drawing.Font("Meiryo UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.cmbOYA_BUSYO.ForeColor = System.Drawing.SystemColors.ControlText
        Me.cmbOYA_BUSYO.FormattingEnabled = True
        Me.cmbOYA_BUSYO.GotFocusedColor = System.Drawing.Color.FromArgb(CType(CType(190, Byte), Integer), CType(CType(180, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.cmbOYA_BUSYO.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.cmbOYA_BUSYO.Location = New System.Drawing.Point(369, 93)
        Me.cmbOYA_BUSYO.MaxLength = 30
        Me.cmbOYA_BUSYO.Name = "cmbOYA_BUSYO"
        Me.cmbOYA_BUSYO.NullValue = " "
        Me.cmbOYA_BUSYO.ReadOnly = False
        Me.cmbOYA_BUSYO.Selected = False
        Me.cmbOYA_BUSYO.Size = New System.Drawing.Size(292, 25)
        Me.cmbOYA_BUSYO.TabIndex = 4
        Me.cmbOYA_BUSYO.ValueMember = "VALUE"
        '
        'Label3
        '
        Me.Label3.Font = New System.Drawing.Font("Meiryo UI", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label3.Location = New System.Drawing.Point(264, 90)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(84, 30)
        Me.Label3.TabIndex = 36
        Me.Label3.Tag = ""
        Me.Label3.Text = "親部署:"
        Me.Label3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label7
        '
        Me.Label7.Font = New System.Drawing.Font("Meiryo UI", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label7.Location = New System.Drawing.Point(3, 90)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(84, 30)
        Me.Label7.TabIndex = 73
        Me.Label7.Tag = ""
        Me.Label7.Text = "親部署区分:"
        Me.Label7.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'cmbOYA_BUSYO_KB
        '
        Me.cmbOYA_BUSYO_KB.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cmbOYA_BUSYO_KB.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cmbOYA_BUSYO_KB.BackColor = System.Drawing.SystemColors.Window
        Me.cmbOYA_BUSYO_KB.Cursor = System.Windows.Forms.Cursors.Default
        Me.cmbOYA_BUSYO_KB.DisplayMember = "DISP"
        Me.cmbOYA_BUSYO_KB.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbOYA_BUSYO_KB.Font = New System.Drawing.Font("Meiryo UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.cmbOYA_BUSYO_KB.ForeColor = System.Drawing.SystemColors.ControlText
        Me.cmbOYA_BUSYO_KB.FormattingEnabled = True
        Me.cmbOYA_BUSYO_KB.GotFocusedColor = System.Drawing.Color.FromArgb(CType(CType(190, Byte), Integer), CType(CType(180, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.cmbOYA_BUSYO_KB.ImeMode = System.Windows.Forms.ImeMode.[On]
        Me.cmbOYA_BUSYO_KB.Location = New System.Drawing.Point(93, 93)
        Me.cmbOYA_BUSYO_KB.MaxLength = 30
        Me.cmbOYA_BUSYO_KB.Name = "cmbOYA_BUSYO_KB"
        Me.cmbOYA_BUSYO_KB.NullValue = " "
        Me.cmbOYA_BUSYO_KB.ReadOnly = False
        Me.cmbOYA_BUSYO_KB.Selected = False
        Me.cmbOYA_BUSYO_KB.Size = New System.Drawing.Size(158, 25)
        Me.cmbOYA_BUSYO_KB.TabIndex = 74
        Me.cmbOYA_BUSYO_KB.ValueMember = "VALUE"
        '
        'datYUKO_YMD
        '
        Me.datYUKO_YMD.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.datYUKO_YMD.Enabled = False
        Me.datYUKO_YMD.GotFocusedColor = System.Drawing.Color.FromArgb(CType(CType(190, Byte), Integer), CType(CType(180, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.datYUKO_YMD.Location = New System.Drawing.Point(93, 63)
        Me.datYUKO_YMD.MaxDate = New Date(9998, 12, 31, 0, 0, 0, 0)
        Me.datYUKO_YMD.MinDate = New Date(1753, 1, 1, 0, 0, 0, 0)
        Me.datYUKO_YMD.MinimumSize = New System.Drawing.Size(98, 24)
        Me.datYUKO_YMD.Name = "datYUKO_YMD"
        Me.datYUKO_YMD.Nullable = True
        Me.datYUKO_YMD.ReadOnly = False
        Me.datYUKO_YMD.Size = New System.Drawing.Size(158, 24)
        Me.datYUKO_YMD.TabIndex = 75
        Me.datYUKO_YMD.Value = ""
        Me.datYUKO_YMD.ValueNonFormat = ""
        '
        'FrmM0021
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.BackColor = System.Drawing.SystemColors.Control
        Me.ClientSize = New System.Drawing.Size(1264, 712)
        Me.Controls.Add(Me.GroupBox1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.HelpButton = True
        Me.MinimumSize = New System.Drawing.Size(1280, 360)
        Me.Name = "FrmM0021"
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
    Friend WithEvents Label3 As Label
    Public WithEvents cmbOYA_BUSYO As ComboboxEx
    Friend WithEvents Label1 As Label
    Friend WithEvents mtxBUSYO_NAME As MaskedTextBoxEx
    Public WithEvents cmbBUSYO_KB As ComboboxEx
    Friend WithEvents lbllblEDIT_YMDHNS As Label
    Public WithEvents lblEDIT_SYAIN_ID As Label
    Friend WithEvents lbllblEDIT_SYAIN_ID As Label
    Public WithEvents lblEDIT_YMDHNS As Label
    Friend WithEvents Label4 As Label
    Friend WithEvents Label5 As Label
    Friend WithEvents mtxTEL As MaskedTextBoxEx
    Friend WithEvents Label6 As Label
    Public WithEvents cmbBUMON_KB As ComboboxEx
    Friend WithEvents chkYUKO_YMD As CheckBox
    Public WithEvents cmbSYOZOKUCYO As ComboboxEx
    Friend WithEvents Label7 As Label
    Public WithEvents cmbOYA_BUSYO_KB As ComboboxEx
    Friend WithEvents datYUKO_YMD As DateTextBoxEx
End Class
