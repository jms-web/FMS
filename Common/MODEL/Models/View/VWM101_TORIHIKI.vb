Imports System
Imports System.Collections.Generic
Imports System.ComponentModel.DataAnnotations
Imports System.ComponentModel.DataAnnotations.Schema
Imports System.Data.Entity.Spatial
Imports PropertyChanged

<AddINotifyPropertyChangedInterface>
Partial Public Class VWM101_TORIHIKI
    Inherits ModelBase
    Implements IDisposable


    <ComponentModel.DisplayName("�����ID")>
    Public Property TORI_ID As Integer

    <ComponentModel.DisplayName("����於")>
    Public Property TORI_NAME As String

    <ComponentModel.DisplayName("����敪")>
    Public Property TORI_KB As String

    <ComponentModel.DisplayName("����敪")>
    Public Property TORI_KB_DISP As String

    <ComponentModel.DisplayName("�X�֔ԍ�")>
    Public Property POST As String

    <ComponentModel.DisplayName("�Z��1")>
    Public Property ADD1 As String

    <ComponentModel.DisplayName("�Z��2")>
    Public Property ADD2 As String

    <ComponentModel.DisplayName("�Z��3")>
    Public Property ADD3 As String

    <Phone>
    <ComponentModel.DisplayName("TEL")>
    Public Property TEL As String

    <Phone>
    <ComponentModel.DisplayName("FAX")>
    Public Property FAX As String


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
