Imports System
Imports System.Collections.Generic
Imports System.ComponentModel.DataAnnotations
Imports System.ComponentModel.DataAnnotations.Schema
Imports System.Data.Entity.Spatial

Partial Public Class VWM002_BUSYO

    <ComponentModel.DisplayName("����ID")>
    Public Property BUSYO_ID As Integer

    <ComponentModel.DisplayName("����敪")>
    Public Property BUMON_KB As String

    <ComponentModel.DisplayName("����")>
    Public Property BUMON_KB_NAME As String

    <ComponentModel.DisplayName("�L������")>
    Public Property YUKO_YMD As String

    <ComponentModel.DisplayName("�����敪")>
    Public Property BUSYO_KB As String

    <ComponentModel.DisplayName("�����敪��")>
    Public Property BUSYO_KB_NAME As String

    <ComponentModel.DisplayName("������")>
    Public Property BUSYO_NAME As String

    <ComponentModel.DisplayName("�e����ID")>
    Public Property OYA_BUSYO_ID As Integer

    <ComponentModel.DisplayName("�e�����敪")>
    Public Property OYA_BUSYO_KB As String

    <ComponentModel.DisplayName("�e������")>
    Public Property OYA_BUSYO_NAME As String

    <ComponentModel.DisplayName("�������Ј�ID")>
    Public Property SYOZOKUCYO_ID As Integer

    <ComponentModel.DisplayName("�������Ј���")>
    Public Property SYOZOKUCYO_SYAIN_NAME As String

    <ComponentModel.DisplayName("TEL")>
    Public Property TEL As String

    <ComponentModel.DisplayName("�ǉ�����")>
    Public Property ADD_YMDHNS As String

    <ComponentModel.DisplayName("�ǉ��Ј�ID")>
    Public Property ADD_SYAIN_ID As Integer

    <ComponentModel.DisplayName("�ǉ��Ј���")>
    Public Property ADD_SYAIN_NAME As String

    <ComponentModel.DisplayName("�X�V����")>
    Public Property UPD_YMDHNS As String

    <ComponentModel.DisplayName("�X�V�Ј�ID")>
    Public Property UPD_SYAIN_ID As Integer

    <ComponentModel.DisplayName("�X�V�Ј���")>
    Public Property UPD_SYAIN_NAME As String

    <ComponentModel.DisplayName("�폜����")>
    Public Property DEL_YMDHNS As String

    <ComponentModel.DisplayName("�폜�Ј�ID")>
    Public Property DEL_SYAIN_ID As Integer

    <ComponentModel.DisplayName("�폜�Ј���")>
    Public Property DEL_SYAIN_NAME As String

    <ComponentModel.DisplayName("�폜�t���O")>
    Public Property DEL_FLG As String

End Class
