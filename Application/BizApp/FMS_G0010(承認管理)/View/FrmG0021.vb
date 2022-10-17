Imports System.Threading.Tasks
Imports JMS_COMMON.ClsPubMethod
Imports MODEL

''' <summary>
''' CTS登録画面
''' </summary>
Public Class FrmG0021

#Region "定数・変数"

    Private _V002_NCR_J As New V002_NCR_J
    Private _V003_SYONIN_J_KANRI_List As New List(Of V003_SYONIN_J_KANRI)
    Private _tabPageManager As TabPageManager

    Private IsEditingClosed As Boolean

    Private IsInitializing As Boolean

#End Region

#Region "プロパティ"

    ''' <summary>
    ''' 一覧の選択行データ
    ''' </summary>
    Public Property PrDataRow As DataRow

    '現在のステージ 承認順
    Public Property PrCurrentStage As Integer

    '報告書No
    Public Property PrHOKOKU_NO As String

    'NCR編集画面から開かれているか
    Public Property PrDialog As Boolean

    Public PrRIYU As String = ""

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
        MyBase.ToolTip.SetToolTip(Me.cmdFunc3, My.Resources.infoToolTipMsgNotFoundData)
        MyBase.ToolTip.SetToolTip(Me.cmdFunc4, My.Resources.infoToolTipMsgNotFoundData)
        MyBase.ToolTip.SetToolTip(Me.cmdFunc5, My.Resources.infoToolTipMsgNotFoundData)
        MyBase.ToolTip.SetToolTip(Me.cmdFunc10, My.Resources.infoToolTipMsgNotFoundData)

        cmbDestTANTO.NullValue = 0
        cmbKOKYAKU_EIKYO_HANTEI_COMMENT.NullValue = ""
        dtTUCHI_YMD.Nullable = True
        dtKOKYAKU_NOUNYU_YMD.Nullable = True
        dtZAIKO_SIKAKE_YMD.Nullable = True
        dtOTHER_PROCESS_YMD.Nullable = True
        Me.Height = 750

        rsbtnST99.Enabled = False
        dtFUTEKIGO_HASSEI_YMD.ReadOnly = True

        dtSYOCHI_YOTEI_YMD.MinDate = Date.Today

        dtFUTEKIGO_HASSEI_YMD.ReadOnly = True

        cmbKISYU1.NullValue = 0
        cmbKISYU2.NullValue = 0
        cmbKISYU3.NullValue = 0
        cmbKISYU4.NullValue = 0
        cmbKISYU5.NullValue = 0
        cmbKISYU6.NullValue = 0

        txtBUHIN_INFO1.ShowRemainingChars = False
        txtBUHIN_INFO2.ShowRemainingChars = False
        txtBUHIN_INFO3.ShowRemainingChars = False
        txtBUHIN_INFO4.ShowRemainingChars = False
        txtBUHIN_INFO5.ShowRemainingChars = False
        txtBUHIN_INFO6.ShowRemainingChars = False
        txtFROM1.ShowRemainingChars = False
        txtFROM2.ShowRemainingChars = False
        txtFROM3.ShowRemainingChars = False
        txtFROM4.ShowRemainingChars = False
        txtFROM5.ShowRemainingChars = False
        txtFROM6.ShowRemainingChars = False
        txtTO1.ShowRemainingChars = False
        txtTO2.ShowRemainingChars = False
        txtTO3.ShowRemainingChars = False
        txtTO4.ShowRemainingChars = False
        txtTO5.ShowRemainingChars = False
        txtTO6.ShowRemainingChars = False

    End Sub

#End Region

