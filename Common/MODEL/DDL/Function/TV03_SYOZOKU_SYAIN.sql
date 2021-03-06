USE [FMS]
GO

/****** Object:  UserDefinedFunction [dbo].[TV03_SYOZOKU_SYAIN]    Script Date: 2020/05/28 11:06:45 ******/
DROP FUNCTION [dbo].[TV03_SYOZOKU_SYAIN]
GO

/****** Object:  UserDefinedFunction [dbo].[TV03_SYOZOKU_SYAIN]    Script Date: 2020/05/28 11:06:45 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO






-- =============================================
-- Author:		JMS-
-- Create date: 2018.
-- Description:	®Ðõîñæ¾
-- =============================================
CREATE  FUNCTION [dbo].[TV03_SYOZOKU_SYAIN] 
(
	 @BUMON_KB				char(1)	--åæª	 
) RETURNS
	@retTBL TABLE(
	 SYAIN_ID				int					--ÐõID
	,SYAIN_NO				varchar(8)			--ÐõNo
	,SIMEI					nvarchar(30)		--Ðõ¼
	,SIMEI_KANA				nvarchar(60)		--Ðõ¼Ji
	,BUMON_KB				char(1)
	,BUSYO_ID				int					--ID
	,BUSYO_NAME				nvarchar(30)		--¼
	,GYOMU_GROUP_ID				int		--Æ±O[v
	,GYOMU_GROUP_NAME				nvarchar(30)		--Æ±O[v¼
	,IS_LEADER			int --®·©Ç¤©(0:False 1:True
)
AS
BEGIN
	DECLARE	@W_SYAIN_ID						int;			--ÐõID[N
	DECLARE	@W_SYAIN_NO						int;			--ÐõNo
	DECLARE @W_SIMEI						nvarchar(30);	--Ðõ¼
	DECLARE @W_SIMEI_KANA					nvarchar(60);	--Ðõ¼(Ji)
	DECLARE @W_BUMON_KB						char(1);
	DECLARE @W_BUSYO_ID						int;
	DECLARE @W_BUSYO_NAME					nvarchar(30);	
	DECLARE @W_GYOMU_GROUP_ID			int;
	DECLARE @W_GYOMU_GROUP_NAME		nvarchar(30);
	DECLARE @W_SYOZOKUCYO_ID			int;
	DECLARE @W_IS_LEADER			int;
	DECLARE @W_TAISYA_YMD char(8);
	
	IF @BUMON_KB = 1 OR @BUMON_KB = 2
		--qó@å
		DECLARE curTB CURSOR FOR
		SELECT M002.BUSYO_ID, M002.BUSYO_NAME, M002.BUMON_KB
		FROM M002_BUSYO M002
		WHERE M002.BUMON_KB IN (1, 2)
		AND M002.YUKO_YMD >= (SELECT MIN(YUKO_YMD) FROM M002_BUSYO WHERE BUMON_KB = M002.BUMON_KB AND YUKO_YMD >= FORMAT(GETDATE(), 'yyyyMMdd'))
		ORDER BY BUSYO_ID;
	ELSE
		--¡Þ»Ì¼
		DECLARE curTB CURSOR FOR
		SELECT BUSYO_ID, BUSYO_NAME, BUMON_KB
		FROM M002_BUSYO
		WHERE BUMON_KB = @BUMON_KB
		AND YUKO_YMD >= (SELECT MIN(YUKO_YMD) FROM M002_BUSYO WHERE BUMON_KB = @BUMON_KB AND YUKO_YMD >= FORMAT(GETDATE(), 'yyyyMMdd'))
		ORDER BY BUSYO_ID;
	
	OPEN curTB;
		
	WHILE 1 = 1
	BEGIN

		FETCH NEXT FROM curTB INTO 
		 @W_BUSYO_ID
		,@W_BUSYO_NAME
		,@W_BUMON_KB

		IF @@FETCH_STATUS <> 0
		BEGIN
			BREAK;
		END

		--®}X^ðõ
		DECLARE curTB2 CURSOR FOR
		SELECT
		SYAIN_ID,SYOZOKUCYO_ID
		FROM M005_SYOZOKU_BUSYO M005 INNER JOIN M002_BUSYO M002 ON (M005.BUSYO_ID = M002.BUSYO_ID)
		WHERE 
		    M005.BUSYO_ID = @W_BUSYO_ID
		AND M005.YUKO_YMD = (SELECT MIN(YUKO_YMD) FROM M005_SYOZOKU_BUSYO WHERE BUSYO_ID = @W_BUSYO_ID AND YUKO_YMD >=FORMAT(GETDATE(), 'yyyyMMdd'))
		
		OPEN curTB2;

		WHILE 1 = 1
		BEGIN
			
			SET @W_SYAIN_ID = null;
			
			FETCH NEXT FROM curTB2 INTO 
			 @W_SYAIN_ID,@W_SYOZOKUCYO_ID

			IF @@FETCH_STATUS <> 0
			BEGIN
				BREAK;
			END


			DECLARE curTB3 CURSOR FOR
			SELECT
				M004.SYAIN_NO
			  , M004.SIMEI
			  , M004.SIMEI_KANA
			  , ISNULL(M011.GYOMU_GROUP_ID, 0)
			  , ISNULL((SELECT GYOMU_GROUP_NAME FROM M003_GYOMU_GROUP M003 WHERE M003.GYOMU_GROUP_ID = M011.GYOMU_GROUP_ID) , '')
			  , RTRIM(M004.TAISYA_YMD)			  
			FROM
			  M005_SYOZOKU_BUSYO M005   
			  LEFT JOIN M004_SYAIN M004 
				ON M005.SYAIN_ID = M004.SYAIN_ID
			  LEFT JOIN M011_SYAIN_GYOMU M011 
				ON M011.SYAIN_ID = M004.SYAIN_ID
			WHERE
			  M004.SYAIN_ID = @W_SYAIN_ID AND M005.BUSYO_ID = @W_BUSYO_ID
			  --ÞEÒÍO
			 AND (RTRIM(M004.TAISYA_YMD)='' OR M004.TAISYA_YMD > FORMAT(GETDATE(), 'yyyyMMdd'))


			OPEN curTB3;

			WHILE 1 = 1
				BEGIN
					FETCH NEXT FROM curTB3 INTO 
					@W_SYAIN_NO,@W_SIMEI,@W_SIMEI_KANA,@W_GYOMU_GROUP_ID,@W_GYOMU_GROUP_NAME,@W_TAISYA_YMD

					IF @@FETCH_STATUS <> 0
					BEGIN
						BREAK;
					END


					SET @W_IS_LEADER = IIF(@W_SYAIN_ID = @W_SYOZOKUCYO_ID,1,0)
			
					IF (@W_TAISYA_YMD='' OR @W_TAISYA_YMD > FORMAT(GETDATE(), 'yyyyMMdd'))
						BEGIN
							INSERT INTO @retTBL 
								(
								 SYAIN_ID				--ÐõID
								,SYAIN_NO				--ÐõNo
								,SIMEI					--Ðõ¼
								,SIMEI_KANA				--Ðõ¼Ji
								,BUMON_KB
								,BUSYO_ID				--ID
								,BUSYO_NAME				--¼
								,GYOMU_GROUP_ID
								,GYOMU_GROUP_NAME
								,IS_LEADER
								) VALUES (
								 @W_SYAIN_ID			--ÐõID
								,@W_SYAIN_NO			--ÐõNo
								,@W_SIMEI				--Ðõ¼
								,@W_SIMEI_KANA			--Ðõ¼Ji
								,@W_BUMON_KB
								,@W_BUSYO_ID			--ID
								,@W_BUSYO_NAME			--¼
								,@W_GYOMU_GROUP_ID
								,@W_GYOMU_GROUP_NAME
								,@W_IS_LEADER
								);
						END

					--IF @W_BUSYO_ID=10 AND (@W_TAISYA_YMD='' OR @W_TAISYA_YMD > FORMAT(GETDATE(), 'yyyyMMdd'))
					--	BEGIN
					
					--		--SET @W_GYOMU_GROUP_ID = 2;
					
					--		--SELECT @W_GYOMU_GROUP_NAME = isnull(GYOMU_GROUP_NAME,'') 
					--		--FROM M003_GYOMU_GROUP M003 
					--		--WHERE M003.GYOMU_GROUP_ID = 2; 

					--		INSERT INTO @retTBL 
					--		(
					--		 SYAIN_ID				--ÐõID
					--		,SYAIN_NO				--ÐõNo
					--		,SIMEI					--Ðõ¼
					--		,SIMEI_KANA				--Ðõ¼Ji
					--		,BUMON_KB
					--		,BUSYO_ID				--ID
					--		,BUSYO_NAME				--¼
					--		,GYOMU_GROUP_ID
					--		,GYOMU_GROUP_NAME
					--		,IS_LEADER
					--		) VALUES (
					--		 @W_SYAIN_ID			--ÐõID
					--		,@W_SYAIN_NO			--ÐõNo
					--		,@W_SIMEI				--Ðõ¼
					--		,@W_SIMEI_KANA			--Ðõ¼Ji
					--		,@W_BUMON_KB
					--		,@W_BUSYO_ID			--ID
					--		,@W_BUSYO_NAME			--¼
					--		,@W_GYOMU_GROUP_ID
					--		,@W_GYOMU_GROUP_NAME
					--		,@W_IS_LEADER
					--		);


					--	END;
				END
				CLOSE curTB3;
				DEALLOCATE curTB3;
			
		END

		CLOSE curTB2;
		DEALLOCATE curTB2;
	END

	CLOSE curTB;
	DEALLOCATE curTB;

	--DELETE @retTBL WHERE SYAIN_NO = '0'

	RETURN;
	
RETURN

END





GO


