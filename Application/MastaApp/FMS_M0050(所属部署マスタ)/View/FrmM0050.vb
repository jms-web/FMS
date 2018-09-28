Imports JMS_COMMON.ClsPubMethod

''' <summary>
''' コードマスタ検索画面
''' </summary>
Public Class FrmM0050

#Region "コンストラクタ"

    ''' <summary>
    ''' コンストラクタ
    ''' </summary>
    ''' <remarks>コンストラクタ</remarks>
    Public Sub New()

        ' この呼び出しはデザイナーで必要です。
        InitializeComponent()
        'ツールチップメッセージ
        MyBase.ToolTip.SetToolTip(Me.cmdFunc3, My.Resources.infoToolTipMsgNotFoundData)
        MyBase.ToolTip.SetToolTip(Me.cmdFunc4, My.Resources.infoToolTipMsgNotFoundData)
        MyBase.ToolTip.SetToolTip(Me.cmdFunc5, My.Resources.infoToolTipMsgNotFoundData)
        MyBase.ToolTip.SetToolTip(Me.cmdFunc10, My.Resources.infoToolTipMsgNotFoundData)

    End Sub

#End Region

#Region "Form関連"

    'Loadイベント
    Private Sub FrmLoad(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        Try
            '-----フォーム初期設定(親フォームから呼び出し)
            Call FunFormCommonSetting(pub_APP_INFO, pub_SYAIN_INFO, My.Application.Info.Version.ToString)
            Using DB As ClsDbUtility = DBOpen()
                lblTytle.Text = FunGetCodeMastaValue(DB, "PG_TITLE", Me.GetType.ToString)
            End Using

            ''-----グリッド初期設定
            FunInitializeFlexGrid(flxDATA)
            FunInitializeFlexGrid(flxDATA_SYAIN)

            '-----コントロールデータソース設定
            Me.cmbBUSYO_KB.SetDataSource(tblBUSYO_KB.ExcludeDeleted, ENM_COMBO_SELECT_VALUE_TYPE._0_Required)
            Me.cmbSYAIN_KB.SetDataSource(tblSYAIN_KB.ExcludeDeleted, ENM_COMBO_SELECT_VALUE_TYPE._2_Option)
            Me.cmbYAKUSYOKU_KB.SetDataSource(tblYAKUSYOKU_KB.ExcludeDeleted, ENM_COMBO_SELECT_VALUE_TYPE._2_Option)

            ''-----イベントハンドラ設定
            AddHandler Me.cmbBUSYO_NAME.SelectedValueChanged, AddressOf SearchFilterValueChanged
            'AddHandler Me.chkDeletedRowVisibled.CheckedChanged, AddressOf SearchFilterValueChanged

            '検索実行
            cmdFunc1.PerformClick()
        Finally

        End Try
    End Sub

    Overrides Sub FrmBaseStsBtn_Resize(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Resize
        If Me.Visible = False Then Exit Sub

        If Me.DesignMode = True Then Exit Sub

        ''===================================
        ''   ボタン位置、サイズ設定
        ''===================================
        'Call SetButtonSize(Me.Width, cmdFunc)

        MyBase.FrmBaseStsBtn_Resize(Me, e)

    End Sub

#End Region

#Region "DataGridView関連"

    '初期化
    Private Function FunInitializeFlexGrid(ByVal flxgrd As C1.Win.C1FlexGrid.C1FlexGrid) As Boolean
        With flxgrd
            .Rows(0).Height = 30

            .AutoGenerateColumns = False
            .AutoResize = True
            .AllowEditing = False
            .AllowDragging = C1.Win.C1FlexGrid.AllowDraggingEnum.None
            .AllowDelete = False
            .AllowResizing = C1.Win.C1FlexGrid.AllowResizingEnum.Columns
            .AllowSorting = C1.Win.C1FlexGrid.AllowSortingEnum.SingleColumn
            '.AllowMerging = C1.Win.C1FlexGrid.AllowMergingEnum.RestrictRows
            .AllowFiltering = True

            .ShowCellLabels = True
            .SelectionMode = C1.Win.C1FlexGrid.SelectionModeEnum.Row
            .FocusRect = C1.Win.C1FlexGrid.FocusRectEnum.None

            .Font = New Font("Meiryo UI", 9, FontStyle.Regular, GraphicsUnit.Point, CType(128, Byte))

            .Styles.Add("DeletedRow")
            .Styles("DeletedRow").BackColor = clrDeletedRowBackColor
            .Styles("DeletedRow").ForeColor = clrDeletedRowForeColor

            .VisualStyle = C1.Win.C1FlexGrid.VisualStyle.Office2010Silver 'Custom

            '以下を適用するにはVisualStyleをCustomにする
            .Styles.Alternate.BackColor = clrRowEvenColor
            .Styles.Normal.BackColor = clrRowOddColor
            .Styles.Focus.BackColor = clrRowEnterColor
        End With
    End Function

    '行選択時イベント
    Private Sub FlxDATA_RowColChange(sender As Object, e As EventArgs) Handles flxDATA.RowColChange
        Call SubInitFuncButtonEnabled()
    End Sub

    Private Sub flxDATA_SYAIN_RowColChange(sender As Object, e As EventArgs) Handles flxDATA_SYAIN.RowColChange
        Call SubInitFuncButtonEnabled()
    End Sub

    '列フィルタ適用
    Private Sub FlxDATA_AfterFilter(sender As Object, e As EventArgs) Handles flxDATA.AfterFilter
        Dim flx As C1.Win.C1FlexGrid.C1FlexGrid = DirectCast(sender, C1.Win.C1FlexGrid.C1FlexGrid)
        Dim intCNT As Integer

        For Each r As C1.Win.C1FlexGrid.Row In flx.Rows
            If r.Visible = True Then
                intCNT += 1
            End If
        Next
        intCNT -= flx.Rows.Fixed

        If intCNT > 0 Then
            Me.lblRecordCount.Text = String.Format(My.Resources.infoToolTipMsgFoundData, intCNT)
        Else
            Me.lblRecordCount.Text = My.Resources.infoSearchResultNotFound
        End If
    End Sub

    'グリッドセル(行)ダブルクリック時イベント
    Private Sub FlxDATA_DoubleClick(sender As Object, e As EventArgs) Handles flxDATA.DoubleClick
        If flxDATA.RowSel > 0 Then
            Me.cmdFunc4.PerformClick()
        End If
    End Sub

#End Region

#Region "FunctionButton関連"

#Region "ボタンクリックイベント"

    Private Sub CmdFunc_Click(ByVal sender As Object, ByVal e As EventArgs) Handles cmdFunc1.Click, cmdFunc2.Click, cmdFunc3.Click, cmdFunc4.Click, cmdFunc5.Click, cmdFunc6.Click, cmdFunc7.Click, cmdFunc8.Click, cmdFunc9.Click, cmdFunc10.Click, cmdFunc11.Click, cmdFunc12.Click
        Dim intFUNC As Integer
        Dim intCNT As Integer
        Dim sbSQL As New System.Text.StringBuilder
        Dim dsList As New DataSet
        Dim intRET As Integer
        Try
            '[処理中]
            Me.PrPG_STATUS = ENM_PG_STATUS._3_PROCESSING

            'ボタン不可/ボタンINDEX取得
            For intCNT = 0 To Me.cmdFunc.Length - 1
                Me.cmdFunc(intCNT).Enabled = False
                If cmdFunc(intCNT) Is sender Then intFUNC = intCNT + 1
            Next

            'ボタンINDEX毎の処理
            Select Case intFUNC
                Case 1  '検索
                    Call FunSRCH(Me.flxDATA_SYAIN, FunGetListData_SYAIN())

                Case 2  '主務追加
                    If FunUpdateEntity(0) = True Then
                        Call FunSRCH(Me.flxDATA, FunGetListData())
                    End If

                Case 3  '兼務追加
                    If FunUpdateEntity(1) = True Then
                        Call FunSRCH(Me.flxDATA, FunGetListData())
                    End If

                Case 5 '削除
                    If FunDEL() = True Then
                        Call FunSRCH(Me.flxDATA, FunGetListData())
                    End If

                Case 10  'CSV出力
                    Dim strFileName As String = pub_APP_INFO.strTitle & "_" & DateTime.Today.ToString("yyyyMMdd") & ".CSV"

                    sbSQL.Remove(0, sbSQL.Length)
                    sbSQL.Append("SELECT")
                    sbSQL.Append(" * ")
                    sbSQL.Append(" FROM " & NameOf(MODEL.VWM005_SYOZOKU_BUSYO) & " ")
                    sbSQL.Append(" WHERE ")
                    sbSQL.Append(" DEL_FLG = '0'")
                    sbSQL.Append(" ORDER BY BUSYO_KB,BUSYO_ID,SYAIN_ID")
                    Using DB As ClsDbUtility = DBOpen()
                        dsList = DB.GetDataSet(sbSQL.ToString, conblnNonMsg)
                    End Using

                    Call FunCSV_OUT(dsList.Tables(0), strFileName, pub_APP_INFO.strOUTPUT_PATH)

                Case 12 '閉じる
                    Me.Close()

            End Select
        Catch ex As Exception
            EM.ErrorSyori(ex, False, conblnNonMsg)
        Finally
            'ボタン可
            System.Windows.Forms.Application.DoEvents()
            For intCNT = 0 To Me.cmdFunc.Length - 1
                Me.cmdFunc(intCNT).Enabled = True
            Next

            'ファンクションキー有効化初期化
            Call SubInitFuncButtonEnabled()

            '[アクティブ]
            Me.PrPG_STATUS = ENM_PG_STATUS._2_ACTIVE
        End Try

    End Sub

#End Region

#Region "検索"

    Private Function FunGetListData() As DataTable
        Try
            Dim sbSQL As New System.Text.StringBuilder
            Dim dsList As New DataSet
            Dim sbSQLWHERE As New System.Text.StringBuilder

            ''----DBデータ取得
            sbSQLWHERE.Remove(0, sbSQLWHERE.Length)

            sbSQLWHERE.Append(" WHERE 0 = 0 ")

            If Me.cmbBUSYO_NAME.SelectedValue <> 0 Then
                sbSQLWHERE.Append(" AND BUSYO_ID = " & Me.cmbBUSYO_NAME.SelectedValue & " ")
            Else
                sbSQLWHERE.Append(" AND BUSYO_ID = 0 ")
            End If
            sbSQLWHERE.Append(" AND BUSYO_YUKO_YMD >= '" & DateTime.Now.ToString("yyyyMMdd") & "'")

            sbSQLWHERE.Append(" AND (TAISYA_YMD >= '" & DateTime.Now.ToString("yyyyMMdd") & "' OR TAISYA_YMD = '')")

            'If Me.chkDeletedRowVisibled.Checked = False Then
            '    sbSQLWHERE.Append(" AND DEL_FLG <> 1 ")
            'End If

            sbSQL.Remove(0, sbSQL.Length)
            sbSQL.Append("SELECT")
            sbSQL.Append(" *")
            sbSQL.Append(" FROM " & NameOf(MODEL.VWM005_SYOZOKU_BUSYO) & " ")
            sbSQL.Append(sbSQLWHERE)
            sbSQL.Append(" ORDER BY SIMEI_KANA ")
            Using DBa As ClsDbUtility = DBOpen()
                dsList = DBa.GetDataSet(sbSQL.ToString, conblnNonMsg)
            End Using

            If dsList.Tables(0).Rows.Count > pub_APP_INFO.intSEARCHMAX Then
                If MessageBox.Show(My.Resources.infoSearchCountOver, "", MessageBoxButtons.YesNo, MessageBoxIcon.Information) = Windows.Forms.DialogResult.No Then
                    Return Nothing
                End If
            End If

            Dim dt As New DataTable

            Dim t As Type = GetType(MODEL.VWM005_SYOZOKU_BUSYO)
            Dim properties As Reflection.PropertyInfo() = t.GetProperties(
                 Reflection.BindingFlags.Public Or
                 Reflection.BindingFlags.NonPublic Or
                 Reflection.BindingFlags.Instance Or
                 Reflection.BindingFlags.Static)

            For Each p As Reflection.PropertyInfo In properties
                'If IsAutoGenerateField(t, p.Name) = True Then
                dt.Columns.Add(p.Name, p.PropertyType)
                'End If
            Next p

            With dsList.Tables(0)
                For Each row As DataRow In .Rows
                    Dim Trow As DataRow = dt.NewRow()
                    For Each p As Reflection.PropertyInfo In properties

                        'If IsAutoGenerateField(t, p.Name) = True Then
                        Select Case p.PropertyType
                            Case GetType(Integer)
                                Trow(p.Name) = Val(row.Item(p.Name))
                            Case GetType(Decimal)
                                Trow(p.Name) = CDec(row.Item(p.Name))
                            Case GetType(Boolean)
                                Trow(p.Name) = CBool(row.Item(p.Name))
                            Case Else
                                Select Case p.Name
                                    Case "YUKO_YMD", "BIRTH_YMD", "NYUSYA_YMD", "TAISYA_YMD", "SYOZOKU_YUKO_YMD", "BUSYO_YUKO_YMD"
                                        Trow(p.Name) = Mid(row.Item(p.Name), 1, 4) & "/" & Mid(row.Item(p.Name), 5, 2) & "/" & Mid(row.Item(p.Name), 7, 2)
                                    Case "UPD_YMDHNS", "ADD_YMDHNS"
                                        Trow(p.Name) = Mid(row.Item(p.Name), 1, 4) & "/" & Mid(row.Item(p.Name), 5, 2) & "/" & Mid(row.Item(p.Name), 7, 2) & " " & Mid(row.Item(p.Name), 9, 2) & ":" & Mid(row.Item(p.Name), 11, 2) & ":" & Mid(row.Item(p.Name), 13, 2)
                                    Case "DEL_FLG"
                                        Trow(p.Name) = CBool(row.Item(p.Name))
                                    Case "Item", "Properties"

                                    Case Else
                                        Trow(p.Name) = row.Item(p.Name)
                                End Select
                        End Select
                        'End If
                    Next p
                    dt.Rows.Add(Trow)
                Next row
                dt.AcceptChanges()
            End With

            Return dt


        Catch ex As Exception
            EM.ErrorSyori(ex, False, conblnNonMsg)
            Return Nothing
        End Try
    End Function

    Private Function FunGetListData_SYAIN() As DataTable
        Try
            Dim sbSQL As New System.Text.StringBuilder
            Dim dsList As New DataSet
            Dim sbSQLWHERE As New System.Text.StringBuilder

            ''----DBデータ取得
            sbSQLWHERE.Remove(0, sbSQLWHERE.Length)

            sbSQLWHERE.Append(" WHERE 0 = 0 ")

            If Me.mtxSIMEI.Text.Trim <> "" Then
                sbSQLWHERE.Append(" AND SIMEI like '%" & Me.mtxSIMEI.Text & "%' ")
            End If

            If Me.mtxSIMEI_KANA.Text.Trim <> "" Then
                sbSQLWHERE.Append(" AND SIMEI_KANA like '%" & Me.mtxSIMEI_KANA.Text & "%' ")
            End If

            If Me.cmbSYAIN_KB.SelectedIndex <> 0 Then
                sbSQLWHERE.Append(" AND SYAIN_KB = '" & Me.cmbSYAIN_KB.SelectedValue & "' ")
            End If

            If Me.cmbYAKUSYOKU_KB.SelectedIndex <> 0 Then
                sbSQLWHERE.Append(" AND YAKUSYOKU_KB = '" & Me.cmbSYAIN_KB.SelectedValue & "' ")
            End If

            sbSQLWHERE.Append(" AND (TAISYA_YMD >= '" & DateTime.Now.ToString("yyyyMMdd") & "' OR TAISYA_YMD = '')")
            sbSQLWHERE.Append(" AND DEL_FLG = '0' ")

            sbSQL.Remove(0, sbSQL.Length)
            sbSQL.Append("SELECT")
            sbSQL.Append(" *")
            sbSQL.Append(" FROM " & NameOf(MODEL.VWM004_SYAIN) & " ")
            sbSQL.Append(sbSQLWHERE)
            sbSQL.Append(" ORDER BY SIMEI_KANA ")
            Using DBa As ClsDbUtility = DBOpen()
                dsList = DBa.GetDataSet(sbSQL.ToString, conblnNonMsg)
            End Using

            If dsList.Tables(0).Rows.Count > pub_APP_INFO.intSEARCHMAX Then
                If MessageBox.Show(My.Resources.infoSearchCountOver, "", MessageBoxButtons.YesNo, MessageBoxIcon.Information) = Windows.Forms.DialogResult.No Then
                    Return Nothing
                End If
            End If

            Dim dt As New DataTable

            Dim t As Type = GetType(MODEL.VWM004_SYAIN)
            Dim properties As Reflection.PropertyInfo() = t.GetProperties(
                 Reflection.BindingFlags.Public Or
                 Reflection.BindingFlags.NonPublic Or
                 Reflection.BindingFlags.Instance Or
                 Reflection.BindingFlags.Static)

            For Each p As Reflection.PropertyInfo In properties
                'If IsAutoGenerateField(t, p.Name) = True Then
                dt.Columns.Add(p.Name, p.PropertyType)
                'End If
            Next p

            With dsList.Tables(0)
                For Each row As DataRow In .Rows
                    Dim Trow As DataRow = dt.NewRow()
                    For Each p As Reflection.PropertyInfo In properties

                        'If IsAutoGenerateField(t, p.Name) = True Then
                        Select Case p.PropertyType
                            Case GetType(Integer)
                                Trow(p.Name) = Val(row.Item(p.Name))
                            Case GetType(Decimal)
                                Trow(p.Name) = CDec(row.Item(p.Name))
                            Case GetType(Boolean)
                                Trow(p.Name) = CBool(row.Item(p.Name))
                            Case Else
                                Select Case p.Name
                                    Case "YUKO_YMD", "BIRTH_YMD", "NYUSYA_YMD", "TAISYA_YMD", "SYOZOKU_YUKO_YMD", "BUSYO_YUKO_YMD"
                                        Trow(p.Name) = Mid(row.Item(p.Name), 1, 4) & "/" & Mid(row.Item(p.Name), 5, 2) & "/" & Mid(row.Item(p.Name), 7, 2)
                                    Case "UPD_YMDHNS", "ADD_YMDHNS"
                                        Trow(p.Name) = Mid(row.Item(p.Name), 1, 4) & "/" & Mid(row.Item(p.Name), 5, 2) & "/" & Mid(row.Item(p.Name), 7, 2) & " " & Mid(row.Item(p.Name), 9, 2) & ":" & Mid(row.Item(p.Name), 11, 2) & ":" & Mid(row.Item(p.Name), 13, 2)
                                    Case "DEL_FLG"
                                        Trow(p.Name) = CBool(row.Item(p.Name))
                                    Case "Item", "Properties"

                                    Case Else
                                        Trow(p.Name) = row.Item(p.Name)
                                End Select
                        End Select
                        'End If
                    Next p
                    dt.Rows.Add(Trow)
                Next row
                dt.AcceptChanges()
            End With

            Return dt

        Catch ex As Exception
            EM.ErrorSyori(ex, False, conblnNonMsg)
            Return Nothing
        End Try
    End Function

    Private Function FunSRCH(ByVal flx As C1.Win.C1FlexGrid.C1FlexGrid, ByVal dt As DataTable) As Boolean
        Dim intCURROW As Integer
        Try

            '-----選択行記憶
            If flx.Rows.Count > 1 Then
                intCURROW = flx.RowSel
            End If

            flx.BeginUpdate()

            If dt IsNot Nothing Then
                flx.DataSource = dt
            End If


            Call FunSetGridCellFormat(flx)

            If flx.RowSel > 0 Then
                '-----選択行設定
                Try

                    flx.RowSel = intCURROW

                Catch dgvEx As Exception
                End Try
                Me.lblRecordCount.Text = String.Format(My.Resources.infoToolTipMsgFoundData, flx.Rows.Count - flx.Rows.Fixed.ToString)
            Else
                Me.lblRecordCount.Text = My.Resources.infoSearchResultNotFound
            End If

            Return True

        Catch ex As Exception
            EM.ErrorSyori(ex, False, conblnNonMsg)
            Return False
        Finally

            flx.EndUpdate()
        End Try
    End Function

    Private Function FunSetGridCellFormat(ByVal flx As C1.Win.C1FlexGrid.C1FlexGrid) As Boolean

        Try

            For Each r As C1.Win.C1FlexGrid.Row In flx.Rows
                If r.Index > 0 AndAlso CBool(r.Item("DEL_FLG")) = True Then
                    r.Style = flx.Styles("DeletedRow")
                End If
            Next

        Catch ex As Exception
            EM.ErrorSyori(ex, False, conblnNonMsg)
        End Try
    End Function

#End Region

#Region "追加・変更"

    ''' <summary>
    ''' レコード追加変更処理
    ''' </summary>
    ''' <param name="intMODE">処理モード</param>
    ''' <returns></returns>
    Private Function FunUpdateEntity(ByVal intKENMU_FLG As Integer) As Boolean
        'intKENMU_FLG　→　０：主務、１：兼務

        Dim sbSQL As New System.Text.StringBuilder
        Dim dsList As New DataSet
        Dim intRET As Integer

        Dim strPreDate As String

        Dim intSyain_id As Integer

        Dim frmDLG As New FrmM0050

        Try

            '登録済みのデータのチェック
            intSyain_id = flxDATA_SYAIN.Rows(flxDATA_SYAIN.RowSel).Item("SYAIN_ID")

            sbSQL.Remove(0, sbSQL.Length)
            sbSQL.Append("SELECT")
            sbSQL.Append(" *")
            sbSQL.Append(" FROM " & NameOf(MODEL.VWM005_SYOZOKU_BUSYO) & " ")
            sbSQL.Append(" WHERE ")
            sbSQL.Append("     SYAIN_ID = " & intSyain_id)
            sbSQL.Append(" AND BUSYO_ID = " & Me.cmbBUSYO_NAME.SelectedValue)
            sbSQL.Append(" AND DEL_FLG = '0'")
            sbSQL.Append(" AND SYOZOKU_YUKO_YMD = '99999999'")

            Using DB As ClsDbUtility = DBOpen()
                dsList = DB.GetDataSet(sbSQL.ToString, conblnNonMsg)

                If dsList.Tables(0).Rows.Count > 0 Then
                    Call MsgBox("既に登録されています", vbOKOnly + vbInformation, "二重登録")
                    FunUpdateEntity = False
                    Exit Function
                End If
            End Using

            '０：主務の場合のチェック
            Using DB As ClsDbUtility = DBOpen()
                Dim blnErr As Boolean
                Dim sqlEx As Exception = Nothing

                Try
                    DB.BeginTransaction()

                    If intKENMU_FLG = 0 Then

                        sbSQL.Remove(0, sbSQL.Length)
                        sbSQL.Append("SELECT")
                        sbSQL.Append(" *")
                        sbSQL.Append(" FROM " & NameOf(MODEL.VWM005_SYOZOKU_BUSYO) & " ")
                        sbSQL.Append(" WHERE ")
                        sbSQL.Append("     SYAIN_ID = " & intSyain_id)
                        sbSQL.Append(" AND KENMU_FLG = '0'")
                        sbSQL.Append(" AND SYOZOKU_YUKO_YMD = '99999999'")

                        dsList = DB.GetDataSet(sbSQL.ToString, conblnNonMsg)

                        If dsList.Tables(0).Rows.Count > 0 Then

                            If Me.radKENMU.Checked = False And radKAISI_YMD.Checked = False Then
                                Call MsgBox("主務の追加の場合は、既存主務更新パターンを選択してください", vbOKOnly + vbInformation, "二重登録")
                                blnErr = True
                                Return False
                            End If

                            If Me.radKAISI_YMD.Checked = True And dtbKAISI_YMD.ValueNonFormat.Trim = "" Then
                                Call MsgBox("主務の追加で開始日で切り替えの場合は、開始日を指定してください", vbOKOnly + vbInformation, "二重登録")
                                blnErr = True
                                Return False
                            End If

                            '既存主務を兼務に切り替える場合
                            If Me.radKENMU.Checked = True Then

                                sbSQL.Remove(0, sbSQL.Length)
                                sbSQL.Append("UPDATE " & NameOf(MODEL.M005_SYOZOKU_BUSYO) & " SET ")
                                sbSQL.Append("KENMU_FLG = '1' ")
                                sbSQL.Append("WHERE ")
                                sbSQL.Append("     SYAIN_ID = " & intSyain_id)
                                sbSQL.Append(" AND KENMU_FLG = '0' ")

                                '-----SQL実行
                                intRET = DB.ExecuteNonQuery(sbSQL.ToString, conblnNonMsg, sqlEx)

                            Else
                                '既存の主務の終了日を更新する場合

                                '開始日の前日を取得する
                                Dim dtSTART As DateTime = DateTime.Parse(dtbKAISI_YMD.Value)
                                ' 1日減算する
                                'dtSTART = dtSTART.AddDays(-1)
                                strPreDate = dtSTART.AddDays(-1).ToString("yyyyMMdd")

                                sbSQL.Remove(0, sbSQL.Length)
                                sbSQL.Append("UPDATE " & NameOf(MODEL.M005_SYOZOKU_BUSYO) & " SET ")
                                sbSQL.Append("YUKO_YMD = '" & strPreDate & "' ")
                                sbSQL.Append("WHERE ")
                                sbSQL.Append("     SYAIN_ID = " & intSyain_id)
                                sbSQL.Append(" AND KENMU_FLG = '0' ")
                                sbSQL.Append(" AND YUKO_YMD = '99999999'")
                                'sbSQL.Append(" AND YUKO_YMD = (SELECT MAX(YUKO_YMD) FROM " & NameOf(MODEL.M005_SYOZOKU_BUSYO) & "")
                                'sbSQL.Append("                 WHERE ")
                                'sbSQL.Append("                     SYAIN_ID = " & intSyain_id)
                                'sbSQL.Append(" And KENMU_FLG = '0' ")
                                'sbSQL.Append("                 AND YUKO_YMD < '" & dtSTART.ToString("yyyyMMdd") & "'")
                                'sbSQL.Append(")")
                                '-----SQL実行
                                intRET = DB.ExecuteNonQuery(sbSQL.ToString, conblnNonMsg, sqlEx)

                            End If
                        End If

                    Else
                        '１：兼務の場合

                    End If

                    '新規にレコード追加
                    sbSQL.Remove(0, sbSQL.Length)
                    sbSQL.Append("INSERT INTO " & NameOf(MODEL.M005_SYOZOKU_BUSYO) & " (")
                    sbSQL.Append(" SYAIN_ID")
                    sbSQL.Append(",BUSYO_ID")
                    sbSQL.Append(",YUKO_YMD")
                    sbSQL.Append(",KENMU_FLG")
                    sbSQL.Append(",ADD_YMDHNS")
                    sbSQL.Append(",ADD_SYAIN_ID")
                    sbSQL.Append(",UPD_YMDHNS")
                    sbSQL.Append(",UPD_SYAIN_ID")
                    sbSQL.Append(",DEL_YMDHNS")
                    sbSQL.Append(",DEL_SYAIN_ID")
                    sbSQL.Append(") VALUES (")
                    sbSQL.Append("" & intSyain_id & "")
                    sbSQL.Append("," & Me.cmbBUSYO_NAME.SelectedValue & "")
                    sbSQL.Append(",'99999999'")
                    sbSQL.Append(",'" & intKENMU_FLG & "'")
                    sbSQL.Append(",'" & DateTime.Now.ToString("yyyyMMddHHmmss") & "'")
                    sbSQL.Append(", " & pub_SYAIN_INFO.SYAIN_ID & "")
                    sbSQL.Append(",' '")
                    sbSQL.Append(",0")
                    sbSQL.Append(",' '")
                    sbSQL.Append(",0")
                    sbSQL.Append(")")

                    '-----SQL実行
                    intRET = DB.ExecuteNonQuery(sbSQL.ToString, conblnNonMsg, sqlEx)
                    If intRET <> 1 Then
                        'エラーログ
                        Dim strErrMsg As String = My.Resources.ErrLogSqlExecutionFailure & "|" & sbSQL.ToString & "|" & sqlEx.Message
                        WL.WriteLogDat(strErrMsg)
                        blnErr = True
                        Return False
                    End If

                Finally
                    DB.Commit(Not blnErr)
                End Try

            End Using

            Return True
        Catch ex As Exception
            EM.ErrorSyori(ex, False, conblnNonMsg)
            Return False
        Finally
            If frmDLG IsNot Nothing Then
                frmDLG.Dispose()
            End If
        End Try
    End Function

