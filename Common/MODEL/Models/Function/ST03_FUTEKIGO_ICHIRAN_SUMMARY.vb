Imports System
Imports System.Collections.Generic
Imports System.ComponentModel.DataAnnotations
Imports System.ComponentModel.DataAnnotations.Schema
Imports System.Data.Entity.Spatial

''' <summary>
''' ST02 �s�K���񍐏��ꗗ �e�[�u���l�֐�
''' </summary>
Partial Public Class ST03_FUTEKIGO_ICHIRAN_SUMMARY
    Inherits MODEL.ModelBase
    Implements IDisposable

    Public Property SUMMARY_ROW_FLG As Integer

    <NotMapped>
    <ComponentModel.DisplayName("�I��")>
    Public Property SELECTED As Boolean

    <StringLength(1)>
    <ComponentModel.DisplayName("���i�敪")>
    Public Property BUMON_KB As String

    <StringLength(50)>
    <ComponentModel.DisplayName("���i�敪")>
    Public Property BUMON_NAME As String

    <Display(AutoGenerateField:=False)>
    <StringLength(10)>
    <ComponentModel.DisplayName("�񍐏�No")>
    Public Property HOKOKU_NO As String

    <Display(AutoGenerateField:=False)>
    <ComponentModel.DisplayName("���F��")>
    Public Property SYONIN_JUN As Integer

    <Display(AutoGenerateField:=False)>
    <StringLength(50)>
    <ComponentModel.DisplayName("�X�e�[�W")>
    Public Property SYONIN_NAIYO As String

    <ComponentModel.DisplayName("���F�񍐏�ID")>
    Public Property SYONIN_HOKOKUSYO_ID As Integer

    <Display(AutoGenerateField:=False)>
    <StringLength(50)>
    <ComponentModel.DisplayName("�񍐏���")>
    Public Property SYONIN_HOKOKUSYO_NAME As String '�񍐏���

    <StringLength(10)>
    <ComponentModel.DisplayName("��ޗ���")>
    Public Property SYONIN_HOKOKUSYO_R_NAME As String '�񍐏�����

    <Display(AutoGenerateField:=False)>
    <ComponentModel.DisplayName("���u�S���ҎЈ�ID")>
    Public Property GEN_TANTO_ID As Integer

    <Display(AutoGenerateField:=False)>
    <StringLength(30)>
    <ComponentModel.DisplayName("���u�S���Җ�")>
    Public Property GEN_TANTO_NAME As String

    <ComponentModel.DisplayName("���F����")>
    <Display(AutoGenerateField:=False)>
    <Column(NameOf(SYONIN_YMDHNS), TypeName:="String")>
    Public Property _SYONIN_YMDHNS As String

    <NotMapped>
    <Display(AutoGenerateField:=False)>
    <ComponentModel.DisplayName("���F����")>
    Public Property SYONIN_YMDHNS As DateTime
        Get
            Return DateTime.ParseExact(_SYONIN_YMDHNS, "yyyyMMddHHmmss", Nothing)
        End Get
        Set(value As DateTime)

            _SYONIN_YMDHNS = value.ToString("yyyyMMddHHmmss")
        End Set
    End Property

    <Display(AutoGenerateField:=False)>
    <ComponentModel.DisplayName("�ؗ�����")>
    Public Property TAIRYU_NISSU As Integer

    <Display(AutoGenerateField:=False)>
    <StringLength(1)>
    <ComponentModel.DisplayName("�ؗ��t���O")>
    Public Property TAIRYU_FG As String

    <Display(AutoGenerateField:=False)>
    <ComponentModel.DisplayName("�@��ID")>
    Public Property KISYU_ID As Integer

    '<StringLength(100)>
    '<ComponentModel.DisplayName("�@��")>
    'Public Property KISYU As String

    <StringLength(100)>
    <ComponentModel.DisplayName("�@��")>
    Public Property KISYU_NAME As String '�@�햼

    <StringLength(60)>
    <ComponentModel.DisplayName("���i�ԍ�")>
    Public Property BUHIN_BANGO As String

    <StringLength(100)>
    <ComponentModel.DisplayName("���i��")>
    Public Property BUHIN_NAME As String '���i��

    <StringLength(5)>
    <ComponentModel.DisplayName("���@")>
    Public Property GOKI As String

    <StringLength(10)>
    <ComponentModel.DisplayName("�Г��R�[�h")>
    Public Property SYANAI_CD As String

    <StringLength(2)>
    <ComponentModel.DisplayName("�s�K���敪")>
    Public Property FUTEKIGO_KB As String

    <StringLength(50)>
    <ComponentModel.DisplayName("�s�K���敪")>
    Public Property FUTEKIGO_NAME As String

    <StringLength(50)>
    <ComponentModel.DisplayName("�s�K���ڍ׋敪")>
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
    <ComponentModel.DisplayName("���O����敪")>
    Public Property JIZEN_SINSA_HANTEI_NAME As String

    <StringLength(1)>
    <ComponentModel.DisplayName("�������u�v�ۋ敪")>
    Public Property ZESEI_SYOCHI_YOHI_KB As String

    <StringLength(150)>
    <ComponentModel.DisplayName("�������u�v�ۋ敪")>
    Public Property ZESEI_SYOCHI_YOHI_NAME As String

    <StringLength(1)>
    <ComponentModel.DisplayName("�ĐR�ψ����敪")>
    Public Property SAISIN_IINKAI_HANTEI_KB As String

    <StringLength(50)>
    <ComponentModel.DisplayName("�ĐR�ψ����敪")>
    Public Property SAISIN_IINKAI_HANTEI_NAME As String

    <StringLength(1)>
    <ComponentModel.DisplayName("�������ʋ敪")>
    Public Property KENSA_KEKKA_KB As String

    <StringLength(50)>
    <ComponentModel.DisplayName("�������ʋ敪")>
    Public Property KENSA_KEKKA_NAME As String

    <StringLength(1)>
    <ComponentModel.DisplayName("���{�v���敪1")>
    Public Property KONPON_YOIN_KB1 As String

    <StringLength(50)>
    <ComponentModel.DisplayName("���{�v���敪1")>
    Public Property KONPON_YOIN_NAME As String

    <StringLength(50)>
    <ComponentModel.DisplayName("���{�v���敪2")>
    Public Property KONPON_YOIN_NAME2 As String

    <StringLength(50)>
    <ComponentModel.DisplayName("����")>
    Public Property GENIN_BUNSEKI_NAME As String

    <StringLength(1)>
    <ComponentModel.DisplayName("�A�ӍH���敪")>
    Public Property KISEKI_KOTEI_KB As String

    <StringLength(50)>
    <ComponentModel.DisplayName("�A�ӍH���敪��")>
    Public Property KISEKI_KOTEI_NAME As String

    <ComponentModel.DisplayName("�N����")>
    <Display(AutoGenerateField:=False)>
    <Column(NameOf(KISO_YMD), TypeName:="String")>
    Public Property _KISO_YMD As String

    <NotMapped>
    <ComponentModel.DisplayName("�N����")>
    Public Property KISO_YMD As Date
        Get
            Return DateTime.ParseExact(_KISO_YMD, "yyyyMMdd", Nothing)
        End Get
        Set(value As Date)

            _KISO_YMD = value.ToString("yyyyMMdd")
        End Set
    End Property

    <ComponentModel.DisplayName("�N���S����ID")>
    Public Property KISO_TANTO_ID As Integer

    <StringLength(30)>
    <ComponentModel.DisplayName("�N���S���Җ�")>
    Public Property KISO_TANTO_NAME As String

    <StringLength(1)>
    <ComponentModel.DisplayName("�N���[�Y�t���O")>
    Public Property CLOSE_FG As String

    <ComponentModel.DisplayName("���ߌ����F��")>
    Public Property SASIMOTO_SYONIN_JUN As Integer

    <StringLength(50)>
    <ComponentModel.DisplayName("���ߌ����F���e")>
    Public Property SASIMOTO_SYONIN_NAIYO As String

    <StringLength(100)>
    <ComponentModel.DisplayName("���ߗ��R")>
    Public Property RIYU As String

    <StringLength(500)>
    <ComponentModel.DisplayName("�v�����e")>
    Public Property YOKYU_NAIYO As String

    <StringLength(2)>
    <ComponentModel.DisplayName("�ڋq����w���敪")>
    Public Property KOKYAKU_HANTEI_SIJI_KB As String

    <StringLength(150)>
    <ComponentModel.DisplayName("�ڋq����w���敪")>
    Public Property KOKYAKU_HANTEI_SIJI_NAME As String

    <StringLength(2)>
    <ComponentModel.DisplayName("�ڋq�ŏI����敪")>
    Public Property KOKYAKU_SAISYU_HANTEI_KB As String

    <StringLength(150)>
    <ComponentModel.DisplayName("�ڋq�ŏI����敪")>
    Public Property KOKYAKU_SAISYU_HANTEI_NAME As String

    <StringLength(14)>
    <ComponentModel.DisplayName("�폜����")>
    Public Property DEL_YMDHNS As String

    <ComponentModel.DisplayName("���u�\���")>
    <Display(AutoGenerateField:=False)>
    <Column(NameOf(SYOCHI_YOTEI_YMD), TypeName:="String")>
    Public Property _SYOCHI_YOTEI_YMD As String

    <NotMapped>
    <ComponentModel.DisplayName("���u�\���")>
    Public Property SYOCHI_YOTEI_YMD As Date
        Get
            Return DateTime.ParseExact(_SYOCHI_YOTEI_YMD, "yyyyMMdd", Nothing)
        End Get
        Set(value As Date)

            _SYOCHI_YOTEI_YMD = value.ToString("yyyyMMdd")
        End Set
    End Property

    <Display(AutoGenerateField:=False)>
    <StringLength(8)>
    <Column(NameOf(HASSEI_YMD), TypeName:="String")>
    <ComponentModel.DisplayName("������")>
    Public Property _HASSEI_YMD As String

    <NotMapped>
    <ComponentModel.DisplayName("������")>
    Public Property HASSEI_YMD As String
        Get
            Return DateTime.ParseExact(_HASSEI_YMD, "yyyyMMdd", Nothing).ToString("yyyy/MM/dd")
        End Get
        Set(value As String)

            _HASSEI_YMD = value '.ToString("yyyyMMdd")
        End Set
    End Property

    '�W�v����------------------------------------------------
    <ComponentModel.DisplayName("��")>
    Public Property SURYO As Integer

    <ComponentModel.DisplayName("�N������")>
    Public Property KISO_KENSU As Integer

    <ComponentModel.DisplayName("���u����")>
    Public Property SYOCHI_KENSU As Integer

    <ComponentModel.DisplayName("���u�c")>
    Public Property SYOCHI_ZANSU As Integer

#Region "IDisposable Support"

    Private disposedValue As Boolean ' �d������Ăяo�������o����ɂ�

    ' IDisposable
    Protected Overridable Sub Dispose(disposing As Boolean)
        If Not disposedValue Then
            If disposing Then
                ' TODO: �}�l�[�W�h��Ԃ�j�����܂� (�}�l�[�W�h �I�u�W�F�N�g)�B
            End If

            ' TODO: �A���}�l�[�W�h ���\�[�X (�A���}�l�[�W�h �I�u�W�F�N�g) ��������A���� Finalize() ���I�[�o�[���C�h���܂��B
            ' TODO: �傫�ȃt�B�[���h�� null �ɐݒ肵�܂��B
        End If
        disposedValue = True
    End Sub

    ' TODO: ��� Dispose(disposing As Boolean) �ɃA���}�l�[�W�h ���\�[�X���������R�[�h���܂܂��ꍇ�ɂ̂� Finalize() ���I�[�o�[���C�h���܂��B
    'Protected Overrides Sub Finalize()
    '    ' ���̃R�[�h��ύX���Ȃ��ł��������B�N���[���A�b�v �R�[�h����� Dispose(disposing As Boolean) �ɋL�q���܂��B
    '    Dispose(False)
    '    MyBase.Finalize()
    'End Sub

    ' ���̃R�[�h�́A�j���\�ȃp�^�[���𐳂��������ł���悤�� Visual Basic �ɂ���Ēǉ�����܂����B
    Public Sub Dispose() Implements IDisposable.Dispose
        ' ���̃R�[�h��ύX���Ȃ��ł��������B�N���[���A�b�v �R�[�h����� Dispose(disposing As Boolean) �ɋL�q���܂��B
        Dispose(True)
        ' TODO: ��� Finalize() ���I�[�o�[���C�h����Ă���ꍇ�́A���̍s�̃R�����g���������Ă��������B
        ' GC.SuppressFinalize(Me)
    End Sub

#End Region

End Class