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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmG0021_Detail))
        Me.cmbBUHIN_BANGO = New JMS_COMMON.ComboboxEx()
        Me.cmbKISYU = New JMS_COMMON.ComboboxEx()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.mtxFCCB_NO = New JMS_COMMON.MaskedTextBoxEx()
        Me.Label14 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.cmbBUMON = New JMS_COMMON.ComboboxEx()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.cmbHINMEI = New JMS_COMMON.ComboboxEx()
        Me.lblKISO_TANTO = New System.Windows.Forms.Label()
        Me.cmbKISO_TANTO = New JMS_COMMON.ComboboxEx()
        Me.lblCM_TANTO = New System.Windows.Forms.Label()
        Me.cmbCM_TANTO = New JMS_COMMON.ComboboxEx()
        Me.lblSYANAI_CD = New System.Windows.Forms.Label()
        Me.cmbSYANAI_CD = New JMS_COMMON.ComboboxEx()
        Me.Label16 = New System.Windows.Forms.Label()
        Me.dtKISO = New JMS_COMMON.DateTextBoxEx()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.InfoToolTip = New System.Windows.Forms.ToolTip(Me.components)
        Me.Label3 = New System.Windows.Forms.Label()
        Me.txtINPUT_NAIYO = New JMS_COMMON.TextBoxEx()
        Me.Label17 = New System.Windows.Forms.Label()
        Me.PanelEx2 = New JMS_COMMON.PanelEx()
        Me.tlpFilter = New System.Windows.Forms.TableLayoutPanel()
        Me.Label18 = New System.Windows.Forms.Label()
        Me.mtxINPUT_DOC_NO = New JMS_COMMON.MaskedTextBoxEx()
        Me.mtxSNO_APPLY_PERIOD_KISO = New JMS_COMMON.MaskedTextBoxEx()
        Me.flpnlStageIndex = New System.Windows.Forms.FlowLayoutPanel()
        Me.rsbtnST01 = New JMS_COMMON.RibbonShapeRadioButton()
        Me.rsbtnST02 = New JMS_COMMON.RibbonShapeRadioButton()
        Me.rsbtnST03 = New JMS_COMMON.RibbonShapeRadioButton()
        Me.rsbtnST04 = New JMS_COMMON.RibbonShapeRadioButton()
        Me.rsbtnST05 = New JMS_COMMON.RibbonShapeRadioButton()
        Me.rsbtnST06 = New JMS_COMMON.RibbonShapeRadioButton()
        Me.rsbtnST99 = New JMS_COMMON.RibbonShapeRadioButton()
        Me.lblDestTanto = New System.Windows.Forms.Label()
        Me.Label48 = New System.Windows.Forms.Label()
        Me.cmbDestTANTO = New JMS_COMMON.ComboboxEx()
        Me.dtUPD_YMD = New JMS_COMMON.DateTextBoxEx()
        Me.TabControl1 = New System.Windows.Forms.TabControl()
        Me.TabPageEx1 = New JMS_COMMON.TabPageEx()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.C1SplitContainer = New C1.Win.C1SplitContainer.C1SplitContainer()
        Me.C1SplitterPanel1 = New C1.Win.C1SplitContainer.C1SplitterPanel()
        Me.flxDATA_2 = New C1.Win.C1FlexGrid.C1FlexGrid()
        Me.Flx2_DS = New System.Windows.Forms.BindingSource(Me.components)
        Me.C1SplitterPanel2 = New C1.Win.C1SplitContainer.C1SplitterPanel()
        Me.flxDATA_3 = New C1.Win.C1FlexGrid.C1FlexGrid()
        Me.Flx3_DS = New System.Windows.Forms.BindingSource(Me.components)
        Me.C1SplitterPanel3 = New C1.Win.C1SplitContainer.C1SplitterPanel()
        Me.flxDATA_4 = New C1.Win.C1FlexGrid.C1FlexGrid()
        Me.Flx4_DS = New System.Windows.Forms.BindingSource(Me.components)
        Me.C1SplitterPanel4 = New C1.Win.C1SplitContainer.C1SplitterPanel()
        Me.TableLayoutPanel1 = New System.Windows.Forms.TableLayoutPanel()
        Me.cmbSYOCHI_GM_TANTO = New JMS_COMMON.ComboboxEx()
        Me.Label29 = New System.Windows.Forms.Label()
        Me.Label28 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label19 = New System.Windows.Forms.Label()
        Me.Label20 = New System.Windows.Forms.Label()
        Me.Label21 = New System.Windows.Forms.Label()
        Me.Label22 = New System.Windows.Forms.Label()
        Me.Label23 = New System.Windows.Forms.Label()
        Me.Label24 = New System.Windows.Forms.Label()
        Me.Label25 = New System.Windows.Forms.Label()
        Me.Label27 = New System.Windows.Forms.Label()
        Me.Label32 = New System.Windows.Forms.Label()
        Me.Label31 = New System.Windows.Forms.Label()
        Me.Label30 = New System.Windows.Forms.Label()
        Me.cmbSYOCHI_SEKKEI_TANTO = New JMS_COMMON.ComboboxEx()
        Me.cmbSYOCHI_SEIGI_TANTO = New JMS_COMMON.ComboboxEx()
        Me.cmbSYOCHI_EIGYO_TANTO = New JMS_COMMON.ComboboxEx()
        Me.cmbSYOCHI_KANRI_TANTO = New JMS_COMMON.ComboboxEx()
        Me.dtSYOCHI_GM_TANTO = New JMS_COMMON.DateTextBoxEx()
        Me.cmbSYOCHI_SEIZO_TANTO = New JMS_COMMON.ComboboxEx()
        Me.cmbSYOCHI_HINSYO_TANTO = New JMS_COMMON.ComboboxEx()
        Me.cmbSYOCHI_KENSA_TANTO = New JMS_COMMON.ComboboxEx()
        Me.cmbSYOCHI_KOBAI_TANTO = New JMS_COMMON.ComboboxEx()
        Me.cmbKAKUNIN_GM_TANTO = New JMS_COMMON.ComboboxEx()
        Me.cmbKAKUNIN_CM_TANTO = New JMS_COMMON.ComboboxEx()
        Me.dtSYOCHI_SEKKEI_TANTO = New JMS_COMMON.DateTextBoxEx()
        Me.dtSYOCHI_SEIGI_TANTO = New JMS_COMMON.DateTextBoxEx()
        Me.dtSYOCHI_EIGYO_TANTO = New JMS_COMMON.DateTextBoxEx()
        Me.dtSYOCHI_KANRI_TANTO = New JMS_COMMON.DateTextBoxEx()
        Me.dtSYOCHI_SEIZO_TANTO = New JMS_COMMON.DateTextBoxEx()
        Me.dtSYOCHI_HINSYO_TANTO = New JMS_COMMON.DateTextBoxEx()
        Me.dtSYOCHI_KENSA_TANTO = New JMS_COMMON.DateTextBoxEx()
        Me.dtSYOCHI_KOBAI_TANTO = New JMS_COMMON.DateTextBoxEx()
        Me.dtKAKUNIN_GM_TANTO = New JMS_COMMON.DateTextBoxEx()
        Me.dtKAKUNIN_CM_TANTO = New JMS_COMMON.DateTextBoxEx()
        Me.PanelEx1 = New JMS_COMMON.PanelEx()
        Me.Label15 = New System.Windows.Forms.Label()
        Me.flxDATA_5 = New C1.Win.C1FlexGrid.C1FlexGrid()
        Me.mtxSNO_APPLY_PERIOD_HENKO_SINGI = New JMS_COMMON.MaskedTextBoxEx()
        Me.C1SplitterPanel5 = New C1.Win.C1SplitContainer.C1SplitterPanel()
        CType(Me.ErrorProvider, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.WarningErrorProvider, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.PanelEx2.SuspendLayout()
        Me.tlpFilter.SuspendLayout()
        Me.flpnlStageIndex.SuspendLayout()
        Me.TabControl1.SuspendLayout()
        Me.TabPageEx1.SuspendLayout()
        CType(Me.C1SplitContainer, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.C1SplitContainer.SuspendLayout()
        Me.C1SplitterPanel1.SuspendLayout()
        CType(Me.flxDATA_2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Flx2_DS, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.C1SplitterPanel2.SuspendLayout()
        CType(Me.flxDATA_3, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Flx3_DS, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.C1SplitterPanel3.SuspendLayout()
        CType(Me.flxDATA_4, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Flx4_DS, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.C1SplitterPanel4.SuspendLayout()
        Me.TableLayoutPanel1.SuspendLayout()
        Me.PanelEx1.SuspendLayout()
        CType(Me.flxDATA_5, System.ComponentModel.ISupportInitialize).BeginInit()
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
        Me.cmdFunc1.Location = New System.Drawing.Point(9, 641)
        Me.cmdFunc1.Size = New System.Drawing.Size(156, 42)
        Me.cmdFunc1.Text = "保存(F1)"
        '
        'cmdFunc2
        '
        Me.cmdFunc2.Image = Global.FMS.My.Resources.Resources.申請
        Me.cmdFunc2.Location = New System.Drawing.Point(191, 641)
        Me.cmdFunc2.Size = New System.Drawing.Size(156, 42)
        Me.cmdFunc2.Text = "承認&&申請(F2)"
        '
        'cmdFunc3
        '
        Me.cmdFunc3.Location = New System.Drawing.Point(10, 10)
        Me.cmdFunc3.Size = New System.Drawing.Size(10, 42)
        '
        'cmdFunc4
        '
        Me.cmdFunc4.Image = Global.FMS.My.Resources.Resources._imgRight32x32
        Me.cmdFunc4.Location = New System.Drawing.Point(373, 641)
        Me.cmdFunc4.Size = New System.Drawing.Size(156, 42)
        Me.cmdFunc4.Text = "転送(F4)"
        '
        'cmdFunc5
        '
        Me.cmdFunc5.Image = Global.FMS.My.Resources.Resources._imgUndo32x32
        Me.cmdFunc5.Location = New System.Drawing.Point(555, 641)
        Me.cmdFunc5.Size = New System.Drawing.Size(156, 42)
        Me.cmdFunc5.Text = "差戻し(F5)"
        '
        'cmdFunc6
        '
        Me.cmdFunc6.Location = New System.Drawing.Point(10, 10)
        Me.cmdFunc6.Size = New System.Drawing.Size(10, 42)
        '
        'cmdFunc12
        '
        Me.cmdFunc12.Image = Global.FMS.My.Resources.Resources._imgLog_Out32x32
        Me.cmdFunc12.Location = New System.Drawing.Point(1101, 641)
        Me.cmdFunc12.Size = New System.Drawing.Size(156, 42)
        Me.cmdFunc12.Text = "閉じる(F12)"
        '
        'cmdFunc11
        '
        Me.cmdFunc11.Image = Global.FMS.My.Resources.Resources.履歴
        Me.cmdFunc11.Location = New System.Drawing.Point(919, 641)
        Me.cmdFunc11.Size = New System.Drawing.Size(156, 42)
        Me.cmdFunc11.Text = "履歴表示(F11)"
        Me.cmdFunc11.Visible = False
        '
        'cmdFunc10
        '
        Me.cmdFunc10.Image = Global.FMS.My.Resources.Resources._imgPrint32x32
        Me.cmdFunc10.Location = New System.Drawing.Point(737, 641)
        Me.cmdFunc10.Size = New System.Drawing.Size(156, 42)
        Me.cmdFunc10.Text = "印刷プレビュー(F10)"
        Me.cmdFunc10.Visible = False
        '
        'cmdFunc7
        '
        Me.cmdFunc7.Location = New System.Drawing.Point(10, 10)
        Me.cmdFunc7.Size = New System.Drawing.Size(10, 42)
        '
        'cmdFunc9
        '
        Me.cmdFunc9.Location = New System.Drawing.Point(10, 10)
        Me.cmdFunc9.Size = New System.Drawing.Size(10, 42)
        '
        'cmdFunc8
        '
        Me.cmdFunc8.Location = New System.Drawing.Point(10, 10)
        Me.cmdFunc8.Size = New System.Drawing.Size(10, 42)
        '
        'lblTytle
        '
        Me.lblTytle.Font = New System.Drawing.Font("Meiryo UI", 24.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTytle.ForeColor = System.Drawing.SystemColors.ControlText
        Me.lblTytle.Size = New System.Drawing.Size(1238, 43)
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
        Me.cmbBUHIN_BANGO.Location = New System.Drawing.Point(103, 63)
        Me.cmbBUHIN_BANGO.Name = "cmbBUHIN_BANGO"
        Me.cmbBUHIN_BANGO.NullValue = " "
        Me.cmbBUHIN_BANGO.Size = New System.Drawing.Size(134, 25)
        Me.cmbBUHIN_BANGO.TabIndex = 6
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
        Me.cmbKISYU.Location = New System.Drawing.Point(103, 33)
        Me.cmbKISYU.Name = "cmbKISYU"
        Me.cmbKISYU.NullValue = " "
        Me.cmbKISYU.Size = New System.Drawing.Size(134, 25)
        Me.cmbKISYU.TabIndex = 3
        Me.cmbKISYU.Text = "(選択)"
        Me.cmbKISYU.ValueMember = "VALUE"
        '
        'Label8
        '
        Me.tlpFilter.SetColumnSpan(Me.Label8, 5)
        Me.Label8.Font = New System.Drawing.Font("Meiryo UI", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label8.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label8.Location = New System.Drawing.Point(3, 0)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(94, 30)
        Me.Label8.TabIndex = 267
        Me.Label8.Text = "FCCB No:"
        Me.Label8.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'mtxFCCB_NO
        '
        Me.mtxFCCB_NO.BackColor = System.Drawing.SystemColors.Control
        Me.tlpFilter.SetColumnSpan(Me.mtxFCCB_NO, 5)
        Me.mtxFCCB_NO.Font = New System.Drawing.Font("Meiryo UI", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.mtxFCCB_NO.ImeMode = System.Windows.Forms.ImeMode.Disable
        Me.mtxFCCB_NO.InputRequired = False
        Me.mtxFCCB_NO.Location = New System.Drawing.Point(103, 3)
        Me.mtxFCCB_NO.MaxByteLength = 0
        Me.mtxFCCB_NO.Name = "mtxFCCB_NO"
        Me.mtxFCCB_NO.ReadOnly = True
        Me.mtxFCCB_NO.SelectAllText = False
        Me.mtxFCCB_NO.Size = New System.Drawing.Size(94, 24)
        Me.mtxFCCB_NO.TabIndex = 0
        Me.mtxFCCB_NO.TabStop = False
        Me.mtxFCCB_NO.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.mtxFCCB_NO.WatermarkColor = System.Drawing.Color.Empty
        Me.mtxFCCB_NO.WatermarkText = Nothing
        '
        'Label14
        '
        Me.tlpFilter.SetColumnSpan(Me.Label14, 5)
        Me.Label14.Font = New System.Drawing.Font("Meiryo UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label14.Location = New System.Drawing.Point(3, 30)
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
        Me.Label4.Location = New System.Drawing.Point(3, 60)
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
        Me.cmbBUMON.Location = New System.Drawing.Point(343, 3)
        Me.cmbBUMON.Name = "cmbBUMON"
        Me.cmbBUMON.NullValue = " "
        Me.cmbBUMON.Size = New System.Drawing.Size(94, 25)
        Me.cmbBUMON.TabIndex = 1
        Me.cmbBUMON.Text = "(選択)"
        Me.cmbBUMON.ValueMember = "VALUE"
        '
        'Label5
        '
        Me.tlpFilter.SetColumnSpan(Me.Label5, 5)
        Me.Label5.Font = New System.Drawing.Font("Meiryo UI", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label5.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label5.Location = New System.Drawing.Point(243, 0)
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
        Me.Label7.Location = New System.Drawing.Point(3, 90)
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
        Me.cmbHINMEI.Location = New System.Drawing.Point(103, 93)
        Me.cmbHINMEI.Name = "cmbHINMEI"
        Me.cmbHINMEI.NullValue = " "
        Me.cmbHINMEI.Size = New System.Drawing.Size(374, 25)
        Me.cmbHINMEI.TabIndex = 8
        Me.cmbHINMEI.Text = "(選択)"
        Me.cmbHINMEI.ValueMember = "VALUE"
        '
        'lblKISO_TANTO
        '
        Me.tlpFilter.SetColumnSpan(Me.lblKISO_TANTO, 5)
        Me.lblKISO_TANTO.Font = New System.Drawing.Font("Meiryo UI", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.lblKISO_TANTO.ForeColor = System.Drawing.SystemColors.ControlText
        Me.lblKISO_TANTO.Location = New System.Drawing.Point(443, 0)
        Me.lblKISO_TANTO.Name = "lblKISO_TANTO"
        Me.lblKISO_TANTO.Size = New System.Drawing.Size(94, 30)
        Me.lblKISO_TANTO.TabIndex = 270
        Me.lblKISO_TANTO.Text = "起草者:"
        Me.lblKISO_TANTO.TextAlign = System.Drawing.ContentAlignment.MiddleRight
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
        Me.cmbKISO_TANTO.ImeMode = System.Windows.Forms.ImeMode.[On]
        Me.cmbKISO_TANTO.IsSelected = False
        Me.cmbKISO_TANTO.Location = New System.Drawing.Point(543, 3)
        Me.cmbKISO_TANTO.Name = "cmbKISO_TANTO"
        Me.cmbKISO_TANTO.NullValue = " "
        Me.cmbKISO_TANTO.Size = New System.Drawing.Size(134, 25)
        Me.cmbKISO_TANTO.TabIndex = 2
        Me.cmbKISO_TANTO.Text = "(選択)"
        Me.cmbKISO_TANTO.ValueMember = "VALUE"
        '
        'lblCM_TANTO
        '
        Me.tlpFilter.SetColumnSpan(Me.lblCM_TANTO, 5)
        Me.lblCM_TANTO.Font = New System.Drawing.Font("Meiryo UI", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.lblCM_TANTO.ForeColor = System.Drawing.SystemColors.ControlText
        Me.lblCM_TANTO.Location = New System.Drawing.Point(443, 30)
        Me.lblCM_TANTO.Name = "lblCM_TANTO"
        Me.lblCM_TANTO.Size = New System.Drawing.Size(94, 30)
        Me.lblCM_TANTO.TabIndex = 269
        Me.lblCM_TANTO.Text = "FCCB議長:"
        Me.lblCM_TANTO.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'cmbCM_TANTO
        '
        Me.cmbCM_TANTO.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cmbCM_TANTO.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cmbCM_TANTO.BackColor = System.Drawing.SystemColors.Window
        Me.tlpFilter.SetColumnSpan(Me.cmbCM_TANTO, 7)
        Me.cmbCM_TANTO.Cursor = System.Windows.Forms.Cursors.Default
        Me.cmbCM_TANTO.DisplayMember = "DISP"
        Me.cmbCM_TANTO.Font = New System.Drawing.Font("Meiryo UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.cmbCM_TANTO.ForeColor = System.Drawing.SystemColors.ControlText
        Me.cmbCM_TANTO.FormattingEnabled = True
        Me.cmbCM_TANTO.HorizontalContentAlignment = System.Drawing.StringAlignment.Near
        Me.cmbCM_TANTO.ImeMode = System.Windows.Forms.ImeMode.[On]
        Me.cmbCM_TANTO.IsSelected = False
        Me.cmbCM_TANTO.Location = New System.Drawing.Point(543, 33)
        Me.cmbCM_TANTO.Name = "cmbCM_TANTO"
        Me.cmbCM_TANTO.NullValue = " "
        Me.cmbCM_TANTO.Size = New System.Drawing.Size(134, 25)
        Me.cmbCM_TANTO.TabIndex = 5
        Me.cmbCM_TANTO.Text = "(選択)"
        Me.cmbCM_TANTO.ValueMember = "VALUE"
        '
        'lblSYANAI_CD
        '
        Me.tlpFilter.SetColumnSpan(Me.lblSYANAI_CD, 5)
        Me.lblSYANAI_CD.Font = New System.Drawing.Font("Meiryo UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.lblSYANAI_CD.Location = New System.Drawing.Point(243, 60)
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
        Me.cmbSYANAI_CD.Location = New System.Drawing.Point(343, 63)
        Me.cmbSYANAI_CD.Name = "cmbSYANAI_CD"
        Me.cmbSYANAI_CD.NullValue = " "
        Me.cmbSYANAI_CD.Size = New System.Drawing.Size(134, 25)
        Me.cmbSYANAI_CD.TabIndex = 7
        Me.cmbSYANAI_CD.Text = "(選択)"
        Me.cmbSYANAI_CD.ValueMember = "VALUE"
        Me.cmbSYANAI_CD.Visible = False
        '
        'Label16
        '
        Me.tlpFilter.SetColumnSpan(Me.Label16, 5)
        Me.Label16.Font = New System.Drawing.Font("Meiryo UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label16.Location = New System.Drawing.Point(243, 30)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(94, 30)
        Me.Label16.TabIndex = 283
        Me.Label16.Text = "起草日:"
        Me.Label16.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'dtKISO
        '
        Me.dtKISO.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.dtKISO.GotFocusedColor = System.Drawing.Color.FromArgb(CType(CType(190, Byte), Integer), CType(CType(180, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.dtKISO.Location = New System.Drawing.Point(343, 33)
        Me.dtKISO.MaxDate = New Date(9998, 12, 31, 0, 0, 0, 0)
        Me.dtKISO.MinDate = New Date(1753, 1, 1, 0, 0, 0, 0)
        Me.dtKISO.MinimumSize = New System.Drawing.Size(98, 24)
        Me.dtKISO.Name = "dtKISO"
        Me.dtKISO.ReadOnly = False
        Me.dtKISO.Size = New System.Drawing.Size(98, 24)
        Me.dtKISO.TabIndex = 4
        Me.dtKISO.Value = ""
        Me.dtKISO.ValueNonFormat = ""
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.BackColor = System.Drawing.Color.Wheat
        Me.Label1.Font = New System.Drawing.Font("Meiryo UI", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label1.Location = New System.Drawing.Point(12, 64)
        Me.Label1.Margin = New System.Windows.Forms.Padding(3)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(86, 24)
        Me.Label1.TabIndex = 326
        Me.Label1.Text = "基本情報"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'InfoToolTip
        '
        Me.InfoToolTip.ToolTipIcon = System.Windows.Forms.ToolTipIcon.Info
        Me.InfoToolTip.ToolTipTitle = "参照元"
        '
        'Label3
        '
        Me.tlpFilter.SetColumnSpan(Me.Label3, 5)
        Me.Label3.Font = New System.Drawing.Font("Meiryo UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label3.Location = New System.Drawing.Point(3, 120)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(94, 30)
        Me.Label3.TabIndex = 93
        Me.Label3.Text = "インプット文書等:"
        Me.Label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'txtINPUT_NAIYO
        '
        Me.txtINPUT_NAIYO.AcceptsReturn = True
        Me.tlpFilter.SetColumnSpan(Me.txtINPUT_NAIYO, 22)
        Me.txtINPUT_NAIYO.Font = New System.Drawing.Font("Meiryo UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.txtINPUT_NAIYO.ImeMode = System.Windows.Forms.ImeMode.[On]
        Me.txtINPUT_NAIYO.InputRequired = False
        Me.txtINPUT_NAIYO.Location = New System.Drawing.Point(783, 3)
        Me.txtINPUT_NAIYO.MaxByteLength = 600
        Me.txtINPUT_NAIYO.MaxLength = 300
        Me.txtINPUT_NAIYO.Multiline = True
        Me.txtINPUT_NAIYO.Name = "txtINPUT_NAIYO"
        Me.tlpFilter.SetRowSpan(Me.txtINPUT_NAIYO, 5)
        Me.txtINPUT_NAIYO.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.txtINPUT_NAIYO.SelectAllText = False
        Me.txtINPUT_NAIYO.ShowRemainingChars = True
        Me.txtINPUT_NAIYO.Size = New System.Drawing.Size(434, 144)
        Me.txtINPUT_NAIYO.TabIndex = 11
        Me.txtINPUT_NAIYO.WatermarkColor = System.Drawing.Color.Empty
        Me.txtINPUT_NAIYO.WatermarkText = Nothing
        '
        'Label17
        '
        Me.tlpFilter.SetColumnSpan(Me.Label17, 6)
        Me.Label17.Font = New System.Drawing.Font("Meiryo UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label17.Location = New System.Drawing.Point(363, 120)
        Me.Label17.Name = "Label17"
        Me.Label17.Size = New System.Drawing.Size(114, 30)
        Me.Label17.TabIndex = 93
        Me.Label17.Text = "SNo./号機 時期等:"
        Me.Label17.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'PanelEx2
        '
        Me.PanelEx2.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.PanelEx2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.PanelEx2.Controls.Add(Me.tlpFilter)
        Me.PanelEx2.HitEnabled = False
        Me.PanelEx2.Location = New System.Drawing.Point(12, 96)
        Me.PanelEx2.Name = "PanelEx2"
        Me.PanelEx2.Size = New System.Drawing.Size(1240, 161)
        Me.PanelEx2.TabIndex = 0
        '
        'tlpFilter
        '
        Me.tlpFilter.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
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
        Me.tlpFilter.Controls.Add(Me.Label8, 0, 0)
        Me.tlpFilter.Controls.Add(Me.mtxFCCB_NO, 1, 0)
        Me.tlpFilter.Controls.Add(Me.cmbBUMON, 15, 0)
        Me.tlpFilter.Controls.Add(Me.lblKISO_TANTO, 20, 0)
        Me.tlpFilter.Controls.Add(Me.cmbKISO_TANTO, 25, 0)
        Me.tlpFilter.Controls.Add(Me.Label14, 0, 1)
        Me.tlpFilter.Controls.Add(Me.Label3, 0, 4)
        Me.tlpFilter.Controls.Add(Me.Label7, 0, 3)
        Me.tlpFilter.Controls.Add(Me.cmbHINMEI, 5, 3)
        Me.tlpFilter.Controls.Add(Me.Label4, 0, 2)
        Me.tlpFilter.Controls.Add(Me.cmbBUHIN_BANGO, 5, 2)
        Me.tlpFilter.Controls.Add(Me.lblSYANAI_CD, 12, 2)
        Me.tlpFilter.Controls.Add(Me.cmbSYANAI_CD, 17, 2)
        Me.tlpFilter.Controls.Add(Me.lblCM_TANTO, 22, 1)
        Me.tlpFilter.Controls.Add(Me.cmbCM_TANTO, 27, 1)
        Me.tlpFilter.Controls.Add(Me.cmbKISYU, 5, 1)
        Me.tlpFilter.Controls.Add(Me.Label18, 34, 0)
        Me.tlpFilter.Controls.Add(Me.txtINPUT_NAIYO, 39, 0)
        Me.tlpFilter.Controls.Add(Me.Label16, 12, 1)
        Me.tlpFilter.Controls.Add(Me.dtKISO, 17, 1)
        Me.tlpFilter.Controls.Add(Me.Label5, 12, 0)
        Me.tlpFilter.Controls.Add(Me.mtxINPUT_DOC_NO, 5, 4)
        Me.tlpFilter.Controls.Add(Me.mtxSNO_APPLY_PERIOD_KISO, 24, 4)
        Me.tlpFilter.Controls.Add(Me.Label17, 18, 4)
        Me.tlpFilter.Location = New System.Drawing.Point(0, 0)
        Me.tlpFilter.Name = "tlpFilter"
        Me.tlpFilter.RowCount = 7
        Me.tlpFilter.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30.0!))
        Me.tlpFilter.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30.0!))
        Me.tlpFilter.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30.0!))
        Me.tlpFilter.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30.0!))
        Me.tlpFilter.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30.0!))
        Me.tlpFilter.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30.0!))
        Me.tlpFilter.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.tlpFilter.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20.0!))
        Me.tlpFilter.Size = New System.Drawing.Size(1236, 157)
        Me.tlpFilter.TabIndex = 327
        '
        'Label18
        '
        Me.tlpFilter.SetColumnSpan(Me.Label18, 5)
        Me.Label18.Font = New System.Drawing.Font("Meiryo UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label18.Location = New System.Drawing.Point(683, 0)
        Me.Label18.Name = "Label18"
        Me.Label18.Size = New System.Drawing.Size(94, 30)
        Me.Label18.TabIndex = 281
        Me.Label18.Text = "変更内容:"
        Me.Label18.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'mtxINPUT_DOC_NO
        '
        Me.tlpFilter.SetColumnSpan(Me.mtxINPUT_DOC_NO, 11)
        Me.mtxINPUT_DOC_NO.Font = New System.Drawing.Font("Meiryo UI", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.mtxINPUT_DOC_NO.ImeMode = System.Windows.Forms.ImeMode.[On]
        Me.mtxINPUT_DOC_NO.InputRequired = False
        Me.mtxINPUT_DOC_NO.Location = New System.Drawing.Point(103, 123)
        Me.mtxINPUT_DOC_NO.MaxByteLength = 0
        Me.mtxINPUT_DOC_NO.Name = "mtxINPUT_DOC_NO"
        Me.mtxINPUT_DOC_NO.SelectAllText = False
        Me.mtxINPUT_DOC_NO.Size = New System.Drawing.Size(214, 24)
        Me.mtxINPUT_DOC_NO.TabIndex = 9
        Me.mtxINPUT_DOC_NO.WatermarkColor = System.Drawing.Color.Empty
        Me.mtxINPUT_DOC_NO.WatermarkText = Nothing
        '
        'mtxSNO_APPLY_PERIOD_KISO
        '
        Me.tlpFilter.SetColumnSpan(Me.mtxSNO_APPLY_PERIOD_KISO, 11)
        Me.mtxSNO_APPLY_PERIOD_KISO.Font = New System.Drawing.Font("Meiryo UI", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.mtxSNO_APPLY_PERIOD_KISO.ImeMode = System.Windows.Forms.ImeMode.[On]
        Me.mtxSNO_APPLY_PERIOD_KISO.InputRequired = False
        Me.mtxSNO_APPLY_PERIOD_KISO.Location = New System.Drawing.Point(483, 123)
        Me.mtxSNO_APPLY_PERIOD_KISO.MaxByteLength = 0
        Me.mtxSNO_APPLY_PERIOD_KISO.Name = "mtxSNO_APPLY_PERIOD_KISO"
        Me.mtxSNO_APPLY_PERIOD_KISO.SelectAllText = False
        Me.mtxSNO_APPLY_PERIOD_KISO.Size = New System.Drawing.Size(214, 24)
        Me.mtxSNO_APPLY_PERIOD_KISO.TabIndex = 10
        Me.mtxSNO_APPLY_PERIOD_KISO.WatermarkColor = System.Drawing.Color.Empty
        Me.mtxSNO_APPLY_PERIOD_KISO.WatermarkText = Nothing
        '
        'flpnlStageIndex
        '
        Me.flpnlStageIndex.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.flpnlStageIndex.Controls.Add(Me.rsbtnST01)
        Me.flpnlStageIndex.Controls.Add(Me.rsbtnST02)
        Me.flpnlStageIndex.Controls.Add(Me.rsbtnST03)
        Me.flpnlStageIndex.Controls.Add(Me.rsbtnST04)
        Me.flpnlStageIndex.Controls.Add(Me.rsbtnST05)
        Me.flpnlStageIndex.Controls.Add(Me.rsbtnST06)
        Me.flpnlStageIndex.Controls.Add(Me.rsbtnST99)
        Me.flpnlStageIndex.Enabled = False
        Me.flpnlStageIndex.Location = New System.Drawing.Point(626, 61)
        Me.flpnlStageIndex.Name = "flpnlStageIndex"
        Me.flpnlStageIndex.Size = New System.Drawing.Size(622, 31)
        Me.flpnlStageIndex.TabIndex = 329
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
        'lblDestTanto
        '
        Me.lblDestTanto.AutoSize = True
        Me.lblDestTanto.Font = New System.Drawing.Font("Meiryo UI", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.lblDestTanto.Location = New System.Drawing.Point(340, 70)
        Me.lblDestTanto.Margin = New System.Windows.Forms.Padding(3, 3, 3, 0)
        Me.lblDestTanto.Name = "lblDestTanto"
        Me.lblDestTanto.Size = New System.Drawing.Size(72, 15)
        Me.lblDestTanto.TabIndex = 331
        Me.lblDestTanto.Text = "申請先社員:"
        Me.lblDestTanto.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.lblDestTanto.Visible = False
        '
        'Label48
        '
        Me.Label48.AutoSize = True
        Me.Label48.Font = New System.Drawing.Font("Meiryo UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label48.Location = New System.Drawing.Point(120, 70)
        Me.Label48.Margin = New System.Windows.Forms.Padding(3, 3, 3, 0)
        Me.Label48.Name = "Label48"
        Me.Label48.Size = New System.Drawing.Size(102, 15)
        Me.Label48.TabIndex = 330
        Me.Label48.Text = "承認・申請年月日:"
        Me.Label48.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.Label48.Visible = False
        '
        'cmbDestTANTO
        '
        Me.cmbDestTANTO.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cmbDestTANTO.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cmbDestTANTO.BackColor = System.Drawing.SystemColors.Window
        Me.cmbDestTANTO.Cursor = System.Windows.Forms.Cursors.Default
        Me.cmbDestTANTO.DisplayMember = "DISP"
        Me.cmbDestTANTO.Font = New System.Drawing.Font("Meiryo UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.cmbDestTANTO.ForeColor = System.Drawing.SystemColors.ControlText
        Me.cmbDestTANTO.FormattingEnabled = True
        Me.cmbDestTANTO.HorizontalContentAlignment = System.Drawing.StringAlignment.Near
        Me.cmbDestTANTO.ImeMode = System.Windows.Forms.ImeMode.Disable
        Me.cmbDestTANTO.IsSelected = False
        Me.cmbDestTANTO.Location = New System.Drawing.Point(421, 65)
        Me.cmbDestTANTO.Name = "cmbDestTANTO"
        Me.cmbDestTANTO.NullValue = " "
        Me.cmbDestTANTO.Size = New System.Drawing.Size(154, 25)
        Me.cmbDestTANTO.TabIndex = 332
        Me.cmbDestTANTO.Text = "(選択)"
        Me.cmbDestTANTO.ValueMember = "VALUE"
        Me.cmbDestTANTO.Visible = False
        '
        'dtUPD_YMD
        '
        Me.dtUPD_YMD.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.dtUPD_YMD.GotFocusedColor = System.Drawing.Color.FromArgb(CType(CType(190, Byte), Integer), CType(CType(180, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.dtUPD_YMD.Location = New System.Drawing.Point(228, 65)
        Me.dtUPD_YMD.MaxDate = New Date(9998, 12, 31, 0, 0, 0, 0)
        Me.dtUPD_YMD.MinDate = New Date(1753, 1, 1, 0, 0, 0, 0)
        Me.dtUPD_YMD.MinimumSize = New System.Drawing.Size(98, 24)
        Me.dtUPD_YMD.Name = "dtUPD_YMD"
        Me.dtUPD_YMD.ReadOnly = False
        Me.dtUPD_YMD.Size = New System.Drawing.Size(98, 24)
        Me.dtUPD_YMD.TabIndex = 333
        Me.dtUPD_YMD.Value = ""
        Me.dtUPD_YMD.ValueNonFormat = ""
        Me.dtUPD_YMD.Visible = False
        '
        'TabControl1
        '
        Me.TabControl1.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TabControl1.Controls.Add(Me.TabPageEx1)
        Me.TabControl1.Font = New System.Drawing.Font("Meiryo UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.TabControl1.HotTrack = True
        Me.TabControl1.Location = New System.Drawing.Point(10, 236)
        Me.TabControl1.Multiline = True
        Me.TabControl1.Name = "TabControl1"
        Me.TabControl1.SelectedIndex = 0
        Me.TabControl1.Size = New System.Drawing.Size(1240, 399)
        Me.TabControl1.TabIndex = 218
        '
        'TabPageEx1
        '
        Me.TabPageEx1.AutoScroll = True
        Me.TabPageEx1.BackColor = System.Drawing.SystemColors.Control
        Me.TabPageEx1.Controls.Add(Me.Label11)
        Me.TabPageEx1.Controls.Add(Me.Label12)
        Me.TabPageEx1.Controls.Add(Me.Label13)
        Me.TabPageEx1.Controls.Add(Me.C1SplitContainer)
        Me.TabPageEx1.HitEnabled = False
        Me.TabPageEx1.Location = New System.Drawing.Point(4, 26)
        Me.TabPageEx1.Name = "TabPageEx1"
        Me.TabPageEx1.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPageEx1.Size = New System.Drawing.Size(1232, 369)
        Me.TabPageEx1.TabIndex = 0
        '
        'Label11
        '
        Me.Label11.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.Label11.AutoSize = True
        Me.Label11.Font = New System.Drawing.Font("Meiryo UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label11.Location = New System.Drawing.Point(255, 32767)
        Me.Label11.Margin = New System.Windows.Forms.Padding(3, 3, 3, 0)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(98, 15)
        Me.Label11.TabIndex = 213
        Me.Label11.Text = "承認先ステージ名:"
        Me.Label11.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label12
        '
        Me.Label12.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.Label12.AutoSize = True
        Me.Label12.Font = New System.Drawing.Font("Meiryo UI", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label12.Location = New System.Drawing.Point(661, 32767)
        Me.Label12.Margin = New System.Windows.Forms.Padding(3, 3, 3, 0)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(72, 15)
        Me.Label12.TabIndex = 212
        Me.Label12.Text = "申請先社員:"
        Me.Label12.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label13
        '
        Me.Label13.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.Label13.AutoSize = True
        Me.Label13.Font = New System.Drawing.Font("Meiryo UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label13.Location = New System.Drawing.Point(10, 32767)
        Me.Label13.Margin = New System.Windows.Forms.Padding(3, 3, 3, 0)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(102, 15)
        Me.Label13.TabIndex = 211
        Me.Label13.Text = "承認・申請年月日:"
        Me.Label13.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'C1SplitContainer
        '
        Me.C1SplitContainer.AutoSizeElement = C1.Framework.AutoSizeElement.Both
        Me.C1SplitContainer.BackColor = System.Drawing.Color.FromArgb(CType(CType(240, Byte), Integer), CType(CType(240, Byte), Integer), CType(CType(240, Byte), Integer))
        Me.C1SplitContainer.BorderColor = System.Drawing.Color.Black
        Me.C1SplitContainer.BorderWidth = 1
        Me.C1SplitContainer.CollapsingCueColor = System.Drawing.Color.FromArgb(CType(CType(133, Byte), Integer), CType(CType(133, Byte), Integer), CType(CType(150, Byte), Integer))
        Me.C1SplitContainer.Dock = System.Windows.Forms.DockStyle.Top
        Me.C1SplitContainer.EnlargeCollapsingHandle = True
        Me.C1SplitContainer.Font = New System.Drawing.Font("Meiryo UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.C1SplitContainer.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.WarningErrorProvider.SetIconAlignment(Me.C1SplitContainer, System.Windows.Forms.ErrorIconAlignment.MiddleLeft)
        Me.C1SplitContainer.Location = New System.Drawing.Point(3, 3)
        Me.C1SplitContainer.Name = "C1SplitContainer"
        Me.C1SplitContainer.Panels.Add(Me.C1SplitterPanel1)
        Me.C1SplitContainer.Panels.Add(Me.C1SplitterPanel2)
        Me.C1SplitContainer.Panels.Add(Me.C1SplitterPanel3)
        Me.C1SplitContainer.Panels.Add(Me.C1SplitterPanel4)
        Me.C1SplitContainer.Panels.Add(Me.C1SplitterPanel5)
        Me.C1SplitContainer.Size = New System.Drawing.Size(1209, 1300)
        Me.C1SplitContainer.TabIndex = 327
        '
        'C1SplitterPanel1
        '
        Me.C1SplitterPanel1.AutoScroll = True
        Me.C1SplitterPanel1.Collapsible = True
        Me.C1SplitterPanel1.Controls.Add(Me.flxDATA_2)
        Me.C1SplitterPanel1.Height = 647
        Me.C1SplitterPanel1.Location = New System.Drawing.Point(1, 22)
        Me.C1SplitterPanel1.MinHeight = 650
        Me.C1SplitterPanel1.Name = "C1SplitterPanel1"
        Me.C1SplitterPanel1.ResizeWhileDragging = True
        Me.C1SplitterPanel1.Size = New System.Drawing.Size(1207, 615)
        Me.C1SplitterPanel1.TabIndex = 0
        Me.C1SplitterPanel1.Text = "②要処置事項調査"
        '
        'flxDATA_2
        '
        Me.flxDATA_2.AllowDragging = C1.Win.C1FlexGrid.AllowDraggingEnum.None
        Me.flxDATA_2.AllowMerging = C1.Win.C1FlexGrid.AllowMergingEnum.RestrictRows
        Me.flxDATA_2.AllowSorting = C1.Win.C1FlexGrid.AllowSortingEnum.None
        Me.flxDATA_2.AutoClipboard = True
        Me.flxDATA_2.AutoGenerateColumns = False
        Me.flxDATA_2.AutoSearch = C1.Win.C1FlexGrid.AutoSearchEnum.FromTop
        Me.flxDATA_2.BorderStyle = C1.Win.C1FlexGrid.Util.BaseControls.BorderStyleEnum.Light3D
        Me.flxDATA_2.ColumnInfo = resources.GetString("flxDATA_2.ColumnInfo")
        Me.flxDATA_2.DataSource = Me.Flx2_DS
        Me.flxDATA_2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.flxDATA_2.Location = New System.Drawing.Point(0, 0)
        Me.flxDATA_2.Name = "flxDATA_2"
        Me.flxDATA_2.Rows.Count = 1
        Me.flxDATA_2.Rows.DefaultSize = 18
        Me.flxDATA_2.ShowCursor = True
        Me.flxDATA_2.Size = New System.Drawing.Size(1207, 615)
        Me.flxDATA_2.StyleInfo = resources.GetString("flxDATA_2.StyleInfo")
        Me.flxDATA_2.TabIndex = 329
        Me.flxDATA_2.VisualStyle = C1.Win.C1FlexGrid.VisualStyle.Office2010Silver
        '
        'Flx2_DS
        '
        Me.Flx2_DS.DataSource = GetType(MODEL.D010_FCCB_SUB_SYOCHI_KOMOKU)
        '
        'C1SplitterPanel2
        '
        Me.C1SplitterPanel2.AutoScroll = True
        Me.C1SplitterPanel2.Collapsible = True
        Me.C1SplitterPanel2.Controls.Add(Me.flxDATA_3)
        Me.C1SplitterPanel2.Height = 120
        Me.C1SplitterPanel2.KeepRelativeSize = False
        Me.C1SplitterPanel2.Location = New System.Drawing.Point(1, 673)
        Me.C1SplitterPanel2.MinHeight = 120
        Me.C1SplitterPanel2.Name = "C1SplitterPanel2"
        Me.C1SplitterPanel2.ResizeWhileDragging = True
        Me.C1SplitterPanel2.Size = New System.Drawing.Size(1207, 88)
        Me.C1SplitterPanel2.SizeRatio = 19.672R
        Me.C1SplitterPanel2.TabIndex = 1
        Me.C1SplitterPanel2.Text = "③検証"
        '
        'flxDATA_3
        '
        Me.flxDATA_3.AllowDragging = C1.Win.C1FlexGrid.AllowDraggingEnum.None
        Me.flxDATA_3.AllowSorting = C1.Win.C1FlexGrid.AllowSortingEnum.None
        Me.flxDATA_3.AutoClipboard = True
        Me.flxDATA_3.AutoGenerateColumns = False
        Me.flxDATA_3.AutoSearch = C1.Win.C1FlexGrid.AutoSearchEnum.FromTop
        Me.flxDATA_3.BorderStyle = C1.Win.C1FlexGrid.Util.BaseControls.BorderStyleEnum.Light3D
        Me.flxDATA_3.ColumnInfo = resources.GetString("flxDATA_3.ColumnInfo")
        Me.flxDATA_3.DataSource = Me.Flx3_DS
        Me.flxDATA_3.Dock = System.Windows.Forms.DockStyle.Fill
        Me.flxDATA_3.Location = New System.Drawing.Point(0, 0)
        Me.flxDATA_3.Name = "flxDATA_3"
        Me.flxDATA_3.Rows.Count = 1
        Me.flxDATA_3.Rows.DefaultSize = 18
        Me.flxDATA_3.Size = New System.Drawing.Size(1207, 88)
        Me.flxDATA_3.StyleInfo = resources.GetString("flxDATA_3.StyleInfo")
        Me.flxDATA_3.TabIndex = 1
        Me.flxDATA_3.VisualStyle = C1.Win.C1FlexGrid.VisualStyle.Office2010Silver
        '
        'Flx3_DS
        '
        Me.Flx3_DS.DataSource = GetType(MODEL.V013_FCCB_SUB_SYOCHI_KOMOKU)
        '
        'C1SplitterPanel3
        '
        Me.C1SplitterPanel3.AutoScroll = True
        Me.C1SplitterPanel3.Collapsible = True
        Me.C1SplitterPanel3.Controls.Add(Me.flxDATA_4)
        Me.C1SplitterPanel3.Height = 164
        Me.C1SplitterPanel3.Location = New System.Drawing.Point(1, 797)
        Me.C1SplitterPanel3.MinHeight = 170
        Me.C1SplitterPanel3.Name = "C1SplitterPanel3"
        Me.C1SplitterPanel3.ResizeWhileDragging = True
        Me.C1SplitterPanel3.Size = New System.Drawing.Size(1207, 132)
        Me.C1SplitterPanel3.SizeRatio = 31.634R
        Me.C1SplitterPanel3.TabIndex = 2
        Me.C1SplitterPanel3.Text = "④仕掛品状況"
        '
        'flxDATA_4
        '
        Me.flxDATA_4.AllowDragging = C1.Win.C1FlexGrid.AllowDraggingEnum.None
        Me.flxDATA_4.AllowSorting = C1.Win.C1FlexGrid.AllowSortingEnum.None
        Me.flxDATA_4.AutoClipboard = True
        Me.flxDATA_4.AutoGenerateColumns = False
        Me.flxDATA_4.AutoSearch = C1.Win.C1FlexGrid.AutoSearchEnum.FromTop
        Me.flxDATA_4.BorderStyle = C1.Win.C1FlexGrid.Util.BaseControls.BorderStyleEnum.Light3D
        Me.flxDATA_4.ColumnInfo = resources.GetString("flxDATA_4.ColumnInfo")
        Me.flxDATA_4.DataSource = Me.Flx4_DS
        Me.flxDATA_4.Dock = System.Windows.Forms.DockStyle.Fill
        Me.flxDATA_4.Location = New System.Drawing.Point(0, 0)
        Me.flxDATA_4.Name = "flxDATA_4"
        Me.flxDATA_4.Rows.Count = 1
        Me.flxDATA_4.Rows.DefaultSize = 18
        Me.flxDATA_4.Size = New System.Drawing.Size(1207, 132)
        Me.flxDATA_4.StyleInfo = resources.GetString("flxDATA_4.StyleInfo")
        Me.flxDATA_4.TabIndex = 1
        Me.flxDATA_4.VisualStyle = C1.Win.C1FlexGrid.VisualStyle.Office2010Silver
        '
        'Flx4_DS
        '
        Me.Flx4_DS.DataSource = GetType(MODEL.D011_FCCB_SUB_SIKAKE_BUHIN)
        '
        'C1SplitterPanel4
        '
        Me.C1SplitterPanel4.AutoScroll = True
        Me.C1SplitterPanel4.Collapsible = True
        Me.C1SplitterPanel4.Controls.Add(Me.TableLayoutPanel1)
        Me.C1SplitterPanel4.Controls.Add(Me.PanelEx1)
        Me.C1SplitterPanel4.Height = 341
        Me.C1SplitterPanel4.Location = New System.Drawing.Point(1, 965)
        Me.C1SplitterPanel4.MinHeight = 340
        Me.C1SplitterPanel4.MinWidth = 100
        Me.C1SplitterPanel4.Name = "C1SplitterPanel4"
        Me.C1SplitterPanel4.ResizeWhileDragging = True
        Me.C1SplitterPanel4.Size = New System.Drawing.Size(1207, 309)
        Me.C1SplitterPanel4.SizeRatio = 98.701R
        Me.C1SplitterPanel4.TabIndex = 3
        Me.C1SplitterPanel4.Text = "⑤変更審議"
        '
        'TableLayoutPanel1
        '
        Me.TableLayoutPanel1.ColumnCount = 14
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 106.0!))
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 106.0!))
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 106.0!))
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 106.0!))
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 106.0!))
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 106.0!))
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 106.0!))
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 106.0!))
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 106.0!))
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 10.0!))
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 26.0!))
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 106.0!))
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 106.0!))
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.TableLayoutPanel1.Controls.Add(Me.cmbSYOCHI_GM_TANTO, 0, 2)
        Me.TableLayoutPanel1.Controls.Add(Me.Label29, 11, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.Label28, 10, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.Label2, 0, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.Label19, 0, 1)
        Me.TableLayoutPanel1.Controls.Add(Me.Label20, 1, 1)
        Me.TableLayoutPanel1.Controls.Add(Me.Label21, 2, 1)
        Me.TableLayoutPanel1.Controls.Add(Me.Label22, 3, 1)
        Me.TableLayoutPanel1.Controls.Add(Me.Label23, 4, 1)
        Me.TableLayoutPanel1.Controls.Add(Me.Label24, 5, 1)
        Me.TableLayoutPanel1.Controls.Add(Me.Label25, 6, 1)
        Me.TableLayoutPanel1.Controls.Add(Me.Label27, 7, 1)
        Me.TableLayoutPanel1.Controls.Add(Me.Label32, 11, 1)
        Me.TableLayoutPanel1.Controls.Add(Me.Label31, 12, 1)
        Me.TableLayoutPanel1.Controls.Add(Me.Label30, 8, 1)
        Me.TableLayoutPanel1.Controls.Add(Me.cmbSYOCHI_SEKKEI_TANTO, 1, 2)
        Me.TableLayoutPanel1.Controls.Add(Me.cmbSYOCHI_SEIGI_TANTO, 2, 2)
        Me.TableLayoutPanel1.Controls.Add(Me.cmbSYOCHI_EIGYO_TANTO, 3, 2)
        Me.TableLayoutPanel1.Controls.Add(Me.cmbSYOCHI_KANRI_TANTO, 4, 2)
        Me.TableLayoutPanel1.Controls.Add(Me.dtSYOCHI_GM_TANTO, 0, 3)
        Me.TableLayoutPanel1.Controls.Add(Me.cmbSYOCHI_SEIZO_TANTO, 5, 2)
        Me.TableLayoutPanel1.Controls.Add(Me.cmbSYOCHI_HINSYO_TANTO, 6, 2)
        Me.TableLayoutPanel1.Controls.Add(Me.cmbSYOCHI_KENSA_TANTO, 7, 2)
        Me.TableLayoutPanel1.Controls.Add(Me.cmbSYOCHI_KOBAI_TANTO, 8, 2)
        Me.TableLayoutPanel1.Controls.Add(Me.cmbKAKUNIN_GM_TANTO, 11, 2)
        Me.TableLayoutPanel1.Controls.Add(Me.cmbKAKUNIN_CM_TANTO, 12, 2)
        Me.TableLayoutPanel1.Controls.Add(Me.dtSYOCHI_SEKKEI_TANTO, 1, 3)
        Me.TableLayoutPanel1.Controls.Add(Me.dtSYOCHI_SEIGI_TANTO, 2, 3)
        Me.TableLayoutPanel1.Controls.Add(Me.dtSYOCHI_EIGYO_TANTO, 3, 3)
        Me.TableLayoutPanel1.Controls.Add(Me.dtSYOCHI_KANRI_TANTO, 4, 3)
        Me.TableLayoutPanel1.Controls.Add(Me.dtSYOCHI_SEIZO_TANTO, 5, 3)
        Me.TableLayoutPanel1.Controls.Add(Me.dtSYOCHI_HINSYO_TANTO, 6, 3)
        Me.TableLayoutPanel1.Controls.Add(Me.dtSYOCHI_KENSA_TANTO, 7, 3)
        Me.TableLayoutPanel1.Controls.Add(Me.dtSYOCHI_KOBAI_TANTO, 8, 3)
        Me.TableLayoutPanel1.Controls.Add(Me.dtKAKUNIN_GM_TANTO, 11, 3)
        Me.TableLayoutPanel1.Controls.Add(Me.dtKAKUNIN_CM_TANTO, 12, 3)
        Me.TableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.TableLayoutPanel1.Location = New System.Drawing.Point(0, 208)
        Me.TableLayoutPanel1.Name = "TableLayoutPanel1"
        Me.TableLayoutPanel1.RowCount = 4
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30.0!))
        Me.TableLayoutPanel1.Size = New System.Drawing.Size(1207, 101)
        Me.TableLayoutPanel1.TabIndex = 270
        '
        'cmbSYOCHI_GM_TANTO
        '
        Me.cmbSYOCHI_GM_TANTO.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cmbSYOCHI_GM_TANTO.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cmbSYOCHI_GM_TANTO.BackColor = System.Drawing.SystemColors.Window
        Me.cmbSYOCHI_GM_TANTO.Cursor = System.Windows.Forms.Cursors.Default
        Me.cmbSYOCHI_GM_TANTO.DisplayMember = "DISP"
        Me.cmbSYOCHI_GM_TANTO.DropDownWidth = 230
        Me.cmbSYOCHI_GM_TANTO.Font = New System.Drawing.Font("Meiryo UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.cmbSYOCHI_GM_TANTO.ForeColor = System.Drawing.SystemColors.ControlText
        Me.cmbSYOCHI_GM_TANTO.FormattingEnabled = True
        Me.cmbSYOCHI_GM_TANTO.HorizontalContentAlignment = System.Drawing.StringAlignment.Near
        Me.cmbSYOCHI_GM_TANTO.ImeMode = System.Windows.Forms.ImeMode.[On]
        Me.cmbSYOCHI_GM_TANTO.IsSelected = False
        Me.cmbSYOCHI_GM_TANTO.Location = New System.Drawing.Point(3, 43)
        Me.cmbSYOCHI_GM_TANTO.Name = "cmbSYOCHI_GM_TANTO"
        Me.cmbSYOCHI_GM_TANTO.NullValue = " "
        Me.cmbSYOCHI_GM_TANTO.Size = New System.Drawing.Size(100, 25)
        Me.cmbSYOCHI_GM_TANTO.TabIndex = 1
        Me.cmbSYOCHI_GM_TANTO.Text = "(選択)"
        Me.cmbSYOCHI_GM_TANTO.ValueMember = "VALUE"
        '
        'Label29
        '
        Me.Label29.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TableLayoutPanel1.SetColumnSpan(Me.Label29, 2)
        Me.Label29.Font = New System.Drawing.Font("Meiryo UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label29.Location = New System.Drawing.Point(993, 0)
        Me.Label29.Name = "Label29"
        Me.Label29.Size = New System.Drawing.Size(206, 20)
        Me.Label29.TabIndex = 291
        Me.Label29.Text = "処置事項完了の確認"
        Me.Label29.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label28
        '
        Me.Label28.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label28.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Label28.Font = New System.Drawing.Font("Meiryo UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label28.Location = New System.Drawing.Point(967, 0)
        Me.Label28.Name = "Label28"
        Me.TableLayoutPanel1.SetRowSpan(Me.Label28, 4)
        Me.Label28.Size = New System.Drawing.Size(20, 101)
        Me.Label28.TabIndex = 290
        Me.Label28.Text = "⑥完了確認"
        Me.Label28.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label2
        '
        Me.Label2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TableLayoutPanel1.SetColumnSpan(Me.Label2, 9)
        Me.Label2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Label2.Font = New System.Drawing.Font("Meiryo UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label2.Location = New System.Drawing.Point(3, 0)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(948, 20)
        Me.Label2.TabIndex = 0
        Me.Label2.Text = "処置内容の確認、変更の適用時期等の確認、仕掛品等の処置確認"
        Me.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label19
        '
        Me.Label19.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label19.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Label19.Font = New System.Drawing.Font("Meiryo UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label19.Location = New System.Drawing.Point(3, 20)
        Me.Label19.Name = "Label19"
        Me.Label19.Size = New System.Drawing.Size(100, 20)
        Me.Label19.TabIndex = 282
        Me.Label19.Text = "統括責任者"
        Me.Label19.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label20
        '
        Me.Label20.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label20.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Label20.Font = New System.Drawing.Font("Meiryo UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label20.Location = New System.Drawing.Point(109, 20)
        Me.Label20.Name = "Label20"
        Me.Label20.Size = New System.Drawing.Size(100, 20)
        Me.Label20.TabIndex = 283
        Me.Label20.Text = "設計"
        Me.Label20.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label21
        '
        Me.Label21.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label21.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Label21.Font = New System.Drawing.Font("Meiryo UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label21.Location = New System.Drawing.Point(215, 20)
        Me.Label21.Name = "Label21"
        Me.Label21.Size = New System.Drawing.Size(100, 20)
        Me.Label21.TabIndex = 284
        Me.Label21.Text = "生技"
        Me.Label21.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label22
        '
        Me.Label22.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label22.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Label22.Font = New System.Drawing.Font("Meiryo UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label22.Location = New System.Drawing.Point(321, 20)
        Me.Label22.Name = "Label22"
        Me.Label22.Size = New System.Drawing.Size(100, 20)
        Me.Label22.TabIndex = 285
        Me.Label22.Text = "営業"
        Me.Label22.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label23
        '
        Me.Label23.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label23.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Label23.Font = New System.Drawing.Font("Meiryo UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label23.Location = New System.Drawing.Point(427, 20)
        Me.Label23.Name = "Label23"
        Me.Label23.Size = New System.Drawing.Size(100, 20)
        Me.Label23.TabIndex = 286
        Me.Label23.Text = "管理"
        Me.Label23.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label24
        '
        Me.Label24.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label24.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Label24.Font = New System.Drawing.Font("Meiryo UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label24.Location = New System.Drawing.Point(533, 20)
        Me.Label24.Name = "Label24"
        Me.Label24.Size = New System.Drawing.Size(100, 20)
        Me.Label24.TabIndex = 287
        Me.Label24.Text = "製造"
        Me.Label24.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label25
        '
        Me.Label25.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label25.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Label25.Font = New System.Drawing.Font("Meiryo UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label25.Location = New System.Drawing.Point(639, 20)
        Me.Label25.Name = "Label25"
        Me.Label25.Size = New System.Drawing.Size(100, 20)
        Me.Label25.TabIndex = 288
        Me.Label25.Text = "品証"
        Me.Label25.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label27
        '
        Me.Label27.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label27.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Label27.Font = New System.Drawing.Font("Meiryo UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label27.Location = New System.Drawing.Point(745, 20)
        Me.Label27.Name = "Label27"
        Me.Label27.Size = New System.Drawing.Size(100, 20)
        Me.Label27.TabIndex = 289
        Me.Label27.Text = "検査"
        Me.Label27.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label32
        '
        Me.Label32.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label32.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Label32.Font = New System.Drawing.Font("Meiryo UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label32.Location = New System.Drawing.Point(993, 20)
        Me.Label32.Name = "Label32"
        Me.Label32.Size = New System.Drawing.Size(100, 20)
        Me.Label32.TabIndex = 294
        Me.Label32.Text = "統括責任者"
        Me.Label32.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label31
        '
        Me.Label31.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label31.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Label31.Font = New System.Drawing.Font("Meiryo UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label31.Location = New System.Drawing.Point(1099, 20)
        Me.Label31.Name = "Label31"
        Me.Label31.Size = New System.Drawing.Size(100, 20)
        Me.Label31.TabIndex = 293
        Me.Label31.Text = "FCCB議長"
        Me.Label31.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label30
        '
        Me.Label30.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label30.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Label30.Font = New System.Drawing.Font("Meiryo UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label30.Location = New System.Drawing.Point(851, 20)
        Me.Label30.Name = "Label30"
        Me.Label30.Size = New System.Drawing.Size(100, 20)
        Me.Label30.TabIndex = 295
        Me.Label30.Text = "購買"
        Me.Label30.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'cmbSYOCHI_SEKKEI_TANTO
        '
        Me.cmbSYOCHI_SEKKEI_TANTO.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cmbSYOCHI_SEKKEI_TANTO.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cmbSYOCHI_SEKKEI_TANTO.BackColor = System.Drawing.SystemColors.Window
        Me.cmbSYOCHI_SEKKEI_TANTO.Cursor = System.Windows.Forms.Cursors.Default
        Me.cmbSYOCHI_SEKKEI_TANTO.DisplayMember = "DISP"
        Me.cmbSYOCHI_SEKKEI_TANTO.DropDownWidth = 230
        Me.cmbSYOCHI_SEKKEI_TANTO.Font = New System.Drawing.Font("Meiryo UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.cmbSYOCHI_SEKKEI_TANTO.ForeColor = System.Drawing.SystemColors.ControlText
        Me.cmbSYOCHI_SEKKEI_TANTO.FormattingEnabled = True
        Me.cmbSYOCHI_SEKKEI_TANTO.HorizontalContentAlignment = System.Drawing.StringAlignment.Near
        Me.cmbSYOCHI_SEKKEI_TANTO.ImeMode = System.Windows.Forms.ImeMode.[On]
        Me.cmbSYOCHI_SEKKEI_TANTO.IsSelected = False
        Me.cmbSYOCHI_SEKKEI_TANTO.Location = New System.Drawing.Point(109, 43)
        Me.cmbSYOCHI_SEKKEI_TANTO.Name = "cmbSYOCHI_SEKKEI_TANTO"
        Me.cmbSYOCHI_SEKKEI_TANTO.NullValue = " "
        Me.cmbSYOCHI_SEKKEI_TANTO.Size = New System.Drawing.Size(100, 25)
        Me.cmbSYOCHI_SEKKEI_TANTO.TabIndex = 3
        Me.cmbSYOCHI_SEKKEI_TANTO.Text = "(選択)"
        Me.cmbSYOCHI_SEKKEI_TANTO.ValueMember = "VALUE"
        '
        'cmbSYOCHI_SEIGI_TANTO
        '
        Me.cmbSYOCHI_SEIGI_TANTO.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cmbSYOCHI_SEIGI_TANTO.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cmbSYOCHI_SEIGI_TANTO.BackColor = System.Drawing.SystemColors.Window
        Me.cmbSYOCHI_SEIGI_TANTO.Cursor = System.Windows.Forms.Cursors.Default
        Me.cmbSYOCHI_SEIGI_TANTO.DisplayMember = "DISP"
        Me.cmbSYOCHI_SEIGI_TANTO.DropDownWidth = 230
        Me.cmbSYOCHI_SEIGI_TANTO.Font = New System.Drawing.Font("Meiryo UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.cmbSYOCHI_SEIGI_TANTO.ForeColor = System.Drawing.SystemColors.ControlText
        Me.cmbSYOCHI_SEIGI_TANTO.FormattingEnabled = True
        Me.cmbSYOCHI_SEIGI_TANTO.HorizontalContentAlignment = System.Drawing.StringAlignment.Near
        Me.cmbSYOCHI_SEIGI_TANTO.ImeMode = System.Windows.Forms.ImeMode.[On]
        Me.cmbSYOCHI_SEIGI_TANTO.IsSelected = False
        Me.cmbSYOCHI_SEIGI_TANTO.Location = New System.Drawing.Point(215, 43)
        Me.cmbSYOCHI_SEIGI_TANTO.Name = "cmbSYOCHI_SEIGI_TANTO"
        Me.cmbSYOCHI_SEIGI_TANTO.NullValue = " "
        Me.cmbSYOCHI_SEIGI_TANTO.Size = New System.Drawing.Size(100, 25)
        Me.cmbSYOCHI_SEIGI_TANTO.TabIndex = 5
        Me.cmbSYOCHI_SEIGI_TANTO.Text = "(選択)"
        Me.cmbSYOCHI_SEIGI_TANTO.ValueMember = "VALUE"
        '
        'cmbSYOCHI_EIGYO_TANTO
        '
        Me.cmbSYOCHI_EIGYO_TANTO.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cmbSYOCHI_EIGYO_TANTO.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cmbSYOCHI_EIGYO_TANTO.BackColor = System.Drawing.SystemColors.Window
        Me.cmbSYOCHI_EIGYO_TANTO.Cursor = System.Windows.Forms.Cursors.Default
        Me.cmbSYOCHI_EIGYO_TANTO.DisplayMember = "DISP"
        Me.cmbSYOCHI_EIGYO_TANTO.DropDownWidth = 230
        Me.cmbSYOCHI_EIGYO_TANTO.Font = New System.Drawing.Font("Meiryo UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.cmbSYOCHI_EIGYO_TANTO.ForeColor = System.Drawing.SystemColors.ControlText
        Me.cmbSYOCHI_EIGYO_TANTO.FormattingEnabled = True
        Me.cmbSYOCHI_EIGYO_TANTO.HorizontalContentAlignment = System.Drawing.StringAlignment.Near
        Me.cmbSYOCHI_EIGYO_TANTO.ImeMode = System.Windows.Forms.ImeMode.[On]
        Me.cmbSYOCHI_EIGYO_TANTO.IsSelected = False
        Me.cmbSYOCHI_EIGYO_TANTO.Location = New System.Drawing.Point(321, 43)
        Me.cmbSYOCHI_EIGYO_TANTO.Name = "cmbSYOCHI_EIGYO_TANTO"
        Me.cmbSYOCHI_EIGYO_TANTO.NullValue = " "
        Me.cmbSYOCHI_EIGYO_TANTO.Size = New System.Drawing.Size(100, 25)
        Me.cmbSYOCHI_EIGYO_TANTO.TabIndex = 7
        Me.cmbSYOCHI_EIGYO_TANTO.Text = "(選択)"
        Me.cmbSYOCHI_EIGYO_TANTO.ValueMember = "VALUE"
        '
        'cmbSYOCHI_KANRI_TANTO
        '
        Me.cmbSYOCHI_KANRI_TANTO.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cmbSYOCHI_KANRI_TANTO.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cmbSYOCHI_KANRI_TANTO.BackColor = System.Drawing.SystemColors.Window
        Me.cmbSYOCHI_KANRI_TANTO.Cursor = System.Windows.Forms.Cursors.Default
        Me.cmbSYOCHI_KANRI_TANTO.DisplayMember = "DISP"
        Me.cmbSYOCHI_KANRI_TANTO.DropDownWidth = 230
        Me.cmbSYOCHI_KANRI_TANTO.Font = New System.Drawing.Font("Meiryo UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.cmbSYOCHI_KANRI_TANTO.ForeColor = System.Drawing.SystemColors.ControlText
        Me.cmbSYOCHI_KANRI_TANTO.FormattingEnabled = True
        Me.cmbSYOCHI_KANRI_TANTO.HorizontalContentAlignment = System.Drawing.StringAlignment.Near
        Me.cmbSYOCHI_KANRI_TANTO.ImeMode = System.Windows.Forms.ImeMode.[On]
        Me.cmbSYOCHI_KANRI_TANTO.IsSelected = False
        Me.cmbSYOCHI_KANRI_TANTO.Location = New System.Drawing.Point(427, 43)
        Me.cmbSYOCHI_KANRI_TANTO.Name = "cmbSYOCHI_KANRI_TANTO"
        Me.cmbSYOCHI_KANRI_TANTO.NullValue = " "
        Me.cmbSYOCHI_KANRI_TANTO.Size = New System.Drawing.Size(100, 25)
        Me.cmbSYOCHI_KANRI_TANTO.TabIndex = 9
        Me.cmbSYOCHI_KANRI_TANTO.Text = "(選択)"
        Me.cmbSYOCHI_KANRI_TANTO.ValueMember = "VALUE"
        '
        'dtSYOCHI_GM_TANTO
        '
        Me.dtSYOCHI_GM_TANTO.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.dtSYOCHI_GM_TANTO.GotFocusedColor = System.Drawing.Color.FromArgb(CType(CType(190, Byte), Integer), CType(CType(180, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.dtSYOCHI_GM_TANTO.Location = New System.Drawing.Point(3, 73)
        Me.dtSYOCHI_GM_TANTO.MaxDate = New Date(9998, 12, 31, 0, 0, 0, 0)
        Me.dtSYOCHI_GM_TANTO.MinDate = New Date(1753, 1, 1, 0, 0, 0, 0)
        Me.dtSYOCHI_GM_TANTO.MinimumSize = New System.Drawing.Size(98, 24)
        Me.dtSYOCHI_GM_TANTO.Name = "dtSYOCHI_GM_TANTO"
        Me.dtSYOCHI_GM_TANTO.ReadOnly = False
        Me.dtSYOCHI_GM_TANTO.Size = New System.Drawing.Size(100, 24)
        Me.dtSYOCHI_GM_TANTO.TabIndex = 2
        Me.dtSYOCHI_GM_TANTO.Value = ""
        Me.dtSYOCHI_GM_TANTO.ValueNonFormat = ""
        '
        'cmbSYOCHI_SEIZO_TANTO
        '
        Me.cmbSYOCHI_SEIZO_TANTO.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cmbSYOCHI_SEIZO_TANTO.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cmbSYOCHI_SEIZO_TANTO.BackColor = System.Drawing.SystemColors.Window
        Me.cmbSYOCHI_SEIZO_TANTO.Cursor = System.Windows.Forms.Cursors.Default
        Me.cmbSYOCHI_SEIZO_TANTO.DisplayMember = "DISP"
        Me.cmbSYOCHI_SEIZO_TANTO.DropDownWidth = 230
        Me.cmbSYOCHI_SEIZO_TANTO.Font = New System.Drawing.Font("Meiryo UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.cmbSYOCHI_SEIZO_TANTO.ForeColor = System.Drawing.SystemColors.ControlText
        Me.cmbSYOCHI_SEIZO_TANTO.FormattingEnabled = True
        Me.cmbSYOCHI_SEIZO_TANTO.HorizontalContentAlignment = System.Drawing.StringAlignment.Near
        Me.cmbSYOCHI_SEIZO_TANTO.ImeMode = System.Windows.Forms.ImeMode.[On]
        Me.cmbSYOCHI_SEIZO_TANTO.IsSelected = False
        Me.cmbSYOCHI_SEIZO_TANTO.Location = New System.Drawing.Point(533, 43)
        Me.cmbSYOCHI_SEIZO_TANTO.Name = "cmbSYOCHI_SEIZO_TANTO"
        Me.cmbSYOCHI_SEIZO_TANTO.NullValue = " "
        Me.cmbSYOCHI_SEIZO_TANTO.Size = New System.Drawing.Size(100, 25)
        Me.cmbSYOCHI_SEIZO_TANTO.TabIndex = 11
        Me.cmbSYOCHI_SEIZO_TANTO.Text = "(選択)"
        Me.cmbSYOCHI_SEIZO_TANTO.ValueMember = "VALUE"
        '
        'cmbSYOCHI_HINSYO_TANTO
        '
        Me.cmbSYOCHI_HINSYO_TANTO.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cmbSYOCHI_HINSYO_TANTO.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cmbSYOCHI_HINSYO_TANTO.BackColor = System.Drawing.SystemColors.Window
        Me.cmbSYOCHI_HINSYO_TANTO.Cursor = System.Windows.Forms.Cursors.Default
        Me.cmbSYOCHI_HINSYO_TANTO.DisplayMember = "DISP"
        Me.cmbSYOCHI_HINSYO_TANTO.DropDownWidth = 230
        Me.cmbSYOCHI_HINSYO_TANTO.Font = New System.Drawing.Font("Meiryo UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.cmbSYOCHI_HINSYO_TANTO.ForeColor = System.Drawing.SystemColors.ControlText
        Me.cmbSYOCHI_HINSYO_TANTO.FormattingEnabled = True
        Me.cmbSYOCHI_HINSYO_TANTO.HorizontalContentAlignment = System.Drawing.StringAlignment.Near
        Me.cmbSYOCHI_HINSYO_TANTO.ImeMode = System.Windows.Forms.ImeMode.[On]
        Me.cmbSYOCHI_HINSYO_TANTO.IsSelected = False
        Me.cmbSYOCHI_HINSYO_TANTO.Location = New System.Drawing.Point(639, 43)
        Me.cmbSYOCHI_HINSYO_TANTO.Name = "cmbSYOCHI_HINSYO_TANTO"
        Me.cmbSYOCHI_HINSYO_TANTO.NullValue = " "
        Me.cmbSYOCHI_HINSYO_TANTO.Size = New System.Drawing.Size(100, 25)
        Me.cmbSYOCHI_HINSYO_TANTO.TabIndex = 13
        Me.cmbSYOCHI_HINSYO_TANTO.Text = "(選択)"
        Me.cmbSYOCHI_HINSYO_TANTO.ValueMember = "VALUE"
        '
        'cmbSYOCHI_KENSA_TANTO
        '
        Me.cmbSYOCHI_KENSA_TANTO.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cmbSYOCHI_KENSA_TANTO.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cmbSYOCHI_KENSA_TANTO.BackColor = System.Drawing.SystemColors.Window
        Me.cmbSYOCHI_KENSA_TANTO.Cursor = System.Windows.Forms.Cursors.Default
        Me.cmbSYOCHI_KENSA_TANTO.DisplayMember = "DISP"
        Me.cmbSYOCHI_KENSA_TANTO.DropDownWidth = 230
        Me.cmbSYOCHI_KENSA_TANTO.Font = New System.Drawing.Font("Meiryo UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.cmbSYOCHI_KENSA_TANTO.ForeColor = System.Drawing.SystemColors.ControlText
        Me.cmbSYOCHI_KENSA_TANTO.FormattingEnabled = True
        Me.cmbSYOCHI_KENSA_TANTO.HorizontalContentAlignment = System.Drawing.StringAlignment.Near
        Me.cmbSYOCHI_KENSA_TANTO.ImeMode = System.Windows.Forms.ImeMode.[On]
        Me.cmbSYOCHI_KENSA_TANTO.IsSelected = False
        Me.cmbSYOCHI_KENSA_TANTO.Location = New System.Drawing.Point(745, 43)
        Me.cmbSYOCHI_KENSA_TANTO.Name = "cmbSYOCHI_KENSA_TANTO"
        Me.cmbSYOCHI_KENSA_TANTO.NullValue = " "
        Me.cmbSYOCHI_KENSA_TANTO.Size = New System.Drawing.Size(100, 25)
        Me.cmbSYOCHI_KENSA_TANTO.TabIndex = 15
        Me.cmbSYOCHI_KENSA_TANTO.Text = "(選択)"
        Me.cmbSYOCHI_KENSA_TANTO.ValueMember = "VALUE"
        '
        'cmbSYOCHI_KOBAI_TANTO
        '
        Me.cmbSYOCHI_KOBAI_TANTO.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cmbSYOCHI_KOBAI_TANTO.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cmbSYOCHI_KOBAI_TANTO.BackColor = System.Drawing.SystemColors.Window
        Me.cmbSYOCHI_KOBAI_TANTO.Cursor = System.Windows.Forms.Cursors.Default
        Me.cmbSYOCHI_KOBAI_TANTO.DisplayMember = "DISP"
        Me.cmbSYOCHI_KOBAI_TANTO.DropDownWidth = 230
        Me.cmbSYOCHI_KOBAI_TANTO.Font = New System.Drawing.Font("Meiryo UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.cmbSYOCHI_KOBAI_TANTO.ForeColor = System.Drawing.SystemColors.ControlText
        Me.cmbSYOCHI_KOBAI_TANTO.FormattingEnabled = True
        Me.cmbSYOCHI_KOBAI_TANTO.HorizontalContentAlignment = System.Drawing.StringAlignment.Near
        Me.cmbSYOCHI_KOBAI_TANTO.ImeMode = System.Windows.Forms.ImeMode.[On]
        Me.cmbSYOCHI_KOBAI_TANTO.IsSelected = False
        Me.cmbSYOCHI_KOBAI_TANTO.Location = New System.Drawing.Point(851, 43)
        Me.cmbSYOCHI_KOBAI_TANTO.Name = "cmbSYOCHI_KOBAI_TANTO"
        Me.cmbSYOCHI_KOBAI_TANTO.NullValue = " "
        Me.cmbSYOCHI_KOBAI_TANTO.Size = New System.Drawing.Size(100, 25)
        Me.cmbSYOCHI_KOBAI_TANTO.TabIndex = 17
        Me.cmbSYOCHI_KOBAI_TANTO.Text = "(選択)"
        Me.cmbSYOCHI_KOBAI_TANTO.ValueMember = "VALUE"
        '
        'cmbKAKUNIN_GM_TANTO
        '
        Me.cmbKAKUNIN_GM_TANTO.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cmbKAKUNIN_GM_TANTO.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cmbKAKUNIN_GM_TANTO.BackColor = System.Drawing.SystemColors.Window
        Me.cmbKAKUNIN_GM_TANTO.Cursor = System.Windows.Forms.Cursors.Default
        Me.cmbKAKUNIN_GM_TANTO.DisplayMember = "DISP"
        Me.cmbKAKUNIN_GM_TANTO.DropDownWidth = 230
        Me.cmbKAKUNIN_GM_TANTO.Font = New System.Drawing.Font("Meiryo UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.cmbKAKUNIN_GM_TANTO.ForeColor = System.Drawing.SystemColors.ControlText
        Me.cmbKAKUNIN_GM_TANTO.FormattingEnabled = True
        Me.cmbKAKUNIN_GM_TANTO.HorizontalContentAlignment = System.Drawing.StringAlignment.Near
        Me.cmbKAKUNIN_GM_TANTO.ImeMode = System.Windows.Forms.ImeMode.[On]
        Me.cmbKAKUNIN_GM_TANTO.IsSelected = False
        Me.cmbKAKUNIN_GM_TANTO.Location = New System.Drawing.Point(993, 43)
        Me.cmbKAKUNIN_GM_TANTO.Name = "cmbKAKUNIN_GM_TANTO"
        Me.cmbKAKUNIN_GM_TANTO.NullValue = " "
        Me.cmbKAKUNIN_GM_TANTO.Size = New System.Drawing.Size(100, 25)
        Me.cmbKAKUNIN_GM_TANTO.TabIndex = 19
        Me.cmbKAKUNIN_GM_TANTO.Text = "(選択)"
        Me.cmbKAKUNIN_GM_TANTO.ValueMember = "VALUE"
        '
        'cmbKAKUNIN_CM_TANTO
        '
        Me.cmbKAKUNIN_CM_TANTO.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cmbKAKUNIN_CM_TANTO.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cmbKAKUNIN_CM_TANTO.BackColor = System.Drawing.SystemColors.Window
        Me.cmbKAKUNIN_CM_TANTO.Cursor = System.Windows.Forms.Cursors.Default
        Me.cmbKAKUNIN_CM_TANTO.DisplayMember = "DISP"
        Me.cmbKAKUNIN_CM_TANTO.DropDownWidth = 230
        Me.cmbKAKUNIN_CM_TANTO.Font = New System.Drawing.Font("Meiryo UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.cmbKAKUNIN_CM_TANTO.ForeColor = System.Drawing.SystemColors.ControlText
        Me.cmbKAKUNIN_CM_TANTO.FormattingEnabled = True
        Me.cmbKAKUNIN_CM_TANTO.HorizontalContentAlignment = System.Drawing.StringAlignment.Near
        Me.cmbKAKUNIN_CM_TANTO.ImeMode = System.Windows.Forms.ImeMode.[On]
        Me.cmbKAKUNIN_CM_TANTO.IsSelected = False
        Me.cmbKAKUNIN_CM_TANTO.Location = New System.Drawing.Point(1099, 43)
        Me.cmbKAKUNIN_CM_TANTO.Name = "cmbKAKUNIN_CM_TANTO"
        Me.cmbKAKUNIN_CM_TANTO.NullValue = " "
        Me.cmbKAKUNIN_CM_TANTO.Size = New System.Drawing.Size(100, 25)
        Me.cmbKAKUNIN_CM_TANTO.TabIndex = 21
        Me.cmbKAKUNIN_CM_TANTO.Text = "(選択)"
        Me.cmbKAKUNIN_CM_TANTO.ValueMember = "VALUE"
        '
        'dtSYOCHI_SEKKEI_TANTO
        '
        Me.dtSYOCHI_SEKKEI_TANTO.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.dtSYOCHI_SEKKEI_TANTO.GotFocusedColor = System.Drawing.Color.FromArgb(CType(CType(190, Byte), Integer), CType(CType(180, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.dtSYOCHI_SEKKEI_TANTO.Location = New System.Drawing.Point(109, 73)
        Me.dtSYOCHI_SEKKEI_TANTO.MaxDate = New Date(9998, 12, 31, 0, 0, 0, 0)
        Me.dtSYOCHI_SEKKEI_TANTO.MinDate = New Date(1753, 1, 1, 0, 0, 0, 0)
        Me.dtSYOCHI_SEKKEI_TANTO.MinimumSize = New System.Drawing.Size(98, 24)
        Me.dtSYOCHI_SEKKEI_TANTO.Name = "dtSYOCHI_SEKKEI_TANTO"
        Me.dtSYOCHI_SEKKEI_TANTO.ReadOnly = False
        Me.dtSYOCHI_SEKKEI_TANTO.Size = New System.Drawing.Size(100, 24)
        Me.dtSYOCHI_SEKKEI_TANTO.TabIndex = 4
        Me.dtSYOCHI_SEKKEI_TANTO.Value = ""
        Me.dtSYOCHI_SEKKEI_TANTO.ValueNonFormat = ""
        '
        'dtSYOCHI_SEIGI_TANTO
        '
        Me.dtSYOCHI_SEIGI_TANTO.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.dtSYOCHI_SEIGI_TANTO.GotFocusedColor = System.Drawing.Color.FromArgb(CType(CType(190, Byte), Integer), CType(CType(180, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.dtSYOCHI_SEIGI_TANTO.Location = New System.Drawing.Point(215, 73)
        Me.dtSYOCHI_SEIGI_TANTO.MaxDate = New Date(9998, 12, 31, 0, 0, 0, 0)
        Me.dtSYOCHI_SEIGI_TANTO.MinDate = New Date(1753, 1, 1, 0, 0, 0, 0)
        Me.dtSYOCHI_SEIGI_TANTO.MinimumSize = New System.Drawing.Size(98, 24)
        Me.dtSYOCHI_SEIGI_TANTO.Name = "dtSYOCHI_SEIGI_TANTO"
        Me.dtSYOCHI_SEIGI_TANTO.ReadOnly = False
        Me.dtSYOCHI_SEIGI_TANTO.Size = New System.Drawing.Size(100, 24)
        Me.dtSYOCHI_SEIGI_TANTO.TabIndex = 6
        Me.dtSYOCHI_SEIGI_TANTO.Value = ""
        Me.dtSYOCHI_SEIGI_TANTO.ValueNonFormat = ""
        '
        'dtSYOCHI_EIGYO_TANTO
        '
        Me.dtSYOCHI_EIGYO_TANTO.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.dtSYOCHI_EIGYO_TANTO.GotFocusedColor = System.Drawing.Color.FromArgb(CType(CType(190, Byte), Integer), CType(CType(180, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.dtSYOCHI_EIGYO_TANTO.Location = New System.Drawing.Point(321, 73)
        Me.dtSYOCHI_EIGYO_TANTO.MaxDate = New Date(9998, 12, 31, 0, 0, 0, 0)
        Me.dtSYOCHI_EIGYO_TANTO.MinDate = New Date(1753, 1, 1, 0, 0, 0, 0)
        Me.dtSYOCHI_EIGYO_TANTO.MinimumSize = New System.Drawing.Size(98, 24)
        Me.dtSYOCHI_EIGYO_TANTO.Name = "dtSYOCHI_EIGYO_TANTO"
        Me.dtSYOCHI_EIGYO_TANTO.ReadOnly = False
        Me.dtSYOCHI_EIGYO_TANTO.Size = New System.Drawing.Size(100, 24)
        Me.dtSYOCHI_EIGYO_TANTO.TabIndex = 8
        Me.dtSYOCHI_EIGYO_TANTO.Value = ""
        Me.dtSYOCHI_EIGYO_TANTO.ValueNonFormat = ""
        '
        'dtSYOCHI_KANRI_TANTO
        '
        Me.dtSYOCHI_KANRI_TANTO.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.dtSYOCHI_KANRI_TANTO.GotFocusedColor = System.Drawing.Color.FromArgb(CType(CType(190, Byte), Integer), CType(CType(180, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.dtSYOCHI_KANRI_TANTO.Location = New System.Drawing.Point(427, 73)
        Me.dtSYOCHI_KANRI_TANTO.MaxDate = New Date(9998, 12, 31, 0, 0, 0, 0)
        Me.dtSYOCHI_KANRI_TANTO.MinDate = New Date(1753, 1, 1, 0, 0, 0, 0)
        Me.dtSYOCHI_KANRI_TANTO.MinimumSize = New System.Drawing.Size(98, 24)
        Me.dtSYOCHI_KANRI_TANTO.Name = "dtSYOCHI_KANRI_TANTO"
        Me.dtSYOCHI_KANRI_TANTO.ReadOnly = False
        Me.dtSYOCHI_KANRI_TANTO.Size = New System.Drawing.Size(100, 24)
        Me.dtSYOCHI_KANRI_TANTO.TabIndex = 10
        Me.dtSYOCHI_KANRI_TANTO.Value = ""
        Me.dtSYOCHI_KANRI_TANTO.ValueNonFormat = ""
        '
        'dtSYOCHI_SEIZO_TANTO
        '
        Me.dtSYOCHI_SEIZO_TANTO.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.dtSYOCHI_SEIZO_TANTO.GotFocusedColor = System.Drawing.Color.FromArgb(CType(CType(190, Byte), Integer), CType(CType(180, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.dtSYOCHI_SEIZO_TANTO.Location = New System.Drawing.Point(533, 73)
        Me.dtSYOCHI_SEIZO_TANTO.MaxDate = New Date(9998, 12, 31, 0, 0, 0, 0)
        Me.dtSYOCHI_SEIZO_TANTO.MinDate = New Date(1753, 1, 1, 0, 0, 0, 0)
        Me.dtSYOCHI_SEIZO_TANTO.MinimumSize = New System.Drawing.Size(98, 24)
        Me.dtSYOCHI_SEIZO_TANTO.Name = "dtSYOCHI_SEIZO_TANTO"
        Me.dtSYOCHI_SEIZO_TANTO.ReadOnly = False
        Me.dtSYOCHI_SEIZO_TANTO.Size = New System.Drawing.Size(100, 24)
        Me.dtSYOCHI_SEIZO_TANTO.TabIndex = 12
        Me.dtSYOCHI_SEIZO_TANTO.Value = ""
        Me.dtSYOCHI_SEIZO_TANTO.ValueNonFormat = ""
        '
        'dtSYOCHI_HINSYO_TANTO
        '
        Me.dtSYOCHI_HINSYO_TANTO.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.dtSYOCHI_HINSYO_TANTO.GotFocusedColor = System.Drawing.Color.FromArgb(CType(CType(190, Byte), Integer), CType(CType(180, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.dtSYOCHI_HINSYO_TANTO.Location = New System.Drawing.Point(639, 73)
        Me.dtSYOCHI_HINSYO_TANTO.MaxDate = New Date(9998, 12, 31, 0, 0, 0, 0)
        Me.dtSYOCHI_HINSYO_TANTO.MinDate = New Date(1753, 1, 1, 0, 0, 0, 0)
        Me.dtSYOCHI_HINSYO_TANTO.MinimumSize = New System.Drawing.Size(98, 24)
        Me.dtSYOCHI_HINSYO_TANTO.Name = "dtSYOCHI_HINSYO_TANTO"
        Me.dtSYOCHI_HINSYO_TANTO.ReadOnly = False
        Me.dtSYOCHI_HINSYO_TANTO.Size = New System.Drawing.Size(100, 24)
        Me.dtSYOCHI_HINSYO_TANTO.TabIndex = 14
        Me.dtSYOCHI_HINSYO_TANTO.Value = ""
        Me.dtSYOCHI_HINSYO_TANTO.ValueNonFormat = ""
        '
        'dtSYOCHI_KENSA_TANTO
        '
        Me.dtSYOCHI_KENSA_TANTO.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.dtSYOCHI_KENSA_TANTO.GotFocusedColor = System.Drawing.Color.FromArgb(CType(CType(190, Byte), Integer), CType(CType(180, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.dtSYOCHI_KENSA_TANTO.Location = New System.Drawing.Point(745, 73)
        Me.dtSYOCHI_KENSA_TANTO.MaxDate = New Date(9998, 12, 31, 0, 0, 0, 0)
        Me.dtSYOCHI_KENSA_TANTO.MinDate = New Date(1753, 1, 1, 0, 0, 0, 0)
        Me.dtSYOCHI_KENSA_TANTO.MinimumSize = New System.Drawing.Size(98, 24)
        Me.dtSYOCHI_KENSA_TANTO.Name = "dtSYOCHI_KENSA_TANTO"
        Me.dtSYOCHI_KENSA_TANTO.ReadOnly = False
        Me.dtSYOCHI_KENSA_TANTO.Size = New System.Drawing.Size(100, 24)
        Me.dtSYOCHI_KENSA_TANTO.TabIndex = 16
        Me.dtSYOCHI_KENSA_TANTO.Value = ""
        Me.dtSYOCHI_KENSA_TANTO.ValueNonFormat = ""
        '
        'dtSYOCHI_KOBAI_TANTO
        '
        Me.dtSYOCHI_KOBAI_TANTO.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.dtSYOCHI_KOBAI_TANTO.GotFocusedColor = System.Drawing.Color.FromArgb(CType(CType(190, Byte), Integer), CType(CType(180, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.dtSYOCHI_KOBAI_TANTO.Location = New System.Drawing.Point(851, 73)
        Me.dtSYOCHI_KOBAI_TANTO.MaxDate = New Date(9998, 12, 31, 0, 0, 0, 0)
        Me.dtSYOCHI_KOBAI_TANTO.MinDate = New Date(1753, 1, 1, 0, 0, 0, 0)
        Me.dtSYOCHI_KOBAI_TANTO.MinimumSize = New System.Drawing.Size(98, 24)
        Me.dtSYOCHI_KOBAI_TANTO.Name = "dtSYOCHI_KOBAI_TANTO"
        Me.dtSYOCHI_KOBAI_TANTO.ReadOnly = False
        Me.dtSYOCHI_KOBAI_TANTO.Size = New System.Drawing.Size(100, 24)
        Me.dtSYOCHI_KOBAI_TANTO.TabIndex = 18
        Me.dtSYOCHI_KOBAI_TANTO.Value = ""
        Me.dtSYOCHI_KOBAI_TANTO.ValueNonFormat = ""
        '
        'dtKAKUNIN_GM_TANTO
        '
        Me.dtKAKUNIN_GM_TANTO.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.dtKAKUNIN_GM_TANTO.GotFocusedColor = System.Drawing.Color.FromArgb(CType(CType(190, Byte), Integer), CType(CType(180, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.dtKAKUNIN_GM_TANTO.Location = New System.Drawing.Point(993, 73)
        Me.dtKAKUNIN_GM_TANTO.MaxDate = New Date(9998, 12, 31, 0, 0, 0, 0)
        Me.dtKAKUNIN_GM_TANTO.MinDate = New Date(1753, 1, 1, 0, 0, 0, 0)
        Me.dtKAKUNIN_GM_TANTO.MinimumSize = New System.Drawing.Size(98, 24)
        Me.dtKAKUNIN_GM_TANTO.Name = "dtKAKUNIN_GM_TANTO"
        Me.dtKAKUNIN_GM_TANTO.ReadOnly = False
        Me.dtKAKUNIN_GM_TANTO.Size = New System.Drawing.Size(100, 24)
        Me.dtKAKUNIN_GM_TANTO.TabIndex = 20
        Me.dtKAKUNIN_GM_TANTO.Value = ""
        Me.dtKAKUNIN_GM_TANTO.ValueNonFormat = ""
        '
        'dtKAKUNIN_CM_TANTO
        '
        Me.dtKAKUNIN_CM_TANTO.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.dtKAKUNIN_CM_TANTO.GotFocusedColor = System.Drawing.Color.FromArgb(CType(CType(190, Byte), Integer), CType(CType(180, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.dtKAKUNIN_CM_TANTO.Location = New System.Drawing.Point(1099, 73)
        Me.dtKAKUNIN_CM_TANTO.MaxDate = New Date(9998, 12, 31, 0, 0, 0, 0)
        Me.dtKAKUNIN_CM_TANTO.MinDate = New Date(1753, 1, 1, 0, 0, 0, 0)
        Me.dtKAKUNIN_CM_TANTO.MinimumSize = New System.Drawing.Size(98, 24)
        Me.dtKAKUNIN_CM_TANTO.Name = "dtKAKUNIN_CM_TANTO"
        Me.dtKAKUNIN_CM_TANTO.ReadOnly = False
        Me.dtKAKUNIN_CM_TANTO.Size = New System.Drawing.Size(100, 24)
        Me.dtKAKUNIN_CM_TANTO.TabIndex = 22
        Me.dtKAKUNIN_CM_TANTO.Value = ""
        Me.dtKAKUNIN_CM_TANTO.ValueNonFormat = ""
        '
        'PanelEx1
        '
        Me.PanelEx1.Controls.Add(Me.Label15)
        Me.PanelEx1.Controls.Add(Me.flxDATA_5)
        Me.PanelEx1.Controls.Add(Me.mtxSNO_APPLY_PERIOD_HENKO_SINGI)
        Me.PanelEx1.Dock = System.Windows.Forms.DockStyle.Top
        Me.PanelEx1.HitEnabled = False
        Me.PanelEx1.Location = New System.Drawing.Point(0, 0)
        Me.PanelEx1.Name = "PanelEx1"
        Me.PanelEx1.Size = New System.Drawing.Size(1207, 176)
        Me.PanelEx1.TabIndex = 269
        '
        'Label15
        '
        Me.Label15.Font = New System.Drawing.Font("Meiryo UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label15.Location = New System.Drawing.Point(3, 7)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(121, 30)
        Me.Label15.TabIndex = 0
        Me.Label15.Text = "SNo./号機 時期等:"
        Me.Label15.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'flxDATA_5
        '
        Me.flxDATA_5.AllowDragging = C1.Win.C1FlexGrid.AllowDraggingEnum.None
        Me.flxDATA_5.AllowSorting = C1.Win.C1FlexGrid.AllowSortingEnum.None
        Me.flxDATA_5.AutoClipboard = True
        Me.flxDATA_5.AutoGenerateColumns = False
        Me.flxDATA_5.AutoSearch = C1.Win.C1FlexGrid.AutoSearchEnum.FromTop
        Me.flxDATA_5.BorderStyle = C1.Win.C1FlexGrid.Util.BaseControls.BorderStyleEnum.Light3D
        Me.flxDATA_5.ColumnInfo = resources.GetString("flxDATA_5.ColumnInfo")
        Me.flxDATA_5.DataSource = Me.Flx4_DS
        Me.flxDATA_5.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.flxDATA_5.Location = New System.Drawing.Point(0, 40)
        Me.flxDATA_5.Name = "flxDATA_5"
        Me.flxDATA_5.Rows.Count = 1
        Me.flxDATA_5.Rows.DefaultSize = 18
        Me.flxDATA_5.Size = New System.Drawing.Size(1207, 136)
        Me.flxDATA_5.StyleInfo = resources.GetString("flxDATA_5.StyleInfo")
        Me.flxDATA_5.TabIndex = 2
        Me.flxDATA_5.VisualStyle = C1.Win.C1FlexGrid.VisualStyle.Office2010Silver
        '
        'mtxSNO_APPLY_PERIOD_HENKO_SINGI
        '
        Me.mtxSNO_APPLY_PERIOD_HENKO_SINGI.BackColor = System.Drawing.SystemColors.Control
        Me.mtxSNO_APPLY_PERIOD_HENKO_SINGI.Font = New System.Drawing.Font("Meiryo UI", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.mtxSNO_APPLY_PERIOD_HENKO_SINGI.ImeMode = System.Windows.Forms.ImeMode.[On]
        Me.mtxSNO_APPLY_PERIOD_HENKO_SINGI.InputRequired = False
        Me.mtxSNO_APPLY_PERIOD_HENKO_SINGI.Location = New System.Drawing.Point(130, 10)
        Me.mtxSNO_APPLY_PERIOD_HENKO_SINGI.MaxByteLength = 0
        Me.mtxSNO_APPLY_PERIOD_HENKO_SINGI.Name = "mtxSNO_APPLY_PERIOD_HENKO_SINGI"
        Me.mtxSNO_APPLY_PERIOD_HENKO_SINGI.ReadOnly = True
        Me.mtxSNO_APPLY_PERIOD_HENKO_SINGI.SelectAllText = False
        Me.mtxSNO_APPLY_PERIOD_HENKO_SINGI.Size = New System.Drawing.Size(214, 24)
        Me.mtxSNO_APPLY_PERIOD_HENKO_SINGI.TabIndex = 1
        Me.mtxSNO_APPLY_PERIOD_HENKO_SINGI.WatermarkColor = System.Drawing.Color.Empty
        Me.mtxSNO_APPLY_PERIOD_HENKO_SINGI.WatermarkText = Nothing
        '
        'C1SplitterPanel5
        '
        Me.C1SplitterPanel5.Height = 10
        Me.C1SplitterPanel5.Location = New System.Drawing.Point(1, 1289)
        Me.C1SplitterPanel5.MinHeight = 10
        Me.C1SplitterPanel5.Name = "C1SplitterPanel5"
        Me.C1SplitterPanel5.Size = New System.Drawing.Size(1207, 10)
        Me.C1SplitterPanel5.SizeRatio = 10.0R
        Me.C1SplitterPanel5.TabIndex = 4
        '
        'FrmG0021_Detail
        '
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None
        Me.ClientSize = New System.Drawing.Size(1264, 711)
        Me.Controls.Add(Me.cmbDestTANTO)
        Me.Controls.Add(Me.dtUPD_YMD)
        Me.Controls.Add(Me.flpnlStageIndex)
        Me.Controls.Add(Me.lblDestTanto)
        Me.Controls.Add(Me.Label48)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.PanelEx2)
        Me.Controls.Add(Me.TabControl1)
        Me.HelpButton = True
        Me.MinimumSize = New System.Drawing.Size(1280, 750)
        Me.Name = "FrmG0021_Detail"
        Me.ShowStatusBar = True
        Me.Text = ""
        Me.Controls.SetChildIndex(Me.TabControl1, 0)
        Me.Controls.SetChildIndex(Me.PanelEx2, 0)
        Me.Controls.SetChildIndex(Me.Label1, 0)
        Me.Controls.SetChildIndex(Me.lblTytle, 0)
        Me.Controls.SetChildIndex(Me.cmdFunc2, 0)
        Me.Controls.SetChildIndex(Me.cmdFunc3, 0)
        Me.Controls.SetChildIndex(Me.cmdFunc4, 0)
        Me.Controls.SetChildIndex(Me.cmdFunc5, 0)
        Me.Controls.SetChildIndex(Me.cmdFunc6, 0)
        Me.Controls.SetChildIndex(Me.cmdFunc1, 0)
        Me.Controls.SetChildIndex(Me.cmdFunc9, 0)
        Me.Controls.SetChildIndex(Me.cmdFunc8, 0)
        Me.Controls.SetChildIndex(Me.cmdFunc10, 0)
        Me.Controls.SetChildIndex(Me.cmdFunc7, 0)
        Me.Controls.SetChildIndex(Me.cmdFunc11, 0)
        Me.Controls.SetChildIndex(Me.cmdFunc12, 0)
        Me.Controls.SetChildIndex(Me.lblRecordCount, 0)
        Me.Controls.SetChildIndex(Me.Label48, 0)
        Me.Controls.SetChildIndex(Me.lblDestTanto, 0)
        Me.Controls.SetChildIndex(Me.flpnlStageIndex, 0)
        Me.Controls.SetChildIndex(Me.dtUPD_YMD, 0)
        Me.Controls.SetChildIndex(Me.cmbDestTANTO, 0)
        CType(Me.ErrorProvider, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.WarningErrorProvider, System.ComponentModel.ISupportInitialize).EndInit()
        Me.PanelEx2.ResumeLayout(False)
        Me.tlpFilter.ResumeLayout(False)
        Me.tlpFilter.PerformLayout()
        Me.flpnlStageIndex.ResumeLayout(False)
        Me.TabControl1.ResumeLayout(False)
        Me.TabPageEx1.ResumeLayout(False)
        Me.TabPageEx1.PerformLayout()
        CType(Me.C1SplitContainer, System.ComponentModel.ISupportInitialize).EndInit()
        Me.C1SplitContainer.ResumeLayout(False)
        Me.C1SplitterPanel1.ResumeLayout(False)
        CType(Me.flxDATA_2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Flx2_DS, System.ComponentModel.ISupportInitialize).EndInit()
        Me.C1SplitterPanel2.ResumeLayout(False)
        CType(Me.flxDATA_3, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Flx3_DS, System.ComponentModel.ISupportInitialize).EndInit()
        Me.C1SplitterPanel3.ResumeLayout(False)
        CType(Me.flxDATA_4, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Flx4_DS, System.ComponentModel.ISupportInitialize).EndInit()
        Me.C1SplitterPanel4.ResumeLayout(False)
        Me.TableLayoutPanel1.ResumeLayout(False)
        Me.PanelEx1.ResumeLayout(False)
        Me.PanelEx1.PerformLayout()
        CType(Me.flxDATA_5, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents mtxFUTEKIGO_KB As MaskedTextBoxEx
    Friend WithEvents mtxFUTEKIGO_S_KB As MaskedTextBoxEx
    Friend WithEvents Label9 As Label
    Friend WithEvents Label10 As Label
    Friend WithEvents InfoToolTip As ToolTip
    Friend WithEvents Label3 As Label
    Friend WithEvents txtINPUT_NAIYO As TextBoxEx
    Friend WithEvents Label17 As Label
    Friend WithEvents cmbBUHIN_BANGO As ComboboxEx
    Friend WithEvents cmbKISYU As ComboboxEx
    Friend WithEvents Label8 As Label
    Friend WithEvents mtxFCCB_NO As MaskedTextBoxEx
    Friend WithEvents Label14 As Label
    Friend WithEvents Label4 As Label
    Friend WithEvents cmbBUMON As ComboboxEx
    Friend WithEvents Label5 As Label
    Friend WithEvents Label7 As Label
    Friend WithEvents cmbHINMEI As ComboboxEx
    Friend WithEvents lblKISO_TANTO As Label
    Friend WithEvents cmbKISO_TANTO As ComboboxEx
    Friend WithEvents lblCM_TANTO As Label
    Friend WithEvents cmbCM_TANTO As ComboboxEx
    Friend WithEvents lblSYANAI_CD As Label
    Friend WithEvents cmbSYANAI_CD As ComboboxEx
    Friend WithEvents Label16 As Label
    Friend WithEvents dtKISO As DateTextBoxEx
    Friend WithEvents PanelEx2 As PanelEx
    Friend WithEvents Label1 As Label
    Friend WithEvents tlpFilter As TableLayoutPanel
    Friend WithEvents mtxINPUT_DOC_NO As MaskedTextBoxEx
    Friend WithEvents mtxSNO_APPLY_PERIOD_KISO As MaskedTextBoxEx
    Friend WithEvents Label18 As Label
    Friend WithEvents flpnlStageIndex As FlowLayoutPanel
    Friend WithEvents rsbtnST01 As RibbonShapeRadioButton
    Friend WithEvents rsbtnST02 As RibbonShapeRadioButton
    Friend WithEvents rsbtnST03 As RibbonShapeRadioButton
    Friend WithEvents rsbtnST04 As RibbonShapeRadioButton
    Friend WithEvents rsbtnST05 As RibbonShapeRadioButton
    Friend WithEvents rsbtnST06 As RibbonShapeRadioButton
    Friend WithEvents rsbtnST99 As RibbonShapeRadioButton
    Friend WithEvents lblDestTanto As Label
    Friend WithEvents Label48 As Label
    Friend WithEvents cmbDestTANTO As ComboboxEx
    Friend WithEvents dtUPD_YMD As DateTextBoxEx
    Friend WithEvents TabControl1 As TabControl
    Friend WithEvents TabPageEx1 As TabPageEx
    Friend WithEvents Label11 As Label
    Friend WithEvents Label12 As Label
    Friend WithEvents Label13 As Label
    Friend WithEvents C1SplitContainer As C1.Win.C1SplitContainer.C1SplitContainer
    Friend WithEvents C1SplitterPanel1 As C1.Win.C1SplitContainer.C1SplitterPanel
    Friend WithEvents flxDATA_2 As C1.Win.C1FlexGrid.C1FlexGrid
    Friend WithEvents C1SplitterPanel2 As C1.Win.C1SplitContainer.C1SplitterPanel
    Friend WithEvents flxDATA_3 As C1.Win.C1FlexGrid.C1FlexGrid
    Friend WithEvents C1SplitterPanel3 As C1.Win.C1SplitContainer.C1SplitterPanel
    Friend WithEvents flxDATA_4 As C1.Win.C1FlexGrid.C1FlexGrid
    Friend WithEvents C1SplitterPanel4 As C1.Win.C1SplitContainer.C1SplitterPanel
    Friend WithEvents Label15 As Label
    Friend WithEvents mtxSNO_APPLY_PERIOD_HENKO_SINGI As MaskedTextBoxEx
    Friend WithEvents flxDATA_5 As C1.Win.C1FlexGrid.C1FlexGrid
    Friend WithEvents PanelEx1 As PanelEx
    Friend WithEvents TableLayoutPanel1 As TableLayoutPanel
    Friend WithEvents Flx2_DS As BindingSource
    Friend WithEvents Flx3_DS As BindingSource
    Friend WithEvents Flx4_DS As BindingSource
    Friend WithEvents Label2 As Label
    Friend WithEvents Label29 As Label
    Friend WithEvents Label28 As Label
    Friend WithEvents Label19 As Label
    Friend WithEvents Label20 As Label
    Friend WithEvents Label21 As Label
    Friend WithEvents Label22 As Label
    Friend WithEvents Label23 As Label
    Friend WithEvents Label24 As Label
    Friend WithEvents Label25 As Label
    Friend WithEvents Label27 As Label
    Friend WithEvents Label32 As Label
    Friend WithEvents Label31 As Label
    Friend WithEvents Label30 As Label
    Friend WithEvents cmbSYOCHI_GM_TANTO As ComboboxEx
    Friend WithEvents cmbSYOCHI_SEKKEI_TANTO As ComboboxEx
    Friend WithEvents cmbSYOCHI_SEIGI_TANTO As ComboboxEx
    Friend WithEvents cmbSYOCHI_EIGYO_TANTO As ComboboxEx
    Friend WithEvents cmbSYOCHI_KANRI_TANTO As ComboboxEx
    Friend WithEvents dtSYOCHI_GM_TANTO As DateTextBoxEx
    Friend WithEvents cmbSYOCHI_SEIZO_TANTO As ComboboxEx
    Friend WithEvents cmbSYOCHI_HINSYO_TANTO As ComboboxEx
    Friend WithEvents cmbSYOCHI_KENSA_TANTO As ComboboxEx
    Friend WithEvents cmbSYOCHI_KOBAI_TANTO As ComboboxEx
    Friend WithEvents cmbKAKUNIN_GM_TANTO As ComboboxEx
    Friend WithEvents cmbKAKUNIN_CM_TANTO As ComboboxEx
    Friend WithEvents dtSYOCHI_SEKKEI_TANTO As DateTextBoxEx
    Friend WithEvents dtSYOCHI_SEIGI_TANTO As DateTextBoxEx
    Friend WithEvents dtSYOCHI_EIGYO_TANTO As DateTextBoxEx
    Friend WithEvents dtSYOCHI_KANRI_TANTO As DateTextBoxEx
    Friend WithEvents dtSYOCHI_SEIZO_TANTO As DateTextBoxEx
    Friend WithEvents dtSYOCHI_HINSYO_TANTO As DateTextBoxEx
    Friend WithEvents dtSYOCHI_KENSA_TANTO As DateTextBoxEx
    Friend WithEvents dtSYOCHI_KOBAI_TANTO As DateTextBoxEx
    Friend WithEvents dtKAKUNIN_GM_TANTO As DateTextBoxEx
    Friend WithEvents dtKAKUNIN_CM_TANTO As DateTextBoxEx
    Friend WithEvents C1SplitterPanel5 As C1.Win.C1SplitContainer.C1SplitterPanel
End Class
