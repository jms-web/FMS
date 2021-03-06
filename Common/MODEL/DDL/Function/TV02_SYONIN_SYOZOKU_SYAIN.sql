USE [FMS]
GO

SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO



-- =============================================
-- Author:		JMS-
-- Create date: 2018.
-- Description:	ÏXàeärê
-- =============================================
ALTER FUNCTION [dbo].[TV02_SYONIN_SYOZOKU_SYAIN] 
(
	 @BUMON_KB				char(1)	--åæª
) RETURNS
	@retTBL TABLE(
	 SYONIN_HOKOKUSYO_ID	int				--³FñID
	,SYONIN_JUN				int				--³F
	,SYAIN_ID				int				--ÐõID
	,SIMEI					nvarchar(30)	--Ðõ¼
)
AS
BEGIN
	
	DECLARE @SYONIN_HOKOKUSYO_ID			int;			--ñID
	DECLARE @SYONIN_JUN						int;			--³F
	DECLARE	@SYAIN_ID						int;			--ÐõID
	DECLARE @SIMEI							nvarchar(30);	--Ðõ¼
	DECLARE @BUSYO_ID						int;			--ID
	DECLARE @W_BUMON_KB						char(1);

	DECLARE curTB CURSOR FOR
	SELECT 
	 SYONIN_HOKOKUSYO_ID
	,SYONIN_JUN
	,M016.SYAIN_ID
	,M004.SIMEI
	FROM  M016_SYONIN_TANTO AS M016 LEFT OUTER JOIN
			M004_SYAIN AS M004 ON M016.SYAIN_ID = M004.SYAIN_ID
	--where SYONIN_JUN = 100
	ORDER BY M016.SYAIN_ID

	OPEN curTB;

	WHILE 1 = 1
	BEGIN

		FETCH NEXT FROM curTB INTO 
		  @SYONIN_HOKOKUSYO_ID
		 ,@SYONIN_JUN
		 ,@SYAIN_ID
		 ,@SIMEI

		IF @@FETCH_STATUS <> 0
		BEGIN
			BREAK;
		END

		--®}X^ðõ
		DECLARE curTB2 CURSOR FOR
		SELECT
		BUSYO_ID
		FROM M005_SYOZOKU_BUSYO
		WHERE 
			SYAIN_ID = @SYAIN_ID
		AND YUKO_YMD = (SELECT MIN(YUKO_YMD) FROM M005_SYOZOKU_BUSYO 
						WHERE 
							SYAIN_ID = @SYAIN_ID  
						AND YUKO_YMD >=FORMAT(GETDATE(), 'yyyyMMdd'))
		
		OPEN curTB2;

		WHILE 1 = 1
		BEGIN
			
			SET @BUSYO_ID = null;

			FETCH NEXT FROM curTB2 INTO 
			 @BUSYO_ID

			IF @@FETCH_STATUS <> 0
			BEGIN
				BREAK;
			END

			IF @BUMON_KB <> ''
			BEGIN
				
				SET @W_BUMON_KB = null;

				SELECT @W_BUMON_KB = BUMON_KB 
				FROM M002_BUSYO
				WHERE 
				BUMON_KB = @BUMON_KB
				AND BUSYO_ID = @BUSYO_ID;

				IF @W_BUMON_KB  is not null
				BEGIN
					INSERT INTO @retTBL 
					(
					 SYONIN_HOKOKUSYO_ID					--³FñID
					,SYONIN_JUN								--³F
					,SYAIN_ID								--ÐõID
					,SIMEI
					) VALUES (
					 @SYONIN_HOKOKUSYO_ID					--³FñID
					,@SYONIN_JUN							--³F
					,@SYAIN_ID								--ÐõID
					,@SIMEI
					);
				END
			END
			ELSE
			BEGIN
				INSERT INTO @retTBL 
					(
					 SYONIN_HOKOKUSYO_ID					--³FñID
					,SYONIN_JUN							--³F
					,SYAIN_ID								--ÐõID
					,SIMEI
					) VALUES (
					 @SYONIN_HOKOKUSYO_ID					--³FñID
					,@SYONIN_JUN							--³F
					,@SYAIN_ID								--ÐõID
					,@SIMEI
					);
			END
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


