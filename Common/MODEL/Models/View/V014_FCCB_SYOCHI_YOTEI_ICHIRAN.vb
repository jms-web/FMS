Imports System.ComponentModel.DataAnnotations
Imports System.ComponentModel.DataAnnotations.Schema
Imports PropertyChanged

''' <summary>
''' D007_不適合封じ込め調査書情報
''' </summary>
<Table(NameOf(V014_FCCB_SYOCHI_YOTEI_ICHIRAN), Schema:="dbo")>
<AddINotifyPropertyChangedInterface>
Partial Public Class V014_FCCB_SYOCHI_YOTEI_ICHIRAN
    Inherits ModelBase

    <Required>
    <StringLength(10)>
    Public Property FCCB_NO As String

    <Required>
    Public Property TANTO_ID As Integer

    <Required>
    <Column(TypeName:="nvarchar")>
    Public Property TANTO_NAME As String


    <Required>
    Public Property KISYU_ID As Integer

    <Required>
    <Column(TypeName:="nvarchar")>
    Public Property KISYU_NAME As String

    <Required>
    <Column(TypeName:="nvarchar")>
    Public Property BUHIN_BANGO As String

    <Required>
    <Column(TypeName:="char")>
    <StringLength(8)>
    Public Property KISO_YMD As String

    <Required>
    <Display(AutoGenerateField:=False)>
    <ComponentModel.DisplayName("完了予定日")>
    Public Property dtKISO_YMD As Date
        Get
            Return If(String.IsNullOrWhiteSpace(KISO_YMD), Nothing, DateTime.ParseExact(KISO_YMD, "yyyyMMdd", Nothing))
        End Get
        Set(value As Date)
            KISO_YMD = value.ToString("yyyyMMdd")
        End Set
    End Property

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