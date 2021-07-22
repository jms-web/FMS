Imports System.Threading.Tasks
Imports JMS_COMMON.ClsPubMethod
Imports MODEL
Imports D013 = MODEL.D013_ZESEI_HASSEI_J
Imports D014 = MODEL.D014_ZESEI_RYUSYUTU_J

''' <summary>
''' 是正処置(流出)画面
''' </summary>
Public Class FrmG0031_EditOverflow

#Region "定数・変数"

    Private _D013 As New D013
    Private _D014 As New D014
    Private _V003_SYONIN_J_KANRI_List As New List(Of V003_SYONIN_J_KANRI)

    Private IsEditingClosed As Boolean
    Private IsInitializing As Boolean

    Private USER_GYOMU_KENGEN_LIST As New List(Of ENM_GYOMU_GROUP_ID)

    Private Flx2_DS_DB As DataTable
    Private Flx3_DS_DB As DataTable
    Private Flx4_DS_DB As DataTable

    Private dtBUFF As DateTime

    Private SYOCHI_KAKUNIN_Users As New List(Of (userId As Integer, YOHI_KAITO As String))

#End Region

#Region "プロパティ"

    Public Property PrMODE As Integer

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
        MyBase.ToolTip.SetToolTip(Me.cmdFunc1, "操作権限がありません")
        MyBase.ToolTip.SetToolTip(Me.cmdFunc2, "操作権限がありません")
        MyBase.ToolTip.SetToolTip(Me.cmdFunc4, My.Resources.infoToolTipMsgNotFoundData)
        MyBase.ToolTip.SetToolTip(Me.cmdFunc5, My.Resources.infoToolTipMsgNotFoundData)
        MyBase.ToolTip.SetToolTip(Me.cmdFunc10, My.Resources.infoToolTipMsgNotFoundData)
        MyBase.ToolTip.SetToolTip(Me.cmdFunc11, My.Resources.infoToolTipMsgNotFoundData)

        cmbKA.NullValue = 0
        cmbTANTO.NullValue = 0

        cmbST01_SAKUSEI_TANTO.NullValue = 0
        cmbST01_TENKEN_TANTO.NullValue = 0
        cmbST01_NINKA_TANTO.NullValue = 0

        cmbST02_SAKUSEI_TANTO.NullValue = 0
        cmbST02_TENKEN_TANTO.NullValue = 0
        cmbST02_NINKA_TANTO.NullValue = 0
        cmbST02_HINSYO_TENKEN_TANTO.NullValue = 0
        cmbST02_HINSYO_NINKA_TANTO.NullValue = 0

        cmbST03_SAKUSEI_TANTO.NullValue = 0
        cmbST03_TENKEN_TANTO.NullValue = 0
        cmbST03_NINKA_TANTO.NullValue = 0

        cmbST04_SAKUSEI_TANTO.NullValue = 0
        cmbST04_TENKEN_TANTO.NullValue = 0
        cmbST04_NINKA_TANTO.NullValue = 0

        cmbST05_SAKUSEI_TANTO.NullValue = 0
        cmbST05_TENKEN_TANTO.NullValue = 0
        cmbST05_NINKA_TANTO.NullValue = 0

    End Sub

#End Region

#Region "Form関連"

    'Loadイベント
    Private Async Sub FrmLoad(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        Try
            PrRIYU = ""
            IsInitializing = True

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
                        _D014.Clear()
                        _D004_SYONIN_J_KANRI.clear()

                        cmbBUMON.SetDataSource(tblBUMON.ExcludeDeleted, ENM_COMBO_SELECT_VALUE_TYPE._0_Required)
                        Dim blnIsAdmin As Boolean = IsSysAdminUser(pub_SYAIN_INFO.SYAIN_ID)
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
                        cmbKA.SetDataSource(tblKA.ExcludeDeleted, ENM_COMBO_SELECT_VALUE_TYPE._2_Option)
                        'Call FunSetBinding()
                        IsEditingClosed = HasEditingRight(pub_SYAIN_INFO.SYAIN_ID)

                        '-----画面初期化
                        Call FunInitializeControls(PrMODE)

                    End Sub)
                End Sub)
        Finally
            FunInitFuncButtonEnabled()
            Me.Cursor = Cursors.Default
            Me.WindowState = FormWindowState.Maximized
            IsInitializing = False
        End Try
    End Sub

    'Shown
    Private Sub Frm_Shown(sender As Object, e As EventArgs) Handles MyBase.Shown
        Me.Owner.Visible = False
    End Sub

    Private Sub Frm_Closed(sender As Object, e As EventArgs) Handles MyBase.Closed
        Me.Owner.Visible = True
    End Sub

    Overrides Sub FrmBaseStsBtn_Resize(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Resize
        If Me.Visible = False Then Exit Sub

        If Me.DesignMode = True Then Exit Sub

        ''===================================
        ''   ボタン位置、サイズ設定
        ''===================================
        'Call SetButtonSize(Me.Width, cmdFunc)
        'MyBase.FrmBaseStsBtn_Resize(Me, e)
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
                        If IsEditingClosed And PrCurrentStage = ENM_ZESEI_STAGE._999_Closed Then

                            Call OpenFormEdit()
                            If PrRIYU.IsNulOrWS Then
                                Exit Sub
                            End If
                        Else
                            If MessageBox.Show("入力内容を保存しますか？", "登録確認", MessageBoxButtons.YesNo, MessageBoxIcon.Information) <> DialogResult.Yes Then Exit Sub
                        End If

                        If FunSAVE(ENM_SAVE_MODE._1_保存) Then
                            Me.DialogResult = DialogResult.OK
                            Dim strMsg As String = "入力内容を保存しました。"

                            MessageBox.Show(strMsg, "保存完了", MessageBoxButtons.OK, MessageBoxIcon.Information)
                        Else
                            MessageBox.Show("保存処理に失敗しました。", "保存失敗", MessageBoxButtons.OK, MessageBoxIcon.Error)
                        End If
                    End If

                Case 2  '承認申請

                    '入力チェック
                    If FunCheckInput(ENM_SAVE_MODE._2_承認申請) Then
                        Dim strMsg As String
                        If FunGetNextSYONIN_JUN(PrCurrentStage) = ENM_ZESEI_STAGE._999_Closed Then
                            strMsg = "承認・CLOSEしますか？"
                        Else
                            strMsg = "承認・申請しますか？"
                        End If

                        If MessageBox.Show(strMsg, "承認・申請処理確認", MessageBoxButtons.YesNo, MessageBoxIcon.Information) = DialogResult.Yes Then
                            If FunSAVE(ENM_SAVE_MODE._2_承認申請) Then
                                If PrCurrentStage = ENM_ZESEI_STAGE._52_要求元完了確認_認可 Then
                                    strMsg = "承認・CLOSEしました"
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

                Case 5  '差し戻し

                    Call OpenFormSASIMODOSI()

                Case 10  '印刷

                    Call FunOpenReport()

                Case 11 '履歴
                    Call OpenFormHistory(Context.ENM_SYONIN_HOKOKUSYO_ID._4_FCCB, PrHOKOKU_NO)

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

                    If FunSAVE_D014(DB, enmSAVE_MODE) = False Then blnErr = True : Return False
                    If FunSAVE_FILE(DB) = False Then blnErr = True : Return False

                    If Not blnTENSO And PrCurrentStage < ENM_ZESEI_STAGE._999_Closed Then
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

#Region "   ファイル保存"

    ''' <summary>
    ''' NCR添付ファイル保存
    ''' </summary>
    ''' <param name="DB"></param>
    ''' <returns></returns>
    Private Function FunSAVE_FILE(ByRef DB As ClsDbUtility) As Boolean

        If _D014.FILE_PATH1.IsNulOrWS And
            _D014.FILE_PATH2.IsNulOrWS And
            _D014.FILE_PATH3.IsNulOrWS And
            _D014.FILE_PATH4.IsNulOrWS And
            _D014.FILE_PATH5.IsNulOrWS Then
            Return True
        Else
            'SPEC: 2.(3).D.②.添付ファイル保存
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
                    System.IO.Directory.CreateDirectory(strRootDir & _D014.HOKOKU_NO)

