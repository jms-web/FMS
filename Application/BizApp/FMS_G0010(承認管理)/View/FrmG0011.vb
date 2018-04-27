Imports JMS_COMMON.ClsPubMethod


Public Class FrmG0011

#Region "定数・変数"
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
    Public Property PrdgvCellCollection As DataGridViewCellCollection

    Public Property PrDataRow As DataRow


    'DEBUG:
    Public Property PrDt As DataTable
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
        MyBase.ToolTip.SetToolTip(Me.cmdFunc4, "新規登録時は使用出来ません")
        MyBase.ToolTip.SetToolTip(Me.cmdFunc5, "新規登録時は使用出来ません")
        MyBase.ToolTip.SetToolTip(Me.cmdFunc10, "新規登録時は使用出来ません")
        MyBase.ToolTip.SetToolTip(Me.cmdFunc11, "新規登録時は使用出来ません")


    End Sub

#End Region

#Region "Form関連"

    'Loadイベント
    Private Sub FrmLoad(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        Try
            '-----フォーム初期設定(親フォームから呼び出し)
            Call FunFormCommonSetting(pub_APP_INFO, pub_SYAIN_INFO, My.Application.Info.Version.ToString)
            Me.Text = "不適合製品処置報告書(Non-Conformance Report)"
            lblTytle.Text = Me.Text

            '-----コントロールデータソース設定
            cmbBUMON.SetDataSource(tblBUMON.ExcludeDeleted, ENM_COMBO_SELECT_VALUE_TYPE._0_Required)
            cmbKISYU.SetDataSource(tblKISYU.ExcludeDeleted, ENM_COMBO_SELECT_VALUE_TYPE._0_Required)
            cmbBUHIN_BANGO.SetDataSource(tblBUHIN.ExcludeDeleted, ENM_COMBO_SELECT_VALUE_TYPE._0_Required)
            cmbFUTEKIGO_STATUS.SetDataSource(tblFUTEKIGO_STATUS_KB.ExcludeDeleted, ENM_COMBO_SELECT_VALUE_TYPE._0_Required)
            cmbFUTEKIGO_KB.SetDataSource(tblFUTEKIGO_KB.ExcludeDeleted, ENM_COMBO_SELECT_VALUE_TYPE._0_Required)


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

#Region "処理モード別画面初期化"
    Private Function FunInitializeControls(ByVal intMODE As Integer) As Boolean

        Try
            Select Case intMODE
                Case ENM_DATA_OPERATION_MODE._1_ADD

                    mtxHOKUKO_NO.Text = "<新規>"
                    mtxHOKUKO_NO.Enabled = True
                    mtxHOKUKO_NO.ReadOnly = True

                    mtxADD_SYAIN_NAME.Text = pub_SYAIN_INFO.SYAIN_NAME
                    mtxADD_SYAIN_NAME.Enabled = False

                    dtDraft.Text = Today.ToString("yyyy/MM/dd")
                    dtDraft.Enabled = False

                    numSU.Value = 1


                    Call FunInitializeTabControl(FunConvertSYONIN_JUN_TO_STAGE_NO(ENM_NCR_STAGE._10_起草入力))
                    Call FunInitializeSTAGE(ENM_NCR_STAGE._10_起草入力)

                Case ENM_DATA_OPERATION_MODE._3_UPDATE


                    'SPEC: 10-2.①
                    Call FunSetEntityValues(PrDataRow)

                    Call FunInitializeTabControl(FunConvertSYONIN_JUN_TO_STAGE_NO(PrDataRow.Item("SYONIN_JUN")))
                    Call FunInitializeSTAGE(PrDataRow.Item("SYONIN_JUN"))
                    mtxHOKUKO_NO.Enabled = False

                    For Each page As TabPage In TabSTAGE.TabPages
                        If page.text = "現ステージ" Then
                            TabSTAGE.SelectedIndex = page.TabIndex
                            Exit For
                        End If
                    Next page

                Case Else
                    Throw New ArgumentException(My.Resources.ErrMsgException, intMODE.ToString)
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
                mtxADD_SYAIN_NAME.Text = .Item("")
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
                mtxHENKYAKU.Text = .Item("")
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
                    page.Enabled = FunblnOwnCreated(ENM_SYONIN_HOKOKU_ID._1_NCR, PrDataRow("HOKOKUSYO_NO"), PrDataRow("SYONIN_JUN"))
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

            'Using DB As ClsDbUtility = DBOpen()
            '    Dim intRET As Integer
            '    Dim sqlEx As New Exception
            '    Dim blnErr As Boolean

            '    Try
            '        DB.BeginTransaction()

            '        ''-----存在チェック
            '        'sbSQL.Remove(0, sbSQL.Length)
            '        'sbSQL.Append("SELECT * FROM " & NameOf(MODEL.M001_SETTING) & "")
            '        'sbSQL.Append(" WHERE ITEM_NAME ='" & Me.cmbKOMO_NM.Text.Trim & "' ")
            '        'sbSQL.Append(" AND ITEM_VALUE ='" & Me.mtxVALUE.Text.Trim & "' ")
            '        'dsList = DB.GetDataSet(sbSQL.ToString, conblnNonMsg)
            '        'If dsList.Tables(0).Rows.Count > 0 Then '存在時
            '        '    MessageBox.Show("既に登録済みのデータです。" & vbCrLf & "入力データを確認して下さい。", "存在チェック", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            '        '    Return False
            '        'End If


            '        '-----INSERT
            '        'sbSQL.Remove(0, sbSQL.Length)
            '        'sbSQL.Append("INSERT INTO " & NameOf(MODEL.D003_NCR_J) & " ")
            '        'sbSQL.Append(" VALUES ( ")
            '        ''項目グループ
            '        'sbSQL.Append(" '" & Me.mtxKOMO_GROUP.Text.Trim & "'")
            '        ''項目名
            '        'sbSQL.Append(" ,'" & Me.cmbKOMO_NM.Text.Trim & "'")
            '        ''項目値
            '        'sbSQL.Append(" ,'" & Me.mtxVALUE.Text.Trim & "'")
            '        ''表示値
            '        'sbSQL.Append(" ,'" & Nz(Me.mtxDISP.Text.Trim, " ") & "'")
            '        ''表示順
            '        'sbSQL.Append(" ," & Me.cmbJYUN.SelectedValue & "")
            '        ''既定値フラグ
            '        'sbSQL.Append(" ,'" & IIf(Me.chkDefaultVaue.Checked = True, "1", "0") & "'")
            '        ''備考
            '        'sbSQL.Append(" ,'" & Nz(Me.mtxBIKOU.Text.Trim, " ") & "'")
            '        ''追加日時
            '        'sbSQL.Append(" ,dbo.GetSysDateString()")
            '        ''追加日時
            '        'sbSQL.Append(" ," & pub_SYAIN_INFO.SYAIN_ID & "")
            '        ''追加担当者
            '        'sbSQL.Append(" ,dbo.GetSysDateString()")
            '        ''更新担当者
            '        'sbSQL.Append(" ," & pub_SYAIN_INFO.SYAIN_ID & "")
            '        ''削除日時
            '        'sbSQL.Append(" ,' '")
            '        ''削除担当者
            '        'sbSQL.Append(" ,0")
            '        'sbSQL.Append(" )")

            '        intRET = DB.ExecuteNonQuery(sbSQL.ToString, conblnNonMsg, sqlEx)
            '        If intRET <> 1 Then
            '            'エラーログ出力
            '            Dim strErrMsg As String = My.Resources.ErrLogSqlExecutionFailure & sbSQL.ToString & "|" & sqlEx.Message
            '            WL.WriteLogDat(strErrMsg)
            '            blnErr = True
            '            Return False
            '        End If
            '    Finally
            '        'トランザクション
            '        DB.Commit(Not blnErr)
            '    End Try
            'End Using

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



            '入力チェック
            If FunCheckInput() = False Then
                Return False
            End If

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

    '検索フィルタ変更
    Private Sub SearchFilterValueChanged(sender As System.Object, e As System.EventArgs)
        '検索
        Me.cmdFunc1.PerformClick()

    End Sub

    Private Sub CmbFUTEKIGO_STATUS_SelectedValueChanged(sender As Object, e As EventArgs) Handles cmbFUTEKIGO_STATUS.SelectedValueChanged
        'If cmbFUTEKIGO_STATUS.SelectedValue = 1 Then

        'End If
    End Sub

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

#End Region
#Region "   STAGE5"

#End Region
#Region "   STAGE6"

#End Region
#Region "   STAGE7"

#End Region
#Region "   STAGE8"

#End Region
#Region "   STAGE9"

#End Region
#Region "   STAGE10"

#End Region
#Region "   STAGE11"

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
        If mtxPict1Path.Tag Is Nothing OrElse mtxPict1Path.Tag.ToString.IsNullOrWhiteSpace Then
        Else
            ofd.InitialDirectory = IO.Path.GetDirectoryName(mtxPict1Path.Tag)
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

    Private Sub MtxPict1Path_DragEnter(sender As Object, e As DragEventArgs) Handles mtxPict1Path.DragEnter
        'ドラッグされたデータ形式を調べ、ファイルのときはコピーとする
        If e.Data.GetDataPresent(DataFormats.FileDrop) Then
            e.Effect = DragDropEffects.Copy
        Else
            e.Effect = DragDropEffects.None
        End If
    End Sub

    Private Sub MtxPict1Path_DragDrop(sender As Object, e As DragEventArgs) Handles mtxPict1Path.DragDrop
        Call SetPict1Data(CType(e.Data.GetData(DataFormats.FileDrop, False), String())(0))
    End Sub

    Private Sub SetPict1Data(ByVal strFileName As String)
        mtxPict1Path.Text = CompactString(strFileName, mtxPict1Path, EllipsisFormat._4_Path)
        mtxPict1Path.Tag = strFileName
        pnlPict1.Image = Image.FromFile(strFileName)
        pnlPict1.Cursor = Cursors.Hand
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
        If mtxPict2Path.Tag Is Nothing OrElse mtxPict2Path.Tag.ToString.IsNullOrWhiteSpace Then
        Else
            ofd.InitialDirectory = IO.Path.GetDirectoryName(mtxPict2Path.Tag)
        End If

        If ofd.ShowDialog() = DialogResult.OK Then
            mtxPict2Path.Text = CompactString(ofd.FileName, mtxPict2Path, EllipsisFormat._4_Path)
            mtxPict2Path.Tag = ofd.FileName
            pnlPict2.Image = Image.FromFile(ofd.FileName)
            pnlPict2.Cursor = Cursors.Hand
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

    Private Sub PnlPict2_DragEnter(sender As Object, e As DragEventArgs) Handles pnlPict2.DragEnter
        'ドラッグされたデータ形式を調べ、ファイルのときはコピーとする
        If e.Data.GetDataPresent(DataFormats.FileDrop) Then
            e.Effect = DragDropEffects.Copy
        Else
            e.Effect = DragDropEffects.None
        End If
    End Sub

    Private Sub PnlPict2_DragDrop(sender As Object, e As DragEventArgs) Handles pnlPict2.DragDrop
        Call SetPict2Data(e.Data.GetData(DataFormats.FileDrop, False))
    End Sub

    Private Sub MtxPict2Path_DragEnter(sender As Object, e As DragEventArgs) Handles mtxPict2Path.DragEnter
        'ドラッグされたデータ形式を調べ、ファイルのときはコピーとする
        If e.Data.GetDataPresent(DataFormats.FileDrop) Then
            e.Effect = DragDropEffects.Copy
        Else
            e.Effect = DragDropEffects.None
        End If
    End Sub

    Private Sub MtxPict2Path_DragDrop(sender As Object, e As DragEventArgs) Handles mtxPict2Path.DragDrop
        Call SetPict2Data(e.Data.GetData(DataFormats.FileDrop, False))
    End Sub

    Private Sub SetPict2Data(ByVal strFileName As String)
        mtxPict2Path.Text = CompactString(strFileName, mtxPict1Path, EllipsisFormat._4_Path)
        mtxPict2Path.Tag = strFileName
        pnlPict2.Image = Image.FromFile(strFileName)
        pnlPict2.Cursor = Cursors.Hand
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


        'DEBUG:
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