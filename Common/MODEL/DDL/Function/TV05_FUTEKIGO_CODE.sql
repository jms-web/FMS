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
-- Description:	不適合区分一覧
-- =============================================
ALTER FUNCTION [dbo].[TV05_FUTEKIGO_CODE] 
(
	 @BUMON_KB				char(1)	--部門区分
) RETURNS
	@retTBL TABLE(
	 SEIHIN_KB				char(1)				--製品区分（部門区分）
	,SEIHIN_KB_NAME			varchar(150)		--製品区分名（部門区分名）
	,FUTEKIGO_KB			char(2)				--不適合区分
	,FUTEKIGO_KB_NAME		nvarchar(150)		--不適合区分名
	,FUTEKIGO_S_KB			char(2)				--不適合詳細区分
	,FUTEKIGO_S_KB_NAME		char(150)			--不適合詳細区分名
	,ADD_YMDHNS				char(14)			--追加日時
	,ADD_SYAIN_ID			int					--追加社員ID
	,ADD_SYAIN_NAME			char(30)			--追加社員名
	,UPD_YMDHNS				char(14)			--更新日時
	,UPD_SYAIN_ID			int					--更新社員ID
	,UPD_SYAIN_NAME			char(30)			--更新社員名
	,DEL_YMDHNS				char(14)			--削除日時
	,DEL_SYAIN_ID			int					--削除社員ID
	,DEL_SYAIN_NAME			char(30)			--削除社員名
)
AS
BEGIN
	DECLARE @W_SEIHIN_KB			char(1);		--製品区分（部門区分）
	DECLARE @W_SEIHIN_KB_NAME		varchar(150);	--製品区分名（部門区分名）
	DECLARE @W_FUTEKIGO_KB			char(2)	;		--不適合区分
	DECLARE @W_FUTEKIGO_KB_NAME		nvarchar(150);	--不適合区分名
	DECLARE @W_FUTEKIGO_S_KB		char(2);		--不適合詳細区分
	DECLARE @W_FUTEKIGO_S_KB_NAME	char(150);		--不適合詳細区分名
	DECLARE @GROUP_TAG				nvarchar(20);	--不適合詳細のグループタグ
	DECLARE @W_ADD_YMDHNS			char(14);		--追加日時
	DECLARE @W_ADD_SYAIN_ID			int;			--追加社員ID
	DECLARE @W_ADD_SYAIN_NAME		char(30);		--追加社員名
	DECLARE @W_UPD_YMDHNS			char(14);		--更新日時
	DECLARE @W_UPD_SYAIN_ID			int;			--更新社員ID
	DECLARE @W_UPD_SYAIN_NAME		char(30);		--更新社員名
	DECLARE @W_DEL_YMDHNS			char(14);		--削除日時
	DECLARE @W_DEL_SYAIN_ID			int;			--削除社員ID
	DECLARE @W_DEL_SYAIN_NAME		char(30);		--削除社員名

	SET @W_SEIHIN_KB = @BUMON_KB;

	--引数の部門区分から、部門名を取得してセットする
	SELECT @W_SEIHIN_KB_NAME = ITEM_DISP FROM M001_SETTING
	WHERE
	    ITEM_NAME = '部門区分'
	AND ITEM_VALUE = @BUMON_KB;

	--部門区分によって、M01コードマスタから部門区分の不適合区分、不適合区分名を取得する
	IF @BUMON_KB = '1'		--風防
	BEGIN
		SET @GROUP_TAG = '風防_不適合区分';
	END 
	ELSE IF @BUMON_KB = '2'	--LP
	BEGIN
		SET @GROUP_TAG = 'LP_不適合区分';
	END 
	ELSE IF @BUMON_KB = '3'	--複合材
	BEGIN
		SET @GROUP_TAG = '複合材_不適合区分';
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

		IF @BUMON_KB = '1'		--風防
		BEGIN
			IF @W_FUTEKIGO_KB = '0'			--外観
			BEGIN
				SET @GROUP_TAG = '風防_不適合外観区分';
			END 
			ELSE IF @W_FUTEKIGO_KB ='1'		--寸法
			BEGIN
				SET @GROUP_TAG = '風防_不適合寸法区分';			
			END
			ELSE IF @W_FUTEKIGO_KB = '2'	--形状
			BEGIN
				SET @GROUP_TAG = '風防_不適合形状区分';	
			END 
			ELSE IF @W_FUTEKIGO_KB = '3'	--機能・性能
			BEGIN
				SET @GROUP_TAG = '風防_不適合機能性能区分';	
			END
			ELSE IF @W_FUTEKIGO_KB = '9'	--その他
			BEGIN
				SET @GROUP_TAG = '風防_不適合その他区分';	
			END;

		END
		ELSE IF @BUMON_KB = '2'		--LP
		BEGIN
			IF @W_FUTEKIGO_KB = '0'			--外観
			BEGIN
				SET @GROUP_TAG = 'LP_不適合外観区分';
			END 
			ELSE IF @W_FUTEKIGO_KB ='1'		--寸法
			BEGIN
				SET @GROUP_TAG = 'LP_不適合寸法区分';			
			END
			ELSE IF @W_FUTEKIGO_KB = '2'	--形状
			BEGIN
				SET @GROUP_TAG = 'LP_不適合形状区分';	
			END 
			ELSE IF @W_FUTEKIGO_KB = '3'	--機能・性能
			BEGIN
				SET @GROUP_TAG = 'LP_不適合機能性能区分';	
			END
			ELSE IF @W_FUTEKIGO_KB = '9'	--その他
			BEGIN
				SET @GROUP_TAG = 'LP_不適合その他区分';	
			END;
		END
		ELSE IF @BUMON_KB = '3'		--複合材
		BEGIN
			IF @W_FUTEKIGO_KB = '0'			--寸法
			BEGIN
				SET @GROUP_TAG = '複合材_不適合寸法区分';
			END 
			ELSE IF @W_FUTEKIGO_KB ='1'		--形状
			BEGIN
				SET @GROUP_TAG = '複合材_不適合形状区分';			
			END
			ELSE IF @W_FUTEKIGO_KB = '2'	--穿孔
			BEGIN
				SET @GROUP_TAG = '複合材_不適合穿孔区分';	
			END 
			ELSE IF @W_FUTEKIGO_KB = '3'	--外観
			BEGIN
				SET @GROUP_TAG = '複合材_不適合外観区分';	
			END
			ELSE IF @W_FUTEKIGO_KB = '4'	--内部欠陥
			BEGIN
				SET @GROUP_TAG = '複合材_不適合内部欠陥区分';	
			END
			ELSE IF @W_FUTEKIGO_KB = '5'	--硬化条件
			BEGIN
				SET @GROUP_TAG = '複合材_不適合硬化条件区分';	
			END
			ELSE IF @W_FUTEKIGO_KB = '6'	--プロセス
			BEGIN
				SET @GROUP_TAG = '複合材_不適合プロセス区分';	
			END
			ELSE IF @W_FUTEKIGO_KB = '9'	--その他
			BEGIN
				SET @GROUP_TAG = '複合材_不適合その他区分';	
			END;
		END


		--再度、コードマスタを検索して、不適合詳細区分と不適合詳細区分名を取得する
		DECLARE curTB2 CURSOR FOR
		SELECT
		 ITEM_VALUE
		,ITEM_DISP
		,ADD_YMDHNS				--追加日時
		,ADD_SYAIN_ID			--追加社員ID
		,ADD_SYAIN_NAME			--追加社員名
		,UPD_YMDHNS				--更新日時
		,UPD_SYAIN_ID			--更新社員ID
		,UPD_SYAIN_NAME			--更新社員名
		,DEL_YMDHNS				--削除日時
		,DEL_SYAIN_ID			--削除社員ID
		,DEL_SYAIN_NAME			--削除社員名
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
			,@W_ADD_YMDHNS			--追加日時
			,@W_ADD_SYAIN_ID		--追加社員ID
			,@W_ADD_SYAIN_NAME		--追加社員名
			,@W_UPD_YMDHNS			--更新日時
			,@W_UPD_SYAIN_ID		--更新社員ID
			,@W_UPD_SYAIN_NAME		--更新社員名
			,@W_DEL_YMDHNS			--削除日時
			,@W_DEL_SYAIN_ID		--削除社員ID
			,@W_DEL_SYAIN_NAME		--削除社員名
			;

			IF @@FETCH_STATUS <> 0
			BEGIN
				BREAK;
			END

			INSERT INTO @retTBL 
				(
				 SEIHIN_KB				--製品区分（部門区分）
				,SEIHIN_KB_NAME			--製品区分名（部門区分名）
				,FUTEKIGO_KB			--不適合区分
				,FUTEKIGO_KB_NAME		--不適合区分名
				,FUTEKIGO_S_KB			--不適合詳細区分
				,FUTEKIGO_S_KB_NAME		--不適合詳細区分名
				,ADD_YMDHNS				--追加日時
				,ADD_SYAIN_ID			--追加社員ID
				,ADD_SYAIN_NAME			--追加社員名
				,UPD_YMDHNS				--更新日時
				,UPD_SYAIN_ID			--更新社員ID
				,UPD_SYAIN_NAME			--更新社員名
				,DEL_YMDHNS				--削除日時
				,DEL_SYAIN_ID			--削除社員ID
				,DEL_SYAIN_NAME			--削除社員名
				) VALUES (
				  @W_SEIHIN_KB			--製品区分（部門区分）
				, @W_SEIHIN_KB_NAME		--製品区分名（部門区分名）
				, @W_FUTEKIGO_KB		--不適合区分
				, @W_FUTEKIGO_KB_NAME	--不適合区分名
				, @W_FUTEKIGO_S_KB		--不適合詳細区分
				, @W_FUTEKIGO_S_KB_NAME	--不適合詳細区分名
				, @W_ADD_YMDHNS			--追加日時
				, @W_ADD_SYAIN_ID		--追加社員ID
				, @W_ADD_SYAIN_NAME		--追加社員名
				, @W_UPD_YMDHNS			--更新日時
				, @W_UPD_SYAIN_ID		--更新社員ID
				, @W_UPD_SYAIN_NAME		--更新社員名
				, @W_DEL_YMDHNS			--削除日時
				, @W_DEL_SYAIN_ID		--削除社員ID
				, @W_DEL_SYAIN_NAME		--削除社員名
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


