Imports System.ComponentModel.DataAnnotations
Imports System.ComponentModel.DataAnnotations.Schema
Imports PropertyChanged

<AddINotifyPropertyChangedInterface>
Partial Public Class VWM106_BUHIN
    Inherits ModelBase
    Implements IDisposable

    <Key>
    <Column(Order:=0)>
    <StringLength(1)>
    <ComponentModel.DisplayName("����敪")>
    Public Property BUMON_KB As String

    <Key>
    <Column(Order:=1)>
    <ComponentModel.DisplayName("���Ӑ�R�[�h")>
    <DatabaseGenerated(DatabaseGeneratedOption.None)>
    Public Property TOKUI_ID As Integer

    <StringLength(50)>
    <ComponentModel.DisplayName("����於")>
    Public Property TORI_NAME As String

    <Key>
    <Column(Order:=2)>
    <StringLength(60)>
    <ComponentModel.DisplayName("���i�ԍ�")>
    Public Property BUHIN_BANGO As String

    <Key>
    <Column(Order:=3)>
    <StringLength(10)>
    <ComponentModel.DisplayName("�Г��R�[�h")>
    Public Property SYANAI_CD As String






    <Key>
    <Column(Order:=4)>
    <StringLength(80)>
    <ComponentModel.DisplayName("���i��")>
    Public Property BUHIN_NAME As String

    <Key>
    <Column(Order:=5)>
    <StringLength(2)>
    <ComponentModel.DisplayName("�_��敪")>
    <DatabaseGenerated(DatabaseGeneratedOption.None)>
    Public Property KEIYAKU_KB As String

    <StringLength(150)>
    <ComponentModel.DisplayName("�_��敪")>
    Public Property KEIYAKU_KB_DISP As String

    <Key>
    <Column(Order:=6)>
    <StringLength(20)>
    <ComponentModel.DisplayName("�}��C")>
    Public Property ZUBAN_C As String

    <Key>
    <Column(Order:=7)>
    <StringLength(20)>
    <ComponentModel.DisplayName("�i��ԍ�")>
    Public Property HINSYU_BANGO As String

    <Key>
    <Column(Order:=8)>
    <StringLength(2)>
    <ComponentModel.DisplayName("���C��敪")>
    <DatabaseGenerated(DatabaseGeneratedOption.None)>
    Public Property RIKUKAIKU_KB As String

    <StringLength(150)>
    <ComponentModel.DisplayName("���C��敪")>
    Public Property RIKUKAIKU_KB_DISP As String

    <Key>
    <Column(Order:=9, TypeName:="money")>
    <ComponentModel.DisplayName("�P��")>
    Public Property TANKA As Decimal

    <Key>
    <Column(Order:=10)>
    <StringLength(1)>
    <ComponentModel.DisplayName("������t���O")>
    Public Property TACHIAI_FLG As String

    <Key>
    <Column(Order:=11)>
    <ComponentModel.DisplayName("�@��ID")>
    <DatabaseGenerated(DatabaseGeneratedOption.None)>
    Public Property KISYU_ID As Integer

    <StringLength(30)>
    <ComponentModel.DisplayName("�@�햼")>
    Public Property KISYU_NAME As String

    <Key>
    <Column(Order:=12)>
    <StringLength(7)>
    <ComponentModel.DisplayName("�FCD")>
    Public Property COLOR_CD As String



    <Key>
    <Column(Order:=13)>
    <StringLength(14)>
    <ComponentModel.DisplayName("�ǉ�����")>
    <DatabaseGenerated(DatabaseGeneratedOption.None)>
    Public Property ADD_YMDHNS As String

    <Key>
    <Column(Order:=14)>
    <ComponentModel.DisplayName("�ǉ��S��ID")>
    <DatabaseGenerated(DatabaseGeneratedOption.None)>
    Public Property ADD_SYAIN_ID As Integer

    <StringLength(30)>
    <ComponentModel.DisplayName("�ǉ��S����")>
    <DatabaseGenerated(DatabaseGeneratedOption.None)>
    Public Property ADD_SYAIN_NAME As String

    <Key>
    <Column(Order:=15)>
    <StringLength(14)>
    <ComponentModel.DisplayName("�X�V����")>
    <DatabaseGenerated(DatabaseGeneratedOption.None)>
    Public Property UPD_YMDHNS As String

    <Key>
    <Column(Order:=16)>
    <ComponentModel.DisplayName("�X�V�S��ID")>
    <DatabaseGenerated(DatabaseGeneratedOption.None)>
    Public Property UPD_SYAIN_ID As Integer

    <StringLength(30)>
    <ComponentModel.DisplayName("�X�V�S����")>
    <DatabaseGenerated(DatabaseGeneratedOption.None)>
    Public Property UPD_SYAIN_NAME As String

    <Key>
    <Column(Order:=17)>
    <StringLength(14)>
    <ComponentModel.DisplayName("�폜����")>
    <DatabaseGenerated(DatabaseGeneratedOption.None)>
    Public Property DEL_YMDHNS As String

    <Key>
    <Column(Order:=18)>
    <ComponentModel.DisplayName("�폜�S��ID")>
    <DatabaseGenerated(DatabaseGeneratedOption.None)>
    Public Property DEL_SYAIN_ID As Integer

    <StringLength(30)>
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
