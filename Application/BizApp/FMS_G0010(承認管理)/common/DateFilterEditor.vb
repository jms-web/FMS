Public Class DateFilterEditor
    Implements C1.Win.C1FlexGrid.IC1ColumnFilterEditor

    Dim _filter As DateFilter

    Public Sub ApplyChanges() Implements C1.Win.C1FlexGrid.IC1ColumnFilterEditor.ApplyChanges

        _filter.Reset()
        If _chkCalendar.Checked Then
            _filter.Minimum = _calendar.SelectionRange.Start
            _filter.Maximum = _calendar.SelectionRange.[End]
        Else
            '
            Dim today = DateTime.Today

            If _chkYesterday.Checked Then
                _filter.Maximum = today.AddDays(-1)
                _filter.Minimum = today.AddDays(-1)
            End If
            '
            If _chkCurrentWeek.Checked Then
                _filter.Maximum = today
                While _filter.Maximum.DayOfWeek <> DayOfWeek.Sunday
                    _filter.Maximum = _filter.Maximum.AddDays(1)
                End While
                _filter.Minimum = today
                While _filter.Minimum.DayOfWeek <> DayOfWeek.Monday
                    _filter.Minimum = _filter.Minimum.AddDays(-1)
                End While
            End If
            '
            If _chkLastWeek.Checked Then
                _filter.Maximum = today.AddDays(-7)
                While _filter.Maximum.DayOfWeek <> DayOfWeek.Sunday
                    _filter.Maximum = _filter.Maximum.AddDays(1)
                End While
                _filter.Minimum = today.AddDays(-7)
                While _filter.Minimum.DayOfWeek <> DayOfWeek.Monday
                    _filter.Minimum = _filter.Minimum.AddDays(-1)
                End While
            End If
            '
            If _chkCurrentMonth.Checked Then
                _filter.Maximum = DateAndTime.DateSerial(today.Year, today.Month, 1).AddMonths(1).AddDays(-1)
                _filter.Minimum = DateAndTime.DateSerial(today.Year, today.Month, 1)
            End If
            '
            If _chkLastMonth.Checked Then
                _filter.Maximum = DateAndTime.DateSerial(today.Year, today.Month, 1).AddDays(-1)
                _filter.Minimum = DateAndTime.DateSerial(today.Year, today.Month, 1).AddMonths(-1)
            End If
            '
            If _chkCurrentYear.Checked Then
                _filter.Maximum = DateAndTime.DateSerial(today.Year, 12, 31)
                _filter.Minimum = DateAndTime.DateSerial(today.Year, 1, 1)
            End If
            '
            If _chkLastYear.Checked Then
                _filter.Maximum = DateAndTime.DateSerial(today.Year - 1, 12, 31)
                _filter.Minimum = DateAndTime.DateSerial(today.Year - 1, 1, 1)
            End If
            '

        End If

    End Sub

    Public Sub Initialize(ByVal grid As C1.Win.C1FlexGrid.C1FlexGridBase, ByVal columnIndex As Integer, ByVal filter As C1.Win.C1FlexGrid.IC1ColumnFilter) Implements C1.Win.C1FlexGrid.IC1ColumnFilterEditor.Initialize
        Me.BackColor = Color.Transparent
        _calendar.Location = New Point(8, 15)
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
