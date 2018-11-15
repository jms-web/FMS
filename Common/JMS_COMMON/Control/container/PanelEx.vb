Imports System.ComponentModel
Imports JMS_COMMON.ClsPubConst

Public Class PanelEx
    Inherits Panel

#Region "�萔"
    Public Enum ENM_PROPERTY
        _1_Enabled = 1
        _2_ReadOnly = 2
    End Enum

#End Region

#Region "�@�R���X�g���N�^�@"
    Public Sub New()
        Call InitializeComponent()
        BorderColor = Color.Transparent
        Me.SetStyle(ControlStyles.UserPaint, True)
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

    ''' <summary>
    ''' �����I�Ƀp�l�����̃I�u�W�F�N�g�ʒu�ɃX�N���[�����邩�ǂ���
    ''' </summary>
    ''' <returns></returns>
    <DefaultValue(False)>
    Public Property AutoScrollControlIntoView As Boolean

    <DefaultValue(GetType(Color), "Transparent")>
    Public Property BorderColor As Color
#End Region

#Region "Overrides���\�b�h"

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

    Protected Overrides Function ScrollToControl(activeControl As Control) As Point
        If Me.AutoScrollControlIntoView Then
            Return MyBase.ScrollToControl(activeControl)
        Else
            Return New Point(-Me.HorizontalScroll.Value, -Me.VerticalScroll.Value)
        End If
    End Function

    Protected Overrides Sub OnClick(e As EventArgs)
        Me.Focus()
        MyBase.OnClick(e)
    End Sub

    Protected Overrides Sub OnPaint(e As PaintEventArgs)
        MyBase.OnPaint(e)
        e.Graphics.DrawRectangle(New Pen(New SolidBrush(BorderColor), 1), e.ClipRectangle)
    End Sub

    Protected Overrides Sub OnScroll(se As ScrollEventArgs)
        Me.Refresh()
        MyBase.OnScroll(se)
    End Sub

#End Region

#Region "���\�b�h"
    Public Sub DisableContaints(ByVal enabled As Boolean, Optional ByVal intProperty As ENM_PROPERTY = ENM_PROPERTY._1_Enabled)

        'UNDONE:panel backcolor
        If enabled Then
            Me.BackColor = SystemColors.Control
        Else
            Me.BackColor = SystemColors.Control
        End If

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
                        Case GetType(CheckBox)
                            DirectCast(ctl, CheckBox).Enabled = enabled
                        Case GetType(Button)
                            DirectCast(ctl, Button).Enabled = enabled
                        Case GetType(DateTextBoxEx)
                            DirectCast(ctl, DateTextBoxEx).Enabled = enabled
                        Case GetType(RadioButton)
                            DirectCast(ctl, RadioButton).Enabled = enabled
                        Case GetType(TableLayoutPanel), GetType(Panel), GetType(PanelEx)

                            DisableContaints(ctl, enabled, intProperty)
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
                        Case GetType(CheckBox)
                            DirectCast(ctl, CheckBox).Enabled = enabled
                        Case GetType(Button)
                            DirectCast(ctl, Button).Enabled = enabled
                        Case GetType(DateTextBoxEx)
                            DirectCast(ctl, DateTextBoxEx).ReadOnly = Not enabled
                        Case GetType(RadioButton)
                            DirectCast(ctl, RadioButton).Enabled = enabled
                        Case GetType(TableLayoutPanel), GetType(Panel), GetType(PanelEx), GetType(FlowLayoutPanel)

                            DisableContaints(ctl, enabled, intProperty)
                        Case Else
                            '����
                    End Select
                Next
        End Select
    End Sub

    Public Sub DisableContaints(ctrl As Control, enabled As Boolean, Optional intProperty As ENM_PROPERTY = ENM_PROPERTY._1_Enabled)

        Select Case intProperty
            Case 1 'Enabled
                For Each ctl As Control In ctrl.Controls
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
                        Case GetType(CheckBox)
                            DirectCast(ctl, CheckBox).Enabled = enabled
                        Case GetType(Button)
                            DirectCast(ctl, Button).Enabled = enabled
                        Case GetType(DateTextBoxEx)
                            DirectCast(ctl, DateTextBoxEx).Enabled = enabled
                        Case GetType(RadioButton)
                            DirectCast(ctl, RadioButton).Enabled = enabled
                        Case GetType(TableLayoutPanel)
                            '�ċA�I�Ɍ�����
                            'EnableDisablePages(enabled, intProperty)
                            DirectCast(ctl, TableLayoutPanel).Enabled = enabled
                        Case Else
                            '����
                    End Select
                Next
            Case 2 'ReadOnly
                For Each ctl As Control In ctrl.Controls
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
                        Case GetType(CheckBox)
                            DirectCast(ctl, CheckBox).Enabled = enabled
                        Case GetType(Button)
                            DirectCast(ctl, Button).Enabled = enabled
                        Case GetType(DateTextBoxEx)
                            DirectCast(ctl, DateTextBoxEx).ReadOnly = Not enabled
                        Case GetType(RadioButton)
                            DirectCast(ctl, RadioButton).Enabled = enabled
                        Case GetType(TableLayoutPanel)
                            '�ċA�I�Ɍ�����
                            'DisableContains(enabled, intProperty)
                            DirectCast(ctl, TableLayoutPanel).Enabled = enabled
                        Case Else
                            '����
                    End Select
                Next
        End Select
    End Sub

#End Region

End Class

