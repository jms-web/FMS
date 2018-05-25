Imports System.ComponentModel


Public Class TabControlEx
    Inherits TabControl

#Region "　コンストラクタ　"
    Public Sub New()
        Call InitializeComponent()

    End Sub
#End Region

#Region "プロパティ"
    <Category("動作")>
    <DefaultValue(False)>
    <Description("WndMessageを無効化することで、見た目を変えずにEnabled=Falseと同等の状態にします")>
    Public Property HitEnabled As Boolean


#End Region


#Region "　WndProc メソッド (Overrides)　"
    '-----入力・ペーストのWINDOWSメッセージを取得
    '<System.Diagnostics.DebuggerStepThrough()>
    Protected Overrides Sub WndProc(ByRef m As System.Windows.Forms.Message)
        Const WM_CHAR As Integer = &H102
        Const WM_PASTE As Integer = &H302
        Const WM_PAINT As Integer = &HF

        'Select Case m.Msg

        '    Case WM_PAINT
        '        'CHECK:右クリック無効の場合は、コメントアウト解除
        '        'Case WM_CONTEXTMENU
        '        '    Return
        'End Select

        MyBase.WndProc(m)
    End Sub
#End Region



End Class

