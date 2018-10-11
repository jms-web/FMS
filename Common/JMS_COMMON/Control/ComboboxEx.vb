Imports System.ComponentModel
Imports JMS_COMMON.ClsPubMethod

<DefaultEvent("SelectedValueChanged")>
Public Class ComboboxEx
    Inherits ComboBox


#Region "定数・変数"

    'メタ選択肢定数
    Const CON_TOP_ROW_CAPTION_0 As String = "(必須)"
    Const CON_TOP_ROW_CAPTION_1 As String = "(すべて)"
    Const CON_TOP_ROW_CAPTION_2 As String = "(未選択)"
    Const WM_PAINT As Integer = &HF

    Private _BackColorDefault As Color 'フォーカス喪失時時の背景色

    Private _BackColorOrg As System.Drawing.Color
    Private _ReadOnly As Boolean
    Private _CursorOrg As Cursor


    Private _BorderWidth As Integer
    Private _OldValue As String
#End Region

#Region "コンストラクタ"

    Public Sub New()
        InitializeComponent()

        _BackColorOrg = BackColor
        _CursorOrg = Cursor
        GotFocusedColor = clrControlGotFocusedColor
        BorderColor = Color.Gray
        BorderStyle = ButtonBorderStyle.None
        BorderWidth = 1

        'SetDatasourceから移行 SelectedValueChanged等を発火させないため
        DisplayMember = "DISP"
        ValueMember = "VALUE"

        NullValue = " "
    End Sub

#End Region


#Region "プロパティ"


    <DefaultValue(GetType(Color), NameOf(Color.Gray))>
    <Category("表示")>
    Public Property BorderColor As Color

    <DefaultValue(GetType(ButtonBorderStyle), NameOf(ButtonBorderStyle.None))>
    <Category("表示")>
    Public Property BorderStyle As ButtonBorderStyle

    <DefaultValue(1)>
    <Category("表示")>
    Public Property BorderWidth As Integer
        Get
            Return Me._BorderWidth
        End Get
        Set(ByVal value As Integer)
            If value < 0 Then value = 1
            If value > 3 Then value = 3
            Me._BorderWidth = value
        End Set
    End Property

    <DefaultValue(False)>
    Public Property [ReadOnly] As Boolean
        Get
            Return _ReadOnly
        End Get

        Set(ByVal Value As Boolean)
            _ReadOnly = Value
            If Value Then
                Cursor = Cursors.Default
                'DEBUG:Combobox ReadOnly時の背景色
                BackColor = System.Drawing.SystemColors.Control
            Else
                Cursor = _CursorOrg
                BackColor = _BackColorOrg
            End If
            TabStop = Not Value
            SetStyle(ControlStyles.UserMouse, Value)
            SetStyle(ControlStyles.Selectable, Value)
            'UpdateStyles()
            'RecreateHandle()
        End Set
    End Property

    Private _NullValue As Object

    Public Property NullValue As Object
        Get

            If _NullValue Is Nothing Then
                Return " "
            Else
                Return _NullValue
            End If

        End Get
        Set(value As Object)
            _NullValue = value
        End Set
    End Property

    <Bindable(True)>
    <Browsable(True)>
    Public Property HorizontalContentAlignment As StringAlignment

