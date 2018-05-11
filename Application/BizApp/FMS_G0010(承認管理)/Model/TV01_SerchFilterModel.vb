﻿Imports PropertyChanged

''' <summary>
''' 一覧検索ストアドパラメータ
''' </summary>
<AddINotifyPropertyChangedInterface>
Public Class TV01_ParamModel
    Inherits MODEL.NotifyChangedBase

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
    Public Property FUTEKIGO_S_KB As String
    Public Property FUTEKIGO_JYOTAI_KB As String

    Public _VISIBLE_CLOSE As String
    <DoNotNotify>
    Public Property VISIBLE_CLOSE As Boolean
        Get
            Return IIf(_VISIBLE_CLOSE = "0", False, True)
        End Get
        Set(value As Boolean)
            _VISIBLE_CLOSE = IIf(value, "1", "0")
            OnPropertyChanged(NameOf(VISIBLE_CLOSE))
        End Set
    End Property

    Public _VISIBLE_TAIRYU As String
    <DoNotNotify>
    Public Property VISIBLE_TAIRYU As Boolean
        Get
            Return IIf(_VISIBLE_TAIRYU = "0", False, True)
        End Get
        Set(value As Boolean)
            _VISIBLE_TAIRYU = IIf(value, "1", "0")
            OnPropertyChanged(NameOf(VISIBLE_TAIRYU))
        End Set
    End Property

    'NCR
    Public Property JIZEN_SINSA_HANTEI_KB As String
    Public Property ZESEI_SYOCHI_YOHI_KB As String
    Public Property SAISIN_IINKAI_HANTEI_KB As String
    Public Property KOKYAKU_HANTEI_SIJI_KB As String
    Public Property KOKYAKU_SAISYU_HANTEI_KB As String
    Public Property KENSA_KEKKA_KB As String

    'CAR
    Public Property GENIN1 As String
    Public Property GENIN2 As String
    Public Property KISEKI_KOTEI_KB As String

End Class
