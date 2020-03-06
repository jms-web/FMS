Imports System.Runtime.CompilerServices
Imports System.Collections.Generic
Imports System.Linq

''' <summary>
''' 拡張メソッドの定義
''' </summary>
Public Module ExtensionMethod

#Region "Attribute"

    <Extension()>
    Public Function DisplayName(ByVal provider As System.Reflection.ICustomAttributeProvider) As String
        Return ModelEx.DisplayNameAttribute.GetAttribute(provider)
    End Function

    <Extension()>
    Public Function DisplayName(ByVal value As [Enum]) As String
        Return ModelEx.DisplayNameAttribute.GetAttribute(value)
    End Function

#End Region

#Region "BindingSource"

    ''' <summary>
    ''' BindingSourceの選択行のentityを置き換える
    ''' </summary>
    ''' <param name="bindSrc"></param>
    ''' <param name="entity"></param>
    <Extension()>
    Public Sub CurrentUpdate(bindSrc As BindingSource, entity As MODEL.IDataModel)
        Dim intPosition As Integer = bindSrc.Position
        bindSrc.Remove(bindSrc.Current)
        bindSrc.Insert(intPosition, entity)
    End Sub

    <Extension()>
    Public Sub Update(bindSrc As BindingSource, entity As MODEL.IDataModel, index As Integer)
        bindSrc.Insert(index - 1, entity)
        bindSrc.Remove(index)
    End Sub

#End Region

#Region "Control"

    ''' <summary>
    ''' コントロールに含まれるすべての子孫コントロールを列挙します
    ''' </summary>
    ''' <param name="top"></param>
    ''' <returns></returns>
    <Extension>
    Public Iterator Function EnumerateAllChildControls(top As Control) As IEnumerable(Of Control)
        For Each c As Control In top.Controls
            Yield c
            If c.HasChildren Then
                For Each cc As Control In EnumerateAllChildControls(c)
                    Yield cc
                Next cc
            End If
        Next c
    End Function

    'UNDONE: GetAllControlsをキャッシュして使いまわせるようにする

    ''' <summary>
    ''' self内のすべてのコントロールを取得する
    ''' </summary>
    ''' <param name="self"></param>
    ''' <returns></returns>
    <Extension>
    Public Function GetAllControls(self As Control) As List(Of Control)
        Dim buf As New List(Of Control)
        self.Controls.OfType(Of Control).
                      ToList.
                      ForEach(Sub(c)
                                  buf.Add(c)
                                  buf.AddRange(c.GetAllControls())
                              End Sub)
        Return buf
    End Function

    ''' <summary>
    ''' self内でBindingObject.PropertyNameをバインドしているコントロールを1つ取得する
    ''' </summary>
    ''' <param name="self"></param>
    ''' <param name="BindingObject"></param>
    ''' <param name="PropertyName"></param>
    ''' <returns></returns>
    Public Function ControlOf(self As Control, BindingObject As Object, PropertyName As String) As Control
        Return self.GetAllControls.
                    FirstOrDefault(Function(c) c.DataBindings.OfType(Of Binding).
                                                              Any(Function(b) b.BindingManagerBase.Current = BindingObject And
                                                                              b.BindingMemberInfo.BindingField = PropertyName))
    End Function

    Public Function ControlsOf(self As Control, BindingObject As Object, PropertyName As String) As IEnumerable(Of Control)

        Return self.GetAllControls.
                    Where(Function(c) c.DataBindings.OfType(Of Binding).
                                                     Any(Function(b) b.BindingManagerBase.Current = BindingObject And
                                                                     b.BindingMemberInfo.BindingField = PropertyName))
    End Function



#End Region

#Region "DataGridView"

    ''' <summary>
    ''' 選択行(または任意の行)のソース元のDataRowを取得します。
    ''' </summary>
    ''' <param name="dgv"></param>
    ''' <returns></returns>
    <Extension()>
    Public Function GetDataRow(ByVal dgv As DataGridView, Optional ByVal rowIndex As Integer = -1) As DataRow
        Dim dgr As DataGridViewRow
        If rowIndex = -1 Then
            dgr = dgv.CurrentRow
        Else
            dgr = dgv.Rows(rowIndex)
        End If

        Dim drv As DataRowView = CType(dgr.DataBoundItem, DataRowView)
        Return drv.Row
    End Function

#End Region

