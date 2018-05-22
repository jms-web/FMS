Imports JMS_COMMON.ClsPubMethod


Public Class FrmG0012

#Region "プロパティ"
    ''' <summary>
    ''' 一覧の選択行データ
    ''' </summary>
    Public Property PrDataRow As DataRow

    '現在のステージ 承認順
    Public Property PrCurrentStage As Integer

    '報告書No
    Public Property PrHOKOKU_NO As String
#End Region

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
            lblTytle.Text = "不適合是正処置報告書（Corrective Action Report）"
            Me.Text = lblTytle.Text
            '-----グリッド初期設定(親フォームから呼び出し)
            'Call FunInitializeDataGridView(Me.dgvDATA)

            '-----グリッド列作成
            'Call FunSetDgvCulumns(Me.dgvDATA)

            '-----コントロールデータソース設定
            cmbKONPON_YOIN_KB1.SetDataSource(tblKONPON_YOIN_KB, ENM_COMBO_SELECT_VALUE_TYPE._2_Option)
            cmbKONPON_YOIN_KB2.SetDataSource(tblKONPON_YOIN_KB, ENM_COMBO_SELECT_VALUE_TYPE._2_Option)

            '検索実行
            FunInitializeControls()


        Finally
            FunInitFuncButtonEnabled(Me)
        End Try
    End Sub

#End Region

#Region "DataGridView関連"

    'フィールド定義()
    Private Shared Function FunSetDgvCulumns(ByVal dgv As DataGridView) As Boolean
        Dim _Model As New MODEL.M001_SETTING
        Try
            With dgv
                .AutoGenerateColumns = False

                '.Columns.Add(NameOf(_Model.KOMO_NM), GetDisplayName(_Model.GetType, NameOf(_Model.KOMO_NM)))
                '.Columns(.ColumnCount - 1).Width = 150
                '.Columns(.ColumnCount - 1).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
                '.Columns(.ColumnCount - 1).DataPropertyName = NameOf(_Model.KOMO_NM)

                '.Columns.Add(NameOf(_Model.VALUE), GetDisplayName(_Model.GetType, NameOf(_Model.VALUE)))
                '.Columns(.ColumnCount - 1).Width = 200
                '.Columns(.ColumnCount - 1).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
                '.Columns(.ColumnCount - 1).Frozen = True
                '.Columns(.ColumnCount - 1).DataPropertyName = NameOf(_Model.VALUE)

                '.Columns.Add(NameOf(_Model.DISP), GetDisplayName(_Model.GetType, NameOf(_Model.DISP)))
                '.Columns(.ColumnCount - 1).Width = 300
                '.Columns(.ColumnCount - 1).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
                '.Columns(.ColumnCount - 1).DataPropertyName = NameOf(_Model.DISP)

                '.Columns.Add(NameOf(_Model.DISP_ORDER), GetDisplayName(_Model.GetType, NameOf(_Model.DISP_ORDER)))
                '.Columns(.ColumnCount - 1).Width = 70
                '.Columns(.ColumnCount - 1).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                '.Columns(.ColumnCount - 1).DataPropertyName = NameOf(_Model.DISP_ORDER)

                '.Columns.Add(NameOf(_Model.BIKOU), GetDisplayName(_Model.GetType, NameOf(_Model.BIKOU)))
                '.Columns(.ColumnCount - 1).Width = 430
                '.Columns(.ColumnCount - 1).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
                '.Columns(.ColumnCount - 1).DataPropertyName = NameOf(_Model.BIKOU)

                'Using cmbclmn1 As New DataGridViewCheckBoxColumn
                '    cmbclmn1.Name = NameOf(_Model.DEF_FLG)
                '    cmbclmn1.HeaderText = GetDisplayName(_Model.GetType, NameOf(_Model.DEF_FLG))
                '    cmbclmn1.Width = 30

                '    cmbclmn1.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
                '    .Columns.Add(cmbclmn1)
                '    .Columns(.ColumnCount - 1).SortMode = DataGridViewColumnSortMode.Automatic
                '    .Columns(.ColumnCount - 1).DataPropertyName = NameOf(_Model.DEF_FLG)
                'End Using

                'Using cmbclmn2 As New DataGridViewCheckBoxColumn
                '    cmbclmn2.Name = NameOf(_Model.DEL_FLG)
                '    cmbclmn2.HeaderText = GetDisplayName(_Model.GetType, NameOf(_Model.DEL_FLG))
                '    cmbclmn2.Width = 30
                '    cmbclmn2.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
                '    .Columns.Add(cmbclmn2)
                '    .Columns(.ColumnCount - 1).SortMode = DataGridViewColumnSortMode.Automatic
                '    .Columns(.ColumnCount - 1).DataPropertyName = NameOf(_Model.DEL_FLG)
                'End Using

                '.Columns.Add(NameOf(_Model.ADD_YMDHNS), GetDisplayName(_Model.GetType, NameOf(_Model.ADD_YMDHNS)))
                '.Columns(.ColumnCount - 1).DataPropertyName = NameOf(_Model.ADD_YMDHNS)
                '.Columns(.ColumnCount - 1).Visible = False

                '.Columns.Add(NameOf(_Model.ADD_TANTO_CD), GetDisplayName(_Model.GetType, NameOf(_Model.ADD_TANTO_CD)))
                '.Columns(.ColumnCount - 1).DataPropertyName = NameOf(_Model.ADD_TANTO_CD)
                '.Columns(.ColumnCount - 1).Visible = False

                '.Columns.Add(NameOf(_Model.ADD_TANTO_NAME), GetDisplayName(_Model.GetType, NameOf(_Model.ADD_TANTO_NAME)))
                '.Columns(.ColumnCount - 1).DataPropertyName = NameOf(_Model.ADD_TANTO_NAME)
                '.Columns(.ColumnCount - 1).Visible = False

                '.Columns.Add(NameOf(_Model.EDIT_YMDHNS), GetDisplayName(_Model.GetType, NameOf(_Model.EDIT_YMDHNS)))
                '.Columns(.ColumnCount - 1).DataPropertyName = NameOf(_Model.EDIT_YMDHNS)
                '.Columns(.ColumnCount - 1).Visible = False

                '.Columns.Add(NameOf(_Model.EDIT_TANTO_CD), GetDisplayName(_Model.GetType, NameOf(_Model.EDIT_TANTO_CD)))
                '.Columns(.ColumnCount - 1).DataPropertyName = NameOf(_Model.EDIT_TANTO_CD)
                '.Columns(.ColumnCount - 1).Visible = False

                '.Columns.Add(NameOf(_Model.EDIT_TANTO_NAME), GetDisplayName(_Model.GetType, NameOf(_Model.EDIT_TANTO_NAME)))
                '.Columns(.ColumnCount - 1).DataPropertyName = NameOf(_Model.EDIT_TANTO_NAME)
                '.Columns(.ColumnCount - 1).Visible = False

                '.Columns.Add(NameOf(_Model.DEL_YMDHNS), GetDisplayName(_Model.GetType, NameOf(_Model.DEL_YMDHNS)))
                '.Columns(.ColumnCount - 1).DataPropertyName = NameOf(_Model.DEL_YMDHNS)
                '.Columns(.ColumnCount - 1).Visible = False

                '.Columns.Add(NameOf(_Model.DEL_YMDHNS), GetDisplayName(_Model.GetType, NameOf(_Model.DEL_YMDHNS)))
                '.Columns(.ColumnCount - 1).DataPropertyName = NameOf(_Model.DEL_YMDHNS)
                '.Columns(.ColumnCount - 1).Visible = False

                '.Columns.Add(NameOf(_Model.DEL_TANTO_NAME), GetDisplayName(_Model.GetType, NameOf(_Model.DEL_TANTO_NAME)))
                '.Columns(.ColumnCount - 1).DataPropertyName = NameOf(_Model.DEL_TANTO_NAME)
                '.Columns(.ColumnCount - 1).Visible = False
            End With

            Return True
        Finally

        End Try
    End Function

    'グリッドセル(行)ダブルクリック時イベント
    Private Sub DgvDATA_CellDoubleClick(sender As System.Object, e As DataGridViewCellEventArgs)
        Try
            'ヘッダ以外のセルダブルクリック時
            If e.RowIndex >= 0 Then
                '該当行の変更処理を実行する
                Me.cmdFunc4.PerformClick()
            End If
        Catch ex As Exception
            EM.ErrorSyori(ex, False, conblnNonMsg)
        End Try
    End Sub

    '行選択時イベント
    Private Overloads Sub DgvDATA_SelectionChanged(sender As System.Object, e As System.EventArgs)
        Try
        Finally
            'Call FunInitFuncButtonEnabled(Me)
        End Try
    End Sub

#End Region

#Region "FunctionButton関連"

#Region "ボタンクリックイベント"

    Private Sub CmdFunc_Click(ByVal sender As Object, ByVal e As EventArgs) Handles cmdFunc1.Click, cmdFunc2.Click, cmdFunc3.Click, cmdFunc4.Click, cmdFunc5.Click, cmdFunc6.Click, cmdFunc7.Click, cmdFunc8.Click, cmdFunc9.Click, cmdFunc10.Click, cmdFunc11.Click, cmdFunc12.Click
        Dim intFUNC As Integer
        Dim intCNT As Integer

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
                'Case 1  '検索
                '    'Call FunSRCH(Me.dgvDATA, FunGetListData())
                'Case 2  '追加

                '    'If FunUpdateEntity(ENM_DATA_OPERATION_MODE._1_ADD) = True Then
                '    '    'Call FunSRCH(Me.dgvDATA, FunGetListData())
                '    'End If
                'Case 3  '参照追加

                '    'If FunUpdateEntity(ENM_DATA_OPERATION_MODE._2_ADDREF) = True Then
                '    '    'Call FunSRCH(Me.dgvDATA, FunGetListData())
                '    'End If
                'Case 4  '変更

                '    'If FunUpdateEntity(ENM_DATA_OPERATION_MODE._3_UPDATE) = True Then
                '    '    'Call FunSRCH(Me.dgvDATA, FunGetListData())
                '    'End If
                'Case 5, 6  '削除/復元/完全削除

                '    'Dim btn As Button = DirectCast(sender, Button)
                '    'Dim ENM_MODE As ENM_DATA_OPERATION_MODE = DirectCast(btn.Tag, ENM_DATA_OPERATION_MODE)
                '    'If FunDEL(ENM_MODE) = True Then
                '    '    'Call FunSRCH(Me.dgvDATA, FunGetListData())
                '    'End If

                'Case 10  'CSV出力

                '    Dim strFileName As String = pub_APP_INFO.strTitle & "_" & DateTime.Today.ToString("yyyyMMdd") & ".CSV"
                '    'Call FunCSV_OUT(Me.dgvDATA.DataSource, strFileName, pub_APP_INFO.strOUTPUT_PATH)


                Case 12 '閉じる
                    Me.Close()
                Case Else
                    MessageBox.Show("未実装", "", MessageBoxButtons.OK, MessageBoxIcon.Information)
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
            'Call FunInitFuncButtonEnabled(Me)

            '[アクティブ]
            Me.PrPG_STATUS = ENM_PG_STATUS._2_ACTIVE
        End Try

    End Sub

#End Region


#Region "印刷"
    Private Function FunOpenReportNCR() As Boolean
        Dim strOutputFileName As String
        Dim strTEMPFILE As String
        'Dim intRET As Integer

        Try

            'ファイル名
            strOutputFileName = "CAR_" & _D003_NCR_J.HOKOKU_NO & "_Work.xlsx"

            '既存ファイル削除
            If FunDELETE_FILE(pub_APP_INFO.strOUTPUT_PATH & strOutputFileName) = False Then
                Return False
            End If

            Using iniIF As New IniFile(FunGetRootPath() & "\INI\" & CON_TEMPLATE_INI)
                strTEMPFILE = FunConvRootPath(iniIF.GetIniString("CAR", "FILEPATH"))
            End Using

            'エクセル出力ファイル用意
            If OUT_EXCEL_READY(strTEMPFILE, pub_APP_INFO.strOUTPUT_PATH, strOutputFileName) = False Then
                Return False
            End If
            '-----書込処理
            If FunMakeReportCAR(pub_APP_INFO.strOUTPUT_PATH & strOutputFileName, _D003_NCR_J.HOKOKU_NO) = False Then
                Return False
            End If

            'Excel起動
            'Return FunOpenExcelApp(pub_APP_INFO.strOUTPUT_PATH & strOutputFileName)

        Catch ex As Exception
            EM.ErrorSyori(ex, False, conblnNonMsg)
            Return False
        Finally

        End Try
    End Function

    Private Function FunMakeReportCAR(ByVal strFilePath As String, ByVal strHOKOKU_NO As String) As Boolean

        Dim spWorkbook As SpreadsheetGear.IWorkbook
        Dim spWorksheets As SpreadsheetGear.IWorksheets
        Dim spSheet1 As SpreadsheetGear.IWorksheet
        Dim spRangeFrom As SpreadsheetGear.IRange
        Dim spRangeTo As SpreadsheetGear.IRange

        Try
            spWorkbook = SpreadsheetGear.Factory.GetWorkbook(strFilePath, System.Globalization.CultureInfo.CurrentCulture)

            spWorkbook.WorkbookSet.GetLock()
            spWorksheets = spWorkbook.Worksheets
            spSheet1 = spWorksheets.Item(0) 'sheet1

            Dim spprint As SpreadsheetGear.Printing.PrintWhat = SpreadsheetGear.Printing.PrintWhat.Sheet


            'レコードフレーム初期化

            Dim _V005_CAR_J As MODEL.V005_CAR_J = FunGetV005Model(strHOKOKU_NO)

            spSheet1.Range(NameOf(_V005_CAR_J.GOKI)).Value = _V005_CAR_J.GOKI
            spSheet1.Range(NameOf(_V005_CAR_J.HOKOKU_NO)).Value = _V005_CAR_J.HOKOKU_NO
            spSheet1.Range(NameOf(_V005_CAR_J.KAITO_1)).Value = _V005_CAR_J.KAITO_1
            spSheet1.Range(NameOf(_V005_CAR_J.KAITO_2)).Value = _V005_CAR_J.KAITO_2
            spSheet1.Range(NameOf(_V005_CAR_J.KAITO_3)).Value = _V005_CAR_J.KAITO_3
            spSheet1.Range(NameOf(_V005_CAR_J.KAITO_4)).Value = _V005_CAR_J.KAITO_4
            spSheet1.Range(NameOf(_V005_CAR_J.KAITO_5)).Value = _V005_CAR_J.KAITO_5
            spSheet1.Range(NameOf(_V005_CAR_J.KAITO_6)).Value = _V005_CAR_J.KAITO_6
            spSheet1.Range(NameOf(_V005_CAR_J.KAITO_7)).Value = _V005_CAR_J.KAITO_7
            spSheet1.Range(NameOf(_V005_CAR_J.KAITO_8)).Value = _V005_CAR_J.KAITO_8
            spSheet1.Range(NameOf(_V005_CAR_J.KAITO_9)).Value = _V005_CAR_J.KAITO_9
            spSheet1.Range(NameOf(_V005_CAR_J.KAITO_10)).Value = _V005_CAR_J.KAITO_10
            spSheet1.Range(NameOf(_V005_CAR_J.KAITO_11)).Value = _V005_CAR_J.KAITO_11
            spSheet1.Range(NameOf(_V005_CAR_J.KAITO_12)).Value = _V005_CAR_J.KAITO_12
            spSheet1.Range(NameOf(_V005_CAR_J.KAITO_13)).Value = _V005_CAR_J.KAITO_13
            If CBool(_V005_CAR_J.KAITO_14) Then
                spSheet1.Range(NameOf(_V005_CAR_J.KAITO_14) & "_YOU").Value = "TRUE"
            Else
                spSheet1.Range(NameOf(_V005_CAR_J.KAITO_14) & "_HI").Value = "TRUE"
            End If
            spSheet1.Range(NameOf(_V005_CAR_J.KAITO_15)).Value = _V005_CAR_J.KAITO_15
            spSheet1.Range(NameOf(_V005_CAR_J.KAITO_16)).Value = _V005_CAR_J.KAITO_16
            spSheet1.Range(NameOf(_V005_CAR_J.KAITO_17)).Value = _V005_CAR_J.KAITO_17
            spSheet1.Range(NameOf(_V005_CAR_J.KAITO_18)).Value = _V005_CAR_J.KAITO_18
            spSheet1.Range(NameOf(_V005_CAR_J.KAITO_19)).Value = _V005_CAR_J.KAITO_19
            spSheet1.Range(NameOf(_V005_CAR_J.KAITO_20)).Value = _V005_CAR_J.KAITO_20
            spSheet1.Range(NameOf(_V005_CAR_J.KAITO_21)).Value = _V005_CAR_J.KAITO_21
            spSheet1.Range(NameOf(_V005_CAR_J.KAITO_22)).Value = _V005_CAR_J.KAITO_22
            spSheet1.Range(NameOf(_V005_CAR_J.KAITO_23)).Value = _V005_CAR_J.KAITO_23
            spSheet1.Range(NameOf(_V005_CAR_J.KAITO_24)).Value = _V005_CAR_J.KAITO_24
            spSheet1.Range(NameOf(_V005_CAR_J.KAITO_25)).Value = _V005_CAR_J.KAITO_25

            spSheet1.Range(NameOf(_V005_CAR_J.KENSA_GL_SYAIN_NAME)).Value = _V005_CAR_J.KENSA_GL_SYAIN_NAME
            spSheet1.Range(NameOf(_V005_CAR_J.KENSA_GL_YMDHNS)).Value = _V005_CAR_J.KENSA_GL_YMDHNS
            spSheet1.Range(NameOf(_V005_CAR_J.KENSA_TANTO_NAME)).Value = _V005_CAR_J.KENSA_TANTO_NAME
            spSheet1.Range(NameOf(_V005_CAR_J.KENSA_TOROKU_YMDHNS)).Value = _V005_CAR_J.KENSA_TOROKU_YMDHNS
            spSheet1.Range(NameOf(_V005_CAR_J.KISYU)).Value = _V005_CAR_J.KISYU
            spSheet1.Range(NameOf(_V005_CAR_J.SYOCHI_A_SYAIN_NAME)).Value = _V005_CAR_J.SYOCHI_A_SYAIN_NAME
            spSheet1.Range(NameOf(_V005_CAR_J.SYOCHI_A_YMDHNS)).Value = _V005_CAR_J.SYOCHI_A_YMDHNS
            spSheet1.Range(NameOf(_V005_CAR_J.SYOCHI_B_SYAIN_NAME)).Value = _V005_CAR_J.SYOCHI_B_SYAIN_NAME
            spSheet1.Range(NameOf(_V005_CAR_J.SYOCHI_B_YMDHNS)).Value = _V005_CAR_J.SYOCHI_B_YMDHNS
            spSheet1.Range(NameOf(_V005_CAR_J.SYOCHI_C_SYAIN_NAME)).Value = _V005_CAR_J.SYOCHI_C_SYAIN_NAME
            spSheet1.Range(NameOf(_V005_CAR_J.SYOCHI_C_YMDHNS)).Value = _V005_CAR_J.SYOCHI_C_YMDHNS
            spSheet1.Range("SYONIN_NAME10").Value = _V005_CAR_J.GOKI
            spSheet1.Range("SYONIN_NAME20").Value = _V005_CAR_J.GOKI
            spSheet1.Range("SYONIN_NAME30").Value = _V005_CAR_J.GOKI
            spSheet1.Range("SYONIN_NAME40").Value = _V005_CAR_J.GOKI
            spSheet1.Range("SYONIN_NAME50").Value = _V005_CAR_J.GOKI
            spSheet1.Range("SYONIN_NAME60").Value = _V005_CAR_J.GOKI
            spSheet1.Range("SYONIN_NAME90").Value = _V005_CAR_J.GOKI
            spSheet1.Range("SYONIN_NAME100").Value = _V005_CAR_J.GOKI
            spSheet1.Range("SYONIN_NAME120").Value = _V005_CAR_J.GOKI
            spSheet1.Range("SYONIN_YMD10").Value = _V005_CAR_J.GOKI
            spSheet1.Range("SYONIN_YMD20").Value = _V005_CAR_J.GOKI
            spSheet1.Range("SYONIN_YMD30").Value = _V005_CAR_J.GOKI
            spSheet1.Range("SYONIN_YMD40").Value = _V005_CAR_J.GOKI
            spSheet1.Range("SYONIN_YMD50").Value = _V005_CAR_J.GOKI
            spSheet1.Range("SYONIN_YMD60").Value = _V005_CAR_J.GOKI
            spSheet1.Range("SYONIN_YMD90").Value = _V005_CAR_J.GOKI
            spSheet1.Range("SYONIN_YMD100").Value = _V005_CAR_J.GOKI
            spSheet1.Range("SYONIN_YMD120").Value = _V005_CAR_J.GOKI
            spSheet1.Range(NameOf(_V005_CAR_J.SYOSAI_FILE_PATH)).Value = _V005_CAR_J.SYOSAI_FILE_PATH
            spSheet1.Range(NameOf(_V005_CAR_J.ZESEI_SYOCHI_YUKO_UMU_NAME)).Value = _V005_CAR_J.ZESEI_SYOCHI_YUKO_UMU_NAME

            '-----SpereasheetGera印刷
            Dim ssgPrintDocument As SpreadsheetGear.Drawing.Printing.WorkbookPrintDocument = New SpreadsheetGear.Drawing.Printing.WorkbookPrintDocument(spSheet1, SpreadsheetGear.Printing.PrintWhat.Sheet)
            'printDocument.PrinterSettings.PrinterName = "PrinterName"
            ssgPrintDocument.Print()

            '-----ファイル保存
            'spWork.Delete()
            'spWorksheets(0).Cells("A1").Select()
            spSheet1.SaveAs(filename:=strFilePath, fileFormat:=SpreadsheetGear.FileFormat.OpenXMLWorkbook)
            spWorkbook.WorkbookSet.ReleaseLock()

            '-----Spire版 直接PDF発行するならこっち
            'Dim workbook As New Spire.Xls.Workbook
            'workbook.LoadFromFile(strFilePath)
            'Dim pdfFilePath As String
            'pdfFilePath = System.IO.Path.GetDirectoryName(strFilePath) & "\" & System.IO.Path.GetFileNameWithoutExtension(strFilePath) & ".pdf"
            'workbook.SaveToFile(pdfFilePath, Spire.Xls.FileFormat.PDF)

            ''Spire PDF編集
            ''Dim pdfDoc As New Spire.Pdf.PdfDocument
            ''pdfDoc.PageSettings.Orientation = Spire.Pdf.PdfPageOrientation.Landscape
            ''pdfDoc.PageSettings.Width = "970"
            ''pdfDoc.PageSettings.Height = "850"

            ''PDF表示
            'System.Diagnostics.Process.Start(pdfFilePath)

            'Excel作業ファイルを削除
            Try
                System.IO.File.Delete(strFilePath)
            Catch ex As UnauthorizedAccessException
            End Try

            Return True

        Catch ex As Exception
            EM.ErrorSyori(ex, False, conblnNonMsg)
            Return False
        Finally
            spRangeFrom = Nothing
            spRangeTo = Nothing
            spSheet1 = Nothing
            spWorksheets = Nothing
            spWorkbook = Nothing

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
    Private Function FunInitFuncButtonEnabled(ByVal frm As FrmG0012) As Boolean
        Try

            For intFunc As Integer = 1 To 12
                With frm.Controls("cmdFunc" & intFunc)
                    If .Text.Length = 0 OrElse .Text.Substring(0, .Text.IndexOf("(")).Trim = "" Then
                        .Text = ""
                        .Visible = False
                    End If
                End With
            Next intFunc

            Dim dgv As DataGridView = DirectCast(frm.Controls("dgvDATA"), DataGridView)

            frm.cmdFunc2.Enabled = True
            frm.cmdFunc3.Enabled = True
            frm.cmdFunc5.Enabled = True
            frm.cmdFunc11.Enabled = True

            'If dgv.SelectedRows.Count > 0 Then
            '    If dgv.CurrentRow IsNot Nothing AndAlso dgv.CurrentRow.Cells.Item("DEL_FLG").Value = True Then
            '        '削除済データの場合
            '        frm.cmdFunc4.Enabled = False
            '        frm.cmdFunc5.Text = "完全削除(F5)"
            '        frm.cmdFunc5.Tag = ENM_DATA_OPERATION_MODE._6_DELETE

            '        '復元
            '        frm.cmdFunc6.Text = "復元(F6)"
            '        frm.cmdFunc6.Visible = True
            '        frm.cmdFunc6.Tag = ENM_DATA_OPERATION_MODE._5_RESTORE
            '    Else
            '        frm.cmdFunc5.Text = "削除(F5)"
            '        frm.cmdFunc5.Tag = ENM_DATA_OPERATION_MODE._4_DISABLE

            '        frm.cmdFunc6.Text = ""
            '        frm.cmdFunc6.Visible = False
            '        frm.cmdFunc6.Tag = ""
            '    End If
            'Else
            '    frm.cmdFunc6.Visible = False
            'End If

            Return True
        Catch ex As Exception
            EM.ErrorSyori(ex, False, conblnNonMsg)
            Return False
        End Try
    End Function

#End Region

#End Region

#Region "コントロールイベント"

#Region "   タブ別"

#Region "   1.発生状況"

#End Region
#Region "   2.要因"

    'SPEC: 10-1
    Private Sub cmbKONPON_YOIN_KB1_Validating(sender As Object, e As System.ComponentModel.CancelEventArgs) Handles cmbKONPON_YOIN_KB1.Validating
        'If _D005_CAR_J.
    End Sub

    Private Sub cmbKONPON_YOIN_KB2_Validating(sender As Object, e As System.ComponentModel.CancelEventArgs) Handles cmbKONPON_YOIN_KB2.Validating

    End Sub
#End Region
#Region "   3.根本原因"

#End Region
#Region "   4.修正応急処置"

#End Region
#Region "   5.是正処置"

#End Region
#Region "   6.処置水平展開"

#End Region
#Region "   7.申請先情報"

#End Region

#Region "   処置実施記録"

#Region "       教育記録"
    'ファイル選択
    Private Sub btnOpenKYOIKU_FILE_PATH_Click(sender As Object, e As EventArgs) Handles btnOpenKYOIKU_FILE_PATH.Click
        Dim ofd As New OpenFileDialog With {
            .Filter = "Excel(*.xls;*.xlsx)|*.xls;*.xlsx|Word(*.doc;*.docx)|*.doc;*.docx|すべてのファイル(*.*)|*.*",
            .FilterIndex = 1,
            .Title = "添付するファイルを選択してください",
            .RestoreDirectory = True
        }
        If lblKYOIKU_FILE_PATH.Links.Count = 0 Then
        Else
            ofd.InitialDirectory = IO.Path.GetDirectoryName(lblKYOIKU_FILE_PATH.Links(0).ToString)
        End If
        If ofd.ShowDialog() = DialogResult.OK Then
            lblKYOIKU_FILE_PATH.Text = IO.Path.GetFileName(ofd.FileName)
            lblKYOIKU_FILE_PATH.Links.Clear()
            lblKYOIKU_FILE_PATH.Links.Add(0, lblKYOIKU_FILE_PATH.Text.Length, ofd.FileName)

            _D003_NCR_J.FILE_PATH = ofd.FileName
            'lbltmpFile1.Tag = ofd.FileName
            lblKYOIKU_FILE_PATH.Visible = True
            lblKYOIKU_FILE_PATH_Clear.Visible = True
        End If
    End Sub

    'リンククリック
    Private Sub lblKYOIKU_FILE_PATH_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles lblKYOIKU_FILE_PATH.LinkClicked
        Dim hProcess As New System.Diagnostics.Process
        Dim strEXE As String
        'Dim strARG As String
        Try

            strEXE = lblKYOIKU_FILE_PATH.Links(0).LinkData
            If strEXE.IsNullOrWhiteSpace Then
            Else
                If System.IO.File.Exists(strEXE) = True Then
                    hProcess.StartInfo.FileName = strEXE
                    'hProcess.StartInfo.Arguments = strARG
                    hProcess.SynchronizingObject = Me
                    'AddHandler hProcess.Exited, AddressOf ProcessExited
                    hProcess.EnableRaisingEvents = True
                    hProcess.Start()

                    '最前面
                    Call SetForegroundWindow(hProcess.Handle)

                    'Call SetTaskbarInfo(ENM_TASKBAR_STATE._2_Normal, 100)
                    'Call SetTaskbarOverlayIcon(System.Drawing.SystemIcons.Application)
                Else
                    Dim strMsg As String
                    strMsg = "ファイルが見つかりません。" & vbCrLf & "システム管理者にご連絡下さい。" &
                                vbCrLf & vbCrLf & strEXE
                    MessageBox.Show(strMsg, My.Application.Info.AssemblyName, MessageBoxButtons.OK, MessageBoxIcon.Information)
                End If
            End If
        Catch exInvalid As InvalidOperationException
            'EM.ErrorSyori(exInvalid, False, conblnNonMsg)
        Finally
            'プロセス終了を待機しない------------------------------------
            ''-----自分表示
            'Me.Show()
            'Me.lstGYOMU.Focus()
            'Me.Activate()
            'Me.BringToFront()
            '------------------------------------------------------------

            '-----開放
            If hProcess IsNot Nothing Then
                hProcess.Close()
            End If
        End Try
    End Sub

    'リンククリア
    Private Sub lblKYOIKU_FILE_PATH_Clear_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles lblKYOIKU_FILE_PATH_Clear.LinkClicked
        lblKYOIKU_FILE_PATH.Text = ""
        lblKYOIKU_FILE_PATH.Tag = ""
        lblKYOIKU_FILE_PATH.Links.Clear()
        lblKYOIKU_FILE_PATH.Visible = False
        lblKYOIKU_FILE_PATH_Clear.Visible = False
    End Sub

    Private Sub ProcessExited(ByVal sender As Object, ByVal e As EventArgs)
        'Call SetTaskbarOverlayIcon(Nothing)
        'Call SetTaskbarInfo(ENM_TASKBAR_STATE._0_NoProgress)
    End Sub
#End Region

#End Region
#Region "   是正処置有効性レビュー"

#Region "       詳細資料"
    'ファイル選択
    Private Sub BtnOpenSYOSAI_FILE_PATH_Click(sender As Object, e As EventArgs) Handles btnOpenSYOSAI_FILE_PATH.Click
        Dim ofd As New OpenFileDialog With {
            .Filter = "Excel(*.xls;*.xlsx)|*.xls;*.xlsx|Word(*.doc;*.docx)|*.doc;*.docx|すべてのファイル(*.*)|*.*",
            .FilterIndex = 1,
            .Title = "添付するファイルを選択してください",
            .RestoreDirectory = True
        }
        If lblSYOSAI_FILE_PATH.Links.Count = 0 Then
        Else
            ofd.InitialDirectory = IO.Path.GetDirectoryName(lblSYOSAI_FILE_PATH.Links(0).ToString)
        End If
        If ofd.ShowDialog() = DialogResult.OK Then
            lblSYOSAI_FILE_PATH.Text = IO.Path.GetFileName(ofd.FileName)
            lblSYOSAI_FILE_PATH.Links.Clear()
            lblSYOSAI_FILE_PATH.Links.Add(0, lblSYOSAI_FILE_PATH.Text.Length, ofd.FileName)

            _D005_CAR_J.KYOIKU_FILE_PATH = ofd.FileName
            lblSYOSAI_FILE_PATH.Visible = True
            lblSYOSAI_FILE_PATH_Clear.Visible = True
        End If
    End Sub

    'リンククリック
    Private Sub LblSYOSAI_FILE_PATH_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles lblSYOSAI_FILE_PATH.LinkClicked
        Dim hProcess As New System.Diagnostics.Process
        Dim strEXE As String
        'Dim strARG As String
        Try

            strEXE = lblSYOSAI_FILE_PATH.Links(0).LinkData
            If strEXE.IsNullOrWhiteSpace Then
            Else
                If System.IO.File.Exists(strEXE) = True Then
                    hProcess.StartInfo.FileName = strEXE
                    'hProcess.StartInfo.Arguments = strARG
                    hProcess.SynchronizingObject = Me
                    'AddHandler hProcess.Exited, AddressOf ProcessExited
                    hProcess.EnableRaisingEvents = True
                    hProcess.Start()

                    '最前面
                    Call SetForegroundWindow(hProcess.Handle)

                    'Call SetTaskbarInfo(ENM_TASKBAR_STATE._2_Normal, 100)
                    'Call SetTaskbarOverlayIcon(System.Drawing.SystemIcons.Application)
                Else
                    Dim strMsg As String
                    strMsg = "ファイルが見つかりません。" & vbCrLf & "システム管理者にご連絡下さい。" &
                                vbCrLf & vbCrLf & strEXE
                    MessageBox.Show(strMsg, My.Application.Info.AssemblyName, MessageBoxButtons.OK, MessageBoxIcon.Information)
                End If
            End If
        Catch exInvalid As InvalidOperationException
            'EM.ErrorSyori(exInvalid, False, conblnNonMsg)
        Finally
            'プロセス終了を待機しない------------------------------------
            ''-----自分表示
            'Me.Show()
            'Me.lstGYOMU.Focus()
            'Me.Activate()
            'Me.BringToFront()
            '------------------------------------------------------------

            '-----開放
            If hProcess IsNot Nothing Then
                hProcess.Close()
            End If
        End Try
    End Sub

    'リンククリア
    Private Sub LblSYOSAI_FILE_PATH_Clear_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles lblSYOSAI_FILE_PATH_Clear.LinkClicked
        lblKYOIKU_FILE_PATH.Text = ""
        lblKYOIKU_FILE_PATH.Tag = ""
        lblKYOIKU_FILE_PATH.Links.Clear()
        lblKYOIKU_FILE_PATH.Visible = False
        lblKYOIKU_FILE_PATH_Clear.Visible = False
    End Sub
#End Region

#End Region
#Region "   添付資料"

#Region "       添付資料1"
    'ファイル選択
    Private Sub BtnOpentmpFile1_Click(sender As Object, e As EventArgs) Handles btnOpentmpFile1.Click
        Dim ofd As New OpenFileDialog With {
            .Filter = "Excel(*.xls;*.xlsx)|*.xls;*.xlsx|Word(*.doc;*.docx)|*.doc;*.docx|すべてのファイル(*.*)|*.*",
            .FilterIndex = 1,
            .Title = "添付するファイルを選択してください",
            .RestoreDirectory = True
        }
        If lbltmpFile1.Links.Count = 0 Then
        Else
            ofd.InitialDirectory = IO.Path.GetDirectoryName(lbltmpFile1.Links(0).ToString)
        End If
        If ofd.ShowDialog() = DialogResult.OK Then
            lbltmpFile1.Text = IO.Path.GetFileName(ofd.FileName)
            lbltmpFile1.Links.Clear()
            lbltmpFile1.Links.Add(0, lbltmpFile1.Text.Length, ofd.FileName)

            _D005_CAR_J.FILE_PATH1 = ofd.FileName
            lbltmpFile1.Visible = True
            lbltmpFile1_Clear.Visible = True
        End If
    End Sub

    'リンククリック
    Private Sub lbltmpFile1_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles lbltmpFile1.LinkClicked
        Dim hProcess As New System.Diagnostics.Process
        Dim strEXE As String
        'Dim strARG As String
        Try

            strEXE = lbltmpFile1.Links(0).LinkData
            If strEXE.IsNullOrWhiteSpace Then
            Else
                If System.IO.File.Exists(strEXE) = True Then
                    hProcess.StartInfo.FileName = strEXE
                    'hProcess.StartInfo.Arguments = strARG
                    hProcess.SynchronizingObject = Me
                    'AddHandler hProcess.Exited, AddressOf ProcessExited
                    hProcess.EnableRaisingEvents = True
                    hProcess.Start()

                    '最前面
                    Call SetForegroundWindow(hProcess.Handle)

                    'Call SetTaskbarInfo(ENM_TASKBAR_STATE._2_Normal, 100)
                    'Call SetTaskbarOverlayIcon(System.Drawing.SystemIcons.Application)
                Else
                    Dim strMsg As String
                    strMsg = "ファイルが見つかりません。" & vbCrLf & "システム管理者にご連絡下さい。" &
                                vbCrLf & vbCrLf & strEXE
                    MessageBox.Show(strMsg, My.Application.Info.AssemblyName, MessageBoxButtons.OK, MessageBoxIcon.Information)
                End If
            End If
        Catch exInvalid As InvalidOperationException
            'EM.ErrorSyori(exInvalid, False, conblnNonMsg)
        Finally
            'プロセス終了を待機しない------------------------------------
            ''-----自分表示
            'Me.Show()
            'Me.lstGYOMU.Focus()
            'Me.Activate()
            'Me.BringToFront()
            '------------------------------------------------------------

            '-----開放
            If hProcess IsNot Nothing Then
                hProcess.Close()
            End If
        End Try
    End Sub

    'リンククリア
    Private Sub LbltmpFile1_Clear_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles lbltmpFile1_Clear.LinkClicked
        lbltmpFile1.Text = ""
        lbltmpFile1.Tag = ""
        lbltmpFile1.Links.Clear()
        lbltmpFile1.Visible = False
        lbltmpFile1_Clear.Visible = False
    End Sub

#End Region
#Region "       添付資料2"
    'ファイル選択
    Private Sub btnOpentmpFile2_Click(sender As Object, e As EventArgs) Handles btnOpentmpFile2.Click
        Dim ofd As New OpenFileDialog With {
            .Filter = "Excel(*.xls;*.xlsx)|*.xls;*.xlsx|Word(*.doc;*.docx)|*.doc;*.docx|すべてのファイル(*.*)|*.*",
            .FilterIndex = 1,
            .Title = "添付するファイルを選択してください",
            .RestoreDirectory = True
        }
        If lbltmpFile2.Links.Count = 0 Then
        Else
            ofd.InitialDirectory = IO.Path.GetDirectoryName(lbltmpFile2.Links(0).ToString)
        End If
        If ofd.ShowDialog() = DialogResult.OK Then
            lbltmpFile2.Text = IO.Path.GetFileName(ofd.FileName)
            lbltmpFile2.Links.Clear()
            lbltmpFile2.Links.Add(0, lbltmpFile2.Text.Length, ofd.FileName)

            _D005_CAR_J.FILE_PATH2 = ofd.FileName
            'lbltmpFile1.Tag = ofd.FileName
            lbltmpFile2.Visible = True
            lbltmpFile2_Clear.Visible = True
        End If
    End Sub

    'リンククリック
    Private Sub lbltmpFile2_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles lbltmpFile2.LinkClicked
        Dim hProcess As New System.Diagnostics.Process
        Dim strEXE As String
        'Dim strARG As String
        Try

            strEXE = lbltmpFile2.Links(0).LinkData
            If strEXE.IsNullOrWhiteSpace Then
            Else
                If System.IO.File.Exists(strEXE) = True Then
                    hProcess.StartInfo.FileName = strEXE
                    'hProcess.StartInfo.Arguments = strARG
                    hProcess.SynchronizingObject = Me
                    'AddHandler hProcess.Exited, AddressOf ProcessExited
                    hProcess.EnableRaisingEvents = True
                    hProcess.Start()

                    '最前面
                    Call SetForegroundWindow(hProcess.Handle)

                    'Call SetTaskbarInfo(ENM_TASKBAR_STATE._2_Normal, 100)
                    'Call SetTaskbarOverlayIcon(System.Drawing.SystemIcons.Application)
                Else
                    Dim strMsg As String
                    strMsg = "ファイルが見つかりません。" & vbCrLf & "システム管理者にご連絡下さい。" &
                                vbCrLf & vbCrLf & strEXE
                    MessageBox.Show(strMsg, My.Application.Info.AssemblyName, MessageBoxButtons.OK, MessageBoxIcon.Information)
                End If
            End If
        Catch exInvalid As InvalidOperationException
            'EM.ErrorSyori(exInvalid, False, conblnNonMsg)
        Finally
            'プロセス終了を待機しない------------------------------------
            ''-----自分表示
            'Me.Show()
            'Me.lstGYOMU.Focus()
            'Me.Activate()
            'Me.BringToFront()
            '------------------------------------------------------------

            '-----開放
            If hProcess IsNot Nothing Then
                hProcess.Close()
            End If
        End Try
    End Sub

    'リンククリア
    Private Sub lbltmpFile2_Clear_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles lbltmpFile2_Clear.LinkClicked
        lbltmpFile2.Text = ""
        lbltmpFile2.Tag = ""
        lbltmpFile2.Links.Clear()
        lbltmpFile2.Visible = False
        lbltmpFile2_Clear.Visible = False
    End Sub
#End Region

#End Region

#End Region


#End Region


#Region "ローカル関数"

    Private Function FunSetBinding() As Boolean
        '更新しないものはバインドしないものとする
        mtxKISYU.Text = tblKISYU.AsEnumerable.Where(Function(r) r.Field(Of Integer)("VALUE") = _D003_NCR_J.KISYU_ID).FirstOrDefault?.Item("DISP")
        mtxADD_SYAIN_NAME.Text = Fun_GetUSER_NAME(_D004_SYONIN_J_KANRI.SYAIN_ID)
        mtxFUTEKIGO_KB.Text = tblFUTEKIGO_KB.AsEnumerable.Where(Function(r) r.Field(Of String)("VALUE") = _D003_NCR_J.FUTEKIGO_KB).FirstOrDefault?.Item("DISP")
        mtxFUTEKIGO_S_KB.Text = tblFUTEKIGO_S_KB.AsEnumerable.Where(Function(r) r.Field(Of String)("VALUE") = _D003_NCR_J.FUTEKIGO_S_KB).FirstOrDefault?.Item("DISP")
        mtxCurrentStageName.Text = FunGetCurrentStageName(ENM_SYONIN_HOKOKUSYO_ID._2_CAR, _D005_CAR_J.HOKOKU_NO)

        'ヘッダ
        mtxHOKUKO_NO.DataBindings.Add(New Binding(NameOf(mtxHOKUKO_NO.Text), _D005_CAR_J, NameOf(_D005_CAR_J.HOKOKU_NO), False, DataSourceUpdateMode.OnPropertyChanged, ""))
        'mtxKISYU.DataBindings.Add(New Binding(NameOf(mtxKISYU.Text), _D005_CAR_J, NameOf(_D005_CAR_J.ki), False, DataSourceUpdateMode.OnPropertyChanged))
        'mtxADD_SYAIN_NAME.DataBindings.Add(New Binding(NameOf(mtxADD_SYAIN_NAME.Text), _D005_CAR_J, NameOf(_D005_CAR_J.HOKOKU_NO), False, DataSourceUpdateMode.OnPropertyChanged))
        'mtxCurrentStageName.DataBindings.Add(New Binding(NameOf(mtxCurrentStageName.Text), _D005_CAR_J, NameOf(_D005_CAR_J.HOKOKU_NO), False, DataSourceUpdateMode.OnPropertyChanged))

        '発生状況
        txtKAITO_1.DataBindings.Add(New Binding(NameOf(txtKAITO_1.Text), _D005_CAR_J, NameOf(_D005_CAR_J.KAITO_1), False, DataSourceUpdateMode.OnPropertyChanged))
        'mtxFUTEKIGO_KB.DataBindings.Add(New Binding(NameOf(mtxFUTEKIGO_KB.Text), _D005_CAR_J, NameOf(_D005_CAR_J), False, DataSourceUpdateMode.OnPropertyChanged))
        'mtxFUTEKIGO_S_KB.DataBindings.Add(New Binding(NameOf(mtxFUTEKIGO_S_KB.Text), _D005_CAR_J, NameOf(_D005_CAR_J.HOKOKU_NO), False, DataSourceUpdateMode.OnPropertyChanged))

        '要因
        txtKAITO_2.DataBindings.Add(New Binding(NameOf(txtKAITO_2.Text), _D005_CAR_J, NameOf(_D005_CAR_J.KAITO_2), False, DataSourceUpdateMode.OnPropertyChanged))
        cmbKONPON_YOIN_KB1.DataBindings.Add(New Binding(NameOf(cmbKONPON_YOIN_KB1.SelectedValue), _D005_CAR_J, NameOf(_D005_CAR_J.KONPON_YOIN_KB1), False, DataSourceUpdateMode.OnPropertyChanged))
        cmbKONPON_YOIN_KB2.DataBindings.Add(New Binding(NameOf(cmbKONPON_YOIN_KB2.SelectedValue), _D005_CAR_J, NameOf(_D005_CAR_J.KONPON_YOIN_KB2), False, DataSourceUpdateMode.OnPropertyChanged))
        cmbKONPON_YOIN_TANTO.DataBindings.Add(New Binding(NameOf(cmbKONPON_YOIN_TANTO.SelectedValue), _D005_CAR_J, NameOf(_D005_CAR_J.KONPON_YOIN_SYAIN_ID), False, DataSourceUpdateMode.OnPropertyChanged))

        '根本原因
        txtKAITO_3.DataBindings.Add(New Binding(NameOf(txtKAITO_3.Text), _D005_CAR_J, NameOf(_D005_CAR_J.KAITO_3), False, DataSourceUpdateMode.OnPropertyChanged))
        'cmbGENIN1.DataBindings.Add(New Binding(NameOf(cmbGENIN1.SelectedValue), _D005_CAR_J, NameOf(_D005_CAR_J), False, DataSourceUpdateMode.OnPropertyChanged))
        'cmbGENIN2.DataBindings.Add(New Binding(NameOf(cmbGENIN2.SelectedValue), _D005_CAR_J, NameOf(_D005_CAR_J.HOKOKU_NO), False, DataSourceUpdateMode.OnPropertyChanged))
        cmbKISEKI_KOTEI.DataBindings.Add(New Binding(NameOf(cmbKISEKI_KOTEI.SelectedValue), _D005_CAR_J, NameOf(_D005_CAR_J.KISEKI_KOTEI_KB), False, DataSourceUpdateMode.OnPropertyChanged))

        '修正・応急処置
        dtKAITO_4.DataBindings.Add(New Binding(NameOf(dtKAITO_4.ValueNonFormat), _D005_CAR_J, NameOf(_D005_CAR_J.KAITO_4), False, DataSourceUpdateMode.OnPropertyChanged))
        cmbKAITO_5.DataBindings.Add(New Binding(NameOf(cmbKAITO_5.SelectedValue), _D005_CAR_J, NameOf(_D005_CAR_J.KAITO_5), False, DataSourceUpdateMode.OnPropertyChanged))
        cmbKAITO_6.DataBindings.Add(New Binding(NameOf(cmbKAITO_6.SelectedValue), _D005_CAR_J, NameOf(_D005_CAR_J.KAITO_6), False, DataSourceUpdateMode.OnPropertyChanged))
        mtxKAITO_7.DataBindings.Add(New Binding(NameOf(mtxKAITO_7.Text), _D005_CAR_J, NameOf(_D005_CAR_J.KAITO_7), False, DataSourceUpdateMode.OnPropertyChanged))
        dtKAITO_8.DataBindings.Add(New Binding(NameOf(dtKAITO_8.ValueNonFormat), _D005_CAR_J, NameOf(_D005_CAR_J.KAITO_7), False, DataSourceUpdateMode.OnPropertyChanged))

        '是正処置
        dtKAITO_9.DataBindings.Add(New Binding(NameOf(dtKAITO_9.ValueNonFormat), _D005_CAR_J, NameOf(_D005_CAR_J.KAITO_9), False, DataSourceUpdateMode.OnPropertyChanged))
        cmbKAITO_10.DataBindings.Add(New Binding(NameOf(cmbKAITO_10.SelectedValue), _D005_CAR_J, NameOf(_D005_CAR_J.KAITO_10), False, DataSourceUpdateMode.OnPropertyChanged))
        cmbKAITO_11.DataBindings.Add(New Binding(NameOf(cmbKAITO_11.SelectedValue), _D005_CAR_J, NameOf(_D005_CAR_J.KAITO_11), False, DataSourceUpdateMode.OnPropertyChanged))
        mtxKAITO_12.DataBindings.Add(New Binding(NameOf(mtxKAITO_12.Text), _D005_CAR_J, NameOf(_D005_CAR_J.KAITO_12), False, DataSourceUpdateMode.OnPropertyChanged))
        dtKAITO_13.DataBindings.Add(New Binding(NameOf(dtKAITO_13.ValueNonFormat), _D005_CAR_J, NameOf(_D005_CAR_J.KAITO_13), False, DataSourceUpdateMode.OnPropertyChanged))

        '処置水平展開
        cmbKAITO_14.DataBindings.Add(New Binding(NameOf(cmbKAITO_14.SelectedValue), _D005_CAR_J, NameOf(_D005_CAR_J.KAITO_14), False, DataSourceUpdateMode.OnPropertyChanged))
        mtxKAITO_15.DataBindings.Add(New Binding(NameOf(mtxKAITO_15.Text), _D005_CAR_J, NameOf(_D005_CAR_J.KAITO_15), False, DataSourceUpdateMode.OnPropertyChanged))
        dtKAITO_16.DataBindings.Add(New Binding(NameOf(dtKAITO_16.ValueNonFormat), _D005_CAR_J, NameOf(_D005_CAR_J.KAITO_16), False, DataSourceUpdateMode.OnPropertyChanged))
        cmbKAITO_17.DataBindings.Add(New Binding(NameOf(cmbKAITO_17.SelectedValue), _D005_CAR_J, NameOf(_D005_CAR_J.KAITO_17), False, DataSourceUpdateMode.OnPropertyChanged))
        cmbKAITO_18.DataBindings.Add(New Binding(NameOf(cmbKAITO_18.SelectedValue), _D005_CAR_J, NameOf(_D005_CAR_J.KAITO_18), False, DataSourceUpdateMode.OnPropertyChanged))
        mtxKAITO_19.DataBindings.Add(New Binding(NameOf(mtxKAITO_19.Text), _D005_CAR_J, NameOf(_D005_CAR_J.KAITO_19), False, DataSourceUpdateMode.OnPropertyChanged))
        dtKAITO_20.DataBindings.Add(New Binding(NameOf(dtKAITO_20.ValueNonFormat), _D005_CAR_J, NameOf(_D005_CAR_J.KAITO_20), False, DataSourceUpdateMode.OnPropertyChanged))

        '処置実施記録
        cmbSYOCHI_A_TANTO.DataBindings.Add(New Binding(NameOf(cmbSYOCHI_A_TANTO.SelectedValue), _D005_CAR_J, NameOf(_D005_CAR_J.SYOCHI_A_SYAIN_ID), False, DataSourceUpdateMode.OnPropertyChanged))
        cmbSYOCHI_B_TANTO.DataBindings.Add(New Binding(NameOf(cmbSYOCHI_B_TANTO.SelectedValue), _D005_CAR_J, NameOf(_D005_CAR_J.SYOCHI_B_SYAIN_ID), False, DataSourceUpdateMode.OnPropertyChanged))
        cmbSYOCHI_C_TANTO.DataBindings.Add(New Binding(NameOf(cmbSYOCHI_C_TANTO.SelectedValue), _D005_CAR_J, NameOf(_D005_CAR_J.SYOCHI_C_SYAIN_ID), False, DataSourceUpdateMode.OnPropertyChanged))
        dtSYOCHI_A_YMD.DataBindings.Add(New Binding(NameOf(dtSYOCHI_A_YMD.ValueNonFormat), _D005_CAR_J, NameOf(_D005_CAR_J.SYOCHI_A_YMDHNS), False, DataSourceUpdateMode.OnPropertyChanged))
        dtSYOCHI_B_YMD.DataBindings.Add(New Binding(NameOf(dtSYOCHI_B_YMD.ValueNonFormat), _D005_CAR_J, NameOf(_D005_CAR_J.SYOCHI_B_YMDHNS), False, DataSourceUpdateMode.OnPropertyChanged))
        dtSYOCHI_C_YMD.DataBindings.Add(New Binding(NameOf(dtSYOCHI_C_YMD.ValueNonFormat), _D005_CAR_J, NameOf(_D005_CAR_J.SYOCHI_C_YMDHNS), False, DataSourceUpdateMode.OnPropertyChanged))
        lblKYOIKU_FILE_PATH.DataBindings.Add(New Binding(NameOf(lblKYOIKU_FILE_PATH.Tag), _D005_CAR_J, NameOf(_D005_CAR_J.KYOIKU_FILE_PATH), False, DataSourceUpdateMode.OnPropertyChanged))

        '是正処置有効性レビュー
        chkZESEI_SYOCHI_YUKO_UMU.DataBindings.Add(New Binding(NameOf(chkZESEI_SYOCHI_YUKO_UMU.Checked), _D005_CAR_J, NameOf(_D005_CAR_J.ZESEI_SYOCHI_YUKO_UMU), False, DataSourceUpdateMode.OnPropertyChanged))
        mtxGOKI.DataBindings.Add(New Binding(NameOf(mtxGOKI.Text), _D005_CAR_J, NameOf(_D005_CAR_J.GOKI), False, DataSourceUpdateMode.OnPropertyChanged))
        mtxLOT.DataBindings.Add(New Binding(NameOf(mtxLOT.Text), _D005_CAR_J, NameOf(_D005_CAR_J.LOT), False, DataSourceUpdateMode.OnPropertyChanged))
        lblSYOSAI_FILE_PATH.DataBindings.Add(New Binding(NameOf(lblSYOSAI_FILE_PATH.Tag), _D005_CAR_J, NameOf(_D005_CAR_J.SYOSAI_FILE_PATH), False, DataSourceUpdateMode.OnPropertyChanged))
        cmbKENSA_TANTO.DataBindings.Add(New Binding(NameOf(cmbKENSA_TANTO.SelectedValue), _D005_CAR_J, NameOf(_D005_CAR_J.KENSA_TANTO_ID), False, DataSourceUpdateMode.OnPropertyChanged))
        cmbKENSA_GL_TANTO.DataBindings.Add(New Binding(NameOf(cmbKENSA_GL_TANTO.SelectedValue), _D005_CAR_J, NameOf(_D005_CAR_J.KENSA_GL_SYAIN_ID), False, DataSourceUpdateMode.OnPropertyChanged))
        dtKENSA_TOROKU.DataBindings.Add(New Binding(NameOf(dtKENSA_TOROKU.ValueNonFormat), _D005_CAR_J, NameOf(_D005_CAR_J.KENSA_TOROKU_YMDHNS), False, DataSourceUpdateMode.OnPropertyChanged))
        dtKENSA_GL_TOROKU.DataBindings.Add(New Binding(NameOf(dtKENSA_GL_TOROKU.ValueNonFormat), _D005_CAR_J, NameOf(_D005_CAR_J.KENSA_GL_YMDHNS), False, DataSourceUpdateMode.OnPropertyChanged))

        '添付資料
        lbltmpFile1.DataBindings.Add(New Binding(NameOf(lbltmpFile1.Tag), _D005_CAR_J, NameOf(_D005_CAR_J.FILE_PATH1), False, DataSourceUpdateMode.OnPropertyChanged))
        lbltmpFile2.DataBindings.Add(New Binding(NameOf(lbltmpFile2.Tag), _D005_CAR_J, NameOf(_D005_CAR_J.FILE_PATH2), False, DataSourceUpdateMode.OnPropertyChanged))


    End Function


#Region "処理モード別画面初期化"
    Private Function FunInitializeControls() As Boolean

        Try
            If FunSetSETUMON_NAIYO() = False Then
                Return False
            End If

            If FunSetModel() = False Then
                Return False
            End If


            Return True

        Catch ex As Exception
            EM.ErrorSyori(ex, False, conblnNonMsg)
            Return False
        End Try
    End Function


    Private Function FunSetSETUMON_NAIYO() As Boolean
        lblSETUMON_1.Text = tblSETUMON_NAIYO.AsEnumerable.Where(Function(r) r.Field(Of String)("VALUE") = 1).First.Item("DISP")
        lblSETUMON_2.Text = tblSETUMON_NAIYO.AsEnumerable.Where(Function(r) r.Field(Of String)("VALUE") = 2).First.Item("DISP")
        lblSETUMON_3.Text = tblSETUMON_NAIYO.AsEnumerable.Where(Function(r) r.Field(Of String)("VALUE") = 3).First.Item("DISP")
        lblSETUMON_4.Text = tblSETUMON_NAIYO.AsEnumerable.Where(Function(r) r.Field(Of String)("VALUE") = 4).First.Item("DISP")
        lblSETUMON_5.Text = tblSETUMON_NAIYO.AsEnumerable.Where(Function(r) r.Field(Of String)("VALUE") = 5).First.Item("DISP")
        lblSETUMON_6.Text = tblSETUMON_NAIYO.AsEnumerable.Where(Function(r) r.Field(Of String)("VALUE") = 6).First.Item("DISP")
        lblSETUMON_7.Text = tblSETUMON_NAIYO.AsEnumerable.Where(Function(r) r.Field(Of String)("VALUE") = 7).First.Item("DISP")
        lblSETUMON_8.Text = tblSETUMON_NAIYO.AsEnumerable.Where(Function(r) r.Field(Of String)("VALUE") = 8).First.Item("DISP")
        lblSETUMON_9.Text = tblSETUMON_NAIYO.AsEnumerable.Where(Function(r) r.Field(Of String)("VALUE") = 9).First.Item("DISP")
        lblSETUMON_10.Text = tblSETUMON_NAIYO.AsEnumerable.Where(Function(r) r.Field(Of String)("VALUE") = 10).First.Item("DISP")
        lblSETUMON_11.Text = tblSETUMON_NAIYO.AsEnumerable.Where(Function(r) r.Field(Of String)("VALUE") = 11).First.Item("DISP")
        lblSETUMON_12.Text = tblSETUMON_NAIYO.AsEnumerable.Where(Function(r) r.Field(Of String)("VALUE") = 12).First.Item("DISP")
        lblSETUMON_13.Text = tblSETUMON_NAIYO.AsEnumerable.Where(Function(r) r.Field(Of String)("VALUE") = 13).First.Item("DISP")
        lblSETUMON_14.Text = tblSETUMON_NAIYO.AsEnumerable.Where(Function(r) r.Field(Of String)("VALUE") = 14).First.Item("DISP")
        lblSETUMON_15.Text = tblSETUMON_NAIYO.AsEnumerable.Where(Function(r) r.Field(Of String)("VALUE") = 15).First.Item("DISP")
        lblSETUMON_16.Text = tblSETUMON_NAIYO.AsEnumerable.Where(Function(r) r.Field(Of String)("VALUE") = 16).First.Item("DISP")
        lblSETUMON_17.Text = tblSETUMON_NAIYO.AsEnumerable.Where(Function(r) r.Field(Of String)("VALUE") = 17).First.Item("DISP")
        lblSETUMON_18.Text = tblSETUMON_NAIYO.AsEnumerable.Where(Function(r) r.Field(Of String)("VALUE") = 18).First.Item("DISP")
        lblSETUMON_19.Text = tblSETUMON_NAIYO.AsEnumerable.Where(Function(r) r.Field(Of String)("VALUE") = 19).First.Item("DISP")
        lblSETUMON_20.Text = tblSETUMON_NAIYO.AsEnumerable.Where(Function(r) r.Field(Of String)("VALUE") = 20).First.Item("DISP")

    End Function

    Private Function FunSetModel() As Boolean
        Try
            Dim sbSQL As New System.Text.StringBuilder
            Dim dsList As New DataSet

            _D005_CAR_J.Clear()

            sbSQL.Remove(0, sbSQL.Length)
            sbSQL.Append("SELECT")
            sbSQL.Append(" *")
            sbSQL.Append(" FROM V005_CAR_J")
            sbSQL.Append(" WHERE HOKOKU_NO='" & PrHOKOKU_NO & "'")
            Using DBa As ClsDbUtility = DBOpen()
                dsList = DBa.GetDataSet(sbSQL.ToString, conblnNonMsg)
            End Using

            If dsList.Tables(0).Rows.Count > 0 Then
                With dsList.Tables(0).Rows(0)
                    _D005_CAR_J.HOKOKU_NO = .Item(NameOf(_D005_CAR_J.HOKOKU_NO))
                    _D005_CAR_J.BUMON_KB = .Item(NameOf(_D005_CAR_J.BUMON_KB))
                    _D005_CAR_J.CLOSE_FG = .Item(NameOf(_D005_CAR_J.CLOSE_FG))

                    _D005_CAR_J.SETUMON_1 = .Item(NameOf(_D005_CAR_J.SETUMON_1))
                    _D005_CAR_J.KAITO_1 = .Item(NameOf(_D005_CAR_J.KAITO_1))
                    _D005_CAR_J.SETUMON_2 = .Item(NameOf(_D005_CAR_J.SETUMON_2))
                    _D005_CAR_J.KAITO_2 = .Item(NameOf(_D005_CAR_J.KAITO_2))
                    _D005_CAR_J.SETUMON_3 = .Item(NameOf(_D005_CAR_J.SETUMON_3))
                    _D005_CAR_J.KAITO_3 = .Item(NameOf(_D005_CAR_J.KAITO_3))
                    _D005_CAR_J.SETUMON_4 = .Item(NameOf(_D005_CAR_J.SETUMON_4))
                    _D005_CAR_J.KAITO_4 = .Item(NameOf(_D005_CAR_J.KAITO_4))
                    _D005_CAR_J.SETUMON_5 = .Item(NameOf(_D005_CAR_J.SETUMON_5))
                    _D005_CAR_J.KAITO_5 = .Item(NameOf(_D005_CAR_J.KAITO_5))
                    _D005_CAR_J.SETUMON_6 = .Item(NameOf(_D005_CAR_J.SETUMON_6))
                    _D005_CAR_J.KAITO_6 = .Item(NameOf(_D005_CAR_J.KAITO_6))
                    _D005_CAR_J.SETUMON_7 = .Item(NameOf(_D005_CAR_J.SETUMON_7))
                    _D005_CAR_J.KAITO_7 = .Item(NameOf(_D005_CAR_J.KAITO_7))
                    _D005_CAR_J.SETUMON_8 = .Item(NameOf(_D005_CAR_J.SETUMON_8))
                    _D005_CAR_J.KAITO_8 = .Item(NameOf(_D005_CAR_J.KAITO_8))
                    _D005_CAR_J.SETUMON_9 = .Item(NameOf(_D005_CAR_J.SETUMON_9))
                    _D005_CAR_J.KAITO_9 = .Item(NameOf(_D005_CAR_J.KAITO_9))
                    _D005_CAR_J.SETUMON_10 = .Item(NameOf(_D005_CAR_J.SETUMON_10))
                    _D005_CAR_J.KAITO_10 = .Item(NameOf(_D005_CAR_J.KAITO_10))
                    _D005_CAR_J.SETUMON_11 = .Item(NameOf(_D005_CAR_J.SETUMON_11))
                    _D005_CAR_J.KAITO_11 = .Item(NameOf(_D005_CAR_J.KAITO_11))
                    _D005_CAR_J.SETUMON_12 = .Item(NameOf(_D005_CAR_J.SETUMON_12))
                    _D005_CAR_J.KAITO_12 = .Item(NameOf(_D005_CAR_J.KAITO_12))
                    _D005_CAR_J.SETUMON_13 = .Item(NameOf(_D005_CAR_J.SETUMON_13))
                    _D005_CAR_J.KAITO_13 = .Item(NameOf(_D005_CAR_J.KAITO_13))
                    _D005_CAR_J.SETUMON_14 = .Item(NameOf(_D005_CAR_J.SETUMON_14))
                    _D005_CAR_J.KAITO_14 = .Item(NameOf(_D005_CAR_J.KAITO_14))
                    _D005_CAR_J.SETUMON_15 = .Item(NameOf(_D005_CAR_J.SETUMON_15))
                    _D005_CAR_J.KAITO_15 = .Item(NameOf(_D005_CAR_J.KAITO_15))
                    _D005_CAR_J.SETUMON_16 = .Item(NameOf(_D005_CAR_J.SETUMON_16))
                    _D005_CAR_J.KAITO_16 = .Item(NameOf(_D005_CAR_J.KAITO_16))
                    _D005_CAR_J.SETUMON_17 = .Item(NameOf(_D005_CAR_J.SETUMON_17))
                    _D005_CAR_J.KAITO_17 = .Item(NameOf(_D005_CAR_J.KAITO_17))
                    _D005_CAR_J.SETUMON_18 = .Item(NameOf(_D005_CAR_J.SETUMON_18))
                    _D005_CAR_J.KAITO_18 = .Item(NameOf(_D005_CAR_J.KAITO_18))
                    _D005_CAR_J.SETUMON_19 = .Item(NameOf(_D005_CAR_J.SETUMON_19))
                    _D005_CAR_J.KAITO_19 = .Item(NameOf(_D005_CAR_J.KAITO_19))
                    _D005_CAR_J.SETUMON_20 = .Item(NameOf(_D005_CAR_J.SETUMON_20))
                    _D005_CAR_J.KAITO_20 = .Item(NameOf(_D005_CAR_J.KAITO_20))
                    _D005_CAR_J.SETUMON_21 = .Item(NameOf(_D005_CAR_J.SETUMON_21))
                    _D005_CAR_J.KAITO_21 = .Item(NameOf(_D005_CAR_J.KAITO_21))
                    _D005_CAR_J.SETUMON_22 = .Item(NameOf(_D005_CAR_J.SETUMON_22))
                    _D005_CAR_J.KAITO_22 = .Item(NameOf(_D005_CAR_J.KAITO_22))
                    _D005_CAR_J.SETUMON_23 = .Item(NameOf(_D005_CAR_J.SETUMON_23))
                    _D005_CAR_J.KAITO_23 = .Item(NameOf(_D005_CAR_J.KAITO_23))
                    _D005_CAR_J.SETUMON_24 = .Item(NameOf(_D005_CAR_J.SETUMON_24))
                    _D005_CAR_J.KAITO_24 = .Item(NameOf(_D005_CAR_J.KAITO_24))
                    _D005_CAR_J.SETUMON_25 = .Item(NameOf(_D005_CAR_J.SETUMON_25))
                    _D005_CAR_J.KAITO_25 = .Item(NameOf(_D005_CAR_J.KAITO_25))

                    _D005_CAR_J.KONPON_YOIN_KB1 = .Item(NameOf(_D005_CAR_J.KONPON_YOIN_KB1))
                    _D005_CAR_J.KONPON_YOIN_KB2 = .Item(NameOf(_D005_CAR_J.KONPON_YOIN_KB2))
                    _D005_CAR_J.KONPON_YOIN_SYAIN_ID = .Item(NameOf(_D005_CAR_J.KONPON_YOIN_SYAIN_ID))
                    _D005_CAR_J.KISEKI_KOTEI_KB = .Item(NameOf(_D005_CAR_J.KISEKI_KOTEI_KB))
                    _D005_CAR_J.SYOCHI_A_SYAIN_ID = .Item(NameOf(_D005_CAR_J.SYOCHI_A_SYAIN_ID))
                    _D005_CAR_J.SYOCHI_A_YMDHNS = .Item(NameOf(_D005_CAR_J.SYOCHI_A_YMDHNS))
                    _D005_CAR_J.SYOCHI_B_SYAIN_ID = .Item(NameOf(_D005_CAR_J.SYOCHI_B_SYAIN_ID))
                    _D005_CAR_J.SYOCHI_B_YMDHNS = .Item(NameOf(_D005_CAR_J.SYOCHI_B_YMDHNS))
                    _D005_CAR_J.SYOCHI_C_SYAIN_ID = .Item(NameOf(_D005_CAR_J.SYOCHI_C_SYAIN_ID))
                    _D005_CAR_J.SYOCHI_C_YMDHNS = .Item(NameOf(_D005_CAR_J.SYOCHI_C_YMDHNS))
                    _D005_CAR_J.KYOIKU_FILE_PATH = .Item(NameOf(_D005_CAR_J.KYOIKU_FILE_PATH))
                    _D005_CAR_J.ZESEI_SYOCHI_YUKO_UMU = .Item(NameOf(_D005_CAR_J.ZESEI_SYOCHI_YUKO_UMU))
                    _D005_CAR_J.SYOSAI_FILE_PATH = .Item(NameOf(_D005_CAR_J.SYOSAI_FILE_PATH))
                    _D005_CAR_J.GOKI = .Item(NameOf(_D005_CAR_J.GOKI))
                    _D005_CAR_J.LOT = .Item(NameOf(_D005_CAR_J.LOT))
                    _D005_CAR_J.KENSA_TANTO_ID = .Item(NameOf(_D005_CAR_J.KENSA_TANTO_ID))
                    _D005_CAR_J.KENSA_TOROKU_YMDHNS = .Item(NameOf(_D005_CAR_J.KENSA_TOROKU_YMDHNS))
                    _D005_CAR_J.KENSA_GL_SYAIN_ID = .Item(NameOf(_D005_CAR_J.KENSA_GL_SYAIN_ID))
                    _D005_CAR_J.KENSA_GL_YMDHNS = .Item(NameOf(_D005_CAR_J.KENSA_GL_YMDHNS))
                    _D005_CAR_J.ADD_SYAIN_ID = .Item(NameOf(_D005_CAR_J.ADD_SYAIN_ID))
                    _D005_CAR_J.ADD_YMDHNS = .Item(NameOf(_D005_CAR_J.ADD_YMDHNS))
                    _D005_CAR_J.UPD_SYAIN_ID = .Item(NameOf(_D005_CAR_J.UPD_SYAIN_ID))
                    _D005_CAR_J.UPD_YMDHNS = .Item(NameOf(_D005_CAR_J.UPD_YMDHNS))
                    _D005_CAR_J.DEL_SYAIN_ID = .Item(NameOf(_D005_CAR_J.DEL_SYAIN_ID))
                    _D005_CAR_J.DEL_YMDHNS = .Item(NameOf(_D005_CAR_J.DEL_YMDHNS))
                End With
            Else
                'Error
                MessageBox.Show("該当報告書Noのデータが見つまりませんでした。" & vbCrLf & "報告書No=" & PrHOKOKU_NO, "該当データなし", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Return False
            End If

            '原因分析区分
            _D006_CAR_GENIN_List.Clear()

            sbSQL.Remove(0, sbSQL.Length)
            sbSQL.Append("SELECT")
            sbSQL.Append(" *")
            sbSQL.Append(" FROM V006_CAR_GENIN")
            sbSQL.Append(" WHERE HOKOKU_NO='" & PrHOKOKU_NO & "'")
            sbSQL.Append(" ORDER BY RENBAN")
            Using DBa As ClsDbUtility = DBOpen()
                dsList = DBa.GetDataSet(sbSQL.ToString, conblnNonMsg)
            End Using

            For Each row As DataRow In dsList.Tables(0).Rows
                _D006_CAR_GENIN_List.Add(New MODEL.D006_CAR_GENIN With {.HOKOKU_NO = dsList.Tables(0).Rows(0).Item(NameOf(.HOKOKU_NO)),
                                                                       .RENBAN = dsList.Tables(0).Rows(0).Item(NameOf(.RENBAN)),
                                                                       .GENIN_BUNSEKI_KB = dsList.Tables(0).Rows(0).Item(NameOf(.GENIN_BUNSEKI_KB)),
                                                                       .GENIN_BUNSEKI_S_KB = dsList.Tables(0).Rows(0).Item(NameOf(.GENIN_BUNSEKI_S_KB)),
                                                                       .DAIHYO_FG = dsList.Tables(0).Rows(0).Item(NameOf(.DAIHYO_FG)),
                                                                       .ADD_SYAIN_ID = dsList.Tables(0).Rows(0).Item(NameOf(.ADD_SYAIN_ID)),
                                                                       .ADD_YMDHNS = dsList.Tables(0).Rows(0).Item(NameOf(.ADD_YMDHNS))})
            Next row

        Catch ex As Exception
            EM.ErrorSyori(ex, False, conblnNonMsg)
            Return Nothing
        End Try
    End Function



#End Region

    Private Function FunGetCurrentStageName(ByVal intSYONIN_HOKOKUSYO_ID As Integer, ByVal strHOKOKU_NO As String) As String
        Dim sbSQL As New System.Text.StringBuilder
        Dim dsList As New DataSet

        sbSQL.Remove(0, sbSQL.Length)
        sbSQL.Append("SELECT")
        sbSQL.Append(" *")
        sbSQL.Append(" FROM " & NameOf(MODEL.V003_SYONIN_J_KANRI) & " ")
        sbSQL.Append(" WHERE SYONIN_HOKOKUSYO_ID=" & intSYONIN_HOKOKUSYO_ID & "")
        sbSQL.Append(" AND HOKOKU_NO='" & strHOKOKU_NO & "'")
        sbSQL.Append(" ORDER BY SYONIN_JUN DESC")
        Using DB As ClsDbUtility = DBOpen()
            dsList = DB.GetDataSet(sbSQL.ToString, conblnNonMsg)
        End Using

        If dsList.Tables(0).Rows.Count = 0 Then
            Return Nothing
        Else
            Return ""
        End If
    End Function

#End Region


End Class