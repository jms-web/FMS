' This software is distributed under the license of NYSL.
' ( http://www.kmonos.net/nysl/ )

''' <summary>
''' DateTimePickerを用いた日付入力セル(DataGridViewDateCell)のホスト
''' </summary>
Public Class DataGridViewDateColumn
    Inherits DataGridViewColumn

    '''表示形式
    Private _format As DateTimePickerFormat = DateTimePickerFormat.Custom

    '''入力用フォーマット
    Private _inputFormat As String = ""
    '''表示用フォーマット
    Private _customFormat As String = ""

    '''入力可能なもっとも過去の日時
    Private _minDate As Date = DateTimePicker.MinimumDateTime
    '''入力可能なもっとも未来の日時
    Private _maxDate As Date = DateTimePicker.MaximumDateTime

    '''
    '''
    '''
    Public Sub New()
        MyBase.New(New DataGridViewDateCell())
    End Sub

    '''
    '''
    '''
    Public Overrides Function Clone() As Object

        Dim col As DataGridViewDateColumn =
            DirectCast(MyBase.Clone(), DataGridViewDateColumn)

        ' プロパティを追加したとき、この場所に追記する
        ' Cloneメソッドに記述しない場合、プロパティブラウザで表示・編集は
        ' されるが、保存されないプロパティとなる
        With col
            .Format = Me.Format
            .CustomFormat = Me.CustomFormat
            .InputFormat = Me.InputFormat
            .MinDate = Me.MinDate
            .MaxDate = Me.MaxDate
        End With

        Return col
    End Function

