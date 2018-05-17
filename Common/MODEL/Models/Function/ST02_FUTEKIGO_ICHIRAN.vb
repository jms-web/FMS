Imports System
Imports System.Collections.Generic
Imports System.ComponentModel.DataAnnotations
Imports System.ComponentModel.DataAnnotations.Schema
Imports System.Data.Entity.Spatial

''' <summary>
''' ST02 不適合報告書一覧 テーブル値関数
''' </summary>
Partial Public Class ST02_FUTEKIGO_ICHIRAN

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
    <Display(AutoGenerateField:=False)>
    Public Property SYONIN_HOKOKUSYO_ID As Integer

    <StringLength(50)>
    <ComponentModel.DisplayName("報告書名")>
    Public Property SYONIN_HOKOKUSYO_NAME As String '報告書名

    <StringLength(10)>
    <ComponentModel.DisplayName("種類略名")>
    Public Property SYONIN_HOKOKUSYO_R_NAME As String '報告書略名

    <ComponentModel.DisplayName("処置担当者社員ID")>
    <Display(AutoGenerateField:=False)>
    Public Property GEN_TANTO_ID As Integer

    <StringLength(30)>
    <ComponentModel.DisplayName("処置担当者名")>
    Public Property GEN_TANTO_NAME As String

    <StringLength(14)>
    <ComponentModel.DisplayName("承認日時")>
    Public Property SYONIN_YMDHNS As String

    <ComponentModel.DisplayName("滞留日数")>
    Public Property TAIRYU_NISSU As Integer

    <StringLength(1)>
    <ComponentModel.DisplayName("滞留フラグ")>
    Public Property TAIRYU_FG As String

    <ComponentModel.DisplayName("機種ID")>
    <Display(AutoGenerateField:=False)>
    Public Property KISYU_ID As Integer

    <StringLength(100)>
    <ComponentModel.DisplayName("機種")>
    Public Property KISYU As String

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
    Public Property JIZEN_SINSA_HANTEI_KB_NAME As String

    <StringLength(1)>
    <ComponentModel.DisplayName("是正処置要否区分")>
    Public Property ZESEI_SYOCHI_YOHI_KB As String

    <StringLength(150)>
    <ComponentModel.DisplayName("是正処置要否区分名")>
    Public Property ZESEI_SYOCHI_YOHI_KB_NAME As String






    <StringLength(1)>
    <ComponentModel.DisplayName("再審判定区分")>
    Public Property SAISIN_IINKAI_HANTEI_KB As String

    <StringLength(50)>
    <ComponentModel.DisplayName("再審判定区分")>
    Public Property SAISIN_IINKAI_HANTEI_KB_DISP As String

    <ComponentModel.DisplayName("起草日")>
    <Display(AutoGenerateField:=False)>
    <Column(NameOf(ADD_YMD), Order:=19, TypeName:="String")>
    Public Property _ADD_YMD As String

    <NotMapped>
    <ComponentModel.DisplayName("起草日")>
    Public Property ADD_YMD As Date
        Get
            Return DateTime.ParseExact(_ADD_YMD, "yyyyMMdd", Nothing)
        End Get
        Set(value As Date)

            _ADD_YMD = value.ToString("yyyyMMdd")
        End Set
    End Property

    <StringLength(1)>
    <ComponentModel.DisplayName("クローズフラグ")>
    Public Property CLOSE_FG As String

    <StringLength(8)>
    <ComponentModel.DisplayName("前処置実施日")>
    <Display(AutoGenerateField:=False)>
    Public Property _SYOCHI_YMD As String

    <NotMapped>
    <ComponentModel.DisplayName("前処置実施日")>
    Public Property SYOCHI_YMD As Date
        Get
            Return DateTime.ParseExact(_SYOCHI_YMD, "yyyyMMdd", Nothing)
        End Get
        Set(value As Date)

            _SYOCHI_YMD = value.ToString("yyyyMMdd")
        End Set
    End Property

    <ComponentModel.DisplayName("差戻元承認順")>
    Public Property MODOSI_SYONIN_JUN As Integer

    <StringLength(50)>
    <ComponentModel.DisplayName("差戻元承認順")>
    Public Property MODOSI_SYONIN_NAIYO As String




End Class
