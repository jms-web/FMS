USE [FMS]
GO

/****** Object:  StoredProcedure [dbo].[ST01_GET_HOKOKU_NO]    Script Date: 2018/05/11 16:09:16 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO




ALTER PROCEDURE [dbo].[ST01_GET_HOKOKU_NO]
	@HOKOKU_NO VARCHAR(8) OUTPUT
	AS
	DECLARE @ErrorMessage varchar(4000);
	DECLARE @ErrorProcedure NVARCHAR(126)  

	DECLARE @wkSYS_YYYYMMDD CHAR(8);
	DECLARE @wkSYS_YYYY CHAR(4);
	DECLARE @wkSYS_MM CHAR(2);
	DECLARE @wkSYS_DD CHAR(2);

	DECLARE @wkHOKOKU_NO VARCHAR(8);

	DECLARE @W_YMD		char(8);  

BEGIN TRY

	BEGIN TRANSACTION

	--システム日付
	SET @wkSYS_YYYYMMDD = FORMAT(GETDATE(), 'yyyyMMdd');
	SET @wkSYS_YYYY = SUBSTRING(@wkSYS_YYYYMMDD, 1, 4);
	SET @wkSYS_MM =   SUBSTRING(@wkSYS_YYYYMMDD, 5, 2);
	SET @wkSYS_DD =   SUBSTRING(@wkSYS_YYYYMMDD, 7, 2);

	SET @wkHOKOKU_NO = '';

	SELECT @wkHOKOKU_NO = isnull(LTRIM(RTRIM(ITEM_VALUE)),'')  FROM M001_SETTING 
	WHERE ITEM_NAME = '報告書No管理'
	 
	IF @wkHOKOKU_NO = '' 
	BEGIN
		SET @HOKOKU_NO = @wkSYS_YYYY + '0010';
		INSERT INTO M001_SETTING
		(
		 [ITEM_NAME]	--1
		,[ITEM_VALUE]	--2
		,[ITEM_GROUP]	--3
		,[ITEM_DISP]	--4
		,[DISP_ORDER]	--5
		,[DEF_FLG]		--6
		,[BIKOU]		--7
		,[ADD_YMDHNS]	--8
		,[ADD_SYAIN_ID]	--9
		,[UPD_YMDHNS]	--10
		,[UPD_SYAIN_ID]	--11
		,[DEL_YMDHNS]	--12
		,[DEL_SYAIN_ID]	--13
		) VALUES (
		  '報告書No管理'				--1
		 ,@HOKOKU_NO					--2
		 ,'承認関連'					--3
		 ,'報告書の連番を管理する値'	--4
		 ,0								--5
		 ,'0'							--6
		 ,''							--7
		 ,FORMAT(GETDATE(), 'yyyyMMddHHmmss') --8
		 ,99999							--9
		 ,''							--10
		 ,0								--11
		 ,''							--12	
		 ,0								--13
		)
	END
	ELSE
	BEGIN
		IF SUBSTRING(@wkHOKOKU_NO,1,4) <> @wkSYS_YYYY
		BEGIN
			SET @HOKOKU_NO = @wkSYS_YYYY + '0010';	
		END
		ELSE
		BEGIN
			IF CONVERT(int,SUBSTRING(@wkHOKOKU_NO,5,4)) + 10 > 9999
			BEGIN
				SET @HOKOKU_NO = CONVERT(varchar,CONVERT(int,@wkSYS_YYYY) + 10) + '0010';
			END
			ELSE
			BEGIN
				SET @HOKOKU_NO = @wkSYS_YYYY + RIGHT('0000' + convert(varchar,CONVERT(int,SUBSTRING(@wkHOKOKU_NO,5,4)) + 10),4)
			END
		END
	
		UPDATE M001_SETTING SET ITEM_VALUE = @HOKOKU_NO
		WHERE 
		ITEM_NAME = '報告書No管理';

	END

	COMMIT TRANSACTION
	
	RETURN 0;

	END TRY

BEGIN CATCH
	SET @ErrorMessage = ERROR_MESSAGE()  
	SET @ErrorProcedure = ERROR_PROCEDURE() 
	EXECUTE [loopback].[FMS].[dbo].spERRLOG 0, 'ST01_GET_HOKOKU_NO',  @ErrorMessage

	ROLLBACK TRANSACTION
	RETURN -1;

END CATCH








GO


