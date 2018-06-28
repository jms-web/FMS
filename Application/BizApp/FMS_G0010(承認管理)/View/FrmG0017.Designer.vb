<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class FrmG0017
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
        Dim DataGridViewCellStyle7 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle8 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle9 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.dgvDATA = New System.Windows.Forms.DataGridView()
        Me.gbxFilter = New System.Windows.Forms.GroupBox()
        Me.tlpFilter = New System.Windows.Forms.TableLayoutPanel()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.lblFUTEKIGO_NAIYO = New System.Windows.Forms.Label()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.mtxHENKYAKU_RIYU = New JMS_COMMON.MaskedTextBoxEx()
        Me.Label14 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.mtxZUBAN_KIKAKU = New JMS_COMMON.MaskedTextBoxEx()
        Me.chkClosed = New System.Windows.Forms.CheckBox()
        Me.mtxHOKUKO_NO = New JMS_COMMON.MaskedTextBoxEx()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.Label16 = New System.Windows.Forms.Label()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.mtxHINMEI = New JMS_COMMON.MaskedTextBoxEx()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.mtxGOUKI = New JMS_COMMON.MaskedTextBoxEx()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.numSU = New System.Windows.Forms.NumericUpDown()
        Me.chkSAIHATU = New System.Windows.Forms.CheckBox()
        Me.btnSRCH_BUHIN = New System.Windows.Forms.Button()
        Me.lblSYANAI_CD = New System.Windows.Forms.Label()
        Me.dtDraft = New JMS_COMMON.DateTextBoxEx()
        Me.mtxKISYU = New JMS_COMMON.MaskedTextBoxEx()
        Me.mtxFUTEKIGO_JYOTAI = New JMS_COMMON.MaskedTextBoxEx()
        Me.mtxFUTEKIGO_KB = New JMS_COMMON.MaskedTextBoxEx()
        Me.mtxFUTEKIGO_S_KB = New JMS_COMMON.MaskedTextBoxEx()
        Me.mtxSYANAI_CD = New JMS_COMMON.MaskedTextBoxEx()
        Me.mtxBUHIN_BANGO = New JMS_COMMON.MaskedTextBoxEx()
        Me.mtxBUMON_KB = New JMS_COMMON.MaskedTextBoxEx()
        Me.mtxKISOU_TANTO = New JMS_COMMON.MaskedTextBoxEx()
        CType(Me.ErrorProvider, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dgvDATA, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.gbxFilter.SuspendLayout()
        Me.tlpFilter.SuspendLayout()
        CType(Me.numSU, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'lblRecordCount
        '
        Me.lblRecordCount.ForeColor = System.Drawing.SystemColors.ControlText
        Me.lblRecordCount.Location = New System.Drawing.Point(9, 565)
        '
        'cmdFunc1
        '
        Me.cmdFunc1.Location = New System.Drawing.Point(9, 595)
        '
        'cmdFunc2
        '
        Me.cmdFunc2.Location = New System.Drawing.Point(216, 595)
        '
        'cmdFunc3
        '
        Me.cmdFunc3.Location = New System.Drawing.Point(423, 595)
        '
        'cmdFunc4
        '
        Me.cmdFunc4.Location = New System.Drawing.Point(630, 595)
        '
        'cmdFunc5
        '
        Me.cmdFunc5.Location = New System.Drawing.Point(837, 595)
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
        Me.cmdFunc11.Location = New System.Drawing.Point(837, 643)
        '
        'cmdFunc10
        '
        Me.cmdFunc10.Location = New System.Drawing.Point(630, 643)
        '
        'cmdFunc7
        '
        Me.cmdFunc7.Location = New System.Drawing.Point(9, 643)
        '
        'cmdFunc9
        '
        Me.cmdFunc9.Location = New System.Drawing.Point(423, 643)
        '
        'cmdFunc8
        '
        Me.cmdFunc8.Location = New System.Drawing.Point(216, 643)
        '
        'lblTytle
        '
        Me.lblTytle.Font = New System.Drawing.Font("Meiryo UI", 24.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTytle.ForeColor = System.Drawing.SystemColors.ControlText
        Me.lblTytle.Text = "処置履歴"
        '
        'ToolTip
        '
        Me.ToolTip.InitialDelay = 700
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
        Me.dgvDATA.Location = New System.Drawing.Point(12, 247)
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
        Me.dgvDATA.Size = New System.Drawing.Size(1240, 315)
        Me.dgvDATA.TabIndex = 64
        '
        'gbxFilter
        '
        Me.gbxFilter.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.gbxFilter.Controls.Add(Me.tlpFilter)
        Me.gbxFilter.Font = New System.Drawing.Font("Meiryo UI", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.gbxFilter.Location = New System.Drawing.Point(12, 60)
        Me.gbxFilter.Name = "gbxFilter"
        Me.gbxFilter.Size = New System.Drawing.Size(1240, 181)
        Me.gbxFilter.TabIndex = 65
        Me.gbxFilter.TabStop = False
        Me.gbxFilter.Text = "基本情報"
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
        Me.tlpFilter.Controls.Add(Me.lblFUTEKIGO_NAIYO, 13, 3)
        Me.tlpFilter.Controls.Add(Me.Label12, 0, 4)
        Me.tlpFilter.Controls.Add(Me.Label5, 13, 4)
        Me.tlpFilter.Controls.Add(Me.mtxHENKYAKU_RIYU, 18, 3)
        Me.tlpFilter.Controls.Add(Me.Label14, 29, 0)
        Me.tlpFilter.Controls.Add(Me.Label1, 0, 3)
        Me.tlpFilter.Controls.Add(Me.Label13, 29, 4)
        Me.tlpFilter.Controls.Add(Me.mtxZUBAN_KIKAKU, 34, 4)
        Me.tlpFilter.Controls.Add(Me.chkClosed, 57, 0)
        Me.tlpFilter.Controls.Add(Me.mtxHOKUKO_NO, 5, 0)
        Me.tlpFilter.Controls.Add(Me.Label8, 0, 0)
        Me.tlpFilter.Controls.Add(Me.Label16, 13, 0)
        Me.tlpFilter.Controls.Add(Me.Label11, 13, 1)
        Me.tlpFilter.Controls.Add(Me.Label7, 29, 1)
        Me.tlpFilter.Controls.Add(Me.mtxHINMEI, 34, 1)
        Me.tlpFilter.Controls.Add(Me.Label4, 0, 2)
        Me.tlpFilter.Controls.Add(Me.mtxGOUKI, 5, 2)
        Me.tlpFilter.Controls.Add(Me.Label6, 42, 0)
        Me.tlpFilter.Controls.Add(Me.Label2, 42, 2)
        Me.tlpFilter.Controls.Add(Me.numSU, 47, 2)
        Me.tlpFilter.Controls.Add(Me.chkSAIHATU, 47, 3)
        Me.tlpFilter.Controls.Add(Me.btnSRCH_BUHIN, 34, 2)
        Me.tlpFilter.Controls.Add(Me.lblSYANAI_CD, 13, 2)
        Me.tlpFilter.Controls.Add(Me.dtDraft, 47, 0)
        Me.tlpFilter.Controls.Add(Me.mtxKISYU, 5, 1)
        Me.tlpFilter.Controls.Add(Me.mtxFUTEKIGO_JYOTAI, 5, 3)
        Me.tlpFilter.Controls.Add(Me.mtxFUTEKIGO_KB, 5, 4)
        Me.tlpFilter.Controls.Add(Me.mtxFUTEKIGO_S_KB, 18, 4)
        Me.tlpFilter.Controls.Add(Me.mtxSYANAI_CD, 18, 2)
        Me.tlpFilter.Controls.Add(Me.mtxBUHIN_BANGO, 18, 1)
        Me.tlpFilter.Controls.Add(Me.mtxBUMON_KB, 18, 0)
        Me.tlpFilter.Controls.Add(Me.mtxKISOU_TANTO, 34, 0)
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
        Me.tlpFilter.Size = New System.Drawing.Size(1234, 158)
        Me.tlpFilter.TabIndex = 56
        '
        'Label9
        '
        Me.tlpFilter.SetColumnSpan(Me.Label9, 5)
        Me.Label9.Font = New System.Drawing.Font("Meiryo UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label9.Location = New System.Drawing.Point(3, 30)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(94, 30)
        Me.Label9.TabIndex = 94
        Me.Label9.Text = "機種:"
        Me.Label9.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'lblFUTEKIGO_NAIYO
        '
        Me.tlpFilter.SetColumnSpan(Me.lblFUTEKIGO_NAIYO, 5)
        Me.lblFUTEKIGO_NAIYO.Font = New System.Drawing.Font("Meiryo UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.lblFUTEKIGO_NAIYO.Location = New System.Drawing.Point(263, 90)
        Me.lblFUTEKIGO_NAIYO.Name = "lblFUTEKIGO_NAIYO"
        Me.lblFUTEKIGO_NAIYO.Size = New System.Drawing.Size(94, 30)
        Me.lblFUTEKIGO_NAIYO.TabIndex = 101
        Me.lblFUTEKIGO_NAIYO.Text = "返却品の場合:"
        Me.lblFUTEKIGO_NAIYO.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.lblFUTEKIGO_NAIYO.Visible = False
        '
        'Label12
        '
        Me.tlpFilter.SetColumnSpan(Me.Label12, 5)
        Me.Label12.Font = New System.Drawing.Font("Meiryo UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label12.Location = New System.Drawing.Point(3, 120)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(94, 30)
        Me.Label12.TabIndex = 102
        Me.Label12.Text = "不適合区分:"
        Me.Label12.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label5
        '
        Me.tlpFilter.SetColumnSpan(Me.Label5, 5)
        Me.Label5.Font = New System.Drawing.Font("Meiryo UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label5.Location = New System.Drawing.Point(263, 120)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(94, 30)
        Me.Label5.TabIndex = 118
        Me.Label5.Text = "不適合詳細区分:"
        Me.Label5.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'mtxHENKYAKU_RIYU
        '
        Me.mtxHENKYAKU_RIYU.BackColor = System.Drawing.SystemColors.Window
        Me.tlpFilter.SetColumnSpan(Me.mtxHENKYAKU_RIYU, 24)
        Me.mtxHENKYAKU_RIYU.Enabled = False
        Me.mtxHENKYAKU_RIYU.GotFocusedColor = System.Drawing.Color.FromArgb(CType(CType(190, Byte), Integer), CType(CType(180, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.mtxHENKYAKU_RIYU.ImeMode = System.Windows.Forms.ImeMode.[On]
        Me.mtxHENKYAKU_RIYU.InputRequired = False
        Me.mtxHENKYAKU_RIYU.Location = New System.Drawing.Point(363, 93)
        Me.mtxHENKYAKU_RIYU.Name = "mtxHENKYAKU_RIYU"
        Me.mtxHENKYAKU_RIYU.Size = New System.Drawing.Size(474, 24)
        Me.mtxHENKYAKU_RIYU.TabIndex = 12
        Me.mtxHENKYAKU_RIYU.Visible = False
        Me.mtxHENKYAKU_RIYU.WatermarkColor = System.Drawing.Color.Empty
        Me.mtxHENKYAKU_RIYU.WatermarkText = Nothing
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
        'Label1
        '
        Me.tlpFilter.SetColumnSpan(Me.Label1, 5)
        Me.Label1.Font = New System.Drawing.Font("Meiryo UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label1.Location = New System.Drawing.Point(3, 90)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(94, 30)
        Me.Label1.TabIndex = 87
        Me.Label1.Text = "状態区分:"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label13
        '
        Me.tlpFilter.SetColumnSpan(Me.Label13, 5)
        Me.Label13.Font = New System.Drawing.Font("Meiryo UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
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
        Me.tlpFilter.SetColumnSpan(Me.mtxZUBAN_KIKAKU, 18)
        Me.mtxZUBAN_KIKAKU.Enabled = False
        Me.mtxZUBAN_KIKAKU.Font = New System.Drawing.Font("Meiryo UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.mtxZUBAN_KIKAKU.GotFocusedColor = System.Drawing.Color.FromArgb(CType(CType(190, Byte), Integer), CType(CType(180, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.mtxZUBAN_KIKAKU.ImeMode = System.Windows.Forms.ImeMode.Off
        Me.mtxZUBAN_KIKAKU.InputRequired = False
        Me.mtxZUBAN_KIKAKU.Location = New System.Drawing.Point(683, 123)
        Me.mtxZUBAN_KIKAKU.MaxByteLength = 60
        Me.mtxZUBAN_KIKAKU.Name = "mtxZUBAN_KIKAKU"
        Me.mtxZUBAN_KIKAKU.Size = New System.Drawing.Size(354, 24)
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
        Me.chkClosed.Visible = False
        '
        'mtxHOKUKO_NO
        '
        Me.mtxHOKUKO_NO.BackColor = System.Drawing.SystemColors.Window
        Me.tlpFilter.SetColumnSpan(Me.mtxHOKUKO_NO, 7)
        Me.mtxHOKUKO_NO.Enabled = False
        Me.mtxHOKUKO_NO.Font = New System.Drawing.Font("Meiryo UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
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
        Me.Label16.Font = New System.Drawing.Font("Meiryo UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label16.Location = New System.Drawing.Point(263, 0)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(94, 30)
        Me.Label16.TabIndex = 112
        Me.Label16.Text = "製品区分:"
        Me.Label16.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label11
        '
        Me.tlpFilter.SetColumnSpan(Me.Label11, 5)
        Me.Label11.Font = New System.Drawing.Font("Meiryo UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label11.Location = New System.Drawing.Point(263, 30)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(94, 30)
        Me.Label11.TabIndex = 97
        Me.Label11.Text = "部品番号:"
        Me.Label11.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label7
        '
        Me.tlpFilter.SetColumnSpan(Me.Label7, 5)
        Me.Label7.Font = New System.Drawing.Font("Meiryo UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label7.Location = New System.Drawing.Point(583, 30)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(94, 30)
        Me.Label7.TabIndex = 99
        Me.Label7.Text = "部品名称:"
        Me.Label7.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'mtxHINMEI
        '
        Me.mtxHINMEI.BackColor = System.Drawing.SystemColors.Window
        Me.tlpFilter.SetColumnSpan(Me.mtxHINMEI, 18)
        Me.mtxHINMEI.Enabled = False
        Me.mtxHINMEI.Font = New System.Drawing.Font("Meiryo UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.mtxHINMEI.GotFocusedColor = System.Drawing.Color.FromArgb(CType(CType(190, Byte), Integer), CType(CType(180, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.mtxHINMEI.ImeMode = System.Windows.Forms.ImeMode.Disable
        Me.mtxHINMEI.InputRequired = False
        Me.mtxHINMEI.Location = New System.Drawing.Point(683, 33)
        Me.mtxHINMEI.Name = "mtxHINMEI"
        Me.mtxHINMEI.Size = New System.Drawing.Size(354, 24)
        Me.mtxHINMEI.TabIndex = 6
        Me.mtxHINMEI.WatermarkColor = System.Drawing.Color.Empty
        Me.mtxHINMEI.WatermarkText = Nothing
        '
        'Label4
        '
        Me.tlpFilter.SetColumnSpan(Me.Label4, 5)
        Me.Label4.Font = New System.Drawing.Font("Meiryo UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label4.Location = New System.Drawing.Point(3, 60)
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
        Me.mtxGOUKI.Enabled = False
        Me.mtxGOUKI.Font = New System.Drawing.Font("Meiryo UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.mtxGOUKI.GotFocusedColor = System.Drawing.Color.FromArgb(CType(CType(190, Byte), Integer), CType(CType(180, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.mtxGOUKI.ImeMode = System.Windows.Forms.ImeMode.Disable
        Me.mtxGOUKI.InputRequired = False
        Me.mtxGOUKI.Location = New System.Drawing.Point(103, 63)
        Me.mtxGOUKI.Name = "mtxGOUKI"
        Me.mtxGOUKI.Size = New System.Drawing.Size(134, 24)
        Me.mtxGOUKI.TabIndex = 7
        Me.mtxGOUKI.WatermarkColor = System.Drawing.Color.Empty
        Me.mtxGOUKI.WatermarkText = Nothing
        '
        'Label6
        '
        Me.tlpFilter.SetColumnSpan(Me.Label6, 5)
        Me.Label6.Font = New System.Drawing.Font("Meiryo UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label6.Location = New System.Drawing.Point(843, 0)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(94, 30)
        Me.Label6.TabIndex = 93
        Me.Label6.Text = "起草日:"
        Me.Label6.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label2
        '
        Me.tlpFilter.SetColumnSpan(Me.Label2, 5)
        Me.Label2.Font = New System.Drawing.Font("Meiryo UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label2.Location = New System.Drawing.Point(843, 60)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(94, 30)
        Me.Label2.TabIndex = 88
        Me.Label2.Text = "個数:"
        Me.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'numSU
        '
        Me.tlpFilter.SetColumnSpan(Me.numSU, 3)
        Me.numSU.Enabled = False
        Me.numSU.Font = New System.Drawing.Font("Meiryo UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.numSU.Location = New System.Drawing.Point(943, 63)
        Me.numSU.Minimum = New Decimal(New Integer() {1, 0, 0, 0})
        Me.numSU.Name = "numSU"
        Me.numSU.Size = New System.Drawing.Size(54, 24)
        Me.numSU.TabIndex = 10
        Me.numSU.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.numSU.Value = New Decimal(New Integer() {1, 0, 0, 0})
        '
        'chkSAIHATU
        '
        Me.chkSAIHATU.AutoSize = True
        Me.tlpFilter.SetColumnSpan(Me.chkSAIHATU, 7)
        Me.chkSAIHATU.Cursor = System.Windows.Forms.Cursors.Hand
        Me.chkSAIHATU.Enabled = False
        Me.chkSAIHATU.Font = New System.Drawing.Font("Meiryo UI", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.chkSAIHATU.Location = New System.Drawing.Point(943, 93)
        Me.chkSAIHATU.Name = "chkSAIHATU"
        Me.chkSAIHATU.Size = New System.Drawing.Size(53, 21)
        Me.chkSAIHATU.TabIndex = 12
        Me.chkSAIHATU.Text = "再発"
        Me.chkSAIHATU.UseVisualStyleBackColor = True
        '
        'btnSRCH_BUHIN
        '
        Me.tlpFilter.SetColumnSpan(Me.btnSRCH_BUHIN, 3)
        Me.btnSRCH_BUHIN.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnSRCH_BUHIN.Location = New System.Drawing.Point(683, 63)
        Me.btnSRCH_BUHIN.Name = "btnSRCH_BUHIN"
        Me.btnSRCH_BUHIN.Size = New System.Drawing.Size(54, 24)
        Me.btnSRCH_BUHIN.TabIndex = 9
        Me.btnSRCH_BUHIN.Text = "検索"
        Me.btnSRCH_BUHIN.UseVisualStyleBackColor = True
        Me.btnSRCH_BUHIN.Visible = False
        '
        'lblSYANAI_CD
        '
        Me.tlpFilter.SetColumnSpan(Me.lblSYANAI_CD, 5)
        Me.lblSYANAI_CD.Font = New System.Drawing.Font("Meiryo UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.lblSYANAI_CD.Location = New System.Drawing.Point(263, 60)
        Me.lblSYANAI_CD.Name = "lblSYANAI_CD"
        Me.lblSYANAI_CD.Size = New System.Drawing.Size(94, 30)
        Me.lblSYANAI_CD.TabIndex = 115
        Me.lblSYANAI_CD.Text = "社内コード:"
        Me.lblSYANAI_CD.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.lblSYANAI_CD.Visible = False
        '
        'dtDraft
        '
        Me.dtDraft.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.tlpFilter.SetColumnSpan(Me.dtDraft, 5)
        Me.dtDraft.Enabled = False
        Me.dtDraft.GotFocusedColor = System.Drawing.Color.FromArgb(CType(CType(190, Byte), Integer), CType(CType(180, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.dtDraft.Location = New System.Drawing.Point(943, 3)
        Me.dtDraft.MaxDate = New Date(9998, 12, 31, 0, 0, 0, 0)
        Me.dtDraft.MinDate = New Date(1753, 1, 1, 0, 0, 0, 0)
        Me.dtDraft.MinimumSize = New System.Drawing.Size(98, 24)
        Me.dtDraft.Name = "dtDraft"
        Me.dtDraft.Size = New System.Drawing.Size(98, 24)
        Me.dtDraft.TabIndex = 3
        Me.dtDraft.Value = ""
        Me.dtDraft.ValueNonFormat = ""
        '
        'mtxKISYU
        '
        Me.mtxKISYU.BackColor = System.Drawing.SystemColors.Window
        Me.tlpFilter.SetColumnSpan(Me.mtxKISYU, 7)
        Me.mtxKISYU.Enabled = False
        Me.mtxKISYU.Font = New System.Drawing.Font("Meiryo UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.mtxKISYU.GotFocusedColor = System.Drawing.Color.FromArgb(CType(CType(190, Byte), Integer), CType(CType(180, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.mtxKISYU.ImeMode = System.Windows.Forms.ImeMode.Disable
        Me.mtxKISYU.InputRequired = False
        Me.mtxKISYU.Location = New System.Drawing.Point(103, 33)
        Me.mtxKISYU.Name = "mtxKISYU"
        Me.mtxKISYU.ReadOnly = True
        Me.mtxKISYU.Size = New System.Drawing.Size(134, 24)
        Me.mtxKISYU.TabIndex = 122
        Me.mtxKISYU.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.mtxKISYU.WatermarkColor = System.Drawing.Color.Empty
        Me.mtxKISYU.WatermarkText = Nothing
        '
        'mtxFUTEKIGO_JYOTAI
        '
        Me.mtxFUTEKIGO_JYOTAI.BackColor = System.Drawing.SystemColors.Window
        Me.tlpFilter.SetColumnSpan(Me.mtxFUTEKIGO_JYOTAI, 7)
        Me.mtxFUTEKIGO_JYOTAI.Enabled = False
        Me.mtxFUTEKIGO_JYOTAI.Font = New System.Drawing.Font("Meiryo UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.mtxFUTEKIGO_JYOTAI.GotFocusedColor = System.Drawing.Color.FromArgb(CType(CType(190, Byte), Integer), CType(CType(180, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.mtxFUTEKIGO_JYOTAI.ImeMode = System.Windows.Forms.ImeMode.Disable
        Me.mtxFUTEKIGO_JYOTAI.InputRequired = False
        Me.mtxFUTEKIGO_JYOTAI.Location = New System.Drawing.Point(103, 93)
        Me.mtxFUTEKIGO_JYOTAI.Name = "mtxFUTEKIGO_JYOTAI"
        Me.mtxFUTEKIGO_JYOTAI.Size = New System.Drawing.Size(134, 24)
        Me.mtxFUTEKIGO_JYOTAI.TabIndex = 123
        Me.mtxFUTEKIGO_JYOTAI.WatermarkColor = System.Drawing.Color.Empty
        Me.mtxFUTEKIGO_JYOTAI.WatermarkText = Nothing
        '
        'mtxFUTEKIGO_KB
        '
        Me.mtxFUTEKIGO_KB.BackColor = System.Drawing.SystemColors.Window
        Me.tlpFilter.SetColumnSpan(Me.mtxFUTEKIGO_KB, 7)
        Me.mtxFUTEKIGO_KB.Enabled = False
        Me.mtxFUTEKIGO_KB.Font = New System.Drawing.Font("Meiryo UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.mtxFUTEKIGO_KB.GotFocusedColor = System.Drawing.Color.FromArgb(CType(CType(190, Byte), Integer), CType(CType(180, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.mtxFUTEKIGO_KB.ImeMode = System.Windows.Forms.ImeMode.Disable
        Me.mtxFUTEKIGO_KB.InputRequired = False
        Me.mtxFUTEKIGO_KB.Location = New System.Drawing.Point(103, 123)
        Me.mtxFUTEKIGO_KB.Name = "mtxFUTEKIGO_KB"
        Me.mtxFUTEKIGO_KB.Size = New System.Drawing.Size(134, 24)
        Me.mtxFUTEKIGO_KB.TabIndex = 124
        Me.mtxFUTEKIGO_KB.WatermarkColor = System.Drawing.Color.Empty
        Me.mtxFUTEKIGO_KB.WatermarkText = Nothing
        '
        'mtxFUTEKIGO_S_KB
        '
        Me.mtxFUTEKIGO_S_KB.BackColor = System.Drawing.SystemColors.Window
        Me.tlpFilter.SetColumnSpan(Me.mtxFUTEKIGO_S_KB, 10)
        Me.mtxFUTEKIGO_S_KB.Enabled = False
        Me.mtxFUTEKIGO_S_KB.Font = New System.Drawing.Font("Meiryo UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.mtxFUTEKIGO_S_KB.GotFocusedColor = System.Drawing.Color.FromArgb(CType(CType(190, Byte), Integer), CType(CType(180, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.mtxFUTEKIGO_S_KB.ImeMode = System.Windows.Forms.ImeMode.Disable
        Me.mtxFUTEKIGO_S_KB.InputRequired = False
        Me.mtxFUTEKIGO_S_KB.Location = New System.Drawing.Point(363, 123)
        Me.mtxFUTEKIGO_S_KB.Name = "mtxFUTEKIGO_S_KB"
        Me.mtxFUTEKIGO_S_KB.Size = New System.Drawing.Size(194, 24)
        Me.mtxFUTEKIGO_S_KB.TabIndex = 125
        Me.mtxFUTEKIGO_S_KB.WatermarkColor = System.Drawing.Color.Empty
        Me.mtxFUTEKIGO_S_KB.WatermarkText = Nothing
        '
        'mtxSYANAI_CD
        '
        Me.mtxSYANAI_CD.BackColor = System.Drawing.SystemColors.Window
        Me.tlpFilter.SetColumnSpan(Me.mtxSYANAI_CD, 7)
        Me.mtxSYANAI_CD.Enabled = False
        Me.mtxSYANAI_CD.Font = New System.Drawing.Font("Meiryo UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.mtxSYANAI_CD.GotFocusedColor = System.Drawing.Color.FromArgb(CType(CType(190, Byte), Integer), CType(CType(180, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.mtxSYANAI_CD.ImeMode = System.Windows.Forms.ImeMode.Disable
        Me.mtxSYANAI_CD.InputRequired = False
        Me.mtxSYANAI_CD.Location = New System.Drawing.Point(363, 63)
        Me.mtxSYANAI_CD.Name = "mtxSYANAI_CD"
        Me.mtxSYANAI_CD.Size = New System.Drawing.Size(134, 24)
        Me.mtxSYANAI_CD.TabIndex = 126
        Me.mtxSYANAI_CD.Visible = False
        Me.mtxSYANAI_CD.WatermarkColor = System.Drawing.Color.Empty
        Me.mtxSYANAI_CD.WatermarkText = Nothing
        '
        'mtxBUHIN_BANGO
        '
        Me.mtxBUHIN_BANGO.BackColor = System.Drawing.SystemColors.Window
        Me.tlpFilter.SetColumnSpan(Me.mtxBUHIN_BANGO, 10)
        Me.mtxBUHIN_BANGO.Enabled = False
        Me.mtxBUHIN_BANGO.Font = New System.Drawing.Font("Meiryo UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.mtxBUHIN_BANGO.GotFocusedColor = System.Drawing.Color.FromArgb(CType(CType(190, Byte), Integer), CType(CType(180, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.mtxBUHIN_BANGO.ImeMode = System.Windows.Forms.ImeMode.Disable
        Me.mtxBUHIN_BANGO.InputRequired = False
        Me.mtxBUHIN_BANGO.Location = New System.Drawing.Point(363, 33)
        Me.mtxBUHIN_BANGO.Name = "mtxBUHIN_BANGO"
        Me.mtxBUHIN_BANGO.Size = New System.Drawing.Size(194, 24)
        Me.mtxBUHIN_BANGO.TabIndex = 127
        Me.mtxBUHIN_BANGO.WatermarkColor = System.Drawing.Color.Empty
        Me.mtxBUHIN_BANGO.WatermarkText = Nothing
        '
        'mtxBUMON_KB
        '
        Me.mtxBUMON_KB.BackColor = System.Drawing.SystemColors.Window
        Me.tlpFilter.SetColumnSpan(Me.mtxBUMON_KB, 5)
        Me.mtxBUMON_KB.Enabled = False
        Me.mtxBUMON_KB.Font = New System.Drawing.Font("Meiryo UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.mtxBUMON_KB.GotFocusedColor = System.Drawing.Color.FromArgb(CType(CType(190, Byte), Integer), CType(CType(180, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.mtxBUMON_KB.ImeMode = System.Windows.Forms.ImeMode.Disable
        Me.mtxBUMON_KB.InputRequired = False
        Me.mtxBUMON_KB.Location = New System.Drawing.Point(363, 3)
        Me.mtxBUMON_KB.Name = "mtxBUMON_KB"
        Me.mtxBUMON_KB.ReadOnly = True
        Me.mtxBUMON_KB.Size = New System.Drawing.Size(94, 24)
        Me.mtxBUMON_KB.TabIndex = 128
        Me.mtxBUMON_KB.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.mtxBUMON_KB.WatermarkColor = System.Drawing.Color.Empty
        Me.mtxBUMON_KB.WatermarkText = Nothing
        '
        'mtxKISOU_TANTO
        '
        Me.mtxKISOU_TANTO.BackColor = System.Drawing.SystemColors.Window
        Me.tlpFilter.SetColumnSpan(Me.mtxKISOU_TANTO, 8)
        Me.mtxKISOU_TANTO.Enabled = False
        Me.mtxKISOU_TANTO.Font = New System.Drawing.Font("Meiryo UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.mtxKISOU_TANTO.GotFocusedColor = System.Drawing.Color.FromArgb(CType(CType(190, Byte), Integer), CType(CType(180, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.mtxKISOU_TANTO.ImeMode = System.Windows.Forms.ImeMode.Disable
        Me.mtxKISOU_TANTO.InputRequired = False
        Me.mtxKISOU_TANTO.Location = New System.Drawing.Point(683, 3)
        Me.mtxKISOU_TANTO.Name = "mtxKISOU_TANTO"
        Me.mtxKISOU_TANTO.Size = New System.Drawing.Size(154, 24)
        Me.mtxKISOU_TANTO.TabIndex = 129
        Me.mtxKISOU_TANTO.WatermarkColor = System.Drawing.Color.Empty
        Me.mtxKISOU_TANTO.WatermarkText = Nothing
        '
        'FrmG0017
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.ClientSize = New System.Drawing.Size(1264, 712)
        Me.Controls.Add(Me.gbxFilter)
        Me.Controls.Add(Me.dgvDATA)
        Me.HelpButton = True
        Me.Name = "FrmG0017"
        Me.ShowStatusBar = True
        Me.Text = ""
        Me.Controls.SetChildIndex(Me.dgvDATA, 0)
        Me.Controls.SetChildIndex(Me.gbxFilter, 0)
        Me.Controls.SetChildIndex(Me.lblTytle, 0)
        Me.Controls.SetChildIndex(Me.cmdFunc8, 0)
        Me.Controls.SetChildIndex(Me.cmdFunc9, 0)
        Me.Controls.SetChildIndex(Me.cmdFunc7, 0)
        Me.Controls.SetChildIndex(Me.cmdFunc10, 0)
        Me.Controls.SetChildIndex(Me.cmdFunc11, 0)
        Me.Controls.SetChildIndex(Me.cmdFunc12, 0)
        Me.Controls.SetChildIndex(Me.cmdFunc6, 0)
        Me.Controls.SetChildIndex(Me.cmdFunc5, 0)
        Me.Controls.SetChildIndex(Me.cmdFunc4, 0)
        Me.Controls.SetChildIndex(Me.cmdFunc3, 0)
        Me.Controls.SetChildIndex(Me.cmdFunc2, 0)
        Me.Controls.SetChildIndex(Me.cmdFunc1, 0)
        Me.Controls.SetChildIndex(Me.lblRecordCount, 0)
        CType(Me.ErrorProvider, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dgvDATA, System.ComponentModel.ISupportInitialize).EndInit()
        Me.gbxFilter.ResumeLayout(False)
        Me.tlpFilter.ResumeLayout(False)
        Me.tlpFilter.PerformLayout()
        CType(Me.numSU, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents dgvDATA As DataGridView
    Friend WithEvents gbxFilter As GroupBox
    Friend WithEvents tlpFilter As TableLayoutPanel
    Friend WithEvents Label9 As Label
    Friend WithEvents lblFUTEKIGO_NAIYO As Label
    Friend WithEvents Label12 As Label
    Friend WithEvents Label5 As Label
    Friend WithEvents mtxHENKYAKU_RIYU As MaskedTextBoxEx
    Friend WithEvents Label14 As Label
    Friend WithEvents Label1 As Label
    Friend WithEvents Label13 As Label
    Friend WithEvents mtxZUBAN_KIKAKU As MaskedTextBoxEx
    Friend WithEvents chkClosed As CheckBox
    Friend WithEvents mtxHOKUKO_NO As MaskedTextBoxEx
    Friend WithEvents Label8 As Label
    Friend WithEvents Label16 As Label
    Friend WithEvents Label11 As Label
    Friend WithEvents Label7 As Label
    Friend WithEvents mtxHINMEI As MaskedTextBoxEx
    Friend WithEvents Label4 As Label
    Friend WithEvents mtxGOUKI As MaskedTextBoxEx
    Friend WithEvents Label6 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents numSU As NumericUpDown
    Friend WithEvents chkSAIHATU As CheckBox
    Friend WithEvents btnSRCH_BUHIN As Button
    Friend WithEvents lblSYANAI_CD As Label
    Friend WithEvents dtDraft As DateTextBoxEx
    Friend WithEvents mtxKISYU As MaskedTextBoxEx
    Friend WithEvents mtxFUTEKIGO_JYOTAI As MaskedTextBoxEx
    Friend WithEvents mtxFUTEKIGO_KB As MaskedTextBoxEx
    Friend WithEvents mtxFUTEKIGO_S_KB As MaskedTextBoxEx
    Friend WithEvents mtxSYANAI_CD As MaskedTextBoxEx
    Friend WithEvents mtxBUHIN_BANGO As MaskedTextBoxEx
    Friend WithEvents mtxBUMON_KB As MaskedTextBoxEx
    Friend WithEvents mtxKISOU_TANTO As MaskedTextBoxEx
End Class
