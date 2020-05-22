USE [FMS]
GO

/****** Object:  StoredProcedure [dbo].[ST01_GET_HOKOKU_NO]    Script Date: 2020/05/21 20:06:12 ******/
Set ANSI_NULLS On
GO

Set QUOTED_IDENTIFIER On
GO





CREATE PROCEDURE [dbo].[ST05_GET_FCCB_NO]
	@HOKOKU_NO VARCHAR(8) OUTPUT
	AS
	Declare @ErrorMessage varchar(4000);
	Declare @ErrorProcedure NVARCHAR(126)

Declare @wkSYS_YYYYMMDD CHAR(8);
	Declare @wkSYS_YYYY CHAR(4);
	Declare @wkSYS_MM CHAR(2);
	Declare @wkSYS_DD CHAR(2);

	Declare @wkHOKOKU_NO VARCHAR(8);

	Declare @W_YMD		char(8);  

BEGIN TRY

	BEGIN TRANSACTION

	--システム日付
	Set @wkSYS_YYYYMMDD = FORMAT(GETDATE(), 'yyyyMMdd');
	Set @wkSYS_YYYY = SUBSTRING(@wkSYS_YYYYMMDD, 1, 4);
	Set @wkSYS_MM =   SUBSTRING(@wkSYS_YYYYMMDD, 5, 2);
	Set @wkSYS_DD =   SUBSTRING(@wkSYS_YYYYMMDD, 7, 2);

	Set @wkHOKOKU_NO = '';

	Select Case@wkHOKOKU_NO = isnull(LTRIM(RTRIM(ITEM_VALUE)),'')  FROM M001_SETTING 
	WHERE ITEM_NAME = 'FCCB_NO管理'

If @wkHOKOKU_NO = '' 
	BEGIN
Set @HOKOKU_NO = @wkSYS_YYYY + '0010';
		INSERT INTO M001_SETTING
		(
		 [ITEM_NAME]    --1
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
		  'FCCB_NO管理'				--1
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
	End
Else
BEGIN
If SUBSTRING(@wkHOKOKU_NO, 1, 4) <> @wkSYS_YYYY
		BEGIN
Set @HOKOKU_NO = @wkSYS_YYYY + '0010';	
		End
Else
BEGIN
If CONVERT(int, SUBSTRING(@wkHOKOKU_NO, 5, 4)) + 10 > 9999
BEGIN
Set @HOKOKU_NO = CONVERT(varchar,CONVERT(int,@wkSYS_YYYY) + 10) + '0010';
			End
Else
BEGIN
Set @HOKOKU_NO = @wkSYS_YYYY + RIGHT('0000' + convert(varchar,CONVERT(int,SUBSTRING(@wkHOKOKU_NO,5,4)) + 10),4)
			End
End
	
		UPDATE M001_SETTING Set ITEM_VALUE = @HOKOKU_NO
		WHERE
ITEM_NAME = 'FCCB_NO管理';

End

	COMMIT TRANSACTION

Return 0;

	End Try

BEGIN CATCH
	Set @ErrorMessage = ERROR_MESSAGE()  
	Set @ErrorProcedure = ERROR_PROCEDURE() 
	EXECUTE [loopback].[FMS].[dbo].spERRLOG 0, 'ST01_GET_HOKOKU_NO',  @ErrorMessage

	ROLLBACK TRANSACTION
Return -1;

End Catch








GO


