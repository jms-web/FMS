Imports System.Collections.Generic
Imports System.ComponentModel
Imports System.ComponentModel.DataAnnotations


Public NotInheritable Class ClsPubMethod

#Region "WinAPI"

    <Runtime.InteropServices.DllImport("user32.dll")>
    Public Shared Function SetForegroundWindow(hWnd As IntPtr) As <Runtime.InteropServices.MarshalAs(Runtime.InteropServices.UnmanagedType.Bool)> Boolean
    End Function

#End Region

#Region "定数・変数"

#Region "列挙値"

    'プログラム実行モード
    Public Enum ENM_EXECMODE
        _0_Sync = 0
        _1_Async = 1
    End Enum

    'プログラムステータスバーステータス
    Public Enum ENM_PG_STATUS
        ''' <summary>
        ''' 非アクティブ(イベント未発生)
        ''' </summary>
        _1_INACTIVE = 1

        ''' <summary>
        ''' アクティブ(イベント未発生)
        ''' </summary>
        _2_ACTIVE = 2

        ''' <summary>
        ''' 処理中
        ''' </summary>
        _3_PROCESSING = 3

        ''' <summary>
        ''' モード切替
        ''' </summary>
        _4_ALTMODE = 4

        ''' <summary>
        ''' エラー
        ''' </summary>
        _9_ERROR = 9
    End Enum

    'ウィンドウ表示状態
    Public Enum ENM_WINDOWMODE
        _0_SW_HIDE = 0
        _1_SW_SHOWNORMAL = 1
        _2_SW_SHOWMINIMIZED = 2
        _3_SW_SHOWMAXIMIZED = 3
        _5_SW_SHOW = 5
        _9_RESTORE = 9
    End Enum


    'トランザクション状態
    Public Enum ENM_TRANSACTION_STATUS
        _0_ROLLBACK = 0
        _1_COMMIT = 1
    End Enum

    ''' <summary>
    ''' コンボボックス先頭行 選択値タイプ
    ''' </summary>
    Public Enum ENM_COMBO_SELECT_VALUE_TYPE
        ''' <summary>
        ''' 必須
        ''' </summary>
        _0_Required = 0
        ''' <summary>
        ''' すべて
        ''' </summary>
        _1_Filter = 1
        ''' <summary>
        ''' 未選択
        ''' </summary>
        _2_Option = 2
    End Enum


    <Flags>
    Public Enum EllipsisFormat
        ' Text Is Not modified.
        _0_None = 0
        ' Text Is trimmed at the end of the string. An ellipsis (...) 
        ' Is drawn in place of remaining text.
        _1_End = 1
        ' Text Is trimmed at the beginning of the string. 
        ' An ellipsis (...) Is drawn in place of remaining text. 
        _2_Start = 2
        ' Text Is trimmed in the middle of the string. 
        ' An ellipsis (...) Is drawn in place of remaining text.
        _3_Middle = 3
        ' Preserve as much as possible of the drive And filename information. 
        ' Must be combined with alignment information.
        _4_Path = 4
        ' Text Is trimmed at a word boundary. 
        ' Must be combined with alignment information.
        _8_Word = 8
    End Enum



#End Region

#End Region

#Region "ファイル／ディレクトリ関連"

#Region "　ルートパス取得"
    Public Shared Function FunGetRootPath() As String
        Dim strBUFF As String

#If DEBUG Then
        strBUFF = Application.StartupPath() & "\.."

#Else
        strBUFF = Application.StartupPath()

        If InStr(strBUFF, "\bin\Release", CompareMethod.Text) > 0 Then
            strBUFF = Application.StartupPath() & "\..\..\..\.."
        ElseIf InStr(strBUFF, "\bin\Debug", CompareMethod.Text) > 0 Then
            strBUFF = Application.StartupPath() & "\..\..\..\.."

        ElseIf InStr(strBUFF, "\bin\x86\Release", CompareMethod.Text) > 0 Then
            strBUFF = Application.StartupPath() & "\..\..\..\..\.."
        ElseIf InStr(strBUFF, "\bin\x86\Debug", CompareMethod.Text) > 0 Then
            strBUFF = Application.StartupPath() & "\..\..\..\..\.."

        ElseIf InStr(strBUFF, "\bin\x64\Release", CompareMethod.Text) > 0 Then
            strBUFF = Application.StartupPath() & "\..\..\..\..\.."
        ElseIf InStr(strBUFF, "\bin\x64\Debug", CompareMethod.Text) > 0 Then
            strBUFF = Application.StartupPath() & "\..\..\..\..\.."

        Else
            strBUFF = Application.StartupPath() & "\.."
        End If

#End If

        strBUFF = System.IO.Path.GetFullPath(strBUFF)
        Return strBUFF
    End Function
#End Region

#Region "パス"
    Public Shared Function FunGetEXEPath() As String
#If DEBUG Then
        Dim strEXE As String = "\EXE_DEBUG\"
#Else
            Dim strEXE As String =  "\EXE\"
#End If
        Return strEXE
    End Function
#End Region

#Region "　ファイル削除"
    Public Shared Function FunDELETE_FILE(ByVal stFilePath As String) As Boolean
        Dim strPath As String
        Try
            strPath = FunConvRootPath(stFilePath)
            Dim cFileInfo As New System.IO.FileInfo(strPath)

            ' ファイルが存在しているか判断する
            If cFileInfo.Exists Then
                ' 読み取り専用属性がある場合は、読み取り専用属性を解除する
                If (cFileInfo.Attributes And System.IO.FileAttributes.ReadOnly) = System.IO.FileAttributes.ReadOnly Then
                    cFileInfo.Attributes = System.IO.FileAttributes.Normal
                End If

                ' ファイルを削除する
                cFileInfo.Delete()
            End If

            Return True

        Catch exIO As System.IO.IOException
            MessageBox.Show("ファイルが開かれているため、削除することが出来ません。" & vbCrLf & "ファイルを閉じて下さい。" & vbCrLf & "対象ファイル：" & stFilePath, "ファイル削除", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Return False
        Catch ex As Exception
            Throw
            Return False
        End Try
    End Function
#End Region

#Region "　パス文字列変換"

    ''' <summary>
    ''' パス文字列の最後に\を付ける
    ''' </summary>
    ''' <param name="strPath"></param>
    Public Shared Sub SubConvPathString(ByRef strPath As String)
        Try
            If strPath.IsNullOrWhiteSpace Then
            Else
                If strPath.LastIndexOf("\") <> strPath.Length - 1 Then
                    'パスの最後に\を付ける
                    strPath &= "\"
                End If
            End If

        Catch ex As Exception
            EM.ErrorSyori(ex, False, True)
        End Try
    End Sub

    ''' <summary>
    ''' パス文字列の最後に\を付ける
    ''' </summary>
    ''' <param name="strPath"></param>
    Public Shared Function FunConvPathString(ByVal strPath As String) As String
        Dim strBUFF As String
        Try

            If strPath.IsNullOrWhiteSpace = False Then
                If strPath.LastIndexOf("\") <> strPath.Length - 1 Then
                    'パスの最後に\を付ける
                    strBUFF = strPath & "\"
                Else
                    strBUFF = strPath
                End If
                Return strBUFF
            Else
                Return vbNullString
            End If

        Catch ex As Exception
            EM.ErrorSyori(ex, False, True)
            Return vbNullString
        End Try
    End Function

    'Link https://www.codeproject.com/Articles/37503/Auto-Ellipsis
    Public Const EllipsisChars As String = "..."
    Public Shared Function CompactString(ByVal text As String, ByVal ctrl As Control, ByVal options As EllipsisFormat) As String
        Using dc As Graphics = ctrl.CreateGraphics()
            Dim s As Size = TextRenderer.MeasureText(dc, text, ctrl.Font)

            ' control Is large enough to display the whole text 
            If (s.Width <= ctrl.Width) Then
                Return text
            End If

            Dim pre As String = ""
            Dim Mid As String = text
            Dim post As String = ""

            Dim isPath As Boolean = (EllipsisFormat._4_Path & options) <> 0

            ' split path string into <drive><directory><filename> 
            If (isPath) Then
                pre = IO.Path.GetPathRoot(text)
                Mid = IO.Path.GetDirectoryName(text).Substring(pre.Length)
                post = IO.Path.GetFileName(text)
            End If

            Dim Len As Integer = 0
            Dim seg As Integer = Mid.Length
            Dim fit As String = ""

            ' find the longest string that fits into
            ' the control boundaries using bisection method
            While (seg > 1)
                seg -= seg / 2

                Dim Left As Integer = Len + seg
                Dim Right As Integer = Mid.Length

                If (Left > Right) Then
                    Continue While
                End If

                If ((EllipsisFormat._3_Middle & options) = EllipsisFormat._3_Middle) Then
                    Right -= Left / 2
                    Left -= Left / 2
                ElseIf ((EllipsisFormat._2_Start & options) <> 0) Then
                    Right -= Left
                    Left = 0
                End If


                ' build And measure a candidate string with ellipsis
                Dim tst As String = Mid.Substring(0, Left) + EllipsisChars + Mid.Substring(Right)

                ' restore path with <drive> And <filename>
                If (isPath) Then
                    tst = IO.Path.Combine(IO.Path.Combine(pre, tst), post)
                End If
                s = TextRenderer.MeasureText(dc, tst, ctrl.Font)

                ' candidate string fits into control boundaries, 
                ' try a longer string 
                ' stop when seg <= 1 
                If (s.Width <= ctrl.Width) Then
                    Len += seg
                    fit = tst
                End If
            End While

            If Len = 0 Then ' String Then can't fit into control
                ' "path" mode Is off, just return ellipsis characters
                If isPath Then
                Else
                    Return EllipsisChars
                End If

                ' <drive> And <directory> are empty, return <filename>
                If (pre.Length = 0 And Mid.Length = 0) Then
                    Return post
                End If

                ' measure "C:\...\filename.ext"
                fit = IO.Path.Combine(IO.Path.Combine(pre, EllipsisChars), post)

                s = TextRenderer.MeasureText(dc, fit, ctrl.Font)

                ' if still Not fit then return "...\filename.ext"
                If (s.Width > ctrl.Width) Then
                    fit = IO.Path.Combine(EllipsisChars, post)
                End If
            End If

            Return fit
        End Using
    End Function

#End Region

#Region "フォルダ存在チェック＆作成"
    Public Shared Function FunCreateDirectory(ByRef strPath As String) As Boolean

        Try

            If System.IO.Path.IsPathRooted(strPath) = False Then
                '相対パスの場合は絶対パスに変換
                strPath = System.IO.Path.GetFullPath(strPath)
            End If

            If System.IO.Directory.Exists(strPath) = False Then
                'フォルダ作成
                System.IO.Directory.CreateDirectory(strPath)
            End If

            Return True
        Catch ex As Exception
            EM.ErrorSyori(ex, False, conblnNonMsg)
            Return False
        End Try
    End Function

#End Region

#Region "相対パス絶対パス変換"
    Public Shared Function FunConvRootPath(ByVal strPath As String) As String
        Try
            If System.IO.Path.IsPathRooted(strPath) = False Then
                Return System.IO.Path.GetFullPath(strPath)
            Else
                Return strPath
            End If

        Catch ex As Exception
            EM.ErrorSyori(ex, False, conblnNonMsg)
            Return vbNullString
        End Try
    End Function
#End Region

#End Region

#Region "フォーム関連"

#Region "　画面サイズ"

    Public Shared Sub SetButtonSize(FormWidth As Integer, cmdFunc() As Button)
        Dim lngIti As Integer
        Dim lngLp1 As Integer
        If IsNothing(cmdFunc(0)) = True Then Exit Sub
        '===================================
        '   コマンドボタンの位置設定
        '===================================
        lngIti = CInt(FormWidth / 6 - 10)
        For lngLp1 = 1 To 12
            cmdFunc(lngLp1 - 1).Left = (lngIti * lngLp1) - lngIti + 20
            cmdFunc(lngLp1 - 1).Width = CInt(FormWidth * 0.152)

            If lngLp1 > 6 Then
                cmdFunc(lngLp1 - 1).Left = ((lngIti * lngLp1) - lngIti + 20) - (lngIti * 6)
            End If
        Next

    End Sub


#End Region

#End Region

#Region "コントロール関連"
    ''' <summary>
    ''' コントロールのDoubleBufferedプロパティをTrueにする
    ''' </summary>
    ''' <param name="control">対象のコントロール</param>
    Public Shared Sub EnableDoubleBuffering(control As Control)
        control.GetType().InvokeMember("DoubleBuffered", System.Reflection.BindingFlags.NonPublic Or
                                                        System.Reflection.BindingFlags.Instance Or
                                                        System.Reflection.BindingFlags.SetProperty,
                                                        Nothing,
                                                        control,
                                                        New Object() {True})


        'control.SetStyle(ControlStyles.ResizeRedraw, True)
        'control.SetStyle(ControlStyles.DoubleBuffer, True)
        'control.SetStyle(ControlStyles.UserPaint, True)
        'control.SetStyle(ControlStyles.AllPaintingInWmPaint, True)

        'Dim myPropertyInfo As System.Reflection.PropertyInfo
        'myPropertyInfo = GetType(Control).GetProperty("DoubleBuffered", System.Reflection.BindingFlags.Instance Or
        '                                                                     System.Reflection.BindingFlags.NonPublic)
    End Sub

#End Region

#Region "データソース関連"

#Region "　コードマスタ設定値取得"
    Public Shared Function FunGetCodeMastaValue(ByVal DB As ClsDbUtility, ByVal strKOM As String, ByVal strVALUE As String) As String
        Dim strBUFF As String = ""
        Dim tbl As New DataTableEx

        Try
            Call FunGetCodeDataTable(DB, strKOM, tbl, "RTRIM(ITEM_VALUE)='" & strVALUE & "' ")
            If tbl.Rows.Count > 0 Then
                strBUFF = tbl.Rows(0).Item("DISP").ToString.Trim
            Else
                strBUFF = ""
            End If

            Return strBUFF

        Catch ex As Exception
            EM.ErrorSyori(ex, False, conblnNonMsg)
            Return ""
        Finally
            tbl.Dispose()
        End Try
    End Function

    Public Shared Function FunGetCodeMastaValues(ByVal DB As ClsDbUtility, ByVal strKOM As String) As List(Of String)
        Dim strBUFF As String = ""
        Dim tbl As New DataTableEx
        Dim list As New List(Of String)

        Try
            Call FunGetCodeDataTable(DB, strKOM, tbl)
            For Each row As DataRow In tbl.Rows
                list.Add(row.Item("ITEM_VALUE").ToString.Trim)
            Next

            Return list

        Catch ex As Exception
            EM.ErrorSyori(ex, False, conblnNonMsg)
            Return Nothing
        End Try
    End Function

    ''' <summary>
    ''' コードマスタの設定値を更新
    ''' </summary>
    ''' <param name="DB">DB接続</param>
    ''' <param name="strKOM">項目名</param>
    ''' <param name="strVALUE">値</param>
    ''' <param name="strDISP">セットする表示値</param>
    ''' <returns></returns>
    Public Shared Function FunSetCodeMastaValue(ByVal DB As ClsDbUtility, ByVal strKOM As String, ByVal strVALUE As String, ByVal strDISP As String) As Boolean
        Dim sbSQL As New System.Text.StringBuilder
        Dim intRET As Integer
        Try
            'UPDATE
            sbSQL.Remove(0, sbSQL.Length)
            sbSQL.Append("UPDATE " & "M001_SETTING" & " SET ")
            sbSQL.Append(" DISP ='" & strDISP & "'")
            sbSQL.Append(" WHERE ITEM_NAME='" & strKOM & "' ")
            sbSQL.Append(" AND RTRIM(ITEM_VALUE)='" & strVALUE & "' ")

            intRET = DB.ExecuteNonQuery(sbSQL.ToString, True)
            If intRET = 0 Then
                'INSERT
                sbSQL.Append("UPDATE " & "M001_SETTING" & " SET")
                sbSQL.Append(" DISP ='" & strDISP & "'")
                sbSQL.Append(" ,UPD_YMDHNS = dbo.GetSysDateString()")
                sbSQL.Append(" WHERE ITEM_NAME='" & strKOM & "' ")
                sbSQL.Append(" AND RTRIM(ITEM_VALUE)='" & strVALUE & "' ")

                'SQL実行
                intRET = DB.ExecuteNonQuery(sbSQL.ToString, True)
                If intRET = 0 Then
                    'エラー
                    Return False
                Else
                    Return True
                End If
            Else
                '
                Return True
            End If

        Catch ex As Exception
            EM.ErrorSyori(ex, False, conblnNonMsg)
            Return False
        End Try
    End Function

#End Region

#Region "　コンボボックス データソース設定"
    ''' <summary>
    ''' コンボボックスのデータソースを設定 DatatableEx
    ''' </summary>
    ''' <param name="cmbCtrl">対象コンボボックス</param>
    ''' <param name="srcTable">データソースとなるデータテーブル</param>
    ''' <param name="TopRowNull">先頭に項目未選択用のブランク行を挿入するか(既定:挿入しない)</param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    <Obsolete("ComboboxExのメソッド版を利用して下さい comboBox1.SetDatasource(dt as DataTableEx)")>
    Public Shared Function FunSetComboboxSrc(ByVal cmbCtrl As ComboBox, ByVal srcTable As DataTableEx, Optional ByVal TopRowNull As Boolean = False, Optional drowMode As DrawMode = DrawMode.OwnerDrawFixed) As Boolean

        Try
            '-----オーナードロー設定
            cmbCtrl.DrawMode = drowMode
            If drowMode <> DrawMode.Normal Then
                'cmbCtrl.DropDownStyle = ComboBoxStyle.DropDown
                cmbCtrl.MaxDropDownItems = 15
                cmbCtrl.ItemHeight = cmbCtrl.Font.Size + 8
                cmbCtrl.IntegralHeight = False
                AddHandler cmbCtrl.DrawItem, AddressOf Combobox_DrawItem
            End If

            '-----コンボボックス表示値と選択値の列設定
            cmbCtrl.DisplayMember = "DISP"
            cmbCtrl.ValueMember = "VALUE"

            If TopRowNull = True Then
                '----先頭に空白行を追加する場合
                Dim dtx As New DataTableEx()
                Dim NulRow As DataRow = dtx.NewRow()

                ''ソーステーブルの構造をコンボボックス用テーブルにコピーする
                'dtx = srcTable.Clone

                'データソースの列名を取得し、先頭空白行のみのDatatableを作成
                For Each column As DataColumn In srcTable.Columns
                    If dtx.Columns.Contains(column.ColumnName.ToString) = False Then
                        dtx.Columns.Add(column.ColumnName.ToString, column.DataType)
                    End If
                    Select Case True
                        Case column.DataType Is GetType(String)
                            NulRow(column.ColumnName.ToString) = ""
                        Case column.DataType Is GetType(Integer), column.DataType Is GetType(Decimal), column.DataType Is GetType(Double)
                            NulRow(column.ColumnName.ToString) = 0
                        Case Else
                            NulRow(column.ColumnName.ToString) = DBNull.Value
                    End Select
                Next column
                dtx.Rows.Add(NulRow)

                '空白行のみのデータテーブルとデータソースのデータテーブルを結合
                dtx.Merge(srcTable)

                'データソースを設定する前にコンボボックスのSelectedIndexChangedイベントが発生しないように一時的にイベントハンドラを外す

                'コンボボックスのデータソースを設定
                cmbCtrl.DataSource = dtx
                'イベントハンドラを戻す


            Else
                '----先頭に空白行を追加しない場合

                'コンボボックスのデータソースを設定
                cmbCtrl.DataSource = srcTable
            End If


            ''オートコンプリート設定       , Optional ByVal AutoComplete As Boolean = False
            'If AutoComplete = True Then
            '    cmbCtrl.AutoCompleteMode = AutoCompleteMode.SuggestAppend
            '    cmbCtrl.AutoCompleteSource = AutoCompleteSource.ListItems
            'End If

            Return True
        Catch ex As Exception
            EM.ErrorSyori(ex, False, conblnNonMsg)
            Return False
        End Try
    End Function

    ''' <summary>
    ''' コンボボックスのデータソースを設定 Datatable
    ''' </summary>
    ''' <param name="cmbCtrl">対象コンボボックス</param>
    ''' <param name="srcTable">データソースとなるデータテーブル</param>
    ''' <param name="TopRowNull">先頭に項目未選択用のブランク行を挿入するか(既定:挿入しない)</param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    <Obsolete("ComboboxExのメソッド版を利用して下さい comboBox1.SetDatasource(dt as DataTableEx)")>
    Public Shared Function FunSetComboboxSrc(ByVal cmbCtrl As ComboBox, ByVal srcTable As DataTable, Optional ByVal TopRowNull As Boolean = False, Optional drowMode As DrawMode = DrawMode.OwnerDrawFixed) As Boolean


        Try

            '-----オーナードロー設定
            cmbCtrl.DrawMode = drowMode
            If drowMode <> DrawMode.Normal Then
                'cmbCtrl.DropDownStyle = ComboBoxStyle.DropDown
                cmbCtrl.MaxDropDownItems = 15
                cmbCtrl.ItemHeight = cmbCtrl.Font.Size + 8
                cmbCtrl.IntegralHeight = False
                AddHandler cmbCtrl.DrawItem, AddressOf Combobox_DrawItem
            End If

            '-----コンボボックス表示値と選択値の列設定
            cmbCtrl.DisplayMember = "DISP"
            cmbCtrl.ValueMember = "VALUE"


            If TopRowNull = True Then
                Dim dt As New DataTable()
                Dim NulRow As DataRow = dt.NewRow()

                'データソースの列名を取得し、先頭空白行のみのDatatableを作成
                For Each column As DataColumn In srcTable.Columns
                    If dt.Columns.Contains(column.ColumnName.ToString) = False Then
                        dt.Columns.Add(column.ColumnName.ToString, column.DataType)
                    End If
                    Select Case True
                        Case column.DataType Is GetType(String)
                            NulRow(column.ColumnName.ToString) = ""
                        Case column.DataType Is GetType(Integer), column.DataType Is GetType(Decimal), column.DataType Is GetType(Double)
                            NulRow(column.ColumnName.ToString) = 0
                        Case Else
                            NulRow(column.ColumnName.ToString) = DBNull.Value
                    End Select
                Next column
                dt.Rows.Add(NulRow)

                '空白行のみのデータテーブルとデータソースのデータテーブルを結合
                dt.Merge(srcTable)

                'コンボボックスのデータソースを設定
                cmbCtrl.DataSource = dt
            Else
                'コンボボックスのデータソースを設定
                cmbCtrl.DataSource = srcTable
            End If


            ''オートコンプリート設定       , Optional ByVal AutoComplete As Boolean = False
            'If AutoComplete = True Then
            '    cmbCtrl.AutoCompleteMode = AutoCompleteMode.SuggestAppend
            '    cmbCtrl.AutoCompleteSource = AutoCompleteSource.ListItems
            'End If

            Return True
        Catch ex As Exception
            EM.ErrorSyori(ex, False, conblnNonMsg)
            Return False
        End Try
    End Function

    Public Shared Function FunSetMultiColumnComboboxSrc(ByRef cmbCtrl As MultiColumnCombobox, ByVal srcTable As DataTableEx, Optional ByVal TopRowNull As Boolean = False, Optional drowMode As DrawMode = DrawMode.OwnerDrawFixed) As Boolean

        Try
            '-----オーナードロー設定
            cmbCtrl.DrawMode = drowMode
            If drowMode <> DrawMode.Normal Then
                'cmbCtrl.DropDownStyle = ComboBoxStyle.DropDown
                cmbCtrl.MaxDropDownItems = 15
                cmbCtrl.ItemHeight = cmbCtrl.Font.Size + 8
                cmbCtrl.IntegralHeight = False
                AddHandler cmbCtrl.DrawItem, AddressOf Combobox_DrawItem
            End If

            '-----コンボボックス表示値と選択値の列設定
            cmbCtrl.DisplayMember = "DISP"
            cmbCtrl.ValueMember = "VALUE"

            If TopRowNull = True Then
                '----先頭に空白行を追加する場合
                Dim dtx As New DataTableEx()
                Dim NulRow As DataRow = dtx.NewRow()

                ''ソーステーブルの構造をコンボボックス用テーブルにコピーする
                'dtx = srcTable.Clone

                'データソースの列名を取得し、先頭空白行のみのDatatableを作成
                For Each column As DataColumn In srcTable.Columns
                    If dtx.Columns.Contains(column.ColumnName.ToString) = False Then
                        dtx.Columns.Add(column.ColumnName.ToString, column.DataType)
                    End If
                    Select Case True
                        Case column.DataType Is GetType(String)
                            NulRow(column.ColumnName.ToString) = ""
                        Case column.DataType Is GetType(Integer), column.DataType Is GetType(Decimal), column.DataType Is GetType(Double)
                            NulRow(column.ColumnName.ToString) = 0
                        Case Else
                            NulRow(column.ColumnName.ToString) = DBNull.Value
                    End Select
                Next column
                dtx.Rows.Add(NulRow)

                '空白行のみのデータテーブルとデータソースのデータテーブルを結合
                dtx.Merge(srcTable)

                'データソースを設定する前にコンボボックスのSelectedIndexChangedイベントが発生しないように一時的にイベントハンドラを外す

                'コンボボックスのデータソースを設定
                cmbCtrl.DataSource = dtx
                'イベントハンドラを戻す


            Else
                '----先頭に空白行を追加しない場合

                'コンボボックスのデータソースを設定
                cmbCtrl.DataSource = srcTable
            End If


            ''オートコンプリート設定       , Optional ByVal AutoComplete As Boolean = False
            'If AutoComplete = True Then
            '    cmbCtrl.AutoCompleteMode = AutoCompleteMode.SuggestAppend
            '    cmbCtrl.AutoCompleteSource = AutoCompleteSource.ListItems
            'End If

            Return True
        Catch ex As Exception
            EM.ErrorSyori(ex, False, conblnNonMsg)
            Return False
        End Try
    End Function

    ''' <summary>
    ''' コンボボックス項目描画時イベント
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
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

    ''' <summary>
    ''' DataGridViewのコンボボックス列のデータソースを設定
    ''' </summary>
    ''' <param name="cmbColumn">対象コンボボックス列</param>
    ''' <param name="srcTable">データソースとなるデータテーブル</param>
    ''' <param name="strName">列名</param>
    ''' <param name="strHeaderText">列ヘッダ表示名</param>
    ''' <param name="TopRowNull">先頭に項目未選択用のブランク行を挿入するか(既定:挿入しない)</param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Shared Function FunSetComboboxColumnSrc(ByRef cmbColumn As DataGridViewComboBoxColumn, ByVal srcTable As DataTableEx,
                                             ByVal strName As String, ByVal strHeaderText As String, Optional ByVal TopRowNull As Boolean = False) As Integer
        Try
            If TopRowNull = True Then
                Dim dtx As New DataTableEx()
                Dim NulRow As DataRow = dtx.NewRow()

                'データソースの列名を取得し、先頭空白行のみのDatatableを作成
                For Each column As DataColumn In srcTable.Columns
                    dtx.Columns.Add(column.ColumnName.ToString, column.DataType)
                    NulRow(column.ColumnName.ToString) = ""
                Next column
                dtx.Rows.Add(NulRow)

                '空白行のみのデータテーブルとデータソースのデータテーブルを結合
                dtx.Merge(srcTable)
                'コンボボックスのデータソースを設定
                cmbColumn.DataSource = dtx
            Else
                'コンボボックスのデータソースを設定
                cmbColumn.DataSource = srcTable
            End If

            'コンボボックス列表示値と選択値の列設定
            cmbColumn.Name = strName
            cmbColumn.HeaderText = strHeaderText
            'コンボボックス表示値と選択値の列設定
            cmbColumn.DisplayMember = "DISP"
            cmbColumn.ValueMember = "VALUE"

            cmbColumn.DisplayStyleForCurrentCellOnly = True
            cmbColumn.DisplayStyle = DataGridViewComboBoxDisplayStyle.Nothing
            Return 0
        Catch ex As Exception
            EM.ErrorSyori(ex, False, conblnNonMsg)
            Return -1
        End Try
    End Function

    ''' <summary>
    ''' コンボボックス規定値設定(コードマスタのみ)
    ''' </summary>
    ''' <param name="cmbCtrl"></param>
    ''' <returns></returns>
    <Obsolete("ComboboxExの拡張メソッド版を利用して下さい comboBox1.SetDefaultValue()")>
    Public Shared Function FunSetComboboxDefaultValue(ByVal cmbCtrl As ComboBox) As Boolean
        Dim strDefaultValue As String

        Try

            'コンボボックスのデータソース取得
            Dim dt As DataTable = DirectCast(cmbCtrl.DataSource, DataTable)
            Dim dtRows As DataRow() = dt.Select("DEF_FLG")

            If dtRows.Length > 0 Then
                strDefaultValue = dtRows(0).Item("VALUE")
            Else
                strDefaultValue = ""
            End If

            cmbCtrl.SelectedValue = strDefaultValue
        Catch ex As Exception
            EM.ErrorSyori(ex, False, conblnNonMsg)
        End Try
    End Function


    ''' <summary>
    ''' 選択された項目が削除済み(非表示)の場合データソースに追加
    ''' </summary>
    ''' <param name="cmbCtrl"></param>
    ''' <param name="originalDatasourse"></param>
    ''' <param name="value"></param>
    ''' <returns></returns>
    Public Shared Function FunSetComboboxValue(ByRef cmbCtrl As ComboBox, ByVal originalDatasourse As DataTable, ByVal value As Object) As Boolean

        Try
            Dim dt As DataTable = DirectCast(cmbCtrl.DataSource, DataTable)
            Dim dtRow As DataRow() = dt.Select("VALUE='" & value & "'")

            If dtRow.Length = 0 Then
                '選択項目が削除済みの場合、オリジナルデータソースからレコードをマージ
                Dim dtDeletedRow As DataRow = originalDatasourse.Select("VALUE=" & value)(0)
                If dtDeletedRow IsNot Nothing Then
                    dt.ImportRow(dtDeletedRow)
                Else
                    '完全削除されている場合
                    MessageBox.Show("登録時の選択項目が見当たりません。" & vbCrLf & "完全削除された可能性があります。" & vbCrLf & "選択値:" & value.ToString, "選択項目取得失敗", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                    Return False
                End If
            End If
            cmbCtrl.SelectedValue = value

        Catch ex As Exception
            EM.ErrorSyori(ex, False, conblnNonMsg)
        End Try
    End Function

#End Region

#Region "モデルからデータテーブルを作成"
    ''' <summary>
    ''' モデルからデータテーブルと
    ''' </summary>
    ''' <param name="_type">モデル(テーブル定義クラス)のタイプ</param>
    ''' <returns>dt…テーブル </returns>
    Public Shared Function FunGetTableFromModel(ByVal _type As Type) As (dt As DataTable, properties As Reflection.PropertyInfo())
        Dim dt As New DataTable
        Dim properties As Reflection.PropertyInfo() = _type.GetProperties(Reflection.BindingFlags.Public Or
                                                                              Reflection.BindingFlags.NonPublic Or
                                                                              Reflection.BindingFlags.Instance Or
                                                                              Reflection.BindingFlags.Static Or
                                                                              Reflection.BindingFlags.DeclaredOnly)
        For Each p As Reflection.PropertyInfo In properties
            dt.Columns.Add(p.Name, p.PropertyType)
        Next p

        Return (dt, properties)
    End Function
