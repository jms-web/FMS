<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class FrmM0160
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
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmM0160))
        Me.SaveFileDialog = New System.Windows.Forms.SaveFileDialog()
        Me.OpenFileDialog = New System.Windows.Forms.OpenFileDialog()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.gbxFilter = New System.Windows.Forms.GroupBox()
        Me.tlpFilter = New System.Windows.Forms.TableLayoutPanel()
        Me.chkDeletedRowVisibled = New System.Windows.Forms.CheckBox()
        Me.CmbSYONIN_JUN = New JMS_COMMON.ComboboxEx()
        Me.CmbSYONIN_HOKOKUSYO_ID = New JMS_COMMON.ComboboxEx()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.cmbBUMON_KB = New JMS_COMMON.ComboboxEx()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.mtxSIMEI = New JMS_COMMON.MaskedTextBoxEx()
        Me.flxDATA = New C1.Win.C1FlexGrid.C1FlexGrid()
        Me.VWM016SYONINTANTOBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        CType(Me.ErrorProvider, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.gbxFilter.SuspendLayout()
        Me.tlpFilter.SuspendLayout()
        CType(Me.flxDATA, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.VWM016SYONINTANTOBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'lblRecordCount
        '
        Me.lblRecordCount.Location = New System.Drawing.Point(9, 569)
        '
        'cmdFunc1
        '
        Me.cmdFunc1.Image = Global.FMS.My.Resources.Resources._imgSearch32x32
        Me.cmdFunc1.Location = New System.Drawing.Point(9, 596)
        Me.cmdFunc1.Text = "����(F1)"
        '
        'cmdFunc2
        '
        Me.cmdFunc2.Image = Global.FMS.My.Resources.Resources._imgApplication_form_add32x32
        Me.cmdFunc2.Location = New System.Drawing.Point(218, 596)
        Me.cmdFunc2.Text = "�ǉ�(F2)"
        '
        'cmdFunc3
        '
        Me.cmdFunc3.Image = Global.FMS.My.Resources.Resources._imgApplication_form_add32x32
        Me.cmdFunc3.Location = New System.Drawing.Point(427, 596)
        Me.cmdFunc3.Text = "�ގ��ǉ�(F3)"
        Me.cmdFunc3.Visible = False
        '
        'cmdFunc4
        '
        Me.cmdFunc4.Image = Global.FMS.My.Resources.Resources._imgApplication_form_edit32x32
        Me.cmdFunc4.Location = New System.Drawing.Point(636, 596)
        Me.cmdFunc4.Text = "�ύX(F4)"
        Me.cmdFunc4.Visible = False
        '
        'cmdFunc5
        '
        Me.cmdFunc5.Image = Global.FMS.My.Resources.Resources._imgStatusAnnotations_Blocked_32x32_MD
        Me.cmdFunc5.Location = New System.Drawing.Point(845, 596)
        Me.cmdFunc5.Size = New System.Drawing.Size(207, 42)
        Me.cmdFunc5.Text = "�폜(F5)"
        '
        'cmdFunc6
        '
        Me.cmdFunc6.Image = Global.FMS.My.Resources.Resources._imgRecovery32x32
        Me.cmdFunc6.Location = New System.Drawing.Point(1057, 596)
        Me.cmdFunc6.Size = New System.Drawing.Size(192, 42)
        Me.cmdFunc6.Text = "����(F6)"
        '
        'cmdFunc12
        '
        Me.cmdFunc12.Image = Global.FMS.My.Resources.Resources._imgLog_Out32x32
        Me.cmdFunc12.Location = New System.Drawing.Point(1054, 644)
        Me.cmdFunc12.Size = New System.Drawing.Size(194, 42)
        Me.cmdFunc12.Text = "����(F12)"
        '
        'cmdFunc11
        '
        Me.cmdFunc11.Location = New System.Drawing.Point(845, 644)
        '
        'cmdFunc10
        '
        Me.cmdFunc10.Image = Global.FMS.My.Resources.Resources._imgExportToExcel32x32
        Me.cmdFunc10.Location = New System.Drawing.Point(636, 644)
        Me.cmdFunc10.Text = "CSV�o��(F10)"
        '
        'cmdFunc7
        '
        Me.cmdFunc7.Location = New System.Drawing.Point(9, 644)
        '
        'cmdFunc9
        '
        Me.cmdFunc9.Location = New System.Drawing.Point(427, 644)
        '
        'cmdFunc8
        '
        Me.cmdFunc8.Location = New System.Drawing.Point(218, 644)
        '
        'lblTytle
        '
        Me.lblTytle.Font = New System.Drawing.Font("Meiryo UI", 24.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTytle.Text = "���F�S���҃}�X�^"
        '
        'Label3
        '
        Me.Label3.Font = New System.Drawing.Font("Meiryo UI", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label3.Location = New System.Drawing.Point(498, 0)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(68, 30)
        Me.Label3.TabIndex = 54
        Me.Label3.Text = "���F��:"
        Me.Label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight
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
        Me.gbxFilter.Text = "��������"
        '
        'tlpFilter
        '
        Me.tlpFilter.ColumnCount = 9
        Me.tlpFilter.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 80.0!))
        Me.tlpFilter.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 122.0!))
        Me.tlpFilter.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 103.0!))
        Me.tlpFilter.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 190.0!))
        Me.tlpFilter.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 74.0!))
        Me.tlpFilter.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 249.0!))
        Me.tlpFilter.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 79.0!))
        Me.tlpFilter.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.tlpFilter.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 119.0!))
        Me.tlpFilter.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20.0!))
        Me.tlpFilter.Controls.Add(Me.chkDeletedRowVisibled, 8, 0)
        Me.tlpFilter.Controls.Add(Me.CmbSYONIN_JUN, 5, 0)
        Me.tlpFilter.Controls.Add(Me.Label3, 4, 0)
        Me.tlpFilter.Controls.Add(Me.CmbSYONIN_HOKOKUSYO_ID, 3, 0)
        Me.tlpFilter.Controls.Add(Me.Label1, 2, 0)
        Me.tlpFilter.Controls.Add(Me.Label4, 0, 0)
        Me.tlpFilter.Controls.Add(Me.cmbBUMON_KB, 1, 0)
        Me.tlpFilter.Controls.Add(Me.Label2, 6, 0)
        Me.tlpFilter.Controls.Add(Me.mtxSIMEI, 7, 0)
        Me.tlpFilter.Dock = System.Windows.Forms.DockStyle.Fill
        Me.tlpFilter.Location = New System.Drawing.Point(3, 20)
        Me.tlpFilter.Name = "tlpFilter"
        Me.tlpFilter.RowCount = 3
        Me.tlpFilter.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30.0!))
        Me.tlpFilter.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30.0!))
        Me.tlpFilter.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.tlpFilter.Size = New System.Drawing.Size(1230, 37)
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
        Me.chkDeletedRowVisibled.Text = "�폜�ς��\��"
        Me.chkDeletedRowVisibled.UseVisualStyleBackColor = True
        Me.chkDeletedRowVisibled.Visible = False
        '
        'CmbSYONIN_JUN
        '
        Me.CmbSYONIN_JUN.BackColor = System.Drawing.SystemColors.Window
        Me.CmbSYONIN_JUN.Cursor = System.Windows.Forms.Cursors.Default
        Me.CmbSYONIN_JUN.DisplayMember = "DISP"
        Me.CmbSYONIN_JUN.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.CmbSYONIN_JUN.FormattingEnabled = True
        Me.CmbSYONIN_JUN.GotFocusedColor = System.Drawing.Color.Empty
        Me.CmbSYONIN_JUN.IsSelected = False
        Me.CmbSYONIN_JUN.Location = New System.Drawing.Point(572, 3)
        Me.CmbSYONIN_JUN.Name = "CmbSYONIN_JUN"
        Me.CmbSYONIN_JUN.NullValue = " "
        Me.CmbSYONIN_JUN.ReadOnly = False
        Me.CmbSYONIN_JUN.Size = New System.Drawing.Size(243, 25)
        Me.CmbSYONIN_JUN.TabIndex = 57
        Me.CmbSYONIN_JUN.ValueMember = "VALUE"
        '
        'CmbSYONIN_HOKOKUSYO_ID
        '
        Me.CmbSYONIN_HOKOKUSYO_ID.BackColor = System.Drawing.SystemColors.Window
        Me.CmbSYONIN_HOKOKUSYO_ID.Cursor = System.Windows.Forms.Cursors.Default
        Me.CmbSYONIN_HOKOKUSYO_ID.DisplayMember = "DISP"
        Me.CmbSYONIN_HOKOKUSYO_ID.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.CmbSYONIN_HOKOKUSYO_ID.Font = New System.Drawing.Font("Meiryo UI", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.CmbSYONIN_HOKOKUSYO_ID.ForeColor = System.Drawing.SystemColors.ControlText
        Me.CmbSYONIN_HOKOKUSYO_ID.FormattingEnabled = True
        Me.CmbSYONIN_HOKOKUSYO_ID.GotFocusedColor = System.Drawing.Color.FromArgb(CType(CType(190, Byte), Integer), CType(CType(180, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.CmbSYONIN_HOKOKUSYO_ID.IsSelected = False
        Me.CmbSYONIN_HOKOKUSYO_ID.Location = New System.Drawing.Point(308, 3)
        Me.CmbSYONIN_HOKOKUSYO_ID.Name = "CmbSYONIN_HOKOKUSYO_ID"
        Me.CmbSYONIN_HOKOKUSYO_ID.NullValue = " "
        Me.CmbSYONIN_HOKOKUSYO_ID.ReadOnly = False
        Me.CmbSYONIN_HOKOKUSYO_ID.Size = New System.Drawing.Size(183, 25)
        Me.CmbSYONIN_HOKOKUSYO_ID.TabIndex = 56
        Me.CmbSYONIN_HOKOKUSYO_ID.ValueMember = "VALUE"
        '
        'Label1
        '
        Me.Label1.Font = New System.Drawing.Font("Meiryo UI", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label1.Location = New System.Drawing.Point(205, 0)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(97, 30)
        Me.Label1.TabIndex = 55
        Me.Label1.Text = "���F�񍐏�:"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label4
        '
        Me.Label4.Location = New System.Drawing.Point(3, 0)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(74, 27)
        Me.Label4.TabIndex = 62
        Me.Label4.Text = "����敪:"
        Me.Label4.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'cmbBUMON_KB
        '
        Me.cmbBUMON_KB.BackColor = System.Drawing.SystemColors.Window
        Me.cmbBUMON_KB.Cursor = System.Windows.Forms.Cursors.Default
        Me.cmbBUMON_KB.DisplayMember = "DISP"
        Me.cmbBUMON_KB.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbBUMON_KB.Font = New System.Drawing.Font("Meiryo UI", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.cmbBUMON_KB.ForeColor = System.Drawing.SystemColors.ControlText
        Me.cmbBUMON_KB.FormattingEnabled = True
        Me.cmbBUMON_KB.GotFocusedColor = System.Drawing.Color.FromArgb(CType(CType(190, Byte), Integer), CType(CType(180, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.cmbBUMON_KB.ImeMode = System.Windows.Forms.ImeMode.Disable
        Me.cmbBUMON_KB.IsSelected = False
        Me.cmbBUMON_KB.Location = New System.Drawing.Point(83, 3)
        Me.cmbBUMON_KB.Name = "cmbBUMON_KB"
        Me.cmbBUMON_KB.NullValue = " "
        Me.cmbBUMON_KB.ReadOnly = False
        Me.cmbBUMON_KB.Size = New System.Drawing.Size(116, 25)
        Me.cmbBUMON_KB.TabIndex = 61
        Me.cmbBUMON_KB.ValueMember = "VALUE"
        '
        'Label2
        '
        Me.Label2.Location = New System.Drawing.Point(821, 0)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(73, 27)
        Me.Label2.TabIndex = 59
        Me.Label2.Text = "�Ј���:"
        Me.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'mtxSIMEI
        '
        Me.mtxSIMEI.BackColor = System.Drawing.SystemColors.Window
        Me.mtxSIMEI.Font = New System.Drawing.Font("Meiryo UI", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.mtxSIMEI.GotFocusedColor = System.Drawing.Color.FromArgb(CType(CType(190, Byte), Integer), CType(CType(180, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.mtxSIMEI.ImeMode = System.Windows.Forms.ImeMode.[On]
        Me.mtxSIMEI.InputRequired = False
        Me.mtxSIMEI.Location = New System.Drawing.Point(900, 3)
        Me.mtxSIMEI.MaxByteLength = 100
        Me.mtxSIMEI.Name = "mtxSIMEI"
        Me.mtxSIMEI.Size = New System.Drawing.Size(127, 24)
        Me.mtxSIMEI.TabIndex = 63
        Me.mtxSIMEI.WatermarkColor = System.Drawing.Color.Empty
        Me.mtxSIMEI.WatermarkText = Nothing
        '
        'flxDATA
        '
        Me.flxDATA.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.flxDATA.ColumnInfo = resources.GetString("flxDATA.ColumnInfo")
        Me.flxDATA.DataSource = Me.VWM016SYONINTANTOBindingSource
        Me.flxDATA.Location = New System.Drawing.Point(14, 126)
        Me.flxDATA.Name = "flxDATA"
        Me.flxDATA.Rows.Count = 1
        Me.flxDATA.Rows.DefaultSize = 18
        Me.flxDATA.Size = New System.Drawing.Size(1234, 437)
        Me.flxDATA.TabIndex = 60
        '
        'VWM016SYONINTANTOBindingSource
        '
        Me.VWM016SYONINTANTOBindingSource.DataSource = GetType(MODEL.VWM016_SYONIN_TANTO)
        '
        'FrmM0160
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.ClientSize = New System.Drawing.Size(1264, 712)
        Me.Controls.Add(Me.flxDATA)
        Me.Controls.Add(Me.gbxFilter)
        Me.HelpButton = True
        Me.Name = "FrmM0160"
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
        Me.Controls.SetChildIndex(Me.flxDATA, 0)
        CType(Me.ErrorProvider, System.ComponentModel.ISupportInitialize).EndInit()
        Me.gbxFilter.ResumeLayout(False)
        Me.tlpFilter.ResumeLayout(False)
        Me.tlpFilter.PerformLayout()
        CType(Me.flxDATA, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.VWM016SYONINTANTOBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents SaveFileDialog As System.Windows.Forms.SaveFileDialog
    Friend WithEvents OpenFileDialog As System.Windows.Forms.OpenFileDialog
    Friend WithEvents Label3 As Label
    Friend WithEvents gbxFilter As GroupBox
    Friend WithEvents tlpFilter As TableLayoutPanel
    Friend WithEvents chkDeletedRowVisibled As CheckBox
    Friend WithEvents Label1 As Label
    Friend WithEvents CmbSYONIN_HOKOKUSYO_ID As ComboboxEx
    Friend WithEvents CmbSYONIN_JUN As ComboboxEx
    Friend WithEvents Label2 As Label
    Friend WithEvents flxDATA As C1.Win.C1FlexGrid.C1FlexGrid
    Friend WithEvents VWM016SYONINTANTOBindingSource As BindingSource
    Friend WithEvents Label4 As Label
    Friend WithEvents cmbBUMON_KB As ComboboxEx
    Friend WithEvents mtxSIMEI As MaskedTextBoxEx
End Class
