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
-- Description:	所属社員情報取得
-- =============================================
ALTER FUNCTION [dbo].[TV04_BUSYO_SYOZOKU_SYAIN] 
(
	  @BUSYO_ID				int					--部署ID
) RETURNS
	@retTBL TABLE(
	 TAISYO_FG				int					--対象フラグ（０：未対象、１：対象）
	,SYAIN_ID				int					--社員ID
	,SYAIN_NO				varchar(8)			--社員No
	,SIMEI					nvarchar(30)		--社員名
	,SIMEI_KANA				nvarchar(60)		--社員名カナ
	,SYAIN_KB				varchar(2)			--社員区分
	,SYAIN_KB_DISP			varchar(50)			--社員区分名
	,YAKUSYOKU_KB			varchar(2)			--役職区分
	,YAKUSYOKU_KB_DISP		varchar(50)			--役職区分名
	,DAIKO_KB				varchar(2)			--代行区分				
	,DAIKO_KB_DISP			varchar(50)			--代行区分名				
	,TAISYA_YMD				char(8)				--退社年月日
	,SYOZOKU_YUKO_YMD		char(8)				--所属部署有効期限
	,KENMU_FG				char(1)				--兼務フラグ
)
AS
BEGIN
	DECLARE @W_TAISYO_FG					int;			--対象フラグ
	DECLARE	@W_SYAIN_ID						int;			--社員IDワーク
	DECLARE	@W_SYAIN_NO						int;			--社員No
	DECLARE @W_SIMEI						nvarchar(30);	--社員名
	DECLARE @W_SIMEI_KANA					nvarchar(60);	--社員名(カナ)
	DECLARE @W_SYAIN_KB						varchar(2)		--社員区分
	DECLARE @W_SYAIN_KB_DISP				varchar(50)		--社員区分名
	DECLARE @W_YAKUSYOKU_KB					varchar(2)		--役職区分
	DECLARE @W_YAKUSYOKU_KB_DISP			varchar(50)		--役職区分名
	DECLARE @W_DAIKO_KB						varchar(2)		--代行区分	
	DECLARE @W_DAIKO_KB_DISP				varchar(50)		--代行区分名			
	DECLARE @W_TAISYA_YMD					char(8)			--退社年月日
	DECLARE @W_SYOZOKU_YUKO_YMD				char(8)			--所属部署有効期限
	DECLARE @W_KENMU_FG						char(1)			--兼務フラグ
	DECLARE @W_YUKO_YMD						char(8)			--有効年月日

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

		--所属部署マスタを検索
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
			 TAISYO_FG				--対象フラグ（０：未対象、１：対象）
			,SYAIN_ID				--社員ID
			,SYAIN_NO				--社員No
			,SIMEI					--社員名
			,SIMEI_KANA				--社員名カナ
			,SYAIN_KB				--社員区分
			,SYAIN_KB_DISP			--社員区分名
			,YAKUSYOKU_KB			--役職区分
			,YAKUSYOKU_KB_DISP		--役職区分名
			,DAIKO_KB				--代行区分	
			,DAIKO_KB_DISP			--代行区分名	
			,TAISYA_YMD				--退社年月日
			,SYOZOKU_YUKO_YMD		--所属部署有効期限
			,KENMU_FG				--兼務フラグ
			) VALUES (
			 @W_TAISYO_FG			--対象フラグ（０：未対象、１：対象）
			,@W_SYAIN_ID			--社員ID
			,@W_SYAIN_NO			--社員No
			,@W_SIMEI				--社員名
			,@W_SIMEI_KANA			--社員名カナ
			,@W_SYAIN_KB			--社員区分
			,@W_SYAIN_KB_DISP		--社員区分名
			,@W_YAKUSYOKU_KB		--役職区分
			,@W_YAKUSYOKU_KB_DISP	--役職区分
			,@W_DAIKO_KB			--代行区分	
			,@W_DAIKO_KB_DISP		--代行区分名
			,@W_TAISYA_YMD			--退社年月日
			,@W_SYOZOKU_YUKO_YMD	--所属部署有効期限
			,@W_KENMU_FG			--兼務フラグ
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


