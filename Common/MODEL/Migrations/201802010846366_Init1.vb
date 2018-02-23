Imports System
Imports System.Data.Entity.Migrations
Imports Microsoft.VisualBasic

Namespace Migrations
    Public Partial Class Init1
        Inherits DbMigration
    
        Public Overrides Sub Up()
            CreateTable(
                "dbo.M016_SYONIN_TANTO",
                Function(c) New With
                    {
                        .SYONIN_HOKOKUSYO_ID = c.Int(nullable := False),
                        .SYONIN_JUN = c.Int(nullable := False),
                        .SYAIN_ID = c.Int(nullable := False),
                        .ADD_YMDHNS = c.String(nullable := False, maxLength := 14, fixedLength := true, unicode := false),
                        .ADD_SYAIN_ID = c.Int(nullable := False)
                    }) _
                .PrimaryKey(Function(t) New With { t.SYONIN_HOKOKUSYO_ID, t.SYONIN_JUN, t.SYAIN_ID })
            
        End Sub
        
        Public Overrides Sub Down()
            DropTable("dbo.M016_SYONIN_TANTO")
        End Sub
    End Class
End Namespace
