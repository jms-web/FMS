Imports System.ComponentModel


Public Class TextBoxEx
    Inherits TextBox

    Private _GotForcusedColor As Color 'フォーカス時の背景色
    Private _BackColorDefault As Color  'フォーカス喪失時時の背景色



#Region "　コンストラクタ　"
    Public Sub New()
        Call InitializeComponent()

        Me.MaxByteLength = 65535
        Me.SelectAllText = True
        Me.ImeMode = Windows.Forms.ImeMode.Disable
        _watermarkColor = SystemColors.GrayText

        Me._GotForcusedColor = clrControlGotFocusedColor
        Me._BackColorDefault = clrControlDefaultBackColor
        Me.EnterBehavior = 0
    End Sub
#End Region

#Region "Undo"
    Protected Sub Ctrl_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles MyBase.KeyDown
        If e.KeyCode = Keys.Escape Then
            Dim mtx As TextBoxEx = DirectCast(sender, TextBoxEx)
            If mtx.CanUndo = True Then
                mtx.Undo()
            End If
        End If
    End Sub
#End Region

#Region "コンテキストメニュー関連"

    Private Sub Mtx_MouseDown(sender As Object, e As MouseEventArgs) Handles MyBase.MouseDown
        If e.Button = MouseButtons.Right Then
            DirectCast(sender, Control).Capture = False
        End If
    End Sub
#End Region

#Region "　WatermarkTextプロパティ"
    Private _watermarkText As String
    Private _hasWatermark As Boolean
    Private _watermarkColor As Color
    Private _foreColor As Color

    ''' <summary>
    ''' テキストが空の場合に表示する文字列を取得・設定します。
    ''' </summary>
    ''' <returns></returns>
    <Category("表示")>
    <DefaultValue("")>
    <Description("テキストが空の場合に表示する文字列です。")>
    <RefreshProperties(RefreshProperties.Repaint)>
    Public Property WatermarkText As String
        Get
            Return _watermarkText
        End Get
        Set(value As String)
            _watermarkText = value
            Call TrySetWatermark() 'Me.Invalidate()
        End Set
    End Property



    ''' <summary>
    ''' テキストが空の場合に表示する文字列の色を取得・設定します。
    ''' </summary>
    ''' <returns></returns>
    <Category("表示")>
    <DefaultValue(GetType(Color), "GrayText")>
    <Description("テキストが空の場合に表示する文字列の色です。")>
    Public Property WatermarkColor As Color
        Get
            Return _watermarkColor
        End Get
        Set(value As Color)
            _watermarkColor = value
            Call TrySetWatermark()
        End Set
    End Property


#End Region

#Region "OldValue プロパティ"
    Private _oldValue As String

    ''' <summary>
    ''' 変更前の値を取得します
    ''' </summary>
    ''' <returns></returns>
    Public ReadOnly Property OldValue As String
        Get
            Return _oldValue
        End Get
    End Property
#End Region

#Region "　MaxByteLength プロパティ (Overridable)　"
    '-----入力または貼り付けできる最大文字バイト数を取得または設定します。
    Private MaxByteLengthValue As Integer

    <Category("動作"),
     DefaultValue(65535),
     Description("エディット コントロールに入力できる最大文字バイト数を指定します。")>
    Public Property MaxByteLength() As Integer
        Get
            Return Me.MaxByteLengthValue
        End Get

        Set(ByVal value As Integer)
            If Me.MaxByteLengthValue <> value Then
                Me.MaxByteLengthValue = value
            End If
        End Set
    End Property

#End Region

#Region "　PermitNumChars プロパティ (Overridable)　"
    '-----｢0123456789.-｣のみ入力可。(MaskがC時に適用)
    Private PermitNumCharsValue As Boolean
    Private chrPermitNumChars As Char() = New Char() {"0"c, "1"c, "2"c, "3"c, "4"c, "5"c, "6"c, "7"c, "8"c, "9"c, "."c, "-"c}

    <Category("動作"),
     DefaultValue(False),
     Description("｢0123456789.-｣のみ入力可。(MaskがC時に適用)")>
    Public Property PermitNumChars() As Boolean
        Get
            Return Me.PermitNumCharsValue
        End Get

        Set(ByVal value As Boolean)
            If Me.PermitNumCharsValue <> value Then
                Me.PermitNumCharsValue = value
            End If
        End Set
    End Property

#End Region

#Region "　SelectAllText プロパティ (Overridable)　"
    '-----Focus時の全選択を設定します。
    Private SelectAllTextValue As Boolean

    <Category("動作"),
     DefaultValue(True),
     Description("Focus時の全選択を設定します。")>
    Public Property SelectAllText() As Boolean
        Get
            Return Me.SelectAllTextValue
        End Get

        Set(ByVal value As Boolean)
            If Me.SelectAllTextValue <> value Then
                Me.SelectAllTextValue = value
            End If
        End Set
    End Property
