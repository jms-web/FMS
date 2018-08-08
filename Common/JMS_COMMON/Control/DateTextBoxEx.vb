'----------------------------------------
'変更履歴
'2007/06/01 ユーザーコントロールとして作成、datetimepickerのtextbox領域を値クリア可能にする為maskedtextboxに置き換え
'2007/09/01 フォントはオーナーのものを使用
'2007/09/03 maskedtextbox領域をフォーカス時全選択にする為、maskedtextboxexに置き換え
'2007/10/15 DisplayFormatプロパティ付加(yyyyMMdd,yyyyMM)
'2007/10/15 LOSTFOCUS時、空欄以外の不正値なら以前の値に復帰
'2007/10/24 Valueプロパティ付加(yyyy/MM/dd形式)
'2007/11/01 継承を許可、Textプロパティへ""セット許可
'2008/01/15 2008/01/2まで入力すると2008/01/02に予測変換される不具合修正
'2017.09.11 DisplayFormat=yyyyMM時、カレンダーを年月表示に固定
'2017.10.17 MinDate MaxDateプロパティ付加
'----------------------------------------

Imports System.ComponentModel

<DefaultEvent("TxtChanged")>
Public Class DateTextBoxEx
    Inherits UserControl


#Region "メンバ"
    Friend WithEvents DateTimePicker1 As System.Windows.Forms.DateTimePicker
    Private Const _strMaxDate As String = "9998/12/31"
    Private Const _strMinDate As String = "1753/01/01"

    Private _blnNullable As Boolean = False

    'YYYYYMM選択用
    Private intYear As Integer


    Private _oldValue As String

    Private _GotForcusedColor As Color 'フォーカス時の背景色
    Private _BackColorDefault As Color 'フォーカス喪失時時の背景色

    Private _BackColorOrg As System.Drawing.Color
    Private _ReadOnly As Boolean
    Private _CursorOrg As Cursor
#End Region

#Region "コンストラクタ"
    Public Sub New()
        InitializeComponent()

        Me._GotForcusedColor = clrControlGotFocusedColor
        Me._BackColorDefault = clrControlDefaultBackColor

    End Sub
#End Region

#Region "プロパティ"
#Region "　DisplayFormat プロパティ (Overridable)　"
    '-----年月日表示フォーマットを指定します。
    Public Enum EnumType As Byte
        yyyyMMdd = 0
        yyyyMM = 1
    End Enum

    Private _DisplayFormat As EnumType = EnumType.yyyyMMdd

    <Browsable(True),
         Category("CustomProperty"),
         DefaultValue(GetType(EnumType), "yyyyMMdd"),
         Description("年月日表示フォーマットを指定します。"),
         RefreshProperties(RefreshProperties.All),
         DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)>
    Public Property DisplayFormat() As EnumType
        Get
            Return Me._DisplayFormat
        End Get

        Set(ByVal value As EnumType)
            If Me._DisplayFormat <> value Then
                Me._DisplayFormat = value

                If Me._DisplayFormat = EnumType.yyyyMMdd Then
                    Me.DateTimePicker1.CustomFormat = "yyyy/MM/dd"
                    Me.MaskedTextBox1.Mask = "0000/00/00"
                ElseIf Me._DisplayFormat = EnumType.yyyyMM Then
                    Me.DateTimePicker1.CustomFormat = "yyyy/MM"
                    Me.MaskedTextBox1.Mask = "0000/00"
                End If
            End If
        End Set
    End Property
#End Region

#Region "Text:テキストボックス表示値を取得・設定"
    <Browsable(True),
         Category("CustomProperty"),
         Description("テキストボックス表示値を取得・設定"),
         RefreshProperties(RefreshProperties.All),
         DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)>
    Public Shadows Property Text() As String
        Get
            Return Me.MaskedTextBox1.Text
        End Get

        Set(ByVal value As String)
            Dim intRET As Integer
            '日付チェック
            intRET = FunDateLimit(value)
            If intRET = 0 Then
                If Me.DisplayFormat = EnumType.yyyyMMdd Then
                    Me.MaskedTextBox1.Text = DateTime.Parse(value).ToString("yyyy/MM/dd")
                ElseIf Me.DisplayFormat = EnumType.yyyyMM Then
                    Me.MaskedTextBox1.Text = DateTime.Parse(value).ToString("yyyy/MM")
                End If

            ElseIf intRET = -2 Then '日付無し時
                If Me.DisplayFormat = EnumType.yyyyMMdd Then
                    Me.MaskedTextBox1.Text = "____/__/__"
                ElseIf Me.DisplayFormat = EnumType.yyyyMM Then
                    Me.MaskedTextBox1.Text = "____/__"
                End If

            Else '不正日付時
                Exit Property
            End If

        End Set
    End Property
