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
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmM0040))
        Me.SaveFileDialog = New System.Windows.Forms.SaveFileDialog()
        Me.OpenFileDialog = New System.Windows.Forms.OpenFileDialog()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.gbxFilter = New System.Windows.Forms.GroupBox()
        Me.tlpFilter = New System.Windows.Forms.TableLayoutPanel()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.mtxSIMEI = New JMS_COMMON.MaskedTextBoxEx()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.mtxSYAIN_NO = New JMS_COMMON.MaskedTextBoxEx()
        Me.cmbYAKUSYOKU_KB = New JMS_COMMON.ComboboxEx()
        Me.chkDeletedRowVisibled = New System.Windows.Forms.CheckBox()
        Me.chkTaisyokuRowVisibled = New System.Windows.Forms.CheckBox()
        Me.cmbSYAIN_KB = New JMS_COMMON.ComboboxEx()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.mtxSIMEI_KANA = New JMS_COMMON.MaskedTextBoxEx()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.dtbNYUSYA_YMD_FROM = New JMS_COMMON.DateTextBoxEx()
        Me.dtbNYUSYA_YMD_To = New JMS_COMMON.DateTextBoxEx()
        Me.VWM004SYAINBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.flxDATA = New C1.Win.C1FlexGrid.C1FlexGrid()
        CType(Me.ErrorProvider, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.gbxFilter.SuspendLayout()
        Me.tlpFilter.SuspendLayout()
        CType(Me.VWM004SYAINBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.flxDATA, System.ComponentModel.ISupportInitialize).BeginInit()
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
        Me.lblTytle.Text = "SÒ}X^"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Label3.Font = New System.Drawing.Font("Meiryo UI", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label3.Location = New System.Drawing.Point(215, 0)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(78, 30)
        Me.Label3.TabIndex = 54
        Me.Label3.Text = "SÒ¼"
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
        Me.gbxFilter.Size = New System.Drawing.Size(1236, 84)
        Me.gbxFilter.TabIndex = 59
        Me.gbxFilter.TabStop = False
        Me.gbxFilter.Text = "õð"
        '
        'tlpFilter
        '
        Me.tlpFilter.ColumnCount = 10
        Me.tlpFilter.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 67.0!))
        Me.tlpFilter.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 145.0!))
        Me.tlpFilter.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 84.0!))
        Me.tlpFilter.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.tlpFilter.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 27.0!))
        Me.tlpFilter.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 133.0!))
        Me.tlpFilter.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 159.0!))
        Me.tlpFilter.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 78.0!))
        Me.tlpFilter.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 292.0!))
        Me.tlpFilter.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 112.0!))
        Me.tlpFilter.Controls.Add(Me.Label5, 0, 1)
        Me.tlpFilter.Controls.Add(Me.mtxSIMEI, 3, 0)
        Me.tlpFilter.Controls.Add(Me.Label3, 2, 0)
        Me.tlpFilter.Controls.Add(Me.Label1, 0, 0)
        Me.tlpFilter.Controls.Add(Me.mtxSYAIN_NO, 1, 0)
        Me.tlpFilter.Controls.Add(Me.cmbYAKUSYOKU_KB, 1, 1)
        Me.tlpFilter.Controls.Add(Me.chkDeletedRowVisibled, 9, 0)
        Me.tlpFilter.Controls.Add(Me.chkTaisyokuRowVisibled, 9, 1)
        Me.tlpFilter.Controls.Add(Me.cmbSYAIN_KB, 8, 0)
        Me.tlpFilter.Controls.Add(Me.Label4, 7, 0)
        Me.tlpFilter.Controls.Add(Me.mtxSIMEI_KANA, 6, 0)
        Me.tlpFilter.Controls.Add(Me.Label2, 5, 0)
        Me.tlpFilter.Controls.Add(Me.Label6, 2, 1)
        Me.tlpFilter.Controls.Add(Me.Label7, 4, 1)
        Me.tlpFilter.Controls.Add(Me.dtbNYUSYA_YMD_FROM, 3, 1)
        Me.tlpFilter.Controls.Add(Me.dtbNYUSYA_YMD_To, 5, 1)
        Me.tlpFilter.Dock = System.Windows.Forms.DockStyle.Fill
        Me.tlpFilter.Location = New System.Drawing.Point(3, 20)
        Me.tlpFilter.Name = "tlpFilter"
        Me.tlpFilter.RowCount = 2
        Me.tlpFilter.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30.0!))
        Me.tlpFilter.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.tlpFilter.Size = New System.Drawing.Size(1230, 61)
        Me.tlpFilter.TabIndex = 56
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Label5.Font = New System.Drawing.Font("Meiryo UI", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label5.Location = New System.Drawing.Point(3, 30)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(61, 31)
        Me.Label5.TabIndex = 62
        Me.Label5.Text = "ðEæª"
        Me.Label5.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'mtxSIMEI
        '
        Me.mtxSIMEI.BackColor = System.Drawing.SystemColors.Window
        Me.mtxSIMEI.Font = New System.Drawing.Font("Meiryo UI", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.mtxSIMEI.GotFocusedColor = System.Drawing.Color.FromArgb(CType(CType(190, Byte), Integer), CType(CType(180, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.mtxSIMEI.ImeMode = System.Windows.Forms.ImeMode.[On]
        Me.mtxSIMEI.InputRequired = False
        Me.mtxSIMEI.Location = New System.Drawing.Point(299, 3)
        Me.mtxSIMEI.MaxByteLength = 100
        Me.mtxSIMEI.Name = "mtxSIMEI"
        Me.mtxSIMEI.Size = New System.Drawing.Size(127, 24)
        Me.mtxSIMEI.TabIndex = 0
        Me.mtxSIMEI.WatermarkColor = System.Drawing.Color.Empty
        Me.mtxSIMEI.WatermarkText = Nothing
        '
        'Label1
        '
        Me.Label1.Font = New System.Drawing.Font("Meiryo UI", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label1.Location = New System.Drawing.Point(3, 0)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(61, 30)
        Me.Label1.TabIndex = 55
        Me.Label1.Text = "EÔ"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'mtxSYAIN_NO
        '
        Me.mtxSYAIN_NO.BackColor = System.Drawing.SystemColors.Window
        Me.mtxSYAIN_NO.Font = New System.Drawing.Font("Meiryo UI", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.mtxSYAIN_NO.GotFocusedColor = System.Drawing.Color.FromArgb(CType(CType(190, Byte), Integer), CType(CType(180, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.mtxSYAIN_NO.ImeMode = System.Windows.Forms.ImeMode.Off
        Me.mtxSYAIN_NO.InputRequired = False
        Me.mtxSYAIN_NO.Location = New System.Drawing.Point(70, 3)
        Me.mtxSYAIN_NO.MaxByteLength = 100
        Me.mtxSYAIN_NO.Name = "mtxSYAIN_NO"
        Me.mtxSYAIN_NO.Size = New System.Drawing.Size(93, 24)
        Me.mtxSYAIN_NO.TabIndex = 56
        Me.mtxSYAIN_NO.WatermarkColor = System.Drawing.Color.Empty
        Me.mtxSYAIN_NO.WatermarkText = Nothing
        '
        'cmbYAKUSYOKU_KB
        '
        Me.cmbYAKUSYOKU_KB.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cmbYAKUSYOKU_KB.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cmbYAKUSYOKU_KB.BackColor = System.Drawing.SystemColors.Window
        Me.cmbYAKUSYOKU_KB.Cursor = System.Windows.Forms.Cursors.Default
        Me.cmbYAKUSYOKU_KB.DisplayMember = "DISP"
        Me.cmbYAKUSYOKU_KB.Font = New System.Drawing.Font("Meiryo UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.cmbYAKUSYOKU_KB.ForeColor = System.Drawing.SystemColors.ControlText
        Me.cmbYAKUSYOKU_KB.FormattingEnabled = True
        Me.cmbYAKUSYOKU_KB.GotFocusedColor = System.Drawing.Color.FromArgb(CType(CType(190, Byte), Integer), CType(CType(180, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.cmbYAKUSYOKU_KB.ImeMode = System.Windows.Forms.ImeMode.[On]
        Me.cmbYAKUSYOKU_KB.Location = New System.Drawing.Point(70, 33)
        Me.cmbYAKUSYOKU_KB.Name = "cmbYAKUSYOKU_KB"
        Me.cmbYAKUSYOKU_KB.NullValue = " "
        Me.cmbYAKUSYOKU_KB.ReadOnly = False
        Me.cmbYAKUSYOKU_KB.Selected = False
        Me.cmbYAKUSYOKU_KB.Size = New System.Drawing.Size(103, 25)
        Me.cmbYAKUSYOKU_KB.TabIndex = 63
        Me.cmbYAKUSYOKU_KB.Text = "(Ið)"
        Me.cmbYAKUSYOKU_KB.ValueMember = "VALUE"
        '
        'chkDeletedRowVisibled
        '
        Me.chkDeletedRowVisibled.AutoSize = True
        Me.chkDeletedRowVisibled.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.chkDeletedRowVisibled.Cursor = System.Windows.Forms.Cursors.Hand
        Me.chkDeletedRowVisibled.Dock = System.Windows.Forms.DockStyle.Fill
        Me.chkDeletedRowVisibled.Font = New System.Drawing.Font("Meiryo UI", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.chkDeletedRowVisibled.Location = New System.Drawing.Point(1121, 3)
        Me.chkDeletedRowVisibled.Name = "chkDeletedRowVisibled"
        Me.chkDeletedRowVisibled.Size = New System.Drawing.Size(106, 24)
        Me.chkDeletedRowVisibled.TabIndex = 59
        Me.chkDeletedRowVisibled.Text = "íÏà\¦"
        Me.chkDeletedRowVisibled.UseVisualStyleBackColor = True
        '
        'chkTaisyokuRowVisibled
        '
        Me.chkTaisyokuRowVisibled.AutoSize = True
        Me.chkTaisyokuRowVisibled.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.chkTaisyokuRowVisibled.Cursor = System.Windows.Forms.Cursors.Hand
        Me.chkTaisyokuRowVisibled.Dock = System.Windows.Forms.DockStyle.Fill
        Me.chkTaisyokuRowVisibled.Font = New System.Drawing.Font("Meiryo UI", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.chkTaisyokuRowVisibled.Location = New System.Drawing.Point(1121, 33)
        Me.chkTaisyokuRowVisibled.Name = "chkTaisyokuRowVisibled"
        Me.chkTaisyokuRowVisibled.Size = New System.Drawing.Size(106, 25)
        Me.chkTaisyokuRowVisibled.TabIndex = 64
        Me.chkTaisyokuRowVisibled.Text = "ÞEÒà\¦"
        Me.chkTaisyokuRowVisibled.UseVisualStyleBackColor = True
        '
        'cmbSYAIN_KB
        '
        Me.cmbSYAIN_KB.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cmbSYAIN_KB.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cmbSYAIN_KB.BackColor = System.Drawing.SystemColors.Window
        Me.cmbSYAIN_KB.Cursor = System.Windows.Forms.Cursors.Default
        Me.cmbSYAIN_KB.DisplayMember = "DISP"
        Me.cmbSYAIN_KB.Font = New System.Drawing.Font("Meiryo UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.cmbSYAIN_KB.ForeColor = System.Drawing.SystemColors.ControlText
        Me.cmbSYAIN_KB.FormattingEnabled = True
        Me.cmbSYAIN_KB.GotFocusedColor = System.Drawing.Color.FromArgb(CType(CType(190, Byte), Integer), CType(CType(180, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.cmbSYAIN_KB.ImeMode = System.Windows.Forms.ImeMode.[On]
        Me.cmbSYAIN_KB.Location = New System.Drawing.Point(829, 3)
        Me.cmbSYAIN_KB.Name = "cmbSYAIN_KB"
        Me.cmbSYAIN_KB.NullValue = " "
        Me.cmbSYAIN_KB.ReadOnly = False
        Me.cmbSYAIN_KB.Selected = False
        Me.cmbSYAIN_KB.Size = New System.Drawing.Size(103, 25)
        Me.cmbSYAIN_KB.TabIndex = 61
        Me.cmbSYAIN_KB.Text = "(Ið)"
        Me.cmbSYAIN_KB.ValueMember = "VALUE"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Label4.Font = New System.Drawing.Font("Meiryo UI", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label4.Location = New System.Drawing.Point(751, 0)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(72, 30)
        Me.Label4.TabIndex = 60
        Me.Label4.Text = "Ðõæª"
        Me.Label4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'mtxSIMEI_KANA
        '
        Me.mtxSIMEI_KANA.BackColor = System.Drawing.SystemColors.Window
        Me.mtxSIMEI_KANA.Font = New System.Drawing.Font("Meiryo UI", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.mtxSIMEI_KANA.GotFocusedColor = System.Drawing.Color.FromArgb(CType(CType(190, Byte), Integer), CType(CType(180, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.mtxSIMEI_KANA.ImeMode = System.Windows.Forms.ImeMode.[On]
        Me.mtxSIMEI_KANA.InputRequired = False
        Me.mtxSIMEI_KANA.Location = New System.Drawing.Point(592, 3)
        Me.mtxSIMEI_KANA.MaxByteLength = 100
        Me.mtxSIMEI_KANA.Name = "mtxSIMEI_KANA"
        Me.mtxSIMEI_KANA.Size = New System.Drawing.Size(137, 24)
        Me.mtxSIMEI_KANA.TabIndex = 58
        Me.mtxSIMEI_KANA.WatermarkColor = System.Drawing.Color.Empty
        Me.mtxSIMEI_KANA.WatermarkText = Nothing
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Label2.Font = New System.Drawing.Font("Meiryo UI", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label2.Location = New System.Drawing.Point(459, 0)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(127, 30)
        Me.Label2.TabIndex = 57
        Me.Label2.Text = "SÒ¼Ji"
        Me.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Label6.Font = New System.Drawing.Font("Meiryo UI", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label6.Location = New System.Drawing.Point(215, 30)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(78, 31)
        Me.Label6.TabIndex = 65
        Me.Label6.Text = "üÐNú"
        Me.Label6.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Label7.Font = New System.Drawing.Font("Meiryo UI", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label7.Location = New System.Drawing.Point(432, 30)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(21, 31)
        Me.Label7.TabIndex = 65
        Me.Label7.Text = "`"
        Me.Label7.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'dtbNYUSYA_YMD_FROM
        '
        Me.dtbNYUSYA_YMD_FROM.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.dtbNYUSYA_YMD_FROM.Font = New System.Drawing.Font("Meiryo UI", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.dtbNYUSYA_YMD_FROM.ForeColor = System.Drawing.SystemColors.ControlText
        Me.dtbNYUSYA_YMD_FROM.GotFocusedColor = System.Drawing.Color.FromArgb(CType(CType(190, Byte), Integer), CType(CType(180, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.dtbNYUSYA_YMD_FROM.Location = New System.Drawing.Point(299, 33)
        Me.dtbNYUSYA_YMD_FROM.MaxDate = New Date(9998, 12, 31, 0, 0, 0, 0)
        Me.dtbNYUSYA_YMD_FROM.MinDate = New Date(1753, 1, 1, 0, 0, 0, 0)
        Me.dtbNYUSYA_YMD_FROM.MinimumSize = New System.Drawing.Size(98, 24)
        Me.dtbNYUSYA_YMD_FROM.Name = "dtbNYUSYA_YMD_FROM"
        Me.dtbNYUSYA_YMD_FROM.ReadOnly = False
        Me.dtbNYUSYA_YMD_FROM.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.dtbNYUSYA_YMD_FROM.Size = New System.Drawing.Size(107, 24)
        Me.dtbNYUSYA_YMD_FROM.TabIndex = 66
        Me.dtbNYUSYA_YMD_FROM.Value = ""
        Me.dtbNYUSYA_YMD_FROM.ValueNonFormat = ""
        '
        'dtbNYUSYA_YMD_To
        '
        Me.dtbNYUSYA_YMD_To.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.dtbNYUSYA_YMD_To.Font = New System.Drawing.Font("Meiryo UI", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.dtbNYUSYA_YMD_To.ForeColor = System.Drawing.SystemColors.ControlText
        Me.dtbNYUSYA_YMD_To.GotFocusedColor = System.Drawing.Color.FromArgb(CType(CType(190, Byte), Integer), CType(CType(180, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.dtbNYUSYA_YMD_To.Location = New System.Drawing.Point(459, 33)
        Me.dtbNYUSYA_YMD_To.MaxDate = New Date(9998, 12, 31, 0, 0, 0, 0)
        Me.dtbNYUSYA_YMD_To.MinDate = New Date(1753, 1, 1, 0, 0, 0, 0)
        Me.dtbNYUSYA_YMD_To.MinimumSize = New System.Drawing.Size(98, 24)
        Me.dtbNYUSYA_YMD_To.Name = "dtbNYUSYA_YMD_To"
        Me.dtbNYUSYA_YMD_To.ReadOnly = False
        Me.dtbNYUSYA_YMD_To.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.dtbNYUSYA_YMD_To.Size = New System.Drawing.Size(100, 24)
        Me.dtbNYUSYA_YMD_To.TabIndex = 67
        Me.dtbNYUSYA_YMD_To.Value = ""
        Me.dtbNYUSYA_YMD_To.ValueNonFormat = ""
        '
        'VWM004SYAINBindingSource
        '
        Me.VWM004SYAINBindingSource.DataSource = GetType(MODEL.VWM004_SYAIN)
        '
        'flxDATA
        '
        Me.flxDATA.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.flxDATA.ColumnInfo = resources.GetString("flxDATA.ColumnInfo")
        Me.flxDATA.DataSource = Me.VWM004SYAINBindingSource
        Me.flxDATA.Font = New System.Drawing.Font("Meiryo UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.flxDATA.Location = New System.Drawing.Point(14, 150)
        Me.flxDATA.Name = "flxDATA"
        Me.flxDATA.Rows.Count = 1
        Me.flxDATA.Rows.DefaultSize = 23
        Me.flxDATA.Size = New System.Drawing.Size(1236, 407)
        Me.flxDATA.StyleInfo = resources.GetString("flxDATA.StyleInfo")
        Me.flxDATA.TabIndex = 62
        Me.flxDATA.VisualStyle = C1.Win.C1FlexGrid.VisualStyle.Office2010Silver
        '
        'FrmM0040
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.ClientSize = New System.Drawing.Size(1264, 712)
        Me.Controls.Add(Me.flxDATA)
        Me.Controls.Add(Me.gbxFilter)
        Me.HelpButton = True
        Me.Name = "FrmM0040"
        Me.ShowStatusBar = True
        Me.Text = ""
        Me.Controls.SetChildIndex(Me.gbxFilter, 0)
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
        Me.Controls.SetChildIndex(Me.flxDATA, 0)
        CType(Me.ErrorProvider, System.ComponentModel.ISupportInitialize).EndInit()
        Me.gbxFilter.ResumeLayout(False)
        Me.tlpFilter.ResumeLayout(False)
        Me.tlpFilter.PerformLayout()
        CType(Me.VWM004SYAINBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.flxDATA, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents SaveFileDialog As System.Windows.Forms.SaveFileDialog
    Friend WithEvents OpenFileDialog As System.Windows.Forms.OpenFileDialog
    Friend WithEvents Label3 As Label
    Friend WithEvents gbxFilter As GroupBox
    Friend WithEvents tlpFilter As TableLayoutPanel
    Friend WithEvents mtxSIMEI As MaskedTextBoxEx
    Friend WithEvents Label1 As Label
    Friend WithEvents mtxSYAIN_NO As MaskedTextBoxEx
    Friend WithEvents Label2 As Label
    Friend WithEvents mtxSIMEI_KANA As MaskedTextBoxEx
    Friend WithEvents chkDeletedRowVisibled As CheckBox
    Friend WithEvents Label4 As Label
    Friend WithEvents Label5 As Label
    Friend WithEvents cmbSYAIN_KB As ComboboxEx
    Friend WithEvents cmbYAKUSYOKU_KB As ComboboxEx
    Friend WithEvents chkTaisyokuRowVisibled As CheckBox
    Friend WithEvents Label6 As Label
    Friend WithEvents Label7 As Label
    Friend WithEvents dtbNYUSYA_YMD_FROM As DateTextBoxEx
    Friend WithEvents dtbNYUSYA_YMD_To As DateTextBoxEx
    Friend WithEvents VWM004SYAINBindingSource As BindingSource
    Friend WithEvents flxDATA As C1.Win.C1FlexGrid.C1FlexGrid
End Class
