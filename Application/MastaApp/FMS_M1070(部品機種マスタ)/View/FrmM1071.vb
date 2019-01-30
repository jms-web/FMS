Imports JMS_COMMON.ClsPubMethod

''' <summary>
''' 機種マスタ編集画面
''' </summary>
Public Class FrmM1071

#Region "変数・定数"
    Private IsValidated As Boolean
    Private _VWM107 As New MODEL.VWM107_BUHIN_KISYU
#End Region

#Region "プロパティ"
    ''' <summary>
    ''' 処理モード
    ''' </summary>
    Public Property PrDATA_OP_MODE As Integer

    ''' <summary>
    ''' 新規追加レコードのキー
    ''' </summary>
    Public Property PrPKeys As Integer

    ''' <summary>
    ''' 一覧の選択行データ
    ''' </summary>
    Public Property PrDataRow As DataRow

#End Region

#Region "コンストラクタ"

    ''' <summary>
    ''' コンストラクタ
    ''' </summary>
    ''' <remarks>コンストラクタ</remarks>
    Public Sub New()

        ' この呼び出しはデザイナーで必要です。
        InitializeComponent()

        Me.Height = 560
        Me.FormBorderStyle = Windows.Forms.FormBorderStyle.FixedDialog
        Me.MaximizeBox = False
        Me.MinimizeBox = False

    End Sub

#End Region

#Region "FORMイベント"
    Private Sub Frm_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        Try
            '-----フォーム共通設定
            Call FunFormCommonSetting(pub_APP_INFO, pub_SYAIN_INFO)
            Using DB As ClsDbUtility = DBOpen()
                lblTytle.Text = FunGetCodeMastaValue(DB, "PG_TITLE", Me.GetType.ToString)
            End Using

            '-----位置・サイズ

            Me.Top = Me.Owner.Top + (Me.Owner.Height - Me.Height) - 26 ' / 2
            Me.Left = Me.Owner.Left + (Me.Owner.Width - Me.Width) / 2

            '-----コントロールデータソース設定
            'cmbBUMON_KB.SetDataSource(tblBUMON.ExcludeDeleted, ENM_COMBO_SELECT_VALUE_TYPE._0_Required)
            '-----グリッド初期設定
            Call FunInitializeFlexGrid(flxDATA)

            Call FunSetBinding()

            '-----処理モード別画面初期化
            Call FunInitializeControls()

        Catch ex As Exception
            EM.ErrorSyori(ex, False, conblnNonMsg)
        Finally
            Call FunInitFuncButtonEnabled()
        End Try
    End Sub

#End Region

#Region "FUNCTIONボタンCLICK"

#Region "ボタンクリックイベント"
    Private Sub CmdFunc_Click(ByVal sender As Object, ByVal e As EventArgs) Handles cmdFunc1.Click, cmdFunc2.Click, cmdFunc3.Click, cmdFunc4.Click, cmdFunc5.Click, cmdFunc6.Click, cmdFunc7.Click, cmdFunc8.Click, cmdFunc9.Click, cmdFunc10.Click, cmdFunc11.Click, cmdFunc12.Click
        Dim intFUNC As Integer
        Dim intCNT As Integer

        Try
            'ボタン不可/ボタンINDEX取得
            For intCNT = 0 To Me.cmdFunc.Length - 1
                Me.cmdFunc(intCNT).Enabled = False
                If cmdFunc(intCNT) Is sender Then intFUNC = intCNT + 1
            Next

            'ボタンINDEX毎の処理
            Select Case intFUNC
                Case 1  '追加
                    If FunSAVE() Then
                        'プロパティに対象レコードのキーを設定
                        Me.PrPKeys = _VWM107.KISYU_ID

                        Me.DialogResult = Windows.Forms.DialogResult.OK
                        Me.Close()
                    End If

                Case 12 '戻る
                    Me.DialogResult = Windows.Forms.DialogResult.Cancel
                    Me.Close()
            End Select

        Catch ex As Exception
            EM.ErrorSyori(ex)
        Finally
            'ボタン可
            System.Windows.Forms.Application.DoEvents()
            For intCNT = 0 To Me.cmdFunc.Length - 1
                Me.cmdFunc(intCNT).Enabled = True
            Next
        End Try
    End Sub

#End Region

