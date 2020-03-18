Imports System.ComponentModel.DataAnnotations
Imports System.ComponentModel.DataAnnotations.Schema
Imports PropertyChanged

''' <summary>
''' D007_不適合封じ込め調査書情報
''' </summary>
<Table(NameOf(V011_FCR_J), Schema:="dbo")>
<AddINotifyPropertyChangedInterface>
Partial Public Class V011_FCR_J
    Inherits ModelBase

    Public Shadows Sub Clear()
        HOKOKU_NO = ""
        CLOSE_FG = False
        KOKYAKU_EIKYO_HANTEI_KB = False
        TAISYOU_KOKYAKU = ""
        KOKYAKU_EIKYO_HANTEI_COMMENT = ""
        KOKYAKU_EIKYO_NAIYO = ""
        KAKUNIN_SYUDAN = ""
        KOKYAKU_EIKYO_TUCHI_HANTEI_KB = False
        TUCHI_YMD = ""
        TUCHI_SYUDAN = ""
        HITUYO_TETUDUKI_ZIKO = ""
        KOKYAKU_EIKYO_ETC_COMMENT = ""
        OTHER_PROCESS_INFLUENCE_KB = False
        FOLLOW_PROCESS_OUTFLOW_KB = False
        KOKYAKU_NOUNYU_NAIYOU = ""
        KOKYAKU_NOUNYU_YMD = ""
        ZAIKO_SIKAKE_NAIYOU = ""
        ZAIKO_SIKAKE_YMD = ""
        OTHER_PROCESS_NAIYOU = ""
        OTHER_PROCESS_YMD = ""

        ADD_SYAIN_ID = 0
        ADD_YMDHNS = ""
        UPD_SYAIN_ID = 0
        UPD_YMDHNS = ""
        DEL_SYAIN_ID = 0
        DEL_YMDHNS = ""



    End Sub

    ''' <summary>
    ''' 報告書No
    ''' </summary>
    ''' <returns></returns>
    <Key>
    <Column(Order:=0, TypeName:="char")>
    <StringLength(10)>
    Public Property HOKOKU_NO As String


#Region "NCR情報"
    Public Property BUMON_KB As String
    Public Property BUMON_NAME As String
    Public Property KISYU_ID As Integer
    Public Property KISYU_NAME As String
    Public Property ADD_SYAIN_NAME_NCR As String
    Public Property HASSEI_YMD As String
    Public Property FUTEKIGO_NAME As String
    Public Property FUTEKIGO_S_NAME As String

#End Region

#Region "詳細項目"
    Public Property KISYU_ID1 As Integer
    Public Property KISYU_ID2 As Integer
    Public Property KISYU_ID3 As Integer
    Public Property KISYU_ID4 As Integer
    Public Property KISYU_ID5 As Integer
    Public Property KISYU_ID6 As Integer

    Public Property KISYU1_NAME As String
    Public Property KISYU2_NAME As String
    Public Property KISYU3_NAME As String
    Public Property KISYU4_NAME As String
    Public Property KISYU5_NAME As String
    Public Property KISYU6_NAME As String

    Public Property BUHIN_INFO1 As String
    Public Property BUHIN_INFO2 As String
    Public Property BUHIN_INFO3 As String
    Public Property BUHIN_INFO4 As String
    Public Property BUHIN_INFO5 As String
    Public Property BUHIN_INFO6 As String

    Public Property SURYO1 As Integer
    Public Property SURYO2 As Integer
    Public Property SURYO3 As Integer
    Public Property SURYO4 As Integer
    Public Property SURYO5 As Integer
    Public Property SURYO6 As Integer

    Public Property RANGE_FROM1 As String
    Public Property RANGE_FROM2 As String
    Public Property RANGE_FROM3 As String
    Public Property RANGE_FROM4 As String
    Public Property RANGE_FROM5 As String
    Public Property RANGE_FROM6 As String

    Public Property RANGE_TO1 As String
    Public Property RANGE_TO2 As String
    Public Property RANGE_TO3 As String
    Public Property RANGE_TO4 As String
    Public Property RANGE_TO5 As String
    Public Property RANGE_TO6 As String

#End Region

#Region "承認情報項目"
    'Public Property SYONIN_NAME10 As String
    'Public Property SYONIN_YMD10 As String
    'Public Property SYONIN_NAME20 As String
    'Public Property SYONIN_YMD20 As String
    'Public Property SYONIN_NAME30 As String
    'Public Property SYONIN_YMD30 As String
    'Public Property SYONIN_NAME40 As String
    'Public Property SYONIN_YMD40 As String
    'Public Property SYONIN_NAME50 As String
    'Public Property SYONIN_YMD50 As String
    'Public Property SYONIN_NAME60 As String
    'Public Property SYONIN_YMD60 As String

#End Region


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
    ''' 1-2-b 顧客に与える影響
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


    ''共通項目------------------------------------
    <Required>
    <StringLength(14)>
    <Column(TypeName:="char")>
    Public Property ADD_YMDHNS As String

    <NotMapped>
    <DoNotNotify>
    <Display(AutoGenerateField:=False)>
    Public ReadOnly Property ADD_YMD As String
        Get
            Dim strRET As String
            If ADD_YMDHNS IsNot Nothing AndAlso ADD_YMDHNS.Length = 14 Then
                strRET = DateTime.ParseExact(ADD_YMDHNS, "yyyyMMddHHmmss", Nothing).ToString("yyyy/MM/dd")
            Else
                strRET = ""
            End If
            Return strRET
        End Get
    End Property

    <Required>
    Public Property ADD_SYAIN_ID As Integer
    Public Property ADD_SYAIN_NAME As String

    <Required>
    <StringLength(14)>
    <Column(TypeName:="char")>
    Public Property UPD_YMDHNS As String

    <Required>
    Public Property UPD_SYAIN_ID As Integer
    Public Property UPD_SYAIN_NAME As String

    <Required>
    <StringLength(14)>
    <Column(TypeName:="char")>
    Public Property DEL_YMDHNS As String

    <ComponentModel.DisplayName("削除済")>
    <NotMapped>
    <DoNotNotify>
    <Display(AutoGenerateField:=False)>
    Public ReadOnly Property DEL_FLG As Boolean
        Get
            Return Not String.IsNullOrWhiteSpace(DEL_YMDHNS)
        End Get
    End Property

    <Required>
    Public Property DEL_SYAIN_ID As Integer

End Class