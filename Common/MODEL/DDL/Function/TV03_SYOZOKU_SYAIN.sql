USE [FMS]
GO
/****** Object:  UserDefinedFunction [dbo].[TV03_SYOZOKU_SYAIN]    Script Date: 2018/11/15 11:09:29 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO






-- =============================================
-- Author:		JMS-
-- Create date: 2018.
-- Description:	�����Ј����擾
-- =============================================
ALTER FUNCTION [dbo].[TV03_SYOZOKU_SYAIN] 
(
	 @BUMON_KB				char(1)	--����敪	 
) RETURNS
	@retTBL TABLE(
	 SYAIN_ID				int					--�Ј�ID
	,SYAIN_NO				varchar(8)			--�Ј�No
	,SIMEI					nvarchar(30)		--�Ј���
	,SIMEI_KANA				nvarchar(60)		--�Ј����J�i
	,BUMON_KB				char(1)
	,BUSYO_ID				int					--����ID
	,BUSYO_NAME				nvarchar(30)		--������
	,GYOMU_GROUP_ID				int		--�Ɩ��O���[�v
	,GYOMU_GROUP_NAME				nvarchar(30)		--�Ɩ��O���[�v��
	,IS_LEADER			int --���������ǂ���(0:False 1:True
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
	DECLARE @W_GYOMU_GROUP_ID			int;
	DECLARE @W_GYOMU_GROUP_NAME		nvarchar(30);
	DECLARE @W_SYOZOKUCYO_ID			int;
	DECLARE @W_IS_LEADER			int;

	
	IF @BUMON_KB = 1 OR @BUMON_KB = 2
		--�q��@����
		DECLARE curTB CURSOR FOR
		SELECT M002.BUSYO_ID, M002.BUSYO_NAME, M002.BUMON_KB
		FROM M002_BUSYO M002
		WHERE M002.BUMON_KB IN (1, 2)
		AND M002.YUKO_YMD >= (SELECT MIN(YUKO_YMD) FROM M002_BUSYO WHERE BUMON_KB = M002.BUMON_KB AND YUKO_YMD >= FORMAT(GETDATE(), 'yyyyMMdd'))
		ORDER BY BUSYO_ID;
	ELSE
		--�����ނ��̑�
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

		--���������}�X�^������
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

			SELECT
				@W_SYAIN_NO = M004.SYAIN_NO
			  , @W_SIMEI = M004.SIMEI
			  , @W_SIMEI_KANA = M004.SIMEI_KANA
			  , @W_GYOMU_GROUP_ID = ISNULL(IIF(@W_BUSYO_ID=10,2, M011.GYOMU_GROUP_ID), 0)
			  , @W_GYOMU_GROUP_NAME = ISNULL((SELECT GYOMU_GROUP_NAME FROM M003_GYOMU_GROUP M003 WHERE M003.GYOMU_GROUP_ID = IIF(@W_BUSYO_ID=10,2,M011.GYOMU_GROUP_ID)) , '') 
			FROM
			  M005_SYOZOKU_BUSYO M005   
			  LEFT JOIN M004_SYAIN M004 
				ON M005.SYAIN_ID = M004.SYAIN_ID
			  LEFT JOIN M011_SYAIN_GYOMU M011 
				ON M011.SYAIN_ID = M004.SYAIN_ID			   
			WHERE
			  M004.SYAIN_ID = @W_SYAIN_ID AND M005.BUSYO_ID = @W_BUSYO_ID; 

			
			SET @W_IS_LEADER = IIF(@W_SYAIN_ID = @W_SYOZOKUCYO_ID,1,0)
			
			INSERT INTO @retTBL 
				(
				 SYAIN_ID				--�Ј�ID
				,SYAIN_NO				--�Ј�No
				,SIMEI					--�Ј���
				,SIMEI_KANA				--�Ј����J�i
				,BUMON_KB
				,BUSYO_ID				--����ID
				,BUSYO_NAME				--������
				,GYOMU_GROUP_ID
				,GYOMU_GROUP_NAME
				,IS_LEADER
				) VALUES (
				 @W_SYAIN_ID			--�Ј�ID
				,@W_SYAIN_NO			--�Ј�No
				,@W_SIMEI				--�Ј���
				,@W_SIMEI_KANA			--�Ј����J�i
				,@W_BUMON_KB
				,@W_BUSYO_ID			--����ID
				,@W_BUSYO_NAME			--������
				,@W_GYOMU_GROUP_ID
				,@W_GYOMU_GROUP_NAME
				,@W_IS_LEADER
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


