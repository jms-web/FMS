Imports JMS_COMMON.ClsPubMethod

Public Class FrmBaseStsBtn

#Region "変数・定数"
    Public cmdFunc() As System.Windows.Forms.Button 'ボタン配列
#End Region

#Region "プロパティ"

#End Region

#Region "コンストラクタ"
    ''' <summary>
    ''' コンストラクタ
    ''' </summary>
    ''' <remarks>コンストラクタ</remarks>
    Public Sub New()

        ' この呼び出しはデザイナーで必要です。
        InitializeComponent()

    End Sub
#End Region

#Region "FORMイベント"

    Private Sub frmBaseStsBtn_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        'アクセントカラー取得 
        'Dim lngColor As Long
        'Dim blnRET As Boolean
        'Call Util.DwmGetColorizationColor(lngColor, blnRET)
        'Dim clrAccent As Color = Util.mdlDWM.GetColorFromInt64(lngColor)
        'Me.BackColor = clrAccent

        '-----ボタン配列
        'ボタン配列の作成
        Me.cmdFunc = New System.Windows.Forms.Button(11) {}

        'ボタン配列に画面に置いたボタンを代入
        Me.cmdFunc(0) = Me.cmdFunc1
        Me.cmdFunc(1) = Me.cmdFunc2
        Me.cmdFunc(2) = Me.cmdFunc3
        Me.cmdFunc(3) = Me.cmdFunc4
        Me.cmdFunc(4) = Me.cmdFunc5
        Me.cmdFunc(5) = Me.cmdFunc6
        Me.cmdFunc(6) = Me.cmdFunc7
        Me.cmdFunc(7) = Me.cmdFunc8
        Me.cmdFunc(8) = Me.cmdFunc9
        Me.cmdFunc(9) = Me.cmdFunc10
        Me.cmdFunc(10) = Me.cmdFunc11
        Me.cmdFunc(11) = Me.cmdFunc12

        AddHandler cmdFunc1.MouseMove, AddressOf cmdFunc_MouseMove
        AddHandler cmdFunc2.MouseMove, AddressOf cmdFunc_MouseMove
        AddHandler cmdFunc3.MouseMove, AddressOf cmdFunc_MouseMove
        AddHandler cmdFunc4.MouseMove, AddressOf cmdFunc_MouseMove
        AddHandler cmdFunc5.MouseMove, AddressOf cmdFunc_MouseMove
        AddHandler cmdFunc6.MouseMove, AddressOf cmdFunc_MouseMove
        AddHandler cmdFunc7.MouseMove, AddressOf cmdFunc_MouseMove
        AddHandler cmdFunc8.MouseMove, AddressOf cmdFunc_MouseMove
        AddHandler cmdFunc9.MouseMove, AddressOf cmdFunc_MouseMove
        AddHandler cmdFunc10.MouseMove, AddressOf cmdFunc_MouseMove
        AddHandler cmdFunc11.MouseMove, AddressOf cmdFunc_MouseMove
        AddHandler cmdFunc12.MouseMove, AddressOf cmdFunc_MouseMove

    End Sub

    Private Sub frmBaseStsBtn_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles MyBase.KeyDown
        Dim KeyCode As Short = e.KeyCode


        '押下されたキーコード取得
        KeyCode = e.KeyCode

        'F1～F12
        If KeyCode >= Windows.Forms.Keys.F1 And KeyCode <= Windows.Forms.Keys.F12 Then
            'F10時に異常動作するのでゴミ消し
            e.Handled = True
            '該当ボタンCLICKイベント生成
            cmdFunc(KeyCode - 112).PerformClick()
        End If

        'ENTERキー
        If KeyCode = Windows.Forms.Keys.Return Then
            'System.Windows.Forms.SendKeys.Send("{TAB}")
        End If

    End Sub

    Overridable Sub FrmBaseStsBtn_Resize(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Resize
        If Me.Visible = False Then Exit Sub

        If Me.DesignMode = True Then Exit Sub

        ''===================================
        ''   ボタン位置、サイズ設定
        ''===================================
        Call SetButtonSize(Me.Width, cmdFunc)

    End Sub

    Protected Friend Sub cmdFunc_MouseMove(sender As Object, e As MouseEventArgs)
        Dim control As Control = GetChildAtPoint(e.Location)
        If control IsNot Nothing Then
            MyBase.ToolTip.Active = Not control.Enabled
        End If
    End Sub

#End Region

End Class