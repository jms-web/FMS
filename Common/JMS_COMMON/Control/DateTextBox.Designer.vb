<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class DateTextBox
    Inherits System.Windows.Forms.UserControl

    'UserControl1 は、コンポーネント一覧に後処理を実行するために dispose をオーバーライドします。
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

    'Windows フォーム デザイナで必要です。
    Private components As System.ComponentModel.IContainer

    'メモ: 以下のプロシージャは Windows フォーム デザイナで必要です。
    'Windows フォーム デザイナを使用して変更できます。  
    'コード エディタを使って変更しないでください。
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.MaskedTextBox1 = New MaskedTextBox
        Me.DateTimePicker1 = New System.Windows.Forms.DateTimePicker
        Me.SuspendLayout()
        '
        'MaskedTextBox1
        '
        Me.MaskedTextBox1.BorderStyle = System.Windows.Forms.BorderStyle.None
        'Me.MaskedTextBox1.Font = New System.Drawing.Font("ＭＳ ゴシック", 14.25!, System.Drawing.FontStyle.Bold)
        Me.MaskedTextBox1.Location = New System.Drawing.Point(5, 6)
        Me.MaskedTextBox1.Margin = New System.Windows.Forms.Padding(6, 5, 6, 5)
        Me.MaskedTextBox1.Mask = "0000/00/00"
        Me.MaskedTextBox1.Name = "MaskedTextBox1"
        Me.MaskedTextBox1.Size = New System.Drawing.Size(114, 19)
        Me.MaskedTextBox1.TabIndex = 0
        Me.MaskedTextBox1.TextMaskFormat = System.Windows.Forms.MaskFormat.IncludePromptAndLiterals
        Me.MaskedTextBox1.ValidatingType = GetType(Date)
        '
        'DateTimePicker1
        '
        Me.DateTimePicker1.CustomFormat = "yyyy/MM/dd"
        Me.DateTimePicker1.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.DateTimePicker1.Location = New System.Drawing.Point(2, 2)
        Me.DateTimePicker1.Name = "DateTimePicker1"
        Me.DateTimePicker1.Size = New System.Drawing.Size(137, 26)
        Me.DateTimePicker1.TabIndex = 1
        Me.DateTimePicker1.Value = New Date(2000, 1, 1, 12, 34, 0, 0)
        '
        'DateTextBox
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(11.0!, 19.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.Controls.Add(Me.MaskedTextBox1)
        Me.Controls.Add(Me.DateTimePicker1)
        'Me.Font = New System.Drawing.Font("ＭＳ ゴシック", 14.25!, System.Drawing.FontStyle.Bold)
        Me.Margin = New System.Windows.Forms.Padding(6, 5, 6, 5)
        Me.Name = "DateTextBox"
        Me.Size = New System.Drawing.Size(144, 33)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents MaskedTextBox1 As MaskedTextBox
    Friend WithEvents DateTimePicker1 As System.Windows.Forms.DateTimePicker

End Class
