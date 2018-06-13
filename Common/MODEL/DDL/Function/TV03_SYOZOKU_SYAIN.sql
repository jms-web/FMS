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
-- Description:	所属社員情報取得
-- =============================================
create FUNCTION [dbo].[TV03_SYOZOKU_SYAIN] 
(
	 @BUMON_KB				char(1)	--部門区分
) RETURNS
	@retTBL TABLE(
	 SYAIN_ID				int					--社員ID
	,SYAIN_NO				varchar(8)			--社員No
	,SIMEI					nvarchar(30)		--社員名
	,SIMEI_KANA				nvarchar(60)		--社員名カナ
	,BUSYO_ID				int					--部署ID
	,BUSYO_NAME				nvarchar(30)		--部署名
)
AS
BEGIN
	DECLARE	@W_SYAIN_ID						int;			--社員IDワーク
	DECLARE	@W_SYAIN_NO						int;			--社員No
	DECLARE @W_SIMEI						nvarchar(30);	--社員名
	DECLARE @W_SIMEI_KANA					nvarchar(60);	--社員名(カナ)
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
	 AND YUKO_YMD =  (SELECT MIN(YUKO_YMD) FROM M002_BUSYO 
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

		--所属部署マスタを検索
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
				 SYAIN_ID				--社員ID
				,SYAIN_NO				--社員No
				,SIMEI					--社員名
				,SIMEI_KANA				--社員名カナ
				,BUSYO_ID				--部署ID
				,BUSYO_NAME				--部署名
				) VALUES (
				 @W_SYAIN_ID			--社員ID
				,@W_SYAIN_NO			--社員No
				,@W_SIMEI				--社員名
				,@W_SIMEI_KANA			--社員名カナ
				,@W_BUSYO_ID			--部署ID
				,@W_BUSYO_NAME			--部署名
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


