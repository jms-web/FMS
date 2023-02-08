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
                    Me.Item(p.Name) = ""
                Case Else
                    Me.Item(p.Name) = Nothing
            End Select
        Next
    End Sub

    Public Function Properties() As Generic.List(Of PropertyInfo) Implements IDataModel.Properties
        Dim _properties = New Generic.List(Of Reflection.PropertyInfo)
        [GetType].GetProperties(BindingFlags.Public Or
                                BindingFlags.Instance Or
                                BindingFlags.Static).
                  ForEach(Sub(p) If IsAutoGenerateField(p.Name) = True Then _properties.Add(p))

        Return _properties
    End Function

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

    ''' <summary>
    ''' ModelインスタンスからMerge文などで使用できるSELECT SQL文字列を生成
    ''' </summary>
    ''' <returns></returns>
    Public Function ToSelectSqlString() As String
        Dim sbSQL As New System.Text.StringBuilder

        sbSQL.Append("SELECT ")

        Properties.Take(1).ForEach(
                  Sub(p)
                      Select Case True
                          Case p.PropertyType Is GetType(String)
                              sbSQL.Append($" N'{Me.Item(p.Name).ToString.EscapeLiteral}' AS {p.Name}")
                          Case p.PropertyType Is GetType(Boolean)
                              sbSQL.Append($" '{If(Me.Item(p.Name), 1, 0)}' AS {p.Name}")
                          Case Else
                              sbSQL.Append($" {Me.Item(p.Name)} AS {p.Name}")
                      End Select
                  End Sub)
        Properties.Skip(1).ForEach(
                    Sub(p)
                        Select Case True
                            Case p.PropertyType Is GetType(String)
                                sbSQL.Append($" ,N'{Me.Item(p.Name).ToString.EscapeLiteral}' AS {p.Name}")
                            Case p.PropertyType Is GetType(Boolean)
                                sbSQL.Append($" ,'{If(Me.Item(p.Name), 1, 0)}' AS {p.Name}")
                            Case Else
                                sbSQL.Append($" ,{Me.Item(p.Name)} AS {p.Name}")
                        End Select
                    End Sub)

        Return sbSQL.ToString
    End Function

    ''' <summary>
    ''' ModelインスタンスからMerge文などで使用できるUPDATE SQL文字列を生成
    ''' </summary>
    ''' <param name="targetSchema">更新元のスキーマ名(DB側)</param>
    ''' <param name="sourceSchema">更新対象のスキーマ名(Entity側)</param>
    ''' <returns></returns>
    Public Function ToUpdateSqlString(targetSchema As String, sourceSchema As String) As String
        Dim sbSQL As New System.Text.StringBuilder
        Dim props = Properties.Where(Function(p) Attribute.IsDefined(Me.GetType.GetProperty(p.Name), GetType(KeyAttribute)) = False)

        sbSQL.Append($"UPDATE SET")
        props.Take(1).Where(Function(p) p.Name <> "ADD_YMDHNS" And p.Name <> "ADD_SYAIN_ID").ForEach(Sub(p) sbSQL.Append($"  {targetSchema}.{p.Name} = {sourceSchema}.{p.Name}"))
        props.Skip(1).Where(Function(p) p.Name <> "ADD_YMDHNS" And p.Name <> "ADD_SYAIN_ID").ForEach(Sub(p) sbSQL.Append($" ,{targetSchema}.{p.Name} = {sourceSchema}.{p.Name}"))

        Return sbSQL.ToString
    End Function

    ''' <summary>
    ''' ModelインスタンスからMerge文などで使用できるINSERT SQL文字列を生成
    ''' </summary>
    ''' <param name="sourceSchema">更新対象のスキーマ名(Entity側)</param>
    ''' <returns></returns>
    Public Function ToInsertSqlString(sourceSchema As String) As String
        Dim sbSQL As New System.Text.StringBuilder

        sbSQL.Append($"INSERT(")
        Properties.Take(1).ForEach(Sub(p) sbSQL.Append($" {p.Name}"))
        Properties.Skip(1).ForEach(Sub(p) sbSQL.Append($",{p.Name}"))
        sbSQL.Append($" ) VALUES(")
        Properties.Take(1).ForEach(Sub(p) sbSQL.Append($" {sourceSchema}.{p.Name}"))
        Properties.Skip(1).ForEach(Sub(p) sbSQL.Append($",{sourceSchema}.{p.Name}"))
        sbSQL.Append(" )")

        Return sbSQL.ToString
    End Function

End Class