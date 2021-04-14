<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class FrmG0037_MailForm
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
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.mtxBody = New JMS_COMMON.TextBoxEx()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.mtxTitle = New JMS_COMMON.MaskedTextBoxEx()
        Me.lbl = New System.Windows.Forms.Label()
        Me.mtxTo = New JMS_COMMON.TextBoxEx()
        CType(Me.ErrorProvider, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.WarningErrorProvider, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox1.SuspendLayout()
        Me.SuspendLayout()
        '
        'cmdFunc1
        '
        Me.cmdFunc1.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.cmdFunc1.Image = Global.FMS.My.Resources.Resources._imgSendMail2
        Me.cmdFunc1.Location = New System.Drawing.Point(24, 508)
        Me.cmdFunc1.TabIndex = 0
        Me.cmdFunc1.Text = "送信(F1)"
        '
        'cmdFunc2
        '
        Me.cmdFunc2.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.cmdFunc2.Location = New System.Drawing.Point(323, 524)
        Me.cmdFunc2.Size = New System.Drawing.Size(20, 27)
        Me.cmdFunc2.Visible = False
        '
        'cmdFunc3
        '
        Me.cmdFunc3.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.cmdFunc3.Location = New System.Drawing.Point(178, 523)
        Me.cmdFunc3.Size = New System.Drawing.Size(20, 27)
        Me.cmdFunc3.Visible = False
        '
        'cmdFunc4
        '
        Me.cmdFunc4.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.cmdFunc4.Location = New System.Drawing.Point(381, 523)
        Me.cmdFunc4.Size = New System.Drawing.Size(20, 27)
        Me.cmdFunc4.Visible = False
        '
        'cmdFunc5
        '
        Me.cmdFunc5.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.cmdFunc5.Location = New System.Drawing.Point(584, 523)
        Me.cmdFunc5.Size = New System.Drawing.Size(20, 27)
        Me.cmdFunc5.Visible = False
        '
        'cmdFunc6
        '
        Me.cmdFunc6.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.cmdFunc6.Location = New System.Drawing.Point(484, 524)
        Me.cmdFunc6.Size = New System.Drawing.Size(15, 27)
        Me.cmdFunc6.TabIndex = 1
        Me.cmdFunc6.Visible = False
        '
        'cmdFunc12
        '
        Me.cmdFunc12.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.cmdFunc12.Image = Global.FMS.My.Resources.Resources._imgLog_Out32x32
        Me.cmdFunc12.Location = New System.Drawing.Point(823, 509)
        Me.cmdFunc12.Text = "キャンセル(F12)"
        '
        'cmdFunc11
        '
        Me.cmdFunc11.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.cmdFunc11.Location = New System.Drawing.Point(584, 523)
        Me.cmdFunc11.Size = New System.Drawing.Size(20, 27)
        Me.cmdFunc11.Visible = False
        '
        'cmdFunc10
        '
        Me.cmdFunc10.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.cmdFunc10.Location = New System.Drawing.Point(381, 523)
        Me.cmdFunc10.Size = New System.Drawing.Size(20, 27)
        Me.cmdFunc10.Visible = False
        '
        'cmdFunc7
        '
        Me.cmdFunc7.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.cmdFunc7.Location = New System.Drawing.Point(357, 524)
        Me.cmdFunc7.Size = New System.Drawing.Size(18, 27)
        Me.cmdFunc7.Visible = False
        '
        'cmdFunc9
        '
        Me.cmdFunc9.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.cmdFunc9.Location = New System.Drawing.Point(178, 523)
        Me.cmdFunc9.Size = New System.Drawing.Size(20, 27)
        Me.cmdFunc9.Visible = False
        '
        'cmdFunc8
        '
        Me.cmdFunc8.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.cmdFunc8.Location = New System.Drawing.Point(323, 524)
        Me.cmdFunc8.Size = New System.Drawing.Size(20, 27)
        Me.cmdFunc8.Visible = False
        '
        'lblTytle
        '
        Me.lblTytle.Location = New System.Drawing.Point(13, 12)
        Me.lblTytle.Size = New System.Drawing.Size(982, 45)
        Me.lblTytle.Text = "メール送信"
        '
        'GroupBox1
        '
        Me.GroupBox1.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GroupBox1.Controls.Add(Me.mtxTo)
        Me.GroupBox1.Controls.Add(Me.Label2)
        Me.GroupBox1.Controls.Add(Me.mtxBody)
        Me.GroupBox1.Controls.Add(Me.Label1)
        Me.GroupBox1.Controls.Add(Me.mtxTitle)
        Me.GroupBox1.Controls.Add(Me.lbl)
        Me.GroupBox1.Font = New System.Drawing.Font("ＭＳ ゴシック", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.GroupBox1.Location = New System.Drawing.Point(13, 60)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(982, 442)
        Me.GroupBox1.TabIndex = 31
        Me.GroupBox1.TabStop = False
        '
        'Label2
        '
        Me.Label2.Font = New System.Drawing.Font("Meiryo UI", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label2.Location = New System.Drawing.Point(8, 107)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(41, 24)
        Me.Label2.TabIndex = 41
        Me.Label2.Text = "本文:"
        Me.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'mtxBody
        '
        Me.mtxBody.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.mtxBody.ImeMode = System.Windows.Forms.ImeMode.[On]
        Me.mtxBody.InputRequired = False
        Me.mtxBody.Location = New System.Drawing.Point(53, 107)
        Me.mtxBody.MaxByteLength = 0
        Me.mtxBody.Multiline = True
        Me.mtxBody.Name = "mtxBody"
        Me.mtxBody.SelectAllText = False
        Me.mtxBody.Size = New System.Drawing.Size(923, 321)
        Me.mtxBody.TabIndex = 40
        Me.mtxBody.WatermarkColor = System.Drawing.Color.Empty
        Me.mtxBody.WatermarkText = Nothing
        '
        'Label1
        '
        Me.Label1.Font = New System.Drawing.Font("Meiryo UI", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label1.Location = New System.Drawing.Point(8, 76)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(41, 24)
        Me.Label1.TabIndex = 39
        Me.Label1.Text = "件名:"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'mtxTitle
        '
        Me.mtxTitle.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.mtxTitle.BackColor = System.Drawing.SystemColors.Window
        Me.mtxTitle.Font = New System.Drawing.Font("Meiryo UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.mtxTitle.ImeMode = System.Windows.Forms.ImeMode.[On]
        Me.mtxTitle.InputRequired = False
        Me.mtxTitle.Location = New System.Drawing.Point(53, 77)
        Me.mtxTitle.MaxByteLength = 200
        Me.mtxTitle.Name = "mtxTitle"
        Me.mtxTitle.SelectAllText = False
        Me.mtxTitle.Size = New System.Drawing.Size(923, 24)
        Me.mtxTitle.TabIndex = 38
        Me.mtxTitle.WatermarkColor = System.Drawing.Color.Empty
        Me.mtxTitle.WatermarkText = Nothing
        '
        'lbl
        '
        Me.lbl.Font = New System.Drawing.Font("Meiryo UI", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.lbl.Location = New System.Drawing.Point(8, 19)
        Me.lbl.Name = "lbl"
        Me.lbl.Size = New System.Drawing.Size(41, 24)
        Me.lbl.TabIndex = 37
        Me.lbl.Text = "宛先:"
        Me.lbl.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'mtxTo
        '
        Me.mtxTo.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.mtxTo.BackColor = System.Drawing.SystemColors.Control
        Me.mtxTo.ImeMode = System.Windows.Forms.ImeMode.[On]
        Me.mtxTo.InputRequired = False
        Me.mtxTo.Location = New System.Drawing.Point(53, 21)
        Me.mtxTo.MaxByteLength = 0
        Me.mtxTo.Multiline = True
        Me.mtxTo.Name = "mtxTo"
        Me.mtxTo.ReadOnly = True
        Me.mtxTo.SelectAllText = False
        Me.mtxTo.Size = New System.Drawing.Size(923, 50)
        Me.mtxTo.TabIndex = 42
        Me.mtxTo.WatermarkColor = System.Drawing.Color.Empty
        Me.mtxTo.WatermarkText = Nothing
        '
        'FrmG0027_MailForm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.BackColor = System.Drawing.SystemColors.Control
        Me.ClientSize = New System.Drawing.Size(1008, 711)
        Me.Controls.Add(Me.GroupBox1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.HelpButton = True
        Me.MinimumSize = New System.Drawing.Size(1000, 600)
        Me.Name = "FrmG0027_MailForm"
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
        Me.GroupBox1.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents lbl As Label
    Friend WithEvents mtxBody As TextBoxEx
    Friend WithEvents Label1 As Label
    Friend WithEvents mtxTitle As MaskedTextBoxEx
    Friend WithEvents Label2 As Label
    Friend WithEvents mtxTo As TextBoxEx
End Class