#Region "更新"

    Private Function FunSAVE() As Boolean
        Dim sbSQL As New System.Text.StringBuilder
        Dim intRET As Integer
        Dim sqlEx As New Exception
        Dim strSysDate As String
        Dim dsList As New DataSet
        Try

            '入力チェック
            'If FunCheckInput() = False Then Return False

            Using DB As ClsDbUtility = DBOpen()
                Dim blnErr As Boolean
                Try
                    DB.BeginTransaction()

                    strSysDate = DB.GetSysDateString()

                    Dim ModelInfo As New MODEL.ModelInfo(Of MODEL.M107_BUHIN_KISYU)(_OnlyAutoGenerateField:=True)

                    sbSQL.Remove(0, sbSQL.Length)
                    sbSQL.Append("SELECT * FROM " & ModelInfo.Name & " ")
                    sbSQL.Append(" WHERE ")
                    sbSQL.Append("     BUMON_KB    = '" & _VWM107.BUMON_KB & "'")
                    sbSQL.Append(" AND TOKUI_ID    =  " & _VWM107.TOKUI_ID & " ")
                    sbSQL.Append(" AND BUHIN_BANGO = '" & _VWM107.BUHIN_BANGO.Trim & "'")
                    sbSQL.Append(" AND KISYU_ID    =  " & Me.flxDATA.Rows(Me.flxDATA.RowSel).Item("KISYU_ID") & " ")

                    dsList = DB.GetDataSet(sbSQL.ToString, conblnNonMsg)

                    If dsList.Tables(0).Rows.Count > 0 Then
                        Call MsgBox("既に追加されている機種です。別の機種を選択してください。", vbExclamation + vbOKOnly, "重複登録")
                        Return False
                    End If

                    sbSQL.Remove(0, sbSQL.Length)
                    sbSQL.Append("INSERT INTO " & ModelInfo.Name & "(")
                    sbSQL.Append(" BUMON_KB")
                    sbSQL.Append(",TOKUI_ID")
                    sbSQL.Append(",BUHIN_BANGO")
                    sbSQL.Append(",KISYU_ID")
                    sbSQL.Append(",ADD_YMDHNS")
                    sbSQL.Append(",ADD_SYAIN_ID")
                    sbSQL.Append(",UPD_YMDHNS")
                    sbSQL.Append(",UPD_SYAIN_ID")
                    sbSQL.Append(",DEL_YMDHNS")
                    sbSQL.Append(",DEL_SYAIN_ID")
                    sbSQL.Append(") VALUES (")
                    sbSQL.Append(" '" & _VWM107.BUMON_KB & "'")
                    sbSQL.Append(", " & _VWM107.TOKUI_ID & " ")
                    sbSQL.Append(",'" & _VWM107.BUHIN_BANGO.Trim & "'")
                    sbSQL.Append(", " & Me.flxDATA.Rows(Me.flxDATA.RowSel).Item("KISYU_ID") & " ")
                    sbSQL.Append(",'" & strSysDate & "'")
                    sbSQL.Append(", " & pub_SYAIN_INFO.SYAIN_ID & " ")
                    sbSQL.Append(",' '")
                    sbSQL.Append(", " & 0 & " ")
                    sbSQL.Append(",' '")
                    sbSQL.Append(", " & 0 & " ")
                    sbSQL.Append(")")

                    intRET = DB.ExecuteNonQuery(sbSQL.ToString, conblnNonMsg, sqlEx)

                    If intRET <> 1 Then
                        Dim strErrMsg As String = $"{My.Resources.ErrLogSqlExecutionFailure}{sbSQL.ToString}|{sqlEx.Message}"
                        WL.WriteLogDat(strErrMsg)
                        blnErr = True
                        Return False
                    End If

                    blnErr = False

                    Return True

                Finally
                    DB.Commit(Not blnErr)
                End Try
            End Using

            Return True
        Catch ex As Exception
            EM.ErrorSyori(ex, False, conblnNonMsg)
            Return False
        Finally

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
    Public Function FunInitFuncButtonEnabled() As Boolean

        Try
            For intFunc As Integer = 1 To 12
                With Me.Controls("cmdFunc" & intFunc)
                    If .Text.Length = 0 OrElse .Text.Substring(0, .Text.IndexOf("(")).IsNulOrWS Then
                        .Text = ""
                        .Visible = False
                    End If
                End With
            Next intFunc

            Return True
        Catch ex As Exception
            EM.ErrorSyori(ex, False, conblnNonMsg)
            Return False
        End Try
    End Function
#End Region

#End Region

#Region "コントロールイベント"

#End Region

#Region "ローカル関数"

