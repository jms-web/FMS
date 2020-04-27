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
        Me.TabSTAGE = New System.Windows.Forms.TabControl()
        Me.tabSTAGE01 = New JMS_COMMON.TabPageEx()
        Me.cmbST01_DestTANTO = New JMS_COMMON.ComboboxEx()
        Me.mtxST01_NextStageName = New JMS_COMMON.MaskedTextBoxEx()
        Me.Label123 = New System.Windows.Forms.Label()
        Me.Label124 = New System.Windows.Forms.Label()
        Me.Label139 = New System.Windows.Forms.Label()
        Me.mtxST01_UPD_YMD = New JMS_COMMON.MaskedTextBoxEx()
        Me.C1SplitContainer1 = New C1.Win.C1SplitContainer.C1SplitContainer()
        Me.sptPanel1 = New C1.Win.C1SplitContainer.C1SplitterPanel()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.flxDATA_2 = New C1.Win.C1FlexGrid.C1FlexGrid()
        Me.sptPanel2 = New C1.Win.C1SplitContainer.C1SplitterPanel()
        Me.flxDATA_3 = New C1.Win.C1FlexGrid.C1FlexGrid()
        Me.sptPanel3 = New C1.Win.C1SplitContainer.C1SplitterPanel()
        Me.flxDATA_4 = New C1.Win.C1FlexGrid.C1FlexGrid()
        Me.sptPanel4 = New C1.Win.C1SplitContainer.C1SplitterPanel()
        Me.flxDATA_5 = New C1.Win.C1FlexGrid.C1FlexGrid()
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
        Me.MaskedTextBoxEx2 = New JMS_COMMON.MaskedTextBoxEx()
        Me.Label18 = New System.Windows.Forms.Label()
        Me.MaskedTextBoxEx1 = New JMS_COMMON.MaskedTextBoxEx()
        Me.dtST05_UPD_YMD = New JMS_COMMON.DateTextBoxEx()
        Me.cmbDestTANTO = New JMS_COMMON.ComboboxEx()
        Me.Label48 = New System.Windows.Forms.Label()
        Me.lblDestTanto = New System.Windows.Forms.Label()
        CType(Me.ErrorProvider, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.WarningErrorProvider, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.TabSTAGE.SuspendLayout()
        Me.tabSTAGE01.SuspendLayout()
        CType(Me.C1SplitContainer1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.C1SplitContainer1.SuspendLayout()
        Me.sptPanel1.SuspendLayout()
        CType(Me.flxDATA_2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.sptPanel2.SuspendLayout()
        CType(Me.flxDATA_3, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.sptPanel3.SuspendLayout()
        CType(Me.flxDATA_4, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.sptPanel4.SuspendLayout()
        CType(Me.flxDATA_5, System.ComponentModel.ISupportInitialize).BeginInit()
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
        Me.cmdFunc1.Location = New System.Drawing.Point(9, 594)
        Me.cmdFunc1.Text = "保存(F1)"
        '
        'cmdFunc2
        '
        Me.cmdFunc2.Image = Global.FMS.My.Resources.Resources.申請
        Me.cmdFunc2.Location = New System.Drawing.Point(216, 594)
        Me.cmdFunc2.Text = "承認&&申請(F2)"
        '
        'cmdFunc3
        '
        Me.cmdFunc3.Location = New System.Drawing.Point(423, 594)
        '
        'cmdFunc4
        '
        Me.cmdFunc4.Image = Global.FMS.My.Resources.Resources._imgRight32x32
        Me.cmdFunc4.Location = New System.Drawing.Point(630, 594)
        Me.cmdFunc4.Text = "転送(F4)"
        '
        'cmdFunc5
        '
        Me.cmdFunc5.Image = Global.FMS.My.Resources.Resources._imgUndo32x32
        Me.cmdFunc5.Location = New System.Drawing.Point(837, 594)
        Me.cmdFunc5.Text = "差戻し(F5)"
        '
        'cmdFunc6
        '
        Me.cmdFunc6.Location = New System.Drawing.Point(1044, 594)
        '
        'cmdFunc12
        '
        Me.cmdFunc12.Image = Global.FMS.My.Resources.Resources._imgLog_Out32x32
        Me.cmdFunc12.Location = New System.Drawing.Point(1044, 642)
        Me.cmdFunc12.Text = "閉じる(F12)"
        '
        'cmdFunc11
        '
        Me.cmdFunc11.Image = Global.FMS.My.Resources.Resources.履歴
        Me.cmdFunc11.Location = New System.Drawing.Point(837, 642)
        Me.cmdFunc11.Text = "履歴表示(F11)"
        '
        'cmdFunc10
        '
        Me.cmdFunc10.Image = Global.FMS.My.Resources.Resources._imgPrint32x32
        Me.cmdFunc10.Location = New System.Drawing.Point(630, 642)
        Me.cmdFunc10.Text = "印刷プレビュー(F10)"
        '
        'cmdFunc7
        '
        Me.cmdFunc7.Location = New System.Drawing.Point(9, 642)
        '
        'cmdFunc9
        '
        Me.cmdFunc9.Location = New System.Drawing.Point(423, 642)
        '
        'cmdFunc8
        '
        Me.cmdFunc8.Location = New System.Drawing.Point(216, 642)
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
        Me.cmbBUHIN_BANGO.Location = New System.Drawing.Point(103, 63)
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
        Me.cmbKISYU.Location = New System.Drawing.Point(103, 33)
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
        Me.Label8.Location = New System.Drawing.Point(3, 0)
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
        Me.mtxHOKUKO_NO.Location = New System.Drawing.Point(103, 3)
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
        Me.cmbBUMON.TabIndex = 275
        Me.cmbBUMON.Text = "(選択)"
        Me.cmbBUMON.ValueMember = "VALUE"
        '
        'Label5
        '
        Me.tlpFilter.SetColumnSpan(Me.Label5, 5)
        Me.Label5.Font = New System.Drawing.Font("Meiryo UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
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
        Me.cmbHINMEI.TabIndex = 279
        Me.cmbHINMEI.Text = "(選択)"
        Me.cmbHINMEI.ValueMember = "VALUE"
        '
        'Label6
        '
        Me.tlpFilter.SetColumnSpan(Me.Label6, 5)
        Me.Label6.Font = New System.Drawing.Font("Meiryo UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label6.Location = New System.Drawing.Point(443, 0)
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
        Me.cmbKISO_TANTO.Location = New System.Drawing.Point(543, 3)
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
        Me.Label26.Location = New System.Drawing.Point(443, 30)
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
        Me.ComboboxEx1.Location = New System.Drawing.Point(543, 33)
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
        Me.cmbSYANAI_CD.TabIndex = 278
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
        'dtDraft
        '
        Me.dtDraft.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.tlpFilter.SetColumnSpan(Me.dtDraft, 5)
        Me.dtDraft.GotFocusedColor = System.Drawing.Color.FromArgb(CType(CType(190, Byte), Integer), CType(CType(180, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.dtDraft.Location = New System.Drawing.Point(343, 33)
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
        'TabSTAGE
        '
        Me.TabSTAGE.Controls.Add(Me.tabSTAGE01)
        Me.TabSTAGE.Font = New System.Drawing.Font("Meiryo UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.TabSTAGE.HotTrack = True
        Me.TabSTAGE.Location = New System.Drawing.Point(12, 261)
        Me.TabSTAGE.Multiline = True
        Me.TabSTAGE.Name = "TabSTAGE"
        Me.TabSTAGE.SelectedIndex = 0
        Me.TabSTAGE.Size = New System.Drawing.Size(1240, 327)
        Me.TabSTAGE.TabIndex = 218
        '
        'tabSTAGE01
        '
        Me.tabSTAGE01.AutoScroll = True
        Me.tabSTAGE01.BackColor = System.Drawing.SystemColors.Control
        Me.tabSTAGE01.Controls.Add(Me.cmbST01_DestTANTO)
        Me.tabSTAGE01.Controls.Add(Me.mtxST01_NextStageName)
        Me.tabSTAGE01.Controls.Add(Me.Label123)
        Me.tabSTAGE01.Controls.Add(Me.Label124)
        Me.tabSTAGE01.Controls.Add(Me.Label139)
        Me.tabSTAGE01.Controls.Add(Me.mtxST01_UPD_YMD)
        Me.tabSTAGE01.Controls.Add(Me.C1SplitContainer1)
        Me.tabSTAGE01.HitEnabled = False
        Me.tabSTAGE01.Location = New System.Drawing.Point(4, 26)
        Me.tabSTAGE01.Name = "tabSTAGE01"
        Me.tabSTAGE01.Padding = New System.Windows.Forms.Padding(3)
        Me.tabSTAGE01.Size = New System.Drawing.Size(1232, 297)
        Me.tabSTAGE01.TabIndex = 0
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
        'C1SplitContainer1
        '
        Me.C1SplitContainer1.AutoSizeElement = C1.Framework.AutoSizeElement.Both
        Me.C1SplitContainer1.BackColor = System.Drawing.Color.FromArgb(CType(CType(240, Byte), Integer), CType(CType(240, Byte), Integer), CType(CType(240, Byte), Integer))
        Me.C1SplitContainer1.BorderColor = System.Drawing.Color.Black
        Me.C1SplitContainer1.BorderWidth = 1
        Me.C1SplitContainer1.CollapsingCueColor = System.Drawing.Color.FromArgb(CType(CType(133, Byte), Integer), CType(CType(133, Byte), Integer), CType(CType(150, Byte), Integer))
        Me.C1SplitContainer1.Dock = System.Windows.Forms.DockStyle.Top
        Me.C1SplitContainer1.Font = New System.Drawing.Font("Meiryo UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.C1SplitContainer1.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.C1SplitContainer1.Location = New System.Drawing.Point(3, 3)
        Me.C1SplitContainer1.Name = "C1SplitContainer1"
        Me.C1SplitContainer1.Panels.Add(Me.sptPanel1)
        Me.C1SplitContainer1.Panels.Add(Me.sptPanel2)
        Me.C1SplitContainer1.Panels.Add(Me.sptPanel3)
        Me.C1SplitContainer1.Panels.Add(Me.sptPanel4)
        Me.C1SplitContainer1.Size = New System.Drawing.Size(1209, 781)
        Me.C1SplitContainer1.TabIndex = 327
        '
        'sptPanel1
        '
        Me.sptPanel1.AutoScroll = True
        Me.sptPanel1.Controls.Add(Me.flxDATA_2)
        Me.sptPanel1.Height = 388
        Me.sptPanel1.Location = New System.Drawing.Point(1, 22)
        Me.sptPanel1.Name = "sptPanel1"
        Me.sptPanel1.ResizeWhileDragging = True
        Me.sptPanel1.Size = New System.Drawing.Size(1207, 367)
        Me.sptPanel1.TabIndex = 0
        Me.sptPanel1.Text = "②要処置事項調査"
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
        'flxDATA_2
        '
        Me.flxDATA_2.AllowDragging = C1.Win.C1FlexGrid.AllowDraggingEnum.None
        Me.flxDATA_2.AllowSorting = C1.Win.C1FlexGrid.AllowSortingEnum.None
        Me.flxDATA_2.AutoClipboard = True
        Me.flxDATA_2.AutoGenerateColumns = False
        Me.flxDATA_2.AutoSearch = C1.Win.C1FlexGrid.AutoSearchEnum.FromTop
        Me.flxDATA_2.BorderStyle = C1.Win.C1FlexGrid.Util.BaseControls.BorderStyleEnum.Light3D
        Me.flxDATA_2.ColumnInfo = "10,1,0,0,0,90,Columns:"
        Me.flxDATA_2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.flxDATA_2.Location = New System.Drawing.Point(0, 0)
        Me.flxDATA_2.Name = "flxDATA_2"
        Me.flxDATA_2.Rows.Count = 1
        Me.flxDATA_2.Rows.DefaultSize = 18
        Me.flxDATA_2.Size = New System.Drawing.Size(1207, 367)
        Me.flxDATA_2.StyleInfo = resources.GetString("flxDATA_2.StyleInfo")
        Me.flxDATA_2.TabIndex = 0
        Me.flxDATA_2.VisualStyle = C1.Win.C1FlexGrid.VisualStyle.Office2010Silver
        '
        'sptPanel2
        '
        Me.sptPanel2.AutoScroll = True
        Me.sptPanel2.Controls.Add(Me.flxDATA_3)
        Me.sptPanel2.Height = 192
        Me.sptPanel2.Location = New System.Drawing.Point(1, 414)
        Me.sptPanel2.Name = "sptPanel2"
        Me.sptPanel2.ResizeWhileDragging = True
        Me.sptPanel2.Size = New System.Drawing.Size(1207, 171)
        Me.sptPanel2.TabIndex = 1
        Me.sptPanel2.Text = "③検証"
        '
        'flxDATA_3
        '
        Me.flxDATA_3.AllowDragging = C1.Win.C1FlexGrid.AllowDraggingEnum.None
        Me.flxDATA_3.AllowSorting = C1.Win.C1FlexGrid.AllowSortingEnum.None
        Me.flxDATA_3.AutoClipboard = True
        Me.flxDATA_3.AutoGenerateColumns = False
        Me.flxDATA_3.AutoSearch = C1.Win.C1FlexGrid.AutoSearchEnum.FromTop
        Me.flxDATA_3.BorderStyle = C1.Win.C1FlexGrid.Util.BaseControls.BorderStyleEnum.Light3D
        Me.flxDATA_3.ColumnInfo = "10,1,0,0,0,90,Columns:"
        Me.flxDATA_3.Dock = System.Windows.Forms.DockStyle.Fill
        Me.flxDATA_3.Location = New System.Drawing.Point(0, 0)
        Me.flxDATA_3.Name = "flxDATA_3"
        Me.flxDATA_3.Rows.Count = 1
        Me.flxDATA_3.Rows.DefaultSize = 18
        Me.flxDATA_3.Size = New System.Drawing.Size(1207, 171)
        Me.flxDATA_3.StyleInfo = resources.GetString("flxDATA_3.StyleInfo")
        Me.flxDATA_3.TabIndex = 1
        Me.flxDATA_3.VisualStyle = C1.Win.C1FlexGrid.VisualStyle.Office2010Silver
        '
        'sptPanel3
        '
        Me.sptPanel3.AutoScroll = True
        Me.sptPanel3.Controls.Add(Me.flxDATA_4)
        Me.sptPanel3.Height = 94
        Me.sptPanel3.Location = New System.Drawing.Point(1, 610)
        Me.sptPanel3.Name = "sptPanel3"
        Me.sptPanel3.ResizeWhileDragging = True
        Me.sptPanel3.Size = New System.Drawing.Size(1207, 73)
        Me.sptPanel3.TabIndex = 2
        Me.sptPanel3.Text = "④仕掛品状況"
        '
        'flxDATA_4
        '
        Me.flxDATA_4.AllowDragging = C1.Win.C1FlexGrid.AllowDraggingEnum.None
        Me.flxDATA_4.AllowSorting = C1.Win.C1FlexGrid.AllowSortingEnum.None
        Me.flxDATA_4.AutoClipboard = True
        Me.flxDATA_4.AutoGenerateColumns = False
        Me.flxDATA_4.AutoSearch = C1.Win.C1FlexGrid.AutoSearchEnum.FromTop
        Me.flxDATA_4.BorderStyle = C1.Win.C1FlexGrid.Util.BaseControls.BorderStyleEnum.Light3D
        Me.flxDATA_4.ColumnInfo = "10,1,0,0,0,90,Columns:"
        Me.flxDATA_4.Dock = System.Windows.Forms.DockStyle.Fill
        Me.flxDATA_4.Location = New System.Drawing.Point(0, 0)
        Me.flxDATA_4.Name = "flxDATA_4"
        Me.flxDATA_4.Rows.Count = 1
        Me.flxDATA_4.Rows.DefaultSize = 18
        Me.flxDATA_4.Size = New System.Drawing.Size(1207, 73)
        Me.flxDATA_4.StyleInfo = resources.GetString("flxDATA_4.StyleInfo")
        Me.flxDATA_4.TabIndex = 1
        Me.flxDATA_4.VisualStyle = C1.Win.C1FlexGrid.VisualStyle.Office2010Silver
        '
        'sptPanel4
        '
        Me.sptPanel4.AutoScroll = True
        Me.sptPanel4.Controls.Add(Me.flxDATA_5)
        Me.sptPanel4.Height = 93
        Me.sptPanel4.Location = New System.Drawing.Point(1, 708)
        Me.sptPanel4.Name = "sptPanel4"
        Me.sptPanel4.ResizeWhileDragging = True
        Me.sptPanel4.Size = New System.Drawing.Size(1207, 72)
        Me.sptPanel4.TabIndex = 3
        Me.sptPanel4.Text = "⑤変更審議"
        '
        'flxDATA_5
        '
        Me.flxDATA_5.AllowDragging = C1.Win.C1FlexGrid.AllowDraggingEnum.None
        Me.flxDATA_5.AllowSorting = C1.Win.C1FlexGrid.AllowSortingEnum.None
        Me.flxDATA_5.AutoClipboard = True
        Me.flxDATA_5.AutoGenerateColumns = False
        Me.flxDATA_5.AutoSearch = C1.Win.C1FlexGrid.AutoSearchEnum.FromTop
        Me.flxDATA_5.BorderStyle = C1.Win.C1FlexGrid.Util.BaseControls.BorderStyleEnum.Light3D
        Me.flxDATA_5.ColumnInfo = "10,1,0,0,0,90,Columns:"
        Me.flxDATA_5.Dock = System.Windows.Forms.DockStyle.Fill
        Me.flxDATA_5.Location = New System.Drawing.Point(0, 0)
        Me.flxDATA_5.Name = "flxDATA_5"
        Me.flxDATA_5.Rows.Count = 1
        Me.flxDATA_5.Rows.DefaultSize = 18
        Me.flxDATA_5.Size = New System.Drawing.Size(1207, 72)
        Me.flxDATA_5.StyleInfo = resources.GetString("flxDATA_5.StyleInfo")
        Me.flxDATA_5.TabIndex = 1
        Me.flxDATA_5.VisualStyle = C1.Win.C1FlexGrid.VisualStyle.Office2010Silver
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
        Me.tlpFilter.SetColumnSpan(Me.Label3, 13)
        Me.Label3.Font = New System.Drawing.Font("Meiryo UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label3.Location = New System.Drawing.Point(3, 120)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(254, 30)
        Me.Label3.TabIndex = 93
        Me.Label3.Text = "変更処置のインプット文書番号等:"
        Me.Label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'TextBoxEx1
        '
        Me.tlpFilter.SetColumnSpan(Me.TextBoxEx1, 22)
        Me.TextBoxEx1.ImeMode = System.Windows.Forms.ImeMode.[On]
        Me.TextBoxEx1.InputRequired = False
        Me.TextBoxEx1.Location = New System.Drawing.Point(783, 3)
        Me.TextBoxEx1.MaxByteLength = 0
        Me.TextBoxEx1.Multiline = True
        Me.TextBoxEx1.Name = "TextBoxEx1"
        Me.tlpFilter.SetRowSpan(Me.TextBoxEx1, 6)
        Me.TextBoxEx1.SelectAllText = False
        Me.TextBoxEx1.Size = New System.Drawing.Size(434, 174)
        Me.TextBoxEx1.TabIndex = 216
        Me.TextBoxEx1.WatermarkColor = System.Drawing.Color.Empty
        Me.TextBoxEx1.WatermarkText = Nothing
        '
        'Label17
        '
        Me.tlpFilter.SetColumnSpan(Me.Label17, 13)
        Me.Label17.Font = New System.Drawing.Font("Meiryo UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label17.Location = New System.Drawing.Point(3, 150)
        Me.Label17.Name = "Label17"
        Me.Label17.Size = New System.Drawing.Size(254, 30)
        Me.Label17.TabIndex = 93
        Me.Label17.Text = "変更の適用S/No. 時期等" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "(顧客等指示が無い場合はN/A、⑤変更審議へ)"
        Me.Label17.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'PanelEx2
        '
        Me.PanelEx2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.PanelEx2.Controls.Add(Me.tlpFilter)
        Me.PanelEx2.HitEnabled = False
        Me.PanelEx2.Location = New System.Drawing.Point(12, 96)
        Me.PanelEx2.Name = "PanelEx2"
        Me.PanelEx2.Size = New System.Drawing.Size(1240, 188)
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
        Me.tlpFilter.Controls.Add(Me.Label8, 0, 0)
        Me.tlpFilter.Controls.Add(Me.mtxHOKUKO_NO, 1, 0)
        Me.tlpFilter.Controls.Add(Me.cmbBUMON, 15, 0)
        Me.tlpFilter.Controls.Add(Me.Label6, 20, 0)
        Me.tlpFilter.Controls.Add(Me.cmbKISO_TANTO, 25, 0)
        Me.tlpFilter.Controls.Add(Me.Label14, 0, 1)
        Me.tlpFilter.Controls.Add(Me.Label17, 0, 5)
        Me.tlpFilter.Controls.Add(Me.Label3, 0, 4)
        Me.tlpFilter.Controls.Add(Me.Label7, 0, 3)
        Me.tlpFilter.Controls.Add(Me.cmbHINMEI, 5, 3)
        Me.tlpFilter.Controls.Add(Me.Label4, 0, 2)
        Me.tlpFilter.Controls.Add(Me.cmbBUHIN_BANGO, 5, 2)
        Me.tlpFilter.Controls.Add(Me.lblSYANAI_CD, 12, 2)
        Me.tlpFilter.Controls.Add(Me.cmbSYANAI_CD, 17, 2)
        Me.tlpFilter.Controls.Add(Me.MaskedTextBoxEx2, 13, 4)
        Me.tlpFilter.Controls.Add(Me.Label26, 22, 1)
        Me.tlpFilter.Controls.Add(Me.ComboboxEx1, 27, 1)
        Me.tlpFilter.Controls.Add(Me.cmbKISYU, 5, 1)
        Me.tlpFilter.Controls.Add(Me.Label18, 34, 0)
        Me.tlpFilter.Controls.Add(Me.TextBoxEx1, 39, 0)
        Me.tlpFilter.Controls.Add(Me.Label16, 12, 1)
        Me.tlpFilter.Controls.Add(Me.dtDraft, 17, 1)
        Me.tlpFilter.Controls.Add(Me.MaskedTextBoxEx1, 13, 5)
        Me.tlpFilter.Controls.Add(Me.Label5, 12, 0)
        Me.tlpFilter.Dock = System.Windows.Forms.DockStyle.Fill
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
        Me.tlpFilter.Size = New System.Drawing.Size(1236, 184)
        Me.tlpFilter.TabIndex = 327
        '
        'MaskedTextBoxEx2
        '
        Me.MaskedTextBoxEx2.BackColor = System.Drawing.SystemColors.Control
        Me.tlpFilter.SetColumnSpan(Me.MaskedTextBoxEx2, 11)
        Me.MaskedTextBoxEx2.Font = New System.Drawing.Font("Meiryo UI", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.MaskedTextBoxEx2.ImeMode = System.Windows.Forms.ImeMode.[On]
        Me.MaskedTextBoxEx2.InputRequired = False
        Me.MaskedTextBoxEx2.Location = New System.Drawing.Point(263, 123)
        Me.MaskedTextBoxEx2.MaxByteLength = 0
        Me.MaskedTextBoxEx2.Name = "MaskedTextBoxEx2"
        Me.MaskedTextBoxEx2.ReadOnly = True
        Me.MaskedTextBoxEx2.SelectAllText = False
        Me.MaskedTextBoxEx2.Size = New System.Drawing.Size(214, 24)
        Me.MaskedTextBoxEx2.TabIndex = 266
        Me.MaskedTextBoxEx2.WatermarkColor = System.Drawing.Color.Empty
        Me.MaskedTextBoxEx2.WatermarkText = Nothing
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
        'MaskedTextBoxEx1
        '
        Me.MaskedTextBoxEx1.BackColor = System.Drawing.SystemColors.Control
        Me.tlpFilter.SetColumnSpan(Me.MaskedTextBoxEx1, 11)
        Me.MaskedTextBoxEx1.Font = New System.Drawing.Font("Meiryo UI", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.MaskedTextBoxEx1.ImeMode = System.Windows.Forms.ImeMode.[On]
        Me.MaskedTextBoxEx1.InputRequired = False
        Me.MaskedTextBoxEx1.Location = New System.Drawing.Point(263, 153)
        Me.MaskedTextBoxEx1.MaxByteLength = 0
        Me.MaskedTextBoxEx1.Name = "MaskedTextBoxEx1"
        Me.MaskedTextBoxEx1.ReadOnly = True
        Me.MaskedTextBoxEx1.SelectAllText = False
        Me.MaskedTextBoxEx1.Size = New System.Drawing.Size(214, 24)
        Me.MaskedTextBoxEx1.TabIndex = 266
        Me.MaskedTextBoxEx1.WatermarkColor = System.Drawing.Color.Empty
        Me.MaskedTextBoxEx1.WatermarkText = Nothing
        '
        'dtST05_UPD_YMD
        '
        Me.dtST05_UPD_YMD.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.dtST05_UPD_YMD.GotFocusedColor = System.Drawing.Color.FromArgb(CType(CType(190, Byte), Integer), CType(CType(180, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.dtST05_UPD_YMD.Location = New System.Drawing.Point(285, 66)
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
        Me.cmbDestTANTO.Location = New System.Drawing.Point(467, 65)
        Me.cmbDestTANTO.Name = "cmbDestTANTO"
        Me.cmbDestTANTO.NullValue = " "
        Me.cmbDestTANTO.Size = New System.Drawing.Size(154, 25)
        Me.cmbDestTANTO.TabIndex = 257
        Me.cmbDestTANTO.Text = "(選択)"
        Me.cmbDestTANTO.ValueMember = "VALUE"
        '
        'Label48
        '
        Me.Label48.AutoSize = True
        Me.Label48.Font = New System.Drawing.Font("Meiryo UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label48.Location = New System.Drawing.Point(177, 71)
        Me.Label48.Margin = New System.Windows.Forms.Padding(3, 3, 3, 0)
        Me.Label48.Name = "Label48"
        Me.Label48.Size = New System.Drawing.Size(102, 15)
        Me.Label48.TabIndex = 259
        Me.Label48.Text = "承認・申請年月日:"
        Me.Label48.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'lblDestTanto
        '
        Me.lblDestTanto.AutoSize = True
        Me.lblDestTanto.Font = New System.Drawing.Font("Meiryo UI", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.lblDestTanto.Location = New System.Drawing.Point(389, 70)
        Me.lblDestTanto.Margin = New System.Windows.Forms.Padding(3, 3, 3, 0)
        Me.lblDestTanto.Name = "lblDestTanto"
        Me.lblDestTanto.Size = New System.Drawing.Size(72, 15)
        Me.lblDestTanto.TabIndex = 260
        Me.lblDestTanto.Text = "申請先社員:"
        Me.lblDestTanto.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'FrmG0021_Detail
        '
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None
        Me.ClientSize = New System.Drawing.Size(1264, 711)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.PanelEx2)
        Me.Controls.Add(Me.TabSTAGE)
        Me.Controls.Add(Me.dtST05_UPD_YMD)
        Me.Controls.Add(Me.cmbDestTANTO)
        Me.Controls.Add(Me.Label48)
        Me.Controls.Add(Me.lblDestTanto)
        Me.Controls.Add(Me.flpnlStageIndex)
        Me.HelpButton = True
        Me.MinimumSize = New System.Drawing.Size(1280, 750)
        Me.Name = "FrmG0021_Detail"
        Me.ShowStatusBar = True
        Me.Text = ""
        Me.Controls.SetChildIndex(Me.lblTytle, 0)
        Me.Controls.SetChildIndex(Me.flpnlStageIndex, 0)
        Me.Controls.SetChildIndex(Me.lblDestTanto, 0)
        Me.Controls.SetChildIndex(Me.Label48, 0)
        Me.Controls.SetChildIndex(Me.cmbDestTANTO, 0)
        Me.Controls.SetChildIndex(Me.dtST05_UPD_YMD, 0)
        Me.Controls.SetChildIndex(Me.TabSTAGE, 0)
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
        Me.Controls.SetChildIndex(Me.PanelEx2, 0)
        Me.Controls.SetChildIndex(Me.Label1, 0)
        CType(Me.ErrorProvider, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.WarningErrorProvider, System.ComponentModel.ISupportInitialize).EndInit()
        Me.TabSTAGE.ResumeLayout(False)
        Me.tabSTAGE01.ResumeLayout(False)
        Me.tabSTAGE01.PerformLayout()
        CType(Me.C1SplitContainer1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.C1SplitContainer1.ResumeLayout(False)
        Me.sptPanel1.ResumeLayout(False)
        CType(Me.flxDATA_2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.sptPanel2.ResumeLayout(False)
        CType(Me.flxDATA_3, System.ComponentModel.ISupportInitialize).EndInit()
        Me.sptPanel3.ResumeLayout(False)
        CType(Me.flxDATA_4, System.ComponentModel.ISupportInitialize).EndInit()
        Me.sptPanel4.ResumeLayout(False)
        CType(Me.flxDATA_5, System.ComponentModel.ISupportInitialize).EndInit()
        Me.flpnlStageIndex.ResumeLayout(False)
        Me.PanelEx2.ResumeLayout(False)
        Me.tlpFilter.ResumeLayout(False)
        Me.tlpFilter.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
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
    Friend WithEvents Label10 As Label
    Friend WithEvents flpnlStageIndex As FlowLayoutPanel
    Friend WithEvents rsbtnST01 As RibbonShapeRadioButton
    Friend WithEvents rsbtnST02 As RibbonShapeRadioButton
    Friend WithEvents rsbtnST03 As RibbonShapeRadioButton
    Friend WithEvents rsbtnST04 As RibbonShapeRadioButton
    Friend WithEvents rsbtnST05 As RibbonShapeRadioButton
    Friend WithEvents rsbtnST06 As RibbonShapeRadioButton
    Friend WithEvents rsbtnST99 As RibbonShapeRadioButton
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
    Friend WithEvents cmbDestTANTO As ComboboxEx
    Friend WithEvents Label48 As Label
    Friend WithEvents lblDestTanto As Label
    Friend WithEvents C1SplitContainer1 As C1.Win.C1SplitContainer.C1SplitContainer
    Friend WithEvents sptPanel1 As C1.Win.C1SplitContainer.C1SplitterPanel
    Friend WithEvents sptPanel2 As C1.Win.C1SplitContainer.C1SplitterPanel
    Friend WithEvents sptPanel3 As C1.Win.C1SplitContainer.C1SplitterPanel
    Friend WithEvents sptPanel4 As C1.Win.C1SplitContainer.C1SplitterPanel
    Friend WithEvents flxDATA_2 As C1.Win.C1FlexGrid.C1FlexGrid
    Friend WithEvents flxDATA_3 As C1.Win.C1FlexGrid.C1FlexGrid
    Friend WithEvents flxDATA_4 As C1.Win.C1FlexGrid.C1FlexGrid
    Friend WithEvents flxDATA_5 As C1.Win.C1FlexGrid.C1FlexGrid
End Class
