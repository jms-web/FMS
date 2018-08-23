<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class FrmM1060
    Inherits JMS_COMMON.frmBaseStsBtnDgv

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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmM1060))
        Me.SaveFileDialog = New System.Windows.Forms.SaveFileDialog()
        Me.OpenFileDialog = New System.Windows.Forms.OpenFileDialog()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.gbxFilter = New System.Windows.Forms.GroupBox()
        Me.tlpFilter = New System.Windows.Forms.TableLayoutPanel()
        Me.btnClearSrchFilter = New System.Windows.Forms.Button()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.cmbBUMON_KB = New JMS_COMMON.ComboboxEx()
        Me.chkDeletedRowVisibled = New System.Windows.Forms.CheckBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.ComboboxEx1 = New JMS_COMMON.ComboboxEx()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.MaskedTextBoxEx1 = New JMS_COMMON.MaskedTextBoxEx()
        Me.mtxKISYU_NAME = New JMS_COMMON.MaskedTextBoxEx()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.MaskedTextBoxEx2 = New JMS_COMMON.MaskedTextBoxEx()
        Me.flxDATA = New C1.Win.C1FlexGrid.C1FlexGrid()
        Me.VWM106BUHINBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        CType(Me.ErrorProvider, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.gbxFilter.SuspendLayout()
        Me.tlpFilter.SuspendLayout()
        CType(Me.flxDATA, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.VWM106BUHINBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'lblRecordCount
        '
        Me.lblRecordCount.Location = New System.Drawing.Point(12, 566)
        Me.lblRecordCount.Size = New System.Drawing.Size(412, 24)
        '
        'cmdFunc1
        '
        Me.cmdFunc1.Image = Global.FMS.My.Resources.Resources._imgSearch32x32
        Me.cmdFunc1.Location = New System.Drawing.Point(9, 596)
        Me.cmdFunc1.Text = "検索(F1)"
        '
        'cmdFunc2
        '
        Me.cmdFunc2.Image = Global.FMS.My.Resources.Resources._imgApplication_form_add32x32
        Me.cmdFunc2.Location = New System.Drawing.Point(218, 596)
        Me.cmdFunc2.Text = "追加(F2)"
        '
        'cmdFunc3
        '
        Me.cmdFunc3.Image = Global.FMS.My.Resources.Resources._imgApplication_form_add32x32
        Me.cmdFunc3.Location = New System.Drawing.Point(427, 596)
        Me.cmdFunc3.Text = "類似追加(F3)"
        '
        'cmdFunc4
        '
        Me.cmdFunc4.Image = Global.FMS.My.Resources.Resources._imgApplication_form_edit32x32
        Me.cmdFunc4.Location = New System.Drawing.Point(636, 596)
        Me.cmdFunc4.Text = "変更(F4)"
        '
        'cmdFunc5
        '
        Me.cmdFunc5.Image = Global.FMS.My.Resources.Resources._imgStatusAnnotations_Blocked_32x32_MD
        Me.cmdFunc5.Location = New System.Drawing.Point(845, 596)
        Me.cmdFunc5.Text = "削除(F5)"
        '
        'cmdFunc6
        '
        Me.cmdFunc6.Image = Global.FMS.My.Resources.Resources._imgRecovery32x32
        Me.cmdFunc6.Location = New System.Drawing.Point(1054, 596)
        Me.cmdFunc6.Text = "復元(F6)"
        '
        'cmdFunc12
        '
        Me.cmdFunc12.Image = Global.FMS.My.Resources.Resources._imgLog_Out32x32
        Me.cmdFunc12.Location = New System.Drawing.Point(1054, 644)
        Me.cmdFunc12.Text = "閉じる(F12)"
        '
        'cmdFunc11
        '
        Me.cmdFunc11.Location = New System.Drawing.Point(845, 644)
        '
        'cmdFunc10
        '
        Me.cmdFunc10.Image = Global.FMS.My.Resources.Resources._imgExportToExcel32x32
        Me.cmdFunc10.Location = New System.Drawing.Point(636, 644)
        Me.cmdFunc10.Text = "CSV出力(F10)"
        '
        'cmdFunc7
        '
        Me.cmdFunc7.Location = New System.Drawing.Point(9, 644)
        '
        'cmdFunc9
        '
        Me.cmdFunc9.Location = New System.Drawing.Point(427, 644)
        '
        'cmdFunc8
        '
        Me.cmdFunc8.Location = New System.Drawing.Point(218, 644)
        '
        'lblTytle
        '
        Me.lblTytle.Font = New System.Drawing.Font("Meiryo UI", 24.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTytle.Size = New System.Drawing.Size(1238, 45)
        Me.lblTytle.Text = "部品番号マスタ"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Meiryo UI", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label3.Location = New System.Drawing.Point(3, 30)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(65, 17)
        Me.Label3.TabIndex = 54
        Me.Label3.Text = "部品番号:"
        Me.Label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'gbxFilter
        '
        Me.gbxFilter.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.gbxFilter.Controls.Add(Me.tlpFilter)
        Me.gbxFilter.Font = New System.Drawing.Font("Meiryo UI", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.gbxFilter.Location = New System.Drawing.Point(14, 60)
        Me.gbxFilter.Name = "gbxFilter"
        Me.gbxFilter.Size = New System.Drawing.Size(1236, 87)
        Me.gbxFilter.TabIndex = 59
        Me.gbxFilter.TabStop = False
        Me.gbxFilter.Text = "検索条件"
        '
        'tlpFilter
        '
        Me.tlpFilter.ColumnCount = 8
        Me.tlpFilter.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 76.0!))
        Me.tlpFilter.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 164.0!))
        Me.tlpFilter.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 79.0!))
        Me.tlpFilter.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.tlpFilter.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 82.0!))
        Me.tlpFilter.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 414.0!))
        Me.tlpFilter.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 124.0!))
        Me.tlpFilter.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 119.0!))
        Me.tlpFilter.Controls.Add(Me.btnClearSrchFilter, 7, 0)
        Me.tlpFilter.Controls.Add(Me.Label1, 0, 0)
        Me.tlpFilter.Controls.Add(Me.cmbBUMON_KB, 1, 0)
        Me.tlpFilter.Controls.Add(Me.chkDeletedRowVisibled, 6, 0)
        Me.tlpFilter.Controls.Add(Me.Label2, 2, 0)
        Me.tlpFilter.Controls.Add(Me.ComboboxEx1, 3, 0)
        Me.tlpFilter.Controls.Add(Me.Label3, 0, 1)
        Me.tlpFilter.Controls.Add(Me.Label4, 2, 1)
        Me.tlpFilter.Controls.Add(Me.MaskedTextBoxEx1, 1, 1)
        Me.tlpFilter.Controls.Add(Me.mtxKISYU_NAME, 3, 1)
        Me.tlpFilter.Controls.Add(Me.Label5, 4, 1)
        Me.tlpFilter.Controls.Add(Me.MaskedTextBoxEx2, 5, 1)
        Me.tlpFilter.Dock = System.Windows.Forms.DockStyle.Fill
        Me.tlpFilter.Location = New System.Drawing.Point(3, 20)
        Me.tlpFilter.Name = "tlpFilter"
        Me.tlpFilter.RowCount = 3
        Me.tlpFilter.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30.0!))
        Me.tlpFilter.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30.0!))
        Me.tlpFilter.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.tlpFilter.Size = New System.Drawing.Size(1230, 64)
        Me.tlpFilter.TabIndex = 56
        '
        'btnClearSrchFilter
        '
        Me.btnClearSrchFilter.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnClearSrchFilter.Location = New System.Drawing.Point(1114, 3)
        Me.btnClearSrchFilter.Name = "btnClearSrchFilter"
        Me.tlpFilter.SetRowSpan(Me.btnClearSrchFilter, 2)
        Me.btnClearSrchFilter.Size = New System.Drawing.Size(113, 54)
        Me.btnClearSrchFilter.TabIndex = 101
        Me.btnClearSrchFilter.Text = "条件クリア"
        Me.btnClearSrchFilter.UseVisualStyleBackColor = True
        '
        'Label1
        '
        Me.Label1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Label1.Font = New System.Drawing.Font("Meiryo UI", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label1.Location = New System.Drawing.Point(3, 0)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(70, 30)
        Me.Label1.TabIndex = 55
        Me.Label1.Text = "部門区分:"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'cmbBUMON_KB
        '
        Me.cmbBUMON_KB.BackColor = System.Drawing.SystemColors.Window
        Me.cmbBUMON_KB.Cursor = System.Windows.Forms.Cursors.Default
        Me.cmbBUMON_KB.DisplayMember = "DISP"
        Me.cmbBUMON_KB.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbBUMON_KB.Font = New System.Drawing.Font("Meiryo UI", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.cmbBUMON_KB.ForeColor = System.Drawing.SystemColors.ControlText
        Me.cmbBUMON_KB.FormattingEnabled = True
        Me.cmbBUMON_KB.GotFocusedColor = System.Drawing.Color.FromArgb(CType(CType(190, Byte), Integer), CType(CType(180, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.cmbBUMON_KB.ImeMode = System.Windows.Forms.ImeMode.Disable
        Me.cmbBUMON_KB.Location = New System.Drawing.Point(79, 3)
        Me.cmbBUMON_KB.Name = "cmbBUMON_KB"
        Me.cmbBUMON_KB.NullValue = " "
        Me.cmbBUMON_KB.ReadOnly = False
        Me.cmbBUMON_KB.Selected = False
        Me.cmbBUMON_KB.Size = New System.Drawing.Size(158, 25)
        Me.cmbBUMON_KB.TabIndex = 59
        Me.cmbBUMON_KB.ValueMember = "VALUE"
        '
        'chkDeletedRowVisibled
        '
        Me.chkDeletedRowVisibled.AutoSize = True
        Me.chkDeletedRowVisibled.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.chkDeletedRowVisibled.Cursor = System.Windows.Forms.Cursors.Hand
        Me.chkDeletedRowVisibled.Dock = System.Windows.Forms.DockStyle.Fill
        Me.chkDeletedRowVisibled.Font = New System.Drawing.Font("Meiryo UI", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.chkDeletedRowVisibled.Location = New System.Drawing.Point(990, 3)
        Me.chkDeletedRowVisibled.Name = "chkDeletedRowVisibled"
        Me.chkDeletedRowVisibled.Size = New System.Drawing.Size(118, 24)
        Me.chkDeletedRowVisibled.TabIndex = 1
        Me.chkDeletedRowVisibled.Text = "削除済も表示"
        Me.chkDeletedRowVisibled.UseVisualStyleBackColor = True
        '
        'Label2
        '
        Me.Label2.Font = New System.Drawing.Font("Meiryo UI", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label2.Location = New System.Drawing.Point(243, 0)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(70, 30)
        Me.Label2.TabIndex = 102
        Me.Label2.Text = "得意先:"
        Me.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'ComboboxEx1
        '
        Me.ComboboxEx1.BackColor = System.Drawing.SystemColors.Window
        Me.ComboboxEx1.Cursor = System.Windows.Forms.Cursors.Default
        Me.ComboboxEx1.DisplayMember = "DISP"
        Me.ComboboxEx1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.ComboboxEx1.Font = New System.Drawing.Font("Meiryo UI", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.ComboboxEx1.ForeColor = System.Drawing.SystemColors.ControlText
        Me.ComboboxEx1.FormattingEnabled = True
        Me.ComboboxEx1.GotFocusedColor = System.Drawing.Color.FromArgb(CType(CType(190, Byte), Integer), CType(CType(180, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.ComboboxEx1.ImeMode = System.Windows.Forms.ImeMode.Disable
        Me.ComboboxEx1.Location = New System.Drawing.Point(322, 3)
        Me.ComboboxEx1.Name = "ComboboxEx1"
        Me.ComboboxEx1.NullValue = " "
        Me.ComboboxEx1.ReadOnly = False
        Me.ComboboxEx1.Selected = False
        Me.ComboboxEx1.Size = New System.Drawing.Size(166, 25)
        Me.ComboboxEx1.TabIndex = 103
        Me.ComboboxEx1.ValueMember = "VALUE"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Meiryo UI", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label4.Location = New System.Drawing.Point(243, 30)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(52, 17)
        Me.Label4.TabIndex = 104
        Me.Label4.Text = "部品名:"
        Me.Label4.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'MaskedTextBoxEx1
        '
        Me.MaskedTextBoxEx1.BackColor = System.Drawing.SystemColors.Window
        Me.MaskedTextBoxEx1.GotFocusedColor = System.Drawing.Color.FromArgb(CType(CType(190, Byte), Integer), CType(CType(180, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.MaskedTextBoxEx1.ImeMode = System.Windows.Forms.ImeMode.[On]
        Me.MaskedTextBoxEx1.InputRequired = False
        Me.MaskedTextBoxEx1.Location = New System.Drawing.Point(79, 33)
        Me.MaskedTextBoxEx1.MaxByteLength = 30
        Me.MaskedTextBoxEx1.Name = "MaskedTextBoxEx1"
        Me.MaskedTextBoxEx1.Size = New System.Drawing.Size(158, 24)
        Me.MaskedTextBoxEx1.TabIndex = 105
        Me.MaskedTextBoxEx1.WatermarkColor = System.Drawing.Color.Empty
        Me.MaskedTextBoxEx1.WatermarkText = Nothing
        '
        'mtxKISYU_NAME
        '
        Me.mtxKISYU_NAME.BackColor = System.Drawing.SystemColors.Window
        Me.mtxKISYU_NAME.GotFocusedColor = System.Drawing.Color.FromArgb(CType(CType(190, Byte), Integer), CType(CType(180, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.mtxKISYU_NAME.ImeMode = System.Windows.Forms.ImeMode.[On]
        Me.mtxKISYU_NAME.InputRequired = False
        Me.mtxKISYU_NAME.Location = New System.Drawing.Point(322, 33)
        Me.mtxKISYU_NAME.MaxByteLength = 30
        Me.mtxKISYU_NAME.Name = "mtxKISYU_NAME"
        Me.mtxKISYU_NAME.Size = New System.Drawing.Size(165, 24)
        Me.mtxKISYU_NAME.TabIndex = 58
        Me.mtxKISYU_NAME.WatermarkColor = System.Drawing.Color.Empty
        Me.mtxKISYU_NAME.WatermarkText = Nothing
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Meiryo UI", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label5.Location = New System.Drawing.Point(494, 30)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(70, 17)
        Me.Label5.TabIndex = 106
        Me.Label5.Text = "社内コード:"
        Me.Label5.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'MaskedTextBoxEx2
        '
        Me.MaskedTextBoxEx2.BackColor = System.Drawing.SystemColors.Window
        Me.MaskedTextBoxEx2.GotFocusedColor = System.Drawing.Color.FromArgb(CType(CType(190, Byte), Integer), CType(CType(180, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.MaskedTextBoxEx2.ImeMode = System.Windows.Forms.ImeMode.[On]
        Me.MaskedTextBoxEx2.InputRequired = False
        Me.MaskedTextBoxEx2.Location = New System.Drawing.Point(576, 33)
        Me.MaskedTextBoxEx2.MaxByteLength = 30
        Me.MaskedTextBoxEx2.Name = "MaskedTextBoxEx2"
        Me.MaskedTextBoxEx2.Size = New System.Drawing.Size(165, 24)
        Me.MaskedTextBoxEx2.TabIndex = 107
        Me.MaskedTextBoxEx2.WatermarkColor = System.Drawing.Color.Empty
        Me.MaskedTextBoxEx2.WatermarkText = Nothing
        '
        'flxDATA
        '
        Me.flxDATA.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.flxDATA.ColumnInfo = resources.GetString("flxDATA.ColumnInfo")
        Me.flxDATA.DataSource = Me.VWM106BUHINBindingSource
        Me.flxDATA.Font = New System.Drawing.Font("Meiryo UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.flxDATA.Location = New System.Drawing.Point(14, 153)
        Me.flxDATA.Name = "flxDATA"
        Me.flxDATA.Rows.Count = 1
        Me.flxDATA.Rows.DefaultSize = 23
        Me.flxDATA.Size = New System.Drawing.Size(1236, 407)
        Me.flxDATA.StyleInfo = resources.GetString("flxDATA.StyleInfo")
        Me.flxDATA.TabIndex = 61
        Me.flxDATA.VisualStyle = C1.Win.C1FlexGrid.VisualStyle.Office2010Silver
        '
        'VWM106BUHINBindingSource
        '
        Me.VWM106BUHINBindingSource.DataSource = GetType(MODEL.VWM106_BUHIN)
        '
        'FrmM1060
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.ClientSize = New System.Drawing.Size(1264, 712)
        Me.Controls.Add(Me.flxDATA)
        Me.Controls.Add(Me.gbxFilter)
        Me.HelpButton = True
        Me.Name = "FrmM1060"
        Me.ShowStatusBar = True
        Me.Text = ""
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
        Me.Controls.SetChildIndex(Me.gbxFilter, 0)
        Me.Controls.SetChildIndex(Me.flxDATA, 0)
        CType(Me.ErrorProvider, System.ComponentModel.ISupportInitialize).EndInit()
        Me.gbxFilter.ResumeLayout(False)
        Me.tlpFilter.ResumeLayout(False)
        Me.tlpFilter.PerformLayout()
        CType(Me.flxDATA, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.VWM106BUHINBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents SaveFileDialog As System.Windows.Forms.SaveFileDialog
    Friend WithEvents OpenFileDialog As System.Windows.Forms.OpenFileDialog
    Friend WithEvents Label3 As Label
    Friend WithEvents gbxFilter As GroupBox
    Friend WithEvents tlpFilter As TableLayoutPanel
    Friend WithEvents chkDeletedRowVisibled As CheckBox
    Friend WithEvents Label1 As Label
    Friend WithEvents mtxKISYU_NAME As MaskedTextBoxEx
    Friend WithEvents cmbBUMON_KB As ComboboxEx
    Friend WithEvents btnClearSrchFilter As Button
    Friend WithEvents flxDATA As C1.Win.C1FlexGrid.C1FlexGrid
    Friend WithEvents Label2 As Label
    Friend WithEvents ComboboxEx1 As ComboboxEx
    Friend WithEvents Label4 As Label
    Friend WithEvents MaskedTextBoxEx1 As MaskedTextBoxEx
    Friend WithEvents Label5 As Label
    Friend WithEvents MaskedTextBoxEx2 As MaskedTextBoxEx
    Friend WithEvents VWM106BUHINBindingSource As BindingSource
End Class
