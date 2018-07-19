Imports System.ComponentModel
Imports JMS_COMMON.ClsPubConst

Public Class TabPageEx
    Inherits TabPage

#Region "　コンストラクタ　"
    Public Sub New()
        Call InitializeComponent()

    End Sub
#End Region

#Region "プロパティ"

    ''' <summary>
    ''' WndMessageを無効化することで、見た目を変えずにEnabled=Falseと同等の状態にします
    ''' </summary>
    ''' <returns></returns>
    <Category("動作")>
    <DefaultValue(True)>
    <Description("WndMessageを無効化することで、見た目を変えずにEnabled=Falseと同等の状態にします")>
    Public Property HitEnabled As Boolean


    ''' <summary>
    ''' 自動的にパネル内のオブジェクト位置にスクロールするかどうか
    ''' </summary>
    ''' <returns></returns>
    <DefaultValue(False)>
    Public Property AutoScrollControlIntoView As Boolean

#End Region

#Region "　WndProc メソッド (Overrides)　"
    '-----入力・ペーストのWINDOWSメッセージを取得
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
                        Case GetType(TableLayoutPanel)
                            '再帰的に見たい
                            'EnableDisablePages(enabled, intProperty)
                            DirectCast(ctl, TableLayoutPanel).Enabled = enabled
                        Case Else
                            '無視
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
                        Case GetType(TableLayoutPanel)
                            '再帰的に見たい
                            'EnableDisablePages(enabled, intProperty)
                            DirectCast(ctl, TableLayoutPanel).Enabled = enabled
                        Case Else
                            '無視
                    End Select
                Next
        End Select
    End Sub

    Protected Overrides Function ScrollToControl(activeControl As Control) As Point
        If Me.AutoScrollControlIntoView Then
            Return MyBase.ScrollToControl(activeControl)
        Else
            Return New Point(-Me.HorizontalScroll.Value, -Me.VerticalScroll.Value)
        End If
    End Function
End Class

