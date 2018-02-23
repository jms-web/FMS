Imports System.ComponentModel

<System.ComponentModel.Designer(
"System.Windows.Forms.Design.PanelDesigner, System.Design")>
Public Class FlowLayoutRadioBox
    Inherits FlowLayoutPanel

    Public Sub New()
    End Sub

    Private _GotForcusedColor As Color = Color.FromArgb(190, 180, 255) 'フォーカス時の背景色
    Private _BackColorDefault As Color = Color.White 'フォーカス喪失時時の背景色

#Region "プロパティ "
#Region "GotFocusedColor"
    '********************************************************************************
    '  プロパティ名     ：  GotFocusedColor
    '  説明             ：  カーソルが当たっている時の色
    '  注意事項         ：  特に無し
    '  作成日／作成者   ：  08/03/09 seki
    '********************************************************************************
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
    '********************************************************************************
    '  プロパティ名     ：  BackColor
    '  説明             ：  バックカラー
    '  注意事項         ：  特に無し
    '  作成日／作成者   ：  08/03/09 seki
    '********************************************************************************
    <Bindable(True), Category("Appearance"), DefaultValue("")>
    Overrides Property [BackColor]() As System.Drawing.Color
        Get
            Return MyBase.BackColor
        End Get
        Set(ByVal value As System.Drawing.Color)
            MyBase.BackColor = value
            _BackColorDefault = value
        End Set
    End Property

#End Region
#End Region

#Region "イベント関連"
#Region "OnKeyDown(ByVal e As KeyEventArgs)"
    Protected Overrides Sub OnKeyDown(ByVal e As KeyEventArgs)

        MyBase.OnKeyDown(e)

        Select Case e.KeyCode
            Case Keys.Enter     'Enter:Tab
                SendKeys.Send("{Tab}") 'Enterを押した際、次の項目へ移動する為Tabを送信する
        End Select
    End Sub
#End Region
#Region "OnGotFocus(ByVal e As EventArgs)"
    Protected Overrides Sub OnGotFocus(ByVal e As EventArgs)
        'フォーカス時は背景色変更
        MyBase.BackColor = _GotForcusedColor
        MyBase.OnGotFocus(e) '基底クラス呼び出し

    End Sub
#End Region
#Region "OnLostFocus(ByVal e As EventArgs)"
    Protected Overrides Sub OnLostFocus(ByVal e As EventArgs)
        'フォーカスがないときは背景色＝白設定
        MyBase.BackColor = _BackColorDefault
        MyBase.OnLostFocus(e) '基底クラス呼び出し

    End Sub
#End Region
#End Region

#Region "関数"
    Public Sub Clear()
        Me.Controls.Clear()
    End Sub

    Public Sub SetControls(ByVal items As Generic.List(Of String))
        Me.Clear()

        Dim intCNT As Integer = 1
        For Each item As String In items
            Dim rbtn As New RadioButton With {.Name = Me.Name & "_rbtn" & intCNT,
                                              .Text = item,
                                              .Cursor = Cursors.Hand}
            Me.Controls.Add(rbtn)
        Next

    End Sub

#End Region
End Class