#Region "Form関連"

    'Loadイベント
    Private Async Sub FrmLoad(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        'Dim imgDlg As New ImageDialog
        Try
            'imgDlg.Show("\\sv04\FMS\RESOURCE\loading.gif", 0)

            PrRIYU = ""
            Await Task.Run(
                Sub()
                    Me.Invoke(
                    Sub()
                        Me.Cursor = Cursors.WaitCursor

                        '-----フォーム初期設定(親フォームから呼び出し)
                        Call FunFormCommonSetting(pub_APP_INFO, pub_SYAIN_INFO, My.Application.Info.Version.ToString)
                        Using DB As ClsDbUtility = DBOpen()
                            lblTytle.Text = FunGetCodeMastaValue(DB, "PG_TITLE", Me.GetType.ToString)
                        End Using

                        '--- モデルクリア
                        _D004_SYONIN_J_KANRI.clear()

                        '-----コントロールデータソース設定
                        cmbKOKYAKU_EIKYO_HANTEI_COMMENT.SetDataSource(tblKOKYAKU_EIKYO_COMMENT.LazyLoad("不適合封じ込め非の理由"), ENM_COMBO_SELECT_VALUE_TYPE._2_Option)

                        '-----画面初期化
                        Call FunInitializeControls()

                        AddHandler rbtnKOKYAKU_EIKYO_HANTEI_KB_T.CheckedChanged, AddressOf RbtnKOKYAKU_EIKYO_HANTEI_KB_CheckedChanged
                        AddHandler rbtnKOKYAKU_EIKYO_HANTEI_KB_F.CheckedChanged, AddressOf RbtnKOKYAKU_EIKYO_HANTEI_KB_CheckedChanged

                        Me.tabSTAGE01.Focus()
                        'Me.ResumeLayout()
                    End Sub)
                End Sub)
        Finally
            FunInitFuncButtonEnabled()
            Me.Cursor = Cursors.Default
            'imgDlg.Close()
            'Me.Visible = True
            Me.WindowState = FormWindowState.Maximized 'Me.Owner.WindowState
        End Try
    End Sub

    Private Sub TabPageMouseWheel(sender As Object, e As MouseEventArgs)
        tabSTAGE01.Focus()
    End Sub

    'Shown
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
                        If IsEditingClosed And PrCurrentStage = ENM_CTS_STAGE._999_Closed Then

                            OpenFormEdit()
                            If PrRIYU.IsNulOrWS Then
                                Exit Sub
                            End If
                        Else
                            If MessageBox.Show("入力内容を保存しますか？", "登録確認", MessageBoxButtons.YesNo, MessageBoxIcon.Information) <> DialogResult.Yes Then Exit Sub
                        End If

                        If FunSAVE(ENM_SAVE_MODE._1_保存) Then
                            Me.DialogResult = DialogResult.OK
                            MessageBox.Show("入力内容を保存しました", "保存完了", MessageBoxButtons.OK, MessageBoxIcon.Information)
                        Else
                            MessageBox.Show("保存処理に失敗しました。", "保存失敗", MessageBoxButtons.OK, MessageBoxIcon.Error)
                        End If
                    End If

                Case 2  '承認申請
                    '申請先タブに切り替え
                    'TabSTAGE.SelectedIndex = 6

                    '入力チェック
                    If FunCheckInput(ENM_SAVE_MODE._2_承認申請) Then
                        Dim strMsg As String
                        If FunGetNextSYONIN_JUN(PrCurrentStage, _V011_FCR_J.KOKYAKU_EIKYO_HANTEI_KB) = ENM_CTS_STAGE._999_Closed Then
                            strMsg = "承認しますか？"
                        Else
                            strMsg = "承認・申請しますか？"
                        End If

                        If MessageBox.Show(strMsg, "承認・申請処理確認", MessageBoxButtons.YesNo, MessageBoxIcon.Information) = DialogResult.Yes Then
                            If FunSAVE(ENM_SAVE_MODE._2_承認申請) Then
                                If PrCurrentStage = ENM_CTS_STAGE._90_部門長 Then
                                    strMsg = "承認しました"
                                Else
                                    strMsg = "承認・申請しました"
                                End If

                                MessageBox.Show(strMsg, "承認・申請処理完了", MessageBoxButtons.OK, MessageBoxIcon.Information)
                                Me.DialogResult = DialogResult.OK

                                'SPEC: 2.(3).E.④
                                Me.Close()
                            Else
                                MessageBox.Show("保存処理に失敗しました。", "保存失敗", MessageBoxButtons.OK, MessageBoxIcon.Error)
                            End If
                        End If
                    End If

                Case 3  'NCR
                    Call OpenFormNCR()

                Case 4  '転送

                    If FunCheckInput(ENM_SAVE_MODE._1_保存) Then
                        If OpenFormTENSO() Then
                            If IsSysAdminUser(pub_SYAIN_INFO.SYAIN_ID) Then
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
                Case 5  '差し戻し
                    Call OpenFormSASIMODOSI()

                Case 9  'CAR
                    Call OpenFormCAR()

                Case 10  '印刷

                    Call FunOpenReportFCR()

                Case 11 '履歴
                    Call OpenFormHistory(Context.ENM_SYONIN_HOKOKUSYO_ID._3_CTS, _V011_FCR_J.HOKOKU_NO)

                Case 12 '閉じる
                    Me.Close()
                Case Else
            End Select
        Catch exDispose As ObjectDisposedException
            System.Console.WriteLine(exDispose.Message)
        Catch ex As Exception
            EM.ErrorSyori(ex, False, conblnNonMsg)
        Finally
            'ボタン可
            System.Windows.Forms.Application.DoEvents()
            For intCNT = 0 To Me.cmdFunc.Length - 1
                Me.cmdFunc(intCNT).Enabled = True
            Next

            'ファンクションキー有効化初期化
            If intFUNC <> 12 Then Call FunInitFuncButtonEnabled()

            '[アクティブ]
            Me.PrPG_STATUS = ENM_PG_STATUS._2_ACTIVE
        End Try

    End Sub

#End Region

#Region "保存・承認申請"

#Region "   保存・承認申請処理メイン"

    ''' <summary>
    ''' 保存・承認申請処理メイン
    ''' </summary>
    ''' <param name="enmSAVE_MODE"></param>
    ''' <returns></returns>
    Private Function FunSAVE(ByVal enmSAVE_MODE As ENM_SAVE_MODE, Optional blnTENSO As Boolean = False) As Boolean
        Try

            Using DB As ClsDbUtility = DBOpen()
                Dim blnErr As Boolean
                Try
                    DB.BeginTransaction()

                    'SPEC: 2.(3).D.①.レコード更新
                    If FunSAVE_D007(DB, enmSAVE_MODE) = False Then blnErr = True : Return False
                    If FunSAVE_D008(DB, enmSAVE_MODE) = False Then blnErr = True : Return False
                    If FunSAVE_FILE(DB) = False Then blnErr = True : Return False

                    If Not blnTENSO And PrCurrentStage < ENM_CTS_STAGE._999_Closed Then
                        If FunSAVE_D004(DB, enmSAVE_MODE) = False Then blnErr = True : Return False
                    End If
                    If FunSAVE_R001(DB, enmSAVE_MODE) = False Then blnErr = True : Return False
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

#Region "   CTS添付ファイル保存"

    ''' <summary>
    ''' CTS添付ファイル保存
    ''' </summary>
    ''' <param name="DB"></param>
    ''' <returns></returns>
    Private Function FunSAVE_FILE(ByRef DB As ClsDbUtility) As Boolean

        If _V011_FCR_J.KOKYAKU_EIKYO_HANTEI_FILEPATH.IsNulOrWS And
            _V011_FCR_J.OTHER_PROCESS_INFLUENCE_FILEPATH.IsNulOrWS And
            _V011_FCR_J.FUTEKIGO_SEIHIN_FILEPATH.IsNulOrWS And
            _V011_FCR_J.KOKYAKU_EIKYO_FILEPATH.IsNulOrWS And
            _V011_FCR_J.SYOCHI_FILEPATH.IsNulOrWS And
            _V011_FCR_J.FOLLOW_PROCESS_OUTFLOW_FILEPATH.IsNulOrWS Then
            Return True
        Else

            Dim strRootDir As String
            Dim strMsg As String
            strRootDir = FunConvPathString(FunGetCodeMastaValue(DB, "添付ファイル保存先", My.Application.Info.AssemblyName))
            If strRootDir.IsNulOrWS OrElse Not System.IO.Directory.Exists(strRootDir) Then

                strMsg = "添付ファイル保存先が設定されていないか、アクセス出来ません。" & vbCrLf &
                         "添付ファイルはシステムに保存されませんが、" & vbCrLf &
                         "登録処理を続行しますか？"

                If MessageBox.Show(strMsg, "ファイル保存先アクセス不可", MessageBoxButtons.OKCancel, MessageBoxIcon.Exclamation) <> vbOK Then
                    Me.DialogResult = DialogResult.Abort
                    Return True
                End If
            Else
                Try
                    Dim tmpPath As String
                    System.IO.Directory.CreateDirectory($"{strRootDir}{_V011_FCR_J.HOKOKU_NO.Trim}\CTS")
                    If Not _V011_FCR_J.KOKYAKU_EIKYO_HANTEI_FILEPATH.IsNulOrWS Then
                        If System.IO.File.Exists(lblKOKYAKU_EIKYO_HANTEI_FILEPATH.Links.Item(0).LinkData) Then
                            tmpPath = strRootDir & _V011_FCR_J.HOKOKU_NO.Trim & "\CTS\" & _V011_FCR_J.KOKYAKU_EIKYO_HANTEI_FILEPATH
                            If lblKOKYAKU_EIKYO_HANTEI_FILEPATH.Links.Item(0).LinkData <> tmpPath Then
                                System.IO.File.Copy(lblKOKYAKU_EIKYO_HANTEI_FILEPATH.Links.Item(0).LinkData, $"{strRootDir}{_V011_FCR_J.HOKOKU_NO.Trim}\CTS\{_V011_FCR_J.KOKYAKU_EIKYO_HANTEI_FILEPATH}", True)
                            End If
                        Else
                            Throw New IO.FileNotFoundException($"1.顧客への影響 資料:{lblKOKYAKU_EIKYO_HANTEI_FILEPATH.Links.Item(0).LinkData}が見つかりません。元の場所に戻すか選択し直してください")
                        End If
                    End If
                    If Not _V011_FCR_J.OTHER_PROCESS_INFLUENCE_FILEPATH.IsNulOrWS Then
                        If System.IO.File.Exists(lblOTHER_PROCESS_INFLUENCE_FILEPATH.Links.Item(0).LinkData) Then
                            tmpPath = strRootDir & _V011_FCR_J.HOKOKU_NO.Trim & "\" & _V011_FCR_J.OTHER_PROCESS_INFLUENCE_FILEPATH
                            If lblOTHER_PROCESS_INFLUENCE_FILEPATH.Links.Item(0).LinkData <> tmpPath Then
                                System.IO.File.Copy(lblOTHER_PROCESS_INFLUENCE_FILEPATH.Links.Item(0).LinkData, $"{strRootDir}{_V011_FCR_J.HOKOKU_NO.Trim}\CTS\{_V011_FCR_J.OTHER_PROCESS_INFLUENCE_FILEPATH}", True)
                            End If
                        Else
                            Throw New IO.FileNotFoundException($"4.他のプロセスへの影響 資料:{lblOTHER_PROCESS_INFLUENCE_FILEPATH.Links.Item(0).LinkData}が見つかりません。元の場所に戻すか選択し直してください")
                        End If
                    End If
                    If Not _V011_FCR_J.FOLLOW_PROCESS_OUTFLOW_FILEPATH.IsNulOrWS Then
                        If System.IO.File.Exists(lblFOLLOW_PROCESS_OUTFLOW_FILEPATH.Links.Item(0).LinkData) Then
                            tmpPath = strRootDir & _V011_FCR_J.HOKOKU_NO.Trim & "\CTS\" & _V011_FCR_J.FOLLOW_PROCESS_OUTFLOW_FILEPATH
                            If lblFOLLOW_PROCESS_OUTFLOW_FILEPATH.Links.Item(0).LinkData <> tmpPath Then
                                System.IO.File.Copy(lblFOLLOW_PROCESS_OUTFLOW_FILEPATH.Links.Item(0).LinkData, $"{strRootDir}{_V011_FCR_J.HOKOKU_NO.Trim}\CTS\{_V011_FCR_J.FOLLOW_PROCESS_OUTFLOW_FILEPATH}", True)
                            End If
                        Else
                            Throw New IO.FileNotFoundException($"4.後続プロセスへの流出 資料:{lblFOLLOW_PROCESS_OUTFLOW_FILEPATH.Links.Item(0).LinkData}が見つかりません。元の場所に戻すか選択し直してください")
                        End If
                    End If
                    If Not _V011_FCR_J.FUTEKIGO_SEIHIN_FILEPATH.IsNulOrWS Then
                        If System.IO.File.Exists(lblFUTEKIGO_SEIHIN_FILEPATH.Links.Item(0).LinkData) Then
                            tmpPath = strRootDir & _V011_FCR_J.HOKOKU_NO.Trim & "\CTS\" & _V011_FCR_J.FUTEKIGO_SEIHIN_FILEPATH
                            If lblFUTEKIGO_SEIHIN_FILEPATH.Links.Item(0).LinkData <> tmpPath Then
                                System.IO.File.Copy(lblFUTEKIGO_SEIHIN_FILEPATH.Links.Item(0).LinkData, $"{strRootDir}{_V011_FCR_J.HOKOKU_NO.Trim}\CTS\{_V011_FCR_J.FUTEKIGO_SEIHIN_FILEPATH}", True)
                            End If
                        Else
                            Throw New IO.FileNotFoundException($"2.不適合製品 資料:{lblFUTEKIGO_SEIHIN_FILEPATH.Links.Item(0).LinkData}が見つかりません。元の場所に戻すか選択し直してください")
                        End If
                    End If
                    If Not _V011_FCR_J.KOKYAKU_EIKYO_FILEPATH.IsNulOrWS Then
                        If System.IO.File.Exists(lblKOKYAKU_EIKYO_FILEPATH.Links.Item(0).LinkData) Then
                            tmpPath = strRootDir & _V011_FCR_J.HOKOKU_NO.Trim & "\CTS\" & _V011_FCR_J.KOKYAKU_EIKYO_FILEPATH
                            If lblKOKYAKU_EIKYO_FILEPATH.Links.Item(0).LinkData <> tmpPath Then
                                System.IO.File.Copy(lblKOKYAKU_EIKYO_FILEPATH.Links.Item(0).LinkData, $"{strRootDir}{_V011_FCR_J.HOKOKU_NO.Trim}\CTS\{_V011_FCR_J.KOKYAKU_EIKYO_FILEPATH}", True)
                            End If
                        Else
                            Throw New IO.FileNotFoundException($"3.顧客影響範囲 資料:{lblKOKYAKU_EIKYO_FILEPATH.Links.Item(0).LinkData}が見つかりません。元の場所に戻すか選択し直してください")
                        End If
                    End If
                    If Not _V011_FCR_J.SYOCHI_FILEPATH.IsNulOrWS Then
                        If System.IO.File.Exists(lblSYOCHI_FILEPATH.Links.Item(0).LinkData) Then
                            tmpPath = strRootDir & _V011_FCR_J.HOKOKU_NO.Trim & "\CTS\" & _V011_FCR_J.SYOCHI_FILEPATH
                            If lblSYOCHI_FILEPATH.Links.Item(0).LinkData <> tmpPath Then
                                System.IO.File.Copy(lblSYOCHI_FILEPATH.Links.Item(0).LinkData, $"{strRootDir}{_V011_FCR_J.HOKOKU_NO.Trim}\CTS\{_V011_FCR_J.SYOCHI_FILEPATH}", True)
                            End If
                        Else
                            Throw New IO.FileNotFoundException($"5,処置実施 資料:{lblSYOCHI_FILEPATH.Links.Item(0).LinkData}が見つかりません。元の場所に戻すか選択し直してください")
                        End If
                    End If

                    Return True
                Catch exNF As IO.FileNotFoundException
                    MessageBox.Show(exNF.Message, "ファイル存在チェック", MessageBoxButtons.OK, MessageBoxIcon.Error)
                    Return False
                Catch exIO As UnauthorizedAccessException
                    strMsg = $"添付ファイル保存先のアクセス権限がありません。{vbCrLf}添付ファイル保存先:{strRootDir}"
                    MessageBox.Show(strMsg, "ファイル保存先アクセス不可", MessageBoxButtons.OK, MessageBoxIcon.Error)
                    Return False
                Catch exIOa As System.IO.IOException
                    MessageBox.Show(exIOa.Message, "添付ファイルアクセス不可", MessageBoxButtons.OK, MessageBoxIcon.Error)
                    Return False
                Catch ex As Exception
                    Throw
                    Return False
                End Try
            End If
        End If
    End Function

#End Region

#Region "   D007"

    ''' <summary>
    ''' CAR実績更新
    ''' </summary>
    ''' <param name="DB"></param>
    ''' <returns></returns>
    Private Function FunSAVE_D007(ByRef DB As ClsDbUtility, ByVal enmSAVE_MODE As ENM_SAVE_MODE) As Boolean
        Dim sbSQL As New System.Text.StringBuilder
        Dim strRET As String
        Dim sqlEx As New Exception
        Dim strSysDate As String = DB.GetSysDateString

#Region "モデル更新"

        _D007.Clear()
        _D007.HOKOKU_NO = PrHOKOKU_NO

        If (FunGetNextSYONIN_JUN(PrCurrentStage, _V011_FCR_J.KOKYAKU_EIKYO_HANTEI_KB) = ENM_CTS_STAGE._999_Closed) And enmSAVE_MODE = ENM_SAVE_MODE._2_承認申請 Then
            _D007._CLOSE_FG = 1
        End If
        If rbtnKOKYAKU_EIKYO_HANTEI_KB_T.Checked Then
            _D007._KOKYAKU_EIKYO_HANTEI_KB = "1"
            _D007.KOKYAKU_EIKYO_HANTEI_COMMENT = ""
            _D007.KOKYAKU_EIKYO_NAIYO = txtKOKYAKU_EIKYO_NAIYO.Text
            _D007.KAKUNIN_SYUDAN = txtKAKUNIN_SYUDAN.Text
            _D007._KOKYAKU_EIKYO_TUCHI_HANTEI_KB = If(rbtnKOKYAKU_EIKYO_TUCHI_HANTEI_KB_T.Checked, "1", "0")
            _D007.TUCHI_YMD = dtTUCHI_YMD.ValueNonFormat
            _D007.TUCHI_SYUDAN = txtTUCHI_SYUDAN.Text
            _D007.HITUYO_TETUDUKI_ZIKO = txtHITUYO_TETUDUKI_ZIKO.Text
            _D007.KOKYAKU_EIKYO_ETC_COMMENT = txtKOKYAKU_EIKYO_ETC_COMMENT.Text
            _D007.KOKYAKU_EIKYO_HANTEI_FILEPATH = _V011_FCR_J.KOKYAKU_EIKYO_HANTEI_FILEPATH
            _D007.FUTEKIGO_SEIHIN_MEMO = txtFUTEKIGO_SEIHIN_MEMO.Text
            _D007.KOKYAKU_EIKYO_MEMO = txtKOKYAKU_EIKYO_MEMO.Text

            _D007.KOKYAKU_EIKYO_FILEPATH = _V011_FCR_J.KOKYAKU_EIKYO_FILEPATH
            _D007.SYOCHI_MEMO = txtSYOCHI_MEMO.Text
            _D007.SYOCHI_FILEPATH = _V011_FCR_J.SYOCHI_FILEPATH
        Else
            _D007._KOKYAKU_EIKYO_HANTEI_KB = "0"
            _D007.KOKYAKU_EIKYO_HANTEI_COMMENT = cmbKOKYAKU_EIKYO_HANTEI_COMMENT.Text
            _D007.KOKYAKU_EIKYO_NAIYO = ""
            _D007.KAKUNIN_SYUDAN = ""
            _D007._KOKYAKU_EIKYO_TUCHI_HANTEI_KB = "0"
            _D007.TUCHI_YMD = ""
            _D007.TUCHI_SYUDAN = ""
            _D007.HITUYO_TETUDUKI_ZIKO = ""
            _D007.KOKYAKU_EIKYO_ETC_COMMENT = ""
            _D007.KOKYAKU_NOUNYU_NAIYOU = ""
            _D007.KOKYAKU_NOUNYU_YMD = ""
            _D007.ZAIKO_SIKAKE_NAIYOU = ""
            _D007.ZAIKO_SIKAKE_YMD = ""
            _D007.OTHER_PROCESS_NAIYOU = ""
            _D007.OTHER_PROCESS_YMD = ""
            _D007.KOKYAKU_EIKYO_HANTEI_FILEPATH = ""
            _D007.FUTEKIGO_SEIHIN_MEMO = ""
            _D007.KOKYAKU_EIKYO_MEMO = ""
            _D007.FUTEKIGO_SEIHIN_FILEPATH = ""
            _D007.KOKYAKU_EIKYO_FILEPATH = ""
            _D007.SYOCHI_MEMO = ""
            _D007.SYOCHI_FILEPATH = ""
        End If

        _D007.TAISYOU_KOKYAKU = txtTAISYO_KOKYAKU.Text

        _D007.FUTEKIGO_SEIHIN_FILEPATH = _V011_FCR_J.FUTEKIGO_SEIHIN_FILEPATH
        _D007.KOKYAKU_EIKYO_FILEPATH = _V011_FCR_J.KOKYAKU_EIKYO_FILEPATH

        _D007._OTHER_PROCESS_INFLUENCE_KB = If(rbtnOTHER_PROCESS_INFLUENCE_KB_T.Checked, "1", "0")
        If rbtnOTHER_PROCESS_INFLUENCE_KB_T.Checked Then
            _D007.OTHER_PROCESS_INFLUENCE_MEMO = txtOTHER_PROCESS_INFLUENCE_MEMO.Text
            _D007.OTHER_PROCESS_INFLUENCE_FILEPATH = _V011_FCR_J.OTHER_PROCESS_INFLUENCE_FILEPATH
        End If

        _D007._FOLLOW_PROCESS_OUTFLOW_KB = If(rbtnFOLLOW_PROCESS_OUTFLOW_KB_T.Checked, "1", "0")
        If rbtnFOLLOW_PROCESS_OUTFLOW_KB_T.Checked Then
            _D007.FOLLOW_PROCESS_OUTFLOW_FILEPATH = _V011_FCR_J.FOLLOW_PROCESS_OUTFLOW_FILEPATH
            _D007.FOLLOW_PROCESS_OUTFLOW_MEMO = txtFOLLOW_PROCESS_OUTFLOW_MEMO.Text
        End If

        If _D007._OTHER_PROCESS_INFLUENCE_KB = "0" And _D007._FOLLOW_PROCESS_OUTFLOW_KB = "0" Then
            _D007.OTHER_PROCESS_NAIYOU = ""
            _D007.OTHER_PROCESS_YMD = ""
        Else
            _D007.OTHER_PROCESS_NAIYOU = txtOTHER_PROCESS_NAIYOU.Text
            _D007.OTHER_PROCESS_YMD = dtOTHER_PROCESS_YMD.ValueNonFormat
        End If
        _D007.KOKYAKU_NOUNYU_NAIYOU = txtKOKYAKU_NOUNYU_NAIYOU.Text
        _D007.KOKYAKU_NOUNYU_YMD = dtKOKYAKU_NOUNYU_YMD.ValueNonFormat
        _D007.ZAIKO_SIKAKE_NAIYOU = txtZAIKO_SIKAKE_NAIYOU.Text
        _D007.ZAIKO_SIKAKE_YMD = dtZAIKO_SIKAKE_YMD.ValueNonFormat
        _D007.ADD_YMDHNS = strSysDate
        _D007.ADD_SYAIN_ID = pub_SYAIN_INFO.SYAIN_ID

#End Region

        '-----MERGE
        sbSQL.Remove(0, sbSQL.Length)
        sbSQL.Append($"MERGE INTO {NameOf(D007_FCR_J)} AS SrcT")
        sbSQL.Append($" USING (")
        sbSQL.Append($"{_D007.ToSelectSqlString}")
        sbSQL.Append($" ) AS WK")
        sbSQL.Append($" ON (SrcT.{NameOf(_D007.HOKOKU_NO)} = WK.{NameOf(_D007.HOKOKU_NO)})")
        'UPDATE
        sbSQL.Append($" WHEN MATCHED THEN")
        sbSQL.Append($" UPDATE SET")
        sbSQL.Append($"  SrcT.{NameOf(_D007.CLOSE_FG)}                         = WK.{NameOf(_D007.CLOSE_FG)}")
        sbSQL.Append($" ,SrcT.{NameOf(_D007.KOKYAKU_EIKYO_HANTEI_KB)}          = WK.{NameOf(_D007.KOKYAKU_EIKYO_HANTEI_KB)}")
        sbSQL.Append($" ,SrcT.{NameOf(_D007.TAISYOU_KOKYAKU)}                  = WK.{NameOf(_D007.TAISYOU_KOKYAKU)}")
        sbSQL.Append($" ,SrcT.{NameOf(_D007.KOKYAKU_EIKYO_HANTEI_COMMENT)}     = WK.{NameOf(_D007.KOKYAKU_EIKYO_HANTEI_COMMENT)}")
        sbSQL.Append($" ,SrcT.{NameOf(_D007.KOKYAKU_EIKYO_NAIYO)}              = WK.{NameOf(_D007.KOKYAKU_EIKYO_NAIYO)}")
        sbSQL.Append($" ,SrcT.{NameOf(_D007.KAKUNIN_SYUDAN)}                   = WK.{NameOf(_D007.KAKUNIN_SYUDAN)}")
        sbSQL.Append($" ,SrcT.{NameOf(_D007.KOKYAKU_EIKYO_TUCHI_HANTEI_KB)}    = WK.{NameOf(_D007.KOKYAKU_EIKYO_TUCHI_HANTEI_KB)}")
        sbSQL.Append($" ,SrcT.{NameOf(_D007.TUCHI_YMD)}                        = WK.{NameOf(_D007.TUCHI_YMD)}")
        sbSQL.Append($" ,SrcT.{NameOf(_D007.TUCHI_SYUDAN)}                     = WK.{NameOf(_D007.TUCHI_SYUDAN)}")
        sbSQL.Append($" ,SrcT.{NameOf(_D007.HITUYO_TETUDUKI_ZIKO)}             = WK.{NameOf(_D007.HITUYO_TETUDUKI_ZIKO)}")
        sbSQL.Append($" ,SrcT.{NameOf(_D007.KOKYAKU_EIKYO_ETC_COMMENT)}        = WK.{NameOf(_D007.KOKYAKU_EIKYO_ETC_COMMENT)}")
        sbSQL.Append($" ,SrcT.{NameOf(_D007.OTHER_PROCESS_INFLUENCE_KB)}       = WK.{NameOf(_D007.OTHER_PROCESS_INFLUENCE_KB)}")
        sbSQL.Append($" ,SrcT.{NameOf(_D007.FOLLOW_PROCESS_OUTFLOW_KB)}        = WK.{NameOf(_D007.FOLLOW_PROCESS_OUTFLOW_KB)}")
        sbSQL.Append($" ,SrcT.{NameOf(_D007.KOKYAKU_NOUNYU_NAIYOU)}            = WK.{NameOf(_D007.KOKYAKU_NOUNYU_NAIYOU)}")
        sbSQL.Append($" ,SrcT.{NameOf(_D007.KOKYAKU_NOUNYU_YMD)}               = WK.{NameOf(_D007.KOKYAKU_NOUNYU_YMD)}")
        sbSQL.Append($" ,SrcT.{NameOf(_D007.ZAIKO_SIKAKE_NAIYOU)}              = WK.{NameOf(_D007.ZAIKO_SIKAKE_NAIYOU)}")
        sbSQL.Append($" ,SrcT.{NameOf(_D007.ZAIKO_SIKAKE_YMD)}                 = WK.{NameOf(_D007.ZAIKO_SIKAKE_YMD)}")
        sbSQL.Append($" ,SrcT.{NameOf(_D007.OTHER_PROCESS_NAIYOU)}             = WK.{NameOf(_D007.OTHER_PROCESS_NAIYOU)}")
        sbSQL.Append($" ,SrcT.{NameOf(_D007.OTHER_PROCESS_YMD)}                = WK.{NameOf(_D007.OTHER_PROCESS_YMD)}")
        sbSQL.Append($" ,SrcT.{NameOf(_D007.KOKYAKU_EIKYO_HANTEI_FILEPATH)}    = WK.{NameOf(_D007.KOKYAKU_EIKYO_HANTEI_FILEPATH)}")
        sbSQL.Append($" ,SrcT.{NameOf(_D007.FUTEKIGO_SEIHIN_MEMO)}             = WK.{NameOf(_D007.FUTEKIGO_SEIHIN_MEMO)}")
        sbSQL.Append($" ,SrcT.{NameOf(_D007.KOKYAKU_EIKYO_MEMO)}               = WK.{NameOf(_D007.KOKYAKU_EIKYO_MEMO)}")
        sbSQL.Append($" ,SrcT.{NameOf(_D007.OTHER_PROCESS_INFLUENCE_MEMO)}     = WK.{NameOf(_D007.OTHER_PROCESS_INFLUENCE_MEMO)}")
        sbSQL.Append($" ,SrcT.{NameOf(_D007.OTHER_PROCESS_INFLUENCE_FILEPATH)} = WK.{NameOf(_D007.OTHER_PROCESS_INFLUENCE_FILEPATH)}")
        sbSQL.Append($" ,SrcT.{NameOf(_D007.FOLLOW_PROCESS_OUTFLOW_MEMO)}      = WK.{NameOf(_D007.FOLLOW_PROCESS_OUTFLOW_MEMO)}")
        sbSQL.Append($" ,SrcT.{NameOf(_D007.FOLLOW_PROCESS_OUTFLOW_FILEPATH)}  = WK.{NameOf(_D007.FOLLOW_PROCESS_OUTFLOW_FILEPATH)}")
        sbSQL.Append($" ,SrcT.{NameOf(_D007.FUTEKIGO_SEIHIN_FILEPATH)}         = WK.{NameOf(_D007.FUTEKIGO_SEIHIN_FILEPATH)}")
        sbSQL.Append($" ,SrcT.{NameOf(_D007.KOKYAKU_EIKYO_FILEPATH)}           = WK.{NameOf(_D007.KOKYAKU_EIKYO_FILEPATH)}")
        sbSQL.Append($" ,SrcT.{NameOf(_D007.SYOCHI_MEMO)}                      = WK.{NameOf(_D007.SYOCHI_MEMO)}")
        sbSQL.Append($" ,SrcT.{NameOf(_D007.SYOCHI_FILEPATH)}                  = WK.{NameOf(_D007.SYOCHI_FILEPATH)}")
        sbSQL.Append($" ,SrcT.{NameOf(_D007.UPD_SYAIN_ID)}                     = WK.{NameOf(_D007.UPD_SYAIN_ID)}")
        sbSQL.Append($" ,SrcT.{NameOf(_D007.UPD_YMDHNS)}                       = WK.{NameOf(_D007.UPD_YMDHNS)}")
        'INSERT
        sbSQL.Append($" WHEN NOT MATCHED THEN ")
        sbSQL.Append($"INSERT(")
        _D007.Properties.Take(1).ForEach(Sub(p) sbSQL.Append($" {p.Name}"))
        _D007.Properties.Skip(1).ForEach(Sub(p) sbSQL.Append($",{p.Name}"))
        sbSQL.Append($" ) VALUES(")
        _D007.Properties.Take(1).ForEach(Sub(p) sbSQL.Append($" WK.{p.Name}"))
        _D007.Properties.Skip(1).ForEach(Sub(p) sbSQL.Append($",WK.{p.Name}"))
        sbSQL.Append($" ) ")
        sbSQL.Append($"OUTPUT $action AS RESULT;")
        strRET = DB.ExecuteScalar(sbSQL.ToString, conblnNonMsg, sqlEx)
        Select Case strRET
            Case "INSERT"
                'Error レコード挿入はNCR40で実施のはず

            Case "UPDATE"

            Case Else
                '-----エラーログ出力
                Dim strErrMsg As String = My.Resources.ErrLogSqlExecutionFailure & sbSQL.ToString & "|" & sqlEx.Message
                WL.WriteLogDat(strErrMsg)
                Return False
        End Select
        WL.WriteLogDat($"[DEBUG]CAR 報告書NO:{_D007.HOKOKU_NO}、MERGE D007")

        Return True
    End Function

#End Region

#Region "   D008"

    Private Function FunSAVE_D008(ByRef DB As ClsDbUtility, ByVal enmSAVE_MODE As ENM_SAVE_MODE) As Boolean
        Dim sbSQL As New System.Text.StringBuilder
        Dim strRET As String
        Dim sqlEx As New Exception
        Dim strSysDate As String = DB.GetSysDateString

        Dim _D008 As New D008_FCR_J_SUB

        For i As Integer = 1 To 6

#Region "   モデル更新"

            _D008.Clear()
            _D008.HOKOKU_NO = _V011_FCR_J.HOKOKU_NO
            _D008.ROW_NO = i
            _D008.ADD_YMDHNS = strSysDate
            _D008.ADD_SYAIN_ID = pub_SYAIN_INFO.SYAIN_ID

            Dim pnlCtrl = GetControlByName(Me, $"pnlInfo{i}")
            If pnlCtrl IsNot Nothing AndAlso pnlCtrl.Enabled Then
                _D008.KISYU_ID = _V011_FCR_J.Item("KISYU_ID" & i)
                _D008.BUHIN_INFO = _V011_FCR_J.Item("BUHIN_INFO" & i)
                _D008.SURYO = _V011_FCR_J.Item("SURYO" & i)
                _D008.RANGE_FROM = _V011_FCR_J.Item("RANGE_FROM" & i)
                _D008.RANGE_TO = _V011_FCR_J.Item("RANGE_TO" & i)
            End If

#End Region

            '-----MERGE
            sbSQL.Remove(0, sbSQL.Length)
            sbSQL.Append($"MERGE INTO {NameOf(D008_FCR_J_SUB)} AS SrcT")
            sbSQL.Append($" USING (")
            sbSQL.Append($"{_D008.ToSelectSqlString}")
            sbSQL.Append($" ) AS WK")
            sbSQL.Append($" ON (SrcT.{NameOf(_D008.HOKOKU_NO)} = WK.{NameOf(_D008.HOKOKU_NO)}")
            sbSQL.Append($" AND SrcT.{NameOf(_D008.ROW_NO)} = WK.{NameOf(_D008.ROW_NO)})")
            'UPDATE
            sbSQL.Append($" WHEN MATCHED THEN")
            sbSQL.Append($" UPDATE SET")
            sbSQL.Append($"  SrcT.{NameOf(_D008.KISYU_ID)} = WK.{NameOf(_D008.KISYU_ID)}")
            sbSQL.Append($" ,SrcT.{NameOf(_D008.BUHIN_INFO)} = WK.{NameOf(_D008.BUHIN_INFO)}")
            sbSQL.Append($" ,SrcT.{NameOf(_D008.SURYO)} = WK.{NameOf(_D008.SURYO)}")
            sbSQL.Append($" ,SrcT.{NameOf(_D008.RANGE_FROM)} = WK.{NameOf(_D008.RANGE_FROM)}")
            sbSQL.Append($" ,SrcT.{NameOf(_D008.RANGE_TO)} = WK.{NameOf(_D008.RANGE_TO)}")
            sbSQL.Append($" ,SrcT.{NameOf(_D008.UPD_SYAIN_ID)} = WK.{NameOf(_D008.UPD_SYAIN_ID)}")
            sbSQL.Append($" ,SrcT.{NameOf(_D008.UPD_YMDHNS)} = WK.{NameOf(_D008.UPD_YMDHNS)}")
            'INSERT
            sbSQL.Append($" WHEN NOT MATCHED THEN ")
            sbSQL.Append($"INSERT(")
            _D008.Properties.Take(1).ForEach(Sub(p) sbSQL.Append($" {p.Name}"))
            _D008.Properties.Skip(1).ForEach(Sub(p) sbSQL.Append($",{p.Name}"))
            sbSQL.Append($" ) VALUES(")
            _D008.Properties.Take(1).ForEach(Sub(p) sbSQL.Append($" WK.{p.Name}"))
            _D008.Properties.Skip(1).ForEach(Sub(p) sbSQL.Append($",WK.{p.Name}"))
            sbSQL.Append($" ) ")
            sbSQL.Append($"OUTPUT $action AS RESULT;")
            strRET = DB.ExecuteScalar(sbSQL.ToString, conblnNonMsg, sqlEx)
            Select Case strRET
                Case "INSERT"

                Case "UPDATE"

                Case Else
                    '-----エラーログ出力
                    Dim strErrMsg As String = My.Resources.ErrLogSqlExecutionFailure & sbSQL.ToString & "|" & sqlEx.Message
                    WL.WriteLogDat(strErrMsg)
                    Return False
            End Select
        Next

        WL.WriteLogDat($"[DEBUG]CTS 報告書NO:{_D008.HOKOKU_NO}、MERGE D008")

        Return True
    End Function

#End Region

#Region "   D004 承認実績管理更新"

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

        Try

#Region "   CurrentStage"

            '-----データモデル更新
            _D004_SYONIN_J_KANRI.SYONIN_HOKOKUSYO_ID = Context.ENM_SYONIN_HOKOKUSYO_ID._3_CTS
            _D004_SYONIN_J_KANRI.HOKOKU_NO = _V011_FCR_J.HOKOKU_NO
            _D004_SYONIN_J_KANRI.MAIL_SEND_FG = True
            _D004_SYONIN_J_KANRI.ADD_SYAIN_ID = pub_SYAIN_INFO.SYAIN_ID
            _D004_SYONIN_J_KANRI.ADD_YMDHNS = strSysDate

            If PrCurrentStage = ENM_CTS_STAGE._10_起草入力 Then
                _D004_SYONIN_J_KANRI.UPD_SYAIN_ID = pub_SYAIN_INFO.SYAIN_ID
            End If

            _D004_SYONIN_J_KANRI.SYONIN_YMDHNS = dtUPD_YMD.ValueNonFormat & "000000"

            '#80 承認申請日は画面で入力
            If _D004_SYONIN_J_KANRI.SYONIN_YMDHNS.IsNulOrWS Then
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

                Case ENM_SAVE_MODE._2_承認申請
                    _D004_SYONIN_J_KANRI.SYONIN_JUN = PrCurrentStage
                    _D004_SYONIN_J_KANRI.SYONIN_HANTEI_KB = ENM_SYONIN_HANTEI_KB._1_承認
                Case Else
                    'Err
                    Return False
            End Select

            _D004_SYONIN_J_KANRI.ADD_YMDHNS = strSysDate 'Now.ToString("yyyyMMddHHmmss")

            '-----MERGE
            sbSQL.Remove(0, sbSQL.Length)
            sbSQL.Append($"MERGE INTO {NameOf(D004_SYONIN_J_KANRI)} AS SrcT")
            sbSQL.Append($" USING (")
            sbSQL.Append($" SELECT")
            sbSQL.Append($"   {_D004_SYONIN_J_KANRI.SYONIN_HOKOKUSYO_ID} AS {NameOf(_D004_SYONIN_J_KANRI.SYONIN_HOKOKUSYO_ID)}")
            sbSQL.Append($" ,'{_D004_SYONIN_J_KANRI.HOKOKU_NO}' AS {NameOf(_D004_SYONIN_J_KANRI.HOKOKU_NO)}")
            sbSQL.Append($" , {_D004_SYONIN_J_KANRI.SYONIN_JUN} AS {NameOf(_D004_SYONIN_J_KANRI.SYONIN_JUN)}")
            sbSQL.Append($" ,'{_D004_SYONIN_J_KANRI.SYAIN_ID}' AS {NameOf(_D004_SYONIN_J_KANRI.SYAIN_ID)}")
            sbSQL.Append($" ,'{_D004_SYONIN_J_KANRI.SYONIN_YMDHNS}' AS {NameOf(_D004_SYONIN_J_KANRI.SYONIN_YMDHNS)}")
            sbSQL.Append($" ,'{_D004_SYONIN_J_KANRI.SYONIN_HANTEI_KB}' AS {NameOf(_D004_SYONIN_J_KANRI.SYONIN_HANTEI_KB)}")
            sbSQL.Append($" ,'{_D004_SYONIN_J_KANRI._SASIMODOSI_FG}' AS {NameOf(_D004_SYONIN_J_KANRI.SASIMODOSI_FG)}")
            sbSQL.Append($" ,'{_D004_SYONIN_J_KANRI.RIYU}' AS {NameOf(_D004_SYONIN_J_KANRI.RIYU)}")
            sbSQL.Append($" ,'{_D004_SYONIN_J_KANRI.COMMENT}' AS {NameOf(_D004_SYONIN_J_KANRI.COMMENT)}")
            sbSQL.Append($" ,'{_D004_SYONIN_J_KANRI._MAIL_SEND_FG}' AS {NameOf(_D004_SYONIN_J_KANRI.MAIL_SEND_FG)}")
            sbSQL.Append($" , {_D004_SYONIN_J_KANRI.ADD_SYAIN_ID} AS {NameOf(_D004_SYONIN_J_KANRI.ADD_SYAIN_ID)}")
            sbSQL.Append($" ,'{_D004_SYONIN_J_KANRI.ADD_YMDHNS}' AS {NameOf(_D004_SYONIN_J_KANRI.ADD_YMDHNS)}")
            sbSQL.Append($" , {_D004_SYONIN_J_KANRI.UPD_SYAIN_ID} AS {NameOf(_D004_SYONIN_J_KANRI.UPD_SYAIN_ID)}")
            sbSQL.Append($" ,'{_D004_SYONIN_J_KANRI.UPD_YMDHNS}' AS {NameOf(_D004_SYONIN_J_KANRI.UPD_YMDHNS)}")
            sbSQL.Append($" ) AS WK")
            sbSQL.Append($" ON (SrcT.{NameOf(_D004_SYONIN_J_KANRI.SYONIN_HOKOKUSYO_ID)} = WK.{NameOf(_D004_SYONIN_J_KANRI.SYONIN_HOKOKUSYO_ID)}")
            sbSQL.Append($" AND SrcT.{NameOf(_D004_SYONIN_J_KANRI.HOKOKU_NO)} = WK.{NameOf(_D004_SYONIN_J_KANRI.HOKOKU_NO)}")
            sbSQL.Append($" AND SrcT.{NameOf(_D004_SYONIN_J_KANRI.SYONIN_JUN)} = WK.{NameOf(_D004_SYONIN_J_KANRI.SYONIN_JUN)})")
            'UPDATE
            sbSQL.Append($" WHEN MATCHED THEN")
            sbSQL.Append($" UPDATE SET")
            sbSQL.Append($"  SrcT.{NameOf(_D004_SYONIN_J_KANRI.SYAIN_ID)} = WK.{NameOf(_D004_SYONIN_J_KANRI.SYAIN_ID)}")
            sbSQL.Append($" ,SrcT.{NameOf(_D004_SYONIN_J_KANRI.COMMENT)} = WK.{NameOf(_D004_SYONIN_J_KANRI.COMMENT)}")
            sbSQL.Append($" ,SrcT.{NameOf(_D004_SYONIN_J_KANRI.SASIMODOSI_FG)} = WK.{NameOf(_D004_SYONIN_J_KANRI.SASIMODOSI_FG)}")
            sbSQL.Append($" ,SrcT.{NameOf(_D004_SYONIN_J_KANRI.SYONIN_YMDHNS)} = WK.{NameOf(_D004_SYONIN_J_KANRI.SYONIN_YMDHNS)}")
            sbSQL.Append($" ,SrcT.{NameOf(_D004_SYONIN_J_KANRI.SYONIN_HANTEI_KB)} = WK.{NameOf(_D004_SYONIN_J_KANRI.SYONIN_HANTEI_KB)}")
            sbSQL.Append($" ,SrcT.{NameOf(_D004_SYONIN_J_KANRI.MAIL_SEND_FG)} = WK.{NameOf(_D004_SYONIN_J_KANRI.MAIL_SEND_FG)}")
            sbSQL.Append($" ,SrcT.{NameOf(_D004_SYONIN_J_KANRI.RIYU)} = WK.{NameOf(_D004_SYONIN_J_KANRI.RIYU)}")
            sbSQL.Append($" ,SrcT.{NameOf(_D004_SYONIN_J_KANRI.UPD_SYAIN_ID)} = {pub_SYAIN_INFO.SYAIN_ID}")
            sbSQL.Append($" ,SrcT.{NameOf(_D004_SYONIN_J_KANRI.UPD_YMDHNS)} = '{strSysDate}'")
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
            sbSQL.Append($" ,'{strSysDate}'")
            sbSQL.Append(" ,WK." & NameOf(_D004_SYONIN_J_KANRI.UPD_SYAIN_ID))
            sbSQL.Append($" ,'{strSysDate}'")
            sbSQL.Append(" )")
            sbSQL.Append("OUTPUT $action AS RESULT") 'INSERT OR UPDATE をncarchar(10)で取得する場合
            sbSQL.Append(";")
            strRET = DB.ExecuteScalar(sbSQL.ToString, conblnNonMsg, sqlEx)
            Select Case strRET
                Case "INSERT"

                Case "UPDATE"

                Case Else
                    '-----エラーログ出力
                    Dim strErrMsg As String = My.Resources.ErrLogSqlExecutionFailure & sbSQL.ToString & "|" & sqlEx.Message
                    WL.WriteLogDat(strErrMsg)
                    Return False
            End Select

#End Region

#Region "   NextStage"

            '-----承認申請
            Select Case enmSAVE_MODE
                Case ENM_SAVE_MODE._1_保存
                    '保存実績のみ
                    Return True
                Case ENM_SAVE_MODE._2_承認申請
                    _D004_SYONIN_J_KANRI.SYONIN_JUN = FunGetNextSYONIN_JUN(PrCurrentStage, _V011_FCR_J.KOKYAKU_EIKYO_HANTEI_KB)
                    _D004_SYONIN_J_KANRI.SYAIN_ID = cmbDestTANTO.SelectedValue
                    _D004_SYONIN_J_KANRI.SYONIN_YMDHNS = ""
                    _D004_SYONIN_J_KANRI.MAIL_SEND_FG = False
                    _D004_SYONIN_J_KANRI.SYONIN_HANTEI_KB = ENM_SYONIN_HANTEI_KB._0_未承認
                    _D004_SYONIN_J_KANRI.ADD_YMDHNS = strSysDate
                Case Else
                    'Err
                    Return False
            End Select

            '-----Close処理
            If _D004_SYONIN_J_KANRI.SYONIN_JUN = ENM_CAR_STAGE._999_Closed Then
                _D004_SYONIN_J_KANRI.SYONIN_HANTEI_KB = ENM_SYONIN_HANTEI_KB._1_承認
                _D004_SYONIN_J_KANRI.SYONIN_YMDHNS = strSysDate
            End If

            '-----MERGE
            sbSQL.Remove(0, sbSQL.Length)
            sbSQL.Append($"MERGE INTO {NameOf(D004_SYONIN_J_KANRI)} AS SrcT")
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
            sbSQL.Append($" WHEN MATCHED THEN")
            sbSQL.Append($" UPDATE SET")
            sbSQL.Append($"  SrcT.{NameOf(_D004_SYONIN_J_KANRI.SYAIN_ID)} = WK.{NameOf(_D004_SYONIN_J_KANRI.SYAIN_ID)}")
            sbSQL.Append($" ,SrcT.{NameOf(_D004_SYONIN_J_KANRI.COMMENT)} = WK.{NameOf(_D004_SYONIN_J_KANRI.COMMENT)}")
            sbSQL.Append($" ,SrcT.{NameOf(_D004_SYONIN_J_KANRI.UPD_SYAIN_ID)} = {pub_SYAIN_INFO.SYAIN_ID}")
            sbSQL.Append($" ,SrcT.{NameOf(_D004_SYONIN_J_KANRI.UPD_YMDHNS)} = '{strSysDate}'")
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
            sbSQL.Append($" ,'{strSysDate}'")
            sbSQL.Append(" ,WK." & NameOf(_D004_SYONIN_J_KANRI.UPD_SYAIN_ID))
            sbSQL.Append($" ,'{strSysDate}'")
            sbSQL.Append(" )")
            sbSQL.Append("OUTPUT $action AS RESULT") 'INSERT OR UPDATE をncarchar(10)で取得する場合
            sbSQL.Append(";")

            ''-----MERGE実行&実行結果取得
            strRET = DB.ExecuteScalar(sbSQL.ToString, conblnNonMsg, sqlEx)
            Select Case strRET
                Case "INSERT"
                    If _D004_SYONIN_J_KANRI.SYONIN_HANTEI_KB = ENM_SYONIN_HANTEI_KB._0_未承認 Then
                        '承認依頼メール送信
                        If FunSendRequestMail() Then
                            WL.WriteLogDat($"[DEBUG]CTS 報告書NO:{_V011_FCR_J.HOKOKU_NO}、Send Request Mail")
                        End If
                    End If

                Case "UPDATE"

                Case Else
                    '-----エラーログ出力
                    Dim strErrMsg As String = My.Resources.ErrLogSqlExecutionFailure & sbSQL.ToString & "|" & sqlEx.Message
                    WL.WriteLogDat(strErrMsg)
                    Return False
            End Select

            WL.WriteLogDat($"[DEBUG]CTS 報告書NO:{_V011_FCR_J.HOKOKU_NO}、MERGE D004")

#End Region

            Return True
        Catch ex As Exception
            Throw
        End Try
    End Function

#End Region

#Region "承認依頼メール送信"

    ''' <summary>
    ''' 承認依頼メール送信
    ''' </summary>
    ''' <returns></returns>
    Private Function FunSendRequestMail()
        Dim KISYU_NAME As String = _V011_FCR_J.KISYU_NAME
        Dim SYONIN_HANTEI_NAME As String = tblSYONIN_HANTEI_KB.LazyLoad("承認判定区分").AsEnumerable.Where(Function(r) r.Field(Of String)("VALUE") = _D004_SYONIN_J_KANRI.SYONIN_HANTEI_KB).FirstOrDefault?.Item("DISP")
        Dim strEXEParam As String = _D004_SYONIN_J_KANRI.SYAIN_ID & "," & ENM_OPEN_MODE._2_処置画面起動 & "," & Context.ENM_SYONIN_HOKOKUSYO_ID._2_CAR & "," & _D004_SYONIN_J_KANRI.HOKOKU_NO
        Dim strSubject As String = $"【不適合品処置依頼】[CTS] {KISYU_NAME}"
        Dim strBody As String = <sql><![CDATA[
        {0} 殿<br />
        <br />
        　不適合封じ込め調査書の処置依頼が来ましたので対応をお願いします。<br />
        <br />
        　　【報 告 書】CTS<br />
        　　【報告書No】{1}<br />
        　　【起 草 日】{2}<br />
        　　【機　  種】{3}<br />        　　
        　　【依 頼 者】{5}<br />
        　　【依頼者処置内容】{6}<br />
        　　【コメント】{7}<br />
        <br />
        <a href = "http://sv04:8000/CLICKONCE_FMS.application" > システム起動</a><br />
        <br />
        ※このメールは配信専用です。(返信できません)<br />
        返信する場合は、各担当者のメールアドレスを使用して下さい。<br />
        ]]></sql>.Value.Trim

        'http://sv116:8000/CLICKONCE_FMS.application?SYAIN_ID={8}&EXEPATH={9}&PARAMS={10}

        strBody = String.Format(strBody,
                                Fun_GetUSER_NAME(_D004_SYONIN_J_KANRI.SYAIN_ID),
                                _D004_SYONIN_J_KANRI.HOKOKU_NO,
                                CDate(_V011_FCR_J.ADD_YMDHNS).ToString("yyyy/MM/dd"),
                                KISYU_NAME,
                                "",
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

#End Region

#Region "SAVE R001"

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
        '---存在確認
        Dim dsList As New DataSet
        Dim blnExist As Boolean
        sbSQL.Append($"SELECT {NameOf(R001_HOKOKU_SOUSA.HOKOKU_NO)} FROM {NameOf(R001_HOKOKU_SOUSA)}")
        sbSQL.Append($" WHERE {NameOf(R001_HOKOKU_SOUSA.HOKOKU_NO)} ='{_R001_HOKOKU_SOUSA.HOKOKU_NO}'")
        dsList = DB.GetDataSet(sbSQL.ToString, conblnNonMsg)
        If dsList.Tables(0).Rows.Count > 0 Then
            blnExist = True
        End If

        '-----データモデル更新
        _R001_HOKOKU_SOUSA.SYONIN_HOKOKUSYO_ID = Context.ENM_SYONIN_HOKOKUSYO_ID._3_CTS
        _R001_HOKOKU_SOUSA.HOKOKU_NO = _V011_FCR_J.HOKOKU_NO
        _R001_HOKOKU_SOUSA.SYONIN_JUN = PrCurrentStage
        _R001_HOKOKU_SOUSA.SYAIN_ID = pub_SYAIN_INFO.SYAIN_ID
        _R001_HOKOKU_SOUSA.RIYU = PrRIYU
        'UNDONE: getsysdatetime
        _R001_HOKOKU_SOUSA.ADD_YMDHNS = strSysDate 'Now.ToString("yyyyMMddHHmmss")

        Select Case enmSAVE_MODE
            Case ENM_SAVE_MODE._1_保存

                If PrCurrentStage = ENM_CTS_STAGE._999_Closed Then
                    _R001_HOKOKU_SOUSA.SYONIN_HANTEI_KB = ENM_SYONIN_HANTEI_KB._1_承認
                    _R001_HOKOKU_SOUSA.SOUSA_KB = ENM_HOKOKUSYO_SOUSA_KB._2_更新保存
                Else
                    Return True
                End If

            Case ENM_SAVE_MODE._2_承認申請
                _R001_HOKOKU_SOUSA.SYONIN_HANTEI_KB = ENM_SYONIN_HANTEI_KB._1_承認
                _R001_HOKOKU_SOUSA.SOUSA_KB = ENM_HOKOKUSYO_SOUSA_KB._1_申請
        End Select

        '-----

        '-----INSERT
        sbSQL.Remove(0, sbSQL.Length)
        sbSQL.Append("INSERT INTO " & NameOf(R001_HOKOKU_SOUSA) & "(")
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

        WL.WriteLogDat($"[DEBUG]CTS 報告書NO:{_V011_FCR_J.HOKOKU_NO}、INSERT R001")

        If FunSAVE_R005(DB, _R001_HOKOKU_SOUSA.ADD_YMDHNS) Then
        Else
            Return False
        End If

        If FunSAVE_R006(DB, _R001_HOKOKU_SOUSA.ADD_YMDHNS) Then
        Else
            Return False
        End If

        Return True
    End Function

#End Region

#Region "SAVE R005"

    Private Function FunSAVE_R005(ByRef DB As ClsDbUtility, ByVal strYMDHNS As String) As Boolean
        Dim sbSQL As New System.Text.StringBuilder
        Dim intRET As Integer
        Dim sqlEx As New Exception

        sbSQL.Append($"INSERT INTO {NameOf(R005_FCR_SASIMODOSI)}(")
        sbSQL.Append($" {NameOf(_R005.SASIMODOSI_YMDHNS)}")
        sbSQL.Append($",{NameOf(_R005.HOKOKU_NO)}")
        sbSQL.Append($",{NameOf(_R005.CLOSE_FG)}")
        sbSQL.Append($",{NameOf(_R005.KOKYAKU_EIKYO_HANTEI_KB)}")
        sbSQL.Append($",{NameOf(_R005.TAISYOU_KOKYAKU)}")
        sbSQL.Append($",{NameOf(_R005.KOKYAKU_EIKYO_HANTEI_COMMENT)}")
        sbSQL.Append($",{NameOf(_R005.KOKYAKU_EIKYO_NAIYO)}")
        sbSQL.Append($",{NameOf(_R005.KAKUNIN_SYUDAN)}")
        sbSQL.Append($",{NameOf(_R005.KOKYAKU_EIKYO_TUCHI_HANTEI_KB)}")
        sbSQL.Append($",{NameOf(_R005.TUCHI_YMD)}")
        sbSQL.Append($",{NameOf(_R005.TUCHI_SYUDAN)}")
        sbSQL.Append($",{NameOf(_R005.HITUYO_TETUDUKI_ZIKO)}")
        sbSQL.Append($",{NameOf(_R005.KOKYAKU_EIKYO_ETC_COMMENT)}")
        sbSQL.Append($",{NameOf(_R005.OTHER_PROCESS_INFLUENCE_KB)}")
        sbSQL.Append($",{NameOf(_R005.FOLLOW_PROCESS_OUTFLOW_KB)}")
        sbSQL.Append($",{NameOf(_R005.KOKYAKU_NOUNYU_NAIYOU)}")
        sbSQL.Append($",{NameOf(_R005.KOKYAKU_NOUNYU_YMD)}")
        sbSQL.Append($",{NameOf(_R005.ZAIKO_SIKAKE_NAIYOU)}")
        sbSQL.Append($",{NameOf(_R005.ZAIKO_SIKAKE_YMD)}")
        sbSQL.Append($",{NameOf(_R005.OTHER_PROCESS_NAIYOU)}")
        sbSQL.Append($",{NameOf(_R005.OTHER_PROCESS_YMD)}")

        sbSQL.Append($",{NameOf(_R005.KOKYAKU_EIKYO_HANTEI_FILEPATH)}")
        sbSQL.Append($",{NameOf(_R005.FUTEKIGO_SEIHIN_MEMO)}")
        sbSQL.Append($",{NameOf(_R005.KOKYAKU_EIKYO_MEMO)}")
        sbSQL.Append($",{NameOf(_R005.OTHER_PROCESS_INFLUENCE_MEMO)}")
        sbSQL.Append($",{NameOf(_R005.OTHER_PROCESS_INFLUENCE_FILEPATH)}")
        sbSQL.Append($",{NameOf(_R005.FOLLOW_PROCESS_OUTFLOW_MEMO)}")
        sbSQL.Append($",{NameOf(_R005.FOLLOW_PROCESS_OUTFLOW_FILEPATH)}")
        sbSQL.Append($",{NameOf(_R005.FUTEKIGO_SEIHIN_FILEPATH)}")
        sbSQL.Append($",{NameOf(_R005.KOKYAKU_EIKYO_FILEPATH)}")
        sbSQL.Append($",{NameOf(_R005.SYOCHI_MEMO)}")
        sbSQL.Append($",{NameOf(_R005.SYOCHI_FILEPATH)}")

        sbSQL.Append($" ) VALUES(")
        sbSQL.Append($" '{strYMDHNS}'")
        sbSQL.Append($",'{_D007.HOKOKU_NO}'")
        sbSQL.Append($",'{If(_D007.CLOSE_FG, "1", "0")}'")
        sbSQL.Append($",'{If(_D007.KOKYAKU_EIKYO_HANTEI_KB, "1", "0")}'")
        sbSQL.Append($",'{_D007.TAISYOU_KOKYAKU.ConvertSqlEscape}'")
        sbSQL.Append($",'{_D007.KOKYAKU_EIKYO_HANTEI_COMMENT.ConvertSqlEscape}'")
        sbSQL.Append($",'{_D007.KOKYAKU_EIKYO_NAIYO.ConvertSqlEscape}'")
        sbSQL.Append($",'{_D007.KAKUNIN_SYUDAN}'")
        sbSQL.Append($",'{If(_D007.KOKYAKU_EIKYO_TUCHI_HANTEI_KB, "1", "0")}'")
        sbSQL.Append($",'{_D007.TUCHI_YMD}'")
        sbSQL.Append($",'{_D007.TUCHI_SYUDAN.ConvertSqlEscape}'")
        sbSQL.Append($",'{_D007.HITUYO_TETUDUKI_ZIKO.ConvertSqlEscape}'")
        sbSQL.Append($",'{_D007.KOKYAKU_EIKYO_ETC_COMMENT.ConvertSqlEscape}'")
        sbSQL.Append($",'{If(_D007.OTHER_PROCESS_INFLUENCE_KB, "1", "0")}'")
        sbSQL.Append($",'{If(_D007.FOLLOW_PROCESS_OUTFLOW_KB, "1", "0")}'")
        sbSQL.Append($",'{_D007.KOKYAKU_NOUNYU_NAIYOU.ConvertSqlEscape}'")
        sbSQL.Append($",'{_D007.KOKYAKU_NOUNYU_YMD}'")
        sbSQL.Append($",'{_D007.ZAIKO_SIKAKE_NAIYOU.ConvertSqlEscape}'")
        sbSQL.Append($",'{_D007.ZAIKO_SIKAKE_YMD}'")
        sbSQL.Append($",'{_D007.OTHER_PROCESS_NAIYOU.ConvertSqlEscape}'")
        sbSQL.Append($",'{_D007.OTHER_PROCESS_YMD}'")

        sbSQL.Append($",'{_D007.KOKYAKU_EIKYO_HANTEI_FILEPATH.ConvertSqlEscape}'")
        sbSQL.Append($",'{_D007.FUTEKIGO_SEIHIN_MEMO.ConvertSqlEscape}'")
        sbSQL.Append($",'{_D007.KOKYAKU_EIKYO_MEMO.ConvertSqlEscape}'")
        sbSQL.Append($",'{_D007.OTHER_PROCESS_INFLUENCE_MEMO.ConvertSqlEscape}'")
        sbSQL.Append($",'{_D007.OTHER_PROCESS_INFLUENCE_FILEPATH.ConvertSqlEscape}'")
        sbSQL.Append($",'{_D007.FOLLOW_PROCESS_OUTFLOW_MEMO.ConvertSqlEscape}'")
        sbSQL.Append($",'{_D007.FOLLOW_PROCESS_OUTFLOW_FILEPATH.ConvertSqlEscape}'")
        sbSQL.Append($",'{_D007.FUTEKIGO_SEIHIN_FILEPATH.ConvertSqlEscape}'")
        sbSQL.Append($",'{_D007.KOKYAKU_EIKYO_FILEPATH.ConvertSqlEscape}'")
        sbSQL.Append($",'{_D007.SYOCHI_MEMO.ConvertSqlEscape}'")
        sbSQL.Append($",'{_D007.SYOCHI_FILEPATH.ConvertSqlEscape}'")

        sbSQL.Append(" );")
        intRET = DB.ExecuteNonQuery(sbSQL.ToString, conblnNonMsg, sqlEx)
        If intRET <> 1 Then
            '-----エラーログ出力
            Dim strErrMsg As String = My.Resources.ErrLogSqlExecutionFailure & sbSQL.ToString & "|" & sqlEx.Message
            WL.WriteLogDat(strErrMsg)
            Return False
        Else
            WL.WriteLogDat($"[DEBUG]CTS 報告書NO:{_V011_FCR_J.HOKOKU_NO}、INSERT R005")
            Return True
        End If
    End Function

#End Region

#Region "SAVE R006"

    Private Function FunSAVE_R006(ByRef DB As ClsDbUtility, strYMDHNS As String) As Boolean
        Dim sbSQL As New System.Text.StringBuilder
        Dim strRET As String
        Dim sqlEx As New Exception

        Dim _R006 As New R006_FCR_J_SUB_SASIMODOSI

        For i As Integer = 1 To 6

#Region "   モデル更新"

            If _V011_FCR_J.Item("KISYU_ID" & i) > 0 Then
                _R006.Clear()
                _R006.SASIMODOSI_YMDHNS = strYMDHNS
                _R006.HOKOKU_NO = _V011_FCR_J.HOKOKU_NO
                _R006.ROW_NO = i
                _R006.KISYU_ID = _V011_FCR_J.Item("KISYU_ID" & i)
                _R006.BUHIN_INFO = _V011_FCR_J.Item("BUHIN_INFO" & i)
                _R006.SURYO = _V011_FCR_J.Item("SURYO" & i)
                _R006.RANGE_FROM = _V011_FCR_J.Item("RANGE_FROM" & i)
                _R006.RANGE_TO = _V011_FCR_J.Item("RANGE_TO" & i)
            End If

#End Region

            '-----MERGE
            sbSQL.Remove(0, sbSQL.Length)
            sbSQL.Append($"MERGE INTO {NameOf(R006_FCR_J_SUB_SASIMODOSI)} AS SrcT")
            sbSQL.Append($" USING (")
            sbSQL.Append($"{_R006.ToSelectSqlString}")
            sbSQL.Append($" ) AS WK")
            sbSQL.Append($" ON (SrcT.{NameOf(_R006.HOKOKU_NO)} = WK.{NameOf(_R006.HOKOKU_NO)}")
            sbSQL.Append($" AND SrcT.{NameOf(_R006.ROW_NO)} = WK.{NameOf(_R006.ROW_NO)}")
            sbSQL.Append($" AND SrcT.{NameOf(_R006.SASIMODOSI_YMDHNS)} = WK.{NameOf(_R006.SASIMODOSI_YMDHNS)})")
            'INSERT
            sbSQL.Append($" WHEN NOT MATCHED THEN ")
            sbSQL.Append($"INSERT(")
            _R006.Properties.Take(1).ForEach(Sub(p) sbSQL.Append($" {p.Name}"))
            _R006.Properties.Skip(1).ForEach(Sub(p) sbSQL.Append($",{p.Name}"))
            sbSQL.Append($" ) VALUES(")
            _R006.Properties.Take(1).ForEach(Sub(p) sbSQL.Append($" WK.{p.Name}"))
            _R006.Properties.Skip(1).ForEach(Sub(p) sbSQL.Append($",WK.{p.Name}"))
            sbSQL.Append($" ) ")
            sbSQL.Append($"OUTPUT $action AS RESULT;")
            strRET = DB.ExecuteScalar(sbSQL.ToString, conblnNonMsg, sqlEx)
            Select Case strRET
                Case "INSERT"

                Case "UPDATE"

                Case Else

                    If sqlEx.Source IsNot Nothing Then
                        '-----エラーログ出力
                        Dim strErrMsg As String = My.Resources.ErrLogSqlExecutionFailure & sbSQL.ToString & "|" & sqlEx.Message
                        WL.WriteLogDat(strErrMsg)
                        Return False
                    End If
            End Select
        Next

        WL.WriteLogDat($"[DEBUG]CTS 報告書NO:{_R006.HOKOKU_NO}、MERGE R006")

        Return True
    End Function

#End Region

#End Region

#Region "NCR"

    Private Function OpenFormNCR() As Boolean

        Dim dlgRET As DialogResult

        Try

            Dim sbSQL As New System.Text.StringBuilder
            Dim dsList As New DataSet

            sbSQL.Remove(0, sbSQL.Length)
            sbSQL.Append($"SELECT")
            sbSQL.Append($" {NameOf(V007_NCR_CAR.HOKOKU_NO)},{NameOf(V007_NCR_CAR.SYONIN_JUN)}")
            sbSQL.Append($" FROM {NameOf(V007_NCR_CAR)} ")
            sbSQL.Append($" WHERE {NameOf(V007_NCR_CAR.SYONIN_HOKOKUSYO_ID)}={Context.ENM_SYONIN_HOKOKUSYO_ID._1_NCR.Value}")
            sbSQL.Append($" AND {NameOf(V007_NCR_CAR.HOKOKU_NO)}='{_V011_FCR_J.HOKOKU_NO}'")
            Using DB As ClsDbUtility = DBOpen()
                dsList = DB.GetDataSet(sbSQL.ToString, conblnNonMsg)
            End Using

            Using frmDLG As New FrmG0011
                frmDLG.PrMODE = ENM_DATA_OPERATION_MODE._3_UPDATE
                frmDLG.PrIsDialog = True
                frmDLG.PrCurrentStage = dsList.Tables(0).Rows(0).Item(NameOf(V007_NCR_CAR.SYONIN_JUN))
                frmDLG.PrHOKOKU_NO = dsList.Tables(0).Rows(0).Item(NameOf(V007_NCR_CAR.HOKOKU_NO))

                dlgRET = frmDLG.ShowDialog(Me)
            End Using

            Me.Refresh()

            If dlgRET = Windows.Forms.DialogResult.Cancel Then
                Return False
            Else
            End If

            Return True
        Catch ex As Exception
            EM.ErrorSyori(ex, False, conblnNonMsg)
            Return False
        Finally

        End Try
    End Function

#End Region

#Region "CAR"

    Private Function OpenFormCAR() As Boolean

        Dim dlgRET As DialogResult

        Try

            Dim sbSQL As New System.Text.StringBuilder
            Dim intRET As Integer

            sbSQL.Remove(0, sbSQL.Length)
            sbSQL.Append($"SELECT")
            sbSQL.Append($" COUNT({NameOf(V007_NCR_CAR.HOKOKU_NO)})")
            sbSQL.Append($" FROM {NameOf(V007_NCR_CAR)}")
            sbSQL.Append($" WHERE {NameOf(V007_NCR_CAR.SYONIN_HOKOKUSYO_ID)}={Context.ENM_SYONIN_HOKOKUSYO_ID._2_CAR.Value}")
            sbSQL.Append($" AND {NameOf(V007_NCR_CAR.HOKOKU_NO)}='{_V011_FCR_J.HOKOKU_NO}'")
            sbSQL.Append($" AND {NameOf(V007_NCR_CAR.CLOSE_FG)}='{0}'")
            Using DB As ClsDbUtility = DBOpen()
                intRET = DB.ExecuteScalar(sbSQL.ToString, conblnNonMsg)
            End Using

            If intRET = 0 Then
                MessageBox.Show("CARは起草されていません", "CAR表示", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Return False
            End If

            Using frmDLG As New FrmG0012
                frmDLG.PrDialog = True
                frmDLG.PrHOKOKU_NO = _V011_FCR_J.HOKOKU_NO
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
            frmDLG.PrSYONIN_HOKOKUSYO_ID = Context.ENM_SYONIN_HOKOKUSYO_ID._3_CTS
            frmDLG.PrHOKOKU_NO = PrHOKOKU_NO
            frmDLG.PrBUMON_KB = _V002_NCR_J.BUMON_KB
            frmDLG.PrBUHIN_BANGO = _V002_NCR_J.BUHIN_BANGO
            frmDLG.PrKISO_YMD = DateTime.ParseExact(_V002_NCR_J.ADD_YMD, "yyyyMMdd", Nothing).ToString("yyyy/MM/dd")
            frmDLG.PrKISYU_NAME = tblKISYU.LazyLoad("機種").AsEnumerable.Where(Function(r) r.Field(Of Integer)("VALUE") = _V002_NCR_J.KISYU_ID).FirstOrDefault?.Item("DISP")
            frmDLG.PrCurrentStage = Me.PrCurrentStage
            dlgRET = frmDLG.ShowDialog(Me)

            If dlgRET = Windows.Forms.DialogResult.OK Then
                Me.DialogResult = DialogResult.OK
                Me.Close()
            Else
                Return False
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

#Region "差戻し"

    Private Function OpenFormSASIMODOSI() As Boolean
        Dim frmDLG As New FrmG0016
        Dim dlgRET As DialogResult

        Try
            frmDLG.PrSYONIN_HOKOKUSYO_ID = Context.ENM_SYONIN_HOKOKUSYO_ID._3_CTS
            frmDLG.PrHOKOKU_NO = PrHOKOKU_NO
            frmDLG.PrBUHIN_BANGO = _V002_NCR_J.BUHIN_BANGO
            frmDLG.PrKISO_YMD = DateTime.ParseExact(_V002_NCR_J.ADD_YMD, "yyyyMMdd", Nothing).ToString("yyyy/MM/dd")
            frmDLG.PrKISYU_NAME = tblKISYU.LazyLoad("機種").AsEnumerable.Where(Function(r) r.Field(Of Integer)("VALUE") = _V002_NCR_J.KISYU_ID).FirstOrDefault?.Item("DISP")
            frmDLG.PrCurrentStage = Me.PrCurrentStage
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

    Private Function FunOpenReportFCR() As Boolean
        Dim strOutputFileName As String
        Dim strTEMPFILE As String
        'Dim intRET As Integer

        Try
            Me.Cursor = Cursors.WaitCursor

            'ファイル名
            strOutputFileName = "CTS_" & _V011_FCR_J.HOKOKU_NO & "_Work.xls"

            '既存ファイル削除
            If FunDELETE_FILE(pub_APP_INFO.strOUTPUT_PATH & strOutputFileName) = False Then
                Return False
            End If

            Using iniIF As New IniFile(FunGetRootPath() & "\INI\" & CON_TEMPLATE_INI)
                strTEMPFILE = FunConvRootPath(iniIF.GetIniString("CTS", "FILEPATH"))
            End Using

            'エクセル出力ファイル用意
            If OUT_EXCEL_READY(strTEMPFILE, pub_APP_INFO.strOUTPUT_PATH, strOutputFileName) = False Then
                Return False
            End If
            '-----書込処理
            If FunMakeReportCTS(pub_APP_INFO.strOUTPUT_PATH & strOutputFileName, _V011_FCR_J.HOKOKU_NO) = False Then
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

#Region "修正"

    Private Function OpenFormEdit() As Boolean
        Dim frmDLG As New FrmG0020
        Dim dlgRET As DialogResult

        Try
            frmDLG.PrSYONIN_HOKOKUSYO_ID = Context.ENM_SYONIN_HOKOKUSYO_ID._1_NCR
            frmDLG.PrHOKOKU_NO = _D003_NCR_J.HOKOKU_NO
            frmDLG.PrBUMON_KB = _D003_NCR_J.BUMON_KB
            frmDLG.PrBUHIN_BANGO = _D003_NCR_J.BUHIN_BANGO
            frmDLG.PrKISO_YMD = DateTime.ParseExact(_D003_NCR_J.ADD_YMD, "yyyyMMdd", Nothing).ToString("yyyy/MM/dd")
            frmDLG.PrKISYU_NAME = tblKISYU.LazyLoad("機種").AsEnumerable.Where(Function(r) r.Field(Of Integer)("VALUE") = _D003_NCR_J.KISYU_ID).FirstOrDefault?.Item("DISP")
            frmDLG.PrCurrentStage = Me.PrCurrentStage

            dlgRET = frmDLG.ShowDialog(Me)

            If dlgRET = Windows.Forms.DialogResult.OK Then
                PrRIYU = frmDLG.PrRIYU
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
                    If .Text.Length = 0 OrElse .Text.Substring(0, .Text.IndexOf("(")).IsNulOrWS Then
                        .Text = ""
                        .Visible = False
                    End If
                End With
            Next intFunc

            If FunblnOwnCreated(Context.ENM_SYONIN_HOKOKUSYO_ID._3_CTS, PrHOKOKU_NO, PrCurrentStage) Then '
                cmdFunc1.Enabled = True
                cmdFunc2.Enabled = True
                cmdFunc4.Enabled = True
                cmdFunc5.Enabled = True

                'SPEC: C10-3
                If PrCurrentStage = ENM_CAR_STAGE._10_起草入力 Then
                    cmdFunc5.Enabled = False
                    MyBase.ToolTip.SetToolTip(Me.cmdFunc5, "起草入力で差戻登録は使用出来ません")
                Else
                    cmdFunc5.Enabled = True
                    MyBase.ToolTip.SetToolTip(Me.cmdFunc5, My.Resources.infoToolTipMsgNotFoundData)
                End If
            Else
                'カレントステージが自身の担当でない場合は無効
                cmdFunc1.Enabled = False
                cmdFunc2.Enabled = False
                cmdFunc4.Enabled = False
                cmdFunc5.Enabled = False

                dtUPD_YMD.ReadOnly = True

                MyBase.ToolTip.SetToolTip(Me.cmdFunc5, "登録権限がありません")

                '#52 管理者権限を持つ場合
                Dim blnIsAdmin As Boolean = IsSysAdminUser(pub_SYAIN_INFO.SYAIN_ID)
                If blnIsAdmin Then
                    cmdFunc4.Enabled = True
                    cmdFunc5.Enabled = True
                End If
            End If

            If Not PrDialog Then
                cmdFunc3.Enabled = True
                MyBase.ToolTip.SetToolTip(Me.cmdFunc3, My.Resources.infoToolTipMsgNotFoundData)
                cmdFunc9.Enabled = True
                MyBase.ToolTip.SetToolTip(Me.cmdFunc9, My.Resources.infoToolTipMsgNotFoundData)
            Else
                cmdFunc3.Enabled = False
                MyBase.ToolTip.SetToolTip(Me.cmdFunc3, "既にNCR画面から呼び出されているため使用出来ません")
                cmdFunc9.Enabled = False
                MyBase.ToolTip.SetToolTip(Me.cmdFunc9, "既にCAR画面から呼び出されているため使用出来ません")
            End If

            Select Case PrCurrentStage
                Case ENM_CTS_STAGE._90_部門長
                    cmdFunc2.Text = "承認(F2)"
                Case ENM_CTS_STAGE._999_Closed

                    '#181
                    If IsEditingClosed Then
                        cmdFunc1.Enabled = True
                        cmdFunc1.Text = "保存(F1)"
                    Else
                        cmdFunc1.Enabled = False
                        cmdFunc1.Text = "一時保存(F1)"
                    End If

                    cmdFunc2.Enabled = False
                    cmdFunc4.Enabled = False
                    cmdFunc5.Enabled = False
                    MyBase.ToolTip.SetToolTip(cmdFunc1, "Close済みのため使用出来ません")
                    MyBase.ToolTip.SetToolTip(cmdFunc2, "Close済みのため使用出来ません")
                    MyBase.ToolTip.SetToolTip(cmdFunc4, "Close済みのため使用出来ません")
                    MyBase.ToolTip.SetToolTip(cmdFunc5, "Close済みのため使用出来ません")
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

#Region "コントロールイベント"

#Region "申請先社員"

    Private Sub CmbDestTANTO_Validating(sender As Object, e As System.ComponentModel.CancelEventArgs) Handles cmbDestTANTO.Validating

        Dim cmb As ComboboxEx = DirectCast(sender, ComboboxEx)
        IsValidated *= ErrorProvider.UpdateErrorInfo(cmb, cmb.IsSelected, String.Format(My.Resources.infoMsgRequireSelectOrInput, "申請先社員"))
    End Sub

#End Region

#Region "ヘッダ"

    Private Sub RsbtnST_CheckedChanged(sender As Object, e As EventArgs) Handles rsbtnST01.CheckedChanged,
                                                                        rsbtnST02.CheckedChanged,
                                                                        rsbtnST03.CheckedChanged,
                                                                        rsbtnST04.CheckedChanged,
                                                                        rsbtnST05.CheckedChanged,
                                                                        rsbtnST06.CheckedChanged,
                                                                        rsbtnST07.CheckedChanged,
                                                                        rsbtnST08.CheckedChanged,
                                                                        rsbtnST09.CheckedChanged

        Dim btn As RibbonShapeRadioButton = DirectCast(sender, RibbonShapeRadioButton)
        Dim intStageID As Integer = Val(btn.Name.Substring(7))
        tabSTAGE01.AutoScrollControlIntoView = True
        'Select Case intStageID
        '    Case ENM_CAR_STAGE2._1_起草入力 To ENM_CAR_STAGE2._7_起草確認_品証課長
        '        tabSTAGE01.ScrollControlIntoView(lblSETUMON_1)

        '        pnlFCR.BorderStyle = BorderStyle.FixedSingle
        '        pnlSYOCHI_KIROKU.BorderStyle = BorderStyle.None
        '        pnlZESEI_SYOCHI.BorderStyle = BorderStyle.None
        '        pnlSYOCHI_JISSI.BorderStyle = BorderStyle.None

        '    Case ENM_CAR_STAGE2._8_処置実施記録入力, ENM_CAR_STAGE2._9_処置実施確認
        '        tabSTAGE01.ScrollControlIntoView(lblSYOCHI_KIROKUFlame)

        '        pnlFCR.BorderStyle = BorderStyle.None
        '        pnlSYOCHI_KIROKU.BorderStyle = BorderStyle.FixedSingle
        '        pnlZESEI_SYOCHI.BorderStyle = BorderStyle.None
        '        pnlSYOCHI_JISSI.BorderStyle = BorderStyle.None

        '    Case ENM_CAR_STAGE2._10_是正有効性記入 To ENM_CAR_STAGE2._12_是正有効性確認_品証TL
        '        tabSTAGE01.ScrollControlIntoView(lblZESEI_SYOCHIFlame)

        '        pnlFCR.BorderStyle = BorderStyle.None
        '        pnlSYOCHI_KIROKU.BorderStyle = BorderStyle.None
        '        pnlZESEI_SYOCHI.BorderStyle = BorderStyle.FixedSingle
        '        pnlSYOCHI_JISSI.BorderStyle = BorderStyle.None

        '    Case ENM_CAR_STAGE2._13_是正有効性確認_品証担当課長
        '        tabSTAGE01.ScrollControlIntoView(lblSTAGEFlame13)
        '        pnlFCR.BorderStyle = BorderStyle.None
        '        pnlSYOCHI_KIROKU.BorderStyle = BorderStyle.None
        '        pnlZESEI_SYOCHI.BorderStyle = BorderStyle.None
        '        pnlSYOCHI_JISSI.BorderStyle = BorderStyle.FixedSingle

        'End Select
        tabSTAGE01.AutoScrollControlIntoView = False

    End Sub

    Private Sub tabSTAGE01_Click(sender As Object, e As EventArgs) Handles tabSTAGE01.Click
        sender.Focus
    End Sub

#End Region

    Private Sub RbtnKOKYAKU_EIKYO_HANTEI_KB_CheckedChanged(sender As Object, e As EventArgs)

        Dim blnChecked As Boolean = rbtnKOKYAKU_EIKYO_HANTEI_KB_T.Checked

        If blnChecked Then
            cmbKOKYAKU_EIKYO_HANTEI_COMMENT.Text = ""
        Else
            txtTAISYO_KOKYAKU.Text = ""
            rbtnKOKYAKU_EIKYO_TUCHI_HANTEI_KB_F.Checked = True
            Call RbtnKOKYAKU_EIKYO_TUCHI_HANTEI_KB_CheckedChanged(rbtnKOKYAKU_EIKYO_TUCHI_HANTEI_KB_F, Nothing)
            txtKOKYAKU_EIKYO_NAIYO.Text = ""
            txtKAKUNIN_SYUDAN.Text = ""
            txtKOKYAKU_EIKYO_ETC_COMMENT.Text = ""
            _V011_FCR_J.KOKYAKU_EIKYO_HANTEI_FILEPATH = ""
            lblKOKYAKU_EIKYO_HANTEI_FILEPATH.Visible = False
            lblKOKYAKU_EIKYO_HANTEI_FILEPATH_Clear.Visible = False
            txtFUTEKIGO_SEIHIN_MEMO.Text = ""
            txtKOKYAKU_EIKYO_MEMO.Text = ""

#Region "サブテーブル"

            cmbKISYU1.SelectedIndex = 0
            cmbKISYU2.SelectedIndex = 0
            cmbKISYU3.SelectedIndex = 0
            cmbKISYU4.SelectedIndex = 0
            cmbKISYU5.SelectedIndex = 0
            cmbKISYU6.SelectedIndex = 0
            Call CmbKISYU_SelectedValueChanged(cmbKISYU1, Nothing)
            Call CmbKISYU_SelectedValueChanged(cmbKISYU2, Nothing)
            Call CmbKISYU_SelectedValueChanged(cmbKISYU3, Nothing)
            Call CmbKISYU_SelectedValueChanged(cmbKISYU4, Nothing)
            Call CmbKISYU_SelectedValueChanged(cmbKISYU5, Nothing)
            Call CmbKISYU_SelectedValueChanged(cmbKISYU6, Nothing)

            txtBUHIN_INFO1.Text = ""
            txtBUHIN_INFO2.Text = ""
            txtBUHIN_INFO3.Text = ""
            txtBUHIN_INFO4.Text = ""
            txtBUHIN_INFO5.Text = ""
            txtBUHIN_INFO6.Text = ""
            Call TxtBUHIN_INFO_Validated(txtBUHIN_INFO1, Nothing)
            Call TxtBUHIN_INFO_Validated(txtBUHIN_INFO2, Nothing)
            Call TxtBUHIN_INFO_Validated(txtBUHIN_INFO3, Nothing)
            Call TxtBUHIN_INFO_Validated(txtBUHIN_INFO4, Nothing)
            Call TxtBUHIN_INFO_Validated(txtBUHIN_INFO5, Nothing)
            Call TxtBUHIN_INFO_Validated(txtBUHIN_INFO6, Nothing)

            nupSURYO1.Value = 0
            nupSURYO2.Value = 0
            nupSURYO3.Value = 0
            nupSURYO4.Value = 0
            nupSURYO5.Value = 0
            nupSURYO6.Value = 0
            Call NupSURYO_ValueChanged(nupSURYO1, Nothing)
            Call NupSURYO_ValueChanged(nupSURYO2, Nothing)
            Call NupSURYO_ValueChanged(nupSURYO3, Nothing)
            Call NupSURYO_ValueChanged(nupSURYO4, Nothing)
            Call NupSURYO_ValueChanged(nupSURYO5, Nothing)
            Call NupSURYO_ValueChanged(nupSURYO6, Nothing)

            txtFROM1.Text = ""
            txtFROM2.Text = ""
            txtFROM3.Text = ""
            txtFROM4.Text = ""
            txtFROM5.Text = ""
            txtFROM6.Text = ""
            Call TxtFROM_Validated(txtFROM1, Nothing)
            Call TxtFROM_Validated(txtFROM2, Nothing)
            Call TxtFROM_Validated(txtFROM3, Nothing)
            Call TxtFROM_Validated(txtFROM4, Nothing)
            Call TxtFROM_Validated(txtFROM5, Nothing)
            Call TxtFROM_Validated(txtFROM6, Nothing)

            txtTO1.Text = ""
            txtTO2.Text = ""
            txtTO3.Text = ""
            txtTO4.Text = ""
            txtTO5.Text = ""
            txtTO6.Text = ""
            Call TxtTO_Validated(txtTO1, Nothing)
            Call TxtTO_Validated(txtTO2, Nothing)
            Call TxtTO_Validated(txtTO3, Nothing)
            Call TxtTO_Validated(txtTO4, Nothing)
            Call TxtTO_Validated(txtTO5, Nothing)
            Call TxtTO_Validated(txtTO6, Nothing)

#End Region

            txtFUTEKIGO_SEIHIN_MEMO.Text = ""
            txtKOKYAKU_EIKYO_MEMO.Text = ""
            Call TxtFUTEKIGO_SEIHIN_MEMO_Validated(txtFUTEKIGO_SEIHIN_MEMO, Nothing)
            Call TxtKOKYAKU_EIKYO_MEMO_Validated(txtKOKYAKU_EIKYO_MEMO, Nothing)

            rbtnOTHER_PROCESS_INFLUENCE_KB_F.Checked = True
            rbtnFOLLOW_PROCESS_OUTFLOW_KB_F.Checked = True
            Call RbtnOTHER_PROCESS_INFLUENCE_KB_CheckedChanged(Nothing, Nothing)
            Call RbtnFOLLOW_PROCESS_OUTFLOW_KB_CheckedChanged(Nothing, Nothing)

            _V011_FCR_J.FUTEKIGO_SEIHIN_FILEPATH = ""
            lblFUTEKIGO_SEIHIN_FILEPATH.Visible = False
            lblFUTEKIGO_SEIHIN_FILEPATH_Clear.Visible = False
            _V011_FCR_J.KOKYAKU_EIKYO_FILEPATH = ""
            lblKOKYAKU_EIKYO_FILEPATH.Visible = False
            lblKOKYAKU_EIKYO_FILEPATH_Clear.Visible = False
            _V011_FCR_J.SYOCHI_FILEPATH = ""
            lblSYOCHI_FILEPATH.Visible = False
            lblSYOCHI_FILEPATH_Clear.Visible = False

            txtKOKYAKU_NOUNYU_NAIYOU.Text = ""
            txtZAIKO_SIKAKE_NAIYOU.Text = ""
            txtOTHER_PROCESS_NAIYOU.Text = ""
            dtKOKYAKU_NOUNYU_YMD.Text = ""
            dtZAIKO_SIKAKE_YMD.Text = ""
            dtOTHER_PROCESS_YMD.Text = ""

            pnlSYOCHI_FILEPATH.DisableContaints(False, PanelEx.ENM_PROPERTY._1_Enabled)
        End If

        pnlrbtnTUCHI.DisableContaints(blnChecked, PanelEx.ENM_PROPERTY._1_Enabled)
        pnlSYOCHI_KIROKU.DisableContaints(blnChecked, PanelEx.ENM_PROPERTY._1_Enabled)
        pnlZESEI_SYOCHI.DisableContaints(blnChecked, PanelEx.ENM_PROPERTY._1_Enabled)
        pnlSYOCHI_JISSI.DisableContaints(blnChecked, PanelEx.ENM_PROPERTY._1_Enabled)
        lblOTHER_PROCESS_NAIYOU.Enabled = True
        txtOTHER_PROCESS_NAIYOU.Enabled = True
        dtOTHER_PROCESS_YMD.Enabled = True
        lblKOKYAKU_EIKYO_HANTEI_COMMENT.Visible = Not blnChecked
        cmbKOKYAKU_EIKYO_HANTEI_COMMENT.Visible = Not blnChecked

        Call RbtnOTHER_PROCESS_INFLUENCE_KB_CheckedChanged(Nothing, Nothing)
        Call RbtnFOLLOW_PROCESS_OUTFLOW_KB_CheckedChanged(Nothing, Nothing)

        lblTAISYO_KOKYAKU.Enabled = blnChecked
        lblKOKYAKU_EIKYO_NAIYO.Enabled = blnChecked
        lblKAKUNIN_SYUDAN.Enabled = blnChecked
        lblKOKYAKU_EIKYO_ETC_COMMENT.Enabled = blnChecked
        lblKOKYAKU_EIKYO_TUCHI_HANTEI_KB.Enabled = blnChecked
        lblTUCHI_YMD.Enabled = blnChecked
        lblTUCHI_SYUDAN.Enabled = blnChecked
        lblHITUYO_TETUDUKI_ZIKO.Enabled = blnChecked

        txtTAISYO_KOKYAKU.Enabled = blnChecked
        txtKOKYAKU_EIKYO_NAIYO.Enabled = blnChecked
        txtKAKUNIN_SYUDAN.Enabled = blnChecked
        txtKOKYAKU_EIKYO_ETC_COMMENT.Enabled = blnChecked
        pnlKOKYAKU_EIKYO_HANTEI_FILEPATH.Enabled = blnChecked
    End Sub

    Private Sub RbtnKOKYAKU_EIKYO_TUCHI_HANTEI_KB_CheckedChanged(sender As Object, e As EventArgs) Handles rbtnKOKYAKU_EIKYO_TUCHI_HANTEI_KB_T.CheckedChanged, rbtnKOKYAKU_EIKYO_TUCHI_HANTEI_KB_F.CheckedChanged

        Dim blnChecked As Boolean = rbtnKOKYAKU_EIKYO_TUCHI_HANTEI_KB_T.Checked

        If blnChecked Then
        Else
            dtTUCHI_YMD.ValueNonFormat = ""
            txtTUCHI_SYUDAN.Text = ""
            txtHITUYO_TETUDUKI_ZIKO.Text = ""
        End If

        dtTUCHI_YMD.Enabled = blnChecked
        txtTUCHI_SYUDAN.Enabled = blnChecked
        txtHITUYO_TETUDUKI_ZIKO.Enabled = blnChecked

    End Sub

#Region "SUB_DATA"

    Private Sub CmbKISYU1_Validated(sender As Object, e As EventArgs) Handles cmbKISYU1.Validated
        Dim cmb = DirectCast(sender, ComboboxEx)
        If cmb.SelectedValue <> 0 Then
            pnlInfo2.Enabled = True
        Else
            pnlInfo2.Enabled = False
            cmbKISYU2.SelectedIndex = 0
            txtBUHIN_INFO2.Text = ""
            nupSURYO2.Value = 0
            txtFROM2.Text = ""
            txtTO2.Text = ""
        End If
    End Sub

    Private Sub CmbKISYU2_Validated(sender As Object, e As EventArgs) Handles cmbKISYU2.Validated
        Dim cmb = DirectCast(sender, ComboboxEx)
        If cmb.SelectedValue <> 0 Then
            pnlInfo3.Enabled = True
        Else
            pnlInfo3.Enabled = False
            cmbKISYU3.SelectedIndex = 0
            txtBUHIN_INFO3.Text = ""
            nupSURYO3.Value = 0
            txtFROM3.Text = ""
            txtTO3.Text = ""
        End If
    End Sub

    Private Sub CmbKISYU4_Validated(sender As Object, e As EventArgs) Handles cmbKISYU4.Validated
        Dim cmb = DirectCast(sender, ComboboxEx)
        If cmb.SelectedValue <> 0 Then
            pnlInfo5.Enabled = True
        Else
            pnlInfo5.Enabled = False
            cmbKISYU5.SelectedIndex = 0
            txtBUHIN_INFO5.Text = ""
            nupSURYO5.Value = 0
            txtFROM5.Text = ""
            txtTO5.Text = ""
        End If
    End Sub

    Private Sub CmbKISYU5_Validated(sender As Object, e As EventArgs) Handles cmbKISYU5.Validated
        Dim cmb = DirectCast(sender, ComboboxEx)
        If Not cmb.Text.IsNulOrWS Then
            pnlInfo6.Enabled = True
        Else
            pnlInfo6.Enabled = False
            cmbKISYU6.SelectedIndex = 0
            txtBUHIN_INFO6.Text = ""
            nupSURYO6.Value = 0
            txtFROM6.Text = ""
            txtTO6.Text = ""
        End If
    End Sub

    Private Sub CmbKISYU_SelectedValueChanged(sender As Object, e As EventArgs) Handles cmbKISYU1.SelectedValueChanged,
                                                                                        cmbKISYU2.SelectedValueChanged,
                                                                                        cmbKISYU3.SelectedValueChanged,
                                                                                        cmbKISYU4.SelectedValueChanged,
                                                                                        cmbKISYU5.SelectedValueChanged,
                                                                                        cmbKISYU6.SelectedValueChanged
        Dim cmb = DirectCast(sender, ComboboxEx)
        Dim idx As Integer = cmb.Name.Substring(cmb.Name.Length - 1).ToVal
        If cmb.IsSelected Then
            _V011_FCR_J.Item($"KISYU_ID{idx}") = cmb.SelectedValue.ToString.ToVal
        Else
            _V011_FCR_J.Item($"KISYU_ID{idx}") = 0
        End If
    End Sub

    Private Sub TxtBUHIN_INFO_Validated(sender As Object, e As EventArgs) Handles txtBUHIN_INFO1.Validated,
                                                                                  txtBUHIN_INFO2.Validated,
                                                                                  txtBUHIN_INFO3.Validated,
                                                                                  txtBUHIN_INFO4.Validated,
                                                                                  txtBUHIN_INFO5.Validated,
                                                                                  txtBUHIN_INFO6.Validated
        Dim txt = DirectCast(sender, TextBoxEx)
        Dim idx As Integer = txt.Name.Substring(txt.Name.Length - 1).ToVal
        If Not txt.Text.IsNulOrWS Then
            _V011_FCR_J.Item($"BUHIN_INFO{idx}") = txt.Text
        Else
            _V011_FCR_J.Item($"BUHIN_INFO{idx}") = ""
        End If
    End Sub

    Private Sub TxtFROM_Validated(sender As Object, e As EventArgs) Handles txtFROM1.Validated,
                                                                              txtFROM2.Validated,
                                                                              txtFROM3.Validated,
                                                                              txtFROM4.Validated,
                                                                              txtFROM5.Validated,
                                                                              txtFROM6.Validated
        Dim txt = DirectCast(sender, TextBoxEx)
        Dim idx As Integer = txt.Name.Substring(txt.Name.Length - 1).ToVal
        If Not txt.Text.IsNulOrWS Then
            _V011_FCR_J.Item($"RANGE_FROM{idx}") = txt.Text
        Else
            _V011_FCR_J.Item($"RANGE_FROM{idx}") = ""
        End If
    End Sub

    Private Sub TxtTO_Validated(sender As Object, e As EventArgs) Handles txtTO1.Validated,
                                                                              txtTO2.Validated,
                                                                              txtTO3.Validated,
                                                                              txtTO4.Validated,
                                                                              txtTO5.Validated,
                                                                              txtTO6.Validated
        Dim txt = DirectCast(sender, TextBoxEx)
        Dim idx As Integer = txt.Name.Substring(txt.Name.Length - 1).ToVal
        If Not txt.Text.IsNulOrWS Then
            _V011_FCR_J.Item($"RANGE_TO{idx}") = txt.Text
        Else
            _V011_FCR_J.Item($"RANGE_TO{idx}") = ""
        End If
    End Sub

    Private Sub NupSURYO_ValueChanged(sender As Object, e As EventArgs) Handles nupSURYO1.ValueChanged,
                                                                                nupSURYO2.ValueChanged,
                                                                                nupSURYO3.ValueChanged,
                                                                                nupSURYO4.ValueChanged,
                                                                                nupSURYO5.ValueChanged,
                                                                                nupSURYO6.ValueChanged
        Dim nup = DirectCast(sender, NumericUpDown)
        Dim idx As Integer = nup.Name.Substring(nup.Name.Length - 1).ToVal
        _V011_FCR_J.Item($"SURYO{idx}") = CInt(nup.Value)
    End Sub

#End Region

    Private Sub RbtnOTHER_PROCESS_INFLUENCE_KB_CheckedChanged(sender As Object, e As EventArgs) Handles rbtnOTHER_PROCESS_INFLUENCE_KB_T.CheckedChanged, rbtnOTHER_PROCESS_INFLUENCE_KB_F.CheckedChanged
        Dim blnChecked As Boolean = rbtnOTHER_PROCESS_INFLUENCE_KB_T.Checked

        txtOTHER_PROCESS_INFLUENCE_MEMO.Enabled = blnChecked
        pnlOTHER_PROCESS_INFLUENCE_FILEPATH.Enabled = blnChecked

        If Not blnChecked And Not IsInitializing Then
            txtOTHER_PROCESS_INFLUENCE_MEMO.Text = ""
            _V011_FCR_J.OTHER_PROCESS_INFLUENCE_FILEPATH = ""
            lblOTHER_PROCESS_INFLUENCE_FILEPATH.Visible = False
            lblOTHER_PROCESS_INFLUENCE_FILEPATH_Clear.Visible = False
        End If

        '#256
        lblOTHER_PROCESS_NAIYOU.Enabled = Not (rbtnFOLLOW_PROCESS_OUTFLOW_KB_F.Checked And rbtnOTHER_PROCESS_INFLUENCE_KB_F.Checked)
        txtOTHER_PROCESS_NAIYOU.Enabled = Not (rbtnFOLLOW_PROCESS_OUTFLOW_KB_F.Checked And rbtnOTHER_PROCESS_INFLUENCE_KB_F.Checked)
        dtOTHER_PROCESS_YMD.Enabled = Not (rbtnFOLLOW_PROCESS_OUTFLOW_KB_F.Checked And rbtnOTHER_PROCESS_INFLUENCE_KB_F.Checked)
        If (rbtnFOLLOW_PROCESS_OUTFLOW_KB_F.Checked And rbtnOTHER_PROCESS_INFLUENCE_KB_F.Checked) Then
            txtOTHER_PROCESS_NAIYOU.Text = ""
            dtOTHER_PROCESS_YMD.Text = ""
        End If
    End Sub

    Private Sub RbtnFOLLOW_PROCESS_OUTFLOW_KB_CheckedChanged(sender As Object, e As EventArgs) Handles rbtnFOLLOW_PROCESS_OUTFLOW_KB_T.CheckedChanged, rbtnFOLLOW_PROCESS_OUTFLOW_KB_F.CheckedChanged
        Dim blnChecked As Boolean = rbtnFOLLOW_PROCESS_OUTFLOW_KB_T.Checked

        txtFOLLOW_PROCESS_OUTFLOW_MEMO.Enabled = blnChecked
        pnlFOLLOW_PROCESS_OUTFLOW_FILEPATH.Enabled = blnChecked

        If Not blnChecked And Not IsInitializing Then
            txtFOLLOW_PROCESS_OUTFLOW_MEMO.Text = ""
            _V011_FCR_J.FOLLOW_PROCESS_OUTFLOW_FILEPATH = ""
            lblFOLLOW_PROCESS_OUTFLOW_FILEPATH.Visible = False
            lblFOLLOW_PROCESS_OUTFLOW_FILEPATH_Clear.Visible = False
        End If

        '#256
        lblOTHER_PROCESS_NAIYOU.Enabled = Not (rbtnFOLLOW_PROCESS_OUTFLOW_KB_F.Checked And rbtnOTHER_PROCESS_INFLUENCE_KB_F.Checked)
        txtOTHER_PROCESS_NAIYOU.Enabled = Not (rbtnFOLLOW_PROCESS_OUTFLOW_KB_F.Checked And rbtnOTHER_PROCESS_INFLUENCE_KB_F.Checked)
        dtOTHER_PROCESS_YMD.Enabled = Not (rbtnFOLLOW_PROCESS_OUTFLOW_KB_F.Checked And rbtnOTHER_PROCESS_INFLUENCE_KB_F.Checked)
        If (rbtnFOLLOW_PROCESS_OUTFLOW_KB_F.Checked And rbtnOTHER_PROCESS_INFLUENCE_KB_F.Checked) Then
            txtOTHER_PROCESS_NAIYOU.Text = ""
            dtOTHER_PROCESS_YMD.Text = ""
        End If
    End Sub

    ''' <summary>
    ''' 2.不適合製品範囲 コメント
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    Private Sub TxtFUTEKIGO_SEIHIN_MEMO_Validated(sender As Object, e As EventArgs) Handles txtFUTEKIGO_SEIHIN_MEMO.Validated
        Dim txt = DirectCast(sender, TextBoxEx)
        Dim blnEnabled As Boolean = (txt.Text.Length = 0)

        'pnlFUTEKIGO_SEIHIN_FILEPATH.Enabled = blnEnabled
        pnlInfo1.Enabled = blnEnabled
        Call CmbKISYU1_Validated(cmbKISYU1, Nothing)
        pnlInfo2.Enabled = blnEnabled
        Call CmbKISYU2_Validated(cmbKISYU2, Nothing)
        pnlInfo3.Enabled = blnEnabled

    End Sub

    ''' <summary>
    ''' 3.顧客影響範囲 コメント
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    Private Sub TxtKOKYAKU_EIKYO_MEMO_Validated(sender As Object, e As EventArgs) Handles txtKOKYAKU_EIKYO_MEMO.Validated
        Dim txt = DirectCast(sender, TextBoxEx)
        Dim blnEnabled As Boolean = (txt.Text.Length = 0)

        'pnlKOKYAKU_EIKYO_FILEPATH.Enabled = blnEnabled
        pnlInfo4.Enabled = blnEnabled
        Call CmbKISYU4_Validated(cmbKISYU4, Nothing)
        pnlInfo5.Enabled = blnEnabled
        Call CmbKISYU5_Validated(cmbKISYU5, Nothing)
        pnlInfo6.Enabled = blnEnabled
    End Sub

#Region "添付ファイル"

#Region "顧客影響判定_詳細資料"

    Private Sub BtnOpenKOKYAKU_EIKYO_HANTEI_FILEPATH_Click(sender As Object, e As EventArgs) Handles btnOpenKOKYAKU_EIKYO_HANTEI_FILEPATH.Click
        Dim ofd As New OpenFileDialog With {
            .Filter = "Excel(*.xls;*.xlsx)|*.xls;*.xlsx|Word(*.doc;*.docx)|*.doc;*.docx|PDF(*.pdf)|*.pdf|すべてのファイル(*.*)|*.*",
            .FilterIndex = 4,
            .Title = "添付するファイルを選択してください",
            .RestoreDirectory = True
        }
        If lblKOKYAKU_EIKYO_HANTEI_FILEPATH.Links.Count = 0 Then
        Else
            ofd.InitialDirectory = IO.Path.GetDirectoryName(lblKOKYAKU_EIKYO_HANTEI_FILEPATH.Links(0).ToString)
        End If
        If ofd.ShowDialog() = DialogResult.OK Then
            lblKOKYAKU_EIKYO_HANTEI_FILEPATH.Text = CompactString(IO.Path.GetFileName(ofd.FileName), lblKOKYAKU_EIKYO_HANTEI_FILEPATH, EllipsisFormat._4_Path)
            lblKOKYAKU_EIKYO_HANTEI_FILEPATH.Links.Clear()
            lblKOKYAKU_EIKYO_HANTEI_FILEPATH.Links.Add(0, lblKOKYAKU_EIKYO_HANTEI_FILEPATH.Text.Length, ofd.FileName)

            _V011_FCR_J.KOKYAKU_EIKYO_HANTEI_FILEPATH = IO.Path.GetFileName(ofd.FileName)
            lblKOKYAKU_EIKYO_HANTEI_FILEPATH.Visible = True
            lblKOKYAKU_EIKYO_HANTEI_FILEPATH_Clear.Visible = True
        End If
    End Sub

    'リンククリック
    Private Sub LblKOKYAKU_EIKYO_HANTEI_FILEPATH_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles lblKOKYAKU_EIKYO_HANTEI_FILEPATH.LinkClicked
        Dim hProcess As New System.Diagnostics.Process
        Dim strEXE As String

        Try

            strEXE = lblKOKYAKU_EIKYO_HANTEI_FILEPATH.Links(0).LinkData
            If strEXE.IsNulOrWS Then
            Else
                If System.IO.File.Exists(strEXE) = True Then
                    hProcess.StartInfo.FileName = strEXE
                    hProcess.SynchronizingObject = Me
                    hProcess.EnableRaisingEvents = True
                    hProcess.Start()

                    '最前面
                    Call SetForegroundWindow(hProcess.Handle)
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
    Private Sub LblKOKYAKU_EIKYO_HANTEI_FILEPATH_Clear_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles lblKOKYAKU_EIKYO_HANTEI_FILEPATH_Clear.LinkClicked
        lblKOKYAKU_EIKYO_HANTEI_FILEPATH.Text = ""
        lblKOKYAKU_EIKYO_HANTEI_FILEPATH.Links.Clear()
        lblKOKYAKU_EIKYO_HANTEI_FILEPATH.Visible = False
        lblKOKYAKU_EIKYO_HANTEI_FILEPATH_Clear.Visible = False
        _V011_FCR_J.KOKYAKU_EIKYO_HANTEI_FILEPATH = ""
    End Sub

#End Region

#Region "他のプロセスへの影響_詳細資料"

    'ファイル選択
    Private Sub BtnOpenFOLLOW_PROCESS_OUTFLOW_FILEPATH_Click(sender As Object, e As EventArgs) Handles btnOpenFOLLOW_PROCESS_OUTFLOW_FILEPATH.Click
        Dim ofd As New OpenFileDialog With {
            .Filter = "Excel(*.xls;*.xlsx)|*.xls;*.xlsx|Word(*.doc;*.docx)|*.doc;*.docx|PDF(*.pdf)|*.pdf|すべてのファイル(*.*)|*.*",
            .FilterIndex = 4,
            .Title = "添付するファイルを選択してください",
            .RestoreDirectory = True
        }
        If lblFOLLOW_PROCESS_OUTFLOW_FILEPATH.Links.Count = 0 Then
        Else
            ofd.InitialDirectory = IO.Path.GetDirectoryName(lblFOLLOW_PROCESS_OUTFLOW_FILEPATH.Links(0).ToString)
        End If
        If ofd.ShowDialog() = DialogResult.OK Then
            lblFOLLOW_PROCESS_OUTFLOW_FILEPATH.Text = CompactString(IO.Path.GetFileName(ofd.FileName), lblFOLLOW_PROCESS_OUTFLOW_FILEPATH, EllipsisFormat._4_Path)
            lblFOLLOW_PROCESS_OUTFLOW_FILEPATH.Links.Clear()
            lblFOLLOW_PROCESS_OUTFLOW_FILEPATH.Links.Add(0, lblFOLLOW_PROCESS_OUTFLOW_FILEPATH.Text.Length, ofd.FileName)

            _V011_FCR_J.FOLLOW_PROCESS_OUTFLOW_FILEPATH = IO.Path.GetFileName(ofd.FileName)
            lblFOLLOW_PROCESS_OUTFLOW_FILEPATH.Visible = True
            lblFOLLOW_PROCESS_OUTFLOW_FILEPATH_Clear.Visible = True
        End If
    End Sub

    'リンククリック
    Private Sub LblFOLLOW_PROCESS_OUTFLOW_FILEPATH_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles lblFOLLOW_PROCESS_OUTFLOW_FILEPATH.LinkClicked
        Dim hProcess As New System.Diagnostics.Process
        Dim strEXE As String
        Try

            strEXE = lblFOLLOW_PROCESS_OUTFLOW_FILEPATH.Links(0).LinkData
            If strEXE.IsNulOrWS Then
            Else
                If System.IO.File.Exists(strEXE) = True Then
                    hProcess.StartInfo.FileName = strEXE

                    hProcess.SynchronizingObject = Me

                    hProcess.EnableRaisingEvents = True
                    hProcess.Start()

                    '最前面
                    Call SetForegroundWindow(hProcess.Handle)
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
    Private Sub LblFOLLOW_PROCESS_OUTFLOW_FILEPATH_Clear_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles lblFOLLOW_PROCESS_OUTFLOW_FILEPATH_Clear.LinkClicked
        lblFOLLOW_PROCESS_OUTFLOW_FILEPATH.Text = ""
        lblFOLLOW_PROCESS_OUTFLOW_FILEPATH.Links.Clear()
        lblFOLLOW_PROCESS_OUTFLOW_FILEPATH.Visible = False
        lblFOLLOW_PROCESS_OUTFLOW_FILEPATH_Clear.Visible = False
        _V011_FCR_J.FOLLOW_PROCESS_OUTFLOW_FILEPATH = ""
    End Sub

#End Region

#Region "後続プロセスへの流出_詳細資料"

    'ファイル選択
    Private Sub BtnOpenOTHER_PROCESS_INFLUENCE_FILEPATH_Click(sender As Object, e As EventArgs) Handles btnOpenOTHER_PROCESS_INFLUENCE_FILEPATH.Click
        Dim ofd As New OpenFileDialog With {
            .Filter = "Excel(*.xls;*.xlsx)|*.xls;*.xlsx|Word(*.doc;*.docx)|*.doc;*.docx|PDF(*.pdf)|*.pdf|すべてのファイル(*.*)|*.*",
            .FilterIndex = 4,
            .Title = "添付するファイルを選択してください",
            .RestoreDirectory = True
        }
        If lblOTHER_PROCESS_INFLUENCE_FILEPATH.Links.Count = 0 Then
        Else
            ofd.InitialDirectory = IO.Path.GetDirectoryName(lblOTHER_PROCESS_INFLUENCE_FILEPATH.Links(0).ToString)
        End If
        If ofd.ShowDialog() = DialogResult.OK Then
            lblOTHER_PROCESS_INFLUENCE_FILEPATH.Text = CompactString(IO.Path.GetFileName(ofd.FileName), lblOTHER_PROCESS_INFLUENCE_FILEPATH, EllipsisFormat._4_Path)
            lblOTHER_PROCESS_INFLUENCE_FILEPATH.Links.Clear()
            lblOTHER_PROCESS_INFLUENCE_FILEPATH.Links.Add(0, lblOTHER_PROCESS_INFLUENCE_FILEPATH.Text.Length, ofd.FileName)

            _V011_FCR_J.OTHER_PROCESS_INFLUENCE_FILEPATH = IO.Path.GetFileName(ofd.FileName)
            lblOTHER_PROCESS_INFLUENCE_FILEPATH.Visible = True
            lblOTHER_PROCESS_INFLUENCE_FILEPATH_Clear.Visible = True
        End If
    End Sub

    'リンククリック
    Private Sub LblOTHER_PROCESS_INFLUENCE_FILEPATH_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles lblOTHER_PROCESS_INFLUENCE_FILEPATH.LinkClicked
        Dim hProcess As New System.Diagnostics.Process
        Dim strEXE As String
        'Dim strARG As String
        Try

            strEXE = lblOTHER_PROCESS_INFLUENCE_FILEPATH.Links(0).LinkData
            If strEXE.IsNulOrWS Then
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
    Private Sub LblOTHER_PROCESS_INFLUENCE_FILEPATH_Clear_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles lblOTHER_PROCESS_INFLUENCE_FILEPATH_Clear.LinkClicked
        lblOTHER_PROCESS_INFLUENCE_FILEPATH.Text = ""
        lblOTHER_PROCESS_INFLUENCE_FILEPATH.Links.Clear()
        lblOTHER_PROCESS_INFLUENCE_FILEPATH.Visible = False
        lblOTHER_PROCESS_INFLUENCE_FILEPATH_Clear.Visible = False
        _V011_FCR_J.OTHER_PROCESS_INFLUENCE_FILEPATH = ""
    End Sub

#End Region

#Region "不適合製品_詳細資料"

    'ファイル選択
    Private Sub BtnOpenFUTEKIGO_SEIHIN_FILEPATH_Click(sender As Object, e As EventArgs) Handles btnOpenFUTEKIGO_SEIHIN_FILEPATH.Click
        Dim ofd As New OpenFileDialog With {
            .Filter = "Excel(*.xls;*.xlsx)|*.xls;*.xlsx|Word(*.doc;*.docx)|*.doc;*.docx|PDF(*.pdf)|*.pdf|すべてのファイル(*.*)|*.*",
            .FilterIndex = 4,
            .Title = "添付するファイルを選択してください",
            .RestoreDirectory = True
        }
        If lblFUTEKIGO_SEIHIN_FILEPATH.Links.Count = 0 Then
        Else
            ofd.InitialDirectory = IO.Path.GetDirectoryName(lblFUTEKIGO_SEIHIN_FILEPATH.Links(0).ToString)
        End If
        If ofd.ShowDialog() = DialogResult.OK Then
            lblFUTEKIGO_SEIHIN_FILEPATH.Text = CompactString(IO.Path.GetFileName(ofd.FileName), lblFUTEKIGO_SEIHIN_FILEPATH, EllipsisFormat._4_Path)
            lblFUTEKIGO_SEIHIN_FILEPATH.Links.Clear()
            lblFUTEKIGO_SEIHIN_FILEPATH.Links.Add(0, lblFUTEKIGO_SEIHIN_FILEPATH.Text.Length, ofd.FileName)

            _V011_FCR_J.FUTEKIGO_SEIHIN_FILEPATH = IO.Path.GetFileName(ofd.FileName)
            lblFUTEKIGO_SEIHIN_FILEPATH.Visible = True
            lblFUTEKIGO_SEIHIN_FILEPATH_Clear.Visible = True
        End If
    End Sub

    'リンククリック
    Private Sub LblFUTEKIGO_SEIHIN_FILEPATH_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles lblFUTEKIGO_SEIHIN_FILEPATH.LinkClicked
        Dim hProcess As New System.Diagnostics.Process
        Dim strEXE As String
        'Dim strARG As String
        Try

            strEXE = lblFUTEKIGO_SEIHIN_FILEPATH.Links(0).LinkData
            If strEXE.IsNulOrWS Then
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
    Private Sub LblFUTEKIGO_SEIHIN_FILEPATH_Clear_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles lblFUTEKIGO_SEIHIN_FILEPATH_Clear.LinkClicked
        lblFUTEKIGO_SEIHIN_FILEPATH.Text = ""
        lblFUTEKIGO_SEIHIN_FILEPATH.Links.Clear()
        lblFUTEKIGO_SEIHIN_FILEPATH.Visible = False
        lblFUTEKIGO_SEIHIN_FILEPATH_Clear.Visible = False
        _V011_FCR_J.FUTEKIGO_SEIHIN_FILEPATH = ""
    End Sub

#End Region

#Region "顧客影響_詳細資料"

    'ファイル選択
    Private Sub BtnOpenKOKYAKU_EIKYO_FILEPATH_Click(sender As Object, e As EventArgs) Handles btnOpenKOKYAKU_EIKYO_FILEPATH.Click
        Dim ofd As New OpenFileDialog With {
            .Filter = "Excel(*.xls;*.xlsx)|*.xls;*.xlsx|Word(*.doc;*.docx)|*.doc;*.docx|PDF(*.pdf)|*.pdf|すべてのファイル(*.*)|*.*",
            .FilterIndex = 4,
            .Title = "添付するファイルを選択してください",
            .RestoreDirectory = True
        }
        If lblKOKYAKU_EIKYO_FILEPATH.Links.Count = 0 Then
        Else
            ofd.InitialDirectory = IO.Path.GetDirectoryName(lblKOKYAKU_EIKYO_FILEPATH.Links(0).ToString)
        End If
        If ofd.ShowDialog() = DialogResult.OK Then
            lblKOKYAKU_EIKYO_FILEPATH.Text = CompactString(IO.Path.GetFileName(ofd.FileName), lblKOKYAKU_EIKYO_FILEPATH, EllipsisFormat._4_Path)
            lblKOKYAKU_EIKYO_FILEPATH.Links.Clear()
            lblKOKYAKU_EIKYO_FILEPATH.Links.Add(0, lblKOKYAKU_EIKYO_FILEPATH.Text.Length, ofd.FileName)

            _V011_FCR_J.KOKYAKU_EIKYO_FILEPATH = IO.Path.GetFileName(ofd.FileName)
            lblKOKYAKU_EIKYO_FILEPATH.Visible = True
            lblKOKYAKU_EIKYO_FILEPATH_Clear.Visible = True
        End If
    End Sub

    'リンククリック
    Private Sub LblKOKYAKU_EIKYO_FILEPATH_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles lblKOKYAKU_EIKYO_FILEPATH.LinkClicked
        Dim hProcess As New System.Diagnostics.Process
        Dim strEXE As String
        'Dim strARG As String
        Try

            strEXE = lblKOKYAKU_EIKYO_FILEPATH.Links(0).LinkData
            If strEXE.IsNulOrWS Then
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
    Private Sub LblKOKYAKU_EIKYO_FILEPATH_Clear_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles lblKOKYAKU_EIKYO_FILEPATH_Clear.LinkClicked
        lblKOKYAKU_EIKYO_FILEPATH.Text = ""
        lblKOKYAKU_EIKYO_FILEPATH.Links.Clear()
        lblKOKYAKU_EIKYO_FILEPATH.Visible = False
        lblKOKYAKU_EIKYO_FILEPATH_Clear.Visible = False
        _V011_FCR_J.KOKYAKU_EIKYO_FILEPATH = ""
    End Sub

#End Region

#Region "処置の実施_詳細資料"

    'ファイル選択
    Private Sub BtnOpenSYOCHI_FILEPATH_Click(sender As Object, e As EventArgs) Handles btnOpenSYOCHI_FILEPATH.Click
        Dim ofd As New OpenFileDialog With {
            .Filter = "Excel(*.xls;*.xlsx)|*.xls;*.xlsx|Word(*.doc;*.docx)|*.doc;*.docx|PDF(*.pdf)|*.pdf|すべてのファイル(*.*)|*.*",
            .FilterIndex = 4,
            .Title = "添付するファイルを選択してください",
            .RestoreDirectory = True
        }
        If lblSYOCHI_FILEPATH.Links.Count = 0 Then
        Else
            ofd.InitialDirectory = IO.Path.GetDirectoryName(lblSYOCHI_FILEPATH.Links(0).ToString)
        End If
        If ofd.ShowDialog() = DialogResult.OK Then
            lblSYOCHI_FILEPATH.Text = CompactString(IO.Path.GetFileName(ofd.FileName), lblSYOCHI_FILEPATH, EllipsisFormat._4_Path)
            lblSYOCHI_FILEPATH.Links.Clear()
            lblSYOCHI_FILEPATH.Links.Add(0, lblSYOCHI_FILEPATH.Text.Length, ofd.FileName)

            _V011_FCR_J.SYOCHI_FILEPATH = IO.Path.GetFileName(ofd.FileName)
            lblSYOCHI_FILEPATH.Visible = True
            lblSYOCHI_FILEPATH_Clear.Visible = True
        End If
    End Sub

    'リンククリック
    Private Sub LblSYOCHI_FILEPATH_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles lblSYOCHI_FILEPATH.LinkClicked
        Dim hProcess As New System.Diagnostics.Process
        Dim strEXE As String
        'Dim strARG As String
        Try

            strEXE = lblSYOCHI_FILEPATH.Links(0).LinkData
            If strEXE.IsNulOrWS Then
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
    Private Sub LblSYOCHI_FILEPATH_Clear_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles lblSYOCHI_FILEPATH_Clear.LinkClicked
        lblSYOCHI_FILEPATH.Text = ""
        lblSYOCHI_FILEPATH.Links.Clear()
        lblSYOCHI_FILEPATH.Visible = False
        lblSYOCHI_FILEPATH_Clear.Visible = False
        _V011_FCR_J.SYOCHI_FILEPATH = ""
    End Sub

#End Region

#End Region

#End Region

#Region "ローカル関数"

#Region "処理モード別画面初期化"

    Private Function FunInitializeControls() As Boolean

        Try
            IsInitializing = True
            If Not FunSetModel() Then Return False

            'ナビゲートリンク選択
            If PrCurrentStage = ENM_CAR_STAGE._999_Closed Then
                rsbtnST99.Checked = True
            Else
                Dim rbtn As RibbonShapeRadioButton = DirectCast(flpnlStageIndex.Controls("rsbtnST" & (PrCurrentStage / 10).ToString("00")), RibbonShapeRadioButton)
                rbtn.Checked = True
            End If

#Region "   ヘッダ"

            mtxHOKUKO_NO.Text = _V011_FCR_J.HOKOKU_NO
            mtxBUMON_KB.Text = _V011_FCR_J.BUMON_NAME
            mtxKISYU.Text = _V011_FCR_J.KISYU_NAME
            mtxFUTEKIGO_KB.Text = _V011_FCR_J.FUTEKIGO_NAME
            mtxFUTEKIGO_S_KB.Text = _V011_FCR_J.FUTEKIGO_S_NAME
            mtxADD_SYAIN_NAME_NCR.Text = _V011_FCR_J.ADD_SYAIN_NAME_NCR
            mtxADD_SYAIN_NAME.Text = _V011_FCR_J.ADD_SYAIN_NAME
            dtFUTEKIGO_HASSEI_YMD.Value = _V011_FCR_J.HASSEI_YMD

#End Region

            Call SetTANTO_TooltipInfo()

            Dim dt = tblKISYU.LazyLoad("機種").AsEnumerable.Where(Function(r) r.Field(Of String)(NameOf(_D003_NCR_J.BUMON_KB)) = PrDataRow.Item("BUMON_KB")).CopyToDataTable
            If _V011_FCR_J.BUMON_NAME = "LP" Then
                dt = dt.AsEnumerable.Where(Function(r) r.Item("DISP") = "LP").CopyToDataTable
            End If

            cmbKISYU1.SetDataSource(dt, ENM_COMBO_SELECT_VALUE_TYPE._2_Option)
            cmbKISYU2.SetDataSource(dt, ENM_COMBO_SELECT_VALUE_TYPE._2_Option)
            cmbKISYU3.SetDataSource(dt, ENM_COMBO_SELECT_VALUE_TYPE._2_Option)
            cmbKISYU4.SetDataSource(dt, ENM_COMBO_SELECT_VALUE_TYPE._2_Option)
            cmbKISYU5.SetDataSource(dt, ENM_COMBO_SELECT_VALUE_TYPE._2_Option)
            cmbKISYU6.SetDataSource(dt, ENM_COMBO_SELECT_VALUE_TYPE._2_Option)

            txtTAISYO_KOKYAKU.Text = _V011_FCR_J.TAISYOU_KOKYAKU
            txtKOKYAKU_EIKYO_NAIYO.Text = _V011_FCR_J.KOKYAKU_EIKYO_NAIYO
            txtKAKUNIN_SYUDAN.Text = _V011_FCR_J.KAKUNIN_SYUDAN
            dtTUCHI_YMD.Value = _V011_FCR_J.TUCHI_YMD
            txtTUCHI_SYUDAN.Text = _V011_FCR_J.TUCHI_SYUDAN
            txtHITUYO_TETUDUKI_ZIKO.Text = _V011_FCR_J.HITUYO_TETUDUKI_ZIKO
            txtKAKUNIN_SYUDAN.Text = _V011_FCR_J.KAKUNIN_SYUDAN
            txtKOKYAKU_EIKYO_ETC_COMMENT.Text = _V011_FCR_J.KOKYAKU_EIKYO_ETC_COMMENT

            txtSYOCHI_MEMO.Text = _V011_FCR_J.SYOCHI_MEMO

            Dim targetCtrl As Control
            If _V011_FCR_J.KOKYAKU_EIKYO_HANTEI_KB Then
                targetCtrl = rbtnKOKYAKU_EIKYO_HANTEI_KB_T
            Else
                targetCtrl = rbtnKOKYAKU_EIKYO_HANTEI_KB_F
            End If
            DirectCast(targetCtrl, RadioButton).Checked = True
            Call RbtnKOKYAKU_EIKYO_HANTEI_KB_CheckedChanged(targetCtrl, Nothing)

            cmbKOKYAKU_EIKYO_HANTEI_COMMENT.Text = _V011_FCR_J.KOKYAKU_EIKYO_HANTEI_COMMENT

            If _V011_FCR_J.KOKYAKU_EIKYO_TUCHI_HANTEI_KB Then
                rbtnKOKYAKU_EIKYO_TUCHI_HANTEI_KB_T.Checked = True
            Else
                rbtnKOKYAKU_EIKYO_TUCHI_HANTEI_KB_F.Checked = True
            End If

            txtKOKYAKU_NOUNYU_NAIYOU.Text = _V011_FCR_J.KOKYAKU_NOUNYU_NAIYOU
            txtZAIKO_SIKAKE_NAIYOU.Text = _V011_FCR_J.ZAIKO_SIKAKE_NAIYOU

            dtKOKYAKU_NOUNYU_YMD.Value = _V011_FCR_J.KOKYAKU_NOUNYU_YMD
            dtZAIKO_SIKAKE_YMD.Value = _V011_FCR_J.ZAIKO_SIKAKE_YMD

            cmbKISYU1.SelectedValue = _V011_FCR_J.KISYU_ID1
            Call CmbKISYU1_Validated(cmbKISYU1, Nothing)
            cmbKISYU2.SelectedValue = _V011_FCR_J.KISYU_ID2
            Call CmbKISYU2_Validated(cmbKISYU2, Nothing)
            cmbKISYU3.SelectedValue = _V011_FCR_J.KISYU_ID3

            cmbKISYU4.SelectedValue = _V011_FCR_J.KISYU_ID4
            Call CmbKISYU4_Validated(cmbKISYU4, Nothing)
            cmbKISYU5.SelectedValue = _V011_FCR_J.KISYU_ID5
            Call CmbKISYU5_Validated(cmbKISYU5, Nothing)
            cmbKISYU6.SelectedValue = _V011_FCR_J.KISYU_ID6

            txtBUHIN_INFO1.Text = _V011_FCR_J.BUHIN_INFO1
            txtBUHIN_INFO2.Text = _V011_FCR_J.BUHIN_INFO2
            txtBUHIN_INFO3.Text = _V011_FCR_J.BUHIN_INFO3
            txtBUHIN_INFO4.Text = _V011_FCR_J.BUHIN_INFO4
            txtBUHIN_INFO5.Text = _V011_FCR_J.BUHIN_INFO5
            txtBUHIN_INFO6.Text = _V011_FCR_J.BUHIN_INFO6
            nupSURYO1.Value = _V011_FCR_J.SURYO1
            nupSURYO2.Value = _V011_FCR_J.SURYO2
            nupSURYO3.Value = _V011_FCR_J.SURYO3
            nupSURYO4.Value = _V011_FCR_J.SURYO4
            nupSURYO5.Value = _V011_FCR_J.SURYO5
            nupSURYO6.Value = _V011_FCR_J.SURYO6
            txtFROM1.Text = _V011_FCR_J.RANGE_FROM1
            txtFROM2.Text = _V011_FCR_J.RANGE_FROM2
            txtFROM3.Text = _V011_FCR_J.RANGE_FROM3
            txtFROM4.Text = _V011_FCR_J.RANGE_FROM4
            txtFROM5.Text = _V011_FCR_J.RANGE_FROM5
            txtFROM6.Text = _V011_FCR_J.RANGE_FROM6
            txtTO1.Text = _V011_FCR_J.RANGE_TO1
            txtTO2.Text = _V011_FCR_J.RANGE_TO2
            txtTO3.Text = _V011_FCR_J.RANGE_TO3
            txtTO4.Text = _V011_FCR_J.RANGE_TO4
            txtTO5.Text = _V011_FCR_J.RANGE_TO5
            txtTO6.Text = _V011_FCR_J.RANGE_TO6

            txtFUTEKIGO_SEIHIN_MEMO.Text = _V011_FCR_J.FUTEKIGO_SEIHIN_MEMO
            Call TxtFUTEKIGO_SEIHIN_MEMO_Validated(txtFUTEKIGO_SEIHIN_MEMO, Nothing)
            txtKOKYAKU_EIKYO_MEMO.Text = _V011_FCR_J.KOKYAKU_EIKYO_MEMO
            Call TxtKOKYAKU_EIKYO_MEMO_Validated(txtKOKYAKU_EIKYO_MEMO, Nothing)

            If _V011_FCR_J.FOLLOW_PROCESS_OUTFLOW_KB Then
                targetCtrl = rbtnFOLLOW_PROCESS_OUTFLOW_KB_T
            Else
                targetCtrl = rbtnFOLLOW_PROCESS_OUTFLOW_KB_F
            End If
            DirectCast(targetCtrl, RadioButton).Checked = True
            Call RbtnFOLLOW_PROCESS_OUTFLOW_KB_CheckedChanged(targetCtrl, Nothing)

            If _V011_FCR_J.OTHER_PROCESS_INFLUENCE_KB Then
                targetCtrl = rbtnOTHER_PROCESS_INFLUENCE_KB_T
            Else
                targetCtrl = rbtnOTHER_PROCESS_INFLUENCE_KB_F
            End If
            DirectCast(targetCtrl, RadioButton).Checked = True
            Call RbtnOTHER_PROCESS_INFLUENCE_KB_CheckedChanged(targetCtrl, Nothing)
            txtOTHER_PROCESS_INFLUENCE_MEMO.Text = _V011_FCR_J.OTHER_PROCESS_INFLUENCE_MEMO
            txtFOLLOW_PROCESS_OUTFLOW_MEMO.Text = _V011_FCR_J.FOLLOW_PROCESS_OUTFLOW_MEMO

            txtOTHER_PROCESS_NAIYOU.Text = _V011_FCR_J.OTHER_PROCESS_NAIYOU
            dtOTHER_PROCESS_YMD.Value = _V011_FCR_J.OTHER_PROCESS_YMD

            mtxCurrentStageName.Text = FunGetLastStageName(Context.ENM_SYONIN_HOKOKUSYO_ID._3_CTS, _V011_FCR_J.HOKOKU_NO)
            mtxNextStageName.Text = FunGetStageName(Context.ENM_SYONIN_HOKOKUSYO_ID._3_CTS, FunGetNextSYONIN_JUN(PrCurrentStage, _V011_FCR_J.KOKYAKU_EIKYO_HANTEI_KB))
            Dim blnOwn As Boolean = FunblnOwnCreated(Context.ENM_SYONIN_HOKOKUSYO_ID._3_CTS, _V011_FCR_J.HOKOKU_NO, PrCurrentStage)

            _tabPageManager = New TabPageManager(TabSTAGE)

            Select Case PrCurrentStage
                Case ENM_CTS_STAGE._999_Closed
                    pnlFCR.DisableContaints(IsEditingClosed, PanelEx.ENM_PROPERTY._2_ReadOnly)
                    pnlSYOCHI_KIROKU.DisableContaints(IsEditingClosed, PanelEx.ENM_PROPERTY._2_ReadOnly)
                    pnlZESEI_SYOCHI.DisableContaints(IsEditingClosed, PanelEx.ENM_PROPERTY._2_ReadOnly)
                    PnlPROCESS.DisableContaints(IsEditingClosed, PanelEx.ENM_PROPERTY._2_ReadOnly)
                    pnlSYOCHI_JISSI.DisableContaints(IsEditingClosed, PanelEx.ENM_PROPERTY._2_ReadOnly)

                Case Else
            End Select

            '画面上部のカレントステージ遷移ボタン
            For Each val As Integer In [Enum].GetValues(GetType(ENM_CTS_STAGE2))
                flpnlStageIndex.Controls("rsbtnST" & val.ToString("00")).Enabled = (PrCurrentStage / 10) >= val
                If (PrCurrentStage / 10) >= val Then
                Else
                    flpnlStageIndex.Controls("rsbtnST" & val.ToString("00")).BackColor = Color.Silver
                End If
            Next val
            'rsbtnST05.Enabled = CBool(_V005_CAR_J.KAITO_23)
            If _V011_FCR_J.CLOSE_FG = False Then
                flpnlStageIndex.Controls("rsbtnST99").Enabled = False
                flpnlStageIndex.Controls("rsbtnST99").BackColor = Color.Silver
            End If

            Dim _V003 As New V003_SYONIN_J_KANRI
            _V003 = _V003_SYONIN_J_KANRI_List.AsEnumerable.
                                Where(Function(r) r.SYONIN_JUN = PrCurrentStage).
                                FirstOrDefault
            If _V003 IsNot Nothing Then
                If Not _V003.RIYU.IsNulOrWS Then lbl_Modoshi_Riyu.Visible = True
                If _V003.SASIMODOSI_FG Then
                    lbl_Modoshi_Riyu.Text = "差戻理由：" & _V003.RIYU
                Else
                    '転送時
                    lbl_Modoshi_Riyu.Text = "転送理由：" & _V003.RIYU
                End If

                Dim dtSYONIN_YMD As Date
                If DateTime.TryParseExact(_V003.SYONIN_YMDHNS, "yyyyMMddHHmmss", Nothing, Nothing, dtSYONIN_YMD) Then
                    '_D004_SYONIN_J_KANRI.SYONIN_YMDHNS = _V003.SYONIN_YMDHNS
                    dtUPD_YMD.ValueNonFormat = dtSYONIN_YMD.ToString("yyyyMMdd")
                Else
                    '_D004_SYONIN_J_KANRI.SYONIN_YMDHNS = Now.ToString("yyyyMMddHHmmss")
                    dtUPD_YMD.Text = Now.ToString("yyyy/MM/dd")
                End If
            End If

#Region "   添付ファイル"

            Dim strRootDir As String
            Using DB = DBOpen()
                strRootDir = FunConvPathString(FunGetCodeMastaValue(DB, "添付ファイル保存先", My.Application.Info.AssemblyName))
            End Using
            If Not _V011_FCR_J.KOKYAKU_EIKYO_HANTEI_FILEPATH.IsNulOrWS Then
                lblKOKYAKU_EIKYO_HANTEI_FILEPATH.Text = CompactString(_V011_FCR_J.KOKYAKU_EIKYO_HANTEI_FILEPATH, lblKOKYAKU_EIKYO_HANTEI_FILEPATH, EllipsisFormat._4_Path)
                lblKOKYAKU_EIKYO_HANTEI_FILEPATH.Links.Clear()
                lblKOKYAKU_EIKYO_HANTEI_FILEPATH.Links.Add(0, lblKOKYAKU_EIKYO_HANTEI_FILEPATH.Text.Length, $"{strRootDir}{_V011_FCR_J.HOKOKU_NO.Trim}\CTS\{_V011_FCR_J.KOKYAKU_EIKYO_HANTEI_FILEPATH}")
                lblKOKYAKU_EIKYO_HANTEI_FILEPATH.Visible = True
                lblKOKYAKU_EIKYO_HANTEI_FILEPATH_Clear.Visible = True
            End If
            If Not _V011_FCR_J.OTHER_PROCESS_INFLUENCE_FILEPATH.IsNulOrWS Then
                lblOTHER_PROCESS_INFLUENCE_FILEPATH.Text = CompactString(_V011_FCR_J.OTHER_PROCESS_INFLUENCE_FILEPATH, lblOTHER_PROCESS_INFLUENCE_FILEPATH, EllipsisFormat._4_Path)
                lblOTHER_PROCESS_INFLUENCE_FILEPATH.Links.Clear()
                lblOTHER_PROCESS_INFLUENCE_FILEPATH.Links.Add(0, lblOTHER_PROCESS_INFLUENCE_FILEPATH.Text.Length, $"{strRootDir}{_V011_FCR_J.HOKOKU_NO.Trim}\CTS\{_V011_FCR_J.OTHER_PROCESS_INFLUENCE_FILEPATH}")
                lblOTHER_PROCESS_INFLUENCE_FILEPATH.Visible = True
                lblOTHER_PROCESS_INFLUENCE_FILEPATH_Clear.Visible = True
            End If
            If Not _V011_FCR_J.FOLLOW_PROCESS_OUTFLOW_FILEPATH.IsNulOrWS Then
                lblFOLLOW_PROCESS_OUTFLOW_FILEPATH.Text = CompactString(_V011_FCR_J.FOLLOW_PROCESS_OUTFLOW_FILEPATH, lblFOLLOW_PROCESS_OUTFLOW_FILEPATH, EllipsisFormat._4_Path)
                lblFOLLOW_PROCESS_OUTFLOW_FILEPATH.Links.Clear()
                lblFOLLOW_PROCESS_OUTFLOW_FILEPATH.Links.Add(0, lblFOLLOW_PROCESS_OUTFLOW_FILEPATH.Text.Length, $"{strRootDir}{_V011_FCR_J.HOKOKU_NO.Trim}\CTS\{_V011_FCR_J.FOLLOW_PROCESS_OUTFLOW_FILEPATH}")
                lblFOLLOW_PROCESS_OUTFLOW_FILEPATH.Visible = True
                lblFOLLOW_PROCESS_OUTFLOW_FILEPATH_Clear.Visible = True
            End If

            If Not _V011_FCR_J.FUTEKIGO_SEIHIN_FILEPATH.IsNulOrWS Then
                lblFUTEKIGO_SEIHIN_FILEPATH.Text = CompactString(_V011_FCR_J.FUTEKIGO_SEIHIN_FILEPATH, lblFUTEKIGO_SEIHIN_FILEPATH, EllipsisFormat._4_Path)
                lblFUTEKIGO_SEIHIN_FILEPATH.Links.Clear()
                lblFUTEKIGO_SEIHIN_FILEPATH.Links.Add(0, lblFUTEKIGO_SEIHIN_FILEPATH.Text.Length, $"{strRootDir}{_V011_FCR_J.HOKOKU_NO.Trim}\CTS\{_V011_FCR_J.FUTEKIGO_SEIHIN_FILEPATH}")
                lblFUTEKIGO_SEIHIN_FILEPATH.Visible = True
                lblFUTEKIGO_SEIHIN_FILEPATH_Clear.Visible = True
            End If
            If Not _V011_FCR_J.KOKYAKU_EIKYO_FILEPATH.IsNulOrWS Then
                lblKOKYAKU_EIKYO_FILEPATH.Text = CompactString(_V011_FCR_J.KOKYAKU_EIKYO_FILEPATH, lblKOKYAKU_EIKYO_FILEPATH, EllipsisFormat._4_Path)
                lblKOKYAKU_EIKYO_FILEPATH.Links.Clear()
                lblKOKYAKU_EIKYO_FILEPATH.Links.Add(0, lblKOKYAKU_EIKYO_FILEPATH.Text.Length, $"{strRootDir}{_V011_FCR_J.HOKOKU_NO.Trim}\CTS\{_V011_FCR_J.KOKYAKU_EIKYO_FILEPATH}")
                lblKOKYAKU_EIKYO_FILEPATH.Visible = True
                lblKOKYAKU_EIKYO_FILEPATH_Clear.Visible = True
            End If
            If Not _V011_FCR_J.SYOCHI_FILEPATH.IsNulOrWS Then
                lblSYOCHI_FILEPATH.Text = CompactString(_V011_FCR_J.SYOCHI_FILEPATH, lblSYOCHI_FILEPATH, EllipsisFormat._4_Path)
                lblSYOCHI_FILEPATH.Links.Clear()
                lblSYOCHI_FILEPATH.Links.Add(0, lblSYOCHI_FILEPATH.Text.Length, $"{strRootDir}{_V011_FCR_J.HOKOKU_NO.Trim}\CTS\{_V011_FCR_J.SYOCHI_FILEPATH}")
                lblSYOCHI_FILEPATH.Visible = True
                lblSYOCHI_FILEPATH_Clear.Visible = True
            End If

#End Region

            If FunGetNextSYONIN_JUN(PrCurrentStage, _V011_FCR_J.KOKYAKU_EIKYO_HANTEI_KB) = ENM_CTS_STAGE._999_Closed Then
                '最終ステージの場合、申請先担当者欄は非表示

                lblDestTANTO.Visible = False
                cmbDestTANTO.Visible = False
                cmdFunc2.Text = "承認(F2)"
            Else
                cmdFunc2.Text = "承認・申請(F2)"
            End If

            ErrorProvider.ClearError(cmbDestTANTO)

            Return True
        Catch ex As Exception
            EM.ErrorSyori(ex, False, conblnNonMsg)
            Return False
        Finally
            IsInitializing = False
        End Try
    End Function

    Private Function FunSetModel() As Boolean
        Try
            _V002_NCR_J.Clear()
            _V002_NCR_J = FunGetV002Model(PrHOKOKU_NO)
            _V003_SYONIN_J_KANRI_List = FunGetV003Model(Context.ENM_SYONIN_HOKOKUSYO_ID._3_CTS, PrHOKOKU_NO)

            _V011_FCR_J.Clear()
            _V011_FCR_J = FunGetV011Model(PrHOKOKU_NO)

            'データソース設定
            Dim dt As DataTable = FunGetSYOZOKU_SYAIN(_V011_FCR_J.BUMON_KB)

            dt = FunGetSYONIN_SYOZOKU_SYAIN(_V011_FCR_J.BUMON_KB, Context.ENM_SYONIN_HOKOKUSYO_ID._3_CTS, FunGetNextSYONIN_JUN(PrCurrentStage, _V011_FCR_J.KOKYAKU_EIKYO_HANTEI_KB))
            cmbDestTANTO.SetDataSource(dt, ENM_COMBO_SELECT_VALUE_TYPE._0_Required)

            '#128
            If PrCurrentStage = ENM_CAR_STAGE._10_起草入力 AndAlso Not IsRemanded(_V011_FCR_J.HOKOKU_NO) Then
                _V011_FCR_J.ADD_SYAIN_ID = pub_SYAIN_INFO.SYAIN_ID
            End If

            IsEditingClosed = _V011_FCR_J.CLOSE_FG = 1 AndAlso HasEditingRight(pub_SYAIN_INFO.SYAIN_ID)

            Return True
        Catch ex As Exception
            EM.ErrorSyori(ex, False, conblnNonMsg)
            Return False
        End Try
    End Function

    Private Function SetTANTO_TooltipInfo() As Boolean

        Call SetInfoLabelFormat(lblDestTANTO, $"承認担当者マスタ{vbCr}所属部門の当該ステージに登録された担当者")

    End Function

    Private Function SetInfoLabelFormat(lbl As Label, caption As String) As Boolean
        lbl.ForeColor = Color.Blue
        'lbl.Cursor = Cursors.Hand
        lbl.Font = New Font("Meiryo UI", 9, FontStyle.Bold + FontStyle.Underline, lbl.Font.Unit, CType(128, Byte))
        InfoToolTip.SetToolTip(lbl, caption)
    End Function

#End Region

#Region "入力チェック"

    Private Function FunCheckInput(ByVal enmSAVE_MODE As ENM_SAVE_MODE) As Boolean
        Try
            'フラグリセット
            IsValidated = True
            '-----共通
            If enmSAVE_MODE = ENM_SAVE_MODE._2_承認申請 And FunGetNextSYONIN_JUN(PrCurrentStage, _V011_FCR_J.KOKYAKU_EIKYO_HANTEI_KB) < ENM_CTS_STAGE._999_Closed Then
                Call CmbDestTANTO_Validating(cmbDestTANTO, Nothing)
                If cmbKOKYAKU_EIKYO_HANTEI_COMMENT.Visible Then
                    Dim IsEntered As Boolean = (Not cmbKOKYAKU_EIKYO_HANTEI_COMMENT.Text.IsNulOrWS) Or cmbKOKYAKU_EIKYO_HANTEI_COMMENT.SelectedIndex > 0
                    IsValidated *= ErrorProvider.UpdateErrorInfo(cmbKOKYAKU_EIKYO_HANTEI_COMMENT, IsEntered, String.Format(My.Resources.infoMsgRequireSelectOrInput, "否の理由"))
                End If
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
    ''' 該当報告書Noの現在のステージ名を取得
    ''' </summary>
    ''' <param name="intSYONIN_HOKOKUSYO_ID"></param>
    ''' <param name="strHOKOKU_NO"></param>
    ''' <returns></returns>
    Private Function FunGetLastStageName(ByVal intSYONIN_HOKOKUSYO_ID As Integer, ByVal strHOKOKU_NO As String) As String
        Dim sbSQL As New System.Text.StringBuilder
        Dim dsList As New DataSet

        sbSQL.Remove(0, sbSQL.Length)
        sbSQL.Append($"SELECT")
        sbSQL.Append($" *")
        sbSQL.Append($" FROM {NameOf(V003_SYONIN_J_KANRI)} ")
        sbSQL.Append($" WHERE {NameOf(V003_SYONIN_J_KANRI.SYONIN_HOKOKUSYO_ID)}={intSYONIN_HOKOKUSYO_ID}")
        sbSQL.Append($" AND {NameOf(V003_SYONIN_J_KANRI.HOKOKU_NO)}='{strHOKOKU_NO.Trim}'")
        sbSQL.Append($" ORDER BY {NameOf(V003_SYONIN_J_KANRI.SYONIN_JUN)} DESC")
        Using DB As ClsDbUtility = DBOpen()
            dsList = DB.GetDataSet(sbSQL.ToString, conblnNonMsg)
        End Using

        With dsList.Tables(0)
            If .Rows.Count = 0 Then
                Return ""
            Else
                Return .Rows(0).Item(NameOf(V003_SYONIN_J_KANRI.SYONIN_NAIYO)) '.Rows(0).Item("SYONIN_JUN") & "." & .Rows(0).Item("SYONIN_NAIYO")
            End If
        End With
    End Function

    ''' <summary>
    ''' 次ステージの承認順Noを取得
    ''' </summary>
    ''' <param name="CurrentStageID">現ステージID</param>
    ''' <returns></returns>
    Private Function FunGetNextSYONIN_JUN(CurrentStageID As Integer, KOKYAKU_HANTEI_KB As Boolean) As Integer
        Try
            Const stageLength As Integer = 10

            If KOKYAKU_HANTEI_KB = False Then
                'なし時 #256
                If CurrentStageID >= ENM_CTS_STAGE._70_品証課長 Then
                    Return ENM_CTS_STAGE._999_Closed
                Else
                    Return CurrentStageID + stageLength
                End If
            Else
                Select Case CurrentStageID
                    Case ENM_CTS_STAGE._90_部門長, ENM_CTS_STAGE._999_Closed
                        Return ENM_CTS_STAGE._999_Closed
                    Case Else
                        Return CurrentStageID + stageLength
                End Select
            End If
        Catch ex As Exception
            EM.ErrorSyori(ex, False, conblnNonMsg)
            Return 0
        End Try
    End Function

    Private Function IsRemanded(strHOKOKU_NO As String) As Boolean
        Dim sbSQL As New System.Text.StringBuilder
        Dim intRET As Integer

        If strHOKOKU_NO.IsNulOrWS Then
            Return False
        Else
            sbSQL.Remove(0, sbSQL.Length)
            sbSQL.Append($"SELECT")
            sbSQL.Append($" COUNT({NameOf(R005_FCR_SASIMODOSI.HOKOKU_NO)})")
            sbSQL.Append($" FROM {NameOf(R005_FCR_SASIMODOSI)} ")
            sbSQL.Append($" WHERE {NameOf(R005_FCR_SASIMODOSI.HOKOKU_NO)}='{strHOKOKU_NO}'")
            Using DB As ClsDbUtility = DBOpen()
                intRET = DB.ExecuteScalar(sbSQL.ToString, conblnNonMsg)
            End Using

            Return intRET > 0
        End If
    End Function

#End Region

End Class