#End Region

#End Region

#Region "Excel関連"

#Region "エクセル出力ファイル用意"
    'エクセル出力ファイル用意
    '　IN:テンプレートファイル名(ex.｢MBCM010CODE｣)
    '　IN:出力先フォルダ(ex.｢C:\EXCEL\｣)
    '　IN:出力ファイル名（ex.「10_1000123____20110911101010」）データ種類+社員コード(10桁)+要求日時(14桁)
    '　OUT:出力先ファイル名(ex.｢C:\EXCEL\コードマスタ_端末名_20071009_123456.xls｣)
    '  IN:Excelアプリケーション存在チェック 2016.08.09 Add by funato
    Public Shared Function OUT_EXCEL_READY(ByVal strTEMPLATE_FILE As String, ByVal strOUT_FOLDER As String, ByVal strOutFileName As String, Optional ByVal blnCheckExcelApp As Boolean = False, Optional ByVal blnNonMsg As Boolean = False) As Boolean
        Dim typClassType As Type
        Dim strBUFF As String
        Dim FolderBrowserDialog1 As New System.Windows.Forms.FolderBrowserDialog
        Dim strEXCEL_FILE As String
        Try
            If blnCheckExcelApp = True Then
                '-----Excelクラス ProgID に関連付けられている型を取得
                typClassType = Type.GetTypeFromProgID("Excel.Application")


                '-----Excelの型がそれに関連付けられていない。(Excelが存在しない)
                If typClassType Is Nothing Then
                    If Not blnNonMsg Then
                        Call MsgBox("エクセルアプリケーションが見つかりません。", MsgBoxStyle.Exclamation)
                    End If
                    WL.WriteLogDat("エクセルアプリケーションが見つかりません。")
                    Return False
                End If

            End If

            '-----テンプレートXLS存在確認
            If System.IO.File.Exists(strTEMPLATE_FILE) = False Then
                If Not blnNonMsg Then
                    Call MsgBox("エクセルのテンプレートファイルの" & strTEMPLATE_FILE & "が存在しません。確認してください。", MsgBoxStyle.Exclamation)
                End If
                WL.WriteLogDat("エクセルのテンプレートファイルの" & strTEMPLATE_FILE & "が存在しません。確認してください。")
                Return False
            End If

            '-----出力先エクセルファイル取得
            'strEXCEL_FILE = strOUT_FOLDER & strSYORI & "_" & pub_PCNM & "_" & System.DateTime.Now.ToString("yyyyMMdd_HHmmss") & ".xls"
            strEXCEL_FILE = strOUT_FOLDER & strOutFileName

            '-----パス不正時
            If strEXCEL_FILE.IndexOfAny(System.IO.Path.GetInvalidPathChars()) >= 0 Then
                If Not blnNonMsg Then
                    Call MsgBox("｢" & strEXCEL_FILE & "｣に不正文字が含まれている為作成出来ません。", MsgBoxStyle.Exclamation)
                End If
                WL.WriteLogDat("｢" & strEXCEL_FILE & "｣に不正文字が含まれている為作成出来ません。")
                Return False
            End If


            '-----パス無し時
            strBUFF = System.IO.Path.GetDirectoryName(strEXCEL_FILE)
            If strBUFF.IsNullOrWhiteSpace Then
                'Call MsgBox(INI_EXCELFILENAME & "にEXCEL出力先フォルダが設定されていません。", MsgBoxStyle.Exclamation)
                'WL.WriteLogDat(INI_EXCELFILENAME & "にEXCEL出力先フォルダが設定されていません。")
                Return False
            End If


            '-----出力先無し時は作成
            Try
                strBUFF = System.IO.Path.GetFullPath(strBUFF)
                If System.IO.Directory.Exists(strBUFF) = False Then
                    System.IO.Directory.CreateDirectory(strBUFF)
                End If
            Catch ex As Exception
                If Not blnNonMsg Then
                    Call MsgBox("EXCEL出力先フォルダ｢" & strBUFF & "｣は作成出来ません。", MsgBoxStyle.Exclamation)
                End If
                WL.WriteLogDat("EXCEL出力先フォルダ｢" & strBUFF & "｣は作成出来ません。")
                Return False
            End Try



            '-----テンプレートをコピーして今回表示ファイルを作成
            Try
                'コピー
                System.IO.File.Copy(strTEMPLATE_FILE, strEXCEL_FILE)

            Catch CPEx As Exception
                If Not blnNonMsg Then
                    Call MsgBox(strTEMPLATE_FILE & "のコピーに失敗しました。", MsgBoxStyle.Exclamation)
                End If
                WL.WriteLogDat(strTEMPLATE_FILE & "のコピーに失敗しました。")
                Return False
            End Try


            '-----コピーされたかもう一度確認する。
            If System.IO.File.Exists(strEXCEL_FILE) = False Then
                If Not blnNonMsg Then
                    Call MsgBox(strTEMPLATE_FILE & "のコピーに失敗しました。", MsgBoxStyle.Exclamation)
                End If
                WL.WriteLogDat(strTEMPLATE_FILE & "のコピーに失敗しました。")
                Return False
            End If

            Return True

        Catch ex As Exception
            EM.ErrorSyori(ex, False, True)
            Return False
        Finally
        End Try

    End Function
