<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class DateFilterEditor
    Inherits System.Windows.Forms.UserControl

    'UserControl は dispose をオーバーライドしてコンポーネント一覧を消去します。
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    ' Windows フォーム デザイナで必要です。
    Private components As System.ComponentModel.IContainer

    'メモ: 以下のプロシージャは Windows フォーム デザイナで必要です。
    'Windows フォーム デザイナを使用して変更できます。  
    'コード エディタを使って変更しないでください。
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me._chkCalendar = New System.Windows.Forms.CheckBox()
        Me._calendar = New System.Windows.Forms.MonthCalendar()
        Me._chkYesterday = New System.Windows.Forms.CheckBox()
        Me._chkLastWeek = New System.Windows.Forms.CheckBox()
        Me._chkCurrentWeek = New System.Windows.Forms.CheckBox()
        Me._chkCurrentMonth = New System.Windows.Forms.CheckBox()
        Me._chkLastMonth = New System.Windows.Forms.CheckBox()
        Me._chkCurrentYear = New System.Windows.Forms.CheckBox()
        Me._chkLastYear = New System.Windows.Forms.CheckBox()
        Me.SuspendLayout()
        '
        '_chkCalendar
        '
        Me._chkCalendar.AutoSize = True
        Me._chkCalendar.Location = New System.Drawing.Point(2, 0)
        Me._chkCalendar.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me._chkCalendar.Name = "_chkCalendar"
        Me._chkCalendar.Size = New System.Drawing.Size(177, 16)
        Me._chkCalendar.TabIndex = 0
        Me._chkCalendar.Text = "指定された日付でフィルタの設定"
        Me._chkCalendar.UseVisualStyleBackColor = True
        '
        '_calendar
        '
        Me._calendar.FirstDayOfWeek = System.Windows.Forms.Day.Monday
        Me._calendar.Location = New System.Drawing.Point(8, 15)
        Me._calendar.Margin = New System.Windows.Forms.Padding(7, 3, 7, 3)
        Me._calendar.MaxSelectionCount = 30
        Me._calendar.Name = "_calendar"
        Me._calendar.TabIndex = 1
        Me._calendar.TitleBackColor = System.Drawing.SystemColors.ControlDark
        '
        '_chkYesterday
        '
        Me._chkYesterday.AutoSize = True
        Me._chkYesterday.Font = New System.Drawing.Font("MS UI Gothic", 9.0!)
        Me._chkYesterday.Location = New System.Drawing.Point(2, 207)
        Me._chkYesterday.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me._chkYesterday.Name = "_chkYesterday"
        Me._chkYesterday.Size = New System.Drawing.Size(48, 16)
        Me._chkYesterday.TabIndex = 0
        Me._chkYesterday.Text = "昨日"
        Me._chkYesterday.UseVisualStyleBackColor = True
        '
        '_chkLastWeek
        '
        Me._chkLastWeek.AutoSize = True
        Me._chkLastWeek.Location = New System.Drawing.Point(121, 207)
        Me._chkLastWeek.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me._chkLastWeek.Name = "_chkLastWeek"
        Me._chkLastWeek.Size = New System.Drawing.Size(48, 16)
        Me._chkLastWeek.TabIndex = 0
        Me._chkLastWeek.Text = "先週"
        Me._chkLastWeek.UseVisualStyleBackColor = True
        '
        '_chkCurrentWeek
        '
        Me._chkCurrentWeek.AutoSize = True
        Me._chkCurrentWeek.Font = New System.Drawing.Font("MS UI Gothic", 9.0!)
        Me._chkCurrentWeek.Location = New System.Drawing.Point(54, 207)
        Me._chkCurrentWeek.Margin = New System.Windows.Forms.Padding(2, 0, 17, 0)
        Me._chkCurrentWeek.Name = "_chkCurrentWeek"
        Me._chkCurrentWeek.Size = New System.Drawing.Size(48, 16)
        Me._chkCurrentWeek.TabIndex = 2
        Me._chkCurrentWeek.Text = "今週"
        Me._chkCurrentWeek.UseVisualStyleBackColor = True
        '
        '_chkCurrentMonth
        '
        Me._chkCurrentMonth.AutoSize = True
        Me._chkCurrentMonth.Font = New System.Drawing.Font("MS UI Gothic", 9.0!)
        Me._chkCurrentMonth.Location = New System.Drawing.Point(2, 223)
        Me._chkCurrentMonth.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me._chkCurrentMonth.Name = "_chkCurrentMonth"
        Me._chkCurrentMonth.Size = New System.Drawing.Size(48, 16)
        Me._chkCurrentMonth.TabIndex = 3
        Me._chkCurrentMonth.Text = "今月"
        Me._chkCurrentMonth.UseVisualStyleBackColor = True
        '
        '_chkLastMonth
        '
        Me._chkLastMonth.AutoSize = True
        Me._chkLastMonth.Font = New System.Drawing.Font("MS UI Gothic", 9.0!)
        Me._chkLastMonth.Location = New System.Drawing.Point(54, 223)
        Me._chkLastMonth.Margin = New System.Windows.Forms.Padding(2, 0, 17, 0)
        Me._chkLastMonth.Name = "_chkLastMonth"
        Me._chkLastMonth.Size = New System.Drawing.Size(48, 16)
        Me._chkLastMonth.TabIndex = 4
        Me._chkLastMonth.Text = "先月"
        Me._chkLastMonth.UseVisualStyleBackColor = True
        '
        '_chkCurrentYear
        '
        Me._chkCurrentYear.AutoSize = True
        Me._chkCurrentYear.Font = New System.Drawing.Font("MS UI Gothic", 9.0!)
        Me._chkCurrentYear.Location = New System.Drawing.Point(121, 223)
        Me._chkCurrentYear.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me._chkCurrentYear.Name = "_chkCurrentYear"
        Me._chkCurrentYear.Size = New System.Drawing.Size(48, 16)
        Me._chkCurrentYear.TabIndex = 5
        Me._chkCurrentYear.Text = "今年"
        Me._chkCurrentYear.UseVisualStyleBackColor = True
        '
        '_chkLastYear
        '
        Me._chkLastYear.AutoSize = True
        Me._chkLastYear.Font = New System.Drawing.Font("MS UI Gothic", 9.0!)
        Me._chkLastYear.Location = New System.Drawing.Point(173, 223)
        Me._chkLastYear.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me._chkLastYear.Name = "_chkLastYear"
        Me._chkLastYear.Size = New System.Drawing.Size(48, 16)
        Me._chkLastYear.TabIndex = 6
        Me._chkLastYear.Text = "去年"
        Me._chkLastYear.UseVisualStyleBackColor = True
        '
        'DateFilterEditor
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.AutoSize = True
        Me.BackColor = System.Drawing.Color.White
        Me.Controls.Add(Me._chkLastYear)
        Me.Controls.Add(Me._chkCurrentYear)
        Me.Controls.Add(Me._chkLastMonth)
        Me.Controls.Add(Me._chkCurrentMonth)
        Me.Controls.Add(Me._chkLastWeek)
        Me.Controls.Add(Me._chkCurrentWeek)
        Me.Controls.Add(Me._chkYesterday)
        Me.Controls.Add(Me._chkCalendar)
        Me.Controls.Add(Me._calendar)
        Me.Name = "DateFilterEditor"
        Me.Size = New System.Drawing.Size(235, 249)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Private WithEvents _chkCalendar As System.Windows.Forms.CheckBox
    Private WithEvents _calendar As System.Windows.Forms.MonthCalendar
    Private WithEvents _chkYesterday As System.Windows.Forms.CheckBox
    Private WithEvents _chkLastWeek As System.Windows.Forms.CheckBox
    Private WithEvents _chkCurrentWeek As CheckBox
    Private WithEvents _chkCurrentMonth As CheckBox
    Private WithEvents _chkLastMonth As CheckBox
    Private WithEvents _chkCurrentYear As CheckBox
    Private WithEvents _chkLastYear As CheckBox
End Class
