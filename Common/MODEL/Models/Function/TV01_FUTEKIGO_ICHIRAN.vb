Imports System
Imports System.Collections.Generic
Imports System.ComponentModel.DataAnnotations
Imports System.ComponentModel.DataAnnotations.Schema
Imports System.Data.Entity.Spatial

''' <summary>
''' TV01 sKñê e[ulÖ
''' </summary>
Partial Public Class TV01_FUTEKIGO_ICHIRAN

    <NotMapped>
    <ComponentModel.DisplayName("Ið")>
    Public Property SELECTED As Boolean

    <Key>
    <Column(Order:=0)>
    <StringLength(10)>
    <ComponentModel.DisplayName("ñNo")>
    Public Property HOKOKUSYO_NO As String

    <Key>
    <Column(Order:=1)>
    <StringLength(1)>
    <ComponentModel.DisplayName("N[YtO")>
    Public Property CLOSE_FLG As String

    <Key>
    <Column(Order:=2)>
    <ComponentModel.DisplayName("³F")>
    Public Property SYONIN_JUN As Integer

    <Key>
    <Column(Order:=3)>
    <StringLength(50)>
    <ComponentModel.DisplayName("Xe[W")>
    Public Property SYONIN_NAIYO As String

    <Key>
    <Column(Order:=4)>
    <ComponentModel.DisplayName("³FñID")>
    <Display(AutoGenerateField:=False)>
    Public Property SYONIN_HOKOKUSYO_ID As Integer

    <Key>
    <Column(Order:=5)>
    <StringLength(50)>
    <ComponentModel.DisplayName("ñ¼")>
    Public Property SYONIN_HOKOKUSYO_NAME As String 'ñ¼

    <Key>
    <Column(Order:=6)>
    <StringLength(10)>
    <ComponentModel.DisplayName("íÞª¼")>
    Public Property SYONIN_HOKOKUSYO_R_NAME As String 'ñª¼

    <Key>
    <Column(Order:=7)>
    <ComponentModel.DisplayName("uSÒÐõID")>
    <Display(AutoGenerateField:=False)>
    Public Property SYOCHI_SYAIN_ID As Integer

    <Key>
    <Column(Order:=8)>
    <StringLength(30)>
    <ComponentModel.DisplayName("uSÒ¼")>
    Public Property SYOCHI_SYAIN_NAME As String

    <Key>
    <Column(Order:=9)>
    <ComponentModel.DisplayName("Ø¯ú")>
    Public Property TAIRYU As Integer

    <Key>
    <Column(Order:=10)>
    <ComponentModel.DisplayName("@íID")>
    <Display(AutoGenerateField:=False)>
    Public Property KISYU_ID As Integer

    <Key>
    <Column(Order:=11)>
    <StringLength(100)>
    <ComponentModel.DisplayName("@í")>
    Public Property KISYU As String

    <Key>
    <Column(Order:=12)>
    <StringLength(100)>
    <ComponentModel.DisplayName("@í")>
    Public Property KISYU_NAME As String '@í¼

    <Key>
    <Column(Order:=13)>
    <StringLength(60)>
    <ComponentModel.DisplayName("iÔ")>
    Public Property BUHIN_BANGO As String

    <Key>
    <Column(Order:=14)>
    <StringLength(100)>
    <ComponentModel.DisplayName("i¼")>
    Public Property BUHIN_NAME As String 'i¼

    <Key>
    <Column(Order:=15)>
    <StringLength(1)>
    <ComponentModel.DisplayName("O»èæª")>
    Public Property JIZEN_SINSA_HANTEI_KB As String

    <Key>
    <Column(Order:=16)>
    <StringLength(50)>
    <ComponentModel.DisplayName("O»èæª")>
    Public Property JIZEN_SINSA_HANTEI_KB_DISP As String

    <Key>
    <Column(Order:=17)>
    <StringLength(1)>
    <ComponentModel.DisplayName("ÄR»èæª")>
    Public Property SAISIN_IINKAI_HANTEI_KB As String

    <Key>
    <Column(Order:=18)>
    <StringLength(50)>
    <ComponentModel.DisplayName("ÄR»èæª")>
    Public Property SAISIN_IINKAI_HANTEI_KB_DISP As String

    <Key>
    <StringLength(8)>
    <ComponentModel.DisplayName("Nú")>
    <Display(AutoGenerateField:=False)>
    <Column(NameOf(ADD_YMD), Order:=19, TypeName:="String")>
    Public Property _ADD_YMD As String

    <NotMapped>
    <ComponentModel.DisplayName("Nú")>
    Public Property ADD_YMD As Date
        Get
            Return DateTime.ParseExact(_ADD_YMD, "yyyyMMdd", Nothing)
        End Get
        Set(value As Date)

            _ADD_YMD = value.ToString("yyyyMMdd")
        End Set
    End Property

    <Key>
    <Column(NameOf(SYOCHI_YMD), Order:=20, TypeName:="String")>
    <StringLength(8)>
    <ComponentModel.DisplayName("OuÀ{ú")>
    <Display(AutoGenerateField:=False)>
    Public Property _SYOCHI_YMD As String

    <NotMapped>
    <ComponentModel.DisplayName("OuÀ{ú")>
    Public Property SYOCHI_YMD As Date
        Get
            Return DateTime.ParseExact(_SYOCHI_YMD, "yyyyMMdd", Nothing)
        End Get
        Set(value As Date)

            _SYOCHI_YMD = value.ToString("yyyyMMdd")
        End Set
    End Property

    <Key>
    <Column(Order:=21)>
    <ComponentModel.DisplayName("·ß³³F")>
    Public Property MODOSI_SYONIN_JUN As Integer

    <Key>
    <Column(Order:=22, TypeName:="nvarchar")>
    <StringLength(50)>
    <ComponentModel.DisplayName("·ß³³F")>
    Public Property MODOSI_SYONIN_NAIYO As String

    <Key>
    <Column(Order:=23, TypeName:="nvarchar")>
    <StringLength(100)>
    <ComponentModel.DisplayName("·ß³³F")>
    Public Property MODOSI_RIYU As String

    <Key>
    <Column(Order:=24)>
    <ComponentModel.DisplayName("xÊmØ¯ú")>
    Public Property KEIKOKU_TAIRYU As Integer

End Class