#End Region

#Region "削除"

    Private Function FunDEL() As Boolean
        Dim sbSQL As New System.Text.StringBuilder
        Dim strMsg As String
        Dim strTitle As String
        Dim intSyain_id As Integer
        Try

            '社員IDを取得
            If flxDATA.RowSel = 0 Then
                intSyain_id = flxDATA.Rows(1).Item("SYAIN_ID")
            Else
                intSyain_id = flxDATA.Rows(flxDATA.RowSel).Item("SYAIN_ID")
            End If


            Using DB As ClsDbUtility = DBOpen()
                Dim blnErr As Boolean
                Dim intRET As Integer
                Dim sqlEx As Exception = Nothing

                Try
                    DB.BeginTransaction()
                    '削除処理
                    '-----SQL
                    sbSQL.Remove(0, sbSQL.Length)
                    sbSQL.Append(" DELETE FROM " & NameOf(MODEL.M005_SYOZOKU_BUSYO) & " ")
                    sbSQL.Append(" WHERE ")
                    sbSQL.Append("     SYAIN_ID = " & intSyain_id & " ")
                    sbSQL.Append(" AND BUSYO_ID = " & Me.cmbBUSYO_NAME.SelectedValue & " ")

                    '-----SQL実行
                    intRET = DB.ExecuteNonQuery(sbSQL.ToString, conblnNonMsg, sqlEx)
                    If intRET <> 1 Then
                        'エラーログ
                        Dim strErrMsg As String = My.Resources.ErrLogSqlExecutionFailure & "|" & sbSQL.ToString & "|" & sqlEx.Message
                        WL.WriteLogDat(strErrMsg)
                        blnErr = True
                        Return False
                    End If

                    '削除されたデータが主務の場合で有効期限が９９９９９９９９のレコードが存在しない場合、
                    '主務の最大の有効期限を９９９９９９９９で更新する
                    '-----SQL
                    sbSQL.Remove(0, sbSQL.Length)
                    sbSQL.Append("UPDATE " & NameOf(MODEL.M005_SYOZOKU_BUSYO) & " ")
                    sbSQL.Append("SET YUKO_YMD = '99999999' ")
                    sbSQL.Append("WHERE ")
                    sbSQL.Append("     SYAIN_ID = '" & intSyain_id & "' ")
                    sbSQL.Append(" AND KENMU_FLG = '0' ")
                    sbSQL.Append(" AND YUKO_YMD = isnull((SELECT MAX(YUKO_YMD) FROM " & NameOf(MODEL.M005_SYOZOKU_BUSYO) & "")
                    sbSQL.Append("                 WHERE ")
                    sbSQL.Append("                     SYAIN_ID = " & intSyain_id)
                    sbSQL.Append("                 AND KENMU_FLG = '0' ")
                    sbSQL.Append("),' ')")

                    intRET = DB.ExecuteNonQuery(sbSQL.ToString, conblnNonMsg, sqlEx)

                    If intRET = 0 Then

                    End If

                Finally
                    DB.Commit(Not blnErr)
                End Try

            End Using

            Return True
        Catch ex As Exception
            EM.ErrorSyori(ex, False, conblnNonMsg)
            Return False
        End Try
    End Function

