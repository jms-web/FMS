Imports System.ComponentModel

Public Class MultiColumnCombobox
    Inherits ComboBox

    Private _item As New MyCollection(Me)

#Region "コンストラクタ"
    Public Sub New()
        Call InitializeComponent()

        Me.SuspendLayout()
        Me.ResumeLayout(False)
    End Sub
#End Region


    ''' <summary>
    ''' ドロップダウンリストの列を設定します。
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    <DesignerSerializationVisibility(DesignerSerializationVisibility.Content)>
    <Category("ドロップダウンリストの列のカスタマイズ")>
    <Description("ドロップダウンリストの列を設定します")>
    Public Property DropDownColumns() As MyCollection
        Get
            Return _item
        End Get
        Set(ByVal value As MyCollection)
            _item = value
        End Set
    End Property

    ''' <summary>
    ''' ドロップダウンリストの列コレクションが変更された場合。
    ''' </summary>
    ''' <remarks></remarks>
    Friend Sub OnCollectionChanged()

        '列の幅の合計をドロップダウン部分の幅に設定。
        If DropDownColumns.Count > 0 Then
            MyBase.DropDownWidth = DropDownColumns(0).Width

            For i As Integer = 1 To DropDownColumns.Count - 1
                MyBase.DropDownWidth += DropDownColumns(i).Width
            Next
        End If
    End Sub

    ''' <summary>
    ''' ドロップダウンリストの列コレクションの設定。
    ''' </summary>
    ''' <remarks></remarks>
    <Runtime.InteropServices.ComVisible(False)>
    Public Class MyCollection
        Inherits System.Collections.ObjectModel.Collection(Of DropDownColumn)

        Private _parent As MultiColumnCombobox

        Friend Sub New(ByVal parent As MultiColumnCombobox)
            _parent = parent
        End Sub

        Protected Overrides Sub ClearItems()
            MyBase.ClearItems()
            _parent.OnCollectionChanged()
        End Sub

        Protected Overrides Sub InsertItem(ByVal index As Integer, ByVal item As DropDownColumn)

            '列の幅の初期値
            If item.Width = Nothing Then
                item.Width = _parent.Width
            End If

            MyBase.InsertItem(index, item)
            _parent.OnCollectionChanged()

        End Sub

        Protected Overrides Sub RemoveItem(ByVal index As Integer)
            MyBase.RemoveItem(index)
            _parent.OnCollectionChanged()
        End Sub

        Protected Overrides Sub SetItem(ByVal index As Integer, ByVal item As DropDownColumn)
            MyBase.SetItem(index, item)
            _parent.OnCollectionChanged()
        End Sub
    End Class

    ''' <summary>
    ''' 現在選択されている行のメンバーの値を取得します。
    ''' </summary>
    ''' <param name="member">メンバー</param>
    ''' <value></value>
    ''' <returns>選択されている値</returns>
    ''' <remarks></remarks>
    Public ReadOnly Property SelectMemberValue(ByVal member As String) As Object
        Get
            'データソースがない場合はNothingを返す。
            If MyBase.DataSource Is Nothing Then
                Return Nothing
            End If

            'データソースがデータテーブルでない場合はNothingを返す。
            If MyBase.DataSource.GetType IsNot GetType(DataTable) Then
                Return Nothing
            End If

            'DataTableを取得
            Dim dt As DataTable = CType(Me.DataSource, DataTable)

            'メンバーがデータテーブルの列でない場合はNothingを返す。
            If dt.Columns.IndexOf(member) = -1 Then
                Return Nothing
            End If

            'メンバーがデータテーブルの列の場合値を返す。
            Return dt.Rows(Me.SelectedIndex).Item(member)

        End Get
    End Property

    ''' <summary>
    ''' 描画処理
    ''' </summary>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Protected Overrides Sub OnDrawItem(ByVal e As System.Windows.Forms.DrawItemEventArgs)
        MyBase.OnDrawItem(e)

        '選択されているアイテムのハイライト
        e.DrawBackground()
        e.DrawFocusRectangle()

        'データソースがない場合は除外。
        If MyBase.DataSource Is Nothing Then
            Exit Sub
        End If

        'データソースがデータテーブルでない場合は除外
        If MyBase.DataSource.GetType IsNot GetType(DataTable) Then
            Exit Sub
        End If

        'データテーブルの取得
        Dim dt As DataTable = CType(MyBase.DataSource, DataTable)

        'アイテムの描画座標の取得
        Dim x As Integer = e.Bounds.X
        Dim y As Integer = e.Bounds.Y
        Dim width As Integer = e.Bounds.X
        Dim height As Integer = e.Bounds.Height
        Dim top As Integer = e.Bounds.Top
        Dim bottom As Integer = e.Bounds.Bottom

        '色の取得
        Dim grayPen As New Pen(Brushes.Gray)
        Dim brsh As New SolidBrush(e.ForeColor)

        '文字列の表示形式
        Dim sf As New StringFormat With {
            .Trimming = StringTrimming.EllipsisWord
        }

        Try
            For i As Integer = 0 To Me.DropDownColumns.Count - 1

                '列の幅の取得
                width = Me.DropDownColumns(i).Width

                '列の境界線の描画
                e.Graphics.DrawLine(grayPen, x + width, top, x + width, bottom)

                '列のメンバーの取得
                Dim columnIndex As String = Me.DropDownColumns(i).Member

                '列のメンバーがない場合またはデータテーブルの列でない場合は除外
                If columnIndex Is Nothing OrElse columnIndex = String.Empty _
                    OrElse dt.Columns.IndexOf(columnIndex) = -1 Then
                    x += width
                    Continue For
                End If

                '列に表示する値を取得
                Dim text As String = dt.Rows(e.Index)(columnIndex).ToString
                '描画領域
                Dim rectF As New RectangleF(CSng(x), CSng(y), CSng(width), CSng(height))
                '値の描画
                e.Graphics.DrawString(text, e.Font, brsh, rectF, sf)

                '次の列の座標
                x += width

            Next
        Finally
            'リソースの解放
            grayPen.Dispose()
            brsh.Dispose()
            sf.Dispose()
        End Try

    End Sub

End Class

''' <summary>
''' ドロップダウンリストに表示される列の定義
''' </summary>
''' <remarks></remarks>
Public Class DropDownColumn

    ''' <summary>
    ''' 列のプロパティ
    ''' </summary>
    ''' <remarks></remarks>
    Private _member As String

    ''' <summary>
    ''' 列のプロパティを設定または取得します。
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    <Description("列のプロパティ")>
    Public Property Member As String
        Get
            Return _member
        End Get
        Set(ByVal value As String)
            _member = value
        End Set
    End Property

    ''' <summary>
    ''' 列の幅
    ''' </summary>
    ''' <remarks></remarks>
    Private _width As Integer = Nothing

    ''' <summary>
    ''' 列の幅を設定または取得します。
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    <Description("列の幅")>
    Public Property Width As Integer
        Get
            Return _width
        End Get
        Set(ByVal value As Integer)
            _width = value
        End Set
    End Property

    ''' <summary>
    ''' コンストラクタ
    ''' </summary>
    ''' <remarks></remarks>
    Public Sub New()
        'インスタンスの初期化
    End Sub

    ''' <summary>
    ''' コンストラクタ
    ''' </summary>
    ''' <param name="paramMember">表示する列名</param>
    ''' <param name="paramWidth">幅</param>
    ''' <remarks>ドロップダウンリストに表示される列の定義</remarks>
    Public Sub New(ByVal paramMember As String, ByVal paramWidth As Integer)
        Member = paramMember
        Width = paramWidth
    End Sub
End Class
