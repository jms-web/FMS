
<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class FrmD010
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
        Me.SaveFileDialog = New System.Windows.Forms.SaveFileDialog()
        Me.OpenFileDialog = New System.Windows.Forms.OpenFileDialog()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.gbxFilter = New System.Windows.Forms.GroupBox()
        Me.tlpFilter = New System.Windows.Forms.TableLayoutPanel()
        Me.mtxTANTO_CD = New JMS_COMMON.MaskedTextBoxEx()
        Me.chkDeletedRowVisibled = New System.Windows.Forms.CheckBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.mtxTANTO_NAME = New JMS_COMMON.MaskedTextBoxEx()
        Me.mtxTANTO_NAME_KANA = New JMS_COMMON.MaskedTextBoxEx()
        Me.dgvDATA = New System.Windows.Forms.DataGridView()
        Me.gbxFilter.SuspendLayout()
        Me.tlpFilter.SuspendLayout()
        CType(Me.dgvDATA, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'lblRecordCount
        '
        Me.lblRecordCount.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.lblRecordCount.Location = New System.Drawing.Point(12, 627)
        Me.lblRecordCount.TabStop = False
        '
        'cmdFunc1
        '
        Me.cmdFunc1.Image = Global.KTS.My.Resources.Resources._imgSearch32x32
        Me.cmdFunc1.Location = New System.Drawing.Point(12, 657)
        Me.cmdFunc1.Text = "åüçı(F1)"
        '
        'cmdFunc2
        '
        Me.cmdFunc2.Image = Global.KTS.My.Resources.Resources._imgStatusAnnotations_Complete_and_ok_32x32
        Me.cmdFunc2.Location = New System.Drawing.Point(221, 657)
        Me.cmdFunc2.Text = "ëIë(F2)"
        '
        'cmdFunc3
        '
        Me.cmdFunc3.Location = New System.Drawing.Point(430, 657)
        '
        'cmdFunc4
        '
        Me.cmdFunc4.Location = New System.Drawing.Point(639, 657)
        Me.cmdFunc4.Size = New System.Drawing.Size(10, 42)
        '
        'cmdFunc5
        '
        Me.cmdFunc5.Location = New System.Drawing.Point(655, 657)
        Me.cmdFunc5.Size = New System.Drawing.Size(10, 42)
        '
        'cmdFunc6
        '
        Me.cmdFunc6.Location = New System.Drawing.Point(671, 657)
        Me.cmdFunc6.Size = New System.Drawing.Size(10, 42)
        '
        'cmdFunc12
        '
        Me.cmdFunc12.Image = Global.KTS.My.Resources.Resources._imgLog_Out32x32
        Me.cmdFunc12.Location = New System.Drawing.Point(1057, 657)
        Me.cmdFunc12.Text = "ï¬Ç∂ÇÈ(F12)"
        '
        'cmdFunc11
        '
        Me.cmdFunc11.Location = New System.Drawing.Point(751, 657)
        Me.cmdFunc11.Size = New System.Drawing.Size(10, 42)
        '
        'cmdFunc10
        '
        Me.cmdFunc10.Location = New System.Drawing.Point(735, 657)
        Me.cmdFunc10.Size = New System.Drawing.Size(10, 42)
        '
        'cmdFunc7
        '
        Me.cmdFunc7.Location = New System.Drawing.Point(687, 657)
        Me.cmdFunc7.Size = New System.Drawing.Size(10, 42)
        '
        'cmdFunc9
        '
        Me.cmdFunc9.Location = New System.Drawing.Point(719, 657)
        Me.cmdFunc9.Size = New System.Drawing.Size(10, 42)
        '
        'cmdFunc8
        '
        Me.cmdFunc8.Location = New System.Drawing.Point(703, 657)
        Me.cmdFunc8.Size = New System.Drawing.Size(10, 42)
        '
        'lblTytle
        '
        Me.lblTytle.Font = New System.Drawing.Font("Meiryo UI", 24.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTytle.Text = "íSìñé“É}ÉXÉ^"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Label3.Font = New System.Drawing.Font("Meiryo UI", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label3.Location = New System.Drawing.Point(3, 0)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(74, 30)
        Me.Label3.TabIndex = 54
        Me.Label3.Text = "íSìñé“CD"
        Me.Label3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'gbxFilter
        '
        Me.gbxFilter.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.gbxFilter.Controls.Add(Me.tlpFilter)
        Me.gbxFilter.Font = New System.Drawing.Font("Meiryo UI", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.gbxFilter.Location = New System.Drawing.Point(14, 60)
        Me.gbxFilter.Name = "gbxFilter"
        Me.gbxFilter.Size = New System.Drawing.Size(1236, 60)
        Me.gbxFilter.TabIndex = 59
        Me.gbxFilter.TabStop = False
        Me.gbxFilter.Text = "åüçıèåè"
        '
        'tlpFilter
        '
        Me.tlpFilter.ColumnCount = 11
        Me.tlpFilter.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 80.0!))
        Me.tlpFilter.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 160.0!))
        Me.tlpFilter.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 10.0!))
        Me.tlpFilter.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 80.0!))
        Me.tlpFilter.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 160.0!))
        Me.tlpFilter.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 10.0!))
        Me.tlpFilter.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 100.0!))
        Me.tlpFilter.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 160.0!))
        Me.tlpFilter.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 10.0!))
        Me.tlpFilter.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.tlpFilter.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 110.0!))
        Me.tlpFilter.Controls.Add(Me.mtxTANTO_CD, 0, 0)
        Me.tlpFilter.Controls.Add(Me.Label3, 0, 0)
        Me.tlpFilter.Controls.Add(Me.chkDeletedRowVisibled, 10, 0)
        Me.tlpFilter.Controls.Add(Me.Label1, 6, 0)
        Me.tlpFilter.Controls.Add(Me.Label2, 3, 0)
        Me.tlpFilter.Controls.Add(Me.mtxTANTO_NAME, 4, 0)
        Me.tlpFilter.Controls.Add(Me.mtxTANTO_NAME_KANA, 7, 0)
        Me.tlpFilter.Dock = System.Windows.Forms.DockStyle.Fill
        Me.tlpFilter.Location = New System.Drawing.Point(3, 20)
        Me.tlpFilter.Name = "tlpFilter"
        Me.tlpFilter.RowCount = 2
        Me.tlpFilter.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30.0!))
        Me.tlpFilter.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.tlpFilter.Size = New System.Drawing.Size(1230, 37)
        Me.tlpFilter.TabIndex = 56
        '
        'mtxTANTO_CD
        '
        Me.mtxTANTO_CD.Dock = System.Windows.Forms.DockStyle.Fill
        Me.mtxTANTO_CD.Font = New System.Drawing.Font("Meiryo UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.mtxTANTO_CD.ImeMode = System.Windows.Forms.ImeMode.[On]
        Me.mtxTANTO_CD.Location = New System.Drawing.Point(83, 3)
        Me.mtxTANTO_CD.MaxByteLength = 100
        Me.mtxTANTO_CD.Name = "mtxTANTO_CD"
        Me.mtxTANTO_CD.Size = New System.Drawing.Size(154, 24)
        Me.mtxTANTO_CD.TabIndex = 0
        '
        'chkDeletedRowVisibled
        '
        Me.chkDeletedRowVisibled.AutoSize = True
        Me.chkDeletedRowVisibled.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.chkDeletedRowVisibled.Cursor = System.Windows.Forms.Cursors.Hand
        Me.chkDeletedRowVisibled.Dock = System.Windows.Forms.DockStyle.Fill
        Me.chkDeletedRowVisibled.Font = New System.Drawing.Font("Meiryo UI", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.chkDeletedRowVisibled.Location = New System.Drawing.Point(1123, 3)
        Me.chkDeletedRowVisibled.Name = "chkDeletedRowVisibled"
        Me.chkDeletedRowVisibled.Size = New System.Drawing.Size(104, 24)
        Me.chkDeletedRowVisibled.TabIndex = 1
        Me.chkDeletedRowVisibled.Text = "çÌèúçœÇ‡ï\é¶"
        Me.chkDeletedRowVisibled.UseVisualStyleBackColor = True
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Label1.Font = New System.Drawing.Font("Meiryo UI", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label1.Location = New System.Drawing.Point(503, 0)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(94, 30)
        Me.Label1.TabIndex = 55
        Me.Label1.Text = "íSìñé“ñºÉJÉi"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Label2.Font = New System.Drawing.Font("Meiryo UI", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label2.Location = New System.Drawing.Point(253, 0)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(74, 30)
        Me.Label2.TabIndex = 56
        Me.Label2.Text = "íSìñé“ñº"
        Me.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'mtxTANTO_NAME
        '
        Me.mtxTANTO_NAME.Dock = System.Windows.Forms.DockStyle.Fill
        Me.mtxTANTO_NAME.Font = New System.Drawing.Font("Meiryo UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.mtxTANTO_NAME.ImeMode = System.Windows.Forms.ImeMode.[On]
        Me.mtxTANTO_NAME.Location = New System.Drawing.Point(333, 3)
        Me.mtxTANTO_NAME.MaxByteLength = 100
        Me.mtxTANTO_NAME.Name = "mtxTANTO_NAME"
        Me.mtxTANTO_NAME.Size = New System.Drawing.Size(154, 24)
        Me.mtxTANTO_NAME.TabIndex = 57
        '
        'mtxTANTO_NAME_KANA
        '
        Me.mtxTANTO_NAME_KANA.Dock = System.Windows.Forms.DockStyle.Fill
        Me.mtxTANTO_NAME_KANA.Font = New System.Drawing.Font("Meiryo UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.mtxTANTO_NAME_KANA.ImeMode = System.Windows.Forms.ImeMode.[On]
        Me.mtxTANTO_NAME_KANA.Location = New System.Drawing.Point(603, 3)
        Me.mtxTANTO_NAME_KANA.MaxByteLength = 100
        Me.mtxTANTO_NAME_KANA.Name = "mtxTANTO_NAME_KANA"
        Me.mtxTANTO_NAME_KANA.Size = New System.Drawing.Size(154, 24)
        Me.mtxTANTO_NAME_KANA.TabIndex = 58
        '
        'dgvDATA
        '
        Me.dgvDATA.AllowUserToAddRows = False
        Me.dgvDATA.AllowUserToDeleteRows = False
        Me.dgvDATA.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.dgvDATA.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvDATA.Location = New System.Drawing.Point(12, 126)
        Me.dgvDATA.Name = "dgvDATA"
        Me.dgvDATA.ReadOnly = True
        Me.dgvDATA.RowTemplate.Height = 21
        Me.dgvDATA.Size = New System.Drawing.Size(1240, 495)
        Me.dgvDATA.TabIndex = 60
        '
        'FrmD010
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.ClientSize = New System.Drawing.Size(1264, 711)
        Me.Controls.Add(Me.dgvDATA)
        Me.Controls.Add(Me.gbxFilter)
        Me.HelpButton = True
        Me.MinimumSize = New System.Drawing.Size(1280, 400)
        Me.Name = "FrmD010"
        Me.ShowStatusBar = True
        Me.Text = ""
        Me.Controls.SetChildIndex(Me.lblRecordCount, 0)
        Me.Controls.SetChildIndex(Me.gbxFilter, 0)
        Me.Controls.SetChildIndex(Me.dgvDATA, 0)
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
        Me.gbxFilter.ResumeLayout(False)
        Me.tlpFilter.ResumeLayout(False)
        Me.tlpFilter.PerformLayout()
        CType(Me.dgvDATA, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents SaveFileDialog As System.Windows.Forms.SaveFileDialog
    Friend WithEvents OpenFileDialog As System.Windows.Forms.OpenFileDialog
    Friend WithEvents Label3 As Label
    Friend WithEvents gbxFilter As GroupBox
    Public WithEvents dgvDATA As DataGridView
    Friend WithEvents chkDeletedRowVisibled As CheckBox
    Friend WithEvents tlpFilter As TableLayoutPanel
    Friend WithEvents mtxTANTO_CD As MaskedTextBoxEx
    Friend WithEvents Label1 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents mtxTANTO_NAME As MaskedTextBoxEx
    Friend WithEvents mtxTANTO_NAME_KANA As MaskedTextBoxEx
End Class
