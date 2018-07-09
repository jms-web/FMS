Imports System.ComponentModel
Imports JMS_COMMON.ClsPubConst

Public Class TabPageEx
    Inherits TabPage

#Region "�@�R���X�g���N�^�@"
    Public Sub New()
        Call InitializeComponent()

    End Sub
#End Region

#Region "�v���p�e�B"

    ''' <summary>
    ''' WndMessage�𖳌������邱�ƂŁA�����ڂ�ς�����Enabled=False�Ɠ����̏�Ԃɂ��܂�
    ''' </summary>
    ''' <returns></returns>
    <Category("����")>
    <DefaultValue(True)>
    <Description("WndMessage�𖳌������邱�ƂŁA�����ڂ�ς�����Enabled=False�Ɠ����̏�Ԃɂ��܂�")>
    Public Property HitEnabled As Boolean

#End Region

#Region "�@WndProc ���\�b�h (Overrides)�@"
    '-----���́E�y�[�X�g��WINDOWS���b�Z�[�W���擾
    '<System.Diagnostics.DebuggerStepThrough()>
    Protected Overrides Sub WndProc(ByRef m As System.Windows.Forms.Message)

        'If HitEnabled Then
        'Else
        '    Select Case m.Msg

        '        Case ENM_WND_MESSAGE.WM_KEYDOWN, ENM_WND_MESSAGE.WM_LBUTTONDOWN, ENM_WND_MESSAGE.WM_RBUTTONDOWN, ENM_WND_MESSAGE.WM_PASTE
        '            Return
        '    End Select
        'End If

        MyBase.WndProc(m)
    End Sub
#End Region

    Public Sub EnableDisablePages(ByVal enabled As Boolean, Optional ByVal intProperty As Integer = 1)

        Select Case intProperty
            Case 1 'Enabled
                For Each ctl As Control In Me.Controls
                    Select Case ctl.GetType
                        Case GetType(TextBox)
                            DirectCast(ctl, TextBox).Enabled = enabled
                        Case GetType(TextBoxEx)
                            DirectCast(ctl, TextBoxEx).Enabled = enabled
                        Case GetType(MaskedTextBox)
                            DirectCast(ctl, MaskedTextBox).Enabled = enabled
                        Case GetType(MaskedTextBoxEx)
                            DirectCast(ctl, MaskedTextBoxEx).Enabled = enabled
                        Case GetType(ComboboxEx)
                            DirectCast(ctl, ComboboxEx).Enabled = enabled
                        Case GetType(DateTextBoxEx)
                            DirectCast(ctl, DateTextBoxEx).Enabled = enabled
                        Case GetType(RadioButton)
                            DirectCast(ctl, RadioButton).Enabled = enabled
                        Case Else
                            '����
                    End Select
                Next
            Case 2 'ReadOnly
                For Each ctl As Control In Me.Controls
                    Select Case ctl.GetType
                        Case GetType(TextBox)
                            DirectCast(ctl, TextBox).ReadOnly = Not enabled
                        Case GetType(TextBoxEx)
                            DirectCast(ctl, TextBoxEx).ReadOnly = Not enabled
                        Case GetType(MaskedTextBox)
                            DirectCast(ctl, MaskedTextBox).ReadOnly = Not enabled
                        Case GetType(MaskedTextBoxEx)
                            DirectCast(ctl, MaskedTextBoxEx).ReadOnly = Not enabled
                        Case GetType(ComboboxEx)
                            DirectCast(ctl, ComboboxEx).ReadOnly = Not enabled
                        Case GetType(DateTextBoxEx)
                            DirectCast(ctl, DateTextBoxEx).ReadOnly = Not enabled
                        Case GetType(RadioButton)
                            DirectCast(ctl, RadioButton).Enabled = enabled

                        Case Else
                            '����
                    End Select
                Next
        End Select
    End Sub
    'Public Shared Sub EnableDisablePages(ByVal tbCon As TabControl, ByVal pg As TabPage, ByVal enabled As Boolean)
    '    Try
    '        'Single TabPage
    '        If pg IsNot Nothing Then
    '            For Each ctl As Control In pg.Controls
    '                ctl.Enabled = enabled
    '            Next
    '        Else 'All TabPages...
    '            If tbCon IsNot Nothing Then
    '                For Each tp As TabPage In tbCon.TabPages
    '                    For Each cCon As Control In tp.Controls
    '                        cCon.Enabled = enabled
    '                    Next
    '                Next
    '            End If

    '        End If
    '    Catch ex As Exception
    '        'Handle your exception...
    '    End Try
    'End Sub

End Class

