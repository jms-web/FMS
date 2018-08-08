<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class FrmM1051
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
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.lbllblEDIT_SYAIN_ID = New System.Windows.Forms.Label()
        Me.TxtKISYU_ID = New JMS_COMMON.MaskedTextBoxEx()
        Me.CmbBUMON_KB = New JMS_COMMON.ComboboxEx()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.TxtKISYU_NAME = New JMS_COMMON.MaskedTextBoxEx()
        CType(Me.ErrorProvider, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox1.SuspendLayout()
        Me.TableLayoutPanel1.SuspendLayout()
        Me.SuspendLayout()
        '
        'cmdFunc1
        '
        Me.cmdFunc1.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.cmdFunc1.Image = Global.FMS.My.Resources.Resources._imgBase_floppydisk32x32
        Me.cmdFunc1.Location = New System.Drawing.Point(12, 213)
        Me.cmdFunc1.Size = New System.Drawing.Size(156, 42)
        Me.cmdFunc1.TabIndex = 0
        Me.cmdFunc1.Text = "追加(F1)"
        '
        'cmdFunc2
        '
        Me.cmdFunc2.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.cmdFunc2.Location = New System.Drawing.Point(335, 222)
        Me.cmdFunc2.Size = New System.Drawing.Size(23, 33)
        Me.cmdFunc2.Visible = False
        '
        'cmdFunc3
        '
        Me.cmdFunc3.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.cmdFunc3.Location = New System.Drawing.Point(496, 222)
        Me.cmdFunc3.Size = New System.Drawing.Size(23, 33)
        Me.cmdFunc3.Visible = False
        '
        'cmdFunc4
        '
        Me.cmdFunc4.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.cmdFunc4.Location = New System.Drawing.Point(657, 222)
        Me.cmdFunc4.Size = New System.Drawing.Size(23, 33)
        Me.cmdFunc4.Visible = False
        '
        'cmdFunc5
        '
        Me.cmdFunc5.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.cmdFunc5.Location = New System.Drawing.Point(818, 222)
        Me.cmdFunc5.Size = New System.Drawing.Size(23, 33)
        Me.cmdFunc5.Visible = False
        '
        'cmdFunc6
        '
        Me.cmdFunc6.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.cmdFunc6.Location = New System.Drawing.Point(979, 222)
        Me.cmdFunc6.Size = New System.Drawing.Size(23, 33)
        Me.cmdFunc6.Visible = False
        '
        'cmdFunc12
        '
        Me.cmdFunc12.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.cmdFunc12.Image = Global.FMS.My.Resources.Resources._imgLog_Out32x32
        Me.cmdFunc12.Location = New System.Drawing.Point(1096, 216)
        Me.cmdFunc12.Size = New System.Drawing.Size(156, 42)
        Me.cmdFunc12.TabIndex = 1
        Me.cmdFunc12.Text = "キャンセル(F12)"
        '
        'cmdFunc11
        '
        Me.cmdFunc11.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.cmdFunc11.Location = New System.Drawing.Point(818, 222)
        Me.cmdFunc11.Size = New System.Drawing.Size(23, 33)
        Me.cmdFunc11.Visible = False
        '
        'cmdFunc10
        '
        Me.cmdFunc10.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.cmdFunc10.Location = New System.Drawing.Point(657, 222)
        Me.cmdFunc10.Size = New System.Drawing.Size(23, 33)
        Me.cmdFunc10.Visible = False
        '
        'cmdFunc7
        '
        Me.cmdFunc7.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.cmdFunc7.Location = New System.Drawing.Point(174, 222)
        Me.cmdFunc7.Size = New System.Drawing.Size(23, 33)
        Me.cmdFunc7.Visible = False
        '
        'cmdFunc9
        '
        Me.cmdFunc9.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.cmdFunc9.Location = New System.Drawing.Point(496, 222)
        Me.cmdFunc9.Size = New System.Drawing.Size(23, 33)
        Me.cmdFunc9.Visible = False
        '
        'cmdFunc8
        '
        Me.cmdFunc8.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.cmdFunc8.Location = New System.Drawing.Point(335, 222)
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
        Me.GroupBox1.Size = New System.Drawing.Size(1239, 150)
        Me.GroupBox1.TabIndex = 31
        Me.GroupBox1.TabStop = False
        '
        'TableLayoutPanel1
        '
        Me.TableLayoutPanel1.ColumnCount = 5
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 100.0!))
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 185.0!))
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 105.0!))
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 182.0!))
        Me.TableLayoutPanel1.Controls.Add(Me.lblEDIT_YMDHNS, 4, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.lblEDIT_SYAIN_ID, 4, 1)
        Me.TableLayoutPanel1.Controls.Add(Me.lbllblEDIT_YMDHNS, 3, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.Label5, 0, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.Label6, 0, 1)
        Me.TableLayoutPanel1.Controls.Add(Me.lbllblEDIT_SYAIN_ID, 3, 1)
        Me.TableLayoutPanel1.Controls.Add(Me.TxtKISYU_ID, 1, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.CmbBUMON_KB, 1, 1)
        Me.TableLayoutPanel1.Controls.Add(Me.Label2, 0, 2)
        Me.TableLayoutPanel1.Controls.Add(Me.TxtKISYU_NAME, 1, 2)
        Me.TableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TableLayoutPanel1.Font = New System.Drawing.Font("Meiryo UI", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.TableLayoutPanel1.Location = New System.Drawing.Point(3, 18)
        Me.TableLayoutPanel1.Name = "TableLayoutPanel1"
        Me.TableLayoutPanel1.RowCount = 7
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel1.Size = New System.Drawing.Size(1233, 129)
        Me.TableLayoutPanel1.TabIndex = 47
        '
        'lblEDIT_YMDHNS
        '
        Me.lblEDIT_YMDHNS.BackColor = System.Drawing.Color.Transparent
        Me.lblEDIT_YMDHNS.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblEDIT_YMDHNS.Dock = System.Windows.Forms.DockStyle.Fill
        Me.lblEDIT_YMDHNS.Enabled = False
        Me.lblEDIT_YMDHNS.Font = New System.Drawing.Font("Meiryo UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.lblEDIT_YMDHNS.Location = New System.Drawing.Point(1054, 0)
        Me.lblEDIT_YMDHNS.Name = "lblEDIT_YMDHNS"
        Me.lblEDIT_YMDHNS.Size = New System.Drawing.Size(176, 30)
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
        Me.lblEDIT_SYAIN_ID.Location = New System.Drawing.Point(1054, 30)
        Me.lblEDIT_SYAIN_ID.Name = "lblEDIT_SYAIN_ID"
        Me.lblEDIT_SYAIN_ID.Size = New System.Drawing.Size(176, 30)
        Me.lblEDIT_SYAIN_ID.TabIndex = 66
        Me.lblEDIT_SYAIN_ID.Text = "xxx xxx"
        Me.lblEDIT_SYAIN_ID.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.lblEDIT_SYAIN_ID.Visible = False
        '
        'lbllblEDIT_YMDHNS
        '
        Me.lbllblEDIT_YMDHNS.Dock = System.Windows.Forms.DockStyle.Fill
        Me.lbllblEDIT_YMDHNS.Font = New System.Drawing.Font("Meiryo UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.lbllblEDIT_YMDHNS.Location = New System.Drawing.Point(949, 0)
        Me.lbllblEDIT_YMDHNS.Name = "lbllblEDIT_YMDHNS"
        Me.lbllblEDIT_YMDHNS.Size = New System.Drawing.Size(99, 30)
        Me.lbllblEDIT_YMDHNS.TabIndex = 56
        Me.lbllblEDIT_YMDHNS.Text = "最終更新日時:"
        Me.lbllblEDIT_YMDHNS.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label5
        '
        Me.Label5.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Label5.Font = New System.Drawing.Font("Meiryo UI", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label5.Location = New System.Drawing.Point(3, 0)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(94, 30)
        Me.Label5.TabIndex = 38
        Me.Label5.Text = "機種ID:"
        Me.Label5.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label6
        '
        Me.Label6.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Label6.Font = New System.Drawing.Font("Meiryo UI", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label6.Location = New System.Drawing.Point(3, 30)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(94, 30)
        Me.Label6.TabIndex = 39
        Me.Label6.Text = "部門区分:"
        Me.Label6.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'lbllblEDIT_SYAIN_ID
        '
        Me.lbllblEDIT_SYAIN_ID.Dock = System.Windows.Forms.DockStyle.Fill
        Me.lbllblEDIT_SYAIN_ID.Font = New System.Drawing.Font("Meiryo UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.lbllblEDIT_SYAIN_ID.Location = New System.Drawing.Point(949, 30)
        Me.lbllblEDIT_SYAIN_ID.Name = "lbllblEDIT_SYAIN_ID"
        Me.lbllblEDIT_SYAIN_ID.Size = New System.Drawing.Size(99, 30)
        Me.lbllblEDIT_SYAIN_ID.TabIndex = 65
        Me.lbllblEDIT_SYAIN_ID.Text = "最終更新者:"
        Me.lbllblEDIT_SYAIN_ID.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.lbllblEDIT_SYAIN_ID.Visible = False
        '
        'TxtKISYU_ID
        '
        Me.TxtKISYU_ID.BackColor = System.Drawing.SystemColors.Window
        Me.TxtKISYU_ID.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TxtKISYU_ID.GotFocusedColor = System.Drawing.Color.FromArgb(CType(CType(190, Byte), Integer), CType(CType(180, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.TxtKISYU_ID.ImeMode = System.Windows.Forms.ImeMode.Disable
        Me.TxtKISYU_ID.InputRequired = False
        Me.TxtKISYU_ID.Location = New System.Drawing.Point(103, 3)
        Me.TxtKISYU_ID.MaxByteLength = 0
        Me.TxtKISYU_ID.Name = "TxtKISYU_ID"
        Me.TxtKISYU_ID.Size = New System.Drawing.Size(179, 23)
        Me.TxtKISYU_ID.TabIndex = 48
        Me.TxtKISYU_ID.WatermarkColor = System.Drawing.Color.Empty
        Me.TxtKISYU_ID.WatermarkText = Nothing
        '
        'CmbBUMON_KB
        '
        Me.CmbBUMON_KB.BackColor = System.Drawing.SystemColors.Window
        Me.CmbBUMON_KB.Cursor = System.Windows.Forms.Cursors.Default
        Me.CmbBUMON_KB.DisplayMember = "DISP"
        Me.CmbBUMON_KB.Dock = System.Windows.Forms.DockStyle.Fill
        Me.CmbBUMON_KB.FormattingEnabled = True
        Me.CmbBUMON_KB.GotFocusedColor = System.Drawing.Color.Empty
        Me.CmbBUMON_KB.Location = New System.Drawing.Point(103, 33)
        Me.CmbBUMON_KB.Name = "CmbBUMON_KB"
        Me.CmbBUMON_KB.NullValue = " "
        Me.CmbBUMON_KB.ReadOnly = False
        Me.CmbBUMON_KB.Selected = False
        Me.CmbBUMON_KB.Size = New System.Drawing.Size(179, 23)
        Me.CmbBUMON_KB.TabIndex = 49
        Me.CmbBUMON_KB.ValueMember = "VALUE"
        '
        'Label2
        '
        Me.Label2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Label2.Font = New System.Drawing.Font("Meiryo UI", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label2.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.Label2.Location = New System.Drawing.Point(3, 60)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(94, 30)
        Me.Label2.TabIndex = 45
        Me.Label2.Text = "機種名:"
        Me.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'TxtKISYU_NAME
        '
        Me.TxtKISYU_NAME.BackColor = System.Drawing.SystemColors.Window
        Me.TxtKISYU_NAME.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TxtKISYU_NAME.GotFocusedColor = System.Drawing.Color.FromArgb(CType(CType(190, Byte), Integer), CType(CType(180, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.TxtKISYU_NAME.ImeMode = System.Windows.Forms.ImeMode.Disable
        Me.TxtKISYU_NAME.InputRequired = False
        Me.TxtKISYU_NAME.Location = New System.Drawing.Point(103, 63)
        Me.TxtKISYU_NAME.MaxByteLength = 0
        Me.TxtKISYU_NAME.Name = "TxtKISYU_NAME"
        Me.TxtKISYU_NAME.Size = New System.Drawing.Size(179, 23)
        Me.TxtKISYU_NAME.TabIndex = 51
        Me.TxtKISYU_NAME.WatermarkColor = System.Drawing.Color.Empty
        Me.TxtKISYU_NAME.WatermarkText = Nothing
        '
        'FrmM1051
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.BackColor = System.Drawing.SystemColors.Control
        Me.ClientSize = New System.Drawing.Size(1264, 712)
        Me.Controls.Add(Me.GroupBox1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.HelpButton = True
        Me.MinimumSize = New System.Drawing.Size(1280, 300)
        Me.Name = "FrmM1051"
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
    Friend WithEvents TxtKISYU_ID As MaskedTextBoxEx
    Friend WithEvents CmbBUMON_KB As ComboboxEx
    Friend WithEvents TxtKISYU_NAME As MaskedTextBoxEx
End Class
