Imports System.ComponentModel

Public MustInherit Class NotifyChangedBase
    Implements INotifyPropertyChanged

    Public Event PropertyChanged As PropertyChangedEventHandler Implements INotifyPropertyChanged.PropertyChanged

    Protected Sub OnPropertyChanged(ByVal propertyName As String)
        Try
            RaiseEvent PropertyChanged(Me, New PropertyChangedEventArgs(propertyName))
        Catch ex As ArgumentOutOfRangeException

        End Try

    End Sub

End Class
