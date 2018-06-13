-- ================================================
-- Template generated from Template Explorer using:
-- Create Procedure (New Menu).SQL
--
-- Use the Specify Values for Template Parameters 
-- command (Ctrl-Shift-M) to fill in the parameter 
-- values below.
--
-- This block of comments will not be included in
-- the definition of the procedure.
-- ================================================
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
create PROCEDURE [dbo].[spERRLOG]
 @TANTO_CD numeric(5,0),
 @FUNC_NM NCHAR(20),
 @MSG NCHAR(256)
 AS

--BEGIN TRANSACTION;

INSERT INTO STB_ERRLOG (
 SYR_YMDHMS,
 PC_ID,
 SYAIN_ID,
 SYR_NM,
 RENBAN,
 ERR_KB,
 FUNC_NM,
 ERR_CD,
 MSG
 ) VALUES (
 CONVERT(VARCHAR,GETDATE(),112) + REPLACE(CONVERT(VARCHAR,GETDATE(),108),':',''),
 ' ',
 @TANTO_CD,
 ' ',
 0,
 ' ',
 @FUNC_NM,
 ' ',
 @MSG
 );

--COMMIT TRANSACTION;

 RETURN 0



