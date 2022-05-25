USE [FMS]
GO

/****** Object:  View [dbo].[V008_NCR_R]    Script Date: 2019/01/30 11:12:17 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO






ALTER VIEW [dbo].[V008_NCR_R]
AS
SELECT 
 R003.SASIMODOSI_YMDHNS		--·ßú
,R003.HOKOKU_NO				--ñNo
,R003.BUMON_KB				--åæª
,isnull((SELECT ITEM_DISP FROM M001_SETTING WHERE ITEM_NAME = 'åæª' AND ITEM_VALUE=R003.BUMON_KB),'') AS BUMON_NAME	--å¼
,R003.CLOSE_FG				--N[YtO
,R003.KISYU_ID				--@íID
--,isnull((SELECT KISYU FROM M105_KISYU AS M105 WHERE M105.KISYU_ID = R003.KISYU_ID),'')		AS KISYU		--@í
,isnull((SELECT KISYU_NAME FROM M105_KISYU AS M105 WHERE M105.KISYU_ID = R003.KISYU_ID),'')	AS KISYU_NAME	--@í¼
,R003.SYANAI_CD				--ÐàR[h
,R003.BUHIN_BANGO			--iÔ
,R003.BUHIN_NAME			--i¼Ì
,R003.GOKI					--@
,R003.SURYO					--Ê
,R003.SAIHATU				--Ä­
,R003.FUTEKIGO_JYOTAI_KB	--sKóÔæª
,isnull((SELECT ITEM_DISP FROM M001_SETTING WHERE ITEM_NAME = 'sKóÔæª' AND ITEM_VALUE=R003.FUTEKIGO_JYOTAI_KB),'')	AS FUTEKIGO_JYOTAI_NAME	--sKóÔæª¼
,R003.FUTEKIGO_NAIYO		--sKóÔàe
,R003.FUTEKIGO_KB			--sKæª
,dbo.SC05_GET_FUTEKIGO_KB_DISP(R003.BUMON_KB,R003.FUTEKIGO_KB)  AS FUTEKIGO_NAME
--,isnull((SELECT ITEM_DISP FROM M001_SETTING WHERE ITEM_NAME = 'sKæª' AND ITEM_VALUE=R003.FUTEKIGO_KB),'') AS FUTEKIGO_NAME	--sKæª¼
,R003.FUTEKIGO_S_KB			--sKÚ×æª
,dbo.SC04_GET_FUTEKIGO_S_KB_DISP(R003.BUMON_KB,R003.FUTEKIGO_KB,R003.FUTEKIGO_S_KB) AS FUTEKIGO_S_NAME	
/*
,CASE R003.FUTEKIGO_KB
 WHEN '0'	--OÏ
	THEN isnull((SELECT ITEM_DISP FROM M001_SETTING WHERE ITEM_NAME = 'sKOÏæª' AND ITEM_VALUE=R003.FUTEKIGO_S_KB),'')		
 WHEN '1'	--¡@
	THEN isnull((SELECT ITEM_DISP FROM M001_SETTING WHERE ITEM_NAME = 'sK¡@æª' AND ITEM_VALUE=R003.FUTEKIGO_S_KB),'')		
 WHEN '2'	--`ó
	THEN isnull((SELECT ITEM_DISP FROM M001_SETTING WHERE ITEM_NAME = 'sK`óæª' AND ITEM_VALUE=R003.FUTEKIGO_S_KB),'')		
 WHEN '3'	--@\E«\
	THEN isnull((SELECT ITEM_DISP FROM M001_SETTING WHERE ITEM_NAME = 'sK@\«\æª' AND ITEM_VALUE=R003.FUTEKIGO_S_KB),'')	
 WHEN '4'	--»Ì¼
	THEN isnull((SELECT ITEM_DISP FROM M001_SETTING WHERE ITEM_NAME = 'sK»Ì¼æª' AND ITEM_VALUE=R003.FUTEKIGO_S_KB)	,'')
 ELSE 'YsKæªÈµ' 
 END AS FUTEKIGO_S_NAME		--sKÚ×æª¼
 */
