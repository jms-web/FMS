Imports System
Imports System.Collections.Generic
Imports System.ComponentModel.DataAnnotations
Imports System.ComponentModel.DataAnnotations.Schema
Imports System.Data.Entity.Spatial
Imports PropertyChanged

<AddINotifyPropertyChangedInterface>
Partial Public Class VWM002_BUSYO
    Inherits ModelBase
    Implements IDisposable

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

    <ComponentModel.DisplayName("�������Ј�NO")>
    Public Property SYOZOKUCYO_SYAIN_NO As String

    <ComponentModel.DisplayName("�������Ј���")>
    Public Property SYOZOKUCYO_SYAIN_NAME As String

    <ComponentModel.DisplayName("TEL")>
    Public Property TEL As String

    <ComponentModel.DisplayName("�ǉ�����")>
    <DatabaseGenerated(DatabaseGeneratedOption.None)>
    Public Property ADD_YMDHNS As String

    <ComponentModel.DisplayName("�ǉ��Ј�ID")>
    <DatabaseGenerated(DatabaseGeneratedOption.None)>
    Public Property ADD_SYAIN_ID As Integer

    <ComponentModel.DisplayName("�ǉ��Ј���")>
    <DatabaseGenerated(DatabaseGeneratedOption.None)>
    Public Property ADD_SYAIN_NAME As String

    <ComponentModel.DisplayName("�X�V����")>
    <DatabaseGenerated(DatabaseGeneratedOption.None)>
    Public Property UPD_YMDHNS As String

    <ComponentModel.DisplayName("�X�V�Ј�ID")>
    <DatabaseGenerated(DatabaseGeneratedOption.None)>
    Public Property UPD_SYAIN_ID As Integer

    <ComponentModel.DisplayName("�X�V�Ј���")>
    <DatabaseGenerated(DatabaseGeneratedOption.None)>
    Public Property UPD_SYAIN_NAME As String

    <ComponentModel.DisplayName("�폜����")>
    <DatabaseGenerated(DatabaseGeneratedOption.None)>
    Public Property DEL_YMDHNS As String

    <ComponentModel.DisplayName("�폜�Ј�ID")>
    <DatabaseGenerated(DatabaseGeneratedOption.None)>
    Public Property DEL_SYAIN_ID As Integer

    <ComponentModel.DisplayName("�폜�Ј���")>
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