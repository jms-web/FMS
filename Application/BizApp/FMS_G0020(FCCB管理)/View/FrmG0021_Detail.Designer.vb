<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class FrmG0021_Detail
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
        Me.components = New System.ComponentModel.Container()
        Me.cmbBUHIN_BANGO = New JMS_COMMON.ComboboxEx()
        Me.cmbKISYU = New JMS_COMMON.ComboboxEx()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.mtxHOKUKO_NO = New JMS_COMMON.MaskedTextBoxEx()
        Me.Label14 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.cmbBUMON = New JMS_COMMON.ComboboxEx()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.cmbHINMEI = New JMS_COMMON.ComboboxEx()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.cmbKISO_TANTO = New JMS_COMMON.ComboboxEx()
        Me.Label26 = New System.Windows.Forms.Label()
        Me.ComboboxEx1 = New JMS_COMMON.ComboboxEx()
        Me.lblSYANAI_CD = New System.Windows.Forms.Label()
        Me.cmbSYANAI_CD = New JMS_COMMON.ComboboxEx()
        Me.Label16 = New System.Windows.Forms.Label()
        Me.dtDraft = New JMS_COMMON.DateTextBoxEx()
        Me.D005CARJBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.TabSTAGE = New System.Windows.Forms.TabControl()
        Me.tabSTAGE01 = New JMS_COMMON.TabPageEx()
        Me.PnlPROCESS = New JMS_COMMON.PanelEx()
        Me.pnlFOLLOW_PROCESS_OUTFLOW_FILEPATH = New JMS_COMMON.PanelEx()
        Me.Label36 = New System.Windows.Forms.Label()
        Me.btnOpenFOLLOW_PROCESS_OUTFLOW_FILEPATH = New System.Windows.Forms.Button()
        Me.fpnlFOLLOW_PROCESS_OUTFLOW_FILEPATH = New System.Windows.Forms.FlowLayoutPanel()
        Me.lblFOLLOW_PROCESS_OUTFLOW_FILEPATH = New System.Windows.Forms.LinkLabel()
        Me.lblFOLLOW_PROCESS_OUTFLOW_FILEPATH_Clear = New System.Windows.Forms.LinkLabel()
        Me.LinkLabel9 = New System.Windows.Forms.LinkLabel()
        Me.LinkLabel10 = New System.Windows.Forms.LinkLabel()
        Me.LinkLabel19 = New System.Windows.Forms.LinkLabel()
        Me.LinkLabel20 = New System.Windows.Forms.LinkLabel()
        Me.LinkLabel31 = New System.Windows.Forms.LinkLabel()
        Me.LinkLabel32 = New System.Windows.Forms.LinkLabel()
        Me.LinkLabel33 = New System.Windows.Forms.LinkLabel()
        Me.LinkLabel34 = New System.Windows.Forms.LinkLabel()
        Me.pnlOTHER_PROCESS_INFLUENCE_FILEPATH = New JMS_COMMON.PanelEx()
        Me.Label30 = New System.Windows.Forms.Label()
        Me.btnOpenOTHER_PROCESS_INFLUENCE_FILEPATH = New System.Windows.Forms.Button()
        Me.fpnlOTHER_PROCESS_INFLUENCE_FILEPATH = New System.Windows.Forms.FlowLayoutPanel()
        Me.lblOTHER_PROCESS_INFLUENCE_FILEPATH = New System.Windows.Forms.LinkLabel()
        Me.lblOTHER_PROCESS_INFLUENCE_FILEPATH_Clear = New System.Windows.Forms.LinkLabel()
        Me.LinkLabel11 = New System.Windows.Forms.LinkLabel()
        Me.LinkLabel12 = New System.Windows.Forms.LinkLabel()
        Me.LinkLabel13 = New System.Windows.Forms.LinkLabel()
        Me.LinkLabel14 = New System.Windows.Forms.LinkLabel()
        Me.LinkLabel15 = New System.Windows.Forms.LinkLabel()
        Me.LinkLabel16 = New System.Windows.Forms.LinkLabel()
        Me.LinkLabel17 = New System.Windows.Forms.LinkLabel()
        Me.LinkLabel18 = New System.Windows.Forms.LinkLabel()
        Me.txtFOLLOW_PROCESS_OUTFLOW_MEMO = New JMS_COMMON.TextBoxEx()
        Me.txtOTHER_PROCESS_INFLUENCE_MEMO = New JMS_COMMON.TextBoxEx()
        Me.PanelEx5 = New JMS_COMMON.PanelEx()
        Me.rbtnFOLLOW_PROCESS_OUTFLOW_KB_F = New System.Windows.Forms.RadioButton()
        Me.rbtnFOLLOW_PROCESS_OUTFLOW_KB_T = New System.Windows.Forms.RadioButton()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.PanelEx4 = New JMS_COMMON.PanelEx()
        Me.rbtnOTHER_PROCESS_INFLUENCE_KB_F = New System.Windows.Forms.RadioButton()
        Me.rbtnOTHER_PROCESS_INFLUENCE_KB_T = New System.Windows.Forms.RadioButton()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.Label15 = New System.Windows.Forms.Label()
        Me.pnlSYOCHI_JISSI = New JMS_COMMON.PanelEx()
        Me.pnlSYOCHI_FILEPATH = New JMS_COMMON.PanelEx()
        Me.Label44 = New System.Windows.Forms.Label()
        Me.btnOpenSYOCHI_FILEPATH = New System.Windows.Forms.Button()
        Me.fpnlSYOCHI_FILEPATH = New System.Windows.Forms.FlowLayoutPanel()
        Me.lblSYOCHI_FILEPATH = New System.Windows.Forms.LinkLabel()
        Me.lblSYOCHI_FILEPATH_Clear = New System.Windows.Forms.LinkLabel()
        Me.LinkLabel21 = New System.Windows.Forms.LinkLabel()
        Me.LinkLabel22 = New System.Windows.Forms.LinkLabel()
        Me.LinkLabel23 = New System.Windows.Forms.LinkLabel()
        Me.LinkLabel24 = New System.Windows.Forms.LinkLabel()
        Me.LinkLabel25 = New System.Windows.Forms.LinkLabel()
        Me.LinkLabel26 = New System.Windows.Forms.LinkLabel()
        Me.LinkLabel27 = New System.Windows.Forms.LinkLabel()
        Me.LinkLabel28 = New System.Windows.Forms.LinkLabel()
        Me.txtSYOCHI_MEMO = New JMS_COMMON.TextBoxEx()
        Me.Label42 = New System.Windows.Forms.Label()
        Me.Label41 = New System.Windows.Forms.Label()
        Me.lblOTHER_PROCESS_NAIYOU = New System.Windows.Forms.Label()
        Me.txtOTHER_PROCESS_NAIYOU = New JMS_COMMON.TextBoxEx()
        Me.dtOTHER_PROCESS_YMD = New JMS_COMMON.DateTextBoxEx()
        Me.Label39 = New System.Windows.Forms.Label()
        Me.txtZAIKO_SIKAKE_NAIYOU = New JMS_COMMON.TextBoxEx()
        Me.dtZAIKO_SIKAKE_YMD = New JMS_COMMON.DateTextBoxEx()
        Me.Label38 = New System.Windows.Forms.Label()
        Me.txtKOKYAKU_NOUNYU_NAIYOU = New JMS_COMMON.TextBoxEx()
        Me.dtKOKYAKU_NOUNYU_YMD = New JMS_COMMON.DateTextBoxEx()
        Me.lblSTAGE16 = New System.Windows.Forms.Label()
        Me.lblSTAGEFlame13 = New System.Windows.Forms.Label()
        Me.pnlFCR = New JMS_COMMON.PanelEx()
        Me.pnlKOKYAKU_EIKYO_HANTEI_FILEPATH = New JMS_COMMON.PanelEx()
        Me.Label37 = New System.Windows.Forms.Label()
        Me.btnOpenKOKYAKU_EIKYO_HANTEI_FILEPATH = New System.Windows.Forms.Button()
        Me.fpnlKOKYAKU_EIKYO_HANTEI_FILEPATH = New System.Windows.Forms.FlowLayoutPanel()
        Me.lblKOKYAKU_EIKYO_HANTEI_FILEPATH = New System.Windows.Forms.LinkLabel()
        Me.lblKOKYAKU_EIKYO_HANTEI_FILEPATH_Clear = New System.Windows.Forms.LinkLabel()
        Me.LinkLabel3 = New System.Windows.Forms.LinkLabel()
        Me.LinkLabel4 = New System.Windows.Forms.LinkLabel()
        Me.LinkLabel5 = New System.Windows.Forms.LinkLabel()
        Me.LinkLabel6 = New System.Windows.Forms.LinkLabel()
        Me.LinkLabel7 = New System.Windows.Forms.LinkLabel()
        Me.LinkLabel8 = New System.Windows.Forms.LinkLabel()
        Me.LinkLabel29 = New System.Windows.Forms.LinkLabel()
        Me.LinkLabel30 = New System.Windows.Forms.LinkLabel()
        Me.lblTAISYO_KOKYAKU = New System.Windows.Forms.Label()
        Me.txtTAISYO_KOKYAKU = New JMS_COMMON.TextBoxEx()
        Me.lblKOKYAKU_EIKYO_ETC_COMMENT = New System.Windows.Forms.Label()
        Me.lblTUCHI_SYUDAN = New System.Windows.Forms.Label()
        Me.lblHITUYO_TETUDUKI_ZIKO = New System.Windows.Forms.Label()
        Me.lblTUCHI_YMD = New System.Windows.Forms.Label()
        Me.pnlrbtnTUCHI = New JMS_COMMON.PanelEx()
        Me.rbtnKOKYAKU_EIKYO_TUCHI_HANTEI_KB_F = New System.Windows.Forms.RadioButton()
        Me.rbtnKOKYAKU_EIKYO_TUCHI_HANTEI_KB_T = New System.Windows.Forms.RadioButton()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.cmbKOKYAKU_EIKYO_HANTEI_COMMENT = New JMS_COMMON.ComboboxEx()
        Me.PanelEx1 = New JMS_COMMON.PanelEx()
        Me.rbtnKOKYAKU_EIKYO_HANTEI_KB_F = New System.Windows.Forms.RadioButton()
        Me.rbtnKOKYAKU_EIKYO_HANTEI_KB_T = New System.Windows.Forms.RadioButton()
        Me.lblSETUMON_1 = New System.Windows.Forms.Label()
        Me.txtKOKYAKU_EIKYO_NAIYO = New JMS_COMMON.TextBoxEx()
        Me.lblKOKYAKU_EIKYO_NAIYO = New System.Windows.Forms.Label()
        Me.txtKOKYAKU_EIKYO_ETC_COMMENT = New JMS_COMMON.TextBoxEx()
        Me.txtKAKUNIN_SYUDAN = New JMS_COMMON.TextBoxEx()
        Me.lblKOKYAKU_EIKYO_TUCHI_HANTEI_KB = New System.Windows.Forms.Label()
        Me.lblKOKYAKU_EIKYO_HANTEI_COMMENT = New System.Windows.Forms.Label()
        Me.lblKAKUNIN_SYUDAN = New System.Windows.Forms.Label()
        Me.txtHITUYO_TETUDUKI_ZIKO = New JMS_COMMON.TextBoxEx()
        Me.txtTUCHI_SYUDAN = New JMS_COMMON.TextBoxEx()
        Me.dtTUCHI_YMD = New JMS_COMMON.DateTextBoxEx()
        Me.lblCARFlame = New System.Windows.Forms.Label()
        Me.pnlZESEI_SYOCHI = New JMS_COMMON.PanelEx()
        Me.lblZESEI_SYOCHIFlame = New System.Windows.Forms.Label()
        Me.lblSTAGE10 = New System.Windows.Forms.Label()
        Me.pnlSYOCHI_KIROKU = New JMS_COMMON.PanelEx()
        Me.lblSYOCHI_KIROKUFlame = New System.Windows.Forms.Label()
        Me.lblSTAGE08 = New System.Windows.Forms.Label()
        Me.cmbST01_DestTANTO = New JMS_COMMON.ComboboxEx()
        Me.mtxST01_NextStageName = New JMS_COMMON.MaskedTextBoxEx()
        Me.Label123 = New System.Windows.Forms.Label()
        Me.Label124 = New System.Windows.Forms.Label()
        Me.Label139 = New System.Windows.Forms.Label()
        Me.mtxST01_UPD_YMD = New JMS_COMMON.MaskedTextBoxEx()
        Me.flpnlStageIndex = New System.Windows.Forms.FlowLayoutPanel()
        Me.rsbtnST01 = New JMS_COMMON.RibbonShapeRadioButton()
        Me.rsbtnST02 = New JMS_COMMON.RibbonShapeRadioButton()
        Me.rsbtnST03 = New JMS_COMMON.RibbonShapeRadioButton()
        Me.rsbtnST04 = New JMS_COMMON.RibbonShapeRadioButton()
        Me.rsbtnST05 = New JMS_COMMON.RibbonShapeRadioButton()
        Me.rsbtnST06 = New JMS_COMMON.RibbonShapeRadioButton()
        Me.rsbtnST99 = New JMS_COMMON.RibbonShapeRadioButton()
        Me.InfoToolTip = New System.Windows.Forms.ToolTip(Me.components)
        Me.Label3 = New System.Windows.Forms.Label()
        Me.TextBoxEx1 = New JMS_COMMON.TextBoxEx()
        Me.Label17 = New System.Windows.Forms.Label()
        Me.PanelEx2 = New JMS_COMMON.PanelEx()
        Me.tlpFilter = New System.Windows.Forms.TableLayoutPanel()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.MaskedTextBoxEx1 = New JMS_COMMON.MaskedTextBoxEx()
        Me.MaskedTextBoxEx2 = New JMS_COMMON.MaskedTextBoxEx()
        Me.Label18 = New System.Windows.Forms.Label()
        Me.dtST05_UPD_YMD = New JMS_COMMON.DateTextBoxEx()
        Me.cmbST05_DestTANTO = New JMS_COMMON.ComboboxEx()
        Me.Label48 = New System.Windows.Forms.Label()
        Me.Label23 = New System.Windows.Forms.Label()
        Me.Label21 = New System.Windows.Forms.Label()
        Me.Label24 = New System.Windows.Forms.Label()
        Me.Label20 = New System.Windows.Forms.Label()
        Me.Label19 = New System.Windows.Forms.Label()
        CType(Me.ErrorProvider, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.WarningErrorProvider, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.D005CARJBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.TabSTAGE.SuspendLayout()
        Me.tabSTAGE01.SuspendLayout()
        Me.PnlPROCESS.SuspendLayout()
        Me.pnlFOLLOW_PROCESS_OUTFLOW_FILEPATH.SuspendLayout()
        Me.fpnlFOLLOW_PROCESS_OUTFLOW_FILEPATH.SuspendLayout()
        Me.pnlOTHER_PROCESS_INFLUENCE_FILEPATH.SuspendLayout()
        Me.fpnlOTHER_PROCESS_INFLUENCE_FILEPATH.SuspendLayout()
        Me.PanelEx5.SuspendLayout()
        Me.PanelEx4.SuspendLayout()
        Me.pnlSYOCHI_JISSI.SuspendLayout()
        Me.pnlSYOCHI_FILEPATH.SuspendLayout()
        Me.fpnlSYOCHI_FILEPATH.SuspendLayout()
        Me.pnlFCR.SuspendLayout()
        Me.pnlKOKYAKU_EIKYO_HANTEI_FILEPATH.SuspendLayout()
        Me.fpnlKOKYAKU_EIKYO_HANTEI_FILEPATH.SuspendLayout()
        Me.pnlrbtnTUCHI.SuspendLayout()
        Me.PanelEx1.SuspendLayout()
        Me.pnlZESEI_SYOCHI.SuspendLayout()
        Me.pnlSYOCHI_KIROKU.SuspendLayout()
        Me.flpnlStageIndex.SuspendLayout()
        Me.PanelEx2.SuspendLayout()
        Me.tlpFilter.SuspendLayout()
        Me.SuspendLayout()
        '
        'lblRecordCount
        '
        Me.lblRecordCount.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.lblRecordCount.ForeColor = System.Drawing.SystemColors.ControlText
        Me.lblRecordCount.Location = New System.Drawing.Point(1205, 31)
        Me.lblRecordCount.Size = New System.Drawing.Size(43, 24)
        Me.lblRecordCount.Visible = False
        '
        'cmdFunc1
        '
        Me.cmdFunc1.Image = Global.FMS.My.Resources.Resources._imgBase_floppydisk32x32
        Me.cmdFunc1.Location = New System.Drawing.Point(9, 744)
        Me.cmdFunc1.Text = "一時保存(F1)"
        '
        'cmdFunc2
        '
        Me.cmdFunc2.Image = Global.FMS.My.Resources.Resources.申請
        Me.cmdFunc2.Location = New System.Drawing.Point(216, 744)
        Me.cmdFunc2.Text = "承認&&申請(F2)"
        '
        'cmdFunc3
        '
        Me.cmdFunc3.Image = Global.FMS.My.Resources.Resources._imgApplication_form32x32
        Me.cmdFunc3.Location = New System.Drawing.Point(423, 744)
        Me.cmdFunc3.Text = "NCR表示(F3)"
        '
        'cmdFunc4
        '
        Me.cmdFunc4.Image = Global.FMS.My.Resources.Resources._imgRight32x32
        Me.cmdFunc4.Location = New System.Drawing.Point(630, 744)
        Me.cmdFunc4.Text = "転送(F4)"
        '
        'cmdFunc5
        '
        Me.cmdFunc5.Image = Global.FMS.My.Resources.Resources._imgUndo32x32
        Me.cmdFunc5.Location = New System.Drawing.Point(837, 744)
        Me.cmdFunc5.Text = "差戻し(F5)"
        '
        'cmdFunc6
        '
        Me.cmdFunc6.Location = New System.Drawing.Point(1044, 744)
        '
        'cmdFunc12
        '
        Me.cmdFunc12.Image = Global.FMS.My.Resources.Resources._imgLog_Out32x32
        Me.cmdFunc12.Location = New System.Drawing.Point(1044, 792)
        Me.cmdFunc12.Text = "閉じる(F12)"
        '
        'cmdFunc11
        '
        Me.cmdFunc11.Image = Global.FMS.My.Resources.Resources.履歴
        Me.cmdFunc11.Location = New System.Drawing.Point(837, 792)
        Me.cmdFunc11.Text = "履歴表示(F11)"
        '
        'cmdFunc10
        '
        Me.cmdFunc10.Image = Global.FMS.My.Resources.Resources._imgPrint32x32
        Me.cmdFunc10.Location = New System.Drawing.Point(630, 792)
        Me.cmdFunc10.Text = "印刷プレビュー(F10)"
        '
        'cmdFunc7
        '
        Me.cmdFunc7.Location = New System.Drawing.Point(9, 792)
        '
        'cmdFunc9
        '
        Me.cmdFunc9.Image = Global.FMS.My.Resources.Resources._imgApplication_form32x32
        Me.cmdFunc9.Location = New System.Drawing.Point(423, 792)
        Me.cmdFunc9.Text = "CAR表示(F9)"
        '
        'cmdFunc8
        '
        Me.cmdFunc8.Location = New System.Drawing.Point(216, 792)
        '
        'lblTytle
        '
        Me.lblTytle.Font = New System.Drawing.Font("Meiryo UI", 24.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTytle.ForeColor = System.Drawing.SystemColors.ControlText
        Me.lblTytle.Text = "FCCB記録書"
        '
        'cmbBUHIN_BANGO
        '
        Me.cmbBUHIN_BANGO.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cmbBUHIN_BANGO.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cmbBUHIN_BANGO.BackColor = System.Drawing.SystemColors.Window
        Me.tlpFilter.SetColumnSpan(Me.cmbBUHIN_BANGO, 7)
        Me.cmbBUHIN_BANGO.Cursor = System.Windows.Forms.Cursors.Default
        Me.cmbBUHIN_BANGO.DisplayMember = "DISP"
        Me.cmbBUHIN_BANGO.DropDownWidth = 230
        Me.cmbBUHIN_BANGO.Font = New System.Drawing.Font("Meiryo UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.cmbBUHIN_BANGO.ForeColor = System.Drawing.SystemColors.ControlText
        Me.cmbBUHIN_BANGO.FormattingEnabled = True
        Me.cmbBUHIN_BANGO.HorizontalContentAlignment = System.Drawing.StringAlignment.Near
        Me.cmbBUHIN_BANGO.ImeMode = System.Windows.Forms.ImeMode.Disable
        Me.cmbBUHIN_BANGO.IsSelected = False
        Me.cmbBUHIN_BANGO.Location = New System.Drawing.Point(103, 93)
        Me.cmbBUHIN_BANGO.Name = "cmbBUHIN_BANGO"
        Me.cmbBUHIN_BANGO.NullValue = " "
        Me.cmbBUHIN_BANGO.Size = New System.Drawing.Size(134, 25)
        Me.cmbBUHIN_BANGO.TabIndex = 277
        Me.cmbBUHIN_BANGO.Text = "(選択)"
        Me.cmbBUHIN_BANGO.ValueMember = "VALUE"
        '
        'cmbKISYU
        '
        Me.cmbKISYU.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cmbKISYU.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cmbKISYU.BackColor = System.Drawing.SystemColors.Window
        Me.tlpFilter.SetColumnSpan(Me.cmbKISYU, 7)
        Me.cmbKISYU.Cursor = System.Windows.Forms.Cursors.Default
        Me.cmbKISYU.DisplayMember = "DISP"
        Me.cmbKISYU.Font = New System.Drawing.Font("Meiryo UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.cmbKISYU.ForeColor = System.Drawing.SystemColors.ControlText
        Me.cmbKISYU.FormattingEnabled = True
        Me.cmbKISYU.HorizontalContentAlignment = System.Drawing.StringAlignment.Near
        Me.cmbKISYU.ImeMode = System.Windows.Forms.ImeMode.Disable
        Me.cmbKISYU.IsSelected = False
        Me.cmbKISYU.Location = New System.Drawing.Point(103, 63)
        Me.cmbKISYU.Name = "cmbKISYU"
        Me.cmbKISYU.NullValue = " "
        Me.cmbKISYU.Size = New System.Drawing.Size(134, 25)
        Me.cmbKISYU.TabIndex = 276
        Me.cmbKISYU.Text = "(選択)"
        Me.cmbKISYU.ValueMember = "VALUE"
        '
        'Label8
        '
        Me.tlpFilter.SetColumnSpan(Me.Label8, 5)
        Me.Label8.Font = New System.Drawing.Font("Meiryo UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label8.Location = New System.Drawing.Point(3, 30)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(94, 30)
        Me.Label8.TabIndex = 267
        Me.Label8.Text = "FCCB No:"
        Me.Label8.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'mtxHOKUKO_NO
        '
        Me.mtxHOKUKO_NO.BackColor = System.Drawing.SystemColors.Control
        Me.tlpFilter.SetColumnSpan(Me.mtxHOKUKO_NO, 5)
        Me.mtxHOKUKO_NO.Font = New System.Drawing.Font("Meiryo UI", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.mtxHOKUKO_NO.ImeMode = System.Windows.Forms.ImeMode.Disable
        Me.mtxHOKUKO_NO.InputRequired = False
        Me.mtxHOKUKO_NO.Location = New System.Drawing.Point(103, 33)
        Me.mtxHOKUKO_NO.MaxByteLength = 0
        Me.mtxHOKUKO_NO.Name = "mtxHOKUKO_NO"
        Me.mtxHOKUKO_NO.ReadOnly = True
        Me.mtxHOKUKO_NO.SelectAllText = False
        Me.mtxHOKUKO_NO.Size = New System.Drawing.Size(94, 24)
        Me.mtxHOKUKO_NO.TabIndex = 266
        Me.mtxHOKUKO_NO.TabStop = False
        Me.mtxHOKUKO_NO.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.mtxHOKUKO_NO.WatermarkColor = System.Drawing.Color.Empty
        Me.mtxHOKUKO_NO.WatermarkText = Nothing
        '
        'Label14
        '
        Me.tlpFilter.SetColumnSpan(Me.Label14, 5)
        Me.Label14.Font = New System.Drawing.Font("Meiryo UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label14.Location = New System.Drawing.Point(3, 60)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(94, 30)
        Me.Label14.TabIndex = 268
        Me.Label14.Text = "機種:"
        Me.Label14.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label4
        '
        Me.tlpFilter.SetColumnSpan(Me.Label4, 5)
        Me.Label4.Font = New System.Drawing.Font("Meiryo UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label4.Location = New System.Drawing.Point(3, 90)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(94, 30)
        Me.Label4.TabIndex = 280
        Me.Label4.Text = "部品番号:"
        Me.Label4.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'cmbBUMON
        '
        Me.cmbBUMON.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cmbBUMON.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cmbBUMON.BackColor = System.Drawing.SystemColors.Window
        Me.tlpFilter.SetColumnSpan(Me.cmbBUMON, 5)
        Me.cmbBUMON.Cursor = System.Windows.Forms.Cursors.Default
        Me.cmbBUMON.DisplayMember = "DISP"
        Me.cmbBUMON.Font = New System.Drawing.Font("Meiryo UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.cmbBUMON.ForeColor = System.Drawing.SystemColors.ControlText
        Me.cmbBUMON.FormattingEnabled = True
        Me.cmbBUMON.HorizontalContentAlignment = System.Drawing.StringAlignment.Near
        Me.cmbBUMON.ImeMode = System.Windows.Forms.ImeMode.Disable
        Me.cmbBUMON.IsSelected = False
        Me.cmbBUMON.Location = New System.Drawing.Point(343, 33)
        Me.cmbBUMON.Name = "cmbBUMON"
        Me.cmbBUMON.NullValue = " "
        Me.cmbBUMON.Size = New System.Drawing.Size(94, 25)
        Me.cmbBUMON.TabIndex = 275
        Me.cmbBUMON.Text = "(選択)"
        Me.cmbBUMON.ValueMember = "VALUE"
        '
        'Label5
        '
        Me.tlpFilter.SetColumnSpan(Me.Label5, 5)
        Me.Label5.Font = New System.Drawing.Font("Meiryo UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label5.Location = New System.Drawing.Point(243, 30)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(94, 30)
        Me.Label5.TabIndex = 271
        Me.Label5.Text = "製品区分:"
        Me.Label5.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label7
        '
        Me.tlpFilter.SetColumnSpan(Me.Label7, 5)
        Me.Label7.Font = New System.Drawing.Font("Meiryo UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label7.Location = New System.Drawing.Point(3, 120)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(94, 30)
        Me.Label7.TabIndex = 281
        Me.Label7.Text = "部品名称:"
        Me.Label7.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'cmbHINMEI
        '
        Me.cmbHINMEI.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cmbHINMEI.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cmbHINMEI.BackColor = System.Drawing.SystemColors.Window
        Me.tlpFilter.SetColumnSpan(Me.cmbHINMEI, 19)
        Me.cmbHINMEI.Cursor = System.Windows.Forms.Cursors.Default
        Me.cmbHINMEI.DisplayMember = "DISP"
        Me.cmbHINMEI.Font = New System.Drawing.Font("Meiryo UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.cmbHINMEI.ForeColor = System.Drawing.SystemColors.ControlText
        Me.cmbHINMEI.FormattingEnabled = True
        Me.cmbHINMEI.HorizontalContentAlignment = System.Drawing.StringAlignment.Near
        Me.cmbHINMEI.ImeMode = System.Windows.Forms.ImeMode.Disable
        Me.cmbHINMEI.IsSelected = False
        Me.cmbHINMEI.Location = New System.Drawing.Point(103, 123)
        Me.cmbHINMEI.Name = "cmbHINMEI"
        Me.cmbHINMEI.NullValue = " "
        Me.cmbHINMEI.Size = New System.Drawing.Size(374, 25)
        Me.cmbHINMEI.TabIndex = 279
        Me.cmbHINMEI.Text = "(選択)"
        Me.cmbHINMEI.ValueMember = "VALUE"
        '
        'Label6
        '
        Me.tlpFilter.SetColumnSpan(Me.Label6, 5)
        Me.Label6.Font = New System.Drawing.Font("Meiryo UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label6.Location = New System.Drawing.Point(443, 30)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(94, 30)
        Me.Label6.TabIndex = 270
        Me.Label6.Text = "起草者:"
        Me.Label6.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'cmbKISO_TANTO
        '
        Me.cmbKISO_TANTO.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cmbKISO_TANTO.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cmbKISO_TANTO.BackColor = System.Drawing.SystemColors.Window
        Me.tlpFilter.SetColumnSpan(Me.cmbKISO_TANTO, 7)
        Me.cmbKISO_TANTO.Cursor = System.Windows.Forms.Cursors.Default
        Me.cmbKISO_TANTO.DisplayMember = "DISP"
        Me.cmbKISO_TANTO.Font = New System.Drawing.Font("Meiryo UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.cmbKISO_TANTO.ForeColor = System.Drawing.SystemColors.ControlText
        Me.cmbKISO_TANTO.FormattingEnabled = True
        Me.cmbKISO_TANTO.HorizontalContentAlignment = System.Drawing.StringAlignment.Near
        Me.cmbKISO_TANTO.ImeMode = System.Windows.Forms.ImeMode.Disable
        Me.cmbKISO_TANTO.IsSelected = False
        Me.cmbKISO_TANTO.Location = New System.Drawing.Point(543, 33)
        Me.cmbKISO_TANTO.Name = "cmbKISO_TANTO"
        Me.cmbKISO_TANTO.NullValue = " "
        Me.cmbKISO_TANTO.Size = New System.Drawing.Size(134, 25)
        Me.cmbKISO_TANTO.TabIndex = 273
        Me.cmbKISO_TANTO.Text = "(選択)"
        Me.cmbKISO_TANTO.ValueMember = "VALUE"
        '
        'Label26
        '
        Me.tlpFilter.SetColumnSpan(Me.Label26, 5)
        Me.Label26.Font = New System.Drawing.Font("Meiryo UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label26.Location = New System.Drawing.Point(683, 30)
        Me.Label26.Name = "Label26"
        Me.Label26.Size = New System.Drawing.Size(94, 30)
        Me.Label26.TabIndex = 269
        Me.Label26.Text = "FCCB議長:"
        Me.Label26.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'ComboboxEx1
        '
        Me.ComboboxEx1.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.ComboboxEx1.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.ComboboxEx1.BackColor = System.Drawing.SystemColors.Window
        Me.tlpFilter.SetColumnSpan(Me.ComboboxEx1, 7)
        Me.ComboboxEx1.Cursor = System.Windows.Forms.Cursors.Default
        Me.ComboboxEx1.DisplayMember = "DISP"
        Me.ComboboxEx1.Font = New System.Drawing.Font("Meiryo UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.ComboboxEx1.ForeColor = System.Drawing.SystemColors.ControlText
        Me.ComboboxEx1.FormattingEnabled = True
        Me.ComboboxEx1.HorizontalContentAlignment = System.Drawing.StringAlignment.Near
        Me.ComboboxEx1.ImeMode = System.Windows.Forms.ImeMode.Disable
        Me.ComboboxEx1.IsSelected = False
        Me.ComboboxEx1.Location = New System.Drawing.Point(783, 33)
        Me.ComboboxEx1.Name = "ComboboxEx1"
        Me.ComboboxEx1.NullValue = " "
        Me.ComboboxEx1.Size = New System.Drawing.Size(134, 25)
        Me.ComboboxEx1.TabIndex = 272
        Me.ComboboxEx1.Text = "(選択)"
        Me.ComboboxEx1.ValueMember = "VALUE"
        '
        'lblSYANAI_CD
        '
        Me.tlpFilter.SetColumnSpan(Me.lblSYANAI_CD, 5)
        Me.lblSYANAI_CD.Font = New System.Drawing.Font("Meiryo UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.lblSYANAI_CD.Location = New System.Drawing.Point(243, 90)
        Me.lblSYANAI_CD.Name = "lblSYANAI_CD"
        Me.lblSYANAI_CD.Size = New System.Drawing.Size(94, 30)
        Me.lblSYANAI_CD.TabIndex = 282
        Me.lblSYANAI_CD.Text = "社内コード:"
        Me.lblSYANAI_CD.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.lblSYANAI_CD.Visible = False
        '
        'cmbSYANAI_CD
        '
        Me.cmbSYANAI_CD.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cmbSYANAI_CD.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cmbSYANAI_CD.BackColor = System.Drawing.SystemColors.Window
        Me.tlpFilter.SetColumnSpan(Me.cmbSYANAI_CD, 7)
        Me.cmbSYANAI_CD.Cursor = System.Windows.Forms.Cursors.Default
        Me.cmbSYANAI_CD.DisplayMember = "DISP"
        Me.cmbSYANAI_CD.Font = New System.Drawing.Font("Meiryo UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.cmbSYANAI_CD.ForeColor = System.Drawing.SystemColors.ControlText
        Me.cmbSYANAI_CD.FormattingEnabled = True
        Me.cmbSYANAI_CD.HorizontalContentAlignment = System.Drawing.StringAlignment.Near
        Me.cmbSYANAI_CD.ImeMode = System.Windows.Forms.ImeMode.Disable
        Me.cmbSYANAI_CD.IsSelected = False
        Me.cmbSYANAI_CD.Location = New System.Drawing.Point(343, 93)
        Me.cmbSYANAI_CD.Name = "cmbSYANAI_CD"
        Me.cmbSYANAI_CD.NullValue = " "
        Me.cmbSYANAI_CD.Size = New System.Drawing.Size(134, 25)
        Me.cmbSYANAI_CD.TabIndex = 278
        Me.cmbSYANAI_CD.Text = "(選択)"
        Me.cmbSYANAI_CD.ValueMember = "VALUE"
        Me.cmbSYANAI_CD.Visible = False
        '
        'Label16
        '
        Me.tlpFilter.SetColumnSpan(Me.Label16, 5)
        Me.Label16.Font = New System.Drawing.Font("Meiryo UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label16.Location = New System.Drawing.Point(923, 30)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(94, 30)
        Me.Label16.TabIndex = 283
        Me.Label16.Text = "起草日:"
        Me.Label16.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'dtDraft
        '
        Me.dtDraft.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.tlpFilter.SetColumnSpan(Me.dtDraft, 7)
        Me.dtDraft.GotFocusedColor = System.Drawing.Color.FromArgb(CType(CType(190, Byte), Integer), CType(CType(180, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.dtDraft.Location = New System.Drawing.Point(1023, 33)
        Me.dtDraft.MaxDate = New Date(9998, 12, 31, 0, 0, 0, 0)
        Me.dtDraft.MinDate = New Date(1753, 1, 1, 0, 0, 0, 0)
        Me.dtDraft.MinimumSize = New System.Drawing.Size(98, 24)
        Me.dtDraft.Name = "dtDraft"
        Me.dtDraft.ReadOnly = False
        Me.dtDraft.Size = New System.Drawing.Size(98, 24)
        Me.dtDraft.TabIndex = 274
        Me.dtDraft.Value = ""
        Me.dtDraft.ValueNonFormat = ""
        '
        'D005CARJBindingSource
        '
        Me.D005CARJBindingSource.DataSource = GetType(MODEL.D005_CAR_J)
        '
        'TabSTAGE
        '
        Me.TabSTAGE.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TabSTAGE.Controls.Add(Me.tabSTAGE01)
        Me.TabSTAGE.Font = New System.Drawing.Font("Meiryo UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.TabSTAGE.HotTrack = True
        Me.TabSTAGE.Location = New System.Drawing.Point(12, 220)
        Me.TabSTAGE.Multiline = True
        Me.TabSTAGE.Name = "TabSTAGE"
        Me.TabSTAGE.SelectedIndex = 0
        Me.TabSTAGE.Size = New System.Drawing.Size(1240, 518)
        Me.TabSTAGE.TabIndex = 218
        '
        'tabSTAGE01
        '
        Me.tabSTAGE01.AutoScroll = True
        Me.tabSTAGE01.BackColor = System.Drawing.SystemColors.Control
        Me.tabSTAGE01.Controls.Add(Me.PnlPROCESS)
        Me.tabSTAGE01.Controls.Add(Me.pnlSYOCHI_JISSI)
        Me.tabSTAGE01.Controls.Add(Me.pnlFCR)
        Me.tabSTAGE01.Controls.Add(Me.pnlZESEI_SYOCHI)
        Me.tabSTAGE01.Controls.Add(Me.pnlSYOCHI_KIROKU)
        Me.tabSTAGE01.Controls.Add(Me.cmbST01_DestTANTO)
        Me.tabSTAGE01.Controls.Add(Me.mtxST01_NextStageName)
        Me.tabSTAGE01.Controls.Add(Me.Label123)
        Me.tabSTAGE01.Controls.Add(Me.Label124)
        Me.tabSTAGE01.Controls.Add(Me.Label139)
        Me.tabSTAGE01.Controls.Add(Me.mtxST01_UPD_YMD)
        Me.tabSTAGE01.HitEnabled = False
        Me.tabSTAGE01.Location = New System.Drawing.Point(4, 26)
        Me.tabSTAGE01.Name = "tabSTAGE01"
        Me.tabSTAGE01.Padding = New System.Windows.Forms.Padding(3)
        Me.tabSTAGE01.Size = New System.Drawing.Size(1232, 488)
        Me.tabSTAGE01.TabIndex = 0
        '
        'PnlPROCESS
        '
        Me.PnlPROCESS.BackColor = System.Drawing.SystemColors.Control
        Me.PnlPROCESS.Controls.Add(Me.pnlFOLLOW_PROCESS_OUTFLOW_FILEPATH)
        Me.PnlPROCESS.Controls.Add(Me.pnlOTHER_PROCESS_INFLUENCE_FILEPATH)
        Me.PnlPROCESS.Controls.Add(Me.txtFOLLOW_PROCESS_OUTFLOW_MEMO)
        Me.PnlPROCESS.Controls.Add(Me.txtOTHER_PROCESS_INFLUENCE_MEMO)
        Me.PnlPROCESS.Controls.Add(Me.PanelEx5)
        Me.PnlPROCESS.Controls.Add(Me.Label12)
        Me.PnlPROCESS.Controls.Add(Me.PanelEx4)
        Me.PnlPROCESS.Controls.Add(Me.Label11)
        Me.PnlPROCESS.Controls.Add(Me.Label13)
        Me.PnlPROCESS.Controls.Add(Me.Label15)
        Me.PnlPROCESS.HitEnabled = False
        Me.PnlPROCESS.Location = New System.Drawing.Point(3, 702)
        Me.PnlPROCESS.Margin = New System.Windows.Forms.Padding(2)
        Me.PnlPROCESS.MinimumSize = New System.Drawing.Size(1212, 0)
        Me.PnlPROCESS.Name = "PnlPROCESS"
        Me.PnlPROCESS.Size = New System.Drawing.Size(1212, 154)
        Me.PnlPROCESS.TabIndex = 4
        '
        'pnlFOLLOW_PROCESS_OUTFLOW_FILEPATH
        '
        Me.pnlFOLLOW_PROCESS_OUTFLOW_FILEPATH.Controls.Add(Me.Label36)
        Me.pnlFOLLOW_PROCESS_OUTFLOW_FILEPATH.Controls.Add(Me.btnOpenFOLLOW_PROCESS_OUTFLOW_FILEPATH)
        Me.pnlFOLLOW_PROCESS_OUTFLOW_FILEPATH.Controls.Add(Me.fpnlFOLLOW_PROCESS_OUTFLOW_FILEPATH)
        Me.pnlFOLLOW_PROCESS_OUTFLOW_FILEPATH.HitEnabled = False
        Me.pnlFOLLOW_PROCESS_OUTFLOW_FILEPATH.Location = New System.Drawing.Point(582, 114)
        Me.pnlFOLLOW_PROCESS_OUTFLOW_FILEPATH.Name = "pnlFOLLOW_PROCESS_OUTFLOW_FILEPATH"
        Me.pnlFOLLOW_PROCESS_OUTFLOW_FILEPATH.Padding = New System.Windows.Forms.Padding(1)
        Me.pnlFOLLOW_PROCESS_OUTFLOW_FILEPATH.Size = New System.Drawing.Size(487, 35)
        Me.pnlFOLLOW_PROCESS_OUTFLOW_FILEPATH.TabIndex = 343
        '
        'Label36
        '
        Me.Label36.AutoSize = True
        Me.Label36.Font = New System.Drawing.Font("Meiryo UI", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label36.Location = New System.Drawing.Point(2, 14)
        Me.Label36.Margin = New System.Windows.Forms.Padding(3, 3, 3, 0)
        Me.Label36.Name = "Label36"
        Me.Label36.Size = New System.Drawing.Size(60, 15)
        Me.Label36.TabIndex = 335
        Me.Label36.Text = "詳細資料:"
        Me.Label36.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'btnOpenFOLLOW_PROCESS_OUTFLOW_FILEPATH
        '
        Me.btnOpenFOLLOW_PROCESS_OUTFLOW_FILEPATH.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnOpenFOLLOW_PROCESS_OUTFLOW_FILEPATH.Image = Global.FMS.My.Resources.Resources._imgFolder_Open_16x16
        Me.btnOpenFOLLOW_PROCESS_OUTFLOW_FILEPATH.Location = New System.Drawing.Point(433, 7)
        Me.btnOpenFOLLOW_PROCESS_OUTFLOW_FILEPATH.Name = "btnOpenFOLLOW_PROCESS_OUTFLOW_FILEPATH"
        Me.btnOpenFOLLOW_PROCESS_OUTFLOW_FILEPATH.Size = New System.Drawing.Size(54, 24)
        Me.btnOpenFOLLOW_PROCESS_OUTFLOW_FILEPATH.TabIndex = 333
        Me.btnOpenFOLLOW_PROCESS_OUTFLOW_FILEPATH.UseVisualStyleBackColor = True
        '
        'fpnlFOLLOW_PROCESS_OUTFLOW_FILEPATH
        '
        Me.fpnlFOLLOW_PROCESS_OUTFLOW_FILEPATH.BackColor = System.Drawing.SystemColors.Window
        Me.fpnlFOLLOW_PROCESS_OUTFLOW_FILEPATH.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.fpnlFOLLOW_PROCESS_OUTFLOW_FILEPATH.Controls.Add(Me.lblFOLLOW_PROCESS_OUTFLOW_FILEPATH)
        Me.fpnlFOLLOW_PROCESS_OUTFLOW_FILEPATH.Controls.Add(Me.lblFOLLOW_PROCESS_OUTFLOW_FILEPATH_Clear)
        Me.fpnlFOLLOW_PROCESS_OUTFLOW_FILEPATH.Controls.Add(Me.LinkLabel9)
        Me.fpnlFOLLOW_PROCESS_OUTFLOW_FILEPATH.Controls.Add(Me.LinkLabel10)
        Me.fpnlFOLLOW_PROCESS_OUTFLOW_FILEPATH.Controls.Add(Me.LinkLabel19)
        Me.fpnlFOLLOW_PROCESS_OUTFLOW_FILEPATH.Controls.Add(Me.LinkLabel20)
        Me.fpnlFOLLOW_PROCESS_OUTFLOW_FILEPATH.Controls.Add(Me.LinkLabel31)
        Me.fpnlFOLLOW_PROCESS_OUTFLOW_FILEPATH.Controls.Add(Me.LinkLabel32)
        Me.fpnlFOLLOW_PROCESS_OUTFLOW_FILEPATH.Controls.Add(Me.LinkLabel33)
        Me.fpnlFOLLOW_PROCESS_OUTFLOW_FILEPATH.Controls.Add(Me.LinkLabel34)
        Me.fpnlFOLLOW_PROCESS_OUTFLOW_FILEPATH.Location = New System.Drawing.Point(63, 9)
        Me.fpnlFOLLOW_PROCESS_OUTFLOW_FILEPATH.Name = "fpnlFOLLOW_PROCESS_OUTFLOW_FILEPATH"
        Me.fpnlFOLLOW_PROCESS_OUTFLOW_FILEPATH.Size = New System.Drawing.Size(364, 22)
        Me.fpnlFOLLOW_PROCESS_OUTFLOW_FILEPATH.TabIndex = 334
        '
        'lblFOLLOW_PROCESS_OUTFLOW_FILEPATH
        '
        Me.lblFOLLOW_PROCESS_OUTFLOW_FILEPATH.AutoSize = True
        Me.lblFOLLOW_PROCESS_OUTFLOW_FILEPATH.Location = New System.Drawing.Point(0, 0)
        Me.lblFOLLOW_PROCESS_OUTFLOW_FILEPATH.Margin = New System.Windows.Forms.Padding(0)
        Me.lblFOLLOW_PROCESS_OUTFLOW_FILEPATH.Name = "lblFOLLOW_PROCESS_OUTFLOW_FILEPATH"
        Me.lblFOLLOW_PROCESS_OUTFLOW_FILEPATH.Size = New System.Drawing.Size(37, 17)
        Me.lblFOLLOW_PROCESS_OUTFLOW_FILEPATH.TabIndex = 126
        Me.lblFOLLOW_PROCESS_OUTFLOW_FILEPATH.TabStop = True
        Me.lblFOLLOW_PROCESS_OUTFLOW_FILEPATH.Text = "link1"
        Me.lblFOLLOW_PROCESS_OUTFLOW_FILEPATH.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.lblFOLLOW_PROCESS_OUTFLOW_FILEPATH.Visible = False
        '
        'lblFOLLOW_PROCESS_OUTFLOW_FILEPATH_Clear
        '
        Me.lblFOLLOW_PROCESS_OUTFLOW_FILEPATH_Clear.AutoSize = True
        Me.lblFOLLOW_PROCESS_OUTFLOW_FILEPATH_Clear.Cursor = System.Windows.Forms.Cursors.Hand
        Me.lblFOLLOW_PROCESS_OUTFLOW_FILEPATH_Clear.Dock = System.Windows.Forms.DockStyle.Right
        Me.fpnlFOLLOW_PROCESS_OUTFLOW_FILEPATH.SetFlowBreak(Me.lblFOLLOW_PROCESS_OUTFLOW_FILEPATH_Clear, True)
        Me.lblFOLLOW_PROCESS_OUTFLOW_FILEPATH_Clear.Font = New System.Drawing.Font("Meiryo UI", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.lblFOLLOW_PROCESS_OUTFLOW_FILEPATH_Clear.LinkBehavior = System.Windows.Forms.LinkBehavior.NeverUnderline
        Me.lblFOLLOW_PROCESS_OUTFLOW_FILEPATH_Clear.LinkColor = System.Drawing.Color.Red
        Me.lblFOLLOW_PROCESS_OUTFLOW_FILEPATH_Clear.Location = New System.Drawing.Point(37, 0)
        Me.lblFOLLOW_PROCESS_OUTFLOW_FILEPATH_Clear.Margin = New System.Windows.Forms.Padding(0)
        Me.lblFOLLOW_PROCESS_OUTFLOW_FILEPATH_Clear.Name = "lblFOLLOW_PROCESS_OUTFLOW_FILEPATH_Clear"
        Me.lblFOLLOW_PROCESS_OUTFLOW_FILEPATH_Clear.Size = New System.Drawing.Size(19, 17)
        Me.lblFOLLOW_PROCESS_OUTFLOW_FILEPATH_Clear.TabIndex = 128
        Me.lblFOLLOW_PROCESS_OUTFLOW_FILEPATH_Clear.TabStop = True
        Me.lblFOLLOW_PROCESS_OUTFLOW_FILEPATH_Clear.Text = "×"
        Me.lblFOLLOW_PROCESS_OUTFLOW_FILEPATH_Clear.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.lblFOLLOW_PROCESS_OUTFLOW_FILEPATH_Clear.Visible = False
        '
        'LinkLabel9
        '
        Me.LinkLabel9.AutoSize = True
        Me.LinkLabel9.Location = New System.Drawing.Point(0, 17)
        Me.LinkLabel9.Margin = New System.Windows.Forms.Padding(0)
        Me.LinkLabel9.Name = "LinkLabel9"
        Me.LinkLabel9.Size = New System.Drawing.Size(37, 17)
        Me.LinkLabel9.TabIndex = 129
        Me.LinkLabel9.TabStop = True
        Me.LinkLabel9.Text = "link2"
        Me.LinkLabel9.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.LinkLabel9.Visible = False
        '
        'LinkLabel10
        '
        Me.LinkLabel10.AutoSize = True
        Me.LinkLabel10.Cursor = System.Windows.Forms.Cursors.Hand
        Me.fpnlFOLLOW_PROCESS_OUTFLOW_FILEPATH.SetFlowBreak(Me.LinkLabel10, True)
        Me.LinkLabel10.Font = New System.Drawing.Font("Meiryo UI", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.LinkLabel10.LinkBehavior = System.Windows.Forms.LinkBehavior.NeverUnderline
        Me.LinkLabel10.LinkColor = System.Drawing.Color.Red
        Me.LinkLabel10.Location = New System.Drawing.Point(37, 17)
        Me.LinkLabel10.Margin = New System.Windows.Forms.Padding(0)
        Me.LinkLabel10.Name = "LinkLabel10"
        Me.LinkLabel10.Size = New System.Drawing.Size(19, 17)
        Me.LinkLabel10.TabIndex = 130
        Me.LinkLabel10.TabStop = True
        Me.LinkLabel10.Text = "×"
        Me.LinkLabel10.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.LinkLabel10.Visible = False
        '
        'LinkLabel19
        '
        Me.LinkLabel19.AutoSize = True
        Me.LinkLabel19.Location = New System.Drawing.Point(0, 34)
        Me.LinkLabel19.Margin = New System.Windows.Forms.Padding(0)
        Me.LinkLabel19.Name = "LinkLabel19"
        Me.LinkLabel19.Size = New System.Drawing.Size(37, 17)
        Me.LinkLabel19.TabIndex = 129
        Me.LinkLabel19.TabStop = True
        Me.LinkLabel19.Text = "link3"
        Me.LinkLabel19.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.LinkLabel19.Visible = False
        '
        'LinkLabel20
        '
        Me.LinkLabel20.AutoSize = True
        Me.LinkLabel20.Cursor = System.Windows.Forms.Cursors.Hand
        Me.fpnlFOLLOW_PROCESS_OUTFLOW_FILEPATH.SetFlowBreak(Me.LinkLabel20, True)
        Me.LinkLabel20.Font = New System.Drawing.Font("Meiryo UI", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.LinkLabel20.LinkBehavior = System.Windows.Forms.LinkBehavior.NeverUnderline
        Me.LinkLabel20.LinkColor = System.Drawing.Color.Red
        Me.LinkLabel20.Location = New System.Drawing.Point(37, 34)
        Me.LinkLabel20.Margin = New System.Windows.Forms.Padding(0)
        Me.LinkLabel20.Name = "LinkLabel20"
        Me.LinkLabel20.Size = New System.Drawing.Size(19, 17)
        Me.LinkLabel20.TabIndex = 130
        Me.LinkLabel20.TabStop = True
        Me.LinkLabel20.Text = "×"
        Me.LinkLabel20.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.LinkLabel20.Visible = False
        '
        'LinkLabel31
        '
        Me.LinkLabel31.AutoSize = True
        Me.LinkLabel31.Location = New System.Drawing.Point(0, 51)
        Me.LinkLabel31.Margin = New System.Windows.Forms.Padding(0)
        Me.LinkLabel31.Name = "LinkLabel31"
        Me.LinkLabel31.Size = New System.Drawing.Size(37, 17)
        Me.LinkLabel31.TabIndex = 129
        Me.LinkLabel31.TabStop = True
        Me.LinkLabel31.Text = "link4"
        Me.LinkLabel31.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.LinkLabel31.Visible = False
        '
        'LinkLabel32
        '
        Me.LinkLabel32.AutoSize = True
        Me.LinkLabel32.Cursor = System.Windows.Forms.Cursors.Hand
        Me.fpnlFOLLOW_PROCESS_OUTFLOW_FILEPATH.SetFlowBreak(Me.LinkLabel32, True)
        Me.LinkLabel32.Font = New System.Drawing.Font("Meiryo UI", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.LinkLabel32.LinkBehavior = System.Windows.Forms.LinkBehavior.NeverUnderline
        Me.LinkLabel32.LinkColor = System.Drawing.Color.Red
        Me.LinkLabel32.Location = New System.Drawing.Point(37, 51)
        Me.LinkLabel32.Margin = New System.Windows.Forms.Padding(0)
        Me.LinkLabel32.Name = "LinkLabel32"
        Me.LinkLabel32.Size = New System.Drawing.Size(19, 17)
        Me.LinkLabel32.TabIndex = 130
        Me.LinkLabel32.TabStop = True
        Me.LinkLabel32.Text = "×"
        Me.LinkLabel32.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.LinkLabel32.Visible = False
        '
        'LinkLabel33
        '
        Me.LinkLabel33.AutoSize = True
        Me.LinkLabel33.Location = New System.Drawing.Point(0, 68)
        Me.LinkLabel33.Margin = New System.Windows.Forms.Padding(0)
        Me.LinkLabel33.Name = "LinkLabel33"
        Me.LinkLabel33.Size = New System.Drawing.Size(37, 17)
        Me.LinkLabel33.TabIndex = 129
        Me.LinkLabel33.TabStop = True
        Me.LinkLabel33.Text = "link5"
        Me.LinkLabel33.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.LinkLabel33.Visible = False
        '
        'LinkLabel34
        '
        Me.LinkLabel34.AutoSize = True
        Me.LinkLabel34.Cursor = System.Windows.Forms.Cursors.Hand
        Me.fpnlFOLLOW_PROCESS_OUTFLOW_FILEPATH.SetFlowBreak(Me.LinkLabel34, True)
        Me.LinkLabel34.Font = New System.Drawing.Font("Meiryo UI", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.LinkLabel34.LinkBehavior = System.Windows.Forms.LinkBehavior.NeverUnderline
        Me.LinkLabel34.LinkColor = System.Drawing.Color.Red
        Me.LinkLabel34.Location = New System.Drawing.Point(37, 68)
        Me.LinkLabel34.Margin = New System.Windows.Forms.Padding(0)
        Me.LinkLabel34.Name = "LinkLabel34"
        Me.LinkLabel34.Size = New System.Drawing.Size(19, 17)
        Me.LinkLabel34.TabIndex = 130
        Me.LinkLabel34.TabStop = True
        Me.LinkLabel34.Text = "×"
        Me.LinkLabel34.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.LinkLabel34.Visible = False
        '
        'pnlOTHER_PROCESS_INFLUENCE_FILEPATH
        '
        Me.pnlOTHER_PROCESS_INFLUENCE_FILEPATH.Controls.Add(Me.Label30)
        Me.pnlOTHER_PROCESS_INFLUENCE_FILEPATH.Controls.Add(Me.btnOpenOTHER_PROCESS_INFLUENCE_FILEPATH)
        Me.pnlOTHER_PROCESS_INFLUENCE_FILEPATH.Controls.Add(Me.fpnlOTHER_PROCESS_INFLUENCE_FILEPATH)
        Me.pnlOTHER_PROCESS_INFLUENCE_FILEPATH.HitEnabled = False
        Me.pnlOTHER_PROCESS_INFLUENCE_FILEPATH.Location = New System.Drawing.Point(38, 114)
        Me.pnlOTHER_PROCESS_INFLUENCE_FILEPATH.Name = "pnlOTHER_PROCESS_INFLUENCE_FILEPATH"
        Me.pnlOTHER_PROCESS_INFLUENCE_FILEPATH.Padding = New System.Windows.Forms.Padding(1)
        Me.pnlOTHER_PROCESS_INFLUENCE_FILEPATH.Size = New System.Drawing.Size(487, 35)
        Me.pnlOTHER_PROCESS_INFLUENCE_FILEPATH.TabIndex = 341
        '
        'Label30
        '
        Me.Label30.AutoSize = True
        Me.Label30.Font = New System.Drawing.Font("Meiryo UI", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label30.Location = New System.Drawing.Point(2, 14)
        Me.Label30.Margin = New System.Windows.Forms.Padding(3, 3, 3, 0)
        Me.Label30.Name = "Label30"
        Me.Label30.Size = New System.Drawing.Size(60, 15)
        Me.Label30.TabIndex = 335
        Me.Label30.Text = "詳細資料:"
        Me.Label30.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'btnOpenOTHER_PROCESS_INFLUENCE_FILEPATH
        '
        Me.btnOpenOTHER_PROCESS_INFLUENCE_FILEPATH.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnOpenOTHER_PROCESS_INFLUENCE_FILEPATH.Image = Global.FMS.My.Resources.Resources._imgFolder_Open_16x16
        Me.btnOpenOTHER_PROCESS_INFLUENCE_FILEPATH.Location = New System.Drawing.Point(433, 7)
        Me.btnOpenOTHER_PROCESS_INFLUENCE_FILEPATH.Name = "btnOpenOTHER_PROCESS_INFLUENCE_FILEPATH"
        Me.btnOpenOTHER_PROCESS_INFLUENCE_FILEPATH.Size = New System.Drawing.Size(54, 24)
        Me.btnOpenOTHER_PROCESS_INFLUENCE_FILEPATH.TabIndex = 333
        Me.btnOpenOTHER_PROCESS_INFLUENCE_FILEPATH.UseVisualStyleBackColor = True
        '
        'fpnlOTHER_PROCESS_INFLUENCE_FILEPATH
        '
        Me.fpnlOTHER_PROCESS_INFLUENCE_FILEPATH.BackColor = System.Drawing.SystemColors.Window
        Me.fpnlOTHER_PROCESS_INFLUENCE_FILEPATH.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.fpnlOTHER_PROCESS_INFLUENCE_FILEPATH.Controls.Add(Me.lblOTHER_PROCESS_INFLUENCE_FILEPATH)
        Me.fpnlOTHER_PROCESS_INFLUENCE_FILEPATH.Controls.Add(Me.lblOTHER_PROCESS_INFLUENCE_FILEPATH_Clear)
        Me.fpnlOTHER_PROCESS_INFLUENCE_FILEPATH.Controls.Add(Me.LinkLabel11)
        Me.fpnlOTHER_PROCESS_INFLUENCE_FILEPATH.Controls.Add(Me.LinkLabel12)
        Me.fpnlOTHER_PROCESS_INFLUENCE_FILEPATH.Controls.Add(Me.LinkLabel13)
        Me.fpnlOTHER_PROCESS_INFLUENCE_FILEPATH.Controls.Add(Me.LinkLabel14)
        Me.fpnlOTHER_PROCESS_INFLUENCE_FILEPATH.Controls.Add(Me.LinkLabel15)
        Me.fpnlOTHER_PROCESS_INFLUENCE_FILEPATH.Controls.Add(Me.LinkLabel16)
        Me.fpnlOTHER_PROCESS_INFLUENCE_FILEPATH.Controls.Add(Me.LinkLabel17)
        Me.fpnlOTHER_PROCESS_INFLUENCE_FILEPATH.Controls.Add(Me.LinkLabel18)
        Me.fpnlOTHER_PROCESS_INFLUENCE_FILEPATH.Location = New System.Drawing.Point(63, 9)
        Me.fpnlOTHER_PROCESS_INFLUENCE_FILEPATH.Name = "fpnlOTHER_PROCESS_INFLUENCE_FILEPATH"
        Me.fpnlOTHER_PROCESS_INFLUENCE_FILEPATH.Size = New System.Drawing.Size(364, 22)
        Me.fpnlOTHER_PROCESS_INFLUENCE_FILEPATH.TabIndex = 334
        '
        'lblOTHER_PROCESS_INFLUENCE_FILEPATH
        '
        Me.lblOTHER_PROCESS_INFLUENCE_FILEPATH.AutoSize = True
        Me.lblOTHER_PROCESS_INFLUENCE_FILEPATH.Location = New System.Drawing.Point(0, 0)
        Me.lblOTHER_PROCESS_INFLUENCE_FILEPATH.Margin = New System.Windows.Forms.Padding(0)
        Me.lblOTHER_PROCESS_INFLUENCE_FILEPATH.Name = "lblOTHER_PROCESS_INFLUENCE_FILEPATH"
        Me.lblOTHER_PROCESS_INFLUENCE_FILEPATH.Size = New System.Drawing.Size(37, 17)
        Me.lblOTHER_PROCESS_INFLUENCE_FILEPATH.TabIndex = 126
        Me.lblOTHER_PROCESS_INFLUENCE_FILEPATH.TabStop = True
        Me.lblOTHER_PROCESS_INFLUENCE_FILEPATH.Text = "link1"
        Me.lblOTHER_PROCESS_INFLUENCE_FILEPATH.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.lblOTHER_PROCESS_INFLUENCE_FILEPATH.Visible = False
        '
        'lblOTHER_PROCESS_INFLUENCE_FILEPATH_Clear
        '
        Me.lblOTHER_PROCESS_INFLUENCE_FILEPATH_Clear.AutoSize = True
        Me.lblOTHER_PROCESS_INFLUENCE_FILEPATH_Clear.Cursor = System.Windows.Forms.Cursors.Hand
        Me.lblOTHER_PROCESS_INFLUENCE_FILEPATH_Clear.Dock = System.Windows.Forms.DockStyle.Right
        Me.fpnlOTHER_PROCESS_INFLUENCE_FILEPATH.SetFlowBreak(Me.lblOTHER_PROCESS_INFLUENCE_FILEPATH_Clear, True)
        Me.lblOTHER_PROCESS_INFLUENCE_FILEPATH_Clear.Font = New System.Drawing.Font("Meiryo UI", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.lblOTHER_PROCESS_INFLUENCE_FILEPATH_Clear.LinkBehavior = System.Windows.Forms.LinkBehavior.NeverUnderline
        Me.lblOTHER_PROCESS_INFLUENCE_FILEPATH_Clear.LinkColor = System.Drawing.Color.Red
        Me.lblOTHER_PROCESS_INFLUENCE_FILEPATH_Clear.Location = New System.Drawing.Point(37, 0)
        Me.lblOTHER_PROCESS_INFLUENCE_FILEPATH_Clear.Margin = New System.Windows.Forms.Padding(0)
        Me.lblOTHER_PROCESS_INFLUENCE_FILEPATH_Clear.Name = "lblOTHER_PROCESS_INFLUENCE_FILEPATH_Clear"
        Me.lblOTHER_PROCESS_INFLUENCE_FILEPATH_Clear.Size = New System.Drawing.Size(19, 17)
        Me.lblOTHER_PROCESS_INFLUENCE_FILEPATH_Clear.TabIndex = 128
        Me.lblOTHER_PROCESS_INFLUENCE_FILEPATH_Clear.TabStop = True
        Me.lblOTHER_PROCESS_INFLUENCE_FILEPATH_Clear.Text = "×"
        Me.lblOTHER_PROCESS_INFLUENCE_FILEPATH_Clear.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.lblOTHER_PROCESS_INFLUENCE_FILEPATH_Clear.Visible = False
        '
        'LinkLabel11
        '
        Me.LinkLabel11.AutoSize = True
        Me.LinkLabel11.Location = New System.Drawing.Point(0, 17)
        Me.LinkLabel11.Margin = New System.Windows.Forms.Padding(0)
        Me.LinkLabel11.Name = "LinkLabel11"
        Me.LinkLabel11.Size = New System.Drawing.Size(37, 17)
        Me.LinkLabel11.TabIndex = 129
        Me.LinkLabel11.TabStop = True
        Me.LinkLabel11.Text = "link2"
        Me.LinkLabel11.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.LinkLabel11.Visible = False
        '
        'LinkLabel12
        '
        Me.LinkLabel12.AutoSize = True
        Me.LinkLabel12.Cursor = System.Windows.Forms.Cursors.Hand
        Me.fpnlOTHER_PROCESS_INFLUENCE_FILEPATH.SetFlowBreak(Me.LinkLabel12, True)
        Me.LinkLabel12.Font = New System.Drawing.Font("Meiryo UI", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.LinkLabel12.LinkBehavior = System.Windows.Forms.LinkBehavior.NeverUnderline
        Me.LinkLabel12.LinkColor = System.Drawing.Color.Red
        Me.LinkLabel12.Location = New System.Drawing.Point(37, 17)
        Me.LinkLabel12.Margin = New System.Windows.Forms.Padding(0)
        Me.LinkLabel12.Name = "LinkLabel12"
        Me.LinkLabel12.Size = New System.Drawing.Size(19, 17)
        Me.LinkLabel12.TabIndex = 130
        Me.LinkLabel12.TabStop = True
        Me.LinkLabel12.Text = "×"
        Me.LinkLabel12.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.LinkLabel12.Visible = False
        '
        'LinkLabel13
        '
        Me.LinkLabel13.AutoSize = True
        Me.LinkLabel13.Location = New System.Drawing.Point(0, 34)
        Me.LinkLabel13.Margin = New System.Windows.Forms.Padding(0)
        Me.LinkLabel13.Name = "LinkLabel13"
        Me.LinkLabel13.Size = New System.Drawing.Size(37, 17)
        Me.LinkLabel13.TabIndex = 129
        Me.LinkLabel13.TabStop = True
        Me.LinkLabel13.Text = "link3"
        Me.LinkLabel13.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.LinkLabel13.Visible = False
        '
        'LinkLabel14
        '
        Me.LinkLabel14.AutoSize = True
        Me.LinkLabel14.Cursor = System.Windows.Forms.Cursors.Hand
        Me.fpnlOTHER_PROCESS_INFLUENCE_FILEPATH.SetFlowBreak(Me.LinkLabel14, True)
        Me.LinkLabel14.Font = New System.Drawing.Font("Meiryo UI", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.LinkLabel14.LinkBehavior = System.Windows.Forms.LinkBehavior.NeverUnderline
        Me.LinkLabel14.LinkColor = System.Drawing.Color.Red
        Me.LinkLabel14.Location = New System.Drawing.Point(37, 34)
        Me.LinkLabel14.Margin = New System.Windows.Forms.Padding(0)
        Me.LinkLabel14.Name = "LinkLabel14"
        Me.LinkLabel14.Size = New System.Drawing.Size(19, 17)
        Me.LinkLabel14.TabIndex = 130
        Me.LinkLabel14.TabStop = True
        Me.LinkLabel14.Text = "×"
        Me.LinkLabel14.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.LinkLabel14.Visible = False
        '
        'LinkLabel15
        '
        Me.LinkLabel15.AutoSize = True
        Me.LinkLabel15.Location = New System.Drawing.Point(0, 51)
        Me.LinkLabel15.Margin = New System.Windows.Forms.Padding(0)
        Me.LinkLabel15.Name = "LinkLabel15"
        Me.LinkLabel15.Size = New System.Drawing.Size(37, 17)
        Me.LinkLabel15.TabIndex = 129
        Me.LinkLabel15.TabStop = True
        Me.LinkLabel15.Text = "link4"
        Me.LinkLabel15.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.LinkLabel15.Visible = False
        '
        'LinkLabel16
        '
        Me.LinkLabel16.AutoSize = True
        Me.LinkLabel16.Cursor = System.Windows.Forms.Cursors.Hand
        Me.fpnlOTHER_PROCESS_INFLUENCE_FILEPATH.SetFlowBreak(Me.LinkLabel16, True)
        Me.LinkLabel16.Font = New System.Drawing.Font("Meiryo UI", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.LinkLabel16.LinkBehavior = System.Windows.Forms.LinkBehavior.NeverUnderline
        Me.LinkLabel16.LinkColor = System.Drawing.Color.Red
        Me.LinkLabel16.Location = New System.Drawing.Point(37, 51)
        Me.LinkLabel16.Margin = New System.Windows.Forms.Padding(0)
        Me.LinkLabel16.Name = "LinkLabel16"
        Me.LinkLabel16.Size = New System.Drawing.Size(19, 17)
        Me.LinkLabel16.TabIndex = 130
        Me.LinkLabel16.TabStop = True
        Me.LinkLabel16.Text = "×"
        Me.LinkLabel16.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.LinkLabel16.Visible = False
        '
        'LinkLabel17
        '
        Me.LinkLabel17.AutoSize = True
        Me.LinkLabel17.Location = New System.Drawing.Point(0, 68)
        Me.LinkLabel17.Margin = New System.Windows.Forms.Padding(0)
        Me.LinkLabel17.Name = "LinkLabel17"
        Me.LinkLabel17.Size = New System.Drawing.Size(37, 17)
        Me.LinkLabel17.TabIndex = 129
        Me.LinkLabel17.TabStop = True
        Me.LinkLabel17.Text = "link5"
        Me.LinkLabel17.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.LinkLabel17.Visible = False
        '
        'LinkLabel18
        '
        Me.LinkLabel18.AutoSize = True
        Me.LinkLabel18.Cursor = System.Windows.Forms.Cursors.Hand
        Me.fpnlOTHER_PROCESS_INFLUENCE_FILEPATH.SetFlowBreak(Me.LinkLabel18, True)
        Me.LinkLabel18.Font = New System.Drawing.Font("Meiryo UI", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.LinkLabel18.LinkBehavior = System.Windows.Forms.LinkBehavior.NeverUnderline
        Me.LinkLabel18.LinkColor = System.Drawing.Color.Red
        Me.LinkLabel18.Location = New System.Drawing.Point(37, 68)
        Me.LinkLabel18.Margin = New System.Windows.Forms.Padding(0)
        Me.LinkLabel18.Name = "LinkLabel18"
        Me.LinkLabel18.Size = New System.Drawing.Size(19, 17)
        Me.LinkLabel18.TabIndex = 130
        Me.LinkLabel18.TabStop = True
        Me.LinkLabel18.Text = "×"
        Me.LinkLabel18.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.LinkLabel18.Visible = False
        '
        'txtFOLLOW_PROCESS_OUTFLOW_MEMO
        '
        Me.txtFOLLOW_PROCESS_OUTFLOW_MEMO.AcceptsReturn = True
        Me.txtFOLLOW_PROCESS_OUTFLOW_MEMO.BackColor = System.Drawing.SystemColors.Window
        Me.txtFOLLOW_PROCESS_OUTFLOW_MEMO.ImeMode = System.Windows.Forms.ImeMode.[On]
        Me.txtFOLLOW_PROCESS_OUTFLOW_MEMO.InputRequired = False
        Me.txtFOLLOW_PROCESS_OUTFLOW_MEMO.Location = New System.Drawing.Point(582, 64)
        Me.txtFOLLOW_PROCESS_OUTFLOW_MEMO.MaxByteLength = 200
        Me.txtFOLLOW_PROCESS_OUTFLOW_MEMO.MaxLength = 100
        Me.txtFOLLOW_PROCESS_OUTFLOW_MEMO.Multiline = True
        Me.txtFOLLOW_PROCESS_OUTFLOW_MEMO.Name = "txtFOLLOW_PROCESS_OUTFLOW_MEMO"
        Me.txtFOLLOW_PROCESS_OUTFLOW_MEMO.SelectAllText = False
        Me.txtFOLLOW_PROCESS_OUTFLOW_MEMO.ShowRemainingChars = True
        Me.txtFOLLOW_PROCESS_OUTFLOW_MEMO.Size = New System.Drawing.Size(487, 46)
        Me.txtFOLLOW_PROCESS_OUTFLOW_MEMO.TabIndex = 340
        Me.txtFOLLOW_PROCESS_OUTFLOW_MEMO.WatermarkColor = System.Drawing.Color.Empty
        Me.txtFOLLOW_PROCESS_OUTFLOW_MEMO.WatermarkText = Nothing
        '
        'txtOTHER_PROCESS_INFLUENCE_MEMO
        '
        Me.txtOTHER_PROCESS_INFLUENCE_MEMO.AcceptsReturn = True
        Me.txtOTHER_PROCESS_INFLUENCE_MEMO.BackColor = System.Drawing.SystemColors.Window
        Me.txtOTHER_PROCESS_INFLUENCE_MEMO.ImeMode = System.Windows.Forms.ImeMode.[On]
        Me.txtOTHER_PROCESS_INFLUENCE_MEMO.InputRequired = False
        Me.txtOTHER_PROCESS_INFLUENCE_MEMO.Location = New System.Drawing.Point(38, 66)
        Me.txtOTHER_PROCESS_INFLUENCE_MEMO.MaxByteLength = 200
        Me.txtOTHER_PROCESS_INFLUENCE_MEMO.MaxLength = 100
        Me.txtOTHER_PROCESS_INFLUENCE_MEMO.Multiline = True
        Me.txtOTHER_PROCESS_INFLUENCE_MEMO.Name = "txtOTHER_PROCESS_INFLUENCE_MEMO"
        Me.txtOTHER_PROCESS_INFLUENCE_MEMO.SelectAllText = False
        Me.txtOTHER_PROCESS_INFLUENCE_MEMO.ShowRemainingChars = True
        Me.txtOTHER_PROCESS_INFLUENCE_MEMO.Size = New System.Drawing.Size(487, 44)
        Me.txtOTHER_PROCESS_INFLUENCE_MEMO.TabIndex = 336
        Me.txtOTHER_PROCESS_INFLUENCE_MEMO.WatermarkColor = System.Drawing.Color.Empty
        Me.txtOTHER_PROCESS_INFLUENCE_MEMO.WatermarkText = Nothing
        '
        'PanelEx5
        '
        Me.PanelEx5.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.PanelEx5.Controls.Add(Me.rbtnFOLLOW_PROCESS_OUTFLOW_KB_F)
        Me.PanelEx5.Controls.Add(Me.rbtnFOLLOW_PROCESS_OUTFLOW_KB_T)
        Me.PanelEx5.HitEnabled = False
        Me.PanelEx5.Location = New System.Drawing.Point(972, 31)
        Me.PanelEx5.Name = "PanelEx5"
        Me.PanelEx5.Size = New System.Drawing.Size(97, 27)
        Me.PanelEx5.TabIndex = 1
        '
        'rbtnFOLLOW_PROCESS_OUTFLOW_KB_F
        '
        Me.rbtnFOLLOW_PROCESS_OUTFLOW_KB_F.AutoSize = True
        Me.rbtnFOLLOW_PROCESS_OUTFLOW_KB_F.Dock = System.Windows.Forms.DockStyle.Right
        Me.rbtnFOLLOW_PROCESS_OUTFLOW_KB_F.Location = New System.Drawing.Point(43, 0)
        Me.rbtnFOLLOW_PROCESS_OUTFLOW_KB_F.Name = "rbtnFOLLOW_PROCESS_OUTFLOW_KB_F"
        Me.rbtnFOLLOW_PROCESS_OUTFLOW_KB_F.Padding = New System.Windows.Forms.Padding(3)
        Me.rbtnFOLLOW_PROCESS_OUTFLOW_KB_F.Size = New System.Drawing.Size(52, 25)
        Me.rbtnFOLLOW_PROCESS_OUTFLOW_KB_F.TabIndex = 1
        Me.rbtnFOLLOW_PROCESS_OUTFLOW_KB_F.Text = "なし"
        Me.rbtnFOLLOW_PROCESS_OUTFLOW_KB_F.UseVisualStyleBackColor = True
        '
        'rbtnFOLLOW_PROCESS_OUTFLOW_KB_T
        '
        Me.rbtnFOLLOW_PROCESS_OUTFLOW_KB_T.AutoSize = True
        Me.rbtnFOLLOW_PROCESS_OUTFLOW_KB_T.Dock = System.Windows.Forms.DockStyle.Left
        Me.rbtnFOLLOW_PROCESS_OUTFLOW_KB_T.Location = New System.Drawing.Point(0, 0)
        Me.rbtnFOLLOW_PROCESS_OUTFLOW_KB_T.Name = "rbtnFOLLOW_PROCESS_OUTFLOW_KB_T"
        Me.rbtnFOLLOW_PROCESS_OUTFLOW_KB_T.Padding = New System.Windows.Forms.Padding(3)
        Me.rbtnFOLLOW_PROCESS_OUTFLOW_KB_T.Size = New System.Drawing.Size(51, 25)
        Me.rbtnFOLLOW_PROCESS_OUTFLOW_KB_T.TabIndex = 0
        Me.rbtnFOLLOW_PROCESS_OUTFLOW_KB_T.Text = "あり"
        Me.rbtnFOLLOW_PROCESS_OUTFLOW_KB_T.UseVisualStyleBackColor = True
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Font = New System.Drawing.Font("Meiryo UI", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label12.ForeColor = System.Drawing.Color.Black
        Me.Label12.Location = New System.Drawing.Point(559, 36)
        Me.Label12.Margin = New System.Windows.Forms.Padding(3, 3, 3, 0)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(367, 17)
        Me.Label12.TabIndex = 329
        Me.Label12.Text = "(2) 発生工程以降の他のプロセスへの不適合製品の流出の可能性"
        Me.Label12.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'PanelEx4
        '
        Me.PanelEx4.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.PanelEx4.Controls.Add(Me.rbtnOTHER_PROCESS_INFLUENCE_KB_F)
        Me.PanelEx4.Controls.Add(Me.rbtnOTHER_PROCESS_INFLUENCE_KB_T)
        Me.PanelEx4.HitEnabled = False
        Me.PanelEx4.Location = New System.Drawing.Point(428, 31)
        Me.PanelEx4.Name = "PanelEx4"
        Me.PanelEx4.Size = New System.Drawing.Size(97, 27)
        Me.PanelEx4.TabIndex = 0
        '
        'rbtnOTHER_PROCESS_INFLUENCE_KB_F
        '
        Me.rbtnOTHER_PROCESS_INFLUENCE_KB_F.AutoSize = True
        Me.rbtnOTHER_PROCESS_INFLUENCE_KB_F.Dock = System.Windows.Forms.DockStyle.Right
        Me.rbtnOTHER_PROCESS_INFLUENCE_KB_F.Location = New System.Drawing.Point(43, 0)
        Me.rbtnOTHER_PROCESS_INFLUENCE_KB_F.Name = "rbtnOTHER_PROCESS_INFLUENCE_KB_F"
        Me.rbtnOTHER_PROCESS_INFLUENCE_KB_F.Padding = New System.Windows.Forms.Padding(3)
        Me.rbtnOTHER_PROCESS_INFLUENCE_KB_F.Size = New System.Drawing.Size(52, 25)
        Me.rbtnOTHER_PROCESS_INFLUENCE_KB_F.TabIndex = 1
        Me.rbtnOTHER_PROCESS_INFLUENCE_KB_F.Text = "なし"
        Me.rbtnOTHER_PROCESS_INFLUENCE_KB_F.UseVisualStyleBackColor = True
        '
        'rbtnOTHER_PROCESS_INFLUENCE_KB_T
        '
        Me.rbtnOTHER_PROCESS_INFLUENCE_KB_T.AutoSize = True
        Me.rbtnOTHER_PROCESS_INFLUENCE_KB_T.Dock = System.Windows.Forms.DockStyle.Left
        Me.rbtnOTHER_PROCESS_INFLUENCE_KB_T.Location = New System.Drawing.Point(0, 0)
        Me.rbtnOTHER_PROCESS_INFLUENCE_KB_T.Name = "rbtnOTHER_PROCESS_INFLUENCE_KB_T"
        Me.rbtnOTHER_PROCESS_INFLUENCE_KB_T.Padding = New System.Windows.Forms.Padding(3)
        Me.rbtnOTHER_PROCESS_INFLUENCE_KB_T.Size = New System.Drawing.Size(51, 25)
        Me.rbtnOTHER_PROCESS_INFLUENCE_KB_T.TabIndex = 0
        Me.rbtnOTHER_PROCESS_INFLUENCE_KB_T.Text = "あり"
        Me.rbtnOTHER_PROCESS_INFLUENCE_KB_T.UseVisualStyleBackColor = True
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Font = New System.Drawing.Font("Meiryo UI", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label11.ForeColor = System.Drawing.Color.Black
        Me.Label11.Location = New System.Drawing.Point(15, 36)
        Me.Label11.Margin = New System.Windows.Forms.Padding(3, 3, 3, 0)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(402, 17)
        Me.Label11.TabIndex = 327
        Me.Label11.Text = "(1) 当社内の他の同様プロセスで不適合製品が存在又は発生する可能性"
        Me.Label11.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.BackColor = System.Drawing.Color.Wheat
        Me.Label13.Font = New System.Drawing.Font("Meiryo UI", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label13.Location = New System.Drawing.Point(3, 3)
        Me.Label13.Margin = New System.Windows.Forms.Padding(3, 3, 3, 0)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(217, 24)
        Me.Label13.TabIndex = 237
        Me.Label13.Text = "４．他のプロセスへの影響"
        Me.Label13.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label15
        '
        Me.Label15.BackColor = System.Drawing.Color.Black
        Me.Label15.Dock = System.Windows.Forms.DockStyle.Right
        Me.Label15.Location = New System.Drawing.Point(1199, 0)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(13, 154)
        Me.Label15.TabIndex = 243
        Me.Label15.Visible = False
        '
        'pnlSYOCHI_JISSI
        '
        Me.pnlSYOCHI_JISSI.BackColor = System.Drawing.SystemColors.Control
        Me.pnlSYOCHI_JISSI.Controls.Add(Me.pnlSYOCHI_FILEPATH)
        Me.pnlSYOCHI_JISSI.Controls.Add(Me.txtSYOCHI_MEMO)
        Me.pnlSYOCHI_JISSI.Controls.Add(Me.Label42)
        Me.pnlSYOCHI_JISSI.Controls.Add(Me.Label41)
        Me.pnlSYOCHI_JISSI.Controls.Add(Me.lblOTHER_PROCESS_NAIYOU)
        Me.pnlSYOCHI_JISSI.Controls.Add(Me.txtOTHER_PROCESS_NAIYOU)
        Me.pnlSYOCHI_JISSI.Controls.Add(Me.dtOTHER_PROCESS_YMD)
        Me.pnlSYOCHI_JISSI.Controls.Add(Me.Label39)
        Me.pnlSYOCHI_JISSI.Controls.Add(Me.txtZAIKO_SIKAKE_NAIYOU)
        Me.pnlSYOCHI_JISSI.Controls.Add(Me.dtZAIKO_SIKAKE_YMD)
        Me.pnlSYOCHI_JISSI.Controls.Add(Me.Label38)
        Me.pnlSYOCHI_JISSI.Controls.Add(Me.txtKOKYAKU_NOUNYU_NAIYOU)
        Me.pnlSYOCHI_JISSI.Controls.Add(Me.dtKOKYAKU_NOUNYU_YMD)
        Me.pnlSYOCHI_JISSI.Controls.Add(Me.lblSTAGE16)
        Me.pnlSYOCHI_JISSI.Controls.Add(Me.lblSTAGEFlame13)
        Me.pnlSYOCHI_JISSI.HitEnabled = False
        Me.pnlSYOCHI_JISSI.Location = New System.Drawing.Point(3, 860)
        Me.pnlSYOCHI_JISSI.Margin = New System.Windows.Forms.Padding(2)
        Me.pnlSYOCHI_JISSI.MinimumSize = New System.Drawing.Size(1212, 0)
        Me.pnlSYOCHI_JISSI.Name = "pnlSYOCHI_JISSI"
        Me.pnlSYOCHI_JISSI.Size = New System.Drawing.Size(1212, 145)
        Me.pnlSYOCHI_JISSI.TabIndex = 5
        '
        'pnlSYOCHI_FILEPATH
        '
        Me.pnlSYOCHI_FILEPATH.Controls.Add(Me.Label44)
        Me.pnlSYOCHI_FILEPATH.Controls.Add(Me.btnOpenSYOCHI_FILEPATH)
        Me.pnlSYOCHI_FILEPATH.Controls.Add(Me.fpnlSYOCHI_FILEPATH)
        Me.pnlSYOCHI_FILEPATH.HitEnabled = False
        Me.pnlSYOCHI_FILEPATH.Location = New System.Drawing.Point(703, 84)
        Me.pnlSYOCHI_FILEPATH.Name = "pnlSYOCHI_FILEPATH"
        Me.pnlSYOCHI_FILEPATH.Padding = New System.Windows.Forms.Padding(1)
        Me.pnlSYOCHI_FILEPATH.Size = New System.Drawing.Size(486, 30)
        Me.pnlSYOCHI_FILEPATH.TabIndex = 353
        '
        'Label44
        '
        Me.Label44.AutoSize = True
        Me.Label44.Font = New System.Drawing.Font("Meiryo UI", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label44.Location = New System.Drawing.Point(2, 10)
        Me.Label44.Margin = New System.Windows.Forms.Padding(3, 3, 3, 0)
        Me.Label44.Name = "Label44"
        Me.Label44.Size = New System.Drawing.Size(60, 15)
        Me.Label44.TabIndex = 335
        Me.Label44.Text = "詳細資料:"
        Me.Label44.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'btnOpenSYOCHI_FILEPATH
        '
        Me.btnOpenSYOCHI_FILEPATH.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnOpenSYOCHI_FILEPATH.Image = Global.FMS.My.Resources.Resources._imgFolder_Open_16x16
        Me.btnOpenSYOCHI_FILEPATH.Location = New System.Drawing.Point(431, 3)
        Me.btnOpenSYOCHI_FILEPATH.Name = "btnOpenSYOCHI_FILEPATH"
        Me.btnOpenSYOCHI_FILEPATH.Size = New System.Drawing.Size(54, 24)
        Me.btnOpenSYOCHI_FILEPATH.TabIndex = 333
        Me.btnOpenSYOCHI_FILEPATH.UseVisualStyleBackColor = True
        '
        'fpnlSYOCHI_FILEPATH
        '
        Me.fpnlSYOCHI_FILEPATH.BackColor = System.Drawing.SystemColors.Window
        Me.fpnlSYOCHI_FILEPATH.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.fpnlSYOCHI_FILEPATH.Controls.Add(Me.lblSYOCHI_FILEPATH)
        Me.fpnlSYOCHI_FILEPATH.Controls.Add(Me.lblSYOCHI_FILEPATH_Clear)
        Me.fpnlSYOCHI_FILEPATH.Controls.Add(Me.LinkLabel21)
        Me.fpnlSYOCHI_FILEPATH.Controls.Add(Me.LinkLabel22)
        Me.fpnlSYOCHI_FILEPATH.Controls.Add(Me.LinkLabel23)
        Me.fpnlSYOCHI_FILEPATH.Controls.Add(Me.LinkLabel24)
        Me.fpnlSYOCHI_FILEPATH.Controls.Add(Me.LinkLabel25)
        Me.fpnlSYOCHI_FILEPATH.Controls.Add(Me.LinkLabel26)
        Me.fpnlSYOCHI_FILEPATH.Controls.Add(Me.LinkLabel27)
        Me.fpnlSYOCHI_FILEPATH.Controls.Add(Me.LinkLabel28)
        Me.fpnlSYOCHI_FILEPATH.Location = New System.Drawing.Point(63, 5)
        Me.fpnlSYOCHI_FILEPATH.Name = "fpnlSYOCHI_FILEPATH"
        Me.fpnlSYOCHI_FILEPATH.Size = New System.Drawing.Size(364, 22)
        Me.fpnlSYOCHI_FILEPATH.TabIndex = 334
        '
        'lblSYOCHI_FILEPATH
        '
        Me.lblSYOCHI_FILEPATH.AutoSize = True
        Me.lblSYOCHI_FILEPATH.Location = New System.Drawing.Point(0, 0)
        Me.lblSYOCHI_FILEPATH.Margin = New System.Windows.Forms.Padding(0)
        Me.lblSYOCHI_FILEPATH.Name = "lblSYOCHI_FILEPATH"
        Me.lblSYOCHI_FILEPATH.Size = New System.Drawing.Size(37, 17)
        Me.lblSYOCHI_FILEPATH.TabIndex = 126
        Me.lblSYOCHI_FILEPATH.TabStop = True
        Me.lblSYOCHI_FILEPATH.Text = "link1"
        Me.lblSYOCHI_FILEPATH.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.lblSYOCHI_FILEPATH.Visible = False
        '
        'lblSYOCHI_FILEPATH_Clear
        '
        Me.lblSYOCHI_FILEPATH_Clear.AutoSize = True
        Me.lblSYOCHI_FILEPATH_Clear.Cursor = System.Windows.Forms.Cursors.Hand
        Me.lblSYOCHI_FILEPATH_Clear.Dock = System.Windows.Forms.DockStyle.Right
        Me.fpnlSYOCHI_FILEPATH.SetFlowBreak(Me.lblSYOCHI_FILEPATH_Clear, True)
        Me.lblSYOCHI_FILEPATH_Clear.Font = New System.Drawing.Font("Meiryo UI", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.lblSYOCHI_FILEPATH_Clear.LinkBehavior = System.Windows.Forms.LinkBehavior.NeverUnderline
        Me.lblSYOCHI_FILEPATH_Clear.LinkColor = System.Drawing.Color.Red
        Me.lblSYOCHI_FILEPATH_Clear.Location = New System.Drawing.Point(37, 0)
        Me.lblSYOCHI_FILEPATH_Clear.Margin = New System.Windows.Forms.Padding(0)
        Me.lblSYOCHI_FILEPATH_Clear.Name = "lblSYOCHI_FILEPATH_Clear"
        Me.lblSYOCHI_FILEPATH_Clear.Size = New System.Drawing.Size(19, 17)
        Me.lblSYOCHI_FILEPATH_Clear.TabIndex = 128
        Me.lblSYOCHI_FILEPATH_Clear.TabStop = True
        Me.lblSYOCHI_FILEPATH_Clear.Text = "×"
        Me.lblSYOCHI_FILEPATH_Clear.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.lblSYOCHI_FILEPATH_Clear.Visible = False
        '
        'LinkLabel21
        '
        Me.LinkLabel21.AutoSize = True
        Me.LinkLabel21.Location = New System.Drawing.Point(0, 17)
        Me.LinkLabel21.Margin = New System.Windows.Forms.Padding(0)
        Me.LinkLabel21.Name = "LinkLabel21"
        Me.LinkLabel21.Size = New System.Drawing.Size(37, 17)
        Me.LinkLabel21.TabIndex = 129
        Me.LinkLabel21.TabStop = True
        Me.LinkLabel21.Text = "link2"
        Me.LinkLabel21.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.LinkLabel21.Visible = False
        '
        'LinkLabel22
        '
        Me.LinkLabel22.AutoSize = True
        Me.LinkLabel22.Cursor = System.Windows.Forms.Cursors.Hand
        Me.fpnlSYOCHI_FILEPATH.SetFlowBreak(Me.LinkLabel22, True)
        Me.LinkLabel22.Font = New System.Drawing.Font("Meiryo UI", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.LinkLabel22.LinkBehavior = System.Windows.Forms.LinkBehavior.NeverUnderline
        Me.LinkLabel22.LinkColor = System.Drawing.Color.Red
        Me.LinkLabel22.Location = New System.Drawing.Point(37, 17)
        Me.LinkLabel22.Margin = New System.Windows.Forms.Padding(0)
        Me.LinkLabel22.Name = "LinkLabel22"
        Me.LinkLabel22.Size = New System.Drawing.Size(19, 17)
        Me.LinkLabel22.TabIndex = 130
        Me.LinkLabel22.TabStop = True
        Me.LinkLabel22.Text = "×"
        Me.LinkLabel22.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.LinkLabel22.Visible = False
        '
        'LinkLabel23
        '
        Me.LinkLabel23.AutoSize = True
        Me.LinkLabel23.Location = New System.Drawing.Point(0, 34)
        Me.LinkLabel23.Margin = New System.Windows.Forms.Padding(0)
        Me.LinkLabel23.Name = "LinkLabel23"
        Me.LinkLabel23.Size = New System.Drawing.Size(37, 17)
        Me.LinkLabel23.TabIndex = 129
        Me.LinkLabel23.TabStop = True
        Me.LinkLabel23.Text = "link3"
        Me.LinkLabel23.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.LinkLabel23.Visible = False
        '
        'LinkLabel24
        '
        Me.LinkLabel24.AutoSize = True
        Me.LinkLabel24.Cursor = System.Windows.Forms.Cursors.Hand
        Me.fpnlSYOCHI_FILEPATH.SetFlowBreak(Me.LinkLabel24, True)
        Me.LinkLabel24.Font = New System.Drawing.Font("Meiryo UI", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.LinkLabel24.LinkBehavior = System.Windows.Forms.LinkBehavior.NeverUnderline
        Me.LinkLabel24.LinkColor = System.Drawing.Color.Red
        Me.LinkLabel24.Location = New System.Drawing.Point(37, 34)
        Me.LinkLabel24.Margin = New System.Windows.Forms.Padding(0)
        Me.LinkLabel24.Name = "LinkLabel24"
        Me.LinkLabel24.Size = New System.Drawing.Size(19, 17)
        Me.LinkLabel24.TabIndex = 130
        Me.LinkLabel24.TabStop = True
        Me.LinkLabel24.Text = "×"
        Me.LinkLabel24.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.LinkLabel24.Visible = False
        '
        'LinkLabel25
        '
        Me.LinkLabel25.AutoSize = True
        Me.LinkLabel25.Location = New System.Drawing.Point(0, 51)
        Me.LinkLabel25.Margin = New System.Windows.Forms.Padding(0)
        Me.LinkLabel25.Name = "LinkLabel25"
        Me.LinkLabel25.Size = New System.Drawing.Size(37, 17)
        Me.LinkLabel25.TabIndex = 129
        Me.LinkLabel25.TabStop = True
        Me.LinkLabel25.Text = "link4"
        Me.LinkLabel25.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.LinkLabel25.Visible = False
        '
        'LinkLabel26
        '
        Me.LinkLabel26.AutoSize = True
        Me.LinkLabel26.Cursor = System.Windows.Forms.Cursors.Hand
        Me.fpnlSYOCHI_FILEPATH.SetFlowBreak(Me.LinkLabel26, True)
        Me.LinkLabel26.Font = New System.Drawing.Font("Meiryo UI", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.LinkLabel26.LinkBehavior = System.Windows.Forms.LinkBehavior.NeverUnderline
        Me.LinkLabel26.LinkColor = System.Drawing.Color.Red
        Me.LinkLabel26.Location = New System.Drawing.Point(37, 51)
        Me.LinkLabel26.Margin = New System.Windows.Forms.Padding(0)
        Me.LinkLabel26.Name = "LinkLabel26"
        Me.LinkLabel26.Size = New System.Drawing.Size(19, 17)
        Me.LinkLabel26.TabIndex = 130
        Me.LinkLabel26.TabStop = True
        Me.LinkLabel26.Text = "×"
        Me.LinkLabel26.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.LinkLabel26.Visible = False
        '
        'LinkLabel27
        '
        Me.LinkLabel27.AutoSize = True
        Me.LinkLabel27.Location = New System.Drawing.Point(0, 68)
        Me.LinkLabel27.Margin = New System.Windows.Forms.Padding(0)
        Me.LinkLabel27.Name = "LinkLabel27"
        Me.LinkLabel27.Size = New System.Drawing.Size(37, 17)
        Me.LinkLabel27.TabIndex = 129
        Me.LinkLabel27.TabStop = True
        Me.LinkLabel27.Text = "link5"
        Me.LinkLabel27.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.LinkLabel27.Visible = False
        '
        'LinkLabel28
        '
        Me.LinkLabel28.AutoSize = True
        Me.LinkLabel28.Cursor = System.Windows.Forms.Cursors.Hand
        Me.fpnlSYOCHI_FILEPATH.SetFlowBreak(Me.LinkLabel28, True)
        Me.LinkLabel28.Font = New System.Drawing.Font("Meiryo UI", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.LinkLabel28.LinkBehavior = System.Windows.Forms.LinkBehavior.NeverUnderline
        Me.LinkLabel28.LinkColor = System.Drawing.Color.Red
        Me.LinkLabel28.Location = New System.Drawing.Point(37, 68)
        Me.LinkLabel28.Margin = New System.Windows.Forms.Padding(0)
        Me.LinkLabel28.Name = "LinkLabel28"
        Me.LinkLabel28.Size = New System.Drawing.Size(19, 17)
        Me.LinkLabel28.TabIndex = 130
        Me.LinkLabel28.TabStop = True
        Me.LinkLabel28.Text = "×"
        Me.LinkLabel28.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.LinkLabel28.Visible = False
        '
        'txtSYOCHI_MEMO
        '
        Me.txtSYOCHI_MEMO.BackColor = System.Drawing.SystemColors.Window
        Me.txtSYOCHI_MEMO.ImeMode = System.Windows.Forms.ImeMode.[On]
        Me.txtSYOCHI_MEMO.InputRequired = False
        Me.txtSYOCHI_MEMO.Location = New System.Drawing.Point(246, 4)
        Me.txtSYOCHI_MEMO.MaxByteLength = 100
        Me.txtSYOCHI_MEMO.MaxLength = 50
        Me.txtSYOCHI_MEMO.Multiline = True
        Me.txtSYOCHI_MEMO.Name = "txtSYOCHI_MEMO"
        Me.txtSYOCHI_MEMO.SelectAllText = False
        Me.txtSYOCHI_MEMO.Size = New System.Drawing.Size(432, 23)
        Me.txtSYOCHI_MEMO.TabIndex = 352
        Me.txtSYOCHI_MEMO.WatermarkColor = System.Drawing.Color.Empty
        Me.txtSYOCHI_MEMO.WatermarkText = Nothing
        '
        'Label42
        '
        Me.Label42.AutoSize = True
        Me.Label42.Font = New System.Drawing.Font("Meiryo UI", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label42.Location = New System.Drawing.Point(582, 39)
        Me.Label42.Name = "Label42"
        Me.Label42.Size = New System.Drawing.Size(43, 15)
        Me.Label42.TabIndex = 346
        Me.Label42.Text = "実施日"
        Me.Label42.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label41
        '
        Me.Label41.AutoSize = True
        Me.Label41.Font = New System.Drawing.Font("Meiryo UI", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label41.Location = New System.Drawing.Point(143, 38)
        Me.Label41.Name = "Label41"
        Me.Label41.Size = New System.Drawing.Size(55, 15)
        Me.Label41.TabIndex = 346
        Me.Label41.Text = "実施内容"
        Me.Label41.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'lblOTHER_PROCESS_NAIYOU
        '
        Me.lblOTHER_PROCESS_NAIYOU.AutoSize = True
        Me.lblOTHER_PROCESS_NAIYOU.Font = New System.Drawing.Font("Meiryo UI", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.lblOTHER_PROCESS_NAIYOU.ForeColor = System.Drawing.Color.Black
        Me.lblOTHER_PROCESS_NAIYOU.Location = New System.Drawing.Point(15, 118)
        Me.lblOTHER_PROCESS_NAIYOU.Margin = New System.Windows.Forms.Padding(3, 3, 3, 0)
        Me.lblOTHER_PROCESS_NAIYOU.Name = "lblOTHER_PROCESS_NAIYOU"
        Me.lblOTHER_PROCESS_NAIYOU.Size = New System.Drawing.Size(100, 17)
        Me.lblOTHER_PROCESS_NAIYOU.TabIndex = 339
        Me.lblOTHER_PROCESS_NAIYOU.Text = "(3) 他のプロセス"
        Me.lblOTHER_PROCESS_NAIYOU.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'txtOTHER_PROCESS_NAIYOU
        '
        Me.txtOTHER_PROCESS_NAIYOU.BackColor = System.Drawing.SystemColors.Window
        Me.txtOTHER_PROCESS_NAIYOU.ImeMode = System.Windows.Forms.ImeMode.[On]
        Me.txtOTHER_PROCESS_NAIYOU.InputRequired = False
        Me.txtOTHER_PROCESS_NAIYOU.Location = New System.Drawing.Point(143, 115)
        Me.txtOTHER_PROCESS_NAIYOU.MaxByteLength = 100
        Me.txtOTHER_PROCESS_NAIYOU.MaxLength = 50
        Me.txtOTHER_PROCESS_NAIYOU.Multiline = True
        Me.txtOTHER_PROCESS_NAIYOU.Name = "txtOTHER_PROCESS_NAIYOU"
        Me.txtOTHER_PROCESS_NAIYOU.SelectAllText = False
        Me.txtOTHER_PROCESS_NAIYOU.ShowRemainingChars = True
        Me.txtOTHER_PROCESS_NAIYOU.Size = New System.Drawing.Size(432, 23)
        Me.txtOTHER_PROCESS_NAIYOU.TabIndex = 4
        Me.txtOTHER_PROCESS_NAIYOU.WatermarkColor = System.Drawing.Color.Empty
        Me.txtOTHER_PROCESS_NAIYOU.WatermarkText = Nothing
        '
        'dtOTHER_PROCESS_YMD
        '
        Me.dtOTHER_PROCESS_YMD.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.dtOTHER_PROCESS_YMD.GotFocusedColor = System.Drawing.Color.FromArgb(CType(CType(190, Byte), Integer), CType(CType(180, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.dtOTHER_PROCESS_YMD.Location = New System.Drawing.Point(582, 115)
        Me.dtOTHER_PROCESS_YMD.MaxDate = New Date(9998, 12, 31, 0, 0, 0, 0)
        Me.dtOTHER_PROCESS_YMD.MinDate = New Date(1753, 1, 1, 0, 0, 0, 0)
        Me.dtOTHER_PROCESS_YMD.MinimumSize = New System.Drawing.Size(98, 24)
        Me.dtOTHER_PROCESS_YMD.Name = "dtOTHER_PROCESS_YMD"
        Me.dtOTHER_PROCESS_YMD.ReadOnly = False
        Me.dtOTHER_PROCESS_YMD.Size = New System.Drawing.Size(98, 24)
        Me.dtOTHER_PROCESS_YMD.TabIndex = 5
        Me.dtOTHER_PROCESS_YMD.Value = ""
        Me.dtOTHER_PROCESS_YMD.ValueNonFormat = ""
        '
        'Label39
        '
        Me.Label39.AutoSize = True
        Me.Label39.Font = New System.Drawing.Font("Meiryo UI", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label39.ForeColor = System.Drawing.Color.Black
        Me.Label39.Location = New System.Drawing.Point(15, 89)
        Me.Label39.Margin = New System.Windows.Forms.Padding(3, 3, 3, 0)
        Me.Label39.Name = "Label39"
        Me.Label39.Size = New System.Drawing.Size(118, 17)
        Me.Label39.TabIndex = 336
        Me.Label39.Text = "(2) 在庫品・仕掛品"
        Me.Label39.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'txtZAIKO_SIKAKE_NAIYOU
        '
        Me.txtZAIKO_SIKAKE_NAIYOU.BackColor = System.Drawing.SystemColors.Window
        Me.txtZAIKO_SIKAKE_NAIYOU.ImeMode = System.Windows.Forms.ImeMode.[On]
        Me.txtZAIKO_SIKAKE_NAIYOU.InputRequired = False
        Me.txtZAIKO_SIKAKE_NAIYOU.Location = New System.Drawing.Point(143, 86)
        Me.txtZAIKO_SIKAKE_NAIYOU.MaxByteLength = 100
        Me.txtZAIKO_SIKAKE_NAIYOU.MaxLength = 50
        Me.txtZAIKO_SIKAKE_NAIYOU.Multiline = True
        Me.txtZAIKO_SIKAKE_NAIYOU.Name = "txtZAIKO_SIKAKE_NAIYOU"
        Me.txtZAIKO_SIKAKE_NAIYOU.SelectAllText = False
        Me.txtZAIKO_SIKAKE_NAIYOU.ShowRemainingChars = True
        Me.txtZAIKO_SIKAKE_NAIYOU.Size = New System.Drawing.Size(432, 23)
        Me.txtZAIKO_SIKAKE_NAIYOU.TabIndex = 2
        Me.txtZAIKO_SIKAKE_NAIYOU.WatermarkColor = System.Drawing.Color.Empty
        Me.txtZAIKO_SIKAKE_NAIYOU.WatermarkText = Nothing
        '
        'dtZAIKO_SIKAKE_YMD
        '
        Me.dtZAIKO_SIKAKE_YMD.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.dtZAIKO_SIKAKE_YMD.GotFocusedColor = System.Drawing.Color.FromArgb(CType(CType(190, Byte), Integer), CType(CType(180, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.dtZAIKO_SIKAKE_YMD.Location = New System.Drawing.Point(582, 86)
        Me.dtZAIKO_SIKAKE_YMD.MaxDate = New Date(9998, 12, 31, 0, 0, 0, 0)
        Me.dtZAIKO_SIKAKE_YMD.MinDate = New Date(1753, 1, 1, 0, 0, 0, 0)
        Me.dtZAIKO_SIKAKE_YMD.MinimumSize = New System.Drawing.Size(98, 24)
        Me.dtZAIKO_SIKAKE_YMD.Name = "dtZAIKO_SIKAKE_YMD"
        Me.dtZAIKO_SIKAKE_YMD.ReadOnly = False
        Me.dtZAIKO_SIKAKE_YMD.Size = New System.Drawing.Size(98, 24)
        Me.dtZAIKO_SIKAKE_YMD.TabIndex = 3
        Me.dtZAIKO_SIKAKE_YMD.Value = ""
        Me.dtZAIKO_SIKAKE_YMD.ValueNonFormat = ""
        '
        'Label38
        '
        Me.Label38.AutoSize = True
        Me.Label38.Font = New System.Drawing.Font("Meiryo UI", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label38.ForeColor = System.Drawing.Color.Black
        Me.Label38.Location = New System.Drawing.Point(15, 60)
        Me.Label38.Margin = New System.Windows.Forms.Padding(3, 3, 3, 0)
        Me.Label38.Name = "Label38"
        Me.Label38.Size = New System.Drawing.Size(122, 17)
        Me.Label38.TabIndex = 333
        Me.Label38.Text = "(1) 顧客納入済み品"
        Me.Label38.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'txtKOKYAKU_NOUNYU_NAIYOU
        '
        Me.txtKOKYAKU_NOUNYU_NAIYOU.BackColor = System.Drawing.SystemColors.Window
        Me.txtKOKYAKU_NOUNYU_NAIYOU.ImeMode = System.Windows.Forms.ImeMode.[On]
        Me.txtKOKYAKU_NOUNYU_NAIYOU.InputRequired = False
        Me.txtKOKYAKU_NOUNYU_NAIYOU.Location = New System.Drawing.Point(143, 57)
        Me.txtKOKYAKU_NOUNYU_NAIYOU.MaxByteLength = 100
        Me.txtKOKYAKU_NOUNYU_NAIYOU.MaxLength = 50
        Me.txtKOKYAKU_NOUNYU_NAIYOU.Multiline = True
        Me.txtKOKYAKU_NOUNYU_NAIYOU.Name = "txtKOKYAKU_NOUNYU_NAIYOU"
        Me.txtKOKYAKU_NOUNYU_NAIYOU.SelectAllText = False
        Me.txtKOKYAKU_NOUNYU_NAIYOU.ShowRemainingChars = True
        Me.txtKOKYAKU_NOUNYU_NAIYOU.Size = New System.Drawing.Size(432, 23)
        Me.txtKOKYAKU_NOUNYU_NAIYOU.TabIndex = 0
        Me.txtKOKYAKU_NOUNYU_NAIYOU.WatermarkColor = System.Drawing.Color.Empty
        Me.txtKOKYAKU_NOUNYU_NAIYOU.WatermarkText = Nothing
        '
        'dtKOKYAKU_NOUNYU_YMD
        '
        Me.dtKOKYAKU_NOUNYU_YMD.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.dtKOKYAKU_NOUNYU_YMD.GotFocusedColor = System.Drawing.Color.FromArgb(CType(CType(190, Byte), Integer), CType(CType(180, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.dtKOKYAKU_NOUNYU_YMD.Location = New System.Drawing.Point(582, 57)
        Me.dtKOKYAKU_NOUNYU_YMD.MaxDate = New Date(9998, 12, 31, 0, 0, 0, 0)
        Me.dtKOKYAKU_NOUNYU_YMD.MinDate = New Date(1753, 1, 1, 0, 0, 0, 0)
        Me.dtKOKYAKU_NOUNYU_YMD.MinimumSize = New System.Drawing.Size(98, 24)
        Me.dtKOKYAKU_NOUNYU_YMD.Name = "dtKOKYAKU_NOUNYU_YMD"
        Me.dtKOKYAKU_NOUNYU_YMD.ReadOnly = False
        Me.dtKOKYAKU_NOUNYU_YMD.Size = New System.Drawing.Size(98, 24)
        Me.dtKOKYAKU_NOUNYU_YMD.TabIndex = 1
        Me.dtKOKYAKU_NOUNYU_YMD.Value = ""
        Me.dtKOKYAKU_NOUNYU_YMD.ValueNonFormat = ""
        '
        'lblSTAGE16
        '
        Me.lblSTAGE16.AutoSize = True
        Me.lblSTAGE16.BackColor = System.Drawing.Color.Wheat
        Me.lblSTAGE16.Font = New System.Drawing.Font("Meiryo UI", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.lblSTAGE16.Location = New System.Drawing.Point(3, 3)
        Me.lblSTAGE16.Margin = New System.Windows.Forms.Padding(3, 3, 3, 0)
        Me.lblSTAGE16.Name = "lblSTAGE16"
        Me.lblSTAGE16.Size = New System.Drawing.Size(141, 24)
        Me.lblSTAGE16.TabIndex = 237
        Me.lblSTAGE16.Text = "５．処置の実施"
        Me.lblSTAGE16.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'lblSTAGEFlame13
        '
        Me.lblSTAGEFlame13.BackColor = System.Drawing.Color.Black
        Me.lblSTAGEFlame13.Dock = System.Windows.Forms.DockStyle.Right
        Me.lblSTAGEFlame13.Location = New System.Drawing.Point(1199, 0)
        Me.lblSTAGEFlame13.Name = "lblSTAGEFlame13"
        Me.lblSTAGEFlame13.Size = New System.Drawing.Size(13, 145)
        Me.lblSTAGEFlame13.TabIndex = 243
        Me.lblSTAGEFlame13.Visible = False
        '
        'pnlFCR
        '
        Me.pnlFCR.Controls.Add(Me.pnlKOKYAKU_EIKYO_HANTEI_FILEPATH)
        Me.pnlFCR.Controls.Add(Me.lblTAISYO_KOKYAKU)
        Me.pnlFCR.Controls.Add(Me.txtTAISYO_KOKYAKU)
        Me.pnlFCR.Controls.Add(Me.lblKOKYAKU_EIKYO_ETC_COMMENT)
        Me.pnlFCR.Controls.Add(Me.lblTUCHI_SYUDAN)
        Me.pnlFCR.Controls.Add(Me.lblHITUYO_TETUDUKI_ZIKO)
        Me.pnlFCR.Controls.Add(Me.lblTUCHI_YMD)
        Me.pnlFCR.Controls.Add(Me.pnlrbtnTUCHI)
        Me.pnlFCR.Controls.Add(Me.Label2)
        Me.pnlFCR.Controls.Add(Me.cmbKOKYAKU_EIKYO_HANTEI_COMMENT)
        Me.pnlFCR.Controls.Add(Me.PanelEx1)
        Me.pnlFCR.Controls.Add(Me.lblSETUMON_1)
        Me.pnlFCR.Controls.Add(Me.txtKOKYAKU_EIKYO_NAIYO)
        Me.pnlFCR.Controls.Add(Me.lblKOKYAKU_EIKYO_NAIYO)
        Me.pnlFCR.Controls.Add(Me.txtKOKYAKU_EIKYO_ETC_COMMENT)
        Me.pnlFCR.Controls.Add(Me.txtKAKUNIN_SYUDAN)
        Me.pnlFCR.Controls.Add(Me.lblKOKYAKU_EIKYO_TUCHI_HANTEI_KB)
        Me.pnlFCR.Controls.Add(Me.lblKOKYAKU_EIKYO_HANTEI_COMMENT)
        Me.pnlFCR.Controls.Add(Me.lblKAKUNIN_SYUDAN)
        Me.pnlFCR.Controls.Add(Me.txtHITUYO_TETUDUKI_ZIKO)
        Me.pnlFCR.Controls.Add(Me.txtTUCHI_SYUDAN)
        Me.pnlFCR.Controls.Add(Me.dtTUCHI_YMD)
        Me.pnlFCR.Controls.Add(Me.lblCARFlame)
        Me.pnlFCR.Dock = System.Windows.Forms.DockStyle.Top
        Me.pnlFCR.HitEnabled = False
        Me.pnlFCR.Location = New System.Drawing.Point(3, 3)
        Me.pnlFCR.MinimumSize = New System.Drawing.Size(1212, 0)
        Me.pnlFCR.Name = "pnlFCR"
        Me.pnlFCR.Size = New System.Drawing.Size(1212, 330)
        Me.pnlFCR.TabIndex = 1
        '
        'pnlKOKYAKU_EIKYO_HANTEI_FILEPATH
        '
        Me.pnlKOKYAKU_EIKYO_HANTEI_FILEPATH.Controls.Add(Me.Label37)
        Me.pnlKOKYAKU_EIKYO_HANTEI_FILEPATH.Controls.Add(Me.btnOpenKOKYAKU_EIKYO_HANTEI_FILEPATH)
        Me.pnlKOKYAKU_EIKYO_HANTEI_FILEPATH.Controls.Add(Me.fpnlKOKYAKU_EIKYO_HANTEI_FILEPATH)
        Me.pnlKOKYAKU_EIKYO_HANTEI_FILEPATH.HitEnabled = False
        Me.pnlKOKYAKU_EIKYO_HANTEI_FILEPATH.Location = New System.Drawing.Point(623, 292)
        Me.pnlKOKYAKU_EIKYO_HANTEI_FILEPATH.Name = "pnlKOKYAKU_EIKYO_HANTEI_FILEPATH"
        Me.pnlKOKYAKU_EIKYO_HANTEI_FILEPATH.Padding = New System.Windows.Forms.Padding(1)
        Me.pnlKOKYAKU_EIKYO_HANTEI_FILEPATH.Size = New System.Drawing.Size(570, 30)
        Me.pnlKOKYAKU_EIKYO_HANTEI_FILEPATH.TabIndex = 344
        '
        'Label37
        '
        Me.Label37.AutoSize = True
        Me.Label37.Font = New System.Drawing.Font("Meiryo UI", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label37.Location = New System.Drawing.Point(2, 9)
        Me.Label37.Margin = New System.Windows.Forms.Padding(3, 3, 3, 0)
        Me.Label37.Name = "Label37"
        Me.Label37.Size = New System.Drawing.Size(60, 15)
        Me.Label37.TabIndex = 335
        Me.Label37.Text = "詳細資料:"
        Me.Label37.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'btnOpenKOKYAKU_EIKYO_HANTEI_FILEPATH
        '
        Me.btnOpenKOKYAKU_EIKYO_HANTEI_FILEPATH.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnOpenKOKYAKU_EIKYO_HANTEI_FILEPATH.Image = Global.FMS.My.Resources.Resources._imgFolder_Open_16x16
        Me.btnOpenKOKYAKU_EIKYO_HANTEI_FILEPATH.Location = New System.Drawing.Point(512, 3)
        Me.btnOpenKOKYAKU_EIKYO_HANTEI_FILEPATH.Name = "btnOpenKOKYAKU_EIKYO_HANTEI_FILEPATH"
        Me.btnOpenKOKYAKU_EIKYO_HANTEI_FILEPATH.Size = New System.Drawing.Size(54, 24)
        Me.btnOpenKOKYAKU_EIKYO_HANTEI_FILEPATH.TabIndex = 333
        Me.btnOpenKOKYAKU_EIKYO_HANTEI_FILEPATH.UseVisualStyleBackColor = True
        '
        'fpnlKOKYAKU_EIKYO_HANTEI_FILEPATH
        '
        Me.fpnlKOKYAKU_EIKYO_HANTEI_FILEPATH.BackColor = System.Drawing.SystemColors.Window
        Me.fpnlKOKYAKU_EIKYO_HANTEI_FILEPATH.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.fpnlKOKYAKU_EIKYO_HANTEI_FILEPATH.Controls.Add(Me.lblKOKYAKU_EIKYO_HANTEI_FILEPATH)
        Me.fpnlKOKYAKU_EIKYO_HANTEI_FILEPATH.Controls.Add(Me.lblKOKYAKU_EIKYO_HANTEI_FILEPATH_Clear)
        Me.fpnlKOKYAKU_EIKYO_HANTEI_FILEPATH.Controls.Add(Me.LinkLabel3)
        Me.fpnlKOKYAKU_EIKYO_HANTEI_FILEPATH.Controls.Add(Me.LinkLabel4)
        Me.fpnlKOKYAKU_EIKYO_HANTEI_FILEPATH.Controls.Add(Me.LinkLabel5)
        Me.fpnlKOKYAKU_EIKYO_HANTEI_FILEPATH.Controls.Add(Me.LinkLabel6)
        Me.fpnlKOKYAKU_EIKYO_HANTEI_FILEPATH.Controls.Add(Me.LinkLabel7)
        Me.fpnlKOKYAKU_EIKYO_HANTEI_FILEPATH.Controls.Add(Me.LinkLabel8)
        Me.fpnlKOKYAKU_EIKYO_HANTEI_FILEPATH.Controls.Add(Me.LinkLabel29)
        Me.fpnlKOKYAKU_EIKYO_HANTEI_FILEPATH.Controls.Add(Me.LinkLabel30)
        Me.fpnlKOKYAKU_EIKYO_HANTEI_FILEPATH.Location = New System.Drawing.Point(63, 4)
        Me.fpnlKOKYAKU_EIKYO_HANTEI_FILEPATH.Name = "fpnlKOKYAKU_EIKYO_HANTEI_FILEPATH"
        Me.fpnlKOKYAKU_EIKYO_HANTEI_FILEPATH.Size = New System.Drawing.Size(444, 22)
        Me.fpnlKOKYAKU_EIKYO_HANTEI_FILEPATH.TabIndex = 334
        '
        'lblKOKYAKU_EIKYO_HANTEI_FILEPATH
        '
        Me.lblKOKYAKU_EIKYO_HANTEI_FILEPATH.AutoSize = True
        Me.lblKOKYAKU_EIKYO_HANTEI_FILEPATH.Location = New System.Drawing.Point(0, 0)
        Me.lblKOKYAKU_EIKYO_HANTEI_FILEPATH.Margin = New System.Windows.Forms.Padding(0)
        Me.lblKOKYAKU_EIKYO_HANTEI_FILEPATH.Name = "lblKOKYAKU_EIKYO_HANTEI_FILEPATH"
        Me.lblKOKYAKU_EIKYO_HANTEI_FILEPATH.Size = New System.Drawing.Size(37, 17)
        Me.lblKOKYAKU_EIKYO_HANTEI_FILEPATH.TabIndex = 126
        Me.lblKOKYAKU_EIKYO_HANTEI_FILEPATH.TabStop = True
        Me.lblKOKYAKU_EIKYO_HANTEI_FILEPATH.Text = "link1"
        Me.lblKOKYAKU_EIKYO_HANTEI_FILEPATH.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.lblKOKYAKU_EIKYO_HANTEI_FILEPATH.Visible = False
        '
        'lblKOKYAKU_EIKYO_HANTEI_FILEPATH_Clear
        '
        Me.lblKOKYAKU_EIKYO_HANTEI_FILEPATH_Clear.AutoSize = True
        Me.lblKOKYAKU_EIKYO_HANTEI_FILEPATH_Clear.Cursor = System.Windows.Forms.Cursors.Hand
        Me.lblKOKYAKU_EIKYO_HANTEI_FILEPATH_Clear.Dock = System.Windows.Forms.DockStyle.Right
        Me.fpnlKOKYAKU_EIKYO_HANTEI_FILEPATH.SetFlowBreak(Me.lblKOKYAKU_EIKYO_HANTEI_FILEPATH_Clear, True)
        Me.lblKOKYAKU_EIKYO_HANTEI_FILEPATH_Clear.Font = New System.Drawing.Font("Meiryo UI", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.lblKOKYAKU_EIKYO_HANTEI_FILEPATH_Clear.LinkBehavior = System.Windows.Forms.LinkBehavior.NeverUnderline
        Me.lblKOKYAKU_EIKYO_HANTEI_FILEPATH_Clear.LinkColor = System.Drawing.Color.Red
        Me.lblKOKYAKU_EIKYO_HANTEI_FILEPATH_Clear.Location = New System.Drawing.Point(37, 0)
        Me.lblKOKYAKU_EIKYO_HANTEI_FILEPATH_Clear.Margin = New System.Windows.Forms.Padding(0)
        Me.lblKOKYAKU_EIKYO_HANTEI_FILEPATH_Clear.Name = "lblKOKYAKU_EIKYO_HANTEI_FILEPATH_Clear"
        Me.lblKOKYAKU_EIKYO_HANTEI_FILEPATH_Clear.Size = New System.Drawing.Size(19, 17)
        Me.lblKOKYAKU_EIKYO_HANTEI_FILEPATH_Clear.TabIndex = 128
        Me.lblKOKYAKU_EIKYO_HANTEI_FILEPATH_Clear.TabStop = True
        Me.lblKOKYAKU_EIKYO_HANTEI_FILEPATH_Clear.Text = "×"
        Me.lblKOKYAKU_EIKYO_HANTEI_FILEPATH_Clear.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.lblKOKYAKU_EIKYO_HANTEI_FILEPATH_Clear.Visible = False
        '
        'LinkLabel3
        '
        Me.LinkLabel3.AutoSize = True
        Me.LinkLabel3.Location = New System.Drawing.Point(0, 17)
        Me.LinkLabel3.Margin = New System.Windows.Forms.Padding(0)
        Me.LinkLabel3.Name = "LinkLabel3"
        Me.LinkLabel3.Size = New System.Drawing.Size(37, 17)
        Me.LinkLabel3.TabIndex = 129
        Me.LinkLabel3.TabStop = True
        Me.LinkLabel3.Text = "link2"
        Me.LinkLabel3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.LinkLabel3.Visible = False
        '
        'LinkLabel4
        '
        Me.LinkLabel4.AutoSize = True
        Me.LinkLabel4.Cursor = System.Windows.Forms.Cursors.Hand
        Me.fpnlKOKYAKU_EIKYO_HANTEI_FILEPATH.SetFlowBreak(Me.LinkLabel4, True)
        Me.LinkLabel4.Font = New System.Drawing.Font("Meiryo UI", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.LinkLabel4.LinkBehavior = System.Windows.Forms.LinkBehavior.NeverUnderline
        Me.LinkLabel4.LinkColor = System.Drawing.Color.Red
        Me.LinkLabel4.Location = New System.Drawing.Point(37, 17)
        Me.LinkLabel4.Margin = New System.Windows.Forms.Padding(0)
        Me.LinkLabel4.Name = "LinkLabel4"
        Me.LinkLabel4.Size = New System.Drawing.Size(19, 17)
        Me.LinkLabel4.TabIndex = 130
        Me.LinkLabel4.TabStop = True
        Me.LinkLabel4.Text = "×"
        Me.LinkLabel4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.LinkLabel4.Visible = False
        '
        'LinkLabel5
        '
        Me.LinkLabel5.AutoSize = True
        Me.LinkLabel5.Location = New System.Drawing.Point(0, 34)
        Me.LinkLabel5.Margin = New System.Windows.Forms.Padding(0)
        Me.LinkLabel5.Name = "LinkLabel5"
        Me.LinkLabel5.Size = New System.Drawing.Size(37, 17)
        Me.LinkLabel5.TabIndex = 129
        Me.LinkLabel5.TabStop = True
        Me.LinkLabel5.Text = "link3"
        Me.LinkLabel5.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.LinkLabel5.Visible = False
        '
        'LinkLabel6
        '
        Me.LinkLabel6.AutoSize = True
        Me.LinkLabel6.Cursor = System.Windows.Forms.Cursors.Hand
        Me.fpnlKOKYAKU_EIKYO_HANTEI_FILEPATH.SetFlowBreak(Me.LinkLabel6, True)
        Me.LinkLabel6.Font = New System.Drawing.Font("Meiryo UI", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.LinkLabel6.LinkBehavior = System.Windows.Forms.LinkBehavior.NeverUnderline
        Me.LinkLabel6.LinkColor = System.Drawing.Color.Red
        Me.LinkLabel6.Location = New System.Drawing.Point(37, 34)
        Me.LinkLabel6.Margin = New System.Windows.Forms.Padding(0)
        Me.LinkLabel6.Name = "LinkLabel6"
        Me.LinkLabel6.Size = New System.Drawing.Size(19, 17)
        Me.LinkLabel6.TabIndex = 130
        Me.LinkLabel6.TabStop = True
        Me.LinkLabel6.Text = "×"
        Me.LinkLabel6.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.LinkLabel6.Visible = False
        '
        'LinkLabel7
        '
        Me.LinkLabel7.AutoSize = True
        Me.LinkLabel7.Location = New System.Drawing.Point(0, 51)
        Me.LinkLabel7.Margin = New System.Windows.Forms.Padding(0)
        Me.LinkLabel7.Name = "LinkLabel7"
        Me.LinkLabel7.Size = New System.Drawing.Size(37, 17)
        Me.LinkLabel7.TabIndex = 129
        Me.LinkLabel7.TabStop = True
        Me.LinkLabel7.Text = "link4"
        Me.LinkLabel7.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.LinkLabel7.Visible = False
        '
        'LinkLabel8
        '
        Me.LinkLabel8.AutoSize = True
        Me.LinkLabel8.Cursor = System.Windows.Forms.Cursors.Hand
        Me.fpnlKOKYAKU_EIKYO_HANTEI_FILEPATH.SetFlowBreak(Me.LinkLabel8, True)
        Me.LinkLabel8.Font = New System.Drawing.Font("Meiryo UI", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.LinkLabel8.LinkBehavior = System.Windows.Forms.LinkBehavior.NeverUnderline
        Me.LinkLabel8.LinkColor = System.Drawing.Color.Red
        Me.LinkLabel8.Location = New System.Drawing.Point(37, 51)
        Me.LinkLabel8.Margin = New System.Windows.Forms.Padding(0)
        Me.LinkLabel8.Name = "LinkLabel8"
        Me.LinkLabel8.Size = New System.Drawing.Size(19, 17)
        Me.LinkLabel8.TabIndex = 130
        Me.LinkLabel8.TabStop = True
        Me.LinkLabel8.Text = "×"
        Me.LinkLabel8.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.LinkLabel8.Visible = False
        '
        'LinkLabel29
        '
        Me.LinkLabel29.AutoSize = True
        Me.LinkLabel29.Location = New System.Drawing.Point(0, 68)
        Me.LinkLabel29.Margin = New System.Windows.Forms.Padding(0)
        Me.LinkLabel29.Name = "LinkLabel29"
        Me.LinkLabel29.Size = New System.Drawing.Size(37, 17)
        Me.LinkLabel29.TabIndex = 129
        Me.LinkLabel29.TabStop = True
        Me.LinkLabel29.Text = "link5"
        Me.LinkLabel29.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.LinkLabel29.Visible = False
        '
        'LinkLabel30
        '
        Me.LinkLabel30.AutoSize = True
        Me.LinkLabel30.Cursor = System.Windows.Forms.Cursors.Hand
        Me.fpnlKOKYAKU_EIKYO_HANTEI_FILEPATH.SetFlowBreak(Me.LinkLabel30, True)
        Me.LinkLabel30.Font = New System.Drawing.Font("Meiryo UI", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.LinkLabel30.LinkBehavior = System.Windows.Forms.LinkBehavior.NeverUnderline
        Me.LinkLabel30.LinkColor = System.Drawing.Color.Red
        Me.LinkLabel30.Location = New System.Drawing.Point(37, 68)
        Me.LinkLabel30.Margin = New System.Windows.Forms.Padding(0)
        Me.LinkLabel30.Name = "LinkLabel30"
        Me.LinkLabel30.Size = New System.Drawing.Size(19, 17)
        Me.LinkLabel30.TabIndex = 130
        Me.LinkLabel30.TabStop = True
        Me.LinkLabel30.Text = "×"
        Me.LinkLabel30.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.LinkLabel30.Visible = False
        '
        'lblTAISYO_KOKYAKU
        '
        Me.lblTAISYO_KOKYAKU.AutoSize = True
        Me.lblTAISYO_KOKYAKU.Font = New System.Drawing.Font("Meiryo UI", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.lblTAISYO_KOKYAKU.Location = New System.Drawing.Point(69, 71)
        Me.lblTAISYO_KOKYAKU.Name = "lblTAISYO_KOKYAKU"
        Me.lblTAISYO_KOKYAKU.Size = New System.Drawing.Size(60, 15)
        Me.lblTAISYO_KOKYAKU.TabIndex = 332
        Me.lblTAISYO_KOKYAKU.Text = "対象顧客:"
        Me.lblTAISYO_KOKYAKU.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'txtTAISYO_KOKYAKU
        '
        Me.txtTAISYO_KOKYAKU.BackColor = System.Drawing.SystemColors.Window
        Me.txtTAISYO_KOKYAKU.ImeMode = System.Windows.Forms.ImeMode.[On]
        Me.txtTAISYO_KOKYAKU.InputRequired = False
        Me.txtTAISYO_KOKYAKU.Location = New System.Drawing.Point(135, 66)
        Me.txtTAISYO_KOKYAKU.MaxByteLength = 100
        Me.txtTAISYO_KOKYAKU.MaxLength = 50
        Me.txtTAISYO_KOKYAKU.Multiline = True
        Me.txtTAISYO_KOKYAKU.Name = "txtTAISYO_KOKYAKU"
        Me.txtTAISYO_KOKYAKU.SelectAllText = False
        Me.txtTAISYO_KOKYAKU.Size = New System.Drawing.Size(441, 23)
        Me.txtTAISYO_KOKYAKU.TabIndex = 2
        Me.txtTAISYO_KOKYAKU.WatermarkColor = System.Drawing.Color.Empty
        Me.txtTAISYO_KOKYAKU.WatermarkText = Nothing
        '
        'lblKOKYAKU_EIKYO_ETC_COMMENT
        '
        Me.lblKOKYAKU_EIKYO_ETC_COMMENT.AutoSize = True
        Me.lblKOKYAKU_EIKYO_ETC_COMMENT.Font = New System.Drawing.Font("Meiryo UI", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.lblKOKYAKU_EIKYO_ETC_COMMENT.ForeColor = System.Drawing.Color.Black
        Me.lblKOKYAKU_EIKYO_ETC_COMMENT.Location = New System.Drawing.Point(620, 209)
        Me.lblKOKYAKU_EIKYO_ETC_COMMENT.Margin = New System.Windows.Forms.Padding(3, 3, 3, 0)
        Me.lblKOKYAKU_EIKYO_ETC_COMMENT.Name = "lblKOKYAKU_EIKYO_ETC_COMMENT"
        Me.lblKOKYAKU_EIKYO_ETC_COMMENT.Size = New System.Drawing.Size(372, 17)
        Me.lblKOKYAKU_EIKYO_ETC_COMMENT.TabIndex = 330
        Me.lblKOKYAKU_EIKYO_ETC_COMMENT.Text = "(d) 製品引取、現地修理、代品納入等の要否、時期・方法・担当等"
        Me.lblKOKYAKU_EIKYO_ETC_COMMENT.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'lblTUCHI_SYUDAN
        '
        Me.lblTUCHI_SYUDAN.Font = New System.Drawing.Font("Meiryo UI", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.lblTUCHI_SYUDAN.ForeColor = System.Drawing.Color.Black
        Me.lblTUCHI_SYUDAN.Location = New System.Drawing.Point(35, 270)
        Me.lblTUCHI_SYUDAN.Margin = New System.Windows.Forms.Padding(3, 3, 3, 0)
        Me.lblTUCHI_SYUDAN.Name = "lblTUCHI_SYUDAN"
        Me.lblTUCHI_SYUDAN.Size = New System.Drawing.Size(94, 17)
        Me.lblTUCHI_SYUDAN.TabIndex = 329
        Me.lblTUCHI_SYUDAN.Text = "通知手段:"
        Me.lblTUCHI_SYUDAN.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'lblHITUYO_TETUDUKI_ZIKO
        '
        Me.lblHITUYO_TETUDUKI_ZIKO.Font = New System.Drawing.Font("Meiryo UI", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.lblHITUYO_TETUDUKI_ZIKO.ForeColor = System.Drawing.Color.Black
        Me.lblHITUYO_TETUDUKI_ZIKO.Location = New System.Drawing.Point(35, 299)
        Me.lblHITUYO_TETUDUKI_ZIKO.Margin = New System.Windows.Forms.Padding(3, 3, 3, 0)
        Me.lblHITUYO_TETUDUKI_ZIKO.Name = "lblHITUYO_TETUDUKI_ZIKO"
        Me.lblHITUYO_TETUDUKI_ZIKO.Size = New System.Drawing.Size(94, 17)
        Me.lblHITUYO_TETUDUKI_ZIKO.TabIndex = 328
        Me.lblHITUYO_TETUDUKI_ZIKO.Text = "必要手配事項:"
        Me.lblHITUYO_TETUDUKI_ZIKO.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'lblTUCHI_YMD
        '
        Me.lblTUCHI_YMD.Font = New System.Drawing.Font("Meiryo UI", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.lblTUCHI_YMD.ForeColor = System.Drawing.Color.Black
        Me.lblTUCHI_YMD.Location = New System.Drawing.Point(35, 239)
        Me.lblTUCHI_YMD.Margin = New System.Windows.Forms.Padding(3, 3, 3, 0)
        Me.lblTUCHI_YMD.Name = "lblTUCHI_YMD"
        Me.lblTUCHI_YMD.Size = New System.Drawing.Size(94, 17)
        Me.lblTUCHI_YMD.TabIndex = 327
        Me.lblTUCHI_YMD.Text = "通知時期:"
        Me.lblTUCHI_YMD.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'pnlrbtnTUCHI
        '
        Me.pnlrbtnTUCHI.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.pnlrbtnTUCHI.Controls.Add(Me.rbtnKOKYAKU_EIKYO_TUCHI_HANTEI_KB_F)
        Me.pnlrbtnTUCHI.Controls.Add(Me.rbtnKOKYAKU_EIKYO_TUCHI_HANTEI_KB_T)
        Me.pnlrbtnTUCHI.HitEnabled = False
        Me.pnlrbtnTUCHI.Location = New System.Drawing.Point(174, 204)
        Me.pnlrbtnTUCHI.Name = "pnlrbtnTUCHI"
        Me.pnlrbtnTUCHI.Size = New System.Drawing.Size(97, 27)
        Me.pnlrbtnTUCHI.TabIndex = 5
        '
        'rbtnKOKYAKU_EIKYO_TUCHI_HANTEI_KB_F
        '
        Me.rbtnKOKYAKU_EIKYO_TUCHI_HANTEI_KB_F.AutoSize = True
        Me.rbtnKOKYAKU_EIKYO_TUCHI_HANTEI_KB_F.Dock = System.Windows.Forms.DockStyle.Right
        Me.rbtnKOKYAKU_EIKYO_TUCHI_HANTEI_KB_F.Location = New System.Drawing.Point(50, 0)
        Me.rbtnKOKYAKU_EIKYO_TUCHI_HANTEI_KB_F.Name = "rbtnKOKYAKU_EIKYO_TUCHI_HANTEI_KB_F"
        Me.rbtnKOKYAKU_EIKYO_TUCHI_HANTEI_KB_F.Padding = New System.Windows.Forms.Padding(3)
        Me.rbtnKOKYAKU_EIKYO_TUCHI_HANTEI_KB_F.Size = New System.Drawing.Size(45, 25)
        Me.rbtnKOKYAKU_EIKYO_TUCHI_HANTEI_KB_F.TabIndex = 7
        Me.rbtnKOKYAKU_EIKYO_TUCHI_HANTEI_KB_F.Text = "否"
        Me.rbtnKOKYAKU_EIKYO_TUCHI_HANTEI_KB_F.UseVisualStyleBackColor = True
        '
        'rbtnKOKYAKU_EIKYO_TUCHI_HANTEI_KB_T
        '
        Me.rbtnKOKYAKU_EIKYO_TUCHI_HANTEI_KB_T.AutoSize = True
        Me.rbtnKOKYAKU_EIKYO_TUCHI_HANTEI_KB_T.Dock = System.Windows.Forms.DockStyle.Left
        Me.rbtnKOKYAKU_EIKYO_TUCHI_HANTEI_KB_T.Location = New System.Drawing.Point(0, 0)
        Me.rbtnKOKYAKU_EIKYO_TUCHI_HANTEI_KB_T.Name = "rbtnKOKYAKU_EIKYO_TUCHI_HANTEI_KB_T"
        Me.rbtnKOKYAKU_EIKYO_TUCHI_HANTEI_KB_T.Padding = New System.Windows.Forms.Padding(3)
        Me.rbtnKOKYAKU_EIKYO_TUCHI_HANTEI_KB_T.Size = New System.Drawing.Size(45, 25)
        Me.rbtnKOKYAKU_EIKYO_TUCHI_HANTEI_KB_T.TabIndex = 6
        Me.rbtnKOKYAKU_EIKYO_TUCHI_HANTEI_KB_T.Text = "要"
        Me.rbtnKOKYAKU_EIKYO_TUCHI_HANTEI_KB_T.UseVisualStyleBackColor = True
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.BackColor = System.Drawing.Color.Wheat
        Me.Label2.Font = New System.Drawing.Font("Meiryo UI", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label2.Location = New System.Drawing.Point(3, 3)
        Me.Label2.Margin = New System.Windows.Forms.Padding(3, 3, 3, 0)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(157, 24)
        Me.Label2.TabIndex = 325
        Me.Label2.Text = "１．顧客への影響"
        Me.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'cmbKOKYAKU_EIKYO_HANTEI_COMMENT
        '
        Me.cmbKOKYAKU_EIKYO_HANTEI_COMMENT.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cmbKOKYAKU_EIKYO_HANTEI_COMMENT.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cmbKOKYAKU_EIKYO_HANTEI_COMMENT.BackColor = System.Drawing.SystemColors.Window
        Me.cmbKOKYAKU_EIKYO_HANTEI_COMMENT.Cursor = System.Windows.Forms.Cursors.Default
        Me.cmbKOKYAKU_EIKYO_HANTEI_COMMENT.DisplayMember = "DISP"
        Me.cmbKOKYAKU_EIKYO_HANTEI_COMMENT.Font = New System.Drawing.Font("Meiryo UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.cmbKOKYAKU_EIKYO_HANTEI_COMMENT.ForeColor = System.Drawing.SystemColors.ControlText
        Me.cmbKOKYAKU_EIKYO_HANTEI_COMMENT.FormattingEnabled = True
        Me.cmbKOKYAKU_EIKYO_HANTEI_COMMENT.HorizontalContentAlignment = System.Drawing.StringAlignment.Near
        Me.cmbKOKYAKU_EIKYO_HANTEI_COMMENT.ImeMode = System.Windows.Forms.ImeMode.[On]
        Me.cmbKOKYAKU_EIKYO_HANTEI_COMMENT.IsSelected = False
        Me.cmbKOKYAKU_EIKYO_HANTEI_COMMENT.Location = New System.Drawing.Point(685, 36)
        Me.cmbKOKYAKU_EIKYO_HANTEI_COMMENT.MaxLength = 50
        Me.cmbKOKYAKU_EIKYO_HANTEI_COMMENT.Name = "cmbKOKYAKU_EIKYO_HANTEI_COMMENT"
        Me.cmbKOKYAKU_EIKYO_HANTEI_COMMENT.NullValue = " "
        Me.cmbKOKYAKU_EIKYO_HANTEI_COMMENT.Size = New System.Drawing.Size(508, 25)
        Me.cmbKOKYAKU_EIKYO_HANTEI_COMMENT.TabIndex = 1
        Me.cmbKOKYAKU_EIKYO_HANTEI_COMMENT.ValueMember = "VALUE"
        Me.cmbKOKYAKU_EIKYO_HANTEI_COMMENT.Visible = False
        '
        'PanelEx1
        '
        Me.PanelEx1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.PanelEx1.Controls.Add(Me.rbtnKOKYAKU_EIKYO_HANTEI_KB_F)
        Me.PanelEx1.Controls.Add(Me.rbtnKOKYAKU_EIKYO_HANTEI_KB_T)
        Me.PanelEx1.HitEnabled = False
        Me.PanelEx1.Location = New System.Drawing.Point(479, 34)
        Me.PanelEx1.Name = "PanelEx1"
        Me.PanelEx1.Size = New System.Drawing.Size(97, 27)
        Me.PanelEx1.TabIndex = 0
        '
        'rbtnKOKYAKU_EIKYO_HANTEI_KB_F
        '
        Me.rbtnKOKYAKU_EIKYO_HANTEI_KB_F.AutoSize = True
        Me.rbtnKOKYAKU_EIKYO_HANTEI_KB_F.Dock = System.Windows.Forms.DockStyle.Right
        Me.rbtnKOKYAKU_EIKYO_HANTEI_KB_F.Location = New System.Drawing.Point(43, 0)
        Me.rbtnKOKYAKU_EIKYO_HANTEI_KB_F.Name = "rbtnKOKYAKU_EIKYO_HANTEI_KB_F"
        Me.rbtnKOKYAKU_EIKYO_HANTEI_KB_F.Padding = New System.Windows.Forms.Padding(3)
        Me.rbtnKOKYAKU_EIKYO_HANTEI_KB_F.Size = New System.Drawing.Size(52, 25)
        Me.rbtnKOKYAKU_EIKYO_HANTEI_KB_F.TabIndex = 1
        Me.rbtnKOKYAKU_EIKYO_HANTEI_KB_F.Text = "なし"
        Me.rbtnKOKYAKU_EIKYO_HANTEI_KB_F.UseVisualStyleBackColor = True
        '
        'rbtnKOKYAKU_EIKYO_HANTEI_KB_T
        '
        Me.rbtnKOKYAKU_EIKYO_HANTEI_KB_T.AutoSize = True
        Me.rbtnKOKYAKU_EIKYO_HANTEI_KB_T.Dock = System.Windows.Forms.DockStyle.Left
        Me.rbtnKOKYAKU_EIKYO_HANTEI_KB_T.Location = New System.Drawing.Point(0, 0)
        Me.rbtnKOKYAKU_EIKYO_HANTEI_KB_T.Name = "rbtnKOKYAKU_EIKYO_HANTEI_KB_T"
        Me.rbtnKOKYAKU_EIKYO_HANTEI_KB_T.Padding = New System.Windows.Forms.Padding(3)
        Me.rbtnKOKYAKU_EIKYO_HANTEI_KB_T.Size = New System.Drawing.Size(51, 25)
        Me.rbtnKOKYAKU_EIKYO_HANTEI_KB_T.TabIndex = 0
        Me.rbtnKOKYAKU_EIKYO_HANTEI_KB_T.Text = "あり"
        Me.rbtnKOKYAKU_EIKYO_HANTEI_KB_T.UseVisualStyleBackColor = True
        '
        'lblSETUMON_1
        '
        Me.lblSETUMON_1.AutoSize = True
        Me.lblSETUMON_1.Font = New System.Drawing.Font("Meiryo UI", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.lblSETUMON_1.ForeColor = System.Drawing.Color.Black
        Me.lblSETUMON_1.Location = New System.Drawing.Point(21, 38)
        Me.lblSETUMON_1.Margin = New System.Windows.Forms.Padding(3, 3, 3, 0)
        Me.lblSETUMON_1.Name = "lblSETUMON_1"
        Me.lblSETUMON_1.Size = New System.Drawing.Size(453, 19)
        Me.lblSETUMON_1.TabIndex = 84
        Me.lblSETUMON_1.Text = "発生したと同様の不適合製品が顧客に納入されている可能性があるか？"
        Me.lblSETUMON_1.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'txtKOKYAKU_EIKYO_NAIYO
        '
        Me.txtKOKYAKU_EIKYO_NAIYO.AcceptsReturn = True
        Me.txtKOKYAKU_EIKYO_NAIYO.BackColor = System.Drawing.SystemColors.Window
        Me.txtKOKYAKU_EIKYO_NAIYO.ImeMode = System.Windows.Forms.ImeMode.[On]
        Me.txtKOKYAKU_EIKYO_NAIYO.InputRequired = False
        Me.txtKOKYAKU_EIKYO_NAIYO.Location = New System.Drawing.Point(27, 130)
        Me.txtKOKYAKU_EIKYO_NAIYO.MaxByteLength = 200
        Me.txtKOKYAKU_EIKYO_NAIYO.MaxLength = 100
        Me.txtKOKYAKU_EIKYO_NAIYO.Multiline = True
        Me.txtKOKYAKU_EIKYO_NAIYO.Name = "txtKOKYAKU_EIKYO_NAIYO"
        Me.txtKOKYAKU_EIKYO_NAIYO.SelectAllText = False
        Me.txtKOKYAKU_EIKYO_NAIYO.ShowRemainingChars = True
        Me.txtKOKYAKU_EIKYO_NAIYO.Size = New System.Drawing.Size(549, 60)
        Me.txtKOKYAKU_EIKYO_NAIYO.TabIndex = 3
        Me.txtKOKYAKU_EIKYO_NAIYO.WatermarkColor = System.Drawing.Color.Empty
        Me.txtKOKYAKU_EIKYO_NAIYO.WatermarkText = Nothing
        '
        'lblKOKYAKU_EIKYO_NAIYO
        '
        Me.lblKOKYAKU_EIKYO_NAIYO.AutoSize = True
        Me.lblKOKYAKU_EIKYO_NAIYO.Font = New System.Drawing.Font("Meiryo UI", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.lblKOKYAKU_EIKYO_NAIYO.ForeColor = System.Drawing.Color.Black
        Me.lblKOKYAKU_EIKYO_NAIYO.Location = New System.Drawing.Point(24, 110)
        Me.lblKOKYAKU_EIKYO_NAIYO.Margin = New System.Windows.Forms.Padding(3, 3, 3, 0)
        Me.lblKOKYAKU_EIKYO_NAIYO.Name = "lblKOKYAKU_EIKYO_NAIYO"
        Me.lblKOKYAKU_EIKYO_NAIYO.Size = New System.Drawing.Size(379, 17)
        Me.lblKOKYAKU_EIKYO_NAIYO.TabIndex = 246
        Me.lblKOKYAKU_EIKYO_NAIYO.Text = "(a) 不適合の存在する可能性のある製品範囲の特定または確認手段"
        Me.lblKOKYAKU_EIKYO_NAIYO.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'txtKOKYAKU_EIKYO_ETC_COMMENT
        '
        Me.txtKOKYAKU_EIKYO_ETC_COMMENT.AcceptsReturn = True
        Me.txtKOKYAKU_EIKYO_ETC_COMMENT.BackColor = System.Drawing.SystemColors.Window
        Me.txtKOKYAKU_EIKYO_ETC_COMMENT.ImeMode = System.Windows.Forms.ImeMode.[On]
        Me.txtKOKYAKU_EIKYO_ETC_COMMENT.InputRequired = False
        Me.txtKOKYAKU_EIKYO_ETC_COMMENT.Location = New System.Drawing.Point(623, 229)
        Me.txtKOKYAKU_EIKYO_ETC_COMMENT.MaxByteLength = 200
        Me.txtKOKYAKU_EIKYO_ETC_COMMENT.MaxLength = 100
        Me.txtKOKYAKU_EIKYO_ETC_COMMENT.Multiline = True
        Me.txtKOKYAKU_EIKYO_ETC_COMMENT.Name = "txtKOKYAKU_EIKYO_ETC_COMMENT"
        Me.txtKOKYAKU_EIKYO_ETC_COMMENT.SelectAllText = False
        Me.txtKOKYAKU_EIKYO_ETC_COMMENT.ShowRemainingChars = True
        Me.txtKOKYAKU_EIKYO_ETC_COMMENT.Size = New System.Drawing.Size(570, 60)
        Me.txtKOKYAKU_EIKYO_ETC_COMMENT.TabIndex = 9
        Me.txtKOKYAKU_EIKYO_ETC_COMMENT.WatermarkColor = System.Drawing.Color.Empty
        Me.txtKOKYAKU_EIKYO_ETC_COMMENT.WatermarkText = Nothing
        '
        'txtKAKUNIN_SYUDAN
        '
        Me.txtKAKUNIN_SYUDAN.AcceptsReturn = True
        Me.txtKAKUNIN_SYUDAN.BackColor = System.Drawing.SystemColors.Window
        Me.txtKAKUNIN_SYUDAN.ImeMode = System.Windows.Forms.ImeMode.[On]
        Me.txtKAKUNIN_SYUDAN.InputRequired = False
        Me.txtKAKUNIN_SYUDAN.Location = New System.Drawing.Point(623, 130)
        Me.txtKAKUNIN_SYUDAN.MaxByteLength = 200
        Me.txtKAKUNIN_SYUDAN.MaxLength = 100
        Me.txtKAKUNIN_SYUDAN.Multiline = True
        Me.txtKAKUNIN_SYUDAN.Name = "txtKAKUNIN_SYUDAN"
        Me.txtKAKUNIN_SYUDAN.SelectAllText = False
        Me.txtKAKUNIN_SYUDAN.ShowRemainingChars = True
        Me.txtKAKUNIN_SYUDAN.Size = New System.Drawing.Size(570, 60)
        Me.txtKAKUNIN_SYUDAN.TabIndex = 4
        Me.txtKAKUNIN_SYUDAN.WatermarkColor = System.Drawing.Color.Empty
        Me.txtKAKUNIN_SYUDAN.WatermarkText = Nothing
        '
        'lblKOKYAKU_EIKYO_TUCHI_HANTEI_KB
        '
        Me.lblKOKYAKU_EIKYO_TUCHI_HANTEI_KB.AutoSize = True
        Me.lblKOKYAKU_EIKYO_TUCHI_HANTEI_KB.Font = New System.Drawing.Font("Meiryo UI", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.lblKOKYAKU_EIKYO_TUCHI_HANTEI_KB.ForeColor = System.Drawing.Color.Black
        Me.lblKOKYAKU_EIKYO_TUCHI_HANTEI_KB.Location = New System.Drawing.Point(24, 209)
        Me.lblKOKYAKU_EIKYO_TUCHI_HANTEI_KB.Margin = New System.Windows.Forms.Padding(3, 3, 3, 0)
        Me.lblKOKYAKU_EIKYO_TUCHI_HANTEI_KB.Name = "lblKOKYAKU_EIKYO_TUCHI_HANTEI_KB"
        Me.lblKOKYAKU_EIKYO_TUCHI_HANTEI_KB.Size = New System.Drawing.Size(144, 17)
        Me.lblKOKYAKU_EIKYO_TUCHI_HANTEI_KB.TabIndex = 248
        Me.lblKOKYAKU_EIKYO_TUCHI_HANTEI_KB.Text = "(c) 顧客への通知の要否"
        Me.lblKOKYAKU_EIKYO_TUCHI_HANTEI_KB.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'lblKOKYAKU_EIKYO_HANTEI_COMMENT
        '
        Me.lblKOKYAKU_EIKYO_HANTEI_COMMENT.AutoSize = True
        Me.lblKOKYAKU_EIKYO_HANTEI_COMMENT.Font = New System.Drawing.Font("Meiryo UI", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.lblKOKYAKU_EIKYO_HANTEI_COMMENT.Location = New System.Drawing.Point(620, 41)
        Me.lblKOKYAKU_EIKYO_HANTEI_COMMENT.Name = "lblKOKYAKU_EIKYO_HANTEI_COMMENT"
        Me.lblKOKYAKU_EIKYO_HANTEI_COMMENT.Size = New System.Drawing.Size(59, 15)
        Me.lblKOKYAKU_EIKYO_HANTEI_COMMENT.TabIndex = 310
        Me.lblKOKYAKU_EIKYO_HANTEI_COMMENT.Text = "否の理由:"
        Me.lblKOKYAKU_EIKYO_HANTEI_COMMENT.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.lblKOKYAKU_EIKYO_HANTEI_COMMENT.Visible = False
        '
        'lblKAKUNIN_SYUDAN
        '
        Me.lblKAKUNIN_SYUDAN.AutoSize = True
        Me.lblKAKUNIN_SYUDAN.Font = New System.Drawing.Font("Meiryo UI", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.lblKAKUNIN_SYUDAN.ForeColor = System.Drawing.Color.Black
        Me.lblKAKUNIN_SYUDAN.Location = New System.Drawing.Point(620, 110)
        Me.lblKAKUNIN_SYUDAN.Margin = New System.Windows.Forms.Padding(3, 3, 3, 0)
        Me.lblKAKUNIN_SYUDAN.Name = "lblKAKUNIN_SYUDAN"
        Me.lblKAKUNIN_SYUDAN.Size = New System.Drawing.Size(181, 17)
        Me.lblKAKUNIN_SYUDAN.TabIndex = 248
        Me.lblKAKUNIN_SYUDAN.Text = "(b) 不適合が顧客に与える影響"
        Me.lblKAKUNIN_SYUDAN.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'txtHITUYO_TETUDUKI_ZIKO
        '
        Me.txtHITUYO_TETUDUKI_ZIKO.BackColor = System.Drawing.SystemColors.Window
        Me.txtHITUYO_TETUDUKI_ZIKO.ImeMode = System.Windows.Forms.ImeMode.[On]
        Me.txtHITUYO_TETUDUKI_ZIKO.InputRequired = False
        Me.txtHITUYO_TETUDUKI_ZIKO.Location = New System.Drawing.Point(135, 296)
        Me.txtHITUYO_TETUDUKI_ZIKO.MaxByteLength = 200
        Me.txtHITUYO_TETUDUKI_ZIKO.MaxLength = 100
        Me.txtHITUYO_TETUDUKI_ZIKO.Multiline = True
        Me.txtHITUYO_TETUDUKI_ZIKO.Name = "txtHITUYO_TETUDUKI_ZIKO"
        Me.txtHITUYO_TETUDUKI_ZIKO.SelectAllText = False
        Me.txtHITUYO_TETUDUKI_ZIKO.Size = New System.Drawing.Size(441, 23)
        Me.txtHITUYO_TETUDUKI_ZIKO.TabIndex = 8
        Me.txtHITUYO_TETUDUKI_ZIKO.WatermarkColor = System.Drawing.Color.Empty
        Me.txtHITUYO_TETUDUKI_ZIKO.WatermarkText = Nothing
        '
        'txtTUCHI_SYUDAN
        '
        Me.txtTUCHI_SYUDAN.BackColor = System.Drawing.SystemColors.Window
        Me.txtTUCHI_SYUDAN.ImeMode = System.Windows.Forms.ImeMode.[On]
        Me.txtTUCHI_SYUDAN.InputRequired = False
        Me.txtTUCHI_SYUDAN.Location = New System.Drawing.Point(135, 267)
        Me.txtTUCHI_SYUDAN.MaxByteLength = 200
        Me.txtTUCHI_SYUDAN.MaxLength = 100
        Me.txtTUCHI_SYUDAN.Multiline = True
        Me.txtTUCHI_SYUDAN.Name = "txtTUCHI_SYUDAN"
        Me.txtTUCHI_SYUDAN.SelectAllText = False
        Me.txtTUCHI_SYUDAN.Size = New System.Drawing.Size(441, 23)
        Me.txtTUCHI_SYUDAN.TabIndex = 7
        Me.txtTUCHI_SYUDAN.WatermarkColor = System.Drawing.Color.Empty
        Me.txtTUCHI_SYUDAN.WatermarkText = Nothing
        '
        'dtTUCHI_YMD
        '
        Me.dtTUCHI_YMD.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.dtTUCHI_YMD.GotFocusedColor = System.Drawing.Color.FromArgb(CType(CType(190, Byte), Integer), CType(CType(180, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.dtTUCHI_YMD.Location = New System.Drawing.Point(135, 237)
        Me.dtTUCHI_YMD.MaxDate = New Date(9998, 12, 31, 0, 0, 0, 0)
        Me.dtTUCHI_YMD.MinDate = New Date(1753, 1, 1, 0, 0, 0, 0)
        Me.dtTUCHI_YMD.MinimumSize = New System.Drawing.Size(98, 24)
        Me.dtTUCHI_YMD.Name = "dtTUCHI_YMD"
        Me.dtTUCHI_YMD.ReadOnly = False
        Me.dtTUCHI_YMD.Size = New System.Drawing.Size(98, 24)
        Me.dtTUCHI_YMD.TabIndex = 6
        Me.dtTUCHI_YMD.Value = ""
        Me.dtTUCHI_YMD.ValueNonFormat = ""
        '
        'lblCARFlame
        '
        Me.lblCARFlame.BackColor = System.Drawing.Color.Black
        Me.lblCARFlame.Dock = System.Windows.Forms.DockStyle.Right
        Me.lblCARFlame.Location = New System.Drawing.Point(1199, 0)
        Me.lblCARFlame.Name = "lblCARFlame"
        Me.lblCARFlame.Size = New System.Drawing.Size(13, 330)
        Me.lblCARFlame.TabIndex = 315
        Me.lblCARFlame.Visible = False
        '
        'pnlZESEI_SYOCHI
        '
        Me.pnlZESEI_SYOCHI.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.pnlZESEI_SYOCHI.BackColor = System.Drawing.Color.Transparent
        Me.pnlZESEI_SYOCHI.Controls.Add(Me.lblZESEI_SYOCHIFlame)
        Me.pnlZESEI_SYOCHI.Controls.Add(Me.lblSTAGE10)
        Me.pnlZESEI_SYOCHI.HitEnabled = False
        Me.pnlZESEI_SYOCHI.Location = New System.Drawing.Point(3, 643)
        Me.pnlZESEI_SYOCHI.Margin = New System.Windows.Forms.Padding(2)
        Me.pnlZESEI_SYOCHI.MinimumSize = New System.Drawing.Size(1212, 0)
        Me.pnlZESEI_SYOCHI.Name = "pnlZESEI_SYOCHI"
        Me.pnlZESEI_SYOCHI.Padding = New System.Windows.Forms.Padding(2)
        Me.pnlZESEI_SYOCHI.Size = New System.Drawing.Size(1212, 55)
        Me.pnlZESEI_SYOCHI.TabIndex = 3
        '
        'lblZESEI_SYOCHIFlame
        '
        Me.lblZESEI_SYOCHIFlame.BackColor = System.Drawing.Color.Black
        Me.lblZESEI_SYOCHIFlame.Dock = System.Windows.Forms.DockStyle.Right
        Me.lblZESEI_SYOCHIFlame.Location = New System.Drawing.Point(1197, 2)
        Me.lblZESEI_SYOCHIFlame.Name = "lblZESEI_SYOCHIFlame"
        Me.lblZESEI_SYOCHIFlame.Size = New System.Drawing.Size(13, 51)
        Me.lblZESEI_SYOCHIFlame.TabIndex = 315
        Me.lblZESEI_SYOCHIFlame.Visible = False
        '
        'lblSTAGE10
        '
        Me.lblSTAGE10.AutoSize = True
        Me.lblSTAGE10.BackColor = System.Drawing.Color.Wheat
        Me.lblSTAGE10.Font = New System.Drawing.Font("Meiryo UI", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.lblSTAGE10.Location = New System.Drawing.Point(3, 5)
        Me.lblSTAGE10.Margin = New System.Windows.Forms.Padding(3, 3, 3, 0)
        Me.lblSTAGE10.Name = "lblSTAGE10"
        Me.lblSTAGE10.Size = New System.Drawing.Size(208, 24)
        Me.lblSTAGE10.TabIndex = 314
        Me.lblSTAGE10.Text = "３．顧客に影響する範囲"
        Me.lblSTAGE10.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'pnlSYOCHI_KIROKU
        '
        Me.pnlSYOCHI_KIROKU.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.pnlSYOCHI_KIROKU.BackColor = System.Drawing.Color.Transparent
        Me.pnlSYOCHI_KIROKU.Controls.Add(Me.lblSYOCHI_KIROKUFlame)
        Me.pnlSYOCHI_KIROKU.Controls.Add(Me.lblSTAGE08)
        Me.pnlSYOCHI_KIROKU.HitEnabled = False
        Me.pnlSYOCHI_KIROKU.Location = New System.Drawing.Point(3, 338)
        Me.pnlSYOCHI_KIROKU.Margin = New System.Windows.Forms.Padding(2)
        Me.pnlSYOCHI_KIROKU.MinimumSize = New System.Drawing.Size(1212, 0)
        Me.pnlSYOCHI_KIROKU.Name = "pnlSYOCHI_KIROKU"
        Me.pnlSYOCHI_KIROKU.Padding = New System.Windows.Forms.Padding(2)
        Me.pnlSYOCHI_KIROKU.Size = New System.Drawing.Size(1212, 301)
        Me.pnlSYOCHI_KIROKU.TabIndex = 2
        '
        'lblSYOCHI_KIROKUFlame
        '
        Me.lblSYOCHI_KIROKUFlame.BackColor = System.Drawing.Color.Black
        Me.lblSYOCHI_KIROKUFlame.Dock = System.Windows.Forms.DockStyle.Right
        Me.lblSYOCHI_KIROKUFlame.Location = New System.Drawing.Point(1197, 2)
        Me.lblSYOCHI_KIROKUFlame.Name = "lblSYOCHI_KIROKUFlame"
        Me.lblSYOCHI_KIROKUFlame.Size = New System.Drawing.Size(13, 297)
        Me.lblSYOCHI_KIROKUFlame.TabIndex = 314
        Me.lblSYOCHI_KIROKUFlame.Visible = False
        '
        'lblSTAGE08
        '
        Me.lblSTAGE08.BackColor = System.Drawing.Color.Wheat
        Me.lblSTAGE08.Dock = System.Windows.Forms.DockStyle.Left
        Me.lblSTAGE08.Font = New System.Drawing.Font("Meiryo UI", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.lblSTAGE08.Location = New System.Drawing.Point(2, 2)
        Me.lblSTAGE08.Margin = New System.Windows.Forms.Padding(3, 3, 3, 0)
        Me.lblSTAGE08.Name = "lblSTAGE08"
        Me.lblSTAGE08.Size = New System.Drawing.Size(33, 297)
        Me.lblSTAGE08.TabIndex = 313
        Me.lblSTAGE08.Text = "②" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "要" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "処" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "置" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "事" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "項" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "調" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "査"
        Me.lblSTAGE08.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'cmbST01_DestTANTO
        '
        Me.cmbST01_DestTANTO.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.cmbST01_DestTANTO.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cmbST01_DestTANTO.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cmbST01_DestTANTO.BackColor = System.Drawing.SystemColors.Window
        Me.cmbST01_DestTANTO.Cursor = System.Windows.Forms.Cursors.Default
        Me.cmbST01_DestTANTO.DisplayMember = "DISP"
        Me.cmbST01_DestTANTO.Font = New System.Drawing.Font("Meiryo UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.cmbST01_DestTANTO.ForeColor = System.Drawing.SystemColors.ControlText
        Me.cmbST01_DestTANTO.FormattingEnabled = True
        Me.cmbST01_DestTANTO.HorizontalContentAlignment = System.Drawing.StringAlignment.Near
        Me.cmbST01_DestTANTO.ImeMode = System.Windows.Forms.ImeMode.Disable
        Me.cmbST01_DestTANTO.IsSelected = False
        Me.cmbST01_DestTANTO.Location = New System.Drawing.Point(739, 32767)
        Me.cmbST01_DestTANTO.Name = "cmbST01_DestTANTO"
        Me.cmbST01_DestTANTO.NullValue = " "
        Me.cmbST01_DestTANTO.Size = New System.Drawing.Size(154, 25)
        Me.cmbST01_DestTANTO.TabIndex = 215
        Me.cmbST01_DestTANTO.Text = "(選択)"
        Me.cmbST01_DestTANTO.ValueMember = "VALUE"
        '
        'mtxST01_NextStageName
        '
        Me.mtxST01_NextStageName.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.mtxST01_NextStageName.BackColor = System.Drawing.SystemColors.Window
        Me.mtxST01_NextStageName.ImeMode = System.Windows.Forms.ImeMode.Disable
        Me.mtxST01_NextStageName.InputRequired = False
        Me.mtxST01_NextStageName.Location = New System.Drawing.Point(359, 32767)
        Me.mtxST01_NextStageName.MaxByteLength = 0
        Me.mtxST01_NextStageName.Name = "mtxST01_NextStageName"
        Me.mtxST01_NextStageName.SelectAllText = False
        Me.mtxST01_NextStageName.Size = New System.Drawing.Size(296, 24)
        Me.mtxST01_NextStageName.TabIndex = 214
        Me.mtxST01_NextStageName.WatermarkColor = System.Drawing.Color.Empty
        Me.mtxST01_NextStageName.WatermarkText = Nothing
        '
        'Label123
        '
        Me.Label123.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.Label123.AutoSize = True
        Me.Label123.Font = New System.Drawing.Font("Meiryo UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label123.Location = New System.Drawing.Point(255, 32767)
        Me.Label123.Margin = New System.Windows.Forms.Padding(3, 3, 3, 0)
        Me.Label123.Name = "Label123"
        Me.Label123.Size = New System.Drawing.Size(98, 15)
        Me.Label123.TabIndex = 213
        Me.Label123.Text = "承認先ステージ名:"
        Me.Label123.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label124
        '
        Me.Label124.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.Label124.AutoSize = True
        Me.Label124.Font = New System.Drawing.Font("Meiryo UI", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label124.Location = New System.Drawing.Point(661, 32767)
        Me.Label124.Margin = New System.Windows.Forms.Padding(3, 3, 3, 0)
        Me.Label124.Name = "Label124"
        Me.Label124.Size = New System.Drawing.Size(72, 15)
        Me.Label124.TabIndex = 212
        Me.Label124.Text = "申請先社員:"
        Me.Label124.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label139
        '
        Me.Label139.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.Label139.AutoSize = True
        Me.Label139.Font = New System.Drawing.Font("Meiryo UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label139.Location = New System.Drawing.Point(10, 32767)
        Me.Label139.Margin = New System.Windows.Forms.Padding(3, 3, 3, 0)
        Me.Label139.Name = "Label139"
        Me.Label139.Size = New System.Drawing.Size(102, 15)
        Me.Label139.TabIndex = 211
        Me.Label139.Text = "承認・申請年月日:"
        Me.Label139.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'mtxST01_UPD_YMD
        '
        Me.mtxST01_UPD_YMD.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.mtxST01_UPD_YMD.BackColor = System.Drawing.Color.White
        Me.mtxST01_UPD_YMD.ImeMode = System.Windows.Forms.ImeMode.Disable
        Me.mtxST01_UPD_YMD.InputRequired = False
        Me.mtxST01_UPD_YMD.Location = New System.Drawing.Point(118, 32767)
        Me.mtxST01_UPD_YMD.MaxByteLength = 0
        Me.mtxST01_UPD_YMD.Name = "mtxST01_UPD_YMD"
        Me.mtxST01_UPD_YMD.SelectAllText = False
        Me.mtxST01_UPD_YMD.Size = New System.Drawing.Size(115, 24)
        Me.mtxST01_UPD_YMD.TabIndex = 210
        Me.mtxST01_UPD_YMD.WatermarkColor = System.Drawing.Color.Empty
        Me.mtxST01_UPD_YMD.WatermarkText = Nothing
        '
        'flpnlStageIndex
        '
        Me.flpnlStageIndex.Controls.Add(Me.rsbtnST01)
        Me.flpnlStageIndex.Controls.Add(Me.rsbtnST02)
        Me.flpnlStageIndex.Controls.Add(Me.rsbtnST03)
        Me.flpnlStageIndex.Controls.Add(Me.rsbtnST04)
        Me.flpnlStageIndex.Controls.Add(Me.rsbtnST05)
        Me.flpnlStageIndex.Controls.Add(Me.rsbtnST06)
        Me.flpnlStageIndex.Controls.Add(Me.rsbtnST99)
        Me.flpnlStageIndex.Location = New System.Drawing.Point(630, 63)
        Me.flpnlStageIndex.Name = "flpnlStageIndex"
        Me.flpnlStageIndex.Size = New System.Drawing.Size(622, 31)
        Me.flpnlStageIndex.TabIndex = 254
        '
        'rsbtnST01
        '
        Me.rsbtnST01.Appearance = System.Windows.Forms.Appearance.Button
        Me.rsbtnST01.Cursor = System.Windows.Forms.Cursors.Hand
        Me.rsbtnST01.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.rsbtnST01.Font = New System.Drawing.Font("Meiryo UI", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.rsbtnST01.Location = New System.Drawing.Point(3, 3)
        Me.rsbtnST01.Name = "rsbtnST01"
        Me.rsbtnST01.Size = New System.Drawing.Size(82, 26)
        Me.rsbtnST01.TabIndex = 0
        Me.rsbtnST01.Text = "ST1"
        Me.rsbtnST01.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.rsbtnST01.UseVisualStyleBackColor = True
        '
        'rsbtnST02
        '
        Me.rsbtnST02.Appearance = System.Windows.Forms.Appearance.Button
        Me.rsbtnST02.Cursor = System.Windows.Forms.Cursors.Hand
        Me.rsbtnST02.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.rsbtnST02.Font = New System.Drawing.Font("Meiryo UI", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.rsbtnST02.Location = New System.Drawing.Point(91, 3)
        Me.rsbtnST02.Name = "rsbtnST02"
        Me.rsbtnST02.Size = New System.Drawing.Size(82, 26)
        Me.rsbtnST02.TabIndex = 1
        Me.rsbtnST02.Text = "ST2"
        Me.rsbtnST02.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.rsbtnST02.UseVisualStyleBackColor = True
        '
        'rsbtnST03
        '
        Me.rsbtnST03.Appearance = System.Windows.Forms.Appearance.Button
        Me.rsbtnST03.Cursor = System.Windows.Forms.Cursors.Hand
        Me.rsbtnST03.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.rsbtnST03.Font = New System.Drawing.Font("Meiryo UI", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.rsbtnST03.Location = New System.Drawing.Point(179, 3)
        Me.rsbtnST03.Name = "rsbtnST03"
        Me.rsbtnST03.Size = New System.Drawing.Size(82, 26)
        Me.rsbtnST03.TabIndex = 2
        Me.rsbtnST03.Text = "ST3"
        Me.rsbtnST03.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.rsbtnST03.UseVisualStyleBackColor = True
        '
        'rsbtnST04
        '
        Me.rsbtnST04.Appearance = System.Windows.Forms.Appearance.Button
        Me.rsbtnST04.Cursor = System.Windows.Forms.Cursors.Hand
        Me.rsbtnST04.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.rsbtnST04.Font = New System.Drawing.Font("Meiryo UI", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.rsbtnST04.Location = New System.Drawing.Point(267, 3)
        Me.rsbtnST04.Name = "rsbtnST04"
        Me.rsbtnST04.Size = New System.Drawing.Size(82, 26)
        Me.rsbtnST04.TabIndex = 3
        Me.rsbtnST04.Text = "ST4"
        Me.rsbtnST04.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.rsbtnST04.UseVisualStyleBackColor = True
        '
        'rsbtnST05
        '
        Me.rsbtnST05.Appearance = System.Windows.Forms.Appearance.Button
        Me.rsbtnST05.Cursor = System.Windows.Forms.Cursors.Hand
        Me.rsbtnST05.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.rsbtnST05.Font = New System.Drawing.Font("Meiryo UI", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.rsbtnST05.Location = New System.Drawing.Point(355, 3)
        Me.rsbtnST05.Name = "rsbtnST05"
        Me.rsbtnST05.Size = New System.Drawing.Size(82, 26)
        Me.rsbtnST05.TabIndex = 4
        Me.rsbtnST05.Text = "ST5"
        Me.rsbtnST05.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.rsbtnST05.UseVisualStyleBackColor = True
        '
        'rsbtnST06
        '
        Me.rsbtnST06.Appearance = System.Windows.Forms.Appearance.Button
        Me.rsbtnST06.Cursor = System.Windows.Forms.Cursors.Hand
        Me.rsbtnST06.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.rsbtnST06.Font = New System.Drawing.Font("Meiryo UI", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.rsbtnST06.Location = New System.Drawing.Point(443, 3)
        Me.rsbtnST06.Name = "rsbtnST06"
        Me.rsbtnST06.Size = New System.Drawing.Size(82, 26)
        Me.rsbtnST06.TabIndex = 5
        Me.rsbtnST06.Text = "ST6"
        Me.rsbtnST06.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.rsbtnST06.UseVisualStyleBackColor = True
        '
        'rsbtnST99
        '
        Me.rsbtnST99.Appearance = System.Windows.Forms.Appearance.Button
        Me.rsbtnST99.Cursor = System.Windows.Forms.Cursors.Hand
        Me.rsbtnST99.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.rsbtnST99.Font = New System.Drawing.Font("Meiryo UI", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.rsbtnST99.Location = New System.Drawing.Point(531, 3)
        Me.rsbtnST99.Name = "rsbtnST99"
        Me.rsbtnST99.Size = New System.Drawing.Size(82, 26)
        Me.rsbtnST99.TabIndex = 9
        Me.rsbtnST99.Text = "Closed"
        Me.rsbtnST99.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.rsbtnST99.UseVisualStyleBackColor = True
        '
        'InfoToolTip
        '
        Me.InfoToolTip.ToolTipIcon = System.Windows.Forms.ToolTipIcon.Info
        Me.InfoToolTip.ToolTipTitle = "参照元"
        '
        'Label3
        '
        Me.tlpFilter.SetColumnSpan(Me.Label3, 20)
        Me.Label3.Font = New System.Drawing.Font("Meiryo UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label3.Location = New System.Drawing.Point(3, 180)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(394, 30)
        Me.Label3.TabIndex = 93
        Me.Label3.Text = "変更処置のインプット文書番号等:"
        Me.Label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'TextBoxEx1
        '
        Me.tlpFilter.SetColumnSpan(Me.TextBoxEx1, 22)
        Me.TextBoxEx1.ImeMode = System.Windows.Forms.ImeMode.[On]
        Me.TextBoxEx1.InputRequired = False
        Me.TextBoxEx1.Location = New System.Drawing.Point(683, 93)
        Me.TextBoxEx1.MaxByteLength = 0
        Me.TextBoxEx1.Multiline = True
        Me.TextBoxEx1.Name = "TextBoxEx1"
        Me.tlpFilter.SetRowSpan(Me.TextBoxEx1, 5)
        Me.TextBoxEx1.SelectAllText = False
        Me.TextBoxEx1.Size = New System.Drawing.Size(434, 144)
        Me.TextBoxEx1.TabIndex = 216
        Me.TextBoxEx1.WatermarkColor = System.Drawing.Color.Empty
        Me.TextBoxEx1.WatermarkText = Nothing
        '
        'Label17
        '
        Me.tlpFilter.SetColumnSpan(Me.Label17, 20)
        Me.Label17.Font = New System.Drawing.Font("Meiryo UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label17.Location = New System.Drawing.Point(3, 210)
        Me.Label17.Name = "Label17"
        Me.Label17.Size = New System.Drawing.Size(394, 30)
        Me.Label17.TabIndex = 93
        Me.Label17.Text = "変更の適用S/No. 時期等（顧客等指示が無い場合はN/A、⑤変更審議へ）:"
        Me.Label17.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'PanelEx2
        '
        Me.PanelEx2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.PanelEx2.Controls.Add(Me.tlpFilter)
        Me.PanelEx2.HitEnabled = False
        Me.PanelEx2.Location = New System.Drawing.Point(12, 98)
        Me.PanelEx2.Name = "PanelEx2"
        Me.PanelEx2.Size = New System.Drawing.Size(1240, 101)
        Me.PanelEx2.TabIndex = 256
        '
        'tlpFilter
        '
        Me.tlpFilter.ColumnCount = 62
        Me.tlpFilter.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20.0!))
        Me.tlpFilter.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20.0!))
        Me.tlpFilter.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20.0!))
        Me.tlpFilter.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20.0!))
        Me.tlpFilter.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20.0!))
        Me.tlpFilter.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20.0!))
        Me.tlpFilter.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20.0!))
        Me.tlpFilter.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20.0!))
        Me.tlpFilter.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20.0!))
        Me.tlpFilter.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20.0!))
        Me.tlpFilter.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20.0!))
        Me.tlpFilter.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20.0!))
        Me.tlpFilter.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20.0!))
        Me.tlpFilter.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20.0!))
        Me.tlpFilter.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20.0!))
        Me.tlpFilter.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20.0!))
        Me.tlpFilter.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20.0!))
        Me.tlpFilter.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20.0!))
        Me.tlpFilter.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20.0!))
        Me.tlpFilter.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20.0!))
        Me.tlpFilter.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20.0!))
        Me.tlpFilter.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20.0!))
        Me.tlpFilter.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20.0!))
        Me.tlpFilter.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20.0!))
        Me.tlpFilter.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20.0!))
        Me.tlpFilter.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20.0!))
        Me.tlpFilter.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20.0!))
        Me.tlpFilter.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20.0!))
        Me.tlpFilter.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20.0!))
        Me.tlpFilter.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20.0!))
        Me.tlpFilter.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20.0!))
        Me.tlpFilter.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20.0!))
        Me.tlpFilter.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20.0!))
        Me.tlpFilter.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20.0!))
        Me.tlpFilter.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20.0!))
        Me.tlpFilter.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20.0!))
        Me.tlpFilter.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20.0!))
        Me.tlpFilter.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20.0!))
        Me.tlpFilter.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20.0!))
        Me.tlpFilter.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20.0!))
        Me.tlpFilter.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20.0!))
        Me.tlpFilter.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20.0!))
        Me.tlpFilter.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20.0!))
        Me.tlpFilter.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20.0!))
        Me.tlpFilter.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20.0!))
        Me.tlpFilter.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20.0!))
        Me.tlpFilter.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20.0!))
        Me.tlpFilter.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20.0!))
        Me.tlpFilter.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20.0!))
        Me.tlpFilter.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20.0!))
        Me.tlpFilter.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20.0!))
        Me.tlpFilter.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20.0!))
        Me.tlpFilter.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20.0!))
        Me.tlpFilter.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20.0!))
        Me.tlpFilter.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20.0!))
        Me.tlpFilter.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20.0!))
        Me.tlpFilter.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20.0!))
        Me.tlpFilter.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20.0!))
        Me.tlpFilter.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20.0!))
        Me.tlpFilter.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20.0!))
        Me.tlpFilter.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20.0!))
        Me.tlpFilter.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.tlpFilter.Controls.Add(Me.Label8, 0, 1)
        Me.tlpFilter.Controls.Add(Me.Label1, 0, 0)
        Me.tlpFilter.Controls.Add(Me.mtxHOKUKO_NO, 1, 1)
        Me.tlpFilter.Controls.Add(Me.dtDraft, 47, 1)
        Me.tlpFilter.Controls.Add(Me.Label16, 41, 1)
        Me.tlpFilter.Controls.Add(Me.ComboboxEx1, 33, 1)
        Me.tlpFilter.Controls.Add(Me.Label26, 28, 1)
        Me.tlpFilter.Controls.Add(Me.cmbBUMON, 15, 1)
        Me.tlpFilter.Controls.Add(Me.Label6, 20, 1)
        Me.tlpFilter.Controls.Add(Me.cmbKISO_TANTO, 25, 1)
        Me.tlpFilter.Controls.Add(Me.Label14, 0, 2)
        Me.tlpFilter.Controls.Add(Me.cmbKISYU, 5, 2)
        Me.tlpFilter.Controls.Add(Me.cmbBUHIN_BANGO, 5, 3)
        Me.tlpFilter.Controls.Add(Me.lblSYANAI_CD, 12, 3)
        Me.tlpFilter.Controls.Add(Me.cmbSYANAI_CD, 17, 3)
        Me.tlpFilter.Controls.Add(Me.Label4, 0, 3)
        Me.tlpFilter.Controls.Add(Me.Label17, 0, 7)
        Me.tlpFilter.Controls.Add(Me.Label3, 0, 6)
        Me.tlpFilter.Controls.Add(Me.MaskedTextBoxEx1, 20, 7)
        Me.tlpFilter.Controls.Add(Me.MaskedTextBoxEx2, 20, 6)
        Me.tlpFilter.Controls.Add(Me.Label7, 0, 4)
        Me.tlpFilter.Controls.Add(Me.cmbHINMEI, 5, 4)
        Me.tlpFilter.Controls.Add(Me.Label5, 12, 1)
        Me.tlpFilter.Controls.Add(Me.TextBoxEx1, 34, 3)
        Me.tlpFilter.Controls.Add(Me.Label18, 34, 2)
        Me.tlpFilter.Dock = System.Windows.Forms.DockStyle.Fill
        Me.tlpFilter.Location = New System.Drawing.Point(0, 0)
        Me.tlpFilter.Name = "tlpFilter"
        Me.tlpFilter.RowCount = 9
        Me.tlpFilter.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30.0!))
        Me.tlpFilter.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30.0!))
        Me.tlpFilter.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30.0!))
        Me.tlpFilter.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30.0!))
        Me.tlpFilter.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30.0!))
        Me.tlpFilter.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30.0!))
        Me.tlpFilter.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30.0!))
        Me.tlpFilter.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30.0!))
        Me.tlpFilter.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.tlpFilter.Size = New System.Drawing.Size(1236, 97)
        Me.tlpFilter.TabIndex = 327
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.BackColor = System.Drawing.Color.Wheat
        Me.tlpFilter.SetColumnSpan(Me.Label1, 5)
        Me.Label1.Font = New System.Drawing.Font("Meiryo UI", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label1.Location = New System.Drawing.Point(3, 3)
        Me.Label1.Margin = New System.Windows.Forms.Padding(3)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(86, 24)
        Me.Label1.TabIndex = 326
        Me.Label1.Text = "基本情報"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'MaskedTextBoxEx1
        '
        Me.MaskedTextBoxEx1.BackColor = System.Drawing.SystemColors.Control
        Me.tlpFilter.SetColumnSpan(Me.MaskedTextBoxEx1, 12)
        Me.MaskedTextBoxEx1.Font = New System.Drawing.Font("Meiryo UI", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.MaskedTextBoxEx1.ImeMode = System.Windows.Forms.ImeMode.[On]
        Me.MaskedTextBoxEx1.InputRequired = False
        Me.MaskedTextBoxEx1.Location = New System.Drawing.Point(403, 213)
        Me.MaskedTextBoxEx1.MaxByteLength = 0
        Me.MaskedTextBoxEx1.Name = "MaskedTextBoxEx1"
        Me.MaskedTextBoxEx1.ReadOnly = True
        Me.MaskedTextBoxEx1.SelectAllText = False
        Me.MaskedTextBoxEx1.Size = New System.Drawing.Size(234, 24)
        Me.MaskedTextBoxEx1.TabIndex = 266
        Me.MaskedTextBoxEx1.WatermarkColor = System.Drawing.Color.Empty
        Me.MaskedTextBoxEx1.WatermarkText = Nothing
        '
        'MaskedTextBoxEx2
        '
        Me.MaskedTextBoxEx2.BackColor = System.Drawing.SystemColors.Control
        Me.tlpFilter.SetColumnSpan(Me.MaskedTextBoxEx2, 12)
        Me.MaskedTextBoxEx2.Font = New System.Drawing.Font("Meiryo UI", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.MaskedTextBoxEx2.ImeMode = System.Windows.Forms.ImeMode.[On]
        Me.MaskedTextBoxEx2.InputRequired = False
        Me.MaskedTextBoxEx2.Location = New System.Drawing.Point(403, 183)
        Me.MaskedTextBoxEx2.MaxByteLength = 0
        Me.MaskedTextBoxEx2.Name = "MaskedTextBoxEx2"
        Me.MaskedTextBoxEx2.ReadOnly = True
        Me.MaskedTextBoxEx2.SelectAllText = False
        Me.MaskedTextBoxEx2.Size = New System.Drawing.Size(234, 24)
        Me.MaskedTextBoxEx2.TabIndex = 266
        Me.MaskedTextBoxEx2.WatermarkColor = System.Drawing.Color.Empty
        Me.MaskedTextBoxEx2.WatermarkText = Nothing
        '
        'Label18
        '
        Me.tlpFilter.SetColumnSpan(Me.Label18, 5)
        Me.Label18.Font = New System.Drawing.Font("Meiryo UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label18.Location = New System.Drawing.Point(683, 60)
        Me.Label18.Name = "Label18"
        Me.Label18.Size = New System.Drawing.Size(94, 30)
        Me.Label18.TabIndex = 281
        Me.Label18.Text = "変更内容:"
        Me.Label18.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'dtST05_UPD_YMD
        '
        Me.dtST05_UPD_YMD.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.dtST05_UPD_YMD.GotFocusedColor = System.Drawing.Color.FromArgb(CType(CType(190, Byte), Integer), CType(CType(180, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.dtST05_UPD_YMD.Location = New System.Drawing.Point(285, 61)
        Me.dtST05_UPD_YMD.MaxDate = New Date(9998, 12, 31, 0, 0, 0, 0)
        Me.dtST05_UPD_YMD.MinDate = New Date(1753, 1, 1, 0, 0, 0, 0)
        Me.dtST05_UPD_YMD.MinimumSize = New System.Drawing.Size(98, 24)
        Me.dtST05_UPD_YMD.Name = "dtST05_UPD_YMD"
        Me.dtST05_UPD_YMD.ReadOnly = False
        Me.dtST05_UPD_YMD.Size = New System.Drawing.Size(98, 24)
        Me.dtST05_UPD_YMD.TabIndex = 258
        Me.dtST05_UPD_YMD.Value = ""
        Me.dtST05_UPD_YMD.ValueNonFormat = ""
        '
        'cmbST05_DestTANTO
        '
        Me.cmbST05_DestTANTO.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cmbST05_DestTANTO.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cmbST05_DestTANTO.BackColor = System.Drawing.SystemColors.Window
        Me.cmbST05_DestTANTO.Cursor = System.Windows.Forms.Cursors.Default
        Me.cmbST05_DestTANTO.DisplayMember = "DISP"
        Me.cmbST05_DestTANTO.Font = New System.Drawing.Font("Meiryo UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.cmbST05_DestTANTO.ForeColor = System.Drawing.SystemColors.ControlText
        Me.cmbST05_DestTANTO.FormattingEnabled = True
        Me.cmbST05_DestTANTO.HorizontalContentAlignment = System.Drawing.StringAlignment.Near
        Me.cmbST05_DestTANTO.ImeMode = System.Windows.Forms.ImeMode.Disable
        Me.cmbST05_DestTANTO.IsSelected = False
        Me.cmbST05_DestTANTO.Location = New System.Drawing.Point(467, 65)
        Me.cmbST05_DestTANTO.Name = "cmbST05_DestTANTO"
        Me.cmbST05_DestTANTO.NullValue = " "
        Me.cmbST05_DestTANTO.Size = New System.Drawing.Size(154, 25)
        Me.cmbST05_DestTANTO.TabIndex = 257
        Me.cmbST05_DestTANTO.Text = "(選択)"
        Me.cmbST05_DestTANTO.ValueMember = "VALUE"
        '
        'Label48
        '
        Me.Label48.AutoSize = True
        Me.Label48.Font = New System.Drawing.Font("Meiryo UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label48.Location = New System.Drawing.Point(177, 66)
        Me.Label48.Margin = New System.Windows.Forms.Padding(3, 3, 3, 0)
        Me.Label48.Name = "Label48"
        Me.Label48.Size = New System.Drawing.Size(102, 15)
        Me.Label48.TabIndex = 259
        Me.Label48.Text = "承認・申請年月日:"
        Me.Label48.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label23
        '
        Me.Label23.AutoSize = True
        Me.Label23.Font = New System.Drawing.Font("Meiryo UI", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label23.Location = New System.Drawing.Point(389, 70)
        Me.Label23.Margin = New System.Windows.Forms.Padding(3, 3, 3, 0)
        Me.Label23.Name = "Label23"
        Me.Label23.Size = New System.Drawing.Size(72, 15)
        Me.Label23.TabIndex = 260
        Me.Label23.Text = "申請先社員:"
        Me.Label23.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label21
        '
        Me.Label21.AutoSize = True
        Me.Label21.Font = New System.Drawing.Font("Meiryo UI", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label21.Location = New System.Drawing.Point(829, 212)
        Me.Label21.Name = "Label21"
        Me.Label21.Size = New System.Drawing.Size(225, 15)
        Me.Label21.TabIndex = 318
        Me.Label21.Text = "いつから、いつまで(号機 or LOT or 日付)"
        Me.Label21.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label24
        '
        Me.Label24.AutoSize = True
        Me.Label24.Font = New System.Drawing.Font("Meiryo UI", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label24.Location = New System.Drawing.Point(722, 213)
        Me.Label24.Name = "Label24"
        Me.Label24.Size = New System.Drawing.Size(31, 15)
        Me.Label24.TabIndex = 319
        Me.Label24.Text = "数量"
        Me.Label24.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label20
        '
        Me.Label20.AutoSize = True
        Me.Label20.Font = New System.Drawing.Font("Meiryo UI", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label20.Location = New System.Drawing.Point(402, 212)
        Me.Label20.Name = "Label20"
        Me.Label20.Size = New System.Drawing.Size(55, 15)
        Me.Label20.TabIndex = 320
        Me.Label20.Text = "部品番号"
        Me.Label20.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label19
        '
        Me.Label19.AutoSize = True
        Me.Label19.Font = New System.Drawing.Font("Meiryo UI", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label19.Location = New System.Drawing.Point(262, 212)
        Me.Label19.Name = "Label19"
        Me.Label19.Size = New System.Drawing.Size(31, 15)
        Me.Label19.TabIndex = 321
        Me.Label19.Text = "機種"
        Me.Label19.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'FrmG0021_Detail
        '
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None
        Me.ClientSize = New System.Drawing.Size(1264, 861)
        Me.Controls.Add(Me.Label21)
        Me.Controls.Add(Me.Label24)
        Me.Controls.Add(Me.Label20)
        Me.Controls.Add(Me.Label19)
        Me.Controls.Add(Me.dtST05_UPD_YMD)
        Me.Controls.Add(Me.cmbST05_DestTANTO)
        Me.Controls.Add(Me.Label48)
        Me.Controls.Add(Me.Label23)
        Me.Controls.Add(Me.PanelEx2)
        Me.Controls.Add(Me.flpnlStageIndex)
        Me.Controls.Add(Me.TabSTAGE)
        Me.HelpButton = True
        Me.MinimumSize = New System.Drawing.Size(1280, 900)
        Me.Name = "FrmG0021_Detail"
        Me.ShowStatusBar = True
        Me.Text = ""
        Me.Controls.SetChildIndex(Me.TabSTAGE, 0)
        Me.Controls.SetChildIndex(Me.flpnlStageIndex, 0)
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
        Me.Controls.SetChildIndex(Me.PanelEx2, 0)
        Me.Controls.SetChildIndex(Me.lblRecordCount, 0)
        Me.Controls.SetChildIndex(Me.Label23, 0)
        Me.Controls.SetChildIndex(Me.Label48, 0)
        Me.Controls.SetChildIndex(Me.cmbST05_DestTANTO, 0)
        Me.Controls.SetChildIndex(Me.dtST05_UPD_YMD, 0)
        Me.Controls.SetChildIndex(Me.Label19, 0)
        Me.Controls.SetChildIndex(Me.Label20, 0)
        Me.Controls.SetChildIndex(Me.Label24, 0)
        Me.Controls.SetChildIndex(Me.Label21, 0)
        CType(Me.ErrorProvider, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.WarningErrorProvider, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.D005CARJBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        Me.TabSTAGE.ResumeLayout(False)
        Me.tabSTAGE01.ResumeLayout(False)
        Me.tabSTAGE01.PerformLayout()
        Me.PnlPROCESS.ResumeLayout(False)
        Me.PnlPROCESS.PerformLayout()
        Me.pnlFOLLOW_PROCESS_OUTFLOW_FILEPATH.ResumeLayout(False)
        Me.pnlFOLLOW_PROCESS_OUTFLOW_FILEPATH.PerformLayout()
        Me.fpnlFOLLOW_PROCESS_OUTFLOW_FILEPATH.ResumeLayout(False)
        Me.fpnlFOLLOW_PROCESS_OUTFLOW_FILEPATH.PerformLayout()
        Me.pnlOTHER_PROCESS_INFLUENCE_FILEPATH.ResumeLayout(False)
        Me.pnlOTHER_PROCESS_INFLUENCE_FILEPATH.PerformLayout()
        Me.fpnlOTHER_PROCESS_INFLUENCE_FILEPATH.ResumeLayout(False)
        Me.fpnlOTHER_PROCESS_INFLUENCE_FILEPATH.PerformLayout()
        Me.PanelEx5.ResumeLayout(False)
        Me.PanelEx5.PerformLayout()
        Me.PanelEx4.ResumeLayout(False)
        Me.PanelEx4.PerformLayout()
        Me.pnlSYOCHI_JISSI.ResumeLayout(False)
        Me.pnlSYOCHI_JISSI.PerformLayout()
        Me.pnlSYOCHI_FILEPATH.ResumeLayout(False)
        Me.pnlSYOCHI_FILEPATH.PerformLayout()
        Me.fpnlSYOCHI_FILEPATH.ResumeLayout(False)
        Me.fpnlSYOCHI_FILEPATH.PerformLayout()
        Me.pnlFCR.ResumeLayout(False)
        Me.pnlFCR.PerformLayout()
        Me.pnlKOKYAKU_EIKYO_HANTEI_FILEPATH.ResumeLayout(False)
        Me.pnlKOKYAKU_EIKYO_HANTEI_FILEPATH.PerformLayout()
        Me.fpnlKOKYAKU_EIKYO_HANTEI_FILEPATH.ResumeLayout(False)
        Me.fpnlKOKYAKU_EIKYO_HANTEI_FILEPATH.PerformLayout()
        Me.pnlrbtnTUCHI.ResumeLayout(False)
        Me.pnlrbtnTUCHI.PerformLayout()
        Me.PanelEx1.ResumeLayout(False)
        Me.PanelEx1.PerformLayout()
        Me.pnlZESEI_SYOCHI.ResumeLayout(False)
        Me.pnlZESEI_SYOCHI.PerformLayout()
        Me.pnlSYOCHI_KIROKU.ResumeLayout(False)
        Me.flpnlStageIndex.ResumeLayout(False)
        Me.PanelEx2.ResumeLayout(False)
        Me.tlpFilter.ResumeLayout(False)
        Me.tlpFilter.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents D005CARJBindingSource As BindingSource
    Friend WithEvents TabSTAGE As TabControl
    Friend WithEvents tabSTAGE01 As TabPageEx
    Friend WithEvents mtxFUTEKIGO_KB As MaskedTextBoxEx
    Friend WithEvents mtxFUTEKIGO_S_KB As MaskedTextBoxEx
    Friend WithEvents Label9 As Label
    Friend WithEvents cmbST01_DestTANTO As ComboboxEx
    Friend WithEvents mtxST01_NextStageName As MaskedTextBoxEx
    Friend WithEvents Label123 As Label
    Friend WithEvents Label124 As Label
    Friend WithEvents Label139 As Label
    Friend WithEvents mtxST01_UPD_YMD As MaskedTextBoxEx
    Friend WithEvents lblSETUMON_1 As Label
    Friend WithEvents Label10 As Label
    Friend WithEvents dtTUCHI_YMD As DateTextBoxEx
    Friend WithEvents lblKAKUNIN_SYUDAN As Label
    Friend WithEvents txtKAKUNIN_SYUDAN As TextBoxEx
    Friend WithEvents lblKOKYAKU_EIKYO_NAIYO As Label
    Friend WithEvents txtKOKYAKU_EIKYO_NAIYO As TextBoxEx
    Friend WithEvents lblKOKYAKU_EIKYO_HANTEI_COMMENT As Label
    Friend WithEvents txtTUCHI_SYUDAN As TextBoxEx
    Friend WithEvents rbtnKOKYAKU_EIKYO_HANTEI_KB_T As RadioButton
    Friend WithEvents rbtnKOKYAKU_EIKYO_HANTEI_KB_F As RadioButton
    Friend WithEvents pnlSYOCHI_KIROKU As PanelEx
    Friend WithEvents lblSTAGE10 As Label
    Friend WithEvents pnlZESEI_SYOCHI As PanelEx
    Friend WithEvents lblSTAGE08 As Label
    Friend WithEvents flpnlStageIndex As FlowLayoutPanel
    Friend WithEvents rsbtnST01 As RibbonShapeRadioButton
    Friend WithEvents rsbtnST02 As RibbonShapeRadioButton
    Friend WithEvents rsbtnST03 As RibbonShapeRadioButton
    Friend WithEvents rsbtnST04 As RibbonShapeRadioButton
    Friend WithEvents rsbtnST05 As RibbonShapeRadioButton
    Friend WithEvents rsbtnST06 As RibbonShapeRadioButton
    Friend WithEvents rsbtnST99 As RibbonShapeRadioButton
    Friend WithEvents lblZESEI_SYOCHIFlame As Label
    Friend WithEvents lblSYOCHI_KIROKUFlame As Label
    Friend WithEvents pnlFCR As PanelEx
    Friend WithEvents lblCARFlame As Label
    Friend WithEvents pnlSYOCHI_JISSI As PanelEx
    Friend WithEvents lblSTAGE16 As Label
    Friend WithEvents lblSTAGEFlame13 As Label
    Friend WithEvents PanelEx1 As PanelEx
    Friend WithEvents Label2 As Label
    Friend WithEvents cmbKOKYAKU_EIKYO_HANTEI_COMMENT As ComboboxEx
    Friend WithEvents lblTUCHI_SYUDAN As Label
    Friend WithEvents lblHITUYO_TETUDUKI_ZIKO As Label
    Friend WithEvents lblTUCHI_YMD As Label
    Friend WithEvents pnlrbtnTUCHI As PanelEx
    Friend WithEvents rbtnKOKYAKU_EIKYO_TUCHI_HANTEI_KB_F As RadioButton
    Friend WithEvents rbtnKOKYAKU_EIKYO_TUCHI_HANTEI_KB_T As RadioButton
    Friend WithEvents lblKOKYAKU_EIKYO_TUCHI_HANTEI_KB As Label
    Friend WithEvents txtHITUYO_TETUDUKI_ZIKO As TextBoxEx
    Friend WithEvents lblKOKYAKU_EIKYO_ETC_COMMENT As Label
    Friend WithEvents txtKOKYAKU_EIKYO_ETC_COMMENT As TextBoxEx
    Friend WithEvents PnlPROCESS As PanelEx
    Friend WithEvents Label13 As Label
    Friend WithEvents Label15 As Label
    Friend WithEvents PanelEx4 As PanelEx
    Friend WithEvents rbtnOTHER_PROCESS_INFLUENCE_KB_F As RadioButton
    Friend WithEvents rbtnOTHER_PROCESS_INFLUENCE_KB_T As RadioButton
    Friend WithEvents Label11 As Label
    Friend WithEvents PanelEx5 As PanelEx
    Friend WithEvents rbtnFOLLOW_PROCESS_OUTFLOW_KB_F As RadioButton
    Friend WithEvents rbtnFOLLOW_PROCESS_OUTFLOW_KB_T As RadioButton
    Friend WithEvents Label12 As Label
    Friend WithEvents Label38 As Label
    Friend WithEvents txtKOKYAKU_NOUNYU_NAIYOU As TextBoxEx
    Friend WithEvents dtKOKYAKU_NOUNYU_YMD As DateTextBoxEx
    Friend WithEvents Label42 As Label
    Friend WithEvents Label41 As Label
    Friend WithEvents lblOTHER_PROCESS_NAIYOU As Label
    Friend WithEvents txtOTHER_PROCESS_NAIYOU As TextBoxEx
    Friend WithEvents dtOTHER_PROCESS_YMD As DateTextBoxEx
    Friend WithEvents Label39 As Label
    Friend WithEvents txtZAIKO_SIKAKE_NAIYOU As TextBoxEx
    Friend WithEvents dtZAIKO_SIKAKE_YMD As DateTextBoxEx
    Friend WithEvents lblTAISYO_KOKYAKU As Label
    Friend WithEvents txtTAISYO_KOKYAKU As TextBoxEx
    Friend WithEvents fpnlOTHER_PROCESS_INFLUENCE_FILEPATH As FlowLayoutPanel
    Friend WithEvents lblOTHER_PROCESS_INFLUENCE_FILEPATH As LinkLabel
    Friend WithEvents lblOTHER_PROCESS_INFLUENCE_FILEPATH_Clear As LinkLabel
    Friend WithEvents LinkLabel11 As LinkLabel
    Friend WithEvents LinkLabel12 As LinkLabel
    Friend WithEvents LinkLabel13 As LinkLabel
    Friend WithEvents LinkLabel14 As LinkLabel
    Friend WithEvents LinkLabel15 As LinkLabel
    Friend WithEvents LinkLabel16 As LinkLabel
    Friend WithEvents LinkLabel17 As LinkLabel
    Friend WithEvents LinkLabel18 As LinkLabel
    Friend WithEvents btnOpenOTHER_PROCESS_INFLUENCE_FILEPATH As Button
    Friend WithEvents Label30 As Label
    Friend WithEvents txtOTHER_PROCESS_INFLUENCE_MEMO As TextBoxEx
    Friend WithEvents txtFOLLOW_PROCESS_OUTFLOW_MEMO As TextBoxEx
    Friend WithEvents pnlOTHER_PROCESS_INFLUENCE_FILEPATH As PanelEx
    Friend WithEvents pnlFOLLOW_PROCESS_OUTFLOW_FILEPATH As PanelEx
    Friend WithEvents Label36 As Label
    Friend WithEvents btnOpenFOLLOW_PROCESS_OUTFLOW_FILEPATH As Button
    Friend WithEvents fpnlFOLLOW_PROCESS_OUTFLOW_FILEPATH As FlowLayoutPanel
    Friend WithEvents lblFOLLOW_PROCESS_OUTFLOW_FILEPATH As LinkLabel
    Friend WithEvents lblFOLLOW_PROCESS_OUTFLOW_FILEPATH_Clear As LinkLabel
    Friend WithEvents LinkLabel9 As LinkLabel
    Friend WithEvents LinkLabel10 As LinkLabel
    Friend WithEvents LinkLabel19 As LinkLabel
    Friend WithEvents LinkLabel20 As LinkLabel
    Friend WithEvents LinkLabel31 As LinkLabel
    Friend WithEvents LinkLabel32 As LinkLabel
    Friend WithEvents LinkLabel33 As LinkLabel
    Friend WithEvents LinkLabel34 As LinkLabel
    Friend WithEvents pnlKOKYAKU_EIKYO_HANTEI_FILEPATH As PanelEx
    Friend WithEvents Label37 As Label
    Friend WithEvents btnOpenKOKYAKU_EIKYO_HANTEI_FILEPATH As Button
    Friend WithEvents fpnlKOKYAKU_EIKYO_HANTEI_FILEPATH As FlowLayoutPanel
    Friend WithEvents lblKOKYAKU_EIKYO_HANTEI_FILEPATH As LinkLabel
    Friend WithEvents lblKOKYAKU_EIKYO_HANTEI_FILEPATH_Clear As LinkLabel
    Friend WithEvents LinkLabel3 As LinkLabel
    Friend WithEvents LinkLabel4 As LinkLabel
    Friend WithEvents LinkLabel5 As LinkLabel
    Friend WithEvents LinkLabel6 As LinkLabel
    Friend WithEvents LinkLabel7 As LinkLabel
    Friend WithEvents LinkLabel8 As LinkLabel
    Friend WithEvents LinkLabel29 As LinkLabel
    Friend WithEvents LinkLabel30 As LinkLabel
    Friend WithEvents txtSYOCHI_MEMO As TextBoxEx
    Friend WithEvents pnlSYOCHI_FILEPATH As PanelEx
    Friend WithEvents Label44 As Label
    Friend WithEvents btnOpenSYOCHI_FILEPATH As Button
    Friend WithEvents fpnlSYOCHI_FILEPATH As FlowLayoutPanel
    Friend WithEvents lblSYOCHI_FILEPATH As LinkLabel
    Friend WithEvents lblSYOCHI_FILEPATH_Clear As LinkLabel
    Friend WithEvents LinkLabel21 As LinkLabel
    Friend WithEvents LinkLabel22 As LinkLabel
    Friend WithEvents LinkLabel23 As LinkLabel
    Friend WithEvents LinkLabel24 As LinkLabel
    Friend WithEvents LinkLabel25 As LinkLabel
    Friend WithEvents LinkLabel26 As LinkLabel
    Friend WithEvents LinkLabel27 As LinkLabel
    Friend WithEvents LinkLabel28 As LinkLabel
    Friend WithEvents InfoToolTip As ToolTip
    Friend WithEvents Label3 As Label
    Friend WithEvents TextBoxEx1 As TextBoxEx
    Friend WithEvents Label17 As Label
    Friend WithEvents cmbBUHIN_BANGO As ComboboxEx
    Friend WithEvents cmbKISYU As ComboboxEx
    Friend WithEvents Label8 As Label
    Friend WithEvents mtxHOKUKO_NO As MaskedTextBoxEx
    Friend WithEvents Label14 As Label
    Friend WithEvents Label4 As Label
    Friend WithEvents cmbBUMON As ComboboxEx
    Friend WithEvents Label5 As Label
    Friend WithEvents Label7 As Label
    Friend WithEvents cmbHINMEI As ComboboxEx
    Friend WithEvents Label6 As Label
    Friend WithEvents cmbKISO_TANTO As ComboboxEx
    Friend WithEvents Label26 As Label
    Friend WithEvents ComboboxEx1 As ComboboxEx
    Friend WithEvents lblSYANAI_CD As Label
    Friend WithEvents cmbSYANAI_CD As ComboboxEx
    Friend WithEvents Label16 As Label
    Friend WithEvents dtDraft As DateTextBoxEx
    Friend WithEvents PanelEx2 As PanelEx
    Friend WithEvents Label1 As Label
    Friend WithEvents tlpFilter As TableLayoutPanel
    Friend WithEvents MaskedTextBoxEx2 As MaskedTextBoxEx
    Friend WithEvents MaskedTextBoxEx1 As MaskedTextBoxEx
    Friend WithEvents Label18 As Label
    Friend WithEvents dtST05_UPD_YMD As DateTextBoxEx
    Friend WithEvents cmbST05_DestTANTO As ComboboxEx
    Friend WithEvents Label48 As Label
    Friend WithEvents Label23 As Label
    Friend WithEvents Label21 As Label
    Friend WithEvents Label24 As Label
    Friend WithEvents Label20 As Label
    Friend WithEvents Label19 As Label
End Class