#Region "オーバーロード"

    <System.Diagnostics.DebuggerStepThrough()>
    <Browsable(False)>
    Protected Overrides Sub WndProc(ByRef m As Message)

        MyBase.WndProc(m)

        Select Case m.Msg
            Case WM_PAINT
                Call DrawRectangle()
        End Select
    End Sub

    <Bindable(True)>
    <Browsable(False)>
    Public Overloads Property SelectedValue As Object
        Get
            If TypeOf MyBase.SelectedValue Is String Then
                Select Case MyBase.SelectedValue.ToString
                    Case CON_TOP_ROW_CAPTION_0, CON_TOP_ROW_CAPTION_1, CON_TOP_ROW_CAPTION_2
                        'メタ選択肢の場合は、選択されていないものとする
                        'NullValueが設定されている場合はそれを返す
                        Return NullValue 'Nothing
                    Case Else
                        Return MyBase.SelectedValue
                End Select
            ElseIf TypeOf MyBase.SelectedValue Is Integer Then
                Return Val(MyBase.SelectedValue)
            Else
                Return MyBase.SelectedValue
            End If
        End Get
        Set(value As Object)
            MyBase.SelectedValue = value
        End Set
    End Property

    <EditorBrowsable(EditorBrowsableState.Always)>
    <Browsable(True)>
    <DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)>
    <Bindable(True)>
    Public Overrides Property Text As String
        Get
            Select Case MyBase.Text
                Case CON_TOP_ROW_CAPTION_0, CON_TOP_ROW_CAPTION_1, CON_TOP_ROW_CAPTION_2
                    'メタ選択肢の場合は、選択されていないものとする
                    Return String.Empty
                Case Else
                    Return MyBase.Text
            End Select
        End Get
        Set(value As String)
            Select Case value
                Case CON_TOP_ROW_CAPTION_0, CON_TOP_ROW_CAPTION_1, CON_TOP_ROW_CAPTION_2
                Case Else
                    MyBase.Text = value
            End Select
        End Set
    End Property

#End Region

    ''' <summary>
    ''' データソース中のItemの選択状態を取得します
    ''' </summary>
    ''' <returns></returns>
    <Browsable(False)>
    Public Property IsSelected As Boolean
        Get
            Return Me.ReadOnly OrElse (Me.DataSource IsNot Nothing AndAlso Me.SelectedValue <> Me.NullValue)
        End Get
        Set(value As Boolean)
            If Me.DataSource IsNot Nothing Then Me.SelectedIndex = 0
        End Set
    End Property



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

#Region "Watermark関連"

    '#Region "InputRequired プロパティ"
    '    Private _InputRequired As Boolean
    '    Public Property InputRequired As Boolean
    '        Get
    '            Return _InputRequired
    '        End Get
    '        Set(value As Boolean)
    '            _InputRequired = value
    '            If value Then
    '                Me.WatermarkText = "<必須>"
    '                Me.WatermarkColor = Color.Red
    '            Else
    '                Me.WatermarkText = _watermarkText
    '                Me.WatermarkColor = _foreColor
    '            End If
    '        End Set
    '    End Property

    '#End Region

    '#Region "WatermarkTextプロパティ"
    '    Private _watermarkText As String
    '    Private _HasWaterMark As Boolean
    '    Private _isDropDownList As Boolean
    '    Private _watermarkColor As Color
    '    Private _foreColor As Color

    '    '<RefreshProperties(RefreshProperties.Repaint)>
    '    ''' <summary>
    '    ''' テキストが空の場合に表示する文字列を取得・設定します。
    '    ''' </summary>
    '    ''' <returns></returns>
    '    <Category("表示")>
    '    <DefaultValue("(選択)")>
    '    <Description("テキストが空の場合に表示する文字列です。")>
    '    Public Property WatermarkText As String
    '        Get
    '            Return _watermarkText
    '        End Get
    '        Set(value As String)
    '            _watermarkText = value
    '            Call TrySetWatermark()
    '        End Set
    '    End Property

    '    Public ReadOnly Property HasWatermark As Boolean
    '        Get
    '            Return _HasWaterMark
    '        End Get
    '    End Property

    '#End Region

    '    ''' <summary>
    '    ''' テキストが空の場合に表示する文字列の色を取得・設定します。
    '    ''' </summary>
    '    ''' <returns></returns>
    '    <Category("表示")>
    '    <DefaultValue(GetType(Color), "GrayText")>
    '    <Description("テキストが空の場合に表示する文字列の色です。")>
    '    Public Property WatermarkColor As Color
    '        Get
    '            Return _watermarkColor
    '        End Get
    '        Set(value As Color)
    '            _watermarkColor = value
    '            Call TrySetWatermark()
    '        End Set
    '    End Property

    '#Region " Text プロパティ "
    '    <RefreshProperties(RefreshProperties.Repaint)>
    '    Public Overrides Property Text As String
    '        Get
    '            Return IIf(_watermarkText.IsNullOrWhiteSpace, String.Empty, MyBase.Text)
    '        End Get
    '        Set(value As String)
    '            If value.IsNullOrWhiteSpace Then
    '                '空文字列が指定された
    '                Call TrySetWatermark() 'ウォーターマーク表示を試みる
    '            ElseIf _HasWaterMark Then
    '                '適切な文字列が設定された。ウォーターマーク表示設定解除
    '                Call ResetWatermark(value)
    '            Else
    '                'テキスト上書き
    '                MyBase.Text = value
    '            End If
    '        End Set
    '    End Property
    '#End Region

    '#Region " ForeColor プロパティ "
    '    Public Overrides Property ForeColor As Color
    '        Get
    '            If DesignMode Then
    '                Return _foreColor
    '            Else
    '                Return MyBase.ForeColor
    '            End If
    '        End Get
    '        Set(value As Color)
    '            _foreColor = value
    '            If _HasWaterMark = False Then
    '                MyBase.ForeColor = value
    '            End If
    '        End Set
    '    End Property

    '    '<RefreshProperties(RefreshProperties.Repaint)>
    '    'Public Overrides Property Text As String
    '    '    Get
    '    '        Return IIf(_watermarkText.IsNullOrWhiteSpace, String.Empty, MyBase.Text)
    '    '    End Get
    '    '    Set(value As String)
    '    '        If value.IsNullOrWhiteSpace Then
    '    '            '空文字列が指定された
    '    '            Call TrySetWatermark() 'ウォーターマーク表示を試みる
    '    '        ElseIf _hasWatermark Then
    '    '            '適切な文字列が設定された。ウォーターマーク表示設定解除
    '    '            Call ResetWatermark(value)
    '    '        Else
    '    '            'テキスト上書き
    '    '            MyBase.Text = value
    '    '        End If
    '    '    End Set
    '    'End Property

