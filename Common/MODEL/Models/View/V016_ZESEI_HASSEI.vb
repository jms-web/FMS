Imports System.ComponentModel.DataAnnotations
Imports System.ComponentModel.DataAnnotations.Schema
Imports PropertyChanged

<Table(NameOf(V016_ZESEI_HASSEI), Schema:="dbo")>
<AddINotifyPropertyChangedInterface>
Partial Public Class V016_ZESEI_HASSEI
    Inherits ModelBase

    Public Property HOKOKU_NO As String

    Public Property CLOSE_FG As String

    Public Property BUMON_KB As String

    Public Property BUMON_NAME As String

    Public Property BUSYO_ID As Integer

    Public Property BUSYO_NAME As String

    Public Property TANTO_ID As Integer

    Public Property TANTO_NAME As String

    Public Property INPUT_TYPE As String

    Public Property INPUT_TYPE_DISP As String

    Public Property DOC_NO As String

    Public Property KAITOU_KIBOU_YMD As String

    <NotMapped>
    <Display(AutoGenerateField:=False)>
    Public Property dtKAITOU_KIBOU_YMD As Date
        Get
            Return If(String.IsNullOrWhiteSpace(KAITOU_KIBOU_YMD), Nothing, DateTime.ParseExact(KAITOU_KIBOU_YMD, "yyyyMMdd", Nothing))
        End Get
        Set(value As Date)
            KAITOU_KIBOU_YMD = value.ToString("yyyyMMdd")
        End Set
    End Property

    Public Property KANSATU_HOUKOKU As String

    Public Property ZESEI_RIYU As String

    Public Property ZESEI_COMMENT As String

    Public Property KAITOU_YMD As String

    <NotMapped>
    <Display(AutoGenerateField:=False)>
    Public Property dtKAITOU_YMD As Date
        Get
            Return If(String.IsNullOrWhiteSpace(KAITOU_YMD), Nothing, DateTime.ParseExact(KAITOU_YMD, "yyyyMMdd", Nothing))
        End Get
        Set(value As Date)
            KAITOU_YMD = value.ToString("yyyyMMdd")
        End Set
    End Property

    Public Property FUTEKIGO_TAISYOU As String

    Public Property CHOUSA_HANI As String

    Public Property FUTEKIGO_UMU As String

    <NotMapped>
    <Display(AutoGenerateField:=False)>
    Public Property blFUTEKIGO_UMU As Boolean
        Get
            Return (FUTEKIGO_UMU = "1")
        End Get
        Set(value As Boolean)
            FUTEKIGO_UMU = If(value, "1", "0")
        End Set
    End Property

    Public Property EIKYOU_HANI As String

    Public Property OUKYU_SYOCHI As String

    Public Property OUKYU_SYOCHI_YOTEI_YMD As String

    Public Property JINTEKI_YOUIN_UMU As String

    <NotMapped>
    <Display(AutoGenerateField:=False)>
    Public Property blJINTEKI_YOUIN_UMU As Boolean
        Get
            Return (JINTEKI_YOUIN_UMU = "1")
        End Get
        Set(value As Boolean)
            JINTEKI_YOUIN_UMU = If(value, "1", "0")
        End Set
    End Property

    Public Property HASSEI_GENIN As String

    Public Property ZESEI_SYOCHI As String

    Public Property ZESEI_SYOCHI_YOTEI_YMD As String

    <NotMapped>
    <Display(AutoGenerateField:=False)>
    Public Property dtZESEI_SYOCHI_YOTEI_YMD As Date
        Get
            Return If(String.IsNullOrWhiteSpace(ZESEI_SYOCHI_YOTEI_YMD), Nothing, DateTime.ParseExact(ZESEI_SYOCHI_YOTEI_YMD, "yyyyMMdd", Nothing))
        End Get
        Set(value As Date)
            ZESEI_SYOCHI_YOTEI_YMD = value.ToString("yyyyMMdd")
        End Set
    End Property

    Public Property ZESEI_SYOCHI_YMD As String

    <NotMapped>
    <Display(AutoGenerateField:=False)>
    Public Property dtZESEI_SYOCHI_YMD As Date
        Get
            Return If(String.IsNullOrWhiteSpace(ZESEI_SYOCHI_YMD), Nothing, DateTime.ParseExact(ZESEI_SYOCHI_YMD, "yyyyMMdd", Nothing))
        End Get
        Set(value As Date)
            ZESEI_SYOCHI_YMD = value.ToString("yyyyMMdd")
        End Set
    End Property

    Public Property OUKYU_SYOCHI_YMD As String

    <NotMapped>
    <Display(AutoGenerateField:=False)>
    Public Property dtOUKYU_SYOCHI_YMD As Date
        Get
            Return If(String.IsNullOrWhiteSpace(OUKYU_SYOCHI_YMD), Nothing, DateTime.ParseExact(OUKYU_SYOCHI_YMD, "yyyyMMdd", Nothing))
        End Get
        Set(value As Date)
            OUKYU_SYOCHI_YMD = value.ToString("yyyyMMdd")
        End Set
    End Property

    Public Property OUKYU_SYOCHI_KEKKA As String

    Public Property ZESEI_SYOCHI_KEKKA As String

    Public Property ZESEI_SYOCHI_HANTEI As String

    Public Property ZESEI_SYOCHI_NG_DOC_NO As String

    Public Property REV_COMMENT As String

    Public Property MOTO_COMMENT As String

    Public Property ADD_YMDHNS As String

    Public Property ADD_SYAIN_ID As String

    Public Property ADD_TANTO_NAME As String

    Public Property DEL_YMDHNS As String

    Public Property DEL_SYAIN_ID As String

#Region "承認担当者"

    Public Property SYONIN_NAME10 As String

    Public Property SYONIN_YMD10 As String

    Public Property SYONIN_NAME11 As String

    Public Property SYONIN_YMD11 As String

    Public Property SYONIN_NAME12 As String

    Public Property SYONIN_YMD12 As String

    Public Property SYONIN_NAME20 As String

    Public Property SYONIN_YMD20 As String

    Public Property SYONIN_NAME21 As String

    Public Property SYONIN_YMD21 As String

    Public Property SYONIN_NAME22 As String

    Public Property SYONIN_YMD22 As String

    Public Property SYONIN_NAME23 As String

    Public Property SYONIN_YMD23 As String

    Public Property SYONIN_NAME24 As String

    Public Property SYONIN_YMD24 As String

    Public Property SYONIN_NAME30 As String

    Public Property SYONIN_YMD30 As String

    Public Property SYONIN_NAME31 As String

    Public Property SYONIN_YMD31 As String

    Public Property SYONIN_NAME32 As String

    Public Property SYONIN_YMD32 As String

    Public Property SYONIN_NAME40 As String

    Public Property SYONIN_YMD40 As String

    Public Property SYONIN_NAME41 As String

    Public Property SYONIN_YMD41 As String

    Public Property SYONIN_NAME42 As String

    Public Property SYONIN_YMD42 As String

    Public Property SYONIN_NAME50 As String

    Public Property SYONIN_YMD50 As String

    Public Property SYONIN_NAME51 As String

    Public Property SYONIN_YMD51 As String

    Public Property SYONIN_NAME52 As String

    Public Property SYONIN_YMD52 As String

#End Region

End Class