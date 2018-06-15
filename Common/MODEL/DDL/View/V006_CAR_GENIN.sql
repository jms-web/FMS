USE [FMS]
GO

/****** Object:  View [dbo].[V006_CAR_GENIN]    Script Date: 2018/05/11 9:30:47 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO





ALTER VIEW [dbo].[V006_CAR_GENIN]
AS
SELECT 
 D006.HOKOKU_NO				--�񍐏�No
,D006.RENBAN				--�A��
,D006.GENIN_BUNSEKI_KB		--�������͋敪
,isnull((SELECT ITEM_DISP FROM M001_SETTING WHERE ITEM_NAME = '�������͋敪' AND ITEM_VALUE=D006.GENIN_BUNSEKI_KB),'') AS SOUSA_NAME		--�������͋敪��
,D006.GENIN_BUNSEKI_S_KB	--�������͏ڍ׋敪
,CASE D006.GENIN_BUNSEKI_KB
 WHEN '0'	--m-�}�l�W�����g
	THEN isnull((SELECT ITEM_DISP FROM M001_SETTING WHERE ITEM_NAME = 'm-SHELL_m�敪' AND ITEM_VALUE = D006.GENIN_BUNSEKI_S_KB),'')	 
 WHEN '1'	--S-�\�t�g�E�F�A
	THEN isnull((SELECT ITEM_DISP FROM M001_SETTING WHERE ITEM_NAME = 'm-SHELL_S�敪' AND ITEM_VALUE = D006.GENIN_BUNSEKI_S_KB),'')	 
 WHEN '2'	--h-�n�[�h�E�F�A
 	THEN isnull((SELECT ITEM_DISP FROM M001_SETTING WHERE ITEM_NAME = 'm-SHELL_H�敪' AND ITEM_VALUE = D006.GENIN_BUNSEKI_S_KB),'')	 
 WHEN '3'	--e-��Ɗ�
 	THEN isnull((SELECT ITEM_DISP FROM M001_SETTING WHERE ITEM_NAME = 'm-SHELL_E�敪' AND ITEM_VALUE = D006.GENIN_BUNSEKI_S_KB),'')	 
 WHEN '4'	--L1-�{�l
 	THEN isnull((SELECT ITEM_DISP FROM M001_SETTING WHERE ITEM_NAME = 'm-SHELL_L1�敪' AND ITEM_VALUE = D006.GENIN_BUNSEKI_S_KB),'')	 
 WHEN '5'	--L2-�֌W�ҁE�x���̐�
 	THEN isnull((SELECT ITEM_DISP FROM M001_SETTING WHERE ITEM_NAME = 'm-SHELL_L2�敪' AND ITEM_VALUE = D006.GENIN_BUNSEKI_S_KB),'')	 
 WHEN '11'	--�ޗ�
 	THEN isnull((SELECT ITEM_DISP FROM M001_SETTING WHERE ITEM_NAME = '�ޗ������敪' AND ITEM_VALUE = D006.GENIN_BUNSEKI_S_KB),'')	 
 WHEN '12'	--�ݔ��E����
 	THEN isnull((SELECT ITEM_DISP FROM M001_SETTING WHERE ITEM_NAME = '�ݔ�������敪' AND ITEM_VALUE = D006.GENIN_BUNSEKI_S_KB),'')	 
 WHEN '13'	--���@
 	THEN isnull((SELECT ITEM_DISP FROM M001_SETTING WHERE ITEM_NAME = '���@�����敪' AND ITEM_VALUE = D006.GENIN_BUNSEKI_S_KB),'')	 
 ELSE ' '
 END AS GENIN_BUNSEKI_NAME
,D006.DAIHYO_FG				--��\�t���O
,D006.ADD_SYAIN_ID			--�ǉ��Ј�ID
,isnull((SELECT SIMEI FROM M004_SYAIN AS M04 WHERE(M04.SYAIN_ID = D006.ADD_SYAIN_ID)),'') AS ADD_SYAIN_NAME
,D006.ADD_YMDHNS			--�ǉ�����
FROM
	D006_CAR_GENIN AS D006
		  
GO

