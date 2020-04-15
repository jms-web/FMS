<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class FrmG0020_List
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmG0020_List))
        Dim DataGridViewCellStyle4 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle5 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle6 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.tlpFilter = New System.Windows.Forms.TableLayoutPanel()
        Me.cmbGEN_TANTO = New JMS_COMMON.ComboboxEx()
        Me.lblGEN_TANTO = New System.Windows.Forms.Label()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.lblHOKUKO_NO = New System.Windows.Forms.Label()
        Me.mtxHOKUKO_NO = New JMS_COMMON.MaskedTextBoxEx()
        Me.cmbKISYU = New JMS_COMMON.ComboboxEx()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.cmbBUMON = New JMS_COMMON.ComboboxEx()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.cmbBUHIN_BANGO = New JMS_COMMON.ComboboxEx()
        Me.Label14 = New System.Windows.Forms.Label()
        Me.cmbADD_TANTO = New JMS_COMMON.ComboboxEx()
        Me.lblSyanaiCD = New System.Windows.Forms.Label()
        Me.cmbSYANAI_CD = New JMS_COMMON.ComboboxEx()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.mtxHINMEI = New JMS_COMMON.MaskedTextBoxEx()
        Me.btnSECH_BUHIN = New System.Windows.Forms.Button()
        Me.chkTairyu = New System.Windows.Forms.CheckBox()
        Me.chkClosedRowVisibled = New System.Windows.Forms.CheckBox()
        Me.chkDeleteRowVisibled = New System.Windows.Forms.CheckBox()
        Me.btnClearSrchFilter = New System.Windows.Forms.Button()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.flxDATA = New C1.Win.C1FlexGrid.C1FlexGrid()
        Me.ST03FUTEKIGOICHIRANBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.dgvDATA = New System.Windows.Forms.DataGridView()
        Me.FlexContextMenu = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.EqualFilter = New System.Windows.Forms.ToolStripMenuItem()
        Me.NotEqualFilter = New System.Windows.Forms.ToolStripMenuItem()
        Me.IncludeFilter = New System.Windows.Forms.ToolStripMenuItem()
        Me.NotIncludeFilter = New System.Windows.Forms.ToolStripMenuItem()
        CType(Me.ErrorProvider, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.WarningErrorProvider, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.tlpFilter.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        CType(Me.flxDATA, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ST03FUTEKIGOICHIRANBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dgvDATA, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.FlexContextMenu.SuspendLayout()
        Me.SuspendLayout()
        '
        'lblRecordCount
        '
        Me.lblRecordCount.ForeColor = System.Drawing.SystemColors.ControlText
        Me.lblRecordCount.Location = New System.Drawing.Point(12, 714)
        Me.lblRecordCount.Size = New System.Drawing.Size(407, 24)
        '
        'cmdFunc1
        '
        Me.cmdFunc1.Font = New System.Drawing.Font("Meiryo UI", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.cmdFunc1.Image = Global.FMS.My.Resources.Resources._imgSearch32x32
        Me.cmdFunc1.Location = New System.Drawing.Point(9, 744)
        Me.cmdFunc1.Text = "検索(F1)"
        '
        'cmdFunc2
        '
        Me.cmdFunc2.Font = New System.Drawing.Font("Meiryo UI", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.cmdFunc2.Image = Global.FMS.My.Resources.Resources._imgApplication_form_add32x32
        Me.cmdFunc2.Location = New System.Drawing.Point(279, 744)
        Me.cmdFunc2.Text = "新規作成(F2)"
        '
        'cmdFunc3
        '
        Me.cmdFunc3.Font = New System.Drawing.Font("Meiryo UI", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.cmdFunc3.Location = New System.Drawing.Point(549, 744)
        '
        'cmdFunc4
        '
        Me.cmdFunc4.Font = New System.Drawing.Font("Meiryo UI", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.cmdFunc4.Image = Global.FMS.My.Resources.Resources._imgApplication_form_edit32x32
        Me.cmdFunc4.Location = New System.Drawing.Point(819, 744)
        Me.cmdFunc4.Text = "変更・承認(F4)"
        '
        'cmdFunc5
        '
        Me.cmdFunc5.Font = New System.Drawing.Font("Meiryo UI", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.cmdFunc5.Image = Global.FMS.My.Resources.Resources._imgStatusAnnotations_Blocked32x32_SM
        Me.cmdFunc5.Location = New System.Drawing.Point(1089, 744)
        Me.cmdFunc5.Text = "取消(F5)"
        '
        'cmdFunc6
        '
        Me.cmdFunc6.Font = New System.Drawing.Font("Meiryo UI", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.cmdFunc6.Image = Global.FMS.My.Resources.Resources._imgRecovery32x32
        Me.cmdFunc6.Location = New System.Drawing.Point(1359, 744)
        Me.cmdFunc6.Text = "復元(F6)"
        Me.cmdFunc6.Visible = False
        '
        'cmdFunc12
        '
        Me.cmdFunc12.Font = New System.Drawing.Font("Meiryo UI", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.cmdFunc12.Image = Global.FMS.My.Resources.Resources._imgLog_Out32x32
        Me.cmdFunc12.Location = New System.Drawing.Point(1359, 792)
        Me.cmdFunc12.Text = "閉じる(F12)"
        '
        'cmdFunc11
        '
        Me.cmdFunc11.Font = New System.Drawing.Font("Meiryo UI", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.cmdFunc11.Image = Global.FMS.My.Resources.Resources.履歴
        Me.cmdFunc11.Location = New System.Drawing.Point(1089, 792)
        Me.cmdFunc11.Text = "履歴(F11)"
        '
        'cmdFunc10
        '
        Me.cmdFunc10.Font = New System.Drawing.Font("Meiryo UI", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.cmdFunc10.Image = Global.FMS.My.Resources.Resources._imgPrint32x32
        Me.cmdFunc10.Location = New System.Drawing.Point(819, 792)
        Me.cmdFunc10.Text = "印刷プレビュー(F10)"
        '
        'cmdFunc7
        '
        Me.cmdFunc7.Enabled = False
        Me.cmdFunc7.Font = New System.Drawing.Font("Meiryo UI", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.cmdFunc7.Location = New System.Drawing.Point(9, 792)
        '
        'cmdFunc9
        '
        Me.cmdFunc9.Font = New System.Drawing.Font("Meiryo UI", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.cmdFunc9.Image = Global.FMS.My.Resources.Resources._imgSendMail2
        Me.cmdFunc9.Location = New System.Drawing.Point(549, 792)
        Me.cmdFunc9.Text = "滞留通知メール送信(F9)"
        '
        'cmdFunc8
        '
        Me.cmdFunc8.Font = New System.Drawing.Font("Meiryo UI", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.cmdFunc8.Image = Global.FMS.My.Resources.Resources._imgExportToExcel32x32
        Me.cmdFunc8.Location = New System.Drawing.Point(279, 792)
        Me.cmdFunc8.Text = "CSV出力(F8)"
        '
        'lblTytle
        '
        Me.lblTytle.Font = New System.Drawing.Font("Meiryo UI", 24.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTytle.ForeColor = System.Drawing.SystemColors.ControlText
        Me.lblTytle.Size = New System.Drawing.Size(1553, 45)
        Me.lblTytle.Text = "FCCB記録書 検索画面"
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
        Me.tlpFilter.Controls.Add(Me.cmbGEN_TANTO, 35, 1)
        Me.tlpFilter.Controls.Add(Me.lblGEN_TANTO, 28, 1)
        Me.tlpFilter.Controls.Add(Me.Label9, 0, 1)
        Me.tlpFilter.Controls.Add(Me.lblHOKUKO_NO, 0, 0)
        Me.tlpFilter.Controls.Add(Me.mtxHOKUKO_NO, 7, 0)
        Me.tlpFilter.Controls.Add(Me.cmbKISYU, 7, 1)
        Me.tlpFilter.Controls.Add(Me.Label1, 14, 0)
        Me.tlpFilter.Controls.Add(Me.cmbBUMON, 21, 0)
        Me.tlpFilter.Controls.Add(Me.Label11, 14, 1)
        Me.tlpFilter.Controls.Add(Me.cmbBUHIN_BANGO, 21, 1)
        Me.tlpFilter.Controls.Add(Me.Label14, 28, 0)
        Me.tlpFilter.Controls.Add(Me.cmbADD_TANTO, 35, 0)
        Me.tlpFilter.Controls.Add(Me.lblSyanaiCD, 0, 2)
        Me.tlpFilter.Controls.Add(Me.cmbSYANAI_CD, 7, 2)
        Me.tlpFilter.Controls.Add(Me.Label2, 14, 2)
        Me.tlpFilter.Controls.Add(Me.mtxHINMEI, 21, 2)
        Me.tlpFilter.Controls.Add(Me.btnSECH_BUHIN, 36, 2)
        Me.tlpFilter.Controls.Add(Me.chkTairyu, 43, 0)
        Me.tlpFilter.Controls.Add(Me.chkClosedRowVisibled, 43, 1)
        Me.tlpFilter.Controls.Add(Me.chkDeleteRowVisibled, 43, 2)
        Me.tlpFilter.Controls.Add(Me.btnClearSrchFilter, 50, 0)
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
        Me.tlpFilter.Size = New System.Drawing.Size(1547, 97)
        Me.tlpFilter.TabIndex = 56
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
        Me.cmbGEN_TANTO.Location = New System.Drawing.Point(703, 33)
        Me.cmbGEN_TANTO.Name = "cmbGEN_TANTO"
        Me.cmbGEN_TANTO.NullValue = " "
        Me.cmbGEN_TANTO.Size = New System.Drawing.Size(134, 25)
        Me.cmbGEN_TANTO.TabIndex = 65
        Me.cmbGEN_TANTO.ValueMember = "VALUE"
        '
        'lblGEN_TANTO
        '
        Me.tlpFilter.SetColumnSpan(Me.lblGEN_TANTO, 7)
        Me.lblGEN_TANTO.Font = New System.Drawing.Font("Meiryo UI", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.lblGEN_TANTO.Location = New System.Drawing.Point(563, 30)
        Me.lblGEN_TANTO.Name = "lblGEN_TANTO"
        Me.lblGEN_TANTO.Size = New System.Drawing.Size(134, 30)
        Me.lblGEN_TANTO.TabIndex = 68
        Me.lblGEN_TANTO.Text = "現処置担当者:"
        Me.lblGEN_TANTO.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label9
        '
        Me.tlpFilter.SetColumnSpan(Me.Label9, 7)
        Me.Label9.Font = New System.Drawing.Font("Meiryo UI", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label9.Location = New System.Drawing.Point(3, 30)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(134, 30)
        Me.Label9.TabIndex = 73
        Me.Label9.Text = "機種:"
        Me.Label9.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'lblHOKUKO_NO
        '
        Me.tlpFilter.SetColumnSpan(Me.lblHOKUKO_NO, 7)
        Me.lblHOKUKO_NO.Font = New System.Drawing.Font("Meiryo UI", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.lblHOKUKO_NO.Location = New System.Drawing.Point(3, 0)
        Me.lblHOKUKO_NO.Name = "lblHOKUKO_NO"
        Me.lblHOKUKO_NO.Size = New System.Drawing.Size(134, 30)
        Me.lblHOKUKO_NO.TabIndex = 69
        Me.lblHOKUKO_NO.Text = "報告書No:"
        Me.lblHOKUKO_NO.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'mtxHOKUKO_NO
        '
        Me.mtxHOKUKO_NO.BackColor = System.Drawing.SystemColors.Window
        Me.tlpFilter.SetColumnSpan(Me.mtxHOKUKO_NO, 7)
        Me.mtxHOKUKO_NO.ImeMode = System.Windows.Forms.ImeMode.Disable
        Me.mtxHOKUKO_NO.InputRequired = False
        Me.mtxHOKUKO_NO.Location = New System.Drawing.Point(143, 3)
        Me.mtxHOKUKO_NO.MaxByteLength = 10
        Me.mtxHOKUKO_NO.Name = "mtxHOKUKO_NO"
        Me.mtxHOKUKO_NO.SelectAllText = False
        Me.mtxHOKUKO_NO.Size = New System.Drawing.Size(134, 23)
        Me.mtxHOKUKO_NO.TabIndex = 1
        Me.mtxHOKUKO_NO.WatermarkColor = System.Drawing.Color.Empty
        Me.mtxHOKUKO_NO.WatermarkText = Nothing
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
        Me.cmbKISYU.Location = New System.Drawing.Point(143, 33)
        Me.cmbKISYU.Name = "cmbKISYU"
        Me.cmbKISYU.NullValue = " "
        Me.cmbKISYU.Size = New System.Drawing.Size(134, 25)
        Me.cmbKISYU.TabIndex = 4
        Me.cmbKISYU.ValueMember = "VALUE"
        '
        'Label1
        '
        Me.tlpFilter.SetColumnSpan(Me.Label1, 7)
        Me.Label1.Font = New System.Drawing.Font("Meiryo UI", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label1.Location = New System.Drawing.Point(283, 0)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(134, 30)
        Me.Label1.TabIndex = 101
        Me.Label1.Text = "製品区分:"
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
        Me.cmbBUMON.Location = New System.Drawing.Point(423, 3)
        Me.cmbBUMON.Name = "cmbBUMON"
        Me.cmbBUMON.NullValue = " "
        Me.cmbBUMON.Size = New System.Drawing.Size(134, 25)
        Me.cmbBUMON.TabIndex = 2
        Me.cmbBUMON.ValueMember = "VALUE"
        '
        'Label11
        '
        Me.tlpFilter.SetColumnSpan(Me.Label11, 7)
        Me.Label11.Font = New System.Drawing.Font("Meiryo UI", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label11.Location = New System.Drawing.Point(283, 30)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(134, 30)
        Me.Label11.TabIndex = 75
        Me.Label11.Text = "部品番号:"
        Me.Label11.TextAlign = System.Drawing.ContentAlignment.MiddleRight
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
        Me.cmbBUHIN_BANGO.Location = New System.Drawing.Point(423, 33)
        Me.cmbBUHIN_BANGO.Name = "cmbBUHIN_BANGO"
        Me.cmbBUHIN_BANGO.NullValue = " "
        Me.cmbBUHIN_BANGO.Size = New System.Drawing.Size(134, 25)
        Me.cmbBUHIN_BANGO.TabIndex = 5
        Me.cmbBUHIN_BANGO.ValueMember = "VALUE"
        '
        'Label14
        '
        Me.tlpFilter.SetColumnSpan(Me.Label14, 7)
        Me.Label14.Font = New System.Drawing.Font("Meiryo UI", 9.0!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Underline), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label14.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.Label14.Location = New System.Drawing.Point(563, 0)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(134, 30)
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
        Me.cmbADD_TANTO.Location = New System.Drawing.Point(703, 3)
        Me.cmbADD_TANTO.Name = "cmbADD_TANTO"
        Me.cmbADD_TANTO.NullValue = " "
        Me.cmbADD_TANTO.Size = New System.Drawing.Size(134, 25)
        Me.cmbADD_TANTO.TabIndex = 3
        Me.cmbADD_TANTO.ValueMember = "VALUE"
        '
        'lblSyanaiCD
        '
        Me.tlpFilter.SetColumnSpan(Me.lblSyanaiCD, 7)
        Me.lblSyanaiCD.Font = New System.Drawing.Font("Meiryo UI", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.lblSyanaiCD.Location = New System.Drawing.Point(3, 60)
        Me.lblSyanaiCD.Name = "lblSyanaiCD"
        Me.lblSyanaiCD.Size = New System.Drawing.Size(134, 30)
        Me.lblSyanaiCD.TabIndex = 105
        Me.lblSyanaiCD.Text = "社内コード:"
        Me.lblSyanaiCD.TextAlign = System.Drawing.ContentAlignment.MiddleRight
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
        Me.cmbSYANAI_CD.Location = New System.Drawing.Point(143, 63)
        Me.cmbSYANAI_CD.Name = "cmbSYANAI_CD"
        Me.cmbSYANAI_CD.NullValue = " "
        Me.cmbSYANAI_CD.Size = New System.Drawing.Size(134, 25)
        Me.cmbSYANAI_CD.TabIndex = 8
        Me.cmbSYANAI_CD.ValueMember = "VALUE"
        '
        'Label2
        '
        Me.tlpFilter.SetColumnSpan(Me.Label2, 7)
        Me.Label2.Font = New System.Drawing.Font("Meiryo UI", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label2.Location = New System.Drawing.Point(283, 60)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(134, 30)
        Me.Label2.TabIndex = 103
        Me.Label2.Text = "部品名称:"
        Me.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'mtxHINMEI
        '
        Me.mtxHINMEI.BackColor = System.Drawing.SystemColors.Window
        Me.tlpFilter.SetColumnSpan(Me.mtxHINMEI, 15)
        Me.mtxHINMEI.Font = New System.Drawing.Font("Meiryo UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.mtxHINMEI.ImeMode = System.Windows.Forms.ImeMode.Disable
        Me.mtxHINMEI.InputRequired = False
        Me.mtxHINMEI.Location = New System.Drawing.Point(423, 63)
        Me.mtxHINMEI.MaxByteLength = 100
        Me.mtxHINMEI.Name = "mtxHINMEI"
        Me.mtxHINMEI.SelectAllText = False
        Me.mtxHINMEI.Size = New System.Drawing.Size(294, 23)
        Me.mtxHINMEI.TabIndex = 6
        Me.mtxHINMEI.WatermarkColor = System.Drawing.Color.Empty
        Me.mtxHINMEI.WatermarkText = Nothing
        '
        'btnSECH_BUHIN
        '
        Me.tlpFilter.SetColumnSpan(Me.btnSECH_BUHIN, 3)
        Me.btnSECH_BUHIN.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnSECH_BUHIN.Location = New System.Drawing.Point(723, 63)
        Me.btnSECH_BUHIN.Name = "btnSECH_BUHIN"
        Me.btnSECH_BUHIN.Size = New System.Drawing.Size(54, 24)
        Me.btnSECH_BUHIN.TabIndex = 5
        Me.btnSECH_BUHIN.Text = "検索"
        Me.btnSECH_BUHIN.UseVisualStyleBackColor = True
        Me.btnSECH_BUHIN.Visible = False
        '
        'chkTairyu
        '
        Me.chkTairyu.AutoSize = True
        Me.tlpFilter.SetColumnSpan(Me.chkTairyu, 7)
        Me.chkTairyu.Cursor = System.Windows.Forms.Cursors.Hand
        Me.chkTairyu.Font = New System.Drawing.Font("Meiryo UI", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.chkTairyu.Location = New System.Drawing.Point(863, 3)
        Me.chkTairyu.Name = "chkTairyu"
        Me.chkTairyu.Size = New System.Drawing.Size(102, 21)
        Me.chkTairyu.TabIndex = 19
        Me.chkTairyu.Text = "滞留のみ表示"
        Me.chkTairyu.UseVisualStyleBackColor = True
        '
        'chkClosedRowVisibled
        '
        Me.chkClosedRowVisibled.AutoSize = True
        Me.tlpFilter.SetColumnSpan(Me.chkClosedRowVisibled, 7)
        Me.chkClosedRowVisibled.Cursor = System.Windows.Forms.Cursors.Hand
        Me.chkClosedRowVisibled.Font = New System.Drawing.Font("Meiryo UI", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.chkClosedRowVisibled.Location = New System.Drawing.Point(863, 33)
        Me.chkClosedRowVisibled.Name = "chkClosedRowVisibled"
        Me.chkClosedRowVisibled.Size = New System.Drawing.Size(113, 21)
        Me.chkClosedRowVisibled.TabIndex = 18
        Me.chkClosedRowVisibled.Text = "Close済も表示"
        Me.chkClosedRowVisibled.UseVisualStyleBackColor = True
        '
        'chkDeleteRowVisibled
        '
        Me.chkDeleteRowVisibled.AutoSize = True
        Me.tlpFilter.SetColumnSpan(Me.chkDeleteRowVisibled, 6)
        Me.chkDeleteRowVisibled.Cursor = System.Windows.Forms.Cursors.Hand
        Me.chkDeleteRowVisibled.Font = New System.Drawing.Font("Meiryo UI", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.chkDeleteRowVisibled.Location = New System.Drawing.Point(863, 63)
        Me.chkDeleteRowVisibled.Name = "chkDeleteRowVisibled"
        Me.chkDeleteRowVisibled.Size = New System.Drawing.Size(103, 21)
        Me.chkDeleteRowVisibled.TabIndex = 17
        Me.chkDeleteRowVisibled.Text = "削除済も表示"
        Me.chkDeleteRowVisibled.UseVisualStyleBackColor = True
        '
        'btnClearSrchFilter
        '
        Me.tlpFilter.SetColumnSpan(Me.btnClearSrchFilter, 5)
        Me.btnClearSrchFilter.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnClearSrchFilter.Location = New System.Drawing.Point(1003, 3)
        Me.btnClearSrchFilter.Name = "btnClearSrchFilter"
        Me.tlpFilter.SetRowSpan(Me.btnClearSrchFilter, 2)
        Me.btnClearSrchFilter.Size = New System.Drawing.Size(94, 54)
        Me.btnClearSrchFilter.TabIndex = 20
        Me.btnClearSrchFilter.Text = "条件クリア"
        Me.btnClearSrchFilter.UseVisualStyleBackColor = True
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.tlpFilter)
        Me.GroupBox1.Font = New System.Drawing.Font("Meiryo UI", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.GroupBox1.Location = New System.Drawing.Point(12, 60)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(1553, 119)
        Me.GroupBox1.TabIndex = 1
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "共通検索条件"
        '
        'flxDATA
        '
        Me.flxDATA.AutoResize = True
        Me.flxDATA.ClipboardCopyMode = C1.Win.C1FlexGrid.ClipboardCopyModeEnum.DataAndColumnHeaders
        Me.flxDATA.ColumnInfo = resources.GetString("flxDATA.ColumnInfo")
        Me.flxDATA.DataSource = Me.ST03FUTEKIGOICHIRANBindingSource
        Me.flxDATA.Font = New System.Drawing.Font("Meiryo UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.flxDATA.Location = New System.Drawing.Point(15, 185)
        Me.flxDATA.Name = "flxDATA"
        Me.flxDATA.Rows.Count = 1
        Me.flxDATA.Rows.DefaultSize = 23
        Me.flxDATA.Size = New System.Drawing.Size(1548, 526)
        Me.flxDATA.StyleInfo = resources.GetString("flxDATA.StyleInfo")
        Me.flxDATA.TabIndex = 64
        '
        'ST03FUTEKIGOICHIRANBindingSource
        '
        Me.ST03FUTEKIGOICHIRANBindingSource.DataSource = GetType(MODEL.ST02_FUTEKIGO_ICHIRAN)
        '
        'dgvDATA
        '
        DataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle4.Font = New System.Drawing.Font("MS UI Gothic", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        DataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgvDATA.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle4
        Me.dgvDATA.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        DataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle5.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle5.Font = New System.Drawing.Font("MS UI Gothic", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        DataGridViewCellStyle5.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle5.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle5.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.dgvDATA.DefaultCellStyle = DataGridViewCellStyle5
        Me.dgvDATA.Location = New System.Drawing.Point(84, 12)
        Me.dgvDATA.Name = "dgvDATA"
        DataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle6.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle6.Font = New System.Drawing.Font("MS UI Gothic", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        DataGridViewCellStyle6.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle6.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle6.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgvDATA.RowHeadersDefaultCellStyle = DataGridViewCellStyle6
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
        'FrmG0020_List
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.ClientSize = New System.Drawing.Size(1584, 861)
        Me.Controls.Add(Me.flxDATA)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.dgvDATA)
        Me.HelpButton = True
        Me.Name = "FrmG0020_List"
        Me.ShowStatusBar = True
        Me.Text = ""
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
        Me.Controls.SetChildIndex(Me.GroupBox1, 0)
        Me.Controls.SetChildIndex(Me.cmdFunc12, 0)
        Me.Controls.SetChildIndex(Me.flxDATA, 0)
        CType(Me.ErrorProvider, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.WarningErrorProvider, System.ComponentModel.ISupportInitialize).EndInit()
        Me.tlpFilter.ResumeLayout(False)
        Me.tlpFilter.PerformLayout()
        Me.GroupBox1.ResumeLayout(False)
        CType(Me.flxDATA, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ST03FUTEKIGOICHIRANBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dgvDATA, System.ComponentModel.ISupportInitialize).EndInit()
        Me.FlexContextMenu.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents chkClosedRowVisibled As CheckBox
    Friend WithEvents tlpFilter As TableLayoutPanel
    Friend WithEvents lblHOKUKO_NO As Label
    Friend WithEvents cmbBUHIN_BANGO As ComboboxEx
    Friend WithEvents Label11 As Label
    Friend WithEvents cmbKISYU As ComboboxEx
    Friend WithEvents Label9 As Label
    Friend WithEvents mtxHINMEI As MaskedTextBoxEx
    Friend WithEvents mtxHOKUKO_NO As MaskedTextBoxEx
    Friend WithEvents btnSECH_BUHIN As Button
    Friend WithEvents btnClearSrchFilter As Button
    Friend WithEvents Label1 As Label
    Friend WithEvents cmbBUMON As ComboboxEx
    Friend WithEvents Label2 As Label
    Friend WithEvents lblSyanaiCD As Label
    Friend WithEvents Label14 As Label
    Friend WithEvents cmbADD_TANTO As ComboboxEx
    Friend WithEvents chkTairyu As CheckBox
    Friend WithEvents cmbSYANAI_CD As ComboboxEx
    Friend WithEvents chkDeleteRowVisibled As CheckBox
    Friend WithEvents dgvDATA As DataGridView
    Friend WithEvents GroupBox1 As GroupBox
    Friend WithEvents flxDATA As C1.Win.C1FlexGrid.C1FlexGrid
    Friend WithEvents ST03FUTEKIGOICHIRANBindingSource As BindingSource
    Friend WithEvents FlexContextMenu As ContextMenuStrip
    Friend WithEvents EqualFilter As ToolStripMenuItem
    Friend WithEvents NotEqualFilter As ToolStripMenuItem
    Friend WithEvents IncludeFilter As ToolStripMenuItem
    Friend WithEvents NotIncludeFilter As ToolStripMenuItem
    Friend WithEvents lblGEN_TANTO As Label
    Friend WithEvents cmbGEN_TANTO As ComboboxEx
End Class
