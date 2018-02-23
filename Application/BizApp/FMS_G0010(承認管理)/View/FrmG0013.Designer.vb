<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class FrmG0013
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmG0013))
        Me.Label3 = New System.Windows.Forms.Label()
        Me.cmbKOMO_NM = New JMS_COMMON.ComboboxEx()
        Me.gbxFilter = New System.Windows.Forms.GroupBox()
        Me.tlpFilter = New System.Windows.Forms.TableLayoutPanel()
        Me.chkDeletedRowVisibled = New System.Windows.Forms.CheckBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.ComboboxEx1 = New JMS_COMMON.ComboboxEx()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.DateTextBoxEx1 = New JMS_COMMON.DateTextBoxEx()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.DateTextBoxEx2 = New JMS_COMMON.DateTextBoxEx()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.DateTextBoxEx4 = New JMS_COMMON.DateTextBoxEx()
        Me.DateTextBoxEx3 = New JMS_COMMON.DateTextBoxEx()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.btnClearSrchFilter = New System.Windows.Forms.Button()
        Me.ComboboxEx2 = New JMS_COMMON.ComboboxEx()
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
        Me.lblRecordCount.Location = New System.Drawing.Point(9, 565)
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
        Me.lblTytle.Text = "不適合検索画面"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.tlpFilter.SetColumnSpan(Me.Label3, 7)
        Me.Label3.Font = New System.Drawing.Font("Meiryo UI", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label3.Location = New System.Drawing.Point(3, 0)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(145, 17)
        Me.Label3.TabIndex = 54
        Me.Label3.Text = "製品処置(NCR)ステージ"
        Me.Label3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'cmbKOMO_NM
        '
        Me.cmbKOMO_NM.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cmbKOMO_NM.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cmbKOMO_NM.BackColor = System.Drawing.SystemColors.Window
        Me.tlpFilter.SetColumnSpan(Me.cmbKOMO_NM, 8)
        Me.cmbKOMO_NM.Cursor = System.Windows.Forms.Cursors.Default
        Me.cmbKOMO_NM.Font = New System.Drawing.Font("Meiryo UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.cmbKOMO_NM.ForeColor = System.Drawing.SystemColors.ControlText
        Me.cmbKOMO_NM.FormattingEnabled = True
        Me.cmbKOMO_NM.GotFocusedColor = System.Drawing.Color.FromArgb(CType(CType(190, Byte), Integer), CType(CType(180, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.cmbKOMO_NM.ImeMode = System.Windows.Forms.ImeMode.[On]
        Me.cmbKOMO_NM.Location = New System.Drawing.Point(178, 3)
        Me.cmbKOMO_NM.Name = "cmbKOMO_NM"
        Me.cmbKOMO_NM.Selected = False
        Me.cmbKOMO_NM.Size = New System.Drawing.Size(194, 25)
        Me.cmbKOMO_NM.TabIndex = 0
        Me.cmbKOMO_NM.Text = "(選択)"
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
        Me.gbxFilter.Text = "検索条件"
        '
        'tlpFilter
        '
        Me.tlpFilter.ColumnCount = 44
        Me.tlpFilter.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 25.0!))
        Me.tlpFilter.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 25.0!))
        Me.tlpFilter.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 25.0!))
        Me.tlpFilter.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 25.0!))
        Me.tlpFilter.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 25.0!))
        Me.tlpFilter.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 25.0!))
        Me.tlpFilter.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 25.0!))
        Me.tlpFilter.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 25.0!))
        Me.tlpFilter.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 25.0!))
        Me.tlpFilter.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 25.0!))
        Me.tlpFilter.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 25.0!))
        Me.tlpFilter.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 25.0!))
        Me.tlpFilter.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 25.0!))
        Me.tlpFilter.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 25.0!))
        Me.tlpFilter.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 25.0!))
        Me.tlpFilter.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 25.0!))
        Me.tlpFilter.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 25.0!))
        Me.tlpFilter.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 25.0!))
        Me.tlpFilter.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 25.0!))
        Me.tlpFilter.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 25.0!))
        Me.tlpFilter.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 25.0!))
        Me.tlpFilter.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 25.0!))
        Me.tlpFilter.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 25.0!))
        Me.tlpFilter.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 25.0!))
        Me.tlpFilter.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 25.0!))
        Me.tlpFilter.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 25.0!))
        Me.tlpFilter.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 25.0!))
        Me.tlpFilter.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 25.0!))
        Me.tlpFilter.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 25.0!))
        Me.tlpFilter.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 25.0!))
        Me.tlpFilter.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 25.0!))
        Me.tlpFilter.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 25.0!))
        Me.tlpFilter.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 25.0!))
        Me.tlpFilter.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 25.0!))
        Me.tlpFilter.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 25.0!))
        Me.tlpFilter.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 25.0!))
        Me.tlpFilter.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 25.0!))
        Me.tlpFilter.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 25.0!))
        Me.tlpFilter.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 25.0!))
        Me.tlpFilter.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 25.0!))
        Me.tlpFilter.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 25.0!))
        Me.tlpFilter.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 25.0!))
        Me.tlpFilter.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 25.0!))
        Me.tlpFilter.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.tlpFilter.Controls.Add(Me.chkDeletedRowVisibled, 43, 0)
        Me.tlpFilter.Controls.Add(Me.Label3, 0, 0)
        Me.tlpFilter.Controls.Add(Me.cmbKOMO_NM, 7, 0)
        Me.tlpFilter.Controls.Add(Me.Label1, 16, 0)
        Me.tlpFilter.Controls.Add(Me.ComboboxEx1, 23, 0)
        Me.tlpFilter.Controls.Add(Me.Label2, 0, 1)
        Me.tlpFilter.Controls.Add(Me.DateTextBoxEx1, 7, 1)
        Me.tlpFilter.Controls.Add(Me.Label4, 12, 1)
        Me.tlpFilter.Controls.Add(Me.DateTextBoxEx2, 13, 1)
        Me.tlpFilter.Controls.Add(Me.Label5, 0, 2)
        Me.tlpFilter.Controls.Add(Me.DateTextBoxEx4, 7, 2)
        Me.tlpFilter.Controls.Add(Me.DateTextBoxEx3, 13, 2)
        Me.tlpFilter.Controls.Add(Me.Label7, 12, 2)
        Me.tlpFilter.Controls.Add(Me.Label6, 0, 3)
        Me.tlpFilter.Controls.Add(Me.btnClearSrchFilter, 43, 4)
        Me.tlpFilter.Controls.Add(Me.ComboboxEx2, 7, 3)
        Me.tlpFilter.Dock = System.Windows.Forms.DockStyle.Left
        Me.tlpFilter.Location = New System.Drawing.Point(3, 20)
        Me.tlpFilter.Name = "tlpFilter"
        Me.tlpFilter.RowCount = 6
        Me.tlpFilter.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30.0!))
        Me.tlpFilter.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30.0!))
        Me.tlpFilter.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30.0!))
        Me.tlpFilter.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30.0!))
        Me.tlpFilter.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30.0!))
        Me.tlpFilter.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.tlpFilter.Size = New System.Drawing.Size(1213, 158)
        Me.tlpFilter.TabIndex = 56
        '
        'chkDeletedRowVisibled
        '
        Me.chkDeletedRowVisibled.AutoSize = True
        Me.chkDeletedRowVisibled.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.chkDeletedRowVisibled.Cursor = System.Windows.Forms.Cursors.Hand
        Me.chkDeletedRowVisibled.Font = New System.Drawing.Font("Meiryo UI", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.chkDeletedRowVisibled.Location = New System.Drawing.Point(1078, 3)
        Me.chkDeletedRowVisibled.Name = "chkDeletedRowVisibled"
        Me.chkDeletedRowVisibled.Size = New System.Drawing.Size(121, 21)
        Me.chkDeletedRowVisibled.TabIndex = 1
        Me.chkDeletedRowVisibled.Text = "クローズ済も表示"
        Me.chkDeletedRowVisibled.UseVisualStyleBackColor = True
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.tlpFilter.SetColumnSpan(Me.Label1, 7)
        Me.Label1.Font = New System.Drawing.Font("Meiryo UI", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label1.Location = New System.Drawing.Point(403, 0)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(145, 17)
        Me.Label1.TabIndex = 56
        Me.Label1.Text = "製品処置(NCR)ステージ"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'ComboboxEx1
        '
        Me.ComboboxEx1.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.ComboboxEx1.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.ComboboxEx1.BackColor = System.Drawing.SystemColors.Window
        Me.tlpFilter.SetColumnSpan(Me.ComboboxEx1, 8)
        Me.ComboboxEx1.Cursor = System.Windows.Forms.Cursors.Default
        Me.ComboboxEx1.Font = New System.Drawing.Font("Meiryo UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.ComboboxEx1.ForeColor = System.Drawing.SystemColors.ControlText
        Me.ComboboxEx1.FormattingEnabled = True
        Me.ComboboxEx1.GotFocusedColor = System.Drawing.Color.FromArgb(CType(CType(190, Byte), Integer), CType(CType(180, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.ComboboxEx1.ImeMode = System.Windows.Forms.ImeMode.[On]
        Me.ComboboxEx1.Location = New System.Drawing.Point(578, 3)
        Me.ComboboxEx1.Name = "ComboboxEx1"
        Me.ComboboxEx1.Selected = False
        Me.ComboboxEx1.Size = New System.Drawing.Size(194, 25)
        Me.ComboboxEx1.TabIndex = 57
        Me.ComboboxEx1.Text = "(選択)"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.tlpFilter.SetColumnSpan(Me.Label2, 7)
        Me.Label2.Font = New System.Drawing.Font("Meiryo UI", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label2.Location = New System.Drawing.Point(3, 30)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(145, 17)
        Me.Label2.TabIndex = 59
        Me.Label2.Text = "製品処置(NCR)ステージ"
        Me.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'DateTextBoxEx1
        '
        Me.DateTextBoxEx1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.tlpFilter.SetColumnSpan(Me.DateTextBoxEx1, 5)
        Me.DateTextBoxEx1.GotFocusedColor = System.Drawing.Color.FromArgb(CType(CType(190, Byte), Integer), CType(CType(180, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.DateTextBoxEx1.Location = New System.Drawing.Point(178, 33)
        Me.DateTextBoxEx1.MaxDate = New Date(9998, 12, 31, 0, 0, 0, 0)
        Me.DateTextBoxEx1.MinDate = New Date(1753, 1, 1, 0, 0, 0, 0)
        Me.DateTextBoxEx1.MinimumSize = New System.Drawing.Size(98, 24)
        Me.DateTextBoxEx1.Name = "DateTextBoxEx1"
        Me.DateTextBoxEx1.Size = New System.Drawing.Size(115, 24)
        Me.DateTextBoxEx1.TabIndex = 58
        Me.DateTextBoxEx1.Value = ""
        Me.DateTextBoxEx1.ValueNonFormat = ""
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Meiryo UI", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label4.Location = New System.Drawing.Point(303, 30)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(19, 17)
        Me.Label4.TabIndex = 60
        Me.Label4.Text = "~"
        Me.Label4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'DateTextBoxEx2
        '
        Me.DateTextBoxEx2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.tlpFilter.SetColumnSpan(Me.DateTextBoxEx2, 5)
        Me.DateTextBoxEx2.GotFocusedColor = System.Drawing.Color.FromArgb(CType(CType(190, Byte), Integer), CType(CType(180, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.DateTextBoxEx2.Location = New System.Drawing.Point(328, 33)
        Me.DateTextBoxEx2.MaxDate = New Date(9998, 12, 31, 0, 0, 0, 0)
        Me.DateTextBoxEx2.MinDate = New Date(1753, 1, 1, 0, 0, 0, 0)
        Me.DateTextBoxEx2.MinimumSize = New System.Drawing.Size(98, 24)
        Me.DateTextBoxEx2.Name = "DateTextBoxEx2"
        Me.DateTextBoxEx2.Size = New System.Drawing.Size(115, 24)
        Me.DateTextBoxEx2.TabIndex = 61
        Me.DateTextBoxEx2.Value = ""
        Me.DateTextBoxEx2.ValueNonFormat = ""
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.tlpFilter.SetColumnSpan(Me.Label5, 7)
        Me.Label5.Font = New System.Drawing.Font("Meiryo UI", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label5.Location = New System.Drawing.Point(3, 60)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(73, 17)
        Me.Label5.TabIndex = 63
        Me.Label5.Text = "処理実施日"
        Me.Label5.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'DateTextBoxEx4
        '
        Me.DateTextBoxEx4.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.tlpFilter.SetColumnSpan(Me.DateTextBoxEx4, 5)
        Me.DateTextBoxEx4.GotFocusedColor = System.Drawing.Color.FromArgb(CType(CType(190, Byte), Integer), CType(CType(180, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.DateTextBoxEx4.Location = New System.Drawing.Point(178, 63)
        Me.DateTextBoxEx4.MaxDate = New Date(9998, 12, 31, 0, 0, 0, 0)
        Me.DateTextBoxEx4.MinDate = New Date(1753, 1, 1, 0, 0, 0, 0)
        Me.DateTextBoxEx4.MinimumSize = New System.Drawing.Size(98, 24)
        Me.DateTextBoxEx4.Name = "DateTextBoxEx4"
        Me.DateTextBoxEx4.Size = New System.Drawing.Size(115, 24)
        Me.DateTextBoxEx4.TabIndex = 65
        Me.DateTextBoxEx4.Value = ""
        Me.DateTextBoxEx4.ValueNonFormat = ""
        '
        'DateTextBoxEx3
        '
        Me.DateTextBoxEx3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.tlpFilter.SetColumnSpan(Me.DateTextBoxEx3, 5)
        Me.DateTextBoxEx3.GotFocusedColor = System.Drawing.Color.FromArgb(CType(CType(190, Byte), Integer), CType(CType(180, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.DateTextBoxEx3.Location = New System.Drawing.Point(328, 63)
        Me.DateTextBoxEx3.MaxDate = New Date(9998, 12, 31, 0, 0, 0, 0)
        Me.DateTextBoxEx3.MinDate = New Date(1753, 1, 1, 0, 0, 0, 0)
        Me.DateTextBoxEx3.MinimumSize = New System.Drawing.Size(98, 24)
        Me.DateTextBoxEx3.Name = "DateTextBoxEx3"
        Me.DateTextBoxEx3.Size = New System.Drawing.Size(115, 24)
        Me.DateTextBoxEx3.TabIndex = 62
        Me.DateTextBoxEx3.Value = ""
        Me.DateTextBoxEx3.ValueNonFormat = ""
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Font = New System.Drawing.Font("Meiryo UI", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label7.Location = New System.Drawing.Point(303, 60)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(19, 17)
        Me.Label7.TabIndex = 66
        Me.Label7.Text = "~"
        Me.Label7.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.tlpFilter.SetColumnSpan(Me.Label6, 7)
        Me.Label6.Font = New System.Drawing.Font("Meiryo UI", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label6.Location = New System.Drawing.Point(3, 90)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(145, 17)
        Me.Label6.TabIndex = 67
        Me.Label6.Text = "製品処置(NCR)ステージ"
        Me.Label6.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'btnClearSrchFilter
        '
        Me.btnClearSrchFilter.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnClearSrchFilter.Location = New System.Drawing.Point(1078, 123)
        Me.btnClearSrchFilter.Name = "btnClearSrchFilter"
        Me.btnClearSrchFilter.Size = New System.Drawing.Size(104, 24)
        Me.btnClearSrchFilter.TabIndex = 55
        Me.btnClearSrchFilter.Text = "条件クリア"
        Me.btnClearSrchFilter.UseVisualStyleBackColor = True
        Me.btnClearSrchFilter.Visible = False
        '
        'ComboboxEx2
        '
        Me.ComboboxEx2.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.ComboboxEx2.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.ComboboxEx2.BackColor = System.Drawing.SystemColors.Window
        Me.tlpFilter.SetColumnSpan(Me.ComboboxEx2, 8)
        Me.ComboboxEx2.Cursor = System.Windows.Forms.Cursors.Default
        Me.ComboboxEx2.Font = New System.Drawing.Font("Meiryo UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.ComboboxEx2.ForeColor = System.Drawing.SystemColors.ControlText
        Me.ComboboxEx2.FormattingEnabled = True
        Me.ComboboxEx2.GotFocusedColor = System.Drawing.Color.FromArgb(CType(CType(190, Byte), Integer), CType(CType(180, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.ComboboxEx2.ImeMode = System.Windows.Forms.ImeMode.[On]
        Me.ComboboxEx2.Location = New System.Drawing.Point(178, 93)
        Me.ComboboxEx2.Name = "ComboboxEx2"
        Me.ComboboxEx2.Selected = False
        Me.ComboboxEx2.Size = New System.Drawing.Size(194, 25)
        Me.ComboboxEx2.TabIndex = 68
        Me.ComboboxEx2.Text = "(選択)"
        '
        'flxDATA
        '
        Me.flxDATA.AllowDragging = C1.Win.C1FlexGrid.AllowDraggingEnum.None
        Me.flxDATA.AllowEditing = False
        Me.flxDATA.AllowFiltering = True
        Me.flxDATA.ColumnInfo = "10,1,0,0,0,90,Columns:"
        Me.flxDATA.Location = New System.Drawing.Point(12, 288)
        Me.flxDATA.Name = "flxDATA"
        Me.flxDATA.Rows.DefaultSize = 18
        Me.flxDATA.Size = New System.Drawing.Size(1236, 271)
        Me.flxDATA.StyleInfo = resources.GetString("flxDATA.StyleInfo")
        Me.flxDATA.TabIndex = 61
        Me.flxDATA.VisualStyle = C1.Win.C1FlexGrid.VisualStyle.Office2010Silver
        '
        'FrmG0013
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.ClientSize = New System.Drawing.Size(1264, 712)
        Me.Controls.Add(Me.flxDATA)
        Me.Controls.Add(Me.gbxFilter)
        Me.HelpButton = True
        Me.Name = "FrmG0013"
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
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Label3 As Label
    Friend WithEvents cmbKOMO_NM As ComboboxEx
    Friend WithEvents gbxFilter As GroupBox
    Friend WithEvents chkDeletedRowVisibled As CheckBox
    Friend WithEvents tlpFilter As TableLayoutPanel
    Friend WithEvents btnClearSrchFilter As Button
    Friend WithEvents flxDATA As C1.Win.C1FlexGrid.C1FlexGrid
    Friend WithEvents Label1 As Label
    Friend WithEvents ComboboxEx1 As ComboboxEx
    Friend WithEvents Label2 As Label
    Friend WithEvents DateTextBoxEx1 As DateTextBoxEx
    Friend WithEvents Label4 As Label
    Friend WithEvents DateTextBoxEx2 As DateTextBoxEx
    Friend WithEvents Label5 As Label
    Friend WithEvents DateTextBoxEx4 As DateTextBoxEx
    Friend WithEvents DateTextBoxEx3 As DateTextBoxEx
    Friend WithEvents Label7 As Label
    Friend WithEvents Label6 As Label
    Friend WithEvents ComboboxEx2 As ComboboxEx
End Class
