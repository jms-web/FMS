<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class FrmExportDialog
    Inherits JMS_COMMON.FrmBaseBtn

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
        CType(Me.ErrorProvider, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.WarningErrorProvider, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'cmdFunc1
        '
        Me.cmdFunc1.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.cmdFunc1.Image = Global.FMS.My.Resources.Resources._imgExportToExcel32x32
        Me.cmdFunc1.Location = New System.Drawing.Point(13, 35)
        Me.cmdFunc1.Size = New System.Drawing.Size(138, 42)
        Me.cmdFunc1.TabIndex = 0
        Me.cmdFunc1.Text = "不適合データExcel"
        '
        'cmdFunc2
        '
        Me.cmdFunc2.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.cmdFunc2.Image = Global.FMS.My.Resources.Resources._imgText_Document32x32
        Me.cmdFunc2.Location = New System.Drawing.Point(157, 35)
        Me.cmdFunc2.Size = New System.Drawing.Size(138, 42)
        Me.cmdFunc2.Text = "不適合データCSV"
        '
        'cmdFunc3
        '
        Me.cmdFunc3.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.cmdFunc3.Image = Global.FMS.My.Resources.Resources._imgNew32x32
        Me.cmdFunc3.Location = New System.Drawing.Point(301, 35)
        Me.cmdFunc3.Size = New System.Drawing.Size(138, 42)
        Me.cmdFunc3.Text = "処置履歴データCSV"
        '
        'cmdFunc4
        '
        Me.cmdFunc4.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.cmdFunc4.Location = New System.Drawing.Point(568, 71)
        Me.cmdFunc4.Size = New System.Drawing.Size(20, 27)
        Me.cmdFunc4.Visible = False
        '
        'cmdFunc5
        '
        Me.cmdFunc5.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.cmdFunc5.Location = New System.Drawing.Point(775, 63)
        Me.cmdFunc5.Size = New System.Drawing.Size(20, 27)
        Me.cmdFunc5.Visible = False
        '
        'cmdFunc6
        '
        Me.cmdFunc6.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.cmdFunc6.Location = New System.Drawing.Point(671, 72)
        Me.cmdFunc6.Size = New System.Drawing.Size(120, 27)
        Me.cmdFunc6.TabIndex = 1
        Me.cmdFunc6.Visible = False
        '
        'cmdFunc12
        '
        Me.cmdFunc12.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.cmdFunc12.Image = Global.FMS.My.Resources.Resources._imgLog_Out32x32
        Me.cmdFunc12.Location = New System.Drawing.Point(445, 35)
        Me.cmdFunc12.Size = New System.Drawing.Size(138, 42)
        Me.cmdFunc12.Text = "キャンセル"
        '
        'cmdFunc11
        '
        Me.cmdFunc11.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.cmdFunc11.Location = New System.Drawing.Point(775, 63)
        Me.cmdFunc11.Size = New System.Drawing.Size(20, 27)
        Me.cmdFunc11.Visible = False
        '
        'cmdFunc10
        '
        Me.cmdFunc10.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.cmdFunc10.Location = New System.Drawing.Point(568, 71)
        Me.cmdFunc10.Size = New System.Drawing.Size(20, 27)
        Me.cmdFunc10.Visible = False
        '
        'cmdFunc7
        '
        Me.cmdFunc7.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.cmdFunc7.Location = New System.Drawing.Point(544, 72)
        Me.cmdFunc7.Size = New System.Drawing.Size(18, 27)
        Me.cmdFunc7.Visible = False
        '
        'cmdFunc9
        '
        Me.cmdFunc9.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.cmdFunc9.Location = New System.Drawing.Point(365, 71)
        Me.cmdFunc9.Size = New System.Drawing.Size(20, 27)
        Me.cmdFunc9.Visible = False
        '
        'cmdFunc8
        '
        Me.cmdFunc8.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.cmdFunc8.Location = New System.Drawing.Point(510, 72)
        Me.cmdFunc8.Size = New System.Drawing.Size(20, 27)
        Me.cmdFunc8.Visible = False
        '
        'lblTytle
        '
        Me.lblTytle.Location = New System.Drawing.Point(12, 3)
        Me.lblTytle.Size = New System.Drawing.Size(568, 29)
        Me.lblTytle.Text = ""
        Me.lblTytle.Visible = False
        '
        'FrmExportDialog
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.BackColor = System.Drawing.SystemColors.Control
        Me.ClientSize = New System.Drawing.Size(594, 111)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.HelpButton = True
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.MinimumSize = New System.Drawing.Size(610, 150)
        Me.Name = "FrmExportDialog"
        CType(Me.ErrorProvider, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.WarningErrorProvider, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
End Class