#End Region

#Region "Value:コントロールの現在値を取得･設定(yyyy/MM/dd形式)"
    <Browsable(True),
         Category("CustomProperty"),
         Description("コントロールの現在値を取得･設定(yyyy/MM/dd形式)"),
         RefreshProperties(RefreshProperties.All),
         DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)>
    Public Shadows Property Value() As String
        Get
            If Me.MaskedTextBox1.Text.Replace("/", "").IsNullOrWhiteSpace = True Then
                '未入力時
                Return ""
            Else
                Return Me.DateTimePicker1.Value.ToString("yyyy/MM/dd")
            End If
        End Get

        Set(ByVal value As String)
            '日付チェック
            If FunDateLimit(value) <> 0 Then
                Exit Property
            End If

            Me.DateTimePicker1.Value = DateTime.Parse(value)
            Me.MaskedTextBox1.Text = Me.DateTimePicker1.Text
        End Set
    End Property
#End Region

#Region "ValueDate:コントロールの現在値を取得(Date形式)"
    <Browsable(True),
         Category("CustomProperty"),
         Description("コントロールの現在値を取得･設定(Date形式)"),
         RefreshProperties(RefreshProperties.All),
         DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)>
    Public ReadOnly Property ValueDate As Date
        Get
            Return Me.DateTimePicker1.Value
        End Get
    End Property
#End Region

#Region "ValueNonFormat:コントロールの現在値を取得･設定(yyyyMMdd形式)"
    <Browsable(True),
         Category("CustomProperty"),
         Description("コントロールの現在値を取得･設定(yyyyMMdd形式)"),
         RefreshProperties(RefreshProperties.All),
         DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)>
    Public Shadows Property ValueNonFormat() As String
        Get
            If Me.MaskedTextBox1.Text.Replace("/", "").IsNullOrWhiteSpace = True Then
                Return ""
            Else
                Select Case Me.DisplayFormat
                    Case EnumType.yyyyMM
                        Return Me.DateTimePicker1.Value.ToString("yyyyMM")
                    Case EnumType.yyyyMMdd
                        Return Me.DateTimePicker1.Value.ToString("yyyyMMdd")
                    Case Else
                        Return ""
                End Select
            End If
        End Get

        Set(ByVal value As String)
            Dim dt As DateTime
            Select Case Me.DisplayFormat
                Case EnumType.yyyyMM
                    DateTime.TryParseExact(value, "yyyyMM", Nothing, Globalization.DateTimeStyles.None, dt)
                Case EnumType.yyyyMMdd
                    DateTime.TryParseExact(value, "yyyyMMdd", Nothing, Globalization.DateTimeStyles.None, dt)
                Case Else
                    Me.MaskedTextBox1.Text = ""
                    Exit Property
            End Select

            '日付チェック
            If FunDateLimit(dt) <> 0 Then
                Me.MaskedTextBox1.Text = ""
                Exit Property
            End If

            Me.DateTimePicker1.Value = dt
            Me.MaskedTextBox1.Text = Me.DateTimePicker1.Text
        End Set
    End Property
#End Region

#Region "BackColor:テキストボックスBACKCOLORを取得・設定"
    <Browsable(True),
         Category("CustomProperty"),
         Description("テキストボックスBACKCOLORを取得・設定"),
         RefreshProperties(RefreshProperties.All),
         DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)>
    Public Shadows Property BackColor() As System.Drawing.Color
        Get
            Return Me.MaskedTextBox1.BackColor
        End Get
        Set(ByVal value As System.Drawing.Color)
            Me.MaskedTextBox1.BackColor = value
            _BackColorDefault = value
        End Set
    End Property
#End Region

