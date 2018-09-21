USE [FMS]
GO

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

-- =============================================
-- Description:	不適合報告書一覧
-- =============================================
ALTER PROCEDURE [dbo].[ST02_FUTEKIGO_ICHIRAN]
  @BUMON_KB					char(2)			--部門区分
 ,@SYONIN_HOKOKUSYO_ID		int				--承認報告書ID
 ,@KISYU_ID					int				--機種ID
 ,@BUHIN_BANGO				char(60)		--部品番号
 ,@SYANAI_CD				char(10)		--社内コード
 ,@BUHIN_NAME				char(100)		--部品名称
 ,@GOKI						nvarchar(20)			--号機
 ,@GEN_TANTO_ID				int				--現処置担当者ID
 ,@SYONIN_YMDHNS_FROM		char(8)			--処置実施日From（承認日時を検索対象とする）
 ,@SYONIN_YMDHNS_TO			char(8)			--処置実施日To（承認日時を検索対象とする）
 ,@HOKOKU_NO				char(10)		--報告書No
 ,@KISO_TANTO_ID			int				--起草担当者ID
 ,@CLOSE_FG					char(1)			--クローズフラグ
 ,@TAIRYU_FG				char(1)			--滞留フラグ
 ,@FUTEKIGO_KB				char(2)			--不適合区分
 ,@FUTEKIGO_S_KB			char(2)			--不適合詳細区分
 ,@FUTEKIGO_JYOTAI_KB		char(2)			--不適合状態区分
 ,@JIZEN_SINSA_HANTEI_KB	char(2)			--事前審査判定区分
 ,@ZESEI_SYOCHI_YOHI_KB		char(2)			--是正処置要否区分
 ,@SAISIN_IINKAI_HANTEI_KB	char(2)			--再審委員会判定区分
 ,@KENSA_KEKKA_KB			char(2)			--検査結果区分
 ,@KONPON_YOIN_KB1			char(2)			--根本要因区分1
 ,@KONPON_YOIN_KB2			char(2)			--根本要因区分2
 ,@KISEKI_KOTEI_KB			char(2)			--帰責工程区分
 ,@KOKYAKU_HANTEI_SIJI_KB	char(2)			--顧客判定指示区分
 ,@KOKYAKU_SAISYU_HANTEI_KB char(2)			--顧客最終判定区分
 ,@GENIN_BUNSEKI_KB1		nvarchar(500)	--原因分析区分1でWHERE条件の内容をそのままセットする
 ,@GENIN_BUNSEKI_KB2		nvarchar(500)	--原因分析区分2でWHERE条件の内容をそのままセットする
 ,@HASSEI_YMD_FROM			char(8)
 ,@HASSEI_YMD_TO				char(8)
