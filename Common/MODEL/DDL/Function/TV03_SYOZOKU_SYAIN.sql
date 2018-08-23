USE [FMS]
GO

/****** Object:  UserDefinedFunction [dbo].[TV02_SYONIN_SYOZOKU_SYAIN]    Script Date: 2018/06/07 21:25:12 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO




-- =============================================
-- Author:		JMS-
-- Create date: 2018.
-- Description:	®Ðõîñæ¾
-- =============================================
create FUNCTION [dbo].[TV03_SYOZOKU_SYAIN] 
(
	 @BUMON_KB				char(1)	--åæª
) RETURNS
	@retTBL TABLE(
	 SYAIN_ID				int					--ÐõID
	,SYAIN_NO				varchar(8)			--ÐõNo
	,SIMEI					nvarchar(30)		--Ðõ¼
	,SIMEI_KANA				nvarchar(60)		--Ðõ¼Ji
	,BUSYO_ID				int					--ID
	,BUSYO_NAME				nvarchar(30)		--¼
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


	DECLARE curTB CURSOR FOR
	SELECT 
	 BUSYO_ID
	,BUSYO_NAME
	FROM M002_BUSYO
	WHERE 
		 BUMON_KB = @BUMON_KB
	 AND YUKO_YMD >=  (SELECT MIN(YUKO_YMD) FROM M002_BUSYO 
					  WHERE 
						  BUMON_KB = @BUMON_KB  
					  AND YUKO_YMD >= FORMAT(GETDATE(), 'yyyyMMdd'))
	ORDER BY BUSYO_ID
	
	OPEN curTB;

	WHILE 1 = 1
	BEGIN

		FETCH NEXT FROM curTB INTO 
		 @W_BUSYO_ID
		,@W_BUSYO_NAME

		IF @@FETCH_STATUS <> 0
		BEGIN
			BREAK;
		END

		--®}X^ðõ
		DECLARE curTB2 CURSOR FOR
		SELECT
		SYAIN_ID
		FROM M005_SYOZOKU_BUSYO
		WHERE 
		    BUSYO_ID = @W_BUSYO_ID
		AND YUKO_YMD = (SELECT MIN(YUKO_YMD) FROM M005_SYOZOKU_BUSYO 
		                WHERE 
						    BUSYO_ID = @W_BUSYO_ID  
						AND YUKO_YMD >=FORMAT(GETDATE(), 'yyyyMMdd'))
		
		OPEN curTB2;

		WHILE 1 = 1
		BEGIN
			
			SET @W_SYAIN_ID = null;

			FETCH NEXT FROM curTB2 INTO 
			 @W_SYAIN_ID

			IF @@FETCH_STATUS <> 0
			BEGIN
				BREAK;
			END

			SELECT
			 @W_SYAIN_NO	= SYAIN_NO
			,@W_SIMEI		= SIMEI
			,@W_SIMEI_KANA	= SIMEI_KANA
			FROM M004_SYAIN
			WHERE 
			SYAIN_ID = @W_SYAIN_ID;


			INSERT INTO @retTBL 
				(
				 SYAIN_ID				--ÐõID
				,SYAIN_NO				--ÐõNo
				,SIMEI					--Ðõ¼
				,SIMEI_KANA				--Ðõ¼Ji
				,BUSYO_ID				--ID
				,BUSYO_NAME				--¼
				) VALUES (
				 @W_SYAIN_ID			--ÐõID
				,@W_SYAIN_NO			--ÐõNo
				,@W_SIMEI				--Ðõ¼
				,@W_SIMEI_KANA			--Ðõ¼Ji
				,@W_BUSYO_ID			--ID
				,@W_BUSYO_NAME			--¼
				);
			
		END

		CLOSE curTB2;
		DEALLOCATE curTB2;
	END

	CLOSE curTB;
	DEALLOCATE curTB;

	RETURN;
	
RETURN

END


GO