#Region "MinDate:設定可能な最小日付"
    <Browsable(True),
         Category("CustomProperty"),
         Description("DateTimePicker指定可能な最小日付を取得・設定"),
         RefreshProperties(RefreshProperties.All),
         DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)>
    <System.ComponentModel.DefaultValueAttribute(_strMinDate)>
    Public Shadows Property MinDate() As Date
        Get
            Return Me.DateTimePicker1.MinDate
        End Get
        Set(ByVal value As Date)
            Me.DateTimePicker1.MinDate = value
        End Set
    End Property
#End Region

#Region "MaxDate:設定可能な最大日付"
    <Browsable(True),
         Category("CustomProperty"),
         Description("DateTimePicker指定可能な最大日付を取得・設定"),
         RefreshProperties(RefreshProperties.All),
         DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)>
    <System.ComponentModel.DefaultValueAttribute(_strMaxDate)>
    Public Shadows Property MaxDate() As Date
        Get
            Return Me.DateTimePicker1.MaxDate
        End Get
        Set(ByVal value As Date)
            Me.DateTimePicker1.MaxDate = value
        End Set
    End Property
#End Region

#Region "Nullable:空欄の許可"
    <Browsable(True),
         Category("CustomProperty"),
         Description("空の日付を許可するかを取得・設定"),
         RefreshProperties(RefreshProperties.All),
         DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)>
    <System.ComponentModel.DefaultValueAttribute(False)>
    Public Property Nullable() As Boolean
        Get
            Return _blnNullable
        End Get
        Set(ByVal value As Boolean)
            _blnNullable = value
        End Set
    End Property

#End Region

#Region "OldValue"

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

#End Region

