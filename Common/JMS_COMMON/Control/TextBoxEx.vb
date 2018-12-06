Imports System.ComponentModel

''' <summary>
''' 主に自由入力欄としての利用を想定したテキスト入力コントロール
''' </summary>
Public Class TextBoxEx
    Inherits TextBox
    'Implements IReadOnly

#Region "定数・変数"

    Private _ActiveBackColor As Color
    Private _BackColorOrg As Color
    Private _ForeColor As Color
    Private _HasWatermark As Boolean
    Private _InputRequired As Boolean
    Private _InvalidBackColor As Color
    Private _OldValue As String
    Private _WatermarkColor As Color
    Private _WatermarkText As String

#End Region

#Region "   コンストラクタ"

    Public Sub New()
        Call InitializeComponent()

        _WatermarkColor = SystemColors.GrayText
        _BackColorOrg = BackColor
        GotFocusedColor = clrControlGotFocusedColor
        _ActiveBackColor = clrControlDefaultBackColor
        _InvalidBackColor = clrDisableControlGotFocusedColor

        ImeMode = Windows.Forms.ImeMode.On
        EnterBehavior = 0
        ShowRemainingChars = True

    End Sub

#End Region

#Region "プロパティ"

#Region "   BackColor"

    <Bindable(True), Category("Appearance")>
    Overrides Property BackColor As Color
        Get
            Return MyBase.BackColor
        End Get
        Set(ByVal value As Color)
            If value <> Color.Transparent Then MyBase.BackColor = value
        End Set
    End Property

#End Region

#Region "   EnterBehavior"

    <Category("動作"),
     DefaultValue(0),
     Description("0:通常、1:次の項目へ移動するため、Tabコマンドを送信する")>
    Public Property EnterBehavior As Integer

#End Region

#Region "   ForeColor"

    Public Overrides Property ForeColor As Color
        Get
            If DesignMode Then
                Return _ForeColor
            Else
                Return MyBase.ForeColor
            End If
        End Get
        Set(value As Color)
            _ForeColor = value
            If _HasWatermark Then
            Else
                MyBase.ForeColor = value
            End If
        End Set
    End Property

#End Region

#Region "   GotFocusedColor"

    <Bindable(True), Category("Appearance"), DefaultValue(GetType(Color), "190, 180, 255")>
    Property GotFocusedColor As Color

#End Region

#Region "   InputRequired"

    Public Property InputRequired As Boolean
        Get
            Return _InputRequired
        End Get
        Set(value As Boolean)
            _InputRequired = value
            If value Then
                WatermarkText = "<必須>"
                WatermarkColor = Color.Red
            Else
                WatermarkText = _WatermarkText
                WatermarkColor = _ForeColor
            End If
        End Set
    End Property

#End Region

#Region "   MaxByteLength"

    <Category("動作"),
     DefaultValue(1000),
     Description("エディット コントロールに入力できる最大文字バイト数を指定します。0の場合は実質無制限")>
    Public Property MaxByteLength As Integer

#End Region

#Region "   OldValue"

    ''' <summary>
    ''' 変更前の値を取得します
    ''' </summary>
    ''' <returns></returns>
    <Browsable(False)>
    Public ReadOnly Property OldValue As String
        Get
            Return _OldValue
        End Get
    End Property

#End Region

#Region "   ReadOnly"

    <DefaultValue(False)>
    Protected Shadows Property [ReadOnly] As Boolean 'Implements IReadOnly.ReadOnly
        Get
            Return MyBase.ReadOnly
        End Get
        Set(value As Boolean)
            MyBase.ReadOnly = value
            If value Then
                BackColor = _InvalidBackColor
            Else
                BackColor = _BackColorOrg
            End If
            'SetStyle(ControlStyles.UserMouse, value)
            'SetStyle(ControlStyles.Selectable, value)
        End Set
    End Property

#End Region

#Region "   SelectAllText"

    <Category("動作"),
     DefaultValue(True),
     Description("Focus時の全選択を設定します。")>
    Public Property SelectAllText As Boolean

#End Region

#Region "   ShowRemainingChars"

    <Bindable(True), Category("Appearance"), DefaultValue(False)>
    Public Property ShowRemainingChars As Boolean

#End Region

#Region "   WatermarkColor"

    ''' <summary>
    ''' テキストが空の場合に表示する文字列の色を取得・設定します。
    ''' </summary>
    ''' <returns></returns>
    <Category("表示")>
    <DefaultValue(GetType(Color), "GrayText")>
    <Description("テキストが空の場合に表示する文字列の色です。")>
    Public Property WatermarkColor As Color
        Get
            Return _WatermarkColor
        End Get
        Set(value As Color)
            _WatermarkColor = value
            Me.Invalidate() 'Call TrySetWatermark()
        End Set
    End Property

#End Region

#Region "   WatermarkText"

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
            Return _WatermarkText
        End Get
        Set(value As String)
            _WatermarkText = value
            Me.Invalidate() 'Call TrySetWatermark()
        End Set
    End Property

#End Region

#End Region

#Region "イベント"

#Region "   OnChar"

    ''' <summary>
    ''' 文字データのクライアント領域への送信時
    ''' </summary>
    ''' <param name="e"></param>
    Protected Overridable Sub OnChar(e As KeyPressEventArgs)
        If Char.IsControl(e.KeyChar) Then Return

        '---入力を最大文字バイト数に制限
        Dim sjisEncoding As System.Text.Encoding = System.Text.Encoding.GetEncoding("Shift_JIS")
        Dim textByteCount As Integer = sjisEncoding.GetByteCount(Me.Text)
        Dim inputByteCount As Integer = sjisEncoding.GetByteCount(e.KeyChar.ToString())
        Dim selectedTextByteCount As Integer = sjisEncoding.GetByteCount(Me.SelectedText)

        If Me.MaxByteLength > 0 AndAlso textByteCount + inputByteCount - selectedTextByteCount > Me.MaxByteLength Then
            e.Handled = True
        End If
    End Sub

#End Region

#Region "   OnEnabledChanged"

    Protected Overrides Sub OnEnabledChanged(e As EventArgs)
        If Enabled Then
            If [ReadOnly] Then
                MyBase.BackColor = _InvalidBackColor
            Else
                MyBase.BackColor = _ActiveBackColor
            End If
        Else
            MyBase.BackColor = _InvalidBackColor
        End If

        MyBase.OnEnabledChanged(e)
    End Sub

#End Region

#Region "   OnEnter"

    Protected Overrides Sub OnEnter(e As EventArgs)
        _OldValue = Me.Text

        If SelectAllText Then BeginInvoke(Sub() If Me IsNot Nothing Then SelectAll())

        MyBase.OnEnter(e)
    End Sub

#End Region

#Region "   OnGotFocus"

    Protected Overrides Sub OnGotFocus(e As EventArgs)

        If [ReadOnly] Then
            MyBase.BackColor = _InvalidBackColor
        Else
            MyBase.BackColor = GotFocusedColor
        End If

        MyBase.OnGotFocus(e)
    End Sub

#End Region

#Region "   OnKeyDown"

    Protected Overrides Sub OnKeyDown(e As KeyEventArgs)

        If e.KeyCode = Keys.Escape Or
            ((e.KeyCode = Windows.Forms.Keys.Z) And (e.Modifiers = Keys.Control)) Then

            If CanUndo = True Then
                Undo()
            End If
        End If

        MyBase.OnKeyDown(e)
    End Sub

#End Region

#Region "   OnLostFocus"

    Protected Overrides Sub OnLostFocus(e As EventArgs)

        If [ReadOnly] Then
            MyBase.BackColor = _InvalidBackColor
        Else
            MyBase.BackColor = _ActiveBackColor
        End If

        MyBase.OnLostFocus(e)
    End Sub

#End Region

#Region "   OnMouseDown"

    Protected Overrides Sub OnMouseDown(e As MouseEventArgs)
        If e.Button = MouseButtons.Right Then
            Capture = False
        End If

        MyBase.OnMouseDown(e)
    End Sub

#End Region

#Region "   OnMouseHover"

    Protected Overrides Sub OnMouseHover(e As EventArgs)
        MyBase.Focus()
        MyBase.OnMouseHover(e)
    End Sub

#End Region

#Region "   OnPaste"

    Protected Overridable Sub OnPaste(e As EventArgs)
        Dim inputText As String = ""
        Dim sjisEncoding As System.Text.Encoding = System.Text.Encoding.GetEncoding("Shift_JIS")
        Dim selectedTextByteCount As Integer

        Dim clipboardText As Object = Clipboard.GetDataObject().GetData(System.Windows.Forms.DataFormats.Text)

        If clipboardText Is Nothing Then Return

        If MaxLength = 0 Or MaxByteLength = 0 Then
            SelectedText = inputText
        Else
            '---ペーストを最大文字バイト数に制限
            If MaxLength * 2 >= MaxByteLength Then

                inputText = clipboardText.ToString()
                Dim textByteCount As Integer = sjisEncoding.GetByteCount(Me.Text)
                Dim inputByteCount As Integer = sjisEncoding.GetByteCount(inputText)
                selectedTextByteCount = sjisEncoding.GetByteCount(SelectedText)
                Dim remainByteCount As Integer = MaxByteLength - (textByteCount - selectedTextByteCount)

                If remainByteCount <= 0 Or MaxByteLength - (textByteCount + inputByteCount) <= 0 Then Return

                If remainByteCount >= inputByteCount Then
                    SelectedText = inputText
                Else
                    textByteCount = sjisEncoding.GetByteCount(inputText)
                    If textByteCount > MaxByteLength Then
                        SelectedText = ClsPubMethod.MidB(inputText, 1, MaxByteLength)
                    Else
                        SelectedText = inputText.Substring(0, remainByteCount)
                    End If
                End If
            End If
        End If
    End Sub

#End Region

#Region "   OnReadOnlyChanged"

    Protected Overrides Sub OnReadOnlyChanged(e As EventArgs)

        If [ReadOnly] Then
            MyBase.BackColor = _InvalidBackColor
        Else
            MyBase.BackColor = _ActiveBackColor
        End If
        MyBase.OnReadOnlyChanged(e)
    End Sub

#End Region

#Region "   OnTextChanged"

    Protected Overrides Sub OnTextChanged(e As EventArgs)

        Me.Refresh()
        MyBase.OnTextChanged(e)
        If ShowRemainingChars Then
            Using g As Graphics = Graphics.FromHwnd(Handle)
                'テキストボックス内に残り入力可能文字数を描画
                TextRenderer.DrawText(g,
                                      "残り " & (MaxLength - (Text.ToString.Length)).ToString("000") & "文字",
                                      New Font(Font.Name, Font.Size, FontStyle.Bold, GraphicsUnit.Point, CType(128, Byte)),
                                      ClientRectangle,
                                      SystemColors.GrayText,
                                      Color.Transparent,
                                      TextFormatFlags.Bottom Or TextFormatFlags.Right)
            End Using
        End If
    End Sub

#End Region

#Region "   ProcessDialogKey"

    Protected Overrides Function ProcessDialogKey(keyData As Keys) As Boolean
        'Returnキーが押されているか調べる
        'AltかCtrlキーが押されている時は、本来の動作をさせる
        If ((keyData And Keys.KeyCode) = Keys.Return) AndAlso
            ((keyData And (Keys.Alt Or Keys.Control)) = Keys.None) Then
            'Tabキーを押した時と同じ動作をさせる
            'Shiftキーが押されている時は、逆順にする
            'Me.ProcessDialogKey(Keys.Tab)
            'If (keyData And Keys.KeyCode) = (Keys.Enter Or Keys.Shift) Then
            If keyData = (Keys.Enter Or Keys.Shift) Then
                Me.ProcessDialogKey((Keys.Tab Or Keys.Shift))
            Else
                Me.ProcessDialogKey(Keys.Tab)
            End If

            '本来の処理はさせない
            Return True
        End If

        Return MyBase.ProcessDialogKey(keyData)
    End Function

#End Region

#Region "   WndProc"

    '-----入力・ペーストのWINDOWSメッセージを取得
    <System.Diagnostics.DebuggerStepThrough()>
    Protected Overrides Sub WndProc(ByRef m As System.Windows.Forms.Message)
        Const WM_CHAR As Integer = &H102
        Const WM_PASTE As Integer = &H302
        Const WM_PAINT As Integer = &HF
        'Const WM_CONTEXTMENU As Integer = &H7B

        Select Case m.Msg
            Case WM_CHAR
                Dim eKeyPress As New KeyPressEventArgs(Microsoft.VisualBasic.ChrW(m.WParam.ToInt32()))
                Me.OnChar(eKeyPress)

                If eKeyPress.Handled Then
                    Return
                End If

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
                                              New Font(Font.Name, Font.Size, FontStyle.Regular, GraphicsUnit.Point, CType(128, Byte)),
                                              rect,
                                              _WatermarkColor,
                                              TextFormatFlags.Top Or TextFormatFlags.Left)
                    End Using
                End If

                'CHECK: 右クリック無効の場合は、コメントアウト解除
                'Case WM_CONTEXTMENU
                '    Return
        End Select

        MyBase.WndProc(m)
    End Sub

#End Region

#End Region

#Region "メソッド"

#Region "Undo"

    Public Overloads Sub Undo()
        Me.Text = Me.OldValue
    End Sub

#End Region

#End Region

#Region "ローカル関数"

#Region "TrySetWatermark"

    Private Function TrySetWatermark() As Boolean
        If _WatermarkText.IsNulOrWS = False And
            MyBase.Text.IsNulOrWS = True And
            MyBase.Focused = False Then

            'ウォーターマーク設定
            MyBase.ForeColor = WatermarkColor
            MyBase.Text = _WatermarkText
            _HasWatermark = True

            Return True
        Else
            _HasWatermark = False
            Return False
        End If

    End Function

#End Region

#Region "   ResetWatermark"
    Private Sub ResetWatermark(ByVal value As String)
        If value IsNot Nothing Then
            MyBase.Text = value
        End If
        MyBase.ForeColor = _ForeColor
        _HasWatermark = False
    End Sub
#End Region

#End Region

End Class