<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class FrmM0020
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
        Me.chkDeletedRowVisibled = New System.Windows.Forms.CheckBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.CmbBUMON_KB = New JMS_COMMON.ComboboxEx()
        Me.CmbBUSYO_KB = New JMS_COMMON.ComboboxEx()
        Me.txtBUSYO_NAME = New JMS_COMMON.MaskedTextBoxEx()
        Me.txtOYA_BUSYO_NAME = New JMS_COMMON.MaskedTextBoxEx()
        Me.txtSYOZOKUCYO_SYAIN_NAME = New JMS_COMMON.MaskedTextBoxEx()
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
        Me.cmdFunc1.Text = "õ(F1)"
        '
        'cmdFunc2
        '
        Me.cmdFunc2.Image = Global.FMS.My.Resources.Resources._imgApplication_form_add32x32
        Me.cmdFunc2.Location = New System.Drawing.Point(219, 596)
        Me.cmdFunc2.Text = "ÇÁ(F2)"
        '
        'cmdFunc3
        '
        Me.cmdFunc3.Image = Global.FMS.My.Resources.Resources._imgApplication_form_add32x32
        Me.cmdFunc3.Location = New System.Drawing.Point(429, 596)
        Me.cmdFunc3.Text = "ÞÇÁ(F3)"
        '
        'cmdFunc4
        '
        Me.cmdFunc4.Image = Global.FMS.My.Resources.Resources._imgApplication_form_edit32x32
        Me.cmdFunc4.Location = New System.Drawing.Point(635, 596)
        Me.cmdFunc4.Text = "ÏX(F4)"
        '
        'cmdFunc5
        '
        Me.cmdFunc5.Image = Global.FMS.My.Resources.Resources._imgStatusAnnotations_Blocked_32x32_MD
        Me.cmdFunc5.Location = New System.Drawing.Point(845, 596)
        Me.cmdFunc5.Size = New System.Drawing.Size(207, 42)
        Me.cmdFunc5.Text = "í(F5)"
        '
        'cmdFunc6
        '
        Me.cmdFunc6.Image = Global.FMS.My.Resources.Resources._imgRecovery32x32
        Me.cmdFunc6.Location = New System.Drawing.Point(1058, 596)
        Me.cmdFunc6.Size = New System.Drawing.Size(192, 42)
        Me.cmdFunc6.Text = "³(F6)"
        '
        'cmdFunc12
        '
        Me.cmdFunc12.Image = Global.FMS.My.Resources.Resources._imgLog_Out32x32
        Me.cmdFunc12.Location = New System.Drawing.Point(1058, 644)
        Me.cmdFunc12.Size = New System.Drawing.Size(194, 42)
        Me.cmdFunc12.Text = "Â¶é(F12)"
        '
        'cmdFunc11
        '
        Me.cmdFunc11.Location = New System.Drawing.Point(845, 644)
        '
        'cmdFunc10
        '
        Me.cmdFunc10.Image = Global.FMS.My.Resources.Resources._imgExportToExcel32x32
        Me.cmdFunc10.Location = New System.Drawing.Point(635, 644)
        Me.cmdFunc10.Text = "CSVoÍ(F10)"
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
        Me.lblTytle.Text = "}X^"
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
        Me.Label3.Location = New System.Drawing.Point(270, 0)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(98, 30)
        Me.Label3.TabIndex = 54
        Me.Label3.Text = "æª"
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
        Me.gbxFilter.Size = New System.Drawing.Size(1236, 89)
        Me.gbxFilter.TabIndex = 59
        Me.gbxFilter.TabStop = False
        Me.gbxFilter.Text = "õð"
        '
        'tlpFilter
        '
        Me.tlpFilter.ColumnCount = 8
        Me.tlpFilter.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 93.0!))
        Me.tlpFilter.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 174.0!))
        Me.tlpFilter.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 104.0!))
        Me.tlpFilter.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 182.0!))
        Me.tlpFilter.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 89.0!))
        Me.tlpFilter.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 194.0!))
        Me.tlpFilter.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.tlpFilter.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 119.0!))
        Me.tlpFilter.Controls.Add(Me.Label3, 2, 0)
        Me.tlpFilter.Controls.Add(Me.chkDeletedRowVisibled, 7, 0)
        Me.tlpFilter.Controls.Add(Me.Label1, 0, 0)
        Me.tlpFilter.Controls.Add(Me.Label2, 4, 0)
        Me.tlpFilter.Controls.Add(Me.Label4, 0, 1)
        Me.tlpFilter.Controls.Add(Me.Label5, 2, 1)
        Me.tlpFilter.Controls.Add(Me.CmbBUMON_KB, 1, 0)
        Me.tlpFilter.Controls.Add(Me.CmbBUSYO_KB, 3, 0)
        Me.tlpFilter.Controls.Add(Me.txtBUSYO_NAME, 5, 0)
        Me.tlpFilter.Controls.Add(Me.txtOYA_BUSYO_NAME, 1, 1)
        Me.tlpFilter.Controls.Add(Me.txtSYOZOKUCYO_SYAIN_NAME, 3, 1)
        Me.tlpFilter.Dock = System.Windows.Forms.DockStyle.Fill
        Me.tlpFilter.Location = New System.Drawing.Point(3, 20)
        Me.tlpFilter.Name = "tlpFilter"
        Me.tlpFilter.RowCount = 3
        Me.tlpFilter.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30.0!))
        Me.tlpFilter.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30.0!))
        Me.tlpFilter.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.tlpFilter.Size = New System.Drawing.Size(1230, 66)
        Me.tlpFilter.TabIndex = 56
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
        Me.chkDeletedRowVisibled.Text = "íÏà\¦"
        Me.chkDeletedRowVisibled.UseVisualStyleBackColor = True
        '
        'Label1
        '
        Me.Label1.Font = New System.Drawing.Font("Meiryo UI", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label1.Location = New System.Drawing.Point(3, 0)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(61, 30)
        Me.Label1.TabIndex = 55
        Me.Label1.Text = "åæª"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label2
        '
        Me.Label2.Font = New System.Drawing.Font("Meiryo UI", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label2.Location = New System.Drawing.Point(556, 0)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(61, 30)
        Me.Label2.TabIndex = 58
        Me.Label2.Text = "¼"
        Me.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label4
        '
        Me.Label4.Font = New System.Drawing.Font("Meiryo UI", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label4.Location = New System.Drawing.Point(3, 30)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(85, 30)
        Me.Label4.TabIndex = 59
        Me.Label4.Text = "e¼"
        Me.Label4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label5
        '
        Me.Label5.Font = New System.Drawing.Font("Meiryo UI", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label5.Location = New System.Drawing.Point(270, 30)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(97, 30)
        Me.Label5.TabIndex = 60
        Me.Label5.Text = "®·Ðõ¼"
        Me.Label5.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'CmbBUMON_KB
        '
        Me.CmbBUMON_KB.BackColor = System.Drawing.SystemColors.Window
        Me.CmbBUMON_KB.Cursor = System.Windows.Forms.Cursors.Default
        Me.CmbBUMON_KB.DisplayMember = "DISP"
        Me.CmbBUMON_KB.FormattingEnabled = True
        Me.CmbBUMON_KB.GotFocusedColor = System.Drawing.Color.Empty
        Me.CmbBUMON_KB.Location = New System.Drawing.Point(96, 3)
        Me.CmbBUMON_KB.Name = "CmbBUMON_KB"
        Me.CmbBUMON_KB.NullValue = " "
        Me.CmbBUMON_KB.ReadOnly = False
        Me.CmbBUMON_KB.Selected = False
        Me.CmbBUMON_KB.Size = New System.Drawing.Size(121, 25)
        Me.CmbBUMON_KB.TabIndex = 61
        Me.CmbBUMON_KB.ValueMember = "VALUE"
        '
        'CmbBUSYO_KB
        '
        Me.CmbBUSYO_KB.BackColor = System.Drawing.SystemColors.Window
        Me.CmbBUSYO_KB.Cursor = System.Windows.Forms.Cursors.Default
        Me.CmbBUSYO_KB.DisplayMember = "DISP"
        Me.CmbBUSYO_KB.FormattingEnabled = True
        Me.CmbBUSYO_KB.GotFocusedColor = System.Drawing.Color.Empty
        Me.CmbBUSYO_KB.Location = New System.Drawing.Point(374, 3)
        Me.CmbBUSYO_KB.Name = "CmbBUSYO_KB"
        Me.CmbBUSYO_KB.NullValue = " "
        Me.CmbBUSYO_KB.ReadOnly = False
        Me.CmbBUSYO_KB.Selected = False
        Me.CmbBUSYO_KB.Size = New System.Drawing.Size(121, 25)
        Me.CmbBUSYO_KB.TabIndex = 62
        Me.CmbBUSYO_KB.ValueMember = "VALUE"
        '
        'txtBUSYO_NAME
        '
        Me.txtBUSYO_NAME.BackColor = System.Drawing.SystemColors.Window
        Me.txtBUSYO_NAME.GotFocusedColor = System.Drawing.Color.FromArgb(CType(CType(190, Byte), Integer), CType(CType(180, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.txtBUSYO_NAME.ImeMode = System.Windows.Forms.ImeMode.[On]
        Me.txtBUSYO_NAME.InputRequired = False
        Me.txtBUSYO_NAME.Location = New System.Drawing.Point(645, 3)
        Me.txtBUSYO_NAME.MaxByteLength = 30
        Me.txtBUSYO_NAME.Name = "txtBUSYO_NAME"
        Me.txtBUSYO_NAME.Size = New System.Drawing.Size(179, 24)
        Me.txtBUSYO_NAME.TabIndex = 63
        Me.txtBUSYO_NAME.WatermarkColor = System.Drawing.Color.Empty
        Me.txtBUSYO_NAME.WatermarkText = Nothing
        '
        'txtOYA_BUSYO_NAME
        '
        Me.txtOYA_BUSYO_NAME.BackColor = System.Drawing.SystemColors.Window
        Me.txtOYA_BUSYO_NAME.GotFocusedColor = System.Drawing.Color.FromArgb(CType(CType(190, Byte), Integer), CType(CType(180, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.txtOYA_BUSYO_NAME.ImeMode = System.Windows.Forms.ImeMode.[On]
        Me.txtOYA_BUSYO_NAME.InputRequired = False
        Me.txtOYA_BUSYO_NAME.Location = New System.Drawing.Point(96, 33)
        Me.txtOYA_BUSYO_NAME.MaxByteLength = 30
        Me.txtOYA_BUSYO_NAME.Name = "txtOYA_BUSYO_NAME"
        Me.txtOYA_BUSYO_NAME.Size = New System.Drawing.Size(168, 24)
        Me.txtOYA_BUSYO_NAME.TabIndex = 63
        Me.txtOYA_BUSYO_NAME.WatermarkColor = System.Drawing.Color.Empty
        Me.txtOYA_BUSYO_NAME.WatermarkText = Nothing
        '
        'txtSYOZOKUCYO_SYAIN_NAME
        '
        Me.txtSYOZOKUCYO_SYAIN_NAME.BackColor = System.Drawing.SystemColors.Window
        Me.txtSYOZOKUCYO_SYAIN_NAME.GotFocusedColor = System.Drawing.Color.FromArgb(CType(CType(190, Byte), Integer), CType(CType(180, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.txtSYOZOKUCYO_SYAIN_NAME.ImeMode = System.Windows.Forms.ImeMode.[On]
        Me.txtSYOZOKUCYO_SYAIN_NAME.InputRequired = False
        Me.txtSYOZOKUCYO_SYAIN_NAME.Location = New System.Drawing.Point(374, 33)
        Me.txtSYOZOKUCYO_SYAIN_NAME.MaxByteLength = 60
        Me.txtSYOZOKUCYO_SYAIN_NAME.Name = "txtSYOZOKUCYO_SYAIN_NAME"
        Me.txtSYOZOKUCYO_SYAIN_NAME.Size = New System.Drawing.Size(176, 24)
        Me.txtSYOZOKUCYO_SYAIN_NAME.TabIndex = 63
        Me.txtSYOZOKUCYO_SYAIN_NAME.WatermarkColor = System.Drawing.Color.Empty
        Me.txtSYOZOKUCYO_SYAIN_NAME.WatermarkText = Nothing
        '
        'dgvDATA
        '
        Me.dgvDATA.AllowUserToAddRows = False
        Me.dgvDATA.AllowUserToDeleteRows = False
        Me.dgvDATA.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvDATA.Location = New System.Drawing.Point(22, 155)
        Me.dgvDATA.Name = "dgvDATA"
        Me.dgvDATA.ReadOnly = True
        Me.dgvDATA.RowTemplate.Height = 21
        Me.dgvDATA.Size = New System.Drawing.Size(1225, 418)
        Me.dgvDATA.TabIndex = 60
        '
        'FrmM0020
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.ClientSize = New System.Drawing.Size(1264, 712)
        Me.Controls.Add(Me.dgvDATA)
        Me.Controls.Add(Me.gbxFilter)
        Me.HelpButton = True
        Me.Name = "FrmM0020"
        Me.ShowStatusBar = True
        Me.Text = ""
        Me.Controls.SetChildIndex(Me.gbxFilter, 0)
        Me.Controls.SetChildIndex(Me.dgvDATA, 0)
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
    Friend WithEvents chkDeletedRowVisibled As CheckBox
    Friend WithEvents Label1 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents Label4 As Label
    Friend WithEvents Label5 As Label
    Friend WithEvents CmbBUMON_KB As ComboboxEx
    Friend WithEvents CmbBUSYO_KB As ComboboxEx
    Friend WithEvents txtBUSYO_NAME As MaskedTextBoxEx
    Friend WithEvents txtOYA_BUSYO_NAME As MaskedTextBoxEx
    Friend WithEvents txtSYOZOKUCYO_SYAIN_NAME As MaskedTextBoxEx
End Class