#Region "プロパティ"
    '''
    '''
    '''
    '''
    '''
    Public Overrides Property CellTemplate() As DataGridViewCell

        Get
            Dim cell As DataGridViewCell = MyBase.CellTemplate
            With TryCast(cell, DataGridViewDateCell)
                .CustomFormat = _customFormat
            End With
            Return cell
        End Get

        Set(ByVal value As DataGridViewCell)
            If Not (value Is Nothing) _
            AndAlso Not value.GetType().IsAssignableFrom(GetType(DataGridViewDateCell)) Then
                Throw New InvalidCastException("Must be a DataGridViewDateCell")
            End If
            MyBase.CellTemplate = value
        End Set
    End Property

    Public Property Format() As String
        Get
            Return _format
        End Get
        Set(ByVal value As String)
            _format = value
        End Set
    End Property

    Public Property CustomFormat() As String
        Get
            Return _customFormat
        End Get
        Set(ByVal value As String)
            _customFormat = value
        End Set
    End Property

    Public Property InputFormat() As String
        Get
            Return _inputFormat
        End Get
        Set(ByVal value As String)
            _inputFormat = value
        End Set
    End Property

    Public Property MinDate() As Date
        Get
            Return _minDate
        End Get
        Set(ByVal value As Date)
            _minDate = value
        End Set
    End Property

    Public Property MaxDate() As Date
        Get
            Return _maxDate
        End Get
        Set(ByVal value As Date)
            _maxDate = value
        End Set
    End Property
#End Region

End Class

'''
''' DateTimePickerを用いた日付入力セルクラス
'''
Public Class DataGridViewDateCell
    Inherits DataGridViewTextBoxCell

    '''表示用フォーマット
    Private _customFormat As String = ""

    '''
    ''' 1
    '''
    '''
    '''
    Public Overrides Function Clone() As Object
        Dim cell As DataGridViewDateCell = DirectCast(MyBase.Clone(), DataGridViewDateCell)
        ' カスタムプロパティをコピー
        With cell
            .CustomFormat = Me.CustomFormat
        End With
        Return cell
    End Function

    '''
    '''
    '''
    '''
    '''
    '''
    '''
    Public Overrides Sub InitializeEditingControl(ByVal rowIndex As Integer,
        ByVal initialFormattedValue As Object,
        ByVal dataGridViewCellStyle As DataGridViewCellStyle)

        MyBase.InitializeEditingControl(rowIndex, initialFormattedValue,
                                        dataGridViewCellStyle)

        Dim dtp As DataGridViewDateEditingControl =
            TryCast(Me.DataGridView.EditingControl, DataGridViewDateEditingControl)

        If dtp Is Nothing Then
            Return
        End If

        Dim s As String = Trim(initialFormattedValue)
        Dim d As Date

        ' 日付が範囲外の場合はNothingとして扱う
        If DateTime.TryParse(s, d) Then
            If d >= dtp.MinDate _
            AndAlso d <= dtp.MaxDate Then
                dtp.Value = d
            Else
                dtp.Value = Nothing
            End If
        Else
            dtp.Value = Nothing
        End If

        ' カスタムプロパティをコピー
        Dim column As DataGridViewDateColumn =
            TryCast(Me.OwningColumn, DataGridViewDateColumn)
        If column IsNot Nothing Then
            With dtp
                .Format = column.Format
                .CustomFormat = column.InputFormat
                .MinDate = column.MinDate
                .MaxDate = column.MaxDate
            End With
        End If

    End Sub

    '''
    '''
    '''
    '''
    '''
    '''
    '''
    '''
    '''
    '''
    '''
    Protected Overrides Function GetFormattedValue(value As Object, rowIndex As Integer, ByRef cellStyle As System.Windows.Forms.DataGridViewCellStyle, valueTypeConverter As System.ComponentModel.TypeConverter, formattedValueTypeConverter As System.ComponentModel.TypeConverter, context As System.Windows.Forms.DataGridViewDataErrorContexts) As Object

        ' valueがNull値、または表示用フォーマットが指定されていない場合、
        ' 親クラスに文字列整形を任せる
        If value Is Nothing _
        OrElse Not IsDate(value) _
        OrElse String.IsNullOrEmpty(Trim(_customFormat)) Then
            Return MyBase.GetFormattedValue(value, rowIndex, cellStyle, valueTypeConverter, formattedValueTypeConverter, context)
        End If

        Try

            Dim d As DateTime = CDate(value)
            If d.Ticks = 0 Then
                Return ""
            End If

            Return d.ToString(_customFormat)

        Catch ex As InvalidCastException
            ' DateTimeにキャストできなかった場合も親クラスに文字列整形を任せる
            Return MyBase.GetFormattedValue(value, rowIndex, cellStyle, valueTypeConverter, formattedValueTypeConverter, context)
        End Try

    End Function

#Region "プロパティ"

    '''
    '''
    '''
    '''
    '''
    '''
    Public Overrides ReadOnly Property EditType() As System.Type
        Get
            Return GetType(DataGridViewDateEditingControl)
        End Get
    End Property

    '''
    '''
    '''
    '''
    '''
    '''
    Public Overrides ReadOnly Property ValueType As System.Type
        Get
            Return GetType(Nullable(Of Date))
        End Get
    End Property

    '''
    '''
    '''
    '''
    '''
    '''
    Public Overrides ReadOnly Property FormattedValueType As System.Type
        Get
            Return GetType(String)
        End Get
    End Property

    '''
    '''
    '''
    '''
    Public Overrides ReadOnly Property DefaultNewRowValue() As Object
        Get
            Return Nothing
        End Get
    End Property

    '''
    '''
    '''
    '''
    '''
    '''
    Public Property CustomFormat() As String
        Get
            Return _customFormat
        End Get
        Set(ByVal value As String)
            _customFormat = value
        End Set
    End Property

#End Region

End Class

