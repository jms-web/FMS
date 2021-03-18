Imports System
Imports System.Collections.Generic
Imports System.ComponentModel.DataAnnotations
Imports System.ComponentModel.DataAnnotations.Schema
Imports System.Data.Entity.Spatial

''' <summary>
'''
''' </summary>
Partial Public Class ST04_FCCB_ICHIRAN
    Inherits MODEL.ModelBase

    <StringLength(1)>
    <ComponentModel.DisplayName("製品区分")>
    Public Property BUMON_KB As String

    <StringLength(50)>
    <ComponentModel.DisplayName("製品区分")>
    Public Property BUMON_NAME As String

    <StringLength(10)>
    <ComponentModel.DisplayName("報告書No")>
    Public Property FCCB_NO As String

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
    <ComponentModel.DisplayName("最終更新者")>
    Public Property GEN_TANTO_NAME As String

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
    Public Property KISYU_NAME As String '機種名

    <StringLength(60)>
    <ComponentModel.DisplayName("部品番号")>
    Public Property BUHIN_BANGO As String

    <StringLength(10)>
    <ComponentModel.DisplayName("社内コード")>
    Public Property SYANAI_CD As String

    <StringLength(100)>
    <ComponentModel.DisplayName("部品名")>
    Public Property BUHIN_NAME As String '部品名

    <StringLength(100)>
    <ComponentModel.DisplayName("文書番号")>
    Public Property SNO_APPLY_PERIOD_KISO As String '部品名

    <StringLength(100)>
    <ComponentModel.DisplayName("文書番号")>
    Public Property INPUT_DOC_NO As String '部品名

    <StringLength(100)>
    <ComponentModel.DisplayName("内容")>
    Public Property INPUT_NAIYO As String '部品名

    <StringLength(100)>
    <ComponentModel.DisplayName("FCCB議長")>
    Public Property CM_TANTO_NAME As String '部品名

    <ComponentModel.DisplayName("起草日")>
    Public Property KISO_YMD As String

    '<NotMapped>
    '<ComponentModel.DisplayName("起草日")>
    'Public Property KISO_YMD As Date
    '    Get
    '        Return DateTime.ParseExact(_KISO_YMD, "yyyyMMdd", Nothing)
    '    End Get
    '    Set(value As Date)

    '        _KISO_YMD = value.ToString("yyyyMMdd")
    '    End Set
    'End Property

    <ComponentModel.DisplayName("起草担当者ID")>
    Public Property KISO_TANTO_ID As Integer

    <StringLength(30)>
    <ComponentModel.DisplayName("起草担当者名")>
    Public Property KISO_TANTO_NAME As String

    <StringLength(1)>
    <ComponentModel.DisplayName("クローズフラグ")>
    Public Property CLOSE_FG As String

    <StringLength(14)>
    <ComponentModel.DisplayName("削除日時")>
    Public Property DEL_YMDHNS As String

End Class