#End Region

#Region "FuncButton有効無効切替"

    ''' <summary>
    ''' 使用しないボタンのキャプションをなくす、かつ非活性にする。
    ''' ファンクションキーを示す(F**)以外の文字がない場合は、未使用とみなす
    ''' </summary>
    ''' <param name="frm">対象フォーム</param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Private Function SubInitFuncButtonEnabled() As Boolean

        For intFunc As Integer = 1 To 12
            With Me.Controls("cmdFunc" & intFunc)
                If .Text.Length = 0 OrElse .Text.Substring(0, .Text.IndexOf("(")).IsNullOrWhiteSpace Then
                    .Text = ""
                    .Visible = False
                End If
            End With
        Next intFunc

        If flxDATA_SYAIN.RowSel > 0 Then
            cmdFunc2.Enabled = True
            cmdFunc3.Enabled = True
        Else
            cmdFunc2.Enabled = False
            cmdFunc3.Enabled = False
        End If

        If flxDATA.RowSel > 0 Then
            cmdFunc5.Visible = True
        Else
            cmdFunc5.Visible = False
        End If

    End Function

#End Region

#End Region

#Region "コントロールイベント"

    '検索フィルタ変更
    Private Sub SearchFilterValueChanged(sender As System.Object, e As System.EventArgs)
        '検索
        'Me.cmdFunc1.PerformClick()
        Call FunSRCH(Me.flxDATA, FunGetListData())

    End Sub

    Private Sub cmbBUSYO_KB_TextChanged(sender As Object, e As EventArgs) Handles cmbBUSYO_KB.TextChanged
        Dim dsList As New DataSet
        Dim sbSQL As New System.Text.StringBuilder
        'Dim intMaxOrder As Integer

        Try

            If cmbBUSYO_KB.SelectedIndex <> 0 Then

                'Me.cmbOYA_BUSYO.DataSource = Nothing

                Using DB As ClsDbUtility = DBOpen()
                    Call FunGetCodeDataTable(DB, "部署", tblBUSYO, " BUSYO_KB = '" & cmbBUSYO_KB.SelectedValue & "' AND YUKO_YMD >= '" & Replace(Now.ToShortDateString, "/", "") & "'")
                End Using

                Me.cmbBUSYO_NAME.SetDataSource(tblBUSYO, ENM_COMBO_SELECT_VALUE_TYPE._2_Option)

            End If

        Catch ex As Exception
            EM.ErrorSyori(ex, False, conblnNonMsg)
        Finally
            dsList.Dispose()
        End Try
    End Sub


#End Region

End Class