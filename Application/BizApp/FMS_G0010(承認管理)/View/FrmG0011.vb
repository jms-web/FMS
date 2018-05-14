Imports JMS_COMMON.ClsPubMethod


Public Class FrmG0011

#Region "定数・変数"
    ''' <summary>
    ''' タブ非表示管理用
    ''' </summary>
    Private _tabPageManager As TabPageManager


#End Region

#Region "プロパティ"
    ''' <summary>
    ''' 処理モード
    ''' </summary>
    Public Property PrMODE As Integer

    ''' <summary>
    ''' 追加更新レコードのキー
    ''' </summary>
    Public Property PrPKeys As String

    ''' <summary>
    ''' 一覧の選択行データ
    ''' </summary>
    Public Property PrDataRow As DataRow

    '現在のステージ 承認順
    Public Property PrCurrentStage As Integer

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
        'MyBase.ToolTip.SetToolTip(Me.cmdFunc3, My.Resources.infoToolTipMsgNotFoundData)
        MyBase.ToolTip.SetToolTip(Me.cmdFunc4, "新規登録時は使用出来ません")
        MyBase.ToolTip.SetToolTip(Me.cmdFunc5, "新規登録時は使用出来ません")
        MyBase.ToolTip.SetToolTip(Me.cmdFunc9, "新規登録時は使用出来ません")
        MyBase.ToolTip.SetToolTip(Me.cmdFunc10, "新規登録時は使用出来ません")
        MyBase.ToolTip.SetToolTip(Me.cmdFunc11, "新規登録時は使用出来ません")

        D003NCRJBindingSource.DataSource = _D003_NCR_J

        mtxHOKUKO_NO.ReadOnly = True
        dtDraft.Enabled = False
        cmbAddTanto.Enabled = False
    End Sub

#End Region

#Region "Form関連"

