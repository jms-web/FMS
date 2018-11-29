Imports System
Imports System.Drawing
Imports System.Collections.Generic
Imports System.Text


Class DateFilter
    Implements C1.Win.C1FlexGrid.IC1ColumnFilter
    '-------------------------------------------------------------------------------
#Region "** フィールド"

    Private _min As DateTime = DateTime.MinValue
    Private _max As DateTime = DateTime.MaxValue

#End Region

    '-------------------------------------------------------------------------------
#Region "** オブジェクトモデル"

    ''' <summary>
    ''' フィルタで指定可能な日付の最小有効値を取得または設定します。
    ''' </summary>
    Public Property Minimum() As DateTime
        Get
            Return _min
        End Get
        Set(ByVal value As DateTime)
            _min = value
        End Set
    End Property
    ''' <summary>
    ''' フィルタで指定可能な日付の最大有効値を取得または設定します。
    ''' </summary>
    Public Property Maximum() As DateTime
        Get
            Return _max
        End Get
        Set(ByVal value As DateTime)
            _max = value
        End Set
    End Property

#End Region

    '-------------------------------------------------------------------------------
#Region "** IC1ColumnFilter メンバ"

    ' 表示できる日付の全てが範囲に含まれていない場合、フィルタがアクティブになります。
    Public ReadOnly Property IsActive() As Boolean Implements C1.Win.C1FlexGrid.IC1ColumnFilter.IsActive
        Get
            Return _min <> DateTime.MinValue OrElse _max <> DateTime.MaxValue
        End Get
    End Property

    ' フィルタをリセットします。
    Public Sub Reset() Implements C1.Win.C1FlexGrid.IC1ColumnFilter.Reset
        _min = DateTime.MinValue
        _max = DateTime.MaxValue
    End Sub

    ' 指定された日付にフィルタを設定します。
    Public Function Apply(ByVal value As Object) As Boolean Implements C1.Win.C1FlexGrid.IC1ColumnFilter.Apply
        Try

            Dim dt As Date
            If DateTime.TryParse(value, dt) Then
                Return dt >= _min AndAlso dt <= _max
            Else
                Return True
            End If
        Catch ex As InvalidCastException
            Return False
        End Try
    End Function

    ' フィルタ用のエディタコントロールを返します。
    Public Function GetEditor() As C1.Win.C1FlexGrid.IC1ColumnFilterEditor Implements C1.Win.C1FlexGrid.IC1ColumnFilter.GetEditor
        Return New DateFilterEditor()
    End Function

#End Region
End Class