#End Region

#Region "　ForeColor プロパティ　"
    Public Overrides Property ForeColor As Color
        Get
            If DesignMode Then
                Return _foreColor
            Else
                Return MyBase.ForeColor
            End If
        End Get
        Set(value As Color)
            _foreColor = value
            If _hasWatermark = False Then
                MyBase.ForeColor = value
            End If
        End Set
    End Property

    '<RefreshProperties(RefreshProperties.Repaint)>
    'Public Overrides Property Text As String
    '    Get
    '        Return IIf(_watermarkText.IsNullOrWhiteSpace, String.Empty, MyBase.Text)
    '    End Get
    '    Set(value As String)
    '        If value.IsNullOrWhiteSpace Then
    '            '空文字列が指定された
    '            Call TrySetWatermark() 'ウォーターマーク表示を試みる
    '        ElseIf _hasWatermark Then
    '            '適切な文字列が設定された。ウォーターマーク表示設定解除
    '            Call ResetWatermark(value)
    '        Else
    '            'テキスト上書き
    '            MyBase.Text = value
    '        End If
    '    End Set
    'End Property

#End Region

#Region "　WndProc メソッド (Overrides)　"
    '-----入力・ペーストのWINDOWSメッセージを取得
    <System.Diagnostics.DebuggerStepThrough()>
    Protected Overrides Sub WndProc(ByRef m As System.Windows.Forms.Message)
        Const WM_CHAR As Integer = &H102
        Const WM_PASTE As Integer = &H302
        'Const WM_CONTEXTMENU As Integer = &H7B
        Const WM_PAINT As Integer = &HF

        Select Case m.Msg
            Case WM_CHAR
                Dim eKeyPress As New KeyPressEventArgs(Microsoft.VisualBasic.ChrW(m.WParam.ToInt32()))
                Me.OnChar(eKeyPress)

                If eKeyPress.Handled Then
                    Return
                End If

                'CHECK: ペースト無効時はコメントアウト解除
            Case WM_PASTE
                Me.OnPaste(New System.EventArgs())
                Return

            Case WM_PAINT
                If m.Msg = WM_PAINT And Me.Text.IsNullOrEmpty = True And WatermarkText.IsNullOrEmpty = False Then
                    Using g As Graphics = Graphics.FromHwnd(Me.Handle)
                        'テキストボックス内の適切な座標に描画
                        Dim rect As Rectangle = Me.ClientRectangle
                        rect.Offset(1, 1)
                        TextRenderer.DrawText(g,
                                              WatermarkText,
                                              New Font(Me.Font.Name, Me.Font.Size, FontStyle.Regular, GraphicsUnit.Point, CType(128, Byte)),
                                              rect,
                                              _watermarkColor,
                                              TextFormatFlags.Top Or TextFormatFlags.Left)
                    End Using
                End If

                'CHECK:右クリック無効の場合は、コメントアウト解除
                'Case WM_CONTEXTMENU
                '    Return
        End Select

        MyBase.WndProc(m)
    End Sub
#End Region

#Region "　OnChar メソッド (Overridable)　"
    ' 文字列がクライアント領域に送信された時に呼び出されるメソッド
    Protected Overridable Sub OnChar(ByVal e As System.Windows.Forms.KeyPressEventArgs)
        If Char.IsControl(e.KeyChar) Then
            Return
        End If

        '-----数値文字のみ入力可
        If Me.PermitNumChars = True Then
            If Not HasPermitChars(e.KeyChar, chrPermitNumChars) Then
                e.Handled = True
            End If
        End If

        '-----入力を最大文字バイト数に制限
        Dim sjisEncoding As System.Text.Encoding = System.Text.Encoding.GetEncoding("Shift_JIS")
        Dim textByteCount As Integer = sjisEncoding.GetByteCount(Me.Text)
        Dim inputByteCount As Integer = sjisEncoding.GetByteCount(e.KeyChar.ToString())
        Dim selectedTextByteCount As Integer = sjisEncoding.GetByteCount(Me.SelectedText)

        If textByteCount + inputByteCount - selectedTextByteCount > Me.MaxByteLength Then
            e.Handled = True
        End If
    End Sub
#End Region

