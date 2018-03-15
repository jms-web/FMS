Imports System
Imports System.Data.Entity.Migrations
Imports Microsoft.VisualBasic

Namespace Migrations
    Public Partial Class Init5
        Inherits DbMigration
    
        Public Overrides Sub Up()
            AlterColumn("dbo.D003_NCR_J", "KISYU_ID", Function(c) c.Int(nullable := False))
            AlterColumn("dbo.D003_NCR_J", "BUHIN_BANGO", Function(c) c.String(nullable := False, maxLength := 60, unicode := false))
            AlterColumn("dbo.D003_NCR_J", "BUHIN_BAME", Function(c) c.String(nullable := False, maxLength := 1))
            AlterColumn("dbo.D003_NCR_J", "GOKI", Function(c) c.String(nullable := False, maxLength := 5, fixedLength := true, unicode := false))
            AlterColumn("dbo.D003_NCR_J", "LOT", Function(c) c.String(nullable := False, maxLength := 15, unicode := false))
            AlterColumn("dbo.D003_NCR_J", "SURYO", Function(c) c.Int(nullable := False))
            AlterColumn("dbo.D003_NCR_J", "SAIHATU", Function(c) c.String(nullable := False, maxLength := 10, unicode := false))
            AlterColumn("dbo.D003_NCR_J", "FUTEKIGO_NAIYO", Function(c) c.String(nullable := False, maxLength := 30))
            AlterColumn("dbo.D003_NCR_J", "ZUMEN_KIKAKU", Function(c) c.String(nullable := False, maxLength := 30))
            AlterColumn("dbo.D003_NCR_J", "YOKYU_NAIYO", Function(c) c.String(nullable := False, maxLength := 500))
            AlterColumn("dbo.D003_NCR_J", "KANSATU_KEKKA", Function(c) c.String(nullable := False, maxLength := 500))
            AlterColumn("dbo.D003_NCR_J", "ZESEI_NASI_RIYU", Function(c) c.String(nullable := False, maxLength := 100))
            AlterColumn("dbo.D003_NCR_J", "JIZEN_SINSA_SYAIN_ID", Function(c) c.Int(nullable := False))
            AlterColumn("dbo.D003_NCR_J", "JIZEN_SINSA_YMD", Function(c) c.String(nullable := False, maxLength := 8, fixedLength := true, unicode := false))
            AlterColumn("dbo.D003_NCR_J", "SAISIN_KAKUNIN_SYAIN_ID", Function(c) c.Int(nullable := False))
            AlterColumn("dbo.D003_NCR_J", "SAISIN_KAKUNIN_YMD", Function(c) c.String(nullable := False, maxLength := 8, fixedLength := true, unicode := false))
            AlterColumn("dbo.D003_NCR_J", "SAISIN_GIJYUTU_SYAIN_ID", Function(c) c.Int(nullable := False))
            AlterColumn("dbo.D003_NCR_J", "SAISIN_GIJYUTU_YMD", Function(c) c.String(nullable := False, maxLength := 8, fixedLength := true, unicode := false))
            AlterColumn("dbo.D003_NCR_J", "SAISIN_HINSYO_SYAIN_ID", Function(c) c.Int(nullable := False))
            AlterColumn("dbo.D003_NCR_J", "SAISIN_HINSYO_YMD", Function(c) c.String(nullable := False, maxLength := 8, fixedLength := true, unicode := false))
            AlterColumn("dbo.D003_NCR_J", "SAISIN_IINKAI_SIRYO_NO", Function(c) c.String(nullable := False, maxLength := 2, fixedLength := true, unicode := false))
            AlterColumn("dbo.D003_NCR_J", "ITAG_NO", Function(c) c.String(nullable := False, maxLength := 20))
            AlterColumn("dbo.D003_NCR_J", "KOKYAKU_SAISIN_TANTO_ID", Function(c) c.Int(nullable := False))
            AlterColumn("dbo.D003_NCR_J", "KOKYAKU_SAISIN_YMD", Function(c) c.String(nullable := False, maxLength := 8, fixedLength := true, unicode := false))
            AlterColumn("dbo.D003_NCR_J", "KOKYAKU_HANTEI_SIJI_YMD", Function(c) c.String(nullable := False, maxLength := 8, fixedLength := true, unicode := false))
            AlterColumn("dbo.D003_NCR_J", "KOKYAKU_SAISYU_HANTEI_YMD", Function(c) c.String(nullable := False, maxLength := 8, fixedLength := true, unicode := false))
            AlterColumn("dbo.D003_NCR_J", "HAIKYAKU_YMD", Function(c) c.String(nullable := False, maxLength := 8, fixedLength := true, unicode := false))
            AlterColumn("dbo.D003_NCR_J", "HAIKYAKU_HOUHOU", Function(c) c.String(nullable := False, maxLength := 30))
            AlterColumn("dbo.D003_NCR_J", "HAIKYAKU_TANTO_ID", Function(c) c.Int(nullable := False))
            AlterColumn("dbo.D003_NCR_J", "SAIKAKO_SIJI_NO", Function(c) c.String(nullable := False, maxLength := 10, fixedLength := true, unicode := false))
            AlterColumn("dbo.D003_NCR_J", "SAIKAKO_SAGYO_KAN_YMD", Function(c) c.String(nullable := False, maxLength := 8, fixedLength := true, unicode := false))
            AlterColumn("dbo.D003_NCR_J", "SAIKAKO_KENSA_YMD", Function(c) c.String(nullable := False, maxLength := 8, fixedLength := true, unicode := false))
            AlterColumn("dbo.D003_NCR_J", "SEIGI_TANTO_ID", Function(c) c.Int(nullable := False))
            AlterColumn("dbo.D003_NCR_J", "SEIZO_TANTO_ID", Function(c) c.Int(nullable := False))
            AlterColumn("dbo.D003_NCR_J", "KENSA_TANTO_ID", Function(c) c.Int(nullable := False))
            AlterColumn("dbo.D003_NCR_J", "HENKYAKU_YMD", Function(c) c.String(nullable := False, maxLength := 8, fixedLength := true, unicode := false))
            AlterColumn("dbo.D003_NCR_J", "HENKYAKU_SAKI", Function(c) c.String(nullable := False, maxLength := 60))
            AlterColumn("dbo.D003_NCR_J", "HENKYAKU_TANTO_ID", Function(c) c.Int(nullable := False))
            AlterColumn("dbo.D003_NCR_J", "HENKYAKU_BIKO", Function(c) c.String(nullable := False, maxLength := 100))
            AlterColumn("dbo.D003_NCR_J", "TENYO_KISYU_ID", Function(c) c.Int(nullable := False))
            AlterColumn("dbo.D003_NCR_J", "TENYO_BUHIN_BANGO", Function(c) c.String(nullable := False, maxLength := 60, unicode := false))
            AlterColumn("dbo.D003_NCR_J", "TENYO_GOKI", Function(c) c.String(nullable := False, maxLength := 5, unicode := false))
            AlterColumn("dbo.D003_NCR_J", "TENYO_LOT", Function(c) c.Int(nullable := False))
            AlterColumn("dbo.D003_NCR_J", "TENYO_YMD", Function(c) c.String(nullable := False, maxLength := 8, fixedLength := true, unicode := false))
            AlterColumn("dbo.D003_NCR_J", "SYOCHI_D_SYOCHI_KIROKU", Function(c) c.String(nullable := False, maxLength := 100))
            AlterColumn("dbo.D003_NCR_J", "SYOCHI_E_SYOCHI_KIROKU", Function(c) c.String(nullable := False, maxLength := 100))
            AlterColumn("dbo.D003_NCR_J", "FILE_PATH", Function(c) c.String(nullable := False, maxLength := 200))
            AlterColumn("dbo.D003_NCR_J", "G_FILE_PATH1", Function(c) c.String(nullable := False, maxLength := 200))
            AlterColumn("dbo.D003_NCR_J", "G_FILE_PATH2", Function(c) c.String(nullable := False, maxLength := 200))
        End Sub
        
        Public Overrides Sub Down()
            AlterColumn("dbo.D003_NCR_J", "G_FILE_PATH2", Function(c) c.String(nullable := False, maxLength := 1, fixedLength := true, unicode := false))
            AlterColumn("dbo.D003_NCR_J", "G_FILE_PATH1", Function(c) c.String(nullable := False, maxLength := 1, fixedLength := true, unicode := false))
            AlterColumn("dbo.D003_NCR_J", "FILE_PATH", Function(c) c.String(nullable := False, maxLength := 1, fixedLength := true, unicode := false))
            AlterColumn("dbo.D003_NCR_J", "SYOCHI_E_SYOCHI_KIROKU", Function(c) c.String(nullable := False, maxLength := 1, fixedLength := true, unicode := false))
            AlterColumn("dbo.D003_NCR_J", "SYOCHI_D_SYOCHI_KIROKU", Function(c) c.String(nullable := False, maxLength := 1, fixedLength := true, unicode := false))
            AlterColumn("dbo.D003_NCR_J", "TENYO_YMD", Function(c) c.String(nullable := False, maxLength := 1, fixedLength := true, unicode := false))
            AlterColumn("dbo.D003_NCR_J", "TENYO_LOT", Function(c) c.String(nullable := False, maxLength := 1, fixedLength := true, unicode := false))
            AlterColumn("dbo.D003_NCR_J", "TENYO_GOKI", Function(c) c.String(nullable := False, maxLength := 1, fixedLength := true, unicode := false))
            AlterColumn("dbo.D003_NCR_J", "TENYO_BUHIN_BANGO", Function(c) c.String(nullable := False, maxLength := 1, fixedLength := true, unicode := false))
            AlterColumn("dbo.D003_NCR_J", "TENYO_KISYU_ID", Function(c) c.String(nullable := False, maxLength := 1, fixedLength := true, unicode := false))
            AlterColumn("dbo.D003_NCR_J", "HENKYAKU_BIKO", Function(c) c.String(nullable := False, maxLength := 1, fixedLength := true, unicode := false))
            AlterColumn("dbo.D003_NCR_J", "HENKYAKU_TANTO_ID", Function(c) c.String(nullable := False, maxLength := 1, fixedLength := true, unicode := false))
            AlterColumn("dbo.D003_NCR_J", "HENKYAKU_SAKI", Function(c) c.String(nullable := False, maxLength := 1, fixedLength := true, unicode := false))
            AlterColumn("dbo.D003_NCR_J", "HENKYAKU_YMD", Function(c) c.String(nullable := False, maxLength := 1, fixedLength := true, unicode := false))
            AlterColumn("dbo.D003_NCR_J", "KENSA_TANTO_ID", Function(c) c.String(nullable := False, maxLength := 1, fixedLength := true, unicode := false))
            AlterColumn("dbo.D003_NCR_J", "SEIZO_TANTO_ID", Function(c) c.String(nullable := False, maxLength := 1, fixedLength := true, unicode := false))
            AlterColumn("dbo.D003_NCR_J", "SEIGI_TANTO_ID", Function(c) c.String(nullable := False, maxLength := 1, fixedLength := true, unicode := false))
            AlterColumn("dbo.D003_NCR_J", "SAIKAKO_KENSA_YMD", Function(c) c.String(nullable := False, maxLength := 1, fixedLength := true, unicode := false))
            AlterColumn("dbo.D003_NCR_J", "SAIKAKO_SAGYO_KAN_YMD", Function(c) c.String(nullable := False, maxLength := 1, fixedLength := true, unicode := false))
            AlterColumn("dbo.D003_NCR_J", "SAIKAKO_SIJI_NO", Function(c) c.String(nullable := False, maxLength := 1, fixedLength := true, unicode := false))
            AlterColumn("dbo.D003_NCR_J", "HAIKYAKU_TANTO_ID", Function(c) c.String(nullable := False, maxLength := 1, fixedLength := true, unicode := false))
            AlterColumn("dbo.D003_NCR_J", "HAIKYAKU_HOUHOU", Function(c) c.String(nullable := False, maxLength := 1, fixedLength := true, unicode := false))
            AlterColumn("dbo.D003_NCR_J", "HAIKYAKU_YMD", Function(c) c.String(nullable := False, maxLength := 1, fixedLength := true, unicode := false))
            AlterColumn("dbo.D003_NCR_J", "KOKYAKU_SAISYU_HANTEI_YMD", Function(c) c.String(nullable := False, maxLength := 1, fixedLength := true, unicode := false))
            AlterColumn("dbo.D003_NCR_J", "KOKYAKU_HANTEI_SIJI_YMD", Function(c) c.String(nullable := False, maxLength := 1, fixedLength := true, unicode := false))
            AlterColumn("dbo.D003_NCR_J", "KOKYAKU_SAISIN_YMD", Function(c) c.String(nullable := False, maxLength := 1, fixedLength := true, unicode := false))
            AlterColumn("dbo.D003_NCR_J", "KOKYAKU_SAISIN_TANTO_ID", Function(c) c.String(nullable := False, maxLength := 1, fixedLength := true, unicode := false))
            AlterColumn("dbo.D003_NCR_J", "ITAG_NO", Function(c) c.String(nullable := False, maxLength := 1, fixedLength := true, unicode := false))
            AlterColumn("dbo.D003_NCR_J", "SAISIN_IINKAI_SIRYO_NO", Function(c) c.String(nullable := False, maxLength := 1, fixedLength := true, unicode := false))
            AlterColumn("dbo.D003_NCR_J", "SAISIN_HINSYO_YMD", Function(c) c.String(nullable := False, maxLength := 1, fixedLength := true, unicode := false))
            AlterColumn("dbo.D003_NCR_J", "SAISIN_HINSYO_SYAIN_ID", Function(c) c.String(nullable := False, maxLength := 1, fixedLength := true, unicode := false))
            AlterColumn("dbo.D003_NCR_J", "SAISIN_GIJYUTU_YMD", Function(c) c.String(nullable := False, maxLength := 1, fixedLength := true, unicode := false))
            AlterColumn("dbo.D003_NCR_J", "SAISIN_GIJYUTU_SYAIN_ID", Function(c) c.String(nullable := False, maxLength := 1, fixedLength := true, unicode := false))
            AlterColumn("dbo.D003_NCR_J", "SAISIN_KAKUNIN_YMD", Function(c) c.String(nullable := False, maxLength := 1, fixedLength := true, unicode := false))
            AlterColumn("dbo.D003_NCR_J", "SAISIN_KAKUNIN_SYAIN_ID", Function(c) c.String(nullable := False, maxLength := 1, fixedLength := true, unicode := false))
            AlterColumn("dbo.D003_NCR_J", "JIZEN_SINSA_YMD", Function(c) c.String(nullable := False, maxLength := 1, fixedLength := true, unicode := false))
            AlterColumn("dbo.D003_NCR_J", "JIZEN_SINSA_SYAIN_ID", Function(c) c.String(nullable := False, maxLength := 1, fixedLength := true, unicode := false))
            AlterColumn("dbo.D003_NCR_J", "ZESEI_NASI_RIYU", Function(c) c.String(nullable := False, maxLength := 1, fixedLength := true, unicode := false))
            AlterColumn("dbo.D003_NCR_J", "KANSATU_KEKKA", Function(c) c.String(nullable := False, maxLength := 1, fixedLength := true, unicode := false))
            AlterColumn("dbo.D003_NCR_J", "YOKYU_NAIYO", Function(c) c.String(nullable := False, maxLength := 1, fixedLength := true, unicode := false))
            AlterColumn("dbo.D003_NCR_J", "ZUMEN_KIKAKU", Function(c) c.String(nullable := False, maxLength := 1, fixedLength := true, unicode := false))
            AlterColumn("dbo.D003_NCR_J", "FUTEKIGO_NAIYO", Function(c) c.String(nullable := False, maxLength := 1, fixedLength := true, unicode := false))
            AlterColumn("dbo.D003_NCR_J", "SAIHATU", Function(c) c.String(nullable := False, maxLength := 1, fixedLength := true, unicode := false))
            AlterColumn("dbo.D003_NCR_J", "SURYO", Function(c) c.String(nullable := False, maxLength := 1, fixedLength := true, unicode := false))
            AlterColumn("dbo.D003_NCR_J", "LOT", Function(c) c.String(nullable := False, maxLength := 1, fixedLength := true, unicode := false))
            AlterColumn("dbo.D003_NCR_J", "GOKI", Function(c) c.String(nullable := False, maxLength := 1, fixedLength := true, unicode := false))
            AlterColumn("dbo.D003_NCR_J", "BUHIN_BAME", Function(c) c.String(nullable := False, maxLength := 1, fixedLength := true, unicode := false))
            AlterColumn("dbo.D003_NCR_J", "BUHIN_BANGO", Function(c) c.String(nullable := False, maxLength := 1, fixedLength := true, unicode := false))
            AlterColumn("dbo.D003_NCR_J", "KISYU_ID", Function(c) c.String(nullable := False, maxLength := 1, fixedLength := true, unicode := false))
        End Sub
    End Class
End Namespace
