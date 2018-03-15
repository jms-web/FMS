Imports System
Imports System.Collections.Generic
Imports System.ComponentModel.DataAnnotations
Imports System.ComponentModel.DataAnnotations.Schema
Imports System.Data.Entity.Spatial

''' <summary>
''' D003_不適合製品処置報告書情報
''' </summary>
<Table("D003_NCR_J", Schema:="dbo")>
Partial Public Class D003_NCR_J

    <Key>
    <Column(Order:=0, TypeName:="char")>
    <StringLength(10)>
    <ComponentModel.DisplayName("報告書No")>
    Public Property HOKOKU_NO As String

    <Required>
    <Column(TypeName:="char")>
    <StringLength(1)>
    <ComponentModel.DisplayName("クローズフラグ")>
    Public Property CLOSE_FLG As String

    <Required>
    <ComponentModel.DisplayName("機種ID")>
    Public Property KISYU_ID As Integer

    <Required>
    <Column(TypeName:="varchar")>
    <StringLength(60)>
    <ComponentModel.DisplayName("部品番号")>
    Public Property BUHIN_BANGO As String

    <Required>
    <Column(TypeName:="nvarchar")>
    <StringLength(1)>
    <ComponentModel.DisplayName("部品名称")>
    Public Property BUHIN_BAME As String

    <Required>
    <Column(TypeName:="char")>
    <StringLength(5)>
    <ComponentModel.DisplayName("号機")>
    Public Property GOKI As String

    <Required>
    <Column(TypeName:="varchar")>
    <StringLength(15)>
    <ComponentModel.DisplayName("LOT")>
    Public Property LOT As String

    <Required>
    <ComponentModel.DisplayName("数量")>
    Public Property SURYO As Integer

    <Required>
    <Column(TypeName:="varchar")>
    <StringLength(10)>
    <ComponentModel.DisplayName("再発")>
    Public Property SAIHATU As String

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
    <ComponentModel.DisplayName("保留理由区分")>
    Public Property HORYU_RIYU_KB As String

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
    <Column(TypeName:="char")>
    <StringLength(1)>
    <ComponentModel.DisplayName("是正処置要否区分")>
    Public Property ZESEI_SYOCHI_YOHI_KB As String

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
    Public Property SYOCHI_KEKKA_A As String

    <Required>
    <Column(TypeName:="char")>
    <StringLength(1)>
    <ComponentModel.DisplayName("処置結果b")>
    Public Property SYOCHI_KEKKA_B As String

    <Required>
    <Column(TypeName:="char")>
    <StringLength(1)>
    <ComponentModel.DisplayName("処置結果c")>
    Public Property SYOCHI_KEKKA_C As String

    <Required>
    <Column(TypeName:="char")>
    <StringLength(1)>
    <ComponentModel.DisplayName("処置d有無区分")>
    Public Property SYOCHI_D_UMU_KB As String

    <Required>
    <Column(TypeName:="char")>
    <StringLength(1)>
    <ComponentModel.DisplayName("処置d要否区分")>
    Public Property SYOCHI_D_YOHI_KB As String

    <Required>
    <Column(TypeName:="nvarchar")>
    <StringLength(100)>
    <ComponentModel.DisplayName("処置d処置記録")>
    Public Property SYOCHI_D_SYOCHI_KIROKU As String

    <Required>
    <Column(TypeName:="char")>
    <StringLength(1)>
    <ComponentModel.DisplayName("処置e有無区分")>
    Public Property SYOCHI_E_UMU_KB As String

    <Required>
    <Column(TypeName:="char")>
    <StringLength(1)>
    <ComponentModel.DisplayName("処置e要否区分")>
    Public Property SYOCHI_E_YOHI_KB As String

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


    ''共通項目------------------------------------
    <Required>
    <StringLength(14)>
    <Display(AutoGenerateField:=False)>
    <Column(TypeName:="char")>
    Public Property ADD_YMDHNS As String

    <Required>
    <Display(AutoGenerateField:=False)>
    Public Property ADD_SYAIN_ID As Integer

    <Required>
    <StringLength(14)>
    <Display(AutoGenerateField:=False)>
    <Column(TypeName:="char")>
    Public Property UPD_YMDHNS As String

    <Required>
    <Display(AutoGenerateField:=False)>
    Public Property UPD_SYAIN_ID As Integer

    <Required>
    <StringLength(14)>
    <Display(AutoGenerateField:=False)>
    <Column(TypeName:="char")>
    Public Property DEL_YMDHNS As String

    <ComponentModel.DisplayName("削除済")>
    <NotMapped>
    Public ReadOnly Property DEL_FLG As Boolean
        Get
            Return DEL_YMDHNS.Trim <> ""
        End Get
    End Property

    <Required>
    <Display(AutoGenerateField:=False)>
    Public Property DEL_SYAIN_ID As Integer
End Class