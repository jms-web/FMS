Imports System
Imports System.Collections.Generic
Imports System.ComponentModel
Imports System.ComponentModel.DataAnnotations
Imports System.ComponentModel.DataAnnotations.Schema
Imports System.Data.Entity.Spatial

''' <summary>
''' D003_不適合製品処置報告書情報
''' </summary>
<Table(NameOf(D003_NCR_J), Schema:="dbo")>
Partial Public Class D003_NCR_J
    Inherits NotifyChangedBase

    Dim _HOKOKU_NO As String
    <Key>
    <Column(Order:=0, TypeName:="char")>
    <StringLength(10)>
    <ComponentModel.DisplayName("報告書No")>
    Public Property HOKOKU_NO As String
        Get
            Return _HOKOKU_NO
        End Get
        Set(value As String)
            _HOKOKU_NO = value
            OnPropertyChanged(NameOf(HOKOKU_NO))
        End Set
    End Property

    Dim _BUMON_KB As String
    <Required>
    <Column(TypeName:="char")>
    <StringLength(1)>
    <ComponentModel.DisplayName("部門区分")>
    Public Property BUMON_KB As String
        Get
            Return _BUMON_KB
        End Get
        Set(value As String)
            _BUMON_KB = value
            OnPropertyChanged(NameOf(BUMON_KB))
        End Set
    End Property

    <Required>
    <StringLength(1)>
    <Column(NameOf(CLOSE_FLG), TypeName:="char")>
    <ComponentModel.DisplayName("クローズフラグ")>
    Public Property _CLOSE_FLG As String

    <ComponentModel.DisplayName("クローズフラグ")>
    <NotMapped>
    Public Property CLOSE_FLG As Boolean
        Get
            Return IIf(_CLOSE_FLG = "0", False, True)
        End Get
        Set(value As Boolean)
            _CLOSE_FLG = IIf(value, "1", "0")
            OnPropertyChanged(NameOf(CLOSE_FLG))
        End Set
    End Property

    Dim _KISYU_ID As Integer
    <Required>
    <ComponentModel.DisplayName("機種ID")>
    Public Property KISYU_ID As Integer
        Get
            Return _KISYU_ID
        End Get
        Set(value As Integer)
            _KISYU_ID = value
            OnPropertyChanged(NameOf(KISYU_ID))
        End Set
    End Property

    Dim _SYANAI_CD As String
    <Required>
    <Column(TypeName:="varchar")>
    <StringLength(10)>
    <ComponentModel.DisplayName("社内コード")>
    Public Property SYANAI_CD As String
        Get
            Return _SYANAI_CD
        End Get
        Set(value As String)
            _SYANAI_CD = value
            OnPropertyChanged(NameOf(SYANAI_CD))
        End Set
    End Property

    Dim _BUHIN_BANGO As String
    <Required>
    <Column(TypeName:="varchar")>
    <StringLength(60)>
    <ComponentModel.DisplayName("部品番号")>
    Public Property BUHIN_BANGO As String
        Get
            Return _BUHIN_BANGO
        End Get
        Set(value As String)
            _BUHIN_BANGO = value
            OnPropertyChanged(NameOf(BUHIN_BANGO))
        End Set
    End Property

    Dim _BUHIN_BAME As String
    <Required>
    <Column(TypeName:="nvarchar")>
    <StringLength(1)>
    <ComponentModel.DisplayName("部品名称")>
    Public Property BUHIN_BAME As String
        Get
            Return _BUHIN_BAME
        End Get
        Set(value As String)
            _BUHIN_BAME = value
            OnPropertyChanged(NameOf(BUHIN_BAME))
        End Set
    End Property

    Dim _GOKI As String
    <Required>
    <Column(TypeName:="char")>
    <StringLength(5)>
    <ComponentModel.DisplayName("号機")>
    Public Property GOKI As String
        Get
            Return _GOKI
        End Get
        Set(value As String)
            _GOKI = value
            OnPropertyChanged(NameOf(GOKI))
        End Set
    End Property

    Dim _SURYO As Integer
    <Required>
    <ComponentModel.DisplayName("数量")>
    Public Property SURYO As Integer
        Get
            Return _SURYO
        End Get
        Set(value As Integer)
            _SURYO = value
            OnPropertyChanged(NameOf(SURYO))
        End Set
    End Property

    <Required>
    <Column("SAIHATU", TypeName:="char")>
    <StringLength(1)>
    <ComponentModel.DisplayName("再発")>
    Public Property _SAIHATU As String

    <ComponentModel.DisplayName("再発")>
    <NotMapped>
    Public Property SAIHATU As Boolean
        Get
            Return IIf(_SAIHATU = "0", False, True)
        End Get
        Set(value As Boolean)
            _SAIHATU = IIf(value, "1", "0")
            OnPropertyChanged(NameOf(SAIHATU))
        End Set
    End Property


    Dim _FUTEKIGO_JYOTAI_KB As String
    <Required>
    <Column(TypeName:="char")>
    <StringLength(1)>
    <ComponentModel.DisplayName("不適合状態区分")>
    Public Property FUTEKIGO_JYOTAI_KB As String
        Get
            Return _FUTEKIGO_JYOTAI_KB
        End Get
        Set(value As String)
            _FUTEKIGO_JYOTAI_KB = value
            OnPropertyChanged(NameOf(FUTEKIGO_JYOTAI_KB))
        End Set
    End Property

    Dim _FUTEKIGO_NAIYO As String
    <Required>
    <Column(TypeName:="nvarchar")>
    <StringLength(30)>
    <ComponentModel.DisplayName("不適合状態内容")>
    Public Property FUTEKIGO_NAIYO As String
        Get
            Return _FUTEKIGO_NAIYO
        End Get
        Set(value As String)
            _FUTEKIGO_NAIYO = value
            OnPropertyChanged(NameOf(FUTEKIGO_NAIYO))
        End Set
    End Property

    Dim _FUTEKIGO_KB As String
    <Required>
    <Column(TypeName:="char")>
    <StringLength(1)>
    <ComponentModel.DisplayName("不適合区分")>
    Public Property FUTEKIGO_KB As String
        Get
            Return _FUTEKIGO_KB
        End Get
        Set(value As String)
            _FUTEKIGO_KB = value
            OnPropertyChanged(NameOf(FUTEKIGO_KB))
        End Set
    End Property

    Dim _FUTEKIGO_S_KB As String
    <Required>
    <Column(TypeName:="varchar")>
    <StringLength(2)>
    <ComponentModel.DisplayName("不適合詳細区分")>
    Public Property FUTEKIGO_S_KB As String
        Get
            Return _FUTEKIGO_S_KB
        End Get
        Set(value As String)
            _FUTEKIGO_S_KB = value
            OnPropertyChanged(NameOf(FUTEKIGO_S_KB))
        End Set
    End Property

    Dim _ZUMEN_KIKAKU As String
    <Required>
    <Column(TypeName:="nvarchar")>
    <StringLength(30)>
    <ComponentModel.DisplayName("図面規格")>
    Public Property ZUMEN_KIKAKU As String
        Get
            Return _ZUMEN_KIKAKU
        End Get
        Set(value As String)
            _ZUMEN_KIKAKU = value
            OnPropertyChanged(NameOf(ZUMEN_KIKAKU))
        End Set
    End Property

    Dim _YOKYU_NAIYO As String
    <Required>
    <Column(TypeName:="nvarchar")>
    <StringLength(500)>
    <ComponentModel.DisplayName("要求内容")>
    Public Property YOKYU_NAIYO As String
        Get
            Return _YOKYU_NAIYO
        End Get
        Set(value As String)
            _YOKYU_NAIYO = value
            OnPropertyChanged(NameOf(YOKYU_NAIYO))
        End Set
    End Property

    Dim _KANSATU_KEKKA As String
    <Required>
    <Column(TypeName:="nvarchar")>
    <StringLength(500)>
    <ComponentModel.DisplayName("観察結果")>
    Public Property KANSATU_KEKKA As String
        Get
            Return _KANSATU_KEKKA
        End Get
        Set(value As String)
            _KANSATU_KEKKA = value
            OnPropertyChanged(NameOf(KANSATU_KEKKA))
        End Set
    End Property


    <Required>
    <Column(NameOf(ZESEI_SYOCHI_YOHI_KB), TypeName:="char")>
    <StringLength(1)>
    <ComponentModel.DisplayName("是正処置要否区分")>
    Public Property _ZESEI_SYOCHI_YOHI_KB As String

    <ComponentModel.DisplayName("是正処置要否区分")>
    <NotMapped>
    Public Property ZESEI_SYOCHI_YOHI_KB As Boolean
        Get
            Return IIf(_ZESEI_SYOCHI_YOHI_KB = "0", False, True)
        End Get
        Set(value As Boolean)
            _ZESEI_SYOCHI_YOHI_KB = IIf(value, "1", "0")
            OnPropertyChanged(NameOf(_ZESEI_SYOCHI_YOHI_KB))
        End Set
    End Property

    Dim _ZESEI_NASI_RIYU As String
    <Required>
    <Column(TypeName:="nvarchar")>
    <StringLength(100)>
    <ComponentModel.DisplayName("是正処置無理由")>
    Public Property ZESEI_NASI_RIYU As String
        Get
            Return _ZESEI_NASI_RIYU
        End Get
        Set(value As String)
            _ZESEI_NASI_RIYU = value
            OnPropertyChanged(NameOf(ZESEI_NASI_RIYU))
        End Set
    End Property

    Dim _JIZEN_SINSA_HANTEI_KB As String
    <Required>
    <Column(TypeName:="char")>
    <StringLength(1)>
    <ComponentModel.DisplayName("事前審査判定区分")>
    Public Property JIZEN_SINSA_HANTEI_KB As String
        Get
            Return _JIZEN_SINSA_HANTEI_KB
        End Get
        Set(value As String)
            _JIZEN_SINSA_HANTEI_KB = value
            OnPropertyChanged(NameOf(JIZEN_SINSA_HANTEI_KB))
        End Set
    End Property

    Dim _JIZEN_SINSA_SYAIN_ID As Integer
    <Required>
    <ComponentModel.DisplayName("事前審査社員ID")>
    Public Property JIZEN_SINSA_SYAIN_ID As Integer
        Get
            Return _JIZEN_SINSA_SYAIN_ID
        End Get
        Set(value As Integer)
            _JIZEN_SINSA_SYAIN_ID = value
            OnPropertyChanged(NameOf(JIZEN_SINSA_SYAIN_ID))
        End Set
    End Property

    Dim _JIZEN_SINSA_YMD As String
    <Required>
    <Column(TypeName:="char")>
    <StringLength(8)>
    <ComponentModel.DisplayName("事前審査日")>
    Public Property JIZEN_SINSA_YMD As String
        Get
            Return _JIZEN_SINSA_YMD
        End Get
        Set(value As String)
            _JIZEN_SINSA_YMD = value
            OnPropertyChanged(NameOf(JIZEN_SINSA_YMD))
        End Set
    End Property

    Dim _SAISIN_KAKUNIN_SYAIN_ID As Integer
    <Required>
    <ComponentModel.DisplayName("再審委員確認社員ID")>
    Public Property SAISIN_KAKUNIN_SYAIN_ID As Integer
        Get
            Return _SAISIN_KAKUNIN_SYAIN_ID
        End Get
        Set(value As Integer)
            _SAISIN_KAKUNIN_SYAIN_ID = value
            OnPropertyChanged(NameOf(SAISIN_KAKUNIN_SYAIN_ID))
        End Set
    End Property

    Dim _SAISIN_KAKUNIN_YMD As String
    <Required>
    <Column(TypeName:="char")>
    <StringLength(8)>
    <ComponentModel.DisplayName("再審委員確認日")>
    Public Property SAISIN_KAKUNIN_YMD As String
        Get
            Return _SAISIN_KAKUNIN_YMD
        End Get
        Set(value As String)
            _SAISIN_KAKUNIN_YMD = value
            OnPropertyChanged(NameOf(SAISIN_KAKUNIN_YMD))
        End Set
    End Property

    Dim _SAISIN_IINKAI_HANTEI_KB As String
    <Required>
    <Column(TypeName:="char")>
    <StringLength(1)>
    <ComponentModel.DisplayName("再審委員会判定区分")>
    Public Property SAISIN_IINKAI_HANTEI_KB As String
        Get
            Return _SAISIN_IINKAI_HANTEI_KB
        End Get
        Set(value As String)
            _SAISIN_IINKAI_HANTEI_KB = value
            OnPropertyChanged(NameOf(SAISIN_IINKAI_HANTEI_KB))
        End Set
    End Property

    Dim _SAISIN_GIJYUTU_SYAIN_ID As Integer
    <Required>
    <ComponentModel.DisplayName("再審委員技術社員ID")>
    Public Property SAISIN_GIJYUTU_SYAIN_ID As Integer
        Get
            Return _SAISIN_GIJYUTU_SYAIN_ID
        End Get
        Set(value As Integer)
            _SAISIN_GIJYUTU_SYAIN_ID = value
            OnPropertyChanged(NameOf(SAISIN_GIJYUTU_SYAIN_ID))
        End Set
    End Property

    Dim _SAISIN_GIJYUTU_YMD As String
    <Required>
    <Column(TypeName:="char")>
    <StringLength(8)>
    <ComponentModel.DisplayName("再審委員技術確認日")>
    Public Property SAISIN_GIJYUTU_YMD As String
        Get
            Return _SAISIN_GIJYUTU_YMD
        End Get
        Set(value As String)
            _SAISIN_GIJYUTU_YMD = value
            OnPropertyChanged(NameOf(SAISIN_GIJYUTU_YMD))
        End Set
    End Property

    Dim _SAISIN_HINSYO_SYAIN_ID As String
    <Required>
    <ComponentModel.DisplayName("再審委員品証社員ID")>
    Public Property SAISIN_HINSYO_SYAIN_ID As Integer
        Get
            Return _SAISIN_HINSYO_SYAIN_ID
        End Get
        Set(value As Integer)
            _SAISIN_HINSYO_SYAIN_ID = value
            OnPropertyChanged(NameOf(SAISIN_HINSYO_SYAIN_ID))
        End Set
    End Property

    Dim _SAISIN_HINSYO_YMD As String
    <Required>
    <Column(TypeName:="char")>
    <StringLength(8)>
    <ComponentModel.DisplayName("再審委員品証確認日")>
    Public Property SAISIN_HINSYO_YMD As String
        Get
            Return _SAISIN_HINSYO_YMD
        End Get
        Set(value As String)
            _SAISIN_HINSYO_YMD = value
            OnPropertyChanged(NameOf(SAISIN_HINSYO_YMD))
        End Set
    End Property

    Dim _SAISIN_IINKAI_SIRYO_NO As String
    <Required>
    <Column(TypeName:="char")>
    <StringLength(2)>
    <ComponentModel.DisplayName("再審委員会資料No")>
    Public Property SAISIN_IINKAI_SIRYO_NO As String
        Get
            Return _SAISIN_IINKAI_SIRYO_NO
        End Get
        Set(value As String)
            _SAISIN_IINKAI_SIRYO_NO = value
            OnPropertyChanged(NameOf(SAISIN_IINKAI_SIRYO_NO))
        End Set
    End Property

    Dim _ITAG_NO As String
    <Required>
    <Column(TypeName:="nvarchar")>
    <StringLength(20)>
    <ComponentModel.DisplayName("ITAGNo")>
    Public Property ITAG_NO As String
        Get
            Return _ITAG_NO
        End Get
        Set(value As String)
            _ITAG_NO = value
            OnPropertyChanged(NameOf(ITAG_NO))
        End Set
    End Property

    Dim _KOKYAKU_SAISIN_TANTO_ID As Integer
    <Required>
    <ComponentModel.DisplayName("顧客再審申請担当ID")>
    Public Property KOKYAKU_SAISIN_TANTO_ID As Integer
        Get
            Return _KOKYAKU_SAISIN_TANTO_ID
        End Get
        Set(value As Integer)
            _KOKYAKU_SAISIN_TANTO_ID = value
            OnPropertyChanged(NameOf(KOKYAKU_SAISIN_TANTO_ID))
        End Set
    End Property

    Dim _KOKYAKU_SAISIN_YMD As String
    <Required>
    <Column(TypeName:="char")>
    <StringLength(8)>
    <ComponentModel.DisplayName("顧客再審申請日")>
    Public Property KOKYAKU_SAISIN_YMD As String
        Get
            Return _KOKYAKU_SAISIN_YMD
        End Get
        Set(value As String)
            _KOKYAKU_SAISIN_YMD = value
            OnPropertyChanged(NameOf(KOKYAKU_SAISIN_YMD))
        End Set
    End Property

    Dim _KOKYAKU_HANTEI_SIJI_KB As String
    <Required>
    <Column(TypeName:="char")>
    <StringLength(1)>
    <ComponentModel.DisplayName("顧客判定指示区分")>
    Public Property KOKYAKU_HANTEI_SIJI_KB As String
        Get
            Return _KOKYAKU_HANTEI_SIJI_KB
        End Get
        Set(value As String)
            _KOKYAKU_HANTEI_SIJI_KB = value
            OnPropertyChanged(NameOf(KOKYAKU_HANTEI_SIJI_KB))
        End Set
    End Property

    Dim _KOKYAKU_HANTEI_SIJI_YMD As String
    <Required>
    <Column(TypeName:="char")>
    <StringLength(8)>
    <ComponentModel.DisplayName("顧客判定指示日")>
    Public Property KOKYAKU_HANTEI_SIJI_YMD As String
        Get
            Return _KOKYAKU_HANTEI_SIJI_YMD
        End Get
        Set(value As String)
            _KOKYAKU_HANTEI_SIJI_YMD = value
            OnPropertyChanged(NameOf(KOKYAKU_HANTEI_SIJI_YMD))
        End Set
    End Property

    Dim _KOKYAKU_SAISYU_HANTEI_KB As String
    <Required>
    <Column(TypeName:="char")>
    <StringLength(1)>
    <ComponentModel.DisplayName("顧客最終判定区分")>
    Public Property KOKYAKU_SAISYU_HANTEI_KB As String
        Get
            Return _KOKYAKU_SAISYU_HANTEI_KB
        End Get
        Set(value As String)
            _KOKYAKU_SAISYU_HANTEI_KB = value
            OnPropertyChanged(NameOf(KOKYAKU_SAISYU_HANTEI_KB))
        End Set
    End Property

    Dim _KOKYAKU_SAISYU_HANTEI_YMD As String
    <Required>
    <Column(TypeName:="char")>
    <StringLength(8)>
    <ComponentModel.DisplayName("顧客最終判定日")>
    Public Property KOKYAKU_SAISYU_HANTEI_YMD As String
        Get
            Return _KOKYAKU_SAISYU_HANTEI_YMD
        End Get
        Set(value As String)
            _KOKYAKU_SAISYU_HANTEI_YMD = value
            OnPropertyChanged(NameOf(KOKYAKU_SAISYU_HANTEI_YMD))
        End Set
    End Property


    <Required>
    <Column("SAIKAKO_SIJI_FLG", TypeName:="char")>
    <StringLength(1)>
    <ComponentModel.DisplayName("再加工指示フラグ")>
    Public Property _SAIKAKO_SIJI_FLG As String

    <ComponentModel.DisplayName("再加工指示フラグ")>
    <NotMapped>
    Public Property SAIKAKO_SIJI_FLG As Boolean
        Get
            Return IIf(_SAIKAKO_SIJI_FLG = "0", False, True)
        End Get
        Set(value As Boolean)
            _SAIKAKO_SIJI_FLG = IIf(value, "1", "0")
            OnPropertyChanged(NameOf(SAIKAKO_SIJI_FLG))
        End Set
    End Property

    Dim _HAIKYAKU_YMD As String
    <Required>
    <Column(TypeName:="char")>
    <StringLength(8)>
    <ComponentModel.DisplayName("廃却年月日")>
    Public Property HAIKYAKU_YMD As String
        Get
            Return _HAIKYAKU_YMD
        End Get
        Set(value As String)
            _HAIKYAKU_YMD = value
            OnPropertyChanged(NameOf(HAIKYAKU_YMD))
        End Set
    End Property

    Dim _HAIKYAKU_KB As String
    <Required>
    <Column(TypeName:="char")>
    <StringLength(1)>
    <ComponentModel.DisplayName("廃却方法区分")>
    Public Property HAIKYAKU_KB As String
        Get
            Return _HAIKYAKU_KB
        End Get
        Set(value As String)
            _HAIKYAKU_KB = value
            OnPropertyChanged(NameOf(HAIKYAKU_KB))
        End Set
    End Property

    Dim _HAIKYAKU_HOUHOU As String
    <Required>
    <Column(TypeName:="nvarchar")>
    <StringLength(30)>
    <ComponentModel.DisplayName("廃却方法内容")>
    Public Property HAIKYAKU_HOUHOU As String
        Get
            Return _HAIKYAKU_HOUHOU
        End Get
        Set(value As String)
            _HAIKYAKU_HOUHOU = value
            OnPropertyChanged(NameOf(HAIKYAKU_HOUHOU))
        End Set
    End Property

    Dim _HAIKYAKU_TANTO_ID As Integer
    <Required>
    <ComponentModel.DisplayName("廃却実施者ID")>
    Public Property HAIKYAKU_TANTO_ID As Integer
        Get
            Return _HAIKYAKU_TANTO_ID
        End Get
        Set(value As Integer)
            _HAIKYAKU_TANTO_ID = value
            OnPropertyChanged(NameOf(HAIKYAKU_TANTO_ID))
        End Set
    End Property

    Dim _SAIKAKO_SIJI_NO As String
    <Required>
    <Column(TypeName:="char")>
    <StringLength(10)>
    <ComponentModel.DisplayName("再加工指示文書No")>
    Public Property SAIKAKO_SIJI_NO As String
        Get
            Return _SAIKAKO_SIJI_NO
        End Get
        Set(value As String)
            _SAIKAKO_SIJI_NO = value
            OnPropertyChanged(NameOf(SAIKAKO_SIJI_NO))
        End Set
    End Property

    Dim _SAIKAKO_SAGYO_KAN_YMD As String
    <Required>
    <Column(TypeName:="char")>
    <StringLength(8)>
    <ComponentModel.DisplayName("再加工作業完了日")>
    Public Property SAIKAKO_SAGYO_KAN_YMD As String
        Get
            Return _SAIKAKO_SAGYO_KAN_YMD
        End Get
        Set(value As String)
            _SAIKAKO_SAGYO_KAN_YMD = value
            OnPropertyChanged(NameOf(SAIKAKO_SAGYO_KAN_YMD))
        End Set
    End Property

    Dim _SAIKAKO_KENSA_YMD As String
    <Required>
    <Column(TypeName:="char")>
    <StringLength(8)>
    <ComponentModel.DisplayName("再加工検査年月日")>
    Public Property SAIKAKO_KENSA_YMD As String
        Get
            Return _SAIKAKO_KENSA_YMD
        End Get
        Set(value As String)
            _SAIKAKO_KENSA_YMD = value
            OnPropertyChanged(NameOf(SAIKAKO_KENSA_YMD))
        End Set
    End Property

    Dim _KENSA_KEKKA_KB As String
    <Required>
    <Column(TypeName:="char")>
    <StringLength(1)>
    <ComponentModel.DisplayName("検査結果区分")>
    Public Property KENSA_KEKKA_KB As String
        Get
            Return _KENSA_KEKKA_KB
        End Get
        Set(value As String)
            _KENSA_KEKKA_KB = value
            OnPropertyChanged(NameOf(KENSA_KEKKA_KB))
        End Set
    End Property

    Dim _SEIGI_TANTO_ID As Integer
    <Required>
    <ComponentModel.DisplayName("生技社員ID")>
    Public Property SEIGI_TANTO_ID As Integer
        Get
            Return _SEIGI_TANTO_ID
        End Get
        Set(value As Integer)
            _SEIGI_TANTO_ID = value
            OnPropertyChanged(NameOf(SEIGI_TANTO_ID))
        End Set
    End Property

    Dim _SEIZO_TANTO_ID As Integer
    <Required>
    <ComponentModel.DisplayName("製造社員ID")>
    Public Property SEIZO_TANTO_ID As Integer
        Get
            Return _SEIZO_TANTO_ID
        End Get
        Set(value As Integer)
            _SEIZO_TANTO_ID = value
            OnPropertyChanged(NameOf(SEIZO_TANTO_ID))
        End Set
    End Property

    Dim _KENSA_TANTO_ID As Integer
    <Required>
    <ComponentModel.DisplayName("検査社員ID")>
    Public Property KENSA_TANTO_ID As Integer
        Get
            Return _KENSA_TANTO_ID
        End Get
        Set(value As Integer)
            _KENSA_TANTO_ID = value
            OnPropertyChanged(NameOf(KENSA_TANTO_ID))
        End Set
    End Property

    Dim _HENKYAKU_YMD As String
    <Required>
    <Column(TypeName:="char")>
    <StringLength(8)>
    <ComponentModel.DisplayName("返却年月日")>
    Public Property HENKYAKU_YMD As String
        Get
            Return _HENKYAKU_YMD
        End Get
        Set(value As String)
            _HENKYAKU_YMD = value
            OnPropertyChanged(NameOf(HENKYAKU_YMD))
        End Set
    End Property

    Dim _HENKYAKU_SAKI As String
    <Required>
    <Column(TypeName:="nvarchar")>
    <StringLength(60)>
    <ComponentModel.DisplayName("返却先")>
    Public Property HENKYAKU_SAKI As String
        Get
            Return _HENKYAKU_SAKI
        End Get
        Set(value As String)
            _HENKYAKU_SAKI = value
            OnPropertyChanged(NameOf(HENKYAKU_SAKI))
        End Set
    End Property



    Dim _HENKYAKU_TANTO_ID As Integer
    <Required>
    <ComponentModel.DisplayName("返却実施者ID")>
    Public Property HENKYAKU_TANTO_ID As Integer
        Get
            Return _HENKYAKU_TANTO_ID
        End Get
        Set(value As Integer)
            _HENKYAKU_TANTO_ID = value
            OnPropertyChanged(NameOf(HENKYAKU_TANTO_ID))
        End Set
    End Property

    Dim _HENKYAKU_BIKO As String
    <Required>
    <Column(TypeName:="nvarchar")>
    <StringLength(100)>
    <ComponentModel.DisplayName("返却実施備考")>
    Public Property HENKYAKU_BIKO As String
        Get
            Return _HENKYAKU_BIKO
        End Get
        Set(value As String)
            _HENKYAKU_BIKO = value
            OnPropertyChanged(NameOf(HENKYAKU_BIKO))
        End Set
    End Property

    Dim _TENYO_KISYU_ID As Integer
    <Required>
    <ComponentModel.DisplayName("転用先機種ID")>
    Public Property TENYO_KISYU_ID As Integer
        Get
            Return _TENYO_KISYU_ID
        End Get
        Set(value As Integer)
            _TENYO_KISYU_ID = value
            OnPropertyChanged(NameOf(TENYO_KISYU_ID))
        End Set
    End Property

    Dim _TENYO_BUHIN_BANGO As String
    <Required>
    <Column(TypeName:="varchar")>
    <StringLength(60)>
    <ComponentModel.DisplayName("転用先部品番号")>
    Public Property TENYO_BUHIN_BANGO As String
        Get
            Return _TENYO_BUHIN_BANGO
        End Get
        Set(value As String)
            _TENYO_BUHIN_BANGO = value
            OnPropertyChanged(NameOf(TENYO_BUHIN_BANGO))
        End Set
    End Property

    Dim _TENYO_GOKI As String
    <Required>
    <Column(TypeName:="varchar")>
    <StringLength(5)>
    <ComponentModel.DisplayName("転用先号機")>
    Public Property TENYO_GOKI As String
        Get
            Return _TENYO_GOKI
        End Get
        Set(value As String)
            _TENYO_GOKI = value
            OnPropertyChanged(NameOf(TENYO_GOKI))
        End Set
    End Property

    Dim _TENYO_LOT As Integer
    <Required>
    <ComponentModel.DisplayName("転用先LOT")>
    Public Property TENYO_LOT As Integer
        Get
            Return _TENYO_LOT
        End Get
        Set(value As Integer)
            _TENYO_LOT = value
            OnPropertyChanged(NameOf(TENYO_LOT))
        End Set
    End Property

    Dim _TENYO_YMD As String
    <Required>
    <Column(TypeName:="char")>
    <StringLength(8)>
    <ComponentModel.DisplayName("転用年月日")>
    Public Property TENYO_YMD As String
        Get
            Return _TENYO_YMD
        End Get
        Set(value As String)
            _TENYO_YMD = value
            OnPropertyChanged(NameOf(TENYO_YMD))
        End Set
    End Property

    Dim _SYOCHI_KEKKA_A As String
    <Required>
    <Column(TypeName:="char")>
    <StringLength(1)>
    <ComponentModel.DisplayName("処置結果a")>
    Public Property SYOCHI_KEKKA_A As String
        Get
            Return _SYOCHI_KEKKA_A
        End Get
        Set(value As String)
            _SYOCHI_KEKKA_A = value
            OnPropertyChanged(NameOf(SYOCHI_KEKKA_A))
        End Set
    End Property

    Dim _SYOCHI_KEKKA_B As String
    <Required>
    <Column(TypeName:="char")>
    <StringLength(1)>
    <ComponentModel.DisplayName("処置結果b")>
    Public Property SYOCHI_KEKKA_B As String
        Get
            Return _SYOCHI_KEKKA_B
        End Get
        Set(value As String)
            _SYOCHI_KEKKA_B = value
            OnPropertyChanged(NameOf(SYOCHI_KEKKA_B))
        End Set
    End Property

    Dim _SYOCHI_KEKKA_C As String
    <Required>
    <Column(TypeName:="char")>
    <StringLength(1)>
    <ComponentModel.DisplayName("処置結果c")>
    Public Property SYOCHI_KEKKA_C As String
        Get
            Return _SYOCHI_KEKKA_C
        End Get
        Set(value As String)
            _SYOCHI_KEKKA_C = value
            OnPropertyChanged(NameOf(SYOCHI_KEKKA_C))
        End Set
    End Property

    Dim _SYOCHI_D_UMU_KB As String
    <Required>
    <Column(TypeName:="char")>
    <StringLength(1)>
    <ComponentModel.DisplayName("処置d有無区分")>
    Public Property SYOCHI_D_UMU_KB As String
        Get
            Return _SYOCHI_D_UMU_KB
        End Get
        Set(value As String)
            _SYOCHI_D_UMU_KB = value
            OnPropertyChanged(NameOf(SYOCHI_D_UMU_KB))
        End Set
    End Property

    Dim _SYOCHI_D_YOHI_KB As String
    <Required>
    <Column(TypeName:="char")>
    <StringLength(1)>
    <ComponentModel.DisplayName("処置d要否区分")>
    Public Property SYOCHI_D_YOHI_KB As String
        Get
            Return _SYOCHI_D_YOHI_KB
        End Get
        Set(value As String)
            _SYOCHI_D_YOHI_KB = value
            OnPropertyChanged(NameOf(SYOCHI_D_YOHI_KB))
        End Set
    End Property

    Dim _SYOCHI_D_SYOCHI_KIROKU As String
    <Required>
    <Column(TypeName:="nvarchar")>
    <StringLength(100)>
    <ComponentModel.DisplayName("処置d処置記録")>
    Public Property SYOCHI_D_SYOCHI_KIROKU As String
        Get
            Return _SYOCHI_D_SYOCHI_KIROKU
        End Get
        Set(value As String)
            _SYOCHI_D_SYOCHI_KIROKU = value
            OnPropertyChanged(NameOf(SYOCHI_D_SYOCHI_KIROKU))
        End Set
    End Property

    Dim _SYOCHI_E_UMU_KB As String
    <Required>
    <Column(TypeName:="char")>
    <StringLength(1)>
    <ComponentModel.DisplayName("処置e有無区分")>
    Public Property SYOCHI_E_UMU_KB As String
        Get
            Return _SYOCHI_E_UMU_KB
        End Get
        Set(value As String)
            _SYOCHI_E_UMU_KB = value
            OnPropertyChanged(NameOf(SYOCHI_E_UMU_KB))
        End Set
    End Property

    Dim _SYOCHI_E_YOHI_KB As String
    <Required>
    <Column(TypeName:="char")>
    <StringLength(1)>
    <ComponentModel.DisplayName("処置e要否区分")>
    Public Property SYOCHI_E_YOHI_KB As String
        Get
            Return _SYOCHI_E_YOHI_KB
        End Get
        Set(value As String)
            _SYOCHI_E_YOHI_KB = value
            OnPropertyChanged(NameOf(SYOCHI_E_YOHI_KB))
        End Set
    End Property

    Dim _SYOCHI_E_SYOCHI_KIROKU As String
    <Required>
    <Column(TypeName:="nvarchar")>
    <StringLength(100)>
    <ComponentModel.DisplayName("処置e処置記録")>
    Public Property SYOCHI_E_SYOCHI_KIROKU As String
        Get
            Return _SYOCHI_E_SYOCHI_KIROKU
        End Get
        Set(value As String)
            _SYOCHI_E_SYOCHI_KIROKU = value
            OnPropertyChanged(NameOf(SYOCHI_E_SYOCHI_KIROKU))
        End Set
    End Property

    Dim _FILE_PATH As String
    <Required>
    <Column(TypeName:="nvarchar")>
    <StringLength(200)>
    <ComponentModel.DisplayName("ファイルパス")>
    Public Property FILE_PATH As String
        Get
            Return _FILE_PATH
        End Get
        Set(value As String)
            _FILE_PATH = value
            OnPropertyChanged(NameOf(FILE_PATH))
        End Set
    End Property

    Dim _G_FILE_PATH1 As String
    <Required>
    <Column(TypeName:="nvarchar")>
    <StringLength(200)>
    <ComponentModel.DisplayName("画像ファイルパス1")>
    Public Property G_FILE_PATH1 As String
        Get
            Return _G_FILE_PATH1
        End Get
        Set(value As String)
            _G_FILE_PATH1 = value
            OnPropertyChanged(NameOf(G_FILE_PATH1))
        End Set
    End Property

    Dim _G_FILE_PATH2 As String
    <Required>
    <Column(TypeName:="nvarchar")>
    <StringLength(200)>
    <ComponentModel.DisplayName("画像ファイルパス2")>
    Public Property G_FILE_PATH2 As String
        Get
            Return _G_FILE_PATH2
        End Get
        Set(value As String)
            _G_FILE_PATH2 = value
            OnPropertyChanged(NameOf(G_FILE_PATH2))
        End Set
    End Property


    ''共通項目------------------------------------
    Dim _ADD_YMDHNS As String
    <Required>
    <StringLength(14)>
    <Display(AutoGenerateField:=False)>
    <Column(TypeName:="char")>
    Public Property ADD_YMDHNS As String
        Get
            Return _ADD_YMDHNS
        End Get
        Set(value As String)
            _ADD_YMDHNS = value
            OnPropertyChanged(NameOf(ADD_YMDHNS))
        End Set
    End Property

    <NotMapped>
    Public ReadOnly Property ADD_YMD As Boolean
        Get
            Return IIf(ADD_YMDHNS <> "", ADD_YMDHNS.Substring(0, 8), "")
        End Get
    End Property


    Dim _ADD_SYAIN_ID As Integer
    <Required>
    <Display(AutoGenerateField:=False)>
    Public Property ADD_SYAIN_ID As Integer
        Get
            Return _ADD_SYAIN_ID
        End Get
        Set(value As Integer)
            _ADD_SYAIN_ID = value
            OnPropertyChanged(NameOf(ADD_SYAIN_ID))
        End Set
    End Property

    Dim _UPD_YMDHNS As String
    <Required>
    <StringLength(14)>
    <Display(AutoGenerateField:=False)>
    <Column(TypeName:="char")>
    Public Property UPD_YMDHNS As String
        Get
            Return _UPD_YMDHNS
        End Get
        Set(value As String)
            _UPD_YMDHNS = value
            OnPropertyChanged(NameOf(UPD_YMDHNS))
        End Set
    End Property

    Dim _UPD_SYAIN_ID As Integer
    <Required>
    <Display(AutoGenerateField:=False)>
    Public Property UPD_SYAIN_ID As Integer
        Get
            Return _UPD_SYAIN_ID
        End Get
        Set(value As Integer)
            _UPD_SYAIN_ID = value
            OnPropertyChanged(NameOf(UPD_SYAIN_ID))
        End Set
    End Property

    Dim _DEL_YMDHNS As String
    <Required>
    <StringLength(14)>
    <Display(AutoGenerateField:=False)>
    <Column(TypeName:="char")>
    Public Property DEL_YMDHNS As String
        Get
            Return _DEL_YMDHNS
        End Get
        Set(value As String)
            _DEL_YMDHNS = value
            OnPropertyChanged(NameOf(DEL_YMDHNS))
        End Set
    End Property

    <ComponentModel.DisplayName("削除済")>
    <NotMapped>
    Public ReadOnly Property DEL_FLG As Boolean
        Get
            Return DEL_YMDHNS.Trim <> ""
        End Get
    End Property

    Dim _DEL_SYAIN_ID As Integer
    <Required>
    <Display(AutoGenerateField:=False)>
    Public Property DEL_SYAIN_ID As Integer
        Get
            Return _DEL_SYAIN_ID
        End Get
        Set(value As Integer)
            _DEL_SYAIN_ID = value
            OnPropertyChanged(NameOf(DEL_SYAIN_ID))
        End Set
    End Property
End Class