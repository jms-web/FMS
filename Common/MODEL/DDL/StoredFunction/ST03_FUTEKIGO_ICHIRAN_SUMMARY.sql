USE [FMS]
GO
/****** Object:  StoredProcedure [dbo].[ST03_FUTEKIGO_ICHIRAN_SUMMARY]    Script Date: 2021/06/03 11:57:30 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

-- =============================================
-- Description:	不適合報告書集計一覧
-- =============================================

-- =============================================
-- Description:	不適合報告書集計一覧
-- =============================================
ALTER PROCEDURE [dbo].[ST03_FUTEKIGO_ICHIRAN_SUMMARY] @BUMON_KB VARCHAR(2)=NULL --部門区分
	,@SYONIN_HOKOKUSYO_ID INT--承認報告書ID
	,@KISYU_ID INT = NULL --機種ID
	,@BUHIN_BANGO VARCHAR(60) = NULL --部品番号
	,@SYANAI_CD VARCHAR(10) = NULL --社内コード
	,@BUHIN_NAME NVARCHAR(100) = NULL --部品名称
	,@GOKI NVARCHAR(20) = NULL --号機
	,@GEN_TANTO_ID INT = NULL --現処置担当者ID
	,@SYONIN_YMDHNS_FROM CHAR(8) = NULL --処置実施日From（承認日時を検索対象とする）
	,@SYONIN_YMDHNS_TO CHAR(8) = NULL --処置実施日To（承認日時を検索対象とする）
	,@HOKOKU_NO CHAR(10) = NULL --報告書No
	,@KISO_TANTO_ID INT = NULL --起草担当者ID
	,@CLOSE_FG CHAR(1) = NULL --クローズフラグ
	,@TAIRYU_FG CHAR(1) = NULL --滞留フラグ
	,@FUTEKIGO_KB VARCHAR(50) = NULL --不適合区分
	,@FUTEKIGO_S_KB VARCHAR(50) = NULL --不適合詳細区分
	,@FUTEKIGO_JYOTAI_KB CHAR(2) = NULL --不適合状態区分
	,@JIZEN_SINSA_HANTEI_KB CHAR(2) = NULL --事前審査判定区分
	,@ZESEI_SYOCHI_YOHI_KB CHAR(2) = NULL --是正処置要否区分
	,@SAISIN_IINKAI_HANTEI_KB CHAR(2) = NULL --再審委員会判定区分
	,@KENSA_KEKKA_KB CHAR(2) = NULL --検査結果区分
	,@KONPON_YOIN_KB1 CHAR(2) = NULL --根本要因区分1
	,@KONPON_YOIN_KB2 CHAR(2) = NULL --根本要因区分2
	,@KISEKI_KOTEI_KB CHAR(2) = NULL --帰責工程区分
	,@KOKYAKU_HANTEI_SIJI_KB CHAR(2) = NULL --顧客判定指示区分
	,@KOKYAKU_SAISYU_HANTEI_KB CHAR(2) = NULL --顧客最終判定区分
	,@GENIN_BUNSEKI_KB1 NVARCHAR(max) = NULL --原因分析区分1でWHERE条件の内容をそのままセットする
	,@GENIN_BUNSEKI_KB2 NVARCHAR(max) = NULL --原因分析区分2でWHERE条件の内容をそのままセットする
	,@HASSEI_YMD_FROM CHAR(8) = NULL
	,@HASSEI_YMD_TO CHAR(8) = NULL
	,@SURYO_FG CHAR(1) = NULL
AS
BEGIN TRY
	DECLARE @ErrorMessage VARCHAR(4000);
	DECLARE @ErrorProcedure NVARCHAR(126);
	DECLARE @SQL NVARCHAR(max)
	DECLARE @S_SQL NVARCHAR(max)
	DECLARE @G_SQL NVARCHAR(max)

	SET @S_SQL  = N' 0 SUMMARY_ROW_FLG';
	SET @S_SQL += N',SYONIN_HOKOKUSYO_ID';-- 4.承認報告書ID	
	SET @S_SQL += N',SYONIN_HOKOKUSYO_R_NAME';-- 6.承認報告書略名

	SET @G_SQL  = N'';
	SET @G_SQL += N' V07.SYONIN_HOKOKUSYO_ID';-- 4.承認報告書ID	
	SET @G_SQL += N',V07.SYONIN_HOKOKUSYO_R_NAME';-- 6.承認報告書略名

	IF @KISYU_ID IS NOT NULL	--@KISYU_ID <> 0
		BEGIN
			SET @S_SQL += N',KISYU_ID';--12.機種ID	
			SET @S_SQL += N',KISYU_NAME';--14.機種名

			SET @G_SQL += N',V07.KISYU_ID';--12.機種ID	
			SET @G_SQL += N',V07.KISYU_NAME';--14.機種名
		END

	IF @BUHIN_BANGO IS NOT NULL --RTRIM(LTRIM(@BUHIN_BANGO)) <> ''
		BEGIN
			SET @S_SQL += N',BUHIN_BANGO';--15.部品番号			
			SET @G_SQL += N',V07.BUHIN_BANGO';--15.部品番号			
		END
	
	IF @BUHIN_NAME IS NOT NULL --RTRIM(LTRIM(@BUHIN_NAME)) <> ''
		BEGIN
			SET @S_SQL += N',BUHIN_NAME';--16.部品名	
			SET @G_SQL += N',V07.BUHIN_NAME';--16.部品名	
		END
		
	IF @GOKI IS NOT NULL --RTRIM(LTRIM(@GOKI)) <> ''
		BEGIN
			SET @S_SQL += N',GOKI';--17.号機	
			SET @G_SQL += N',V07.GOKI';--17.号機	
		END		

	IF @SYANAI_CD IS NOT NULL --RTRIM(LTRIM(@SYANAI_CD)) <> ''
		BEGIN
			SET @S_SQL += N',SYANAI_CD';--18.社内コード	
			SET @G_SQL += N',V07.SYANAI_CD';--18.社内コード	
		END
		
	IF @FUTEKIGO_KB IS NOT NULL --RTRIM(LTRIM(@FUTEKIGO_KB)) <> ''
	BEGIN

		--部門未選択で区分集計するため名称項目で集計
		--SET @S_SQL += N',FUTEKIGO_KB';--19.不適合区分
		SET @S_SQL += N',FUTEKIGO_NAME';--20.不適合区分名

		--SET @G_SQL += N',FUTEKIGO_KB';--19.不適合区分
		SET @G_SQL += N',V07.FUTEKIGO_NAME';--20.不適合区分名
	END

	IF @FUTEKIGO_S_KB IS NOT NULL --RTRIM(LTRIM(@FUTEKIGO_S_KB)) <> ''
	BEGIN
		--SET @S_SQL += N',FUTEKIGO_S_KB';--21.不適合詳細区分
		SET @S_SQL += N',FUTEKIGO_S_NAME';--22.不適合詳細区分名

		--SET @G_SQL += N',FUTEKIGO_S_KB';--21.不適合詳細区分
		SET @G_SQL += N',V07.FUTEKIGO_S_NAME';--22.不適合詳細区分名
	END

	IF @FUTEKIGO_JYOTAI_KB IS NOT NULL --RTRIM(LTRIM(@FUTEKIGO_JYOTAI_KB)) <> ''
	BEGIN
		SET @S_SQL += N',FUTEKIGO_JYOTAI_KB';--23.不適合状態区分
		SET @S_SQL += N',FUTEKIGO_JYOTAI_NAME';--24.不適合状態区分

		SET @G_SQL += N',V07.FUTEKIGO_JYOTAI_KB';--23.不適合状態区分
		SET @G_SQL += N',V07.FUTEKIGO_JYOTAI_NAME';--24.不適合状態区分
	END

	IF @JIZEN_SINSA_HANTEI_KB IS NOT NULL --RTRIM(LTRIM(@JIZEN_SINSA_HANTEI_KB)) <> ''
	BEGIN
		SET @S_SQL += N',JIZEN_SINSA_HANTEI_KB';--25.事前審査判定区分
		SET @S_SQL += N',JIZEN_SINSA_HANTEI_NAME';--26.事前審査判定区分名

		SET @G_SQL += N',V07.JIZEN_SINSA_HANTEI_KB';--25.事前審査判定区分
		SET @G_SQL += N',V07.JIZEN_SINSA_HANTEI_NAME';--26.事前審査判定区分名
	END

	IF @ZESEI_SYOCHI_YOHI_KB IS NOT NULL --RTRIM(LTRIM(@ZESEI_SYOCHI_YOHI_KB)) <> ''
	BEGIN
		SET @S_SQL += N',ZESEI_SYOCHI_YOHI_KB';--27.是正処置要否区分
		SET @S_SQL += N',ZESEI_SYOCHI_YOHI_NAME';--28.是正処置要否区分名

		SET @G_SQL += N',V07.ZESEI_SYOCHI_YOHI_KB';--27.是正処置要否区分
		SET @G_SQL += N',V07.ZESEI_SYOCHI_YOHI_NAME';--28.是正処置要否区分名
	END

	IF @SAISIN_IINKAI_HANTEI_KB IS NOT NULL --RTRIM(LTRIM(@SAISIN_IINKAI_HANTEI_KB)) <> ''
	BEGIN
		SET @S_SQL += N',SAISIN_IINKAI_HANTEI_KB';--29.再審委員会判定区分
		SET @S_SQL += N',SAISIN_IINKAI_HANTEI_NAME';--30.再審委員会判定区分名

		SET @G_SQL += N',V07.SAISIN_IINKAI_HANTEI_KB';--29.再審委員会判定区分
		SET @G_SQL += N',V07.SAISIN_IINKAI_HANTEI_NAME';--30.再審委員会判定区分名
	END

	IF @KENSA_KEKKA_KB IS NOT NULL --RTRIM(LTRIM(@KENSA_KEKKA_KB)) <> ''
	BEGIN
		SET @S_SQL += N',KENSA_KEKKA_KB';--31.検査結果区分
		SET @S_SQL += N',KENSA_KEKKA_NAME';--32.検査結果区分名

		SET @G_SQL += N',V07.KENSA_KEKKA_KB';--31.検査結果区分
		SET @G_SQL += N',V07.KENSA_KEKKA_NAME';--32.検査結果区分名
	END

	IF @KONPON_YOIN_KB1 IS NOT NULL OR  @KONPON_YOIN_KB2 IS NOT NULL
	BEGIN
		SET @S_SQL += N',KONPON_YOIN_KB';--33.根本要因区分1
		SET @S_SQL += N',KONPON_YOIN_NAME';--34.根本要因区分名1

		SET @G_SQL += N',V07.KONPON_YOIN_KB';--33.根本要因区分1
		SET @G_SQL += N',V07.KONPON_YOIN_NAME';--34.根本要因区分名1
	END

	--IF @KONPON_YOIN_KB2 IS NOT NULL --RTRIM(LTRIM(@KONPON_YOIN_KB2)) <> ''
	--BEGIN
	--	SET @S_SQL += N',KONPON_YOIN_KB2';--33.根本要因区分2
	--	SET @S_SQL += N',KONPON_YOIN_NAME2';--34.根本要因区分名2

	--	SET @G_SQL += N',V07.KONPON_YOIN_KB2';--33.根本要因区分2
	--	SET @G_SQL += N',V07.KONPON_YOIN_NAME2';--34.根本要因区分名2
	--END

	IF @KISEKI_KOTEI_KB IS NOT NULL --RTRIM(LTRIM(@KISEKI_KOTEI_KB)) <> ''
	BEGIN
		SET @S_SQL += N',KISEKI_KOTEI_KB';--37.帰責工程区分
		SET @S_SQL += N',KISEKI_KOTEI_NAME';--38.帰責工程区分名

		SET @G_SQL += N',V07.KISEKI_KOTEI_KB';--37.帰責工程区分
		SET @G_SQL += N',V07.KISEKI_KOTEI_NAME';--38.帰責工程区分名
	END

	--SET @S_SQL = @S_SQL + N',KISO_YMD';--39.起草日

	IF @KISO_TANTO_ID IS NOT NULL --@KISO_TANTO_ID <> 0
	BEGIN
		SET @S_SQL += N',KISO_TANTO_ID';--40.起草担当者ID
		SET @S_SQL += N',KISO_TANTO_NAME';--41.起草担当者名

		SET @G_SQL += N',V07.KISO_TANTO_ID';--40.起草担当者ID
		SET @G_SQL += N',V07.KISO_TANTO_NAME';--41.起草担当者名
	END

	--IF RTRIM(LTRIM(@CLOSE_FG)) <> ''
	--	SET @S_SQL = @S_SQL + N',CLOSE_FG';--42.クローズフラグ
	--SET @S_SQL = @S_SQL + N',SASIMOTO_SYONIN_JUN';--43.差戻元承認順
	--SET @S_SQL = @S_SQL + N',SASIMOTO_SYONIN_NAIYO';--44.差戻元承認内容（差戻し元ステージ）
	--SET @S_SQL = @S_SQL + N',RIYU';--45.差戻理由
	--SET @S_SQL = @S_SQL + N',YOKYU_NAIYO';--46.要求内容

	IF @BUMON_KB IS NOT NULL --RTRIM(LTRIM(@BUMON_KB)) <> ''
	BEGIN
		SET @S_SQL += N',BUMON_KB';--47.部門区分
		SET @S_SQL += N',BUMON_NAME';--48.部門区分

		SET @G_SQL += N',V07.BUMON_KB';--47.部門区分
		SET @G_SQL += N',V07.BUMON_NAME';--48.部門区分
	END

	IF @KOKYAKU_HANTEI_SIJI_KB IS NOT NULL --RTRIM(LTRIM(@KOKYAKU_HANTEI_SIJI_KB)) <> ''
	BEGIN
		SET @S_SQL += N',KOKYAKU_HANTEI_SIJI_KB';--49.顧客判定指示区分
		SET @S_SQL += N',KOKYAKU_HANTEI_SIJI_NAME';--50.顧客判定指示区分名

		SET @G_SQL += N',V07.KOKYAKU_HANTEI_SIJI_KB';--49.顧客判定指示区分
		SET @G_SQL += N',V07.KOKYAKU_HANTEI_SIJI_NAME';--50.顧客判定指示区分名
	END

	IF @KOKYAKU_SAISYU_HANTEI_KB IS NOT NULL --RTRIM(LTRIM(@KOKYAKU_SAISYU_HANTEI_KB)) <> ''
	BEGIN
		SET @S_SQL += N',KOKYAKU_SAISYU_HANTEI_KB';--51.顧客最終判定区分
		SET @S_SQL += N',KOKYAKU_SAISYU_HANTEI_NAME';--52.顧客最終判定区分名

		SET @G_SQL += N',V07.KOKYAKU_SAISYU_HANTEI_KB';--51.顧客最終判定区分
		SET @G_SQL += N',V07.KOKYAKU_SAISYU_HANTEI_NAME';--52.顧客最終判定区分名
	END

	--SET @S_SQL = @S_SQL + N',DEL_YMDHNS';--2018.06.05 Add by funato

	IF @HASSEI_YMD_FROM IS NOT NULL Or @HASSEI_YMD_FROM IS NOT NULL --RTRIM(LTRIM(@HASSEI_YMD_FROM)) <> '' Or RTRIM(LTRIM(@HASSEI_YMD_FROM)) <> ''
	BEGIN
		SET @S_SQL += N',SUBSTRING(HASSEI_YMD,1,6) HASSEI_YMD';
		SET @G_SQL += N',V07.SUBSTRING(HASSEI_YMD,1,6)';
	END

	--SET @S_SQL = @S_SQL + N',SYOCHI_YOTEI_YMD';--2018.11.29 Add by funato


	IF @SURYO_FG = '1'
	BEGIN
		SET @S_SQL += N',SURYO';--
		SET @G_SQL += N',V07.SURYO';--		
	END

	IF @GENIN_BUNSEKI_KB1 IS NOT NULL Or @GENIN_BUNSEKI_KB2 IS NOT NULL
	BEGIN
		SET @S_SQL += N',V06.GENIN_BUNSEKI_S_KB';--
		SET @G_SQL += N',V06.GENIN_BUNSEKI_S_KB';--		
		SET @S_SQL += N',V06.GENIN_BUNSEKI_NAME';--
		SET @G_SQL += N',V06.GENIN_BUNSEKI_NAME';--		
	END

	SET @SQL = N' SELECT DISTINCT ';

	IF @S_SQL <> ''
	BEGIN
		SET @SQL += @S_SQL;	
		SET @SQL +=N','
	END
	
	--集計項目
	SET @SQL += N'COUNT(SYONIN_HOKOKUSYO_ID) AS KISO_KENSU';--
	SET @SQL += N',SUM(CASE WHEN CLOSE_FG = ''1'' THEN 1 ELSE 0 END) AS SYOCHI_KENSU';--
	SET @SQL += N',SUM(CASE WHEN CLOSE_FG = ''0'' THEN 1 ELSE 0 END) AS SYOCHI_ZANSU';--

	SET @SQL += N' INTO #tmp_futekigo_ichiran';--テンポラリテーブルに格納
	SET @SQL += N' FROM V007_NCR_CAR_BUNSEKI V07';
	IF @GENIN_BUNSEKI_KB1 IS NOT NULL Or @GENIN_BUNSEKI_KB2 IS NOT NULL
	BEGIN
		SET @SQL += N' LEFT JOIN V006_CAR_GENIN V06 ON V07.HOKOKU_NO = V06.HOKOKU_NO';--
	END	
	SET @SQL += N' WHERE V07.HOKOKU_NO <> '''' '
	SET @SQL += N' AND RTRIM(DEL_YMDHNS) = '''' ';



	--部門区分
	IF RTRIM(LTRIM(ISNULL(@BUMON_KB,''))) <> ''
	BEGIN
		SET @SQL += N' AND BUMON_KB = ''' + RTRIM(LTRIM(@BUMON_KB)) + ''' ';
	END

	--承認報告書ID
	IF @SYONIN_HOKOKUSYO_ID <> 0
	BEGIN
		SET @SQL += N' AND SYONIN_HOKOKUSYO_ID = ' + CONVERT(CHAR, @SYONIN_HOKOKUSYO_ID) + '';
	END

	--機種ID
	IF ISNULL(@KISYU_ID,0) <> 0 --@KISYU_ID <> 0
	BEGIN
		SET @SQL += N' AND KISYU_ID = ' + CONVERT(CHAR, @KISYU_ID) + '';
	END

	--部品番号
	IF RTRIM(LTRIM(ISNULL(@BUHIN_BANGO,''))) <> ''
	BEGIN
		SET @SQL += N' AND BUHIN_BANGO LIKE ''%' + RTRIM(LTRIM(@BUHIN_BANGO)) + '%'' ';
	END

	--社内コード
	IF RTRIM(LTRIM(ISNULL(@SYANAI_CD,''))) <> ''
	BEGIN
		SET @SQL += N' AND SYANAI_CD LIKE ''%' + RTRIM(LTRIM(@SYANAI_CD)) + '%'' ';
	END

	--部品名称
	IF RTRIM(LTRIM(ISNULL(@BUHIN_NAME,''))) <> ''
	BEGIN
		SET @SQL += N' AND BUHIN_NAME LIKE ''%' + RTRIM(LTRIM(@BUHIN_NAME)) + '%'' ';
	END

	--号機
	IF RTRIM(LTRIM(ISNULL(@GOKI,''))) <> ''
	BEGIN
		SET @SQL += N' AND GOKI LIKE ''%' + RTRIM(LTRIM(@GOKI)) + '%'' ';
	END

	--現処置担当者ID
	IF @GEN_TANTO_ID <> 0
	BEGIN
		SET @SQL += N' AND GEN_TANTO_ID = ' + CONVERT(CHAR, @GEN_TANTO_ID) + '';
	END

	--処置実施日From
	IF RTRIM(LTRIM(ISNULL(@SYONIN_YMDHNS_FROM,''))) <> ''
	BEGIN
		SET @SQL += N' AND substring(SYONIN_YMDHNS,1,8) >= ''' + RTRIM(LTRIM(@SYONIN_YMDHNS_FROM)) + ''' ';
	END

	--処置実施日To
	IF RTRIM(LTRIM(ISNULL(@SYONIN_YMDHNS_TO,''))) <> ''
	BEGIN
		SET @SQL += N' AND substring(SYONIN_YMDHNS,1,8) <= ''' + RTRIM(LTRIM(@SYONIN_YMDHNS_TO)) + ''' ';
	END

	--報告書No
	IF RTRIM(LTRIM(ISNULL(@HOKOKU_NO,''))) <> ''
	BEGIN
		SET @SQL += N' AND HOKOKU_NO LIKE ''%' + RTRIM(LTRIM(@HOKOKU_NO)) + '%'' ';
	END

	--起草担当者ID
	IF ISNULL(@KISO_TANTO_ID,0) <> 0
	BEGIN
		SET @SQL += N' AND KISO_TANTO_ID = ' + CONVERT(CHAR, @KISO_TANTO_ID) + '';
	END

	--クローズフラグ
	IF RTRIM(LTRIM(ISNULL(@CLOSE_FG,''))) <> ''
	BEGIN
		SET @SQL += N' AND CLOSE_FG = ''' + RTRIM(LTRIM(@CLOSE_FG)) + ''' ';
	END

	--滞留フラグ
	IF RTRIM(LTRIM(ISNULL(@TAIRYU_FG,''))) <> ''
	BEGIN
		SET @SQL += N' AND TAIRYU_FG = ''' + RTRIM(LTRIM(@TAIRYU_FG)) + ''' ';
	END

	--不適合区分
	IF RTRIM(LTRIM(ISNULL(@FUTEKIGO_KB,''))) <> ''
	BEGIN
		SET @SQL += N' AND FUTEKIGO_NAME = ''' + RTRIM(LTRIM(@FUTEKIGO_KB)) + ''' ';
	END

	--不適合詳細区分
	IF RTRIM(LTRIM(ISNULL(@FUTEKIGO_S_KB,''))) <> ''
	BEGIN
		SET @SQL += N' AND FUTEKIGO_S_NAME = ''' + RTRIM(LTRIM(@FUTEKIGO_S_KB)) + ''' ';
	END

	--不適合状態区分
	IF RTRIM(LTRIM(ISNULL(@FUTEKIGO_JYOTAI_KB,''))) <> ''
	BEGIN
		SET @SQL += N' AND FUTEKIGO_JYOTAI_KB = ''' + RTRIM(LTRIM(@FUTEKIGO_JYOTAI_KB)) + ''' ';
	END

	--事前審査判定区分
	IF RTRIM(LTRIM(ISNULL(@JIZEN_SINSA_HANTEI_KB,''))) <> ''
	BEGIN
		SET @SQL += N' AND JIZEN_SINSA_HANTEI_KB = ''' + RTRIM(LTRIM(@JIZEN_SINSA_HANTEI_KB)) + ''' ';
	END

	--是正処置要否区分
	IF RTRIM(LTRIM(ISNULL(@ZESEI_SYOCHI_YOHI_KB,''))) <> ''
	BEGIN
		SET @SQL += N' AND ZESEI_SYOCHI_YOHI_KB = ''' + RTRIM(LTRIM(@ZESEI_SYOCHI_YOHI_KB)) + ''' ';
	END

	--再審委員会判定区分
	IF RTRIM(LTRIM(ISNULL(@SAISIN_IINKAI_HANTEI_KB,''))) <> ''
	BEGIN
		SET @SQL += N' AND SAISIN_IINKAI_HANTEI_KB = ''' + RTRIM(LTRIM(@SAISIN_IINKAI_HANTEI_KB)) + ''' ';
	END

	--検査結果区分
	IF RTRIM(LTRIM(ISNULL(@KENSA_KEKKA_KB,''))) <> ''
	BEGIN
		SET @SQL += N' AND KENSA_KEKKA_KB = ''' + RTRIM(LTRIM(@KENSA_KEKKA_KB)) + ''' ';
	END

	--根本要因区分1
	IF RTRIM(LTRIM(ISNULL(@KONPON_YOIN_KB1,''))) <> '' AND RTRIM(LTRIM(ISNULL(@KONPON_YOIN_KB2,''))) <> ''
	BEGIN
		SET @SQL += N' AND (KONPON_YOIN_KB = ''' + RTRIM(LTRIM(@KONPON_YOIN_KB1)) + ''' OR KONPON_YOIN_KB = ''' + RTRIM(LTRIM(@KONPON_YOIN_KB2)) + ''')';
	END
	ELSE IF RTRIM(LTRIM(ISNULL(@KONPON_YOIN_KB1,''))) <> ''		
	BEGIN
		SET @SQL += N' AND KONPON_YOIN_KB = ''' + RTRIM(LTRIM(@KONPON_YOIN_KB1)) + ''' ';
	END	
	ELSE IF RTRIM(LTRIM(ISNULL(@KONPON_YOIN_KB2,''))) <> ''
	BEGIN
		SET @SQL += N' AND KONPON_YOIN_KB = ''' + RTRIM(LTRIM(@KONPON_YOIN_KB2)) + ''' ';
	END

	--帰責工程区分
	IF RTRIM(LTRIM(ISNULL(@KISEKI_KOTEI_KB,''))) <> ''
	BEGIN
		SET @SQL += N' AND KISEKI_KOTEI_KB = ''' + RTRIM(LTRIM(@KISEKI_KOTEI_KB)) + ''' ';
	END

	--原因分析区分1
	IF RTRIM(LTRIM(ISNULL(@GENIN_BUNSEKI_KB1,''))) <> ''
	BEGIN
		SET @SQL += N' ' + @GENIN_BUNSEKI_KB1 + ' ';
	END

	--原因分析区分2
	IF RTRIM(LTRIM(ISNULL(@GENIN_BUNSEKI_KB2,''))) <> ''
	BEGIN
		SET @SQL += N' ' + @GENIN_BUNSEKI_KB2 + ' ';
	END

	--顧客判定指示区分
	IF RTRIM(LTRIM(ISNULL(@KOKYAKU_HANTEI_SIJI_KB,''))) <> ''
	BEGIN
		SET @SQL += N' AND KOKYAKU_HANTEI_SIJI_KB = ''' + @KOKYAKU_HANTEI_SIJI_KB + ''' ';
	END

	--顧客最終判定区分
	IF RTRIM(LTRIM(ISNULL(@KOKYAKU_SAISYU_HANTEI_KB,''))) <> ''
	BEGIN
		SET @SQL += N' AND KOKYAKU_SAISYU_HANTEI_KB = ''' + @KOKYAKU_SAISYU_HANTEI_KB + ''' ';
	END

	--発生日From
	IF RTRIM(LTRIM(ISNULL(@HASSEI_YMD_FROM,''))) <> ''
	BEGIN
		SET @SQL += N' AND HASSEI_YMD >= ''' + RTRIM(LTRIM(@HASSEI_YMD_FROM)) + ''' ';
	END

	--発生日To
	IF RTRIM(LTRIM(ISNULL(@HASSEI_YMD_TO,''))) <> ''
	BEGIN
		SET @SQL += N' AND HASSEI_YMD <= ''' + RTRIM(LTRIM(@HASSEI_YMD_TO)) + ''' ';
	END
	
	--集計
	SET @SQL = @SQL + N' GROUP BY ' + @G_SQL


	--テンポラリテーブルから取得
	SET @SQL += N';' --同一セッションで実行するため、SELECT INTO SQLと結合する
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
