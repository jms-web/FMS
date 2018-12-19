Imports System
Imports System.Collections.Generic
Imports System.ComponentModel.DataAnnotations
Imports System.ComponentModel.DataAnnotations.Schema
Imports System.Data.Entity.Spatial
Imports PropertyChanged

<AddINotifyPropertyChangedInterface>
Partial Public Class VWM004_SYAIN
    Inherits ModelBase
    Implements IDisposable

    <Key>
    <Column(Order:=0)>
    <ComponentModel.DisplayName("�Ј�ID")>
    Public Property SYAIN_ID As Integer

    <Key>
    <Column(Order:=1)>
    <StringLength(8)>
    <ComponentModel.DisplayName("�Ј�NO")>
    Public Property SYAIN_NO As String

    <Key>
    <Column(Order:=2)>
    <StringLength(30)>
    <ComponentModel.DisplayName("����")>
    Public Property SIMEI As String

    <Key>
    <Column(Order:=3)>
    <StringLength(60)>
    <ComponentModel.DisplayName("�����J�i")>
    Public Property SIMEI_KANA As String

    <Key>
    <Column(Order:=4)>
    <StringLength(2)>
    <ComponentModel.DisplayName("�Ј��敪")>
    Public Property SYAIN_KB As String

    <StringLength(150)>
    <ComponentModel.DisplayName("�Ј��敪")>
    Public Property SYAIN_KB_DISP As String

    <Key>
    <Column(Order:=5)>
    <StringLength(2)>
    <ComponentModel.DisplayName("��E�敪")>
    Public Property YAKUSYOKU_KB As String

    <StringLength(150)>
    <ComponentModel.DisplayName("��E�敪")>
    Public Property YAKUSYOKU_KB_DISP As String

    <Key>
    <Column(Order:=6)>
    <StringLength(2)>
    <ComponentModel.DisplayName("���F��s�敪")>
    Public Property DAIKO_KB As String

    <StringLength(150)>
    <ComponentModel.DisplayName("���F��s�敪")>
    Public Property DAIKO_KB_DISP As String

    <Key>
    <Column(Order:=7)>
    <StringLength(8)>
    <ComponentModel.DisplayName("���N����")>
    Public Property BIRTH_YMD As String

    <Key>
    <Column(Order:=8)>
    <StringLength(8000)>
    <ComponentModel.DisplayName("TEL")>
    Public Property TEL As String

    <Key>
    <Column(Order:=9)>
    <StringLength(8000)>
    <ComponentModel.DisplayName("���[���A�h���X")>
    Public Property MAIL_ADDRESS As String

    <Key>
    <Column(Order:=10)>
    <StringLength(8)>
    <ComponentModel.DisplayName("���ДN����")>
    Public Property NYUSYA_YMD As String

    <Key>
    <Column(Order:=11)>
    <StringLength(8)>
    <ComponentModel.DisplayName("�ގДN����")>
    Public Property TAISYA_YMD As String

    <Key>
    <Column(Order:=12)>
    <StringLength(8)>
    <ComponentModel.DisplayName("�p�X���[�h")>
    Public Property PASS As String

    <StringLength(1)>
    <ComponentModel.DisplayName("�^�p�Ǘ���")>
    Public Property ADMIN_OP As String

    '<Display(AutoGenerateField:=False)>
    'Public Property blnADMIN_OP As Boolean
    '    Get
    '        Return ADMIN_OP = "1"
    '    End Get
    '    Set(value As Boolean)
    '        ADMIN_OP = If(value, "1", "0")
    '    End Set
    'End Property


    <StringLength(1)>
    <ComponentModel.DisplayName("�V�X�e���Ǘ���")>
    Public Property ADMIN_SYS As String

    '<Display(AutoGenerateField:=False)>
    'Public Property blnADMIN_SYS As Boolean
    '    Get
    '        Return ADMIN_SYS = "1"
    '    End Get
    '    Set(value As Boolean)
    '        ADMIN_SYS = If(value, "1", "0")
    '    End Set
    'End Property

    <ComponentModel.DisplayName("�ǉ�����")>
    <DatabaseGenerated(DatabaseGeneratedOption.None)>
    Public Property ADD_YMDHNS As String

    <ComponentModel.DisplayName("�ǉ��S��ID")>
    <DatabaseGenerated(DatabaseGeneratedOption.None)>
    Public Property ADD_SYAIN_ID As Integer

    <ComponentModel.DisplayName("�ǉ��S����")>
    <DatabaseGenerated(DatabaseGeneratedOption.None)>
    Public Property ADD_SYAIN_NAME As String

    <ComponentModel.DisplayName("�X�V����")>
    <DatabaseGenerated(DatabaseGeneratedOption.None)>
    Public Property UPD_YMDHNS As String

    <ComponentModel.DisplayName("�X�V�S��ID")>
    <DatabaseGenerated(DatabaseGeneratedOption.None)>
    Public Property UPD_SYAIN_ID As Integer

    <ComponentModel.DisplayName("�X�V�S����")>
    <DatabaseGenerated(DatabaseGeneratedOption.None)>
    Public Property UPD_SYAIN_NAME As String

    <ComponentModel.DisplayName("�폜����")>
    <DatabaseGenerated(DatabaseGeneratedOption.None)>
    Public Property DEL_YMDHNS As String

    <ComponentModel.DisplayName("�폜�S��ID")>
    <DatabaseGenerated(DatabaseGeneratedOption.None)>
    Public Property DEL_SYAIN_ID As Integer

    <ComponentModel.DisplayName("�폜�S����")>
    <DatabaseGenerated(DatabaseGeneratedOption.None)>
    Public Property DEL_SYAIN_NAME As String


    <DoNotNotify>
    <ComponentModel.DisplayName("�폜�t���O")>
    <Display(AutoGenerateField:=False)>
    <NotMapped>
    Public ReadOnly Property DEL_FLG As Boolean
        Get
            Return Not String.IsNullOrWhiteSpace(DEL_YMDHNS)
        End Get
    End Property

#Region "IDisposable Support"
    Private disposedValue As Boolean ' �d������Ăяo�������o����ɂ�

    ' IDisposable
    Protected Overridable Sub Dispose(disposing As Boolean)
        If Not disposedValue Then
            If disposing Then
                ' TODO: �}�l�[�W��Ԃ�j�����܂� (�}�l�[�W �I�u�W�F�N�g)�B
            End If

            ' TODO: �A���}�l�[�W ���\�[�X (�A���}�l�[�W �I�u�W�F�N�g) ��������A���� Finalize() ���I�[�o�[���C�h���܂��B
            ' TODO: �傫�ȃt�B�[���h�� null �ɐݒ肵�܂��B
        End If
        disposedValue = True
    End Sub

    ' TODO: ��� Dispose(disposing As Boolean) �ɃA���}�l�[�W ���\�[�X���������R�[�h���܂܂��ꍇ�ɂ̂� Finalize() ���I�[�o�[���C�h���܂��B
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
