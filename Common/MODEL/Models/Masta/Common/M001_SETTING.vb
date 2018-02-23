Imports System
Imports System.Collections.Generic
Imports System.ComponentModel.DataAnnotations
Imports System.ComponentModel.DataAnnotations.Schema
Imports System.Data.Entity.Spatial

''' <summary>
''' M001_�V�X�e���ݒ�l�}�X�^
''' </summary>
<Table("M001_SETTING", Schema:="dbo")>
Partial Public Class M001_SETTING
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

    <Required>
    <StringLength(1)>
    <Column(NameOf(DEF_FLG), TypeName:="char")>
    <Display(AutoGenerateField:=False)>
    <ComponentModel.EditorBrowsable(ComponentModel.EditorBrowsableState.Never)>
    Public Property _DEF_FLG As String

    <NotMapped>
    <ComponentModel.DisplayName("����l")>
    Public Property DEF_FLG As Boolean
        Get
            Return _DEF_FLG <> "0"
        End Get
        Set(value As Boolean)
            If value Then
                _DEF_FLG = "1"
            Else
                _DEF_FLG = "0"
            End If
        End Set
    End Property

    <Required>
    <StringLength(200)>
    <Column(TypeName:="nvarchar")>
    <ComponentModel.DisplayName("���l")>
    Public Property BIKOU As String

    '���ʍ���------------------------------------
    <Required>
    <StringLength(14)>
    <Display(AutoGenerateField:=False)>
    <Column(TypeName:="Char")>
    Public Property ADD_YMDHNS As String

    <Required>
    <Display(AutoGenerateField:=False)>
    Public Property ADD_SYAIN_ID As Integer

    <Required>
    <StringLength(14)>
    <Display(AutoGenerateField:=False)>
    <Column(TypeName:="Char")>
    Public Property UPD_YMDHNS As String

    <Required>
    <Display(AutoGenerateField:=False)>
    Public Property UPD_SYAIN_ID As Integer

    <Required>
    <StringLength(14)>
    <Display(AutoGenerateField:=False)>
    <Column(TypeName:="char")>
    Public Property DEL_YMDHNS As String

    <ComponentModel.DisplayName("�폜��")>
    <NotMapped>
    Public ReadOnly Property DEL_FLG As Boolean
        Get
            Return String.IsNullOrWhiteSpace(DEL_YMDHNS) = False
        End Get
    End Property

    <Required>
    <Display(AutoGenerateField:=False)>
    Public Property DEL_SYAIN_ID As Integer

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