#Region "バインディング"
    Private Function FunSetBinding() As Boolean
        mtxBumon_KB.DataBindings.Add(New Binding(NameOf(mtxBumon_KB.Text), _VWM107, NameOf(_VWM107.BUMON_KB_DISP), False, DataSourceUpdateMode.OnPropertyChanged, ""))
        mtxTORI_NAME.DataBindings.Add(New Binding(NameOf(mtxTORI_NAME.Text), _VWM107, NameOf(_VWM107.TORI_NAME), False, DataSourceUpdateMode.OnPropertyChanged, ""))
        mtxBUHIN_BANGO.DataBindings.Add(New Binding(NameOf(mtxBUHIN_BANGO.Text), _VWM107, NameOf(_VWM107.BUHIN_BANGO), False, DataSourceUpdateMode.OnPropertyChanged, ""))
        mtxBUHIN_NAME.DataBindings.Add(New Binding(NameOf(mtxBUHIN_NAME.Text), _VWM107, NameOf(_VWM107.BUHIN_NAME), False, DataSourceUpdateMode.OnPropertyChanged, ""))

    End Function

#End Region

#Region "処理モード別画面初期化"
    Private Function FunInitializeControls() As Boolean
        Dim _Model = New MODEL.ModelInfo(Of MODEL.VWM107_BUHIN_KISYU)(_OnlyAutoGenerateField:=True)

        Try
            Select Case PrDATA_OP_MODE
                Case ENM_DATA_OPERATION_MODE._1_ADD
                    lblTytle.Text &= "（追加）"
                    cmdFunc1.Text = "追加(F1)"

                    _Model.Properties.ForEach(Sub(p)
                                                  Select Case p.PropertyType
                                                      Case GetType(Boolean)
                                                          _VWM107(p.Name) = CBool(PrDataRow.Item(p.Name))
                                                      Case Else
                                                          _VWM107(p.Name) = PrDataRow.Item(p.Name)
                                                  End Select
                                              End Sub)

                    lbllblEDIT_YMDHNS.Visible = False
                    lblEDIT_YMDHNS.Visible = False
                    lbllblEDIT_SYAIN_ID.Visible = False
                    lblEDIT_SYAIN_ID.Visible = False

                Case ENM_DATA_OPERATION_MODE._2_ADDREF


                    'lblTytle.Text &= "（類似追加）"
                    'cmdFunc1.Text = "追加(F1)"

                    'mtxKISYU_ID.Text = "<新規>"
                    'mtxKISYU_ID.ReadOnly = True

                    'lbllblEDIT_YMDHNS.Visible = False
                    'lblEDIT_YMDHNS.Visible = False
                    'lbllblEDIT_SYAIN_ID.Visible = False
                    'lblEDIT_SYAIN_ID.Visible = False

                Case ENM_DATA_OPERATION_MODE._3_UPDATE
                    '_Model.Properties.ForEach(Sub(p)
                    '                              Select Case p.PropertyType
                    '                                  Case GetType(Boolean)
                    '                                      _M105(p.Name) = CBool(PrDataRow.Item(p.Name))
                    '                                  Case Else
                    '                                      _M105(p.Name) = PrDataRow.Item(p.Name)
                    '                              End Select
                    '                          End Sub)

                    'lblTytle.Text &= "（変更）"
                    'Me.cmdFunc1.Text = "変更(F1)"

                    ''mtxKISYU_ID.ReadOnly = True

                    'lbllblEDIT_YMDHNS.Visible = True
                    'lblEDIT_YMDHNS.Visible = True
                    'lbllblEDIT_SYAIN_ID.Visible = True
                    'lblEDIT_SYAIN_ID.Visible = True

                    ''更新日時
                    'lblEDIT_YMDHNS.Text = DateTime.ParseExact(PrDataRow.Item(NameOf(_M105.UPD_YMDHNS)), "yyyyMMddHHmmss", Nothing).ToString("yyyy/MM/dd HH:mm:ss")
                    ''更新担当者CD
                    'lblEDIT_SYAIN_ID.Text = PrDataRow.Item(NameOf(_M105.UPD_SYAIN_ID)) & " " & Fun_GetUSER_NAME(PrDataRow.Item(NameOf(_M105.UPD_SYAIN_ID)))

                Case Else
                    Throw New ArgumentException(My.Resources.ErrMsgException, PrDATA_OP_MODE.ToString)
            End Select

            Return True

        Catch ex As Exception
            EM.ErrorSyori(ex, False, conblnNonMsg)
            Return False
        End Try
    End Function

#End Region

