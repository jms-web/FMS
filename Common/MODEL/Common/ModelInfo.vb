Imports System.ComponentModel
Imports System.ComponentModel.DataAnnotations
Imports System.Reflection


Public Class ModelInfo(Of T As {New, IDataModel})

#Region "プロパティ"

    Public Shadows ReadOnly Property [GetType] As Type
        Get
            Return GetType(T)
        End Get
    End Property

    Public Property Data As New DataTable

    Public Property Entities As New List(Of T)

    <DefaultValue(True)>
    Public Property OnlyAutoGenerateField As Boolean

    Public Property Entity As T

    Public ReadOnly Property [Name] As String
        Get
            Return GetType(T).Name
        End Get
    End Property


#End Region

#Region "コンストラクタ"

    Public Sub New()
        OnlyAutoGenerateField = True
        Properties.ForEach(Sub(p) Data.Columns.Add(p.Name, p.PropertyType))
        Entity = New T
    End Sub

    Public Sub New(Optional _OnlyAutoGenerateField As Boolean = True, Optional srcDATA As DataTable = Nothing)
        OnlyAutoGenerateField = _OnlyAutoGenerateField

        Properties().ForEach(Sub(p) Data.Columns.Add(p.Name, p.PropertyType))
        Entity = New T
        If srcDATA IsNot Nothing Then
            Call SetDataSource(srcDATA)
            Call SetEntities(srcDATA)
        End If
    End Sub

#End Region

    ''' <summary>
    ''' モデルのフィールド一覧を取得
    ''' </summary>
    ''' <returns></returns>
    Public Function Properties() As Generic.List(Of PropertyInfo)
        Dim _properties = New Generic.List(Of Reflection.PropertyInfo)
        [GetType].GetProperties(BindingFlags.Public Or
                                BindingFlags.Instance Or
                                BindingFlags.Static).
                  ForEach(Sub(p) If OnlyAutoGenerateField = False Or IsAutoGenerateField(p.Name) = True Then _properties.Add(p))

        Return _properties

    End Function

    Public Sub SetEntities(srcDATA As DataTable)
        For Each row In srcDATA.Rows
            Dim _Model As New T
            For Each p In Properties()
                Select Case p.PropertyType
                    Case GetType(Boolean)
                        _Model(p.Name) = CBool(row(p.Name))
                    Case GetType(Date), GetType(DateTime)
                        _Model(p.Name) = CDate(row(p.Name))
                    Case GetType(Decimal)
                        _Model(p.Name) = CDec(row(p.Name))
                    Case GetType(Double)
                        _Model(p.Name) = CDbl(row(p.Name))
                    Case GetType(Integer)
                        _Model(p.Name) = CInt(row(p.Name))
                    Case GetType(String)
                        _Model(p.Name) = CStr(row(p.Name))
                    Case Else
                        _Model(p.Name) = row(p.Name)
                End Select
            Next p
            Entities.Add(_Model)
        Next row
    End Sub
    Public Sub SetEntity(dr As DataRow)
        Dim _Model As New T
        For Each p In Properties()
            Select Case p.PropertyType
                Case GetType(Boolean)
                    _Model(p.Name) = CBool(dr(p.Name))
                Case GetType(Date), GetType(DateTime)
                    _Model(p.Name) = CDate(dr(p.Name))
                Case GetType(Decimal)
                    _Model(p.Name) = CDec(dr(p.Name))
                Case GetType(Double)
                    _Model(p.Name) = CDbl(dr(p.Name))
                Case GetType(Integer)
                    _Model(p.Name) = CInt(dr(p.Name))
                Case GetType(String)
                    _Model(p.Name) = CStr(dr(p.Name))
                Case Else
                    _Model(p.Name) = dr(p.Name)
            End Select
        Next p
        Entities.Add(_Model)
    End Sub

    Public Sub SetDataSource(srcDATA As DataTable)
        'UNDONE: DBNullの場合エラー

        For Each row In srcDATA.Rows
            Dim r As DataRow = Data.NewRow()
            For Each p In Properties()
                Select Case p.PropertyType
                    Case GetType(Boolean)
                        r(p.Name) = CBool(row.Item(p.Name))
                    Case GetType(Date), GetType(DateTime)
                        r(p.Name) = CDate(row.Item(p.Name))
                    Case GetType(Decimal)
                        r(p.Name) = CDec(row.Item(p.Name))
                    Case GetType(Double)
                        r(p.Name) = CDbl(row.Item(p.Name))
                    Case GetType(Integer)
                        r(p.Name) = CInt(row.Item(p.Name))
                    Case GetType(String)
                        r(p.Name) = CStr(row.Item(p.Name))
                    Case Else
                        r(p.Name) = row.Item(p.Name)
                End Select
            Next p
            Data.Rows.Add(r)
        Next row
        Data.AcceptChanges()
    End Sub



#Region "内部関数"

    Private Function IsAutoGenerateField(_propertyName As String) As Boolean
        Dim _attribute As DisplayAttribute = Attribute.GetCustomAttribute([GetType].GetProperty(_propertyName),
                                                      GetType(DisplayAttribute))


        If _attribute Is Nothing Then
            Return True
        Else
            Return _attribute.AutoGenerateField
        End If


    End Function

#End Region

End Class

Public Interface IDataModel
    <Display(AutoGenerateField:=False)>
    Default Property Item(propertyName As String) As Object

    Sub Clear()
    Function Properties() As Generic.List(Of PropertyInfo)

End Interface


Module mdlExtention
    <Runtime.CompilerServices.Extension>
    Public Sub ForEach(Of T)(ItemSource As System.Collections.Generic.IEnumerable(Of T), AppliedAction As Action(Of T))
        For Each item As T In ItemSource
            AppliedAction(item)
        Next
    End Sub
End Module