Imports PropertyChanged

''' <summary>
''' 一覧検索ストアドパラメータ
''' </summary>
<AddINotifyPropertyChangedInterface>
Public Class TV01_ParamModel

    '共通
    Public Property BUMON_KB As String
    Public Property HOKOKU_NO As String
    Public Property ADD_TANTO As Integer
    Public Property KISYU_ID As Integer
    Public Property GOUKI As String
    Public Property SYANAI_CD As String
    Public Property BUHIN_BANGO As String
    Public Property BUHIN_NAME As String
    Public Property SYOCHI_TANTO As String
    Public Property JISI_YMD_FROM As String
    Public Property JISI_YMD_TO As String
    Public Property FUTEKIGO_KB As String
    Public Property FUKEKIGO_S_KB As String
    Public Property FUTEKIGO_JYOTAI_KB As String
    Public Property VISIBLE_CLOSE As String
    Public Property VISIBLE_TAIRYU As String

    'NCR
    Public Property JIZEN_SINSA_HANTEI_KB As String
    Public Property ZESEI_SYOCHI_YOHI_KB As String
    Public Property SAISIN_IINKAI_HANTEI_KB As String
    Public Property KOKYAKU_HANTEI_SIJI_KB As String
    Public Property KOKYAKU_SAISYU_HANTEI_KB As String
    Public Property KENSA_KEKKA_KB As String

    'CAR
    Public Property YOIN1 As String
    Public Property YOIN2 As String
    Public Property TANTO_SAGYO As String
    Public Property KISEKI_KOTEI_KB As String

End Class
