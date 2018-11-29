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
        Me._chkEarlierThisWeek = New System.Windows.Forms.CheckBox()
        Me._chkLastWeek = New System.Windows.Forms.CheckBox()
        Me._chkLongAgo = New System.Windows.Forms.CheckBox()
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
        Me._calendar.Location = New System.Drawing.Point(101, 8)
        Me._calendar.Margin = New System.Windows.Forms.Padding(7, 3, 7, 3)
        Me._calendar.MaxSelectionCount = 30
        Me._calendar.Name = "_calendar"
        Me._calendar.ShowToday = False
        Me._calendar.TabIndex = 1
        Me._calendar.TitleBackColor = System.Drawing.SystemColors.ControlDark
        '
        '_chkYesterday
        '
        Me._chkYesterday.AutoSize = True
        Me._chkYesterday.Font = New System.Drawing.Font("MS UI Gothic", 9.0!)
        Me._chkYesterday.Location = New System.Drawing.Point(2, 161)
        Me._chkYesterday.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me._chkYesterday.Name = "_chkYesterday"
        Me._chkYesterday.Size = New System.Drawing.Size(48, 16)
        Me._chkYesterday.TabIndex = 0
        Me._chkYesterday.Text = "昨日"
        Me._chkYesterday.UseVisualStyleBackColor = True
        '
        '_chkEarlierThisWeek
        '
        Me._chkEarlierThisWeek.AutoSize = True
        Me._chkEarlierThisWeek.Location = New System.Drawing.Point(2, 193)
        Me._chkEarlierThisWeek.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me._chkEarlierThisWeek.Name = "_chkEarlierThisWeek"
        Me._chkEarlierThisWeek.Size = New System.Drawing.Size(70, 16)
        Me._chkEarlierThisWeek.TabIndex = 0
        Me._chkEarlierThisWeek.Text = "今週始め"
        Me._chkEarlierThisWeek.UseVisualStyleBackColor = True
        '
        '_chkLastWeek
        '
        Me._chkLastWeek.AutoSize = True
        Me._chkLastWeek.Location = New System.Drawing.Point(2, 177)
        Me._chkLastWeek.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me._chkLastWeek.Name = "_chkLastWeek"
        Me._chkLastWeek.Size = New System.Drawing.Size(48, 16)
        Me._chkLastWeek.TabIndex = 0
        Me._chkLastWeek.Text = "先週"
        Me._chkLastWeek.UseVisualStyleBackColor = True
        '
        '_chkLongAgo
        '
        Me._chkLongAgo.AutoSize = True
        Me._chkLongAgo.Location = New System.Drawing.Point(2, 208)
        Me._chkLongAgo.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me._chkLongAgo.Name = "_chkLongAgo"
        Me._chkLongAgo.Size = New System.Drawing.Size(106, 16)
        Me._chkLongAgo.TabIndex = 0
        Me._chkLongAgo.Text = "今日の日付以外"
        Me._chkLongAgo.UseVisualStyleBackColor = True
        '
        'DateFilterEditor
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.AutoSize = True
        Me.BackColor = System.Drawing.Color.White
        Me.Controls.Add(Me._chkCalendar)
        Me.Controls.Add(Me._calendar)
        Me.Controls.Add(Me._chkYesterday)
        Me.Controls.Add(Me._chkEarlierThisWeek)
        Me.Controls.Add(Me._chkLastWeek)
        Me.Controls.Add(Me._chkLongAgo)
        Me.Name = "DateFilterEditor"
        Me.Size = New System.Drawing.Size(328, 229)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Private WithEvents _chkCalendar As System.Windows.Forms.CheckBox
    Private WithEvents _calendar As System.Windows.Forms.MonthCalendar
    Private WithEvents _chkYesterday As System.Windows.Forms.CheckBox
    Private WithEvents _chkEarlierThisWeek As System.Windows.Forms.CheckBox
    Private WithEvents _chkLastWeek As System.Windows.Forms.CheckBox
    Private WithEvents _chkLongAgo As System.Windows.Forms.CheckBox

End Class
