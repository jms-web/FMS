<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class FrmG0013
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
        Me.Panel1 = New System.Windows.Forms.Panel()
        CType(Me.ErrorProvider, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'lblRecordCount
        '
        Me.lblRecordCount.ForeColor = System.Drawing.SystemColors.ControlText
        Me.lblRecordCount.Location = New System.Drawing.Point(16, 565)
        Me.lblRecordCount.Size = New System.Drawing.Size(403, 24)
        '
        'cmdFunc1
        '
        Me.cmdFunc1.Image = Global.FMS.My.Resources.Resources._imgApplication_form32x32
        Me.cmdFunc1.Location = New System.Drawing.Point(9, 595)
        Me.cmdFunc1.Text = "変更内容比較(F1)"
        '
        'cmdFunc2
        '
        Me.cmdFunc2.Location = New System.Drawing.Point(216, 595)
        '
        'cmdFunc3
        '
        Me.cmdFunc3.Location = New System.Drawing.Point(423, 595)
        '
        'cmdFunc4
        '
        Me.cmdFunc4.Location = New System.Drawing.Point(630, 595)
        '
        'cmdFunc5
        '
        Me.cmdFunc5.Location = New System.Drawing.Point(837, 595)
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
        Me.cmdFunc10.Location = New System.Drawing.Point(630, 643)
        '
        'cmdFunc7
        '
        Me.cmdFunc7.Location = New System.Drawing.Point(9, 643)
        '
        'cmdFunc9
        '
        Me.cmdFunc9.Location = New System.Drawing.Point(423, 643)
        '
        'cmdFunc8
        '
        Me.cmdFunc8.Location = New System.Drawing.Point(216, 643)
        '
        'lblTytle
        '
        Me.lblTytle.Font = New System.Drawing.Font("Meiryo UI", 24.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTytle.ForeColor = System.Drawing.SystemColors.ControlText
        Me.lblTytle.Text = "不適合検索画面"
        '
        'Panel1
        '

        Me.Panel1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.Panel1.Location = New System.Drawing.Point(16, 60)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(1236, 502)
        Me.Panel1.TabIndex = 65
        '
        'FrmG0013
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.ClientSize = New System.Drawing.Size(1264, 712)
        Me.Controls.Add(Me.Panel1)
        Me.HelpButton = True
        Me.Name = "FrmG0013"
        Me.ShowStatusBar = True
        Me.Text = ""
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
        Me.Controls.SetChildIndex(Me.Panel1, 0)
        CType(Me.ErrorProvider, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Panel1 As Panel
End Class
