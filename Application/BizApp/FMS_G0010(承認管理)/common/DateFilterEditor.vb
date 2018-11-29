Public Class DateFilterEditor
    Implements C1.Win.C1FlexGrid.IC1ColumnFilterEditor

    Dim _filter As DateFilter

    Public Sub ApplyChanges() Implements C1.Win.C1FlexGrid.IC1ColumnFilterEditor.ApplyChanges

        _filter.Reset()
        If _chkCalendar.Checked Then
            _filter.Minimum = _calendar.SelectionRange.Start
            _filter.Maximum = _calendar.SelectionRange.[End]
        Else
            Dim yesterday = DateTime.Today.AddDays(-1)
            If _chkYesterday.Checked Then
                _filter.Maximum = yesterday
                _filter.Minimum = yesterday
            End If
            If _chkEarlierThisWeek.Checked Then
                _filter.Maximum = yesterday
                _filter.Minimum = yesterday
                While _filter.Minimum.DayOfWeek <> DayOfWeek.Monday
                    _filter.Minimum = _filter.Minimum.AddDays(-1)
                End While
            End If
            If _chkLastWeek.Checked Then
                _filter.Maximum = yesterday
                _filter.Minimum = yesterday.AddDays(-7)
                While _filter.Minimum.DayOfWeek <> DayOfWeek.Monday
                    _filter.Minimum = _filter.Minimum.AddDays(-1)
                End While
            End If
            If _chkLongAgo.Checked Then
                _filter.Maximum = yesterday
                _filter.Minimum = yesterday.AddYears(-5)
            End If
        End If

    End Sub

    Public Sub Initialize(ByVal grid As C1.Win.C1FlexGrid.C1FlexGridBase, ByVal columnIndex As Integer, ByVal filter As C1.Win.C1FlexGrid.IC1ColumnFilter) Implements C1.Win.C1FlexGrid.IC1ColumnFilterEditor.Initialize
        Me.BackColor = Color.Transparent
        _calendar.Location = New Point(8, 11)
        _filter = CType(filter, DateFilter)

    End Sub

    Public ReadOnly Property KeepFormOpen() As Boolean Implements C1.Win.C1FlexGrid.IC1ColumnFilterEditor.KeepFormOpen
        Get
            Return False
        End Get
    End Property

    Private Sub _calendar_DateSelected(ByVal sender As Object, ByVal e As System.Windows.Forms.DateRangeEventArgs) Handles _calendar.DateSelected

        _chkCalendar.Checked = True

    End Sub

    Private Sub _chkCalendar_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles _chkCalendar.CheckedChanged

        Dim cb = CType(sender, CheckBox)
        If (cb.Checked) Then
            cb.Font = New Font(Font, FontStyle.Bold)
        End If
    End Sub
End Class