#Region "入力チェック"
    Public Function FunCheckInput() As Boolean

        Try
            IsValidated = True

            Return IsValidated
        Catch ex As Exception
            EM.ErrorSyori(ex, False, conblnNonMsg)
            Return False
        End Try
    End Function

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
            .Styles("DeletedRow").BackColor = Color.FromArgb(200, 200, 200)
            .Styles("DeletedRow").ForeColor = Color.FromArgb(74, 74, 74)

            .VisualStyle = C1.Win.C1FlexGrid.VisualStyle.Office2010Silver 'Custom

            '以下を適用するにはVisualStyleをCustomにする
            .Styles.Alternate.BackColor = Color.White
            .Styles.Normal.BackColor = Color.Bisque
            .Styles.Focus.BackColor = Color.Cyan
        End With
    End Function


#End Region

    Private Function FunGetNextIdentity() As Integer

        Dim dsList As New System.Data.DataSet
        Try
            Dim intRET As Integer
            Dim sbSQL As New System.Text.StringBuilder

            sbSQL.Remove(0, sbSQL.Length)
            sbSQL.Append($"SELECT MAX(KISYU_ID) FROM {NameOf(MODEL.M105_KISYU)}")
            Using DB As ClsDbUtility = DBOpen()
                dsList = DB.GetDataSet(sbSQL.ToString, conblnNonMsg)
            End Using

            intRET = Val(dsList.Tables(0).Rows(0).Item(0)) + 1

            Return intRET
        Catch ex As Exception
            EM.ErrorSyori(ex, False, conblnNonMsg)
            Return -1
        Finally
            dsList.Dispose()
        End Try
    End Function


    Private Sub btnSRCH_Click(sender As Object, e As EventArgs) Handles btnSRCH.Click
        Call FunSRCH(Me.flxDATA, FunGetListData())
    End Sub


    Private Function FunSRCH(flx As C1.Win.C1FlexGrid.C1FlexGrid, dt As DataTable) As Boolean
        Dim intCURROW As Integer
        Try

            '-----選択行記憶
            If flx.Rows.Count > 0 Then
                intCURROW = flx.RowSel
            End If

            flx.BeginUpdate()
            flx.DataSource = dt

            'Call FunSetGridCellFormat(flx)

            If flx.Rows.Count > 0 Then
                '-----選択行設定
                Try
                    flx.RowSel = intCURROW
                Catch dgvEx As Exception
                End Try
                'lblRecordCount.Text = String.Format(My.Resources.infoToolTipMsgFoundData, flx.Rows.Count - flx.Rows.Fixed.ToString)
            Else
                'lblRecordCount.Text = My.Resources.infoSearchResultNotFound
            End If

            Return True

        Catch ex As Exception
            EM.ErrorSyori(ex, False, conblnNonMsg)
            Return False
        Finally
            flx.EndUpdate()
        End Try
    End Function

    Private Function FunGetListData() As DataTable
        Try
            Dim sbSQL As New System.Text.StringBuilder
            Dim dsList As New DataSet
            Dim sbSQLWHERE As New System.Text.StringBuilder

            sbSQLWHERE.Append(" WHERE  DEL_FLG = 0 ")
            sbSQLWHERE.Append(" AND BUMON_KB ='" & _VWM107.BUMON_KB & "'")
            If Not mtxKISYU_NAME.Text.IsNulOrWS Then sbSQLWHERE.Append(" AND " & $"KISYU_NAME LIKE '%{mtxKISYU_NAME.Text.Trim}%'")

            sbSQL.Append($"SELECT")
            sbSQL.Append($" * ")
            sbSQL.Append($" FROM {NameOf(MODEL.VWM105_KISYU)} ")
            sbSQL.Append(sbSQLWHERE)
            sbSQL.Append($" ORDER BY KISYU_NAME ")
            Using DB As ClsDbUtility = DBOpen()
                dsList = DB.GetDataSet(sbSQL.ToString, conblnNonMsg)
            End Using

            If dsList.Tables(0).Rows.Count > pub_APP_INFO.intSEARCHMAX Then
                If MessageBox.Show(My.Resources.infoSearchCountOver, "", MessageBoxButtons.YesNo, MessageBoxIcon.Information) = Windows.Forms.DialogResult.No Then
                    Return Nothing
                End If
            End If

            Dim _Model As New MODEL.ModelInfo(Of MODEL.VWM105_KISYU)(srcDATA:=dsList.Tables(0))
            Return _Model.Data

        Catch ex As Exception
            EM.ErrorSyori(ex, False, conblnNonMsg)
            Return Nothing
        End Try
    End Function




#End Region



End Class