#Region "1"

                    If Not _D014.FILE_PATH1.IsNulOrWS AndAlso
                        Not System.IO.File.Exists(strRootDir & _D014.HOKOKU_NO.Trim & "\" & _D014.FILE_PATH1) Then

                        If System.IO.File.Exists(lbltmpFile1.Links.Item(0).LinkData) Then
                            System.IO.File.Copy(lbltmpFile1.Links.Item(0).LinkData, strRootDir & _D014.HOKOKU_NO.Trim & "\" & _D014.FILE_PATH1, True)
                        Else
                            Throw New IO.FileNotFoundException($"添付資料1:{lbltmpFile1.Links.Item(0).LinkData}が見つかりません。元の場所に戻すか選択し直してください")
                        End If
                    End If

#End Region

#Region "2"

                    If Not _D014.FILE_PATH2.IsNulOrWS AndAlso
                        Not System.IO.File.Exists(strRootDir & _D014.HOKOKU_NO.Trim & "\" & _D014.FILE_PATH2) Then

                        If System.IO.File.Exists(lbltmpFile2.Links.Item(0).LinkData) Then
                            System.IO.File.Copy(lbltmpFile2.Links.Item(0).LinkData, strRootDir & _D014.HOKOKU_NO.Trim & "\" & _D014.FILE_PATH2, True)
                        Else
                            Throw New IO.FileNotFoundException($"添付資料2:{lbltmpFile2.Links.Item(0).LinkData}が見つかりません。元の場所に戻すか選択し直してください")
                        End If
                    End If

#End Region

#Region "3"

                    If Not _D014.FILE_PATH3.IsNulOrWS AndAlso
                        Not System.IO.File.Exists(strRootDir & _D014.HOKOKU_NO.Trim & "\" & _D014.FILE_PATH3) Then

                        If System.IO.File.Exists(lbltmpFile3.Links.Item(0).LinkData) Then
                            System.IO.File.Copy(lbltmpFile3.Links.Item(0).LinkData, strRootDir & _D014.HOKOKU_NO.Trim & "\" & _D014.FILE_PATH3, True)
                        Else
                            Throw New IO.FileNotFoundException($"添付資料3:{lbltmpFile3.Links.Item(0).LinkData}が見つかりません。元の場所に戻すか選択し直してください")
                        End If
                    End If

#End Region

#Region "4"

                    If Not _D014.FILE_PATH4.IsNulOrWS AndAlso
                        Not System.IO.File.Exists(strRootDir & _D014.HOKOKU_NO.Trim & "\" & _D014.FILE_PATH4) Then

                        If System.IO.File.Exists(lbltmpFile4.Links.Item(0).LinkData) Then
                            System.IO.File.Copy(lbltmpFile4.Links.Item(0).LinkData, strRootDir & _D014.HOKOKU_NO.Trim & "\" & _D014.FILE_PATH4, True)
                        Else
                            Throw New IO.FileNotFoundException($"添付資料4:{lbltmpFile4.Links.Item(0).LinkData}が見つかりません。元の場所に戻すか選択し直してください")
                        End If
                    End If

#End Region

#Region "5"

                    If Not _D014.FILE_PATH5.IsNulOrWS AndAlso
                        Not System.IO.File.Exists(strRootDir & _D014.HOKOKU_NO.Trim & "\" & _D014.FILE_PATH5) Then

                        If System.IO.File.Exists(lbltmpFile5.Links.Item(0).LinkData) Then
                            System.IO.File.Copy(lbltmpFile5.Links.Item(0).LinkData, strRootDir & _D014.HOKOKU_NO.Trim & "\" & _D014.FILE_PATH5, True)
                        Else
                            Throw New IO.FileNotFoundException($"添付資料5:{lbltmpFile5.Links.Item(0).LinkData}が見つかりません。元の場所に戻すか選択し直してください")
                        End If
                    End If

#End Region

                    Return True
                Catch exNF As IO.FileNotFoundException
                    MessageBox.Show(exNF.Message, "ファイル存在チェック", MessageBoxButtons.OK, MessageBoxIcon.Error)
                    Return False
                Catch exIO As UnauthorizedAccessException
                    strMsg = $"添付ファイル保存先のアクセス権限がありません。{vbCrLf}添付ファイル保存先:{strRootDir}"
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

#Region "   D014"

    ''' <summary>
    ''' FCCB更新
    ''' </summary>
    ''' <param name="DB"></param>
    ''' <returns></returns>
    Private Function FunSAVE_D014(ByRef DB As ClsDbUtility, ByVal enmSAVE_MODE As ENM_SAVE_MODE) As Boolean
        Dim sbSQL As New System.Text.StringBuilder
        Dim strRET As String
        Dim sqlEx As New Exception
        Dim strSysDate As String = DB.GetSysDateString

#Region "モデル更新"

        If _D014.HOKOKU_NO.IsNulOrWS Or _D014.HOKOKU_NO = "<新規>" Then
            Dim objParam As System.Data.Common.DbParameter = DB.DbCommand.CreateParameter
            Dim lstParam As New List(Of System.Data.Common.DbParameter)
            With objParam
                .ParameterName = "HOKOKU_NO"
                .DbType = DbType.String
                .Direction = ParameterDirection.Output
                .Size = 8
            End With
            lstParam.Add(objParam)
            If DB.Fun_blnExecStored("dbo.ST06_GET_ZESEI_NO", lstParam) = True Then
                _D014.HOKOKU_NO = DB.DbCommand.Parameters("HOKOKU_NO").Value
            Else
                Return False
            End If
        End If

        If (FunGetNextSYONIN_JUN(PrCurrentStage) = ENM_ZESEI_STAGE._999_Closed) And enmSAVE_MODE = ENM_SAVE_MODE._2_承認申請 Then
            _D014._CLOSE_FG = 1
        End If
        _D014.ADD_YMDHNS = strSysDate
        _D014.ADD_SYAIN_ID = pub_SYAIN_INFO.SYAIN_ID
        _D014.UPD_YMDHNS = strSysDate
        _D014.UPD_SYAIN_ID = pub_SYAIN_INFO.SYAIN_ID
        _D014.DEL_YMDHNS = ""
        _D014.DEL_SYAIN_ID = 0

#Region "日付フォーマット加工"

        'CHECK: 本来不要のはず？
        Dim dt As DateTime
        If DateTime.TryParse(_D014.KAITOU_KIBOU_YMD, dt) Then
            _D014.KAITOU_KIBOU_YMD = CDate(_D014.KAITOU_KIBOU_YMD).ToString("yyyyMMdd")
        End If
        If DateTime.TryParse(_D014.KAITOU_YMD, dt) Then
            _D014.KAITOU_YMD = CDate(_D014.KAITOU_YMD).ToString("yyyyMMdd")
        End If

        If DateTime.TryParse(_D014.OUKYU_SYOCHI_YMD, dt) Then
            _D014.OUKYU_SYOCHI_YMD = CDate(_D014.OUKYU_SYOCHI_YMD).ToString("yyyyMMdd")
        End If
        If DateTime.TryParse(_D014.OUKYU_SYOCHI_YOTEI_YMD, dt) Then
            _D014.OUKYU_SYOCHI_YOTEI_YMD = CDate(_D014.OUKYU_SYOCHI_YOTEI_YMD).ToString("yyyyMMdd")
        End If
        If DateTime.TryParse(_D014.ZESEI_SYOCHI_YMD, dt) Then
            _D014.ZESEI_SYOCHI_YMD = CDate(_D014.ZESEI_SYOCHI_YMD).ToString("yyyyMMdd")
        End If
        If DateTime.TryParse(_D014.ZESEI_SYOCHI_YOTEI_YMD, dt) Then
            _D014.ZESEI_SYOCHI_YOTEI_YMD = CDate(_D014.ZESEI_SYOCHI_YOTEI_YMD).ToString("yyyyMMdd")
        End If

#End Region

#End Region

        '-----MERGE
        sbSQL.Remove(0, sbSQL.Length)
        sbSQL.Append($"MERGE INTO {NameOf(D014_ZESEI_RYUSYUTU_J)} AS TARGET")
        sbSQL.Append($" USING (")
        sbSQL.Append($"{_D014.ToSelectSqlString}")
        sbSQL.Append($" ) AS WK")
        sbSQL.Append($" ON (TARGET.{NameOf(_D014.HOKOKU_NO)} = WK.{NameOf(_D014.HOKOKU_NO)})")
        '---UPDATE
        sbSQL.Append($" WHEN MATCHED THEN")
        sbSQL.Append($" {_D014.ToUpdateSqlString("TARGET", "WK")}")
        '---INSERT
        sbSQL.Append($" WHEN NOT MATCHED THEN")
        sbSQL.Append($" {_D014.ToInsertSqlString("WK")}")
        sbSQL.Append(" OUTPUT $action As RESULT;")
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
        WL.WriteLogDat($"[DEBUG]是正処置 報告書NO:{_D014.HOKOKU_NO}、MERGE D014_ZESEI_RYUSYUTU_J")

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
            _D004_SYONIN_J_KANRI.SYONIN_HOKOKUSYO_ID = Context.ENM_SYONIN_HOKOKUSYO_ID._6_ZESEI_R
            _D004_SYONIN_J_KANRI.HOKOKU_NO = _D014.HOKOKU_NO
            _D004_SYONIN_J_KANRI.MAIL_SEND_FG = True
            _D004_SYONIN_J_KANRI.ADD_SYAIN_ID = pub_SYAIN_INFO.SYAIN_ID
            _D004_SYONIN_J_KANRI.ADD_YMDHNS = strSysDate

            If PrCurrentStage = ENM_ZESEI_STAGE._10_起草入力 Then
                _D004_SYONIN_J_KANRI.UPD_SYAIN_ID = pub_SYAIN_INFO.SYAIN_ID
            End If

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
                    _D004_SYONIN_J_KANRI.SYONIN_JUN = FunGetNextSYONIN_JUN(PrCurrentStage)
                    _D004_SYONIN_J_KANRI.SYONIN_YMDHNS = ""
                    _D004_SYONIN_J_KANRI.MAIL_SEND_FG = False
                    _D004_SYONIN_J_KANRI.SYONIN_HANTEI_KB = ENM_SYONIN_HANTEI_KB._0_未承認
                    _D004_SYONIN_J_KANRI.ADD_YMDHNS = strSysDate
                    _D004_SYONIN_J_KANRI.SYAIN_ID = FunGetNextSYONIN_TANTO_ID(PrCurrentStage)

                Case Else
                    'Err
                    Return False
            End Select

            '-----Close処理
            If _D004_SYONIN_J_KANRI.SYONIN_JUN = ENM_ZESEI_STAGE._999_Closed Then
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
                    If PrCurrentStage < ENM_ZESEI_STAGE._52_要求元完了確認_認可 AndAlso FunSendRequestMail() Then
                        WL.WriteLogDat($"[DEBUG]是正処置 報告書NO:{_D014.HOKOKU_NO}、Send Request Mail")
                    End If

                Case "UPDATE"

                Case Else
                    '-----エラーログ出力
                    Dim strErrMsg As String = My.Resources.ErrLogSqlExecutionFailure & sbSQL.ToString & "|" & sqlEx.Message
                    WL.WriteLogDat(strErrMsg)
                    Return False
            End Select

            WL.WriteLogDat($"[DEBUG]是正処置 報告書NO:{_D014.HOKOKU_NO}、MERGE D004")

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
    Private Function FunSendRequestMail(Optional toUserNAME As String = "", Optional fromUserNAME As String = "") As Boolean

        Try

            Dim SYONIN_HANTEI_NAME As String = tblSYONIN_HANTEI_KB.LazyLoad("承認判定区分").
                                                                   AsEnumerable.
                                                                   Where(Function(r) r.Field(Of String)("VALUE") = _D004_SYONIN_J_KANRI.SYONIN_HANTEI_KB).
                                                                   FirstOrDefault?.Item("DISP")

            Dim strEXEParam As String = $"{_D004_SYONIN_J_KANRI.SYAIN_ID},{ENM_OPEN_MODE._2_処置画面起動.Value},{Context.ENM_SYONIN_HOKOKUSYO_ID._5_ZESEI.Value},{_D004_SYONIN_J_KANRI.HOKOKU_NO}"
            Dim strSubject As String = $"【是正処置依頼】:{_D004_SYONIN_J_KANRI.HOKOKU_NO}"
            Dim ToUsers As New List(Of Integer)

            ToUsers.Add(_D004_SYONIN_J_KANRI.SYAIN_ID)

            Dim strBody As String = <sql><![CDATA[
                {0}<br />
                <br />
        　        是正処置要求書の処置内容の確認と承認をお願いします。<br />
                <br />        　　
        　　        【報告書No】{1}<br />
        　　        【起 草 日】{2}<br />        　　
        　　        【依 頼 者】{5}<br />        　　
                <br />
                <a href = "http://sv04:8000/CLICKONCE_FMS.application" > システム起動</a><br />
                <br />
                ※このメールは配信専用です。(返信できません)<br />
                返信する場合は、各担当者のメールアドレスを使用して下さい。<br />
                ]]></sql>.Value.Trim

            'http://sv116:8000/CLICKONCE_FMS.application?SYAIN_ID={8}&EXEPATH={9}&PARAMS={10}

            Dim username As String

            If (ToUsers.Count > 1) Then
                username = "各位"
            Else
                username = If(toUserNAME.IsNulOrWS, $"{Fun_GetUSER_NAME(_D004_SYONIN_J_KANRI.SYAIN_ID)} 殿", toUserNAME)
            End If

            strBody = String.Format(strBody,
                                username,
                                _D004_SYONIN_J_KANRI.HOKOKU_NO,
                                DateTime.ParseExact(_D014.ADD_YMDHNS, "yyyyMMddHHmmss", Nothing).ToString("yyyy/MM/dd"),
                                "",
                                "",
                                If(fromUserNAME = "", Fun_GetUSER_NAME(pub_SYAIN_INFO.SYAIN_ID), fromUserNAME),
                                SYONIN_HANTEI_NAME,
                                _D004_SYONIN_J_KANRI.COMMENT,
                                _D004_SYONIN_J_KANRI.SYAIN_ID,
                                "FMS_G0030.exe",
                                strEXEParam)

            If ToUsers.Count = 0 Then
                MessageBox.Show("送信者が見つからないため、依頼メールを送信できません", "依頼メール送信", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Return False
            Else
                If FunSendMailFCCB(strSubject, strBody, ToUsers, blnSendSenior:=False) Then
                    Return True
                Else
                    MessageBox.Show("メール送信に失敗しました。", "メール送信失敗", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    Return False
                End If
            End If
        Catch ex As Exception
            Throw
        End Try
    End Function

    Private Function GetTLGLUsers(BUMON_KB As String) As IEnumerable(Of Integer)
        Dim retList As New List(Of Integer)
        Try
            Dim sbSQL As New System.Text.StringBuilder
            Dim dsList As New DataSet
            If (BUMON_KB = ENM_BUMON_KB._1_風防.Value) Then
                sbSQL.Append($"SELECT M04.SYAIN_ID,M04.SIMEI FROM M004_SYAIN M04")
                sbSQL.Append($" INNER JOIN M011_SYAIN_GYOMU M11")
                sbSQL.Append($" ON M04.SYAIN_ID = M11.SYAIN_ID And M11.GYOMU_GROUP_ID <> '{ENM_GYOMU_GROUP_ID._2_製造.Value}'")
                sbSQL.Append($" WHERE M04.SYAIN_ID IN ((SELECT SYOZOKUCYO_ID FROM M002_BUSYO WHERE BUMON_KB='{ENM_BUMON_KB._1_風防.Value}') )")
                sbSQL.Append($" AND M04.YAKUSYOKU_KB IN ('{ENM_YAKUSYOKU_KB._2_GL.Value}','{ENM_YAKUSYOKU_KB._5_TL.Value}')")
                sbSQL.Append($" UNION")
                sbSQL.Append($" SELECT M04.SYAIN_ID,M04.SIMEI FROM M004_SYAIN M04")
                sbSQL.Append($" INNER JOIN M011_SYAIN_GYOMU M11")
                sbSQL.Append($" ON M04.SYAIN_ID = M11.SYAIN_ID AND M11.GYOMU_GROUP_ID = '{ENM_GYOMU_GROUP_ID._2_製造.Value}'")
                sbSQL.Append($" WHERE M04.SYAIN_ID IN (SELECT SYOZOKUCYO_ID FROM M002_BUSYO WHERE BUMON_KB='{ENM_BUMON_KB._1_風防.Value}')")
                sbSQL.Append($" AND YAKUSYOKU_KB ='{ENM_YAKUSYOKU_KB._1_課長.Value}'")
            Else
                sbSQL.Append($"SELECT SYAIN_ID,SIMEI FROM M004_SYAIN")
                sbSQL.Append($" WHERE SYAIN_ID IN ((SELECT SYOZOKUCYO_ID FROM M002_BUSYO WHERE BUMON_KB='{BUMON_KB}') )")
                sbSQL.Append($" AND YAKUSYOKU_KB IN ('{ENM_YAKUSYOKU_KB._2_GL.Value}','{ENM_YAKUSYOKU_KB._5_TL.Value}')")
                sbSQL.Append($" Except")
                sbSQL.Append($" SELECT M04.SYAIN_ID,M04.SIMEI FROM M004_SYAIN M04")
                sbSQL.Append($" LEFT JOIN M011_SYAIN_GYOMU M11")
                sbSQL.Append($" ON M04.SYAIN_ID = M11.SYAIN_ID AND M11.GYOMU_GROUP_ID = '{ENM_GYOMU_GROUP_ID._2_製造.Value}'")
                sbSQL.Append($" WHERE M04.SYAIN_ID IN (SELECT SYOZOKUCYO_ID FROM M002_BUSYO WHERE BUMON_KB='{BUMON_KB}')")
                sbSQL.Append($" AND YAKUSYOKU_KB ='{ENM_YAKUSYOKU_KB._2_GL.Value}'")
            End If

            Using DB = DBOpen()
                dsList = DB.GetDataSet(sbSQL.ToString, conblnNonMsg)
            End Using
            For Each r As DataRow In dsList.Tables(0).Rows
                retList.Add(r.Item(0).ToString.ToVal)
            Next

            Return retList
        Catch ex As Exception
            Throw
        End Try
    End Function

#End Region

#Region "R001"

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
        _R001_HOKOKU_SOUSA.SYONIN_HOKOKUSYO_ID = Context.ENM_SYONIN_HOKOKUSYO_ID._6_ZESEI_R
        _R001_HOKOKU_SOUSA.HOKOKU_NO = _D014.HOKOKU_NO
        _R001_HOKOKU_SOUSA.SYONIN_JUN = PrCurrentStage
        _R001_HOKOKU_SOUSA.SYAIN_ID = pub_SYAIN_INFO.SYAIN_ID
        _R001_HOKOKU_SOUSA.RIYU = PrRIYU
        _R001_HOKOKU_SOUSA.ADD_YMDHNS = strSysDate 'Now.ToString("yyyyMMddHHmmss")

        Select Case enmSAVE_MODE
            Case ENM_SAVE_MODE._1_保存

                If PrCurrentStage = ENM_ZESEI_STAGE._999_Closed Then
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

        'WL.WriteLogDat($"[DEBUG]CTS 報告書NO:{_D013.HOKOKU_NO}、INSERT R001")

        Return True
    End Function

#End Region

#End Region

#Region "転送"

    Private Function OpenFormTENSO() As Boolean
        Dim frmDLG As New FrmG0035_Tenso
        Dim dlgRET As DialogResult

        Try
            frmDLG.PrSYONIN_HOKOKUSYO_ID = Context.ENM_SYONIN_HOKOKUSYO_ID._5_ZESEI
            frmDLG.PrHOKOKU_NO = PrHOKOKU_NO
            frmDLG.PrBUMON_KB = _D014.BUMON_KB
            frmDLG.PrKISO_YMD = DateTime.ParseExact(_D009.ADD_YMD, "yyyyMMdd", Nothing).ToString("yyyy/MM/dd")
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
        Dim frmDLG As New FrmG0036_Sasimodosi
        Dim dlgRET As DialogResult

        Try
            frmDLG.PrSYONIN_HOKOKUSYO_ID = Context.ENM_SYONIN_HOKOKUSYO_ID._6_ZESEI_R
            frmDLG.PrHOKOKU_NO = PrHOKOKU_NO
            frmDLG.PrBUHIN_BANGO = ""
            frmDLG.PrKISO_YMD = CDate(_D014.ADD_YMDHNS).ToString("yyyy/MM/dd")
            frmDLG.PrKISYU_NAME = ""
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

    Private Function FunOpenReport() As Boolean
        Dim strOutputFileName As String
        Dim strTEMPFILE As String
        'Dim intRET As Integer

        Try
            Me.Cursor = Cursors.WaitCursor

            'ファイル名
            strOutputFileName = "ZESEI_" & _D014.HOKOKU_NO & "_Work.xls"

            '既存ファイル削除
            If FunDELETE_FILE(pub_APP_INFO.strOUTPUT_PATH & strOutputFileName) = False Then
                Return False
            End If

            Using iniIF As New IniFile(FunGetRootPath() & "\INI\" & CON_TEMPLATE_INI)
                strTEMPFILE = FunConvRootPath(iniIF.GetIniString("ZESEI_RYUSYUTU", "FILEPATH"))
            End Using

            'エクセル出力ファイル用意
            If OUT_EXCEL_READY(strTEMPFILE, pub_APP_INFO.strOUTPUT_PATH, strOutputFileName) = False Then
                Return False
            End If
            '-----書込処理
            If FunMakeReportZESEI_RYUSYUTU(pub_APP_INFO.strOUTPUT_PATH & strOutputFileName, _D014.HOKOKU_NO) = False Then
                Return False
            End If

            'Excel起動
            Return FunOpenExcelApp(pub_APP_INFO.strOUTPUT_PATH & strOutputFileName)
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
        Dim frmDLG As New FrmG0032_Rireki
        Dim dlgRET As DialogResult

        Try
            frmDLG.PrSYONIN_HOKOKUSYO_ID = SYONIN_HOKOKU_ID
            frmDLG.PrHOKOKU_NO = HOKOKU_NO
            frmDLG.PrDatarow = PrDataRow
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
        Dim frmDLG As New FrmG0034_EditComment
        Dim dlgRET As DialogResult

        Try
            frmDLG.PrSYONIN_HOKOKUSYO_ID = Context.ENM_SYONIN_HOKOKUSYO_ID._5_ZESEI
            frmDLG.PrHOKOKU_NO = _D014.HOKOKU_NO
            frmDLG.PrBUMON_KB = _D014.BUMON_KB
            frmDLG.PrKISO_YMD = DateTime.ParseExact(_D014.ADD_YMD, "yyyyMMdd", Nothing).ToString("yyyy/MM/dd")
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

#Region "メール送信"

    Private Function OpenFormSendMail() As Boolean
        Dim frmDLG As New FrmG0037_MailForm
        Dim dlgRET As DialogResult

        Try
            frmDLG.PrSYONIN_HOKOKUSYO_ID = Context.ENM_SYONIN_HOKOKUSYO_ID._4_FCCB
            frmDLG.PrHOKOKU_NO = PrHOKOKU_NO
            frmDLG.PrSYORI_NAME = "協議確認依頼メール送信"

            Dim userlist As New List(Of Integer)

            'userlist.Add(cmbCM_TANTO.SelectedValue)
            'If cmbSYOCHI_GM_TANTO.IsSelected AndAlso Not userlist.Contains(cmbSYOCHI_GM_TANTO.SelectedValue) Then
            '    userlist.Add(cmbSYOCHI_GM_TANTO.SelectedValue)
            'End If
            'If cmbSYOCHI_SEIZO_TANTO.IsSelected AndAlso Not userlist.Contains(cmbSYOCHI_SEIZO_TANTO.SelectedValue) Then
            '    userlist.Add(cmbSYOCHI_SEIZO_TANTO.SelectedValue)
            'End If
            'If cmbSYOCHI_KENSA_TANTO.IsSelected AndAlso Not userlist.Contains(cmbSYOCHI_KENSA_TANTO.SelectedValue) Then
            '    userlist.Add(cmbSYOCHI_KENSA_TANTO.SelectedValue)
            'End If
            'If cmbSYOCHI_HINSYO_TANTO.IsSelected AndAlso Not userlist.Contains(cmbSYOCHI_HINSYO_TANTO.SelectedValue) Then
            '    userlist.Add(cmbSYOCHI_HINSYO_TANTO.SelectedValue)
            'End If
            'If cmbSYOCHI_SEKKEI_TANTO.IsSelected AndAlso Not userlist.Contains(cmbSYOCHI_SEKKEI_TANTO.SelectedValue) Then
            '    userlist.Add(cmbSYOCHI_SEKKEI_TANTO.SelectedValue)
            'End If
            'If cmbSYOCHI_SEIGI_TANTO.IsSelected AndAlso Not userlist.Contains(cmbSYOCHI_SEIGI_TANTO.SelectedValue) Then
            '    userlist.Add(cmbSYOCHI_SEIGI_TANTO.SelectedValue)
            'End If
            'If cmbSYOCHI_KANRI_TANTO.IsSelected AndAlso Not userlist.Contains(cmbSYOCHI_KANRI_TANTO.SelectedValue) Then
            '    userlist.Add(cmbSYOCHI_KANRI_TANTO.SelectedValue)
            'End If
            'If cmbSYOCHI_EIGYO_TANTO.IsSelected AndAlso Not userlist.Contains(cmbSYOCHI_EIGYO_TANTO.SelectedValue) Then
            '    userlist.Add(cmbSYOCHI_EIGYO_TANTO.SelectedValue)
            'End If

            If userlist.Count > 1 Then
                frmDLG.PrToUsers = userlist
                dlgRET = frmDLG.ShowDialog(Me)

                If dlgRET = Windows.Forms.DialogResult.OK Then
                    Me.DialogResult = DialogResult.OK
                    Me.Close()
                    Return True
                Else
                    Return False
                End If
            Else
                MessageBox.Show($"確認依頼担当者が選択されていません{vbCrLf}先に、⑤変更審議 各部門の担当者を選択して下さい", "協議確認依頼メール送信", MessageBoxButtons.OK, MessageBoxIcon.Information)
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

            'カレントステージが自身の担当でない場合は無効
            Dim IsOwnCreated As Boolean = FunblnOwnCreated(Context.ENM_SYONIN_HOKOKUSYO_ID._5_ZESEI.Value, _D014.HOKOKU_NO, PrCurrentStage)

            If PrMODE = ENM_DATA_OPERATION_MODE._1_ADD Then

                cmdFunc1.Enabled = IsOwnCreated
                cmdFunc2.Enabled = IsOwnCreated

                cmdFunc4.Enabled = False
                cmdFunc4.Visible = False
                cmdFunc5.Enabled = False
                cmdFunc10.Enabled = False
                cmdFunc11.Enabled = False
            Else

                cmdFunc1.Enabled = IsOwnCreated
                cmdFunc2.Enabled = IsOwnCreated

                cmdFunc5.Enabled = IsOwnCreated

                cmdFunc10.Enabled = True
                cmdFunc11.Enabled = True

                Dim blnIsAdmin As Boolean = IsSysAdminUser(pub_SYAIN_INFO.SYAIN_ID)
                cmdFunc5.Enabled = blnIsAdmin

                cmdFunc4.Visible = False

                Select Case PrCurrentStage
                    Case ENM_ZESEI_STAGE._10_起草入力

                    Case ENM_ZESEI_STAGE._20_是正処置入力

                    Case ENM_ZESEI_STAGE._30_処置結果入力
                    Case ENM_ZESEI_STAGE._40_処置結果レビュー

                    Case ENM_ZESEI_STAGE._50_要求元完了確認

                    Case ENM_ZESEI_STAGE._999_Closed
                        If IsEditingClosed Then
                            cmdFunc1.Enabled = True
                            cmdFunc1.Text = "保存(F1)"
                        Else
                            cmdFunc1.Enabled = False
                            cmdFunc1.Text = "保存(F1)"
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

            End If

            Return True
        Catch ex As Exception
            EM.ErrorSyori(ex, False, conblnNonMsg)
        End Try
    End Function

#End Region

#End Region

#Region "コントロールイベント"

#Region "申請先社員"

    Private Sub CmbDestTANTO_SelectedvalueChanged(sender As Object, e As EventArgs)
        Dim cmb As ComboboxEx = DirectCast(sender, ComboboxEx)
        Dim caption As String = [Enum].GetName(GetType(ENM_SAVE_MODE), PrCurrentStage)
        IsValidated *= ErrorProvider.UpdateErrorInfo(cmb, cmb.IsSelected, String.Format(My.Resources.infoMsgRequireSelectOrInput, caption))
        Call FunInitFuncButtonEnabled()
    End Sub

#End Region

#Region "ヘッダ"

    Private Sub cmbBUMON_SelectedValueChanged(sender As Object, e As EventArgs) Handles cmbBUMON.SelectedValueChanged
        Dim dtKA As DataTable
        Dim dtTANTO As DataTable
        If cmbBUMON.SelectedValue.ToString.IsNulOrWS Then
            dtKA = tblKA
            dtTANTO = tblTANTO
        Else
            Dim dr As List(Of DataRow)
            dr = tblKA.AsEnumerable.Where(Function(r) r.Item("BUMON_KB") = cmbBUMON.SelectedValue).ToList
            If dr.Count > 0 Then
                dtKA = dr.CopyToDataTable
            Else
                dtKA = Nothing
            End If

            dr = tblTANTO.AsEnumerable.Where(Function(r) r.Item("BUMON_KB") = cmbBUMON.SelectedValue).ToList
            If dr.Count > 0 Then
                dtTANTO = dr.CopyToDataTable
            Else
                dtTANTO = tblTANTO
            End If
        End If
        If dtKA IsNot Nothing Then
            cmbKA.SetDataSource(dtKA.ExcludeDeleted, ENM_COMBO_SELECT_VALUE_TYPE._2_Option)
        Else
            cmbKA.DataSource = Nothing
            cmbKA.DisplayMember = "DISP"
            cmbKA.ValueMember = "VALUE"
        End If
        If dtTANTO IsNot Nothing Then
            cmbTANTO.SetDataSource(dtTANTO.ExcludeDeleted, ENM_COMBO_SELECT_VALUE_TYPE._0_Required)
        Else
            cmbTANTO.DataSource = Nothing
            cmbTANTO.DisplayMember = "DISP"
            cmbTANTO.ValueMember = "VALUE"
        End If

        _D014.BUMON_KB = cmbBUMON.SelectedValue
        Call FunInitializeSTAGE(PrCurrentStage)

    End Sub

    Private Sub cmbKA_SelectedValueChanged(sender As Object, e As EventArgs) Handles cmbKA.SelectedValueChanged
        Dim dt As DataTable
        If cmbKA.SelectedValue.ToString.IsNulOrWS Then
            Dim dr As List(Of DataRow)
            dr = tblTANTO.AsEnumerable.Where(Function(r) r.Item("BUMON_KB") = cmbBUMON.SelectedValue).ToList
            If dr.Count > 0 Then
                dt = dr.CopyToDataTable
            Else
                dt = tblTANTO
            End If
        Else
            Dim drs = tblTANTO.AsEnumerable.Where(Function(r) r.Item("BUSYO_ID") = cmbKA.SelectedValue Or r.Item("OYA_BUSYO_ID") = cmbKA.SelectedValue).ToList
            If drs.Count > 0 Then
                dt = drs.CopyToDataTable
            End If
            If dt IsNot Nothing Then
                cmbTANTO.SetDataSource(dt.ExcludeDeleted, ENM_COMBO_SELECT_VALUE_TYPE._0_Required)
            Else
                cmbTANTO.DataSource = Nothing
                cmbTANTO.DisplayMember = "DISP"
                cmbTANTO.ValueMember = "VALUE"
            End If
        End If
    End Sub

    Private Sub cmbBUMON_Validated(sender As Object, e As EventArgs) Handles cmbBUMON.Validated
        Dim cmb As ComboboxEx = DirectCast(sender, ComboboxEx)
        IsValidated *= ErrorProvider.UpdateErrorInfo(cmb, cmb.IsSelected, String.Format(My.Resources.infoMsgRequireSelectOrInput, "製品区分"))
    End Sub

    'Private Sub cmbKA_Validated(sender As Object, e As EventArgs) Handles cmbKA.Validated
    '    Dim cmb As ComboboxEx = DirectCast(sender, ComboboxEx)
    '    IsValidated *= ErrorProvider.UpdateErrorInfo(cmb, cmb.IsSelected, String.Format(My.Resources.infoMsgRequireSelectOrInput, "課"))
    'End Sub

    Private Sub cmbTANTO_Validated(sender As Object, e As EventArgs) Handles cmbTANTO.Validated
        Dim cmb As ComboboxEx = DirectCast(sender, ComboboxEx)
        IsValidated *= ErrorProvider.UpdateErrorInfo(cmb, cmb.IsSelected, String.Format(My.Resources.infoMsgRequireSelectOrInput, "責任者"))
    End Sub

    Private Sub cmbKISO_TANTO_Validated(sender As Object, e As EventArgs)
        Dim cmb As ComboboxEx = DirectCast(sender, ComboboxEx)
        IsValidated *= ErrorProvider.UpdateErrorInfo(cmb, cmb.IsSelected, String.Format(My.Resources.infoMsgRequireSelectOrInput, "起草者"))
    End Sub

#End Region

#Region "ST1"

    Private Sub dtKAITOU_KIBOU_YMD_Validating(sender As Object, e As System.ComponentModel.CancelEventArgs) Handles dtKAITOU_KIBOU_YMD.Validating
        Dim dtx As DateTextBoxEx = DirectCast(sender, DateTextBoxEx)
        If IsCheckRequired Then
            IsValidated *= ErrorProvider.UpdateErrorInfo(dtx, Not dtx.ValueNonFormat.IsNulOrWS, String.Format(My.Resources.infoMsgRequireSelectOrInput, "発生日"))
        End If
    End Sub

#End Region

#Region "チェック項目"

    Private Sub rbtnINPUT_TYPE_CheckedChanged(sender As Object, e As EventArgs) Handles rbtnINPUT_TYPE1.CheckedChanged,
                                                                                          rbtnINPUT_TYPE2.CheckedChanged,
                                                                                          rbtnINPUT_TYPE3.CheckedChanged
        Dim val As Integer
        Select Case True
            Case rbtnINPUT_TYPE1.Checked
                val = "1"
            Case rbtnINPUT_TYPE2.Checked
                val = "2"
            Case rbtnINPUT_TYPE3.Checked
                val = "3"
            Case Else
                val = ""
        End Select
        txtINPUT_TYPE.Text = val
    End Sub

    Private Sub chkST02_FUTEKIGO_UMU_CheckedChanged(sender As Object, e As EventArgs) Handles rbtnST02_FUTEKIGO_YES.CheckedChanged,
                                                                                          rbtnST02_FUTEKIGO_NO.CheckedChanged

        Select Case True
            Case rbtnST02_FUTEKIGO_YES.Checked
                chkST02_FUTEKIGO_UMU.Checked = True
            Case Else
                chkST02_FUTEKIGO_UMU.Checked = False
        End Select
    End Sub

    Private Sub chkJINTEKI_YOUIN_UMU_CheckedChanged(sender As Object, e As EventArgs) Handles rbtnFUTEKIGO_YOUIN_T.CheckedChanged,
                                                                                          rbtnFUTEKIGO_YOUIN_F.CheckedChanged

        Select Case True
            Case rbtnFUTEKIGO_YOUIN_T.Checked
                chkJINTEKI_YOUIN_UMU.Checked = True
                txtHASSEI_GENIN.Enabled = True
            Case Else
                chkJINTEKI_YOUIN_UMU.Checked = False
                txtHASSEI_GENIN.Enabled = False
        End Select
    End Sub

    Private Sub chkZESEI_SYOCHI_HANTEI_CheckedChanged(sender As Object, e As EventArgs) Handles rbtnZESEI_SYOCHI_YES.CheckedChanged,
                                                                                          rbtnZESEI_SYOCHI_NO.CheckedChanged

        Select Case True
            Case rbtnZESEI_SYOCHI_YES.Checked
                chkZESEI_SYOCHI_HANTEI.Checked = True
            Case Else
                chkZESEI_SYOCHI_HANTEI.Checked = False
        End Select
    End Sub

#End Region

    Private Sub txtHASSEI_GENIN_Validated(sender As Object, e As EventArgs) Handles txtHASSEI_GENIN.Validated
        Dim txt As TextBoxEx = DirectCast(sender, TextBoxEx)
        If IsCheckRequired Then
            IsValidated *= ErrorProvider.UpdateErrorInfo(txt, Not txt.Text.IsNulOrWS, String.Format(My.Resources.infoMsgRequireSelectOrInput, "発生原因"))
        End If
    End Sub

#End Region

#Region "ローカル関数"

#Region "バインディング"

    Private Sub ClearBinding()
        mtxHOKOKU_NO.DataBindings.Clear()
        cmbBUMON.DataBindings.Clear()
        cmbKA.DataBindings.Clear()
        cmbTANTO.DataBindings.Clear()
        txtINPUT_TYPE.DataBindings.Clear()
        txtDOC_NO.DataBindings.Clear()
        dtKAITOU_KIBOU_YMD.DataBindings.Clear()
        txtKANSATU_HOUKOKU.DataBindings.Clear()
        txtZESEI_RIYU.DataBindings.Clear()
        txtZESEI_COMMENT.DataBindings.Clear()
        dtKAITOU_YMD.DataBindings.Clear()
        chkST02_FUTEKIGO_UMU.DataBindings.Clear()
        txtFUTEKIGO_TAISYOU.DataBindings.Clear()
        txtCHOUSA_HANI.DataBindings.Clear()

        txtEIKYOU_HANI.DataBindings.Clear()
        txtOUKYU_SYOCHI.DataBindings.Clear()
        dtOUKYU_SYOCHI_YOTEI_YMD.DataBindings.Clear()
        chkJINTEKI_YOUIN_UMU.DataBindings.Clear()
        txtHASSEI_GENIN.DataBindings.Clear()
        txtZESEI_SYOCHI.DataBindings.Clear()
        dtZESEI_SYOCHI_YOTEI_YMD.DataBindings.Clear()
        dtZESEI_SYOCHI_YMD.DataBindings.Clear()
        dtOUKYU_SYOCHI_YMD.DataBindings.Clear()
        txtOUKYU_SYOCHI_KEKKA.DataBindings.Clear()
        txtZESEI_SYOCHI_KEKKA.DataBindings.Clear()
        chkZESEI_SYOCHI_HANTEI.DataBindings.Clear()

        txtCOMMENT1.DataBindings.Clear()
        txtCOMMENT2.DataBindings.Clear()
        txtCOMMENT3.DataBindings.Clear()
        txtCOMMENT4.DataBindings.Clear()
        txtCOMMENT5.DataBindings.Clear()

        lbltmpFile1.DataBindings.Clear()
        lbltmpFile2.DataBindings.Clear()
        lbltmpFile3.DataBindings.Clear()
        lbltmpFile4.DataBindings.Clear()
        lbltmpFile5.DataBindings.Clear()
    End Sub

    Private Function FunSetBinding() As Boolean

        Try

            mtxHOKOKU_NO.DataBindings.Add(New Binding(NameOf(mtxHOKOKU_NO.Text), _D014, NameOf(_D014.HOKOKU_NO), False, DataSourceUpdateMode.OnPropertyChanged, ""))
            cmbBUMON.DataBindings.Add(New Binding(NameOf(cmbBUMON.SelectedValue), _D014, NameOf(_D014.BUMON_KB), False, DataSourceUpdateMode.OnPropertyChanged, ""))
            cmbKA.DataBindings.Add(New Binding(NameOf(cmbKA.SelectedValue), _D014, NameOf(_D014.BUSYO_ID), False, DataSourceUpdateMode.OnPropertyChanged, 0))
            cmbTANTO.DataBindings.Add(New Binding(NameOf(cmbTANTO.SelectedValue), _D014, NameOf(_D014.TANTO_ID), False, DataSourceUpdateMode.OnPropertyChanged, 0))
            txtINPUT_TYPE.DataBindings.Add(New Binding(NameOf(txtINPUT_TYPE.Text), _D014, NameOf(_D014.INPUT_TYPE), False, DataSourceUpdateMode.OnPropertyChanged, ""))
            txtDOC_NO.DataBindings.Add(New Binding(NameOf(txtDOC_NO.Text), _D014, NameOf(_D014.DOC_NO), False, DataSourceUpdateMode.OnPropertyChanged, ""))
            dtKAITOU_KIBOU_YMD.DataBindings.Add(New Binding(NameOf(dtKAITOU_KIBOU_YMD.Text), _D014, NameOf(_D014.KAITOU_KIBOU_YMD), False, DataSourceUpdateMode.OnPropertyChanged, ""))
            txtKANSATU_HOUKOKU.DataBindings.Add(New Binding(NameOf(txtKANSATU_HOUKOKU.Text), _D014, NameOf(_D014.KANSATU_HOUKOKU), False, DataSourceUpdateMode.OnPropertyChanged, ""))
            txtZESEI_RIYU.DataBindings.Add(New Binding(NameOf(txtZESEI_RIYU.Text), _D014, NameOf(_D014.ZESEI_RIYU), False, DataSourceUpdateMode.OnPropertyChanged, ""))
            txtZESEI_COMMENT.DataBindings.Add(New Binding(NameOf(txtZESEI_COMMENT.Text), _D014, NameOf(_D014.ZESEI_COMMENT), False, DataSourceUpdateMode.OnPropertyChanged, ""))
            dtKAITOU_YMD.DataBindings.Add(New Binding(NameOf(dtKAITOU_YMD.Text), _D014, NameOf(_D014.KAITOU_YMD), False, DataSourceUpdateMode.OnPropertyChanged, ""))
            chkST02_FUTEKIGO_UMU.DataBindings.Add(New Binding(NameOf(chkST02_FUTEKIGO_UMU.Checked), _D014, NameOf(_D014.FUTEKIGO_UMU), False, DataSourceUpdateMode.OnPropertyChanged, False))
            txtFUTEKIGO_TAISYOU.DataBindings.Add(New Binding(NameOf(txtFUTEKIGO_TAISYOU.Text), _D014, NameOf(_D014.FUTEKIGO_TAISYOU), False, DataSourceUpdateMode.OnPropertyChanged, ""))
            txtCHOUSA_HANI.DataBindings.Add(New Binding(NameOf(txtCHOUSA_HANI.Text), _D014, NameOf(_D014.CHOUSA_HANI), False, DataSourceUpdateMode.OnPropertyChanged, ""))

            txtEIKYOU_HANI.DataBindings.Add(New Binding(NameOf(txtEIKYOU_HANI.Text), _D014, NameOf(_D014.EIKYOU_HANI), False, DataSourceUpdateMode.OnPropertyChanged, ""))
            txtOUKYU_SYOCHI.DataBindings.Add(New Binding(NameOf(txtOUKYU_SYOCHI.Text), _D014, NameOf(_D014.OUKYU_SYOCHI), False, DataSourceUpdateMode.OnPropertyChanged, ""))
            dtOUKYU_SYOCHI_YOTEI_YMD.DataBindings.Add(New Binding(NameOf(dtOUKYU_SYOCHI_YOTEI_YMD.Text), _D014, NameOf(_D014.OUKYU_SYOCHI_YOTEI_YMD), False, DataSourceUpdateMode.OnPropertyChanged, ""))
            chkJINTEKI_YOUIN_UMU.DataBindings.Add(New Binding(NameOf(chkJINTEKI_YOUIN_UMU.Checked), _D014, NameOf(_D014.JINTEKI_YOUIN_UMU), False, DataSourceUpdateMode.OnPropertyChanged, False))
            txtHASSEI_GENIN.DataBindings.Add(New Binding(NameOf(txtHASSEI_GENIN.Text), _D014, NameOf(_D014.HASSEI_GENIN), False, DataSourceUpdateMode.OnPropertyChanged, ""))
            txtZESEI_SYOCHI.DataBindings.Add(New Binding(NameOf(txtZESEI_SYOCHI.Text), _D014, NameOf(_D014.ZESEI_SYOCHI), False, DataSourceUpdateMode.OnPropertyChanged, ""))
            dtZESEI_SYOCHI_YOTEI_YMD.DataBindings.Add(New Binding(NameOf(dtZESEI_SYOCHI_YOTEI_YMD.Text), _D014, NameOf(_D014.ZESEI_SYOCHI_YOTEI_YMD), False, DataSourceUpdateMode.OnPropertyChanged, ""))
            dtZESEI_SYOCHI_YMD.DataBindings.Add(New Binding(NameOf(dtZESEI_SYOCHI_YMD.Text), _D014, NameOf(_D014.ZESEI_SYOCHI_YMD), False, DataSourceUpdateMode.OnPropertyChanged, ""))
            dtOUKYU_SYOCHI_YMD.DataBindings.Add(New Binding(NameOf(dtOUKYU_SYOCHI_YMD.Text), _D014, NameOf(_D014.OUKYU_SYOCHI_YMD), False, DataSourceUpdateMode.OnPropertyChanged, ""))
            txtOUKYU_SYOCHI_KEKKA.DataBindings.Add(New Binding(NameOf(txtOUKYU_SYOCHI_KEKKA.Text), _D014, NameOf(_D014.OUKYU_SYOCHI_KEKKA), False, DataSourceUpdateMode.OnPropertyChanged, ""))
            txtZESEI_SYOCHI_KEKKA.DataBindings.Add(New Binding(NameOf(txtZESEI_SYOCHI_KEKKA.Text), _D014, NameOf(_D014.ZESEI_SYOCHI_KEKKA), False, DataSourceUpdateMode.OnPropertyChanged, ""))
            chkZESEI_SYOCHI_HANTEI.DataBindings.Add(New Binding(NameOf(chkZESEI_SYOCHI_HANTEI.Checked), _D014, NameOf(_D014.ZESEI_SYOCHI_HANTEI), False, DataSourceUpdateMode.OnPropertyChanged, False))

            txtCOMMENT1.DataBindings.Add(New Binding(NameOf(txtCOMMENT1.Text), _D014, NameOf(_D014.COMMENT1), False, DataSourceUpdateMode.OnPropertyChanged, ""))
            txtCOMMENT2.DataBindings.Add(New Binding(NameOf(txtCOMMENT2.Text), _D014, NameOf(_D014.COMMENT2), False, DataSourceUpdateMode.OnPropertyChanged, ""))
            txtCOMMENT3.DataBindings.Add(New Binding(NameOf(txtCOMMENT3.Text), _D014, NameOf(_D014.COMMENT3), False, DataSourceUpdateMode.OnPropertyChanged, ""))
            txtCOMMENT4.DataBindings.Add(New Binding(NameOf(txtCOMMENT4.Text), _D014, NameOf(_D014.COMMENT4), False, DataSourceUpdateMode.OnPropertyChanged, ""))
            txtCOMMENT5.DataBindings.Add(New Binding(NameOf(txtCOMMENT5.Text), _D014, NameOf(_D014.COMMENT5), False, DataSourceUpdateMode.OnPropertyChanged, ""))

            lbltmpFile1.DataBindings.Add(New Binding(NameOf(lbltmpFile1.Tag), _D014, NameOf(_D014.FILE_PATH1), False, DataSourceUpdateMode.OnPropertyChanged, ""))
            lbltmpFile2.DataBindings.Add(New Binding(NameOf(lbltmpFile2.Tag), _D014, NameOf(_D014.FILE_PATH2), False, DataSourceUpdateMode.OnPropertyChanged, ""))
            lbltmpFile3.DataBindings.Add(New Binding(NameOf(lbltmpFile3.Tag), _D014, NameOf(_D014.FILE_PATH3), False, DataSourceUpdateMode.OnPropertyChanged, ""))
            lbltmpFile4.DataBindings.Add(New Binding(NameOf(lbltmpFile4.Tag), _D014, NameOf(_D014.FILE_PATH4), False, DataSourceUpdateMode.OnPropertyChanged, ""))
            lbltmpFile5.DataBindings.Add(New Binding(NameOf(lbltmpFile5.Tag), _D014, NameOf(_D014.FILE_PATH5), False, DataSourceUpdateMode.OnPropertyChanged, ""))

            Return True
        Catch ex As Exception
            Throw
            Return False
        End Try
    End Function

#End Region

#Region "処理モード別画面初期化"

    ''' <summary>
    ''' 画面初期化
    ''' </summary>
    ''' <param name="intMODE"></param>
    ''' <returns></returns>
    Private Function FunInitializeControls(intMODE As ENM_DATA_OPERATION_MODE) As Boolean

        Try

            pnlST01.BackColor = Color.Transparent
            pnlST02.BackColor = Color.Transparent
            pnlST03.BackColor = Color.Transparent
            pnlST05.BackColor = Color.Transparent
            pnlST04.BackColor = Color.Transparent

            'ナビゲートリンク選択
            If PrCurrentStage = ENM_ZESEI_STAGE._999_Closed Then
                rsbtnST99.Checked = True
            Else
                Dim rbtn As RibbonShapeRadioButton = DirectCast(flpnlStageIndex.Controls("rsbtnST" & (PrCurrentStage / 10).ToString("00")), RibbonShapeRadioButton)
                rbtn.Checked = True
            End If

            Call SetTANTO_TooltipInfo()

            '-----コントロールデータソース設定
            cmbBUMON.SetDataSource(tblBUMON, ENM_COMBO_SELECT_VALUE_TYPE._0_Required)

            '現行ステージ名
            lblCurrentStageName.Text = If(PrHOKOKU_NO.IsNulOrWS, "ST01.起草", FunGetLastStageName(Context.ENM_SYONIN_HOKOKUSYO_ID._6_ZESEI_R, PrHOKOKU_NO))

            Select Case intMODE
                Case ENM_DATA_OPERATION_MODE._1_ADD

                    Call FunSetD013Model(PrHOKOKU_NO, PrCurrentStage)

                    _D014.ADD_SYAIN_ID = pub_SYAIN_INFO.SYAIN_ID
                    _D014.ADD_YMDHNS = Now.ToString("yyyyMMddHHmmss")

                    If IsSysAdminUser(pub_SYAIN_INFO.SYAIN_ID) Then
                    Else
                        _D014.BUMON_KB = pub_SYAIN_INFO.BUMON_KB
                    End If

                    tabMain.Visible = False 'ちらつき防止
                    Application.DoEvents()
                    Call FunInitializeSTAGE(PrCurrentStage)
                    Application.DoEvents()
                    tabMain.Visible = True

                Case ENM_DATA_OPERATION_MODE._3_UPDATE

                    Call FunSetEntityModel(PrHOKOKU_NO, PrCurrentStage)

                    tabMain.Visible = False
                    Application.DoEvents()
                    Call FunInitializeSTAGE(PrCurrentStage)
                    Application.DoEvents()
                    tabMain.Visible = True

                    'カレントステージ選択
                    'For Each page As TabPage In tabMain.TabPages
                    '    If page.Text = "現ステージ" Then
                    '        'SPEC: 10-2.④
                    '        tabMain.SelectedTab = page
                    '        Exit For
                    '    End If
                    'Next page
                    'Me.tabMain.Visible = True

                    Dim HeaderItemReadOnly As Boolean
                    If PrCurrentStage = ENM_ZESEI_STAGE._10_起草入力 Then
                        HeaderItemReadOnly = False
                    ElseIf PrCurrentStage = ENM_ZESEI_STAGE._999_Closed And IsEditingClosed = True Then
                        HeaderItemReadOnly = True
                    End If
                    mtxHOKOKU_NO.ReadOnly = HeaderItemReadOnly
                    cmbBUMON.ReadOnly = HeaderItemReadOnly
                    cmbTANTO.ReadOnly = HeaderItemReadOnly
                    cmbKA.ReadOnly = HeaderItemReadOnly

            End Select

            Call ClearBinding()
            Call FunSetBinding()

            Return True
        Catch ex As Exception
            EM.ErrorSyori(ex, False, conblnNonMsg)
        End Try
    End Function

    Private Function FunSetD013Model(HOKOKU_NO As String, SYONIN_JUN As Integer) As Boolean

        Try
            'ビューモデルをロード
            _D013 = FunGetD013Model(HOKOKU_NO)
            _D014.HOKOKU_NO = _D013.HOKOKU_NO
            _D014.BUMON_KB = _D013.BUMON_KB
            _D014.BUSYO_ID = _D013.BUSYO_ID
            _D014.TANTO_ID = _D013.TANTO_ID

            Return True
        Catch ex As Exception
            EM.ErrorSyori(ex, False, conblnNonMsg)
            Return False
        End Try
    End Function

    Private Function FunSetEntityModel(HOKOKU_NO As String, SYONIN_JUN As Integer) As Boolean

        Try
            'ビューモデルをロード
            _D014 = FunGetD014Model(HOKOKU_NO)
            _V003_SYONIN_J_KANRI_List = FunGetV003Model(Context.ENM_SYONIN_HOKOKUSYO_ID._6_ZESEI_R, HOKOKU_NO)

#Region "D003"

            Dim t As Type = GetType(D014)
            Dim properties As Reflection.PropertyInfo() = t.GetProperties(
                 Reflection.BindingFlags.Public Or
                 Reflection.BindingFlags.Instance Or
                 Reflection.BindingFlags.Static)

            Dim blnFieldList As New List(Of String) From {NameOf(D014.CLOSE_FG),
                                                          NameOf(D014.FUTEKIGO_UMU),
                                                          NameOf(D014.JINTEKI_YOUIN_UMU),
                                                          NameOf(D014.ZESEI_SYOCHI_HANTEI)}

            If PrCurrentStage = ENM_ZESEI_STAGE._10_起草入力 AndAlso Not IsRemanded(_D014.HOKOKU_NO) Then
                _D014.ADD_SYAIN_ID = pub_SYAIN_INFO.SYAIN_ID
            End If

#End Region

#Region "D004"

            Dim _V003 As New V003_SYONIN_J_KANRI
            _V003 = _V003_SYONIN_J_KANRI_List.AsEnumerable.
                                Where(Function(r) r.SYONIN_JUN = SYONIN_JUN).
                                FirstOrDefault

            t = GetType(D004_SYONIN_J_KANRI)
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

#Region "添付資料"

            Dim strRootDir As String
            Using DB As ClsDbUtility = DBOpen()
                strRootDir = FunConvPathString(FunGetCodeMastaValue(DB, "添付ファイル保存先", My.Application.Info.AssemblyName))
            End Using

            If Not _D014.FILE_PATH1.IsNulOrWS Then
                lbltmpFile1.Text = CompactString(_D014.FILE_PATH1, lbltmpFile1, EllipsisFormat._4_Path)
                lbltmpFile1.Links.Clear()
                lbltmpFile1.Links.Add(0, lbltmpFile1.Text.Length, strRootDir & _D014.HOKOKU_NO.Trim & "\" & _D014.FILE_PATH1)
                lbltmpFile1.Visible = True
                lbltmpFile1_Clear.Visible = True
            End If
            If Not _D014.FILE_PATH2.IsNulOrWS Then
                lbltmpFile2.Text = CompactString(_D014.FILE_PATH2, lbltmpFile2, EllipsisFormat._4_Path)
                lbltmpFile2.Links.Clear()
                lbltmpFile2.Links.Add(0, lbltmpFile2.Text.Length, strRootDir & _D014.HOKOKU_NO.Trim & "\" & _D014.FILE_PATH2)
                lbltmpFile2.Visible = True
                lbltmpFile2_Clear.Visible = True
            End If
            If Not _D014.FILE_PATH3.IsNulOrWS Then
                lbltmpFile3.Text = CompactString(_D014.FILE_PATH3, lbltmpFile3, EllipsisFormat._4_Path)
                lbltmpFile3.Links.Clear()
                lbltmpFile3.Links.Add(0, lbltmpFile3.Text.Length, strRootDir & _D014.HOKOKU_NO.Trim & "\" & _D014.FILE_PATH3)
                lbltmpFile3.Visible = True
                lbltmpFile3_Clear.Visible = True
            End If
            If Not _D014.FILE_PATH4.IsNulOrWS Then
                lbltmpFile4.Text = CompactString(_D014.FILE_PATH4, lbltmpFile4, EllipsisFormat._4_Path)
                lbltmpFile4.Links.Clear()
                lbltmpFile4.Links.Add(0, lbltmpFile4.Text.Length, strRootDir & _D014.HOKOKU_NO.Trim & "\" & _D014.FILE_PATH4)
                lbltmpFile4.Visible = True
                lbltmpFile4_Clear.Visible = True
            End If
            If Not _D014.FILE_PATH5.IsNulOrWS Then
                lbltmpFile5.Text = CompactString(_D014.FILE_PATH5, lbltmpFile5, EllipsisFormat._4_Path)
                lbltmpFile5.Links.Clear()
                lbltmpFile5.Links.Add(0, lbltmpFile5.Text.Length, strRootDir & _D014.HOKOKU_NO.Trim & "\" & _D014.FILE_PATH5)
                lbltmpFile5.Visible = True
                lbltmpFile5_Clear.Visible = True
            End If

#End Region

            Return True
        Catch ex As Exception
            EM.ErrorSyori(ex, False, conblnNonMsg)
            Return False
        End Try
    End Function

    Private Function FunInitializeSTAGE(ByVal intStageID As Integer) As Boolean
        Dim dt As DataTable
        Dim _V003List As List(Of V003_SYONIN_J_KANRI)
        Dim V003 As V003_SYONIN_J_KANRI

        Dim dtUser As DataTable
        Dim drs As IEnumerable(Of DataRow)
        Dim InList As New List(Of Integer)

        Try

#Region "Set EventHandler"

            Select Case DirectCast(intStageID, ENM_ZESEI_STAGE)
                Case ENM_ZESEI_STAGE._10_起草入力
                    AddHandler cmbST01_SAKUSEI_TANTO.SelectedValueChanged, AddressOf CmbDestTANTO_SelectedvalueChanged
                    cmbST01_SAKUSEI_TANTO.SelectedValue = pub_SYAIN_INFO.SYAIN_ID
                Case ENM_ZESEI_STAGE._11_起草入力_点検
                    AddHandler cmbST01_TENKEN_TANTO.SelectedValueChanged, AddressOf CmbDestTANTO_SelectedvalueChanged
                    cmbST01_TENKEN_TANTO.SelectedValue = pub_SYAIN_INFO.SYAIN_ID
                Case ENM_ZESEI_STAGE._12_起草入力_認可
                    AddHandler cmbST01_NINKA_TANTO.SelectedValueChanged, AddressOf CmbDestTANTO_SelectedvalueChanged
                    cmbST01_NINKA_TANTO.SelectedValue = pub_SYAIN_INFO.SYAIN_ID
                Case ENM_ZESEI_STAGE._20_是正処置入力
                    AddHandler cmbST02_SAKUSEI_TANTO.SelectedValueChanged, AddressOf CmbDestTANTO_SelectedvalueChanged
                    cmbST02_SAKUSEI_TANTO.SelectedValue = pub_SYAIN_INFO.SYAIN_ID
                Case ENM_ZESEI_STAGE._21_是正処置入力_点検
                    AddHandler cmbST02_TENKEN_TANTO.SelectedValueChanged, AddressOf CmbDestTANTO_SelectedvalueChanged
                    cmbST02_TENKEN_TANTO.SelectedValue = pub_SYAIN_INFO.SYAIN_ID
                Case ENM_ZESEI_STAGE._22_是正処置入力_認可
                    AddHandler cmbST02_NINKA_TANTO.SelectedValueChanged, AddressOf CmbDestTANTO_SelectedvalueChanged
                    cmbST02_NINKA_TANTO.SelectedValue = pub_SYAIN_INFO.SYAIN_ID
                Case ENM_ZESEI_STAGE._23_是正処置入力_品証_点検
                    AddHandler cmbST02_HINSYO_TENKEN_TANTO.SelectedValueChanged, AddressOf CmbDestTANTO_SelectedvalueChanged
                    cmbST02_HINSYO_TENKEN_TANTO.SelectedValue = pub_SYAIN_INFO.SYAIN_ID
                Case ENM_ZESEI_STAGE._24_是正処置入力_品証_認可
                    AddHandler cmbST02_HINSYO_NINKA_TANTO.SelectedValueChanged, AddressOf CmbDestTANTO_SelectedvalueChanged
                    cmbST02_HINSYO_NINKA_TANTO.SelectedValue = pub_SYAIN_INFO.SYAIN_ID
                Case ENM_ZESEI_STAGE._30_処置結果入力
                    AddHandler cmbST03_SAKUSEI_TANTO.SelectedValueChanged, AddressOf CmbDestTANTO_SelectedvalueChanged
                    cmbST03_SAKUSEI_TANTO.SelectedValue = pub_SYAIN_INFO.SYAIN_ID
                Case ENM_ZESEI_STAGE._31_処置結果入力_点検
                    AddHandler cmbST03_TENKEN_TANTO.SelectedValueChanged, AddressOf CmbDestTANTO_SelectedvalueChanged
                    cmbST03_TENKEN_TANTO.SelectedValue = pub_SYAIN_INFO.SYAIN_ID
                Case ENM_ZESEI_STAGE._32_処置結果入力_認可
                    AddHandler cmbST03_NINKA_TANTO.SelectedValueChanged, AddressOf CmbDestTANTO_SelectedvalueChanged
                    cmbST03_NINKA_TANTO.SelectedValue = pub_SYAIN_INFO.SYAIN_ID
                Case ENM_ZESEI_STAGE._40_処置結果レビュー
                    AddHandler cmbST04_SAKUSEI_TANTO.SelectedValueChanged, AddressOf CmbDestTANTO_SelectedvalueChanged
                    cmbST04_SAKUSEI_TANTO.SelectedValue = pub_SYAIN_INFO.SYAIN_ID
                Case ENM_ZESEI_STAGE._41_処置結果レビュー_点検
                    AddHandler cmbST04_TENKEN_TANTO.SelectedValueChanged, AddressOf CmbDestTANTO_SelectedvalueChanged
                    cmbST04_TENKEN_TANTO.SelectedValue = pub_SYAIN_INFO.SYAIN_ID
                Case ENM_ZESEI_STAGE._42_処置結果レビュー_認可
                    AddHandler cmbST04_NINKA_TANTO.SelectedValueChanged, AddressOf CmbDestTANTO_SelectedvalueChanged
                    cmbST04_NINKA_TANTO.SelectedValue = pub_SYAIN_INFO.SYAIN_ID
                Case ENM_ZESEI_STAGE._50_要求元完了確認
                    AddHandler cmbST05_SAKUSEI_TANTO.SelectedValueChanged, AddressOf CmbDestTANTO_SelectedvalueChanged
                    cmbST05_SAKUSEI_TANTO.SelectedValue = pub_SYAIN_INFO.SYAIN_ID
                Case ENM_ZESEI_STAGE._51_要求元完了確認_点検
                    AddHandler cmbST05_TENKEN_TANTO.SelectedValueChanged, AddressOf CmbDestTANTO_SelectedvalueChanged
                    cmbST05_TENKEN_TANTO.SelectedValue = pub_SYAIN_INFO.SYAIN_ID
                Case ENM_ZESEI_STAGE._52_要求元完了確認_認可
                    AddHandler cmbST05_NINKA_TANTO.SelectedValueChanged, AddressOf CmbDestTANTO_SelectedvalueChanged
                    cmbST05_NINKA_TANTO.SelectedValue = pub_SYAIN_INFO.SYAIN_ID
                Case ENM_ZESEI_STAGE._999_Closed
            End Select

#End Region

            If intStageID >= ENM_ZESEI_STAGE._10_起草入力 And Not _D014.BUMON_KB.IsNulOrWS Then

                dtUser = FunGetSYOZOKU_SYAIN(_D014.BUMON_KB)
                pnlST01.Visible = True

                Select Case _D014.INPUT_TYPE
                    Case "1"
                        rbtnINPUT_TYPE1.Checked = True
                    Case "2"
                        rbtnINPUT_TYPE2.Checked = True
                    Case "3"
                        rbtnINPUT_TYPE3.Checked = True
                End Select

#Region "           承認担当者"

                drs = dtUser.AsEnumerable.Where(Function(r) r.Item(NameOf(M011_SYAIN_GYOMU.GYOMU_GROUP_ID)) = ENM_GYOMU_GROUP_ID._4_品証.Value)
                If drs.Count > 0 Then cmbST01_SAKUSEI_TANTO.SetDataSource(drs.CopyToDataTable, ENM_COMBO_SELECT_VALUE_TYPE._0_Required)

                dt = FunGetSYONIN_SYOZOKU_SYAIN(_D014.BUMON_KB, Context.ENM_SYONIN_HOKOKUSYO_ID._5_ZESEI.Value, ENM_ZESEI_STAGE._11_起草入力_点検)
                cmbST01_TENKEN_TANTO.SetDataSource(dt, ENM_COMBO_SELECT_VALUE_TYPE._0_Required)
                dt = FunGetSYONIN_SYOZOKU_SYAIN(_D014.BUMON_KB, Context.ENM_SYONIN_HOKOKUSYO_ID._5_ZESEI.Value, ENM_ZESEI_STAGE._12_起草入力_認可)
                cmbST01_NINKA_TANTO.SetDataSource(dt, ENM_COMBO_SELECT_VALUE_TYPE._0_Required)

                V003 = _V003_SYONIN_J_KANRI_List.AsEnumerable.Where(Function(r) r.SYONIN_JUN = ENM_ZESEI_STAGE._10_起草入力).FirstOrDefault
                If V003 IsNot Nothing Then
                    cmbST01_SAKUSEI_TANTO.SelectedValue = V003.SYAIN_ID
                    dtST01_SAKUSEI_YMD.Text = V003.SYONIN_YMDHNS.ToDateTimeWithFormat("yyyyMMddHHmmss", "yyyy/MM/dd")
                End If
                V003 = _V003_SYONIN_J_KANRI_List.AsEnumerable.Where(Function(r) r.SYONIN_JUN = ENM_ZESEI_STAGE._11_起草入力_点検).FirstOrDefault
                If V003 IsNot Nothing Then
                    cmbST01_TENKEN_TANTO.SelectedValue = V003.SYAIN_ID
                    dtST01_TENKEN_YMD.Text = V003.SYONIN_YMDHNS.ToDateTimeWithFormat("yyyyMMddHHmmss", "yyyy/MM/dd")
                End If
                V003 = _V003_SYONIN_J_KANRI_List.AsEnumerable.Where(Function(r) r.SYONIN_JUN = ENM_ZESEI_STAGE._12_起草入力_認可).FirstOrDefault
                If V003 IsNot Nothing Then
                    cmbST01_NINKA_TANTO.SelectedValue = V003.SYAIN_ID
                    dtST01_NINKA_YMD.Text = V003.SYONIN_YMDHNS.ToDateTimeWithFormat("yyyyMMddHHmmss", "yyyy/MM/dd")
                End If

#End Region

#Region "           差し戻し理由"

                _V003List = _V003_SYONIN_J_KANRI_List.AsEnumerable.
                        Where(Function(r) r.SYONIN_JUN >= ENM_ZESEI_STAGE._10_起草入力 And r.SYONIN_JUN < ENM_ZESEI_STAGE._20_是正処置入力).ToList

                If _V003List.Count > 0 Then
                    V003 = _V003List.Where(Function(r) r.SASIMODOSI_FG And r.RIYU.ToString.Trim.IsNulOrWS).
                                                        OrderBy(Function(r) r.SYONIN_JUN).
                                                        FirstOrDefault

                    If V003 IsNot Nothing Then
                        lblST01_Modoshi_Riyu.Text = $"差戻理由：{V003.RIYU}"
                    Else
                        lblST01_Modoshi_Riyu.Text = ""
                    End If
                End If

#End Region

            End If

            If intStageID >= ENM_ZESEI_STAGE._12_起草入力_認可 Then
                pnlST02.Visible = True
                dt = FunGetSYONIN_SYOZOKU_SYAIN(_D014.BUMON_KB, Context.ENM_SYONIN_HOKOKUSYO_ID._5_ZESEI.Value, ENM_ZESEI_STAGE._20_是正処置入力)
                If dtUser IsNot Nothing Then
                    InList.Clear() : InList.AddRange({ENM_GYOMU_GROUP_ID._1_技術.Value, ENM_GYOMU_GROUP_ID._2_製造.Value, ENM_GYOMU_GROUP_ID._7_管理.Value, ENM_GYOMU_GROUP_ID._8_営業.Value})
                    drs = dtUser.AsEnumerable.Where(Function(r) InList.Contains(r.Field(Of Integer)(NameOf(M011_SYAIN_GYOMU.GYOMU_GROUP_ID))))
                End If
                If drs IsNot Nothing Then dt.Merge(drs.CopyToDataTable)
                cmbST02_SAKUSEI_TANTO.SetDataSource(dt, ENM_COMBO_SELECT_VALUE_TYPE._0_Required)
            End If

            If intStageID >= ENM_ZESEI_STAGE._20_是正処置入力 Then
                'tlpHeader.Enabled = False
                'pnlST01.Enabled = False

                If _D014.FUTEKIGO_UMU Then
                    rbtnST02_FUTEKIGO_YES.Checked = True
                Else
                    rbtnST02_FUTEKIGO_NO.Checked = True
                End If

                If _D014.JINTEKI_YOUIN_UMU Then
                    rbtnFUTEKIGO_YOUIN_T.Checked = True
                Else
                    rbtnFUTEKIGO_YOUIN_F.Checked = True
                End If

#Region "           承認担当者"

                dt = FunGetSYONIN_SYOZOKU_SYAIN(_D014.BUMON_KB, Context.ENM_SYONIN_HOKOKUSYO_ID._5_ZESEI.Value, ENM_ZESEI_STAGE._21_是正処置入力_点検)
                If drs IsNot Nothing Then dt.Merge(drs.CopyToDataTable)
                cmbST02_TENKEN_TANTO.SetDataSource(dt, ENM_COMBO_SELECT_VALUE_TYPE._0_Required)
                dt = FunGetSYONIN_SYOZOKU_SYAIN(_D014.BUMON_KB, Context.ENM_SYONIN_HOKOKUSYO_ID._5_ZESEI.Value, ENM_ZESEI_STAGE._22_是正処置入力_認可)
                cmbST02_NINKA_TANTO.SetDataSource(dt, ENM_COMBO_SELECT_VALUE_TYPE._0_Required)

                Dim IsHinsyo = FunGetSYOZOKU_SYAIN(cmbBUMON.SelectedValue).
                                AsEnumerable.
                                Any(Function(r) r.Item("GYOMU_GROUP_ID") = ENM_GYOMU_GROUP_ID._4_品証 And r.Item("VALUE") = cmbST02_SAKUSEI_TANTO.SelectedValue)

                V003 = _V003_SYONIN_J_KANRI_List.AsEnumerable.Where(Function(r) r.SYONIN_JUN = ENM_ZESEI_STAGE._20_是正処置入力).FirstOrDefault
                If V003 IsNot Nothing Then
                    cmbST02_SAKUSEI_TANTO.SelectedValue = V003.SYAIN_ID
                    dtST02_SAKUSEI_YMD.Text = V003.SYONIN_YMDHNS.ToDateTimeWithFormat("yyyyMMddHHmmss", "yyyy/MM/dd")
                End If

                V003 = _V003_SYONIN_J_KANRI_List.AsEnumerable.Where(Function(r) r.SYONIN_JUN = ENM_ZESEI_STAGE._21_是正処置入力_点検).FirstOrDefault
                If V003 IsNot Nothing Then
                    cmbST02_TENKEN_TANTO.SelectedValue = V003.SYAIN_ID
                    dtST02_TENKEN_YMD.Text = V003.SYONIN_YMDHNS.ToDateTimeWithFormat("yyyyMMddHHmmss", "yyyy/MM/dd")
                End If

                V003 = _V003_SYONIN_J_KANRI_List.AsEnumerable.Where(Function(r) r.SYONIN_JUN = ENM_ZESEI_STAGE._22_是正処置入力_認可).FirstOrDefault
                If V003 IsNot Nothing Then
                    cmbST02_NINKA_TANTO.SelectedValue = V003.SYAIN_ID
                    dtST02_NINKA_YMD.Text = V003.SYONIN_YMDHNS.ToDateTimeWithFormat("yyyyMMddHHmmss", "yyyy/MM/dd")
                End If

                'Dim nextstage As Integer
                If IsHinsyo Then
                    'nextstage = ENM_ZESEI_STAGE._30_処置結果入力
                Else
                    'nextstage = ENM_ZESEI_STAGE._23_是正処置入力_品証_点検

                    dt = FunGetSYONIN_SYOZOKU_SYAIN(_D014.BUMON_KB, Context.ENM_SYONIN_HOKOKUSYO_ID._5_ZESEI.Value, ENM_ZESEI_STAGE._23_是正処置入力_品証_点検)
                    cmbST02_HINSYO_TENKEN_TANTO.SetDataSource(dt, ENM_COMBO_SELECT_VALUE_TYPE._0_Required)

                    dt = FunGetSYONIN_SYOZOKU_SYAIN(_D014.BUMON_KB, Context.ENM_SYONIN_HOKOKUSYO_ID._5_ZESEI.Value, ENM_ZESEI_STAGE._24_是正処置入力_品証_認可)
                    cmbST02_HINSYO_NINKA_TANTO.SetDataSource(dt, ENM_COMBO_SELECT_VALUE_TYPE._0_Required)

                    V003 = _V003_SYONIN_J_KANRI_List.AsEnumerable.Where(Function(r) r.SYONIN_JUN = ENM_ZESEI_STAGE._23_是正処置入力_品証_点検).FirstOrDefault
                    If V003 IsNot Nothing Then
                        cmbST02_HINSYO_TENKEN_TANTO.SelectedValue = V003.SYAIN_ID
                        dtST02_HINSYO_TENKEN_YMD.Text = V003.SYONIN_YMDHNS.ToDateTimeWithFormat("yyyyMMddHHmmss", "yyyy/MM/dd")
                    End If

                    V003 = _V003_SYONIN_J_KANRI_List.AsEnumerable.Where(Function(r) r.SYONIN_JUN = ENM_ZESEI_STAGE._24_是正処置入力_品証_認可).FirstOrDefault
                    If V003 IsNot Nothing Then
                        cmbST02_HINSYO_NINKA_TANTO.SelectedValue = V003.SYAIN_ID
                        dtST02_HINSYO_NINKA_YMD.Text = V003.SYONIN_YMDHNS.ToDateTimeWithFormat("yyyyMMddHHmmss", "yyyy/MM/dd")
                    End If
                End If

#End Region

#Region "           差し戻し理由"

                _V003List = _V003_SYONIN_J_KANRI_List.AsEnumerable.
                    Where(Function(r) r.SYONIN_JUN >= ENM_ZESEI_STAGE._20_是正処置入力 And r.SYONIN_JUN < ENM_ZESEI_STAGE._30_処置結果入力).ToList

                If _V003List.Count > 0 Then
                    V003 = _V003List.Where(Function(r) r.SASIMODOSI_FG And r.RIYU.ToString.Trim.IsNulOrWS).
                                                    OrderBy(Function(r) r.SYONIN_JUN).
                                                    FirstOrDefault

                    If V003 IsNot Nothing Then
                        lblST02_Modoshi_Riyu.Text = $"差戻理由：{V003.RIYU}"
                    Else
                        lblST02_Modoshi_Riyu.Text = ""
                    End If
                End If

#End Region

            End If

            If intStageID >= ENM_ZESEI_STAGE._22_是正処置入力_認可 Then
                pnlST03.Visible = True
                dt = FunGetSYONIN_SYOZOKU_SYAIN(_D014.BUMON_KB, Context.ENM_SYONIN_HOKOKUSYO_ID._5_ZESEI.Value, ENM_ZESEI_STAGE._30_処置結果入力)
                cmbST03_SAKUSEI_TANTO.SetDataSource(dt, ENM_COMBO_SELECT_VALUE_TYPE._0_Required)
            End If

            If intStageID >= ENM_ZESEI_STAGE._30_処置結果入力 Then
                'pnlST02.Enabled = False

#Region "           承認担当者"

                dt = FunGetSYONIN_SYOZOKU_SYAIN(_D014.BUMON_KB, Context.ENM_SYONIN_HOKOKUSYO_ID._5_ZESEI.Value, ENM_ZESEI_STAGE._31_処置結果入力_点検)
                cmbST03_TENKEN_TANTO.SetDataSource(dt, ENM_COMBO_SELECT_VALUE_TYPE._0_Required)
                dt = FunGetSYONIN_SYOZOKU_SYAIN(_D014.BUMON_KB, Context.ENM_SYONIN_HOKOKUSYO_ID._5_ZESEI.Value, ENM_ZESEI_STAGE._32_処置結果入力_認可)
                cmbST03_NINKA_TANTO.SetDataSource(dt, ENM_COMBO_SELECT_VALUE_TYPE._0_Required)

                V003 = _V003_SYONIN_J_KANRI_List.AsEnumerable.Where(Function(r) r.SYONIN_JUN = ENM_ZESEI_STAGE._30_処置結果入力).FirstOrDefault
                If V003 IsNot Nothing Then
                    cmbST03_SAKUSEI_TANTO.SelectedValue = V003.SYAIN_ID
                    dtST03_SAKUSEI_YMD.Text = V003.SYONIN_YMDHNS.ToDateTimeWithFormat("yyyyMMddHHmmss", "yyyy/MM/dd")
                End If

                V003 = _V003_SYONIN_J_KANRI_List.AsEnumerable.Where(Function(r) r.SYONIN_JUN = ENM_ZESEI_STAGE._31_処置結果入力_点検).FirstOrDefault
                If V003 IsNot Nothing Then
                    cmbST03_TENKEN_TANTO.SelectedValue = V003.SYAIN_ID
                    dtST03_TENKEN_YMD.Text = V003.SYONIN_YMDHNS.ToDateTimeWithFormat("yyyyMMddHHmmss", "yyyy/MM/dd")
                End If

                V003 = _V003_SYONIN_J_KANRI_List.AsEnumerable.Where(Function(r) r.SYONIN_JUN = ENM_ZESEI_STAGE._32_処置結果入力_認可).FirstOrDefault
                If V003 IsNot Nothing Then
                    cmbST03_NINKA_TANTO.SelectedValue = V003.SYAIN_ID
                    dtST03_NINKA_YMD.Text = V003.SYONIN_YMDHNS.ToDateTimeWithFormat("yyyyMMddHHmmss", "yyyy/MM/dd")
                End If

#End Region

#Region "           差し戻し理由"

                _V003List = _V003_SYONIN_J_KANRI_List.AsEnumerable.
                        Where(Function(r) r.SYONIN_JUN >= ENM_ZESEI_STAGE._30_処置結果入力 And r.SYONIN_JUN < ENM_ZESEI_STAGE._40_処置結果レビュー).ToList

                If _V003List.Count > 0 Then
                    V003 = _V003List.Where(Function(r) r.SASIMODOSI_FG And r.RIYU.ToString.Trim.IsNulOrWS).
                                                        OrderBy(Function(r) r.SYONIN_JUN).
                                                        FirstOrDefault

                    If V003 IsNot Nothing Then
                        lblST03_Modoshi_Riyu.Text = $"差戻理由：{V003.RIYU}"
                    Else
                        lblST03_Modoshi_Riyu.Text = ""
                    End If
                End If

#End Region

            End If

            If intStageID >= ENM_ZESEI_STAGE._32_処置結果入力_認可 Then
                pnlST04.Visible = True
                dt = FunGetSYONIN_SYOZOKU_SYAIN(_D014.BUMON_KB, Context.ENM_SYONIN_HOKOKUSYO_ID._5_ZESEI.Value, ENM_ZESEI_STAGE._40_処置結果レビュー)
                cmbST04_SAKUSEI_TANTO.SetDataSource(dt, ENM_COMBO_SELECT_VALUE_TYPE._0_Required)
            End If

            If intStageID >= ENM_ZESEI_STAGE._40_処置結果レビュー Then
                'pnlST03.Enabled = False

                If _D014.ZESEI_SYOCHI_HANTEI Then
                    rbtnZESEI_SYOCHI_YES.Checked = True
                Else
                    rbtnZESEI_SYOCHI_NO.Checked = True
                End If

#Region "           承認担当者"

                dt = FunGetSYONIN_SYOZOKU_SYAIN(_D014.BUMON_KB, Context.ENM_SYONIN_HOKOKUSYO_ID._5_ZESEI.Value, ENM_ZESEI_STAGE._41_処置結果レビュー_点検)
                cmbST04_TENKEN_TANTO.SetDataSource(dt, ENM_COMBO_SELECT_VALUE_TYPE._0_Required)
                dt = FunGetSYONIN_SYOZOKU_SYAIN(_D014.BUMON_KB, Context.ENM_SYONIN_HOKOKUSYO_ID._5_ZESEI.Value, ENM_ZESEI_STAGE._42_処置結果レビュー_認可)
                cmbST04_NINKA_TANTO.SetDataSource(dt, ENM_COMBO_SELECT_VALUE_TYPE._0_Required)

                V003 = _V003_SYONIN_J_KANRI_List.AsEnumerable.Where(Function(r) r.SYONIN_JUN = ENM_ZESEI_STAGE._40_処置結果レビュー).FirstOrDefault
                If V003 IsNot Nothing Then
                    cmbST04_SAKUSEI_TANTO.SelectedValue = V003.SYAIN_ID
                    dtST04_SAKUSEI_YMD.Text = V003.SYONIN_YMDHNS.ToDateTimeWithFormat("yyyyMMddHHmmss", "yyyy/MM/dd")
                End If

                V003 = _V003_SYONIN_J_KANRI_List.AsEnumerable.Where(Function(r) r.SYONIN_JUN = ENM_ZESEI_STAGE._41_処置結果レビュー_点検).FirstOrDefault
                If V003 IsNot Nothing Then
                    cmbST04_TENKEN_TANTO.SelectedValue = V003.SYAIN_ID
                    dtST04_TENKEN_YMD.Text = V003.SYONIN_YMDHNS.ToDateTimeWithFormat("yyyyMMddHHmmss", "yyyy/MM/dd")
                End If

                V003 = _V003_SYONIN_J_KANRI_List.AsEnumerable.Where(Function(r) r.SYONIN_JUN = ENM_ZESEI_STAGE._42_処置結果レビュー_認可).FirstOrDefault
                If V003 IsNot Nothing Then
                    cmbST04_NINKA_TANTO.SelectedValue = V003.SYAIN_ID
                    dtST04_NINKA_YMD.Text = V003.SYONIN_YMDHNS.ToDateTimeWithFormat("yyyyMMddHHmmss", "yyyy/MM/dd")
                End If

#End Region

#Region "           差し戻し理由"

                _V003List = _V003_SYONIN_J_KANRI_List.AsEnumerable.
                        Where(Function(r) r.SYONIN_JUN >= ENM_ZESEI_STAGE._40_処置結果レビュー And r.SYONIN_JUN < ENM_ZESEI_STAGE._50_要求元完了確認).ToList

                If _V003List.Count > 0 Then
                    V003 = _V003List.Where(Function(r) r.SASIMODOSI_FG And r.RIYU.ToString.Trim.IsNulOrWS).
                                                    OrderBy(Function(r) r.SYONIN_JUN).
                                                    FirstOrDefault

                    If V003 IsNot Nothing Then
                        lblST04_Modoshi_Riyu.Text = $"差戻理由：{V003.RIYU}"
                    Else
                        lblST04_Modoshi_Riyu.Text = ""
                    End If
                End If

#End Region

            End If

            If intStageID >= ENM_ZESEI_STAGE._42_処置結果レビュー_認可 Then
                pnlST05.Visible = True
                dt = FunGetSYONIN_SYOZOKU_SYAIN(_D014.BUMON_KB, Context.ENM_SYONIN_HOKOKUSYO_ID._5_ZESEI.Value, ENM_ZESEI_STAGE._50_要求元完了確認)
                cmbST05_SAKUSEI_TANTO.SetDataSource(dt, ENM_COMBO_SELECT_VALUE_TYPE._0_Required)
            End If

            If intStageID >= ENM_ZESEI_STAGE._50_要求元完了確認 Then
                'pnlST04.Enabled = False

#Region "           承認担当者"

                dt = FunGetSYONIN_SYOZOKU_SYAIN(_D014.BUMON_KB, Context.ENM_SYONIN_HOKOKUSYO_ID._5_ZESEI.Value, ENM_ZESEI_STAGE._51_要求元完了確認_点検)
                cmbST05_TENKEN_TANTO.SetDataSource(dt, ENM_COMBO_SELECT_VALUE_TYPE._0_Required)
                dt = FunGetSYONIN_SYOZOKU_SYAIN(_D014.BUMON_KB, Context.ENM_SYONIN_HOKOKUSYO_ID._5_ZESEI.Value, ENM_ZESEI_STAGE._52_要求元完了確認_認可)
                cmbST05_NINKA_TANTO.SetDataSource(dt, ENM_COMBO_SELECT_VALUE_TYPE._0_Required)

                V003 = _V003_SYONIN_J_KANRI_List.AsEnumerable.Where(Function(r) r.SYONIN_JUN = ENM_ZESEI_STAGE._50_要求元完了確認).FirstOrDefault
                If V003 IsNot Nothing Then
                    cmbST05_SAKUSEI_TANTO.SelectedValue = V003.SYAIN_ID
                    dtST05_SAKUSEI_YMD.Text = V003.SYONIN_YMDHNS.ToDateTimeWithFormat("yyyyMMddHHmmss", "yyyy/MM/dd")
                End If

                V003 = _V003_SYONIN_J_KANRI_List.AsEnumerable.Where(Function(r) r.SYONIN_JUN = ENM_ZESEI_STAGE._51_要求元完了確認_点検).FirstOrDefault
                If V003 IsNot Nothing Then
                    cmbST05_TENKEN_TANTO.SelectedValue = V003.SYAIN_ID
                    dtST05_TENKEN_YMD.Text = V003.SYONIN_YMDHNS.ToDateTimeWithFormat("yyyyMMddHHmmss", "yyyy/MM/dd")
                End If

                V003 = _V003_SYONIN_J_KANRI_List.AsEnumerable.Where(Function(r) r.SYONIN_JUN = ENM_ZESEI_STAGE._52_要求元完了確認_認可).FirstOrDefault
                If V003 IsNot Nothing Then
                    cmbST05_NINKA_TANTO.SelectedValue = V003.SYAIN_ID
                    dtST05_NINKA_YMD.Text = V003.SYONIN_YMDHNS.ToDateTimeWithFormat("yyyyMMddHHmmss", "yyyy/MM/dd")
                End If

#End Region

#Region "           差し戻し理由"

                _V003List = _V003_SYONIN_J_KANRI_List.AsEnumerable.
                        Where(Function(r) r.SYONIN_JUN >= ENM_ZESEI_STAGE._50_要求元完了確認 And r.SYONIN_JUN <= ENM_ZESEI_STAGE._52_要求元完了確認_認可).ToList

                If _V003List.Count > 0 Then
                    V003 = _V003List.Where(Function(r) r.SASIMODOSI_FG And r.RIYU.ToString.Trim.IsNulOrWS).
                                                        OrderBy(Function(r) r.SYONIN_JUN).
                                                        FirstOrDefault

                    If V003 IsNot Nothing Then
                        lblST05_Modoshi_Riyu.Text = $"差戻理由：{V003.RIYU}"
                    Else
                        lblST05_Modoshi_Riyu.Text = ""
                    End If
                End If

#End Region

            End If

            Return True
        Catch ex As Exception
            EM.ErrorSyori(ex, False, conblnNonMsg)
            Return False
        End Try
    End Function

    ''' <summary>
    ''' 担当者のデータソース情報をラベルに表示
    ''' </summary>
    ''' <returns></returns>
    Private Function SetTANTO_TooltipInfo() As Boolean

        Call SetInfoLabelFormat(lblTANTO, $"選択した部門・課の所属する担当者")

        Call SetInfoLabelFormat(lblST01_SAKUSEI_TANTO, $"社員業務グループマスタ{vbCr}以下の業務グループに登録された担当者{vbCrLf}{vbCrLf}QMS管理責任者・品証")
        Call SetInfoLabelFormat(lblST01_TENKEN_TANTO, $"承認担当者マスタ{vbCr}所属部門のST11.に登録された担当者")
        Call SetInfoLabelFormat(lblST01_NINKA_TANTO, $"承認担当者マスタ{vbCr}所属部門のST12.に登録された担当者")

        '是正処置(流出)では製造がない
        Call SetInfoLabelFormat(lblST02_SAKUSEI_TANTO, $"社員業務グループマスタ{vbCr}以下の業務グループに登録されたTL・GL{vbCrLf}{vbCrLf}技術・製造・管理・営業{vbCrLf}{vbCrLf}または承認担当者マスタのST20.に登録された担当者")
        Call SetInfoLabelFormat(lblST02_TENKEN_TANTO, $"社員業務グループマスタ{vbCr}以下の業務グループに登録されたTL・GL{vbCrLf}{vbCrLf}技術・製造・管理・営業{vbCrLf}{vbCrLf}または承認担当者マスタのST21.に登録された担当者")
        Call SetInfoLabelFormat(lblST02_NINKA_TANTO, $"承認担当者マスタ{vbCr}所属部門のST22.に登録された担当者")

        Call SetInfoLabelFormat(lblST03_SAKUSEI_TANTO, $"社員業務グループマスタ{vbCr}以下の業務グループに登録された担当者{vbCrLf}{vbCrLf}QMS管理責任者・品証")
        Call SetInfoLabelFormat(lblST03_TENKEN_TANTO, $"承認担当者マスタ{vbCr}所属部門のST31.に登録された担当者")
        Call SetInfoLabelFormat(lblST03_NINKA_TANTO, $"承認担当者マスタ{vbCr}所属部門のST32.に登録された担当者")

        Call SetInfoLabelFormat(lblST04_SAKUSEI_TANTO, $"社員業務グループマスタ{vbCr}以下の業務グループに登録された担当者{vbCrLf}{vbCrLf}QMS管理責任者・品証")
        Call SetInfoLabelFormat(lblST04_TENKEN_TANTO, $"承認担当者マスタ{vbCr}所属部門のST41.に登録された担当者")
        Call SetInfoLabelFormat(lblST04_NINKA_TANTO, $"承認担当者マスタ{vbCr}所属部門のST42.に登録された担当者")

        Call SetInfoLabelFormat(lblST05_SAKUSEI_TANTO, $"社員業務グループマスタ{vbCr}以下の業務グループに登録された担当者{vbCrLf}{vbCrLf}QMS管理責任者・品証")
        Call SetInfoLabelFormat(lblST05_TENKEN_TANTO, $"承認担当者マスタ{vbCr}所属部門のST51.に登録された担当者")
        Call SetInfoLabelFormat(lblST05_NINKA_TANTO, $"承認担当者マスタ{vbCr}所属部門のST52.に登録された担当者")

    End Function

    Private Function SetInfoLabelFormat(lbl As System.Windows.Forms.Label, caption As String) As Boolean
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

#Region "ヘッダ"

            Call cmbBUMON_Validated(cmbBUMON, Nothing)
            'all cmbKA_Validated(cmbKA, Nothing)
            Call cmbTANTO_Validated(cmbTANTO, Nothing)

#End Region

            If Not IsValidated Then Return False

            If enmSAVE_MODE = ENM_SAVE_MODE._2_承認申請 Then
                Select Case PrCurrentStage
                    Case ENM_ZESEI_STAGE._10_起草入力
                        Call dtKAITOU_KIBOU_YMD_Validating(dtKAITOU_KIBOU_YMD, Nothing)
                        Call CmbDestTANTO_SelectedvalueChanged(cmbTANTO, Nothing)
                        Call CmbDestTANTO_SelectedvalueChanged(cmbST01_SAKUSEI_TANTO, Nothing)
                        Call CmbDestTANTO_SelectedvalueChanged(cmbST01_TENKEN_TANTO, Nothing)
                    Case ENM_ZESEI_STAGE._11_起草入力_点検
                        Call CmbDestTANTO_SelectedvalueChanged(cmbST01_TENKEN_TANTO, Nothing)
                        Call CmbDestTANTO_SelectedvalueChanged(cmbST01_NINKA_TANTO, Nothing)
                    Case ENM_ZESEI_STAGE._12_起草入力_認可
                        Call CmbDestTANTO_SelectedvalueChanged(cmbST01_NINKA_TANTO, Nothing)
                        Call CmbDestTANTO_SelectedvalueChanged(cmbST02_SAKUSEI_TANTO, Nothing)

                        If chkJINTEKI_YOUIN_UMU.Checked Then

                        End If

                    Case ENM_ZESEI_STAGE._20_是正処置入力
                        Call dtKAITOU_KIBOU_YMD_Validating(dtKAITOU_YMD, Nothing)
                        Call CmbDestTANTO_SelectedvalueChanged(cmbST02_SAKUSEI_TANTO, Nothing)
                        Call CmbDestTANTO_SelectedvalueChanged(cmbST02_TENKEN_TANTO, Nothing)
                    Case ENM_ZESEI_STAGE._21_是正処置入力_点検
                        Call CmbDestTANTO_SelectedvalueChanged(cmbST02_TENKEN_TANTO, Nothing)
                        Call CmbDestTANTO_SelectedvalueChanged(cmbST02_NINKA_TANTO, Nothing)
                    Case ENM_ZESEI_STAGE._22_是正処置入力_認可
                        Call CmbDestTANTO_SelectedvalueChanged(cmbST02_NINKA_TANTO, Nothing)
                        Call CmbDestTANTO_SelectedvalueChanged(cmbST03_SAKUSEI_TANTO, Nothing)
                    Case ENM_ZESEI_STAGE._23_是正処置入力_品証_点検
                        Call CmbDestTANTO_SelectedvalueChanged(cmbST02_HINSYO_TENKEN_TANTO, Nothing)
                        Call CmbDestTANTO_SelectedvalueChanged(cmbST02_HINSYO_NINKA_TANTO, Nothing)
                    Case ENM_ZESEI_STAGE._24_是正処置入力_品証_認可
                        Call CmbDestTANTO_SelectedvalueChanged(cmbST02_HINSYO_NINKA_TANTO, Nothing)
                        Call CmbDestTANTO_SelectedvalueChanged(cmbST03_SAKUSEI_TANTO, Nothing)
                    Case ENM_ZESEI_STAGE._30_処置結果入力
                        Call CmbDestTANTO_SelectedvalueChanged(cmbST03_SAKUSEI_TANTO, Nothing)
                    Case ENM_ZESEI_STAGE._31_処置結果入力_点検
                        Call CmbDestTANTO_SelectedvalueChanged(cmbST03_TENKEN_TANTO, Nothing)
                    Case ENM_ZESEI_STAGE._32_処置結果入力_認可
                        Call CmbDestTANTO_SelectedvalueChanged(cmbST03_NINKA_TANTO, Nothing)
                    Case ENM_ZESEI_STAGE._40_処置結果レビュー
                        Call CmbDestTANTO_SelectedvalueChanged(cmbST04_SAKUSEI_TANTO, Nothing)
                    Case ENM_ZESEI_STAGE._41_処置結果レビュー_点検
                        Call CmbDestTANTO_SelectedvalueChanged(cmbST04_TENKEN_TANTO, Nothing)
                    Case ENM_ZESEI_STAGE._42_処置結果レビュー_認可
                        Call CmbDestTANTO_SelectedvalueChanged(cmbST04_NINKA_TANTO, Nothing)
                    Case ENM_ZESEI_STAGE._50_要求元完了確認
                        Call CmbDestTANTO_SelectedvalueChanged(cmbST05_SAKUSEI_TANTO, Nothing)
                    Case ENM_ZESEI_STAGE._51_要求元完了確認_点検
                        Call CmbDestTANTO_SelectedvalueChanged(cmbST05_TENKEN_TANTO, Nothing)
                    Case ENM_ZESEI_STAGE._52_要求元完了確認_認可
                        Call CmbDestTANTO_SelectedvalueChanged(cmbST05_NINKA_TANTO, Nothing)
                End Select

            End If

            '上記各種Validatingイベントでフラグを更新し、全てOKの場合はTrue
            Return IsValidated
        Catch ex As Exception
            Throw
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
        sbSQL.Append($"Select")
        sbSQL.Append($" {NameOf(V003_SYONIN_J_KANRI)}.*")
        sbSQL.Append($" FROM {NameOf(V003_SYONIN_J_KANRI)} ")
        sbSQL.Append($" WHERE {NameOf(V003_SYONIN_J_KANRI.SYONIN_HOKOKUSYO_ID)}={intSYONIN_HOKOKUSYO_ID}")
        sbSQL.Append($" And {NameOf(V003_SYONIN_J_KANRI.HOKOKU_NO)}='{strHOKOKU_NO.Trim}'")
        sbSQL.Append($" ORDER BY {NameOf(V003_SYONIN_J_KANRI.SYONIN_JUN)} DESC")
        Using DB As ClsDbUtility = DBOpen()
            dsList = DB.GetDataSet(sbSQL.ToString, conblnNonMsg)
        End Using

        With dsList.Tables(0)
            If .Rows.Count = 0 Then
                Return "ST01.起草"
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
    Private Function FunGetNextSYONIN_JUN(CurrentStageID As Integer) As Integer
        Try

            Select Case CurrentStageID
                Case ENM_ZESEI_STAGE._10_起草入力
                    Return ENM_ZESEI_STAGE._11_起草入力_点検
                Case ENM_ZESEI_STAGE._11_起草入力_点検
                    Return ENM_ZESEI_STAGE._12_起草入力_認可
                Case ENM_ZESEI_STAGE._12_起草入力_認可
                    Return ENM_ZESEI_STAGE._20_是正処置入力
                Case ENM_ZESEI_STAGE._20_是正処置入力
                    Return ENM_ZESEI_STAGE._21_是正処置入力_点検
                Case ENM_ZESEI_STAGE._21_是正処置入力_点検
                    Return ENM_ZESEI_STAGE._22_是正処置入力_認可
                Case ENM_ZESEI_STAGE._22_是正処置入力_認可
                    Dim stage As Integer
                    Dim IsHinsyo = FunGetSYOZOKU_SYAIN(cmbBUMON.SelectedValue).
                                    AsEnumerable.
                                    Any(Function(r) r.Item("GYOMU_GROUP_ID") = ENM_GYOMU_GROUP_ID._4_品証 And r.Item("VALUE") = cmbST02_SAKUSEI_TANTO.SelectedValue)

                    If IsHinsyo Then
                        stage = ENM_ZESEI_STAGE._30_処置結果入力
                    Else
                        stage = ENM_ZESEI_STAGE._23_是正処置入力_品証_点検
                    End If

                    Return stage
                Case ENM_ZESEI_STAGE._23_是正処置入力_品証_点検
                    Return ENM_ZESEI_STAGE._24_是正処置入力_品証_認可
                Case ENM_ZESEI_STAGE._24_是正処置入力_品証_認可
                    Return ENM_ZESEI_STAGE._30_処置結果入力
                Case ENM_ZESEI_STAGE._30_処置結果入力
                    Return ENM_ZESEI_STAGE._31_処置結果入力_点検
                Case ENM_ZESEI_STAGE._31_処置結果入力_点検
                    Return ENM_ZESEI_STAGE._32_処置結果入力_認可
                Case ENM_ZESEI_STAGE._32_処置結果入力_認可
                    Return ENM_ZESEI_STAGE._40_処置結果レビュー
                Case ENM_ZESEI_STAGE._40_処置結果レビュー
                    Return ENM_ZESEI_STAGE._41_処置結果レビュー_点検
                Case ENM_ZESEI_STAGE._41_処置結果レビュー_点検
                    Return ENM_ZESEI_STAGE._42_処置結果レビュー_認可
                Case ENM_ZESEI_STAGE._42_処置結果レビュー_認可
                    Return ENM_ZESEI_STAGE._50_要求元完了確認
                Case ENM_ZESEI_STAGE._50_要求元完了確認
                    Return ENM_ZESEI_STAGE._51_要求元完了確認_点検
                Case ENM_ZESEI_STAGE._51_要求元完了確認_点検
                    Return ENM_ZESEI_STAGE._52_要求元完了確認_認可
                Case ENM_ZESEI_STAGE._52_要求元完了確認_認可
                    Return ENM_ZESEI_STAGE._999_Closed
                Case Else
                    Return 0
            End Select
        Catch ex As Exception
            Throw
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

    ''' <summary>
    ''' ログインユーザーが承認or申請したステージか判定
    ''' </summary>
    ''' <param name="intSYONIN_HOKOKUSYO_ID">承認報告書ID</param>
    ''' <param name="strHOKOKU_NO">報告書No</param>
    ''' <param name="intSYONIN_JUN">承認順No</param>
    ''' <returns></returns>
    Public Function FunblnOwnCreated(ByVal intSYONIN_HOKOKUSYO_ID As Integer, ByVal strHOKOKU_NO As String, ByVal intSYONIN_JUN As Integer) As Boolean

        Try
            Dim cmb As ComboboxEx

            Select Case intSYONIN_JUN
                Case ENM_ZESEI_STAGE._10_起草入力
                    cmb = cmbST01_SAKUSEI_TANTO
                Case ENM_ZESEI_STAGE._11_起草入力_点検
                    cmb = cmbST01_TENKEN_TANTO
                Case ENM_ZESEI_STAGE._12_起草入力_認可
                    cmb = cmbST01_NINKA_TANTO
                Case ENM_ZESEI_STAGE._20_是正処置入力
                    cmb = cmbST02_SAKUSEI_TANTO
                Case ENM_ZESEI_STAGE._21_是正処置入力_点検
                    cmb = cmbST02_TENKEN_TANTO
                Case ENM_ZESEI_STAGE._22_是正処置入力_認可
                    cmb = cmbST02_NINKA_TANTO
                Case ENM_ZESEI_STAGE._23_是正処置入力_品証_点検
                    cmb = cmbST02_HINSYO_TENKEN_TANTO
                Case ENM_ZESEI_STAGE._24_是正処置入力_品証_認可
                    cmb = cmbST02_HINSYO_NINKA_TANTO
                Case ENM_ZESEI_STAGE._30_処置結果入力
                    cmb = cmbST03_SAKUSEI_TANTO
                Case ENM_ZESEI_STAGE._31_処置結果入力_点検
                    cmb = cmbST03_TENKEN_TANTO
                Case ENM_ZESEI_STAGE._32_処置結果入力_認可
                    cmb = cmbST03_NINKA_TANTO
                Case ENM_ZESEI_STAGE._40_処置結果レビュー
                    cmb = cmbST04_SAKUSEI_TANTO
                Case ENM_ZESEI_STAGE._41_処置結果レビュー_点検
                    cmb = cmbST04_TENKEN_TANTO
                Case ENM_ZESEI_STAGE._42_処置結果レビュー_認可
                    cmb = cmbST04_NINKA_TANTO
                Case ENM_ZESEI_STAGE._50_要求元完了確認
                    cmb = cmbST05_SAKUSEI_TANTO
                Case ENM_ZESEI_STAGE._51_要求元完了確認_点検
                    cmb = cmbST05_TENKEN_TANTO
                Case ENM_ZESEI_STAGE._52_要求元完了確認_認可
                    cmb = cmbST05_NINKA_TANTO
                Case Else

                    'close 済み　システム担当者のみ編集許可
                    Return False
            End Select
            Dim users = DirectCast(cmb.DataSource, DataTable)
            If users IsNot Nothing AndAlso users.Rows.Count > 0 Then
                Return users.AsEnumerable.Any(Function(r) r.Item("VALUE") = pub_SYAIN_INFO.SYAIN_ID)
            Else
                Return False
            End If
        Catch ex As Exception
            Throw
        End Try

    End Function

    Private Function IsNeedMeeting() As Boolean

        Dim sbSQL As New System.Text.StringBuilder
        Dim sqlEx As New Exception
        Dim intRET As Integer

        'sbSQL.Append($"SELECT")
        'sbSQL.Append($" COUNT({NameOf(D012.TANTO_ID)})")
        'sbSQL.Append($" FROM {NameOf(D012_FCCB_SUB_SYOCHI_KAKUNIN)} ")
        'sbSQL.Append($" WHERE {NameOf(D012.FCCB_NO)}='{_D009.FCCB_NO}' ")
        'sbSQL.Append($" AND {NameOf(D012.TANTO_ID)}<>0 ")
        'sbSQL.Append($" AND RTRIM({NameOf(D012.KYOGI_YOHI_KAITO)})='1' ")
        Using DB = DBOpen()
            intRET = DB.ExecuteScalar(sbSQL.ToString, conblnNonMsg, sqlEx).ToVal()
        End Using

        Return intRET > 0
    End Function

    ''' <summary>
    ''' 申請先社員IDを取得
    ''' </summary>
    ''' <param name="intCurrentStageID"></param>
    ''' <returns></returns>
    Private Function FunGetNextSYONIN_TANTO_ID(ByVal intCurrentStageID As Integer) As Integer
        Try
            Dim cmb As ComboboxEx = Nothing

            Select Case PrCurrentStage
                Case ENM_ZESEI_STAGE._10_起草入力
                    cmb = cmbST01_TENKEN_TANTO
                Case ENM_ZESEI_STAGE._11_起草入力_点検
                    cmb = cmbST01_NINKA_TANTO
                Case ENM_ZESEI_STAGE._12_起草入力_認可
                    cmb = cmbST02_SAKUSEI_TANTO
                Case ENM_ZESEI_STAGE._20_是正処置入力
                    cmb = cmbST02_TENKEN_TANTO
                Case ENM_ZESEI_STAGE._21_是正処置入力_点検
                    cmb = cmbST02_NINKA_TANTO
                Case ENM_ZESEI_STAGE._22_是正処置入力_認可
                    cmb = cmbST03_SAKUSEI_TANTO
                Case ENM_ZESEI_STAGE._23_是正処置入力_品証_点検
                    cmb = cmbST02_HINSYO_NINKA_TANTO
                Case ENM_ZESEI_STAGE._24_是正処置入力_品証_認可
                    cmb = cmbST03_SAKUSEI_TANTO
                Case ENM_ZESEI_STAGE._30_処置結果入力
                    cmb = cmbST03_TENKEN_TANTO
                Case ENM_ZESEI_STAGE._31_処置結果入力_点検
                    cmb = cmbST03_NINKA_TANTO
                Case ENM_ZESEI_STAGE._32_処置結果入力_認可
                    cmb = cmbST04_SAKUSEI_TANTO
                Case ENM_ZESEI_STAGE._40_処置結果レビュー
                    cmb = cmbST04_TENKEN_TANTO
                Case ENM_ZESEI_STAGE._41_処置結果レビュー_点検
                    cmb = cmbST04_NINKA_TANTO
                Case ENM_ZESEI_STAGE._42_処置結果レビュー_認可
                    cmb = cmbST05_SAKUSEI_TANTO
                Case ENM_ZESEI_STAGE._50_要求元完了確認
                    cmb = cmbST05_TENKEN_TANTO
                Case ENM_ZESEI_STAGE._51_要求元完了確認_点検
                    cmb = cmbST05_NINKA_TANTO
                Case ENM_ZESEI_STAGE._52_要求元完了確認_認可
                    cmb = Nothing
            End Select

            If cmb IsNot Nothing Then
                Return cmb.SelectedValue
            Else
                Return 0
            End If
        Catch ex As Exception
            Throw
        End Try
    End Function

#End Region

#Region "添付ファイル"

#Region "1"

    '添付ファイル選択
    Private Sub BtnOpenTempFileDialog_Click(sender As Object, e As EventArgs) Handles btnOpenTempFileDialog.Click
        Dim ofd As New OpenFileDialog With {
            .Filter = "すべてのファイル(*.*)|*.*|Excel(*.xls;*.xlsx)|*.xls;*.xlsx|Word(*.doc;*.docx)|*.doc;*.docx",
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

            _D014.FILE_PATH1 = IO.Path.GetFileName(ofd.FileName)
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
    Private Sub LbltmpFile1_Clear_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles lbltmpFile1_Clear.LinkClicked
        lbltmpFile1.Text = ""
        _D014.FILE_PATH1 = ""
        lbltmpFile1.Links.Clear()
        lbltmpFile1.Visible = False
        lbltmpFile1_Clear.Visible = False
    End Sub

#End Region

#Region "2"

    '添付ファイル選択
    Private Sub BtnOpenTempFileDialog2_Click(sender As Object, e As EventArgs) Handles btnOpenTempFileDialog2.Click
        Dim ofd As New OpenFileDialog With {
            .Filter = "すべてのファイル(*.*)|*.*|Excel(*.xls;*.xlsx)|*.xls;*.xlsx|Word(*.doc;*.docx)|*.doc;*.docx",
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

            _D014.FILE_PATH2 = IO.Path.GetFileName(ofd.FileName)
            lbltmpFile2.Visible = True
            lbltmpFile2_Clear.Visible = True
        End If
    End Sub

    'リンククリック
    Private Sub LbltmpFile2_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles lbltmpFile2.LinkClicked
        Dim hProcess As New System.Diagnostics.Process
        Dim strEXE As String

        Try

            strEXE = lbltmpFile2.Links(0).LinkData
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
            '-----開放
            If hProcess IsNot Nothing Then
                hProcess.Close()
            End If
        End Try
    End Sub

    'リンククリア
    Private Sub LbltmpFile2_Clear_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles lbltmpFile2_Clear.LinkClicked
        lbltmpFile2.Text = ""
        _D014.FILE_PATH2 = ""
        lbltmpFile2.Links.Clear()
        lbltmpFile2.Visible = False
        lbltmpFile2_Clear.Visible = False
    End Sub

#End Region

#Region "3"

    '添付ファイル選択
    Private Sub BtnOpenTempFileDialog3_Click(sender As Object, e As EventArgs) Handles btnOpenTempFileDialog3.Click
        Dim ofd As New OpenFileDialog With {
            .Filter = "すべてのファイル(*.*)|*.*|Excel(*.xls;*.xlsx)|*.xls;*.xlsx|Word(*.doc;*.docx)|*.doc;*.docx",
            .FilterIndex = 1,
            .Title = "添付するファイルを選択してください",
            .RestoreDirectory = True
        }
        If lbltmpFile3.Links.Count = 0 Then
        Else
            ofd.InitialDirectory = IO.Path.GetDirectoryName(lbltmpFile3.Links(0).ToString)
        End If
        If ofd.ShowDialog() = DialogResult.OK Then
            lbltmpFile3.Text = IO.Path.GetFileName(ofd.FileName)
            lbltmpFile3.Links.Clear()
            lbltmpFile3.Links.Add(0, lbltmpFile3.Text.Length, ofd.FileName)

            _D014.FILE_PATH3 = IO.Path.GetFileName(ofd.FileName)
            lbltmpFile3.Visible = True
            lbltmpFile3_Clear.Visible = True
        End If
    End Sub

    'リンククリック
    Private Sub LbltmpFile3_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles lbltmpFile3.LinkClicked
        Dim hProcess As New System.Diagnostics.Process
        Dim strEXE As String
        Try

            strEXE = lbltmpFile3.Links(0).LinkData
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

            '-----開放
            If hProcess IsNot Nothing Then
                hProcess.Close()
            End If
        End Try
    End Sub

    'リンククリア
    Private Sub LbltmpFile3_Clear_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles lbltmpFile3_Clear.LinkClicked
        lbltmpFile3.Text = ""
        _D014.FILE_PATH3 = ""
        lbltmpFile3.Links.Clear()
        lbltmpFile3.Visible = False
        lbltmpFile3_Clear.Visible = False
    End Sub

#End Region

#Region "4"

    '添付ファイル選択
    Private Sub BtnOpenTempFileDialog4_Click(sender As Object, e As EventArgs) Handles btnOpenTempFileDialog4.Click
        Dim ofd As New OpenFileDialog With {
            .Filter = "すべてのファイル(*.*)|*.*|Excel(*.xls;*.xlsx)|*.xls;*.xlsx|Word(*.doc;*.docx)|*.doc;*.docx",
            .FilterIndex = 1,
            .Title = "添付するファイルを選択してください",
            .RestoreDirectory = True
        }
        If lbltmpFile4.Links.Count = 0 Then
        Else
            ofd.InitialDirectory = IO.Path.GetDirectoryName(lbltmpFile4.Links(0).ToString)
        End If
        If ofd.ShowDialog() = DialogResult.OK Then
            lbltmpFile4.Text = IO.Path.GetFileName(ofd.FileName)
            lbltmpFile4.Links.Clear()
            lbltmpFile4.Links.Add(0, lbltmpFile4.Text.Length, ofd.FileName)

            _D014.FILE_PATH4 = IO.Path.GetFileName(ofd.FileName)
            lbltmpFile4.Visible = True
            lbltmpFile4_Clear.Visible = True
        End If
    End Sub

    'リンククリック
    Private Sub LbltmpFile4_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles lbltmpFile4.LinkClicked
        Dim hProcess As New System.Diagnostics.Process
        Dim strEXE As String
        Try

            strEXE = lbltmpFile4.Links(0).LinkData
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

            '-----開放
            If hProcess IsNot Nothing Then
                hProcess.Close()
            End If
        End Try
    End Sub

    'リンククリア
    Private Sub LbltmpFile4_Clear_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles lbltmpFile4_Clear.LinkClicked
        lbltmpFile4.Text = ""
        _D014.FILE_PATH4 = ""
        lbltmpFile4.Links.Clear()
        lbltmpFile4.Visible = False
        lbltmpFile4_Clear.Visible = False
    End Sub

#End Region

#Region "5"

    '添付ファイル選択
    Private Sub BtnOpenTempFileDialog5_Click(sender As Object, e As EventArgs) Handles btnOpenTempFileDialog5.Click
        Dim ofd As New OpenFileDialog With {
            .Filter = "すべてのファイル(*.*)|*.*|Excel(*.xls;*.xlsx)|*.xls;*.xlsx|Word(*.doc;*.docx)|*.doc;*.docx",
            .FilterIndex = 1,
            .Title = "添付するファイルを選択してください",
            .RestoreDirectory = True
        }
        If lbltmpFile5.Links.Count = 0 Then
        Else
            ofd.InitialDirectory = IO.Path.GetDirectoryName(lbltmpFile5.Links(0).ToString)
        End If
        If ofd.ShowDialog() = DialogResult.OK Then
            lbltmpFile5.Text = IO.Path.GetFileName(ofd.FileName)
            lbltmpFile5.Links.Clear()
            lbltmpFile5.Links.Add(0, lbltmpFile5.Text.Length, ofd.FileName)

            _D014.FILE_PATH5 = IO.Path.GetFileName(ofd.FileName)
            lbltmpFile5.Visible = True
            lbltmpFile5_Clear.Visible = True
        End If
    End Sub

    'リンククリック
    Private Sub LbltmpFile5_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles lbltmpFile5.LinkClicked
        Dim hProcess As New System.Diagnostics.Process
        Dim strEXE As String
        'Dim strARG As String
        Try

            strEXE = lbltmpFile5.Links(0).LinkData
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
    Private Sub LbltmpFile5_Clear_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles lbltmpFile5_Clear.LinkClicked
        lbltmpFile5.Text = ""
        _D014.FILE_PATH5 = ""
        lbltmpFile5.Links.Clear()
        lbltmpFile5.Visible = False
        lbltmpFile5_Clear.Visible = False
    End Sub

#End Region

#End Region

End Class