#Region "Datarow"
    ''' <summary>
    ''' DataRowをModelEntityクラスにマッピング
    ''' </summary>
    ''' <returns></returns>
    <Extension()>
    Public Function ToEntity(Of T As {New, MODEL.IDataModel})(dr As DataRow) As T
        Dim resultData = New T
        resultData.Properties.ForEach(Sub(p) resultData(p.Name) = dr(p.Name))
        Return resultData
    End Function
#End Region

#Region "DataTable"

    <Extension()>
    Public Function ExcludeDeleted(ByVal dt As DataTable) As DataTable
        If dt.Rows.Count > 0 Then
            Dim filteredTable As DataTable = dt.AsEnumerable().Where(Function(r) r.Field(Of String)("DEL_FLG") = "0").CopyToDataTable
            If filteredTable IsNot Nothing Then
                Return filteredTable
            Else
                Return Nothing
            End If
        Else
            Return dt
        End If
    End Function


    ''' <summary>
    ''' ブランク行追加
    ''' </summary>
    ''' <param name="dt"></param>
    ''' <returns></returns>
    <Extension()>
    Public Function AddBlankRow(ByVal dt As DataTable) As DataTable

        Dim dtx As New DataTable
        Dim BlankRow As DataRow = dtx.NewRow()

        'データソースの列名を取得し、先頭空白行のみのDatatableを作成
        For Each column As DataColumn In dt.Columns
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
        dtx.Merge(dt)

        Return dtx

    End Function

    ''' <summary>
    ''' DatatableのDataRowsを
    ''' </summary>
    ''' <typeparam name="T"></typeparam>
    ''' <param name="dt"></param>
    ''' <returns></returns>
    <Extension()>
    Public Iterator Function AsEnumerableEntity(Of T As {New, MODEL.IDataModel})(dt As DataTable) As Generic.IEnumerable(Of T)

        For Each r As DataRow In dt.Rows
            Yield r.ToEntity(Of T)
        Next r
    End Function
#End Region

#Region "Date"

    ''' <summary>
    ''' 月初
    ''' </summary>
    ''' <param name="theDay"></param>
    ''' <returns></returns>
    <Extension()>
    Public Function GetBeginOfMonths(ByVal theDay As Date) As Date
        Return New DateTime(theDay.Year, theDay.Month, 1)
    End Function

    ''' <summary>
    ''' 月末
    ''' </summary>
    ''' <param name="theDay"></param>
    ''' <returns></returns>
    <Extension()>
    Public Function GetEndOfMonths(ByVal theDay As Date) As Date
        Dim intDay As Integer = DateTime.DaysInMonth(theDay.Year, theDay.Month)
        Return New DateTime(theDay.Year, theDay.Month, intDay)
    End Function

#End Region

#Region "Datetime"

    ''' <summary>
    ''' 月初
    ''' </summary>
    ''' <param name="theDay"></param>
    ''' <returns></returns>
    <Extension()>
    Public Function GetBeginOfMonth(ByVal theDay As DateTime) As DateTime
        Return New DateTime(theDay.Year, theDay.Month, 1)
    End Function

    ''' <summary>
    ''' 月末
    ''' </summary>
    ''' <param name="theDay"></param>
    ''' <returns></returns>
    <Extension()>
    Public Function GetEndOfMonth(ByVal theDay As DateTime) As DateTime
        Dim intDay As Integer = DateTime.DaysInMonth(theDay.Year, theDay.Month)
        Return New DateTime(theDay.Year, theDay.Month, intDay)
    End Function

    <Extension()>
    Public Function FunGetWarekiFormat(ByVal targetDate As DateTime, Optional ByVal strFormat As String = "ggyyyy年MM月dd日") As String
        Dim culture As Globalization.CultureInfo = New Globalization.CultureInfo("ja-JP", True)
        culture.DateTimeFormat.Calendar = New Globalization.JapaneseCalendar()
        Dim result As String = targetDate.ToString(strFormat, culture)
        Return result
    End Function

#End Region

#Region "Decimal"

    ''' <summary>
    ''' 少数点時間(Hour)を分(minutes)に変換した数値を返します
    ''' 例)1.5→1.30 6.6→6.36
    ''' </summary>
    ''' <param name="decHour"></param>
    ''' <returns></returns>
    <Extension()>
    Public Function ConvertSmallNumberPointHoursToDecimalMinutes(ByVal decHour As Decimal) As Decimal
        Dim decRET As Decimal
        Dim intPart As Integer = Math.Truncate(decHour)
        Dim decPart As Decimal = decHour - Math.Truncate(decHour)

        decRET = intPart + (decPart * 0.6)
        Return decRET
    End Function

    ''' <summary>
    ''' 少数点時間(Hour)を分(minutes)に変換した文字列を返します
    ''' 例)1.5→1:30 6.6→6:36
    ''' </summary>
    ''' <param name="decHour"></param>
    ''' <returns></returns>
    <Extension()>
    Public Function ConvertSmallNumberPointHoursToStringMinutes(ByVal decHour As Decimal) As String
        Dim strRET As String = String.Empty
        Dim intPart As Integer = Math.Truncate(decHour)
        Dim decPart As Decimal = decHour - Math.Truncate(decHour)

        strRET = intPart & ":" & (decPart * 0.6)
        Return strRET
    End Function

    <Extension()>
    Public Function RoundingToSpecifiedLength(ByVal decValue As Decimal, ByVal iDigits As Integer) As Decimal
        Return System.Math.Round(decValue, iDigits)
    End Function

#End Region

#Region "Double"

    ''' <summary>
    ''' 指定した精度の数値に四捨五入します。(JIS丸め 銀行丸め)
    ''' </summary>
    ''' <param name="dValue">丸め対象の倍精度浮動小数点数。</param>
    ''' <param name="iDigits">戻り値の有効桁数の精度。</param>
    ''' <returns>iDigits に等しい精度の数値に四捨五入された数値。</returns>
    <Extension()>
    Public Function ToHalfAdjust(ByVal dValue As Double, ByVal iDigits As Integer) As Double
        Return System.Math.Round(dValue, iDigits)
    End Function

    '有効桁数に丸める(JIS丸め 銀行丸め)(5桁まで対応)
    Public Function ToYuukouKeta(ByVal dValue As Double, ByVal iDigits As Integer) As Double
        Dim dblWORK As Double

        If dValue < 1 Then
            dblWORK = dValue.ToHalfAdjust(iDigits) '四捨五入
        ElseIf dValue < 10 Or iDigits = 1 Then
            dblWORK = dValue.ToHalfAdjust(iDigits - 1) '四捨五入
        ElseIf dValue < 100 Or iDigits = 2 Then
            dblWORK = dValue.ToHalfAdjust(iDigits - 2) '四捨五入
        ElseIf dValue < 1000 And iDigits = 3 Then
            dblWORK = dValue.ToHalfAdjust(iDigits - 3) '四捨五入
        ElseIf dValue < 10000 And iDigits = 4 Then
            dblWORK = dValue.ToHalfAdjust(iDigits - 4) '四捨五入
        ElseIf dValue < 100000 And iDigits = 5 Then
            dblWORK = dValue.ToHalfAdjust(iDigits - 5) '四捨五入
        Else
            dblWORK = dValue.ToHalfAdjust(0) '四捨五入
        End If

        Return dblWORK
    End Function

#End Region

#Region "Enum"
    <Extension>
    Public Function [Value](Of T As {IComparable, IConvertible, IFormattable})(enm As T) As Integer
        If enm.GetType.IsEnum Then
            'Dim fieldInfo As Reflection.FieldInfo = enm.GetType.GetField(enm.ToString)
            'If fieldInfo Is Nothing Then Return Nothing
            'Dim attr = fieldInfo.GetCustomAttributes("System.ComponentModel.DescriptionAttribute")
            Return Val(enm)
        Else
            Throw New System.ComponentModel.InvalidEnumArgumentException
        End If
    End Function


#End Region

#Region "ErrorProvider"

    ''' <summary>
    ''' コントロールにErrorProviderを設定する
    ''' </summary>
    ''' <param name="provider">ErrorProvider</param>
    ''' <param name="control">エラーを通知するコントロール</param>
    ''' <param name="ExpressionResult">評価結果 入力Errorかどうかの判定</param>
    ''' <param name="message">ExpressionResult=false時にアイコンに表示するメッセージ</param>
    ''' <param name="IconAlignment">(オプション) アイコン表示位置</param>
    ''' <param name="IconPadding">(オプション)アイコン、コントロール間の余白</param>
    ''' <param name="ErrorIcon">(オプション)表示するアイコン ※アイコンは16x16に対応したものにすること </param>
    ''' <returns>エラーチェック評価結果=ExpressionResult 入力チェックのフラグ更新等に利用できます</returns>
    <Extension>
    Public Function UpdateErrorInfo(provider As ErrorProvider,
                              control As Control,
                              ExpressionResult As Boolean,
                              message As String,
                              Optional IconAlignment As ErrorIconAlignment = ErrorIconAlignment.MiddleLeft,
                              Optional IconPadding As Integer = 2,
                              Optional ErrorIcon As Icon = Nothing) As Boolean

        If ExpressionResult Then
            'Clear Error
            Call provider.ClearError(control)
        Else
            'Set Error
            If provider.GetError(control).Trim <> message Then

                provider.BlinkStyle = ErrorBlinkStyle.NeverBlink
                If ErrorIcon IsNot Nothing Then provider.Icon = ErrorIcon
                provider.SetIconAlignment(control, IconAlignment)
                provider.SetIconPadding(control, IconPadding)
                provider.SetError(control, message)

                If message.IsNulOrWS Then
                    control.BackColor = clrControlDefaultBackColor
                Else
                    Select Case control.GetType
                        Case GetType(TextBoxEx), GetType(MaskedTextBoxEx), GetType(DateTextBoxEx), GetType(NumericUpDown)
                            control.BackColor = clrControlErrorBackColor
                        Case GetType(ComboboxEx)
                            control.BackColor = clrControlErrorBackColor
                            Dim cmb As ComboboxEx = DirectCast(control, ComboboxEx)
                            Dim _defaultStyle = cmb.DropDownStyle
                            Application.DoEvents()
                            cmb.DropDownStyle = ComboBoxStyle.DropDown
                            cmb.FlatStyle = FlatStyle.Flat
                            cmb.BorderStyle = ButtonBorderStyle.Solid
                            cmb.DropDownStyle = _defaultStyle
                        Case Else
                    End Select
                End If
            Else
                '既に同一コメントが設定されている場合は何もしない(ちらつきの原因になる)
            End If
        End If

        Return ExpressionResult
    End Function


    <Obsolete("拡張メソッド.UpdateErrorInfoを使用して下さい 例)ErrorProvider.UpdateErrorInfo(Combobox1,Combobox1.IsSelected,'選択されていません')")>
    <Extension>
    Public Sub SetErrorInfo(provider As ErrorProvider, control As Control, message As String, Optional IconAlignment As ErrorIconAlignment = ErrorIconAlignment.MiddleLeft, Optional IconPadding As Integer = 2, Optional ErrorIcon As Icon = Nothing)

        provider.BlinkStyle = ErrorBlinkStyle.NeverBlink
        If ErrorIcon IsNot Nothing Then provider.Icon = ErrorIcon
        provider.SetIconAlignment(control, IconAlignment)
        provider.SetIconPadding(control, IconPadding)
        provider.SetError(control, message)

        If message.IsNulOrWS Then
            control.BackColor = clrControlDefaultBackColor
        Else
            Select Case control.GetType
                Case GetType(TextBoxEx), GetType(MaskedTextBoxEx), GetType(DateTextBoxEx), GetType(NumericUpDown)
                    control.BackColor = clrControlErrorBackColor
                Case GetType(ComboboxEx)
                    control.BackColor = clrControlErrorBackColor
                    Dim cmb As ComboboxEx = DirectCast(control, ComboboxEx)
                    Dim _defaultStyle As ComboBoxStyle = cmb.DropDownStyle
                    Application.DoEvents()
                    cmb.DropDownStyle = ComboBoxStyle.DropDown
                    cmb.FlatStyle = FlatStyle.Flat
                    cmb.BorderStyle = ButtonBorderStyle.Solid
                    cmb.DropDownStyle = _defaultStyle
                Case Else
            End Select
        End If
    End Sub

    <Extension>
    Public Sub ClearError(ByVal provider As ErrorProvider, ByVal control As Control)
        provider.SetError(control, "")
        control.BackColor = clrControlDefaultBackColor

        Select Case control.GetType
            Case GetType(ComboboxEx)
                'Application.DoEvents()
                DirectCast(control, ComboboxEx).FlatStyle = FlatStyle.Standard
                DirectCast(control, ComboboxEx).BorderStyle = ButtonBorderStyle.None
        End Select
    End Sub

