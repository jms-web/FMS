Imports System.ComponentModel.DataAnnotations
Imports System.ComponentModel.DataAnnotations.Schema
Imports PropertyChanged

''' <summary>
''' D008_不適合封じ込め調査書情報
''' </summary>
<Table(NameOf(D008_FCR_J_SUB), Schema:="dbo")>
<AddINotifyPropertyChangedInterface>
Partial Public Class D008_FCR_J_SUB
    Inherits ModelBase

    Public Shadows Sub Clear()
        HOKOKU_NO = ""
        KISYU_ID = 0
        BUHIN_INFO = ""
        SURYO = 0
        RANGE_FROM = ""
        RANGE_TO = ""
        ADD_SYAIN_ID = 0
        ADD_YMDHNS = ""
        UPD_SYAIN_ID = 0
        UPD_YMDHNS = ""
        DEL_SYAIN_ID = 0
        DEL_YMDHNS = ""

    End Sub

    ''' <summary>
    ''' 報告書No
    ''' </summary>
    ''' <returns></returns>
    <Key>
    <Column(Order:=0, TypeName:="char")>
    <StringLength(10)>
    Public Property HOKOKU_NO As String

    <Key>
    <Column(Order:=1)>
    Public Property ROW_NO As Integer

    ''' <summary>
    ''' 機種
    ''' </summary>
    ''' <returns></returns>
    <Required>
    Public Property KISYU_ID As Integer

    ''' <summary>
    ''' 部品情報(部品番号、品名)
    ''' </summary>
    ''' <returns></returns>
    <Required>
    <StringLength(100)>
    <Column(TypeName:="nvarchar")>
    Public Property BUHIN_INFO As String

    ''' <summary>
    ''' 数量
    ''' </summary>
    ''' <returns></returns>
    <Required>
    Public Property SURYO As Integer

    ''' <summary>
    ''' 範囲FROM
    ''' </summary>
    ''' <returns></returns>
    <Required>
    <StringLength(100)>
    <Column(TypeName:="nvarchar")>
    Public Property RANGE_FROM As String

    ''' <summary>
    ''' 範囲TO
    ''' </summary>
    ''' <returns></returns>
    <Required>
    <StringLength(100)>
    <Column(TypeName:="nvarchar")>
    Public Property RANGE_TO As String

    ''共通項目------------------------------------
    <Required>
    <StringLength(14)>
    <Column(TypeName:="char")>
    Public Property ADD_YMDHNS As String

    <NotMapped>
    <DoNotNotify>
    <Display(AutoGenerateField:=False)>
    Public ReadOnly Property ADD_YMD As String
        Get
            Dim strRET As String
            If ADD_YMDHNS IsNot Nothing AndAlso ADD_YMDHNS.Length = 14 Then
                strRET = DateTime.ParseExact(ADD_YMDHNS, "yyyyMMddHHmmss", Nothing).ToString("yyyy/MM/dd")
            Else
                strRET = ""
            End If
            Return strRET
        End Get
    End Property

    <Required>
    Public Property ADD_SYAIN_ID As Integer

    <Required>
    <StringLength(14)>
    <Column(TypeName:="char")>
    Public Property UPD_YMDHNS As String

    <Required>
    Public Property UPD_SYAIN_ID As Integer

    <Required>
    <StringLength(14)>
    <Column(TypeName:="char")>
    Public Property DEL_YMDHNS As String

    <ComponentModel.DisplayName("削除済")>
    <NotMapped>
    <DoNotNotify>
    <Display(AutoGenerateField:=False)>
    Public ReadOnly Property DEL_FLG As Boolean
        Get
            Return Not String.IsNullOrWhiteSpace(DEL_YMDHNS)
        End Get
    End Property

    <Required>
    Public Property DEL_SYAIN_ID As Integer

End Class