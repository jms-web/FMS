﻿Imports System.ComponentModel
Imports System.Security.Permissions
Imports JMS_COMMON.ClsPubMethod

<DefaultEvent("SelectedValueChanged")>
Public Class ComboboxEx
    Inherits ComboBox

#Region "定数・変数"


    'メタ選択肢定数
    Const CON_TOP_ROW_CAPTION_0 As String = "(必須)"
    Const CON_TOP_ROW_CAPTION_1 As String = "(すべて)"
    Const CON_TOP_ROW_CAPTION_2 As String = "(未選択)"

    Private _GotFocusedColor As Color 'フォーカス時の背景色
    Private _BackColorDefault As Color 'フォーカス喪失時時の背景色

    Private _BackColorOrg As System.Drawing.Color
    Private _ReadOnly As Boolean
    Private _CursorOrg As Cursor
    Private keyPressHandled As Boolean
    Private _imeMode As ImeMode
#End Region

#Region "コンストラクタ"
    Public Sub New()
        InitializeComponent()
        _BackColorOrg = BackColor
        _CursorOrg = Cursor
        'SetDatasourceから移行 SelectedValueChanged等を発火させないため
        DisplayMember = "DISP"
        ValueMember = "VALUE"
        '_imeMode = ImeMode
        NullValue = " "
    End Sub
#End Region

#Region "プロパティ"

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
                ContextMenu = New ContextMenu
                SetStyle(ControlStyles.UserMouse, True)
                'Me.ImeMode = _imeMode
            Else
                Cursor = _CursorOrg
                BackColor = _BackColorOrg
                ContextMenu = Nothing
                SetStyle(ControlStyles.UserMouse, False)
                'Me.ImeMode = ImeMode.Disable
            End If
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


#Region "オーバーロード"

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

    '<DefaultValue(GetType(Cursors), "Hand")>
    'Public Overrides Property Cursor As Cursor
    '    Get
    '        Return MyBase.Cursor
    '    End Get
    '    Set(value As Cursor)
    '        MyBase.Cursor = value
    '    End Set
    'End Property



#End Region

    ''' <summary>
    ''' データソース中のItemの選択状態を取得します
    ''' </summary>
    ''' <returns></returns>
    <Browsable(False)>
    Public Property Selected As Boolean
        Get
            Return Me.ReadOnly OrElse (Me.DataSource IsNot Nothing AndAlso Me.SelectedValue <> Me.NullValue)
        End Get
        Set(value As Boolean)

        End Set
    End Property


    Private _OldValue As Object
    ''' <summary>
    ''' 変更前の値を取得します
    ''' </summary>
    ''' <returns></returns>
    <Browsable(False)>
    Public ReadOnly Property OldValue As Object
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

    '#Region "　Text プロパティ　"
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

    '#Region "　ForeColor プロパティ　"
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
    Private Shared Sub Combobox_DrawItem(ByVal sender As Object, ByVal e As System.Windows.Forms.DrawItemEventArgs)
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
                sf.Alignment = StringAlignment.Near
                sf.LineAlignment = StringAlignment.Center

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

    Public Overrides Property Text As String
        Get
            Select Case MyBase.SelectedValue?.ToString
                Case CON_TOP_ROW_CAPTION_0, CON_TOP_ROW_CAPTION_1, CON_TOP_ROW_CAPTION_2
                    'メタ選択肢の場合は、選択されていないものとする
                    Return String.Empty 'NullValue
                Case Else
                    Return MyBase.Text
            End Select
        End Get
        Set(value As String)
            MyBase.Text = value
        End Set
    End Property

    Protected Overrides Sub OnMouseWheel(e As MouseEventArgs)
        'CHECK: コンボボックスマウスホイール無効
        MyBase.OnMouseWheel(e)

        'Dim eventArgs As HandledMouseEventArgs = DirectCast(e, HandledMouseEventArgs)
        'eventArgs.Handled = True
    End Sub