#End Region

#Region "Exception"

    ''' <summary>
    ''' 完全なメッセージを取得します
    ''' </summary>
    ''' <param name="source"></param>
    ''' <returns></returns>
    ''' <remarks>内部例外も評価したメッセージを返します</remarks>
    <Extension()>
    Public Function ToFullMessage(source As Exception) As String
        Dim s As New System.Text.StringBuilder
        Dim cnt As Integer = 0
        Dim act As Action(Of Exception) =
            Sub(ex)
                s.Append(New String(CChar(">"), cnt))
                cnt += 1
                s.AppendLine(ex.Message)
                If ex.InnerException IsNot Nothing Then act.Invoke(ex.InnerException)
            End Sub
        act.Invoke(source)
        Return s.ToString
    End Function

    ''' <summary>
    ''' 完全なスタックトレースを取得します
    ''' </summary>
    ''' <param name="source"></param>
    ''' <returns></returns>
    ''' <remarks>内部例外も評価したスタックトレースを返します</remarks>
    <Extension()>
    Public Function ToFullStackTrace(source As Exception) As String
        Dim s As New System.Text.StringBuilder
        Dim act As Action(Of Exception) =
            Sub(ex)
                s.AppendLine(ex.Message)
                s.AppendLine(ex.StackTrace)
                If ex.InnerException IsNot Nothing Then act.Invoke(ex.InnerException)
            End Sub
        act.Invoke(source)
        Return s.ToString
    End Function

