USE [FMS]
GO

/****** Object:  View [dbo].[V001_SYONIN_TANTO]    Script Date: 2018/05/08 10:03:51 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO





ALTER VIEW [dbo].[V001_SYONIN_TANTO]
AS
SELECT
 M016.[SYONIN_HOKOKUSYO_ID]
,M013.SYONIN_HOKOKUSYO_NAME
,M016.[SYONIN_JUN]
,M014.SYONIN_NAIYO
,M016.[SYAIN_ID]
,(SELECT SIMEI FROM M004_SYAIN AS M004 WHERE(M016.[SYAIN_ID] = M004.SYAIN_ID)) AS SIMEI
,M016.[ADD_YMDHNS]
,M016.[ADD_SYAIN_ID]
,(SELECT SIMEI FROM M004_SYAIN AS M004 WHERE(M016.ADD_SYAIN_ID = M004.SYAIN_ID)) AS ADD_SYAIN_NAME
, '0' AS DEL_FLG
 
FROM
  M016_SYONIN_TANTO AS M016 INNER JOIN M013_SYONIN_HOKOKU M013 ON M016.SYONIN_HOKOKUSYO_ID = M013.SYONIN_HOKOKUSYO_ID
														INNER JOIN M014_SYONIN_ROUT M014 
														ON M016.SYONIN_HOKOKUSYO_ID = M014.SYONIN_HOKOKUSYO_ID
														AND M016.[SYONIN_JUN] = M014.SYONIN_JUN
  
GO


