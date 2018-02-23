Imports System.Runtime.CompilerServices

''' <summary>
''' 拡張メソッドの定義
''' </summary>
Public Module mdlExtensionMethod

#Region "Attribute"
    <Extension()>
    Public Function DisplayName(ByVal provider As System.Reflection.ICustomAttributeProvider) As String
        Return Model.DisplayNameAttribute.GetAttribute(provider)
    End Function

    <Extension()>
    Public Function DisplayName(ByVal value As [Enum]) As String
        Return Model.DisplayNameAttribute.GetAttribute(value)
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

#Region "ブランク行追加"
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

#End Region

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

#Region "ErrorProvider"
    <Extension>
    Public Sub SetError(ByVal provider As ErrorProvider, ByVal control As Control, ByVal message As String, ByVal alignment As ErrorIconAlignment, Optional ByVal intPadding As Integer = 2)
        provider.SetError(control, message)
        provider.SetIconAlignment(control, alignment)
        provider.SetIconPadding(control, intPadding)

        If message.IsNullOrWhiteSpace = True Then
            control.BackColor = clrControlDefaultBackColor
        Else
            Select Case control.GetType
                Case GetType(TextBoxEx), GetType(MaskedTextBoxEx), GetType(DateTextBoxEx), GetType(ComboboxEx)
                    control.BackColor = clrControlErrorBackColor
                Case Else
            End Select
        End If
    End Sub

    <Extension>
    Public Sub ClearError(ByVal provider As ErrorProvider, ByVal control As Control)
        provider.SetError(control, "")
        control.BackColor = clrControlDefaultBackColor
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

    <Extension>
    Public Sub ForEach(Of T)(ItemSource As System.Collections.Generic.IEnumerable(Of T), AppliedAction As Action(Of T))
        For Each item As T In ItemSource
            AppliedAction(item)
        Next
    End Sub


#End Region

#Region "String"
    <Extension()>
    Public Function IsNullOrEmpty(ByVal value As String) As Boolean
        Return String.IsNullOrEmpty(value)
    End Function

    <Extension()>
    Public Function IsNullOrWhiteSpace(ByVal this As String) As Boolean
        Return String.IsNullOrWhiteSpace(this)
    End Function

    <Extension()>
    Public Function Format(ByVal this As String, ByVal ParamArray args() As Object) As String
        Return String.Format(this, args)
    End Function
#End Region

End Module