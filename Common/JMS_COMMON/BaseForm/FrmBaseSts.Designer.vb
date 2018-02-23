<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class FrmBaseSts
    Inherits JMS_COMMON.FrmBase

    'フォームがコンポーネントの一覧をクリーンアップするために dispose をオーバーライドします。
    <System.Diagnostics.DebuggerNonUserCode()>
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
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Me.StatusStrip = New System.Windows.Forms.StatusStrip()
        Me.ToolStripStatusLabelVERSION = New System.Windows.Forms.ToolStripStatusLabel()
        Me.ToolStripStatusLabelPCNAME = New System.Windows.Forms.ToolStripStatusLabel()
        Me.ToolStripStatusLabelBLANK = New System.Windows.Forms.ToolStripStatusLabel()
        Me.TimerTime = New System.Windows.Forms.Timer(Me.components)
        CType(Me.ErrorProvider, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.StatusStrip.SuspendLayout()
        Me.SuspendLayout()
        '
        'lblTytle
        '
        Me.lblTytle.Size = New System.Drawing.Size(1240, 45)
        '
        'ErrorProvider
        '
        Me.ErrorProvider.BlinkStyle = System.Windows.Forms.ErrorBlinkStyle.NeverBlink
        '
        'StatusStrip
        '
        Me.StatusStrip.BackColor = System.Drawing.SystemColors.Control
        Me.StatusStrip.Font = New System.Drawing.Font("Meiryo UI", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.StatusStrip.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripStatusLabelVERSION, Me.ToolStripStatusLabelPCNAME, Me.ToolStripStatusLabelBLANK})
        Me.StatusStrip.Location = New System.Drawing.Point(0, 685)
        Me.StatusStrip.Name = "StatusStrip"
        Me.StatusStrip.Size = New System.Drawing.Size(1264, 26)
        Me.StatusStrip.TabIndex = 2
        Me.StatusStrip.Text = "StatusStrip1"
        '
        'ToolStripStatusLabelVERSION
        '
        Me.ToolStripStatusLabelVERSION.ActiveLinkColor = System.Drawing.Color.Black
        Me.ToolStripStatusLabelVERSION.AutoSize = False
        Me.ToolStripStatusLabelVERSION.BorderSides = CType((((System.Windows.Forms.ToolStripStatusLabelBorderSides.Left Or System.Windows.Forms.ToolStripStatusLabelBorderSides.Top) _
            Or System.Windows.Forms.ToolStripStatusLabelBorderSides.Right) _
            Or System.Windows.Forms.ToolStripStatusLabelBorderSides.Bottom), System.Windows.Forms.ToolStripStatusLabelBorderSides)
        Me.ToolStripStatusLabelVERSION.BorderStyle = System.Windows.Forms.Border3DStyle.SunkenOuter
        Me.ToolStripStatusLabelVERSION.Font = New System.Drawing.Font("Meiryo UI", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.ToolStripStatusLabelVERSION.IsLink = True
        Me.ToolStripStatusLabelVERSION.LinkBehavior = System.Windows.Forms.LinkBehavior.NeverUnderline
        Me.ToolStripStatusLabelVERSION.LinkColor = System.Drawing.Color.Black
        Me.ToolStripStatusLabelVERSION.Margin = New System.Windows.Forms.Padding(0, 3, 0, 0)
        Me.ToolStripStatusLabelVERSION.Name = "ToolStripStatusLabelVERSION"
        Me.ToolStripStatusLabelVERSION.Size = New System.Drawing.Size(125, 23)
        Me.ToolStripStatusLabelVERSION.Text = "Ver 0.00.00.00"
        '
        'ToolStripStatusLabelPCNAME
        '
        Me.ToolStripStatusLabelPCNAME.AutoSize = False
        Me.ToolStripStatusLabelPCNAME.BorderSides = CType((((System.Windows.Forms.ToolStripStatusLabelBorderSides.Left Or System.Windows.Forms.ToolStripStatusLabelBorderSides.Top) _
            Or System.Windows.Forms.ToolStripStatusLabelBorderSides.Right) _
            Or System.Windows.Forms.ToolStripStatusLabelBorderSides.Bottom), System.Windows.Forms.ToolStripStatusLabelBorderSides)
        Me.ToolStripStatusLabelPCNAME.BorderStyle = System.Windows.Forms.Border3DStyle.SunkenOuter
        Me.ToolStripStatusLabelPCNAME.Font = New System.Drawing.Font("Meiryo UI", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.ToolStripStatusLabelPCNAME.Margin = New System.Windows.Forms.Padding(0, 3, 0, 0)
        Me.ToolStripStatusLabelPCNAME.Name = "ToolStripStatusLabelPCNAME"
        Me.ToolStripStatusLabelPCNAME.Size = New System.Drawing.Size(190, 23)
        Me.ToolStripStatusLabelPCNAME.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'ToolStripStatusLabelBLANK
        '
        Me.ToolStripStatusLabelBLANK.AutoSize = False
        Me.ToolStripStatusLabelBLANK.BorderSides = CType((((System.Windows.Forms.ToolStripStatusLabelBorderSides.Left Or System.Windows.Forms.ToolStripStatusLabelBorderSides.Top) _
            Or System.Windows.Forms.ToolStripStatusLabelBorderSides.Right) _
            Or System.Windows.Forms.ToolStripStatusLabelBorderSides.Bottom), System.Windows.Forms.ToolStripStatusLabelBorderSides)
        Me.ToolStripStatusLabelBLANK.BorderStyle = System.Windows.Forms.Border3DStyle.SunkenOuter
        Me.ToolStripStatusLabelBLANK.Font = New System.Drawing.Font("Meiryo UI", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.ToolStripStatusLabelBLANK.Margin = New System.Windows.Forms.Padding(0, 3, 0, 0)
        Me.ToolStripStatusLabelBLANK.Name = "ToolStripStatusLabelBLANK"
        Me.ToolStripStatusLabelBLANK.Size = New System.Drawing.Size(520, 23)
        Me.ToolStripStatusLabelBLANK.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'TimerTime
        '
        Me.TimerTime.Enabled = True
        Me.TimerTime.Interval = 1000
        '
        'FrmBaseSts
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1264, 711)
        Me.Controls.Add(Me.StatusStrip)
        Me.Name = "FrmBaseSts"
        Me.ShowIcon = False
        Me.Controls.SetChildIndex(Me.StatusStrip, 0)
        Me.Controls.SetChildIndex(Me.lblTytle, 0)
        CType(Me.ErrorProvider, System.ComponentModel.ISupportInitialize).EndInit()
        Me.StatusStrip.ResumeLayout(False)
        Me.StatusStrip.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub


    Protected Overrides ReadOnly Property CreateParams() As System.Windows.Forms.CreateParams
        Get
            Const CS_NOCLOSE As Integer = &H200
            Dim cp As System.Windows.Forms.CreateParams = MyBase.CreateParams
            cp.ClassStyle = cp.ClassStyle Or CS_NOCLOSE

            Return cp
        End Get
    End Property

    Protected WithEvents ToolStripStatusLabelVERSION As System.Windows.Forms.ToolStripStatusLabel
    Protected WithEvents ToolStripStatusLabelBLANK As System.Windows.Forms.ToolStripStatusLabel
    Protected WithEvents ToolStripStatusLabelPCNAME As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents TimerTime As Timer
    Public WithEvents StatusStrip As StatusStrip
End Class
