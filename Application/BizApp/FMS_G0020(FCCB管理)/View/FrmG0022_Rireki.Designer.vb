<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class FrmG0022_Rireki
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
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.dgvDATA = New System.Windows.Forms.DataGridView()
        Me.gbxFilter = New System.Windows.Forms.GroupBox()
        Me.tlpFilter = New System.Windows.Forms.TableLayoutPanel()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.mtxHOKUKO_NO = New JMS_COMMON.MaskedTextBoxEx()
        Me.Label16 = New System.Windows.Forms.Label()
        Me.mtxBUMON_KB = New JMS_COMMON.MaskedTextBoxEx()
        Me.Label14 = New System.Windows.Forms.Label()
        Me.mtxKISOU_TANTO = New JMS_COMMON.MaskedTextBoxEx()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.mtxKISYU = New JMS_COMMON.MaskedTextBoxEx()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.dtDraft = New JMS_COMMON.DateTextBoxEx()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.mtxCM_TANTO = New JMS_COMMON.MaskedTextBoxEx()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.mtxBUHIN_BANGO = New JMS_COMMON.MaskedTextBoxEx()
        Me.lblSYANAI_CD = New System.Windows.Forms.Label()
        Me.mtxSYANAI_CD = New JMS_COMMON.MaskedTextBoxEx()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.mtxHINMEI = New JMS_COMMON.MaskedTextBoxEx()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.mtxINPUT_DOC_NO = New JMS_COMMON.MaskedTextBoxEx()
        Me.Label17 = New System.Windows.Forms.Label()
        Me.mtxSNO_APPLY_PERIOD_KISO = New JMS_COMMON.MaskedTextBoxEx()
        Me.Label18 = New System.Windows.Forms.Label()
        Me.txtINPUT_NAIYO = New JMS_COMMON.TextBoxEx()
        CType(Me.ErrorProvider, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.WarningErrorProvider, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dgvDATA, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.gbxFilter.SuspendLayout()
        Me.tlpFilter.SuspendLayout()
        Me.SuspendLayout()
        '
        'lblRecordCount
        '
        Me.lblRecordCount.ForeColor = System.Drawing.SystemColors.ControlText
        Me.lblRecordCount.Location = New System.Drawing.Point(9, 714)
        '
        'cmdFunc1
        '
        Me.cmdFunc1.Location = New System.Drawing.Point(9, 744)
        '
        'cmdFunc2
        '
        Me.cmdFunc2.Location = New System.Drawing.Point(216, 744)
        '
        'cmdFunc3
        '
        Me.cmdFunc3.Location = New System.Drawing.Point(423, 744)
        '
        'cmdFunc4
        '
        Me.cmdFunc4.Location = New System.Drawing.Point(630, 744)
        '
        'cmdFunc5
        '
        Me.cmdFunc5.Location = New System.Drawing.Point(837, 744)
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
        Me.cmdFunc11.Location = New System.Drawing.Point(837, 792)
        '
        'cmdFunc10
        '
        Me.cmdFunc10.Location = New System.Drawing.Point(630, 792)
        '
        'cmdFunc7
        '
        Me.cmdFunc7.Location = New System.Drawing.Point(9, 792)
        '
        'cmdFunc9
        '
        Me.cmdFunc9.Location = New System.Drawing.Point(423, 792)
        '
        'cmdFunc8
        '
        Me.cmdFunc8.Location = New System.Drawing.Point(216, 792)
        '
        'lblTytle
        '
        Me.lblTytle.Font = New System.Drawing.Font("Meiryo UI", 24.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTytle.ForeColor = System.Drawing.SystemColors.ControlText
        Me.lblTytle.Text = "処置履歴"
        '
        'dgvDATA
        '
        Me.dgvDATA.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
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
        Me.dgvDATA.Location = New System.Drawing.Point(12, 277)
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
        Me.dgvDATA.Size = New System.Drawing.Size(1240, 434)
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
        Me.gbxFilter.Size = New System.Drawing.Size(1240, 211)
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
        Me.tlpFilter.Controls.Add(Me.Label8, 0, 0)
        Me.tlpFilter.Controls.Add(Me.mtxHOKUKO_NO, 5, 0)
        Me.tlpFilter.Controls.Add(Me.Label16, 13, 0)
        Me.tlpFilter.Controls.Add(Me.mtxBUMON_KB, 17, 0)
        Me.tlpFilter.Controls.Add(Me.Label14, 22, 0)
        Me.tlpFilter.Controls.Add(Me.mtxKISOU_TANTO, 27, 0)
        Me.tlpFilter.Controls.Add(Me.Label9, 0, 1)
        Me.tlpFilter.Controls.Add(Me.mtxKISYU, 5, 1)
        Me.tlpFilter.Controls.Add(Me.Label6, 13, 1)
        Me.tlpFilter.Controls.Add(Me.dtDraft, 17, 1)
        Me.tlpFilter.Controls.Add(Me.Label1, 22, 1)
        Me.tlpFilter.Controls.Add(Me.mtxCM_TANTO, 27, 1)
        Me.tlpFilter.Controls.Add(Me.Label11, 0, 2)
        Me.tlpFilter.Controls.Add(Me.mtxBUHIN_BANGO, 5, 2)
        Me.tlpFilter.Controls.Add(Me.lblSYANAI_CD, 22, 2)
        Me.tlpFilter.Controls.Add(Me.mtxSYANAI_CD, 27, 2)
        Me.tlpFilter.Controls.Add(Me.Label7, 0, 3)
        Me.tlpFilter.Controls.Add(Me.mtxHINMEI, 5, 3)
        Me.tlpFilter.Controls.Add(Me.Label3, 0, 4)
        Me.tlpFilter.Controls.Add(Me.mtxINPUT_DOC_NO, 5, 4)
        Me.tlpFilter.Controls.Add(Me.Label17, 21, 4)
        Me.tlpFilter.Controls.Add(Me.mtxSNO_APPLY_PERIOD_KISO, 27, 4)
        Me.tlpFilter.Controls.Add(Me.Label18, 34, 0)
        Me.tlpFilter.Controls.Add(Me.txtINPUT_NAIYO, 38, 0)
        Me.tlpFilter.Dock = System.Windows.Forms.DockStyle.Fill
        Me.tlpFilter.Location = New System.Drawing.Point(3, 20)
        Me.tlpFilter.Name = "tlpFilter"
        Me.tlpFilter.RowCount = 7
        Me.tlpFilter.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30.0!))
        Me.tlpFilter.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30.0!))
        Me.tlpFilter.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30.0!))
        Me.tlpFilter.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30.0!))
        Me.tlpFilter.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30.0!))
        Me.tlpFilter.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30.0!))
        Me.tlpFilter.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.tlpFilter.Size = New System.Drawing.Size(1234, 188)
        Me.tlpFilter.TabIndex = 56
        '
        'Label8
        '
        Me.tlpFilter.SetColumnSpan(Me.Label8, 5)
        Me.Label8.Font = New System.Drawing.Font("Meiryo UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label8.Location = New System.Drawing.Point(3, 0)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(94, 30)
        Me.Label8.TabIndex = 83
        Me.Label8.Text = "FCCB No:"
        Me.Label8.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'mtxHOKUKO_NO
        '
        Me.mtxHOKUKO_NO.BackColor = System.Drawing.SystemColors.Control
        Me.tlpFilter.SetColumnSpan(Me.mtxHOKUKO_NO, 6)
        Me.mtxHOKUKO_NO.Font = New System.Drawing.Font("Meiryo UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.mtxHOKUKO_NO.ImeMode = System.Windows.Forms.ImeMode.Disable
        Me.mtxHOKUKO_NO.InputRequired = False
        Me.mtxHOKUKO_NO.Location = New System.Drawing.Point(103, 3)
        Me.mtxHOKUKO_NO.MaxByteLength = 0
        Me.mtxHOKUKO_NO.Name = "mtxHOKUKO_NO"
        Me.mtxHOKUKO_NO.ReadOnly = True
        Me.mtxHOKUKO_NO.SelectAllText = False
        Me.mtxHOKUKO_NO.Size = New System.Drawing.Size(114, 24)
        Me.mtxHOKUKO_NO.TabIndex = 0
        Me.mtxHOKUKO_NO.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.mtxHOKUKO_NO.WatermarkColor = System.Drawing.Color.Empty
        Me.mtxHOKUKO_NO.WatermarkText = Nothing
        '
        'Label16
        '
        Me.tlpFilter.SetColumnSpan(Me.Label16, 4)
        Me.Label16.Font = New System.Drawing.Font("Meiryo UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label16.Location = New System.Drawing.Point(263, 0)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(74, 30)
        Me.Label16.TabIndex = 112
        Me.Label16.Text = "製品区分:"
        Me.Label16.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'mtxBUMON_KB
        '
        Me.mtxBUMON_KB.BackColor = System.Drawing.SystemColors.Control
        Me.tlpFilter.SetColumnSpan(Me.mtxBUMON_KB, 5)
        Me.mtxBUMON_KB.Font = New System.Drawing.Font("Meiryo UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.mtxBUMON_KB.ImeMode = System.Windows.Forms.ImeMode.Disable
        Me.mtxBUMON_KB.InputRequired = False
        Me.mtxBUMON_KB.Location = New System.Drawing.Point(343, 3)
        Me.mtxBUMON_KB.MaxByteLength = 0
        Me.mtxBUMON_KB.Name = "mtxBUMON_KB"
        Me.mtxBUMON_KB.ReadOnly = True
        Me.mtxBUMON_KB.SelectAllText = False
        Me.mtxBUMON_KB.Size = New System.Drawing.Size(94, 24)
        Me.mtxBUMON_KB.TabIndex = 128
        Me.mtxBUMON_KB.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.mtxBUMON_KB.WatermarkColor = System.Drawing.Color.Empty
        Me.mtxBUMON_KB.WatermarkText = Nothing
        '
        'Label14
        '
        Me.tlpFilter.SetColumnSpan(Me.Label14, 5)
        Me.Label14.Font = New System.Drawing.Font("Meiryo UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label14.Location = New System.Drawing.Point(443, 0)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(94, 30)
        Me.Label14.TabIndex = 85
        Me.Label14.Text = "起草者:"
        Me.Label14.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'mtxKISOU_TANTO
        '
        Me.mtxKISOU_TANTO.BackColor = System.Drawing.SystemColors.Control
        Me.tlpFilter.SetColumnSpan(Me.mtxKISOU_TANTO, 7)
        Me.mtxKISOU_TANTO.Font = New System.Drawing.Font("Meiryo UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.mtxKISOU_TANTO.ImeMode = System.Windows.Forms.ImeMode.Disable
        Me.mtxKISOU_TANTO.InputRequired = False
        Me.mtxKISOU_TANTO.Location = New System.Drawing.Point(543, 3)
        Me.mtxKISOU_TANTO.MaxByteLength = 0
        Me.mtxKISOU_TANTO.Name = "mtxKISOU_TANTO"
        Me.mtxKISOU_TANTO.ReadOnly = True
        Me.mtxKISOU_TANTO.SelectAllText = False
        Me.mtxKISOU_TANTO.Size = New System.Drawing.Size(134, 24)
        Me.mtxKISOU_TANTO.TabIndex = 129
        Me.mtxKISOU_TANTO.WatermarkColor = System.Drawing.Color.Empty
        Me.mtxKISOU_TANTO.WatermarkText = Nothing
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
        'mtxKISYU
        '
        Me.mtxKISYU.BackColor = System.Drawing.SystemColors.Control
        Me.tlpFilter.SetColumnSpan(Me.mtxKISYU, 8)
        Me.mtxKISYU.Font = New System.Drawing.Font("Meiryo UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.mtxKISYU.ImeMode = System.Windows.Forms.ImeMode.Disable
        Me.mtxKISYU.InputRequired = False
        Me.mtxKISYU.Location = New System.Drawing.Point(103, 33)
        Me.mtxKISYU.MaxByteLength = 0
        Me.mtxKISYU.Name = "mtxKISYU"
        Me.mtxKISYU.ReadOnly = True
        Me.mtxKISYU.SelectAllText = False
        Me.mtxKISYU.Size = New System.Drawing.Size(154, 24)
        Me.mtxKISYU.TabIndex = 122
        Me.mtxKISYU.WatermarkColor = System.Drawing.Color.Empty
        Me.mtxKISYU.WatermarkText = Nothing
        '
        'Label6
        '
        Me.tlpFilter.SetColumnSpan(Me.Label6, 4)
        Me.Label6.Font = New System.Drawing.Font("Meiryo UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label6.Location = New System.Drawing.Point(263, 30)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(74, 30)
        Me.Label6.TabIndex = 93
        Me.Label6.Text = "起草日:"
        Me.Label6.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'dtDraft
        '
        Me.dtDraft.BackColor = System.Drawing.SystemColors.Control
        Me.dtDraft.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.tlpFilter.SetColumnSpan(Me.dtDraft, 5)
        Me.dtDraft.Cursor = System.Windows.Forms.Cursors.Default
        Me.dtDraft.GotFocusedColor = System.Drawing.Color.FromArgb(CType(CType(190, Byte), Integer), CType(CType(180, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.dtDraft.Location = New System.Drawing.Point(343, 33)
        Me.dtDraft.MaxDate = New Date(9998, 12, 31, 0, 0, 0, 0)
        Me.dtDraft.MinDate = New Date(1753, 1, 1, 0, 0, 0, 0)
        Me.dtDraft.MinimumSize = New System.Drawing.Size(98, 24)
        Me.dtDraft.Name = "dtDraft"
        Me.dtDraft.ReadOnly = True
        Me.dtDraft.Size = New System.Drawing.Size(98, 24)
        Me.dtDraft.TabIndex = 3
        Me.dtDraft.TabStop = False
        Me.dtDraft.Value = ""
        Me.dtDraft.ValueNonFormat = ""
        '
        'Label1
        '
        Me.tlpFilter.SetColumnSpan(Me.Label1, 5)
        Me.Label1.Font = New System.Drawing.Font("Meiryo UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label1.Location = New System.Drawing.Point(443, 30)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(94, 30)
        Me.Label1.TabIndex = 130
        Me.Label1.Text = "FCCB議長:"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'mtxCM_TANTO
        '
        Me.mtxCM_TANTO.BackColor = System.Drawing.SystemColors.Control
        Me.tlpFilter.SetColumnSpan(Me.mtxCM_TANTO, 7)
        Me.mtxCM_TANTO.Font = New System.Drawing.Font("Meiryo UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.mtxCM_TANTO.ImeMode = System.Windows.Forms.ImeMode.Disable
        Me.mtxCM_TANTO.InputRequired = False
        Me.mtxCM_TANTO.Location = New System.Drawing.Point(543, 33)
        Me.mtxCM_TANTO.MaxByteLength = 0
        Me.mtxCM_TANTO.Name = "mtxCM_TANTO"
        Me.mtxCM_TANTO.ReadOnly = True
        Me.mtxCM_TANTO.SelectAllText = False
        Me.mtxCM_TANTO.Size = New System.Drawing.Size(134, 24)
        Me.mtxCM_TANTO.TabIndex = 131
        Me.mtxCM_TANTO.WatermarkColor = System.Drawing.Color.Empty
        Me.mtxCM_TANTO.WatermarkText = Nothing
        '
        'Label11
        '
        Me.tlpFilter.SetColumnSpan(Me.Label11, 5)
        Me.Label11.Font = New System.Drawing.Font("Meiryo UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label11.Location = New System.Drawing.Point(3, 60)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(94, 30)
        Me.Label11.TabIndex = 97
        Me.Label11.Text = "部品番号:"
        Me.Label11.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'mtxBUHIN_BANGO
        '
        Me.mtxBUHIN_BANGO.BackColor = System.Drawing.SystemColors.Control
        Me.tlpFilter.SetColumnSpan(Me.mtxBUHIN_BANGO, 12)
        Me.mtxBUHIN_BANGO.Font = New System.Drawing.Font("Meiryo UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.mtxBUHIN_BANGO.ImeMode = System.Windows.Forms.ImeMode.Disable
        Me.mtxBUHIN_BANGO.InputRequired = False
        Me.mtxBUHIN_BANGO.Location = New System.Drawing.Point(103, 63)
        Me.mtxBUHIN_BANGO.MaxByteLength = 0
        Me.mtxBUHIN_BANGO.Name = "mtxBUHIN_BANGO"
        Me.mtxBUHIN_BANGO.ReadOnly = True
        Me.mtxBUHIN_BANGO.SelectAllText = False
        Me.mtxBUHIN_BANGO.Size = New System.Drawing.Size(234, 24)
        Me.mtxBUHIN_BANGO.TabIndex = 127
        Me.mtxBUHIN_BANGO.WatermarkColor = System.Drawing.Color.Empty
        Me.mtxBUHIN_BANGO.WatermarkText = Nothing
        '
        'lblSYANAI_CD
        '
        Me.tlpFilter.SetColumnSpan(Me.lblSYANAI_CD, 5)
        Me.lblSYANAI_CD.Font = New System.Drawing.Font("Meiryo UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.lblSYANAI_CD.Location = New System.Drawing.Point(443, 60)
        Me.lblSYANAI_CD.Name = "lblSYANAI_CD"
        Me.lblSYANAI_CD.Size = New System.Drawing.Size(94, 30)
        Me.lblSYANAI_CD.TabIndex = 115
        Me.lblSYANAI_CD.Text = "社内コード:"
        Me.lblSYANAI_CD.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.lblSYANAI_CD.Visible = False
        '
        'mtxSYANAI_CD
        '
        Me.mtxSYANAI_CD.BackColor = System.Drawing.SystemColors.Control
        Me.tlpFilter.SetColumnSpan(Me.mtxSYANAI_CD, 7)
        Me.mtxSYANAI_CD.Font = New System.Drawing.Font("Meiryo UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.mtxSYANAI_CD.ImeMode = System.Windows.Forms.ImeMode.Disable
        Me.mtxSYANAI_CD.InputRequired = False
        Me.mtxSYANAI_CD.Location = New System.Drawing.Point(543, 63)
        Me.mtxSYANAI_CD.MaxByteLength = 0
        Me.mtxSYANAI_CD.Name = "mtxSYANAI_CD"
        Me.mtxSYANAI_CD.ReadOnly = True
        Me.mtxSYANAI_CD.SelectAllText = False
        Me.mtxSYANAI_CD.Size = New System.Drawing.Size(134, 24)
        Me.mtxSYANAI_CD.TabIndex = 126
        Me.mtxSYANAI_CD.Visible = False
        Me.mtxSYANAI_CD.WatermarkColor = System.Drawing.Color.Empty
        Me.mtxSYANAI_CD.WatermarkText = Nothing
        '
        'Label7
        '
        Me.tlpFilter.SetColumnSpan(Me.Label7, 5)
        Me.Label7.Font = New System.Drawing.Font("Meiryo UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label7.Location = New System.Drawing.Point(3, 90)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(94, 30)
        Me.Label7.TabIndex = 99
        Me.Label7.Text = "部品名称:"
        Me.Label7.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'mtxHINMEI
        '
        Me.mtxHINMEI.BackColor = System.Drawing.SystemColors.Control
        Me.tlpFilter.SetColumnSpan(Me.mtxHINMEI, 17)
        Me.mtxHINMEI.Font = New System.Drawing.Font("Meiryo UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.mtxHINMEI.ImeMode = System.Windows.Forms.ImeMode.Disable
        Me.mtxHINMEI.InputRequired = False
        Me.mtxHINMEI.Location = New System.Drawing.Point(103, 93)
        Me.mtxHINMEI.MaxByteLength = 0
        Me.mtxHINMEI.Name = "mtxHINMEI"
        Me.mtxHINMEI.ReadOnly = True
        Me.mtxHINMEI.SelectAllText = False
        Me.mtxHINMEI.Size = New System.Drawing.Size(334, 24)
        Me.mtxHINMEI.TabIndex = 6
        Me.mtxHINMEI.WatermarkColor = System.Drawing.Color.Empty
        Me.mtxHINMEI.WatermarkText = Nothing
        '
        'Label3
        '
        Me.tlpFilter.SetColumnSpan(Me.Label3, 5)
        Me.Label3.Font = New System.Drawing.Font("Meiryo UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label3.Location = New System.Drawing.Point(3, 120)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(94, 30)
        Me.Label3.TabIndex = 132
        Me.Label3.Text = "インプット文書等:"
        Me.Label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'mtxINPUT_DOC_NO
        '
        Me.mtxINPUT_DOC_NO.BackColor = System.Drawing.SystemColors.Control
        Me.tlpFilter.SetColumnSpan(Me.mtxINPUT_DOC_NO, 17)
        Me.mtxINPUT_DOC_NO.Font = New System.Drawing.Font("Meiryo UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.mtxINPUT_DOC_NO.ImeMode = System.Windows.Forms.ImeMode.[On]
        Me.mtxINPUT_DOC_NO.InputRequired = False
        Me.mtxINPUT_DOC_NO.Location = New System.Drawing.Point(103, 123)
        Me.mtxINPUT_DOC_NO.MaxByteLength = 0
        Me.mtxINPUT_DOC_NO.Name = "mtxINPUT_DOC_NO"
        Me.mtxINPUT_DOC_NO.ReadOnly = True
        Me.mtxINPUT_DOC_NO.SelectAllText = False
        Me.mtxINPUT_DOC_NO.Size = New System.Drawing.Size(334, 24)
        Me.mtxINPUT_DOC_NO.TabIndex = 133
        Me.mtxINPUT_DOC_NO.WatermarkColor = System.Drawing.Color.Empty
        Me.mtxINPUT_DOC_NO.WatermarkText = Nothing
        '
        'Label17
        '
        Me.tlpFilter.SetColumnSpan(Me.Label17, 6)
        Me.Label17.Font = New System.Drawing.Font("Meiryo UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label17.Location = New System.Drawing.Point(443, 120)
        Me.Label17.Name = "Label17"
        Me.Label17.Size = New System.Drawing.Size(114, 30)
        Me.Label17.TabIndex = 134
        Me.Label17.Text = "SNo./号機 時期等:"
        Me.Label17.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'mtxSNO_APPLY_PERIOD_KISO
        '
        Me.mtxSNO_APPLY_PERIOD_KISO.BackColor = System.Drawing.SystemColors.Control
        Me.tlpFilter.SetColumnSpan(Me.mtxSNO_APPLY_PERIOD_KISO, 7)
        Me.mtxSNO_APPLY_PERIOD_KISO.Font = New System.Drawing.Font("Meiryo UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.mtxSNO_APPLY_PERIOD_KISO.ImeMode = System.Windows.Forms.ImeMode.[On]
        Me.mtxSNO_APPLY_PERIOD_KISO.InputRequired = False
        Me.mtxSNO_APPLY_PERIOD_KISO.Location = New System.Drawing.Point(563, 123)
        Me.mtxSNO_APPLY_PERIOD_KISO.MaxByteLength = 0
        Me.mtxSNO_APPLY_PERIOD_KISO.Name = "mtxSNO_APPLY_PERIOD_KISO"
        Me.mtxSNO_APPLY_PERIOD_KISO.ReadOnly = True
        Me.mtxSNO_APPLY_PERIOD_KISO.SelectAllText = False
        Me.mtxSNO_APPLY_PERIOD_KISO.Size = New System.Drawing.Size(134, 24)
        Me.mtxSNO_APPLY_PERIOD_KISO.TabIndex = 135
        Me.mtxSNO_APPLY_PERIOD_KISO.WatermarkColor = System.Drawing.Color.Empty
        Me.mtxSNO_APPLY_PERIOD_KISO.WatermarkText = Nothing
        '
        'Label18
        '
        Me.tlpFilter.SetColumnSpan(Me.Label18, 4)
        Me.Label18.Font = New System.Drawing.Font("Meiryo UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label18.Location = New System.Drawing.Point(683, 0)
        Me.Label18.Name = "Label18"
        Me.Label18.Size = New System.Drawing.Size(74, 30)
        Me.Label18.TabIndex = 282
        Me.Label18.Text = "変更内容:"
        Me.Label18.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'txtINPUT_NAIYO
        '
        Me.txtINPUT_NAIYO.AcceptsReturn = True
        Me.tlpFilter.SetColumnSpan(Me.txtINPUT_NAIYO, 23)
        Me.txtINPUT_NAIYO.Enabled = False
        Me.txtINPUT_NAIYO.Font = New System.Drawing.Font("Meiryo UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.txtINPUT_NAIYO.ImeMode = System.Windows.Forms.ImeMode.[On]
        Me.txtINPUT_NAIYO.InputRequired = False
        Me.txtINPUT_NAIYO.Location = New System.Drawing.Point(763, 3)
        Me.txtINPUT_NAIYO.MaxByteLength = 600
        Me.txtINPUT_NAIYO.MaxLength = 300
        Me.txtINPUT_NAIYO.Multiline = True
        Me.txtINPUT_NAIYO.Name = "txtINPUT_NAIYO"
        Me.tlpFilter.SetRowSpan(Me.txtINPUT_NAIYO, 5)
        Me.txtINPUT_NAIYO.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.txtINPUT_NAIYO.SelectAllText = False
        Me.txtINPUT_NAIYO.ShowRemainingChars = True
        Me.txtINPUT_NAIYO.Size = New System.Drawing.Size(454, 144)
        Me.txtINPUT_NAIYO.TabIndex = 283
        Me.txtINPUT_NAIYO.WatermarkColor = System.Drawing.Color.Empty
        Me.txtINPUT_NAIYO.WatermarkText = Nothing
        '
        'FrmG0022_Rireki
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.ClientSize = New System.Drawing.Size(1264, 861)
        Me.Controls.Add(Me.gbxFilter)
        Me.Controls.Add(Me.dgvDATA)
        Me.HelpButton = True
        Me.Name = "FrmG0022_Rireki"
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
        CType(Me.WarningErrorProvider, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dgvDATA, System.ComponentModel.ISupportInitialize).EndInit()
        Me.gbxFilter.ResumeLayout(False)
        Me.tlpFilter.ResumeLayout(False)
        Me.tlpFilter.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents dgvDATA As DataGridView
    Friend WithEvents gbxFilter As GroupBox
    Friend WithEvents tlpFilter As TableLayoutPanel
    Friend WithEvents Label9 As Label
    Friend WithEvents Label14 As Label
    Friend WithEvents mtxHOKUKO_NO As MaskedTextBoxEx
    Friend WithEvents Label8 As Label
    Friend WithEvents Label16 As Label
    Friend WithEvents Label11 As Label
    Friend WithEvents Label7 As Label
    Friend WithEvents mtxHINMEI As MaskedTextBoxEx
    Friend WithEvents Label6 As Label
    Friend WithEvents lblSYANAI_CD As Label
    Friend WithEvents dtDraft As DateTextBoxEx
    Friend WithEvents mtxKISYU As MaskedTextBoxEx
    Friend WithEvents mtxSYANAI_CD As MaskedTextBoxEx
    Friend WithEvents mtxBUHIN_BANGO As MaskedTextBoxEx
    Friend WithEvents mtxBUMON_KB As MaskedTextBoxEx
    Friend WithEvents mtxKISOU_TANTO As MaskedTextBoxEx
    Friend WithEvents Label1 As Label
    Friend WithEvents mtxCM_TANTO As MaskedTextBoxEx
    Friend WithEvents Label3 As Label
    Friend WithEvents mtxINPUT_DOC_NO As MaskedTextBoxEx
    Friend WithEvents Label17 As Label
    Friend WithEvents mtxSNO_APPLY_PERIOD_KISO As MaskedTextBoxEx
    Friend WithEvents Label18 As Label
    Friend WithEvents txtINPUT_NAIYO As TextBoxEx
End Class
