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
-- Description:	�����Ј����擾
-- =============================================
ALTER FUNCTION [dbo].[TV04_BUSYO_SYOZOKU_SYAIN] 
(
	  @BUSYO_ID				int					--����ID
) RETURNS
	@retTBL TABLE(
	 TAISYO_FG				int					--�Ώۃt���O�i�O�F���ΏہA�P�F�Ώہj
	,SYAIN_ID				int					--�Ј�ID
	,SYAIN_NO				varchar(8)			--�Ј�No
	,SIMEI					nvarchar(30)		--�Ј���
	,SIMEI_KANA				nvarchar(60)		--�Ј����J�i
	,SYAIN_KB				varchar(2)			--�Ј��敪
	,SYAIN_KB_DISP			varchar(50)			--�Ј��敪��
	,YAKUSYOKU_KB			varchar(2)			--��E�敪
	,YAKUSYOKU_KB_DISP		varchar(50)			--��E�敪��
	,DAIKO_KB				varchar(2)			--��s�敪				
	,DAIKO_KB_DISP			varchar(50)			--��s�敪��				
	,TAISYA_YMD				char(8)				--�ގДN����
	,SYOZOKU_YUKO_YMD		char(8)				--���������L������
	,KENMU_FG				char(1)				--�����t���O
)
AS
BEGIN
	DECLARE @W_TAISYO_FG					int;			--�Ώۃt���O
	DECLARE	@W_SYAIN_ID						int;			--�Ј�ID���[�N
	DECLARE	@W_SYAIN_NO						int;			--�Ј�No
	DECLARE @W_SIMEI						nvarchar(30);	--�Ј���
	DECLARE @W_SIMEI_KANA					nvarchar(60);	--�Ј���(�J�i)
	DECLARE @W_SYAIN_KB						varchar(2)		--�Ј��敪
	DECLARE @W_SYAIN_KB_DISP				varchar(50)		--�Ј��敪��
	DECLARE @W_YAKUSYOKU_KB					varchar(2)		--��E�敪
	DECLARE @W_YAKUSYOKU_KB_DISP			varchar(50)		--��E�敪��
	DECLARE @W_DAIKO_KB						varchar(2)		--��s�敪	
	DECLARE @W_DAIKO_KB_DISP				varchar(50)		--��s�敪��			
	DECLARE @W_TAISYA_YMD					char(8)			--�ގДN����
	DECLARE @W_SYOZOKU_YUKO_YMD				char(8)			--���������L������
	DECLARE @W_KENMU_FG						char(1)			--�����t���O
	DECLARE @W_YUKO_YMD						char(8)			--�L���N����

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

		--���������}�X�^������
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
			 TAISYO_FG				--�Ώۃt���O�i�O�F���ΏہA�P�F�Ώہj
			,SYAIN_ID				--�Ј�ID
			,SYAIN_NO				--�Ј�No
			,SIMEI					--�Ј���
			,SIMEI_KANA				--�Ј����J�i
			,SYAIN_KB				--�Ј��敪
			,SYAIN_KB_DISP			--�Ј��敪��
			,YAKUSYOKU_KB			--��E�敪
			,YAKUSYOKU_KB_DISP		--��E�敪��
			,DAIKO_KB				--��s�敪	
			,DAIKO_KB_DISP			--��s�敪��	
			,TAISYA_YMD				--�ގДN����
			,SYOZOKU_YUKO_YMD		--���������L������
			,KENMU_FG				--�����t���O
			) VALUES (
			 @W_TAISYO_FG			--�Ώۃt���O�i�O�F���ΏہA�P�F�Ώہj
			,@W_SYAIN_ID			--�Ј�ID
			,@W_SYAIN_NO			--�Ј�No
			,@W_SIMEI				--�Ј���
			,@W_SIMEI_KANA			--�Ј����J�i
			,@W_SYAIN_KB			--�Ј��敪
			,@W_SYAIN_KB_DISP		--�Ј��敪��
			,@W_YAKUSYOKU_KB		--��E�敪
			,@W_YAKUSYOKU_KB_DISP	--��E�敪
			,@W_DAIKO_KB			--��s�敪	
			,@W_DAIKO_KB_DISP		--��s�敪��
			,@W_TAISYA_YMD			--�ގДN����
			,@W_SYOZOKU_YUKO_YMD	--���������L������
			,@W_KENMU_FG			--�����t���O
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