'''
''' DateTimePickerの編集用コントロール
'''
Public Class DataGridViewDateEditingControl
    Inherits NullableDateTimePicker
    Implements IDataGridViewEditingControl

    ''' 親DataGridView
    Private _dataGridView As DataGridView
    ''' 編集行インデックス
    Private _rowIndex As Integer
    ''' 変更フラグ
    Private _valueChanged As Boolean = False

    Public Sub New()

        Me.TabStop = False
        Me.ImeModeBase = Windows.Forms.ImeMode.Disable
        Me.Format = DateTimePickerFormat.Custom
        Me.MinDate = Date.MinValue
        Me.MaxDate = Date.MaxValue

    End Sub

    Public Function GetEditingControlFormattedValue(
        ByVal context As DataGridViewDataErrorContexts) As Object _
        Implements IDataGridViewEditingControl.GetEditingControlFormattedValue

        Dim v As Date? = Me.Value
        If v Is Nothing Then
            Return ""
        End If

        Return CType(v, DateTime).ToString(Me.CustomFormat)

    End Function

    Public Sub ApplyCellStyleToEditingControl(
        ByVal dataGridViewCellStyle As DataGridViewCellStyle) _
        Implements IDataGridViewEditingControl.ApplyCellStyleToEditingControl

        Me.Font = dataGridViewCellStyle.Font
        Me.ForeColor = dataGridViewCellStyle.ForeColor
        Me.BackColor = dataGridViewCellStyle.BackColor

    End Sub

    Public Function EditingControlWantsInputKey(ByVal keyData As Keys,
        ByVal dataGridViewWantsInputKey As Boolean) As Boolean _
        Implements IDataGridViewEditingControl.EditingControlWantsInputKey

        Select Case keyData And Keys.KeyCode
            Case Keys.Right, Keys.[End], Keys.Left, Keys.Home, Keys.Delete
                Return True
            Case Else
                Return Not dataGridViewWantsInputKey
        End Select
    End Function

    Public Sub PrepareEditingControlForEdit(ByVal selectAll As Boolean) _
        Implements IDataGridViewEditingControl.PrepareEditingControlForEdit
        '
    End Sub

    Protected Overrides Sub OnEnter(e As System.EventArgs)

        ' Enterイベントが発生した時点で入力したとみなす
        ' 編集状態になったときに表示された文字列を入力された
        ' ものとみなすため
        Me._valueChanged = True
        Me._dataGridView.NotifyCurrentCellDirty(True)

        MyBase.OnEnter(e)

    End Sub

#Region "プロパティ"

    Public Property EditingControlFormattedValue() As Object _
        Implements IDataGridViewEditingControl.EditingControlFormattedValue

        Get
            If Me.IsNull() Then
                Return ""
            End If

            Return Me.GetEditingControlFormattedValue(
                DataGridViewDataErrorContexts.Formatting)
        End Get
        Set(ByVal value As Object)
            Try
                Me.Value = DateTime.Parse(CStr(value))
            Catch
                Me.Value = Nothing
            End Try
        End Set
    End Property

    Public Property EditingControlRowIndex() As Integer _
        Implements IDataGridViewEditingControl.EditingControlRowIndex

        Get
            Return Me._rowIndex
        End Get
        Set(ByVal value As Integer)
            Me._rowIndex = value
        End Set
    End Property

    Public ReadOnly Property RepositionEditingControlOnValueChange() As Boolean _
        Implements IDataGridViewEditingControl.RepositionEditingControlOnValueChange

        Get
            Return False
        End Get
    End Property

    Public Property EditingControlDataGridView() As DataGridView _
        Implements IDataGridViewEditingControl.EditingControlDataGridView

        Get
            Return Me._dataGridView
        End Get
        Set(ByVal value As DataGridView)
            Me._dataGridView = value
        End Set
    End Property

    Public Property EditingControlValueChanged() As Boolean _
        Implements IDataGridViewEditingControl.EditingControlValueChanged

        Get
            Return Me._valueChanged
        End Get
        Set(ByVal value As Boolean)
            Me._valueChanged = value
        End Set
    End Property


    Public ReadOnly Property EditingPanelCursor() As Cursor _
        Implements IDataGridViewEditingControl.EditingPanelCursor

        Get
            Return MyBase.Cursor
        End Get
    End Property

#End Region

End Class
