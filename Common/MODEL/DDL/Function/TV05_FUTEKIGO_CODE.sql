USE [FMS]
GO

/****** Object:  UserDefinedFunction [dbo].[TV03_SYOZOKU_SYAIN]    Script Date: 2018/10/11 16:35:39 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO






-- =============================================
-- Author:		JMS-
-- Create date: 2018.
-- Description:	�s�K���敪�ꗗ
-- =============================================
ALTER FUNCTION [dbo].[TV05_FUTEKIGO_CODE] 
(
	 @BUMON_KB				char(1)	--����敪
) RETURNS
	@retTBL TABLE(
	 SEIHIN_KB				char(1)				--���i�敪�i����敪�j
	,SEIHIN_KB_NAME			varchar(150)		--���i�敪���i����敪���j
	,FUTEKIGO_KB			char(2)				--�s�K���敪
	,FUTEKIGO_KB_NAME		nvarchar(150)		--�s�K���敪��
	,FUTEKIGO_S_KB			char(2)				--�s�K���ڍ׋敪
	,FUTEKIGO_S_KB_NAME		char(150)			--�s�K���ڍ׋敪��
	,ADD_YMDHNS				char(14)			--�ǉ�����
	,ADD_SYAIN_ID			int					--�ǉ��Ј�ID
	,ADD_SYAIN_NAME			char(30)			--�ǉ��Ј���
	,UPD_YMDHNS				char(14)			--�X�V����
	,UPD_SYAIN_ID			int					--�X�V�Ј�ID
	,UPD_SYAIN_NAME			char(30)			--�X�V�Ј���
	,DEL_YMDHNS				char(14)			--�폜����
	,DEL_SYAIN_ID			int					--�폜�Ј�ID
	,DEL_SYAIN_NAME			char(30)			--�폜�Ј���
)
AS
BEGIN
	DECLARE @W_SEIHIN_KB			char(1);		--���i�敪�i����敪�j
	DECLARE @W_SEIHIN_KB_NAME		varchar(150);	--���i�敪���i����敪���j
	DECLARE @W_FUTEKIGO_KB			char(2)	;		--�s�K���敪
	DECLARE @W_FUTEKIGO_KB_NAME		nvarchar(150);	--�s�K���敪��
	DECLARE @W_FUTEKIGO_S_KB		char(2);		--�s�K���ڍ׋敪
	DECLARE @W_FUTEKIGO_S_KB_NAME	char(150);		--�s�K���ڍ׋敪��
	DECLARE @GROUP_TAG				nvarchar(20);	--�s�K���ڍׂ̃O���[�v�^�O
	DECLARE @W_ADD_YMDHNS			char(14);		--�ǉ�����
	DECLARE @W_ADD_SYAIN_ID			int;			--�ǉ��Ј�ID
	DECLARE @W_ADD_SYAIN_NAME		char(30);		--�ǉ��Ј���
	DECLARE @W_UPD_YMDHNS			char(14);		--�X�V����
	DECLARE @W_UPD_SYAIN_ID			int;			--�X�V�Ј�ID
	DECLARE @W_UPD_SYAIN_NAME		char(30);		--�X�V�Ј���
	DECLARE @W_DEL_YMDHNS			char(14);		--�폜����
	DECLARE @W_DEL_SYAIN_ID			int;			--�폜�Ј�ID
	DECLARE @W_DEL_SYAIN_NAME		char(30);		--�폜�Ј���

	SET @W_SEIHIN_KB = @BUMON_KB;

	--�����̕���敪����A���喼���擾���ăZ�b�g����
	SELECT @W_SEIHIN_KB_NAME = ITEM_DISP FROM M001_SETTING
	WHERE
	    ITEM_NAME = '����敪'
	AND ITEM_VALUE = @BUMON_KB;

	--����敪�ɂ���āAM01�R�[�h�}�X�^���畔��敪�̕s�K���敪�A�s�K���敪�����擾����
	IF @BUMON_KB = '1'		--���h
	BEGIN
		SET @GROUP_TAG = '���h_�s�K���敪';
	END 
	ELSE IF @BUMON_KB = '2'	--LP
	BEGIN
		SET @GROUP_TAG = 'LP_�s�K���敪';
	END 
	ELSE IF @BUMON_KB = '3'	--������
	BEGIN
		SET @GROUP_TAG = '������_�s�K���敪';
	END
	ELSE
	BEGIN
		SET @GROUP_TAG = '';
	END
			
	DECLARE curTB CURSOR FOR
		SELECT 
		 ITEM_VALUE
		,ITEM_DISP
		FROM M001_SETTING
		WHERE 
		ITEM_NAME = @GROUP_TAG
		ORDER BY DISP_ORDER;

	OPEN curTB;

	WHILE 1 = 1
	BEGIN

		FETCH NEXT FROM curTB INTO 
		 @W_FUTEKIGO_KB
		,@W_FUTEKIGO_KB_NAME

		IF @@FETCH_STATUS <> 0
		BEGIN
			BREAK;
		END

		IF @BUMON_KB = '1'		--���h
		BEGIN
			IF @W_FUTEKIGO_KB = '0'			--�O��
			BEGIN
				SET @GROUP_TAG = '���h_�s�K���O�ϋ敪';
			END 
			ELSE IF @W_FUTEKIGO_KB ='1'		--���@
			BEGIN
				SET @GROUP_TAG = '���h_�s�K�����@�敪';			
			END
			ELSE IF @W_FUTEKIGO_KB = '2'	--�`��
			BEGIN
				SET @GROUP_TAG = '���h_�s�K���`��敪';	
			END 
			ELSE IF @W_FUTEKIGO_KB = '3'	--�@�\�E���\
			BEGIN
				SET @GROUP_TAG = '���h_�s�K���@�\���\�敪';	
			END
			ELSE IF @W_FUTEKIGO_KB = '9'	--���̑�
			BEGIN
				SET @GROUP_TAG = '���h_�s�K�����̑��敪';	
			END;

		END
		ELSE IF @BUMON_KB = '2'		--LP
		BEGIN
			IF @W_FUTEKIGO_KB = '0'			--�O��
			BEGIN
				SET @GROUP_TAG = 'LP_�s�K���O�ϋ敪';
			END 
			ELSE IF @W_FUTEKIGO_KB ='1'		--���@
			BEGIN
				SET @GROUP_TAG = 'LP_�s�K�����@�敪';			
			END
			ELSE IF @W_FUTEKIGO_KB = '2'	--�`��
			BEGIN
				SET @GROUP_TAG = 'LP_�s�K���`��敪';	
			END 
			ELSE IF @W_FUTEKIGO_KB = '3'	--�@�\�E���\
			BEGIN
				SET @GROUP_TAG = 'LP_�s�K���@�\���\�敪';	
			END
			ELSE IF @W_FUTEKIGO_KB = '9'	--���̑�
			BEGIN
				SET @GROUP_TAG = 'LP_�s�K�����̑��敪';	
			END;
		END
		ELSE IF @BUMON_KB = '3'		--������
		BEGIN
			IF @W_FUTEKIGO_KB = '0'			--���@
			BEGIN
				SET @GROUP_TAG = '������_�s�K�����@�敪';
			END 
			ELSE IF @W_FUTEKIGO_KB ='1'		--�`��
			BEGIN
				SET @GROUP_TAG = '������_�s�K���`��敪';			
			END
			ELSE IF @W_FUTEKIGO_KB = '2'	--���E
			BEGIN
				SET @GROUP_TAG = '������_�s�K�����E�敪';	
			END 
			ELSE IF @W_FUTEKIGO_KB = '3'	--�O��
			BEGIN
				SET @GROUP_TAG = '������_�s�K���O�ϋ敪';	
			END
			ELSE IF @W_FUTEKIGO_KB = '4'	--��������
			BEGIN
				SET @GROUP_TAG = '������_�s�K���������׋敪';	
			END
			ELSE IF @W_FUTEKIGO_KB = '5'	--�d������
			BEGIN
				SET @GROUP_TAG = '������_�s�K���d�������敪';	
			END
			ELSE IF @W_FUTEKIGO_KB = '6'	--�v���Z�X
			BEGIN
				SET @GROUP_TAG = '������_�s�K���v���Z�X�敪';	
			END
			ELSE IF @W_FUTEKIGO_KB = '9'	--���̑�
			BEGIN
				SET @GROUP_TAG = '������_�s�K�����̑��敪';	
			END;
		END


		--�ēx�A�R�[�h�}�X�^���������āA�s�K���ڍ׋敪�ƕs�K���ڍ׋敪�����擾����
		DECLARE curTB2 CURSOR FOR
		SELECT
		 ITEM_VALUE
		,ITEM_DISP
		,ADD_YMDHNS				--�ǉ�����
		,ADD_SYAIN_ID			--�ǉ��Ј�ID
		,ADD_SYAIN_NAME			--�ǉ��Ј���
		,UPD_YMDHNS				--�X�V����
		,UPD_SYAIN_ID			--�X�V�Ј�ID
		,UPD_SYAIN_NAME			--�X�V�Ј���
		,DEL_YMDHNS				--�폜����
		,DEL_SYAIN_ID			--�폜�Ј�ID
		,DEL_SYAIN_NAME			--�폜�Ј���
		FROM VWM001_SETTING
		WHERE 
		ITEM_NAME = @GROUP_TAG
		ORDER BY DISP_ORDER;
		
		OPEN curTB2;

		WHILE 1 = 1
		BEGIN
			
			FETCH NEXT FROM curTB2 INTO 
			 @W_FUTEKIGO_S_KB
			,@W_FUTEKIGO_S_KB_NAME
			,@W_ADD_YMDHNS			--�ǉ�����
			,@W_ADD_SYAIN_ID		--�ǉ��Ј�ID
			,@W_ADD_SYAIN_NAME		--�ǉ��Ј���
			,@W_UPD_YMDHNS			--�X�V����
			,@W_UPD_SYAIN_ID		--�X�V�Ј�ID
			,@W_UPD_SYAIN_NAME		--�X�V�Ј���
			,@W_DEL_YMDHNS			--�폜����
			,@W_DEL_SYAIN_ID		--�폜�Ј�ID
			,@W_DEL_SYAIN_NAME		--�폜�Ј���
			;

			IF @@FETCH_STATUS <> 0
			BEGIN
				BREAK;
			END

			INSERT INTO @retTBL 
				(
				 SEIHIN_KB				--���i�敪�i����敪�j
				,SEIHIN_KB_NAME			--���i�敪���i����敪���j
				,FUTEKIGO_KB			--�s�K���敪
				,FUTEKIGO_KB_NAME		--�s�K���敪��
				,FUTEKIGO_S_KB			--�s�K���ڍ׋敪
				,FUTEKIGO_S_KB_NAME		--�s�K���ڍ׋敪��
				,ADD_YMDHNS				--�ǉ�����
				,ADD_SYAIN_ID			--�ǉ��Ј�ID
				,ADD_SYAIN_NAME			--�ǉ��Ј���
				,UPD_YMDHNS				--�X�V����
				,UPD_SYAIN_ID			--�X�V�Ј�ID
				,UPD_SYAIN_NAME			--�X�V�Ј���
				,DEL_YMDHNS				--�폜����
				,DEL_SYAIN_ID			--�폜�Ј�ID
				,DEL_SYAIN_NAME			--�폜�Ј���
				) VALUES (
				  @W_SEIHIN_KB			--���i�敪�i����敪�j
				, @W_SEIHIN_KB_NAME		--���i�敪���i����敪���j
				, @W_FUTEKIGO_KB		--�s�K���敪
				, @W_FUTEKIGO_KB_NAME	--�s�K���敪��
				, @W_FUTEKIGO_S_KB		--�s�K���ڍ׋敪
				, @W_FUTEKIGO_S_KB_NAME	--�s�K���ڍ׋敪��
				, @W_ADD_YMDHNS			--�ǉ�����
				, @W_ADD_SYAIN_ID		--�ǉ��Ј�ID
				, @W_ADD_SYAIN_NAME		--�ǉ��Ј���
				, @W_UPD_YMDHNS			--�X�V����
				, @W_UPD_SYAIN_ID		--�X�V�Ј�ID
				, @W_UPD_SYAIN_NAME		--�X�V�Ј���
				, @W_DEL_YMDHNS			--�폜����
				, @W_DEL_SYAIN_ID		--�폜�Ј�ID
				, @W_DEL_SYAIN_NAME		--�폜�Ј���
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


