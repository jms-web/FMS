<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class FrmG0010
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmG0010))
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.tlpFilter = New System.Windows.Forms.TableLayoutPanel()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.cmbBUMON = New JMS_COMMON.ComboboxEx()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.cmbTANTO = New JMS_COMMON.ComboboxEx()
        Me.btnClearSrchFilter = New System.Windows.Forms.Button()
        Me.CheckBox3 = New System.Windows.Forms.CheckBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.dtExecFrom = New JMS_COMMON.DateTextBoxEx()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.dtExecTo = New JMS_COMMON.DateTextBoxEx()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.mtxHOKUKO_NO = New JMS_COMMON.MaskedTextBoxEx()
        Me.Label14 = New System.Windows.Forms.Label()
        Me.ComboboxEx15 = New JMS_COMMON.ComboboxEx()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.cmbKISYU = New JMS_COMMON.ComboboxEx()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.MaskedTextBoxEx5 = New JMS_COMMON.MaskedTextBoxEx()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.MaskedTextBoxEx6 = New JMS_COMMON.MaskedTextBoxEx()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.cmbBUHIN_BANGO = New JMS_COMMON.ComboboxEx()
        Me.btnSECH_BUHIN = New System.Windows.Forms.Button()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.mtxHINMEI = New JMS_COMMON.MaskedTextBoxEx()
        Me.Label15 = New System.Windows.Forms.Label()
        Me.ComboboxEx6 = New JMS_COMMON.ComboboxEx()
        Me.Label16 = New System.Windows.Forms.Label()
        Me.ComboboxEx7 = New JMS_COMMON.ComboboxEx()
        Me.Label40 = New System.Windows.Forms.Label()
        Me.ComboboxEx16 = New JMS_COMMON.ComboboxEx()
        Me.chkClosedRowVisibled = New System.Windows.Forms.CheckBox()
        Me.cmbJIZEN_SINSA_HANTEI_KB = New JMS_COMMON.ComboboxEx()
        Me.cmbSAISIN_IINKAI_HANTEI_KB = New JMS_COMMON.ComboboxEx()
        Me.flxDATA = New C1.Win.C1FlexGrid.C1FlexGrid()
        Me.dgvDATA = New System.Windows.Forms.DataGridView()
        Me.TabControl1 = New System.Windows.Forms.TabControl()
        Me.TabPage1 = New System.Windows.Forms.TabPage()
        Me.TabPage2 = New System.Windows.Forms.TabPage()
        Me.TableLayoutPanel1 = New System.Windows.Forms.TableLayoutPanel()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.Label17 = New System.Windows.Forms.Label()
        Me.ComboboxEx4 = New JMS_COMMON.ComboboxEx()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.ComboboxEx3 = New JMS_COMMON.ComboboxEx()
        Me.Label20 = New System.Windows.Forms.Label()
        Me.ComboboxEx17 = New JMS_COMMON.ComboboxEx()
        Me.Label19 = New System.Windows.Forms.Label()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.ComboboxEx1 = New JMS_COMMON.ComboboxEx()
        Me.TabPage3 = New System.Windows.Forms.TabPage()
        Me.TableLayoutPanel2 = New System.Windows.Forms.TableLayoutPanel()
        Me.Label27 = New System.Windows.Forms.Label()
        Me.Label28 = New System.Windows.Forms.Label()
        Me.ComboboxEx8 = New JMS_COMMON.ComboboxEx()
        Me.ComboboxEx10 = New JMS_COMMON.ComboboxEx()
        Me.Label35 = New System.Windows.Forms.Label()
        Me.Label18 = New System.Windows.Forms.Label()
        Me.Label21 = New System.Windows.Forms.Label()
        Me.ComboboxEx2 = New JMS_COMMON.ComboboxEx()
        Me.MaskedTextBoxEx3 = New JMS_COMMON.MaskedTextBoxEx()
        Me.MaskedTextBoxEx1 = New JMS_COMMON.MaskedTextBoxEx()
        Me.Button2 = New System.Windows.Forms.Button()
        Me.Button4 = New System.Windows.Forms.Button()
        Me.Button3 = New System.Windows.Forms.Button()
        Me.Label30 = New System.Windows.Forms.Label()
        Me.ComboboxEx5 = New JMS_COMMON.ComboboxEx()
        CType(Me.ErrorProvider, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.tlpFilter.SuspendLayout()
        CType(Me.flxDATA, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dgvDATA, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.TabControl1.SuspendLayout()
        Me.TabPage1.SuspendLayout()
        Me.TabPage2.SuspendLayout()
        Me.TableLayoutPanel1.SuspendLayout()
        Me.TabPage3.SuspendLayout()
        Me.TableLayoutPanel2.SuspendLayout()
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
        Me.cmdFunc1.Image = Global.FMS.My.Resources.Resources._imgSearch32x32
        Me.cmdFunc1.Location = New System.Drawing.Point(9, 595)
        Me.cmdFunc1.Text = "����(F1)"
        '
        'cmdFunc2
        '
        Me.cmdFunc2.Image = Global.FMS.My.Resources.Resources._imgApplication_form_add32x32
        Me.cmdFunc2.Location = New System.Drawing.Point(216, 595)
        Me.cmdFunc2.Text = "�V�K�쐬(F2)"
        '
        'cmdFunc3
        '
        Me.cmdFunc3.Location = New System.Drawing.Point(423, 595)
        '
        'cmdFunc4
        '
        Me.cmdFunc4.Image = Global.FMS.My.Resources.Resources._imgApplication_form_edit32x32
        Me.cmdFunc4.Location = New System.Drawing.Point(630, 595)
        Me.cmdFunc4.Text = "�ύX�E���F(F4)"
        '
        'cmdFunc5
        '
        Me.cmdFunc5.Image = Global.FMS.My.Resources.Resources._imgStatusAnnotations_Blocked_32x32_MD
        Me.cmdFunc5.Location = New System.Drawing.Point(837, 595)
        Me.cmdFunc5.Text = "�폜(F5)"
        '
        'cmdFunc6
        '
        Me.cmdFunc6.Image = Global.FMS.My.Resources.Resources._imgRecovery32x32
        Me.cmdFunc6.Location = New System.Drawing.Point(1044, 595)
        Me.cmdFunc6.Text = "����(F6)"
        Me.cmdFunc6.Visible = False
        '
        'cmdFunc12
        '
        Me.cmdFunc12.Image = Global.FMS.My.Resources.Resources._imgLog_Out32x32
        Me.cmdFunc12.Location = New System.Drawing.Point(1044, 643)
        Me.cmdFunc12.Text = "����(F12)"
        '
        'cmdFunc11
        '
        Me.cmdFunc11.Image = Global.FMS.My.Resources.Resources._imgApplication_form32x32
        Me.cmdFunc11.Location = New System.Drawing.Point(837, 643)
        Me.cmdFunc11.Text = "����\��(F11)"
        '
        'cmdFunc10
        '
        Me.cmdFunc10.Image = Global.FMS.My.Resources.Resources._imgPrint32x32
        Me.cmdFunc10.Location = New System.Drawing.Point(630, 643)
        Me.cmdFunc10.Text = "���(F10)"
        '
        'cmdFunc7
        '
        Me.cmdFunc7.Image = Global.FMS.My.Resources.Resources._imgStatusAnnotations_Complete_and_ok_32x32
        Me.cmdFunc7.Location = New System.Drawing.Point(9, 643)
        Me.cmdFunc7.Text = "�S�I��(F7)"
        '
        'cmdFunc9
        '
        Me.cmdFunc9.Location = New System.Drawing.Point(423, 643)
        Me.cmdFunc9.Text = "���[�����M(F9)"
        '
        'cmdFunc8
        '
        Me.cmdFunc8.Image = Global.FMS.My.Resources.Resources._imgStatusAnnotations_Complete_and_ok_mono32x32
        Me.cmdFunc8.Location = New System.Drawing.Point(216, 643)
        Me.cmdFunc8.Text = "�S�I������(F8)"
        '
        'lblTytle
        '
        Me.lblTytle.Font = New System.Drawing.Font("Meiryo UI", 24.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTytle.ForeColor = System.Drawing.SystemColors.ControlText
        Me.lblTytle.Size = New System.Drawing.Size(1233, 45)
        Me.lblTytle.Text = "�s�K���������"
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
        Me.tlpFilter.Controls.Add(Me.Label1, 0, 0)
        Me.tlpFilter.Controls.Add(Me.cmbBUMON, 8, 0)
        Me.tlpFilter.Controls.Add(Me.Label6, 0, 3)
        Me.tlpFilter.Controls.Add(Me.cmbTANTO, 8, 3)
        Me.tlpFilter.Controls.Add(Me.btnClearSrchFilter, 57, 4)
        Me.tlpFilter.Controls.Add(Me.CheckBox3, 50, 5)
        Me.tlpFilter.Controls.Add(Me.Label5, 15, 3)
        Me.tlpFilter.Controls.Add(Me.dtExecFrom, 23, 3)
        Me.tlpFilter.Controls.Add(Me.Label7, 28, 3)
        Me.tlpFilter.Controls.Add(Me.dtExecTo, 29, 3)
        Me.tlpFilter.Controls.Add(Me.Label8, 15, 0)
        Me.tlpFilter.Controls.Add(Me.mtxHOKUKO_NO, 23, 0)
        Me.tlpFilter.Controls.Add(Me.Label14, 34, 0)
        Me.tlpFilter.Controls.Add(Me.ComboboxEx15, 42, 0)
        Me.tlpFilter.Controls.Add(Me.Label9, 0, 1)
        Me.tlpFilter.Controls.Add(Me.cmbKISYU, 8, 1)
        Me.tlpFilter.Controls.Add(Me.Label3, 0, 2)
        Me.tlpFilter.Controls.Add(Me.MaskedTextBoxEx5, 8, 2)
        Me.tlpFilter.Controls.Add(Me.Label4, 15, 1)
        Me.tlpFilter.Controls.Add(Me.MaskedTextBoxEx6, 23, 1)
        Me.tlpFilter.Controls.Add(Me.Label11, 15, 2)
        Me.tlpFilter.Controls.Add(Me.cmbBUHIN_BANGO, 23, 2)
        Me.tlpFilter.Controls.Add(Me.btnSECH_BUHIN, 31, 2)
        Me.tlpFilter.Controls.Add(Me.Label2, 34, 2)
        Me.tlpFilter.Controls.Add(Me.mtxHINMEI, 42, 2)
        Me.tlpFilter.Controls.Add(Me.Label15, 0, 4)
        Me.tlpFilter.Controls.Add(Me.ComboboxEx6, 8, 4)
        Me.tlpFilter.Controls.Add(Me.Label16, 15, 4)
        Me.tlpFilter.Controls.Add(Me.ComboboxEx7, 23, 4)
        Me.tlpFilter.Controls.Add(Me.Label40, 0, 5)
        Me.tlpFilter.Controls.Add(Me.ComboboxEx16, 8, 5)
        Me.tlpFilter.Controls.Add(Me.chkClosedRowVisibled, 43, 5)
        Me.tlpFilter.Dock = System.Windows.Forms.DockStyle.Fill
        Me.tlpFilter.Location = New System.Drawing.Point(3, 3)
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
        Me.tlpFilter.Size = New System.Drawing.Size(1222, 187)
        Me.tlpFilter.TabIndex = 56
        '
        'Label1
        '
        Me.tlpFilter.SetColumnSpan(Me.Label1, 8)
        Me.Label1.Font = New System.Drawing.Font("Meiryo UI", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label1.Location = New System.Drawing.Point(3, 0)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(154, 30)
        Me.Label1.TabIndex = 101
        Me.Label1.Text = "*����:"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'cmbBUMON
        '
        Me.cmbBUMON.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cmbBUMON.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cmbBUMON.BackColor = System.Drawing.SystemColors.Window
        Me.tlpFilter.SetColumnSpan(Me.cmbBUMON, 5)
        Me.cmbBUMON.Cursor = System.Windows.Forms.Cursors.Default
        Me.cmbBUMON.Font = New System.Drawing.Font("Meiryo UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.cmbBUMON.ForeColor = System.Drawing.SystemColors.ControlText
        Me.cmbBUMON.FormattingEnabled = True
        Me.cmbBUMON.GotFocusedColor = System.Drawing.Color.FromArgb(CType(CType(190, Byte), Integer), CType(CType(180, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.cmbBUMON.ImeMode = System.Windows.Forms.ImeMode.[On]
        Me.cmbBUMON.Location = New System.Drawing.Point(163, 3)
        Me.cmbBUMON.Name = "cmbBUMON"
        Me.cmbBUMON.Selected = False
        Me.cmbBUMON.Size = New System.Drawing.Size(94, 25)
        Me.cmbBUMON.TabIndex = 102
        Me.cmbBUMON.Text = "(�I��)"
        '
        'Label6
        '
        Me.tlpFilter.SetColumnSpan(Me.Label6, 8)
        Me.Label6.Font = New System.Drawing.Font("Meiryo UI", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label6.Location = New System.Drawing.Point(3, 90)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(154, 30)
        Me.Label6.TabIndex = 67
        Me.Label6.Text = "�����u�S����:"
        Me.Label6.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'cmbTANTO
        '
        Me.cmbTANTO.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cmbTANTO.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cmbTANTO.BackColor = System.Drawing.SystemColors.Window
        Me.tlpFilter.SetColumnSpan(Me.cmbTANTO, 7)
        Me.cmbTANTO.Cursor = System.Windows.Forms.Cursors.Default
        Me.cmbTANTO.Font = New System.Drawing.Font("Meiryo UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.cmbTANTO.ForeColor = System.Drawing.SystemColors.ControlText
        Me.cmbTANTO.FormattingEnabled = True
        Me.cmbTANTO.GotFocusedColor = System.Drawing.Color.FromArgb(CType(CType(190, Byte), Integer), CType(CType(180, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.cmbTANTO.ImeMode = System.Windows.Forms.ImeMode.[On]
        Me.cmbTANTO.Location = New System.Drawing.Point(163, 93)
        Me.cmbTANTO.Name = "cmbTANTO"
        Me.cmbTANTO.Selected = False
        Me.cmbTANTO.Size = New System.Drawing.Size(134, 25)
        Me.cmbTANTO.TabIndex = 70
        Me.cmbTANTO.Text = "(�I��)"
        '
        'btnClearSrchFilter
        '
        Me.tlpFilter.SetColumnSpan(Me.btnClearSrchFilter, 5)
        Me.btnClearSrchFilter.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnClearSrchFilter.Location = New System.Drawing.Point(1143, 123)
        Me.btnClearSrchFilter.Name = "btnClearSrchFilter"
        Me.tlpFilter.SetRowSpan(Me.btnClearSrchFilter, 2)
        Me.btnClearSrchFilter.Size = New System.Drawing.Size(74, 54)
        Me.btnClearSrchFilter.TabIndex = 100
        Me.btnClearSrchFilter.Text = "�����N���A"
        Me.btnClearSrchFilter.UseVisualStyleBackColor = True
        '
        'CheckBox3
        '
        Me.CheckBox3.AutoSize = True
        Me.tlpFilter.SetColumnSpan(Me.CheckBox3, 7)
        Me.CheckBox3.Cursor = System.Windows.Forms.Cursors.Hand
        Me.CheckBox3.Font = New System.Drawing.Font("Meiryo UI", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.CheckBox3.Location = New System.Drawing.Point(1003, 153)
        Me.CheckBox3.Name = "CheckBox3"
        Me.CheckBox3.Size = New System.Drawing.Size(90, 21)
        Me.CheckBox3.TabIndex = 110
        Me.CheckBox3.Text = "�ؗ���\��"
        Me.CheckBox3.UseVisualStyleBackColor = True
        '
        'Label5
        '
        Me.tlpFilter.SetColumnSpan(Me.Label5, 8)
        Me.Label5.Font = New System.Drawing.Font("Meiryo UI", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label5.Location = New System.Drawing.Point(303, 90)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(154, 30)
        Me.Label5.TabIndex = 63
        Me.Label5.Text = "���������{��:"
        Me.Label5.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'dtExecFrom
        '
        Me.dtExecFrom.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.tlpFilter.SetColumnSpan(Me.dtExecFrom, 5)
        Me.dtExecFrom.GotFocusedColor = System.Drawing.Color.FromArgb(CType(CType(190, Byte), Integer), CType(CType(180, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.dtExecFrom.Location = New System.Drawing.Point(463, 93)
        Me.dtExecFrom.MaxDate = New Date(9998, 12, 31, 0, 0, 0, 0)
        Me.dtExecFrom.MinDate = New Date(1753, 1, 1, 0, 0, 0, 0)
        Me.dtExecFrom.MinimumSize = New System.Drawing.Size(98, 24)
        Me.dtExecFrom.Name = "dtExecFrom"
        Me.dtExecFrom.Size = New System.Drawing.Size(98, 24)
        Me.dtExecFrom.TabIndex = 65
        Me.dtExecFrom.Value = ""
        Me.dtExecFrom.ValueNonFormat = ""
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Font = New System.Drawing.Font("Meiryo UI", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label7.Location = New System.Drawing.Point(563, 90)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(14, 15)
        Me.Label7.TabIndex = 66
        Me.Label7.Text = "~"
        Me.Label7.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'dtExecTo
        '
        Me.dtExecTo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.tlpFilter.SetColumnSpan(Me.dtExecTo, 5)
        Me.dtExecTo.GotFocusedColor = System.Drawing.Color.FromArgb(CType(CType(190, Byte), Integer), CType(CType(180, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.dtExecTo.Location = New System.Drawing.Point(583, 93)
        Me.dtExecTo.MaxDate = New Date(9998, 12, 31, 0, 0, 0, 0)
        Me.dtExecTo.MinDate = New Date(1753, 1, 1, 0, 0, 0, 0)
        Me.dtExecTo.MinimumSize = New System.Drawing.Size(98, 24)
        Me.dtExecTo.Name = "dtExecTo"
        Me.dtExecTo.Size = New System.Drawing.Size(98, 24)
        Me.dtExecTo.TabIndex = 62
        Me.dtExecTo.Value = ""
        Me.dtExecTo.ValueNonFormat = ""
        '
        'Label8
        '
        Me.tlpFilter.SetColumnSpan(Me.Label8, 8)
        Me.Label8.Font = New System.Drawing.Font("Meiryo UI", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label8.Location = New System.Drawing.Point(303, 0)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(154, 30)
        Me.Label8.TabIndex = 69
        Me.Label8.Text = "�񍐏�No:"
        Me.Label8.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'mtxHOKUKO_NO
        '
        Me.mtxHOKUKO_NO.BackColor = System.Drawing.SystemColors.Window
        Me.tlpFilter.SetColumnSpan(Me.mtxHOKUKO_NO, 7)
        Me.mtxHOKUKO_NO.GotFocusedColor = System.Drawing.Color.FromArgb(CType(CType(190, Byte), Integer), CType(CType(180, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.mtxHOKUKO_NO.ImeMode = System.Windows.Forms.ImeMode.Disable
        Me.mtxHOKUKO_NO.InputRequired = False
        Me.mtxHOKUKO_NO.Location = New System.Drawing.Point(463, 3)
        Me.mtxHOKUKO_NO.Name = "mtxHOKUKO_NO"
        Me.mtxHOKUKO_NO.Size = New System.Drawing.Size(134, 24)
        Me.mtxHOKUKO_NO.TabIndex = 82
        Me.mtxHOKUKO_NO.WatermarkColor = System.Drawing.Color.Empty
        Me.mtxHOKUKO_NO.WatermarkText = Nothing
        '
        'Label14
        '
        Me.tlpFilter.SetColumnSpan(Me.Label14, 8)
        Me.Label14.Font = New System.Drawing.Font("Meiryo UI", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label14.Location = New System.Drawing.Point(683, 0)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(154, 30)
        Me.Label14.TabIndex = 108
        Me.Label14.Text = "�N����:"
        Me.Label14.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'ComboboxEx15
        '
        Me.ComboboxEx15.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.ComboboxEx15.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.ComboboxEx15.BackColor = System.Drawing.SystemColors.Window
        Me.tlpFilter.SetColumnSpan(Me.ComboboxEx15, 7)
        Me.ComboboxEx15.Cursor = System.Windows.Forms.Cursors.Default
        Me.ComboboxEx15.Font = New System.Drawing.Font("Meiryo UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.ComboboxEx15.ForeColor = System.Drawing.SystemColors.ControlText
        Me.ComboboxEx15.FormattingEnabled = True
        Me.ComboboxEx15.GotFocusedColor = System.Drawing.Color.FromArgb(CType(CType(190, Byte), Integer), CType(CType(180, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.ComboboxEx15.ImeMode = System.Windows.Forms.ImeMode.[On]
        Me.ComboboxEx15.Location = New System.Drawing.Point(843, 3)
        Me.ComboboxEx15.Name = "ComboboxEx15"
        Me.ComboboxEx15.Selected = False
        Me.ComboboxEx15.Size = New System.Drawing.Size(134, 25)
        Me.ComboboxEx15.TabIndex = 109
        Me.ComboboxEx15.Text = "(�I��)"
        '
        'Label9
        '
        Me.tlpFilter.SetColumnSpan(Me.Label9, 8)
        Me.Label9.Font = New System.Drawing.Font("Meiryo UI", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label9.Location = New System.Drawing.Point(3, 30)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(154, 30)
        Me.Label9.TabIndex = 73
        Me.Label9.Text = "�@��:"
        Me.Label9.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'cmbKISYU
        '
        Me.cmbKISYU.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cmbKISYU.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cmbKISYU.BackColor = System.Drawing.SystemColors.Window
        Me.tlpFilter.SetColumnSpan(Me.cmbKISYU, 7)
        Me.cmbKISYU.Cursor = System.Windows.Forms.Cursors.Default
        Me.cmbKISYU.Font = New System.Drawing.Font("Meiryo UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.cmbKISYU.ForeColor = System.Drawing.SystemColors.ControlText
        Me.cmbKISYU.FormattingEnabled = True
        Me.cmbKISYU.GotFocusedColor = System.Drawing.Color.FromArgb(CType(CType(190, Byte), Integer), CType(CType(180, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.cmbKISYU.ImeMode = System.Windows.Forms.ImeMode.[On]
        Me.cmbKISYU.Location = New System.Drawing.Point(163, 33)
        Me.cmbKISYU.Name = "cmbKISYU"
        Me.cmbKISYU.Selected = False
        Me.cmbKISYU.Size = New System.Drawing.Size(134, 25)
        Me.cmbKISYU.TabIndex = 78
        Me.cmbKISYU.Text = "(�I��)"
        '
        'Label3
        '
        Me.tlpFilter.SetColumnSpan(Me.Label3, 8)
        Me.Label3.Font = New System.Drawing.Font("Meiryo UI", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label3.Location = New System.Drawing.Point(3, 60)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(154, 30)
        Me.Label3.TabIndex = 105
        Me.Label3.Text = "�Г��R�[�h:"
        Me.Label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'MaskedTextBoxEx5
        '
        Me.MaskedTextBoxEx5.BackColor = System.Drawing.SystemColors.Window
        Me.tlpFilter.SetColumnSpan(Me.MaskedTextBoxEx5, 7)
        Me.MaskedTextBoxEx5.GotFocusedColor = System.Drawing.Color.FromArgb(CType(CType(190, Byte), Integer), CType(CType(180, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.MaskedTextBoxEx5.ImeMode = System.Windows.Forms.ImeMode.Disable
        Me.MaskedTextBoxEx5.InputRequired = False
        Me.MaskedTextBoxEx5.Location = New System.Drawing.Point(163, 63)
        Me.MaskedTextBoxEx5.Name = "MaskedTextBoxEx5"
        Me.MaskedTextBoxEx5.Size = New System.Drawing.Size(134, 24)
        Me.MaskedTextBoxEx5.TabIndex = 104
        Me.MaskedTextBoxEx5.WatermarkColor = System.Drawing.Color.Empty
        Me.MaskedTextBoxEx5.WatermarkText = Nothing
        '
        'Label4
        '
        Me.tlpFilter.SetColumnSpan(Me.Label4, 8)
        Me.Label4.Font = New System.Drawing.Font("Meiryo UI", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label4.Location = New System.Drawing.Point(303, 30)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(154, 30)
        Me.Label4.TabIndex = 107
        Me.Label4.Text = "�����ԍ�(���@):"
        Me.Label4.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'MaskedTextBoxEx6
        '
        Me.MaskedTextBoxEx6.BackColor = System.Drawing.SystemColors.Window
        Me.tlpFilter.SetColumnSpan(Me.MaskedTextBoxEx6, 7)
        Me.MaskedTextBoxEx6.GotFocusedColor = System.Drawing.Color.FromArgb(CType(CType(190, Byte), Integer), CType(CType(180, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.MaskedTextBoxEx6.ImeMode = System.Windows.Forms.ImeMode.Disable
        Me.MaskedTextBoxEx6.InputRequired = False
        Me.MaskedTextBoxEx6.Location = New System.Drawing.Point(463, 33)
        Me.MaskedTextBoxEx6.Name = "MaskedTextBoxEx6"
        Me.MaskedTextBoxEx6.Size = New System.Drawing.Size(134, 24)
        Me.MaskedTextBoxEx6.TabIndex = 106
        Me.MaskedTextBoxEx6.WatermarkColor = System.Drawing.Color.Empty
        Me.MaskedTextBoxEx6.WatermarkText = Nothing
        '
        'Label11
        '
        Me.tlpFilter.SetColumnSpan(Me.Label11, 8)
        Me.Label11.Font = New System.Drawing.Font("Meiryo UI", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label11.Location = New System.Drawing.Point(303, 60)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(154, 30)
        Me.Label11.TabIndex = 75
        Me.Label11.Text = "���i�ԍ�:"
        Me.Label11.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'cmbBUHIN_BANGO
        '
        Me.cmbBUHIN_BANGO.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cmbBUHIN_BANGO.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cmbBUHIN_BANGO.BackColor = System.Drawing.SystemColors.Window
        Me.tlpFilter.SetColumnSpan(Me.cmbBUHIN_BANGO, 8)
        Me.cmbBUHIN_BANGO.Cursor = System.Windows.Forms.Cursors.Default
        Me.cmbBUHIN_BANGO.Font = New System.Drawing.Font("Meiryo UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.cmbBUHIN_BANGO.ForeColor = System.Drawing.SystemColors.ControlText
        Me.cmbBUHIN_BANGO.FormattingEnabled = True
        Me.cmbBUHIN_BANGO.GotFocusedColor = System.Drawing.Color.FromArgb(CType(CType(190, Byte), Integer), CType(CType(180, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.cmbBUHIN_BANGO.ImeMode = System.Windows.Forms.ImeMode.[On]
        Me.cmbBUHIN_BANGO.Location = New System.Drawing.Point(463, 63)
        Me.cmbBUHIN_BANGO.Name = "cmbBUHIN_BANGO"
        Me.cmbBUHIN_BANGO.Selected = False
        Me.cmbBUHIN_BANGO.Size = New System.Drawing.Size(154, 25)
        Me.cmbBUHIN_BANGO.TabIndex = 71
        Me.cmbBUHIN_BANGO.Text = "(�I��)"
        '
        'btnSECH_BUHIN
        '
        Me.tlpFilter.SetColumnSpan(Me.btnSECH_BUHIN, 3)
        Me.btnSECH_BUHIN.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnSECH_BUHIN.Location = New System.Drawing.Point(623, 63)
        Me.btnSECH_BUHIN.Name = "btnSECH_BUHIN"
        Me.btnSECH_BUHIN.Size = New System.Drawing.Size(54, 24)
        Me.btnSECH_BUHIN.TabIndex = 99
        Me.btnSECH_BUHIN.Text = "����"
        Me.btnSECH_BUHIN.UseVisualStyleBackColor = True
        Me.btnSECH_BUHIN.Visible = False
        '
        'Label2
        '
        Me.tlpFilter.SetColumnSpan(Me.Label2, 8)
        Me.Label2.Font = New System.Drawing.Font("Meiryo UI", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label2.Location = New System.Drawing.Point(683, 60)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(154, 30)
        Me.Label2.TabIndex = 103
        Me.Label2.Text = "���i����:"
        Me.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'mtxHINMEI
        '
        Me.mtxHINMEI.BackColor = System.Drawing.SystemColors.Window
        Me.tlpFilter.SetColumnSpan(Me.mtxHINMEI, 12)
        Me.mtxHINMEI.GotFocusedColor = System.Drawing.Color.FromArgb(CType(CType(190, Byte), Integer), CType(CType(180, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.mtxHINMEI.ImeMode = System.Windows.Forms.ImeMode.Disable
        Me.mtxHINMEI.InputRequired = False
        Me.mtxHINMEI.Location = New System.Drawing.Point(843, 63)
        Me.mtxHINMEI.Name = "mtxHINMEI"
        Me.mtxHINMEI.Size = New System.Drawing.Size(234, 24)
        Me.mtxHINMEI.TabIndex = 82
        Me.mtxHINMEI.WatermarkColor = System.Drawing.Color.Empty
        Me.mtxHINMEI.WatermarkText = Nothing
        '
        'Label15
        '
        Me.tlpFilter.SetColumnSpan(Me.Label15, 8)
        Me.Label15.Font = New System.Drawing.Font("Meiryo UI", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label15.Location = New System.Drawing.Point(3, 120)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(154, 30)
        Me.Label15.TabIndex = 80
        Me.Label15.Text = "�s�K���敪:"
        Me.Label15.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'ComboboxEx6
        '
        Me.ComboboxEx6.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.ComboboxEx6.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.ComboboxEx6.BackColor = System.Drawing.SystemColors.Window
        Me.tlpFilter.SetColumnSpan(Me.ComboboxEx6, 7)
        Me.ComboboxEx6.Cursor = System.Windows.Forms.Cursors.Default
        Me.ComboboxEx6.Font = New System.Drawing.Font("Meiryo UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.ComboboxEx6.ForeColor = System.Drawing.SystemColors.ControlText
        Me.ComboboxEx6.FormattingEnabled = True
        Me.ComboboxEx6.GotFocusedColor = System.Drawing.Color.FromArgb(CType(CType(190, Byte), Integer), CType(CType(180, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.ComboboxEx6.ImeMode = System.Windows.Forms.ImeMode.[On]
        Me.ComboboxEx6.Location = New System.Drawing.Point(163, 123)
        Me.ComboboxEx6.Name = "ComboboxEx6"
        Me.ComboboxEx6.Selected = False
        Me.ComboboxEx6.Size = New System.Drawing.Size(134, 25)
        Me.ComboboxEx6.TabIndex = 111
        Me.ComboboxEx6.Text = "(�I��)"
        '
        'Label16
        '
        Me.tlpFilter.SetColumnSpan(Me.Label16, 8)
        Me.Label16.Font = New System.Drawing.Font("Meiryo UI", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label16.Location = New System.Drawing.Point(303, 120)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(154, 30)
        Me.Label16.TabIndex = 80
        Me.Label16.Text = "�s�K���ڍ׋敪:"
        Me.Label16.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'ComboboxEx7
        '
        Me.ComboboxEx7.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.ComboboxEx7.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.ComboboxEx7.BackColor = System.Drawing.SystemColors.Window
        Me.tlpFilter.SetColumnSpan(Me.ComboboxEx7, 7)
        Me.ComboboxEx7.Cursor = System.Windows.Forms.Cursors.Default
        Me.ComboboxEx7.Font = New System.Drawing.Font("Meiryo UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.ComboboxEx7.ForeColor = System.Drawing.SystemColors.ControlText
        Me.ComboboxEx7.FormattingEnabled = True
        Me.ComboboxEx7.GotFocusedColor = System.Drawing.Color.FromArgb(CType(CType(190, Byte), Integer), CType(CType(180, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.ComboboxEx7.ImeMode = System.Windows.Forms.ImeMode.[On]
        Me.ComboboxEx7.Location = New System.Drawing.Point(463, 123)
        Me.ComboboxEx7.Name = "ComboboxEx7"
        Me.ComboboxEx7.Selected = False
        Me.ComboboxEx7.Size = New System.Drawing.Size(134, 25)
        Me.ComboboxEx7.TabIndex = 112
        Me.ComboboxEx7.Text = "(�I��)"
        '
        'Label40
        '
        Me.tlpFilter.SetColumnSpan(Me.Label40, 8)
        Me.Label40.Font = New System.Drawing.Font("Meiryo UI", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label40.Location = New System.Drawing.Point(3, 150)
        Me.Label40.Name = "Label40"
        Me.Label40.Size = New System.Drawing.Size(154, 30)
        Me.Label40.TabIndex = 113
        Me.Label40.Text = "��ԋ敪:"
        Me.Label40.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'ComboboxEx16
        '
        Me.ComboboxEx16.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.ComboboxEx16.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.ComboboxEx16.BackColor = System.Drawing.SystemColors.Window
        Me.tlpFilter.SetColumnSpan(Me.ComboboxEx16, 7)
        Me.ComboboxEx16.Cursor = System.Windows.Forms.Cursors.Default
        Me.ComboboxEx16.Font = New System.Drawing.Font("Meiryo UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.ComboboxEx16.ForeColor = System.Drawing.SystemColors.ControlText
        Me.ComboboxEx16.FormattingEnabled = True
        Me.ComboboxEx16.GotFocusedColor = System.Drawing.Color.FromArgb(CType(CType(190, Byte), Integer), CType(CType(180, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.ComboboxEx16.ImeMode = System.Windows.Forms.ImeMode.[On]
        Me.ComboboxEx16.Location = New System.Drawing.Point(163, 153)
        Me.ComboboxEx16.Name = "ComboboxEx16"
        Me.ComboboxEx16.Selected = False
        Me.ComboboxEx16.Size = New System.Drawing.Size(134, 25)
        Me.ComboboxEx16.TabIndex = 114
        Me.ComboboxEx16.Text = "(�I��)"
        '
        'chkClosedRowVisibled
        '
        Me.chkClosedRowVisibled.AutoSize = True
        Me.tlpFilter.SetColumnSpan(Me.chkClosedRowVisibled, 7)
        Me.chkClosedRowVisibled.Cursor = System.Windows.Forms.Cursors.Hand
        Me.chkClosedRowVisibled.Font = New System.Drawing.Font("Meiryo UI", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.chkClosedRowVisibled.Location = New System.Drawing.Point(863, 153)
        Me.chkClosedRowVisibled.Name = "chkClosedRowVisibled"
        Me.chkClosedRowVisibled.Size = New System.Drawing.Size(121, 21)
        Me.chkClosedRowVisibled.TabIndex = 1
        Me.chkClosedRowVisibled.Text = "�N���[�Y�ς��\��"
        Me.chkClosedRowVisibled.UseVisualStyleBackColor = True
        '
        'cmbJIZEN_SINSA_HANTEI_KB
        '
        Me.cmbJIZEN_SINSA_HANTEI_KB.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cmbJIZEN_SINSA_HANTEI_KB.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cmbJIZEN_SINSA_HANTEI_KB.BackColor = System.Drawing.SystemColors.Window
        Me.TableLayoutPanel1.SetColumnSpan(Me.cmbJIZEN_SINSA_HANTEI_KB, 7)
        Me.cmbJIZEN_SINSA_HANTEI_KB.Cursor = System.Windows.Forms.Cursors.Default
        Me.cmbJIZEN_SINSA_HANTEI_KB.Font = New System.Drawing.Font("Meiryo UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.cmbJIZEN_SINSA_HANTEI_KB.ForeColor = System.Drawing.SystemColors.ControlText
        Me.cmbJIZEN_SINSA_HANTEI_KB.FormattingEnabled = True
        Me.cmbJIZEN_SINSA_HANTEI_KB.GotFocusedColor = System.Drawing.Color.FromArgb(CType(CType(190, Byte), Integer), CType(CType(180, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.cmbJIZEN_SINSA_HANTEI_KB.ImeMode = System.Windows.Forms.ImeMode.[On]
        Me.cmbJIZEN_SINSA_HANTEI_KB.Location = New System.Drawing.Point(163, 3)
        Me.cmbJIZEN_SINSA_HANTEI_KB.Name = "cmbJIZEN_SINSA_HANTEI_KB"
        Me.cmbJIZEN_SINSA_HANTEI_KB.Selected = False
        Me.cmbJIZEN_SINSA_HANTEI_KB.Size = New System.Drawing.Size(134, 25)
        Me.cmbJIZEN_SINSA_HANTEI_KB.TabIndex = 68
        Me.cmbJIZEN_SINSA_HANTEI_KB.Text = "(�I��)"
        '
        'cmbSAISIN_IINKAI_HANTEI_KB
        '
        Me.cmbSAISIN_IINKAI_HANTEI_KB.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cmbSAISIN_IINKAI_HANTEI_KB.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cmbSAISIN_IINKAI_HANTEI_KB.BackColor = System.Drawing.SystemColors.Window
        Me.TableLayoutPanel1.SetColumnSpan(Me.cmbSAISIN_IINKAI_HANTEI_KB, 7)
        Me.cmbSAISIN_IINKAI_HANTEI_KB.Cursor = System.Windows.Forms.Cursors.Default
        Me.cmbSAISIN_IINKAI_HANTEI_KB.Font = New System.Drawing.Font("Meiryo UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.cmbSAISIN_IINKAI_HANTEI_KB.ForeColor = System.Drawing.SystemColors.ControlText
        Me.cmbSAISIN_IINKAI_HANTEI_KB.FormattingEnabled = True
        Me.cmbSAISIN_IINKAI_HANTEI_KB.GotFocusedColor = System.Drawing.Color.FromArgb(CType(CType(190, Byte), Integer), CType(CType(180, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.cmbSAISIN_IINKAI_HANTEI_KB.ImeMode = System.Windows.Forms.ImeMode.[On]
        Me.cmbSAISIN_IINKAI_HANTEI_KB.Location = New System.Drawing.Point(163, 63)
        Me.cmbSAISIN_IINKAI_HANTEI_KB.Name = "cmbSAISIN_IINKAI_HANTEI_KB"
        Me.cmbSAISIN_IINKAI_HANTEI_KB.Selected = False
        Me.cmbSAISIN_IINKAI_HANTEI_KB.Size = New System.Drawing.Size(134, 25)
        Me.cmbSAISIN_IINKAI_HANTEI_KB.TabIndex = 77
        Me.cmbSAISIN_IINKAI_HANTEI_KB.Text = "(�I��)"
        '
        'flxDATA
        '
        Me.flxDATA.AllowDragging = C1.Win.C1FlexGrid.AllowDraggingEnum.None
        Me.flxDATA.AllowEditing = False
        Me.flxDATA.AllowFiltering = True
        Me.flxDATA.ColumnInfo = resources.GetString("flxDATA.ColumnInfo")
        Me.flxDATA.Location = New System.Drawing.Point(1213, 496)
        Me.flxDATA.Name = "flxDATA"
        Me.flxDATA.Rows.Count = 1
        Me.flxDATA.Rows.DefaultSize = 18
        Me.flxDATA.Size = New System.Drawing.Size(32, 30)
        Me.flxDATA.StyleInfo = resources.GetString("flxDATA.StyleInfo")
        Me.flxDATA.TabIndex = 61
        Me.flxDATA.Visible = False
        Me.flxDATA.VisualStyle = C1.Win.C1FlexGrid.VisualStyle.Office2010Silver
        '
        'dgvDATA
        '
        DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle1.Font = New System.Drawing.Font("MS UI Gothic", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        DataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgvDATA.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle1
        Me.dgvDATA.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle2.Font = New System.Drawing.Font("MS UI Gothic", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        DataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.dgvDATA.DefaultCellStyle = DataGridViewCellStyle2
        Me.dgvDATA.Location = New System.Drawing.Point(12, 289)
        Me.dgvDATA.Name = "dgvDATA"
        DataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle3.Font = New System.Drawing.Font("MS UI Gothic", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        DataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgvDATA.RowHeadersDefaultCellStyle = DataGridViewCellStyle3
        Me.dgvDATA.RowTemplate.Height = 21
        Me.dgvDATA.Size = New System.Drawing.Size(1233, 273)
        Me.dgvDATA.TabIndex = 62
        '
        'TabControl1
        '
        Me.TabControl1.Controls.Add(Me.TabPage1)
        Me.TabControl1.Controls.Add(Me.TabPage2)
        Me.TabControl1.Controls.Add(Me.TabPage3)
        Me.TabControl1.Font = New System.Drawing.Font("Meiryo UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.TabControl1.Location = New System.Drawing.Point(12, 60)
        Me.TabControl1.Name = "TabControl1"
        Me.TabControl1.SelectedIndex = 0
        Me.TabControl1.Size = New System.Drawing.Size(1236, 223)
        Me.TabControl1.TabIndex = 63
        '
        'TabPage1
        '
        Me.TabPage1.Controls.Add(Me.tlpFilter)
        Me.TabPage1.Location = New System.Drawing.Point(4, 26)
        Me.TabPage1.Name = "TabPage1"
        Me.TabPage1.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage1.Size = New System.Drawing.Size(1228, 193)
        Me.TabPage1.TabIndex = 0
        Me.TabPage1.Text = "���ʌ�������"
        Me.TabPage1.UseVisualStyleBackColor = True
        '
        'TabPage2
        '
        Me.TabPage2.Controls.Add(Me.TableLayoutPanel1)
        Me.TabPage2.Location = New System.Drawing.Point(4, 26)
        Me.TabPage2.Name = "TabPage2"
        Me.TabPage2.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage2.Size = New System.Drawing.Size(1228, 193)
        Me.TabPage2.TabIndex = 1
        Me.TabPage2.Text = "NCR��������"
        Me.TabPage2.UseVisualStyleBackColor = True
        '
        'TableLayoutPanel1
        '
        Me.TableLayoutPanel1.ColumnCount = 62
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20.0!))
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20.0!))
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20.0!))
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20.0!))
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20.0!))
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20.0!))
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20.0!))
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20.0!))
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20.0!))
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20.0!))
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20.0!))
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20.0!))
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20.0!))
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20.0!))
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20.0!))
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20.0!))
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20.0!))
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20.0!))
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20.0!))
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20.0!))
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20.0!))
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20.0!))
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20.0!))
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20.0!))
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20.0!))
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20.0!))
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20.0!))
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20.0!))
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20.0!))
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20.0!))
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20.0!))
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20.0!))
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20.0!))
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20.0!))
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20.0!))
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20.0!))
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20.0!))
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20.0!))
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20.0!))
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20.0!))
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20.0!))
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20.0!))
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20.0!))
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20.0!))
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20.0!))
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20.0!))
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20.0!))
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20.0!))
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20.0!))
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20.0!))
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20.0!))
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20.0!))
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20.0!))
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20.0!))
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20.0!))
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20.0!))
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20.0!))
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20.0!))
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20.0!))
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20.0!))
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20.0!))
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.TableLayoutPanel1.Controls.Add(Me.Label13, 0, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.cmbJIZEN_SINSA_HANTEI_KB, 8, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.Button1, 57, 4)
        Me.TableLayoutPanel1.Controls.Add(Me.Label17, 0, 5)
        Me.TableLayoutPanel1.Controls.Add(Me.ComboboxEx4, 8, 5)
        Me.TableLayoutPanel1.Controls.Add(Me.Label12, 0, 4)
        Me.TableLayoutPanel1.Controls.Add(Me.ComboboxEx3, 8, 4)
        Me.TableLayoutPanel1.Controls.Add(Me.Label20, 0, 3)
        Me.TableLayoutPanel1.Controls.Add(Me.ComboboxEx17, 8, 3)
        Me.TableLayoutPanel1.Controls.Add(Me.Label19, 0, 2)
        Me.TableLayoutPanel1.Controls.Add(Me.cmbSAISIN_IINKAI_HANTEI_KB, 8, 2)
        Me.TableLayoutPanel1.Controls.Add(Me.Label10, 0, 1)
        Me.TableLayoutPanel1.Controls.Add(Me.ComboboxEx1, 8, 1)
        Me.TableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TableLayoutPanel1.Location = New System.Drawing.Point(3, 3)
        Me.TableLayoutPanel1.Name = "TableLayoutPanel1"
        Me.TableLayoutPanel1.RowCount = 7
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel1.Size = New System.Drawing.Size(1222, 187)
        Me.TableLayoutPanel1.TabIndex = 64
        '
        'Label13
        '
        Me.TableLayoutPanel1.SetColumnSpan(Me.Label13, 8)
        Me.Label13.Font = New System.Drawing.Font("Meiryo UI", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label13.Location = New System.Drawing.Point(3, 0)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(154, 30)
        Me.Label13.TabIndex = 80
        Me.Label13.Text = "���O�R������敪:"
        Me.Label13.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Button1
        '
        Me.TableLayoutPanel1.SetColumnSpan(Me.Button1, 5)
        Me.Button1.Cursor = System.Windows.Forms.Cursors.Hand
        Me.Button1.Location = New System.Drawing.Point(1143, 123)
        Me.Button1.Name = "Button1"
        Me.TableLayoutPanel1.SetRowSpan(Me.Button1, 3)
        Me.Button1.Size = New System.Drawing.Size(74, 54)
        Me.Button1.TabIndex = 100
        Me.Button1.Text = "�����N���A"
        Me.Button1.UseVisualStyleBackColor = True
        '
        'Label17
        '
        Me.TableLayoutPanel1.SetColumnSpan(Me.Label17, 8)
        Me.Label17.Font = New System.Drawing.Font("Meiryo UI", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label17.Location = New System.Drawing.Point(3, 150)
        Me.Label17.Name = "Label17"
        Me.Label17.Size = New System.Drawing.Size(154, 30)
        Me.Label17.TabIndex = 69
        Me.Label17.Text = "��������:"
        Me.Label17.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'ComboboxEx4
        '
        Me.ComboboxEx4.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.ComboboxEx4.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.ComboboxEx4.BackColor = System.Drawing.SystemColors.Window
        Me.TableLayoutPanel1.SetColumnSpan(Me.ComboboxEx4, 5)
        Me.ComboboxEx4.Cursor = System.Windows.Forms.Cursors.Default
        Me.ComboboxEx4.Font = New System.Drawing.Font("Meiryo UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.ComboboxEx4.ForeColor = System.Drawing.SystemColors.ControlText
        Me.ComboboxEx4.FormattingEnabled = True
        Me.ComboboxEx4.GotFocusedColor = System.Drawing.Color.FromArgb(CType(CType(190, Byte), Integer), CType(CType(180, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.ComboboxEx4.ImeMode = System.Windows.Forms.ImeMode.[On]
        Me.ComboboxEx4.Location = New System.Drawing.Point(163, 153)
        Me.ComboboxEx4.Name = "ComboboxEx4"
        Me.ComboboxEx4.Selected = False
        Me.ComboboxEx4.Size = New System.Drawing.Size(94, 25)
        Me.ComboboxEx4.TabIndex = 78
        Me.ComboboxEx4.Text = "(�I��)"
        '
        'Label12
        '
        Me.TableLayoutPanel1.SetColumnSpan(Me.Label12, 8)
        Me.Label12.Font = New System.Drawing.Font("Meiryo UI", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label12.Location = New System.Drawing.Point(3, 120)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(154, 30)
        Me.Label12.TabIndex = 67
        Me.Label12.Text = "�ڋq�ŏI����敪:"
        Me.Label12.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'ComboboxEx3
        '
        Me.ComboboxEx3.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.ComboboxEx3.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.ComboboxEx3.BackColor = System.Drawing.SystemColors.Window
        Me.TableLayoutPanel1.SetColumnSpan(Me.ComboboxEx3, 7)
        Me.ComboboxEx3.Cursor = System.Windows.Forms.Cursors.Default
        Me.ComboboxEx3.Font = New System.Drawing.Font("Meiryo UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.ComboboxEx3.ForeColor = System.Drawing.SystemColors.ControlText
        Me.ComboboxEx3.FormattingEnabled = True
        Me.ComboboxEx3.GotFocusedColor = System.Drawing.Color.FromArgb(CType(CType(190, Byte), Integer), CType(CType(180, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.ComboboxEx3.ImeMode = System.Windows.Forms.ImeMode.[On]
        Me.ComboboxEx3.Location = New System.Drawing.Point(163, 123)
        Me.ComboboxEx3.Name = "ComboboxEx3"
        Me.ComboboxEx3.Selected = False
        Me.ComboboxEx3.Size = New System.Drawing.Size(134, 25)
        Me.ComboboxEx3.TabIndex = 70
        Me.ComboboxEx3.Text = "(�I��)"
        '
        'Label20
        '
        Me.TableLayoutPanel1.SetColumnSpan(Me.Label20, 8)
        Me.Label20.Font = New System.Drawing.Font("Meiryo UI", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label20.Location = New System.Drawing.Point(3, 90)
        Me.Label20.Name = "Label20"
        Me.Label20.Size = New System.Drawing.Size(154, 30)
        Me.Label20.TabIndex = 103
        Me.Label20.Text = "�ڋq����w���敪:"
        Me.Label20.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'ComboboxEx17
        '
        Me.ComboboxEx17.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.ComboboxEx17.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.ComboboxEx17.BackColor = System.Drawing.SystemColors.Window
        Me.TableLayoutPanel1.SetColumnSpan(Me.ComboboxEx17, 5)
        Me.ComboboxEx17.Cursor = System.Windows.Forms.Cursors.Default
        Me.ComboboxEx17.Font = New System.Drawing.Font("Meiryo UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.ComboboxEx17.ForeColor = System.Drawing.SystemColors.ControlText
        Me.ComboboxEx17.FormattingEnabled = True
        Me.ComboboxEx17.GotFocusedColor = System.Drawing.Color.FromArgb(CType(CType(190, Byte), Integer), CType(CType(180, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.ComboboxEx17.ImeMode = System.Windows.Forms.ImeMode.[On]
        Me.ComboboxEx17.Location = New System.Drawing.Point(163, 93)
        Me.ComboboxEx17.Name = "ComboboxEx17"
        Me.ComboboxEx17.Selected = False
        Me.ComboboxEx17.Size = New System.Drawing.Size(94, 25)
        Me.ComboboxEx17.TabIndex = 106
        Me.ComboboxEx17.Text = "(�I��)"
        '
        'Label19
        '
        Me.TableLayoutPanel1.SetColumnSpan(Me.Label19, 8)
        Me.Label19.Font = New System.Drawing.Font("Meiryo UI", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label19.Location = New System.Drawing.Point(3, 60)
        Me.Label19.Name = "Label19"
        Me.Label19.Size = New System.Drawing.Size(154, 30)
        Me.Label19.TabIndex = 102
        Me.Label19.Text = "�ĐR�ψ����敪:"
        Me.Label19.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label10
        '
        Me.TableLayoutPanel1.SetColumnSpan(Me.Label10, 8)
        Me.Label10.Font = New System.Drawing.Font("Meiryo UI", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label10.Location = New System.Drawing.Point(3, 30)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(154, 30)
        Me.Label10.TabIndex = 101
        Me.Label10.Text = "�������u�v�۔���敪:"
        Me.Label10.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'ComboboxEx1
        '
        Me.ComboboxEx1.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.ComboboxEx1.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.ComboboxEx1.BackColor = System.Drawing.SystemColors.Window
        Me.TableLayoutPanel1.SetColumnSpan(Me.ComboboxEx1, 5)
        Me.ComboboxEx1.Cursor = System.Windows.Forms.Cursors.Default
        Me.ComboboxEx1.Font = New System.Drawing.Font("Meiryo UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.ComboboxEx1.ForeColor = System.Drawing.SystemColors.ControlText
        Me.ComboboxEx1.FormattingEnabled = True
        Me.ComboboxEx1.GotFocusedColor = System.Drawing.Color.FromArgb(CType(CType(190, Byte), Integer), CType(CType(180, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.ComboboxEx1.ImeMode = System.Windows.Forms.ImeMode.[On]
        Me.ComboboxEx1.Location = New System.Drawing.Point(163, 33)
        Me.ComboboxEx1.Name = "ComboboxEx1"
        Me.ComboboxEx1.Selected = False
        Me.ComboboxEx1.Size = New System.Drawing.Size(94, 25)
        Me.ComboboxEx1.TabIndex = 104
        Me.ComboboxEx1.Text = "(�I��)"
        '
        'TabPage3
        '
        Me.TabPage3.Controls.Add(Me.TableLayoutPanel2)
        Me.TabPage3.Location = New System.Drawing.Point(4, 26)
        Me.TabPage3.Name = "TabPage3"
        Me.TabPage3.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage3.Size = New System.Drawing.Size(1228, 193)
        Me.TabPage3.TabIndex = 2
        Me.TabPage3.Text = "CAR��������"
        Me.TabPage3.UseVisualStyleBackColor = True
        '
        'TableLayoutPanel2
        '
        Me.TableLayoutPanel2.ColumnCount = 62
        Me.TableLayoutPanel2.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20.0!))
        Me.TableLayoutPanel2.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20.0!))
        Me.TableLayoutPanel2.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20.0!))
        Me.TableLayoutPanel2.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20.0!))
        Me.TableLayoutPanel2.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20.0!))
        Me.TableLayoutPanel2.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20.0!))
        Me.TableLayoutPanel2.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20.0!))
        Me.TableLayoutPanel2.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20.0!))
        Me.TableLayoutPanel2.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20.0!))
        Me.TableLayoutPanel2.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20.0!))
        Me.TableLayoutPanel2.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20.0!))
        Me.TableLayoutPanel2.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20.0!))
        Me.TableLayoutPanel2.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20.0!))
        Me.TableLayoutPanel2.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20.0!))
        Me.TableLayoutPanel2.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20.0!))
        Me.TableLayoutPanel2.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20.0!))
        Me.TableLayoutPanel2.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20.0!))
        Me.TableLayoutPanel2.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20.0!))
        Me.TableLayoutPanel2.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20.0!))
        Me.TableLayoutPanel2.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20.0!))
        Me.TableLayoutPanel2.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20.0!))
        Me.TableLayoutPanel2.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20.0!))
        Me.TableLayoutPanel2.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20.0!))
        Me.TableLayoutPanel2.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20.0!))
        Me.TableLayoutPanel2.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20.0!))
        Me.TableLayoutPanel2.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20.0!))
        Me.TableLayoutPanel2.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20.0!))
        Me.TableLayoutPanel2.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20.0!))
        Me.TableLayoutPanel2.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20.0!))
        Me.TableLayoutPanel2.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20.0!))
        Me.TableLayoutPanel2.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20.0!))
        Me.TableLayoutPanel2.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20.0!))
        Me.TableLayoutPanel2.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20.0!))
        Me.TableLayoutPanel2.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20.0!))
        Me.TableLayoutPanel2.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20.0!))
        Me.TableLayoutPanel2.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20.0!))
        Me.TableLayoutPanel2.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20.0!))
        Me.TableLayoutPanel2.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20.0!))
        Me.TableLayoutPanel2.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20.0!))
        Me.TableLayoutPanel2.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20.0!))
        Me.TableLayoutPanel2.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20.0!))
        Me.TableLayoutPanel2.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20.0!))
        Me.TableLayoutPanel2.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20.0!))
        Me.TableLayoutPanel2.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20.0!))
        Me.TableLayoutPanel2.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20.0!))
        Me.TableLayoutPanel2.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20.0!))
        Me.TableLayoutPanel2.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20.0!))
        Me.TableLayoutPanel2.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20.0!))
        Me.TableLayoutPanel2.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20.0!))
        Me.TableLayoutPanel2.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20.0!))
        Me.TableLayoutPanel2.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20.0!))
        Me.TableLayoutPanel2.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20.0!))
        Me.TableLayoutPanel2.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20.0!))
        Me.TableLayoutPanel2.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20.0!))
        Me.TableLayoutPanel2.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20.0!))
        Me.TableLayoutPanel2.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20.0!))
        Me.TableLayoutPanel2.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20.0!))
        Me.TableLayoutPanel2.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20.0!))
        Me.TableLayoutPanel2.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20.0!))
        Me.TableLayoutPanel2.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20.0!))
        Me.TableLayoutPanel2.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20.0!))
        Me.TableLayoutPanel2.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.TableLayoutPanel2.Controls.Add(Me.Label27, 0, 0)
        Me.TableLayoutPanel2.Controls.Add(Me.Label28, 0, 2)
        Me.TableLayoutPanel2.Controls.Add(Me.ComboboxEx8, 8, 0)
        Me.TableLayoutPanel2.Controls.Add(Me.ComboboxEx10, 8, 2)
        Me.TableLayoutPanel2.Controls.Add(Me.Label35, 19, 0)
        Me.TableLayoutPanel2.Controls.Add(Me.Label18, 0, 1)
        Me.TableLayoutPanel2.Controls.Add(Me.Label21, 19, 1)
        Me.TableLayoutPanel2.Controls.Add(Me.ComboboxEx2, 8, 1)
        Me.TableLayoutPanel2.Controls.Add(Me.MaskedTextBoxEx3, 27, 0)
        Me.TableLayoutPanel2.Controls.Add(Me.MaskedTextBoxEx1, 27, 1)
        Me.TableLayoutPanel2.Controls.Add(Me.Button2, 39, 0)
        Me.TableLayoutPanel2.Controls.Add(Me.Button4, 39, 1)
        Me.TableLayoutPanel2.Controls.Add(Me.Button3, 57, 4)
        Me.TableLayoutPanel2.Controls.Add(Me.Label30, 0, 3)
        Me.TableLayoutPanel2.Controls.Add(Me.ComboboxEx5, 8, 3)
        Me.TableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TableLayoutPanel2.Location = New System.Drawing.Point(3, 3)
        Me.TableLayoutPanel2.Name = "TableLayoutPanel2"
        Me.TableLayoutPanel2.RowCount = 7
        Me.TableLayoutPanel2.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30.0!))
        Me.TableLayoutPanel2.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30.0!))
        Me.TableLayoutPanel2.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30.0!))
        Me.TableLayoutPanel2.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30.0!))
        Me.TableLayoutPanel2.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30.0!))
        Me.TableLayoutPanel2.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30.0!))
        Me.TableLayoutPanel2.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel2.Size = New System.Drawing.Size(1222, 187)
        Me.TableLayoutPanel2.TabIndex = 64
        '
        'Label27
        '
        Me.TableLayoutPanel2.SetColumnSpan(Me.Label27, 8)
        Me.Label27.Font = New System.Drawing.Font("Meiryo UI", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label27.Location = New System.Drawing.Point(3, 0)
        Me.Label27.Name = "Label27"
        Me.Label27.Size = New System.Drawing.Size(154, 30)
        Me.Label27.TabIndex = 54
        Me.Label27.Text = "�v��1:"
        Me.Label27.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label28
        '
        Me.TableLayoutPanel2.SetColumnSpan(Me.Label28, 8)
        Me.Label28.Font = New System.Drawing.Font("Meiryo UI", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label28.Location = New System.Drawing.Point(3, 60)
        Me.Label28.Name = "Label28"
        Me.Label28.Size = New System.Drawing.Size(154, 30)
        Me.Label28.TabIndex = 67
        Me.Label28.Text = "��ƎҖ�:"
        Me.Label28.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'ComboboxEx8
        '
        Me.ComboboxEx8.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.ComboboxEx8.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.ComboboxEx8.BackColor = System.Drawing.SystemColors.Window
        Me.TableLayoutPanel2.SetColumnSpan(Me.ComboboxEx8, 10)
        Me.ComboboxEx8.Cursor = System.Windows.Forms.Cursors.Default
        Me.ComboboxEx8.DropDownWidth = 220
        Me.ComboboxEx8.Font = New System.Drawing.Font("Meiryo UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.ComboboxEx8.ForeColor = System.Drawing.SystemColors.ControlText
        Me.ComboboxEx8.FormattingEnabled = True
        Me.ComboboxEx8.GotFocusedColor = System.Drawing.Color.FromArgb(CType(CType(190, Byte), Integer), CType(CType(180, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.ComboboxEx8.ImeMode = System.Windows.Forms.ImeMode.[On]
        Me.ComboboxEx8.Location = New System.Drawing.Point(163, 3)
        Me.ComboboxEx8.Name = "ComboboxEx8"
        Me.ComboboxEx8.Selected = False
        Me.ComboboxEx8.Size = New System.Drawing.Size(194, 25)
        Me.ComboboxEx8.TabIndex = 0
        Me.ComboboxEx8.Text = "(�I��)"
        '
        'ComboboxEx10
        '
        Me.ComboboxEx10.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.ComboboxEx10.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.ComboboxEx10.BackColor = System.Drawing.SystemColors.Window
        Me.TableLayoutPanel2.SetColumnSpan(Me.ComboboxEx10, 7)
        Me.ComboboxEx10.Cursor = System.Windows.Forms.Cursors.Default
        Me.ComboboxEx10.Font = New System.Drawing.Font("Meiryo UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.ComboboxEx10.ForeColor = System.Drawing.SystemColors.ControlText
        Me.ComboboxEx10.FormattingEnabled = True
        Me.ComboboxEx10.GotFocusedColor = System.Drawing.Color.FromArgb(CType(CType(190, Byte), Integer), CType(CType(180, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.ComboboxEx10.ImeMode = System.Windows.Forms.ImeMode.[On]
        Me.ComboboxEx10.Location = New System.Drawing.Point(163, 63)
        Me.ComboboxEx10.Name = "ComboboxEx10"
        Me.ComboboxEx10.Selected = False
        Me.ComboboxEx10.Size = New System.Drawing.Size(134, 25)
        Me.ComboboxEx10.TabIndex = 70
        Me.ComboboxEx10.Text = "(�I��)"
        '
        'Label35
        '
        Me.TableLayoutPanel2.SetColumnSpan(Me.Label35, 8)
        Me.Label35.Font = New System.Drawing.Font("Meiryo UI", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label35.Location = New System.Drawing.Point(383, 0)
        Me.Label35.Name = "Label35"
        Me.Label35.Size = New System.Drawing.Size(154, 30)
        Me.Label35.TabIndex = 63
        Me.Label35.Text = "����1:"
        Me.Label35.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label18
        '
        Me.TableLayoutPanel2.SetColumnSpan(Me.Label18, 8)
        Me.Label18.Font = New System.Drawing.Font("Meiryo UI", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label18.Location = New System.Drawing.Point(3, 30)
        Me.Label18.Name = "Label18"
        Me.Label18.Size = New System.Drawing.Size(154, 30)
        Me.Label18.TabIndex = 101
        Me.Label18.Text = "�v��2:"
        Me.Label18.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label21
        '
        Me.TableLayoutPanel2.SetColumnSpan(Me.Label21, 8)
        Me.Label21.Font = New System.Drawing.Font("Meiryo UI", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label21.Location = New System.Drawing.Point(383, 30)
        Me.Label21.Name = "Label21"
        Me.Label21.Size = New System.Drawing.Size(154, 30)
        Me.Label21.TabIndex = 102
        Me.Label21.Text = "����2:"
        Me.Label21.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'ComboboxEx2
        '
        Me.ComboboxEx2.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.ComboboxEx2.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.ComboboxEx2.BackColor = System.Drawing.SystemColors.Window
        Me.TableLayoutPanel2.SetColumnSpan(Me.ComboboxEx2, 10)
        Me.ComboboxEx2.Cursor = System.Windows.Forms.Cursors.Default
        Me.ComboboxEx2.DropDownWidth = 220
        Me.ComboboxEx2.Font = New System.Drawing.Font("Meiryo UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.ComboboxEx2.ForeColor = System.Drawing.SystemColors.ControlText
        Me.ComboboxEx2.FormattingEnabled = True
        Me.ComboboxEx2.GotFocusedColor = System.Drawing.Color.FromArgb(CType(CType(190, Byte), Integer), CType(CType(180, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.ComboboxEx2.ImeMode = System.Windows.Forms.ImeMode.[On]
        Me.ComboboxEx2.Location = New System.Drawing.Point(163, 33)
        Me.ComboboxEx2.Name = "ComboboxEx2"
        Me.ComboboxEx2.Selected = False
        Me.ComboboxEx2.Size = New System.Drawing.Size(194, 25)
        Me.ComboboxEx2.TabIndex = 103
        Me.ComboboxEx2.Text = "(�I��)"
        '
        'MaskedTextBoxEx3
        '
        Me.MaskedTextBoxEx3.BackColor = System.Drawing.SystemColors.Window
        Me.TableLayoutPanel2.SetColumnSpan(Me.MaskedTextBoxEx3, 24)
        Me.MaskedTextBoxEx3.GotFocusedColor = System.Drawing.Color.FromArgb(CType(CType(190, Byte), Integer), CType(CType(180, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.MaskedTextBoxEx3.ImeMode = System.Windows.Forms.ImeMode.Disable
        Me.MaskedTextBoxEx3.InputRequired = False
        Me.MaskedTextBoxEx3.Location = New System.Drawing.Point(543, 3)
        Me.MaskedTextBoxEx3.Name = "MaskedTextBoxEx3"
        Me.MaskedTextBoxEx3.Size = New System.Drawing.Size(474, 24)
        Me.MaskedTextBoxEx3.TabIndex = 82
        Me.MaskedTextBoxEx3.WatermarkColor = System.Drawing.Color.Empty
        Me.MaskedTextBoxEx3.WatermarkText = Nothing
        '
        'MaskedTextBoxEx1
        '
        Me.MaskedTextBoxEx1.BackColor = System.Drawing.SystemColors.Window
        Me.TableLayoutPanel2.SetColumnSpan(Me.MaskedTextBoxEx1, 24)
        Me.MaskedTextBoxEx1.GotFocusedColor = System.Drawing.Color.FromArgb(CType(CType(190, Byte), Integer), CType(CType(180, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.MaskedTextBoxEx1.ImeMode = System.Windows.Forms.ImeMode.Disable
        Me.MaskedTextBoxEx1.InputRequired = False
        Me.MaskedTextBoxEx1.Location = New System.Drawing.Point(543, 33)
        Me.MaskedTextBoxEx1.Name = "MaskedTextBoxEx1"
        Me.MaskedTextBoxEx1.Size = New System.Drawing.Size(474, 24)
        Me.MaskedTextBoxEx1.TabIndex = 104
        Me.MaskedTextBoxEx1.WatermarkColor = System.Drawing.Color.Empty
        Me.MaskedTextBoxEx1.WatermarkText = Nothing
        '
        'Button2
        '
        Me.TableLayoutPanel2.SetColumnSpan(Me.Button2, 3)
        Me.Button2.Cursor = System.Windows.Forms.Cursors.Hand
        Me.Button2.Location = New System.Drawing.Point(1023, 3)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(54, 24)
        Me.Button2.TabIndex = 105
        Me.Button2.Text = "�I��"
        Me.Button2.UseVisualStyleBackColor = True
        Me.Button2.Visible = False
        '
        'Button4
        '
        Me.TableLayoutPanel2.SetColumnSpan(Me.Button4, 3)
        Me.Button4.Cursor = System.Windows.Forms.Cursors.Hand
        Me.Button4.Location = New System.Drawing.Point(1023, 33)
        Me.Button4.Name = "Button4"
        Me.Button4.Size = New System.Drawing.Size(54, 24)
        Me.Button4.TabIndex = 99
        Me.Button4.Text = "�I��"
        Me.Button4.UseVisualStyleBackColor = True
        Me.Button4.Visible = False
        '
        'Button3
        '
        Me.TableLayoutPanel2.SetColumnSpan(Me.Button3, 5)
        Me.Button3.Cursor = System.Windows.Forms.Cursors.Hand
        Me.Button3.Location = New System.Drawing.Point(1143, 123)
        Me.Button3.Name = "Button3"
        Me.TableLayoutPanel2.SetRowSpan(Me.Button3, 3)
        Me.Button3.Size = New System.Drawing.Size(74, 54)
        Me.Button3.TabIndex = 100
        Me.Button3.Text = "�����N���A"
        Me.Button3.UseVisualStyleBackColor = True
        '
        'Label30
        '
        Me.TableLayoutPanel2.SetColumnSpan(Me.Label30, 8)
        Me.Label30.Font = New System.Drawing.Font("Meiryo UI", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label30.Location = New System.Drawing.Point(3, 90)
        Me.Label30.Name = "Label30"
        Me.Label30.Size = New System.Drawing.Size(154, 30)
        Me.Label30.TabIndex = 69
        Me.Label30.Text = "�A�ӍH��:"
        Me.Label30.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'ComboboxEx5
        '
        Me.ComboboxEx5.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.ComboboxEx5.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.ComboboxEx5.BackColor = System.Drawing.SystemColors.Window
        Me.TableLayoutPanel2.SetColumnSpan(Me.ComboboxEx5, 10)
        Me.ComboboxEx5.Cursor = System.Windows.Forms.Cursors.Default
        Me.ComboboxEx5.DropDownWidth = 220
        Me.ComboboxEx5.Font = New System.Drawing.Font("Meiryo UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.ComboboxEx5.ForeColor = System.Drawing.SystemColors.ControlText
        Me.ComboboxEx5.FormattingEnabled = True
        Me.ComboboxEx5.GotFocusedColor = System.Drawing.Color.FromArgb(CType(CType(190, Byte), Integer), CType(CType(180, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.ComboboxEx5.ImeMode = System.Windows.Forms.ImeMode.[On]
        Me.ComboboxEx5.Location = New System.Drawing.Point(163, 93)
        Me.ComboboxEx5.Name = "ComboboxEx5"
        Me.ComboboxEx5.Selected = False
        Me.ComboboxEx5.Size = New System.Drawing.Size(194, 25)
        Me.ComboboxEx5.TabIndex = 106
        Me.ComboboxEx5.Text = "(�I��)"
        '
        'FrmG0010
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.ClientSize = New System.Drawing.Size(1264, 712)
        Me.Controls.Add(Me.TabControl1)
        Me.Controls.Add(Me.dgvDATA)
        Me.Controls.Add(Me.flxDATA)
        Me.HelpButton = True
        Me.Name = "FrmG0010"
        Me.ShowStatusBar = True
        Me.Text = ""
        Me.Controls.SetChildIndex(Me.flxDATA, 0)
        Me.Controls.SetChildIndex(Me.dgvDATA, 0)
        Me.Controls.SetChildIndex(Me.TabControl1, 0)
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
        Me.tlpFilter.ResumeLayout(False)
        Me.tlpFilter.PerformLayout()
        CType(Me.flxDATA, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dgvDATA, System.ComponentModel.ISupportInitialize).EndInit()
        Me.TabControl1.ResumeLayout(False)
        Me.TabPage1.ResumeLayout(False)
        Me.TabPage2.ResumeLayout(False)
        Me.TableLayoutPanel1.ResumeLayout(False)
        Me.TabPage3.ResumeLayout(False)
        Me.TableLayoutPanel2.ResumeLayout(False)
        Me.TableLayoutPanel2.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents chkClosedRowVisibled As CheckBox
    Friend WithEvents tlpFilter As TableLayoutPanel
    Friend WithEvents Label5 As Label
    Friend WithEvents dtExecFrom As DateTextBoxEx
    Friend WithEvents dtExecTo As DateTextBoxEx
    Friend WithEvents Label7 As Label
    Friend WithEvents Label6 As Label
    Friend WithEvents cmbJIZEN_SINSA_HANTEI_KB As ComboboxEx
    Friend WithEvents Label8 As Label
    Friend WithEvents cmbTANTO As ComboboxEx
    Friend WithEvents cmbBUHIN_BANGO As ComboboxEx
    Friend WithEvents Label11 As Label
    Friend WithEvents cmbSAISIN_IINKAI_HANTEI_KB As ComboboxEx
    Friend WithEvents cmbKISYU As ComboboxEx
    Friend WithEvents Label9 As Label
    Friend WithEvents Label15 As Label
    Friend WithEvents Label16 As Label
    Friend WithEvents mtxHINMEI As MaskedTextBoxEx
    Friend WithEvents mtxHOKUKO_NO As MaskedTextBoxEx
    Friend WithEvents btnSECH_BUHIN As Button
    Friend WithEvents btnClearSrchFilter As Button
    Friend WithEvents flxDATA As C1.Win.C1FlexGrid.C1FlexGrid
    Friend WithEvents dgvDATA As DataGridView
    Friend WithEvents TabControl1 As TabControl
    Friend WithEvents TabPage1 As TabPage
    Friend WithEvents TabPage2 As TabPage
    Friend WithEvents TabPage3 As TabPage
    Friend WithEvents TableLayoutPanel1 As TableLayoutPanel
    Friend WithEvents Label12 As Label
    Friend WithEvents Label13 As Label
    Friend WithEvents Label17 As Label
    Friend WithEvents ComboboxEx3 As ComboboxEx
    Friend WithEvents ComboboxEx4 As ComboboxEx
    Friend WithEvents Button1 As Button
    Friend WithEvents TableLayoutPanel2 As TableLayoutPanel
    Friend WithEvents Label27 As Label
    Friend WithEvents Label28 As Label
    Friend WithEvents Label30 As Label
    Friend WithEvents ComboboxEx8 As ComboboxEx
    Friend WithEvents Label35 As Label
    Friend WithEvents ComboboxEx10 As ComboboxEx
    Friend WithEvents MaskedTextBoxEx3 As MaskedTextBoxEx
    Friend WithEvents Button3 As Button
    Friend WithEvents Button4 As Button
    Friend WithEvents Label1 As Label
    Friend WithEvents cmbBUMON As ComboboxEx
    Friend WithEvents Label2 As Label
    Friend WithEvents MaskedTextBoxEx5 As MaskedTextBoxEx
    Friend WithEvents Label3 As Label
    Friend WithEvents MaskedTextBoxEx6 As MaskedTextBoxEx
    Friend WithEvents Label4 As Label
    Friend WithEvents Label14 As Label
    Friend WithEvents ComboboxEx15 As ComboboxEx
    Friend WithEvents CheckBox3 As CheckBox
    Friend WithEvents ComboboxEx6 As ComboboxEx
    Friend WithEvents ComboboxEx7 As ComboboxEx
    Friend WithEvents Label40 As Label
    Friend WithEvents ComboboxEx16 As ComboboxEx
    Friend WithEvents Label10 As Label
    Friend WithEvents Label19 As Label
    Friend WithEvents Label20 As Label
    Friend WithEvents ComboboxEx17 As ComboboxEx
    Friend WithEvents ComboboxEx1 As ComboboxEx
    Friend WithEvents Label18 As Label
    Friend WithEvents Label21 As Label
    Friend WithEvents ComboboxEx2 As ComboboxEx
    Friend WithEvents MaskedTextBoxEx1 As MaskedTextBoxEx
    Friend WithEvents Button2 As Button
    Friend WithEvents ComboboxEx5 As ComboboxEx
End Class
