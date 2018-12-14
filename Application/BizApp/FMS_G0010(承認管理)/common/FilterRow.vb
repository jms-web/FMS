' ------------------------------------------------------------------------
' FilterRow.vb
' 
' C1FlexGrid コントロールのフィルター行として操作するクラスをインプリメントします。
' （これはC1FlexGroupコントロールとしても使用されます。） 
' 
' このクラスを使用するため、FlexGridをDataTableまたはDataViewオブジェクトへバインドします。 
' 次に、コンストラクタにパラメータを渡すFilterRowオブジェクトを作成します。 
' 例：constructor. For example:
' 
' OleDbDataAdapter da = new OleDbDataAdapter(rs, conn);
' DataTable dt = new DataTable();
' da.Fill(dt);
' _flex.DataSource = dt;
' FilterRow fr = new FilterRow(_flex);
' 
' いったんFilterRowが作成されると：
' 
' 1 - 新規固定行がグリッドに追加されます。これはフィルター行となります。
'
' 2 - フィルター行の選択セルにマウスおよびキーボードイベントをトラップします。
'     ユーザーはセルのクリック、F3の押下、最上部の行の移動、または上矢印の押下
'     によって、フィルタを選択できます。
'     また、フィルター行上で最初の固定列をクリック、または削除キーを押すことで、
'     フィルターを削除できます。
'      
' 3 - RowColChangeイベントをトラップして、フィルター表現を更新し、グリッドのデータソースに
'     適用できます。フィルター表現には以下のようなものが含まれます。
'     a) 単純な値（例えば"Smith"）。
' 		  これらは"like 'Smith*'"のようなフィルター表現に変換されます。
' 		  フィルター行に "s"と入力した場合、グリッドには"s"で始まるエントリのみが表示されます。
'     b) 論理的な表現（例えば"> a"、 "= US"など）。
' 		  これらは  "> 'a'" や "= 'US'" のようなフィルター表現に変換されます。
' 		  フィルター行に ">=12" と入力した場合、グリッドには12かそれ以上の値を含むエントリ
'         のみが表示されます。
' ------------------------------------------------------------------------

Imports System
Imports System.Text
Imports System.Data
Imports C1.Win.C1FlexGrid

