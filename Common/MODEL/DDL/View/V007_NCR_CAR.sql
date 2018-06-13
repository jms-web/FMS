USE [FMS]
GO

/****** Object:  View [dbo].[V007_NCR_CAR]    Script Date: 2018/05/30 11:50:47 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO





ALTER VIEW [dbo].[V007_NCR_CAR]
AS
SELECT 
	HOKOKU_NO							--ñNo
	,isnull((SELECT MAX(SYONIN_JUN) FROM D004_SYONIN_J_KANRI 
	         WHERE SYONIN_HOKOKUSYO_ID = 1 
			 AND HOKOKU_NO = V002.HOKOKU_NO 
			 AND SYONIN_YMDHNS = ' ' ),0) AS SYONIN_JUN		--³F
	,isnull((SELECT SYONIN_NAIYO FROM M014_SYONIN_ROUT
	  WHERE 
	  SYONIN_HOKOKUSYO_ID = 1
	  AND SYONIN_JUN = isnull((SELECT MAX(SYONIN_JUN) FROM D004_SYONIN_J_KANRI 
	                           WHERE SYONIN_HOKOKUSYO_ID = 1 
							   AND HOKOKU_NO = V002.HOKOKU_NO 
							   AND SYONIN_YMDHNS = ' '),0)),(SELECT SYONIN_NAIYO fROM M014_SYONIN_ROUT WHERE SYONIN_HOKOKUSYO_ID= 1 AND SYONIN_JUN =999 )) AS SYONIN_NAIYO	--³FàeiXe[Wj
	,1	AS SYONIN_HOKOKUSYO_ID		--³FñID
	,(SELECT SYONIN_HOKOKUSYO_NAME		FROM M013_SYONIN_HOKOKU 
	  WHERE SYONIN_HOKOKUSYO_ID = 1)	AS SYONIN_HOKOKUSYO_NAME			--³Fñ¼
	,(SELECT SYONIN_HOKOKUSYO_R_NAME	FROM M013_SYONIN_HOKOKU 
	  WHERE SYONIN_HOKOKUSYO_ID = 1) AS SYONIN_HOKOKUSYO_R_NAME				--³Fñª¼
	,isnull((SELECT SYAIN_ID FROM D004_SYONIN_J_KANRI 
	  WHERE SYONIN_HOKOKUSYO_ID = 1 
	  AND HOKOKU_NO = V002.HOKOKU_NO 
	  AND SYONIN_JUN = (SELECT MIN(SYONIN_JUN) FROM D004_SYONIN_J_KANRI 
	                    WHERE SYONIN_HOKOKUSYO_ID = 1 
						  AND HOKOKU_NO = V002.HOKOKU_NO 
						  AND SYONIN_YMDHNS = '')),'') AS GEN_TANTO_ID			--³FSÒIDi»uSÒIDj
	,isnull((SELECT SIMEI FROM M004_SYAIN
	  WHERE 
	  SYAIN_ID = (SELECT SYAIN_ID FROM D004_SYONIN_J_KANRI 
			 	 WHERE SYONIN_HOKOKUSYO_ID = 1 
			      AND HOKOKU_NO = V002.HOKOKU_NO 
			 	  AND SYONIN_JUN = (SELECT MIN(SYONIN_JUN) FROM D004_SYONIN_J_KANRI 
									WHERE SYONIN_HOKOKUSYO_ID = 1 
									AND HOKOKU_NO = V002.HOKOKU_NO 
									AND SYONIN_YMDHNS = ''))),'')	AS GEN_TANTO_NAME	--³FSÒ¼
	,(SELECT MAX(SYONIN_YMDHNS) FROM D004_SYONIN_J_KANRI
	  WHERE SYONIN_HOKOKUSYO_ID = 1 
	   AND HOKOKU_NO = V002.HOKOKU_NO) AS SYONIN_YMDHNS							--³FúiuÀ{ú¨æÑOuÀ{új
	,CASE CLOSE_FG 
	 WHEN '0' THEN
		dbo.SC02_GET_TAIRYU_NISSU('1'
							   ,(SELECT MAX(SYONIN_YMDHNS) FROM D004_SYONIN_J_KANRI
								 WHERE SYONIN_HOKOKUSYO_ID = 1 
								  AND HOKOKU_NO = V002.HOKOKU_NO)
							   ,CONVERT(nvarchar,GETDATE(),112)
								 )
	ELSE '0'
	END		AS TAIRYU_NISSU									--Ø¯ú
	,CASE CLOSE_FG 
	 WHEN '0' THEN
		CASE WHEN dbo.SC02_GET_TAIRYU_NISSU('1'
				                        ,(SELECT MAX(SYONIN_YMDHNS) FROM D004_SYONIN_J_KANRI
							              WHERE SYONIN_HOKOKUSYO_ID = 1 
							              AND HOKOKU_NO = V002.HOKOKU_NO)
						                 ,CONVERT(nvarchar,GETDATE(),112)) >= (SELECT KEIKOKU_TAIRYU_NISSU FROM M014_SYONIN_ROUT 
										                                        WHERE SYONIN_HOKOKUSYO_ID = 1
																				AND SYONIN_JUN = (SELECT MAX(SYONIN_JUN) FROM D004_SYONIN_J_KANRI 
																					              WHERE SYONIN_HOKOKUSYO_ID = 1 
																					                AND HOKOKU_NO = V002.HOKOKU_NO 
																					                AND SYONIN_YMDHNS = ' ' )) THEN '1'
		 ELSE '0' END 
	 ELSE 0 END	 AS TAIRYU_FG		--Ø¯tO
	,V002.KISYU_ID						--@íID
	,V002.KISYU							--@í
	,V002.KISYU_NAME						--@í¼
	,V002.BUHIN_BANGO					--iÔ
	,V002.BUHIN_NAME						--i¼
	,V002.GOKI							--@
	,V002.SYANAI_CD						--ÐàR[h
	,V002.FUTEKIGO_KB					--sKæª
	,V002.FUTEKIGO_NAME					--sKæª¼
	,V002.FUTEKIGO_S_KB					--sKÚ×æª
	,V002.FUTEKIGO_S_NAME				--sKÚ×æª¼
	,V002.FUTEKIGO_JYOTAI_KB				--sKóÔæª
	,V002.FUTEKIGO_JYOTAI_NAME			--sKóÔæª
	,V002.JIZEN_SINSA_HANTEI_KB			--OR¸»èæª
	,V002.JIZEN_SINSA_HANTEI_NAME		--OR¸»èæª¼
	,V002.ZESEI_SYOCHI_YOHI_KB			--¥³uvÛæª
	,V002.ZESEI_SYOCHI_YOHI_NAME			--¥³uvÛæª¼
	,V002.SAISIN_IINKAI_HANTEI_KB		--ÄRÏõï»èæª
	,V002.SAISIN_IINKAI_HANTEI_NAME		--ÄRÏõï»èæª¼
	,V002.KENSA_KEKKA_KB					--¸Êæª
	,V002.KENSA_KEKKA_NAME				--¸Êæª¼
	,V002.KONPON_YOIN_KB1				--ª{vöæª1
	,V002.KONPON_YOIN_NAME1				--ª{vöæª¼1
	,V002.KONPON_YOIN_KB2				--ª{vöæª2
	,V002.KONPON_YOIN_NAME2				--ª{vöæª¼2
	,V002.KISEKI_KOTEI_KB				--AÓHöæª
	,V002.KISEKI_KOTEI_NAME				--AÓHöæª¼
	
	,isnull((SELECT SUBSTRING(SYONIN_YMDHNS,1,8) FROM V003_SYONIN_J_KANRI 
	  WHERE SYONIN_HOKOKUSYO_ID = 1 
	    AND HOKOKU_NO = V002.HOKOKU_NO
		AND SYONIN_JUN = 10),'') AS KISO_YMD		--Nú
	,(SELECT SYAIN_ID FROM V003_SYONIN_J_KANRI 
	  WHERE SYONIN_HOKOKUSYO_ID = 1 
	    AND HOKOKU_NO = V002.HOKOKU_NO
		AND SYONIN_JUN = 10) AS KISO_TANTO_ID	--NSÒID
	,(SELECT SYAIN_NAME FROM V003_SYONIN_J_KANRI 
	  WHERE SYONIN_HOKOKUSYO_ID = 1 
	    AND HOKOKU_NO = V002.HOKOKU_NO
		AND SYONIN_JUN = 10) AS KISO_TANTO_NAME--NSÒ¼
	,CLOSE_FG						--N[YtO
	,CASE (SELECT SASIMODOSI_FG FROM D004_SYONIN_J_KANRI 
	       WHERE SYONIN_HOKOKUSYO_ID = 1
		    AND  HOKOKU_NO = V002.HOKOKU_NO
			AND  SYONIN_JUN = (SELECT MAX(SYONIN_JUN) FROM D004_SYONIN_J_KANRI 
			                    WHERE SYONIN_HOKOKUSYO_ID = 1
								 AND  HOKOKU_NO = V002.HOKOKU_NO))
     WHEN '0' THEN 0
	 ELSE isnull((SELECT SYONIN_JUN FROM R001_HOKOKU_SOUSA
	         WHERE SYONIN_HOKOKUSYO_ID = 1 
			  AND  HOKOKU_NO = V002.HOKOKU_NO
			  AND  SOUSA_KB = '3'
			  AND  SYONIN_JUN = (SELECT MAX(SYONIN_JUN) FROM D004_SYONIN_J_KANRI 
			                    WHERE SYONIN_HOKOKUSYO_ID = 1
								 AND  HOKOKU_NO = V002.HOKOKU_NO)),0) 
	END		  AS SASIMOTO_SYONIN_JUN			--·ß³³F
	,CASE (SELECT SASIMODOSI_FG FROM D004_SYONIN_J_KANRI 
	       WHERE SYONIN_HOKOKUSYO_ID = 1
		    AND  HOKOKU_NO = V002.HOKOKU_NO
			AND  SYONIN_JUN = (SELECT MAX(SYONIN_JUN) FROM D004_SYONIN_J_KANRI 
			                    WHERE SYONIN_HOKOKUSYO_ID = 1
								 AND  HOKOKU_NO = V002.HOKOKU_NO))
     WHEN '0' THEN ''
	 ELSE (SELECT SYONIN_NAIYO FROM M014_SYONIN_ROUT
	       WHERE SYONIN_HOKOKUSYO_ID = 1
		    AND SYONIN_JUN = isnull((SELECT SYONIN_JUN FROM R001_HOKOKU_SOUSA
									 WHERE SYONIN_HOKOKUSYO_ID = 1 
									  AND  HOKOKU_NO = V002.HOKOKU_NO
									  AND  SOUSA_KB = '3'
									  AND  SYONIN_JUN = (SELECT MAX(SYONIN_JUN) FROM D004_SYONIN_J_KANRI 
														 WHERE SYONIN_HOKOKUSYO_ID = 1
														  AND  HOKOKU_NO = V002.HOKOKU_NO)),0)) 
	 END	 AS SASIMOTO_SYONIN_NAIYO			--·ß³³Fàei·ßµ³Xe[Wj
	,CASE (SELECT SASIMODOSI_FG FROM D004_SYONIN_J_KANRI 
	       WHERE SYONIN_HOKOKUSYO_ID = 1
		    AND  HOKOKU_NO = V002.HOKOKU_NO
			AND  SYONIN_JUN = (SELECT MAX(SYONIN_JUN) FROM D004_SYONIN_J_KANRI 
			                    WHERE SYONIN_HOKOKUSYO_ID = 1
								 AND  HOKOKU_NO = V002.HOKOKU_NO))
     WHEN '0' THEN ''
	 ELSE isnull((SELECT RIYU FROM R001_HOKOKU_SOUSA
	         WHERE SYONIN_HOKOKUSYO_ID = 1 
			  AND  HOKOKU_NO = V002.HOKOKU_NO
			  AND  SOUSA_KB = '3'
			  AND  SYONIN_JUN = (SELECT MAX(SYONIN_JUN) FROM D004_SYONIN_J_KANRI 
			                    WHERE SYONIN_HOKOKUSYO_ID = 1
								 AND  HOKOKU_NO = V002.HOKOKU_NO)),0) 
	END	  AS RIYU							--·ßR
	
	,YOKYU_NAIYO					--vàe
	,V002.BUMON_KB
	,V002.BUMON_NAME
	,V002.KOKYAKU_HANTEI_SIJI_KB
	,V002.KOKYAKU_HANTEI_SIJI_NAME
	,V002.KOKYAKU_SAISYU_HANTEI_KB
	,V002.KOKYAKU_SAISYU_HANTEI_NAME
	FROM V002_NCR_J AS V002 
	
	UNION ALL
	
	SELECT 
	V005.HOKOKU_NO							--ñNo
	,isnull((SELECT MAX(SYONIN_JUN) FROM D004_SYONIN_J_KANRI 
	         WHERE SYONIN_HOKOKUSYO_ID = 2 
			 AND HOKOKU_NO = V005.HOKOKU_NO 
			 AND SYONIN_YMDHNS = ' ' ),0) AS SYONIN_JUN		--³F
	,isnull((SELECT SYONIN_NAIYO FROM M014_SYONIN_ROUT
	  WHERE 
	  SYONIN_HOKOKUSYO_ID = 2
	  AND SYONIN_JUN = isnull((SELECT MAX(SYONIN_JUN) FROM D004_SYONIN_J_KANRI 
	                           WHERE SYONIN_HOKOKUSYO_ID = 2 
							   AND HOKOKU_NO = V005.HOKOKU_NO 
							   AND SYONIN_YMDHNS = ' '),0)),(SELECT SYONIN_NAIYO fROM M014_SYONIN_ROUT WHERE SYONIN_HOKOKUSYO_ID= 1 AND SYONIN_JUN =999 )) AS SYONIN_NAIYO	--³FàeiXe[Wj
	,2	AS SYONIN_HOKOKUSYO_ID		--³FñID
	,(SELECT SYONIN_HOKOKUSYO_NAME		FROM M013_SYONIN_HOKOKU 
	  WHERE SYONIN_HOKOKUSYO_ID = 2)	AS SYONIN_HOKOKUSYO_NAME			--³Fñ¼
	,(SELECT SYONIN_HOKOKUSYO_R_NAME	FROM M013_SYONIN_HOKOKU 
	  WHERE SYONIN_HOKOKUSYO_ID = 2) AS SYONIN_HOKOKUSYO_R_NAME				--³Fñª¼
	,isnull((SELECT SYAIN_ID FROM D004_SYONIN_J_KANRI 
	  WHERE SYONIN_HOKOKUSYO_ID = 2 
	  AND HOKOKU_NO = V005.HOKOKU_NO 
	  AND SYONIN_JUN = (SELECT MIN(SYONIN_JUN) FROM D004_SYONIN_J_KANRI 
	                    WHERE SYONIN_HOKOKUSYO_ID = 2 
						  AND HOKOKU_NO = V005.HOKOKU_NO 
						  AND SYONIN_YMDHNS = '')),0) AS GEN_TANTO_ID			--³FSÒIDi»uSÒIDj
	,isnull((SELECT SIMEI FROM M004_SYAIN
	  WHERE 
	  SYAIN_ID = (SELECT SYAIN_ID FROM D004_SYONIN_J_KANRI 
			 	 WHERE SYONIN_HOKOKUSYO_ID = 2 
			      AND HOKOKU_NO = V005.HOKOKU_NO 
			 	  AND SYONIN_JUN = (SELECT MIN(SYONIN_JUN) FROM D004_SYONIN_J_KANRI 
									WHERE SYONIN_HOKOKUSYO_ID = 2 
									AND HOKOKU_NO = V005.HOKOKU_NO 
									AND SYONIN_YMDHNS = ''))),'')	AS GEN_TANTO_NAME	--³FSÒ¼
	,(SELECT MAX(SYONIN_YMDHNS) FROM D004_SYONIN_J_KANRI
	  WHERE SYONIN_HOKOKUSYO_ID = 2 
	   AND HOKOKU_NO = V005.HOKOKU_NO) AS SYONIN_YMDHNS							--³FúiuÀ{ú¨æÑOuÀ{új
	,dbo.SC02_GET_TAIRYU_NISSU('1'
						   ,(SELECT MAX(SYONIN_YMDHNS) FROM D004_SYONIN_J_KANRI
							 WHERE SYONIN_HOKOKUSYO_ID = 2 
							  AND HOKOKU_NO = V005.HOKOKU_NO)
						   ,CONVERT(nvarchar,GETDATE(),112)
							 )AS TAIRYU_NISSU									--Ø¯ú
	
	,CASE WHEN dbo.SC02_GET_TAIRYU_NISSU('1'
				                        ,(SELECT MAX(SYONIN_YMDHNS) FROM D004_SYONIN_J_KANRI
							              WHERE SYONIN_HOKOKUSYO_ID = 2 
							              AND HOKOKU_NO = V005.HOKOKU_NO)
						                 ,CONVERT(nvarchar,GETDATE(),112)) >= (SELECT KEIKOKU_TAIRYU_NISSU FROM M014_SYONIN_ROUT 
										                                        WHERE SYONIN_HOKOKUSYO_ID = 2
																				AND SYONIN_JUN = (SELECT MAX(SYONIN_JUN) FROM D004_SYONIN_J_KANRI 
																					              WHERE SYONIN_HOKOKUSYO_ID = 2 
																					                AND HOKOKU_NO = V005.HOKOKU_NO 
																					                AND SYONIN_YMDHNS = ' ' )) THEN '1'
	 ELSE '0' END AS TAIRYU_FG		--Ø¯tO
	,V005.KISYU_ID						--@íID
	,V005.KISYU							--@í
	,V005.KISYU_NAME						--@í¼
	,BUHIN_BANGO					--iÔ
	,BUHIN_NAME						--i¼
	,V002.GOKI							--@
	,SYANAI_CD						--ÐàR[h
	,FUTEKIGO_KB					--sKæª
	,FUTEKIGO_NAME					--sKæª¼
	,FUTEKIGO_S_KB					--sKÚ×æª
	,FUTEKIGO_S_NAME				--sKÚ×æª¼
	,FUTEKIGO_JYOTAI_KB				--sKóÔæª
	,FUTEKIGO_JYOTAI_NAME			--sKóÔæª
	,JIZEN_SINSA_HANTEI_KB			--OR¸»èæª
	,JIZEN_SINSA_HANTEI_NAME		--OR¸»èæª¼
	,ZESEI_SYOCHI_YOHI_KB			--¥³uvÛæª
	,ZESEI_SYOCHI_YOHI_NAME			--¥³uvÛæª¼
	,SAISIN_IINKAI_HANTEI_KB		--ÄRÏõï»èæª
	,SAISIN_IINKAI_HANTEI_NAME		--ÄRÏõï»èæª¼
	,KENSA_KEKKA_KB					--¸Êæª
	,KENSA_KEKKA_NAME				--¸Êæª¼
	,V005.KONPON_YOIN_KB1			--ª{vöæª1
	,V005.KONPON_YOIN_NAME1			--ª{vöæª¼1
	,V005.KONPON_YOIN_KB2			--ª{vöæª2
	,V005.KONPON_YOIN_NAME2			--ª{vöæª¼2
	,V005.KISEKI_KOTEI_KB				--AÓHöæª
	,V005.KISEKI_KOTEI_NAME				--AÓHöæª¼

	,isnull((SELECT SUBSTRING(SYONIN_YMDHNS,1,8) FROM V003_SYONIN_J_KANRI 
	  WHERE SYONIN_HOKOKUSYO_ID = 2 
	    AND HOKOKU_NO = V005.HOKOKU_NO
		AND SYONIN_JUN = 10),'') AS KISO_YMD		--Nú
	,(SELECT SYAIN_ID FROM V003_SYONIN_J_KANRI 
	  WHERE SYONIN_HOKOKUSYO_ID = 2 
	    AND HOKOKU_NO = V005.HOKOKU_NO
		AND SYONIN_JUN = 10) AS KISO_TANTO_ID	--NSÒID
	,(SELECT SYAIN_NAME FROM V003_SYONIN_J_KANRI 
	  WHERE SYONIN_HOKOKUSYO_ID = 2 
	    AND HOKOKU_NO = V005.HOKOKU_NO
		AND SYONIN_JUN = 10) AS KISO_TANTO_NAME--NSÒ¼

	,V005.CLOSE_FG						--N[YtO
	,CASE (SELECT SASIMODOSI_FG FROM D004_SYONIN_J_KANRI 
	       WHERE SYONIN_HOKOKUSYO_ID = 2
		    AND  HOKOKU_NO = V005.HOKOKU_NO
			AND  SYONIN_JUN = (SELECT MAX(SYONIN_JUN) FROM D004_SYONIN_J_KANRI 
			                    WHERE SYONIN_HOKOKUSYO_ID = 2
								 AND  HOKOKU_NO = V005.HOKOKU_NO))
     WHEN '0' THEN 0
	 ELSE isnull((SELECT SYONIN_JUN FROM R001_HOKOKU_SOUSA
	         WHERE SYONIN_HOKOKUSYO_ID = 2 
			  AND  HOKOKU_NO = V005.HOKOKU_NO
			  AND  SOUSA_KB = '3'
			  AND  SYONIN_JUN = (SELECT MAX(SYONIN_JUN) FROM D004_SYONIN_J_KANRI 
			                    WHERE SYONIN_HOKOKUSYO_ID = 2
								 AND  HOKOKU_NO = V005.HOKOKU_NO)),0) 
	END		  AS SASIMOTO_SYONIN_JUN			--·ß³³F
	,CASE (SELECT SASIMODOSI_FG FROM D004_SYONIN_J_KANRI 
	       WHERE SYONIN_HOKOKUSYO_ID = 2
		    AND  HOKOKU_NO = V005.HOKOKU_NO
			AND  SYONIN_JUN = (SELECT MAX(SYONIN_JUN) FROM D004_SYONIN_J_KANRI 
			                    WHERE SYONIN_HOKOKUSYO_ID = 2
								 AND  HOKOKU_NO = V005.HOKOKU_NO))
     WHEN '0' THEN ''
	 ELSE (SELECT SYONIN_NAIYO FROM M014_SYONIN_ROUT
	       WHERE SYONIN_HOKOKUSYO_ID = 2
		    AND SYONIN_JUN = isnull((SELECT SYONIN_JUN FROM R001_HOKOKU_SOUSA
									 WHERE SYONIN_HOKOKUSYO_ID = 2 
									  AND  HOKOKU_NO = V005.HOKOKU_NO
									  AND  SOUSA_KB = '3'
									  AND  SYONIN_JUN = (SELECT MAX(SYONIN_JUN) FROM D004_SYONIN_J_KANRI 
														 WHERE SYONIN_HOKOKUSYO_ID = 2
														  AND  HOKOKU_NO = V005.HOKOKU_NO)),0)) 
	 END	 AS SASIMOTO_SYONIN_NAIYO			--·ß³³Fàei·ßµ³Xe[Wj
	,CASE (SELECT SASIMODOSI_FG FROM D004_SYONIN_J_KANRI 
	       WHERE SYONIN_HOKOKUSYO_ID = 2
		    AND  HOKOKU_NO = V005.HOKOKU_NO
			AND  SYONIN_JUN = (SELECT MAX(SYONIN_JUN) FROM D004_SYONIN_J_KANRI 
			                    WHERE SYONIN_HOKOKUSYO_ID = 2
								 AND  HOKOKU_NO = V005.HOKOKU_NO))
     WHEN '0' THEN ''
	 ELSE isnull((SELECT RIYU FROM R001_HOKOKU_SOUSA
	         WHERE SYONIN_HOKOKUSYO_ID = 2 
			  AND  HOKOKU_NO = V005.HOKOKU_NO
			  AND  SOUSA_KB = '3'
			  AND  SYONIN_JUN = (SELECT MAX(SYONIN_JUN) FROM D004_SYONIN_J_KANRI 
			                    WHERE SYONIN_HOKOKUSYO_ID = 2
								 AND  HOKOKU_NO = V005.HOKOKU_NO)),0) 
	END	  AS RIYU							--·ßR
	,YOKYU_NAIYO					--vàe
	,V005.BUMON_KB
	,V005.BUMON_NAME
	,V002.KOKYAKU_HANTEI_SIJI_KB
	,V002.KOKYAKU_HANTEI_SIJI_NAME
	,V002.KOKYAKU_SAISYU_HANTEI_KB
	,V002.KOKYAKU_SAISYU_HANTEI_NAME
	FROM V005_CAR_J V005 LEFT OUTER JOIN
    V002_NCR_J V002 ON V005.HOKOKU_NO = V002.HOKOKU_NO
	
GO