#Region "　OnPaste メソッド (Overridable)　"
    '貼り付けした時に呼び出されるメソッド
    Protected Overridable Sub OnPaste(ByVal e As System.EventArgs)
        Dim inputText As String = ""
        Dim sjisEncoding As System.Text.Encoding = System.Text.Encoding.GetEncoding("Shift_JIS")
        Dim selectedTextByteCount As Integer
        Try

            Dim clipboardText As Object = Clipboard.GetDataObject().GetData(System.Windows.Forms.DataFormats.Text)

            If clipboardText Is Nothing Then
                Return
            End If

            '-----数値文字のみ入力可
            If Me.PermitNumChars = True Then
                Me.SelectedText = GetPermitedString(clipboardText, chrPermitNumChars)
                clipboardText = Me.SelectedText
            End If

            '-----ペーストを最大文字バイト数に制限
            If Me.MaxLength * 2 >= Me.MaxByteLength Then

                inputText = clipboardText.ToString()
                Dim textByteCount As Integer = sjisEncoding.GetByteCount(Me.Text)
                Dim inputByteCount As Integer = sjisEncoding.GetByteCount(inputText)
                selectedTextByteCount = sjisEncoding.GetByteCount(Me.SelectedText)
                Dim remainByteCount As Integer = Me.MaxByteLength - (textByteCount - selectedTextByteCount)

                If remainByteCount <= 0 Or MaxByteLength - (textByteCount + inputByteCount) <= 0 Then
                    Return
                End If

                If remainByteCount >= inputByteCount Then
                    Me.SelectedText = inputText
                Else
                    textByteCount = sjisEncoding.GetByteCount(inputText)
                    If textByteCount > Me.MaxByteLength Then
                        Me.SelectedText = ClsPubMethod.MidB(inputText, 1, Me.MaxByteLength)
                    Else
                        Me.SelectedText = inputText.Substring(0, remainByteCount)
                    End If

                End If
            End If

        Catch ex As Exception
            'EM.ErrorSyori(ex, False, conblnNonMsg)
        End Try
    End Sub
#End Region

#Region "　HasPermitChars メソッド　"
    '-----許可された文字かどうかを示す値を返す
    Private Shared Function HasPermitChars(ByVal chTarget As Char, ByVal chPermits As Char()) As Boolean
        For Each ch As Char In chPermits
            If chTarget = ch Then
                Return True
            End If
        Next ch
    End Function
#End Region

#Region "　GetPermitedString メソッド　"
    '-----許可された文字だけを連結して返す
    Private Shared Function GetPermitedString(ByVal stTarget As String, ByVal chPermits As Char()) As String
        Dim stReturn As String = String.Empty

        For Each chTarget As Char In stTarget
            If HasPermitChars(chTarget, chPermits) Then
                stReturn &= chTarget
            End If
        Next chTarget

        Return stReturn
    End Function
#End Region

#Region "　OnEnter メソッド (Overrides)　"
    '-----フォーカス時に全選択
    Protected Overrides Sub OnEnter(ByVal e As System.EventArgs)
        _oldValue = Me.Text
        If Me.SelectAllText = True Then
            BeginInvoke(New MethodInvokerForTextBox(AddressOf MaskedTextBoxSelectAll), Me)
        End If
    End Sub
#End Region

    Public Property ShowRemaining As Boolean


#Region "　Change メソッド(Overrides)"
    Protected Overrides Sub OnTextChanged(e As EventArgs)
        MyBase.OnTextChanged(e)

        Using g As Graphics = Graphics.FromHwnd(Me.Handle)
            'テキストボックス外に残り入力可能文字数を描画
            Dim rect As Rectangle = Me.ClientRectangle
            rect.Offset(1, 1)
            TextRenderer.DrawText(g,
                                  WatermarkText,
                                  New Font(Me.Font.Name, Me.Font.Size, FontStyle.Regular, GraphicsUnit.Point, CType(128, Byte)),
                                  rect,
                                  _watermarkColor,
                                  TextFormatFlags.Top Or TextFormatFlags.Left)
        End Using
    End Sub

#End Region

#Region "　SelectAll メソッド (Delegate)　"
    Private Delegate Sub MethodInvokerForTextBox(ByVal pTarget As TextBox)
    Private Shared Sub MaskedTextBoxSelectAll(ByVal pTarget As TextBox)
        If pTarget IsNot Nothing Then pTarget.SelectAll()
    End Sub
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
            _BackColorDefault = value
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

#Region "Undo メソッド"
    Public Overloads Sub Undo()
        Me.Text = Me.OldValue
    End Sub
#End Region

#Region "WaterMark関連"
    Private Function TrySetWatermark() As Boolean
        If _watermarkText.IsNullOrWhiteSpace = False And
            MyBase.Text.IsNullOrWhiteSpace = True And
            MyBase.Focused = False Then

            'ウォーターマーク設定
            MyBase.ForeColor = WatermarkColor
            MyBase.Text = _watermarkText
            _hasWatermark = True

            Return True
        Else
            _hasWatermark = False
            Return False
        End If

    End Function

    Private Sub ResetWatermark(ByVal value As String)
        If value IsNot Nothing Then
            MyBase.Text = value
        End If
        MyBase.ForeColor = _foreColor
        _hasWatermark = False
    End Sub

#End Region

End Class

