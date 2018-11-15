Imports System.ComponentModel


Public Class NumericUpDownEx
    Inherits NumericUpDown
    Implements IReadOnly

#Region "�萔�E�ϐ�"
    Private _BackColorOrg As System.Drawing.Color
    Private _IncrementOrg As Integer
#End Region

#Region "�@�R���X�g���N�^�@"
    Public Sub New()
        Call InitializeComponent()
        _IncrementOrg = Increment
        _BackColorOrg = BackColor
    End Sub

    <DefaultValue(False)>
    Public Shadows Property [ReadOnly] As Boolean Implements IReadOnly.ReadOnly
        Get
            Return MyBase.ReadOnly
        End Get

        Set(ByVal Value As Boolean)
            If Value Then
                BackColor = clrDisableControlGotFocusedColor 'System.Drawing.SystemColors.Control
                Increment = 0
            Else
                BackColor = _BackColorOrg
                Increment = _IncrementOrg
            End If
            MyBase.ReadOnly = Value
            'SetStyle(ControlStyles.UserMouse, Value)
            'SetStyle(ControlStyles.Selectable, Value)
        End Set
    End Property
#End Region

#Region "Override"
    Protected Overrides Sub OnMouseWheel(e As MouseEventArgs)
        Dim eventargs As HandledMouseEventArgs = DirectCast(e, HandledMouseEventArgs)
        If [ReadOnly] Then eventargs.Handled = True
        MyBase.OnMouseWheel(e)
    End Sub

    Protected Overrides Sub OnKeyDown(ByVal e As KeyEventArgs)

        MyBase.OnKeyDown(e)

        'Select Case e.KeyCode
        '    Case Keys.Enter     'Enter:Tab
        '        SendKeys.Send("{Tab}") 'Enter���������ہA���̍��ڂֈړ������Tab�𑗐M����
        'End Select

    End Sub

#End Region

End Class

