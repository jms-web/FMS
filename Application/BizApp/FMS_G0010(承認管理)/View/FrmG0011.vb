Imports JMS_COMMON.ClsPubMethod
Imports MODEL

''' <summary>
''' NCR入力画面
''' </summary>
Public Class FrmG0011

#Region "定数・変数"

    ''' <summary>
    ''' タブ非表示管理用
    ''' </summary>
    Private _tabPageManager As TabPageManager

    Private _tabPageManagerST08Sub As TabPageManager

    'Model
    Private _V002_NCR_J As New MODEL.V002_NCR_J

    Private _V003_SYONIN_J_KANRI_List As New List(Of MODEL.V003_SYONIN_J_KANRI)
    Private _V004_HOKOKU_SOUSA As New MODEL.V004_HOKOKU_SOUSA
    Private _V005_CAR_J As New MODEL.V005_CAR_J

    '入力必須コントロール検証判定
    Private IsValidated As Boolean = True

    '是正処置要否判定=CAR編集画面起動判定
    Private blnEnableCAREdit As Boolean

#End Region

#Region "プロパティ"

    ''' <summary>
    ''' 処理モード
    ''' </summary>
    Public Property PrMODE As Integer

    ''' <summary>
    ''' 一覧の選択行データ
    ''' </summary>
    Public Property PrDataRow As DataRow

    '現在のステージ 承認順
    Public Property PrCurrentStage As Integer

    Public Property PrHOKOKU_NO As String

    'CAR編集画面から開かれているか
    Public Property PrIsDialog As Boolean

    Public Property PrSAI_FUTEKIGO As Boolean

#End Region

#Region "コンストラクタ"

    ''' <summary>
    ''' コンストラクタ
    ''' </summary>
    ''' <remarks>コンストラクタ</remarks>
    Public Sub New()

        ' この呼び出しはデザイナーで必要です。
        InitializeComponent()

        Me.Icon = My.Resources._icoAppForm32x32
        Me.ShowIcon = True

        'ツールチップメッセージ
        'MyBase.ToolTip.SetToolTip(Me.cmdFunc3, My.Resources.infoToolTipMsgNotFoundData)
        MyBase.ToolTip.SetToolTip(Me.cmdFunc1, "処置担当者以外は登録内容の変更は出来ません")
        MyBase.ToolTip.SetToolTip(Me.cmdFunc2, "処置担当者以外は承認依頼出来ません")
        MyBase.ToolTip.SetToolTip(Me.cmdFunc4, "このステージでは使用出来ません")
        MyBase.ToolTip.SetToolTip(Me.cmdFunc5, "このステージでは使用出来ません")
        MyBase.ToolTip.SetToolTip(Me.cmdFunc10, "このステージでは使用出来ません")
        MyBase.ToolTip.SetToolTip(Me.cmdFunc11, "このステージでは使用出来ません")

        If PrMODE = ENM_DATA_OPERATION_MODE._1_ADD Then
            MyBase.ToolTip.SetToolTip(Me.cmdFunc9, "このステージでは使用出来ません")
        Else
            MyBase.ToolTip.SetToolTip(Me.cmdFunc9, "編集権限がありません")
        End If

        D003NCRJBindingSource.DataSource = _D003_NCR_J
        mtxHOKUKO_NO.ReadOnly = True
        dtDraft.ReadOnly = True
        cmbKISO_TANTO.ReadOnly = True
        cmbHINMEI.ReadOnly = True
        pnlPict1.AllowDrop = True
        pnlPict2.AllowDrop = True

        '未選択時ウォーターマーク+バインドが必要なコンボボックスのための設定
        cmbKISO_TANTO.NullValue = 0
        cmbKISYU.NullValue = 0
        cmbST07_SAISIN_TANTO.NullValue = 0
        cmbST08_1_HAIKYAKU_TANTO.NullValue = 0
        cmbST08_2_TANTO_SEIZO.NullValue = 0
        cmbST08_2_TANTO_SEIGI.NullValue = 0
        cmbST08_2_TANTO_KENSA.NullValue = 0
        cmbST08_4_KISYU.NullValue = 0
        cmbST01_DestTANTO.NullValue = 0
        cmbST02_DestTANTO.NullValue = 0
        cmbST03_DestTANTO.NullValue = 0
        cmbST04_DestTANTO.NullValue = 0
        cmbST04_HASSEI_KOTEI_GL_TANTO.NullValue = 0
        cmbST04_CAR_TANTO.NullValue = 0
        cmbST05_DestTANTO.NullValue = 0
        cmbST06_DestTANTO.NullValue = 0
        cmbST08_DestTANTO.NullValue = 0
        cmbST09_DestTANTO.NullValue = 0
        cmbST13_DestTANTO.NullValue = 0
        cmbST14_DestTANTO.NullValue = 0
        cmbST15_DestTANTO.NullValue = 0

        cmbKISO_TANTO.ImeMode = ImeMode.On
        cmbST07_SAISIN_TANTO.ImeMode = ImeMode.On
        cmbST08_1_HAIKYAKU_TANTO.ImeMode = ImeMode.On
        cmbST08_2_TANTO_SEIZO.ImeMode = ImeMode.On
        cmbST08_2_TANTO_SEIGI.ImeMode = ImeMode.On
        cmbST08_2_TANTO_KENSA.ImeMode = ImeMode.On
        cmbST01_DestTANTO.ImeMode = ImeMode.On
        cmbST02_DestTANTO.ImeMode = ImeMode.On
        cmbST03_DestTANTO.ImeMode = ImeMode.On
        cmbST04_DestTANTO.ImeMode = ImeMode.On
        cmbST04_HASSEI_KOTEI_GL_TANTO.ImeMode = ImeMode.On
        cmbST04_CAR_TANTO.ImeMode = ImeMode.On
        cmbST05_DestTANTO.ImeMode = ImeMode.On
        cmbST06_DestTANTO.ImeMode = ImeMode.On
        cmbST08_DestTANTO.ImeMode = ImeMode.On
        cmbST09_DestTANTO.ImeMode = ImeMode.On
        cmbST13_DestTANTO.ImeMode = ImeMode.On
        cmbST14_DestTANTO.ImeMode = ImeMode.On
        cmbST15_DestTANTO.ImeMode = ImeMode.On

        pnlST01.BackColor = Color.Transparent
        pnlST02.BackColor = Color.Transparent
        pnlST03.BackColor = Color.Transparent
        pnlST04.BackColor = Color.Transparent
        pnlST05.BackColor = Color.Transparent
        pnlST06.BackColor = Color.Transparent
        pnlST07.BackColor = Color.Transparent
        pnlST08.BackColor = Color.Transparent
        pnlST09.BackColor = Color.Transparent
        pnlST10.BackColor = Color.Transparent
        pnlST11.BackColor = Color.Transparent
        pnlST12.BackColor = Color.Transparent
        pnlST13.BackColor = Color.Transparent
        pnlST14.BackColor = Color.Transparent
        pnlST15.BackColor = Color.Transparent
        pnlST16.BackColor = Color.Transparent

        txtST01_KEKKA.Multiline = True

        rsbtnST99.Enabled = False
    End Sub

#End Region

#Region "Form関連"

#Region "LOAD"

    Private Sub FrmLoad(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        Try
            Me.Visible = False
            '-----フォーム初期設定(親フォームから呼び出し)
            Call FunFormCommonSetting(pub_APP_INFO, pub_SYAIN_INFO, My.Application.Info.Version.ToString)
            Using DB As ClsDbUtility = DBOpen()
                lblTytle.Text = FunGetCodeMastaValue(DB, "PG_TITLE", Me.GetType.ToString)
            End Using

            'バインディング・モデルクリア
            Call FunClearBindingD003()
            _D003_NCR_J.Clear()
            _D004_SYONIN_J_KANRI.clear()
            _R001_HOKOKU_SOUSA.Clear()
            _R002_HOKOKU_TENSO.clear()

            '-----コントロールデータソース設定
            cmbKISO_TANTO.SetDataSource(tblTANTO, ENM_COMBO_SELECT_VALUE_TYPE._0_Required)
            cmbKISYU.SetDataSource(tblKISYU.ExcludeDeleted, ENM_COMBO_SELECT_VALUE_TYPE._0_Required)
            cmbBUHIN_BANGO.SetDataSource(tblBUHIN.ExcludeDeleted, ENM_COMBO_SELECT_VALUE_TYPE._0_Required)
            cmbFUTEKIGO_STATUS.SetDataSource(tblFUTEKIGO_STATUS_KB.ExcludeDeleted, ENM_COMBO_SELECT_VALUE_TYPE._0_Required)
            cmbFUTEKIGO_KB.SetDataSource(tblFUTEKIGO_KB.ExcludeDeleted, ENM_COMBO_SELECT_VALUE_TYPE._0_Required)
            cmbSYANAI_CD.SetDataSource(tblSYANAI_CD.ExcludeDeleted, ENM_COMBO_SELECT_VALUE_TYPE._0_Required)

            'DEBUG:再不適合後エラー？
            cmbBUMON.SetDataSource(tblBUMON.ExcludeDeleted, ENM_COMBO_SELECT_VALUE_TYPE._0_Required)
            Dim blnIsAdmin As Boolean = HasAdminAuth(pub_SYAIN_INFO.SYAIN_ID)
            If blnIsAdmin Then
                'システム管理者のみ制限解除
            Else
                Select Case pub_SYAIN_INFO.BUMON_KB
                    Case Context.ENM_BUMON_KB._1_風防, Context.ENM_BUMON_KB._2_LP
                        Dim dt As DataTable = DirectCast(cmbBUMON.DataSource, DataTable).
                                                    AsEnumerable.
                                                    Where(Function(r) r.Field(Of String)("VALUE") = "1" Or r.Field(Of String)("VALUE") = "2").
                                                    CopyToDataTable
                        cmbBUMON.SetDataSource(dt, ENM_COMBO_SELECT_VALUE_TYPE._1_Filter)

                        cmbBUMON.SelectedValue = pub_SYAIN_INFO.BUMON_KB

                    Case Context.ENM_BUMON_KB._3_複合材
                        Dim dt As DataTable = DirectCast(cmbBUMON.DataSource, DataTable).
                                                    AsEnumerable.
                                                    Where(Function(r) r.Field(Of String)("VALUE") = pub_SYAIN_INFO.BUMON_KB).
                                                    CopyToDataTable
                        cmbBUMON.SetDataSource(dt, ENM_COMBO_SELECT_VALUE_TYPE._1_Filter)

                        cmbBUMON.SelectedValue = pub_SYAIN_INFO.BUMON_KB
                    Case Else
                        'Err
                End Select
            End If

            'バインディングセット
            Call FunSetBindingD003()

            Me.Cursor = Cursors.WaitCursor
            '-----処理モード別画面初期化
            If FunInitializeControls(PrMODE) Then
            Else
                'Me.Close()
            End If

            Me.WindowState = FormWindowState.Maximized

            If _D003_NCR_J.BUMON_KB.ToVal = Context.ENM_BUMON_KB._2_LP Then
                Me.ActiveControl = cmbSYANAI_CD
            Else
                Me.ActiveControl = cmbKISYU
            End If
        Finally
            Call FunInitFuncButtonEnabled()
            Me.Cursor = Cursors.Default
            Me.Visible = True
        End Try
    End Sub

#End Region

    Private Sub Frm_Shown(sender As Object, e As EventArgs) Handles MyBase.Shown
        Me.Owner.Visible = False
    End Sub

    Private Sub Frm_Closed(sender As Object, e As EventArgs) Handles Me.Closed
        Me.Owner.Visible = True
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

            Me.Cursor = Cursors.WaitCursor

            'ボタン不可/ボタンINDEX取得
            For intCNT = 0 To Me.cmdFunc.Length - 1
                Me.cmdFunc(intCNT).Enabled = False
                If cmdFunc(intCNT) Is sender Then intFUNC = intCNT + 1
            Next

            'ボタンINDEX毎の処理
            Select Case intFUNC
                Case 1  '保存

                    '入力チェック
                    If FunCheckInput(ENM_SAVE_MODE._1_保存) Then
                        If MessageBox.Show("入力内容を保存しますか？", "登録確認", MessageBoxButtons.YesNo, MessageBoxIcon.Information) = DialogResult.Yes Then

                            If FunSAVE(ENM_SAVE_MODE._1_保存) Then
                                Me.DialogResult = DialogResult.OK
                                MessageBox.Show("入力内容を保存しました", "保存完了", MessageBoxButtons.OK, MessageBoxIcon.Information)

                                If blnEnableCAREdit Then
                                    If MessageBox.Show("CAR起草入力画面を表示しますか?", "CAR起草入力", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes Then
                                        Call OpenFormCAR()
                                        blnEnableCAREdit = False
                                    End If
                                End If
                            Else
                                MessageBox.Show("保存処理に失敗しました。", "保存失敗", MessageBoxButtons.OK, MessageBoxIcon.Error)
                            End If
                        End If
                    End If

                Case 2  '承認申請
                    '入力チェック
                    If FunCheckInput(ENM_SAVE_MODE._2_承認申請) Then
                        If MessageBox.Show("申請しますか？", "申請処理確認", MessageBoxButtons.YesNo, MessageBoxIcon.Information) = DialogResult.Yes Then
                            If FunSAVE(ENM_SAVE_MODE._2_承認申請) Then
                                MessageBox.Show("申請しました", "申請処理完了", MessageBoxButtons.OK, MessageBoxIcon.Information)
                                Me.DialogResult = DialogResult.OK

                                'CAR編集可能判定
                                If blnEnableCAREdit Then
                                    If MessageBox.Show("CAR起草入力画面を表示しますか?", "CAR起草入力", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes Then
                                        Call OpenFormCAR()
                                        blnEnableCAREdit = False
                                    End If
                                End If

                                'SPEC: 80-3.③
                                If PrCurrentStage = ENM_NCR_STAGE._80_処置実施 AndAlso Val(_D003_NCR_J.KENSA_KEKKA_KB) = ENM_KENSA_KEKKA_KB._1_不合格 Then
                                    If MessageBox.Show("再不適合処置データを続けて作成しますか?", "再不適合処置確認", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes Then
                                        If FunSAVE_D003_SAI_FUTEKIGO() Then
                                            PrHOKOKU_NO = _D003_NCR_J.HOKOKU_NO
                                            PrCurrentStage = ENM_NCR_STAGE._10_起草入力
                                            PrSAI_FUTEKIGO = True
                                        End If
                                    End If
                                End If

                                'SPEC: 2.(3).E.④
                                Me.Close()
                            Else
                                MessageBox.Show("保存処理に失敗しました。", "保存失敗", MessageBoxButtons.OK, MessageBoxIcon.Error)
                            End If
                        End If
                    End If

                Case 4  '転送

                    If FunCheckInput(ENM_SAVE_MODE._1_保存) Then
                        If OpenFormTENSO() Then
                            If HasAdminAuth(pub_SYAIN_INFO.SYAIN_ID) Then
                                Me.DialogResult = DialogResult.OK
                            Else
                                If FunSAVE(ENM_SAVE_MODE._1_保存, True) Then
                                    Me.DialogResult = DialogResult.OK
                                Else
                                    MessageBox.Show("保存処理に失敗しました。", "保存失敗", MessageBoxButtons.OK, MessageBoxIcon.Error)
                                End If
                            End If
                        End If
                    End If


                Case 5  '差戻し
                    Call OpenFormSASIMODOSI()
                Case 9  'CAR編集

                    'SPEC: 40-6
                    If PrCurrentStage <= ENM_NCR_STAGE._40_事前審査判定及びCAR要否判定 AndAlso FunHasAuthCAREdit(_D003_NCR_J.HOKOKU_NO, pub_SYAIN_INFO.SYAIN_ID) = False Then
                        MessageBox.Show("CARは起草されていません。" & vbCrLf & "権限のある社員にて起草後に開いて下さい", "権限なし", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    Else
                        Call OpenFormCAR()
                    End If

                Case 10  'レポート印刷
                    Call FunOpenReportNCR()

                Case 11 '履歴表示
                    Call OpenFormHistory(Context.ENM_SYONIN_HOKOKUSYO_ID._1_NCR, _D003_NCR_J.HOKOKU_NO)

                Case 12 '閉じる
                    If pub_intOPEN_MODE = 1 Then
                        Environment.Exit(0)
                    Else
                        Me.Close()
                    End If
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

            Me.Cursor = Cursors.Default
        End Try
    End Sub

#End Region

#Region "保存・承認申請"

#Region "   保存MAIN"

    ''' <summary>
    ''' 保存・承認申請処理メイン
    ''' </summary>
    ''' <param name="enmSAVE_MODE"></param>
    ''' <returns></returns>
    Private Function FunSAVE(ByVal enmSAVE_MODE As ENM_SAVE_MODE, Optional blnTENSO As Boolean = False) As Boolean
        Try

            Using DB As ClsDbUtility = DBOpen()
                Dim blnErr As Boolean
                Try '-----トランザクション
                    DB.BeginTransaction()

                    Select Case PrCurrentStage
                        Case ENM_NCR_STAGE._81_処置実施_生技 To ENM_NCR_STAGE._100_処置実施決裁_製造課長
                            'データは更新しない
                        Case Else
                            'マスタ更新
                            If FunSAVE_M106(DB) = False Then blnErr = True : Return False

                            'SPEC: 2.(3).D.①.レコード更新
                            If FunSAVE_D003(DB, enmSAVE_MODE) = False Then blnErr = True : Return False
                            If FunSAVE_FILE(DB) = False Then blnErr = True : Return False
                    End Select

                    If Not blnTENSO Then
                        If FunSAVE_D004(DB, enmSAVE_MODE) = False Then blnErr = True : Return False                        '
                        If FunSAVE_R001(DB, enmSAVE_MODE) = False Then blnErr = True : Return False
                    End If
                Finally
                    DB.Commit(Not blnErr)
                End Try
            End Using

            Return True
        Catch ex As Exception
            Throw
            Return False
        Finally
        End Try
    End Function

#End Region

#Region "   ファイル保存"

    ''' <summary>
    ''' NCR添付ファイル保存
    ''' </summary>
    ''' <param name="DB"></param>
    ''' <returns></returns>
    Private Function FunSAVE_FILE(ByRef DB As ClsDbUtility) As Boolean

        If _D003_NCR_J.FILE_PATH.IsNullOrWhiteSpace And _D003_NCR_J.G_FILE_PATH1.IsNullOrWhiteSpace And _D003_NCR_J.G_FILE_PATH2.IsNullOrWhiteSpace Then
            Return True
        Else
            'SPEC: 2.(3).D.②.添付ファイル保存
            Dim strRootDir As String
            Dim strMsg As String
            strRootDir = FunConvPathString(FunGetCodeMastaValue(DB, "添付ファイル保存先", My.Application.Info.AssemblyName))
            If strRootDir.IsNullOrWhiteSpace OrElse Not System.IO.Directory.Exists(strRootDir) Then

                strMsg = "添付ファイル保存先が設定されていないか、アクセス出来ません。" & vbCrLf &
                         "添付ファイルはシステムに保存されませんが、" & vbCrLf &
                         "登録処理を続行しますか？"

                If MessageBox.Show(strMsg, "ファイル保存先アクセス不可", MessageBoxButtons.OKCancel, MessageBoxIcon.Exclamation) <> vbOK Then
                    Me.DialogResult = DialogResult.Abort
                    _D003_NCR_J.FILE_PATH = ""
                    _D003_NCR_J.G_FILE_PATH1 = ""
                    _D003_NCR_J.G_FILE_PATH2 = ""
                    Return True
                Else
                    Me.DialogResult = DialogResult.Abort
                    Return True
                End If
            Else
                Try
                    System.IO.Directory.CreateDirectory(strRootDir & _D003_NCR_J.HOKOKU_NO)
                    If Not _D003_NCR_J.FILE_PATH.IsNullOrWhiteSpace AndAlso Not System.IO.File.Exists(strRootDir & _D003_NCR_J.HOKOKU_NO.Trim & "\" & _D003_NCR_J.FILE_PATH) Then
                        System.IO.File.Copy(lbltmpFile1.Links.Item(0).LinkData, strRootDir & _D003_NCR_J.HOKOKU_NO.Trim & "\" & _D003_NCR_J.FILE_PATH, True)
                    End If
                    If Not _D003_NCR_J.G_FILE_PATH1.IsNullOrWhiteSpace AndAlso Not System.IO.File.Exists(strRootDir & _D003_NCR_J.HOKOKU_NO.Trim & "\" & _D003_NCR_J.G_FILE_PATH1) Then
                        System.IO.File.Copy(lblPict1Path.Links.Item(0).LinkData, strRootDir & _D003_NCR_J.HOKOKU_NO.Trim & "\" & _D003_NCR_J.G_FILE_PATH1, True)
                    End If
                    If Not _D003_NCR_J.G_FILE_PATH2.IsNullOrWhiteSpace AndAlso Not System.IO.File.Exists(strRootDir & _D003_NCR_J.HOKOKU_NO.Trim & "\" & _D003_NCR_J.G_FILE_PATH2) Then
                        System.IO.File.Copy(lblPict2Path.Links.Item(0).LinkData, strRootDir & _D003_NCR_J.HOKOKU_NO.Trim & "\" & _D003_NCR_J.G_FILE_PATH2, True)
                    End If

                    Return True
                Catch exIO As UnauthorizedAccessException
                    strMsg = "添付ファイル保存先のアクセス権限がありません。" & vbCrLf &
                             "添付ファイル保存先:" & strRootDir
                    MessageBox.Show(strMsg, "ファイル保存先アクセス不可", MessageBoxButtons.OK, MessageBoxIcon.Error)
                    Return False
                Catch ex As Exception
                    Throw
                    Return False
                End Try
            End If
        End If
    End Function

#End Region

#Region "   マスタ更新"

    ''' <summary>
    ''' 部品番号マスタ更新
    ''' </summary>
    ''' <param name="DB"></param>
    ''' <param name="enmSAVE_MODE"></param>
    ''' <returns></returns>
    Private Function FunSAVE_M106(ByRef DB As ClsDbUtility) As Boolean
        Dim sbSQL As New System.Text.StringBuilder
        Dim intRET As Integer
        sbSQL.Remove(0, sbSQL.Length)
        sbSQL.Append($"UPDATE {NameOf(MODEL.M106_BUHIN)} SET")
        sbSQL.Append($" {NameOf(MODEL.M106_BUHIN.BUHIN_NAME)}='{_D003_NCR_J.BUHIN_NAME.Trim}'")
        sbSQL.Append($" ,{NameOf(MODEL.M106_BUHIN.UPD_SYAIN_ID)}={pub_SYAIN_INFO.SYAIN_ID}")
        sbSQL.Append($" ,{NameOf(MODEL.M106_BUHIN.UPD_YMDHNS)}=dbo.GetSysDateString()")
        sbSQL.Append($" WHERE {NameOf(MODEL.M106_BUHIN.BUMON_KB)}='{_D003_NCR_J.BUMON_KB}'")
        sbSQL.Append($" AND {NameOf(MODEL.M106_BUHIN.BUHIN_BANGO)}='{_D003_NCR_J.BUHIN_BANGO}'")

        intRET = DB.ExecuteNonQuery(sbSQL.ToString, conblnNonMsg)

        Return True
    End Function


#End Region

#Region "   D003保存"

    ''' <summary>
    ''' NCR実績更新
    ''' </summary>
    ''' <param name="DB"></param>
    ''' <returns></returns>
    Private Function FunSAVE_D003(ByRef DB As ClsDbUtility, ByVal enmSAVE_MODE As ENM_SAVE_MODE) As Boolean
        Dim sbSQL As New System.Text.StringBuilder
        Dim strRET As String
        Dim sqlEx As New Exception
        Dim strSysDate As String

        strSysDate = DB.GetSysDateString()

        '-----未保存時、報告書No取得
        If _D003_NCR_J.HOKOKU_NO.IsNullOrWhiteSpace Or _D003_NCR_J.HOKOKU_NO = "<新規>" Then
            Dim objParam As System.Data.Common.DbParameter = DB.DbCommand.CreateParameter
            Dim lstParam As New List(Of System.Data.Common.DbParameter)
            With objParam
                .ParameterName = NameOf(_D003_NCR_J.HOKOKU_NO)
                .DbType = DbType.String
                .Direction = ParameterDirection.Output
                .Size = 8
            End With
            lstParam.Add(objParam)
            If DB.Fun_blnExecStored("dbo.ST01_GET_HOKOKU_NO", lstParam) = True Then
                _D003_NCR_J.HOKOKU_NO = DB.DbCommand.Parameters(NameOf(_D003_NCR_J.HOKOKU_NO)).Value
            Else
                Return False
            End If
        End If

        _D003_NCR_J.ADD_YMDHNS = strSysDate
        _D003_NCR_J.ADD_SYAIN_ID = pub_SYAIN_INFO.SYAIN_ID
        _D003_NCR_J.UPD_SYAIN_ID = pub_SYAIN_INFO.SYAIN_ID

        '-----モデル更新
        If (PrCurrentStage = ENM_NCR_STAGE._80_処置実施 AndAlso Val(_D003_NCR_J.KENSA_KEKKA_KB) = ENM_KENSA_KEKKA_KB._1_不合格) Or
            (PrCurrentStage = ENM_NCR_STAGE._120_abcde処置確認 And enmSAVE_MODE = ENM_SAVE_MODE._2_承認申請) Then
            _D003_NCR_J._CLOSE_FG = 1
        End If

        Select Case enmSAVE_MODE
            Case ENM_SAVE_MODE._1_保存
            Case ENM_SAVE_MODE._2_承認申請
                Select Case PrCurrentStage
                    Case ENM_NCR_STAGE._40_事前審査判定及びCAR要否判定
                        If _D003_NCR_J.JIZEN_SINSA_SYAIN_ID = 0 Then _D003_NCR_J.JIZEN_SINSA_SYAIN_ID = pub_SYAIN_INFO.SYAIN_ID
                        'UNDONE: getdbsysdate
                        _D003_NCR_J.JIZEN_SINSA_YMD = Now.ToString("yyyyMMdd")
                    Case ENM_NCR_STAGE._50_事前審査確認
                        _D003_NCR_J.SAISIN_KAKUNIN_SYAIN_ID = pub_SYAIN_INFO.SYAIN_ID
                        _D003_NCR_J.SAISIN_KAKUNIN_YMD = Now.ToString("yyyyMMdd")
                    Case ENM_NCR_STAGE._60_再審審査判定_技術代表
                        _D003_NCR_J.SAISIN_GIJYUTU_SYAIN_ID = pub_SYAIN_INFO.SYAIN_ID
                        _D003_NCR_J.SAISIN_GIJYUTU_YMD = Now.ToString("yyyyMMdd")
                    Case ENM_NCR_STAGE._61_再審審査判定_品証代表
                        _D003_NCR_J.SAISIN_HINSYO_SYAIN_ID = pub_SYAIN_INFO.SYAIN_ID
                        _D003_NCR_J.SAISIN_HINSYO_YMD = Now.ToString("yyyyMMdd")
                    Case ENM_NCR_STAGE._70_顧客再審処置_I_tag
                        _D003_NCR_J.KOKYAKU_SAISIN_TANTO_ID = pub_SYAIN_INFO.SYAIN_ID
                        _D003_NCR_J.KOKYAKU_SAISIN_YMD = Now.ToString("yyyyMMdd")

                    Case ENM_NCR_STAGE._110_abcde処置担当

                    Case Else
                        'UNDONE: Err
                End Select
        End Select

        '-----MERGE
        sbSQL.Remove(0, sbSQL.Length)
        sbSQL.Append($"MERGE INTO {NameOf(MODEL.D003_NCR_J)} AS SrcT")
        sbSQL.Append(" USING (")
        sbSQL.Append(" SELECT")
        sbSQL.Append($" '{_D003_NCR_J.HOKOKU_NO}' AS {NameOf(_D003_NCR_J.HOKOKU_NO)}")
        sbSQL.Append($" ,'{_D003_NCR_J.BUMON_KB}' AS {NameOf(_D003_NCR_J.BUMON_KB)}")
        sbSQL.Append($" ,'{_D003_NCR_J._CLOSE_FG}' AS {NameOf(_D003_NCR_J.CLOSE_FG)}")
        sbSQL.Append($" ,{_D003_NCR_J.KISYU_ID} AS {NameOf(_D003_NCR_J.KISYU_ID)}")
        sbSQL.Append($" ,'{_D003_NCR_J.SYANAI_CD}' AS {NameOf(_D003_NCR_J.SYANAI_CD)}")
        sbSQL.Append($" ,'{_D003_NCR_J.BUHIN_BANGO}' AS {NameOf(_D003_NCR_J.BUHIN_BANGO)}")
        sbSQL.Append($" ,'{_D003_NCR_J.BUHIN_NAME.ConvertSqlEscape}' AS {NameOf(_D003_NCR_J.BUHIN_NAME)}")
        sbSQL.Append($" ,'{_D003_NCR_J.GOKI.ConvertSqlEscape}' AS {NameOf(_D003_NCR_J.GOKI)}")
        sbSQL.Append($" ,{_D003_NCR_J.SURYO} AS {NameOf(_D003_NCR_J.SURYO)}")
        sbSQL.Append($" ,'{_D003_NCR_J._SAIHATU}' AS {NameOf(_D003_NCR_J.SAIHATU)}")
        sbSQL.Append($" ,'{_D003_NCR_J.FUTEKIGO_JYOTAI_KB}' AS {NameOf(_D003_NCR_J.FUTEKIGO_JYOTAI_KB)}")
        sbSQL.Append($" ,'{_D003_NCR_J.FUTEKIGO_NAIYO.ConvertSqlEscape}' AS {NameOf(_D003_NCR_J.FUTEKIGO_NAIYO)}")
        sbSQL.Append($" ,'{_D003_NCR_J.FUTEKIGO_KB}' AS {NameOf(_D003_NCR_J.FUTEKIGO_KB)}")
        sbSQL.Append($" ,'{_D003_NCR_J.FUTEKIGO_S_KB}' AS {NameOf(_D003_NCR_J.FUTEKIGO_S_KB)}")
        sbSQL.Append($" ,'{_D003_NCR_J.ZUMEN_KIKAKU.ConvertSqlEscape}' AS {NameOf(_D003_NCR_J.ZUMEN_KIKAKU)}")
        sbSQL.Append($" ,'{_D003_NCR_J.YOKYU_NAIYO.ConvertSqlEscape}' AS {NameOf(_D003_NCR_J.YOKYU_NAIYO)}")
        sbSQL.Append($" ,'{_D003_NCR_J.KANSATU_KEKKA.ConvertSqlEscape}' AS {NameOf(_D003_NCR_J.KANSATU_KEKKA)}")
        sbSQL.Append($" ,'{_D003_NCR_J._ZESEI_SYOCHI_YOHI_KB}' AS {NameOf(_D003_NCR_J.ZESEI_SYOCHI_YOHI_KB)}")
        sbSQL.Append($" ,'{_D003_NCR_J.ZESEI_NASI_RIYU.ConvertSqlEscape}' AS {NameOf(_D003_NCR_J.ZESEI_NASI_RIYU)}")
        sbSQL.Append($" ,{_D003_NCR_J.HASSEI_KOTEI_GL_SYAIN_ID} AS {NameOf(_D003_NCR_J.HASSEI_KOTEI_GL_SYAIN_ID)}")
        sbSQL.Append($" ,'{_D003_NCR_J.JIZEN_SINSA_HANTEI_KB}' AS {NameOf(_D003_NCR_J.JIZEN_SINSA_HANTEI_KB)}")
        sbSQL.Append($" ,{_D003_NCR_J.JIZEN_SINSA_SYAIN_ID} AS {NameOf(_D003_NCR_J.JIZEN_SINSA_SYAIN_ID)}")

        sbSQL.Append($" ,'{_D003_NCR_J.JIZEN_SINSA_YMD}' AS {NameOf(_D003_NCR_J.JIZEN_SINSA_YMD)}")
        sbSQL.Append($" ,{_D003_NCR_J.SAISIN_KAKUNIN_SYAIN_ID} AS {NameOf(_D003_NCR_J.SAISIN_KAKUNIN_SYAIN_ID)}")
        sbSQL.Append($" ,'{_D003_NCR_J.SAISIN_KAKUNIN_YMD}' AS {NameOf(_D003_NCR_J.SAISIN_KAKUNIN_YMD)}")
        sbSQL.Append($" ,'{_D003_NCR_J.SAISIN_IINKAI_HANTEI_KB}' AS {NameOf(_D003_NCR_J.SAISIN_IINKAI_HANTEI_KB)}")
        sbSQL.Append($" ,{_D003_NCR_J.SAISIN_GIJYUTU_SYAIN_ID} AS {NameOf(_D003_NCR_J.SAISIN_GIJYUTU_SYAIN_ID)}")
        sbSQL.Append($" ,'{_D003_NCR_J.SAISIN_GIJYUTU_YMD}' AS {NameOf(_D003_NCR_J.SAISIN_GIJYUTU_YMD)}")
        sbSQL.Append($" ,{_D003_NCR_J.SAISIN_HINSYO_SYAIN_ID} AS {NameOf(_D003_NCR_J.SAISIN_HINSYO_SYAIN_ID)}")
        sbSQL.Append($" ,'{_D003_NCR_J.SAISIN_HINSYO_YMD}' AS {NameOf(_D003_NCR_J.SAISIN_HINSYO_YMD)}")
        sbSQL.Append($" ,'{_D003_NCR_J.SAISIN_IINKAI_SIRYO_NO.ConvertSqlEscape}' AS {NameOf(_D003_NCR_J.SAISIN_IINKAI_SIRYO_NO)}")
        sbSQL.Append($" ,'{_D003_NCR_J.ITAG_NO.ConvertSqlEscape}' AS {NameOf(_D003_NCR_J.ITAG_NO)}")
        sbSQL.Append($" ,{_D003_NCR_J.KOKYAKU_SAISIN_TANTO_ID} AS {NameOf(_D003_NCR_J.KOKYAKU_SAISIN_TANTO_ID)}")
        sbSQL.Append($" ,'{_D003_NCR_J.KOKYAKU_SAISIN_YMD}' AS {NameOf(_D003_NCR_J.KOKYAKU_SAISIN_YMD)}")
        sbSQL.Append($" ,'{_D003_NCR_J.KOKYAKU_HANTEI_SIJI_KB}' AS {NameOf(_D003_NCR_J.KOKYAKU_HANTEI_SIJI_KB)}")
        sbSQL.Append($" ,'{_D003_NCR_J.KOKYAKU_HANTEI_SIJI_YMD}' AS {NameOf(_D003_NCR_J.KOKYAKU_HANTEI_SIJI_YMD)}")
        sbSQL.Append($" ,'{_D003_NCR_J.KOKYAKU_SAISYU_HANTEI_KB}' AS {NameOf(_D003_NCR_J.KOKYAKU_SAISYU_HANTEI_KB)}")
        sbSQL.Append($" ,'{_D003_NCR_J.KOKYAKU_SAISYU_HANTEI_YMD}' AS {NameOf(_D003_NCR_J.KOKYAKU_SAISYU_HANTEI_YMD)}")
        sbSQL.Append($" ,'{_D003_NCR_J._SAIKAKO_SIJI_FG}' AS {NameOf(_D003_NCR_J.SAIKAKO_SIJI_FG)}")
        sbSQL.Append($" ,'{_D003_NCR_J.HAIKYAKU_YMD}' AS {NameOf(_D003_NCR_J.HAIKYAKU_YMD)}")
        sbSQL.Append($" ,'{_D003_NCR_J.HAIKYAKU_KB}' AS {NameOf(_D003_NCR_J.HAIKYAKU_KB)}")
        sbSQL.Append($" ,'{_D003_NCR_J.HAIKYAKU_HOUHOU.ConvertSqlEscape}' AS {NameOf(_D003_NCR_J.HAIKYAKU_HOUHOU)}")
        sbSQL.Append($" ,{_D003_NCR_J.HAIKYAKU_TANTO_ID} AS {NameOf(_D003_NCR_J.HAIKYAKU_TANTO_ID)}")
        sbSQL.Append($" ,'{_D003_NCR_J.SAIKAKO_SIJI_NO.ConvertSqlEscape}' AS {NameOf(_D003_NCR_J.SAIKAKO_SIJI_NO)}")
        sbSQL.Append($" ,'{_D003_NCR_J.SAIKAKO_SAGYO_KAN_YMD}' AS {NameOf(_D003_NCR_J.SAIKAKO_SAGYO_KAN_YMD)}")
        sbSQL.Append($" ,'{_D003_NCR_J.SAIKAKO_KENSA_YMD}' AS {NameOf(_D003_NCR_J.SAIKAKO_KENSA_YMD)}")
        sbSQL.Append($" ,'{_D003_NCR_J.KENSA_KEKKA_KB}' AS {NameOf(_D003_NCR_J.KENSA_KEKKA_KB)}")
        sbSQL.Append($" ,{_D003_NCR_J.SEIGI_TANTO_ID} AS {NameOf(_D003_NCR_J.SEIGI_TANTO_ID)}")
        sbSQL.Append($" ,{_D003_NCR_J.SEIZO_TANTO_ID} AS {NameOf(_D003_NCR_J.SEIZO_TANTO_ID)}")
        sbSQL.Append($" ,{_D003_NCR_J.KENSA_TANTO_ID} AS {NameOf(_D003_NCR_J.KENSA_TANTO_ID)}")
        sbSQL.Append($" ,'{_D003_NCR_J.HENKYAKU_YMD}' AS {NameOf(_D003_NCR_J.HENKYAKU_YMD)}")
        sbSQL.Append($" ,'{_D003_NCR_J.HENKYAKU_SAKI.ConvertSqlEscape}' AS {NameOf(_D003_NCR_J.HENKYAKU_SAKI)}")
        sbSQL.Append($" ,{_D003_NCR_J.HENKYAKU_TANTO_ID} AS {NameOf(_D003_NCR_J.HENKYAKU_TANTO_ID)}")
        sbSQL.Append($" ,'{_D003_NCR_J.HENKYAKU_BIKO.ConvertSqlEscape}' AS {NameOf(_D003_NCR_J.HENKYAKU_BIKO)}")
        sbSQL.Append($" ,{_D003_NCR_J.TENYO_KISYU_ID} AS {NameOf(_D003_NCR_J.TENYO_KISYU_ID)}")
        sbSQL.Append($" ,'{_D003_NCR_J.TENYO_BUHIN_BANGO.ConvertSqlEscape}' AS {NameOf(_D003_NCR_J.TENYO_BUHIN_BANGO)}")
        sbSQL.Append($" ,'{_D003_NCR_J.TENYO_GOKI.ConvertSqlEscape}' AS {NameOf(_D003_NCR_J.TENYO_GOKI)}")
        sbSQL.Append($" ,{_D003_NCR_J.TENYO_LOT} AS {NameOf(_D003_NCR_J.TENYO_LOT)}")
        sbSQL.Append($" ,'{_D003_NCR_J.TENYO_YMD}' AS {NameOf(_D003_NCR_J.TENYO_YMD)}")
        sbSQL.Append($" ,'{_D003_NCR_J._SYOCHI_KEKKA_A}' AS {NameOf(_D003_NCR_J.SYOCHI_KEKKA_A)}")
        sbSQL.Append($" ,'{_D003_NCR_J._SYOCHI_KEKKA_B}' AS {NameOf(_D003_NCR_J.SYOCHI_KEKKA_B)}")
        sbSQL.Append($" ,'{_D003_NCR_J._SYOCHI_KEKKA_C}' AS {NameOf(_D003_NCR_J.SYOCHI_KEKKA_C)}")
        sbSQL.Append($" ,'{_D003_NCR_J._SYOCHI_D_UMU_KB}' AS {NameOf(_D003_NCR_J.SYOCHI_D_UMU_KB)}")
        sbSQL.Append($" ,'{_D003_NCR_J._SYOCHI_D_YOHI_KB}' AS {NameOf(_D003_NCR_J.SYOCHI_D_YOHI_KB)}")
        sbSQL.Append($" ,'{_D003_NCR_J.SYOCHI_D_SYOCHI_KIROKU.ConvertSqlEscape}' AS {NameOf(_D003_NCR_J.SYOCHI_D_SYOCHI_KIROKU)}")
        sbSQL.Append($" ,'{_D003_NCR_J._SYOCHI_E_UMU_KB}' AS {NameOf(_D003_NCR_J.SYOCHI_E_UMU_KB)}")
        sbSQL.Append($" ,'{_D003_NCR_J._SYOCHI_E_YOHI_KB}' AS {NameOf(_D003_NCR_J.SYOCHI_E_YOHI_KB)}")
        sbSQL.Append($" ,'{_D003_NCR_J.SYOCHI_E_SYOCHI_KIROKU.ConvertSqlEscape}' AS {NameOf(_D003_NCR_J.SYOCHI_E_SYOCHI_KIROKU)}")

        sbSQL.Append($" ,'{_D003_NCR_J.HASSEI_YMD}' AS {NameOf(_D003_NCR_J.HASSEI_YMD)}")

        sbSQL.Append($" ,'{_D003_NCR_J.FILE_PATH.ConvertSqlEscape}' AS {NameOf(_D003_NCR_J.FILE_PATH)}")
        sbSQL.Append($" ,'{_D003_NCR_J.G_FILE_PATH1.ConvertSqlEscape}' AS {NameOf(_D003_NCR_J.G_FILE_PATH1)}")
        sbSQL.Append($" ,'{_D003_NCR_J.G_FILE_PATH2.ConvertSqlEscape}' AS {NameOf(_D003_NCR_J.G_FILE_PATH2)}")
        sbSQL.Append($" ,{_D003_NCR_J.ADD_SYAIN_ID} AS {NameOf(_D003_NCR_J.ADD_SYAIN_ID)}")
        sbSQL.Append($" ,'{_D003_NCR_J.ADD_YMDHNS}' AS {NameOf(_D003_NCR_J.ADD_YMDHNS)}")
        sbSQL.Append($" ,{pub_SYAIN_INFO.SYAIN_ID} AS {NameOf(_D003_NCR_J.UPD_SYAIN_ID)}")
        sbSQL.Append($" ,'{_D003_NCR_J.UPD_YMDHNS}' AS {NameOf(_D003_NCR_J.UPD_YMDHNS)}")
        sbSQL.Append($" ,0 AS {NameOf(_D003_NCR_J.DEL_SYAIN_ID)}")
        sbSQL.Append($" ,' ' AS {NameOf(_D003_NCR_J.DEL_YMDHNS)}")
        sbSQL.Append($" ) AS WK")
        sbSQL.Append($" ON (SrcT.{NameOf(_D003_NCR_J.HOKOKU_NO)} = WK.{NameOf(_D003_NCR_J.HOKOKU_NO)})")

        'UPDATE 排他制御 更新日時が変更されていない場合のみ
        sbSQL.Append($" WHEN MATCHED AND SrcT.{NameOf(_D003_NCR_J.UPD_YMDHNS)} = WK.{NameOf(_D003_NCR_J.UPD_YMDHNS)} THEN ")
        sbSQL.Append(" UPDATE SET")
        sbSQL.Append($"  SrcT.{NameOf(_D003_NCR_J.KISYU_ID)} = WK.{NameOf(_D003_NCR_J.KISYU_ID)}")
        sbSQL.Append($" , SrcT.{NameOf(_D003_NCR_J.CLOSE_FG)} = WK.{NameOf(_D003_NCR_J.CLOSE_FG)}")
        sbSQL.Append($" ,SrcT.{NameOf(_D003_NCR_J.SYANAI_CD)} = WK.{NameOf(_D003_NCR_J.SYANAI_CD)}")
        sbSQL.Append($" , SrcT.{NameOf(_D003_NCR_J.BUHIN_BANGO)} = WK.{NameOf(_D003_NCR_J.BUHIN_BANGO)}")
        sbSQL.Append($" ,SrcT.{NameOf(_D003_NCR_J.BUHIN_NAME)} = WK.{NameOf(_D003_NCR_J.BUHIN_NAME)}")
        sbSQL.Append($" ,SrcT.{NameOf(_D003_NCR_J.GOKI)} = WK.{NameOf(_D003_NCR_J.GOKI)}")
        sbSQL.Append($" ,SrcT.{NameOf(_D003_NCR_J.SURYO)} = WK.{NameOf(_D003_NCR_J.SURYO)}")
        sbSQL.Append($" ,SrcT.{NameOf(_D003_NCR_J.SAIHATU)} = WK.{NameOf(_D003_NCR_J.SAIHATU)}")
        sbSQL.Append($" ,SrcT.{NameOf(_D003_NCR_J.FUTEKIGO_JYOTAI_KB)} = WK.{NameOf(_D003_NCR_J.FUTEKIGO_JYOTAI_KB)}")
        sbSQL.Append($" ,SrcT.{NameOf(_D003_NCR_J.FUTEKIGO_NAIYO)} = WK.{NameOf(_D003_NCR_J.FUTEKIGO_NAIYO)}")
        sbSQL.Append($" ,SrcT.{NameOf(_D003_NCR_J.FUTEKIGO_KB)} = WK.{NameOf(_D003_NCR_J.FUTEKIGO_KB)}")
        sbSQL.Append($" ,SrcT.{NameOf(_D003_NCR_J.FUTEKIGO_S_KB)} = WK.{NameOf(_D003_NCR_J.FUTEKIGO_S_KB)}")
        sbSQL.Append($" ,SrcT.{NameOf(_D003_NCR_J.ZUMEN_KIKAKU)} = WK.{NameOf(_D003_NCR_J.ZUMEN_KIKAKU)}")
        sbSQL.Append($" ,SrcT.{NameOf(_D003_NCR_J.YOKYU_NAIYO)} = WK.{NameOf(_D003_NCR_J.YOKYU_NAIYO)}")
        sbSQL.Append($" ,SrcT.{NameOf(_D003_NCR_J.KANSATU_KEKKA)} = WK.{NameOf(_D003_NCR_J.KANSATU_KEKKA)}")

        sbSQL.Append($" ,SrcT.{NameOf(_D003_NCR_J.ZESEI_SYOCHI_YOHI_KB)} = WK.{NameOf(_D003_NCR_J.ZESEI_SYOCHI_YOHI_KB)}")
        sbSQL.Append($" ,SrcT.{NameOf(_D003_NCR_J.ZESEI_NASI_RIYU)} = WK.{NameOf(_D003_NCR_J.ZESEI_NASI_RIYU)}")
        sbSQL.Append($" ,SrcT.{NameOf(_D003_NCR_J.HASSEI_KOTEI_GL_SYAIN_ID)} = WK.{NameOf(_D003_NCR_J.HASSEI_KOTEI_GL_SYAIN_ID)}")
        sbSQL.Append($" ,SrcT.{NameOf(_D003_NCR_J.JIZEN_SINSA_HANTEI_KB)} = WK.{NameOf(_D003_NCR_J.JIZEN_SINSA_HANTEI_KB)}")
        sbSQL.Append($" ,SrcT.{NameOf(_D003_NCR_J.JIZEN_SINSA_SYAIN_ID)} = WK.{NameOf(_D003_NCR_J.JIZEN_SINSA_SYAIN_ID)}")
        sbSQL.Append($" ,SrcT.{NameOf(_D003_NCR_J.JIZEN_SINSA_YMD)} = WK.{NameOf(_D003_NCR_J.JIZEN_SINSA_YMD)}")
        sbSQL.Append($" ,SrcT.{NameOf(_D003_NCR_J.SAISIN_KAKUNIN_SYAIN_ID)} = WK.{NameOf(_D003_NCR_J.SAISIN_KAKUNIN_SYAIN_ID)}")
        sbSQL.Append($" ,SrcT.{NameOf(_D003_NCR_J.SAISIN_KAKUNIN_YMD)} = WK.{NameOf(_D003_NCR_J.SAISIN_KAKUNIN_YMD)}")
        sbSQL.Append($" ,SrcT.{NameOf(_D003_NCR_J.SAISIN_IINKAI_HANTEI_KB)} = WK.{NameOf(_D003_NCR_J.SAISIN_IINKAI_HANTEI_KB)}")
        sbSQL.Append($" ,SrcT.{NameOf(_D003_NCR_J.SAISIN_GIJYUTU_SYAIN_ID)} = WK.{NameOf(_D003_NCR_J.SAISIN_GIJYUTU_SYAIN_ID)}")
        sbSQL.Append($" ,SrcT.{NameOf(_D003_NCR_J.SAISIN_GIJYUTU_YMD)} = WK.{NameOf(_D003_NCR_J.SAISIN_GIJYUTU_YMD)}")
        sbSQL.Append($" ,SrcT.{NameOf(_D003_NCR_J.SAISIN_HINSYO_SYAIN_ID)} = WK.{NameOf(_D003_NCR_J.SAISIN_HINSYO_SYAIN_ID)}")
        sbSQL.Append($" ,SrcT.{NameOf(_D003_NCR_J.SAISIN_HINSYO_YMD)} = WK.{NameOf(_D003_NCR_J.SAISIN_HINSYO_YMD)}")
        sbSQL.Append($" ,SrcT.{NameOf(_D003_NCR_J.SAISIN_IINKAI_SIRYO_NO)} = WK.{NameOf(_D003_NCR_J.SAISIN_IINKAI_SIRYO_NO)}")
        sbSQL.Append($" ,SrcT.{NameOf(_D003_NCR_J.ITAG_NO)} = WK.{NameOf(_D003_NCR_J.ITAG_NO)}")
        sbSQL.Append($" ,SrcT.{NameOf(_D003_NCR_J.KOKYAKU_SAISIN_TANTO_ID)} = WK.{NameOf(_D003_NCR_J.KOKYAKU_SAISIN_TANTO_ID)}")
        sbSQL.Append($" ,SrcT.{NameOf(_D003_NCR_J.KOKYAKU_SAISIN_YMD)} = WK.{NameOf(_D003_NCR_J.KOKYAKU_SAISIN_YMD)}")
        sbSQL.Append($" ,SrcT.{NameOf(_D003_NCR_J.KOKYAKU_HANTEI_SIJI_KB)} = WK.{NameOf(_D003_NCR_J.KOKYAKU_HANTEI_SIJI_KB)}")
        sbSQL.Append($" ,SrcT.{NameOf(_D003_NCR_J.KOKYAKU_HANTEI_SIJI_YMD)} = WK.{NameOf(_D003_NCR_J.KOKYAKU_HANTEI_SIJI_YMD)}")
        sbSQL.Append($" ,SrcT.{NameOf(_D003_NCR_J.KOKYAKU_SAISYU_HANTEI_KB)} = WK.{NameOf(_D003_NCR_J.KOKYAKU_SAISYU_HANTEI_KB)}")
        sbSQL.Append($" ,SrcT.{NameOf(_D003_NCR_J.KOKYAKU_SAISYU_HANTEI_YMD)} = WK.{NameOf(_D003_NCR_J.KOKYAKU_SAISYU_HANTEI_YMD)}")
        sbSQL.Append($" ,SrcT.{NameOf(_D003_NCR_J.SAIKAKO_SIJI_FG)} = WK.{NameOf(_D003_NCR_J.SAIKAKO_SIJI_FG)}")
        sbSQL.Append($" ,SrcT.{NameOf(_D003_NCR_J.HAIKYAKU_YMD)} = WK.{NameOf(_D003_NCR_J.HAIKYAKU_YMD)}")
        sbSQL.Append($" ,SrcT.{NameOf(_D003_NCR_J.HAIKYAKU_KB)} = WK.{NameOf(_D003_NCR_J.HAIKYAKU_KB)}")
        sbSQL.Append($" ,SrcT.{NameOf(_D003_NCR_J.HAIKYAKU_HOUHOU)} = WK.{NameOf(_D003_NCR_J.HAIKYAKU_HOUHOU)}")
        sbSQL.Append($" ,SrcT.{NameOf(_D003_NCR_J.HAIKYAKU_TANTO_ID)} = WK.{NameOf(_D003_NCR_J.HAIKYAKU_TANTO_ID)}")
        sbSQL.Append($" ,SrcT.{NameOf(_D003_NCR_J.SAIKAKO_SIJI_NO)} = WK.{NameOf(_D003_NCR_J.SAIKAKO_SIJI_NO)}")
        sbSQL.Append($" ,SrcT.{NameOf(_D003_NCR_J.SAIKAKO_SAGYO_KAN_YMD)} = WK.{NameOf(_D003_NCR_J.SAIKAKO_SAGYO_KAN_YMD)}")
        sbSQL.Append($" ,SrcT.{NameOf(_D003_NCR_J.SAIKAKO_KENSA_YMD)} = WK.{NameOf(_D003_NCR_J.SAIKAKO_KENSA_YMD)}")
        sbSQL.Append($" ,SrcT.{NameOf(_D003_NCR_J.KENSA_KEKKA_KB)} = WK.{NameOf(_D003_NCR_J.KENSA_KEKKA_KB)}")
        sbSQL.Append($" ,SrcT.{NameOf(_D003_NCR_J.SEIGI_TANTO_ID)} = WK.{NameOf(_D003_NCR_J.SEIGI_TANTO_ID)}")
        sbSQL.Append($" ,SrcT.{NameOf(_D003_NCR_J.SEIZO_TANTO_ID)} = WK.{NameOf(_D003_NCR_J.SEIZO_TANTO_ID)}")
        sbSQL.Append($" ,SrcT.{NameOf(_D003_NCR_J.KENSA_TANTO_ID)} = WK.{NameOf(_D003_NCR_J.KENSA_TANTO_ID)}")
        sbSQL.Append($" ,SrcT.{NameOf(_D003_NCR_J.HENKYAKU_YMD)} = WK.{NameOf(_D003_NCR_J.HENKYAKU_YMD)}")
        sbSQL.Append($" ,SrcT.{NameOf(_D003_NCR_J.HENKYAKU_SAKI)} = WK.{NameOf(_D003_NCR_J.HENKYAKU_SAKI)}")
        sbSQL.Append($" ,SrcT.{NameOf(_D003_NCR_J.HENKYAKU_TANTO_ID)} = WK.{NameOf(_D003_NCR_J.HENKYAKU_TANTO_ID)}")
        sbSQL.Append($" ,SrcT.{NameOf(_D003_NCR_J.HENKYAKU_BIKO)} = WK.{NameOf(_D003_NCR_J.HENKYAKU_BIKO)}")
        sbSQL.Append($" ,SrcT.{NameOf(_D003_NCR_J.TENYO_KISYU_ID)} = WK.{NameOf(_D003_NCR_J.TENYO_KISYU_ID)}")
        sbSQL.Append($" ,SrcT.{NameOf(_D003_NCR_J.TENYO_BUHIN_BANGO)} = WK.{NameOf(_D003_NCR_J.TENYO_BUHIN_BANGO)}")
        sbSQL.Append($" ,SrcT.{NameOf(_D003_NCR_J.TENYO_GOKI)} = WK.{NameOf(_D003_NCR_J.TENYO_GOKI)}")
        sbSQL.Append($" ,SrcT.{NameOf(_D003_NCR_J.TENYO_LOT)} = WK.{NameOf(_D003_NCR_J.TENYO_LOT)}")
        sbSQL.Append($" ,SrcT.{NameOf(_D003_NCR_J.TENYO_YMD)} = WK.{NameOf(_D003_NCR_J.TENYO_YMD)}")
        sbSQL.Append($" ,SrcT.{NameOf(_D003_NCR_J.SYOCHI_KEKKA_A)} = WK.{NameOf(_D003_NCR_J.SYOCHI_KEKKA_A)}")
        sbSQL.Append($" ,SrcT.{NameOf(_D003_NCR_J.SYOCHI_KEKKA_B)} = WK.{NameOf(_D003_NCR_J.SYOCHI_KEKKA_B)}")
        sbSQL.Append($" ,SrcT.{NameOf(_D003_NCR_J.SYOCHI_KEKKA_C)} = WK.{NameOf(_D003_NCR_J.SYOCHI_KEKKA_C)}")
        sbSQL.Append($" ,SrcT.{NameOf(_D003_NCR_J.SYOCHI_D_UMU_KB)} = WK.{NameOf(_D003_NCR_J.SYOCHI_D_UMU_KB)}")
        sbSQL.Append($" ,SrcT.{NameOf(_D003_NCR_J.SYOCHI_D_YOHI_KB)} = WK.{NameOf(_D003_NCR_J.SYOCHI_D_YOHI_KB)}")
        sbSQL.Append($" ,SrcT.{NameOf(_D003_NCR_J.SYOCHI_D_SYOCHI_KIROKU)} = WK.{NameOf(_D003_NCR_J.SYOCHI_D_SYOCHI_KIROKU)}")
        sbSQL.Append($" ,SrcT.{NameOf(_D003_NCR_J.SYOCHI_E_UMU_KB)} = WK.{NameOf(_D003_NCR_J.SYOCHI_E_UMU_KB)}")
        sbSQL.Append($" ,SrcT.{NameOf(_D003_NCR_J.SYOCHI_E_YOHI_KB)} = WK.{NameOf(_D003_NCR_J.SYOCHI_E_YOHI_KB)}")
        sbSQL.Append($" ,SrcT.{NameOf(_D003_NCR_J.SYOCHI_E_SYOCHI_KIROKU)} = WK.{NameOf(_D003_NCR_J.SYOCHI_E_SYOCHI_KIROKU)}")
        sbSQL.Append($" ,SrcT.{NameOf(_D003_NCR_J.HASSEI_YMD)} = WK.{NameOf(_D003_NCR_J.HASSEI_YMD)}")

        sbSQL.Append($" ,SrcT.{NameOf(_D003_NCR_J.FILE_PATH)} = WK.{NameOf(_D003_NCR_J.FILE_PATH)}")
        sbSQL.Append($" ,SrcT.{NameOf(_D003_NCR_J.G_FILE_PATH1)} = WK.{NameOf(_D003_NCR_J.G_FILE_PATH1)}")
        sbSQL.Append($" ,SrcT.{NameOf(_D003_NCR_J.G_FILE_PATH2)} = WK.{NameOf(_D003_NCR_J.G_FILE_PATH2)}")
        sbSQL.Append($" ,SrcT.{NameOf(_D003_NCR_J.UPD_SYAIN_ID)} = WK.{NameOf(_D003_NCR_J.UPD_SYAIN_ID)}")
        sbSQL.Append($" ,SrcT.{NameOf(_D003_NCR_J.UPD_YMDHNS)} = '{strSysDate}'")

        'INSERT
        sbSQL.Append(" WHEN NOT MATCHED THEN ")
        sbSQL.Append(" INSERT(")
        sbSQL.Append("  " & NameOf(_D003_NCR_J.HOKOKU_NO))
        sbSQL.Append(" ," & NameOf(_D003_NCR_J.BUMON_KB))
        sbSQL.Append(" ," & NameOf(_D003_NCR_J.CLOSE_FG))
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
        '---defaultValue
        sbSQL.Append(" ," & NameOf(_D003_NCR_J.ZESEI_SYOCHI_YOHI_KB))
        sbSQL.Append(" ," & NameOf(_D003_NCR_J.ZESEI_NASI_RIYU))
        sbSQL.Append(" ," & NameOf(_D003_NCR_J.HASSEI_KOTEI_GL_SYAIN_ID))
        sbSQL.Append(" ," & NameOf(_D003_NCR_J.JIZEN_SINSA_HANTEI_KB))
        sbSQL.Append(" ," & NameOf(_D003_NCR_J.JIZEN_SINSA_SYAIN_ID))
        sbSQL.Append(" ," & NameOf(_D003_NCR_J.JIZEN_SINSA_YMD))
        sbSQL.Append(" ," & NameOf(_D003_NCR_J.SAISIN_KAKUNIN_SYAIN_ID))
        sbSQL.Append(" ," & NameOf(_D003_NCR_J.SAISIN_KAKUNIN_YMD))
        sbSQL.Append(" ," & NameOf(_D003_NCR_J.SAISIN_IINKAI_HANTEI_KB))
        sbSQL.Append(" ," & NameOf(_D003_NCR_J.SAISIN_GIJYUTU_SYAIN_ID))
        sbSQL.Append(" ," & NameOf(_D003_NCR_J.SAISIN_GIJYUTU_YMD))
        sbSQL.Append(" ," & NameOf(_D003_NCR_J.SAISIN_HINSYO_SYAIN_ID))
        sbSQL.Append(" ," & NameOf(_D003_NCR_J.SAISIN_HINSYO_YMD))
        sbSQL.Append(" ," & NameOf(_D003_NCR_J.SAISIN_IINKAI_SIRYO_NO))
        sbSQL.Append(" ," & NameOf(_D003_NCR_J.ITAG_NO))
        sbSQL.Append(" ," & NameOf(_D003_NCR_J.KOKYAKU_SAISIN_TANTO_ID))
        sbSQL.Append(" ," & NameOf(_D003_NCR_J.KOKYAKU_SAISIN_YMD))
        sbSQL.Append(" ," & NameOf(_D003_NCR_J.KOKYAKU_HANTEI_SIJI_KB))
        sbSQL.Append(" ," & NameOf(_D003_NCR_J.KOKYAKU_HANTEI_SIJI_YMD))
        sbSQL.Append(" ," & NameOf(_D003_NCR_J.KOKYAKU_SAISYU_HANTEI_KB))
        sbSQL.Append(" ," & NameOf(_D003_NCR_J.KOKYAKU_SAISYU_HANTEI_YMD))
        sbSQL.Append(" ," & NameOf(_D003_NCR_J.SAIKAKO_SIJI_FG))
        sbSQL.Append(" ," & NameOf(_D003_NCR_J.HAIKYAKU_YMD))
        sbSQL.Append(" ," & NameOf(_D003_NCR_J.HAIKYAKU_KB))
        sbSQL.Append(" ," & NameOf(_D003_NCR_J.HAIKYAKU_HOUHOU))
        sbSQL.Append(" ," & NameOf(_D003_NCR_J.HAIKYAKU_TANTO_ID))
        sbSQL.Append(" ," & NameOf(_D003_NCR_J.SAIKAKO_SIJI_NO))
        sbSQL.Append(" ," & NameOf(_D003_NCR_J.SAIKAKO_SAGYO_KAN_YMD))
        sbSQL.Append(" ," & NameOf(_D003_NCR_J.SAIKAKO_KENSA_YMD))
        sbSQL.Append(" ," & NameOf(_D003_NCR_J.KENSA_KEKKA_KB))
        sbSQL.Append(" ," & NameOf(_D003_NCR_J.SEIGI_TANTO_ID))
        sbSQL.Append(" ," & NameOf(_D003_NCR_J.SEIZO_TANTO_ID))
        sbSQL.Append(" ," & NameOf(_D003_NCR_J.KENSA_TANTO_ID))
        sbSQL.Append(" ," & NameOf(_D003_NCR_J.HENKYAKU_YMD))
        sbSQL.Append(" ," & NameOf(_D003_NCR_J.HENKYAKU_SAKI))
        sbSQL.Append(" ," & NameOf(_D003_NCR_J.HENKYAKU_TANTO_ID))
        sbSQL.Append(" ," & NameOf(_D003_NCR_J.HENKYAKU_BIKO))
        sbSQL.Append(" ," & NameOf(_D003_NCR_J.TENYO_KISYU_ID))
        sbSQL.Append(" ," & NameOf(_D003_NCR_J.TENYO_BUHIN_BANGO))
        sbSQL.Append(" ," & NameOf(_D003_NCR_J.TENYO_GOKI))
        sbSQL.Append(" ," & NameOf(_D003_NCR_J.TENYO_LOT))
        sbSQL.Append(" ," & NameOf(_D003_NCR_J.TENYO_YMD))
        sbSQL.Append(" ," & NameOf(_D003_NCR_J.SYOCHI_KEKKA_A))
        sbSQL.Append(" ," & NameOf(_D003_NCR_J.SYOCHI_KEKKA_B))
        sbSQL.Append(" ," & NameOf(_D003_NCR_J.SYOCHI_KEKKA_C))
        sbSQL.Append(" ," & NameOf(_D003_NCR_J.SYOCHI_D_UMU_KB))
        sbSQL.Append(" ," & NameOf(_D003_NCR_J.SYOCHI_D_YOHI_KB))
        sbSQL.Append(" ," & NameOf(_D003_NCR_J.SYOCHI_D_SYOCHI_KIROKU))
        sbSQL.Append(" ," & NameOf(_D003_NCR_J.SYOCHI_E_UMU_KB))
        sbSQL.Append(" ," & NameOf(_D003_NCR_J.SYOCHI_E_YOHI_KB))
        sbSQL.Append(" ," & NameOf(_D003_NCR_J.SYOCHI_E_SYOCHI_KIROKU))
        sbSQL.Append(" ," & NameOf(_D003_NCR_J.HASSEI_YMD))
        '---
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
        sbSQL.Append(" ,WK." & NameOf(_D003_NCR_J.CLOSE_FG))
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
        '---defaultValue
        sbSQL.Append(" ,'0'") 'sbSQL.Append(" ," & NameOf(_D003_NCR_J.ZESEI_SYOCHI_YOHI_KB))
        sbSQL.Append(" ,''") 'sbSQL.Append(" ," & NameOf(_D003_NCR_J.ZESEI_NASI_RIYU))
        sbSQL.Append(" ,0") 'sbSQL.Append(" ," & NameOf(_D003_NCR_J.HASSEI_KOTEI_SYAIN_ID))
        sbSQL.Append(" ,' '") 'sbSQL.Append(" ," & NameOf(_D003_NCR_J.JIZEN_SINSA_HANTEI_KB))
        sbSQL.Append(" ,0") 'sbSQL.Append(" ," & NameOf(_D003_NCR_J.JIZEN_SINSA_SYAIN_ID))
        sbSQL.Append(" ,''") 'sbSQL.Append(" ," & NameOf(_D003_NCR_J.JIZEN_SINSA_YMD))
        sbSQL.Append(" ,0") 'sbSQL.Append(" ," & NameOf(_D003_NCR_J.SAISIN_KAKUNIN_SYAIN_ID))
        sbSQL.Append(" ,''") 'sbSQL.Append(" ," & NameOf(_D003_NCR_J.SAISIN_KAKUNIN_YMD))
        sbSQL.Append(" ,''") 'sbSQL.Append(" ," & NameOf(_D003_NCR_J.SAISIN_IINKAI_HANTEI_KB))
        sbSQL.Append(" ,0") 'sbSQL.Append(" ," & NameOf(_D003_NCR_J.SAISIN_GIJYUTU_SYAIN_ID))
        sbSQL.Append(" ,''") 'sbSQL.Append(" ," & NameOf(_D003_NCR_J.SAISIN_GIJYUTU_YMD))
        sbSQL.Append(" ,0") 'sbSQL.Append(" ," & NameOf(_D003_NCR_J.SAISIN_HINSYO_SYAIN_ID))
        sbSQL.Append(" ,''") 'sbSQL.Append(" ," & NameOf(_D003_NCR_J.SAISIN_HINSYO_YMD))
        sbSQL.Append(" ,''") 'sbSQL.Append(" ," & NameOf(_D003_NCR_J.SAISIN_IINKAI_SIRYO_NO))
        sbSQL.Append(" ,''") 'sbSQL.Append(" ," & NameOf(_D003_NCR_J.ITAG_NO))
        sbSQL.Append(" ,0") 'sbSQL.Append(" ," & NameOf(_D003_NCR_J.KOKYAKU_SAISIN_TANTO_ID))
        sbSQL.Append(" ,''") 'sbSQL.Append(" ," & NameOf(_D003_NCR_J.KOKYAKU_SAISIN_YMD))
        sbSQL.Append(" ,''") 'sbSQL.Append(" ," & NameOf(_D003_NCR_J.KOKYAKU_HANTEI_SIJI_KB))
        sbSQL.Append(" ,''") 'sbSQL.Append(" ," & NameOf(_D003_NCR_J.KOKYAKU_HANTEI_SIJI_YMD))
        sbSQL.Append(" ,''") 'sbSQL.Append(" ," & NameOf(_D003_NCR_J.KOKYAKU_SAISYU_HANTEI_KB))
        sbSQL.Append(" ,''") 'sbSQL.Append(" ," & NameOf(_D003_NCR_J.KOKYAKU_SAISYU_HANTEI_YMD))
        sbSQL.Append(" ,'0'") 'sbSQL.Append(" ," & NameOf(_D003_NCR_J.SAIKAKO_SIJI_FG))
        sbSQL.Append(" ,''") 'sbSQL.Append(" ," & NameOf(_D003_NCR_J.HAIKYAKU_YMD))
        sbSQL.Append(" ,''") 'sbSQL.Append(" ," & NameOf(_D003_NCR_J.HAIKYAKU_KB))
        sbSQL.Append(" ,''") 'sbSQL.Append(" ," & NameOf(_D003_NCR_J.HAIKYAKU_HOUHOU))
        sbSQL.Append(" ,0") 'sbSQL.Append(" ," & NameOf(_D003_NCR_J.HAIKYAKU_TANTO_ID))
        sbSQL.Append(" ,''") 'sbSQL.Append(" ," & NameOf(_D003_NCR_J.SAIKAKO_SIJI_NO))
        sbSQL.Append(" ,''") 'sbSQL.Append(" ," & NameOf(_D003_NCR_J.SAIKAKO_SAGYO_KAN_YMD))
        sbSQL.Append(" ,''") 'sbSQL.Append(" ," & NameOf(_D003_NCR_J.SAIKAKO_KENSA_YMD))
        sbSQL.Append(" ,''") 'sbSQL.Append(" ," & NameOf(_D003_NCR_J.KENSA_KEKKA_KB))
        sbSQL.Append(" ,0") 'sbSQL.Append(" ," & NameOf(_D003_NCR_J.SEIGI_TANTO_ID))
        sbSQL.Append(" ,0") 'sbSQL.Append(" ," & NameOf(_D003_NCR_J.SEIZO_TANTO_ID))
        sbSQL.Append(" ,0") 'sbSQL.Append(" ," & NameOf(_D003_NCR_J.KENSA_TANTO_ID))
        sbSQL.Append(" ,''") 'sbSQL.Append(" ," & NameOf(_D003_NCR_J.HENKYAKU_YMD))
        sbSQL.Append(" ,''") 'sbSQL.Append(" ," & NameOf(_D003_NCR_J.HENKYAKU_SAKI))
        sbSQL.Append(" ,0") 'sbSQL.Append(" ," & NameOf(_D003_NCR_J.HENKYAKU_TANTO_ID))
        sbSQL.Append(" ,''") 'sbSQL.Append(" ," & NameOf(_D003_NCR_J.HENKYAKU_BIKO))
        sbSQL.Append(" ,0") 'sbSQL.Append(" ," & NameOf(_D003_NCR_J.TENYO_KISYU_ID))
        sbSQL.Append(" ,''") 'sbSQL.Append(" ," & NameOf(_D003_NCR_J.TENYO_BUHIN_BANGO))
        sbSQL.Append(" ,''") 'sbSQL.Append(" ," & NameOf(_D003_NCR_J.TENYO_GOKI))
        sbSQL.Append(" ,0") 'sbSQL.Append(" ," & NameOf(_D003_NCR_J.TENYO_LOT))
        sbSQL.Append(" ,''") 'sbSQL.Append(" ," & NameOf(_D003_NCR_J.TENYO_YMD))
        sbSQL.Append(" ,'0'") 'sbSQL.Append(" ," & NameOf(_D003_NCR_J.SYOCHI_KEKKA_A))
        sbSQL.Append(" ,'0'") 'sbSQL.Append(" ," & NameOf(_D003_NCR_J.SYOCHI_KEKKA_B))
        sbSQL.Append(" ,'0'") 'sbSQL.Append(" ," & NameOf(_D003_NCR_J.SYOCHI_KEKKA_C))
        sbSQL.Append(" ,'0'") 'sbSQL.Append(" ," & NameOf(_D003_NCR_J.SYOCHI_D_UMU_KB))
        sbSQL.Append(" ,'0'") 'sbSQL.Append(" ," & NameOf(_D003_NCR_J.SYOCHI_D_YOHI_KB))
        sbSQL.Append(" ,''") 'sbSQL.Append(" ," & NameOf(_D003_NCR_J.SYOCHI_D_SYOCHI_KIROKU))
        sbSQL.Append(" ,'0'") 'sbSQL.Append(" ," & NameOf(_D003_NCR_J.SYOCHI_E_UMU_KB))
        sbSQL.Append(" ,'0'") 'sbSQL.Append(" ," & NameOf(_D003_NCR_J.SYOCHI_E_YOHI_KB))
        sbSQL.Append(" ,''") 'sbSQL.Append(" ," & NameOf(_D003_NCR_J.SYOCHI_E_SYOCHI_KIROKU))
        sbSQL.Append(" ,WK." & NameOf(_D003_NCR_J.HASSEI_YMD))
        '---
        sbSQL.Append(" ,WK." & NameOf(_D003_NCR_J.FILE_PATH))
        sbSQL.Append(" ,WK." & NameOf(_D003_NCR_J.G_FILE_PATH1))
        sbSQL.Append(" ,WK." & NameOf(_D003_NCR_J.G_FILE_PATH2))
        sbSQL.Append(" ,WK." & NameOf(_D003_NCR_J.ADD_SYAIN_ID))
        sbSQL.Append(" ,dbo.GetSysDateString()") 'ADD_YMDHNS
        sbSQL.Append(" ,WK." & NameOf(_D003_NCR_J.UPD_SYAIN_ID))
        sbSQL.Append(" ,WK." & NameOf(_D003_NCR_J.UPD_YMDHNS))
        sbSQL.Append(" ,WK." & NameOf(_D003_NCR_J.DEL_SYAIN_ID))
        sbSQL.Append(" ,WK." & NameOf(_D003_NCR_J.DEL_YMDHNS))
        sbSQL.Append(" )")
        sbSQL.Append("OUTPUT $action AS RESULT") 'INSERT OR UPDATE をncarchar(10)で取得する場合
        sbSQL.Append(";")
        strRET = DB.ExecuteScalar(sbSQL.ToString, conblnNonMsg, sqlEx)
        Select Case strRET
            Case "INSERT"

            Case "UPDATE"

            Case Else
                If sqlEx.Source IsNot Nothing Then
                    '-----エラーログ出力
                    Dim strErrMsg As String = My.Resources.ErrLogSqlExecutionFailure & sbSQL.ToString & "|" & sqlEx.Message
                    WL.WriteLogDat(strErrMsg)
                Else
                    '---排他制御
                    Dim strMsg As String
                    strMsg = "既に他の担当者によって変更されているため保存出来ません。" & vbCrLf &
                                "再度登録し直して下さい。"

                    MessageBox.Show(strMsg, "同時更新無効", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                End If
                Return False
        End Select

        Return True
    End Function

#End Region

#Region "   D004保存"

    ''' <summary>
    ''' 承認実績管理更新
    ''' </summary>
    ''' <param name="DB"></param>
    ''' <param name="enmSAVE_MODE"></param>
    ''' <returns></returns>
    Private Function FunSAVE_D004(ByRef DB As ClsDbUtility, ByVal enmSAVE_MODE As ENM_SAVE_MODE) As Boolean
        Dim sbSQL As New System.Text.StringBuilder
        Dim strRET As String
        Dim sqlEx As New Exception
        Dim strSysDate As String = DB.GetSysDateString

#Region "承認"

        '-----データモデル更新
        _D004_SYONIN_J_KANRI.SYONIN_HOKOKUSYO_ID = Context.ENM_SYONIN_HOKOKUSYO_ID._1_NCR
        _D004_SYONIN_J_KANRI.HOKOKU_NO = _D003_NCR_J.HOKOKU_NO
        _D004_SYONIN_J_KANRI.MAIL_SEND_FG = True
        _D004_SYONIN_J_KANRI.ADD_SYAIN_ID = pub_SYAIN_INFO.SYAIN_ID


        '#80 承認申請日は画面で入力
        If _D004_SYONIN_J_KANRI.SYONIN_YMDHNS.IsNullOrWhiteSpace Then
            _D004_SYONIN_J_KANRI.SYONIN_YMDHNS = strSysDate
        ElseIf _D004_SYONIN_J_KANRI.SYONIN_YMDHNS.Trim.Length = 8 Then
            'datetextboxにバインド時は時刻情報を結合
            _D004_SYONIN_J_KANRI.SYONIN_YMDHNS &= "000000"
        End If

        Select Case enmSAVE_MODE
            Case ENM_SAVE_MODE._1_保存
                _D004_SYONIN_J_KANRI.SYONIN_JUN = PrCurrentStage
                _D004_SYONIN_J_KANRI.SYONIN_HANTEI_KB = ENM_SYONIN_HANTEI_KB._0_未承認
                _D004_SYONIN_J_KANRI.SYAIN_ID = pub_SYAIN_INFO.SYAIN_ID
                '一時保存時も入力された承認申請日を保存する
                '_D004_SYONIN_J_KANRI.SYONIN_YMDHNS = ""
            Case ENM_SAVE_MODE._2_承認申請
                _D004_SYONIN_J_KANRI.SYONIN_JUN = PrCurrentStage
                _D004_SYONIN_J_KANRI.SYONIN_HANTEI_KB = ENM_SYONIN_HANTEI_KB._1_承認

            Case Else
                'Err
                Return False
        End Select

        '-----MERGE
        sbSQL.Remove(0, sbSQL.Length)
        sbSQL.Append($"MERGE INTO {NameOf(MODEL.D004_SYONIN_J_KANRI)} AS SrcT")
        sbSQL.Append($" USING (")
        sbSQL.Append($" SELECT")
        sbSQL.Append($" {_D004_SYONIN_J_KANRI.SYONIN_HOKOKUSYO_ID} AS {NameOf(_D004_SYONIN_J_KANRI.SYONIN_HOKOKUSYO_ID)}")
        sbSQL.Append($" ,'{_D004_SYONIN_J_KANRI.HOKOKU_NO}' AS {NameOf(_D004_SYONIN_J_KANRI.HOKOKU_NO)}")
        sbSQL.Append($" ,{_D004_SYONIN_J_KANRI.SYONIN_JUN} AS {NameOf(_D004_SYONIN_J_KANRI.SYONIN_JUN)}")
        sbSQL.Append($" ,'{_D004_SYONIN_J_KANRI.SYAIN_ID}' AS {NameOf(_D004_SYONIN_J_KANRI.SYAIN_ID)}")
        sbSQL.Append($" ,'{_D004_SYONIN_J_KANRI.SYONIN_YMDHNS}' AS {NameOf(_D004_SYONIN_J_KANRI.SYONIN_YMDHNS)}")
        sbSQL.Append($" ,'{_D004_SYONIN_J_KANRI.SYONIN_HANTEI_KB}' AS {NameOf(_D004_SYONIN_J_KANRI.SYONIN_HANTEI_KB)}")
        sbSQL.Append($" ,'{_D004_SYONIN_J_KANRI._SASIMODOSI_FG}' AS {NameOf(_D004_SYONIN_J_KANRI.SASIMODOSI_FG)}")
        sbSQL.Append($" ,'{_D004_SYONIN_J_KANRI.RIYU}' AS {NameOf(_D004_SYONIN_J_KANRI.RIYU)}")
        sbSQL.Append($" ,'{_D004_SYONIN_J_KANRI.COMMENT}' AS {NameOf(_D004_SYONIN_J_KANRI.COMMENT)}")
        sbSQL.Append($" ,'{_D004_SYONIN_J_KANRI._MAIL_SEND_FG}' AS {NameOf(_D004_SYONIN_J_KANRI.MAIL_SEND_FG)}")
        sbSQL.Append($" ,{_D004_SYONIN_J_KANRI.ADD_SYAIN_ID} AS {NameOf(_D004_SYONIN_J_KANRI.ADD_SYAIN_ID)}")
        sbSQL.Append($" ,'{_D004_SYONIN_J_KANRI.ADD_YMDHNS}' AS {NameOf(_D004_SYONIN_J_KANRI.ADD_YMDHNS)}")
        sbSQL.Append($" ,{pub_SYAIN_INFO.SYAIN_ID} AS {NameOf(_D004_SYONIN_J_KANRI.UPD_SYAIN_ID)}")
        sbSQL.Append($" ,'{_D004_SYONIN_J_KANRI.UPD_YMDHNS}' AS {NameOf(_D004_SYONIN_J_KANRI.UPD_YMDHNS)}")
        sbSQL.Append($" ) AS WK")
        sbSQL.Append($" ON (SrcT.{NameOf(_D004_SYONIN_J_KANRI.SYONIN_HOKOKUSYO_ID)} = WK.{NameOf(_D004_SYONIN_J_KANRI.SYONIN_HOKOKUSYO_ID)}")
        sbSQL.Append($" AND SrcT.{NameOf(_D004_SYONIN_J_KANRI.HOKOKU_NO)} = WK.{NameOf(_D004_SYONIN_J_KANRI.HOKOKU_NO)}")
        sbSQL.Append($" AND SrcT.{NameOf(_D004_SYONIN_J_KANRI.SYONIN_JUN)} = WK.{NameOf(_D004_SYONIN_J_KANRI.SYONIN_JUN)})")
        'UPDATE
        '排他制御 更新日時が変更されている場合、変更されないフィールド名のUPDATE文を実行(=実質更新しない)
        sbSQL.Append($" WHEN MATCHED AND SrcT.{NameOf(_D004_SYONIN_J_KANRI.UPD_YMDHNS)} = WK.{NameOf(_D004_SYONIN_J_KANRI.UPD_YMDHNS)} THEN ")
        sbSQL.Append($" UPDATE SET")
        sbSQL.Append($"  SrcT.{NameOf(_D004_SYONIN_J_KANRI.SYAIN_ID)} = WK.{NameOf(_D004_SYONIN_J_KANRI.SYAIN_ID)}")
        sbSQL.Append($" ,SrcT.{NameOf(_D004_SYONIN_J_KANRI.UPD_SYAIN_ID)} = WK.{NameOf(_D004_SYONIN_J_KANRI.UPD_SYAIN_ID)}")
        sbSQL.Append($" ,SrcT.{NameOf(_D004_SYONIN_J_KANRI.COMMENT)} = WK.{NameOf(_D004_SYONIN_J_KANRI.COMMENT)}")
        sbSQL.Append($" ,SrcT.{NameOf(_D004_SYONIN_J_KANRI.UPD_YMDHNS)} = dbo.GetSysDateString()")
        sbSQL.Append($" ,SrcT.{NameOf(_D004_SYONIN_J_KANRI.SASIMODOSI_FG)} = WK.{NameOf(_D004_SYONIN_J_KANRI.SASIMODOSI_FG)}")
        sbSQL.Append($" ,SrcT.{NameOf(_D004_SYONIN_J_KANRI.SYONIN_YMDHNS)} = WK.{NameOf(_D004_SYONIN_J_KANRI.SYONIN_YMDHNS)}")
        sbSQL.Append($" ,SrcT.{NameOf(_D004_SYONIN_J_KANRI.SYONIN_HANTEI_KB)} = WK.{NameOf(_D004_SYONIN_J_KANRI.SYONIN_HANTEI_KB)}")
        sbSQL.Append($" ,SrcT.{NameOf(_D004_SYONIN_J_KANRI.MAIL_SEND_FG)} = WK.{NameOf(_D004_SYONIN_J_KANRI.MAIL_SEND_FG)}")
        sbSQL.Append($" ,SrcT.{NameOf(_D004_SYONIN_J_KANRI.RIYU)} = WK.{NameOf(_D004_SYONIN_J_KANRI.RIYU)}")
        'INSERT
        sbSQL.Append(" WHEN NOT MATCHED THEN ")
        sbSQL.Append(" INSERT(")
        sbSQL.Append("  " & NameOf(_D004_SYONIN_J_KANRI.SYONIN_HOKOKUSYO_ID))
        sbSQL.Append(" ," & NameOf(_D004_SYONIN_J_KANRI.HOKOKU_NO))
        sbSQL.Append(" ," & NameOf(_D004_SYONIN_J_KANRI.SYONIN_JUN))
        sbSQL.Append(" ," & NameOf(_D004_SYONIN_J_KANRI.SYAIN_ID))
        sbSQL.Append(" ," & NameOf(_D004_SYONIN_J_KANRI.SYONIN_YMDHNS))
        sbSQL.Append(" ," & NameOf(_D004_SYONIN_J_KANRI.SYONIN_HANTEI_KB))
        sbSQL.Append(" ," & NameOf(_D004_SYONIN_J_KANRI.SASIMODOSI_FG))
        sbSQL.Append(" ," & NameOf(_D004_SYONIN_J_KANRI.RIYU))
        sbSQL.Append(" ," & NameOf(_D004_SYONIN_J_KANRI.COMMENT))
        sbSQL.Append(" ," & NameOf(_D004_SYONIN_J_KANRI.MAIL_SEND_FG))
        sbSQL.Append(" ," & NameOf(_D004_SYONIN_J_KANRI.ADD_SYAIN_ID))
        sbSQL.Append(" ," & NameOf(_D004_SYONIN_J_KANRI.ADD_YMDHNS))
        sbSQL.Append(" ," & NameOf(_D004_SYONIN_J_KANRI.UPD_SYAIN_ID))
        sbSQL.Append(" ," & NameOf(_D004_SYONIN_J_KANRI.UPD_YMDHNS))
        sbSQL.Append(" ) VALUES(")
        sbSQL.Append("  WK." & NameOf(_D004_SYONIN_J_KANRI.SYONIN_HOKOKUSYO_ID))
        sbSQL.Append(" ,WK." & NameOf(_D004_SYONIN_J_KANRI.HOKOKU_NO))
        sbSQL.Append(" ,WK." & NameOf(_D004_SYONIN_J_KANRI.SYONIN_JUN))
        sbSQL.Append(" ,WK." & NameOf(_D004_SYONIN_J_KANRI.SYAIN_ID))
        sbSQL.Append(" ,WK." & NameOf(_D004_SYONIN_J_KANRI.SYONIN_YMDHNS))
        sbSQL.Append(" ,WK." & NameOf(_D004_SYONIN_J_KANRI.SYONIN_HANTEI_KB))
        sbSQL.Append(" ,WK." & NameOf(_D004_SYONIN_J_KANRI.SASIMODOSI_FG))
        sbSQL.Append(" ,WK." & NameOf(_D004_SYONIN_J_KANRI.RIYU))
        sbSQL.Append(" ,WK." & NameOf(_D004_SYONIN_J_KANRI.COMMENT))
        sbSQL.Append(" ,WK." & NameOf(_D004_SYONIN_J_KANRI.MAIL_SEND_FG))
        sbSQL.Append(" ,WK." & NameOf(_D004_SYONIN_J_KANRI.ADD_SYAIN_ID))
        sbSQL.Append(" ,dbo.GetSysDateString()") 'ADD_YMDHNS
        sbSQL.Append(" ,WK." & NameOf(_D004_SYONIN_J_KANRI.UPD_SYAIN_ID))
        sbSQL.Append(" ,dbo.GetSysDateString()")
        sbSQL.Append(" )")
        sbSQL.Append("OUTPUT $action AS RESULT")
        sbSQL.Append(";")
        strRET = DB.ExecuteScalar(sbSQL.ToString, conblnNonMsg, sqlEx)
        Select Case strRET
            Case "INSERT"

            Case "UPDATE"

            Case Else
                If sqlEx.Source IsNot Nothing Then
                    '-----エラーログ出力
                    Dim strErrMsg As String = My.Resources.ErrLogSqlExecutionFailure & sbSQL.ToString & "|" & sqlEx.Message
                    WL.WriteLogDat(strErrMsg)
                Else
                    '---排他制御
                    Dim strMsg As String
                    strMsg = "既に他の担当者によって変更されているため保存出来ません。" & vbCrLf &
                                "再度登録し直して下さい。"

                    MessageBox.Show(strMsg, "同時更新無効", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                End If
                Return False
        End Select

#End Region

#Region "申請"

        Select Case enmSAVE_MODE
            Case ENM_SAVE_MODE._1_保存
                '保存実績のみ
                Return True
            Case ENM_SAVE_MODE._2_承認申請
                _D004_SYONIN_J_KANRI.SYONIN_JUN = FunGetNextSYONIN_JUN(PrCurrentStage)

                If PrCurrentStage = ENM_NCR_STAGE._120_abcde処置確認 Then
                    _D004_SYONIN_J_KANRI.SYAIN_ID = 0
                    _D004_SYONIN_J_KANRI.SYONIN_YMDHNS = strSysDate
                    _D004_SYONIN_J_KANRI.SYONIN_HANTEI_KB = ENM_SYONIN_HANTEI_KB._1_承認
                    _D004_SYONIN_J_KANRI.SYONIN_JUN = 999 'Close
                Else
                    _D004_SYONIN_J_KANRI.SYAIN_ID = FunGetNextSYONIN_TANTO_ID(PrCurrentStage)
                    _D004_SYONIN_J_KANRI.SYONIN_YMDHNS = ""
                    _D004_SYONIN_J_KANRI.SYONIN_HANTEI_KB = ENM_SYONIN_HANTEI_KB._0_未承認
                End If
                _D004_SYONIN_J_KANRI.RIYU = ""
                _D004_SYONIN_J_KANRI.COMMENT = ""
                _D004_SYONIN_J_KANRI.MAIL_SEND_FG = False

            Case Else
                'Err
                Return False
        End Select

        _D004_SYONIN_J_KANRI.ADD_YMDHNS = strSysDate 'Now.ToString("yyyyMMddHHmmss")

        '-----MERGE
        sbSQL.Remove(0, sbSQL.Length)
        sbSQL.Append($"MERGE INTO {NameOf(MODEL.D004_SYONIN_J_KANRI)} AS SrcT")
        sbSQL.Append($" USING (")
        sbSQL.Append($" SELECT")
        sbSQL.Append($" {_D004_SYONIN_J_KANRI.SYONIN_HOKOKUSYO_ID} AS {NameOf(_D004_SYONIN_J_KANRI.SYONIN_HOKOKUSYO_ID)}")
        sbSQL.Append($" ,'{_D004_SYONIN_J_KANRI.HOKOKU_NO}' AS {NameOf(_D004_SYONIN_J_KANRI.HOKOKU_NO)}")
        sbSQL.Append($" ,{_D004_SYONIN_J_KANRI.SYONIN_JUN} AS {NameOf(_D004_SYONIN_J_KANRI.SYONIN_JUN)}")
        sbSQL.Append($" ,'{_D004_SYONIN_J_KANRI.SYAIN_ID}' AS {NameOf(_D004_SYONIN_J_KANRI.SYAIN_ID)}")
        sbSQL.Append($" ,'{_D004_SYONIN_J_KANRI.SYONIN_YMDHNS}' AS {NameOf(_D004_SYONIN_J_KANRI.SYONIN_YMDHNS)}")
        sbSQL.Append($" ,'{_D004_SYONIN_J_KANRI.SYONIN_HANTEI_KB}' AS {NameOf(_D004_SYONIN_J_KANRI.SYONIN_HANTEI_KB)}")
        sbSQL.Append($" ,'{_D004_SYONIN_J_KANRI._SASIMODOSI_FG}' AS {NameOf(_D004_SYONIN_J_KANRI.SASIMODOSI_FG)}")
        sbSQL.Append($" ,'{_D004_SYONIN_J_KANRI.RIYU}' AS {NameOf(_D004_SYONIN_J_KANRI.RIYU)}")
        sbSQL.Append($" ,'{_D004_SYONIN_J_KANRI.COMMENT}' AS {NameOf(_D004_SYONIN_J_KANRI.COMMENT)}")
        sbSQL.Append($" ,'{_D004_SYONIN_J_KANRI._MAIL_SEND_FG}' AS {NameOf(_D004_SYONIN_J_KANRI.MAIL_SEND_FG)}")
        sbSQL.Append($" ,{_D004_SYONIN_J_KANRI.ADD_SYAIN_ID} AS {NameOf(_D004_SYONIN_J_KANRI.ADD_SYAIN_ID)}")
        sbSQL.Append($" ,'{_D004_SYONIN_J_KANRI.ADD_YMDHNS}' AS {NameOf(_D004_SYONIN_J_KANRI.ADD_YMDHNS)}")
        sbSQL.Append($" ,{pub_SYAIN_INFO.SYAIN_ID} AS {NameOf(_D004_SYONIN_J_KANRI.UPD_SYAIN_ID)}")
        sbSQL.Append($" ,'{_D004_SYONIN_J_KANRI.UPD_YMDHNS}' AS {NameOf(_D004_SYONIN_J_KANRI.UPD_YMDHNS)}")
        sbSQL.Append($" ) AS WK")
        sbSQL.Append($" ON (SrcT.{NameOf(_D004_SYONIN_J_KANRI.SYONIN_HOKOKUSYO_ID)} = WK.{NameOf(_D004_SYONIN_J_KANRI.SYONIN_HOKOKUSYO_ID)}")
        sbSQL.Append($" AND SrcT.{NameOf(_D004_SYONIN_J_KANRI.HOKOKU_NO)} = WK.{NameOf(_D004_SYONIN_J_KANRI.HOKOKU_NO)}")
        sbSQL.Append($" AND SrcT.{NameOf(_D004_SYONIN_J_KANRI.SYONIN_JUN)} = WK.{NameOf(_D004_SYONIN_J_KANRI.SYONIN_JUN)})")

        'UPDATE 排他制御 更新日時が変更されていない場合のみ
        sbSQL.Append($" WHEN MATCHED AND SrcT.{NameOf(_D004_SYONIN_J_KANRI.UPD_YMDHNS)} = WK.{NameOf(_D004_SYONIN_J_KANRI.UPD_YMDHNS)} THEN ")
        sbSQL.Append($" UPDATE SET")
        sbSQL.Append($"  SrcT.{NameOf(_D004_SYONIN_J_KANRI.SYAIN_ID)} = WK.{NameOf(_D004_SYONIN_J_KANRI.SYAIN_ID)}")
        sbSQL.Append($" ,SrcT.{NameOf(_D004_SYONIN_J_KANRI.COMMENT)} = WK.{NameOf(_D004_SYONIN_J_KANRI.COMMENT)}")
        sbSQL.Append($" ,SrcT.{NameOf(_D004_SYONIN_J_KANRI.UPD_SYAIN_ID)} = WK.{NameOf(_D004_SYONIN_J_KANRI.UPD_SYAIN_ID)}")
        sbSQL.Append($" ,SrcT.{NameOf(_D004_SYONIN_J_KANRI.UPD_YMDHNS)} = dbo.GetSysDateString()")
        'INSERT
        sbSQL.Append(" WHEN NOT MATCHED THEN ")
        sbSQL.Append(" INSERT(")
        sbSQL.Append("  " & NameOf(_D004_SYONIN_J_KANRI.SYONIN_HOKOKUSYO_ID))
        sbSQL.Append(" ," & NameOf(_D004_SYONIN_J_KANRI.HOKOKU_NO))
        sbSQL.Append(" ," & NameOf(_D004_SYONIN_J_KANRI.SYONIN_JUN))
        sbSQL.Append(" ," & NameOf(_D004_SYONIN_J_KANRI.SYAIN_ID))
        sbSQL.Append(" ," & NameOf(_D004_SYONIN_J_KANRI.SYONIN_YMDHNS))
        sbSQL.Append(" ," & NameOf(_D004_SYONIN_J_KANRI.SYONIN_HANTEI_KB))
        sbSQL.Append(" ," & NameOf(_D004_SYONIN_J_KANRI.SASIMODOSI_FG))
        sbSQL.Append(" ," & NameOf(_D004_SYONIN_J_KANRI.RIYU))
        sbSQL.Append(" ," & NameOf(_D004_SYONIN_J_KANRI.COMMENT))
        sbSQL.Append(" ," & NameOf(_D004_SYONIN_J_KANRI.MAIL_SEND_FG))
        sbSQL.Append(" ," & NameOf(_D004_SYONIN_J_KANRI.ADD_SYAIN_ID))
        sbSQL.Append(" ," & NameOf(_D004_SYONIN_J_KANRI.ADD_YMDHNS))
        sbSQL.Append(" ," & NameOf(_D004_SYONIN_J_KANRI.UPD_SYAIN_ID))
        sbSQL.Append(" ," & NameOf(_D004_SYONIN_J_KANRI.UPD_YMDHNS))
        sbSQL.Append(" ) VALUES(")
        sbSQL.Append("  WK." & NameOf(_D004_SYONIN_J_KANRI.SYONIN_HOKOKUSYO_ID))
        sbSQL.Append(" ,WK." & NameOf(_D004_SYONIN_J_KANRI.HOKOKU_NO))
        sbSQL.Append(" ,WK." & NameOf(_D004_SYONIN_J_KANRI.SYONIN_JUN))
        sbSQL.Append(" ,WK." & NameOf(_D004_SYONIN_J_KANRI.SYAIN_ID))
        sbSQL.Append(" ,WK." & NameOf(_D004_SYONIN_J_KANRI.SYONIN_YMDHNS))
        sbSQL.Append(" ,WK." & NameOf(_D004_SYONIN_J_KANRI.SYONIN_HANTEI_KB))
        sbSQL.Append(" ,WK." & NameOf(_D004_SYONIN_J_KANRI.SASIMODOSI_FG))
        sbSQL.Append(" ,WK." & NameOf(_D004_SYONIN_J_KANRI.RIYU))
        sbSQL.Append(" ,WK." & NameOf(_D004_SYONIN_J_KANRI.COMMENT))
        sbSQL.Append(" ,WK." & NameOf(_D004_SYONIN_J_KANRI.MAIL_SEND_FG))
        sbSQL.Append(" ,WK." & NameOf(_D004_SYONIN_J_KANRI.ADD_SYAIN_ID))
        sbSQL.Append(" ,WK." & NameOf(_D004_SYONIN_J_KANRI.ADD_YMDHNS))
        sbSQL.Append(" ,WK." & NameOf(_D004_SYONIN_J_KANRI.UPD_SYAIN_ID))
        sbSQL.Append(" ,WK." & NameOf(_D004_SYONIN_J_KANRI.UPD_YMDHNS))
        sbSQL.Append(" )")
        sbSQL.Append("OUTPUT $action AS RESULT") 'INSERT OR UPDATE をncarchar(10)で取得する場合
        sbSQL.Append(";")

        ''-----MERGE実行&実行結果取得
        strRET = DB.ExecuteScalar(sbSQL.ToString, conblnNonMsg, sqlEx)
        Select Case strRET
            Case "INSERT"
                If PrCurrentStage < ENM_NCR_STAGE._120_abcde処置確認 AndAlso _D004_SYONIN_J_KANRI.MAIL_SEND_FG = False Then
                    '承認依頼メール送信
                    Call FunSendRequestMail_NCR()
                End If

            Case "UPDATE"

            Case Else
                If sqlEx.Source IsNot Nothing Then
                    '-----エラーログ出力
                    Dim strErrMsg As String = My.Resources.ErrLogSqlExecutionFailure & sbSQL.ToString & "|" & sqlEx.Message
                    WL.WriteLogDat(strErrMsg)
                Else
                    '---排他制御
                    Dim strMsg As String
                    strMsg = "既に他の担当者によって変更されているため保存出来ません。" & vbCrLf &
                                "再度登録し直して下さい。"

                    MessageBox.Show(strMsg, "同時更新無効", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                End If
                Return False
        End Select

#End Region

#Region "CAR起草依頼メール送信"

        '#73
        sbSQL.Remove(0, sbSQL.Length)
        sbSQL.Append($"SELECT COUNT({NameOf(MODEL.D005_CAR_J.HOKOKU_NO)}) FROM {NameOf(MODEL.D005_CAR_J)} ")
        sbSQL.Append($" WHERE {NameOf(MODEL.D005_CAR_J.HOKOKU_NO)}='{_D004_SYONIN_J_KANRI.HOKOKU_NO}'")
        strRET = DB.ExecuteScalar(sbSQL.ToString, conblnNonMsg)
        If Val(strRET) = 0 Then
            'SPEC: 40-1
            If enmSAVE_MODE = ENM_SAVE_MODE._2_承認申請 And
                PrCurrentStage = ENM_NCR_STAGE._40_事前審査判定及びCAR要否判定 And
                _D003_NCR_J._ZESEI_SYOCHI_YOHI_KB = ENM_YOHI_KB._1_要 Then

                If FunSAVE_D005(DB) Then
                    '承認依頼メール送信
                    Call FunSendRequestMail_CAR()
                    blnEnableCAREdit = True
                Else
                    Return False
                End If
            End If
        End If

#End Region

        Return True
    End Function

#End Region

#Region "   承認依頼メール送信"

    ''' <summary>
    ''' 承認依頼メール送信
    ''' </summary>
    ''' <returns></returns>
    Private Function FunSendRequestMail_NCR()
        Dim KISYU_NAME As String = tblKISYU.AsEnumerable.Where(Function(r) r.Field(Of Integer)("VALUE") = _D003_NCR_J.KISYU_ID).FirstOrDefault?.Item("DISP")
        Dim SYONIN_HANTEI_NAME As String = tblSYONIN_HANTEI_KB.AsEnumerable.Where(Function(r) r.Field(Of String)("VALUE") = _D004_SYONIN_J_KANRI.SYONIN_HANTEI_KB).FirstOrDefault?.Item("DISP")
        Dim strEXEParam As String = _D004_SYONIN_J_KANRI.SYAIN_ID & "," & ENM_OPEN_MODE._2_処置画面起動 & "," & Context.ENM_SYONIN_HOKOKUSYO_ID._1_NCR & "," & _D004_SYONIN_J_KANRI.HOKOKU_NO
        Dim strSubject As String = $"【不適合品処置依頼】{KISYU_NAME}・{_D003_NCR_J.BUHIN_BANGO}"
        Dim strBody As String = <html><![CDATA[
        {0} 殿<br />
        <br />
        　不適合製品の処置依頼が来ましたので対応をお願いします。<br />
        <br />
        　　【報告書No】{1}<br />
        　　【起草日　】{2}<br />
        　　【機種　　】{3}<br />
        　　【部品番号】{4}<br />
        　　【依頼者　】{5}<br />
        　　【依頼者処置内容】{6}<br />
        　　【コメント】{7}<br />
        <br />
        <a href = "http://sv116:8000/CLICKONCE_FMS.application" >システム起動</a><br />
        <br />
        ※このメールは配信専用です。(返信できません)<br />
        返信する場合は、各担当者のメールアドレスを使用して下さい。<br />
        ]]></html>.Value.Trim

        'http://sv116:8000/CLICKONCE_FMS.application?SYAIN_ID={8}&EXEPATH={9}&PARAMS={10}

        strBody = String.Format(strBody,
                                Fun_GetUSER_NAME(_D004_SYONIN_J_KANRI.SYAIN_ID),
                                _D004_SYONIN_J_KANRI.HOKOKU_NO,
                                DateTime.ParseExact(_D003_NCR_J.ADD_YMD, "yyyyMMdd", Nothing).ToString("yyyy/MM/dd"),
                                KISYU_NAME,
                                _D003_NCR_J.BUHIN_BANGO,
                                Fun_GetUSER_NAME(pub_SYAIN_INFO.SYAIN_ID),
                                SYONIN_HANTEI_NAME,
                                _D004_SYONIN_J_KANRI.COMMENT,
                                _D004_SYONIN_J_KANRI.SYAIN_ID,
                                "FMS_G0010.exe",
                                strEXEParam)

        If FunSendMailFutekigo(strSubject, strBody, ToSYAIN_ID:=_D004_SYONIN_J_KANRI.SYAIN_ID) Then
            Return True
        Else
            MessageBox.Show("メール送信に失敗しました。", "メール送信失敗", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Return False
        End If
    End Function

    ''' <summary>
    ''' 承認依頼メール送信
    ''' </summary>
    ''' <returns></returns>
    Private Function FunSendRequestMail_CAR()
        Dim KISYU_NAME As String = tblKISYU.AsEnumerable.Where(Function(r) r.Field(Of Integer)("VALUE") = _D003_NCR_J.KISYU_ID).FirstOrDefault?.Item("DISP")
        Dim SYONIN_HANTEI_NAME As String = tblSYONIN_HANTEI_KB.AsEnumerable.Where(Function(r) r.Field(Of String)("VALUE") = _D004_SYONIN_J_KANRI.SYONIN_HANTEI_KB).FirstOrDefault?.Item("DISP")
        Dim strEXEParam As String = _D004_SYONIN_J_KANRI.SYAIN_ID & "," & ENM_OPEN_MODE._2_処置画面起動 & "," & Context.ENM_SYONIN_HOKOKUSYO_ID._2_CAR & "," & _D004_SYONIN_J_KANRI.HOKOKU_NO
        Dim strSubject As String = $"【不適合品処置依頼】{KISYU_NAME}・{_D003_NCR_J.BUHIN_BANGO}"
        Dim strBody As String = <sql><![CDATA[
        {0} 殿<br />
        <br />
        　{1} 殿より{0} 殿宛にCARの起草入力依頼がありました。<br />
        　不適合管理システムから該当するデータを選択し、起草入力を行って下さい。<br />
        <br />
        　　【報告書No】{2}<br />
        　　【機種　　】{3}<br />
        　　【部品番号】{4}<br />
        　　【依頼者　】{1}<br />
        <br />
        <a href = "http://sv116:8000/CLICKONCE_FMS.application" >システム起動</a><br />
        <br />
        ※このメールは配信専用です。(返信できません)<br />
        返信する場合は、各担当者のメールアドレスを使用して下さい。<br />
        ]]></sql>.Value.Trim

        'http://sv116:8000/CLICKONCE_FMS.application?SYAIN_ID={5}&EXEPATH={6}&PARAMS={7}

        strBody = String.Format(strBody,
                                Fun_GetUSER_NAME(_D004_SYONIN_J_KANRI.SYAIN_ID),
                                Fun_GetUSER_NAME(pub_SYAIN_INFO.SYAIN_ID),
                                _D004_SYONIN_J_KANRI.HOKOKU_NO,
                                KISYU_NAME,
                                _D003_NCR_J.BUHIN_BANGO,
                                _D004_SYONIN_J_KANRI.SYAIN_ID,
                                "FMS_G0010.exe",
                                strEXEParam)

        If FunSendMailFutekigo(strSubject, strBody, ToSYAIN_ID:=_D004_SYONIN_J_KANRI.SYAIN_ID) Then
            Return True
        Else
            MessageBox.Show("メール送信に失敗しました。", "メール送信失敗", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Return False
        End If
    End Function

#End Region

#Region "   R001保存"

    ''' <summary>
    ''' 報告書操作履歴更新
    ''' </summary>
    ''' <param name="DB"></param>
    ''' <param name="enmSAVE_MODE"></param>
    ''' <returns></returns>
    Private Function FunSAVE_R001(ByRef DB As ClsDbUtility, ByVal enmSAVE_MODE As ENM_SAVE_MODE) As Boolean
        Dim sbSQL As New System.Text.StringBuilder
        Dim intRET As Integer
        Dim sqlEx As New Exception
        Dim strSysDate As String = DB.GetSysDateString
        'UNDONE: MERGE INTO に変更

        '---存在確認
        Dim dsList As New DataSet
        Dim blnExist As Boolean
        sbSQL.Append($"SELECT {NameOf(MODEL.R001_HOKOKU_SOUSA.HOKOKU_NO)} FROM {NameOf(MODEL.R001_HOKOKU_SOUSA)}")
        sbSQL.Append($" WHERE {NameOf(MODEL.R001_HOKOKU_SOUSA.HOKOKU_NO)} ='{_D003_NCR_J.HOKOKU_NO}'")
        dsList = DB.GetDataSet(sbSQL.ToString, conblnNonMsg)
        If dsList.Tables(0).Rows.Count > 0 Then
            blnExist = True
        End If

        '-----データモデル更新
        _R001_HOKOKU_SOUSA.SYONIN_HOKOKUSYO_ID = Context.ENM_SYONIN_HOKOKUSYO_ID._1_NCR
        _R001_HOKOKU_SOUSA.HOKOKU_NO = _D003_NCR_J.HOKOKU_NO
        _R001_HOKOKU_SOUSA.SYONIN_JUN = PrCurrentStage
        _R001_HOKOKU_SOUSA.SYAIN_ID = pub_SYAIN_INFO.SYAIN_ID
        'UNDONE: getsysdatetime
        _R001_HOKOKU_SOUSA.ADD_YMDHNS = strSysDate 'Now.ToString("yyyyMMddHHmmss")

        Select Case enmSAVE_MODE
            Case ENM_SAVE_MODE._1_保存
                _R001_HOKOKU_SOUSA.SYONIN_HANTEI_KB = ENM_SYONIN_HANTEI_KB._0_未承認
            Case ENM_SAVE_MODE._2_承認申請
                _R001_HOKOKU_SOUSA.SYONIN_HANTEI_KB = ENM_SYONIN_HANTEI_KB._1_承認
        End Select

        Select Case enmSAVE_MODE
            Case ENM_SAVE_MODE._1_保存
                '#55
                _R001_HOKOKU_SOUSA.SOUSA_KB = ENM_HOKOKUSYO_SOUSA_KB._2_更新保存

                '#56 一時保存時の履歴は残さない
                Return True
            Case ENM_SAVE_MODE._2_承認申請
                _R001_HOKOKU_SOUSA.SOUSA_KB = ENM_HOKOKUSYO_SOUSA_KB._1_申請承認依頼
        End Select
        '-----

        '-----INSERT
        sbSQL.Remove(0, sbSQL.Length)
        sbSQL.Append("INSERT INTO " & NameOf(MODEL.R001_HOKOKU_SOUSA) & "(")
        sbSQL.Append("  " & NameOf(_R001_HOKOKU_SOUSA.SYONIN_HOKOKUSYO_ID))
        sbSQL.Append(" ," & NameOf(_R001_HOKOKU_SOUSA.HOKOKU_NO))
        sbSQL.Append(" ," & NameOf(_R001_HOKOKU_SOUSA.ADD_YMDHNS))
        sbSQL.Append(" ," & NameOf(_R001_HOKOKU_SOUSA.SYONIN_JUN))
        sbSQL.Append(" ," & NameOf(_R001_HOKOKU_SOUSA.SOUSA_KB))
        sbSQL.Append(" ," & NameOf(_R001_HOKOKU_SOUSA.SYAIN_ID))
        sbSQL.Append(" ," & NameOf(_R001_HOKOKU_SOUSA.SYONIN_HANTEI_KB))
        sbSQL.Append(" ," & NameOf(_R001_HOKOKU_SOUSA.RIYU))
        sbSQL.Append(" ) VALUES(")
        sbSQL.Append("  " & _R001_HOKOKU_SOUSA.SYONIN_HOKOKUSYO_ID)
        sbSQL.Append(" ,'" & _R001_HOKOKU_SOUSA.HOKOKU_NO & "'")
        sbSQL.Append(" ,'" & _R001_HOKOKU_SOUSA.ADD_YMDHNS & "'")
        sbSQL.Append(" ," & _R001_HOKOKU_SOUSA.SYONIN_JUN)
        sbSQL.Append(" ,'" & _R001_HOKOKU_SOUSA.SOUSA_KB & "'")
        sbSQL.Append(" ," & _R001_HOKOKU_SOUSA.SYAIN_ID)
        sbSQL.Append(" ,'" & _R001_HOKOKU_SOUSA.SYONIN_HANTEI_KB & "'")
        sbSQL.Append(" ,'" & _R001_HOKOKU_SOUSA.RIYU & "'")
        sbSQL.Append(")")

        '-----SQL実行
        intRET = DB.ExecuteNonQuery(sbSQL.ToString, conblnNonMsg, sqlEx)
        If intRET <> 1 Then
            '-----エラーログ出力
            Dim strErrMsg As String = My.Resources.ErrLogSqlExecutionFailure & sbSQL.ToString & "|" & sqlEx.Message
            WL.WriteLogDat(strErrMsg)
            Return False
        End If

        If FunSAVE_R003(DB, _R001_HOKOKU_SOUSA.ADD_YMDHNS) Then
        Else
            Return False
        End If

        Return True
    End Function

#End Region

#Region "   R003保存"

    ''' <summary>
    ''' 差し戻し履歴登録
    ''' </summary>
    ''' <param name="DB"></param>
    ''' <param name="strYMDHNS"></param>
    ''' <returns></returns>
    Private Function FunSAVE_R003(ByRef DB As ClsDbUtility, ByVal strYMDHNS As String) As Boolean
        Dim sbSQL As New System.Text.StringBuilder
        Dim intRET As Integer
        Dim sqlEx As New Exception

        '-----MERGE
        sbSQL.Append(" INSERT INTO " & NameOf(MODEL.R003_NCR_SASIMODOSI) & "(")
        sbSQL.Append(" " & NameOf(_R003_NCR_SASIMODOSI.SASIMODOSI_YMDHNS))
        sbSQL.Append(" ," & NameOf(_R003_NCR_SASIMODOSI.HOKOKU_NO))
        sbSQL.Append(" ," & NameOf(_R003_NCR_SASIMODOSI.BUMON_KB))
        sbSQL.Append(" ," & NameOf(_R003_NCR_SASIMODOSI.CLOSE_FG))
        sbSQL.Append(" ," & NameOf(_R003_NCR_SASIMODOSI.KISYU_ID))
        sbSQL.Append(" ," & NameOf(_R003_NCR_SASIMODOSI.SYANAI_CD))
        sbSQL.Append(" ," & NameOf(_R003_NCR_SASIMODOSI.BUHIN_BANGO))
        sbSQL.Append(" ," & NameOf(_R003_NCR_SASIMODOSI.BUHIN_NAME))
        sbSQL.Append(" ," & NameOf(_R003_NCR_SASIMODOSI.GOKI))
        sbSQL.Append(" ," & NameOf(_R003_NCR_SASIMODOSI.SURYO))
        sbSQL.Append(" ," & NameOf(_R003_NCR_SASIMODOSI.SAIHATU))
        sbSQL.Append(" ," & NameOf(_R003_NCR_SASIMODOSI.FUTEKIGO_JYOTAI_KB))
        sbSQL.Append(" ," & NameOf(_R003_NCR_SASIMODOSI.FUTEKIGO_NAIYO))
        sbSQL.Append(" ," & NameOf(_R003_NCR_SASIMODOSI.FUTEKIGO_KB))
        sbSQL.Append(" ," & NameOf(_R003_NCR_SASIMODOSI.FUTEKIGO_S_KB))
        sbSQL.Append(" ," & NameOf(_R003_NCR_SASIMODOSI.ZUMEN_KIKAKU))
        sbSQL.Append(" ," & NameOf(_R003_NCR_SASIMODOSI.YOKYU_NAIYO))
        sbSQL.Append(" ," & NameOf(_R003_NCR_SASIMODOSI.KANSATU_KEKKA))
        sbSQL.Append(" ," & NameOf(_R003_NCR_SASIMODOSI.ZESEI_SYOCHI_YOHI_KB))
        sbSQL.Append(" ," & NameOf(_R003_NCR_SASIMODOSI.ZESEI_NASI_RIYU))
        sbSQL.Append(" ," & NameOf(_R003_NCR_SASIMODOSI.HASSEI_KOTEI_GL_SYAIN_ID))
        sbSQL.Append(" ," & NameOf(_R003_NCR_SASIMODOSI.JIZEN_SINSA_HANTEI_KB))
        sbSQL.Append(" ," & NameOf(_R003_NCR_SASIMODOSI.JIZEN_SINSA_SYAIN_ID))
        sbSQL.Append(" ," & NameOf(_R003_NCR_SASIMODOSI.JIZEN_SINSA_YMD))
        sbSQL.Append(" ," & NameOf(_R003_NCR_SASIMODOSI.SAISIN_KAKUNIN_SYAIN_ID))
        sbSQL.Append(" ," & NameOf(_R003_NCR_SASIMODOSI.SAISIN_KAKUNIN_YMD))
        sbSQL.Append(" ," & NameOf(_R003_NCR_SASIMODOSI.SAISIN_IINKAI_HANTEI_KB))
        sbSQL.Append(" ," & NameOf(_R003_NCR_SASIMODOSI.SAISIN_GIJYUTU_SYAIN_ID))
        sbSQL.Append(" ," & NameOf(_R003_NCR_SASIMODOSI.SAISIN_GIJYUTU_YMD))
        sbSQL.Append(" ," & NameOf(_R003_NCR_SASIMODOSI.SAISIN_HINSYO_SYAIN_ID))
        sbSQL.Append(" ," & NameOf(_R003_NCR_SASIMODOSI.SAISIN_HINSYO_YMD))
        sbSQL.Append(" ," & NameOf(_R003_NCR_SASIMODOSI.SAISIN_IINKAI_SIRYO_NO))
        sbSQL.Append(" ," & NameOf(_R003_NCR_SASIMODOSI.ITAG_NO))
        sbSQL.Append(" ," & NameOf(_R003_NCR_SASIMODOSI.KOKYAKU_SAISIN_TANTO_ID))
        sbSQL.Append(" ," & NameOf(_R003_NCR_SASIMODOSI.KOKYAKU_SAISIN_YMD))
        sbSQL.Append(" ," & NameOf(_R003_NCR_SASIMODOSI.KOKYAKU_HANTEI_SIJI_KB))
        sbSQL.Append(" ," & NameOf(_R003_NCR_SASIMODOSI.KOKYAKU_HANTEI_SIJI_YMD))
        sbSQL.Append(" ," & NameOf(_R003_NCR_SASIMODOSI.KOKYAKU_SAISYU_HANTEI_KB))
        sbSQL.Append(" ," & NameOf(_R003_NCR_SASIMODOSI.KOKYAKU_SAISYU_HANTEI_YMD))
        sbSQL.Append(" ," & NameOf(_R003_NCR_SASIMODOSI.SAIKAKO_SIJI_FG))
        sbSQL.Append(" ," & NameOf(_R003_NCR_SASIMODOSI.HAIKYAKU_YMD))
        sbSQL.Append(" ," & NameOf(_R003_NCR_SASIMODOSI.HAIKYAKU_KB))
        sbSQL.Append(" ," & NameOf(_R003_NCR_SASIMODOSI.HAIKYAKU_HOUHOU))
        sbSQL.Append(" ," & NameOf(_R003_NCR_SASIMODOSI.HAIKYAKU_TANTO_ID))
        sbSQL.Append(" ," & NameOf(_R003_NCR_SASIMODOSI.SAIKAKO_SIJI_NO))
        sbSQL.Append(" ," & NameOf(_R003_NCR_SASIMODOSI.SAIKAKO_SAGYO_KAN_YMD))
        sbSQL.Append(" ," & NameOf(_R003_NCR_SASIMODOSI.SAIKAKO_KENSA_YMD))
        sbSQL.Append(" ," & NameOf(_R003_NCR_SASIMODOSI.KENSA_KEKKA_KB))
        sbSQL.Append(" ," & NameOf(_R003_NCR_SASIMODOSI.SEIGI_TANTO_ID))
        sbSQL.Append(" ," & NameOf(_R003_NCR_SASIMODOSI.SEIZO_TANTO_ID))
        sbSQL.Append(" ," & NameOf(_R003_NCR_SASIMODOSI.KENSA_TANTO_ID))
        sbSQL.Append(" ," & NameOf(_R003_NCR_SASIMODOSI.HENKYAKU_YMD))
        sbSQL.Append(" ," & NameOf(_R003_NCR_SASIMODOSI.HENKYAKU_SAKI))
        sbSQL.Append(" ," & NameOf(_R003_NCR_SASIMODOSI.HENKYAKU_TANTO_ID))
        sbSQL.Append(" ," & NameOf(_R003_NCR_SASIMODOSI.HENKYAKU_BIKO))
        sbSQL.Append(" ," & NameOf(_R003_NCR_SASIMODOSI.TENYO_KISYU_ID))
        sbSQL.Append(" ," & NameOf(_R003_NCR_SASIMODOSI.TENYO_BUHIN_BANGO))
        sbSQL.Append(" ," & NameOf(_R003_NCR_SASIMODOSI.TENYO_GOKI))
        sbSQL.Append(" ," & NameOf(_R003_NCR_SASIMODOSI.TENYO_LOT))
        sbSQL.Append(" ," & NameOf(_R003_NCR_SASIMODOSI.TENYO_YMD))
        sbSQL.Append(" ," & NameOf(_R003_NCR_SASIMODOSI.SYOCHI_KEKKA_A))
        sbSQL.Append(" ," & NameOf(_R003_NCR_SASIMODOSI.SYOCHI_KEKKA_B))
        sbSQL.Append(" ," & NameOf(_R003_NCR_SASIMODOSI.SYOCHI_KEKKA_C))
        sbSQL.Append(" ," & NameOf(_R003_NCR_SASIMODOSI.SYOCHI_D_UMU_KB))
        sbSQL.Append(" ," & NameOf(_R003_NCR_SASIMODOSI.SYOCHI_D_YOHI_KB))
        sbSQL.Append(" ," & NameOf(_R003_NCR_SASIMODOSI.SYOCHI_D_SYOCHI_KIROKU))
        sbSQL.Append(" ," & NameOf(_R003_NCR_SASIMODOSI.SYOCHI_E_UMU_KB))
        sbSQL.Append(" ," & NameOf(_R003_NCR_SASIMODOSI.SYOCHI_E_YOHI_KB))
        sbSQL.Append(" ," & NameOf(_R003_NCR_SASIMODOSI.SYOCHI_E_SYOCHI_KIROKU))
        sbSQL.Append(" ," & NameOf(_R003_NCR_SASIMODOSI.FILE_PATH))
        sbSQL.Append(" ," & NameOf(_R003_NCR_SASIMODOSI.G_FILE_PATH1))
        sbSQL.Append(" ," & NameOf(_R003_NCR_SASIMODOSI.G_FILE_PATH2))
        sbSQL.Append(" ," & NameOf(_R003_NCR_SASIMODOSI.HASSEI_YMD))
        sbSQL.Append(" ) VALUES(")
        sbSQL.Append(" '" & strYMDHNS & "'")
        sbSQL.Append(" ,'" & _D003_NCR_J.HOKOKU_NO & "'")
        sbSQL.Append(" ,'" & _D003_NCR_J.BUMON_KB & "'")
        sbSQL.Append(" ,'" & _D003_NCR_J._CLOSE_FG & "'")
        sbSQL.Append(" ," & _D003_NCR_J.KISYU_ID & "")
        sbSQL.Append(" ,'" & _D003_NCR_J.SYANAI_CD & "'")
        sbSQL.Append(" ,'" & _D003_NCR_J.BUHIN_BANGO & "'")
        sbSQL.Append(" ,'" & _D003_NCR_J.BUHIN_NAME & "'")
        sbSQL.Append(" ,'" & _D003_NCR_J.GOKI & "'")
        sbSQL.Append(" ," & _D003_NCR_J.SURYO & "")
        sbSQL.Append(" ,'" & _D003_NCR_J._SAIHATU & "'")
        sbSQL.Append(" ,'" & _D003_NCR_J.FUTEKIGO_JYOTAI_KB & "'")
        sbSQL.Append(" ,'" & _D003_NCR_J.FUTEKIGO_NAIYO & "'")
        sbSQL.Append(" ,'" & _D003_NCR_J.FUTEKIGO_KB & "'")
        sbSQL.Append(" ,'" & _D003_NCR_J.FUTEKIGO_S_KB & "'")
        sbSQL.Append(" ,'" & _D003_NCR_J.ZUMEN_KIKAKU & "'")
        sbSQL.Append(" ,'" & _D003_NCR_J.YOKYU_NAIYO & "'")
        sbSQL.Append(" ,'" & _D003_NCR_J.KANSATU_KEKKA & "'")
        sbSQL.Append(" ,'" & _D003_NCR_J._ZESEI_SYOCHI_YOHI_KB & "'")
        sbSQL.Append(" ,'" & _D003_NCR_J.ZESEI_NASI_RIYU & "'")
        sbSQL.Append(" ," & _D003_NCR_J.HASSEI_KOTEI_GL_SYAIN_ID & "")
        sbSQL.Append(" ,'" & _D003_NCR_J.JIZEN_SINSA_HANTEI_KB & "'")
        sbSQL.Append(" ," & _D003_NCR_J.JIZEN_SINSA_SYAIN_ID & "")
        sbSQL.Append(" ,'" & _D003_NCR_J.JIZEN_SINSA_YMD & "'")
        sbSQL.Append(" ," & _D003_NCR_J.SAISIN_KAKUNIN_SYAIN_ID & "")
        sbSQL.Append(" ,'" & _D003_NCR_J.SAISIN_KAKUNIN_YMD & "'")
        sbSQL.Append(" ,'" & _D003_NCR_J.SAISIN_IINKAI_HANTEI_KB & "'")
        sbSQL.Append(" ," & _D003_NCR_J.SAISIN_GIJYUTU_SYAIN_ID & "")
        sbSQL.Append(" ,'" & _D003_NCR_J.SAISIN_GIJYUTU_YMD & "'")
        sbSQL.Append(" ," & _D003_NCR_J.SAISIN_HINSYO_SYAIN_ID & "")
        sbSQL.Append(" ,'" & _D003_NCR_J.SAISIN_HINSYO_YMD & "'")
        sbSQL.Append(" ,'" & _D003_NCR_J.SAISIN_IINKAI_SIRYO_NO & "'")
        sbSQL.Append(" ,'" & _D003_NCR_J.ITAG_NO & "'")
        sbSQL.Append(" ," & _D003_NCR_J.KOKYAKU_SAISIN_TANTO_ID & "")
        sbSQL.Append(" ,'" & _D003_NCR_J.KOKYAKU_SAISIN_YMD & "'")
        sbSQL.Append(" ,'" & _D003_NCR_J.KOKYAKU_HANTEI_SIJI_KB & "'")
        sbSQL.Append(" ,'" & _D003_NCR_J.KOKYAKU_HANTEI_SIJI_YMD & "'")
        sbSQL.Append(" ,'" & _D003_NCR_J.KOKYAKU_SAISYU_HANTEI_KB & "'")
        sbSQL.Append(" ,'" & _D003_NCR_J.KOKYAKU_SAISYU_HANTEI_YMD & "'")
        sbSQL.Append(" ,'" & _D003_NCR_J._SAIKAKO_SIJI_FG & "'")
        sbSQL.Append(" ,'" & _D003_NCR_J.HAIKYAKU_YMD & "'")
        sbSQL.Append(" ,'" & _D003_NCR_J.HAIKYAKU_KB & "'")
        sbSQL.Append(" ,'" & _D003_NCR_J.HAIKYAKU_HOUHOU & "'")
        sbSQL.Append(" ," & _D003_NCR_J.HAIKYAKU_TANTO_ID & "")
        sbSQL.Append(" ,'" & _D003_NCR_J.SAIKAKO_SIJI_NO & "'")
        sbSQL.Append(" ,'" & _D003_NCR_J.SAIKAKO_SAGYO_KAN_YMD & "'")
        sbSQL.Append(" ,'" & _D003_NCR_J.SAIKAKO_KENSA_YMD & "'")
        sbSQL.Append(" ,'" & _D003_NCR_J.KENSA_KEKKA_KB & "'")
        sbSQL.Append(" ," & _D003_NCR_J.SEIGI_TANTO_ID & "")
        sbSQL.Append(" ," & _D003_NCR_J.SEIZO_TANTO_ID & "")
        sbSQL.Append(" ," & _D003_NCR_J.KENSA_TANTO_ID & "")
        sbSQL.Append(" ,'" & _D003_NCR_J.HENKYAKU_YMD & "'")
        sbSQL.Append(" ,'" & _D003_NCR_J.HENKYAKU_SAKI & "'")
        sbSQL.Append(" ," & _D003_NCR_J.HENKYAKU_TANTO_ID & "")
        sbSQL.Append(" ,'" & _D003_NCR_J.HENKYAKU_BIKO & "'")
        sbSQL.Append(" ," & _D003_NCR_J.TENYO_KISYU_ID & "")
        sbSQL.Append(" ,'" & _D003_NCR_J.TENYO_BUHIN_BANGO & "'")
        sbSQL.Append(" ,'" & _D003_NCR_J.TENYO_GOKI & "'")
        sbSQL.Append(" ," & _D003_NCR_J.TENYO_LOT & "")
        sbSQL.Append(" ,'" & _D003_NCR_J.TENYO_YMD & "'")
        sbSQL.Append(" ,'" & _D003_NCR_J._SYOCHI_KEKKA_A & "'")
        sbSQL.Append(" ,'" & _D003_NCR_J._SYOCHI_KEKKA_B & "'")
        sbSQL.Append(" ,'" & _D003_NCR_J._SYOCHI_KEKKA_C & "'")
        sbSQL.Append(" ,'" & _D003_NCR_J._SYOCHI_D_UMU_KB & "'")
        sbSQL.Append(" ,'" & _D003_NCR_J._SYOCHI_D_YOHI_KB & "'")
        sbSQL.Append(" ,'" & _D003_NCR_J.SYOCHI_D_SYOCHI_KIROKU & "'")
        sbSQL.Append(" ,'" & _D003_NCR_J._SYOCHI_E_UMU_KB & "'")
        sbSQL.Append(" ,'" & _D003_NCR_J._SYOCHI_E_YOHI_KB & "'")
        sbSQL.Append(" ,'" & _D003_NCR_J.SYOCHI_E_SYOCHI_KIROKU & "'")
        sbSQL.Append(" ,'" & _D003_NCR_J.FILE_PATH & "'")
        sbSQL.Append(" ,'" & _D003_NCR_J.G_FILE_PATH1 & "'")
        sbSQL.Append(" ,'" & _D003_NCR_J.G_FILE_PATH2 & "'")
        sbSQL.Append(" ,'" & _D003_NCR_J.HASSEI_YMD & "'")
        sbSQL.Append(" );")
        intRET = DB.ExecuteNonQuery(sbSQL.ToString, conblnNonMsg, sqlEx)
        If intRET <> 1 Then
            '-----エラーログ出力
            Dim strErrMsg As String = My.Resources.ErrLogSqlExecutionFailure & sbSQL.ToString & "|" & sqlEx.Message
            WL.WriteLogDat(strErrMsg)
            Return False
        Else
            Return True
        End If
    End Function

#End Region

#Region "   Ｄ005保存"

    ''' <summary>
    ''' D005_CAR_J更新
    ''' </summary>
    ''' <param name="DB"></param>
    ''' <returns></returns>
    Private Function FunSAVE_D005(ByRef DB As ClsDbUtility) As Boolean
        Dim sbSQL As New System.Text.StringBuilder
        Dim strRET As String
        Dim sqlEx As New Exception

        '-----データモデル更新
        Dim _D005_CAR_J As New MODEL.D005_CAR_J
        _D005_CAR_J.HOKOKU_NO = _D003_NCR_J.HOKOKU_NO
        _D005_CAR_J.BUMON_KB = _D003_NCR_J.BUMON_KB
        _D005_CAR_J._CLOSE_FG = "0"

        '-----INSERT
        sbSQL.Remove(0, sbSQL.Length)
        sbSQL.Append($"MERGE INTO {NameOf(MODEL.D005_CAR_J)} AS SrcT")
        sbSQL.Append($" USING (")
        sbSQL.Append($" SELECT")
        sbSQL.Append($" '{_D005_CAR_J.HOKOKU_NO}' AS {NameOf(_D005_CAR_J.HOKOKU_NO)}")
        sbSQL.Append($" ,'{_D005_CAR_J.BUMON_KB}' AS {NameOf(_D005_CAR_J.BUMON_KB)}")
        sbSQL.Append($" ,'{_D005_CAR_J._CLOSE_FG}' AS {NameOf(_D005_CAR_J.CLOSE_FG)}")
        sbSQL.Append($" ,'{_D005_CAR_J.SETUMON_1}' AS {NameOf(_D005_CAR_J.SETUMON_1)}")
        sbSQL.Append($" ,'{_D005_CAR_J.SETUMON_2}' AS {NameOf(_D005_CAR_J.SETUMON_2)}")
        sbSQL.Append($" ,'{_D005_CAR_J.SETUMON_3}' AS {NameOf(_D005_CAR_J.SETUMON_3)}")
        sbSQL.Append($" ,'{_D005_CAR_J.SETUMON_4}' AS {NameOf(_D005_CAR_J.SETUMON_4)}")
        sbSQL.Append($" ,'{_D005_CAR_J.SETUMON_5}' AS {NameOf(_D005_CAR_J.SETUMON_5)}")
        sbSQL.Append($" ,'{_D005_CAR_J.SETUMON_6}' AS {NameOf(_D005_CAR_J.SETUMON_6)}")
        sbSQL.Append($" ,'{_D005_CAR_J.SETUMON_7}' AS {NameOf(_D005_CAR_J.SETUMON_7)}")
        sbSQL.Append($" ,'{_D005_CAR_J.SETUMON_8}' AS {NameOf(_D005_CAR_J.SETUMON_8)}")
        sbSQL.Append($" ,'{_D005_CAR_J.SETUMON_9}' AS {NameOf(_D005_CAR_J.SETUMON_9)}")
        sbSQL.Append($" ,'{_D005_CAR_J.SETUMON_10}' AS {NameOf(_D005_CAR_J.SETUMON_10)}")
        sbSQL.Append($" ,'{_D005_CAR_J.SETUMON_11}' AS {NameOf(_D005_CAR_J.SETUMON_11)}")
        sbSQL.Append($" ,'{_D005_CAR_J.SETUMON_12}' AS {NameOf(_D005_CAR_J.SETUMON_12)}")
        sbSQL.Append($" ,'{_D005_CAR_J.SETUMON_13}' AS {NameOf(_D005_CAR_J.SETUMON_13)}")
        sbSQL.Append($" ,'{_D005_CAR_J.SETUMON_14}' AS {NameOf(_D005_CAR_J.SETUMON_14)}")
        sbSQL.Append($" ,'{_D005_CAR_J.SETUMON_15}' AS {NameOf(_D005_CAR_J.SETUMON_15)}")
        sbSQL.Append($" ,'{_D005_CAR_J.SETUMON_16}' AS {NameOf(_D005_CAR_J.SETUMON_16)}")
        sbSQL.Append($" ,'{_D005_CAR_J.SETUMON_17}' AS {NameOf(_D005_CAR_J.SETUMON_17)}")
        sbSQL.Append($" ,'{_D005_CAR_J.SETUMON_18}' AS {NameOf(_D005_CAR_J.SETUMON_18)}")
        sbSQL.Append($" ,'{_D005_CAR_J.SETUMON_19}' AS {NameOf(_D005_CAR_J.SETUMON_19)}")
        sbSQL.Append($" ,'{_D005_CAR_J.SETUMON_20}' AS {NameOf(_D005_CAR_J.SETUMON_20)}")
        sbSQL.Append($" ,'{_D005_CAR_J.SETUMON_21}' AS {NameOf(_D005_CAR_J.SETUMON_21)}")
        sbSQL.Append($" ,'{_D005_CAR_J.SETUMON_22}' AS {NameOf(_D005_CAR_J.SETUMON_22)}")
        sbSQL.Append($" ,'{_D005_CAR_J.SETUMON_23}' AS {NameOf(_D005_CAR_J.SETUMON_23)}")
        sbSQL.Append($" ,'{_D005_CAR_J.SETUMON_24}' AS {NameOf(_D005_CAR_J.SETUMON_24)}")
        sbSQL.Append($" ,'{_D005_CAR_J.SETUMON_25}' AS {NameOf(_D005_CAR_J.SETUMON_25)}")

        sbSQL.Append($" ,'{_D005_CAR_J.KAITO_1}' AS {NameOf(_D005_CAR_J.KAITO_1)}")
        sbSQL.Append($" ,'{_D005_CAR_J.KAITO_2}' AS {NameOf(_D005_CAR_J.KAITO_2)}")
        sbSQL.Append($" ,'{_D005_CAR_J.KAITO_3}' AS {NameOf(_D005_CAR_J.KAITO_3)}")
        sbSQL.Append($" ,'{_D005_CAR_J.KAITO_4}' AS {NameOf(_D005_CAR_J.KAITO_4)}")
        sbSQL.Append($" ,{_D005_CAR_J.KAITO_5} AS {NameOf(_D005_CAR_J.KAITO_5)}")
        sbSQL.Append($" ,'{_D005_CAR_J.KAITO_6}' AS {NameOf(_D005_CAR_J.KAITO_6)}")
        sbSQL.Append($" ,'{_D005_CAR_J.KAITO_7}' AS {NameOf(_D005_CAR_J.KAITO_7)}")
        sbSQL.Append($" ,'{_D005_CAR_J.KAITO_8}' AS {NameOf(_D005_CAR_J.KAITO_8)}")
        sbSQL.Append($" ,'{_D005_CAR_J.KAITO_9}' AS {NameOf(_D005_CAR_J.KAITO_9)}")
        sbSQL.Append($" ,{_D005_CAR_J.KAITO_10} AS {NameOf(_D005_CAR_J.KAITO_10)}")
        sbSQL.Append($" ,'{_D005_CAR_J.KAITO_11}' AS {NameOf(_D005_CAR_J.KAITO_11)}")
        sbSQL.Append($" ,'{_D005_CAR_J.KAITO_12}' AS {NameOf(_D005_CAR_J.KAITO_12)}")
        sbSQL.Append($" ,'{_D005_CAR_J.KAITO_13}' AS {NameOf(_D005_CAR_J.KAITO_13)}")
        sbSQL.Append($" ,'{_D005_CAR_J.KAITO_14}' AS {NameOf(_D005_CAR_J.KAITO_14)}")
        sbSQL.Append($" ,'{_D005_CAR_J.KAITO_15}' AS {NameOf(_D005_CAR_J.KAITO_15)}")
        sbSQL.Append($" ,'{_D005_CAR_J.KAITO_16}' AS {NameOf(_D005_CAR_J.KAITO_16)}")
        sbSQL.Append($" ,{_D005_CAR_J.KAITO_17} AS {NameOf(_D005_CAR_J.KAITO_17)}")
        sbSQL.Append($" ,'{_D005_CAR_J.KAITO_18}' AS {NameOf(_D005_CAR_J.KAITO_18)}")
        sbSQL.Append($" ,'{_D005_CAR_J.KAITO_19}' AS {NameOf(_D005_CAR_J.KAITO_19)}")
        sbSQL.Append($" ,'{_D005_CAR_J.KAITO_20}' AS {NameOf(_D005_CAR_J.KAITO_20)}")
        sbSQL.Append($" ,'{_D005_CAR_J.KAITO_21}' AS {NameOf(_D005_CAR_J.KAITO_21)}")
        sbSQL.Append($" ,'{_D005_CAR_J.KAITO_22}' AS {NameOf(_D005_CAR_J.KAITO_22)}")
        sbSQL.Append($" ,'{_D005_CAR_J.KAITO_23}' AS {NameOf(_D005_CAR_J.KAITO_23)}")
        sbSQL.Append($" ,'{_D005_CAR_J.KAITO_24}' AS {NameOf(_D005_CAR_J.KAITO_24)}")
        sbSQL.Append($" ,'{_D005_CAR_J.KAITO_25}' AS {NameOf(_D005_CAR_J.KAITO_25)}")

        sbSQL.Append($" ,'{_D005_CAR_J.KONPON_YOIN_KB1}' AS {NameOf(_D005_CAR_J.KONPON_YOIN_KB1)}")
        sbSQL.Append($" ,'{_D005_CAR_J.KONPON_YOIN_KB2}' AS {NameOf(_D005_CAR_J.KONPON_YOIN_KB2)}")
        sbSQL.Append($" ,{_D005_CAR_J.KONPON_YOIN_SYAIN_ID} AS {NameOf(_D005_CAR_J.KONPON_YOIN_SYAIN_ID)}")
        sbSQL.Append($" ,'{_D005_CAR_J.KISEKI_KOTEI_KB}' AS {NameOf(_D005_CAR_J.KISEKI_KOTEI_KB)}")
        sbSQL.Append($" ,{_D005_CAR_J.SYOCHI_A_SYAIN_ID} AS {NameOf(_D005_CAR_J.SYOCHI_A_SYAIN_ID)}")
        sbSQL.Append($" ,'{_D005_CAR_J.SYOCHI_A_YMDHNS}' AS {NameOf(_D005_CAR_J.SYOCHI_A_YMDHNS)}")
        sbSQL.Append($" ,{_D005_CAR_J.SYOCHI_B_SYAIN_ID} AS {NameOf(_D005_CAR_J.SYOCHI_B_SYAIN_ID)}")
        sbSQL.Append($" ,'{_D005_CAR_J.SYOCHI_B_YMDHNS}' AS {NameOf(_D005_CAR_J.SYOCHI_B_YMDHNS)}")
        sbSQL.Append($" ,{_D005_CAR_J.SYOCHI_C_SYAIN_ID} AS {NameOf(_D005_CAR_J.SYOCHI_C_SYAIN_ID)}")
        sbSQL.Append($" ,'{_D005_CAR_J.SYOCHI_C_YMDHNS}' AS {NameOf(_D005_CAR_J.SYOCHI_C_YMDHNS)}")
        sbSQL.Append($" ,'{_D005_CAR_J.KYOIKU_FILE_PATH}' AS {NameOf(_D005_CAR_J.KYOIKU_FILE_PATH)}")
        sbSQL.Append($" ,'{_D005_CAR_J._ZESEI_SYOCHI_YUKO_UMU}' AS {NameOf(_D005_CAR_J.ZESEI_SYOCHI_YUKO_UMU)}")
        sbSQL.Append($" ,'{_D005_CAR_J.SYOSAI_FILE_PATH}' AS {NameOf(_D005_CAR_J.SYOSAI_FILE_PATH)}")
        sbSQL.Append($" ,'{_D005_CAR_J.GOKI}' AS {NameOf(_D005_CAR_J.GOKI)}")
        sbSQL.Append($" ,'{_D005_CAR_J.LOT}' AS {NameOf(_D005_CAR_J.LOT)}")
        sbSQL.Append($" ,{_D005_CAR_J.KENSA_TANTO_ID} AS {NameOf(_D005_CAR_J.KENSA_TANTO_ID)}")
        sbSQL.Append($" ,'{_D005_CAR_J.KENSA_TOROKU_YMDHNS}' AS {NameOf(_D005_CAR_J.KENSA_TOROKU_YMDHNS)}")
        sbSQL.Append($" ,{_D005_CAR_J.KENSA_GL_SYAIN_ID} AS {NameOf(_D005_CAR_J.KENSA_GL_SYAIN_ID)}")
        sbSQL.Append($" ,'{_D005_CAR_J.KENSA_GL_YMDHNS}' AS {NameOf(_D005_CAR_J.KENSA_GL_YMDHNS)}")
        sbSQL.Append($" ,'{_D005_CAR_J.FILE_PATH1}' AS {NameOf(_D005_CAR_J.FILE_PATH1)}")
        sbSQL.Append($" ,'{_D005_CAR_J.FILE_PATH2}' AS {NameOf(_D005_CAR_J.FILE_PATH2)}")
        sbSQL.Append($" ,'{_D005_CAR_J.FUTEKIGO_HASSEI_YMD}' AS {NameOf(_D005_CAR_J.FUTEKIGO_HASSEI_YMD)}")

        sbSQL.Append($" ,{_D005_CAR_J.ADD_SYAIN_ID} AS {NameOf(_D005_CAR_J.ADD_SYAIN_ID)}")
        sbSQL.Append($" ,'{_D005_CAR_J.ADD_YMDHNS}' AS {NameOf(_D005_CAR_J.ADD_YMDHNS)}")
        sbSQL.Append($" ,{_D005_CAR_J.UPD_SYAIN_ID} AS {NameOf(_D005_CAR_J.UPD_SYAIN_ID)}")
        sbSQL.Append($" ,'{_D005_CAR_J.UPD_YMDHNS}' AS {NameOf(_D005_CAR_J.UPD_YMDHNS)}")
        sbSQL.Append($" ,{_D005_CAR_J.DEL_SYAIN_ID} AS {NameOf(_D005_CAR_J.DEL_SYAIN_ID)}")
        sbSQL.Append($" ,'{_D005_CAR_J.DEL_YMDHNS}' AS {NameOf(_D005_CAR_J.DEL_YMDHNS)}")
        sbSQL.Append($" ) AS WK")
        sbSQL.Append($" ON (SrcT.{NameOf(_D005_CAR_J.HOKOKU_NO)} = WK.{NameOf(_D005_CAR_J.HOKOKU_NO)})")
        'UPDATE
        sbSQL.Append(" WHEN MATCHED THEN")
        sbSQL.Append(" UPDATE SET")

        sbSQL.Append($"  SrcT.{NameOf(_D005_CAR_J.SETUMON_1)} = WK.{NameOf(_D005_CAR_J.SETUMON_1)}")
        sbSQL.Append($" ,SrcT.{NameOf(_D005_CAR_J.SETUMON_2)} = WK.{NameOf(_D005_CAR_J.SETUMON_2)}")
        sbSQL.Append($" ,SrcT.{NameOf(_D005_CAR_J.SETUMON_3)} = WK.{NameOf(_D005_CAR_J.SETUMON_3)}")
        sbSQL.Append($" ,SrcT.{NameOf(_D005_CAR_J.SETUMON_4)} = WK.{NameOf(_D005_CAR_J.SETUMON_4)}")
        sbSQL.Append($" ,SrcT.{NameOf(_D005_CAR_J.SETUMON_5)} = WK.{NameOf(_D005_CAR_J.SETUMON_5)}")
        sbSQL.Append($" ,SrcT.{NameOf(_D005_CAR_J.SETUMON_6)} = WK.{NameOf(_D005_CAR_J.SETUMON_6)}")
        sbSQL.Append($" ,SrcT.{NameOf(_D005_CAR_J.SETUMON_7)} = WK.{NameOf(_D005_CAR_J.SETUMON_7)}")
        sbSQL.Append($" ,SrcT.{NameOf(_D005_CAR_J.SETUMON_8)} = WK.{NameOf(_D005_CAR_J.SETUMON_8)}")
        sbSQL.Append($" ,SrcT.{NameOf(_D005_CAR_J.SETUMON_9)} = WK.{NameOf(_D005_CAR_J.SETUMON_9)}")
        sbSQL.Append($" ,SrcT.{NameOf(_D005_CAR_J.SETUMON_10)} = WK.{NameOf(_D005_CAR_J.SETUMON_10)}")
        sbSQL.Append($" ,SrcT.{NameOf(_D005_CAR_J.SETUMON_11)} = WK.{NameOf(_D005_CAR_J.SETUMON_11)}")
        sbSQL.Append($" ,SrcT.{NameOf(_D005_CAR_J.SETUMON_12)} = WK.{NameOf(_D005_CAR_J.SETUMON_12)}")
        sbSQL.Append($" ,SrcT.{NameOf(_D005_CAR_J.SETUMON_13)} = WK.{NameOf(_D005_CAR_J.SETUMON_13)}")
        sbSQL.Append($" ,SrcT.{NameOf(_D005_CAR_J.SETUMON_14)} = WK.{NameOf(_D005_CAR_J.SETUMON_14)}")
        sbSQL.Append($" ,SrcT.{NameOf(_D005_CAR_J.SETUMON_15)} = WK.{NameOf(_D005_CAR_J.SETUMON_15)}")
        sbSQL.Append($" ,SrcT.{NameOf(_D005_CAR_J.SETUMON_16)} = WK.{NameOf(_D005_CAR_J.SETUMON_16)}")
        sbSQL.Append($" ,SrcT.{NameOf(_D005_CAR_J.SETUMON_17)} = WK.{NameOf(_D005_CAR_J.SETUMON_17)}")
        sbSQL.Append($" ,SrcT.{NameOf(_D005_CAR_J.SETUMON_18)} = WK.{NameOf(_D005_CAR_J.SETUMON_18)}")
        sbSQL.Append($" ,SrcT.{NameOf(_D005_CAR_J.SETUMON_19)} = WK.{NameOf(_D005_CAR_J.SETUMON_19)}")
        sbSQL.Append($" ,SrcT.{NameOf(_D005_CAR_J.SETUMON_20)} = WK.{NameOf(_D005_CAR_J.SETUMON_20)}")

        sbSQL.Append($" ,SrcT.{NameOf(_D005_CAR_J.KAITO_1)} = WK.{NameOf(_D005_CAR_J.KAITO_1)}")
        sbSQL.Append($" ,SrcT.{NameOf(_D005_CAR_J.KAITO_2)} = WK.{NameOf(_D005_CAR_J.KAITO_2)}")
        sbSQL.Append($" ,SrcT.{NameOf(_D005_CAR_J.KAITO_3)} = WK.{NameOf(_D005_CAR_J.KAITO_3)}")
        sbSQL.Append($" ,SrcT.{NameOf(_D005_CAR_J.KAITO_4)} = WK.{NameOf(_D005_CAR_J.KAITO_4)}")
        sbSQL.Append($" ,SrcT.{NameOf(_D005_CAR_J.KAITO_5)} = WK.{NameOf(_D005_CAR_J.KAITO_5)}")
        sbSQL.Append($" ,SrcT.{NameOf(_D005_CAR_J.KAITO_6)} = WK.{NameOf(_D005_CAR_J.KAITO_6)}")
        sbSQL.Append($" ,SrcT.{NameOf(_D005_CAR_J.KAITO_7)} = WK.{NameOf(_D005_CAR_J.KAITO_7)}")
        sbSQL.Append($" ,SrcT.{NameOf(_D005_CAR_J.KAITO_8)} = WK.{NameOf(_D005_CAR_J.KAITO_8)}")
        sbSQL.Append($" ,SrcT.{NameOf(_D005_CAR_J.KAITO_9)} = WK.{NameOf(_D005_CAR_J.KAITO_9)}")
        sbSQL.Append($" ,SrcT.{NameOf(_D005_CAR_J.KAITO_10)} = WK.{NameOf(_D005_CAR_J.KAITO_10)}")
        sbSQL.Append($" ,SrcT.{NameOf(_D005_CAR_J.KAITO_11)} = WK.{NameOf(_D005_CAR_J.KAITO_11)}")
        sbSQL.Append($" ,SrcT.{NameOf(_D005_CAR_J.KAITO_12)} = WK.{NameOf(_D005_CAR_J.KAITO_12)}")
        sbSQL.Append($" ,SrcT.{NameOf(_D005_CAR_J.KAITO_13)} = WK.{NameOf(_D005_CAR_J.KAITO_13)}")
        sbSQL.Append($" ,SrcT.{NameOf(_D005_CAR_J.KAITO_14)} = WK.{NameOf(_D005_CAR_J.KAITO_14)}")
        sbSQL.Append($" ,SrcT.{NameOf(_D005_CAR_J.KAITO_15)} = WK.{NameOf(_D005_CAR_J.KAITO_15)}")
        sbSQL.Append($" ,SrcT.{NameOf(_D005_CAR_J.KAITO_16)} = WK.{NameOf(_D005_CAR_J.KAITO_16)}")
        sbSQL.Append($" ,SrcT.{NameOf(_D005_CAR_J.KAITO_17)} = WK.{NameOf(_D005_CAR_J.KAITO_17)}")
        sbSQL.Append($" ,SrcT.{NameOf(_D005_CAR_J.KAITO_18)} = WK.{NameOf(_D005_CAR_J.KAITO_18)}")
        sbSQL.Append($" ,SrcT.{NameOf(_D005_CAR_J.KAITO_19)} = WK.{NameOf(_D005_CAR_J.KAITO_19)}")
        sbSQL.Append($" ,SrcT.{NameOf(_D005_CAR_J.KAITO_20)} = WK.{NameOf(_D005_CAR_J.KAITO_20)}")

        sbSQL.Append($" , SrcT.{NameOf(_D005_CAR_J.KONPON_YOIN_KB1)} = WK.{NameOf(_D005_CAR_J.KONPON_YOIN_KB1)}")
        sbSQL.Append($" , SrcT.{NameOf(_D005_CAR_J.KONPON_YOIN_KB2)} = WK.{NameOf(_D005_CAR_J.KONPON_YOIN_KB2)}")
        sbSQL.Append($" , SrcT.{NameOf(_D005_CAR_J.KONPON_YOIN_SYAIN_ID)} = WK.{NameOf(_D005_CAR_J.KONPON_YOIN_SYAIN_ID)}")
        sbSQL.Append($" , SrcT.{NameOf(_D005_CAR_J.KISEKI_KOTEI_KB)} = WK.{NameOf(_D005_CAR_J.KISEKI_KOTEI_KB)}")

        sbSQL.Append($" , SrcT.{NameOf(_D005_CAR_J.ADD_SYAIN_ID)} = WK.{NameOf(_D005_CAR_J.ADD_SYAIN_ID)}")
        sbSQL.Append($" , SrcT.{NameOf(_D005_CAR_J.ADD_YMDHNS)} = WK.{NameOf(_D005_CAR_J.ADD_YMDHNS)}")

        sbSQL.Append($" , SrcT.{NameOf(_D005_CAR_J.SYOCHI_A_SYAIN_ID)} = WK.{NameOf(_D005_CAR_J.SYOCHI_A_SYAIN_ID)}")
        sbSQL.Append($" , SrcT.{NameOf(_D005_CAR_J.SYOCHI_A_YMDHNS)} = WK.{NameOf(_D005_CAR_J.SYOCHI_A_YMDHNS)}")
        sbSQL.Append($" , SrcT.{NameOf(_D005_CAR_J.SYOCHI_B_SYAIN_ID)} = WK.{NameOf(_D005_CAR_J.SYOCHI_B_SYAIN_ID)}")
        sbSQL.Append($" , SrcT.{NameOf(_D005_CAR_J.SYOCHI_B_YMDHNS)} = WK.{NameOf(_D005_CAR_J.SYOCHI_B_YMDHNS)}")
        sbSQL.Append($" , SrcT.{NameOf(_D005_CAR_J.SYOCHI_C_SYAIN_ID)} = WK.{NameOf(_D005_CAR_J.SYOCHI_C_SYAIN_ID)}")
        sbSQL.Append($" , SrcT.{NameOf(_D005_CAR_J.SYOCHI_C_YMDHNS)} = WK.{NameOf(_D005_CAR_J.SYOCHI_C_YMDHNS)}")
        sbSQL.Append($" , SrcT.{NameOf(_D005_CAR_J.KYOIKU_FILE_PATH)} = WK.{NameOf(_D005_CAR_J.KYOIKU_FILE_PATH)}")

        sbSQL.Append($" , SrcT.{NameOf(_D005_CAR_J.ZESEI_SYOCHI_YUKO_UMU)} = WK.{NameOf(_D005_CAR_J.ZESEI_SYOCHI_YUKO_UMU)}")
        sbSQL.Append($" , SrcT.{NameOf(_D005_CAR_J.SYOSAI_FILE_PATH)} = WK.{NameOf(_D005_CAR_J.SYOSAI_FILE_PATH)}")
        sbSQL.Append($" , SrcT.{NameOf(_D005_CAR_J.GOKI)} = WK.{NameOf(_D005_CAR_J.GOKI)}")
        sbSQL.Append($" , SrcT.{NameOf(_D005_CAR_J.LOT)} = WK.{NameOf(_D005_CAR_J.LOT)}")
        sbSQL.Append($" , SrcT.{NameOf(_D005_CAR_J.KENSA_TANTO_ID)} = WK.{NameOf(_D005_CAR_J.KENSA_TANTO_ID)}")
        sbSQL.Append($" , SrcT.{NameOf(_D005_CAR_J.KENSA_TOROKU_YMDHNS)} = WK.{NameOf(_D005_CAR_J.KENSA_TOROKU_YMDHNS)}")
        sbSQL.Append($" , SrcT.{NameOf(_D005_CAR_J.KENSA_GL_SYAIN_ID)} = WK.{NameOf(_D005_CAR_J.KENSA_GL_SYAIN_ID)}")
        sbSQL.Append($" , SrcT.{NameOf(_D005_CAR_J.KENSA_GL_YMDHNS)} = WK.{NameOf(_D005_CAR_J.KENSA_GL_YMDHNS)}")

        sbSQL.Append($" , SrcT.{NameOf(_D005_CAR_J.FILE_PATH1)} = WK.{NameOf(_D005_CAR_J.FILE_PATH1)}")
        sbSQL.Append($" , SrcT.{NameOf(_D005_CAR_J.FILE_PATH2)} = WK.{NameOf(_D005_CAR_J.FILE_PATH2)}")
        sbSQL.Append($" , SrcT.{NameOf(_D005_CAR_J.FUTEKIGO_HASSEI_YMD)} = WK.{NameOf(_D005_CAR_J.FUTEKIGO_HASSEI_YMD)}")

        sbSQL.Append($" , SrcT.{NameOf(_D005_CAR_J.UPD_SYAIN_ID)} = WK.{NameOf(_D005_CAR_J.UPD_SYAIN_ID)}")
        sbSQL.Append($" , SrcT.{NameOf(_D005_CAR_J.UPD_YMDHNS)} = WK.{NameOf(_D005_CAR_J.UPD_YMDHNS)}")
        sbSQL.Append($" , SrcT.{NameOf(_D005_CAR_J.CLOSE_FG)} = WK.{NameOf(_D005_CAR_J.CLOSE_FG)}")

        'INSERT
        sbSQL.Append(" WHEN NOT MATCHED THEN ")
        sbSQL.Append("INSERT(")
        sbSQL.Append("  " & NameOf(_D005_CAR_J.HOKOKU_NO))
        sbSQL.Append(" ," & NameOf(_D005_CAR_J.BUMON_KB))
        sbSQL.Append(" ," & NameOf(_D005_CAR_J.CLOSE_FG))
        sbSQL.Append(" ," & NameOf(_D005_CAR_J.SETUMON_1))
        sbSQL.Append(" ," & NameOf(_D005_CAR_J.SETUMON_2))
        sbSQL.Append(" ," & NameOf(_D005_CAR_J.SETUMON_3))
        sbSQL.Append(" ," & NameOf(_D005_CAR_J.SETUMON_4))
        sbSQL.Append(" ," & NameOf(_D005_CAR_J.SETUMON_5))
        sbSQL.Append(" ," & NameOf(_D005_CAR_J.SETUMON_6))
        sbSQL.Append(" ," & NameOf(_D005_CAR_J.SETUMON_7))
        sbSQL.Append(" ," & NameOf(_D005_CAR_J.SETUMON_8))
        sbSQL.Append(" ," & NameOf(_D005_CAR_J.SETUMON_9))
        sbSQL.Append(" ," & NameOf(_D005_CAR_J.SETUMON_10))
        sbSQL.Append(" ," & NameOf(_D005_CAR_J.SETUMON_11))
        sbSQL.Append(" ," & NameOf(_D005_CAR_J.SETUMON_12))
        sbSQL.Append(" ," & NameOf(_D005_CAR_J.SETUMON_13))
        sbSQL.Append(" ," & NameOf(_D005_CAR_J.SETUMON_14))
        sbSQL.Append(" ," & NameOf(_D005_CAR_J.SETUMON_15))
        sbSQL.Append(" ," & NameOf(_D005_CAR_J.SETUMON_16))
        sbSQL.Append(" ," & NameOf(_D005_CAR_J.SETUMON_17))
        sbSQL.Append(" ," & NameOf(_D005_CAR_J.SETUMON_18))
        sbSQL.Append(" ," & NameOf(_D005_CAR_J.SETUMON_19))
        sbSQL.Append(" ," & NameOf(_D005_CAR_J.SETUMON_20))
        sbSQL.Append(" ," & NameOf(_D005_CAR_J.SETUMON_21))
        sbSQL.Append(" ," & NameOf(_D005_CAR_J.SETUMON_22))
        sbSQL.Append(" ," & NameOf(_D005_CAR_J.SETUMON_23))
        sbSQL.Append(" ," & NameOf(_D005_CAR_J.SETUMON_24))
        sbSQL.Append(" ," & NameOf(_D005_CAR_J.SETUMON_25))
        sbSQL.Append(" ," & NameOf(_D005_CAR_J.KAITO_1))
        sbSQL.Append(" ," & NameOf(_D005_CAR_J.KAITO_2))
        sbSQL.Append(" ," & NameOf(_D005_CAR_J.KAITO_3))
        sbSQL.Append(" ," & NameOf(_D005_CAR_J.KAITO_4))
        sbSQL.Append(" ," & NameOf(_D005_CAR_J.KAITO_5))
        sbSQL.Append(" ," & NameOf(_D005_CAR_J.KAITO_6))
        sbSQL.Append(" ," & NameOf(_D005_CAR_J.KAITO_7))
        sbSQL.Append(" ," & NameOf(_D005_CAR_J.KAITO_8))
        sbSQL.Append(" ," & NameOf(_D005_CAR_J.KAITO_9))
        sbSQL.Append(" ," & NameOf(_D005_CAR_J.KAITO_10))
        sbSQL.Append(" ," & NameOf(_D005_CAR_J.KAITO_11))
        sbSQL.Append(" ," & NameOf(_D005_CAR_J.KAITO_12))
        sbSQL.Append(" ," & NameOf(_D005_CAR_J.KAITO_13))
        sbSQL.Append(" ," & NameOf(_D005_CAR_J.KAITO_14))
        sbSQL.Append(" ," & NameOf(_D005_CAR_J.KAITO_15))
        sbSQL.Append(" ," & NameOf(_D005_CAR_J.KAITO_16))
        sbSQL.Append(" ," & NameOf(_D005_CAR_J.KAITO_17))
        sbSQL.Append(" ," & NameOf(_D005_CAR_J.KAITO_18))
        sbSQL.Append(" ," & NameOf(_D005_CAR_J.KAITO_19))
        sbSQL.Append(" ," & NameOf(_D005_CAR_J.KAITO_20))
        sbSQL.Append(" ," & NameOf(_D005_CAR_J.KAITO_21))
        sbSQL.Append(" ," & NameOf(_D005_CAR_J.KAITO_22))
        sbSQL.Append(" ," & NameOf(_D005_CAR_J.KAITO_23))
        sbSQL.Append(" ," & NameOf(_D005_CAR_J.KAITO_24))
        sbSQL.Append(" ," & NameOf(_D005_CAR_J.KAITO_25))
        sbSQL.Append(" ," & NameOf(_D005_CAR_J.KONPON_YOIN_KB1))
        sbSQL.Append(" ," & NameOf(_D005_CAR_J.KONPON_YOIN_KB2))
        sbSQL.Append(" ," & NameOf(_D005_CAR_J.KONPON_YOIN_SYAIN_ID))
        sbSQL.Append(" ," & NameOf(_D005_CAR_J.KISEKI_KOTEI_KB))
        sbSQL.Append(" ," & NameOf(_D005_CAR_J.SYOCHI_A_SYAIN_ID))
        sbSQL.Append(" ," & NameOf(_D005_CAR_J.SYOCHI_A_YMDHNS))
        sbSQL.Append(" ," & NameOf(_D005_CAR_J.SYOCHI_B_SYAIN_ID))
        sbSQL.Append(" ," & NameOf(_D005_CAR_J.SYOCHI_B_YMDHNS))
        sbSQL.Append(" ," & NameOf(_D005_CAR_J.SYOCHI_C_SYAIN_ID))
        sbSQL.Append(" ," & NameOf(_D005_CAR_J.SYOCHI_C_YMDHNS))
        sbSQL.Append(" ," & NameOf(_D005_CAR_J.KYOIKU_FILE_PATH))
        sbSQL.Append(" ," & NameOf(_D005_CAR_J.ZESEI_SYOCHI_YUKO_UMU))
        sbSQL.Append(" ," & NameOf(_D005_CAR_J.SYOSAI_FILE_PATH))
        sbSQL.Append(" ," & NameOf(_D005_CAR_J.GOKI))
        sbSQL.Append(" ," & NameOf(_D005_CAR_J.LOT))
        sbSQL.Append(" ," & NameOf(_D005_CAR_J.KENSA_TANTO_ID))
        sbSQL.Append(" ," & NameOf(_D005_CAR_J.KENSA_TOROKU_YMDHNS))
        sbSQL.Append(" ," & NameOf(_D005_CAR_J.KENSA_GL_SYAIN_ID))
        sbSQL.Append(" ," & NameOf(_D005_CAR_J.KENSA_GL_YMDHNS))
        sbSQL.Append(" ," & NameOf(_D005_CAR_J.ADD_SYAIN_ID))
        sbSQL.Append(" ," & NameOf(_D005_CAR_J.ADD_YMDHNS))
        sbSQL.Append(" ," & NameOf(_D005_CAR_J.UPD_SYAIN_ID))
        sbSQL.Append(" ," & NameOf(_D005_CAR_J.UPD_YMDHNS))
        sbSQL.Append(" ," & NameOf(_D005_CAR_J.DEL_SYAIN_ID))
        sbSQL.Append(" ," & NameOf(_D005_CAR_J.DEL_YMDHNS))
        sbSQL.Append(" ," & NameOf(_D005_CAR_J.FILE_PATH1))
        sbSQL.Append(" ," & NameOf(_D005_CAR_J.FILE_PATH2))
        sbSQL.Append(" ," & NameOf(_D005_CAR_J.FUTEKIGO_HASSEI_YMD))
        sbSQL.Append(" ) VALUES(")
        sbSQL.Append(" '" & _D005_CAR_J.HOKOKU_NO & "'")
        sbSQL.Append(" ,'" & _D005_CAR_J.BUMON_KB & "'")
        sbSQL.Append(" ,'" & _D005_CAR_J._CLOSE_FG & "'")
        sbSQL.Append(" ,'" & _D005_CAR_J.SETUMON_1 & "'")
        sbSQL.Append(" ,'" & _D005_CAR_J.SETUMON_2 & "'")
        sbSQL.Append(" ,'" & _D005_CAR_J.SETUMON_3 & "'")
        sbSQL.Append(" ,'" & _D005_CAR_J.SETUMON_4 & "'")
        sbSQL.Append(" ,'" & _D005_CAR_J.SETUMON_5 & "'")
        sbSQL.Append(" ,'" & _D005_CAR_J.SETUMON_6 & "'")
        sbSQL.Append(" ,'" & _D005_CAR_J.SETUMON_7 & "'")
        sbSQL.Append(" ,'" & _D005_CAR_J.SETUMON_8 & "'")
        sbSQL.Append(" ,'" & _D005_CAR_J.SETUMON_9 & "'")
        sbSQL.Append(" ,'" & _D005_CAR_J.SETUMON_10 & "'")
        sbSQL.Append(" ,'" & _D005_CAR_J.SETUMON_11 & "'")
        sbSQL.Append(" ,'" & _D005_CAR_J.SETUMON_12 & "'")
        sbSQL.Append(" ,'" & _D005_CAR_J.SETUMON_13 & "'")
        sbSQL.Append(" ,'" & _D005_CAR_J.SETUMON_14 & "'")
        sbSQL.Append(" ,'" & _D005_CAR_J.SETUMON_15 & "'")
        sbSQL.Append(" ,'" & _D005_CAR_J.SETUMON_16 & "'")
        sbSQL.Append(" ,'" & _D005_CAR_J.SETUMON_17 & "'")
        sbSQL.Append(" ,'" & _D005_CAR_J.SETUMON_18 & "'")
        sbSQL.Append(" ,'" & _D005_CAR_J.SETUMON_19 & "'")
        sbSQL.Append(" ,'" & _D005_CAR_J.SETUMON_20 & "'")
        sbSQL.Append(" ,'" & _D005_CAR_J.SETUMON_21 & "'")
        sbSQL.Append(" ,'" & _D005_CAR_J.SETUMON_22 & "'")
        sbSQL.Append(" ,'" & _D005_CAR_J.SETUMON_23 & "'")
        sbSQL.Append(" ,'" & _D005_CAR_J.SETUMON_24 & "'")
        sbSQL.Append(" ,'" & _D005_CAR_J.SETUMON_25 & "'")
        sbSQL.Append(" ,'" & _D005_CAR_J.KAITO_1 & "'")
        sbSQL.Append(" ,'" & _D005_CAR_J.KAITO_2 & "'")
        sbSQL.Append(" ,'" & _D005_CAR_J.KAITO_3 & "'")
        sbSQL.Append(" ,'" & _D005_CAR_J.KAITO_4 & "'")
        sbSQL.Append(" ,'" & _D005_CAR_J.KAITO_5 & "'")
        sbSQL.Append(" ,'" & _D005_CAR_J.KAITO_6 & "'")
        sbSQL.Append(" ,'" & _D005_CAR_J.KAITO_7 & "'")
        sbSQL.Append(" ,'" & _D005_CAR_J.KAITO_8 & "'")
        sbSQL.Append(" ,'" & _D005_CAR_J.KAITO_9 & "'")
        sbSQL.Append(" ,'" & _D005_CAR_J.KAITO_10 & "'")
        sbSQL.Append(" ,'" & _D005_CAR_J.KAITO_11 & "'")
        sbSQL.Append(" ,'" & _D005_CAR_J.KAITO_12 & "'")
        sbSQL.Append(" ,'" & _D005_CAR_J.KAITO_13 & "'")
        sbSQL.Append(" ,'" & _D005_CAR_J.KAITO_14 & "'")
        sbSQL.Append(" ,'" & _D005_CAR_J.KAITO_15 & "'")
        sbSQL.Append(" ,'" & _D005_CAR_J.KAITO_16 & "'")
        sbSQL.Append(" ,'" & _D005_CAR_J.KAITO_17 & "'")
        sbSQL.Append(" ,'" & _D005_CAR_J.KAITO_18 & "'")
        sbSQL.Append(" ,'" & _D005_CAR_J.KAITO_19 & "'")
        sbSQL.Append(" ,'" & _D005_CAR_J.KAITO_20 & "'")
        sbSQL.Append(" ,'" & _D005_CAR_J.KAITO_21 & "'")
        sbSQL.Append(" ,'" & _D005_CAR_J.KAITO_22 & "'")
        sbSQL.Append(" ,'" & _D005_CAR_J.KAITO_23 & "'")
        sbSQL.Append(" ,'" & _D005_CAR_J.KAITO_24 & "'")
        sbSQL.Append(" ,'" & _D005_CAR_J.KAITO_25 & "'")
        sbSQL.Append(" ,'" & _D005_CAR_J.KONPON_YOIN_KB1 & "'")
        sbSQL.Append(" ,'" & _D005_CAR_J.KONPON_YOIN_KB2 & "'")
        sbSQL.Append(" ," & _D005_CAR_J.KONPON_YOIN_SYAIN_ID & "")
        sbSQL.Append(" ,'" & _D005_CAR_J.KISEKI_KOTEI_KB & "'")
        sbSQL.Append(" ," & _D005_CAR_J.SYOCHI_A_SYAIN_ID & "")
        sbSQL.Append(" ,'" & _D005_CAR_J.SYOCHI_A_YMDHNS & "'")
        sbSQL.Append(" ," & _D005_CAR_J.SYOCHI_B_SYAIN_ID & "")
        sbSQL.Append(" ,'" & _D005_CAR_J.SYOCHI_B_YMDHNS & "'")
        sbSQL.Append(" ," & _D005_CAR_J.SYOCHI_C_SYAIN_ID & "")
        sbSQL.Append(" ,'" & _D005_CAR_J.SYOCHI_C_YMDHNS & "'")
        sbSQL.Append(" ,'" & _D005_CAR_J.KYOIKU_FILE_PATH & "'")
        sbSQL.Append(" ,'" & _D005_CAR_J._ZESEI_SYOCHI_YUKO_UMU & "'")
        sbSQL.Append(" ,'" & _D005_CAR_J.SYOSAI_FILE_PATH & "'")
        sbSQL.Append(" ,'" & _D005_CAR_J.GOKI & "'")
        sbSQL.Append(" ,'" & _D005_CAR_J.LOT & "'")
        sbSQL.Append(" ," & _D005_CAR_J.KENSA_TANTO_ID & "")
        sbSQL.Append(" ,'" & _D005_CAR_J.KENSA_TOROKU_YMDHNS & "'")
        sbSQL.Append(" ," & _D005_CAR_J.KENSA_GL_SYAIN_ID & "")
        sbSQL.Append(" ,'" & _D005_CAR_J.KENSA_GL_YMDHNS & "'")
        sbSQL.Append(" ," & _D005_CAR_J.ADD_SYAIN_ID & "")
        sbSQL.Append(" ,'" & _D005_CAR_J.ADD_YMDHNS & "'")
        sbSQL.Append(" ," & _D005_CAR_J.UPD_SYAIN_ID & "")
        sbSQL.Append(" ,'" & _D005_CAR_J.UPD_YMDHNS & "'")
        sbSQL.Append(" ," & _D005_CAR_J.DEL_SYAIN_ID & "")
        sbSQL.Append(" ,'" & _D005_CAR_J.DEL_YMDHNS & "'")
        sbSQL.Append(" ,'" & _D005_CAR_J.FILE_PATH1 & "'")
        sbSQL.Append(" ,'" & _D005_CAR_J.FILE_PATH2 & "'")
        sbSQL.Append(" ,'" & _D005_CAR_J.FUTEKIGO_HASSEI_YMD & "'")
        sbSQL.Append(")")
        sbSQL.Append("OUTPUT $action AS RESULT")
        sbSQL.Append(";")
        strRET = DB.ExecuteScalar(sbSQL.ToString, conblnNonMsg, sqlEx)

        Dim blnSASIMODOSI As Boolean

        Select Case strRET
            Case "INSERT"

            Case "UPDATE"
                'ステージ40以前まで差し戻しされた場合のみUPDATEで登録内容がリセットされる

                '#73 一度起草済みのＣＡＲはリセットしない
                blnSASIMODOSI = True

            Case Else
                '-----エラーログ出力
                Dim strErrMsg As String = My.Resources.ErrLogSqlExecutionFailure & sbSQL.ToString & "|" & sqlEx.Message
                WL.WriteLogDat(strErrMsg)
                Return False
        End Select

        '----D004
        '-----データモデル更新
        _D004_SYONIN_J_KANRI.SYONIN_HOKOKUSYO_ID = Context.ENM_SYONIN_HOKOKUSYO_ID._2_CAR
        _D004_SYONIN_J_KANRI.HOKOKU_NO = _D003_NCR_J.HOKOKU_NO
        _D004_SYONIN_J_KANRI.SYONIN_JUN = ENM_CAR_STAGE._10_起草入力
        '#53
        _D004_SYONIN_J_KANRI.SYAIN_ID = cmbST04_CAR_TANTO.SelectedValue 'pub_SYAIN_INFO.SYAIN_ID
        _D004_SYONIN_J_KANRI.SYONIN_YMDHNS = ""
        _D004_SYONIN_J_KANRI.SYONIN_HANTEI_KB = ENM_SYONIN_HANTEI_KB._0_未承認
        _D004_SYONIN_J_KANRI.SASIMODOSI_FG = False
        _D004_SYONIN_J_KANRI.RIYU = ""
        _D004_SYONIN_J_KANRI.COMMENT = ""
        _D004_SYONIN_J_KANRI.MAIL_SEND_FG = True
        _D004_SYONIN_J_KANRI.ADD_SYAIN_ID = pub_SYAIN_INFO.SYAIN_ID

        '-----MERGE
        sbSQL.Remove(0, sbSQL.Length)
        sbSQL.Append($"MERGE INTO {NameOf(MODEL.D004_SYONIN_J_KANRI)} AS SrcT")
        sbSQL.Append($" USING (")
        sbSQL.Append($" SELECT")
        sbSQL.Append($" {_D004_SYONIN_J_KANRI.SYONIN_HOKOKUSYO_ID} AS {NameOf(_D004_SYONIN_J_KANRI.SYONIN_HOKOKUSYO_ID)}")
        sbSQL.Append($" ,'{_D004_SYONIN_J_KANRI.HOKOKU_NO}' AS {NameOf(_D004_SYONIN_J_KANRI.HOKOKU_NO)}")
        sbSQL.Append($" ,{_D004_SYONIN_J_KANRI.SYONIN_JUN} AS {NameOf(_D004_SYONIN_J_KANRI.SYONIN_JUN)}")
        sbSQL.Append($" ,'{_D004_SYONIN_J_KANRI.SYAIN_ID}' AS {NameOf(_D004_SYONIN_J_KANRI.SYAIN_ID)}")
        sbSQL.Append($" ,'{_D004_SYONIN_J_KANRI.SYONIN_YMDHNS}' AS {NameOf(_D004_SYONIN_J_KANRI.SYONIN_YMDHNS)}")
        sbSQL.Append($" ,'{_D004_SYONIN_J_KANRI.SYONIN_HANTEI_KB}' AS {NameOf(_D004_SYONIN_J_KANRI.SYONIN_HANTEI_KB)}")
        sbSQL.Append($" ,'{_D004_SYONIN_J_KANRI._SASIMODOSI_FG}' AS {NameOf(_D004_SYONIN_J_KANRI.SASIMODOSI_FG)}")
        sbSQL.Append($" ,'{_D004_SYONIN_J_KANRI.RIYU}' AS {NameOf(_D004_SYONIN_J_KANRI.RIYU)}")
        sbSQL.Append($" ,'{_D004_SYONIN_J_KANRI.COMMENT}' AS {NameOf(_D004_SYONIN_J_KANRI.COMMENT)}")
        sbSQL.Append($" ,'{_D004_SYONIN_J_KANRI._MAIL_SEND_FG}' AS {NameOf(_D004_SYONIN_J_KANRI.MAIL_SEND_FG)}")
        sbSQL.Append($" ,{_D004_SYONIN_J_KANRI.ADD_SYAIN_ID} AS {NameOf(_D004_SYONIN_J_KANRI.ADD_SYAIN_ID)}")
        sbSQL.Append($" ,dbo.GetSysDateString() AS {NameOf(_D004_SYONIN_J_KANRI.ADD_YMDHNS)}")
        sbSQL.Append($" ,{pub_SYAIN_INFO.SYAIN_ID} AS {NameOf(_D004_SYONIN_J_KANRI.UPD_SYAIN_ID)}")
        sbSQL.Append($" ,'{_D004_SYONIN_J_KANRI.UPD_YMDHNS}' AS {NameOf(_D004_SYONIN_J_KANRI.UPD_YMDHNS)}")
        sbSQL.Append($" ) AS WK")
        sbSQL.Append($" ON (SrcT.{NameOf(_D004_SYONIN_J_KANRI.SYONIN_HOKOKUSYO_ID)} = WK.{NameOf(_D004_SYONIN_J_KANRI.SYONIN_HOKOKUSYO_ID)}")
        sbSQL.Append($" AND SrcT.{NameOf(_D004_SYONIN_J_KANRI.HOKOKU_NO)} = WK.{NameOf(_D004_SYONIN_J_KANRI.HOKOKU_NO)}")
        sbSQL.Append($" AND SrcT.{NameOf(_D004_SYONIN_J_KANRI.SYONIN_JUN)} = WK.{NameOf(_D004_SYONIN_J_KANRI.SYONIN_JUN)})")

        If blnSASIMODOSI Then
            sbSQL.Append(" WHEN MATCHED THEN ")
        Else
            'UPDATE 排他制御 更新日時が変更されていない場合のみ
            sbSQL.Append($" WHEN MATCHED AND SrcT.{NameOf(_D004_SYONIN_J_KANRI.UPD_YMDHNS)} = WK.{NameOf(_D004_SYONIN_J_KANRI.UPD_YMDHNS)} THEN ")
        End If
        sbSQL.Append(" UPDATE SET")
        sbSQL.Append($"  SrcT.{NameOf(_D004_SYONIN_J_KANRI.SYAIN_ID)} = WK.{NameOf(_D004_SYONIN_J_KANRI.SYAIN_ID)}")
        sbSQL.Append($" ,SrcT.{NameOf(_D004_SYONIN_J_KANRI.UPD_SYAIN_ID)} = WK.{NameOf(_D004_SYONIN_J_KANRI.UPD_SYAIN_ID)}")
        sbSQL.Append($" ,SrcT.{NameOf(_D004_SYONIN_J_KANRI.COMMENT)} = WK.{NameOf(_D004_SYONIN_J_KANRI.COMMENT)}")
        sbSQL.Append($" ,SrcT.{NameOf(_D004_SYONIN_J_KANRI.UPD_YMDHNS)} = dbo.GetSysDateString()")
        sbSQL.Append($" ,SrcT.{NameOf(_D004_SYONIN_J_KANRI.SASIMODOSI_FG)} = WK.{NameOf(_D004_SYONIN_J_KANRI.SASIMODOSI_FG)}")
        sbSQL.Append($" ,SrcT.{NameOf(_D004_SYONIN_J_KANRI.SYONIN_YMDHNS)} = WK.{NameOf(_D004_SYONIN_J_KANRI.SYONIN_YMDHNS)}")
        sbSQL.Append($" ,SrcT.{NameOf(_D004_SYONIN_J_KANRI.SYONIN_HANTEI_KB)} = WK.{NameOf(_D004_SYONIN_J_KANRI.SYONIN_HANTEI_KB)}")
        sbSQL.Append($" ,SrcT.{NameOf(_D004_SYONIN_J_KANRI.MAIL_SEND_FG)} = WK.{NameOf(_D004_SYONIN_J_KANRI.MAIL_SEND_FG)}")
        sbSQL.Append($" ,SrcT.{NameOf(_D004_SYONIN_J_KANRI.RIYU)} = WK.{NameOf(_D004_SYONIN_J_KANRI.RIYU)}")
        'INSERT
        sbSQL.Append(" WHEN NOT MATCHED THEN ")
        sbSQL.Append(" INSERT(")
        sbSQL.Append("  " & NameOf(_D004_SYONIN_J_KANRI.SYONIN_HOKOKUSYO_ID))
        sbSQL.Append(" ," & NameOf(_D004_SYONIN_J_KANRI.HOKOKU_NO))
        sbSQL.Append(" ," & NameOf(_D004_SYONIN_J_KANRI.SYONIN_JUN))
        sbSQL.Append(" ," & NameOf(_D004_SYONIN_J_KANRI.SYAIN_ID))
        sbSQL.Append(" ," & NameOf(_D004_SYONIN_J_KANRI.SYONIN_YMDHNS))
        sbSQL.Append(" ," & NameOf(_D004_SYONIN_J_KANRI.SYONIN_HANTEI_KB))
        sbSQL.Append(" ," & NameOf(_D004_SYONIN_J_KANRI.SASIMODOSI_FG))
        sbSQL.Append(" ," & NameOf(_D004_SYONIN_J_KANRI.RIYU))
        sbSQL.Append(" ," & NameOf(_D004_SYONIN_J_KANRI.COMMENT))
        sbSQL.Append(" ," & NameOf(_D004_SYONIN_J_KANRI.MAIL_SEND_FG))
        sbSQL.Append(" ," & NameOf(_D004_SYONIN_J_KANRI.ADD_SYAIN_ID))
        sbSQL.Append(" ," & NameOf(_D004_SYONIN_J_KANRI.ADD_YMDHNS))
        sbSQL.Append(" ," & NameOf(_D004_SYONIN_J_KANRI.UPD_SYAIN_ID))
        sbSQL.Append(" ," & NameOf(_D004_SYONIN_J_KANRI.UPD_YMDHNS))
        sbSQL.Append(" ) VALUES(")
        sbSQL.Append("  WK." & NameOf(_D004_SYONIN_J_KANRI.SYONIN_HOKOKUSYO_ID))
        sbSQL.Append(" ,WK." & NameOf(_D004_SYONIN_J_KANRI.HOKOKU_NO))
        sbSQL.Append(" ,WK." & NameOf(_D004_SYONIN_J_KANRI.SYONIN_JUN))
        sbSQL.Append(" ,WK." & NameOf(_D004_SYONIN_J_KANRI.SYAIN_ID))
        sbSQL.Append(" ,WK." & NameOf(_D004_SYONIN_J_KANRI.SYONIN_YMDHNS))
        sbSQL.Append(" ,WK." & NameOf(_D004_SYONIN_J_KANRI.SYONIN_HANTEI_KB))
        sbSQL.Append(" ,WK." & NameOf(_D004_SYONIN_J_KANRI.SASIMODOSI_FG))
        sbSQL.Append(" ,WK." & NameOf(_D004_SYONIN_J_KANRI.RIYU))
        sbSQL.Append(" ,WK." & NameOf(_D004_SYONIN_J_KANRI.COMMENT))
        sbSQL.Append(" ,WK." & NameOf(_D004_SYONIN_J_KANRI.MAIL_SEND_FG))
        sbSQL.Append(" ,WK." & NameOf(_D004_SYONIN_J_KANRI.ADD_SYAIN_ID))
        sbSQL.Append(" ,WK." & NameOf(_D004_SYONIN_J_KANRI.ADD_YMDHNS))
        sbSQL.Append(" ,WK." & NameOf(_D004_SYONIN_J_KANRI.UPD_SYAIN_ID))
        sbSQL.Append(" ,WK." & NameOf(_D004_SYONIN_J_KANRI.UPD_YMDHNS))
        sbSQL.Append(" )")
        sbSQL.Append("OUTPUT $action AS RESULT;")
        strRET = DB.ExecuteScalar(sbSQL.ToString, conblnNonMsg, sqlEx)
        Select Case strRET
            Case "INSERT"

            Case "UPDATE"

            Case Else
                If sqlEx.Source IsNot Nothing Then
                    '-----エラーログ出力
                    Dim strErrMsg As String = My.Resources.ErrLogSqlExecutionFailure & sbSQL.ToString & "|" & sqlEx.Message
                    WL.WriteLogDat(strErrMsg)
                Else
                    '---排他制御
                    Dim strMsg As String
                    strMsg = "既に他の担当者によって変更されているため保存出来ません。" & vbCrLf &
                                "再度登録し直して下さい。"

                    MessageBox.Show(strMsg, "同時更新無効", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                End If

                Return False
        End Select

        Return True
    End Function

#End Region

#Region "   D003再不適合保存"

    ''' <summary>
    ''' NCR再不適合登録
    ''' </summary>
    ''' <param name="DB"></param>
    ''' <returns></returns>
    Private Function FunSAVE_D003_SAI_FUTEKIGO() As Boolean
        Dim sbSQL As New System.Text.StringBuilder
        Dim strRET As String
        Dim sqlEx As New Exception

        _D003_NCR_J.HOKOKU_NO = Val(_D003_NCR_J.HOKOKU_NO) + 1

        '-----MERGE
        sbSQL.Remove(0, sbSQL.Length)
        sbSQL.Append($"MERGE INTO {NameOf(MODEL.D003_NCR_J)} AS SrcT")
        sbSQL.Append($" USING (")
        sbSQL.Append($" SELECT")
        sbSQL.Append($" '{_D003_NCR_J.HOKOKU_NO}' AS {NameOf(_D003_NCR_J.HOKOKU_NO)}")
        sbSQL.Append($" ,'{_D003_NCR_J.BUMON_KB}' AS {NameOf(_D003_NCR_J.BUMON_KB)}")
        sbSQL.Append($" ,'0' AS {NameOf(_D003_NCR_J.CLOSE_FG)}")
        sbSQL.Append($" ,{_D003_NCR_J.KISYU_ID} AS {NameOf(_D003_NCR_J.KISYU_ID)}")
        sbSQL.Append($" ,'{_D003_NCR_J.SYANAI_CD}' AS {NameOf(_D003_NCR_J.SYANAI_CD)}")
        sbSQL.Append($" ,'{_D003_NCR_J.BUHIN_BANGO}' AS {NameOf(_D003_NCR_J.BUHIN_BANGO)}")
        sbSQL.Append($" ,'{_D003_NCR_J.BUHIN_NAME}' AS {NameOf(_D003_NCR_J.BUHIN_NAME)}")
        sbSQL.Append($" ,'{_D003_NCR_J.GOKI}' AS {NameOf(_D003_NCR_J.GOKI)}")
        sbSQL.Append($" ,{_D003_NCR_J.SURYO} AS {NameOf(_D003_NCR_J.SURYO)}")
        sbSQL.Append($" ,'{_D003_NCR_J._SAIHATU}' AS {NameOf(_D003_NCR_J.SAIHATU)}")
        sbSQL.Append($" ,'{_D003_NCR_J.FUTEKIGO_JYOTAI_KB}' AS {NameOf(_D003_NCR_J.FUTEKIGO_JYOTAI_KB)}")
        sbSQL.Append($" ,'{_D003_NCR_J.FUTEKIGO_NAIYO}' AS {NameOf(_D003_NCR_J.FUTEKIGO_NAIYO)}")
        sbSQL.Append($" ,'{_D003_NCR_J.FUTEKIGO_KB}' AS {NameOf(_D003_NCR_J.FUTEKIGO_KB)}")
        sbSQL.Append($" ,'{_D003_NCR_J.FUTEKIGO_S_KB}' AS {NameOf(_D003_NCR_J.FUTEKIGO_S_KB)}")
        sbSQL.Append($" ,'{_D003_NCR_J.ZUMEN_KIKAKU}' AS {NameOf(_D003_NCR_J.ZUMEN_KIKAKU)}")

        sbSQL.Append($" ,'' AS {NameOf(_D003_NCR_J.YOKYU_NAIYO)}")
        sbSQL.Append($" ,'' AS {NameOf(_D003_NCR_J.KANSATU_KEKKA)}")
        sbSQL.Append($" ,'0' AS {NameOf(_D003_NCR_J.ZESEI_SYOCHI_YOHI_KB)}")
        sbSQL.Append($" ,'' AS {NameOf(_D003_NCR_J.ZESEI_NASI_RIYU)}")
        sbSQL.Append($" ,'' AS {NameOf(_D003_NCR_J.JIZEN_SINSA_HANTEI_KB)}")
        sbSQL.Append($" , 0 AS {NameOf(_D003_NCR_J.JIZEN_SINSA_SYAIN_ID)}")

        sbSQL.Append($" ,'' AS {NameOf(_D003_NCR_J.JIZEN_SINSA_YMD)}")
        sbSQL.Append($" , 0 AS {NameOf(_D003_NCR_J.SAISIN_KAKUNIN_SYAIN_ID)}")
        sbSQL.Append($" ,'' AS {NameOf(_D003_NCR_J.SAISIN_KAKUNIN_YMD)}")
        sbSQL.Append($" ,'' AS {NameOf(_D003_NCR_J.SAISIN_IINKAI_HANTEI_KB)}")
        sbSQL.Append($" , 0 AS {NameOf(_D003_NCR_J.SAISIN_GIJYUTU_SYAIN_ID)}")
        sbSQL.Append($" ,'' AS {NameOf(_D003_NCR_J.SAISIN_GIJYUTU_YMD)}")
        sbSQL.Append($" , 0 AS {NameOf(_D003_NCR_J.SAISIN_HINSYO_SYAIN_ID)}")
        sbSQL.Append($" ,'' AS {NameOf(_D003_NCR_J.SAISIN_HINSYO_YMD)}")
        sbSQL.Append($" ,'' AS {NameOf(_D003_NCR_J.SAISIN_IINKAI_SIRYO_NO)}")
        sbSQL.Append($" ,'' AS {NameOf(_D003_NCR_J.ITAG_NO)}")
        sbSQL.Append($" , 0 AS {NameOf(_D003_NCR_J.KOKYAKU_SAISIN_TANTO_ID)}")
        sbSQL.Append($" ,'' AS {NameOf(_D003_NCR_J.KOKYAKU_SAISIN_YMD)}")
        sbSQL.Append($" ,'' AS {NameOf(_D003_NCR_J.KOKYAKU_HANTEI_SIJI_KB)}")
        sbSQL.Append($" ,'' AS {NameOf(_D003_NCR_J.KOKYAKU_HANTEI_SIJI_YMD)}")
        sbSQL.Append($" ,'' AS {NameOf(_D003_NCR_J.KOKYAKU_SAISYU_HANTEI_KB)}")
        sbSQL.Append($" ,'' AS {NameOf(_D003_NCR_J.KOKYAKU_SAISYU_HANTEI_YMD)}")
        sbSQL.Append($" ,'0' AS {NameOf(_D003_NCR_J.SAIKAKO_SIJI_FG)}")
        sbSQL.Append($" ,'' AS {NameOf(_D003_NCR_J.HAIKYAKU_YMD)}")
        sbSQL.Append($" ,'' AS {NameOf(_D003_NCR_J.HAIKYAKU_KB)}")
        sbSQL.Append($" ,'' AS {NameOf(_D003_NCR_J.HAIKYAKU_HOUHOU)}")
        sbSQL.Append($" , 0 AS {NameOf(_D003_NCR_J.HAIKYAKU_TANTO_ID)}")
        sbSQL.Append($" ,'' AS {NameOf(_D003_NCR_J.SAIKAKO_SIJI_NO)}")
        sbSQL.Append($" ,'' AS {NameOf(_D003_NCR_J.SAIKAKO_SAGYO_KAN_YMD)}")
        sbSQL.Append($" ,'' AS {NameOf(_D003_NCR_J.SAIKAKO_KENSA_YMD)}")
        sbSQL.Append($" ,'' AS {NameOf(_D003_NCR_J.KENSA_KEKKA_KB)}")
        sbSQL.Append($" , 0 AS {NameOf(_D003_NCR_J.SEIGI_TANTO_ID)}")
        sbSQL.Append($" , 0 As {NameOf(_D003_NCR_J.SEIZO_TANTO_ID)}")
        sbSQL.Append($" , 0 As {NameOf(_D003_NCR_J.KENSA_TANTO_ID)}")
        sbSQL.Append($" ,'' AS {NameOf(_D003_NCR_J.HENKYAKU_YMD)}")
        sbSQL.Append($" ,'' AS {NameOf(_D003_NCR_J.HENKYAKU_SAKI)}")
        sbSQL.Append($" , 0 AS {NameOf(_D003_NCR_J.HENKYAKU_TANTO_ID)}")
        sbSQL.Append($" ,'' AS {NameOf(_D003_NCR_J.HENKYAKU_BIKO)}")
        sbSQL.Append($" , 0 AS {NameOf(_D003_NCR_J.TENYO_KISYU_ID)}")
        sbSQL.Append($" ,'' AS {NameOf(_D003_NCR_J.TENYO_BUHIN_BANGO)}")
        sbSQL.Append($" ,'' AS {NameOf(_D003_NCR_J.TENYO_GOKI)}")
        sbSQL.Append($" , 0 AS {NameOf(_D003_NCR_J.TENYO_LOT)}")
        sbSQL.Append($" ,'' AS {NameOf(_D003_NCR_J.TENYO_YMD)}")
        sbSQL.Append($" ,'0' AS {NameOf(_D003_NCR_J.SYOCHI_KEKKA_A)}")
        sbSQL.Append($" ,'0' AS {NameOf(_D003_NCR_J.SYOCHI_KEKKA_B)}")
        sbSQL.Append($" ,'0' AS {NameOf(_D003_NCR_J.SYOCHI_KEKKA_C)}")
        sbSQL.Append($" ,'0' AS {NameOf(_D003_NCR_J.SYOCHI_D_UMU_KB)}")
        sbSQL.Append($" ,'0' AS {NameOf(_D003_NCR_J.SYOCHI_D_YOHI_KB)}")
        sbSQL.Append($" ,'' AS {NameOf(_D003_NCR_J.SYOCHI_D_SYOCHI_KIROKU)}")
        sbSQL.Append($" ,'0' AS {NameOf(_D003_NCR_J.SYOCHI_E_UMU_KB)}")
        sbSQL.Append($" ,'0' AS {NameOf(_D003_NCR_J.SYOCHI_E_YOHI_KB)}")
        sbSQL.Append($" ,'' AS {NameOf(_D003_NCR_J.SYOCHI_E_SYOCHI_KIROKU)}")
        sbSQL.Append($" ,'' AS {NameOf(_D003_NCR_J.FILE_PATH)}")
        sbSQL.Append($" ,'' AS {NameOf(_D003_NCR_J.G_FILE_PATH1)}")
        sbSQL.Append($" ,'' AS {NameOf(_D003_NCR_J.G_FILE_PATH2)}")
        sbSQL.Append($" , 0 AS {NameOf(_D003_NCR_J.HASSEI_KOTEI_GL_SYAIN_ID)}")
        sbSQL.Append($" ,'' AS {NameOf(_D003_NCR_J.HASSEI_YMD)}")

        sbSQL.Append($" ,{pub_SYAIN_INFO.SYAIN_ID} AS {NameOf(_D003_NCR_J.ADD_SYAIN_ID)}")
        sbSQL.Append($" ,dbo.GetSysDateString() AS {NameOf(_D003_NCR_J.ADD_YMDHNS)}")
        sbSQL.Append($" , 0 AS {NameOf(_D003_NCR_J.UPD_SYAIN_ID)}")
        sbSQL.Append($" ,'' AS {NameOf(_D003_NCR_J.UPD_YMDHNS)}")
        sbSQL.Append($" ,0 AS {NameOf(_D003_NCR_J.DEL_SYAIN_ID)}")
        sbSQL.Append($" ,' ' AS {NameOf(_D003_NCR_J.DEL_YMDHNS)}")
        sbSQL.Append($" ) AS WK")
        sbSQL.Append($" ON (SrcT.{NameOf(_D003_NCR_J.HOKOKU_NO)} = WK.{NameOf(_D003_NCR_J.HOKOKU_NO)})")

        'UPDATE 排他制御 更新日時が変更されていない場合のみ
        sbSQL.Append($" WHEN MATCHED AND SrcT.{NameOf(_D003_NCR_J.UPD_YMDHNS)} = WK.{NameOf(_D003_NCR_J.UPD_YMDHNS)} THEN ")
        sbSQL.Append($" UPDATE SET")
        sbSQL.Append($"  SrcT.{NameOf(_D003_NCR_J.KISYU_ID)} = WK.{NameOf(_D003_NCR_J.KISYU_ID)}")
        sbSQL.Append($" ,SrcT.{NameOf(_D003_NCR_J.CLOSE_FG)} = WK.{NameOf(_D003_NCR_J.CLOSE_FG)}")
        sbSQL.Append($" ,SrcT.{NameOf(_D003_NCR_J.SYANAI_CD)} = WK.{NameOf(_D003_NCR_J.SYANAI_CD)}")
        sbSQL.Append($" ,SrcT.{NameOf(_D003_NCR_J.BUHIN_BANGO)} = WK.{NameOf(_D003_NCR_J.BUHIN_BANGO)}")
        sbSQL.Append($" ,SrcT.{NameOf(_D003_NCR_J.BUHIN_NAME)} = WK.{NameOf(_D003_NCR_J.BUHIN_NAME)}")
        sbSQL.Append($" ,SrcT.{NameOf(_D003_NCR_J.GOKI)} = WK.{NameOf(_D003_NCR_J.GOKI)}")
        sbSQL.Append($" ,SrcT.{NameOf(_D003_NCR_J.SURYO)} = WK.{NameOf(_D003_NCR_J.SURYO)}")
        sbSQL.Append($" ,SrcT.{NameOf(_D003_NCR_J.SAIHATU)} = WK.{NameOf(_D003_NCR_J.SAIHATU)}")
        sbSQL.Append($" ,SrcT.{NameOf(_D003_NCR_J.FUTEKIGO_JYOTAI_KB)} = WK.{NameOf(_D003_NCR_J.FUTEKIGO_JYOTAI_KB)}")
        sbSQL.Append($" ,SrcT.{NameOf(_D003_NCR_J.FUTEKIGO_NAIYO)} = WK.{NameOf(_D003_NCR_J.FUTEKIGO_NAIYO)}")
        sbSQL.Append($" ,SrcT.{NameOf(_D003_NCR_J.FUTEKIGO_KB)} = WK.{NameOf(_D003_NCR_J.FUTEKIGO_KB)}")
        sbSQL.Append($" ,SrcT.{NameOf(_D003_NCR_J.FUTEKIGO_S_KB)} = WK.{NameOf(_D003_NCR_J.FUTEKIGO_S_KB)}")
        sbSQL.Append($" ,SrcT.{NameOf(_D003_NCR_J.ZUMEN_KIKAKU)} = WK.{NameOf(_D003_NCR_J.ZUMEN_KIKAKU)}")
        sbSQL.Append($" ,SrcT.{NameOf(_D003_NCR_J.YOKYU_NAIYO)} = WK.{NameOf(_D003_NCR_J.YOKYU_NAIYO)}")
        sbSQL.Append($" ,SrcT.{NameOf(_D003_NCR_J.KANSATU_KEKKA)} = WK.{NameOf(_D003_NCR_J.KANSATU_KEKKA)}")

        sbSQL.Append($" ,SrcT.{NameOf(_D003_NCR_J.ZESEI_SYOCHI_YOHI_KB)} = WK.{NameOf(_D003_NCR_J.ZESEI_SYOCHI_YOHI_KB)}")
        sbSQL.Append($" ,SrcT.{NameOf(_D003_NCR_J.ZESEI_NASI_RIYU)} = WK.{NameOf(_D003_NCR_J.ZESEI_NASI_RIYU)}")
        sbSQL.Append($" ,SrcT.{NameOf(_D003_NCR_J.JIZEN_SINSA_HANTEI_KB)} = WK.{NameOf(_D003_NCR_J.JIZEN_SINSA_HANTEI_KB)}")
        sbSQL.Append($" ,SrcT.{NameOf(_D003_NCR_J.JIZEN_SINSA_SYAIN_ID)} = WK.{NameOf(_D003_NCR_J.JIZEN_SINSA_SYAIN_ID)}")
        sbSQL.Append($" ,SrcT.{NameOf(_D003_NCR_J.JIZEN_SINSA_YMD)} = WK.{NameOf(_D003_NCR_J.JIZEN_SINSA_YMD)}")
        sbSQL.Append($" ,SrcT.{NameOf(_D003_NCR_J.SAISIN_KAKUNIN_SYAIN_ID)} = WK.{NameOf(_D003_NCR_J.SAISIN_KAKUNIN_SYAIN_ID)}")
        sbSQL.Append($" ,SrcT.{NameOf(_D003_NCR_J.SAISIN_KAKUNIN_YMD)} = WK.{NameOf(_D003_NCR_J.SAISIN_KAKUNIN_YMD)}")
        sbSQL.Append($" ,SrcT.{NameOf(_D003_NCR_J.SAISIN_IINKAI_HANTEI_KB)} = WK.{NameOf(_D003_NCR_J.SAISIN_IINKAI_HANTEI_KB)}")
        sbSQL.Append($" ,SrcT.{NameOf(_D003_NCR_J.SAISIN_GIJYUTU_SYAIN_ID)} = WK.{NameOf(_D003_NCR_J.SAISIN_GIJYUTU_SYAIN_ID)}")
        sbSQL.Append($" ,SrcT.{NameOf(_D003_NCR_J.SAISIN_GIJYUTU_YMD)} = WK.{NameOf(_D003_NCR_J.SAISIN_GIJYUTU_YMD)}")
        sbSQL.Append($" ,SrcT.{NameOf(_D003_NCR_J.SAISIN_HINSYO_SYAIN_ID)} = WK.{NameOf(_D003_NCR_J.SAISIN_HINSYO_SYAIN_ID)}")
        sbSQL.Append($" ,SrcT.{NameOf(_D003_NCR_J.SAISIN_HINSYO_YMD)} = WK.{NameOf(_D003_NCR_J.SAISIN_HINSYO_YMD)}")
        sbSQL.Append($" ,SrcT.{NameOf(_D003_NCR_J.SAISIN_IINKAI_SIRYO_NO)} = WK.{NameOf(_D003_NCR_J.SAISIN_IINKAI_SIRYO_NO)}")
        sbSQL.Append($" ,SrcT.{NameOf(_D003_NCR_J.ITAG_NO)} = WK.{NameOf(_D003_NCR_J.ITAG_NO)}")
        sbSQL.Append($" ,SrcT.{NameOf(_D003_NCR_J.KOKYAKU_SAISIN_TANTO_ID)} = WK.{NameOf(_D003_NCR_J.KOKYAKU_SAISIN_TANTO_ID)}")
        sbSQL.Append($" ,SrcT.{NameOf(_D003_NCR_J.KOKYAKU_SAISIN_YMD)} = WK.{NameOf(_D003_NCR_J.KOKYAKU_SAISIN_YMD)}")
        sbSQL.Append($" ,SrcT.{NameOf(_D003_NCR_J.KOKYAKU_HANTEI_SIJI_KB)} = WK.{NameOf(_D003_NCR_J.KOKYAKU_HANTEI_SIJI_KB)}")
        sbSQL.Append($" ,SrcT.{NameOf(_D003_NCR_J.KOKYAKU_HANTEI_SIJI_YMD)} = WK.{NameOf(_D003_NCR_J.KOKYAKU_HANTEI_SIJI_YMD)}")
        sbSQL.Append($" ,SrcT.{NameOf(_D003_NCR_J.KOKYAKU_SAISYU_HANTEI_KB)} = WK.{NameOf(_D003_NCR_J.KOKYAKU_SAISYU_HANTEI_KB)}")
        sbSQL.Append($" ,SrcT.{NameOf(_D003_NCR_J.KOKYAKU_SAISYU_HANTEI_YMD)} = WK.{NameOf(_D003_NCR_J.KOKYAKU_SAISYU_HANTEI_YMD)}")
        sbSQL.Append($" ,SrcT.{NameOf(_D003_NCR_J.SAIKAKO_SIJI_FG)} = WK.{NameOf(_D003_NCR_J.SAIKAKO_SIJI_FG)}")
        sbSQL.Append($" ,SrcT.{NameOf(_D003_NCR_J.HAIKYAKU_YMD)} = WK.{NameOf(_D003_NCR_J.HAIKYAKU_YMD)}")
        sbSQL.Append($" ,SrcT.{NameOf(_D003_NCR_J.HAIKYAKU_KB)} = WK.{NameOf(_D003_NCR_J.HAIKYAKU_KB)}")
        sbSQL.Append($" ,SrcT.{NameOf(_D003_NCR_J.HAIKYAKU_HOUHOU)} = WK.{NameOf(_D003_NCR_J.HAIKYAKU_HOUHOU)}")
        sbSQL.Append($" ,SrcT.{NameOf(_D003_NCR_J.HAIKYAKU_TANTO_ID)} = WK.{NameOf(_D003_NCR_J.HAIKYAKU_TANTO_ID)}")
        sbSQL.Append($" ,SrcT.{NameOf(_D003_NCR_J.SAIKAKO_SIJI_NO)} = WK.{NameOf(_D003_NCR_J.SAIKAKO_SIJI_NO)}")
        sbSQL.Append($" ,SrcT.{NameOf(_D003_NCR_J.SAIKAKO_SAGYO_KAN_YMD)} = WK.{NameOf(_D003_NCR_J.SAIKAKO_SAGYO_KAN_YMD)}")
        sbSQL.Append($" ,SrcT.{NameOf(_D003_NCR_J.SAIKAKO_KENSA_YMD)} = WK.{NameOf(_D003_NCR_J.SAIKAKO_KENSA_YMD)}")
        sbSQL.Append($" ,SrcT.{NameOf(_D003_NCR_J.KENSA_KEKKA_KB)} = WK.{NameOf(_D003_NCR_J.KENSA_KEKKA_KB)}")
        sbSQL.Append($" ,SrcT.{NameOf(_D003_NCR_J.SEIGI_TANTO_ID)} = WK.{NameOf(_D003_NCR_J.SEIGI_TANTO_ID)}")
        sbSQL.Append($" ,SrcT.{NameOf(_D003_NCR_J.SEIZO_TANTO_ID)} = WK.{NameOf(_D003_NCR_J.SEIZO_TANTO_ID)}")
        sbSQL.Append($" ,SrcT.{NameOf(_D003_NCR_J.KENSA_TANTO_ID)} = WK.{NameOf(_D003_NCR_J.KENSA_TANTO_ID)}")
        sbSQL.Append($" ,SrcT.{NameOf(_D003_NCR_J.HENKYAKU_YMD)} = WK.{NameOf(_D003_NCR_J.HENKYAKU_YMD)}")
        sbSQL.Append($" ,SrcT.{NameOf(_D003_NCR_J.HENKYAKU_SAKI)} = WK.{NameOf(_D003_NCR_J.HENKYAKU_SAKI)}")
        sbSQL.Append($" ,SrcT.{NameOf(_D003_NCR_J.HENKYAKU_TANTO_ID)} = WK.{NameOf(_D003_NCR_J.HENKYAKU_TANTO_ID)}")
        sbSQL.Append($" ,SrcT.{NameOf(_D003_NCR_J.HENKYAKU_BIKO)} = WK.{NameOf(_D003_NCR_J.HENKYAKU_BIKO)}")
        sbSQL.Append($" ,SrcT.{NameOf(_D003_NCR_J.TENYO_KISYU_ID)} = WK.{NameOf(_D003_NCR_J.TENYO_KISYU_ID)}")
        sbSQL.Append($" ,SrcT.{NameOf(_D003_NCR_J.TENYO_BUHIN_BANGO)} = WK.{NameOf(_D003_NCR_J.TENYO_BUHIN_BANGO)}")
        sbSQL.Append($" ,SrcT.{NameOf(_D003_NCR_J.TENYO_GOKI)} = WK.{NameOf(_D003_NCR_J.TENYO_GOKI)}")
        sbSQL.Append($" ,SrcT.{NameOf(_D003_NCR_J.TENYO_LOT)} = WK.{NameOf(_D003_NCR_J.TENYO_LOT)}")
        sbSQL.Append($" ,SrcT.{NameOf(_D003_NCR_J.TENYO_YMD)} = WK.{NameOf(_D003_NCR_J.TENYO_YMD)}")
        sbSQL.Append($" ,SrcT.{NameOf(_D003_NCR_J.SYOCHI_KEKKA_A)} = WK.{NameOf(_D003_NCR_J.SYOCHI_KEKKA_A)}")
        sbSQL.Append($" ,SrcT.{NameOf(_D003_NCR_J.SYOCHI_KEKKA_B)} = WK.{NameOf(_D003_NCR_J.SYOCHI_KEKKA_B)}")
        sbSQL.Append($" ,SrcT.{NameOf(_D003_NCR_J.SYOCHI_KEKKA_C)} = WK.{NameOf(_D003_NCR_J.SYOCHI_KEKKA_C)}")
        sbSQL.Append($" ,SrcT.{NameOf(_D003_NCR_J.SYOCHI_D_UMU_KB)} = WK.{NameOf(_D003_NCR_J.SYOCHI_D_UMU_KB)}")
        sbSQL.Append($" ,SrcT.{NameOf(_D003_NCR_J.SYOCHI_D_YOHI_KB)} = WK.{NameOf(_D003_NCR_J.SYOCHI_D_YOHI_KB)}")
        sbSQL.Append($" ,SrcT.{NameOf(_D003_NCR_J.SYOCHI_D_SYOCHI_KIROKU)} = WK.{NameOf(_D003_NCR_J.SYOCHI_D_SYOCHI_KIROKU)}")
        sbSQL.Append($" ,SrcT.{NameOf(_D003_NCR_J.SYOCHI_E_UMU_KB)} = WK.{NameOf(_D003_NCR_J.SYOCHI_E_UMU_KB)}")
        sbSQL.Append($" ,SrcT.{NameOf(_D003_NCR_J.SYOCHI_E_YOHI_KB)} = WK.{NameOf(_D003_NCR_J.SYOCHI_E_YOHI_KB)}")
        sbSQL.Append($" ,SrcT.{NameOf(_D003_NCR_J.SYOCHI_E_SYOCHI_KIROKU)} = WK.{NameOf(_D003_NCR_J.SYOCHI_E_SYOCHI_KIROKU)}")

        sbSQL.Append($" ,SrcT.{NameOf(_D003_NCR_J.FILE_PATH)} = WK.{NameOf(_D003_NCR_J.FILE_PATH)}")
        sbSQL.Append($" ,SrcT.{NameOf(_D003_NCR_J.G_FILE_PATH1)} = WK.{NameOf(_D003_NCR_J.G_FILE_PATH1)}")
        sbSQL.Append($" ,SrcT.{NameOf(_D003_NCR_J.G_FILE_PATH2)} = WK.{NameOf(_D003_NCR_J.G_FILE_PATH2)}")
        sbSQL.Append($" ,SrcT.{NameOf(_D003_NCR_J.HASSEI_KOTEI_GL_SYAIN_ID)} = WK.{NameOf(_D003_NCR_J.HASSEI_KOTEI_GL_SYAIN_ID)}")
        sbSQL.Append($" ,SrcT.{NameOf(_D003_NCR_J.HASSEI_YMD)} = WK.{NameOf(_D003_NCR_J.HASSEI_YMD)}")

        sbSQL.Append($" ,SrcT.{NameOf(_D003_NCR_J.UPD_SYAIN_ID)} = {pub_SYAIN_INFO.SYAIN_ID}")
        sbSQL.Append($" ,SrcT.{NameOf(_D003_NCR_J.UPD_YMDHNS)} = dbo.GetSysDateString()")

        'INSERT
        sbSQL.Append(" WHEN NOT MATCHED THEN ")
        sbSQL.Append(" INSERT(")
        sbSQL.Append("  " & NameOf(_D003_NCR_J.HOKOKU_NO))
        sbSQL.Append(" ," & NameOf(_D003_NCR_J.BUMON_KB))
        sbSQL.Append(" ," & NameOf(_D003_NCR_J.CLOSE_FG))
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
        sbSQL.Append(" ," & NameOf(_D003_NCR_J.ZESEI_SYOCHI_YOHI_KB))
        sbSQL.Append(" ," & NameOf(_D003_NCR_J.ZESEI_NASI_RIYU))
        sbSQL.Append(" ," & NameOf(_D003_NCR_J.JIZEN_SINSA_HANTEI_KB))
        sbSQL.Append(" ," & NameOf(_D003_NCR_J.JIZEN_SINSA_SYAIN_ID))
        sbSQL.Append(" ," & NameOf(_D003_NCR_J.JIZEN_SINSA_YMD))
        sbSQL.Append(" ," & NameOf(_D003_NCR_J.SAISIN_KAKUNIN_SYAIN_ID))
        sbSQL.Append(" ," & NameOf(_D003_NCR_J.SAISIN_KAKUNIN_YMD))
        sbSQL.Append(" ," & NameOf(_D003_NCR_J.SAISIN_IINKAI_HANTEI_KB))
        sbSQL.Append(" ," & NameOf(_D003_NCR_J.SAISIN_GIJYUTU_SYAIN_ID))
        sbSQL.Append(" ," & NameOf(_D003_NCR_J.SAISIN_GIJYUTU_YMD))
        sbSQL.Append(" ," & NameOf(_D003_NCR_J.SAISIN_HINSYO_SYAIN_ID))
        sbSQL.Append(" ," & NameOf(_D003_NCR_J.SAISIN_HINSYO_YMD))
        sbSQL.Append(" ," & NameOf(_D003_NCR_J.SAISIN_IINKAI_SIRYO_NO))
        sbSQL.Append(" ," & NameOf(_D003_NCR_J.ITAG_NO))
        sbSQL.Append(" ," & NameOf(_D003_NCR_J.KOKYAKU_SAISIN_TANTO_ID))
        sbSQL.Append(" ," & NameOf(_D003_NCR_J.KOKYAKU_SAISIN_YMD))
        sbSQL.Append(" ," & NameOf(_D003_NCR_J.KOKYAKU_HANTEI_SIJI_KB))
        sbSQL.Append(" ," & NameOf(_D003_NCR_J.KOKYAKU_HANTEI_SIJI_YMD))
        sbSQL.Append(" ," & NameOf(_D003_NCR_J.KOKYAKU_SAISYU_HANTEI_KB))
        sbSQL.Append(" ," & NameOf(_D003_NCR_J.KOKYAKU_SAISYU_HANTEI_YMD))
        sbSQL.Append(" ," & NameOf(_D003_NCR_J.SAIKAKO_SIJI_FG))
        sbSQL.Append(" ," & NameOf(_D003_NCR_J.HAIKYAKU_YMD))
        sbSQL.Append(" ," & NameOf(_D003_NCR_J.HAIKYAKU_KB))
        sbSQL.Append(" ," & NameOf(_D003_NCR_J.HAIKYAKU_HOUHOU))
        sbSQL.Append(" ," & NameOf(_D003_NCR_J.HAIKYAKU_TANTO_ID))
        sbSQL.Append(" ," & NameOf(_D003_NCR_J.SAIKAKO_SIJI_NO))
        sbSQL.Append(" ," & NameOf(_D003_NCR_J.SAIKAKO_SAGYO_KAN_YMD))
        sbSQL.Append(" ," & NameOf(_D003_NCR_J.SAIKAKO_KENSA_YMD))
        sbSQL.Append(" ," & NameOf(_D003_NCR_J.KENSA_KEKKA_KB))
        sbSQL.Append(" ," & NameOf(_D003_NCR_J.SEIGI_TANTO_ID))
        sbSQL.Append(" ," & NameOf(_D003_NCR_J.SEIZO_TANTO_ID))
        sbSQL.Append(" ," & NameOf(_D003_NCR_J.KENSA_TANTO_ID))
        sbSQL.Append(" ," & NameOf(_D003_NCR_J.HENKYAKU_YMD))
        sbSQL.Append(" ," & NameOf(_D003_NCR_J.HENKYAKU_SAKI))
        sbSQL.Append(" ," & NameOf(_D003_NCR_J.HENKYAKU_TANTO_ID))
        sbSQL.Append(" ," & NameOf(_D003_NCR_J.HENKYAKU_BIKO))
        sbSQL.Append(" ," & NameOf(_D003_NCR_J.TENYO_KISYU_ID))
        sbSQL.Append(" ," & NameOf(_D003_NCR_J.TENYO_BUHIN_BANGO))
        sbSQL.Append(" ," & NameOf(_D003_NCR_J.TENYO_GOKI))
        sbSQL.Append(" ," & NameOf(_D003_NCR_J.TENYO_LOT))
        sbSQL.Append(" ," & NameOf(_D003_NCR_J.TENYO_YMD))
        sbSQL.Append(" ," & NameOf(_D003_NCR_J.SYOCHI_KEKKA_A))
        sbSQL.Append(" ," & NameOf(_D003_NCR_J.SYOCHI_KEKKA_B))
        sbSQL.Append(" ," & NameOf(_D003_NCR_J.SYOCHI_KEKKA_C))
        sbSQL.Append(" ," & NameOf(_D003_NCR_J.SYOCHI_D_UMU_KB))
        sbSQL.Append(" ," & NameOf(_D003_NCR_J.SYOCHI_D_YOHI_KB))
        sbSQL.Append(" ," & NameOf(_D003_NCR_J.SYOCHI_D_SYOCHI_KIROKU))
        sbSQL.Append(" ," & NameOf(_D003_NCR_J.SYOCHI_E_UMU_KB))
        sbSQL.Append(" ," & NameOf(_D003_NCR_J.SYOCHI_E_YOHI_KB))
        sbSQL.Append(" ," & NameOf(_D003_NCR_J.SYOCHI_E_SYOCHI_KIROKU))
        sbSQL.Append(" ," & NameOf(_D003_NCR_J.FILE_PATH))
        sbSQL.Append(" ," & NameOf(_D003_NCR_J.G_FILE_PATH1))
        sbSQL.Append(" ," & NameOf(_D003_NCR_J.G_FILE_PATH2))
        sbSQL.Append(" ," & NameOf(_D003_NCR_J.HASSEI_KOTEI_GL_SYAIN_ID))
        sbSQL.Append(" ," & NameOf(_D003_NCR_J.HASSEI_YMD))
        sbSQL.Append(" ," & NameOf(_D003_NCR_J.ADD_SYAIN_ID))
        sbSQL.Append(" ," & NameOf(_D003_NCR_J.ADD_YMDHNS))
        sbSQL.Append(" ," & NameOf(_D003_NCR_J.UPD_SYAIN_ID))
        sbSQL.Append(" ," & NameOf(_D003_NCR_J.UPD_YMDHNS))
        sbSQL.Append(" ," & NameOf(_D003_NCR_J.DEL_SYAIN_ID))
        sbSQL.Append(" ," & NameOf(_D003_NCR_J.DEL_YMDHNS))
        sbSQL.Append(" ) VALUES(")
        sbSQL.Append("  WK." & NameOf(_D003_NCR_J.HOKOKU_NO))
        sbSQL.Append(" ,WK." & NameOf(_D003_NCR_J.BUMON_KB))
        sbSQL.Append(" ,WK." & NameOf(_D003_NCR_J.CLOSE_FG))
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
        sbSQL.Append(" ,WK." & NameOf(_D003_NCR_J.ZESEI_SYOCHI_YOHI_KB))
        sbSQL.Append(" ,WK." & NameOf(_D003_NCR_J.ZESEI_NASI_RIYU))
        sbSQL.Append(" ,WK." & NameOf(_D003_NCR_J.JIZEN_SINSA_HANTEI_KB))
        sbSQL.Append(" ,WK." & NameOf(_D003_NCR_J.JIZEN_SINSA_SYAIN_ID))
        sbSQL.Append(" ,WK." & NameOf(_D003_NCR_J.JIZEN_SINSA_YMD))
        sbSQL.Append(" ,WK." & NameOf(_D003_NCR_J.SAISIN_KAKUNIN_SYAIN_ID))
        sbSQL.Append(" ,WK." & NameOf(_D003_NCR_J.SAISIN_KAKUNIN_YMD))
        sbSQL.Append(" ,WK." & NameOf(_D003_NCR_J.SAISIN_IINKAI_HANTEI_KB))
        sbSQL.Append(" ,WK." & NameOf(_D003_NCR_J.SAISIN_GIJYUTU_SYAIN_ID))
        sbSQL.Append(" ,WK." & NameOf(_D003_NCR_J.SAISIN_GIJYUTU_YMD))
        sbSQL.Append(" ,WK." & NameOf(_D003_NCR_J.SAISIN_HINSYO_SYAIN_ID))
        sbSQL.Append(" ,WK." & NameOf(_D003_NCR_J.SAISIN_HINSYO_YMD))
        sbSQL.Append(" ,WK." & NameOf(_D003_NCR_J.SAISIN_IINKAI_SIRYO_NO))
        sbSQL.Append(" ,WK." & NameOf(_D003_NCR_J.ITAG_NO))
        sbSQL.Append(" ,WK." & NameOf(_D003_NCR_J.KOKYAKU_SAISIN_TANTO_ID))
        sbSQL.Append(" ,WK." & NameOf(_D003_NCR_J.KOKYAKU_SAISIN_YMD))
        sbSQL.Append(" ,WK." & NameOf(_D003_NCR_J.KOKYAKU_HANTEI_SIJI_KB))
        sbSQL.Append(" ,WK." & NameOf(_D003_NCR_J.KOKYAKU_HANTEI_SIJI_YMD))
        sbSQL.Append(" ,WK." & NameOf(_D003_NCR_J.KOKYAKU_SAISYU_HANTEI_KB))
        sbSQL.Append(" ,WK." & NameOf(_D003_NCR_J.KOKYAKU_SAISYU_HANTEI_YMD))
        sbSQL.Append(" ,WK." & NameOf(_D003_NCR_J.SAIKAKO_SIJI_FG))
        sbSQL.Append(" ,WK." & NameOf(_D003_NCR_J.HAIKYAKU_YMD))
        sbSQL.Append(" ,WK." & NameOf(_D003_NCR_J.HAIKYAKU_KB))
        sbSQL.Append(" ,WK." & NameOf(_D003_NCR_J.HAIKYAKU_HOUHOU))
        sbSQL.Append(" ,WK." & NameOf(_D003_NCR_J.HAIKYAKU_TANTO_ID))
        sbSQL.Append(" ,WK." & NameOf(_D003_NCR_J.SAIKAKO_SIJI_NO))
        sbSQL.Append(" ,WK." & NameOf(_D003_NCR_J.SAIKAKO_SAGYO_KAN_YMD))
        sbSQL.Append(" ,WK." & NameOf(_D003_NCR_J.SAIKAKO_KENSA_YMD))
        sbSQL.Append(" ,WK." & NameOf(_D003_NCR_J.KENSA_KEKKA_KB))
        sbSQL.Append(" ,WK." & NameOf(_D003_NCR_J.SEIGI_TANTO_ID))
        sbSQL.Append(" ,WK." & NameOf(_D003_NCR_J.SEIZO_TANTO_ID))
        sbSQL.Append(" ,WK." & NameOf(_D003_NCR_J.KENSA_TANTO_ID))
        sbSQL.Append(" ,WK." & NameOf(_D003_NCR_J.HENKYAKU_YMD))
        sbSQL.Append(" ,WK." & NameOf(_D003_NCR_J.HENKYAKU_SAKI))
        sbSQL.Append(" ,WK." & NameOf(_D003_NCR_J.HENKYAKU_TANTO_ID))
        sbSQL.Append(" ,WK." & NameOf(_D003_NCR_J.HENKYAKU_BIKO))
        sbSQL.Append(" ,WK." & NameOf(_D003_NCR_J.TENYO_KISYU_ID))
        sbSQL.Append(" ,WK." & NameOf(_D003_NCR_J.TENYO_BUHIN_BANGO))
        sbSQL.Append(" ,WK." & NameOf(_D003_NCR_J.TENYO_GOKI))
        sbSQL.Append(" ,WK." & NameOf(_D003_NCR_J.TENYO_LOT))
        sbSQL.Append(" ,WK." & NameOf(_D003_NCR_J.TENYO_YMD))
        sbSQL.Append(" ,WK." & NameOf(_D003_NCR_J.SYOCHI_KEKKA_A))
        sbSQL.Append(" ,WK." & NameOf(_D003_NCR_J.SYOCHI_KEKKA_B))
        sbSQL.Append(" ,WK." & NameOf(_D003_NCR_J.SYOCHI_KEKKA_C))
        sbSQL.Append(" ,WK." & NameOf(_D003_NCR_J.SYOCHI_D_UMU_KB))
        sbSQL.Append(" ,WK." & NameOf(_D003_NCR_J.SYOCHI_D_YOHI_KB))
        sbSQL.Append(" ,WK." & NameOf(_D003_NCR_J.SYOCHI_D_SYOCHI_KIROKU))
        sbSQL.Append(" ,WK." & NameOf(_D003_NCR_J.SYOCHI_E_UMU_KB))
        sbSQL.Append(" ,WK." & NameOf(_D003_NCR_J.SYOCHI_E_YOHI_KB))
        sbSQL.Append(" ,WK." & NameOf(_D003_NCR_J.SYOCHI_E_SYOCHI_KIROKU))
        sbSQL.Append(" ,WK." & NameOf(_D003_NCR_J.FILE_PATH))
        sbSQL.Append(" ,WK." & NameOf(_D003_NCR_J.G_FILE_PATH1))
        sbSQL.Append(" ,WK." & NameOf(_D003_NCR_J.G_FILE_PATH2))
        sbSQL.Append(" ,WK." & NameOf(_D003_NCR_J.HASSEI_KOTEI_GL_SYAIN_ID))
        sbSQL.Append(" ,WK." & NameOf(_D003_NCR_J.HASSEI_YMD))
        sbSQL.Append(" ,WK." & NameOf(_D003_NCR_J.ADD_SYAIN_ID))
        sbSQL.Append(" ,WK." & NameOf(_D003_NCR_J.ADD_YMDHNS))
        sbSQL.Append(" ,WK." & NameOf(_D003_NCR_J.UPD_SYAIN_ID))
        sbSQL.Append(" ,WK." & NameOf(_D003_NCR_J.UPD_YMDHNS))
        sbSQL.Append(" ,WK." & NameOf(_D003_NCR_J.DEL_SYAIN_ID))
        sbSQL.Append(" ,WK." & NameOf(_D003_NCR_J.DEL_YMDHNS))
        sbSQL.Append(" )")
        sbSQL.Append("OUTPUT $action AS RESULT;")

        Using DB As ClsDbUtility = DBOpen()
            Dim blnErr As Boolean
            Try
                DB.BeginTransaction()
                strRET = DB.ExecuteScalar(sbSQL.ToString, conblnNonMsg, sqlEx)
                Select Case strRET
                    Case "INSERT"

                    Case "UPDATE"
                        '既に存在する場合もエラー
                        Dim strMsg As String
                        strMsg = "既に他の担当者によって再不適合登録されているため、保存出来ません。"

                        MessageBox.Show(strMsg, "同時更新無効", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                        Return False
                    Case Else
                        If sqlEx.Source IsNot Nothing Then
                            '-----エラーログ出力
                            Dim strErrMsg As String = My.Resources.ErrLogSqlExecutionFailure & sbSQL.ToString & "|" & sqlEx.Message
                            WL.WriteLogDat(strErrMsg)
                            blnErr = True
                        Else
                            '---排他制御
                            Dim strMsg As String
                            strMsg = "既に他の担当者によって変更されているため保存出来ません。" & vbCrLf &
                                "再度登録し直して下さい。"

                            MessageBox.Show(strMsg, "同時更新無効", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                        End If
                        Return False
                End Select

                '----D004
                '-----データモデル更新
                _D004_SYONIN_J_KANRI.clear()
                _D004_SYONIN_J_KANRI.SYONIN_HOKOKUSYO_ID = Context.ENM_SYONIN_HOKOKUSYO_ID._1_NCR
                _D004_SYONIN_J_KANRI.HOKOKU_NO = _D003_NCR_J.HOKOKU_NO
                _D004_SYONIN_J_KANRI.SYONIN_JUN = ENM_CAR_STAGE._10_起草入力
                _D004_SYONIN_J_KANRI.SYAIN_ID = pub_SYAIN_INFO.SYAIN_ID
                _D004_SYONIN_J_KANRI.SYONIN_YMDHNS = ""
                _D004_SYONIN_J_KANRI.SYONIN_HANTEI_KB = ENM_SYONIN_HANTEI_KB._0_未承認
                _D004_SYONIN_J_KANRI.SASIMODOSI_FG = False
                _D004_SYONIN_J_KANRI.RIYU = ""
                _D004_SYONIN_J_KANRI.COMMENT = ""
                _D004_SYONIN_J_KANRI.MAIL_SEND_FG = True
                _D004_SYONIN_J_KANRI.ADD_SYAIN_ID = pub_SYAIN_INFO.SYAIN_ID

                strRET = ""
                '-----D004
                sbSQL.Remove(0, sbSQL.Length)
                sbSQL.Append($"MERGE INTO {NameOf(MODEL.D004_SYONIN_J_KANRI)} AS SrcT")
                sbSQL.Append($" USING (")
                sbSQL.Append($" SELECT")
                sbSQL.Append($" {_D004_SYONIN_J_KANRI.SYONIN_HOKOKUSYO_ID} AS {NameOf(_D004_SYONIN_J_KANRI.SYONIN_HOKOKUSYO_ID)}")
                sbSQL.Append($" ,'{_D004_SYONIN_J_KANRI.HOKOKU_NO}' AS {NameOf(_D004_SYONIN_J_KANRI.HOKOKU_NO)}")
                sbSQL.Append($" ,{_D004_SYONIN_J_KANRI.SYONIN_JUN} AS {NameOf(_D004_SYONIN_J_KANRI.SYONIN_JUN)}")
                sbSQL.Append($" ,'{_D004_SYONIN_J_KANRI.SYAIN_ID}' AS {NameOf(_D004_SYONIN_J_KANRI.SYAIN_ID)}")
                sbSQL.Append($" ,'{_D004_SYONIN_J_KANRI.SYONIN_YMDHNS}' AS {NameOf(_D004_SYONIN_J_KANRI.SYONIN_YMDHNS)}")
                sbSQL.Append($" ,'{_D004_SYONIN_J_KANRI.SYONIN_HANTEI_KB}' AS {NameOf(_D004_SYONIN_J_KANRI.SYONIN_HANTEI_KB)}")
                sbSQL.Append($" ,'{_D004_SYONIN_J_KANRI._SASIMODOSI_FG}' AS {NameOf(_D004_SYONIN_J_KANRI.SASIMODOSI_FG)}")
                sbSQL.Append($" ,'{_D004_SYONIN_J_KANRI.RIYU}' AS {NameOf(_D004_SYONIN_J_KANRI.RIYU)}")
                sbSQL.Append($" ,'{_D004_SYONIN_J_KANRI.COMMENT}' AS {NameOf(_D004_SYONIN_J_KANRI.COMMENT)}")
                sbSQL.Append($" ,'{_D004_SYONIN_J_KANRI._MAIL_SEND_FG}' AS {NameOf(_D004_SYONIN_J_KANRI.MAIL_SEND_FG)}")
                sbSQL.Append($" ,{_D004_SYONIN_J_KANRI.ADD_SYAIN_ID} AS {NameOf(_D004_SYONIN_J_KANRI.ADD_SYAIN_ID)}")
                sbSQL.Append($" ,dbo.GetSysDateString() AS {NameOf(_D004_SYONIN_J_KANRI.ADD_YMDHNS)}")
                sbSQL.Append($" ,{pub_SYAIN_INFO.SYAIN_ID} AS {NameOf(_D004_SYONIN_J_KANRI.UPD_SYAIN_ID)}")
                sbSQL.Append($" ,'{_D004_SYONIN_J_KANRI.UPD_YMDHNS}' AS {NameOf(_D004_SYONIN_J_KANRI.UPD_YMDHNS)}")
                sbSQL.Append($" ) AS WK")
                sbSQL.Append($" ON (SrcT.{NameOf(_D004_SYONIN_J_KANRI.SYONIN_HOKOKUSYO_ID)} = WK.{NameOf(_D004_SYONIN_J_KANRI.SYONIN_HOKOKUSYO_ID)}")
                sbSQL.Append($" AND SrcT.{NameOf(_D004_SYONIN_J_KANRI.HOKOKU_NO)} = WK.{NameOf(_D004_SYONIN_J_KANRI.HOKOKU_NO)}")
                sbSQL.Append($" AND SrcT.{NameOf(_D004_SYONIN_J_KANRI.SYONIN_JUN)} = WK.{NameOf(_D004_SYONIN_J_KANRI.SYONIN_JUN)})")

                'UPDATE 排他制御 更新日時が変更されていない場合のみ
                sbSQL.Append($" WHEN MATCHED AND SrcT.{NameOf(_D004_SYONIN_J_KANRI.UPD_YMDHNS)} = WK.{NameOf(_D004_SYONIN_J_KANRI.UPD_YMDHNS)} THEN ")
                sbSQL.Append($" UPDATE SET")
                sbSQL.Append($"  SrcT.{NameOf(_D004_SYONIN_J_KANRI.SYAIN_ID)} = WK.{NameOf(_D004_SYONIN_J_KANRI.SYAIN_ID)}")
                sbSQL.Append($" ,SrcT.{NameOf(_D004_SYONIN_J_KANRI.UPD_SYAIN_ID)} = WK.{NameOf(_D004_SYONIN_J_KANRI.UPD_SYAIN_ID)}")
                sbSQL.Append($" ,SrcT.{NameOf(_D004_SYONIN_J_KANRI.COMMENT)} = WK.{NameOf(_D004_SYONIN_J_KANRI.COMMENT)}")
                sbSQL.Append($" ,SrcT.{NameOf(_D004_SYONIN_J_KANRI.UPD_YMDHNS)} = dbo.GetSysDateString()")
                sbSQL.Append($" ,SrcT.{NameOf(_D004_SYONIN_J_KANRI.SASIMODOSI_FG)} = WK.{NameOf(_D004_SYONIN_J_KANRI.SASIMODOSI_FG)}")
                sbSQL.Append($" ,SrcT.{NameOf(_D004_SYONIN_J_KANRI.SYONIN_YMDHNS)} = WK.{NameOf(_D004_SYONIN_J_KANRI.SYONIN_YMDHNS)}")
                sbSQL.Append($" ,SrcT.{NameOf(_D004_SYONIN_J_KANRI.SYONIN_HANTEI_KB)} = WK.{NameOf(_D004_SYONIN_J_KANRI.SYONIN_HANTEI_KB)}")
                sbSQL.Append($" ,SrcT.{NameOf(_D004_SYONIN_J_KANRI.MAIL_SEND_FG)} = WK.{NameOf(_D004_SYONIN_J_KANRI.MAIL_SEND_FG)}")
                sbSQL.Append($" ,SrcT.{NameOf(_D004_SYONIN_J_KANRI.RIYU)} = WK.{NameOf(_D004_SYONIN_J_KANRI.RIYU)}")
                'INSERT
                sbSQL.Append(" WHEN NOT MATCHED THEN ")
                sbSQL.Append(" INSERT(")
                sbSQL.Append("  " & NameOf(_D004_SYONIN_J_KANRI.SYONIN_HOKOKUSYO_ID))
                sbSQL.Append(" ," & NameOf(_D004_SYONIN_J_KANRI.HOKOKU_NO))
                sbSQL.Append(" ," & NameOf(_D004_SYONIN_J_KANRI.SYONIN_JUN))
                sbSQL.Append(" ," & NameOf(_D004_SYONIN_J_KANRI.SYAIN_ID))
                sbSQL.Append(" ," & NameOf(_D004_SYONIN_J_KANRI.SYONIN_YMDHNS))
                sbSQL.Append(" ," & NameOf(_D004_SYONIN_J_KANRI.SYONIN_HANTEI_KB))
                sbSQL.Append(" ," & NameOf(_D004_SYONIN_J_KANRI.SASIMODOSI_FG))
                sbSQL.Append(" ," & NameOf(_D004_SYONIN_J_KANRI.RIYU))
                sbSQL.Append(" ," & NameOf(_D004_SYONIN_J_KANRI.COMMENT))
                sbSQL.Append(" ," & NameOf(_D004_SYONIN_J_KANRI.MAIL_SEND_FG))
                sbSQL.Append(" ," & NameOf(_D004_SYONIN_J_KANRI.ADD_SYAIN_ID))
                sbSQL.Append(" ," & NameOf(_D004_SYONIN_J_KANRI.ADD_YMDHNS))
                sbSQL.Append(" ," & NameOf(_D004_SYONIN_J_KANRI.UPD_SYAIN_ID))
                sbSQL.Append(" ," & NameOf(_D004_SYONIN_J_KANRI.UPD_YMDHNS))
                sbSQL.Append(" ) VALUES(")
                sbSQL.Append("  WK." & NameOf(_D004_SYONIN_J_KANRI.SYONIN_HOKOKUSYO_ID))
                sbSQL.Append(" ,WK." & NameOf(_D004_SYONIN_J_KANRI.HOKOKU_NO))
                sbSQL.Append(" ,WK." & NameOf(_D004_SYONIN_J_KANRI.SYONIN_JUN))
                sbSQL.Append(" ,WK." & NameOf(_D004_SYONIN_J_KANRI.SYAIN_ID))
                sbSQL.Append(" ,WK." & NameOf(_D004_SYONIN_J_KANRI.SYONIN_YMDHNS))
                sbSQL.Append(" ,WK." & NameOf(_D004_SYONIN_J_KANRI.SYONIN_HANTEI_KB))
                sbSQL.Append(" ,WK." & NameOf(_D004_SYONIN_J_KANRI.SASIMODOSI_FG))
                sbSQL.Append(" ,WK." & NameOf(_D004_SYONIN_J_KANRI.RIYU))
                sbSQL.Append(" ,WK." & NameOf(_D004_SYONIN_J_KANRI.COMMENT))
                sbSQL.Append(" ,WK." & NameOf(_D004_SYONIN_J_KANRI.MAIL_SEND_FG))
                sbSQL.Append(" ,WK." & NameOf(_D004_SYONIN_J_KANRI.ADD_SYAIN_ID))
                sbSQL.Append(" ,WK." & NameOf(_D004_SYONIN_J_KANRI.ADD_YMDHNS))
                sbSQL.Append(" ,WK." & NameOf(_D004_SYONIN_J_KANRI.UPD_SYAIN_ID))
                sbSQL.Append(" ,WK." & NameOf(_D004_SYONIN_J_KANRI.UPD_YMDHNS))
                sbSQL.Append(" )")
                sbSQL.Append("OUTPUT $action AS RESULT;")
                strRET = DB.ExecuteScalar(sbSQL.ToString, conblnNonMsg, sqlEx)

                Select Case strRET
                    Case "INSERT"

                    Case "UPDATE"

                    Case Else
                        If sqlEx.Source IsNot Nothing Then
                            '-----エラーログ出力
                            Dim strErrMsg As String = My.Resources.ErrLogSqlExecutionFailure & sbSQL.ToString & "|" & sqlEx.Message
                            WL.WriteLogDat(strErrMsg)
                        Else
                            '---排他制御
                            Dim strMsg As String
                            strMsg = "既に他の担当者によって変更されているため保存出来ません。" & vbCrLf &
                                        "再度登録し直して下さい。"

                            MessageBox.Show(strMsg, "同時更新無効", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                        End If

                        Return False
                End Select
            Finally
                DB.Commit(Not blnErr)
            End Try
        End Using

        Return True
    End Function

#End Region

#End Region

#Region "CAR"

    Private Function OpenFormCAR() As Boolean

        Dim dlgRET As DialogResult

        Try
            Using frmDLG As New FrmG0012
                frmDLG.PrDialog = True
                frmDLG.PrHOKOKU_NO = _D003_NCR_J.HOKOKU_NO
                frmDLG.PrCurrentStage = ENM_CAR_STAGE._10_起草入力
                dlgRET = frmDLG.ShowDialog(Me)
            End Using

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

        End Try
    End Function

#End Region

#Region "転送"

    Private Function OpenFormTENSO() As Boolean
        Dim frmDLG As New FrmG0015
        Dim dlgRET As DialogResult

        Try
            frmDLG.PrSYONIN_HOKOKUSYO_ID = Context.ENM_SYONIN_HOKOKUSYO_ID._1_NCR
            frmDLG.PrHOKOKU_NO = _D003_NCR_J.HOKOKU_NO
            frmDLG.PrBUMON_KB = _D003_NCR_J.BUMON_KB
            frmDLG.PrBUHIN_BANGO = _D003_NCR_J.BUHIN_BANGO
            frmDLG.PrKISO_YMD = DateTime.ParseExact(_D003_NCR_J.ADD_YMD, "yyyyMMdd", Nothing).ToString("yyyy/MM/dd")
            frmDLG.PrKISYU_NAME = tblKISYU.AsEnumerable.Where(Function(r) r.Field(Of Integer)("VALUE") = _D003_NCR_J.KISYU_ID).FirstOrDefault?.Item("DISP")
            frmDLG.PrCurrentStage = Me.PrCurrentStage
            dlgRET = frmDLG.ShowDialog(Me)

            If dlgRET = Windows.Forms.DialogResult.OK Then
                Me.DialogResult = DialogResult.OK
                Me.Close()
                Return True
            Else
                Return False
            End If
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

#Region "差戻し"

    Private Function OpenFormSASIMODOSI() As Boolean
        Dim frmDLG As New FrmG0016
        Dim dlgRET As DialogResult

        Try
            frmDLG.PrSYONIN_HOKOKUSYO_ID = Context.ENM_SYONIN_HOKOKUSYO_ID._1_NCR
            frmDLG.PrHOKOKU_NO = _D003_NCR_J.HOKOKU_NO
            frmDLG.PrCurrentStage = Me.PrCurrentStage
            frmDLG.PrBUHIN_BANGO = _D003_NCR_J.BUHIN_BANGO
            frmDLG.PrKISO_YMD = DateTime.ParseExact(_D003_NCR_J.ADD_YMD, "yyyyMMdd", Nothing).ToString("yyyy/MM/dd")
            frmDLG.PrKISYU_NAME = tblKISYU.AsEnumerable.Where(Function(r) r.Field(Of Integer)("VALUE") = _D003_NCR_J.KISYU_ID).FirstOrDefault?.Item("DISP")
            dlgRET = frmDLG.ShowDialog(Me)
            If dlgRET = Windows.Forms.DialogResult.Cancel Then
                Return False
            Else
                Me.DialogResult = DialogResult.OK
                Me.Close()
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

#Region "印刷"

    Private Function FunOpenReportNCR() As Boolean
        Dim strOutputFileName As String
        Dim strTEMPFILE As String
        'Dim intRET As Integer

        Try
            Me.Cursor = Cursors.WaitCursor

            'ファイル名
            strOutputFileName = "NCR_" & _D003_NCR_J.HOKOKU_NO & "_Work.xls"

            '既存ファイル削除
            If FunDELETE_FILE(pub_APP_INFO.strOUTPUT_PATH & strOutputFileName) = False Then
                Return False
            End If

            Using iniIF As New IniFile(FunGetRootPath() & "\INI\" & CON_TEMPLATE_INI)
                strTEMPFILE = FunConvRootPath(iniIF.GetIniString("NCR", "FILEPATH"))
            End Using

            'エクセル出力ファイル用意
            If OUT_EXCEL_READY(strTEMPFILE, pub_APP_INFO.strOUTPUT_PATH, strOutputFileName) = False Then
                Return False
            End If
            '-----書込処理
            If FunMakeReportNCR(pub_APP_INFO.strOUTPUT_PATH & strOutputFileName, _D003_NCR_J.HOKOKU_NO) = False Then
                Return False
            End If

            'Excel起動
            'Return FunOpenExcelApp(pub_APP_INFO.strOUTPUT_PATH & strOutputFileName)
        Catch ex As Exception
            EM.ErrorSyori(ex, False, conblnNonMsg)
            Return False
        Finally
            Me.Cursor = Cursors.Default
        End Try
    End Function

    Private Function _FunMakeReportNCR(ByVal strFilePath As String, ByVal strHOKOKU_NO As String) As Boolean

        Dim ssgWorkbook As SpreadsheetGear.IWorkbook
        Dim ssgWorksheets As SpreadsheetGear.IWorksheets
        Dim ssgSheet1 As SpreadsheetGear.IWorksheet

        Try
            Dim _V002_NCR_J As MODEL.V002_NCR_J = FunGetV002Model(strHOKOKU_NO)

            ssgWorkbook = SpreadsheetGear.Factory.GetWorkbook(strFilePath, System.Globalization.CultureInfo.CurrentCulture)
            ssgWorkbook.WorkbookSet.GetLock()
            ssgWorksheets = ssgWorkbook.Worksheets
            ssgSheet1 = ssgWorksheets.Item(0) 'sheet1

            'レコードフレーム初期化
            'spWork.Range("RECORD_FRAME").ClearContents()
            ssgSheet1.Range(NameOf(_V002_NCR_J.BUHIN_BANGO)).Value = _V002_NCR_J.BUHIN_BANGO
            ssgSheet1.Range(NameOf(_V002_NCR_J.BUHIN_NAME)).Value = _V002_NCR_J.BUHIN_NAME
            If Not _V002_NCR_J.FUTEKIGO_JYOTAI_KB.IsNullOrWhiteSpace Then
                ssgSheet1.Range(NameOf(_V002_NCR_J.FUTEKIGO_JYOTAI_KB) & _V002_NCR_J.FUTEKIGO_JYOTAI_KB).Value = "TRUE"
            End If
            ssgSheet1.Range(NameOf(_V002_NCR_J.FUTEKIGO_NAIYO)).Value = _V002_NCR_J.FUTEKIGO_NAIYO
            ssgSheet1.Range(NameOf(_V002_NCR_J.GOKI)).Value = _V002_NCR_J.GOKI
            ssgSheet1.Range(NameOf(_V002_NCR_J.HAIKYAKU_HOUHOU)).Value = "(その他の内容：" & _V002_NCR_J.HAIKYAKU_HOUHOU.PadRight(30) & ")"
            ssgSheet1.Range(NameOf(_V002_NCR_J.HAIKYAKU_KB_NAME)).Value = _V002_NCR_J.HAIKYAKU_KB_NAME
            ssgSheet1.Range(NameOf(_V002_NCR_J.HAIKYAKU_TANTO_NAME)).Value = _V002_NCR_J.HAIKYAKU_TANTO_NAME
            ssgSheet1.Range(NameOf(_V002_NCR_J.HAIKYAKU_YMD)).Value = _V002_NCR_J.HAIKYAKU_YMD
            ssgSheet1.Range(NameOf(_V002_NCR_J.HASSEI_KOTEI_GL_SYAIN_NAME)).Value = _V002_NCR_J.HASSEI_KOTEI_GL_SYAIN_NAME
            ssgSheet1.Range(NameOf(_V002_NCR_J.HASSEI_KOTEI_GL_YMD)).Value = _V002_NCR_J.HASSEI_KOTEI_GL_YMD
            ssgSheet1.Range(NameOf(_V002_NCR_J.HENKYAKU_BIKO)).Value = _V002_NCR_J.HENKYAKU_BIKO
            ssgSheet1.Range(NameOf(_V002_NCR_J.HENKYAKU_SAKI)).Value = _V002_NCR_J.HENKYAKU_SAKI
            ssgSheet1.Range(NameOf(_V002_NCR_J.HENKYAKU_TANTO_NAME)).Value = _V002_NCR_J.HENKYAKU_TANTO_NAME
            ssgSheet1.Range(NameOf(_V002_NCR_J.HENKYAKU_YMD)).Value = _V002_NCR_J.HENKYAKU_YMD
            ssgSheet1.Range(NameOf(_V002_NCR_J.HOKOKU_NO)).Value = _V002_NCR_J.HOKOKU_NO
            ssgSheet1.Range(NameOf(_V002_NCR_J.ITAG_NO)).Value = _V002_NCR_J.ITAG_NO
            If Not _V002_NCR_J.JIZEN_SINSA_HANTEI_KB.IsNullOrWhiteSpace Then
                ssgSheet1.Range(NameOf(_V002_NCR_J.JIZEN_SINSA_HANTEI_KB) & _V002_NCR_J.JIZEN_SINSA_HANTEI_KB).Value = "TRUE"
            End If
            ssgSheet1.Range(NameOf(_V002_NCR_J.JIZEN_SINSA_SYAIN_NAME)).Value = _V002_NCR_J.JIZEN_SINSA_SYAIN_NAME
            ssgSheet1.Range(NameOf(_V002_NCR_J.JIZEN_SINSA_YMD)).Value = _V002_NCR_J.JIZEN_SINSA_YMD
            ssgSheet1.Range(NameOf(_V002_NCR_J.KANSATU_KEKKA)).Value = _V002_NCR_J.KANSATU_KEKKA
            ssgSheet1.Range(NameOf(_V002_NCR_J.KENSA_KEKKA_NAME)).Value = _V002_NCR_J.KENSA_KEKKA_NAME
            ssgSheet1.Range(NameOf(_V002_NCR_J.KENSA_TANTO_NAME)).Value = _V002_NCR_J.KENSA_TANTO_NAME
            'ssgSheet1.Range(NameOf(_V002_NCR_J.KISYU)).Value = _V002_NCR_J.KISYU
            ssgSheet1.Range(NameOf(_V002_NCR_J.KOKYAKU_HANTEI_SIJI_NAME)).Value = _V002_NCR_J.KOKYAKU_HANTEI_SIJI_NAME
            ssgSheet1.Range(NameOf(_V002_NCR_J.KOKYAKU_HANTEI_SIJI_YMD)).Value = _V002_NCR_J.KOKYAKU_HANTEI_SIJI_YMD
            ssgSheet1.Range(NameOf(_V002_NCR_J.SAIHATU)).Value = _V002_NCR_J.SAIHATU
            ssgSheet1.Range(NameOf(_V002_NCR_J.SAIKAKO_KENSA_YMD)).Value = _V002_NCR_J.SAIKAKO_KENSA_YMD
            ssgSheet1.Range(NameOf(_V002_NCR_J.SAIKAKO_SAGYO_KAN_YMD)).Value = _V002_NCR_J.SAIKAKO_SAGYO_KAN_YMD
            ssgSheet1.Range(NameOf(_V002_NCR_J.SAIKAKO_SIJI_NO)).Value = _V002_NCR_J.SAIKAKO_SIJI_NO
            ssgSheet1.Range(NameOf(_V002_NCR_J.SAISIN_GIJYUTU_SYAIN_NAME)).Value = _V002_NCR_J.SAISIN_GIJYUTU_SYAIN_NAME
            ssgSheet1.Range(NameOf(_V002_NCR_J.SAISIN_HINSYO_SYAIN_NAME)).Value = _V002_NCR_J.SAISIN_HINSYO_SYAIN_NAME
            ssgSheet1.Range(NameOf(_V002_NCR_J.SAISIN_HINSYO_YMD)).Value = _V002_NCR_J.SAISIN_HINSYO_YMD
            If Not _V002_NCR_J.SAISIN_IINKAI_HANTEI_KB.IsNullOrWhiteSpace Then
                ssgSheet1.Range(NameOf(_V002_NCR_J.SAISIN_IINKAI_HANTEI_KB) & _V002_NCR_J.SAISIN_IINKAI_HANTEI_KB).Value = "TRUE"
            End If
            ssgSheet1.Range(NameOf(_V002_NCR_J.SAISIN_IINKAI_SIRYO_NO)).Value = _V002_NCR_J.SAISIN_IINKAI_SIRYO_NO
            ssgSheet1.Range(NameOf(_V002_NCR_J.SAISIN_KAKUNIN_SYAIN_NAME)).Value = _V002_NCR_J.SAISIN_KAKUNIN_SYAIN_NAME
            ssgSheet1.Range(NameOf(_V002_NCR_J.SAISIN_KAKUNIN_YMD)).Value = _V002_NCR_J.SAISIN_KAKUNIN_YMD
            ssgSheet1.Range(NameOf(_V002_NCR_J.SEIGI_TANTO_NAME)).Value = _V002_NCR_J.SEIGI_TANTO_NAME
            ssgSheet1.Range(NameOf(_V002_NCR_J.SEIZO_TANTO_NAME)).Value = _V002_NCR_J.SEIZO_TANTO_NAME
            ssgSheet1.Range(NameOf(_V002_NCR_J.SURYO)).Value = _V002_NCR_J.SURYO
            ssgSheet1.Range(NameOf(_V002_NCR_J.SYOCHI_D_SYOCHI_KIROKU)).Value = _V002_NCR_J.SYOCHI_D_SYOCHI_KIROKU
            ssgSheet1.Range(NameOf(_V002_NCR_J.SYOCHI_D_UMU_NAME)).Value = _V002_NCR_J.SYOCHI_D_UMU_NAME
            ssgSheet1.Range(NameOf(_V002_NCR_J.SYOCHI_D_YOHI_NAME)).Value = _V002_NCR_J.SYOCHI_D_YOHI_NAME
            ssgSheet1.Range(NameOf(_V002_NCR_J.SYOCHI_E_SYOCHI_KIROKU)).Value = _V002_NCR_J.SYOCHI_E_SYOCHI_KIROKU
            ssgSheet1.Range(NameOf(_V002_NCR_J.SYOCHI_E_UMU_NAME)).Value = _V002_NCR_J.SYOCHI_E_UMU_NAME
            ssgSheet1.Range(NameOf(_V002_NCR_J.SYOCHI_E_YOHI_NAME)).Value = _V002_NCR_J.SYOCHI_E_YOHI_NAME
            ssgSheet1.Range(NameOf(_V002_NCR_J.SYOCHI_KEKKA_A_NAME)).Value = _V002_NCR_J.SYOCHI_KEKKA_A_NAME
            ssgSheet1.Range(NameOf(_V002_NCR_J.SYOCHI_KEKKA_B_NAME)).Value = _V002_NCR_J.SYOCHI_KEKKA_B_NAME
            ssgSheet1.Range(NameOf(_V002_NCR_J.SYOCHI_KEKKA_C_NAME)).Value = _V002_NCR_J.SYOCHI_KEKKA_C_NAME
            ssgSheet1.Range(NameOf(_V002_NCR_J.TENYO_BUHIN_BANGO)).Value = _V002_NCR_J.TENYO_BUHIN_BANGO
            ssgSheet1.Range(NameOf(_V002_NCR_J.TENYO_GOKI)).Value = _V002_NCR_J.TENYO_GOKI
            ssgSheet1.Range(NameOf(_V002_NCR_J.TENYO_KISYU_NAME)).Value = _V002_NCR_J.TENYO_KISYU_NAME
            ssgSheet1.Range(NameOf(_V002_NCR_J.TENYO_YMD)).Value = _V002_NCR_J.TENYO_YMD
            ssgSheet1.Range(NameOf(_V002_NCR_J.YOKYU_NAIYO)).Value = _V002_NCR_J.YOKYU_NAIYO
            ssgSheet1.Range(NameOf(_V002_NCR_J.ZUMEN_KIKAKU)).Value = "(図面/規格　： " & _V002_NCR_J.ZUMEN_KIKAKU.PadRight(50) & ")"

            ssgSheet1.Range("SYONIN_NAME10").Value = _V003_SYONIN_J_KANRI_List.Where(Function(r) r.SYONIN_JUN = ENM_NCR_STAGE._10_起草入力).FirstOrDefault?.SYAIN_NAME
            ssgSheet1.Range("SYONIN_NAME20").Value = _V003_SYONIN_J_KANRI_List.Where(Function(r) r.SYONIN_JUN = ENM_NCR_STAGE._20_起草確認製造GL).FirstOrDefault?.SYAIN_NAME
            ssgSheet1.Range("SYONIN_NAME30").Value = _V003_SYONIN_J_KANRI_List.Where(Function(r) r.SYONIN_JUN = ENM_NCR_STAGE._30_起草確認検査).FirstOrDefault?.SYAIN_NAME
            ssgSheet1.Range("SYONIN_NAME90").Value = _V003_SYONIN_J_KANRI_List.Where(Function(r) r.SYONIN_JUN = ENM_NCR_STAGE._90_処置実施確認_管理T).FirstOrDefault?.SYAIN_NAME
            ssgSheet1.Range("SYONIN_NAME100").Value = _V003_SYONIN_J_KANRI_List.Where(Function(r) r.SYONIN_JUN = ENM_NCR_STAGE._100_処置実施決裁_製造課長).FirstOrDefault?.SYAIN_NAME
            ssgSheet1.Range("SYONIN_NAME110").Value = _V003_SYONIN_J_KANRI_List.Where(Function(r) r.SYONIN_JUN = ENM_NCR_STAGE._110_abcde処置担当).FirstOrDefault?.SYAIN_NAME
            ssgSheet1.Range("SYONIN_NAME120").Value = _V003_SYONIN_J_KANRI_List.Where(Function(r) r.SYONIN_JUN = ENM_NCR_STAGE._120_abcde処置確認).FirstOrDefault?.SYAIN_NAME
            ssgSheet1.Range("SYONIN_YMD20").Value = _V003_SYONIN_J_KANRI_List.Where(Function(r) r.SYONIN_JUN = ENM_NCR_STAGE._20_起草確認製造GL And r.SYONIN_HANTEI_KB = ENM_SYONIN_HANTEI_KB._1_承認).FirstOrDefault?.SYONIN_YMDHNS
            ssgSheet1.Range("SYONIN_YMD30").Value = _V003_SYONIN_J_KANRI_List.Where(Function(r) r.SYONIN_JUN = ENM_NCR_STAGE._30_起草確認検査 And r.SYONIN_HANTEI_KB = ENM_SYONIN_HANTEI_KB._1_承認).FirstOrDefault?.SYONIN_YMDHNS
            ssgSheet1.Range("SYONIN_YMD90").Value = _V003_SYONIN_J_KANRI_List.Where(Function(r) r.SYONIN_JUN = ENM_NCR_STAGE._90_処置実施確認_管理T And r.SYONIN_HANTEI_KB = ENM_SYONIN_HANTEI_KB._1_承認).FirstOrDefault?.SYONIN_YMDHNS
            ssgSheet1.Range("SYONIN_YMD100").Value = _V003_SYONIN_J_KANRI_List.Where(Function(r) r.SYONIN_JUN = ENM_NCR_STAGE._100_処置実施決裁_製造課長 And r.SYONIN_HANTEI_KB = ENM_SYONIN_HANTEI_KB._1_承認).FirstOrDefault?.SYONIN_YMDHNS
            ssgSheet1.Range("SYONIN_YMD110").Value = _V003_SYONIN_J_KANRI_List.Where(Function(r) r.SYONIN_JUN = ENM_NCR_STAGE._110_abcde処置担当 And r.SYONIN_HANTEI_KB = ENM_SYONIN_HANTEI_KB._1_承認).FirstOrDefault?.SYONIN_YMDHNS

            '-----ファイル保存
            ssgSheet1.SaveAs(filename:=strFilePath, fileFormat:=SpreadsheetGear.FileFormat.Excel8)
            ssgWorkbook.WorkbookSet.ReleaseLock()

            '-----Spire版 直接PDF発行するならこっち
            'Dim workbook As New Spire.Xls.Workbook
            'workbook.LoadFromFile(strFilePath)
            'Dim pdfFilePath As String
            'pdfFilePath = System.IO.Path.GetDirectoryName(strFilePath) & "\" & System.IO.Path.GetFileNameWithoutExtension(strFilePath) & ".pdf"
            'workbook.SaveToFile(pdfFilePath, Spire.Xls.FileFormat.PDF)

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
            ssgSheet1 = Nothing
            ssgWorksheets = Nothing
            ssgWorkbook = Nothing
        End Try
    End Function

#End Region

#Region "履歴"

    Private Function OpenFormHistory(ByVal SYONIN_HOKOKU_ID As Integer, ByVal HOKOKU_NO As String) As Boolean
        Dim frmDLG As New FrmG0017
        Dim dlgRET As DialogResult

        Try
            frmDLG.PrSYONIN_HOKOKUSYO_ID = SYONIN_HOKOKU_ID
            frmDLG.PrHOKOKU_NO = HOKOKU_NO
            dlgRET = frmDLG.ShowDialog(Me)
            If dlgRET = Windows.Forms.DialogResult.Cancel Then
                Return False
            Else
            End If

            Return True
        Catch ex As Exception
            EM.ErrorSyori(ex, False, conblnNonMsg)
            Return False
        Finally
            If frmDLG IsNot Nothing Then
                frmDLG.Dispose()
            End If
            Me.Visible = True
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
                cmdFunc10.Enabled = True
                cmdFunc11.Enabled = True

                'SPEC: 40-3.④
                If PrIsDialog = True Then

                    cmdFunc9.Enabled = False
                    MyBase.ToolTip.SetToolTip(Me.cmdFunc9, "既にCAR画面から呼び出されているため使用出来ません")
                Else
                    If _D003_NCR_J._ZESEI_SYOCHI_YOHI_KB = ENM_YOHI_KB._1_要 Then
                        cmdFunc9.Enabled = True
                    Else
                        If PrMODE = ENM_DATA_OPERATION_MODE._1_ADD Then
                            MyBase.ToolTip.SetToolTip(Me.cmdFunc9, "このステージでは使用出来ません")
                        Else
                            MyBase.ToolTip.SetToolTip(Me.cmdFunc9, "是正処置不要のため作成されていません")
                        End If
                        cmdFunc9.Enabled = False
                    End If
                End If

                'カレントステージが自身の担当でない場合は無効
                If FunblnOwnCreated(Context.ENM_SYONIN_HOKOKUSYO_ID._1_NCR, _D003_NCR_J.HOKOKU_NO, PrCurrentStage) Then 'If TabSTAGE.TabPages(TabSTAGE.SelectedIndex).Enabled = False Then
                    cmdFunc1.Enabled = True
                    cmdFunc2.Enabled = True
                    cmdFunc4.Enabled = True
                    cmdFunc5.Enabled = True
                Else
                    cmdFunc1.Enabled = False
                    cmdFunc2.Enabled = False
                    cmdFunc4.Enabled = False
                    cmdFunc5.Enabled = False
                End If

                'SPEC: 80-2.⑤
                Select Case PrCurrentStage
                    Case ENM_NCR_STAGE._10_起草入力
                        cmdFunc5.Enabled = False
                    Case ENM_NCR_STAGE._81_処置実施_生技, ENM_NCR_STAGE._82_処置実施_製造, ENM_NCR_STAGE._83_処置実施_検査
                        cmdFunc1.Enabled = False
                    Case Else
                End Select

                '#52 管理者権限を持つ場合
                Dim blnIsAdmin As Boolean = HasAdminAuth(pub_SYAIN_INFO.SYAIN_ID)
                If blnIsAdmin Then
                    cmdFunc4.Enabled = True
                    cmdFunc5.Enabled = True
                End If

                If PrCurrentStage = ENM_NCR_STAGE._999_Closed Then
                    cmdFunc1.Enabled = False
                    cmdFunc2.Enabled = False
                    cmdFunc4.Enabled = False
                    cmdFunc5.Enabled = False
                    MyBase.ToolTip.SetToolTip(cmdFunc1, "Close済みのため使用出来ません")
                    MyBase.ToolTip.SetToolTip(cmdFunc2, "Close済みのため使用出来ません")
                    MyBase.ToolTip.SetToolTip(cmdFunc4, "Close済みのため使用出来ません")
                    MyBase.ToolTip.SetToolTip(cmdFunc5, "Close済みのため使用出来ません")
                End If
            End If

            Return True
        Catch ex As Exception
            EM.ErrorSyori(ex, False, conblnNonMsg)
            Return False
        End Try
    End Function

#End Region

#End Region

#Region "コントロールイベント"

#Region "タブ関連"

#Region "初期化"

    Private Function FunInitializeTabControl(ByVal intCurrentTabNo As Integer) As Boolean
        Dim strStageName As String = ""
        Try
            _tabPageManager = New TabPageManager(TabSTAGE)

            For Each ctrl As Control In tabSTAGE01.Controls
                If ctrl.GetType Is GetType(PanelEx) Then
                    Dim panel As PanelEx = DirectCast(ctrl, PanelEx)

                    If panel.Name = "pnlTEMP_SIRYO" Then
                        If _D003_NCR_J.CLOSE_FG Then
                            'panel.DisableContaints(False, 1)
                            btnOpenPict1Dialog.Enabled = False
                            btnOpenPict2Dialog.Enabled = False
                            btnOpenTempFileDialog.Enabled = False
                        End If
                    Else
                        Dim intTabNo As Integer = Val(panel.Name.Substring(5))

                        If intTabNo < intCurrentTabNo Then
                            'SPEC: 10-2.③
                            Dim dr = tblNCR.AsEnumerable.Where(Function(r) r.Field(Of Integer)("VALUE") = FunConvertSTAGE_NO_TO_SYONIN_JUN(intTabNo)).FirstOrDefault
                            If dr IsNot Nothing Then strStageName = dr.Item("DISP")

                            Dim ctrlLabel As Control() = panel.Controls.Find("lblSTAGE" & intTabNo.ToString("00"), True)
                            If ctrlLabel.Length > 0 Then
                                Dim lblSTAGE As Label = ctrlLabel(0)
                                lblSTAGE.Text = strStageName
                            End If

                        ElseIf intTabNo = intCurrentTabNo Then
                            strStageName = tblNCR.AsEnumerable.Where(Function(r) r.Field(Of Integer)("VALUE") = FunConvertSTAGE_NO_TO_SYONIN_JUN(intTabNo)).FirstOrDefault.Item("DISP")
                            Dim ctrlLabel As Control() = panel.Controls.Find("lblSTAGE" & intTabNo.ToString("00"), True)
                            If ctrlLabel.Length > 0 Then
                                Dim lblSTAGE As Label = ctrlLabel(0)
                                lblSTAGE.Text = strStageName
                            End If

                            '次ステージの承認担当者・コメント欄・承認申請日をバインド
                            Dim ctrlTANTO As Control() = panel.Controls.Find("cmbST" & intCurrentTabNo.ToString("00") & "_DestTANTO", True)
                            If ctrlTANTO.Length > 0 Then
                                Dim cmbTANTO As ComboboxEx = ctrlTANTO(0)
                                cmbTANTO.NullValue = 0
                                cmbTANTO.DataBindings.Add(New Binding(NameOf(cmbTANTO.SelectedValue), _D004_SYONIN_J_KANRI, NameOf(_D004_SYONIN_J_KANRI.SYAIN_ID), False, DataSourceUpdateMode.OnPropertyChanged, 0))
                            End If
                            Dim ctrlCOMMENT As Control() = panel.Controls.Find("txtST" & intCurrentTabNo.ToString("00") & "_Comment", True)
                            If ctrlCOMMENT.Length > 0 Then
                                Dim txtCOMMENT As TextBoxEx = ctrlCOMMENT(0)
                                txtCOMMENT.DataBindings.Add(New Binding(NameOf(txtCOMMENT.Text), _D004_SYONIN_J_KANRI, NameOf(_D004_SYONIN_J_KANRI.COMMENT), False, DataSourceUpdateMode.OnPropertyChanged, ""))
                            End If
                            Dim ctrlYMD As Control() = panel.Controls.Find("dtST" & intCurrentTabNo.ToString("00") & "_UPD_YMD", True)
                            If ctrlYMD.Length > 0 Then
                                Dim dtSYONIN_SINSEI_YMD As DateTextBoxEx = ctrlYMD(0)
                                dtSYONIN_SINSEI_YMD.DataBindings.Add(New Binding(NameOf(dtSYONIN_SINSEI_YMD.ValueNonFormat), _D004_SYONIN_J_KANRI, NameOf(_D004_SYONIN_J_KANRI.SYONIN_YMD), False, DataSourceUpdateMode.OnPropertyChanged, ""))
                            End If

                        ElseIf intTabNo > intCurrentTabNo Then
                            'SPEC: 10-2 ②
                            '_tabPageManager.ChangeTabPageVisible(page.TabIndex, False)
                            panel.Visible = False
                            flpnlStageIndex.Controls("rsbtnST" & intTabNo.ToString("00")).Enabled = False
                            flpnlStageIndex.Controls("rsbtnST" & intTabNo.ToString("00")).BackColor = Color.Silver
                        End If

                        'SPEC: 10-2.⑤ ステージパネル有効無効判定
                        If PrMODE = ENM_DATA_OPERATION_MODE._1_ADD Then
                            '新規作成時
                            'SPEC: (3).B
                            'page.Enabled = True
                            panel.Enabled = True
                        Else
                            If PrCurrentStage >= ENM_NCR_STAGE._90_処置実施確認_管理T Then
                                If intTabNo = intCurrentTabNo Then
                                    panel.DisableContaints(FunblnOwnCreated(Context.ENM_SYONIN_HOKOKUSYO_ID._1_NCR, _D003_NCR_J.HOKOKU_NO, PrCurrentStage), PanelEx.ENM_PROPERTY._2_ReadOnly)
                                Else
                                    panel.DisableContaints(False, PanelEx.ENM_PROPERTY._2_ReadOnly)
                                End If
                            Else
                                If PrCurrentStage = ENM_NCR_STAGE._20_起草確認製造GL Then
                                    panel.Enabled = True
                                Else
                                    'Mod #70
                                    'カレントユーザー以外は参照のみ
                                    'panel.DisableContaints(FunblnOwnCreated(Context.ENM_SYONIN_HOKOKUSYO_ID._1_NCR, PrHOKOKU_NO, FunConvertSTAGE_NO_TO_SYONIN_JUN(intTabNo)), 2)
                                    panel.DisableContaints(intTabNo = intCurrentTabNo, PanelEx.ENM_PROPERTY._2_ReadOnly)
                                End If
                            End If
                        End If
                        If _D003_NCR_J.CLOSE_FG Then panel.DisableContaints(False, PanelEx.ENM_PROPERTY._2_ReadOnly)
                    End If
                Else
                    Continue For
                End If
            Next ctrl

            '添付資料タブ初期化
            Dim strRootDir As String
            Using DB As ClsDbUtility = DBOpen()
                strRootDir = FunConvPathString(FunGetCodeMastaValue(DB, "添付ファイル保存先", My.Application.Info.AssemblyName))
            End Using
            If Not _D003_NCR_J.FILE_PATH.IsNullOrWhiteSpace Then
                lbltmpFile1.Text = CompactString(_D003_NCR_J.FILE_PATH, lbltmpFile1, EllipsisFormat._4_Path)
                lbltmpFile1.Links.Clear()
                lbltmpFile1.Links.Add(0, lbltmpFile1.Text.Length, strRootDir & _D003_NCR_J.HOKOKU_NO.Trim & "\" & _D003_NCR_J.FILE_PATH)
                lbltmpFile1.Visible = True
                lbltmpFile1_Clear.Visible = True
            End If
            If Not _D003_NCR_J.G_FILE_PATH1.IsNullOrWhiteSpace Then
                Call SetPict1Data({strRootDir & _D003_NCR_J.HOKOKU_NO.Trim & "\" & _D003_NCR_J.G_FILE_PATH1})
            End If
            If Not _D003_NCR_J.G_FILE_PATH2.IsNullOrWhiteSpace Then
                Call SetPict2Data({strRootDir & _D003_NCR_J.HOKOKU_NO.Trim & "\" & _D003_NCR_J.G_FILE_PATH2})
            End If

            If _D003_NCR_J.CLOSE_FG Then
                lbltmpFile1_Clear.Visible = False
                lblPict1Path_Clear.Visible = False
                lblPict2Path_Clear.Visible = False
            Else
                flpnlStageIndex.Controls("rsbtnST99").Enabled = False
                flpnlStageIndex.Controls("rsbtnST99").BackColor = Color.Silver
            End If

            Return True
        Catch ex As Exception
            EM.ErrorSyori(ex, False, conblnNonMsg)
            Return False
        Finally
        End Try
    End Function

    Private Function OLDFunInitializeTabControl(ByVal intCurrentTabNo As Integer) As Boolean
        'Dim strStageName As String
        'Try
        '    _tabPageManager = New TabPageManager(TabSTAGE)

        '    For Each page As TabPageEx In TabSTAGE.TabPages
        '        If page.Name <> "tabAttachment" Then
        '            Dim intTabNo As Integer = Val(page.Name.Substring(8))

        '            If intTabNo < intCurrentTabNo Then
        '                'SPEC: 10-2.③
        '                strStageName = tblNCR.AsEnumerable.Where(Function(r) r.Field(Of Integer)("VALUE") = FunConvertSTAGE_NO_TO_SYONIN_JUN2(Val(page.Name.Substring(8)))).FirstOrDefault.Item("DISP")
        '                page.Text = strStageName

        '                Dim ctrlLabel As Control() = Me.Controls.Find("lblSTAGE" & intTabNo.ToString("00"), True)
        '                If ctrlLabel.Length > 0 Then
        '                    Dim lblSTAGE As Label = ctrlLabel(0)
        '                    lblSTAGE.Text = strStageName
        '                End If

        '            ElseIf intTabNo = intCurrentTabNo Then
        '                page.Text = "現ステージ"
        '                strStageName = tblNCR.AsEnumerable.Where(Function(r) r.Field(Of Integer)("VALUE") = FunConvertSTAGE_NO_TO_SYONIN_JUN2(Val(page.Name.Substring(8)))).FirstOrDefault.Item("DISP")
        '                Dim ctrlLabel As Control() = Me.Controls.Find("lblSTAGE" & intTabNo.ToString("00"), True)
        '                If ctrlLabel.Length > 0 Then
        '                    Dim lblSTAGE As Label = ctrlLabel(0)
        '                    lblSTAGE.Text = strStageName
        '                End If

        '                '次ステージの承認担当者・コメント欄をバインド
        '                Dim ctrlTANTO As Control() = Me.Controls.Find("cmbST" & intCurrentTabNo.ToString("00") & "_DestTANTO", True)
        '                If ctrlTANTO.Length > 0 Then
        '                    Dim cmbTANTO As ComboboxEx = ctrlTANTO(0)
        '                    cmbTANTO.NullValue = 0
        '                    cmbTANTO.DataBindings.Add(New Binding(NameOf(cmbTANTO.SelectedValue), _D004_SYONIN_J_KANRI, NameOf(_D004_SYONIN_J_KANRI.SYAIN_ID), False, DataSourceUpdateMode.OnPropertyChanged, 0))
        '                End If
        '                Dim ctrlCOMMENT As Control() = Me.Controls.Find("txtST" & intCurrentTabNo.ToString("00") & "_Comment", True)
        '                If ctrlCOMMENT.Length > 0 Then
        '                    Dim txtCOMMENT As TextBoxEx = ctrlCOMMENT(0)
        '                    txtCOMMENT.DataBindings.Add(New Binding(NameOf(txtCOMMENT.Text), _D004_SYONIN_J_KANRI, NameOf(_D004_SYONIN_J_KANRI.COMMENT), False, DataSourceUpdateMode.OnPropertyChanged, ""))
        '                End If

        '            ElseIf intTabNo > intCurrentTabNo Then
        '                'SPEC: 10-2 ②
        '                _tabPageManager.ChangeTabPageVisible(page.TabIndex, False)
        '            End If

        '            'SPEC: 10-2.⑤
        '            If PrMODE = ENM_DATA_OPERATION_MODE._1_ADD Then
        '                '新規作成時
        '                'SPEC: (3).B
        '                page.Enabled = True
        '            Else
        '                If PrCurrentStage >= ENM_NCR_STAGE._90_処置実施確認_管理T Then
        '                    If Val(page.Name.Substring(8)) = intCurrentTabNo Then
        '                        page.Enabled = True
        '                    Else
        '                        page.EnableDisablePages(False, 2)
        '                        'page.Enabled = False
        '                    End If
        '                Else
        '                    'カレントユーザー以外は参照のみ
        '                    page.EnableDisablePages(FunblnOwnCreated(Context.ENM_SYONIN_HOKOKUSYO_ID._1_NCR, PrHOKOKU_NO, FunConvertSTAGE_NO_TO_SYONIN_JUN2(intTabNo)), 2)
        '                    'page.EnableDisablePages(FunblnOwnCreated(Context.ENM_SYONIN_HOKOKUSYO_ID._1_NCR, PrDataRow("HOKOKU_NO"), PrCurrentStage))
        '                End If
        '            End If
        '        End If
        '    Next page

        '    '添付資料タブ初期化
        '    Dim strRootDir As String
        '    Using DB As ClsDbUtility = DBOpen()
        '        strRootDir = FunConvPathString(FunGetCodeMastaValue(DB, "添付ファイル保存先", My.Application.Info.AssemblyName))
        '    End Using
        '    If Not _D003_NCR_J.FILE_PATH.IsNullOrWhiteSpace Then
        '        lbltmpFile1.Text = CompactString(_D003_NCR_J.FILE_PATH, lbltmpFile1, EllipsisFormat._4_Path)
        '        lbltmpFile1.Links.Clear()
        '        lbltmpFile1.Links.Add(0, lbltmpFile1.Text.Length, strRootDir & _D003_NCR_J.HOKOKU_NO.Trim & "\" & _D003_NCR_J.FILE_PATH)
        '        lbltmpFile1.Visible = True
        '        lbltmpFile1_Clear.Visible = True
        '    End If
        '    If Not _D003_NCR_J.G_FILE_PATH1.IsNullOrWhiteSpace Then
        '        Call SetPict1Data({strRootDir & _D003_NCR_J.HOKOKU_NO.Trim & "\" & _D003_NCR_J.G_FILE_PATH1})
        '    End If
        '    If Not _D003_NCR_J.G_FILE_PATH2.IsNullOrWhiteSpace Then
        '        Call SetPict2Data({strRootDir & _D003_NCR_J.HOKOKU_NO.Trim & "\" & _D003_NCR_J.G_FILE_PATH2})
        '    End If

        '    Return True
        'Catch ex As Exception
        '    EM.ErrorSyori(ex, False, conblnNonMsg)
        '    Return False
        'Finally
        'End Try
    End Function

#End Region

#Region "STAGE別コントロール初期化"

    Private Function FunInitializeSTAGE(ByVal intStageID As Integer) As Boolean
        Dim dt As New DataTable
        Dim _V003 As New MODEL.V003_SYONIN_J_KANRI
        Try

#Region "               10"

            If intStageID >= ENM_NCR_STAGE._10_起草入力 Then
                dt = FunGetSYONIN_SYOZOKU_SYAIN(_D003_NCR_J.BUMON_KB, Context.ENM_SYONIN_HOKOKUSYO_ID._1_NCR, FunGetNextSYONIN_JUN(ENM_NCR_STAGE._10_起草入力))
                cmbST01_DestTANTO.SetDataSource(dt, ENM_COMBO_SELECT_VALUE_TYPE._0_Required)

                mtxST01_NextStageName.Text = FunGetStageName(Context.ENM_SYONIN_HOKOKUSYO_ID._1_NCR, FunGetNextSYONIN_JUN(ENM_NCR_STAGE._10_起草入力))

                If PrMODE = ENM_DATA_OPERATION_MODE._3_UPDATE Then
                    _D003_NCR_J.YOKYU_NAIYO = _V002_NCR_J.YOKYU_NAIYO
                    _D003_NCR_J.KANSATU_KEKKA = _V002_NCR_J.KANSATU_KEKKA

                    _V003 = _V003_SYONIN_J_KANRI_List.AsEnumerable.
                                Where(Function(r) r.SYONIN_JUN = ENM_NCR_STAGE._10_起草入力).
                                FirstOrDefault

                    If _V003 IsNot Nothing Then
                        If Not _V003.RIYU.IsNullOrWhiteSpace And intStageID = ENM_NCR_STAGE._10_起草入力 Then lblST01_Modoshi_Riyu.Visible = True
                        If _V003.SASIMODOSI_FG Then
                            lblST01_Modoshi_Riyu.Text = "差戻理由：" & _V003.RIYU
                        Else
                            '転送時
                            lblST01_Modoshi_Riyu.Text = "転送理由：" & _V003.RIYU
                        End If
                        If _V003.SYONIN_YMDHNS.IsNullOrWhiteSpace Then
                            cmbST01_DestTANTO.SelectedValue = 0
                        Else
                            cmbST01_DestTANTO.SelectedValue = _V003.SYAIN_ID
                        End If
                        If intStageID >= ENM_NCR_STAGE._20_起草確認製造GL Then
                            cmbST01_DestTANTO.ReadOnly = True
                            txtST01_KEKKA.ReadOnly = True
                            txtST01_YOKYU_NAIYO.ReadOnly = True
                        End If
                        Dim dtSYONIN_YMD As Date
                        If DateTime.TryParseExact(_V003.SYONIN_YMDHNS, "yyyyMMddHHmmss", Nothing, Nothing, dtSYONIN_YMD) Then
                            If _V003.SYONIN_HANTEI_KB = ENM_SYONIN_HANTEI_KB._1_承認 Then
                                dtST01_UPD_YMD.ValueNonFormat = dtSYONIN_YMD.ToString("yyyyMMdd")
                                dtST01_UPD_YMD.ReadOnly = True
                            Else
                                '一時保存時の日付を読み込み 変更可能
                                _D004_SYONIN_J_KANRI.SYONIN_YMD = dtSYONIN_YMD.ToString("yyyyMMdd")
                            End If
                        Else
                            _D004_SYONIN_J_KANRI.SYONIN_YMD = Now.ToString("yyyyMMdd")
                        End If
                    Else
                        _D004_SYONIN_J_KANRI.SYONIN_YMD = Now.ToString("yyyyMMdd")
                    End If
                Else
                    _D004_SYONIN_J_KANRI.SYONIN_YMD = Now.ToString("yyyyMMdd")
                End If
            End If

#End Region

#Region "               20"

            If intStageID >= ENM_NCR_STAGE._20_起草確認製造GL Then
                dt = FunGetSYONIN_SYOZOKU_SYAIN(cmbBUMON.SelectedValue, Context.ENM_SYONIN_HOKOKUSYO_ID._1_NCR, FunGetNextSYONIN_JUN(ENM_NCR_STAGE._20_起草確認製造GL))
                cmbST02_DestTANTO.SetDataSource(dt, ENM_COMBO_SELECT_VALUE_TYPE._0_Required)

                mtxST02_NextStageName.Text = FunGetStageName(Context.ENM_SYONIN_HOKOKUSYO_ID._1_NCR, FunGetNextSYONIN_JUN(ENM_NCR_STAGE._20_起草確認製造GL))

                _V003 = _V003_SYONIN_J_KANRI_List.AsEnumerable.
                                Where(Function(r) r.SYONIN_JUN = ENM_NCR_STAGE._20_起草確認製造GL).
                                FirstOrDefault

                If _V003.SYONIN_YMDHNS.IsNullOrWhiteSpace Then
                    cmbST02_DestTANTO.SelectedValue = 0
                Else
                    cmbST02_DestTANTO.SelectedValue = _V003.SYAIN_ID
                End If
                txtST02_Comment.Text = _V003.COMMENT

                If _V003 IsNot Nothing Then
                    If Not _V003.RIYU.IsNullOrWhiteSpace And intStageID = ENM_NCR_STAGE._20_起草確認製造GL Then lblST02_Modoshi_Riyu.Visible = True
                    If _V003.SASIMODOSI_FG Then
                        lblST02_Modoshi_Riyu.Text = "差戻理由：" & _V003.RIYU
                    Else
                        '転送時
                        lblST02_Modoshi_Riyu.Text = "転送理由：" & _V003.RIYU
                    End If

                    Dim dtSYONIN_YMD As Date
                    If DateTime.TryParseExact(_V003.SYONIN_YMDHNS, "yyyyMMddHHmmss", Nothing, Nothing, dtSYONIN_YMD) Then
                        If _V003.SYONIN_HANTEI_KB = ENM_SYONIN_HANTEI_KB._1_承認 Then
                            dtST02_UPD_YMD.ValueNonFormat = dtSYONIN_YMD.ToString("yyyyMMdd")
                            dtST02_UPD_YMD.ReadOnly = True
                        Else
                            '一時保存時の日付を読み込み 変更可能
                            _D004_SYONIN_J_KANRI.SYONIN_YMD = dtSYONIN_YMD.ToString("yyyyMMdd")
                        End If
                    Else
                        _D004_SYONIN_J_KANRI.SYONIN_YMD = Now.ToString("yyyyMMdd")
                    End If

                    If intStageID > ENM_NCR_STAGE._20_起草確認製造GL Then
                        cmbST02_DestTANTO.ReadOnly = True
                        txtST02_Comment.ReadOnly = True
                    End If
                Else
                    _D004_SYONIN_J_KANRI.SYONIN_YMD = Now.ToString("yyyyMMdd")
                End If
            Else
                pnlST02.Visible = False
                rsbtnST02.Enabled = False
            End If

#End Region

#Region "               30"

            If intStageID >= ENM_NCR_STAGE._30_起草確認検査 Then
                dt = FunGetSYONIN_SYOZOKU_SYAIN(cmbBUMON.SelectedValue, Context.ENM_SYONIN_HOKOKUSYO_ID._1_NCR, FunGetNextSYONIN_JUN(ENM_NCR_STAGE._30_起草確認検査))
                cmbST03_DestTANTO.SetDataSource(dt, ENM_COMBO_SELECT_VALUE_TYPE._0_Required)

                mtxST03_NextStageName.Text = FunGetStageName(Context.ENM_SYONIN_HOKOKUSYO_ID._1_NCR, FunGetNextSYONIN_JUN(ENM_NCR_STAGE._30_起草確認検査))

                _V003 = _V003_SYONIN_J_KANRI_List.AsEnumerable.
                                Where(Function(r) r.SYONIN_JUN = ENM_NCR_STAGE._30_起草確認検査).
                                FirstOrDefault

                If _V003 IsNot Nothing Then
                    If _V003.SYONIN_YMDHNS.IsNullOrWhiteSpace Then
                        cmbST03_DestTANTO.SelectedValue = 0
                    Else
                        cmbST03_DestTANTO.SelectedValue = _V003.SYAIN_ID
                    End If
                    txtST03_Comment.Text = _V003.COMMENT

                    Dim dtSYONIN_YMD As Date
                    If DateTime.TryParseExact(_V003.SYONIN_YMDHNS, "yyyyMMddHHmmss", Nothing, Nothing, dtSYONIN_YMD) Then
                        If _V003.SYONIN_HANTEI_KB = ENM_SYONIN_HANTEI_KB._1_承認 Then
                            dtST03_UPD_YMD.ValueNonFormat = dtSYONIN_YMD.ToString("yyyyMMdd")
                            dtST03_UPD_YMD.ReadOnly = True
                        Else
                            '一時保存時の日付を読み込み 変更可能
                            _D004_SYONIN_J_KANRI.SYONIN_YMD = dtSYONIN_YMD.ToString("yyyyMMdd")
                        End If
                    Else
                        _D004_SYONIN_J_KANRI.SYONIN_YMD = Now.ToString("yyyyMMdd")
                    End If

                    If Not _V003.RIYU.IsNullOrWhiteSpace And intStageID = ENM_NCR_STAGE._30_起草確認検査 Then lblST03_Modoshi_Riyu.Visible = True

                    If _V003.SASIMODOSI_FG Then
                        lblST03_Modoshi_Riyu.Text = "差戻理由：" & _V003.RIYU
                    Else
                        '転送時
                        lblST03_Modoshi_Riyu.Text = "転送理由：" & _V003.RIYU
                    End If
                    If intStageID > ENM_NCR_STAGE._30_起草確認検査 Then
                        cmbST03_DestTANTO.ReadOnly = True
                        txtST03_Comment.ReadOnly = True
                    End If
                Else
                    _D004_SYONIN_J_KANRI.SYONIN_YMD = Now.ToString("yyyyMMdd")
                End If
            Else
                pnlST03.Visible = False
                rsbtnST03.Enabled = False
            End If

#End Region

#Region "               40"

            If intStageID >= ENM_NCR_STAGE._40_事前審査判定及びCAR要否判定 Then
                dt = FunGetSYONIN_SYOZOKU_SYAIN(cmbBUMON.SelectedValue, Context.ENM_SYONIN_HOKOKUSYO_ID._1_NCR, FunGetNextSYONIN_JUN(ENM_NCR_STAGE._40_事前審査判定及びCAR要否判定))
                cmbST04_DestTANTO.SetDataSource(dt, ENM_COMBO_SELECT_VALUE_TYPE._0_Required)

                mtxST04_NextStageName.Text = FunGetStageName(Context.ENM_SYONIN_HOKOKUSYO_ID._1_NCR, FunGetNextSYONIN_JUN(ENM_NCR_STAGE._40_事前審査判定及びCAR要否判定))

                cmbST04_JIZENSINSA_HANTEI.SetDataSource(tblJIZEN_SINSA_HANTEI_KB.ExcludeDeleted, ENM_COMBO_SELECT_VALUE_TYPE._0_Required)

                dt = FunGetSYONIN_SYOZOKU_SYAIN(_V002_NCR_J.BUMON_KB, Context.ENM_SYONIN_HOKOKUSYO_ID._1_NCR, ENM_NCR_STAGE._20_起草確認製造GL) 'FunGetSYOZOKU_SYAIN(_D003_NCR_J.BUMON_KB)
                cmbST04_HASSEI_KOTEI_GL_TANTO.SetDataSource(dt, ENM_COMBO_SELECT_VALUE_TYPE._2_Option)

                dt = FunGetSYONIN_SYOZOKU_SYAIN(_V002_NCR_J.BUMON_KB, Context.ENM_SYONIN_HOKOKUSYO_ID._2_CAR, ENM_CAR_STAGE._10_起草入力)
                cmbST04_CAR_TANTO.SetDataSource(dt, ENM_COMBO_SELECT_VALUE_TYPE._0_Required)

                '#73
                cmbST04_CAR_TANTO.SelectedValue = pub_SYAIN_INFO.SYAIN_ID
                Dim dsList As New DataSet
                Dim sbSQL As New System.Text.StringBuilder

                sbSQL.Remove(0, sbSQL.Length)
                sbSQL.Append($"SELECT {NameOf(MODEL.D004_SYONIN_J_KANRI.SYAIN_ID)} FROM {NameOf(MODEL.D004_SYONIN_J_KANRI)} ")
                sbSQL.Append($" WHERE {NameOf(MODEL.D004_SYONIN_J_KANRI.HOKOKU_NO)}='{_V002_NCR_J.HOKOKU_NO}'")
                sbSQL.Append($" AND {NameOf(MODEL.D004_SYONIN_J_KANRI.SYONIN_HOKOKUSYO_ID)}={Val(Context.ENM_SYONIN_HOKOKUSYO_ID._2_CAR)}")
                sbSQL.Append($" AND {NameOf(MODEL.D004_SYONIN_J_KANRI.SYONIN_JUN)}={Val(ENM_CAR_STAGE._10_起草入力)}")

                Using DB As ClsDbUtility = DBOpen()
                    dsList = DB.GetDataSet(sbSQL.ToString, conblnNonMsg)
                End Using
                If dsList.Tables(0).Rows.Count > 0 Then
                    cmbST04_CAR_TANTO.SelectedValue = dsList.Tables(0).Rows(0).Item(0)
                End If

                _V003 = _V003_SYONIN_J_KANRI_List.AsEnumerable.
                                Where(Function(r) r.SYONIN_JUN = ENM_NCR_STAGE._40_事前審査判定及びCAR要否判定).
                                FirstOrDefault

                _D003_NCR_J.JIZEN_SINSA_HANTEI_KB = _V002_NCR_J.JIZEN_SINSA_HANTEI_KB
                _D003_NCR_J.ZESEI_SYOCHI_YOHI_KB = CBool(_V002_NCR_J.ZESEI_SYOCHI_YOHI_KB)
                If _D003_NCR_J.ZESEI_SYOCHI_YOHI_KB Then
                    rbtnST04_ZESEI_YES.Checked = True
                Else
                    rbtnST04_ZESEI_NO.Checked = True
                End If

                _D003_NCR_J.ZESEI_NASI_RIYU = _V002_NCR_J.ZESEI_NASI_RIYU

                If _V003 IsNot Nothing Then
                    If _V003.SYONIN_YMDHNS.IsNullOrWhiteSpace Then
                        cmbST04_DestTANTO.SelectedValue = 0
                    Else
                        cmbST04_DestTANTO.SelectedValue = _V003.SYAIN_ID
                    End If
                    txtST04_Comment.Text = _V003.COMMENT
                    Dim dtSYONIN_YMD As Date
                    If DateTime.TryParseExact(_V003.SYONIN_YMDHNS, "yyyyMMddHHmmss", Nothing, Nothing, dtSYONIN_YMD) Then
                        If _V003.SYONIN_HANTEI_KB = ENM_SYONIN_HANTEI_KB._1_承認 Then
                            dtST04_UPD_YMD.ValueNonFormat = dtSYONIN_YMD.ToString("yyyyMMdd")
                            dtST04_UPD_YMD.ReadOnly = True
                        Else
                            '一時保存時の日付を読み込み 変更可能
                            _D004_SYONIN_J_KANRI.SYONIN_YMD = dtSYONIN_YMD.ToString("yyyyMMdd")
                        End If
                    Else
                        _D004_SYONIN_J_KANRI.SYONIN_YMD = Now.ToString("yyyyMMdd")
                    End If
                    If Not _V003.RIYU.IsNullOrWhiteSpace And intStageID = ENM_NCR_STAGE._40_事前審査判定及びCAR要否判定 Then lblST04_Modoshi_Riyu.Visible = True
                    If _V003.SASIMODOSI_FG Then
                        lblST04_Modoshi_Riyu.Text = "差戻理由：" & _V003.RIYU
                    Else
                        '転送時
                        lblST04_Modoshi_Riyu.Text = "転送理由：" & _V003.RIYU
                    End If

                    If intStageID > ENM_NCR_STAGE._40_事前審査判定及びCAR要否判定 Then
                        cmbST04_DestTANTO.ReadOnly = True
                        txtST04_Comment.ReadOnly = True
                        cmbST04_JIZENSINSA_HANTEI.ReadOnly = True
                        cmbST04_CAR_TANTO.ReadOnly = True
                        cmbST04_HASSEI_KOTEI_GL_TANTO.ReadOnly = True
                        pnlST04_ZESEI.Enabled = False
                    End If
                Else
                    _D004_SYONIN_J_KANRI.SYONIN_YMD = Now.ToString("yyyyMMdd")
                End If
            Else
                pnlST04.Visible = False
                rsbtnST04.Enabled = False
            End If

#End Region

#Region "               50"

            If intStageID >= ENM_NCR_STAGE._50_事前審査確認 Then
                dt = FunGetSYONIN_SYOZOKU_SYAIN(cmbBUMON.SelectedValue, Context.ENM_SYONIN_HOKOKUSYO_ID._1_NCR, FunGetNextSYONIN_JUN(ENM_NCR_STAGE._50_事前審査確認))
                cmbST05_DestTANTO.SetDataSource(dt, ENM_COMBO_SELECT_VALUE_TYPE._0_Required)

                mtxST05_NextStageName.Text = FunGetStageName(Context.ENM_SYONIN_HOKOKUSYO_ID._1_NCR, FunGetNextSYONIN_JUN(ENM_NCR_STAGE._50_事前審査確認))

                _V003 = _V003_SYONIN_J_KANRI_List.AsEnumerable.
                                Where(Function(r) r.SYONIN_JUN = ENM_NCR_STAGE._50_事前審査確認).
                                FirstOrDefault

                If _V003 IsNot Nothing Then
                    If _V003.SYONIN_YMDHNS.IsNullOrWhiteSpace Then
                        cmbST05_DestTANTO.SelectedValue = 0
                    Else
                        cmbST05_DestTANTO.SelectedValue = _V003.SYAIN_ID
                    End If
                    txtST05_Comment.Text = _V003.COMMENT
                    Dim dtSYONIN_YMD As Date
                    If DateTime.TryParseExact(_V003.SYONIN_YMDHNS, "yyyyMMddHHmmss", Nothing, Nothing, dtSYONIN_YMD) Then
                        If _V003.SYONIN_HANTEI_KB = ENM_SYONIN_HANTEI_KB._1_承認 Then
                            dtST05_UPD_YMD.ValueNonFormat = dtSYONIN_YMD.ToString("yyyyMMdd")
                            dtST05_UPD_YMD.ReadOnly = True
                        Else
                            '一時保存時の日付を読み込み 変更可能
                            _D004_SYONIN_J_KANRI.SYONIN_YMD = dtSYONIN_YMD.ToString("yyyyMMdd")
                        End If
                    Else
                        _D004_SYONIN_J_KANRI.SYONIN_YMD = Now.ToString("yyyyMMdd")
                    End If
                    If Not _V003.RIYU.IsNullOrWhiteSpace And intStageID = ENM_NCR_STAGE._50_事前審査確認 Then lblST05_Modoshi_Riyu.Visible = True
                    If _V003.SASIMODOSI_FG Then
                        lblST05_Modoshi_Riyu.Text = "差戻理由：" & _V003.RIYU
                    Else
                        '転送時
                        lblST05_Modoshi_Riyu.Text = "転送理由：" & _V003.RIYU
                    End If
                    If intStageID > ENM_NCR_STAGE._50_事前審査確認 Then
                        cmbST05_DestTANTO.ReadOnly = True
                        txtST05_Comment.ReadOnly = True
                    End If
                Else
                    _D004_SYONIN_J_KANRI.SYONIN_YMD = Now.ToString("yyyyMMdd")
                End If
            Else
                pnlST05.Visible = False
                rsbtnST05.Enabled = False
            End If

#End Region

#Region "               60"

            If intStageID >= ENM_NCR_STAGE._60_再審審査判定_技術代表 Then
                dt = FunGetSYONIN_SYOZOKU_SYAIN(cmbBUMON.SelectedValue, Context.ENM_SYONIN_HOKOKUSYO_ID._1_NCR, FunGetNextSYONIN_JUN(ENM_NCR_STAGE._60_再審審査判定_技術代表))
                cmbST06_DestTANTO.SetDataSource(dt, ENM_COMBO_SELECT_VALUE_TYPE._0_Required)

                mtxST06_NextStageName.Text = FunGetStageName(Context.ENM_SYONIN_HOKOKUSYO_ID._1_NCR, FunGetNextSYONIN_JUN(ENM_NCR_STAGE._60_再審審査判定_技術代表))
                cmbST06_SAISIN_IINKAI_HANTEI.SetDataSource(tblSAISIN_IINKAI_HANTEI_KB, ENM_COMBO_SELECT_VALUE_TYPE._0_Required)

                'SPEC: 60-2.③
                'cmbKISYU.ReadOnly = True
                'cmbSYANAI_CD.ReadOnly = True
                'cmbFUTEKIGO_STATUS.ReadOnly = True
                'cmbFUTEKIGO_KB.ReadOnly = True
                'cmbFUTEKIGO_S_KB.ReadOnly = True
                ''cmbBUMON.ReadOnly = True
                'mtxGOUKI.ReadOnly = True
                'cmbBUHIN_BANGO.ReadOnly = True
                'mtxHENKYAKU_RIYU.ReadOnly = True
                'cmbFUTEKIGO_S_KB.ReadOnly = True
                'cmbKISO_TANTO.ReadOnly = True
                'mtxHINMEI.ReadOnly = True
                'mtxZUBAN_KIKAKU.ReadOnly = True
                'numSU.Enabled = False

                _V003 = _V003_SYONIN_J_KANRI_List.AsEnumerable.
                                Where(Function(r) r.SYONIN_JUN = ENM_NCR_STAGE._60_再審審査判定_技術代表).
                                FirstOrDefault

                _D003_NCR_J.SAISIN_IINKAI_HANTEI_KB = _V002_NCR_J.SAISIN_IINKAI_HANTEI_KB
                _D003_NCR_J.SAISIN_IINKAI_SIRYO_NO = _V002_NCR_J.SAISIN_IINKAI_SIRYO_NO

                If _V003 IsNot Nothing Then
                    If _V003.SYONIN_YMDHNS.IsNullOrWhiteSpace Then
                        cmbST06_DestTANTO.SelectedValue = 0
                    Else
                        cmbST06_DestTANTO.SelectedValue = _V003.SYAIN_ID
                    End If
                    txtST06_Comment.Text = _V003.COMMENT
                    Dim dtSYONIN_YMD As Date
                    If DateTime.TryParseExact(_V003.SYONIN_YMDHNS, "yyyyMMddHHmmss", Nothing, Nothing, dtSYONIN_YMD) Then
                        If _V003.SYONIN_HANTEI_KB = ENM_SYONIN_HANTEI_KB._1_承認 Then
                            dtST06_UPD_YMD.ValueNonFormat = dtSYONIN_YMD.ToString("yyyyMMdd")
                            dtST06_UPD_YMD.ReadOnly = True
                        Else
                            '一時保存時の日付を読み込み 変更可能
                            _D004_SYONIN_J_KANRI.SYONIN_YMD = dtSYONIN_YMD.ToString("yyyyMMdd")
                        End If
                    Else
                        _D004_SYONIN_J_KANRI.SYONIN_YMD = Now.ToString("yyyyMMdd")
                    End If
                    If Not _V003.RIYU.IsNullOrWhiteSpace And intStageID = ENM_NCR_STAGE._60_再審審査判定_技術代表 Then lblST06_Modoshi_Riyu.Visible = True
                    If _V003.SASIMODOSI_FG Then
                        lblST06_Modoshi_Riyu.Text = "差戻理由：" & _V003.RIYU
                    Else
                        '転送時
                        lblST06_Modoshi_Riyu.Text = "転送理由：" & _V003.RIYU
                    End If
                    If intStageID > ENM_NCR_STAGE._60_再審審査判定_技術代表 Then
                        cmbST06_DestTANTO.ReadOnly = True
                        txtST06_Comment.ReadOnly = True
                    End If
                Else
                    _D004_SYONIN_J_KANRI.SYONIN_YMD = Now.ToString("yyyyMMdd")
                    pnlST06.Visible = False
                    rsbtnST06.Enabled = False
                    rsbtnST06.BackColor = Color.Silver
                End If
            Else
                pnlST06.Visible = False
                rsbtnST06.Enabled = False
            End If

#End Region

#Region "               61 7"

            If intStageID >= ENM_NCR_STAGE._61_再審審査判定_品証代表 Then
                If FunExistAchievement(Context.ENM_SYONIN_HOKOKUSYO_ID._1_NCR, _D003_NCR_J.HOKOKU_NO, ENM_NCR_STAGE._61_再審審査判定_品証代表) Then
                    dt = FunGetSYONIN_SYOZOKU_SYAIN(cmbBUMON.SelectedValue, Context.ENM_SYONIN_HOKOKUSYO_ID._1_NCR, FunGetNextSYONIN_JUN(ENM_NCR_STAGE._61_再審審査判定_品証代表))
                    cmbST07_DestTANTO.SetDataSource(dt, ENM_COMBO_SELECT_VALUE_TYPE._0_Required)

                    mtxST07_NextStageName.Text = FunGetStageName(Context.ENM_SYONIN_HOKOKUSYO_ID._1_NCR, FunGetNextSYONIN_JUN(ENM_NCR_STAGE._61_再審審査判定_品証代表))

                    _V003 = _V003_SYONIN_J_KANRI_List.AsEnumerable.
                                    Where(Function(r) r.SYONIN_JUN = ENM_NCR_STAGE._61_再審審査判定_品証代表).
                                    FirstOrDefault

                    _D003_NCR_J.SAISIN_IINKAI_HANTEI_KB = _V002_NCR_J.SAISIN_IINKAI_HANTEI_KB
                    _D003_NCR_J.SAISIN_IINKAI_SIRYO_NO = _V002_NCR_J.SAISIN_IINKAI_SIRYO_NO

                    If _V003 IsNot Nothing Then
                        If _V003.SYONIN_YMDHNS.IsNullOrWhiteSpace Then
                            cmbST07_DestTANTO.SelectedValue = 0
                        Else
                            cmbST07_DestTANTO.SelectedValue = _V003.SYAIN_ID
                        End If
                        txtST07_Comment.Text = _V003.COMMENT
                        Dim dtSYONIN_YMD As Date
                        If DateTime.TryParseExact(_V003.SYONIN_YMDHNS, "yyyyMMddHHmmss", Nothing, Nothing, dtSYONIN_YMD) Then
                            If _V003.SYONIN_HANTEI_KB = ENM_SYONIN_HANTEI_KB._1_承認 Then
                                dtST07_UPD_YMD.ValueNonFormat = dtSYONIN_YMD.ToString("yyyyMMdd")
                                dtST07_UPD_YMD.ReadOnly = True
                            Else
                                '一時保存時の日付を読み込み 変更可能
                                _D004_SYONIN_J_KANRI.SYONIN_YMD = dtSYONIN_YMD.ToString("yyyyMMdd")
                            End If
                        Else
                            _D004_SYONIN_J_KANRI.SYONIN_YMD = Now.ToString("yyyyMMdd")
                        End If
                        If Not _V003.RIYU.IsNullOrWhiteSpace And intStageID = ENM_NCR_STAGE._61_再審審査判定_品証代表 Then lblST07_Modoshi_Riyu.Visible = True
                        If _V003.SASIMODOSI_FG Then
                            lblST07_Modoshi_Riyu.Text = "差戻理由：" & _V003.RIYU
                        Else
                            '転送時
                            lblST07_Modoshi_Riyu.Text = "転送理由：" & _V003.RIYU
                        End If
                        If intStageID > ENM_NCR_STAGE._61_再審審査判定_品証代表 Then
                            cmbST07_DestTANTO.ReadOnly = True
                            txtST07_Comment.ReadOnly = True
                        End If
                    Else
                        _D004_SYONIN_J_KANRI.SYONIN_YMD = Now.ToString("yyyyMMdd")
                        pnlST07.Visible = False
                        rsbtnST07.Enabled = False
                        rsbtnST07.BackColor = Color.Silver
                    End If
                Else
                    '次ステージが取得出来ない場合=登録内容により処理がスキップされた場合等はタブごと非表示
                    'For Each page As TabPage In TabSTAGE.TabPages
                    '    If Val(page.Name.Substring(8)) = FunConvertSYONIN_JUN_TO_STAGE_NO(ENM_NCR_STAGE._61_再審審査判定_品証代表).ToString("00") Then
                    '        _tabPageManager.ChangeTabPageVisible(page.TabIndex, False)
                    '        Exit For
                    '    End If
                    'Next
                    pnlST07.Visible = False
                    rsbtnST07.Enabled = False
                    rsbtnST07.BackColor = Color.Silver
                End If
            Else
                pnlST07.Visible = False
                rsbtnST07.Enabled = False
            End If

#End Region

#Region "               70 8"

            If intStageID >= ENM_NCR_STAGE._70_顧客再審処置_I_tag Then
                If FunExistAchievement(Context.ENM_SYONIN_HOKOKUSYO_ID._1_NCR, _D003_NCR_J.HOKOKU_NO, ENM_NCR_STAGE._70_顧客再審処置_I_tag) Then
                    dt = FunGetSYONIN_SYOZOKU_SYAIN(cmbBUMON.SelectedValue, Context.ENM_SYONIN_HOKOKUSYO_ID._1_NCR, FunGetNextSYONIN_JUN(ENM_NCR_STAGE._70_顧客再審処置_I_tag))
                    cmbST08_DestTANTO.SetDataSource(dt, ENM_COMBO_SELECT_VALUE_TYPE._0_Required)
                    mtxST08_NextStageName.Text = FunGetStageName(Context.ENM_SYONIN_HOKOKUSYO_ID._1_NCR, FunGetNextSYONIN_JUN(ENM_NCR_STAGE._70_顧客再審処置_I_tag))

                    '部門所属社員取得
                    dt = FunGetSYOZOKU_SYAIN(_D003_NCR_J.BUMON_KB)

                    cmbST07_SAISIN_TANTO.SetDataSource(dt, ENM_COMBO_SELECT_VALUE_TYPE._0_Required)
                    cmbST07_KOKYAKU_HANTEI_SIJI.SetDataSource(tblKOKYAKU_HANTEI_SIJI_KB, ENM_COMBO_SELECT_VALUE_TYPE._0_Required)
                    cmbST07_KOKYAKU_SAISYU_HANTEI.SetDataSource(tblKOKYAKU_SAISYU_HANTEI_KB, ENM_COMBO_SELECT_VALUE_TYPE._0_Required)

                    _V003 = _V003_SYONIN_J_KANRI_List.AsEnumerable.
                                    Where(Function(r) r.SYONIN_JUN = ENM_NCR_STAGE._70_顧客再審処置_I_tag).
                                    FirstOrDefault

                    _D003_NCR_J.ITAG_NO = _V002_NCR_J.ITAG_NO
                    _D003_NCR_J.KOKYAKU_SAISIN_TANTO_ID = _V002_NCR_J.KOKYAKU_SAISIN_TANTO_ID
                    _D003_NCR_J.KOKYAKU_HANTEI_SIJI_KB = _V002_NCR_J.KOKYAKU_HANTEI_SIJI_KB
                    _D003_NCR_J.KOKYAKU_HANTEI_SIJI_YMD = _V002_NCR_J.KOKYAKU_HANTEI_SIJI_YMD
                    _D003_NCR_J.KOKYAKU_SAISYU_HANTEI_KB = _V002_NCR_J.KOKYAKU_SAISYU_HANTEI_KB
                    _D003_NCR_J.KOKYAKU_SAISYU_HANTEI_YMD = _V002_NCR_J.KOKYAKU_SAISYU_HANTEI_YMD
                    _D003_NCR_J.SAIKAKO_SIJI_FG = CBool(_V002_NCR_J.SAIKAKO_SIJI_FG)
                    If _D003_NCR_J.SAIKAKO_SIJI_FG Then
                        rbtnST07_Yes.Checked = True
                    Else
                        rbtnST07_No.Checked = True
                    End If

                    If _V003 IsNot Nothing Then
                        If _V003.SYONIN_YMDHNS.IsNullOrWhiteSpace Then
                            cmbST08_DestTANTO.SelectedValue = 0
                        Else
                            cmbST08_DestTANTO.SelectedValue = _V003.SYAIN_ID
                        End If
                        txtST08_Comment.Text = _V003.COMMENT
                        Dim dtSYONIN_YMD As Date
                        If DateTime.TryParseExact(_V003.SYONIN_YMDHNS, "yyyyMMddHHmmss", Nothing, Nothing, dtSYONIN_YMD) Then
                            If _V003.SYONIN_HANTEI_KB = ENM_SYONIN_HANTEI_KB._1_承認 Then
                                dtST08_UPD_YMD.ValueNonFormat = dtSYONIN_YMD.ToString("yyyyMMdd")
                                dtST08_UPD_YMD.ReadOnly = True
                            Else
                                '一時保存時の日付を読み込み 変更可能
                                _D004_SYONIN_J_KANRI.SYONIN_YMD = dtSYONIN_YMD.ToString("yyyyMMdd")
                            End If
                        Else
                            _D004_SYONIN_J_KANRI.SYONIN_YMD = Now.ToString("yyyyMMdd")
                        End If
                        If Not _V003.RIYU.IsNullOrWhiteSpace And intStageID = ENM_NCR_STAGE._70_顧客再審処置_I_tag Then lblST08_Modoshi_Riyu.Visible = True
                        If _V003.SASIMODOSI_FG Then
                            lblST08_Modoshi_Riyu.Text = "差戻理由：" & _V003.RIYU
                        Else
                            '転送時
                            lblST08_Modoshi_Riyu.Text = "転送理由：" & _V003.RIYU
                        End If
                        If intStageID > ENM_NCR_STAGE._70_顧客再審処置_I_tag Then
                            cmbST08_DestTANTO.ReadOnly = True
                            txtST08_Comment.ReadOnly = True
                        End If
                    Else
                        _D004_SYONIN_J_KANRI.SYONIN_YMD = Now.ToString("yyyyMMdd")
                        pnlST08.Visible = False
                        rsbtnST08.Enabled = False
                        rsbtnST08.BackColor = Color.Silver
                    End If
                Else
                    '次ステージが取得出来ない場合=登録内容により処理がスキップされた場合等はタブごと非表示
                    'For Each page As TabPage In TabSTAGE.TabPages
                    '    If Val(page.Name.Substring(8)) = FunConvertSYONIN_JUN_TO_STAGE_NO(ENM_NCR_STAGE._70_顧客再審処置_I_tag).ToString("00") Then
                    '        _tabPageManager.ChangeTabPageVisible(page.TabIndex, False)
                    '        Exit For
                    '    End If
                    'Next
                    pnlST08.Visible = False
                    rsbtnST08.Enabled = False
                    rsbtnST08.BackColor = Color.Silver
                End If
            Else
                pnlST08.Visible = False
                rsbtnST08.Enabled = False
            End If

#End Region

#Region "               80 9"

            '80
            If intStageID >= ENM_NCR_STAGE._80_処置実施 Then
                If FunExistAchievement(Context.ENM_SYONIN_HOKOKUSYO_ID._1_NCR, _D003_NCR_J.HOKOKU_NO, ENM_NCR_STAGE._80_処置実施) Then
                    dt = FunGetSYONIN_SYOZOKU_SYAIN(cmbBUMON.SelectedValue, Context.ENM_SYONIN_HOKOKUSYO_ID._1_NCR, FunGetNextSYONIN_JUN(ENM_NCR_STAGE._80_処置実施))
                    cmbST09_DestTANTO.SetDataSource(dt, ENM_COMBO_SELECT_VALUE_TYPE._0_Required)

                    mtxST09_NextStageName.Text = FunGetStageName(Context.ENM_SYONIN_HOKOKUSYO_ID._1_NCR, FunGetNextSYONIN_JUN(ENM_NCR_STAGE._80_処置実施))
                    cmbST08_1_HAIKYAKU_KB.SetDataSource(tblHAIKYAKU_KB, ENM_COMBO_SELECT_VALUE_TYPE._0_Required)
                    cmbST08_2_KENSA_KEKKA.SetDataSource(tblKENSA_KEKKA_KB, ENM_COMBO_SELECT_VALUE_TYPE._0_Required)

                    '部門所属社員取得
                    dt = FunGetSYOZOKU_SYAIN(_D003_NCR_J.BUMON_KB)
                    cmbST08_1_HAIKYAKU_TANTO.SetDataSource(dt, ENM_COMBO_SELECT_VALUE_TYPE._0_Required)
                    cmbST08_2_TANTO_SEIZO.SetDataSource(dt, ENM_COMBO_SELECT_VALUE_TYPE._2_Option)
                    cmbST08_2_TANTO_SEIGI.SetDataSource(dt, ENM_COMBO_SELECT_VALUE_TYPE._2_Option)
                    cmbST08_2_TANTO_KENSA.SetDataSource(dt, ENM_COMBO_SELECT_VALUE_TYPE._2_Option)
                    cmbST08_3_HENKYAKU_TANTO.SetDataSource(dt, ENM_COMBO_SELECT_VALUE_TYPE._0_Required)

                    Dim drs = tblKISYU.AsEnumerable.Where(Function(r) r.Field(Of String)(NameOf(_D003_NCR_J.BUMON_KB)) = _D003_NCR_J.BUMON_KB).ToList
                    If drs.Count > 0 Then
                        dt = drs.CopyToDataTable
                        cmbST08_4_KISYU.SetDataSource(dt, ENM_COMBO_SELECT_VALUE_TYPE._2_Option)
                        '_D003_NCR_J.KISYU_ID = 0
                    End If

                    drs = tblBUHIN.AsEnumerable.Where(Function(r) r.Field(Of String)(NameOf(_D003_NCR_J.BUMON_KB)) = _D003_NCR_J.BUMON_KB).ToList
                    If drs.Count > 0 Then
                        dt = drs.CopyToDataTable
                        cmbST08_4_BUHIN_BANGO.SetDataSource(dt, ENM_COMBO_SELECT_VALUE_TYPE._2_Option)
                        '_D003_NCR_J.BUHIN_BANGO = ""
                    End If

                    _V003 = _V003_SYONIN_J_KANRI_List.AsEnumerable.
                                    Where(Function(r) r.SYONIN_JUN = ENM_NCR_STAGE._80_処置実施).
                                    FirstOrDefault

                    _D003_NCR_J.HAIKYAKU_YMD = _V002_NCR_J.HAIKYAKU_YMD
                    _D003_NCR_J.HAIKYAKU_HOUHOU = _V002_NCR_J.HAIKYAKU_HOUHOU
                    _D003_NCR_J.HENKYAKU_BIKO = _V002_NCR_J.HENKYAKU_BIKO
                    _D003_NCR_J.HAIKYAKU_TANTO_ID = _V002_NCR_J.HAIKYAKU_TANTO_ID
                    _D003_NCR_J.SAIKAKO_SIJI_NO = _V002_NCR_J.SAIKAKO_SIJI_NO
                    _D003_NCR_J.SAIKAKO_SAGYO_KAN_YMD = _V002_NCR_J.SAIKAKO_SAGYO_KAN_YMD
                    _D003_NCR_J.SAIKAKO_KENSA_YMD = _V002_NCR_J.SAIKAKO_KENSA_YMD

                    _D003_NCR_J.KENSA_KEKKA_KB = _V002_NCR_J.KENSA_KEKKA_KB
                    _D003_NCR_J.SEIZO_TANTO_ID = _V002_NCR_J.SEIZO_TANTO_ID
                    _D003_NCR_J.SEIGI_TANTO_ID = _V002_NCR_J.SEIGI_TANTO_ID
                    _D003_NCR_J.KENSA_TANTO_ID = _V002_NCR_J.KENSA_TANTO_ID

                    _D003_NCR_J.HENKYAKU_YMD = _V002_NCR_J.HENKYAKU_YMD
                    _D003_NCR_J.HENKYAKU_SAKI = _V002_NCR_J.HENKYAKU_SAKI
                    _D003_NCR_J.HENKYAKU_BIKO = _V002_NCR_J.HENKYAKU_BIKO
                    _D003_NCR_J.HENKYAKU_TANTO_ID = _V002_NCR_J.HENKYAKU_TANTO_ID

                    _D003_NCR_J.TENYO_KISYU_ID = _V002_NCR_J.TENYO_KISYU_ID
                    _D003_NCR_J.TENYO_BUHIN_BANGO = _V002_NCR_J.TENYO_BUHIN_BANGO
                    _D003_NCR_J.TENYO_GOKI = _V002_NCR_J.TENYO_GOKI
                    _D003_NCR_J.TENYO_LOT = _V002_NCR_J.TENYO_LOT
                    _D003_NCR_J.TENYO_YMD = _V002_NCR_J.TENYO_YMD

                    If _V003 IsNot Nothing Then
                        If _V003.SYONIN_YMDHNS.IsNullOrWhiteSpace Then
                            cmbST09_DestTANTO.SelectedValue = 0
                        Else
                            cmbST09_DestTANTO.SelectedValue = _V003.SYAIN_ID
                        End If
                        txtST09_Comment.Text = _V003.COMMENT
                        Dim dtSYONIN_YMD As Date
                        If DateTime.TryParseExact(_V003.SYONIN_YMDHNS, "yyyyMMddHHmmss", Nothing, Nothing, dtSYONIN_YMD) Then
                            If _V003.SYONIN_HANTEI_KB = ENM_SYONIN_HANTEI_KB._1_承認 Then
                                dtST09_UPD_YMD.ValueNonFormat = dtSYONIN_YMD.ToString("yyyyMMdd")
                                dtST09_UPD_YMD.ReadOnly = True
                            Else
                                '一時保存時の日付を読み込み 変更可能
                                _D004_SYONIN_J_KANRI.SYONIN_YMD = dtSYONIN_YMD.ToString("yyyyMMdd")
                            End If
                        Else
                            _D004_SYONIN_J_KANRI.SYONIN_YMD = Now.ToString("yyyyMMdd")
                        End If
                        If Not _V003.RIYU.IsNullOrWhiteSpace And intStageID = ENM_NCR_STAGE._80_処置実施 Then lblST09_Modoshi_Riyu.Visible = True
                        If _V003.SASIMODOSI_FG Then
                            lblST09_Modoshi_Riyu.Text = "差戻理由：" & _V003.RIYU
                        Else
                            '転送時
                            lblST09_Modoshi_Riyu.Text = "転送理由：" & _V003.RIYU
                        End If
                        If intStageID > ENM_NCR_STAGE._80_処置実施 Then
                            'cmbST08_DestTANTO.ReadOnly = True
                            'txtST08_Comment.Enabled = False
                            tabST08_SUB.Enabled = False
                        End If
                    Else
                        _D004_SYONIN_J_KANRI.SYONIN_YMD = Now.ToString("yyyyMMdd")
                        pnlST09.Visible = False
                        rsbtnST09.Enabled = False
                        rsbtnST09.BackColor = Color.Silver
                    End If

                    'SPEC: 80-2.④
                    _tabPageManagerST08Sub = New TabPageManager(tabST08_SUB)
                    Dim strTabpageName As String
                    strTabpageName = FunGetST08SubPageName()
                    For Each page As TabPage In tabST08_SUB.TabPages
                        If page.Name = strTabpageName Then
                            tabST08_SUB.SelectedIndex = page.TabIndex
                        Else
                            '非表示
                            _tabPageManagerST08Sub.ChangeTabPageVisible(page.TabIndex, False)
                        End If
                    Next page
                Else
                    '次ステージが取得出来ない場合=登録内容により処理がスキップされた場合等はタブごと非表示
                    'For Each page As TabPage In TabSTAGE.TabPages
                    '    If Val(page.Name.Substring(8)) = FunConvertSYONIN_JUN_TO_STAGE_NO(ENM_NCR_STAGE._80_処置実施).ToString("00") Then
                    '        _tabPageManager.ChangeTabPageVisible(page.TabIndex, False)
                    '        Exit For
                    '    End If
                    'Next
                    pnlST09.Visible = False
                    rsbtnST09.Enabled = False
                    rsbtnST09.BackColor = Color.Silver
                End If
            Else
                pnlST09.Visible = False
                rsbtnST09.Enabled = False
            End If

            If intStageID > ENM_NCR_STAGE._80_処置実施 Then
                flpnlST08_SAIKAKO.Enabled = False
            End If

#End Region

#Region "旧 再加工ステージ"
            '#Region "               81 10"

            '            '81
            '            If intStageID >= ENM_NCR_STAGE._81_処置実施_生技 Then
            '                dt = FunGetSYONIN_SYOZOKU_SYAIN(cmbBUMON.SelectedValue, Context.ENM_SYONIN_HOKOKUSYO_ID._1_NCR, FunGetNextSYONIN_JUN(ENM_NCR_STAGE._81_処置実施_生技))
            '                cmbST10_DestTANTO.SetDataSource(dt, ENM_COMBO_SELECT_VALUE_TYPE._0_Required)

            '                mtxST10_NextStageName.Text = FunGetStageName(Context.ENM_SYONIN_HOKOKUSYO_ID._1_NCR, FunGetNextSYONIN_JUN(ENM_NCR_STAGE._81_処置実施_生技))

            '                If PrMODE = ENM_DATA_OPERATION_MODE._3_UPDATE Then
            '                    _V003 = _V003_SYONIN_J_KANRI_List.AsEnumerable.
            '                                Where(Function(r) r.SYONIN_JUN = ENM_NCR_STAGE._81_処置実施_生技).
            '                                FirstOrDefault

            '                    If _V003 IsNot Nothing Then
            '                        If _V003.SYONIN_YMDHNS.IsNullOrWhiteSpace Then
            '                            cmbST10_DestTANTO.SelectedValue = 0
            '                        Else
            '                            cmbST10_DestTANTO.SelectedValue = _V003.SYAIN_ID
            '                        End If
            '                        txtST10_Comment.Text = _V003.COMMENT
            '                        Dim dtSYONIN_YMD As Date
            '                        If DateTime.TryParseExact(_V003.SYONIN_YMDHNS, "yyyyMMddHHmmss", Nothing, Nothing, dtSYONIN_YMD) Then
            '                            dtST10_UPD_YMD.ValueNonFormat = dtSYONIN_YMD.ToString("yyyyMMdd")
            '                            dtST10_UPD_YMD.ReadOnly = True
            '                        Else
            '                            _D004_SYONIN_J_KANRI.SYONIN_YMD = Now.ToString("yyyyMMdd")
            '                        End If

            '                        If Not _V003.RIYU.IsNullOrWhiteSpace And intStageID = ENM_NCR_STAGE._81_処置実施_生技 Then lblST10_Modoshi_Riyu.Visible = True
            '                        If _V003.SASIMODOSI_FG Then
            '                            lblST10_Modoshi_Riyu.Text = "差戻理由：" & _V003.RIYU
            '                        Else
            '                            '転送時
            '                            lblST10_Modoshi_Riyu.Text = "転送理由：" & _V003.RIYU
            '                        End If
            '                    Else
            '                        pnlST10.Visible = False
            '                        rsbtnST10.Enabled = False
            '                        rsbtnST10.BackColor = Color.Silver
            '                    End If
            '                End If
            '            Else
            '                pnlST10.Visible = False
            '                rsbtnST10.Enabled = False
            '            End If

            '#End Region

            '#Region "               82 11"

            '            '82
            '            If intStageID >= ENM_NCR_STAGE._82_処置実施_製造 Then
            '                dt = FunGetSYONIN_SYOZOKU_SYAIN(cmbBUMON.SelectedValue, Context.ENM_SYONIN_HOKOKUSYO_ID._1_NCR, FunGetNextSYONIN_JUN(ENM_NCR_STAGE._82_処置実施_製造))
            '                cmbST11_DestTANTO.SetDataSource(dt, ENM_COMBO_SELECT_VALUE_TYPE._0_Required)

            '                mtxST11_NextStageName.Text = FunGetStageName(Context.ENM_SYONIN_HOKOKUSYO_ID._1_NCR, FunGetNextSYONIN_JUN(ENM_NCR_STAGE._82_処置実施_製造))

            '                If PrMODE = ENM_DATA_OPERATION_MODE._3_UPDATE Then
            '                    _V003 = _V003_SYONIN_J_KANRI_List.AsEnumerable.
            '                                Where(Function(r) r.SYONIN_JUN = ENM_NCR_STAGE._82_処置実施_製造).
            '                                FirstOrDefault

            '                    If _V003 IsNot Nothing Then
            '                        If _V003.SYONIN_YMDHNS.IsNullOrWhiteSpace Then
            '                            cmbST11_DestTANTO.SelectedValue = 0
            '                        Else
            '                            cmbST11_DestTANTO.SelectedValue = _V003.SYAIN_ID
            '                        End If
            '                        txtST11_Comment.Text = _V003.COMMENT
            '                        Dim dtSYONIN_YMD As Date
            '                        If DateTime.TryParseExact(_V003.SYONIN_YMDHNS, "yyyyMMddHHmmss", Nothing, Nothing, dtSYONIN_YMD) Then
            '                            dtST11_UPD_YMD.ValueNonFormat = dtSYONIN_YMD.ToString("yyyyMMdd")
            '                            dtST11_UPD_YMD.ReadOnly = True
            '                        Else
            '                            _D004_SYONIN_J_KANRI.SYONIN_YMD = Now.ToString("yyyyMMdd")
            '                        End If
            '                        If Not _V003.RIYU.IsNullOrWhiteSpace And intStageID = ENM_NCR_STAGE._82_処置実施_製造 Then lblST11_Modoshi_Riyu.Visible = True
            '                        If _V003.SASIMODOSI_FG Then
            '                            lblST11_Modoshi_Riyu.Text = "差戻理由：" & _V003.RIYU
            '                        Else
            '                            '転送時
            '                            lblST11_Modoshi_Riyu.Text = "転送理由：" & _V003.RIYU
            '                        End If
            '                    Else
            '                        pnlST11.Visible = False
            '                        rsbtnST11.Enabled = False
            '                        rsbtnST11.BackColor = Color.Silver
            '                    End If
            '                End If
            '            Else
            '                pnlST11.Visible = False
            '                rsbtnST11.Enabled = False
            '            End If

            '#End Region

            '#Region "               83 12"

            '            '83
            '            If intStageID >= ENM_NCR_STAGE._83_処置実施_検査 Then
            '                dt = FunGetSYONIN_SYOZOKU_SYAIN(cmbBUMON.SelectedValue, Context.ENM_SYONIN_HOKOKUSYO_ID._1_NCR, FunGetNextSYONIN_JUN(ENM_NCR_STAGE._83_処置実施_検査))
            '                cmbST12_DestTANTO.SetDataSource(dt, ENM_COMBO_SELECT_VALUE_TYPE._0_Required)

            '                mtxST12_NextStageName.Text = FunGetStageName(Context.ENM_SYONIN_HOKOKUSYO_ID._1_NCR, FunGetNextSYONIN_JUN(ENM_NCR_STAGE._83_処置実施_検査))

            '                If PrMODE = ENM_DATA_OPERATION_MODE._3_UPDATE Then
            '                    _V003 = _V003_SYONIN_J_KANRI_List.AsEnumerable.
            '                                Where(Function(r) r.SYONIN_JUN = ENM_NCR_STAGE._83_処置実施_検査).
            '                                FirstOrDefault

            '                    If _V003 IsNot Nothing Then
            '                        If _V003.SYONIN_YMDHNS.IsNullOrWhiteSpace Then
            '                            cmbST12_DestTANTO.SelectedValue = 0
            '                        Else
            '                            cmbST12_DestTANTO.SelectedValue = _V003.SYAIN_ID
            '                        End If
            '                        txtST12_Comment.Text = _V003.COMMENT
            '                        Dim dtSYONIN_YMD As Date
            '                        If DateTime.TryParseExact(_V003.SYONIN_YMDHNS, "yyyyMMddHHmmss", Nothing, Nothing, dtSYONIN_YMD) Then
            '                            dtST12_UPD_YMD.ValueNonFormat = dtSYONIN_YMD.ToString("yyyyMMdd")
            '                            dtST12_UPD_YMD.ReadOnly = True
            '                        Else
            '                            _D004_SYONIN_J_KANRI.SYONIN_YMD = Now.ToString("yyyyMMdd")
            '                        End If
            '                        If Not _V003.RIYU.IsNullOrWhiteSpace And intStageID = ENM_NCR_STAGE._83_処置実施_検査 Then lblST12_Modoshi_Riyu.Visible = True
            '                        If _V003.SASIMODOSI_FG Then
            '                            lblST12_Modoshi_Riyu.Text = "差戻理由：" & _V003.RIYU
            '                        Else
            '                            '転送時
            '                            lblST12_Modoshi_Riyu.Text = "転送理由：" & _V003.RIYU
            '                        End If
            '                    Else
            '                        pnlST12.Visible = False
            '                        rsbtnST12.Enabled = False
            '                        rsbtnST12.BackColor = Color.Silver
            '                    End If
            '                End If
            '            Else
            '                pnlST12.Visible = False
            '                rsbtnST12.Enabled = False
            '            End If

            '#End Region
#End Region

#Region "               90 13"

            If intStageID >= ENM_NCR_STAGE._90_処置実施確認_管理T Then
                dt = FunGetSYONIN_SYOZOKU_SYAIN(cmbBUMON.SelectedValue, Context.ENM_SYONIN_HOKOKUSYO_ID._1_NCR, FunGetNextSYONIN_JUN(ENM_NCR_STAGE._90_処置実施確認_管理T))
                cmbST13_DestTANTO.SetDataSource(dt, ENM_COMBO_SELECT_VALUE_TYPE._0_Required)

                mtxST13_NextStageName.Text = FunGetStageName(Context.ENM_SYONIN_HOKOKUSYO_ID._1_NCR, FunGetNextSYONIN_JUN(ENM_NCR_STAGE._90_処置実施確認_管理T))

                If PrMODE = ENM_DATA_OPERATION_MODE._3_UPDATE Then
                    _V003 = _V003_SYONIN_J_KANRI_List.AsEnumerable.
                                Where(Function(r) r.SYONIN_JUN = ENM_NCR_STAGE._90_処置実施確認_管理T).
                                FirstOrDefault

                    If _V003 IsNot Nothing Then
                        If _V003.SYONIN_YMDHNS.IsNullOrWhiteSpace Then
                            cmbST13_DestTANTO.SelectedValue = 0
                        Else
                            cmbST13_DestTANTO.SelectedValue = _V003.SYAIN_ID
                        End If
                        txtST13_Comment.Text = _V003.COMMENT
                        Dim dtSYONIN_YMD As Date
                        If DateTime.TryParseExact(_V003.SYONIN_YMDHNS, "yyyyMMddHHmmss", Nothing, Nothing, dtSYONIN_YMD) Then
                            If _V003.SYONIN_HANTEI_KB = ENM_SYONIN_HANTEI_KB._1_承認 Then
                                dtST13_UPD_YMD.ValueNonFormat = dtSYONIN_YMD.ToString("yyyyMMdd")
                                dtST13_UPD_YMD.ReadOnly = True
                            Else
                                '一時保存時の日付を読み込み 変更可能
                                _D004_SYONIN_J_KANRI.SYONIN_YMD = dtSYONIN_YMD.ToString("yyyyMMdd")
                            End If
                        Else
                            _D004_SYONIN_J_KANRI.SYONIN_YMD = Now.ToString("yyyyMMdd")
                        End If
                        If Not _V003.RIYU.IsNullOrWhiteSpace And intStageID = ENM_NCR_STAGE._90_処置実施確認_管理T Then lblST13_Modoshi_Riyu.Visible = True
                        If _V003.SASIMODOSI_FG Then
                            lblST13_Modoshi_Riyu.Text = "差戻理由：" & _V003.RIYU
                        Else
                            '転送時
                            lblST13_Modoshi_Riyu.Text = "転送理由：" & _V003.RIYU
                        End If
                        If intStageID > ENM_NCR_STAGE._90_処置実施確認_管理T Then
                            cmbST13_DestTANTO.ReadOnly = True
                            txtST13_Comment.ReadOnly = True
                        End If
                    Else
                        _D004_SYONIN_J_KANRI.SYONIN_YMD = Now.ToString("yyyyMMdd")
                    End If
                Else
                    pnlST13.Visible = False
                    rsbtnST13.Enabled = False
                    rsbtnST13.BackColor = Color.Silver
                End If
            Else
                pnlST13.Visible = False
                rsbtnST13.Enabled = False
            End If

#End Region

#Region "               100 14"

            If intStageID >= ENM_NCR_STAGE._100_処置実施決裁_製造課長 Then
                dt = FunGetSYONIN_SYOZOKU_SYAIN(cmbBUMON.SelectedValue, Context.ENM_SYONIN_HOKOKUSYO_ID._1_NCR, FunGetNextSYONIN_JUN(ENM_NCR_STAGE._100_処置実施決裁_製造課長))
                cmbST14_DestTANTO.SetDataSource(dt, ENM_COMBO_SELECT_VALUE_TYPE._0_Required)

                mtxST14_NextStageName.Text = FunGetStageName(Context.ENM_SYONIN_HOKOKUSYO_ID._1_NCR, FunGetNextSYONIN_JUN(ENM_NCR_STAGE._100_処置実施決裁_製造課長))

                If PrMODE = ENM_DATA_OPERATION_MODE._3_UPDATE Then
                    _V003 = _V003_SYONIN_J_KANRI_List.AsEnumerable.
                                Where(Function(r) r.SYONIN_JUN = ENM_NCR_STAGE._100_処置実施決裁_製造課長).
                                FirstOrDefault

                    If _V003 IsNot Nothing Then
                        If _V003.SYONIN_YMDHNS.IsNullOrWhiteSpace Then
                            cmbST14_DestTANTO.SelectedValue = 0
                        Else
                            cmbST14_DestTANTO.SelectedValue = _V003.SYAIN_ID
                        End If
                        txtST14_Comment.Text = _V003.COMMENT
                        Dim dtSYONIN_YMD As Date
                        If DateTime.TryParseExact(_V003.SYONIN_YMDHNS, "yyyyMMddHHmmss", Nothing, Nothing, dtSYONIN_YMD) Then
                            If _V003.SYONIN_HANTEI_KB = ENM_SYONIN_HANTEI_KB._1_承認 Then
                                dtST14_UPD_YMD.ValueNonFormat = dtSYONIN_YMD.ToString("yyyyMMdd")
                                dtST14_UPD_YMD.ReadOnly = True
                            Else
                                '一時保存時の日付を読み込み 変更可能
                                _D004_SYONIN_J_KANRI.SYONIN_YMD = dtSYONIN_YMD.ToString("yyyyMMdd")
                            End If
                        Else
                            _D004_SYONIN_J_KANRI.SYONIN_YMD = Now.ToString("yyyyMMdd")
                        End If

                        If Not _V003.RIYU.IsNullOrWhiteSpace And intStageID = ENM_NCR_STAGE._100_処置実施決裁_製造課長 Then lblST14_Modoshi_Riyu.Visible = True
                        If _V003.SASIMODOSI_FG Then
                            lblST14_Modoshi_Riyu.Text = "差戻理由：" & _V003.RIYU
                        Else
                            '転送時
                            lblST14_Modoshi_Riyu.Text = "転送理由：" & _V003.RIYU
                        End If
                        If intStageID > ENM_NCR_STAGE._100_処置実施決裁_製造課長 Then
                            cmbST14_DestTANTO.ReadOnly = True
                            txtST14_Comment.ReadOnly = True
                        End If
                    Else
                        _D004_SYONIN_J_KANRI.SYONIN_YMD = Now.ToString("yyyyMMdd")
                    End If
                End If
            Else
                pnlST14.Visible = False
                rsbtnST14.Enabled = False
            End If

#End Region

#Region "               110 15"

            If intStageID >= ENM_NCR_STAGE._110_abcde処置担当 Then
                dt = FunGetSYONIN_SYOZOKU_SYAIN(cmbBUMON.SelectedValue, Context.ENM_SYONIN_HOKOKUSYO_ID._1_NCR, FunGetNextSYONIN_JUN(ENM_NCR_STAGE._110_abcde処置担当))
                cmbST15_DestTANTO.SetDataSource(dt, ENM_COMBO_SELECT_VALUE_TYPE._0_Required)

                mtxST15_NextStageName.Text = FunGetStageName(Context.ENM_SYONIN_HOKOKUSYO_ID._1_NCR, FunGetNextSYONIN_JUN(ENM_NCR_STAGE._110_abcde処置担当))

                '#90
                Dim blnDISP As Boolean = (_D003_NCR_J.JIZEN_SINSA_HANTEI_KB.ToVal = ENM_JIZEN_SINSA_HANTEI_KB._4_廃却する)
                lblSYOCHI_C_1.Visible = blnDISP
                lblSYOCHI_C_2.Visible = blnDISP
                pnlSYOCHI_C.Visible = blnDISP

                If PrMODE = ENM_DATA_OPERATION_MODE._3_UPDATE Then
                    _V003 = _V003_SYONIN_J_KANRI_List.AsEnumerable.
                                Where(Function(r) r.SYONIN_JUN = ENM_NCR_STAGE._110_abcde処置担当).
                                FirstOrDefault

                    _D003_NCR_J.SYOCHI_KEKKA_A = CBool(_V002_NCR_J.SYOCHI_KEKKA_A)
                    If _D003_NCR_J.SYOCHI_KEKKA_A Then
                        rbtnST11_A1_T.Checked = True
                    Else
                        rbtnST11_A1_F.Checked = True
                    End If

                    _D003_NCR_J.SYOCHI_KEKKA_B = CBool(_V002_NCR_J.SYOCHI_KEKKA_B)
                    If _D003_NCR_J.SYOCHI_KEKKA_B Then
                        rbtnST11_B1_T.Checked = True
                    Else
                        rbtnST11_B1_F.Checked = True
                    End If

                    _D003_NCR_J.SYOCHI_KEKKA_C = CBool(_V002_NCR_J.SYOCHI_KEKKA_C)
                    If _D003_NCR_J.SYOCHI_KEKKA_C Then
                        rbtnST11_C1_T.Checked = True
                    Else
                        rbtnST11_C1_F.Checked = True
                    End If

                    _D003_NCR_J.SYOCHI_D_UMU_KB = CBool(_V002_NCR_J.SYOCHI_D_UMU_KB)
                    If _D003_NCR_J.SYOCHI_D_UMU_KB Then
                        rbtnST11_D1_T.Checked = True
                    Else
                        rbtnST11_D1_F.Checked = True
                    End If

                    _D003_NCR_J.SYOCHI_D_YOHI_KB = CBool(_V002_NCR_J.SYOCHI_E_YOHI_KB)
                    If _D003_NCR_J.SYOCHI_E_YOHI_KB Then
                        rbtnST11_D2_T.Checked = True
                    Else
                        rbtnST11_D2_F.Checked = True
                    End If

                    _D003_NCR_J.SYOCHI_D_SYOCHI_KIROKU = _V002_NCR_J.SYOCHI_D_SYOCHI_KIROKU

                    _D003_NCR_J.SYOCHI_E_UMU_KB = CBool(_V002_NCR_J.SYOCHI_D_UMU_KB)
                    If _D003_NCR_J.SYOCHI_D_UMU_KB Then
                        rbtnST11_E1_T.Checked = True
                    Else
                        rbtnST11_E1_F.Checked = True
                    End If

                    _D003_NCR_J.SYOCHI_E_YOHI_KB = CBool(_V002_NCR_J.SYOCHI_E_YOHI_KB)
                    If _D003_NCR_J.SYOCHI_E_YOHI_KB Then
                        rbtnST11_E2_T.Checked = True
                    Else
                        rbtnST11_E2_F.Checked = True
                    End If

                    _D003_NCR_J.SYOCHI_E_SYOCHI_KIROKU = _V002_NCR_J.SYOCHI_E_SYOCHI_KIROKU

                    If _V003 IsNot Nothing Then
                        If _V003.SYONIN_YMDHNS.IsNullOrWhiteSpace Then
                            cmbST15_DestTANTO.SelectedValue = 0
                        Else
                            cmbST15_DestTANTO.SelectedValue = _V003.SYAIN_ID
                        End If
                        txtST15_Comment.Text = _V003.COMMENT
                        Dim dtSYONIN_YMD As Date
                        If DateTime.TryParseExact(_V003.SYONIN_YMDHNS, "yyyyMMddHHmmss", Nothing, Nothing, dtSYONIN_YMD) Then
                            If _V003.SYONIN_HANTEI_KB = ENM_SYONIN_HANTEI_KB._1_承認 Then
                                dtST15_UPD_YMD.ValueNonFormat = dtSYONIN_YMD.ToString("yyyyMMdd")
                                dtST15_UPD_YMD.ReadOnly = True
                            Else
                                '一時保存時の日付を読み込み 変更可能
                                _D004_SYONIN_J_KANRI.SYONIN_YMD = dtSYONIN_YMD.ToString("yyyyMMdd")
                            End If
                        Else
                            _D004_SYONIN_J_KANRI.SYONIN_YMD = Now.ToString("yyyyMMdd")
                        End If
                        If Not _V003.RIYU.IsNullOrWhiteSpace And intStageID = ENM_NCR_STAGE._110_abcde処置担当 Then lblST15_Modoshi_Riyu.Visible = True
                        If _V003.SASIMODOSI_FG Then
                            lblST15_Modoshi_Riyu.Text = "差戻理由：" & _V003.RIYU
                        Else
                            '転送時
                            lblST15_Modoshi_Riyu.Text = "転送理由：" & _V003.RIYU
                        End If
                        If intStageID > ENM_NCR_STAGE._110_abcde処置担当 Then
                            cmbST15_DestTANTO.ReadOnly = True
                            txtST15_Comment.ReadOnly = True
                            pnlSYOCHI_A.Enabled = False
                            pnlSYOCHI_B.Enabled = False
                            pnlSYOCHI_C.Enabled = False
                            pnlSYOCHI_D1.Enabled = False
                            pnlSYOCHI_D2.Enabled = False
                            pnlSYOCHI_E1.Enabled = False
                            pnlSYOCHI_E2.Enabled = False
                        End If
                    Else
                        _D004_SYONIN_J_KANRI.SYONIN_YMD = Now.ToString("yyyyMMdd")
                    End If
                End If
            Else
                pnlST15.Visible = False
                rsbtnST15.Enabled = False
            End If

#End Region

#Region "               120 16"

            If intStageID >= ENM_NCR_STAGE._120_abcde処置確認 Then
                _D004_SYONIN_J_KANRI.SYAIN_ID = pub_SYAIN_INFO.SYAIN_ID

                btnST16_SYONIN.Enabled = FunblnOwnCreated(Context.ENM_SYONIN_HOKOKUSYO_ID._1_NCR, PrHOKOKU_NO, ENM_NCR_STAGE._120_abcde処置確認)
            Else
                pnlST16.Visible = False
                rsbtnST16.Enabled = False
                btnST16_SYONIN.Enabled = False
            End If

#End Region

#Region "               999 close"

            If intStageID = ENM_NCR_STAGE._999_Closed Then
                rsbtnST99.Enabled = True
            Else
                rsbtnST99.Enabled = False
            End If

#End Region

            Return True
        Catch ex As Exception
            EM.ErrorSyori(ex, False, conblnNonMsg)
            Return False
        Finally

        End Try
    End Function

    ''' <summary>
    ''' ステージ80内タブの判定
    ''' </summary>
    ''' <returns></returns>
    Private Function FunGetST08SubPageName() As String
        Select Case _D003_NCR_J.KOKYAKU_SAISYU_HANTEI_KB
            Case ENM_KOKYAKU_SAISYU_HANTEI_KB._3_廃却する
                Return "tabSTAGE08_" & ENM_NCR_STAGE80_TABPAGES._1_廃却実施記録
            Case ENM_KOKYAKU_SAISYU_HANTEI_KB._4_返却する
                Return "tabSTAGE08_" & ENM_NCR_STAGE80_TABPAGES._3_返却実施記録
            Case ENM_KOKYAKU_SAISYU_HANTEI_KB._5_転用する
                Return "tabSTAGE08_" & ENM_NCR_STAGE80_TABPAGES._4_転用先記録
            Case ENM_KOKYAKU_SAISYU_HANTEI_KB._6_再加工する
                Return "tabSTAGE08_" & ENM_NCR_STAGE80_TABPAGES._2_再加工指示_記録
            Case Else
                Select Case _D003_NCR_J.SAISIN_IINKAI_HANTEI_KB
                    Case ENM_SAISIN_IINKAI_HANTEI_KB._3_廃却する
                        Return "tabSTAGE08_" & ENM_NCR_STAGE80_TABPAGES._1_廃却実施記録
                    Case ENM_SAISIN_IINKAI_HANTEI_KB._4_返却する
                        Return "tabSTAGE08_" & ENM_NCR_STAGE80_TABPAGES._3_返却実施記録
                    Case ENM_SAISIN_IINKAI_HANTEI_KB._5_転用する
                        Return "tabSTAGE08_" & ENM_NCR_STAGE80_TABPAGES._4_転用先記録
                    Case ENM_SAISIN_IINKAI_HANTEI_KB._6_再加工する
                        Return "tabSTAGE08_" & ENM_NCR_STAGE80_TABPAGES._2_再加工指示_記録
                    Case Else
                        Select Case _D003_NCR_J.JIZEN_SINSA_HANTEI_KB
                            Case ENM_JIZEN_SINSA_HANTEI_KB._4_廃却する
                                Return "tabSTAGE08_" & ENM_NCR_STAGE80_TABPAGES._1_廃却実施記録
                            Case ENM_JIZEN_SINSA_HANTEI_KB._5_返却する
                                Return "tabSTAGE08_" & ENM_NCR_STAGE80_TABPAGES._3_返却実施記録
                            Case ENM_JIZEN_SINSA_HANTEI_KB._6_転用する
                                Return "tabSTAGE08_" & ENM_NCR_STAGE80_TABPAGES._4_転用先記録
                            Case ENM_JIZEN_SINSA_HANTEI_KB._7_再加工する
                                Return "tabSTAGE08_" & ENM_NCR_STAGE80_TABPAGES._2_再加工指示_記録
                            Case Else
                                'Err
                                Throw New ArgumentException("80-2.④ JIZEN_SINSA_HANTEI_KB")
                        End Select
                End Select
        End Select
    End Function

#End Region

#Region "タブイベント"

    Private Sub TabSTAGE_SelectedIndexChanged(sender As Object, e As EventArgs) Handles TabSTAGE.SelectedIndexChanged
        Call FunInitFuncButtonEnabled()
    End Sub

#End Region

#End Region

#Region "共通"

#Region "ステージリスト"

    Private Sub RsbtnST_CheckedChanged(sender As Object, e As EventArgs) Handles rsbtnST01.CheckedChanged,
                                                                        rsbtnST02.CheckedChanged,
                                                                        rsbtnST03.CheckedChanged,
                                                                        rsbtnST04.CheckedChanged,
                                                                        rsbtnST05.CheckedChanged,
                                                                        rsbtnST06.CheckedChanged,
                                                                        rsbtnST07.CheckedChanged,
                                                                        rsbtnST08.CheckedChanged,
                                                                        rsbtnST09.CheckedChanged,
                                                                        rsbtnST13.CheckedChanged,
                                                                        rsbtnST14.CheckedChanged,
                                                                        rsbtnST15.CheckedChanged,
                                                                        rsbtnST16.CheckedChanged

        Dim btn As RibbonShapeRadioButton = DirectCast(sender, RibbonShapeRadioButton)
        Dim intStageID As Integer = Val(btn.Name.Substring(7))
        tabSTAGE01.AutoScrollControlIntoView = True
        Dim pnl As PanelEx = DirectCast(tabSTAGE01.Controls("pnlST" & intStageID.ToString("00")), PanelEx)
        Me.tabSTAGE01.ScrollControlIntoView(pnl.Controls("lblSTAGEFlame" & intStageID.ToString("00")))
        tabSTAGE01.AutoScrollControlIntoView = False

        For Each ctrl As Control In tabSTAGE01.Controls
            If ctrl.GetType Is GetType(PanelEx) Then
                Dim panel As PanelEx = DirectCast(ctrl, PanelEx)
                If panel.Name = "pnlST" & intStageID.ToString("00") Then
                    panel.BorderStyle = BorderStyle.FixedSingle
                Else
                    panel.BorderStyle = BorderStyle.None
                End If
            End If
        Next ctrl

    End Sub

#End Region

#Region "部門区分"

    'DEBUG: selectedvaluechange → validated

    Private Sub CmbBUMON_SelectedValueChanged(sender As Object, e As EventArgs) Handles cmbBUMON.SelectedValueChanged
        Dim cmb As ComboboxEx = DirectCast(sender, ComboboxEx)

        Select Case cmb.SelectedValue?.ToString.Trim
            Case ""
            Case Context.ENM_BUMON_KB._2_LP
                lblSYANAI_CD.Visible = True
                cmbSYANAI_CD.Visible = True
                cmbSYANAI_CD.GotFocusedColor = Color.Orange
                cmbHINMEI.ReadOnly = False
                Me.ActiveControl = cmbSYANAI_CD

                Dim tblLP_HINMEI As New DataTableEx
                Using DB As ClsDbUtility = DBOpen()
                    Call FunGetCodeDataTable(DB, "LP部品名称", tblLP_HINMEI)
                End Using
                cmbHINMEI.SetDataSource(tblLP_HINMEI, ENM_COMBO_SELECT_VALUE_TYPE._0_Required)

            Case Else
                lblSYANAI_CD.Visible = False
                cmbSYANAI_CD.Visible = False
                cmbHINMEI.ReadOnly = True
                Me.ActiveControl = cmbKISYU
        End Select
        If PrMODE = ENM_DATA_OPERATION_MODE._1_ADD Then
            Dim dtTANTO = FunGetSYONIN_SYOZOKU_SYAIN(cmb.SelectedValue, Context.ENM_SYONIN_HOKOKUSYO_ID._1_NCR, FunGetNextSYONIN_JUN(ENM_NCR_STAGE._10_起草入力))
            cmbST01_DestTANTO.SetDataSource(dtTANTO, ENM_COMBO_SELECT_VALUE_TYPE._0_Required)
        End If

        Dim blnSelected As Boolean = (cmb.SelectedValue IsNot Nothing AndAlso Not cmb.SelectedValue.ToString.IsNullOrWhiteSpace)

        '機種
        RemoveHandler cmbKISYU.SelectedValueChanged, AddressOf CmbKISYU_SelectedValueChanged
        cmbKISYU.DataBindings.Clear()
        If blnSelected Then
            Dim drs = tblKISYU.AsEnumerable.Where(Function(r) r.Field(Of String)(NameOf(_D003_NCR_J.BUMON_KB)) = cmb.SelectedValue).ToList
            If drs.Count > 0 Then
                Dim dt As DataTable = drs.CopyToDataTable
                cmbKISYU.SetDataSource(dt, ENM_COMBO_SELECT_VALUE_TYPE._0_Required)
                _D003_NCR_J.KISYU_ID = 0
            End If
        Else
            cmbKISYU.SetDataSource(tblKISYU.ExcludeDeleted, ENM_COMBO_SELECT_VALUE_TYPE._0_Required)
        End If
        AddHandler cmbKISYU.SelectedValueChanged, AddressOf CmbKISYU_SelectedValueChanged
        cmbKISYU.DataBindings.Add(New Binding(NameOf(cmbKISYU.SelectedValue), _D003_NCR_J, NameOf(_D003_NCR_J.KISYU_ID), False, DataSourceUpdateMode.OnPropertyChanged, 0))

        '部品番号
        RemoveHandler cmbBUHIN_BANGO.SelectedValueChanged, AddressOf CmbBUHIN_BANGO_SelectedValueChanged
        cmbBUHIN_BANGO.DataBindings.Clear()
        If blnSelected Then
            Dim drs = tblBUHIN.AsEnumerable.Where(Function(r) r.Field(Of String)(NameOf(_D003_NCR_J.BUMON_KB)) = cmb.SelectedValue).ToList
            If drs.Count > 0 Then
                Dim dt As DataTable = drs.CopyToDataTable
                cmbBUHIN_BANGO.SetDataSource(dt, ENM_COMBO_SELECT_VALUE_TYPE._0_Required)
                _D003_NCR_J.BUHIN_BANGO = ""
            End If
        Else
            cmbBUHIN_BANGO.SetDataSource(tblBUHIN.ExcludeDeleted, ENM_COMBO_SELECT_VALUE_TYPE._0_Required)
        End If
        AddHandler cmbBUHIN_BANGO.SelectedValueChanged, AddressOf CmbBUHIN_BANGO_SelectedValueChanged
        cmbBUHIN_BANGO.DataBindings.Add(New Binding(NameOf(cmbBUHIN_BANGO.SelectedValue), _D003_NCR_J, NameOf(_D003_NCR_J.BUHIN_BANGO), False, DataSourceUpdateMode.OnPropertyChanged, ""))

        '社内コード
        RemoveHandler cmbSYANAI_CD.SelectedValueChanged, AddressOf CmbSYANAI_CD_SelectedValueChanged
        cmbSYANAI_CD.DataBindings.Clear()
        If blnSelected Then
            If Val(cmb.SelectedValue) = Context.ENM_BUMON_KB._2_LP Then
                Dim drs = tblSYANAI_CD.AsEnumerable.Where(Function(r) r.Field(Of String)(NameOf(_D003_NCR_J.BUMON_KB)) = cmb.SelectedValue).ToList
                If drs.Count > 0 Then
                    Dim dt As DataTable = drs.CopyToDataTable
                    cmbSYANAI_CD.DisplayMember = "DISP"
                    cmbSYANAI_CD.ValueMember = "VALUE"
                    cmbSYANAI_CD.SetDataSource(dt, ENM_COMBO_SELECT_VALUE_TYPE._0_Required)
                End If
            Else
                'cmbSYANAI_CD.DataSource = Nothing
            End If
            _D003_NCR_J.SYANAI_CD = ""
        Else
            cmbSYANAI_CD.SetDataSource(tblSYANAI_CD.ExcludeDeleted, ENM_COMBO_SELECT_VALUE_TYPE._0_Required)
        End If
        AddHandler cmbSYANAI_CD.SelectedValueChanged, AddressOf CmbSYANAI_CD_SelectedValueChanged
        cmbSYANAI_CD.DataBindings.Add(New Binding(NameOf(cmbSYANAI_CD.SelectedValue), _D003_NCR_J, NameOf(_D003_NCR_J.SYANAI_CD), False, DataSourceUpdateMode.OnPropertyChanged, ""))
    End Sub

    Private Sub CmbBUMON_Validating(sender As Object, e As System.ComponentModel.CancelEventArgs) Handles cmbBUMON.Validating
        Dim cmb As ComboboxEx = DirectCast(sender, ComboboxEx)

        IsValidated *= ErrorProvider.UpdateErrorInfo(cmb, cmb.IsSelected, String.Format(My.Resources.infoMsgRequireSelectOrInput, "製品区分"))

    End Sub

#End Region

#Region "機種"

    Private Sub CmbKISYU_SelectedValueChanged(sender As Object, e As EventArgs) Handles cmbKISYU.SelectedValueChanged
        Dim cmb As ComboboxEx = DirectCast(sender, ComboboxEx)
        Dim blnSelected As Boolean = (cmb.SelectedValue IsNot Nothing AndAlso Not cmb.SelectedValue.ToString.IsNullOrWhiteSpace)

        cmbSYANAI_CD.ValueMember = "VALUE"
        cmbSYANAI_CD.DisplayMember = "DISP"

        '部品番号
        RemoveHandler cmbBUHIN_BANGO.SelectedValueChanged, AddressOf CmbBUHIN_BANGO_SelectedValueChanged
        If blnSelected Then
            Dim drs = tblBUHIN.AsEnumerable.Where(Function(r) r.Field(Of Integer)(NameOf(_D003_NCR_J.KISYU_ID)) = cmb.SelectedValue).ToList
            If drs.Count > 0 Then
                Dim dt As DataTable = drs.CopyToDataTable
                Dim _selectedValue As String = cmbBUHIN_BANGO.SelectedValue

                cmbBUHIN_BANGO.SetDataSource(dt, ENM_COMBO_SELECT_VALUE_TYPE._0_Required)
                If Not cmbBUHIN_BANGO.NullValue = _selectedValue Then
                    _D003_NCR_J.BUHIN_BANGO = _selectedValue
                End If
            Else
                drs = tblBUHIN.AsEnumerable.Where(Function(r) r.Field(Of String)(NameOf(_D003_NCR_J.BUMON_KB)) = cmbBUMON.SelectedValue).ToList
                If drs.Count > 0 Then
                    cmbBUHIN_BANGO.SetDataSource(drs.CopyToDataTable, ENM_COMBO_SELECT_VALUE_TYPE._0_Required)
                End If
            End If
        Else
            Dim drs = tblBUHIN.AsEnumerable.Where(Function(r) r.Field(Of String)(NameOf(_D003_NCR_J.BUMON_KB)) = cmbBUMON.SelectedValue).ToList
            If drs.Count > 0 Then
                cmbBUHIN_BANGO.SetDataSource(drs.CopyToDataTable, ENM_COMBO_SELECT_VALUE_TYPE._0_Required)
            End If
        End If
        AddHandler cmbBUHIN_BANGO.SelectedValueChanged, AddressOf CmbBUHIN_BANGO_SelectedValueChanged

        '社内コード
        RemoveHandler cmbSYANAI_CD.SelectedValueChanged, AddressOf CmbSYANAI_CD_SelectedValueChanged
        If blnSelected Then
            If Val(cmb.SelectedValue) = Context.ENM_BUMON_KB._2_LP Then
                Dim drs = tblSYANAI_CD.AsEnumerable.Where(Function(r) r.Field(Of Integer)(NameOf(_D003_NCR_J.KISYU_ID)) = cmb.SelectedValue).ToList
                If drs.Count > 0 Then
                    Dim dt As DataTable = drs.CopyToDataTable
                    Dim _selectedValue As String = cmbSYANAI_CD.SelectedValue
                    cmbSYANAI_CD.SetDataSource(dt, ENM_COMBO_SELECT_VALUE_TYPE._1_Filter)
                    If Not cmbSYANAI_CD.NullValue = _selectedValue Then
                        _D003_NCR_J.SYANAI_CD = _selectedValue
                    End If
                End If
            Else
                'cmbSYANAI_CD.DataSource = Nothing
            End If
            _D003_NCR_J.SYANAI_CD = ""
        Else
            Dim drs = tblSYANAI_CD.AsEnumerable.Where(Function(r) r.Field(Of String)(NameOf(_D003_NCR_J.BUMON_KB)) = cmbBUMON.SelectedValue).ToList
            If drs.Count > 0 Then
                cmbSYANAI_CD.SetDataSource(drs.CopyToDataTable, ENM_COMBO_SELECT_VALUE_TYPE._0_Required)
            End If
        End If
        AddHandler cmbSYANAI_CD.SelectedValueChanged, AddressOf CmbSYANAI_CD_SelectedValueChanged
    End Sub

    Private Sub CmbKISYU_Validating(sender As Object, e As System.ComponentModel.CancelEventArgs) Handles cmbKISYU.Validating
        Dim cmb As ComboboxEx = DirectCast(sender, ComboboxEx)

        IsValidated *= ErrorProvider.UpdateErrorInfo(cmb, cmb.IsSelected, String.Format(My.Resources.infoMsgRequireSelectOrInput, "機種"))


    End Sub

#End Region

#Region "社内コード"

    Private Sub CmbSYANAI_CD_SelectedValueChanged(sender As Object, e As EventArgs)
        Try
            Dim cmb As ComboboxEx = DirectCast(sender, ComboboxEx)

            RemoveHandler cmbSYANAI_CD.SelectedValueChanged, AddressOf CmbSYANAI_CD_SelectedValueChanged

            '部品番号
            RemoveHandler cmbBUHIN_BANGO.SelectedValueChanged, AddressOf CmbBUHIN_BANGO_SelectedValueChanged
            cmbBUHIN_BANGO.DataBindings.Clear()
            If cmb.IsSelected Then
                Dim drs = tblBUHIN.AsEnumerable.Where(Function(r) r.Field(Of String)(NameOf(_D003_NCR_J.SYANAI_CD)) = cmb.SelectedValue).ToList
                If drs.Count > 0 Then
                    Dim dt As DataTable = drs.CopyToDataTable
                    cmbBUHIN_BANGO.SetDataSource(dt, ENM_COMBO_SELECT_VALUE_TYPE._0_Required)
                    If drs.Count = 1 Then
                        _D003_NCR_J.BUHIN_BANGO = drs(0).Item("DISP")
                    Else
                        _D003_NCR_J.BUHIN_BANGO = " "
                    End If
                End If
            Else
                cmbBUHIN_BANGO.SetDataSource(tblBUHIN.ExcludeDeleted, ENM_COMBO_SELECT_VALUE_TYPE._0_Required)
            End If
            cmbBUHIN_BANGO.DataBindings.Add(New Binding(NameOf(cmbBUHIN_BANGO.SelectedValue), _D003_NCR_J, NameOf(_D003_NCR_J.BUHIN_BANGO), False, DataSourceUpdateMode.OnPropertyChanged, ""))
            AddHandler cmbBUHIN_BANGO.SelectedValueChanged, AddressOf CmbBUHIN_BANGO_SelectedValueChanged

            '抽出
            RemoveHandler cmbBUHIN_BANGO.SelectedValueChanged, AddressOf CmbBUHIN_BANGO_SelectedValueChanged
            RemoveHandler cmbKISYU.SelectedValueChanged, AddressOf CmbKISYU_SelectedValueChanged
            cmbKISYU.DataBindings.Clear()
            cmbBUHIN_BANGO.DataBindings.Clear()
            If cmb.IsSelected Then
                Dim dr As DataRow = DirectCast(cmbSYANAI_CD.DataSource, DataTable).AsEnumerable.Where(Function(r) r.Field(Of String)("VALUE") = cmb.SelectedValue).FirstOrDefault
                If dr IsNot Nothing Then
                    _D003_NCR_J.BUHIN_BANGO = dr.Item("BUHIN_BANGO")
                    If dr.Item("BUHIN_NAME").ToString.IsNullOrWhiteSpace = False Then _D003_NCR_J.BUHIN_NAME = dr.Item("BUHIN_NAME")
                    If dr.Item("KISYU_ID") <> 0 Then _D003_NCR_J.KISYU_ID = dr.Item("KISYU_ID")
                Else
                    _D003_NCR_J.BUHIN_BANGO = " "
                    _D003_NCR_J.BUHIN_NAME = "(必須)"
                    _D003_NCR_J.KISYU_ID = 0
                End If
            Else
                _D003_NCR_J.BUHIN_BANGO = " "
                _D003_NCR_J.BUHIN_NAME = "(必須)"
                _D003_NCR_J.KISYU_ID = 0
            End If
            cmbKISYU.DataBindings.Add(New Binding(NameOf(cmbKISYU.SelectedValue), _D003_NCR_J, NameOf(_D003_NCR_J.KISYU_ID), False, DataSourceUpdateMode.OnPropertyChanged, 0))
            cmbBUHIN_BANGO.DataBindings.Add(New Binding(NameOf(cmbBUHIN_BANGO.SelectedValue), _D003_NCR_J, NameOf(_D003_NCR_J.BUHIN_BANGO), False, DataSourceUpdateMode.OnPropertyChanged, ""))
            AddHandler cmbBUHIN_BANGO.SelectedValueChanged, AddressOf CmbBUHIN_BANGO_SelectedValueChanged
            AddHandler cmbKISYU.SelectedValueChanged, AddressOf CmbKISYU_SelectedValueChanged

            ErrorProvider.ClearError(cmbKISYU)
            ErrorProvider.ClearError(cmbBUHIN_BANGO)

        Finally
            AddHandler cmbSYANAI_CD.SelectedValueChanged, AddressOf CmbSYANAI_CD_SelectedValueChanged
        End Try
    End Sub

    Private Sub CmbSYANAI_CD_Validating(sender As Object, e As System.ComponentModel.CancelEventArgs) Handles cmbSYANAI_CD.Validating
        Dim cmb As ComboboxEx = DirectCast(sender, ComboboxEx)
        If _D003_NCR_J.BUMON_KB.ToVal = Context.ENM_BUMON_KB._2_LP Then

            IsValidated *= ErrorProvider.UpdateErrorInfo(cmb, cmb.IsSelected, String.Format(My.Resources.infoMsgRequireSelectOrInput, "社内コード"))

        End If
    End Sub

#End Region

#Region "部品番号"

    Private Sub CmbBUHIN_BANGO_SelectedValueChanged(sender As Object, e As EventArgs)
        Dim cmb As ComboboxEx = DirectCast(sender, ComboboxEx)
        Dim blnSelected As Boolean = (cmb.SelectedValue IsNot Nothing AndAlso Not cmb.SelectedValue.ToString.IsNullOrWhiteSpace)

        RemoveHandler cmbBUHIN_BANGO.SelectedValueChanged, AddressOf CmbBUHIN_BANGO_SelectedValueChanged
        RemoveHandler cmbSYANAI_CD.SelectedValueChanged, AddressOf CmbSYANAI_CD_SelectedValueChanged

        '社内コード
        If blnSelected Then
            cmbSYANAI_CD.DataBindings.Clear()
            If Val(cmb.SelectedValue) = Context.ENM_BUMON_KB._2_LP Then
                Dim drs = tblSYANAI_CD.AsEnumerable.Where(Function(r) r.Field(Of String)(NameOf(_D003_NCR_J.BUHIN_BANGO)) = cmb.SelectedValue).ToList
                If drs.Count > 0 Then
                    Dim dt As DataTable = drs.CopyToDataTable
                    Dim _selectedValue As String = cmbSYANAI_CD.SelectedValue
                    cmbSYANAI_CD.DisplayMember = "DISP"
                    cmbSYANAI_CD.ValueMember = "VALUE"
                    cmbSYANAI_CD.SetDataSource(dt, ENM_COMBO_SELECT_VALUE_TYPE._0_Required)
                    If Not cmbSYANAI_CD.NullValue = _selectedValue Then
                        _D003_NCR_J.SYANAI_CD = _selectedValue
                    End If
                End If
            Else
                _D003_NCR_J.SYANAI_CD = ""
                'cmbSYANAI_CD.DataSource = Nothing
            End If
            cmbSYANAI_CD.DataBindings.Add(New Binding(NameOf(cmbSYANAI_CD.SelectedValue), _D003_NCR_J, NameOf(_D003_NCR_J.SYANAI_CD), False, DataSourceUpdateMode.OnPropertyChanged, ""))
        Else
            cmbSYANAI_CD.SetDataSource(tblSYANAI_CD.ExcludeDeleted, ENM_COMBO_SELECT_VALUE_TYPE._0_Required)
        End If
        AddHandler cmbSYANAI_CD.SelectedValueChanged, AddressOf CmbSYANAI_CD_SelectedValueChanged

        '抽出
        If blnSelected Then
            Dim dr As DataRow = DirectCast(cmbBUHIN_BANGO.DataSource, DataTable).AsEnumerable.Where(Function(r) r.Field(Of String)("VALUE") = cmbBUHIN_BANGO.SelectedValue).FirstOrDefault
            If Val(cmb.SelectedValue) = Context.ENM_BUMON_KB._2_LP Then
                _D003_NCR_J.SYANAI_CD = dr.Item("SYANAI_CD")
                If dr.Item("BUHIN_NAME").ToString.IsNullOrWhiteSpace = False Then _D003_NCR_J.BUHIN_NAME = dr.Item("BUHIN_NAME")
            Else
                _D003_NCR_J.BUHIN_NAME = dr.Item("BUHIN_NAME")
            End If

            RemoveHandler cmbKISYU.SelectedValueChanged, AddressOf CmbKISYU_SelectedValueChanged
            If dr.Item("KISYU_ID") <> 0 Then _D003_NCR_J.KISYU_ID = dr.Item("KISYU_ID")
            AddHandler cmbKISYU.SelectedValueChanged, AddressOf CmbKISYU_SelectedValueChanged

            '再発チェック
            _D003_NCR_J.SAIHATU = FunIsReIssue(_D003_NCR_J.BUHIN_BANGO, _D003_NCR_J.FUTEKIGO_KB, _D003_NCR_J.FUTEKIGO_S_KB)
        Else
            _D003_NCR_J.SYANAI_CD = ""
            _D003_NCR_J.BUHIN_NAME = ""
            _D003_NCR_J.KISYU_ID = 0
        End If

        AddHandler cmbBUHIN_BANGO.SelectedValueChanged, AddressOf CmbBUHIN_BANGO_SelectedValueChanged
    End Sub

    Private Sub CmbBUHIN_BANGO_Validating(sender As Object, e As System.ComponentModel.CancelEventArgs) Handles cmbBUHIN_BANGO.Validating
        Dim cmb As ComboboxEx = DirectCast(sender, ComboboxEx)

        IsValidated *= ErrorProvider.UpdateErrorInfo(cmb, cmb.IsSelected, String.Format(My.Resources.infoMsgRequireSelectOrInput, "部品番号"))

    End Sub

#End Region

#Region "製造番号(号機)"

    Private Sub MtxGOUKI_Validating(sender As Object, e As System.ComponentModel.CancelEventArgs) 'Handles mtxGOUKI.Validating 必須項目でない
        Dim mtx As MaskedTextBoxEx = DirectCast(sender, MaskedTextBoxEx)

        IsValidated *= ErrorProvider.UpdateErrorInfo(mtx, (mtx.ReadOnly AndAlso Not mtx.Text.IsNullOrWhiteSpace), String.Format(My.Resources.infoMsgRequireSelectOrInput, "製造番号(号機)"))


    End Sub

#End Region

#Region "状態区分"

    Private Sub CmbFUTEKIGO_STATUS_SelectedValueChanged(sender As Object, e As EventArgs) Handles cmbFUTEKIGO_STATUS.SelectedValueChanged
        Dim cmb As ComboboxEx = DirectCast(sender, ComboboxEx)

        Dim blnRET As Boolean = cmb.SelectedValue = "3" 'ENM_FUTEKIGO_JYOTAI_KB._3_返却品.ToString
        lblFUTEKIGO_NAIYO.Visible = blnRET
        mtxHENKYAKU_RIYU.Visible = blnRET
        mtxHENKYAKU_RIYU.Enabled = blnRET
    End Sub

    Private Sub CmbFUTEKIGO_STATUS_Validating(sender As Object, e As System.ComponentModel.CancelEventArgs) Handles cmbFUTEKIGO_STATUS.Validating
        Dim cmb As ComboboxEx = DirectCast(sender, ComboboxEx)

        IsValidated *= ErrorProvider.UpdateErrorInfo(cmb, cmb.IsSelected, String.Format(My.Resources.infoMsgRequireSelectOrInput, "状態区分"))

    End Sub

#End Region

#Region "返却理由"

    Private Sub MtxFUTEKIGO_NAIYO_Validating(sender As Object, e As System.ComponentModel.CancelEventArgs) Handles mtxHENKYAKU_RIYU.Validating
        Dim mtx As MaskedTextBoxEx = DirectCast(sender, MaskedTextBoxEx)
        Dim result As Boolean = Not (mtx.Visible = True AndAlso mtx.ReadOnly = False AndAlso mtx.Text.IsNullOrWhiteSpace)
        IsValidated *= ErrorProvider.UpdateErrorInfo(mtx, result, String.Format(My.Resources.infoMsgRequireSelectOrInput, "返却理由"))

    End Sub

#End Region

#Region "不適合区分"

    Private Sub CmbFUTEKIGO_KB_SelectedValueChanged(sender As Object, e As EventArgs) Handles cmbFUTEKIGO_KB.SelectedValueChanged

        Dim cmb As ComboboxEx = DirectCast(sender, ComboboxEx)

        cmbFUTEKIGO_S_KB.DataBindings.Clear()
        RemoveHandler cmbFUTEKIGO_S_KB.Validated, AddressOf cmbFUTEKIGO_S_KB_Validated
        If cmb.SelectedValue IsNot Nothing AndAlso Not cmb.SelectedValue.ToString.IsNullOrWhiteSpace Then
            Dim dt As New DataTableEx
            Using DB As ClsDbUtility = DBOpen()
                FunGetCodeDataTable(DB, "不適合" & cmb.Text.Replace("・", "") & "区分", dt)
            End Using
            cmbFUTEKIGO_S_KB.ValueMember = "VALUE"
            cmbFUTEKIGO_S_KB.DisplayMember = "DISP"
            cmbFUTEKIGO_S_KB.SetDataSource(dt.ExcludeDeleted, ENM_COMBO_SELECT_VALUE_TYPE._0_Required)
            _D003_NCR_J.FUTEKIGO_S_KB = ""
        Else
            cmbFUTEKIGO_S_KB.DataSource = Nothing
        End If
        AddHandler cmbFUTEKIGO_S_KB.Validated, AddressOf cmbFUTEKIGO_S_KB_Validated
        cmbFUTEKIGO_S_KB.DataBindings.Add(New Binding(NameOf(cmbFUTEKIGO_S_KB.SelectedValue), _D003_NCR_J, NameOf(_D003_NCR_J.FUTEKIGO_S_KB), False, DataSourceUpdateMode.OnPropertyChanged, False))
    End Sub

    Private Sub CmbFUTEKIGO_KB_Validating(sender As Object, e As System.ComponentModel.CancelEventArgs) Handles cmbFUTEKIGO_KB.Validating
        Dim cmb As ComboboxEx = DirectCast(sender, ComboboxEx)

        IsValidated *= ErrorProvider.UpdateErrorInfo(cmb, cmb.IsSelected, String.Format(My.Resources.infoMsgRequireSelectOrInput, "不適合区分"))


    End Sub

#End Region

#Region "不適合詳細区分"

    Private Sub cmbFUTEKIGO_S_KB_Validated(sender As Object, e As EventArgs) Handles cmbFUTEKIGO_S_KB.Validated
        '再発チェック
        _D003_NCR_J.SAIHATU = FunIsReIssue(_D003_NCR_J.BUHIN_BANGO, _D003_NCR_J.FUTEKIGO_KB, _D003_NCR_J.FUTEKIGO_S_KB)
    End Sub

    Private Sub CmbFUTEKIGO_S_KB_Validating(sender As Object, e As System.ComponentModel.CancelEventArgs) Handles cmbFUTEKIGO_S_KB.Validating
        Dim cmb As ComboboxEx = DirectCast(sender, ComboboxEx)

        IsValidated *= ErrorProvider.UpdateErrorInfo(cmb, cmb.IsSelected, String.Format(My.Resources.infoMsgRequireSelectOrInput, "不適合詳細区分"))


    End Sub

#End Region

#Region "図番"

    Private Sub MtxZUBAN_KIKAKU_Validating(sender As Object, e As System.ComponentModel.CancelEventArgs) 'Handles mtxZUBAN_KIKAKU.Validating 必須項目でない
        Dim mtx As MaskedTextBoxEx = DirectCast(sender, MaskedTextBoxEx)

        IsValidated *= ErrorProvider.UpdateErrorInfo(mtx, Not mtx.Text.IsNullOrWhiteSpace, String.Format(My.Resources.infoMsgRequireSelectOrInput, "図番"))

    End Sub

#End Region

#Region "数量"

    Private Sub NumSU_Validated(sender As Object, e As EventArgs) Handles numSU.Validated

        If Val(numSU.Text) = 0 Then
            numSU.Text = numSU.Minimum
        End If
    End Sub

#End Region

#Region "発生日"
    Private Sub DtHASSEI_YMD_Validating(sender As Object, e As System.ComponentModel.CancelEventArgs) Handles dtHASSEI_YMD.Validating
        Dim dtx As DateTextBoxEx = DirectCast(sender, DateTextBoxEx)

        IsValidated *= ErrorProvider.UpdateErrorInfo(dtx, Not dtx.ValueNonFormat.IsNullOrWhiteSpace, String.Format(My.Resources.infoMsgRequireSelectOrInput, "発生日"))


    End Sub
#End Region

#End Region

#Region "STAGE別"

#Region "申請先社員"

    Private Sub CmbDestTANTO_Validating(sender As Object, e As System.ComponentModel.CancelEventArgs) Handles cmbST01_DestTANTO.Validating,
                                                                                                              cmbST02_DestTANTO.Validating,
                                                                                                              cmbST03_DestTANTO.Validating,
                                                                                                              cmbST04_DestTANTO.Validating,
                                                                                                              cmbST05_DestTANTO.Validating,
                                                                                                              cmbST06_DestTANTO.Validating,
                                                                                                              cmbST07_DestTANTO.Validating,
                                                                                                              cmbST08_DestTANTO.Validating,
                                                                                                              cmbST09_DestTANTO.Validating,
                                                                                                              cmbST10_DestTANTO.Validating,
                                                                                                              cmbST11_DestTANTO.Validating,
                                                                                                              cmbST12_DestTANTO.Validating,
                                                                                                              cmbST13_DestTANTO.Validating,
                                                                                                              cmbST14_DestTANTO.Validating,
                                                                                                              cmbST15_DestTANTO.Validating

        Dim cmb As ComboboxEx = DirectCast(sender, ComboboxEx)
        IsValidated *= ErrorProvider.UpdateErrorInfo(cmb, cmb.IsSelected, String.Format(My.Resources.infoMsgRequireSelectOrInput, "申請先社員"))

    End Sub

#End Region

#Region "承認申請日"

    Private Sub dtUPD_YMD_Validating(sender As Object, e As System.ComponentModel.CancelEventArgs) Handles dtST01_UPD_YMD.Validating,
                                                                                                              dtST02_UPD_YMD.Validating,
                                                                                                              dtST03_UPD_YMD.Validating,
                                                                                                              dtST04_UPD_YMD.Validating,
                                                                                                              dtST05_UPD_YMD.Validating,
                                                                                                              dtST06_UPD_YMD.Validating,
                                                                                                              dtST07_UPD_YMD.Validating,
                                                                                                              dtST08_UPD_YMD.Validating,
                                                                                                              dtST09_UPD_YMD.Validating,
                                                                                                              dtST10_UPD_YMD.Validating,
                                                                                                              dtST11_UPD_YMD.Validating,
                                                                                                              dtST12_UPD_YMD.Validating,
                                                                                                              dtST13_UPD_YMD.Validating,
                                                                                                              dtST14_UPD_YMD.Validating,
                                                                                                              dtST15_UPD_YMD.Validating

        Dim dtx As DateTextBoxEx = DirectCast(sender, DateTextBoxEx)
        IsValidated *= ErrorProvider.UpdateErrorInfo(dtx, Not dtx.ValueNonFormat.IsNullOrWhiteSpace, String.Format(My.Resources.infoMsgRequireSelectOrInput, "承認・申請日"))


    End Sub

#End Region

#Region "   STAGE1"

    Private Sub TxtST01_YOKYU_NAIYO_Validating(sender As Object, e As System.ComponentModel.CancelEventArgs) Handles txtST01_YOKYU_NAIYO.Validating
        Dim txt As TextBoxEx = DirectCast(sender, TextBoxEx)

        IsValidated *= ErrorProvider.UpdateErrorInfo(txt, (txt.ReadOnly OrElse Not txt.Text.IsNullOrWhiteSpace), String.Format(My.Resources.infoMsgRequireSelectOrInput, "要求内容"))

    End Sub

    Private Sub TxtST01_KEKKA_Validating(sender As Object, e As System.ComponentModel.CancelEventArgs) Handles txtST01_KEKKA.Validating
        Dim txt As TextBoxEx = DirectCast(sender, TextBoxEx)

        IsValidated *= ErrorProvider.UpdateErrorInfo(txt, (txt.ReadOnly OrElse Not txt.Text.IsNullOrWhiteSpace), String.Format(My.Resources.infoMsgRequireSelectOrInput, "観察結果"))

    End Sub

#End Region

#Region "   STAGE2"

    '共通項目のみ

#End Region

#Region "   STAGE3"

    '共通項目のみ

#End Region

#Region "   STAGE4"

    Private Sub RbtnST04_ZESEI_YES_CheckedChanged(sender As Object, e As EventArgs) Handles rbtnST04_ZESEI_YES.CheckedChanged

        Dim blnChecked As Boolean = rbtnST04_ZESEI_NO.Checked
        lbltxtST04_RIYU.Visible = blnChecked
        txtST04_RIYU.Visible = blnChecked
        lblCAR_TANTO.Visible = Not blnChecked
        cmbST04_CAR_TANTO.Visible = Not blnChecked

        lblST04_HASSEI_KOTEI_GL_TANTO.Visible = Not blnChecked
        cmbST04_HASSEI_KOTEI_GL_TANTO.Visible = Not blnChecked

        _D003_NCR_J.ZESEI_SYOCHI_YOHI_KB = True
    End Sub

    Private Sub RbtnST04_ZESEI_NO_CheckedChanged(sender As Object, e As EventArgs) Handles rbtnST04_ZESEI_NO.CheckedChanged

        Dim blnChecked As Boolean = rbtnST04_ZESEI_NO.Checked
        lbltxtST04_RIYU.Visible = blnChecked
        txtST04_RIYU.Visible = blnChecked
        lblCAR_TANTO.Visible = Not blnChecked
        cmbST04_CAR_TANTO.Visible = Not blnChecked

        lblST04_HASSEI_KOTEI_GL_TANTO.Visible = Not blnChecked
        cmbST04_HASSEI_KOTEI_GL_TANTO.Visible = Not blnChecked

        _D003_NCR_J.ZESEI_SYOCHI_YOHI_KB = False
    End Sub

    Private Sub ChkZESEI_SYOCHI_YOHI_KB_CheckedChanged(sender As Object, e As EventArgs) Handles chkST04_ZESEI_SYOCHI_YOHI_KB.CheckedChanged
        If chkST04_ZESEI_SYOCHI_YOHI_KB.Checked Then
            rbtnST04_ZESEI_YES.Checked = True
        Else
            rbtnST04_ZESEI_NO.Checked = True
        End If
    End Sub

    Private Sub TxtST04_RIYU_Validating(sender As Object, e As System.ComponentModel.CancelEventArgs) Handles txtST04_RIYU.Validating
        Dim txt As TextBoxEx = DirectCast(sender, TextBoxEx)

        IsValidated *= ErrorProvider.UpdateErrorInfo(txt, (txt.ReadOnly OrElse Not txt.Text.IsNullOrWhiteSpace), String.Format(My.Resources.infoMsgRequireSelectOrInput, "否の理由"))

    End Sub

    Private Sub CmbST04_JIZENSINSA_HANTEI_Validating(sender As Object, e As System.ComponentModel.CancelEventArgs) Handles cmbST04_JIZENSINSA_HANTEI.Validating
        Dim cmb As ComboboxEx = DirectCast(sender, ComboboxEx)

        IsValidated *= ErrorProvider.UpdateErrorInfo(cmb, cmb.IsSelected, String.Format(My.Resources.infoMsgRequireSelectOrInput, "事前審査判定"))

    End Sub

    Private Sub CmbST04_CAR_TANTO_Validating(sender As Object, e As System.ComponentModel.CancelEventArgs) Handles cmbST04_CAR_TANTO.Validating
        Dim cmb As ComboboxEx = DirectCast(sender, ComboboxEx)

        IsValidated *= ErrorProvider.UpdateErrorInfo(cmb, cmb.IsSelected, String.Format(My.Resources.infoMsgRequireSelectOrInput, "CAR起草担当"))

    End Sub

    Private Sub CmbST04_HASSEI_KOTEI_GL_TANTO_Validating(sender As Object, e As System.ComponentModel.CancelEventArgs) Handles cmbST04_HASSEI_KOTEI_GL_TANTO.Validating
        Dim cmb As ComboboxEx = DirectCast(sender, ComboboxEx)

        IsValidated *= ErrorProvider.UpdateErrorInfo(cmb, cmb.IsSelected, String.Format(My.Resources.infoMsgRequireSelectOrInput, "発生工程GL担当"))

    End Sub

#End Region

#Region "   STAGE5"

    '共通項目のみ

#End Region

#Region "   STAGE6"

    Private Sub CmbST06_SAISIN_IINKAI_HANTEI_SelectedValueChanged(sender As Object, e As EventArgs) Handles cmbST06_SAISIN_IINKAI_HANTEI.SelectedValueChanged

        '次ステージ名更新
        mtxST06_NextStageName.Text = FunGetStageName(Context.ENM_SYONIN_HOKOKUSYO_ID._1_NCR, FunGetNextSYONIN_JUN(ENM_NCR_STAGE._60_再審審査判定_技術代表)) 'PrCurrentStage
        Dim dt As DataTable
        dt = FunGetSYONIN_SYOZOKU_SYAIN(cmbBUMON.SelectedValue, Context.ENM_SYONIN_HOKOKUSYO_ID._1_NCR, FunGetNextSYONIN_JUN(ENM_NCR_STAGE._60_再審審査判定_技術代表))
        cmbST06_DestTANTO.SetDataSource(dt, ENM_COMBO_SELECT_VALUE_TYPE._0_Required)
    End Sub

    Private Sub CmbST06_SAISIN_IINKAI_HANTEI_Validating(sender As Object, e As System.ComponentModel.CancelEventArgs) Handles cmbST06_SAISIN_IINKAI_HANTEI.Validating
        Dim cmb As ComboboxEx = DirectCast(sender, ComboboxEx)

        IsValidated *= ErrorProvider.UpdateErrorInfo(cmb, cmb.IsSelected, String.Format(My.Resources.infoMsgRequireSelectOrInput, "事前審査判定"))

    End Sub

#End Region

#Region "   STAGE7"

    Private Sub RbtnST07_Yes_CheckedChanged(sender As Object, e As EventArgs) Handles rbtnST07_Yes.CheckedChanged

        Dim blnChecked As Boolean = rbtnST07_No.Checked
        _D003_NCR_J.SAIKAKO_SIJI_FG = True

        Call FunUpdateNextStageInfo()
    End Sub

    Private Sub RbtnST07_No_CheckedChanged(sender As Object, e As EventArgs) Handles rbtnST07_No.CheckedChanged

        Dim blnChecked As Boolean = rbtnST07_No.Checked
        _D003_NCR_J.SAIKAKO_SIJI_FG = False

        Call FunUpdateNextStageInfo()
    End Sub

    Private Sub ChkST07_SAIKAKO_SIJI_FLG_CheckedChanged(sender As Object, e As EventArgs) Handles chkST07_SAIKAKO_SIJI_FLG.CheckedChanged
        If chkST07_SAIKAKO_SIJI_FLG.Checked Then
            rbtnST07_Yes.Checked = True
        Else
            rbtnST07_No.Checked = True
        End If
    End Sub

    Private Sub CmbST07_KOKYAKU_SAISYU_HANTEI_SelectedValueChanged(sender As Object, e As EventArgs) Handles cmbST07_KOKYAKU_SAISYU_HANTEI.SelectedValueChanged
        Call FunUpdateNextStageInfo()
    End Sub

    ''' <summary>
    ''' ステージ70 選択内容に応じて次ステージ名と担当者を更新
    ''' </summary>
    ''' <returns></returns>
    Private Function FunUpdateNextStageInfo() As Boolean
        Dim dt As DataTable
        dt = FunGetSYONIN_SYOZOKU_SYAIN(cmbBUMON.SelectedValue, Context.ENM_SYONIN_HOKOKUSYO_ID._1_NCR, FunGetNextSYONIN_JUN(ENM_NCR_STAGE._70_顧客再審処置_I_tag))
        cmbST08_DestTANTO.SetDataSource(dt, ENM_COMBO_SELECT_VALUE_TYPE._0_Required)
        mtxST08_NextStageName.Text = FunGetStageName(Context.ENM_SYONIN_HOKOKUSYO_ID._1_NCR, FunGetNextSYONIN_JUN(ENM_NCR_STAGE._70_顧客再審処置_I_tag))
    End Function

    Private Sub CmbST07_SAISIN_TANTO_Validating(sender As Object, e As System.ComponentModel.CancelEventArgs) Handles cmbST07_SAISIN_TANTO.Validating
        Dim cmb As ComboboxEx = DirectCast(sender, ComboboxEx)

        IsValidated *= ErrorProvider.UpdateErrorInfo(cmb, cmb.IsSelected, String.Format(My.Resources.infoMsgRequireSelectOrInput, "再審申請担当"))

    End Sub

    Private Sub CmbST07_KOKYAKU_HANTEI_SIJI_Validating(sender As Object, e As System.ComponentModel.CancelEventArgs) Handles cmbST07_KOKYAKU_HANTEI_SIJI.Validating
        Dim cmb As ComboboxEx = DirectCast(sender, ComboboxEx)

        IsValidated *= ErrorProvider.UpdateErrorInfo(cmb, cmb.IsSelected, String.Format(My.Resources.infoMsgRequireSelectOrInput, "顧客判定指示"))

    End Sub

    Private Sub CmbST07_KOKYAKU_SAISYU_HANTEI_Validating(sender As Object, e As System.ComponentModel.CancelEventArgs) Handles cmbST07_KOKYAKU_SAISYU_HANTEI.Validating
        Dim cmb As ComboboxEx = DirectCast(sender, ComboboxEx)

        IsValidated *= ErrorProvider.UpdateErrorInfo(cmb, cmb.IsSelected, String.Format(My.Resources.infoMsgRequireSelectOrInput, "顧客最終判定"))

    End Sub

#End Region

#Region "   STAGE8"

#Region "       8-1"

    Private Sub CmbST08_1_HAIKYAKU_KB_Validating(sender As Object, e As System.ComponentModel.CancelEventArgs)
        Dim cmb As ComboboxEx = DirectCast(sender, ComboboxEx)

        IsValidated *= ErrorProvider.UpdateErrorInfo(cmb, tabST08_SUB.SelectedIndex <> 0 OrElse cmb.IsSelected, String.Format(My.Resources.infoMsgRequireSelectOrInput, "廃却方法"))


    End Sub

    Private Sub CmbST08_1_HAIKYAKU_TANTO_Validating(sender As Object, e As System.ComponentModel.CancelEventArgs)
        Dim cmb As ComboboxEx = DirectCast(sender, ComboboxEx)

        IsValidated *= ErrorProvider.UpdateErrorInfo(cmb, tabST08_SUB.SelectedIndex <> 0 OrElse cmb.IsSelected, String.Format(My.Resources.infoMsgRequireSelectOrInput, "廃却実地者"))


    End Sub

#End Region

#Region "       8-2"

    Private Sub CmbST08_2_KENSA_KEKKA_Validating(sender As Object, e As System.ComponentModel.CancelEventArgs)
        Dim cmb As ComboboxEx = DirectCast(sender, ComboboxEx)

        IsValidated *= ErrorProvider.UpdateErrorInfo(cmb, tabST08_SUB.SelectedIndex <> 1 OrElse cmb.IsSelected, String.Format(My.Resources.infoMsgRequireSelectOrInput, "検査結果"))


    End Sub

    Private Sub CmbST08_2_TANTO_SEIZO_Validating(sender As Object, e As System.ComponentModel.CancelEventArgs)
        Dim cmb As ComboboxEx = DirectCast(sender, ComboboxEx)

        IsValidated *= ErrorProvider.UpdateErrorInfo(cmb, tabST08_SUB.SelectedIndex <> 1 OrElse cmb.IsSelected, String.Format(My.Resources.infoMsgRequireSelectOrInput, "製造担当"))


    End Sub

    Private Sub CmbST08_2_TANTO_SEIGI_Validating(sender As Object, e As System.ComponentModel.CancelEventArgs)
        Dim cmb As ComboboxEx = DirectCast(sender, ComboboxEx)

        IsValidated *= ErrorProvider.UpdateErrorInfo(cmb, tabST08_SUB.SelectedIndex <> 1 OrElse cmb.IsSelected, String.Format(My.Resources.infoMsgRequireSelectOrInput, "生技担当"))

    End Sub

    Private Sub CmbST08_2_TANTO_KENSA_Validating(sender As Object, e As System.ComponentModel.CancelEventArgs)
        Dim cmb As ComboboxEx = DirectCast(sender, ComboboxEx)

        IsValidated *= ErrorProvider.UpdateErrorInfo(cmb, tabST08_SUB.SelectedIndex <> 1 OrElse cmb.IsSelected, String.Format(My.Resources.infoMsgRequireSelectOrInput, "検査担当"))

    End Sub

#End Region

#Region "       8-3"

    Private Sub CmbST08_3_HENKYAKU_TANTO_Validating(sender As Object, e As System.ComponentModel.CancelEventArgs)
        Dim cmb As ComboboxEx = DirectCast(sender, ComboboxEx)

        IsValidated *= ErrorProvider.UpdateErrorInfo(cmb, tabST08_SUB.SelectedIndex <> 2 OrElse cmb.IsSelected, String.Format(My.Resources.infoMsgRequireSelectOrInput, "返却担当"))


    End Sub

#End Region

#Region "       8-4"

    Private Sub CmbST08_4_KISYU_Validating(sender As Object, e As System.ComponentModel.CancelEventArgs)
        Dim cmb As ComboboxEx = DirectCast(sender, ComboboxEx)

        IsValidated *= ErrorProvider.UpdateErrorInfo(cmb, tabST08_SUB.SelectedIndex <> 3 OrElse cmb.IsSelected, String.Format(My.Resources.infoMsgRequireSelectOrInput, "機種"))


    End Sub

    Private Sub CmbST08_4_BUHIN_BANGO_Validating(sender As Object, e As System.ComponentModel.CancelEventArgs)
        Dim cmb As ComboboxEx = DirectCast(sender, ComboboxEx)

        IsValidated *= ErrorProvider.UpdateErrorInfo(cmb, tabST08_SUB.SelectedIndex <> 3 OrElse cmb.IsSelected, String.Format(My.Resources.infoMsgRequireSelectOrInput, "部品番号"))


    End Sub

#End Region

#End Region

#Region "   STAGE9"

    '共通項目のみ

#End Region

#Region "   STAGE10"

    '共通項目のみ

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
        'Dim strNameSuffix As String
        'If chk.Checked Then
        '    strNameSuffix = "T"
        'Else
        '    strNameSuffix = "F"
        'End If
        'Dim ctrlLabel As Control() = Me.Controls.Find("rbtnST11_" & chk.Name.Substring(8, 2) & "_" & strNameSuffix, True)
        'If ctrlLabel.Length > 0 Then
        '    Dim rbtn As RadioButton = ctrlLabel(0)
        '    rbtn.Checked = True
        'End If
    End Sub

    Private Sub RbtnST11_CheckedChanged(sender As Object, e As EventArgs) Handles rbtnST11_A1_F.CheckedChanged,
                                                                                  rbtnST11_E2_T.CheckedChanged,
                                                                                  rbtnST11_E2_F.CheckedChanged,
                                                                                  rbtnST11_E1_T.CheckedChanged,
                                                                                  rbtnST11_E1_F.CheckedChanged,
                                                                                  rbtnST11_D2_T.CheckedChanged,
                                                                                  rbtnST11_D2_F.CheckedChanged,
                                                                                  rbtnST11_D1_T.CheckedChanged,
                                                                                  rbtnST11_D1_F.CheckedChanged,
                                                                                  rbtnST11_C1_T.CheckedChanged,
                                                                                  rbtnST11_C1_F.CheckedChanged,
                                                                                  rbtnST11_B1_T.CheckedChanged,
                                                                                  rbtnST11_B1_F.CheckedChanged,
                                                                                  rbtnST11_A1_T.CheckedChanged

        Dim rbtn As RadioButton = DirectCast(sender, RadioButton)
        Dim strNameSuffix As String = rbtn.Name.Substring(12, 1)

        Dim ctrlLabel As Control() = Me.Controls.Find("chkST11_" & rbtn.Name.Substring(9, 2), True)
        If ctrlLabel.Length > 0 Then
            Dim chk As CheckBox = ctrlLabel(0)
            chk.Checked = IIf(strNameSuffix = "T", True, False)
        End If
    End Sub

#End Region

#Region "   STAGE12"

    Private Sub BtnST16_SYONIN_Click(sender As Object, e As EventArgs) Handles btnST16_SYONIN.Click
        cmdFunc2.PerformClick()
    End Sub

#End Region

#Region "添付資料"

#Region "添付ファイル"

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
            lbltmpFile1.Links.Clear()
            lbltmpFile1.Links.Add(0, lbltmpFile1.Text.Length, ofd.FileName)

            _D003_NCR_J.FILE_PATH = IO.Path.GetFileName(ofd.FileName)
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

                    'Private Sub ProcessExited(ByVal sender As Object, ByVal e As EventArgs)
                    '    Call SetTaskbarOverlayIcon(Nothing)
                    '    Call SetTaskbarInfo(ENM_TASKBAR_STATE._0_NoProgress)
                    'End Sub
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
        _D003_NCR_J.FILE_PATH = ""
        lbltmpFile1.Links.Clear()
        lbltmpFile1.Visible = False
        lbltmpFile1_Clear.Visible = False
    End Sub

#End Region

#Region "画像1"

    '画像1選択
    Private Sub BtnOpenPict1Dialog_Click(sender As Object, e As EventArgs) Handles btnOpenPict1Dialog.Click
        Try
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
                Call SetPict1Data({ofd.FileName})
            End If
        Catch ex As Exception
            Throw
        End Try
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
        _D003_NCR_J.G_FILE_PATH1 = ""
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

    Private Sub SetPict1Data(ByVal strFileName() As String)

        Try
            pnlPict1.Cursor = Cursors.Hand

            lblPict1Path.Text = CompactString(IO.Path.GetFileName(strFileName(0)), lblPict1Path, EllipsisFormat._4_Path) 'IO.Path.GetFileName(strFileName)
            'lblPict1Path.Tag = strFileName(0)
            _D003_NCR_J.G_FILE_PATH1 = IO.Path.GetFileName(strFileName(0))
            lblPict1Path.Links.Clear()
            lblPict1Path.Links.Add(0, lblPict1Path.Text.Length, strFileName(0))
            lblPict1Path.Visible = True
            lblPict1Path_Clear.Visible = True

            'Dim img As Image = New Bitmap(Image.FromFile(strFileName(0)), New Size(pnlPict1.Width, pnlPict1.Height))
            pnlPict1.Image = Image.FromFile(strFileName(0))
            'End Using
        Catch ex As OutOfMemoryException
        Catch ex2 As io.FileNotFoundException
            '
        End Try
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
            Call SetPict2Data({ofd.FileName})
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
        _D003_NCR_J.G_FILE_PATH2 = ""
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

    Private Sub LblPict2Path_DragEnter(sender As Object, e As DragEventArgs) Handles lblPict2Path.DragEnter
        'ドラッグされたデータ形式を調べ、ファイルのときはコピーとする
        If e.Data.GetDataPresent(DataFormats.FileDrop) Then
            e.Effect = DragDropEffects.Copy
        Else
            e.Effect = DragDropEffects.None
        End If
    End Sub

    Private Sub LblPict2Path_DragDrop(sender As Object, e As DragEventArgs) Handles lblPict2Path.DragDrop
        Call SetPict2Data(e.Data.GetData(DataFormats.FileDrop, False))
    End Sub

    Private Sub SetPict2Data(ByVal strFileName() As String)

        Try
            pnlPict2.Cursor = Cursors.Hand
            lblPict2Path.Text = CompactString(IO.Path.GetFileName(strFileName(0)), lblPict2Path, EllipsisFormat._4_Path) 'IO.Path.GetFileName(strFileName)
            _D003_NCR_J.G_FILE_PATH2 = IO.Path.GetFileName(strFileName(0))
            lblPict2Path.Links.Clear()
            lblPict2Path.Links.Add(0, lblPict2Path.Text.Length, strFileName(0))
            lblPict2Path.Visible = True
            lblPict2Path_Clear.Visible = True

            pnlPict2.Image = Image.FromFile(strFileName(0))
        Catch ex As OutOfMemoryException
        Catch ex2 As io.FileNotFoundException
            '
        End Try
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

#Region "バインディング"

    Private Function FunSetBindingD003() As Boolean

        '共通
        'mtxHOKUKO_NO.DataBindings.Add(New Binding(NameOf(mtxHOKUKO_NO.Text), _D003_NCR_J, NameOf(_D003_NCR_J.HOKOKU_NO), False, DataSourceUpdateMode.OnPropertyChanged, ""))
        cmbBUMON.DataBindings.Add(New Binding(NameOf(cmbBUMON.SelectedValue), _D003_NCR_J, NameOf(_D003_NCR_J.BUMON_KB), False, DataSourceUpdateMode.OnPropertyChanged, ""))
        chkClosed.DataBindings.Add(New Binding(NameOf(chkClosed.Checked), _D003_NCR_J, NameOf(_D003_NCR_J.CLOSE_FG), False, DataSourceUpdateMode.OnPropertyChanged, False))
        dtDraft.DataBindings.Add(New Binding(NameOf(dtDraft.ValueNonFormat), _D003_NCR_J, NameOf(_D003_NCR_J.ADD_YMD), False, DataSourceUpdateMode.OnPropertyChanged, ""))
        cmbKISO_TANTO.DataBindings.Add(New Binding(NameOf(cmbKISO_TANTO.SelectedValue), _D003_NCR_J, NameOf(_D003_NCR_J.ADD_SYAIN_ID), False, DataSourceUpdateMode.OnPropertyChanged, 0))
        'cmbKISYU.DataBindings.Add(New Binding(NameOf(cmbKISYU.SelectedValue), _D003_NCR_J, NameOf(_D003_NCR_J.KISYU_ID), False, DataSourceUpdateMode.OnPropertyChanged, 0))
        mtxGOUKI.DataBindings.Add(New Binding(NameOf(mtxGOUKI.Text), _D003_NCR_J, NameOf(_D003_NCR_J.GOKI), False, DataSourceUpdateMode.OnPropertyChanged, ""))
        'cmbSYANAI_CD.DataBindings.Add(New Binding(NameOf(cmbSYANAI_CD.SelectedValue), _D003_NCR_J, NameOf(_D003_NCR_J.SYANAI_CD), False, DataSourceUpdateMode.OnPropertyChanged, ""))
        'cmbBUHIN_BANGO.DataBindings.Add(New Binding(NameOf(cmbBUHIN_BANGO.SelectedValue), _D003_NCR_J, NameOf(_D003_NCR_J.BUHIN_BANGO), False, DataSourceUpdateMode.OnPropertyChanged, ""))
        cmbHINMEI.DataBindings.Add(New Binding(NameOf(cmbHINMEI.Text), _D003_NCR_J, NameOf(_D003_NCR_J.BUHIN_NAME), False, DataSourceUpdateMode.OnPropertyChanged, ""))
        numSU.DataBindings.Add(New Binding(NameOf(numSU.Value), _D003_NCR_J, NameOf(_D003_NCR_J.SURYO), False, DataSourceUpdateMode.OnPropertyChanged, 1))
        cmbFUTEKIGO_STATUS.DataBindings.Add(New Binding(NameOf(cmbFUTEKIGO_STATUS.SelectedValue), _D003_NCR_J, NameOf(_D003_NCR_J.FUTEKIGO_JYOTAI_KB), False, DataSourceUpdateMode.OnPropertyChanged, ""))
        chkSAIHATU.DataBindings.Add(New Binding(NameOf(chkSAIHATU.Checked), _D003_NCR_J, NameOf(_D003_NCR_J.SAIHATU), False, DataSourceUpdateMode.OnPropertyChanged, False))
        mtxHENKYAKU_RIYU.DataBindings.Add(New Binding(NameOf(mtxHENKYAKU_RIYU.Text), _D003_NCR_J, NameOf(_D003_NCR_J.FUTEKIGO_NAIYO), False, DataSourceUpdateMode.OnPropertyChanged, ""))
        cmbFUTEKIGO_KB.DataBindings.Add(New Binding(NameOf(cmbFUTEKIGO_KB.SelectedValue), _D003_NCR_J, NameOf(_D003_NCR_J.FUTEKIGO_KB), False, DataSourceUpdateMode.OnPropertyChanged, ""))
        'FUTEKIGO_S_KBはFUTEKIGO_KB変更時にバインド
        mtxZUBAN_KIKAKU.DataBindings.Add(New Binding(NameOf(mtxZUBAN_KIKAKU.Text), _D003_NCR_J, NameOf(_D003_NCR_J.ZUMEN_KIKAKU), False, DataSourceUpdateMode.OnPropertyChanged, ""))
        dtHASSEI_YMD.DataBindings.Add(New Binding(NameOf(dtHASSEI_YMD.ValueNonFormat), _D003_NCR_J, NameOf(_D003_NCR_J.HASSEI_YMD), False, DataSourceUpdateMode.OnPropertyChanged, ""))

        '添付資料
        lbltmpFile1.DataBindings.Add(New Binding(NameOf(lbltmpFile1.Tag), _D003_NCR_J, NameOf(_D003_NCR_J.FILE_PATH), False, DataSourceUpdateMode.OnPropertyChanged, ""))
        lblPict1Path.DataBindings.Add(New Binding(NameOf(lblPict1Path.Tag), _D003_NCR_J, NameOf(_D003_NCR_J.G_FILE_PATH1), False, DataSourceUpdateMode.OnPropertyChanged, ""))
        lblPict2Path.DataBindings.Add(New Binding(NameOf(lblPict2Path.Tag), _D003_NCR_J, NameOf(_D003_NCR_J.G_FILE_PATH2), False, DataSourceUpdateMode.OnPropertyChanged, ""))

        'STAGE01
        txtST01_YOKYU_NAIYO.DataBindings.Add(New Binding(NameOf(txtST01_YOKYU_NAIYO.Text), _D003_NCR_J, NameOf(_D003_NCR_J.YOKYU_NAIYO), False, DataSourceUpdateMode.OnPropertyChanged, ""))
        txtST01_KEKKA.DataBindings.Add(New Binding(NameOf(txtST01_KEKKA.Text), _D003_NCR_J, NameOf(_D003_NCR_J.KANSATU_KEKKA), False, DataSourceUpdateMode.OnPropertyChanged, ""))

        'STAGE02

        'STAGE03

        'STAGE04
        cmbST04_JIZENSINSA_HANTEI.DataBindings.Add(New Binding(NameOf(cmbST04_JIZENSINSA_HANTEI.SelectedValue), _D003_NCR_J, NameOf(_D003_NCR_J.JIZEN_SINSA_HANTEI_KB), False, DataSourceUpdateMode.OnPropertyChanged, ""))
        chkST04_ZESEI_SYOCHI_YOHI_KB.DataBindings.Add(New Binding(NameOf(chkST04_ZESEI_SYOCHI_YOHI_KB.Checked), _D003_NCR_J, NameOf(_D003_NCR_J.ZESEI_SYOCHI_YOHI_KB), False, DataSourceUpdateMode.OnPropertyChanged, False))
        txtST04_RIYU.DataBindings.Add(New Binding(NameOf(txtST04_RIYU.Text), _D003_NCR_J, NameOf(_D003_NCR_J.ZESEI_NASI_RIYU), False, DataSourceUpdateMode.OnPropertyChanged, ""))

        cmbST04_HASSEI_KOTEI_GL_TANTO.DataBindings.Add(New Binding(NameOf(cmbST04_HASSEI_KOTEI_GL_TANTO.SelectedValue), _D003_NCR_J, NameOf(_D003_NCR_J.HASSEI_KOTEI_GL_SYAIN_ID), False, DataSourceUpdateMode.OnPropertyChanged, 0))

        'STAGE05

        'STAGE06
        cmbST06_SAISIN_IINKAI_HANTEI.DataBindings.Add(New Binding(NameOf(cmbST06_SAISIN_IINKAI_HANTEI.SelectedValue), _D003_NCR_J, NameOf(_D003_NCR_J.SAISIN_IINKAI_HANTEI_KB), False, DataSourceUpdateMode.OnPropertyChanged, ""))
        mtxST06_SAISIN_IINKAI_SIRYO_NO.DataBindings.Add(New Binding(NameOf(mtxST06_SAISIN_IINKAI_SIRYO_NO.Text), _D003_NCR_J, NameOf(_D003_NCR_J.SAISIN_IINKAI_SIRYO_NO), False, DataSourceUpdateMode.OnPropertyChanged, ""))
        'If PrCurrentStage = ENM_NCR_STAGE._60_再審審査判定_技術代表 Then
        '    cmbST06_DestTANTO.DataBindings.Add(New Binding(NameOf(cmbST06_DestTANTO.SelectedValue), _D003_NCR_J, NameOf(_D003_NCR_J.SAISIN_GIJYUTU_SYAIN_ID), False, DataSourceUpdateMode.OnPropertyChanged, 0))
        'Else
        '    cmbST06_DestTANTO.DataBindings.Add(New Binding(NameOf(cmbST06_DestTANTO.SelectedValue), _D003_NCR_J, NameOf(_D003_NCR_J.SAISIN_HINSYO_SYAIN_ID), False, DataSourceUpdateMode.OnPropertyChanged, 0))
        'End If

        'STAGE07
        mtxST07_ITAG_NO.DataBindings.Add(New Binding(NameOf(mtxST07_ITAG_NO.Text), _D003_NCR_J, NameOf(_D003_NCR_J.ITAG_NO), False, DataSourceUpdateMode.OnPropertyChanged, ""))
        cmbST07_SAISIN_TANTO.DataBindings.Add(New Binding(NameOf(cmbST07_SAISIN_TANTO.SelectedValue), _D003_NCR_J, NameOf(_D003_NCR_J.KOKYAKU_SAISIN_TANTO_ID), False, DataSourceUpdateMode.OnPropertyChanged, 0))
        cmbST07_KOKYAKU_HANTEI_SIJI.DataBindings.Add(New Binding(NameOf(cmbST07_KOKYAKU_HANTEI_SIJI.SelectedValue), _D003_NCR_J, NameOf(_D003_NCR_J.KOKYAKU_HANTEI_SIJI_KB), False, DataSourceUpdateMode.OnPropertyChanged, ""))
        dtST07_KOKYAKU_HANTEI_SIJI.DataBindings.Add(New Binding(NameOf(dtST07_KOKYAKU_HANTEI_SIJI.ValueNonFormat), _D003_NCR_J, NameOf(_D003_NCR_J.KOKYAKU_HANTEI_SIJI_YMD), False, DataSourceUpdateMode.OnPropertyChanged, ""))
        cmbST07_KOKYAKU_SAISYU_HANTEI.DataBindings.Add(New Binding(NameOf(cmbST07_KOKYAKU_SAISYU_HANTEI.SelectedValue), _D003_NCR_J, NameOf(_D003_NCR_J.KOKYAKU_SAISYU_HANTEI_KB), False, DataSourceUpdateMode.OnPropertyChanged, ""))
        dtST07_KOKYAKU_SAISYU_HANTEI.DataBindings.Add(New Binding(NameOf(dtST07_KOKYAKU_SAISYU_HANTEI.ValueNonFormat), _D003_NCR_J, NameOf(_D003_NCR_J.KOKYAKU_SAISYU_HANTEI_YMD), False, DataSourceUpdateMode.OnPropertyChanged, ""))
        chkST07_SAIKAKO_SIJI_FLG.DataBindings.Add(New Binding(NameOf(chkST07_SAIKAKO_SIJI_FLG.Checked), _D003_NCR_J, NameOf(_D003_NCR_J.SAIKAKO_SIJI_FG), False, DataSourceUpdateMode.OnPropertyChanged, False))

        'STAGE08
        dtST08_1_HAIKYAKU_YMD.DataBindings.Add(New Binding(NameOf(dtST08_1_HAIKYAKU_YMD.ValueNonFormat), _D003_NCR_J, NameOf(_D003_NCR_J.HAIKYAKU_YMD), False, DataSourceUpdateMode.OnPropertyChanged, ""))
        cmbST08_1_HAIKYAKU_KB.DataBindings.Add(New Binding(NameOf(cmbST08_1_HAIKYAKU_KB.SelectedValue), _D003_NCR_J, NameOf(_D003_NCR_J.HAIKYAKU_KB), False, DataSourceUpdateMode.OnPropertyChanged, ""))
        mtxST08_1_BIKO.DataBindings.Add(New Binding(NameOf(mtxST08_1_BIKO.Text), _D003_NCR_J, NameOf(_D003_NCR_J.HAIKYAKU_HOUHOU), False, DataSourceUpdateMode.OnPropertyChanged, ""))
        cmbST08_1_HAIKYAKU_TANTO.DataBindings.Add(New Binding(NameOf(cmbST08_1_HAIKYAKU_TANTO.SelectedValue), _D003_NCR_J, NameOf(_D003_NCR_J.HAIKYAKU_TANTO_ID), False, DataSourceUpdateMode.OnPropertyChanged, 0))

        mtxST08_2_DOC_NO.DataBindings.Add(New Binding(NameOf(mtxST08_2_DOC_NO.Text), _D003_NCR_J, NameOf(_D003_NCR_J.SAIKAKO_SIJI_NO), False, DataSourceUpdateMode.OnPropertyChanged, ""))
        dtST08_2_WorkOutYMD.DataBindings.Add(New Binding(NameOf(dtST08_2_WorkOutYMD.ValueNonFormat), _D003_NCR_J, NameOf(_D003_NCR_J.SAIKAKO_SAGYO_KAN_YMD), False, DataSourceUpdateMode.OnPropertyChanged, ""))
        dtST08_2_KENSA_YMD.DataBindings.Add(New Binding(NameOf(dtST08_2_KENSA_YMD.ValueNonFormat), _D003_NCR_J, NameOf(_D003_NCR_J.SAIKAKO_KENSA_YMD), False, DataSourceUpdateMode.OnPropertyChanged, ""))
        cmbST08_2_KENSA_KEKKA.DataBindings.Add(New Binding(NameOf(cmbST08_2_KENSA_KEKKA.SelectedValue), _D003_NCR_J, NameOf(_D003_NCR_J.KENSA_KEKKA_KB), False, DataSourceUpdateMode.OnPropertyChanged, ""))
        cmbST08_2_TANTO_SEIZO.DataBindings.Add(New Binding(NameOf(cmbST08_2_TANTO_SEIZO.SelectedValue), _D003_NCR_J, NameOf(_D003_NCR_J.SEIZO_TANTO_ID), False, DataSourceUpdateMode.OnPropertyChanged, 0))
        cmbST08_2_TANTO_SEIGI.DataBindings.Add(New Binding(NameOf(cmbST08_2_TANTO_SEIGI.SelectedValue), _D003_NCR_J, NameOf(_D003_NCR_J.SEIGI_TANTO_ID), False, DataSourceUpdateMode.OnPropertyChanged, 0))
        cmbST08_2_TANTO_KENSA.DataBindings.Add(New Binding(NameOf(cmbST08_2_TANTO_KENSA.SelectedValue), _D003_NCR_J, NameOf(_D003_NCR_J.KENSA_TANTO_ID), False, DataSourceUpdateMode.OnPropertyChanged, 0))

        dtST08_3_HENKYAKU_YMD.DataBindings.Add(New Binding(NameOf(dtST08_3_HENKYAKU_YMD.ValueNonFormat), _D003_NCR_J, NameOf(_D003_NCR_J.HENKYAKU_YMD), False, DataSourceUpdateMode.OnPropertyChanged, ""))
        mtxST08_3_HENKYAKU_SAKI.DataBindings.Add(New Binding(NameOf(mtxST08_3_HENKYAKU_SAKI.Text), _D003_NCR_J, NameOf(_D003_NCR_J.HENKYAKU_SAKI), False, DataSourceUpdateMode.OnPropertyChanged, ""))
        txtST08_3_BIKO.DataBindings.Add(New Binding(NameOf(txtST08_3_BIKO.Text), _D003_NCR_J, NameOf(_D003_NCR_J.HENKYAKU_BIKO), False, DataSourceUpdateMode.OnPropertyChanged, ""))

        cmbST08_4_KISYU.DataBindings.Add(New Binding(NameOf(cmbST08_4_KISYU.SelectedValue), _D003_NCR_J, NameOf(_D003_NCR_J.TENYO_KISYU_ID), False, DataSourceUpdateMode.OnPropertyChanged, 0))
        cmbST08_4_BUHIN_BANGO.DataBindings.Add(New Binding(NameOf(cmbST08_4_BUHIN_BANGO.SelectedValue), _D003_NCR_J, NameOf(_D003_NCR_J.TENYO_BUHIN_BANGO), False, DataSourceUpdateMode.OnPropertyChanged, ""))
        mtxST08_4_GOUKI.DataBindings.Add(New Binding(NameOf(mtxST08_4_GOUKI.Text), _D003_NCR_J, NameOf(_D003_NCR_J.TENYO_GOKI), False, DataSourceUpdateMode.OnPropertyChanged, ""))
        mtxST08_4_LOT.DataBindings.Add(New Binding(NameOf(mtxST08_4_LOT.Text), _D003_NCR_J, NameOf(_D003_NCR_J.TENYO_LOT), False, DataSourceUpdateMode.OnPropertyChanged, ""))
        dtST08_4_TENYO_YMD.DataBindings.Add(New Binding(NameOf(dtST08_4_TENYO_YMD.ValueNonFormat), _D003_NCR_J, NameOf(_D003_NCR_J.TENYO_YMD), False, DataSourceUpdateMode.OnPropertyChanged, ""))

        'STAGE09

        'STAGE10

        'STAGE11
        chkST11_A1.DataBindings.Add(New Binding(NameOf(chkST11_A1.Checked), _D003_NCR_J, NameOf(_D003_NCR_J.SYOCHI_KEKKA_A), False, DataSourceUpdateMode.OnPropertyChanged, False))
        chkST11_B1.DataBindings.Add(New Binding(NameOf(chkST11_B1.Checked), _D003_NCR_J, NameOf(_D003_NCR_J.SYOCHI_KEKKA_B), False, DataSourceUpdateMode.OnPropertyChanged, False))
        chkST11_C1.DataBindings.Add(New Binding(NameOf(chkST11_C1.Checked), _D003_NCR_J, NameOf(_D003_NCR_J.SYOCHI_KEKKA_C), False, DataSourceUpdateMode.OnPropertyChanged, False))
        chkST11_D1.DataBindings.Add(New Binding(NameOf(chkST11_D1.Checked), _D003_NCR_J, NameOf(_D003_NCR_J.SYOCHI_D_UMU_KB), False, DataSourceUpdateMode.OnPropertyChanged, False))
        chkST11_D2.DataBindings.Add(New Binding(NameOf(chkST11_D2.Checked), _D003_NCR_J, NameOf(_D003_NCR_J.SYOCHI_D_YOHI_KB), False, DataSourceUpdateMode.OnPropertyChanged, False))
        mtxST11_D_Comment.DataBindings.Add(New Binding(NameOf(mtxST11_D_Comment.Text), _D003_NCR_J, NameOf(_D003_NCR_J.SYOCHI_D_SYOCHI_KIROKU), False, DataSourceUpdateMode.OnPropertyChanged, ""))
        chkST11_E1.DataBindings.Add(New Binding(NameOf(chkST11_E1.Checked), _D003_NCR_J, NameOf(_D003_NCR_J.SYOCHI_E_UMU_KB), False, DataSourceUpdateMode.OnPropertyChanged, False))
        chkST11_E2.DataBindings.Add(New Binding(NameOf(chkST11_E2.Checked), _D003_NCR_J, NameOf(_D003_NCR_J.SYOCHI_E_YOHI_KB), False, DataSourceUpdateMode.OnPropertyChanged, False))
        mtxST11_E_Comment.DataBindings.Add(New Binding(NameOf(mtxST11_E_Comment.Text), _D003_NCR_J, NameOf(_D003_NCR_J.SYOCHI_E_SYOCHI_KIROKU), False, DataSourceUpdateMode.OnPropertyChanged, ""))

        'STAGE12

    End Function

    Private Function FunClearBindingD003() As Boolean
        mtxHOKUKO_NO.DataBindings.Clear()
        cmbBUMON.DataBindings.Clear()
        chkClosed.DataBindings.Clear()
        dtDraft.DataBindings.Clear()
        cmbKISO_TANTO.DataBindings.Clear()
        mtxGOUKI.DataBindings.Clear()
        cmbHINMEI.DataBindings.Clear()
        numSU.DataBindings.Clear()
        cmbFUTEKIGO_STATUS.DataBindings.Clear()
        chkSAIHATU.DataBindings.Clear()
        mtxHENKYAKU_RIYU.DataBindings.Clear()
        cmbFUTEKIGO_KB.DataBindings.Clear()
        mtxZUBAN_KIKAKU.DataBindings.Clear()

        lbltmpFile1.DataBindings.Clear()
        lblPict1Path.DataBindings.Clear()
        lblPict2Path.DataBindings.Clear()

        txtST01_YOKYU_NAIYO.DataBindings.Clear()
        txtST01_KEKKA.DataBindings.Clear()

        cmbST04_JIZENSINSA_HANTEI.DataBindings.Clear()
        chkST04_ZESEI_SYOCHI_YOHI_KB.DataBindings.Clear()
        txtST04_RIYU.DataBindings.Clear()

        cmbST06_SAISIN_IINKAI_HANTEI.DataBindings.Clear()
        mtxST06_SAISIN_IINKAI_SIRYO_NO.DataBindings.Clear()

        mtxST07_ITAG_NO.DataBindings.Clear()
        cmbST07_SAISIN_TANTO.DataBindings.Clear()
        cmbST07_KOKYAKU_HANTEI_SIJI.DataBindings.Clear()
        dtST07_KOKYAKU_HANTEI_SIJI.DataBindings.Clear()
        cmbST07_KOKYAKU_SAISYU_HANTEI.DataBindings.Clear()
        dtST07_KOKYAKU_SAISYU_HANTEI.DataBindings.Clear()
        chkST07_SAIKAKO_SIJI_FLG.DataBindings.Clear()

        dtST08_1_HAIKYAKU_YMD.DataBindings.Clear()
        cmbST08_1_HAIKYAKU_KB.DataBindings.Clear()
        mtxST08_1_BIKO.DataBindings.Clear()
        cmbST08_1_HAIKYAKU_TANTO.DataBindings.Clear()

        mtxST08_2_DOC_NO.DataBindings.Clear()
        dtST08_2_WorkOutYMD.DataBindings.Clear()
        dtST08_2_KENSA_YMD.DataBindings.Clear()
        cmbST08_2_KENSA_KEKKA.DataBindings.Clear()
        cmbST08_2_TANTO_SEIZO.DataBindings.Clear()
        cmbST08_2_TANTO_SEIGI.DataBindings.Clear()
        cmbST08_2_TANTO_KENSA.DataBindings.Clear()

        dtST08_3_HENKYAKU_YMD.DataBindings.Clear()
        mtxST08_3_HENKYAKU_SAKI.DataBindings.Clear()
        txtST08_3_BIKO.DataBindings.Clear()

        cmbST08_4_KISYU.DataBindings.Clear()
        cmbST08_4_BUHIN_BANGO.DataBindings.Clear()
        mtxST08_4_GOUKI.DataBindings.Clear()
        mtxST08_4_LOT.DataBindings.Clear()
        dtST08_4_TENYO_YMD.DataBindings.Clear()

        chkST11_A1.DataBindings.Clear()
        chkST11_B1.DataBindings.Clear()
        chkST11_C1.DataBindings.Clear()
        chkST11_D1.DataBindings.Clear()
        chkST11_D2.DataBindings.Clear()
        mtxST11_D_Comment.DataBindings.Clear()
        chkST11_E1.DataBindings.Clear()
        chkST11_E2.DataBindings.Clear()
        mtxST11_E_Comment.DataBindings.Clear()

        Return True
    End Function

    Private Function FunSetBindingD004(ByVal intTabNo) As Boolean
        Dim ctrlTANTO As Control() = Me.Controls.Find("cmbST" & intTabNo.ToString("00") & "_DestTANTO", True)
        If ctrlTANTO.Length > 0 Then
            Dim cmbTANTO As ComboboxEx = ctrlTANTO(0)
            cmbTANTO.NullValue = 0
            cmbTANTO.DataBindings.Add(New Binding(NameOf(cmbTANTO.SelectedValue), _D004_SYONIN_J_KANRI, NameOf(_D004_SYONIN_J_KANRI.SYAIN_ID), False, DataSourceUpdateMode.OnPropertyChanged, 0))
        End If
    End Function

#End Region

#Region "処理モード別画面初期化"

    Private Function FunInitializeControls(ByVal intMODE As Integer) As Boolean

        Try
            'ナビゲートリンク選択
            Select Case PrCurrentStage
                Case 0, ENM_NCR_STAGE._999_Closed
                    rsbtnST99.Checked = True
                Case Else
                    Dim rbtn As RibbonShapeRadioButton = CType(flpnlStageIndex.Controls("rsbtnST" & FunConvertSYONIN_JUN_TO_STAGE_NO(PrCurrentStage).ToString("00")), RibbonShapeRadioButton)
                    If rbtn IsNot Nothing Then rbtn.Checked = True
            End Select

            Select Case intMODE
                Case ENM_DATA_OPERATION_MODE._1_ADD

                    mtxHOKUKO_NO.Text = "<新規>"
                    _D003_NCR_J.ADD_SYAIN_ID = pub_SYAIN_INFO.SYAIN_ID
                    _D003_NCR_J.ADD_YMDHNS = Now.ToString("yyyyMMddHHmmss")


                    If HasAdminAuth(pub_SYAIN_INFO.SYAIN_ID) Then
                    Else
                        _D003_NCR_J.BUMON_KB = pub_SYAIN_INFO.BUMON_KB
                    End If

                    _D003_NCR_J.SURYO = 1
                    Me.TabSTAGE.Visible = False 'ちらつき防止
                    Call FunInitializeTabControl(FunConvertSYONIN_JUN_TO_STAGE_NO(PrCurrentStage))
                    Application.DoEvents()
                    Call FunInitializeSTAGE(PrCurrentStage)
                    Application.DoEvents()
                    Me.TabSTAGE.Visible = True

                Case ENM_DATA_OPERATION_MODE._3_UPDATE

                    mtxHOKUKO_NO.DataBindings.Add(New Binding(NameOf(mtxHOKUKO_NO.Text), _D003_NCR_J, NameOf(_D003_NCR_J.HOKOKU_NO), False, DataSourceUpdateMode.OnPropertyChanged, ""))

                    'SPEC: 10-2.①
                    Call FunSetEntityModel(PrHOKOKU_NO, PrCurrentStage)

                    '#90 起草以降変更不可
                    If PrCurrentStage > ENM_NCR_STAGE._10_起草入力 Then

                        'UNDONE: ヘッダ項目も変更不可 とりあえずコントロールを直接制御 可能ならパネル単位で制御したい
                        mtxHOKUKO_NO.ReadOnly = True
                        cmbBUMON.ReadOnly = True
                        cmbKISO_TANTO.ReadOnly = True
                        dtDraft.ReadOnly = True
                        cmbKISYU.ReadOnly = True
                        cmbBUHIN_BANGO.ReadOnly = True
                        cmbHINMEI.ReadOnly = True
                        mtxGOUKI.ReadOnly = True
                        cmbSYANAI_CD.ReadOnly = True
                        cmbFUTEKIGO_STATUS.ReadOnly = True
                        mtxHENKYAKU_RIYU.ReadOnly = True
                        cmbFUTEKIGO_KB.ReadOnly = True
                        cmbFUTEKIGO_S_KB.ReadOnly = True
                        mtxZUBAN_KIKAKU.ReadOnly = True
                        numSU.Enabled = False
                        dtHASSEI_YMD.ReadOnly = True

                    End If

                    TabSTAGE.Visible = False
                    Call FunInitializeTabControl(FunConvertSYONIN_JUN_TO_STAGE_NO(PrCurrentStage))
                    Application.DoEvents()
                    Call FunInitializeSTAGE(PrCurrentStage)
                    Application.DoEvents()

                    For Each page As TabPage In TabSTAGE.TabPages
                        If page.Text = "現ステージ" Then
                            'SPEC: 10-2.④
                            TabSTAGE.SelectedTab = page
                            Exit For
                        End If
                    Next page
                    Me.TabSTAGE.Visible = True

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
    ''' 一覧選択行の値より各種ビューを検索し、モデルデータにセットする
    ''' </summary>
    ''' <param name="dr">一覧選択行のデータ</param>
    ''' <returns></returns>
    Private Function FunSetEntityModel(HOKOKU_NO As String, SYONIN_JUN As Integer) As Boolean

        Try
            'ビューモデルをロード
            _V002_NCR_J = FunGetV002Model(HOKOKU_NO)
            _V003_SYONIN_J_KANRI_List = FunGetV003Model(Context.ENM_SYONIN_HOKOKUSYO_ID._1_NCR, HOKOKU_NO)

#Region "D003"

            Dim t As Type = GetType(MODEL.D003_NCR_J)
            Dim properties As Reflection.PropertyInfo() = t.GetProperties(
                 Reflection.BindingFlags.Public Or
                 Reflection.BindingFlags.Instance Or
                 Reflection.BindingFlags.Static)

            Dim blnFieldList As New List(Of String) From {NameOf(_V002_NCR_J.CLOSE_FG),
                                                          NameOf(_V002_NCR_J.ZESEI_SYOCHI_YOHI_KB),
                                                          NameOf(_V002_NCR_J.SAIHATU),
                                                          NameOf(_V002_NCR_J.SAIKAKO_SIJI_FG),
                                                          NameOf(_V002_NCR_J.SYOCHI_KEKKA_A),
                                                          NameOf(_V002_NCR_J.SYOCHI_KEKKA_B),
                                                          NameOf(_V002_NCR_J.SYOCHI_KEKKA_C),
                                                          NameOf(_V002_NCR_J.SYOCHI_D_UMU_KB),
                                                          NameOf(_V002_NCR_J.SYOCHI_D_YOHI_KB),
                                                          NameOf(_V002_NCR_J.SYOCHI_E_UMU_KB),
                                                          NameOf(_V002_NCR_J.SYOCHI_E_YOHI_KB)}

            For Each p As Reflection.PropertyInfo In properties
                If IsAutoGenerateField(t, p.Name) = True Then
                    Select Case True
                        Case blnFieldList.Contains(p.Name)
                            _D003_NCR_J(p.Name) = CBool(_V002_NCR_J(p.Name))
                        Case Else
                            _D003_NCR_J(p.Name) = _V002_NCR_J(p.Name)
                    End Select
                End If
            Next p

#End Region

#Region "D004"

            Dim _V003 As New MODEL.V003_SYONIN_J_KANRI
            _V003 = _V003_SYONIN_J_KANRI_List.AsEnumerable.
                                Where(Function(r) r.SYONIN_JUN = SYONIN_JUN).
                                FirstOrDefault

            t = GetType(MODEL.D004_SYONIN_J_KANRI)
            properties = t.GetProperties(
                 Reflection.BindingFlags.Public Or
                 Reflection.BindingFlags.Instance Or
                 Reflection.BindingFlags.Static)

            Dim blnFieldList2 As New List(Of String) From {NameOf(_V003.SASIMODOSI_FG),
                                                          NameOf(_V003.MAIL_SEND_FG)}

            For Each p As Reflection.PropertyInfo In properties
                If IsAutoGenerateField(t, p.Name) = True Then
                    Select Case True
                        Case blnFieldList2.Contains(p.Name)
                            _D004_SYONIN_J_KANRI(p.Name) = CBool(_V003(p.Name))
                        Case Else
                            _D004_SYONIN_J_KANRI(p.Name) = _V003(p.Name)
                    End Select
                End If
            Next p

#End Region

            Return True
        Catch ex As Exception
            EM.ErrorSyori(ex, False, conblnNonMsg)
            Return False
        End Try
    End Function

#End Region

#Region "入力チェック"

    ''' <summary>
    ''' 入力チェック 必須項目のValidationを呼び出すことで判定
    ''' AndAlsoでビット演算し、1個でもFalseがあったらfalseを返す
    ''' </summary>
    ''' <param name="enmSAVE_MODE"></param>
    ''' <returns></returns>
    Private Function FunCheckInput(ByVal enmSAVE_MODE As ENM_SAVE_MODE) As Boolean
        Try
            'フラグリセット
            IsValidated = True

            '-----共通
            Call CmbBUMON_Validating(cmbBUMON, Nothing)
            Call CmbKISYU_Validating(cmbKISYU, Nothing)
            Call CmbBUHIN_BANGO_Validating(cmbBUHIN_BANGO, Nothing)
            Call CmbSYANAI_CD_Validating(cmbSYANAI_CD, Nothing)
            Call CmbFUTEKIGO_STATUS_Validating(cmbFUTEKIGO_STATUS, Nothing)
            Call MtxFUTEKIGO_NAIYO_Validating(mtxHENKYAKU_RIYU, Nothing)
            Call CmbFUTEKIGO_KB_Validating(cmbFUTEKIGO_KB, Nothing)
            Call CmbFUTEKIGO_S_KB_Validating(cmbFUTEKIGO_S_KB, Nothing)
            Call DtHASSEI_YMD_Validating(dtHASSEI_YMD, Nothing)

            If enmSAVE_MODE = ENM_SAVE_MODE._2_承認申請 Then
                '-----ステージ別
                Select Case PrCurrentStage
                    Case ENM_NCR_STAGE._10_起草入力
                        Call TxtST01_YOKYU_NAIYO_Validating(txtST01_YOKYU_NAIYO, Nothing)
                        Call TxtST01_KEKKA_Validating(txtST01_KEKKA, Nothing)
                        Call CmbDestTANTO_Validating(cmbST01_DestTANTO, Nothing)
                        Call dtUPD_YMD_Validating(dtST01_UPD_YMD, Nothing)

                    Case ENM_NCR_STAGE._20_起草確認製造GL
                        Call CmbDestTANTO_Validating(cmbST02_DestTANTO, Nothing)
                        Call dtUPD_YMD_Validating(dtST02_UPD_YMD, Nothing)
                    Case ENM_NCR_STAGE._30_起草確認検査
                        Call CmbDestTANTO_Validating(cmbST03_DestTANTO, Nothing)
                        Call dtUPD_YMD_Validating(dtST03_UPD_YMD, Nothing)

                    Case ENM_NCR_STAGE._40_事前審査判定及びCAR要否判定
                        Call CmbST04_JIZENSINSA_HANTEI_Validating(cmbST04_JIZENSINSA_HANTEI, Nothing)
                        Call CmbDestTANTO_Validating(cmbST04_DestTANTO, Nothing)
                        Call dtUPD_YMD_Validating(dtST04_UPD_YMD, Nothing)

                        If chkST04_ZESEI_SYOCHI_YOHI_KB.Checked = True Then
                            Call CmbST04_CAR_TANTO_Validating(cmbST04_CAR_TANTO, Nothing)
                            Call CmbST04_HASSEI_KOTEI_GL_TANTO_Validating(cmbST04_HASSEI_KOTEI_GL_TANTO, Nothing)
                        End If

                    Case ENM_NCR_STAGE._50_事前審査確認
                        Call CmbDestTANTO_Validating(cmbST05_DestTANTO, Nothing)
                        Call dtUPD_YMD_Validating(dtST05_UPD_YMD, Nothing)

                    Case ENM_NCR_STAGE._60_再審審査判定_技術代表
                        Call CmbST06_SAISIN_IINKAI_HANTEI_Validating(cmbST06_SAISIN_IINKAI_HANTEI, Nothing)
                        Call CmbDestTANTO_Validating(cmbST06_DestTANTO, Nothing)
                        Call dtUPD_YMD_Validating(dtST06_UPD_YMD, Nothing)

                    Case ENM_NCR_STAGE._61_再審審査判定_品証代表
                        Call CmbST06_SAISIN_IINKAI_HANTEI_Validating(cmbST06_SAISIN_IINKAI_HANTEI, Nothing)
                        Call CmbDestTANTO_Validating(cmbST07_DestTANTO, Nothing)
                        Call dtUPD_YMD_Validating(dtST07_UPD_YMD, Nothing)

                    Case ENM_NCR_STAGE._70_顧客再審処置_I_tag
                        Call CmbST07_SAISIN_TANTO_Validating(cmbST07_SAISIN_TANTO, Nothing)
                        Call CmbST07_KOKYAKU_HANTEI_SIJI_Validating(cmbST07_KOKYAKU_HANTEI_SIJI, Nothing)
                        Call CmbST07_KOKYAKU_SAISYU_HANTEI_Validating(cmbST07_KOKYAKU_SAISYU_HANTEI, Nothing)
                        Call CmbDestTANTO_Validating(cmbST08_DestTANTO, Nothing)
                        Call dtUPD_YMD_Validating(dtST08_UPD_YMD, Nothing)

                    Case ENM_NCR_STAGE._80_処置実施, ENM_NCR_STAGE._81_処置実施_生技, ENM_NCR_STAGE._82_処置実施_製造, ENM_NCR_STAGE._83_処置実施_検査

                        Dim strPageName As String = FunGetST08SubPageName()
                        Select Case Val(strPageName.Substring(11, 1))
                            Case ENM_NCR_STAGE80_TABPAGES._1_廃却実施記録
                                Call CmbST08_1_HAIKYAKU_KB_Validating(cmbST08_1_HAIKYAKU_KB, Nothing)
                                Call CmbST08_1_HAIKYAKU_TANTO_Validating(cmbST08_1_HAIKYAKU_TANTO, Nothing)
                            Case ENM_NCR_STAGE80_TABPAGES._3_返却実施記録
                                Call CmbST08_2_KENSA_KEKKA_Validating(cmbST08_2_KENSA_KEKKA, Nothing)
                                Call CmbST08_2_TANTO_KENSA_Validating(cmbST08_2_TANTO_KENSA, Nothing)
                                Call CmbST08_2_TANTO_SEIGI_Validating(cmbST08_2_TANTO_SEIGI, Nothing)
                                Call CmbST08_2_TANTO_SEIZO_Validating(cmbST08_2_TANTO_SEIZO, Nothing)
                            Case ENM_NCR_STAGE80_TABPAGES._4_転用先記録
                                Call CmbST08_3_HENKYAKU_TANTO_Validating(cmbST08_3_HENKYAKU_TANTO, Nothing)
                            Case ENM_NCR_STAGE80_TABPAGES._2_再加工指示_記録
                                Call CmbST08_4_BUHIN_BANGO_Validating(cmbST08_4_BUHIN_BANGO, Nothing)
                                Call CmbST08_4_KISYU_Validating(cmbST08_4_KISYU, Nothing)
                            Case Else
                                Throw New ArgumentException("80-2.④ JIZEN_SINSA_HANTEI_KB")
                        End Select

                        Select Case PrCurrentStage
                            Case ENM_NCR_STAGE._80_処置実施
                                Call CmbDestTANTO_Validating(cmbST09_DestTANTO, Nothing)
                                Call dtUPD_YMD_Validating(dtST09_UPD_YMD, Nothing)
                            Case ENM_NCR_STAGE._81_処置実施_生技
                                Call CmbDestTANTO_Validating(cmbST10_DestTANTO, Nothing)
                                Call dtUPD_YMD_Validating(dtST10_UPD_YMD, Nothing)
                            Case ENM_NCR_STAGE._82_処置実施_製造
                                Call CmbDestTANTO_Validating(cmbST11_DestTANTO, Nothing)
                                Call dtUPD_YMD_Validating(dtST11_UPD_YMD, Nothing)
                            Case ENM_NCR_STAGE._83_処置実施_検査
                                Call CmbDestTANTO_Validating(cmbST12_DestTANTO, Nothing)
                                Call dtUPD_YMD_Validating(dtST12_UPD_YMD, Nothing)
                        End Select

                    Case ENM_NCR_STAGE._90_処置実施確認_管理T
                        Call CmbDestTANTO_Validating(cmbST13_DestTANTO, Nothing)

                    Case ENM_NCR_STAGE._100_処置実施決裁_製造課長
                        Call CmbDestTANTO_Validating(cmbST14_DestTANTO, Nothing)

                    Case ENM_NCR_STAGE._110_abcde処置担当
                        Call CmbDestTANTO_Validating(cmbST15_DestTANTO, Nothing)

                    Case ENM_NCR_STAGE._120_abcde処置確認

                    Case Else
                        'Err
                End Select
            End If

            '上記各種Validatingイベントでフラグを更新し、全てOKの場合はTrue
            Return IsValidated
        Catch ex As Exception
            EM.ErrorSyori(ex, False, conblnNonMsg)
            Return False
        End Try
    End Function

#End Region

    ''' <summary>
    ''' 次ステージの承認順Noを取得
    ''' </summary>
    ''' <param name="intCurrentStageID">現ステージID</param>
    ''' <returns></returns>
    Private Function FunGetNextSYONIN_JUN(ByVal intCurrentStageID As Integer) As Integer
        Try

            Dim intNextStageID As Integer

            'SPEC: 50-3 50以降の承認順遷移
            Select Case intCurrentStageID
                Case Is < ENM_NCR_STAGE._50_事前審査確認
                    '50以前の場合は登録順番通り

                    Dim drList As List(Of DataRow) = tblNCR.AsEnumerable().
                                                    Where(Function(r) Val(r.Field(Of Integer)("VALUE")) > intCurrentStageID).ToList
                    If drList.Count > 0 Then
                        intNextStageID = Val(drList(0).Item("VALUE"))
                    End If
                Case ENM_NCR_STAGE._50_事前審査確認
                    Select Case _D003_NCR_J.JIZEN_SINSA_HANTEI_KB
                        Case ENM_JIZEN_SINSA_HANTEI_KB._0_完成する, ENM_JIZEN_SINSA_HANTEI_KB._1_そのまま使用可
                            intNextStageID = ENM_NCR_STAGE._90_処置実施確認_管理T
                        Case ENM_JIZEN_SINSA_HANTEI_KB._2_再審委員会送り
                            intNextStageID = ENM_NCR_STAGE._60_再審審査判定_技術代表
                        Case ENM_JIZEN_SINSA_HANTEI_KB._3_顧客再審申請
                            intNextStageID = ENM_NCR_STAGE._70_顧客再審処置_I_tag
                        Case ENM_JIZEN_SINSA_HANTEI_KB._4_廃却する, ENM_JIZEN_SINSA_HANTEI_KB._5_返却する, ENM_JIZEN_SINSA_HANTEI_KB._6_転用する, ENM_JIZEN_SINSA_HANTEI_KB._7_再加工する
                            intNextStageID = ENM_NCR_STAGE._80_処置実施
                        Case Else
                            'Err
                    End Select

                Case ENM_NCR_STAGE._60_再審審査判定_技術代表
                    intNextStageID = ENM_NCR_STAGE._61_再審審査判定_品証代表

                Case ENM_NCR_STAGE._61_再審審査判定_品証代表

                    Select Case _D003_NCR_J.SAISIN_IINKAI_HANTEI_KB
                        Case ENM_SAISIN_IINKAI_HANTEI_KB._0_完成する, ENM_SAISIN_IINKAI_HANTEI_KB._1_そのまま使用可
                            intNextStageID = ENM_NCR_STAGE._90_処置実施確認_管理T
                        Case ENM_SAISIN_IINKAI_HANTEI_KB._2_顧客再審申請
                            intNextStageID = ENM_NCR_STAGE._70_顧客再審処置_I_tag
                        Case ENM_SAISIN_IINKAI_HANTEI_KB._3_廃却する, ENM_SAISIN_IINKAI_HANTEI_KB._4_返却する, ENM_SAISIN_IINKAI_HANTEI_KB._5_転用する, ENM_SAISIN_IINKAI_HANTEI_KB._6_再加工する
                            intNextStageID = ENM_NCR_STAGE._80_処置実施
                        Case Else
                            'Err
                    End Select

                Case ENM_NCR_STAGE._70_顧客再審処置_I_tag

                    'SPEC: #48
                    Select Case Val(cmbST07_KOKYAKU_SAISYU_HANTEI.SelectedValue)'_D003_NCR_J.KOKYAKU_SAISYU_HANTEI_KB
                        Case ENM_KOKYAKU_SAISYU_HANTEI_KB._3_廃却する, ENM_KOKYAKU_SAISYU_HANTEI_KB._4_返却する, ENM_KOKYAKU_SAISYU_HANTEI_KB._5_転用する
                            intNextStageID = ENM_NCR_STAGE._80_処置実施
                        Case Else
                            If _D003_NCR_J.SAIKAKO_SIJI_FG Then
                                intNextStageID = ENM_NCR_STAGE._80_処置実施
                            Else
                                intNextStageID = ENM_NCR_STAGE._90_処置実施確認_管理T
                            End If
                    End Select

                Case ENM_NCR_STAGE._80_処置実施
                    'If _D003_NCR_J.SAIKAKO_SIJI_FG Then
                    '    intNextStageID = ENM_NCR_STAGE._81_処置実施_生技
                    'Else
                    intNextStageID = ENM_NCR_STAGE._90_処置実施確認_管理T
                    'End If

                'Case ENM_NCR_STAGE._81_処置実施_生技
                '    intNextStageID = ENM_NCR_STAGE._82_処置実施_製造

                'Case ENM_NCR_STAGE._82_処置実施_製造
                '    intNextStageID = ENM_NCR_STAGE._83_処置実施_検査

                'Case ENM_NCR_STAGE._83_処置実施_検査
                '    intNextStageID = ENM_NCR_STAGE._90_処置実施確認_管理T

                Case ENM_NCR_STAGE._90_処置実施確認_管理T
                    intNextStageID = ENM_NCR_STAGE._100_処置実施決裁_製造課長

                Case ENM_NCR_STAGE._100_処置実施決裁_製造課長
                    intNextStageID = ENM_NCR_STAGE._110_abcde処置担当
                Case ENM_NCR_STAGE._110_abcde処置担当
                    intNextStageID = ENM_NCR_STAGE._120_abcde処置確認
                Case Else

            End Select

            Return intNextStageID
        Catch ex As Exception
            EM.ErrorSyori(ex, False, conblnNonMsg)
            Return 0
        End Try
    End Function

    ''' <summary>
    ''' 申請先社員IDを取得
    ''' </summary>
    ''' <param name="intCurrentStageID"></param>
    ''' <returns></returns>
    Private Function FunGetNextSYONIN_TANTO_ID(ByVal intCurrentStageID As Integer) As Integer
        Try

            Dim currentStageTabNo As String = FunConvertSYONIN_JUN_TO_STAGE_NO(intCurrentStageID).ToString("00")
            Dim ctrl As Control() = Me.Controls.Find("cmbST" & currentStageTabNo & "_DestTANTO", True)
            Dim cmbTANTO As ComboboxEx = ctrl(0)

            If cmbTANTO IsNot Nothing Then
                Return cmbTANTO.SelectedValue
            Else
                Return 0
            End If
        Catch ex As Exception
            Throw
        End Try
    End Function

    ''' <summary>
    ''' 承認順Noから該当するタブNoを取得
    ''' </summary>
    ''' <param name="intSYONIN_JUN">承認順No</param>
    ''' <returns></returns>
    Private Function FunConvertSYONIN_JUN_TO_STAGE_NO(intSYONIN_JUN As Integer) As Integer
        Dim intStageTabNo As Integer
        Select Case intSYONIN_JUN
            Case ENM_NCR_STAGE._10_起草入力
                intStageTabNo = 1
            Case ENM_NCR_STAGE._20_起草確認製造GL
                intStageTabNo = 2
            Case ENM_NCR_STAGE._30_起草確認検査
                intStageTabNo = 3
            Case ENM_NCR_STAGE._40_事前審査判定及びCAR要否判定
                intStageTabNo = 4
            Case ENM_NCR_STAGE._50_事前審査確認
                intStageTabNo = 5
            Case ENM_NCR_STAGE._60_再審審査判定_技術代表
                intStageTabNo = 6
            Case ENM_NCR_STAGE._61_再審審査判定_品証代表
                intStageTabNo = 7
            Case ENM_NCR_STAGE._70_顧客再審処置_I_tag
                intStageTabNo = 8
            Case ENM_NCR_STAGE._80_処置実施
                intStageTabNo = 9
            Case ENM_NCR_STAGE._81_処置実施_生技
                intStageTabNo = 10
            Case ENM_NCR_STAGE._82_処置実施_製造
                intStageTabNo = 11
            Case ENM_NCR_STAGE._83_処置実施_検査
                intStageTabNo = 12
            Case ENM_NCR_STAGE._90_処置実施確認_管理T
                intStageTabNo = 13
            Case ENM_NCR_STAGE._100_処置実施決裁_製造課長
                intStageTabNo = 14
            Case ENM_NCR_STAGE._110_abcde処置担当
                intStageTabNo = 15
            Case ENM_NCR_STAGE._120_abcde処置確認
                intStageTabNo = 16
            Case ENM_NCR_STAGE._999_Closed
                intStageTabNo = 999
            Case Else
                'Err
                intStageTabNo = 999
        End Select

        Return intStageTabNo
    End Function

    Private Function FunConvertSTAGE_NO_TO_SYONIN_JUN(intTabNo As Integer) As Integer
        Dim intSTAGE_ID As Integer
        Select Case intTabNo
            Case ENM_NCR_STAGE2._1_起草入力
                intSTAGE_ID = ENM_NCR_STAGE._10_起草入力
            Case ENM_NCR_STAGE2._2_起草確認製造GL
                intSTAGE_ID = ENM_NCR_STAGE._20_起草確認製造GL
            Case ENM_NCR_STAGE2._3_起草確認検査
                intSTAGE_ID = ENM_NCR_STAGE._30_起草確認検査
            Case ENM_NCR_STAGE2._4_事前審査判定及びCAR要否判定
                intSTAGE_ID = ENM_NCR_STAGE._40_事前審査判定及びCAR要否判定
            Case ENM_NCR_STAGE2._5_事前審査確認
                intSTAGE_ID = ENM_NCR_STAGE._50_事前審査確認
            Case ENM_NCR_STAGE2._6_再審審査判定_技術代表
                intSTAGE_ID = ENM_NCR_STAGE._60_再審審査判定_技術代表
            Case ENM_NCR_STAGE2._7_再審審査判定_品証代表
                intSTAGE_ID = ENM_NCR_STAGE._61_再審審査判定_品証代表
            Case ENM_NCR_STAGE2._8_顧客再審処置_I_tag
                intSTAGE_ID = ENM_NCR_STAGE._70_顧客再審処置_I_tag
            Case ENM_NCR_STAGE2._9_処置実施
                intSTAGE_ID = ENM_NCR_STAGE._80_処置実施
            Case ENM_NCR_STAGE2._10_処置実施_生技
                intSTAGE_ID = ENM_NCR_STAGE._81_処置実施_生技
            Case ENM_NCR_STAGE2._11_処置実施_製造
                intSTAGE_ID = ENM_NCR_STAGE._82_処置実施_製造
            Case ENM_NCR_STAGE2._12_処置実施_検査
                intSTAGE_ID = ENM_NCR_STAGE._83_処置実施_検査
            Case ENM_NCR_STAGE2._13_処置実施確認_管理T
                intSTAGE_ID = ENM_NCR_STAGE._90_処置実施確認_管理T
            Case ENM_NCR_STAGE2._14_処置実施決裁_製造課長
                intSTAGE_ID = ENM_NCR_STAGE._100_処置実施決裁_製造課長
            Case ENM_NCR_STAGE2._15_abcde処置担当
                intSTAGE_ID = ENM_NCR_STAGE._110_abcde処置担当
            Case ENM_NCR_STAGE2._16_abcde処置確認
                intSTAGE_ID = ENM_NCR_STAGE._120_abcde処置確認
            Case Else
                intSTAGE_ID = 999
        End Select

        Return intSTAGE_ID
    End Function

    ''' <summary>
    ''' 再発判定
    ''' </summary>
    ''' <returns></returns>
    Private Function FunIsReIssue(ByVal strBUHIN_BANGO As String, ByVal strFUTEKIGO_KB As String, ByVal strFUTEKIGO_S_KB As String) As Boolean

        Dim sbSQL As New System.Text.StringBuilder
        Dim dsList As New DataSet

        If strBUHIN_BANGO.IsNullOrWhiteSpace Or strFUTEKIGO_KB.IsNullOrWhiteSpace Or strFUTEKIGO_S_KB.IsNullOrWhiteSpace Then
            Return False
        Else
            sbSQL.Remove(0, sbSQL.Length)
            sbSQL.Append($"SELECT")
            sbSQL.Append($" *")
            sbSQL.Append($" FROM {NameOf(MODEL.D003_NCR_J)} ")
            sbSQL.Append($" WHERE {NameOf(MODEL.D003_NCR_J.BUHIN_BANGO)} ='{strBUHIN_BANGO}'")
            sbSQL.Append($" AND {NameOf(MODEL.D003_NCR_J.FUTEKIGO_KB)}='{strFUTEKIGO_KB}'")
            sbSQL.Append($" AND {NameOf(MODEL.D003_NCR_J.FUTEKIGO_S_KB)}='{strFUTEKIGO_S_KB}'")
            sbSQL.Append($" AND RTRIM({NameOf(MODEL.D003_NCR_J.DEL_YMDHNS)})<>''")
            If Not _D003_NCR_J.HOKOKU_NO.IsNullOrEmpty Then
                sbSQL.Append($" AND {NameOf(MODEL.D003_NCR_J.HOKOKU_NO)}<>'{_D003_NCR_J.HOKOKU_NO}'")
            End If

            Using DB As ClsDbUtility = DBOpen()
                dsList = DB.GetDataSet(sbSQL.ToString, conblnNonMsg)
            End Using

            Return dsList.Tables(0).Rows.Count > 0
        End If
    End Function

    ''' <summary>
    ''' CAR編集権限判定
    ''' </summary>
    ''' <returns></returns>
    Private Function FunHasAuthCAREdit(ByVal strHOKOKU_NO As String, ByVal intSYAIN_ID As Integer) As Boolean
        Dim sbSQL As New System.Text.StringBuilder
        Dim dsList As New DataSet

        If strHOKOKU_NO.IsNullOrWhiteSpace Or intSYAIN_ID = 0 Then
            Return False
        Else
            sbSQL.Remove(0, sbSQL.Length)
            sbSQL.Append($"SELECT")
            sbSQL.Append($" {NameOf(MODEL.V003_SYONIN_J_KANRI.HOKOKU_NO)}")
            sbSQL.Append($" FROM {NameOf(MODEL.V003_SYONIN_J_KANRI)} ")
            sbSQL.Append($" WHERE {NameOf(MODEL.V003_SYONIN_J_KANRI.SYONIN_HOKOKUSYO_ID)}={Context.ENM_SYONIN_HOKOKUSYO_ID._2_CAR}")
            sbSQL.Append($" AND {NameOf(MODEL.V003_SYONIN_J_KANRI.HOKOKU_NO)}='{strHOKOKU_NO}'")
            sbSQL.Append($" AND {NameOf(MODEL.V003_SYONIN_J_KANRI.SYAIN_ID)}={intSYAIN_ID}")
            Using DB As ClsDbUtility = DBOpen()
                dsList = DB.GetDataSet(sbSQL.ToString, conblnNonMsg)
            End Using

            Return dsList.Tables(0).Rows.Count > 0
        End If

    End Function

    ''' <summary>
    ''' D004実績確認
    ''' </summary>
    ''' <param name="intSYONIN_HOKOKUSYO_ID"></param>
    ''' <param name="strHOKOKU_NO"></param>
    ''' <param name="intSYONIN_JUN"></param>
    ''' <returns></returns>
    Private Function FunExistAchievement(ByVal intSYONIN_HOKOKUSYO_ID As Integer, ByVal strHOKOKU_NO As String, ByVal intSYONIN_JUN As Integer) As Boolean
        Dim sbSQL As New System.Text.StringBuilder
        Dim dsList As New DataSet

        sbSQL.Remove(0, sbSQL.Length)
        sbSQL.Append($"SELECT")
        sbSQL.Append($" {NameOf(MODEL.V003_SYONIN_J_KANRI.HOKOKU_NO)}")
        sbSQL.Append($" FROM {NameOf(MODEL.V003_SYONIN_J_KANRI)} ")
        sbSQL.Append($" WHERE {NameOf(MODEL.V003_SYONIN_J_KANRI.SYONIN_HOKOKUSYO_ID)}={intSYONIN_HOKOKUSYO_ID}")
        sbSQL.Append($" AND {NameOf(MODEL.V003_SYONIN_J_KANRI.HOKOKU_NO)}='{strHOKOKU_NO}'")
        sbSQL.Append($" AND {NameOf(MODEL.V003_SYONIN_J_KANRI.SYONIN_JUN)}={intSYONIN_JUN}")
        Using DB As ClsDbUtility = DBOpen()
            dsList = DB.GetDataSet(sbSQL.ToString, conblnNonMsg)
        End Using

        Return dsList.Tables(0).Rows.Count > 0
    End Function




#End Region

End Class