
Imports System.ComponentModel.DataAnnotations

Public MustInherit Class ModelBase
    <Display(AutoGenerateField:=False)>
    Default Public Property Item(ByVal propertyName As String) As Object
        Get
            Return Me.GetType.GetProperty(propertyName).GetValue(Me)
        End Get
        Set(value As Object)
            Me.GetType.GetProperty(propertyName).SetValue(Me, value)
        End Set
    End Property

End Class
