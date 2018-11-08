<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class FrmM0030
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmM0030))
        Me.SaveFileDialog = New System.Windows.Forms.SaveFileDialog()
        Me.OpenFileDialog = New System.Windows.Forms.OpenFileDialog()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.cmbBUMON_KB = New JMS_COMMON.ComboboxEx()
        Me.gbxFilter = New System.Windows.Forms.GroupBox()
        Me.tlpFilter = New System.Windows.Forms.TableLayoutPanel()
        Me.chkDeletedRowVisibled = New System.Windows.Forms.CheckBox()
        Me.btnClearSrchFilter = New System.Windows.Forms.Button()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.cmbBUSYO_KB = New JMS_COMMON.ComboboxEx()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.datYUKO_YMD = New JMS_COMMON.DateTextBoxEx()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.txtBUSYO_NAME = New JMS_COMMON.MaskedTextBoxEx()
        Me.txtOYA_BUSYO_NAME = New JMS_COMMON.MaskedTextBoxEx()
        Me.flxDATA = New C1.Win.C1FlexGrid.C1FlexGrid()
        CType(Me.ErrorProvider, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.gbxFilter.SuspendLayout()
        Me.tlpFilter.SuspendLayout()
        CType(Me.flxDATA, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'lblRecordCount
        '
        Me.lblRecordCount.ForeColor = System.Drawing.SystemColors.ControlText
        Me.lblRecordCount.Location = New System.Drawing.Point(12, 565)
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
        Me.cmdFunc2.Text = "追加(F2)"
        '
        'cmdFunc3
        '
        Me.cmdFunc3.Image = Global.FMS.My.Resources.Resources._imgApplication_form_add32x32
        Me.cmdFunc3.Location = New System.Drawing.Point(423, 595)
        Me.cmdFunc3.Text = "類似追加(F3)"
        '
        'cmdFunc4
        '
        Me.cmdFunc4.Image = Global.FMS.My.Resources.Resources._imgApplication_form_edit32x32
        Me.cmdFunc4.Location = New System.Drawing.Point(630, 595)
        Me.cmdFunc4.Text = "変更(F4)"
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
        Me.cmdFunc10.Image = Global.FMS.My.Resources.Resources._imgExportToExcel32x32
        Me.cmdFunc10.Location = New System.Drawing.Point(630, 643)
        Me.cmdFunc10.Text = "CSV出力(F10)"
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
        Me.lblTytle.Text = "業務グループマスタ"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Meiryo UI", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label3.Location = New System.Drawing.Point(3, 0)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(60, 17)
        Me.Label3.TabIndex = 54
        Me.Label3.Text = "製品区分"
        Me.Label3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'cmbBUMON_KB
        '
        Me.cmbBUMON_KB.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cmbBUMON_KB.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cmbBUMON_KB.BackColor = System.Drawing.SystemColors.Window
        Me.cmbBUMON_KB.Cursor = System.Windows.Forms.Cursors.Default
        Me.cmbBUMON_KB.DisplayMember = "DISP"
        Me.cmbBUMON_KB.Font = New System.Drawing.Font("Meiryo UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.cmbBUMON_KB.ForeColor = System.Drawing.SystemColors.ControlText
        Me.cmbBUMON_KB.FormattingEnabled = True
        Me.cmbBUMON_KB.HorizontalContentAlignment = System.Drawing.StringAlignment.Near
        Me.cmbBUMON_KB.ImeMode = System.Windows.Forms.ImeMode.Disable
        Me.cmbBUMON_KB.IsSelected = False
        Me.cmbBUMON_KB.Location = New System.Drawing.Point(83, 3)
        Me.cmbBUMON_KB.Name = "cmbBUMON_KB"
        Me.cmbBUMON_KB.NullValue = " "
        Me.cmbBUMON_KB.Size = New System.Drawing.Size(113, 25)
        Me.cmbBUMON_KB.TabIndex = 0
        Me.cmbBUMON_KB.Text = "(選択)"
        Me.cmbBUMON_KB.ValueMember = "VALUE"
        '
        'gbxFilter
        '
        Me.gbxFilter.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.gbxFilter.Controls.Add(Me.tlpFilter)
        Me.gbxFilter.Font = New System.Drawing.Font("Meiryo UI", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.gbxFilter.Location = New System.Drawing.Point(14, 60)
        Me.gbxFilter.Name = "gbxFilter"
        Me.gbxFilter.Size = New System.Drawing.Size(1236, 89)
        Me.gbxFilter.TabIndex = 59
        Me.gbxFilter.TabStop = False
        Me.gbxFilter.Text = "検索条件"
        '
        'tlpFilter
        '
        Me.tlpFilter.ColumnCount = 7
        Me.tlpFilter.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 80.0!))
        Me.tlpFilter.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 231.0!))
        Me.tlpFilter.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 80.0!))
        Me.tlpFilter.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 275.0!))
        Me.tlpFilter.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 75.0!))
        Me.tlpFilter.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.tlpFilter.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 110.0!))
        Me.tlpFilter.Controls.Add(Me.Label3, 0, 0)
        Me.tlpFilter.Controls.Add(Me.chkDeletedRowVisibled, 6, 0)
        Me.tlpFilter.Controls.Add(Me.cmbBUMON_KB, 1, 0)
        Me.tlpFilter.Controls.Add(Me.btnClearSrchFilter, 6, 1)
        Me.tlpFilter.Controls.Add(Me.Label1, 2, 0)
        Me.tlpFilter.Controls.Add(Me.cmbBUSYO_KB, 3, 0)
        Me.tlpFilter.Controls.Add(Me.Label2, 4, 0)
        Me.tlpFilter.Controls.Add(Me.datYUKO_YMD, 5, 0)
        Me.tlpFilter.Controls.Add(Me.Label4, 0, 1)
        Me.tlpFilter.Controls.Add(Me.Label5, 2, 1)
        Me.tlpFilter.Controls.Add(Me.txtBUSYO_NAME, 3, 1)
        Me.tlpFilter.Controls.Add(Me.txtOYA_BUSYO_NAME, 1, 1)
        Me.tlpFilter.Dock = System.Windows.Forms.DockStyle.Fill
        Me.tlpFilter.Location = New System.Drawing.Point(3, 20)
        Me.tlpFilter.Name = "tlpFilter"
        Me.tlpFilter.RowCount = 3
        Me.tlpFilter.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 31.0!))
        Me.tlpFilter.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 29.0!))
        Me.tlpFilter.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.tlpFilter.Size = New System.Drawing.Size(1230, 66)
        Me.tlpFilter.TabIndex = 56
        '
        'chkDeletedRowVisibled
        '
        Me.chkDeletedRowVisibled.AutoSize = True
        Me.chkDeletedRowVisibled.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.chkDeletedRowVisibled.Cursor = System.Windows.Forms.Cursors.Hand
        Me.chkDeletedRowVisibled.Dock = System.Windows.Forms.DockStyle.Fill
        Me.chkDeletedRowVisibled.Font = New System.Drawing.Font("Meiryo UI", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.chkDeletedRowVisibled.Location = New System.Drawing.Point(1123, 3)
        Me.chkDeletedRowVisibled.Name = "chkDeletedRowVisibled"
        Me.chkDeletedRowVisibled.Size = New System.Drawing.Size(104, 25)
        Me.chkDeletedRowVisibled.TabIndex = 1
        Me.chkDeletedRowVisibled.Text = "削除済も表示"
        Me.chkDeletedRowVisibled.UseVisualStyleBackColor = True
        '
        'btnClearSrchFilter
        '
        Me.btnClearSrchFilter.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnClearSrchFilter.Location = New System.Drawing.Point(1123, 34)
        Me.btnClearSrchFilter.Name = "btnClearSrchFilter"
        Me.btnClearSrchFilter.Size = New System.Drawing.Size(104, 23)
        Me.btnClearSrchFilter.TabIndex = 55
        Me.btnClearSrchFilter.Text = "条件クリア"
        Me.btnClearSrchFilter.UseVisualStyleBackColor = True
        Me.btnClearSrchFilter.Visible = False
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Meiryo UI", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label1.Location = New System.Drawing.Point(314, 0)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(60, 17)
        Me.Label1.TabIndex = 54
        Me.Label1.Text = "部署区分"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'cmbBUSYO_KB
        '
        Me.cmbBUSYO_KB.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cmbBUSYO_KB.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cmbBUSYO_KB.BackColor = System.Drawing.SystemColors.Window
        Me.cmbBUSYO_KB.Cursor = System.Windows.Forms.Cursors.Default
        Me.cmbBUSYO_KB.DisplayMember = "DISP"
        Me.cmbBUSYO_KB.Font = New System.Drawing.Font("Meiryo UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.cmbBUSYO_KB.ForeColor = System.Drawing.SystemColors.ControlText
        Me.cmbBUSYO_KB.FormattingEnabled = True
        Me.cmbBUSYO_KB.HorizontalContentAlignment = System.Drawing.StringAlignment.Near
        Me.cmbBUSYO_KB.ImeMode = System.Windows.Forms.ImeMode.Disable
        Me.cmbBUSYO_KB.IsSelected = False
        Me.cmbBUSYO_KB.Location = New System.Drawing.Point(394, 3)
        Me.cmbBUSYO_KB.Name = "cmbBUSYO_KB"
        Me.cmbBUSYO_KB.NullValue = " "
        Me.cmbBUSYO_KB.Size = New System.Drawing.Size(135, 25)
        Me.cmbBUSYO_KB.TabIndex = 0
        Me.cmbBUSYO_KB.Text = "(選択)"
        Me.cmbBUSYO_KB.ValueMember = "VALUE"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Meiryo UI", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label2.Location = New System.Drawing.Point(669, 0)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(60, 17)
        Me.Label2.TabIndex = 54
        Me.Label2.Text = "有効期限"
        Me.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'datYUKO_YMD
        '
        Me.datYUKO_YMD.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.datYUKO_YMD.GotFocusedColor = System.Drawing.Color.FromArgb(CType(CType(190, Byte), Integer), CType(CType(180, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.datYUKO_YMD.Location = New System.Drawing.Point(744, 3)
        Me.datYUKO_YMD.MaxDate = New Date(9998, 12, 31, 0, 0, 0, 0)
        Me.datYUKO_YMD.MinDate = New Date(1753, 1, 1, 0, 0, 0, 0)
        Me.datYUKO_YMD.MinimumSize = New System.Drawing.Size(98, 24)
        Me.datYUKO_YMD.Name = "datYUKO_YMD"
        Me.datYUKO_YMD.ReadOnly = False
        Me.datYUKO_YMD.Size = New System.Drawing.Size(121, 24)
        Me.datYUKO_YMD.TabIndex = 56
        Me.datYUKO_YMD.Value = ""
        Me.datYUKO_YMD.ValueNonFormat = ""
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Meiryo UI", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label4.Location = New System.Drawing.Point(3, 31)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(60, 17)
        Me.Label4.TabIndex = 54
        Me.Label4.Text = "親部署名"
        Me.Label4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Meiryo UI", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label5.Location = New System.Drawing.Point(314, 31)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(47, 17)
        Me.Label5.TabIndex = 54
        Me.Label5.Text = "部署名"
        Me.Label5.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txtBUSYO_NAME
        '
        Me.txtBUSYO_NAME.BackColor = System.Drawing.SystemColors.Window
        Me.txtBUSYO_NAME.GotFocusedColor = System.Drawing.Color.FromArgb(CType(CType(190, Byte), Integer), CType(CType(180, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.txtBUSYO_NAME.ImeMode = System.Windows.Forms.ImeMode.[On]
        Me.txtBUSYO_NAME.InputRequired = False
        Me.txtBUSYO_NAME.Location = New System.Drawing.Point(394, 34)
        Me.txtBUSYO_NAME.MaxByteLength = 30
        Me.txtBUSYO_NAME.Name = "txtBUSYO_NAME"
        Me.txtBUSYO_NAME.SelectAllText = False
        Me.txtBUSYO_NAME.Size = New System.Drawing.Size(192, 24)
        Me.txtBUSYO_NAME.TabIndex = 57
        Me.txtBUSYO_NAME.WatermarkColor = System.Drawing.Color.Empty
        Me.txtBUSYO_NAME.WatermarkText = Nothing
        '
        'txtOYA_BUSYO_NAME
        '
        Me.txtOYA_BUSYO_NAME.BackColor = System.Drawing.SystemColors.Window
        Me.txtOYA_BUSYO_NAME.GotFocusedColor = System.Drawing.Color.FromArgb(CType(CType(190, Byte), Integer), CType(CType(180, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.txtOYA_BUSYO_NAME.ImeMode = System.Windows.Forms.ImeMode.[On]
        Me.txtOYA_BUSYO_NAME.InputRequired = False
        Me.txtOYA_BUSYO_NAME.Location = New System.Drawing.Point(83, 34)
        Me.txtOYA_BUSYO_NAME.MaxByteLength = 30
        Me.txtOYA_BUSYO_NAME.Name = "txtOYA_BUSYO_NAME"
        Me.txtOYA_BUSYO_NAME.SelectAllText = False
        Me.txtOYA_BUSYO_NAME.Size = New System.Drawing.Size(170, 24)
        Me.txtOYA_BUSYO_NAME.TabIndex = 57
        Me.txtOYA_BUSYO_NAME.WatermarkColor = System.Drawing.Color.Empty
        Me.txtOYA_BUSYO_NAME.WatermarkText = Nothing
        '
        'flxDATA
        '
        Me.flxDATA.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.flxDATA.AutoGenerateColumns = False
        Me.flxDATA.BorderStyle = C1.Win.C1FlexGrid.Util.BaseControls.BorderStyleEnum.XpThemes
        Me.flxDATA.ColumnInfo = "24,1,0,0,0,115,Columns:1{Visible:False;}" & Global.Microsoft.VisualBasic.ChrW(9) & "5{Visible:False;}" & Global.Microsoft.VisualBasic.ChrW(9) & "8{Visible:False;}" & Global.Microsoft.VisualBasic.ChrW(9) & "9{Vi" &
    "sible:False;}" & Global.Microsoft.VisualBasic.ChrW(9) & "11{Visible:False;}" & Global.Microsoft.VisualBasic.ChrW(9) & "15{Visible:False;}" & Global.Microsoft.VisualBasic.ChrW(9) & "18{Visible:False;}" & Global.Microsoft.VisualBasic.ChrW(9) & "21{Visibl" &
    "e:False;}" & Global.Microsoft.VisualBasic.ChrW(9) & "23{Visible:False;}" & Global.Microsoft.VisualBasic.ChrW(9)
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
        'FrmM0030
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.ClientSize = New System.Drawing.Size(1264, 712)
        Me.Controls.Add(Me.flxDATA)
        Me.Controls.Add(Me.gbxFilter)
        Me.HelpButton = True
        Me.Name = "FrmM0030"
        Me.ShowStatusBar = True
        Me.Text = ""
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
        Me.Controls.SetChildIndex(Me.flxDATA, 0)
        CType(Me.ErrorProvider, System.ComponentModel.ISupportInitialize).EndInit()
        Me.gbxFilter.ResumeLayout(False)
        Me.tlpFilter.ResumeLayout(False)
        Me.tlpFilter.PerformLayout()
        CType(Me.flxDATA, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents SaveFileDialog As System.Windows.Forms.SaveFileDialog
    Friend WithEvents OpenFileDialog As System.Windows.Forms.OpenFileDialog
    Friend WithEvents Label3 As Label
    Friend WithEvents cmbBUMON_KB As ComboboxEx
    Friend WithEvents gbxFilter As GroupBox
    Friend WithEvents chkDeletedRowVisibled As CheckBox
    Friend WithEvents tlpFilter As TableLayoutPanel
    Friend WithEvents btnClearSrchFilter As Button
    Friend WithEvents Label1 As Label
    Friend WithEvents cmbBUSYO_KB As ComboboxEx
    Friend WithEvents Label2 As Label
    Friend WithEvents datYUKO_YMD As DateTextBoxEx
    Friend WithEvents Label4 As Label
    Friend WithEvents Label5 As Label
    Friend WithEvents txtBUSYO_NAME As MaskedTextBoxEx
    Friend WithEvents txtOYA_BUSYO_NAME As MaskedTextBoxEx
    Friend WithEvents flxDATA As C1.Win.C1FlexGrid.C1FlexGrid
End Class
