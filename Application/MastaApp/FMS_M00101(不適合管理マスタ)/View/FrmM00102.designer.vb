<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class FrmM00102
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
        Me.mtxVALUE = New JMS_COMMON.MaskedTextBoxEx()
        Me.lbllblEDIT_YMDHNS = New System.Windows.Forms.Label()
        Me.lbllblEDIT_SYAIN_ID = New System.Windows.Forms.Label()
        Me.lblEDIT_SYAIN_ID = New System.Windows.Forms.Label()
        Me.lblEDIT_YMDHNS = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.cmbJYUN = New JMS_COMMON.ComboboxEx()
        Me.mtxDISP = New JMS_COMMON.MaskedTextBoxEx()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.mtxSEIHIN_KB_NAME = New JMS_COMMON.MaskedTextBoxEx()
        Me.cmbFUTEKIGO_KB = New JMS_COMMON.ComboboxEx()
        Me.mtxKOMO_GROUP = New JMS_COMMON.MaskedTextBoxEx()
        CType(Me.ErrorProvider, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.WarningErrorProvider, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox1.SuspendLayout()
        Me.tlpFields.SuspendLayout()
        Me.SuspendLayout()
        '
        'cmdFunc1
        '
        Me.cmdFunc1.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.cmdFunc1.Image = Global.FMS.My.Resources.Resources._imgBase_floppydisk32x32
        Me.cmdFunc1.Location = New System.Drawing.Point(13, 294)
        Me.cmdFunc1.TabIndex = 0
        Me.cmdFunc1.Text = "追加(F1)"
        '
        'cmdFunc2
        '
        Me.cmdFunc2.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.cmdFunc2.Location = New System.Drawing.Point(216, 294)
        Me.cmdFunc2.Size = New System.Drawing.Size(20, 42)
        Me.cmdFunc2.Visible = False
        '
        'cmdFunc3
        '
        Me.cmdFunc3.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.cmdFunc3.Location = New System.Drawing.Point(419, 294)
        Me.cmdFunc3.Size = New System.Drawing.Size(20, 42)
        Me.cmdFunc3.Visible = False
        '
        'cmdFunc4
        '
        Me.cmdFunc4.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.cmdFunc4.Location = New System.Drawing.Point(622, 294)
        Me.cmdFunc4.Size = New System.Drawing.Size(20, 42)
        Me.cmdFunc4.Visible = False
        '
        'cmdFunc5
        '
        Me.cmdFunc5.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.cmdFunc5.Location = New System.Drawing.Point(825, 294)
        Me.cmdFunc5.Size = New System.Drawing.Size(20, 42)
        Me.cmdFunc5.Visible = False
        '
        'cmdFunc6
        '
        Me.cmdFunc6.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.cmdFunc6.Location = New System.Drawing.Point(887, 294)
        Me.cmdFunc6.Size = New System.Drawing.Size(120, 42)
        Me.cmdFunc6.TabIndex = 1
        Me.cmdFunc6.Visible = False
        '
        'cmdFunc12
        '
        Me.cmdFunc12.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.cmdFunc12.Image = Global.FMS.My.Resources.Resources._imgLog_Out32x32
        Me.cmdFunc12.Location = New System.Drawing.Point(1091, 294)
        Me.cmdFunc12.Text = "キャンセル(F12)"
        '
        'cmdFunc11
        '
        Me.cmdFunc11.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.cmdFunc11.Location = New System.Drawing.Point(825, 294)
        Me.cmdFunc11.Size = New System.Drawing.Size(20, 42)
        Me.cmdFunc11.Visible = False
        '
        'cmdFunc10
        '
        Me.cmdFunc10.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.cmdFunc10.Location = New System.Drawing.Point(622, 294)
        Me.cmdFunc10.Size = New System.Drawing.Size(20, 42)
        Me.cmdFunc10.Visible = False
        '
        'cmdFunc7
        '
        Me.cmdFunc7.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.cmdFunc7.Location = New System.Drawing.Point(242, 294)
        Me.cmdFunc7.Size = New System.Drawing.Size(18, 42)
        Me.cmdFunc7.Visible = False
        '
        'cmdFunc9
        '
        Me.cmdFunc9.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.cmdFunc9.Location = New System.Drawing.Point(419, 294)
        Me.cmdFunc9.Size = New System.Drawing.Size(20, 42)
        Me.cmdFunc9.Visible = False
        '
        'cmdFunc8
        '
        Me.cmdFunc8.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.cmdFunc8.Location = New System.Drawing.Point(216, 294)
        Me.cmdFunc8.Size = New System.Drawing.Size(20, 42)
        Me.cmdFunc8.Visible = False
        '
        'lblTytle
        '
        Me.lblTytle.Size = New System.Drawing.Size(1239, 45)
        Me.lblTytle.Text = "追加/変更"
        '
        'ToolTip
        '
        Me.ToolTip.InitialDelay = 700
        '
        'GroupBox1
        '
        Me.GroupBox1.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GroupBox1.Controls.Add(Me.tlpFields)
        Me.GroupBox1.Font = New System.Drawing.Font("ＭＳ ゴシック", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.GroupBox1.Location = New System.Drawing.Point(13, 60)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(1238, 228)
        Me.GroupBox1.TabIndex = 31
        Me.GroupBox1.TabStop = False
        '
        'tlpFields
        '
        Me.tlpFields.ColumnCount = 5
        Me.tlpFields.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 136.0!))
        Me.tlpFields.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 504.0!))
        Me.tlpFields.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.tlpFields.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 100.0!))
        Me.tlpFields.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 180.0!))
        Me.tlpFields.Controls.Add(Me.mtxVALUE, 0, 2)
        Me.tlpFields.Controls.Add(Me.lbllblEDIT_YMDHNS, 3, 0)
        Me.tlpFields.Controls.Add(Me.lbllblEDIT_SYAIN_ID, 3, 1)
        Me.tlpFields.Controls.Add(Me.lblEDIT_SYAIN_ID, 4, 1)
        Me.tlpFields.Controls.Add(Me.lblEDIT_YMDHNS, 4, 0)
        Me.tlpFields.Controls.Add(Me.Label1, 0, 4)
        Me.tlpFields.Controls.Add(Me.cmbJYUN, 1, 4)
        Me.tlpFields.Controls.Add(Me.mtxDISP, 1, 3)
        Me.tlpFields.Controls.Add(Me.Label3, 0, 3)
        Me.tlpFields.Controls.Add(Me.Label11, 0, 2)
        Me.tlpFields.Controls.Add(Me.Label2, 0, 1)
        Me.tlpFields.Controls.Add(Me.Label5, 0, 0)
        Me.tlpFields.Controls.Add(Me.mtxSEIHIN_KB_NAME, 1, 0)
        Me.tlpFields.Controls.Add(Me.cmbFUTEKIGO_KB, 1, 1)
        Me.tlpFields.Dock = System.Windows.Forms.DockStyle.Fill
        Me.tlpFields.Location = New System.Drawing.Point(3, 18)
        Me.tlpFields.Name = "tlpFields"
        Me.tlpFields.RowCount = 8
        Me.tlpFields.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30.0!))
        Me.tlpFields.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30.0!))
        Me.tlpFields.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30.0!))
        Me.tlpFields.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30.0!))
        Me.tlpFields.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30.0!))
        Me.tlpFields.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30.0!))
        Me.tlpFields.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30.0!))
        Me.tlpFields.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.tlpFields.Size = New System.Drawing.Size(1232, 207)
        Me.tlpFields.TabIndex = 0
        '
        'mtxVALUE
        '
        Me.mtxVALUE.BackColor = System.Drawing.SystemColors.Window
        Me.mtxVALUE.Font = New System.Drawing.Font("Meiryo UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.mtxVALUE.ImeMode = System.Windows.Forms.ImeMode.Off
        Me.mtxVALUE.InputRequired = False
        Me.mtxVALUE.Location = New System.Drawing.Point(139, 63)
        Me.mtxVALUE.Mask = "CC"
        Me.mtxVALUE.MaxByteLength = 60
        Me.mtxVALUE.Name = "mtxVALUE"
        Me.mtxVALUE.PermitNumChars = True
        Me.mtxVALUE.SelectAllText = False
        Me.mtxVALUE.Size = New System.Drawing.Size(101, 24)
        Me.mtxVALUE.TabIndex = 2
        Me.mtxVALUE.WatermarkColor = System.Drawing.Color.Empty
        Me.mtxVALUE.WatermarkText = Nothing
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
        Me.lbllblEDIT_YMDHNS.Visible = False
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
        Me.lblEDIT_SYAIN_ID.Font = New System.Drawing.Font("Meiryo UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.lblEDIT_SYAIN_ID.Location = New System.Drawing.Point(1055, 30)
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
        Me.lblEDIT_YMDHNS.Font = New System.Drawing.Font("Meiryo UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.lblEDIT_YMDHNS.Location = New System.Drawing.Point(1055, 0)
        Me.lblEDIT_YMDHNS.Name = "lblEDIT_YMDHNS"
        Me.lblEDIT_YMDHNS.Size = New System.Drawing.Size(174, 30)
        Me.lblEDIT_YMDHNS.TabIndex = 43
        Me.lblEDIT_YMDHNS.Text = "yyyy/MM/dd HH:mm:ss"
        Me.lblEDIT_YMDHNS.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.lblEDIT_YMDHNS.Visible = False
        '
        'Label1
        '
        Me.Label1.Font = New System.Drawing.Font("Meiryo UI", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label1.Location = New System.Drawing.Point(3, 120)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(84, 30)
        Me.Label1.TabIndex = 44
        Me.Label1.Text = "表示順:"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'cmbJYUN
        '
        Me.cmbJYUN.BackColor = System.Drawing.SystemColors.Window
        Me.cmbJYUN.Cursor = System.Windows.Forms.Cursors.Default
        Me.cmbJYUN.DisplayMember = "DISP"
        Me.cmbJYUN.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbJYUN.Font = New System.Drawing.Font("Meiryo UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.cmbJYUN.ForeColor = System.Drawing.SystemColors.ControlText
        Me.cmbJYUN.FormattingEnabled = True
        Me.cmbJYUN.HorizontalContentAlignment = System.Drawing.StringAlignment.Near
        Me.cmbJYUN.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.cmbJYUN.IsSelected = False
        Me.cmbJYUN.Location = New System.Drawing.Point(139, 123)
        Me.cmbJYUN.MaxLength = 30
        Me.cmbJYUN.Name = "cmbJYUN"
        Me.cmbJYUN.NullValue = " "
        Me.cmbJYUN.Size = New System.Drawing.Size(101, 25)
        Me.cmbJYUN.TabIndex = 4
        Me.cmbJYUN.ValueMember = "VALUE"
        '
        'mtxDISP
        '
        Me.mtxDISP.BackColor = System.Drawing.SystemColors.Window
        Me.mtxDISP.Font = New System.Drawing.Font("Meiryo UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.mtxDISP.ImeMode = System.Windows.Forms.ImeMode.[On]
        Me.mtxDISP.InputRequired = False
        Me.mtxDISP.Location = New System.Drawing.Point(139, 93)
        Me.mtxDISP.MaxByteLength = 200
        Me.mtxDISP.Name = "mtxDISP"
        Me.mtxDISP.SelectAllText = False
        Me.mtxDISP.Size = New System.Drawing.Size(331, 24)
        Me.mtxDISP.TabIndex = 3
        Me.mtxDISP.WatermarkColor = System.Drawing.Color.Empty
        Me.mtxDISP.WatermarkText = Nothing
        '
        'Label3
        '
        Me.Label3.Font = New System.Drawing.Font("Meiryo UI", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label3.Location = New System.Drawing.Point(3, 90)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(130, 30)
        Me.Label3.TabIndex = 36
        Me.Label3.Text = "不適合詳細区分名:"
        Me.Label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label11
        '
        Me.Label11.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Label11.Font = New System.Drawing.Font("Meiryo UI", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label11.Location = New System.Drawing.Point(3, 60)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(130, 30)
        Me.Label11.TabIndex = 38
        Me.Label11.Text = "不適合詳細区分値:"
        Me.Label11.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label2
        '
        Me.Label2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Label2.Font = New System.Drawing.Font("Meiryo UI", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label2.Location = New System.Drawing.Point(3, 30)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(130, 30)
        Me.Label2.TabIndex = 37
        Me.Label2.Text = "不適合区分:"
        Me.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label5
        '
        Me.Label5.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Label5.Font = New System.Drawing.Font("Meiryo UI", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label5.Location = New System.Drawing.Point(3, 0)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(130, 30)
        Me.Label5.TabIndex = 67
        Me.Label5.Text = "製品区分:"
        Me.Label5.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'mtxSEIHIN_KB_NAME
        '
        Me.mtxSEIHIN_KB_NAME.BackColor = System.Drawing.SystemColors.MenuBar
        Me.mtxSEIHIN_KB_NAME.Enabled = False
        Me.mtxSEIHIN_KB_NAME.Font = New System.Drawing.Font("Meiryo UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.mtxSEIHIN_KB_NAME.ImeMode = System.Windows.Forms.ImeMode.[On]
        Me.mtxSEIHIN_KB_NAME.InputRequired = False
        Me.mtxSEIHIN_KB_NAME.Location = New System.Drawing.Point(139, 3)
        Me.mtxSEIHIN_KB_NAME.MaxByteLength = 60
        Me.mtxSEIHIN_KB_NAME.Name = "mtxSEIHIN_KB_NAME"
        Me.mtxSEIHIN_KB_NAME.SelectAllText = False
        Me.mtxSEIHIN_KB_NAME.Size = New System.Drawing.Size(101, 24)
        Me.mtxSEIHIN_KB_NAME.TabIndex = 0
        Me.mtxSEIHIN_KB_NAME.WatermarkColor = System.Drawing.Color.Empty
        Me.mtxSEIHIN_KB_NAME.WatermarkText = Nothing
        '
        'cmbFUTEKIGO_KB
        '
        Me.cmbFUTEKIGO_KB.BackColor = System.Drawing.SystemColors.Window
        Me.cmbFUTEKIGO_KB.Cursor = System.Windows.Forms.Cursors.Default
        Me.cmbFUTEKIGO_KB.DisplayMember = "DISP"
        Me.cmbFUTEKIGO_KB.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbFUTEKIGO_KB.Font = New System.Drawing.Font("Meiryo UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.cmbFUTEKIGO_KB.ForeColor = System.Drawing.SystemColors.ControlText
        Me.cmbFUTEKIGO_KB.FormattingEnabled = True
        Me.cmbFUTEKIGO_KB.HorizontalContentAlignment = System.Drawing.StringAlignment.Near
        Me.cmbFUTEKIGO_KB.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.cmbFUTEKIGO_KB.IsSelected = False
        Me.cmbFUTEKIGO_KB.Location = New System.Drawing.Point(139, 33)
        Me.cmbFUTEKIGO_KB.MaxLength = 30
        Me.cmbFUTEKIGO_KB.Name = "cmbFUTEKIGO_KB"
        Me.cmbFUTEKIGO_KB.NullValue = " "
        Me.cmbFUTEKIGO_KB.Size = New System.Drawing.Size(142, 25)
        Me.cmbFUTEKIGO_KB.TabIndex = 1
        Me.cmbFUTEKIGO_KB.ValueMember = "VALUE"
        '
        'mtxKOMO_GROUP
        '
        Me.mtxKOMO_GROUP.BackColor = System.Drawing.SystemColors.MenuBar
        Me.mtxKOMO_GROUP.Enabled = False
        Me.mtxKOMO_GROUP.Font = New System.Drawing.Font("Meiryo UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.mtxKOMO_GROUP.ImeMode = System.Windows.Forms.ImeMode.[On]
        Me.mtxKOMO_GROUP.InputRequired = False
        Me.mtxKOMO_GROUP.Location = New System.Drawing.Point(93, 3)
        Me.mtxKOMO_GROUP.MaxByteLength = 60
        Me.mtxKOMO_GROUP.Name = "mtxKOMO_GROUP"
        Me.mtxKOMO_GROUP.SelectAllText = False
        Me.mtxKOMO_GROUP.Size = New System.Drawing.Size(101, 24)
        Me.mtxKOMO_GROUP.TabIndex = 0
        Me.mtxKOMO_GROUP.WatermarkColor = System.Drawing.Color.Empty
        Me.mtxKOMO_GROUP.WatermarkText = Nothing
        '
        'FrmM00102
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.BackColor = System.Drawing.SystemColors.Control
        Me.ClientSize = New System.Drawing.Size(1264, 712)
        Me.Controls.Add(Me.GroupBox1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.HelpButton = True
        Me.MinimumSize = New System.Drawing.Size(1280, 380)
        Me.Name = "FrmM00102"
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
        CType(Me.WarningErrorProvider, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox1.ResumeLayout(False)
        Me.tlpFields.ResumeLayout(False)
        Me.tlpFields.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents tlpFields As TableLayoutPanel
    Friend WithEvents Label2 As Label
    Friend WithEvents Label11 As Label
    Friend WithEvents lbllblEDIT_YMDHNS As Label
    Public WithEvents lblEDIT_SYAIN_ID As Label
    Friend WithEvents lbllblEDIT_SYAIN_ID As Label
    Public WithEvents lblEDIT_YMDHNS As Label
    Friend WithEvents Label5 As Label
    Friend WithEvents mtxSEIHIN_KB_NAME As MaskedTextBoxEx
    Friend WithEvents mtxKOMO_GROUP As MaskedTextBoxEx
    Friend WithEvents Label1 As Label
    Public WithEvents cmbJYUN As ComboboxEx
    Friend WithEvents mtxDISP As MaskedTextBoxEx
    Friend WithEvents Label3 As Label
    Friend WithEvents Label4 As Label
    Friend WithEvents mtxBIKOU As MaskedTextBoxEx
    Public WithEvents cmbFUTEKIGO_KB As ComboboxEx
    Friend WithEvents mtxVALUE As MaskedTextBoxEx
End Class
