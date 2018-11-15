<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ToastForm
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Me.messageLabel = New System.Windows.Forms.Label()
        Me.lifeTimer = New System.Windows.Forms.Timer(Me.components)
        Me.SuspendLayout()
        '
        'messageLabel
        '
        Me.messageLabel.BackColor = System.Drawing.Color.Transparent
        Me.messageLabel.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.messageLabel.Dock = System.Windows.Forms.DockStyle.Fill
        Me.messageLabel.Font = New System.Drawing.Font("Meiryo UI", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.messageLabel.ForeColor = System.Drawing.Color.White
        Me.messageLabel.Location = New System.Drawing.Point(0, 0)
        Me.messageLabel.Name = "messageLabel"
        Me.messageLabel.Size = New System.Drawing.Size(1280, 23)
        Me.messageLabel.TabIndex = 0
        Me.messageLabel.Text = "Message will appear here"
        Me.messageLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lifeTimer
        '
        '
        'ToastForm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.SlateGray
        Me.ClientSize = New System.Drawing.Size(1280, 23)
        Me.Controls.Add(Me.messageLabel)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Name = "ToastForm"
        Me.Text = "Toast Form"
        Me.TopMost = True
        Me.ResumeLayout(False)

    End Sub
    Private WithEvents messageLabel As System.Windows.Forms.Label
    Private WithEvents lifeTimer As System.Windows.Forms.Timer
End Class