#End Region

#End Region

#Region "イベント"

#Region "コンボボックス項目描画時イベント"

    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub Combobox_DrawItem(ByVal sender As Object, ByVal e As System.Windows.Forms.DrawItemEventArgs)
        Dim cmb As ComboBox = CType(sender, ComboBox)

        Try

            Dim backColor As Color = e.BackColor
            'If e.State = DrawItemState.Disabled Then
            '    backColor = SystemColors.Control
            'ElseIf e.Index <> -1 Then
            '    backColor = SystemColors.Control 'cmb.Items(e.Index)
            'End If

            'Dim halfRectSize As Size = New Size(e.Bounds.Width / 2, e.Bounds.Height)
            Dim textRect As Rectangle = New Rectangle(New Point(e.Bounds.Left, e.Bounds.Top), New Size(e.Bounds.Width, e.Bounds.Height))
            'Dim colorRect As Rectangle = New Rectangle(New Point(e.Bounds.Left + halfRectSize.Width, e.Bounds.Top), halfRectSize)
            'Using backBrush As New SolidBrush(backColor)
            '    e.Graphics.FillRectangle(backBrush, colorRect)
            'End Using

            ''背景を描画する
            ''項目が選択されている時は強調表示される
            Dim c As Color = SystemColors.MenuHighlight
            If (e.State And DrawItemState.Selected) = DrawItemState.Selected Then
                Using sb As New SolidBrush(e.BackColor)
                    e.Graphics.FillRectangle(sb, e.Bounds)
                End Using
                Using sb As New SolidBrush(Color.FromArgb(64, c.R, c.G, c.B))
                    e.Graphics.FillRectangle(sb, e.Bounds)
                End Using
            Else
                e.DrawBackground()
            End If

            'BindingSource項目設定
            If e.Index <> -1 Then
                Dim item As Object = cmb.Items(e.Index)
                Dim dispObject As Object = item

                '項目に表示する文字列
                If IsNothing(cmb.DataSource) = False Then
                    Dim bmb As BindingManagerBase = cmb.BindingContext(cmb.DataSource)
                    Dim properties As PropertyDescriptorCollection = bmb.GetItemProperties
                    Dim dispProp As PropertyDescriptor = properties(cmb.DisplayMember)

                    If IsNothing(dispProp) = False Then
                        dispObject = dispProp.GetValue(item)
                    End If

                End If

                Dim itemText As String = TypeDescriptor.GetConverter(dispObject).ConvertToString(dispObject)

                Dim sf As StringFormat = StringFormat.GenericDefault.Clone()
                Select Case HorizontalContentAlignment
                    Case StringAlignment.Near
                        sf.Alignment = StringAlignment.Near
                        sf.LineAlignment = StringAlignment.Near
                    Case StringAlignment.Center
                        sf.Alignment = StringAlignment.Center
                        sf.LineAlignment = StringAlignment.Center
                    Case StringAlignment.Far
                        sf.Alignment = StringAlignment.Far
                        sf.LineAlignment = StringAlignment.Far
                    Case Else
                        sf.Alignment = StringAlignment.Near
                        sf.LineAlignment = StringAlignment.Center
                End Select

                Dim foreColor As Color = e.ForeColor
                If e.State = DrawItemState.Disabled Then
                    foreColor = SystemColors.GrayText
                Else
                    If (e.State And DrawItemState.Selected) = DrawItemState.Selected Then
                        foreColor = Color.White
                    Else
                        foreColor = SystemColors.ControlText
                    End If

                End If

                'e.Graphics.FillRectangle(SystemBrushes.Window, textRect)

                Using foreBrush As New SolidBrush(foreColor)
                    e.Graphics.DrawString(itemText, e.Font, foreBrush, textRect, sf)
                End Using

                'フォーカスを示す四角形を描画
                e.DrawFocusRectangle()

            End If

            If e.State = DrawItemState.Focus Then
                e.DrawFocusRectangle()
            End If
        Catch ex As Exception
            EM.ErrorSyori(ex)
        End Try
    End Sub

