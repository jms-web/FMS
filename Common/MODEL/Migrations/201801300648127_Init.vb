Imports System
Imports System.Data.Entity.Migrations
Imports Microsoft.VisualBasic

Namespace Migrations
    Public Partial Class Init
        Inherits DbMigration
    
        Public Overrides Sub Up()
            CreateTable(
                "dbo.M001_SETTING",
                Function(c) New With
                    {
                        .ITEM_NAME = c.String(nullable := False, maxLength := 50),
                        .ITEM_VALUE = c.String(nullable := False, maxLength := 50),
                        .ITEM_GROUP = c.String(nullable := False, maxLength := 50),
                        .ITEM_DISP = c.String(nullable := False, maxLength := 150),
                        .DISP_ORDER = c.Int(nullable := False),
                        .DEF_FLG = c.String(nullable := False, maxLength := 1, fixedLength := true, unicode := false),
                        .BIKOU = c.String(nullable := False, maxLength := 200),
                        .ADD_YMDHNS = c.String(nullable := False, maxLength := 14, fixedLength := true, unicode := false),
                        .ADD_SYAIN_ID = c.Int(nullable := False),
                        .UPD_YMDHNS = c.String(nullable := False, maxLength := 14, fixedLength := true, unicode := false),
                        .UPD_SYAIN_ID = c.Int(nullable := False),
                        .DEL_YMDHNS = c.String(nullable := False, maxLength := 14, fixedLength := true, unicode := false),
                        .DEL_SYAIN_ID = c.Int(nullable := False)
                    }) _
                .PrimaryKey(Function(t) New With { t.ITEM_NAME, t.ITEM_VALUE })
            
            CreateTable(
                "dbo.M002_BUSYO",
                Function(c) New With
                    {
                        .BUSYO_ID = c.Int(nullable := False, identity := True),
                        .YUKO_YMD = c.String(nullable := False, maxLength := 8, fixedLength := true, unicode := false),
                        .BUSYO_KB = c.String(nullable := False, maxLength := 1, fixedLength := true, unicode := false),
                        .BUSYO_NAME = c.String(nullable := False, maxLength := 30),
                        .OYA_BUSYO_ID = c.Int(nullable := False),
                        .SYOZOKUCYO_ID = c.Int(nullable := False),
                        .TEL = c.String(nullable := False, maxLength := 8000, unicode := false),
                        .ADD_YMDHNS = c.String(nullable := False, maxLength := 14, fixedLength := true, unicode := false),
                        .ADD_SYAIN_ID = c.Int(nullable := False),
                        .UPD_YMDHNS = c.String(nullable := False, maxLength := 14, fixedLength := true, unicode := false),
                        .UPD_SYAIN_ID = c.Int(nullable := False),
                        .DEL_YMDHNS = c.String(nullable := False, maxLength := 14, fixedLength := true, unicode := false),
                        .DEL_SYAIN_ID = c.Int(nullable := False)
                    }) _
                .PrimaryKey(Function(t) t.BUSYO_ID)
            
            CreateTable(
                "dbo.M003_GYOMU_GROUP",
                Function(c) New With
                    {
                        .GYOMU_GROUP_ID = c.Int(nullable := False, identity := True),
                        .GYOMU_GROUP_NAME = c.String(nullable := False, maxLength := 50),
                        .ADD_YMDHNS = c.String(nullable := False, maxLength := 14, fixedLength := true, unicode := false),
                        .ADD_SYAIN_ID = c.Int(nullable := False),
                        .UPD_YMDHNS = c.String(nullable := False, maxLength := 14, fixedLength := true, unicode := false),
                        .UPD_SYAIN_ID = c.Int(nullable := False),
                        .DEL_YMDHNS = c.String(nullable := False, maxLength := 14, fixedLength := true, unicode := false),
                        .DEL_SYAIN_ID = c.Int(nullable := False)
                    }) _
                .PrimaryKey(Function(t) t.GYOMU_GROUP_ID)
            
            CreateTable(
                "dbo.M004_SYAIN",
                Function(c) New With
                    {
                        .SYAIN_ID = c.Int(nullable := False, identity := True),
                        .SYAIN_NO = c.String(nullable := False, maxLength := 8, unicode := false),
                        .SIMEI = c.String(nullable := False, maxLength := 30),
                        .SIMEI_KANA = c.String(nullable := False, maxLength := 60),
                        .SYAIN_KB = c.String(nullable := False, maxLength := 2, unicode := false),
                        .YAKUSYOKU_KB = c.String(nullable := False, maxLength := 2, unicode := false),
                        .DAIKO_KB = c.String(nullable := False, maxLength := 2, unicode := false),
                        .BIRTH_YMD = c.String(nullable := False, maxLength := 8, fixedLength := true, unicode := false),
                        .TEL = c.String(nullable := False, maxLength := 8000, unicode := false),
                        .MAIL_ADDRESS = c.String(nullable := False, maxLength := 8000, unicode := false),
                        .NYUSYA_YMD = c.String(nullable := False, maxLength := 8, fixedLength := true, unicode := false),
                        .TAISYA_YMD = c.String(nullable := False, maxLength := 8, fixedLength := true, unicode := false),
                        .PASS = c.String(nullable := False, maxLength := 8, unicode := false),
                        .ADD_YMDHNS = c.String(nullable := False, maxLength := 14, fixedLength := true, unicode := false),
                        .ADD_SYAIN_ID = c.Int(nullable := False),
                        .UPD_YMDHNS = c.String(nullable := False, maxLength := 14, fixedLength := true, unicode := false),
                        .UPD_SYAIN_ID = c.Int(nullable := False),
                        .DEL_YMDHNS = c.String(nullable := False, maxLength := 14, fixedLength := true, unicode := false),
                        .DEL_SYAIN_ID = c.Int(nullable := False)
                    }) _
                .PrimaryKey(Function(t) t.SYAIN_ID)
            
            CreateTable(
                "dbo.M005_SYOZOKU_BUSYO",
                Function(c) New With
                    {
                        .SYAIN_ID = c.Int(nullable := False),
                        .BUSYO_ID = c.Int(nullable := False),
                        .YUKO_YMD = c.String(nullable := False, maxLength := 8, fixedLength := true, unicode := false),
                        .KENMU_FLG = c.String(nullable := False, maxLength := 1, fixedLength := true, unicode := false),
                        .ADD_YMDHNS = c.String(nullable := False, maxLength := 14, fixedLength := true, unicode := false),
                        .ADD_SYAIN_ID = c.Int(nullable := False),
                        .UPD_YMDHNS = c.String(nullable := False, maxLength := 14, fixedLength := true, unicode := false),
                        .UPD_SYAIN_ID = c.Int(nullable := False),
                        .DEL_YMDHNS = c.String(nullable := False, maxLength := 14, fixedLength := true, unicode := false),
                        .DEL_SYAIN_ID = c.Int(nullable := False)
                    }) _
                .PrimaryKey(Function(t) New With { t.SYAIN_ID, t.BUSYO_ID })
            
            CreateTable(
                "dbo.M006_CALENDAR",
                Function(c) New With
                    {
                        .YMD = c.String(nullable := False, maxLength := 128, fixedLength := true, unicode := false),
                        .KADO_KB = c.String(nullable := False, maxLength := 1, fixedLength := true, unicode := false),
                        .ADD_YMDHNS = c.String(nullable := False, maxLength := 14, fixedLength := true, unicode := false),
                        .ADD_SYAIN_ID = c.Int(nullable := False),
                        .UPD_YMDHNS = c.String(nullable := False, maxLength := 14, fixedLength := true, unicode := false),
                        .UPD_SYAIN_ID = c.Int(nullable := False)
                    }) _
                .PrimaryKey(Function(t) t.YMD)
            
            CreateTable(
                "dbo.M007_GAMEN",
                Function(c) New With
                    {
                        .GAMEN_ID = c.String(nullable := False, maxLength := 6, unicode := false),
                        .GAMEN_KB = c.String(nullable := False, maxLength := 1, fixedLength := true, unicode := false),
                        .GAMEN_NAME = c.String(nullable := False, maxLength := 30),
                        .PG_FILE_NAME = c.String(nullable := False, maxLength := 30, unicode := false),
                        .ADD_YMDHNS = c.String(nullable := False, maxLength := 14, fixedLength := true, unicode := false),
                        .ADD_SYAIN_ID = c.Int(nullable := False),
                        .UPD_YMDHNS = c.String(nullable := False, maxLength := 14, fixedLength := true, unicode := false),
                        .UPD_SYAIN_ID = c.Int(nullable := False),
                        .DEL_YMDHNS = c.String(nullable := False, maxLength := 14, fixedLength := true, unicode := false),
                        .DEL_SYAIN_ID = c.Int(nullable := False)
                    }) _
                .PrimaryKey(Function(t) t.GAMEN_ID)
            
            CreateTable(
                "dbo.M008_MENU",
                Function(c) New With
                    {
                        .OYA_GAMEN_ID = c.String(nullable := False, maxLength := 6, unicode := false),
                        .GAMEN_ID = c.String(nullable := False, maxLength := 6, unicode := false),
                        .DISP_ORDER = c.Int(nullable := False),
                        .ADD_YMDHNS = c.String(nullable := False, maxLength := 14, fixedLength := true, unicode := false),
                        .ADD_SYAIN_ID = c.Int(nullable := False),
                        .UPD_YMDHNS = c.String(nullable := False, maxLength := 14, fixedLength := true, unicode := false),
                        .UPD_SYAIN_ID = c.Int(nullable := False),
                        .DEL_YMDHNS = c.String(nullable := False, maxLength := 14, fixedLength := true, unicode := false),
                        .DEL_SYAIN_ID = c.Int(nullable := False)
                    }) _
                .PrimaryKey(Function(t) New With { t.OYA_GAMEN_ID, t.GAMEN_ID })
            
            CreateTable(
                "dbo.M009_GAMEN_KENGEN",
                Function(c) New With
                    {
                        .GYOMU_GROUP_ID = c.Int(nullable := False),
                        .GAMEN_ID = c.String(nullable := False, maxLength := 6, unicode := false),
                        .KENGEN_KB = c.String(nullable := False, maxLength := 1, fixedLength := true, unicode := false),
                        .ADD_YMDHNS = c.String(nullable := False, maxLength := 14, fixedLength := true, unicode := false),
                        .ADD_SYAIN_ID = c.Int(nullable := False),
                        .UPD_YMDHNS = c.String(nullable := False, maxLength := 14, fixedLength := true, unicode := false),
                        .UPD_SYAIN_ID = c.Int(nullable := False),
                        .DEL_YMDHNS = c.String(nullable := False, maxLength := 14, fixedLength := true, unicode := false),
                        .DEL_SYAIN_ID = c.Int(nullable := False)
                    }) _
                .PrimaryKey(Function(t) New With { t.GYOMU_GROUP_ID, t.GAMEN_ID })
            
            CreateTable(
                "dbo.M010_SYAIN_KENGEN",
                Function(c) New With
                    {
                        .SYAIN_ID = c.Int(nullable := False),
                        .GAMEN_ID = c.String(nullable := False, maxLength := 6, unicode := false),
                        .KENGEN_KB = c.String(nullable := False, maxLength := 1, fixedLength := true, unicode := false),
                        .ADD_YMDHNS = c.String(nullable := False, maxLength := 14, fixedLength := true, unicode := false),
                        .ADD_SYAIN_ID = c.Int(nullable := False),
                        .UPD_YMDHNS = c.String(nullable := False, maxLength := 14, fixedLength := true, unicode := false),
                        .UPD_SYAIN_ID = c.Int(nullable := False),
                        .DEL_YMDHNS = c.String(nullable := False, maxLength := 14, fixedLength := true, unicode := false),
                        .DEL_SYAIN_ID = c.Int(nullable := False)
                    }) _
                .PrimaryKey(Function(t) New With { t.SYAIN_ID, t.GAMEN_ID })
            
            CreateTable(
                "dbo.M012_J_KOJO",
                Function(c) New With
                    {
                        .KOJO_ID = c.String(nullable := False, maxLength := 3, fixedLength := true, unicode := false),
                        .KOJO_NAME = c.String(nullable := False, maxLength := 30),
                        .POST = c.String(nullable := False, maxLength := 8, fixedLength := true, unicode := false),
                        .ADD1 = c.String(nullable := False, maxLength := 100),
                        .ADD2 = c.String(nullable := False, maxLength := 100),
                        .ADD3 = c.String(nullable := False, maxLength := 100),
                        .TEL = c.String(nullable := False, maxLength := 20, unicode := false),
                        .FAX = c.String(nullable := False, maxLength := 20, unicode := false),
                        .ADD_YMDHNS = c.String(nullable := False, maxLength := 14, fixedLength := true, unicode := false),
                        .ADD_SYAIN_ID = c.Int(nullable := False),
                        .UPD_YMDHNS = c.String(nullable := False, maxLength := 14, fixedLength := true, unicode := false),
                        .UPD_SYAIN_ID = c.Int(nullable := False),
                        .DEL_YMDHNS = c.String(nullable := False, maxLength := 14, fixedLength := true, unicode := false),
                        .DEL_SYAIN_ID = c.Int(nullable := False)
                    }) _
                .PrimaryKey(Function(t) t.KOJO_ID)
            
            CreateTable(
                "dbo.M013_SYONIN_HOKOKU",
                Function(c) New With
                    {
                        .SYONIN_HOKOKUSYO_ID = c.Int(nullable := False, identity := True),
                        .SYONIN_HOKOKUSYO_NAME = c.String(nullable := False, maxLength := 50),
                        .FILE_PATH = c.String(nullable := False, maxLength := 200),
                        .ADD_YMDHNS = c.String(nullable := False, maxLength := 14, fixedLength := true, unicode := false),
                        .ADD_SYAIN_ID = c.Int(nullable := False),
                        .UPD_YMDHNS = c.String(nullable := False, maxLength := 14, fixedLength := true, unicode := false),
                        .UPD_SYAIN_ID = c.Int(nullable := False),
                        .DEL_YMDHNS = c.String(nullable := False, maxLength := 14, fixedLength := true, unicode := false),
                        .DEL_SYAIN_ID = c.Int(nullable := False)
                    }) _
                .PrimaryKey(Function(t) t.SYONIN_HOKOKUSYO_ID)
            
            CreateTable(
                "dbo.M014_SYONIN_ROUT",
                Function(c) New With
                    {
                        .SYONIN_HOKOKUSYO_ID = c.Int(nullable := False),
                        .SYONIN_JUN = c.Int(nullable := False),
                        .SYONIN_NAIYO = c.String(nullable := False, maxLength := 50),
                        .SYONIN_SITEI_KB = c.String(nullable := False, maxLength := 1, fixedLength := true, unicode := false),
                        .BUSYO_SYAIN_ID = c.Int(nullable := False),
                        .OPTION_FLG = c.String(nullable := False, maxLength := 1, fixedLength := true, unicode := false),
                        .ADD_YMDHNS = c.String(nullable := False, maxLength := 14, fixedLength := true, unicode := false),
                        .ADD_SYAIN_ID = c.Int(nullable := False),
                        .UPD_YMDHNS = c.String(nullable := False, maxLength := 14, fixedLength := true, unicode := false),
                        .UPD_SYAIN_ID = c.Int(nullable := False),
                        .DEL_YMDHNS = c.String(nullable := False, maxLength := 14, fixedLength := true, unicode := false),
                        .DEL_SYAIN_ID = c.Int(nullable := False)
                    }) _
                .PrimaryKey(Function(t) New With { t.SYONIN_HOKOKUSYO_ID, t.SYONIN_JUN })
            
            CreateTable(
                "dbo.M015_SYONIN_NYURYOKU",
                Function(c) New With
                    {
                        .SYONIN_HOKOKUSYO_ID = c.Int(nullable := False),
                        .SYONIN_JUN = c.Int(nullable := False),
                        .ITEM_NAME = c.String(nullable := False, maxLength := 50),
                        .ADD_YMDHNS = c.String(nullable := False, maxLength := 14, fixedLength := true, unicode := false),
                        .ADD_SYAIN_ID = c.Int(nullable := False)
                    }) _
                .PrimaryKey(Function(t) New With { t.SYONIN_HOKOKUSYO_ID, t.SYONIN_JUN, t.ITEM_NAME })
            
            CreateTable(
                "dbo.M101_TORIHIKI",
                Function(c) New With
                    {
                        .TORI_ID = c.Int(nullable := False, identity := True),
                        .TORI_NAME = c.String(nullable := False, maxLength := 50),
                        .TORI_KB = c.String(nullable := False, maxLength := 1, fixedLength := true, unicode := false),
                        .POST = c.String(nullable := False, maxLength := 8, fixedLength := true, unicode := false),
                        .ADD1 = c.String(nullable := False, maxLength := 50),
                        .ADD2 = c.String(nullable := False, maxLength := 50),
                        .ADD3 = c.String(nullable := False, maxLength := 50),
                        .TEL = c.String(nullable := False, maxLength := 20, unicode := false),
                        .FAX = c.String(nullable := False, maxLength := 20, unicode := false),
                        .ADD_YMDHNS = c.String(nullable := False, maxLength := 14, fixedLength := true, unicode := false),
                        .ADD_SYAIN_ID = c.Int(nullable := False),
                        .UPD_YMDHNS = c.String(nullable := False, maxLength := 14, fixedLength := true, unicode := false),
                        .UPD_SYAIN_ID = c.Int(nullable := False),
                        .DEL_YMDHNS = c.String(nullable := False, maxLength := 14, fixedLength := true, unicode := false),
                        .DEL_SYAIN_ID = c.Int(nullable := False)
                    }) _
                .PrimaryKey(Function(t) t.TORI_ID)
            
            CreateTable(
                "dbo.M102_TORI_KYOTEN",
                Function(c) New With
                    {
                        .TORI_ID = c.Int(nullable := False),
                        .KYOTEN_ID = c.Int(nullable := False),
                        .KYOTEN_NAME = c.String(nullable := False, maxLength := 30),
                        .TORI_KB = c.String(nullable := False, maxLength := 1, fixedLength := true, unicode := false),
                        .POSTAL_CODE = c.String(nullable := False, maxLength := 8, fixedLength := true, unicode := false),
                        .ADD1 = c.String(nullable := False, maxLength := 50),
                        .ADD2 = c.String(nullable := False, maxLength := 50),
                        .ADD3 = c.String(nullable := False, maxLength := 50),
                        .TEL = c.String(nullable := False, maxLength := 20, unicode := false),
                        .FAX = c.String(nullable := False, maxLength := 20, unicode := false),
                        .ADD_YMDHNS = c.String(nullable := False, maxLength := 14, fixedLength := true, unicode := false),
                        .ADD_SYAIN_ID = c.Int(nullable := False),
                        .UPD_YMDHNS = c.String(nullable := False, maxLength := 14, fixedLength := true, unicode := false),
                        .UPD_SYAIN_ID = c.Int(nullable := False),
                        .DEL_YMDHNS = c.String(nullable := False, maxLength := 14, fixedLength := true, unicode := false),
                        .DEL_SYAIN_ID = c.Int(nullable := False)
                    }) _
                .PrimaryKey(Function(t) New With { t.TORI_ID, t.KYOTEN_ID })
            
            CreateTable(
                "dbo.M103_KOTEI",
                Function(c) New With
                    {
                        .KOTEI_ID = c.Int(nullable := False, identity := True),
                        .BUMON_KB = c.String(nullable := False, maxLength := 1, fixedLength := true, unicode := false),
                        .KOTEI_NAME = c.String(nullable := False, maxLength := 30),
                        .KOTEI_R_NAME = c.String(nullable := False, maxLength := 15),
                        .BUSYO_ID = c.Int(nullable := False),
                        .JIKAN_TANI_KB = c.String(nullable := False, maxLength := 1, fixedLength := true, unicode := false),
                        .DOJI_KAKO_KB = c.String(nullable := False, maxLength := 1, fixedLength := true, unicode := false),
                        .MENTE_KOTEI_FLG = c.String(nullable := False, maxLength := 1, fixedLength := true, unicode := false),
                        .ADD_YMDHNS = c.String(nullable := False, maxLength := 14, fixedLength := true, unicode := false),
                        .ADD_SYAIN_ID = c.Int(nullable := False),
                        .UPD_YMDHNS = c.String(nullable := False, maxLength := 14, fixedLength := true, unicode := false),
                        .UPD_SYAIN_ID = c.Int(nullable := False),
                        .DEL_YMDHNS = c.String(nullable := False, maxLength := 14, fixedLength := true, unicode := false),
                        .DEL_SYAIN_ID = c.Int(nullable := False)
                    }) _
                .PrimaryKey(Function(t) t.KOTEI_ID)
            
            CreateTable(
                "dbo.M105_KISYU",
                Function(c) New With
                    {
                        .KISYU_ID = c.Int(nullable := False, identity := True),
                        .KISYU_NAME = c.String(nullable := False, maxLength := 30),
                        .ADD_YMDHNS = c.String(nullable := False, maxLength := 14, fixedLength := true, unicode := false),
                        .ADD_SYAIN_ID = c.Int(nullable := False),
                        .UPD_YMDHNS = c.String(nullable := False, maxLength := 14, fixedLength := true, unicode := false),
                        .UPD_SYAIN_ID = c.Int(nullable := False),
                        .DEL_YMDHNS = c.String(nullable := False, maxLength := 14, fixedLength := true, unicode := false),
                        .DEL_SYAIN_ID = c.Int(nullable := False)
                    }) _
                .PrimaryKey(Function(t) t.KISYU_ID)
            
            CreateTable(
                "dbo.M106_BUHIN",
                Function(c) New With
                    {
                        .BUMON_KB = c.String(nullable := False, maxLength := 1, fixedLength := true, unicode := false),
                        .TOKUI_ID = c.Int(nullable := False),
                        .BUHIN_BANGO = c.String(nullable := False, maxLength := 60, unicode := false),
                        .BUHIN_MEI = c.String(nullable := False, maxLength := 80, unicode := false),
                        .KEIYAKU_KB = c.String(nullable := False, maxLength := 2, fixedLength := true, unicode := false),
                        .KISYU = c.String(nullable := False, maxLength := 100, unicode := false),
                        .ZUBAN_C = c.String(nullable := False, maxLength := 20, unicode := false),
                        .HINSYU_BANGO = c.String(nullable := False, maxLength := 20, unicode := false),
                        .RIKUKAIKU_KB = c.String(nullable := False, maxLength := 2, fixedLength := true, unicode := false),
                        .TANKA = c.Decimal(nullable := False, storeType := "money"),
                        .TACHIAI_FLG = c.String(nullable := False, maxLength := 1, fixedLength := true, unicode := false),
                        .KISYU_ID = c.Int(nullable := False),
                        .COLOR_CD = c.String(nullable := False, maxLength := 7, fixedLength := true, unicode := false),
                        .ADD_YMDHNS = c.String(nullable := False, maxLength := 14, fixedLength := true, unicode := false),
                        .ADD_SYAIN_ID = c.Int(nullable := False),
                        .UPD_YMDHNS = c.String(nullable := False, maxLength := 14, fixedLength := true, unicode := false),
                        .UPD_SYAIN_ID = c.Int(nullable := False),
                        .DEL_YMDHNS = c.String(nullable := False, maxLength := 14, fixedLength := true, unicode := false),
                        .DEL_SYAIN_ID = c.Int(nullable := False)
                    }) _
                .PrimaryKey(Function(t) New With { t.BUMON_KB, t.TOKUI_ID, t.BUHIN_BANGO })
            
            CreateTable(
                "dbo.M109_BUHIN_KOTEI",
                Function(c) New With
                    {
                        .BUMON_KB = c.String(nullable := False, maxLength := 1, fixedLength := true, unicode := false),
                        .TOKUI_CD = c.Int(nullable := False),
                        .BUHIN_BANGO = c.String(nullable := False, maxLength := 60),
                        .KOJYUN = c.Int(nullable := False),
                        .KOTEI_ID = c.Int(nullable := False),
                        .DANDORI_TIME = c.Decimal(nullable := False, precision := 18, scale := 2),
                        .KAKO_TIME = c.Decimal(nullable := False, precision := 18, scale := 2),
                        .LEAD_TIME = c.Decimal(nullable := False, precision := 18, scale := 2),
                        .KOTEI_YUSEN_LEVEL = c.Int(nullable := False),
                        .ADD_YMDHNS = c.String(nullable := False, maxLength := 14, fixedLength := true, unicode := false),
                        .ADD_SYAIN_ID = c.Int(nullable := False),
                        .UPD_YMDHNS = c.String(nullable := False, maxLength := 14, fixedLength := true, unicode := false),
                        .UPD_SYAIN_ID = c.Int(nullable := False),
                        .DEL_YMDHNS = c.String(nullable := False, maxLength := 14, fixedLength := true, unicode := false),
                        .DEL_SYAIN_ID = c.Int(nullable := False)
                    }) _
                .PrimaryKey(Function(t) New With { t.BUMON_KB, t.TOKUI_CD, t.BUHIN_BANGO, t.KOJYUN })
            
            CreateTable(
                "dbo.M118_SETUBI",
                Function(c) New With
                    {
                        .SETUBI_ID = c.Int(nullable := False, identity := True),
                        .SETUBI_NAME = c.String(nullable := False, maxLength := 80),
                        .SETUBI_KIGO = c.String(nullable := False, maxLength := 3, unicode := false),
                        .K_BUSYO_ID = c.Int(nullable := False),
                        .ADD_YMDHNS = c.String(nullable := False, maxLength := 14, fixedLength := true, unicode := false),
                        .ADD_SYAIN_ID = c.Int(nullable := False),
                        .UPD_YMDHNS = c.String(nullable := False, maxLength := 14, fixedLength := true, unicode := false),
                        .UPD_SYAIN_ID = c.Int(nullable := False),
                        .DEL_YMDHNS = c.String(nullable := False, maxLength := 14, fixedLength := true, unicode := false),
                        .DEL_SYAIN_ID = c.Int(nullable := False)
                    }) _
                .PrimaryKey(Function(t) t.SETUBI_ID)
            
            CreateTable(
                "dbo.M119_KOTEI_SETUBI",
                Function(c) New With
                    {
                        .KOTEI_ID = c.Int(nullable := False),
                        .SETUBI_ID = c.Int(nullable := False),
                        .BUMON_KB = c.String(nullable := False, maxLength := 1, fixedLength := true, unicode := false),
                        .ADD_YMDHNS = c.String(nullable := False, maxLength := 14, fixedLength := true, unicode := false),
                        .ADD_SYAIN_ID = c.Int(nullable := False),
                        .UPD_YMDHNS = c.String(nullable := False, maxLength := 14, fixedLength := true, unicode := false),
                        .UPD_SYAIN_ID = c.Int(nullable := False),
                        .DEL_YMDHNS = c.String(nullable := False, maxLength := 14, fixedLength := true, unicode := false),
                        .DEL_SYAIN_ID = c.Int(nullable := False)
                    }) _
                .PrimaryKey(Function(t) New With { t.KOTEI_ID, t.SETUBI_ID })
            
            CreateTable(
                "dbo.R001_SYONIN",
                Function(c) New With
                    {
                        .HOKOKU_NO = c.String(nullable := False, maxLength := 10, fixedLength := true, unicode := false),
                        .ADD_YMDHNS = c.String(nullable := False, maxLength := 14, fixedLength := true, unicode := false),
                        .SYAIN_ID = c.Int(nullable := False),
                        .SYONIN_HANTEI_KB = c.String(nullable := False, maxLength := 1, fixedLength := true, unicode := false),
                        .RIYU = c.String(nullable := False, maxLength := 100)
                    }) _
                .PrimaryKey(Function(t) t.HOKOKU_NO)
            
        End Sub
        
        Public Overrides Sub Down()
            DropTable("dbo.R001_SYONIN")
            DropTable("dbo.M119_KOTEI_SETUBI")
            DropTable("dbo.M118_SETUBI")
            DropTable("dbo.M109_BUHIN_KOTEI")
            DropTable("dbo.M106_BUHIN")
            DropTable("dbo.M105_KISYU")
            DropTable("dbo.M103_KOTEI")
            DropTable("dbo.M102_TORI_KYOTEN")
            DropTable("dbo.M101_TORIHIKI")
            DropTable("dbo.M015_SYONIN_NYURYOKU")
            DropTable("dbo.M014_SYONIN_ROUT")
            DropTable("dbo.M013_SYONIN_HOKOKU")
            DropTable("dbo.M012_J_KOJO")
            DropTable("dbo.M010_SYAIN_KENGEN")
            DropTable("dbo.M009_GAMEN_KENGEN")
            DropTable("dbo.M008_MENU")
            DropTable("dbo.M007_GAMEN")
            DropTable("dbo.M006_CALENDAR")
            DropTable("dbo.M005_SYOZOKU_BUSYO")
            DropTable("dbo.M004_SYAIN")
            DropTable("dbo.M003_GYOMU_GROUP")
            DropTable("dbo.M002_BUSYO")
            DropTable("dbo.M001_SETTING")
        End Sub
    End Class
End Namespace
