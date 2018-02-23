Imports System
Imports System.Collections.Generic
Imports System.ComponentModel.DataAnnotations
Imports System.ComponentModel.DataAnnotations.Schema
Imports System.Data.Entity.Spatial

''' <summary>
''' TV01 不適合報告書一覧 テーブル値関数
''' </summary>
Partial Public Class TV01_FUTEKIGO_ICHIRAN

    <Key>
    <Column(Order:=0)>
    <StringLength(10)>
    <ComponentModel.DisplayName("報告書No")>
    Public Property HOKOKUSYO_NO As String

    <Key>
    <Column(Order:=1)>
    <StringLength(1)>
    <Display(AutoGenerateField:=False)>
    <ComponentModel.DisplayName("クローズフラグ")>
    Public Property CLOSE_FLG As String

    <Key>
    <Column(Order:=2)>
    <ComponentModel.DisplayName("承認順")>
    <Display(AutoGenerateField:=False)>
    Public Property SYONIN_JUN As Integer

    <Key>
    <Column(Order:=3)>
    <StringLength(50)>
    <ComponentModel.DisplayName("承認内容名")>
    <Display(AutoGenerateField:=False)>
    Public Property SYONIN_NAIYO As String

    <Key>
    <Column(Order:=4)>
    <ComponentModel.DisplayName("承認報告書ID")>
    <Display(AutoGenerateField:=False)>
    Public Property SYONIN_HOKOKUSYO_ID As Integer

    <Key>
    <Column(Order:=5)>
    <StringLength(50)>
    <ComponentModel.DisplayName("ステージ")>
    Public Property SYONIN_HOKOKUSYO_NAME As String '報告書名

    <Key>
    <Column(Order:=6)>
    <StringLength(10)>
    <ComponentModel.DisplayName("種類略名")>
    Public Property SYONIN_HOKOKUSYO_R_NAME As String '報告書略名

    <Key>
    <Column(Order:=7)>
    <ComponentModel.DisplayName("処置担当者社員ID")>
    <Display(AutoGenerateField:=False)>
    Public Property SYOCHI_SYAIN_ID As Integer

    <Key>
    <Column(Order:=8)>
    <StringLength(30)>
    <ComponentModel.DisplayName("処置担当者名")>
    Public Property SYOCHI_SYAIN_NAME As String

    <Key>
    <Column(Order:=9)>
    <ComponentModel.DisplayName("滞留日数")>
    Public Property TAIRYU As Integer

    <Key>
    <Column(Order:=10)>
    <ComponentModel.DisplayName("機種ID")>
    <Display(AutoGenerateField:=False)>
    Public Property KISYU_ID As Integer

    <Key>
    <Column(Order:=11)>
    <StringLength(100)>
    <ComponentModel.DisplayName("機種")>
    <Display(AutoGenerateField:=False)>
    Public Property KISYU As String

    <Key>
    <Column(Order:=12)>
    <StringLength(100)>
    <ComponentModel.DisplayName("機種")>
    Public Property KISYU_NAME As String '機種名

    <Key>
    <Column(Order:=13)>
    <StringLength(60)>
    <ComponentModel.DisplayName("部品番号")>
    Public Property BUHIN_BANGO As String

    <Key>
    <Column(Order:=14)>
    <StringLength(100)>
    <ComponentModel.DisplayName("品名")>
    Public Property BUHIN_NAME As String '部品名

    <Key>
    <Column(Order:=15)>
    <StringLength(1)>
    <ComponentModel.DisplayName("事前判定区分")>
    <Display(AutoGenerateField:=False)>
    Public Property JIZEN_SINSA_HANTEI_KB As String

    <Key>
    <Column(Order:=16)>
    <StringLength(50)>
    <ComponentModel.DisplayName("事前判定区分")>
    Public Property JIZEN_SINSA_HANTEI_KB_DISP As String

    <Key>
    <Column(Order:=17)>
    <StringLength(1)>
    <ComponentModel.DisplayName("再審判定区分")>
    <Display(AutoGenerateField:=False)>
    Public Property SAISIN_IINKAI_HANTEI_KB As String

    <Key>
    <Column(Order:=18)>
    <StringLength(50)>
    <ComponentModel.DisplayName("再審判定区分")>
    Public Property SAISIN_IINKAI_HANTEI_KB_DISP As String


    <StringLength(8)>
    <NotMapped>
    <ComponentModel.DisplayName("起草日")>
    <Display(AutoGenerateField:=False)>
    Public Property _ADD_YMD As String

    <Key>
    <Column(Order:=19)>
    <ComponentModel.DisplayName("起草日")>
    Public Property ADD_YMD As Date
        Get
            Return DateTime.ParseExact(_ADD_YMD, "yyyyMMdd", Nothing)
        End Get
        Set(value As Date)

            _ADD_YMD = value.ToString("yyyyMMdd")
        End Set
    End Property

    <StringLength(8)>
    <NotMapped>
    <ComponentModel.DisplayName("前処置実施日")>
    <Display(AutoGenerateField:=False)>
    Public Property _SYOCHI_YMD As String

    <Key>
    <Column(Order:=20)>
    <ComponentModel.DisplayName("前処置実施日")>
    Public Property SYOCHI_YMD As Date
        Get
            Return DateTime.ParseExact(_SYOCHI_YMD, "yyyyMMdd", Nothing)
        End Get
        Set(value As Date)

            _SYOCHI_YMD = value.ToString("yyyyMMdd")
        End Set
    End Property


End Class
