Imports System.Threading.Tasks
Imports JMS_COMMON.ClsPubMethod
Imports MODEL

''' <summary>
''' CAR登録画面
''' </summary>
Public Class FrmG0021

#Region "定数・変数"

    Private _V002_NCR_J As New V002_NCR_J
    Private _V003_SYONIN_J_KANRI_List As New List(Of V003_SYONIN_J_KANRI)
    Private _V011_FCR_J As New V011_FCR_J

    '入力必須コントロール検証判定
    Private IsValidated As Boolean

    Private _tabPageManager As TabPageManager

    Private IsEditingClosed As Boolean

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
    End Sub

#End Region

#Region "Form関連"

    'Loadイベント
    Private Async Sub FrmLoad(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        Try
            Me.Visible = False
            PrRIYU = ""
            Await Task.Run(
                Sub()
                    Me.Invoke(
                    Sub()
                        '-----フォーム初期設定(親フォームから呼び出し)
                        Call FunFormCommonSetting(pub_APP_INFO, pub_SYAIN_INFO, My.Application.Info.Version.ToString)
                        Using DB As ClsDbUtility = DBOpen()
                            lblTytle.Text = FunGetCodeMastaValue(DB, "PG_TITLE", Me.GetType.ToString)
                        End Using

                        '--- モデルクリア
                        _D004_SYONIN_J_KANRI.clear()

                        '-----コントロールデータソース設定
                        cmbKOKYAKU_EIKYO_HANTEI_COMMENT.SetDataSource(tblKOKYAKU_EIKYO_COMMENT, ENM_COMBO_SELECT_VALUE_TYPE._2_Option)
                        Dim dt = tblKISYU.AsEnumerable.Where(Function(r) r.Field(Of String)(NameOf(_D003_NCR_J.BUMON_KB)) = PrDataRow.Item("BUMON_KB")).CopyToDataTable
                        cmbKISYU1.SetDataSource(dt, ENM_COMBO_SELECT_VALUE_TYPE._2_Option)
                        cmbKISYU2.SetDataSource(dt, ENM_COMBO_SELECT_VALUE_TYPE._2_Option)
                        cmbKISYU3.SetDataSource(dt, ENM_COMBO_SELECT_VALUE_TYPE._2_Option)
                        cmbKISYU4.SetDataSource(dt, ENM_COMBO_SELECT_VALUE_TYPE._2_Option)
                        cmbKISYU5.SetDataSource(dt, ENM_COMBO_SELECT_VALUE_TYPE._2_Option)
                        cmbKISYU6.SetDataSource(dt, ENM_COMBO_SELECT_VALUE_TYPE._2_Option)

                        '-----画面初期化
                        Call FunInitializeControls()

                        AddHandler rbtnKOKYAKU_EIKYO_HANTEI_KB_T.CheckedChanged, AddressOf RbtnSEKKEI_TANTO_YOHI_YES_CheckedChanged
                        AddHandler rbtnKOKYAKU_EIKYO_HANTEI_KB_F.CheckedChanged, AddressOf RbtnSEKKEI_TANTO_YOHI_NO_CheckedChanged

                        Me.tabSTAGE01.Focus()
                    End Sub)
                End Sub)
        Finally
            FunInitFuncButtonEnabled()
            Me.Visible = True
            Me.WindowState = Me.Owner.WindowState
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
                        If IsEditingClosed And PrCurrentStage = ENM_NCR_STAGE._999_Closed Then

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
                    TabSTAGE.SelectedIndex = 6

                    '入力チェック
                    If FunCheckInput(ENM_SAVE_MODE._2_承認申請) Then
                        If MessageBox.Show("申請しますか？", "承認・申請処理確認", MessageBoxButtons.YesNo, MessageBoxIcon.Information) = DialogResult.Yes Then
                            If FunSAVE(ENM_SAVE_MODE._2_承認申請) Then

                                Dim strMsg As String
                                If PrCurrentStage = ENM_NCR_STAGE._120_abcde処置確認 Then
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

                Case 10  '印刷

                    Call FunOpenReportCAR()

                Case 11 '履歴
                    Call OpenFormHistory(Context.ENM_SYONIN_HOKOKUSYO_ID._2_CAR, _V011_FCR_J.HOKOKU_NO)

                Case 12 '閉じる
                    Me.Close()
                Case Else
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
                    If FunSAVE_FILE(DB) = False Then blnErr = True : Return False

                    If Not blnTENSO And PrCurrentStage < ENM_FCR_STAGE._999_Closed Then
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

#Region "   CAR添付ファイル保存"

    ''' <summary>
    ''' CAR添付ファイル保存
    ''' </summary>
    ''' <param name="DB"></param>
    ''' <returns></returns>
    Private Function FunSAVE_FILE(ByRef DB As ClsDbUtility) As Boolean

        If _D005_CAR_J.KYOIKU_FILE_PATH.IsNulOrWS And
            _D005_CAR_J.SYOSAI_FILE_PATH.IsNulOrWS And
            _D005_CAR_J.FILE_PATH1.IsNulOrWS And
            _D005_CAR_J.FILE_PATH2.IsNulOrWS Then
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
                    System.IO.Directory.CreateDirectory(strRootDir & _D005_CAR_J.HOKOKU_NO)
                    If Not _D005_CAR_J.KYOIKU_FILE_PATH.IsNulOrWS AndAlso
                        Not System.IO.File.Exists(strRootDir & _D005_CAR_J.HOKOKU_NO.Trim & "\" & _D005_CAR_J.KYOIKU_FILE_PATH) Then

                        'If System.IO.File.Exists(lblKYOIKU_FILE_PATH.Links.Item(0).LinkData) Then
                        '    System.IO.File.Copy(lblKYOIKU_FILE_PATH.Links.Item(0).LinkData, strRootDir & _D005_CAR_J.HOKOKU_NO.Trim & "\" & _D005_CAR_J.KYOIKU_FILE_PATH, True)
                        'Else
                        '    Throw New IO.FileNotFoundException($"教育記録リンク:{lblKYOIKU_FILE_PATH.Links.Item(0).LinkData}が見つかりません。元の場所に戻すか選択し直してください")
                        'End If
                    End If
                    If Not _D005_CAR_J.SYOSAI_FILE_PATH.IsNulOrWS AndAlso
                        Not System.IO.File.Exists(strRootDir & _D005_CAR_J.HOKOKU_NO.Trim & "\" & _D005_CAR_J.SYOSAI_FILE_PATH) Then

                        'If System.IO.File.Exists(lblSYOSAI_FILE_PATH.Links.Item(0).LinkData) Then
                        '    System.IO.File.Copy(lblSYOSAI_FILE_PATH.Links.Item(0).LinkData, strRootDir & _D005_CAR_J.HOKOKU_NO.Trim & "\" & _D005_CAR_J.SYOSAI_FILE_PATH, True)
                        'Else
                        '    Throw New IO.FileNotFoundException($"是正処置詳細資料:{lblSYOSAI_FILE_PATH.Links.Item(0).LinkData}が見つかりません。元の場所に戻すか選択し直してください")
                        'End If
                    End If
                    If Not _D005_CAR_J.FILE_PATH1.IsNulOrWS AndAlso
                        Not System.IO.File.Exists(strRootDir & _D005_CAR_J.HOKOKU_NO.Trim & "\" & _D005_CAR_J.FILE_PATH1) Then

                        'If System.IO.File.Exists(lbltmpFile1.Links.Item(0).LinkData) Then
                        '    System.IO.File.Copy(lbltmpFile1.Links.Item(0).LinkData, strRootDir & _D005_CAR_J.HOKOKU_NO.Trim & "\" & _D005_CAR_J.FILE_PATH1, True)
                        'Else
                        '    Throw New IO.FileNotFoundException($"添付ファイル1:{lbltmpFile1.Links.Item(0).LinkData}が見つかりません。元の場所に戻すか選択し直してください")
                        'End If
                    End If
                    If Not _D005_CAR_J.FILE_PATH2.IsNulOrWS AndAlso
                        Not System.IO.File.Exists(strRootDir & _D005_CAR_J.HOKOKU_NO.Trim & "\" & _D005_CAR_J.FILE_PATH2) Then

                        'If System.IO.File.Exists(lbltmpFile2.Links.Item(0).LinkData) Then
                        '    System.IO.File.Copy(lbltmpFile2.Links.Item(0).LinkData, strRootDir & _D005_CAR_J.HOKOKU_NO.Trim & "\" & _D005_CAR_J.FILE_PATH2, True)
                        'Else
                        '    Throw New IO.FileNotFoundException($"添付ファイル2:{lbltmpFile2.Links.Item(0).LinkData}が見つかりません。元の場所に戻すか選択し直してください")
                        'End If
                    End If

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

        Dim _D007 As New D007_FCR_J
        _D007.Clear()
        _D007.HOKOKU_NO = mtxHOKUKO_NO.Text
        If PrCurrentStage = ENM_FCR_STAGE._60_品証課長 And enmSAVE_MODE = ENM_SAVE_MODE._2_承認申請 Then
            _D007._CLOSE_FG = 1
        End If
        _D007._KOKYAKU_EIKYO_HANTEI_KB = If(rbtnKOKYAKU_EIKYO_HANTEI_KB_T.Checked, "1", "0")
        _D007.TAISYOU_KOKYAKU = txtTAISYO_KOKYAKU.Text
        _D007.KOKYAKU_EIKYO_ETC_COMMENT = cmbKOKYAKU_EIKYO_HANTEI_COMMENT.Text
        _D007.KOKYAKU_EIKYO_NAIYO = txtKOKYAKU_EIKYO_NAIYO.Text
        _D007.KAKUNIN_SYUDAN = txtKAKUNIN_SYUDAN.Text
        _D007._KOKYAKU_EIKYO_TUCHI_HANTEI_KB = If(rbtnKOKYAKU_EIKYO_TUCHI_HANTEI_KB_T.Checked, "1", "0")
        _D007.TUCHI_YMD = dtTUCHI_YMD.ValueNonFormat
        _D007.TUCHI_SYUDAN = txtTUCHI_SYUDAN.Text
        _D007.HITUYO_TETUDUKI_ZIKO = txtHITUYO_TETUDUKI_ZIKO.Text
        _D007.KOKYAKU_EIKYO_ETC_COMMENT = txtKOKYAKU_EIKYO_ETC_COMMENT.Text
        _D007._OTHER_PROCESS_INFLUENCE_KB = If(rbtnOTHER_PROCESS_INFLUENCE_KB_T.Checked, "1", "0")
        _D007._FOLLOW_PROCESS_OUTFLOW_KB = If(rbtnFOLLOW_PROCESS_OUTFLOW_KB_T.Checked, "1", "0")
        _D007.KOKYAKU_NOUNYU_NAIYOU = txtKOKYAKU_NOUNYU_NAIYOU.Text
        _D007.KOKYAKU_NOUNYU_YMD = dtKOKYAKU_NOUNYU_YMD.ValueNonFormat
        _D007.ZAIKO_SIKAKE_NAIYOU = txtZAIKO_SIKAKE_NAIYOU.Text
        _D007.ZAIKO_SIKAKE_YMD = dtZAIKO_SIKAKE_YMD.ValueNonFormat
        _D007.OTHER_PROCESS_NAIYOU = txtOTHER_PROCESS_NAIYOU.Text
        _D007.OTHER_PROCESS_YMD = dtOTHER_PROCESS_YMD.ValueNonFormat
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
        sbSQL.Append($"  SrcT.{NameOf(_D007.CLOSE_FG)} = WK.{NameOf(_D007.CLOSE_FG)}")
        sbSQL.Append($" ,SrcT.{NameOf(_D007.KOKYAKU_EIKYO_HANTEI_KB)} = WK.{NameOf(_D007.KOKYAKU_EIKYO_HANTEI_KB)}")
        sbSQL.Append($" ,SrcT.{NameOf(_D007.TAISYOU_KOKYAKU)} = WK.{NameOf(_D007.TAISYOU_KOKYAKU)}")
        sbSQL.Append($" ,SrcT.{NameOf(_D007.KOKYAKU_EIKYO_HANTEI_COMMENT)} = WK.{NameOf(_D007.KOKYAKU_EIKYO_HANTEI_COMMENT)}")
        sbSQL.Append($" ,SrcT.{NameOf(_D007.KOKYAKU_EIKYO_NAIYO)} = WK.{NameOf(_D007.KOKYAKU_EIKYO_NAIYO)}")
        sbSQL.Append($" ,SrcT.{NameOf(_D007.KAKUNIN_SYUDAN)} = WK.{NameOf(_D007.KAKUNIN_SYUDAN)}")
        sbSQL.Append($" ,SrcT.{NameOf(_D007.KOKYAKU_EIKYO_TUCHI_HANTEI_KB)} = WK.{NameOf(_D007.KOKYAKU_EIKYO_TUCHI_HANTEI_KB)}")
        sbSQL.Append($" ,SrcT.{NameOf(_D007.TUCHI_YMD)} = WK.{NameOf(_D007.TUCHI_YMD)}")
        sbSQL.Append($" ,SrcT.{NameOf(_D007.TUCHI_SYUDAN)} = WK.{NameOf(_D007.TUCHI_SYUDAN)}")
        sbSQL.Append($" ,SrcT.{NameOf(_D007.HITUYO_TETUDUKI_ZIKO)} = WK.{NameOf(_D007.HITUYO_TETUDUKI_ZIKO)}")
        sbSQL.Append($" ,SrcT.{NameOf(_D007.KOKYAKU_EIKYO_ETC_COMMENT)} = WK.{NameOf(_D007.KOKYAKU_EIKYO_ETC_COMMENT)}")
        sbSQL.Append($" ,SrcT.{NameOf(_D007.OTHER_PROCESS_INFLUENCE_KB)} = WK.{NameOf(_D007.OTHER_PROCESS_INFLUENCE_KB)}")
        sbSQL.Append($" ,SrcT.{NameOf(_D007.FOLLOW_PROCESS_OUTFLOW_KB)} = WK.{NameOf(_D007.FOLLOW_PROCESS_OUTFLOW_KB)}")
        sbSQL.Append($" ,SrcT.{NameOf(_D007.KOKYAKU_NOUNYU_NAIYOU)} = WK.{NameOf(_D007.KOKYAKU_NOUNYU_NAIYOU)}")
        sbSQL.Append($" ,SrcT.{NameOf(_D007.KOKYAKU_NOUNYU_YMD)} = WK.{NameOf(_D007.KOKYAKU_NOUNYU_YMD)}")
        sbSQL.Append($" ,SrcT.{NameOf(_D007.ZAIKO_SIKAKE_NAIYOU)} = WK.{NameOf(_D007.ZAIKO_SIKAKE_NAIYOU)}")
        sbSQL.Append($" ,SrcT.{NameOf(_D007.ZAIKO_SIKAKE_YMD)} = WK.{NameOf(_D007.ZAIKO_SIKAKE_YMD)}")
        sbSQL.Append($" ,SrcT.{NameOf(_D007.OTHER_PROCESS_NAIYOU)} = WK.{NameOf(_D007.OTHER_PROCESS_NAIYOU)}")
        sbSQL.Append($" ,SrcT.{NameOf(_D007.OTHER_PROCESS_YMD)} = WK.{NameOf(_D007.OTHER_PROCESS_YMD)}")
        sbSQL.Append($" ,SrcT.{NameOf(_D007.UPD_SYAIN_ID)} = WK.{NameOf(_D007.UPD_SYAIN_ID)}")
        sbSQL.Append($" ,SrcT.{NameOf(_D007.UPD_YMDHNS)} = WK.{NameOf(_D007.UPD_YMDHNS)}")
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

#Region "D008"
    Private Function FunSAVE_D008(ByRef DB As ClsDbUtility, ByVal enmSAVE_MODE As ENM_SAVE_MODE) As Boolean
        Dim sbSQL As New System.Text.StringBuilder
        Dim strRET As String
        Dim sqlEx As New Exception
        Dim strSysDate As String = DB.GetSysDateString

        Dim _D008 As New D008_FCR_J_SUB

#Region "Section1"

#End Region

#Region "   モデル更新"
        If cmbKISYU1.IsSelected Then
            _D008.Clear()
            _D008.HOKOKU_NO = mtxHOKUKO_NO.Text
            _D008.ROW_NO = 1
            _D008.KISYU_ID = cmbKISYU1.SelectedValue
            _D008.BUHIN_INFO = txtBUHIN_INFO1.Text
            _D008.SURYO = nupSURYO1.Value
            _D008.RANGE_FROM = txtFROM1.Text
            _D008.RANGE_TO = txtTO1.Text
            _D008.ADD_YMDHNS = strSysDate
            _D008.ADD_SYAIN_ID = pub_SYAIN_INFO.SYAIN_ID
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
        WL.WriteLogDat($"[DEBUG]CAR 報告書NO:{_D007.HOKOKU_NO}、MERGE D007")

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
        '-----データモデル更新
        _D004_SYONIN_J_KANRI.SYONIN_HOKOKUSYO_ID = Context.ENM_SYONIN_HOKOKUSYO_ID._3_FCR
        _D004_SYONIN_J_KANRI.HOKOKU_NO = _V011_FCR_J.HOKOKU_NO
        _D004_SYONIN_J_KANRI.MAIL_SEND_FG = True
        _D004_SYONIN_J_KANRI.ADD_SYAIN_ID = pub_SYAIN_INFO.SYAIN_ID
        _D004_SYONIN_J_KANRI.ADD_YMDHNS = strSysDate

        If PrCurrentStage = ENM_FCR_STAGE._10_起草入力 Then
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

        '-----承認申請
        Select Case enmSAVE_MODE
            Case ENM_SAVE_MODE._1_保存
                '保存実績のみ
                Return True
            Case ENM_SAVE_MODE._2_承認申請
                _D004_SYONIN_J_KANRI.SYONIN_JUN = FunGetNextSYONIN_JUN(PrCurrentStage)
                _D004_SYONIN_J_KANRI.SYAIN_ID = cmbDestTANTO.SelectedValue
                _D004_SYONIN_J_KANRI.SYONIN_YMDHNS = ""
                _D004_SYONIN_J_KANRI.MAIL_SEND_FG = False
                _D004_SYONIN_J_KANRI.SYONIN_HANTEI_KB = ENM_SYONIN_HANTEI_KB._0_未承認

            Case Else
                'Err
                Return False
        End Select

        '-----モデル更新
        Select Case PrCurrentStage
            Case ENM_FCR_STAGE._60_品証課長
                _D004_SYONIN_J_KANRI.SYONIN_JUN = 999 'Close
                _D004_SYONIN_J_KANRI.SYONIN_HANTEI_KB = ENM_SYONIN_HANTEI_KB._1_承認
                _D004_SYONIN_J_KANRI.SYONIN_YMDHNS = strSysDate
        End Select
        _D004_SYONIN_J_KANRI.ADD_YMDHNS = strSysDate

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
                If PrCurrentStage < ENM_FCR_STAGE._60_品証課長 AndAlso _D004_SYONIN_J_KANRI.MAIL_SEND_FG = False Then
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

        Return True
    End Function

#End Region

#Region "承認依頼メール送信"

    ''' <summary>
    ''' 承認依頼メール送信
    ''' </summary>
    ''' <returns></returns>
    Private Function FunSendRequestMail()
        Dim KISYU_NAME As String = _V011_FCR_J.KISYU_NAME
        Dim SYONIN_HANTEI_NAME As String = tblSYONIN_HANTEI_KB.AsEnumerable.Where(Function(r) r.Field(Of String)("VALUE") = _D004_SYONIN_J_KANRI.SYONIN_HANTEI_KB).FirstOrDefault?.Item("DISP")
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
                                DateTime.ParseExact(_V011_FCR_J.ADD_YMD, "yyyyMMdd", Nothing).ToString("yyyy/MM/dd"),
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
        _R001_HOKOKU_SOUSA.SYONIN_HOKOKUSYO_ID = Context.ENM_SYONIN_HOKOKUSYO_ID._3_FCR
        _R001_HOKOKU_SOUSA.HOKOKU_NO = _V011_FCR_J.HOKOKU_NO
        _R001_HOKOKU_SOUSA.SYONIN_JUN = PrCurrentStage
        _R001_HOKOKU_SOUSA.SYAIN_ID = pub_SYAIN_INFO.SYAIN_ID
        _R001_HOKOKU_SOUSA.RIYU = PrRIYU
        'UNDONE: getsysdatetime
        _R001_HOKOKU_SOUSA.ADD_YMDHNS = strSysDate 'Now.ToString("yyyyMMddHHmmss")

        Select Case enmSAVE_MODE
            Case ENM_SAVE_MODE._1_保存

                If PrCurrentStage = ENM_FCR_STAGE._999_Closed Then
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

        Return True
    End Function

    Private Function FunSAVE_R005(ByRef DB As ClsDbUtility, ByVal strYMDHNS As String) As Boolean
        Dim sbSQL As New System.Text.StringBuilder
        Dim intRET As Integer
        Dim sqlEx As New Exception

        sbSQL.Append($"INSERT(")
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
        sbSQL.Append($" ) VALUES(")
        sbSQL.Append($" '{strYMDHNS}'")
        sbSQL.Append($",{NameOf(_R005.HOKOKU_NO)}")
        sbSQL.Append($",'{_D007.HOKOKU_NO}'")
        sbSQL.Append($",'{_D007.CLOSE_FG}'")
        sbSQL.Append($",'{_D007.KOKYAKU_EIKYO_HANTEI_KB}'")
        sbSQL.Append($",'{_D007.TAISYOU_KOKYAKU}'")
        sbSQL.Append($",'{_D007.KOKYAKU_EIKYO_HANTEI_COMMENT}'")
        sbSQL.Append($",'{_D007.KOKYAKU_EIKYO_NAIYO}'")
        sbSQL.Append($",'{_D007.KAKUNIN_SYUDAN}'")
        sbSQL.Append($",'{_D007.KOKYAKU_EIKYO_TUCHI_HANTEI_KB}'")
        sbSQL.Append($",'{_D007.TUCHI_YMD}'")
        sbSQL.Append($",'{_D007.TUCHI_SYUDAN}'")
        sbSQL.Append($",'{_D007.HITUYO_TETUDUKI_ZIKO}'")
        sbSQL.Append($",'{_D007.KOKYAKU_EIKYO_ETC_COMMENT}'")
        sbSQL.Append($",'{_D007.OTHER_PROCESS_INFLUENCE_KB}'")
        sbSQL.Append($",'{_D007.FOLLOW_PROCESS_OUTFLOW_KB}'")
        sbSQL.Append($",'{_D007.KOKYAKU_NOUNYU_NAIYOU}'")
        sbSQL.Append($",'{_D007.KOKYAKU_NOUNYU_YMD}'")
        sbSQL.Append($",'{_D007.ZAIKO_SIKAKE_NAIYOU}'")
        sbSQL.Append($",'{_D007.ZAIKO_SIKAKE_YMD}'")
        sbSQL.Append($",'{_D007.OTHER_PROCESS_NAIYOU}'")
        sbSQL.Append($",'{_D007.OTHER_PROCESS_YMD}'")
        sbSQL.Append(" );")
        intRET = DB.ExecuteNonQuery(sbSQL.ToString, conblnNonMsg, sqlEx)
        If intRET <> 1 Then
            '-----エラーログ出力
            Dim strErrMsg As String = My.Resources.ErrLogSqlExecutionFailure & sbSQL.ToString & "|" & sqlEx.Message
            WL.WriteLogDat(strErrMsg)
            Return False
        Else
            WL.WriteLogDat($"[DEBUG]CTS 報告書NO:{_D005_CAR_J.HOKOKU_NO}、INSERT R005")
            Return True
        End If
    End Function

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
            sbSQL.Append($" AND {NameOf(V007_NCR_CAR.HOKOKU_NO)}='{_D005_CAR_J.HOKOKU_NO}'")
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

#Region "転送"

    Private Function OpenFormTENSO() As Boolean
        Dim frmDLG As New FrmG0015
        Dim dlgRET As DialogResult

        Try
            frmDLG.PrSYONIN_HOKOKUSYO_ID = Context.ENM_SYONIN_HOKOKUSYO_ID._2_CAR
            frmDLG.PrHOKOKU_NO = _D005_CAR_J.HOKOKU_NO
            frmDLG.PrBUMON_KB = _V002_NCR_J.BUMON_KB
            frmDLG.PrBUHIN_BANGO = _V002_NCR_J.BUHIN_BANGO
            frmDLG.PrKISO_YMD = DateTime.ParseExact(_V002_NCR_J.ADD_YMD, "yyyyMMdd", Nothing).ToString("yyyy/MM/dd")
            frmDLG.PrKISYU_NAME = tblKISYU.AsEnumerable.Where(Function(r) r.Field(Of Integer)("VALUE") = _V002_NCR_J.KISYU_ID).FirstOrDefault?.Item("DISP")
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
            frmDLG.PrSYONIN_HOKOKUSYO_ID = Context.ENM_SYONIN_HOKOKUSYO_ID._2_CAR
            frmDLG.PrHOKOKU_NO = _D005_CAR_J.HOKOKU_NO
            frmDLG.PrBUHIN_BANGO = _V002_NCR_J.BUHIN_BANGO
            frmDLG.PrKISO_YMD = DateTime.ParseExact(_V002_NCR_J.ADD_YMD, "yyyyMMdd", Nothing).ToString("yyyy/MM/dd")
            frmDLG.PrKISYU_NAME = tblKISYU.AsEnumerable.Where(Function(r) r.Field(Of Integer)("VALUE") = _V002_NCR_J.KISYU_ID).FirstOrDefault?.Item("DISP")
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

    Private Function FunOpenReportCAR() As Boolean
        Dim strOutputFileName As String
        Dim strTEMPFILE As String
        'Dim intRET As Integer

        Try
            Me.Cursor = Cursors.WaitCursor

            'ファイル名
            strOutputFileName = "CAR_" & _D005_CAR_J.HOKOKU_NO & "_Work.xls"

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
            If FunMakeReportFCR(pub_APP_INFO.strOUTPUT_PATH & strOutputFileName, _D005_CAR_J.HOKOKU_NO) = False Then
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

    Private Function FunMakeReportFCR(ByVal strFilePath As String, ByVal strHOKOKU_NO As String) As Boolean

        Dim spWorkbook As SpreadsheetGear.IWorkbook
        Dim spWorksheets As SpreadsheetGear.IWorksheets
        Dim spSheet1 As SpreadsheetGear.IWorksheet
        Dim spRangeFrom As SpreadsheetGear.IRange
        Dim spRangeTo As SpreadsheetGear.IRange
        Dim ssgShapes As SpreadsheetGear.Shapes.IShapes
        Try
            spWorkbook = SpreadsheetGear.Factory.GetWorkbook(strFilePath, System.Globalization.CultureInfo.CurrentCulture)

            spWorkbook.WorkbookSet.GetLock()
            spWorksheets = spWorkbook.Worksheets
            spSheet1 = spWorksheets.Item(0) 'sheet1

            Dim spprint As SpreadsheetGear.Printing.PrintWhat = SpreadsheetGear.Printing.PrintWhat.Sheet

            Dim shLINE_KOKYAKU_EIKYO_NAIYO As SpreadsheetGear.Shapes.IShape = Nothing
            Dim shLINE_KAKUNIN_SYUDAN As SpreadsheetGear.Shapes.IShape = Nothing
            Dim shLINE_TUCHI As SpreadsheetGear.Shapes.IShape = Nothing
            Dim shLINE_KOKYAKU_EIKYO_ETC_COMMENT As SpreadsheetGear.Shapes.IShape = Nothing
            Dim shLINE_KISYU1 As SpreadsheetGear.Shapes.IShape = Nothing
            Dim shLINE_RANGE1 As SpreadsheetGear.Shapes.IShape = Nothing
            Dim shLINE_KISYU2 As SpreadsheetGear.Shapes.IShape = Nothing
            Dim shLINE_RANGE2 As SpreadsheetGear.Shapes.IShape = Nothing
            Dim shLINE_NAIYO As SpreadsheetGear.Shapes.IShape = Nothing
            Dim shLINE_YMD As SpreadsheetGear.Shapes.IShape = Nothing
            Dim shSCR_KOKYAKU_EIKYO_HANTEI_KB_T As SpreadsheetGear.Shapes.IShape = Nothing
            Dim shSCR_KOKYAKU_EIKYO_HANTEI_KB_F As SpreadsheetGear.Shapes.IShape = Nothing
            Dim shSCR_KOKYAKU_EIKYO_TUCHI_HANTEI_KB_T As SpreadsheetGear.Shapes.IShape = Nothing
            Dim shSCR_KOKYAKU_EIKYO_TUCHI_HANTEI_KB_F As SpreadsheetGear.Shapes.IShape = Nothing
            Dim shSCR_OTHER_PROCESS_INFLUENCE_KB_T As SpreadsheetGear.Shapes.IShape = Nothing
            Dim shSCR_OTHER_PROCESS_INFLUENCE_KB_F As SpreadsheetGear.Shapes.IShape = Nothing
            Dim shSCR_FOLLOW_PROCESS_OUTFLOW_KB_T As SpreadsheetGear.Shapes.IShape = Nothing
            Dim shSCR_FOLLOW_PROCESS_OUTFLOW_KB_F As SpreadsheetGear.Shapes.IShape = Nothing

            Dim strYMDHNS As String
            ssgShapes = spSheet1.Shapes
            For Each shape As SpreadsheetGear.Shapes.IShape In ssgShapes
                Select Case shape.Name
                    Case "LINE_KOKYAKU_EIKYO_NAIYO"
                        shLINE_KOKYAKU_EIKYO_NAIYO = shape
                    Case "LINE_KAKUNIN_SYUDAN"
                        shLINE_KAKUNIN_SYUDAN = shape
                    Case "LINE_TUCHI"
                        shLINE_TUCHI = shape
                    Case "LINE_KOKYAKU_EIKYO_ETC_COMMENT"
                        shLINE_KOKYAKU_EIKYO_ETC_COMMENT = shape
                    Case "LINE_KISYU1"
                        shLINE_KISYU1 = shape
                    Case "LINE_RANGE1"
                        shLINE_RANGE1 = shape
                    Case "LINE_KISYU2"
                        shLINE_KISYU2 = shape
                    Case "LINE_RANGE2"
                        shLINE_RANGE2 = shape
                    Case "LINE_NAIYO"
                        shLINE_NAIYO = shape
                    Case "LINE_YMD"
                        shLINE_YMD = shape
                    Case "SCR_KOKYAKU_EIKYO_HANTEI_KB_T"
                        shSCR_KOKYAKU_EIKYO_HANTEI_KB_T = shape
                    Case "SCR_KOKYAKU_EIKYO_HANTEI_KB_F"
                        shSCR_KOKYAKU_EIKYO_HANTEI_KB_F = shape
                    Case "SCR_KOKYAKU_EIKYO_TUCHI_HANTEI_KB_T"
                        shSCR_KOKYAKU_EIKYO_TUCHI_HANTEI_KB_T = shape
                    Case "SCR_KOKYAKU_EIKYO_TUCHI_HANTEI_KB_F"
                        shSCR_KOKYAKU_EIKYO_TUCHI_HANTEI_KB_F = shape
                    Case "SCR_OTHER_PROCESS_INFLUENCE_KB_T"
                        shSCR_OTHER_PROCESS_INFLUENCE_KB_T = shape
                    Case "SCR_OTHER_PROCESS_INFLUENCE_KB_F"
                        shSCR_OTHER_PROCESS_INFLUENCE_KB_F = shape
                    Case "SCR_FOLLOW_PROCESS_OUTFLOW_KB_T"
                        shSCR_FOLLOW_PROCESS_OUTFLOW_KB_T = shape
                    Case "SCR_FOLLOW_PROCESS_OUTFLOW_KB_F"
                        shSCR_FOLLOW_PROCESS_OUTFLOW_KB_F = shape
                End Select
            Next shape

            'レコードフレーム初期化

            Dim _V11 As V011_FCR_J = FunGetV011Model(strHOKOKU_NO)
            Dim _V003_SYONIN_J_KANRI_List As List(Of V003_SYONIN_J_KANRI) = FunGetV003Model(Context.ENM_SYONIN_HOKOKUSYO_ID._3_FCR, strHOKOKU_NO)

            spSheet1.Range(NameOf(V011_FCR_J.HOKOKU_NO)).Value = _V11.HOKOKU_NO
            spSheet1.Range(NameOf(V011_FCR_J.TAISYOU_KOKYAKU)).Value = _V11.TAISYOU_KOKYAKU
            spSheet1.Range(NameOf(V011_FCR_J.KOKYAKU_EIKYO_HANTEI_COMMENT)).Value = _V11.KOKYAKU_EIKYO_HANTEI_COMMENT

            Dim blnHANTEI As Boolean = (_V11.KOKYAKU_EIKYO_HANTEI_KB = "1")
            shSCR_KOKYAKU_EIKYO_HANTEI_KB_T.Visible = blnHANTEI
            shSCR_KOKYAKU_EIKYO_HANTEI_KB_F.Visible = Not blnHANTEI
            shLINE_KOKYAKU_EIKYO_NAIYO.Visible = Not blnHANTEI
            shLINE_KAKUNIN_SYUDAN.Visible = Not blnHANTEI
            shLINE_TUCHI.Visible = Not blnHANTEI
            shLINE_KOKYAKU_EIKYO_ETC_COMMENT.Visible = Not blnHANTEI
            shLINE_KISYU1.Visible = Not blnHANTEI
            shLINE_KISYU2.Visible = Not blnHANTEI
            shLINE_RANGE1.Visible = Not blnHANTEI
            shLINE_RANGE2.Visible = Not blnHANTEI
            shLINE_NAIYO.Visible = Not blnHANTEI
            shLINE_YMD.Visible = Not blnHANTEI

            shSCR_OTHER_PROCESS_INFLUENCE_KB_T.Visible = (_V11.OTHER_PROCESS_INFLUENCE_KB = "1")
            shSCR_OTHER_PROCESS_INFLUENCE_KB_F.Visible = Not (_V11.OTHER_PROCESS_INFLUENCE_KB = "1")
            shSCR_FOLLOW_PROCESS_OUTFLOW_KB_T.Visible = (_V11.FOLLOW_PROCESS_OUTFLOW_KB = "1")
            shSCR_FOLLOW_PROCESS_OUTFLOW_KB_F.Visible = Not (_V11.FOLLOW_PROCESS_OUTFLOW_KB = "1")

            spSheet1.Range(NameOf(V011_FCR_J.KOKYAKU_EIKYO_NAIYO)).Value = _V11.KOKYAKU_EIKYO_NAIYO
            spSheet1.Range(NameOf(V011_FCR_J.KAKUNIN_SYUDAN)).Value = _V11.KAKUNIN_SYUDAN
            spSheet1.Range(NameOf(V011_FCR_J.KOKYAKU_EIKYO_ETC_COMMENT)).Value = _V11.KOKYAKU_EIKYO_ETC_COMMENT
            spSheet1.Range(NameOf(V011_FCR_J.KISYU1_NAME)).Value = _V11.KISYU1_NAME
            spSheet1.Range(NameOf(V011_FCR_J.KISYU2_NAME)).Value = _V11.KISYU2_NAME
            spSheet1.Range(NameOf(V011_FCR_J.KISYU3_NAME)).Value = _V11.KISYU3_NAME
            spSheet1.Range(NameOf(V011_FCR_J.KISYU4_NAME)).Value = _V11.KISYU4_NAME
            spSheet1.Range(NameOf(V011_FCR_J.KISYU5_NAME)).Value = _V11.KISYU5_NAME
            spSheet1.Range(NameOf(V011_FCR_J.KISYU6_NAME)).Value = _V11.KISYU6_NAME
            spSheet1.Range(NameOf(V011_FCR_J.BUHIN_INFO1)).Value = _V11.BUHIN_INFO1
            spSheet1.Range(NameOf(V011_FCR_J.BUHIN_INFO2)).Value = _V11.BUHIN_INFO2
            spSheet1.Range(NameOf(V011_FCR_J.BUHIN_INFO3)).Value = _V11.BUHIN_INFO3
            spSheet1.Range(NameOf(V011_FCR_J.BUHIN_INFO4)).Value = _V11.BUHIN_INFO4
            spSheet1.Range(NameOf(V011_FCR_J.BUHIN_INFO5)).Value = _V11.BUHIN_INFO5
            spSheet1.Range(NameOf(V011_FCR_J.BUHIN_INFO6)).Value = _V11.BUHIN_INFO6
            spSheet1.Range(NameOf(V011_FCR_J.SURYO1)).Value = _V11.SURYO1
            spSheet1.Range(NameOf(V011_FCR_J.SURYO2)).Value = _V11.SURYO2
            spSheet1.Range(NameOf(V011_FCR_J.SURYO3)).Value = _V11.SURYO3
            spSheet1.Range(NameOf(V011_FCR_J.SURYO4)).Value = _V11.SURYO4
            spSheet1.Range(NameOf(V011_FCR_J.SURYO5)).Value = _V11.SURYO5
            spSheet1.Range(NameOf(V011_FCR_J.SURYO6)).Value = _V11.SURYO6
            spSheet1.Range(NameOf(V011_FCR_J.RANGE_FROM1)).Value = _V11.RANGE_FROM1
            spSheet1.Range(NameOf(V011_FCR_J.RANGE_FROM2)).Value = _V11.RANGE_FROM2
            spSheet1.Range(NameOf(V011_FCR_J.RANGE_FROM3)).Value = _V11.RANGE_FROM3
            spSheet1.Range(NameOf(V011_FCR_J.RANGE_FROM4)).Value = _V11.RANGE_FROM4
            spSheet1.Range(NameOf(V011_FCR_J.RANGE_FROM5)).Value = _V11.RANGE_FROM5
            spSheet1.Range(NameOf(V011_FCR_J.RANGE_FROM6)).Value = _V11.RANGE_FROM6
            spSheet1.Range(NameOf(V011_FCR_J.RANGE_TO1)).Value = _V11.RANGE_TO1
            spSheet1.Range(NameOf(V011_FCR_J.RANGE_TO2)).Value = _V11.RANGE_TO2
            spSheet1.Range(NameOf(V011_FCR_J.RANGE_TO3)).Value = _V11.RANGE_TO3
            spSheet1.Range(NameOf(V011_FCR_J.RANGE_TO4)).Value = _V11.RANGE_TO4
            spSheet1.Range(NameOf(V011_FCR_J.RANGE_TO5)).Value = _V11.RANGE_TO5
            spSheet1.Range(NameOf(V011_FCR_J.RANGE_TO6)).Value = _V11.RANGE_TO6
            spSheet1.Range(NameOf(V011_FCR_J.KOKYAKU_NOUNYU_NAIYOU)).Value = _V11.KOKYAKU_NOUNYU_NAIYOU
            spSheet1.Range(NameOf(V011_FCR_J.KOKYAKU_NOUNYU_YMD)).Value = _V11.KOKYAKU_NOUNYU_YMD
            spSheet1.Range(NameOf(V011_FCR_J.ZAIKO_SIKAKE_NAIYOU)).Value = _V11.ZAIKO_SIKAKE_NAIYOU
            spSheet1.Range(NameOf(V011_FCR_J.ZAIKO_SIKAKE_YMD)).Value = _V11.ZAIKO_SIKAKE_YMD
            spSheet1.Range(NameOf(V011_FCR_J.OTHER_PROCESS_NAIYOU)).Value = _V11.OTHER_PROCESS_NAIYOU
            spSheet1.Range(NameOf(V011_FCR_J.OTHER_PROCESS_YMD)).Value = _V11.OTHER_PROCESS_YMD

            strYMDHNS = _V003_SYONIN_J_KANRI_List.Where(Function(r) r.SYONIN_JUN = ENM_FCR_STAGE._10_起草入力 And r.SYONIN_HANTEI_KB = ENM_SYONIN_HANTEI_KB._1_承認).FirstOrDefault?.SYONIN_YMDHNS
            If Not strYMDHNS.IsNulOrWS Then
                spSheet1.Range("SYONIN_YMD" & ENM_FCR_STAGE._10_起草入力).Value = DateTime.ParseExact(strYMDHNS, "yyyyMMddHHmmss", Nothing).ToString("yyyy/MM/dd")
                spSheet1.Range("SYONIN_NAME" & ENM_FCR_STAGE._10_起草入力).Value = _V003_SYONIN_J_KANRI_List.Where(Function(r) r.SYONIN_JUN = ENM_FCR_STAGE._10_起草入力).FirstOrDefault?.UPD_SYAIN_NAME
            End If

            strYMDHNS = _V003_SYONIN_J_KANRI_List.Where(Function(r) r.SYONIN_JUN = ENM_FCR_STAGE._20_品証_検査 And r.SYONIN_HANTEI_KB = ENM_SYONIN_HANTEI_KB._1_承認).FirstOrDefault?.SYONIN_YMDHNS
            If Not strYMDHNS.IsNulOrWS Then
                spSheet1.Range("SYONIN_YMD" & ENM_FCR_STAGE._20_品証_検査).Value = DateTime.ParseExact(strYMDHNS, "yyyyMMddHHmmss", Nothing).ToString("yyyy/MM/dd")
                spSheet1.Range("SYONIN_NAME" & ENM_FCR_STAGE._20_品証_検査).Value = _V003_SYONIN_J_KANRI_List.Where(Function(r) r.SYONIN_JUN = ENM_FCR_STAGE._20_品証_検査).FirstOrDefault?.UPD_SYAIN_NAME
            End If

            strYMDHNS = _V003_SYONIN_J_KANRI_List.Where(Function(r) r.SYONIN_JUN = ENM_FCR_STAGE._30_管理TL And r.SYONIN_HANTEI_KB = ENM_SYONIN_HANTEI_KB._1_承認).FirstOrDefault?.SYONIN_YMDHNS
            If Not strYMDHNS.IsNulOrWS Then
                spSheet1.Range("SYONIN_YMD" & ENM_FCR_STAGE._30_管理TL).Value = DateTime.ParseExact(strYMDHNS, "yyyyMMddHHmmss", Nothing).ToString("yyyy/MM/dd")
                spSheet1.Range("SYONIN_NAME" & ENM_FCR_STAGE._30_管理TL).Value = _V003_SYONIN_J_KANRI_List.Where(Function(r) r.SYONIN_JUN = ENM_FCR_STAGE._30_管理TL).FirstOrDefault?.UPD_SYAIN_NAME
            End If

            strYMDHNS = _V003_SYONIN_J_KANRI_List.Where(Function(r) r.SYONIN_JUN = ENM_FCR_STAGE._40_生技TL And r.SYONIN_HANTEI_KB = ENM_SYONIN_HANTEI_KB._1_承認).FirstOrDefault?.SYONIN_YMDHNS
            If Not strYMDHNS.IsNulOrWS Then
                spSheet1.Range("SYONIN_YMD" & ENM_FCR_STAGE._40_生技TL).Value = DateTime.ParseExact(strYMDHNS, "yyyyMMddHHmmss", Nothing).ToString("yyyy/MM/dd")
                spSheet1.Range("SYONIN_NAME" & ENM_FCR_STAGE._40_生技TL).Value = _V003_SYONIN_J_KANRI_List.Where(Function(r) r.SYONIN_JUN = ENM_FCR_STAGE._40_生技TL).FirstOrDefault?.UPD_SYAIN_NAME
            End If

            strYMDHNS = _V003_SYONIN_J_KANRI_List.Where(Function(r) r.SYONIN_JUN = ENM_FCR_STAGE._50_営業TL And r.SYONIN_HANTEI_KB = ENM_SYONIN_HANTEI_KB._1_承認).FirstOrDefault?.SYONIN_YMDHNS
            If Not strYMDHNS.IsNulOrWS Then
                spSheet1.Range("SYONIN_YMD" & ENM_FCR_STAGE._50_営業TL).Value = DateTime.ParseExact(strYMDHNS, "yyyyMMddHHmmss", Nothing).ToString("yyyy/MM/dd")
                spSheet1.Range("SYONIN_NAME" & ENM_FCR_STAGE._50_営業TL).Value = _V003_SYONIN_J_KANRI_List.Where(Function(r) r.SYONIN_JUN = ENM_FCR_STAGE._50_営業TL).FirstOrDefault?.UPD_SYAIN_NAME
            End If

            strYMDHNS = _V003_SYONIN_J_KANRI_List.Where(Function(r) r.SYONIN_JUN = ENM_FCR_STAGE._60_品証課長 And r.SYONIN_HANTEI_KB = ENM_SYONIN_HANTEI_KB._1_承認).FirstOrDefault?.SYONIN_YMDHNS
            If Not strYMDHNS.IsNulOrWS Then
                spSheet1.Range("SYONIN_YMD" & ENM_FCR_STAGE._60_品証課長).Value = DateTime.ParseExact(strYMDHNS, "yyyyMMddHHmmss", Nothing).ToString("yyyy/MM/dd")
                spSheet1.Range("SYONIN_NAME" & ENM_FCR_STAGE._60_品証課長).Value = _V003_SYONIN_J_KANRI_List.Where(Function(r) r.SYONIN_JUN = ENM_FCR_STAGE._60_品証課長).FirstOrDefault?.UPD_SYAIN_NAME
            End If

            '-----ファイル保存
            spSheet1.SaveAs(filename:=strFilePath, fileFormat:=SpreadsheetGear.FileFormat.Excel8)
            spWorkbook.WorkbookSet.ReleaseLock()

            ''-----Spire版 直接PDF発行するならこっち
            'Dim workbook As New Spire.Xls.Workbook
            'workbook.LoadFromFile(strFilePath)
            'Dim pdfFilePath As String
            'pdfFilePath = System.IO.Path.GetDirectoryName(strFilePath) & "\" & System.IO.Path.GetFileNameWithoutExtension(strFilePath) & ".pdf"
            'workbook.SaveToFile(pdfFilePath, Spire.Xls.FileFormat.PDF)
            '''PDF表示
            'System.Diagnostics.Process.Start(pdfFilePath)

            Call FunOpenWorkbook(strFilePath)

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
            frmDLG.PrKISYU_NAME = tblKISYU.AsEnumerable.Where(Function(r) r.Field(Of Integer)("VALUE") = _D003_NCR_J.KISYU_ID).FirstOrDefault?.Item("DISP")
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

            If FunblnOwnCreated(Context.ENM_SYONIN_HOKOKUSYO_ID._3_FCR, PrHOKOKU_NO, PrCurrentStage) Then '
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
            Else
                cmdFunc3.Enabled = False
                MyBase.ToolTip.SetToolTip(Me.cmdFunc3, "既にNCR画面から呼び出されているため使用出来ません")
            End If

            If PrCurrentStage = ENM_FCR_STAGE._999_Closed Then

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
                                                                        rsbtnST06.CheckedChanged

        Dim btn As RibbonShapeRadioButton = DirectCast(sender, RibbonShapeRadioButton)
        Dim intStageID As Integer = Val(btn.Name.Substring(7))
        tabSTAGE01.AutoScrollControlIntoView = True
        Select Case intStageID
            Case ENM_CAR_STAGE2._1_起草入力 To ENM_CAR_STAGE2._7_起草確認_品証課長
                tabSTAGE01.ScrollControlIntoView(lblSETUMON_1)

                pnlFCR.BorderStyle = BorderStyle.FixedSingle
                pnlSYOCHI_KIROKU.BorderStyle = BorderStyle.None
                pnlZESEI_SYOCHI.BorderStyle = BorderStyle.None
                pnlSYOCHI_JISSI.BorderStyle = BorderStyle.None

            Case ENM_CAR_STAGE2._8_処置実施記録入力, ENM_CAR_STAGE2._9_処置実施確認
                tabSTAGE01.ScrollControlIntoView(lblSYOCHI_KIROKUFlame)

                pnlFCR.BorderStyle = BorderStyle.None
                pnlSYOCHI_KIROKU.BorderStyle = BorderStyle.FixedSingle
                pnlZESEI_SYOCHI.BorderStyle = BorderStyle.None
                pnlSYOCHI_JISSI.BorderStyle = BorderStyle.None

            Case ENM_CAR_STAGE2._10_是正有効性記入 To ENM_CAR_STAGE2._12_是正有効性確認_品証TL
                tabSTAGE01.ScrollControlIntoView(lblZESEI_SYOCHIFlame)

                pnlFCR.BorderStyle = BorderStyle.None
                pnlSYOCHI_KIROKU.BorderStyle = BorderStyle.None
                pnlZESEI_SYOCHI.BorderStyle = BorderStyle.FixedSingle
                pnlSYOCHI_JISSI.BorderStyle = BorderStyle.None

            Case ENM_CAR_STAGE2._13_是正有効性確認_品証担当課長
                tabSTAGE01.ScrollControlIntoView(lblSTAGEFlame13)
                pnlFCR.BorderStyle = BorderStyle.None
                pnlSYOCHI_KIROKU.BorderStyle = BorderStyle.None
                pnlZESEI_SYOCHI.BorderStyle = BorderStyle.None
                pnlSYOCHI_JISSI.BorderStyle = BorderStyle.FixedSingle

        End Select
        tabSTAGE01.AutoScrollControlIntoView = False

    End Sub

    Private Sub tabSTAGE01_Click(sender As Object, e As EventArgs) Handles tabSTAGE01.Click
        sender.Focus
    End Sub

    Private Sub RbtnSEKKEI_TANTO_YOHI_YES_CheckedChanged(sender As Object, e As EventArgs) 'Handles rbtnSEKKEI_TANTO_YOHI_YES.CheckedChanged
        _D005_CAR_J._KAITO_23 = 1
        'mtxNextStageName.Text = FunGetStageName(Context.ENM_SYONIN_HOKOKUSYO_ID._2_CAR, FunGetNextSYONIN_JUN(PrCurrentStage))
        'Dim dt As DataTable = FunGetSYONIN_SYOZOKU_SYAIN(_V002_NCR_J.BUMON_KB, Context.ENM_SYONIN_HOKOKUSYO_ID._2_CAR, FunGetNextSYONIN_JUN(PrCurrentStage))
        'cmbDestTANTO.SetDataSource(dt, ENM_COMBO_SELECT_VALUE_TYPE._0_Required)
    End Sub

    Private Sub RbtnSEKKEI_TANTO_YOHI_NO_CheckedChanged(sender As Object, e As EventArgs) 'Handles rbtnSEKKEI_TANTO_YOHI_NO.CheckedChanged
        _D005_CAR_J._KAITO_23 = 0
        'mtxNextStageName.Text = FunGetStageName(Context.ENM_SYONIN_HOKOKUSYO_ID._2_CAR, FunGetNextSYONIN_JUN(PrCurrentStage))
        'Dim dt As DataTable = FunGetSYONIN_SYOZOKU_SYAIN(_V002_NCR_J.BUMON_KB, Context.ENM_SYONIN_HOKOKUSYO_ID._2_CAR, FunGetNextSYONIN_JUN(PrCurrentStage))
        'cmbDestTANTO.SetDataSource(dt, ENM_COMBO_SELECT_VALUE_TYPE._0_Required)
    End Sub

    Private Sub ChkSEKKEI_TANTO_YOHI_KB_CheckedChanged(sender As Object, e As EventArgs)
        'If chkSEKKEI_TANTO_YOHI_KB.Checked Then
        '    rbtnSEKKEI_TANTO_YOHI_YES.Checked = True
        'Else
        '    rbtnSEKKEI_TANTO_YOHI_NO.Checked = True
        'End If

    End Sub



#End Region

    Private Sub RbtnKOKYAKU_EIKYO_HANTEI_KB_CheckedChanged(sender As Object, e As EventArgs) Handles rbtnKOKYAKU_EIKYO_HANTEI_KB_T.CheckedChanged, rbtnKOKYAKU_EIKYO_HANTEI_KB_F.CheckedChanged

        Dim blnChecked As Boolean = rbtnKOKYAKU_EIKYO_HANTEI_KB_T.Checked

        If blnChecked Then
            cmbKOKYAKU_EIKYO_HANTEI_COMMENT.SelectedIndex = 0
        End If
        lblKOKYAKU_EIKYO_HANTEI_COMMENT.Visible = Not blnChecked
        cmbKOKYAKU_EIKYO_HANTEI_COMMENT.Visible = Not blnChecked

        txtKOKYAKU_EIKYO_NAIYO.Enabled = blnChecked
        txtKAKUNIN_SYUDAN.Enabled = blnChecked
        rbtnKOKYAKU_EIKYO_TUCHI_HANTEI_KB_T.Checked = False
        dtTUCHI_YMD.Enabled = blnChecked
        txtTUCHI_SYUDAN.Enabled = blnChecked
        txtHITUYO_TETUDUKI_ZIKO.Enabled = blnChecked
        txtKOKYAKU_EIKYO_ETC_COMMENT.Enabled = blnChecked

        txtKOKYAKU_EIKYO_NAIYO.Text = ""
        txtKAKUNIN_SYUDAN.Text = ""
        dtTUCHI_YMD.Value = ""
        txtTUCHI_SYUDAN.Text = ""
        txtHITUYO_TETUDUKI_ZIKO.Text = ""
        txtKOKYAKU_EIKYO_ETC_COMMENT.Text = ""

        pnlrbtnTUCHI.DisableContaints(blnChecked, PanelEx.ENM_PROPERTY._1_Enabled)
        pnlSYOCHI_KIROKU.DisableContaints(blnChecked, PanelEx.ENM_PROPERTY._1_Enabled)
        pnlZESEI_SYOCHI.DisableContaints(blnChecked, PanelEx.ENM_PROPERTY._1_Enabled)
        PnlPROCESS.DisableContaints(blnChecked, PanelEx.ENM_PROPERTY._1_Enabled)
        pnlSYOCHI_JISSI.DisableContaints(blnChecked, PanelEx.ENM_PROPERTY._1_Enabled)

        cmbKISYU1.SelectedIndex = 0
        cmbKISYU2.SelectedIndex = 0
        cmbKISYU3.SelectedIndex = 0
        cmbKISYU4.SelectedIndex = 0
        cmbKISYU5.SelectedIndex = 0
        cmbKISYU6.SelectedIndex = 0

        txtBUHIN_INFO1.Text = ""
        txtBUHIN_INFO2.Text = ""
        txtBUHIN_INFO3.Text = ""
        txtBUHIN_INFO4.Text = ""
        txtBUHIN_INFO5.Text = ""
        txtBUHIN_INFO6.Text = ""
        nupSURYO1.Value = 0
        nupSURYO2.Value = 0
        nupSURYO3.Value = 0
        nupSURYO4.Value = 0
        nupSURYO5.Value = 0
        nupSURYO6.Value = 0
        txtFROM1.Text = ""
        txtFROM2.Text = ""
        txtFROM3.Text = ""
        txtFROM4.Text = ""
        txtFROM5.Text = ""
        txtFROM6.Text = ""

        txtTO1.Text = ""
        txtTO2.Text = ""
        txtTO3.Text = ""
        txtTO4.Text = ""
        txtTO5.Text = ""
        txtTO6.Text = ""

        rbtnOTHER_PROCESS_INFLUENCE_KB_F.Checked = True
        rbtnFOLLOW_PROCESS_OUTFLOW_KB_F.Checked = True

        txtKOKYAKU_NOUNYU_NAIYOU.Text = ""
        txtZAIKO_SIKAKE_NAIYOU.Text = ""
        txtOTHER_PROCESS_NAIYOU.Text = ""
        dtKOKYAKU_NOUNYU_YMD.Value = ""
        dtZAIKO_SIKAKE_YMD.Value = ""
        dtOTHER_PROCESS_YMD.Value = ""
    End Sub

    Private Sub RbtnKOKYAKU_EIKYO_TUCHI_HANTEI_KB_CheckedChanged(sender As Object, e As EventArgs) Handles rbtnKOKYAKU_EIKYO_TUCHI_HANTEI_KB_T.CheckedChanged, rbtnKOKYAKU_EIKYO_TUCHI_HANTEI_KB_F.CheckedChanged

        Dim blnChecked As Boolean = rbtnKOKYAKU_EIKYO_TUCHI_HANTEI_KB_T.Checked

        dtTUCHI_YMD.Enabled = blnChecked
        txtTUCHI_SYUDAN.Enabled = blnChecked
        txtHITUYO_TETUDUKI_ZIKO.Enabled = blnChecked

    End Sub

    Private Sub CmbKISYU1_Validated(sender As Object, e As EventArgs) Handles cmbKISYU1.Validated
        Dim cmb = DirectCast(sender, ComboboxEx)
        If Not cmb.Text.IsNulOrWS Then
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
        If Not cmb.Text.IsNulOrWS Then
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
        If Not cmb.Text.IsNulOrWS Then
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

#End Region

#Region "ローカル関数"

#Region "バインディング"

    Private Function FunSetBinding() As Boolean

        Try

            Return True
        Catch ex As Exception
            Throw
            Return False
        End Try
    End Function

#End Region

#Region "処理モード別画面初期化"

    Private Function FunInitializeControls() As Boolean

        Try
            If Not FunSetBinding() Then Return False
            If Not FunSetModel() Then Return False

            'ナビゲートリンク選択
            If PrCurrentStage = ENM_CAR_STAGE._999_Closed Then
                rsbtnST99.Checked = True
            Else
                Dim rbtn As RibbonShapeRadioButton = DirectCast(flpnlStageIndex.Controls("rsbtnST" & (PrCurrentStage / 10).ToString("00")), RibbonShapeRadioButton)
                rbtn.Checked = True
            End If

            mtxHOKUKO_NO.Text = _V011_FCR_J.HOKOKU_NO
            mtxBUMON_KB.Text = _V011_FCR_J.BUMON_NAME
            mtxKISYU.Text = _V011_FCR_J.KISYU_NAME
            mtxFUTEKIGO_KB.Text = _V011_FCR_J.FUTEKIGO_NAME
            mtxFUTEKIGO_S_KB.Text = _V011_FCR_J.FUTEKIGO_S_NAME
            mtxADD_SYAIN_NAME_NCR.Text = _V011_FCR_J.ADD_SYAIN_NAME_NCR
            mtxADD_SYAIN_NAME.Text = _V011_FCR_J.ADD_SYAIN_NAME
            dtFUTEKIGO_HASSEI_YMD.Value = _V011_FCR_J.HASSEI_YMD

            rbtnFOLLOW_PROCESS_OUTFLOW_KB_T.Checked = (_V011_FCR_J.FOLLOW_PROCESS_OUTFLOW_KB = "1")
            rbtnKOKYAKU_EIKYO_HANTEI_KB_T.Checked = (_V011_FCR_J.KOKYAKU_EIKYO_HANTEI_KB = "1")
            rbtnKOKYAKU_EIKYO_TUCHI_HANTEI_KB_T.Checked = (_V011_FCR_J.KOKYAKU_EIKYO_TUCHI_HANTEI_KB = "1")
            rbtnOTHER_PROCESS_INFLUENCE_KB_T.Checked = (_V011_FCR_J.OTHER_PROCESS_INFLUENCE_KB = "1")

            mtxCurrentStageName.Text = FunGetLastStageName(Context.ENM_SYONIN_HOKOKUSYO_ID._3_FCR, _V011_FCR_J.HOKOKU_NO)

            mtxNextStageName.Text = FunGetStageName(Context.ENM_SYONIN_HOKOKUSYO_ID._3_FCR, FunGetNextSYONIN_JUN(PrCurrentStage))

            Dim blnOwn As Boolean = FunblnOwnCreated(Context.ENM_SYONIN_HOKOKUSYO_ID._3_FCR, _V011_FCR_J.HOKOKU_NO, PrCurrentStage)
            'tabSTAGE07.Enabled = blnOwn

            _tabPageManager = New TabPageManager(TabSTAGE)

            Select Case PrCurrentStage
                Case ENM_FCR_STAGE._999_Closed
                    pnlFCR.DisableContaints(IsEditingClosed, PanelEx.ENM_PROPERTY._2_ReadOnly)
                    pnlSYOCHI_KIROKU.DisableContaints(IsEditingClosed, PanelEx.ENM_PROPERTY._2_ReadOnly)
                    pnlZESEI_SYOCHI.DisableContaints(IsEditingClosed, PanelEx.ENM_PROPERTY._2_ReadOnly)
                    PnlPROCESS.DisableContaints(IsEditingClosed, PanelEx.ENM_PROPERTY._2_ReadOnly)
                    pnlSYOCHI_JISSI.DisableContaints(IsEditingClosed, PanelEx.ENM_PROPERTY._2_ReadOnly)

                Case Else
            End Select

            '画面上部のカレントステージ遷移ボタン
            For Each val As Integer In [Enum].GetValues(GetType(ENM_FCR_STAGE2))
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

            '最終ステージの場合、申請先担当者欄は非表示
            If PrCurrentStage >= ENM_FCR_STAGE._60_品証課長 Then
                lblDestTANTO.Visible = False
                cmbDestTANTO.Visible = False
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



            ErrorProvider.ClearError(cmbDestTANTO)

            Return True
        Catch ex As Exception
            EM.ErrorSyori(ex, False, conblnNonMsg)
            Return False
        End Try
    End Function

    Private Function FunSetModel() As Boolean
        Try
            _V003_SYONIN_J_KANRI_List = FunGetV003Model(Context.ENM_SYONIN_HOKOKUSYO_ID._3_FCR, PrHOKOKU_NO)

            _V011_FCR_J.Clear()
            _V011_FCR_J = FunGetV011Model(PrHOKOKU_NO)

            'データソース設定
            Dim dt As DataTable = FunGetSYOZOKU_SYAIN(_V011_FCR_J.BUMON_KB)

            dt = FunGetSYONIN_SYOZOKU_SYAIN(_V011_FCR_J.BUMON_KB, Context.ENM_SYONIN_HOKOKUSYO_ID._3_FCR, FunGetNextSYONIN_JUN(PrCurrentStage))
            cmbDestTANTO.SetDataSource(dt, ENM_COMBO_SELECT_VALUE_TYPE._0_Required)

            '#128
            If PrCurrentStage = ENM_CAR_STAGE._10_起草入力 AndAlso Not IsRemanded(_V011_FCR_J.HOKOKU_NO) Then
                _V011_FCR_J.ADD_SYAIN_ID = pub_SYAIN_INFO.SYAIN_ID
            End If

            Return True
        Catch ex As Exception
            EM.ErrorSyori(ex, False, conblnNonMsg)
            Return False
        End Try
    End Function


#End Region

#Region "入力チェック"

    Private Function FunCheckInput(ByVal enmSAVE_MODE As ENM_SAVE_MODE) As Boolean
        Try
            'フラグリセット
            IsValidated = True
            '-----共通
            If enmSAVE_MODE = ENM_SAVE_MODE._2_承認申請 Then
                Call CmbDestTANTO_Validating(cmbDestTANTO, Nothing)
            End If

            If cmbKOKYAKU_EIKYO_HANTEI_COMMENT.Visible Then
                IsValidated *= ErrorProvider.UpdateErrorInfo(cmbKOKYAKU_EIKYO_HANTEI_COMMENT, Not cmbKOKYAKU_EIKYO_HANTEI_COMMENT.Text.IsNulOrWS, String.Format(My.Resources.infoMsgRequireSelectOrInput, "否の理由"))
            End If

            '上記各種Validatingイベントでフラグを更新し、全てOKの場合はTrue
            Return IsValidated
        Catch ex As Exception
            EM.ErrorSyori(ex, False, conblnNonMsg)
            Return False
        End Try
    End Function

    Private Sub TxtKAITO_21_Validating(sender As Object, e As System.ComponentModel.CancelEventArgs)
        Dim txt As TextBoxEx = DirectCast(sender, TextBoxEx)

        IsValidated *= ErrorProvider.UpdateErrorInfo(txt, txt.ReadOnly OrElse Not txt.Text.IsNulOrWS, String.Format(My.Resources.infoMsgRequireSelectOrInput, "修正応急処置:内容"))

    End Sub

    Private Sub TxtKAITO_22_Validating(sender As Object, e As System.ComponentModel.CancelEventArgs) Handles txtTUCHI_SYUDAN.Validating, txtHITUYO_TETUDUKI_ZIKO.Validating, txtTO1.Validating, txtFROM1.Validating
        Dim txt As TextBoxEx = DirectCast(sender, TextBoxEx)

        IsValidated *= ErrorProvider.UpdateErrorInfo(txt, txt.ReadOnly OrElse Not txt.Text.IsNulOrWS, String.Format(My.Resources.infoMsgRequireSelectOrInput, "是正処置:内容"))

    End Sub

    Private Sub ＤtKAITO_4_Validating(sender As Object, e As System.ComponentModel.CancelEventArgs)
        Dim dtx As DateTextBoxEx = DirectCast(sender, DateTextBoxEx)

        IsValidated *= ErrorProvider.UpdateErrorInfo(dtx, Not dtx.ValueNonFormat.IsNulOrWS, String.Format(My.Resources.infoMsgRequireSelectOrInput, "修正応急処置:いつまで"))

    End Sub

    Private Sub CmbKAITO_5_Validating(sender As Object, e As System.ComponentModel.CancelEventArgs)
        Dim cmb As ComboboxEx = DirectCast(sender, ComboboxEx)

        IsValidated *= ErrorProvider.UpdateErrorInfo(cmb, cmb.IsSelected, String.Format(My.Resources.infoMsgRequireSelectOrInput, "修正応急処置:誰が"))

    End Sub

    Private Sub KAITO_678_Validating(sender As Object, e As System.ComponentModel.CancelEventArgs) Handles dtTUCHI_YMD.Validating
        'Dim mtxGOKI As MaskedTextBoxEx = mtxKAITO_6
        'Dim mtxLOT As MaskedTextBoxEx = mtxKAITO_7
        'Dim dtYMD As DateTextBoxEx = dtKAITO_8

        'Dim result As Boolean = Not (mtxGOKI.Text.IsNulOrWS AndAlso mtxLOT.Text.IsNulOrWS AndAlso dtYMD.ValueNonFormat.IsNulOrWS)
        'IsValidated *= ErrorProvider.UpdateErrorInfo(mtxGOKI, result, String.Format(My.Resources.infoMsgRequireSelectOrInput, "修正応急処置:有効号機・LOT・日付のいづれかの入力が必要です"))
        'IsValidated *= ErrorProvider.UpdateErrorInfo(mtxLOT, result, String.Format(My.Resources.infoMsgRequireSelectOrInput, "修正応急処置:有効号機・LOT・日付のいづれかの入力が必要です"))
        'IsValidated *= ErrorProvider.UpdateErrorInfo(dtYMD, result, String.Format(My.Resources.infoMsgRequireSelectOrInput, "修正応急処置:有効号機・LOT・日付のいづれかの入力が必要です"))

    End Sub

    Private Sub DtKAITO_9_Validating(sender As Object, e As System.ComponentModel.CancelEventArgs)
        Dim dtx As DateTextBoxEx = DirectCast(sender, DateTextBoxEx)

        IsValidated *= ErrorProvider.UpdateErrorInfo(dtx, Not dtx.ValueNonFormat.IsNulOrWS, String.Format(My.Resources.infoMsgRequireSelectOrInput, "是正処置:いつまで"))

    End Sub

    Private Sub cmbKAITO_10_Validating(sender As Object, e As System.ComponentModel.CancelEventArgs)
        Dim cmb As ComboboxEx = DirectCast(sender, ComboboxEx)

        IsValidated *= ErrorProvider.UpdateErrorInfo(cmb, cmb.IsSelected, String.Format(My.Resources.infoMsgRequireSelectOrInput, "是正処置:誰が"))

    End Sub

    Private Sub KAITO_111213_Validating(sender As Object, e As System.ComponentModel.CancelEventArgs)
        'Dim mtxGOKI As MaskedTextBoxEx = mtxKAITO_11
        'Dim mtxLOT As MaskedTextBoxEx = mtxKAITO_12
        'Dim dtYMD As DateTextBoxEx = dtKAITO_13

        'Dim result As Boolean = Not (mtxGOKI.Text.IsNulOrWS AndAlso mtxLOT.Text.IsNulOrWS AndAlso dtYMD.ValueNonFormat.IsNulOrWS)
        'IsValidated *= ErrorProvider.UpdateErrorInfo(mtxGOKI, result, String.Format(My.Resources.infoMsgRequireSelectOrInput, "是正処置:有効号機・LOT・日付のいづれかの入力が必要です"))
        'IsValidated *= ErrorProvider.UpdateErrorInfo(mtxLOT, result, String.Format(My.Resources.infoMsgRequireSelectOrInput, "是正処置:有効号機・LOT・日付のいづれかの入力が必要です"))
        'IsValidated *= ErrorProvider.UpdateErrorInfo(dtYMD, result, String.Format(My.Resources.infoMsgRequireSelectOrInput, "是正処置:有効号機・LOT・日付のいづれかの入力が必要です"))

    End Sub

    Private Sub dtKAITO_16_Validating(sender As Object, e As System.ComponentModel.CancelEventArgs)
        Dim dtx As DateTextBoxEx = DirectCast(sender, DateTextBoxEx)

        IsValidated *= ErrorProvider.UpdateErrorInfo(dtx, dtx.ReadOnly OrElse Not dtx.ValueNonFormat.IsNulOrWS, String.Format(My.Resources.infoMsgRequireSelectOrInput, "水平展開:いつまで"))

    End Sub

    Private Sub cmbKAITO_17_Validating(sender As Object, e As System.ComponentModel.CancelEventArgs)
        Dim cmb As ComboboxEx = DirectCast(sender, ComboboxEx)

        IsValidated *= ErrorProvider.UpdateErrorInfo(cmb, cmb.ReadOnly OrElse cmb.IsSelected, String.Format(My.Resources.infoMsgRequireSelectOrInput, "水平展開:誰が"))

    End Sub

    Private Sub KAITO_181920_Validating(sender As Object, e As System.ComponentModel.CancelEventArgs)
        'Dim mtxGOKI As MaskedTextBoxEx = mtxKAITO_18
        'Dim mtxLOT As MaskedTextBoxEx = mtxKAITO_19
        'Dim dtYMD As DateTextBoxEx = dtKAITO_20

        'Dim result As Boolean = (mtxGOKI.ReadOnly OrElse Not (mtxGOKI.Text.IsNulOrWS AndAlso mtxLOT.Text.IsNulOrWS AndAlso dtYMD.ValueNonFormat.IsNulOrWS))
        'IsValidated *= ErrorProvider.UpdateErrorInfo(mtxGOKI, result, String.Format(My.Resources.infoMsgRequireSelectOrInput, "水平展開:有効号機・LOT・日付のいづれかの入力が必要です"))
        'IsValidated *= ErrorProvider.UpdateErrorInfo(mtxLOT, result, String.Format(My.Resources.infoMsgRequireSelectOrInput, "水平展開:有効号機・LOT・日付のいづれかの入力が必要です"))
        'IsValidated *= ErrorProvider.UpdateErrorInfo(dtYMD, result, String.Format(My.Resources.infoMsgRequireSelectOrInput, "水平展開:有効号機・LOT・日付のいづれかの入力が必要です"))

    End Sub

    Private Sub mtxGOKI_Validating(sender As Object, e As System.ComponentModel.CancelEventArgs)
        Dim mtx As MaskedTextBoxEx = DirectCast(sender, MaskedTextBoxEx)

        IsValidated *= ErrorProvider.UpdateErrorInfo(mtx, mtx.ReadOnly OrElse Not mtx.Text.IsNulOrWS, String.Format(My.Resources.infoMsgRequireSelectOrInput, "是正処置有効性レビュー：号機・LOT"))

    End Sub

    Private Sub cmbKONPON_YOIN_TANTO_Validating(sender As Object, e As System.ComponentModel.CancelEventArgs)
        Dim cmb As ComboboxEx = DirectCast(sender, ComboboxEx)

        IsValidated *= ErrorProvider.UpdateErrorInfo(cmb, cmb.ReadOnly OrElse cmb.IsSelected, String.Format(My.Resources.infoMsgRequireSelectOrInput, "分析：作業担当"))

    End Sub

    Private Sub cmbKISEKI_KOTEI_Validating(sender As Object, e As System.ComponentModel.CancelEventArgs)
        Dim cmb As ComboboxEx = DirectCast(sender, ComboboxEx)

        IsValidated *= ErrorProvider.UpdateErrorInfo(cmb, cmb.ReadOnly OrElse cmb.IsSelected, String.Format(My.Resources.infoMsgRequireSelectOrInput, "分析：帰責工程"))

    End Sub

    Private Sub ＤtST13_Validating(sender As Object, e As System.ComponentModel.CancelEventArgs)
        Dim dtx As DateTextBoxEx = DirectCast(sender, DateTextBoxEx)

        IsValidated *= ErrorProvider.UpdateErrorInfo(dtx, Not dtx.ValueNonFormat.IsNulOrWS, String.Format(My.Resources.infoMsgRequireSelectOrInput, "是正有効性確認:確認日"))

    End Sub

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
    ''' <param name="intCurrentStageID">現ステージID</param>
    ''' <returns></returns>
    Private Function FunGetNextSYONIN_JUN(ByVal intCurrentStageID As Integer) As Integer
        Try
            Const stageLength As Integer = 10

            'If PrCurrentStage = ENM_CAR_STAGE._40_起草確認_生産技術 And _D005_CAR_J.KAITO_23 = False Then
            '    'ステージ50スキップ
            '    Return intCurrentStageID + (stageLength * 2)
            'Else
            Select Case intCurrentStageID
                Case ENM_FCR_STAGE._60_品証課長, ENM_FCR_STAGE._999_Closed
                    Return ENM_FCR_STAGE._999_Closed
                Case Else
                    Return intCurrentStageID + stageLength
            End Select

            'End If
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
            sbSQL.Append($" COUNT({NameOf(R004_CAR_SASIMODOSI.HOKOKU_NO)})")
            sbSQL.Append($" FROM {NameOf(R004_CAR_SASIMODOSI)} ")
            sbSQL.Append($" WHERE {NameOf(R004_CAR_SASIMODOSI.HOKOKU_NO)}='{strHOKOKU_NO}'")
            Using DB As ClsDbUtility = DBOpen()
                intRET = DB.ExecuteScalar(sbSQL.ToString, conblnNonMsg)
            End Using

            Return intRET > 0
        End If
    End Function

#End Region

End Class