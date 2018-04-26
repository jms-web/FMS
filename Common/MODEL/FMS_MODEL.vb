Imports System
Imports System.Data.Entity
Imports System.ComponentModel.DataAnnotations.Schema
Imports System.Linq

Partial Public Class FMS_Context
    Inherits DbContext

    Public Sub New()
        MyBase.New("name=FMS")
    End Sub

    Public Overridable Property M001_SETTING As DbSet(Of M001_SETTING)
    Public Overridable Property M002_BUSYO As DbSet(Of M002_BUSYO)
    Public Overridable Property M003_GYOMU_GROUP As DbSet(Of M003_GYOMU_GROUP)
    Public Overridable Property M004_SYAIN As DbSet(Of M004_SYAIN)
    Public Overridable Property M005_SYOZOKU_BUSYO As DbSet(Of M005_SYOZOKU_BUSYO)
    Public Overridable Property M006_CALENDAR As DbSet(Of M006_CALENDAR)
    Public Overridable Property M007_GAMEN As DbSet(Of M007_GAMEN)
    Public Overridable Property M008_MENU As DbSet(Of M008_MENU)
    Public Overridable Property M009_GAMEN_KENGEN As DbSet(Of M009_GAMEN_KENGEN)
    Public Overridable Property M010_SYAIN_KENGEN As DbSet(Of M010_SYAIN_KENGEN)
    Public Overridable Property M012_J_KOJO As DbSet(Of M012_J_KOJO)
    Public Overridable Property M013_SYONIN_HOKOKU As DbSet(Of M013_SYONIN_HOKOKU)
    Public Overridable Property M014_SYONIN_ROUT As DbSet(Of VW014_SYONIN_ROUT)
    Public Overridable Property M015_SYONIN_NYURYOKU As DbSet(Of M015_SYONIN_NYURYOKU)
    Public Overridable Property M016_SYONIN_TANTO As DbSet(Of M016_SYONIN_TANTO)

    Public Overridable Property M101_TORIHIKI As DbSet(Of M101_TORIHIKI)
    Public Overridable Property M102_TORI_KYOTEN As DbSet(Of M102_TORI_KYOTEN)
    Public Overridable Property M103_KOTEI As DbSet(Of M103_KOTEI)
    Public Overridable Property M105_KISYU As DbSet(Of M105_KISYU)
    Public Overridable Property M106_BUHIN As DbSet(Of M106_BUHIN)
    Public Overridable Property M107_BUHIN_KISYU As DbSet(Of M107_BUHIN_KISYU)
    Public Overridable Property M108_KOTEI_SYUKEI As DbSet(Of M108_KOTEI_SYUKEI)
    Public Overridable Property M109_BUHIN_KOTEI As DbSet(Of M109_BUHIN_KOTEI)
    Public Overridable Property M118_SETUBI As DbSet(Of M118_SETUBI)
    Public Overridable Property M119_KOTEI_SETUBI As DbSet(Of M119_KOTEI_SETUBI)

    Public Overridable Property D003_NCR_J As DbSet(Of D003_NCR_J)

    Protected Overrides Sub OnModelCreating(ByVal modelBuilder As DbModelBuilder)

    End Sub
End Class
