''' <summary>
''' コードテーブルクラス
''' </summary>
''' <remarks></remarks>
Public Class DataTableEx
    Inherits DataTable

#Region "変数・定数"
    Public Const DtExFindErrMsg As String = "#code does not exist#"
#End Region

    ''' <summary>
    ''' コンストラクタ
    ''' </summary>
    ''' <remarks></remarks>
    Public Sub New(ByVal Optional valueType As String = "System.String")

        'CHECK: 列追加 VALUE列はバインドする場合は明示的にデータ型を指定
        Dim t As Type = Type.GetType(valueType, False, True)
        Columns.Add("VALUE", t)
        Columns.Add("DISP", GetType(String))
        Columns.Add("DEL_FLG", GetType(Boolean))
        Columns.Add("DEF_FLG", GetType(Boolean))

        '主キー設定
        Me.PrimaryKey = {Me.Columns("VALUE")}
    End Sub

    ''' <summary>
    ''' 削除済みを除外
    ''' </summary>
    ''' <returns></returns>
    Public Function ExcludeDeleted() As DataTable
        Dim dt As DataTable = Nothing
        If Me.Rows.Count > 0 Then
            Dim dr As DataRow() = Me.Select("DEL_FLG=0")
            If dr.Length > 0 Then
                dt = dr.CopyToDataTable
                Return dt
            Else
                'MessageBox.Show("対象データが存在しません")
                Return Nothing
            End If
        Else
            Return Me
        End If
    End Function

    ''' <summary>
    ''' レコード追加
    ''' </summary>
    ''' <param name="VALUE">値列</param>
    ''' <param name="strDISP">表示列</param>
    ''' <param name="opRow1">追加列1 配列で(列名,値,Type)</param>
    ''' <param name="opRow2">追加列2 配列で(列名,値,Type)</param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function Add(ByVal VALUE As Object, ByVal strDISP As String, Optional ByVal opRow1() As Object = Nothing, Optional ByVal opRow2() As Object = Nothing) As Integer
        Dim NewDataRow As DataRow = Me.NewRow()
        Try

            If opRow1 IsNot Nothing Then
                If Me.Columns.Contains(opRow1(0)) = False Then
                    Me.Columns.Add(opRow1(0), opRow1(2))
                End If

                NewDataRow(opRow1(0)) = opRow1(1)
            End If

            If opRow2 IsNot Nothing Then
                If Me.Columns.Contains(opRow2(0)) = False Then
                    Me.Columns.Add(opRow2(0), opRow2(2))
                End If

                NewDataRow(opRow2(0)) = opRow2(1)
            End If

            NewDataRow("VALUE") = VALUE
            NewDataRow("DISP") = strDISP

            'レコードデータを追加
            Me.Rows.Add(NewDataRow)

            'テーブル変更を確定
            Me.AcceptChanges()

            Return 0

        Catch exConstraint As ConstraintException
            '制約違反エラー
            Me.AcceptChanges()
            Return 0

        Catch ex As Exception
            EM.ErrorSyori(ex)

            'テーブル変更をロールバック
            Me.RejectChanges()

            Return -1
        End Try
    End Function

    ''' <summary>
    ''' ソースデータテーブルを、指定したフィルタ条件で抽出(＆ソート)したデータテーブルとして返す
    ''' </summary>
    ''' <param name="strFilter">抽出条件</param>
    ''' <param name="strSort">並べ替え条件(オプション)</param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function Filter(ByVal strFilter As String, Optional ByVal strSort As String = "", Optional ByVal blnNonMsg As Boolean = False) As DataTable
        Dim dtr() As DataRow
        Dim dtx As New DataTable

        Try

            ''返値用のテーブルにソースデータテーブルと同じ列を設定する
            'For Each column As DataColumn In srcTable.Columns
            '    dtx.Columns.Add(column.ColumnName.ToString, column.DataType)
            'Next column

            'ソーステーブルの構造を返値用のテーブルにコピーする
            dtx = Me.Clone


            'ソースデータテーブルにフィルタをかける
            If strSort.IsNullOrWhiteSpace = False Then
                dtr = Me.Select(strFilter, strSort)
            Else
                dtr = Me.Select(strFilter)

            End If

            '抽出結果が0件の場合、元のテーブルを返す
            If dtr.Length = 0 Then
                If blnNonMsg = False Then
                    MessageBox.Show("抽出結果が存在しませんでした。" & vbCrLf & "抽出前のデータを使用します。",
                                "データテーブル取得失敗", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    'CHECHK: フィルタ条件が不適切で、データテーブルの抽出結果が0件になってしまう場合、強制終了する？
                    '抽出前のテーブルを使用することも可能だが、本来ありえない組合せのデータができてしまう

                    '強制終了
                    'Environment.Exit(0)
                End If

                Return Nothing
            End If

            '返値用のテーブルに抽出したレコード<DataRow()>をコピーする
            dtx = dtr.CopyToDataTable

            Return dtx

        Catch ex As Exception
            EM.ErrorSyori(ex, False, conblnNonMsg)
            Return Nothing
        End Try
    End Function

    ''' <summary>
    ''' グループ化
    ''' </summary>
    ''' <param name="strPrimary">一意とすべき列名を指定</param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function Orderby(ByVal strPrimary() As String) As DataTable
        Dim dv As DataView
        Dim dt As DataTable
        Try
            dv = New DataView(Me)
            dt = dv.ToTable(True, strPrimary)

            Return dt
        Catch ex As Exception
            EM.ErrorSyori(ex)
            Return Me
        End Try
    End Function

    ''' <summary>
    ''' 任意のフィールドのキーを用いて、レコード上の別のフィールドを取得します
    ''' </summary>
    ''' <param name="Key">検索するキー</param>
    ''' <param name="Member">取得するフィールド名を指定する 既定:"DISP" メンバー</param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Overloads Function Find(ByVal Key As String, Optional ByVal Member As String = "DISP") As String
        Try
            If Key.IsNullOrWhiteSpace Then
            Else
                If Me.Rows.Find(Key) IsNot Nothing Then
                    Return Me.Rows.Find(Key).Item(Member).ToString.TrimEnd
                Else
                    Return DtExFindErrMsg
                End If
            End If

            Return ""
        Catch ex As Exception
            EM.ErrorSyori(ex)
            Return ""
        End Try
    End Function

    ''' <summary>
    ''' 任意のフィールドのキー(連結主キーの場合)を用いて、レコード上の別のフィールドを取得します
    ''' </summary>
    ''' <param name="Key">検索するキー配列</param>
    ''' <param name="Member">取得するフィールド名を指定する 既定:"DISP" メンバー</param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Overloads Function Find(ByVal Key() As String, Optional ByVal Member As String = "DISP") As String
        Try
            If Key IsNot Nothing AndAlso Key.GetLength(0) > 0 Then
                If Me.Rows.Find(Key) IsNot Nothing Then
                    Return Me.Rows.Find(Key).Item(Member).ToString.TrimEnd
                Else
                    Return DtExFindErrMsg
                End If
            End If

            Return ""
        Catch ex As Exception
            EM.ErrorSyori(ex)
            Return ""
        End Try
    End Function
End Class