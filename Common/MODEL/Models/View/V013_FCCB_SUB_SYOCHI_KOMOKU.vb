Imports System.ComponentModel.DataAnnotations
Imports System.ComponentModel.DataAnnotations.Schema
Imports PropertyChanged

''' <summary>
''' D007_不適合封じ込め調査書情報
''' </summary>
<Table(NameOf(V013_FCCB_SUB_SYOCHI_KOMOKU), Schema:="dbo")>
<AddINotifyPropertyChangedInterface>
Partial Public Class V013_FCCB_SUB_SYOCHI_KOMOKU
    Inherits ModelBase

    'Public Shadows Sub Clear()



    'End Sub

    ''' <summary>
    ''' 報告書No
    ''' </summary>
    ''' <returns></returns>
    <Key>
    <Column(Order:=0, TypeName:="varchar")>
    <StringLength(10)>
    Public Property FCCB_NO As String

    <Key>
    <Column(Order:=1)>
    <Required>
    Public Property ITEM_NO As Integer

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
    Public Property YOTEI_YMD As String

    <Required>
    <Display(AutoGenerateField:=False)>
    <ComponentModel.DisplayName("完了予定日")>
    Public Property dtYOTEI_YMD As Date
        Get
            Return If(String.IsNullOrWhiteSpace(YOTEI_YMD), Nothing, DateTime.ParseExact(YOTEI_YMD, "yyyyMMdd", Nothing))
        End Get
        Set(value As Date)
            YOTEI_YMD = value.ToString("yyyyMMdd")
        End Set
    End Property

    <Required>
    <Column(TypeName:="char")>
    <StringLength(8)>
    Public Property CLOSE_YMD As String

    <Required>
    <Display(AutoGenerateField:=False)>
    <ComponentModel.DisplayName("完了日")>
    Public Property dtCLOSE_YMD As Date
        Get
            Return If(String.IsNullOrWhiteSpace(CLOSE_YMD), Nothing, DateTime.ParseExact(CLOSE_YMD, "yyyyMMdd", Nothing))
        End Get
        Set(value As Date)
            CLOSE_YMD = value.ToString("yyyyMMdd")
        End Set
    End Property
End Class