USE [FMS]
GO

/****** Object:  View [dbo].[V013_FCCB_ICHIRAN]    Script Date: 2020/07/09 9:51:27 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO









ALTER VIEW [dbo].[V013_FCCB_ICHIRAN]
AS
SELECT
	 D009.FCCB_NO
	,D009.BUMON_KB
	,isnull((SELECT ITEM_DISP FROM M001_SETTING WHERE ITEM_NAME = '����敪' AND ITEM_VALUE=D009.BUMON_KB),''
	 ) AS BUMON_NAME
	,isnull((SELECT MAX(SYONIN_JUN) FROM D004_SYONIN_J_KANRI WHERE SYONIN_HOKOKUSYO_ID = 4 AND HOKOKU_NO = D009.FCCB_NO AND SYONIN_HANTEI_KB = '0' ),999)
	 AS SYONIN_JUN
	,IIF(RTRIM(DEL_YMDHNS)<>'',	'DELETED',	
	isnull((SELECT SYONIN_NAIYO FROM M014_SYONIN_ROUT
	  WHERE SYONIN_HOKOKUSYO_ID = 4 
			AND SYONIN_JUN = isnull((SELECT MAX(SYONIN_JUN) FROM D004_SYONIN_J_KANRI WHERE SYONIN_HOKOKUSYO_ID = 4 AND HOKOKU_NO = D009.FCCB_NO AND SYONIN_HANTEI_KB = '0'),0)),(SELECT SYONIN_NAIYO fROM M014_SYONIN_ROUT WHERE SYONIN_HOKOKUSYO_ID= 4 AND SYONIN_JUN =999 )
	 )) AS SYONIN_NAIYO
	,4 AS SYONIN_HOKOKUSYO_ID
	,(SELECT SYONIN_HOKOKUSYO_NAME FROM M013_SYONIN_HOKOKU WHERE SYONIN_HOKOKUSYO_ID = 4)	AS SYONIN_HOKOKUSYO_NAME
	,(SELECT SYONIN_HOKOKUSYO_R_NAME	FROM M013_SYONIN_HOKOKU WHERE SYONIN_HOKOKUSYO_ID = 4) AS SYONIN_HOKOKUSYO_R_NAME
	,CASE WHEN (SELECT MAX(SYONIN_JUN) AS SYONIN_JUN FROM D004_SYONIN_J_KANRI WHERE SYONIN_HOKOKUSYO_ID = 4 AND HOKOKU_NO = D009.FCCB_NO AND SYONIN_HANTEI_KB = '0') = 20 THEN 0
	 ELSE (SELECT SYAIN_ID FROM D004_SYONIN_J_KANRI WHERE SYONIN_HOKOKUSYO_ID = 4 AND HOKOKU_NO = D009.FCCB_NO 
						AND SYONIN_JUN = (SELECT MIN(SYONIN_JUN) FROM D004_SYONIN_J_KANRI 
						WHERE SYONIN_HOKOKUSYO_ID = 4 
						  AND HOKOKU_NO = D009.FCCB_NO 
						  AND SYONIN_HANTEI_KB = '0')) END AS GEN_TANTO_ID
	,CASE WHEN (SELECT MAX(SYONIN_JUN) AS SYONIN_JUN FROM D004_SYONIN_J_KANRI WHERE SYONIN_HOKOKUSYO_ID = 4 AND HOKOKU_NO = D009.FCCB_NO AND SYONIN_HANTEI_KB = '0') = 20 THEN ''
	 ELSE isnull((SELECT SIMEI FROM M004_SYAIN
	  WHERE 
	  SYAIN_ID = (SELECT SYAIN_ID FROM D004_SYONIN_J_KANRI 
				 WHERE SYONIN_HOKOKUSYO_ID = 4
				  AND HOKOKU_NO = D009.FCCB_NO 
				  AND SYONIN_JUN = (SELECT MIN(SYONIN_JUN) FROM D004_SYONIN_J_KANRI 
									WHERE SYONIN_HOKOKUSYO_ID = 4
									AND HOKOKU_NO = D009.FCCB_NO 
									AND SYONIN_HANTEI_KB = '0'))),'') END AS GEN_TANTO_NAME
										,ISNULL((SELECT MAX(UPD_YMDHNS) FROM D004_SYONIN_J_KANRI
	  WHERE SYONIN_HOKOKUSYO_ID = 4
	   AND HOKOKU_NO = D009.FCCB_NO
		 AND SYONIN_HANTEI_KB = '1'),''
	 ) AS SYONIN_YMDHNS
	,CASE CLOSE_FG 
	 WHEN '0' THEN
		dbo.SC02_GET_TAIRYU_NISSU('1'
							   ,(SELECT MAX(CASE WHEN UPD_YMDHNS='' THEN ADD_YMDHNS ELSE UPD_YMDHNS END) FROM D004_SYONIN_J_KANRI
								 WHERE SYONIN_HOKOKUSYO_ID = 4
								  AND HOKOKU_NO = D009.FCCB_NO
									AND SYONIN_HANTEI_KB = '0')
							   ,CONVERT(nvarchar,GETDATE(),112)
								 )
	ELSE '0'
	END	AS TAIRYU_NISSU
	,CASE CLOSE_FG 
	 WHEN '0' THEN
		CASE WHEN dbo.SC02_GET_TAIRYU_NISSU('1'
										,(SELECT MAX(CASE WHEN UPD_YMDHNS='' THEN ADD_YMDHNS ELSE UPD_YMDHNS END) FROM D004_SYONIN_J_KANRI
										  WHERE SYONIN_HOKOKUSYO_ID = 4
										  AND HOKOKU_NO = D009.FCCB_NO
														AND SYONIN_HANTEI_KB = '0')
										 ,CONVERT(nvarchar,GETDATE(),112)) >= (SELECT KEIKOKU_TAIRYU_NISSU FROM M014_SYONIN_ROUT 
																				WHERE SYONIN_HOKOKUSYO_ID = 4
																				AND SYONIN_JUN = (SELECT MAX(SYONIN_JUN) FROM D004_SYONIN_J_KANRI 
																								  WHERE SYONIN_HOKOKUSYO_ID = 4
																									AND HOKOKU_NO = D009.FCCB_NO 
																									AND SYONIN_HANTEI_KB = '0')) THEN '1' ELSE '0' END 
	 ELSE 0 END	 AS TAIRYU_FG
	,D009.KISYU_ID	
	,isnull((SELECT KISYU_NAME FROM M105_KISYU AS M105 WHERE M105.KISYU_ID = D009.KISYU_ID),'')	AS KISYU_NAME
	,D009.BUHIN_BANGO
	,D009.BUHIN_NAME
	,D009.SYANAI_CD
	,D009.INPUT_DOC_NO
	,isnull((SELECT SUBSTRING(SYONIN_YMDHNS,1,8) FROM V003_SYONIN_J_KANRI
			WHERE SYONIN_HOKOKUSYO_ID = 4
					AND HOKOKU_NO = D009.FCCB_NO
					AND SYONIN_JUN = 10),'') AS KISO_YMD
	,isnull((SELECT SYAIN_ID FROM V003_SYONIN_J_KANRI 
	  WHERE SYONIN_HOKOKUSYO_ID = 4 
		AND HOKOKU_NO = D009.FCCB_NO
		AND SYONIN_JUN = 10),0) AS KISO_TANTO_ID
	,isnull((SELECT SYAIN_NAME FROM V003_SYONIN_J_KANRI 
	  WHERE SYONIN_HOKOKUSYO_ID = 4
		AND HOKOKU_NO = D009.FCCB_NO
		AND SYONIN_JUN = 10) ,'')AS KISO_TANTO_NAME
	,D009.CLOSE_FG
	,D009.DEL_YMDHNS
	FROM D009_FCCB_J D009
GO


