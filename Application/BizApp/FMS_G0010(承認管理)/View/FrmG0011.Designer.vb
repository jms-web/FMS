<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class FrmG0011
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmG0011))
        Me.gbxFilter = New System.Windows.Forms.GroupBox()
        Me.tlpFilter = New System.Windows.Forms.TableLayoutPanel()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.cmbKISYU = New JMS_COMMON.ComboboxEx()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.cmbFUTEKIGO_KB = New JMS_COMMON.ComboboxEx()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.cmbFUTEKIGO_S_KB = New JMS_COMMON.ComboboxEx()
        Me.mtxFUTEKIGO_NAIYO = New JMS_COMMON.MaskedTextBoxEx()
        Me.Label14 = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.mtxGOUKI = New JMS_COMMON.MaskedTextBoxEx()
        Me.lblSYANAI_CD = New System.Windows.Forms.Label()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.cmbBUHIN_BANGO = New JMS_COMMON.ComboboxEx()
        Me.btnSRCH_BUHIN = New System.Windows.Forms.Button()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.dtDraft = New JMS_COMMON.DateTextBoxEx()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.numSU = New System.Windows.Forms.NumericUpDown()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.cmbFUTEKIGO_STATUS = New JMS_COMMON.ComboboxEx()
        Me.chkSAIHATU = New System.Windows.Forms.CheckBox()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.mtxZUBAN_KIKAKU = New JMS_COMMON.MaskedTextBoxEx()
        Me.chkClosed = New System.Windows.Forms.CheckBox()
        Me.cmbAddTanto = New JMS_COMMON.ComboboxEx()
        Me.mtxHOKUKO_NO = New JMS_COMMON.MaskedTextBoxEx()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.Label16 = New System.Windows.Forms.Label()
        Me.mtxHINMEI = New JMS_COMMON.MaskedTextBoxEx()
        Me.cmbBUMON = New JMS_COMMON.ComboboxEx()
        Me.cmbSYANAI_CD = New JMS_COMMON.ComboboxEx()
        Me.D003NCRJBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.picZoom = New System.Windows.Forms.PictureBox()
        Me.TabSTAGE = New System.Windows.Forms.TabControl()
        Me.tabSTAGE01 = New System.Windows.Forms.TabPage()
        Me.lblST01_Modoshi_Riyu = New System.Windows.Forms.Label()
        Me.cmbST01_DestTANTO = New JMS_COMMON.ComboboxEx()
        Me.mtxST01_NextStageName = New JMS_COMMON.MaskedTextBoxEx()
        Me.Label123 = New System.Windows.Forms.Label()
        Me.Label124 = New System.Windows.Forms.Label()
        Me.Label139 = New System.Windows.Forms.Label()
        Me.mtxST01_UPD_YMD = New JMS_COMMON.MaskedTextBoxEx()
        Me.Label17 = New System.Windows.Forms.Label()
        Me.txtST01_KEKKA = New JMS_COMMON.TextBoxEx()
        Me.lblSTAGE01 = New System.Windows.Forms.Label()
        Me.Label15 = New System.Windows.Forms.Label()
        Me.txtST01_YOKYU_NAIYO = New JMS_COMMON.TextBoxEx()
        Me.tabSTAGE02 = New System.Windows.Forms.TabPage()
        Me.lblST02_Modoshi_Riyu = New System.Windows.Forms.Label()
        Me.cmbST02_DestTANTO = New JMS_COMMON.ComboboxEx()
        Me.mtxST02_NextStageName = New JMS_COMMON.MaskedTextBoxEx()
        Me.Label27 = New System.Windows.Forms.Label()
        Me.Label28 = New System.Windows.Forms.Label()
        Me.Label29 = New System.Windows.Forms.Label()
        Me.txtST02_Comment = New JMS_COMMON.TextBoxEx()
        Me.Label30 = New System.Windows.Forms.Label()
        Me.mtxST02_UPD_YMD = New JMS_COMMON.MaskedTextBoxEx()
        Me.lblSTAGE02 = New System.Windows.Forms.Label()
        Me.tabSTAGE03 = New System.Windows.Forms.TabPage()
        Me.lblST03_Modoshi_Riyu = New System.Windows.Forms.Label()
        Me.cmbST03_DestTANTO = New JMS_COMMON.ComboboxEx()
        Me.mtxST03_NextStageName = New JMS_COMMON.MaskedTextBoxEx()
        Me.Label18 = New System.Windows.Forms.Label()
        Me.Label31 = New System.Windows.Forms.Label()
        Me.Label32 = New System.Windows.Forms.Label()
        Me.txtST03_Comment = New JMS_COMMON.TextBoxEx()
        Me.Label33 = New System.Windows.Forms.Label()
        Me.mtxST03_UPD_YMD = New JMS_COMMON.MaskedTextBoxEx()
        Me.lblSTAGE03 = New System.Windows.Forms.Label()
        Me.tabSTAGE04 = New System.Windows.Forms.TabPage()
        Me.chkST04_ZESEI_SYOCHI_YOHI_KB = New System.Windows.Forms.CheckBox()
        Me.FlowLayoutPanel2 = New System.Windows.Forms.FlowLayoutPanel()
        Me.rbtnST04_ZESEI_YES = New System.Windows.Forms.RadioButton()
        Me.rbtnST04_ZESEI_NO = New System.Windows.Forms.RadioButton()
        Me.lblST04_Modoshi_Riyu = New System.Windows.Forms.Label()
        Me.cmbST04_DestTANTO = New JMS_COMMON.ComboboxEx()
        Me.mtxST04_NextStageName = New JMS_COMMON.MaskedTextBoxEx()
        Me.Label34 = New System.Windows.Forms.Label()
        Me.Label36 = New System.Windows.Forms.Label()
        Me.Label37 = New System.Windows.Forms.Label()
        Me.txtST04_Comment = New JMS_COMMON.TextBoxEx()
        Me.Label38 = New System.Windows.Forms.Label()
        Me.mtxST04_UPD_YMD = New JMS_COMMON.MaskedTextBoxEx()
        Me.lbltxtST04_RIYU = New System.Windows.Forms.Label()
        Me.txtST04_RIYU = New JMS_COMMON.TextBoxEx()
        Me.Label42 = New System.Windows.Forms.Label()
        Me.cmbST04_ZIZENSINSA_HANTEI = New JMS_COMMON.ComboboxEx()
        Me.Label41 = New System.Windows.Forms.Label()
        Me.lblSTAGE04 = New System.Windows.Forms.Label()
        Me.tabSTAGE05 = New System.Windows.Forms.TabPage()
        Me.lblST05_Modoshi_Riyu = New System.Windows.Forms.Label()
        Me.cmbST05_DestTANTO = New JMS_COMMON.ComboboxEx()
        Me.mtxST05_NextStageName = New JMS_COMMON.MaskedTextBoxEx()
        Me.Label45 = New System.Windows.Forms.Label()
        Me.Label46 = New System.Windows.Forms.Label()
        Me.Label47 = New System.Windows.Forms.Label()
        Me.txtST05_Comment = New JMS_COMMON.TextBoxEx()
        Me.Label48 = New System.Windows.Forms.Label()
        Me.mtxST05_UPD_YMD = New JMS_COMMON.MaskedTextBoxEx()
        Me.lblSTAGE05 = New System.Windows.Forms.Label()
        Me.tabSTAGE06 = New System.Windows.Forms.TabPage()
        Me.lblST06_Modoshi_Riyu = New System.Windows.Forms.Label()
        Me.cmbST06_DestTANTO = New JMS_COMMON.ComboboxEx()
        Me.mtxST06_NextStageName = New JMS_COMMON.MaskedTextBoxEx()
        Me.Label49 = New System.Windows.Forms.Label()
        Me.Label50 = New System.Windows.Forms.Label()
        Me.Label51 = New System.Windows.Forms.Label()
        Me.txtST06_Comment = New JMS_COMMON.TextBoxEx()
        Me.Label55 = New System.Windows.Forms.Label()
        Me.mtxST06_UPD_YMD = New JMS_COMMON.MaskedTextBoxEx()
        Me.mtxST06_SAISIN_IINKAI_SIRYO_NO = New JMS_COMMON.MaskedTextBoxEx()
        Me.Label52 = New System.Windows.Forms.Label()
        Me.cmbST06_SAISIN_IINKAI_HANTEI = New JMS_COMMON.ComboboxEx()
        Me.Label53 = New System.Windows.Forms.Label()
        Me.lblSTAGE06 = New System.Windows.Forms.Label()
        Me.tabSTAGE07 = New System.Windows.Forms.TabPage()
        Me.chkST07_SAIKAKO_SIJI_FLG = New System.Windows.Forms.CheckBox()
        Me.FlowLayoutPanel1 = New System.Windows.Forms.FlowLayoutPanel()
        Me.rbtnST07_Yes = New System.Windows.Forms.RadioButton()
        Me.rbtnST07_No = New System.Windows.Forms.RadioButton()
        Me.Label141 = New System.Windows.Forms.Label()
        Me.lblST07_Modoshi_Riyu = New System.Windows.Forms.Label()
        Me.cmbST07_DestTANTO = New JMS_COMMON.ComboboxEx()
        Me.mtxST07_NextStageName = New JMS_COMMON.MaskedTextBoxEx()
        Me.Label56 = New System.Windows.Forms.Label()
        Me.Label57 = New System.Windows.Forms.Label()
        Me.Label58 = New System.Windows.Forms.Label()
        Me.txtST07_Comment = New JMS_COMMON.TextBoxEx()
        Me.Label59 = New System.Windows.Forms.Label()
        Me.mtxST07_UPD_YMD = New JMS_COMMON.MaskedTextBoxEx()
        Me.dtST07_KOKYAKU_SAISYU_HANTEI = New JMS_COMMON.DateTextBoxEx()
        Me.dtST07_KOKYAKU_HANTEI_SIJI = New JMS_COMMON.DateTextBoxEx()
        Me.Label66 = New System.Windows.Forms.Label()
        Me.cmbST07_KOKYAKU_HANTEI_SIJI = New JMS_COMMON.ComboboxEx()
        Me.Label65 = New System.Windows.Forms.Label()
        Me.Label64 = New System.Windows.Forms.Label()
        Me.cmbST07_KOKYAKU_SAISYU_HANTEI = New JMS_COMMON.ComboboxEx()
        Me.Label63 = New System.Windows.Forms.Label()
        Me.mtxST07_ITAG_NO = New JMS_COMMON.MaskedTextBoxEx()
        Me.Label60 = New System.Windows.Forms.Label()
        Me.cmbST07_SAISIN_TANTO = New JMS_COMMON.ComboboxEx()
        Me.Label61 = New System.Windows.Forms.Label()
        Me.lblSTAGE07 = New System.Windows.Forms.Label()
        Me.tabSTAGE08 = New System.Windows.Forms.TabPage()
        Me.lblST08_Modoshi_Riyu = New System.Windows.Forms.Label()
        Me.cmbST08_DestTANTO = New JMS_COMMON.ComboboxEx()
        Me.mtxST08_NextStageName = New JMS_COMMON.MaskedTextBoxEx()
        Me.Label67 = New System.Windows.Forms.Label()
        Me.Label68 = New System.Windows.Forms.Label()
        Me.Label69 = New System.Windows.Forms.Label()
        Me.txtST08_Comment = New JMS_COMMON.TextBoxEx()
        Me.Label70 = New System.Windows.Forms.Label()
        Me.mtxST08_UPD_YMD = New JMS_COMMON.MaskedTextBoxEx()
        Me.tabST08_SUB = New System.Windows.Forms.TabControl()
        Me.tabSTAGE08_1 = New System.Windows.Forms.TabPage()
        Me.btnST08_1_SRCH_TANTO = New System.Windows.Forms.Button()
        Me.cmbST08_1_HAIKYAKU_TANTO = New JMS_COMMON.ComboboxEx()
        Me.Label74 = New System.Windows.Forms.Label()
        Me.mtxST08_1_BIKO = New JMS_COMMON.MaskedTextBoxEx()
        Me.Label73 = New System.Windows.Forms.Label()
        Me.cmbST08_1_HAIKYAKU_KB = New JMS_COMMON.ComboboxEx()
        Me.Label72 = New System.Windows.Forms.Label()
        Me.Label71 = New System.Windows.Forms.Label()
        Me.dtST08_1_HAIKYAKU_YMD = New JMS_COMMON.DateTextBoxEx()
        Me.tabSTAGE08_2 = New System.Windows.Forms.TabPage()
        Me.btnST08_2_SRCH_TANTO_SEIGI = New System.Windows.Forms.Button()
        Me.cmbST08_2_TANTO_SEIGI = New JMS_COMMON.ComboboxEx()
        Me.Label82 = New System.Windows.Forms.Label()
        Me.btnST08_2_SRCH_TANTO_SEIZO = New System.Windows.Forms.Button()
        Me.cmbST08_2_TANTO_SEIZO = New JMS_COMMON.ComboboxEx()
        Me.Label81 = New System.Windows.Forms.Label()
        Me.dtST08_2_KENSA_YMD = New JMS_COMMON.DateTextBoxEx()
        Me.cmbST08_2_KENSA_KEKKA = New JMS_COMMON.ComboboxEx()
        Me.Label80 = New System.Windows.Forms.Label()
        Me.mtxST08_2_DOC_NO = New JMS_COMMON.MaskedTextBoxEx()
        Me.btnST08_2_SRCH_TANTO_KENSA = New System.Windows.Forms.Button()
        Me.cmbST08_2_TANTO_KENSA = New JMS_COMMON.ComboboxEx()
        Me.Label75 = New System.Windows.Forms.Label()
        Me.Label76 = New System.Windows.Forms.Label()
        Me.Label78 = New System.Windows.Forms.Label()
        Me.Label79 = New System.Windows.Forms.Label()
        Me.dtST08_2_WorkOutYMD = New JMS_COMMON.DateTextBoxEx()
        Me.tabSTAGE08_3 = New System.Windows.Forms.TabPage()
        Me.Label83 = New System.Windows.Forms.Label()
        Me.txtST08_3_BIKO = New JMS_COMMON.TextBoxEx()
        Me.btnST08_3_SRCH_TANTO_HENKYAKU = New System.Windows.Forms.Button()
        Me.cmbST08_3_HENKYAKU_TANTO = New JMS_COMMON.ComboboxEx()
        Me.mtxST08_3_HENKYAKU_SAKI = New JMS_COMMON.MaskedTextBoxEx()
        Me.Label87 = New System.Windows.Forms.Label()
        Me.Label88 = New System.Windows.Forms.Label()
        Me.Label89 = New System.Windows.Forms.Label()
        Me.dtST08_3_HENKYAKU_YMD = New JMS_COMMON.DateTextBoxEx()
        Me.tabSTAGE08_4 = New System.Windows.Forms.TabPage()
        Me.cmbST08_4_BUHIN_BANGO = New JMS_COMMON.ComboboxEx()
        Me.cmbST08_4_KISYU = New JMS_COMMON.ComboboxEx()
        Me.mtxST08_4_GOUKI = New JMS_COMMON.MaskedTextBoxEx()
        Me.dtST08_4_TENYO_YMD = New JMS_COMMON.DateTextBoxEx()
        Me.Label91 = New System.Windows.Forms.Label()
        Me.Label84 = New System.Windows.Forms.Label()
        Me.mtxST08_4_LOT = New JMS_COMMON.MaskedTextBoxEx()
        Me.Label85 = New System.Windows.Forms.Label()
        Me.Label86 = New System.Windows.Forms.Label()
        Me.Label90 = New System.Windows.Forms.Label()
        Me.lblSTAGE08 = New System.Windows.Forms.Label()
        Me.tabSTAGE09 = New System.Windows.Forms.TabPage()
        Me.lblST09_Modoshi_Riyu = New System.Windows.Forms.Label()
        Me.cmbST09_DestTANTO = New JMS_COMMON.ComboboxEx()
        Me.mtxST09_NextStageName = New JMS_COMMON.MaskedTextBoxEx()
        Me.Label92 = New System.Windows.Forms.Label()
        Me.Label93 = New System.Windows.Forms.Label()
        Me.Label94 = New System.Windows.Forms.Label()
        Me.txtST09_Comment = New JMS_COMMON.TextBoxEx()
        Me.Label95 = New System.Windows.Forms.Label()
        Me.mtxST09_UPD_YMD = New JMS_COMMON.MaskedTextBoxEx()
        Me.lblSTAGE09 = New System.Windows.Forms.Label()
        Me.tabSTAGE10 = New System.Windows.Forms.TabPage()
        Me.lblST10_Modoshi_Riyu = New System.Windows.Forms.Label()
        Me.cmbST10_DestTANTO = New JMS_COMMON.ComboboxEx()
        Me.mtxST10_NextStageName = New JMS_COMMON.MaskedTextBoxEx()
        Me.Label97 = New System.Windows.Forms.Label()
        Me.Label98 = New System.Windows.Forms.Label()
        Me.Label99 = New System.Windows.Forms.Label()
        Me.txtST10_Comment = New JMS_COMMON.TextBoxEx()
        Me.Label100 = New System.Windows.Forms.Label()
        Me.mtxST10_UPD_YMD = New JMS_COMMON.MaskedTextBoxEx()
        Me.lblSTAGE10 = New System.Windows.Forms.Label()
        Me.tabSTAGE11 = New System.Windows.Forms.TabPage()
        Me.chkST11_E2 = New System.Windows.Forms.CheckBox()
        Me.chkST11_D1 = New System.Windows.Forms.CheckBox()
        Me.chkST11_D2 = New System.Windows.Forms.CheckBox()
        Me.chkST11_E1 = New System.Windows.Forms.CheckBox()
        Me.chkST11_C1 = New System.Windows.Forms.CheckBox()
        Me.chkST11_B1 = New System.Windows.Forms.CheckBox()
        Me.chkST11_A1 = New System.Windows.Forms.CheckBox()
        Me.lblST11_Riyu = New System.Windows.Forms.Label()
        Me.tlpST08 = New System.Windows.Forms.TableLayoutPanel()
        Me.rbtnST11_E2_F = New System.Windows.Forms.RadioButton()
        Me.rbtnST11_E2_T = New System.Windows.Forms.RadioButton()
        Me.rbtnST11_E1_F = New System.Windows.Forms.RadioButton()
        Me.rbtnST11_E1_T = New System.Windows.Forms.RadioButton()
        Me.rbtnST11_D2_F = New System.Windows.Forms.RadioButton()
        Me.rbtnST11_D2_T = New System.Windows.Forms.RadioButton()
        Me.rbtnST11_D1_F = New System.Windows.Forms.RadioButton()
        Me.rbtnST11_D1_T = New System.Windows.Forms.RadioButton()
        Me.rbtnST11_C1_F = New System.Windows.Forms.RadioButton()
        Me.rbtnST11_C1_T = New System.Windows.Forms.RadioButton()
        Me.rbtnST11_B1_F = New System.Windows.Forms.RadioButton()
        Me.rbtnST11_B1_T = New System.Windows.Forms.RadioButton()
        Me.rbtnST11_A1_F = New System.Windows.Forms.RadioButton()
        Me.mtxST11_E_Comment = New JMS_COMMON.MaskedTextBoxEx()
        Me.mtxST11_D_Comment = New JMS_COMMON.MaskedTextBoxEx()
        Me.Label125 = New System.Windows.Forms.Label()
        Me.Label126 = New System.Windows.Forms.Label()
        Me.Label127 = New System.Windows.Forms.Label()
        Me.Label128 = New System.Windows.Forms.Label()
        Me.Label129 = New System.Windows.Forms.Label()
        Me.Label130 = New System.Windows.Forms.Label()
        Me.Label131 = New System.Windows.Forms.Label()
        Me.Label132 = New System.Windows.Forms.Label()
        Me.Label133 = New System.Windows.Forms.Label()
        Me.Label134 = New System.Windows.Forms.Label()
        Me.Label135 = New System.Windows.Forms.Label()
        Me.Label136 = New System.Windows.Forms.Label()
        Me.Label137 = New System.Windows.Forms.Label()
        Me.Label138 = New System.Windows.Forms.Label()
        Me.rbtnST11_A1_T = New System.Windows.Forms.RadioButton()
        Me.lblSTAGE11 = New System.Windows.Forms.Label()
        Me.cmbST11_DestTANTO = New JMS_COMMON.ComboboxEx()
        Me.mtxST11_NextStageName = New JMS_COMMON.MaskedTextBoxEx()
        Me.Label21 = New System.Windows.Forms.Label()
        Me.Label20 = New System.Windows.Forms.Label()
        Me.Label103 = New System.Windows.Forms.Label()
        Me.Label104 = New System.Windows.Forms.Label()
        Me.txtST11_Comment = New JMS_COMMON.TextBoxEx()
        Me.mtxST11_UPD_YMD = New JMS_COMMON.MaskedTextBoxEx()
        Me.tabSTAGE12 = New System.Windows.Forms.TabPage()
        Me.Label122 = New System.Windows.Forms.Label()
        Me.lblSTAGE12 = New System.Windows.Forms.Label()
        Me.tabAttachment = New System.Windows.Forms.TabPage()
        Me.SplitContainer1 = New System.Windows.Forms.SplitContainer()
        Me.flpPict1Path = New System.Windows.Forms.Panel()
        Me.lblPict1Path_Clear = New System.Windows.Forms.LinkLabel()
        Me.lblPict1Path = New System.Windows.Forms.LinkLabel()
        Me.pnlPict1 = New System.Windows.Forms.PictureBox()
        Me.Label24 = New System.Windows.Forms.Label()
        Me.btnOpenPict1Dialog = New System.Windows.Forms.Button()
        Me.flpPict2Path = New System.Windows.Forms.Panel()
        Me.lblPict2Path_Clear = New System.Windows.Forms.LinkLabel()
        Me.lblPict2Path = New System.Windows.Forms.LinkLabel()
        Me.pnlPict2 = New System.Windows.Forms.PictureBox()
        Me.Label25 = New System.Windows.Forms.Label()
        Me.btnOpenPict2Dialog = New System.Windows.Forms.Button()
        Me.fpnlTempFile = New System.Windows.Forms.FlowLayoutPanel()
        Me.lbltmpFile1 = New System.Windows.Forms.LinkLabel()
        Me.lbltmpFile1_Clear = New System.Windows.Forms.LinkLabel()
        Me.LinkLabel1 = New System.Windows.Forms.LinkLabel()
        Me.LinkLabel2 = New System.Windows.Forms.LinkLabel()
        Me.LinkLabel3 = New System.Windows.Forms.LinkLabel()
        Me.LinkLabel4 = New System.Windows.Forms.LinkLabel()
        Me.LinkLabel5 = New System.Windows.Forms.LinkLabel()
        Me.LinkLabel6 = New System.Windows.Forms.LinkLabel()
        Me.LinkLabel7 = New System.Windows.Forms.LinkLabel()
        Me.LinkLabel8 = New System.Windows.Forms.LinkLabel()
        Me.btnOpenTempFileDialog = New System.Windows.Forms.Button()
        Me.Label19 = New System.Windows.Forms.Label()
        Me.D004SYONINJKANRIBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        CType(Me.ErrorProvider, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.gbxFilter.SuspendLayout()
        Me.tlpFilter.SuspendLayout()
        CType(Me.numSU, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.D003NCRJBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.picZoom, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.TabSTAGE.SuspendLayout()
        Me.tabSTAGE01.SuspendLayout()
        Me.tabSTAGE02.SuspendLayout()
        Me.tabSTAGE03.SuspendLayout()
        Me.tabSTAGE04.SuspendLayout()
        Me.FlowLayoutPanel2.SuspendLayout()
        Me.tabSTAGE05.SuspendLayout()
        Me.tabSTAGE06.SuspendLayout()
        Me.tabSTAGE07.SuspendLayout()
        Me.FlowLayoutPanel1.SuspendLayout()
        Me.tabSTAGE08.SuspendLayout()
        Me.tabST08_SUB.SuspendLayout()
        Me.tabSTAGE08_1.SuspendLayout()
        Me.tabSTAGE08_2.SuspendLayout()
        Me.tabSTAGE08_3.SuspendLayout()
        Me.tabSTAGE08_4.SuspendLayout()
        Me.tabSTAGE09.SuspendLayout()
        Me.tabSTAGE10.SuspendLayout()
        Me.tabSTAGE11.SuspendLayout()
        Me.tlpST08.SuspendLayout()
        Me.tabSTAGE12.SuspendLayout()
        Me.tabAttachment.SuspendLayout()
        CType(Me.SplitContainer1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SplitContainer1.Panel1.SuspendLayout()
        Me.SplitContainer1.Panel2.SuspendLayout()
        Me.SplitContainer1.SuspendLayout()
        Me.flpPict1Path.SuspendLayout()
        CType(Me.pnlPict1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.flpPict2Path.SuspendLayout()
        CType(Me.pnlPict2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.fpnlTempFile.SuspendLayout()
        CType(Me.D004SYONINJKANRIBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'lblRecordCount
        '
        Me.lblRecordCount.ForeColor = System.Drawing.SystemColors.ControlText
        Me.lblRecordCount.Location = New System.Drawing.Point(12, 565)
        Me.lblRecordCount.Size = New System.Drawing.Size(407, 24)
        '
        'cmdFunc1
        '
        Me.cmdFunc1.Image = Global.FMS.My.Resources.Resources._imgBase_floppydisk32x32
        Me.cmdFunc1.Location = New System.Drawing.Point(9, 595)
        Me.cmdFunc1.Text = "保存(F1)"
        '
        'cmdFunc2
        '
        Me.cmdFunc2.Image = Global.FMS.My.Resources.Resources.申請
        Me.cmdFunc2.Location = New System.Drawing.Point(216, 595)
        Me.cmdFunc2.Text = "承認&&申請(F2)"
        '
        'cmdFunc3
        '
        Me.cmdFunc3.Location = New System.Drawing.Point(423, 595)
        '
        'cmdFunc4
        '
        Me.cmdFunc4.Image = Global.FMS.My.Resources.Resources._imgRight32x32
        Me.cmdFunc4.Location = New System.Drawing.Point(630, 595)
        Me.cmdFunc4.Text = "転送 (F4)"
        '
        'cmdFunc5
        '
        Me.cmdFunc5.Image = Global.FMS.My.Resources.Resources._imgUndo32x32
        Me.cmdFunc5.Location = New System.Drawing.Point(837, 595)
        Me.cmdFunc5.Text = "差戻し(F5)"
        '
        'cmdFunc6
        '
        Me.cmdFunc6.Location = New System.Drawing.Point(1044, 595)
        '
        'cmdFunc12
        '
        Me.cmdFunc12.Image = Global.FMS.My.Resources.Resources._imgLog_Out32x32
        Me.cmdFunc12.Location = New System.Drawing.Point(1044, 643)
        Me.cmdFunc12.Text = "閉じる(F12)"
        '
        'cmdFunc11
        '
        Me.cmdFunc11.Image = Global.FMS.My.Resources.Resources.履歴
        Me.cmdFunc11.Location = New System.Drawing.Point(837, 643)
        Me.cmdFunc11.Text = "履歴表示(F11)"
        '
        'cmdFunc10
        '
        Me.cmdFunc10.Image = Global.FMS.My.Resources.Resources._imgPrint32x32
        Me.cmdFunc10.Location = New System.Drawing.Point(630, 643)
        Me.cmdFunc10.Text = "印刷(F10)"
        '
        'cmdFunc7
        '
        Me.cmdFunc7.Location = New System.Drawing.Point(9, 643)
        '
        'cmdFunc9
        '
        Me.cmdFunc9.Image = Global.FMS.My.Resources.Resources._imgApplication_form_edit32x32
        Me.cmdFunc9.Location = New System.Drawing.Point(423, 643)
        Me.cmdFunc9.Text = "CAR編集(F9)"
        '
        'cmdFunc8
        '
        Me.cmdFunc8.Location = New System.Drawing.Point(216, 643)
        '
        'lblTytle
        '
        Me.lblTytle.Font = New System.Drawing.Font("Meiryo UI", 24.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTytle.ForeColor = System.Drawing.SystemColors.ControlText
        Me.lblTytle.Text = "不適合製品処置報告書(Non-Conformance Report)"
        '
        'gbxFilter
        '
        Me.gbxFilter.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.gbxFilter.Controls.Add(Me.tlpFilter)
        Me.gbxFilter.Font = New System.Drawing.Font("Meiryo UI", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.gbxFilter.Location = New System.Drawing.Point(12, 60)
        Me.gbxFilter.Name = "gbxFilter"
        Me.gbxFilter.Size = New System.Drawing.Size(1236, 181)
        Me.gbxFilter.TabIndex = 59
        Me.gbxFilter.TabStop = False
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
        Me.tlpFilter.Controls.Add(Me.Label9, 0, 1)
        Me.tlpFilter.Controls.Add(Me.cmbKISYU, 5, 1)
        Me.tlpFilter.Controls.Add(Me.Label10, 13, 3)
        Me.tlpFilter.Controls.Add(Me.Label12, 0, 4)
        Me.tlpFilter.Controls.Add(Me.cmbFUTEKIGO_KB, 5, 4)
        Me.tlpFilter.Controls.Add(Me.Label5, 13, 4)
        Me.tlpFilter.Controls.Add(Me.cmbFUTEKIGO_S_KB, 18, 4)
        Me.tlpFilter.Controls.Add(Me.mtxFUTEKIGO_NAIYO, 18, 3)
        Me.tlpFilter.Controls.Add(Me.Label14, 29, 0)
        Me.tlpFilter.Controls.Add(Me.Label7, 29, 2)
        Me.tlpFilter.Controls.Add(Me.Label4, 13, 1)
        Me.tlpFilter.Controls.Add(Me.mtxGOUKI, 18, 1)
        Me.tlpFilter.Controls.Add(Me.lblSYANAI_CD, 0, 2)
        Me.tlpFilter.Controls.Add(Me.Label11, 13, 2)
        Me.tlpFilter.Controls.Add(Me.cmbBUHIN_BANGO, 18, 2)
        Me.tlpFilter.Controls.Add(Me.btnSRCH_BUHIN, 26, 2)
        Me.tlpFilter.Controls.Add(Me.Label6, 43, 0)
        Me.tlpFilter.Controls.Add(Me.dtDraft, 48, 0)
        Me.tlpFilter.Controls.Add(Me.Label2, 43, 2)
        Me.tlpFilter.Controls.Add(Me.numSU, 48, 2)
        Me.tlpFilter.Controls.Add(Me.Label1, 0, 3)
        Me.tlpFilter.Controls.Add(Me.cmbFUTEKIGO_STATUS, 5, 3)
        Me.tlpFilter.Controls.Add(Me.chkSAIHATU, 31, 3)
        Me.tlpFilter.Controls.Add(Me.Label13, 29, 4)
        Me.tlpFilter.Controls.Add(Me.mtxZUBAN_KIKAKU, 34, 4)
        Me.tlpFilter.Controls.Add(Me.chkClosed, 57, 0)
        Me.tlpFilter.Controls.Add(Me.cmbAddTanto, 34, 0)
        Me.tlpFilter.Controls.Add(Me.mtxHOKUKO_NO, 5, 0)
        Me.tlpFilter.Controls.Add(Me.Label8, 0, 0)
        Me.tlpFilter.Controls.Add(Me.Label16, 13, 0)
        Me.tlpFilter.Controls.Add(Me.mtxHINMEI, 34, 2)
        Me.tlpFilter.Controls.Add(Me.cmbBUMON, 18, 0)
        Me.tlpFilter.Controls.Add(Me.cmbSYANAI_CD, 5, 2)
        Me.tlpFilter.Dock = System.Windows.Forms.DockStyle.Fill
        Me.tlpFilter.Location = New System.Drawing.Point(3, 20)
        Me.tlpFilter.Name = "tlpFilter"
        Me.tlpFilter.RowCount = 6
        Me.tlpFilter.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30.0!))
        Me.tlpFilter.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30.0!))
        Me.tlpFilter.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30.0!))
        Me.tlpFilter.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30.0!))
        Me.tlpFilter.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30.0!))
        Me.tlpFilter.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.tlpFilter.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20.0!))
        Me.tlpFilter.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20.0!))
        Me.tlpFilter.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20.0!))
        Me.tlpFilter.Size = New System.Drawing.Size(1230, 158)
        Me.tlpFilter.TabIndex = 56
        '
        'Label9
        '
        Me.tlpFilter.SetColumnSpan(Me.Label9, 5)
        Me.Label9.Font = New System.Drawing.Font("Meiryo UI", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label9.Location = New System.Drawing.Point(3, 30)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(94, 30)
        Me.Label9.TabIndex = 94
        Me.Label9.Text = "機種:"
        Me.Label9.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'cmbKISYU
        '
        Me.cmbKISYU.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cmbKISYU.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cmbKISYU.BackColor = System.Drawing.SystemColors.Window
        Me.tlpFilter.SetColumnSpan(Me.cmbKISYU, 7)
        Me.cmbKISYU.Cursor = System.Windows.Forms.Cursors.Hand
        Me.cmbKISYU.Font = New System.Drawing.Font("Meiryo UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.cmbKISYU.ForeColor = System.Drawing.SystemColors.ControlText
        Me.cmbKISYU.FormattingEnabled = True
        Me.cmbKISYU.GotFocusedColor = System.Drawing.Color.FromArgb(CType(CType(190, Byte), Integer), CType(CType(180, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.cmbKISYU.ImeMode = System.Windows.Forms.ImeMode.[On]
        Me.cmbKISYU.Location = New System.Drawing.Point(103, 33)
        Me.cmbKISYU.Name = "cmbKISYU"
        Me.cmbKISYU.Selected = False
        Me.cmbKISYU.Size = New System.Drawing.Size(134, 25)
        Me.cmbKISYU.TabIndex = 4
        Me.cmbKISYU.Text = "(選択)"
        '
        'Label10
        '
        Me.tlpFilter.SetColumnSpan(Me.Label10, 5)
        Me.Label10.Font = New System.Drawing.Font("Meiryo UI", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label10.Location = New System.Drawing.Point(263, 90)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(94, 30)
        Me.Label10.TabIndex = 101
        Me.Label10.Text = "返却品の場合:"
        Me.Label10.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label12
        '
        Me.tlpFilter.SetColumnSpan(Me.Label12, 5)
        Me.Label12.Font = New System.Drawing.Font("Meiryo UI", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label12.Location = New System.Drawing.Point(3, 120)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(94, 30)
        Me.Label12.TabIndex = 102
        Me.Label12.Text = "不適合区分:"
        Me.Label12.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'cmbFUTEKIGO_KB
        '
        Me.cmbFUTEKIGO_KB.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cmbFUTEKIGO_KB.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cmbFUTEKIGO_KB.BackColor = System.Drawing.SystemColors.Window
        Me.tlpFilter.SetColumnSpan(Me.cmbFUTEKIGO_KB, 7)
        Me.cmbFUTEKIGO_KB.Cursor = System.Windows.Forms.Cursors.Hand
        Me.cmbFUTEKIGO_KB.Font = New System.Drawing.Font("Meiryo UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.cmbFUTEKIGO_KB.ForeColor = System.Drawing.SystemColors.ControlText
        Me.cmbFUTEKIGO_KB.FormattingEnabled = True
        Me.cmbFUTEKIGO_KB.GotFocusedColor = System.Drawing.Color.FromArgb(CType(CType(190, Byte), Integer), CType(CType(180, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.cmbFUTEKIGO_KB.ImeMode = System.Windows.Forms.ImeMode.[On]
        Me.cmbFUTEKIGO_KB.Location = New System.Drawing.Point(103, 123)
        Me.cmbFUTEKIGO_KB.Name = "cmbFUTEKIGO_KB"
        Me.cmbFUTEKIGO_KB.Selected = False
        Me.cmbFUTEKIGO_KB.Size = New System.Drawing.Size(134, 25)
        Me.cmbFUTEKIGO_KB.TabIndex = 13
        Me.cmbFUTEKIGO_KB.Text = "(選択)"
        '
        'Label5
        '
        Me.tlpFilter.SetColumnSpan(Me.Label5, 5)
        Me.Label5.Font = New System.Drawing.Font("Meiryo UI", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label5.Location = New System.Drawing.Point(263, 120)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(94, 30)
        Me.Label5.TabIndex = 118
        Me.Label5.Text = "不適合詳細区分:"
        Me.Label5.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'cmbFUTEKIGO_S_KB
        '
        Me.cmbFUTEKIGO_S_KB.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cmbFUTEKIGO_S_KB.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cmbFUTEKIGO_S_KB.BackColor = System.Drawing.SystemColors.Window
        Me.tlpFilter.SetColumnSpan(Me.cmbFUTEKIGO_S_KB, 11)
        Me.cmbFUTEKIGO_S_KB.Cursor = System.Windows.Forms.Cursors.Hand
        Me.cmbFUTEKIGO_S_KB.Font = New System.Drawing.Font("Meiryo UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.cmbFUTEKIGO_S_KB.ForeColor = System.Drawing.SystemColors.ControlText
        Me.cmbFUTEKIGO_S_KB.FormattingEnabled = True
        Me.cmbFUTEKIGO_S_KB.GotFocusedColor = System.Drawing.Color.FromArgb(CType(CType(190, Byte), Integer), CType(CType(180, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.cmbFUTEKIGO_S_KB.ImeMode = System.Windows.Forms.ImeMode.[On]
        Me.cmbFUTEKIGO_S_KB.Location = New System.Drawing.Point(363, 123)
        Me.cmbFUTEKIGO_S_KB.Name = "cmbFUTEKIGO_S_KB"
        Me.cmbFUTEKIGO_S_KB.Selected = False
        Me.cmbFUTEKIGO_S_KB.Size = New System.Drawing.Size(214, 25)
        Me.cmbFUTEKIGO_S_KB.TabIndex = 14
        Me.cmbFUTEKIGO_S_KB.Text = "(選択)"
        '
        'mtxFUTEKIGO_NAIYO
        '
        Me.mtxFUTEKIGO_NAIYO.BackColor = System.Drawing.SystemColors.Window
        Me.tlpFilter.SetColumnSpan(Me.mtxFUTEKIGO_NAIYO, 11)
        Me.mtxFUTEKIGO_NAIYO.GotFocusedColor = System.Drawing.Color.FromArgb(CType(CType(190, Byte), Integer), CType(CType(180, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.mtxFUTEKIGO_NAIYO.ImeMode = System.Windows.Forms.ImeMode.[On]
        Me.mtxFUTEKIGO_NAIYO.InputRequired = False
        Me.mtxFUTEKIGO_NAIYO.Location = New System.Drawing.Point(363, 93)
        Me.mtxFUTEKIGO_NAIYO.Name = "mtxFUTEKIGO_NAIYO"
        Me.mtxFUTEKIGO_NAIYO.Size = New System.Drawing.Size(214, 24)
        Me.mtxFUTEKIGO_NAIYO.TabIndex = 11
        Me.mtxFUTEKIGO_NAIYO.WatermarkColor = System.Drawing.Color.Empty
        Me.mtxFUTEKIGO_NAIYO.WatermarkText = Nothing
        '
        'Label14
        '
        Me.tlpFilter.SetColumnSpan(Me.Label14, 5)
        Me.Label14.Font = New System.Drawing.Font("Meiryo UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label14.Location = New System.Drawing.Point(583, 0)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(94, 30)
        Me.Label14.TabIndex = 85
        Me.Label14.Text = "起草者:"
        Me.Label14.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label7
        '
        Me.tlpFilter.SetColumnSpan(Me.Label7, 5)
        Me.Label7.Font = New System.Drawing.Font("Meiryo UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label7.Location = New System.Drawing.Point(583, 60)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(94, 30)
        Me.Label7.TabIndex = 99
        Me.Label7.Text = "部品名称:"
        Me.Label7.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label4
        '
        Me.tlpFilter.SetColumnSpan(Me.Label4, 5)
        Me.Label4.Font = New System.Drawing.Font("Meiryo UI", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label4.Location = New System.Drawing.Point(263, 30)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(94, 30)
        Me.Label4.TabIndex = 90
        Me.Label4.Text = "製造番号(号機):"
        Me.Label4.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'mtxGOUKI
        '
        Me.mtxGOUKI.BackColor = System.Drawing.SystemColors.Window
        Me.tlpFilter.SetColumnSpan(Me.mtxGOUKI, 7)
        Me.mtxGOUKI.GotFocusedColor = System.Drawing.Color.FromArgb(CType(CType(190, Byte), Integer), CType(CType(180, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.mtxGOUKI.ImeMode = System.Windows.Forms.ImeMode.Disable
        Me.mtxGOUKI.InputRequired = False
        Me.mtxGOUKI.Location = New System.Drawing.Point(363, 33)
        Me.mtxGOUKI.Name = "mtxGOUKI"
        Me.mtxGOUKI.Size = New System.Drawing.Size(134, 24)
        Me.mtxGOUKI.TabIndex = 5
        Me.mtxGOUKI.WatermarkColor = System.Drawing.Color.Empty
        Me.mtxGOUKI.WatermarkText = Nothing
        '
        'lblSYANAI_CD
        '
        Me.tlpFilter.SetColumnSpan(Me.lblSYANAI_CD, 5)
        Me.lblSYANAI_CD.Font = New System.Drawing.Font("Meiryo UI", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.lblSYANAI_CD.Location = New System.Drawing.Point(3, 60)
        Me.lblSYANAI_CD.Name = "lblSYANAI_CD"
        Me.lblSYANAI_CD.Size = New System.Drawing.Size(94, 30)
        Me.lblSYANAI_CD.TabIndex = 115
        Me.lblSYANAI_CD.Text = "社内コード:"
        Me.lblSYANAI_CD.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label11
        '
        Me.tlpFilter.SetColumnSpan(Me.Label11, 5)
        Me.Label11.Font = New System.Drawing.Font("Meiryo UI", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label11.Location = New System.Drawing.Point(263, 60)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(94, 30)
        Me.Label11.TabIndex = 97
        Me.Label11.Text = "部品番号:"
        Me.Label11.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'cmbBUHIN_BANGO
        '
        Me.cmbBUHIN_BANGO.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cmbBUHIN_BANGO.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cmbBUHIN_BANGO.BackColor = System.Drawing.SystemColors.Window
        Me.tlpFilter.SetColumnSpan(Me.cmbBUHIN_BANGO, 8)
        Me.cmbBUHIN_BANGO.Cursor = System.Windows.Forms.Cursors.Hand
        Me.cmbBUHIN_BANGO.Font = New System.Drawing.Font("Meiryo UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.cmbBUHIN_BANGO.ForeColor = System.Drawing.SystemColors.ControlText
        Me.cmbBUHIN_BANGO.FormattingEnabled = True
        Me.cmbBUHIN_BANGO.GotFocusedColor = System.Drawing.Color.FromArgb(CType(CType(190, Byte), Integer), CType(CType(180, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.cmbBUHIN_BANGO.ImeMode = System.Windows.Forms.ImeMode.[On]
        Me.cmbBUHIN_BANGO.Location = New System.Drawing.Point(363, 63)
        Me.cmbBUHIN_BANGO.Name = "cmbBUHIN_BANGO"
        Me.cmbBUHIN_BANGO.Selected = False
        Me.cmbBUHIN_BANGO.Size = New System.Drawing.Size(154, 25)
        Me.cmbBUHIN_BANGO.TabIndex = 7
        Me.cmbBUHIN_BANGO.Text = "(選択)"
        '
        'btnSRCH_BUHIN
        '
        Me.tlpFilter.SetColumnSpan(Me.btnSRCH_BUHIN, 3)
        Me.btnSRCH_BUHIN.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnSRCH_BUHIN.Location = New System.Drawing.Point(523, 63)
        Me.btnSRCH_BUHIN.Name = "btnSRCH_BUHIN"
        Me.btnSRCH_BUHIN.Size = New System.Drawing.Size(54, 24)
        Me.btnSRCH_BUHIN.TabIndex = 98
        Me.btnSRCH_BUHIN.Text = "検索"
        Me.btnSRCH_BUHIN.UseVisualStyleBackColor = True
        Me.btnSRCH_BUHIN.Visible = False
        '
        'Label6
        '
        Me.tlpFilter.SetColumnSpan(Me.Label6, 5)
        Me.Label6.Font = New System.Drawing.Font("Meiryo UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label6.Location = New System.Drawing.Point(863, 0)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(94, 30)
        Me.Label6.TabIndex = 93
        Me.Label6.Text = "起草日:"
        Me.Label6.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'dtDraft
        '
        Me.dtDraft.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.tlpFilter.SetColumnSpan(Me.dtDraft, 5)
        Me.dtDraft.GotFocusedColor = System.Drawing.Color.FromArgb(CType(CType(190, Byte), Integer), CType(CType(180, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.dtDraft.Location = New System.Drawing.Point(963, 3)
        Me.dtDraft.MaxDate = New Date(9998, 12, 31, 0, 0, 0, 0)
        Me.dtDraft.MinDate = New Date(1753, 1, 1, 0, 0, 0, 0)
        Me.dtDraft.MinimumSize = New System.Drawing.Size(98, 24)
        Me.dtDraft.Name = "dtDraft"
        Me.dtDraft.Size = New System.Drawing.Size(98, 24)
        Me.dtDraft.TabIndex = 3
        Me.dtDraft.Value = ""
        Me.dtDraft.ValueNonFormat = ""
        '
        'Label2
        '
        Me.tlpFilter.SetColumnSpan(Me.Label2, 5)
        Me.Label2.Font = New System.Drawing.Font("Meiryo UI", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label2.Location = New System.Drawing.Point(863, 60)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(94, 30)
        Me.Label2.TabIndex = 88
        Me.Label2.Text = "個数:"
        Me.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'numSU
        '
        Me.tlpFilter.SetColumnSpan(Me.numSU, 3)
        Me.numSU.Location = New System.Drawing.Point(963, 63)
        Me.numSU.Name = "numSU"
        Me.numSU.Size = New System.Drawing.Size(54, 24)
        Me.numSU.TabIndex = 9
        Me.numSU.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label1
        '
        Me.tlpFilter.SetColumnSpan(Me.Label1, 5)
        Me.Label1.Font = New System.Drawing.Font("Meiryo UI", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label1.Location = New System.Drawing.Point(3, 90)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(94, 30)
        Me.Label1.TabIndex = 87
        Me.Label1.Text = "状態区分:"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'cmbFUTEKIGO_STATUS
        '
        Me.cmbFUTEKIGO_STATUS.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cmbFUTEKIGO_STATUS.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cmbFUTEKIGO_STATUS.BackColor = System.Drawing.SystemColors.Window
        Me.tlpFilter.SetColumnSpan(Me.cmbFUTEKIGO_STATUS, 7)
        Me.cmbFUTEKIGO_STATUS.Cursor = System.Windows.Forms.Cursors.Hand
        Me.cmbFUTEKIGO_STATUS.Font = New System.Drawing.Font("Meiryo UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.cmbFUTEKIGO_STATUS.ForeColor = System.Drawing.SystemColors.ControlText
        Me.cmbFUTEKIGO_STATUS.FormattingEnabled = True
        Me.cmbFUTEKIGO_STATUS.GotFocusedColor = System.Drawing.Color.FromArgb(CType(CType(190, Byte), Integer), CType(CType(180, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.cmbFUTEKIGO_STATUS.ImeMode = System.Windows.Forms.ImeMode.[On]
        Me.cmbFUTEKIGO_STATUS.Location = New System.Drawing.Point(103, 93)
        Me.cmbFUTEKIGO_STATUS.Name = "cmbFUTEKIGO_STATUS"
        Me.cmbFUTEKIGO_STATUS.Selected = False
        Me.cmbFUTEKIGO_STATUS.Size = New System.Drawing.Size(134, 25)
        Me.cmbFUTEKIGO_STATUS.TabIndex = 10
        Me.cmbFUTEKIGO_STATUS.Text = "(選択)"
        '
        'chkSAIHATU
        '
        Me.chkSAIHATU.AutoSize = True
        Me.tlpFilter.SetColumnSpan(Me.chkSAIHATU, 7)
        Me.chkSAIHATU.Cursor = System.Windows.Forms.Cursors.Hand
        Me.chkSAIHATU.Font = New System.Drawing.Font("Meiryo UI", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.chkSAIHATU.Location = New System.Drawing.Point(623, 93)
        Me.chkSAIHATU.Name = "chkSAIHATU"
        Me.chkSAIHATU.Size = New System.Drawing.Size(53, 21)
        Me.chkSAIHATU.TabIndex = 12
        Me.chkSAIHATU.Text = "再発"
        Me.chkSAIHATU.UseVisualStyleBackColor = True
        '
        'Label13
        '
        Me.tlpFilter.SetColumnSpan(Me.Label13, 5)
        Me.Label13.Font = New System.Drawing.Font("Meiryo UI", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label13.Location = New System.Drawing.Point(583, 120)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(94, 30)
        Me.Label13.TabIndex = 103
        Me.Label13.Text = "図面/規格:"
        Me.Label13.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'mtxZUBAN_KIKAKU
        '
        Me.mtxZUBAN_KIKAKU.BackColor = System.Drawing.SystemColors.Window
        Me.tlpFilter.SetColumnSpan(Me.mtxZUBAN_KIKAKU, 19)
        Me.mtxZUBAN_KIKAKU.GotFocusedColor = System.Drawing.Color.FromArgb(CType(CType(190, Byte), Integer), CType(CType(180, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.mtxZUBAN_KIKAKU.ImeMode = System.Windows.Forms.ImeMode.[On]
        Me.mtxZUBAN_KIKAKU.InputRequired = False
        Me.mtxZUBAN_KIKAKU.Location = New System.Drawing.Point(683, 123)
        Me.mtxZUBAN_KIKAKU.Name = "mtxZUBAN_KIKAKU"
        Me.mtxZUBAN_KIKAKU.Size = New System.Drawing.Size(374, 24)
        Me.mtxZUBAN_KIKAKU.TabIndex = 15
        Me.mtxZUBAN_KIKAKU.WatermarkColor = System.Drawing.Color.Empty
        Me.mtxZUBAN_KIKAKU.WatermarkText = Nothing
        '
        'chkClosed
        '
        Me.chkClosed.AutoSize = True
        Me.tlpFilter.SetColumnSpan(Me.chkClosed, 4)
        Me.chkClosed.Enabled = False
        Me.chkClosed.Font = New System.Drawing.Font("Meiryo UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.chkClosed.Location = New System.Drawing.Point(1143, 3)
        Me.chkClosed.Name = "chkClosed"
        Me.chkClosed.Size = New System.Drawing.Size(69, 21)
        Me.chkClosed.TabIndex = 121
        Me.chkClosed.Text = "Closed"
        Me.chkClosed.UseVisualStyleBackColor = True
        '
        'cmbAddTanto
        '
        Me.cmbAddTanto.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cmbAddTanto.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cmbAddTanto.BackColor = System.Drawing.SystemColors.Window
        Me.tlpFilter.SetColumnSpan(Me.cmbAddTanto, 8)
        Me.cmbAddTanto.Cursor = System.Windows.Forms.Cursors.Hand
        Me.cmbAddTanto.Font = New System.Drawing.Font("Meiryo UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.cmbAddTanto.ForeColor = System.Drawing.SystemColors.ControlText
        Me.cmbAddTanto.FormattingEnabled = True
        Me.cmbAddTanto.GotFocusedColor = System.Drawing.Color.FromArgb(CType(CType(190, Byte), Integer), CType(CType(180, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.cmbAddTanto.ImeMode = System.Windows.Forms.ImeMode.[On]
        Me.cmbAddTanto.Location = New System.Drawing.Point(683, 3)
        Me.cmbAddTanto.Name = "cmbAddTanto"
        Me.cmbAddTanto.Selected = False
        Me.cmbAddTanto.Size = New System.Drawing.Size(154, 25)
        Me.cmbAddTanto.TabIndex = 2
        Me.cmbAddTanto.Text = "(選択)"
        '
        'mtxHOKUKO_NO
        '
        Me.mtxHOKUKO_NO.BackColor = System.Drawing.SystemColors.Window
        Me.tlpFilter.SetColumnSpan(Me.mtxHOKUKO_NO, 7)
        Me.mtxHOKUKO_NO.GotFocusedColor = System.Drawing.Color.FromArgb(CType(CType(190, Byte), Integer), CType(CType(180, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.mtxHOKUKO_NO.ImeMode = System.Windows.Forms.ImeMode.Disable
        Me.mtxHOKUKO_NO.InputRequired = False
        Me.mtxHOKUKO_NO.Location = New System.Drawing.Point(103, 3)
        Me.mtxHOKUKO_NO.Name = "mtxHOKUKO_NO"
        Me.mtxHOKUKO_NO.ReadOnly = True
        Me.mtxHOKUKO_NO.Size = New System.Drawing.Size(134, 24)
        Me.mtxHOKUKO_NO.TabIndex = 0
        Me.mtxHOKUKO_NO.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.mtxHOKUKO_NO.WatermarkColor = System.Drawing.Color.Empty
        Me.mtxHOKUKO_NO.WatermarkText = Nothing
        '
        'Label8
        '
        Me.tlpFilter.SetColumnSpan(Me.Label8, 5)
        Me.Label8.Font = New System.Drawing.Font("Meiryo UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label8.Location = New System.Drawing.Point(3, 0)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(94, 30)
        Me.Label8.TabIndex = 83
        Me.Label8.Text = "報告書No:"
        Me.Label8.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label16
        '
        Me.tlpFilter.SetColumnSpan(Me.Label16, 5)
        Me.Label16.Font = New System.Drawing.Font("Meiryo UI", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label16.Location = New System.Drawing.Point(263, 0)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(94, 30)
        Me.Label16.TabIndex = 112
        Me.Label16.Text = "部門区分:"
        Me.Label16.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'mtxHINMEI
        '
        Me.mtxHINMEI.BackColor = System.Drawing.SystemColors.Window
        Me.tlpFilter.SetColumnSpan(Me.mtxHINMEI, 8)
        Me.mtxHINMEI.Enabled = False
        Me.mtxHINMEI.GotFocusedColor = System.Drawing.Color.FromArgb(CType(CType(190, Byte), Integer), CType(CType(180, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.mtxHINMEI.ImeMode = System.Windows.Forms.ImeMode.Disable
        Me.mtxHINMEI.InputRequired = False
        Me.mtxHINMEI.Location = New System.Drawing.Point(683, 63)
        Me.mtxHINMEI.Name = "mtxHINMEI"
        Me.mtxHINMEI.Size = New System.Drawing.Size(154, 24)
        Me.mtxHINMEI.TabIndex = 8
        Me.mtxHINMEI.WatermarkColor = System.Drawing.Color.Empty
        Me.mtxHINMEI.WatermarkText = Nothing
        '
        'cmbBUMON
        '
        Me.cmbBUMON.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cmbBUMON.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cmbBUMON.BackColor = System.Drawing.SystemColors.Window
        Me.tlpFilter.SetColumnSpan(Me.cmbBUMON, 5)
        Me.cmbBUMON.Cursor = System.Windows.Forms.Cursors.Hand
        Me.cmbBUMON.Font = New System.Drawing.Font("Meiryo UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.cmbBUMON.ForeColor = System.Drawing.SystemColors.ControlText
        Me.cmbBUMON.FormattingEnabled = True
        Me.cmbBUMON.GotFocusedColor = System.Drawing.Color.FromArgb(CType(CType(190, Byte), Integer), CType(CType(180, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.cmbBUMON.ImeMode = System.Windows.Forms.ImeMode.[On]
        Me.cmbBUMON.Location = New System.Drawing.Point(363, 3)
        Me.cmbBUMON.Name = "cmbBUMON"
        Me.cmbBUMON.Selected = False
        Me.cmbBUMON.Size = New System.Drawing.Size(94, 25)
        Me.cmbBUMON.TabIndex = 1
        Me.cmbBUMON.Text = "(選択)"
        '
        'cmbSYANAI_CD
        '
        Me.cmbSYANAI_CD.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cmbSYANAI_CD.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cmbSYANAI_CD.BackColor = System.Drawing.SystemColors.Window
        Me.tlpFilter.SetColumnSpan(Me.cmbSYANAI_CD, 7)
        Me.cmbSYANAI_CD.Cursor = System.Windows.Forms.Cursors.Hand
        Me.cmbSYANAI_CD.Font = New System.Drawing.Font("Meiryo UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.cmbSYANAI_CD.ForeColor = System.Drawing.SystemColors.ControlText
        Me.cmbSYANAI_CD.FormattingEnabled = True
        Me.cmbSYANAI_CD.GotFocusedColor = System.Drawing.Color.FromArgb(CType(CType(190, Byte), Integer), CType(CType(180, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.cmbSYANAI_CD.ImeMode = System.Windows.Forms.ImeMode.[On]
        Me.cmbSYANAI_CD.Location = New System.Drawing.Point(103, 63)
        Me.cmbSYANAI_CD.Name = "cmbSYANAI_CD"
        Me.cmbSYANAI_CD.Selected = False
        Me.cmbSYANAI_CD.Size = New System.Drawing.Size(134, 25)
        Me.cmbSYANAI_CD.TabIndex = 10
        Me.cmbSYANAI_CD.Text = "(選択)"
        '
        'D003NCRJBindingSource
        '
        Me.D003NCRJBindingSource.DataSource = GetType(MODEL.D003_NCR_J)
        '
        'picZoom
        '
        Me.picZoom.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.picZoom.Cursor = System.Windows.Forms.Cursors.Hand
        Me.picZoom.Location = New System.Drawing.Point(12, 60)
        Me.picZoom.Name = "picZoom"
        Me.picZoom.Size = New System.Drawing.Size(1240, 529)
        Me.picZoom.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.picZoom.TabIndex = 126
        Me.picZoom.TabStop = False
        Me.picZoom.Visible = False
        '
        'TabSTAGE
        '
        Me.TabSTAGE.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TabSTAGE.Controls.Add(Me.tabSTAGE01)
        Me.TabSTAGE.Controls.Add(Me.tabSTAGE02)
        Me.TabSTAGE.Controls.Add(Me.tabSTAGE03)
        Me.TabSTAGE.Controls.Add(Me.tabSTAGE04)
        Me.TabSTAGE.Controls.Add(Me.tabSTAGE05)
        Me.TabSTAGE.Controls.Add(Me.tabSTAGE06)
        Me.TabSTAGE.Controls.Add(Me.tabSTAGE07)
        Me.TabSTAGE.Controls.Add(Me.tabSTAGE08)
        Me.TabSTAGE.Controls.Add(Me.tabSTAGE09)
        Me.TabSTAGE.Controls.Add(Me.tabSTAGE10)
        Me.TabSTAGE.Controls.Add(Me.tabSTAGE11)
        Me.TabSTAGE.Controls.Add(Me.tabSTAGE12)
        Me.TabSTAGE.Controls.Add(Me.tabAttachment)
        Me.TabSTAGE.Font = New System.Drawing.Font("Meiryo UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.TabSTAGE.HotTrack = True
        Me.TabSTAGE.Location = New System.Drawing.Point(15, 247)
        Me.TabSTAGE.Multiline = True
        Me.TabSTAGE.Name = "TabSTAGE"
        Me.TabSTAGE.SelectedIndex = 0
        Me.TabSTAGE.Size = New System.Drawing.Size(1237, 342)
        Me.TabSTAGE.TabIndex = 1
        '
        'tabSTAGE01
        '
        Me.tabSTAGE01.Controls.Add(Me.lblST01_Modoshi_Riyu)
        Me.tabSTAGE01.Controls.Add(Me.cmbST01_DestTANTO)
        Me.tabSTAGE01.Controls.Add(Me.mtxST01_NextStageName)
        Me.tabSTAGE01.Controls.Add(Me.Label123)
        Me.tabSTAGE01.Controls.Add(Me.Label124)
        Me.tabSTAGE01.Controls.Add(Me.Label139)
        Me.tabSTAGE01.Controls.Add(Me.mtxST01_UPD_YMD)
        Me.tabSTAGE01.Controls.Add(Me.Label17)
        Me.tabSTAGE01.Controls.Add(Me.txtST01_KEKKA)
        Me.tabSTAGE01.Controls.Add(Me.lblSTAGE01)
        Me.tabSTAGE01.Controls.Add(Me.Label15)
        Me.tabSTAGE01.Controls.Add(Me.txtST01_YOKYU_NAIYO)
        Me.tabSTAGE01.Location = New System.Drawing.Point(4, 26)
        Me.tabSTAGE01.Name = "tabSTAGE01"
        Me.tabSTAGE01.Padding = New System.Windows.Forms.Padding(3)
        Me.tabSTAGE01.Size = New System.Drawing.Size(1229, 312)
        Me.tabSTAGE01.TabIndex = 0
        Me.tabSTAGE01.Text = "STAGE01"
        Me.tabSTAGE01.UseVisualStyleBackColor = True
        '
        'lblST01_Modoshi_Riyu
        '
        Me.lblST01_Modoshi_Riyu.Font = New System.Drawing.Font("Meiryo UI", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.lblST01_Modoshi_Riyu.Location = New System.Drawing.Point(259, 6)
        Me.lblST01_Modoshi_Riyu.Name = "lblST01_Modoshi_Riyu"
        Me.lblST01_Modoshi_Riyu.Size = New System.Drawing.Size(556, 24)
        Me.lblST01_Modoshi_Riyu.TabIndex = 216
        Me.lblST01_Modoshi_Riyu.Text = "差戻理由：__________________________________________________________"
        Me.lblST01_Modoshi_Riyu.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.lblST01_Modoshi_Riyu.Visible = False
        '
        'cmbST01_DestTANTO
        '
        Me.cmbST01_DestTANTO.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cmbST01_DestTANTO.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cmbST01_DestTANTO.BackColor = System.Drawing.SystemColors.Window
        Me.cmbST01_DestTANTO.Cursor = System.Windows.Forms.Cursors.Hand
        Me.cmbST01_DestTANTO.Font = New System.Drawing.Font("Meiryo UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.cmbST01_DestTANTO.ForeColor = System.Drawing.SystemColors.ControlText
        Me.cmbST01_DestTANTO.FormattingEnabled = True
        Me.cmbST01_DestTANTO.GotFocusedColor = System.Drawing.Color.FromArgb(CType(CType(190, Byte), Integer), CType(CType(180, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.cmbST01_DestTANTO.ImeMode = System.Windows.Forms.ImeMode.[On]
        Me.cmbST01_DestTANTO.Location = New System.Drawing.Point(739, 282)
        Me.cmbST01_DestTANTO.Name = "cmbST01_DestTANTO"
        Me.cmbST01_DestTANTO.Selected = False
        Me.cmbST01_DestTANTO.Size = New System.Drawing.Size(154, 25)
        Me.cmbST01_DestTANTO.TabIndex = 4
        Me.cmbST01_DestTANTO.Text = "(選択)"
        '
        'mtxST01_NextStageName
        '
        Me.mtxST01_NextStageName.BackColor = System.Drawing.SystemColors.Window
        Me.mtxST01_NextStageName.Enabled = False
        Me.mtxST01_NextStageName.GotFocusedColor = System.Drawing.Color.FromArgb(CType(CType(190, Byte), Integer), CType(CType(180, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.mtxST01_NextStageName.ImeMode = System.Windows.Forms.ImeMode.Disable
        Me.mtxST01_NextStageName.InputRequired = False
        Me.mtxST01_NextStageName.Location = New System.Drawing.Point(359, 282)
        Me.mtxST01_NextStageName.Name = "mtxST01_NextStageName"
        Me.mtxST01_NextStageName.ReadOnly = True
        Me.mtxST01_NextStageName.Size = New System.Drawing.Size(296, 24)
        Me.mtxST01_NextStageName.TabIndex = 3
        Me.mtxST01_NextStageName.WatermarkColor = System.Drawing.Color.Empty
        Me.mtxST01_NextStageName.WatermarkText = Nothing
        '
        'Label123
        '
        Me.Label123.AutoSize = True
        Me.Label123.Font = New System.Drawing.Font("Meiryo UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label123.Location = New System.Drawing.Point(255, 287)
        Me.Label123.Margin = New System.Windows.Forms.Padding(3, 3, 3, 0)
        Me.Label123.Name = "Label123"
        Me.Label123.Size = New System.Drawing.Size(98, 15)
        Me.Label123.TabIndex = 213
        Me.Label123.Text = "承認先ステージ名:"
        Me.Label123.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label124
        '
        Me.Label124.AutoSize = True
        Me.Label124.Font = New System.Drawing.Font("Meiryo UI", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label124.Location = New System.Drawing.Point(661, 287)
        Me.Label124.Margin = New System.Windows.Forms.Padding(3, 3, 3, 0)
        Me.Label124.Name = "Label124"
        Me.Label124.Size = New System.Drawing.Size(72, 15)
        Me.Label124.TabIndex = 212
        Me.Label124.Text = "申請先社員:"
        Me.Label124.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label139
        '
        Me.Label139.AutoSize = True
        Me.Label139.Font = New System.Drawing.Font("Meiryo UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label139.Location = New System.Drawing.Point(10, 287)
        Me.Label139.Margin = New System.Windows.Forms.Padding(3, 3, 3, 0)
        Me.Label139.Name = "Label139"
        Me.Label139.Size = New System.Drawing.Size(102, 15)
        Me.Label139.TabIndex = 211
        Me.Label139.Text = "承認・申請年月日:"
        Me.Label139.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'mtxST01_UPD_YMD
        '
        Me.mtxST01_UPD_YMD.BackColor = System.Drawing.SystemColors.Window
        Me.mtxST01_UPD_YMD.Enabled = False
        Me.mtxST01_UPD_YMD.GotFocusedColor = System.Drawing.Color.FromArgb(CType(CType(190, Byte), Integer), CType(CType(180, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.mtxST01_UPD_YMD.ImeMode = System.Windows.Forms.ImeMode.Disable
        Me.mtxST01_UPD_YMD.InputRequired = False
        Me.mtxST01_UPD_YMD.Location = New System.Drawing.Point(118, 282)
        Me.mtxST01_UPD_YMD.Name = "mtxST01_UPD_YMD"
        Me.mtxST01_UPD_YMD.ReadOnly = True
        Me.mtxST01_UPD_YMD.Size = New System.Drawing.Size(115, 24)
        Me.mtxST01_UPD_YMD.TabIndex = 2
        Me.mtxST01_UPD_YMD.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.mtxST01_UPD_YMD.WatermarkColor = System.Drawing.Color.Empty
        Me.mtxST01_UPD_YMD.WatermarkText = Nothing
        '
        'Label17
        '
        Me.Label17.AutoSize = True
        Me.Label17.Font = New System.Drawing.Font("Meiryo UI", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label17.Location = New System.Drawing.Point(7, 145)
        Me.Label17.Margin = New System.Windows.Forms.Padding(3, 3, 3, 0)
        Me.Label17.Name = "Label17"
        Me.Label17.Size = New System.Drawing.Size(60, 15)
        Me.Label17.TabIndex = 125
        Me.Label17.Text = "観察結果:"
        Me.Label17.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'txtST01_KEKKA
        '
        Me.txtST01_KEKKA.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtST01_KEKKA.BackColor = System.Drawing.SystemColors.Window
        Me.txtST01_KEKKA.GotFocusedColor = System.Drawing.Color.FromArgb(CType(CType(190, Byte), Integer), CType(CType(180, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.txtST01_KEKKA.ImeMode = System.Windows.Forms.ImeMode.[On]
        Me.txtST01_KEKKA.Location = New System.Drawing.Point(10, 163)
        Me.txtST01_KEKKA.Multiline = True
        Me.txtST01_KEKKA.Name = "txtST01_KEKKA"
        Me.txtST01_KEKKA.Size = New System.Drawing.Size(1209, 81)
        Me.txtST01_KEKKA.TabIndex = 1
        Me.txtST01_KEKKA.WatermarkText = Nothing
        '
        'lblSTAGE01
        '
        Me.lblSTAGE01.AutoSize = True
        Me.lblSTAGE01.BackColor = System.Drawing.Color.Wheat
        Me.lblSTAGE01.Font = New System.Drawing.Font("Meiryo UI", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.lblSTAGE01.Location = New System.Drawing.Point(6, 6)
        Me.lblSTAGE01.Margin = New System.Windows.Forms.Padding(3, 3, 3, 0)
        Me.lblSTAGE01.Name = "lblSTAGE01"
        Me.lblSTAGE01.Size = New System.Drawing.Size(86, 24)
        Me.lblSTAGE01.TabIndex = 85
        Me.lblSTAGE01.Text = "起草入力"
        Me.lblSTAGE01.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label15
        '
        Me.Label15.AutoSize = True
        Me.Label15.Font = New System.Drawing.Font("Meiryo UI", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label15.Location = New System.Drawing.Point(6, 40)
        Me.Label15.Margin = New System.Windows.Forms.Padding(3, 3, 3, 0)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(60, 15)
        Me.Label15.TabIndex = 84
        Me.Label15.Text = "要求内容:"
        Me.Label15.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'txtST01_YOKYU_NAIYO
        '
        Me.txtST01_YOKYU_NAIYO.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtST01_YOKYU_NAIYO.BackColor = System.Drawing.SystemColors.Window
        Me.txtST01_YOKYU_NAIYO.GotFocusedColor = System.Drawing.Color.FromArgb(CType(CType(190, Byte), Integer), CType(CType(180, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.txtST01_YOKYU_NAIYO.ImeMode = System.Windows.Forms.ImeMode.[On]
        Me.txtST01_YOKYU_NAIYO.Location = New System.Drawing.Point(9, 58)
        Me.txtST01_YOKYU_NAIYO.Multiline = True
        Me.txtST01_YOKYU_NAIYO.Name = "txtST01_YOKYU_NAIYO"
        Me.txtST01_YOKYU_NAIYO.Size = New System.Drawing.Size(1210, 81)
        Me.txtST01_YOKYU_NAIYO.TabIndex = 0
        Me.txtST01_YOKYU_NAIYO.WatermarkText = Nothing
        '
        'tabSTAGE02
        '
        Me.tabSTAGE02.Controls.Add(Me.lblST02_Modoshi_Riyu)
        Me.tabSTAGE02.Controls.Add(Me.cmbST02_DestTANTO)
        Me.tabSTAGE02.Controls.Add(Me.mtxST02_NextStageName)
        Me.tabSTAGE02.Controls.Add(Me.Label27)
        Me.tabSTAGE02.Controls.Add(Me.Label28)
        Me.tabSTAGE02.Controls.Add(Me.Label29)
        Me.tabSTAGE02.Controls.Add(Me.txtST02_Comment)
        Me.tabSTAGE02.Controls.Add(Me.Label30)
        Me.tabSTAGE02.Controls.Add(Me.mtxST02_UPD_YMD)
        Me.tabSTAGE02.Controls.Add(Me.lblSTAGE02)
        Me.tabSTAGE02.Location = New System.Drawing.Point(4, 26)
        Me.tabSTAGE02.Name = "tabSTAGE02"
        Me.tabSTAGE02.Padding = New System.Windows.Forms.Padding(3)
        Me.tabSTAGE02.Size = New System.Drawing.Size(1229, 312)
        Me.tabSTAGE02.TabIndex = 1
        Me.tabSTAGE02.Text = "STAGE02"
        Me.tabSTAGE02.UseVisualStyleBackColor = True
        '
        'lblST02_Modoshi_Riyu
        '
        Me.lblST02_Modoshi_Riyu.Font = New System.Drawing.Font("Meiryo UI", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.lblST02_Modoshi_Riyu.Location = New System.Drawing.Point(259, 6)
        Me.lblST02_Modoshi_Riyu.Name = "lblST02_Modoshi_Riyu"
        Me.lblST02_Modoshi_Riyu.Size = New System.Drawing.Size(556, 24)
        Me.lblST02_Modoshi_Riyu.TabIndex = 217
        Me.lblST02_Modoshi_Riyu.Text = "差戻理由：__________________________________________________________"
        Me.lblST02_Modoshi_Riyu.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.lblST02_Modoshi_Riyu.Visible = False
        '
        'cmbST02_DestTANTO
        '
        Me.cmbST02_DestTANTO.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cmbST02_DestTANTO.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cmbST02_DestTANTO.BackColor = System.Drawing.SystemColors.Window
        Me.cmbST02_DestTANTO.Cursor = System.Windows.Forms.Cursors.Hand
        Me.cmbST02_DestTANTO.Font = New System.Drawing.Font("Meiryo UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.cmbST02_DestTANTO.ForeColor = System.Drawing.SystemColors.ControlText
        Me.cmbST02_DestTANTO.FormattingEnabled = True
        Me.cmbST02_DestTANTO.GotFocusedColor = System.Drawing.Color.FromArgb(CType(CType(190, Byte), Integer), CType(CType(180, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.cmbST02_DestTANTO.ImeMode = System.Windows.Forms.ImeMode.[On]
        Me.cmbST02_DestTANTO.Location = New System.Drawing.Point(739, 40)
        Me.cmbST02_DestTANTO.Name = "cmbST02_DestTANTO"
        Me.cmbST02_DestTANTO.Selected = False
        Me.cmbST02_DestTANTO.Size = New System.Drawing.Size(154, 25)
        Me.cmbST02_DestTANTO.TabIndex = 2
        Me.cmbST02_DestTANTO.Text = "(選択)"
        '
        'mtxST02_NextStageName
        '
        Me.mtxST02_NextStageName.BackColor = System.Drawing.SystemColors.Window
        Me.mtxST02_NextStageName.Enabled = False
        Me.mtxST02_NextStageName.GotFocusedColor = System.Drawing.Color.FromArgb(CType(CType(190, Byte), Integer), CType(CType(180, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.mtxST02_NextStageName.ImeMode = System.Windows.Forms.ImeMode.Disable
        Me.mtxST02_NextStageName.InputRequired = False
        Me.mtxST02_NextStageName.Location = New System.Drawing.Point(359, 40)
        Me.mtxST02_NextStageName.Name = "mtxST02_NextStageName"
        Me.mtxST02_NextStageName.Size = New System.Drawing.Size(296, 24)
        Me.mtxST02_NextStageName.TabIndex = 1
        Me.mtxST02_NextStageName.WatermarkColor = System.Drawing.Color.Empty
        Me.mtxST02_NextStageName.WatermarkText = Nothing
        '
        'Label27
        '
        Me.Label27.AutoSize = True
        Me.Label27.Font = New System.Drawing.Font("Meiryo UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label27.Location = New System.Drawing.Point(255, 45)
        Me.Label27.Margin = New System.Windows.Forms.Padding(3, 3, 3, 0)
        Me.Label27.Name = "Label27"
        Me.Label27.Size = New System.Drawing.Size(98, 15)
        Me.Label27.TabIndex = 207
        Me.Label27.Text = "承認先ステージ名:"
        Me.Label27.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label28
        '
        Me.Label28.AutoSize = True
        Me.Label28.Font = New System.Drawing.Font("Meiryo UI", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label28.Location = New System.Drawing.Point(661, 45)
        Me.Label28.Margin = New System.Windows.Forms.Padding(3, 3, 3, 0)
        Me.Label28.Name = "Label28"
        Me.Label28.Size = New System.Drawing.Size(72, 15)
        Me.Label28.TabIndex = 206
        Me.Label28.Text = "申請先社員:"
        Me.Label28.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label29
        '
        Me.Label29.AutoSize = True
        Me.Label29.Font = New System.Drawing.Font("Meiryo UI", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label29.Location = New System.Drawing.Point(63, 75)
        Me.Label29.Margin = New System.Windows.Forms.Padding(3, 3, 3, 0)
        Me.Label29.Name = "Label29"
        Me.Label29.Size = New System.Drawing.Size(49, 15)
        Me.Label29.TabIndex = 205
        Me.Label29.Text = "コメント:"
        Me.Label29.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'txtST02_Comment
        '
        Me.txtST02_Comment.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtST02_Comment.BackColor = System.Drawing.SystemColors.Window
        Me.txtST02_Comment.GotFocusedColor = System.Drawing.Color.FromArgb(CType(CType(190, Byte), Integer), CType(CType(180, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.txtST02_Comment.ImeMode = System.Windows.Forms.ImeMode.[On]
        Me.txtST02_Comment.Location = New System.Drawing.Point(118, 70)
        Me.txtST02_Comment.Multiline = True
        Me.txtST02_Comment.Name = "txtST02_Comment"
        Me.txtST02_Comment.Size = New System.Drawing.Size(1101, 58)
        Me.txtST02_Comment.TabIndex = 3
        Me.txtST02_Comment.WatermarkText = Nothing
        '
        'Label30
        '
        Me.Label30.AutoSize = True
        Me.Label30.Font = New System.Drawing.Font("Meiryo UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label30.Location = New System.Drawing.Point(10, 45)
        Me.Label30.Margin = New System.Windows.Forms.Padding(3, 3, 3, 0)
        Me.Label30.Name = "Label30"
        Me.Label30.Size = New System.Drawing.Size(102, 15)
        Me.Label30.TabIndex = 203
        Me.Label30.Text = "承認・申請年月日:"
        Me.Label30.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'mtxST02_UPD_YMD
        '
        Me.mtxST02_UPD_YMD.BackColor = System.Drawing.SystemColors.Window
        Me.mtxST02_UPD_YMD.Enabled = False
        Me.mtxST02_UPD_YMD.GotFocusedColor = System.Drawing.Color.FromArgb(CType(CType(190, Byte), Integer), CType(CType(180, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.mtxST02_UPD_YMD.ImeMode = System.Windows.Forms.ImeMode.Disable
        Me.mtxST02_UPD_YMD.InputRequired = False
        Me.mtxST02_UPD_YMD.Location = New System.Drawing.Point(118, 40)
        Me.mtxST02_UPD_YMD.Name = "mtxST02_UPD_YMD"
        Me.mtxST02_UPD_YMD.Size = New System.Drawing.Size(115, 24)
        Me.mtxST02_UPD_YMD.TabIndex = 0
        Me.mtxST02_UPD_YMD.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.mtxST02_UPD_YMD.WatermarkColor = System.Drawing.Color.Empty
        Me.mtxST02_UPD_YMD.WatermarkText = Nothing
        '
        'lblSTAGE02
        '
        Me.lblSTAGE02.AutoSize = True
        Me.lblSTAGE02.BackColor = System.Drawing.Color.Wheat
        Me.lblSTAGE02.Font = New System.Drawing.Font("Meiryo UI", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.lblSTAGE02.Location = New System.Drawing.Point(6, 6)
        Me.lblSTAGE02.Margin = New System.Windows.Forms.Padding(3, 3, 3, 0)
        Me.lblSTAGE02.Name = "lblSTAGE02"
        Me.lblSTAGE02.Size = New System.Drawing.Size(150, 24)
        Me.lblSTAGE02.TabIndex = 86
        Me.lblSTAGE02.Text = "起草確認製造GL"
        Me.lblSTAGE02.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'tabSTAGE03
        '
        Me.tabSTAGE03.Controls.Add(Me.lblST03_Modoshi_Riyu)
        Me.tabSTAGE03.Controls.Add(Me.cmbST03_DestTANTO)
        Me.tabSTAGE03.Controls.Add(Me.mtxST03_NextStageName)
        Me.tabSTAGE03.Controls.Add(Me.Label18)
        Me.tabSTAGE03.Controls.Add(Me.Label31)
        Me.tabSTAGE03.Controls.Add(Me.Label32)
        Me.tabSTAGE03.Controls.Add(Me.txtST03_Comment)
        Me.tabSTAGE03.Controls.Add(Me.Label33)
        Me.tabSTAGE03.Controls.Add(Me.mtxST03_UPD_YMD)
        Me.tabSTAGE03.Controls.Add(Me.lblSTAGE03)
        Me.tabSTAGE03.Location = New System.Drawing.Point(4, 26)
        Me.tabSTAGE03.Name = "tabSTAGE03"
        Me.tabSTAGE03.Size = New System.Drawing.Size(1229, 312)
        Me.tabSTAGE03.TabIndex = 2
        Me.tabSTAGE03.Text = "STAGE03"
        Me.tabSTAGE03.UseVisualStyleBackColor = True
        '
        'lblST03_Modoshi_Riyu
        '
        Me.lblST03_Modoshi_Riyu.Font = New System.Drawing.Font("Meiryo UI", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.lblST03_Modoshi_Riyu.Location = New System.Drawing.Point(259, 6)
        Me.lblST03_Modoshi_Riyu.Name = "lblST03_Modoshi_Riyu"
        Me.lblST03_Modoshi_Riyu.Size = New System.Drawing.Size(556, 24)
        Me.lblST03_Modoshi_Riyu.TabIndex = 218
        Me.lblST03_Modoshi_Riyu.Text = "差戻理由：__________________________________________________________"
        Me.lblST03_Modoshi_Riyu.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.lblST03_Modoshi_Riyu.Visible = False
        '
        'cmbST03_DestTANTO
        '
        Me.cmbST03_DestTANTO.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cmbST03_DestTANTO.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cmbST03_DestTANTO.BackColor = System.Drawing.SystemColors.Window
        Me.cmbST03_DestTANTO.Cursor = System.Windows.Forms.Cursors.Hand
        Me.cmbST03_DestTANTO.Font = New System.Drawing.Font("Meiryo UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.cmbST03_DestTANTO.ForeColor = System.Drawing.SystemColors.ControlText
        Me.cmbST03_DestTANTO.FormattingEnabled = True
        Me.cmbST03_DestTANTO.GotFocusedColor = System.Drawing.Color.FromArgb(CType(CType(190, Byte), Integer), CType(CType(180, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.cmbST03_DestTANTO.ImeMode = System.Windows.Forms.ImeMode.[On]
        Me.cmbST03_DestTANTO.Location = New System.Drawing.Point(739, 40)
        Me.cmbST03_DestTANTO.Name = "cmbST03_DestTANTO"
        Me.cmbST03_DestTANTO.Selected = False
        Me.cmbST03_DestTANTO.Size = New System.Drawing.Size(154, 25)
        Me.cmbST03_DestTANTO.TabIndex = 2
        Me.cmbST03_DestTANTO.Text = "(選択)"
        '
        'mtxST03_NextStageName
        '
        Me.mtxST03_NextStageName.BackColor = System.Drawing.SystemColors.Window
        Me.mtxST03_NextStageName.Enabled = False
        Me.mtxST03_NextStageName.GotFocusedColor = System.Drawing.Color.FromArgb(CType(CType(190, Byte), Integer), CType(CType(180, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.mtxST03_NextStageName.ImeMode = System.Windows.Forms.ImeMode.Disable
        Me.mtxST03_NextStageName.InputRequired = False
        Me.mtxST03_NextStageName.Location = New System.Drawing.Point(359, 40)
        Me.mtxST03_NextStageName.Name = "mtxST03_NextStageName"
        Me.mtxST03_NextStageName.Size = New System.Drawing.Size(296, 24)
        Me.mtxST03_NextStageName.TabIndex = 1
        Me.mtxST03_NextStageName.WatermarkColor = System.Drawing.Color.Empty
        Me.mtxST03_NextStageName.WatermarkText = Nothing
        '
        'Label18
        '
        Me.Label18.AutoSize = True
        Me.Label18.Font = New System.Drawing.Font("Meiryo UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label18.Location = New System.Drawing.Point(255, 45)
        Me.Label18.Margin = New System.Windows.Forms.Padding(3, 3, 3, 0)
        Me.Label18.Name = "Label18"
        Me.Label18.Size = New System.Drawing.Size(98, 15)
        Me.Label18.TabIndex = 215
        Me.Label18.Text = "承認先ステージ名:"
        Me.Label18.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label31
        '
        Me.Label31.AutoSize = True
        Me.Label31.Font = New System.Drawing.Font("Meiryo UI", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label31.Location = New System.Drawing.Point(661, 45)
        Me.Label31.Margin = New System.Windows.Forms.Padding(3, 3, 3, 0)
        Me.Label31.Name = "Label31"
        Me.Label31.Size = New System.Drawing.Size(72, 15)
        Me.Label31.TabIndex = 214
        Me.Label31.Text = "申請先社員:"
        Me.Label31.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label32
        '
        Me.Label32.AutoSize = True
        Me.Label32.Font = New System.Drawing.Font("Meiryo UI", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label32.Location = New System.Drawing.Point(63, 75)
        Me.Label32.Margin = New System.Windows.Forms.Padding(3, 3, 3, 0)
        Me.Label32.Name = "Label32"
        Me.Label32.Size = New System.Drawing.Size(49, 15)
        Me.Label32.TabIndex = 213
        Me.Label32.Text = "コメント:"
        Me.Label32.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'txtST03_Comment
        '
        Me.txtST03_Comment.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtST03_Comment.BackColor = System.Drawing.SystemColors.Window
        Me.txtST03_Comment.GotFocusedColor = System.Drawing.Color.FromArgb(CType(CType(190, Byte), Integer), CType(CType(180, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.txtST03_Comment.ImeMode = System.Windows.Forms.ImeMode.[On]
        Me.txtST03_Comment.Location = New System.Drawing.Point(118, 70)
        Me.txtST03_Comment.Multiline = True
        Me.txtST03_Comment.Name = "txtST03_Comment"
        Me.txtST03_Comment.Size = New System.Drawing.Size(1101, 58)
        Me.txtST03_Comment.TabIndex = 3
        Me.txtST03_Comment.WatermarkText = Nothing
        '
        'Label33
        '
        Me.Label33.AutoSize = True
        Me.Label33.Font = New System.Drawing.Font("Meiryo UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label33.Location = New System.Drawing.Point(10, 45)
        Me.Label33.Margin = New System.Windows.Forms.Padding(3, 3, 3, 0)
        Me.Label33.Name = "Label33"
        Me.Label33.Size = New System.Drawing.Size(102, 15)
        Me.Label33.TabIndex = 211
        Me.Label33.Text = "承認・申請年月日:"
        Me.Label33.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'mtxST03_UPD_YMD
        '
        Me.mtxST03_UPD_YMD.BackColor = System.Drawing.SystemColors.Window
        Me.mtxST03_UPD_YMD.Enabled = False
        Me.mtxST03_UPD_YMD.GotFocusedColor = System.Drawing.Color.FromArgb(CType(CType(190, Byte), Integer), CType(CType(180, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.mtxST03_UPD_YMD.ImeMode = System.Windows.Forms.ImeMode.Disable
        Me.mtxST03_UPD_YMD.InputRequired = False
        Me.mtxST03_UPD_YMD.Location = New System.Drawing.Point(118, 40)
        Me.mtxST03_UPD_YMD.Name = "mtxST03_UPD_YMD"
        Me.mtxST03_UPD_YMD.Size = New System.Drawing.Size(115, 24)
        Me.mtxST03_UPD_YMD.TabIndex = 0
        Me.mtxST03_UPD_YMD.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.mtxST03_UPD_YMD.WatermarkColor = System.Drawing.Color.Empty
        Me.mtxST03_UPD_YMD.WatermarkText = Nothing
        '
        'lblSTAGE03
        '
        Me.lblSTAGE03.AutoSize = True
        Me.lblSTAGE03.BackColor = System.Drawing.Color.Wheat
        Me.lblSTAGE03.Font = New System.Drawing.Font("Meiryo UI", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.lblSTAGE03.Location = New System.Drawing.Point(6, 6)
        Me.lblSTAGE03.Margin = New System.Windows.Forms.Padding(3, 3, 3, 0)
        Me.lblSTAGE03.Name = "lblSTAGE03"
        Me.lblSTAGE03.Size = New System.Drawing.Size(150, 24)
        Me.lblSTAGE03.TabIndex = 118
        Me.lblSTAGE03.Text = "起草確認製造GL"
        Me.lblSTAGE03.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'tabSTAGE04
        '
        Me.tabSTAGE04.Controls.Add(Me.chkST04_ZESEI_SYOCHI_YOHI_KB)
        Me.tabSTAGE04.Controls.Add(Me.FlowLayoutPanel2)
        Me.tabSTAGE04.Controls.Add(Me.lblST04_Modoshi_Riyu)
        Me.tabSTAGE04.Controls.Add(Me.cmbST04_DestTANTO)
        Me.tabSTAGE04.Controls.Add(Me.mtxST04_NextStageName)
        Me.tabSTAGE04.Controls.Add(Me.Label34)
        Me.tabSTAGE04.Controls.Add(Me.Label36)
        Me.tabSTAGE04.Controls.Add(Me.Label37)
        Me.tabSTAGE04.Controls.Add(Me.txtST04_Comment)
        Me.tabSTAGE04.Controls.Add(Me.Label38)
        Me.tabSTAGE04.Controls.Add(Me.mtxST04_UPD_YMD)
        Me.tabSTAGE04.Controls.Add(Me.lbltxtST04_RIYU)
        Me.tabSTAGE04.Controls.Add(Me.txtST04_RIYU)
        Me.tabSTAGE04.Controls.Add(Me.Label42)
        Me.tabSTAGE04.Controls.Add(Me.cmbST04_ZIZENSINSA_HANTEI)
        Me.tabSTAGE04.Controls.Add(Me.Label41)
        Me.tabSTAGE04.Controls.Add(Me.lblSTAGE04)
        Me.tabSTAGE04.Location = New System.Drawing.Point(4, 26)
        Me.tabSTAGE04.Name = "tabSTAGE04"
        Me.tabSTAGE04.Size = New System.Drawing.Size(1229, 312)
        Me.tabSTAGE04.TabIndex = 3
        Me.tabSTAGE04.Text = "STAGE04"
        Me.tabSTAGE04.UseVisualStyleBackColor = True
        '
        'chkST04_ZESEI_SYOCHI_YOHI_KB
        '
        Me.chkST04_ZESEI_SYOCHI_YOHI_KB.AutoSize = True
        Me.chkST04_ZESEI_SYOCHI_YOHI_KB.Location = New System.Drawing.Point(239, 74)
        Me.chkST04_ZESEI_SYOCHI_YOHI_KB.Name = "chkST04_ZESEI_SYOCHI_YOHI_KB"
        Me.chkST04_ZESEI_SYOCHI_YOHI_KB.Size = New System.Drawing.Size(189, 21)
        Me.chkST04_ZESEI_SYOCHI_YOHI_KB.TabIndex = 233
        Me.chkST04_ZESEI_SYOCHI_YOHI_KB.Text = "ZESEI_SYOCHI_YOHI_KB"
        Me.chkST04_ZESEI_SYOCHI_YOHI_KB.UseVisualStyleBackColor = True
        Me.chkST04_ZESEI_SYOCHI_YOHI_KB.Visible = False
        '
        'FlowLayoutPanel2
        '
        Me.FlowLayoutPanel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.FlowLayoutPanel2.Controls.Add(Me.rbtnST04_ZESEI_YES)
        Me.FlowLayoutPanel2.Controls.Add(Me.rbtnST04_ZESEI_NO)
        Me.FlowLayoutPanel2.Location = New System.Drawing.Point(118, 70)
        Me.FlowLayoutPanel2.Margin = New System.Windows.Forms.Padding(0)
        Me.FlowLayoutPanel2.Name = "FlowLayoutPanel2"
        Me.FlowLayoutPanel2.Padding = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.FlowLayoutPanel2.Size = New System.Drawing.Size(118, 28)
        Me.FlowLayoutPanel2.TabIndex = 232
        '
        'rbtnST04_ZESEI_YES
        '
        Me.rbtnST04_ZESEI_YES.AutoSize = True
        Me.rbtnST04_ZESEI_YES.Location = New System.Drawing.Point(7, 3)
        Me.rbtnST04_ZESEI_YES.Margin = New System.Windows.Forms.Padding(3, 3, 20, 3)
        Me.rbtnST04_ZESEI_YES.Name = "rbtnST04_ZESEI_YES"
        Me.rbtnST04_ZESEI_YES.Size = New System.Drawing.Size(39, 21)
        Me.rbtnST04_ZESEI_YES.TabIndex = 0
        Me.rbtnST04_ZESEI_YES.TabStop = True
        Me.rbtnST04_ZESEI_YES.Text = "要"
        Me.rbtnST04_ZESEI_YES.UseVisualStyleBackColor = True
        '
        'rbtnST04_ZESEI_NO
        '
        Me.rbtnST04_ZESEI_NO.AutoSize = True
        Me.rbtnST04_ZESEI_NO.Location = New System.Drawing.Point(69, 3)
        Me.rbtnST04_ZESEI_NO.Name = "rbtnST04_ZESEI_NO"
        Me.rbtnST04_ZESEI_NO.Size = New System.Drawing.Size(39, 21)
        Me.rbtnST04_ZESEI_NO.TabIndex = 1
        Me.rbtnST04_ZESEI_NO.TabStop = True
        Me.rbtnST04_ZESEI_NO.Text = "否"
        Me.rbtnST04_ZESEI_NO.UseVisualStyleBackColor = True
        '
        'lblST04_Modoshi_Riyu
        '
        Me.lblST04_Modoshi_Riyu.Font = New System.Drawing.Font("Meiryo UI", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.lblST04_Modoshi_Riyu.Location = New System.Drawing.Point(337, 6)
        Me.lblST04_Modoshi_Riyu.Name = "lblST04_Modoshi_Riyu"
        Me.lblST04_Modoshi_Riyu.Size = New System.Drawing.Size(556, 24)
        Me.lblST04_Modoshi_Riyu.TabIndex = 226
        Me.lblST04_Modoshi_Riyu.Text = "差戻理由：__________________________________________________________"
        Me.lblST04_Modoshi_Riyu.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.lblST04_Modoshi_Riyu.Visible = False
        '
        'cmbST04_DestTANTO
        '
        Me.cmbST04_DestTANTO.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cmbST04_DestTANTO.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cmbST04_DestTANTO.BackColor = System.Drawing.SystemColors.Window
        Me.cmbST04_DestTANTO.Cursor = System.Windows.Forms.Cursors.Hand
        Me.cmbST04_DestTANTO.Font = New System.Drawing.Font("Meiryo UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.cmbST04_DestTANTO.ForeColor = System.Drawing.SystemColors.ControlText
        Me.cmbST04_DestTANTO.FormattingEnabled = True
        Me.cmbST04_DestTANTO.GotFocusedColor = System.Drawing.Color.FromArgb(CType(CType(190, Byte), Integer), CType(CType(180, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.cmbST04_DestTANTO.ImeMode = System.Windows.Forms.ImeMode.[On]
        Me.cmbST04_DestTANTO.Location = New System.Drawing.Point(739, 221)
        Me.cmbST04_DestTANTO.Name = "cmbST04_DestTANTO"
        Me.cmbST04_DestTANTO.Selected = False
        Me.cmbST04_DestTANTO.Size = New System.Drawing.Size(154, 25)
        Me.cmbST04_DestTANTO.TabIndex = 4
        Me.cmbST04_DestTANTO.Text = "(選択)"
        '
        'mtxST04_NextStageName
        '
        Me.mtxST04_NextStageName.BackColor = System.Drawing.SystemColors.Window
        Me.mtxST04_NextStageName.Enabled = False
        Me.mtxST04_NextStageName.GotFocusedColor = System.Drawing.Color.FromArgb(CType(CType(190, Byte), Integer), CType(CType(180, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.mtxST04_NextStageName.ImeMode = System.Windows.Forms.ImeMode.Disable
        Me.mtxST04_NextStageName.InputRequired = False
        Me.mtxST04_NextStageName.Location = New System.Drawing.Point(359, 221)
        Me.mtxST04_NextStageName.Name = "mtxST04_NextStageName"
        Me.mtxST04_NextStageName.Size = New System.Drawing.Size(296, 24)
        Me.mtxST04_NextStageName.TabIndex = 3
        Me.mtxST04_NextStageName.WatermarkColor = System.Drawing.Color.Empty
        Me.mtxST04_NextStageName.WatermarkText = Nothing
        '
        'Label34
        '
        Me.Label34.AutoSize = True
        Me.Label34.Font = New System.Drawing.Font("Meiryo UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label34.Location = New System.Drawing.Point(255, 226)
        Me.Label34.Margin = New System.Windows.Forms.Padding(3, 3, 3, 0)
        Me.Label34.Name = "Label34"
        Me.Label34.Size = New System.Drawing.Size(98, 15)
        Me.Label34.TabIndex = 223
        Me.Label34.Text = "承認先ステージ名:"
        Me.Label34.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label36
        '
        Me.Label36.AutoSize = True
        Me.Label36.Font = New System.Drawing.Font("Meiryo UI", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label36.Location = New System.Drawing.Point(661, 226)
        Me.Label36.Margin = New System.Windows.Forms.Padding(3, 3, 3, 0)
        Me.Label36.Name = "Label36"
        Me.Label36.Size = New System.Drawing.Size(72, 15)
        Me.Label36.TabIndex = 222
        Me.Label36.Text = "申請先社員:"
        Me.Label36.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label37
        '
        Me.Label37.AutoSize = True
        Me.Label37.Font = New System.Drawing.Font("Meiryo UI", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label37.Location = New System.Drawing.Point(63, 256)
        Me.Label37.Margin = New System.Windows.Forms.Padding(3, 3, 3, 0)
        Me.Label37.Name = "Label37"
        Me.Label37.Size = New System.Drawing.Size(49, 15)
        Me.Label37.TabIndex = 221
        Me.Label37.Text = "コメント:"
        Me.Label37.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'txtST04_Comment
        '
        Me.txtST04_Comment.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtST04_Comment.BackColor = System.Drawing.SystemColors.Window
        Me.txtST04_Comment.GotFocusedColor = System.Drawing.Color.FromArgb(CType(CType(190, Byte), Integer), CType(CType(180, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.txtST04_Comment.ImeMode = System.Windows.Forms.ImeMode.[On]
        Me.txtST04_Comment.Location = New System.Drawing.Point(118, 251)
        Me.txtST04_Comment.Multiline = True
        Me.txtST04_Comment.Name = "txtST04_Comment"
        Me.txtST04_Comment.Size = New System.Drawing.Size(1101, 58)
        Me.txtST04_Comment.TabIndex = 5
        Me.txtST04_Comment.WatermarkText = Nothing
        '
        'Label38
        '
        Me.Label38.AutoSize = True
        Me.Label38.Font = New System.Drawing.Font("Meiryo UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label38.Location = New System.Drawing.Point(10, 226)
        Me.Label38.Margin = New System.Windows.Forms.Padding(3, 3, 3, 0)
        Me.Label38.Name = "Label38"
        Me.Label38.Size = New System.Drawing.Size(102, 15)
        Me.Label38.TabIndex = 219
        Me.Label38.Text = "承認・申請年月日:"
        Me.Label38.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'mtxST04_UPD_YMD
        '
        Me.mtxST04_UPD_YMD.BackColor = System.Drawing.SystemColors.Window
        Me.mtxST04_UPD_YMD.Enabled = False
        Me.mtxST04_UPD_YMD.GotFocusedColor = System.Drawing.Color.FromArgb(CType(CType(190, Byte), Integer), CType(CType(180, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.mtxST04_UPD_YMD.ImeMode = System.Windows.Forms.ImeMode.Disable
        Me.mtxST04_UPD_YMD.InputRequired = False
        Me.mtxST04_UPD_YMD.Location = New System.Drawing.Point(118, 221)
        Me.mtxST04_UPD_YMD.Name = "mtxST04_UPD_YMD"
        Me.mtxST04_UPD_YMD.Size = New System.Drawing.Size(115, 24)
        Me.mtxST04_UPD_YMD.TabIndex = 2
        Me.mtxST04_UPD_YMD.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.mtxST04_UPD_YMD.WatermarkColor = System.Drawing.Color.Empty
        Me.mtxST04_UPD_YMD.WatermarkText = Nothing
        '
        'lbltxtST04_RIYU
        '
        Me.lbltxtST04_RIYU.AutoSize = True
        Me.lbltxtST04_RIYU.Font = New System.Drawing.Font("Meiryo UI", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.lbltxtST04_RIYU.Location = New System.Drawing.Point(53, 109)
        Me.lbltxtST04_RIYU.Margin = New System.Windows.Forms.Padding(3, 3, 3, 0)
        Me.lbltxtST04_RIYU.Name = "lbltxtST04_RIYU"
        Me.lbltxtST04_RIYU.Size = New System.Drawing.Size(59, 15)
        Me.lbltxtST04_RIYU.TabIndex = 141
        Me.lbltxtST04_RIYU.Text = "否の理由:"
        Me.lbltxtST04_RIYU.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.lbltxtST04_RIYU.Visible = False
        '
        'txtST04_RIYU
        '
        Me.txtST04_RIYU.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtST04_RIYU.BackColor = System.Drawing.SystemColors.Window
        Me.txtST04_RIYU.GotFocusedColor = System.Drawing.Color.FromArgb(CType(CType(190, Byte), Integer), CType(CType(180, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.txtST04_RIYU.ImeMode = System.Windows.Forms.ImeMode.[On]
        Me.txtST04_RIYU.Location = New System.Drawing.Point(118, 104)
        Me.txtST04_RIYU.Multiline = True
        Me.txtST04_RIYU.Name = "txtST04_RIYU"
        Me.txtST04_RIYU.Size = New System.Drawing.Size(1101, 57)
        Me.txtST04_RIYU.TabIndex = 1
        Me.txtST04_RIYU.Visible = False
        Me.txtST04_RIYU.WatermarkText = Nothing
        '
        'Label42
        '
        Me.Label42.AutoSize = True
        Me.Label42.Font = New System.Drawing.Font("Meiryo UI", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label42.Location = New System.Drawing.Point(4, 78)
        Me.Label42.Margin = New System.Windows.Forms.Padding(3, 3, 3, 0)
        Me.Label42.Name = "Label42"
        Me.Label42.Size = New System.Drawing.Size(108, 15)
        Me.Label42.TabIndex = 138
        Me.Label42.Text = "是正処置要否判定:"
        Me.Label42.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'cmbST04_ZIZENSINSA_HANTEI
        '
        Me.cmbST04_ZIZENSINSA_HANTEI.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cmbST04_ZIZENSINSA_HANTEI.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cmbST04_ZIZENSINSA_HANTEI.BackColor = System.Drawing.SystemColors.Window
        Me.cmbST04_ZIZENSINSA_HANTEI.Cursor = System.Windows.Forms.Cursors.Hand
        Me.cmbST04_ZIZENSINSA_HANTEI.Font = New System.Drawing.Font("Meiryo UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.cmbST04_ZIZENSINSA_HANTEI.ForeColor = System.Drawing.SystemColors.ControlText
        Me.cmbST04_ZIZENSINSA_HANTEI.FormattingEnabled = True
        Me.cmbST04_ZIZENSINSA_HANTEI.GotFocusedColor = System.Drawing.Color.FromArgb(CType(CType(190, Byte), Integer), CType(CType(180, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.cmbST04_ZIZENSINSA_HANTEI.ImeMode = System.Windows.Forms.ImeMode.[On]
        Me.cmbST04_ZIZENSINSA_HANTEI.Location = New System.Drawing.Point(118, 42)
        Me.cmbST04_ZIZENSINSA_HANTEI.Name = "cmbST04_ZIZENSINSA_HANTEI"
        Me.cmbST04_ZIZENSINSA_HANTEI.Selected = False
        Me.cmbST04_ZIZENSINSA_HANTEI.Size = New System.Drawing.Size(118, 25)
        Me.cmbST04_ZIZENSINSA_HANTEI.TabIndex = 0
        Me.cmbST04_ZIZENSINSA_HANTEI.Text = "(選択)"
        '
        'Label41
        '
        Me.Label41.AutoSize = True
        Me.Label41.Font = New System.Drawing.Font("Meiryo UI", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label41.Location = New System.Drawing.Point(28, 47)
        Me.Label41.Margin = New System.Windows.Forms.Padding(3, 3, 3, 0)
        Me.Label41.Name = "Label41"
        Me.Label41.Size = New System.Drawing.Size(84, 15)
        Me.Label41.TabIndex = 136
        Me.Label41.Text = "事前審査判定:"
        Me.Label41.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'lblSTAGE04
        '
        Me.lblSTAGE04.AutoSize = True
        Me.lblSTAGE04.BackColor = System.Drawing.Color.Wheat
        Me.lblSTAGE04.Font = New System.Drawing.Font("Meiryo UI", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.lblSTAGE04.Location = New System.Drawing.Point(6, 6)
        Me.lblSTAGE04.Margin = New System.Windows.Forms.Padding(3, 3, 3, 0)
        Me.lblSTAGE04.Name = "lblSTAGE04"
        Me.lblSTAGE04.Size = New System.Drawing.Size(278, 24)
        Me.lblSTAGE04.TabIndex = 127
        Me.lblSTAGE04.Text = "事前審査判定及びCAR要否判定"
        Me.lblSTAGE04.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'tabSTAGE05
        '
        Me.tabSTAGE05.Controls.Add(Me.lblST05_Modoshi_Riyu)
        Me.tabSTAGE05.Controls.Add(Me.cmbST05_DestTANTO)
        Me.tabSTAGE05.Controls.Add(Me.mtxST05_NextStageName)
        Me.tabSTAGE05.Controls.Add(Me.Label45)
        Me.tabSTAGE05.Controls.Add(Me.Label46)
        Me.tabSTAGE05.Controls.Add(Me.Label47)
        Me.tabSTAGE05.Controls.Add(Me.txtST05_Comment)
        Me.tabSTAGE05.Controls.Add(Me.Label48)
        Me.tabSTAGE05.Controls.Add(Me.mtxST05_UPD_YMD)
        Me.tabSTAGE05.Controls.Add(Me.lblSTAGE05)
        Me.tabSTAGE05.Location = New System.Drawing.Point(4, 26)
        Me.tabSTAGE05.Name = "tabSTAGE05"
        Me.tabSTAGE05.Size = New System.Drawing.Size(1229, 312)
        Me.tabSTAGE05.TabIndex = 4
        Me.tabSTAGE05.Text = "STAGE05"
        Me.tabSTAGE05.UseVisualStyleBackColor = True
        '
        'lblST05_Modoshi_Riyu
        '
        Me.lblST05_Modoshi_Riyu.Font = New System.Drawing.Font("Meiryo UI", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.lblST05_Modoshi_Riyu.Location = New System.Drawing.Point(259, 6)
        Me.lblST05_Modoshi_Riyu.Name = "lblST05_Modoshi_Riyu"
        Me.lblST05_Modoshi_Riyu.Size = New System.Drawing.Size(556, 24)
        Me.lblST05_Modoshi_Riyu.TabIndex = 226
        Me.lblST05_Modoshi_Riyu.Text = "差戻理由：__________________________________________________________"
        Me.lblST05_Modoshi_Riyu.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.lblST05_Modoshi_Riyu.Visible = False
        '
        'cmbST05_DestTANTO
        '
        Me.cmbST05_DestTANTO.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cmbST05_DestTANTO.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cmbST05_DestTANTO.BackColor = System.Drawing.SystemColors.Window
        Me.cmbST05_DestTANTO.Cursor = System.Windows.Forms.Cursors.Hand
        Me.cmbST05_DestTANTO.Font = New System.Drawing.Font("Meiryo UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.cmbST05_DestTANTO.ForeColor = System.Drawing.SystemColors.ControlText
        Me.cmbST05_DestTANTO.FormattingEnabled = True
        Me.cmbST05_DestTANTO.GotFocusedColor = System.Drawing.Color.FromArgb(CType(CType(190, Byte), Integer), CType(CType(180, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.cmbST05_DestTANTO.ImeMode = System.Windows.Forms.ImeMode.[On]
        Me.cmbST05_DestTANTO.Location = New System.Drawing.Point(739, 40)
        Me.cmbST05_DestTANTO.Name = "cmbST05_DestTANTO"
        Me.cmbST05_DestTANTO.Selected = False
        Me.cmbST05_DestTANTO.Size = New System.Drawing.Size(154, 25)
        Me.cmbST05_DestTANTO.TabIndex = 2
        Me.cmbST05_DestTANTO.Text = "(選択)"
        '
        'mtxST05_NextStageName
        '
        Me.mtxST05_NextStageName.BackColor = System.Drawing.SystemColors.Window
        Me.mtxST05_NextStageName.Enabled = False
        Me.mtxST05_NextStageName.GotFocusedColor = System.Drawing.Color.FromArgb(CType(CType(190, Byte), Integer), CType(CType(180, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.mtxST05_NextStageName.ImeMode = System.Windows.Forms.ImeMode.Disable
        Me.mtxST05_NextStageName.InputRequired = False
        Me.mtxST05_NextStageName.Location = New System.Drawing.Point(359, 40)
        Me.mtxST05_NextStageName.Name = "mtxST05_NextStageName"
        Me.mtxST05_NextStageName.Size = New System.Drawing.Size(296, 24)
        Me.mtxST05_NextStageName.TabIndex = 1
        Me.mtxST05_NextStageName.WatermarkColor = System.Drawing.Color.Empty
        Me.mtxST05_NextStageName.WatermarkText = Nothing
        '
        'Label45
        '
        Me.Label45.AutoSize = True
        Me.Label45.Font = New System.Drawing.Font("Meiryo UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label45.Location = New System.Drawing.Point(255, 45)
        Me.Label45.Margin = New System.Windows.Forms.Padding(3, 3, 3, 0)
        Me.Label45.Name = "Label45"
        Me.Label45.Size = New System.Drawing.Size(98, 15)
        Me.Label45.TabIndex = 223
        Me.Label45.Text = "承認先ステージ名:"
        Me.Label45.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label46
        '
        Me.Label46.AutoSize = True
        Me.Label46.Font = New System.Drawing.Font("Meiryo UI", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label46.Location = New System.Drawing.Point(661, 45)
        Me.Label46.Margin = New System.Windows.Forms.Padding(3, 3, 3, 0)
        Me.Label46.Name = "Label46"
        Me.Label46.Size = New System.Drawing.Size(72, 15)
        Me.Label46.TabIndex = 222
        Me.Label46.Text = "申請先社員:"
        Me.Label46.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label47
        '
        Me.Label47.AutoSize = True
        Me.Label47.Font = New System.Drawing.Font("Meiryo UI", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label47.Location = New System.Drawing.Point(63, 75)
        Me.Label47.Margin = New System.Windows.Forms.Padding(3, 3, 3, 0)
        Me.Label47.Name = "Label47"
        Me.Label47.Size = New System.Drawing.Size(49, 15)
        Me.Label47.TabIndex = 221
        Me.Label47.Text = "コメント:"
        Me.Label47.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'txtST05_Comment
        '
        Me.txtST05_Comment.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtST05_Comment.BackColor = System.Drawing.SystemColors.Window
        Me.txtST05_Comment.GotFocusedColor = System.Drawing.Color.FromArgb(CType(CType(190, Byte), Integer), CType(CType(180, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.txtST05_Comment.ImeMode = System.Windows.Forms.ImeMode.[On]
        Me.txtST05_Comment.Location = New System.Drawing.Point(118, 70)
        Me.txtST05_Comment.Multiline = True
        Me.txtST05_Comment.Name = "txtST05_Comment"
        Me.txtST05_Comment.Size = New System.Drawing.Size(1101, 58)
        Me.txtST05_Comment.TabIndex = 3
        Me.txtST05_Comment.WatermarkText = Nothing
        '
        'Label48
        '
        Me.Label48.AutoSize = True
        Me.Label48.Font = New System.Drawing.Font("Meiryo UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label48.Location = New System.Drawing.Point(10, 45)
        Me.Label48.Margin = New System.Windows.Forms.Padding(3, 3, 3, 0)
        Me.Label48.Name = "Label48"
        Me.Label48.Size = New System.Drawing.Size(102, 15)
        Me.Label48.TabIndex = 219
        Me.Label48.Text = "承認・申請年月日:"
        Me.Label48.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'mtxST05_UPD_YMD
        '
        Me.mtxST05_UPD_YMD.BackColor = System.Drawing.SystemColors.Window
        Me.mtxST05_UPD_YMD.Enabled = False
        Me.mtxST05_UPD_YMD.GotFocusedColor = System.Drawing.Color.FromArgb(CType(CType(190, Byte), Integer), CType(CType(180, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.mtxST05_UPD_YMD.ImeMode = System.Windows.Forms.ImeMode.Disable
        Me.mtxST05_UPD_YMD.InputRequired = False
        Me.mtxST05_UPD_YMD.Location = New System.Drawing.Point(118, 40)
        Me.mtxST05_UPD_YMD.Name = "mtxST05_UPD_YMD"
        Me.mtxST05_UPD_YMD.Size = New System.Drawing.Size(115, 24)
        Me.mtxST05_UPD_YMD.TabIndex = 0
        Me.mtxST05_UPD_YMD.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.mtxST05_UPD_YMD.WatermarkColor = System.Drawing.Color.Empty
        Me.mtxST05_UPD_YMD.WatermarkText = Nothing
        '
        'lblSTAGE05
        '
        Me.lblSTAGE05.AutoSize = True
        Me.lblSTAGE05.BackColor = System.Drawing.Color.Wheat
        Me.lblSTAGE05.Font = New System.Drawing.Font("Meiryo UI", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.lblSTAGE05.Location = New System.Drawing.Point(6, 6)
        Me.lblSTAGE05.Margin = New System.Windows.Forms.Padding(3, 3, 3, 0)
        Me.lblSTAGE05.Name = "lblSTAGE05"
        Me.lblSTAGE05.Size = New System.Drawing.Size(124, 24)
        Me.lblSTAGE05.TabIndex = 128
        Me.lblSTAGE05.Text = "事前審査確認"
        Me.lblSTAGE05.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'tabSTAGE06
        '
        Me.tabSTAGE06.Controls.Add(Me.lblST06_Modoshi_Riyu)
        Me.tabSTAGE06.Controls.Add(Me.cmbST06_DestTANTO)
        Me.tabSTAGE06.Controls.Add(Me.mtxST06_NextStageName)
        Me.tabSTAGE06.Controls.Add(Me.Label49)
        Me.tabSTAGE06.Controls.Add(Me.Label50)
        Me.tabSTAGE06.Controls.Add(Me.Label51)
        Me.tabSTAGE06.Controls.Add(Me.txtST06_Comment)
        Me.tabSTAGE06.Controls.Add(Me.Label55)
        Me.tabSTAGE06.Controls.Add(Me.mtxST06_UPD_YMD)
        Me.tabSTAGE06.Controls.Add(Me.mtxST06_SAISIN_IINKAI_SIRYO_NO)
        Me.tabSTAGE06.Controls.Add(Me.Label52)
        Me.tabSTAGE06.Controls.Add(Me.cmbST06_SAISIN_IINKAI_HANTEI)
        Me.tabSTAGE06.Controls.Add(Me.Label53)
        Me.tabSTAGE06.Controls.Add(Me.lblSTAGE06)
        Me.tabSTAGE06.Location = New System.Drawing.Point(4, 26)
        Me.tabSTAGE06.Name = "tabSTAGE06"
        Me.tabSTAGE06.Size = New System.Drawing.Size(1229, 312)
        Me.tabSTAGE06.TabIndex = 5
        Me.tabSTAGE06.Text = "STAGE06"
        Me.tabSTAGE06.UseVisualStyleBackColor = True
        '
        'lblST06_Modoshi_Riyu
        '
        Me.lblST06_Modoshi_Riyu.Font = New System.Drawing.Font("Meiryo UI", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.lblST06_Modoshi_Riyu.Location = New System.Drawing.Point(259, 6)
        Me.lblST06_Modoshi_Riyu.Name = "lblST06_Modoshi_Riyu"
        Me.lblST06_Modoshi_Riyu.Size = New System.Drawing.Size(556, 24)
        Me.lblST06_Modoshi_Riyu.TabIndex = 226
        Me.lblST06_Modoshi_Riyu.Text = "差戻理由：__________________________________________________________"
        Me.lblST06_Modoshi_Riyu.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.lblST06_Modoshi_Riyu.Visible = False
        '
        'cmbST06_DestTANTO
        '
        Me.cmbST06_DestTANTO.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.cmbST06_DestTANTO.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cmbST06_DestTANTO.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cmbST06_DestTANTO.BackColor = System.Drawing.SystemColors.Window
        Me.cmbST06_DestTANTO.Cursor = System.Windows.Forms.Cursors.Hand
        Me.cmbST06_DestTANTO.Font = New System.Drawing.Font("Meiryo UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.cmbST06_DestTANTO.ForeColor = System.Drawing.SystemColors.ControlText
        Me.cmbST06_DestTANTO.FormattingEnabled = True
        Me.cmbST06_DestTANTO.GotFocusedColor = System.Drawing.Color.FromArgb(CType(CType(190, Byte), Integer), CType(CType(180, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.cmbST06_DestTANTO.ImeMode = System.Windows.Forms.ImeMode.[On]
        Me.cmbST06_DestTANTO.Location = New System.Drawing.Point(739, 221)
        Me.cmbST06_DestTANTO.Name = "cmbST06_DestTANTO"
        Me.cmbST06_DestTANTO.Selected = False
        Me.cmbST06_DestTANTO.Size = New System.Drawing.Size(154, 25)
        Me.cmbST06_DestTANTO.TabIndex = 4
        Me.cmbST06_DestTANTO.Text = "(選択)"
        '
        'mtxST06_NextStageName
        '
        Me.mtxST06_NextStageName.BackColor = System.Drawing.SystemColors.Window
        Me.mtxST06_NextStageName.Enabled = False
        Me.mtxST06_NextStageName.GotFocusedColor = System.Drawing.Color.FromArgb(CType(CType(190, Byte), Integer), CType(CType(180, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.mtxST06_NextStageName.ImeMode = System.Windows.Forms.ImeMode.Disable
        Me.mtxST06_NextStageName.InputRequired = False
        Me.mtxST06_NextStageName.Location = New System.Drawing.Point(359, 221)
        Me.mtxST06_NextStageName.Name = "mtxST06_NextStageName"
        Me.mtxST06_NextStageName.Size = New System.Drawing.Size(296, 24)
        Me.mtxST06_NextStageName.TabIndex = 3
        Me.mtxST06_NextStageName.WatermarkColor = System.Drawing.Color.Empty
        Me.mtxST06_NextStageName.WatermarkText = Nothing
        '
        'Label49
        '
        Me.Label49.AutoSize = True
        Me.Label49.Font = New System.Drawing.Font("Meiryo UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label49.Location = New System.Drawing.Point(255, 226)
        Me.Label49.Margin = New System.Windows.Forms.Padding(3, 3, 3, 0)
        Me.Label49.Name = "Label49"
        Me.Label49.Size = New System.Drawing.Size(98, 15)
        Me.Label49.TabIndex = 223
        Me.Label49.Text = "承認先ステージ名:"
        Me.Label49.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label50
        '
        Me.Label50.AutoSize = True
        Me.Label50.Font = New System.Drawing.Font("Meiryo UI", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label50.Location = New System.Drawing.Point(661, 226)
        Me.Label50.Margin = New System.Windows.Forms.Padding(3, 3, 3, 0)
        Me.Label50.Name = "Label50"
        Me.Label50.Size = New System.Drawing.Size(72, 15)
        Me.Label50.TabIndex = 222
        Me.Label50.Text = "申請先社員:"
        Me.Label50.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label51
        '
        Me.Label51.AutoSize = True
        Me.Label51.Font = New System.Drawing.Font("Meiryo UI", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label51.Location = New System.Drawing.Point(63, 256)
        Me.Label51.Margin = New System.Windows.Forms.Padding(3, 3, 3, 0)
        Me.Label51.Name = "Label51"
        Me.Label51.Size = New System.Drawing.Size(49, 15)
        Me.Label51.TabIndex = 221
        Me.Label51.Text = "コメント:"
        Me.Label51.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'txtST06_Comment
        '
        Me.txtST06_Comment.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtST06_Comment.BackColor = System.Drawing.SystemColors.Window
        Me.txtST06_Comment.GotFocusedColor = System.Drawing.Color.FromArgb(CType(CType(190, Byte), Integer), CType(CType(180, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.txtST06_Comment.ImeMode = System.Windows.Forms.ImeMode.[On]
        Me.txtST06_Comment.Location = New System.Drawing.Point(118, 251)
        Me.txtST06_Comment.Multiline = True
        Me.txtST06_Comment.Name = "txtST06_Comment"
        Me.txtST06_Comment.Size = New System.Drawing.Size(1101, 58)
        Me.txtST06_Comment.TabIndex = 5
        Me.txtST06_Comment.WatermarkText = Nothing
        '
        'Label55
        '
        Me.Label55.AutoSize = True
        Me.Label55.Font = New System.Drawing.Font("Meiryo UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label55.Location = New System.Drawing.Point(10, 226)
        Me.Label55.Margin = New System.Windows.Forms.Padding(3, 3, 3, 0)
        Me.Label55.Name = "Label55"
        Me.Label55.Size = New System.Drawing.Size(102, 15)
        Me.Label55.TabIndex = 219
        Me.Label55.Text = "承認・申請年月日:"
        Me.Label55.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'mtxST06_UPD_YMD
        '
        Me.mtxST06_UPD_YMD.BackColor = System.Drawing.SystemColors.Window
        Me.mtxST06_UPD_YMD.Enabled = False
        Me.mtxST06_UPD_YMD.GotFocusedColor = System.Drawing.Color.FromArgb(CType(CType(190, Byte), Integer), CType(CType(180, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.mtxST06_UPD_YMD.ImeMode = System.Windows.Forms.ImeMode.Disable
        Me.mtxST06_UPD_YMD.InputRequired = False
        Me.mtxST06_UPD_YMD.Location = New System.Drawing.Point(118, 221)
        Me.mtxST06_UPD_YMD.Name = "mtxST06_UPD_YMD"
        Me.mtxST06_UPD_YMD.Size = New System.Drawing.Size(115, 24)
        Me.mtxST06_UPD_YMD.TabIndex = 2
        Me.mtxST06_UPD_YMD.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.mtxST06_UPD_YMD.WatermarkColor = System.Drawing.Color.Empty
        Me.mtxST06_UPD_YMD.WatermarkText = Nothing
        '
        'mtxST06_SAISIN_IINKAI_SIRYO_NO
        '
        Me.mtxST06_SAISIN_IINKAI_SIRYO_NO.BackColor = System.Drawing.SystemColors.Window
        Me.mtxST06_SAISIN_IINKAI_SIRYO_NO.GotFocusedColor = System.Drawing.Color.FromArgb(CType(CType(190, Byte), Integer), CType(CType(180, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.mtxST06_SAISIN_IINKAI_SIRYO_NO.ImeMode = System.Windows.Forms.ImeMode.Disable
        Me.mtxST06_SAISIN_IINKAI_SIRYO_NO.InputRequired = False
        Me.mtxST06_SAISIN_IINKAI_SIRYO_NO.Location = New System.Drawing.Point(118, 73)
        Me.mtxST06_SAISIN_IINKAI_SIRYO_NO.Name = "mtxST06_SAISIN_IINKAI_SIRYO_NO"
        Me.mtxST06_SAISIN_IINKAI_SIRYO_NO.Size = New System.Drawing.Size(154, 24)
        Me.mtxST06_SAISIN_IINKAI_SIRYO_NO.TabIndex = 1
        Me.mtxST06_SAISIN_IINKAI_SIRYO_NO.WatermarkColor = System.Drawing.Color.Empty
        Me.mtxST06_SAISIN_IINKAI_SIRYO_NO.WatermarkText = Nothing
        '
        'Label52
        '
        Me.Label52.AutoSize = True
        Me.Label52.Font = New System.Drawing.Font("Meiryo UI", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label52.Location = New System.Drawing.Point(7, 78)
        Me.Label52.Margin = New System.Windows.Forms.Padding(3, 3, 3, 0)
        Me.Label52.Name = "Label52"
        Me.Label52.Size = New System.Drawing.Size(104, 14)
        Me.Label52.TabIndex = 153
        Me.Label52.Text = "再審委員会資料No:"
        Me.Label52.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'cmbST06_SAISIN_IINKAI_HANTEI
        '
        Me.cmbST06_SAISIN_IINKAI_HANTEI.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cmbST06_SAISIN_IINKAI_HANTEI.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cmbST06_SAISIN_IINKAI_HANTEI.BackColor = System.Drawing.SystemColors.Window
        Me.cmbST06_SAISIN_IINKAI_HANTEI.Cursor = System.Windows.Forms.Cursors.Hand
        Me.cmbST06_SAISIN_IINKAI_HANTEI.Font = New System.Drawing.Font("Meiryo UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.cmbST06_SAISIN_IINKAI_HANTEI.ForeColor = System.Drawing.SystemColors.ControlText
        Me.cmbST06_SAISIN_IINKAI_HANTEI.FormattingEnabled = True
        Me.cmbST06_SAISIN_IINKAI_HANTEI.GotFocusedColor = System.Drawing.Color.FromArgb(CType(CType(190, Byte), Integer), CType(CType(180, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.cmbST06_SAISIN_IINKAI_HANTEI.ImeMode = System.Windows.Forms.ImeMode.[On]
        Me.cmbST06_SAISIN_IINKAI_HANTEI.Location = New System.Drawing.Point(118, 42)
        Me.cmbST06_SAISIN_IINKAI_HANTEI.Name = "cmbST06_SAISIN_IINKAI_HANTEI"
        Me.cmbST06_SAISIN_IINKAI_HANTEI.Selected = False
        Me.cmbST06_SAISIN_IINKAI_HANTEI.Size = New System.Drawing.Size(118, 25)
        Me.cmbST06_SAISIN_IINKAI_HANTEI.TabIndex = 0
        Me.cmbST06_SAISIN_IINKAI_HANTEI.Text = "(選択)"
        '
        'Label53
        '
        Me.Label53.AutoSize = True
        Me.Label53.Font = New System.Drawing.Font("Meiryo UI", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label53.Location = New System.Drawing.Point(16, 47)
        Me.Label53.Margin = New System.Windows.Forms.Padding(3, 3, 3, 0)
        Me.Label53.Name = "Label53"
        Me.Label53.Size = New System.Drawing.Size(96, 15)
        Me.Label53.TabIndex = 151
        Me.Label53.Text = "再審委員会判定:"
        Me.Label53.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'lblSTAGE06
        '
        Me.lblSTAGE06.AutoSize = True
        Me.lblSTAGE06.BackColor = System.Drawing.Color.Wheat
        Me.lblSTAGE06.Font = New System.Drawing.Font("Meiryo UI", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.lblSTAGE06.Location = New System.Drawing.Point(6, 6)
        Me.lblSTAGE06.Margin = New System.Windows.Forms.Padding(3, 3, 3, 0)
        Me.lblSTAGE06.Name = "lblSTAGE06"
        Me.lblSTAGE06.Size = New System.Drawing.Size(124, 24)
        Me.lblSTAGE06.TabIndex = 150
        Me.lblSTAGE06.Text = "再審審査判定"
        Me.lblSTAGE06.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'tabSTAGE07
        '
        Me.tabSTAGE07.Controls.Add(Me.chkST07_SAIKAKO_SIJI_FLG)
        Me.tabSTAGE07.Controls.Add(Me.FlowLayoutPanel1)
        Me.tabSTAGE07.Controls.Add(Me.Label141)
        Me.tabSTAGE07.Controls.Add(Me.lblST07_Modoshi_Riyu)
        Me.tabSTAGE07.Controls.Add(Me.cmbST07_DestTANTO)
        Me.tabSTAGE07.Controls.Add(Me.mtxST07_NextStageName)
        Me.tabSTAGE07.Controls.Add(Me.Label56)
        Me.tabSTAGE07.Controls.Add(Me.Label57)
        Me.tabSTAGE07.Controls.Add(Me.Label58)
        Me.tabSTAGE07.Controls.Add(Me.txtST07_Comment)
        Me.tabSTAGE07.Controls.Add(Me.Label59)
        Me.tabSTAGE07.Controls.Add(Me.mtxST07_UPD_YMD)
        Me.tabSTAGE07.Controls.Add(Me.dtST07_KOKYAKU_SAISYU_HANTEI)
        Me.tabSTAGE07.Controls.Add(Me.dtST07_KOKYAKU_HANTEI_SIJI)
        Me.tabSTAGE07.Controls.Add(Me.Label66)
        Me.tabSTAGE07.Controls.Add(Me.cmbST07_KOKYAKU_HANTEI_SIJI)
        Me.tabSTAGE07.Controls.Add(Me.Label65)
        Me.tabSTAGE07.Controls.Add(Me.Label64)
        Me.tabSTAGE07.Controls.Add(Me.cmbST07_KOKYAKU_SAISYU_HANTEI)
        Me.tabSTAGE07.Controls.Add(Me.Label63)
        Me.tabSTAGE07.Controls.Add(Me.mtxST07_ITAG_NO)
        Me.tabSTAGE07.Controls.Add(Me.Label60)
        Me.tabSTAGE07.Controls.Add(Me.cmbST07_SAISIN_TANTO)
        Me.tabSTAGE07.Controls.Add(Me.Label61)
        Me.tabSTAGE07.Controls.Add(Me.lblSTAGE07)
        Me.tabSTAGE07.Location = New System.Drawing.Point(4, 26)
        Me.tabSTAGE07.Name = "tabSTAGE07"
        Me.tabSTAGE07.Size = New System.Drawing.Size(1229, 312)
        Me.tabSTAGE07.TabIndex = 6
        Me.tabSTAGE07.Text = "STAGE07"
        Me.tabSTAGE07.UseVisualStyleBackColor = True
        '
        'chkST07_SAIKAKO_SIJI_FLG
        '
        Me.chkST07_SAIKAKO_SIJI_FLG.AutoSize = True
        Me.chkST07_SAIKAKO_SIJI_FLG.Location = New System.Drawing.Point(236, 135)
        Me.chkST07_SAIKAKO_SIJI_FLG.Name = "chkST07_SAIKAKO_SIJI_FLG"
        Me.chkST07_SAIKAKO_SIJI_FLG.Size = New System.Drawing.Size(149, 21)
        Me.chkST07_SAIKAKO_SIJI_FLG.TabIndex = 234
        Me.chkST07_SAIKAKO_SIJI_FLG.Text = "SAIKAKO_SIJI_FLG"
        Me.chkST07_SAIKAKO_SIJI_FLG.UseVisualStyleBackColor = True
        Me.chkST07_SAIKAKO_SIJI_FLG.Visible = False
        '
        'FlowLayoutPanel1
        '
        Me.FlowLayoutPanel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.FlowLayoutPanel1.Controls.Add(Me.rbtnST07_Yes)
        Me.FlowLayoutPanel1.Controls.Add(Me.rbtnST07_No)
        Me.FlowLayoutPanel1.Location = New System.Drawing.Point(118, 132)
        Me.FlowLayoutPanel1.Margin = New System.Windows.Forms.Padding(0)
        Me.FlowLayoutPanel1.Name = "FlowLayoutPanel1"
        Me.FlowLayoutPanel1.Padding = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.FlowLayoutPanel1.Size = New System.Drawing.Size(115, 28)
        Me.FlowLayoutPanel1.TabIndex = 231
        '
        'rbtnST07_Yes
        '
        Me.rbtnST07_Yes.AutoSize = True
        Me.rbtnST07_Yes.Location = New System.Drawing.Point(7, 3)
        Me.rbtnST07_Yes.Margin = New System.Windows.Forms.Padding(3, 3, 18, 3)
        Me.rbtnST07_Yes.Name = "rbtnST07_Yes"
        Me.rbtnST07_Yes.Size = New System.Drawing.Size(39, 21)
        Me.rbtnST07_Yes.TabIndex = 0
        Me.rbtnST07_Yes.TabStop = True
        Me.rbtnST07_Yes.Text = "有"
        Me.rbtnST07_Yes.UseVisualStyleBackColor = True
        '
        'rbtnST07_No
        '
        Me.rbtnST07_No.AutoSize = True
        Me.rbtnST07_No.Location = New System.Drawing.Point(67, 3)
        Me.rbtnST07_No.Name = "rbtnST07_No"
        Me.rbtnST07_No.Size = New System.Drawing.Size(39, 21)
        Me.rbtnST07_No.TabIndex = 1
        Me.rbtnST07_No.TabStop = True
        Me.rbtnST07_No.Text = "無"
        Me.rbtnST07_No.UseVisualStyleBackColor = True
        '
        'Label141
        '
        Me.Label141.AutoSize = True
        Me.Label141.Font = New System.Drawing.Font("Meiryo UI", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label141.Location = New System.Drawing.Point(40, 138)
        Me.Label141.Margin = New System.Windows.Forms.Padding(3, 3, 3, 0)
        Me.Label141.Name = "Label141"
        Me.Label141.Size = New System.Drawing.Size(72, 15)
        Me.Label141.TabIndex = 228
        Me.Label141.Text = "再加工指示:"
        Me.Label141.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'lblST07_Modoshi_Riyu
        '
        Me.lblST07_Modoshi_Riyu.Font = New System.Drawing.Font("Meiryo UI", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.lblST07_Modoshi_Riyu.Location = New System.Drawing.Point(259, 6)
        Me.lblST07_Modoshi_Riyu.Name = "lblST07_Modoshi_Riyu"
        Me.lblST07_Modoshi_Riyu.Size = New System.Drawing.Size(556, 24)
        Me.lblST07_Modoshi_Riyu.TabIndex = 227
        Me.lblST07_Modoshi_Riyu.Text = "差戻理由：__________________________________________________________"
        Me.lblST07_Modoshi_Riyu.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.lblST07_Modoshi_Riyu.Visible = False
        '
        'cmbST07_DestTANTO
        '
        Me.cmbST07_DestTANTO.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cmbST07_DestTANTO.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cmbST07_DestTANTO.BackColor = System.Drawing.SystemColors.Window
        Me.cmbST07_DestTANTO.Cursor = System.Windows.Forms.Cursors.Hand
        Me.cmbST07_DestTANTO.Font = New System.Drawing.Font("Meiryo UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.cmbST07_DestTANTO.ForeColor = System.Drawing.SystemColors.ControlText
        Me.cmbST07_DestTANTO.FormattingEnabled = True
        Me.cmbST07_DestTANTO.GotFocusedColor = System.Drawing.Color.FromArgb(CType(CType(190, Byte), Integer), CType(CType(180, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.cmbST07_DestTANTO.ImeMode = System.Windows.Forms.ImeMode.[On]
        Me.cmbST07_DestTANTO.Location = New System.Drawing.Point(739, 221)
        Me.cmbST07_DestTANTO.Name = "cmbST07_DestTANTO"
        Me.cmbST07_DestTANTO.Selected = False
        Me.cmbST07_DestTANTO.Size = New System.Drawing.Size(154, 25)
        Me.cmbST07_DestTANTO.TabIndex = 8
        Me.cmbST07_DestTANTO.Text = "(選択)"
        '
        'mtxST07_NextStageName
        '
        Me.mtxST07_NextStageName.BackColor = System.Drawing.SystemColors.Window
        Me.mtxST07_NextStageName.Enabled = False
        Me.mtxST07_NextStageName.GotFocusedColor = System.Drawing.Color.FromArgb(CType(CType(190, Byte), Integer), CType(CType(180, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.mtxST07_NextStageName.ImeMode = System.Windows.Forms.ImeMode.Disable
        Me.mtxST07_NextStageName.InputRequired = False
        Me.mtxST07_NextStageName.Location = New System.Drawing.Point(359, 221)
        Me.mtxST07_NextStageName.Name = "mtxST07_NextStageName"
        Me.mtxST07_NextStageName.Size = New System.Drawing.Size(296, 24)
        Me.mtxST07_NextStageName.TabIndex = 7
        Me.mtxST07_NextStageName.WatermarkColor = System.Drawing.Color.Empty
        Me.mtxST07_NextStageName.WatermarkText = Nothing
        '
        'Label56
        '
        Me.Label56.AutoSize = True
        Me.Label56.Font = New System.Drawing.Font("Meiryo UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label56.Location = New System.Drawing.Point(255, 226)
        Me.Label56.Margin = New System.Windows.Forms.Padding(3, 3, 3, 0)
        Me.Label56.Name = "Label56"
        Me.Label56.Size = New System.Drawing.Size(98, 15)
        Me.Label56.TabIndex = 223
        Me.Label56.Text = "承認先ステージ名:"
        Me.Label56.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label57
        '
        Me.Label57.AutoSize = True
        Me.Label57.Font = New System.Drawing.Font("Meiryo UI", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label57.Location = New System.Drawing.Point(661, 226)
        Me.Label57.Margin = New System.Windows.Forms.Padding(3, 3, 3, 0)
        Me.Label57.Name = "Label57"
        Me.Label57.Size = New System.Drawing.Size(72, 15)
        Me.Label57.TabIndex = 222
        Me.Label57.Text = "申請先社員:"
        Me.Label57.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label58
        '
        Me.Label58.AutoSize = True
        Me.Label58.Font = New System.Drawing.Font("Meiryo UI", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label58.Location = New System.Drawing.Point(63, 256)
        Me.Label58.Margin = New System.Windows.Forms.Padding(3, 3, 3, 0)
        Me.Label58.Name = "Label58"
        Me.Label58.Size = New System.Drawing.Size(49, 15)
        Me.Label58.TabIndex = 221
        Me.Label58.Text = "コメント:"
        Me.Label58.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'txtST07_Comment
        '
        Me.txtST07_Comment.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtST07_Comment.BackColor = System.Drawing.SystemColors.Window
        Me.txtST07_Comment.GotFocusedColor = System.Drawing.Color.FromArgb(CType(CType(190, Byte), Integer), CType(CType(180, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.txtST07_Comment.ImeMode = System.Windows.Forms.ImeMode.[On]
        Me.txtST07_Comment.Location = New System.Drawing.Point(118, 251)
        Me.txtST07_Comment.Multiline = True
        Me.txtST07_Comment.Name = "txtST07_Comment"
        Me.txtST07_Comment.Size = New System.Drawing.Size(1101, 58)
        Me.txtST07_Comment.TabIndex = 9
        Me.txtST07_Comment.WatermarkText = Nothing
        '
        'Label59
        '
        Me.Label59.AutoSize = True
        Me.Label59.Font = New System.Drawing.Font("Meiryo UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label59.Location = New System.Drawing.Point(10, 226)
        Me.Label59.Margin = New System.Windows.Forms.Padding(3, 3, 3, 0)
        Me.Label59.Name = "Label59"
        Me.Label59.Size = New System.Drawing.Size(102, 15)
        Me.Label59.TabIndex = 219
        Me.Label59.Text = "承認・申請年月日:"
        Me.Label59.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'mtxST07_UPD_YMD
        '
        Me.mtxST07_UPD_YMD.BackColor = System.Drawing.SystemColors.Window
        Me.mtxST07_UPD_YMD.Enabled = False
        Me.mtxST07_UPD_YMD.GotFocusedColor = System.Drawing.Color.FromArgb(CType(CType(190, Byte), Integer), CType(CType(180, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.mtxST07_UPD_YMD.ImeMode = System.Windows.Forms.ImeMode.Disable
        Me.mtxST07_UPD_YMD.InputRequired = False
        Me.mtxST07_UPD_YMD.Location = New System.Drawing.Point(118, 221)
        Me.mtxST07_UPD_YMD.Name = "mtxST07_UPD_YMD"
        Me.mtxST07_UPD_YMD.Size = New System.Drawing.Size(115, 24)
        Me.mtxST07_UPD_YMD.TabIndex = 6
        Me.mtxST07_UPD_YMD.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.mtxST07_UPD_YMD.WatermarkColor = System.Drawing.Color.Empty
        Me.mtxST07_UPD_YMD.WatermarkText = Nothing
        '
        'dtST07_KOKYAKU_SAISYU_HANTEI
        '
        Me.dtST07_KOKYAKU_SAISYU_HANTEI.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.dtST07_KOKYAKU_SAISYU_HANTEI.GotFocusedColor = System.Drawing.Color.FromArgb(CType(CType(190, Byte), Integer), CType(CType(180, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.dtST07_KOKYAKU_SAISYU_HANTEI.Location = New System.Drawing.Point(382, 103)
        Me.dtST07_KOKYAKU_SAISYU_HANTEI.MaxDate = New Date(9998, 12, 31, 0, 0, 0, 0)
        Me.dtST07_KOKYAKU_SAISYU_HANTEI.MinDate = New Date(1753, 1, 1, 0, 0, 0, 0)
        Me.dtST07_KOKYAKU_SAISYU_HANTEI.MinimumSize = New System.Drawing.Size(98, 24)
        Me.dtST07_KOKYAKU_SAISYU_HANTEI.Name = "dtST07_KOKYAKU_SAISYU_HANTEI"
        Me.dtST07_KOKYAKU_SAISYU_HANTEI.Size = New System.Drawing.Size(104, 24)
        Me.dtST07_KOKYAKU_SAISYU_HANTEI.TabIndex = 5
        Me.dtST07_KOKYAKU_SAISYU_HANTEI.Value = ""
        Me.dtST07_KOKYAKU_SAISYU_HANTEI.ValueNonFormat = ""
        '
        'dtST07_KOKYAKU_HANTEI_SIJI
        '
        Me.dtST07_KOKYAKU_HANTEI_SIJI.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.dtST07_KOKYAKU_HANTEI_SIJI.GotFocusedColor = System.Drawing.Color.FromArgb(CType(CType(190, Byte), Integer), CType(CType(180, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.dtST07_KOKYAKU_HANTEI_SIJI.Location = New System.Drawing.Point(739, 73)
        Me.dtST07_KOKYAKU_HANTEI_SIJI.MaxDate = New Date(9998, 12, 31, 0, 0, 0, 0)
        Me.dtST07_KOKYAKU_HANTEI_SIJI.MinDate = New Date(1753, 1, 1, 0, 0, 0, 0)
        Me.dtST07_KOKYAKU_HANTEI_SIJI.MinimumSize = New System.Drawing.Size(98, 24)
        Me.dtST07_KOKYAKU_HANTEI_SIJI.Name = "dtST07_KOKYAKU_HANTEI_SIJI"
        Me.dtST07_KOKYAKU_HANTEI_SIJI.Size = New System.Drawing.Size(104, 24)
        Me.dtST07_KOKYAKU_HANTEI_SIJI.TabIndex = 3
        Me.dtST07_KOKYAKU_HANTEI_SIJI.Value = ""
        Me.dtST07_KOKYAKU_HANTEI_SIJI.ValueNonFormat = ""
        '
        'Label66
        '
        Me.Label66.AutoSize = True
        Me.Label66.Font = New System.Drawing.Font("Meiryo UI", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label66.Location = New System.Drawing.Point(292, 77)
        Me.Label66.Margin = New System.Windows.Forms.Padding(3, 3, 3, 0)
        Me.Label66.Name = "Label66"
        Me.Label66.Size = New System.Drawing.Size(84, 15)
        Me.Label66.TabIndex = 186
        Me.Label66.Text = "顧客判定指示:"
        Me.Label66.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'cmbST07_KOKYAKU_HANTEI_SIJI
        '
        Me.cmbST07_KOKYAKU_HANTEI_SIJI.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cmbST07_KOKYAKU_HANTEI_SIJI.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cmbST07_KOKYAKU_HANTEI_SIJI.BackColor = System.Drawing.SystemColors.Window
        Me.cmbST07_KOKYAKU_HANTEI_SIJI.Cursor = System.Windows.Forms.Cursors.Hand
        Me.cmbST07_KOKYAKU_HANTEI_SIJI.Font = New System.Drawing.Font("Meiryo UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.cmbST07_KOKYAKU_HANTEI_SIJI.ForeColor = System.Drawing.SystemColors.ControlText
        Me.cmbST07_KOKYAKU_HANTEI_SIJI.FormattingEnabled = True
        Me.cmbST07_KOKYAKU_HANTEI_SIJI.GotFocusedColor = System.Drawing.Color.FromArgb(CType(CType(190, Byte), Integer), CType(CType(180, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.cmbST07_KOKYAKU_HANTEI_SIJI.ImeMode = System.Windows.Forms.ImeMode.[On]
        Me.cmbST07_KOKYAKU_HANTEI_SIJI.Location = New System.Drawing.Point(382, 72)
        Me.cmbST07_KOKYAKU_HANTEI_SIJI.Name = "cmbST07_KOKYAKU_HANTEI_SIJI"
        Me.cmbST07_KOKYAKU_HANTEI_SIJI.Selected = False
        Me.cmbST07_KOKYAKU_HANTEI_SIJI.Size = New System.Drawing.Size(154, 25)
        Me.cmbST07_KOKYAKU_HANTEI_SIJI.TabIndex = 2
        Me.cmbST07_KOKYAKU_HANTEI_SIJI.Text = "(選択)"
        '
        'Label65
        '
        Me.Label65.AutoSize = True
        Me.Label65.Font = New System.Drawing.Font("Meiryo UI", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label65.Location = New System.Drawing.Point(661, 77)
        Me.Label65.Margin = New System.Windows.Forms.Padding(3, 3, 3, 0)
        Me.Label65.Name = "Label65"
        Me.Label65.Size = New System.Drawing.Size(72, 15)
        Me.Label65.TabIndex = 184
        Me.Label65.Text = "顧客判定日:"
        Me.Label65.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label64
        '
        Me.Label64.AutoSize = True
        Me.Label64.Font = New System.Drawing.Font("Meiryo UI", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label64.Location = New System.Drawing.Point(4, 108)
        Me.Label64.Margin = New System.Windows.Forms.Padding(3, 3, 3, 0)
        Me.Label64.Name = "Label64"
        Me.Label64.Size = New System.Drawing.Size(108, 15)
        Me.Label64.TabIndex = 182
        Me.Label64.Text = "顧客最終判定区分:"
        Me.Label64.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'cmbST07_KOKYAKU_SAISYU_HANTEI
        '
        Me.cmbST07_KOKYAKU_SAISYU_HANTEI.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cmbST07_KOKYAKU_SAISYU_HANTEI.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cmbST07_KOKYAKU_SAISYU_HANTEI.BackColor = System.Drawing.SystemColors.Window
        Me.cmbST07_KOKYAKU_SAISYU_HANTEI.Cursor = System.Windows.Forms.Cursors.Default
        Me.cmbST07_KOKYAKU_SAISYU_HANTEI.Font = New System.Drawing.Font("Meiryo UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.cmbST07_KOKYAKU_SAISYU_HANTEI.ForeColor = System.Drawing.SystemColors.ControlText
        Me.cmbST07_KOKYAKU_SAISYU_HANTEI.FormattingEnabled = True
        Me.cmbST07_KOKYAKU_SAISYU_HANTEI.GotFocusedColor = System.Drawing.Color.FromArgb(CType(CType(190, Byte), Integer), CType(CType(180, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.cmbST07_KOKYAKU_SAISYU_HANTEI.ImeMode = System.Windows.Forms.ImeMode.[On]
        Me.cmbST07_KOKYAKU_SAISYU_HANTEI.Location = New System.Drawing.Point(118, 103)
        Me.cmbST07_KOKYAKU_SAISYU_HANTEI.Name = "cmbST07_KOKYAKU_SAISYU_HANTEI"
        Me.cmbST07_KOKYAKU_SAISYU_HANTEI.Selected = False
        Me.cmbST07_KOKYAKU_SAISYU_HANTEI.Size = New System.Drawing.Size(154, 25)
        Me.cmbST07_KOKYAKU_SAISYU_HANTEI.TabIndex = 4
        Me.cmbST07_KOKYAKU_SAISYU_HANTEI.Text = "(選択)"
        '
        'Label63
        '
        Me.Label63.AutoSize = True
        Me.Label63.Font = New System.Drawing.Font("Meiryo UI", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label63.Location = New System.Drawing.Point(280, 108)
        Me.Label63.Margin = New System.Windows.Forms.Padding(3, 3, 3, 0)
        Me.Label63.Name = "Label63"
        Me.Label63.Size = New System.Drawing.Size(96, 15)
        Me.Label63.TabIndex = 180
        Me.Label63.Text = "顧客最終判定日:"
        Me.Label63.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'mtxST07_ITAG_NO
        '
        Me.mtxST07_ITAG_NO.BackColor = System.Drawing.SystemColors.Window
        Me.mtxST07_ITAG_NO.GotFocusedColor = System.Drawing.Color.FromArgb(CType(CType(190, Byte), Integer), CType(CType(180, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.mtxST07_ITAG_NO.ImeMode = System.Windows.Forms.ImeMode.Disable
        Me.mtxST07_ITAG_NO.InputRequired = False
        Me.mtxST07_ITAG_NO.Location = New System.Drawing.Point(118, 42)
        Me.mtxST07_ITAG_NO.Name = "mtxST07_ITAG_NO"
        Me.mtxST07_ITAG_NO.Size = New System.Drawing.Size(154, 24)
        Me.mtxST07_ITAG_NO.TabIndex = 0
        Me.mtxST07_ITAG_NO.WatermarkColor = System.Drawing.Color.Empty
        Me.mtxST07_ITAG_NO.WatermarkText = Nothing
        '
        'Label60
        '
        Me.Label60.AutoSize = True
        Me.Label60.Font = New System.Drawing.Font("Meiryo UI", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label60.Location = New System.Drawing.Point(4, 77)
        Me.Label60.Margin = New System.Windows.Forms.Padding(3, 3, 3, 0)
        Me.Label60.Name = "Label60"
        Me.Label60.Size = New System.Drawing.Size(108, 15)
        Me.Label60.TabIndex = 169
        Me.Label60.Text = "顧客再審申請担当:"
        Me.Label60.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'cmbST07_SAISIN_TANTO
        '
        Me.cmbST07_SAISIN_TANTO.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cmbST07_SAISIN_TANTO.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cmbST07_SAISIN_TANTO.BackColor = System.Drawing.SystemColors.Window
        Me.cmbST07_SAISIN_TANTO.Cursor = System.Windows.Forms.Cursors.Default
        Me.cmbST07_SAISIN_TANTO.Font = New System.Drawing.Font("Meiryo UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.cmbST07_SAISIN_TANTO.ForeColor = System.Drawing.SystemColors.ControlText
        Me.cmbST07_SAISIN_TANTO.FormattingEnabled = True
        Me.cmbST07_SAISIN_TANTO.GotFocusedColor = System.Drawing.Color.FromArgb(CType(CType(190, Byte), Integer), CType(CType(180, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.cmbST07_SAISIN_TANTO.ImeMode = System.Windows.Forms.ImeMode.[On]
        Me.cmbST07_SAISIN_TANTO.Location = New System.Drawing.Point(118, 72)
        Me.cmbST07_SAISIN_TANTO.Name = "cmbST07_SAISIN_TANTO"
        Me.cmbST07_SAISIN_TANTO.Selected = False
        Me.cmbST07_SAISIN_TANTO.Size = New System.Drawing.Size(154, 25)
        Me.cmbST07_SAISIN_TANTO.TabIndex = 1
        Me.cmbST07_SAISIN_TANTO.Text = "(選択)"
        '
        'Label61
        '
        Me.Label61.AutoSize = True
        Me.Label61.Font = New System.Drawing.Font("Meiryo UI", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label61.Location = New System.Drawing.Point(47, 47)
        Me.Label61.Margin = New System.Windows.Forms.Padding(3, 3, 3, 0)
        Me.Label61.Name = "Label61"
        Me.Label61.Size = New System.Drawing.Size(65, 15)
        Me.Label61.TabIndex = 167
        Me.Label61.Text = "ITAG No:"
        Me.Label61.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'lblSTAGE07
        '
        Me.lblSTAGE07.AutoSize = True
        Me.lblSTAGE07.BackColor = System.Drawing.Color.Wheat
        Me.lblSTAGE07.Font = New System.Drawing.Font("Meiryo UI", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.lblSTAGE07.Location = New System.Drawing.Point(6, 6)
        Me.lblSTAGE07.Margin = New System.Windows.Forms.Padding(3, 3, 3, 0)
        Me.lblSTAGE07.Name = "lblSTAGE07"
        Me.lblSTAGE07.Size = New System.Drawing.Size(124, 24)
        Me.lblSTAGE07.TabIndex = 166
        Me.lblSTAGE07.Text = "顧客再審処置"
        Me.lblSTAGE07.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'tabSTAGE08
        '
        Me.tabSTAGE08.Controls.Add(Me.lblST08_Modoshi_Riyu)
        Me.tabSTAGE08.Controls.Add(Me.cmbST08_DestTANTO)
        Me.tabSTAGE08.Controls.Add(Me.mtxST08_NextStageName)
        Me.tabSTAGE08.Controls.Add(Me.Label67)
        Me.tabSTAGE08.Controls.Add(Me.Label68)
        Me.tabSTAGE08.Controls.Add(Me.Label69)
        Me.tabSTAGE08.Controls.Add(Me.txtST08_Comment)
        Me.tabSTAGE08.Controls.Add(Me.Label70)
        Me.tabSTAGE08.Controls.Add(Me.mtxST08_UPD_YMD)
        Me.tabSTAGE08.Controls.Add(Me.tabST08_SUB)
        Me.tabSTAGE08.Controls.Add(Me.lblSTAGE08)
        Me.tabSTAGE08.Location = New System.Drawing.Point(4, 26)
        Me.tabSTAGE08.Name = "tabSTAGE08"
        Me.tabSTAGE08.Size = New System.Drawing.Size(1229, 312)
        Me.tabSTAGE08.TabIndex = 7
        Me.tabSTAGE08.Text = "STAGE08"
        Me.tabSTAGE08.UseVisualStyleBackColor = True
        '
        'lblST08_Modoshi_Riyu
        '
        Me.lblST08_Modoshi_Riyu.Font = New System.Drawing.Font("Meiryo UI", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.lblST08_Modoshi_Riyu.Location = New System.Drawing.Point(259, 6)
        Me.lblST08_Modoshi_Riyu.Name = "lblST08_Modoshi_Riyu"
        Me.lblST08_Modoshi_Riyu.Size = New System.Drawing.Size(556, 24)
        Me.lblST08_Modoshi_Riyu.TabIndex = 226
        Me.lblST08_Modoshi_Riyu.Text = "差戻理由：__________________________________________________________"
        Me.lblST08_Modoshi_Riyu.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.lblST08_Modoshi_Riyu.Visible = False
        '
        'cmbST08_DestTANTO
        '
        Me.cmbST08_DestTANTO.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cmbST08_DestTANTO.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cmbST08_DestTANTO.BackColor = System.Drawing.SystemColors.Window
        Me.cmbST08_DestTANTO.Cursor = System.Windows.Forms.Cursors.Hand
        Me.cmbST08_DestTANTO.Font = New System.Drawing.Font("Meiryo UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.cmbST08_DestTANTO.ForeColor = System.Drawing.SystemColors.ControlText
        Me.cmbST08_DestTANTO.FormattingEnabled = True
        Me.cmbST08_DestTANTO.GotFocusedColor = System.Drawing.Color.FromArgb(CType(CType(190, Byte), Integer), CType(CType(180, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.cmbST08_DestTANTO.ImeMode = System.Windows.Forms.ImeMode.[On]
        Me.cmbST08_DestTANTO.Location = New System.Drawing.Point(739, 221)
        Me.cmbST08_DestTANTO.Name = "cmbST08_DestTANTO"
        Me.cmbST08_DestTANTO.Selected = False
        Me.cmbST08_DestTANTO.Size = New System.Drawing.Size(154, 25)
        Me.cmbST08_DestTANTO.TabIndex = 3
        Me.cmbST08_DestTANTO.Text = "(選択)"
        '
        'mtxST08_NextStageName
        '
        Me.mtxST08_NextStageName.BackColor = System.Drawing.SystemColors.Window
        Me.mtxST08_NextStageName.Enabled = False
        Me.mtxST08_NextStageName.GotFocusedColor = System.Drawing.Color.FromArgb(CType(CType(190, Byte), Integer), CType(CType(180, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.mtxST08_NextStageName.ImeMode = System.Windows.Forms.ImeMode.Disable
        Me.mtxST08_NextStageName.InputRequired = False
        Me.mtxST08_NextStageName.Location = New System.Drawing.Point(359, 221)
        Me.mtxST08_NextStageName.Name = "mtxST08_NextStageName"
        Me.mtxST08_NextStageName.Size = New System.Drawing.Size(296, 24)
        Me.mtxST08_NextStageName.TabIndex = 2
        Me.mtxST08_NextStageName.WatermarkColor = System.Drawing.Color.Empty
        Me.mtxST08_NextStageName.WatermarkText = Nothing
        '
        'Label67
        '
        Me.Label67.AutoSize = True
        Me.Label67.Font = New System.Drawing.Font("Meiryo UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label67.Location = New System.Drawing.Point(255, 226)
        Me.Label67.Margin = New System.Windows.Forms.Padding(3, 3, 3, 0)
        Me.Label67.Name = "Label67"
        Me.Label67.Size = New System.Drawing.Size(98, 15)
        Me.Label67.TabIndex = 223
        Me.Label67.Text = "承認先ステージ名:"
        Me.Label67.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label68
        '
        Me.Label68.AutoSize = True
        Me.Label68.Font = New System.Drawing.Font("Meiryo UI", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label68.Location = New System.Drawing.Point(661, 226)
        Me.Label68.Margin = New System.Windows.Forms.Padding(3, 3, 3, 0)
        Me.Label68.Name = "Label68"
        Me.Label68.Size = New System.Drawing.Size(72, 15)
        Me.Label68.TabIndex = 222
        Me.Label68.Text = "申請先社員:"
        Me.Label68.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label69
        '
        Me.Label69.AutoSize = True
        Me.Label69.Font = New System.Drawing.Font("Meiryo UI", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label69.Location = New System.Drawing.Point(63, 256)
        Me.Label69.Margin = New System.Windows.Forms.Padding(3, 3, 3, 0)
        Me.Label69.Name = "Label69"
        Me.Label69.Size = New System.Drawing.Size(49, 15)
        Me.Label69.TabIndex = 221
        Me.Label69.Text = "コメント:"
        Me.Label69.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'txtST08_Comment
        '
        Me.txtST08_Comment.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtST08_Comment.BackColor = System.Drawing.SystemColors.Window
        Me.txtST08_Comment.GotFocusedColor = System.Drawing.Color.FromArgb(CType(CType(190, Byte), Integer), CType(CType(180, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.txtST08_Comment.ImeMode = System.Windows.Forms.ImeMode.[On]
        Me.txtST08_Comment.Location = New System.Drawing.Point(118, 251)
        Me.txtST08_Comment.Multiline = True
        Me.txtST08_Comment.Name = "txtST08_Comment"
        Me.txtST08_Comment.Size = New System.Drawing.Size(1101, 58)
        Me.txtST08_Comment.TabIndex = 4
        Me.txtST08_Comment.WatermarkText = Nothing
        '
        'Label70
        '
        Me.Label70.AutoSize = True
        Me.Label70.Font = New System.Drawing.Font("Meiryo UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label70.Location = New System.Drawing.Point(10, 226)
        Me.Label70.Margin = New System.Windows.Forms.Padding(3, 3, 3, 0)
        Me.Label70.Name = "Label70"
        Me.Label70.Size = New System.Drawing.Size(102, 15)
        Me.Label70.TabIndex = 219
        Me.Label70.Text = "承認・申請年月日:"
        Me.Label70.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'mtxST08_UPD_YMD
        '
        Me.mtxST08_UPD_YMD.BackColor = System.Drawing.SystemColors.Window
        Me.mtxST08_UPD_YMD.Enabled = False
        Me.mtxST08_UPD_YMD.GotFocusedColor = System.Drawing.Color.FromArgb(CType(CType(190, Byte), Integer), CType(CType(180, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.mtxST08_UPD_YMD.ImeMode = System.Windows.Forms.ImeMode.Disable
        Me.mtxST08_UPD_YMD.InputRequired = False
        Me.mtxST08_UPD_YMD.Location = New System.Drawing.Point(118, 221)
        Me.mtxST08_UPD_YMD.Name = "mtxST08_UPD_YMD"
        Me.mtxST08_UPD_YMD.Size = New System.Drawing.Size(115, 24)
        Me.mtxST08_UPD_YMD.TabIndex = 1
        Me.mtxST08_UPD_YMD.WatermarkColor = System.Drawing.Color.Empty
        Me.mtxST08_UPD_YMD.WatermarkText = Nothing
        '
        'tabST08_SUB
        '
        Me.tabST08_SUB.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.tabST08_SUB.Controls.Add(Me.tabSTAGE08_1)
        Me.tabST08_SUB.Controls.Add(Me.tabSTAGE08_2)
        Me.tabST08_SUB.Controls.Add(Me.tabSTAGE08_3)
        Me.tabST08_SUB.Controls.Add(Me.tabSTAGE08_4)
        Me.tabST08_SUB.Location = New System.Drawing.Point(13, 33)
        Me.tabST08_SUB.Name = "tabST08_SUB"
        Me.tabST08_SUB.SelectedIndex = 0
        Me.tabST08_SUB.Size = New System.Drawing.Size(1206, 182)
        Me.tabST08_SUB.TabIndex = 0
        '
        'tabSTAGE08_1
        '
        Me.tabSTAGE08_1.Controls.Add(Me.btnST08_1_SRCH_TANTO)
        Me.tabSTAGE08_1.Controls.Add(Me.cmbST08_1_HAIKYAKU_TANTO)
        Me.tabSTAGE08_1.Controls.Add(Me.Label74)
        Me.tabSTAGE08_1.Controls.Add(Me.mtxST08_1_BIKO)
        Me.tabSTAGE08_1.Controls.Add(Me.Label73)
        Me.tabSTAGE08_1.Controls.Add(Me.cmbST08_1_HAIKYAKU_KB)
        Me.tabSTAGE08_1.Controls.Add(Me.Label72)
        Me.tabSTAGE08_1.Controls.Add(Me.Label71)
        Me.tabSTAGE08_1.Controls.Add(Me.dtST08_1_HAIKYAKU_YMD)
        Me.tabSTAGE08_1.Location = New System.Drawing.Point(4, 26)
        Me.tabSTAGE08_1.Name = "tabSTAGE08_1"
        Me.tabSTAGE08_1.Padding = New System.Windows.Forms.Padding(3)
        Me.tabSTAGE08_1.Size = New System.Drawing.Size(1198, 152)
        Me.tabSTAGE08_1.TabIndex = 0
        Me.tabSTAGE08_1.Text = "廃棄実施記録"
        Me.tabSTAGE08_1.UseVisualStyleBackColor = True
        '
        'btnST08_1_SRCH_TANTO
        '
        Me.btnST08_1_SRCH_TANTO.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnST08_1_SRCH_TANTO.Font = New System.Drawing.Font("Meiryo UI", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.btnST08_1_SRCH_TANTO.Location = New System.Drawing.Point(261, 96)
        Me.btnST08_1_SRCH_TANTO.Name = "btnST08_1_SRCH_TANTO"
        Me.btnST08_1_SRCH_TANTO.Size = New System.Drawing.Size(54, 26)
        Me.btnST08_1_SRCH_TANTO.TabIndex = 4
        Me.btnST08_1_SRCH_TANTO.Text = "検索"
        Me.btnST08_1_SRCH_TANTO.UseVisualStyleBackColor = True
        Me.btnST08_1_SRCH_TANTO.Visible = False
        '
        'cmbST08_1_HAIKYAKU_TANTO
        '
        Me.cmbST08_1_HAIKYAKU_TANTO.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cmbST08_1_HAIKYAKU_TANTO.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cmbST08_1_HAIKYAKU_TANTO.BackColor = System.Drawing.SystemColors.Window
        Me.cmbST08_1_HAIKYAKU_TANTO.Cursor = System.Windows.Forms.Cursors.Hand
        Me.cmbST08_1_HAIKYAKU_TANTO.Font = New System.Drawing.Font("Meiryo UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.cmbST08_1_HAIKYAKU_TANTO.ForeColor = System.Drawing.SystemColors.ControlText
        Me.cmbST08_1_HAIKYAKU_TANTO.FormattingEnabled = True
        Me.cmbST08_1_HAIKYAKU_TANTO.GotFocusedColor = System.Drawing.Color.FromArgb(CType(CType(190, Byte), Integer), CType(CType(180, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.cmbST08_1_HAIKYAKU_TANTO.ImeMode = System.Windows.Forms.ImeMode.[On]
        Me.cmbST08_1_HAIKYAKU_TANTO.Location = New System.Drawing.Point(101, 97)
        Me.cmbST08_1_HAIKYAKU_TANTO.Name = "cmbST08_1_HAIKYAKU_TANTO"
        Me.cmbST08_1_HAIKYAKU_TANTO.Selected = False
        Me.cmbST08_1_HAIKYAKU_TANTO.Size = New System.Drawing.Size(154, 25)
        Me.cmbST08_1_HAIKYAKU_TANTO.TabIndex = 3
        Me.cmbST08_1_HAIKYAKU_TANTO.Text = "(選択)"
        '
        'Label74
        '
        Me.Label74.AutoSize = True
        Me.Label74.Font = New System.Drawing.Font("Meiryo UI", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label74.Location = New System.Drawing.Point(47, 102)
        Me.Label74.Margin = New System.Windows.Forms.Padding(3, 3, 3, 0)
        Me.Label74.Name = "Label74"
        Me.Label74.Size = New System.Drawing.Size(48, 15)
        Me.Label74.TabIndex = 230
        Me.Label74.Text = "実施者:"
        Me.Label74.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'mtxST08_1_BIKO
        '
        Me.mtxST08_1_BIKO.BackColor = System.Drawing.SystemColors.Window
        Me.mtxST08_1_BIKO.GotFocusedColor = System.Drawing.Color.FromArgb(CType(CType(190, Byte), Integer), CType(CType(180, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.mtxST08_1_BIKO.ImeMode = System.Windows.Forms.ImeMode.[On]
        Me.mtxST08_1_BIKO.InputRequired = False
        Me.mtxST08_1_BIKO.Location = New System.Drawing.Point(101, 67)
        Me.mtxST08_1_BIKO.Name = "mtxST08_1_BIKO"
        Me.mtxST08_1_BIKO.Size = New System.Drawing.Size(775, 24)
        Me.mtxST08_1_BIKO.TabIndex = 2
        Me.mtxST08_1_BIKO.WatermarkColor = System.Drawing.Color.Empty
        Me.mtxST08_1_BIKO.WatermarkText = Nothing
        '
        'Label73
        '
        Me.Label73.AutoSize = True
        Me.Label73.Font = New System.Drawing.Font("Meiryo UI", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label73.Location = New System.Drawing.Point(16, 72)
        Me.Label73.Margin = New System.Windows.Forms.Padding(3, 3, 3, 0)
        Me.Label73.Name = "Label73"
        Me.Label73.Size = New System.Drawing.Size(79, 15)
        Me.Label73.TabIndex = 228
        Me.Label73.Text = "その他の内容:"
        Me.Label73.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'cmbST08_1_HAIKYAKU_KB
        '
        Me.cmbST08_1_HAIKYAKU_KB.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cmbST08_1_HAIKYAKU_KB.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cmbST08_1_HAIKYAKU_KB.BackColor = System.Drawing.SystemColors.Window
        Me.cmbST08_1_HAIKYAKU_KB.Cursor = System.Windows.Forms.Cursors.Hand
        Me.cmbST08_1_HAIKYAKU_KB.Font = New System.Drawing.Font("Meiryo UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.cmbST08_1_HAIKYAKU_KB.ForeColor = System.Drawing.SystemColors.ControlText
        Me.cmbST08_1_HAIKYAKU_KB.FormattingEnabled = True
        Me.cmbST08_1_HAIKYAKU_KB.GotFocusedColor = System.Drawing.Color.FromArgb(CType(CType(190, Byte), Integer), CType(CType(180, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.cmbST08_1_HAIKYAKU_KB.ImeMode = System.Windows.Forms.ImeMode.[On]
        Me.cmbST08_1_HAIKYAKU_KB.Location = New System.Drawing.Point(101, 36)
        Me.cmbST08_1_HAIKYAKU_KB.Name = "cmbST08_1_HAIKYAKU_KB"
        Me.cmbST08_1_HAIKYAKU_KB.Selected = False
        Me.cmbST08_1_HAIKYAKU_KB.Size = New System.Drawing.Size(154, 25)
        Me.cmbST08_1_HAIKYAKU_KB.TabIndex = 1
        Me.cmbST08_1_HAIKYAKU_KB.Text = "(選択)"
        '
        'Label72
        '
        Me.Label72.AutoSize = True
        Me.Label72.Font = New System.Drawing.Font("Meiryo UI", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label72.Location = New System.Drawing.Point(35, 41)
        Me.Label72.Margin = New System.Windows.Forms.Padding(3, 3, 3, 0)
        Me.Label72.Name = "Label72"
        Me.Label72.Size = New System.Drawing.Size(60, 15)
        Me.Label72.TabIndex = 226
        Me.Label72.Text = "廃却方法:"
        Me.Label72.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label71
        '
        Me.Label71.AutoSize = True
        Me.Label71.Font = New System.Drawing.Font("Meiryo UI", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label71.Location = New System.Drawing.Point(23, 10)
        Me.Label71.Name = "Label71"
        Me.Label71.Size = New System.Drawing.Size(72, 15)
        Me.Label71.TabIndex = 95
        Me.Label71.Text = "廃却年月日:"
        Me.Label71.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'dtST08_1_HAIKYAKU_YMD
        '
        Me.dtST08_1_HAIKYAKU_YMD.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.dtST08_1_HAIKYAKU_YMD.GotFocusedColor = System.Drawing.Color.FromArgb(CType(CType(190, Byte), Integer), CType(CType(180, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.dtST08_1_HAIKYAKU_YMD.Location = New System.Drawing.Point(101, 6)
        Me.dtST08_1_HAIKYAKU_YMD.MaxDate = New Date(9998, 12, 31, 0, 0, 0, 0)
        Me.dtST08_1_HAIKYAKU_YMD.MinDate = New Date(1753, 1, 1, 0, 0, 0, 0)
        Me.dtST08_1_HAIKYAKU_YMD.MinimumSize = New System.Drawing.Size(98, 24)
        Me.dtST08_1_HAIKYAKU_YMD.Name = "dtST08_1_HAIKYAKU_YMD"
        Me.dtST08_1_HAIKYAKU_YMD.Size = New System.Drawing.Size(98, 24)
        Me.dtST08_1_HAIKYAKU_YMD.TabIndex = 0
        Me.dtST08_1_HAIKYAKU_YMD.Value = ""
        Me.dtST08_1_HAIKYAKU_YMD.ValueNonFormat = ""
        '
        'tabSTAGE08_2
        '
        Me.tabSTAGE08_2.Controls.Add(Me.btnST08_2_SRCH_TANTO_SEIGI)
        Me.tabSTAGE08_2.Controls.Add(Me.cmbST08_2_TANTO_SEIGI)
        Me.tabSTAGE08_2.Controls.Add(Me.Label82)
        Me.tabSTAGE08_2.Controls.Add(Me.btnST08_2_SRCH_TANTO_SEIZO)
        Me.tabSTAGE08_2.Controls.Add(Me.cmbST08_2_TANTO_SEIZO)
        Me.tabSTAGE08_2.Controls.Add(Me.Label81)
        Me.tabSTAGE08_2.Controls.Add(Me.dtST08_2_KENSA_YMD)
        Me.tabSTAGE08_2.Controls.Add(Me.cmbST08_2_KENSA_KEKKA)
        Me.tabSTAGE08_2.Controls.Add(Me.Label80)
        Me.tabSTAGE08_2.Controls.Add(Me.mtxST08_2_DOC_NO)
        Me.tabSTAGE08_2.Controls.Add(Me.btnST08_2_SRCH_TANTO_KENSA)
        Me.tabSTAGE08_2.Controls.Add(Me.cmbST08_2_TANTO_KENSA)
        Me.tabSTAGE08_2.Controls.Add(Me.Label75)
        Me.tabSTAGE08_2.Controls.Add(Me.Label76)
        Me.tabSTAGE08_2.Controls.Add(Me.Label78)
        Me.tabSTAGE08_2.Controls.Add(Me.Label79)
        Me.tabSTAGE08_2.Controls.Add(Me.dtST08_2_WorkOutYMD)
        Me.tabSTAGE08_2.Location = New System.Drawing.Point(4, 26)
        Me.tabSTAGE08_2.Name = "tabSTAGE08_2"
        Me.tabSTAGE08_2.Padding = New System.Windows.Forms.Padding(3)
        Me.tabSTAGE08_2.Size = New System.Drawing.Size(1198, 152)
        Me.tabSTAGE08_2.TabIndex = 1
        Me.tabSTAGE08_2.Text = "再加工指示/記録"
        Me.tabSTAGE08_2.UseVisualStyleBackColor = True
        '
        'btnST08_2_SRCH_TANTO_SEIGI
        '
        Me.btnST08_2_SRCH_TANTO_SEIGI.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnST08_2_SRCH_TANTO_SEIGI.Font = New System.Drawing.Font("Meiryo UI", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.btnST08_2_SRCH_TANTO_SEIGI.Location = New System.Drawing.Point(682, 97)
        Me.btnST08_2_SRCH_TANTO_SEIGI.Name = "btnST08_2_SRCH_TANTO_SEIGI"
        Me.btnST08_2_SRCH_TANTO_SEIGI.Size = New System.Drawing.Size(54, 24)
        Me.btnST08_2_SRCH_TANTO_SEIGI.TabIndex = 7
        Me.btnST08_2_SRCH_TANTO_SEIGI.Text = "検索"
        Me.btnST08_2_SRCH_TANTO_SEIGI.UseVisualStyleBackColor = True
        Me.btnST08_2_SRCH_TANTO_SEIGI.Visible = False
        '
        'cmbST08_2_TANTO_SEIGI
        '
        Me.cmbST08_2_TANTO_SEIGI.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cmbST08_2_TANTO_SEIGI.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cmbST08_2_TANTO_SEIGI.BackColor = System.Drawing.SystemColors.Window
        Me.cmbST08_2_TANTO_SEIGI.Cursor = System.Windows.Forms.Cursors.Hand
        Me.cmbST08_2_TANTO_SEIGI.Font = New System.Drawing.Font("Meiryo UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.cmbST08_2_TANTO_SEIGI.ForeColor = System.Drawing.SystemColors.ControlText
        Me.cmbST08_2_TANTO_SEIGI.FormattingEnabled = True
        Me.cmbST08_2_TANTO_SEIGI.GotFocusedColor = System.Drawing.Color.FromArgb(CType(CType(190, Byte), Integer), CType(CType(180, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.cmbST08_2_TANTO_SEIGI.ImeMode = System.Windows.Forms.ImeMode.[On]
        Me.cmbST08_2_TANTO_SEIGI.Location = New System.Drawing.Point(522, 96)
        Me.cmbST08_2_TANTO_SEIGI.Name = "cmbST08_2_TANTO_SEIGI"
        Me.cmbST08_2_TANTO_SEIGI.Selected = False
        Me.cmbST08_2_TANTO_SEIGI.Size = New System.Drawing.Size(154, 25)
        Me.cmbST08_2_TANTO_SEIGI.TabIndex = 6
        Me.cmbST08_2_TANTO_SEIGI.Text = "(選択)"
        '
        'Label82
        '
        Me.Label82.AutoSize = True
        Me.Label82.Font = New System.Drawing.Font("Meiryo UI", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label82.Location = New System.Drawing.Point(456, 101)
        Me.Label82.Margin = New System.Windows.Forms.Padding(3, 3, 3, 0)
        Me.Label82.Name = "Label82"
        Me.Label82.Size = New System.Drawing.Size(60, 15)
        Me.Label82.TabIndex = 250
        Me.Label82.Text = "生技担当:"
        Me.Label82.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'btnST08_2_SRCH_TANTO_SEIZO
        '
        Me.btnST08_2_SRCH_TANTO_SEIZO.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnST08_2_SRCH_TANTO_SEIZO.Font = New System.Drawing.Font("Meiryo UI", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.btnST08_2_SRCH_TANTO_SEIZO.Location = New System.Drawing.Point(261, 97)
        Me.btnST08_2_SRCH_TANTO_SEIZO.Name = "btnST08_2_SRCH_TANTO_SEIZO"
        Me.btnST08_2_SRCH_TANTO_SEIZO.Size = New System.Drawing.Size(54, 24)
        Me.btnST08_2_SRCH_TANTO_SEIZO.TabIndex = 5
        Me.btnST08_2_SRCH_TANTO_SEIZO.Text = "検索"
        Me.btnST08_2_SRCH_TANTO_SEIZO.UseVisualStyleBackColor = True
        Me.btnST08_2_SRCH_TANTO_SEIZO.Visible = False
        '
        'cmbST08_2_TANTO_SEIZO
        '
        Me.cmbST08_2_TANTO_SEIZO.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cmbST08_2_TANTO_SEIZO.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cmbST08_2_TANTO_SEIZO.BackColor = System.Drawing.SystemColors.Window
        Me.cmbST08_2_TANTO_SEIZO.Cursor = System.Windows.Forms.Cursors.Hand
        Me.cmbST08_2_TANTO_SEIZO.Font = New System.Drawing.Font("Meiryo UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.cmbST08_2_TANTO_SEIZO.ForeColor = System.Drawing.SystemColors.ControlText
        Me.cmbST08_2_TANTO_SEIZO.FormattingEnabled = True
        Me.cmbST08_2_TANTO_SEIZO.GotFocusedColor = System.Drawing.Color.FromArgb(CType(CType(190, Byte), Integer), CType(CType(180, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.cmbST08_2_TANTO_SEIZO.ImeMode = System.Windows.Forms.ImeMode.[On]
        Me.cmbST08_2_TANTO_SEIZO.Location = New System.Drawing.Point(101, 96)
        Me.cmbST08_2_TANTO_SEIZO.Name = "cmbST08_2_TANTO_SEIZO"
        Me.cmbST08_2_TANTO_SEIZO.Selected = False
        Me.cmbST08_2_TANTO_SEIZO.Size = New System.Drawing.Size(154, 25)
        Me.cmbST08_2_TANTO_SEIZO.TabIndex = 4
        Me.cmbST08_2_TANTO_SEIZO.Text = "(選択)"
        '
        'Label81
        '
        Me.Label81.AutoSize = True
        Me.Label81.Font = New System.Drawing.Font("Meiryo UI", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label81.Location = New System.Drawing.Point(264, 42)
        Me.Label81.Margin = New System.Windows.Forms.Padding(3, 3, 3, 0)
        Me.Label81.Name = "Label81"
        Me.Label81.Size = New System.Drawing.Size(72, 15)
        Me.Label81.TabIndex = 247
        Me.Label81.Text = "検査年月日:"
        Me.Label81.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'dtST08_2_KENSA_YMD
        '
        Me.dtST08_2_KENSA_YMD.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.dtST08_2_KENSA_YMD.GotFocusedColor = System.Drawing.Color.FromArgb(CType(CType(190, Byte), Integer), CType(CType(180, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.dtST08_2_KENSA_YMD.Location = New System.Drawing.Point(342, 37)
        Me.dtST08_2_KENSA_YMD.MaxDate = New Date(9998, 12, 31, 0, 0, 0, 0)
        Me.dtST08_2_KENSA_YMD.MinDate = New Date(1753, 1, 1, 0, 0, 0, 0)
        Me.dtST08_2_KENSA_YMD.MinimumSize = New System.Drawing.Size(98, 24)
        Me.dtST08_2_KENSA_YMD.Name = "dtST08_2_KENSA_YMD"
        Me.dtST08_2_KENSA_YMD.Size = New System.Drawing.Size(98, 24)
        Me.dtST08_2_KENSA_YMD.TabIndex = 2
        Me.dtST08_2_KENSA_YMD.Value = ""
        Me.dtST08_2_KENSA_YMD.ValueNonFormat = ""
        '
        'cmbST08_2_KENSA_KEKKA
        '
        Me.cmbST08_2_KENSA_KEKKA.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cmbST08_2_KENSA_KEKKA.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cmbST08_2_KENSA_KEKKA.BackColor = System.Drawing.SystemColors.Window
        Me.cmbST08_2_KENSA_KEKKA.Cursor = System.Windows.Forms.Cursors.Hand
        Me.cmbST08_2_KENSA_KEKKA.Font = New System.Drawing.Font("Meiryo UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.cmbST08_2_KENSA_KEKKA.ForeColor = System.Drawing.SystemColors.ControlText
        Me.cmbST08_2_KENSA_KEKKA.FormattingEnabled = True
        Me.cmbST08_2_KENSA_KEKKA.GotFocusedColor = System.Drawing.Color.FromArgb(CType(CType(190, Byte), Integer), CType(CType(180, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.cmbST08_2_KENSA_KEKKA.ImeMode = System.Windows.Forms.ImeMode.[On]
        Me.cmbST08_2_KENSA_KEKKA.Location = New System.Drawing.Point(101, 66)
        Me.cmbST08_2_KENSA_KEKKA.Name = "cmbST08_2_KENSA_KEKKA"
        Me.cmbST08_2_KENSA_KEKKA.Selected = False
        Me.cmbST08_2_KENSA_KEKKA.Size = New System.Drawing.Size(154, 25)
        Me.cmbST08_2_KENSA_KEKKA.TabIndex = 3
        Me.cmbST08_2_KENSA_KEKKA.Text = "(選択)"
        '
        'Label80
        '
        Me.Label80.AutoSize = True
        Me.Label80.Font = New System.Drawing.Font("Meiryo UI", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label80.Location = New System.Drawing.Point(35, 71)
        Me.Label80.Margin = New System.Windows.Forms.Padding(3, 3, 3, 0)
        Me.Label80.Name = "Label80"
        Me.Label80.Size = New System.Drawing.Size(60, 15)
        Me.Label80.TabIndex = 244
        Me.Label80.Text = "検査結果:"
        Me.Label80.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'mtxST08_2_DOC_NO
        '
        Me.mtxST08_2_DOC_NO.BackColor = System.Drawing.SystemColors.Window
        Me.mtxST08_2_DOC_NO.GotFocusedColor = System.Drawing.Color.FromArgb(CType(CType(190, Byte), Integer), CType(CType(180, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.mtxST08_2_DOC_NO.ImeMode = System.Windows.Forms.ImeMode.Disable
        Me.mtxST08_2_DOC_NO.InputRequired = False
        Me.mtxST08_2_DOC_NO.Location = New System.Drawing.Point(101, 6)
        Me.mtxST08_2_DOC_NO.Name = "mtxST08_2_DOC_NO"
        Me.mtxST08_2_DOC_NO.Size = New System.Drawing.Size(115, 24)
        Me.mtxST08_2_DOC_NO.TabIndex = 0
        Me.mtxST08_2_DOC_NO.WatermarkColor = System.Drawing.Color.Empty
        Me.mtxST08_2_DOC_NO.WatermarkText = Nothing
        '
        'btnST08_2_SRCH_TANTO_KENSA
        '
        Me.btnST08_2_SRCH_TANTO_KENSA.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnST08_2_SRCH_TANTO_KENSA.Font = New System.Drawing.Font("Meiryo UI", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.btnST08_2_SRCH_TANTO_KENSA.Location = New System.Drawing.Point(1066, 97)
        Me.btnST08_2_SRCH_TANTO_KENSA.Name = "btnST08_2_SRCH_TANTO_KENSA"
        Me.btnST08_2_SRCH_TANTO_KENSA.Size = New System.Drawing.Size(54, 24)
        Me.btnST08_2_SRCH_TANTO_KENSA.TabIndex = 9
        Me.btnST08_2_SRCH_TANTO_KENSA.Text = "検索"
        Me.btnST08_2_SRCH_TANTO_KENSA.UseVisualStyleBackColor = True
        Me.btnST08_2_SRCH_TANTO_KENSA.Visible = False
        '
        'cmbST08_2_TANTO_KENSA
        '
        Me.cmbST08_2_TANTO_KENSA.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cmbST08_2_TANTO_KENSA.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cmbST08_2_TANTO_KENSA.BackColor = System.Drawing.SystemColors.Window
        Me.cmbST08_2_TANTO_KENSA.Cursor = System.Windows.Forms.Cursors.Hand
        Me.cmbST08_2_TANTO_KENSA.Font = New System.Drawing.Font("Meiryo UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.cmbST08_2_TANTO_KENSA.ForeColor = System.Drawing.SystemColors.ControlText
        Me.cmbST08_2_TANTO_KENSA.FormattingEnabled = True
        Me.cmbST08_2_TANTO_KENSA.GotFocusedColor = System.Drawing.Color.FromArgb(CType(CType(190, Byte), Integer), CType(CType(180, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.cmbST08_2_TANTO_KENSA.ImeMode = System.Windows.Forms.ImeMode.[On]
        Me.cmbST08_2_TANTO_KENSA.Location = New System.Drawing.Point(906, 96)
        Me.cmbST08_2_TANTO_KENSA.Name = "cmbST08_2_TANTO_KENSA"
        Me.cmbST08_2_TANTO_KENSA.Selected = False
        Me.cmbST08_2_TANTO_KENSA.Size = New System.Drawing.Size(154, 25)
        Me.cmbST08_2_TANTO_KENSA.TabIndex = 8
        Me.cmbST08_2_TANTO_KENSA.Text = "(選択)"
        '
        'Label75
        '
        Me.Label75.AutoSize = True
        Me.Label75.Font = New System.Drawing.Font("Meiryo UI", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label75.Location = New System.Drawing.Point(840, 101)
        Me.Label75.Margin = New System.Windows.Forms.Padding(3, 3, 3, 0)
        Me.Label75.Name = "Label75"
        Me.Label75.Size = New System.Drawing.Size(60, 15)
        Me.Label75.TabIndex = 239
        Me.Label75.Text = "検査担当:"
        Me.Label75.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label76
        '
        Me.Label76.AutoSize = True
        Me.Label76.Font = New System.Drawing.Font("Meiryo UI", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label76.Location = New System.Drawing.Point(35, 101)
        Me.Label76.Margin = New System.Windows.Forms.Padding(3, 3, 3, 0)
        Me.Label76.Name = "Label76"
        Me.Label76.Size = New System.Drawing.Size(60, 15)
        Me.Label76.TabIndex = 237
        Me.Label76.Text = "製造担当:"
        Me.Label76.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label78
        '
        Me.Label78.AutoSize = True
        Me.Label78.Font = New System.Drawing.Font("Meiryo UI", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label78.Location = New System.Drawing.Point(23, 42)
        Me.Label78.Margin = New System.Windows.Forms.Padding(3, 3, 3, 0)
        Me.Label78.Name = "Label78"
        Me.Label78.Size = New System.Drawing.Size(72, 15)
        Me.Label78.TabIndex = 235
        Me.Label78.Text = "作業完了日:"
        Me.Label78.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label79
        '
        Me.Label79.AutoSize = True
        Me.Label79.Font = New System.Drawing.Font("Meiryo UI", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label79.Location = New System.Drawing.Point(41, 11)
        Me.Label79.Name = "Label79"
        Me.Label79.Size = New System.Drawing.Size(54, 15)
        Me.Label79.TabIndex = 234
        Me.Label79.Text = "文書No:"
        Me.Label79.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'dtST08_2_WorkOutYMD
        '
        Me.dtST08_2_WorkOutYMD.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.dtST08_2_WorkOutYMD.GotFocusedColor = System.Drawing.Color.FromArgb(CType(CType(190, Byte), Integer), CType(CType(180, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.dtST08_2_WorkOutYMD.Location = New System.Drawing.Point(101, 36)
        Me.dtST08_2_WorkOutYMD.MaxDate = New Date(9998, 12, 31, 0, 0, 0, 0)
        Me.dtST08_2_WorkOutYMD.MinDate = New Date(1753, 1, 1, 0, 0, 0, 0)
        Me.dtST08_2_WorkOutYMD.MinimumSize = New System.Drawing.Size(98, 24)
        Me.dtST08_2_WorkOutYMD.Name = "dtST08_2_WorkOutYMD"
        Me.dtST08_2_WorkOutYMD.Size = New System.Drawing.Size(98, 24)
        Me.dtST08_2_WorkOutYMD.TabIndex = 1
        Me.dtST08_2_WorkOutYMD.Value = ""
        Me.dtST08_2_WorkOutYMD.ValueNonFormat = ""
        '
        'tabSTAGE08_3
        '
        Me.tabSTAGE08_3.Controls.Add(Me.Label83)
        Me.tabSTAGE08_3.Controls.Add(Me.txtST08_3_BIKO)
        Me.tabSTAGE08_3.Controls.Add(Me.btnST08_3_SRCH_TANTO_HENKYAKU)
        Me.tabSTAGE08_3.Controls.Add(Me.cmbST08_3_HENKYAKU_TANTO)
        Me.tabSTAGE08_3.Controls.Add(Me.mtxST08_3_HENKYAKU_SAKI)
        Me.tabSTAGE08_3.Controls.Add(Me.Label87)
        Me.tabSTAGE08_3.Controls.Add(Me.Label88)
        Me.tabSTAGE08_3.Controls.Add(Me.Label89)
        Me.tabSTAGE08_3.Controls.Add(Me.dtST08_3_HENKYAKU_YMD)
        Me.tabSTAGE08_3.Location = New System.Drawing.Point(4, 26)
        Me.tabSTAGE08_3.Name = "tabSTAGE08_3"
        Me.tabSTAGE08_3.Size = New System.Drawing.Size(1198, 152)
        Me.tabSTAGE08_3.TabIndex = 2
        Me.tabSTAGE08_3.Text = "返却実施記録"
        Me.tabSTAGE08_3.UseVisualStyleBackColor = True
        '
        'Label83
        '
        Me.Label83.AutoSize = True
        Me.Label83.Font = New System.Drawing.Font("Meiryo UI", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label83.Location = New System.Drawing.Point(59, 41)
        Me.Label83.Margin = New System.Windows.Forms.Padding(3, 3, 3, 0)
        Me.Label83.Name = "Label83"
        Me.Label83.Size = New System.Drawing.Size(36, 15)
        Me.Label83.TabIndex = 268
        Me.Label83.Text = "備考:"
        Me.Label83.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'txtST08_3_BIKO
        '
        Me.txtST08_3_BIKO.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtST08_3_BIKO.BackColor = System.Drawing.SystemColors.Window
        Me.txtST08_3_BIKO.GotFocusedColor = System.Drawing.Color.FromArgb(CType(CType(190, Byte), Integer), CType(CType(180, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.txtST08_3_BIKO.ImeMode = System.Windows.Forms.ImeMode.[On]
        Me.txtST08_3_BIKO.Location = New System.Drawing.Point(101, 36)
        Me.txtST08_3_BIKO.Multiline = True
        Me.txtST08_3_BIKO.Name = "txtST08_3_BIKO"
        Me.txtST08_3_BIKO.Size = New System.Drawing.Size(1090, 113)
        Me.txtST08_3_BIKO.TabIndex = 4
        Me.txtST08_3_BIKO.WatermarkText = Nothing
        '
        'btnST08_3_SRCH_TANTO_HENKYAKU
        '
        Me.btnST08_3_SRCH_TANTO_HENKYAKU.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnST08_3_SRCH_TANTO_HENKYAKU.Font = New System.Drawing.Font("Meiryo UI", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.btnST08_3_SRCH_TANTO_HENKYAKU.Location = New System.Drawing.Point(882, 7)
        Me.btnST08_3_SRCH_TANTO_HENKYAKU.Name = "btnST08_3_SRCH_TANTO_HENKYAKU"
        Me.btnST08_3_SRCH_TANTO_HENKYAKU.Size = New System.Drawing.Size(54, 24)
        Me.btnST08_3_SRCH_TANTO_HENKYAKU.TabIndex = 3
        Me.btnST08_3_SRCH_TANTO_HENKYAKU.Text = "検索"
        Me.btnST08_3_SRCH_TANTO_HENKYAKU.UseVisualStyleBackColor = True
        Me.btnST08_3_SRCH_TANTO_HENKYAKU.Visible = False
        '
        'cmbST08_3_HENKYAKU_TANTO
        '
        Me.cmbST08_3_HENKYAKU_TANTO.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cmbST08_3_HENKYAKU_TANTO.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cmbST08_3_HENKYAKU_TANTO.BackColor = System.Drawing.SystemColors.Window
        Me.cmbST08_3_HENKYAKU_TANTO.Cursor = System.Windows.Forms.Cursors.Default
        Me.cmbST08_3_HENKYAKU_TANTO.Font = New System.Drawing.Font("Meiryo UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.cmbST08_3_HENKYAKU_TANTO.ForeColor = System.Drawing.SystemColors.ControlText
        Me.cmbST08_3_HENKYAKU_TANTO.FormattingEnabled = True
        Me.cmbST08_3_HENKYAKU_TANTO.GotFocusedColor = System.Drawing.Color.FromArgb(CType(CType(190, Byte), Integer), CType(CType(180, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.cmbST08_3_HENKYAKU_TANTO.ImeMode = System.Windows.Forms.ImeMode.[On]
        Me.cmbST08_3_HENKYAKU_TANTO.Location = New System.Drawing.Point(722, 6)
        Me.cmbST08_3_HENKYAKU_TANTO.Name = "cmbST08_3_HENKYAKU_TANTO"
        Me.cmbST08_3_HENKYAKU_TANTO.Selected = False
        Me.cmbST08_3_HENKYAKU_TANTO.Size = New System.Drawing.Size(154, 25)
        Me.cmbST08_3_HENKYAKU_TANTO.TabIndex = 2
        Me.cmbST08_3_HENKYAKU_TANTO.Text = "(選択)"
        '
        'mtxST08_3_HENKYAKU_SAKI
        '
        Me.mtxST08_3_HENKYAKU_SAKI.BackColor = System.Drawing.SystemColors.Window
        Me.mtxST08_3_HENKYAKU_SAKI.GotFocusedColor = System.Drawing.Color.FromArgb(CType(CType(190, Byte), Integer), CType(CType(180, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.mtxST08_3_HENKYAKU_SAKI.ImeMode = System.Windows.Forms.ImeMode.[On]
        Me.mtxST08_3_HENKYAKU_SAKI.InputRequired = False
        Me.mtxST08_3_HENKYAKU_SAKI.Location = New System.Drawing.Point(342, 6)
        Me.mtxST08_3_HENKYAKU_SAKI.Name = "mtxST08_3_HENKYAKU_SAKI"
        Me.mtxST08_3_HENKYAKU_SAKI.Size = New System.Drawing.Size(154, 24)
        Me.mtxST08_3_HENKYAKU_SAKI.TabIndex = 1
        Me.mtxST08_3_HENKYAKU_SAKI.WatermarkColor = System.Drawing.Color.Empty
        Me.mtxST08_3_HENKYAKU_SAKI.WatermarkText = Nothing
        '
        'Label87
        '
        Me.Label87.AutoSize = True
        Me.Label87.Font = New System.Drawing.Font("Meiryo UI", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label87.Location = New System.Drawing.Point(668, 11)
        Me.Label87.Margin = New System.Windows.Forms.Padding(3, 3, 3, 0)
        Me.Label87.Name = "Label87"
        Me.Label87.Size = New System.Drawing.Size(48, 15)
        Me.Label87.TabIndex = 256
        Me.Label87.Text = "実施者:"
        Me.Label87.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label88
        '
        Me.Label88.AutoSize = True
        Me.Label88.Font = New System.Drawing.Font("Meiryo UI", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label88.Location = New System.Drawing.Point(288, 11)
        Me.Label88.Margin = New System.Windows.Forms.Padding(3, 3, 3, 0)
        Me.Label88.Name = "Label88"
        Me.Label88.Size = New System.Drawing.Size(48, 15)
        Me.Label88.TabIndex = 255
        Me.Label88.Text = "返却先:"
        Me.Label88.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label89
        '
        Me.Label89.AutoSize = True
        Me.Label89.Font = New System.Drawing.Font("Meiryo UI", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label89.Location = New System.Drawing.Point(23, 11)
        Me.Label89.Name = "Label89"
        Me.Label89.Size = New System.Drawing.Size(72, 15)
        Me.Label89.TabIndex = 254
        Me.Label89.Text = "返却年月日:"
        Me.Label89.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'dtST08_3_HENKYAKU_YMD
        '
        Me.dtST08_3_HENKYAKU_YMD.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.dtST08_3_HENKYAKU_YMD.GotFocusedColor = System.Drawing.Color.FromArgb(CType(CType(190, Byte), Integer), CType(CType(180, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.dtST08_3_HENKYAKU_YMD.Location = New System.Drawing.Point(101, 6)
        Me.dtST08_3_HENKYAKU_YMD.MaxDate = New Date(9998, 12, 31, 0, 0, 0, 0)
        Me.dtST08_3_HENKYAKU_YMD.MinDate = New Date(1753, 1, 1, 0, 0, 0, 0)
        Me.dtST08_3_HENKYAKU_YMD.MinimumSize = New System.Drawing.Size(98, 24)
        Me.dtST08_3_HENKYAKU_YMD.Name = "dtST08_3_HENKYAKU_YMD"
        Me.dtST08_3_HENKYAKU_YMD.Size = New System.Drawing.Size(98, 24)
        Me.dtST08_3_HENKYAKU_YMD.TabIndex = 0
        Me.dtST08_3_HENKYAKU_YMD.Value = ""
        Me.dtST08_3_HENKYAKU_YMD.ValueNonFormat = ""
        '
        'tabSTAGE08_4
        '
        Me.tabSTAGE08_4.Controls.Add(Me.cmbST08_4_BUHIN_BANGO)
        Me.tabSTAGE08_4.Controls.Add(Me.cmbST08_4_KISYU)
        Me.tabSTAGE08_4.Controls.Add(Me.mtxST08_4_GOUKI)
        Me.tabSTAGE08_4.Controls.Add(Me.dtST08_4_TENYO_YMD)
        Me.tabSTAGE08_4.Controls.Add(Me.Label91)
        Me.tabSTAGE08_4.Controls.Add(Me.Label84)
        Me.tabSTAGE08_4.Controls.Add(Me.mtxST08_4_LOT)
        Me.tabSTAGE08_4.Controls.Add(Me.Label85)
        Me.tabSTAGE08_4.Controls.Add(Me.Label86)
        Me.tabSTAGE08_4.Controls.Add(Me.Label90)
        Me.tabSTAGE08_4.Location = New System.Drawing.Point(4, 26)
        Me.tabSTAGE08_4.Name = "tabSTAGE08_4"
        Me.tabSTAGE08_4.Size = New System.Drawing.Size(1198, 152)
        Me.tabSTAGE08_4.TabIndex = 3
        Me.tabSTAGE08_4.Text = "転用先記録"
        Me.tabSTAGE08_4.UseVisualStyleBackColor = True
        '
        'cmbST08_4_BUHIN_BANGO
        '
        Me.cmbST08_4_BUHIN_BANGO.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cmbST08_4_BUHIN_BANGO.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cmbST08_4_BUHIN_BANGO.BackColor = System.Drawing.SystemColors.Window
        Me.cmbST08_4_BUHIN_BANGO.Cursor = System.Windows.Forms.Cursors.Hand
        Me.cmbST08_4_BUHIN_BANGO.Font = New System.Drawing.Font("Meiryo UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.cmbST08_4_BUHIN_BANGO.ForeColor = System.Drawing.SystemColors.ControlText
        Me.cmbST08_4_BUHIN_BANGO.FormattingEnabled = True
        Me.cmbST08_4_BUHIN_BANGO.GotFocusedColor = System.Drawing.Color.FromArgb(CType(CType(190, Byte), Integer), CType(CType(180, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.cmbST08_4_BUHIN_BANGO.ImeMode = System.Windows.Forms.ImeMode.[On]
        Me.cmbST08_4_BUHIN_BANGO.Location = New System.Drawing.Point(101, 36)
        Me.cmbST08_4_BUHIN_BANGO.Name = "cmbST08_4_BUHIN_BANGO"
        Me.cmbST08_4_BUHIN_BANGO.Selected = False
        Me.cmbST08_4_BUHIN_BANGO.Size = New System.Drawing.Size(154, 25)
        Me.cmbST08_4_BUHIN_BANGO.TabIndex = 1
        Me.cmbST08_4_BUHIN_BANGO.Text = "(選択)"
        '
        'cmbST08_4_KISYU
        '
        Me.cmbST08_4_KISYU.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cmbST08_4_KISYU.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cmbST08_4_KISYU.BackColor = System.Drawing.SystemColors.Window
        Me.cmbST08_4_KISYU.Cursor = System.Windows.Forms.Cursors.Hand
        Me.cmbST08_4_KISYU.Font = New System.Drawing.Font("Meiryo UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.cmbST08_4_KISYU.ForeColor = System.Drawing.SystemColors.ControlText
        Me.cmbST08_4_KISYU.FormattingEnabled = True
        Me.cmbST08_4_KISYU.GotFocusedColor = System.Drawing.Color.FromArgb(CType(CType(190, Byte), Integer), CType(CType(180, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.cmbST08_4_KISYU.ImeMode = System.Windows.Forms.ImeMode.[On]
        Me.cmbST08_4_KISYU.Location = New System.Drawing.Point(101, 5)
        Me.cmbST08_4_KISYU.Name = "cmbST08_4_KISYU"
        Me.cmbST08_4_KISYU.Selected = False
        Me.cmbST08_4_KISYU.Size = New System.Drawing.Size(134, 25)
        Me.cmbST08_4_KISYU.TabIndex = 0
        Me.cmbST08_4_KISYU.Text = "(選択)"
        '
        'mtxST08_4_GOUKI
        '
        Me.mtxST08_4_GOUKI.BackColor = System.Drawing.SystemColors.Window
        Me.mtxST08_4_GOUKI.GotFocusedColor = System.Drawing.Color.FromArgb(CType(CType(190, Byte), Integer), CType(CType(180, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.mtxST08_4_GOUKI.ImeMode = System.Windows.Forms.ImeMode.Disable
        Me.mtxST08_4_GOUKI.InputRequired = False
        Me.mtxST08_4_GOUKI.Location = New System.Drawing.Point(101, 66)
        Me.mtxST08_4_GOUKI.Name = "mtxST08_4_GOUKI"
        Me.mtxST08_4_GOUKI.Size = New System.Drawing.Size(134, 24)
        Me.mtxST08_4_GOUKI.TabIndex = 2
        Me.mtxST08_4_GOUKI.WatermarkColor = System.Drawing.Color.Empty
        Me.mtxST08_4_GOUKI.WatermarkText = Nothing
        '
        'dtST08_4_TENYO_YMD
        '
        Me.dtST08_4_TENYO_YMD.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.dtST08_4_TENYO_YMD.GotFocusedColor = System.Drawing.Color.FromArgb(CType(CType(190, Byte), Integer), CType(CType(180, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.dtST08_4_TENYO_YMD.Location = New System.Drawing.Point(101, 125)
        Me.dtST08_4_TENYO_YMD.MaxDate = New Date(9998, 12, 31, 0, 0, 0, 0)
        Me.dtST08_4_TENYO_YMD.MinDate = New Date(1753, 1, 1, 0, 0, 0, 0)
        Me.dtST08_4_TENYO_YMD.MinimumSize = New System.Drawing.Size(98, 24)
        Me.dtST08_4_TENYO_YMD.Name = "dtST08_4_TENYO_YMD"
        Me.dtST08_4_TENYO_YMD.Size = New System.Drawing.Size(98, 24)
        Me.dtST08_4_TENYO_YMD.TabIndex = 4
        Me.dtST08_4_TENYO_YMD.Value = ""
        Me.dtST08_4_TENYO_YMD.ValueNonFormat = ""
        '
        'Label91
        '
        Me.Label91.AutoSize = True
        Me.Label91.Font = New System.Drawing.Font("Meiryo UI", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label91.Location = New System.Drawing.Point(23, 128)
        Me.Label91.Margin = New System.Windows.Forms.Padding(3, 3, 3, 0)
        Me.Label91.Name = "Label91"
        Me.Label91.Size = New System.Drawing.Size(72, 15)
        Me.Label91.TabIndex = 243
        Me.Label91.Text = "転用年月日:"
        Me.Label91.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label84
        '
        Me.Label84.AutoSize = True
        Me.Label84.Font = New System.Drawing.Font("Meiryo UI", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label84.Location = New System.Drawing.Point(59, 101)
        Me.Label84.Margin = New System.Windows.Forms.Padding(3, 3, 3, 0)
        Me.Label84.Name = "Label84"
        Me.Label84.Size = New System.Drawing.Size(36, 15)
        Me.Label84.TabIndex = 239
        Me.Label84.Text = "LOT:"
        Me.Label84.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'mtxST08_4_LOT
        '
        Me.mtxST08_4_LOT.BackColor = System.Drawing.SystemColors.Window
        Me.mtxST08_4_LOT.GotFocusedColor = System.Drawing.Color.FromArgb(CType(CType(190, Byte), Integer), CType(CType(180, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.mtxST08_4_LOT.ImeMode = System.Windows.Forms.ImeMode.Disable
        Me.mtxST08_4_LOT.InputRequired = False
        Me.mtxST08_4_LOT.Location = New System.Drawing.Point(101, 96)
        Me.mtxST08_4_LOT.Name = "mtxST08_4_LOT"
        Me.mtxST08_4_LOT.Size = New System.Drawing.Size(54, 24)
        Me.mtxST08_4_LOT.TabIndex = 3
        Me.mtxST08_4_LOT.WatermarkColor = System.Drawing.Color.Empty
        Me.mtxST08_4_LOT.WatermarkText = Nothing
        '
        'Label85
        '
        Me.Label85.AutoSize = True
        Me.Label85.Font = New System.Drawing.Font("Meiryo UI", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label85.Location = New System.Drawing.Point(59, 71)
        Me.Label85.Margin = New System.Windows.Forms.Padding(3, 3, 3, 0)
        Me.Label85.Name = "Label85"
        Me.Label85.Size = New System.Drawing.Size(36, 15)
        Me.Label85.TabIndex = 237
        Me.Label85.Text = "号機:"
        Me.Label85.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label86
        '
        Me.Label86.AutoSize = True
        Me.Label86.Font = New System.Drawing.Font("Meiryo UI", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label86.Location = New System.Drawing.Point(35, 41)
        Me.Label86.Margin = New System.Windows.Forms.Padding(3, 3, 3, 0)
        Me.Label86.Name = "Label86"
        Me.Label86.Size = New System.Drawing.Size(60, 15)
        Me.Label86.TabIndex = 235
        Me.Label86.Text = "部品番号:"
        Me.Label86.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label90
        '
        Me.Label90.AutoSize = True
        Me.Label90.Font = New System.Drawing.Font("Meiryo UI", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label90.Location = New System.Drawing.Point(59, 11)
        Me.Label90.Name = "Label90"
        Me.Label90.Size = New System.Drawing.Size(36, 15)
        Me.Label90.TabIndex = 234
        Me.Label90.Text = "機種:"
        Me.Label90.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'lblSTAGE08
        '
        Me.lblSTAGE08.AutoSize = True
        Me.lblSTAGE08.BackColor = System.Drawing.Color.Wheat
        Me.lblSTAGE08.Font = New System.Drawing.Font("Meiryo UI", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.lblSTAGE08.Location = New System.Drawing.Point(6, 6)
        Me.lblSTAGE08.Margin = New System.Windows.Forms.Padding(3, 3, 3, 0)
        Me.lblSTAGE08.Name = "lblSTAGE08"
        Me.lblSTAGE08.Size = New System.Drawing.Size(86, 24)
        Me.lblSTAGE08.TabIndex = 189
        Me.lblSTAGE08.Text = "処置実施"
        Me.lblSTAGE08.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'tabSTAGE09
        '
        Me.tabSTAGE09.Controls.Add(Me.lblST09_Modoshi_Riyu)
        Me.tabSTAGE09.Controls.Add(Me.cmbST09_DestTANTO)
        Me.tabSTAGE09.Controls.Add(Me.mtxST09_NextStageName)
        Me.tabSTAGE09.Controls.Add(Me.Label92)
        Me.tabSTAGE09.Controls.Add(Me.Label93)
        Me.tabSTAGE09.Controls.Add(Me.Label94)
        Me.tabSTAGE09.Controls.Add(Me.txtST09_Comment)
        Me.tabSTAGE09.Controls.Add(Me.Label95)
        Me.tabSTAGE09.Controls.Add(Me.mtxST09_UPD_YMD)
        Me.tabSTAGE09.Controls.Add(Me.lblSTAGE09)
        Me.tabSTAGE09.Location = New System.Drawing.Point(4, 26)
        Me.tabSTAGE09.Name = "tabSTAGE09"
        Me.tabSTAGE09.Size = New System.Drawing.Size(1229, 312)
        Me.tabSTAGE09.TabIndex = 8
        Me.tabSTAGE09.Text = "STAGE09"
        Me.tabSTAGE09.UseVisualStyleBackColor = True
        '
        'lblST09_Modoshi_Riyu
        '
        Me.lblST09_Modoshi_Riyu.Font = New System.Drawing.Font("Meiryo UI", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.lblST09_Modoshi_Riyu.Location = New System.Drawing.Point(259, 6)
        Me.lblST09_Modoshi_Riyu.Name = "lblST09_Modoshi_Riyu"
        Me.lblST09_Modoshi_Riyu.Size = New System.Drawing.Size(556, 24)
        Me.lblST09_Modoshi_Riyu.TabIndex = 235
        Me.lblST09_Modoshi_Riyu.Text = "差戻理由：__________________________________________________________"
        Me.lblST09_Modoshi_Riyu.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.lblST09_Modoshi_Riyu.Visible = False
        '
        'cmbST09_DestTANTO
        '
        Me.cmbST09_DestTANTO.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cmbST09_DestTANTO.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cmbST09_DestTANTO.BackColor = System.Drawing.SystemColors.Window
        Me.cmbST09_DestTANTO.Cursor = System.Windows.Forms.Cursors.Hand
        Me.cmbST09_DestTANTO.Font = New System.Drawing.Font("Meiryo UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.cmbST09_DestTANTO.ForeColor = System.Drawing.SystemColors.ControlText
        Me.cmbST09_DestTANTO.FormattingEnabled = True
        Me.cmbST09_DestTANTO.GotFocusedColor = System.Drawing.Color.FromArgb(CType(CType(190, Byte), Integer), CType(CType(180, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.cmbST09_DestTANTO.ImeMode = System.Windows.Forms.ImeMode.[On]
        Me.cmbST09_DestTANTO.Location = New System.Drawing.Point(739, 40)
        Me.cmbST09_DestTANTO.Name = "cmbST09_DestTANTO"
        Me.cmbST09_DestTANTO.Selected = False
        Me.cmbST09_DestTANTO.Size = New System.Drawing.Size(154, 25)
        Me.cmbST09_DestTANTO.TabIndex = 2
        Me.cmbST09_DestTANTO.Text = "(選択)"
        '
        'mtxST09_NextStageName
        '
        Me.mtxST09_NextStageName.BackColor = System.Drawing.SystemColors.Window
        Me.mtxST09_NextStageName.Enabled = False
        Me.mtxST09_NextStageName.GotFocusedColor = System.Drawing.Color.FromArgb(CType(CType(190, Byte), Integer), CType(CType(180, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.mtxST09_NextStageName.ImeMode = System.Windows.Forms.ImeMode.Disable
        Me.mtxST09_NextStageName.InputRequired = False
        Me.mtxST09_NextStageName.Location = New System.Drawing.Point(359, 40)
        Me.mtxST09_NextStageName.Name = "mtxST09_NextStageName"
        Me.mtxST09_NextStageName.Size = New System.Drawing.Size(296, 24)
        Me.mtxST09_NextStageName.TabIndex = 1
        Me.mtxST09_NextStageName.WatermarkColor = System.Drawing.Color.Empty
        Me.mtxST09_NextStageName.WatermarkText = Nothing
        '
        'Label92
        '
        Me.Label92.AutoSize = True
        Me.Label92.Font = New System.Drawing.Font("Meiryo UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label92.Location = New System.Drawing.Point(255, 45)
        Me.Label92.Margin = New System.Windows.Forms.Padding(3, 3, 3, 0)
        Me.Label92.Name = "Label92"
        Me.Label92.Size = New System.Drawing.Size(98, 15)
        Me.Label92.TabIndex = 232
        Me.Label92.Text = "承認先ステージ名:"
        Me.Label92.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label93
        '
        Me.Label93.AutoSize = True
        Me.Label93.Font = New System.Drawing.Font("Meiryo UI", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label93.Location = New System.Drawing.Point(661, 45)
        Me.Label93.Margin = New System.Windows.Forms.Padding(3, 3, 3, 0)
        Me.Label93.Name = "Label93"
        Me.Label93.Size = New System.Drawing.Size(72, 15)
        Me.Label93.TabIndex = 231
        Me.Label93.Text = "申請先社員:"
        Me.Label93.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label94
        '
        Me.Label94.AutoSize = True
        Me.Label94.Font = New System.Drawing.Font("Meiryo UI", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label94.Location = New System.Drawing.Point(63, 75)
        Me.Label94.Margin = New System.Windows.Forms.Padding(3, 3, 3, 0)
        Me.Label94.Name = "Label94"
        Me.Label94.Size = New System.Drawing.Size(49, 15)
        Me.Label94.TabIndex = 230
        Me.Label94.Text = "コメント:"
        Me.Label94.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'txtST09_Comment
        '
        Me.txtST09_Comment.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtST09_Comment.BackColor = System.Drawing.SystemColors.Window
        Me.txtST09_Comment.GotFocusedColor = System.Drawing.Color.FromArgb(CType(CType(190, Byte), Integer), CType(CType(180, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.txtST09_Comment.ImeMode = System.Windows.Forms.ImeMode.[On]
        Me.txtST09_Comment.Location = New System.Drawing.Point(118, 70)
        Me.txtST09_Comment.Multiline = True
        Me.txtST09_Comment.Name = "txtST09_Comment"
        Me.txtST09_Comment.Size = New System.Drawing.Size(1101, 58)
        Me.txtST09_Comment.TabIndex = 3
        Me.txtST09_Comment.WatermarkText = Nothing
        '
        'Label95
        '
        Me.Label95.AutoSize = True
        Me.Label95.Font = New System.Drawing.Font("Meiryo UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label95.Location = New System.Drawing.Point(10, 45)
        Me.Label95.Margin = New System.Windows.Forms.Padding(3, 3, 3, 0)
        Me.Label95.Name = "Label95"
        Me.Label95.Size = New System.Drawing.Size(102, 15)
        Me.Label95.TabIndex = 228
        Me.Label95.Text = "承認・申請年月日:"
        Me.Label95.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'mtxST09_UPD_YMD
        '
        Me.mtxST09_UPD_YMD.BackColor = System.Drawing.SystemColors.Window
        Me.mtxST09_UPD_YMD.Enabled = False
        Me.mtxST09_UPD_YMD.GotFocusedColor = System.Drawing.Color.FromArgb(CType(CType(190, Byte), Integer), CType(CType(180, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.mtxST09_UPD_YMD.ImeMode = System.Windows.Forms.ImeMode.Disable
        Me.mtxST09_UPD_YMD.InputRequired = False
        Me.mtxST09_UPD_YMD.Location = New System.Drawing.Point(118, 40)
        Me.mtxST09_UPD_YMD.Name = "mtxST09_UPD_YMD"
        Me.mtxST09_UPD_YMD.Size = New System.Drawing.Size(115, 24)
        Me.mtxST09_UPD_YMD.TabIndex = 0
        Me.mtxST09_UPD_YMD.WatermarkColor = System.Drawing.Color.Empty
        Me.mtxST09_UPD_YMD.WatermarkText = Nothing
        '
        'lblSTAGE09
        '
        Me.lblSTAGE09.AutoSize = True
        Me.lblSTAGE09.BackColor = System.Drawing.Color.Wheat
        Me.lblSTAGE09.Font = New System.Drawing.Font("Meiryo UI", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.lblSTAGE09.Location = New System.Drawing.Point(6, 6)
        Me.lblSTAGE09.Margin = New System.Windows.Forms.Padding(3, 3, 3, 0)
        Me.lblSTAGE09.Name = "lblSTAGE09"
        Me.lblSTAGE09.Size = New System.Drawing.Size(124, 24)
        Me.lblSTAGE09.TabIndex = 226
        Me.lblSTAGE09.Text = "処置実施確認"
        Me.lblSTAGE09.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'tabSTAGE10
        '
        Me.tabSTAGE10.Controls.Add(Me.lblST10_Modoshi_Riyu)
        Me.tabSTAGE10.Controls.Add(Me.cmbST10_DestTANTO)
        Me.tabSTAGE10.Controls.Add(Me.mtxST10_NextStageName)
        Me.tabSTAGE10.Controls.Add(Me.Label97)
        Me.tabSTAGE10.Controls.Add(Me.Label98)
        Me.tabSTAGE10.Controls.Add(Me.Label99)
        Me.tabSTAGE10.Controls.Add(Me.txtST10_Comment)
        Me.tabSTAGE10.Controls.Add(Me.Label100)
        Me.tabSTAGE10.Controls.Add(Me.mtxST10_UPD_YMD)
        Me.tabSTAGE10.Controls.Add(Me.lblSTAGE10)
        Me.tabSTAGE10.Location = New System.Drawing.Point(4, 26)
        Me.tabSTAGE10.Name = "tabSTAGE10"
        Me.tabSTAGE10.Size = New System.Drawing.Size(1229, 312)
        Me.tabSTAGE10.TabIndex = 9
        Me.tabSTAGE10.Text = "STAGE10"
        Me.tabSTAGE10.UseVisualStyleBackColor = True
        '
        'lblST10_Modoshi_Riyu
        '
        Me.lblST10_Modoshi_Riyu.Font = New System.Drawing.Font("Meiryo UI", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.lblST10_Modoshi_Riyu.Location = New System.Drawing.Point(259, 6)
        Me.lblST10_Modoshi_Riyu.Name = "lblST10_Modoshi_Riyu"
        Me.lblST10_Modoshi_Riyu.Size = New System.Drawing.Size(556, 24)
        Me.lblST10_Modoshi_Riyu.TabIndex = 244
        Me.lblST10_Modoshi_Riyu.Text = "差戻理由：__________________________________________________________"
        Me.lblST10_Modoshi_Riyu.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.lblST10_Modoshi_Riyu.Visible = False
        '
        'cmbST10_DestTANTO
        '
        Me.cmbST10_DestTANTO.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cmbST10_DestTANTO.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cmbST10_DestTANTO.BackColor = System.Drawing.SystemColors.Window
        Me.cmbST10_DestTANTO.Cursor = System.Windows.Forms.Cursors.Hand
        Me.cmbST10_DestTANTO.Font = New System.Drawing.Font("Meiryo UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.cmbST10_DestTANTO.ForeColor = System.Drawing.SystemColors.ControlText
        Me.cmbST10_DestTANTO.FormattingEnabled = True
        Me.cmbST10_DestTANTO.GotFocusedColor = System.Drawing.Color.FromArgb(CType(CType(190, Byte), Integer), CType(CType(180, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.cmbST10_DestTANTO.ImeMode = System.Windows.Forms.ImeMode.[On]
        Me.cmbST10_DestTANTO.Location = New System.Drawing.Point(739, 40)
        Me.cmbST10_DestTANTO.Name = "cmbST10_DestTANTO"
        Me.cmbST10_DestTANTO.Selected = False
        Me.cmbST10_DestTANTO.Size = New System.Drawing.Size(154, 25)
        Me.cmbST10_DestTANTO.TabIndex = 2
        Me.cmbST10_DestTANTO.Text = "(選択)"
        '
        'mtxST10_NextStageName
        '
        Me.mtxST10_NextStageName.BackColor = System.Drawing.SystemColors.Window
        Me.mtxST10_NextStageName.Enabled = False
        Me.mtxST10_NextStageName.GotFocusedColor = System.Drawing.Color.FromArgb(CType(CType(190, Byte), Integer), CType(CType(180, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.mtxST10_NextStageName.ImeMode = System.Windows.Forms.ImeMode.Disable
        Me.mtxST10_NextStageName.InputRequired = False
        Me.mtxST10_NextStageName.Location = New System.Drawing.Point(359, 40)
        Me.mtxST10_NextStageName.Name = "mtxST10_NextStageName"
        Me.mtxST10_NextStageName.Size = New System.Drawing.Size(296, 24)
        Me.mtxST10_NextStageName.TabIndex = 1
        Me.mtxST10_NextStageName.WatermarkColor = System.Drawing.Color.Empty
        Me.mtxST10_NextStageName.WatermarkText = Nothing
        '
        'Label97
        '
        Me.Label97.AutoSize = True
        Me.Label97.Font = New System.Drawing.Font("Meiryo UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label97.Location = New System.Drawing.Point(255, 45)
        Me.Label97.Margin = New System.Windows.Forms.Padding(3, 3, 3, 0)
        Me.Label97.Name = "Label97"
        Me.Label97.Size = New System.Drawing.Size(98, 15)
        Me.Label97.TabIndex = 241
        Me.Label97.Text = "承認先ステージ名:"
        Me.Label97.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label98
        '
        Me.Label98.AutoSize = True
        Me.Label98.Font = New System.Drawing.Font("Meiryo UI", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label98.Location = New System.Drawing.Point(661, 45)
        Me.Label98.Margin = New System.Windows.Forms.Padding(3, 3, 3, 0)
        Me.Label98.Name = "Label98"
        Me.Label98.Size = New System.Drawing.Size(72, 15)
        Me.Label98.TabIndex = 240
        Me.Label98.Text = "申請先社員:"
        Me.Label98.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label99
        '
        Me.Label99.AutoSize = True
        Me.Label99.Font = New System.Drawing.Font("Meiryo UI", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label99.Location = New System.Drawing.Point(63, 75)
        Me.Label99.Margin = New System.Windows.Forms.Padding(3, 3, 3, 0)
        Me.Label99.Name = "Label99"
        Me.Label99.Size = New System.Drawing.Size(49, 15)
        Me.Label99.TabIndex = 239
        Me.Label99.Text = "コメント:"
        Me.Label99.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'txtST10_Comment
        '
        Me.txtST10_Comment.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtST10_Comment.BackColor = System.Drawing.SystemColors.Window
        Me.txtST10_Comment.GotFocusedColor = System.Drawing.Color.FromArgb(CType(CType(190, Byte), Integer), CType(CType(180, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.txtST10_Comment.ImeMode = System.Windows.Forms.ImeMode.[On]
        Me.txtST10_Comment.Location = New System.Drawing.Point(118, 70)
        Me.txtST10_Comment.Multiline = True
        Me.txtST10_Comment.Name = "txtST10_Comment"
        Me.txtST10_Comment.Size = New System.Drawing.Size(1101, 58)
        Me.txtST10_Comment.TabIndex = 3
        Me.txtST10_Comment.WatermarkText = Nothing
        '
        'Label100
        '
        Me.Label100.AutoSize = True
        Me.Label100.Font = New System.Drawing.Font("Meiryo UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label100.Location = New System.Drawing.Point(10, 45)
        Me.Label100.Margin = New System.Windows.Forms.Padding(3, 3, 3, 0)
        Me.Label100.Name = "Label100"
        Me.Label100.Size = New System.Drawing.Size(102, 15)
        Me.Label100.TabIndex = 237
        Me.Label100.Text = "承認・申請年月日:"
        Me.Label100.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'mtxST10_UPD_YMD
        '
        Me.mtxST10_UPD_YMD.BackColor = System.Drawing.SystemColors.Window
        Me.mtxST10_UPD_YMD.Enabled = False
        Me.mtxST10_UPD_YMD.GotFocusedColor = System.Drawing.Color.FromArgb(CType(CType(190, Byte), Integer), CType(CType(180, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.mtxST10_UPD_YMD.ImeMode = System.Windows.Forms.ImeMode.Disable
        Me.mtxST10_UPD_YMD.InputRequired = False
        Me.mtxST10_UPD_YMD.Location = New System.Drawing.Point(118, 40)
        Me.mtxST10_UPD_YMD.Name = "mtxST10_UPD_YMD"
        Me.mtxST10_UPD_YMD.Size = New System.Drawing.Size(115, 24)
        Me.mtxST10_UPD_YMD.TabIndex = 0
        Me.mtxST10_UPD_YMD.WatermarkColor = System.Drawing.Color.Empty
        Me.mtxST10_UPD_YMD.WatermarkText = Nothing
        '
        'lblSTAGE10
        '
        Me.lblSTAGE10.AutoSize = True
        Me.lblSTAGE10.BackColor = System.Drawing.Color.Wheat
        Me.lblSTAGE10.Font = New System.Drawing.Font("Meiryo UI", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.lblSTAGE10.Location = New System.Drawing.Point(6, 6)
        Me.lblSTAGE10.Margin = New System.Windows.Forms.Padding(3, 3, 3, 0)
        Me.lblSTAGE10.Name = "lblSTAGE10"
        Me.lblSTAGE10.Size = New System.Drawing.Size(124, 24)
        Me.lblSTAGE10.TabIndex = 235
        Me.lblSTAGE10.Text = "処置実施決裁"
        Me.lblSTAGE10.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'tabSTAGE11
        '
        Me.tabSTAGE11.Controls.Add(Me.chkST11_E2)
        Me.tabSTAGE11.Controls.Add(Me.chkST11_D1)
        Me.tabSTAGE11.Controls.Add(Me.chkST11_D2)
        Me.tabSTAGE11.Controls.Add(Me.chkST11_E1)
        Me.tabSTAGE11.Controls.Add(Me.chkST11_C1)
        Me.tabSTAGE11.Controls.Add(Me.chkST11_B1)
        Me.tabSTAGE11.Controls.Add(Me.chkST11_A1)
        Me.tabSTAGE11.Controls.Add(Me.lblST11_Riyu)
        Me.tabSTAGE11.Controls.Add(Me.tlpST08)
        Me.tabSTAGE11.Controls.Add(Me.lblSTAGE11)
        Me.tabSTAGE11.Controls.Add(Me.cmbST11_DestTANTO)
        Me.tabSTAGE11.Controls.Add(Me.mtxST11_NextStageName)
        Me.tabSTAGE11.Controls.Add(Me.Label21)
        Me.tabSTAGE11.Controls.Add(Me.Label20)
        Me.tabSTAGE11.Controls.Add(Me.Label103)
        Me.tabSTAGE11.Controls.Add(Me.Label104)
        Me.tabSTAGE11.Controls.Add(Me.txtST11_Comment)
        Me.tabSTAGE11.Controls.Add(Me.mtxST11_UPD_YMD)
        Me.tabSTAGE11.Location = New System.Drawing.Point(4, 26)
        Me.tabSTAGE11.Name = "tabSTAGE11"
        Me.tabSTAGE11.Size = New System.Drawing.Size(1229, 312)
        Me.tabSTAGE11.TabIndex = 10
        Me.tabSTAGE11.Text = "STAGE11"
        Me.tabSTAGE11.UseVisualStyleBackColor = True
        '
        'chkST11_E2
        '
        Me.chkST11_E2.AutoSize = True
        Me.chkST11_E2.Location = New System.Drawing.Point(772, 248)
        Me.chkST11_E2.Name = "chkST11_E2"
        Me.chkST11_E2.Size = New System.Drawing.Size(43, 21)
        Me.chkST11_E2.TabIndex = 243
        Me.chkST11_E2.Text = "E2"
        Me.chkST11_E2.UseVisualStyleBackColor = True
        Me.chkST11_E2.Visible = False
        '
        'chkST11_D1
        '
        Me.chkST11_D1.AutoSize = True
        Me.chkST11_D1.Location = New System.Drawing.Point(772, 136)
        Me.chkST11_D1.Name = "chkST11_D1"
        Me.chkST11_D1.Size = New System.Drawing.Size(45, 21)
        Me.chkST11_D1.TabIndex = 242
        Me.chkST11_D1.Text = "D1"
        Me.chkST11_D1.UseVisualStyleBackColor = True
        Me.chkST11_D1.Visible = False
        '
        'chkST11_D2
        '
        Me.chkST11_D2.AutoSize = True
        Me.chkST11_D2.Location = New System.Drawing.Point(772, 162)
        Me.chkST11_D2.Name = "chkST11_D2"
        Me.chkST11_D2.Size = New System.Drawing.Size(45, 21)
        Me.chkST11_D2.TabIndex = 241
        Me.chkST11_D2.Text = "D2"
        Me.chkST11_D2.UseVisualStyleBackColor = True
        Me.chkST11_D2.Visible = False
        '
        'chkST11_E1
        '
        Me.chkST11_E1.AutoSize = True
        Me.chkST11_E1.Location = New System.Drawing.Point(772, 218)
        Me.chkST11_E1.Name = "chkST11_E1"
        Me.chkST11_E1.Size = New System.Drawing.Size(43, 21)
        Me.chkST11_E1.TabIndex = 240
        Me.chkST11_E1.Text = "E1"
        Me.chkST11_E1.UseVisualStyleBackColor = True
        Me.chkST11_E1.Visible = False
        '
        'chkST11_C1
        '
        Me.chkST11_C1.AutoSize = True
        Me.chkST11_C1.Location = New System.Drawing.Point(772, 107)
        Me.chkST11_C1.Name = "chkST11_C1"
        Me.chkST11_C1.Size = New System.Drawing.Size(44, 21)
        Me.chkST11_C1.TabIndex = 239
        Me.chkST11_C1.Text = "C1"
        Me.chkST11_C1.UseVisualStyleBackColor = True
        Me.chkST11_C1.Visible = False
        '
        'chkST11_B1
        '
        Me.chkST11_B1.AutoSize = True
        Me.chkST11_B1.Location = New System.Drawing.Point(772, 78)
        Me.chkST11_B1.Name = "chkST11_B1"
        Me.chkST11_B1.Size = New System.Drawing.Size(44, 21)
        Me.chkST11_B1.TabIndex = 239
        Me.chkST11_B1.Text = "B1"
        Me.chkST11_B1.UseVisualStyleBackColor = True
        Me.chkST11_B1.Visible = False
        '
        'chkST11_A1
        '
        Me.chkST11_A1.AutoSize = True
        Me.chkST11_A1.Location = New System.Drawing.Point(772, 48)
        Me.chkST11_A1.Name = "chkST11_A1"
        Me.chkST11_A1.Size = New System.Drawing.Size(44, 21)
        Me.chkST11_A1.TabIndex = 239
        Me.chkST11_A1.Text = "A1"
        Me.chkST11_A1.UseVisualStyleBackColor = True
        Me.chkST11_A1.Visible = False
        '
        'lblST11_Riyu
        '
        Me.lblST11_Riyu.Font = New System.Drawing.Font("Meiryo UI", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.lblST11_Riyu.Location = New System.Drawing.Point(259, 6)
        Me.lblST11_Riyu.Name = "lblST11_Riyu"
        Me.lblST11_Riyu.Size = New System.Drawing.Size(556, 24)
        Me.lblST11_Riyu.TabIndex = 238
        Me.lblST11_Riyu.Text = "差戻理由：__________________________________________________________"
        Me.lblST11_Riyu.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.lblST11_Riyu.Visible = False
        '
        'tlpST08
        '
        Me.tlpST08.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.tlpST08.CellBorderStyle = System.Windows.Forms.TableLayoutPanelCellBorderStyle.[Single]
        Me.tlpST08.ColumnCount = 5
        Me.tlpST08.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20.0!))
        Me.tlpST08.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 65.0!))
        Me.tlpST08.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.tlpST08.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 90.0!))
        Me.tlpST08.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 126.0!))
        Me.tlpST08.Controls.Add(Me.rbtnST11_E2_F, 4, 7)
        Me.tlpST08.Controls.Add(Me.rbtnST11_E2_T, 3, 7)
        Me.tlpST08.Controls.Add(Me.rbtnST11_E1_F, 4, 6)
        Me.tlpST08.Controls.Add(Me.rbtnST11_E1_T, 3, 6)
        Me.tlpST08.Controls.Add(Me.rbtnST11_D2_F, 4, 4)
        Me.tlpST08.Controls.Add(Me.rbtnST11_D2_T, 3, 4)
        Me.tlpST08.Controls.Add(Me.rbtnST11_D1_F, 4, 3)
        Me.tlpST08.Controls.Add(Me.rbtnST11_D1_T, 3, 3)
        Me.tlpST08.Controls.Add(Me.rbtnST11_C1_F, 4, 2)
        Me.tlpST08.Controls.Add(Me.rbtnST11_C1_T, 3, 2)
        Me.tlpST08.Controls.Add(Me.rbtnST11_B1_F, 4, 1)
        Me.tlpST08.Controls.Add(Me.rbtnST11_B1_T, 3, 1)
        Me.tlpST08.Controls.Add(Me.rbtnST11_A1_F, 4, 0)
        Me.tlpST08.Controls.Add(Me.mtxST11_E_Comment, 2, 8)
        Me.tlpST08.Controls.Add(Me.mtxST11_D_Comment, 2, 5)
        Me.tlpST08.Controls.Add(Me.Label125, 1, 8)
        Me.tlpST08.Controls.Add(Me.Label126, 1, 4)
        Me.tlpST08.Controls.Add(Me.Label127, 1, 3)
        Me.tlpST08.Controls.Add(Me.Label128, 1, 2)
        Me.tlpST08.Controls.Add(Me.Label129, 0, 2)
        Me.tlpST08.Controls.Add(Me.Label130, 1, 1)
        Me.tlpST08.Controls.Add(Me.Label131, 0, 1)
        Me.tlpST08.Controls.Add(Me.Label132, 0, 0)
        Me.tlpST08.Controls.Add(Me.Label133, 0, 6)
        Me.tlpST08.Controls.Add(Me.Label134, 1, 6)
        Me.tlpST08.Controls.Add(Me.Label135, 1, 5)
        Me.tlpST08.Controls.Add(Me.Label136, 1, 7)
        Me.tlpST08.Controls.Add(Me.Label137, 1, 0)
        Me.tlpST08.Controls.Add(Me.Label138, 0, 3)
        Me.tlpST08.Controls.Add(Me.rbtnST11_A1_T, 3, 0)
        Me.tlpST08.Location = New System.Drawing.Point(10, 43)
        Me.tlpST08.Name = "tlpST08"
        Me.tlpST08.RowCount = 10
        Me.tlpST08.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 28.0!))
        Me.tlpST08.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 28.0!))
        Me.tlpST08.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 28.0!))
        Me.tlpST08.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 28.0!))
        Me.tlpST08.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 28.0!))
        Me.tlpST08.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 24.0!))
        Me.tlpST08.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 28.0!))
        Me.tlpST08.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 28.0!))
        Me.tlpST08.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 24.0!))
        Me.tlpST08.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.tlpST08.Size = New System.Drawing.Size(756, 255)
        Me.tlpST08.TabIndex = 237
        '
        'rbtnST11_E2_F
        '
        Me.rbtnST11_E2_F.Dock = System.Windows.Forms.DockStyle.Fill
        Me.rbtnST11_E2_F.Location = New System.Drawing.Point(632, 203)
        Me.rbtnST11_E2_F.Name = "rbtnST11_E2_F"
        Me.rbtnST11_E2_F.Size = New System.Drawing.Size(120, 22)
        Me.rbtnST11_E2_F.TabIndex = 14
        Me.rbtnST11_E2_F.TabStop = True
        Me.rbtnST11_E2_F.Text = "未回答"
        Me.rbtnST11_E2_F.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.rbtnST11_E2_F.UseVisualStyleBackColor = True
        '
        'rbtnST11_E2_T
        '
        Me.rbtnST11_E2_T.Dock = System.Windows.Forms.DockStyle.Fill
        Me.rbtnST11_E2_T.Location = New System.Drawing.Point(541, 203)
        Me.rbtnST11_E2_T.Name = "rbtnST11_E2_T"
        Me.rbtnST11_E2_T.Size = New System.Drawing.Size(84, 22)
        Me.rbtnST11_E2_T.TabIndex = 13
        Me.rbtnST11_E2_T.TabStop = True
        Me.rbtnST11_E2_T.Text = "良好"
        Me.rbtnST11_E2_T.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.rbtnST11_E2_T.UseVisualStyleBackColor = True
        '
        'rbtnST11_E1_F
        '
        Me.rbtnST11_E1_F.Dock = System.Windows.Forms.DockStyle.Fill
        Me.rbtnST11_E1_F.Location = New System.Drawing.Point(632, 174)
        Me.rbtnST11_E1_F.Name = "rbtnST11_E1_F"
        Me.rbtnST11_E1_F.Size = New System.Drawing.Size(120, 22)
        Me.rbtnST11_E1_F.TabIndex = 12
        Me.rbtnST11_E1_F.TabStop = True
        Me.rbtnST11_E1_F.Text = "未回答"
        Me.rbtnST11_E1_F.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.rbtnST11_E1_F.UseVisualStyleBackColor = True
        '
        'rbtnST11_E1_T
        '
        Me.rbtnST11_E1_T.Dock = System.Windows.Forms.DockStyle.Fill
        Me.rbtnST11_E1_T.Location = New System.Drawing.Point(541, 174)
        Me.rbtnST11_E1_T.Name = "rbtnST11_E1_T"
        Me.rbtnST11_E1_T.Size = New System.Drawing.Size(84, 22)
        Me.rbtnST11_E1_T.TabIndex = 11
        Me.rbtnST11_E1_T.TabStop = True
        Me.rbtnST11_E1_T.Text = "良好"
        Me.rbtnST11_E1_T.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.rbtnST11_E1_T.UseVisualStyleBackColor = True
        '
        'rbtnST11_D2_F
        '
        Me.rbtnST11_D2_F.Dock = System.Windows.Forms.DockStyle.Fill
        Me.rbtnST11_D2_F.Location = New System.Drawing.Point(632, 120)
        Me.rbtnST11_D2_F.Name = "rbtnST11_D2_F"
        Me.rbtnST11_D2_F.Size = New System.Drawing.Size(120, 22)
        Me.rbtnST11_D2_F.TabIndex = 9
        Me.rbtnST11_D2_F.TabStop = True
        Me.rbtnST11_D2_F.Text = "未回答"
        Me.rbtnST11_D2_F.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.rbtnST11_D2_F.UseVisualStyleBackColor = True
        '
        'rbtnST11_D2_T
        '
        Me.rbtnST11_D2_T.Dock = System.Windows.Forms.DockStyle.Fill
        Me.rbtnST11_D2_T.Location = New System.Drawing.Point(541, 120)
        Me.rbtnST11_D2_T.Name = "rbtnST11_D2_T"
        Me.rbtnST11_D2_T.Size = New System.Drawing.Size(84, 22)
        Me.rbtnST11_D2_T.TabIndex = 8
        Me.rbtnST11_D2_T.TabStop = True
        Me.rbtnST11_D2_T.Text = "良好"
        Me.rbtnST11_D2_T.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.rbtnST11_D2_T.UseVisualStyleBackColor = True
        '
        'rbtnST11_D1_F
        '
        Me.rbtnST11_D1_F.Dock = System.Windows.Forms.DockStyle.Fill
        Me.rbtnST11_D1_F.Location = New System.Drawing.Point(632, 91)
        Me.rbtnST11_D1_F.Name = "rbtnST11_D1_F"
        Me.rbtnST11_D1_F.Size = New System.Drawing.Size(120, 22)
        Me.rbtnST11_D1_F.TabIndex = 7
        Me.rbtnST11_D1_F.TabStop = True
        Me.rbtnST11_D1_F.Text = "未回答"
        Me.rbtnST11_D1_F.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.rbtnST11_D1_F.UseVisualStyleBackColor = True
        '
        'rbtnST11_D1_T
        '
        Me.rbtnST11_D1_T.Dock = System.Windows.Forms.DockStyle.Fill
        Me.rbtnST11_D1_T.Location = New System.Drawing.Point(541, 91)
        Me.rbtnST11_D1_T.Name = "rbtnST11_D1_T"
        Me.rbtnST11_D1_T.Size = New System.Drawing.Size(84, 22)
        Me.rbtnST11_D1_T.TabIndex = 6
        Me.rbtnST11_D1_T.TabStop = True
        Me.rbtnST11_D1_T.Text = "良好"
        Me.rbtnST11_D1_T.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.rbtnST11_D1_T.UseVisualStyleBackColor = True
        '
        'rbtnST11_C1_F
        '
        Me.rbtnST11_C1_F.Dock = System.Windows.Forms.DockStyle.Fill
        Me.rbtnST11_C1_F.Location = New System.Drawing.Point(632, 62)
        Me.rbtnST11_C1_F.Name = "rbtnST11_C1_F"
        Me.rbtnST11_C1_F.Size = New System.Drawing.Size(120, 22)
        Me.rbtnST11_C1_F.TabIndex = 5
        Me.rbtnST11_C1_F.TabStop = True
        Me.rbtnST11_C1_F.Text = "未回答"
        Me.rbtnST11_C1_F.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.rbtnST11_C1_F.UseVisualStyleBackColor = True
        '
        'rbtnST11_C1_T
        '
        Me.rbtnST11_C1_T.Dock = System.Windows.Forms.DockStyle.Fill
        Me.rbtnST11_C1_T.Location = New System.Drawing.Point(541, 62)
        Me.rbtnST11_C1_T.Name = "rbtnST11_C1_T"
        Me.rbtnST11_C1_T.Size = New System.Drawing.Size(84, 22)
        Me.rbtnST11_C1_T.TabIndex = 4
        Me.rbtnST11_C1_T.TabStop = True
        Me.rbtnST11_C1_T.Text = "良好"
        Me.rbtnST11_C1_T.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.rbtnST11_C1_T.UseVisualStyleBackColor = True
        '
        'rbtnST11_B1_F
        '
        Me.rbtnST11_B1_F.Dock = System.Windows.Forms.DockStyle.Fill
        Me.rbtnST11_B1_F.Location = New System.Drawing.Point(632, 33)
        Me.rbtnST11_B1_F.Name = "rbtnST11_B1_F"
        Me.rbtnST11_B1_F.Size = New System.Drawing.Size(120, 22)
        Me.rbtnST11_B1_F.TabIndex = 3
        Me.rbtnST11_B1_F.TabStop = True
        Me.rbtnST11_B1_F.Text = "未回答"
        Me.rbtnST11_B1_F.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.rbtnST11_B1_F.UseVisualStyleBackColor = True
        '
        'rbtnST11_B1_T
        '
        Me.rbtnST11_B1_T.Dock = System.Windows.Forms.DockStyle.Fill
        Me.rbtnST11_B1_T.Location = New System.Drawing.Point(541, 33)
        Me.rbtnST11_B1_T.Name = "rbtnST11_B1_T"
        Me.rbtnST11_B1_T.Size = New System.Drawing.Size(84, 22)
        Me.rbtnST11_B1_T.TabIndex = 2
        Me.rbtnST11_B1_T.TabStop = True
        Me.rbtnST11_B1_T.Text = "良好"
        Me.rbtnST11_B1_T.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.rbtnST11_B1_T.UseVisualStyleBackColor = True
        '
        'rbtnST11_A1_F
        '
        Me.rbtnST11_A1_F.Dock = System.Windows.Forms.DockStyle.Fill
        Me.rbtnST11_A1_F.Location = New System.Drawing.Point(632, 4)
        Me.rbtnST11_A1_F.Name = "rbtnST11_A1_F"
        Me.rbtnST11_A1_F.Size = New System.Drawing.Size(120, 22)
        Me.rbtnST11_A1_F.TabIndex = 1
        Me.rbtnST11_A1_F.TabStop = True
        Me.rbtnST11_A1_F.Text = "未回答"
        Me.rbtnST11_A1_F.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.rbtnST11_A1_F.UseVisualStyleBackColor = True
        '
        'mtxST11_E_Comment
        '
        Me.mtxST11_E_Comment.BackColor = System.Drawing.SystemColors.Window
        Me.tlpST08.SetColumnSpan(Me.mtxST11_E_Comment, 3)
        Me.mtxST11_E_Comment.Dock = System.Windows.Forms.DockStyle.Fill
        Me.mtxST11_E_Comment.GotFocusedColor = System.Drawing.Color.FromArgb(CType(CType(190, Byte), Integer), CType(CType(180, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.mtxST11_E_Comment.ImeMode = System.Windows.Forms.ImeMode.Disable
        Me.mtxST11_E_Comment.InputRequired = False
        Me.mtxST11_E_Comment.Location = New System.Drawing.Point(88, 229)
        Me.mtxST11_E_Comment.Margin = New System.Windows.Forms.Padding(0)
        Me.mtxST11_E_Comment.Name = "mtxST11_E_Comment"
        Me.mtxST11_E_Comment.Size = New System.Drawing.Size(667, 24)
        Me.mtxST11_E_Comment.TabIndex = 15
        Me.mtxST11_E_Comment.WatermarkColor = System.Drawing.Color.Empty
        Me.mtxST11_E_Comment.WatermarkText = Nothing
        '
        'mtxST11_D_Comment
        '
        Me.mtxST11_D_Comment.BackColor = System.Drawing.SystemColors.Window
        Me.tlpST08.SetColumnSpan(Me.mtxST11_D_Comment, 3)
        Me.mtxST11_D_Comment.Dock = System.Windows.Forms.DockStyle.Fill
        Me.mtxST11_D_Comment.GotFocusedColor = System.Drawing.Color.FromArgb(CType(CType(190, Byte), Integer), CType(CType(180, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.mtxST11_D_Comment.ImeMode = System.Windows.Forms.ImeMode.Disable
        Me.mtxST11_D_Comment.InputRequired = False
        Me.mtxST11_D_Comment.Location = New System.Drawing.Point(88, 146)
        Me.mtxST11_D_Comment.Margin = New System.Windows.Forms.Padding(0)
        Me.mtxST11_D_Comment.Name = "mtxST11_D_Comment"
        Me.mtxST11_D_Comment.Size = New System.Drawing.Size(667, 24)
        Me.mtxST11_D_Comment.TabIndex = 10
        Me.mtxST11_D_Comment.WatermarkColor = System.Drawing.Color.Empty
        Me.mtxST11_D_Comment.WatermarkText = Nothing
        '
        'Label125
        '
        Me.Label125.AutoSize = True
        Me.Label125.BackColor = System.Drawing.SystemColors.Window
        Me.Label125.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Label125.Font = New System.Drawing.Font("Meiryo UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label125.Location = New System.Drawing.Point(25, 229)
        Me.Label125.Name = "Label125"
        Me.Label125.Size = New System.Drawing.Size(59, 24)
        Me.Label125.TabIndex = 239
        Me.Label125.Text = "処置記録"
        Me.Label125.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label126
        '
        Me.Label126.AutoSize = True
        Me.Label126.BackColor = System.Drawing.SystemColors.Window
        Me.tlpST08.SetColumnSpan(Me.Label126, 2)
        Me.Label126.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Label126.Font = New System.Drawing.Font("Meiryo UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label126.Location = New System.Drawing.Point(25, 117)
        Me.Label126.Name = "Label126"
        Me.Label126.Size = New System.Drawing.Size(509, 28)
        Me.Label126.TabIndex = 241
        Me.Label126.Text = "影響有の場合、顧客への通知の要否"
        Me.Label126.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label127
        '
        Me.Label127.AutoSize = True
        Me.Label127.BackColor = System.Drawing.SystemColors.Window
        Me.tlpST08.SetColumnSpan(Me.Label127, 2)
        Me.Label127.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Label127.Font = New System.Drawing.Font("Meiryo UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label127.Location = New System.Drawing.Point(25, 88)
        Me.Label127.Name = "Label127"
        Me.Label127.Size = New System.Drawing.Size(509, 28)
        Me.Label127.TabIndex = 242
        Me.Label127.Text = "当該不適合による顧客への影響"
        Me.Label127.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label128
        '
        Me.Label128.AutoSize = True
        Me.Label128.BackColor = System.Drawing.SystemColors.Window
        Me.tlpST08.SetColumnSpan(Me.Label128, 2)
        Me.Label128.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Label128.Font = New System.Drawing.Font("Meiryo UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label128.Location = New System.Drawing.Point(25, 59)
        Me.Label128.Name = "Label128"
        Me.Label128.Size = New System.Drawing.Size(509, 28)
        Me.Label128.TabIndex = 241
        Me.Label128.Text = "廃却処置は本来の意図した使用又は適用ができない方法だったか？"
        Me.Label128.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label129
        '
        Me.Label129.AutoSize = True
        Me.Label129.BackColor = System.Drawing.SystemColors.Window
        Me.Label129.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Label129.Font = New System.Drawing.Font("Meiryo UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label129.Location = New System.Drawing.Point(4, 59)
        Me.Label129.Name = "Label129"
        Me.Label129.Size = New System.Drawing.Size(14, 28)
        Me.Label129.TabIndex = 243
        Me.Label129.Text = "C"
        Me.Label129.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label130
        '
        Me.Label130.AutoSize = True
        Me.Label130.BackColor = System.Drawing.SystemColors.Window
        Me.tlpST08.SetColumnSpan(Me.Label130, 2)
        Me.Label130.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Label130.Font = New System.Drawing.Font("Meiryo UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label130.Location = New System.Drawing.Point(25, 30)
        Me.Label130.Name = "Label130"
        Me.Label130.Size = New System.Drawing.Size(509, 28)
        Me.Label130.TabIndex = 240
        Me.Label130.Text = "社内権限者により、又は顧客再審の場合は顧客により判定されたか？"
        Me.Label130.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label131
        '
        Me.Label131.AutoSize = True
        Me.Label131.BackColor = System.Drawing.SystemColors.Window
        Me.Label131.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Label131.Font = New System.Drawing.Font("Meiryo UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label131.Location = New System.Drawing.Point(4, 30)
        Me.Label131.Name = "Label131"
        Me.Label131.Size = New System.Drawing.Size(14, 28)
        Me.Label131.TabIndex = 244
        Me.Label131.Text = "B"
        Me.Label131.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label132
        '
        Me.Label132.AutoSize = True
        Me.Label132.BackColor = System.Drawing.SystemColors.Window
        Me.Label132.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Label132.Font = New System.Drawing.Font("Meiryo UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label132.Location = New System.Drawing.Point(4, 1)
        Me.Label132.Name = "Label132"
        Me.Label132.Size = New System.Drawing.Size(14, 28)
        Me.Label132.TabIndex = 245
        Me.Label132.Text = "A"
        Me.Label132.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label133
        '
        Me.Label133.BackColor = System.Drawing.SystemColors.Window
        Me.Label133.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Label133.Font = New System.Drawing.Font("Meiryo UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label133.Location = New System.Drawing.Point(1, 171)
        Me.Label133.Margin = New System.Windows.Forms.Padding(0)
        Me.Label133.Name = "Label133"
        Me.tlpST08.SetRowSpan(Me.Label133, 3)
        Me.Label133.Size = New System.Drawing.Size(20, 82)
        Me.Label133.TabIndex = 242
        Me.Label133.Text = "E"
        Me.Label133.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label134
        '
        Me.Label134.AutoSize = True
        Me.Label134.BackColor = System.Drawing.SystemColors.Window
        Me.tlpST08.SetColumnSpan(Me.Label134, 2)
        Me.Label134.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Label134.Font = New System.Drawing.Font("Meiryo UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label134.Location = New System.Drawing.Point(25, 171)
        Me.Label134.Name = "Label134"
        Me.Label134.Size = New System.Drawing.Size(509, 28)
        Me.Label134.TabIndex = 240
        Me.Label134.Text = "当該不適合による他のプロセスへの影響"
        Me.Label134.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label135
        '
        Me.Label135.AutoSize = True
        Me.Label135.BackColor = System.Drawing.SystemColors.Window
        Me.Label135.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Label135.Font = New System.Drawing.Font("Meiryo UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label135.Location = New System.Drawing.Point(25, 146)
        Me.Label135.Name = "Label135"
        Me.Label135.Size = New System.Drawing.Size(59, 24)
        Me.Label135.TabIndex = 246
        Me.Label135.Text = "処置記録"
        Me.Label135.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label136
        '
        Me.Label136.AutoSize = True
        Me.Label136.BackColor = System.Drawing.SystemColors.Window
        Me.tlpST08.SetColumnSpan(Me.Label136, 2)
        Me.Label136.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Label136.Font = New System.Drawing.Font("Meiryo UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label136.Location = New System.Drawing.Point(25, 200)
        Me.Label136.Name = "Label136"
        Me.Label136.Size = New System.Drawing.Size(509, 28)
        Me.Label136.TabIndex = 247
        Me.Label136.Text = "影響有の場合、封じ込め処置の要否"
        Me.Label136.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label137
        '
        Me.Label137.AutoSize = True
        Me.Label137.BackColor = System.Drawing.SystemColors.Window
        Me.tlpST08.SetColumnSpan(Me.Label137, 2)
        Me.Label137.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Label137.Font = New System.Drawing.Font("Meiryo UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label137.Location = New System.Drawing.Point(25, 1)
        Me.Label137.Name = "Label137"
        Me.Label137.Size = New System.Drawing.Size(509, 28)
        Me.Label137.TabIndex = 238
        Me.Label137.Text = "検出された不適合を除去する処置（廃却を含む）は確実にとられたか？"
        Me.Label137.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label138
        '
        Me.Label138.BackColor = System.Drawing.SystemColors.Window
        Me.Label138.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Label138.Font = New System.Drawing.Font("Meiryo UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label138.Location = New System.Drawing.Point(1, 88)
        Me.Label138.Margin = New System.Windows.Forms.Padding(0)
        Me.Label138.Name = "Label138"
        Me.tlpST08.SetRowSpan(Me.Label138, 3)
        Me.Label138.Size = New System.Drawing.Size(20, 82)
        Me.Label138.TabIndex = 239
        Me.Label138.Text = "D"
        Me.Label138.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'rbtnST11_A1_T
        '
        Me.rbtnST11_A1_T.Dock = System.Windows.Forms.DockStyle.Fill
        Me.rbtnST11_A1_T.Location = New System.Drawing.Point(541, 4)
        Me.rbtnST11_A1_T.Name = "rbtnST11_A1_T"
        Me.rbtnST11_A1_T.Size = New System.Drawing.Size(84, 22)
        Me.rbtnST11_A1_T.TabIndex = 0
        Me.rbtnST11_A1_T.TabStop = True
        Me.rbtnST11_A1_T.Text = "良好"
        Me.rbtnST11_A1_T.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.rbtnST11_A1_T.UseVisualStyleBackColor = True
        '
        'lblSTAGE11
        '
        Me.lblSTAGE11.AutoSize = True
        Me.lblSTAGE11.BackColor = System.Drawing.Color.Wheat
        Me.lblSTAGE11.Font = New System.Drawing.Font("Meiryo UI", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.lblSTAGE11.Location = New System.Drawing.Point(6, 6)
        Me.lblSTAGE11.Margin = New System.Windows.Forms.Padding(3, 3, 3, 0)
        Me.lblSTAGE11.Name = "lblSTAGE11"
        Me.lblSTAGE11.Size = New System.Drawing.Size(161, 24)
        Me.lblSTAGE11.TabIndex = 236
        Me.lblSTAGE11.Text = "処置確認(担当者)"
        Me.lblSTAGE11.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'cmbST11_DestTANTO
        '
        Me.cmbST11_DestTANTO.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cmbST11_DestTANTO.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cmbST11_DestTANTO.BackColor = System.Drawing.SystemColors.Window
        Me.cmbST11_DestTANTO.Cursor = System.Windows.Forms.Cursors.Hand
        Me.cmbST11_DestTANTO.Font = New System.Drawing.Font("Meiryo UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.cmbST11_DestTANTO.ForeColor = System.Drawing.SystemColors.ControlText
        Me.cmbST11_DestTANTO.FormattingEnabled = True
        Me.cmbST11_DestTANTO.GotFocusedColor = System.Drawing.Color.FromArgb(CType(CType(190, Byte), Integer), CType(CType(180, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.cmbST11_DestTANTO.ImeMode = System.Windows.Forms.ImeMode.[On]
        Me.cmbST11_DestTANTO.Location = New System.Drawing.Point(927, 106)
        Me.cmbST11_DestTANTO.Name = "cmbST11_DestTANTO"
        Me.cmbST11_DestTANTO.Selected = False
        Me.cmbST11_DestTANTO.Size = New System.Drawing.Size(154, 25)
        Me.cmbST11_DestTANTO.TabIndex = 2
        Me.cmbST11_DestTANTO.Text = "(選択)"
        '
        'mtxST11_NextStageName
        '
        Me.mtxST11_NextStageName.BackColor = System.Drawing.SystemColors.Window
        Me.mtxST11_NextStageName.Enabled = False
        Me.mtxST11_NextStageName.GotFocusedColor = System.Drawing.Color.FromArgb(CType(CType(190, Byte), Integer), CType(CType(180, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.mtxST11_NextStageName.ImeMode = System.Windows.Forms.ImeMode.Disable
        Me.mtxST11_NextStageName.InputRequired = False
        Me.mtxST11_NextStageName.Location = New System.Drawing.Point(927, 76)
        Me.mtxST11_NextStageName.Name = "mtxST11_NextStageName"
        Me.mtxST11_NextStageName.Size = New System.Drawing.Size(295, 24)
        Me.mtxST11_NextStageName.TabIndex = 1
        Me.mtxST11_NextStageName.WatermarkColor = System.Drawing.Color.Empty
        Me.mtxST11_NextStageName.WatermarkText = Nothing
        '
        'Label21
        '
        Me.Label21.AutoSize = True
        Me.Label21.Font = New System.Drawing.Font("Meiryo UI", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label21.Location = New System.Drawing.Point(821, 83)
        Me.Label21.Margin = New System.Windows.Forms.Padding(3, 3, 3, 0)
        Me.Label21.Name = "Label21"
        Me.Label21.Size = New System.Drawing.Size(100, 15)
        Me.Label21.TabIndex = 230
        Me.Label21.Text = "承認先ステージ名:"
        Me.Label21.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label20
        '
        Me.Label20.AutoSize = True
        Me.Label20.Font = New System.Drawing.Font("Meiryo UI", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label20.Location = New System.Drawing.Point(825, 52)
        Me.Label20.Margin = New System.Windows.Forms.Padding(3, 3, 3, 0)
        Me.Label20.Name = "Label20"
        Me.Label20.Size = New System.Drawing.Size(96, 15)
        Me.Label20.TabIndex = 230
        Me.Label20.Text = "承認申請年月日:"
        Me.Label20.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label103
        '
        Me.Label103.AutoSize = True
        Me.Label103.Font = New System.Drawing.Font("Meiryo UI", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label103.Location = New System.Drawing.Point(849, 110)
        Me.Label103.Margin = New System.Windows.Forms.Padding(3, 3, 3, 0)
        Me.Label103.Name = "Label103"
        Me.Label103.Size = New System.Drawing.Size(72, 15)
        Me.Label103.TabIndex = 230
        Me.Label103.Text = "申請先社員:"
        Me.Label103.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label104
        '
        Me.Label104.AutoSize = True
        Me.Label104.Font = New System.Drawing.Font("Meiryo UI", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label104.Location = New System.Drawing.Point(872, 141)
        Me.Label104.Margin = New System.Windows.Forms.Padding(3, 3, 3, 0)
        Me.Label104.Name = "Label104"
        Me.Label104.Size = New System.Drawing.Size(49, 15)
        Me.Label104.TabIndex = 229
        Me.Label104.Text = "コメント:"
        Me.Label104.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'txtST11_Comment
        '
        Me.txtST11_Comment.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtST11_Comment.BackColor = System.Drawing.SystemColors.Window
        Me.txtST11_Comment.GotFocusedColor = System.Drawing.Color.FromArgb(CType(CType(190, Byte), Integer), CType(CType(180, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.txtST11_Comment.ImeMode = System.Windows.Forms.ImeMode.[On]
        Me.txtST11_Comment.Location = New System.Drawing.Point(927, 137)
        Me.txtST11_Comment.Multiline = True
        Me.txtST11_Comment.Name = "txtST11_Comment"
        Me.txtST11_Comment.Size = New System.Drawing.Size(295, 167)
        Me.txtST11_Comment.TabIndex = 3
        Me.txtST11_Comment.WatermarkText = Nothing
        '
        'mtxST11_UPD_YMD
        '
        Me.mtxST11_UPD_YMD.BackColor = System.Drawing.SystemColors.Window
        Me.mtxST11_UPD_YMD.Enabled = False
        Me.mtxST11_UPD_YMD.GotFocusedColor = System.Drawing.Color.FromArgb(CType(CType(190, Byte), Integer), CType(CType(180, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.mtxST11_UPD_YMD.ImeMode = System.Windows.Forms.ImeMode.Disable
        Me.mtxST11_UPD_YMD.InputRequired = False
        Me.mtxST11_UPD_YMD.Location = New System.Drawing.Point(927, 46)
        Me.mtxST11_UPD_YMD.Name = "mtxST11_UPD_YMD"
        Me.mtxST11_UPD_YMD.Size = New System.Drawing.Size(115, 24)
        Me.mtxST11_UPD_YMD.TabIndex = 0
        Me.mtxST11_UPD_YMD.WatermarkColor = System.Drawing.Color.Empty
        Me.mtxST11_UPD_YMD.WatermarkText = Nothing
        '
        'tabSTAGE12
        '
        Me.tabSTAGE12.Controls.Add(Me.Label122)
        Me.tabSTAGE12.Controls.Add(Me.lblSTAGE12)
        Me.tabSTAGE12.Location = New System.Drawing.Point(4, 26)
        Me.tabSTAGE12.Name = "tabSTAGE12"
        Me.tabSTAGE12.Size = New System.Drawing.Size(1229, 312)
        Me.tabSTAGE12.TabIndex = 11
        Me.tabSTAGE12.Text = "STAGE12"
        Me.tabSTAGE12.UseVisualStyleBackColor = True
        '
        'Label122
        '
        Me.Label122.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label122.Font = New System.Drawing.Font("Meiryo UI", 36.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label122.Location = New System.Drawing.Point(350, 126)
        Me.Label122.Margin = New System.Windows.Forms.Padding(3, 3, 3, 0)
        Me.Label122.Name = "Label122"
        Me.Label122.Size = New System.Drawing.Size(525, 61)
        Me.Label122.TabIndex = 241
        Me.Label122.Text = "最終承認を行ってください"
        Me.Label122.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'lblSTAGE12
        '
        Me.lblSTAGE12.AutoSize = True
        Me.lblSTAGE12.BackColor = System.Drawing.Color.Wheat
        Me.lblSTAGE12.Font = New System.Drawing.Font("Meiryo UI", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.lblSTAGE12.Location = New System.Drawing.Point(6, 6)
        Me.lblSTAGE12.Margin = New System.Windows.Forms.Padding(3, 3, 3, 0)
        Me.lblSTAGE12.Name = "lblSTAGE12"
        Me.lblSTAGE12.Size = New System.Drawing.Size(161, 24)
        Me.lblSTAGE12.TabIndex = 237
        Me.lblSTAGE12.Text = "処置確認(検査Ｇ)"
        Me.lblSTAGE12.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'tabAttachment
        '
        Me.tabAttachment.Controls.Add(Me.SplitContainer1)
        Me.tabAttachment.Controls.Add(Me.fpnlTempFile)
        Me.tabAttachment.Controls.Add(Me.btnOpenTempFileDialog)
        Me.tabAttachment.Controls.Add(Me.Label19)
        Me.tabAttachment.Location = New System.Drawing.Point(4, 26)
        Me.tabAttachment.Name = "tabAttachment"
        Me.tabAttachment.Size = New System.Drawing.Size(1229, 312)
        Me.tabAttachment.TabIndex = 12
        Me.tabAttachment.Text = "添付資料"
        Me.tabAttachment.UseVisualStyleBackColor = True
        '
        'SplitContainer1
        '
        Me.SplitContainer1.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.SplitContainer1.Location = New System.Drawing.Point(6, 37)
        Me.SplitContainer1.Name = "SplitContainer1"
        '
        'SplitContainer1.Panel1
        '
        Me.SplitContainer1.Panel1.Controls.Add(Me.flpPict1Path)
        Me.SplitContainer1.Panel1.Controls.Add(Me.pnlPict1)
        Me.SplitContainer1.Panel1.Controls.Add(Me.Label24)
        Me.SplitContainer1.Panel1.Controls.Add(Me.btnOpenPict1Dialog)
        '
        'SplitContainer1.Panel2
        '
        Me.SplitContainer1.Panel2.Controls.Add(Me.flpPict2Path)
        Me.SplitContainer1.Panel2.Controls.Add(Me.pnlPict2)
        Me.SplitContainer1.Panel2.Controls.Add(Me.Label25)
        Me.SplitContainer1.Panel2.Controls.Add(Me.btnOpenPict2Dialog)
        Me.SplitContainer1.Size = New System.Drawing.Size(1209, 266)
        Me.SplitContainer1.SplitterDistance = 601
        Me.SplitContainer1.TabIndex = 3
        '
        'flpPict1Path
        '
        Me.flpPict1Path.AllowDrop = True
        Me.flpPict1Path.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.flpPict1Path.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.flpPict1Path.Controls.Add(Me.lblPict1Path_Clear)
        Me.flpPict1Path.Controls.Add(Me.lblPict1Path)
        Me.flpPict1Path.Location = New System.Drawing.Point(73, 5)
        Me.flpPict1Path.Name = "flpPict1Path"
        Me.flpPict1Path.Size = New System.Drawing.Size(464, 20)
        Me.flpPict1Path.TabIndex = 0
        '
        'lblPict1Path_Clear
        '
        Me.lblPict1Path_Clear.AutoSize = True
        Me.lblPict1Path_Clear.Cursor = System.Windows.Forms.Cursors.Hand
        Me.lblPict1Path_Clear.Dock = System.Windows.Forms.DockStyle.Right
        Me.lblPict1Path_Clear.Font = New System.Drawing.Font("Meiryo UI", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.lblPict1Path_Clear.LinkBehavior = System.Windows.Forms.LinkBehavior.NeverUnderline
        Me.lblPict1Path_Clear.LinkColor = System.Drawing.Color.Red
        Me.lblPict1Path_Clear.Location = New System.Drawing.Point(443, 0)
        Me.lblPict1Path_Clear.Margin = New System.Windows.Forms.Padding(0)
        Me.lblPict1Path_Clear.Name = "lblPict1Path_Clear"
        Me.lblPict1Path_Clear.Size = New System.Drawing.Size(19, 17)
        Me.lblPict1Path_Clear.TabIndex = 128
        Me.lblPict1Path_Clear.TabStop = True
        Me.lblPict1Path_Clear.Text = "×"
        Me.lblPict1Path_Clear.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.lblPict1Path_Clear.Visible = False
        '
        'lblPict1Path
        '
        Me.lblPict1Path.AllowDrop = True
        Me.lblPict1Path.Dock = System.Windows.Forms.DockStyle.Left
        Me.lblPict1Path.Location = New System.Drawing.Point(0, 0)
        Me.lblPict1Path.Margin = New System.Windows.Forms.Padding(0)
        Me.lblPict1Path.Name = "lblPict1Path"
        Me.lblPict1Path.Size = New System.Drawing.Size(365, 18)
        Me.lblPict1Path.TabIndex = 126
        Me.lblPict1Path.TabStop = True
        Me.lblPict1Path.Text = "link1"
        Me.lblPict1Path.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.lblPict1Path.Visible = False
        '
        'pnlPict1
        '
        Me.pnlPict1.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.pnlPict1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.pnlPict1.Location = New System.Drawing.Point(3, 31)
        Me.pnlPict1.Name = "pnlPict1"
        Me.pnlPict1.Size = New System.Drawing.Size(593, 235)
        Me.pnlPict1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.pnlPict1.TabIndex = 124
        Me.pnlPict1.TabStop = False
        '
        'Label24
        '
        Me.Label24.AutoSize = True
        Me.Label24.Font = New System.Drawing.Font("Meiryo UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label24.Location = New System.Drawing.Point(4, 9)
        Me.Label24.Margin = New System.Windows.Forms.Padding(3, 3, 3, 0)
        Me.Label24.Name = "Label24"
        Me.Label24.Size = New System.Drawing.Size(43, 15)
        Me.Label24.TabIndex = 116
        Me.Label24.Text = "画像1:"
        Me.Label24.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'btnOpenPict1Dialog
        '
        Me.btnOpenPict1Dialog.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnOpenPict1Dialog.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnOpenPict1Dialog.Image = CType(resources.GetObject("btnOpenPict1Dialog.Image"), System.Drawing.Image)
        Me.btnOpenPict1Dialog.Location = New System.Drawing.Point(543, 3)
        Me.btnOpenPict1Dialog.Name = "btnOpenPict1Dialog"
        Me.btnOpenPict1Dialog.Size = New System.Drawing.Size(54, 24)
        Me.btnOpenPict1Dialog.TabIndex = 1
        Me.btnOpenPict1Dialog.UseVisualStyleBackColor = True
        '
        'flpPict2Path
        '
        Me.flpPict2Path.AllowDrop = True
        Me.flpPict2Path.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.flpPict2Path.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.flpPict2Path.Controls.Add(Me.lblPict2Path_Clear)
        Me.flpPict2Path.Controls.Add(Me.lblPict2Path)
        Me.flpPict2Path.Location = New System.Drawing.Point(68, 5)
        Me.flpPict2Path.Name = "flpPict2Path"
        Me.flpPict2Path.Size = New System.Drawing.Size(473, 20)
        Me.flpPict2Path.TabIndex = 130
        '
        'lblPict2Path_Clear
        '
        Me.lblPict2Path_Clear.AutoSize = True
        Me.lblPict2Path_Clear.Cursor = System.Windows.Forms.Cursors.Hand
        Me.lblPict2Path_Clear.Dock = System.Windows.Forms.DockStyle.Right
        Me.lblPict2Path_Clear.Font = New System.Drawing.Font("Meiryo UI", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.lblPict2Path_Clear.LinkBehavior = System.Windows.Forms.LinkBehavior.NeverUnderline
        Me.lblPict2Path_Clear.LinkColor = System.Drawing.Color.Red
        Me.lblPict2Path_Clear.Location = New System.Drawing.Point(452, 0)
        Me.lblPict2Path_Clear.Margin = New System.Windows.Forms.Padding(0)
        Me.lblPict2Path_Clear.Name = "lblPict2Path_Clear"
        Me.lblPict2Path_Clear.Size = New System.Drawing.Size(19, 17)
        Me.lblPict2Path_Clear.TabIndex = 1
        Me.lblPict2Path_Clear.TabStop = True
        Me.lblPict2Path_Clear.Text = "×"
        Me.lblPict2Path_Clear.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.lblPict2Path_Clear.Visible = False
        '
        'lblPict2Path
        '
        Me.lblPict2Path.AllowDrop = True
        Me.lblPict2Path.Dock = System.Windows.Forms.DockStyle.Left
        Me.lblPict2Path.Location = New System.Drawing.Point(0, 0)
        Me.lblPict2Path.Margin = New System.Windows.Forms.Padding(0)
        Me.lblPict2Path.Name = "lblPict2Path"
        Me.lblPict2Path.Size = New System.Drawing.Size(430, 18)
        Me.lblPict2Path.TabIndex = 0
        Me.lblPict2Path.TabStop = True
        Me.lblPict2Path.Text = "link1"
        Me.lblPict2Path.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.lblPict2Path.Visible = False
        '
        'pnlPict2
        '
        Me.pnlPict2.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.pnlPict2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.pnlPict2.Location = New System.Drawing.Point(7, 30)
        Me.pnlPict2.Name = "pnlPict2"
        Me.pnlPict2.Size = New System.Drawing.Size(596, 236)
        Me.pnlPict2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.pnlPict2.TabIndex = 125
        Me.pnlPict2.TabStop = False
        '
        'Label25
        '
        Me.Label25.AutoSize = True
        Me.Label25.Font = New System.Drawing.Font("Meiryo UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label25.Location = New System.Drawing.Point(4, 9)
        Me.Label25.Margin = New System.Windows.Forms.Padding(3, 3, 3, 0)
        Me.Label25.Name = "Label25"
        Me.Label25.Size = New System.Drawing.Size(43, 15)
        Me.Label25.TabIndex = 119
        Me.Label25.Text = "画像2:"
        Me.Label25.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'btnOpenPict2Dialog
        '
        Me.btnOpenPict2Dialog.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnOpenPict2Dialog.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnOpenPict2Dialog.Image = CType(resources.GetObject("btnOpenPict2Dialog.Image"), System.Drawing.Image)
        Me.btnOpenPict2Dialog.Location = New System.Drawing.Point(547, 3)
        Me.btnOpenPict2Dialog.Name = "btnOpenPict2Dialog"
        Me.btnOpenPict2Dialog.Size = New System.Drawing.Size(54, 24)
        Me.btnOpenPict2Dialog.TabIndex = 121
        Me.btnOpenPict2Dialog.UseVisualStyleBackColor = True
        '
        'fpnlTempFile
        '
        Me.fpnlTempFile.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.fpnlTempFile.Controls.Add(Me.lbltmpFile1)
        Me.fpnlTempFile.Controls.Add(Me.lbltmpFile1_Clear)
        Me.fpnlTempFile.Controls.Add(Me.LinkLabel1)
        Me.fpnlTempFile.Controls.Add(Me.LinkLabel2)
        Me.fpnlTempFile.Controls.Add(Me.LinkLabel3)
        Me.fpnlTempFile.Controls.Add(Me.LinkLabel4)
        Me.fpnlTempFile.Controls.Add(Me.LinkLabel5)
        Me.fpnlTempFile.Controls.Add(Me.LinkLabel6)
        Me.fpnlTempFile.Controls.Add(Me.LinkLabel7)
        Me.fpnlTempFile.Controls.Add(Me.LinkLabel8)
        Me.fpnlTempFile.Location = New System.Drawing.Point(79, 8)
        Me.fpnlTempFile.Name = "fpnlTempFile"
        Me.fpnlTempFile.Size = New System.Drawing.Size(287, 22)
        Me.fpnlTempFile.TabIndex = 0
        '
        'lbltmpFile1
        '
        Me.lbltmpFile1.AutoSize = True
        Me.lbltmpFile1.Location = New System.Drawing.Point(0, 0)
        Me.lbltmpFile1.Margin = New System.Windows.Forms.Padding(0)
        Me.lbltmpFile1.Name = "lbltmpFile1"
        Me.lbltmpFile1.Size = New System.Drawing.Size(37, 17)
        Me.lbltmpFile1.TabIndex = 126
        Me.lbltmpFile1.TabStop = True
        Me.lbltmpFile1.Text = "link1"
        Me.lbltmpFile1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.lbltmpFile1.Visible = False
        '
        'lbltmpFile1_Clear
        '
        Me.lbltmpFile1_Clear.AutoSize = True
        Me.lbltmpFile1_Clear.Cursor = System.Windows.Forms.Cursors.Hand
        Me.fpnlTempFile.SetFlowBreak(Me.lbltmpFile1_Clear, True)
        Me.lbltmpFile1_Clear.Font = New System.Drawing.Font("Meiryo UI", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.lbltmpFile1_Clear.LinkBehavior = System.Windows.Forms.LinkBehavior.NeverUnderline
        Me.lbltmpFile1_Clear.LinkColor = System.Drawing.Color.Red
        Me.lbltmpFile1_Clear.Location = New System.Drawing.Point(37, 0)
        Me.lbltmpFile1_Clear.Margin = New System.Windows.Forms.Padding(0)
        Me.lbltmpFile1_Clear.Name = "lbltmpFile1_Clear"
        Me.lbltmpFile1_Clear.Size = New System.Drawing.Size(19, 17)
        Me.lbltmpFile1_Clear.TabIndex = 128
        Me.lbltmpFile1_Clear.TabStop = True
        Me.lbltmpFile1_Clear.Text = "×"
        Me.lbltmpFile1_Clear.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.lbltmpFile1_Clear.Visible = False
        '
        'LinkLabel1
        '
        Me.LinkLabel1.AutoSize = True
        Me.LinkLabel1.Location = New System.Drawing.Point(0, 17)
        Me.LinkLabel1.Margin = New System.Windows.Forms.Padding(0)
        Me.LinkLabel1.Name = "LinkLabel1"
        Me.LinkLabel1.Size = New System.Drawing.Size(37, 17)
        Me.LinkLabel1.TabIndex = 129
        Me.LinkLabel1.TabStop = True
        Me.LinkLabel1.Text = "link2"
        Me.LinkLabel1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.LinkLabel1.Visible = False
        '
        'LinkLabel2
        '
        Me.LinkLabel2.AutoSize = True
        Me.LinkLabel2.Cursor = System.Windows.Forms.Cursors.Hand
        Me.fpnlTempFile.SetFlowBreak(Me.LinkLabel2, True)
        Me.LinkLabel2.Font = New System.Drawing.Font("Meiryo UI", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.LinkLabel2.LinkBehavior = System.Windows.Forms.LinkBehavior.NeverUnderline
        Me.LinkLabel2.LinkColor = System.Drawing.Color.Red
        Me.LinkLabel2.Location = New System.Drawing.Point(37, 17)
        Me.LinkLabel2.Margin = New System.Windows.Forms.Padding(0)
        Me.LinkLabel2.Name = "LinkLabel2"
        Me.LinkLabel2.Size = New System.Drawing.Size(19, 17)
        Me.LinkLabel2.TabIndex = 130
        Me.LinkLabel2.TabStop = True
        Me.LinkLabel2.Text = "×"
        Me.LinkLabel2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.LinkLabel2.Visible = False
        '
        'LinkLabel3
        '
        Me.LinkLabel3.AutoSize = True
        Me.LinkLabel3.Location = New System.Drawing.Point(0, 34)
        Me.LinkLabel3.Margin = New System.Windows.Forms.Padding(0)
        Me.LinkLabel3.Name = "LinkLabel3"
        Me.LinkLabel3.Size = New System.Drawing.Size(37, 17)
        Me.LinkLabel3.TabIndex = 129
        Me.LinkLabel3.TabStop = True
        Me.LinkLabel3.Text = "link3"
        Me.LinkLabel3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.LinkLabel3.Visible = False
        '
        'LinkLabel4
        '
        Me.LinkLabel4.AutoSize = True
        Me.LinkLabel4.Cursor = System.Windows.Forms.Cursors.Hand
        Me.fpnlTempFile.SetFlowBreak(Me.LinkLabel4, True)
        Me.LinkLabel4.Font = New System.Drawing.Font("Meiryo UI", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.LinkLabel4.LinkBehavior = System.Windows.Forms.LinkBehavior.NeverUnderline
        Me.LinkLabel4.LinkColor = System.Drawing.Color.Red
        Me.LinkLabel4.Location = New System.Drawing.Point(37, 34)
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
        Me.LinkLabel5.Location = New System.Drawing.Point(0, 51)
        Me.LinkLabel5.Margin = New System.Windows.Forms.Padding(0)
        Me.LinkLabel5.Name = "LinkLabel5"
        Me.LinkLabel5.Size = New System.Drawing.Size(37, 17)
        Me.LinkLabel5.TabIndex = 129
        Me.LinkLabel5.TabStop = True
        Me.LinkLabel5.Text = "link4"
        Me.LinkLabel5.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.LinkLabel5.Visible = False
        '
        'LinkLabel6
        '
        Me.LinkLabel6.AutoSize = True
        Me.LinkLabel6.Cursor = System.Windows.Forms.Cursors.Hand
        Me.fpnlTempFile.SetFlowBreak(Me.LinkLabel6, True)
        Me.LinkLabel6.Font = New System.Drawing.Font("Meiryo UI", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.LinkLabel6.LinkBehavior = System.Windows.Forms.LinkBehavior.NeverUnderline
        Me.LinkLabel6.LinkColor = System.Drawing.Color.Red
        Me.LinkLabel6.Location = New System.Drawing.Point(37, 51)
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
        Me.LinkLabel7.Location = New System.Drawing.Point(0, 68)
        Me.LinkLabel7.Margin = New System.Windows.Forms.Padding(0)
        Me.LinkLabel7.Name = "LinkLabel7"
        Me.LinkLabel7.Size = New System.Drawing.Size(37, 17)
        Me.LinkLabel7.TabIndex = 129
        Me.LinkLabel7.TabStop = True
        Me.LinkLabel7.Text = "link5"
        Me.LinkLabel7.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.LinkLabel7.Visible = False
        '
        'LinkLabel8
        '
        Me.LinkLabel8.AutoSize = True
        Me.LinkLabel8.Cursor = System.Windows.Forms.Cursors.Hand
        Me.fpnlTempFile.SetFlowBreak(Me.LinkLabel8, True)
        Me.LinkLabel8.Font = New System.Drawing.Font("Meiryo UI", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.LinkLabel8.LinkBehavior = System.Windows.Forms.LinkBehavior.NeverUnderline
        Me.LinkLabel8.LinkColor = System.Drawing.Color.Red
        Me.LinkLabel8.Location = New System.Drawing.Point(37, 68)
        Me.LinkLabel8.Margin = New System.Windows.Forms.Padding(0)
        Me.LinkLabel8.Name = "LinkLabel8"
        Me.LinkLabel8.Size = New System.Drawing.Size(19, 17)
        Me.LinkLabel8.TabIndex = 130
        Me.LinkLabel8.TabStop = True
        Me.LinkLabel8.Text = "×"
        Me.LinkLabel8.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.LinkLabel8.Visible = False
        '
        'btnOpenTempFileDialog
        '
        Me.btnOpenTempFileDialog.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnOpenTempFileDialog.Image = Global.FMS.My.Resources.Resources._imgFolder_Open_16x16
        Me.btnOpenTempFileDialog.Location = New System.Drawing.Point(372, 7)
        Me.btnOpenTempFileDialog.Name = "btnOpenTempFileDialog"
        Me.btnOpenTempFileDialog.Size = New System.Drawing.Size(54, 24)
        Me.btnOpenTempFileDialog.TabIndex = 1
        Me.btnOpenTempFileDialog.UseVisualStyleBackColor = True
        '
        'Label19
        '
        Me.Label19.AutoSize = True
        Me.Label19.Font = New System.Drawing.Font("Meiryo UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label19.Location = New System.Drawing.Point(3, 12)
        Me.Label19.Margin = New System.Windows.Forms.Padding(3, 3, 3, 0)
        Me.Label19.Name = "Label19"
        Me.Label19.Size = New System.Drawing.Size(70, 15)
        Me.Label19.TabIndex = 85
        Me.Label19.Text = "添付ファイル:"
        Me.Label19.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'D004SYONINJKANRIBindingSource
        '
        Me.D004SYONINJKANRIBindingSource.DataSource = GetType(MODEL.D004_SYONIN_J_KANRI)
        '
        'FrmG0011
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.ClientSize = New System.Drawing.Size(1264, 712)
        Me.Controls.Add(Me.TabSTAGE)
        Me.Controls.Add(Me.gbxFilter)
        Me.Controls.Add(Me.picZoom)
        Me.HelpButton = True
        Me.MinimumSize = New System.Drawing.Size(1278, 750)
        Me.Name = "FrmG0011"
        Me.ShowStatusBar = True
        Me.Text = ""
        Me.Controls.SetChildIndex(Me.picZoom, 0)
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
        Me.Controls.SetChildIndex(Me.TabSTAGE, 0)
        CType(Me.ErrorProvider, System.ComponentModel.ISupportInitialize).EndInit()
        Me.gbxFilter.ResumeLayout(False)
        Me.tlpFilter.ResumeLayout(False)
        Me.tlpFilter.PerformLayout()
        CType(Me.numSU, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.D003NCRJBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.picZoom, System.ComponentModel.ISupportInitialize).EndInit()
        Me.TabSTAGE.ResumeLayout(False)
        Me.tabSTAGE01.ResumeLayout(False)
        Me.tabSTAGE01.PerformLayout()
        Me.tabSTAGE02.ResumeLayout(False)
        Me.tabSTAGE02.PerformLayout()
        Me.tabSTAGE03.ResumeLayout(False)
        Me.tabSTAGE03.PerformLayout()
        Me.tabSTAGE04.ResumeLayout(False)
        Me.tabSTAGE04.PerformLayout()
        Me.FlowLayoutPanel2.ResumeLayout(False)
        Me.FlowLayoutPanel2.PerformLayout()
        Me.tabSTAGE05.ResumeLayout(False)
        Me.tabSTAGE05.PerformLayout()
        Me.tabSTAGE06.ResumeLayout(False)
        Me.tabSTAGE06.PerformLayout()
        Me.tabSTAGE07.ResumeLayout(False)
        Me.tabSTAGE07.PerformLayout()
        Me.FlowLayoutPanel1.ResumeLayout(False)
        Me.FlowLayoutPanel1.PerformLayout()
        Me.tabSTAGE08.ResumeLayout(False)
        Me.tabSTAGE08.PerformLayout()
        Me.tabST08_SUB.ResumeLayout(False)
        Me.tabSTAGE08_1.ResumeLayout(False)
        Me.tabSTAGE08_1.PerformLayout()
        Me.tabSTAGE08_2.ResumeLayout(False)
        Me.tabSTAGE08_2.PerformLayout()
        Me.tabSTAGE08_3.ResumeLayout(False)
        Me.tabSTAGE08_3.PerformLayout()
        Me.tabSTAGE08_4.ResumeLayout(False)
        Me.tabSTAGE08_4.PerformLayout()
        Me.tabSTAGE09.ResumeLayout(False)
        Me.tabSTAGE09.PerformLayout()
        Me.tabSTAGE10.ResumeLayout(False)
        Me.tabSTAGE10.PerformLayout()
        Me.tabSTAGE11.ResumeLayout(False)
        Me.tabSTAGE11.PerformLayout()
        Me.tlpST08.ResumeLayout(False)
        Me.tlpST08.PerformLayout()
        Me.tabSTAGE12.ResumeLayout(False)
        Me.tabSTAGE12.PerformLayout()
        Me.tabAttachment.ResumeLayout(False)
        Me.tabAttachment.PerformLayout()
        Me.SplitContainer1.Panel1.ResumeLayout(False)
        Me.SplitContainer1.Panel1.PerformLayout()
        Me.SplitContainer1.Panel2.ResumeLayout(False)
        Me.SplitContainer1.Panel2.PerformLayout()
        CType(Me.SplitContainer1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.SplitContainer1.ResumeLayout(False)
        Me.flpPict1Path.ResumeLayout(False)
        Me.flpPict1Path.PerformLayout()
        CType(Me.pnlPict1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.flpPict2Path.ResumeLayout(False)
        Me.flpPict2Path.PerformLayout()
        CType(Me.pnlPict2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.fpnlTempFile.ResumeLayout(False)
        Me.fpnlTempFile.PerformLayout()
        CType(Me.D004SYONINJKANRIBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents gbxFilter As GroupBox
    Friend WithEvents tlpFilter As TableLayoutPanel
    Friend WithEvents mtxHOKUKO_NO As MaskedTextBoxEx
    Friend WithEvents Label8 As Label
    Friend WithEvents Label4 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents Label1 As Label
    Friend WithEvents Label14 As Label
    Friend WithEvents Label6 As Label
    Friend WithEvents dtDraft As DateTextBoxEx
    Friend WithEvents cmbKISYU As ComboboxEx
    Friend WithEvents Label9 As Label
    Friend WithEvents Label11 As Label
    Friend WithEvents cmbBUHIN_BANGO As ComboboxEx
    Friend WithEvents btnSRCH_BUHIN As Button
    Friend WithEvents Label7 As Label
    Friend WithEvents mtxHINMEI As MaskedTextBoxEx
    Friend WithEvents Label10 As Label
    Friend WithEvents Label13 As Label
    Friend WithEvents Label12 As Label
    Friend WithEvents cmbFUTEKIGO_STATUS As ComboboxEx
    Friend WithEvents mtxGOUKI As MaskedTextBoxEx
    Friend WithEvents mtxFUTEKIGO_NAIYO As MaskedTextBoxEx
    Friend WithEvents mtxZUBAN_KIKAKU As MaskedTextBoxEx
    Friend WithEvents TabSTAGE As TabControl
    Friend WithEvents tabSTAGE01 As TabPage
    Friend WithEvents tabSTAGE02 As TabPage
    Friend WithEvents Label15 As Label
    Friend WithEvents txtST01_YOKYU_NAIYO As TextBoxEx
    Friend WithEvents lblSTAGE01 As Label
    Friend WithEvents tabSTAGE03 As TabPage
    Friend WithEvents tabSTAGE04 As TabPage
    Friend WithEvents tabSTAGE05 As TabPage
    Friend WithEvents tabSTAGE06 As TabPage
    Friend WithEvents tabSTAGE07 As TabPage
    Friend WithEvents tabSTAGE08 As TabPage
    Friend WithEvents tabSTAGE09 As TabPage
    Friend WithEvents tabSTAGE10 As TabPage
    Friend WithEvents tabSTAGE11 As TabPage
    Friend WithEvents tabSTAGE12 As TabPage
    Friend WithEvents tabAttachment As TabPage
    Friend WithEvents btnOpenTempFileDialog As Button
    Friend WithEvents Label19 As Label
    Friend WithEvents btnOpenPict2Dialog As Button
    Friend WithEvents Label25 As Label
    Friend WithEvents btnOpenPict1Dialog As Button
    Friend WithEvents Label24 As Label
    Friend WithEvents lblSTAGE02 As Label
    Friend WithEvents lblSTAGE03 As Label
    Friend WithEvents lblSTAGE04 As Label
    Friend WithEvents lbltxtST04_RIYU As Label
    Friend WithEvents txtST04_RIYU As TextBoxEx
    Friend WithEvents Label42 As Label
    Friend WithEvents cmbST04_ZIZENSINSA_HANTEI As ComboboxEx
    Friend WithEvents Label41 As Label
    Friend WithEvents Label17 As Label
    Friend WithEvents txtST01_KEKKA As TextBoxEx
    Friend WithEvents lblSTAGE05 As Label
    Friend WithEvents mtxST06_SAISIN_IINKAI_SIRYO_NO As MaskedTextBoxEx
    Friend WithEvents Label52 As Label
    Friend WithEvents cmbST06_SAISIN_IINKAI_HANTEI As ComboboxEx
    Friend WithEvents Label53 As Label
    Friend WithEvents lblSTAGE06 As Label
    Friend WithEvents dtST07_KOKYAKU_SAISYU_HANTEI As DateTextBoxEx
    Friend WithEvents dtST07_KOKYAKU_HANTEI_SIJI As DateTextBoxEx
    Friend WithEvents Label66 As Label
    Friend WithEvents cmbST07_KOKYAKU_HANTEI_SIJI As ComboboxEx
    Friend WithEvents Label65 As Label
    Friend WithEvents Label64 As Label
    Friend WithEvents cmbST07_KOKYAKU_SAISYU_HANTEI As ComboboxEx
    Friend WithEvents Label63 As Label
    Friend WithEvents mtxST07_ITAG_NO As MaskedTextBoxEx
    Friend WithEvents Label60 As Label
    Friend WithEvents cmbST07_SAISIN_TANTO As ComboboxEx
    Friend WithEvents Label61 As Label
    Friend WithEvents lblSTAGE07 As Label
    Friend WithEvents lblSTAGE08 As Label
    Friend WithEvents tabST08_SUB As TabControl
    Friend WithEvents tabSTAGE08_1 As TabPage
    Friend WithEvents tabSTAGE08_2 As TabPage
    Friend WithEvents tabSTAGE08_3 As TabPage
    Friend WithEvents tabSTAGE08_4 As TabPage
    Friend WithEvents cmbST02_DestTANTO As ComboboxEx
    Friend WithEvents mtxST02_NextStageName As MaskedTextBoxEx
    Friend WithEvents Label27 As Label
    Friend WithEvents Label28 As Label
    Friend WithEvents Label29 As Label
    Friend WithEvents txtST02_Comment As TextBoxEx
    Friend WithEvents Label30 As Label
    Friend WithEvents mtxST02_UPD_YMD As MaskedTextBoxEx
    Friend WithEvents cmbST03_DestTANTO As ComboboxEx
    Friend WithEvents mtxST03_NextStageName As MaskedTextBoxEx
    Friend WithEvents Label18 As Label
    Friend WithEvents Label31 As Label
    Friend WithEvents Label32 As Label
    Friend WithEvents txtST03_Comment As TextBoxEx
    Friend WithEvents Label33 As Label
    Friend WithEvents mtxST03_UPD_YMD As MaskedTextBoxEx
    Friend WithEvents cmbST04_DestTANTO As ComboboxEx
    Friend WithEvents mtxST04_NextStageName As MaskedTextBoxEx
    Friend WithEvents Label34 As Label
    Friend WithEvents Label36 As Label
    Friend WithEvents Label37 As Label
    Friend WithEvents txtST04_Comment As TextBoxEx
    Friend WithEvents Label38 As Label
    Friend WithEvents mtxST04_UPD_YMD As MaskedTextBoxEx
    Friend WithEvents cmbST05_DestTANTO As ComboboxEx
    Friend WithEvents mtxST05_NextStageName As MaskedTextBoxEx
    Friend WithEvents Label45 As Label
    Friend WithEvents Label46 As Label
    Friend WithEvents Label47 As Label
    Friend WithEvents txtST05_Comment As TextBoxEx
    Friend WithEvents Label48 As Label
    Friend WithEvents mtxST05_UPD_YMD As MaskedTextBoxEx
    Friend WithEvents cmbST06_DestTANTO As ComboboxEx
    Friend WithEvents mtxST06_NextStageName As MaskedTextBoxEx
    Friend WithEvents Label49 As Label
    Friend WithEvents Label50 As Label
    Friend WithEvents Label51 As Label
    Friend WithEvents txtST06_Comment As TextBoxEx
    Friend WithEvents Label55 As Label
    Friend WithEvents mtxST06_UPD_YMD As MaskedTextBoxEx
    Friend WithEvents cmbST07_DestTANTO As ComboboxEx
    Friend WithEvents mtxST07_NextStageName As MaskedTextBoxEx
    Friend WithEvents Label56 As Label
    Friend WithEvents Label57 As Label
    Friend WithEvents Label58 As Label
    Friend WithEvents txtST07_Comment As TextBoxEx
    Friend WithEvents Label59 As Label
    Friend WithEvents mtxST07_UPD_YMD As MaskedTextBoxEx
    Friend WithEvents cmbST08_DestTANTO As ComboboxEx
    Friend WithEvents mtxST08_NextStageName As MaskedTextBoxEx
    Friend WithEvents Label67 As Label
    Friend WithEvents Label68 As Label
    Friend WithEvents Label69 As Label
    Friend WithEvents txtST08_Comment As TextBoxEx
    Friend WithEvents Label70 As Label
    Friend WithEvents mtxST08_UPD_YMD As MaskedTextBoxEx
    Friend WithEvents btnST08_1_SRCH_TANTO As Button
    Friend WithEvents cmbST08_1_HAIKYAKU_TANTO As ComboboxEx
    Friend WithEvents Label74 As Label
    Friend WithEvents mtxST08_1_BIKO As MaskedTextBoxEx
    Friend WithEvents Label73 As Label
    Friend WithEvents cmbST08_1_HAIKYAKU_KB As ComboboxEx
    Friend WithEvents Label72 As Label
    Friend WithEvents Label71 As Label
    Friend WithEvents dtST08_1_HAIKYAKU_YMD As DateTextBoxEx
    Friend WithEvents btnST08_2_SRCH_TANTO_SEIGI As Button
    Friend WithEvents cmbST08_2_TANTO_SEIGI As ComboboxEx
    Friend WithEvents Label82 As Label
    Friend WithEvents btnST08_2_SRCH_TANTO_SEIZO As Button
    Friend WithEvents cmbST08_2_TANTO_SEIZO As ComboboxEx
    Friend WithEvents Label81 As Label
    Friend WithEvents dtST08_2_KENSA_YMD As DateTextBoxEx
    Friend WithEvents cmbST08_2_KENSA_KEKKA As ComboboxEx
    Friend WithEvents Label80 As Label
    Friend WithEvents mtxST08_2_DOC_NO As MaskedTextBoxEx
    Friend WithEvents btnST08_2_SRCH_TANTO_KENSA As Button
    Friend WithEvents cmbST08_2_TANTO_KENSA As ComboboxEx
    Friend WithEvents Label75 As Label
    Friend WithEvents Label76 As Label
    Friend WithEvents Label78 As Label
    Friend WithEvents Label79 As Label
    Friend WithEvents dtST08_2_WorkOutYMD As DateTextBoxEx
    Friend WithEvents btnST08_3_SRCH_TANTO_HENKYAKU As Button
    Friend WithEvents cmbST08_3_HENKYAKU_TANTO As ComboboxEx
    Friend WithEvents mtxST08_3_HENKYAKU_SAKI As MaskedTextBoxEx
    Friend WithEvents Label87 As Label
    Friend WithEvents Label88 As Label
    Friend WithEvents Label89 As Label
    Friend WithEvents dtST08_3_HENKYAKU_YMD As DateTextBoxEx
    Friend WithEvents Label83 As Label
    Friend WithEvents txtST08_3_BIKO As TextBoxEx
    Friend WithEvents Label84 As Label
    Friend WithEvents mtxST08_4_LOT As MaskedTextBoxEx
    Friend WithEvents Label85 As Label
    Friend WithEvents Label86 As Label
    Friend WithEvents Label90 As Label
    Friend WithEvents Label91 As Label
    Friend WithEvents cmbST09_DestTANTO As ComboboxEx
    Friend WithEvents mtxST09_NextStageName As MaskedTextBoxEx
    Friend WithEvents Label92 As Label
    Friend WithEvents Label93 As Label
    Friend WithEvents Label94 As Label
    Friend WithEvents txtST09_Comment As TextBoxEx
    Friend WithEvents Label95 As Label
    Friend WithEvents mtxST09_UPD_YMD As MaskedTextBoxEx
    Friend WithEvents lblSTAGE09 As Label
    Friend WithEvents cmbST10_DestTANTO As ComboboxEx
    Friend WithEvents mtxST10_NextStageName As MaskedTextBoxEx
    Friend WithEvents Label97 As Label
    Friend WithEvents Label98 As Label
    Friend WithEvents Label99 As Label
    Friend WithEvents txtST10_Comment As TextBoxEx
    Friend WithEvents Label100 As Label
    Friend WithEvents mtxST10_UPD_YMD As MaskedTextBoxEx
    Friend WithEvents lblSTAGE10 As Label
    Friend WithEvents lblSTAGE11 As Label
    Friend WithEvents cmbST11_DestTANTO As ComboboxEx
    Friend WithEvents mtxST11_NextStageName As MaskedTextBoxEx
    Friend WithEvents Label103 As Label
    Friend WithEvents Label104 As Label
    Friend WithEvents txtST11_Comment As TextBoxEx
    Friend WithEvents mtxST11_UPD_YMD As MaskedTextBoxEx
    Friend WithEvents tlpST08 As TableLayoutPanel
    Friend WithEvents mtxST11_E_Comment As MaskedTextBoxEx
    Friend WithEvents mtxST11_D_Comment As MaskedTextBoxEx
    Friend WithEvents Label125 As Label
    Friend WithEvents Label126 As Label
    Friend WithEvents Label127 As Label
    Friend WithEvents Label128 As Label
    Friend WithEvents Label129 As Label
    Friend WithEvents Label130 As Label
    Friend WithEvents Label131 As Label
    Friend WithEvents Label132 As Label
    Friend WithEvents Label133 As Label
    Friend WithEvents Label134 As Label
    Friend WithEvents Label135 As Label
    Friend WithEvents Label136 As Label
    Friend WithEvents Label137 As Label
    Friend WithEvents Label138 As Label
    Friend WithEvents Label122 As Label
    Friend WithEvents lblSTAGE12 As Label
    Friend WithEvents cmbST01_DestTANTO As ComboboxEx
    Friend WithEvents mtxST01_NextStageName As MaskedTextBoxEx
    Friend WithEvents Label123 As Label
    Friend WithEvents Label124 As Label
    Friend WithEvents Label139 As Label
    Friend WithEvents mtxST01_UPD_YMD As MaskedTextBoxEx
    Friend WithEvents lblST01_Modoshi_Riyu As Label
    Friend WithEvents lblST02_Modoshi_Riyu As Label
    Friend WithEvents lblST03_Modoshi_Riyu As Label
    Friend WithEvents lblST04_Modoshi_Riyu As Label
    Friend WithEvents lblST05_Modoshi_Riyu As Label
    Friend WithEvents lblST06_Modoshi_Riyu As Label
    Friend WithEvents lblST07_Modoshi_Riyu As Label
    Friend WithEvents lblST08_Modoshi_Riyu As Label
    Friend WithEvents lblST09_Modoshi_Riyu As Label
    Friend WithEvents lblST10_Modoshi_Riyu As Label
    Friend WithEvents lblST11_Riyu As Label
    Friend WithEvents rbtnST07_No As RadioButton
    Friend WithEvents rbtnST07_Yes As RadioButton
    Friend WithEvents Label141 As Label
    Friend WithEvents FlowLayoutPanel1 As FlowLayoutPanel
    Friend WithEvents mtxST08_4_GOUKI As MaskedTextBoxEx
    Friend WithEvents dtST08_4_TENYO_YMD As DateTextBoxEx
    Friend WithEvents rbtnST11_E2_F As RadioButton
    Friend WithEvents rbtnST11_E2_T As RadioButton
    Friend WithEvents rbtnST11_E1_F As RadioButton
    Friend WithEvents rbtnST11_E1_T As RadioButton
    Friend WithEvents rbtnST11_D2_F As RadioButton
    Friend WithEvents rbtnST11_D2_T As RadioButton
    Friend WithEvents rbtnST11_D1_F As RadioButton
    Friend WithEvents rbtnST11_D1_T As RadioButton
    Friend WithEvents rbtnST11_C1_F As RadioButton
    Friend WithEvents rbtnST11_C1_T As RadioButton
    Friend WithEvents rbtnST11_B1_F As RadioButton
    Friend WithEvents rbtnST11_B1_T As RadioButton
    Friend WithEvents rbtnST11_A1_F As RadioButton
    Friend WithEvents rbtnST11_A1_T As RadioButton
    Friend WithEvents Label16 As Label
    Friend WithEvents cmbBUMON As ComboboxEx
    Friend WithEvents chkSAIHATU As CheckBox
    Friend WithEvents lblSYANAI_CD As Label
    Friend WithEvents cmbFUTEKIGO_KB As ComboboxEx
    Friend WithEvents Label5 As Label
    Friend WithEvents cmbFUTEKIGO_S_KB As ComboboxEx
    Friend WithEvents Label21 As Label
    Friend WithEvents Label20 As Label
    Friend WithEvents numSU As NumericUpDown
    Friend WithEvents FlowLayoutPanel2 As FlowLayoutPanel
    Friend WithEvents rbtnST04_ZESEI_YES As RadioButton
    Friend WithEvents rbtnST04_ZESEI_NO As RadioButton
    Friend WithEvents pnlPict2 As PictureBox
    Friend WithEvents pnlPict1 As PictureBox
    Friend WithEvents picZoom As PictureBox
    Friend WithEvents fpnlTempFile As FlowLayoutPanel
    Friend WithEvents lbltmpFile1 As LinkLabel
    Friend WithEvents lbltmpFile1_Clear As LinkLabel
    Friend WithEvents LinkLabel1 As LinkLabel
    Friend WithEvents LinkLabel2 As LinkLabel
    Friend WithEvents LinkLabel3 As LinkLabel
    Friend WithEvents LinkLabel4 As LinkLabel
    Friend WithEvents LinkLabel5 As LinkLabel
    Friend WithEvents LinkLabel6 As LinkLabel
    Friend WithEvents LinkLabel7 As LinkLabel
    Friend WithEvents LinkLabel8 As LinkLabel
    Friend WithEvents D003NCRJBindingSource As BindingSource
    Friend WithEvents chkClosed As CheckBox
    Friend WithEvents cmbAddTanto As ComboboxEx
    Friend WithEvents chkST04_ZESEI_SYOCHI_YOHI_KB As CheckBox
    Friend WithEvents chkST07_SAIKAKO_SIJI_FLG As CheckBox
    Friend WithEvents cmbST08_4_KISYU As ComboboxEx
    Friend WithEvents cmbST08_4_BUHIN_BANGO As ComboboxEx
    Friend WithEvents chkST11_A1 As CheckBox
    Friend WithEvents chkST11_E2 As CheckBox
    Friend WithEvents chkST11_D1 As CheckBox
    Friend WithEvents chkST11_D2 As CheckBox
    Friend WithEvents chkST11_E1 As CheckBox
    Friend WithEvents chkST11_C1 As CheckBox
    Friend WithEvents chkST11_B1 As CheckBox
    Friend WithEvents lblPict1Path As LinkLabel
    Friend WithEvents lblPict1Path_Clear As LinkLabel
    Friend WithEvents lblPict2Path As LinkLabel
    Friend WithEvents lblPict2Path_Clear As LinkLabel
    Friend WithEvents SplitContainer1 As SplitContainer
    Friend WithEvents D004SYONINJKANRIBindingSource As BindingSource
    Friend WithEvents flpPict1Path As Panel
    Friend WithEvents flpPict2Path As Panel
    Friend WithEvents cmbSYANAI_CD As ComboboxEx
End Class
