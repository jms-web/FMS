Imports System
Imports System.Collections.Generic
Imports System.ComponentModel.DataAnnotations
Imports System.ComponentModel.DataAnnotations.Schema
Imports System.Data.Entity.Spatial

''' <summary>
''' TV01 �s�K���񍐏��ꗗ �e�[�u���l�֐�
''' </summary>
Partial Public Class TV01_FUTEKIGO_ICHIRAN

    <NotMapped>
    <ComponentModel.DisplayName("�I��")>
    Public Property SELECTED As Boolean

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
    <ComponentModel.DisplayName("�X�e�[�W")>
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
    <ComponentModel.DisplayName("�񍐏���")>
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
    Public Property SAISIN_IINKAI_HANTEI_KB As String

    <Key>
    <Column(Order:=18)>
    <StringLength(50)>
    <ComponentModel.DisplayName("�ĐR����敪")>
    Public Property SAISIN_IINKAI_HANTEI_KB_DISP As String

    <Key>
    <StringLength(8)>
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

    <Key>
    <Column(NameOf(SYOCHI_YMD), Order:=20, TypeName:="String")>
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

    <Key>
    <Column(Order:=21)>
    <ComponentModel.DisplayName("���ߌ����F��")>
    Public Property MODOSI_SYONIN_JUN As Integer

    <Key>
    <Column(Order:=22, TypeName:="nvarchar")>
    <StringLength(50)>
    <ComponentModel.DisplayName("���ߌ����F��")>
    Public Property MODOSI_SYONIN_NAIYO As Integer

    <Key>
    <Column(Order:=23, TypeName:="nvarchar")>
    <StringLength(100)>
    <ComponentModel.DisplayName("���ߌ����F��")>
    Public Property MODOSI_RIYU As Integer

    <Key>
    <Column(Order:=24)>
    <ComponentModel.DisplayName("���ߌ����F��")>
    Public Property MODOSI_TAIRYU As Integer
End Class
