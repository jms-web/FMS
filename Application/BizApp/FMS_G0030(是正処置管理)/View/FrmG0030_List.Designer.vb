<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class FrmG0030_List
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
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmG0030_List))
        Me.tlpFilter = New System.Windows.Forms.TableLayoutPanel()
        Me.lblHOKUKO_NO = New System.Windows.Forms.Label()
        Me.mtxHOKUKO_NO = New JMS_COMMON.MaskedTextBoxEx()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.cmbBUMON = New JMS_COMMON.ComboboxEx()
        Me.Label14 = New System.Windows.Forms.Label()
        Me.cmbADD_TANTO = New JMS_COMMON.ComboboxEx()
        Me.lblGEN_TANTO = New System.Windows.Forms.Label()
        Me.cmbGEN_TANTO = New JMS_COMMON.ComboboxEx()
        Me.chkClosedRowVisibled = New System.Windows.Forms.CheckBox()
        Me.chkTairyu = New System.Windows.Forms.CheckBox()
        Me.chkDeleteRowVisibled = New System.Windows.Forms.CheckBox()
        Me.btnClearSrchFilter = New System.Windows.Forms.Button()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.dgvDATA = New System.Windows.Forms.DataGridView()
        Me.FlexContextMenu = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.EqualFilter = New System.Windows.Forms.ToolStripMenuItem()
        Me.NotEqualFilter = New System.Windows.Forms.ToolStripMenuItem()
        Me.IncludeFilter = New System.Windows.Forms.ToolStripMenuItem()
        Me.NotIncludeFilter = New System.Windows.Forms.ToolStripMenuItem()
        Me.flxDATA = New C1.Win.C1FlexGrid.C1FlexGrid()
        Me.V015ZESEIICHIRANBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.lblDEV_FLG = New System.Windows.Forms.Label()
        CType(Me.ErrorProvider, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.WarningErrorProvider, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.tlpFilter.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        CType(Me.dgvDATA, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.FlexContextMenu.SuspendLayout()
        CType(Me.flxDATA, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.V015ZESEIICHIRANBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'lblRecordCount
        '
        Me.lblRecordCount.ForeColor = System.Drawing.SystemColors.ControlText
        Me.lblRecordCount.Location = New System.Drawing.Point(9, 613)
        Me.lblRecordCount.Size = New System.Drawing.Size(407, 24)
        '
        'cmdFunc1
        '
        Me.cmdFunc1.Enabled = False
        Me.cmdFunc1.Font = New System.Drawing.Font("Meiryo UI", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.cmdFunc1.Image = Global.FMS.My.Resources.Resources._imgSearch32x32
        Me.cmdFunc1.Location = New System.Drawing.Point(12, 640)
        Me.cmdFunc1.Size = New System.Drawing.Size(132, 42)
        Me.cmdFunc1.Text = "検索(F1)"
        '
        'cmdFunc2
        '
        Me.cmdFunc2.Font = New System.Drawing.Font("Meiryo UI", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.cmdFunc2.Image = Global.FMS.My.Resources.Resources._imgApplication_form_add32x32
        Me.cmdFunc2.Location = New System.Drawing.Point(150, 640)
        Me.cmdFunc2.Size = New System.Drawing.Size(132, 42)
        Me.cmdFunc2.Text = "新規作成" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "[発生](F2)"
        '
        'cmdFunc3
        '
        Me.cmdFunc3.Font = New System.Drawing.Font("Meiryo UI", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.cmdFunc3.Image = Global.FMS.My.Resources.Resources._imgApplication_form_add32x32
        Me.cmdFunc3.Location = New System.Drawing.Point(288, 640)
        Me.cmdFunc3.Size = New System.Drawing.Size(132, 42)
        Me.cmdFunc3.Text = "新規作成" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "[流出](F3)"
        '
        'cmdFunc4
        '
        Me.cmdFunc4.Font = New System.Drawing.Font("Meiryo UI", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.cmdFunc4.Image = Global.FMS.My.Resources.Resources._imgApplication_form_edit32x32
        Me.cmdFunc4.Location = New System.Drawing.Point(426, 640)
        Me.cmdFunc4.Size = New System.Drawing.Size(132, 42)
        Me.cmdFunc4.Text = "変更・承認(F4)"
        '
        'cmdFunc5
        '
        Me.cmdFunc5.Font = New System.Drawing.Font("Meiryo UI", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.cmdFunc5.Image = Global.FMS.My.Resources.Resources._imgStatusAnnotations_Blocked32x32_SM
        Me.cmdFunc5.Location = New System.Drawing.Point(564, 640)
        Me.cmdFunc5.Size = New System.Drawing.Size(132, 42)
        Me.cmdFunc5.Text = "取消(F5)"
        '
        'cmdFunc6
        '
        Me.cmdFunc6.Font = New System.Drawing.Font("Meiryo UI", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.cmdFunc6.Image = Global.FMS.My.Resources.Resources._imgRecovery32x32
        Me.cmdFunc6.Location = New System.Drawing.Point(991, 12)
        Me.cmdFunc6.Size = New System.Drawing.Size(12, 42)
        Me.cmdFunc6.Text = "復元(F6)"
        Me.cmdFunc6.Visible = False
        '
        'cmdFunc12
        '
        Me.cmdFunc12.Font = New System.Drawing.Font("Meiryo UI", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.cmdFunc12.Image = Global.FMS.My.Resources.Resources._imgLog_Out32x32
        Me.cmdFunc12.Location = New System.Drawing.Point(1254, 640)
        Me.cmdFunc12.Size = New System.Drawing.Size(132, 42)
        Me.cmdFunc12.Text = "閉じる(F12)"
        '
        'cmdFunc11
        '
        Me.cmdFunc11.Font = New System.Drawing.Font("Meiryo UI", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.cmdFunc11.Image = Global.FMS.My.Resources.Resources.履歴
        Me.cmdFunc11.Location = New System.Drawing.Point(1116, 640)
        Me.cmdFunc11.Size = New System.Drawing.Size(132, 42)
        Me.cmdFunc11.Text = "履歴(F11)"
        '
        'cmdFunc10
        '
        Me.cmdFunc10.Font = New System.Drawing.Font("Meiryo UI", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.cmdFunc10.Image = Global.FMS.My.Resources.Resources._imgPrint32x32
        Me.cmdFunc10.Location = New System.Drawing.Point(978, 640)
        Me.cmdFunc10.Size = New System.Drawing.Size(132, 42)
        Me.cmdFunc10.Text = "印刷プレビュー(F10)"
        '
        'cmdFunc7
        '
        Me.cmdFunc7.Enabled = False
        Me.cmdFunc7.Font = New System.Drawing.Font("Meiryo UI", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.cmdFunc7.Location = New System.Drawing.Point(1533, -135)
        Me.cmdFunc7.Size = New System.Drawing.Size(10, 42)
        '
        'cmdFunc9
        '
        Me.cmdFunc9.Font = New System.Drawing.Font("Meiryo UI", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.cmdFunc9.Image = Global.FMS.My.Resources.Resources._imgSendMail2
        Me.cmdFunc9.Location = New System.Drawing.Point(840, 640)
        Me.cmdFunc9.Size = New System.Drawing.Size(132, 42)
        Me.cmdFunc9.Text = "滞留通知メール送信(F9)"
        Me.cmdFunc9.Visible = False
        '
        'cmdFunc8
        '
        Me.cmdFunc8.Font = New System.Drawing.Font("Meiryo UI", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.cmdFunc8.Image = Global.FMS.My.Resources.Resources._imgExportToExcel32x32
        Me.cmdFunc8.Location = New System.Drawing.Point(702, 640)
        Me.cmdFunc8.Size = New System.Drawing.Size(132, 42)
        Me.cmdFunc8.Text = "CSV出力(F8)"
        Me.cmdFunc8.Visible = False
        '
        'lblTytle
        '
        Me.lblTytle.Font = New System.Drawing.Font("Meiryo UI", 24.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTytle.ForeColor = System.Drawing.SystemColors.ControlText
        Me.lblTytle.Size = New System.Drawing.Size(1373, 45)
        Me.lblTytle.Text = "是正処置要求書 検索画面"
        '
        'tlpFilter
        '
        Me.tlpFilter.ColumnCount = 71
        Me.tlpFilter.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20.0!))
        Me.tlpFilter.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20.0!))
        Me.tlpFilter.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20.0!))
        Me.tlpFilter.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20.0!))
        Me.tlpFilter.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20.0!))
        Me.tlpFilter.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20.0!))
        Me.tlpFilter.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20.0!))
        Me.tlpFilter.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20.0!))
        Me.tlpFilter.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20.0!))
        Me.tlpFilter.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20.0!))
        Me.tlpFilter.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20.0!))
        Me.tlpFilter.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20.0!))
        Me.tlpFilter.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20.0!))
        Me.tlpFilter.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20.0!))
        Me.tlpFilter.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20.0!))
        Me.tlpFilter.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20.0!))
        Me.tlpFilter.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20.0!))
        Me.tlpFilter.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20.0!))
        Me.tlpFilter.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20.0!))
        Me.tlpFilter.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20.0!))
        Me.tlpFilter.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20.0!))
        Me.tlpFilter.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20.0!))
        Me.tlpFilter.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20.0!))
        Me.tlpFilter.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20.0!))
        Me.tlpFilter.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20.0!))
        Me.tlpFilter.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20.0!))
        Me.tlpFilter.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20.0!))
        Me.tlpFilter.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20.0!))
        Me.tlpFilter.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20.0!))
        Me.tlpFilter.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20.0!))
        Me.tlpFilter.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20.0!))
        Me.tlpFilter.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20.0!))
        Me.tlpFilter.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20.0!))
        Me.tlpFilter.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20.0!))
        Me.tlpFilter.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20.0!))
        Me.tlpFilter.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20.0!))
        Me.tlpFilter.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20.0!))
        Me.tlpFilter.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20.0!))
        Me.tlpFilter.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20.0!))
        Me.tlpFilter.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20.0!))
        Me.tlpFilter.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20.0!))
        Me.tlpFilter.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20.0!))
        Me.tlpFilter.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20.0!))
        Me.tlpFilter.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20.0!))
        Me.tlpFilter.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20.0!))
        Me.tlpFilter.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20.0!))
        Me.tlpFilter.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20.0!))
        Me.tlpFilter.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20.0!))
        Me.tlpFilter.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20.0!))
        Me.tlpFilter.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20.0!))
        Me.tlpFilter.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20.0!))
        Me.tlpFilter.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20.0!))
        Me.tlpFilter.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20.0!))
        Me.tlpFilter.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20.0!))
        Me.tlpFilter.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20.0!))
        Me.tlpFilter.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20.0!))
        Me.tlpFilter.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20.0!))
        Me.tlpFilter.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20.0!))
        Me.tlpFilter.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20.0!))
        Me.tlpFilter.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20.0!))
        Me.tlpFilter.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20.0!))
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
        Me.tlpFilter.Controls.Add(Me.lblHOKUKO_NO, 0, 0)
        Me.tlpFilter.Controls.Add(Me.mtxHOKUKO_NO, 5, 0)
        Me.tlpFilter.Controls.Add(Me.Label1, 12, 0)
        Me.tlpFilter.Controls.Add(Me.cmbBUMON, 17, 0)
        Me.tlpFilter.Controls.Add(Me.Label14, 0, 1)
        Me.tlpFilter.Controls.Add(Me.cmbADD_TANTO, 5, 1)
        Me.tlpFilter.Controls.Add(Me.lblGEN_TANTO, 12, 1)
        Me.tlpFilter.Controls.Add(Me.cmbGEN_TANTO, 17, 1)
        Me.tlpFilter.Controls.Add(Me.chkClosedRowVisibled, 31, 0)
        Me.tlpFilter.Controls.Add(Me.chkTairyu, 25, 0)
        Me.tlpFilter.Controls.Add(Me.chkDeleteRowVisibled, 32, 1)
        Me.tlpFilter.Controls.Add(Me.btnClearSrchFilter, 40, 0)
        Me.tlpFilter.Dock = System.Windows.Forms.DockStyle.Fill
        Me.tlpFilter.Location = New System.Drawing.Point(3, 19)
        Me.tlpFilter.Name = "tlpFilter"
        Me.tlpFilter.RowCount = 4
        Me.tlpFilter.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30.0!))
        Me.tlpFilter.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30.0!))
        Me.tlpFilter.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30.0!))
        Me.tlpFilter.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.tlpFilter.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20.0!))
        Me.tlpFilter.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20.0!))
        Me.tlpFilter.Size = New System.Drawing.Size(1367, 66)
        Me.tlpFilter.TabIndex = 56
        '
        'lblHOKUKO_NO
        '
        Me.tlpFilter.SetColumnSpan(Me.lblHOKUKO_NO, 5)
        Me.lblHOKUKO_NO.Font = New System.Drawing.Font("Meiryo UI", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.lblHOKUKO_NO.Location = New System.Drawing.Point(3, 0)
        Me.lblHOKUKO_NO.Name = "lblHOKUKO_NO"
        Me.lblHOKUKO_NO.Size = New System.Drawing.Size(94, 30)
        Me.lblHOKUKO_NO.TabIndex = 69
        Me.lblHOKUKO_NO.Text = "No:"
        Me.lblHOKUKO_NO.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'mtxHOKUKO_NO
        '
        Me.mtxHOKUKO_NO.BackColor = System.Drawing.SystemColors.Window
        Me.tlpFilter.SetColumnSpan(Me.mtxHOKUKO_NO, 7)
        Me.mtxHOKUKO_NO.ImeMode = System.Windows.Forms.ImeMode.Disable
        Me.mtxHOKUKO_NO.InputRequired = False
        Me.mtxHOKUKO_NO.Location = New System.Drawing.Point(103, 3)
        Me.mtxHOKUKO_NO.MaxByteLength = 10
        Me.mtxHOKUKO_NO.Name = "mtxHOKUKO_NO"
        Me.mtxHOKUKO_NO.SelectAllText = False
        Me.mtxHOKUKO_NO.Size = New System.Drawing.Size(134, 23)
        Me.mtxHOKUKO_NO.TabIndex = 1
        Me.mtxHOKUKO_NO.WatermarkColor = System.Drawing.Color.Empty
        Me.mtxHOKUKO_NO.WatermarkText = Nothing
        '
        'Label1
        '
        Me.tlpFilter.SetColumnSpan(Me.Label1, 5)
        Me.Label1.Font = New System.Drawing.Font("Meiryo UI", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label1.Location = New System.Drawing.Point(243, 0)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(94, 30)
        Me.Label1.TabIndex = 101
        Me.Label1.Text = "部門:"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'cmbBUMON
        '
        Me.cmbBUMON.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cmbBUMON.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cmbBUMON.BackColor = System.Drawing.SystemColors.Window
        Me.tlpFilter.SetColumnSpan(Me.cmbBUMON, 7)
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
        Me.cmbBUMON.Size = New System.Drawing.Size(134, 25)
        Me.cmbBUMON.TabIndex = 2
        Me.cmbBUMON.ValueMember = "VALUE"
        '
        'Label14
        '
        Me.tlpFilter.SetColumnSpan(Me.Label14, 5)
        Me.Label14.Font = New System.Drawing.Font("Meiryo UI", 9.0!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Underline), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label14.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.Label14.Location = New System.Drawing.Point(3, 30)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(94, 30)
        Me.Label14.TabIndex = 108
        Me.Label14.Text = "起草者:"
        Me.Label14.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.ToolTip.SetToolTip(Me.Label14, "対象者:所属部門の担当者全て")
        '
        'cmbADD_TANTO
        '
        Me.cmbADD_TANTO.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cmbADD_TANTO.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cmbADD_TANTO.BackColor = System.Drawing.SystemColors.Window
        Me.tlpFilter.SetColumnSpan(Me.cmbADD_TANTO, 7)
        Me.cmbADD_TANTO.Cursor = System.Windows.Forms.Cursors.Default
        Me.cmbADD_TANTO.DisplayMember = "DISP"
        Me.cmbADD_TANTO.Font = New System.Drawing.Font("Meiryo UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.cmbADD_TANTO.ForeColor = System.Drawing.SystemColors.ControlText
        Me.cmbADD_TANTO.FormattingEnabled = True
        Me.cmbADD_TANTO.HorizontalContentAlignment = System.Drawing.StringAlignment.Near
        Me.cmbADD_TANTO.ImeMode = System.Windows.Forms.ImeMode.Disable
        Me.cmbADD_TANTO.IsSelected = False
        Me.cmbADD_TANTO.Location = New System.Drawing.Point(103, 33)
        Me.cmbADD_TANTO.Name = "cmbADD_TANTO"
        Me.cmbADD_TANTO.NullValue = " "
        Me.cmbADD_TANTO.Size = New System.Drawing.Size(134, 25)
        Me.cmbADD_TANTO.TabIndex = 3
        Me.cmbADD_TANTO.ValueMember = "VALUE"
        '
        'lblGEN_TANTO
        '
        Me.tlpFilter.SetColumnSpan(Me.lblGEN_TANTO, 5)
        Me.lblGEN_TANTO.Font = New System.Drawing.Font("Meiryo UI", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.lblGEN_TANTO.Location = New System.Drawing.Point(243, 30)
        Me.lblGEN_TANTO.Name = "lblGEN_TANTO"
        Me.lblGEN_TANTO.Size = New System.Drawing.Size(94, 30)
        Me.lblGEN_TANTO.TabIndex = 68
        Me.lblGEN_TANTO.Text = "現処置担当者:"
        Me.lblGEN_TANTO.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'cmbGEN_TANTO
        '
        Me.cmbGEN_TANTO.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cmbGEN_TANTO.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cmbGEN_TANTO.BackColor = System.Drawing.SystemColors.Window
        Me.tlpFilter.SetColumnSpan(Me.cmbGEN_TANTO, 7)
        Me.cmbGEN_TANTO.Cursor = System.Windows.Forms.Cursors.Default
        Me.cmbGEN_TANTO.DisplayMember = "DISP"
        Me.cmbGEN_TANTO.Font = New System.Drawing.Font("Meiryo UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.cmbGEN_TANTO.ForeColor = System.Drawing.SystemColors.ControlText
        Me.cmbGEN_TANTO.FormattingEnabled = True
        Me.cmbGEN_TANTO.HorizontalContentAlignment = System.Drawing.StringAlignment.Near
        Me.cmbGEN_TANTO.ImeMode = System.Windows.Forms.ImeMode.Disable
        Me.cmbGEN_TANTO.IsSelected = False
        Me.cmbGEN_TANTO.Location = New System.Drawing.Point(343, 33)
        Me.cmbGEN_TANTO.Name = "cmbGEN_TANTO"
        Me.cmbGEN_TANTO.NullValue = " "
        Me.cmbGEN_TANTO.Size = New System.Drawing.Size(134, 25)
        Me.cmbGEN_TANTO.TabIndex = 4
        Me.cmbGEN_TANTO.ValueMember = "VALUE"
        '
        'chkClosedRowVisibled
        '
        Me.chkClosedRowVisibled.AutoSize = True
        Me.tlpFilter.SetColumnSpan(Me.chkClosedRowVisibled, 7)
        Me.chkClosedRowVisibled.Cursor = System.Windows.Forms.Cursors.Hand
        Me.chkClosedRowVisibled.Font = New System.Drawing.Font("Meiryo UI", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.chkClosedRowVisibled.Location = New System.Drawing.Point(643, 3)
        Me.chkClosedRowVisibled.Name = "chkClosedRowVisibled"
        Me.chkClosedRowVisibled.Size = New System.Drawing.Size(113, 21)
        Me.chkClosedRowVisibled.TabIndex = 6
        Me.chkClosedRowVisibled.Text = "Close済も表示"
        Me.chkClosedRowVisibled.UseVisualStyleBackColor = True
        '
        'chkTairyu
        '
        Me.chkTairyu.AutoSize = True
        Me.tlpFilter.SetColumnSpan(Me.chkTairyu, 7)
        Me.chkTairyu.Cursor = System.Windows.Forms.Cursors.Hand
        Me.chkTairyu.Font = New System.Drawing.Font("Meiryo UI", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.chkTairyu.Location = New System.Drawing.Point(503, 3)
        Me.chkTairyu.Name = "chkTairyu"
        Me.chkTairyu.Size = New System.Drawing.Size(102, 21)
        Me.chkTairyu.TabIndex = 5
        Me.chkTairyu.Text = "滞留のみ表示"
        Me.chkTairyu.UseVisualStyleBackColor = True
        Me.chkTairyu.Visible = False
        '
        'chkDeleteRowVisibled
        '
        Me.chkDeleteRowVisibled.AutoSize = True
        Me.tlpFilter.SetColumnSpan(Me.chkDeleteRowVisibled, 6)
        Me.chkDeleteRowVisibled.Cursor = System.Windows.Forms.Cursors.Hand
        Me.chkDeleteRowVisibled.Font = New System.Drawing.Font("Meiryo UI", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.chkDeleteRowVisibled.Location = New System.Drawing.Point(643, 33)
        Me.chkDeleteRowVisibled.Name = "chkDeleteRowVisibled"
        Me.chkDeleteRowVisibled.Size = New System.Drawing.Size(103, 21)
        Me.chkDeleteRowVisibled.TabIndex = 7
        Me.chkDeleteRowVisibled.Text = "削除済も表示"
        Me.chkDeleteRowVisibled.UseVisualStyleBackColor = True
        '
        'btnClearSrchFilter
        '
        Me.tlpFilter.SetColumnSpan(Me.btnClearSrchFilter, 5)
        Me.btnClearSrchFilter.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnClearSrchFilter.Location = New System.Drawing.Point(803, 3)
        Me.btnClearSrchFilter.Name = "btnClearSrchFilter"
        Me.tlpFilter.SetRowSpan(Me.btnClearSrchFilter, 2)
        Me.btnClearSrchFilter.Size = New System.Drawing.Size(94, 54)
        Me.btnClearSrchFilter.TabIndex = 8
        Me.btnClearSrchFilter.Text = "条件クリア"
        Me.btnClearSrchFilter.UseVisualStyleBackColor = True
        '
        'GroupBox1
        '
        Me.GroupBox1.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GroupBox1.Controls.Add(Me.tlpFilter)
        Me.GroupBox1.Font = New System.Drawing.Font("Meiryo UI", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.GroupBox1.Location = New System.Drawing.Point(12, 60)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(1373, 88)
        Me.GroupBox1.TabIndex = 1
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "共通検索条件"
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
        Me.dgvDATA.Location = New System.Drawing.Point(84, 12)
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
        Me.dgvDATA.Size = New System.Drawing.Size(75, 26)
        Me.dgvDATA.TabIndex = 63
        Me.dgvDATA.Visible = False
        '
        'FlexContextMenu
        '
        Me.FlexContextMenu.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.EqualFilter, Me.NotEqualFilter, Me.IncludeFilter, Me.NotIncludeFilter})
        Me.FlexContextMenu.Name = "FlexContextMenu"
        Me.FlexContextMenu.Size = New System.Drawing.Size(158, 92)
        '
        'EqualFilter
        '
        Me.EqualFilter.Name = "EqualFilter"
        Me.EqualFilter.Size = New System.Drawing.Size(157, 22)
        Me.EqualFilter.Text = """{0}"" に等しい"
        '
        'NotEqualFilter
        '
        Me.NotEqualFilter.Name = "NotEqualFilter"
        Me.NotEqualFilter.Size = New System.Drawing.Size(157, 22)
        Me.NotEqualFilter.Text = """{0}"" に等しくない"
        '
        'IncludeFilter
        '
        Me.IncludeFilter.Name = "IncludeFilter"
        Me.IncludeFilter.Size = New System.Drawing.Size(157, 22)
        Me.IncludeFilter.Text = """{0}"" を含む"
        '
        'NotIncludeFilter
        '
        Me.NotIncludeFilter.Name = "NotIncludeFilter"
        Me.NotIncludeFilter.Size = New System.Drawing.Size(157, 22)
        Me.NotIncludeFilter.Text = """{0}"" を含まない"
        '
        'flxDATA
        '
        Me.flxDATA.AllowDragging = C1.Win.C1FlexGrid.AllowDraggingEnum.None
        Me.flxDATA.AllowEditing = False
        Me.flxDATA.AllowFiltering = True
        Me.flxDATA.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.flxDATA.ClipboardCopyMode = C1.Win.C1FlexGrid.ClipboardCopyModeEnum.DataAndColumnHeaders
        Me.flxDATA.ColumnInfo = resources.GetString("flxDATA.ColumnInfo")
        Me.flxDATA.DataSource = Me.V015ZESEIICHIRANBindingSource
        Me.flxDATA.Font = New System.Drawing.Font("Meiryo UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.flxDATA.Location = New System.Drawing.Point(12, 154)
        Me.flxDATA.Name = "flxDATA"
        Me.flxDATA.Rows.Count = 1
        Me.flxDATA.Rows.DefaultSize = 23
        Me.flxDATA.Size = New System.Drawing.Size(1373, 456)
        Me.flxDATA.StyleInfo = resources.GetString("flxDATA.StyleInfo")
        Me.flxDATA.TabIndex = 65
        '
        'V015ZESEIICHIRANBindingSource
        '
        Me.V015ZESEIICHIRANBindingSource.DataSource = GetType(MODEL.V015_ZESEI_ICHIRAN)
        '
        'lblDEV_FLG
        '
        Me.lblDEV_FLG.BackColor = System.Drawing.Color.White
        Me.lblDEV_FLG.Font = New System.Drawing.Font("Meiryo UI", 18.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.lblDEV_FLG.ForeColor = System.Drawing.Color.Red
        Me.lblDEV_FLG.Location = New System.Drawing.Point(16, 17)
        Me.lblDEV_FLG.Name = "lblDEV_FLG"
        Me.lblDEV_FLG.Size = New System.Drawing.Size(183, 35)
        Me.lblDEV_FLG.TabIndex = 337
        Me.lblDEV_FLG.Text = "TESTサーバ版"
        Me.lblDEV_FLG.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.lblDEV_FLG.Visible = False
        '
        'FrmG0030_List
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.ClientSize = New System.Drawing.Size(1404, 711)
        Me.Controls.Add(Me.lblDEV_FLG)
        Me.Controls.Add(Me.flxDATA)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.dgvDATA)
        Me.HelpButton = True
        Me.MinimumSize = New System.Drawing.Size(1280, 750)
        Me.Name = "FrmG0030_List"
        Me.ShowStatusBar = True
        Me.Text = ""
        Me.Controls.SetChildIndex(Me.dgvDATA, 0)
        Me.Controls.SetChildIndex(Me.GroupBox1, 0)
        Me.Controls.SetChildIndex(Me.flxDATA, 0)
        Me.Controls.SetChildIndex(Me.lblRecordCount, 0)
        Me.Controls.SetChildIndex(Me.cmdFunc2, 0)
        Me.Controls.SetChildIndex(Me.cmdFunc4, 0)
        Me.Controls.SetChildIndex(Me.cmdFunc5, 0)
        Me.Controls.SetChildIndex(Me.cmdFunc6, 0)
        Me.Controls.SetChildIndex(Me.cmdFunc1, 0)
        Me.Controls.SetChildIndex(Me.lblTytle, 0)
        Me.Controls.SetChildIndex(Me.cmdFunc8, 0)
        Me.Controls.SetChildIndex(Me.cmdFunc10, 0)
        Me.Controls.SetChildIndex(Me.cmdFunc11, 0)
        Me.Controls.SetChildIndex(Me.cmdFunc12, 0)
        Me.Controls.SetChildIndex(Me.cmdFunc3, 0)
        Me.Controls.SetChildIndex(Me.cmdFunc9, 0)
        Me.Controls.SetChildIndex(Me.cmdFunc7, 0)
        Me.Controls.SetChildIndex(Me.lblDEV_FLG, 0)
        CType(Me.ErrorProvider, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.WarningErrorProvider, System.ComponentModel.ISupportInitialize).EndInit()
        Me.tlpFilter.ResumeLayout(False)
        Me.tlpFilter.PerformLayout()
        Me.GroupBox1.ResumeLayout(False)
        CType(Me.dgvDATA, System.ComponentModel.ISupportInitialize).EndInit()
        Me.FlexContextMenu.ResumeLayout(False)
        CType(Me.flxDATA, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.V015ZESEIICHIRANBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents chkClosedRowVisibled As CheckBox
    Friend WithEvents tlpFilter As TableLayoutPanel
    Friend WithEvents lblHOKUKO_NO As Label
    Friend WithEvents mtxHOKUKO_NO As MaskedTextBoxEx
    Friend WithEvents btnClearSrchFilter As Button
    Friend WithEvents Label1 As Label
    Friend WithEvents cmbBUMON As ComboboxEx
    Friend WithEvents Label14 As Label
    Friend WithEvents cmbADD_TANTO As ComboboxEx
    Friend WithEvents chkTairyu As CheckBox
    Friend WithEvents chkDeleteRowVisibled As CheckBox
    Friend WithEvents dgvDATA As DataGridView
    Friend WithEvents GroupBox1 As GroupBox
    Friend WithEvents FlexContextMenu As ContextMenuStrip
    Friend WithEvents EqualFilter As ToolStripMenuItem
    Friend WithEvents NotEqualFilter As ToolStripMenuItem
    Friend WithEvents IncludeFilter As ToolStripMenuItem
    Friend WithEvents NotIncludeFilter As ToolStripMenuItem
    Friend WithEvents lblGEN_TANTO As Label
    Friend WithEvents cmbGEN_TANTO As ComboboxEx
    Friend WithEvents flxDATA As C1.Win.C1FlexGrid.C1FlexGrid
    Friend WithEvents lblDEV_FLG As Label
    Friend WithEvents V015ZESEIICHIRANBindingSource As BindingSource
End Class
