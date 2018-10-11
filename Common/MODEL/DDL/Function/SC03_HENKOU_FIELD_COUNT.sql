USE [FMS]
GO

/****** Object:  UserDefinedFunction [dbo].[SC03_HENKOU_FIELD_COUNT]    Script Date: 2018/10/11 14:40:12 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO




-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date, ,>
-- Description:	<Description, ,>
-- =============================================

ALTER function [dbo].[SC03_HENKOU_FIELD_COUNT](
	 @SASIMODOSI_YMDHNS		char(14)	--差戻日時
	,@SYONIN_HOKOKUSYO_ID	int			--承認報告書ID
	,@HOKOKUSYO_NO			char(10)	--報告書No
	) returns int
AS
BEGIN
	
	DECLARE @wkCOUNT int;
	SET @wkCOUNT = 0;
			
	SELECT @wkCOUNT =  COUNT(*) 
	FROM TV01_HENKO_HIKAKU(@SASIMODOSI_YMDHNS,@SYONIN_HOKOKUSYO_ID,@HOKOKUSYO_NO)
	
	RETURN @wkCOUNT;

END


GO

