Public Class ExceptionEx
    Inherits Exception

    Public Sub New()
    End Sub

    Public Sub New(message As String)
        MyBase.New(message)
    End Sub

    Public Sub New(message As String, innerException As Exception)
        MyBase.New(message, innerException)
    End Sub

    Public Sub New(message As String, submessage As String)
        MyBase.New(message & " " & submessage)
    End Sub

End Class
