Imports System
Imports System.Data.Entity.Migrations
Imports Microsoft.VisualBasic

Namespace Migrations
    Public Partial Class Init3
        Inherits DbMigration
    
        Public Overrides Sub Up()
            AddColumn("dbo.M014_SYONIN_ROUT", "KEIKOKU_TAIRYU_NISSU", Function(c) c.Int(nullable := False))
            AddColumn("dbo.M106_BUHIN", "BUHIN_NAME", Function(c) c.String(nullable := False, maxLength := 80, unicode := false))
            DropColumn("dbo.M014_SYONIN_ROUT", "SYONIN_SITEI_KB")
            DropColumn("dbo.M014_SYONIN_ROUT", "BUSYO_SYAIN_ID")
            DropColumn("dbo.M014_SYONIN_ROUT", "OPTION_FLG")
            DropColumn("dbo.M106_BUHIN", "BUHIN_MEI")
        End Sub
        
        Public Overrides Sub Down()
            AddColumn("dbo.M106_BUHIN", "BUHIN_MEI", Function(c) c.String(nullable := False, maxLength := 80, unicode := false))
            AddColumn("dbo.M014_SYONIN_ROUT", "OPTION_FLG", Function(c) c.String(nullable := False, maxLength := 1, fixedLength := true, unicode := false))
            AddColumn("dbo.M014_SYONIN_ROUT", "BUSYO_SYAIN_ID", Function(c) c.Int(nullable := False))
            AddColumn("dbo.M014_SYONIN_ROUT", "SYONIN_SITEI_KB", Function(c) c.String(nullable := False, maxLength := 1, fixedLength := true, unicode := false))
            DropColumn("dbo.M106_BUHIN", "BUHIN_NAME")
            DropColumn("dbo.M014_SYONIN_ROUT", "KEIKOKU_TAIRYU_NISSU")
        End Sub
    End Class
End Namespace
