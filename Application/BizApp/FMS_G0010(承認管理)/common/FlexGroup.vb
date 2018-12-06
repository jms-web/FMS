'
' FlexGroup.vb
'
' C1FlexGridコントロールを用いたOutlookスタイルのグループ化のインプリメント
'
Imports System.Text
Imports System.ComponentModel
Imports System.Reflection
Imports C1.Win.C1FlexGrid

Public Class FlexGroupControl
    Inherits System.Windows.Forms.PictureBox
    Implements ISupportInitialize

    ' フィールド
    Dim WithEvents _flex As C1FlexGrid         ' グリッドコントロール
    Dim _groups As ArrayList        ' グループ領域内のフィールドリスト（列）
    Dim _dragger As FieldDragger    ' ドラッグ領域へのAUXコントロール 
    Dim _styleGroup As CellStyle    ' グループの描画に使用
    Dim _styleEmpty As CellStyle    ' 空白領域の描画に使用
    Dim _showGroups As Boolean      ' グループ領域の表示／非表示
    Dim _insGroup As Boolean        ' 挿入された列はグループ／列のいずれか 
    Dim _dirty As Boolean           ' グループのリフレッシュに必要
    Dim _insIndex As Integer        ' どのグループ／列に挿入すべきかを示すインデックス
    Dim _insRect As Rectangle       ' 挿入されたインジケータが描画される四角形
    Dim _insRectLast As Rectangle   ' 最後に挿入されたインジケータが描画される四角形
    Dim _brBack As SolidBrush       ' グループ領域の描画に用いられるGDIオブジェクト
    Dim _brFore As SolidBrush
    Dim _brGrp As SolidBrush
    Dim _brBdr As SolidBrush
    Dim _filterRow As FilterRow     ' フィルター行（FilterRowプロパティで可視化を制御）
    Dim _groupMessage As String     ' 空のグループ領域に表示するメッセージ

    Shared _sf As StringFormat
    Shared _bmpInsert As Bitmap     ' 挿入アイコン
    Shared _bmpSortUp As Bitmap     ' ソートアイコン
    Shared _bmpSortDn As Bitmap     ' ソートアイコン

    Const CONST_MARGIN As Integer = 8                ' グループと端の間の空白
    Const SCROLLSTEP As Integer = 15           ' スクロールのステップ（マウスドラッグ間）
    Const DRAGTHRESHOLD As Integer = 8         ' 列のドラッグを開始する前のピクセル
    Const GROUP_MSG As String = "グループ化するには、ここに列ヘッダをドラッグしてください。"

    Public Sub New()
        MyBase.New()

        ' 静的(shared)メンバーの初期化
        If _sf Is Nothing Then
            _sf = New StringFormat(StringFormat.GenericDefault)
            _sf.Alignment = StringAlignment.Center
            _sf.LineAlignment = StringAlignment.Center
            _bmpInsert = Global.FMS.My.Resources.Resources.InsertPoint 'LoadBitmap("InsertPoint", Color.White)
            _bmpSortUp = Global.FMS.My.Resources.Resources.SortUp 'LoadBitmap("SortUp", Color.Red)
            _bmpSortDn = Global.FMS.My.Resources.Resources.SortDn 'LoadBitmap("SortDn", Color.Red)
        End If

        ' 含まれるFlex コントロールの初期化
        _flex = New C1FlexGrid()
        _flex.BorderStyle = C1.Win.C1FlexGrid.Util.BaseControls.BorderStyleEnum.None
        _flex.Dock = DockStyle.Bottom
        _flex.Size = New Size(10, 10)
        _flex.AllowSorting = AllowSortingEnum.None
        _flex.AllowMerging = AllowMergingEnum.Nodes
        _flex.Cols(0).Width = _flex.Rows.DefaultSize
        _flex.ShowCursor = True
        _flex.Tree.Style = TreeStyleFlags.Symbols
        _flex.DrawMode = DrawModeEnum.OwnerDraw

        ' スタイルの初期化
        _flex.Styles.Normal.Border.Direction = BorderDirEnum.Horizontal
        _styleGroup = _flex.Styles.Add("Group", _flex.Styles.Fixed)
        _styleEmpty = _flex.Styles.Add("Empty", _flex.Styles.EmptyArea)
        _styleEmpty.BackColor = SystemColors.ControlDarkDark
        _styleEmpty.ForeColor = SystemColors.ControlLightLight

        ' 内部メンバの初期化
        _groupMessage = GROUP_MSG
        _groups = New ArrayList()
        _showGroups = True
        _insIndex = -1

        ' FieldDraggerコントロールの初期化
        _dragger = New FieldDragger(Me)

        ' フィルタ行を追加します。
        _filterRow = New FilterRow(_flex)
        _filterRow.Visible = False

        ' 親コントロールの初期化
        SuspendLayout()
        BorderStyle = Windows.Forms.BorderStyle.Fixed3D
        BackColor = SystemColors.ControlDark
        ForeColor = SystemColors.ControlLightLight
        Controls.AddRange(New System.Windows.Forms.Control() {_dragger, _flex})
        ResumeLayout(False)
    End Sub

    ' ** ISupportInitialize

    Sub BeginInit()
        _flex.BeginInit()
    End Sub

    Sub EndInit()
        _flex.EndInit()

        ' スタイルを再生成し、
        ' カスタムスタイルへの参照を取得します。
        _styleGroup = _flex.Styles("Group")
        _styleEmpty = _flex.Styles("Empty")
        _flex.Visible = True
    End Sub

    ' ** オブジェクトモデル

    <DesignerSerializationVisibility(DesignerSerializationVisibility.Content)> _
    ReadOnly Property Grid() As C1FlexGrid
        Get
            Grid = _flex
        End Get
    End Property

    Property ShowGroups() As Boolean
        Get
            Return _showGroups
        End Get
        Set(ByVal Value As Boolean)
            _showGroups = Value
            UpdateLayout()
        End Set
    End Property

    <DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)> _
    ReadOnly Property StyleGroupRows() As CellStyle
        Get
            Return _styleGroup
        End Get
    End Property

    <DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)> _
    ReadOnly Property StyleGroupArea() As CellStyle
        Get
            Return _styleGroup
        End Get
    End Property

    <Description("Gets or sets the message shown in the empty group area."), _
    DefaultValue(GROUP_MSG)> _
    Public Property GroupMessage() As String
        Get
            Return _groupMessage
        End Get
        Set(ByVal Value As String)
            _groupMessage = Value
            Invalidate()
        End Set
    End Property

    <Description("Gets or sets a comma-delimited list of the groups (by column name)."), _
 DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)> _
    Public Property Groups() As String
        Get
            ' 列名を用いて文字列を作成します。
            Dim sb As New StringBuilder()
            Dim col As Column
            For Each col In _groups
                If sb.Length > 0 Then sb.Append(", ")
                sb.Append(col.Name)
            Next
            Return sb.ToString()
        End Get
        Set(ByVal Value As String)
            ' 現在のグループを表示します。
            _flex.BeginUpdate()
            Dim col As Column
            For Each col In _groups
                col.Visible = True
            Next

            ' _groups コレクションを作成します。
            _groups.Clear()
            Dim colName As String
            For Each colName In Value.Split(",")
                col = _flex.Cols(colName.Trim())
                If Not IsNothing(col) Then _groups.Add(col)
            Next

            ' 新規コレクションを適用します。
            UpdateGroups()
            UpdateLayout()

            ' 完了
            _flex.EndUpdate()
        End Set
    End Property

    <Description("Gets or sets whether the control should display a filter row above the data."), _
     DefaultValue(False)> _
    Public Property FilterRow() As Boolean
        Get
            Return _filterRow.Visible
        End Get
        Set(ByVal Value As Boolean)
            If _filterRow.Visible <> Value Then
                _filterRow.Clear()
                _filterRow.Visible = Value
            End If
        End Set
    End Property

    <Browsable(False), EditorBrowsable(EditorBrowsableState.Never)> _
    Shadows Property Image() As Image
        Get
            Return MyBase.Image
        End Get
        Set(ByVal Value As Image)
            MyBase.Image = Value
        End Set
    End Property

    ' ** オーバーライド

    ' コントロールがリサイズされたとき、レイアウトを調整します。
    Protected Overrides Sub OnResize(ByVal e As EventArgs)
        UpdateLayout()
        MyBase.OnResize(e)
    End Sub

    ' グループのドラッグを開始します。
    Protected Overrides Sub OnMouseDown(ByVal e As MouseEventArgs)

        ' 左側のボタンに注目します。
        Dim i As Integer, rc As Rectangle
        If (e.Button And Windows.Forms.MouseButtons.Left) <> 0 Then
            For i = 0 To _groups.Count - 1
                rc = GetGroupRectangle(i)
                If rc.Contains(e.X, e.Y) Then
                    _dragger.StartDragging(_groups(i), rc)
                    Exit Sub
                End If
            Next
        End If

        ' ベースとなるクラスの処理を許可します。
        MyBase.OnMouseDown(e)
    End Sub

    ' グループ領域を描画します。
    Protected Overrides Sub OnPaint(ByVal e As PaintEventArgs)
        UpdateObjects()
        Dim g As Graphics = e.Graphics

        ' グループ領域を取得します。
        Dim rc As Rectangle = ClientRectangle
        rc.Height = _flex.Top

        ' 背景を描画します。
        g.FillRectangle(_brBack, rc)
        If _groups.Count = 0 Then
            g.DrawString(_groupMessage, _styleEmpty.Font, _brFore, ToRCF(rc), _sf)
        Else ' グループを描画します。
            Dim i As Integer
            For i = 0 To _groups.Count - 1
                rc = GetGroupRectangle(i)
                PaintGroup(g, rc, _groups(i))
            Next
        End If

        ' ドラッグ中に挿入位置を表示します。
        If _dragger.Visible Then
            DrawImageCentered(g, _bmpInsert, _insRect)
        End If
    End Sub

    ' グリッドのスタイルに基づくGDIオブジェクトを更新します。
    Sub UpdateObjects()
        Dim clr As Color

        ' グループ領域のドラッグに用いるオブジェクトを更新します。
        clr = _styleEmpty.BackColor
        If (_brBack Is Nothing) OrElse (Not _brBack.Color.Equals(clr)) Then _brBack = New SolidBrush(clr)

        clr = _styleEmpty.ForeColor
        If (_brFore Is Nothing) OrElse (Not _brFore.Color.Equals(clr)) Then _brFore = New SolidBrush(clr)

        ' グループを描画するために使用するオブジェクトを更新します。
        clr = _styleGroup.BackColor
        If (_brGrp Is Nothing) OrElse (Not _brGrp.Color.Equals(clr)) Then _brGrp = New SolidBrush(clr)

        clr = _styleGroup.Border.Color
        If (_brBdr Is Nothing) OrElse (Not _brBdr.Color.Equals(clr)) Then _brBdr = New SolidBrush(clr)
    End Sub

    ' ** イベントハンドラ

    ' キーが押されたとき、ドラッグをキャンセルします。
    Private Sub _flex_KeyPress(ByVal sender As Object, ByVal e As KeyPressEventArgs) Handles _flex.KeyPress
        If _dragger.Visible Then
            _dragger.Visible = False
            Invalidate()
        End If
    End Sub

    ' 列のドラッグを開始します。
    Private Sub _flex_BeforeMouseDown(ByVal sender As Object, ByVal e As BeforeMouseDownEventArgs) Handles _flex.BeforeMouseDown

        ' 左のボタンに注目します。
        If (e.Button And Windows.Forms.MouseButtons.Left) = 0 Then Exit Sub

        ' 列ヘッダ上でクリックされたかチェックします。
        Dim hti As HitTestInfo = _flex.HitTest(e.X, e.Y)
        If hti.Type <> HitTestTypeEnum.ColumnHeader Then Exit Sub

        ' スクロール可能な列上でクリックされたかチェックします。
        Dim cols As ColumnCollection = _flex.Cols
        If hti.Column < cols.Fixed Then Exit Sub

        ' 最初の行でクリックされたかチェックします。
        ' (この場合、追加の固定行が存在します)
        If hti.Row > 0 Then Exit Sub

        ' イベントをキャンセルします。
        e.Cancel = True

        ' 少なくともひとつのグループ化されていない列があるかどうかチェックします。
        If _groups.Count >= cols.Count - cols.Fixed - 1 Then Exit Sub

        ' 列のドラッグを開始します。
        _dragger.StartDragging(cols(hti.Column))
    End Sub

    ' 列のリサイズ後にレイアウトを更新します。
    Private Sub _flex_AfterResizeColumn(ByVal sender As Object, ByVal e As RowColEventArgs) Handles _flex.AfterResizeColumn
        UpdateLayout()
    End Sub

    ' Outlookスタイルでセルを描画します。
    Private Sub _flex_OwnerDrawCell(ByVal sender As Object, ByVal e As OwnerDrawCellEventArgs) Handles _flex.OwnerDrawCell

        ' ツリー列上のスクロール可能な行のみカスタムで描画します。
        If _groups.Count = 0 Then Exit Sub
        If e.Col <> _flex.Tree.Column Then Exit Sub
        If e.Row < _flex.Rows.Fixed Then Exit Sub

        ' 必要なGDIオブジェクトが取得できたかどうかをチェックします。
        UpdateObjects()

        ' 必要なパラメータを取得します。
        Dim row As Row = _flex.Rows(e.Row)
        If row.Node Is Nothing Then Return
        Dim idt As Integer = _flex.Tree.Indent
        Dim x As Integer = _flex.ScrollPosition.X
        Dim lvl As Integer = row.Node.Level
        Dim rc As Rectangle

        ' カスタム描画ノード
        If row.IsNode Then

            ' 背景と内容を描画します。
            e.Style = _styleGroup
            e.DrawCell(DrawCellFlags.Background Or DrawCellFlags.Content)

            ' 上部の線を描画します。
            If (lvl = 0) OrElse (Not _flex.Rows(e.Row - 1).IsNode) Then
                rc = e.Bounds
                OffsetLeft(rc, lvl * idt + x)
                rc.Height = 1
                e.Graphics.FillRectangle(_brBdr, rc)
            End If

            ' ノードが展開されていれば、下部の線を描画します。
            If row.Node.Expanded Then
                rc = e.Bounds
                OffsetLeft(rc, (lvl + 1) * idt + x)
                rc.Y = rc.Bottom - 1
                rc.Height = 1
                e.Graphics.FillRectangle(_brBdr, rc)
            End If

            ' シンボルの左まで縦線を描画します。
            rc = e.Bounds
            rc.X += x
            rc.Width = 1
            Dim i As Integer
            For i = 0 To lvl
                e.Graphics.FillRectangle(_brBdr, rc)
                rc.Offset(idt, 0)
            Next

        Else ' カスタム描画データ

            ' ベースを描画します。
            e.DrawCell()

            ' 左側の領域を満たします。
            rc = e.Bounds
            rc.Width = (lvl + 1) * idt
            e.Graphics.FillRectangle(_brGrp, rc)

            ' 満たされた領域上に縦線を描画します。
            rc = e.Bounds
            rc.Width = 1
            Dim i As Integer
            For i = 0 To lvl + 1
                e.Graphics.FillRectangle(_brBdr, rc)
                rc.Offset(idt, 0)
            Next
        End If
    End Sub

    Public Sub OffsetLeft(ByRef rc As Rectangle, ByVal x As Integer)
        rc.X = rc.X + x
        rc.Width = rc.Width - x
    End Sub

    ' データソースが変更されたとき、グループをリセットします。
    Private Sub _flex_DataChanged(ByVal sender As Object, ByVal e As ListChangedEventArgs) Handles _flex.AfterDataRefresh
        If e.ListChangedType = ListChangedType.Reset Then
            UpdateGroups()
        End If
    End Sub

    ' スタイルが変更されたときコントロールを再描画します。
    Private Sub _flex_GridChanged(ByVal sender As Object, ByVal e As GridChangedEventArgs) Handles _flex.GridChanged
        If e.GridChangedType = GridChangedTypeEnum.RepaintGrid Then
            Invalidate()
        End If
    End Sub

    ' ** ユーティリティ

    ' グループ領域のサイズを更新します。
    Sub UpdateLayout()

        ' グループ領域のサイズを計算します。
        Dim hei As Integer = 0
        If _showGroups Then
            If _groups.Count > 0 Then
                hei = GetGroupRectangle(_groups.Count - 1).Bottom + CONST_MARGIN
            Else
                hei = 2 * _flex.Rows.DefaultSize
            End If
        End If

        ' 残りの領域にグリッドを移動します。
        _flex.Height = ClientRectangle.Height - hei

        ' コントロールを再描画します。
        Invalidate()

        ' グループを更新します。
        UpdateGroups()
    End Sub

    ' グループ化／ソートを更新します。
    Function UpdateGroupNeeded() As Boolean

        ' データソースが変更されたら、グループをリセットします。
        Dim i As Integer
        For i = 0 To _groups.Count - 1
            Dim col As Column = _groups(i)

            ' インデックスが不正なら、それをフィックスします。
            If col.Index < 0 Then
                If _flex.Cols.Contains(col.Name) Then
                    _groups(i) = _flex.Cols(col.Name)
                Else
                    _groups.Clear()
                    Return True
                End If
            End If
        Next

        ' グループは最初の列で、しかも非表示でなければなりません。
        Dim cols As ColumnCollection = _flex.Cols
        Dim iFixed As Integer = cols.Fixed
        For i = 0 To _groups.Count - 1
            Dim col As Column = cols(i + iFixed)
            If (col.Visible) OrElse (Not _groups(i).Equals(col)) Then Return True
        Next


        ' 残りの列を表示します。
        For i = iFixed + _groups.Count To cols.Count - 1
            If Not cols(i).Visible Then Return True
            Return False
        Next
        Return False
    End Function

    ' グループ化／ソートを更新します。
    Sub UpdateGroups()

        ' グループを更新する必要があるかどうかチェックします。
        If (Not _dirty) AndAlso (Not UpdateGroupNeeded()) Then Return

        ' しばらくの間、描画をストップします。
        _flex.BeginUpdate()

        ' サブトータルを削除します。
        _flex.Subtotal(AggregateEnum.Clear)

        ' グループの列を調節します。
        Dim cols As ColumnCollection = _flex.Cols
        Dim index As Integer = cols.Fixed
        Dim col As Column
        For Each col In _groups

            ' 列の位置／可視性を調整します。
            col.Visible = False
            cols.Move(col.Index, index)
            index = index + 1

            ' 必要ならソーと方向を初期化します。
            If (col.Sort And (SortFlags.Ascending Or SortFlags.Descending)) = 0 Then
                col.Sort = SortFlags.Ascending
            End If
        Next

        'TODO: 常に非表示にしたい列をあらかじめ指定する

        'グループ列以外全て表示
        For index = index To cols.Count - 1
            cols(index).Visible = True
        Next

        ' 列をソートします。
        _flex.Sort(SortFlags.UseColSort, cols.Fixed, _groups.Count)

        ' ツリーが右側の位置にあるかどうか確認します。
        _flex.Tree.Column = cols.Fixed + _groups.Count

        ' ツリーのコンテンツが左寄せ（またはマージされていない）かどうか確認します。
        _flex.Cols(_flex.Tree.Column).TextAlign = TextAlignEnum.LeftCenter


        ' サブトータルを挿入します。
        For index = 0 To _groups.Count - 1
            Dim icol As Integer = index + cols.Fixed
            Dim fmt As String = cols(icol).Caption + ": {0}"
            _flex.Subtotal(AggregateEnum.Count, index, icol, cols.Count - 1, fmt)
        Next

        ' 完了です。
        _dirty = False
        _flex.EndUpdate()
    End Sub

    ' インジケータの挿入位置を更新します。
    Sub UpdateInsertLocation()
        Dim loc As Point = PointToClient(Control.MousePosition)
        Dim rc As Rectangle

        ' メンバーを更新します。
        _insRect = Rectangle.Empty
        _insIndex = -1

        ' グループリストに挿入します。
        If loc.Y < _flex.Top Then

            ' 新規グループを挿入する位置を見つけます。
            Dim index As Integer = _groups.Count
            Dim i As Integer
            For i = 0 To _groups.Count - 1
                rc = GetGroupRectangle(i)
                If rc.X + rc.Width / 2 > loc.X Then
                    index = i
                    Exit For
                End If
            Next

            ' 挿入情報を更新します。
            _insGroup = True
            _insIndex = index

            ' 挿入位置を更新します。
            If index < _groups.Count Then
                _insRect = GetGroupRectangle(index)
                _insRect.X = _insRect.X - CONST_MARGIN
            Else
                _insRect = GetGroupRectangle(_groups.Count - 1)
                _insRect.X = _insRect.Right
            End If
            If index > 0 AndAlso index < _groups.Count Then
                _insRect.Y = _insRect.Y - _insRect.Height / 2
                _insRect.Height = _insRect.Height + _insRect.Height / 2
            End If
            _insRect.Width = CONST_MARGIN

        Else ' グループリスト（グリッドに挿入）から削除します。

            ' グリッド列を挿入する位置を見つけます。
            Dim index As Integer = _flex.Cols.Count
            Dim i As Integer
            For i = _flex.Cols.Fixed To _flex.Cols.Count - 1
                rc = _flex.GetCellRect(0, i, False)
                If rc.X + rc.Width / 2 > loc.X Then
                    index = i
                    Exit For
                End If
            Next

            ' 挿入情報を更新します。
            _insGroup = False
            _insIndex = index

            ' 挿入位置を更新します。
            If index < _flex.Cols.Count Then
                _insRect = _flex.GetCellRect(0, index, False)
                _insRect.Width = 0
            Else
                _insRect = _flex.GetCellRect(0, index - 1, False)
                _insRect.X = _insRect.Right
                _insRect.Width = 0
            End If
            _insRect.Inflate(CONST_MARGIN / 2, 5)
            _insRect.Offset(0, _flex.Top)
        End If

        ' 新規挿入ポイントを表示するために、無効にします。
        If Not _insRect.Equals(_insRectLast) Then
            Invalidate()
            _insRectLast = _insRect
        End If
    End Sub

    ' 列（またはグループ）のドラッグを終了します。
    Sub FinishDragging(ByVal col As Column, ByVal dragged As Boolean)

        ' ドラッグされなかった場合、通常／逆ソートがクリックされました。
        If Not dragged Then

            ' 逆の列ソート
            If (col.Sort And SortFlags.Ascending) <> 0 Then
                col.Sort = SortFlags.Descending
            Else
                col.Sort = SortFlags.Ascending
            End If

            ' もし非グループ列なら、アンバウンド時のみソートします。
            ' （グループ化を台無しにしないため）
            If Not _groups.Contains(col) Then
                If (_groups.Count = 0) OrElse (_flex.DataSource Is Nothing) Then
                    _flex.Sort(col.Sort, col.Index)
                    Return
                End If
            End If

            ' グループコレクションに列を挿入します。
        ElseIf _insGroup Then

            ' グループを適切な場所でリストに追加します。 (col->grp, grp->grp)
            _groups.Insert(_insIndex, col)
            Dim i As Integer
            For i = 0 To _groups.Count - 1
                If (i <> _insIndex) AndAlso (_groups(i).Equals(col)) Then
                    _groups.RemoveAt(i)
                    Exit For
                End If
                col.Visible = False
            Next

        Else ' グリッドに列を挿入します。

            ' 列を新しい位置へ移動します。 (col->col, grp->col)
            Dim oldIndex As Integer = col.Index
            Dim newIndex As Integer = _insIndex
            If newIndex > oldIndex Then newIndex = newIndex - 1
            _flex.Cols.Move(oldIndex, newIndex)
            col.Visible = True

            ' 既にある場合、グループリストから削除します。 (grp->col)
            If _groups.Contains(col) Then
                _groups.Remove(col)
            End If
        End If

        ' レイアウトを更新し、再描画します。
        _dirty = True
        UpdateLayout()
    End Sub

    ' グループ領域内でのグループの位置を取得します。
    Function GetGroupRectangle(ByVal index As Integer) As Rectangle

        ' 最上部の小さな四角形を生成します。
        Dim rc As Rectangle = New Rectangle(CONST_MARGIN, CONST_MARGIN, 0, _flex.Rows.DefaultSize)

        ' 可能なら幅を設定します。
        ' （WidthDisplayは使用しません。なぜならグループ列は非表示なので、
        ' WidthDisplay wはゼロを戻すからです。
        Dim wid As Integer
        If (index > -1) AndAlso (index < _groups.Count) Then
            wid = _groups(index).Width ' <<B1.2>>
            If wid < 0 Then wid = Grid.Cols.DefaultSize
            rc.Width = wid
        End If

        ' ループして位置を調整します。
        Dim i As Integer
        For i = 0 To index - 1
            wid = _groups(i).Width ' <<B1.2>>
            If wid < 0 Then wid = Grid.Cols.DefaultSize
            rc.X = rc.X + wid + CONST_MARGIN
            rc.Y = rc.Y + rc.Height / 2
        Next

        ' 四角形を戻します。
        Return rc
    End Function

    ' 画像を四角形の中で中央に配置します。
    Sub DrawImageCentered(ByVal g As Graphics, ByVal img As Image, ByVal rc As Rectangle)
        Dim sz As Size = img.Size
        rc.Offset((rc.Width - sz.Width) / 2, (rc.Height - sz.Height) / 2)
        rc.Size = sz
        g.DrawImageUnscaled(img, rc)
        Console.WriteLine("rc is {0} {1} {2} {3}", rc.X, rc.Y, rc.Width, rc.Height)
    End Sub

    ' アセンブリのリソースからビットマップをロードします。
    Function LoadBitmap(ByVal name As String, ByVal transparent As Color) As Bitmap
        Dim a As System.Reflection.Assembly = System.Reflection.Assembly.GetExecutingAssembly()
        Dim resName As String = String.Format("{0}.{1}.bmp", a.GetName().Name, name)
        Dim s As String() = a.GetManifestResourceNames()
        Dim bmp As Bitmap = New Bitmap(a.GetManifestResourceStream(resName))
        bmp.MakeTransparent(transparent)
        Return bmp
    End Function

    ' draggerコントロールを用いて、グループを描画します。
    Sub PaintGroup(ByVal g As Graphics, ByVal rc As Rectangle, ByVal col As Column)

        ' コントロールを描画します。
        _dragger.PaintControl(g, rc, col.Caption, False)

        ' ソート記号を描画します。
        Dim img As Image = Nothing
        If _flex.ShowSort Then
            If (col.Sort And SortFlags.Ascending) <> 0 Then
                img = _bmpSortUp
            ElseIf (col.Sort And SortFlags.Descending) <> 0 Then
                img = _bmpSortDn
            End If
            If Not img Is Nothing Then
                rc.X = rc.Right - rc.Height
                rc.Width = rc.Height
                DrawImageCentered(g, img, rc)
            End If
        End If
    End Sub

    Function ToRCF(ByVal rc As Rectangle) As RectangleF
        Return New RectangleF(rc.X, rc.Y, rc.Width, rc.Height)
    End Function

    '/ <summary>
    '/ FieldDragger
    '/ フィールドのドラッグをインプリメントするための内部クラスです。
    '/ </summary>
    Private Class FieldDragger
        Inherits Label
        Dim _owner As FlexGroupControl
        Dim _column As Column
        Dim _offset As Point
        Dim _ptDown As Point
        Dim _dragging As Boolean
        Dim _rcClip As Rectangle
        Dim _brBack As SolidBrush
        Dim _brFore As SolidBrush
        Dim _brDrag As SolidBrush

        Shared _sf As StringFormat
        Shared _pDark As Pen
        Shared _pLite As Pen

        ' ** ctor
        Public Sub New(ByVal owner As FlexGroupControl)

            ' 静的なメンバーを初期化します。
            If _sf Is Nothing Then
                _pDark = SystemPens.ControlDark
                _pLite = SystemPens.ControlLightLight
                _sf = New StringFormat(StringFormat.GenericDefault)
                _sf.Alignment = StringAlignment.Near
                _sf.LineAlignment = StringAlignment.Center
                _sf.FormatFlags = _sf.FormatFlags Or StringFormatFlags.NoWrap
            End If

            ' コントロールを初期化します。
            _owner = owner
            Visible = False
            BackColor = Color.Transparent
        End Sub

        ' ** オーバーライド

        ' カスタムの描画ルーチンを使用します。
        Protected Overrides Sub OnPaint(ByVal e As PaintEventArgs)
            Dim rc As Rectangle = ClientRectangle
            PaintControl(e.Graphics, rc, _column.Caption, True)
        End Sub

        ' マウスで移動します。
        Protected Overrides Sub OnMouseMove(ByVal e As MouseEventArgs)

            ' 左ボタンを押している間、ドラッグを続けます。
            If (e.Button And Windows.Forms.MouseButtons.Left) = 0 Then Return

            ' 少しでもマウスが移動したかどうか確認します。
            If Not _dragging Then
                Dim ptNow As Point = Control.MousePosition
                If Math.Abs(ptNow.X - _ptDown.X) < DRAGTHRESHOLD AndAlso _
                    Math.Abs(ptNow.Y - _ptDown.Y) < DRAGTHRESHOLD Then Return
                _dragging = True
            End If

            ' コントロールの新規位置を計算します。
            Dim pos As Point = _owner.PointToClient(Control.MousePosition)
            Dim loc As Point = pos
            loc.Offset(-_offset.X, -_offset.Y)

            ' グループ領域を切り取り、スクロールします。
            Dim rc As Rectangle = _rcClip
            Dim g As C1FlexGrid = _owner.Grid
            Dim pt As Point = g.ScrollPosition
            If loc.X + Width > rc.Right Then
                loc.X = rc.Right - Width
                pt.X = pt.X - SCROLLSTEP
            End If
            If loc.X < 0 Then
                loc.X = 0
                pt.X = pt.X + SCROLLSTEP
            End If
            If loc.Y + Height > rc.Bottom Then loc.Y = rc.Bottom - Height
            If loc.Y < 0 Then loc.Y = 0

            ' draggerコントロールを移動します。
            If Not Location.Equals(loc) Then Location = loc

            ' グリッドをスクロールします。
            Dim scroll As Boolean = False
            If (pos.Y >= _owner.Grid.Top) AndAlso (Not g.ScrollPosition.Equals(pt)) Then
                Dim oldPos As Point = g.ScrollPosition
                g.ScrollPosition = pt
                scroll = Not g.ScrollPosition.Equals(oldPos)
            End If

            ' 挿入場所を更新します（グリッドのスクロール後）。
            _owner.UpdateInsertLocation()

            ' スクロールを続けます。
            If scroll Then
                _owner.Update()
                OnMouseMove(e)
            End If
        End Sub

        ' 左ボタンがリリースされたら、ドラッグを終了します。
        Protected Overrides Sub OnMouseUp(ByVal e As MouseEventArgs)

            ' 左ボタンが押されていないか確認します。
            If (Control.MouseButtons And Windows.Forms.MouseButtons.Left) <> 0 Then Return

            ' 可視状態かどうか確認します。
            If Not Visible Then Return

            ' 非表示にし、ドラッグを終了します。
            Visible = False
            _owner.FinishDragging(_column, _dragging)
        End Sub

        ' フォーカスを失ったら、キャンセルします。
        Protected Overrides Sub OnLeave(ByVal a As EventArgs)
            Visible = False
        End Sub

        ' ** ユーティリティ

        ' グループのスタイルに基づくGDIオブジェクトを更新します。
        Sub UpdateObjects()

            Dim clr As Color

            Dim cs As CellStyle = _owner.Grid.Styles("Group")

            clr = cs.BackColor
            If (_brBack Is Nothing) OrElse (Not _brBack.Color.Equals(clr)) Then
                _brBack = New SolidBrush(clr)
                _brDrag = New SolidBrush(Color.FromArgb(100, clr))
            End If

            clr = cs.ForeColor
            If (_brFore Is Nothing) OrElse (Not _brFore.Color.Equals(clr)) Then
                _brFore = New SolidBrush(clr)
            End If

            Font = cs.Font
        End Sub

        ' グリッドの列のドラッグを開始します。
        Sub StartDragging(ByVal col As Column)
            Dim g As C1FlexGrid = _owner.Grid
            Dim rc As Rectangle = g.GetCellRect(0, col.Index, False)
            rc.Width = col.WidthDisplay
            rc = g.RectangleToScreen(rc)
            rc = _owner.RectangleToClient(rc)
            StartDragging(col, rc)
        End Sub

        ' グループのドラッグを開始します。
        Sub StartDragging(ByVal col As Column, ByVal rc As Rectangle)
            Dim g As C1FlexGrid = _owner.Grid
            _column = col

            ' 位置／可視性を初期化します。
            Size = New Size(rc.Width, rc.Height)
            Location = New Point(rc.X, rc.Y)
            Visible = True

            ' 切り取る四角形を計算します。
            _rcClip = _owner.ClientRectangle
            _rcClip.Height = g.Top + g.Rows(0).HeightDisplay

            ' マウス位置の追跡を続けます。
            _ptDown = Control.MousePosition
            _offset = PointToClient(_ptDown)
            _dragging = False

            ' MouseMove イベントを追いかけるためマウスをキャプチャします。
            Capture = True
        End Sub

        ' 利用可能なカスタムの描画ルーチンです。
        Sub PaintControl(ByVal g As Graphics, ByVal rc As Rectangle, ByVal text As String, ByVal dragging As Boolean)

            ' コントロールを描画します。
            UpdateObjects()
            If dragging Then
                g.FillRectangle(_brDrag, rc)
            Else
                g.FillRectangle(_brBack, rc)
            End If
            g.DrawString(text, Font, _brFore, ToRCF(rc), _sf)

            ' ボーダーを描画します。 
            ' メモ：透明な素材を用いての ControlPaint.DrawBorder3Dは適切ではありません。
            rc.Width = rc.Width - 1 : rc.Height = rc.Height - 1
            g.DrawLine(_pDark, rc.Left + 1, rc.Bottom, rc.Right, rc.Bottom)
            g.DrawLine(_pDark, rc.Right, rc.Bottom, rc.Right, rc.Top + 1)
            g.DrawLine(_pLite, rc.Left, rc.Bottom - 1, rc.Left, rc.Top)
            g.DrawLine(_pLite, rc.Left, rc.Top, rc.Right - 1, rc.Top)
        End Sub

        Function ToRCF(ByVal rc As Rectangle) As RectangleF
            Return New RectangleF(rc.X, rc.Y, rc.Width, rc.Height)
        End Function

    End Class
End Class
