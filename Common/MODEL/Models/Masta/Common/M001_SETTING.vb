Imports System.ComponentModel.DataAnnotations
Imports System.ComponentModel.DataAnnotations.Schema
Imports PropertyChanged

''' <summary>
''' M001_�V�X�e���ݒ�l�}�X�^
''' </summary>
<Table("M001_SETTING", Schema:="dbo")>
<AddINotifyPropertyChangedInterface>
Partial Public Class M001_SETTING
    Inherits ModelBase
    Implements IDisposable

    <Key>
    <Column(Order:=0, TypeName:="nvarchar")>
    <StringLength(50)>
    <ComponentModel.DisplayName("���ږ�")>
    Public Property ITEM_NAME As String

    <Key>
    <Column(Order:=1, TypeName:="nvarchar")>
    <StringLength(50)>
    <ComponentModel.DisplayName("���ڒl")>
    Public Property ITEM_VALUE As String

    <Required>
    <StringLength(50)>
    <Column(TypeName:="nvarchar")>
    <ComponentModel.DisplayName("���ڃO���[�v")>
    Public Property ITEM_GROUP As String

    <Required>
    <StringLength(150)>
    <Column(TypeName:="nvarchar")>
    <ComponentModel.DisplayName("�\���l")>
    Public Property ITEM_DISP As String

    <Required>
    <ComponentModel.DisplayName("�\����")>
    Public Property DISP_ORDER As Integer

    '<DoNotNotify>
    '<Required>
    '<StringLength(1)>
    '<Column(NameOf(DEF_FLG), TypeName:="char")>
    '<Display(AutoGenerateField:=False)>
    'Public Property _DEF_FLG As String

    <NotMapped>
    <Display(AutoGenerateField:=False)>
    <ComponentModel.DisplayName("����l")>
    Public Property DEF_FLG_ As Boolean
        Get
            Return DEF_FLG <> "0"
        End Get
        Set(value As Boolean)
            DEF_FLG = IIf(value, "1", "0")
        End Set
    End Property
    Public Property DEF_FLG As String

    <Required>
    <StringLength(200)>
    <Column(TypeName:="nvarchar")>
    <ComponentModel.DisplayName("���l")>
    Public Property BIKOU As String

    '���ʍ���------------------------------------
    <Required>
    <StringLength(14)>
    <Column(TypeName:="Char")>
    <ComponentModel.DisplayName("�ǉ�����")>
    Public Property ADD_YMDHNS As String

    <Required>
    <ComponentModel.DisplayName("�ǉ��Ј�ID")>
    Public Property ADD_SYAIN_ID As Integer

    <Required>
    <StringLength(14)>
    <Column(TypeName:="Char")>
    <ComponentModel.DisplayName("�X�V����")>
    Public Property UPD_YMDHNS As String

    <Required>
    <ComponentModel.DisplayName("�X�V�Ј�ID")>
    Public Property UPD_SYAIN_ID As Integer

    <Required>
    <StringLength(14)>
    <Column(TypeName:="char")>
    <ComponentModel.DisplayName("�폜����")>
    Public Property DEL_YMDHNS As String

    <DoNotNotify>
    <ComponentModel.DisplayName("�폜�t���O")>
    <Display(AutoGenerateField:=False)>
    <NotMapped>
    Public ReadOnly Property DEL_FLG As Boolean
        Get
            Return Not String.IsNullOrWhiteSpace(DEL_YMDHNS)
        End Get
    End Property

    <Required>
    <ComponentModel.DisplayName("�폜�Ј�ID")>
    Public Property DEL_SYAIN_ID As Integer

#Region "IDisposable Support"
    Private disposedValue As Boolean ' �d������Ăяo�������o����ɂ�

    ' IDisposable
    Protected Overridable Sub Dispose(disposing As Boolean)
        If Not disposedValue Then
            If disposing Then
                '  �}�l�[�W��Ԃ�j�����܂� (�}�l�[�W �I�u�W�F�N�g)�B
            End If

            ' �A���}�l�[�W ���\�[�X (�A���}�l�[�W �I�u�W�F�N�g) ��������A���� Finalize() ���I�[�o�[���C�h���܂��B
            ' �傫�ȃt�B�[���h�� null �ɐݒ肵�܂��B
        End If
        disposedValue = True
    End Sub

    '  ��� Dispose(disposing As Boolean) �ɃA���}�l�[�W ���\�[�X���������R�[�h���܂܂��ꍇ�ɂ̂� Finalize() ���I�[�o�[���C�h���܂��B
    'Protected Overrides Sub Finalize()
    '    ' ���̃R�[�h��ύX���Ȃ��ł��������B�N���[���A�b�v �R�[�h����� Dispose(disposing As Boolean) �ɋL�q���܂��B
    '    Dispose(False)
    '    MyBase.Finalize()
    'End Sub

    ' ���̃R�[�h�́A�j���\�ȃp�^�[���𐳂��������ł���悤�� Visual Basic �ɂ���Ēǉ�����܂����B
    Public Sub Dispose() Implements IDisposable.Dispose
        ' ���̃R�[�h��ύX���Ȃ��ł��������B�N���[���A�b�v �R�[�h����� Dispose(disposing As Boolean) �ɋL�q���܂��B
        Dispose(True)
        '  ��� Finalize() ���I�[�o�[���C�h����Ă���ꍇ�́A���̍s�̃R�����g���������Ă��������B
        ' GC.SuppressFinalize(Me)
    End Sub
#End Region
End Class