,R003.ZUMEN_KIKAKU				--}ÊKi
,R003.YOKYU_NAIYO				--vàe
,R003.KANSATU_KEKKA				--Ï@Ê
,R003.ZESEI_SYOCHI_YOHI_KB		--¥³uvÛæª
,isnull((SELECT ITEM_DISP FROM M001_SETTING WHERE ITEM_NAME = 'vÛæª' AND ITEM_VALUE=R003.ZESEI_SYOCHI_YOHI_KB),'')	 AS ZESEI_SYOCHI_YOHI_NAME				--sKóÔæª¼
,R003.ZESEI_NASI_RIYU			--¥³u³R
,R003.JIZEN_SINSA_HANTEI_KB		--OR¸»èæª
,isnull((SELECT ITEM_DISP FROM M001_SETTING WHERE ITEM_NAME = 'OR¸»èæª' AND ITEM_VALUE=R003.JIZEN_SINSA_HANTEI_KB),'') AS JIZEN_SINSA_HANTEI_NAME		--OR¸»èæª¼
,R003.JIZEN_SINSA_SYAIN_ID		--OR¸ÐõID
,isnull((SELECT SIMEI FROM M004_SYAIN AS M04 WHERE(M04.SYAIN_ID = R003.JIZEN_SINSA_SYAIN_ID)),'') AS JIZEN_SINSA_SYAIN_NAME
,R003.JIZEN_SINSA_YMD			--OR¸ú
,R003.SAISIN_KAKUNIN_SYAIN_ID	--ÄRÏõmFÐõID
,isnull((SELECT SIMEI FROM M004_SYAIN AS M04 WHERE(M04.SYAIN_ID = R003.SAISIN_KAKUNIN_SYAIN_ID)),'') AS SAISIN_KAKUNIN_SYAIN_NAME
,R003.SAISIN_KAKUNIN_YMD		--ÄRÏõmFú
,R003.SAISIN_IINKAI_HANTEI_KB	--ÄRÏõï»èæª
,isnull((SELECT ITEM_DISP FROM M001_SETTING WHERE ITEM_NAME = 'ÄRÏõï»èæª' AND ITEM_VALUE=R003.SAISIN_IINKAI_HANTEI_KB),'') AS SAISIN_IINKAI_HANTEI_NAME	--ÄRÏõï»èæª¼
,R003.SAISIN_GIJYUTU_SYAIN_ID	--ÄRÏõZpÐõID
,isnull((SELECT SIMEI FROM M004_SYAIN AS M04 WHERE(M04.SYAIN_ID = R003.SAISIN_GIJYUTU_SYAIN_ID)),'') AS SAISIN_GIJYUTU_SYAIN_NAME
,R003.SAISIN_GIJYUTU_YMD		--ÄRÏõZpmFú
,R003.SAISIN_HINSYO_SYAIN_ID	--ÄRÏõiØÐõID
,isnull((SELECT SIMEI FROM M004_SYAIN AS M04 WHERE(M04.SYAIN_ID = R003.SAISIN_HINSYO_SYAIN_ID)),'') AS SAISIN_HINSYO_SYAIN_NAME
,R003.SAISIN_HINSYO_YMD			--ÄRÏõiØmFú
,R003.SAISIN_IINKAI_SIRYO_NO	--ÄRÏõï¿No
,R003.ITAG_NO					--ITAGNo
,R003.KOKYAKU_SAISIN_TANTO_ID	--ÚqÄR\¿SID
,isnull((SELECT SIMEI FROM M004_SYAIN AS M04 WHERE(M04.SYAIN_ID = R003.KOKYAKU_SAISIN_TANTO_ID)),'') AS KOKYAKU_SAISIN_TANTO_NAME
,R003.KOKYAKU_SAISIN_YMD		--ÚqÄR\¿ú
,R003.KOKYAKU_SAISIN_FILEPATH1		--ÚqÄR\¿¿1
,R003.KOKYAKU_SAISIN_FILEPATH2		--ÚqÄR\¿¿2
,R003.KOKYAKU_HANTEI_SIJI_KB	--Úq»èw¦æª
,isnull((SELECT ITEM_DISP FROM M001_SETTING WHERE ITEM_NAME = 'Úq»èw¦æª' AND ITEM_VALUE=R003.KOKYAKU_HANTEI_SIJI_KB),'') AS KOKYAKU_HANTEI_SIJI_NAME		--Úq»èw¦æª¼
,R003.KOKYAKU_HANTEI_SIJI_YMD	--Úq»èw¦ú
,R003.KOKYAKU_SAISYU_HANTEI_KB	--ÚqÅI»èæª
,isnull((SELECT ITEM_DISP FROM M001_SETTING WHERE ITEM_NAME = 'ÚqÅI»èæª' AND ITEM_VALUE=R003.KOKYAKU_SAISYU_HANTEI_KB),'') AS KOKYAKU_SAISYU_HANTEI_NAME		--ÚqÅI»èæª¼
,R003.KOKYAKU_SAISYU_HANTEI_YMD	--ÚqÅI»èú
,R003.SAIKAKO_SIJI_FG			--ÄÁHw¦tO
,R003.HAIKYAKU_YMD				--ppNú
,R003.HAIKYAKU_KB				--ppû@æª
,isnull((SELECT ITEM_DISP FROM M001_SETTING WHERE ITEM_NAME = 'ppû@æª' AND ITEM_VALUE=R003.HAIKYAKU_KB),'') AS HAIKYAKU_KB_NAME							--ÚqÅI»èæª¼
,R003.HAIKYAKU_HOUHOU			--ppû@àe
,R003.HAIKYAKU_TANTO_ID			--ppÀ{ÒID
,isnull((SELECT SIMEI FROM M004_SYAIN AS M04 WHERE(M04.SYAIN_ID = R003.HAIKYAKU_TANTO_ID)),'') AS HAIKYAKU_TANTO_NAME
,R003.SAIKAKO_SIJI_NO			--ÄÁHw¦¶No
,R003.SAIKAKO_SAGYO_KAN_YMD		--ÄÁHìÆ®¹ú
,R003.SAIKAKO_KENSA_YMD			--ÄÁH¸Nú
,R003.KENSA_KEKKA_KB			--¸Êæª
,isnull((SELECT ITEM_DISP FROM M001_SETTING WHERE ITEM_NAME = '¸Êæª' AND ITEM_VALUE=R003.KENSA_KEKKA_KB),'') AS KENSA_KEKKA_NAME						--¸Êæª¼
,R003.SEIGI_TANTO_ID			--¶ZÐõID
,isnull((SELECT SIMEI FROM M004_SYAIN AS M04 WHERE(M04.SYAIN_ID = R003.SEIGI_TANTO_ID)),'') AS SEIGI_TANTO_NAME		--¶ZÐõ¼
,R003.SEIZO_TANTO_ID			--»¢ÐõID
,isnull((SELECT SIMEI FROM M004_SYAIN AS M04 WHERE(M04.SYAIN_ID = R003.SEIZO_TANTO_ID)),'') AS SEIZO_TANTO_NAME		--»¢Ðõ¼
,R003.KENSA_TANTO_ID			--¸ÐõID
,isnull((SELECT SIMEI FROM M004_SYAIN AS M04 WHERE(M04.SYAIN_ID = R003.KENSA_TANTO_ID)),'') AS KENSA_TANTO_NAME		--¸Ðõ¼
,R003.HENKYAKU_YMD				--ÔpNú
,R003.HENKYAKU_SAKI				--Ôpæ
,R003.HENKYAKU_TANTO_ID			--ÔpÀ{ÒID
,isnull((SELECT SIMEI FROM M004_SYAIN AS M04 WHERE(M04.SYAIN_ID = R003.HENKYAKU_TANTO_ID)),'') AS HENKYAKU_TANTO_NAME	--¸Ðõ¼
,R003.HENKYAKU_BIKO				--ÔpÀ{õl
,R003.TENYO_KISYU_ID			--]pæ@íID
--,isnull((SELECT KISYU FROM M105_KISYU AS M105 WHERE M105.KISYU_ID = R003.TENYO_KISYU_ID),'')		AS TENYO_KISYU		--]pæ@í
,isnull((SELECT KISYU_NAME FROM M105_KISYU AS M105 WHERE M105.KISYU_ID = R003.TENYO_KISYU_ID),'')	AS TENYO_KISYU_NAME	--]pæ@í¼
,R003.TENYO_BUHIN_BANGO			--]pæiÔ
,R003.TENYO_GOKI				--]pæ@
,R003.TENYO_LOT					--]pæLOT
,R003.TENYO_YMD					--]pNú
,R003.SYOCHI_KEKKA_A			--uÊa
,isnull((SELECT ITEM_DISP FROM M001_SETTING WHERE ITEM_NAME = 'uÊæª' AND ITEM_VALUE=R003.SYOCHI_KEKKA_A),'') AS SYOCHI_KEKKA_A_NAME		--uÊa¼
,R003.SYOCHI_KEKKA_B			--uÊb
,isnull((SELECT ITEM_DISP FROM M001_SETTING WHERE ITEM_NAME = 'uÊæª' AND ITEM_VALUE=R003.SYOCHI_KEKKA_B),'') AS SYOCHI_KEKKA_B_NAME		--uÊb¼
,R003.SYOCHI_KEKKA_C			--uÊc
,isnull((SELECT ITEM_DISP FROM M001_SETTING WHERE ITEM_NAME = 'uÊæª' AND ITEM_VALUE=R003.SYOCHI_KEKKA_C),'') AS SYOCHI_KEKKA_C_NAME		--uÊc¼
,R003.SYOCHI_D_UMU_KB			--udL³æª
,isnull((SELECT ITEM_DISP FROM M001_SETTING WHERE ITEM_NAME = 'L³æª' AND ITEM_VALUE=R003.SYOCHI_D_UMU_KB),'') AS SYOCHI_D_UMU_NAME			--udL³æª¼
,R003.SYOCHI_D_YOHI_KB			--udvÛæª
,isnull((SELECT ITEM_DISP FROM M001_SETTING WHERE ITEM_NAME = 'vÛæª' AND ITEM_VALUE=R003.SYOCHI_D_YOHI_KB),'') AS SYOCHI_D_YOHI_NAME		--udvÛæª¼
,R003.SYOCHI_D_SYOCHI_KIROKU	--uduL^
,R003.SYOCHI_E_UMU_KB			--ueL³æª
,isnull((SELECT ITEM_DISP FROM M001_SETTING WHERE ITEM_NAME = 'L³æª' AND ITEM_VALUE=R003.SYOCHI_E_UMU_KB),'') AS SYOCHI_E_UMU_NAME			--ueL³æª¼
,R003.SYOCHI_E_YOHI_KB			--uevÛæª
,isnull((SELECT ITEM_DISP FROM M001_SETTING WHERE ITEM_NAME = 'vÛæª' AND ITEM_VALUE=R003.SYOCHI_E_YOHI_KB),'') AS SYOCHI_E_YOHI_NAME		--uevÛæª¼
,R003.SYOCHI_E_SYOCHI_KIROKU	--ueuL^
,R003.FILE_PATH					--t@CpX
,R003.G_FILE_PATH1				--æt@CpX1
,R003.G_FILE_PATH2				--æt@CpX2
,R003.HASSEI_KOTEI_GL_SYAIN_ID
,isnull((SELECT SIMEI FROM M004_SYAIN AS M04 WHERE(M04.SYAIN_ID = R003.HASSEI_KOTEI_GL_SYAIN_ID)),'') AS HASSEI_KOTEI_GL_SYAIN_NAME
,R003.SAI_FUTEKIGO_KISO_TANTO_ID
,R003.SAI_KAKO_NG_SURYO
,R003.SAI_KAKO_COMMENT
,R003.SYOCHI_YOTEI_YMD
FROM
R003_NCR_SASIMODOSI AS R003 
GO