#End Region

#Region "LINQ"

    <System.Diagnostics.DebuggerStepThrough()>
    <Extension>
    Public Sub ForEach(Of T)(ItemSource As System.Collections.Generic.IEnumerable(Of T), AppliedAction As Action(Of T))
        For Each item As T In ItemSource
            AppliedAction(item)
        Next
    End Sub


    '<Extension>
    'Public Function [Using](Of T, Tresult)(source As T, process As Func(Of T, Tresult)) As Tresult
    '    If source Is Nothing Then
    '        Throw New ArgumentNullException(NameOf(source))
    '    End If
    '    If process Is Nothing Then
    '        Throw New ArgumentNullException(NameOf(process))
    '    End If

    '    Using source
    '        Return process(source)
    '    End Using

    'End Function


    <Extension>
    Public Sub [Using](Of T As IDisposable)(source As T, process As Action(Of T))
        If source Is Nothing Then
            Throw New ArgumentNullException(NameOf(source))
        End If
        If process Is Nothing Then
            Throw New ArgumentNullException(NameOf(process))
        End If
        Using source
            process(source)
        End Using
    End Sub

#End Region

#Region "List"
    <Extension>
    Public Sub ReplaceItem(Of T)(list As Generic.List(Of T), oldItemSelector As Predicate(Of T), newItem As T)
        Dim oldItemIndex As Integer = list.FindIndex(oldItemSelector)
        list(oldItemIndex) = newItem
    End Sub