#End Region

#Region "オーバーライド"

    Protected Overrides Sub OnEnter(ByVal e As System.EventArgs)
        _OldValue = Me.SelectedValue
        'If _HasWaterMark Then
        '    '解除
        '    Call ResetWatermark("")
        'End If
        MyBase.OnEnter(e)
    End Sub

    Protected Overrides Sub OnLeave(ByVal e As EventArgs)
        MyBase.OnLeave(e)
        'Call TrySetWatermark()

    End Sub

    Protected Overrides Sub OnSelectedValueChanged(ByVal e As EventArgs)
        'If Me.SelectedValue IsNot Nothing Then
        '    '解除
        '    ResetWatermark(Me.Text)
        'End If

        If OldValue = Me.SelectedValue Then
        Else
            'If Me.SelectedValue = Nothing AndAlso MyBase.DataSource IsNot Nothing Then
            '    MyBase.SelectedIndex = 0
            'End If
            _OldValue = Me.SelectedValue
            MyBase.OnSelectedValueChanged(e)
        End If
    End Sub

    Protected Overrides Sub OnMouseHover(e As EventArgs)
        If DropDownStyle = ComboBoxStyle.DropDownList Then
            Cursor = Cursors.Hand
        Else
            Cursor = Cursors.Default
        End If
        MyBase.OnMouseHover(e)
    End Sub

#End Region

#Region "GotFocusedColor"

    <Bindable(True), Category("Appearance"), DefaultValue(GetType(Color), "190, 180, 255")>
    Property GotFocusedColor As System.Drawing.Color

#End Region

#Region "BackColor"

    <Bindable(True), Category("Appearance")>
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

#Region "OnKeyUp"

    Protected Overrides Sub OnKeyUp(e As KeyEventArgs)

        If _ReadOnly Then
            e.Handled = True
            Return
        End If

        MyBase.OnKeyUp(e)
    End Sub

#End Region