#End Region

#Region "表示"

    Public Shared Function FunOpenExcelApp(ByVal strSagyoPath As String) As Boolean
        Dim typClassType As Type
        Dim xlApp As Object = Nothing
        Dim lnghWnd As Long

        Try
            '-----Excelクラス ProgID に関連付けられている型を取得
            typClassType = Type.GetTypeFromProgID("Excel.Application")


            'EXCEL起動
            xlApp = Activator.CreateInstance(typClassType)

            lnghWnd = Shell(xlApp.Path & "\excel.exe " & ControlChars.Quote & strSagyoPath & ControlChars.Quote, vbMaximizedFocus)
            If lnghWnd = 0 Then
                Call MsgBox(xlApp.Path & "\excel.exe がありません。", MsgBoxStyle.Exclamation)
                Return False
            End If

            Return True

        Catch ex As Exception
            EM.ErrorSyori(ex, False, conblnNonMsg)
            Return False
        Finally
            If Not xlApp Is Nothing Then
                xlApp.Quit()
                MRComObject(xlApp)
            End If

            '-----ガベージコレクション
            GC.Collect()
        End Try

    End Function



#End Region

#Region "COMオブジェクトへの参照を解放"
    'COMオブジェクトへの参照を解放
    '(COM オブジェクトの使用後、明示的に COM オブジェクトへの参照を解放する)
    Public Shared Sub MRComObject(ByRef objCom As Object)
        Try
            '提供されたランタイム呼び出し可能ラッパーの参照カウントをデクリメントします
            If Not objCom Is Nothing AndAlso System.Runtime.InteropServices.
                                                      Marshal.IsComObject(objCom) Then
                Dim I As Integer
                Do
                    I = System.Runtime.InteropServices.Marshal.ReleaseComObject(objCom)
                Loop Until I <= 0
            End If
        Catch
        Finally
            '参照を解除する
            objCom = Nothing
        End Try
    End Sub