#Region "メソッド"
#Region "InitializeComponent:コントロール配置"
    Private Sub InitializeComponent()
        Me.DateTimePicker1 = New System.Windows.Forms.DateTimePicker()
        Me.MaskedTextBox1 = New JMS_COMMON.MaskedTextBoxEx()
        Me.SuspendLayout()
        '
        'DateTimePicker1
        '
        Me.DateTimePicker1.CalendarForeColor = System.Drawing.Color.Black
        Me.DateTimePicker1.Cursor = System.Windows.Forms.Cursors.Default
        Me.DateTimePicker1.CustomFormat = "yyyy/MM/dd"
        Me.DateTimePicker1.Dock = System.Windows.Forms.DockStyle.Right
        Me.DateTimePicker1.Font = New System.Drawing.Font("Meiryo UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.DateTimePicker1.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.DateTimePicker1.Location = New System.Drawing.Point(81, 0)
        Me.DateTimePicker1.Margin = New System.Windows.Forms.Padding(0)
        Me.DateTimePicker1.Name = "DateTimePicker1"
        Me.DateTimePicker1.Size = New System.Drawing.Size(17, 24)
        Me.DateTimePicker1.TabIndex = 0
        Me.DateTimePicker1.TabStop = False
        '
        'MaskedTextBox1
        '
        Me.MaskedTextBox1.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.MaskedTextBox1.BackColor = System.Drawing.SystemColors.Window
        Me.MaskedTextBox1.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.MaskedTextBox1.Font = New System.Drawing.Font("Meiryo UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.MaskedTextBox1.GotFocusedColor = System.Drawing.Color.FromArgb(CType(CType(190, Byte), Integer), CType(CType(180, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.MaskedTextBox1.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.MaskedTextBox1.InputRequired = False
        Me.MaskedTextBox1.Location = New System.Drawing.Point(2, 3)
        Me.MaskedTextBox1.Margin = New System.Windows.Forms.Padding(1)
        Me.MaskedTextBox1.Mask = "0000/00/00"
        Me.MaskedTextBox1.MaxByteLength = 10
        Me.MaskedTextBox1.Name = "MaskedTextBox1"
        Me.MaskedTextBox1.Size = New System.Drawing.Size(79, 17)
        Me.MaskedTextBox1.TabIndex = 1
        Me.MaskedTextBox1.ValidatingType = GetType(Date)
        Me.MaskedTextBox1.WatermarkColor = System.Drawing.Color.Empty
        Me.MaskedTextBox1.WatermarkText = Nothing
        '
        'DateTextBoxEx
        '
        Me.BackColor = System.Drawing.SystemColors.Window
        Me.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Controls.Add(Me.DateTimePicker1)
        Me.Controls.Add(Me.MaskedTextBox1)
        Me.MinimumSize = New System.Drawing.Size(98, 24)
        Me.Name = "DateTextBoxEx"
        Me.Size = New System.Drawing.Size(98, 24)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
#End Region
#End Region

#Region "イベント"

#Region "ユーザーコントロールにTEXT値が変更時のイベントを追加"
    Public Event TxtChanged(ByVal sender As Object, ByVal e As System.EventArgs)
#End Region

#Region "MaskedTextBox1_TextChanged:TEXT値が変更時"
    Private Sub MaskedTextBox1_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MaskedTextBox1.TextChanged
        Dim strBUFF As String = ""

        '正常日付時
        If FunDateLimit(Me.MaskedTextBox1.Text) = 0 Then
            If Me.DateTimePicker1.Text <> Me.MaskedTextBox1.Text Then
                If Me.DisplayFormat = EnumType.yyyyMMdd Then
                    strBUFF = Me.MaskedTextBox1.Text
                ElseIf Me.DisplayFormat = EnumType.yyyyMM Then
                    strBUFF = Me.MaskedTextBox1.Text & "/" & Me.DateTimePicker1.Value.ToString("dd")
                End If

                If DateTime.Parse(strBUFF) <= Me.DateTimePicker1.MaxDate And DateTime.Parse(strBUFF) >= Me.DateTimePicker1.MinDate Then
                    Me.DateTimePicker1.Value = DateTime.Parse(strBUFF)
                Else
                    MessageBox.Show("入力された日付は有効範囲外のため使用出来ません。", "日付入力範囲エラー", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    Me.MaskedTextBox1.Text = ""
                    Exit Sub
                End If
            End If

            'ユーザーコントロールのイベント起動
            RaiseEvent TxtChanged(Me, System.EventArgs.Empty)
        Else
            'MessageBox.Show("不正な日付形式が入力されました。。", "日付形式エラー", MessageBoxButtons.OK, MessageBoxIcon.Information)

            If _blnNullable = True Then
                'Me.MaskedTextBox1.Text = ""
                ''ユーザーコントロールのイベント起動
                'RaiseEvent TxtChanged(Me, System.EventArgs.Empty)
            End If
            Exit Sub
        End If
    End Sub
#End Region

#Region "ユーザーコントロールにVALUE値が変更時のイベントを追加"
    Public Event DateValueChanged(ByVal sender As Object, ByVal e As System.EventArgs)
#End Region

#Region "MaskedTextBox1_TextChanged:VALUE値が変更時"
    Private Sub DateTimePicker1_DateValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DateTimePicker1.ValueChanged
        If Me.DisplayFormat = EnumType.yyyyMMdd Then
            If Me.MaskedTextBox1.Text <> Me.DateTimePicker1.Value.ToString("yyyy/MM/dd") Then
                Me.MaskedTextBox1.Text = Me.DateTimePicker1.Value.ToString("yyyy/MM/dd")
            End If

        ElseIf Me.DisplayFormat = EnumType.yyyyMM Then
            If Me.MaskedTextBox1.Text <> Me.DateTimePicker1.Value.ToString("yyyy/MM") Then
                Me.MaskedTextBox1.Text = Me.DateTimePicker1.Value.ToString("yyyy/MM")

                If intYear = Me.DateTimePicker1.Value.Year Then
                    SendKeys.SendWait("{ENTER}")
                Else
                    intYear = Me.DateTimePicker1.Value.Year
                End If
            End If
        End If

        'ユーザーコントロールのイベント起動
        RaiseEvent DateValueChanged(sender, System.EventArgs.Empty)
    End Sub
#End Region

#Region "DateTextBox_LOSTFOCUS"
    Private Sub DateTextBox_Leave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Leave
        Dim intRET As Integer
        Dim strBUFF As String = ""

        '日付チェック
        intRET = FunDateLimit(Me.MaskedTextBox1.Text)

        '日付値以外時
        If intRET = -1 Or intRET = -2 Then
            If Me.MaskedTextBox1.Text.Replace("/", "").IsNullOrWhiteSpace = True Then
                '未入力時
                Exit Sub
            Else
                '以前の値に復帰
                If Me.DisplayFormat = EnumType.yyyyMMdd Then
                    Me.MaskedTextBox1.Text = Me.DateTimePicker1.Value.ToString("yyyy/MM/dd")
                ElseIf Me.DisplayFormat = EnumType.yyyyMM Then
                    Me.MaskedTextBox1.Text = Me.DateTimePicker1.Value.ToString("yyyy/MM")
                End If
                Exit Sub
            End If
        End If

        '日付範囲外時
        If intRET = 1 Then
            '以前の値に復帰
            If Me.DisplayFormat = EnumType.yyyyMMdd Then
                Me.MaskedTextBox1.Text = Me.DateTimePicker1.Value.ToString("yyyy/MM/dd")
            ElseIf Me.DisplayFormat = EnumType.yyyyMM Then
                Me.MaskedTextBox1.Text = Me.DateTimePicker1.Value.ToString("yyyy/MM")
            End If
            Exit Sub
        End If

        '正常日付時
        'ブランク等を0詰めフォーマット
        If Me.DisplayFormat = EnumType.yyyyMMdd Then
            strBUFF = DateTime.Parse(Me.MaskedTextBox1.Text).ToString("yyyy/MM/dd")
        ElseIf Me.DisplayFormat = EnumType.yyyyMM Then
            strBUFF = DateTime.Parse(Me.MaskedTextBox1.Text).ToString("yyyy/MM")
        End If
        If Me.MaskedTextBox1.Text <> strBUFF Then
            Me.MaskedTextBox1.Text = strBUFF
        End If

    End Sub
#End Region

#Region "MaskedTextBox1_Load:コントロールのLoad時"
    'Private Sub DateTextBox_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
    '    'Me.DateTimePicker1.Text = System.DateTime.Now.ToString("yyyy/MM/dd")
    'End Sub
#End Region

#Region "ユーザーコントロールにTEXT値が変更時のイベントを追加"
    '2014.01.20 Add by funato 
    Public Event CloseUp(ByVal sender As Object, ByVal e As System.EventArgs)
#End Region

#Region "DateTimePicker1_CloseUp:カレンダーから日付を選択時"
    Private Sub DateTimePicker1_CloseUp(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DateTimePicker1.CloseUp
        Me.MaskedTextBox1.Text = Me.DateTimePicker1.Text
        Me.MaskedTextBox1.Focus()

        'ユーザーコントロールのイベント起動
        RaiseEvent CloseUp(sender, System.EventArgs.Empty)
    End Sub
#End Region

#Region "カレンダー展開時"
    '2017.09.11 Add by funato
    Private Sub DateTimePicker1_DropDown(sender As Object, e As EventArgs) Handles DateTimePicker1.DropDown
        Dim dtp As DateTimePicker = DirectCast(sender, DateTimePicker)
        intYear = dtp.Value.Year
        If Me.DisplayFormat = EnumType.yyyyMM Then
            SendKeys.Send("^{UP}")
        End If
    End Sub

#End Region

#Region "OnEnter(Overrides)"
    Protected Overrides Sub OnEnter(ByVal e As System.EventArgs)
        _oldValue = Me.Text
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

        If Me.Enabled = False Or Me.ReadOnly = True Then
            MyBase.BackColor = clrDisableControlGotFocusedColor
            MaskedTextBox1.BackColor = clrDisableControlGotFocusedColor
            'DateTimePicker1.Enabled = False
            'MaskedTextBox1.ReadOnly = True
        Else
            'フォーカス時は背景色変更
            MyBase.BackColor = _GotForcusedColor
            MaskedTextBox1.BackColor = _GotForcusedColor
            'DateTimePicker1.Enabled = True
            'MaskedTextBox1.ReadOnly = False
        End If

        MyBase.OnGotFocus(e) '基底クラス呼び出し

    End Sub

    Private Sub MaskedTextBox1_Enter(sender As Object, e As EventArgs) Handles MaskedTextBox1.Enter
        Call OnGotFocus(e)
    End Sub

#End Region
#Region "OnLostFocus(ByVal e As EventArgs)"
    Protected Overrides Sub OnLostFocus(ByVal e As EventArgs)
        If Me.Enabled = False Or Me.ReadOnly = True Then
            MyBase.BackColor = clrDisableControlGotFocusedColor
            MaskedTextBox1.BackColor = clrDisableControlGotFocusedColor
            'DateTimePicker1.Enabled = False
            'MaskedTextBox1.ReadOnly = True
        Else
            'フォーカスがないときは背景色＝白設定
            MyBase.BackColor = _BackColorDefault
            MaskedTextBox1.BackColor = _GotForcusedColor
            'DateTimePicker1.Enabled = True
            'MaskedTextBox1.ReadOnly = False
        End If
        MyBase.OnLostFocus(e) '基底クラス呼び出し
    End Sub

    Private Sub MaskedTextBox1_Leave(sender As Object, e As EventArgs) Handles MaskedTextBox1.Leave
        Call OnLostFocus(e)
    End Sub

#End Region

    Public Property [ReadOnly] As Boolean
        Get
            Return _ReadOnly
        End Get

        Set(ByVal Value As Boolean)
            _ReadOnly = Value
            If Value Then
                Cursor = Cursors.Default
                BackColor = System.Drawing.SystemColors.Control
                MaskedTextBox1.ReadOnly = True
                DateTimePicker1.Enabled = False
                'SetStyle(ControlStyles.UserMouse, True)
                'SetStyle(ControlStyles.Selectable, False)
                'UpdateStyles()
                'RecreateHandle()
            Else
                Cursor = _CursorOrg
                BackColor = _BackColorOrg
                MaskedTextBox1.ReadOnly = False
                DateTimePicker1.Enabled = True
                'SetStyle(ControlStyles.UserMouse, False)
                'SetStyle(ControlStyles.Selectable, True)
                'UpdateStyles()
                'RecreateHandle()
            End If
        End Set
    End Property




#Region "Undo メソッド"
    Public Overloads Sub Undo()
        Me.Text = Me.OldValue
    End Sub
#End Region

#End Region


#Region "関数"
    '日付範囲チェック
    ' 0:範囲内、1:範囲外、-1:不正日付、-2:日付無し
    Private Function FunDateLimit(ByVal strDATE As String) As Integer
        Dim dteBUFF As Date

        '不正日付時
        If strDATE.Replace("/", "").IsNullOrWhiteSpace = True Then
            Return -2
        End If

        '不正日付時
        If Me.DisplayFormat = EnumType.yyyyMMdd Then
            If strDATE.Replace(" ", "").Trim.Length <> 10 Then
                Return -1
            End If

        ElseIf Me.DisplayFormat = EnumType.yyyyMM Then
            If strDATE.Replace(" ", "").Trim.Length <> 7 Then
                Return -1
            End If
        End If


        '不正日付時
        If DateTime.TryParse(strDATE, dteBUFF) = False Then
            Return -1
        End If

        '日付範囲外時
        If dteBUFF.ToString("yyyy/MM/dd") < _strMinDate Then
            Return 1
        End If

        '日付範囲外時
        If dteBUFF.ToString("yyyy/MM/dd") > _strMaxDate Then
            Return 1
        End If

        Return 0

    End Function

    '日付範囲チェック
    ' 0:範囲内、1:範囲外
    Private Function FunDateLimit(ByVal dteDATE As Date) As Integer
        Dim intRET As Integer

        '日付範囲チェック
        intRET = FunDateLimit(dteDATE.ToString("yyyy/MM/dd"))
        Return intRET

    End Function

    Private Sub MaskedTextBox1_Validated(sender As Object, e As EventArgs) Handles MaskedTextBox1.Validated

        If FunDateLimit(Me.MaskedTextBox1.Text) = 0 Then
            If Me.DisplayFormat = EnumType.yyyyMMdd Then
                Me.MaskedTextBox1.Text = Me.DateTimePicker1.Value.ToString("yyyy/MM/dd")
            ElseIf Me.DisplayFormat = EnumType.yyyyMM Then
                Me.MaskedTextBox1.Text = Me.DateTimePicker1.Value.ToString("yyyy/MM")
            End If
        Else
            If _blnNullable = True Then
                Me.MaskedTextBox1.Text = ""
            End If
        End If
    End Sub

    Friend WithEvents MaskedTextBox1 As MaskedTextBoxEx



#End Region


End Class
