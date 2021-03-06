USE [FMS]
GO

/****** Object:  UserDefinedFunction [dbo].[TV04_BUSYO_SYOZOKU_SYAIN]    Script Date: 2018/10/11 18:29:00 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO







-- =============================================
-- Author:		JMS-
-- Create date: 2018.
-- Description:	®Ðõîñæ¾
-- =============================================
ALTER FUNCTION [dbo].[TV04_BUSYO_SYOZOKU_SYAIN] 
(
	  @BUSYO_ID				int					--ID
) RETURNS
	@retTBL TABLE(
	 TAISYO_FG				int					--ÎÛtOiOF¢ÎÛAPFÎÛj
	,SYAIN_ID				int					--ÐõID
	,SYAIN_NO				varchar(8)			--ÐõNo
	,SIMEI					nvarchar(30)		--Ðõ¼
	,SIMEI_KANA				nvarchar(60)		--Ðõ¼Ji
	,SYAIN_KB				varchar(2)			--Ðõæª
	,SYAIN_KB_DISP			varchar(50)			--Ðõæª¼
	,YAKUSYOKU_KB			varchar(2)			--ðEæª
	,YAKUSYOKU_KB_DISP		varchar(50)			--ðEæª¼
	,DAIKO_KB				varchar(2)			--ãsæª				
	,DAIKO_KB_DISP			varchar(50)			--ãsæª¼				
	,TAISYA_YMD				char(8)				--ÞÐNú
	,SYOZOKU_YUKO_YMD		char(8)				--®LøúÀ
	,KENMU_FG				char(1)				--±tO
)
AS
BEGIN
	DECLARE @W_TAISYO_FG					int;			--ÎÛtO
	DECLARE	@W_SYAIN_ID						int;			--ÐõID[N
	DECLARE	@W_SYAIN_NO						int;			--ÐõNo
	DECLARE @W_SIMEI						nvarchar(30);	--Ðõ¼
	DECLARE @W_SIMEI_KANA					nvarchar(60);	--Ðõ¼(Ji)
	DECLARE @W_SYAIN_KB						varchar(2)		--Ðõæª
	DECLARE @W_SYAIN_KB_DISP				varchar(50)		--Ðõæª¼
	DECLARE @W_YAKUSYOKU_KB					varchar(2)		--ðEæª
	DECLARE @W_YAKUSYOKU_KB_DISP			varchar(50)		--ðEæª¼
	DECLARE @W_DAIKO_KB						varchar(2)		--ãsæª	
	DECLARE @W_DAIKO_KB_DISP				varchar(50)		--ãsæª¼			
	DECLARE @W_TAISYA_YMD					char(8)			--ÞÐNú
	DECLARE @W_SYOZOKU_YUKO_YMD				char(8)			--®LøúÀ
	DECLARE @W_KENMU_FG						char(1)			--±tO
	DECLARE @W_YUKO_YMD						char(8)			--LøNú

	DECLARE curTB CURSOR FOR
	SELECT 
	 SYAIN_ID				--1
    ,SYAIN_NO				--2
    ,SIMEI					--3
    ,SIMEI_KANA				--4
    ,SYAIN_KB				--5
    ,SYAIN_KB_DISP			--6
    ,YAKUSYOKU_KB			--7
    ,YAKUSYOKU_KB_DISP		--8
    ,DAIKO_KB				--9
    ,DAIKO_KB_DISP			--10
	,TAISYA_YMD				--11
	FROM VWM004_SYAIN
	WHERE 
		 DEL_FLG    = '0'
	 AND TAISYA_YMD = ' ' 
	ORDER BY SIMEI_KANA
	
	OPEN curTB;

	WHILE 1 = 1
	BEGIN
		
		SET @W_SYAIN_ID		= 0;		--1
		SET @W_SYAIN_NO		= '';		--2
		SET @W_SIMEI		= '';		--3
		SET @W_SIMEI_KANA	= '';		--4
		SET @W_SYAIN_KB		= '';		--5
		SET @W_SYAIN_KB_DISP= '';		--6
		SET @W_YAKUSYOKU_KB = '';		--7
		SET @W_YAKUSYOKU_KB_DISP = '';	--8
		SET @W_DAIKO_KB		= '';		--9
		SET @W_DAIKO_KB_DISP =	'';		--10
		SET @W_YUKO_YMD		= '';		--11
		SET @W_KENMU_FG = ''

		FETCH NEXT FROM curTB INTO 
		 @W_SYAIN_ID				--1
		,@W_SYAIN_NO				--2
		,@W_SIMEI					--3
		,@W_SIMEI_KANA				--4
		,@W_SYAIN_KB				--5
		,@W_SYAIN_KB_DISP			--6
		,@W_YAKUSYOKU_KB			--7
		,@W_YAKUSYOKU_KB_DISP		--8
		,@W_DAIKO_KB				--9
		,@W_DAIKO_KB_DISP			--10
		,@W_TAISYA_YMD				--11

		IF @@FETCH_STATUS <> 0
		BEGIN
			BREAK;
		END

		--®}X^ðõ
		DECLARE curTB2 CURSOR FOR
		SELECT
		 YUKO_YMD
		,KENMU_FLG
		FROM M005_SYOZOKU_BUSYO
		WHERE 
		    BUSYO_ID = @BUSYO_ID
		AND SYAIN_ID = @W_SYAIN_ID;
		
		OPEN curTB2;

		FETCH NEXT FROM curTB2 INTO 
		 @W_SYOZOKU_YUKO_YMD
		,@W_KENMU_FG

		IF @@FETCH_STATUS <> 0
		BEGIN
			SET @W_TAISYO_FG = 0;
			SET @W_SYOZOKU_YUKO_YMD = '';
			SET @W_KENMU_FG = '';
		END
		ELSE
		BEGIN
			SET @W_TAISYO_FG = 1;
		END

		INSERT INTO @retTBL 
			(
			 TAISYO_FG				--ÎÛtOiOF¢ÎÛAPFÎÛj
			,SYAIN_ID				--ÐõID
			,SYAIN_NO				--ÐõNo
			,SIMEI					--Ðõ¼
			,SIMEI_KANA				--Ðõ¼Ji
			,SYAIN_KB				--Ðõæª
			,SYAIN_KB_DISP			--Ðõæª¼
			,YAKUSYOKU_KB			--ðEæª
			,YAKUSYOKU_KB_DISP		--ðEæª¼
			,DAIKO_KB				--ãsæª	
			,DAIKO_KB_DISP			--ãsæª¼	
			,TAISYA_YMD				--ÞÐNú
			,SYOZOKU_YUKO_YMD		--®LøúÀ
			,KENMU_FG				--±tO
			) VALUES (
			 @W_TAISYO_FG			--ÎÛtOiOF¢ÎÛAPFÎÛj
			,@W_SYAIN_ID			--ÐõID
			,@W_SYAIN_NO			--ÐõNo
			,@W_SIMEI				--Ðõ¼
			,@W_SIMEI_KANA			--Ðõ¼Ji
			,@W_SYAIN_KB			--Ðõæª
			,@W_SYAIN_KB_DISP		--Ðõæª¼
			,@W_YAKUSYOKU_KB		--ðEæª
			,@W_YAKUSYOKU_KB_DISP	--ðEæª
			,@W_DAIKO_KB			--ãsæª	
			,@W_DAIKO_KB_DISP		--ãsæª¼
			,@W_TAISYA_YMD			--ÞÐNú
			,@W_SYOZOKU_YUKO_YMD	--®LøúÀ
			,@W_KENMU_FG			--±tO
			);
			
		CLOSE curTB2;
		DEALLOCATE curTB2;
	END

	CLOSE curTB;
	DEALLOCATE curTB;

	RETURN;
	
RETURN

END


GO


