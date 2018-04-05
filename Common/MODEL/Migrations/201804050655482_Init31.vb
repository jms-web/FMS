Imports System
Imports System.Data.Entity.Migrations
Imports Microsoft.VisualBasic

Namespace Migrations
    Public Partial Class Init31
        Inherits DbMigration
    
        Public Overrides Sub Up()
            AddColumn("dbo.M002_BUSYO", "BUMON_KB", Function(c) c.String(nullable := False, maxLength := 1, fixedLength := true, unicode := false))
            AddColumn("dbo.M106_BUHIN", "SYANAI_CD", Function(c) c.String(nullable := False, maxLength := 10, unicode := false))
            '            DropColumn("dbo.M106_BUHIN", "KISYU")
        End Sub
        
        Public Overrides Sub Down()
            AddColumn("dbo.M106_BUHIN", "KISYU", Function(c) c.String(nullable := False, maxLength := 100, unicode := false))
            DropColumn("dbo.M106_BUHIN", "SYANAI_CD")
            DropColumn("dbo.M002_BUSYO", "BUMON_KB")
        End Sub
    End Class
End Namespace
