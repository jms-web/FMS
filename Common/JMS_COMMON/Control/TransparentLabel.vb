''' α値を設定可能なLabelコントロール。
''' </summary>
''' <remarks></remarks>
Public Class TransparentLabel
    Inherits Label

    Private _BackAlpha As Integer = 0 '背景のα値（0～255、0で透明）

    ''' <summary>
    ''' 背景のα値を取得または設定します。
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    <System.ComponentModel.DefaultValue(GetType(Integer), "0"),
     System.ComponentModel.Description("背景のα値を取得または設定します。(0～255)")>
    Public Property BackAlpha As Integer
        Get
            Return _BackAlpha
        End Get
        Set(value As Integer)
            If value < 0 Then
                value = 0
            ElseIf value > 255 Then
                value = 255
            End If
            _BackAlpha = value
            Me.Redraw()
        End Set
    End Property

    ''' <summary>
    ''' 再描画を行う。
    ''' </summary>
    ''' <remarks></remarks>
    Public Sub Redraw()
        If _BackAlpha = 255 Then
            Me.Invalidate()
        Else
            '半透明or透明の場合、親が先に描画される必要があるため、親をInvalidate
            If Not IsNothing(Parent) Then
                Parent.Invalidate(New Rectangle(Me.Left, Me.Top, Me.Width, Me.Height), True)
            End If
        End If
    End Sub

    Public Sub New()
        Me.SetStyle(ControlStyles.UserPaint, True)                    'コントロールを独自描画する
        Me.SetStyle(ControlStyles.SupportsTransparentBackColor, True) 'α値を有効にする
        Me.SetStyle(ControlStyles.Opaque, True)                       '背景自動描画OFF
        Me.SetStyle(ControlStyles.OptimizedDoubleBuffer, False)       'Falseにしないと表示がおかしくなる
    End Sub

    Protected Overrides ReadOnly Property CreateParams As System.Windows.Forms.CreateParams
        Get
            'WS_EX_TRANSPARENT
            'このスタイルで作成されたウィンドウは透明になります。 
            'このスタイルで作成されたウィンドウは、そのウィンドウの下にある
            '兄弟ウィンドウがすべて更新された後にだけ、 WM_PAINT メッセージを受け取ります。 
            Const WS_EX_TRANSPARENT As Integer = &H20

            Dim params As CreateParams = MyBase.CreateParams
            params.ExStyle = params.ExStyle Or WS_EX_TRANSPARENT
            Return params
        End Get
    End Property

    Protected Overrides Sub OnPaint(e As System.Windows.Forms.PaintEventArgs)

        If _BackAlpha > 0 Then
            'α値を設定して背景を描画
            Dim argb As Integer = (Me.BackColor.ToArgb And &HFFFFFF) Or (Me._BackAlpha << 24)
            Using br As New SolidBrush(Color.FromArgb(argb))
                Dim g As Graphics = e.Graphics
                g.FillRectangle(br, g.VisibleClipBounds)
            End Using
        End If

        '基底クラスOnPaint呼び出し（文字を書いてもらう）
        MyBase.OnPaint(e)
    End Sub

End Class