#End Region

#Region "String"

    <Extension()>
    Public Function IsNullOrEmpty(ByVal value As String) As Boolean
        Return String.IsNullOrEmpty(value)
    End Function

    <Extension()>
    Public Function IsNulOrWS(ByVal this As String) As Boolean
        Return String.IsNullOrWhiteSpace(this)
    End Function

    <Extension()>
    Public Function Format(ByVal this As String, ByVal ParamArray args() As Object) As String
        Return String.Format(this, args)
    End Function

    ''' <summary>
    ''' 文字列中の特定文字をSQL文用にエスケープ
    ''' </summary>
    ''' <param name="this"></param>
    ''' <returns></returns>
    <Extension()>
    Public Function ConvertSqlEscape(ByVal this As String) As String
        Dim strRET As String

        'UNDONE: SQLエスケープ文字追加
        strRET = this.Replace("'", "''")

        Return strRET
    End Function

    ''' <summary>
    ''' バイト
    ''' </summary>
    ''' <param name="this"></param>
    ''' <returns></returns>
    <Extension()>
    Public Function GetByteLength(this As String, Optional encodeName As String = "Shift_JIS") As Integer
        Dim enc As System.Text.Encoding = System.Text.Encoding.GetEncoding(encodeName)
        Return enc.GetByteCount(this)
    End Function

    ''' <summary>
    ''' 数値(整数)型に変換 Val
    ''' </summary>
    ''' <param name="this"></param>
    ''' <returns></returns>
    <Extension()>
    Public Function ToVal(this As String) As Integer
        Dim intRET As Integer
        Integer.TryParse(this, intRET)

        Return intRET
    End Function


    ''' <summary>
    ''' 文字列を日付型に変換
    ''' </summary>
    ''' <param name="this"></param>
    <Extension()>
    Public Function ToDateTime(this As String, Optional format As String = "") As DateTime

        If format.IsNulOrWS Then
            Return DateTime.Parse(this)
        Else
            Return DateTime.ParseExact(this, format, Nothing)
        End If
    End Function

#End Region



End Module