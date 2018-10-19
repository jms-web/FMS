USE [FMS]
GO

/****** Object:  UserDefinedFunction [dbo].[SC05_GET_FUTEKIGO_KB_DISP]    Script Date: 2018/10/11 14:40:30 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO



-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date, ,>
-- Description:	<Description, ,>
-- =============================================

ALTER function [dbo].[SC05_GET_FUTEKIGO_KB_DISP](
	@BUMON_KB char(1),
	@FUTEKIGO_KB char(1)) returns nvarchar(150)
AS
BEGIN
	
	DECLARE @TAG		nvarchar(10);
	DECLARE @ITEM_DISP  nvarchar(150);

	SET @ITEM_DISP = '';

	IF @BUMON_KB = '1'		--風防
	BEGIN
		SET @TAG = '風防_不適合区分';
	END
	ELSE IF @BUMON_KB = '3' --複合材	
	BEGIN
		SET @TAG = '複合材_不適合区分';
	END
	ELSE IF @BUMON_KB = '2' --LP	
	BEGIN
		SET @TAG = 'LP_不適合区分';
	END

	SELECT @ITEM_DISP = ITEM_DISP FROM M001_SETTING  WHERE ITEM_NAME = @TAG AND ITEM_VALUE = @FUTEKIGO_KB;

	RETURN @ITEM_DISP;

END


GO

