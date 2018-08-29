Imports System.ComponentModel


Public Class CheckBoxEx
    Inherits CheckBox

    Private _GotForcusedColor As Color '�t�H�[�J�X���̔w�i�F
    Private _BackColorDefault As Color  '�t�H�[�J�X�r�������̔w�i�F
    Private _ReadOnly As Boolean
#Region "�@�R���X�g���N�^�@"
    Public Sub New()
        Call InitializeComponent()

        Me._BackColorDefault = clrControlDefaultBackColor
        Me.EnterBehavior = 0

    End Sub
#End Region

#Region "ReadOnly"
    Public Shadows Property [ReadOnly] As Boolean
        Get
            Return _ReadOnly
        End Get
        Set(value As Boolean)
            SetStyle(ControlStyles.UserMouse, value)
            _ReadOnly = value
        End Set
    End Property

#End Region

#Region "GotFocusedColor"
    <Bindable(True), Category("Appearance"), DefaultValue("")>
    Property [GotFocusedColor]() As System.Drawing.Color
        Get
            Return _GotForcusedColor
        End Get
        Set(ByVal value As Color)
            _GotForcusedColor = value
        End Set
    End Property
#End Region
#Region "BackColor"
    <Bindable(True), Category("Appearance"), DefaultValue("")>
    Overrides Property [BackColor]() As System.Drawing.Color
        Get
            Return MyBase.BackColor
        End Get
        Set(ByVal value As System.Drawing.Color)
            MyBase.BackColor = value

            'BackColorDefault = value
        End Set
    End Property
#End Region

#Region "EnterBehavior"

    <Category("����"),
     DefaultValue(0),
     Description("0:�ʏ�A1:���̍��ڂֈړ����邽�߁ATab�R�}���h�𑗐M����")>
    Public Property EnterBehavior As Integer

#End Region

#Region "OnKeyDown(ByVal e As KeyEventArgs)"
    Protected Overrides Sub OnKeyDown(ByVal e As KeyEventArgs)

        MyBase.OnKeyDown(e)

        Select Case e.KeyCode
            Case Keys.Enter     'Enter:Tab

                Select Case EnterBehavior
                    Case 1
                        SendKeys.Send("{Tab}") 'Enter���������ہA���̍��ڂֈړ������Tab�𑗐M����
                    Case Else 'and 0
                End Select
        End Select

    End Sub
#End Region
#Region "OnGotFocus(ByVal e As EventArgs)"
    Protected Overrides Sub OnGotFocus(ByVal e As EventArgs)
        If Me.Enabled = False Or Me.ReadOnly = True Then
            MyBase.BackColor = clrDisableControlGotFocusedColor
        Else
            '�t�H�[�J�X���͔w�i�F�ύX
            MyBase.BackColor = _GotForcusedColor
        End If
        MyBase.OnGotFocus(e) '���N���X�Ăяo��

    End Sub
#End Region
#Region "OnLostFocus(ByVal e As EventArgs)"
    Protected Overrides Sub OnLostFocus(ByVal e As EventArgs)

        If Me.Enabled = False Or Me.ReadOnly = True Then
            MyBase.BackColor = clrDisableControlGotFocusedColor
        Else
            '�t�H�[�J�X���Ȃ��Ƃ��͔w�i�F�����ݒ�
            MyBase.BackColor = _BackColorDefault
        End If
        MyBase.OnLostFocus(e) '���N���X�Ăяo��

    End Sub
#End Region

    Protected Overrides Sub OnEnabledChanged(e As EventArgs)
        If Me.Enabled = False Then
            MyBase.BackColor = clrDisableControlGotFocusedColor
            _BackColorDefault = clrDisableControlGotFocusedColor
        End If

        MyBase.OnEnabledChanged(e)
    End Sub


End Class

