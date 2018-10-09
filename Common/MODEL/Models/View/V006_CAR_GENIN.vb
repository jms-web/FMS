Imports System
Imports System.Collections.Generic
Imports System.ComponentModel.DataAnnotations
Imports System.ComponentModel.DataAnnotations.Schema
Imports System.Data.Entity.Spatial
Imports PropertyChanged

<AddINotifyPropertyChangedInterface>
Partial Public Class V006_CAR_GENIN
    Inherits ModelBase
    Implements IDisposable

    <ComponentModel.DisplayName("�񍐏�No")>
    Public Property HOKOKU_NO As String

    <ComponentModel.DisplayName("�A��")>
    Public Property RENBAN As Integer

    <ComponentModel.DisplayName("�������͋敪")>
    Public Property GENIN_BUNSEKI_KB As String

    <ComponentModel.DisplayName("����敪��")>
    Public Property SOUSA_NAME As Integer

    <ComponentModel.DisplayName("�������͏ڍ׋敪")>
    Public Property GENIN_BUNSEKI_S_KB As Integer

    <ComponentModel.DisplayName("�������͋敪��")>
    Public Property GENIN_BUNSEKI_NAME As String

    <ComponentModel.DisplayName("��\�t���O")>
    Public Property DAIHYO_FG As String

    <ComponentModel.DisplayName("�ǉ��Ј�ID")>
    Public Property ADD_SYAIN_ID As Integer

    <ComponentModel.DisplayName("�ǉ��Ј���")>
    Public Property ADD_SYAIN_NAME As String

    <ComponentModel.DisplayName("�ǉ�����")>
    Public Property ADD_YMDHNS As String


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
