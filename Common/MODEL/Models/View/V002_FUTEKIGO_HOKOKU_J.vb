Imports System
Imports System.Collections.Generic
Imports System.ComponentModel.DataAnnotations
Imports System.ComponentModel.DataAnnotations.Schema
Imports System.Data.Entity.Spatial

Partial Public Class V002_FUTEKIGO_HOKOKU_J
    <Key>
    <Column(Order:=0)>
    <StringLength(10)>
    Public Property HOKOKU_NO As String

    <Key>
    <Column(Order:=1)>
    <StringLength(1)>
    Public Property CLOSE_FLG As String

    <Key>
    <Column(Order:=2)>
    <DatabaseGenerated(DatabaseGeneratedOption.None)>
    Public Property KISYU_ID As Integer

    <StringLength(30)>
    Public Property KISYU As String

    <StringLength(30)>
    Public Property KISYU_NAME As String

    <Key>
    <Column(Order:=3)>
    <StringLength(60)>
    Public Property BUHIN_BANGO As String

    <Key>
    <Column(Order:=4)>
    <StringLength(1)>
    Public Property BUHIN_BAME As String

    <Key>
    <Column(Order:=5)>
    <StringLength(5)>
    Public Property GOKI As String

    <Key>
    <Column(Order:=6)>
    <StringLength(15)>
    Public Property LOT As String

    <Key>
    <Column(Order:=7)>
    <DatabaseGenerated(DatabaseGeneratedOption.None)>
    Public Property SURYO As Integer

    <Key>
    <Column(Order:=8)>
    <StringLength(10)>
    Public Property SAIHATU As String

    <Key>
    <Column(Order:=9)>
    <StringLength(1)>
    Public Property FUTEKIGO_JYOTAI_KB As String

    <Key>
    <Column(Order:=10)>
    <StringLength(30)>
    Public Property FUTEKIGO_NAIYO As String

    <Key>
    <Column(Order:=11)>
    <StringLength(1)>
    Public Property HORYU_RIYU_KB As String

    <Key>
    <Column(Order:=12)>
    <StringLength(30)>
    Public Property ZUMEN_KIKAKU As String

    <Key>
    <Column(Order:=13)>
    <StringLength(500)>
    Public Property YOKYU_NAIYO As String

    <Key>
    <Column(Order:=14)>
    <StringLength(500)>
    Public Property KANSATU_KEKKA As String

    <Key>
    <Column(Order:=15)>
    <StringLength(1)>
    Public Property ZESEI_SYOCHI_YOHI_KB As String

    <Key>
    <Column(Order:=16)>
    <StringLength(100)>
    Public Property ZESEI_NASI_RIYU As String

    <Key>
    <Column(Order:=17)>
    <StringLength(1)>
    Public Property JIZEN_SINSA_HANTEI_KB As String

    <Key>
    <Column(Order:=18)>
    <DatabaseGenerated(DatabaseGeneratedOption.None)>
    Public Property JIZEN_SINSA_SYAIN_ID As Integer

    <Key>
    <Column(Order:=19)>
    <StringLength(8)>
    Public Property JIZEN_SINSA_YMD As String

    <Key>
    <Column(Order:=20)>
    <DatabaseGenerated(DatabaseGeneratedOption.None)>
    Public Property SAISIN_KAKUNIN_SYAIN_ID As Integer

    <Key>
    <Column(Order:=21)>
    <StringLength(8)>
    Public Property SAISIN_KAKUNIN_YMD As String

    <Key>
    <Column(Order:=22)>
    <StringLength(1)>
    Public Property SAISIN_IINKAI_HANTEI_KB As String

    <Key>
    <Column(Order:=23)>
    <DatabaseGenerated(DatabaseGeneratedOption.None)>
    Public Property SAISIN_GIJYUTU_SYAIN_ID As Integer

    <Key>
    <Column(Order:=24)>
    <StringLength(8)>
    Public Property SAISIN_GIJYUTU_YMD As String

    <Key>
    <Column(Order:=25)>
    <DatabaseGenerated(DatabaseGeneratedOption.None)>
    Public Property SAISIN_HINSYO_SYAIN_ID As Integer

    <Key>
    <Column(Order:=26)>
    <StringLength(8)>
    Public Property SAISIN_HINSYO_YMD As String

    <Key>
    <Column(Order:=27)>
    <StringLength(2)>
    Public Property SAISIN_IINKAI_SIRYO_NO As String

    <Key>
    <Column(Order:=28)>
    <StringLength(20)>
    Public Property ITAG_NO As String

    <Key>
    <Column(Order:=29)>
    <DatabaseGenerated(DatabaseGeneratedOption.None)>
    Public Property KOKYAKU_SAISIN_TANTO_ID As Integer

    <Key>
    <Column(Order:=30)>
    <StringLength(8)>
    Public Property KOKYAKU_SAISIN_YMD As String

    <Key>
    <Column(Order:=31)>
    <StringLength(1)>
    Public Property KOKYAKU_HANTEI_SIJI_KB As String

    <Key>
    <Column(Order:=32)>
    <StringLength(8)>
    Public Property KOKYAKU_HANTEI_SIJI_YMD As String

    <Key>
    <Column(Order:=33)>
    <StringLength(1)>
    Public Property KOKYAKU_SAISYU_HANTEI_KB As String

    <Key>
    <Column(Order:=34)>
    <StringLength(8)>
    Public Property KOKYAKU_SAISYU_HANTEI_YMD As String

    <Key>
    <Column(Order:=35)>
    <StringLength(8)>
    Public Property HAIKYAKU_YMD As String

    <Key>
    <Column(Order:=36)>
    <StringLength(1)>
    Public Property HAIKYAKU_KB As String

    <Key>
    <Column(Order:=37)>
    <StringLength(30)>
    Public Property HAIKYAKU_HOUHOU As String

    <Key>
    <Column(Order:=38)>
    <DatabaseGenerated(DatabaseGeneratedOption.None)>
    Public Property HAIKYAKU_TANTO_ID As Integer

    <Key>
    <Column(Order:=39)>
    <StringLength(10)>
    Public Property SAIKAKO_SIJI_NO As String

    <Key>
    <Column(Order:=40)>
    <StringLength(8)>
    Public Property SAIKAKO_SAGYO_KAN_YMD As String

    <Key>
    <Column(Order:=41)>
    <StringLength(8)>
    Public Property SAIKAKO_KENSA_YMD As String

    <Key>
    <Column(Order:=42)>
    <StringLength(1)>
    Public Property KENSA_KEKKA_KB As String

    <Key>
    <Column(Order:=43)>
    <DatabaseGenerated(DatabaseGeneratedOption.None)>
    Public Property SEIGI_TANTO_ID As Integer

    <Key>
    <Column(Order:=44)>
    <DatabaseGenerated(DatabaseGeneratedOption.None)>
    Public Property SEIZO_TANTO_ID As Integer

    <Key>
    <Column(Order:=45)>
    <DatabaseGenerated(DatabaseGeneratedOption.None)>
    Public Property KENSA_TANTO_ID As Integer

    <Key>
    <Column(Order:=46)>
    <StringLength(8)>
    Public Property HENKYAKU_YMD As String

    <Key>
    <Column(Order:=47)>
    <StringLength(60)>
    Public Property HENKYAKU_SAKI As String

    <Key>
    <Column(Order:=48)>
    <DatabaseGenerated(DatabaseGeneratedOption.None)>
    Public Property HENKYAKU_TANTO_ID As Integer

    <Key>
    <Column(Order:=49)>
    <StringLength(100)>
    Public Property HENKYAKU_BIKO As String

    <Key>
    <Column(Order:=50)>
    <DatabaseGenerated(DatabaseGeneratedOption.None)>
    Public Property TENYO_KISYU_ID As Integer

    <Key>
    <Column(Order:=51)>
    <StringLength(60)>
    Public Property TENYO_BUHIN_BANGO As String

    <Key>
    <Column(Order:=52)>
    <StringLength(5)>
    Public Property TENYO_GOKI As String

    <Key>
    <Column(Order:=53)>
    <DatabaseGenerated(DatabaseGeneratedOption.None)>
    Public Property TENYO_LOT As Integer

    <Key>
    <Column(Order:=54)>
    <StringLength(8)>
    Public Property TENYO_YMD As String

    <Key>
    <Column(Order:=55)>
    <StringLength(1)>
    Public Property SYOCHI_KEKKA_A As String

    <Key>
    <Column(Order:=56)>
    <StringLength(1)>
    Public Property SYOCHI_KEKKA_B As String

    <Key>
    <Column(Order:=57)>
    <StringLength(1)>
    Public Property SYOCHI_KEKKA_C As String

    <Key>
    <Column(Order:=58)>
    <StringLength(1)>
    Public Property SYOCHI_D_UMU_KB As String

    <Key>
    <Column(Order:=59)>
    <StringLength(1)>
    Public Property SYOCHI_D_YOHI_KB As String

    <Key>
    <Column(Order:=60)>
    <StringLength(100)>
    Public Property SYOCHI_D_SYOCHI_KIROKU As String

    <Key>
    <Column(Order:=61)>
    <StringLength(1)>
    Public Property SYOCHI_E_UMU_KB As String

    <Key>
    <Column(Order:=62)>
    <StringLength(1)>
    Public Property SYOCHI_E_YOHI_KB As String

    <Key>
    <Column(Order:=63)>
    <StringLength(100)>
    Public Property SYOCHI_E_SYOCHI_KIROKU As String

    <Key>
    <Column(Order:=64)>
    <StringLength(200)>
    Public Property FILE_PATH As String

    <Key>
    <Column(Order:=65)>
    <StringLength(200)>
    Public Property G_FILE_PATH1 As String

    <Key>
    <Column(Order:=66)>
    <StringLength(200)>
    Public Property G_FILE_PATH2 As String

    <Key>
    <Column(Order:=67)>
    <StringLength(14)>
    Public Property ADD_YMDHNS As String

    <Key>
    <Column(Order:=68)>
    <DatabaseGenerated(DatabaseGeneratedOption.None)>
    Public Property ADD_SYAIN_ID As Integer

    <StringLength(30)>
    Public Property ADD_SYAIN_NAME As String

    <Key>
    <Column(Order:=69)>
    <StringLength(14)>
    Public Property UPD_YMDHNS As String

    <Key>
    <Column(Order:=70)>
    <DatabaseGenerated(DatabaseGeneratedOption.None)>
    Public Property UPD_SYAIN_ID As Integer

    <StringLength(30)>
    Public Property UPD_SYAIN_NAME As String

    <Key>
    <Column(Order:=71)>
    <StringLength(14)>
    Public Property DEL_YMDHNS As String

    <Key>
    <Column(Order:=72)>
    <DatabaseGenerated(DatabaseGeneratedOption.None)>
    Public Property DEL_SYAIN_ID As Integer

    <StringLength(30)>
    Public Property DEL_SYAIN_NAME As String

    <Key>
    <Column(Order:=73)>
    <StringLength(1)>
    Public Property DEL_FLG As String
End Class
