Imports System.ComponentModel.DataAnnotations
Imports System.ComponentModel.DataAnnotations.Schema
Imports PropertyChanged

<AddINotifyPropertyChangedInterface>
Partial Public Class V003_SYONIN_J_KANRI
    Inherits ModelBase
    Implements IDisposable

    <ComponentModel.DisplayName("���F�񍐏�ID")>
    Public Property SYONIN_HOKOKUSYO_ID As Integer

    <ComponentModel.DisplayName("�񍐏�No")>
    Public Property HOKOKU_NO As String

    <ComponentModel.DisplayName("���F��")>
    Public Property SYONIN_JUN As Integer

    <ComponentModel.DisplayName("���F���e")>
    Public Property SYONIN_NAIYO As String

    <ComponentModel.DisplayName("�Ј�ID")>
    Public Property SYAIN_ID As Integer

    <ComponentModel.DisplayName("�ǉ��Ј���")>
    Public Property SYAIN_NAME As String

    <ComponentModel.DisplayName("���F����")>
    Public Property SYONIN_YMDHNS As String

    <ComponentModel.DisplayName("���F����敪")>
    Public Property SYONIN_HANTEI_KB As String

    <ComponentModel.DisplayName("���F����敪��")>
    Public Property SYONIN_HANTEI_NAME As String


    <Required>
    <StringLength(1)>
    <Column(NameOf(SASIMODOSI_FG), TypeName:="char")>
    <ComponentModel.DisplayName("���߃t���O")>
    Private Property _SASIMODOSI_FG As String

    <ComponentModel.DisplayName("���߃t���O")>
    <NotMapped>
    <DoNotNotify>
    Public Property SASIMODOSI_FG As Boolean
        Get
            Return (_SASIMODOSI_FG = "1")
        End Get
        Set(value As Boolean)
            _SASIMODOSI_FG = IIf(value, "1", "0")
        End Set
    End Property

    <ComponentModel.DisplayName("���R")>
    Public Property RIYU As String

    <ComponentModel.DisplayName("�R�����g")>
    Public Property COMMENT As String

    <Required>
    <StringLength(1)>
    <Column(NameOf(MAIL_SEND_FG), TypeName:="char")>
    <ComponentModel.DisplayName("���[�����M�t���O")>
    Private Property _MAIL_SEND_FG As String

    <ComponentModel.DisplayName("���[�����M�t���O")>
    <NotMapped>
    <DoNotNotify>
    Public Property MAIL_SEND_FG As Boolean
        Get
            Return (_MAIL_SEND_FG = "1")
        End Get
        Set(value As Boolean)
            _MAIL_SEND_FG = IIf(value, "1", "0")
        End Set
    End Property


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
