Imports System.ComponentModel


Public Class TabControlEx
    Inherits TabControl

#Region "�@�R���X�g���N�^�@"
    Public Sub New()
        Call InitializeComponent()

    End Sub
#End Region

#Region "�v���p�e�B"
    <Category("����")>
    <DefaultValue(False)>
    <Description("WndMessage�𖳌������邱�ƂŁA�����ڂ�ς�����Enabled=False�Ɠ����̏�Ԃɂ��܂�")>
    Public Property HitEnabled As Boolean


#End Region


#Region "�@WndProc ���\�b�h (Overrides)�@"
    '-----���́E�y�[�X�g��WINDOWS���b�Z�[�W���擾
    '<System.Diagnostics.DebuggerStepThrough()>
    Protected Overrides Sub WndProc(ByRef m As System.Windows.Forms.Message)
        Const WM_CHAR As Integer = &H102
        Const WM_PASTE As Integer = &H302
        Const WM_PAINT As Integer = &HF

        'Select Case m.Msg

        '    Case WM_PAINT
        '        'CHECK:�E�N���b�N�����̏ꍇ�́A�R�����g�A�E�g����
        '        'Case WM_CONTEXTMENU
        '        '    Return
        'End Select

        MyBase.WndProc(m)
    End Sub
#End Region



End Class

