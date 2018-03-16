Imports System
Imports System.Data.Entity.Migrations
Imports Microsoft.VisualBasic

Namespace Migrations
    Public Partial Class Init4
        Inherits DbMigration

        Public Overrides Sub Up()
            CreateTable(
                "dbo.D003_NCR_J",
                Function(c) New With
                    {
                        .HOKOKU_NO = c.String(nullable:=False, maxLength:=10, fixedLength:=True, unicode:=False),
                        .CLOSE_FLG = c.String(nullable:=False, maxLength:=1, fixedLength:=True, unicode:=False),
                        .KISYU_ID = c.String(nullable:=False, maxLength:=1, fixedLength:=True, unicode:=False),
                        .BUHIN_BANGO = c.String(nullable:=False, maxLength:=1, fixedLength:=True, unicode:=False),
                        .BUHIN_BAME = c.String(nullable:=False, maxLength:=1, fixedLength:=True, unicode:=False),
                        .GOKI = c.String(nullable:=False, maxLength:=1, fixedLength:=True, unicode:=False),
                        .LOT = c.String(nullable:=False, maxLength:=1, fixedLength:=True, unicode:=False),
                        .SURYO = c.String(nullable:=False, maxLength:=1, fixedLength:=True, unicode:=False),
                        .SAIHATU = c.String(nullable:=False, maxLength:=1, fixedLength:=True, unicode:=False),
                        .FUTEKIGO_JYOTAI_KB = c.String(nullable:=False, maxLength:=1, fixedLength:=True, unicode:=False),
                        .FUTEKIGO_NAIYO = c.String(nullable:=False, maxLength:=1, fixedLength:=True, unicode:=False),
                        .HORYU_RIYU_KB = c.String(nullable:=False, maxLength:=1, fixedLength:=True, unicode:=False),
                        .ZUMEN_KIKAKU = c.String(nullable:=False, maxLength:=1, fixedLength:=True, unicode:=False),
                        .YOKYU_NAIYO = c.String(nullable:=False, maxLength:=1, fixedLength:=True, unicode:=False),
                        .KANSATU_KEKKA = c.String(nullable:=False, maxLength:=1, fixedLength:=True, unicode:=False),
                        .ZESEI_SYOCHI_YOHI_KB = c.String(nullable:=False, maxLength:=1, fixedLength:=True, unicode:=False),
                        .ZESEI_NASI_RIYU = c.String(nullable:=False, maxLength:=1, fixedLength:=True, unicode:=False),
                        .JIZEN_SINSA_HANTEI_KB = c.String(nullable:=False, maxLength:=1, fixedLength:=True, unicode:=False),
                        .JIZEN_SINSA_SYAIN_ID = c.String(nullable:=False, maxLength:=1, fixedLength:=True, unicode:=False),
                        .JIZEN_SINSA_YMD = c.String(nullable:=False, maxLength:=1, fixedLength:=True, unicode:=False),
                        .SAISIN_KAKUNIN_SYAIN_ID = c.String(nullable:=False, maxLength:=1, fixedLength:=True, unicode:=False),
                        .SAISIN_KAKUNIN_YMD = c.String(nullable:=False, maxLength:=1, fixedLength:=True, unicode:=False),
                        .SAISIN_IINKAI_HANTEI_KB = c.String(nullable:=False, maxLength:=1, fixedLength:=True, unicode:=False),
                        .SAISIN_GIJYUTU_SYAIN_ID = c.String(nullable:=False, maxLength:=1, fixedLength:=True, unicode:=False),
                        .SAISIN_GIJYUTU_YMD = c.String(nullable:=False, maxLength:=1, fixedLength:=True, unicode:=False),
                        .SAISIN_HINSYO_SYAIN_ID = c.String(nullable:=False, maxLength:=1, fixedLength:=True, unicode:=False),
                        .SAISIN_HINSYO_YMD = c.String(nullable:=False, maxLength:=1, fixedLength:=True, unicode:=False),
                        .SAISIN_IINKAI_SIRYO_NO = c.String(nullable:=False, maxLength:=1, fixedLength:=True, unicode:=False),
                        .ITAG_NO = c.String(nullable:=False, maxLength:=1, fixedLength:=True, unicode:=False),
                        .KOKYAKU_SAISIN_TANTO_ID = c.String(nullable:=False, maxLength:=1, fixedLength:=True, unicode:=False),
                        .KOKYAKU_SAISIN_YMD = c.String(nullable:=False, maxLength:=1, fixedLength:=True, unicode:=False),
                        .KOKYAKU_HANTEI_SIJI_KB = c.String(nullable:=False, maxLength:=1, fixedLength:=True, unicode:=False),
                        .KOKYAKU_HANTEI_SIJI_YMD = c.String(nullable:=False, maxLength:=1, fixedLength:=True, unicode:=False),
                        .KOKYAKU_SAISYU_HANTEI_KB = c.String(nullable:=False, maxLength:=1, fixedLength:=True, unicode:=False),
                        .KOKYAKU_SAISYU_HANTEI_YMD = c.String(nullable:=False, maxLength:=1, fixedLength:=True, unicode:=False),
                        .HAIKYAKU_YMD = c.String(nullable:=False, maxLength:=1, fixedLength:=True, unicode:=False),
                        .HAIKYAKU_KB = c.String(nullable:=False, maxLength:=1, fixedLength:=True, unicode:=False),
                        .HAIKYAKU_HOUHOU = c.String(nullable:=False, maxLength:=1, fixedLength:=True, unicode:=False),
                        .HAIKYAKU_TANTO_ID = c.String(nullable:=False, maxLength:=1, fixedLength:=True, unicode:=False),
                        .SAIKAKO_SIJI_NO = c.String(nullable:=False, maxLength:=1, fixedLength:=True, unicode:=False),
                        .SAIKAKO_SAGYO_KAN_YMD = c.String(nullable:=False, maxLength:=1, fixedLength:=True, unicode:=False),
                        .SAIKAKO_KENSA_YMD = c.String(nullable:=False, maxLength:=1, fixedLength:=True, unicode:=False),
                        .KENSA_KEKKA_KB = c.String(nullable:=False, maxLength:=1, fixedLength:=True, unicode:=False),
                        .SEIGI_TANTO_ID = c.String(nullable:=False, maxLength:=1, fixedLength:=True, unicode:=False),
                        .SEIZO_TANTO_ID = c.String(nullable:=False, maxLength:=1, fixedLength:=True, unicode:=False),
                        .KENSA_TANTO_ID = c.String(nullable:=False, maxLength:=1, fixedLength:=True, unicode:=False),
                        .HENKYAKU_YMD = c.String(nullable:=False, maxLength:=1, fixedLength:=True, unicode:=False),
                        .HENKYAKU_SAKI = c.String(nullable:=False, maxLength:=1, fixedLength:=True, unicode:=False),
                        .HENKYAKU_TANTO_ID = c.String(nullable:=False, maxLength:=1, fixedLength:=True, unicode:=False),
                        .HENKYAKU_BIKO = c.String(nullable:=False, maxLength:=1, fixedLength:=True, unicode:=False),
                        .TENYO_KISYU_ID = c.String(nullable:=False, maxLength:=1, fixedLength:=True, unicode:=False),
                        .TENYO_BUHIN_BANGO = c.String(nullable:=False, maxLength:=1, fixedLength:=True, unicode:=False),
                        .TENYO_GOKI = c.String(nullable:=False, maxLength:=1, fixedLength:=True, unicode:=False),
                        .TENYO_LOT = c.String(nullable:=False, maxLength:=1, fixedLength:=True, unicode:=False),
                        .TENYO_YMD = c.String(nullable:=False, maxLength:=1, fixedLength:=True, unicode:=False),
                        .SYOCHI_KEKKA_A = c.String(nullable:=False, maxLength:=1, fixedLength:=True, unicode:=False),
                        .SYOCHI_KEKKA_B = c.String(nullable:=False, maxLength:=1, fixedLength:=True, unicode:=False),
                        .SYOCHI_KEKKA_C = c.String(nullable:=False, maxLength:=1, fixedLength:=True, unicode:=False),
                        .SYOCHI_D_UMU_KB = c.String(nullable:=False, maxLength:=1, fixedLength:=True, unicode:=False),
                        .SYOCHI_D_YOHI_KB = c.String(nullable:=False, maxLength:=1, fixedLength:=True, unicode:=False),
                        .SYOCHI_D_SYOCHI_KIROKU = c.String(nullable:=False, maxLength:=1, fixedLength:=True, unicode:=False),
                        .SYOCHI_E_UMU_KB = c.String(nullable:=False, maxLength:=1, fixedLength:=True, unicode:=False),
                        .SYOCHI_E_YOHI_KB = c.String(nullable:=False, maxLength:=1, fixedLength:=True, unicode:=False),
                        .SYOCHI_E_SYOCHI_KIROKU = c.String(nullable:=False, maxLength:=1, fixedLength:=True, unicode:=False),
                        .FILE_PATH = c.String(nullable:=False, maxLength:=1, fixedLength:=True, unicode:=False),
                        .G_FILE_PATH1 = c.String(nullable:=False, maxLength:=1, fixedLength:=True, unicode:=False),
                        .G_FILE_PATH2 = c.String(nullable:=False, maxLength:=1, fixedLength:=True, unicode:=False),
                        .ADD_YMDHNS = c.String(nullable:=False, maxLength:=14, fixedLength:=True, unicode:=False),
                        .ADD_SYAIN_ID = c.Int(nullable:=False),
                        .UPD_YMDHNS = c.String(nullable:=False, maxLength:=14, fixedLength:=True, unicode:=False),
                        .UPD_SYAIN_ID = c.Int(nullable:=False),
                        .DEL_YMDHNS = c.String(nullable:=False, maxLength:=14, fixedLength:=True, unicode:=False),
                        .DEL_SYAIN_ID = c.Int(nullable:=False)
                    }) _
                .PrimaryKey(Function(t) t.HOKOKU_NO)


        End Sub

        Public Overrides Sub Down()
            DropColumn("dbo.M013_SYONIN_HOKOKU", "BUMON_KB")
            DropTable("dbo.D003_NCR_J")
        End Sub
    End Class
End Namespace
