Imports System.ComponentModel
Imports System.ComponentModel.DataAnnotations
Imports System.ComponentModel.DataAnnotations.Schema
Imports PropertyChanged

''' <summary>
''' D003_不適合製品処置報告書情報
''' </summary>
<Table(NameOf(R003_NCR_SASIMODOSI), Schema:="dbo")>
<AddINotifyPropertyChangedInterface>
Partial Public Class R003_NCR_SASIMODOSI
    'Inherits NotifyChangedBase

    Public Sub New()
        Call Clear()
    End Sub

    Public Sub Clear()
        SASIMODOSI_YMDHNS = ""
        HOKOKU_NO = ""
        BUMON_KB = ""
        CLOSE_FG = False
        KISYU_ID = 0
        SYANAI_CD = ""
        BUHIN_BANGO = ""
        BUHIN_NAME = ""
        GOKI = ""
        SURYO = 1
        SAIHATU = False
        FUTEKIGO_JYOTAI_KB = ""
        FUTEKIGO_NAIYO = ""
        FUTEKIGO_KB = ""
        FUTEKIGO_S_KB = ""
        ZUMEN_KIKAKU = ""
        YOKYU_NAIYO = ""
        KANSATU_KEKKA = ""
        ZESEI_SYOCHI_YOHI_KB = False
        ZESEI_NASI_RIYU = ""
        JIZEN_SINSA_HANTEI_KB = ""
        JIZEN_SINSA_SYAIN_ID = 0
        JIZEN_SINSA_YMD = ""
        SAISIN_KAKUNIN_SYAIN_ID = 0
        SAISIN_KAKUNIN_YMD = ""
        SAISIN_IINKAI_HANTEI_KB = ""
        SAISIN_GIJYUTU_SYAIN_ID = 0
        SAISIN_GIJYUTU_YMD = ""
        SAISIN_HINSYO_SYAIN_ID = 0
        SAISIN_HINSYO_YMD = ""
        SAISIN_IINKAI_SIRYO_NO = ""
        ITAG_NO = ""
        KOKYAKU_SAISIN_TANTO_ID = 0
        KOKYAKU_SAISIN_YMD = ""
        KOKYAKU_HANTEI_SIJI_KB = ""
        KOKYAKU_HANTEI_SIJI_YMD = ""
        KOKYAKU_SAISYU_HANTEI_KB = ""
        KOKYAKU_SAISYU_HANTEI_YMD = ""
        SAIKAKO_SIJI_FG = False
        HAIKYAKU_YMD = ""
        HAIKYAKU_KB = ""
        HAIKYAKU_HOUHOU = ""
        HAIKYAKU_TANTO_ID = 0
        SAIKAKO_SIJI_NO = ""
        SAIKAKO_SAGYO_KAN_YMD = ""
        SAIKAKO_KENSA_YMD = ""
        KENSA_KEKKA_KB = ""
        SEIGI_TANTO_ID = 0
        SEIZO_TANTO_ID = 0
        KENSA_TANTO_ID = 0
        HENKYAKU_YMD = ""
        HENKYAKU_SAKI = ""
        HENKYAKU_TANTO_ID = 0
        HENKYAKU_BIKO = ""
        TENYO_KISYU_ID = 0
        TENYO_BUHIN_BANGO = ""
        TENYO_GOKI = ""
        TENYO_LOT = 0
        TENYO_YMD = ""
        SYOCHI_KEKKA_A = False
        SYOCHI_KEKKA_B = False
        SYOCHI_KEKKA_C = False
        SYOCHI_D_UMU_KB = False
        SYOCHI_D_YOHI_KB = False
        SYOCHI_D_SYOCHI_KIROKU = ""
        SYOCHI_E_UMU_KB = False
        SYOCHI_E_YOHI_KB = False
        SYOCHI_E_SYOCHI_KIROKU = ""
        FILE_PATH = ""
        G_FILE_PATH1 = ""
        G_FILE_PATH2 = ""
        HASSEI_KOTEI_GL_SYAIN_ID = 0

    End Sub

    <Display(AutoGenerateField:=False)>
    Default Public Property Item(ByVal propertyName As String) As Object
        Get
            Return GetType(R003_NCR_SASIMODOSI).GetProperty(propertyName).GetValue(Me)
        End Get
        Set(value As Object)
            GetType(R003_NCR_SASIMODOSI).GetProperty(propertyName).SetValue(Me, value)
        End Set
    End Property

    <StringLength(14)>
    Public Property SASIMODOSI_YMDHNS As String


    <StringLength(10)>
    <DisplayName("報告書No")>
    Public Property HOKOKU_NO As String

    <Required>
    <Column(TypeName:="char")>
    <StringLength(1)>
    <DisplayName("部門区分")>
    Public Property BUMON_KB As String

    <Required>
    <StringLength(1)>
    <Column(NameOf(CLOSE_FG), TypeName:="char")>
    <ComponentModel.DisplayName("クローズフラグ")>
    Public Property _CLOSE_FG As String

    <ComponentModel.DisplayName("クローズフラグ")>
    <NotMapped>
    Public Property CLOSE_FG As Boolean
        Get
            Return IIf(_CLOSE_FG = "0", False, True)
        End Get
        Set(value As Boolean)
            _CLOSE_FG = IIf(value, "1", "0")
            'OnPropertyChanged(NameOf(CLOSE_FG))
        End Set
    End Property

    <Required>
    <ComponentModel.DisplayName("機種ID")>
    Public Property KISYU_ID As Integer

    <Required>
    <Column(TypeName:="varchar")>
    <StringLength(10)>
    <ComponentModel.DisplayName("社内コード")>
    Public Property SYANAI_CD As String

    <Required>
    <Column(TypeName:="varchar")>
    <StringLength(60)>
    <ComponentModel.DisplayName("部品番号")>
    Public Property BUHIN_BANGO As String

    <Required>
    <Column(TypeName:="nvarchar")>
    <StringLength(1)>
    <ComponentModel.DisplayName("部品名称")>
    Public Property BUHIN_NAME As String

    <Required>
    <Column(TypeName:="char")>
    <StringLength(5)>
    <ComponentModel.DisplayName("号機")>
    Public Property GOKI As String

    <Required>
    <ComponentModel.DisplayName("数量")>
    Public Property SURYO As Integer

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
            'OnPropertyChanged(NameOf(SAIHATU))
        End Set
    End Property

    <Required>
    <Column(TypeName:="char")>
    <StringLength(1)>
    <ComponentModel.DisplayName("不適合状態区分")>
    Public Property FUTEKIGO_JYOTAI_KB As String

    <Required>
    <Column(TypeName:="nvarchar")>
    <StringLength(30)>
    <ComponentModel.DisplayName("不適合状態内容")>
    Public Property FUTEKIGO_NAIYO As String

    <Required>
    <Column(TypeName:="char")>
    <StringLength(1)>
    <ComponentModel.DisplayName("不適合区分")>
    Public Property FUTEKIGO_KB As String

    <Required>
    <Column(TypeName:="varchar")>
    <StringLength(2)>
    <ComponentModel.DisplayName("不適合詳細区分")>
    Public Property FUTEKIGO_S_KB As String

    <Required>
    <Column(TypeName:="nvarchar")>
    <StringLength(30)>
    <ComponentModel.DisplayName("図面規格")>
    Public Property ZUMEN_KIKAKU As String

    <Required>
    <Column(TypeName:="nvarchar")>
    <StringLength(500)>
    <ComponentModel.DisplayName("要求内容")>
    Public Property YOKYU_NAIYO As String

    <Required>
    <Column(TypeName:="nvarchar")>
    <StringLength(500)>
    <ComponentModel.DisplayName("観察結果")>
    Public Property KANSATU_KEKKA As String

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
            'OnPropertyChanged(NameOf(_ZESEI_SYOCHI_YOHI_KB))
        End Set
    End Property

    <Required>
    <Column(TypeName:="nvarchar")>
    <StringLength(100)>
    <ComponentModel.DisplayName("是正処置無理由")>
    Public Property ZESEI_NASI_RIYU As String

    <Required>
    <Column(TypeName:="char")>
    <StringLength(1)>
    <ComponentModel.DisplayName("事前審査判定区分")>
    Public Property JIZEN_SINSA_HANTEI_KB As String

    <Required>
    <ComponentModel.DisplayName("事前審査社員ID")>
    Public Property JIZEN_SINSA_SYAIN_ID As Integer

    <Required>
    <Column(TypeName:="char")>
    <StringLength(8)>
    <ComponentModel.DisplayName("事前審査日")>
    Public Property JIZEN_SINSA_YMD As String

    <Required>
    <ComponentModel.DisplayName("再審委員確認社員ID")>
    Public Property SAISIN_KAKUNIN_SYAIN_ID As Integer

    <Required>
    <Column(TypeName:="char")>
    <StringLength(8)>
    <ComponentModel.DisplayName("再審委員確認日")>
    Public Property SAISIN_KAKUNIN_YMD As String

    <Required>
    <Column(TypeName:="char")>
    <StringLength(1)>
    <ComponentModel.DisplayName("再審委員会判定区分")>
    Public Property SAISIN_IINKAI_HANTEI_KB As String

    <Required>
    <ComponentModel.DisplayName("再審委員技術社員ID")>
    Public Property SAISIN_GIJYUTU_SYAIN_ID As Integer

    <Required>
    <Column(TypeName:="char")>
    <StringLength(8)>
    <ComponentModel.DisplayName("再審委員技術確認日")>
    Public Property SAISIN_GIJYUTU_YMD As String

    <Required>
    <ComponentModel.DisplayName("再審委員品証社員ID")>
    Public Property SAISIN_HINSYO_SYAIN_ID As Integer

    <Required>
    <Column(TypeName:="char")>
    <StringLength(8)>
    <ComponentModel.DisplayName("再審委員品証確認日")>
    Public Property SAISIN_HINSYO_YMD As String

    <Required>
    <Column(TypeName:="char")>
    <StringLength(2)>
    <ComponentModel.DisplayName("再審委員会資料No")>
    Public Property SAISIN_IINKAI_SIRYO_NO As String

    <Required>
    <Column(TypeName:="nvarchar")>
    <StringLength(20)>
    <ComponentModel.DisplayName("ITAGNo")>
    Public Property ITAG_NO As String

    <Required>
    <ComponentModel.DisplayName("顧客再審申請担当ID")>
    Public Property KOKYAKU_SAISIN_TANTO_ID As Integer

    <Required>
    <Column(TypeName:="char")>
    <StringLength(8)>
    <ComponentModel.DisplayName("顧客再審申請日")>
    Public Property KOKYAKU_SAISIN_YMD As String

    <Required>
    <Column(TypeName:="char")>
    <StringLength(1)>
    <ComponentModel.DisplayName("顧客判定指示区分")>
    Public Property KOKYAKU_HANTEI_SIJI_KB As String

    <Required>
    <Column(TypeName:="char")>
    <StringLength(8)>
    <ComponentModel.DisplayName("顧客判定指示日")>
    Public Property KOKYAKU_HANTEI_SIJI_YMD As String

    <Required>
    <Column(TypeName:="char")>
    <StringLength(1)>
    <ComponentModel.DisplayName("顧客最終判定区分")>
    Public Property KOKYAKU_SAISYU_HANTEI_KB As String

    <Required>
    <Column(TypeName:="char")>
    <StringLength(8)>
    <ComponentModel.DisplayName("顧客最終判定日")>
    Public Property KOKYAKU_SAISYU_HANTEI_YMD As String

    <Required>
    <Column(NameOf(SAIKAKO_SIJI_FG), TypeName:="char")>
    <StringLength(1)>
    <Display(AutoGenerateField:=False)>
    <ComponentModel.DisplayName("再加工指示フラグ")>
    Public Property _SAIKAKO_SIJI_FG As String

    <ComponentModel.DisplayName("再加工指示フラグ")>
    <NotMapped>
    Public Property SAIKAKO_SIJI_FG As Boolean
        Get
            Return IIf(_SAIKAKO_SIJI_FG = "0", False, True)
        End Get
        Set(value As Boolean)
            _SAIKAKO_SIJI_FG = IIf(value, "1", "0")
            'OnPropertyChanged(NameOf(SAIKAKO_SIJI_FG))
        End Set
    End Property

    <Required>
    <Column(TypeName:="char")>
    <StringLength(8)>
    <ComponentModel.DisplayName("廃却年月日")>
    Public Property HAIKYAKU_YMD As String

    <Required>
    <Column(TypeName:="char")>
    <StringLength(1)>
    <ComponentModel.DisplayName("廃却方法区分")>
    Public Property HAIKYAKU_KB As String

    <Required>
    <Column(TypeName:="nvarchar")>
    <StringLength(30)>
    <ComponentModel.DisplayName("廃却方法内容")>
    Public Property HAIKYAKU_HOUHOU As String

    <Required>
    <ComponentModel.DisplayName("廃却実施者ID")>
    Public Property HAIKYAKU_TANTO_ID As Integer

    <Required>
    <Column(TypeName:="char")>
    <StringLength(10)>
    <ComponentModel.DisplayName("再加工指示文書No")>
    Public Property SAIKAKO_SIJI_NO As String

    <Required>
    <Column(TypeName:="char")>
    <StringLength(8)>
    <ComponentModel.DisplayName("再加工作業完了日")>
    Public Property SAIKAKO_SAGYO_KAN_YMD As String

    <Required>
    <Column(TypeName:="char")>
    <StringLength(8)>
    <ComponentModel.DisplayName("再加工検査年月日")>
    Public Property SAIKAKO_KENSA_YMD As String

    <Required>
    <Column(TypeName:="char")>
    <StringLength(1)>
    <ComponentModel.DisplayName("検査結果区分")>
    Public Property KENSA_KEKKA_KB As String

    <Required>
    <ComponentModel.DisplayName("生技社員ID")>
    Public Property SEIGI_TANTO_ID As Integer

    <Required>
    <ComponentModel.DisplayName("製造社員ID")>
    Public Property SEIZO_TANTO_ID As Integer

    <Required>
    <ComponentModel.DisplayName("検査社員ID")>
    Public Property KENSA_TANTO_ID As Integer

    <Required>
    <Column(TypeName:="char")>
    <StringLength(8)>
    <ComponentModel.DisplayName("返却年月日")>
    Public Property HENKYAKU_YMD As String

    <Required>
    <Column(TypeName:="nvarchar")>
    <StringLength(60)>
    <ComponentModel.DisplayName("返却先")>
    Public Property HENKYAKU_SAKI As String

    <Required>
    <ComponentModel.DisplayName("返却実施者ID")>
    Public Property HENKYAKU_TANTO_ID As Integer

    <Required>
    <Column(TypeName:="nvarchar")>
    <StringLength(100)>
    <ComponentModel.DisplayName("返却実施備考")>
    Public Property HENKYAKU_BIKO As String

    <Required>
    <ComponentModel.DisplayName("転用先機種ID")>
    Public Property TENYO_KISYU_ID As Integer

    <Required>
    <Column(TypeName:="varchar")>
    <StringLength(60)>
    <ComponentModel.DisplayName("転用先部品番号")>
    Public Property TENYO_BUHIN_BANGO As String

    <Required>
    <Column(TypeName:="varchar")>
    <StringLength(5)>
    <ComponentModel.DisplayName("転用先号機")>
    Public Property TENYO_GOKI As String

    <Required>
    <ComponentModel.DisplayName("転用先LOT")>
    Public Property TENYO_LOT As Integer

    <Required>
    <Column(TypeName:="char")>
    <StringLength(8)>
    <ComponentModel.DisplayName("転用年月日")>
    Public Property TENYO_YMD As String

    <Required>
    <Column(TypeName:="char")>
    <StringLength(1)>
    <ComponentModel.DisplayName("処置結果a")>
    Public Property _SYOCHI_KEKKA_A As String

    <ComponentModel.DisplayName("処置結果a")>
    <NotMapped>
    Public Property SYOCHI_KEKKA_A As Boolean
        Get
            Return IIf(_SYOCHI_KEKKA_A = "0", False, True)
        End Get
        Set(value As Boolean)
            _SYOCHI_KEKKA_A = IIf(value, "1", "0")
            'OnPropertyChanged(NameOf(CLOSE_FG))
        End Set
    End Property

    <Required>
    <Column(TypeName:="char")>
    <StringLength(1)>
    <ComponentModel.DisplayName("処置結果b")>
    Public Property _SYOCHI_KEKKA_B As String

    <ComponentModel.DisplayName("処置結果b")>
    <NotMapped>
    Public Property SYOCHI_KEKKA_B As Boolean
        Get
            Return IIf(_SYOCHI_KEKKA_B = "0", False, True)
        End Get
        Set(value As Boolean)
            _SYOCHI_KEKKA_B = IIf(value, "1", "0")
            'OnPropertyChanged(NameOf(CLOSE_FG))
        End Set
    End Property

    <Required>
    <Column(TypeName:="char")>
    <StringLength(1)>
    <ComponentModel.DisplayName("処置結果c")>
    Public Property _SYOCHI_KEKKA_C As String

    <ComponentModel.DisplayName("処置結果c")>
    <NotMapped>
    Public Property SYOCHI_KEKKA_C As Boolean
        Get
            Return IIf(_SYOCHI_KEKKA_C = "0", False, True)
        End Get
        Set(value As Boolean)
            _SYOCHI_KEKKA_C = IIf(value, "1", "0")
            'OnPropertyChanged(NameOf(CLOSE_FG))
        End Set
    End Property

    <Required>
    <Column(TypeName:="char")>
    <StringLength(1)>
    <ComponentModel.DisplayName("処置d有無区分")>
    Public Property _SYOCHI_D_UMU_KB As String

    <ComponentModel.DisplayName("処置d有無区分")>
    <NotMapped>
    Public Property SYOCHI_D_UMU_KB As Boolean
        Get
            Return IIf(_SYOCHI_D_UMU_KB = "0", False, True)
        End Get
        Set(value As Boolean)
            _SYOCHI_D_UMU_KB = IIf(value, "1", "0")
            'OnPropertyChanged(NameOf(CLOSE_FG))
        End Set
    End Property

    <Required>
    <Column(TypeName:="char")>
    <StringLength(1)>
    <ComponentModel.DisplayName("処置d要否区分")>
    Public Property _SYOCHI_D_YOHI_KB As String

    <ComponentModel.DisplayName("処置d要否区分")>
    <NotMapped>
    Public Property SYOCHI_D_YOHI_KB As Boolean
        Get
            Return IIf(_SYOCHI_D_YOHI_KB = "0", False, True)
        End Get
        Set(value As Boolean)
            _SYOCHI_D_YOHI_KB = IIf(value, "1", "0")
            'OnPropertyChanged(NameOf(CLOSE_FG))
        End Set
    End Property

    <Required>
    <Column(TypeName:="nvarchar")>
    <StringLength(100)>
    <ComponentModel.DisplayName("処置d処置記録")>
    Public Property SYOCHI_D_SYOCHI_KIROKU As String

    <Required>
    <Column(TypeName:="char")>
    <StringLength(1)>
    <ComponentModel.DisplayName("処置e有無区分")>
    Public Property _SYOCHI_E_UMU_KB As String

    <ComponentModel.DisplayName("処置e有無区分")>
    <NotMapped>
    Public Property SYOCHI_E_UMU_KB As Boolean
        Get
            Return IIf(_SYOCHI_E_UMU_KB = "0", False, True)
        End Get
        Set(value As Boolean)
            _SYOCHI_E_UMU_KB = IIf(value, "1", "0")
            'OnPropertyChanged(NameOf(CLOSE_FG))
        End Set
    End Property

    <Required>
    <Column(TypeName:="char")>
    <StringLength(1)>
    <ComponentModel.DisplayName("処置e要否区分")>
    Public Property _SYOCHI_E_YOHI_KB As String

    <ComponentModel.DisplayName("処置e要否区分")>
    <NotMapped>
    Public Property SYOCHI_E_YOHI_KB As Boolean
        Get
            Return IIf(_SYOCHI_E_YOHI_KB = "0", False, True)
        End Get
        Set(value As Boolean)
            _SYOCHI_E_YOHI_KB = IIf(value, "1", "0")
            'OnPropertyChanged(NameOf(CLOSE_FG))
        End Set
    End Property

    <Required>
    <Column(TypeName:="nvarchar")>
    <StringLength(100)>
    <ComponentModel.DisplayName("処置e処置記録")>
    Public Property SYOCHI_E_SYOCHI_KIROKU As String

    <Required>
    <Column(TypeName:="nvarchar")>
    <StringLength(200)>
    <ComponentModel.DisplayName("ファイルパス")>
    Public Property FILE_PATH As String

    <Required>
    <Column(TypeName:="nvarchar")>
    <StringLength(200)>
    <ComponentModel.DisplayName("画像ファイルパス1")>
    Public Property G_FILE_PATH1 As String

    <Required>
    <Column(TypeName:="nvarchar")>
    <StringLength(200)>
    <ComponentModel.DisplayName("画像ファイルパス2")>
    Public Property G_FILE_PATH2 As String



    <Required>
    <ComponentModel.DisplayName("発生工程GL確認担当")>
    Public Property HASSEI_KOTEI_GL_SYAIN_ID As Integer
End Class