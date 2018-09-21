Imports System
Imports System.Collections.Generic
Imports System.ComponentModel.DataAnnotations
Imports System.ComponentModel.DataAnnotations.Schema
Imports System.Data.Entity.Spatial

''' <summary>
''' ST02 不適合報告書一覧 テーブル値関数
''' </summary>
Partial Public Class ST02_FUTEKIGO_ICHIRAN
    Inherits MODEL.ModelBase

    <NotMapped>
    <ComponentModel.DisplayName("選択")>
    Public Property SELECTED As Boolean

    <StringLength(10)>
    <ComponentModel.DisplayName("報告書No")>
    Public Property HOKOKU_NO As String

    <ComponentModel.DisplayName("承認順")>
    Public Property SYONIN_JUN As Integer

    <StringLength(50)>
    <ComponentModel.DisplayName("ステージ")>
    Public Property SYONIN_NAIYO As String

    <ComponentModel.DisplayName("承認報告書ID")>
    Public Property SYONIN_HOKOKUSYO_ID As Integer

    <StringLength(50)>
    <ComponentModel.DisplayName("報告書名")>
    Public Property SYONIN_HOKOKUSYO_NAME As String '報告書名

    <StringLength(10)>
    <ComponentModel.DisplayName("種類略名")>
    Public Property SYONIN_HOKOKUSYO_R_NAME As String '報告書略名

    <ComponentModel.DisplayName("処置担当者社員ID")>
    Public Property GEN_TANTO_ID As Integer

    <StringLength(30)>
    <ComponentModel.DisplayName("処置担当者名")>
    Public Property GEN_TANTO_NAME As String


    <ComponentModel.DisplayName("承認日時")>
    <Display(AutoGenerateField:=False)>
    <Column(NameOf(SYONIN_YMDHNS), TypeName:="String")>
    Public Property _SYONIN_YMDHNS As String

    <NotMapped>
    <ComponentModel.DisplayName("承認日時")>
    Public Property SYONIN_YMDHNS As DateTime
        Get
            Return DateTime.ParseExact(_SYONIN_YMDHNS, "yyyyMMddHHmmss", Nothing)
        End Get
        Set(value As DateTime)

            _SYONIN_YMDHNS = value.ToString("yyyyMMddHHmmss")
        End Set
    End Property

    <ComponentModel.DisplayName("滞留日数")>
    Public Property TAIRYU_NISSU As Integer

    <StringLength(1)>
    <ComponentModel.DisplayName("滞留フラグ")>
    Public Property TAIRYU_FG As String

    <ComponentModel.DisplayName("機種ID")>
    <Display(AutoGenerateField:=False)>
    Public Property KISYU_ID As Integer

    '<StringLength(100)>
    '<ComponentModel.DisplayName("機種")>
    'Public Property KISYU As String

    <StringLength(100)>
    <ComponentModel.DisplayName("機種")>
    Public Property KISYU_NAME As String '機種名

    <StringLength(60)>
    <ComponentModel.DisplayName("部品番号")>
    Public Property BUHIN_BANGO As String

    <StringLength(100)>
    <ComponentModel.DisplayName("品名")>
    Public Property BUHIN_NAME As String '部品名

    <StringLength(5)>
    <ComponentModel.DisplayName("号機")>
    Public Property GOKI As String

    <StringLength(10)>
    <ComponentModel.DisplayName("号機")>
    Public Property SYANAI_CD As String

    <StringLength(2)>
    <ComponentModel.DisplayName("不適合区分")>
    Public Property FUTEKIGO_KB As String

    <StringLength(50)>
    <ComponentModel.DisplayName("不適合区分名")>
    Public Property FUTEKIGO_NAME As String

    <StringLength(50)>
    <ComponentModel.DisplayName("不適合詳細区分名")>
    Public Property FUTEKIGO_S_NAME As String

    <StringLength(2)>
    <ComponentModel.DisplayName("不適合詳細区分")>
    Public Property FUTEKIGO_S_KB As String

    <StringLength(2)>
    <ComponentModel.DisplayName("不適合状態区分")>
    Public Property FUTEKIGO_JYOTAI_KB As String

    <StringLength(2)>
    <ComponentModel.DisplayName("不適合状態区分")>
    Public Property FUTEKIGO_JYOTAI_NAME As String

    <StringLength(1)>
    <ComponentModel.DisplayName("事前判定区分")>
    Public Property JIZEN_SINSA_HANTEI_KB As String

    <StringLength(50)>
    <ComponentModel.DisplayName("事前判定区分名")>
    Public Property JIZEN_SINSA_HANTEI_NAME As String

    <StringLength(1)>
    <ComponentModel.DisplayName("是正処置要否区分")>
    Public Property ZESEI_SYOCHI_YOHI_KB As String

    <StringLength(150)>
    <ComponentModel.DisplayName("是正処置要否区分名")>
    Public Property ZESEI_SYOCHI_YOHI_NAME As String

    <StringLength(1)>
    <ComponentModel.DisplayName("再審委員会判定区分")>
    Public Property SAISIN_IINKAI_HANTEI_KB As String

    <StringLength(50)>
    <ComponentModel.DisplayName("再審委員会判定区分名")>
    Public Property SAISIN_IINKAI_HANTEI_NAME As String

    <StringLength(1)>
    <ComponentModel.DisplayName("検査結果区分")>
    Public Property KENSA_KEKKA_KB As String

    <StringLength(50)>
    <ComponentModel.DisplayName("検査結果区分名")>
    Public Property KENSA_KEKKA_NAME As String

    <StringLength(1)>
    <ComponentModel.DisplayName("根本要因区分1")>
    Public Property KONPON_YOIN_KB1 As String

    <StringLength(50)>
    <ComponentModel.DisplayName("根本要因区分名1")>
    Public Property KONPON_YOIN_NAME1 As String

    <StringLength(1)>
    <ComponentModel.DisplayName("根本要因区分2")>
    Public Property KONPON_YOIN_KB2 As String

    <StringLength(50)>
    <ComponentModel.DisplayName("根本要因区分名2")>
    Public Property KONPON_YOIN_NAME2 As String

    <StringLength(1)>
    <ComponentModel.DisplayName("帰責工程区分")>
    Public Property KISEKI_KOTEI_KB As String

    <StringLength(50)>
    <ComponentModel.DisplayName("帰責工程区分名")>
    Public Property KISEKI_KOTEI_NAME As String

    <ComponentModel.DisplayName("起草日")>
    <Display(AutoGenerateField:=False)>
    <Column(NameOf(KISO_YMD), TypeName:="String")>
    Public Property _KISO_YMD As String

    <NotMapped>
    <ComponentModel.DisplayName("起草日")>
    Public Property KISO_YMD As Date
        Get
            Return DateTime.ParseExact(_KISO_YMD, "yyyyMMdd", Nothing)
        End Get
        Set(value As Date)

            _KISO_YMD = value.ToString("yyyyMMdd")
        End Set
    End Property

    <ComponentModel.DisplayName("起草担当者ID")>
    Public Property KISO_TANTO_ID As Integer

    <StringLength(30)>
    <ComponentModel.DisplayName("起草担当者名")>
    Public Property KISO_TANTO_NAME As String

    <StringLength(1)>
    <ComponentModel.DisplayName("クローズフラグ")>
    Public Property CLOSE_FG As String

    <ComponentModel.DisplayName("差戻元承認順")>
    Public Property SASIMOTO_SYONIN_JUN As Integer

    <StringLength(50)>
    <ComponentModel.DisplayName("差戻元承認内容")>
    Public Property SASIMOTO_SYONIN_NAIYO As String

    <StringLength(100)>
    <ComponentModel.DisplayName("差戻理由")>
    Public Property RIYU As String

    <StringLength(500)>
    <ComponentModel.DisplayName("要求内容")>
    Public Property YOKYU_NAIYO As String

    <StringLength(1)>
    <ComponentModel.DisplayName("部門区分")>
    Public Property BUMON_KB As String

    <StringLength(50)>
    <ComponentModel.DisplayName("部門区分")>
    Public Property BUMON_NAME As String

    <StringLength(2)>
    <ComponentModel.DisplayName("顧客判定指示区分")>
    Public Property KOKYAKU_HANTEI_SIJI_KB As String

    <StringLength(150)>
    <ComponentModel.DisplayName("顧客判定指示区分名")>
    Public Property KOKYAKU_HANTEI_SIJI_NAME As String

    <StringLength(2)>
    <ComponentModel.DisplayName("顧客最終判定区分")>
    Public Property KOKYAKU_SAISYU_HANTEI_KB As String

    <StringLength(150)>
    <ComponentModel.DisplayName("顧客最終判定区分名")>
    Public Property KOKYAKU_SAISYU_HANTEI_NAME As String

    <StringLength(14)>
    <ComponentModel.DisplayName("削除日時")>
    Public Property DEL_YMDHNS As String

    <Display(AutoGenerateField:=False)>
    <StringLength(8)>
    <Column(NameOf(HASSEI_YMD), TypeName:="String")>
    <ComponentModel.DisplayName("発生日")>
    Public Property _HASSEI_YMD As String

    <NotMapped>
    <ComponentModel.DisplayName("発生日")>
    Public Property HASSEI_YMD As DateTime
        Get
            Return DateTime.ParseExact(_HASSEI_YMD, "yyyyMMdd", Nothing)
        End Get
        Set(value As Date)

            _HASSEI_YMD = value.ToString("yyyyMMdd")
        End Set
    End Property
End Class