#Region "OnKeyPress"

    Protected Overrides Sub OnKeyPress(e As KeyPressEventArgs)
        If _ReadOnly Then
            e.Handled = True
            Return
        End If

        MyBase.OnKeyPress(e)
    End Sub

#End Region

#Region "ProcessDialogKey"

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

#Region "OnKeyDown"

    'Protected Overrides Sub OnKeyDown(ByVal e As KeyEventArgs)

    '    If _ReadOnly Then
    '        e.Handled = True
    '        Return
    '    End If

    '    If e.KeyCode = Keys.Escape Or ((e.KeyCode = Windows.Forms.Keys.Z) And (e.Modifiers = Keys.Control)) Then
    '        Undo()
    '    End If

    '    MyBase.OnKeyDown(e)

    '    Select Case e.KeyCode
    '        Case Keys.Enter     'Enter:Tab
    '            SendKeys.Send("{Tab}") 'Enterを押した際、次の項目へ移動する為Tabを送信する
    '    End Select
    'End Sub

#End Region

#Region "OnGotFocus(ByVal e As EventArgs)"

    Protected Overrides Sub OnGotFocus(ByVal e As EventArgs)

        If Me.ReadOnly Then
            MyBase.BackColor = clrDisableControlGotFocusedColor
        Else
            'フォーカス時は背景色変更
            MyBase.BackColor = Me.GotFocusedColor
        End If
        MyBase.OnGotFocus(e) '基底クラス呼び出し

    End Sub

#End Region

#Region "OnLostFocus(ByVal e As EventArgs)"

    Protected Overrides Sub OnLostFocus(ByVal e As EventArgs)

        If Me.ReadOnly Then
            MyBase.BackColor = clrDisableControlGotFocusedColor
        Else
            'フォーカスがないときは背景色＝白設定
            MyBase.BackColor = _BackColorDefault
        End If
        MyBase.OnLostFocus(e) '基底クラス呼び出し

    End Sub

#End Region

#End Region

#Region "メソッド"

#Region "WaterMark関連"

    'Private Function TrySetWatermark() As Boolean
    '    Try

    '        If _watermarkText.IsNullOrWhiteSpace = False And
    '        MyBase.Text.IsNullOrWhiteSpace = True And MyBase.Focused = False Then '

    '            'MyBase.SelectedIndex < 0 And

    '            'DropDownListは、ウォーターマーク表示のためDropDownにスタイル変更
    '            _isDropDownList = (MyBase.DropDownStyle = ComboBoxStyle.DropDownList And DesignMode = False)

    '            If _isDropDownList Then
    '                MyBase.DropDownStyle = ComboBoxStyle.DropDown
    '            End If

    '            'ウォーターマーク設定
    '            MyBase.ForeColor = _watermarkColor
    '            MyBase.Text = _watermarkText
    '            _HasWaterMark = True

    '            Return True
    '        Else
    '            'DEBUG: ブランク行が選択された場合 ハンドル作成エラー いっそブランク行の文字をウォーターマークテキストで置き換える？

    '            'MyBase.DropDownStyle = ComboBoxStyle.DropDownList

    '            _HasWaterMark = False
    '            Return False
    '        End If
    '    Catch ex As Exception
    '        EM.ErrorSyori(ex, False, conblnNonMsg)
    '    End Try
    'End Function

    'Private Sub ResetWatermark(ByVal value As String)
    '    If _isDropDownList Then
    '        MyBase.DropDownStyle = ComboBoxStyle.DropDownList
    '        _isDropDownList = False
    '    Else
    '        If value IsNot Nothing Then
    '            MyBase.Text = value
    '        End If
    '        MyBase.ForeColor = _foreColor
    '        _HasWaterMark = False
    '    End If
    'End Sub

#End Region