AS
BEGIN TRY
	DECLARE @ErrorMessage varchar(4000);
	DECLARE @ErrorProcedure NVARCHAR(126);

	DECLARE @W_HOKOKU_NO					char(10);		-- 1.報告書No
	DECLARE @W_SYONIN_JUN					int;			-- 2.承認順
	DECLARE @W_SYONIN_NAIYO					nvarchar(50);	-- 3.承認内容（ステージ）
	DECLARE @W_SYONIN_HOKOKUSYO_ID			int;			-- 4.承認報告書ID
	DECLARE @W_SYONIN_HOKOKUSYO_NAME		nvarchar(50);	-- 5.承認報告書名
	DECLARE @W_SYONIN_HOKOKUSYO_R_NAME		nvarchar(10);	-- 6.承認報告書略名
	DECLARE @W_GEN_TANTO_ID					int;			-- 7.承認担当者ID（現処置担当者ID）
	DECLARE @W_GEN_TANTO_NAME				char(30);		-- 8.承認担当者名
	DECLARE @W_SYONIN_YMDHNS				char(8);		-- 9.承認日時（処置実施日）
	DECLARE @W_TAIRYU_NISSU					int;			--10.滞留日数
	DECLARE @W_TAIRYU_FG					char(1);		--11.滞留フラグ
	DECLARE @W_KISYU_ID						int;			--12.機種ID
	--DECLARE @W_KISYU						char(100);		--13.機種
	DECLARE @W_KISYU_NAME					char(100);		--14.機種名
	DECLARE @W_BUHIN_BANGO					char(60);		--15.部品番号
	DECLARE @W_BUHIN_NAME					char(80);		--16.部品名
	DECLARE @W_GOKI							 nvarchar(20);		--17.号機
	DECLARE @W_SYANAI_CD					char(10);		--18.社内コード
	DECLARE @W_FUTEKIGO_KB					char(2);		--19.不適合区分
	DECLARE @W_FUTEKIGO_NAME				char(50);		--20.不適合区分名
	DECLARE @W_FUTEKIGO_S_KB				char(2);		--21.不適合詳細区分
	DECLARE @W_FUTEKIGO_S_NAME				char(50);		--22.不適合詳細区分名
	DECLARE @W_FUTEKIGO_JYOTAI_KB			char(2);		--23.不適合状態区分
	DECLARE @W_FUTEKIGO_JYOTAI_NAME			char(50);		--24.不適合状態区分
	DECLARE @W_JIZEN_SINSA_HANTEI_KB		char(2);		--25.事前審査判定区分
	DECLARE @W_JIZEN_SINSA_HANTEI_NAME		char(150);		--26.事前審査判定区分名
	DECLARE @W_ZESEI_SYOCHI_YOHI_KB			char(2);		--27.是正処置要否区分
	DECLARE @W_ZESEI_SYOCHI_YOHI_NAME		char(50);		--28.是正処置要否区分名
	DECLARE @W_SAISIN_IINKAI_HANTEI_KB		char(2);		--29.再審委員会判定区分
	DECLARE @W_SAISIN_IINKAI_HANTEI_NAME	char(50);		--30.再審委員会判定区分名
	DECLARE @W_KENSA_KEKKA_KB				char(2);		--31.検査結果区分
	DECLARE @W_KENSA_KEKKA_NAME				char(50);		--32.検査結果区分名
	DECLARE @W_KONPON_YOIN_KB1				char(2);		--33.根本要因区分1
	DECLARE @W_KONPON_YOIN_NAME1			char(50);		--34.根本要因区分名1
	DECLARE @W_KONPON_YOIN_KB2				char(2);		--35.根本要因区分2
	DECLARE @W_KONPON_YOIN_NAME2			char(50);		--36.根本要因区分名2
	DECLARE @W_KISEKI_KOTEI_KB				char(2);		--37.帰責工程区分
	DECLARE @W_KISEKI_KOTEI_NAME			char(50);		--38.帰責工程区分名
	DECLARE @W_KISO_YMD						char(8);		--39.起草日
	DECLARE @W_KISO_TANTO_ID				int;		--40.起草担当者ID
	DECLARE @W_KISO_TANTO_NAME				char(30);		--41.起草担当者名
	DECLARE @W_CLOSE_FG						char(1);		--42.クローズフラグ
	DECLARE @W_SASIMOTO_SYONIN_JUN			int;			--43.差戻元承認順
	DECLARE @W_SASIMOTO_SYONIN_NAIYO		nvarchar(50);	--44.差戻元承認内容（差戻し元ステージ）
	DECLARE @W_RIYU							nvarchar(100);	--45.差戻理由
	DECLARE @W_YOKYU_NAIYO					nvarchar(500);	--46.要求内容
	DECLARE @W_BUMON_KB						char(1);		--47.部門区分
	DECLARE @W_BUMON_NAME					char(50);		--48.部門区分
	DECLARE @W_KOKYAKU_HANTEI_SIJI_KB		char(2);		--49.顧客判定指示区分
	DECLARE @W_KOKYAKU_HANTEI_SIJI_NAME		nvarchar(150);	--50.顧客判定指示区分名
	DECLARE @W_KOKYAKU_SAISYU_HANTEI_KB	    char(2);		--51.顧客最終判定区分
	DECLARE @W_KOKYAKU_SAISYU_HANTEI_NAME	nvarchar(150);	--52.顧客最終判定区分名
	DECLARE @W_DEL_YMDHNS char(14);
	DECLARE @W_HASSEI_YMD char(8);

	DECLARE @retTBL TABLE(
	 HOKOKU_NO					char(10)		-- 1.報告書No
	,SYONIN_JUN					int				-- 2.承認順
	,SYONIN_NAIYO				nvarchar(100)	-- 3.承認内容（ステージ）
	,SYONIN_HOKOKUSYO_ID		int				-- 4.承認報告書ID
	,SYONIN_HOKOKUSYO_NAME		nvarchar(50)	-- 5.承認報告書名
	,SYONIN_HOKOKUSYO_R_NAME	nvarchar(20)	-- 6.承認報告書略名
	,GEN_TANTO_ID				int				-- 7.承認担当者ID（現処置担当者ID）
	,GEN_TANTO_NAME				char(30)		-- 8.承認担当者名
	,SYONIN_YMDHNS				char(8)			-- 9.承認日時（処置実施日）
	,TAIRYU_NISSU				int				--10.滞留日数
	,TAIRYU_FG					char(1)			--11.滞留フラグ
	,KISYU_ID					int				--12.機種ID
	--,KISYU						char(100)		--13.機種
	,KISYU_NAME					char(100)		--14.機種名
	,BUHIN_BANGO				char(60)		--15.部品番号
	,BUHIN_NAME					char(80)		--16.部品名
	,GOKI						nvarchar(20)			--17.号機
	,SYANAI_CD					char(10)		--18.社内コード
	,FUTEKIGO_KB				char(2)			--19.不適合区分
	,FUTEKIGO_NAME				char(50)		--20.不適合区分名
	,FUTEKIGO_S_KB				char(2)			--21.不適合詳細区分
	,FUTEKIGO_S_NAME			char(50)		--22.不適合詳細区分名
	,FUTEKIGO_JYOTAI_KB			char(2)			--23.不適合状態区分
	,FUTEKIGO_JYOTAI_NAME		char(50)		--24.不適合状態区分
	,JIZEN_SINSA_HANTEI_KB		char(2)			--25.事前審査判定区分
	,JIZEN_SINSA_HANTEI_NAME	char(150)		--26.事前審査判定区分名
	,ZESEI_SYOCHI_YOHI_KB		char(2)			--27.是正処置要否区分
	,ZESEI_SYOCHI_YOHI_NAME		char(50)		--28.是正処置要否区分名
	,SAISIN_IINKAI_HANTEI_KB	char(2)			--29.再審委員会判定区分
	,SAISIN_IINKAI_HANTEI_NAME	char(50)			--30.再審委員会判定区分名
	,KENSA_KEKKA_KB				char(2)			--31.検査結果区分
	,KENSA_KEKKA_NAME			char(50)			--32.検査結果区分名
	,KONPON_YOIN_KB1			char(2)			--33.根本要因区分1
	,KONPON_YOIN_NAME1			char(50)		--34.根本要因区分名1
	,KONPON_YOIN_KB2			char(2)			--35.根本要因区分2
	,KONPON_YOIN_NAME2			char(50)		--36.根本要因区分名2
	,KISEKI_KOTEI_KB			char(2)			--37.帰責工程区分
	,KISEKI_KOTEI_NAME			char(50)		--38.帰責工程区分名
	,KISO_YMD					char(8)			--39.起草日
	,KISO_TANTO_ID				int			--40.起草担当者ID
	,KISO_TANTO_NAME			char(30)		--41.起草担当者名
	,CLOSE_FG					char(1)			--42.クローズフラグ
	--,MAE_SYOCHI_YMD				char(8)			--43.前処置実施日
	,SASIMOTO_SYONIN_JUN		int				--43.差戻元承認順
	,SASIMOTO_SYONIN_NAIYO		nvarchar(50)	--44.差戻元承認内容（差戻し元ステージ）
	,RIYU						nvarchar(100)	--45.差戻理由
	,YOKYU_NAIYO				nvarchar(500)	--46.要求内容
	,BUMON_KB					char(1)			--47.部門区分
	,BUMON_NAME					char(50)		--48.部門区分名
	,KOKYAKU_HANTEI_SIJI_KB		char(2)			--49.顧客判定指示区分
	,KOKYAKU_HANTEI_SIJI_NAME	nvarchar(150)	--50.顧客判定指示区分名
	,KOKYAKU_SAISYU_HANTEI_KB	char(2)			--51.顧客最終判定区分
	,KOKYAKU_SAISYU_HANTEI_NAME nvarchar(150)	--52.顧客最終判定区分名
	,DEL_YMDHNS char(14)
	,HASSEI_YMD char(8)
	);

	--SQL を作成する変数宣言
	DECLARE @SQL nvarchar(max)

	--カーソルを実行するSQLを作成する

	SET @SQL = N'';
	SET @SQL = @SQL + N' SELECT  ';
	SET @SQL = @SQL + N' HOKOKU_NO';					-- 1.報告書No
	SET @SQL = @SQL + N',SYONIN_JUN';					-- 2.承認順
	SET @SQL = @SQL + N',SYONIN_NAIYO';					-- 3.承認内容（ステージ）
	SET @SQL = @SQL + N',SYONIN_HOKOKUSYO_ID';			-- 4.承認報告書ID
	SET @SQL = @SQL + N',SYONIN_HOKOKUSYO_NAME';		-- 5.承認報告書名
	SET @SQL = @SQL + N',SYONIN_HOKOKUSYO_R_NAME';		-- 6.承認報告書略名
	SET @SQL = @SQL + N',GEN_TANTO_ID';					-- 7.承認担当者ID（現処置担当者ID）
	SET @SQL = @SQL + N',GEN_TANTO_NAME';				-- 8.承認担当者名
	SET @SQL = @SQL + N',SYONIN_YMDHNS';				-- 9.承認日時（処置実施日）
	SET @SQL = @SQL + N',TAIRYU_NISSU';					--10.滞留日数
	SET @SQL = @SQL + N',TAIRYU_FG';					--11.滞留フラグ
	SET @SQL = @SQL + N',KISYU_ID';						--12.機種ID
	--SET @SQL = @SQL + N',KISYU';						--13.機種
	SET @SQL = @SQL + N',KISYU_NAME';					--14.機種名
	SET @SQL = @SQL + N',BUHIN_BANGO';					--15.部品番号
	SET @SQL = @SQL + N',BUHIN_NAME';					--16.部品名
	SET @SQL = @SQL + N',GOKI';							--17.号機
	SET @SQL = @SQL + N',SYANAI_CD';					--18.社内コード
	SET @SQL = @SQL + N',FUTEKIGO_KB';					--19.不適合区分
	SET @SQL = @SQL + N',FUTEKIGO_NAME';				--20.不適合区分名
	SET @SQL = @SQL + N',FUTEKIGO_S_KB';				--21.不適合詳細区分
	SET @SQL = @SQL + N',FUTEKIGO_S_NAME';				--22.不適合詳細区分名
	SET @SQL = @SQL + N',FUTEKIGO_JYOTAI_KB';			--23.不適合状態区分
	SET @SQL = @SQL + N',FUTEKIGO_JYOTAI_NAME';			--24.不適合状態区分
	SET @SQL = @SQL + N',JIZEN_SINSA_HANTEI_KB';		--25.事前審査判定区分
	SET @SQL = @SQL + N',JIZEN_SINSA_HANTEI_NAME';		--26.事前審査判定区分名
	SET @SQL = @SQL + N',ZESEI_SYOCHI_YOHI_KB';			--27.是正処置要否区分
	SET @SQL = @SQL + N',ZESEI_SYOCHI_YOHI_NAME';		--28.是正処置要否区分名
	SET @SQL = @SQL + N',SAISIN_IINKAI_HANTEI_KB';		--29.再審委員会判定区分
	SET @SQL = @SQL + N',SAISIN_IINKAI_HANTEI_NAME';	--30.再審委員会判定区分名
	SET @SQL = @SQL + N',KENSA_KEKKA_KB';				--31.検査結果区分
	SET @SQL = @SQL + N',KENSA_KEKKA_NAME';				--32.検査結果区分名
	SET @SQL = @SQL + N',KONPON_YOIN_KB1';				--33.根本要因区分1
	SET @SQL = @SQL + N',KONPON_YOIN_NAME1';			--34.根本要因区分名1
	SET @SQL = @SQL + N',KONPON_YOIN_KB2';				--35.根本要因区分2
	SET @SQL = @SQL + N',KONPON_YOIN_NAME2';			--36.根本要因区分名2
	SET @SQL = @SQL + N',KISEKI_KOTEI_KB';				--37.帰責工程区分
	SET @SQL = @SQL + N',KISEKI_KOTEI_NAME';			--38.帰責工程区分名
	SET @SQL = @SQL + N',KISO_YMD';						--39.起草日
	SET @SQL = @SQL + N',KISO_TANTO_ID';				--40.起草担当者ID
	SET @SQL = @SQL + N',KISO_TANTO_NAME';				--41.起草担当者名
	SET @SQL = @SQL + N',CLOSE_FG';						--42.クローズフラグ
	SET @SQL = @SQL + N',SASIMOTO_SYONIN_JUN';			--43.差戻元承認順
	SET @SQL = @SQL + N',SASIMOTO_SYONIN_NAIYO';		--44.差戻元承認内容（差戻し元ステージ）
	SET @SQL = @SQL + N',RIYU';							--45.差戻理由
	SET @SQL = @SQL + N',YOKYU_NAIYO';					--46.要求内容
	SET @SQL = @SQL + N',BUMON_KB';						--47.部門区分
	SET @SQL = @SQL + N',BUMON_NAME';					--48.部門区分
	SET @SQL = @SQL + N',KOKYAKU_HANTEI_SIJI_KB';		--49.顧客判定指示区分
	SET @SQL = @SQL + N',KOKYAKU_HANTEI_SIJI_NAME';		--50.顧客判定指示区分名
	SET @SQL = @SQL + N',KOKYAKU_SAISYU_HANTEI_KB';		--51.顧客最終判定区分
	SET @SQL = @SQL + N',KOKYAKU_SAISYU_HANTEI_NAME';	--52.顧客最終判定区分名
	SET @SQL = @SQL + N',DEL_YMDHNS';	--2018.06.05 Add by funato
	SET @SQL = @SQL + N',HASSEI_YMD';	--2018.06.05 Add by funato
	SET @SQL = @SQL + N' FROM V007_NCR_CAR ';

	SET @SQL = @SQL + N' WHERE HOKOKU_NO <> '''' '

	--部門区分
	IF RTRIM(LTRIM(@BUMON_KB)) <> ''
	BEGIN
		SET @SQL = @SQL + N' AND BUMON_KB = ''' + RTRIM(LTRIM(@BUMON_KB)) + ''' ';
	END

	--承認報告書ID
	IF @SYONIN_HOKOKUSYO_ID <> 0
	BEGIN
		SET @SQL = @SQL + N' AND SYONIN_HOKOKUSYO_ID = ' + CONVERT(char,@SYONIN_HOKOKUSYO_ID) + '';
	END

	--機種ID
	IF @KISYU_ID <> 0
	BEGIN
		SET @SQL = @SQL + N' AND KISYU_ID = ' + CONVERT(char,@KISYU_ID) + '';
	END

	--部品番号
	IF RTRIM(LTRIM(@BUHIN_BANGO)) <> ''
	BEGIN
		SET @SQL = @SQL + N' AND BUHIN_BANGO LIKE ''%' + RTRIM(LTRIM(@BUHIN_BANGO)) + '%'' ';
	END

	--社内コード
	IF RTRIM(LTRIM(@SYANAI_CD)) <> ''
	BEGIN
		SET @SQL = @SQL + N' AND SYANAI_CD LIKE ''%' + RTRIM(LTRIM(@SYANAI_CD)) + '%'' ';
	END

	--部品名称
	IF RTRIM(LTRIM(@BUHIN_NAME)) <> ''
	BEGIN
		SET @SQL = @SQL + N' AND BUHIN_NAME LIKE ''%' + RTRIM(LTRIM(@BUHIN_NAME)) + '%'' ';
	END

	--号機
	IF RTRIM(LTRIM(@GOKI)) <> ''
	BEGIN
		SET @SQL = @SQL + N' AND GOKI LIKE ''%' + RTRIM(LTRIM(@GOKI)) + '%'' ';
	END

	--現処置担当者ID
	IF @GEN_TANTO_ID <> 0
	BEGIN
		SET @SQL = @SQL + N' AND GEN_TANTO_ID = ' + CONVERT(char,@GEN_TANTO_ID) + '';
	END

	--処置実施日From
	IF RTRIM(LTRIM(@SYONIN_YMDHNS_FROM)) <> ''
	BEGIN
		SET @SQL = @SQL + N' AND substring(SYONIN_YMDHNS,1,8) >= ''' + RTRIM(LTRIM(@SYONIN_YMDHNS_FROM)) + ''' ';
	END

	--処置実施日To
	IF RTRIM(LTRIM(@SYONIN_YMDHNS_TO)) <> ''
	BEGIN
		SET @SQL = @SQL + N' AND substring(SYONIN_YMDHNS,1,8) <= ''' + RTRIM(LTRIM(@SYONIN_YMDHNS_TO)) + ''' ';
	END

	--報告書No
	IF RTRIM(LTRIM(@HOKOKU_NO)) <> ''
	BEGIN
		SET @SQL = @SQL + N' AND HOKOKU_NO =''' + RTRIM(LTRIM(@HOKOKU_NO)) + ''' ';
	END

	--起草担当者ID
	IF @KISO_TANTO_ID <> 0
	BEGIN
		SET @SQL = @SQL + N' AND KISO_TANTO_ID = ' + CONVERT(char,@KISO_TANTO_ID) + '';
	END

	--クローズフラグ
	IF RTRIM(LTRIM(@CLOSE_FG)) <> ''
	BEGIN
		SET @SQL = @SQL + N' AND CLOSE_FG = ''' + RTRIM(LTRIM(@CLOSE_FG)) + ''' ';
	END

	--滞留フラグ
	IF RTRIM(LTRIM(@TAIRYU_FG)) <> ''
	BEGIN
		SET @SQL = @SQL + N' AND TAIRYU_FG = ''' + RTRIM(LTRIM(@TAIRYU_FG)) + ''' ';
	END

	--不適合区分
	IF RTRIM(LTRIM(@FUTEKIGO_KB)) <> ''
	BEGIN
		SET @SQL = @SQL + N' AND FUTEKIGO_KB = ''' + RTRIM(LTRIM(@FUTEKIGO_KB)) + ''' ';
	END

	--不適合詳細区分
	IF RTRIM(LTRIM(@FUTEKIGO_S_KB)) <> ''
	BEGIN
		SET @SQL = @SQL + N' AND FUTEKIGO_S_KB = ''' + RTRIM(LTRIM(@FUTEKIGO_S_KB)) + ''' ';
	END

	--不適合状態区分
	IF RTRIM(LTRIM(@FUTEKIGO_JYOTAI_KB)) <> ''
	BEGIN
		SET @SQL = @SQL + N' AND FUTEKIGO_JYOTAI_KB = ''' + RTRIM(LTRIM(@FUTEKIGO_JYOTAI_KB)) + ''' ';
	END

	--事前審査判定区分
	IF RTRIM(LTRIM(@JIZEN_SINSA_HANTEI_KB)) <> ''
	BEGIN
		SET @SQL = @SQL + N' AND JIZEN_SINSA_HANTEI_KB = ''' + RTRIM(LTRIM(@JIZEN_SINSA_HANTEI_KB)) + ''' ';
	END

	--是正処置要否区分
	IF RTRIM(LTRIM(@ZESEI_SYOCHI_YOHI_KB)) <> ''
	BEGIN
		SET @SQL = @SQL + N' AND ZESEI_SYOCHI_YOHI_KB = ''' + RTRIM(LTRIM(@ZESEI_SYOCHI_YOHI_KB)) + ''' ';
	END

	--再審委員会判定区分
	IF RTRIM(LTRIM(@SAISIN_IINKAI_HANTEI_KB)) <> ''
	BEGIN
		SET @SQL = @SQL + N' AND SAISIN_IINKAI_HANTEI_KB = ''' + RTRIM(LTRIM(@SAISIN_IINKAI_HANTEI_KB)) + ''' ';
	END

	--検査結果区分
	IF RTRIM(LTRIM(@KENSA_KEKKA_KB)) <> ''
	BEGIN
		SET @SQL = @SQL + N' AND KENSA_KEKKA_KB = ''' + RTRIM(LTRIM(@KENSA_KEKKA_KB)) + ''' ';
	END

	--根本要因区分1
	IF RTRIM(LTRIM(@KONPON_YOIN_KB1)) <> ''
	BEGIN
		SET @SQL = @SQL + N' AND KONPON_YOIN_KB1 = ''' + RTRIM(LTRIM(@KONPON_YOIN_KB1)) + ''' ';
	END

	--根本要因区分2
	IF RTRIM(LTRIM(@KONPON_YOIN_KB2)) <> ''
	BEGIN
		SET @SQL = @SQL + N' AND KONPON_YOIN_KB2 = ''' + RTRIM(LTRIM(@KONPON_YOIN_KB2)) + ''' ';
	END

	--帰責工程区分
	IF RTRIM(LTRIM(@KISEKI_KOTEI_KB)) <> ''
	BEGIN
		SET @SQL = @SQL + N' AND KISEKI_KOTEI_KB = ''' + RTRIM(LTRIM(@KISEKI_KOTEI_KB)) + ''' ';
	END

	--原因分析区分1
	IF RTRIM(LTRIM(@GENIN_BUNSEKI_KB1)) <> ''
	BEGIN
		SET @SQL = @SQL + N' ' + @GENIN_BUNSEKI_KB1 + ' ';
	END

	--原因分析区分2
	IF RTRIM(LTRIM(@GENIN_BUNSEKI_KB2)) <> ''
	BEGIN
		SET @SQL = @SQL + N' ' + @GENIN_BUNSEKI_KB2 + ' ';
	END
	/*
	--顧客判定指示区分
	IF RTRIM(LTRIM(@KOKYAKU_HANTEI_SIJI_KB)) <> ''
	BEGIN
		SET @SQL = @SQL + N' AND KOKYAKU_HANTEI_SIJI_KB = ''' + @KOKYAKU_HANTEI_SIJI_KB + ''' ';
	END

	--顧客最終判定区分
	IF RTRIM(LTRIM(@KOKYAKU_SAISYU_HANTEI_KB)) <> ''
	BEGIN
		SET @SQL = @SQL + N' AND KOKYAKU_SAISYU_HANTEI_KB = ''' + @KOKYAKU_SAISYU_HANTEI_KB + ''' ';
	END
	*/

	--発生日From
	IF RTRIM(LTRIM(@HASSEI_YMD_FROM)) <> ''
	BEGIN
		SET @SQL = @SQL + N' AND HASSEI_YMD >= ''' + RTRIM(LTRIM(@HASSEI_YMD_FROM)) + ''' ';
	END

	--発生日To
	IF RTRIM(LTRIM(@HASSEI_YMD_TO)) <> ''
	BEGIN
		SET @SQL = @SQL + N' AND HASSEI_YMD <= ''' + RTRIM(LTRIM(@HASSEI_YMD_TO)) + ''' ';
	END

	--カーソル定義
	EXECUTE (' DECLARE curTB_A CURSOR FOR ' + @SQL);

	OPEN curTB_A;

	WHILE 1 = 1
	BEGIN

		FETCH NEXT FROM curTB_A	INTO
		 @W_HOKOKU_NO					-- 1.報告書No

		,@W_SYONIN_JUN					-- 2.承認順
		,@W_SYONIN_NAIYO				-- 3.承認内容（ステージ）
		,@W_SYONIN_HOKOKUSYO_ID			-- 4.承認報告書ID
		,@W_SYONIN_HOKOKUSYO_NAME		-- 5.承認報告書名
		,@W_SYONIN_HOKOKUSYO_R_NAME		-- 6.承認報告書略名
		,@W_GEN_TANTO_ID				-- 7.承認担当者ID（現処置担当者ID）
		,@W_GEN_TANTO_NAME				-- 8.承認担当者名
		,@W_SYONIN_YMDHNS				-- 9.承認日時（処置実施日）
		,@W_TAIRYU_NISSU				--10.滞留日数
		,@W_TAIRYU_FG					--11.滞留フラグ
		,@W_KISYU_ID					--12.機種ID
		--,@W_KISYU						--13.機種
		,@W_KISYU_NAME					--14.機種名
		,@W_BUHIN_BANGO					--15.部品番号
		,@W_BUHIN_NAME					--16.部品名
		,@W_GOKI						--17.号機
		,@W_SYANAI_CD					--18.社内コード
		,@W_FUTEKIGO_KB					--19.不適合区分
		,@W_FUTEKIGO_NAME				--20.不適合区分名
		,@W_FUTEKIGO_S_KB				--21.不適合詳細区分
		,@W_FUTEKIGO_S_NAME				--22.不適合詳細区分名
		,@W_FUTEKIGO_JYOTAI_KB			--23.不適合状態区分
		,@W_FUTEKIGO_JYOTAI_NAME		--24.不適合状態区分
		,@W_JIZEN_SINSA_HANTEI_KB		--25.事前審査判定区分
		,@W_JIZEN_SINSA_HANTEI_NAME		--26.事前審査判定区分名
		,@W_ZESEI_SYOCHI_YOHI_KB		--27.是正処置要否区分
		,@W_ZESEI_SYOCHI_YOHI_NAME		--28.是正処置要否区分名
		,@W_SAISIN_IINKAI_HANTEI_KB		--29.再審委員会判定区分
		,@W_SAISIN_IINKAI_HANTEI_NAME	--30.再審委員会判定区分名
		,@W_KENSA_KEKKA_KB				--31.検査結果区分
		,@W_KENSA_KEKKA_NAME			--32.検査結果区分名
		,@W_KONPON_YOIN_KB1				--33.根本要因区分1
		,@W_KONPON_YOIN_NAME1			--34.根本要因区分名1
		,@W_KONPON_YOIN_KB2				--35.根本要因区分2
		,@W_KONPON_YOIN_NAME2			--36.根本要因区分名2
		,@W_KISEKI_KOTEI_KB				--37.帰責工程区分
		,@W_KISEKI_KOTEI_NAME			--38.帰責工程区分名
		,@W_KISO_YMD					--39.起草日
		,@W_KISO_TANTO_ID				--40.起草担当者ID
		,@W_KISO_TANTO_NAME				--41.起草担当者名
		,@W_CLOSE_FG					--42.クローズフラグ
		,@W_SASIMOTO_SYONIN_JUN			--43.差戻元承認順
		,@W_SASIMOTO_SYONIN_NAIYO		--44.差戻元承認内容（差戻し元ステージ）
		,@W_RIYU						--45.差戻理由
		,@W_YOKYU_NAIYO					--46.要求内容
		,@W_BUMON_KB					--47.部門区分
		,@W_BUMON_NAME					--48.部門区分名
		,@W_KOKYAKU_HANTEI_SIJI_KB		--49.顧客判定指示区分
		,@W_KOKYAKU_HANTEI_SIJI_NAME	--50.顧客判定指示区分名
		,@W_KOKYAKU_SAISYU_HANTEI_KB	--51.顧客最終判定区分
		,@W_KOKYAKU_SAISYU_HANTEI_NAME	--52.顧客最終判定区分名
		,@W_DEL_YMDHNS --2018.06.05 Add by funato
		,@W_HASSEI_YMD

		IF @@FETCH_STATUS <> 0
		BEGIN
			BREAK;
		END

		INSERT INTO @retTBL (
		 HOKOKU_NO					-- 1.報告書No
		,SYONIN_JUN					-- 2.承認順
		,SYONIN_NAIYO				-- 3.承認内容（ステージ）
		,SYONIN_HOKOKUSYO_ID		-- 4.承認報告書ID
		,SYONIN_HOKOKUSYO_NAME		-- 5.承認報告書名
		,SYONIN_HOKOKUSYO_R_NAME	-- 6.承認報告書略名
		,GEN_TANTO_ID				-- 7.承認担当者ID（現処置担当者ID）
		,GEN_TANTO_NAME				-- 8.承認担当者名
		,SYONIN_YMDHNS				-- 9.承認日時（処置実施日）
		,TAIRYU_NISSU				--10.滞留日数
		,TAIRYU_FG					--11.滞留フラグ
		,KISYU_ID					--12.機種ID
		--,KISYU						--13.機種
		,KISYU_NAME					--14.機種名
		,BUHIN_BANGO				--15.部品番号
		,BUHIN_NAME					--16.部品名
		,GOKI						--17.号機
		,SYANAI_CD					--18.社内コード
		,FUTEKIGO_KB				--19.不適合区分
		,FUTEKIGO_NAME				--20.不適合区分名
		,FUTEKIGO_S_KB				--21.不適合詳細区分
		,FUTEKIGO_S_NAME			--22.不適合詳細区分名
		,FUTEKIGO_JYOTAI_KB			--23.不適合状態区分
		,FUTEKIGO_JYOTAI_NAME		--24.不適合状態区分
		,JIZEN_SINSA_HANTEI_KB		--25.事前審査判定区分
		,JIZEN_SINSA_HANTEI_NAME	--26.事前審査判定区分名
		,ZESEI_SYOCHI_YOHI_KB		--27.是正処置要否区分
		,ZESEI_SYOCHI_YOHI_NAME		--28.是正処置要否区分名
		,SAISIN_IINKAI_HANTEI_KB	--29.再審委員会判定区分
		,SAISIN_IINKAI_HANTEI_NAME	--30.再審委員会判定区分名
		,KENSA_KEKKA_KB				--31.検査結果区分
		,KENSA_KEKKA_NAME			--32.検査結果区分名
		,KONPON_YOIN_KB1			--33.根本要因区分1
		,KONPON_YOIN_NAME1			--34.根本要因区分名1
		,KONPON_YOIN_KB2			--35.根本要因区分2
		,KONPON_YOIN_NAME2			--36.根本要因区分名2
		,KISEKI_KOTEI_KB			--37.帰責工程区分
		,KISEKI_KOTEI_NAME			--38.帰責工程区分名
		,KISO_YMD					--39.起草日
		,KISO_TANTO_ID				--40.起草担当者ID
		,KISO_TANTO_NAME			--41.起草担当者名
		,CLOSE_FG					--42.クローズフラグ
		,SASIMOTO_SYONIN_JUN		--43.差戻元承認順
		,SASIMOTO_SYONIN_NAIYO		--44.差戻元承認内容（差戻し元ステージ）
		,RIYU						--45.差戻理由
		,YOKYU_NAIYO				--46.要求内容
		,BUMON_KB					--47.部門区分
		,BUMON_NAME					--48.部門区分
		,KOKYAKU_HANTEI_SIJI_KB		--49.顧客判定指示区分
		,KOKYAKU_HANTEI_SIJI_NAME	--50.顧客判定指示区分名
		,KOKYAKU_SAISYU_HANTEI_KB	--51.顧客最終判定区分
		,KOKYAKU_SAISYU_HANTEI_NAME	--52.顧客最終判定区分名
		,DEL_YMDHNS
		,HASSEI_YMD
		) VALUES (
		@W_HOKOKU_NO					-- 1.報告書No
		,@W_SYONIN_JUN					-- 2.承認順
		,@W_SYONIN_NAIYO				-- 3.承認内容（ステージ）
		,@W_SYONIN_HOKOKUSYO_ID			-- 4.承認報告書ID
		,@W_SYONIN_HOKOKUSYO_NAME		-- 5.承認報告書名
		,@W_SYONIN_HOKOKUSYO_R_NAME		-- 6.承認報告書略名
		,@W_GEN_TANTO_ID				-- 7.承認担当者ID（現処置担当者ID）
		,@W_GEN_TANTO_NAME				-- 8.承認担当者名
		,@W_SYONIN_YMDHNS				-- 9.承認日時（処置実施日）
		,@W_TAIRYU_NISSU				--10.滞留日数
		,@W_TAIRYU_FG					--11.滞留フラグ
		,@W_KISYU_ID					--12.機種ID
		--,@W_KISYU						--13.機種
		,@W_KISYU_NAME					--14.機種名
		,@W_BUHIN_BANGO					--15.部品番号
		,@W_BUHIN_NAME					--16.部品名
		,@W_GOKI						--17.号機
		,@W_SYANAI_CD					--18.社内コード
		,@W_FUTEKIGO_KB					--19.不適合区分
		,@W_FUTEKIGO_NAME				--20.不適合区分名
		,@W_FUTEKIGO_S_KB				--21.不適合詳細区分
		,@W_FUTEKIGO_S_NAME				--22.不適合詳細区分名
		,@W_FUTEKIGO_JYOTAI_KB			--23.不適合状態区分
		,@W_FUTEKIGO_JYOTAI_NAME		--24.不適合状態区分
		,@W_JIZEN_SINSA_HANTEI_KB		--25.事前審査判定区分
		,@W_JIZEN_SINSA_HANTEI_NAME		--26.事前審査判定区分名
		,@W_ZESEI_SYOCHI_YOHI_KB		--27.是正処置要否区分
		,@W_ZESEI_SYOCHI_YOHI_NAME		--28.是正処置要否区分名
		,@W_SAISIN_IINKAI_HANTEI_KB		--29.再審委員会判定区分
		,@W_SAISIN_IINKAI_HANTEI_NAME	--30.再審委員会判定区分名
		,@W_KENSA_KEKKA_KB				--31.検査結果区分
		,@W_KENSA_KEKKA_NAME			--32.検査結果区分名
		,@W_KONPON_YOIN_KB1				--33.根本要因区分1
		,@W_KONPON_YOIN_NAME1			--34.根本要因区分名1
		,@W_KONPON_YOIN_KB2				--35.根本要因区分2
		,@W_KONPON_YOIN_NAME2			--36.根本要因区分名2
		,@W_KISEKI_KOTEI_KB				--37.帰責工程区分
		,@W_KISEKI_KOTEI_NAME			--38.帰責工程区分名
		,@W_KISO_YMD					--39.起草日
		,@W_KISO_TANTO_ID				--40.起草担当者ID
		,@W_KISO_TANTO_NAME				--41.起草担当者名
		,@W_CLOSE_FG					--42.クローズフラグ
		,@W_SASIMOTO_SYONIN_JUN			--43.差戻元承認順
		,@W_SASIMOTO_SYONIN_NAIYO		--44.差戻元承認内容（差戻し元ステージ）
		,@W_RIYU						--45.差戻理由
		,@W_YOKYU_NAIYO					--46.要求内容
		,@W_BUMON_KB					--47.部門区分
		,@W_BUMON_NAME					--48.部門区分
		,@W_KOKYAKU_HANTEI_SIJI_KB		--49.顧客判定指示区分
		,@W_KOKYAKU_HANTEI_SIJI_NAME	--50.顧客判定指示区分名
		,@W_KOKYAKU_SAISYU_HANTEI_KB	--51.顧客最終判定区分
		,@W_KOKYAKU_SAISYU_HANTEI_NAME	--52.顧客最終判定区分名
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





