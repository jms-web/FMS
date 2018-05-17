Imports System
Imports System.Collections.Generic
Imports System.ComponentModel.DataAnnotations
Imports System.ComponentModel.DataAnnotations.Schema
Imports System.Data.Entity.Spatial

''' <summary>
''' ST02 �s�K���񍐏��ꗗ �e�[�u���l�֐�
''' </summary>
Partial Public Class ST02_FUTEKIGO_ICHIRAN

    <NotMapped>
    <ComponentModel.DisplayName("�I��")>
    Public Property SELECTED As Boolean

    <StringLength(10)>
    <ComponentModel.DisplayName("�񍐏�No")>
    Public Property HOKOKU_NO As String

    <ComponentModel.DisplayName("���F��")>
    Public Property SYONIN_JUN As Integer

    <StringLength(50)>
    <ComponentModel.DisplayName("�X�e�[�W")>
    Public Property SYONIN_NAIYO As String

    <ComponentModel.DisplayName("���F�񍐏�ID")>
    <Display(AutoGenerateField:=False)>
    Public Property SYONIN_HOKOKUSYO_ID As Integer

    <StringLength(50)>
    <ComponentModel.DisplayName("�񍐏���")>
    Public Property SYONIN_HOKOKUSYO_NAME As String '�񍐏���

    <StringLength(10)>
    <ComponentModel.DisplayName("��ޗ���")>
    Public Property SYONIN_HOKOKUSYO_R_NAME As String '�񍐏�����

    <ComponentModel.DisplayName("���u�S���ҎЈ�ID")>
    <Display(AutoGenerateField:=False)>
    Public Property GEN_TANTO_ID As Integer

    <StringLength(30)>
    <ComponentModel.DisplayName("���u�S���Җ�")>
    Public Property GEN_TANTO_NAME As String

    <StringLength(14)>
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
    Public Property KISYU As String

    <StringLength(100)>
    <ComponentModel.DisplayName("�@��")>
    Public Property KISYU_NAME As String '�@�햼

    <StringLength(60)>
    <ComponentModel.DisplayName("���i�ԍ�")>
    Public Property BUHIN_BANGO As String

    <StringLength(100)>
    <ComponentModel.DisplayName("�i��")>
    Public Property BUHIN_NAME As String '���i��

    <StringLength(5)>
    <ComponentModel.DisplayName("���@")>
    Public Property GOKI As String

    <StringLength(10)>
    <ComponentModel.DisplayName("���@")>
    Public Property SYANAI_CD As String

    <StringLength(2)>
    <ComponentModel.DisplayName("�s�K���敪")>
    Public Property FUTEKIGO_KB As String

    <StringLength(50)>
    <ComponentModel.DisplayName("�s�K���敪��")>
    Public Property FUTEKIGO_NAME As String

    <StringLength(50)>
    <ComponentModel.DisplayName("�s�K���ڍ׋敪��")>
    Public Property FUTEKIGO_S_NAME As String

    <StringLength(2)>
    <ComponentModel.DisplayName("�s�K���ڍ׋敪")>
    Public Property FUTEKIGO_S_KB As String

    <StringLength(2)>
    <ComponentModel.DisplayName("�s�K����ԋ敪")>
    Public Property FUTEKIGO_JYOTAI_KB As String

    <StringLength(2)>
    <ComponentModel.DisplayName("�s�K����ԋ敪")>
    Public Property FUTEKIGO_JYOTAI_NAME As String

    <StringLength(1)>
    <ComponentModel.DisplayName("���O����敪")>
    Public Property JIZEN_SINSA_HANTEI_KB As String

    <StringLength(50)>
    <ComponentModel.DisplayName("���O����敪��")>
    Public Property JIZEN_SINSA_HANTEI_KB_NAME As String

    <StringLength(1)>
    <ComponentModel.DisplayName("�������u�v�ۋ敪")>
    Public Property ZESEI_SYOCHI_YOHI_KB As String

    <StringLength(150)>
    <ComponentModel.DisplayName("�������u�v�ۋ敪��")>
    Public Property ZESEI_SYOCHI_YOHI_KB_NAME As String






    <StringLength(1)>
    <ComponentModel.DisplayName("�ĐR����敪")>
    Public Property SAISIN_IINKAI_HANTEI_KB As String

    <StringLength(50)>
    <ComponentModel.DisplayName("�ĐR����敪")>
    Public Property SAISIN_IINKAI_HANTEI_KB_DISP As String

    <ComponentModel.DisplayName("�N����")>
    <Display(AutoGenerateField:=False)>
    <Column(NameOf(ADD_YMD), Order:=19, TypeName:="String")>
    Public Property _ADD_YMD As String

    <NotMapped>
    <ComponentModel.DisplayName("�N����")>
    Public Property ADD_YMD As Date
        Get
            Return DateTime.ParseExact(_ADD_YMD, "yyyyMMdd", Nothing)
        End Get
        Set(value As Date)

            _ADD_YMD = value.ToString("yyyyMMdd")
        End Set
    End Property

    <StringLength(1)>
    <ComponentModel.DisplayName("�N���[�Y�t���O")>
    Public Property CLOSE_FG As String

    <StringLength(8)>
    <ComponentModel.DisplayName("�O���u���{��")>
    <Display(AutoGenerateField:=False)>
    Public Property _SYOCHI_YMD As String

    <NotMapped>
    <ComponentModel.DisplayName("�O���u���{��")>
    Public Property SYOCHI_YMD As Date
        Get
            Return DateTime.ParseExact(_SYOCHI_YMD, "yyyyMMdd", Nothing)
        End Get
        Set(value As Date)

            _SYOCHI_YMD = value.ToString("yyyyMMdd")
        End Set
    End Property

    <ComponentModel.DisplayName("���ߌ����F��")>
    Public Property MODOSI_SYONIN_JUN As Integer

    <StringLength(50)>
    <ComponentModel.DisplayName("���ߌ����F��")>
    Public Property MODOSI_SYONIN_NAIYO As String




End Class
