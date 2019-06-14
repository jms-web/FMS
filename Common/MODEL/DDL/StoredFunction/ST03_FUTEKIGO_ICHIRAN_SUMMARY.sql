USE [FMS]
GO
/****** Object:  StoredProcedure [dbo].[ST03_FUTEKIGO_ICHIRAN_SUMMARY]    Script Date: 2019/06/07 16:15:05 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

-- =============================================
-- Description:	�s�K���񍐏��W�v�ꗗ
-- =============================================

-- =============================================
-- Description:	�s�K���񍐏��W�v�ꗗ
-- =============================================
ALTER PROCEDURE [dbo].[ST03_FUTEKIGO_ICHIRAN_SUMMARY] @BUMON_KB VARCHAR(2)=NULL --����敪
	,@SYONIN_HOKOKUSYO_ID INT--���F�񍐏�ID
	,@KISYU_ID INT = NULL --�@��ID
	,@BUHIN_BANGO VARCHAR(60) = NULL --���i�ԍ�
	,@SYANAI_CD VARCHAR(10) = NULL --�Г��R�[�h
	,@BUHIN_NAME NVARCHAR(100) = NULL --���i����
	,@GOKI NVARCHAR(20) = NULL --���@
	,@GEN_TANTO_ID INT = NULL --�����u�S����ID
	,@SYONIN_YMDHNS_FROM CHAR(8) = NULL --���u���{��From�i���F�����������ΏۂƂ���j
	,@SYONIN_YMDHNS_TO CHAR(8) = NULL --���u���{��To�i���F�����������ΏۂƂ���j
	,@HOKOKU_NO CHAR(10) = NULL --�񍐏�No
	,@KISO_TANTO_ID INT = NULL --�N���S����ID
	,@CLOSE_FG CHAR(1) = NULL --�N���[�Y�t���O
	,@TAIRYU_FG CHAR(1) = NULL --�ؗ��t���O
	,@FUTEKIGO_KB CHAR(2) = NULL --�s�K���敪
	,@FUTEKIGO_S_KB CHAR(2) = NULL --�s�K���ڍ׋敪
	,@FUTEKIGO_JYOTAI_KB CHAR(2) = NULL --�s�K����ԋ敪
	,@JIZEN_SINSA_HANTEI_KB CHAR(2) = NULL --���O�R������敪
	,@ZESEI_SYOCHI_YOHI_KB CHAR(2) = NULL --�������u�v�ۋ敪
	,@SAISIN_IINKAI_HANTEI_KB CHAR(2) = NULL --�ĐR�ψ����敪
	,@KENSA_KEKKA_KB CHAR(2) = NULL --�������ʋ敪
	,@KONPON_YOIN_KB1 CHAR(2) = NULL --���{�v���敪1
	,@KONPON_YOIN_KB2 CHAR(2) = NULL --���{�v���敪2
	,@KISEKI_KOTEI_KB CHAR(2) = NULL --�A�ӍH���敪
	,@KOKYAKU_HANTEI_SIJI_KB CHAR(2) = NULL --�ڋq����w���敪
	,@KOKYAKU_SAISYU_HANTEI_KB CHAR(2) = NULL --�ڋq�ŏI����敪
	,@GENIN_BUNSEKI_KB1 NVARCHAR(500) = NULL --�������͋敪1��WHERE�����̓��e�����̂܂܃Z�b�g����
	,@GENIN_BUNSEKI_KB2 NVARCHAR(500) = NULL --�������͋敪2��WHERE�����̓��e�����̂܂܃Z�b�g����
	,@HASSEI_YMD_FROM CHAR(8) = NULL
	,@HASSEI_YMD_TO CHAR(8) = NULL
AS
BEGIN TRY
	DECLARE @ErrorMessage VARCHAR(4000);
	DECLARE @ErrorProcedure NVARCHAR(126);
	DECLARE @SQL NVARCHAR(max)
	DECLARE @S_SQL NVARCHAR(max)
	DECLARE @G_SQL NVARCHAR(max)

	SET @SQL = N'';
	SET @SQL += N' SELECT DISTINCT ';

	SET @S_SQL  = N'';
	SET @S_SQL += N' SYONIN_HOKOKUSYO_ID';-- 4.���F�񍐏�ID	
	SET @S_SQL += N',SYONIN_HOKOKUSYO_R_NAME';-- 6.���F�񍐏�����

	SET @G_SQL  = N'';
	SET @G_SQL += N' SYONIN_HOKOKUSYO_ID';-- 4.���F�񍐏�ID	
	SET @G_SQL += N',SYONIN_HOKOKUSYO_R_NAME';-- 6.���F�񍐏�����

	IF @KISYU_ID IS NOT NULL	--@KISYU_ID <> 0
		BEGIN
			SET @S_SQL += N',KISYU_ID';--12.�@��ID	
			SET @S_SQL += N',KISYU_NAME';--14.�@�햼

			SET @G_SQL += N',KISYU_ID';--12.�@��ID	
			SET @G_SQL += N',KISYU_NAME';--14.�@�햼
		END

	IF @BUHIN_BANGO IS NOT NULL --RTRIM(LTRIM(@BUHIN_BANGO)) <> ''
		BEGIN
			SET @S_SQL += N',BUHIN_BANGO';--15.���i�ԍ�			
			SET @G_SQL += N',BUHIN_BANGO';--15.���i�ԍ�			
		END
	
	IF @BUHIN_NAME IS NOT NULL --RTRIM(LTRIM(@BUHIN_NAME)) <> ''
		BEGIN
			SET @S_SQL += N',BUHIN_NAME';--16.���i��	
			SET @G_SQL += N',BUHIN_NAME';--16.���i��	
		END
		
	IF @GOKI IS NOT NULL --RTRIM(LTRIM(@GOKI)) <> ''
		BEGIN
			SET @S_SQL += N',GOKI';--17.���@	
			SET @G_SQL += N',GOKI';--17.���@	
		END		

	IF @SYANAI_CD IS NOT NULL --RTRIM(LTRIM(@SYANAI_CD)) <> ''
		BEGIN
			SET @S_SQL += N',SYANAI_CD';--18.�Г��R�[�h	
			SET @G_SQL += N',SYANAI_CD';--18.�Г��R�[�h	
		END
		
	IF @FUTEKIGO_KB IS NOT NULL --RTRIM(LTRIM(@FUTEKIGO_KB)) <> ''
	BEGIN
		SET @S_SQL += N',FUTEKIGO_KB';--19.�s�K���敪
		SET @S_SQL += N',FUTEKIGO_NAME';--20.�s�K���敪��

		SET @G_SQL += N',FUTEKIGO_KB';--19.�s�K���敪
		SET @G_SQL += N',FUTEKIGO_NAME';--20.�s�K���敪��
	END

	IF @FUTEKIGO_S_KB IS NOT NULL --RTRIM(LTRIM(@FUTEKIGO_S_KB)) <> ''
	BEGIN
		SET @S_SQL += N',FUTEKIGO_S_KB';--21.�s�K���ڍ׋敪
		SET @S_SQL += N',FUTEKIGO_S_NAME';--22.�s�K���ڍ׋敪��

		SET @G_SQL += N',FUTEKIGO_S_KB';--21.�s�K���ڍ׋敪
		SET @G_SQL += N',FUTEKIGO_S_NAME';--22.�s�K���ڍ׋敪��
	END

	IF @FUTEKIGO_JYOTAI_KB IS NOT NULL --RTRIM(LTRIM(@FUTEKIGO_JYOTAI_KB)) <> ''
	BEGIN
		SET @S_SQL += N',FUTEKIGO_JYOTAI_KB';--23.�s�K����ԋ敪
		SET @S_SQL += N',FUTEKIGO_JYOTAI_NAME';--24.�s�K����ԋ敪

		SET @G_SQL += N',FUTEKIGO_JYOTAI_KB';--23.�s�K����ԋ敪
		SET @G_SQL += N',FUTEKIGO_JYOTAI_NAME';--24.�s�K����ԋ敪
	END

	IF @JIZEN_SINSA_HANTEI_KB IS NOT NULL --RTRIM(LTRIM(@JIZEN_SINSA_HANTEI_KB)) <> ''
	BEGIN
		SET @S_SQL += N',JIZEN_SINSA_HANTEI_KB';--25.���O�R������敪
		SET @S_SQL += N',JIZEN_SINSA_HANTEI_NAME';--26.���O�R������敪��

		SET @G_SQL += N',JIZEN_SINSA_HANTEI_KB';--25.���O�R������敪
		SET @G_SQL += N',JIZEN_SINSA_HANTEI_NAME';--26.���O�R������敪��
	END

	IF @ZESEI_SYOCHI_YOHI_KB IS NOT NULL --RTRIM(LTRIM(@ZESEI_SYOCHI_YOHI_KB)) <> ''
	BEGIN
		SET @S_SQL += N',ZESEI_SYOCHI_YOHI_KB';--27.�������u�v�ۋ敪
		SET @S_SQL += N',ZESEI_SYOCHI_YOHI_NAME';--28.�������u�v�ۋ敪��

		SET @G_SQL += N',ZESEI_SYOCHI_YOHI_KB';--27.�������u�v�ۋ敪
		SET @G_SQL += N',ZESEI_SYOCHI_YOHI_NAME';--28.�������u�v�ۋ敪��
	END

	IF @SAISIN_IINKAI_HANTEI_KB IS NOT NULL --RTRIM(LTRIM(@SAISIN_IINKAI_HANTEI_KB)) <> ''
	BEGIN
		SET @S_SQL += N',SAISIN_IINKAI_HANTEI_KB';--29.�ĐR�ψ����敪
		SET @S_SQL += N',SAISIN_IINKAI_HANTEI_NAME';--30.�ĐR�ψ����敪��

		SET @G_SQL += N',SAISIN_IINKAI_HANTEI_KB';--29.�ĐR�ψ����敪
		SET @G_SQL += N',SAISIN_IINKAI_HANTEI_NAME';--30.�ĐR�ψ����敪��
	END

	IF @KENSA_KEKKA_KB IS NOT NULL --RTRIM(LTRIM(@KENSA_KEKKA_KB)) <> ''
	BEGIN
		SET @S_SQL += N',KENSA_KEKKA_KB';--31.�������ʋ敪
		SET @S_SQL += N',KENSA_KEKKA_NAME';--32.�������ʋ敪��

		SET @G_SQL += N',KENSA_KEKKA_KB';--31.�������ʋ敪
		SET @G_SQL += N',KENSA_KEKKA_NAME';--32.�������ʋ敪��
	END

	IF @KONPON_YOIN_KB1 IS NOT NULL --RTRIM(LTRIM(@KONPON_YOIN_KB1)) <> ''
	BEGIN
		SET @S_SQL += N',KONPON_YOIN_KB1';--33.���{�v���敪1
		SET @S_SQL += N',KONPON_YOIN_NAME1';--34.���{�v���敪��1

		SET @G_SQL += N',KONPON_YOIN_KB1';--33.���{�v���敪1
		SET @G_SQL += N',KONPON_YOIN_NAME1';--34.���{�v���敪��1
	END

	IF @KONPON_YOIN_KB2 IS NOT NULL --RTRIM(LTRIM(@KONPON_YOIN_KB2)) <> ''
	BEGIN
		SET @S_SQL += N',KONPON_YOIN_KB2';--33.���{�v���敪2
		SET @S_SQL += N',KONPON_YOIN_NAME2';--34.���{�v���敪��2

		SET @G_SQL += N',KONPON_YOIN_KB2';--33.���{�v���敪2
		SET @G_SQL += N',KONPON_YOIN_NAME2';--34.���{�v���敪��2
	END

	IF @KISEKI_KOTEI_KB IS NOT NULL --RTRIM(LTRIM(@KISEKI_KOTEI_KB)) <> ''
	BEGIN
		SET @S_SQL += N',KISEKI_KOTEI_KB';--37.�A�ӍH���敪
		SET @S_SQL += N',KISEKI_KOTEI_NAME';--38.�A�ӍH���敪��

		SET @G_SQL += N',KISEKI_KOTEI_KB';--37.�A�ӍH���敪
		SET @G_SQL += N',KISEKI_KOTEI_NAME';--38.�A�ӍH���敪��
	END

	--SET @S_SQL = @S_SQL + N',KISO_YMD';--39.�N����

	IF @KISO_TANTO_ID IS NOT NULL --@KISO_TANTO_ID <> 0
	BEGIN
		SET @S_SQL += N',KISO_TANTO_ID';--40.�N���S����ID
		SET @S_SQL += N',KISO_TANTO_NAME';--41.�N���S���Җ�

		SET @G_SQL += N',KISO_TANTO_ID';--40.�N���S����ID
		SET @G_SQL += N',KISO_TANTO_NAME';--41.�N���S���Җ�
	END

	--IF RTRIM(LTRIM(@CLOSE_FG)) <> ''
	--	SET @S_SQL = @S_SQL + N',CLOSE_FG';--42.�N���[�Y�t���O
	--SET @S_SQL = @S_SQL + N',SASIMOTO_SYONIN_JUN';--43.���ߌ����F��
	--SET @S_SQL = @S_SQL + N',SASIMOTO_SYONIN_NAIYO';--44.���ߌ����F���e�i���߂����X�e�[�W�j
	--SET @S_SQL = @S_SQL + N',RIYU';--45.���ߗ��R
	--SET @S_SQL = @S_SQL + N',YOKYU_NAIYO';--46.�v�����e

	IF @BUMON_KB IS NOT NULL --RTRIM(LTRIM(@BUMON_KB)) <> ''
	BEGIN
		SET @S_SQL += N',BUMON_KB';--47.����敪
		SET @S_SQL += N',BUMON_NAME';--48.����敪

		SET @G_SQL += N',BUMON_KB';--47.����敪
		SET @G_SQL += N',BUMON_NAME';--48.����敪
	END

	IF @KOKYAKU_HANTEI_SIJI_KB IS NOT NULL --RTRIM(LTRIM(@KOKYAKU_HANTEI_SIJI_KB)) <> ''
	BEGIN
		SET @S_SQL += N',KOKYAKU_HANTEI_SIJI_KB';--49.�ڋq����w���敪
		SET @S_SQL += N',KOKYAKU_HANTEI_SIJI_NAME';--50.�ڋq����w���敪��

		SET @G_SQL += N',KOKYAKU_HANTEI_SIJI_KB';--49.�ڋq����w���敪
		SET @G_SQL += N',KOKYAKU_HANTEI_SIJI_NAME';--50.�ڋq����w���敪��
	END

	IF @KOKYAKU_SAISYU_HANTEI_KB IS NOT NULL --RTRIM(LTRIM(@KOKYAKU_SAISYU_HANTEI_KB)) <> ''
	BEGIN
		SET @S_SQL += N',KOKYAKU_SAISYU_HANTEI_KB';--51.�ڋq�ŏI����敪
		SET @S_SQL += N',KOKYAKU_SAISYU_HANTEI_NAME';--52.�ڋq�ŏI����敪��

		SET @G_SQL += N',KOKYAKU_SAISYU_HANTEI_KB';--51.�ڋq�ŏI����敪
		SET @G_SQL += N',KOKYAKU_SAISYU_HANTEI_NAME';--52.�ڋq�ŏI����敪��
	END

	--SET @S_SQL = @S_SQL + N',DEL_YMDHNS';--2018.06.05 Add by funato

	IF @HASSEI_YMD_FROM IS NOT NULL Or @HASSEI_YMD_FROM IS NOT NULL --RTRIM(LTRIM(@HASSEI_YMD_FROM)) <> '' Or RTRIM(LTRIM(@HASSEI_YMD_FROM)) <> ''
	BEGIN
		SET @S_SQL += N',SUBSTRING(HASSEI_YMD,1,6) HASSEI_YMD';
		SET @G_SQL += N',SUBSTRING(HASSEI_YMD,1,6)';
	END
		
	--SET @S_SQL = @S_SQL + N',SYOCHI_YOTEI_YMD';--2018.11.29 Add by funato
	SET @S_SQL += N',SURYO';--
	SET @G_SQL += N',SURYO';--

	SET @SQL += @S_SQL;
	
	--�W�v����
	SET @SQL += N',COUNT(SYONIN_HOKOKUSYO_ID) AS KISO_KENSU';--
	SET @SQL += N',SUM(CASE WHEN CLOSE_FG = ''1'' THEN 1 ELSE 0 END) AS SYOCHI_KENSU';--
	SET @SQL += N',SUM(CASE WHEN CLOSE_FG = ''0'' THEN 1 ELSE 0 END) AS SYOCHI_ZANSU';--

	SET @SQL += N' INTO #tmp_futekigo_ichiran';--�e���|�����e�[�u���Ɋi�[
	SET @SQL += N' FROM V007_NCR_CAR ';
	SET @SQL += N' WHERE HOKOKU_NO <> '''' '	

	--����敪
	IF RTRIM(LTRIM(ISNULL(@BUMON_KB,''))) <> ''
	BEGIN
		SET @SQL += N' AND BUMON_KB = ''' + RTRIM(LTRIM(@BUMON_KB)) + ''' ';
	END

	--���F�񍐏�ID
	IF @SYONIN_HOKOKUSYO_ID <> 0
	BEGIN
		SET @SQL += N' AND SYONIN_HOKOKUSYO_ID = ' + CONVERT(CHAR, @SYONIN_HOKOKUSYO_ID) + '';
	END

	--�@��ID
	IF ISNULL(@KISYU_ID,0) <> 0 --@KISYU_ID <> 0
	BEGIN
		SET @SQL += N' AND KISYU_ID = ' + CONVERT(CHAR, @KISYU_ID) + '';
	END

	--���i�ԍ�
	IF RTRIM(LTRIM(ISNULL(@BUHIN_BANGO,''))) <> ''
	BEGIN
		SET @SQL += N' AND BUHIN_BANGO LIKE ''%' + RTRIM(LTRIM(@BUHIN_BANGO)) + '%'' ';
	END

	--�Г��R�[�h
	IF RTRIM(LTRIM(ISNULL(@SYANAI_CD,''))) <> ''
	BEGIN
		SET @SQL += N' AND SYANAI_CD LIKE ''%' + RTRIM(LTRIM(@SYANAI_CD)) + '%'' ';
	END

	--���i����
	IF RTRIM(LTRIM(ISNULL(@BUHIN_NAME,''))) <> ''
	BEGIN
		SET @SQL += N' AND BUHIN_NAME LIKE ''%' + RTRIM(LTRIM(@BUHIN_NAME)) + '%'' ';
	END

	--���@
	IF RTRIM(LTRIM(ISNULL(@GOKI,''))) <> ''
	BEGIN
		SET @SQL += N' AND GOKI LIKE ''%' + RTRIM(LTRIM(@GOKI)) + '%'' ';
	END

	--�����u�S����ID
	IF @GEN_TANTO_ID <> 0
	BEGIN
		SET @SQL += N' AND GEN_TANTO_ID = ' + CONVERT(CHAR, @GEN_TANTO_ID) + '';
	END

	--���u���{��From
	IF RTRIM(LTRIM(ISNULL(@SYONIN_YMDHNS_FROM,''))) <> ''
	BEGIN
		SET @SQL += N' AND substring(SYONIN_YMDHNS,1,8) >= ''' + RTRIM(LTRIM(@SYONIN_YMDHNS_FROM)) + ''' ';
	END

	--���u���{��To
	IF RTRIM(LTRIM(ISNULL(@SYONIN_YMDHNS_TO,''))) <> ''
	BEGIN
		SET @SQL += N' AND substring(SYONIN_YMDHNS,1,8) <= ''' + RTRIM(LTRIM(@SYONIN_YMDHNS_TO)) + ''' ';
	END

	--�񍐏�No
	IF RTRIM(LTRIM(ISNULL(@HOKOKU_NO,''))) <> ''
	BEGIN
		SET @SQL += N' AND HOKOKU_NO LIKE ''%' + RTRIM(LTRIM(@HOKOKU_NO)) + '%'' ';
	END

	--�N���S����ID
	IF ISNULL(@KISO_TANTO_ID,0) <> 0
	BEGIN
		SET @SQL += N' AND KISO_TANTO_ID = ' + CONVERT(CHAR, @KISO_TANTO_ID) + '';
	END

	--�N���[�Y�t���O
	IF RTRIM(LTRIM(ISNULL(@CLOSE_FG,''))) <> ''
	BEGIN
		SET @SQL += N' AND CLOSE_FG = ''' + RTRIM(LTRIM(@CLOSE_FG)) + ''' ';
	END

	--�ؗ��t���O
	IF RTRIM(LTRIM(ISNULL(@TAIRYU_FG,''))) <> ''
	BEGIN
		SET @SQL += N' AND TAIRYU_FG = ''' + RTRIM(LTRIM(@TAIRYU_FG)) + ''' ';
	END

	--�s�K���敪
	IF RTRIM(LTRIM(ISNULL(@FUTEKIGO_KB,''))) <> ''
	BEGIN
		SET @SQL += N' AND FUTEKIGO_KB = ''' + RTRIM(LTRIM(@FUTEKIGO_KB)) + ''' ';
	END

	--�s�K���ڍ׋敪
	IF RTRIM(LTRIM(ISNULL(@FUTEKIGO_S_KB,''))) <> ''
	BEGIN
		SET @SQL += N' AND FUTEKIGO_S_KB = ''' + RTRIM(LTRIM(@FUTEKIGO_S_KB)) + ''' ';
	END

	--�s�K����ԋ敪
	IF RTRIM(LTRIM(ISNULL(@FUTEKIGO_JYOTAI_KB,''))) <> ''
	BEGIN
		SET @SQL += N' AND FUTEKIGO_JYOTAI_KB = ''' + RTRIM(LTRIM(@FUTEKIGO_JYOTAI_KB)) + ''' ';
	END

	--���O�R������敪
	IF RTRIM(LTRIM(ISNULL(@JIZEN_SINSA_HANTEI_KB,''))) <> ''
	BEGIN
		SET @SQL += N' AND JIZEN_SINSA_HANTEI_KB = ''' + RTRIM(LTRIM(@JIZEN_SINSA_HANTEI_KB)) + ''' ';
	END

	--�������u�v�ۋ敪
	IF RTRIM(LTRIM(ISNULL(@ZESEI_SYOCHI_YOHI_KB,''))) <> ''
	BEGIN
		SET @SQL += N' AND ZESEI_SYOCHI_YOHI_KB = ''' + RTRIM(LTRIM(@ZESEI_SYOCHI_YOHI_KB)) + ''' ';
	END

	--�ĐR�ψ����敪
	IF RTRIM(LTRIM(ISNULL(@SAISIN_IINKAI_HANTEI_KB,''))) <> ''
	BEGIN
		SET @SQL += N' AND SAISIN_IINKAI_HANTEI_KB = ''' + RTRIM(LTRIM(@SAISIN_IINKAI_HANTEI_KB)) + ''' ';
	END

	--�������ʋ敪
	IF RTRIM(LTRIM(ISNULL(@KENSA_KEKKA_KB,''))) <> ''
	BEGIN
		SET @SQL += N' AND KENSA_KEKKA_KB = ''' + RTRIM(LTRIM(@KENSA_KEKKA_KB)) + ''' ';
	END

	--���{�v���敪1
	IF RTRIM(LTRIM(ISNULL(@KONPON_YOIN_KB1,''))) <> ''
	BEGIN
		SET @SQL += N' AND KONPON_YOIN_KB1 = ''' + RTRIM(LTRIM(@KONPON_YOIN_KB1)) + ''' ';
	END

	--���{�v���敪2
	IF RTRIM(LTRIM(ISNULL(@KONPON_YOIN_KB2,''))) <> ''
	BEGIN
		SET @SQL += N' AND KONPON_YOIN_KB2 = ''' + RTRIM(LTRIM(@KONPON_YOIN_KB2)) + ''' ';
	END

	--�A�ӍH���敪
	IF RTRIM(LTRIM(ISNULL(@KISEKI_KOTEI_KB,''))) <> ''
	BEGIN
		SET @SQL += N' AND KISEKI_KOTEI_KB = ''' + RTRIM(LTRIM(@KISEKI_KOTEI_KB)) + ''' ';
	END

	--�������͋敪1
	IF RTRIM(LTRIM(ISNULL(@GENIN_BUNSEKI_KB1,''))) <> ''
	BEGIN
		SET @SQL += N' ' + @GENIN_BUNSEKI_KB1 + ' ';
	END

	--�������͋敪2
	IF RTRIM(LTRIM(ISNULL(@GENIN_BUNSEKI_KB2,''))) <> ''
	BEGIN
		SET @SQL += N' ' + @GENIN_BUNSEKI_KB2 + ' ';
	END

	--�ڋq����w���敪
	IF RTRIM(LTRIM(ISNULL(@KOKYAKU_HANTEI_SIJI_KB,''))) <> ''
	BEGIN
		SET @SQL += N' AND KOKYAKU_HANTEI_SIJI_KB = ''' + @KOKYAKU_HANTEI_SIJI_KB + ''' ';
	END

	--�ڋq�ŏI����敪
	IF RTRIM(LTRIM(ISNULL(@KOKYAKU_SAISYU_HANTEI_KB,''))) <> ''
	BEGIN
		SET @SQL += N' AND KOKYAKU_SAISYU_HANTEI_KB = ''' + @KOKYAKU_SAISYU_HANTEI_KB + ''' ';
	END

	--������From
	IF RTRIM(LTRIM(ISNULL(@HASSEI_YMD_FROM,''))) <> ''
	BEGIN
		SET @SQL += N' AND HASSEI_YMD >= ''' + RTRIM(LTRIM(@HASSEI_YMD_FROM)) + ''' ';
	END

	--������To
	IF RTRIM(LTRIM(ISNULL(@HASSEI_YMD_TO,''))) <> ''
	BEGIN
		SET @SQL += N' AND HASSEI_YMD <= ''' + RTRIM(LTRIM(@HASSEI_YMD_TO)) + ''' ';
	END
	
	--�W�v
	SET @SQL = @SQL + N' GROUP BY ' + @G_SQL


	--�e���|�����e�[�u������擾
	SET @SQL += N';' --����Z�b�V�����Ŏ��s���邽�߁ASELECT INTO SQL�ƌ�������
	SET @SQL += N'SELECT * FROM #tmp_futekigo_ichiran'

	EXECUTE (@SQL);
		--RETURN 0;
END TRY

BEGIN CATCH
	SET @ErrorMessage = CONVERT(CHAR, ERROR_LINE()) + ERROR_MESSAGE()
	SET @ErrorProcedure = ERROR_PROCEDURE()

	EXECUTE [loopback].[FMS].[dbo].spERRLOG 0
		,'ST03_FUTEKIGO_ICHIRAN_SUMMARY'
		,@ErrorMessage

	RETURN - 1
END CATCH