Imports System.ComponentModel


Public Class CheckBoxEx
    Inherits CheckBox

    Private _GotForcusedColor As Color 'フォーカス時の背景色
    Private _BackColorDefault As Color  'フォーカス喪失時時の背景色
    Private _ReadOnly As Boolean
#Region "　コンストラクタ　"
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

    <Category("動作"),
     DefaultValue(0),
     Description("0:通常、1:次の項目へ移動するため、Tabコマンドを送信する")>
    Public Property EnterBehavior As Integer

#End Region

#Region "OnKeyDown(ByVal e As KeyEventArgs)"
    Protected Overrides Sub OnKeyDown(ByVal e As KeyEventArgs)

        MyBase.OnKeyDown(e)

        Select Case e.KeyCode
            Case Keys.Enter     'Enter:Tab

                Select Case EnterBehavior
                    Case 1
                        SendKeys.Send("{Tab}") 'Enterを押した際、次の項目へ移動する為Tabを送信する
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
            'フォーカス時は背景色変更
            MyBase.BackColor = _GotForcusedColor
        End If
        MyBase.OnGotFocus(e) '基底クラス呼び出し

    End Sub
#End Region
#Region "OnLostFocus(ByVal e As EventArgs)"
    Protected Overrides Sub OnLostFocus(ByVal e As EventArgs)

        If Me.Enabled = False Or Me.ReadOnly = True Then
            MyBase.BackColor = clrDisableControlGotFocusedColor
        Else
            'フォーカスがないときは背景色＝白設定
            MyBase.BackColor = _BackColorDefault
        End If
        MyBase.OnLostFocus(e) '基底クラス呼び出し

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

