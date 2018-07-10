<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class FrmG0014
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
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.dgvDATA = New System.Windows.Forms.DataGridView()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.mtxYOIN_NAME = New JMS_COMMON.MaskedTextBoxEx()
        CType(Me.ErrorProvider, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dgvDATA, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'lblRecordCount
        '
        Me.lblRecordCount.ForeColor = System.Drawing.SystemColors.ControlText
        Me.lblRecordCount.Location = New System.Drawing.Point(12, 415)
        Me.lblRecordCount.Size = New System.Drawing.Size(408, 24)
        '
        'cmdFunc1
        '
        Me.cmdFunc1.Image = Global.FMS.My.Resources.Resources._imgApplication_form32x32
        Me.cmdFunc1.Location = New System.Drawing.Point(9, 445)
        Me.cmdFunc1.Text = "OK(F1)"
        '
        'cmdFunc2
        '
        Me.cmdFunc2.Location = New System.Drawing.Point(255, 445)
        Me.cmdFunc2.Size = New System.Drawing.Size(31, 42)
        '
        'cmdFunc3
        '
        Me.cmdFunc3.Location = New System.Drawing.Point(292, 445)
        Me.cmdFunc3.Size = New System.Drawing.Size(31, 42)
        '
        'cmdFunc4
        '
        Me.cmdFunc4.Location = New System.Drawing.Point(329, 445)
        Me.cmdFunc4.Size = New System.Drawing.Size(31, 42)
        '
        'cmdFunc5
        '
        Me.cmdFunc5.Location = New System.Drawing.Point(366, 445)
        Me.cmdFunc5.Size = New System.Drawing.Size(31, 42)
        '
        'cmdFunc6
        '
        Me.cmdFunc6.Location = New System.Drawing.Point(219, 445)
        Me.cmdFunc6.Size = New System.Drawing.Size(33, 42)
        '
        'cmdFunc12
        '
        Me.cmdFunc12.Image = Global.FMS.My.Resources.Resources._imgLog_Out32x32
        Me.cmdFunc12.Location = New System.Drawing.Point(568, 491)
        Me.cmdFunc12.Text = "ï¬Ç∂ÇÈ(F12)"
        '
        'cmdFunc11
        '
        Me.cmdFunc11.Location = New System.Drawing.Point(366, 493)
        Me.cmdFunc11.Size = New System.Drawing.Size(31, 42)
        '
        'cmdFunc10
        '
        Me.cmdFunc10.Location = New System.Drawing.Point(329, 493)
        Me.cmdFunc10.Size = New System.Drawing.Size(31, 42)
        '
        'cmdFunc7
        '
        Me.cmdFunc7.Location = New System.Drawing.Point(219, 493)
        Me.cmdFunc7.Size = New System.Drawing.Size(33, 42)
        '
        'cmdFunc9
        '
        Me.cmdFunc9.Location = New System.Drawing.Point(292, 493)
        Me.cmdFunc9.Size = New System.Drawing.Size(31, 42)
        '
        'cmdFunc8
        '
        Me.cmdFunc8.Location = New System.Drawing.Point(255, 493)
        Me.cmdFunc8.Size = New System.Drawing.Size(31, 42)
        '
        'lblTytle
        '
        Me.lblTytle.Font = New System.Drawing.Font("Meiryo UI", 24.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTytle.ForeColor = System.Drawing.SystemColors.ControlText
        Me.lblTytle.Size = New System.Drawing.Size(760, 45)
        Me.lblTytle.Text = "å¥àˆï™êÕãÊï™ÇÃëIë(óvàˆ:XXX)"
        '
        'ToolTip
        '
        Me.ToolTip.InitialDelay = 700
        '
        'dgvDATA
        '
        DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle1.Font = New System.Drawing.Font("MS UI Gothic", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        DataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgvDATA.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle1
        Me.dgvDATA.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle2.Font = New System.Drawing.Font("MS UI Gothic", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        DataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.dgvDATA.DefaultCellStyle = DataGridViewCellStyle2
        Me.dgvDATA.Location = New System.Drawing.Point(12, 91)
        Me.dgvDATA.Name = "dgvDATA"
        DataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle3.Font = New System.Drawing.Font("MS UI Gothic", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        DataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgvDATA.RowHeadersDefaultCellStyle = DataGridViewCellStyle3
        Me.dgvDATA.RowTemplate.Height = 21
        Me.dgvDATA.Size = New System.Drawing.Size(760, 348)
        Me.dgvDATA.TabIndex = 63
        '
        'Label11
        '
        Me.Label11.Font = New System.Drawing.Font("Meiryo UI", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label11.Location = New System.Drawing.Point(12, 57)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(39, 30)
        Me.Label11.TabIndex = 77
        Me.Label11.Text = "óvàˆ:"
        Me.Label11.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'mtxYOIN_NAME
        '
        Me.mtxYOIN_NAME.BackColor = System.Drawing.SystemColors.Control
        Me.mtxYOIN_NAME.Font = New System.Drawing.Font("Meiryo UI", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.mtxYOIN_NAME.GotFocusedColor = System.Drawing.Color.FromArgb(CType(CType(190, Byte), Integer), CType(CType(180, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.mtxYOIN_NAME.ImeMode = System.Windows.Forms.ImeMode.Disable
        Me.mtxYOIN_NAME.InputRequired = False
        Me.mtxYOIN_NAME.Location = New System.Drawing.Point(57, 61)
        Me.mtxYOIN_NAME.MaxByteLength = 0
        Me.mtxYOIN_NAME.Name = "mtxYOIN_NAME"
        Me.mtxYOIN_NAME.ReadOnly = True
        Me.mtxYOIN_NAME.Size = New System.Drawing.Size(156, 24)
        Me.mtxYOIN_NAME.TabIndex = 105
        Me.mtxYOIN_NAME.WatermarkColor = System.Drawing.Color.Empty
        Me.mtxYOIN_NAME.WatermarkText = Nothing
        '
        'FrmG0014
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.ClientSize = New System.Drawing.Size(784, 562)
        Me.Controls.Add(Me.mtxYOIN_NAME)
        Me.Controls.Add(Me.Label11)
        Me.Controls.Add(Me.dgvDATA)
        Me.HelpButton = True
        Me.MinimumSize = New System.Drawing.Size(800, 600)
        Me.Name = "FrmG0014"
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
        Me.Controls.SetChildIndex(Me.dgvDATA, 0)
        Me.Controls.SetChildIndex(Me.Label11, 0)
        Me.Controls.SetChildIndex(Me.mtxYOIN_NAME, 0)
        CType(Me.ErrorProvider, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dgvDATA, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents dgvDATA As DataGridView
    Friend WithEvents Label11 As Label
    Friend WithEvents mtxYOIN_NAME As MaskedTextBoxEx
End Class
