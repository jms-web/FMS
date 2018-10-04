<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class FrmM1071
    Inherits JMS_COMMON.frmBaseBtn

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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmM1071))
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.TableLayoutPanel1 = New System.Windows.Forms.TableLayoutPanel()
        Me.lblEDIT_YMDHNS = New System.Windows.Forms.Label()
        Me.lblEDIT_SYAIN_ID = New System.Windows.Forms.Label()
        Me.lbllblEDIT_YMDHNS = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.lbllblEDIT_SYAIN_ID = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.mtxBumon_KB = New JMS_COMMON.MaskedTextBoxEx()
        Me.mtxTORI_NAME = New JMS_COMMON.MaskedTextBoxEx()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.mtxBUHIN_BANGO = New JMS_COMMON.MaskedTextBoxEx()
        Me.mtxBUHIN_NAME = New JMS_COMMON.MaskedTextBoxEx()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.mtxKISYU_NAME = New JMS_COMMON.MaskedTextBoxEx()
        Me.flxDATA = New C1.Win.C1FlexGrid.C1FlexGrid()
        Me.VWM105KISYUBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.btnSRCH = New System.Windows.Forms.Button()
        CType(Me.ErrorProvider, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox1.SuspendLayout()
        Me.TableLayoutPanel1.SuspendLayout()
        CType(Me.flxDATA, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.VWM105KISYUBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'cmdFunc1
        '
        Me.cmdFunc1.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.cmdFunc1.Image = Global.FMS.My.Resources.Resources._imgBase_floppydisk32x32
        Me.cmdFunc1.Location = New System.Drawing.Point(12, 465)
        Me.cmdFunc1.Size = New System.Drawing.Size(156, 42)
        Me.cmdFunc1.TabIndex = 0
        Me.cmdFunc1.Text = "追加(F1)"
        '
        'cmdFunc2
        '
        Me.cmdFunc2.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.cmdFunc2.Location = New System.Drawing.Point(338, 474)
        Me.cmdFunc2.Size = New System.Drawing.Size(23, 33)
        Me.cmdFunc2.Visible = False
        '
        'cmdFunc3
        '
        Me.cmdFunc3.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.cmdFunc3.Location = New System.Drawing.Point(499, 474)
        Me.cmdFunc3.Size = New System.Drawing.Size(23, 33)
        Me.cmdFunc3.Visible = False
        '
        'cmdFunc4
        '
        Me.cmdFunc4.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.cmdFunc4.Location = New System.Drawing.Point(660, 474)
        Me.cmdFunc4.Size = New System.Drawing.Size(23, 33)
        Me.cmdFunc4.Visible = False
        '
        'cmdFunc5
        '
        Me.cmdFunc5.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.cmdFunc5.Location = New System.Drawing.Point(821, 474)
        Me.cmdFunc5.Size = New System.Drawing.Size(23, 33)
        Me.cmdFunc5.Visible = False
        '
        'cmdFunc6
        '
        Me.cmdFunc6.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.cmdFunc6.Location = New System.Drawing.Point(982, 474)
        Me.cmdFunc6.Size = New System.Drawing.Size(23, 33)
        Me.cmdFunc6.Visible = False
        '
        'cmdFunc12
        '
        Me.cmdFunc12.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.cmdFunc12.Image = Global.FMS.My.Resources.Resources._imgLog_Out32x32
        Me.cmdFunc12.Location = New System.Drawing.Point(1096, 465)
        Me.cmdFunc12.Size = New System.Drawing.Size(156, 42)
        Me.cmdFunc12.TabIndex = 1
        Me.cmdFunc12.Text = "キャンセル(F12)"
        '
        'cmdFunc11
        '
        Me.cmdFunc11.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.cmdFunc11.Location = New System.Drawing.Point(821, 474)
        Me.cmdFunc11.Size = New System.Drawing.Size(23, 33)
        Me.cmdFunc11.Visible = False
        '
        'cmdFunc10
        '
        Me.cmdFunc10.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.cmdFunc10.Location = New System.Drawing.Point(660, 474)
        Me.cmdFunc10.Size = New System.Drawing.Size(23, 33)
        Me.cmdFunc10.Visible = False
        '
        'cmdFunc7
        '
        Me.cmdFunc7.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.cmdFunc7.Location = New System.Drawing.Point(177, 474)
        Me.cmdFunc7.Size = New System.Drawing.Size(23, 33)
        Me.cmdFunc7.Visible = False
        '
        'cmdFunc9
        '
        Me.cmdFunc9.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.cmdFunc9.Location = New System.Drawing.Point(499, 474)
        Me.cmdFunc9.Size = New System.Drawing.Size(23, 33)
        Me.cmdFunc9.Visible = False
        '
        'cmdFunc8
        '
        Me.cmdFunc8.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.cmdFunc8.Location = New System.Drawing.Point(338, 474)
        Me.cmdFunc8.Size = New System.Drawing.Size(23, 33)
        Me.cmdFunc8.Visible = False
        '
        'lblTytle
        '
        Me.lblTytle.Size = New System.Drawing.Size(1240, 45)
        Me.lblTytle.Text = "追加/変更"
        '
        'ToolTip
        '
        Me.ToolTip.InitialDelay = 700
        '
        'ErrorProvider
        '
        Me.ErrorProvider.BlinkStyle = System.Windows.Forms.ErrorBlinkStyle.NeverBlink
        '
        'GroupBox1
        '
        Me.GroupBox1.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GroupBox1.Controls.Add(Me.TableLayoutPanel1)
        Me.GroupBox1.Font = New System.Drawing.Font("ＭＳ ゴシック", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.GroupBox1.Location = New System.Drawing.Point(12, 60)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(1239, 90)
        Me.GroupBox1.TabIndex = 31
        Me.GroupBox1.TabStop = False
        '
        'TableLayoutPanel1
        '
        Me.TableLayoutPanel1.ColumnCount = 6
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 100.0!))
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 202.0!))
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 121.0!))
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 105.0!))
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 182.0!))
        Me.TableLayoutPanel1.Controls.Add(Me.lblEDIT_YMDHNS, 5, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.lblEDIT_SYAIN_ID, 5, 1)
        Me.TableLayoutPanel1.Controls.Add(Me.lbllblEDIT_YMDHNS, 4, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.Label6, 0, 1)
        Me.TableLayoutPanel1.Controls.Add(Me.lbllblEDIT_SYAIN_ID, 4, 1)
        Me.TableLayoutPanel1.Controls.Add(Me.Label5, 2, 1)
        Me.TableLayoutPanel1.Controls.Add(Me.Label1, 0, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.mtxBumon_KB, 1, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.mtxTORI_NAME, 3, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.Label3, 2, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.mtxBUHIN_BANGO, 1, 1)
        Me.TableLayoutPanel1.Controls.Add(Me.mtxBUHIN_NAME, 3, 1)
        Me.TableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TableLayoutPanel1.Font = New System.Drawing.Font("Meiryo UI", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.TableLayoutPanel1.Location = New System.Drawing.Point(3, 18)
        Me.TableLayoutPanel1.Name = "TableLayoutPanel1"
        Me.TableLayoutPanel1.RowCount = 3
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20.0!))
        Me.TableLayoutPanel1.Size = New System.Drawing.Size(1233, 69)
        Me.TableLayoutPanel1.TabIndex = 47
        '
        'lblEDIT_YMDHNS
        '
        Me.lblEDIT_YMDHNS.BackColor = System.Drawing.Color.Transparent
        Me.lblEDIT_YMDHNS.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblEDIT_YMDHNS.Dock = System.Windows.Forms.DockStyle.Fill
        Me.lblEDIT_YMDHNS.Enabled = False
        Me.lblEDIT_YMDHNS.Font = New System.Drawing.Font("Meiryo UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.lblEDIT_YMDHNS.Location = New System.Drawing.Point(1054, 0)
        Me.lblEDIT_YMDHNS.Name = "lblEDIT_YMDHNS"
        Me.lblEDIT_YMDHNS.Size = New System.Drawing.Size(176, 30)
        Me.lblEDIT_YMDHNS.TabIndex = 43
        Me.lblEDIT_YMDHNS.Text = "yyyy/MM/dd HH:mm:ss"
        Me.lblEDIT_YMDHNS.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.lblEDIT_YMDHNS.Visible = False
        '
        'lblEDIT_SYAIN_ID
        '
        Me.lblEDIT_SYAIN_ID.BackColor = System.Drawing.Color.Transparent
        Me.lblEDIT_SYAIN_ID.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblEDIT_SYAIN_ID.Dock = System.Windows.Forms.DockStyle.Fill
        Me.lblEDIT_SYAIN_ID.Enabled = False
        Me.lblEDIT_SYAIN_ID.Font = New System.Drawing.Font("Meiryo UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.lblEDIT_SYAIN_ID.Location = New System.Drawing.Point(1054, 30)
        Me.lblEDIT_SYAIN_ID.Name = "lblEDIT_SYAIN_ID"
        Me.lblEDIT_SYAIN_ID.Size = New System.Drawing.Size(176, 30)
        Me.lblEDIT_SYAIN_ID.TabIndex = 66
        Me.lblEDIT_SYAIN_ID.Text = "xxx xxx"
        Me.lblEDIT_SYAIN_ID.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.lblEDIT_SYAIN_ID.Visible = False
        '
        'lbllblEDIT_YMDHNS
        '
        Me.lbllblEDIT_YMDHNS.Dock = System.Windows.Forms.DockStyle.Fill
        Me.lbllblEDIT_YMDHNS.Font = New System.Drawing.Font("Meiryo UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.lbllblEDIT_YMDHNS.Location = New System.Drawing.Point(949, 0)
        Me.lbllblEDIT_YMDHNS.Name = "lbllblEDIT_YMDHNS"
        Me.lbllblEDIT_YMDHNS.Size = New System.Drawing.Size(99, 30)
        Me.lbllblEDIT_YMDHNS.TabIndex = 56
        Me.lbllblEDIT_YMDHNS.Text = "最終更新日時:"
        Me.lbllblEDIT_YMDHNS.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.lbllblEDIT_YMDHNS.Visible = False
        '
        'Label6
        '
        Me.Label6.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Label6.Font = New System.Drawing.Font("Meiryo UI", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label6.Location = New System.Drawing.Point(3, 30)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(94, 30)
        Me.Label6.TabIndex = 39
        Me.Label6.Text = "部品番号:"
        Me.Label6.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'lbllblEDIT_SYAIN_ID
        '
        Me.lbllblEDIT_SYAIN_ID.Dock = System.Windows.Forms.DockStyle.Fill
        Me.lbllblEDIT_SYAIN_ID.Font = New System.Drawing.Font("Meiryo UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.lbllblEDIT_SYAIN_ID.Location = New System.Drawing.Point(949, 30)
        Me.lbllblEDIT_SYAIN_ID.Name = "lbllblEDIT_SYAIN_ID"
        Me.lbllblEDIT_SYAIN_ID.Size = New System.Drawing.Size(99, 30)
        Me.lbllblEDIT_SYAIN_ID.TabIndex = 65
        Me.lbllblEDIT_SYAIN_ID.Text = "最終更新者:"
        Me.lbllblEDIT_SYAIN_ID.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label5
        '
        Me.Label5.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Label5.Font = New System.Drawing.Font("Meiryo UI", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label5.Location = New System.Drawing.Point(305, 30)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(115, 30)
        Me.Label5.TabIndex = 38
        Me.Label5.Text = "部品名:"
        Me.Label5.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label1
        '
        Me.Label1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Label1.Font = New System.Drawing.Font("Meiryo UI", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label1.Location = New System.Drawing.Point(3, 0)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(94, 30)
        Me.Label1.TabIndex = 67
        Me.Label1.Text = "部門区分:"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'mtxBumon_KB
        '
        Me.mtxBumon_KB.BackColor = System.Drawing.SystemColors.Menu
        Me.mtxBumon_KB.Enabled = False
        Me.mtxBumon_KB.GotFocusedColor = System.Drawing.Color.FromArgb(CType(CType(190, Byte), Integer), CType(CType(180, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.mtxBumon_KB.ImeMode = System.Windows.Forms.ImeMode.Disable
        Me.mtxBumon_KB.InputRequired = False
        Me.mtxBumon_KB.Location = New System.Drawing.Point(103, 3)
        Me.mtxBumon_KB.MaxByteLength = 0
        Me.mtxBumon_KB.Name = "mtxBumon_KB"
        Me.mtxBumon_KB.Size = New System.Drawing.Size(121, 23)
        Me.mtxBumon_KB.TabIndex = 68
        Me.mtxBumon_KB.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.mtxBumon_KB.WatermarkColor = System.Drawing.Color.Empty
        Me.mtxBumon_KB.WatermarkText = Nothing
        '
        'mtxTORI_NAME
        '
        Me.mtxTORI_NAME.BackColor = System.Drawing.SystemColors.Menu
        Me.mtxTORI_NAME.Enabled = False
        Me.mtxTORI_NAME.GotFocusedColor = System.Drawing.Color.FromArgb(CType(CType(190, Byte), Integer), CType(CType(180, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.mtxTORI_NAME.ImeMode = System.Windows.Forms.ImeMode.Disable
        Me.mtxTORI_NAME.InputRequired = False
        Me.mtxTORI_NAME.Location = New System.Drawing.Point(426, 3)
        Me.mtxTORI_NAME.MaxByteLength = 0
        Me.mtxTORI_NAME.Name = "mtxTORI_NAME"
        Me.mtxTORI_NAME.Size = New System.Drawing.Size(287, 23)
        Me.mtxTORI_NAME.TabIndex = 69
        Me.mtxTORI_NAME.WatermarkColor = System.Drawing.Color.Empty
        Me.mtxTORI_NAME.WatermarkText = Nothing
        '
        'Label3
        '
        Me.Label3.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Label3.Font = New System.Drawing.Font("Meiryo UI", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label3.Location = New System.Drawing.Point(305, 0)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(115, 30)
        Me.Label3.TabIndex = 70
        Me.Label3.Text = "取引先名:"
        Me.Label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'mtxBUHIN_BANGO
        '
        Me.mtxBUHIN_BANGO.BackColor = System.Drawing.SystemColors.Menu
        Me.mtxBUHIN_BANGO.Enabled = False
        Me.mtxBUHIN_BANGO.GotFocusedColor = System.Drawing.Color.FromArgb(CType(CType(190, Byte), Integer), CType(CType(180, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.mtxBUHIN_BANGO.ImeMode = System.Windows.Forms.ImeMode.[On]
        Me.mtxBUHIN_BANGO.InputRequired = False
        Me.mtxBUHIN_BANGO.Location = New System.Drawing.Point(103, 33)
        Me.mtxBUHIN_BANGO.MaxByteLength = 30
        Me.mtxBUHIN_BANGO.Name = "mtxBUHIN_BANGO"
        Me.mtxBUHIN_BANGO.Size = New System.Drawing.Size(196, 23)
        Me.mtxBUHIN_BANGO.TabIndex = 107
        Me.mtxBUHIN_BANGO.WatermarkColor = System.Drawing.Color.Empty
        Me.mtxBUHIN_BANGO.WatermarkText = Nothing
        '
        'mtxBUHIN_NAME
        '
        Me.mtxBUHIN_NAME.BackColor = System.Drawing.SystemColors.Menu
        Me.mtxBUHIN_NAME.Enabled = False
        Me.mtxBUHIN_NAME.GotFocusedColor = System.Drawing.Color.FromArgb(CType(CType(190, Byte), Integer), CType(CType(180, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.mtxBUHIN_NAME.ImeMode = System.Windows.Forms.ImeMode.[On]
        Me.mtxBUHIN_NAME.InputRequired = False
        Me.mtxBUHIN_NAME.Location = New System.Drawing.Point(426, 33)
        Me.mtxBUHIN_NAME.MaxByteLength = 30
        Me.mtxBUHIN_NAME.Name = "mtxBUHIN_NAME"
        Me.mtxBUHIN_NAME.Size = New System.Drawing.Size(287, 23)
        Me.mtxBUHIN_NAME.TabIndex = 108
        Me.mtxBUHIN_NAME.WatermarkColor = System.Drawing.Color.Empty
        Me.mtxBUHIN_NAME.WatermarkText = Nothing
        '
        'Label2
        '
        Me.Label2.Font = New System.Drawing.Font("Meiryo UI", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label2.Location = New System.Drawing.Point(18, 174)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(94, 30)
        Me.Label2.TabIndex = 39
        Me.Label2.Text = "機種名検索:"
        Me.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'mtxKISYU_NAME
        '
        Me.mtxKISYU_NAME.BackColor = System.Drawing.SystemColors.Window
        Me.mtxKISYU_NAME.Font = New System.Drawing.Font("Meiryo UI", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.mtxKISYU_NAME.GotFocusedColor = System.Drawing.Color.FromArgb(CType(CType(190, Byte), Integer), CType(CType(180, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.mtxKISYU_NAME.ImeMode = System.Windows.Forms.ImeMode.[On]
        Me.mtxKISYU_NAME.InputRequired = False
        Me.mtxKISYU_NAME.Location = New System.Drawing.Point(118, 175)
        Me.mtxKISYU_NAME.MaxByteLength = 30
        Me.mtxKISYU_NAME.Name = "mtxKISYU_NAME"
        Me.mtxKISYU_NAME.Size = New System.Drawing.Size(155, 24)
        Me.mtxKISYU_NAME.TabIndex = 59
        Me.mtxKISYU_NAME.WatermarkColor = System.Drawing.Color.Empty
        Me.mtxKISYU_NAME.WatermarkText = Nothing
        '
        'flxDATA
        '
        Me.flxDATA.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.flxDATA.ColumnInfo = resources.GetString("flxDATA.ColumnInfo")
        Me.flxDATA.DataSource = Me.VWM105KISYUBindingSource
        Me.flxDATA.Font = New System.Drawing.Font("Meiryo UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.flxDATA.Location = New System.Drawing.Point(472, 167)
        Me.flxDATA.Name = "flxDATA"
        Me.flxDATA.Rows.Count = 1
        Me.flxDATA.Rows.DefaultSize = 23
        Me.flxDATA.Size = New System.Drawing.Size(314, 533)
        Me.flxDATA.StyleInfo = resources.GetString("flxDATA.StyleInfo")
        Me.flxDATA.TabIndex = 62
        Me.flxDATA.VisualStyle = C1.Win.C1FlexGrid.VisualStyle.Office2010Silver
        '
        'VWM105KISYUBindingSource
        '
        Me.VWM105KISYUBindingSource.DataSource = GetType(MODEL.VWM105_KISYU)
        '
        'btnSRCH
        '
        Me.btnSRCH.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnSRCH.Font = New System.Drawing.Font("Meiryo UI", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.btnSRCH.Image = Global.FMS.My.Resources.Resources._imgSearch32x32
        Me.btnSRCH.Location = New System.Drawing.Point(314, 168)
        Me.btnSRCH.Name = "btnSRCH"
        Me.btnSRCH.Size = New System.Drawing.Size(121, 42)
        Me.btnSRCH.TabIndex = 64
        Me.btnSRCH.Text = "検索"
        Me.btnSRCH.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.btnSRCH.UseVisualStyleBackColor = True
        '
        'FrmM1071
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.BackColor = System.Drawing.SystemColors.Control
        Me.ClientSize = New System.Drawing.Size(1264, 712)
        Me.Controls.Add(Me.btnSRCH)
        Me.Controls.Add(Me.flxDATA)
        Me.Controls.Add(Me.mtxKISYU_NAME)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.GroupBox1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.HelpButton = True
        Me.MinimumSize = New System.Drawing.Size(1280, 300)
        Me.Name = "FrmM1071"
        Me.ShowInTaskbar = False
        Me.Controls.SetChildIndex(Me.GroupBox1, 0)
        Me.Controls.SetChildIndex(Me.lblTytle, 0)
        Me.Controls.SetChildIndex(Me.cmdFunc8, 0)
        Me.Controls.SetChildIndex(Me.cmdFunc9, 0)
        Me.Controls.SetChildIndex(Me.cmdFunc7, 0)
        Me.Controls.SetChildIndex(Me.cmdFunc10, 0)
        Me.Controls.SetChildIndex(Me.cmdFunc11, 0)
        Me.Controls.SetChildIndex(Me.cmdFunc6, 0)
        Me.Controls.SetChildIndex(Me.cmdFunc5, 0)
        Me.Controls.SetChildIndex(Me.cmdFunc4, 0)
        Me.Controls.SetChildIndex(Me.cmdFunc3, 0)
        Me.Controls.SetChildIndex(Me.cmdFunc2, 0)
        Me.Controls.SetChildIndex(Me.cmdFunc1, 0)
        Me.Controls.SetChildIndex(Me.cmdFunc12, 0)
        Me.Controls.SetChildIndex(Me.Label2, 0)
        Me.Controls.SetChildIndex(Me.mtxKISYU_NAME, 0)
        Me.Controls.SetChildIndex(Me.flxDATA, 0)
        Me.Controls.SetChildIndex(Me.btnSRCH, 0)
        CType(Me.ErrorProvider, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox1.ResumeLayout(False)
        Me.TableLayoutPanel1.ResumeLayout(False)
        Me.TableLayoutPanel1.PerformLayout()
        CType(Me.flxDATA, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.VWM105KISYUBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents lbllblEDIT_YMDHNS As Label
    Public WithEvents lblEDIT_SYAIN_ID As Label
    Friend WithEvents lbllblEDIT_SYAIN_ID As Label
    Public WithEvents lblEDIT_YMDHNS As Label
    Friend WithEvents TableLayoutPanel1 As TableLayoutPanel
    Friend WithEvents Label5 As Label
    Friend WithEvents Label6 As Label
    Friend WithEvents Label1 As Label
    Friend WithEvents mtxBumon_KB As MaskedTextBoxEx
    Friend WithEvents mtxTORI_NAME As MaskedTextBoxEx
    Friend WithEvents Label3 As Label
    Friend WithEvents mtxBUHIN_BANGO As MaskedTextBoxEx
    Friend WithEvents mtxBUHIN_NAME As MaskedTextBoxEx
    Friend WithEvents Label2 As Label
    Friend WithEvents mtxKISYU_NAME As MaskedTextBoxEx
    Friend WithEvents flxDATA As C1.Win.C1FlexGrid.C1FlexGrid
    Friend WithEvents VWM105KISYUBindingSource As BindingSource
    Friend WithEvents btnSRCH As Button
End Class
