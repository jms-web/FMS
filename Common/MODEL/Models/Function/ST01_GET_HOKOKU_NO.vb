Imports System
Imports System.Collections.Generic
Imports System.ComponentModel.DataAnnotations
Imports System.ComponentModel.DataAnnotations.Schema
Imports System.Data.Entity.Spatial

''' <summary>
''' ST02 sKñê e[ulÖ
''' </summary>
Partial Public Class ST01_GET_HOKOKU_NO

    'CfNTvpeB
    <Display(AutoGenerateField:=False)>
    Default Public Property Item(ByVal propertyName As String) As Object
        Get
            Return GetType(ST01_GET_HOKOKU_NO).GetProperty(propertyName).GetValue(Me)
        End Get
        Set(value As Object)
            GetType(ST01_GET_HOKOKU_NO).GetProperty(propertyName).SetValue(Me, value)
        End Set
    End Property

    <NotMapped>
    <ComponentModel.DisplayName("Ið")>
    Public Property SELECTED As Boolean

    <StringLength(10)>
    <ComponentModel.DisplayName("ñNo")>
    Public Property HOKOKU_NO As String

    <ComponentModel.DisplayName("³F")>
    Public Property SYONIN_JUN As Integer

    <StringLength(50)>
    <ComponentModel.DisplayName("Xe[W")>
    Public Property SYONIN_NAIYO As String

    <ComponentModel.DisplayName("³FñID")>
    Public Property SYONIN_HOKOKUSYO_ID As Integer

    <StringLength(50)>
    <ComponentModel.DisplayName("ñ¼")>
    Public Property SYONIN_HOKOKUSYO_NAME As String 'ñ¼

    <StringLength(10)>
    <ComponentModel.DisplayName("íÞª¼")>
    Public Property SYONIN_HOKOKUSYO_R_NAME As String 'ñª¼

    <ComponentModel.DisplayName("uSÒÐõID")>
    Public Property GEN_TANTO_ID As Integer

    <StringLength(30)>
    <ComponentModel.DisplayName("uSÒ¼")>
    Public Property GEN_TANTO_NAME As String


    <ComponentModel.DisplayName("³Fú")>
    <Display(AutoGenerateField:=False)>
    <Column(NameOf(SYONIN_YMDHNS), TypeName:="String")>
    Public Property _SYONIN_YMDHNS As String

    <NotMapped>
    <ComponentModel.DisplayName("³Fú")>
    Public Property SYONIN_YMDHNS As DateTime
        Get
            Return DateTime.ParseExact(_SYONIN_YMDHNS, "yyyyMMddHHmmss", Nothing)
        End Get
        Set(value As DateTime)

            _SYONIN_YMDHNS = value.ToString("yyyyMMddHHmmss")
        End Set
    End Property

    <ComponentModel.DisplayName("Ø¯ú")>
    Public Property TAIRYU_NISSU As Integer

    <StringLength(1)>
    <ComponentModel.DisplayName("Ø¯tO")>
    Public Property TAIRYU_FG As String

    <ComponentModel.DisplayName("@íID")>
    <Display(AutoGenerateField:=False)>
    Public Property KISYU_ID As Integer

    <StringLength(100)>
    <ComponentModel.DisplayName("@í")>
    Public Property KISYU As String

    <StringLength(100)>
    <ComponentModel.DisplayName("@í")>
    Public Property KISYU_NAME As String '@í¼

    <StringLength(60)>
    <ComponentModel.DisplayName("iÔ")>
    Public Property BUHIN_BANGO As String

    <StringLength(100)>
    <ComponentModel.DisplayName("i¼")>
    Public Property BUHIN_NAME As String 'i¼

    <StringLength(5)>
    <ComponentModel.DisplayName("@")>
    Public Property GOKI As String

    <StringLength(10)>
    <ComponentModel.DisplayName("@")>
    Public Property SYANAI_CD As String

    <StringLength(2)>
    <ComponentModel.DisplayName("sKæª")>
    Public Property FUTEKIGO_KB As String

    <StringLength(50)>
    <ComponentModel.DisplayName("sKæª¼")>
    Public Property FUTEKIGO_NAME As String

    <StringLength(50)>
    <ComponentModel.DisplayName("sKÚ×æª¼")>
    Public Property FUTEKIGO_S_NAME As String

    <StringLength(2)>
    <ComponentModel.DisplayName("sKÚ×æª")>
    Public Property FUTEKIGO_S_KB As String

    <StringLength(2)>
    <ComponentModel.DisplayName("sKóÔæª")>
    Public Property FUTEKIGO_JYOTAI_KB As String

    <StringLength(2)>
    <ComponentModel.DisplayName("sKóÔæª")>
    Public Property FUTEKIGO_JYOTAI_NAME As String

    <StringLength(1)>
    <ComponentModel.DisplayName("O»èæª")>
    Public Property JIZEN_SINSA_HANTEI_KB As String

    <StringLength(50)>
    <ComponentModel.DisplayName("O»èæª¼")>
    Public Property JIZEN_SINSA_HANTEI_NAME As String

    <StringLength(1)>
    <ComponentModel.DisplayName("¥³uvÛæª")>
    Public Property ZESEI_SYOCHI_YOHI_KB As String

    <StringLength(150)>
    <ComponentModel.DisplayName("¥³uvÛæª¼")>
    Public Property ZESEI_SYOCHI_YOHI_NAME As String

    <StringLength(1)>
    <ComponentModel.DisplayName("ÄRÏõï»èæª")>
    Public Property SAISIN_IINKAI_HANTEI_KB As String

    <StringLength(50)>
    <ComponentModel.DisplayName("ÄRÏõï»èæª¼")>
    Public Property SAISIN_IINKAI_HANTEI_NAME As String

    <StringLength(1)>
    <ComponentModel.DisplayName("¸Êæª")>
    Public Property KENSA_KEKKA_KB As String

    <StringLength(50)>
    <ComponentModel.DisplayName("¸Êæª¼")>
    Public Property KENSA_KEKKA_NAME As String

    <StringLength(1)>
    <ComponentModel.DisplayName("ª{vöæª1")>
    Public Property KONPON_YOIN_KB1 As String

    <StringLength(50)>
    <ComponentModel.DisplayName("ª{vöæª¼1")>
    Public Property KONPON_YOIN_NAME1 As String

    <StringLength(1)>
    <ComponentModel.DisplayName("ª{vöæª2")>
    Public Property KONPON_YOIN_KB2 As String

    <StringLength(50)>
    <ComponentModel.DisplayName("ª{vöæª¼2")>
    Public Property KONPON_YOIN_NAME2 As String

    <StringLength(1)>
    <ComponentModel.DisplayName("AÓHöæª")>
    Public Property KISEKI_KOTEI_KB As String

    <StringLength(50)>
    <ComponentModel.DisplayName("AÓHöæª¼")>
    Public Property KISEKI_KOTEI_NAME As String

    <ComponentModel.DisplayName("Nú")>
    <Display(AutoGenerateField:=False)>
    <Column(NameOf(KISO_YMD), TypeName:="String")>
    Public Property _KISO_YMD As String

    <NotMapped>
    <ComponentModel.DisplayName("Nú")>
    Public Property KISO_YMD As Date
        Get
            Return DateTime.ParseExact(_KISO_YMD, "yyyyMMdd", Nothing)
        End Get
        Set(value As Date)

            _KISO_YMD = value.ToString("yyyyMMdd")
        End Set
    End Property

    <ComponentModel.DisplayName("NSÒID")>
    Public Property KISO_TANTO_ID As Integer

    <StringLength(30)>
    <ComponentModel.DisplayName("NSÒ¼")>
    Public Property KISO_TANTO_NAME As String

    <StringLength(1)>
    <ComponentModel.DisplayName("N[YtO")>
    Public Property CLOSE_FG As String

    <ComponentModel.DisplayName("·ß³³F")>
    Public Property SASIMOTO_SYONIN_JUN As Integer

    <StringLength(50)>
    <ComponentModel.DisplayName("·ß³³Fàe")>
    Public Property SASIMOTO_SYONIN_NAIYO As String

    <StringLength(100)>
    <ComponentModel.DisplayName("·ßR")>
    Public Property RIYU As String

    <StringLength(500)>
    <ComponentModel.DisplayName("vàe")>
    Public Property YOKYU_NAIYO As String

    <StringLength(1)>
    <ComponentModel.DisplayName("åæª")>
    Public Property BUMON_KB As String

    <StringLength(50)>
    <ComponentModel.DisplayName("åæª")>
    Public Property BUMON_NAME As String

    <StringLength(2)>
    <ComponentModel.DisplayName("Úq»èw¦æª")>
    Public Property KOKYAKU_HANTEI_SIJI_KB As String

    <StringLength(150)>
    <ComponentModel.DisplayName("Úq»èw¦æª¼")>
    Public Property KOKYAKU_HANTEI_SIJI_NAME As String

    <StringLength(2)>
    <ComponentModel.DisplayName("ÚqÅI»èæª")>
    Public Property KOKYAKU_SAISYU_HANTEI_KB As String

    <StringLength(150)>
    <ComponentModel.DisplayName("ÚqÅI»èæª¼")>
    Public Property KOKYAKU_SAISYU_HANTEI_NAME As String

    <StringLength(14)>
    <ComponentModel.DisplayName("íú")>
    Public Property DEL_YMDHNS As String


End Class