#End Region

#Region "GotFocusedColor"
    <Bindable(True), Category("Appearance"), DefaultValue("")>
    Property [GotFocusedColor]() As System.Drawing.Color
        Get
            Return _GotFocusedColor
        End Get
        Set(ByVal value As Color)
            _GotFocusedColor = value
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

#Region "OnKeyPress"
    Protected Overrides Sub OnKeyPress(e As KeyPressEventArgs)
        If Not Me.ReadOnly Then
            'If ToUpper Then
            '    Dim keyAscii As Integer = AscW(e.KeyChar)

            '    '変換したｷｰｺｰﾄﾞをｷｰｲﾍﾞﾝﾄに返す
            '    e.KeyChar = ChrW(AscW(Char.ToUpper(ChrW(keyAscii))))
            '    If keyAscii = 0 Then
            '        e.Handled = True
            '    End If
            'End If
            Me.keyPressHandled = False
            Return
        End If

        If Me.keyPressHandled Then
            e.Handled = True
            Me.keyPressHandled = False
            Return
        End If

        If Not Char.IsControl(e.KeyChar) Then
            e.Handled = True
        End If

        Me.keyPressHandled = False
    End Sub
#End Region
#Region "OnKeyDown"
    Protected Overrides Sub OnKeyDown(ByVal e As KeyEventArgs)

        If Not Me.ReadOnly Then
            Select Case e.KeyCode
                Case Keys.Enter     'Enter:Tab
                    SendKeys.Send("{Tab}") 'Enterを押した際、次の項目へ移動する為Tabを送信する
            End Select

            Return
        End If

        'If Me.ImeMode = ImeMode.Disable Then
        '    Stop
        'End If

        If e.KeyCode = Keys.Delete Then
            e.Handled = True
            Return
        End If

        If e.KeyCode = Keys.Back Then
            Me.keyPressHandled = True
            Return
        End If

        If e.Control Then
            Select Case e.KeyCode
                Case Keys.V, Keys.X
                    Me.keyPressHandled = True
                    Return
            End Select
        End If

        If e.KeyCode = Keys.Up OrElse e.KeyCode = Keys.PageUp OrElse e.KeyCode = Keys.Down OrElse e.KeyCode = Keys.PageDown Then
            e.Handled = True
            Return
        End If

        Me.keyPressHandled = False
    End Sub
#End Region

    <SecurityPermission(SecurityAction.Demand, Flags:=SecurityPermissionFlag.UnmanagedCode)>
    Protected Overrides Function ProcessCmdKey(ByRef msg As Message, keyData As Keys) As Boolean

        If ((keyData And Keys.Control) = Keys.Control AndAlso
                (keyData And Keys.KeyCode) = Keys.V) OrElse
                ((keyData And Keys.Shift) = Keys.Shift AndAlso
                 (keyData And Keys.KeyCode) = Keys.Insert) Then
            If Me.ReadOnly Then
                Return True
            Else
                Return MyBase.ProcessCmdKey(msg, keyData)
            End If
        Else
            Return MyBase.ProcessCmdKey(msg, keyData)
        End If

    End Function


#Region "OnGotFocus(ByVal e As EventArgs)"
    Protected Overrides Sub OnGotFocus(ByVal e As EventArgs)

        If Me.Enabled = False Or Me.ReadOnly = True Then
            MyBase.BackColor = clrDisableControlGotFocusedColor
        Else
            'フォーカス時は背景色変更
            MyBase.BackColor = _GotFocusedColor
        End If
        MyBase.OnGotFocus(e) '基底クラス呼び出し

    End Sub
#End Region
#Region "OnLostFocus(ByVal e As EventArgs)"
    Protected Overrides Sub OnLostFocus(ByVal e As EventArgs)

        If Me.Enabled = False Or Me.ReadOnly = True Then
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
                Me.SelectedIndex = -1

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


End Class


