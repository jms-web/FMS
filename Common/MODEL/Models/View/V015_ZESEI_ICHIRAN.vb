Imports System.ComponentModel.DataAnnotations
Imports System.ComponentModel.DataAnnotations.Schema
Imports PropertyChanged

<Table(NameOf(V015_ZESEI_ICHIRAN), Schema:="dbo")>
<AddINotifyPropertyChangedInterface>
Partial Public Class V015_ZESEI_ICHIRAN
    Inherits ModelBase

    <ComponentModel.DisplayName("報告書No")>
    Public Property HOKOKU_NO As String

    <ComponentModel.DisplayName("承認順")>
    Public Property SYONIN_JUN As Integer

    <ComponentModel.DisplayName("承認内容")>
    Public Property SYONIN_NAIYO As String

    <ComponentModel.DisplayName("報告書")>
    Public Property SYONIN_HOKOKUSYO_ID As Integer

    <ComponentModel.DisplayName("報告書")>
    Public Property SYONIN_HOKOKUSYO_NAME As String

    <ComponentModel.DisplayName("報告書略名")>
    Public Property SYONIN_HOKOKUSYO_R_NAME As String

    <ComponentModel.DisplayName("現担当者ID")>
    Public Property GEN_TANTO_ID As Integer

    <ComponentModel.DisplayName("現担当者")>
    Public Property GEN_TANTO_NAME As String

    <ComponentModel.DisplayName("承認日時")>
    Public Property SYONIN_YMDHNS As String

    <ComponentModel.DisplayName("滞留日数")>
    Public Property TAIRYU_NISSU As Integer

    <ComponentModel.DisplayName("滞留フラグ")>
    Public Property TAIRYU_FG As Integer

    <ComponentModel.DisplayName("Closeフラグ")>
    Public Property CLOSE_FG As String

    <ComponentModel.DisplayName("部門区分")>
    Public Property BUMON_KB As String

    <ComponentModel.DisplayName("部門")>
    Public Property BUMON_NAME As String

    <ComponentModel.DisplayName("部署ID")>
    Public Property BUSYO_ID As Integer

    <ComponentModel.DisplayName("部署")>
    Public Property BUSYO_NAME As String

    <ComponentModel.DisplayName("担当者ID")>
    Public Property TANTO_ID As Integer

    <ComponentModel.DisplayName("プロセス責任者")>
    Public Property TANTO_NAME As String

    <ComponentModel.DisplayName("インプット情報")>
    Public Property INPUT_TYPE As String

    <ComponentModel.DisplayName("インプット情報")>
    Public Property INPUT_TYPE_DISP As String

    <ComponentModel.DisplayName("文書番号")>
    Public Property DOC_NO As String

    <ComponentModel.DisplayName("回答希望日")>
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

    <ComponentModel.DisplayName("観察報告事項")>
    Public Property KANSATU_HOUKOKU As String

    <ComponentModel.DisplayName("是正処置を必要とする理由")>
    Public Property ZESEI_RIYU As String

    <ComponentModel.DisplayName("是正改善要望その他コメント")>
    Public Property ZESEI_COMMENT As String

    <ComponentModel.DisplayName("回答日")>
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

    <ComponentModel.DisplayName("不適合対象")>
    Public Property FUTEKIGO_TAISYOU As String

    <ComponentModel.DisplayName("不適合調査範囲")>
    Public Property CHOUSA_HANI As String

    <ComponentModel.DisplayName("不適合遡及波及　有無")>
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

    <ComponentModel.DisplayName("影響が特定された範囲")>
    Public Property EIKYOU_HANI As String

    <ComponentModel.DisplayName("応急処置")>
    Public Property OUKYU_SYOCHI As String

    <ComponentModel.DisplayName("応急処置実施予定日")>
    Public Property OUKYU_SYOCHI_YOTEI_YMD As String

    <ComponentModel.DisplayName("人的要因有無")>
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

    <ComponentModel.DisplayName("発生原因")>
    Public Property HASSEI_GENIN As String

    <ComponentModel.DisplayName("是正処置")>
    Public Property ZESEI_SYOCHI As String

    <ComponentModel.DisplayName("是正実施予定日")>
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

    <ComponentModel.DisplayName("是正実施日")>
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

    <ComponentModel.DisplayName("応急処置実施日")>
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

    <ComponentModel.DisplayName("応急処置結果")>
    Public Property OUKYU_SYOCHI_KEKKA As String

    <ComponentModel.DisplayName("是正処置結果")>
    Public Property ZESEI_SYOCHI_KEKKA As String

    <ComponentModel.DisplayName("是正処置結果判定")>
    Public Property ZESEI_SYOCHI_HANTEI As String

    <ComponentModel.DisplayName("是正処置詳細資料No")>
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

    Public Property ADD_SYAIN_ID As String

    Public Property ADD_TANTO_NAME As String

    Public Property DEL_YMDHNS As String

    Public Property DEL_SYAIN_ID As String

End Class