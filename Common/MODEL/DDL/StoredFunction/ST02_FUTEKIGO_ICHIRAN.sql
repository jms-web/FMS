USE [FMS]
GO

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

-- =============================================
-- Description:	�s�K���񍐏��ꗗ
-- =============================================
ALTER PROCEDURE [dbo].[ST02_FUTEKIGO_ICHIRAN]
  @BUMON_KB					char(2)			--����敪
 ,@SYONIN_HOKOKUSYO_ID		int				--���F�񍐏�ID
 ,@KISYU_ID					int				--�@��ID
 ,@BUHIN_BANGO				char(60)		--���i�ԍ�
 ,@SYANAI_CD				char(10)		--�Г��R�[�h
 ,@BUHIN_NAME				char(100)		--���i����
 ,@GOKI						nvarchar(20)			--���@
 ,@GEN_TANTO_ID				int				--�����u�S����ID
 ,@SYONIN_YMDHNS_FROM		char(8)			--���u���{��From�i���F�����������ΏۂƂ���j
 ,@SYONIN_YMDHNS_TO			char(8)			--���u���{��To�i���F�����������ΏۂƂ���j
 ,@HOKOKU_NO				char(10)		--�񍐏�No
 ,@KISO_TANTO_ID			int				--�N���S����ID
 ,@CLOSE_FG					char(1)			--�N���[�Y�t���O
 ,@TAIRYU_FG				char(1)			--�ؗ��t���O
 ,@FUTEKIGO_KB				char(2)			--�s�K���敪
 ,@FUTEKIGO_S_KB			char(2)			--�s�K���ڍ׋敪
 ,@FUTEKIGO_JYOTAI_KB		char(2)			--�s�K����ԋ敪
 ,@JIZEN_SINSA_HANTEI_KB	char(2)			--���O�R������敪
 ,@ZESEI_SYOCHI_YOHI_KB		char(2)			--�������u�v�ۋ敪
 ,@SAISIN_IINKAI_HANTEI_KB	char(2)			--�ĐR�ψ����敪
 ,@KENSA_KEKKA_KB			char(2)			--�������ʋ敪
 ,@KONPON_YOIN_KB1			char(2)			--���{�v���敪1
 ,@KONPON_YOIN_KB2			char(2)			--���{�v���敪2
 ,@KISEKI_KOTEI_KB			char(2)			--�A�ӍH���敪
 ,@KOKYAKU_HANTEI_SIJI_KB	char(2)			--�ڋq����w���敪
 ,@KOKYAKU_SAISYU_HANTEI_KB char(2)			--�ڋq�ŏI����敪
 ,@GENIN_BUNSEKI_KB1		nvarchar(500)	--�������͋敪1��WHERE�����̓��e�����̂܂܃Z�b�g����
 ,@GENIN_BUNSEKI_KB2		nvarchar(500)	--�������͋敪2��WHERE�����̓��e�����̂܂܃Z�b�g����
 ,@HASSEI_YMD_FROM			char(8)
 ,@HASSEI_YMD_TO				char(8)
AS
BEGIN TRY
	DECLARE @ErrorMessage varchar(4000);
	DECLARE @ErrorProcedure NVARCHAR(126);

	DECLARE @W_HOKOKU_NO					char(10);		-- 1.�񍐏�No
	DECLARE @W_SYONIN_JUN					int;			-- 2.���F��
	DECLARE @W_SYONIN_NAIYO					nvarchar(50);	-- 3.���F���e�i�X�e�[�W�j
	DECLARE @W_SYONIN_HOKOKUSYO_ID			int;			-- 4.���F�񍐏�ID
	DECLARE @W_SYONIN_HOKOKUSYO_NAME		nvarchar(50);	-- 5.���F�񍐏���
	DECLARE @W_SYONIN_HOKOKUSYO_R_NAME		nvarchar(10);	-- 6.���F�񍐏�����
	DECLARE @W_GEN_TANTO_ID					int;			-- 7.���F�S����ID�i�����u�S����ID�j
	DECLARE @W_GEN_TANTO_NAME				char(30);		-- 8.���F�S���Җ�
	DECLARE @W_SYONIN_YMDHNS				char(8);		-- 9.���F�����i���u���{���j
	DECLARE @W_TAIRYU_NISSU					int;			--10.�ؗ�����
	DECLARE @W_TAIRYU_FG					char(1);		--11.�ؗ��t���O
	DECLARE @W_KISYU_ID						int;			--12.�@��ID
	--DECLARE @W_KISYU						char(100);		--13.�@��
	DECLARE @W_KISYU_NAME					char(100);		--14.�@�햼
	DECLARE @W_BUHIN_BANGO					char(60);		--15.���i�ԍ�
	DECLARE @W_BUHIN_NAME					char(80);		--16.���i��
	DECLARE @W_GOKI							 nvarchar(20);		--17.���@
	DECLARE @W_SYANAI_CD					char(10);		--18.�Г��R�[�h
	DECLARE @W_FUTEKIGO_KB					char(2);		--19.�s�K���敪
	DECLARE @W_FUTEKIGO_NAME				char(50);		--20.�s�K���敪��
	DECLARE @W_FUTEKIGO_S_KB				char(2);		--21.�s�K���ڍ׋敪
	DECLARE @W_FUTEKIGO_S_NAME				char(50);		--22.�s�K���ڍ׋敪��
	DECLARE @W_FUTEKIGO_JYOTAI_KB			char(2);		--23.�s�K����ԋ敪
	DECLARE @W_FUTEKIGO_JYOTAI_NAME			char(50);		--24.�s�K����ԋ敪
	DECLARE @W_JIZEN_SINSA_HANTEI_KB		char(2);		--25.���O�R������敪
	DECLARE @W_JIZEN_SINSA_HANTEI_NAME		char(150);		--26.���O�R������敪��
	DECLARE @W_ZESEI_SYOCHI_YOHI_KB			char(2);		--27.�������u�v�ۋ敪
	DECLARE @W_ZESEI_SYOCHI_YOHI_NAME		char(50);		--28.�������u�v�ۋ敪��
	DECLARE @W_SAISIN_IINKAI_HANTEI_KB		char(2);		--29.�ĐR�ψ����敪
	DECLARE @W_SAISIN_IINKAI_HANTEI_NAME	char(50);		--30.�ĐR�ψ����敪��
	DECLARE @W_KENSA_KEKKA_KB				char(2);		--31.�������ʋ敪
	DECLARE @W_KENSA_KEKKA_NAME				char(50);		--32.�������ʋ敪��
	DECLARE @W_KONPON_YOIN_KB1				char(2);		--33.���{�v���敪1
	DECLARE @W_KONPON_YOIN_NAME1			char(50);		--34.���{�v���敪��1
	DECLARE @W_KONPON_YOIN_KB2				char(2);		--35.���{�v���敪2
	DECLARE @W_KONPON_YOIN_NAME2			char(50);		--36.���{�v���敪��2
	DECLARE @W_KISEKI_KOTEI_KB				char(2);		--37.�A�ӍH���敪
	DECLARE @W_KISEKI_KOTEI_NAME			char(50);		--38.�A�ӍH���敪��
	DECLARE @W_KISO_YMD						char(8);		--39.�N����
	DECLARE @W_KISO_TANTO_ID				int;		--40.�N���S����ID
	DECLARE @W_KISO_TANTO_NAME				char(30);		--41.�N���S���Җ�
	DECLARE @W_CLOSE_FG						char(1);		--42.�N���[�Y�t���O
	DECLARE @W_SASIMOTO_SYONIN_JUN			int;			--43.���ߌ����F��
	DECLARE @W_SASIMOTO_SYONIN_NAIYO		nvarchar(50);	--44.���ߌ����F���e�i���߂����X�e�[�W�j
	DECLARE @W_RIYU							nvarchar(100);	--45.���ߗ��R
	DECLARE @W_YOKYU_NAIYO					nvarchar(500);	--46.�v�����e
	DECLARE @W_BUMON_KB						char(1);		--47.����敪
	DECLARE @W_BUMON_NAME					char(50);		--48.����敪
	DECLARE @W_KOKYAKU_HANTEI_SIJI_KB		char(2);		--49.�ڋq����w���敪
	DECLARE @W_KOKYAKU_HANTEI_SIJI_NAME		nvarchar(150);	--50.�ڋq����w���敪��
	DECLARE @W_KOKYAKU_SAISYU_HANTEI_KB	    char(2);		--51.�ڋq�ŏI����敪
	DECLARE @W_KOKYAKU_SAISYU_HANTEI_NAME	nvarchar(150);	--52.�ڋq�ŏI����敪��
	DECLARE @W_DEL_YMDHNS char(14);
	DECLARE @W_HASSEI_YMD char(8);

	DECLARE @retTBL TABLE(
	 HOKOKU_NO					char(10)		-- 1.�񍐏�No
	,SYONIN_JUN					int				-- 2.���F��
	,SYONIN_NAIYO				nvarchar(100)	-- 3.���F���e�i�X�e�[�W�j
	,SYONIN_HOKOKUSYO_ID		int				-- 4.���F�񍐏�ID
	,SYONIN_HOKOKUSYO_NAME		nvarchar(50)	-- 5.���F�񍐏���
	,SYONIN_HOKOKUSYO_R_NAME	nvarchar(20)	-- 6.���F�񍐏�����
	,GEN_TANTO_ID				int				-- 7.���F�S����ID�i�����u�S����ID�j
	,GEN_TANTO_NAME				char(30)		-- 8.���F�S���Җ�
	,SYONIN_YMDHNS				char(8)			-- 9.���F�����i���u���{���j
	,TAIRYU_NISSU				int				--10.�ؗ�����
	,TAIRYU_FG					char(1)			--11.�ؗ��t���O
	,KISYU_ID					int				--12.�@��ID
	--,KISYU						char(100)		--13.�@��
	,KISYU_NAME					char(100)		--14.�@�햼
	,BUHIN_BANGO				char(60)		--15.���i�ԍ�
	,BUHIN_NAME					char(80)		--16.���i��
	,GOKI						nvarchar(20)			--17.���@
	,SYANAI_CD					char(10)		--18.�Г��R�[�h
	,FUTEKIGO_KB				char(2)			--19.�s�K���敪
	,FUTEKIGO_NAME				char(50)		--20.�s�K���敪��
	,FUTEKIGO_S_KB				char(2)			--21.�s�K���ڍ׋敪
	,FUTEKIGO_S_NAME			char(50)		--22.�s�K���ڍ׋敪��
	,FUTEKIGO_JYOTAI_KB			char(2)			--23.�s�K����ԋ敪
	,FUTEKIGO_JYOTAI_NAME		char(50)		--24.�s�K����ԋ敪
	,JIZEN_SINSA_HANTEI_KB		char(2)			--25.���O�R������敪
	,JIZEN_SINSA_HANTEI_NAME	char(150)		--26.���O�R������敪��
	,ZESEI_SYOCHI_YOHI_KB		char(2)			--27.�������u�v�ۋ敪
	,ZESEI_SYOCHI_YOHI_NAME		char(50)		--28.�������u�v�ۋ敪��
	,SAISIN_IINKAI_HANTEI_KB	char(2)			--29.�ĐR�ψ����敪
	,SAISIN_IINKAI_HANTEI_NAME	char(50)			--30.�ĐR�ψ����敪��
	,KENSA_KEKKA_KB				char(2)			--31.�������ʋ敪
	,KENSA_KEKKA_NAME			char(50)			--32.�������ʋ敪��
	,KONPON_YOIN_KB1			char(2)			--33.���{�v���敪1
	,KONPON_YOIN_NAME1			char(50)		--34.���{�v���敪��1
	,KONPON_YOIN_KB2			char(2)			--35.���{�v���敪2
	,KONPON_YOIN_NAME2			char(50)		--36.���{�v���敪��2
	,KISEKI_KOTEI_KB			char(2)			--37.�A�ӍH���敪
	,KISEKI_KOTEI_NAME			char(50)		--38.�A�ӍH���敪��
	,KISO_YMD					char(8)			--39.�N����
	,KISO_TANTO_ID				int			--40.�N���S����ID
	,KISO_TANTO_NAME			char(30)		--41.�N���S���Җ�
	,CLOSE_FG					char(1)			--42.�N���[�Y�t���O
	--,MAE_SYOCHI_YMD				char(8)			--43.�O���u���{��
	,SASIMOTO_SYONIN_JUN		int				--43.���ߌ����F��
	,SASIMOTO_SYONIN_NAIYO		nvarchar(50)	--44.���ߌ����F���e�i���߂����X�e�[�W�j
	,RIYU						nvarchar(100)	--45.���ߗ��R
	,YOKYU_NAIYO				nvarchar(500)	--46.�v�����e
	,BUMON_KB					char(1)			--47.����敪
	,BUMON_NAME					char(50)		--48.����敪��
	,KOKYAKU_HANTEI_SIJI_KB		char(2)			--49.�ڋq����w���敪
	,KOKYAKU_HANTEI_SIJI_NAME	nvarchar(150)	--50.�ڋq����w���敪��
	,KOKYAKU_SAISYU_HANTEI_KB	char(2)			--51.�ڋq�ŏI����敪
	,KOKYAKU_SAISYU_HANTEI_NAME nvarchar(150)	--52.�ڋq�ŏI����敪��
	,DEL_YMDHNS char(14)
	,HASSEI_YMD char(8)
	);

	--SQL ���쐬����ϐ��錾
	DECLARE @SQL nvarchar(max)

	--�J�[�\�������s����SQL���쐬����

	SET @SQL = N'';
	SET @SQL = @SQL + N' SELECT  ';
	SET @SQL = @SQL + N' HOKOKU_NO';					-- 1.�񍐏�No
	SET @SQL = @SQL + N',SYONIN_JUN';					-- 2.���F��
	SET @SQL = @SQL + N',SYONIN_NAIYO';					-- 3.���F���e�i�X�e�[�W�j
	SET @SQL = @SQL + N',SYONIN_HOKOKUSYO_ID';			-- 4.���F�񍐏�ID
	SET @SQL = @SQL + N',SYONIN_HOKOKUSYO_NAME';		-- 5.���F�񍐏���
	SET @SQL = @SQL + N',SYONIN_HOKOKUSYO_R_NAME';		-- 6.���F�񍐏�����
	SET @SQL = @SQL + N',GEN_TANTO_ID';					-- 7.���F�S����ID�i�����u�S����ID�j
	SET @SQL = @SQL + N',GEN_TANTO_NAME';				-- 8.���F�S���Җ�
	SET @SQL = @SQL + N',SYONIN_YMDHNS';				-- 9.���F�����i���u���{���j
	SET @SQL = @SQL + N',TAIRYU_NISSU';					--10.�ؗ�����
	SET @SQL = @SQL + N',TAIRYU_FG';					--11.�ؗ��t���O
	SET @SQL = @SQL + N',KISYU_ID';						--12.�@��ID
	--SET @SQL = @SQL + N',KISYU';						--13.�@��
	SET @SQL = @SQL + N',KISYU_NAME';					--14.�@�햼
	SET @SQL = @SQL + N',BUHIN_BANGO';					--15.���i�ԍ�
	SET @SQL = @SQL + N',BUHIN_NAME';					--16.���i��
	SET @SQL = @SQL + N',GOKI';							--17.���@
	SET @SQL = @SQL + N',SYANAI_CD';					--18.�Г��R�[�h
	SET @SQL = @SQL + N',FUTEKIGO_KB';					--19.�s�K���敪
	SET @SQL = @SQL + N',FUTEKIGO_NAME';				--20.�s�K���敪��
	SET @SQL = @SQL + N',FUTEKIGO_S_KB';				--21.�s�K���ڍ׋敪
	SET @SQL = @SQL + N',FUTEKIGO_S_NAME';				--22.�s�K���ڍ׋敪��
	SET @SQL = @SQL + N',FUTEKIGO_JYOTAI_KB';			--23.�s�K����ԋ敪
	SET @SQL = @SQL + N',FUTEKIGO_JYOTAI_NAME';			--24.�s�K����ԋ敪
	SET @SQL = @SQL + N',JIZEN_SINSA_HANTEI_KB';		--25.���O�R������敪
	SET @SQL = @SQL + N',JIZEN_SINSA_HANTEI_NAME';		--26.���O�R������敪��
	SET @SQL = @SQL + N',ZESEI_SYOCHI_YOHI_KB';			--27.�������u�v�ۋ敪
	SET @SQL = @SQL + N',ZESEI_SYOCHI_YOHI_NAME';		--28.�������u�v�ۋ敪��
	SET @SQL = @SQL + N',SAISIN_IINKAI_HANTEI_KB';		--29.�ĐR�ψ����敪
	SET @SQL = @SQL + N',SAISIN_IINKAI_HANTEI_NAME';	--30.�ĐR�ψ����敪��
	SET @SQL = @SQL + N',KENSA_KEKKA_KB';				--31.�������ʋ敪
	SET @SQL = @SQL + N',KENSA_KEKKA_NAME';				--32.�������ʋ敪��
	SET @SQL = @SQL + N',KONPON_YOIN_KB1';				--33.���{�v���敪1
	SET @SQL = @SQL + N',KONPON_YOIN_NAME1';			--34.���{�v���敪��1
	SET @SQL = @SQL + N',KONPON_YOIN_KB2';				--35.���{�v���敪2
	SET @SQL = @SQL + N',KONPON_YOIN_NAME2';			--36.���{�v���敪��2
	SET @SQL = @SQL + N',KISEKI_KOTEI_KB';				--37.�A�ӍH���敪
	SET @SQL = @SQL + N',KISEKI_KOTEI_NAME';			--38.�A�ӍH���敪��
	SET @SQL = @SQL + N',KISO_YMD';						--39.�N����
	SET @SQL = @SQL + N',KISO_TANTO_ID';				--40.�N���S����ID
	SET @SQL = @SQL + N',KISO_TANTO_NAME';				--41.�N���S���Җ�
	SET @SQL = @SQL + N',CLOSE_FG';						--42.�N���[�Y�t���O
	SET @SQL = @SQL + N',SASIMOTO_SYONIN_JUN';			--43.���ߌ����F��
	SET @SQL = @SQL + N',SASIMOTO_SYONIN_NAIYO';		--44.���ߌ����F���e�i���߂����X�e�[�W�j
	SET @SQL = @SQL + N',RIYU';							--45.���ߗ��R
	SET @SQL = @SQL + N',YOKYU_NAIYO';					--46.�v�����e
	SET @SQL = @SQL + N',BUMON_KB';						--47.����敪
	SET @SQL = @SQL + N',BUMON_NAME';					--48.����敪
	SET @SQL = @SQL + N',KOKYAKU_HANTEI_SIJI_KB';		--49.�ڋq����w���敪
	SET @SQL = @SQL + N',KOKYAKU_HANTEI_SIJI_NAME';		--50.�ڋq����w���敪��
	SET @SQL = @SQL + N',KOKYAKU_SAISYU_HANTEI_KB';		--51.�ڋq�ŏI����敪
	SET @SQL = @SQL + N',KOKYAKU_SAISYU_HANTEI_NAME';	--52.�ڋq�ŏI����敪��
	SET @SQL = @SQL + N',DEL_YMDHNS';	--2018.06.05 Add by funato
	SET @SQL = @SQL + N',HASSEI_YMD';	--2018.06.05 Add by funato
	SET @SQL = @SQL + N' FROM V007_NCR_CAR ';

	SET @SQL = @SQL + N' WHERE HOKOKU_NO <> '''' '

	--����敪
	IF RTRIM(LTRIM(@BUMON_KB)) <> ''
	BEGIN
		SET @SQL = @SQL + N' AND BUMON_KB = ''' + RTRIM(LTRIM(@BUMON_KB)) + ''' ';
	END

	--���F�񍐏�ID
	IF @SYONIN_HOKOKUSYO_ID <> 0
	BEGIN
		SET @SQL = @SQL + N' AND SYONIN_HOKOKUSYO_ID = ' + CONVERT(char,@SYONIN_HOKOKUSYO_ID) + '';
	END

	--�@��ID
	IF @KISYU_ID <> 0
	BEGIN
		SET @SQL = @SQL + N' AND KISYU_ID = ' + CONVERT(char,@KISYU_ID) + '';
	END

	--���i�ԍ�
	IF RTRIM(LTRIM(@BUHIN_BANGO)) <> ''
	BEGIN
		SET @SQL = @SQL + N' AND BUHIN_BANGO LIKE ''%' + RTRIM(LTRIM(@BUHIN_BANGO)) + '%'' ';
	END

	--�Г��R�[�h
	IF RTRIM(LTRIM(@SYANAI_CD)) <> ''
	BEGIN
		SET @SQL = @SQL + N' AND SYANAI_CD LIKE ''%' + RTRIM(LTRIM(@SYANAI_CD)) + '%'' ';
	END

	--���i����
	IF RTRIM(LTRIM(@BUHIN_NAME)) <> ''
	BEGIN
		SET @SQL = @SQL + N' AND BUHIN_NAME LIKE ''%' + RTRIM(LTRIM(@BUHIN_NAME)) + '%'' ';
	END

	--���@
	IF RTRIM(LTRIM(@GOKI)) <> ''
	BEGIN
		SET @SQL = @SQL + N' AND GOKI LIKE ''%' + RTRIM(LTRIM(@GOKI)) + '%'' ';
	END

	--�����u�S����ID
	IF @GEN_TANTO_ID <> 0
	BEGIN
		SET @SQL = @SQL + N' AND GEN_TANTO_ID = ' + CONVERT(char,@GEN_TANTO_ID) + '';
	END

	--���u���{��From
	IF RTRIM(LTRIM(@SYONIN_YMDHNS_FROM)) <> ''
	BEGIN
		SET @SQL = @SQL + N' AND substring(SYONIN_YMDHNS,1,8) >= ''' + RTRIM(LTRIM(@SYONIN_YMDHNS_FROM)) + ''' ';
	END

	--���u���{��To
	IF RTRIM(LTRIM(@SYONIN_YMDHNS_TO)) <> ''
	BEGIN
		SET @SQL = @SQL + N' AND substring(SYONIN_YMDHNS,1,8) <= ''' + RTRIM(LTRIM(@SYONIN_YMDHNS_TO)) + ''' ';
	END

	--�񍐏�No
	IF RTRIM(LTRIM(@HOKOKU_NO)) <> ''
	BEGIN
		SET @SQL = @SQL + N' AND HOKOKU_NO =''' + RTRIM(LTRIM(@HOKOKU_NO)) + ''' ';
	END

	--�N���S����ID
	IF @KISO_TANTO_ID <> 0
	BEGIN
		SET @SQL = @SQL + N' AND KISO_TANTO_ID = ' + CONVERT(char,@KISO_TANTO_ID) + '';
	END

	--�N���[�Y�t���O
	IF RTRIM(LTRIM(@CLOSE_FG)) <> ''
	BEGIN
		SET @SQL = @SQL + N' AND CLOSE_FG = ''' + RTRIM(LTRIM(@CLOSE_FG)) + ''' ';
	END

	--�ؗ��t���O
	IF RTRIM(LTRIM(@TAIRYU_FG)) <> ''
	BEGIN
		SET @SQL = @SQL + N' AND TAIRYU_FG = ''' + RTRIM(LTRIM(@TAIRYU_FG)) + ''' ';
	END

	--�s�K���敪
	IF RTRIM(LTRIM(@FUTEKIGO_KB)) <> ''
	BEGIN
		SET @SQL = @SQL + N' AND FUTEKIGO_KB = ''' + RTRIM(LTRIM(@FUTEKIGO_KB)) + ''' ';
	END

	--�s�K���ڍ׋敪
	IF RTRIM(LTRIM(@FUTEKIGO_S_KB)) <> ''
	BEGIN
		SET @SQL = @SQL + N' AND FUTEKIGO_S_KB = ''' + RTRIM(LTRIM(@FUTEKIGO_S_KB)) + ''' ';
	END

	--�s�K����ԋ敪
	IF RTRIM(LTRIM(@FUTEKIGO_JYOTAI_KB)) <> ''
	BEGIN
		SET @SQL = @SQL + N' AND FUTEKIGO_JYOTAI_KB = ''' + RTRIM(LTRIM(@FUTEKIGO_JYOTAI_KB)) + ''' ';
	END

	--���O�R������敪
	IF RTRIM(LTRIM(@JIZEN_SINSA_HANTEI_KB)) <> ''
	BEGIN
		SET @SQL = @SQL + N' AND JIZEN_SINSA_HANTEI_KB = ''' + RTRIM(LTRIM(@JIZEN_SINSA_HANTEI_KB)) + ''' ';
	END

	--�������u�v�ۋ敪
	IF RTRIM(LTRIM(@ZESEI_SYOCHI_YOHI_KB)) <> ''
	BEGIN
		SET @SQL = @SQL + N' AND ZESEI_SYOCHI_YOHI_KB = ''' + RTRIM(LTRIM(@ZESEI_SYOCHI_YOHI_KB)) + ''' ';
	END

	--�ĐR�ψ����敪
	IF RTRIM(LTRIM(@SAISIN_IINKAI_HANTEI_KB)) <> ''
	BEGIN
		SET @SQL = @SQL + N' AND SAISIN_IINKAI_HANTEI_KB = ''' + RTRIM(LTRIM(@SAISIN_IINKAI_HANTEI_KB)) + ''' ';
	END

	--�������ʋ敪
	IF RTRIM(LTRIM(@KENSA_KEKKA_KB)) <> ''
	BEGIN
		SET @SQL = @SQL + N' AND KENSA_KEKKA_KB = ''' + RTRIM(LTRIM(@KENSA_KEKKA_KB)) + ''' ';
	END

	--���{�v���敪1
	IF RTRIM(LTRIM(@KONPON_YOIN_KB1)) <> ''
	BEGIN
		SET @SQL = @SQL + N' AND KONPON_YOIN_KB1 = ''' + RTRIM(LTRIM(@KONPON_YOIN_KB1)) + ''' ';
	END

	--���{�v���敪2
	IF RTRIM(LTRIM(@KONPON_YOIN_KB2)) <> ''
	BEGIN
		SET @SQL = @SQL + N' AND KONPON_YOIN_KB2 = ''' + RTRIM(LTRIM(@KONPON_YOIN_KB2)) + ''' ';
	END

	--�A�ӍH���敪
	IF RTRIM(LTRIM(@KISEKI_KOTEI_KB)) <> ''
	BEGIN
		SET @SQL = @SQL + N' AND KISEKI_KOTEI_KB = ''' + RTRIM(LTRIM(@KISEKI_KOTEI_KB)) + ''' ';
	END

	--�������͋敪1
	IF RTRIM(LTRIM(@GENIN_BUNSEKI_KB1)) <> ''
	BEGIN
		SET @SQL = @SQL + N' ' + @GENIN_BUNSEKI_KB1 + ' ';
	END

	--�������͋敪2
	IF RTRIM(LTRIM(@GENIN_BUNSEKI_KB2)) <> ''
	BEGIN
		SET @SQL = @SQL + N' ' + @GENIN_BUNSEKI_KB2 + ' ';
	END
	/*
	--�ڋq����w���敪
	IF RTRIM(LTRIM(@KOKYAKU_HANTEI_SIJI_KB)) <> ''
	BEGIN
		SET @SQL = @SQL + N' AND KOKYAKU_HANTEI_SIJI_KB = ''' + @KOKYAKU_HANTEI_SIJI_KB + ''' ';
	END

	--�ڋq�ŏI����敪
	IF RTRIM(LTRIM(@KOKYAKU_SAISYU_HANTEI_KB)) <> ''
	BEGIN
		SET @SQL = @SQL + N' AND KOKYAKU_SAISYU_HANTEI_KB = ''' + @KOKYAKU_SAISYU_HANTEI_KB + ''' ';
	END
	*/

	--������From
	IF RTRIM(LTRIM(@HASSEI_YMD_FROM)) <> ''
	BEGIN
		SET @SQL = @SQL + N' AND HASSEI_YMD >= ''' + RTRIM(LTRIM(@HASSEI_YMD_FROM)) + ''' ';
	END

	--������To
	IF RTRIM(LTRIM(@HASSEI_YMD_TO)) <> ''
	BEGIN
		SET @SQL = @SQL + N' AND HASSEI_YMD <= ''' + RTRIM(LTRIM(@HASSEI_YMD_TO)) + ''' ';
	END

	--�J�[�\����`
	EXECUTE (' DECLARE curTB_A CURSOR FOR ' + @SQL);

	OPEN curTB_A;

	WHILE 1 = 1
	BEGIN

		FETCH NEXT FROM curTB_A	INTO
		 @W_HOKOKU_NO					-- 1.�񍐏�No

		,@W_SYONIN_JUN					-- 2.���F��
		,@W_SYONIN_NAIYO				-- 3.���F���e�i�X�e�[�W�j
		,@W_SYONIN_HOKOKUSYO_ID			-- 4.���F�񍐏�ID
		,@W_SYONIN_HOKOKUSYO_NAME		-- 5.���F�񍐏���
		,@W_SYONIN_HOKOKUSYO_R_NAME		-- 6.���F�񍐏�����
		,@W_GEN_TANTO_ID				-- 7.���F�S����ID�i�����u�S����ID�j
		,@W_GEN_TANTO_NAME				-- 8.���F�S���Җ�
		,@W_SYONIN_YMDHNS				-- 9.���F�����i���u���{���j
		,@W_TAIRYU_NISSU				--10.�ؗ�����
		,@W_TAIRYU_FG					--11.�ؗ��t���O
		,@W_KISYU_ID					--12.�@��ID
		--,@W_KISYU						--13.�@��
		,@W_KISYU_NAME					--14.�@�햼
		,@W_BUHIN_BANGO					--15.���i�ԍ�
		,@W_BUHIN_NAME					--16.���i��
		,@W_GOKI						--17.���@
		,@W_SYANAI_CD					--18.�Г��R�[�h
		,@W_FUTEKIGO_KB					--19.�s�K���敪
		,@W_FUTEKIGO_NAME				--20.�s�K���敪��
		,@W_FUTEKIGO_S_KB				--21.�s�K���ڍ׋敪
		,@W_FUTEKIGO_S_NAME				--22.�s�K���ڍ׋敪��
		,@W_FUTEKIGO_JYOTAI_KB			--23.�s�K����ԋ敪
		,@W_FUTEKIGO_JYOTAI_NAME		--24.�s�K����ԋ敪
		,@W_JIZEN_SINSA_HANTEI_KB		--25.���O�R������敪
		,@W_JIZEN_SINSA_HANTEI_NAME		--26.���O�R������敪��
		,@W_ZESEI_SYOCHI_YOHI_KB		--27.�������u�v�ۋ敪
		,@W_ZESEI_SYOCHI_YOHI_NAME		--28.�������u�v�ۋ敪��
		,@W_SAISIN_IINKAI_HANTEI_KB		--29.�ĐR�ψ����敪
		,@W_SAISIN_IINKAI_HANTEI_NAME	--30.�ĐR�ψ����敪��
		,@W_KENSA_KEKKA_KB				--31.�������ʋ敪
		,@W_KENSA_KEKKA_NAME			--32.�������ʋ敪��
		,@W_KONPON_YOIN_KB1				--33.���{�v���敪1
		,@W_KONPON_YOIN_NAME1			--34.���{�v���敪��1
		,@W_KONPON_YOIN_KB2				--35.���{�v���敪2
		,@W_KONPON_YOIN_NAME2			--36.���{�v���敪��2
		,@W_KISEKI_KOTEI_KB				--37.�A�ӍH���敪
		,@W_KISEKI_KOTEI_NAME			--38.�A�ӍH���敪��
		,@W_KISO_YMD					--39.�N����
		,@W_KISO_TANTO_ID				--40.�N���S����ID
		,@W_KISO_TANTO_NAME				--41.�N���S���Җ�
		,@W_CLOSE_FG					--42.�N���[�Y�t���O
		,@W_SASIMOTO_SYONIN_JUN			--43.���ߌ����F��
		,@W_SASIMOTO_SYONIN_NAIYO		--44.���ߌ����F���e�i���߂����X�e�[�W�j
		,@W_RIYU						--45.���ߗ��R
		,@W_YOKYU_NAIYO					--46.�v�����e
		,@W_BUMON_KB					--47.����敪
		,@W_BUMON_NAME					--48.����敪��
		,@W_KOKYAKU_HANTEI_SIJI_KB		--49.�ڋq����w���敪
		,@W_KOKYAKU_HANTEI_SIJI_NAME	--50.�ڋq����w���敪��
		,@W_KOKYAKU_SAISYU_HANTEI_KB	--51.�ڋq�ŏI����敪
		,@W_KOKYAKU_SAISYU_HANTEI_NAME	--52.�ڋq�ŏI����敪��
		,@W_DEL_YMDHNS --2018.06.05 Add by funato
		,@W_HASSEI_YMD

		IF @@FETCH_STATUS <> 0
		BEGIN
			BREAK;
		END

		INSERT INTO @retTBL (
		 HOKOKU_NO					-- 1.�񍐏�No
		,SYONIN_JUN					-- 2.���F��
		,SYONIN_NAIYO				-- 3.���F���e�i�X�e�[�W�j
		,SYONIN_HOKOKUSYO_ID		-- 4.���F�񍐏�ID
		,SYONIN_HOKOKUSYO_NAME		-- 5.���F�񍐏���
		,SYONIN_HOKOKUSYO_R_NAME	-- 6.���F�񍐏�����
		,GEN_TANTO_ID				-- 7.���F�S����ID�i�����u�S����ID�j
		,GEN_TANTO_NAME				-- 8.���F�S���Җ�
		,SYONIN_YMDHNS				-- 9.���F�����i���u���{���j
		,TAIRYU_NISSU				--10.�ؗ�����
		,TAIRYU_FG					--11.�ؗ��t���O
		,KISYU_ID					--12.�@��ID
		--,KISYU						--13.�@��
		,KISYU_NAME					--14.�@�햼
		,BUHIN_BANGO				--15.���i�ԍ�
		,BUHIN_NAME					--16.���i��
		,GOKI						--17.���@
		,SYANAI_CD					--18.�Г��R�[�h
		,FUTEKIGO_KB				--19.�s�K���敪
		,FUTEKIGO_NAME				--20.�s�K���敪��
		,FUTEKIGO_S_KB				--21.�s�K���ڍ׋敪
		,FUTEKIGO_S_NAME			--22.�s�K���ڍ׋敪��
		,FUTEKIGO_JYOTAI_KB			--23.�s�K����ԋ敪
		,FUTEKIGO_JYOTAI_NAME		--24.�s�K����ԋ敪
		,JIZEN_SINSA_HANTEI_KB		--25.���O�R������敪
		,JIZEN_SINSA_HANTEI_NAME	--26.���O�R������敪��
		,ZESEI_SYOCHI_YOHI_KB		--27.�������u�v�ۋ敪
		,ZESEI_SYOCHI_YOHI_NAME		--28.�������u�v�ۋ敪��
		,SAISIN_IINKAI_HANTEI_KB	--29.�ĐR�ψ����敪
		,SAISIN_IINKAI_HANTEI_NAME	--30.�ĐR�ψ����敪��
		,KENSA_KEKKA_KB				--31.�������ʋ敪
		,KENSA_KEKKA_NAME			--32.�������ʋ敪��
		,KONPON_YOIN_KB1			--33.���{�v���敪1
		,KONPON_YOIN_NAME1			--34.���{�v���敪��1
		,KONPON_YOIN_KB2			--35.���{�v���敪2
		,KONPON_YOIN_NAME2			--36.���{�v���敪��2
		,KISEKI_KOTEI_KB			--37.�A�ӍH���敪
		,KISEKI_KOTEI_NAME			--38.�A�ӍH���敪��
		,KISO_YMD					--39.�N����
		,KISO_TANTO_ID				--40.�N���S����ID
		,KISO_TANTO_NAME			--41.�N���S���Җ�
		,CLOSE_FG					--42.�N���[�Y�t���O
		,SASIMOTO_SYONIN_JUN		--43.���ߌ����F��
		,SASIMOTO_SYONIN_NAIYO		--44.���ߌ����F���e�i���߂����X�e�[�W�j
		,RIYU						--45.���ߗ��R
		,YOKYU_NAIYO				--46.�v�����e
		,BUMON_KB					--47.����敪
		,BUMON_NAME					--48.����敪
		,KOKYAKU_HANTEI_SIJI_KB		--49.�ڋq����w���敪
		,KOKYAKU_HANTEI_SIJI_NAME	--50.�ڋq����w���敪��
		,KOKYAKU_SAISYU_HANTEI_KB	--51.�ڋq�ŏI����敪
		,KOKYAKU_SAISYU_HANTEI_NAME	--52.�ڋq�ŏI����敪��
		,DEL_YMDHNS
		,HASSEI_YMD
		) VALUES (
		@W_HOKOKU_NO					-- 1.�񍐏�No
		,@W_SYONIN_JUN					-- 2.���F��
		,@W_SYONIN_NAIYO				-- 3.���F���e�i�X�e�[�W�j
		,@W_SYONIN_HOKOKUSYO_ID			-- 4.���F�񍐏�ID
		,@W_SYONIN_HOKOKUSYO_NAME		-- 5.���F�񍐏���
		,@W_SYONIN_HOKOKUSYO_R_NAME		-- 6.���F�񍐏�����
		,@W_GEN_TANTO_ID				-- 7.���F�S����ID�i�����u�S����ID�j
		,@W_GEN_TANTO_NAME				-- 8.���F�S���Җ�
		,@W_SYONIN_YMDHNS				-- 9.���F�����i���u���{���j
		,@W_TAIRYU_NISSU				--10.�ؗ�����
		,@W_TAIRYU_FG					--11.�ؗ��t���O
		,@W_KISYU_ID					--12.�@��ID
		--,@W_KISYU						--13.�@��
		,@W_KISYU_NAME					--14.�@�햼
		,@W_BUHIN_BANGO					--15.���i�ԍ�
		,@W_BUHIN_NAME					--16.���i��
		,@W_GOKI						--17.���@
		,@W_SYANAI_CD					--18.�Г��R�[�h
		,@W_FUTEKIGO_KB					--19.�s�K���敪
		,@W_FUTEKIGO_NAME				--20.�s�K���敪��
		,@W_FUTEKIGO_S_KB				--21.�s�K���ڍ׋敪
		,@W_FUTEKIGO_S_NAME				--22.�s�K���ڍ׋敪��
		,@W_FUTEKIGO_JYOTAI_KB			--23.�s�K����ԋ敪
		,@W_FUTEKIGO_JYOTAI_NAME		--24.�s�K����ԋ敪
		,@W_JIZEN_SINSA_HANTEI_KB		--25.���O�R������敪
		,@W_JIZEN_SINSA_HANTEI_NAME		--26.���O�R������敪��
		,@W_ZESEI_SYOCHI_YOHI_KB		--27.�������u�v�ۋ敪
		,@W_ZESEI_SYOCHI_YOHI_NAME		--28.�������u�v�ۋ敪��
		,@W_SAISIN_IINKAI_HANTEI_KB		--29.�ĐR�ψ����敪
		,@W_SAISIN_IINKAI_HANTEI_NAME	--30.�ĐR�ψ����敪��
		,@W_KENSA_KEKKA_KB				--31.�������ʋ敪
		,@W_KENSA_KEKKA_NAME			--32.�������ʋ敪��
		,@W_KONPON_YOIN_KB1				--33.���{�v���敪1
		,@W_KONPON_YOIN_NAME1			--34.���{�v���敪��1
		,@W_KONPON_YOIN_KB2				--35.���{�v���敪2
		,@W_KONPON_YOIN_NAME2			--36.���{�v���敪��2
		,@W_KISEKI_KOTEI_KB				--37.�A�ӍH���敪
		,@W_KISEKI_KOTEI_NAME			--38.�A�ӍH���敪��
		,@W_KISO_YMD					--39.�N����
		,@W_KISO_TANTO_ID				--40.�N���S����ID
		,@W_KISO_TANTO_NAME				--41.�N���S���Җ�
		,@W_CLOSE_FG					--42.�N���[�Y�t���O
		,@W_SASIMOTO_SYONIN_JUN			--43.���ߌ����F��
		,@W_SASIMOTO_SYONIN_NAIYO		--44.���ߌ����F���e�i���߂����X�e�[�W�j
		,@W_RIYU						--45.���ߗ��R
		,@W_YOKYU_NAIYO					--46.�v�����e
		,@W_BUMON_KB					--47.����敪
		,@W_BUMON_NAME					--48.����敪
		,@W_KOKYAKU_HANTEI_SIJI_KB		--49.�ڋq����w���敪
		,@W_KOKYAKU_HANTEI_SIJI_NAME	--50.�ڋq����w���敪��
		,@W_KOKYAKU_SAISYU_HANTEI_KB	--51.�ڋq�ŏI����敪
		,@W_KOKYAKU_SAISYU_HANTEI_NAME	--52.�ڋq�ŏI����敪��
		,@W_DEL_YMDHNS -- 2018.06.05 Add by funato
		,@W_HASSEI_YMD
		);

	END

	CLOSE curTB_A;
	DEALLOCATE curTB_A;

	SELECT * FROM @retTBL;

	RETURN 0;

END TRY

BEGIN CATCH
 SET @ErrorMessage = CONVERT(char,ERROR_LINE()) + ERROR_MESSAGE()
 SET @ErrorProcedure = ERROR_PROCEDURE()
 EXECUTE [loopback].[FMS].[dbo].spERRLOG ' ', 'ST02_FUTEKIGO_ICHIRAN',  @ErrorMessage
 RETURN -1
END CATCH





