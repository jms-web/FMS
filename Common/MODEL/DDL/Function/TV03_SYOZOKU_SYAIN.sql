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
-- Description:	�����Ј����擾
-- =============================================
create FUNCTION [dbo].[TV03_SYOZOKU_SYAIN] 
(
	 @BUMON_KB				char(1)	--����敪
) RETURNS
	@retTBL TABLE(
	 SYAIN_ID				int					--�Ј�ID
	,SYAIN_NO				varchar(8)			--�Ј�No
	,SIMEI					nvarchar(30)		--�Ј���
	,SIMEI_KANA				nvarchar(60)		--�Ј����J�i
	,BUSYO_ID				int					--����ID
	,BUSYO_NAME				nvarchar(30)		--������
)
AS
BEGIN
	DECLARE	@W_SYAIN_ID						int;			--�Ј�ID���[�N
	DECLARE	@W_SYAIN_NO						int;			--�Ј�No
	DECLARE @W_SIMEI						nvarchar(30);	--�Ј���
	DECLARE @W_SIMEI_KANA					nvarchar(60);	--�Ј���(�J�i)
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

		--���������}�X�^������
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
				 SYAIN_ID				--�Ј�ID
				,SYAIN_NO				--�Ј�No
				,SIMEI					--�Ј���
				,SIMEI_KANA				--�Ј����J�i
				,BUSYO_ID				--����ID
				,BUSYO_NAME				--������
				) VALUES (
				 @W_SYAIN_ID			--�Ј�ID
				,@W_SYAIN_NO			--�Ј�No
				,@W_SIMEI				--�Ј���
				,@W_SIMEI_KANA			--�Ј����J�i
				,@W_BUSYO_ID			--����ID
				,@W_BUSYO_NAME			--������
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


