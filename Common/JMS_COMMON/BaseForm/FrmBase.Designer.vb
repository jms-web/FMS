<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmBase
    Inherits System.Windows.Forms.Form

    'フォームがコンポーネントの一覧をクリーンアップするために dispose をオーバーライドします。
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
        Me.components = New System.ComponentModel.Container()
        Me.lblTytle = New System.Windows.Forms.Label()
        Me.ToolTip = New System.Windows.Forms.ToolTip(Me.components)
        Me.ErrorProvider = New System.Windows.Forms.ErrorProvider(Me.components)
        CType(Me.ErrorProvider, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'lblTytle
        '
        Me.lblTytle.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblTytle.BackColor = System.Drawing.Color.DeepSkyBlue
        Me.lblTytle.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblTytle.Font = New System.Drawing.Font("Meiryo UI", 24.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.lblTytle.Location = New System.Drawing.Point(12, 12)
        Me.lblTytle.Margin = New System.Windows.Forms.Padding(3, 3, 3, 0)
        Me.lblTytle.Name = "lblTytle"
        Me.lblTytle.Size = New System.Drawing.Size(984, 45)
        Me.lblTytle.TabIndex = 0
        Me.lblTytle.Text = "○○システム"
        Me.lblTytle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'ToolTip
        '
        Me.ToolTip.AutoPopDelay = 5000
        Me.ToolTip.InitialDelay = 500
        Me.ToolTip.ReshowDelay = 100
        Me.ToolTip.ToolTipIcon = System.Windows.Forms.ToolTipIcon.Info
        Me.ToolTip.ToolTipTitle = "使用不可"
        '
        'ErrorProvider
        '
        Me.ErrorProvider.ContainerControl = Me
        '
        'FrmBase
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1008, 711)
        Me.Controls.Add(Me.lblTytle)
        Me.KeyPreview = True
        Me.MinimumSize = New System.Drawing.Size(1024, 750)
        Me.Name = "FrmBase"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = " "
        CType(Me.ErrorProvider, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Protected WithEvents lblTytle As Label
    Public WithEvents ToolTip As ToolTip
    Public WithEvents ErrorProvider As ErrorProvider

    Protected Overrides ReadOnly Property CreateParams() As System.Windows.Forms.CreateParams
        Get
            Const CS_NOCLOSE As Integer = &H200
            Dim cp As System.Windows.Forms.CreateParams = MyBase.CreateParams
            cp.ClassStyle = cp.ClassStyle Or CS_NOCLOSE

            Return cp
        End Get
    End Property

End Class
