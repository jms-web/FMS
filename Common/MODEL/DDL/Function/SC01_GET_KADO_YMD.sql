-- ================================================
-- Template generated from Template Explorer using:
-- Create Scalar Function (New Menu).SQL
--
-- Use the Specify Values for Template Parameters 
-- command (Ctrl-Shift-M) to fill in the parameter 
-- values below.
--
-- This block of comments will not be included in
-- the definition of the function.
-- ================================================
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date, ,>
-- Description:	<Description, ,>
-- =============================================

create function [dbo].[SC01_GET_KADO_YMD](
	@YYYYMMDD char(8),
	@wkSA numeric) returns char(8)
AS
BEGIN

 DECLARE @wkYYYYMMDD char(8);
 --DECLARE @wkSA numeric;

 -----��0��
 IF @wkSA =0
  RETURN @YYYYMMDD;

 -----���v���X��
 IF @wkSA >0
  BEGIN
   -----�ғ��}�X�^
   DECLARE curTB CURSOR FOR
    SELECT YMD FROM M006_CALENDAR
     WHERE YMD > @YYYYMMDD
     AND KADO_KB = '1' --1:�ғ�
     ORDER BY YMD;
  
   OPEN curTB;
   FETCH NEXT FROM curTB INTO @wkYYYYMMDD;
  
   WHILE @@FETCH_STATUS = 0
    BEGIN
     SET @wkSA = @wkSA -1;
     IF @wkSA =0 BREAK;
  
     FETCH NEXT FROM curTB INTO @wkYYYYMMDD;
    END
  
   CLOSE curTB;
   DEALLOCATE curTB;
  END

 -----���}�C�i�X��
 IF @wkSA <0
  BEGIN
   -----�ғ��}�X�^
   DECLARE curTB CURSOR FOR
    SELECT YMD FROM M006_CALENDAR
     WHERE YMD < @YYYYMMDD
     AND KADO_KB = '1' --1:�ғ�
     ORDER BY YMD DESC;
  
   OPEN curTB;
   FETCH NEXT FROM curTB INTO @wkYYYYMMDD;
  
   WHILE @@FETCH_STATUS = 0
    BEGIN
     SET @wkSA = @wkSA +1;
     IF @wkSA =0 BREAK;
  
     FETCH NEXT FROM curTB INTO @wkYYYYMMDD;
    END
  
   CLOSE curTB;
   DEALLOCATE curTB;
  END

 -----�擾�s����
 IF @wkSA !=0
  SET @wkYYYYMMDD='';


  return @wkYYYYMMDD;

END


GO