#End Region

#Region "シート名から不正文字除く"
    'シート名から不正文字除く
    Public Shared Function REPLACE_SHEETNAME(ByVal strNAME As String) As String
        Dim strBUFF As String

        Try

            strBUFF = strNAME

            strBUFF = Replace(strBUFF, ":", "")
            strBUFF = Replace(strBUFF, "\", "")
            strBUFF = Replace(strBUFF, "/", "")
            strBUFF = Replace(strBUFF, "?", "")
            strBUFF = Replace(strBUFF, "*", "")
            strBUFF = Replace(strBUFF, "[", "")
            strBUFF = Replace(strBUFF, "]", "")
            strBUFF = Replace(strBUFF, "：", "")
            strBUFF = Replace(strBUFF, "￥", "")
            strBUFF = Replace(strBUFF, "／", "")
            strBUFF = Replace(strBUFF, "？", "")
            strBUFF = Replace(strBUFF, "＊", "")
            strBUFF = Replace(strBUFF, "［", "")
            strBUFF = Replace(strBUFF, "］", "")

            Return strBUFF

        Catch ex As Exception
            EM.ErrorSyori(ex, False, conblnNonMsg)
            Return vbNullString
        End Try
    End Function
#End Region

#Region "　CSV出力"
    Public Shared Function WRITE_CSV_FILE(ByRef strOUT_FOLDER As String, ByVal strFILE As String, ByVal strDATA() As String) As Boolean
        Dim strPATH As String

        Try
            If strOUT_FOLDER.IsNullOrWhiteSpace Then
                Return False
            Else
                'パス文字列変換
                Call SubConvPathString(strOUT_FOLDER)

                'フォルダ作成
                strPATH = System.IO.Path.GetDirectoryName(strOUT_FOLDER)
                If System.IO.Directory.Exists(strPATH) = False Then
                    System.IO.Directory.CreateDirectory(strPATH)
                End If

                'CSVファイルに書き込むときに使うEncoding
                Dim enc As System.Text.Encoding = System.Text.Encoding.GetEncoding("Shift_JIS")

                '-----書き込み-----
                System.IO.File.WriteAllLines(strOUT_FOLDER & strFILE, strDATA, enc)

                Return True

            End If

        Catch ex As Exception
            EM.ErrorSyori(ex, False, conblnNonMsg)
            Return False
        End Try
    End Function

    ''' <summary>
    ''' CSV出力
    ''' </summary>
    ''' <param name="dt"></param>
    ''' <param name="strOutPath"></param>
    ''' <returns></returns>
    Public Shared Function FunCSV_OUT(ByVal dt As DataTable, ByVal strFileName As String, ByVal strOutPath As String, Optional ByVal blnWriteHeader As Boolean = True) As Boolean

        Dim strARY() As String

        Dim intROW As Integer
        'Dim intCOL As Integer
        Dim strOUT_PATH As String
        Dim dlgRET As DialogResult
        Dim sb As New System.Text.StringBuilder
        Try

            '出力データチェック
            If dt.Rows.Count = 0 Then
                MessageBox.Show("出力データがありません", "CSV出力", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Return False
            End If

            '出力先フォルダ作成(+相対パス→絶対パス変換)
            If FunCreateDirectory(strOutPath) = False Then
                '出力先フォルダ作成失敗
            End If

            Using sfd As New SaveFileDialog
                With sfd
                    .Title = "出力先を選択して下さい"
                    .Filter = "CSVファイル(*.CSV)|*.CSV"
                    .FileName = strFileName
                    .InitialDirectory = strOutPath
                    .CheckPathExists = True

                    'ダイアログ表示
                    dlgRET = sfd.ShowDialog
                End With

                Application.DoEvents()

                If dlgRET = Windows.Forms.DialogResult.Cancel Then
                    Return False
                Else
                    '出力先
                    strOUT_PATH = FunConvPathString(System.IO.Path.GetDirectoryName(sfd.FileName))
                End If
                'ファイル名
                strFileName = System.IO.Path.GetFileName(sfd.FileName)


                '-----配列用意
                ReDim strARY(0 To dt.Rows.Count)


                If blnWriteHeader = True Then
                    sb.Remove(0, sb.Length)
                    For Each dc As DataColumn In dt.Columns
                        If sb.Length > 0 Then
                            sb.Append(","c)
                        End If
                        sb.Append(EncloseDoubleQuotesIfNeed(dc.ColumnName.ToString.Replace(vbCrLf, "")))
                    Next dc
                    strARY(intROW) = sb.ToString
                    intROW += 1
                End If

                '-----データ書込
                For Each dr As DataRow In dt.Rows
                    sb.Remove(0, sb.Length)
                    For Each item As Object In dr.ItemArray
                        If sb.Length > 0 Then
                            sb.Append(","c)
                        End If
                        sb.Append(EncloseDoubleQuotesIfNeed(item.ToString.Replace(vbCrLf, "")))
                    Next item
                    strARY(intROW) = sb.ToString
                    intROW += 1
                Next dr

            End Using

            '-----CSV出力
            Call WRITE_CSV_FILE(strOUT_PATH, strFileName, strARY)

            MessageBox.Show("｢" & strOUT_PATH & strFileName & "｣に出力しました。", "CSV出力", MessageBoxButtons.OK, MessageBoxIcon.Information)

            Return True

        Catch ex As Exception
            EM.ErrorSyori(ex, False, conblnNonMsg)
            Return False
        End Try
    End Function

    ''' <summary>
    ''' 必要ならば、文字列をダブルクォートで囲む
    ''' </summary>
    Private Shared Function EncloseDoubleQuotesIfNeed(field As String) As String
        If NeedEncloseDoubleQuotes(field) Then
            Return EncloseDoubleQuotes(field)
        End If
        Return field
    End Function

    ''' <summary>
    ''' 文字列をダブルクォートで囲む
    ''' </summary>
    Private Shared Function EncloseDoubleQuotes(field As String) As String
        If field.IndexOf(""""c) > -1 Then
            '"を""とする
            field = field.Replace("""", """""")
        End If
        Return """" & field & """"
    End Function

    ''' <summary>
    ''' 文字列をダブルクォートで囲む必要があるか調べる
    ''' </summary>
    Private Shared Function NeedEncloseDoubleQuotes(field As String) As Boolean
        Return field.IndexOf(""""c) > -1 OrElse
        field.IndexOf(","c) > -1 OrElse
        field.IndexOf(ControlChars.Cr) > -1 OrElse
        field.IndexOf(ControlChars.Lf) > -1 OrElse
        field.StartsWith(" ") OrElse
        field.StartsWith(vbTab) OrElse
        field.EndsWith(" ") OrElse
        field.EndsWith(vbTab)
    End Function
#End Region

#End Region

#Region "フォーマット関連"

#Region "時刻数値の計算"
    ''' <summary>
    ''' 60進数の時刻を表す数値の計算
    ''' </summary>
    ''' <param name="dec1"></param>
    ''' <param name="dec2"></param>
    ''' <param name="intMode">
    ''' 0…＋ 1…― 2…× 3…÷</param>
    ''' <returns></returns>
    Public Shared Function TimeCalc(dec1 As Decimal, dec2 As Decimal, intMode As Integer) As Decimal
        Dim decCalc As Decimal

        Dim decWk1 As Decimal
        Dim decWk2 As Decimal

        decWk1 = Convert10(dec1)
        decWk2 = Convert10(dec2)

        Select Case intMode
            Case 0 : decCalc = decWk1 + decWk2
            Case 1 : decCalc = decWk1 - decWk2
            Case 2 : decCalc = (decWk1 * decWk2) / 100
            Case 3 : decCalc = (decWk1 / decWk2) * 100
        End Select

        Dim intPart As Integer = Math.Truncate(decCalc)
        Dim decPart As Decimal = decCalc - Math.Truncate(decCalc)

        Return intPart + (decPart * 0.6)
    End Function

    Private Shared Function Convert10(dec As Decimal) As Decimal
        Dim strWk As String

        strWk = Strings.Right(Format(dec, "#.#0"), 2)
        Return CDec(Int(dec) + (CDec(strWk) / 60))
    End Function
#End Region

#Region "　桁数チェック"
    '桁数チェック
    Public Shared Function FunNUMCHECK(ByVal strDATA As String, ByVal intSEISUKETA As Integer, ByVal intSYOSUKETA As Integer) As Integer
        Dim lngBUFF As Long
        Dim intCNT As Integer
        Dim strBUFF As String

        Try
            '-----文字列チェック
            For intCNT = 0 To strDATA.Length - 1
                strBUFF = strDATA.Substring(intCNT, 1)
                If InStr("1234567890.-", strBUFF) = 0 Then
                    Return 1
                End If
            Next

            '-----数値かチェック
            If IsNumeric(strDATA) = False Then
                Return 1
            End If


            '-----整数桁長取得
            If Val(strDATA) >= 0 Then '正数時
                lngBUFF = System.Math.Truncate(Val(strDATA))
            ElseIf Val(strDATA) < 0 Then '負数時
                lngBUFF = System.Math.Truncate(Val(strDATA) * -1)
            End If


            '-----整数桁長チェック
            If CStr(lngBUFF).Length > intSEISUKETA Then
                Return 1
            End If

            '-----少数桁長チェック
            If Val(strDATA) >= 0 Then '正数時
                If strDATA.Length - CStr(lngBUFF).Length > intSYOSUKETA + 1 Then
                    Return 1
                End If
            ElseIf Val(strDATA) < 0 Then '負数時
                If strDATA.Length - 1 - CStr(lngBUFF).Length > intSYOSUKETA + 1 Then
                    Return 1
                End If
            End If


            Return 0

        Catch ex As Exception
            EM.ErrorSyori(ex)
            Return -1
        End Try
    End Function

#End Region

#Region "　指定した精度の数値に切り捨て"
    ''' ------------------------------------------------------------------------
    ''' <summary>
    '''     指定した精度の数値に切り捨てします。</summary>
    ''' <param name="dValue">
    '''     丸め対象の倍精度浮動小数点数。</param>
    ''' <param name="iDigits">
    '''     戻り値の有効桁数の精度。</param>
    ''' <returns>
    '''     iDigits に等しい精度の数値に切り捨てられた数値。</returns>
    ''' ------------------------------------------------------------------------
    Public Shared Function ToRoundDown(ByVal dValue As Double, ByVal iDigits As Integer) As Double
        Dim dCoef As Double = System.Math.Pow(10, iDigits)

        If dValue > 0 Then
            Return System.Math.Floor(dValue * dCoef) / dCoef
        Else
            Return System.Math.Ceiling(dValue * dCoef) / dCoef
        End If
    End Function

#End Region

#Region "　指定した精度の数値に切り上げ"
    ''' ------------------------------------------------------------------------
    ''' <summary>
    '''     指定した精度の数値に切り上げします。</summary>
    ''' <param name="dValue">
    '''     丸め対象の倍精度浮動小数点数。</param>
    ''' <param name="iDigits">
    '''     戻り値の有効桁数の精度。</param>
    ''' <returns>
    '''     iDigits に等しい精度の数値に切り上げられた数値。</returns>
    ''' ------------------------------------------------------------------------
    Public Shared Function ToRoundUp(ByVal dValue As Double, ByVal iDigits As Integer) As Double
        Dim dCoef As Double = System.Math.Pow(10, iDigits)

        If dValue > 0 Then
            Return System.Math.Ceiling(dValue * dCoef) / dCoef
        Else
            Return System.Math.Floor(dValue * dCoef) / dCoef
        End If
    End Function

#End Region

#Region "　指定した精度の数値に四捨五入 !=JIS丸め"
    '四捨五入
    Public Shared Function ToHalfAdjust_NOTJIS(ByVal dValue As Double, ByVal iDigits As Integer) As Double
        Dim dCoef As Double = System.Math.Pow(10, iDigits)

        If dValue > 0 Then
            Return System.Math.Floor((dValue * dCoef) + 0.5) / dCoef
        Else
            Return System.Math.Ceiling((dValue * dCoef) - 0.5) / dCoef
        End If
    End Function
#End Region

#Region "　ByteSubstring"
    Public Shared Function ByteSubstring(ByVal value As String, ByVal startindex As Integer, ByVal length As Integer) As String

        Dim ret As String = ""          ' 切り出した文字列
        Dim start As Integer = 0
        Dim sjis As System.Text.Encoding
        sjis = System.Text.Encoding.GetEncoding("Shift-JIS")
        Dim i As Integer = 0

        If startindex < 0 Then startindex = 0

        ' 開始位置を取得
        If startindex = 0 Then
            ' 先頭を指定された
            start = 0
        Else
            ' 先頭以外を指定された
            Dim bytecnt As Integer = 0
            For i = 0 To value.Length - 1
                ' 先頭からのバイト数を取得
                Dim tmp As String = value.Substring(i, 1)
                bytecnt += sjis.GetByteCount(tmp)

                If bytecnt >= startindex Then
                    ' 先頭からのバイト数が開始位置以上になる文字の次の文字が開始位置
                    start = i + 1
                    Exit For
                End If

            Next i
        End If

        ' 決定した開始位置から1文字ずつ取得し、指定バイト数を超えるまで取得
        For i = 0 To value.Length - 1
            If i >= start Then
                Dim temp As String = value.Substring(i, 1)
                If sjis.GetByteCount(ret & temp) <= length Then
                    ret &= temp
                End If
            End If
        Next i

        Return ret

    End Function

#End Region

#Region "　MidB"
    '■MidB
    '''  <summary>Mid関数のバイト版。文字数と位置をバイト数で指定して文字列を切り抜く。</summary>
    '''  <param name="str">対象の文字列</param>
    '''  <param name="Start">切り抜き開始位置。全角文字を分割するよう位置が指定された場合、戻り値の文字列の先頭は意味不明の半角文字となる。</param>
    '''  <param name="Length">切り抜く文字列のバイト数</param>
    '''  <returns>切り抜かれた文字列</returns>
    '''  <remarks>最後の１バイトが全角文字の半分になる場合、その１バイトは無視される。</remarks>
    Public Shared Function MidB(ByVal str As String, ByVal Start As Integer, Optional ByVal Length As Integer = 0) As String
        Try


            '▼空文字に対しては常に空文字を返す

            If str.IsNullOrWhiteSpace Then
                Return ""
            End If

            '▼Lengthのチェック

            'Lengthが0か、Start以降のバイト数をオーバーする場合はStart以降の全バイトが指定されたものとみなす。

            Dim RestLength As Integer = System.Text.Encoding.GetEncoding("Shift_JIS").GetByteCount(str) - Start + 1

            If Length = 0 OrElse Length > RestLength Then
                Length = RestLength
            End If

            '▼切り抜き

            Dim SJIS As System.Text.Encoding = System.Text.Encoding.GetEncoding("Shift-JIS")
            Dim B() As Byte = CType(Array.CreateInstance(GetType(Byte), Length), Byte())

            Array.Copy(SJIS.GetBytes(str), Start - 1, B, 0, Length)

            Dim st1 As String = SJIS.GetString(B)

            '▼切り抜いた結果、最後の１バイトが全角文字の半分だった場合、その半分は切り捨てる。

            Dim ResultLength As Integer = System.Text.Encoding.GetEncoding("Shift_JIS").GetByteCount(st1) - Start + 1

            If Asc(Strings.Right(st1, 1)) = 0 Then
                'VB.NET2002,2003の場合、最後の１バイトが全角の半分の時
                Return st1.Substring(0, st1.Length - 1)
            ElseIf Length = ResultLength - 1 Then
                'VB2005の場合で最後の１バイトが全角の半分の時
                Return st1.Substring(0, st1.Length - 1)
            Else
                'その他の場合
                Return st1
            End If
        Catch ex As Exception
            EM.ErrorSyori(ex, False, conblnNonMsg)
            Return ""
        End Try

    End Function

#End Region

#Region "　Nz関数"
    'CHECKED: 2015.11.03 by funato
    ''' <summary>
    ''' オブジェクトが Nothing または DBNull の場合に長さ 0 の文字列("")または指定したその他の値を返す　AccessVBAのNz関数より
    ''' </summary>
    ''' <param name="Value">対象となるオブジェクト</param>
    ''' <param name="ValueIfNull">Nothing または DBNull のときに返す値を指定、長さ 0 の文字列("")以外の値を返す場合に指定</param>
    ''' <returns>長さ 0 の文字列("")または、指定したその他の値</returns>
    ''' <remarks></remarks>
    Public Shared Function Nz(ByVal Value As Object, Optional ByVal ValueIfNull As Object = Nothing) As String

        Dim res As Object = Nothing

        Try
            If ValueIfNull Is Nothing Then
                res = Space(0)
            Else
                res = ValueIfNull
            End If

            'チェックする値型が数値型でNullの場合は返す値を0とする
            If IsNumeric(Value) = True Then
                If IsNothing(Value) OrElse IsDBNull(Value) Then
                    Return 0
                Else
                    Return Value
                End If
            Else
                If IsNothing(Value) OrElse IsDBNull(Value) OrElse Value = "" Then
                    Return res
                Else
                    Return Value.ToString()
                End If
            End If

            Return ""
        Catch ex As Exception
            EM.ErrorSyori(ex)
            Return res
        End Try

    End Function
#End Region

#Region "　全角/半角数"
    '全角数/半角数/バイト数を戻す
    '   元データ
    '   Z:全角数、H:半角数、B：BYTE数
    Public Shared Function FunZHCNT(ByVal strDATA As String, ByVal strMODE As String) As Integer
        Dim intStrLen As Integer
        Dim intStrByte As Integer
        Dim intHankaku As Integer
        Dim intZenkaku As Integer

        Try
            'strStr = TextBox1.Text
            ''System.Text.Encoding.GetEncoding("Shift_JIS")
            'sjisEnc = sjisEnc.GetEncoding("Shift_JIS")

            intStrByte = System.Text.Encoding.GetEncoding("Shift_JIS").GetByteCount(strDATA)
            intStrLen = strDATA.Length

            intHankaku = intStrLen * 2 - intStrByte
            intZenkaku = intStrLen - intHankaku

            If strMODE = "Z" Then
                Return intZenkaku

            ElseIf strMODE = "H" Then
                Return intHankaku

            ElseIf strMODE = "B" Then
                Return intZenkaku * 2 + intHankaku
            End If


        Catch ex As Exception
            EM.ErrorSyori(ex)
        Finally
        End Try
    End Function
#End Region

#Region "　日付範囲チェック"
    Public Shared Function FunDATESPAN(ByVal strYMD As String, Optional ByVal strNAME As String = "") As Integer

        Try
            If strNAME.IsNullOrWhiteSpace Then
                strNAME = "日付"
            End If

            '10桁(yyyy/MM/dd)以外
            If strYMD.Replace(" ", "").Length <> 10 Then
                MsgBox(strNAME & "は YYYY/MM/DD 形式で入力してください", MsgBoxStyle.Information)
                Return -1
            End If


            '過去15日以上前
            If strYMD < System.DateTime.Now.AddDays(-15).ToString("yyyy/MM/dd") Then
                If MsgBox(strNAME & "が 半月以上前 ですが、よろしいですか？", MsgBoxStyle.YesNo + MsgBoxStyle.DefaultButton2 + MsgBoxStyle.Information) = MsgBoxResult.No Then
                    Return -1
                End If
            End If

            '過去365日以上前
            If strYMD < System.DateTime.Now.AddDays(-365).ToString("yyyy/MM/dd") Then
                If MsgBox(strNAME & "が １年以上前 になります、本当によろしいですか？", MsgBoxStyle.YesNo + MsgBoxStyle.DefaultButton2 + MsgBoxStyle.Information) = MsgBoxResult.No Then
                    Return -1
                End If
            End If

            '60日以上先
            If strYMD > System.DateTime.Now.AddDays(60).ToString("yyyy/MM/dd") Then
                If MsgBox(strNAME & "が ２カ月以上先 ですが、よろしいですか？", MsgBoxStyle.YesNo + MsgBoxStyle.DefaultButton2 + MsgBoxStyle.Information) = MsgBoxResult.No Then
                    Return -1
                End If
            End If

            '365日以上先
            If strYMD > System.DateTime.Now.AddDays(365).ToString("yyyy/MM/dd") Then
                If MsgBox(strNAME & "が １年以上先 になります、本当によろしいですか？", MsgBoxStyle.YesNo + MsgBoxStyle.DefaultButton2 + MsgBoxStyle.Information) = MsgBoxResult.No Then
                    Return -1
                End If
            End If


            Return 0


        Catch ex As Exception
            EM.ErrorSyori(ex)
            Return -1
        Finally
        End Try
    End Function
#End Region

#Region "　数値型日付を書式付きフォーマットに変換"
    '数値型日付を書式付きフォーマットに変換
    Public Shared Function FunGetFormattedDateString(ByVal strNumericDate As String) As String
        Try
            If strNumericDate.Length = 8 Then
                Return String.Format("{0}/{1}/{2}", strNumericDate.Substring(0, 4), strNumericDate.Substring(4, 2), strNumericDate.Substring(6, 2))
            Else
                Return strNumericDate
            End If

        Catch ex As Exception
            EM.ErrorSyori(ex, False, conblnNonMsg)
            Return vbNullString
        End Try
    End Function
#End Region

#Region "　ToFToNumber"
    Public Shared Function FunConvToFToNumer(ByVal objArgs As Object) As Object
        Dim intRET As Integer
        Dim blnRET As Boolean
        Try
            If TypeOf objArgs Is Boolean Then
                'boolean→integer
                If objArgs = True Then
                    intRET = 1
                Else
                    intRET = 0
                End If

                Return intRET
            Else
                'integer→boolean
                If objArgs = 1 Then
                    blnRET = True
                Else
                    blnRET = False
                End If

                Return blnRET
            End If

        Catch ex As Exception
            EM.ErrorSyori(ex, False, False)
            Return Nothing
        End Try
    End Function

#End Region

#Region "Object型を文字列に変換する"
    ''' <summary>
    ''' Object型の値をStringに変換する処理
    ''' </summary>
    ''' <param name="objData">オブジェクト</param>
    ''' <remarks>Object型の値をStringに変換する</remarks>
    Public Shared Function Fun_sObjectToString(ByVal objData As Object) As String

        Fun_sObjectToString = ""

        Try
            ' Nothing の場合
            If objData Is Nothing Then Return ""

            Dim l_oType As System.Type = objData.GetType()

            ' 配列の場合
            If l_oType.IsArray = True Then
                Diagnostics.Debug.Assert(False, "引数[a_objObj]は配列です。")
                Return ""
            End If

            ' 値型の場合のみ値の内容を文字に変換する
            Select Case l_oType.FullName
                Case "System.Int32"
                    Return DirectCast(objData, System.Int32).ToString()
                Case "System.Int64"
                    Return DirectCast(objData, System.Int64).ToString()
                Case "System.Single"
                    Return DirectCast(objData, System.Single).ToString()
                Case "System.Double"
                    Return DirectCast(objData, System.Double).ToString()
                Case "System.Boolean"
                    Return DirectCast(objData, System.Boolean).ToString()
                Case "System.Byte"
                    Return DirectCast(objData, System.Byte).ToString()
                Case "System.Decimal"
                    Return DirectCast(objData, System.Decimal).ToString()
                Case "System.String"
                    Return DirectCast(objData, System.String)
                Case "System.Char"
                    Return CType(DirectCast(objData, System.Char), System.String)
                Case "System.DateTime"
                    Return DirectCast(objData, System.DateTime).ToString("yyyy/MM/dd HH:mm:ss")
                Case Else
                    Diagnostics.Debug.Assert(False, "引数[a_objObj]は値を持っていません！！")
                    ' 値型以外の場合は型の名前を返す
                    Return l_oType.ToString()
            End Select

        Catch ex As Exception
            EM.ErrorSyori(ex)
        End Try
    End Function

#End Region

#Region "Image To Icon"
    Public Shared Function ConvertImageToIcon(ByVal img As Image) As Icon
        Return Icon.FromHandle(DirectCast(img, Bitmap).GetHicon())
    End Function

#End Region


#End Region

#Region "　シェルコマンド実行"
    Public Shared Function FunExexuteShellCommand(ByVal strCommand As String) As String
        Dim p As New System.Diagnostics.Process()

        Try

            'ComSpec(cmd.exe)のパスを取得して、FileNameプロパティに指定
            p.StartInfo.FileName = System.Environment.GetEnvironmentVariable("ComSpec")
            '出力を読み取れるようにする
            p.StartInfo.UseShellExecute = False
            p.StartInfo.RedirectStandardOutput = True
            p.StartInfo.RedirectStandardInput = False
            'ウィンドウを表示しないようにする
            p.StartInfo.CreateNoWindow = True
            'コマンドラインを指定（"/c"は実行後閉じるために必要）
            p.StartInfo.Arguments = "/c " & strCommand

            '起動
            p.Start()

            '出力を読み取る
            Dim results As String = p.StandardOutput.ReadToEnd()

            'プロセス終了まで待機する
            'WaitForExitはReadToEndの後である必要がある
            '(親プロセス、子プロセスでブロック防止のため)
            p.WaitForExit()
            p.Close()

            '出力された結果を表示
            Return results
        Catch ex As Exception
            EM.ErrorSyori(ex)
            Return ""
        End Try
    End Function
#End Region

#Region "　別プログラム実行"

    ''' <summary>
    ''' 指定されたプログラム(ファイル)を起動します。
    ''' </summary>
    ''' <param name="strProc">実行ファイルパス</param>
    ''' <param name="strPara">パラメータ</param>
    ''' <param name="intExecMODE">実行モード　0=同期実行 1=非同期実行</param>
    ''' <param name="intWindowMODE">ウインドウ表示状態</param>
    ''' <returns></returns>
    Public Shared Function FunCallEXE(ByVal strProc As String, ByVal strPara As String, ByVal intExecMODE As Integer, Optional ByVal intWindowMODE As ENM_WINDOWMODE = ENM_WINDOWMODE._1_SW_SHOWNORMAL, Optional ByVal intWaitSec As Integer = 10) As Boolean
        Dim blnRET As Boolean

        Try

            '-----起動
            If System.IO.File.Exists(strProc) = False Then
                Dim strMsg As String
                strMsg = "下記プログラムファイルが見つかりません。" & vbCrLf & "システム管理者にご連絡下さい。" &
                            vbCrLf & vbCrLf & strProc
                MessageBox.Show(strMsg, My.Application.Info.AssemblyName, MessageBoxButtons.OK, MessageBoxIcon.Information)
                Return False
            End If

            Using hProcess As New System.Diagnostics.Process
                With hProcess
                    ' 起動するアプリケーションを設定する
                    hProcess.StartInfo.FileName = strProc

                    ' コマンドライン引数を設定する
                    hProcess.StartInfo.Arguments = strPara

                    ' 新しいウィンドウを作成するかどうかを設定する (初期値 False)
                    .StartInfo.CreateNoWindow = True

                    ' シェルを使用するかどうか設定する (初期値 True)
                    .StartInfo.UseShellExecute = False

                    ' 起動できなかった時にエラーダイアログを表示するかどうかを設定する (初期値 False)
                    .StartInfo.ErrorDialog = False

                    ' エラーダイアログを表示するのに必要な親ハンドルを設定する
                    '.StartInfo.ErrorDialogParentHandle = parentWindow.Handle

                    ' アプリケーションを起動する時の動詞を設定する
                    '.StartInfo.Verb = "Open"

                    ' 起動ディレクトリを設定する
                    '.StartInfo.WorkingDirectory = "C:\"

                    ' 起動時のウィンドウの状態を設定する
                    Select Case intWindowMODE
                        Case ENM_WINDOWMODE._0_SW_HIDE
                            .StartInfo.WindowStyle = System.Diagnostics.ProcessWindowStyle.Hidden
                        Case ENM_WINDOWMODE._2_SW_SHOWMINIMIZED
                            .StartInfo.WindowStyle = System.Diagnostics.ProcessWindowStyle.Minimized
                        Case ENM_WINDOWMODE._3_SW_SHOWMAXIMIZED
                            .StartInfo.WindowStyle = System.Diagnostics.ProcessWindowStyle.Maximized
                        Case Else
                            .StartInfo.WindowStyle = System.Diagnostics.ProcessWindowStyle.Normal     '通常
                    End Select


                    blnRET = .Start()

                    'While .HasExited = False
                    '    'Application.DoEvents()
                    '    Threading.Thread.Sleep(1000)
                    'End While
                    If intExecMODE = ENM_EXECMODE._0_Sync Then
                        '同期実行 プロセス終了まで待機
                        .WaitForExit(intWaitSec * 1000)
                    Else
                    End If
                End With
            End Using

            Return blnRET
        Catch exWin32 As System.ComponentModel.Win32Exception
            'UAC等のセキュリティ警告画面にて、プログラム実行をキャンセルされた場合
            Return False
        Catch ex As Exception
            EM.ErrorSyori(ex, False, conblnNonMsg)
            Return False
        Finally

        End Try
    End Function
#End Region

#Region "　エラーログメール通知"

    '    Public Shared Function FunSendErrorMail(ByVal DB As clsDbUtility, _
    '                                            ByVal subject As String, _
    '                                            ByVal message As String, _
    '                                            Optional ByVal sendFile As List(Of String) = Nothing) As Boolean

    '        Dim clsMail As New clsSendMail
    '        Dim AddressTo As New List(Of String)
    '        Dim AddressCC As New List(Of String)

    '        Dim sbSQL As New System.Text.StringBuilder
    '        Dim dtReader As System.Data.Common.DbDataReader = Nothing

    '        Dim blnRET As Boolean

    '        Try


    '            clsMail.GetMailSetting(DB)

    '            '---送信先
    '            sbSQL.Remove(0, sbSQL.Length)
    '            sbSQL.Append("SELECT * FROM MTB_CODE")
    '            sbSQL.Append(" WHERE KOMO_NM = 'ERROR_SEND_TO'")
    '            sbSQL.Append(" ORDER BY VALUE")

    '            dtReader = DB.GetDataReader(sbSQL.ToString)

    '            Do While dtReader.Read = True
    '                If dtReader.Item("DISP").ToString.TrimEnd <> "" Then
    '                    AddressTo.Add(dtReader.Item("DISP").ToString.TrimEnd)
    '                End If
    '            Loop
    '            dtReader.Close()

    '            '---CC
    '            sbSQL.Remove(0, sbSQL.Length)
    '            sbSQL.Append("SELECT * FROM MTB_CODE")
    '            sbSQL.Append(" WHERE KOMO_NM = 'ERROR_SEND_CC'")
    '            sbSQL.Append(" ORDER BY VALUE")
    '            dtReader = DB.GetDataReader(sbSQL.ToString)
    '            Do While dtReader.Read = True
    '                If dtReader.Item("DISP").ToString.TrimEnd <> "" Then
    '                    AddressCC.Add(dtReader.Item("DISP").ToString.TrimEnd)
    '                End If
    '            Loop
    '            dtReader.Close()

    '            blnRET = clsMail.Send_Mail(AddressTo, AddressCC, Nothing, subject, message, sendFile)
    '            Return blnRET

    '        Catch ex As Exception
    '            EM.ErrorSyori(ex, False, conblnNonMsg)
    '            Return False
    '        Finally
    '            If Not (dtReader Is Nothing) Then
    '                dtReader.Close()
    '            End If

    '            clsMail = Nothing
    '        End Try
    '    End Function
#End Region

#Region "デバッグ関連"
    Public Shared Function FunGetBuildDatetime(ByVal Ver As Version) As DateTime

        Try
            '標準のワイルドカードバージョンの場合
            Dim dt As DateTime = New DateTime(2000, 1, 1, 9, 0, 0) 'UTC+9
            Dim dtRET As DateTime
            'dtRET = dt.AddDays(Ver.Build).AddSeconds(Ver.Revision * 2)

            'AutomaticVersionsAdd-inの場合
            dtRET = dt.AddYears(Ver.Build.ToString.Substring(0, 2)).AddDays(Ver.Build.ToString.Substring(2, 3) - 1).AddHours(Ver.Revision.ToString("0000").Substring(0, 2)).AddMinutes(Ver.Revision.ToString("0000").Substring(2, 2))

            Return dtRET
        Catch ex As Exception
            EM.ErrorSyori(ex, False, conblnNonMsg)
            Return Nothing
        End Try
    End Function
#End Region

#Region "Attribute"
    Public Shared Function GetDisplayName(ByVal _type As Type, ByVal _property As String) As String
        Dim _attribute As System.ComponentModel.DisplayNameAttribute
        _attribute = Attribute.GetCustomAttribute(_type.GetProperty(_property),
                                         GetType(System.ComponentModel.DisplayNameAttribute))
        Return _attribute?.DisplayName
    End Function

    Public Shared Function IsAutoGenerateField(ByVal _type As Type, ByVal _property As String) As Boolean
        Try
            Dim blnRET As Boolean

            Dim _attribute As DisplayAttribute
            _attribute = Attribute.GetCustomAttribute(_type.GetProperty(_property),
                                             GetType(DisplayAttribute))

            If _attribute Is Nothing Then
                blnRET = True
            Else
                blnRET = _attribute.AutoGenerateField
            End If

            Return blnRET
        Catch ex As Exception
            EM.ErrorSyori(ex, False, conblnNonMsg)
            Return False
        End Try
    End Function
#End Region

End Class
