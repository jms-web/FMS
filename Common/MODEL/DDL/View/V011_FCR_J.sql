USE [FMS]
GO

/****** Object:  View [dbo].[V011_FCR_J]    Script Date: 2020/03/18 15:13:58 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO





ALTER VIEW [dbo].[V011_FCR_J]
AS
SELECT 
 D007.HOKOKU_NO
,V002.BUMON_KB
,V002.BUMON_NAME
,V002.KISYU_ID
,V002.KISYU_NAME
,V002.ADD_SYAIN_NAME AS ADD_SYAIN_NAME_NCR
,V002.HASSEI_YMD
,V002.FUTEKIGO_NAME
,V002.FUTEKIGO_S_NAME
,D007.CLOSE_FG
,D007.KOKYAKU_EIKYO_HANTEI_KB 
,D007.TAISYOU_KOKYAKU 
,D007.KOKYAKU_EIKYO_HANTEI_COMMENT 
,D007.KOKYAKU_EIKYO_NAIYO 
,D007.KAKUNIN_SYUDAN 
,D007.KOKYAKU_EIKYO_TUCHI_HANTEI_KB 
,D007.TUCHI_YMD 
,D007.TUCHI_SYUDAN 
,D007.HITUYO_TETUDUKI_ZIKO 
,D007.KOKYAKU_EIKYO_ETC_COMMENT 
,D007.OTHER_PROCESS_INFLUENCE_KB 
,D007.FOLLOW_PROCESS_OUTFLOW_KB 
,D007.KOKYAKU_NOUNYU_NAIYOU 
,D007.KOKYAKU_NOUNYU_YMD 
,D007.ZAIKO_SIKAKE_NAIYOU 
,D007.ZAIKO_SIKAKE_YMD 
,D007.OTHER_PROCESS_NAIYOU
,D007.OTHER_PROCESS_YMD
,D007.KOKYAKU_EIKYO_HANTEI_FILEPATH
,D007.FUTEKIGO_SEIHIN_MEMO
,D007.KOKYAKU_EIKYO_MEMO
,D007.OTHER_PROCESS_INFLUENCE_MEMO
,D007.OTHER_PROCESS_INFLUENCE_FILEPATH
,D007.FOLLOW_PROCESS_OUTFLOW_MEMO
,D007.FOLLOW_PROCESS_OUTFLOW_FILEPATH
,D007.FUTEKIGO_SEIHIN_FILEPATH
,D007.KOKYAKU_EIKYO_FILEPATH
,D007.SYOCHI_MEMO
,D007.SYOCHI_FILEPATH
,D007.ADD_SYAIN_ID
,isnull((SELECT SIMEI FROM M004_SYAIN AS M04 WHERE(M04.SYAIN_ID = D007.ADD_SYAIN_ID)),'') AS ADD_SYAIN_NAME
,D007.ADD_YMDHNS			
,D007.UPD_SYAIN_ID		
,isnull((SELECT SIMEI FROM M004_SYAIN AS M04 WHERE(M04.SYAIN_ID = D007.UPD_SYAIN_ID)),'') AS UPD_SYAIN_NAME
,D007.UPD_YMDHNS		
,D007.DEL_SYAIN_ID		
,isnull((SELECT SIMEI FROM M004_SYAIN AS M04 WHERE(M04.SYAIN_ID = D007.DEL_SYAIN_ID)),'') AS DEL_SYAIN_NAME
,D007.DEL_YMDHNS

,D008_1.KISYU_ID AS KISYU_ID1
,D008_2.KISYU_ID AS KISYU_ID2
,D008_3.KISYU_ID AS KISYU_ID3
,D008_4.KISYU_ID AS KISYU_ID4
,D008_5.KISYU_ID AS KISYU_ID5
,D008_6.KISYU_ID AS KISYU_ID6

,isnull((SELECT KISYU_NAME FROM M105_KISYU AS M105 WHERE(M105.KISYU_ID = D008_1.KISYU_ID AND M105.BUMON_KB = V002.BUMON_KB)),'') AS KISYU1_NAME
,isnull((SELECT KISYU_NAME FROM M105_KISYU AS M105 WHERE(M105.KISYU_ID = D008_2.KISYU_ID AND M105.BUMON_KB = V002.BUMON_KB)),'') AS KISYU2_NAME
,isnull((SELECT KISYU_NAME FROM M105_KISYU AS M105 WHERE(M105.KISYU_ID = D008_3.KISYU_ID AND M105.BUMON_KB = V002.BUMON_KB)),'') AS KISYU3_NAME
,isnull((SELECT KISYU_NAME FROM M105_KISYU AS M105 WHERE(M105.KISYU_ID = D008_4.KISYU_ID AND M105.BUMON_KB = V002.BUMON_KB)),'') AS KISYU4_NAME
,isnull((SELECT KISYU_NAME FROM M105_KISYU AS M105 WHERE(M105.KISYU_ID = D008_5.KISYU_ID AND M105.BUMON_KB = V002.BUMON_KB)),'') AS KISYU5_NAME
,isnull((SELECT KISYU_NAME FROM M105_KISYU AS M105 WHERE(M105.KISYU_ID = D008_6.KISYU_ID AND M105.BUMON_KB = V002.BUMON_KB)),'') AS KISYU6_NAME

,D008_1.BUHIN_INFO AS BUHIN_INFO1
,D008_2.BUHIN_INFO AS BUHIN_INFO2
,D008_3.BUHIN_INFO AS BUHIN_INFO3
,D008_4.BUHIN_INFO AS BUHIN_INFO4
,D008_5.BUHIN_INFO AS BUHIN_INFO5
,D008_6.BUHIN_INFO AS BUHIN_INFO6

,D008_1.SURYO AS SURYO1
,D008_2.SURYO AS SURYO2
,D008_3.SURYO AS SURYO3
,D008_4.SURYO AS SURYO4
,D008_5.SURYO AS SURYO5
,D008_6.SURYO AS SURYO6

,D008_1.RANGE_FROM AS RANGE_FROM1
,D008_2.RANGE_FROM AS RANGE_FROM2
,D008_3.RANGE_FROM AS RANGE_FROM3
,D008_4.RANGE_FROM AS RANGE_FROM4
,D008_5.RANGE_FROM AS RANGE_FROM5
,D008_6.RANGE_FROM AS RANGE_FROM6

,D008_1.RANGE_TO AS RANGE_TO1
,D008_2.RANGE_TO AS RANGE_TO2
,D008_3.RANGE_TO AS RANGE_TO3
,D008_4.RANGE_TO AS RANGE_TO4
,D008_5.RANGE_TO AS RANGE_TO5
,D008_6.RANGE_TO AS RANGE_TO6

FROM D007_FCR_J AS D007
LEFT JOIN V002_NCR_J V002 ON (V002.HOKOKU_NO = D007.HOKOKU_NO)
LEFT JOIN D008_FCR_J_SUB D008_1 ON (D007.HOKOKU_NO = D008_1.HOKOKU_NO AND D008_1.ROW_NO = 1)
LEFT JOIN D008_FCR_J_SUB D008_2 ON (D007.HOKOKU_NO = D008_2.HOKOKU_NO AND D008_2.ROW_NO = 2)
LEFT JOIN D008_FCR_J_SUB D008_3 ON (D007.HOKOKU_NO = D008_3.HOKOKU_NO AND D008_3.ROW_NO = 3)
LEFT JOIN D008_FCR_J_SUB D008_4 ON (D007.HOKOKU_NO = D008_4.HOKOKU_NO AND D008_4.ROW_NO = 4)
LEFT JOIN D008_FCR_J_SUB D008_5 ON (D007.HOKOKU_NO = D008_5.HOKOKU_NO AND D008_5.ROW_NO = 5)
LEFT JOIN D008_FCR_J_SUB D008_6 ON (D007.HOKOKU_NO = D008_6.HOKOKU_NO AND D008_6.ROW_NO = 6)

GO


