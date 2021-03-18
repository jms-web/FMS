Imports System
Imports System.Collections.Generic
Imports System.ComponentModel.DataAnnotations
Imports System.ComponentModel.DataAnnotations.Schema
Imports System.Data.Entity.Spatial

''' <summary>
'''
''' </summary>
Partial Public Class ST04_FCCB_ICHIRAN
    Inherits MODEL.ModelBase

    <StringLength(1)>
    <ComponentModel.DisplayName("���i�敪")>
    Public Property BUMON_KB As String

    <StringLength(50)>
    <ComponentModel.DisplayName("���i�敪")>
    Public Property BUMON_NAME As String

    <StringLength(10)>
    <ComponentModel.DisplayName("�񍐏�No")>
    Public Property FCCB_NO As String

    <ComponentModel.DisplayName("���F��")>
    Public Property SYONIN_JUN As Integer

    <StringLength(50)>
    <ComponentModel.DisplayName("�X�e�[�W")>
    Public Property SYONIN_NAIYO As String

    <ComponentModel.DisplayName("���F�񍐏�ID")>
    Public Property SYONIN_HOKOKUSYO_ID As Integer

    <StringLength(50)>
    <ComponentModel.DisplayName("�񍐏���")>
    Public Property SYONIN_HOKOKUSYO_NAME As String '�񍐏���

    <StringLength(10)>
    <ComponentModel.DisplayName("��ޗ���")>
    Public Property SYONIN_HOKOKUSYO_R_NAME As String '�񍐏�����

    <ComponentModel.DisplayName("���u�S���ҎЈ�ID")>
    Public Property GEN_TANTO_ID As Integer

    <StringLength(30)>
    <ComponentModel.DisplayName("�ŏI�X�V��")>
    Public Property GEN_TANTO_NAME As String

    <ComponentModel.DisplayName("���F����")>
    Public Property SYONIN_YMDHNS As String

    <ComponentModel.DisplayName("�ؗ�����")>
    Public Property TAIRYU_NISSU As Integer

    <StringLength(1)>
    <ComponentModel.DisplayName("�ؗ��t���O")>
    Public Property TAIRYU_FG As String

    <ComponentModel.DisplayName("�@��ID")>
    <Display(AutoGenerateField:=False)>
    Public Property KISYU_ID As Integer

    <StringLength(100)>
    <ComponentModel.DisplayName("�@��")>
    Public Property KISYU_NAME As String '�@�햼

    <StringLength(60)>
    <ComponentModel.DisplayName("���i�ԍ�")>
    Public Property BUHIN_BANGO As String

    <StringLength(10)>
    <ComponentModel.DisplayName("�Г��R�[�h")>
    Public Property SYANAI_CD As String

    <StringLength(100)>
    <ComponentModel.DisplayName("���i��")>
    Public Property BUHIN_NAME As String '���i��

    <StringLength(100)>
    <ComponentModel.DisplayName("�����ԍ�")>
    Public Property SNO_APPLY_PERIOD_KISO As String '���i��

    <StringLength(100)>
    <ComponentModel.DisplayName("�����ԍ�")>
    Public Property INPUT_DOC_NO As String '���i��

    <StringLength(100)>
    <ComponentModel.DisplayName("���e")>
    Public Property INPUT_NAIYO As String '���i��

    <StringLength(100)>
    <ComponentModel.DisplayName("FCCB�c��")>
    Public Property CM_TANTO_NAME As String '���i��

    <ComponentModel.DisplayName("�N����")>
    Public Property KISO_YMD As String

    '<NotMapped>
    '<ComponentModel.DisplayName("�N����")>
    'Public Property KISO_YMD As Date
    '    Get
    '        Return DateTime.ParseExact(_KISO_YMD, "yyyyMMdd", Nothing)
    '    End Get
    '    Set(value As Date)

    '        _KISO_YMD = value.ToString("yyyyMMdd")
    '    End Set
    'End Property

    <ComponentModel.DisplayName("�N���S����ID")>
    Public Property KISO_TANTO_ID As Integer

    <StringLength(30)>
    <ComponentModel.DisplayName("�N���S���Җ�")>
    Public Property KISO_TANTO_NAME As String

    <StringLength(1)>
    <ComponentModel.DisplayName("�N���[�Y�t���O")>
    Public Property CLOSE_FG As String

    <StringLength(14)>
    <ComponentModel.DisplayName("�폜����")>
    Public Property DEL_YMDHNS As String

End Class