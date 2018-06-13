USE [FMS]
GO

/****** Object:  View [dbo].[R004_CAR_R]    Script Date: 2018/05/14 11:30:59 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO


alter VIEW [dbo].[V009_CAR_R]
AS
SELECT
 R004.SASIMODOSI_YMDHNS 
,R004.HOKOKU_NO		--報告書No
,R004.BUMON_KB		--部門区分
,isnull((SELECT ITEM_DISP FROM M001_SETTING WHERE ITEM_NAME = '部門区分' AND ITEM_VALUE=R004.BUMON_KB),'') AS BUMON_NAME	----部門区分名
,R004.CLOSE_FG		--クローズフラグ
,R004.SETUMON_1		--設問内容1
,R004.KAITO_1		--設問回答1
,R004.SETUMON_2		--設問内容2
,R004.KAITO_2		--設問回答2
,R004.SETUMON_3		--設問内容3
,R004.KAITO_3		--設問回答3
,R004.SETUMON_4		--設問内容4
,R004.KAITO_4		--設問回答4
,R004.SETUMON_5		--設問内容5
,R004.KAITO_5		--設問回答5
,R004.SETUMON_6		--設問内容6
,R004.KAITO_6		--設問回答6
,R004.SETUMON_7		--設問内容7
,R004.KAITO_7		--設問回答7
,R004.SETUMON_8		--設問内容8
,R004.KAITO_8		--設問回答8
,R004.SETUMON_9		--設問内容9
,R004.KAITO_9		--設問回答9
,R004.SETUMON_10	--設問内容10
,R004.KAITO_10		--設問回答10
,R004.SETUMON_11	--設問内容11
,R004.KAITO_11		--設問回答11
,R004.SETUMON_12	--設問内容12
,R004.KAITO_12		--設問回答12
,R004.SETUMON_13	--設問内容13
,R004.KAITO_13		--設問回答13
,R004.SETUMON_14	--設問内容14
,R004.KAITO_14		--設問回答14
,R004.SETUMON_15	--設問内容15
,R004.KAITO_15		--設問回答15
,R004.SETUMON_16	--設問内容16
,R004.KAITO_16		--設問回答16
,R004.SETUMON_17	--設問内容17
,R004.KAITO_17		--設問回答17
,R004.SETUMON_18	--設問内容18
,R004.KAITO_18		--設問回答18
,R004.SETUMON_19	--設問内容19
,R004.KAITO_19		--設問回答19
,R004.SETUMON_20	--設問内容20
,R004.KAITO_20		--設問回答20
,R004.SETUMON_21	--設問内容21
,R004.KAITO_21		--設問回答21
,R004.SETUMON_22	--設問内容22
,R004.KAITO_22		--設問回答22
,R004.SETUMON_23	--設問内容23
,R004.KAITO_23		--設問回答23
,R004.SETUMON_24	--設問内容24
,R004.KAITO_24		--設問回答24
,R004.SETUMON_25	--設問内容25
,R004.KAITO_25		--設問回答25
,R004.KONPON_YOIN_KB1	--根本要因区分1
,isnull((SELECT ITEM_DISP FROM M001_SETTING WHERE ITEM_NAME = '根本要因区分' AND ITEM_VALUE=R004.KONPON_YOIN_KB1),'') AS KONPON_YOIN_NAME1	----根本要因区分1名
,R004.KONPON_YOIN_KB2	--根本要因区分2
,isnull((SELECT ITEM_DISP FROM M001_SETTING WHERE ITEM_NAME = '根本要因区分' AND ITEM_VALUE=R004.KONPON_YOIN_KB2),'') AS KONPON_YOIN_NAME2	----根本要因区分2名
,R004.KONPON_YOIN_SYAIN_ID	--根本要因社員ID
,isnull((SELECT SIMEI FROM M004_SYAIN AS M04 WHERE(M04.SYAIN_ID = R004.KONPON_YOIN_SYAIN_ID)),'') AS KONPON_YOIN_SYAIN_NAME	--根本要因社員名
,R004.KISEKI_KOTEI_KB		--帰責工程区分
,isnull((SELECT ITEM_DISP FROM M001_SETTING WHERE ITEM_NAME = '帰責工程区分' AND ITEM_VALUE=R004.KISEKI_KOTEI_KB),'') AS KISEKI_KOTEI_NAME	----帰責工程区分名
,R004.SYOCHI_A_SYAIN_ID		--処置実施A社員ID
,isnull((SELECT SIMEI FROM M004_SYAIN AS M04 WHERE(M04.SYAIN_ID = R004.SYOCHI_A_SYAIN_ID)),'') AS SYOCHI_A_SYAIN_NAME	--処置実施A社員名
,R004.SYOCHI_A_YMDHNS		--処置実施A日時
,R004.SYOCHI_B_SYAIN_ID		--処置実施B社員ID
,isnull((SELECT SIMEI FROM M004_SYAIN AS M04 WHERE(M04.SYAIN_ID = R004.SYOCHI_B_SYAIN_ID)),'') AS SYOCHI_B_SYAIN_NAME	--処置実施B社員名
,R004.SYOCHI_B_YMDHNS		--処置実施B日時
,R004.SYOCHI_C_SYAIN_ID		--処置実施C社員ID
,isnull((SELECT SIMEI FROM M004_SYAIN AS M04 WHERE(M04.SYAIN_ID = R004.SYOCHI_C_SYAIN_ID)),'') AS SYOCHI_C_SYAIN_NAME	--処置実施C社員名
,R004.SYOCHI_C_YMDHNS		--処置実施C日時
,R004.KYOIKU_FILE_PATH		--教育記録ファイルパス
,R004.ZESEI_SYOCHI_YUKO_UMU	--是正処置有効性有無
,R004.SYOSAI_FILE_PATH		--詳細資料Noファイルパス
,R004.GOKI					--号機
,R004.LOT					--LOT
,R004.KENSA_TANTO_ID		--検査社員ID
,isnull((SELECT SIMEI FROM M004_SYAIN AS M04 WHERE(M04.SYAIN_ID = R004.KENSA_TANTO_ID)),'') AS KENSA_TANTO_NAME	--検査社員名
,R004.KENSA_TOROKU_YMDHNS	--検査社員登録日時
,R004.KENSA_GL_SYAIN_ID		--検査GL社員ID
,isnull((SELECT SIMEI FROM M004_SYAIN AS M04 WHERE(M04.SYAIN_ID = R004.KENSA_GL_SYAIN_ID)),'') AS KENSA_GL_SYAIN_NAME	--検査GL社員名
,R004.KENSA_GL_YMDHNS		--検査GL社員登録日時
FROM R004_CAR_SASIMODOSI AS R004
		  
GO


