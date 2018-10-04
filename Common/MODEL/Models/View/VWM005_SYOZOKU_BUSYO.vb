Imports System
Imports System.Collections.Generic
Imports System.ComponentModel.DataAnnotations
Imports System.ComponentModel.DataAnnotations.Schema
Imports System.Data.Entity.Spatial
Imports PropertyChanged

<AddINotifyPropertyChangedInterface>
Partial Public Class VWM005_SYOZOKU_BUSYO
    Inherits ModelBase
    Implements IDisposable

    <ComponentModel.DisplayName("�Ј�ID")>
    Public Property SYAIN_ID As Integer
    <ComponentModel.DisplayName("�Ј�NO")>
    Public Property SYAIN_NO As String

    Public Property SIMEI As String
    Public Property SIMEI_KANA As String
    Public Property SYAIN_KB As String
    Public Property SYAIN_KB_DISP As String
    Public Property YAKUSYOKU_KB As String
    Public Property YAKUSYOKU_KB_DISP As String
    Public Property DAIKO_KB As String
    Public Property DAIKO_KB_DISP As String
    Public Property TAISYA_YMD As String

    Public Property BUMON_KB As String
    Public Property BUMON_KB_DISP As String

    <ComponentModel.DisplayName("����ID")>
    Public Property BUSYO_ID As Integer
    Public Property SYOZOKU_YUKO_YMD As String
    Public Property BUSYO_KB As String
    Public Property BUSYOKB_DISP As String
    Public Property BUSYO_YUKO_YMD As String
    Public Property BUSYO_NAME As String
    Public Property KENMU_FLG As String
    Public Property KENMU_FLG_DISP As String
    '<Column(NameOf(KENMU_FLG), TypeName:="char")>
    '<Display(AutoGenerateField:=False)>
    'Public Property _KENMU_FLG As String


    '<NotMapped>
    'Public Property KENMU_FLG As Boolean
    '    Get
    '        Return IIf(_KENMU_FLG = "0", False, True)
    '    End Get
    '    Set(value As Boolean)
    '        _KENMU_FLG = IIf(value, "1", "0")
    '        'OnPropertyChanged(NameOf(CLOSE_FG))
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

    'Public Property DEL_FLG As String

    '<DoNotNotify>
    '<Column(NameOf(KENMU_FLG), TypeName:="char")>
    '<Display(AutoGenerateField:=False)>
    'Public Property _KENMU_FLG As String


    '<NotMapped>
    '<ComponentModel.DisplayName("�����t���O")>
    'Public Property KENMU_FLG As Boolean
    '    Get
    '        Return IIf(_KENMU_FLG = "0", False, True)
    '    End Get
    '    Set(value As Boolean)
    '        _KENMU_FLG = IIf(value, "1", "0")
    '        'OnPropertyChanged(NameOf(CLOSE_FG))
    '    End Set
    'End Property

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
