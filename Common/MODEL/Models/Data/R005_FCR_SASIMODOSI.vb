Imports System
Imports System.ComponentModel
Imports System.ComponentModel.DataAnnotations
Imports System.ComponentModel.DataAnnotations.Schema
Imports PropertyChanged

''' <summary>
''' R005 不適合封じ込め調査書履歴
''' </summary>
<Table(NameOf(R005_FCR_SASIMODOSI), Schema:="dbo")>
<AddINotifyPropertyChangedInterface>
Partial Public Class R005_FCR_SASIMODOSI
    Inherits ModelBase

    Public Shadows Sub Clear()
        SASIMODOSI_YMDHNS = ""
        HOKOKU_NO = ""

        CLOSE_FG = False

    End Sub

    <StringLength(14)>
    Public Property SASIMODOSI_YMDHNS As String

    ''' <summary>
    ''' 報告書No
    ''' </summary>
    ''' <returns></returns>
    <Key>
    <Column(Order:=0, TypeName:="char")>
    <StringLength(10)>
    Public Property HOKOKU_NO As String

    ''' <summary>
    ''' クローズフラグ
    ''' </summary>
    ''' <returns></returns>
    <Required>
    <StringLength(1)>
    <Column(NameOf(CLOSE_FG), TypeName:="char")>
    <Display(AutoGenerateField:=False)>
    Public Property _CLOSE_FG As String

    ''' <summary>
    ''' クローズフラグ
    ''' </summary>
    ''' <returns></returns>
    <Display(AutoGenerateField:=False)>
    <NotMapped>
    <DoNotNotify>
    Public Property CLOSE_FG As Boolean
        Get
            Return (_CLOSE_FG = "1")
        End Get
        Set(value As Boolean)
            _CLOSE_FG = If(value, "1", "0")

        End Set
    End Property

    <Required>
    <Column(NameOf(KOKYAKU_EIKYO_HANTEI_KB), TypeName:="char")>
    <StringLength(1)>
    <Display(AutoGenerateField:=False)>
    Public Property _KOKYAKU_EIKYO_HANTEI_KB As String

    ''' <summary>
    ''' 1-1 判定
    ''' </summary>
    ''' <returns></returns>
    <NotMapped>
    Public Property KOKYAKU_EIKYO_HANTEI_KB As Boolean
        Get
            Return (_KOKYAKU_EIKYO_HANTEI_KB = "1")
        End Get
        Set(value As Boolean)
            _KOKYAKU_EIKYO_HANTEI_KB = If(value, "1", "0")
            'OnPropertyChanged(NameOf(CLOSE_FG))
        End Set
    End Property

    ''' <summary>
    ''' 対象顧客
    ''' </summary>
    ''' <returns></returns>
    <Required>
    <Column(TypeName:="nvarchar")>
    <StringLength(50)>
    Public Property TAISYOU_KOKYAKU As String

    ''' <summary>
    ''' 顧客影響判定コメント
    ''' </summary>
    ''' <returns></returns>
    <Required>
    <Column(TypeName:="nvarchar")>
    <StringLength(200)>
    Public Property KOKYAKU_EIKYO_HANTEI_COMMENT As String

    ''' <summary>
    ''' 1-2-a 不適合確認手段
    ''' </summary>
    ''' <returns></returns>
    <Required>
    <Column(TypeName:="nvarchar")>
    <StringLength(100)>
    Public Property KOKYAKU_EIKYO_NAIYO As String

    ''' <summary>
    ''' 1-2-b 不適合確認手段
    ''' </summary>
    ''' <returns></returns>
    <Required>
    <Column(TypeName:="nvarchar")>
    <StringLength(100)>
    Public Property KAKUNIN_SYUDAN As String

    <Required>
    <Column(NameOf(KOKYAKU_EIKYO_TUCHI_HANTEI_KB), TypeName:="char")>
    <StringLength(1)>
    <Display(AutoGenerateField:=False)>
    Public Property _KOKYAKU_EIKYO_TUCHI_HANTEI_KB As String

    ''' <summary>
    ''' 1-2-b 顧客影響通知判定
    ''' </summary>
    ''' <returns></returns>
    <NotMapped>
    Public Property KOKYAKU_EIKYO_TUCHI_HANTEI_KB As Boolean
        Get
            Return (_KOKYAKU_EIKYO_TUCHI_HANTEI_KB = "1")
        End Get
        Set(value As Boolean)
            _KOKYAKU_EIKYO_TUCHI_HANTEI_KB = If(value, "1", "0")
        End Set
    End Property

    ''' <summary>
    ''' 1-2-c 通知時期
    ''' </summary>
    ''' <returns></returns>
    <Required>
    <StringLength(8)>
    <Column(TypeName:="char")>
    Public Property TUCHI_YMD As String

    ''' <summary>
    ''' 1-2-c 通知手段
    ''' </summary>
    ''' <returns></returns>
    <Required>
    <StringLength(100)>
    <Column(TypeName:="nvarchar")>
    Public Property TUCHI_SYUDAN As String

    ''' <summary>
    ''' 1-2-c 必要手続き事項
    ''' </summary>
    ''' <returns></returns>
    <Required>
    <StringLength(200)>
    <Column(TypeName:="nvarchar")>
    Public Property HITUYO_TETUDUKI_ZIKO As String

    ''' <summary>
    ''' 1-2-d 引取・修理・代品納入の要否
    ''' </summary>
    ''' <returns></returns>
    <Required>
    <StringLength(200)>
    <Column(TypeName:="nvarchar")>
    Public Property KOKYAKU_EIKYO_ETC_COMMENT As String

    <Required>
    <Column(NameOf(OTHER_PROCESS_INFLUENCE_KB), TypeName:="char")>
    <StringLength(1)>
    <Display(AutoGenerateField:=False)>
    Public Property _OTHER_PROCESS_INFLUENCE_KB As String

    ''' <summary>
    ''' 4-1 他のプロセスへの影響
    ''' </summary>
    ''' <returns></returns>
    <NotMapped>
    Public Property OTHER_PROCESS_INFLUENCE_KB As Boolean
        Get
            Return (_OTHER_PROCESS_INFLUENCE_KB = "1")
        End Get
        Set(value As Boolean)
            _OTHER_PROCESS_INFLUENCE_KB = If(value, "1", "0")
        End Set
    End Property

    <Required>
    <Column(NameOf(FOLLOW_PROCESS_OUTFLOW_KB), TypeName:="char")>
    <StringLength(1)>
    <Display(AutoGenerateField:=False)>
    Public Property _FOLLOW_PROCESS_OUTFLOW_KB As String

    ''' <summary>
    ''' 4-2 後続プロセスへの流出
    ''' </summary>
    ''' <returns></returns>
    <NotMapped>
    Public Property FOLLOW_PROCESS_OUTFLOW_KB As Boolean
        Get
            Return (_FOLLOW_PROCESS_OUTFLOW_KB = "1")
        End Get
        Set(value As Boolean)
            _FOLLOW_PROCESS_OUTFLOW_KB = If(value, "1", "0")
        End Set
    End Property

    ''' <summary>
    ''' 5-1 顧客納入済品 実施内容
    ''' </summary>
    ''' <returns></returns>
    <Required>
    <StringLength(50)>
    <Column(TypeName:="nvarchar")>
    Public Property KOKYAKU_NOUNYU_NAIYOU As String

    ''' 5-1 顧客納入済品 実施日
    ''' </summary>
    ''' <returns></returns>
    <Required>
    <StringLength(8)>
    <Column(TypeName:="char")>
    Public Property KOKYAKU_NOUNYU_YMD As String

    ''' <summary>
    ''' 5-2 在庫品・仕掛品 内容
    ''' </summary>
    ''' <returns></returns>
    <Required>
    <StringLength(50)>
    <Column(TypeName:="nvarchar")>
    Public Property ZAIKO_SIKAKE_NAIYOU As String

    ''' 5-2 在庫品・仕掛品 日付
    ''' </summary>
    ''' <returns></returns>
    <Required>
    <StringLength(8)>
    <Column(TypeName:="char")>
    Public Property ZAIKO_SIKAKE_YMD As String

    ''' <summary>
    ''' 5-3 他のプロセス 内容
    ''' </summary>
    ''' <returns></returns>
    <Required>
    <StringLength(50)>
    <Column(TypeName:="nvarchar")>
    Public Property OTHER_PROCESS_NAIYOU As String

    ''' 5-2 他のプロセス 日付
    ''' </summary>
    ''' <returns></returns>
    <Required>
    <StringLength(8)>
    <Column(TypeName:="char")>
    Public Property OTHER_PROCESS_YMD As String


    '#252 追加項目

    ''' <summary>
    ''' 
    ''' </summary>
    ''' <returns></returns>
    <Required>
    <StringLength(100)>
    <Column(TypeName:="nvarchar")>
    Public Property KOKYAKU_EIKYO_HANTEI_FILEPATH As String

    ''' <summary>
    ''' 
    ''' </summary>
    ''' <returns></returns>
    <Required>
    <StringLength(100)>
    <Column(TypeName:="nvarchar")>
    Public Property FUTEKIGO_SEIHIN_MEMO As String

    ''' <summary>
    ''' 
    ''' </summary>
    ''' <returns></returns>
    <Required>
    <StringLength(100)>
    <Column(TypeName:="nvarchar")>
    Public Property KOKYAKU_EIKYO_MEMO As String

    ''' <summary>
    ''' 
    ''' </summary>
    ''' <returns></returns>
    <Required>
    <StringLength(100)>
    <Column(TypeName:="nvarchar")>
    Public Property OTHER_PROCESS_INFLUENCE_MEMO As String

    ''' <summary>
    ''' 
    ''' </summary>
    ''' <returns></returns>
    <Required>
    <StringLength(100)>
    <Column(TypeName:="nvarchar")>
    Public Property OTHER_PROCESS_INFLUENCE_FILEPATH As String

    ''' <summary>
    ''' 
    ''' </summary>
    ''' <returns></returns>
    <Required>
    <StringLength(100)>
    <Column(TypeName:="nvarchar")>
    Public Property FOLLOW_PROCESS_OUTFLOW_MEMO As String

    ''' <summary>
    ''' 
    ''' </summary>
    ''' <returns></returns>
    <Required>
    <StringLength(100)>
    <Column(TypeName:="nvarchar")>
    Public Property FOLLOW_PROCESS_OUTFLOW_FILEPATH As String


    ''' <summary>
    ''' 
    ''' </summary>
    ''' <returns></returns>
    <Required>
    <StringLength(100)>
    <Column(TypeName:="nvarchar")>
    Public Property FUTEKIGO_SEIHIN_FILEPATH As String


    ''' <summary>
    ''' 
    ''' </summary>
    ''' <returns></returns>
    <Required>
    <StringLength(100)>
    <Column(TypeName:="nvarchar")>
    Public Property KOKYAKU_EIKYO_FILEPATH As String


    ''' <summary>
    ''' 
    ''' </summary>
    ''' <returns></returns>
    <Required>
    <StringLength(100)>
    <Column(TypeName:="nvarchar")>
    Public Property SYOCHI_MEMO As String


    ''' <summary>
    ''' 
    ''' </summary>
    ''' <returns></returns>
    <Required>
    <StringLength(100)>
    <Column(TypeName:="nvarchar")>
    Public Property SYOCHI_FILEPATH As String
End Class