Imports System
Imports System.Collections.Generic
Imports System.ComponentModel.DataAnnotations
Imports System.ComponentModel.DataAnnotations.Schema
Imports System.Data.Entity.Spatial

''' <summary>
''' TV01 �s�K���񍐏��ꗗ �e�[�u���l�֐�
''' </summary>
Partial Public Class TV01_FUTEKIGO_ICHIRAN

    <Key>
    <Column(Order:=0)>
    <StringLength(10)>
    <ComponentModel.DisplayName("�񍐏�No")>
    Public Property HOKOKUSYO_NO As String

    <Key>
    <Column(Order:=1)>
    <StringLength(1)>
    <Display(AutoGenerateField:=False)>
    <ComponentModel.DisplayName("�N���[�Y�t���O")>
    Public Property CLOSE_FLG As String

    <Key>
    <Column(Order:=2)>
    <ComponentModel.DisplayName("���F��")>
    <Display(AutoGenerateField:=False)>
    Public Property SYONIN_JUN As Integer

    <Key>
    <Column(Order:=3)>
    <StringLength(50)>
    <ComponentModel.DisplayName("���F���e��")>
    <Display(AutoGenerateField:=False)>
    Public Property SYONIN_NAIYO As String

    <Key>
    <Column(Order:=4)>
    <ComponentModel.DisplayName("���F�񍐏�ID")>
    <Display(AutoGenerateField:=False)>
    Public Property SYONIN_HOKOKUSYO_ID As Integer

    <Key>
    <Column(Order:=5)>
    <StringLength(50)>
    <ComponentModel.DisplayName("�X�e�[�W")>
    Public Property SYONIN_HOKOKUSYO_NAME As String '�񍐏���

    <Key>
    <Column(Order:=6)>
    <StringLength(10)>
    <ComponentModel.DisplayName("��ޗ���")>
    Public Property SYONIN_HOKOKUSYO_R_NAME As String '�񍐏�����

    <Key>
    <Column(Order:=7)>
    <ComponentModel.DisplayName("���u�S���ҎЈ�ID")>
    <Display(AutoGenerateField:=False)>
    Public Property SYOCHI_SYAIN_ID As Integer

    <Key>
    <Column(Order:=8)>
    <StringLength(30)>
    <ComponentModel.DisplayName("���u�S���Җ�")>
    Public Property SYOCHI_SYAIN_NAME As String

    <Key>
    <Column(Order:=9)>
    <ComponentModel.DisplayName("�ؗ�����")>
    Public Property TAIRYU As Integer

    <Key>
    <Column(Order:=10)>
    <ComponentModel.DisplayName("�@��ID")>
    <Display(AutoGenerateField:=False)>
    Public Property KISYU_ID As Integer

    <Key>
    <Column(Order:=11)>
    <StringLength(100)>
    <ComponentModel.DisplayName("�@��")>
    <Display(AutoGenerateField:=False)>
    Public Property KISYU As String

    <Key>
    <Column(Order:=12)>
    <StringLength(100)>
    <ComponentModel.DisplayName("�@��")>
    Public Property KISYU_NAME As String '�@�햼

    <Key>
    <Column(Order:=13)>
    <StringLength(60)>
    <ComponentModel.DisplayName("���i�ԍ�")>
    Public Property BUHIN_BANGO As String

    <Key>
    <Column(Order:=14)>
    <StringLength(100)>
    <ComponentModel.DisplayName("�i��")>
    Public Property BUHIN_NAME As String '���i��

    <Key>
    <Column(Order:=15)>
    <StringLength(1)>
    <ComponentModel.DisplayName("���O����敪")>
    <Display(AutoGenerateField:=False)>
    Public Property JIZEN_SINSA_HANTEI_KB As String

    <Key>
    <Column(Order:=16)>
    <StringLength(50)>
    <ComponentModel.DisplayName("���O����敪")>
    Public Property JIZEN_SINSA_HANTEI_KB_DISP As String

    <Key>
    <Column(Order:=17)>
    <StringLength(1)>
    <ComponentModel.DisplayName("�ĐR����敪")>
    <Display(AutoGenerateField:=False)>
    Public Property SAISIN_IINKAI_HANTEI_KB As String

    <Key>
    <Column(Order:=18)>
    <StringLength(50)>
    <ComponentModel.DisplayName("�ĐR����敪")>
    Public Property SAISIN_IINKAI_HANTEI_KB_DISP As String


    <StringLength(8)>
    <NotMapped>
    <ComponentModel.DisplayName("�N����")>
    <Display(AutoGenerateField:=False)>
    Public Property _ADD_YMD As String

    <Key>
    <Column(Order:=19)>
    <ComponentModel.DisplayName("�N����")>
    Public Property ADD_YMD As Date
        Get
            Return DateTime.ParseExact(_ADD_YMD, "yyyyMMdd", Nothing)
        End Get
        Set(value As Date)

            _ADD_YMD = value.ToString("yyyyMMdd")
        End Set
    End Property

    <StringLength(8)>
    <NotMapped>
    <ComponentModel.DisplayName("�O���u���{��")>
    <Display(AutoGenerateField:=False)>
    Public Property _SYOCHI_YMD As String

    <Key>
    <Column(Order:=20)>
    <ComponentModel.DisplayName("�O���u���{��")>
    Public Property SYOCHI_YMD As Date
        Get
            Return DateTime.ParseExact(_SYOCHI_YMD, "yyyyMMdd", Nothing)
        End Get
        Set(value As Date)

            _SYOCHI_YMD = value.ToString("yyyyMMdd")
        End Set
    End Property


End Class
