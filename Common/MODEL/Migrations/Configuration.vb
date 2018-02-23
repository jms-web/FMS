Imports System
Imports System.Data.Entity
Imports System.Data.Entity.Migrations
Imports System.Linq

Namespace Migrations

    Friend NotInheritable Class Configuration 
        Inherits DbMigrationsConfiguration(Of FMS_Context)

        Public Sub New()
            AutomaticMigrationsEnabled = True
            AutomaticMigrationDataLossAllowed = True
            Database.SetInitializer(New DropCreateDatabaseAlways(Of FMS_Context))
        End Sub

        Protected Overrides Sub Seed(context As FMS_Context)
            '  This method will be called after migrating to the latest version.

            '  You can use the DbSet(Of T).AddOrUpdate() helper extension method 
            '  to avoid creating duplicate seed data.
        End Sub

    End Class

End Namespace
