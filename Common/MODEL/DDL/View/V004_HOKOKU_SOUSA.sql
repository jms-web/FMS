USE [FMS]
GO

/****** Object:  View [dbo].[V004_HOKOKU_SOUSA]    Script Date: 2018/05/22 18:34:00 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO




ALTER VIEW [dbo].[V004_HOKOKU_SOUSA]
AS
SELECT 
 SYONIN_HOKOKUSYO_ID	--���F�񍐏�ID
,HOKOKU_NO				--�񍐏�No
,ADD_YMDHNS				--�ǉ�����
,SYONIN_JUN				--���F��
,isnull((SELECT SYONIN_NAIYO FROM M014_SYONIN_ROUT 
  WHERE 
      SYONIN_HOKOKUSYO_ID = R001.SYONIN_HOKOKUSYO_ID
  AND SYONIN_JUN		  = R001.SYONIN_JUN),'') AS SYONIN_NAIYO
,SOUSA_KB				--����敪
,isnull((SELECT ITEM_DISP FROM M001_SETTING WHERE ITEM_NAME = '����敪' AND ITEM_VALUE=R001.SOUSA_KB),'') AS SOUSA_NAME		--����敪��
,SYAIN_ID				--�Ј�ID
,isnull((SELECT SIMEI FROM M004_SYAIN AS M04 WHERE(M04.SYAIN_ID = R001.SYAIN_ID)),'') AS SYAIN_NAME
,SYONIN_HANTEI_KB		--���F����敪
,isnull((SELECT ITEM_DISP FROM M001_SETTING WHERE ITEM_NAME = '���F����敪' AND ITEM_VALUE=R001.SYONIN_HANTEI_KB),'') AS SYONIN_HANTEI_NAME		--���F����敪��
,RIYU					--���R
FROM
	R001_HOKOKU_SOUSA AS R001
		  
GO

