Imports System.ComponentModel.DataAnnotations
Imports System.ComponentModel.DataAnnotations.Schema


Partial Public Class V002_NCR_J

    Public Sub New()
        Call Clear()
    End Sub


    Public Sub Clear()
        ZESEI_SYOCHI_YOHI_KB = "0"
    End Sub

    'UNDONE: 他のモデルにもインデクサプロパティを実装する

    'インデクサプロパティ
    <ComponentModel.DataAnnotations.Display(AutoGenerateField:=False)>
    Default Public Property Item(ByVal propertyName As String) As Object
        Get
            Return GetType(V002_NCR_J).GetProperty(propertyName).GetValue(Me)
        End Get
        Set(value As Object)
            GetType(V002_NCR_J).GetProperty(propertyName).SetValue(Me, value)
        End Set
    End Property

    <StringLength(10)>
    Public Property HOKOKU_NO As String

    <StringLength(1)>
    Public Property BUMON_KB As String

    <StringLength(30)>
    Public Property BUMON_NAME As String

    <StringLength(1)>
    Public Property CLOSE_FG As String

    Public Property KISYU_ID As Integer

    <StringLength(30)>
    Public Property KISYU As String

    <StringLength(30)>
    Public Property KISYU_NAME As String

    <StringLength(30)>
    Public Property SYANAI_CD As String

    <StringLength(60)>
    Public Property BUHIN_BANGO As String

    <StringLength(1)>
    Public Property BUHIN_NAME As String

    <StringLength(5)>
    Public Property GOKI As String

    Public Property SURYO As Integer

    <StringLength(10)>
    Public Property SAIHATU As String

    <StringLength(1)>
    Public Property FUTEKIGO_JYOTAI_KB As String

    <StringLength(30)>
    Public Property FUTEKIGO_JYOTAI_NAME As String

    <StringLength(30)>
    Public Property FUTEKIGO_NAIYO As String

    Public Property FUTEKIGO_KB As String

    Public Property FUTEKIGO_NAME As String

    Public Property FUTEKIGO_S_KB As String

    Public Property FUTEKIGO_S_NAME As String


    <StringLength(30)>
    Public Property ZUMEN_KIKAKU As String

    <StringLength(500)>
    Public Property YOKYU_NAIYO As String

    <StringLength(500)>
    Public Property KANSATU_KEKKA As String

    <StringLength(1)>
    Public Property ZESEI_SYOCHI_YOHI_KB As String

    <StringLength(100)>
    Public Property ZESEI_NASI_RIYU As String

    <StringLength(1)>
    Public Property JIZEN_SINSA_HANTEI_KB As String

    Public Property JIZEN_SINSA_SYAIN_ID As Integer

    <StringLength(30)>
    Public Property JIZEN_SINSA_SYAIN_NAME As String

    <StringLength(8)>
    Public Property JIZEN_SINSA_YMD As String

    Public Property SAISIN_KAKUNIN_SYAIN_ID As Integer

    <StringLength(30)>
    Public Property SAISIN_KAKUNIN_SYAIN_NAME As String

    <StringLength(8)>
    Public Property SAISIN_KAKUNIN_YMD As String

    <StringLength(1)>
    Public Property SAISIN_IINKAI_HANTEI_KB As String

    Public Property SAISIN_GIJYUTU_SYAIN_ID As Integer

    <StringLength(30)>
    Public Property SAISIN_GIJYUTU_SYAIN_NAME As String

    <StringLength(8)>
    Public Property SAISIN_GIJYUTU_YMD As String

    Public Property SAISIN_HINSYO_SYAIN_ID As Integer

    <StringLength(30)>
    Public Property SAISIN_HINSYO_SYAIN_NAME As String

    <StringLength(8)>
    Public Property SAISIN_HINSYO_YMD As String

    <StringLength(2)>
    Public Property SAISIN_IINKAI_SIRYO_NO As String

    <StringLength(20)>
    Public Property ITAG_NO As String

    Public Property KOKYAKU_SAISIN_TANTO_ID As Integer

    <StringLength(30)>
    Public Property KOKYAKU_SAISIN_TANTO_NAME As String

    <StringLength(8)>
    Public Property KOKYAKU_SAISIN_YMD As String

    <StringLength(1)>
    Public Property KOKYAKU_HANTEI_SIJI_KB As String

    <StringLength(50)>
    Public Property KOKYAKU_HANTEI_SIJI_NAME As String

    <StringLength(8)>
    Public Property KOKYAKU_HANTEI_SIJI_YMD As String

    <StringLength(1)>
    Public Property KOKYAKU_SAISYU_HANTEI_KB As String

    <StringLength(30)>
    Public Property KOKYAKU_SAISYU_HANTEI_NAME As String

    <StringLength(8)>
    Public Property KOKYAKU_SAISYU_HANTEI_YMD As String

    <StringLength(8)>
    Public Property HAIKYAKU_YMD As String

    <StringLength(1)>
    Public Property HAIKYAKU_KB As String

    <StringLength(30)>
    Public Property HAIKYAKU_KB_NAME As String

    <StringLength(30)>
    Public Property HAIKYAKU_HOUHOU As String

    Public Property HAIKYAKU_TANTO_ID As Integer

    <StringLength(30)>
    Public Property HAIKYAKU_TANTO_NAME As String

    <StringLength(10)>
    Public Property SAIKAKO_SIJI_NO As String

    Public Property SAIKAKO_SIJI_FG As String

    <StringLength(8)>
    Public Property SAIKAKO_SAGYO_KAN_YMD As String

    <StringLength(8)>
    Public Property SAIKAKO_KENSA_YMD As String

    <StringLength(1)>
    Public Property KENSA_KEKKA_KB As String

    <StringLength(50)>
    Public Property KENSA_KEKKA_NAME As String

    Public Property SEIGI_TANTO_ID As Integer

    <StringLength(30)>
    Public Property SEIGI_TANTO_NAME As String

    <StringLength(8)>
    Public Property SEIGI_KAKUNIN_YMD As String

    Public Property SEIZO_TANTO_ID As Integer

    <StringLength(30)>
    Public Property SEIZO_TANTO_NAME As String

    <StringLength(8)>
    Public Property SEIZO_KAKUNIN_YMD As String

    Public Property KENSA_TANTO_ID As Integer

    <StringLength(30)>
    Public Property KENSA_TANTO_NAME As String

    <StringLength(8)>
    Public Property KENSA_KAKUNIN_YMD As String

    <StringLength(8)>
    Public Property HENKYAKU_YMD As String

    <StringLength(60)>
    Public Property HENKYAKU_SAKI As String

    Public Property HENKYAKU_TANTO_ID As Integer

    <StringLength(30)>
    Public Property HENKYAKU_TANTO_NAME As String

    <StringLength(100)>
    Public Property HENKYAKU_BIKO As String

    Public Property TENYO_KISYU_ID As Integer

    <StringLength(50)>
    Public Property TENYO_KISYU As String

    <StringLength(60)>
    Public Property TENYO_BUHIN_BANGO As String

    <StringLength(5)>
    Public Property TENYO_GOKI As String

    Public Property TENYO_LOT As Integer

    <StringLength(8)>
    Public Property TENYO_YMD As String

    <StringLength(1)>
    Public Property SYOCHI_KEKKA_A As String

    <StringLength(50)>
    Public Property SYOCHI_KEKKA_A_NAME As String

    <StringLength(1)>
    Public Property SYOCHI_KEKKA_B As String

    <StringLength(50)>
    Public Property SYOCHI_KEKKA_B_NAME As String

    <StringLength(1)>
    Public Property SYOCHI_KEKKA_C As String

    <StringLength(50)>
    Public Property SYOCHI_KEKKA_C_NAME As String

    <StringLength(1)>
    Public Property SYOCHI_D_UMU_KB As String

    <StringLength(10)>
    Public Property SYOCHI_D_UMU_NAME As String

    <StringLength(1)>
    Public Property SYOCHI_D_YOHI_KB As String

    <StringLength(10)>
    Public Property SYOCHI_D_YOHI_NAME As String

    <StringLength(100)>
    Public Property SYOCHI_D_SYOCHI_KIROKU As String

    <StringLength(1)>
    Public Property SYOCHI_E_UMU_KB As String

    <StringLength(10)>
    Public Property SYOCHI_E_UMU_NAME As String

    <StringLength(1)>
    Public Property SYOCHI_E_YOHI_KB As String

    <StringLength(10)>
    Public Property SYOCHI_E_YOHI_NAME As String

    <StringLength(100)>
    Public Property SYOCHI_E_SYOCHI_KIROKU As String

    <StringLength(200)>
    Public Property FILE_PATH As String

    <StringLength(200)>
    Public Property G_FILE_PATH1 As String

    <StringLength(200)>
    Public Property G_FILE_PATH2 As String

    Public Property HASSEI_KOTEI_GL_SYAIN_ID As Integer

    <StringLength(14)>
    Public Property ADD_YMDHNS As String

    <Display(AutoGenerateField:=False)>
    <NotMapped>
    Public ReadOnly Property ADD_YMD As String
        Get
            Dim strRET As String
            If ADD_YMDHNS IsNot Nothing AndAlso ADD_YMDHNS.Length = 14 Then
                strRET = DateTime.ParseExact(ADD_YMDHNS, "yyyyMMddHHmmss", Nothing).ToString("yyyyMMdd")
            Else
                strRET = ""
            End If
            Return strRET
        End Get
    End Property

    Public Property ADD_SYAIN_ID As Integer

    <StringLength(30)>
    Public Property ADD_SYAIN_NAME As String

    <StringLength(14)>
    Public Property UPD_YMDHNS As String

    Public Property UPD_SYAIN_ID As Integer

    <StringLength(30)>
    Public Property UPD_SYAIN_NAME As String

    <StringLength(14)>
    Public Property DEL_YMDHNS As String

    Public Property DEL_SYAIN_ID As Integer

    <StringLength(30)>
    Public Property DEL_SYAIN_NAME As String

    <StringLength(14)>
    Public Property HASSEI_KOTEI_GL_YMD As String

    <StringLength(30)>
    Public Property HASSEI_KOTEI_GL_SYAIN_NAME As String



End Class