Public Class FilterRow

    Dim _flex As C1FlexGrid
    Dim _style As CellStyle
    Dim _row As Integer = -1            ' index of filter row (-1 if none)
    Dim _col As Integer = -1   ' index of filter row cell being edited (-1 if none)

    ' ** ctor
    Public Sub New(ByVal flex As C1FlexGrid)

        ' 参照をグリッドに保存します。
        _flex = flex

        ' フィルター列を追加します。
        _row = _flex.Rows.Fixed
        _flex.Rows.Fixed = _flex.Rows.Fixed + 1

        ' フィルター行のスタイルをカスタマイズします。
        _style = _flex.Styles.Add("Filter", _flex.Styles.Frozen)
        _style.BackColor = SystemColors.Info
        _style.ForeColor = SystemColors.InfoText
        _style.Border.Direction = BorderDirEnum.Horizontal
        _flex.Rows(_row).Style = _style

        ' イベントハンドラを追加します。
        AddHandler _flex.KeyDown, New KeyEventHandler(AddressOf _flex_KeyDown)
        AddHandler _flex.BeforeMouseDown, New BeforeMouseDownEventHandler(AddressOf _flex_BeforeMouseDown)
        AddHandler _flex.RowColChange, New EventHandler(AddressOf _flex_RowColChange)
        AddHandler _flex.AfterEdit, New RowColEventHandler(AddressOf _flex_AfterEdit)

        '  行をフィルタリングするために、カーソルを移動します。
        _flex.Select(_row, _flex.Cols.Fixed)
    End Sub

    ' ** イベントハンドラ

    ' フィルターを選択しクリアするためのカスタム ロジック
    Private Sub _flex_KeyDown(ByVal sender As Object, ByVal e As KeyEventArgs)

        ' スクロール可能な行上で、F3をクリックまたは上矢印を押した場合
        If (e.KeyCode = Keys.F3 OrElse (e.KeyCode = Keys.Up AndAlso _flex.Row = _row + 1)) Then

            ' フィルターセルを選択し、編集を開始します。
            _flex.Select(_row, _flex.Col)
            e.Handled = True
        End If

        ' フィルター行を選択してDelキーを押した場合
        If (e.KeyCode = Keys.Delete AndAlso _flex.Row = _row) Then
            Dim col As Integer
            For col = _flex.Cols.Fixed To _flex.Cols.Count - 1
                _flex(_row, col) = Nothing
            Next
            UpdateFilter()
            e.Handled = True
        End If

    End Sub

    ' フィルター行の特殊なマウス操作
    Private Sub _flex_BeforeMouseDown(ByVal sender As Object, ByVal e As BeforeMouseDownEventArgs)

        ' フィルター行上でのクリックを禁止します。
        If ((e.Button And MouseButtons.Left) <> 0 AndAlso _row > 0 AndAlso _flex.MouseRow = _row) Then

            ' クリックされた列数を取得します。
            Dim col As Integer = _flex.MouseCol

            ' 固定行なら、フィルタ行全体を選択します。
            If (col < _flex.Cols.Fixed) Then
                _flex.Select(_row, _flex.Cols.Fixed, _row, _flex.Cols.Count - 1)
                _flex.FinishEditing(True)
            Else ' フィルター行上でセルをクリックし、選択します。
                _flex.Select(_row, col)
            End If

            ' イベントをキャンセルします（ソート、サイズ変更など）。
            e.Cancel = True
        End If
    End Sub

    ' フィルター行を編集モードのままにします。
    Private Sub _flex_RowColChange(ByVal sender As Object, ByVal e As EventArgs)

        ' カーソルの変更に注目します。
        If (_row > -1 AndAlso (_flex.Row <> _row OrElse _flex.Col <> _col)) Then

            ' 新規セルがフィルター内にあれば、編集を開始します。
            _col = -1
            If (_flex.Row = _row) Then
                _col = _flex.Col
                _flex.StartEditing()
            End If
        End If
    End Sub

    ' フィルター行の編集後、フィルタを更新します。
    Private Sub _flex_AfterEdit(ByVal sender As Object, ByVal e As RowColEventArgs)
        If (e.Row = _row) Then
            UpdateFilter()
        End If
    End Sub

    ' ** オブジェクトモデル
    Public Property Visible() As Boolean
        Get
            Return _flex.Rows(_row).Visible
        End Get
        Set(ByVal Value As Boolean)
            _flex.Rows(_row).Visible = Value
        End Set
    End Property

    Public Sub Clear()
        Dim col As Integer
        For col = 0 To _flex.Cols.Count - 1
            _flex(_row, col) = Nothing
        Next
        UpdateFilter()
    End Sub

    ' ** イベントハンドラ

    ' ** ユーティリティ

    ' フィルターの更新（フィルター行の編集後に呼び出し）
    Private Sub UpdateFilter()

        ' フィルター行が存在するかどうか確認します。
        If _row < 0 Then Return

        ' データビューがあるかどうか確認します。
        Dim dv As DataView = Nothing
        If TypeOf _flex.DataSource Is DataView Then
            dv = _flex.DataSource
        End If
        If TypeOf _flex.DataSource Is DataTable Then
            Dim dt As DataTable = _flex.DataSource
            dv = dt.DefaultView
        End If
        If dv Is Nothing Then
            Debug.WriteLine("DataSource should be a DataTable or DataView.")
            Return
        End If

        ' フィルター行中の各セルをスキャンし、新規フィルターを作成します。
        Dim sb As New StringBuilder()
        Dim col As Integer
        For col = _flex.Cols.Fixed To _flex.Cols.Count - 1

            ' 列に対する値を取得します。
            Dim expr As String = _flex.GetDataDisplay(_row, col).TrimEnd()
            If expr.Length > 0 Then

                ' フィルターの表現を取得します。
                expr = BuildFilterExpression(col, expr)
                If expr.Length > 0 Then

                    ' 新しい条件を連結します。
                    If (sb.Length > 0) Then sb.Append(" And ")
                    sb.AppendFormat("[{0}]{1}", _flex.Cols(col).Name, expr)
                End If
            End If
        Next

        ' 現在のビューにフィルタを適用します。
        Dim strFilter As String = sb.ToString()
        If strFilter = dv.RowFilter Then Return
        Try
            _flex(_row, 0) = Nothing
            dv.RowFilter = strFilter
        Catch
            _flex(_row, 0) = "Err"
            Debug.WriteLine("Bad filter expression.")
        End Try

        ' フィルター行を保持します。
        _flex.Row = _row
    End Sub


    ' データテーブルに適用するためのフィルタ－表現の生成
    '
    ' フィルター行への入力値を、フィルター表現に変更します。 
    ' 例：
    '
    ' テキスト	フィルタ－表現
    ' -------  -----------------
    ' smith    like 'smith*'
    ' > s      > 's'
    '
    Private Function BuildFilterExpression(ByVal col As Integer, ByVal expr As String) As String

        ' 認識可能な操作
        Dim oper As String = "<>="

        ' 操作がない場合、文字列には'like'を、それ以外のデータタイプには'='を用います。 
        If (oper.IndexOf(Left(expr, 1)) < 0) Then
            If _flex.Cols(col).DataType Is GetType(String) Then
                Return String.Format(" like '{0}*'", expr)
            Else
                Return String.Format(" = '{0}'", expr)
            End If
        End If

        ' 操作の終わりを探します。
        Dim index As Integer
        For index = 0 To expr.Length - 1
            If (oper.IndexOf(Mid(expr, index + 1, 1)) < 0) Then
                Dim retval As String = expr.Substring(0, index) + " "
                retval = retval + String.Format("'{0}'", expr.Substring(index).Trim())
                Return retval
            End If
        Next

        ' ここに到達した場合は、条件が正しくありません（つまり、><です）。
        Debug.WriteLine("フィルター表現を構築できません。")
        Return ""
    End Function

End Class
