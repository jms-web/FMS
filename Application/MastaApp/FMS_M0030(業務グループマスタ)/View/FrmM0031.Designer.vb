<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class FrmM0031
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
        Me.Label5 = New System.Windows.Forms.Label()
        Me.mtxGYOMU_GROUP_ID = New JMS_COMMON.MaskedTextBoxEx()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.mtxBUSYO_NAME = New JMS_COMMON.MaskedTextBoxEx()
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
        Me.cmdFunc1.Location = New System.Drawing.Point(22, 155)
        Me.cmdFunc1.TabIndex = 0
        Me.cmdFunc1.Text = "追加(F1)"
        '
        'cmdFunc2
        '
        Me.cmdFunc2.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.cmdFunc2.Location = New System.Drawing.Point(223, 155)
        Me.cmdFunc2.Size = New System.Drawing.Size(20, 42)
        Me.cmdFunc2.Visible = False
        '
        'cmdFunc3
        '
        Me.cmdFunc3.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.cmdFunc3.Location = New System.Drawing.Point(431, 155)
        Me.cmdFunc3.Size = New System.Drawing.Size(20, 42)
        Me.cmdFunc3.Visible = False
        '
        'cmdFunc4
        '
        Me.cmdFunc4.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.cmdFunc4.Location = New System.Drawing.Point(629, 158)
        Me.cmdFunc4.Size = New System.Drawing.Size(20, 42)
        Me.cmdFunc4.Visible = False
        '
        'cmdFunc5
        '
        Me.cmdFunc5.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.cmdFunc5.Location = New System.Drawing.Point(832, 155)
        Me.cmdFunc5.Size = New System.Drawing.Size(20, 42)
        Me.cmdFunc5.Visible = False
        '
        'cmdFunc6
        '
        Me.cmdFunc6.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.cmdFunc6.Location = New System.Drawing.Point(892, 155)
        Me.cmdFunc6.Size = New System.Drawing.Size(120, 42)
        Me.cmdFunc6.TabIndex = 1
        Me.cmdFunc6.Visible = False
        '
        'cmdFunc12
        '
        Me.cmdFunc12.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.cmdFunc12.Image = Global.FMS.My.Resources.Resources._imgLog_Out32x32
        Me.cmdFunc12.Location = New System.Drawing.Point(1086, 155)
        Me.cmdFunc12.Text = "キャンセル(F12)"
        '
        'cmdFunc11
        '
        Me.cmdFunc11.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.cmdFunc11.Location = New System.Drawing.Point(832, 158)
        Me.cmdFunc11.Size = New System.Drawing.Size(20, 42)
        Me.cmdFunc11.Visible = False
        '
        'cmdFunc10
        '
        Me.cmdFunc10.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.cmdFunc10.Location = New System.Drawing.Point(629, 155)
        Me.cmdFunc10.Size = New System.Drawing.Size(20, 42)
        Me.cmdFunc10.Visible = False
        '
        'cmdFunc7
        '
        Me.cmdFunc7.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.cmdFunc7.Location = New System.Drawing.Point(249, 155)
        Me.cmdFunc7.Size = New System.Drawing.Size(18, 42)
        Me.cmdFunc7.Visible = False
        '
        'cmdFunc9
        '
        Me.cmdFunc9.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.cmdFunc9.Location = New System.Drawing.Point(431, 155)
        Me.cmdFunc9.Size = New System.Drawing.Size(20, 42)
        Me.cmdFunc9.Visible = False
        '
        'cmdFunc8
        '
        Me.cmdFunc8.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.cmdFunc8.Location = New System.Drawing.Point(223, 142)
        Me.cmdFunc8.Size = New System.Drawing.Size(20, 42)
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
        'GroupBox1
        '
        Me.GroupBox1.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GroupBox1.Controls.Add(Me.tlpFields)
        Me.GroupBox1.Font = New System.Drawing.Font("ＭＳ ゴシック", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.GroupBox1.Location = New System.Drawing.Point(13, 60)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(1239, 89)
        Me.GroupBox1.TabIndex = 31
        Me.GroupBox1.TabStop = False
        '
        'tlpFields
        '
        Me.tlpFields.ColumnCount = 6
        Me.tlpFields.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 126.0!))
        Me.tlpFields.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 135.0!))
        Me.tlpFields.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 105.0!))
        Me.tlpFields.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.tlpFields.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 100.0!))
        Me.tlpFields.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 180.0!))
        Me.tlpFields.Controls.Add(Me.lbllblEDIT_YMDHNS, 4, 0)
        Me.tlpFields.Controls.Add(Me.lbllblEDIT_SYAIN_ID, 4, 1)
        Me.tlpFields.Controls.Add(Me.lblEDIT_SYAIN_ID, 5, 1)
        Me.tlpFields.Controls.Add(Me.lblEDIT_YMDHNS, 5, 0)
        Me.tlpFields.Controls.Add(Me.Label5, 0, 0)
        Me.tlpFields.Controls.Add(Me.mtxGYOMU_GROUP_ID, 1, 0)
        Me.tlpFields.Controls.Add(Me.Label11, 0, 1)
        Me.tlpFields.Controls.Add(Me.mtxBUSYO_NAME, 1, 1)
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
        Me.tlpFields.Size = New System.Drawing.Size(1233, 68)
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
        'Label5
        '
        Me.Label5.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Label5.Font = New System.Drawing.Font("Meiryo UI", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label5.Location = New System.Drawing.Point(3, 0)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(120, 30)
        Me.Label5.TabIndex = 67
        Me.Label5.Text = "ID:＊"
        Me.Label5.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'mtxGYOMU_GROUP_ID
        '
        Me.mtxGYOMU_GROUP_ID.BackColor = System.Drawing.Color.White
        Me.tlpFields.SetColumnSpan(Me.mtxGYOMU_GROUP_ID, 2)
        Me.mtxGYOMU_GROUP_ID.Font = New System.Drawing.Font("Meiryo UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.mtxGYOMU_GROUP_ID.ImeMode = System.Windows.Forms.ImeMode.[On]
        Me.mtxGYOMU_GROUP_ID.InputRequired = False
        Me.mtxGYOMU_GROUP_ID.Location = New System.Drawing.Point(129, 3)
        Me.mtxGYOMU_GROUP_ID.MaxByteLength = 200
        Me.mtxGYOMU_GROUP_ID.Name = "mtxGYOMU_GROUP_ID"
        Me.mtxGYOMU_GROUP_ID.SelectAllText = False
        Me.mtxGYOMU_GROUP_ID.Size = New System.Drawing.Size(63, 24)
        Me.mtxGYOMU_GROUP_ID.TabIndex = 68
        Me.mtxGYOMU_GROUP_ID.WatermarkColor = System.Drawing.Color.Empty
        Me.mtxGYOMU_GROUP_ID.WatermarkText = Nothing
        '
        'Label11
        '
        Me.Label11.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Label11.Font = New System.Drawing.Font("Meiryo UI", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label11.Location = New System.Drawing.Point(3, 30)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(120, 30)
        Me.Label11.TabIndex = 38
        Me.Label11.Text = "業務グループ名:＊"
        Me.Label11.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'mtxBUSYO_NAME
        '
        Me.mtxBUSYO_NAME.BackColor = System.Drawing.SystemColors.Window
        Me.tlpFields.SetColumnSpan(Me.mtxBUSYO_NAME, 2)
        Me.mtxBUSYO_NAME.Font = New System.Drawing.Font("Meiryo UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.mtxBUSYO_NAME.ImeMode = System.Windows.Forms.ImeMode.[On]
        Me.mtxBUSYO_NAME.InputRequired = False
        Me.mtxBUSYO_NAME.Location = New System.Drawing.Point(129, 33)
        Me.mtxBUSYO_NAME.MaxByteLength = 200
        Me.mtxBUSYO_NAME.Name = "mtxBUSYO_NAME"
        Me.mtxBUSYO_NAME.SelectAllText = False
        Me.mtxBUSYO_NAME.Size = New System.Drawing.Size(234, 24)
        Me.mtxBUSYO_NAME.TabIndex = 3
        Me.mtxBUSYO_NAME.WatermarkColor = System.Drawing.Color.Empty
        Me.mtxBUSYO_NAME.WatermarkText = Nothing
        '
        'FrmM0031
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.BackColor = System.Drawing.SystemColors.Control
        Me.ClientSize = New System.Drawing.Size(1264, 712)
        Me.Controls.Add(Me.GroupBox1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.HelpButton = True
        Me.MinimumSize = New System.Drawing.Size(1280, 250)
        Me.Name = "FrmM0031"
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
    Friend WithEvents Label11 As Label
    Friend WithEvents mtxBUSYO_NAME As MaskedTextBoxEx
    Friend WithEvents lbllblEDIT_YMDHNS As Label
    Public WithEvents lblEDIT_SYAIN_ID As Label
    Friend WithEvents lbllblEDIT_SYAIN_ID As Label
    Public WithEvents lblEDIT_YMDHNS As Label
    Friend WithEvents Label5 As Label
    Friend WithEvents mtxGYOMU_GROUP_ID As MaskedTextBoxEx
End Class
