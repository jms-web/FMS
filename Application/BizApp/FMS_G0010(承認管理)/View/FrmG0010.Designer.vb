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
        Dim DataGridViewCellStyle7 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle8 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle9 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.cmbSTAGE_NCR = New JMS_COMMON.ComboboxEx()
        Me.gbxFilter = New System.Windows.Forms.GroupBox()
        Me.tlpFilter = New System.Windows.Forms.TableLayoutPanel()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label15 = New System.Windows.Forms.Label()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.Label16 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.cmbSTAGE_CAR = New JMS_COMMON.ComboboxEx()
        Me.dtDraftFrom = New JMS_COMMON.DateTextBoxEx()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.dtDraftTo = New JMS_COMMON.DateTextBoxEx()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.dtExecFrom = New JMS_COMMON.DateTextBoxEx()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.dtExecTo = New JMS_COMMON.DateTextBoxEx()
        Me.cmbTANTO = New JMS_COMMON.ComboboxEx()
        Me.mtxHOKUKO_NO = New JMS_COMMON.MaskedTextBoxEx()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.cmbKISYU = New JMS_COMMON.ComboboxEx()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.cmbBUHIN_NO = New JMS_COMMON.ComboboxEx()
        Me.btnSECH_BUHIN = New System.Windows.Forms.Button()
        Me.cmbHOKUKO_NAME = New JMS_COMMON.ComboboxEx()
        Me.mtxHINMEI = New JMS_COMMON.MaskedTextBoxEx()
        Me.cmbSINSA_HANTEI_KB = New JMS_COMMON.ComboboxEx()
        Me.cmbSAISIN_HANTEI_KB = New JMS_COMMON.ComboboxEx()
        Me.btnClearSrchFilter = New System.Windows.Forms.Button()
        Me.chkClosedRowVisibled = New System.Windows.Forms.CheckBox()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.Label14 = New System.Windows.Forms.Label()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.cmbSYOCHI_KB = New JMS_COMMON.ComboboxEx()
        Me.flxDATA = New C1.Win.C1FlexGrid.C1FlexGrid()
        Me.dgvDATA = New System.Windows.Forms.DataGridView()
        CType(Me.ErrorProvider, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.gbxFilter.SuspendLayout()
        Me.tlpFilter.SuspendLayout()
        CType(Me.flxDATA, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dgvDATA, System.ComponentModel.ISupportInitialize).BeginInit()
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
        Me.cmdFunc1.Text = "検索(F1)"
        '
        'cmdFunc2
        '
        Me.cmdFunc2.Image = Global.FMS.My.Resources.Resources._imgApplication_form_add32x32
        Me.cmdFunc2.Location = New System.Drawing.Point(216, 595)
        Me.cmdFunc2.Text = "新規作成(F2)"
        '
        'cmdFunc3
        '
        Me.cmdFunc3.Location = New System.Drawing.Point(423, 595)
        '
        'cmdFunc4
        '
        Me.cmdFunc4.Image = Global.FMS.My.Resources.Resources._imgApplication_form_edit32x32
        Me.cmdFunc4.Location = New System.Drawing.Point(630, 595)
        Me.cmdFunc4.Text = "変更・承認(F4)"
        '
        'cmdFunc5
        '
        Me.cmdFunc5.Image = Global.FMS.My.Resources.Resources._imgStatusAnnotations_Blocked_32x32_MD
        Me.cmdFunc5.Location = New System.Drawing.Point(837, 595)
        Me.cmdFunc5.Text = "削除(F5)"
        '
        'cmdFunc6
        '
        Me.cmdFunc6.Image = Global.FMS.My.Resources.Resources._imgRecovery32x32
        Me.cmdFunc6.Location = New System.Drawing.Point(1044, 595)
        Me.cmdFunc6.Text = "復元(F6)"
        Me.cmdFunc6.Visible = False
        '
        'cmdFunc12
        '
        Me.cmdFunc12.Image = Global.FMS.My.Resources.Resources._imgLog_Out32x32
        Me.cmdFunc12.Location = New System.Drawing.Point(1044, 643)
        Me.cmdFunc12.Text = "閉じる(F12)"
        '
        'cmdFunc11
        '
        Me.cmdFunc11.Image = Global.FMS.My.Resources.Resources._imgApplication_form32x32
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
        Me.cmdFunc7.Image = Global.FMS.My.Resources.Resources._imgStatusAnnotations_Complete_and_ok_32x32
        Me.cmdFunc7.Location = New System.Drawing.Point(9, 643)
        Me.cmdFunc7.Text = "全選択(F7)"
        '
        'cmdFunc9
        '
        Me.cmdFunc9.Location = New System.Drawing.Point(423, 643)
        Me.cmdFunc9.Text = "メール送信(F9)"
        '
        'cmdFunc8
        '
        Me.cmdFunc8.Image = Global.FMS.My.Resources.Resources._imgStatusAnnotations_Complete_and_ok_mono32x32
        Me.cmdFunc8.Location = New System.Drawing.Point(216, 643)
        Me.cmdFunc8.Text = "全選択解除(F8)"
        '
        'lblTytle
        '
        Me.lblTytle.Font = New System.Drawing.Font("Meiryo UI", 24.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTytle.ForeColor = System.Drawing.SystemColors.ControlText
        Me.lblTytle.Text = "不適合検索画面"
        '
        'Label3
        '
        Me.tlpFilter.SetColumnSpan(Me.Label3, 8)
        Me.Label3.Font = New System.Drawing.Font("Meiryo UI", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label3.Location = New System.Drawing.Point(3, 0)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(154, 30)
        Me.Label3.TabIndex = 54
        Me.Label3.Text = "製品処置(NCR)ステージ:"
        Me.Label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'cmbSTAGE_NCR
        '
        Me.cmbSTAGE_NCR.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cmbSTAGE_NCR.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cmbSTAGE_NCR.BackColor = System.Drawing.SystemColors.Window
        Me.tlpFilter.SetColumnSpan(Me.cmbSTAGE_NCR, 10)
        Me.cmbSTAGE_NCR.Cursor = System.Windows.Forms.Cursors.Default
        Me.cmbSTAGE_NCR.DropDownWidth = 220
        Me.cmbSTAGE_NCR.Font = New System.Drawing.Font("Meiryo UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.cmbSTAGE_NCR.ForeColor = System.Drawing.SystemColors.ControlText
        Me.cmbSTAGE_NCR.FormattingEnabled = True
        Me.cmbSTAGE_NCR.GotFocusedColor = System.Drawing.Color.FromArgb(CType(CType(190, Byte), Integer), CType(CType(180, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.cmbSTAGE_NCR.ImeMode = System.Windows.Forms.ImeMode.[On]
        Me.cmbSTAGE_NCR.Location = New System.Drawing.Point(163, 3)
        Me.cmbSTAGE_NCR.Name = "cmbSTAGE_NCR"
        Me.cmbSTAGE_NCR.Selected = False
        Me.cmbSTAGE_NCR.Size = New System.Drawing.Size(194, 25)
        Me.cmbSTAGE_NCR.TabIndex = 0
        Me.cmbSTAGE_NCR.Text = "(選択)"
        '
        'gbxFilter
        '
        Me.gbxFilter.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.gbxFilter.Controls.Add(Me.tlpFilter)
        Me.gbxFilter.Font = New System.Drawing.Font("Meiryo UI", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.gbxFilter.Location = New System.Drawing.Point(12, 60)
        Me.gbxFilter.Name = "gbxFilter"
        Me.gbxFilter.Size = New System.Drawing.Size(1236, 174)
        Me.gbxFilter.TabIndex = 59
        Me.gbxFilter.TabStop = False
        Me.gbxFilter.Text = "検索条件"
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
        Me.tlpFilter.Controls.Add(Me.Label3, 0, 0)
        Me.tlpFilter.Controls.Add(Me.Label6, 0, 2)
        Me.tlpFilter.Controls.Add(Me.Label15, 0, 4)
        Me.tlpFilter.Controls.Add(Me.Label8, 19, 2)
        Me.tlpFilter.Controls.Add(Me.Label16, 19, 4)
        Me.tlpFilter.Controls.Add(Me.cmbSTAGE_NCR, 8, 0)
        Me.tlpFilter.Controls.Add(Me.Label2, 0, 1)
        Me.tlpFilter.Controls.Add(Me.cmbSTAGE_CAR, 25, 0)
        Me.tlpFilter.Controls.Add(Me.dtDraftFrom, 8, 1)
        Me.tlpFilter.Controls.Add(Me.Label4, 13, 1)
        Me.tlpFilter.Controls.Add(Me.dtDraftTo, 14, 1)
        Me.tlpFilter.Controls.Add(Me.Label1, 19, 0)
        Me.tlpFilter.Controls.Add(Me.Label5, 19, 1)
        Me.tlpFilter.Controls.Add(Me.dtExecFrom, 27, 1)
        Me.tlpFilter.Controls.Add(Me.Label7, 32, 1)
        Me.tlpFilter.Controls.Add(Me.dtExecTo, 33, 1)
        Me.tlpFilter.Controls.Add(Me.cmbTANTO, 8, 2)
        Me.tlpFilter.Controls.Add(Me.mtxHOKUKO_NO, 27, 2)
        Me.tlpFilter.Controls.Add(Me.Label9, 0, 3)
        Me.tlpFilter.Controls.Add(Me.cmbKISYU, 8, 3)
        Me.tlpFilter.Controls.Add(Me.Label11, 19, 3)
        Me.tlpFilter.Controls.Add(Me.cmbBUHIN_NO, 27, 3)
        Me.tlpFilter.Controls.Add(Me.btnSECH_BUHIN, 33, 3)
        Me.tlpFilter.Controls.Add(Me.cmbHOKUKO_NAME, 41, 2)
        Me.tlpFilter.Controls.Add(Me.mtxHINMEI, 41, 3)
        Me.tlpFilter.Controls.Add(Me.cmbSINSA_HANTEI_KB, 8, 4)
        Me.tlpFilter.Controls.Add(Me.cmbSAISIN_HANTEI_KB, 27, 4)
        Me.tlpFilter.Controls.Add(Me.btnClearSrchFilter, 57, 3)
        Me.tlpFilter.Controls.Add(Me.chkClosedRowVisibled, 50, 4)
        Me.tlpFilter.Controls.Add(Me.Label12, 36, 4)
        Me.tlpFilter.Controls.Add(Me.Label14, 39, 3)
        Me.tlpFilter.Controls.Add(Me.Label10, 37, 2)
        Me.tlpFilter.Controls.Add(Me.cmbSYOCHI_KB, 44, 4)
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
        Me.tlpFilter.Size = New System.Drawing.Size(1230, 151)
        Me.tlpFilter.TabIndex = 56
        '
        'Label6
        '
        Me.tlpFilter.SetColumnSpan(Me.Label6, 8)
        Me.Label6.Font = New System.Drawing.Font("Meiryo UI", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label6.Location = New System.Drawing.Point(3, 60)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(154, 30)
        Me.Label6.TabIndex = 67
        Me.Label6.Text = "処置担当者:"
        Me.Label6.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label15
        '
        Me.tlpFilter.SetColumnSpan(Me.Label15, 8)
        Me.Label15.Font = New System.Drawing.Font("Meiryo UI", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label15.Location = New System.Drawing.Point(3, 120)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(154, 30)
        Me.Label15.TabIndex = 80
        Me.Label15.Text = "事前審査判定区分:"
        Me.Label15.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label8
        '
        Me.tlpFilter.SetColumnSpan(Me.Label8, 8)
        Me.Label8.Font = New System.Drawing.Font("Meiryo UI", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label8.Location = New System.Drawing.Point(383, 60)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(154, 30)
        Me.Label8.TabIndex = 69
        Me.Label8.Text = "報告書No:"
        Me.Label8.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label16
        '
        Me.tlpFilter.SetColumnSpan(Me.Label16, 8)
        Me.Label16.Font = New System.Drawing.Font("Meiryo UI", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label16.Location = New System.Drawing.Point(383, 120)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(154, 30)
        Me.Label16.TabIndex = 80
        Me.Label16.Text = "再審委員会判定区分:"
        Me.Label16.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label2
        '
        Me.tlpFilter.SetColumnSpan(Me.Label2, 8)
        Me.Label2.Font = New System.Drawing.Font("Meiryo UI", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label2.Location = New System.Drawing.Point(3, 30)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(154, 30)
        Me.Label2.TabIndex = 59
        Me.Label2.Text = "起草日:"
        Me.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'cmbSTAGE_CAR
        '
        Me.cmbSTAGE_CAR.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cmbSTAGE_CAR.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cmbSTAGE_CAR.BackColor = System.Drawing.SystemColors.Window
        Me.tlpFilter.SetColumnSpan(Me.cmbSTAGE_CAR, 10)
        Me.cmbSTAGE_CAR.Cursor = System.Windows.Forms.Cursors.Default
        Me.cmbSTAGE_CAR.DropDownWidth = 220
        Me.cmbSTAGE_CAR.Font = New System.Drawing.Font("Meiryo UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.cmbSTAGE_CAR.ForeColor = System.Drawing.SystemColors.ControlText
        Me.cmbSTAGE_CAR.FormattingEnabled = True
        Me.cmbSTAGE_CAR.GotFocusedColor = System.Drawing.Color.FromArgb(CType(CType(190, Byte), Integer), CType(CType(180, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.cmbSTAGE_CAR.ImeMode = System.Windows.Forms.ImeMode.[On]
        Me.cmbSTAGE_CAR.Location = New System.Drawing.Point(543, 3)
        Me.cmbSTAGE_CAR.Name = "cmbSTAGE_CAR"
        Me.cmbSTAGE_CAR.Selected = False
        Me.cmbSTAGE_CAR.Size = New System.Drawing.Size(194, 25)
        Me.cmbSTAGE_CAR.TabIndex = 57
        Me.cmbSTAGE_CAR.Text = "(選択)"
        '
        'dtDraftFrom
        '
        Me.dtDraftFrom.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.tlpFilter.SetColumnSpan(Me.dtDraftFrom, 5)
        Me.dtDraftFrom.GotFocusedColor = System.Drawing.Color.FromArgb(CType(CType(190, Byte), Integer), CType(CType(180, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.dtDraftFrom.Location = New System.Drawing.Point(163, 33)
        Me.dtDraftFrom.MaxDate = New Date(9998, 12, 31, 0, 0, 0, 0)
        Me.dtDraftFrom.MinDate = New Date(1753, 1, 1, 0, 0, 0, 0)
        Me.dtDraftFrom.MinimumSize = New System.Drawing.Size(98, 24)
        Me.dtDraftFrom.Name = "dtDraftFrom"
        Me.dtDraftFrom.Size = New System.Drawing.Size(98, 24)
        Me.dtDraftFrom.TabIndex = 58
        Me.dtDraftFrom.Value = ""
        Me.dtDraftFrom.ValueNonFormat = ""
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Label4.Font = New System.Drawing.Font("Meiryo UI", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label4.Location = New System.Drawing.Point(263, 30)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(14, 30)
        Me.Label4.TabIndex = 60
        Me.Label4.Text = "~"
        Me.Label4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'dtDraftTo
        '
        Me.dtDraftTo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.tlpFilter.SetColumnSpan(Me.dtDraftTo, 5)
        Me.dtDraftTo.GotFocusedColor = System.Drawing.Color.FromArgb(CType(CType(190, Byte), Integer), CType(CType(180, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.dtDraftTo.Location = New System.Drawing.Point(283, 33)
        Me.dtDraftTo.MaxDate = New Date(9998, 12, 31, 0, 0, 0, 0)
        Me.dtDraftTo.MinDate = New Date(1753, 1, 1, 0, 0, 0, 0)
        Me.dtDraftTo.MinimumSize = New System.Drawing.Size(98, 24)
        Me.dtDraftTo.Name = "dtDraftTo"
        Me.dtDraftTo.Size = New System.Drawing.Size(98, 24)
        Me.dtDraftTo.TabIndex = 61
        Me.dtDraftTo.Value = ""
        Me.dtDraftTo.ValueNonFormat = ""
        '
        'Label1
        '
        Me.Label1.BackColor = System.Drawing.SystemColors.Control
        Me.tlpFilter.SetColumnSpan(Me.Label1, 8)
        Me.Label1.Font = New System.Drawing.Font("Meiryo UI", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label1.Location = New System.Drawing.Point(383, 0)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(154, 30)
        Me.Label1.TabIndex = 56
        Me.Label1.Text = "是正処置(CAR)ステージ:"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label5
        '
        Me.tlpFilter.SetColumnSpan(Me.Label5, 8)
        Me.Label5.Font = New System.Drawing.Font("Meiryo UI", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label5.Location = New System.Drawing.Point(383, 30)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(154, 30)
        Me.Label5.TabIndex = 63
        Me.Label5.Text = "処理実施日:"
        Me.Label5.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'dtExecFrom
        '
        Me.dtExecFrom.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.tlpFilter.SetColumnSpan(Me.dtExecFrom, 5)
        Me.dtExecFrom.GotFocusedColor = System.Drawing.Color.FromArgb(CType(CType(190, Byte), Integer), CType(CType(180, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.dtExecFrom.Location = New System.Drawing.Point(543, 33)
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
        Me.Label7.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Label7.Font = New System.Drawing.Font("Meiryo UI", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label7.Location = New System.Drawing.Point(643, 30)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(14, 30)
        Me.Label7.TabIndex = 66
        Me.Label7.Text = "~"
        Me.Label7.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'dtExecTo
        '
        Me.dtExecTo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.tlpFilter.SetColumnSpan(Me.dtExecTo, 5)
        Me.dtExecTo.GotFocusedColor = System.Drawing.Color.FromArgb(CType(CType(190, Byte), Integer), CType(CType(180, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.dtExecTo.Location = New System.Drawing.Point(663, 33)
        Me.dtExecTo.MaxDate = New Date(9998, 12, 31, 0, 0, 0, 0)
        Me.dtExecTo.MinDate = New Date(1753, 1, 1, 0, 0, 0, 0)
        Me.dtExecTo.MinimumSize = New System.Drawing.Size(98, 24)
        Me.dtExecTo.Name = "dtExecTo"
        Me.dtExecTo.Size = New System.Drawing.Size(98, 24)
        Me.dtExecTo.TabIndex = 62
        Me.dtExecTo.Value = ""
        Me.dtExecTo.ValueNonFormat = ""
        '
        'cmbTANTO
        '
        Me.cmbTANTO.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cmbTANTO.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cmbTANTO.BackColor = System.Drawing.SystemColors.Window
        Me.tlpFilter.SetColumnSpan(Me.cmbTANTO, 6)
        Me.cmbTANTO.Cursor = System.Windows.Forms.Cursors.Default
        Me.cmbTANTO.Font = New System.Drawing.Font("Meiryo UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.cmbTANTO.ForeColor = System.Drawing.SystemColors.ControlText
        Me.cmbTANTO.FormattingEnabled = True
        Me.cmbTANTO.GotFocusedColor = System.Drawing.Color.FromArgb(CType(CType(190, Byte), Integer), CType(CType(180, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.cmbTANTO.ImeMode = System.Windows.Forms.ImeMode.[On]
        Me.cmbTANTO.Location = New System.Drawing.Point(163, 63)
        Me.cmbTANTO.Name = "cmbTANTO"
        Me.cmbTANTO.Selected = False
        Me.cmbTANTO.Size = New System.Drawing.Size(114, 25)
        Me.cmbTANTO.TabIndex = 70
        Me.cmbTANTO.Text = "(選択)"
        '
        'mtxHOKUKO_NO
        '
        Me.mtxHOKUKO_NO.BackColor = System.Drawing.SystemColors.Window
        Me.tlpFilter.SetColumnSpan(Me.mtxHOKUKO_NO, 7)
        Me.mtxHOKUKO_NO.GotFocusedColor = System.Drawing.Color.FromArgb(CType(CType(190, Byte), Integer), CType(CType(180, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.mtxHOKUKO_NO.ImeMode = System.Windows.Forms.ImeMode.Disable
        Me.mtxHOKUKO_NO.InputRequired = False
        Me.mtxHOKUKO_NO.Location = New System.Drawing.Point(543, 63)
        Me.mtxHOKUKO_NO.Name = "mtxHOKUKO_NO"
        Me.mtxHOKUKO_NO.Size = New System.Drawing.Size(134, 24)
        Me.mtxHOKUKO_NO.TabIndex = 82
        Me.mtxHOKUKO_NO.WatermarkColor = System.Drawing.Color.Empty
        Me.mtxHOKUKO_NO.WatermarkText = Nothing
        '
        'Label9
        '
        Me.tlpFilter.SetColumnSpan(Me.Label9, 8)
        Me.Label9.Font = New System.Drawing.Font("Meiryo UI", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label9.Location = New System.Drawing.Point(3, 90)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(154, 30)
        Me.Label9.TabIndex = 73
        Me.Label9.Text = "機種:"
        Me.Label9.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'cmbKISYU
        '
        Me.cmbKISYU.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cmbKISYU.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cmbKISYU.BackColor = System.Drawing.SystemColors.Window
        Me.tlpFilter.SetColumnSpan(Me.cmbKISYU, 5)
        Me.cmbKISYU.Cursor = System.Windows.Forms.Cursors.Default
        Me.cmbKISYU.Font = New System.Drawing.Font("Meiryo UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.cmbKISYU.ForeColor = System.Drawing.SystemColors.ControlText
        Me.cmbKISYU.FormattingEnabled = True
        Me.cmbKISYU.GotFocusedColor = System.Drawing.Color.FromArgb(CType(CType(190, Byte), Integer), CType(CType(180, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.cmbKISYU.ImeMode = System.Windows.Forms.ImeMode.[On]
        Me.cmbKISYU.Location = New System.Drawing.Point(163, 93)
        Me.cmbKISYU.Name = "cmbKISYU"
        Me.cmbKISYU.Selected = False
        Me.cmbKISYU.Size = New System.Drawing.Size(94, 25)
        Me.cmbKISYU.TabIndex = 78
        Me.cmbKISYU.Text = "(選択)"
        '
        'Label11
        '
        Me.tlpFilter.SetColumnSpan(Me.Label11, 8)
        Me.Label11.Font = New System.Drawing.Font("Meiryo UI", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label11.Location = New System.Drawing.Point(383, 90)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(154, 30)
        Me.Label11.TabIndex = 75
        Me.Label11.Text = "部品番号:"
        Me.Label11.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'cmbBUHIN_NO
        '
        Me.cmbBUHIN_NO.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cmbBUHIN_NO.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cmbBUHIN_NO.BackColor = System.Drawing.SystemColors.Window
        Me.tlpFilter.SetColumnSpan(Me.cmbBUHIN_NO, 6)
        Me.cmbBUHIN_NO.Cursor = System.Windows.Forms.Cursors.Default
        Me.cmbBUHIN_NO.Font = New System.Drawing.Font("Meiryo UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.cmbBUHIN_NO.ForeColor = System.Drawing.SystemColors.ControlText
        Me.cmbBUHIN_NO.FormattingEnabled = True
        Me.cmbBUHIN_NO.GotFocusedColor = System.Drawing.Color.FromArgb(CType(CType(190, Byte), Integer), CType(CType(180, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.cmbBUHIN_NO.ImeMode = System.Windows.Forms.ImeMode.[On]
        Me.cmbBUHIN_NO.Location = New System.Drawing.Point(543, 93)
        Me.cmbBUHIN_NO.Name = "cmbBUHIN_NO"
        Me.cmbBUHIN_NO.Selected = False
        Me.cmbBUHIN_NO.Size = New System.Drawing.Size(114, 25)
        Me.cmbBUHIN_NO.TabIndex = 71
        Me.cmbBUHIN_NO.Text = "(選択)"
        '
        'btnSECH_BUHIN
        '
        Me.tlpFilter.SetColumnSpan(Me.btnSECH_BUHIN, 3)
        Me.btnSECH_BUHIN.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnSECH_BUHIN.Location = New System.Drawing.Point(663, 93)
        Me.btnSECH_BUHIN.Name = "btnSECH_BUHIN"
        Me.btnSECH_BUHIN.Size = New System.Drawing.Size(54, 24)
        Me.btnSECH_BUHIN.TabIndex = 99
        Me.btnSECH_BUHIN.Text = "検索"
        Me.btnSECH_BUHIN.UseVisualStyleBackColor = True
        Me.btnSECH_BUHIN.Visible = False
        '
        'cmbHOKUKO_NAME
        '
        Me.cmbHOKUKO_NAME.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cmbHOKUKO_NAME.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cmbHOKUKO_NAME.BackColor = System.Drawing.SystemColors.Window
        Me.tlpFilter.SetColumnSpan(Me.cmbHOKUKO_NAME, 12)
        Me.cmbHOKUKO_NAME.Cursor = System.Windows.Forms.Cursors.Default
        Me.cmbHOKUKO_NAME.Font = New System.Drawing.Font("Meiryo UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.cmbHOKUKO_NAME.ForeColor = System.Drawing.SystemColors.ControlText
        Me.cmbHOKUKO_NAME.FormattingEnabled = True
        Me.cmbHOKUKO_NAME.GotFocusedColor = System.Drawing.Color.FromArgb(CType(CType(190, Byte), Integer), CType(CType(180, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.cmbHOKUKO_NAME.ImeMode = System.Windows.Forms.ImeMode.[On]
        Me.cmbHOKUKO_NAME.Location = New System.Drawing.Point(883, 63)
        Me.cmbHOKUKO_NAME.Name = "cmbHOKUKO_NAME"
        Me.cmbHOKUKO_NAME.Selected = False
        Me.cmbHOKUKO_NAME.Size = New System.Drawing.Size(234, 25)
        Me.cmbHOKUKO_NAME.TabIndex = 84
        Me.cmbHOKUKO_NAME.Text = "(選択)"
        '
        'mtxHINMEI
        '
        Me.mtxHINMEI.BackColor = System.Drawing.SystemColors.Window
        Me.tlpFilter.SetColumnSpan(Me.mtxHINMEI, 12)
        Me.mtxHINMEI.GotFocusedColor = System.Drawing.Color.FromArgb(CType(CType(190, Byte), Integer), CType(CType(180, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.mtxHINMEI.ImeMode = System.Windows.Forms.ImeMode.Disable
        Me.mtxHINMEI.InputRequired = False
        Me.mtxHINMEI.Location = New System.Drawing.Point(883, 93)
        Me.mtxHINMEI.Name = "mtxHINMEI"
        Me.mtxHINMEI.Size = New System.Drawing.Size(234, 24)
        Me.mtxHINMEI.TabIndex = 82
        Me.mtxHINMEI.WatermarkColor = System.Drawing.Color.Empty
        Me.mtxHINMEI.WatermarkText = Nothing
        '
        'cmbSINSA_HANTEI_KB
        '
        Me.cmbSINSA_HANTEI_KB.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cmbSINSA_HANTEI_KB.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cmbSINSA_HANTEI_KB.BackColor = System.Drawing.SystemColors.Window
        Me.tlpFilter.SetColumnSpan(Me.cmbSINSA_HANTEI_KB, 8)
        Me.cmbSINSA_HANTEI_KB.Cursor = System.Windows.Forms.Cursors.Default
        Me.cmbSINSA_HANTEI_KB.Font = New System.Drawing.Font("Meiryo UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.cmbSINSA_HANTEI_KB.ForeColor = System.Drawing.SystemColors.ControlText
        Me.cmbSINSA_HANTEI_KB.FormattingEnabled = True
        Me.cmbSINSA_HANTEI_KB.GotFocusedColor = System.Drawing.Color.FromArgb(CType(CType(190, Byte), Integer), CType(CType(180, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.cmbSINSA_HANTEI_KB.ImeMode = System.Windows.Forms.ImeMode.[On]
        Me.cmbSINSA_HANTEI_KB.Location = New System.Drawing.Point(163, 123)
        Me.cmbSINSA_HANTEI_KB.Name = "cmbSINSA_HANTEI_KB"
        Me.cmbSINSA_HANTEI_KB.Selected = False
        Me.cmbSINSA_HANTEI_KB.Size = New System.Drawing.Size(154, 25)
        Me.cmbSINSA_HANTEI_KB.TabIndex = 68
        Me.cmbSINSA_HANTEI_KB.Text = "(選択)"
        '
        'cmbSAISIN_HANTEI_KB
        '
        Me.cmbSAISIN_HANTEI_KB.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cmbSAISIN_HANTEI_KB.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cmbSAISIN_HANTEI_KB.BackColor = System.Drawing.SystemColors.Window
        Me.tlpFilter.SetColumnSpan(Me.cmbSAISIN_HANTEI_KB, 8)
        Me.cmbSAISIN_HANTEI_KB.Cursor = System.Windows.Forms.Cursors.Default
        Me.cmbSAISIN_HANTEI_KB.Font = New System.Drawing.Font("Meiryo UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.cmbSAISIN_HANTEI_KB.ForeColor = System.Drawing.SystemColors.ControlText
        Me.cmbSAISIN_HANTEI_KB.FormattingEnabled = True
        Me.cmbSAISIN_HANTEI_KB.GotFocusedColor = System.Drawing.Color.FromArgb(CType(CType(190, Byte), Integer), CType(CType(180, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.cmbSAISIN_HANTEI_KB.ImeMode = System.Windows.Forms.ImeMode.[On]
        Me.cmbSAISIN_HANTEI_KB.Location = New System.Drawing.Point(543, 123)
        Me.cmbSAISIN_HANTEI_KB.Name = "cmbSAISIN_HANTEI_KB"
        Me.cmbSAISIN_HANTEI_KB.Selected = False
        Me.cmbSAISIN_HANTEI_KB.Size = New System.Drawing.Size(154, 25)
        Me.cmbSAISIN_HANTEI_KB.TabIndex = 77
        Me.cmbSAISIN_HANTEI_KB.Text = "(選択)"
        '
        'btnClearSrchFilter
        '
        Me.tlpFilter.SetColumnSpan(Me.btnClearSrchFilter, 4)
        Me.btnClearSrchFilter.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnClearSrchFilter.Location = New System.Drawing.Point(1143, 93)
        Me.btnClearSrchFilter.Name = "btnClearSrchFilter"
        Me.tlpFilter.SetRowSpan(Me.btnClearSrchFilter, 2)
        Me.btnClearSrchFilter.Size = New System.Drawing.Size(74, 54)
        Me.btnClearSrchFilter.TabIndex = 100
        Me.btnClearSrchFilter.Text = "条件クリア"
        Me.btnClearSrchFilter.UseVisualStyleBackColor = True
        '
        'chkClosedRowVisibled
        '
        Me.chkClosedRowVisibled.AutoSize = True
        Me.tlpFilter.SetColumnSpan(Me.chkClosedRowVisibled, 7)
        Me.chkClosedRowVisibled.Cursor = System.Windows.Forms.Cursors.Hand
        Me.chkClosedRowVisibled.Font = New System.Drawing.Font("Meiryo UI", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.chkClosedRowVisibled.Location = New System.Drawing.Point(1003, 123)
        Me.chkClosedRowVisibled.Name = "chkClosedRowVisibled"
        Me.chkClosedRowVisibled.Size = New System.Drawing.Size(121, 21)
        Me.chkClosedRowVisibled.TabIndex = 1
        Me.chkClosedRowVisibled.Text = "クローズ済も表示"
        Me.chkClosedRowVisibled.UseVisualStyleBackColor = True
        '
        'Label12
        '
        Me.tlpFilter.SetColumnSpan(Me.Label12, 8)
        Me.Label12.Font = New System.Drawing.Font("Meiryo UI", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label12.Location = New System.Drawing.Point(723, 120)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(154, 30)
        Me.Label12.TabIndex = 76
        Me.Label12.Text = "製品・是正処置:"
        Me.Label12.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label14
        '
        Me.tlpFilter.SetColumnSpan(Me.Label14, 5)
        Me.Label14.Font = New System.Drawing.Font("Meiryo UI", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label14.Location = New System.Drawing.Point(783, 90)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(94, 30)
        Me.Label14.TabIndex = 79
        Me.Label14.Text = "部品名称:"
        Me.Label14.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label10
        '
        Me.tlpFilter.SetColumnSpan(Me.Label10, 7)
        Me.Label10.Font = New System.Drawing.Font("Meiryo UI", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label10.Location = New System.Drawing.Point(743, 60)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(134, 30)
        Me.Label10.TabIndex = 83
        Me.Label10.Text = "報告書名:"
        Me.Label10.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'cmbSYOCHI_KB
        '
        Me.cmbSYOCHI_KB.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cmbSYOCHI_KB.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cmbSYOCHI_KB.BackColor = System.Drawing.SystemColors.Window
        Me.tlpFilter.SetColumnSpan(Me.cmbSYOCHI_KB, 4)
        Me.cmbSYOCHI_KB.Cursor = System.Windows.Forms.Cursors.Default
        Me.cmbSYOCHI_KB.Font = New System.Drawing.Font("Meiryo UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.cmbSYOCHI_KB.ForeColor = System.Drawing.SystemColors.ControlText
        Me.cmbSYOCHI_KB.FormattingEnabled = True
        Me.cmbSYOCHI_KB.GotFocusedColor = System.Drawing.Color.FromArgb(CType(CType(190, Byte), Integer), CType(CType(180, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.cmbSYOCHI_KB.ImeMode = System.Windows.Forms.ImeMode.[On]
        Me.cmbSYOCHI_KB.Location = New System.Drawing.Point(883, 123)
        Me.cmbSYOCHI_KB.Name = "cmbSYOCHI_KB"
        Me.cmbSYOCHI_KB.Selected = False
        Me.cmbSYOCHI_KB.Size = New System.Drawing.Size(74, 25)
        Me.cmbSYOCHI_KB.TabIndex = 72
        Me.cmbSYOCHI_KB.Text = "(選択)"
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
        DataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle7.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle7.Font = New System.Drawing.Font("MS UI Gothic", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        DataGridViewCellStyle7.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle7.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle7.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle7.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgvDATA.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle7
        Me.dgvDATA.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        DataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle8.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle8.Font = New System.Drawing.Font("MS UI Gothic", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        DataGridViewCellStyle8.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle8.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle8.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle8.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.dgvDATA.DefaultCellStyle = DataGridViewCellStyle8
        Me.dgvDATA.Location = New System.Drawing.Point(12, 240)
        Me.dgvDATA.Name = "dgvDATA"
        DataGridViewCellStyle9.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle9.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle9.Font = New System.Drawing.Font("MS UI Gothic", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        DataGridViewCellStyle9.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle9.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle9.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle9.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgvDATA.RowHeadersDefaultCellStyle = DataGridViewCellStyle9
        Me.dgvDATA.RowTemplate.Height = 21
        Me.dgvDATA.Size = New System.Drawing.Size(1233, 322)
        Me.dgvDATA.TabIndex = 62
        '
        'FrmG0010
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.ClientSize = New System.Drawing.Size(1264, 712)
        Me.Controls.Add(Me.dgvDATA)
        Me.Controls.Add(Me.flxDATA)
        Me.Controls.Add(Me.gbxFilter)
        Me.HelpButton = True
        Me.Name = "FrmG0010"
        Me.ShowStatusBar = True
        Me.Text = ""
        Me.Controls.SetChildIndex(Me.gbxFilter, 0)
        Me.Controls.SetChildIndex(Me.flxDATA, 0)
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
        Me.Controls.SetChildIndex(Me.dgvDATA, 0)
        CType(Me.ErrorProvider, System.ComponentModel.ISupportInitialize).EndInit()
        Me.gbxFilter.ResumeLayout(False)
        Me.tlpFilter.ResumeLayout(False)
        Me.tlpFilter.PerformLayout()
        CType(Me.flxDATA, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dgvDATA, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Label3 As Label
    Friend WithEvents cmbSTAGE_NCR As ComboboxEx
    Friend WithEvents gbxFilter As GroupBox
    Friend WithEvents chkClosedRowVisibled As CheckBox
    Friend WithEvents tlpFilter As TableLayoutPanel
    Friend WithEvents Label1 As Label
    Friend WithEvents cmbSTAGE_CAR As ComboboxEx
    Friend WithEvents Label2 As Label
    Friend WithEvents dtDraftFrom As DateTextBoxEx
    Friend WithEvents Label4 As Label
    Friend WithEvents dtDraftTo As DateTextBoxEx
    Friend WithEvents Label5 As Label
    Friend WithEvents dtExecFrom As DateTextBoxEx
    Friend WithEvents dtExecTo As DateTextBoxEx
    Friend WithEvents Label7 As Label
    Friend WithEvents Label6 As Label
    Friend WithEvents cmbSINSA_HANTEI_KB As ComboboxEx
    Friend WithEvents Label8 As Label
    Friend WithEvents cmbTANTO As ComboboxEx
    Friend WithEvents cmbSYOCHI_KB As ComboboxEx
    Friend WithEvents cmbBUHIN_NO As ComboboxEx
    Friend WithEvents Label11 As Label
    Friend WithEvents Label12 As Label
    Friend WithEvents cmbSAISIN_HANTEI_KB As ComboboxEx
    Friend WithEvents cmbKISYU As ComboboxEx
    Friend WithEvents Label9 As Label
    Friend WithEvents Label14 As Label
    Friend WithEvents Label15 As Label
    Friend WithEvents Label16 As Label
    Friend WithEvents mtxHINMEI As MaskedTextBoxEx
    Friend WithEvents mtxHOKUKO_NO As MaskedTextBoxEx
    Friend WithEvents Label10 As Label
    Friend WithEvents cmbHOKUKO_NAME As ComboboxEx
    Friend WithEvents btnSECH_BUHIN As Button
    Friend WithEvents btnClearSrchFilter As Button
    Friend WithEvents flxDATA As C1.Win.C1FlexGrid.C1FlexGrid
    Friend WithEvents dgvDATA As DataGridView
End Class