#Region "SetDatasource"

    ''' <summary>
    ''' コンボボックスのデータソースを設定します
    ''' </summary>
    ''' <param name="srcTable"></param>
    ''' <param name="InsertBlankRow">先頭空白行を挿入する場合:True (既定値)True</param>
    ''' <param name="drowMode">コントロールの描画モードを指定 (既定値)Normal</param>
    Public Sub SetDataSource(ByVal srcTable As DataTable, Optional ByVal InsertBlankRow As Boolean = True, Optional drowMode As DrawMode = DrawMode.Normal)

        Try

            '-----オーナードロー設定
            Me.DrawMode = drowMode
            If drowMode <> DrawMode.Normal Then
                Me.MaxDropDownItems = 15
                Me.ItemHeight = Me.Font.Size + 8
                Me.IntegralHeight = False
                AddHandler Me.DrawItem, AddressOf Combobox_DrawItem
            End If

            '-----コンボボックス表示値と選択値の列設定
            'Me.DisplayMember = "DISP"
            'Me.ValueMember = "VALUE"

            If InsertBlankRow = True Then
                '----先頭に空白行を追加する場合
                Dim dtx As New DataTable()
                Dim BlankRow As DataRow = dtx.NewRow()

                ''ソーステーブルの構造をコンボボックス用テーブルにコピーする
                'dtx = srcTable.Clone

                'データソースの列名を取得し、先頭空白行のみのDatatableを作成
                For Each column As DataColumn In srcTable.Columns
                    If dtx.Columns.Contains(column.ColumnName.ToString) = False Then
                        dtx.Columns.Add(column.ColumnName.ToString, column.DataType)
                    End If
                    Select Case True
                        Case column.DataType Is GetType(String)
                            BlankRow(column.ColumnName.ToString) = ""
                        Case column.DataType Is GetType(Integer), column.DataType Is GetType(Decimal), column.DataType Is GetType(Double)
                            BlankRow(column.ColumnName.ToString) = 0
                        Case Else
                            BlankRow(column.ColumnName.ToString) = DBNull.Value
                    End Select
                Next column
                dtx.Rows.Add(BlankRow)

                '空白行のみのデータテーブルとデータソースのデータテーブルを結合
                dtx.Merge(srcTable)

                'データソースを設定する前にコンボボックスのSelectedIndexChangedイベントが発生しないように一時的にイベントハンドラを外す

                Me.DataSource = dtx
                '先頭ブランクの場合はウォーターマーク表示
                'Call TrySetWatermark()
            Else
                '----先頭に空白行を追加しない場合

                Me.DataSource = srcTable

            End If
        Catch ex As Exception
            EM.ErrorSyori(ex, False, conblnNonMsg)
        End Try
    End Sub

    ''' <summary>
    ''' コンボボックスのデータソースを設定します
    ''' </summary>
    ''' <param name="srcTable"></param>
    ''' <param name="TopRow">先頭行の表示内容</param>
    ''' <param name="drowMode">コントロールの描画モードを指定 (既定値)Normal</param>
    Public Sub SetDataSource(ByVal srcTable As DataTable, Optional ByVal TopRow As ENM_COMBO_SELECT_VALUE_TYPE = ENM_COMBO_SELECT_VALUE_TYPE._0_Required, Optional drowMode As DrawMode = DrawMode.Normal)

        Try

            '-----オーナードロー設定
            Me.DrawMode = drowMode
            If drowMode <> DrawMode.Normal Then
                Me.MaxDropDownItems = 15
                Me.ItemHeight = Me.Font.Size + 8
                Me.IntegralHeight = False
                AddHandler Me.DrawItem, AddressOf Combobox_DrawItem
            End If

            '-----コンボボックス表示値と選択値の列設定
            'Me.DisplayMember = "DISP"
            'Me.ValueMember = "VALUE"

            Dim blnInsertRow As Boolean
            Dim strTopRowCaption As String
            Select Case TopRow
                Case ENM_COMBO_SELECT_VALUE_TYPE._0_Required
                    blnInsertRow = True
                    strTopRowCaption = CON_TOP_ROW_CAPTION_0
                Case ENM_COMBO_SELECT_VALUE_TYPE._1_Filter
                    blnInsertRow = True
                    strTopRowCaption = CON_TOP_ROW_CAPTION_1
                Case ENM_COMBO_SELECT_VALUE_TYPE._2_Option
                    blnInsertRow = True
                    strTopRowCaption = CON_TOP_ROW_CAPTION_2
                Case Else
                    'エラー
                    blnInsertRow = False
                    strTopRowCaption = ""
            End Select

            If blnInsertRow = True Then
                '----先頭に空白行を追加する場合
                Dim dtx As New DataTable()
                Dim BlankRow As DataRow = dtx.NewRow()

                ''ソーステーブルの構造をコンボボックス用テーブルにコピーする
                'dtx = srcTable.Clone

                'データソースの列名を取得し、先頭空白行のみのDatatableを作成
                For Each column As DataColumn In srcTable.Columns
                    If dtx.Columns.Contains(column.ColumnName.ToString) = False Then
                        dtx.Columns.Add(column.ColumnName.ToString, column.DataType)
                    End If
                    Select Case True
                        Case column.DataType Is GetType(String)
                            Select Case column.ColumnName
                                Case DisplayMember
                                    BlankRow(column.ColumnName.ToString) = strTopRowCaption
                                Case ValueMember
                                    BlankRow(column.ColumnName.ToString) = NullValue
                                Case Else
                                    BlankRow(column.ColumnName.ToString) = ""
                            End Select

                        Case column.DataType Is GetType(Integer), column.DataType Is GetType(Decimal), column.DataType Is GetType(Double)
                            BlankRow(column.ColumnName.ToString) = 0
                        Case column.DataType Is GetType(Boolean)
                            BlankRow(column.ColumnName.ToString) = False
                        Case Else
                            BlankRow(column.ColumnName.ToString) = DBNull.Value
                    End Select
                Next column
                dtx.Rows.Add(BlankRow)

                '空白行のみのデータテーブルとデータソースのデータテーブルを結合
                dtx.Merge(srcTable)

                'データソースを設定する前にコンボボックスのSelectedIndexChangedイベントが発生しないように一時的にイベントハンドラを外す

                Me.DataSource = dtx
                '先頭ブランクの場合はウォーターマーク表示
                'Call TrySetWatermark()
            Else
                '----先頭に空白行を追加しない場合

                Me.DataSource = srcTable

            End If
        Catch ex As Exception
            EM.ErrorSyori(ex, False, conblnNonMsg)
        End Try
    End Sub

