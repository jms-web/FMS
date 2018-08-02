<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class FrmM0040
    Inherits JMS_COMMON.frmBaseStsBtnDgv

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
        Me.mtxTANTO_NAME = New JMS_COMMON.MaskedTextBoxEx()
        Me.chkDeletedRowVisibled = New System.Windows.Forms.CheckBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.cmbSYOKUBAN = New JMS_COMMON.ComboboxEx()
        Me.dgvDATA = New System.Windows.Forms.DataGridView()
        CType(Me.ErrorProvider, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.gbxFilter.SuspendLayout()
        Me.tlpFilter.SuspendLayout()
        CType(Me.dgvDATA, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'lblRecordCount
        '
        Me.lblRecordCount.Location = New System.Drawing.Point(14, 566)
        '
        'cmdFunc1
        '
        Me.cmdFunc1.Image = Global.FMS.My.Resources.Resources._imgSearch32x32
        Me.cmdFunc1.Location = New System.Drawing.Point(9, 596)
        Me.cmdFunc1.Text = "検索(F1)"
        '
        'cmdFunc2
        '
        Me.cmdFunc2.Image = Global.FMS.My.Resources.Resources._imgApplication_form_add32x32
        Me.cmdFunc2.Location = New System.Drawing.Point(219, 596)
        Me.cmdFunc2.Text = "追加(F2)"
        '
        'cmdFunc3
        '
        Me.cmdFunc3.Image = Global.FMS.My.Resources.Resources._imgApplication_form_add32x32
        Me.cmdFunc3.Location = New System.Drawing.Point(429, 596)
        Me.cmdFunc3.Text = "類似追加(F3)"
        '
        'cmdFunc4
        '
        Me.cmdFunc4.Image = Global.FMS.My.Resources.Resources._imgApplication_form_edit32x32
        Me.cmdFunc4.Location = New System.Drawing.Point(635, 596)
        Me.cmdFunc4.Text = "変更(F4)"
        '
        'cmdFunc5
        '
        Me.cmdFunc5.Image = Global.FMS.My.Resources.Resources._imgStatusAnnotations_Blocked_32x32_MD
        Me.cmdFunc5.Location = New System.Drawing.Point(845, 596)
        Me.cmdFunc5.Size = New System.Drawing.Size(207, 42)
        Me.cmdFunc5.Text = "削除(F5)"
        '
        'cmdFunc6
        '
        Me.cmdFunc6.Image = Global.FMS.My.Resources.Resources._imgRecovery32x32
        Me.cmdFunc6.Location = New System.Drawing.Point(1058, 596)
        Me.cmdFunc6.Size = New System.Drawing.Size(192, 42)
        Me.cmdFunc6.Text = "復元(F6)"
        '
        'cmdFunc12
        '
        Me.cmdFunc12.Image = Global.FMS.My.Resources.Resources._imgLog_Out32x32
        Me.cmdFunc12.Location = New System.Drawing.Point(1058, 644)
        Me.cmdFunc12.Size = New System.Drawing.Size(194, 42)
        Me.cmdFunc12.Text = "閉じる(F12)"
        '
        'cmdFunc11
        '
        Me.cmdFunc11.Location = New System.Drawing.Point(845, 644)
        '
        'cmdFunc10
        '
        Me.cmdFunc10.Image = Global.FMS.My.Resources.Resources._imgExportToExcel32x32
        Me.cmdFunc10.Location = New System.Drawing.Point(635, 644)
        Me.cmdFunc10.Text = "CSV出力(F10)"
        '
        'cmdFunc7
        '
        Me.cmdFunc7.Location = New System.Drawing.Point(9, 644)
        '
        'cmdFunc9
        '
        Me.cmdFunc9.Location = New System.Drawing.Point(429, 644)
        '
        'cmdFunc8
        '
        Me.cmdFunc8.Location = New System.Drawing.Point(219, 644)
        '
        'lblTytle
        '
        Me.lblTytle.Font = New System.Drawing.Font("Meiryo UI", 24.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTytle.Text = "担当者マスタ"
        '
        'ToolTip
        '
        Me.ToolTip.InitialDelay = 700
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Label3.Font = New System.Drawing.Font("Meiryo UI", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label3.Location = New System.Drawing.Point(243, 0)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(73, 30)
        Me.Label3.TabIndex = 54
        Me.Label3.Text = "担当者名"
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
        Me.gbxFilter.Text = "検索条件"
        '
        'tlpFilter
        '
        Me.tlpFilter.ColumnCount = 8
        Me.tlpFilter.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 67.0!))
        Me.tlpFilter.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 173.0!))
        Me.tlpFilter.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 79.0!))
        Me.tlpFilter.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.tlpFilter.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 113.0!))
        Me.tlpFilter.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 186.0!))
        Me.tlpFilter.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 350.0!))
        Me.tlpFilter.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 119.0!))
        Me.tlpFilter.Controls.Add(Me.mtxTANTO_NAME, 3, 0)
        Me.tlpFilter.Controls.Add(Me.Label3, 2, 0)
        Me.tlpFilter.Controls.Add(Me.chkDeletedRowVisibled, 7, 0)
        Me.tlpFilter.Controls.Add(Me.Label1, 0, 0)
        Me.tlpFilter.Controls.Add(Me.cmbSYOKUBAN, 1, 0)
        Me.tlpFilter.Dock = System.Windows.Forms.DockStyle.Fill
        Me.tlpFilter.Location = New System.Drawing.Point(3, 20)
        Me.tlpFilter.Name = "tlpFilter"
        Me.tlpFilter.RowCount = 2
        Me.tlpFilter.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30.0!))
        Me.tlpFilter.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.tlpFilter.Size = New System.Drawing.Size(1230, 37)
        Me.tlpFilter.TabIndex = 56
        '
        'mtxTANTO_NAME
        '
        Me.mtxTANTO_NAME.BackColor = System.Drawing.SystemColors.Window
        Me.mtxTANTO_NAME.Dock = System.Windows.Forms.DockStyle.Fill
        Me.mtxTANTO_NAME.Font = New System.Drawing.Font("Meiryo UI", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.mtxTANTO_NAME.GotFocusedColor = System.Drawing.Color.FromArgb(CType(CType(190, Byte), Integer), CType(CType(180, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.mtxTANTO_NAME.ImeMode = System.Windows.Forms.ImeMode.[On]
        Me.mtxTANTO_NAME.InputRequired = False
        Me.mtxTANTO_NAME.Location = New System.Drawing.Point(322, 3)
        Me.mtxTANTO_NAME.MaxByteLength = 100
        Me.mtxTANTO_NAME.Name = "mtxTANTO_NAME"
        Me.mtxTANTO_NAME.Size = New System.Drawing.Size(137, 24)
        Me.mtxTANTO_NAME.TabIndex = 0
        Me.mtxTANTO_NAME.WatermarkColor = System.Drawing.Color.Empty
        Me.mtxTANTO_NAME.WatermarkText = Nothing
        '
        'chkDeletedRowVisibled
        '
        Me.chkDeletedRowVisibled.AutoSize = True
        Me.chkDeletedRowVisibled.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.chkDeletedRowVisibled.Cursor = System.Windows.Forms.Cursors.Hand
        Me.chkDeletedRowVisibled.Dock = System.Windows.Forms.DockStyle.Fill
        Me.chkDeletedRowVisibled.Font = New System.Drawing.Font("Meiryo UI", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.chkDeletedRowVisibled.Location = New System.Drawing.Point(1114, 3)
        Me.chkDeletedRowVisibled.Name = "chkDeletedRowVisibled"
        Me.chkDeletedRowVisibled.Size = New System.Drawing.Size(113, 24)
        Me.chkDeletedRowVisibled.TabIndex = 1
        Me.chkDeletedRowVisibled.Text = "削除済も表示"
        Me.chkDeletedRowVisibled.UseVisualStyleBackColor = True
        '
        'Label1
        '
        Me.Label1.Font = New System.Drawing.Font("Meiryo UI", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label1.Location = New System.Drawing.Point(3, 0)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(61, 30)
        Me.Label1.TabIndex = 55
        Me.Label1.Text = "職番"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'cmbSYOKUBAN
        '
        Me.cmbSYOKUBAN.BackColor = System.Drawing.SystemColors.Window
        Me.cmbSYOKUBAN.Cursor = System.Windows.Forms.Cursors.Default
        Me.cmbSYOKUBAN.DisplayMember = "DISP"
        Me.cmbSYOKUBAN.Font = New System.Drawing.Font("Meiryo UI", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.cmbSYOKUBAN.ForeColor = System.Drawing.SystemColors.ControlText
        Me.cmbSYOKUBAN.FormattingEnabled = True
        Me.cmbSYOKUBAN.GotFocusedColor = System.Drawing.Color.FromArgb(CType(CType(190, Byte), Integer), CType(CType(180, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.cmbSYOKUBAN.Location = New System.Drawing.Point(70, 3)
        Me.cmbSYOKUBAN.Name = "cmbSYOKUBAN"
        Me.cmbSYOKUBAN.NullValue = " "
        Me.cmbSYOKUBAN.ReadOnly = False
        Me.cmbSYOKUBAN.Selected = False
        Me.cmbSYOKUBAN.Size = New System.Drawing.Size(121, 25)
        Me.cmbSYOKUBAN.TabIndex = 56
        Me.cmbSYOKUBAN.Text = "(選択)"
        Me.cmbSYOKUBAN.ValueMember = "VALUE"
        '
        'dgvDATA
        '
        Me.dgvDATA.AllowUserToAddRows = False
        Me.dgvDATA.AllowUserToDeleteRows = False
        Me.dgvDATA.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvDATA.Location = New System.Drawing.Point(19, 126)
        Me.dgvDATA.Name = "dgvDATA"
        Me.dgvDATA.ReadOnly = True
        Me.dgvDATA.RowTemplate.Height = 21
        Me.dgvDATA.Size = New System.Drawing.Size(1225, 436)
        Me.dgvDATA.TabIndex = 60
        '
        'FrmM0040
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.ClientSize = New System.Drawing.Size(1264, 712)
        Me.Controls.Add(Me.dgvDATA)
        Me.Controls.Add(Me.gbxFilter)
        Me.HelpButton = True
        Me.Name = "FrmM0040"
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
        Me.Controls.SetChildIndex(Me.gbxFilter, 0)
        Me.Controls.SetChildIndex(Me.dgvDATA, 0)
        CType(Me.ErrorProvider, System.ComponentModel.ISupportInitialize).EndInit()
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
    Friend WithEvents tlpFilter As TableLayoutPanel
    Friend WithEvents mtxTANTO_NAME As MaskedTextBoxEx
    Friend WithEvents chkDeletedRowVisibled As CheckBox
    Friend WithEvents Label1 As Label
    Friend WithEvents cmbSYOKUBAN As ComboboxEx
End Class
