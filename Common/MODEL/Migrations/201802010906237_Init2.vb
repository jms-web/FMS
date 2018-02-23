Imports System
Imports System.Data.Entity.Migrations
Imports Microsoft.VisualBasic

Namespace Migrations
    Public Partial Class Init2
        Inherits DbMigration
    
        Public Overrides Sub Up()
            CreateTable(
                "dbo.M107_BUHIN_KISYU",
                Function(c) New With
                    {
                        .BUMON_KB = c.String(nullable := False, maxLength := 1, fixedLength := true, unicode := false),
                        .TOKUI_ID = c.Int(nullable := False),
                        .BUHIN_BANGO = c.String(nullable := False, maxLength := 60, unicode := false),
                        .KISYU_ID = c.Int(nullable := False),
                        .ADD_YMDHNS = c.String(nullable := False, maxLength := 14, fixedLength := true, unicode := false),
                        .ADD_SYAIN_ID = c.Int(nullable := False),
                        .UPD_YMDHNS = c.String(nullable := False, maxLength := 14, fixedLength := true, unicode := false),
                        .UPD_SYAIN_ID = c.Int(nullable := False),
                        .DEL_YMDHNS = c.String(nullable := False, maxLength := 14, fixedLength := true, unicode := false),
                        .DEL_SYAIN_ID = c.Int(nullable := False)
                    }) _
                .PrimaryKey(Function(t) New With { t.BUMON_KB, t.TOKUI_ID, t.BUHIN_BANGO })
            
            CreateTable(
                "dbo.M108_KOTEI_SYUKEI",
                Function(c) New With
                    {
                        .BUMON_KB = c.String(nullable := False, maxLength := 1, fixedLength := true, unicode := false),
                        .KOTEI_SYUKEI_KB = c.String(nullable := False, maxLength := 1, fixedLength := true, unicode := false),
                        .KOTEI_KANRI_KB = c.String(nullable := False, maxLength := 1, fixedLength := true, unicode := false),
                        .KOTEI_ID = c.Int(nullable := False),
                        .S_KOTEI_KANRI_KB = c.String(nullable := False, maxLength := 1, fixedLength := true, unicode := false),
                        .S_KOTEI_ID = c.Int(nullable := False),
                        .KOSU_WARIAI = c.Int(nullable := False),
                        .ADD_YMDHNS = c.String(nullable := False, maxLength := 14, fixedLength := true, unicode := false),
                        .ADD_SYAIN_ID = c.Int(nullable := False),
                        .UPD_YMDHNS = c.String(nullable := False, maxLength := 14, fixedLength := true, unicode := false),
                        .UPD_SYAIN_ID = c.Int(nullable := False),
                        .DEL_YMDHNS = c.String(nullable := False, maxLength := 14, fixedLength := true, unicode := false),
                        .DEL_SYAIN_ID = c.Int(nullable := False)
                    }) _
                .PrimaryKey(Function(t) New With { t.BUMON_KB, t.KOTEI_SYUKEI_KB, t.KOTEI_KANRI_KB, t.KOTEI_ID, t.S_KOTEI_KANRI_KB, t.S_KOTEI_ID })
            
        End Sub
        
        Public Overrides Sub Down()
            DropTable("dbo.M108_KOTEI_SYUKEI")
            DropTable("dbo.M107_BUHIN_KISYU")
        End Sub
    End Class
End Namespace