#End Region

#Region "Undo"

    Public Sub Undo()
        Me.Text = Me.OldValue
    End Sub

#End Region

#Region "SetDefaultValue"

    ''' <summary>
    ''' コンボボックス規定値設定(コードマスタのみ)
    ''' </summary>
    ''' <param name="cmbCtrl"></param>
    ''' <returns></returns>
    Public Sub SetDefaultValue()
        Dim strDefaultValue As String

        Try

            'コンボボックスのデータソース取得
            Dim dt As DataTable = DirectCast(Me.DataSource, DataTable)
            Dim dtRows As DataRow() = dt.Select("DEF_FLG=True")

            If dtRows.Length > 0 Then
                strDefaultValue = dtRows(0).Item("VALUE")
            Else
                strDefaultValue = ""
            End If

            Me.SelectedValue = strDefaultValue
        Catch ex As Exception
            EM.ErrorSyori(ex, False, conblnNonMsg)
        End Try
    End Sub

#End Region

#End Region

#Region "ローカル関数"

    Private Sub DrawRectangle()
        Try
            'ボタンスタイルコントロールの輪郭の描画(線の幅指定有り)
            ControlPaint.DrawBorder(Me.CreateGraphics(), Me.ClientRectangle,
                                    Me.BorderColor, Me.BorderWidth, Me.BorderStyle,
                                    Me.BorderColor, Me.BorderWidth, Me.BorderStyle,
                                    Me.BorderColor, Me.BorderWidth, Me.BorderStyle,
                                    Me.BorderColor, Me.BorderWidth, Me.BorderStyle)
        Catch
        End Try
    End Sub
#End Region

End Class