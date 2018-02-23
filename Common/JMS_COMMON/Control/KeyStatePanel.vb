
''' <summary>
''' StatusBarにキーの状態を表示するためのクラス
''' </summary>
Public Class KeyStatePanel
    Inherits ToolStripStatusLabel

    <System.Runtime.InteropServices.DllImport("user32.dll")> _
    Private Shared Function GetKeyState(ByVal nVirtKey As Integer) As Integer
    End Function

    Private Const VK_CAPITAL As Integer = &H14
    Private Const VK_KANA As Integer = &H15
    Private Const VK_INSERT As Integer = &H2D
    Private Const VK_NUMLOCK As Integer = &H90
    Private Const VK_SCROLL As Integer = &H91

    Public Enum KeyStatePanelStyle As Integer
        CapsLock = VK_CAPITAL
        KanaLock = VK_KANA
        Insert = VK_INSERT
        NumLock = VK_NUMLOCK
        ScrollLock = VK_SCROLL
    End Enum

    Private _keyStatePanelStyle As KeyStatePanelStyle

    ''' <summary>
    ''' 状態を表示するキーの種類
    ''' </summary>
    Public Property KeyStyle() As KeyStatePanelStyle
        '状態を更新
        'Textを更新
        Get
            Return _keyStatePanelStyle
        End Get

        Set(ByVal Value As KeyStatePanelStyle)
            _keyStatePanelStyle = Value
            _keyState = GetKeyState(CInt(_keyStatePanelStyle))
            UpdateText()
        End Set
    End Property

    Private _keyState As Integer = 0
    ''' <summary>
    ''' コンストラクタ
    ''' </summary>
    ''' <param name="styl">状態を表示するキーの種類</param>
    Public Sub New(ByVal styl As KeyStatePanelStyle)
        '状態を表示するキーの種類を設定
        Me.KeyStyle = styl
        Me.AutoSize = False
        Me.BorderSides = CType(ToolStripStatusLabelBorderSides.Left Or
                                  ToolStripStatusLabelBorderSides.Top Or
                                  ToolStripStatusLabelBorderSides.Right Or
                                  ToolStripStatusLabelBorderSides.Bottom,
                                  ToolStripStatusLabelBorderSides)
        Me.BorderStyle = Border3DStyle.SunkenOuter
        Me.Font = New Font("Meiryo UI", 10, FontStyle.Bold, GraphicsUnit.Point, CType(128, Byte))
        Me.Margin = New Padding(0, 3, 0, 0)
        Me.Size = New Size(40, 19)

        'Idleイベントハンドラの追加
        AddHandler Application.Idle, AddressOf Application_Idle
    End Sub


    'アプリケーションがアイドル状態の時
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub Application_Idle(ByVal sender As Object, ByVal e As EventArgs)
        '状態を更新
        Dim keyState As Integer = GetKeyState(CInt(_keyStatePanelStyle))

        If keyState <> _keyState Then
            _keyState = keyState
            'Textを更新
            UpdateText()
        End If
    End Sub

    'パネルのTextを更新する
    Private Sub UpdateText()
        If (_keyState And 1) = 1 Then
            'キーが有効のとき
            Select Case _keyStatePanelStyle
                Case KeyStatePanelStyle.CapsLock
                    Me.Enabled = True
                Case KeyStatePanelStyle.KanaLock
                    Me.Enabled = True
                Case KeyStatePanelStyle.Insert
                    Me.Enabled = True
                Case KeyStatePanelStyle.NumLock
                    Me.Enabled = True
                Case KeyStatePanelStyle.ScrollLock
                    Me.Enabled = True
                Case Else
                    Me.Enabled = False
            End Select
        Else
            'キーが無効の時
            Me.Enabled = False
        End If
    End Sub
End Class
