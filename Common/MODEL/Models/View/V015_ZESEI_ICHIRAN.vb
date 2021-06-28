Imports System.ComponentModel.DataAnnotations
Imports System.ComponentModel.DataAnnotations.Schema
Imports PropertyChanged

''' <summary>
''' D007_不適合封じ込め調査書情報
''' </summary>
<Table(NameOf(V015_ZESEI_ICHIRAN), Schema:="dbo")>
<AddINotifyPropertyChangedInterface>
Partial Public Class V015_ZESEI_ICHIRAN
    Inherits ModelBase

    Public Property HOKOKU_NO As String

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

    Public Property FILE_PATH1 As String

    Public Property FILE_PATH2 As String

    Public Property FILE_PATH3 As String

    Public Property FILE_PATH4 As String

    Public Property FILE_PATH5 As String

    Public Property COMMENT1 As String

    Public Property COMMENT2 As String

    Public Property COMMENT3 As String

    Public Property COMMENT4 As String

    Public Property COMMENT5 As String

    Public Property ADD_YMDHNS As String

    Public Property ADD_TANTO_ID As String

End Class