#Region "LOAD"
    Private Sub FrmLoad(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        Try
            '-----フォーム初期設定(親フォームから呼び出し)
            Call FunFormCommonSetting(pub_APP_INFO, pub_SYAIN_INFO, My.Application.Info.Version.ToString)
            Me.Text = "不適合製品処置報告書(Non-Conformance Report)"
            lblTytle.Text = Me.Text

            '-----コントロールデータソース設定
            'Dim dtAddTANTO As DataTable = tblTANTO_SYONIN.
            '                                ExcludeDeleted.
            '                                AsEnumerable.
            '                                Where(Function(r) r.Field(Of Integer)("SYONIN_JUN") = ENM_NCR_STAGE._10_起草入力 And r.Field(Of Integer)("SYONIN_HOKOKUSYO_ID") = ENM_SYONIN_HOKOKU_ID._1_NCR).
            '                                CopyToDataTable
            cmbAddTanto.SetDataSource(tblTANTO, ENM_COMBO_SELECT_VALUE_TYPE._0_Required)

            cmbBUMON.SetDataSource(tblBUMON.ExcludeDeleted, ENM_COMBO_SELECT_VALUE_TYPE._0_Required)
            cmbKISYU.SetDataSource(tblKISYU.ExcludeDeleted, ENM_COMBO_SELECT_VALUE_TYPE._0_Required)
            cmbBUHIN_BANGO.SetDataSource(tblBUHIN.ExcludeDeleted, ENM_COMBO_SELECT_VALUE_TYPE._0_Required)
            cmbFUTEKIGO_STATUS.SetDataSource(tblFUTEKIGO_STATUS_KB.ExcludeDeleted, ENM_COMBO_SELECT_VALUE_TYPE._0_Required)
            cmbFUTEKIGO_KB.SetDataSource(tblFUTEKIGO_KB.ExcludeDeleted, ENM_COMBO_SELECT_VALUE_TYPE._0_Required)

            'バインディング
            Call FunSetBinding()

            '既定値の設定

            '''-----イベントハンドラ設定
            'AddHandler Me.cmbKOMO_NM.SelectedValueChanged, AddressOf SearchFilterValueChanged
            'AddHandler Me.chkDeletedRowVisibled.CheckedChanged, AddressOf SearchFilterValueChanged



            '-----処理モード別画面初期化
            Call FunInitializeControls(PrMODE)
        Finally
            Call FunInitFuncButtonEnabled()
        End Try
    End Sub


#End Region

#Region "KEYDOWN"
    'KEYDOWN
    Private Sub FrmMBCA000MENU_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        Dim KeyCode As Short = e.KeyCode

        Try
            '押下されたキーコード取得
            KeyCode = e.KeyCode

            If (KeyCode = Windows.Forms.Keys.A) And (e.Modifiers = Keys.Control + Keys.Shift) Then

                Call FunSetAllTabPages()
            End If

        Catch ex As Exception
            EM.ErrorSyori(ex, False, conblnNonMsg)
        End Try

    End Sub
#End Region

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
                Case 1  '保存
                    If MessageBox.Show("入力内容を保存しますか？", "登録確認", MessageBoxButtons.YesNo, MessageBoxIcon.Information) = DialogResult.Yes Then
                        If FunSAVE() Then
                            Me.DialogResult = DialogResult.OK
                            MessageBox.Show("入力内容を保存しました", "保存完了", MessageBoxButtons.OK, MessageBoxIcon.Information)
                        End If
                    End If

                Case 2  '承認申請
                    If MessageBox.Show("申請しますか？", "申請処理確認", MessageBoxButtons.YesNo, MessageBoxIcon.Information) = DialogResult.Yes Then
                        If FunREQUEST() Then
                            MessageBox.Show("申請しました", "申請処理完了", MessageBoxButtons.OK, MessageBoxIcon.Information)
                            Me.DialogResult = DialogResult.OK

                            'SPEC: 2.(3).E.④
                            Me.Close()
                        End If
                    End If

                Case 4  '転送
                    MessageBox.Show("未実装", "", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Case 5  '差戻し
                    MessageBox.Show("未実装", "", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Case 9  'CAR編集
                    Call OpenFormCAR()
                    'Dim strFileName As String = pub_APP_INFO.strTitle & "_" & DateTime.Today.ToString("yyyyMMdd") & ".CSV"
                    'Call FunCSV_OUT(Me.dgvDATA.DataSource, strFileName, pub_APP_INFO.strOUTPUT_PATH)

                Case 10  'レポート印刷
                    MessageBox.Show("未実装", "", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Case 11 '履歴表示
                    MessageBox.Show("未実装", "", MessageBoxButtons.OK, MessageBoxIcon.Information)
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
            Call FunInitFuncButtonEnabled()

            '[アクティブ]
            Me.PrPG_STATUS = ENM_PG_STATUS._2_ACTIVE
        End Try

    End Sub

#End Region

#Region "保存"
    Private Function FunSAVE() As Boolean
        Dim dsList As New DataSet
        Dim sbSQL As New System.Text.StringBuilder


        Try
            '-----入力チェック
            If FunCheckInput() = False Then
                Return False
            End If

            'SPEC: 2.(3).D.①.レコード更新
            Using DB As ClsDbUtility = DBOpen()
                Dim intRET As Integer
                Dim sqlEx As New Exception
                Dim blnErr As Boolean

                Try
                    DB.BeginTransaction()

                    '-----報告書No取得
                    sbSQL.Remove(0, sbSQL.Length)
                    sbSQL.Append("SELECT * FROM " & NameOf(MODEL.M001_SETTING) & "")
                    dsList = DB.GetDataSet(sbSQL.ToString, conblnNonMsg)
                    If dsList.Tables(0).Rows.Count > 0 Then '存在時
                        _D003_NCR_J.HOKOKU_NO = dsList.Tables(0).Rows(0).Item(0)
                    End If

                    '-----MERGE
                    sbSQL.Remove(0, sbSQL.Length)
                    sbSQL.Append("MERGE INTO " & NameOf(MODEL.D003_NCR_J) & " AS SrcT")
                    sbSQL.Append(" USING (")
                    sbSQL.Append(" SELECT")
                    sbSQL.Append(" '" & _D003_NCR_J.HOKOKU_NO & "' AS " & NameOf(_D003_NCR_J.HOKOKU_NO))
                    sbSQL.Append(" ,'" & _D003_NCR_J.BUMON_KB & "' AS " & NameOf(_D003_NCR_J.BUMON_KB))
                    sbSQL.Append(" ,'" & _D003_NCR_J._CLOSE_FLG & "' AS " & NameOf(_D003_NCR_J.CLOSE_FLG))
                    sbSQL.Append(" ," & _D003_NCR_J.KISYU_ID & " AS " & NameOf(_D003_NCR_J.KISYU_ID))
                    sbSQL.Append(" ,'" & _D003_NCR_J.SYANAI_CD & "' AS " & NameOf(_D003_NCR_J.SYANAI_CD))
                    sbSQL.Append(" ,'" & _D003_NCR_J.BUHIN_BANGO & "' AS " & NameOf(_D003_NCR_J.BUHIN_BANGO))
                    sbSQL.Append(" ,'" & _D003_NCR_J.BUHIN_NAME & "' AS " & NameOf(_D003_NCR_J.BUHIN_NAME))
                    sbSQL.Append(" ,'" & _D003_NCR_J.GOKI & "' AS " & NameOf(_D003_NCR_J.GOKI))
                    sbSQL.Append(" ," & _D003_NCR_J.SURYO & " AS " & NameOf(_D003_NCR_J.SURYO))
                    sbSQL.Append(" ,'" & _D003_NCR_J._SAIHATU & "' AS " & NameOf(_D003_NCR_J.SAIHATU))
                    sbSQL.Append(" ,'" & _D003_NCR_J.FUTEKIGO_JYOTAI_KB & "' AS " & NameOf(_D003_NCR_J.FUTEKIGO_JYOTAI_KB))
                    sbSQL.Append(" ,'" & _D003_NCR_J.FUTEKIGO_NAIYO & "' AS " & NameOf(_D003_NCR_J.FUTEKIGO_NAIYO))
                    sbSQL.Append(" ,'" & _D003_NCR_J.FUTEKIGO_KB & "' AS " & NameOf(_D003_NCR_J.FUTEKIGO_KB))
                    sbSQL.Append(" ,'" & _D003_NCR_J.FUTEKIGO_S_KB & "' AS " & NameOf(_D003_NCR_J.FUTEKIGO_S_KB))
                    sbSQL.Append(" ,'" & _D003_NCR_J.ZUMEN_KIKAKU & "' AS " & NameOf(_D003_NCR_J.ZUMEN_KIKAKU))
                    sbSQL.Append(" ,'" & _D003_NCR_J.YOKYU_NAIYO & "' AS " & NameOf(_D003_NCR_J.YOKYU_NAIYO))
                    sbSQL.Append(" ,'" & _D003_NCR_J.KANSATU_KEKKA & "' AS " & NameOf(_D003_NCR_J.KANSATU_KEKKA))
                    sbSQL.Append(" ,'" & _D003_NCR_J._SAIKAKO_SIJI_FLG & "' AS " & NameOf(_D003_NCR_J.SAIKAKO_SIJI_FLG))
                    sbSQL.Append(" ,'" & _D003_NCR_J.FILE_PATH & "' AS " & NameOf(_D003_NCR_J.FILE_PATH))
                    sbSQL.Append(" ,'" & _D003_NCR_J.G_FILE_PATH1 & "' AS " & NameOf(_D003_NCR_J.G_FILE_PATH1))
                    sbSQL.Append(" ,'" & _D003_NCR_J.G_FILE_PATH2 & "' AS " & NameOf(_D003_NCR_J.G_FILE_PATH2))
                    sbSQL.Append(" ," & _D003_NCR_J.ADD_SYAIN_ID & " AS " & NameOf(_D003_NCR_J.ADD_SYAIN_ID))
                    sbSQL.Append(" ,dbo.GetSysDateString() AS " & NameOf(_D003_NCR_J.ADD_YMDHNS))
                    sbSQL.Append(" ," & pub_SYAIN_INFO.SYAIN_ID & " AS " & NameOf(_D003_NCR_J.UPD_SYAIN_ID))
                    sbSQL.Append(" ,dbo.GetSysDateString() AS " & NameOf(_D003_NCR_J.UPD_YMDHNS))
                    sbSQL.Append(" ,0 AS " & NameOf(_D003_NCR_J.DEL_SYAIN_ID))
                    sbSQL.Append(" ,' ' AS " & NameOf(_D003_NCR_J.DEL_YMDHNS))
                    sbSQL.Append(" ) AS WK")
                    sbSQL.Append(" ON (SrcT.HOKOKU_NO = WK.HOKOKU_NO)")
                    'UPDATE
                    sbSQL.Append(" WHEN MATCHED THEN")
                    sbSQL.Append(" UPDATE SET")
                    sbSQL.Append("  SrcT." & NameOf(_D003_NCR_J.KISYU_ID) & " = WK." & NameOf(_D003_NCR_J.KISYU_ID))
                    sbSQL.Append(" ,SrcT." & NameOf(_D003_NCR_J.SYANAI_CD) & " = WK." & NameOf(_D003_NCR_J.SYANAI_CD))
                    sbSQL.Append(" ,SrcT." & NameOf(_D003_NCR_J.BUHIN_BANGO) & " = WK." & NameOf(_D003_NCR_J.BUHIN_BANGO))
                    sbSQL.Append(" ,SrcT." & NameOf(_D003_NCR_J.BUHIN_NAME) & " = WK." & NameOf(_D003_NCR_J.BUHIN_NAME))
                    sbSQL.Append(" ,SrcT." & NameOf(_D003_NCR_J.GOKI) & " = WK." & NameOf(_D003_NCR_J.GOKI))
                    sbSQL.Append(" ,SrcT." & NameOf(_D003_NCR_J.SURYO) & " = WK." & NameOf(_D003_NCR_J.SURYO))
                    sbSQL.Append(" ,SrcT." & NameOf(_D003_NCR_J.SAIHATU) & " = WK." & NameOf(_D003_NCR_J.SAIHATU))
                    sbSQL.Append(" ,SrcT." & NameOf(_D003_NCR_J.FUTEKIGO_JYOTAI_KB) & " = WK." & NameOf(_D003_NCR_J.FUTEKIGO_JYOTAI_KB))
                    sbSQL.Append(" ,SrcT." & NameOf(_D003_NCR_J.FUTEKIGO_NAIYO) & " = WK." & NameOf(_D003_NCR_J.FUTEKIGO_NAIYO))
                    sbSQL.Append(" ,SrcT." & NameOf(_D003_NCR_J.FUTEKIGO_KB) & " = WK." & NameOf(_D003_NCR_J.FUTEKIGO_KB))
                    sbSQL.Append(" ,SrcT." & NameOf(_D003_NCR_J.FUTEKIGO_S_KB) & " = WK." & NameOf(_D003_NCR_J.FUTEKIGO_S_KB))
                    sbSQL.Append(" ,SrcT." & NameOf(_D003_NCR_J.ZUMEN_KIKAKU) & " = WK." & NameOf(_D003_NCR_J.ZUMEN_KIKAKU))

                    sbSQL.Append(" ,SrcT." & NameOf(_D003_NCR_J.YOKYU_NAIYO) & " = WK." & NameOf(_D003_NCR_J.YOKYU_NAIYO))
                    sbSQL.Append(" ,SrcT." & NameOf(_D003_NCR_J.SAIKAKO_SIJI_FLG) & " = WK." & NameOf(_D003_NCR_J.SAIKAKO_SIJI_FLG))
                    sbSQL.Append(" ,SrcT." & NameOf(_D003_NCR_J.FILE_PATH) & " = WK." & NameOf(_D003_NCR_J.FILE_PATH))
                    sbSQL.Append(" ,SrcT." & NameOf(_D003_NCR_J.G_FILE_PATH1) & " = WK." & NameOf(_D003_NCR_J.G_FILE_PATH1))
                    sbSQL.Append(" ,SrcT." & NameOf(_D003_NCR_J.G_FILE_PATH2) & " = WK." & NameOf(_D003_NCR_J.G_FILE_PATH2))
                    sbSQL.Append(" ,SrcT." & NameOf(_D003_NCR_J.UPD_SYAIN_ID) & " = WK." & NameOf(_D003_NCR_J.UPD_SYAIN_ID))
                    sbSQL.Append(" ,SrcT." & NameOf(_D003_NCR_J.UPD_YMDHNS) & " = WK." & NameOf(_D003_NCR_J.UPD_YMDHNS))
                    'INSERT
                    sbSQL.Append(" WHEN NOT MATCHED THEN ")
                    sbSQL.Append(" INSERT(")
                    sbSQL.Append("  " & NameOf(_D003_NCR_J.HOKOKU_NO))
                    sbSQL.Append(" ," & NameOf(_D003_NCR_J.BUMON_KB))
                    sbSQL.Append(" ," & NameOf(_D003_NCR_J.CLOSE_FLG))
                    sbSQL.Append(" ," & NameOf(_D003_NCR_J.KISYU_ID))
                    sbSQL.Append(" ," & NameOf(_D003_NCR_J.SYANAI_CD))
                    sbSQL.Append(" ," & NameOf(_D003_NCR_J.BUHIN_BANGO))
                    sbSQL.Append(" ," & NameOf(_D003_NCR_J.BUHIN_NAME))
                    sbSQL.Append(" ," & NameOf(_D003_NCR_J.GOKI))
                    sbSQL.Append(" ," & NameOf(_D003_NCR_J.SURYO))
                    sbSQL.Append(" ," & NameOf(_D003_NCR_J.SAIHATU))
                    sbSQL.Append(" ," & NameOf(_D003_NCR_J.FUTEKIGO_JYOTAI_KB))
                    sbSQL.Append(" ," & NameOf(_D003_NCR_J.FUTEKIGO_NAIYO))
                    sbSQL.Append(" ," & NameOf(_D003_NCR_J.FUTEKIGO_KB))
                    sbSQL.Append(" ," & NameOf(_D003_NCR_J.FUTEKIGO_S_KB))
                    sbSQL.Append(" ," & NameOf(_D003_NCR_J.ZUMEN_KIKAKU))
                    sbSQL.Append(" ," & NameOf(_D003_NCR_J.YOKYU_NAIYO))
                    sbSQL.Append(" ," & NameOf(_D003_NCR_J.KANSATU_KEKKA))
                    sbSQL.Append(" ," & NameOf(_D003_NCR_J.SAIKAKO_SIJI_FLG))
                    sbSQL.Append(" ," & NameOf(_D003_NCR_J.FILE_PATH))
                    sbSQL.Append(" ," & NameOf(_D003_NCR_J.G_FILE_PATH1))
                    sbSQL.Append(" ," & NameOf(_D003_NCR_J.G_FILE_PATH2))
                    sbSQL.Append(" ," & NameOf(_D003_NCR_J.ADD_SYAIN_ID))
                    sbSQL.Append(" ," & NameOf(_D003_NCR_J.ADD_YMDHNS))
                    sbSQL.Append(" ," & NameOf(_D003_NCR_J.UPD_SYAIN_ID))
                    sbSQL.Append(" ," & NameOf(_D003_NCR_J.UPD_YMDHNS))
                    sbSQL.Append(" ," & NameOf(_D003_NCR_J.DEL_SYAIN_ID))
                    sbSQL.Append(" ," & NameOf(_D003_NCR_J.DEL_YMDHNS))
                    sbSQL.Append(" ) VALUES(")
                    sbSQL.Append("  WK." & NameOf(_D003_NCR_J.HOKOKU_NO))
                    sbSQL.Append(" ,WK." & NameOf(_D003_NCR_J.BUMON_KB))
                    sbSQL.Append(" ,WK." & NameOf(_D003_NCR_J.CLOSE_FLG))
                    sbSQL.Append(" ,WK." & NameOf(_D003_NCR_J.KISYU_ID))
                    sbSQL.Append(" ,WK." & NameOf(_D003_NCR_J.SYANAI_CD))
                    sbSQL.Append(" ,WK." & NameOf(_D003_NCR_J.BUHIN_BANGO))
                    sbSQL.Append(" ,WK." & NameOf(_D003_NCR_J.BUHIN_NAME))
                    sbSQL.Append(" ,WK." & NameOf(_D003_NCR_J.GOKI))
                    sbSQL.Append(" ,WK." & NameOf(_D003_NCR_J.SURYO))
                    sbSQL.Append(" ,WK." & NameOf(_D003_NCR_J.SAIHATU))
                    sbSQL.Append(" ,WK." & NameOf(_D003_NCR_J.FUTEKIGO_JYOTAI_KB))
                    sbSQL.Append(" ,WK." & NameOf(_D003_NCR_J.FUTEKIGO_NAIYO))
                    sbSQL.Append(" ,WK." & NameOf(_D003_NCR_J.FUTEKIGO_KB))
                    sbSQL.Append(" ,WK." & NameOf(_D003_NCR_J.FUTEKIGO_S_KB))
                    sbSQL.Append(" ,WK." & NameOf(_D003_NCR_J.ZUMEN_KIKAKU))
                    sbSQL.Append(" ,WK." & NameOf(_D003_NCR_J.YOKYU_NAIYO))
                    sbSQL.Append(" ,WK." & NameOf(_D003_NCR_J.KANSATU_KEKKA))
                    sbSQL.Append(" ,WK." & NameOf(_D003_NCR_J.SAIKAKO_SIJI_FLG))
                    sbSQL.Append(" ,WK." & NameOf(_D003_NCR_J.FILE_PATH))
                    sbSQL.Append(" ,WK." & NameOf(_D003_NCR_J.G_FILE_PATH1))
                    sbSQL.Append(" ,WK." & NameOf(_D003_NCR_J.G_FILE_PATH2))
                    sbSQL.Append(" ,WK." & NameOf(_D003_NCR_J.ADD_SYAIN_ID))
                    sbSQL.Append(" ,WK." & NameOf(_D003_NCR_J.ADD_YMDHNS))
                    sbSQL.Append(" ,WK." & NameOf(_D003_NCR_J.UPD_SYAIN_ID))
                    sbSQL.Append(" ,WK." & NameOf(_D003_NCR_J.UPD_YMDHNS))
                    sbSQL.Append(" ,WK." & NameOf(_D003_NCR_J.DEL_SYAIN_ID))
                    sbSQL.Append(" ,WK." & NameOf(_D003_NCR_J.DEL_YMDHNS))
                    sbSQL.Append(" );")

                    intRET = DB.ExecuteNonQuery(sbSQL.ToString, conblnNonMsg, sqlEx)
                    If intRET <> 1 Then
                        'エラーログ出力
                        Dim strErrMsg As String = My.Resources.ErrLogSqlExecutionFailure & sbSQL.ToString & "|" & sqlEx.Message
                        WL.WriteLogDat(strErrMsg)
                        blnErr = True
                        Return False
                    End If
                Finally
                    'トランザクション
                    DB.Commit(Not blnErr)
                End Try
            End Using

            'SPEC: 2.(3).D.②.添付ファイル保存


            '存在チェック
            'If PrDt.AsEnumerable.Where(Function(r) r.Field(Of Integer)("HOKOKUSYO_NO") = 18011).ToList.Count = 0 Then
            '    Dim dr As DataRow = PrDt.NewRow
            '    Dim intNextHOKOKUSYO_NO As Integer
            '    Using DB As ClsDbUtility = DBOpen()
            '        intNextHOKOKUSYO_NO = FunGetCodeMastaValue(DB, "報告書NO管理", "1")
            '    End Using

            '    'dr("HOKOKUSYO_NO") = intNextHOKOKUSYO_NO
            '    'dr("CLOSE_FLG") = "0"
            '    'dr("SYONIN_JUN") = 10
            '    'dr("SYONIN_NAIYO") = mtxST01_NextStageName.Text.Split(" ")(1)
            '    'dr("SYONIN_HOKOKUSYO_ID") = "1"
            '    'dr("SYONIN_HOKOKUSYO_NAME") = "不適合製品処置報告書"
            '    'dr("SYONIN_HOKOKUSYO_R_NAME") = "NCR"
            '    'dr("SYOCHI_SYAIN_ID") = pub_SYAIN_INFO.SYAIN_ID
            '    'dr("SYOCHI_SYAIN_NAME") = pub_SYAIN_INFO.SYAIN_NAME
            '    'dr("TAIRYU") = 0
            '    'dr("KISYU_ID") = ""
            '    'dr("KISYU") = ""
            '    'dr("KISYU_NAME") = ""
            '    'dr("BUHIN_BANGO") = ""
            '    'dr("BUHIN_NAME") = ""
            '    'dr("JIZEN_SINSA_HANTEI_KB") = ""
            '    'dr("JIZEN_SINSA_HANTEI_KB_DISP") = ""
            '    'dr("SAISIN_IINKAI_HANTEI_KB") = ""
            '    'dr("SAISIN_IINKAI_HANTEI_KB_DISP") = ""
            '    'dr("ADD_YMD") = dtDraft.ValueDate.ToString("yyyyMMdd")
            '    'dr("SYOCHI_YMD") = " "
            '    'dr("MODOSI_SYONIN_JUN") = 0
            '    'dr("MODOSI_SYONIN_NAIYO") = ""
            '    'dr("MODOSI_RIYU") = ""
            '    'dr("MODOSI_TAIRYU") = 6
            '    'PrDt.Rows.Add(dr)
            'Else

            'End If



            Return True
        Catch ex As Exception
            Throw
            Return False
        Finally
            dsList.Dispose()
        End Try
    End Function
#End Region

#Region "申請"
    Private Function FunREQUEST() As Boolean
        Dim sbSQL As New System.Text.StringBuilder
        Dim dsList As New System.Data.DataSet

        Try

            'SPEC: 2.(3).E.①
            '入力チェック
            If FunCheckInput() = False Then
                Return False
            End If


            'SPEC: 2.(3).E.② 
            If FunSAVE() Then
                'MessageBox.Show("レコード登録失敗")
                Return False
            End If

            'SPEC: 2.(3).E.③ 報告書操作履歴登録





            Using DB As ClsDbUtility = DBOpen()
                Dim intRET As Integer
                Dim sqlEx As Exception = Nothing
                Dim blnErr As Boolean

                Try
                    'トランザクション
                    DB.BeginTransaction()

                    ''-----存在チェック
                    'sbSQL.Append("SELECT * FROM " & NameOf(MODEL.M001_SETTING) & " ")
                    'sbSQL.Append("WHERE")
                    'sbSQL.Append(" ITEM_NAME ='" & Me.cmbKOMO_NM.Text.Trim & "' ")
                    'sbSQL.Append(" AND ITEM_VALUE ='" & Me.mtxVALUE.Text.Trim & "' ")
                    'sbSQL.Append(" AND UPD_YMDHNS ='" & PrDataRow.Item("UPD_YMDHNS").ToString & "' ")
                    'dsList = DB.GetDataSet(sbSQL.ToString)
                    'If dsList.Tables(0).Rows.Count = 0 Then '非存在時
                    '    MessageBox.Show(String.Format(My.Resources.infoSearchDataChange), My.Resources.infoTilteDuplicateCheck, MessageBoxButtons.OK, MessageBoxIcon.Information)
                    '    Return False
                    'End If

                    '-----UPDATE(表示順以外)
                    'sbSQL.Remove(0, sbSQL.Length)
                    'sbSQL.Append("UPDATE " & NameOf(MODEL.M001_SETTING) & " SET")
                    'sbSQL.Append(" ITEM_DISP ='" & Me.mtxDISP.Text.Trim & "'")
                    'sbSQL.Append(" ,DEF_FLG ='" & IIf(Me.chkDefaultVaue.Checked = True, "1", "0") & "'")
                    'sbSQL.Append(" ,BIKOU ='" & Me.mtxBIKOU.Text.Trim & "'")
                    'sbSQL.Append(" ,UPD_SYAIN_ID = " & pub_SYAIN_INFO.SYAIN_ID)
                    'sbSQL.Append(" ,UPD_YMDHNS = dbo.GetSysDateString()")
                    'sbSQL.Append("WHERE")
                    'sbSQL.Append(" ITEM_NAME ='" & Me.cmbKOMO_NM.Text.Trim & "' ")
                    'sbSQL.Append(" AND ITEM_VALUE ='" & Me.mtxVALUE.Text.Trim & "' ")

                    intRET = DB.ExecuteNonQuery(sbSQL.ToString, conblnNonMsg, sqlEx)
                    If intRET <> 1 Then
                        'エラーログ
                        Dim strErrMsg As String = My.Resources.ErrLogSqlExecutionFailure & sbSQL.ToString & "|" & sqlEx.Message
                        WL.WriteLogDat(strErrMsg)
                        blnErr = True
                        Return False
                    End If
                Finally
                    'トランザクション
                    DB.Commit(Not blnErr)
                End Try
            End Using

            Return True
        Catch ex As Exception
            Throw
            Return False
        Finally
            dsList.Dispose()
        End Try
    End Function
#End Region

#Region "CAR"
    Private Function OpenFormCAR() As Boolean
        Dim frmDLG As New FrmG0012
        Dim dlgRET As DialogResult
        'Dim PKeys As String

        Try


            dlgRET = frmDLG.ShowDialog(Me)


            If dlgRET = Windows.Forms.DialogResult.Cancel Then
                Return False
            Else
                '追加選択行選択
            End If


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

#Region "入力チェック"
    Public Function FunCheckInput() As Boolean
        Try

            '項目名
            'If cmbKOMO_NM.Text.IsNullOrWhiteSpace Then
            '    MessageBox.Show(String.Format(My.Resources.infoMsgRequireSelectOrInput, "項目名"), My.Resources.infoTitleInputCheck, MessageBoxButtons.OK, MessageBoxIcon.Information)
            '    Me.cmbKOMO_NM.Focus()
            '    Return False
            'End If

            ''項目値
            'If Me.mtxVALUE.Text.IsNullOrWhiteSpace Then
            '    MessageBox.Show(String.Format(My.Resources.infoMsgRequireInput, "項目値"), My.Resources.infoTitleInputCheck, MessageBoxButtons.OK, MessageBoxIcon.Information)
            '    Me.mtxVALUE.Focus()
            '    Return False
            'End If

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
    Private Function FunInitFuncButtonEnabled() As Boolean
        Try

            For intFunc As Integer = 1 To 12
                With Me.Controls("cmdFunc" & intFunc)
                    If .Text.Length = 0 OrElse .Text.Substring(0, .Text.IndexOf("(")).IsNullOrWhiteSpace Then
                        .Text = ""
                        .Visible = False
                    End If
                End With
            Next intFunc

            If PrMODE = ENM_DATA_OPERATION_MODE._1_ADD Then
                cmdFunc4.Enabled = False
                cmdFunc5.Enabled = False
                cmdFunc9.Enabled = False
                cmdFunc10.Enabled = False
                cmdFunc11.Enabled = False
            Else
                cmdFunc4.Enabled = True
                cmdFunc5.Enabled = True
                cmdFunc9.Enabled = True
                cmdFunc10.Enabled = True
                cmdFunc11.Enabled = True
            End If


            'UNDONE: ユーザー権限による制御

            Return True
        Catch ex As Exception
            EM.ErrorSyori(ex, False, conblnNonMsg)
            Return False
        End Try
    End Function

#End Region

#End Region

#Region "コントロールイベント"

#Region "共通"

    '検索フィルタ変更
    Private Sub SearchFilterValueChanged(sender As System.Object, e As System.EventArgs)
        '検索
        Me.cmdFunc1.PerformClick()

    End Sub

    Private Sub CmbFUTEKIGO_STATUS_SelectedValueChanged(sender As Object, e As EventArgs) Handles cmbFUTEKIGO_STATUS.SelectedValueChanged
        'If cmbFUTEKIGO_STATUS.SelectedValue = 1 Then

        'End If
    End Sub

    '部門変更時
    Private Sub CmbBUMON_SelectedValueChanged(sender As Object, e As EventArgs) Handles cmbBUMON.SelectedValueChanged
        Select Case cmbBUMON.SelectedValue
            Case Context.ENM_BUMON_KB._4_LP
                lblSYANAI_CD.Visible = True
                mtxSYANAI_CD.Visible = True
            Case Else
                lblSYANAI_CD.Visible = False
                mtxSYANAI_CD.Visible = False
                mtxSYANAI_CD.Text = ""
        End Select
    End Sub

    '不適合区分
    Private Sub CmbFUTEKIGO_KB_SelectedValueChanged(sender As Object, e As EventArgs) Handles cmbFUTEKIGO_KB.SelectedValueChanged

        If cmbFUTEKIGO_KB.SelectedValue <> "" Then
            Dim dt As New DataTableEx
            Using DB As ClsDbUtility = DBOpen()
                FunGetCodeDataTable(DB, "不適合" & cmbFUTEKIGO_KB.Text.Replace("・", "") & "区分", dt)
            End Using
            cmbFUTEKIGO_S_KB.SetDataSource(dt.ExcludeDeleted, ENM_COMBO_SELECT_VALUE_TYPE._0_Required)
        Else
            cmbFUTEKIGO_S_KB.DataSource = Nothing
        End If

    End Sub
#End Region

#Region "STAGE別"

#Region "   STAGE1"

#End Region
#Region "   STAGE2"

#End Region
#Region "   STAGE3"

#End Region
#Region "   STAGE4"

    Private Sub rbtnST04_ZESEI_YES_CheckedChanged(sender As Object, e As EventArgs) Handles rbtnST04_ZESEI_YES.CheckedChanged
        If rbtnST04_ZESEI_YES.Checked Then
            lbltxtST04_RIYU.Visible = False
            txtST04_RIYU.Visible = False
        Else
            lbltxtST04_RIYU.Visible = True
            txtST04_RIYU.Visible = True
        End If
    End Sub

    Private Sub ChkZESEI_SYOCHI_YOHI_KB_CheckedChanged(sender As Object, e As EventArgs) Handles chkST04_ZESEI_SYOCHI_YOHI_KB.CheckedChanged
        If chkST04_ZESEI_SYOCHI_YOHI_KB.Checked Then
            rbtnST04_ZESEI_YES.Checked = True
        Else
            rbtnST04_ZESEI_NO.Checked = True
        End If
    End Sub

#End Region
#Region "   STAGE5"

#End Region
#Region "   STAGE6"

#End Region
#Region "   STAGE7"

    Private Sub ChkST07_SAIKAKO_SIJI_FLG_CheckedChanged(sender As Object, e As EventArgs) Handles chkST07_SAIKAKO_SIJI_FLG.CheckedChanged
        If chkST07_SAIKAKO_SIJI_FLG.Checked Then
            rbtnST07_Yes.Checked = True
        Else
            rbtnST07_No.Checked = True
        End If
    End Sub

#End Region
#Region "   STAGE8"

#End Region
#Region "   STAGE9"

#End Region
#Region "   STAGE10"

#End Region
#Region "   STAGE11"
    Private Sub ChkST11_CheckedChanged(sender As Object, e As EventArgs) Handles chkST11_A1.CheckedChanged,
                                                                                 chkST11_B1.CheckedChanged,
                                                                                 chkST11_C1.CheckedChanged,
                                                                                 chkST11_D1.CheckedChanged,
                                                                                 chkST11_D2.CheckedChanged,
                                                                                 chkST11_E1.CheckedChanged,
                                                                                 chkST11_E2.CheckedChanged

        Dim chk As CheckBox = DirectCast(sender, CheckBox)
        If chk.Checked Then
            DirectCast(tlpST08.Controls("rbtnST11_" & chk.Name.Substring(8, 2) & "_T"), RadioButton).Checked = True
        Else
            DirectCast(tlpST08.Controls("rbtnST11_" & chk.Name.Substring(8, 2) & "_F"), RadioButton).Checked = True
        End If
    End Sub

#End Region
#Region "   STAGE12"

#End Region
#Region "添付資料"

    '添付ファイル選択
    Private Sub BtnOpenTempFileDialog_Click(sender As Object, e As EventArgs) Handles btnOpenTempFileDialog.Click
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
            lbltmpFile1.Links.Add(0, lbltmpFile1.Text.Length, ofd.FileName)
            lbltmpFile1.Tag = ofd.FileName
            lbltmpFile1.Visible = True
            lbltmpFile1_Clear.Visible = True
        End If
    End Sub

    'リンククリック
    Private Sub LbltmpFile1_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles lbltmpFile1.LinkClicked
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

    Private Sub ProcessExited(ByVal sender As Object, ByVal e As EventArgs)
        'Call SetTaskbarOverlayIcon(Nothing)
        'Call SetTaskbarInfo(ENM_TASKBAR_STATE._0_NoProgress)
    End Sub

#Region "画像1"

    '画像1選択
    Private Sub BtnOpenPict1Dialog_Click(sender As Object, e As EventArgs) Handles btnOpenPict1Dialog.Click
        Dim ofd As New OpenFileDialog With {
         .Filter = "画像(*.bmp;*.gif;*.jpg;*.png)|*.bmp;*.gif;*.jpg;*.png",
         .FilterIndex = 1,
         .Title = "添付する画像ファイルを選択してください",
         .RestoreDirectory = True
        }
        If lblPict1Path.Links.Count = 0 Then
        Else
            ofd.InitialDirectory = IO.Path.GetDirectoryName(lblPict1Path.Links(0).ToString)
        End If

        If ofd.ShowDialog() = DialogResult.OK Then
            Call SetPict1Data(ofd.FileName)
        End If
    End Sub

    '画像1クリック
    Private Sub PnlPict1_Click(sender As Object, e As EventArgs) Handles pnlPict1.Click
        If pnlPict1.Image IsNot Nothing Then
            picZoom.Image = pnlPict1.Image
            picZoom.BringToFront()
            picZoom.Visible = True
        End If
    End Sub

    Private Sub PnlPict1_DragEnter(sender As Object, e As DragEventArgs) Handles pnlPict1.DragEnter
        'ドラッグされたデータ形式を調べ、ファイルのときはコピーとする
        If e.Data.GetDataPresent(DataFormats.FileDrop) Then
            e.Effect = DragDropEffects.Copy
        Else
            e.Effect = DragDropEffects.None
        End If
    End Sub

    Private Sub PnlPict1_DragDrop(sender As Object, e As DragEventArgs) Handles pnlPict1.DragDrop
        Call SetPict1Data(e.Data.GetData(DataFormats.FileDrop, False))
    End Sub

    'リンククリア
    Private Sub LblPict1Path_Clear_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles lblPict1Path_Clear.LinkClicked
        lblPict1Path.Text = ""
        lblPict1Path.Tag = ""
        lblPict1Path.Links.Clear()
        lblPict1Path.Visible = False
        lblPict1Path_Clear.Visible = False
        pnlPict1.Image = Nothing
        pnlPict1.Cursor = Cursors.Default
    End Sub

    'Private Sub MtxPict1Path_DragEnter(sender As Object, e As DragEventArgs) Handles mtxPict1Path.DragEnter
    '    'ドラッグされたデータ形式を調べ、ファイルのときはコピーとする
    '    If e.Data.GetDataPresent(DataFormats.FileDrop) Then
    '        e.Effect = DragDropEffects.Copy
    '    Else
    '        e.Effect = DragDropEffects.None
    '    End If
    'End Sub

    'Private Sub MtxPict1Path_DragDrop(sender As Object, e As DragEventArgs) Handles mtxPict1Path.DragDrop
    '    Call SetPict1Data(CType(e.Data.GetData(DataFormats.FileDrop, False), String())(0))
    'End Sub

    Private Sub SetPict1Data(ByVal strFileName As String)
        pnlPict1.Image = Image.FromFile(strFileName)
        pnlPict1.Cursor = Cursors.Hand

        lblPict1Path.Text = CompactString(strFileName, lblPict1Path, EllipsisFormat._4_Path) 'IO.Path.GetFileName(strFileName)
        lblPict1Path.Tag = strFileName
        lblPict1Path.Links.Add(0, lblPict1Path.Text.Length, strFileName)
        lblPict1Path.Visible = True
        lblPict1Path_Clear.Visible = True
    End Sub

#End Region

#Region "画像2"

    '画像2選択
    Private Sub BtnOpenPict2Dialog_Click(sender As Object, e As EventArgs) Handles btnOpenPict2Dialog.Click
        Dim ofd As New OpenFileDialog With {
            .Filter = "画像(*.bmp;*.gif;*.jpg;*.png)|*.bmp;*.gif;*.jpg;*.png",
            .FilterIndex = 1,
            .Title = "添付する画像ファイルを選択してください",
            .RestoreDirectory = True
        }
        If lblPict2Path.Links.Count = 0 Then
        Else
            ofd.InitialDirectory = IO.Path.GetDirectoryName(lblPict2Path.Links(0).ToString)
        End If

        If ofd.ShowDialog() = DialogResult.OK Then
            Call SetPict2Data(ofd.FileName)
        End If
    End Sub

    '画像2クリック
    Private Sub PnlPict2_Click(sender As Object, e As EventArgs) Handles pnlPict2.Click
        If pnlPict2.Image IsNot Nothing Then
            picZoom.Image = pnlPict2.Image
            picZoom.BringToFront()
            picZoom.Visible = True
        End If
    End Sub

    'リンククリア
    Private Sub LblPict2Path_Clear_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles lblPict2Path_Clear.LinkClicked
        lblPict2Path.Text = ""
        lblPict2Path.Tag = ""
        lblPict2Path.Links.Clear()
        lblPict2Path.Visible = False
        lblPict2Path_Clear.Visible = False
        pnlPict2.Image = Nothing
        pnlPict2.Cursor = Cursors.Default
    End Sub

    'Private Sub PnlPict2_DragEnter(sender As Object, e As DragEventArgs) Handles pnlPict2.DragEnter
    '    'ドラッグされたデータ形式を調べ、ファイルのときはコピーとする
    '    If e.Data.GetDataPresent(DataFormats.FileDrop) Then
    '        e.Effect = DragDropEffects.Copy
    '    Else
    '        e.Effect = DragDropEffects.None
    '    End If
    'End Sub

    'Private Sub PnlPict2_DragDrop(sender As Object, e As DragEventArgs) Handles pnlPict2.DragDrop
    '    Call SetPict2Data(e.Data.GetData(DataFormats.FileDrop, False))
    'End Sub

    Private Sub MtxPict2Path_DragEnter(sender As Object, e As DragEventArgs)
        'ドラッグされたデータ形式を調べ、ファイルのときはコピーとする
        If e.Data.GetDataPresent(DataFormats.FileDrop) Then
            e.Effect = DragDropEffects.Copy
        Else
            e.Effect = DragDropEffects.None
        End If
    End Sub

    Private Sub MtxPict2Path_DragDrop(sender As Object, e As DragEventArgs)
        Call SetPict2Data(e.Data.GetData(DataFormats.FileDrop, False))
    End Sub

    Private Sub SetPict2Data(ByVal strFileName As String)
        pnlPict2.Image = Image.FromFile(strFileName)
        pnlPict2.Cursor = Cursors.Hand

        lblPict2Path.Text = CompactString(strFileName, lblPict2Path, EllipsisFormat._4_Path) 'IO.Path.GetFileName(strFileName)
        lblPict2Path.Tag = strFileName
        lblPict2Path.Links.Add(0, lblPict2Path.Text.Length, strFileName)
        lblPict2Path.Visible = True
        lblPict2Path_Clear.Visible = True
    End Sub

#End Region

    '拡大画像クリック
    Private Sub PicZoom_Click(sender As Object, e As EventArgs) Handles picZoom.Click
        picZoom.Image = Nothing
        picZoom.Visible = False
        picZoom.SendToBack()
    End Sub

#End Region

#End Region


#End Region

#Region "ローカル関数"

#Region "Model - Control バインディング"
    Private Function FunSetBinding() As Boolean

        '共通
        mtxHOKUKO_NO.DataBindings.Add(New Binding(NameOf(mtxHOKUKO_NO.Text), _D003_NCR_J, NameOf(_D003_NCR_J.HOKOKU_NO)))
        cmbBUMON.DataBindings.Add(New Binding(NameOf(cmbBUMON.SelectedValue), _D003_NCR_J, NameOf(_D003_NCR_J.BUMON_KB)))
        chkClosed.DataBindings.Add(New Binding(NameOf(chkClosed.Checked), _D003_NCR_J, NameOf(_D003_NCR_J.CLOSE_FLG)))
        dtDraft.DataBindings.Add(New Binding(NameOf(dtDraft.ValueNonFormat), _D003_NCR_J, NameOf(_D003_NCR_J.ADD_YMD)))
        cmbAddTanto.DataBindings.Add(New Binding(NameOf(cmbAddTanto.SelectedValue), _D003_NCR_J, NameOf(_D003_NCR_J.ADD_SYAIN_ID)))
        cmbKISYU.DataBindings.Add(New Binding(NameOf(cmbKISYU.SelectedValue), _D003_NCR_J, NameOf(_D003_NCR_J.KISYU_ID)))
        mtxGOUKI.DataBindings.Add(New Binding(NameOf(mtxGOUKI.Text), _D003_NCR_J, NameOf(_D003_NCR_J.GOKI)))
        mtxSYANAI_CD.DataBindings.Add(New Binding(NameOf(mtxSYANAI_CD.Text), _D003_NCR_J, NameOf(_D003_NCR_J.SYANAI_CD)))
        cmbBUHIN_BANGO.DataBindings.Add(New Binding(NameOf(cmbBUHIN_BANGO.SelectedValue), _D003_NCR_J, NameOf(_D003_NCR_J.BUHIN_BANGO)))
        mtxHINMEI.DataBindings.Add(New Binding(NameOf(mtxHINMEI.Text), _D003_NCR_J, NameOf(_D003_NCR_J.BUHIN_NAME)))
        numSU.DataBindings.Add(New Binding(NameOf(numSU.Value), _D003_NCR_J, NameOf(_D003_NCR_J.SURYO)))
        cmbFUTEKIGO_STATUS.DataBindings.Add(New Binding(NameOf(cmbFUTEKIGO_STATUS.SelectedValue), _D003_NCR_J, NameOf(_D003_NCR_J.FUTEKIGO_JYOTAI_KB)))
        chkSAIHATU.DataBindings.Add(New Binding(NameOf(chkSAIHATU.Checked), _D003_NCR_J, NameOf(_D003_NCR_J.SAIHATU)))
        cmbFUTEKIGO_KB.DataBindings.Add(New Binding(NameOf(cmbFUTEKIGO_KB.SelectedValue), _D003_NCR_J, NameOf(_D003_NCR_J.FUTEKIGO_KB)))
        cmbFUTEKIGO_S_KB.DataBindings.Add(New Binding(NameOf(cmbFUTEKIGO_S_KB.SelectedValue), _D003_NCR_J, NameOf(_D003_NCR_J.FUTEKIGO_S_KB)))
        mtxZUBAN_KIKAKU.DataBindings.Add(New Binding(NameOf(mtxZUBAN_KIKAKU.Text), _D003_NCR_J, NameOf(_D003_NCR_J.ZUMEN_KIKAKU)))

        '添付資料
        lbltmpFile1.DataBindings.Add(New Binding(NameOf(lbltmpFile1.Tag), _D003_NCR_J, NameOf(_D003_NCR_J.FILE_PATH)))
        lblPict1Path.DataBindings.Add(New Binding(NameOf(lblPict1Path.Tag), _D003_NCR_J, NameOf(_D003_NCR_J.G_FILE_PATH1)))
        lblPict2Path.DataBindings.Add(New Binding(NameOf(lblPict2Path.Tag), _D003_NCR_J, NameOf(_D003_NCR_J.G_FILE_PATH2)))


        'STAGE01
        txtST01_YOKYU_NAIYO.DataBindings.Add(New Binding(NameOf(txtST01_YOKYU_NAIYO.Text), _D003_NCR_J, NameOf(_D003_NCR_J.YOKYU_NAIYO)))
        txtST01_KEKKA.DataBindings.Add(New Binding(NameOf(txtST01_KEKKA.Text), _D003_NCR_J, NameOf(_D003_NCR_J.KANSATU_KEKKA)))

        'STAGE02
        'mtxHOKUKO_NO.DataBindings.Add(New Binding(NameOf(mtxHOKUKO_NO.Text), _D003_NCR_J, NameOf(_D003_NCR_J.HOKOKU_NO)))

        'STAGE03
        'mtxHOKUKO_NO.DataBindings.Add(New Binding(NameOf(mtxHOKUKO_NO.Text), _D003_NCR_J, NameOf(_D003_NCR_J.HOKOKU_NO)))

        'STAGE04
        cmbST04_ZIZENSINSA_HANTEI.DataBindings.Add(New Binding(NameOf(cmbST04_ZIZENSINSA_HANTEI.SelectedValue), _D003_NCR_J, NameOf(_D003_NCR_J.JIZEN_SINSA_HANTEI_KB)))
        chkST04_ZESEI_SYOCHI_YOHI_KB.DataBindings.Add(New Binding(NameOf(chkST04_ZESEI_SYOCHI_YOHI_KB.Checked), _D003_NCR_J, NameOf(_D003_NCR_J.ZESEI_SYOCHI_YOHI_KB)))
        txtST04_RIYU.DataBindings.Add(New Binding(NameOf(txtST04_RIYU.Text), _D003_NCR_J, NameOf(_D003_NCR_J.ZESEI_NASI_RIYU)))

        'STAGE05
        'mtxHOKUKO_NO.DataBindings.Add(New Binding(NameOf(mtxHOKUKO_NO.Text), _D003_NCR_J, NameOf(_D003_NCR_J.HOKOKU_NO)))

        'STAGE06
        cmbST06_SAISIN_IINKAI_HANTEI.DataBindings.Add(New Binding(NameOf(cmbST06_SAISIN_IINKAI_HANTEI.SelectedValue), _D003_NCR_J, NameOf(_D003_NCR_J.SAISIN_IINKAI_HANTEI_KB)))
        mtxST06_SAISIN_IINKAI_SIRYO_NO.DataBindings.Add(New Binding(NameOf(mtxST06_SAISIN_IINKAI_SIRYO_NO.Text), _D003_NCR_J, NameOf(_D003_NCR_J.SAISIN_IINKAI_SIRYO_NO)))

        'STAGE07
        mtxST07_ITAG_NO.DataBindings.Add(New Binding(NameOf(mtxST07_ITAG_NO.Text), _D003_NCR_J, NameOf(_D003_NCR_J.ITAG_NO)))
        cmbST07_SAISIN_TANTO.DataBindings.Add(New Binding(NameOf(cmbST07_SAISIN_TANTO.SelectedValue), _D003_NCR_J, NameOf(_D003_NCR_J.KOKYAKU_SAISIN_TANTO_ID)))
        cmbST07_KOKYAKU_HANTEI_SIJI.DataBindings.Add(New Binding(NameOf(cmbST07_KOKYAKU_HANTEI_SIJI.SelectedValue), _D003_NCR_J, NameOf(_D003_NCR_J.KOKYAKU_HANTEI_SIJI_KB)))
        dtST07_KOKYAKU_HANTEI_SIJI.DataBindings.Add(New Binding(NameOf(dtST07_KOKYAKU_HANTEI_SIJI.ValueNonFormat), _D003_NCR_J, NameOf(_D003_NCR_J.KOKYAKU_HANTEI_SIJI_YMD)))
        cmbST07_KOKYAKU_SAISYU_HANTEI.DataBindings.Add(New Binding(NameOf(cmbST07_KOKYAKU_SAISYU_HANTEI.SelectedValue), _D003_NCR_J, NameOf(_D003_NCR_J.KOKYAKU_SAISYU_HANTEI_KB)))
        dtST07_KOKYAKU_SAISYU_HANTEI.DataBindings.Add(New Binding(NameOf(dtST07_KOKYAKU_SAISYU_HANTEI.ValueNonFormat), _D003_NCR_J, NameOf(_D003_NCR_J.KOKYAKU_SAISYU_HANTEI_YMD)))
        chkST07_SAIKAKO_SIJI_FLG.DataBindings.Add(New Binding(NameOf(chkST07_SAIKAKO_SIJI_FLG.Checked), _D003_NCR_J, NameOf(_D003_NCR_J.SAIKAKO_SIJI_FLG)))

        'STAGE08
        dtST08_1_HAIKYAKU_YMD.DataBindings.Add(New Binding(NameOf(dtST08_1_HAIKYAKU_YMD.ValueNonFormat), _D003_NCR_J, NameOf(_D003_NCR_J.HAIKYAKU_YMD)))
        cmbST08_1_HAIKYAKU_KB.DataBindings.Add(New Binding(NameOf(cmbST08_1_HAIKYAKU_KB.SelectedValue), _D003_NCR_J, NameOf(_D003_NCR_J.HAIKYAKU_KB)))
        mtxST08_1_BIKO.DataBindings.Add(New Binding(NameOf(mtxST08_1_BIKO.Text), _D003_NCR_J, NameOf(_D003_NCR_J.HAIKYAKU_HOUHOU)))
        cmbST08_1_HAIKYAKU_TANTO.DataBindings.Add(New Binding(NameOf(cmbST08_1_HAIKYAKU_TANTO.SelectedValue), _D003_NCR_J, NameOf(_D003_NCR_J.HAIKYAKU_TANTO_ID)))

        mtxST08_2_DOC_NO.DataBindings.Add(New Binding(NameOf(mtxST08_2_DOC_NO.Text), _D003_NCR_J, NameOf(_D003_NCR_J.SAIKAKO_SIJI_NO)))
        dtST08_2_WorkOutYMD.DataBindings.Add(New Binding(NameOf(dtST08_2_WorkOutYMD.ValueNonFormat), _D003_NCR_J, NameOf(_D003_NCR_J.SAIKAKO_SAGYO_KAN_YMD)))
        dtST08_2_KENSA_YMD.DataBindings.Add(New Binding(NameOf(dtST08_2_KENSA_YMD.ValueNonFormat), _D003_NCR_J, NameOf(_D003_NCR_J.SAIKAKO_KENSA_YMD)))
        cmbST08_2_KENSA_KEKKA.DataBindings.Add(New Binding(NameOf(cmbST08_2_KENSA_KEKKA.SelectedValue), _D003_NCR_J, NameOf(_D003_NCR_J.KENSA_KEKKA_KB)))
        cmbST08_2_TANTO_SEIZO.DataBindings.Add(New Binding(NameOf(cmbST08_2_TANTO_SEIZO.SelectedValue), _D003_NCR_J, NameOf(_D003_NCR_J.SEIZO_TANTO_ID)))
        cmbST08_2_TANTO_SEIGI.DataBindings.Add(New Binding(NameOf(cmbST08_2_TANTO_SEIGI.SelectedValue), _D003_NCR_J, NameOf(_D003_NCR_J.SEIGI_TANTO_ID)))
        cmbST08_2_TANTO_KENSA.DataBindings.Add(New Binding(NameOf(cmbST08_2_TANTO_KENSA.SelectedValue), _D003_NCR_J, NameOf(_D003_NCR_J.KENSA_TANTO_ID)))

        dtST08_3_HENKYAKU_YMD.DataBindings.Add(New Binding(NameOf(dtST08_3_HENKYAKU_YMD.ValueNonFormat), _D003_NCR_J, NameOf(_D003_NCR_J.HAIKYAKU_YMD)))
        mtxST08_3_HENKYAKU_SAKI.DataBindings.Add(New Binding(NameOf(mtxST08_3_HENKYAKU_SAKI.Text), _D003_NCR_J, NameOf(_D003_NCR_J.HENKYAKU_SAKI)))
        txtST08_3_BIKO.DataBindings.Add(New Binding(NameOf(txtST08_3_BIKO.Text), _D003_NCR_J, NameOf(_D003_NCR_J.HENKYAKU_BIKO)))

        cmbST08_4_KISYU.DataBindings.Add(New Binding(NameOf(cmbST08_4_KISYU.SelectedValue), _D003_NCR_J, NameOf(_D003_NCR_J.TENYO_KISYU_ID)))
        cmbST08_4_BUHIN_BANGO.DataBindings.Add(New Binding(NameOf(cmbST08_4_BUHIN_BANGO.SelectedValue), _D003_NCR_J, NameOf(_D003_NCR_J.TENYO_BUHIN_BANGO)))
        mtxST08_4_GOUKI.DataBindings.Add(New Binding(NameOf(mtxST08_4_GOUKI.Text), _D003_NCR_J, NameOf(_D003_NCR_J.TENYO_GOKI)))
        mtxST08_4_LOT.DataBindings.Add(New Binding(NameOf(mtxST08_4_LOT.Text), _D003_NCR_J, NameOf(_D003_NCR_J.TENYO_LOT)))
        dtST08_4_TENYO_YMD.DataBindings.Add(New Binding(NameOf(dtST08_4_TENYO_YMD.ValueNonFormat), _D003_NCR_J, NameOf(_D003_NCR_J.TENYO_YMD)))

        'STAGE09
        'mtxHOKUKO_NO.DataBindings.Add(New Binding(NameOf(mtxHOKUKO_NO.Text), _D003_NCR_J, NameOf(_D003_NCR_J.HOKOKU_NO)))

        'STAGE10
        'mtxHOKUKO_NO.DataBindings.Add(New Binding(NameOf(mtxHOKUKO_NO.Text), _D003_NCR_J, NameOf(_D003_NCR_J.HOKOKU_NO)))

        'STAGE11
        chkST11_A1.DataBindings.Add(New Binding(NameOf(chkST11_A1.Checked), _D003_NCR_J, NameOf(_D003_NCR_J.SYOCHI_KEKKA_A)))
        chkST11_B1.DataBindings.Add(New Binding(NameOf(chkST11_B1.Checked), _D003_NCR_J, NameOf(_D003_NCR_J.SYOCHI_KEKKA_B)))
        chkST11_C1.DataBindings.Add(New Binding(NameOf(chkST11_C1.Checked), _D003_NCR_J, NameOf(_D003_NCR_J.SYOCHI_KEKKA_C)))
        chkST11_D1.DataBindings.Add(New Binding(NameOf(chkST11_D1.Checked), _D003_NCR_J, NameOf(_D003_NCR_J.SYOCHI_D_UMU_KB)))
        chkST11_D2.DataBindings.Add(New Binding(NameOf(chkST11_D2.Checked), _D003_NCR_J, NameOf(_D003_NCR_J.SYOCHI_D_YOHI_KB)))
        mtxST11_D_Comment.DataBindings.Add(New Binding(NameOf(mtxST11_D_Comment.Text), _D003_NCR_J, NameOf(_D003_NCR_J.SYOCHI_D_SYOCHI_KIROKU)))
        chkST11_E1.DataBindings.Add(New Binding(NameOf(chkST11_E1.Checked), _D003_NCR_J, NameOf(_D003_NCR_J.SYOCHI_E_UMU_KB)))
        chkST11_E2.DataBindings.Add(New Binding(NameOf(chkST11_E2.Checked), _D003_NCR_J, NameOf(_D003_NCR_J.SYOCHI_E_YOHI_KB)))
        mtxST11_E_Comment.DataBindings.Add(New Binding(NameOf(mtxST11_E_Comment.Text), _D003_NCR_J, NameOf(_D003_NCR_J.SYOCHI_E_SYOCHI_KIROKU)))

        'STAGE12



    End Function
#End Region

#Region "処理モード別画面初期化"
    Private Function FunInitializeControls(ByVal intMODE As Integer) As Boolean

        Try
            Select Case intMODE
                Case ENM_DATA_OPERATION_MODE._1_ADD

                    _D003_NCR_J.HOKOKU_NO = "<新規>"
                    _D003_NCR_J.ADD_SYAIN_ID = pub_SYAIN_INFO.SYAIN_ID
                    _D003_NCR_J.ADD_YMDHNS = Now.ToString("yyyyMMddHHmmss")
                    _D003_NCR_J.BUMON_KB = pub_SYAIN_INFO.BUMON_KB
                    _D003_NCR_J.SURYO = 1


                    'SPEC: 2.(3).B.②
                    PrCurrentStage = ENM_NCR_STAGE._10_起草入力

                    Call FunInitializeTabControl(FunConvertSYONIN_JUN_TO_STAGE_NO(PrCurrentStage))
                    Call FunInitializeSTAGE(PrCurrentStage)

                Case ENM_DATA_OPERATION_MODE._3_UPDATE


                    'SPEC: 10-2.①
                    Call FunSetEntityValues(PrDataRow)

                    Call FunInitializeTabControl(FunConvertSYONIN_JUN_TO_STAGE_NO(PrDataRow.Item("SYONIN_JUN")))
                    Call FunInitializeSTAGE(PrDataRow.Item("SYONIN_JUN"))
                    mtxHOKUKO_NO.Enabled = False

                    For Each page As TabPage In TabSTAGE.TabPages
                        If page.Text = "現ステージ" Then
                            TabSTAGE.SelectedIndex = page.TabIndex
                            Exit For
                        End If
                    Next page
                Case Else
                    'Throw New ArgumentException(My.Resources.ErrMsgException, intMODE.ToString)
            End Select

            Return True

        Catch ex As Exception
            EM.ErrorSyori(ex, False, conblnNonMsg)
            Return False
        End Try
    End Function

    ''' <summary>
    ''' 一覧選択行の値をセット
    ''' </summary>
    ''' <param name="dgvCol"></param>
    ''' <returns></returns>
    Private Function FunSetEntityValues(dr As DataRow) As Boolean

        Try
            '-----コントロールに値をセット
            Dim sbSQL As New System.Text.StringBuilder
            Dim dsList As New DataSet
            sbSQL.Remove(0, sbSQL.Length)
            sbSQL.Append("SELECT")
            sbSQL.Append(" *")
            sbSQL.Append(" FROM " & NameOf(MODEL.V002_FUTEKIGO_HOKOKU_J) & " ")
            sbSQL.Append(" WHERE HOKOKU_NO='" & dr.Item("HOKOKUSYO_NO") & "'")
            Using DBa As ClsDbUtility = DBOpen()
                dsList = DBa.GetDataSet(sbSQL.ToString, conblnNonMsg)
            End Using

            With dsList.Tables(0).Rows(0)

                '報告書No
                mtxHOKUKO_NO.Text = .Item("")
                '起草者

                '起草日
                dtDraft.Text = .Item("")
                '機種
                cmbKISYU.SelectedValue = .Item("")
                '部品番号
                cmbBUHIN_BANGO.SelectedValue = .Item("")
                '部品名称
                mtxHINMEI.Text = .Item("")
                '号機
                mtxGOUKI.Text = .Item("")
                '個数
                numSU.Value = .Item("")
                '再発
                chkSAIHATU.Checked = CBool(.Item(""))

                '状態区分
                cmbFUTEKIGO_STATUS.SelectedValue = .Item("")
                '返却時の場合
                cmbFUTEKIGO_KB.SelectedValue = .Item("")
                '保留理由
                mtxFUTEKIGO_NAIYO.Text = .Item("")
                '図番/規格
                mtxZUBAN_KIKAKU.Text = .Item("")
            End With

            Return True
        Catch ex As Exception
            EM.ErrorSyori(ex, False, conblnNonMsg)
            Return False
        End Try
    End Function

#End Region
    
#Region "タブコントロール制御"

#Region "初期化"
    Private Function FunInitializeTabControl(ByVal intSTAGE As Integer) As Boolean

        Try
            _tabPageManager = New TabPageManager(TabSTAGE)

            For Each page As TabPage In TabSTAGE.TabPages
                If page.Name <> "tabAttachment" Then
                    If Val(page.Name.Substring(8)) < intSTAGE Then
                        'SPEC: 10-2.③
                        page.Text = tblNCR.AsEnumerable.Where(Function(r) r.Field(Of String)("VALUE") = PrDataRow("SYONIN_JUN")).FirstOrDefault.Item("DISP")
                    ElseIf Val(page.Name.Substring(8)) = intSTAGE Then
                        page.Text = "現ステージ" 'tblNCR.AsEnumerable.Where(Function(r) r.Field(Of String)("VALUE") = PrDataRow("SYONIN_JUN")).FirstOrDefault.Item("DISP")
                        'SPEC: 10-2.④
                        TabSTAGE.SelectedIndex = page.TabIndex
                    ElseIf Val(page.Name.Substring(8)) > intSTAGE Then
                        'SPEC: 10-2 ②
                        _tabPageManager.ChangeTabPageVisible(page.TabIndex, False)
                    End If

                    'SPEC: 10-2.⑤ 
                    If PrDataRow Is Nothing Then
                        '新規作成時
                        'SPEC: (3).B 
                        page.Enabled = True
                    Else
                        page.Enabled = FunblnOwnCreated(ENM_SYONIN_HOKOKU_ID._1_NCR, PrDataRow("HOKOKUSYO_NO"), PrDataRow("SYONIN_JUN"))
                    End If
                End If
            Next page

            'mtxST01_NextStageName.Text = FunGetNextStageName(ENM_NCR_STAGE._10_起草入力)
            'mtxST02_NextStageName.Text = FunGetNextStageName(ENM_NCR_STAGE._20_起草確認製造GL)
            'mtxST03_NextStageName.Text = FunGetNextStageName(ENM_NCR_STAGE._30_起草確認検査)
            'mtxST04_NextStageName.Text = FunGetNextStageName(ENM_NCR_STAGE._40_事前審査判定及びCAR要否判定)
            'mtxST05_NextStageName.Text = FunGetNextStageName(ENM_NCR_STAGE._50_事前審査確認)
            'mtxST06_NextStageName.Text = FunGetNextStageName(ENM_NCR_STAGE._61_再審審査判定_品証代表)
            'mtxST07_NextStageName.Text = FunGetNextStageName(ENM_NCR_STAGE._70_顧客再審処置_I_tag)
            'mtxST08_NextStageName.Text = FunGetNextStageName(ENM_NCR_STAGE._83_処置実施_検査)
            'mtxST09_NextStageName.Text = FunGetNextStageName(ENM_NCR_STAGE._90_処置実施確認_管理T)
            'mtxST10_NextStageName.Text = FunGetNextStageName(ENM_NCR_STAGE._100_処置実施決裁_製造課長)
            'mtxST11_NextStageName.Text = FunGetNextStageName(ENM_NCR_STAGE._110_abcde処置担当)

            Return True
        Catch ex As Exception
            EM.ErrorSyori(ex, False, conblnNonMsg)
            Return False
        End Try
    End Function

#End Region

#Region "STAGE別コントロール初期化"
    Private Function FunInitializeSTAGE(ByVal intStageID As Integer) As Boolean

        Try

            Select Case intStageID
#Region "               10"
                Case ENM_NCR_STAGE._10_起草入力
                    Dim dt As DataTable = tblTANTO_SYONIN.AsEnumerable.
                                            Where(Function(r) r.Field(Of Integer)("SYONIN_HOKOKUSYO_ID") = 1 And r.Field(Of Integer)("SYONIN_JUN") = FunGetNextSYONIN_JUN(intStageID)).
                                            CopyToDataTable

                    mtxST01_UPD_YMD.Text = Today.ToString("yyyy/MM/dd")
                    mtxST01_NextStageName.Text = FunGetNextStageName(intStageID)
                    cmbST01_DestTANTO.SetDataSource(dt, ENM_COMBO_SELECT_VALUE_TYPE._0_Required)

#End Region
#Region "               20"
                Case ENM_NCR_STAGE._20_起草確認製造GL
                    Dim dt As DataTable = tblTANTO_SYONIN.AsEnumerable.
                                            Where(Function(r) r.Field(Of Integer)("SYONIN_HOKOKUSYO_ID") = 1 And r.Field(Of Integer)("SYONIN_JUN") = FunGetNextSYONIN_JUN(intStageID)).
                                            CopyToDataTable

                    mtxST02_UPD_YMD.Text = Today.ToString("yyyy/MM/dd")
                    mtxST02_NextStageName.Text = FunGetNextStageName(intStageID)
                    cmbST02_DestTANTO.SetDataSource(dt, ENM_COMBO_SELECT_VALUE_TYPE._0_Required)

#End Region
#Region "               30"
                Case ENM_NCR_STAGE._30_起草確認検査
                    Dim dt As DataTable = tblTANTO_SYONIN.AsEnumerable.
                                            Where(Function(r) r.Field(Of Integer)("SYONIN_HOKOKUSYO_ID") = 1 And r.Field(Of Integer)("SYONIN_JUN") = FunGetNextSYONIN_JUN(intStageID)).
                                            CopyToDataTable

                    mtxST03_UPD_YMD.Text = Today.ToString("yyyy/MM/dd")
                    mtxST03_NextStageName.Text = FunGetNextStageName(intStageID)
                    cmbST03_DestTANTO.SetDataSource(dt, ENM_COMBO_SELECT_VALUE_TYPE._0_Required)

#End Region
#Region "               40"
                Case ENM_NCR_STAGE._40_事前審査判定及びCAR要否判定
                    Dim dt As DataTable = tblTANTO_SYONIN.AsEnumerable.
                                            Where(Function(r) r.Field(Of Integer)("SYONIN_HOKOKUSYO_ID") = 1 And r.Field(Of Integer)("SYONIN_JUN") = FunGetNextSYONIN_JUN(intStageID)).
                                            CopyToDataTable

                    mtxST04_UPD_YMD.Text = Today.ToString("yyyy/MM/dd")
                    mtxST04_NextStageName.Text = FunGetNextStageName(intStageID)
                    cmbST04_DestTANTO.SetDataSource(dt, ENM_COMBO_SELECT_VALUE_TYPE._0_Required)

                    cmbST04_ZIZENSINSA_HANTEI.SetDataSource(tblJIZEN_SINSA_HANTEI_KB.ExcludeDeleted, ENM_COMBO_SELECT_VALUE_TYPE._0_Required)

#End Region
#Region "               50"
                Case ENM_NCR_STAGE._50_事前審査確認
                    Dim dt As DataTable = tblTANTO_SYONIN.AsEnumerable.
                                        Where(Function(r) r.Field(Of Integer)("SYONIN_HOKOKUSYO_ID") = 1 And r.Field(Of Integer)("SYONIN_JUN") = FunGetNextSYONIN_JUN(intStageID)).
                                        CopyToDataTable

                    mtxST05_UPD_YMD.Text = Today.ToString("yyyy/MM/dd")
                    mtxST05_NextStageName.Text = FunGetNextStageName(intStageID)
                    cmbST05_DestTANTO.SetDataSource(dt, ENM_COMBO_SELECT_VALUE_TYPE._0_Required)

#End Region
#Region "               60"
                Case ENM_NCR_STAGE._60_再審審査判定_技術代表, ENM_NCR_STAGE._61_再審審査判定_品証代表
                    Dim dt As DataTable = tblTANTO_SYONIN.AsEnumerable.
                                        Where(Function(r) r.Field(Of Integer)("SYONIN_HOKOKUSYO_ID") = 1 And r.Field(Of Integer)("SYONIN_JUN") = FunGetNextSYONIN_JUN(intStageID)).
                                        CopyToDataTable

                    mtxST06_UPD_YMD.Text = Today.ToString("yyyy/MM/dd")
                    mtxST06_NextStageName.Text = FunGetNextStageName(intStageID)
                    cmbST06_DestTANTO.SetDataSource(dt, ENM_COMBO_SELECT_VALUE_TYPE._0_Required)

                    cmbST06_SAISIN_IINKAI_HANTEI.SetDataSource(tblSAISIN_IINKAI_HANTEI_KB.ExcludeDeleted, ENM_COMBO_SELECT_VALUE_TYPE._0_Required)

#End Region
#Region "               70"
                Case ENM_NCR_STAGE._70_顧客再審処置_I_tag
#End Region
#Region "               80"
                Case ENM_NCR_STAGE._80_処置実施
                Case ENM_NCR_STAGE._81_処置実施_生技
                Case ENM_NCR_STAGE._82_処置実施_製造
                Case ENM_NCR_STAGE._83_処置実施_検査
#End Region
#Region "               90"
                Case ENM_NCR_STAGE._90_処置実施確認_管理T
#End Region
#Region "               100"
                Case ENM_NCR_STAGE._100_処置実施決裁_製造課長
#End Region
#Region "               110"
                Case ENM_NCR_STAGE._110_abcde処置担当
#End Region
#Region "               120"
                Case ENM_NCR_STAGE._120_abcde処置確認
#End Region

                Case Else

            End Select

            Return True
        Catch ex As Exception
            EM.ErrorSyori(ex, False, conblnNonMsg)
            Return False
        End Try
    End Function

#End Region

#End Region

    ''' <summary>
    ''' 次ステージ名を取得
    ''' </summary>
    ''' <param name="intCurrentStageID">現ステージID</param>
    ''' <returns></returns>
    Private Function FunGetNextStageName(ByVal intCurrentStageID As Integer) As String
        Try

            Dim drList As List(Of DataRow) = tblNCR.AsEnumerable().
                                                Where(Function(r) Val(r.Field(Of String)("VALUE")) > intCurrentStageID).ToList
            Dim strBUFF As String = ""
            If drList.Count > 0 Then
                strBUFF = drList(0).Item("DISP")
            End If

            Return strBUFF
        Catch ex As Exception
            EM.ErrorSyori(ex, False, conblnNonMsg)
            Return vbEmpty
        End Try
    End Function

    ''' <summary>
    ''' 次ステージの承認順Noを取得
    ''' </summary>
    ''' <param name="intCurrentStageID">現ステージID</param>
    ''' <returns></returns>
    Private Function FunGetNextSYONIN_JUN(ByVal intCurrentStageID As Integer) As Integer
        Try

            Dim drList As List(Of DataRow) = tblNCR.AsEnumerable().
                                                Where(Function(r) Val(r.Field(Of String)("VALUE")) > intCurrentStageID).ToList
            Dim intBUFF As Integer
            If drList.Count > 0 Then
                intBUFF = Val(drList(0).Item("VALUE"))
            End If

            Return intBUFF
        Catch ex As Exception
            EM.ErrorSyori(ex, False, conblnNonMsg)
            Return 0
        End Try
    End Function

    ''' <summary>
    ''' 承認順Noから該当するタブNoを取得
    ''' </summary>
    ''' <param name="intSYONIN_JUN">承認順No</param>
    ''' <returns></returns>
    Private Function FunConvertSYONIN_JUN_TO_STAGE_NO(ByVal intSYONIN_JUN As Integer) As Integer
        Dim intBUFF As Integer
        Select Case intSYONIN_JUN
            Case ENM_NCR_STAGE._10_起草入力
                intBUFF = 1
            Case ENM_NCR_STAGE._20_起草確認製造GL
                intBUFF = 2
            Case ENM_NCR_STAGE._30_起草確認検査
                intBUFF = 3
            Case ENM_NCR_STAGE._40_事前審査判定及びCAR要否判定
                intBUFF = 4
            Case ENM_NCR_STAGE._50_事前審査確認
                intBUFF = 5
            Case ENM_NCR_STAGE._60_再審審査判定_技術代表, ENM_NCR_STAGE._61_再審審査判定_品証代表
                intBUFF = 6
            Case ENM_NCR_STAGE._70_顧客再審処置_I_tag
                intBUFF = 7
            Case ENM_NCR_STAGE._80_処置実施, ENM_NCR_STAGE._81_処置実施_生技, ENM_NCR_STAGE._82_処置実施_製造, ENM_NCR_STAGE._83_処置実施_検査
                intBUFF = 8
            Case ENM_NCR_STAGE._90_処置実施確認_管理T
                intBUFF = 9
            Case ENM_NCR_STAGE._100_処置実施決裁_製造課長
                intBUFF = 10
            Case ENM_NCR_STAGE._110_abcde処置担当
                intBUFF = 11
            Case ENM_NCR_STAGE._120_abcde処置確認
                intBUFF = 12
            Case Else
                intBUFF = 15
        End Select

        Return intBUFF
    End Function

    ''' <summary>
    ''' ログインユーザーが承認or申請したステージか判定
    ''' </summary>
    ''' <param name="intHOKOKUSYO_ID">承認報告書ID</param>
    ''' <param name="strHOKOKUSYO_NO">報告書No</param>
    ''' <param name="intSYONIN_JUN">承認順No</param>
    ''' <returns></returns>
    Private Function FunblnOwnCreated(ByVal intHOKOKUSYO_ID As Integer, ByVal strHOKOKUSYO_NO As String, ByVal intSYONIN_JUN As Integer) As Boolean
        Dim sbSQL As New System.Text.StringBuilder
        Dim dsList As New DataSet
        sbSQL.Remove(0, sbSQL.Length)
        sbSQL.Append("SELECT")
        sbSQL.Append(" *")
        sbSQL.Append(" FROM D004_SYONIN_J_KANRI ")
        sbSQL.Append(" WHERE SYONIN_HOKOKUSYO_ID=" & intHOKOKUSYO_ID & "")
        sbSQL.Append(" AND HOKOKU_NO=" & intHOKOKUSYO_ID & "")
        sbSQL.Append(" AND SYONIN_JUN=" & intHOKOKUSYO_ID & "")
        sbSQL.Append(" AND SYAIN_ID=" & pub_SYAIN_INFO.SYAIN_ID & "")
        Using DBa As ClsDbUtility = DBOpen()
            dsList = DBa.GetDataSet(sbSQL.ToString, conblnNonMsg)
        End Using

        Return dsList.Tables(0).Rows.Count > 0

    End Function

    ''' <summary>
    ''' demo用全タブセット
    ''' </summary>
    ''' <returns></returns>
    Private Function FunSetAllTabPages() As Boolean
        For i As Integer = 1 To 12
            _tabPageManager.ChangeTabPageVisible(i, True)
        Next
        Dim dt As DataTable = tblTANTO_SYONIN.AsEnumerable.
                                         Where(Function(r) r.Field(Of Integer)("SYONIN_HOKOKUSYO_ID") = 1 And r.Field(Of Integer)("SYONIN_JUN") = FunGetNextSYONIN_JUN(ENM_NCR_STAGE._10_起草入力)).
                                         CopyToDataTable
        mtxST01_NextStageName.Text = FunGetNextStageName(ENM_NCR_STAGE._10_起草入力)
        cmbST01_DestTANTO.SetDataSource(dt, ENM_COMBO_SELECT_VALUE_TYPE._0_Required)

        dt = tblTANTO_SYONIN.AsEnumerable.
                                         Where(Function(r) r.Field(Of Integer)("SYONIN_HOKOKUSYO_ID") = 1 And r.Field(Of Integer)("SYONIN_JUN") = FunGetNextSYONIN_JUN(ENM_NCR_STAGE._20_起草確認製造GL)).
                                         CopyToDataTable
        'mtxST02_UPD_YMD.Text = Today.ToString("yyyy/MM/dd")
        mtxST02_NextStageName.Text = FunGetNextStageName(ENM_NCR_STAGE._20_起草確認製造GL)
        cmbST02_DestTANTO.SetDataSource(dt, ENM_COMBO_SELECT_VALUE_TYPE._0_Required)

        dt = tblTANTO_SYONIN.AsEnumerable.
                                 Where(Function(r) r.Field(Of Integer)("SYONIN_HOKOKUSYO_ID") = 1 And r.Field(Of Integer)("SYONIN_JUN") = FunGetNextSYONIN_JUN(ENM_NCR_STAGE._30_起草確認検査)).
                                 CopyToDataTable
        'mtxST03_UPD_YMD.Text = Today.ToString("yyyy/MM/dd")
        mtxST03_NextStageName.Text = FunGetNextStageName(ENM_NCR_STAGE._30_起草確認検査)
        cmbST03_DestTANTO.SetDataSource(dt, ENM_COMBO_SELECT_VALUE_TYPE._0_Required)

        dt = tblTANTO_SYONIN.AsEnumerable.
                                      Where(Function(r) r.Field(Of Integer)("SYONIN_HOKOKUSYO_ID") = 1 And r.Field(Of Integer)("SYONIN_JUN") = FunGetNextSYONIN_JUN(ENM_NCR_STAGE._40_事前審査判定及びCAR要否判定)).
                                      CopyToDataTable
        'mtxST04_UPD_YMD.Text = Today.ToString("yyyy/MM/dd")
        mtxST04_NextStageName.Text = FunGetNextStageName(ENM_NCR_STAGE._40_事前審査判定及びCAR要否判定)
        cmbST04_DestTANTO.SetDataSource(dt, ENM_COMBO_SELECT_VALUE_TYPE._0_Required)
        cmbST04_ZIZENSINSA_HANTEI.SetDataSource(tblJIZEN_SINSA_HANTEI_KB.ExcludeDeleted, ENM_COMBO_SELECT_VALUE_TYPE._0_Required)

        dt = tblTANTO_SYONIN.AsEnumerable.
                                Where(Function(r) r.Field(Of Integer)("SYONIN_HOKOKUSYO_ID") = 1 And r.Field(Of Integer)("SYONIN_JUN") = FunGetNextSYONIN_JUN(ENM_NCR_STAGE._50_事前審査確認)).
                                CopyToDataTable
        'mtxST05_UPD_YMD.Text = Today.ToString("yyyy/MM/dd")
        mtxST05_NextStageName.Text = FunGetNextStageName(ENM_NCR_STAGE._50_事前審査確認)
        cmbST05_DestTANTO.SetDataSource(dt, ENM_COMBO_SELECT_VALUE_TYPE._0_Required)

        dt = tblTANTO_SYONIN.AsEnumerable.
                                   Where(Function(r) r.Field(Of Integer)("SYONIN_HOKOKUSYO_ID") = 1 And r.Field(Of Integer)("SYONIN_JUN") = FunGetNextSYONIN_JUN(ENM_NCR_STAGE._61_再審審査判定_品証代表)).
                                   CopyToDataTable
        'mtxST06_UPD_YMD.Text = Today.ToString("yyyy/MM/dd")
        mtxST06_NextStageName.Text = FunGetNextStageName(ENM_NCR_STAGE._61_再審審査判定_品証代表)
        cmbST06_DestTANTO.SetDataSource(dt, ENM_COMBO_SELECT_VALUE_TYPE._0_Required)
        cmbST06_SAISIN_IINKAI_HANTEI.SetDataSource(tblSAISIN_IINKAI_HANTEI_KB.ExcludeDeleted, ENM_COMBO_SELECT_VALUE_TYPE._0_Required)

        'mtxST07_UPD_YMD.Text = Today.ToString("yyyy/MM/dd")
        mtxST07_NextStageName.Text = FunGetNextStageName(ENM_NCR_STAGE._70_顧客再審処置_I_tag)
        cmbST07_DestTANTO.SetDataSource(dt, ENM_COMBO_SELECT_VALUE_TYPE._0_Required)



        Dim strTabNameList As New List(Of String)
        strTabNameList.Add("日比野 敏久") '23
        strTabNameList.Add("杉山 茂巨") '31
        strTabNameList.Add("横山 隆広") '21
        strTabNameList.Add("半田功") '157
        strTabNameList.Add("今井秀秋") '122
        strTabNameList.Add("半田功") '157
        strTabNameList.Add("中澤康嗣") '
        strTabNameList.Add("日比野敏久") '
        strTabNameList.Add("林 欣吾") '
        strTabNameList.Add("日當瀬政彦") '
        strTabNameList.Add("横山 隆広") '
        strTabNameList.Add("杉山 茂巨") '

        '処理済みステージ情報の取得
        For i As Integer = 1 To 12
            TabSTAGE.Controls("tabSTAGE" & i.ToString("00")).Visible = True
            TabSTAGE.Controls("tabSTAGE" & i.ToString("00")).Text = strTabNameList(i - 1)
        Next i

        cmbST01_DestTANTO.Text = strTabNameList(0)
        cmbST02_DestTANTO.Text = strTabNameList(1)
        cmbST03_DestTANTO.Text = strTabNameList(2)
        cmbST04_DestTANTO.Text = strTabNameList(3)
        cmbST05_DestTANTO.Text = strTabNameList(4)
        cmbST06_DestTANTO.Text = strTabNameList(5)
        cmbST07_DestTANTO.Text = strTabNameList(6)
        cmbST08_DestTANTO.Text = strTabNameList(7)
        cmbST09_DestTANTO.Text = strTabNameList(8)
        cmbST10_DestTANTO.Text = strTabNameList(9)
        cmbST11_DestTANTO.Text = strTabNameList(10)

    End Function


#End Region

End Class