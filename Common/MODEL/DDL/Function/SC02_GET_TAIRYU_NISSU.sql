USE [FMS]
GO

/****** Object:  UserDefinedFunction [dbo].[SC02_GET_TAIRYU_NISSU]    Script Date: 2018/05/21 22:58:17 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO


-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date, ,>
-- Description:	<Description, ,>
-- =============================================

ALTER function [dbo].[SC02_GET_TAIRYU_NISSU](
	@wMODE char(1),
	@YYYYMMDD1 char(8),
	@YYYYMMDD2 char(8)
	) returns int
AS
BEGIN

	DECLARE @wkSA int;

	SET @wkSA = 0;

	-----—ï“úƒ‚[ƒh‚ÌŽž
	IF @wMODE ='0'
	BEGIN
		SET @wkSA = DATEDIFF(day,CONVERT(DATETIME, @YYYYMMDD1),CONVERT(DATETIME, @YYYYMMDD2));
	END
	ELSE
	BEGIN
		SELECT @wkSA = COUNT(YMD) FROM M006_CALENDAR
		WHERE 
		    YMD > @YYYYMMDD1
		AND YMD<= @YYYYMMDD2
		AND KADO_KB = '1';
	END

	IF LTRIM(RTRIM(@YYYYMMDD1)) = ''
	BEGIN
		SET @wkSA = 0;
	END

  return @wkSA;

END


GO


