Imports System.Threading.Tasks
Imports JMS_COMMON.ClsPubMethod
Imports MODEL

''' <summary>
''' CAR登録画面
''' </summary>
Public Class FrmG0021

#Region "定数・変数"

    Private _V002_NCR_J As New MODEL.V002_NCR_J
    Private _V003_SYONIN_J_KANRI_List As New List(Of MODEL.V003_SYONIN_J_KANRI)
    Private _V007_FCR_J As New MODEL.V005_CAR_J


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
        'cmbKAITO_5.NullValue = 0
        'cmbKAITO_10.NullValue = 0
        'cmbKAITO_17.NullValue = 0
        'cmbKONPON_YOIN_TANTO.NullValue = 0

        'cmbDestTANTO.ImeMode = ImeMode.On
        'cmbKAITO_5.ImeMode = ImeMode.On
        'cmbKAITO_10.ImeMode = ImeMode.On
        'cmbKAITO_17.ImeMode = ImeMode.On
        'cmbKONPON_YOIN_TANTO.ImeMode = ImeMode.On
        'cmbSYOCHI_A_TANTO.ImeMode = ImeMode.On
        'cmbSYOCHI_B_TANTO.ImeMode = ImeMode.On
        'cmbSYOCHI_C_TANTO.ImeMode = ImeMode.On
        'cmbKENSA_TANTO.ImeMode = ImeMode.On
        'cmbKENSA_GL_TANTO.ImeMode = ImeMode.On
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
                        'cmbKONPON_YOIN_KB1.SetDataSource(tblKONPON_YOIN_KB, ENM_COMBO_SELECT_VALUE_TYPE._2_Option)
                        'cmbKONPON_YOIN_KB2.SetDataSource(tblKONPON_YOIN_KB, ENM_COMBO_SELECT_VALUE_TYPE._2_Option)

                        'cmbKISEKI_KOTEI.SetDataSource(tblKISEKI_KOUTEI_KB, ENM_COMBO_SELECT_VALUE_TYPE._2_Option)
                        'cmbKAITO_14.SetDataSource(tblYOHI_KB, ENM_COMBO_SELECT_VALUE_TYPE._0_Required)

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

                                'SPEC: 2.(3).E.�C
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
                    Call OpenFormHistory(Context.ENM_SYONIN_HOKOKUSYO_ID._2_CAR, _V007_FCR_J.HOKOKU_NO)

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

                    'SPEC: 2.(3).D.�@.レコード更新
                    If FunSAVE_D007(DB, enmSAVE_MODE) = False Then blnErr = True : Return False
                    If FunSAVE_FILE(DB) = False Then blnErr = True : Return False

                    If Not blnTENSO And PrCurrentStage < ENM_CAR_STAGE._999_Closed Then
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
            'SPEC: 2.(3).D.�A.添付ファイル保存
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

#Region "   D005"

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
        'モデル更新

        Select Case PrCurrentStage
            Case ENM_CAR_STAGE._10_起草入力
                _D005_CAR_J.ADD_SYAIN_ID = pub_SYAIN_INFO.SYAIN_ID
            Case ENM_CAR_STAGE._130_是正有効性確認_品証担当課長 And enmSAVE_MODE = ENM_SAVE_MODE._2_承認申請
                _D005_CAR_J._CLOSE_FG = 1
            Case Else

        End Select

        '-----MERGE
        sbSQL.Remove(0, sbSQL.Length)
        sbSQL.Append($"MERGE INTO {NameOf(MODEL.D005_CAR_J)} AS SrcT")
        sbSQL.Append(" USING (")
        sbSQL.Append(" SELECT")
        sbSQL.Append($" '{_D005_CAR_J.HOKOKU_NO }' AS {NameOf(_D005_CAR_J.HOKOKU_NO)}")
        sbSQL.Append($",'{_D005_CAR_J.BUMON_KB }' AS {NameOf(_D005_CAR_J.BUMON_KB)}")
        sbSQL.Append($",'{_D005_CAR_J._CLOSE_FG }' AS {NameOf(_D005_CAR_J.CLOSE_FG)}")
        sbSQL.Append($",'{_D005_CAR_J.SETUMON_1 }' AS {NameOf(_D005_CAR_J.SETUMON_1)}")
        sbSQL.Append($",'{_D005_CAR_J.SETUMON_2 }' AS {NameOf(_D005_CAR_J.SETUMON_2)}")
        sbSQL.Append($",'{_D005_CAR_J.SETUMON_3 }' AS {NameOf(_D005_CAR_J.SETUMON_3)}")
        sbSQL.Append($",'{_D005_CAR_J.SETUMON_4 }' AS {NameOf(_D005_CAR_J.SETUMON_4)}")
        sbSQL.Append($",'{_D005_CAR_J.SETUMON_5 }' AS {NameOf(_D005_CAR_J.SETUMON_5)}")
        sbSQL.Append($",'{_D005_CAR_J.SETUMON_6 }' AS {NameOf(_D005_CAR_J.SETUMON_6)}")
        sbSQL.Append($",'{_D005_CAR_J.SETUMON_7 }' AS {NameOf(_D005_CAR_J.SETUMON_7)}")
        sbSQL.Append($",'{_D005_CAR_J.SETUMON_8 }' AS {NameOf(_D005_CAR_J.SETUMON_8)}")
        sbSQL.Append($",'{_D005_CAR_J.SETUMON_9 }' AS {NameOf(_D005_CAR_J.SETUMON_9)}")
        sbSQL.Append($",'{_D005_CAR_J.SETUMON_10 }' AS {NameOf(_D005_CAR_J.SETUMON_10)}")
        sbSQL.Append($",'{_D005_CAR_J.SETUMON_11 }' AS {NameOf(_D005_CAR_J.SETUMON_11)}")
        sbSQL.Append($",'{_D005_CAR_J.SETUMON_12 }' AS {NameOf(_D005_CAR_J.SETUMON_12)}")
        sbSQL.Append($",'{_D005_CAR_J.SETUMON_13 }' AS {NameOf(_D005_CAR_J.SETUMON_13)}")
        sbSQL.Append($",'{_D005_CAR_J.SETUMON_14 }' AS {NameOf(_D005_CAR_J.SETUMON_14)}")
        sbSQL.Append($",'{_D005_CAR_J.SETUMON_15 }' AS {NameOf(_D005_CAR_J.SETUMON_15)}")
        sbSQL.Append($",'{_D005_CAR_J.SETUMON_16 }' AS {NameOf(_D005_CAR_J.SETUMON_16)}")
        sbSQL.Append($",'{_D005_CAR_J.SETUMON_17 }' AS {NameOf(_D005_CAR_J.SETUMON_17)}")
        sbSQL.Append($",'{_D005_CAR_J.SETUMON_18 }' AS {NameOf(_D005_CAR_J.SETUMON_18)}")
        sbSQL.Append($",'{_D005_CAR_J.SETUMON_19 }' AS {NameOf(_D005_CAR_J.SETUMON_19)}")
        sbSQL.Append($",'{_D005_CAR_J.SETUMON_20 }' AS {NameOf(_D005_CAR_J.SETUMON_20)}")
        sbSQL.Append($",'{_D005_CAR_J.SETUMON_21 }' AS {NameOf(_D005_CAR_J.SETUMON_21)}")
        sbSQL.Append($",'{_D005_CAR_J.SETUMON_22 }' AS {NameOf(_D005_CAR_J.SETUMON_22)}")
        sbSQL.Append($",'{_D005_CAR_J.SETUMON_23 }' AS {NameOf(_D005_CAR_J.SETUMON_23)}")
        sbSQL.Append($",'{_D005_CAR_J.SETUMON_24 }' AS {NameOf(_D005_CAR_J.SETUMON_24)}")
        sbSQL.Append($",'{_D005_CAR_J.SETUMON_25 }' AS {NameOf(_D005_CAR_J.SETUMON_25)}")

        sbSQL.Append($",'{_D005_CAR_J.KAITO_1 }' AS {NameOf(_D005_CAR_J.KAITO_1)}")
        sbSQL.Append($",'{_D005_CAR_J.KAITO_2 }' AS {NameOf(_D005_CAR_J.KAITO_2)}")
        sbSQL.Append($",'{_D005_CAR_J.KAITO_3 }' AS {NameOf(_D005_CAR_J.KAITO_3)}")
        sbSQL.Append($",'{_D005_CAR_J.KAITO_4 }' AS {NameOf(_D005_CAR_J.KAITO_4)}")
        sbSQL.Append($", {_D005_CAR_J.KAITO_5 } As {NameOf(_D005_CAR_J.KAITO_5)}")
        sbSQL.Append($",'{_D005_CAR_J.KAITO_6 }' AS {NameOf(_D005_CAR_J.KAITO_6)}")
        sbSQL.Append($",'{_D005_CAR_J.KAITO_7 }' AS {NameOf(_D005_CAR_J.KAITO_7)}")
        sbSQL.Append($",'{_D005_CAR_J.KAITO_8 }' AS {NameOf(_D005_CAR_J.KAITO_8)}")
        sbSQL.Append($",'{_D005_CAR_J.KAITO_9 }' AS {NameOf(_D005_CAR_J.KAITO_9)}")
        sbSQL.Append($", {_D005_CAR_J.KAITO_10 } As {NameOf(_D005_CAR_J.KAITO_10)}")
        sbSQL.Append($",'{_D005_CAR_J.KAITO_11 }' AS {NameOf(_D005_CAR_J.KAITO_11)}")
        sbSQL.Append($",'{_D005_CAR_J.KAITO_12 }' AS {NameOf(_D005_CAR_J.KAITO_12)}")
        sbSQL.Append($",'{_D005_CAR_J.KAITO_13 }' AS {NameOf(_D005_CAR_J.KAITO_13)}")
        sbSQL.Append($",'{_D005_CAR_J.KAITO_14 }' AS {NameOf(_D005_CAR_J.KAITO_14)}")
        sbSQL.Append($",'{_D005_CAR_J.KAITO_15 }' AS {NameOf(_D005_CAR_J.KAITO_15)}")
        sbSQL.Append($",'{_D005_CAR_J.KAITO_16 }' AS {NameOf(_D005_CAR_J.KAITO_16)}")
        sbSQL.Append($", {_D005_CAR_J.KAITO_17 } As {NameOf(_D005_CAR_J.KAITO_17)}")
        sbSQL.Append($",'{_D005_CAR_J.KAITO_18 }' AS {NameOf(_D005_CAR_J.KAITO_18)}")
        sbSQL.Append($",'{_D005_CAR_J.KAITO_19 }' AS {NameOf(_D005_CAR_J.KAITO_19)}")
        sbSQL.Append($",'{_D005_CAR_J.KAITO_20 }' AS {NameOf(_D005_CAR_J.KAITO_20)}")
        sbSQL.Append($",'{_D005_CAR_J.KAITO_21 }' AS {NameOf(_D005_CAR_J.KAITO_21)}")
        sbSQL.Append($",'{_D005_CAR_J.KAITO_22 }' AS {NameOf(_D005_CAR_J.KAITO_22)}")
        sbSQL.Append($",'{_D005_CAR_J._KAITO_23 }' AS {NameOf(_D005_CAR_J.KAITO_23)}")
        sbSQL.Append($",'{_D005_CAR_J.KAITO_24 }' AS {NameOf(_D005_CAR_J.KAITO_24)}")
        sbSQL.Append($",'{_D005_CAR_J.KAITO_25 }' AS {NameOf(_D005_CAR_J.KAITO_25)}")

        sbSQL.Append($",'{_D005_CAR_J.KONPON_YOIN_KB1}' AS {NameOf(_D005_CAR_J.KONPON_YOIN_KB1)}")
        sbSQL.Append($",'{_D005_CAR_J.KONPON_YOIN_KB2}' AS {NameOf(_D005_CAR_J.KONPON_YOIN_KB2)}")
        sbSQL.Append($", {_D005_CAR_J.KONPON_YOIN_SYAIN_ID} AS {NameOf(_D005_CAR_J.KONPON_YOIN_SYAIN_ID)}")
        sbSQL.Append($",'{_D005_CAR_J.KISEKI_KOTEI_KB}' AS {NameOf(_D005_CAR_J.KISEKI_KOTEI_KB)}")
        sbSQL.Append($", {_D005_CAR_J.SYOCHI_A_SYAIN_ID} AS {NameOf(_D005_CAR_J.SYOCHI_A_SYAIN_ID)}")
        sbSQL.Append($",'{_D005_CAR_J.SYOCHI_A_YMDHNS}' AS {NameOf(_D005_CAR_J.SYOCHI_A_YMDHNS)}")
        sbSQL.Append($", {_D005_CAR_J.SYOCHI_B_SYAIN_ID} AS {NameOf(_D005_CAR_J.SYOCHI_B_SYAIN_ID)}")
        sbSQL.Append($",'{_D005_CAR_J.SYOCHI_B_YMDHNS}' AS {NameOf(_D005_CAR_J.SYOCHI_B_YMDHNS)}")
        sbSQL.Append($", {_D005_CAR_J.SYOCHI_C_SYAIN_ID} AS {NameOf(_D005_CAR_J.SYOCHI_C_SYAIN_ID)}")
        sbSQL.Append($",'{_D005_CAR_J.SYOCHI_C_YMDHNS}' AS {NameOf(_D005_CAR_J.SYOCHI_C_YMDHNS)}")
        sbSQL.Append($",'{_D005_CAR_J.KYOIKU_FILE_PATH}' AS {NameOf(_D005_CAR_J.KYOIKU_FILE_PATH)}")
        sbSQL.Append($",'{_D005_CAR_J._ZESEI_SYOCHI_YUKO_UMU}' AS {NameOf(_D005_CAR_J.ZESEI_SYOCHI_YUKO_UMU)}")
        sbSQL.Append($",'{_D005_CAR_J.SYOSAI_FILE_PATH}' AS {NameOf(_D005_CAR_J.SYOSAI_FILE_PATH)}")
        sbSQL.Append($",'{_D005_CAR_J.GOKI}' AS {NameOf(_D005_CAR_J.GOKI)}")
        sbSQL.Append($",'{_D005_CAR_J.LOT}' AS {NameOf(_D005_CAR_J.LOT)}")
        sbSQL.Append($", {_D005_CAR_J.KENSA_TANTO_ID} AS {NameOf(_D005_CAR_J.KENSA_TANTO_ID)}")
        sbSQL.Append($",'{_D005_CAR_J.KENSA_TOROKU_YMDHNS}' AS {NameOf(_D005_CAR_J.KENSA_TOROKU_YMDHNS)}")
        sbSQL.Append($", {_D005_CAR_J.KENSA_GL_SYAIN_ID} AS {NameOf(_D005_CAR_J.KENSA_GL_SYAIN_ID)}")
        sbSQL.Append($",'{_D005_CAR_J.KENSA_GL_YMDHNS}' AS {NameOf(_D005_CAR_J.KENSA_GL_YMDHNS)}")
        sbSQL.Append($",'{_D005_CAR_J.FILE_PATH1}' AS {NameOf(_D005_CAR_J.FILE_PATH1)}")
        sbSQL.Append($",'{_D005_CAR_J.FILE_PATH2}' AS {NameOf(_D005_CAR_J.FILE_PATH2)}")
        sbSQL.Append($",'{_D005_CAR_J.FUTEKIGO_HASSEI_YMD}' AS {NameOf(_D005_CAR_J.FUTEKIGO_HASSEI_YMD)}")
        sbSQL.Append($",'{_D005_CAR_J.SYOCHI_YOTEI_YMD}' AS {NameOf(_D005_CAR_J.SYOCHI_YOTEI_YMD)}")
        sbSQL.Append($", {_D005_CAR_J.ADD_SYAIN_ID} AS {NameOf(_D005_CAR_J.ADD_SYAIN_ID)}")
        sbSQL.Append($",'{_D005_CAR_J.ADD_YMDHNS}' AS {NameOf(_D005_CAR_J.ADD_YMDHNS)}")
        sbSQL.Append($", {_D005_CAR_J.UPD_SYAIN_ID} AS {NameOf(_D005_CAR_J.UPD_SYAIN_ID)}")
        sbSQL.Append($",'{strSysDate}' AS {NameOf(_D005_CAR_J.UPD_YMDHNS)}")
        sbSQL.Append($", {_D005_CAR_J.DEL_SYAIN_ID} AS {NameOf(_D005_CAR_J.DEL_SYAIN_ID)}")
        sbSQL.Append($",'{_D005_CAR_J.DEL_YMDHNS}' AS {NameOf(_D005_CAR_J.DEL_YMDHNS)}")
        sbSQL.Append($" ) AS WK")
        sbSQL.Append($" ON (SrcT.{NameOf(_D005_CAR_J.HOKOKU_NO)} = WK.{NameOf(_D005_CAR_J.HOKOKU_NO)})")
        'UPDATE
        sbSQL.Append($" WHEN MATCHED THEN")
        sbSQL.Append($" UPDATE SET")

        Select Case PrCurrentStage
            Case ENM_CAR_STAGE._10_起草入力 To ENM_CAR_STAGE._70_起草確認_品証課長
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
                sbSQL.Append($" ,SrcT.{NameOf(_D005_CAR_J.SETUMON_21)} = WK.{NameOf(_D005_CAR_J.SETUMON_21)}")
                sbSQL.Append($" ,SrcT.{NameOf(_D005_CAR_J.SETUMON_22)} = WK.{NameOf(_D005_CAR_J.SETUMON_22)}")
                sbSQL.Append($" ,SrcT.{NameOf(_D005_CAR_J.SETUMON_23)} = WK.{NameOf(_D005_CAR_J.SETUMON_23)}")

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
                sbSQL.Append($" ,SrcT.{NameOf(_D005_CAR_J.KAITO_21)} = WK.{NameOf(_D005_CAR_J.KAITO_21)}")
                sbSQL.Append($" ,SrcT.{NameOf(_D005_CAR_J.KAITO_22)} = WK.{NameOf(_D005_CAR_J.KAITO_22)}")
                sbSQL.Append($" ,SrcT.{NameOf(_D005_CAR_J.KAITO_23)} = WK.{NameOf(_D005_CAR_J.KAITO_23)}")

                sbSQL.Append($" ,SrcT.{NameOf(_D005_CAR_J.KONPON_YOIN_KB1)} = WK.{NameOf(_D005_CAR_J.KONPON_YOIN_KB1)}")
                sbSQL.Append($" ,SrcT.{NameOf(_D005_CAR_J.KONPON_YOIN_KB2)} = WK.{NameOf(_D005_CAR_J.KONPON_YOIN_KB2)}")
                sbSQL.Append($" ,SrcT.{NameOf(_D005_CAR_J.KONPON_YOIN_SYAIN_ID)} = WK.{NameOf(_D005_CAR_J.KONPON_YOIN_SYAIN_ID)}")
                sbSQL.Append($" ,SrcT.{NameOf(_D005_CAR_J.KISEKI_KOTEI_KB)} = WK.{NameOf(_D005_CAR_J.KISEKI_KOTEI_KB)}")

                sbSQL.Append($" ,SrcT.{NameOf(_D005_CAR_J.FUTEKIGO_HASSEI_YMD)} = WK.{NameOf(_D005_CAR_J.FUTEKIGO_HASSEI_YMD)}")
                sbSQL.Append($" ,SrcT.{NameOf(_D005_CAR_J.ADD_SYAIN_ID)} = WK.{NameOf(_D005_CAR_J.ADD_SYAIN_ID)}")
                sbSQL.Append($" ,SrcT.{NameOf(_D005_CAR_J.ADD_YMDHNS)} = WK.{NameOf(_D005_CAR_J.ADD_YMDHNS)}")

            Case ENM_CAR_STAGE._80_処置実施記録入力 To ENM_CAR_STAGE._90_処置実施確認
                sbSQL.Append($" SrcT.{NameOf(_D005_CAR_J.SYOCHI_A_SYAIN_ID)} = WK.{NameOf(_D005_CAR_J.SYOCHI_A_SYAIN_ID)}")
                sbSQL.Append($" ,SrcT.{NameOf(_D005_CAR_J.SYOCHI_A_YMDHNS)} = WK.{NameOf(_D005_CAR_J.SYOCHI_A_YMDHNS)}")
                sbSQL.Append($" ,SrcT.{NameOf(_D005_CAR_J.SYOCHI_B_SYAIN_ID)} = WK.{NameOf(_D005_CAR_J.SYOCHI_B_SYAIN_ID)}")
                sbSQL.Append($" ,SrcT.{NameOf(_D005_CAR_J.SYOCHI_B_YMDHNS)} = WK.{NameOf(_D005_CAR_J.SYOCHI_B_YMDHNS)}")
                sbSQL.Append($" ,SrcT.{NameOf(_D005_CAR_J.SYOCHI_C_SYAIN_ID)} = WK.{NameOf(_D005_CAR_J.SYOCHI_C_SYAIN_ID)}")
                sbSQL.Append($" ,SrcT.{NameOf(_D005_CAR_J.SYOCHI_C_YMDHNS)} = WK.{NameOf(_D005_CAR_J.SYOCHI_C_YMDHNS)}")
                sbSQL.Append($" ,SrcT.{NameOf(_D005_CAR_J.KYOIKU_FILE_PATH)} = WK.{NameOf(_D005_CAR_J.KYOIKU_FILE_PATH)}")

            Case ENM_CAR_STAGE._100_是正有効性記入 To ENM_CAR_STAGE._130_是正有効性確認_品証担当課長
                sbSQL.Append($" SrcT.{NameOf(_D005_CAR_J.ZESEI_SYOCHI_YUKO_UMU)} = WK.{NameOf(_D005_CAR_J.ZESEI_SYOCHI_YUKO_UMU)}")
                sbSQL.Append($" ,SrcT.{NameOf(_D005_CAR_J.SYOSAI_FILE_PATH)} = WK.{NameOf(_D005_CAR_J.SYOSAI_FILE_PATH)}")
                sbSQL.Append($" ,SrcT.{NameOf(_D005_CAR_J.GOKI)} = WK.{NameOf(_D005_CAR_J.GOKI)}")
                sbSQL.Append($" ,SrcT.{NameOf(_D005_CAR_J.LOT)} = WK.{NameOf(_D005_CAR_J.LOT)}")
                sbSQL.Append($" ,SrcT.{NameOf(_D005_CAR_J.KENSA_TANTO_ID)} = WK.{NameOf(_D005_CAR_J.KENSA_TANTO_ID)}")
                sbSQL.Append($" ,SrcT.{NameOf(_D005_CAR_J.KENSA_TOROKU_YMDHNS)} = WK.{NameOf(_D005_CAR_J.KENSA_TOROKU_YMDHNS)}")
                sbSQL.Append($" ,SrcT.{NameOf(_D005_CAR_J.KENSA_GL_SYAIN_ID)} = WK.{NameOf(_D005_CAR_J.KENSA_GL_SYAIN_ID)}")
                sbSQL.Append($" ,SrcT.{NameOf(_D005_CAR_J.KENSA_GL_YMDHNS)} = WK.{NameOf(_D005_CAR_J.KENSA_GL_YMDHNS)}")

            Case Else
                'Err
                Return False
        End Select

        sbSQL.Append($" ,SrcT.{NameOf(_D005_CAR_J.KAITO_24)} = WK.{NameOf(_D005_CAR_J.KAITO_24)}")
        sbSQL.Append($" ,SrcT.{NameOf(_D005_CAR_J.SYOCHI_YOTEI_YMD)} = WK.{NameOf(_D005_CAR_J.SYOCHI_YOTEI_YMD)}")
        sbSQL.Append($" ,SrcT.{NameOf(_D005_CAR_J.FILE_PATH1)} = WK.{NameOf(_D005_CAR_J.FILE_PATH1)}")
        sbSQL.Append($" ,SrcT.{NameOf(_D005_CAR_J.FILE_PATH2)} = WK.{NameOf(_D005_CAR_J.FILE_PATH2)}")
        sbSQL.Append($" ,SrcT.{NameOf(_D005_CAR_J.UPD_SYAIN_ID)} = WK.{NameOf(_D005_CAR_J.UPD_SYAIN_ID)}")
        sbSQL.Append($" ,SrcT.{NameOf(_D005_CAR_J.UPD_YMDHNS)} = WK.{NameOf(_D005_CAR_J.UPD_YMDHNS)}")
        sbSQL.Append($" ,SrcT.{NameOf(_D005_CAR_J.CLOSE_FG)} = WK.{NameOf(_D005_CAR_J.CLOSE_FG)}")

        'INSERT
        sbSQL.Append($" WHEN NOT MATCHED THEN ")
        sbSQL.Append($"INSERT(")

#Region "列挙"

        sbSQL.Append($"  " & NameOf(_D005_CAR_J.HOKOKU_NO))
        sbSQL.Append($" ," & NameOf(_D005_CAR_J.BUMON_KB))
        sbSQL.Append($" ," & NameOf(_D005_CAR_J.CLOSE_FG))
        sbSQL.Append($" ," & NameOf(_D005_CAR_J.SETUMON_1))
        sbSQL.Append($" ," & NameOf(_D005_CAR_J.SETUMON_2))
        sbSQL.Append($" ," & NameOf(_D005_CAR_J.SETUMON_3))
        sbSQL.Append($" ," & NameOf(_D005_CAR_J.SETUMON_4))
        sbSQL.Append($" ," & NameOf(_D005_CAR_J.SETUMON_5))
        sbSQL.Append($" ," & NameOf(_D005_CAR_J.SETUMON_6))
        sbSQL.Append($" ," & NameOf(_D005_CAR_J.SETUMON_7))
        sbSQL.Append($" ," & NameOf(_D005_CAR_J.SETUMON_8))
        sbSQL.Append($" ," & NameOf(_D005_CAR_J.SETUMON_9))
        sbSQL.Append($" ," & NameOf(_D005_CAR_J.SETUMON_10))
        sbSQL.Append($" ," & NameOf(_D005_CAR_J.SETUMON_11))
        sbSQL.Append($" ," & NameOf(_D005_CAR_J.SETUMON_12))
        sbSQL.Append($" ," & NameOf(_D005_CAR_J.SETUMON_13))
        sbSQL.Append($" ," & NameOf(_D005_CAR_J.SETUMON_14))
        sbSQL.Append($" ," & NameOf(_D005_CAR_J.SETUMON_15))
        sbSQL.Append($" ," & NameOf(_D005_CAR_J.SETUMON_16))
        sbSQL.Append($" ," & NameOf(_D005_CAR_J.SETUMON_17))
        sbSQL.Append($" ," & NameOf(_D005_CAR_J.SETUMON_18))
        sbSQL.Append($" ," & NameOf(_D005_CAR_J.SETUMON_19))
        sbSQL.Append($" ," & NameOf(_D005_CAR_J.SETUMON_20))
        sbSQL.Append($" ," & NameOf(_D005_CAR_J.SETUMON_21))
        sbSQL.Append($" ," & NameOf(_D005_CAR_J.SETUMON_22))
        sbSQL.Append($" ," & NameOf(_D005_CAR_J.SETUMON_23))
        sbSQL.Append($" ," & NameOf(_D005_CAR_J.SETUMON_24))
        sbSQL.Append($" ," & NameOf(_D005_CAR_J.SETUMON_25))
        sbSQL.Append($" ," & NameOf(_D005_CAR_J.KAITO_1))
        sbSQL.Append($" ," & NameOf(_D005_CAR_J.KAITO_2))
        sbSQL.Append($" ," & NameOf(_D005_CAR_J.KAITO_3))
        sbSQL.Append($" ," & NameOf(_D005_CAR_J.KAITO_4))
        sbSQL.Append($" ," & NameOf(_D005_CAR_J.KAITO_5))
        sbSQL.Append($" ," & NameOf(_D005_CAR_J.KAITO_6))
        sbSQL.Append($" ," & NameOf(_D005_CAR_J.KAITO_7))
        sbSQL.Append($" ," & NameOf(_D005_CAR_J.KAITO_8))
        sbSQL.Append($" ," & NameOf(_D005_CAR_J.KAITO_9))
        sbSQL.Append($" ," & NameOf(_D005_CAR_J.KAITO_10))
        sbSQL.Append($" ," & NameOf(_D005_CAR_J.KAITO_11))
        sbSQL.Append($" ," & NameOf(_D005_CAR_J.KAITO_12))
        sbSQL.Append($" ," & NameOf(_D005_CAR_J.KAITO_13))
        sbSQL.Append($" ," & NameOf(_D005_CAR_J.KAITO_14))
        sbSQL.Append($" ," & NameOf(_D005_CAR_J.KAITO_15))
        sbSQL.Append($" ," & NameOf(_D005_CAR_J.KAITO_16))
        sbSQL.Append($" ," & NameOf(_D005_CAR_J.KAITO_17))
        sbSQL.Append($" ," & NameOf(_D005_CAR_J.KAITO_18))
        sbSQL.Append($" ," & NameOf(_D005_CAR_J.KAITO_19))
        sbSQL.Append($" ," & NameOf(_D005_CAR_J.KAITO_20))
        sbSQL.Append($" ," & NameOf(_D005_CAR_J.KAITO_21))
        sbSQL.Append($" ," & NameOf(_D005_CAR_J.KAITO_22))
        sbSQL.Append($" ," & NameOf(_D005_CAR_J.KAITO_23))
        sbSQL.Append($" ," & NameOf(_D005_CAR_J.KAITO_24))
        sbSQL.Append($" ," & NameOf(_D005_CAR_J.KAITO_25))
        sbSQL.Append($" ," & NameOf(_D005_CAR_J.KONPON_YOIN_KB1))
        sbSQL.Append($" ," & NameOf(_D005_CAR_J.KONPON_YOIN_KB2))
        sbSQL.Append($" ," & NameOf(_D005_CAR_J.KONPON_YOIN_SYAIN_ID))
        sbSQL.Append($" ," & NameOf(_D005_CAR_J.KISEKI_KOTEI_KB))
        sbSQL.Append($" ," & NameOf(_D005_CAR_J.SYOCHI_A_SYAIN_ID))
        sbSQL.Append($" ," & NameOf(_D005_CAR_J.SYOCHI_A_YMDHNS))
        sbSQL.Append($" ," & NameOf(_D005_CAR_J.SYOCHI_B_SYAIN_ID))
        sbSQL.Append($" ," & NameOf(_D005_CAR_J.SYOCHI_B_YMDHNS))
        sbSQL.Append($" ," & NameOf(_D005_CAR_J.SYOCHI_C_SYAIN_ID))
        sbSQL.Append($" ," & NameOf(_D005_CAR_J.SYOCHI_C_YMDHNS))
        sbSQL.Append($" ," & NameOf(_D005_CAR_J.KYOIKU_FILE_PATH))
        sbSQL.Append($" ," & NameOf(_D005_CAR_J.ZESEI_SYOCHI_YUKO_UMU))
        sbSQL.Append($" ," & NameOf(_D005_CAR_J.SYOSAI_FILE_PATH))
        sbSQL.Append($" ," & NameOf(_D005_CAR_J.GOKI))
        sbSQL.Append($" ," & NameOf(_D005_CAR_J.LOT))
        sbSQL.Append($" ," & NameOf(_D005_CAR_J.KENSA_TANTO_ID))
        sbSQL.Append($" ," & NameOf(_D005_CAR_J.KENSA_TOROKU_YMDHNS))
        sbSQL.Append($" ," & NameOf(_D005_CAR_J.KENSA_GL_SYAIN_ID))
        sbSQL.Append($" ," & NameOf(_D005_CAR_J.KENSA_GL_YMDHNS))
        sbSQL.Append($" ," & NameOf(_D005_CAR_J.FILE_PATH1))
        sbSQL.Append($" ," & NameOf(_D005_CAR_J.FILE_PATH2))
        sbSQL.Append($" ," & NameOf(_D005_CAR_J.FUTEKIGO_HASSEI_YMD))
        sbSQL.Append($" ," & NameOf(_D005_CAR_J.SYOCHI_YOTEI_YMD))
        sbSQL.Append($" ," & NameOf(_D005_CAR_J.ADD_SYAIN_ID))
        sbSQL.Append($" ," & NameOf(_D005_CAR_J.ADD_YMDHNS))
        sbSQL.Append($" ," & NameOf(_D005_CAR_J.UPD_SYAIN_ID))
        sbSQL.Append($" ," & NameOf(_D005_CAR_J.UPD_YMDHNS))
        sbSQL.Append($" ," & NameOf(_D005_CAR_J.DEL_SYAIN_ID))
        sbSQL.Append($" ," & NameOf(_D005_CAR_J.DEL_YMDHNS))

#End Region

        sbSQL.Append($" ) VALUES(")
        sbSQL.Append($" '" & _D005_CAR_J.HOKOKU_NO & "'")
        sbSQL.Append($" ,'" & _D005_CAR_J.BUMON_KB & "'")
        sbSQL.Append($" ,'" & _D005_CAR_J._CLOSE_FG & "'")
        sbSQL.Append($" ,'" & _D005_CAR_J.SETUMON_1 & "'")
        sbSQL.Append($" ,'" & _D005_CAR_J.SETUMON_2 & "'")
        sbSQL.Append($" ,'" & _D005_CAR_J.SETUMON_3 & "'")
        sbSQL.Append($" ,'" & _D005_CAR_J.SETUMON_4 & "'")
        sbSQL.Append($" ,'" & _D005_CAR_J.SETUMON_5 & "'")
        sbSQL.Append($" ,'" & _D005_CAR_J.SETUMON_6 & "'")
        sbSQL.Append($" ,'" & _D005_CAR_J.SETUMON_7 & "'")
        sbSQL.Append($" ,'" & _D005_CAR_J.SETUMON_8 & "'")
        sbSQL.Append($" ,'" & _D005_CAR_J.SETUMON_9 & "'")
        sbSQL.Append($" ,'" & _D005_CAR_J.SETUMON_10 & "'")
        sbSQL.Append($" ,'" & _D005_CAR_J.SETUMON_11 & "'")
        sbSQL.Append($" ,'" & _D005_CAR_J.SETUMON_12 & "'")
        sbSQL.Append($" ,'" & _D005_CAR_J.SETUMON_13 & "'")
        sbSQL.Append($" ,'" & _D005_CAR_J.SETUMON_14 & "'")
        sbSQL.Append($" ,'" & _D005_CAR_J.SETUMON_15 & "'")
        sbSQL.Append($" ,'" & _D005_CAR_J.SETUMON_16 & "'")
        sbSQL.Append($" ,'" & _D005_CAR_J.SETUMON_17 & "'")
        sbSQL.Append($" ,'" & _D005_CAR_J.SETUMON_18 & "'")
        sbSQL.Append($" ,'" & _D005_CAR_J.SETUMON_19 & "'")
        sbSQL.Append($" ,'" & _D005_CAR_J.SETUMON_20 & "'")
        sbSQL.Append($" ,'" & _D005_CAR_J.SETUMON_21 & "'")
        sbSQL.Append($" ,'" & _D005_CAR_J.SETUMON_22 & "'")
        sbSQL.Append($" ,'" & _D005_CAR_J.SETUMON_23 & "'")
        sbSQL.Append($" ,'" & _D005_CAR_J.SETUMON_24 & "'")
        sbSQL.Append($" ,'" & _D005_CAR_J.SETUMON_25 & "'")
        sbSQL.Append($" ,'" & _D005_CAR_J.KAITO_1 & "'")
        sbSQL.Append($" ,'" & _D005_CAR_J.KAITO_2 & "'")
        sbSQL.Append($" ,'" & _D005_CAR_J.KAITO_3 & "'")
        sbSQL.Append($" ,'" & _D005_CAR_J.KAITO_4 & "'")
        sbSQL.Append($" ," & _D005_CAR_J.KAITO_5 & "")
        sbSQL.Append($" ,'" & _D005_CAR_J.KAITO_6 & "'")
        sbSQL.Append($" ,'" & _D005_CAR_J.KAITO_7 & "'")
        sbSQL.Append($" ,'" & _D005_CAR_J.KAITO_8 & "'")
        sbSQL.Append($" ,'" & _D005_CAR_J.KAITO_9 & "'")
        sbSQL.Append($" ," & _D005_CAR_J.KAITO_10 & "")
        sbSQL.Append($" ,'" & _D005_CAR_J.KAITO_11 & "'")
        sbSQL.Append($" ,'" & _D005_CAR_J.KAITO_12 & "'")
        sbSQL.Append($" ,'" & _D005_CAR_J.KAITO_13 & "'")
        sbSQL.Append($" ,'" & _D005_CAR_J.KAITO_14 & "'")
        sbSQL.Append($" ,'" & _D005_CAR_J.KAITO_15 & "'")
        sbSQL.Append($" ,'" & _D005_CAR_J.KAITO_16 & "'")
        sbSQL.Append($" ," & _D005_CAR_J.KAITO_17 & "")
        sbSQL.Append($" ,'" & _D005_CAR_J.KAITO_18 & "'")
        sbSQL.Append($" ,'" & _D005_CAR_J.KAITO_19 & "'")
        sbSQL.Append($" ,'" & _D005_CAR_J.KAITO_20 & "'")
        sbSQL.Append($" ,'" & _D005_CAR_J.KAITO_21 & "'")
        sbSQL.Append($" ,'" & _D005_CAR_J.KAITO_22 & "'")
        sbSQL.Append($" ,'" & _D005_CAR_J._KAITO_23 & "'")
        sbSQL.Append($" ,'" & _D005_CAR_J.KAITO_24 & "'")
        sbSQL.Append($" ,'" & _D005_CAR_J.KAITO_25 & "'")
        sbSQL.Append($" ,'" & _D005_CAR_J.KONPON_YOIN_KB1 & "'")
        sbSQL.Append($" ,'" & _D005_CAR_J.KONPON_YOIN_KB2 & "'")
        sbSQL.Append($" ," & _D005_CAR_J.KONPON_YOIN_SYAIN_ID & "")
        sbSQL.Append($" ,'" & _D005_CAR_J.KISEKI_KOTEI_KB & "'")
        sbSQL.Append($" ," & _D005_CAR_J.SYOCHI_A_SYAIN_ID & "")
        sbSQL.Append($" ,'" & _D005_CAR_J.SYOCHI_A_YMDHNS & "'")
        sbSQL.Append($" ," & _D005_CAR_J.SYOCHI_B_SYAIN_ID & "")
        sbSQL.Append($" ,'" & _D005_CAR_J.SYOCHI_B_YMDHNS & "'")
        sbSQL.Append($" ," & _D005_CAR_J.SYOCHI_C_SYAIN_ID & "")
        sbSQL.Append($" ,'" & _D005_CAR_J.SYOCHI_C_YMDHNS & "'")
        sbSQL.Append($" ,'" & _D005_CAR_J.KYOIKU_FILE_PATH & "'")
        sbSQL.Append($" ,'" & _D005_CAR_J._ZESEI_SYOCHI_YUKO_UMU & "'")
        sbSQL.Append($" ,'" & _D005_CAR_J.SYOSAI_FILE_PATH & "'")
        sbSQL.Append($" ,'" & _D005_CAR_J.GOKI & "'")
        sbSQL.Append($" ,'" & _D005_CAR_J.LOT & "'")
        sbSQL.Append($" ," & _D005_CAR_J.KENSA_TANTO_ID & "")
        sbSQL.Append($" ,'" & _D005_CAR_J.KENSA_TOROKU_YMDHNS & "'")
        sbSQL.Append($" ," & _D005_CAR_J.KENSA_GL_SYAIN_ID & "")
        sbSQL.Append($" ,'" & _D005_CAR_J.KENSA_GL_YMDHNS & "'")
        sbSQL.Append($" ,'" & _D005_CAR_J.FILE_PATH1 & "'")
        sbSQL.Append($" ,'" & _D005_CAR_J.FILE_PATH2 & "'")
        sbSQL.Append($" ,'" & _D005_CAR_J.FUTEKIGO_HASSEI_YMD & "'")
        sbSQL.Append($" ,'" & _D005_CAR_J.SYOCHI_YOTEI_YMD & "'")
        sbSQL.Append($" ," & _D005_CAR_J.ADD_SYAIN_ID & "")
        sbSQL.Append($" ,'" & strSysDate & "'")
        sbSQL.Append($" ," & _D005_CAR_J.UPD_SYAIN_ID & "")
        sbSQL.Append($" ,'" & _D005_CAR_J.UPD_YMDHNS & "'")
        sbSQL.Append($" ," & _D005_CAR_J.DEL_SYAIN_ID & "")
        sbSQL.Append($" ,'" & _D005_CAR_J.DEL_YMDHNS & "'")
        sbSQL.Append($")")
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
        WL.WriteLogDat($"[DEBUG]CAR 報告書NO:{_D005_CAR_J.HOKOKU_NO}、MERGE D005")

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
        _D004_SYONIN_J_KANRI.SYONIN_HOKOKUSYO_ID = Context.ENM_SYONIN_HOKOKUSYO_ID._2_CAR
        _D004_SYONIN_J_KANRI.HOKOKU_NO = _V007_FCR_J.HOKOKU_NO
        _D004_SYONIN_J_KANRI.MAIL_SEND_FG = True
        _D004_SYONIN_J_KANRI.ADD_SYAIN_ID = pub_SYAIN_INFO.SYAIN_ID
        _D004_SYONIN_J_KANRI.ADD_YMDHNS = strSysDate

        If PrCurrentStage = ENM_NCR_STAGE._10_起草入力 Then
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
        sbSQL.Append($"MERGE INTO {NameOf(MODEL.D004_SYONIN_J_KANRI)} AS SrcT")
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
            Case ENM_CAR_STAGE._130_是正有効性確認_品証担当課長
                _D004_SYONIN_J_KANRI.SYONIN_JUN = 999 'Close
                _D004_SYONIN_J_KANRI.SYONIN_HANTEI_KB = ENM_SYONIN_HANTEI_KB._1_承認
                _D004_SYONIN_J_KANRI.SYONIN_YMDHNS = strSysDate
        End Select
        _D004_SYONIN_J_KANRI.ADD_YMDHNS = strSysDate

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
                If PrCurrentStage < ENM_CAR_STAGE._130_是正有効性確認_品証担当課長 AndAlso _D004_SYONIN_J_KANRI.MAIL_SEND_FG = False Then
                    '承認依頼メール送信
                    If FunSendRequestMail() Then
                        WL.WriteLogDat($"[DEBUG]CAR 報告書NO:{_D005_CAR_J.HOKOKU_NO}、Send Request Mail")
                    End If
                End If

            Case "UPDATE"

            Case Else
                '-----エラーログ出力
                Dim strErrMsg As String = My.Resources.ErrLogSqlExecutionFailure & sbSQL.ToString & "|" & sqlEx.Message
                WL.WriteLogDat(strErrMsg)
                Return False
        End Select

        WL.WriteLogDat($"[DEBUG]CAR 報告書NO:{_D005_CAR_J.HOKOKU_NO}、MERGE D004")


        Return True
    End Function

#End Region

#Region "承認依頼メール送信"

    ''' <summary>
    ''' 承認依頼メール送信
    ''' </summary>
    ''' <returns></returns>
    Private Function FunSendRequestMail()
        Dim KISYU_NAME As String = _V002_NCR_J.KISYU_NAME
        Dim SYONIN_HANTEI_NAME As String = tblSYONIN_HANTEI_KB.AsEnumerable.Where(Function(r) r.Field(Of String)("VALUE") = _D004_SYONIN_J_KANRI.SYONIN_HANTEI_KB).FirstOrDefault?.Item("DISP")
        Dim strEXEParam As String = _D004_SYONIN_J_KANRI.SYAIN_ID & "," & ENM_OPEN_MODE._2_処置画面起動 & "," & Context.ENM_SYONIN_HOKOKUSYO_ID._2_CAR & "," & _D004_SYONIN_J_KANRI.HOKOKU_NO
        Dim strSubject As String = $"【不適合品処置依頼】[CAR] {KISYU_NAME}・{_V002_NCR_J.BUHIN_BANGO}"
        Dim strBody As String = <sql><![CDATA[
        {0} 殿<br />
        <br />
        　不適合製品の処置依頼が来ましたので対応をお願いします。<br />
        <br />
        　　【報 告 書】CAR<br />
        　　【報告書No】{1}<br />
        　　【起 草 日】{2}<br />
        　　【機　  種】{3}<br />
        　　【部品番号】{4}<br />
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
                                DateTime.ParseExact(_V002_NCR_J.ADD_YMD, "yyyyMMdd", Nothing).ToString("yyyy/MM/dd"),
                                KISYU_NAME,
                                _V002_NCR_J.BUHIN_BANGO,
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
        sbSQL.Append($"SELECT {NameOf(MODEL.R001_HOKOKU_SOUSA.HOKOKU_NO)} FROM {NameOf(MODEL.R001_HOKOKU_SOUSA)}")
        sbSQL.Append($" WHERE {NameOf(MODEL.R001_HOKOKU_SOUSA.HOKOKU_NO)} ='{_R001_HOKOKU_SOUSA.HOKOKU_NO}'")
        dsList = DB.GetDataSet(sbSQL.ToString, conblnNonMsg)
        If dsList.Tables(0).Rows.Count > 0 Then
            blnExist = True
        End If

        '-----データモデル更新
        _R001_HOKOKU_SOUSA.SYONIN_HOKOKUSYO_ID = Context.ENM_SYONIN_HOKOKUSYO_ID._2_CAR
        _R001_HOKOKU_SOUSA.HOKOKU_NO = _V002_NCR_J.HOKOKU_NO
        _R001_HOKOKU_SOUSA.SYONIN_JUN = PrCurrentStage
        _R001_HOKOKU_SOUSA.SYAIN_ID = pub_SYAIN_INFO.SYAIN_ID
        _R001_HOKOKU_SOUSA.RIYU = PrRIYU
        'UNDONE: getsysdatetime
        _R001_HOKOKU_SOUSA.ADD_YMDHNS = strSysDate 'Now.ToString("yyyyMMddHHmmss")

        Select Case enmSAVE_MODE
            Case ENM_SAVE_MODE._1_保存

                If PrCurrentStage = ENM_CAR_STAGE._999_Closed Then
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

        WL.WriteLogDat($"[DEBUG]CAR 報告書NO:{_D005_CAR_J.HOKOKU_NO}、INSERT R001")

        If FunSAVE_R004(DB, _R001_HOKOKU_SOUSA.ADD_YMDHNS) Then
        Else
            Return False
        End If



        Return True
    End Function

    Private Function FunSAVE_R004(ByRef DB As ClsDbUtility, ByVal strYMDHNS As String) As Boolean
        Dim sbSQL As New System.Text.StringBuilder
        Dim intRET As Integer
        Dim sqlEx As New Exception

        '-----MERGE
        sbSQL.Append(" INSERT INTO " & NameOf(R004_CAR_SASIMODOSI) & "(")
        sbSQL.Append(" " & NameOf(_R004.SASIMODOSI_YMDHNS))
        sbSQL.Append(" ," & NameOf(_R004.HOKOKU_NO))
        sbSQL.Append(" ," & NameOf(_R004.BUMON_KB))
        sbSQL.Append(" ," & NameOf(_R004.CLOSE_FG))
        sbSQL.Append(" ," & NameOf(_R004.SETUMON_1))
        sbSQL.Append(" ," & NameOf(_R004.SETUMON_2))
        sbSQL.Append(" ," & NameOf(_R004.SETUMON_3))
        sbSQL.Append(" ," & NameOf(_R004.SETUMON_4))
        sbSQL.Append(" ," & NameOf(_R004.SETUMON_5))
        sbSQL.Append(" ," & NameOf(_R004.SETUMON_6))
        sbSQL.Append(" ," & NameOf(_R004.SETUMON_7))
        sbSQL.Append(" ," & NameOf(_R004.SETUMON_8))
        sbSQL.Append(" ," & NameOf(_R004.SETUMON_9))
        sbSQL.Append(" ," & NameOf(_R004.SETUMON_10))
        sbSQL.Append(" ," & NameOf(_R004.SETUMON_11))
        sbSQL.Append(" ," & NameOf(_R004.SETUMON_12))
        sbSQL.Append(" ," & NameOf(_R004.SETUMON_13))
        sbSQL.Append(" ," & NameOf(_R004.SETUMON_14))
        sbSQL.Append(" ," & NameOf(_R004.SETUMON_15))
        sbSQL.Append(" ," & NameOf(_R004.SETUMON_16))
        sbSQL.Append(" ," & NameOf(_R004.SETUMON_17))
        sbSQL.Append(" ," & NameOf(_R004.SETUMON_18))
        sbSQL.Append(" ," & NameOf(_R004.SETUMON_19))
        sbSQL.Append(" ," & NameOf(_R004.SETUMON_20))
        sbSQL.Append(" ," & NameOf(_R004.SETUMON_21))
        sbSQL.Append(" ," & NameOf(_R004.SETUMON_22))
        sbSQL.Append(" ," & NameOf(_R004.SETUMON_23))
        sbSQL.Append(" ," & NameOf(_R004.SETUMON_24))
        sbSQL.Append(" ," & NameOf(_R004.SETUMON_25))
        sbSQL.Append(" ," & NameOf(_R004.KAITO_1))
        sbSQL.Append(" ," & NameOf(_R004.KAITO_2))
        sbSQL.Append(" ," & NameOf(_R004.KAITO_3))
        sbSQL.Append(" ," & NameOf(_R004.KAITO_4))
        sbSQL.Append(" ," & NameOf(_R004.KAITO_5))
        sbSQL.Append(" ," & NameOf(_R004.KAITO_6))
        sbSQL.Append(" ," & NameOf(_R004.KAITO_7))
        sbSQL.Append(" ," & NameOf(_R004.KAITO_8))
        sbSQL.Append(" ," & NameOf(_R004.KAITO_9))
        sbSQL.Append(" ," & NameOf(_R004.KAITO_10))
        sbSQL.Append(" ," & NameOf(_R004.KAITO_11))
        sbSQL.Append(" ," & NameOf(_R004.KAITO_12))
        sbSQL.Append(" ," & NameOf(_R004.KAITO_13))
        sbSQL.Append(" ," & NameOf(_R004.KAITO_14))
        sbSQL.Append(" ," & NameOf(_R004.KAITO_15))
        sbSQL.Append(" ," & NameOf(_R004.KAITO_16))
        sbSQL.Append(" ," & NameOf(_R004.KAITO_17))
        sbSQL.Append(" ," & NameOf(_R004.KAITO_18))
        sbSQL.Append(" ," & NameOf(_R004.KAITO_19))
        sbSQL.Append(" ," & NameOf(_R004.KAITO_20))
        sbSQL.Append(" ," & NameOf(_R004.KAITO_21))
        sbSQL.Append(" ," & NameOf(_R004.KAITO_22))
        sbSQL.Append(" ," & NameOf(_R004.KAITO_23))
        sbSQL.Append(" ," & NameOf(_R004.KAITO_24))
        sbSQL.Append(" ," & NameOf(_R004.KAITO_25))
        sbSQL.Append(" ," & NameOf(_R004.KONPON_YOIN_KB1))
        sbSQL.Append(" ," & NameOf(_R004.KONPON_YOIN_KB2))
        sbSQL.Append(" ," & NameOf(_R004.KONPON_YOIN_SYAIN_ID))
        sbSQL.Append(" ," & NameOf(_R004.KISEKI_KOTEI_KB))
        sbSQL.Append(" ," & NameOf(_R004.SYOCHI_A_SYAIN_ID))
        sbSQL.Append(" ," & NameOf(_R004.SYOCHI_A_YMDHNS))
        sbSQL.Append(" ," & NameOf(_R004.SYOCHI_B_SYAIN_ID))
        sbSQL.Append(" ," & NameOf(_R004.SYOCHI_B_YMDHNS))
        sbSQL.Append(" ," & NameOf(_R004.SYOCHI_C_SYAIN_ID))
        sbSQL.Append(" ," & NameOf(_R004.SYOCHI_C_YMDHNS))
        sbSQL.Append(" ," & NameOf(_R004.KYOIKU_FILE_PATH))
        sbSQL.Append(" ," & NameOf(_R004.ZESEI_SYOCHI_YUKO_UMU))
        sbSQL.Append(" ," & NameOf(_R004.SYOSAI_FILE_PATH))
        sbSQL.Append(" ," & NameOf(_R004.GOKI))
        sbSQL.Append(" ," & NameOf(_R004.LOT))
        sbSQL.Append(" ," & NameOf(_R004.KENSA_TANTO_ID))
        sbSQL.Append(" ," & NameOf(_R004.KENSA_TOROKU_YMDHNS))
        sbSQL.Append(" ," & NameOf(_R004.KENSA_GL_SYAIN_ID))
        sbSQL.Append(" ," & NameOf(_R004.KENSA_GL_YMDHNS))
        sbSQL.Append(" ," & NameOf(_R004.FILE_PATH1))
        sbSQL.Append(" ," & NameOf(_R004.FILE_PATH2))
        sbSQL.Append(" ," & NameOf(_R004.FUTEKIGO_HASSEI_YMD))
        sbSQL.Append(" ," & NameOf(_R004.SYOCHI_YOTEI_YMD))

        sbSQL.Append(" ) VALUES(")
        sbSQL.Append(" '" & strYMDHNS & "'")
        sbSQL.Append(" ,'" & _D005_CAR_J.HOKOKU_NO & "'")
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
        sbSQL.Append(" ,'" & _D005_CAR_J._KAITO_23 & "'")
        sbSQL.Append(" ,'" & _D005_CAR_J.KAITO_24 & "'")
        sbSQL.Append(" ,'" & _D005_CAR_J.KAITO_25 & "'")

        sbSQL.Append(" ,'" & _D005_CAR_J.KONPON_YOIN_KB1 & "'")
        sbSQL.Append(" ,'" & _D005_CAR_J.KONPON_YOIN_KB2 & "'")
        sbSQL.Append(" ,'" & _D005_CAR_J.KONPON_YOIN_SYAIN_ID & "'")
        sbSQL.Append(" ,'" & _D005_CAR_J.KISEKI_KOTEI_KB & "'")
        sbSQL.Append(" ,'" & _D005_CAR_J.SYOCHI_A_SYAIN_ID & "'")
        sbSQL.Append(" ,'" & _D005_CAR_J.SYOCHI_A_YMDHNS & "'")
        sbSQL.Append(" ,'" & _D005_CAR_J.SYOCHI_B_SYAIN_ID & "'")
        sbSQL.Append(" ,'" & _D005_CAR_J.SYOCHI_B_YMDHNS & "'")
        sbSQL.Append(" ,'" & _D005_CAR_J.SYOCHI_C_SYAIN_ID & "'")
        sbSQL.Append(" ,'" & _D005_CAR_J.SYOCHI_C_YMDHNS & "'")
        sbSQL.Append(" ,'" & _D005_CAR_J.KYOIKU_FILE_PATH & "'")
        sbSQL.Append(" ,'" & _D005_CAR_J._ZESEI_SYOCHI_YUKO_UMU & "'")
        sbSQL.Append(" ,'" & _D005_CAR_J.SYOSAI_FILE_PATH & "'")
        sbSQL.Append(" ,'" & _D005_CAR_J.GOKI & "'")
        sbSQL.Append(" ,'" & _D005_CAR_J.LOT & "'")
        sbSQL.Append(" ,'" & _D005_CAR_J.KENSA_TANTO_ID & "'")
        sbSQL.Append(" ,'" & _D005_CAR_J.KENSA_TOROKU_YMDHNS & "'")
        sbSQL.Append(" ,'" & _D005_CAR_J.KENSA_GL_SYAIN_ID & "'")
        sbSQL.Append(" ,'" & _D005_CAR_J.KENSA_GL_YMDHNS & "'")
        sbSQL.Append(" ,'" & _D005_CAR_J.FILE_PATH1 & "'")
        sbSQL.Append(" ,'" & _D005_CAR_J.FILE_PATH2 & "'")
        sbSQL.Append(" ,'" & _D005_CAR_J.FUTEKIGO_HASSEI_YMD & "'")
        sbSQL.Append(" ,'" & _D005_CAR_J.SYOCHI_YOTEI_YMD & "'")
        sbSQL.Append(" );")
        intRET = DB.ExecuteNonQuery(sbSQL.ToString, conblnNonMsg, sqlEx)
        If intRET <> 1 Then
            '-----エラーログ出力
            Dim strErrMsg As String = My.Resources.ErrLogSqlExecutionFailure & sbSQL.ToString & "|" & sqlEx.Message
            WL.WriteLogDat(strErrMsg)
            Return False
        Else
            WL.WriteLogDat($"[DEBUG]CAR 報告書NO:{_D005_CAR_J.HOKOKU_NO}、INSERT R004")
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
            sbSQL.Append($" {NameOf(MODEL.V007_NCR_CAR.HOKOKU_NO)},{NameOf(MODEL.V007_NCR_CAR.SYONIN_JUN)}")
            sbSQL.Append($" FROM {NameOf(MODEL.V007_NCR_CAR)} ")
            sbSQL.Append($" WHERE {NameOf(MODEL.V007_NCR_CAR.SYONIN_HOKOKUSYO_ID)}={Context.ENM_SYONIN_HOKOKUSYO_ID._1_NCR.Value}")
            sbSQL.Append($" AND {NameOf(MODEL.V007_NCR_CAR.HOKOKU_NO)}='{_D005_CAR_J.HOKOKU_NO}'")
            Using DB As ClsDbUtility = DBOpen()
                dsList = DB.GetDataSet(sbSQL.ToString, conblnNonMsg)
            End Using

            Using frmDLG As New FrmG0011
                frmDLG.PrMODE = ENM_DATA_OPERATION_MODE._3_UPDATE
                frmDLG.PrIsDialog = True
                frmDLG.PrCurrentStage = dsList.Tables(0).Rows(0).Item(NameOf(MODEL.V007_NCR_CAR.SYONIN_JUN))
                frmDLG.PrHOKOKU_NO = dsList.Tables(0).Rows(0).Item(NameOf(MODEL.V007_NCR_CAR.HOKOKU_NO))

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
            If FunMakeReportCAR(pub_APP_INFO.strOUTPUT_PATH & strOutputFileName, _D005_CAR_J.HOKOKU_NO) = False Then
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

    Private Function _FunMakeReportCAR(ByVal strFilePath As String, ByVal strHOKOKU_NO As String) As Boolean

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
            spSheet1.Range(NameOf(_V005_CAR_J.KISYU_NAME)).Value = _V005_CAR_J.KISYU_NAME
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
            'ssgPrintDocument.Print()

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
                'System.IO.File.Delete(strFilePath)
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

            If FunblnOwnCreated(Context.ENM_SYONIN_HOKOKUSYO_ID._2_CAR, PrHOKOKU_NO, PrCurrentStage) Then '
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

            If PrCurrentStage = ENM_CAR_STAGE._999_Closed Then

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

#Region "   タブ別"

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

                pnlCAR.BorderStyle = BorderStyle.FixedSingle
                pnlSYOCHI_KIROKU.BorderStyle = BorderStyle.None
                pnlZESEI_SYOCHI.BorderStyle = BorderStyle.None
                pnlST13.BorderStyle = BorderStyle.None

            Case ENM_CAR_STAGE2._8_処置実施記録入力, ENM_CAR_STAGE2._9_処置実施確認
                tabSTAGE01.ScrollControlIntoView(lblSYOCHI_KIROKUFlame)

                pnlCAR.BorderStyle = BorderStyle.None
                pnlSYOCHI_KIROKU.BorderStyle = BorderStyle.FixedSingle
                pnlZESEI_SYOCHI.BorderStyle = BorderStyle.None
                pnlST13.BorderStyle = BorderStyle.None

            Case ENM_CAR_STAGE2._10_是正有効性記入 To ENM_CAR_STAGE2._12_是正有効性確認_品証TL
                tabSTAGE01.ScrollControlIntoView(lblZESEI_SYOCHIFlame)

                pnlCAR.BorderStyle = BorderStyle.None
                pnlSYOCHI_KIROKU.BorderStyle = BorderStyle.None
                pnlZESEI_SYOCHI.BorderStyle = BorderStyle.FixedSingle
                pnlST13.BorderStyle = BorderStyle.None

            Case ENM_CAR_STAGE2._13_是正有効性確認_品証担当課長
                tabSTAGE01.ScrollControlIntoView(lblSTAGEFlame13)
                pnlCAR.BorderStyle = BorderStyle.None
                pnlSYOCHI_KIROKU.BorderStyle = BorderStyle.None
                pnlZESEI_SYOCHI.BorderStyle = BorderStyle.None
                pnlST13.BorderStyle = BorderStyle.FixedSingle

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

#End Region

#End Region

#Region "ローカル関数"

#Region "バインディング"

    Private Function FunSetBinding() As Boolean

        Try

            '更新しないものはバインドしないものとする


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
            If FunSetBinding() Then
            Else
                Return False
            End If

            If FunSetModel() Then
            Else
                Return False
            End If

            If FunSetSETUMON_NAIYO() Then
            Else
                Return False
            End If

            'ナビゲートリンク選択
            If PrCurrentStage = ENM_CAR_STAGE._999_Closed Then
                rsbtnST99.Checked = True
            Else
                Dim rbtn As RibbonShapeRadioButton = DirectCast(flpnlStageIndex.Controls("rsbtnST" & (PrCurrentStage / 10).ToString("00")), RibbonShapeRadioButton)
                rbtn.Checked = True
            End If

            mtxBUMON_KB.Text = _V002_NCR_J.BUMON_NAME
            mtxHOKUKO_NO.Text = _V002_NCR_J.HOKOKU_NO
            mtxKISYU.Text = _V002_NCR_J.KISYU_NAME
            mtxADD_SYAIN_NAME.Text = _V007_FCR_J.ADD_SYAIN_NAME
            mtxADD_SYAIN_NAME_NCR.Text = _V002_NCR_J.ADD_SYAIN_NAME
            mtxFUTEKIGO_KB.Text = _V002_NCR_J.FUTEKIGO_NAME
            mtxFUTEKIGO_S_KB.Text = _V002_NCR_J.FUTEKIGO_S_NAME
            mtxCurrentStageName.Text = FunGetLastStageName(Context.ENM_SYONIN_HOKOKUSYO_ID._2_CAR, _V007_FCR_J.HOKOKU_NO)

            mtxNextStageName.Text = FunGetStageName(Context.ENM_SYONIN_HOKOKUSYO_ID._2_CAR, FunGetNextSYONIN_JUN(PrCurrentStage))

            Dim blnOwn As Boolean = FunblnOwnCreated(Context.ENM_SYONIN_HOKOKUSYO_ID._2_CAR, _V007_FCR_J.HOKOKU_NO, PrCurrentStage)
            'tabSTAGE07.Enabled = blnOwn

            _tabPageManager = New TabPageManager(TabSTAGE)

            'SPEC: C10-2.�C
            Select Case PrCurrentStage
                Case ENM_CAR_STAGE._10_起草入力 To ENM_CAR_STAGE._70_起草確認_品証課長
                    '実質再表示の必要がないので退避させずにタブ削除
                    'TabSTAGE.TabPages.Remove(tab_CAR_SUB_1_)
                    'TabSTAGE.TabPages.Remove(tab_CAR_SUB_2_)

                    '_tabPageManager.ChangeTabPageVisible(1, False) 'tab_CAR_SUB_1_.Visible = False
                    '_tabPageManager.ChangeTabPageVisible(2, False)'tab_CAR_SUB_2_.Visible = False
                    pnlCAR.DisableContaints(blnOwn, PanelEx.ENM_PROPERTY._2_ReadOnly)

                    pnlSYOCHI_KIROKU.Visible = False
                    pnlZESEI_SYOCHI.Visible = False
                    pnlST13.Visible = False
                    'pnlST05.Visible = (PrCurrentStage = ENM_CAR_STAGE._50_起草確認_設計開発)
                    'pnlAnalysis.Visible = (PrCurrentStage = ENM_CAR_STAGE._70_起草確認_品証課長)

                Case ENM_CAR_STAGE._80_処置実施記録入力, ENM_CAR_STAGE._90_処置実施確認
                    tabSTAGE01.EnableDisablePages(False)

                    'tab_CAR_SUB_1_.Enabled = blnOwn 'tab_CAR_SUB_1_.EnableDisablePages(blnOwn)
                    'TabSTAGE.TabPages.Remove(tab_CAR_SUB_2_)
                    pnlCAR.DisableContaints(False, PanelEx.ENM_PROPERTY._2_ReadOnly)
                    'pnlST05.DisableContaints(False, PanelEx.ENM_PROPERTY._2_ReadOnly)
                    pnlSYOCHI_KIROKU.DisableContaints(blnOwn, PanelEx.ENM_PROPERTY._2_ReadOnly)
                    pnlZESEI_SYOCHI.Visible = False
                    pnlST13.Visible = False
                    'lblKYOIKU_FILE_PATH_Clear.Enabled = blnOwn
                    'pnlAnalysis.Visible = True

                Case ENM_CAR_STAGE._100_是正有効性記入 To ENM_CAR_STAGE._130_是正有効性確認_品証担当課長

                    pnlCAR.DisableContaints(False, PanelEx.ENM_PROPERTY._2_ReadOnly)
                    pnlSYOCHI_KIROKU.DisableContaints(False, PanelEx.ENM_PROPERTY._2_ReadOnly)
                    pnlZESEI_SYOCHI.DisableContaints(blnOwn, PanelEx.ENM_PROPERTY._2_ReadOnly)
                    'pnlST05.DisableContaints(False, PanelEx.ENM_PROPERTY._2_ReadOnly)
                    'tab_CAR_SUB_1_.Enabled = False 'tab_CAR_SUB_1_.EnableDisablePages(False)
                    'tab_CAR_SUB_2_.Enabled = blnOwn 'tab_CAR_SUB_2_.EnableDisablePages(blnOwn)
                    'lblKYOIKU_FILE_PATH_Clear.Enabled = False

                    'If PrCurrentStage = ENM_CAR_STAGE._130_是正有効性確認_品証担当課長 Then
                    '    pnlST13.Visible = True
                    '    btnST13_SYONIN.Enabled = blnOwn
                    '    dtST13_KAKUNIN.ReadOnly = Not blnOwn
                    '    lblSYOSAI_FILE_PATH_Clear.Enabled = False
                    'Else
                    '    pnlST13.Visible = False
                    'End If
                    'pnlAnalysis.Visible = True

                Case ENM_CAR_STAGE._999_Closed
                    'tabSTAGE02.EnableDisablePages(False)

                    If IsEditingClosed Then
                        pnlCAR.DisableContaints(True, PanelEx.ENM_PROPERTY._2_ReadOnly)
                        pnlSYOCHI_KIROKU.DisableContaints(True, PanelEx.ENM_PROPERTY._2_ReadOnly)
                        pnlZESEI_SYOCHI.DisableContaints(True, PanelEx.ENM_PROPERTY._2_ReadOnly)

                        'lbltmpFile1_Clear.Enabled = True
                        'lbltmpFile2_Clear.Enabled = True
                        'btnOpentmpFile1.Enabled = True
                        'btnOpentmpFile2.Enabled = True
                        'lblKYOIKU_FILE_PATH_Clear.Enabled = True
                        'lblSYOSAI_FILE_PATH_Clear.Enabled = True
                    Else
                        pnlCAR.DisableContaints(False, PanelEx.ENM_PROPERTY._2_ReadOnly)
                        pnlSYOCHI_KIROKU.DisableContaints(False, PanelEx.ENM_PROPERTY._2_ReadOnly)
                        pnlZESEI_SYOCHI.DisableContaints(False, PanelEx.ENM_PROPERTY._2_ReadOnly)
                        'pnlST05.DisableContaints(False, PanelEx.ENM_PROPERTY._2_ReadOnly)

                        'lbltmpFile1_Clear.Enabled = False
                        'lbltmpFile2_Clear.Enabled = False
                        'btnOpentmpFile1.Enabled = False
                        'btnOpentmpFile2.Enabled = False
                        'lblKYOIKU_FILE_PATH_Clear.Enabled = False
                        'lblSYOSAI_FILE_PATH_Clear.Enabled = False
                    End If

                    pnlST13.Visible = False
                    'pnlAnalysis.Visible = True

                Case Else
            End Select

            If PrCurrentStage >= ENM_CAR_STAGE._70_起草確認_品証課長 And (_V007_FCR_J.KISEKI_KOTEI_KB.IsNulOrWS Or _V007_FCR_J.KONPON_YOIN_SYAIN_ID = 0) Then
                'lblMessage.Visible = True
            End If

            For Each val As Integer In [Enum].GetValues(GetType(ENM_CAR_STAGE2))
                flpnlStageIndex.Controls("rsbtnST" & val.ToString("00")).Enabled = (PrCurrentStage / 10) >= val
                If (PrCurrentStage / 10) >= val Then
                Else
                    flpnlStageIndex.Controls("rsbtnST" & val.ToString("00")).BackColor = Color.Silver
                End If
            Next val
            'rsbtnST05.Enabled = CBool(_V005_CAR_J.KAITO_23)
            If _V007_FCR_J.CLOSE_FG = False Then
                flpnlStageIndex.Controls("rsbtnST99").Enabled = False
                flpnlStageIndex.Controls("rsbtnST99").BackColor = Color.Silver
            End If

            If PrCurrentStage >= ENM_CAR_STAGE._130_是正有効性確認_品証担当課長 Then
                lblDestTANTO.Visible = False
                cmbDestTANTO.Visible = False
            End If

            Dim _V003 As New MODEL.V003_SYONIN_J_KANRI
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

            'Call RbtnKAITO_14_CheckedChanged(rbtnKAITO_14_F, Nothing)

            'txtKAITO_1.Focus()
            ErrorProvider.ClearError(cmbDestTANTO)

            Return True
        Catch ex As Exception
            EM.ErrorSyori(ex, False, conblnNonMsg)
            Return False
        End Try
    End Function

    Private Function FunSetSETUMON_NAIYO() As Boolean
        Try

            _D005_CAR_J.SETUMON_1 = tblSETUMON_NAIYO.AsEnumerable.Where(Function(r) r.Field(Of String)("VALUE") = 1).First.Item("DISP")
            _D005_CAR_J.SETUMON_2 = tblSETUMON_NAIYO.AsEnumerable.Where(Function(r) r.Field(Of String)("VALUE") = 2).First.Item("DISP")
            _D005_CAR_J.SETUMON_3 = tblSETUMON_NAIYO.AsEnumerable.Where(Function(r) r.Field(Of String)("VALUE") = 3).First.Item("DISP")
            _D005_CAR_J.SETUMON_4 = tblSETUMON_NAIYO.AsEnumerable.Where(Function(r) r.Field(Of String)("VALUE") = 4).First.Item("DISP")
            _D005_CAR_J.SETUMON_5 = tblSETUMON_NAIYO.AsEnumerable.Where(Function(r) r.Field(Of String)("VALUE") = 5).First.Item("DISP")
            _D005_CAR_J.SETUMON_6 = tblSETUMON_NAIYO.AsEnumerable.Where(Function(r) r.Field(Of String)("VALUE") = 6).First.Item("DISP")
            _D005_CAR_J.SETUMON_7 = tblSETUMON_NAIYO.AsEnumerable.Where(Function(r) r.Field(Of String)("VALUE") = 7).First.Item("DISP")
            _D005_CAR_J.SETUMON_8 = tblSETUMON_NAIYO.AsEnumerable.Where(Function(r) r.Field(Of String)("VALUE") = 8).First.Item("DISP")
            _D005_CAR_J.SETUMON_9 = tblSETUMON_NAIYO.AsEnumerable.Where(Function(r) r.Field(Of String)("VALUE") = 9).First.Item("DISP")
            _D005_CAR_J.SETUMON_10 = tblSETUMON_NAIYO.AsEnumerable.Where(Function(r) r.Field(Of String)("VALUE") = 10).First.Item("DISP")
            _D005_CAR_J.SETUMON_11 = tblSETUMON_NAIYO.AsEnumerable.Where(Function(r) r.Field(Of String)("VALUE") = 11).First.Item("DISP")
            _D005_CAR_J.SETUMON_12 = tblSETUMON_NAIYO.AsEnumerable.Where(Function(r) r.Field(Of String)("VALUE") = 12).First.Item("DISP")
            _D005_CAR_J.SETUMON_13 = tblSETUMON_NAIYO.AsEnumerable.Where(Function(r) r.Field(Of String)("VALUE") = 13).First.Item("DISP")
            _D005_CAR_J.SETUMON_14 = tblSETUMON_NAIYO.AsEnumerable.Where(Function(r) r.Field(Of String)("VALUE") = 14).First.Item("DISP")
            _D005_CAR_J.SETUMON_15 = tblSETUMON_NAIYO.AsEnumerable.Where(Function(r) r.Field(Of String)("VALUE") = 15).First.Item("DISP")
            _D005_CAR_J.SETUMON_16 = tblSETUMON_NAIYO.AsEnumerable.Where(Function(r) r.Field(Of String)("VALUE") = 16).First.Item("DISP")
            _D005_CAR_J.SETUMON_17 = tblSETUMON_NAIYO.AsEnumerable.Where(Function(r) r.Field(Of String)("VALUE") = 17).First.Item("DISP")
            _D005_CAR_J.SETUMON_18 = tblSETUMON_NAIYO.AsEnumerable.Where(Function(r) r.Field(Of String)("VALUE") = 18).First.Item("DISP")
            _D005_CAR_J.SETUMON_19 = tblSETUMON_NAIYO.AsEnumerable.Where(Function(r) r.Field(Of String)("VALUE") = 19).First.Item("DISP")
            _D005_CAR_J.SETUMON_20 = tblSETUMON_NAIYO.AsEnumerable.Where(Function(r) r.Field(Of String)("VALUE") = 20).First.Item("DISP")
            _D005_CAR_J.SETUMON_21 = tblSETUMON_NAIYO.AsEnumerable.Where(Function(r) r.Field(Of String)("VALUE") = 21).First.Item("DISP")
            _D005_CAR_J.SETUMON_22 = tblSETUMON_NAIYO.AsEnumerable.Where(Function(r) r.Field(Of String)("VALUE") = 22).First.Item("DISP")
            _D005_CAR_J.SETUMON_23 = tblSETUMON_NAIYO.AsEnumerable.Where(Function(r) r.Field(Of String)("VALUE") = 23).First.Item("DISP")

            Return True
        Catch ex As Exception
            EM.ErrorSyori(ex, False, conblnNonMsg)
            Return False
        End Try
    End Function

    Private Function FunSetModel() As Boolean
        Try
            Dim sbSQL As New System.Text.StringBuilder
            Dim dsList As New DataSet
            Dim InList As New List(Of Integer)
            _V002_NCR_J.Clear()
            _V002_NCR_J = FunGetV002Model(PrHOKOKU_NO)

            _V003_SYONIN_J_KANRI_List = FunGetV003Model(Context.ENM_SYONIN_HOKOKUSYO_ID._2_CAR, PrHOKOKU_NO)

            _D005_CAR_J.Clear()
            _V007_FCR_J = FunGetV005Model(PrHOKOKU_NO)

            'データソース設定
            Dim dt As DataTable = FunGetSYOZOKU_SYAIN(_V002_NCR_J.BUMON_KB)
            Dim drs As IEnumerable(Of DataRow)

            'cmbKONPON_YOIN_TANTO.SetDataSource(tblTANTO.ExcludeDeleted, ENM_COMBO_SELECT_VALUE_TYPE._2_Option)

            'InList.Clear() : InList.AddRange({ENM_GYOMU_GROUP_ID._1_技術.Value, ENM_GYOMU_GROUP_ID._2_製造.Value, ENM_GYOMU_GROUP_ID._3_検査.Value, ENM_GYOMU_GROUP_ID._4_品証.Value})
            'drs = dt.AsEnumerable.Where(Function(r) InList.Contains(r.Field(Of Integer)(NameOf(M011_SYAIN_GYOMU.GYOMU_GROUP_ID))))
            'If drs.Count > 0 Then cmbKAITO_5.SetDataSource(drs.CopyToDataTable, ENM_COMBO_SELECT_VALUE_TYPE._0_Required)

            'InList.Clear() : InList.AddRange({ENM_GYOMU_GROUP_ID._1_技術.Value, ENM_GYOMU_GROUP_ID._2_製造.Value, ENM_GYOMU_GROUP_ID._3_検査.Value, ENM_GYOMU_GROUP_ID._4_品証.Value})
            'drs = dt.AsEnumerable.Where(Function(r) InList.Contains(r.Field(Of Integer)(NameOf(M011_SYAIN_GYOMU.GYOMU_GROUP_ID))))
            'If drs.Count > 0 Then cmbKAITO_10.SetDataSource(drs.CopyToDataTable, ENM_COMBO_SELECT_VALUE_TYPE._0_Required)

            'InList.Clear() : InList.AddRange({ENM_GYOMU_GROUP_ID._1_技術.Value, ENM_GYOMU_GROUP_ID._2_製造.Value, ENM_GYOMU_GROUP_ID._3_検査.Value, ENM_GYOMU_GROUP_ID._4_品証.Value})
            'drs = dt.AsEnumerable.Where(Function(r) InList.Contains(r.Field(Of Integer)(NameOf(M011_SYAIN_GYOMU.GYOMU_GROUP_ID))))
            'If drs.Count > 0 Then cmbKAITO_17.SetDataSource(drs.CopyToDataTable, ENM_COMBO_SELECT_VALUE_TYPE._0_Required)

            'drs = dt.AsEnumerable.Where(Function(r) r.Field(Of Boolean)("IS_LEADER") = True)
            'If drs.Count > 0 Then cmbSYOCHI_A_TANTO.SetDataSource(drs.CopyToDataTable, ENM_COMBO_SELECT_VALUE_TYPE._2_Option)

            'drs = dt.AsEnumerable.Where(Function(r) r.Field(Of Boolean)("IS_LEADER") = True)
            'If drs.Count > 0 Then cmbSYOCHI_B_TANTO.SetDataSource(drs.CopyToDataTable, ENM_COMBO_SELECT_VALUE_TYPE._2_Option)

            'drs = dt.AsEnumerable.Where(Function(r) r.Field(Of Boolean)("IS_LEADER") = True)
            'If drs.Count > 0 Then cmbSYOCHI_C_TANTO.SetDataSource(drs.CopyToDataTable, ENM_COMBO_SELECT_VALUE_TYPE._2_Option)

            'InList.Clear() : InList.AddRange({ENM_GYOMU_GROUP_ID._3_検査.Value})
            'drs = dt.AsEnumerable.Where(Function(r) InList.Contains(r.Field(Of Integer)(NameOf(M011_SYAIN_GYOMU.GYOMU_GROUP_ID))))
            'If drs.Count > 0 Then cmbKENSA_TANTO.SetDataSource(drs.CopyToDataTable, ENM_COMBO_SELECT_VALUE_TYPE._2_Option)

            'InList.Clear() : InList.AddRange({ENM_GYOMU_GROUP_ID._3_検査.Value})
            'drs = dt.AsEnumerable.Where(Function(r) InList.Contains(r.Field(Of Integer)(NameOf(M011_SYAIN_GYOMU.GYOMU_GROUP_ID))) And r.Field(Of Boolean)("IS_LEADER") = True)
            'If drs.Count > 0 Then cmbKENSA_GL_TANTO.SetDataSource(drs.CopyToDataTable, ENM_COMBO_SELECT_VALUE_TYPE._2_Option)

            dt = FunGetSYONIN_SYOZOKU_SYAIN(_V002_NCR_J.BUMON_KB, Context.ENM_SYONIN_HOKOKUSYO_ID._2_CAR, FunGetNextSYONIN_JUN(PrCurrentStage))
            cmbDestTANTO.SetDataSource(dt, ENM_COMBO_SELECT_VALUE_TYPE._0_Required)

            _D005_CAR_J.FUTEKIGO_HASSEI_YMD = _V002_NCR_J.HASSEI_YMD

            _D005_CAR_J.HOKOKU_NO = _V007_FCR_J.HOKOKU_NO
            _D005_CAR_J.BUMON_KB = _V007_FCR_J.BUMON_KB
            _D005_CAR_J.CLOSE_FG = _V007_FCR_J.CLOSE_FG

            _D005_CAR_J.SETUMON_1 = _V007_FCR_J.SETUMON_1
            _D005_CAR_J.KAITO_1 = _V007_FCR_J.KAITO_1
            _D005_CAR_J.SETUMON_2 = _V007_FCR_J.SETUMON_2
            _D005_CAR_J.KAITO_2 = _V007_FCR_J.KAITO_2
            _D005_CAR_J.SETUMON_3 = _V007_FCR_J.SETUMON_3
            _D005_CAR_J.KAITO_3 = _V007_FCR_J.KAITO_3
            _D005_CAR_J.SETUMON_4 = _V007_FCR_J.SETUMON_4
            _D005_CAR_J.KAITO_4 = _V007_FCR_J.KAITO_4
            _D005_CAR_J.SETUMON_5 = _V007_FCR_J.SETUMON_5
            _D005_CAR_J.KAITO_5 = _V007_FCR_J.KAITO_5
            _D005_CAR_J.SETUMON_6 = _V007_FCR_J.SETUMON_6
            _D005_CAR_J.KAITO_6 = _V007_FCR_J.KAITO_6
            _D005_CAR_J.SETUMON_7 = _V007_FCR_J.SETUMON_7
            _D005_CAR_J.KAITO_7 = _V007_FCR_J.KAITO_7
            _D005_CAR_J.SETUMON_8 = _V007_FCR_J.SETUMON_8
            _D005_CAR_J.KAITO_8 = _V007_FCR_J.KAITO_8
            _D005_CAR_J.SETUMON_9 = _V007_FCR_J.SETUMON_9
            _D005_CAR_J.KAITO_9 = _V007_FCR_J.KAITO_9
            _D005_CAR_J.SETUMON_10 = _V007_FCR_J.SETUMON_10
            _D005_CAR_J.KAITO_10 = _V007_FCR_J.KAITO_10
            _D005_CAR_J.SETUMON_11 = _V007_FCR_J.SETUMON_11
            _D005_CAR_J.KAITO_11 = _V007_FCR_J.KAITO_11
            _D005_CAR_J.SETUMON_12 = _V007_FCR_J.SETUMON_12
            _D005_CAR_J.KAITO_12 = _V007_FCR_J.KAITO_12
            _D005_CAR_J.SETUMON_13 = _V007_FCR_J.SETUMON_13
            _D005_CAR_J.KAITO_13 = _V007_FCR_J.KAITO_13
            _D005_CAR_J.SETUMON_14 = _V007_FCR_J.SETUMON_14
            _D005_CAR_J.KAITO_14 = _V007_FCR_J.KAITO_14
            'chkKAITO_14.Checked = IIf(_V005_CAR_J.KAITO_14 = "1", True, False)

            _D005_CAR_J.SETUMON_15 = _V007_FCR_J.SETUMON_15
            _D005_CAR_J.KAITO_15 = _V007_FCR_J.KAITO_15
            _D005_CAR_J.SETUMON_16 = _V007_FCR_J.SETUMON_16
            _D005_CAR_J.KAITO_16 = _V007_FCR_J.KAITO_16
            _D005_CAR_J.SETUMON_17 = _V007_FCR_J.SETUMON_17
            _D005_CAR_J.KAITO_17 = _V007_FCR_J.KAITO_17
            _D005_CAR_J.SETUMON_18 = _V007_FCR_J.SETUMON_18
            _D005_CAR_J.KAITO_18 = _V007_FCR_J.KAITO_18
            _D005_CAR_J.SETUMON_19 = _V007_FCR_J.SETUMON_19
            _D005_CAR_J.KAITO_19 = _V007_FCR_J.KAITO_19
            _D005_CAR_J.SETUMON_20 = _V007_FCR_J.SETUMON_20
            _D005_CAR_J.KAITO_20 = _V007_FCR_J.KAITO_20
            _D005_CAR_J.SETUMON_21 = _V007_FCR_J.SETUMON_21
            _D005_CAR_J.KAITO_21 = _V007_FCR_J.KAITO_21
            _D005_CAR_J.SETUMON_22 = _V007_FCR_J.SETUMON_22
            _D005_CAR_J.KAITO_22 = _V007_FCR_J.KAITO_22
            _D005_CAR_J.SETUMON_23 = _V007_FCR_J.SETUMON_23
            _D005_CAR_J.KAITO_23 = IIf(_V007_FCR_J.KAITO_23 = "1", True, False)
            rbtnKOKYAKU_EIKYO_HANTEI_KB_T.Checked = IIf(_V007_FCR_J.KAITO_23 = "1", True, False)
            rbtnKOKYAKU_EIKYO_HANTEI_KB_F.Checked = IIf(_V007_FCR_J.KAITO_23 = "0", True, False)

            _D005_CAR_J.SETUMON_24 = _V007_FCR_J.SETUMON_24
            _D005_CAR_J.KAITO_24 = _V007_FCR_J.KAITO_24
            _D005_CAR_J.SETUMON_25 = _V007_FCR_J.SETUMON_25
            _D005_CAR_J.KAITO_25 = _V007_FCR_J.KAITO_25

            _D005_CAR_J.KONPON_YOIN_KB1 = _V007_FCR_J.KONPON_YOIN_KB1
            'If Not _V005_CAR_J.KONPON_YOIN_KB1.IsNulOrWS Then
            '    btnSelectGenin1.Enabled = True
            'End If
            '_D005_CAR_J.KONPON_YOIN_KB2 = _V005_CAR_J.KONPON_YOIN_KB2
            'If Not _V005_CAR_J.KONPON_YOIN_KB2.IsNulOrWS Then
            '    btnSelectGenin2.Enabled = True
            'End If

            _D005_CAR_J.FUTEKIGO_HASSEI_YMD = _V007_FCR_J.FUTEKIGO_HASSEI_YMD
            _D005_CAR_J.KONPON_YOIN_SYAIN_ID = _V007_FCR_J.KONPON_YOIN_SYAIN_ID
            _D005_CAR_J.KISEKI_KOTEI_KB = _V007_FCR_J.KISEKI_KOTEI_KB
            _D005_CAR_J.SYOCHI_A_SYAIN_ID = _V007_FCR_J.SYOCHI_A_SYAIN_ID
            _D005_CAR_J.SYOCHI_A_YMDHNS = _V007_FCR_J.SYOCHI_A_YMDHNS.Trim
            _D005_CAR_J.SYOCHI_B_SYAIN_ID = _V007_FCR_J.SYOCHI_B_SYAIN_ID
            _D005_CAR_J.SYOCHI_B_YMDHNS = _V007_FCR_J.SYOCHI_B_YMDHNS.Trim
            _D005_CAR_J.SYOCHI_C_SYAIN_ID = _V007_FCR_J.SYOCHI_C_SYAIN_ID
            _D005_CAR_J.SYOCHI_C_YMDHNS = _V007_FCR_J.SYOCHI_C_YMDHNS.Trim

            _D005_CAR_J.ZESEI_SYOCHI_YUKO_UMU = CBool(_V007_FCR_J.ZESEI_SYOCHI_YUKO_UMU.ToVal)

            _D005_CAR_J.GOKI = _V007_FCR_J.GOKI
            _D005_CAR_J.LOT = _V007_FCR_J.LOT
            _D005_CAR_J.KENSA_TANTO_ID = _V007_FCR_J.KENSA_TANTO_ID
            _D005_CAR_J.KENSA_TOROKU_YMDHNS = _V007_FCR_J.KENSA_TOROKU_YMDHNS.Trim
            _D005_CAR_J.KENSA_GL_SYAIN_ID = _V007_FCR_J.KENSA_GL_SYAIN_ID
            _D005_CAR_J.KENSA_GL_YMDHNS = _V007_FCR_J.KENSA_GL_YMDHNS.Trim
            _D005_CAR_J.ADD_SYAIN_ID = _V007_FCR_J.ADD_SYAIN_ID
            _D005_CAR_J.ADD_YMDHNS = _V007_FCR_J.ADD_YMDHNS.Trim
            _D005_CAR_J.UPD_SYAIN_ID = _V007_FCR_J.UPD_SYAIN_ID
            _D005_CAR_J.UPD_YMDHNS = _V007_FCR_J.UPD_YMDHNS.Trim
            _D005_CAR_J.DEL_SYAIN_ID = _V007_FCR_J.DEL_SYAIN_ID
            _D005_CAR_J.DEL_YMDHNS = _V007_FCR_J.DEL_YMDHNS.Trim

            _D005_CAR_J.KYOIKU_FILE_PATH = _V007_FCR_J.KYOIKU_FILE_PATH
            _D005_CAR_J.SYOSAI_FILE_PATH = _V007_FCR_J.SYOSAI_FILE_PATH
            _D005_CAR_J.FILE_PATH1 = _V007_FCR_J.FILE_PATH1
            _D005_CAR_J.FILE_PATH2 = _V007_FCR_J.FILE_PATH2
            If _V007_FCR_J.SYOCHI_YOTEI_YMD >= Today.ToString("yyyyMMdd") Then
                _D005_CAR_J.SYOCHI_YOTEI_YMD = _V007_FCR_J.SYOCHI_YOTEI_YMD
            Else
                _D005_CAR_J.SYOCHI_YOTEI_YMD = ""
            End If


            '#128
            If PrCurrentStage = ENM_CAR_STAGE._10_起草入力 AndAlso Not IsRemanded(_D005_CAR_J.HOKOKU_NO) Then
                _D005_CAR_J.ADD_SYAIN_ID = pub_SYAIN_INFO.SYAIN_ID
            End If

            '原因分析区分
            _D006_CAR_GENIN_List.Clear()

            sbSQL.Remove(0, sbSQL.Length)
            sbSQL.Append($"SELECT")
            sbSQL.Append($" *")
            sbSQL.Append($" FROM {NameOf(MODEL.V006_CAR_GENIN)}")
            sbSQL.Append($" WHERE {NameOf(MODEL.V006_CAR_GENIN.HOKOKU_NO)}='{PrHOKOKU_NO}'")
            sbSQL.Append($" ORDER BY {NameOf(MODEL.V006_CAR_GENIN.RENBAN)}")
            Using DB As ClsDbUtility = DBOpen()
                dsList = DB.GetDataSet(sbSQL.ToString, conblnNonMsg)
            End Using


            Return True
        Catch ex As Exception
            EM.ErrorSyori(ex, False, conblnNonMsg)
            Return False
        End Try
    End Function

    Private Sub BtnST13_SYONIN_Click(sender As Object, e As EventArgs)
        cmdFunc2.PerformClick()
    End Sub

#End Region

#Region "入力チェック"

    Private Function FunCheckInput(ByVal enmSAVE_MODE As ENM_SAVE_MODE) As Boolean
        Try
            'フラグリセット
            IsValidated = True
            '-----共通
            If enmSAVE_MODE = ENM_SAVE_MODE._2_承認申請 Then
                '-----ステージ別
                Select Case PrCurrentStage
                    Case ENM_CAR_STAGE._10_起草入力 To ENM_CAR_STAGE._80_処置実施記録入力
                        'Call CmbDestTANTO_Validating(cmbDestTANTO, Nothing)
                        'Call ＤtKAITO_4_Validating(dtKAITO_4, Nothing)
                        'Call CmbKAITO_5_Validating(cmbKAITO_5, Nothing)
                        'Call KAITO_678_Validating(mtxKAITO_6, Nothing)
                        'Call DtKAITO_9_Validating(dtKAITO_9, Nothing)
                        'Call cmbKAITO_10_Validating(cmbKAITO_10, Nothing)
                        'Call KAITO_111213_Validating(mtxKAITO_11, Nothing)
                        'Call dtKAITO_16_Validating(dtKAITO_16, Nothing)
                        'Call cmbKAITO_17_Validating(cmbKAITO_17, Nothing)
                        'Call KAITO_181920_Validating(mtxKAITO_18, Nothing)



                    Case ENM_CAR_STAGE._90_処置実施確認 To ENM_CAR_STAGE._100_是正有効性記入
                        'Call CmbDestTANTO_Validating(cmbDestTANTO, Nothing)
                    Case ENM_CAR_STAGE._110_是正有効性確認_検査GL To ENM_CAR_STAGE._120_是正有効性確認_品証TL
                        'Call CmbDestTANTO_Validating(cmbDestTANTO, Nothing)
                        'Call mtxGOKI_Validating(mtxGOKI, Nothing)

                    Case ENM_CAR_STAGE._130_是正有効性確認_品証担当課長
                        'Call ＤtST13_Validating(dtST13_KAKUNIN, Nothing)
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

    Private Sub TxtKAITO_21_Validating(sender As Object, e As System.ComponentModel.CancelEventArgs)
        Dim txt As TextBoxEx = DirectCast(sender, TextBoxEx)

        IsValidated *= ErrorProvider.UpdateErrorInfo(txt, txt.ReadOnly OrElse Not txt.Text.IsNulOrWS, String.Format(My.Resources.infoMsgRequireSelectOrInput, "修正応急処置:内容"))

    End Sub

    Private Sub TxtKAITO_22_Validating(sender As Object, e As System.ComponentModel.CancelEventArgs) Handles txtTUCHI_SYUDAN.Validating, txtHITUYO_TETUDUKI_ZIKO.Validating, TextBoxEx4.Validating, TextBoxEx3.Validating
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
        sbSQL.Append($" FROM {NameOf(MODEL.V003_SYONIN_J_KANRI)} ")
        sbSQL.Append($" WHERE {NameOf(MODEL.V003_SYONIN_J_KANRI.SYONIN_HOKOKUSYO_ID)}={intSYONIN_HOKOKUSYO_ID}")
        sbSQL.Append($" AND {NameOf(MODEL.V003_SYONIN_J_KANRI.HOKOKU_NO)}='{strHOKOKU_NO.Trim}'")
        sbSQL.Append($" ORDER BY {NameOf(MODEL.V003_SYONIN_J_KANRI.SYONIN_JUN)} DESC")
        Using DB As ClsDbUtility = DBOpen()
            dsList = DB.GetDataSet(sbSQL.ToString, conblnNonMsg)
        End Using

        With dsList.Tables(0)
            If .Rows.Count = 0 Then
                Return ""
            Else
                Return .Rows(0).Item(NameOf(MODEL.V003_SYONIN_J_KANRI.SYONIN_NAIYO)) '.Rows(0).Item("SYONIN_JUN") & "." & .Rows(0).Item("SYONIN_NAIYO")
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
                Case ENM_CAR_STAGE._130_是正有効性確認_品証担当課長, ENM_CAR_STAGE._999_Closed
                    Return ENM_CAR_STAGE._999_Closed
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
            sbSQL.Append($" COUNT({NameOf(MODEL.R004_CAR_SASIMODOSI.HOKOKU_NO)})")
            sbSQL.Append($" FROM {NameOf(MODEL.R004_CAR_SASIMODOSI)} ")
            sbSQL.Append($" WHERE {NameOf(MODEL.R004_CAR_SASIMODOSI.HOKOKU_NO)}='{strHOKOKU_NO}'")
            Using DB As ClsDbUtility = DBOpen()
                intRET = DB.ExecuteScalar(sbSQL.ToString, conblnNonMsg)
            End Using

            Return intRET > 0
        End If
    End Function



#End Region

End Class