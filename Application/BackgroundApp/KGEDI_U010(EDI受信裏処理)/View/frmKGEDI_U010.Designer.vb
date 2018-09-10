<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmKGEDI_U010
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

    'Windows フォーム デザイナーで必要です。
    Private components As System.ComponentModel.IContainer

    'メモ: 以下のプロシージャは Windows フォーム デザイナーで必要です。
    'Windows フォーム デザイナーを使用して変更できます。  
    'コード エディターを使って変更しないでください。
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmKGEDI_U010))
        Me.tskIcon = New System.Windows.Forms.NotifyIcon(Me.components)
        Me.ContextMenuStrip1 = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.CancelToopStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ENDToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.lblMessage = New System.Windows.Forms.Label()
        Me.dgvDATA = New System.Windows.Forms.DataGridView()
        Me.bgWorker = New System.ComponentModel.BackgroundWorker()
        Me.tmrGET_DELFOR = New System.Windows.Forms.Timer(Me.components)
        Me.tmrGET_RECADV = New System.Windows.Forms.Timer(Me.components)
        Me.tmrGET_DELJIT = New System.Windows.Forms.Timer(Me.components)
        Me.tmrOUTPUT_FILE = New System.Windows.Forms.Timer(Me.components)
        Me.tmrINPUT_FILE = New System.Windows.Forms.Timer(Me.components)
        Me.tmrGET_DESADV = New System.Windows.Forms.Timer(Me.components)
        Me.tmrRECV_FILE = New System.Windows.Forms.Timer(Me.components)
        Me.Smtp1 = New Dart.PowerTCP.SecureMail.Smtp(Me.components)
        Me.ContextMenuStrip1.SuspendLayout()
        CType(Me.dgvDATA, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'tskIcon
        '
        Me.tskIcon.ContextMenuStrip = Me.ContextMenuStrip1
        Me.tskIcon.Icon = CType(resources.GetObject("tskIcon.Icon"), System.Drawing.Icon)
        Me.tskIcon.Text = "共通EDI受信システム"
        Me.tskIcon.Visible = True
        '
        'ContextMenuStrip1
        '
        Me.ContextMenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.CancelToopStripMenuItem, Me.ENDToolStripMenuItem})
        Me.ContextMenuStrip1.Name = "ContextMenuStrip1"
        Me.ContextMenuStrip1.Size = New System.Drawing.Size(122, 48)
        '
        'CancelToopStripMenuItem
        '
        Me.CancelToopStripMenuItem.Name = "CancelToopStripMenuItem"
        Me.CancelToopStripMenuItem.Size = New System.Drawing.Size(121, 22)
        Me.CancelToopStripMenuItem.Text = "CANCEL"
        Me.CancelToopStripMenuItem.Visible = False
        '
        'ENDToolStripMenuItem
        '
        Me.ENDToolStripMenuItem.Name = "ENDToolStripMenuItem"
        Me.ENDToolStripMenuItem.Size = New System.Drawing.Size(121, 22)
        Me.ENDToolStripMenuItem.Text = "終了"
        '
        'lblMessage
        '
        Me.lblMessage.BackColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.lblMessage.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblMessage.Font = New System.Drawing.Font("HG丸ｺﾞｼｯｸM-PRO", 20.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.lblMessage.Location = New System.Drawing.Point(10, 9)
        Me.lblMessage.Name = "lblMessage"
        Me.lblMessage.Size = New System.Drawing.Size(930, 120)
        Me.lblMessage.TabIndex = 1
        Me.lblMessage.Text = "EDIデータ受信"
        Me.lblMessage.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'dgvDATA
        '
        Me.dgvDATA.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvDATA.Location = New System.Drawing.Point(59, 106)
        Me.dgvDATA.Name = "dgvDATA"
        Me.dgvDATA.RowTemplate.Height = 21
        Me.dgvDATA.Size = New System.Drawing.Size(67, 34)
        Me.dgvDATA.TabIndex = 2
        '
        'bgWorker
        '
        Me.bgWorker.WorkerReportsProgress = True
        Me.bgWorker.WorkerSupportsCancellation = True
        '
        'tmrGET_DELFOR
        '
        Me.tmrGET_DELFOR.Interval = 3000
        '
        'tmrGET_RECADV
        '
        Me.tmrGET_RECADV.Interval = 3000
        '
        'tmrGET_DELJIT
        '
        Me.tmrGET_DELJIT.Interval = 3000
        '
        'tmrOUTPUT_FILE
        '
        Me.tmrOUTPUT_FILE.Interval = 3000
        '
        'tmrINPUT_FILE
        '
        Me.tmrINPUT_FILE.Interval = 3000
        '
        'tmrGET_DESADV
        '
        Me.tmrGET_DESADV.Interval = 3000
        '
        'tmrRECV_FILE
        '
        Me.tmrRECV_FILE.Interval = 3000
        '
        'Smtp1
        '
        Me.Smtp1.DnsServers = CType(resources.GetObject("Smtp1.DnsServers"), System.Collections.Specialized.StringCollection)
        Me.Smtp1.DnsServerTimeout = 3000
        Me.Smtp1.Editor = Me.Smtp1
        Me.Smtp1.HelloName = "fsystem"
        Me.Smtp1.LoginMethod = Dart.PowerTCP.SecureMail.SmtpLoginMethod.[Auto]
        Me.Smtp1.MailFrom = Nothing
        '
        'frmKGEDI_U010
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(952, 138)
        Me.ControlBox = False
        Me.Controls.Add(Me.lblMessage)
        Me.Controls.Add(Me.dgvDATA)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "frmKGEDI_U010"
        Me.ShowInTaskbar = False
        Me.Text = "EDIデータ受信"
        Me.WindowState = System.Windows.Forms.FormWindowState.Minimized
        Me.ContextMenuStrip1.ResumeLayout(False)
        CType(Me.dgvDATA, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents tskIcon As System.Windows.Forms.NotifyIcon
    Friend WithEvents ContextMenuStrip1 As System.Windows.Forms.ContextMenuStrip
    Friend WithEvents ENDToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents lblMessage As System.Windows.Forms.Label
    Friend WithEvents dgvDATA As System.Windows.Forms.DataGridView
    Friend WithEvents bgWorker As System.ComponentModel.BackgroundWorker
    Friend WithEvents CancelToopStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Public WithEvents tmrGET_DELFOR As System.Windows.Forms.Timer
    Public WithEvents tmrGET_RECADV As System.Windows.Forms.Timer
    Public WithEvents tmrGET_DELJIT As System.Windows.Forms.Timer
    Public WithEvents tmrOUTPUT_FILE As System.Windows.Forms.Timer
    Public WithEvents tmrINPUT_FILE As System.Windows.Forms.Timer
    Public WithEvents tmrGET_DESADV As System.Windows.Forms.Timer
    Public WithEvents tmrRECV_FILE As System.Windows.Forms.Timer
    Friend WithEvents Smtp1 As Dart.PowerTCP.SecureMail.Smtp

End Class
