Imports System.ComponentModel.DataAnnotations
Imports System.Reflection


Public Class ModelBase
    Implements IDataModel

    Public Sub New()
        Call Clear()
    End Sub

    <Display(AutoGenerateField:=False)>
    Default Public Property Item(ByVal propertyName As String) As Object Implements IDataModel.Item
        Get
            Return Me.GetType.GetProperty(propertyName).GetValue(Me)
        End Get
        Set(value As Object)
            Me.GetType.GetProperty(propertyName).SetValue(Me, value)
        End Set
    End Property

    Public Sub Clear() Implements IDataModel.Clear
        For Each p In Properties()
            Select Case p.PropertyType
                Case GetType(Boolean)
                    Me.Item(p.Name) = False
                Case GetType(Date), GetType(DateTime)
                    Me.Item(p.Name) = New DateTime
                Case GetType(Decimal)
                    Me.Item(p.Name) = 0D
                Case GetType(Double)
                    Me.Item(p.Name) = 0R
                Case GetType(Integer)
                    Me.Item(p.Name) = 0I
                Case GetType(String)
                    Me.Item(p.Name) = " "
                Case Else
                    Me.Item(p.Name) = Nothing
            End Select
        Next
    End Sub

    Public Property Properties() As Generic.List(Of PropertyInfo) Implements IDataModel.Properties
        Get
            Dim _properties = New Generic.List(Of Reflection.PropertyInfo)
            [GetType].GetProperties(BindingFlags.Public Or
                                    BindingFlags.Instance Or
                                    BindingFlags.Static).
                      ForEach(Sub(p) If IsAutoGenerateField(p.Name) = True Then _properties.Add(p))

            Return _properties
        End Get
        Set(value As Generic.List(Of PropertyInfo))

        End Set
    End Property

    ''' <summary>
    '''自動生成対象フィールド(テーブルのフィールド)かどうか判定
    ''' </summary>
    ''' <param name="_propertyName">フィールド名(プロパティ名)</param>
    ''' <returns></returns>
    Public Function IsAutoGenerateField(_propertyName As String) As Boolean
        Dim _attribute As DisplayAttribute = Attribute.GetCustomAttribute(Me.GetType.GetProperty(_propertyName), GetType(DisplayAttribute))

        If _attribute Is Nothing Then
            Return True
        Else
            Return _attribute.AutoGenerateField
        End If

    End Function

End Class