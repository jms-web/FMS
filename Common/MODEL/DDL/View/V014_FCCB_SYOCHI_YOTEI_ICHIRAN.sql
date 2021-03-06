USE [FMS]
GO

/****** Object:  View [dbo].[V014_FCCB_SYOCHI_YOTEI_ICHIRAN]    Script Date: 2020/07/09 9:51:27 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO





ALTER VIEW dbo.V014_FCCB_SYOCHI_YOTEI_ICHIRAN
AS
SELECT
    D010.FCCB_NO
  , D010.TANTO_ID
  , isnull((SELECT SIMEI FROM M004_SYAIN WHERE SYAIN_ID = D010.TANTO_ID),'') AS TANTO_NAME
  , D009.KISYU_ID
  , isnull((SELECT KISYU_NAME FROM M105_KISYU AS M105 WHERE M105.KISYU_ID = D009.KISYU_ID),'')	AS KISYU_NAME
  , D009.BUHIN_BANGO
  , isnull((SELECT SUBSTRING(SYONIN_YMDHNS,1,8) FROM V003_SYONIN_J_KANRI
			WHERE SYONIN_HOKOKUSYO_ID = 4
					AND HOKOKU_NO = D009.FCCB_NO
					AND SYONIN_JUN = 10),'') AS KISO_YMD
  , YOTEI_YMD
  , CLOSE_YMD 
FROM
  D010_FCCB_SUB_SYOCHI_KOMOKU D010 INNER JOIN D009_FCCB_J D009 ON (D010.FCCB_NO = D009.FCCB_NO) 
WHERE
  D010.YOHI_KB = '1'
  AND D010.YOTEI_YMD <> ''
  AND D010.CLOSE_YMD = ''
  AND D009.CLOSE_FG = '0'

UNION ALL
SELECT
    D011.FCCB_NO
  , D011.TANTO_ID
  , isnull((SELECT SIMEI FROM M004_SYAIN WHERE SYAIN_ID = D011.TANTO_ID),'') AS TANTO_NAME
  , 0 AS KISYU_ID
  , '' AS KISYU_NAME
  , D011.BUHIN_HINBAN AS BUHIN_BANGO
  , isnull((SELECT SUBSTRING(SYONIN_YMDHNS,1,8) FROM V003_SYONIN_J_KANRI
			WHERE SYONIN_HOKOKUSYO_ID = 4
					AND HOKOKU_NO = D009.FCCB_NO
					AND SYONIN_JUN = 10),'') AS KISO_YMD
  , D011.YOTEI_YMD
  , D011.CLOSE_YMD 
FROM
  D011_FCCB_SUB_SIKAKE_BUHIN D011 INNER JOIN D009_FCCB_J D009 ON (D011.FCCB_NO = D009.FCCB_NO) 
WHERE
  D011.YOTEI_YMD <> ''
  AND D011.CLOSE_YMD = ''
  AND D009.CLOSE_FG = '0'

GO


