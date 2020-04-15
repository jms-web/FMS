Imports System.ComponentModel.DataAnnotations
Imports System.ComponentModel.DataAnnotations.Schema
Imports PropertyChanged

''' <summary>
''' D007_不適合封じ込め調査書情報
''' </summary>
<Table(NameOf(D010_FCCB_SUB_SYOCHI_KOMOKU), Schema:="dbo")>
<AddINotifyPropertyChangedInterface>
Partial Public Class D010_FCCB_SUB_SYOCHI_KOMOKU
    Inherits ModelBase

    Public Shadows Sub Clear()



    End Sub

    ''' <summary>
    ''' 報告書No
    ''' </summary>
    ''' <returns></returns>
    <Key>
    <Column(Order:=0, TypeName:="char")>
    <StringLength(10)>
    Public Property HOKOKU_NO As String

    <Required>
    <StringLength(2)>
    <Column(TypeName:="varchar")>
    Public Property ITEM_NO As String

    <Required>
    <StringLength(20)>
    <Column(TypeName:="nvarchar")>
    Public Property ITEM_GROUP_NAME As String

    <Required>
    <StringLength(50)>
    <Column(TypeName:="nvarchar")>
    Public Property ITEM_NAME As String

    <Required>
    Public Property TANTO_GYOMU_GROUP_ID As Integer

    <Required>
    <Column(NameOf(YOHI_KB), TypeName:="char")>
    <StringLength(1)>
    <Display(AutoGenerateField:=False)>
    Public Property _YOHI_KB As String

    <NotMapped>
    Public Property YOHI_KB As Boolean
        Get
            Return (_YOHI_KB = "1")
        End Get
        Set(value As Boolean)
            _YOHI_KB = If(value, "1", "0")
        End Set
    End Property

    <Required>
    Public Property TANTO_ID As Integer

    <Required>
    <StringLength(300)>
    <Column(TypeName:="nvarchar")>
    Public Property NAIYO As String

    <Required>
    <StringLength(100)>
    <Column(TypeName:="nvarchar")>
    Public Property GOKI As String

    <Required>
    <Column(TypeName:="char")>
    <StringLength(8)>
    <ComponentModel.DisplayName("完了予定日")>
    Public Property YOTEI_YMD As String

    <Required>
    <Column(TypeName:="char")>
    <StringLength(8)>
    <ComponentModel.DisplayName("完了日")>
    Public Property CLOSE_YMD As String
End Class