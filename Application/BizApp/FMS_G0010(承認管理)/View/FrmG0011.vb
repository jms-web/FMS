Imports JMS_COMMON.ClsPubMethod


Public Class FrmG0011

#Region "定数・変数"
    ''' <summary>
    ''' タブ非表示管理用
    ''' </summary>
    Private _tabPageManager As TabPageManager
    Private _tabPageManagerST08Sub As TabPageManager

    Private Enum ENM_SAVE_MODE
        _1_保存 = 1
        _2_承認申請 = 2
    End Enum

    '80 NCR処置実施 タブページ
    Private Enum ENM_STAGE80_TABPAGES
        _1_廃却実施記録 = 1
        _2_返却実施記録 = 2
        _3_転用先記録 = 3
        _4_再加工指示_記録 = 4
    End Enum


    'Model
    Private _V002_NCR_J As New MODEL.V002_NCR_J
    Private _V003_SYONIN_J_KANRI_List As New List(Of MODEL.V003_SYONIN_J_KANRI)

    '入力必須コントロール検証判定
    Private pri_blnValidated As Boolean

    '是正処置要否判定=CAR編集画面起動判定
    Private blnEnableCAREdit As Boolean




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
        cmbKISO_TANTO.Enabled = False
        pnlPict1.AllowDrop = True
        pnlPict2.AllowDrop = True

        'UNDONE: Enable FalseのForeColorを指定したい

        '先頭ウォーターマーク+バインドが必要なコンボボックスのための設定
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
        cmbST05_DestTANTO.NullValue = 0
        cmbST06_DestTANTO.NullValue = 0
        cmbST07_DestTANTO.NullValue = 0
        cmbST08_DestTANTO.NullValue = 0
        cmbST09_DestTANTO.NullValue = 0
        cmbST10_DestTANTO.NullValue = 0
        cmbST11_DestTANTO.NullValue = 0
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
            cmbKISO_TANTO.SetDataSource(tblTANTO, ENM_COMBO_SELECT_VALUE_TYPE._0_Required)

            cmbBUMON.SetDataSource(tblBUMON.ExcludeDeleted, ENM_COMBO_SELECT_VALUE_TYPE._0_Required)
            cmbKISYU.SetDataSource(tblKISYU.ExcludeDeleted, ENM_COMBO_SELECT_VALUE_TYPE._0_Required)
            cmbBUHIN_BANGO.SetDataSource(tblBUHIN.ExcludeDeleted, ENM_COMBO_SELECT_VALUE_TYPE._0_Required)
            cmbFUTEKIGO_STATUS.SetDataSource(tblFUTEKIGO_STATUS_KB.ExcludeDeleted, ENM_COMBO_SELECT_VALUE_TYPE._0_Required)
            cmbFUTEKIGO_KB.SetDataSource(tblFUTEKIGO_KB.ExcludeDeleted, ENM_COMBO_SELECT_VALUE_TYPE._0_Required)
            cmbSYANAI_CD.SetDataSource(tblSYANAI_CD.ExcludeDeleted, ENM_COMBO_SELECT_VALUE_TYPE._0_Required)

            'モデルリセット
            _D003_NCR_J.Clear()
            _D004_SYONIN_J_KANRI.clear()
            _D005_CAR_J.Clear()
            _R001_HOKOKU_SOUSA.clear()
            _R002_HOKOKU_TENSO.clear()
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
                    If FunCheckInput() Then
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
                    If FunCheckInput() Then
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
                                If PrCurrentStage = ENM_NCR_STAGE._80_処置実施 AndAlso _D003_NCR_J.KENSA_KEKKA_KB = ENM_KENSA_KEKKA_KB._1_不合格 Then
                                    If MessageBox.Show("再不適合処置データを続けて作成しますか?", "再不適合処置確認", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes Then
                                        Call FunSAVE_D003_SAI_FUTEKIGO()
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
                    Call OpenFormTENSO()
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
                    Call OpenFormHistory()

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

#Region "保存・承認申請"

    ''' <summary>
    ''' 保存・承認申請処理メイン
    ''' </summary>
    ''' <param name="enmSAVE_MODE"></param>
    ''' <returns></returns>
    Private Function FunSAVE(ByVal enmSAVE_MODE As ENM_SAVE_MODE) As Boolean
        Try

            Using DB As ClsDbUtility = DBOpen()
                Dim blnErr As Boolean
                Try '-----トランザクション
                    DB.BeginTransaction()


                    Select Case PrCurrentStage
                        Case ENM_NCR_STAGE._81_処置実施_生技 To ENM_NCR_STAGE._100_処置実施決裁_製造課長
                            'データは更新しない
                        Case Else
                            If FunSAVE_FILE(DB) Then
                            Else
                                Return False
                                blnErr = True
                            End If
                            'SPEC: 2.(3).D.①.レコード更新
                            If FunSAVE_D003(DB) Then
                            Else
                                Return False
                                blnErr = True
                            End If
                    End Select

                    '
                    If FunSAVE_D004(DB, enmSAVE_MODE) Then
                    Else
                        Return False
                        blnErr = True
                    End If

                    '
                    If FunSAVE_R001(DB, enmSAVE_MODE) Then
                    Else
                        Return False
                        blnErr = True
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
                    Return True
                End If
            Else
                Try
                    If Not _D003_NCR_J.FILE_PATH.IsNullOrWhiteSpace AndAlso _D003_NCR_J.FILE_PATH <> strRootDir & System.IO.Path.GetFileName(_D003_NCR_J.FILE_PATH) Then
                        System.IO.File.Copy(_D003_NCR_J.FILE_PATH, strRootDir & System.IO.Path.GetFileName(_D003_NCR_J.FILE_PATH), True)
                        _D003_NCR_J.FILE_PATH = strRootDir & System.IO.Path.GetFileName(_D003_NCR_J.FILE_PATH)
                    End If
                    If Not _D003_NCR_J.G_FILE_PATH1.IsNullOrWhiteSpace AndAlso _D003_NCR_J.G_FILE_PATH1 <> strRootDir & System.IO.Path.GetFileName(_D003_NCR_J.G_FILE_PATH1) Then
                        System.IO.File.Copy(_D003_NCR_J.G_FILE_PATH1, strRootDir & System.IO.Path.GetFileName(_D003_NCR_J.G_FILE_PATH1), True)
                        _D003_NCR_J.G_FILE_PATH1 = strRootDir & System.IO.Path.GetFileName(_D003_NCR_J.G_FILE_PATH1)
                    End If
                    If Not _D003_NCR_J.G_FILE_PATH2.IsNullOrWhiteSpace AndAlso _D003_NCR_J.G_FILE_PATH2 <> strRootDir & System.IO.Path.GetFileName(_D003_NCR_J.G_FILE_PATH2) Then
                        System.IO.File.Copy(_D003_NCR_J.G_FILE_PATH2, strRootDir & System.IO.Path.GetFileName(_D003_NCR_J.G_FILE_PATH2), True)
                        _D003_NCR_J.G_FILE_PATH2 = strRootDir & System.IO.Path.GetFileName(_D003_NCR_J.G_FILE_PATH2)
                    End If

                    Return True

                Catch exIO As UnauthorizedAccessException
                    strMsg = "添付ファイル保存先のアクセス権限がありません。" & vbCrLf &
                             "添付ファイル保存先:" & strRootDir
                    MessageBox.Show(strMsg, "ファイル保存先アクセス不可", MessageBoxButtons.OK, MessageBoxIcon.Error)
                End Try
            End If
        End If
    End Function

    ''' <summary>
    ''' NCR実績更新
    ''' </summary>
    ''' <param name="DB"></param>
    ''' <returns></returns>
    Private Function FunSAVE_D003(ByRef DB As ClsDbUtility) As Boolean
        Dim sbSQL As New System.Text.StringBuilder
        Dim strRET As String
        Dim sqlEx As New Exception

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
                _D003_NCR_J.HOKOKU_NO = DB.DbCommand.Parameters("HOKOKU_NO").Value
            Else
                Return False
            End If
        End If

        '-----モデル更新
        If PrCurrentStage = ENM_NCR_STAGE._80_処置実施 AndAlso _D003_NCR_J.KENSA_KEKKA_KB = ENM_KENSA_KEKKA_KB._1_不合格 Then
            _D003_NCR_J.CLOSE_FG = 1
        End If

        '-----MERGE
        sbSQL.Remove(0, sbSQL.Length)
        sbSQL.Append("MERGE INTO " & NameOf(MODEL.D003_NCR_J) & " AS SrcT")
        sbSQL.Append(" USING (")
        sbSQL.Append(" SELECT")
        sbSQL.Append(" '" & _D003_NCR_J.HOKOKU_NO & "' AS " & NameOf(_D003_NCR_J.HOKOKU_NO))
        sbSQL.Append(" ,'" & _D003_NCR_J.BUMON_KB & "' AS " & NameOf(_D003_NCR_J.BUMON_KB))
        sbSQL.Append(" ,'" & _D003_NCR_J._CLOSE_FG & "' AS " & NameOf(_D003_NCR_J.CLOSE_FG))
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
        sbSQL.Append(" ,'" & _D003_NCR_J._ZESEI_SYOCHI_YOHI_KB & "' AS " & NameOf(_D003_NCR_J.ZESEI_SYOCHI_YOHI_KB))
        sbSQL.Append(" ,'" & _D003_NCR_J.ZESEI_NASI_RIYU & "' AS " & NameOf(_D003_NCR_J.ZESEI_NASI_RIYU))
        sbSQL.Append(" ,'" & _D003_NCR_J.JIZEN_SINSA_HANTEI_KB & "' AS " & NameOf(_D003_NCR_J.JIZEN_SINSA_HANTEI_KB))
        sbSQL.Append(" ," & _D003_NCR_J.JIZEN_SINSA_SYAIN_ID & " AS " & NameOf(_D003_NCR_J.JIZEN_SINSA_SYAIN_ID))

        sbSQL.Append(" ,'" & _D003_NCR_J.JIZEN_SINSA_YMD & "' AS " & NameOf(_D003_NCR_J.JIZEN_SINSA_YMD))
        sbSQL.Append(" ," & _D003_NCR_J.SAISIN_KAKUNIN_SYAIN_ID & " AS " & NameOf(_D003_NCR_J.SAISIN_KAKUNIN_SYAIN_ID))
        sbSQL.Append(" ,'" & _D003_NCR_J.SAISIN_KAKUNIN_YMD & "' AS " & NameOf(_D003_NCR_J.SAISIN_KAKUNIN_YMD))
        sbSQL.Append(" ,'" & _D003_NCR_J.SAISIN_IINKAI_HANTEI_KB & "' AS " & NameOf(_D003_NCR_J.SAISIN_IINKAI_HANTEI_KB))
        sbSQL.Append(" ," & _D003_NCR_J.SAISIN_GIJYUTU_SYAIN_ID & " AS " & NameOf(_D003_NCR_J.SAISIN_GIJYUTU_SYAIN_ID))
        sbSQL.Append(" ,'" & _D003_NCR_J.SAISIN_GIJYUTU_YMD & "' AS " & NameOf(_D003_NCR_J.SAISIN_GIJYUTU_YMD))
        sbSQL.Append(" ," & _D003_NCR_J.SAISIN_HINSYO_SYAIN_ID & " AS " & NameOf(_D003_NCR_J.SAISIN_HINSYO_SYAIN_ID))
        sbSQL.Append(" ,'" & _D003_NCR_J.SAISIN_HINSYO_YMD & "' AS " & NameOf(_D003_NCR_J.SAISIN_HINSYO_YMD))
        sbSQL.Append(" ,'" & _D003_NCR_J.SAISIN_IINKAI_SIRYO_NO & "' AS " & NameOf(_D003_NCR_J.SAISIN_IINKAI_SIRYO_NO))
        sbSQL.Append(" ,'" & _D003_NCR_J.ITAG_NO & "' AS " & NameOf(_D003_NCR_J.ITAG_NO))
        sbSQL.Append(" ," & _D003_NCR_J.KOKYAKU_SAISIN_TANTO_ID & " AS " & NameOf(_D003_NCR_J.KOKYAKU_SAISIN_TANTO_ID))
        sbSQL.Append(" ,'" & _D003_NCR_J.KOKYAKU_SAISIN_YMD & "' AS " & NameOf(_D003_NCR_J.KOKYAKU_SAISIN_YMD))
        sbSQL.Append(" ,'" & _D003_NCR_J.KOKYAKU_HANTEI_SIJI_KB & "' AS " & NameOf(_D003_NCR_J.KOKYAKU_HANTEI_SIJI_KB))
        sbSQL.Append(" ,'" & _D003_NCR_J.KOKYAKU_HANTEI_SIJI_YMD & "' AS " & NameOf(_D003_NCR_J.KOKYAKU_HANTEI_SIJI_YMD))
        sbSQL.Append(" ,'" & _D003_NCR_J.KOKYAKU_SAISYU_HANTEI_KB & "' AS " & NameOf(_D003_NCR_J.KOKYAKU_SAISYU_HANTEI_KB))
        sbSQL.Append(" ,'" & _D003_NCR_J.KOKYAKU_SAISYU_HANTEI_YMD & "' AS " & NameOf(_D003_NCR_J.KOKYAKU_SAISYU_HANTEI_YMD))
        sbSQL.Append(" ,'" & _D003_NCR_J._SAIKAKO_SIJI_FG & "' AS " & NameOf(_D003_NCR_J.SAIKAKO_SIJI_FG))
        sbSQL.Append(" ,'" & _D003_NCR_J.HAIKYAKU_YMD & "' AS " & NameOf(_D003_NCR_J.HAIKYAKU_YMD))
        sbSQL.Append(" ,'" & _D003_NCR_J.HAIKYAKU_KB & "' AS " & NameOf(_D003_NCR_J.HAIKYAKU_KB))
        sbSQL.Append(" ,'" & _D003_NCR_J.HAIKYAKU_HOUHOU & "' AS " & NameOf(_D003_NCR_J.HAIKYAKU_HOUHOU))
        sbSQL.Append(" ," & _D003_NCR_J.HAIKYAKU_TANTO_ID & " AS " & NameOf(_D003_NCR_J.HAIKYAKU_TANTO_ID))
        sbSQL.Append(" ,'" & _D003_NCR_J.SAIKAKO_SIJI_NO & "' AS " & NameOf(_D003_NCR_J.SAIKAKO_SIJI_NO))
        sbSQL.Append(" ,'" & _D003_NCR_J.SAIKAKO_SAGYO_KAN_YMD & "' AS " & NameOf(_D003_NCR_J.SAIKAKO_SAGYO_KAN_YMD))
        sbSQL.Append(" ,'" & _D003_NCR_J.SAIKAKO_KENSA_YMD & "' AS " & NameOf(_D003_NCR_J.SAIKAKO_KENSA_YMD))
        sbSQL.Append(" ,'" & _D003_NCR_J.KENSA_KEKKA_KB & "' AS " & NameOf(_D003_NCR_J.KENSA_KEKKA_KB))
        sbSQL.Append(" ," & _D003_NCR_J.SEIGI_TANTO_ID & " AS " & NameOf(_D003_NCR_J.SEIGI_TANTO_ID))
        sbSQL.Append(" ," & _D003_NCR_J.SEIZO_TANTO_ID & " AS " & NameOf(_D003_NCR_J.SEIZO_TANTO_ID))
        sbSQL.Append(" ," & _D003_NCR_J.KENSA_TANTO_ID & " AS " & NameOf(_D003_NCR_J.KENSA_TANTO_ID))
        sbSQL.Append(" ,'" & _D003_NCR_J.HENKYAKU_YMD & "' AS " & NameOf(_D003_NCR_J.HENKYAKU_YMD))
        sbSQL.Append(" ,'" & _D003_NCR_J.HENKYAKU_SAKI & "' AS " & NameOf(_D003_NCR_J.HENKYAKU_SAKI))
        sbSQL.Append(" ," & _D003_NCR_J.HENKYAKU_TANTO_ID & " AS " & NameOf(_D003_NCR_J.HENKYAKU_TANTO_ID))
        sbSQL.Append(" ,'" & _D003_NCR_J.HENKYAKU_BIKO & "' AS " & NameOf(_D003_NCR_J.HENKYAKU_BIKO))
        sbSQL.Append(" ," & _D003_NCR_J.TENYO_KISYU_ID & " AS " & NameOf(_D003_NCR_J.TENYO_KISYU_ID))
        sbSQL.Append(" ,'" & _D003_NCR_J.TENYO_BUHIN_BANGO & "' AS " & NameOf(_D003_NCR_J.TENYO_BUHIN_BANGO))
        sbSQL.Append(" ,'" & _D003_NCR_J.TENYO_GOKI & "' AS " & NameOf(_D003_NCR_J.TENYO_GOKI))
        sbSQL.Append(" ," & _D003_NCR_J.TENYO_LOT & " AS " & NameOf(_D003_NCR_J.TENYO_LOT))
        sbSQL.Append(" ,'" & _D003_NCR_J.TENYO_YMD & "' AS " & NameOf(_D003_NCR_J.TENYO_YMD))
        sbSQL.Append(" ,'" & _D003_NCR_J._SYOCHI_KEKKA_A & "' AS " & NameOf(_D003_NCR_J.SYOCHI_KEKKA_A))
        sbSQL.Append(" ,'" & _D003_NCR_J._SYOCHI_KEKKA_B & "' AS " & NameOf(_D003_NCR_J.SYOCHI_KEKKA_B))
        sbSQL.Append(" ,'" & _D003_NCR_J._SYOCHI_KEKKA_C & "' AS " & NameOf(_D003_NCR_J.SYOCHI_KEKKA_C))
        sbSQL.Append(" ,'" & _D003_NCR_J._SYOCHI_D_UMU_KB & "' AS " & NameOf(_D003_NCR_J.SYOCHI_D_UMU_KB))
        sbSQL.Append(" ,'" & _D003_NCR_J._SYOCHI_D_YOHI_KB & "' AS " & NameOf(_D003_NCR_J.SYOCHI_D_YOHI_KB))
        sbSQL.Append(" ,'" & _D003_NCR_J.SYOCHI_D_SYOCHI_KIROKU & "' AS " & NameOf(_D003_NCR_J.SYOCHI_D_SYOCHI_KIROKU))
        sbSQL.Append(" ,'" & _D003_NCR_J._SYOCHI_E_UMU_KB & "' AS " & NameOf(_D003_NCR_J.SYOCHI_E_UMU_KB))
        sbSQL.Append(" ,'" & _D003_NCR_J._SYOCHI_E_YOHI_KB & "' AS " & NameOf(_D003_NCR_J.SYOCHI_E_YOHI_KB))
        sbSQL.Append(" ,'" & _D003_NCR_J.SYOCHI_E_SYOCHI_KIROKU & "' AS " & NameOf(_D003_NCR_J.SYOCHI_E_SYOCHI_KIROKU))

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
        sbSQL.Append(" ,SrcT." & NameOf(_D003_NCR_J.CLOSE_FG) & " = WK." & NameOf(_D003_NCR_J.CLOSE_FG))
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
        sbSQL.Append(" ,SrcT." & NameOf(_D003_NCR_J.KANSATU_KEKKA) & " = WK." & NameOf(_D003_NCR_J.KANSATU_KEKKA))

        sbSQL.Append(" ,SrcT." & NameOf(_D003_NCR_J.ZESEI_SYOCHI_YOHI_KB) & " = WK." & NameOf(_D003_NCR_J.ZESEI_SYOCHI_YOHI_KB))
        sbSQL.Append(" ,SrcT." & NameOf(_D003_NCR_J.ZESEI_NASI_RIYU) & " = WK." & NameOf(_D003_NCR_J.ZESEI_NASI_RIYU))
        sbSQL.Append(" ,SrcT." & NameOf(_D003_NCR_J.JIZEN_SINSA_HANTEI_KB) & " = WK." & NameOf(_D003_NCR_J.JIZEN_SINSA_HANTEI_KB))
        sbSQL.Append(" ,SrcT." & NameOf(_D003_NCR_J.JIZEN_SINSA_SYAIN_ID) & " = WK." & NameOf(_D003_NCR_J.JIZEN_SINSA_SYAIN_ID))
        sbSQL.Append(" ,SrcT." & NameOf(_D003_NCR_J.JIZEN_SINSA_YMD) & " = WK." & NameOf(_D003_NCR_J.JIZEN_SINSA_YMD))
        sbSQL.Append(" ,SrcT." & NameOf(_D003_NCR_J.SAISIN_KAKUNIN_SYAIN_ID) & " = WK." & NameOf(_D003_NCR_J.SAISIN_KAKUNIN_SYAIN_ID))
        sbSQL.Append(" ,SrcT." & NameOf(_D003_NCR_J.SAISIN_KAKUNIN_YMD) & " = WK." & NameOf(_D003_NCR_J.SAISIN_KAKUNIN_YMD))
        sbSQL.Append(" ,SrcT." & NameOf(_D003_NCR_J.SAISIN_IINKAI_HANTEI_KB) & " = WK." & NameOf(_D003_NCR_J.SAISIN_IINKAI_HANTEI_KB))
        sbSQL.Append(" ,SrcT." & NameOf(_D003_NCR_J.SAISIN_GIJYUTU_SYAIN_ID) & " = WK." & NameOf(_D003_NCR_J.SAISIN_GIJYUTU_SYAIN_ID))
        sbSQL.Append(" ,SrcT." & NameOf(_D003_NCR_J.SAISIN_GIJYUTU_YMD) & " = WK." & NameOf(_D003_NCR_J.SAISIN_GIJYUTU_YMD))
        sbSQL.Append(" ,SrcT." & NameOf(_D003_NCR_J.SAISIN_HINSYO_SYAIN_ID) & " = WK." & NameOf(_D003_NCR_J.SAISIN_HINSYO_SYAIN_ID))
        sbSQL.Append(" ,SrcT." & NameOf(_D003_NCR_J.SAISIN_HINSYO_YMD) & " = WK." & NameOf(_D003_NCR_J.SAISIN_HINSYO_YMD))
        sbSQL.Append(" ,SrcT." & NameOf(_D003_NCR_J.SAISIN_IINKAI_SIRYO_NO) & " = WK." & NameOf(_D003_NCR_J.SAISIN_IINKAI_SIRYO_NO))
        sbSQL.Append(" ,SrcT." & NameOf(_D003_NCR_J.ITAG_NO) & " = WK." & NameOf(_D003_NCR_J.ITAG_NO))
        sbSQL.Append(" ,SrcT." & NameOf(_D003_NCR_J.KOKYAKU_SAISIN_TANTO_ID) & " = WK." & NameOf(_D003_NCR_J.KOKYAKU_SAISIN_TANTO_ID))
        sbSQL.Append(" ,SrcT." & NameOf(_D003_NCR_J.KOKYAKU_SAISIN_YMD) & " = WK." & NameOf(_D003_NCR_J.KOKYAKU_SAISIN_YMD))
        sbSQL.Append(" ,SrcT." & NameOf(_D003_NCR_J.KOKYAKU_HANTEI_SIJI_KB) & " = WK." & NameOf(_D003_NCR_J.KOKYAKU_HANTEI_SIJI_KB))
        sbSQL.Append(" ,SrcT." & NameOf(_D003_NCR_J.KOKYAKU_HANTEI_SIJI_YMD) & " = WK." & NameOf(_D003_NCR_J.KOKYAKU_HANTEI_SIJI_YMD))
        sbSQL.Append(" ,SrcT." & NameOf(_D003_NCR_J.KOKYAKU_SAISYU_HANTEI_KB) & " = WK." & NameOf(_D003_NCR_J.KOKYAKU_SAISYU_HANTEI_KB))
        sbSQL.Append(" ,SrcT." & NameOf(_D003_NCR_J.KOKYAKU_SAISYU_HANTEI_YMD) & " = WK." & NameOf(_D003_NCR_J.KOKYAKU_SAISYU_HANTEI_YMD))
        sbSQL.Append(" ,SrcT." & NameOf(_D003_NCR_J.SAIKAKO_SIJI_FG) & " = WK." & NameOf(_D003_NCR_J.SAIKAKO_SIJI_FG))
        sbSQL.Append(" ,SrcT." & NameOf(_D003_NCR_J.HAIKYAKU_YMD) & " = WK." & NameOf(_D003_NCR_J.HAIKYAKU_YMD))
        sbSQL.Append(" ,SrcT." & NameOf(_D003_NCR_J.HAIKYAKU_KB) & " = WK." & NameOf(_D003_NCR_J.HAIKYAKU_KB))
        sbSQL.Append(" ,SrcT." & NameOf(_D003_NCR_J.HAIKYAKU_HOUHOU) & " = WK." & NameOf(_D003_NCR_J.HAIKYAKU_HOUHOU))
        sbSQL.Append(" ,SrcT." & NameOf(_D003_NCR_J.HAIKYAKU_TANTO_ID) & " = WK." & NameOf(_D003_NCR_J.HAIKYAKU_TANTO_ID))
        sbSQL.Append(" ,SrcT." & NameOf(_D003_NCR_J.SAIKAKO_SIJI_NO) & " = WK." & NameOf(_D003_NCR_J.SAIKAKO_SIJI_NO))
        sbSQL.Append(" ,SrcT." & NameOf(_D003_NCR_J.SAIKAKO_SAGYO_KAN_YMD) & " = WK." & NameOf(_D003_NCR_J.SAIKAKO_SAGYO_KAN_YMD))
        sbSQL.Append(" ,SrcT." & NameOf(_D003_NCR_J.SAIKAKO_KENSA_YMD) & " = WK." & NameOf(_D003_NCR_J.SAIKAKO_KENSA_YMD))
        sbSQL.Append(" ,SrcT." & NameOf(_D003_NCR_J.KENSA_KEKKA_KB) & " = WK." & NameOf(_D003_NCR_J.KENSA_KEKKA_KB))
        sbSQL.Append(" ,SrcT." & NameOf(_D003_NCR_J.SEIGI_TANTO_ID) & " = WK." & NameOf(_D003_NCR_J.SEIGI_TANTO_ID))
        sbSQL.Append(" ,SrcT." & NameOf(_D003_NCR_J.SEIZO_TANTO_ID) & " = WK." & NameOf(_D003_NCR_J.SEIZO_TANTO_ID))
        sbSQL.Append(" ,SrcT." & NameOf(_D003_NCR_J.KENSA_TANTO_ID) & " = WK." & NameOf(_D003_NCR_J.KENSA_TANTO_ID))
        sbSQL.Append(" ,SrcT." & NameOf(_D003_NCR_J.HENKYAKU_YMD) & " = WK." & NameOf(_D003_NCR_J.HENKYAKU_YMD))
        sbSQL.Append(" ,SrcT." & NameOf(_D003_NCR_J.HENKYAKU_SAKI) & " = WK." & NameOf(_D003_NCR_J.HENKYAKU_SAKI))
        sbSQL.Append(" ,SrcT." & NameOf(_D003_NCR_J.HENKYAKU_TANTO_ID) & " = WK." & NameOf(_D003_NCR_J.HENKYAKU_TANTO_ID))
        sbSQL.Append(" ,SrcT." & NameOf(_D003_NCR_J.HENKYAKU_BIKO) & " = WK." & NameOf(_D003_NCR_J.HENKYAKU_BIKO))
        sbSQL.Append(" ,SrcT." & NameOf(_D003_NCR_J.TENYO_KISYU_ID) & " = WK." & NameOf(_D003_NCR_J.TENYO_KISYU_ID))
        sbSQL.Append(" ,SrcT." & NameOf(_D003_NCR_J.TENYO_BUHIN_BANGO) & " = WK." & NameOf(_D003_NCR_J.TENYO_BUHIN_BANGO))
        sbSQL.Append(" ,SrcT." & NameOf(_D003_NCR_J.TENYO_GOKI) & " = WK." & NameOf(_D003_NCR_J.TENYO_GOKI))
        sbSQL.Append(" ,SrcT." & NameOf(_D003_NCR_J.TENYO_LOT) & " = WK." & NameOf(_D003_NCR_J.TENYO_LOT))
        sbSQL.Append(" ,SrcT." & NameOf(_D003_NCR_J.TENYO_YMD) & " = WK." & NameOf(_D003_NCR_J.TENYO_YMD))
        sbSQL.Append(" ,SrcT." & NameOf(_D003_NCR_J.SYOCHI_KEKKA_A) & " = WK." & NameOf(_D003_NCR_J.SYOCHI_KEKKA_A))
        sbSQL.Append(" ,SrcT." & NameOf(_D003_NCR_J.SYOCHI_KEKKA_B) & " = WK." & NameOf(_D003_NCR_J.SYOCHI_KEKKA_B))
        sbSQL.Append(" ,SrcT." & NameOf(_D003_NCR_J.SYOCHI_KEKKA_C) & " = WK." & NameOf(_D003_NCR_J.SYOCHI_KEKKA_C))
        sbSQL.Append(" ,SrcT." & NameOf(_D003_NCR_J.SYOCHI_D_UMU_KB) & " = WK." & NameOf(_D003_NCR_J.SYOCHI_D_UMU_KB))
        sbSQL.Append(" ,SrcT." & NameOf(_D003_NCR_J.SYOCHI_D_YOHI_KB) & " = WK." & NameOf(_D003_NCR_J.SYOCHI_D_YOHI_KB))
        sbSQL.Append(" ,SrcT." & NameOf(_D003_NCR_J.SYOCHI_D_SYOCHI_KIROKU) & " = WK." & NameOf(_D003_NCR_J.SYOCHI_D_SYOCHI_KIROKU))
        sbSQL.Append(" ,SrcT." & NameOf(_D003_NCR_J.SYOCHI_E_UMU_KB) & " = WK." & NameOf(_D003_NCR_J.SYOCHI_E_UMU_KB))
        sbSQL.Append(" ,SrcT." & NameOf(_D003_NCR_J.SYOCHI_E_YOHI_KB) & " = WK." & NameOf(_D003_NCR_J.SYOCHI_E_YOHI_KB))
        sbSQL.Append(" ,SrcT." & NameOf(_D003_NCR_J.SYOCHI_E_SYOCHI_KIROKU) & " = WK." & NameOf(_D003_NCR_J.SYOCHI_E_SYOCHI_KIROKU))

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
        sbSQL.Append(" ,'0'") 'sbSQL.Append(" ," & NameOf(_D003_NCR_J.JIZEN_SINSA_HANTEI_KB))
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
        '---
        sbSQL.Append(" ,WK." & NameOf(_D003_NCR_J.FILE_PATH))
        sbSQL.Append(" ,WK." & NameOf(_D003_NCR_J.G_FILE_PATH1))
        sbSQL.Append(" ,WK." & NameOf(_D003_NCR_J.G_FILE_PATH2))
        sbSQL.Append(" ,WK." & NameOf(_D003_NCR_J.ADD_SYAIN_ID))
        sbSQL.Append(" ,WK." & NameOf(_D003_NCR_J.ADD_YMDHNS))
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
                'SPEC: 40-1
                If PrCurrentStage = ENM_NCR_STAGE._40_事前審査判定及びCAR要否判定 And _D003_NCR_J.ZESEI_SYOCHI_YOHI_KB = ENM_YOHI_KB._1_要 Then
                    If FunSAVE_D005(DB) Then
                        blnEnableCAREdit = True
                    Else
                        Return False
                    End If
                End If

            Case "UPDATE"

            Case Else
                '-----エラーログ出力
                Dim strErrMsg As String = My.Resources.ErrLogSqlExecutionFailure & sbSQL.ToString & "|" & sqlEx.Message
                WL.WriteLogDat(strErrMsg)
                Return False
        End Select

        Return True
    End Function

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

        '-----データモデル更新
        _D004_SYONIN_J_KANRI.SYONIN_HOKOKUSYO_ID = ENM_SYONIN_HOKOKUSYO_ID._1_NCR
        _D004_SYONIN_J_KANRI.HOKOKU_NO = _D003_NCR_J.HOKOKU_NO
        _D004_SYONIN_J_KANRI.MAIL_SEND_FG = True
        _D004_SYONIN_J_KANRI.ADD_SYAIN_ID = pub_SYAIN_INFO.SYAIN_ID
        '-----レコード保存
        Select Case enmSAVE_MODE
            Case ENM_SAVE_MODE._1_保存
                _D004_SYONIN_J_KANRI.SYONIN_JUN = PrCurrentStage
                _D004_SYONIN_J_KANRI.SYONIN_HANTEI_KB = ENM_SYONIN_HANTEI_KB._0_未承認
            Case ENM_SAVE_MODE._2_承認申請
                _D004_SYONIN_J_KANRI.SYONIN_JUN = PrCurrentStage
                _D004_SYONIN_J_KANRI.SYONIN_HANTEI_KB = ENM_SYONIN_HANTEI_KB._1_承認
                'UNDONE: getsysdate server
                _D004_SYONIN_J_KANRI.SYONIN_YMDHNS = Now.ToString("yyyyMMddHHmmss")
            Case Else
                'Err
                Return False
        End Select
        '-----MERGE
        sbSQL.Remove(0, sbSQL.Length)
        sbSQL.Append("MERGE INTO " & NameOf(MODEL.D004_SYONIN_J_KANRI) & " AS SrcT")
        sbSQL.Append(" USING (")
        sbSQL.Append(" SELECT")
        sbSQL.Append(" " & _D004_SYONIN_J_KANRI.SYONIN_HOKOKUSYO_ID & " AS " & NameOf(_D004_SYONIN_J_KANRI.SYONIN_HOKOKUSYO_ID))
        sbSQL.Append(" ,'" & _D004_SYONIN_J_KANRI.HOKOKU_NO & "' AS " & NameOf(_D004_SYONIN_J_KANRI.HOKOKU_NO))
        sbSQL.Append(" ," & _D004_SYONIN_J_KANRI.SYONIN_JUN & " AS " & NameOf(_D004_SYONIN_J_KANRI.SYONIN_JUN))
        sbSQL.Append(" ,'" & _D004_SYONIN_J_KANRI.SYAIN_ID & "' AS " & NameOf(_D004_SYONIN_J_KANRI.SYAIN_ID))
        sbSQL.Append(" ,'" & _D004_SYONIN_J_KANRI.SYONIN_YMDHNS & "' AS " & NameOf(_D004_SYONIN_J_KANRI.SYONIN_YMDHNS))
        sbSQL.Append(" ,'" & _D004_SYONIN_J_KANRI.SYONIN_HANTEI_KB & "' AS " & NameOf(_D004_SYONIN_J_KANRI.SYONIN_HANTEI_KB))
        sbSQL.Append(" ,'" & _D004_SYONIN_J_KANRI._SASIMODOSI_FG & "' AS " & NameOf(_D004_SYONIN_J_KANRI.SASIMODOSI_FG))
        sbSQL.Append(" ,'" & _D004_SYONIN_J_KANRI.RIYU & "' AS " & NameOf(_D004_SYONIN_J_KANRI.RIYU))
        sbSQL.Append(" ,'" & _D004_SYONIN_J_KANRI.COMMENT & "' AS " & NameOf(_D004_SYONIN_J_KANRI.COMMENT))
        sbSQL.Append(" ,'" & _D004_SYONIN_J_KANRI._MAIL_SEND_FG & "' AS " & NameOf(_D004_SYONIN_J_KANRI.MAIL_SEND_FG))
        sbSQL.Append(" ," & _D004_SYONIN_J_KANRI.ADD_SYAIN_ID & " AS " & NameOf(_D004_SYONIN_J_KANRI.ADD_SYAIN_ID))
        sbSQL.Append(" ,dbo.GetSysDateString() AS " & NameOf(_D004_SYONIN_J_KANRI.ADD_YMDHNS))
        sbSQL.Append(" ," & pub_SYAIN_INFO.SYAIN_ID & " AS " & NameOf(_D004_SYONIN_J_KANRI.UPD_SYAIN_ID))
        sbSQL.Append(" ,dbo.GetSysDateString() AS " & NameOf(_D004_SYONIN_J_KANRI.UPD_YMDHNS))
        sbSQL.Append(" ) AS WK")
        sbSQL.Append(" ON (SrcT." & NameOf(_D004_SYONIN_J_KANRI.SYONIN_HOKOKUSYO_ID) & " = WK." & NameOf(_D004_SYONIN_J_KANRI.SYONIN_HOKOKUSYO_ID) & "")
        sbSQL.Append(" AND SrcT." & NameOf(_D004_SYONIN_J_KANRI.HOKOKU_NO) & " = WK." & NameOf(_D004_SYONIN_J_KANRI.HOKOKU_NO) & "")
        sbSQL.Append(" AND SrcT." & NameOf(_D004_SYONIN_J_KANRI.SYONIN_JUN) & " = WK." & NameOf(_D004_SYONIN_J_KANRI.SYONIN_JUN) & ")")
        'UPDATE
        sbSQL.Append(" WHEN MATCHED THEN")
        sbSQL.Append(" UPDATE SET")
        sbSQL.Append("  SrcT." & NameOf(_D004_SYONIN_J_KANRI.SYAIN_ID) & " = WK." & NameOf(_D004_SYONIN_J_KANRI.SYAIN_ID))
        sbSQL.Append(" ,SrcT." & NameOf(_D004_SYONIN_J_KANRI.UPD_SYAIN_ID) & " = WK." & NameOf(_D004_SYONIN_J_KANRI.UPD_SYAIN_ID))
        sbSQL.Append(" ,SrcT." & NameOf(_D004_SYONIN_J_KANRI.COMMENT) & " = WK." & NameOf(_D004_SYONIN_J_KANRI.COMMENT))
        sbSQL.Append(" ,SrcT." & NameOf(_D004_SYONIN_J_KANRI.UPD_YMDHNS) & " = WK." & NameOf(_D004_SYONIN_J_KANRI.UPD_YMDHNS))
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
        sbSQL.Append(" ," & pub_SYAIN_INFO.SYAIN_ID & "")
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
                _D004_SYONIN_J_KANRI.SYAIN_ID = FunGetNextSYONIN_TANTO_ID(PrCurrentStage)
                _D004_SYONIN_J_KANRI.SYONIN_YMDHNS = ""
                _D004_SYONIN_J_KANRI.MAIL_SEND_FG = False
            Case Else
                'Err
                Return False
        End Select

        '-----MERGE
        sbSQL.Remove(0, sbSQL.Length)
        sbSQL.Append("MERGE INTO " & NameOf(MODEL.D004_SYONIN_J_KANRI) & " AS SrcT")
        sbSQL.Append(" USING (")
        sbSQL.Append(" SELECT")
        sbSQL.Append(" " & _D004_SYONIN_J_KANRI.SYONIN_HOKOKUSYO_ID & " AS " & NameOf(_D004_SYONIN_J_KANRI.SYONIN_HOKOKUSYO_ID))
        sbSQL.Append(" ,'" & _D004_SYONIN_J_KANRI.HOKOKU_NO & "' AS " & NameOf(_D004_SYONIN_J_KANRI.HOKOKU_NO))
        sbSQL.Append(" ," & _D004_SYONIN_J_KANRI.SYONIN_JUN & " AS " & NameOf(_D004_SYONIN_J_KANRI.SYONIN_JUN))
        sbSQL.Append(" ,'" & _D004_SYONIN_J_KANRI.SYAIN_ID & "' AS " & NameOf(_D004_SYONIN_J_KANRI.SYAIN_ID))
        sbSQL.Append(" ,'" & _D004_SYONIN_J_KANRI.SYONIN_YMDHNS & "' AS " & NameOf(_D004_SYONIN_J_KANRI.SYONIN_YMDHNS))
        sbSQL.Append(" ,'" & _D004_SYONIN_J_KANRI.SYONIN_HANTEI_KB & "' AS " & NameOf(_D004_SYONIN_J_KANRI.SYONIN_HANTEI_KB))
        sbSQL.Append(" ,'" & _D004_SYONIN_J_KANRI._SASIMODOSI_FG & "' AS " & NameOf(_D004_SYONIN_J_KANRI.SASIMODOSI_FG))
        sbSQL.Append(" ,'" & _D004_SYONIN_J_KANRI.RIYU & "' AS " & NameOf(_D004_SYONIN_J_KANRI.RIYU))
        sbSQL.Append(" ,'" & _D004_SYONIN_J_KANRI.COMMENT & "' AS " & NameOf(_D004_SYONIN_J_KANRI.COMMENT))
        sbSQL.Append(" ,'" & _D004_SYONIN_J_KANRI._MAIL_SEND_FG & "' AS " & NameOf(_D004_SYONIN_J_KANRI.MAIL_SEND_FG))
        sbSQL.Append(" ," & _D004_SYONIN_J_KANRI.ADD_SYAIN_ID & " AS " & NameOf(_D004_SYONIN_J_KANRI.ADD_SYAIN_ID))
        sbSQL.Append(" ,dbo.GetSysDateString() AS " & NameOf(_D004_SYONIN_J_KANRI.ADD_YMDHNS))
        sbSQL.Append(" ," & pub_SYAIN_INFO.SYAIN_ID & " AS " & NameOf(_D004_SYONIN_J_KANRI.UPD_SYAIN_ID))
        sbSQL.Append(" ,dbo.GetSysDateString() AS " & NameOf(_D004_SYONIN_J_KANRI.UPD_YMDHNS))
        sbSQL.Append(" ) AS WK")
        sbSQL.Append(" ON (SrcT." & NameOf(_D004_SYONIN_J_KANRI.SYONIN_HOKOKUSYO_ID) & " = WK." & NameOf(_D004_SYONIN_J_KANRI.SYONIN_HOKOKUSYO_ID) & "")
        sbSQL.Append(" AND SrcT." & NameOf(_D004_SYONIN_J_KANRI.HOKOKU_NO) & " = WK." & NameOf(_D004_SYONIN_J_KANRI.HOKOKU_NO) & "")
        sbSQL.Append(" AND SrcT." & NameOf(_D004_SYONIN_J_KANRI.SYONIN_JUN) & " = WK." & NameOf(_D004_SYONIN_J_KANRI.SYONIN_JUN) & ")")
        'UPDATE
        sbSQL.Append(" WHEN MATCHED THEN")
        sbSQL.Append(" UPDATE SET")
        sbSQL.Append("  SrcT." & NameOf(_D004_SYONIN_J_KANRI.SYAIN_ID) & " = WK." & NameOf(_D004_SYONIN_J_KANRI.SYAIN_ID))
        sbSQL.Append(" ,SrcT." & NameOf(_D004_SYONIN_J_KANRI.COMMENT) & " = WK." & NameOf(_D004_SYONIN_J_KANRI.COMMENT))
        sbSQL.Append(" ,SrcT." & NameOf(_D004_SYONIN_J_KANRI.UPD_SYAIN_ID) & " = WK." & NameOf(_D004_SYONIN_J_KANRI.UPD_SYAIN_ID))
        sbSQL.Append(" ,SrcT." & NameOf(_D004_SYONIN_J_KANRI.UPD_YMDHNS) & " = WK." & NameOf(_D004_SYONIN_J_KANRI.UPD_YMDHNS))
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
                If _D004_SYONIN_J_KANRI.MAIL_SEND_FG = False Then
                    If FunSendMailFutekigo("【テスト】不適合管理システム テストメール", FunGetNextStageName(_D004_SYONIN_J_KANRI.SYONIN_JUN), _D004_SYONIN_J_KANRI.SYAIN_ID) Then
                    Else
                        MessageBox.Show("メール送信に失敗しました。", "メール送信失敗", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    End If
                End If
            Case "UPDATE"

            Case Else
                '-----エラーログ出力
                Dim strErrMsg As String = My.Resources.ErrLogSqlExecutionFailure & sbSQL.ToString & "|" & sqlEx.Message
                WL.WriteLogDat(strErrMsg)
                Return False
        End Select

        Return True
    End Function

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

        '---存在確認
        Dim dsList As New DataSet
        Dim blnExist As Boolean
        sbSQL.Append("SELECT HOKOKU_NO FROM " & NameOf(MODEL.R001_HOKOKU_SOUSA) & "")
        sbSQL.Append(" WHERE HOKOKU_NO ='" & _R001_HOKOKU_SOUSA.HOKOKU_NO & "'")
        dsList = DB.GetDataSet(sbSQL.ToString, conblnNonMsg)
        If dsList.Tables(0).Rows.Count > 0 Then
            blnExist = True
        End If

        '-----データモデル更新
        _R001_HOKOKU_SOUSA.SYONIN_HOKOKUSYO_ID = ENM_SYONIN_HOKOKUSYO_ID._1_NCR
        _R001_HOKOKU_SOUSA.HOKOKU_NO = _D003_NCR_J.HOKOKU_NO
        _R001_HOKOKU_SOUSA.SYONIN_JUN = PrCurrentStage
        _R001_HOKOKU_SOUSA.SYAIN_ID = pub_SYAIN_INFO.SYAIN_ID
        'UNDONE: getsysdatetime
        _R001_HOKOKU_SOUSA.ADD_YMDHNS = Now.ToString("yyyyMMddHHmmss")

        Select Case _R001_HOKOKU_SOUSA.SYONIN_JUN
            Case ENM_NCR_STAGE._10_起草入力
                Select Case enmSAVE_MODE
                    Case ENM_SAVE_MODE._1_保存
                        _R001_HOKOKU_SOUSA.SYONIN_HANTEI_KB = ENM_SYONIN_HANTEI_KB._0_未承認

                        If blnExist Then
                            _R001_HOKOKU_SOUSA.SOUSA_KB = ENM_HOKOKUSYO_SOUSA_KB._2_更新保存
                        Else
                            _R001_HOKOKU_SOUSA.SOUSA_KB = ENM_HOKOKUSYO_SOUSA_KB._0_起草
                        End If

                    Case ENM_SAVE_MODE._2_承認申請
                        _R001_HOKOKU_SOUSA.SYONIN_HANTEI_KB = ENM_SYONIN_HANTEI_KB._1_承認

                        If blnExist Then
                            '追加しない
                            Return True
                        Else
                            _R001_HOKOKU_SOUSA.SOUSA_KB = ENM_HOKOKUSYO_SOUSA_KB._0_起草
                        End If
                End Select
            Case Else
                Select Case enmSAVE_MODE
                    Case ENM_SAVE_MODE._1_保存
                        '追加しない
                        Return True

                    Case ENM_SAVE_MODE._2_承認申請
                        _R001_HOKOKU_SOUSA.SYONIN_HANTEI_KB = ENM_SYONIN_HANTEI_KB._1_承認
                        _R001_HOKOKU_SOUSA.SOUSA_KB = ENM_HOKOKUSYO_SOUSA_KB._1_申請承認依頼
                End Select
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

        Return True
    End Function

    ''' <summary>
    ''' D005_CAR_J更新
    ''' </summary>
    ''' <param name="DB"></param>
    ''' <returns></returns>
    Private Function FunSAVE_D005(ByRef DB As ClsDbUtility) As Boolean
        Dim sbSQL As New System.Text.StringBuilder
        Dim intRET As Integer
        Dim sqlEx As New Exception

        '-----データモデル更新
        Dim _D005_CAR_J As New MODEL.D005_CAR_J
        _D005_CAR_J.HOKOKU_NO = _D003_NCR_J.HOKOKU_NO
        _D005_CAR_J.BUMON_KB = _D003_NCR_J.BUMON_KB

        '-----INSERT
        sbSQL.Remove(0, sbSQL.Length)
        sbSQL.Append("INSERT INTO " & NameOf(MODEL.D005_CAR_J) & "(")
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
        sbSQL.Append(" ," & NameOf(_D005_CAR_J.ADD_SYAIN_ID))
        sbSQL.Append(" ," & NameOf(_D005_CAR_J.ADD_YMDHNS))
        sbSQL.Append(" ," & NameOf(_D005_CAR_J.UPD_SYAIN_ID))
        sbSQL.Append(" ," & NameOf(_D005_CAR_J.UPD_YMDHNS))
        sbSQL.Append(" ," & NameOf(_D005_CAR_J.DEL_SYAIN_ID))
        sbSQL.Append(" ," & NameOf(_D005_CAR_J.DEL_YMDHNS))
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
        sbSQL.Append(" ,'" & _D005_CAR_J.ZESEI_SYOCHI_YUKO_UMU & "'")
        sbSQL.Append(" ,'" & _D005_CAR_J.SYOSAI_FILE_PATH & "'")
        sbSQL.Append(" ,'" & _D005_CAR_J.GOKI & "'")
        sbSQL.Append(" ,'" & _D005_CAR_J.LOT & "'")
        sbSQL.Append(" ," & _D005_CAR_J.KENSA_TANTO_ID & "")
        sbSQL.Append(" ,'" & _D005_CAR_J.KENSA_TOROKU_YMDHNS & "'")
        sbSQL.Append(" ," & _D005_CAR_J.KENSA_GL_SYAIN_ID & "")
        sbSQL.Append(" ," & _D005_CAR_J.ADD_SYAIN_ID & "")
        sbSQL.Append(" ,'" & _D005_CAR_J.ADD_YMDHNS & "'")
        sbSQL.Append(" ," & _D005_CAR_J.UPD_SYAIN_ID & "")
        sbSQL.Append(" ,'" & _D005_CAR_J.UPD_YMDHNS & "'")
        sbSQL.Append(" ," & _D005_CAR_J.DEL_SYAIN_ID & "")
        sbSQL.Append(" ,'" & _D005_CAR_J.DEL_YMDHNS & "'")
        sbSQL.Append(")")

        '-----SQL実行
        intRET = DB.ExecuteNonQuery(sbSQL.ToString, conblnNonMsg, sqlEx)
        If intRET <> 1 Then
            '-----エラーログ出力
            Dim strErrMsg As String = My.Resources.ErrLogSqlExecutionFailure & sbSQL.ToString & "|" & sqlEx.Message
            WL.WriteLogDat(strErrMsg)
            Return False
        End If

        Return True
    End Function

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
        sbSQL.Append("MERGE INTO " & NameOf(MODEL.D003_NCR_J) & " AS SrcT")
        sbSQL.Append(" USING (")
        sbSQL.Append(" SELECT")
        sbSQL.Append(" '" & _D003_NCR_J.HOKOKU_NO & "' AS " & NameOf(_D003_NCR_J.HOKOKU_NO))
        sbSQL.Append(" ,'" & _D003_NCR_J.BUMON_KB & "' AS " & NameOf(_D003_NCR_J.BUMON_KB))
        sbSQL.Append(" ,'" & _D003_NCR_J._CLOSE_FG & "' AS " & NameOf(_D003_NCR_J.CLOSE_FG))
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
        sbSQL.Append(" ,'" & _D003_NCR_J._ZESEI_SYOCHI_YOHI_KB & "' AS " & NameOf(_D003_NCR_J.ZESEI_SYOCHI_YOHI_KB))
        sbSQL.Append(" ,'" & _D003_NCR_J.ZESEI_NASI_RIYU & "' AS " & NameOf(_D003_NCR_J.ZESEI_NASI_RIYU))
        sbSQL.Append(" ,'" & _D003_NCR_J.JIZEN_SINSA_HANTEI_KB & "' AS " & NameOf(_D003_NCR_J.JIZEN_SINSA_HANTEI_KB))
        sbSQL.Append(" ," & _D003_NCR_J.JIZEN_SINSA_SYAIN_ID & " AS " & NameOf(_D003_NCR_J.JIZEN_SINSA_SYAIN_ID))

        sbSQL.Append(" ,'" & _D003_NCR_J.JIZEN_SINSA_YMD & "' AS " & NameOf(_D003_NCR_J.JIZEN_SINSA_YMD))
        sbSQL.Append(" ," & _D003_NCR_J.SAISIN_KAKUNIN_SYAIN_ID & " AS " & NameOf(_D003_NCR_J.SAISIN_KAKUNIN_SYAIN_ID))
        sbSQL.Append(" ,'" & _D003_NCR_J.SAISIN_KAKUNIN_YMD & "' AS " & NameOf(_D003_NCR_J.SAISIN_KAKUNIN_YMD))
        sbSQL.Append(" ,'" & _D003_NCR_J.SAISIN_IINKAI_HANTEI_KB & "' AS " & NameOf(_D003_NCR_J.SAISIN_IINKAI_HANTEI_KB))
        sbSQL.Append(" ," & _D003_NCR_J.SAISIN_GIJYUTU_SYAIN_ID & " AS " & NameOf(_D003_NCR_J.SAISIN_GIJYUTU_SYAIN_ID))
        sbSQL.Append(" ,'" & _D003_NCR_J.SAISIN_GIJYUTU_YMD & "' AS " & NameOf(_D003_NCR_J.SAISIN_GIJYUTU_YMD))
        sbSQL.Append(" ," & _D003_NCR_J.SAISIN_HINSYO_SYAIN_ID & " AS " & NameOf(_D003_NCR_J.SAISIN_HINSYO_SYAIN_ID))
        sbSQL.Append(" ,'" & _D003_NCR_J.SAISIN_HINSYO_YMD & "' AS " & NameOf(_D003_NCR_J.SAISIN_HINSYO_YMD))
        sbSQL.Append(" ,'" & _D003_NCR_J.SAISIN_IINKAI_SIRYO_NO & "' AS " & NameOf(_D003_NCR_J.SAISIN_IINKAI_SIRYO_NO))
        sbSQL.Append(" ,'" & _D003_NCR_J.ITAG_NO & "' AS " & NameOf(_D003_NCR_J.ITAG_NO))
        sbSQL.Append(" ," & _D003_NCR_J.KOKYAKU_SAISIN_TANTO_ID & " AS " & NameOf(_D003_NCR_J.KOKYAKU_SAISIN_TANTO_ID))
        sbSQL.Append(" ,'" & _D003_NCR_J.KOKYAKU_SAISIN_YMD & "' AS " & NameOf(_D003_NCR_J.KOKYAKU_SAISIN_YMD))
        sbSQL.Append(" ,'" & _D003_NCR_J.KOKYAKU_HANTEI_SIJI_KB & "' AS " & NameOf(_D003_NCR_J.KOKYAKU_HANTEI_SIJI_KB))
        sbSQL.Append(" ,'" & _D003_NCR_J.KOKYAKU_HANTEI_SIJI_YMD & "' AS " & NameOf(_D003_NCR_J.KOKYAKU_HANTEI_SIJI_YMD))
        sbSQL.Append(" ,'" & _D003_NCR_J.KOKYAKU_SAISYU_HANTEI_KB & "' AS " & NameOf(_D003_NCR_J.KOKYAKU_SAISYU_HANTEI_KB))
        sbSQL.Append(" ,'" & _D003_NCR_J.KOKYAKU_SAISYU_HANTEI_YMD & "' AS " & NameOf(_D003_NCR_J.KOKYAKU_SAISYU_HANTEI_YMD))
        sbSQL.Append(" ,'" & _D003_NCR_J._SAIKAKO_SIJI_FG & "' AS " & NameOf(_D003_NCR_J.SAIKAKO_SIJI_FG))
        sbSQL.Append(" ,'" & _D003_NCR_J.HAIKYAKU_YMD & "' AS " & NameOf(_D003_NCR_J.HAIKYAKU_YMD))
        sbSQL.Append(" ,'" & _D003_NCR_J.HAIKYAKU_KB & "' AS " & NameOf(_D003_NCR_J.HAIKYAKU_KB))
        sbSQL.Append(" ,'" & _D003_NCR_J.HAIKYAKU_HOUHOU & "' AS " & NameOf(_D003_NCR_J.HAIKYAKU_HOUHOU))
        sbSQL.Append(" ," & _D003_NCR_J.HAIKYAKU_TANTO_ID & " AS " & NameOf(_D003_NCR_J.HAIKYAKU_TANTO_ID))
        sbSQL.Append(" ,'" & _D003_NCR_J.SAIKAKO_SIJI_NO & "' AS " & NameOf(_D003_NCR_J.SAIKAKO_SIJI_NO))
        sbSQL.Append(" ,'" & _D003_NCR_J.SAIKAKO_SAGYO_KAN_YMD & "' AS " & NameOf(_D003_NCR_J.SAIKAKO_SAGYO_KAN_YMD))
        sbSQL.Append(" ,'" & _D003_NCR_J.SAIKAKO_KENSA_YMD & "' AS " & NameOf(_D003_NCR_J.SAIKAKO_KENSA_YMD))
        sbSQL.Append(" ,'" & _D003_NCR_J.KENSA_KEKKA_KB & "' AS " & NameOf(_D003_NCR_J.KENSA_KEKKA_KB))
        sbSQL.Append(" ," & _D003_NCR_J.SEIGI_TANTO_ID & " AS " & NameOf(_D003_NCR_J.SEIGI_TANTO_ID))
        sbSQL.Append(" ," & _D003_NCR_J.SEIZO_TANTO_ID & " AS " & NameOf(_D003_NCR_J.SEIZO_TANTO_ID))
        sbSQL.Append(" ," & _D003_NCR_J.KENSA_TANTO_ID & " AS " & NameOf(_D003_NCR_J.KENSA_TANTO_ID))
        sbSQL.Append(" ,'" & _D003_NCR_J.HENKYAKU_YMD & "' AS " & NameOf(_D003_NCR_J.HENKYAKU_YMD))
        sbSQL.Append(" ,'" & _D003_NCR_J.HENKYAKU_SAKI & "' AS " & NameOf(_D003_NCR_J.HENKYAKU_SAKI))
        sbSQL.Append(" ," & _D003_NCR_J.HENKYAKU_TANTO_ID & " AS " & NameOf(_D003_NCR_J.HENKYAKU_TANTO_ID))
        sbSQL.Append(" ,'" & _D003_NCR_J.HENKYAKU_BIKO & "' AS " & NameOf(_D003_NCR_J.HENKYAKU_BIKO))
        sbSQL.Append(" ," & _D003_NCR_J.TENYO_KISYU_ID & " AS " & NameOf(_D003_NCR_J.TENYO_KISYU_ID))
        sbSQL.Append(" ,'" & _D003_NCR_J.TENYO_BUHIN_BANGO & "' AS " & NameOf(_D003_NCR_J.TENYO_BUHIN_BANGO))
        sbSQL.Append(" ,'" & _D003_NCR_J.TENYO_GOKI & "' AS " & NameOf(_D003_NCR_J.TENYO_GOKI))
        sbSQL.Append(" ," & _D003_NCR_J.TENYO_LOT & " AS " & NameOf(_D003_NCR_J.TENYO_LOT))
        sbSQL.Append(" ,'" & _D003_NCR_J.TENYO_YMD & "' AS " & NameOf(_D003_NCR_J.TENYO_YMD))
        sbSQL.Append(" ,'" & _D003_NCR_J._SYOCHI_KEKKA_A & "' AS " & NameOf(_D003_NCR_J.SYOCHI_KEKKA_A))
        sbSQL.Append(" ,'" & _D003_NCR_J._SYOCHI_KEKKA_B & "' AS " & NameOf(_D003_NCR_J.SYOCHI_KEKKA_B))
        sbSQL.Append(" ,'" & _D003_NCR_J._SYOCHI_KEKKA_C & "' AS " & NameOf(_D003_NCR_J.SYOCHI_KEKKA_C))
        sbSQL.Append(" ,'" & _D003_NCR_J._SYOCHI_D_UMU_KB & "' AS " & NameOf(_D003_NCR_J.SYOCHI_D_UMU_KB))
        sbSQL.Append(" ,'" & _D003_NCR_J._SYOCHI_D_YOHI_KB & "' AS " & NameOf(_D003_NCR_J.SYOCHI_D_YOHI_KB))
        sbSQL.Append(" ,'" & _D003_NCR_J.SYOCHI_D_SYOCHI_KIROKU & "' AS " & NameOf(_D003_NCR_J.SYOCHI_D_SYOCHI_KIROKU))
        sbSQL.Append(" ,'" & _D003_NCR_J._SYOCHI_E_UMU_KB & "' AS " & NameOf(_D003_NCR_J.SYOCHI_E_UMU_KB))
        sbSQL.Append(" ,'" & _D003_NCR_J._SYOCHI_E_YOHI_KB & "' AS " & NameOf(_D003_NCR_J.SYOCHI_E_YOHI_KB))
        sbSQL.Append(" ,'" & _D003_NCR_J.SYOCHI_E_SYOCHI_KIROKU & "' AS " & NameOf(_D003_NCR_J.SYOCHI_E_SYOCHI_KIROKU))

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
        sbSQL.Append(" ,SrcT." & NameOf(_D003_NCR_J.CLOSE_FG) & " = WK." & NameOf(_D003_NCR_J.CLOSE_FG))
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
        sbSQL.Append(" ,SrcT." & NameOf(_D003_NCR_J.KANSATU_KEKKA) & " = WK." & NameOf(_D003_NCR_J.KANSATU_KEKKA))

        sbSQL.Append(" ,SrcT." & NameOf(_D003_NCR_J.ZESEI_SYOCHI_YOHI_KB) & " = WK." & NameOf(_D003_NCR_J.ZESEI_SYOCHI_YOHI_KB))
        sbSQL.Append(" ,SrcT." & NameOf(_D003_NCR_J.ZESEI_NASI_RIYU) & " = WK." & NameOf(_D003_NCR_J.ZESEI_NASI_RIYU))
        sbSQL.Append(" ,SrcT." & NameOf(_D003_NCR_J.JIZEN_SINSA_HANTEI_KB) & " = WK." & NameOf(_D003_NCR_J.JIZEN_SINSA_HANTEI_KB))
        sbSQL.Append(" ,SrcT." & NameOf(_D003_NCR_J.JIZEN_SINSA_SYAIN_ID) & " = WK." & NameOf(_D003_NCR_J.JIZEN_SINSA_SYAIN_ID))
        sbSQL.Append(" ,SrcT." & NameOf(_D003_NCR_J.JIZEN_SINSA_YMD) & " = WK." & NameOf(_D003_NCR_J.JIZEN_SINSA_YMD))
        sbSQL.Append(" ,SrcT." & NameOf(_D003_NCR_J.SAISIN_KAKUNIN_SYAIN_ID) & " = WK." & NameOf(_D003_NCR_J.SAISIN_KAKUNIN_SYAIN_ID))
        sbSQL.Append(" ,SrcT." & NameOf(_D003_NCR_J.SAISIN_KAKUNIN_YMD) & " = WK." & NameOf(_D003_NCR_J.SAISIN_KAKUNIN_YMD))
        sbSQL.Append(" ,SrcT." & NameOf(_D003_NCR_J.SAISIN_IINKAI_HANTEI_KB) & " = WK." & NameOf(_D003_NCR_J.SAISIN_IINKAI_HANTEI_KB))
        sbSQL.Append(" ,SrcT." & NameOf(_D003_NCR_J.SAISIN_GIJYUTU_SYAIN_ID) & " = WK." & NameOf(_D003_NCR_J.SAISIN_GIJYUTU_SYAIN_ID))
        sbSQL.Append(" ,SrcT." & NameOf(_D003_NCR_J.SAISIN_GIJYUTU_YMD) & " = WK." & NameOf(_D003_NCR_J.SAISIN_GIJYUTU_YMD))
        sbSQL.Append(" ,SrcT." & NameOf(_D003_NCR_J.SAISIN_HINSYO_SYAIN_ID) & " = WK." & NameOf(_D003_NCR_J.SAISIN_HINSYO_SYAIN_ID))
        sbSQL.Append(" ,SrcT." & NameOf(_D003_NCR_J.SAISIN_HINSYO_YMD) & " = WK." & NameOf(_D003_NCR_J.SAISIN_HINSYO_YMD))
        sbSQL.Append(" ,SrcT." & NameOf(_D003_NCR_J.SAISIN_IINKAI_SIRYO_NO) & " = WK." & NameOf(_D003_NCR_J.SAISIN_IINKAI_SIRYO_NO))
        sbSQL.Append(" ,SrcT." & NameOf(_D003_NCR_J.ITAG_NO) & " = WK." & NameOf(_D003_NCR_J.ITAG_NO))
        sbSQL.Append(" ,SrcT." & NameOf(_D003_NCR_J.KOKYAKU_SAISIN_TANTO_ID) & " = WK." & NameOf(_D003_NCR_J.KOKYAKU_SAISIN_TANTO_ID))
        sbSQL.Append(" ,SrcT." & NameOf(_D003_NCR_J.KOKYAKU_SAISIN_YMD) & " = WK." & NameOf(_D003_NCR_J.KOKYAKU_SAISIN_YMD))
        sbSQL.Append(" ,SrcT." & NameOf(_D003_NCR_J.KOKYAKU_HANTEI_SIJI_KB) & " = WK." & NameOf(_D003_NCR_J.KOKYAKU_HANTEI_SIJI_KB))
        sbSQL.Append(" ,SrcT." & NameOf(_D003_NCR_J.KOKYAKU_HANTEI_SIJI_YMD) & " = WK." & NameOf(_D003_NCR_J.KOKYAKU_HANTEI_SIJI_YMD))
        sbSQL.Append(" ,SrcT." & NameOf(_D003_NCR_J.KOKYAKU_SAISYU_HANTEI_KB) & " = WK." & NameOf(_D003_NCR_J.KOKYAKU_SAISYU_HANTEI_KB))
        sbSQL.Append(" ,SrcT." & NameOf(_D003_NCR_J.KOKYAKU_SAISYU_HANTEI_YMD) & " = WK." & NameOf(_D003_NCR_J.KOKYAKU_SAISYU_HANTEI_YMD))
        sbSQL.Append(" ,SrcT." & NameOf(_D003_NCR_J.SAIKAKO_SIJI_FG) & " = WK." & NameOf(_D003_NCR_J.SAIKAKO_SIJI_FG))
        sbSQL.Append(" ,SrcT." & NameOf(_D003_NCR_J.HAIKYAKU_YMD) & " = WK." & NameOf(_D003_NCR_J.HAIKYAKU_YMD))
        sbSQL.Append(" ,SrcT." & NameOf(_D003_NCR_J.HAIKYAKU_KB) & " = WK." & NameOf(_D003_NCR_J.HAIKYAKU_KB))
        sbSQL.Append(" ,SrcT." & NameOf(_D003_NCR_J.HAIKYAKU_HOUHOU) & " = WK." & NameOf(_D003_NCR_J.HAIKYAKU_HOUHOU))
        sbSQL.Append(" ,SrcT." & NameOf(_D003_NCR_J.HAIKYAKU_TANTO_ID) & " = WK." & NameOf(_D003_NCR_J.HAIKYAKU_TANTO_ID))
        sbSQL.Append(" ,SrcT." & NameOf(_D003_NCR_J.SAIKAKO_SIJI_NO) & " = WK." & NameOf(_D003_NCR_J.SAIKAKO_SIJI_NO))
        sbSQL.Append(" ,SrcT." & NameOf(_D003_NCR_J.SAIKAKO_SAGYO_KAN_YMD) & " = WK." & NameOf(_D003_NCR_J.SAIKAKO_SAGYO_KAN_YMD))
        sbSQL.Append(" ,SrcT." & NameOf(_D003_NCR_J.SAIKAKO_KENSA_YMD) & " = WK." & NameOf(_D003_NCR_J.SAIKAKO_KENSA_YMD))
        sbSQL.Append(" ,SrcT." & NameOf(_D003_NCR_J.KENSA_KEKKA_KB) & " = WK." & NameOf(_D003_NCR_J.KENSA_KEKKA_KB))
        sbSQL.Append(" ,SrcT." & NameOf(_D003_NCR_J.SEIGI_TANTO_ID) & " = WK." & NameOf(_D003_NCR_J.SEIGI_TANTO_ID))
        sbSQL.Append(" ,SrcT." & NameOf(_D003_NCR_J.SEIZO_TANTO_ID) & " = WK." & NameOf(_D003_NCR_J.SEIZO_TANTO_ID))
        sbSQL.Append(" ,SrcT." & NameOf(_D003_NCR_J.KENSA_TANTO_ID) & " = WK." & NameOf(_D003_NCR_J.KENSA_TANTO_ID))
        sbSQL.Append(" ,SrcT." & NameOf(_D003_NCR_J.HENKYAKU_YMD) & " = WK." & NameOf(_D003_NCR_J.HENKYAKU_YMD))
        sbSQL.Append(" ,SrcT." & NameOf(_D003_NCR_J.HENKYAKU_SAKI) & " = WK." & NameOf(_D003_NCR_J.HENKYAKU_SAKI))
        sbSQL.Append(" ,SrcT." & NameOf(_D003_NCR_J.HENKYAKU_TANTO_ID) & " = WK." & NameOf(_D003_NCR_J.HENKYAKU_TANTO_ID))
        sbSQL.Append(" ,SrcT." & NameOf(_D003_NCR_J.HENKYAKU_BIKO) & " = WK." & NameOf(_D003_NCR_J.HENKYAKU_BIKO))
        sbSQL.Append(" ,SrcT." & NameOf(_D003_NCR_J.TENYO_KISYU_ID) & " = WK." & NameOf(_D003_NCR_J.TENYO_KISYU_ID))
        sbSQL.Append(" ,SrcT." & NameOf(_D003_NCR_J.TENYO_BUHIN_BANGO) & " = WK." & NameOf(_D003_NCR_J.TENYO_BUHIN_BANGO))
        sbSQL.Append(" ,SrcT." & NameOf(_D003_NCR_J.TENYO_GOKI) & " = WK." & NameOf(_D003_NCR_J.TENYO_GOKI))
        sbSQL.Append(" ,SrcT." & NameOf(_D003_NCR_J.TENYO_LOT) & " = WK." & NameOf(_D003_NCR_J.TENYO_LOT))
        sbSQL.Append(" ,SrcT." & NameOf(_D003_NCR_J.TENYO_YMD) & " = WK." & NameOf(_D003_NCR_J.TENYO_YMD))
        sbSQL.Append(" ,SrcT." & NameOf(_D003_NCR_J.SYOCHI_KEKKA_A) & " = WK." & NameOf(_D003_NCR_J.SYOCHI_KEKKA_A))
        sbSQL.Append(" ,SrcT." & NameOf(_D003_NCR_J.SYOCHI_KEKKA_B) & " = WK." & NameOf(_D003_NCR_J.SYOCHI_KEKKA_B))
        sbSQL.Append(" ,SrcT." & NameOf(_D003_NCR_J.SYOCHI_KEKKA_C) & " = WK." & NameOf(_D003_NCR_J.SYOCHI_KEKKA_C))
        sbSQL.Append(" ,SrcT." & NameOf(_D003_NCR_J.SYOCHI_D_UMU_KB) & " = WK." & NameOf(_D003_NCR_J.SYOCHI_D_UMU_KB))
        sbSQL.Append(" ,SrcT." & NameOf(_D003_NCR_J.SYOCHI_D_YOHI_KB) & " = WK." & NameOf(_D003_NCR_J.SYOCHI_D_YOHI_KB))
        sbSQL.Append(" ,SrcT." & NameOf(_D003_NCR_J.SYOCHI_D_SYOCHI_KIROKU) & " = WK." & NameOf(_D003_NCR_J.SYOCHI_D_SYOCHI_KIROKU))
        sbSQL.Append(" ,SrcT." & NameOf(_D003_NCR_J.SYOCHI_E_UMU_KB) & " = WK." & NameOf(_D003_NCR_J.SYOCHI_E_UMU_KB))
        sbSQL.Append(" ,SrcT." & NameOf(_D003_NCR_J.SYOCHI_E_YOHI_KB) & " = WK." & NameOf(_D003_NCR_J.SYOCHI_E_YOHI_KB))
        sbSQL.Append(" ,SrcT." & NameOf(_D003_NCR_J.SYOCHI_E_SYOCHI_KIROKU) & " = WK." & NameOf(_D003_NCR_J.SYOCHI_E_SYOCHI_KIROKU))

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
        sbSQL.Append(" ," & NameOf(_D003_NCR_J.ADD_SYAIN_ID))
        sbSQL.Append(" ," & NameOf(_D003_NCR_J.ADD_YMDHNS))
        sbSQL.Append(" ," & NameOf(_D003_NCR_J.UPD_SYAIN_ID))
        sbSQL.Append(" ," & NameOf(_D003_NCR_J.UPD_YMDHNS))
        sbSQL.Append(" ," & NameOf(_D003_NCR_J.DEL_SYAIN_ID))
        sbSQL.Append(" ," & NameOf(_D003_NCR_J.DEL_YMDHNS))
        sbSQL.Append(" ) VALUES(")
        sbSQL.Append(" '" & _D003_NCR_J.HOKOKU_NO & "'")
        sbSQL.Append(" ,'" & _D003_NCR_J.BUMON_KB & "'")
        sbSQL.Append(" ,'" & _D003_NCR_J.CLOSE_FG & "'")
        sbSQL.Append(" ," & _D003_NCR_J.KISYU_ID & "")
        sbSQL.Append(" ,'" & _D003_NCR_J.SYANAI_CD & "'")
        sbSQL.Append(" ,'" & _D003_NCR_J.BUHIN_BANGO & "'")
        sbSQL.Append(" ,'" & _D003_NCR_J.BUHIN_NAME & "'")
        sbSQL.Append(" ,'" & _D003_NCR_J.GOKI & "'")
        sbSQL.Append(" ," & _D003_NCR_J.SURYO & "")
        sbSQL.Append(" ,'" & _D003_NCR_J.SAIHATU & "'")
        sbSQL.Append(" ,'" & _D003_NCR_J.FUTEKIGO_JYOTAI_KB & "'")
        sbSQL.Append(" ,'" & _D003_NCR_J.FUTEKIGO_NAIYO & "'")
        sbSQL.Append(" ,'" & _D003_NCR_J.FUTEKIGO_KB & "'")
        sbSQL.Append(" ,'" & _D003_NCR_J.FUTEKIGO_S_KB & "'")
        sbSQL.Append(" ,'" & _D003_NCR_J.ZUMEN_KIKAKU & "'")
        sbSQL.Append(" ,'" & _D003_NCR_J.YOKYU_NAIYO & "'")
        sbSQL.Append(" ,'" & _D003_NCR_J.KANSATU_KEKKA & "'")
        sbSQL.Append(" ,'" & _D003_NCR_J.ZESEI_SYOCHI_YOHI_KB & "'")
        sbSQL.Append(" ,'" & _D003_NCR_J.ZESEI_NASI_RIYU & "'")
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
        sbSQL.Append(" ,'" & _D003_NCR_J.SAIKAKO_SIJI_FG & "'")
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
        sbSQL.Append(" ,'" & _D003_NCR_J.TENYO_LOT & "'")
        sbSQL.Append(" ,'" & _D003_NCR_J.TENYO_YMD & "'")
        sbSQL.Append(" ,'" & _D003_NCR_J.SYOCHI_KEKKA_A & "'")
        sbSQL.Append(" ,'" & _D003_NCR_J.SYOCHI_KEKKA_B & "'")
        sbSQL.Append(" ,'" & _D003_NCR_J.SYOCHI_KEKKA_C & "'")
        sbSQL.Append(" ,'" & _D003_NCR_J.SYOCHI_D_UMU_KB & "'")
        sbSQL.Append(" ,'" & _D003_NCR_J.SYOCHI_D_YOHI_KB & "'")
        sbSQL.Append(" ,'" & _D003_NCR_J.SYOCHI_D_SYOCHI_KIROKU & "'")
        sbSQL.Append(" ,'" & _D003_NCR_J.SYOCHI_E_UMU_KB & "'")
        sbSQL.Append(" ,'" & _D003_NCR_J.SYOCHI_E_YOHI_KB & "'")
        sbSQL.Append(" ,'" & _D003_NCR_J.SYOCHI_E_SYOCHI_KIROKU & "'")
        sbSQL.Append(" ,'" & _D003_NCR_J.FILE_PATH & "'")
        sbSQL.Append(" ,'" & _D003_NCR_J.G_FILE_PATH1 & "'")
        sbSQL.Append(" ,'" & _D003_NCR_J.G_FILE_PATH2 & "'")
        sbSQL.Append(" ," & _D003_NCR_J.ADD_SYAIN_ID & "")
        sbSQL.Append(" ,'" & _D003_NCR_J.ADD_YMDHNS & "'")
        sbSQL.Append(" ," & _D003_NCR_J.UPD_SYAIN_ID & "")
        sbSQL.Append(" ,'" & _D003_NCR_J.UPD_YMDHNS & "'")
        sbSQL.Append(" ," & _D003_NCR_J.DEL_SYAIN_ID & "")
        sbSQL.Append(" ,'" & _D003_NCR_J.DEL_YMDHNS & "'")
        sbSQL.Append(" )")
        sbSQL.Append("OUTPUT $action AS RESULT") 'INSERT OR UPDATE をncarchar(10)で取得する場合
        sbSQL.Append(";")

        Using DB As ClsDbUtility = DBOpen()
            Dim blnErr As Boolean
            Try
                DB.BeginTransaction()
                strRET = DB.ExecuteScalar(sbSQL.ToString, conblnNonMsg, sqlEx)
                Select Case strRET
                    Case "INSERT"

                    Case "UPDATE"
                        'Err?
                    Case Else
                        '-----エラーログ出力
                        Dim strErrMsg As String = My.Resources.ErrLogSqlExecutionFailure & sbSQL.ToString & "|" & sqlEx.Message
                        WL.WriteLogDat(strErrMsg)
                        blnErr = True
                        Return False
                End Select
            Finally
                DB.Commit(Not blnErr)
            End Try
        End Using

        Return True
    End Function

#End Region

#Region "CAR"
    Private Function OpenFormCAR() As Boolean
        Dim frmDLG As New FrmG0012
        Dim dlgRET As DialogResult

        Try

            frmDLG.PrHOKOKU_NO = _D003_NCR_J.HOKOKU_NO
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

#Region "転送"
    Private Function OpenFormTENSO() As Boolean
        Dim frmDLG As New FrmG0015
        Dim dlgRET As DialogResult

        Try
            frmDLG.PrSYONIN_HOKOKUSYO_ID = ENM_SYONIN_HOKOKUSYO_ID._1_NCR
            frmDLG.PrHOKOKU_NO = _D003_NCR_J.HOKOKU_NO
            frmDLG.PrCurrentStage = Me.PrCurrentStage
            dlgRET = frmDLG.ShowDialog(Me)

            If dlgRET = Windows.Forms.DialogResult.Cancel Then
                Return False
            Else
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

#Region "差戻し"
    Private Function OpenFormSASIMODOSI() As Boolean
        Dim frmDLG As New FrmG0016
        Dim dlgRET As DialogResult

        Try
            frmDLG.PrSYONIN_HOKOKUSYO_ID = ENM_SYONIN_HOKOKUSYO_ID._1_NCR
            frmDLG.PrHOKOKU_NO = _D003_NCR_J.HOKOKU_NO
            frmDLG.PrCurrentStage = Me.PrCurrentStage
            dlgRET = frmDLG.ShowDialog(Me)
            If dlgRET = Windows.Forms.DialogResult.Cancel Then
                Return False
            Else
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

            'ファイル名
            strOutputFileName = "NCR_" & _D003_NCR_J.HOKOKU_NO & "_Work.xlsx"

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
        End Try
    End Function

    Private Function FunMakeReportNCR(ByVal strFilePath As String, ByVal strHOKOKU_NO As String) As Boolean

        Dim ssgWorkbook As SpreadsheetGear.IWorkbook
        Dim ssgWorksheets As SpreadsheetGear.IWorksheets
        Dim ssgSheet1 As SpreadsheetGear.IWorksheet
        Dim ssgRangeFrom As SpreadsheetGear.IRange
        Dim ssgRangeTo As SpreadsheetGear.IRange

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
            ssgSheet1.Range(NameOf(_V002_NCR_J.FUTEKIGO_JYOTAI_KB) & _V002_NCR_J.FUTEKIGO_JYOTAI_KB).Value = "TRUE"
            ssgSheet1.Range(NameOf(_V002_NCR_J.FUTEKIGO_NAIYO)).Value = _V002_NCR_J.FUTEKIGO_NAIYO
            ssgSheet1.Range(NameOf(_V002_NCR_J.GOKI)).Value = _V002_NCR_J.GOKI
            ssgSheet1.Range(NameOf(_V002_NCR_J.HAIKYAKU_HOUHOU)).Value = "(その他の内容：" & _V002_NCR_J.HAIKYAKU_HOUHOU.PadRight(30) & ")"
            ssgSheet1.Range(NameOf(_V002_NCR_J.HAIKYAKU_KB_NAME)).Value = _V002_NCR_J.HAIKYAKU_KB_NAME
            ssgSheet1.Range(NameOf(_V002_NCR_J.HAIKYAKU_TANTO_NAME)).Value = _V002_NCR_J.HAIKYAKU_TANTO_NAME
            ssgSheet1.Range(NameOf(_V002_NCR_J.HAIKYAKU_YMD)).Value = _V002_NCR_J.HAIKYAKU_YMD
            ssgSheet1.Range(NameOf(_V002_NCR_J.HASSEI_KOTEI_GL_NAME)).Value = _V002_NCR_J.HASSEI_KOTEI_GL_NAME
            ssgSheet1.Range(NameOf(_V002_NCR_J.HASSEI_KOTEI_GL_YMD)).Value = _V002_NCR_J.HASSEI_KOTEI_GL_YMD
            ssgSheet1.Range(NameOf(_V002_NCR_J.HENKYAKU_BIKO)).Value = _V002_NCR_J.HENKYAKU_BIKO
            ssgSheet1.Range(NameOf(_V002_NCR_J.HENKYAKU_SAKI)).Value = _V002_NCR_J.HENKYAKU_SAKI
            ssgSheet1.Range(NameOf(_V002_NCR_J.HENKYAKU_TANTO_NAME)).Value = _V002_NCR_J.HENKYAKU_TANTO_NAME
            ssgSheet1.Range(NameOf(_V002_NCR_J.HENKYAKU_YMD)).Value = _V002_NCR_J.HENKYAKU_YMD
            ssgSheet1.Range(NameOf(_V002_NCR_J.HOKOKU_NO)).Value = _V002_NCR_J.HOKOKU_NO
            ssgSheet1.Range(NameOf(_V002_NCR_J.ITAG_NO)).Value = _V002_NCR_J.ITAG_NO
            ssgSheet1.Range(NameOf(_V002_NCR_J.JIZEN_SINSA_HANTEI_KB) & _V002_NCR_J.JIZEN_SINSA_HANTEI_KB).Value = "TRUE"
            ssgSheet1.Range(NameOf(_V002_NCR_J.JIZEN_SINSA_SYAIN_NAME)).Value = _V002_NCR_J.JIZEN_SINSA_SYAIN_NAME
            ssgSheet1.Range(NameOf(_V002_NCR_J.JIZEN_SINSA_YMD)).Value = _V002_NCR_J.JIZEN_SINSA_YMD
            ssgSheet1.Range(NameOf(_V002_NCR_J.KANSATU_KEKKA)).Value = _V002_NCR_J.KANSATU_KEKKA
            ssgSheet1.Range(NameOf(_V002_NCR_J.KENSA_KEKKA_NAME)).Value = _V002_NCR_J.KENSA_KEKKA_NAME
            ssgSheet1.Range(NameOf(_V002_NCR_J.KENSA_TANTO_NAME)).Value = _V002_NCR_J.KENSA_TANTO_NAME
            ssgSheet1.Range(NameOf(_V002_NCR_J.KISYU)).Value = _V002_NCR_J.KISYU
            ssgSheet1.Range(NameOf(_V002_NCR_J.KOKYAKU_HANTEI_SIJI_NAME)).Value = _V002_NCR_J.KOKYAKU_HANTEI_SIJI_NAME
            ssgSheet1.Range(NameOf(_V002_NCR_J.KOKYAKU_HANTEI_SIJI_YMD)).Value = _V002_NCR_J.KOKYAKU_HANTEI_SIJI_YMD
            ssgSheet1.Range(NameOf(_V002_NCR_J.SAIHATU)).Value = _V002_NCR_J.SAIHATU
            ssgSheet1.Range(NameOf(_V002_NCR_J.SAIKAKO_KENSA_YMD)).Value = _V002_NCR_J.SAIKAKO_KENSA_YMD
            ssgSheet1.Range(NameOf(_V002_NCR_J.SAIKAKO_SAGYO_KAN_YMD)).Value = _V002_NCR_J.SAIKAKO_SAGYO_KAN_YMD
            ssgSheet1.Range(NameOf(_V002_NCR_J.SAIKAKO_SIJI_NO)).Value = _V002_NCR_J.SAIKAKO_SIJI_NO
            ssgSheet1.Range(NameOf(_V002_NCR_J.SAISIN_GIJYUTU_SYAIN_NAME)).Value = _V002_NCR_J.SAISIN_GIJYUTU_SYAIN_NAME
            ssgSheet1.Range(NameOf(_V002_NCR_J.SAISIN_HINSYO_SYAIN_NAME)).Value = _V002_NCR_J.SAISIN_HINSYO_SYAIN_NAME
            ssgSheet1.Range(NameOf(_V002_NCR_J.SAISIN_HINSYO_YMD)).Value = _V002_NCR_J.SAISIN_HINSYO_YMD
            ssgSheet1.Range(NameOf(_V002_NCR_J.SAISIN_IINKAI_HANTEI_KB) & _V002_NCR_J.SAISIN_IINKAI_HANTEI_KB).Value = "TRUE"
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
            ssgSheet1.Range(NameOf(_V002_NCR_J.TENYO_KISYU)).Value = _V002_NCR_J.TENYO_KISYU
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

            '-----SpereasheetGera印刷
            Dim ssgPrintDocument As SpreadsheetGear.Drawing.Printing.WorkbookPrintDocument = New SpreadsheetGear.Drawing.Printing.WorkbookPrintDocument(ssgSheet1, SpreadsheetGear.Printing.PrintWhat.Sheet)
            'printDocument.PrinterSettings.PrinterName = "PrinterName"
            ssgPrintDocument.Print()

            '-----ファイル保存
            'spWork.Delete()
            'spWorksheets(0).Cells("A1").Select()
            ssgSheet1.SaveAs(filename:=strFilePath, fileFormat:=SpreadsheetGear.FileFormat.OpenXMLWorkbook)
            ssgWorkbook.WorkbookSet.ReleaseLock()

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
            ssgRangeFrom = Nothing
            ssgRangeTo = Nothing
            ssgSheet1 = Nothing
            ssgWorksheets = Nothing
            ssgWorkbook = Nothing
        End Try
    End Function

#End Region

#Region "履歴"
    Private Function OpenFormHistory() As Boolean
        Dim frmDLG As New FrmG0017
        Dim dlgRET As DialogResult

        Try
            frmDLG.PrSYONIN_HOKOKUSYO_ID = ENM_SYONIN_HOKOKUSYO_ID._1_NCR
            frmDLG.PrHOKOKU_NO = _D003_NCR_J.HOKOKU_NO
            dlgRET = frmDLG.ShowDialog(Me)
            If dlgRET = Windows.Forms.DialogResult.Cancel Then
                Return False
            Else
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
                cmdFunc10.Enabled = False
                cmdFunc11.Enabled = False
            Else
                cmdFunc4.Enabled = True
                cmdFunc5.Enabled = True
                cmdFunc10.Enabled = True
                cmdFunc11.Enabled = True
            End If

            'SPEC: 40-3.④
            cmdFunc9.Enabled = _D003_NCR_J.ZESEI_SYOCHI_YOHI_KB = ENM_YOHI_KB._1_要

            'SPEC: 80-2.⑤
            Select Case PrCurrentStage
                Case ENM_NCR_STAGE._81_処置実施_生技, ENM_NCR_STAGE._82_処置実施_製造, ENM_NCR_STAGE._83_処置実施_検査
                    cmdFunc1.Enabled = False
                Case Else
                    cmdFunc1.Enabled = True
            End Select


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

#Region "タブコントロール制御"

#Region "初期化"
    Private Function FunInitializeTabControl(ByVal intCurrentTabNo As Integer) As Boolean

        Try
            _tabPageManager = New TabPageManager(TabSTAGE)

            For Each page As TabPage In TabSTAGE.TabPages
                If page.Name <> "tabAttachment" Then
                    If Val(page.Name.Substring(8)) < intCurrentTabNo Then
                        'SPEC: 10-2.③
                        page.Text = tblNCR.AsEnumerable.Where(Function(r) r.Field(Of Integer)("VALUE") = FunConvertSTAGE_NO_TO_SYONIN_JUN(Val(page.Name.Substring(8)))).FirstOrDefault.Item("DISP")

                    ElseIf Val(page.Name.Substring(8)) = intCurrentTabNo Then
                        page.Text = "現ステージ" 'tblNCR.AsEnumerable.Where(Function(r) r.Field(Of String)("VALUE") = PrDataRow("SYONIN_JUN")).FirstOrDefault.Item("DISP")

                        '次ステージの承認担当者・コメント欄をバインド
                        Dim ctrlTANTO As Control() = Me.Controls.Find("cmbST" & intCurrentTabNo.ToString("00") & "_DestTANTO", True)
                        If ctrlTANTO.Length > 0 Then
                            Dim cmbTANTO As ComboboxEx = ctrlTANTO(0)
                            cmbTANTO.NullValue = 0
                            cmbTANTO.DataBindings.Add(New Binding(NameOf(cmbTANTO.SelectedValue), _D004_SYONIN_J_KANRI, NameOf(_D004_SYONIN_J_KANRI.SYAIN_ID), False, DataSourceUpdateMode.OnPropertyChanged, 0))
                        End If
                        Dim ctrlCOMMENT As Control() = Me.Controls.Find("txtST" & intCurrentTabNo.ToString("00") & "_Comment", True)
                        If ctrlCOMMENT.Length > 0 Then
                            Dim txtCOMMENT As TextBoxEx = ctrlCOMMENT(0)
                            txtCOMMENT.DataBindings.Add(New Binding(NameOf(txtCOMMENT.Text), _D004_SYONIN_J_KANRI, NameOf(_D004_SYONIN_J_KANRI.COMMENT), False, DataSourceUpdateMode.OnPropertyChanged, ""))
                        End If

                    ElseIf Val(page.Name.Substring(8)) > intCurrentTabNo Then
                        'SPEC: 10-2 ②
                        _tabPageManager.ChangeTabPageVisible(page.TabIndex, False)
                    End If

                    'SPEC: 10-2.⑤ 
                    If PrMODE = ENM_DATA_OPERATION_MODE._1_ADD Then
                        '新規作成時
                        'SPEC: (3).B 
                        page.Enabled = True
                    Else
                        'カレントユーザーの以外は参照のみ
                        If PrDataRow("SYONIN_JUN") >= ENM_NCR_STAGE._90_処置実施確認_管理T Then
                            page.Enabled = FunblnOwnCreated(ENM_SYONIN_HOKOKUSYO_ID._1_NCR, PrDataRow("HOKOKU_NO"), PrDataRow("SYONIN_JUN"))
                        End If
                    End If
                End If
            Next page


            '添付資料タブ初期化

            If Not _D003_NCR_J.FILE_PATH.IsNullOrWhiteSpace Then
                lbltmpFile1.Text = IO.Path.GetFileName(_D003_NCR_J.FILE_PATH)
                lbltmpFile1.Links.Clear()
                lbltmpFile1.Links.Add(0, lbltmpFile1.Text.Length, _D003_NCR_J.FILE_PATH)
                _D003_NCR_J.FILE_PATH = _D003_NCR_J.FILE_PATH
                lbltmpFile1.Visible = True
                lbltmpFile1_Clear.Visible = True
            End If
            If Not _D003_NCR_J.G_FILE_PATH1.IsNullOrWhiteSpace Then
                Call SetPict1Data({_D003_NCR_J.G_FILE_PATH1})
            End If
            If Not _D003_NCR_J.G_FILE_PATH2.IsNullOrWhiteSpace Then
                Call SetPict1Data({_D003_NCR_J.G_FILE_PATH2})
            End If

            Return True
        Catch ex As Exception
            EM.ErrorSyori(ex, False, conblnNonMsg)
            Return False
        End Try
    End Function

#End Region

#Region "STAGE別コントロール初期化"
    Private Function FunInitializeSTAGE(ByVal intStageID As Integer) As Boolean
        Dim dt As New DataTable
        Dim _V003 As New MODEL.V003_SYONIN_J_KANRI
        Try



#Region "               10"
            If intStageID >= ENM_NCR_STAGE._10_起草入力 Then
                dt = tblTANTO_SYONIN.AsEnumerable.
                                            Where(Function(r) r.Field(Of Integer)("SYONIN_HOKOKUSYO_ID") = 1 And r.Field(Of Integer)("SYONIN_JUN") = FunGetNextSYONIN_JUN(ENM_NCR_STAGE._10_起草入力)).
                                            CopyToDataTable

                mtxST01_UPD_YMD.Text = Today.ToString("yyyy/MM/dd")
                mtxST01_NextStageName.Text = FunGetNextStageName(ENM_NCR_STAGE._10_起草入力)
                cmbST01_DestTANTO.SetDataSource(dt, ENM_COMBO_SELECT_VALUE_TYPE._0_Required)


                If PrMODE = ENM_DATA_OPERATION_MODE._3_UPDATE Then
                    _D003_NCR_J.YOKYU_NAIYO = _V002_NCR_J.YOKYU_NAIYO
                    _D003_NCR_J.KANSATU_KEKKA = _V002_NCR_J.KANSATU_KEKKA


                    _V003 = _V003_SYONIN_J_KANRI_List.AsEnumerable.
                                Where(Function(r) r.SYONIN_JUN = ENM_NCR_STAGE._10_起草入力).
                                FirstOrDefault

                    If _V003 IsNot Nothing Then
                        If Not _V003.RIYU.IsNullOrWhiteSpace And intStageID = ENM_NCR_STAGE._10_起草入力 Then lblST01_Modoshi_Riyu.Visible = True
                        lblST01_Modoshi_Riyu.Text = "差戻理由：" & _V003.RIYU
                        cmbST01_DestTANTO.SelectedValue = _V003.SYAIN_ID
                    End If
                End If
            End If
#End Region
#Region "               20"
            If intStageID >= ENM_NCR_STAGE._20_起草確認製造GL Then
                dt = tblTANTO_SYONIN.AsEnumerable.
                                Where(Function(r) r.Field(Of Integer)("SYONIN_HOKOKUSYO_ID") = 1 And r.Field(Of Integer)("SYONIN_JUN") = FunGetNextSYONIN_JUN(ENM_NCR_STAGE._20_起草確認製造GL)).
                                CopyToDataTable

                mtxST02_UPD_YMD.Text = Today.ToString("yyyy/MM/dd")
                mtxST02_NextStageName.Text = FunGetNextStageName(ENM_NCR_STAGE._20_起草確認製造GL)
                cmbST02_DestTANTO.SetDataSource(dt, ENM_COMBO_SELECT_VALUE_TYPE._0_Required)


                If PrMODE = ENM_DATA_OPERATION_MODE._3_UPDATE Then
                    _V003 = _V003_SYONIN_J_KANRI_List.AsEnumerable.
                                Where(Function(r) r.SYONIN_JUN = ENM_NCR_STAGE._20_起草確認製造GL).
                                FirstOrDefault

                    cmbST02_DestTANTO.SelectedValue = _V003.SYAIN_ID
                    txtST02_Comment.Text = _V003.COMMENT

                    If _V003 IsNot Nothing Then
                        If Not _V003.RIYU.IsNullOrWhiteSpace And intStageID = ENM_NCR_STAGE._20_起草確認製造GL Then lblST02_Modoshi_Riyu.Visible = True
                        lblST02_Modoshi_Riyu.Text = "差戻理由：" & _V003.RIYU
                    End If
                End If
            End If
#End Region
#Region "               30"
            If intStageID >= ENM_NCR_STAGE._30_起草確認検査 Then
                dt = tblTANTO_SYONIN.AsEnumerable.
                                Where(Function(r) r.Field(Of Integer)("SYONIN_HOKOKUSYO_ID") = 1 And r.Field(Of Integer)("SYONIN_JUN") = FunGetNextSYONIN_JUN(ENM_NCR_STAGE._30_起草確認検査)).
                                CopyToDataTable

                mtxST03_UPD_YMD.Text = Today.ToString("yyyy/MM/dd")
                mtxST03_NextStageName.Text = FunGetNextStageName(ENM_NCR_STAGE._30_起草確認検査)
                cmbST03_DestTANTO.SetDataSource(dt, ENM_COMBO_SELECT_VALUE_TYPE._0_Required)

                If PrMODE = ENM_DATA_OPERATION_MODE._3_UPDATE Then
                    _V003 = _V003_SYONIN_J_KANRI_List.AsEnumerable.
                                Where(Function(r) r.SYONIN_JUN = ENM_NCR_STAGE._30_起草確認検査).
                                FirstOrDefault

                    If _V003 IsNot Nothing Then
                        cmbST03_DestTANTO.SelectedValue = _V003.SYAIN_ID
                        txtST03_Comment.Text = _V003.COMMENT
                        If Not _V003.RIYU.IsNullOrWhiteSpace And intStageID = ENM_NCR_STAGE._30_起草確認検査 Then lblST03_Modoshi_Riyu.Visible = True
                        lblST03_Modoshi_Riyu.Text = "差戻理由：" & _V003.RIYU
                    End If
                End If
            End If
#End Region
#Region "               40"
            If intStageID >= ENM_NCR_STAGE._40_事前審査判定及びCAR要否判定 Then
                dt = tblTANTO_SYONIN.AsEnumerable.
                                            Where(Function(r) r.Field(Of Integer)("SYONIN_HOKOKUSYO_ID") = 1 And r.Field(Of Integer)("SYONIN_JUN") = FunGetNextSYONIN_JUN(ENM_NCR_STAGE._40_事前審査判定及びCAR要否判定)).
                                            CopyToDataTable

                mtxST04_UPD_YMD.Text = Today.ToString("yyyy/MM/dd")
                mtxST04_NextStageName.Text = FunGetNextStageName(ENM_NCR_STAGE._40_事前審査判定及びCAR要否判定)
                cmbST04_DestTANTO.SetDataSource(dt, ENM_COMBO_SELECT_VALUE_TYPE._0_Required)

                cmbST04_JIZENSINSA_HANTEI.SetDataSource(tblJIZEN_SINSA_HANTEI_KB.ExcludeDeleted, ENM_COMBO_SELECT_VALUE_TYPE._0_Required)


                If PrMODE = ENM_DATA_OPERATION_MODE._3_UPDATE Then
                    _V003 = _V003_SYONIN_J_KANRI_List.AsEnumerable.
                                Where(Function(r) r.SYONIN_JUN = ENM_NCR_STAGE._40_事前審査判定及びCAR要否判定).
                                FirstOrDefault

                    _D003_NCR_J.JIZEN_SINSA_HANTEI_KB = _V002_NCR_J.JIZEN_SINSA_HANTEI_KB
                    _D003_NCR_J.ZESEI_SYOCHI_YOHI_KB = CBool(_V002_NCR_J.ZESEI_SYOCHI_YOHI_KB)
                    _D003_NCR_J.ZESEI_NASI_RIYU = _V002_NCR_J.ZESEI_NASI_RIYU

                    If _V003 IsNot Nothing Then
                        cmbST04_DestTANTO.SelectedValue = _V003.SYAIN_ID
                        txtST04_Comment.Text = _V003.COMMENT
                        If Not _V003.RIYU.IsNullOrWhiteSpace And intStageID = ENM_NCR_STAGE._40_事前審査判定及びCAR要否判定 Then lblST04_Modoshi_Riyu.Visible = True
                        lblST04_Modoshi_Riyu.Text = "差戻理由：" & _V003.RIYU
                    End If
                End If
            End If

#End Region
#Region "               50"
            If intStageID >= ENM_NCR_STAGE._50_事前審査確認 Then
                dt = tblTANTO_SYONIN.AsEnumerable.
                                        Where(Function(r) r.Field(Of Integer)("SYONIN_HOKOKUSYO_ID") = 1 And r.Field(Of Integer)("SYONIN_JUN") = ENM_NCR_STAGE._60_再審審査判定_技術代表).
                                        CopyToDataTable

                mtxST05_UPD_YMD.Text = Today.ToString("yyyy/MM/dd")
                mtxST05_NextStageName.Text = FunGetNextStageName(ENM_NCR_STAGE._50_事前審査確認)
                cmbST05_DestTANTO.SetDataSource(dt, ENM_COMBO_SELECT_VALUE_TYPE._0_Required)

                If PrMODE = ENM_DATA_OPERATION_MODE._3_UPDATE Then
                    _V003 = _V003_SYONIN_J_KANRI_List.AsEnumerable.
                                Where(Function(r) r.SYONIN_JUN = ENM_NCR_STAGE._50_事前審査確認).
                                FirstOrDefault

                    If _V003 IsNot Nothing Then
                        cmbST05_DestTANTO.SelectedValue = _V003.SYAIN_ID
                        txtST05_Comment.Text = _V003.COMMENT
                        If Not _V003.RIYU.IsNullOrWhiteSpace And intStageID = ENM_NCR_STAGE._50_事前審査確認 Then lblST05_Modoshi_Riyu.Visible = True
                        lblST05_Modoshi_Riyu.Text = "差戻理由：" & _V003.RIYU
                    End If
                End If
            End If
#End Region
#Region "               60"
            If intStageID >= ENM_NCR_STAGE._60_再審審査判定_技術代表 Then
                dt = tblTANTO_SYONIN.AsEnumerable.
                                        Where(Function(r) r.Field(Of Integer)("SYONIN_HOKOKUSYO_ID") = 1 And r.Field(Of Integer)("SYONIN_JUN") = FunGetNextSYONIN_JUN(ENM_NCR_STAGE._60_再審審査判定_技術代表)).
                                        CopyToDataTable

                mtxST06_UPD_YMD.Text = Today.ToString("yyyy/MM/dd")
                mtxST06_NextStageName.Text = FunGetNextStageName(ENM_NCR_STAGE._60_再審審査判定_技術代表)
                cmbST06_DestTANTO.SetDataSource(dt, ENM_COMBO_SELECT_VALUE_TYPE._0_Required)

                cmbST06_SAISIN_IINKAI_HANTEI.SetDataSource(tblSAISIN_IINKAI_HANTEI_KB.ExcludeDeleted, ENM_COMBO_SELECT_VALUE_TYPE._0_Required)


                'SPEC: 60-2.③
                cmbKISYU.Enabled = False
                cmbSYANAI_CD.Enabled = False
                cmbFUTEKIGO_STATUS.Enabled = False
                cmbFUTEKIGO_KB.Enabled = False
                cmbFUTEKIGO_S_KB.Enabled = False
                cmbBUMON.Enabled = False
                mtxGOUKI.Enabled = False
                cmbBUHIN_BANGO.Enabled = False
                mtxHENKYAKU_RIYU.Enabled = False
                cmbFUTEKIGO_S_KB.Enabled = False
                cmbKISO_TANTO.Enabled = False
                mtxHINMEI.Enabled = False
                mtxZUBAN_KIKAKU.Enabled = False
                numSU.Enabled = False

                If PrMODE = ENM_DATA_OPERATION_MODE._3_UPDATE Then
                    _V003 = _V003_SYONIN_J_KANRI_List.AsEnumerable.
                                Where(Function(r) r.SYONIN_JUN = ENM_NCR_STAGE._60_再審審査判定_技術代表).
                                FirstOrDefault

                    _D003_NCR_J.SAISIN_IINKAI_HANTEI_KB = _V002_NCR_J.SAISIN_IINKAI_HANTEI_KB
                    _D003_NCR_J.SAISIN_IINKAI_SIRYO_NO = _V002_NCR_J.SAISIN_IINKAI_SIRYO_NO

                    If _V003 IsNot Nothing Then
                        cmbST06_DestTANTO.SelectedValue = _V003.SYAIN_ID
                        txtST06_Comment.Text = _V003.COMMENT
                        If Not _V003.RIYU.IsNullOrWhiteSpace And intStageID = ENM_NCR_STAGE._60_再審審査判定_技術代表 Then lblST06_Modoshi_Riyu.Visible = True
                        lblST06_Modoshi_Riyu.Text = "差戻理由：" & _V003.RIYU
                    End If
                End If

            End If
#End Region
#Region "               61"
            If intStageID >= ENM_NCR_STAGE._61_再審審査判定_品証代表 Then
                If FunExistAchievement(ENM_SYONIN_HOKOKUSYO_ID._1_NCR, _D003_NCR_J.HOKOKU_NO, ENM_NCR_STAGE._61_再審審査判定_品証代表) Then
                    dt = tblTANTO_SYONIN.AsEnumerable.
                                        Where(Function(r) r.Field(Of Integer)("SYONIN_HOKOKUSYO_ID") = 1 And r.Field(Of Integer)("SYONIN_JUN") = FunGetNextSYONIN_JUN(ENM_NCR_STAGE._61_再審審査判定_品証代表)).
                                        CopyToDataTable

                    mtxST06_UPD_YMD.Text = Today.ToString("yyyy/MM/dd")
                    mtxST06_NextStageName.Text = FunGetNextStageName(ENM_NCR_STAGE._61_再審審査判定_品証代表)
                    cmbST06_DestTANTO.SetDataSource(dt, ENM_COMBO_SELECT_VALUE_TYPE._0_Required)

                    cmbST06_SAISIN_IINKAI_HANTEI.SetDataSource(tblSAISIN_IINKAI_HANTEI_KB.ExcludeDeleted, ENM_COMBO_SELECT_VALUE_TYPE._0_Required)

                    'SPEC: 60-2.④
                    cmbST06_SAISIN_IINKAI_HANTEI.Enabled = False
                    mtxST06_SAISIN_IINKAI_SIRYO_NO.Enabled = False

                    If PrMODE = ENM_DATA_OPERATION_MODE._3_UPDATE Then
                        _V003 = _V003_SYONIN_J_KANRI_List.AsEnumerable.
                                    Where(Function(r) r.SYONIN_JUN = ENM_NCR_STAGE._61_再審審査判定_品証代表).
                                    FirstOrDefault

                        _D003_NCR_J.SAISIN_IINKAI_HANTEI_KB = _V002_NCR_J.SAISIN_IINKAI_HANTEI_KB
                        _D003_NCR_J.SAISIN_IINKAI_SIRYO_NO = _V002_NCR_J.SAISIN_IINKAI_SIRYO_NO

                        If _V003 IsNot Nothing Then
                            cmbST06_DestTANTO.SelectedValue = _V003.SYAIN_ID
                            txtST06_Comment.Text = _V003.COMMENT
                            If Not _V003.RIYU.IsNullOrWhiteSpace And intStageID = ENM_NCR_STAGE._61_再審審査判定_品証代表 Then lblST06_Modoshi_Riyu.Visible = True
                            lblST06_Modoshi_Riyu.Text = "差戻理由：" & _V003.RIYU
                        End If
                    End If
                Else
                    '次ステージが取得出来ない場合=登録内容により処理がスキップされた場合等はタブごと非表示
                    For Each page As TabPage In TabSTAGE.TabPages
                        If Val(page.Name.Substring(8)) = FunConvertSYONIN_JUN_TO_STAGE_NO(ENM_NCR_STAGE._61_再審審査判定_品証代表).ToString("00") Then
                            _tabPageManager.ChangeTabPageVisible(page.TabIndex, False)
                            Exit For
                        End If
                    Next
                End If
            End If
#End Region
#Region "               70"

            If intStageID >= ENM_NCR_STAGE._70_顧客再審処置_I_tag Then
                If FunExistAchievement(ENM_SYONIN_HOKOKUSYO_ID._1_NCR, _D003_NCR_J.HOKOKU_NO, ENM_NCR_STAGE._70_顧客再審処置_I_tag) Then
                    dt = tblTANTO_SYONIN.AsEnumerable.
                                Where(Function(r) r.Field(Of Integer)("SYONIN_HOKOKUSYO_ID") = 1 And r.Field(Of Integer)("SYONIN_JUN") = FunGetNextSYONIN_JUN(ENM_NCR_STAGE._70_顧客再審処置_I_tag)).
                                CopyToDataTable

                    mtxST07_UPD_YMD.Text = Today.ToString("yyyy/MM/dd")
                    mtxST07_NextStageName.Text = FunGetNextStageName(ENM_NCR_STAGE._70_顧客再審処置_I_tag)
                    cmbST07_DestTANTO.SetDataSource(dt, ENM_COMBO_SELECT_VALUE_TYPE._0_Required)

                    If PrMODE = ENM_DATA_OPERATION_MODE._3_UPDATE Then
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

                        If _V003 IsNot Nothing Then
                            cmbST07_DestTANTO.SelectedValue = _V003.SYAIN_ID
                            txtST07_Comment.Text = _V003.COMMENT
                            If Not _V003.RIYU.IsNullOrWhiteSpace And intStageID = ENM_NCR_STAGE._70_顧客再審処置_I_tag Then lblST07_Modoshi_Riyu.Visible = True
                            lblST07_Modoshi_Riyu.Text = "差戻理由：" & _V003.RIYU
                        End If
                    End If
                Else
                    '次ステージが取得出来ない場合=登録内容により処理がスキップされた場合等はタブごと非表示
                    For Each page As TabPage In TabSTAGE.TabPages
                        If Val(page.Name.Substring(8)) = FunConvertSYONIN_JUN_TO_STAGE_NO(ENM_NCR_STAGE._70_顧客再審処置_I_tag).ToString("00") Then
                            _tabPageManager.ChangeTabPageVisible(page.TabIndex, False)
                            Exit For
                        End If
                    Next
                End If
            End If
#End Region
#Region "               80"

            '80
            If intStageID >= ENM_NCR_STAGE._80_処置実施 Then
                If FunExistAchievement(ENM_SYONIN_HOKOKUSYO_ID._1_NCR, _D003_NCR_J.HOKOKU_NO, ENM_NCR_STAGE._80_処置実施) Then
                    dt = tblTANTO_SYONIN.AsEnumerable.
                          Where(Function(r) r.Field(Of Integer)("SYONIN_HOKOKUSYO_ID") = 1 And r.Field(Of Integer)("SYONIN_JUN") = FunGetNextSYONIN_JUN(ENM_NCR_STAGE._80_処置実施)).
                          CopyToDataTable

                    mtxST08_UPD_YMD.Text = Today.ToString("yyyy/MM/dd")
                    mtxST08_NextStageName.Text = FunGetNextStageName(ENM_NCR_STAGE._80_処置実施)
                    cmbST08_DestTANTO.SetDataSource(dt, ENM_COMBO_SELECT_VALUE_TYPE._0_Required)

                    cmbST08_1_HAIKYAKU_KB.SetDataSource(tblHAIKYAKU_KB, ENM_COMBO_SELECT_VALUE_TYPE._0_Required)
                    cmbST08_1_HAIKYAKU_TANTO.SetDataSource(tblTANTO, ENM_COMBO_SELECT_VALUE_TYPE._0_Required)
                    cmbST08_2_KENSA_KEKKA.SetDataSource(tblKENSA_KEKKA_KB, ENM_COMBO_SELECT_VALUE_TYPE._0_Required)
                    cmbST08_2_TANTO_SEIZO.SetDataSource(tblTANTO, ENM_COMBO_SELECT_VALUE_TYPE._2_Option)
                    cmbST08_2_TANTO_SEIGI.SetDataSource(tblTANTO, ENM_COMBO_SELECT_VALUE_TYPE._2_Option)
                    cmbST08_2_TANTO_KENSA.SetDataSource(tblTANTO, ENM_COMBO_SELECT_VALUE_TYPE._2_Option)
                    cmbST08_3_HENKYAKU_TANTO.SetDataSource(tblTANTO, ENM_COMBO_SELECT_VALUE_TYPE._0_Required)
                    cmbST08_4_KISYU.SetDataSource(tblKISYU, ENM_COMBO_SELECT_VALUE_TYPE._2_Option)
                    cmbST08_4_BUHIN_BANGO.SetDataSource(tblBUHIN, ENM_COMBO_SELECT_VALUE_TYPE._2_Option)

                    If PrMODE = ENM_DATA_OPERATION_MODE._3_UPDATE Then
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
                            cmbST08_DestTANTO.SelectedValue = _V003.SYAIN_ID
                            txtST08_Comment.Text = _V003.COMMENT
                            If Not _V003.RIYU.IsNullOrWhiteSpace And intStageID = ENM_NCR_STAGE._80_処置実施 Then lblST08_Modoshi_Riyu.Visible = True
                            lblST08_Modoshi_Riyu.Text = "差戻理由：" & _V003.RIYU
                        End If

                        'SPEC: 80-2.④
                        _tabPageManagerST08Sub = New TabPageManager(tabST08_SUB)
                        Dim strTabpageName As String
                        Select Case _D003_NCR_J.KOKYAKU_SAISYU_HANTEI_KB
                            Case ENM_KOKYAKU_SAISYU_HANTEI_KB._3_廃却する
                                strTabpageName = "tabSTAGE08_" & ENM_STAGE80_TABPAGES._1_廃却実施記録
                            Case ENM_KOKYAKU_SAISYU_HANTEI_KB._4_返却する
                                strTabpageName = "tabSTAGE08_" & ENM_STAGE80_TABPAGES._2_返却実施記録
                            Case ENM_KOKYAKU_SAISYU_HANTEI_KB._5_転用する
                                strTabpageName = "tabSTAGE08_" & ENM_STAGE80_TABPAGES._3_転用先記録
                            Case ENM_KOKYAKU_SAISYU_HANTEI_KB._6_再加工する
                                strTabpageName = "tabSTAGE08_" & ENM_STAGE80_TABPAGES._4_再加工指示_記録
                            Case Else
                                Select Case _D003_NCR_J.SAISIN_IINKAI_HANTEI_KB
                                    Case ENM_SAISIN_IINKAI_HANTEI_KB._3_廃却する
                                        strTabpageName = "tabSTAGE08_" & ENM_STAGE80_TABPAGES._1_廃却実施記録
                                    Case ENM_SAISIN_IINKAI_HANTEI_KB._4_返却する
                                        strTabpageName = "tabSTAGE08_" & ENM_STAGE80_TABPAGES._2_返却実施記録
                                    Case ENM_SAISIN_IINKAI_HANTEI_KB._5_転用する
                                        strTabpageName = "tabSTAGE08_" & ENM_STAGE80_TABPAGES._3_転用先記録
                                    Case ENM_SAISIN_IINKAI_HANTEI_KB._6_再加工する
                                        strTabpageName = "tabSTAGE08_" & ENM_STAGE80_TABPAGES._4_再加工指示_記録
                                    Case Else
                                        Select Case _D003_NCR_J.JIZEN_SINSA_HANTEI_KB
                                            Case ENM_JIZEN_SINSA_HANTEI_KB._4_廃却する
                                                strTabpageName = "tabSTAGE08_" & ENM_STAGE80_TABPAGES._1_廃却実施記録
                                            Case ENM_JIZEN_SINSA_HANTEI_KB._5_返却する
                                                strTabpageName = "tabSTAGE08_" & ENM_STAGE80_TABPAGES._2_返却実施記録
                                            Case ENM_JIZEN_SINSA_HANTEI_KB._6_転用する
                                                strTabpageName = "tabSTAGE08_" & ENM_STAGE80_TABPAGES._3_転用先記録
                                            Case ENM_JIZEN_SINSA_HANTEI_KB._7_再加工する
                                                strTabpageName = "tabSTAGE08_" & ENM_STAGE80_TABPAGES._4_再加工指示_記録
                                            Case Else
                                                'Err
                                                Throw New ArgumentException("80-2.④ JIZEN_SINSA_HANTEI_KB")
                                        End Select
                                End Select
                        End Select
                        For Each page As TabPage In tabST08_SUB.TabPages
                            If page.Name = strTabpageName Then
                                tabST08_SUB.SelectedIndex = page.TabIndex
                            Else
                                '非表示
                                _tabPageManagerST08Sub.ChangeTabPageVisible(page.TabIndex, False)
                            End If
                        Next page
                        '
                    End If
                Else
                    '次ステージが取得出来ない場合=登録内容により処理がスキップされた場合等はタブごと非表示
                    For Each page As TabPage In TabSTAGE.TabPages
                        If Val(page.Name.Substring(8)) = FunConvertSYONIN_JUN_TO_STAGE_NO(ENM_NCR_STAGE._80_処置実施).ToString("00") Then
                            _tabPageManager.ChangeTabPageVisible(page.TabIndex, False)
                            Exit For
                        End If
                    Next
                End If
            End If

            '81
            If intStageID >= ENM_NCR_STAGE._81_処置実施_生技 Then
                dt = tblTANTO_SYONIN.AsEnumerable.
                          Where(Function(r) r.Field(Of Integer)("SYONIN_HOKOKUSYO_ID") = 1 And r.Field(Of Integer)("SYONIN_JUN") = FunGetNextSYONIN_JUN(ENM_NCR_STAGE._81_処置実施_生技)).
                          CopyToDataTable

                mtxST08_NextStageName.Text = FunGetNextStageName(ENM_NCR_STAGE._81_処置実施_生技)
                cmbST08_DestTANTO.SetDataSource(dt, ENM_COMBO_SELECT_VALUE_TYPE._0_Required)

                If PrMODE = ENM_DATA_OPERATION_MODE._3_UPDATE Then
                    _V003 = _V003_SYONIN_J_KANRI_List.AsEnumerable.
                                Where(Function(r) r.SYONIN_JUN = ENM_NCR_STAGE._81_処置実施_生技).
                                FirstOrDefault

                    If _V003 IsNot Nothing Then
                        cmbST08_DestTANTO.SelectedValue = _V003.SYAIN_ID
                        txtST08_Comment.Text = _V003.COMMENT
                        If Not _V003.RIYU.IsNullOrWhiteSpace And intStageID = ENM_NCR_STAGE._81_処置実施_生技 Then lblST08_Modoshi_Riyu.Visible = True
                        lblST08_Modoshi_Riyu.Text = "差戻理由：" & _V003.RIYU
                    End If
                End If
            End If

            '82
            If intStageID >= ENM_NCR_STAGE._82_処置実施_製造 Then
                dt = tblTANTO_SYONIN.AsEnumerable.
                          Where(Function(r) r.Field(Of Integer)("SYONIN_HOKOKUSYO_ID") = 1 And r.Field(Of Integer)("SYONIN_JUN") = FunGetNextSYONIN_JUN(ENM_NCR_STAGE._82_処置実施_製造)).
                          CopyToDataTable

                mtxST08_NextStageName.Text = FunGetNextStageName(ENM_NCR_STAGE._82_処置実施_製造)
                cmbST08_DestTANTO.SetDataSource(dt, ENM_COMBO_SELECT_VALUE_TYPE._0_Required)

                If PrMODE = ENM_DATA_OPERATION_MODE._3_UPDATE Then
                    _V003 = _V003_SYONIN_J_KANRI_List.AsEnumerable.
                                Where(Function(r) r.SYONIN_JUN = ENM_NCR_STAGE._82_処置実施_製造).
                                FirstOrDefault

                    If _V003 IsNot Nothing Then
                        cmbST08_DestTANTO.SelectedValue = _V003.SYAIN_ID
                        txtST08_Comment.Text = _V003.COMMENT
                        If Not _V003.RIYU.IsNullOrWhiteSpace And intStageID = ENM_NCR_STAGE._82_処置実施_製造 Then lblST08_Modoshi_Riyu.Visible = True
                        lblST08_Modoshi_Riyu.Text = "差戻理由：" & _V003.RIYU
                    End If
                End If
            End If

            '83
            If intStageID >= ENM_NCR_STAGE._83_処置実施_検査 Then
                dt = tblTANTO_SYONIN.AsEnumerable.
                          Where(Function(r) r.Field(Of Integer)("SYONIN_HOKOKUSYO_ID") = 1 And r.Field(Of Integer)("SYONIN_JUN") = FunGetNextSYONIN_JUN(ENM_NCR_STAGE._83_処置実施_検査)).
                          CopyToDataTable

                mtxST08_NextStageName.Text = FunGetNextStageName(ENM_NCR_STAGE._83_処置実施_検査)
                cmbST08_DestTANTO.SetDataSource(dt, ENM_COMBO_SELECT_VALUE_TYPE._0_Required)

                If PrMODE = ENM_DATA_OPERATION_MODE._3_UPDATE Then
                    _V003 = _V003_SYONIN_J_KANRI_List.AsEnumerable.
                                Where(Function(r) r.SYONIN_JUN = ENM_NCR_STAGE._83_処置実施_検査).
                                FirstOrDefault

                    If _V003 IsNot Nothing Then
                        cmbST08_DestTANTO.SelectedValue = _V003.SYAIN_ID
                        txtST08_Comment.Text = _V003.COMMENT
                        If Not _V003.RIYU.IsNullOrWhiteSpace And intStageID = ENM_NCR_STAGE._83_処置実施_検査 Then lblST08_Modoshi_Riyu.Visible = True
                        lblST08_Modoshi_Riyu.Text = "差戻理由：" & _V003.RIYU
                    End If
                End If
            End If

#End Region
#Region "               90"
            If intStageID >= ENM_NCR_STAGE._90_処置実施確認_管理T Then
                dt = tblTANTO_SYONIN.AsEnumerable.
                            Where(Function(r) r.Field(Of Integer)("SYONIN_HOKOKUSYO_ID") = 1 And r.Field(Of Integer)("SYONIN_JUN") = FunGetNextSYONIN_JUN(ENM_NCR_STAGE._90_処置実施確認_管理T)).
                            CopyToDataTable

                mtxST09_UPD_YMD.Text = Today.ToString("yyyy/MM/dd")
                mtxST09_NextStageName.Text = FunGetNextStageName(ENM_NCR_STAGE._90_処置実施確認_管理T)
                cmbST09_DestTANTO.SetDataSource(dt, ENM_COMBO_SELECT_VALUE_TYPE._0_Required)

                If PrMODE = ENM_DATA_OPERATION_MODE._3_UPDATE Then
                    _V003 = _V003_SYONIN_J_KANRI_List.AsEnumerable.
                                Where(Function(r) r.SYONIN_JUN = ENM_NCR_STAGE._90_処置実施確認_管理T).
                                FirstOrDefault

                    If _V003 IsNot Nothing Then
                        cmbST09_DestTANTO.SelectedValue = _V003.SYAIN_ID
                        txtST09_Comment.Text = _V003.COMMENT
                        If Not _V003.RIYU.IsNullOrWhiteSpace And intStageID = ENM_NCR_STAGE._90_処置実施確認_管理T Then lblST09_Modoshi_Riyu.Visible = True
                        lblST09_Modoshi_Riyu.Text = "差戻理由：" & _V003.RIYU
                    End If
                End If
            End If
#End Region
#Region "               100"
            If intStageID >= ENM_NCR_STAGE._100_処置実施決裁_製造課長 Then
                dt = tblTANTO_SYONIN.AsEnumerable.
                    Where(Function(r) r.Field(Of Integer)("SYONIN_HOKOKUSYO_ID") = 1 And r.Field(Of Integer)("SYONIN_JUN") = FunGetNextSYONIN_JUN(ENM_NCR_STAGE._100_処置実施決裁_製造課長)).
                    CopyToDataTable

                mtxST10_UPD_YMD.Text = Today.ToString("yyyy/MM/dd")
                mtxST10_NextStageName.Text = FunGetNextStageName(ENM_NCR_STAGE._100_処置実施決裁_製造課長)
                cmbST10_DestTANTO.SetDataSource(dt, ENM_COMBO_SELECT_VALUE_TYPE._0_Required)

                If PrMODE = ENM_DATA_OPERATION_MODE._3_UPDATE Then
                    _V003 = _V003_SYONIN_J_KANRI_List.AsEnumerable.
                                Where(Function(r) r.SYONIN_JUN = ENM_NCR_STAGE._100_処置実施決裁_製造課長).
                                FirstOrDefault

                    If _V003 IsNot Nothing Then
                        cmbST10_DestTANTO.SelectedValue = _V003.SYAIN_ID
                        txtST10_Comment.Text = _V003.COMMENT
                        If Not _V003.RIYU.IsNullOrWhiteSpace And intStageID = ENM_NCR_STAGE._100_処置実施決裁_製造課長 Then lblST10_Modoshi_Riyu.Visible = True
                        lblST10_Modoshi_Riyu.Text = "差戻理由：" & _V003.RIYU
                    End If
                End If
            End If
#End Region
#Region "               110"
            If intStageID >= ENM_NCR_STAGE._110_abcde処置担当 Then
                dt = tblTANTO_SYONIN.AsEnumerable.
                          Where(Function(r) r.Field(Of Integer)("SYONIN_HOKOKUSYO_ID") = 1 And r.Field(Of Integer)("SYONIN_JUN") = FunGetNextSYONIN_JUN(ENM_NCR_STAGE._110_abcde処置担当)).
                          CopyToDataTable

                mtxST11_UPD_YMD.Text = Today.ToString("yyyy/MM/dd")
                mtxST11_NextStageName.Text = FunGetNextStageName(ENM_NCR_STAGE._110_abcde処置担当)
                cmbST11_DestTANTO.SetDataSource(dt, ENM_COMBO_SELECT_VALUE_TYPE._0_Required)

                If PrMODE = ENM_DATA_OPERATION_MODE._3_UPDATE Then
                    _V003 = _V003_SYONIN_J_KANRI_List.AsEnumerable.
                                Where(Function(r) r.SYONIN_JUN = ENM_NCR_STAGE._110_abcde処置担当).
                                FirstOrDefault

                    _D003_NCR_J.SYOCHI_KEKKA_A = CBool(_V002_NCR_J.SYOCHI_KEKKA_A)
                    _D003_NCR_J.SYOCHI_KEKKA_B = CBool(_V002_NCR_J.SYOCHI_KEKKA_B)
                    _D003_NCR_J.SYOCHI_KEKKA_C = CBool(_V002_NCR_J.SYOCHI_KEKKA_C)
                    _D003_NCR_J.SYOCHI_D_UMU_KB = CBool(_V002_NCR_J.SYOCHI_D_UMU_KB)
                    _D003_NCR_J.SYOCHI_D_YOHI_KB = CBool(_V002_NCR_J.SYOCHI_E_YOHI_KB)
                    _D003_NCR_J.SYOCHI_D_SYOCHI_KIROKU = _V002_NCR_J.SYOCHI_D_SYOCHI_KIROKU
                    _D003_NCR_J.SYOCHI_E_UMU_KB = CBool(_V002_NCR_J.SYOCHI_D_UMU_KB)
                    _D003_NCR_J.SYOCHI_E_YOHI_KB = CBool(_V002_NCR_J.SYOCHI_E_YOHI_KB)
                    _D003_NCR_J.SYOCHI_E_SYOCHI_KIROKU = _V002_NCR_J.SYOCHI_E_SYOCHI_KIROKU

                    If _V003 IsNot Nothing Then
                        cmbST11_DestTANTO.SelectedValue = _V003.SYAIN_ID
                        txtST11_Comment.Text = _V003.COMMENT
                        If Not _V003.RIYU.IsNullOrWhiteSpace And intStageID = ENM_NCR_STAGE._110_abcde処置担当 Then lblST11_Modoshi_Riyu.Visible = True
                        lblST11_Modoshi_Riyu.Text = "差戻理由：" & _V003.RIYU
                    End If
                End If
            End If
#End Region
#Region "               120"
            If intStageID >= ENM_NCR_STAGE._120_abcde処置確認 Then

            End If
#End Region

            Return True
        Catch ex As Exception
            EM.ErrorSyori(ex, False, conblnNonMsg)
            Return False
        End Try
    End Function

#End Region

    Private Sub TabSTAGE_SelectedIndexChanged(sender As Object, e As EventArgs) 'Handles TabSTAGE.SelectedIndexChanged
        If TabSTAGE.SelectedTab.Enabled = False Then
            cmdFunc1.Enabled = False
        End If
    End Sub
#End Region

#Region "共通"

#Region "部門区分"
    Private Sub CmbBUMON_SelectedValueChanged(sender As Object, e As EventArgs) Handles cmbBUMON.SelectedValueChanged
        Select Case cmbBUMON.SelectedValue.ToString
            Case Context.ENM_BUMON_KB._2_LP
                lblSYANAI_CD.Visible = True
                cmbSYANAI_CD.Visible = True
            Case Else
                lblSYANAI_CD.Visible = False
                cmbSYANAI_CD.Visible = False
                _D003_NCR_J.SYANAI_CD = ""
        End Select
    End Sub

    'UNDONE: ErrorProvider 表示名を適切に

    Private Sub CmbBUMON_Validating(sender As Object, e As System.ComponentModel.CancelEventArgs) Handles cmbBUMON.Validating
        Dim cmb As ComboboxEx = DirectCast(sender, ComboboxEx)

        If cmb.SelectedValue = cmb.NullValue Then
            'e.Cancel = True
            ErrorProvider.SetError(cmb, String.Format(My.Resources.infoMsgRequireSelectOrInput, "部門"))
            ErrorProvider.SetIconAlignment(cmb, ErrorIconAlignment.MiddleLeft)
            pri_blnValidated = False
        Else
            ErrorProvider.ClearError(cmb)
            pri_blnValidated = True
        End If
    End Sub
#End Region

#Region "機種"
    Private Sub CmbKISYU_Validating(sender As Object, e As System.ComponentModel.CancelEventArgs) Handles cmbKISYU.Validating
        Dim cmb As ComboboxEx = DirectCast(sender, ComboboxEx)

        If cmb.SelectedValue = cmb.NullValue Then
            'e.Cancel = True
            ErrorProvider.SetError(cmb, String.Format(My.Resources.infoMsgRequireSelectOrInput, "機種"))
            ErrorProvider.SetIconAlignment(cmb, ErrorIconAlignment.MiddleLeft)
            pri_blnValidated = False
        Else
            ErrorProvider.ClearError(cmb)
            pri_blnValidated = True
        End If
    End Sub
#End Region

#Region "社内コード"
    Private Sub CmbSYANAI_CD_Validated(sender As Object, e As EventArgs) Handles cmbSYANAI_CD.Validated
        If cmbSYANAI_CD.SelectedValue IsNot Nothing Then
            Dim dr As DataRow = DirectCast(cmbSYANAI_CD.DataSource, DataTable).AsEnumerable.Where(Function(r) r.Field(Of String)("SYANAI_CD") = cmbSYANAI_CD.SelectedValue).FirstOrDefault
            _D003_NCR_J.BUHIN_BANGO = dr.Item("BUHIN_BANGO")
            _D003_NCR_J.BUHIN_NAME = dr.Item("BUHIN_MEI")
        Else
            _D003_NCR_J.BUHIN_BANGO = ""
            _D003_NCR_J.BUHIN_NAME = ""
        End If
    End Sub
#End Region

#Region "部品番号"

    Private Sub CmbBUHIN_BANGO_Validated(sender As Object, e As EventArgs) Handles cmbBUHIN_BANGO.Validated
        'CHECK: SelectedValueにバインドしているため、SelectedValueChanged自身やその前に発生するValidating時だと設定できない
        If cmbBUHIN_BANGO.SelectedValue IsNot Nothing Then
            Dim dr As DataRow = DirectCast(cmbBUHIN_BANGO.DataSource, DataTable).AsEnumerable.Where(Function(r) r.Field(Of String)("VALUE") = cmbBUHIN_BANGO.SelectedValue).FirstOrDefault
            _D003_NCR_J.SYANAI_CD = dr.Item("SYANAI_CD")
            _D003_NCR_J.BUHIN_NAME = dr.Item("BUHIN_NAME")

            '再発チェック
            _D003_NCR_J.SAIHATU = FunIsReIssue(_D003_NCR_J.BUHIN_BANGO, _D003_NCR_J.FUTEKIGO_KB, _D003_NCR_J.FUTEKIGO_S_KB)
        Else
            _D003_NCR_J.SYANAI_CD = ""
            _D003_NCR_J.BUHIN_NAME = ""
        End If
    End Sub

    Private Sub CmbBUHIN_BANGO_Validating(sender As Object, e As System.ComponentModel.CancelEventArgs) Handles cmbBUHIN_BANGO.Validating
        Dim cmb As ComboboxEx = DirectCast(sender, ComboboxEx)

        If cmb.SelectedValue = cmb.NullValue Then
            'e.Cancel = True
            ErrorProvider.SetError(cmb, String.Format(My.Resources.infoMsgRequireSelectOrInput, "部品番号"))
            ErrorProvider.SetIconAlignment(cmb, ErrorIconAlignment.MiddleLeft)
            pri_blnValidated = False
        Else
            ErrorProvider.ClearError(cmb)
            pri_blnValidated = True
        End If
    End Sub
#End Region

#Region "製造番号(号機)"
    Private Sub MtxGOUKI_Validating(sender As Object, e As System.ComponentModel.CancelEventArgs) Handles mtxGOUKI.Validating
        Dim mtx As MaskedTextBoxEx = DirectCast(sender, MaskedTextBoxEx)

        If mtx.Text.IsNullOrWhiteSpace = True Then
            'e.Cancel = True
            ErrorProvider.SetError(mtx, String.Format(My.Resources.infoMsgRequireSelectOrInput, "製造番号(号機)"))
            ErrorProvider.SetIconAlignment(mtx, ErrorIconAlignment.MiddleLeft)
            pri_blnValidated = False
        Else
            ErrorProvider.ClearError(mtx)
            pri_blnValidated = True
        End If
    End Sub
#End Region

#Region "状態区分"
    Private Sub CmbFUTEKIGO_STATUS_SelectedValueChanged(sender As Object, e As EventArgs) Handles cmbFUTEKIGO_STATUS.SelectedValueChanged
        Dim cmb As ComboboxEx = DirectCast(sender, ComboboxEx)

        Dim blnRET As Boolean = (cmb.SelectedValue = ENM_FUTEKIGO_JYOTAI_KB._3_返却品.ToString)
        lblFUTEKIGO_NAIYO.Visible = blnRET
        mtxHENKYAKU_RIYU.Visible = blnRET
        mtxHENKYAKU_RIYU.Enabled = blnRET
    End Sub

    Private Sub CmbFUTEKIGO_STATUS_Validating(sender As Object, e As System.ComponentModel.CancelEventArgs) Handles cmbFUTEKIGO_STATUS.Validating
        Dim cmb As ComboboxEx = DirectCast(sender, ComboboxEx)

        If cmb.SelectedValue = cmb.NullValue Then
            'e.Cancel = True
            ErrorProvider.SetError(cmb, String.Format(My.Resources.infoMsgRequireSelectOrInput, "状態区分"))
            ErrorProvider.SetIconAlignment(cmb, ErrorIconAlignment.MiddleLeft)
            pri_blnValidated = False
        Else
            ErrorProvider.ClearError(cmb)
            pri_blnValidated = True
        End If
    End Sub
#End Region

#Region "返却理由"
    Private Sub MtxFUTEKIGO_NAIYO_Validating(sender As Object, e As System.ComponentModel.CancelEventArgs) Handles mtxHENKYAKU_RIYU.Validating
        Dim mtx As MaskedTextBoxEx = DirectCast(sender, MaskedTextBoxEx)

        If mtx.Enabled = True AndAlso mtx.Text.IsNullOrWhiteSpace = True Then
            'e.Cancel = True
            ErrorProvider.SetError(mtx, String.Format(My.Resources.infoMsgRequireSelectOrInput, "返却理由"))
            ErrorProvider.SetIconAlignment(mtx, ErrorIconAlignment.MiddleLeft)
            pri_blnValidated = False
        Else
            ErrorProvider.ClearError(mtx)
            pri_blnValidated = True
        End If
    End Sub
#End Region

#Region "不適合区分"
    Private Sub CmbFUTEKIGO_KB_SelectedValueChanged(sender As Object, e As EventArgs) Handles cmbFUTEKIGO_KB.SelectedValueChanged

        Dim cmb As ComboboxEx = DirectCast(sender, ComboboxEx)

        If cmb.SelectedValue <> "" Then
            Dim dt As New DataTableEx
            Using DB As ClsDbUtility = DBOpen()
                FunGetCodeDataTable(DB, "不適合" & cmb.Text.Replace("・", "") & "区分", dt)
            End Using
            cmbFUTEKIGO_S_KB.SetDataSource(dt.ExcludeDeleted, ENM_COMBO_SELECT_VALUE_TYPE._0_Required)
            cmbFUTEKIGO_S_KB.DataBindings.Clear()
            _D003_NCR_J.FUTEKIGO_S_KB = ""
            cmbFUTEKIGO_S_KB.DataBindings.Add(New Binding(NameOf(cmbFUTEKIGO_S_KB.SelectedValue), _D003_NCR_J, NameOf(_D003_NCR_J.FUTEKIGO_S_KB), False, DataSourceUpdateMode.OnPropertyChanged, ""))
        Else
            cmbFUTEKIGO_S_KB.DataSource = Nothing
            cmbFUTEKIGO_S_KB.DataBindings.Clear()
        End If

    End Sub

    Private Sub CmbFUTEKIGO_KB_Validating(sender As Object, e As System.ComponentModel.CancelEventArgs) Handles cmbFUTEKIGO_KB.Validating
        Dim cmb As ComboboxEx = DirectCast(sender, ComboboxEx)

        If cmb.SelectedValue = cmb.NullValue Then
            'e.Cancel = True
            ErrorProvider.SetError(cmb, String.Format(My.Resources.infoMsgRequireSelectOrInput, "不適合区分"))
            ErrorProvider.SetIconAlignment(cmb, ErrorIconAlignment.MiddleLeft)
            pri_blnValidated = False
        Else
            ErrorProvider.ClearError(cmb)
            pri_blnValidated = True
        End If
    End Sub
#End Region

#Region "不適合詳細区分"
    Private Sub CmbFUTEKIGO_S_KB_Validated(sender As Object, e As EventArgs) Handles cmbFUTEKIGO_S_KB.Validated
        '再発チェック
        _D003_NCR_J.SAIHATU = FunIsReIssue(_D003_NCR_J.BUHIN_BANGO, _D003_NCR_J.FUTEKIGO_KB, _D003_NCR_J.FUTEKIGO_S_KB)
    End Sub

    Private Sub CmbFUTEKIGO_S_KB_Validating(sender As Object, e As System.ComponentModel.CancelEventArgs) Handles cmbFUTEKIGO_S_KB.Validating
        Dim cmb As ComboboxEx = DirectCast(sender, ComboboxEx)

        If cmb.SelectedValue = cmb.NullValue Then
            'e.Cancel = True
            ErrorProvider.SetError(cmb, String.Format(My.Resources.infoMsgRequireSelectOrInput, "不適合詳細区分"))
            ErrorProvider.SetIconAlignment(cmb, ErrorIconAlignment.MiddleLeft)
            pri_blnValidated = False
        Else
            ErrorProvider.ClearError(cmb)
            pri_blnValidated = True
        End If
    End Sub
#End Region

#Region "図番"
    Private Sub MtxZUBAN_KIKAKU_Validating(sender As Object, e As System.ComponentModel.CancelEventArgs) Handles mtxZUBAN_KIKAKU.Validating
        Dim mtx As MaskedTextBoxEx = DirectCast(sender, MaskedTextBoxEx)

        If mtx.Text.IsNullOrWhiteSpace = True Then
            'e.Cancel = True
            ErrorProvider.SetError(mtx, String.Format(My.Resources.infoMsgRequireSelectOrInput, "図番"))
            ErrorProvider.SetIconAlignment(mtx, ErrorIconAlignment.MiddleLeft)
            pri_blnValidated = False
        Else
            ErrorProvider.ClearError(mtx)
            pri_blnValidated = True
        End If
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
                                                                                                              cmbST11_DestTANTO.Validating
        Dim cmb As ComboboxEx = DirectCast(sender, ComboboxEx)
        If cmb.SelectedValue = cmb.NullValue Then
            'e.Cancel = True
            ErrorProvider.SetError(cmb, String.Format(My.Resources.infoMsgRequireSelectOrInput, "申請先社員"))
            ErrorProvider.SetIconAlignment(cmb, ErrorIconAlignment.MiddleLeft)
            pri_blnValidated = False
        Else
            ErrorProvider.ClearError(cmb)
            pri_blnValidated = True
        End If
    End Sub
#End Region

#Region "   STAGE1"
    Private Sub TxtST01_YOKYU_NAIYO_Validating(sender As Object, e As System.ComponentModel.CancelEventArgs) Handles txtST01_YOKYU_NAIYO.Validating
        Dim txt As TextBoxEx = DirectCast(sender, TextBoxEx)

        If txt.Text.IsNullOrWhiteSpace = True Then
            'e.Cancel = True
            ErrorProvider.SetError(txt, String.Format(My.Resources.infoMsgRequireSelectOrInput, "要求内容"))
            ErrorProvider.SetIconAlignment(txt, ErrorIconAlignment.MiddleLeft)
            pri_blnValidated = False
        Else
            ErrorProvider.ClearError(txt)
            pri_blnValidated = True
        End If
    End Sub

    Private Sub TxtST01_KEKKA_Validating(sender As Object, e As System.ComponentModel.CancelEventArgs) Handles txtST01_KEKKA.Validating
        Dim txt As TextBoxEx = DirectCast(sender, TextBoxEx)

        If txt.Text.IsNullOrWhiteSpace = True Then
            'e.Cancel = True
            ErrorProvider.SetError(txt, String.Format(My.Resources.infoMsgRequireSelectOrInput, "観察結果"))
            ErrorProvider.SetIconAlignment(txt, ErrorIconAlignment.MiddleLeft)
            pri_blnValidated = False
        Else
            ErrorProvider.ClearError(txt)
            pri_blnValidated = True
        End If
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
        txtST04_RIYU.Enabled = blnChecked
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

        If txt.Enabled = True AndAlso txt.Text.IsNullOrWhiteSpace = True Then
            'e.Cancel = True
            ErrorProvider.SetError(txt, String.Format(My.Resources.infoMsgRequireSelectOrInput, "否の理由"))
            ErrorProvider.SetIconAlignment(txt, ErrorIconAlignment.MiddleLeft)
            pri_blnValidated = False
        Else
            ErrorProvider.ClearError(txt)
            pri_blnValidated = True
        End If
    End Sub
#End Region
#Region "   STAGE5"
    '共通項目のみ
#End Region
#Region "   STAGE6"
    '共通項目のみ
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

            _D003_NCR_J.FILE_PATH = ofd.FileName
            'lbltmpFile1.Tag = ofd.FileName
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

    Private Sub SetPict1Data(ByVal strFileName() As String)

        Try
            pnlPict1.Cursor = Cursors.Hand

            lblPict1Path.Text = CompactString(strFileName(0), lblPict1Path, EllipsisFormat._4_Path) 'IO.Path.GetFileName(strFileName)
            'lblPict1Path.Tag = strFileName(0)
            _D003_NCR_J.G_FILE_PATH1 = strFileName(0)
            lblPict1Path.Links.Clear()
            lblPict1Path.Links.Add(0, lblPict1Path.Text.Length, strFileName(0))
            lblPict1Path.Visible = True
            lblPict1Path_Clear.Visible = True

            'Dim img As Image = New Bitmap(Image.FromFile(strFileName(0)), New Size(pnlPict1.Width, pnlPict1.Height))
            pnlPict1.Image = Image.FromFile(strFileName(0))
            'End Using

        Catch ex As OutOfMemoryException
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

    Private Sub SetPict2Data(ByVal strFileName() As String)
        Try
            pnlPict2.Cursor = Cursors.Hand

            lblPict2Path.Text = CompactString(strFileName(0), lblPict2Path, EllipsisFormat._4_Path) 'IO.Path.GetFileName(strFileName)
            'lblPict2Path.Tag = strFileName(0)
            _D003_NCR_J.G_FILE_PATH2 = strFileName(0)
            lblPict2Path.Links.Clear()
            lblPict2Path.Links.Add(0, lblPict2Path.Text.Length, strFileName)
            lblPict2Path.Visible = True
            lblPict2Path_Clear.Visible = True

            'UNDONE: 登録後の読込時、そのままだとメモリエラーが発生するのでbmpサイズ指定の必要あり？
            'Dim img As Image = New Bitmap(Image.FromFile(strFileName(0)), New Size(pnlPict2.Width, pnlPict1.Height))
            pnlPict2.Image = Image.FromFile(strFileName(0))
            'End Using
        Catch ex As OutOfMemoryException
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

#Region "Model - Control バインディング"
    Private Function FunSetBinding() As Boolean

        '共通
        mtxHOKUKO_NO.DataBindings.Add(New Binding(NameOf(mtxHOKUKO_NO.Text), _D003_NCR_J, NameOf(_D003_NCR_J.HOKOKU_NO), False, DataSourceUpdateMode.OnPropertyChanged, ""))
        cmbBUMON.DataBindings.Add(New Binding(NameOf(cmbBUMON.SelectedValue), _D003_NCR_J, NameOf(_D003_NCR_J.BUMON_KB), False, DataSourceUpdateMode.OnPropertyChanged, ""))
        chkClosed.DataBindings.Add(New Binding(NameOf(chkClosed.Checked), _D003_NCR_J, NameOf(_D003_NCR_J.CLOSE_FG), False, DataSourceUpdateMode.OnPropertyChanged, False))
        dtDraft.DataBindings.Add(New Binding(NameOf(dtDraft.ValueNonFormat), _D003_NCR_J, NameOf(_D003_NCR_J.ADD_YMD), False, DataSourceUpdateMode.OnPropertyChanged, ""))
        cmbKISO_TANTO.DataBindings.Add(New Binding(NameOf(cmbKISO_TANTO.SelectedValue), _D003_NCR_J, NameOf(_D003_NCR_J.ADD_SYAIN_ID), False, DataSourceUpdateMode.OnPropertyChanged, 0))
        cmbKISYU.DataBindings.Add(New Binding(NameOf(cmbKISYU.SelectedValue), _D003_NCR_J, NameOf(_D003_NCR_J.KISYU_ID), False, DataSourceUpdateMode.OnPropertyChanged, 0))
        mtxGOUKI.DataBindings.Add(New Binding(NameOf(mtxGOUKI.Text), _D003_NCR_J, NameOf(_D003_NCR_J.GOKI), False, DataSourceUpdateMode.OnPropertyChanged, ""))
        cmbSYANAI_CD.DataBindings.Add(New Binding(NameOf(cmbSYANAI_CD.SelectedValue), _D003_NCR_J, NameOf(_D003_NCR_J.SYANAI_CD), False, DataSourceUpdateMode.OnPropertyChanged, ""))
        cmbBUHIN_BANGO.DataBindings.Add(New Binding(NameOf(cmbBUHIN_BANGO.SelectedValue), _D003_NCR_J, NameOf(_D003_NCR_J.BUHIN_BANGO), False, DataSourceUpdateMode.OnPropertyChanged, ""))
        mtxHINMEI.DataBindings.Add(New Binding(NameOf(mtxHINMEI.Text), _D003_NCR_J, NameOf(_D003_NCR_J.BUHIN_NAME), False, DataSourceUpdateMode.OnPropertyChanged, ""))
        numSU.DataBindings.Add(New Binding(NameOf(numSU.Value), _D003_NCR_J, NameOf(_D003_NCR_J.SURYO), False, DataSourceUpdateMode.OnPropertyChanged, 1))
        cmbFUTEKIGO_STATUS.DataBindings.Add(New Binding(NameOf(cmbFUTEKIGO_STATUS.SelectedValue), _D003_NCR_J, NameOf(_D003_NCR_J.FUTEKIGO_JYOTAI_KB), False, DataSourceUpdateMode.OnPropertyChanged, ""))
        chkSAIHATU.DataBindings.Add(New Binding(NameOf(chkSAIHATU.Checked), _D003_NCR_J, NameOf(_D003_NCR_J.SAIHATU), False, DataSourceUpdateMode.OnPropertyChanged, ""))
        mtxHENKYAKU_RIYU.DataBindings.Add(New Binding(NameOf(mtxHENKYAKU_RIYU.Text), _D003_NCR_J, NameOf(_D003_NCR_J.FUTEKIGO_NAIYO), False, DataSourceUpdateMode.OnPropertyChanged, ""))
        cmbFUTEKIGO_KB.DataBindings.Add(New Binding(NameOf(cmbFUTEKIGO_KB.SelectedValue), _D003_NCR_J, NameOf(_D003_NCR_J.FUTEKIGO_KB), False, DataSourceUpdateMode.OnPropertyChanged, ""))
        'FUTEKIGO_S_KBはFUTEKIGO_KB変更時にバインド
        mtxZUBAN_KIKAKU.DataBindings.Add(New Binding(NameOf(mtxZUBAN_KIKAKU.Text), _D003_NCR_J, NameOf(_D003_NCR_J.ZUMEN_KIKAKU), False, DataSourceUpdateMode.OnPropertyChanged, ""))

        '添付資料
        lbltmpFile1.DataBindings.Add(New Binding(NameOf(lbltmpFile1.Tag), _D003_NCR_J, NameOf(_D003_NCR_J.FILE_PATH), False, DataSourceUpdateMode.OnPropertyChanged, ""))
        lblPict1Path.DataBindings.Add(New Binding(NameOf(lblPict1Path.Tag), _D003_NCR_J, NameOf(_D003_NCR_J.G_FILE_PATH1), False, DataSourceUpdateMode.OnPropertyChanged, ""))
        lblPict2Path.DataBindings.Add(New Binding(NameOf(lblPict2Path.Tag), _D003_NCR_J, NameOf(_D003_NCR_J.G_FILE_PATH2), False, DataSourceUpdateMode.OnPropertyChanged, ""))


        'STAGE01
        txtST01_YOKYU_NAIYO.DataBindings.Add(New Binding(NameOf(txtST01_YOKYU_NAIYO.Text), _D003_NCR_J, NameOf(_D003_NCR_J.YOKYU_NAIYO), False, DataSourceUpdateMode.OnPropertyChanged, ""))
        txtST01_KEKKA.DataBindings.Add(New Binding(NameOf(txtST01_KEKKA.Text), _D003_NCR_J, NameOf(_D003_NCR_J.KANSATU_KEKKA), False, DataSourceUpdateMode.OnPropertyChanged, ""))


        'STAGE02
        'mtxHOKUKO_NO.DataBindings.Add(New Binding(NameOf(mtxHOKUKO_NO.Text), _D003_NCR_J, NameOf(_D003_NCR_J.HOKOKU_NO)))

        'STAGE03
        'mtxHOKUKO_NO.DataBindings.Add(New Binding(NameOf(mtxHOKUKO_NO.Text), _D003_NCR_J, NameOf(_D003_NCR_J.HOKOKU_NO)))

        'STAGE04
        cmbST04_JIZENSINSA_HANTEI.DataBindings.Add(New Binding(NameOf(cmbST04_JIZENSINSA_HANTEI.SelectedValue), _D003_NCR_J, NameOf(_D003_NCR_J.JIZEN_SINSA_HANTEI_KB), False, DataSourceUpdateMode.OnPropertyChanged, ""))
        chkST04_ZESEI_SYOCHI_YOHI_KB.DataBindings.Add(New Binding(NameOf(chkST04_ZESEI_SYOCHI_YOHI_KB.Checked), _D003_NCR_J, NameOf(_D003_NCR_J.ZESEI_SYOCHI_YOHI_KB), False, DataSourceUpdateMode.OnPropertyChanged, ""))
        txtST04_RIYU.DataBindings.Add(New Binding(NameOf(txtST04_RIYU.Text), _D003_NCR_J, NameOf(_D003_NCR_J.ZESEI_NASI_RIYU), False, DataSourceUpdateMode.OnPropertyChanged, ""))

        'STAGE05
        'mtxHOKUKO_NO.DataBindings.Add(New Binding(NameOf(mtxHOKUKO_NO.Text), _D003_NCR_J, NameOf(_D003_NCR_J.HOKOKU_NO)))

        'STAGE06
        cmbST06_SAISIN_IINKAI_HANTEI.DataBindings.Add(New Binding(NameOf(cmbST06_SAISIN_IINKAI_HANTEI.SelectedValue), _D003_NCR_J, NameOf(_D003_NCR_J.SAISIN_IINKAI_HANTEI_KB), False, DataSourceUpdateMode.OnPropertyChanged, ""))
        mtxST06_SAISIN_IINKAI_SIRYO_NO.DataBindings.Add(New Binding(NameOf(mtxST06_SAISIN_IINKAI_SIRYO_NO.Text), _D003_NCR_J, NameOf(_D003_NCR_J.SAISIN_IINKAI_SIRYO_NO), False, DataSourceUpdateMode.OnPropertyChanged, ""))

        'STAGE07
        mtxST07_ITAG_NO.DataBindings.Add(New Binding(NameOf(mtxST07_ITAG_NO.Text), _D003_NCR_J, NameOf(_D003_NCR_J.ITAG_NO), False, DataSourceUpdateMode.OnPropertyChanged, ""))
        cmbST07_SAISIN_TANTO.DataBindings.Add(New Binding(NameOf(cmbST07_SAISIN_TANTO.SelectedValue), _D003_NCR_J, NameOf(_D003_NCR_J.KOKYAKU_SAISIN_TANTO_ID), False, DataSourceUpdateMode.OnPropertyChanged, ""))
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
        'mtxHOKUKO_NO.DataBindings.Add(New Binding(NameOf(mtxHOKUKO_NO.Text), _D003_NCR_J, NameOf(_D003_NCR_J.HOKOKU_NO)))

        'STAGE10
        'mtxHOKUKO_NO.DataBindings.Add(New Binding(NameOf(mtxHOKUKO_NO.Text), _D003_NCR_J, NameOf(_D003_NCR_J.HOKOKU_NO)))

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


                    PrCurrentStage = PrDataRow.Item("SYONIN_JUN")

                    If PrCurrentStage >= ENM_NCR_STAGE._20_起草確認製造GL Then
                        cmbBUMON.Enabled = False
                    End If

                    Call FunInitializeTabControl(FunConvertSYONIN_JUN_TO_STAGE_NO(PrDataRow.Item("SYONIN_JUN")))
                    Call FunInitializeSTAGE(PrDataRow.Item("SYONIN_JUN"))
                    mtxHOKUKO_NO.Enabled = False

                    For Each page As TabPage In TabSTAGE.TabPages
                        If page.Text = "現ステージ" Then
                            'SPEC: 10-2.④
                            TabSTAGE.SelectedTab = page
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
            'ビューモデルをロード
            _V002_NCR_J = FunGetV002Model(dr.Item(NameOf(_D003_NCR_J.HOKOKU_NO)))
            _V003_SYONIN_J_KANRI_List = FunGetV003Model(ENM_SYONIN_HOKOKUSYO_ID._1_NCR, dr.Item(NameOf(_D003_NCR_J.HOKOKU_NO)))

            '-----モデルに値をセット

            '部門
            _D003_NCR_J.BUMON_KB = _V002_NCR_J.BUMON_KB

            '報告書No
            'mtxHOKUKO_NO.Text = .Item("")
            _D003_NCR_J.HOKOKU_NO = _V002_NCR_J.HOKOKU_NO

            '起草者
            'cmbKISO_TANTO.SelectedValue =""
            _D003_NCR_J.ADD_SYAIN_ID = _V002_NCR_J.ADD_SYAIN_ID

            '起草日
            'dtDraft.Text = .Item("")
            _D003_NCR_J.ADD_YMDHNS = _V002_NCR_J.ADD_YMDHNS

            '機種
            'cmbKISYU.SelectedValue = .Item("")
            _D003_NCR_J.KISYU_ID = _V002_NCR_J.KISYU_ID

            '部品番号
            'cmbBUHIN_BANGO.SelectedValue = .Item("")
            _D003_NCR_J.BUHIN_BANGO = _V002_NCR_J.BUHIN_BANGO

            '部品名称
            'mtxHINMEI.Text = .Item("")
            _D003_NCR_J.BUHIN_NAME = _V002_NCR_J.BUHIN_NAME

            '号機
            'mtxGOUKI.Text = .Item("")
            _D003_NCR_J.GOKI = _V002_NCR_J.GOKI

            '個数
            'numSU.Value = .Item("")
            _D003_NCR_J.SURYO = _V002_NCR_J.SURYO

            '再発
            'chkSAIHATU.Checked = CBool(.Item(""))
            _D003_NCR_J.SAIHATU = _V002_NCR_J.SAIHATU

            '状態区分
            'cmbFUTEKIGO_STATUS.SelectedValue = .Item("")
            _D003_NCR_J.FUTEKIGO_JYOTAI_KB = _V002_NCR_J.FUTEKIGO_JYOTAI_KB

            '返却品の場合 保留理由
            _D003_NCR_J.FUTEKIGO_NAIYO = _V002_NCR_J.FUTEKIGO_NAIYO

            '不適合区分
            'cmbFUTEKIGO_KB.SelectedValue = .Item("")
            _D003_NCR_J.FUTEKIGO_KB = _V002_NCR_J.FUTEKIGO_JYOTAI_KB

            _D003_NCR_J.FUTEKIGO_S_KB = _V002_NCR_J.FUTEKIGO_S_KB

            '図番/規格
            'mtxZUBAN_KIKAKU.Text = .Item("")
            _D003_NCR_J.ZUMEN_KIKAKU = _V002_NCR_J.ZUMEN_KIKAKU


            _D003_NCR_J.JIZEN_SINSA_HANTEI_KB = _V002_NCR_J.JIZEN_SINSA_HANTEI_KB
            _D003_NCR_J.ZESEI_SYOCHI_YOHI_KB = CBool(_V002_NCR_J.ZESEI_SYOCHI_YOHI_KB)

            _D003_NCR_J.FILE_PATH = _V002_NCR_J.FILE_PATH
            _D003_NCR_J.G_FILE_PATH1 = _V002_NCR_J.G_FILE_PATH1
            _D003_NCR_J.G_FILE_PATH2 = _V002_NCR_J.G_FILE_PATH2

            Return True
        Catch ex As Exception
            EM.ErrorSyori(ex, False, conblnNonMsg)
            Return False
        End Try
    End Function

#End Region

#Region "タブコントロール制御"

#Region "初期化"
    Private Function FunInitializeTabControl(ByVal intCurrentTabNo As Integer) As Boolean

        Try
            _tabPageManager = New TabPageManager(TabSTAGE)

            For Each page As TabPage In TabSTAGE.TabPages
                If page.Name <> "tabAttachment" Then
                    If Val(page.Name.Substring(8)) < intCurrentTabNo Then
                        'SPEC: 10-2.③
                        page.Text = tblNCR.AsEnumerable.Where(Function(r) r.Field(Of Integer)("VALUE") = FunConvertSTAGE_NO_TO_SYONIN_JUN(Val(page.Name.Substring(8)))).FirstOrDefault.Item("DISP")

                    ElseIf Val(page.Name.Substring(8)) = intCurrentTabNo Then
                        page.Text = "現ステージ" 'tblNCR.AsEnumerable.Where(Function(r) r.Field(Of String)("VALUE") = PrDataRow("SYONIN_JUN")).FirstOrDefault.Item("DISP")

                        '次ステージの承認担当者・コメント欄をバインド
                        Dim ctrlTANTO As Control() = Me.Controls.Find("cmbST" & intCurrentTabNo.ToString("00") & "_DestTANTO", True)
                        If ctrlTANTO.Length > 0 Then
                            Dim cmbTANTO As ComboboxEx = ctrlTANTO(0)
                            cmbTANTO.NullValue = 0
                            cmbTANTO.DataBindings.Add(New Binding(NameOf(cmbTANTO.SelectedValue), _D004_SYONIN_J_KANRI, NameOf(_D004_SYONIN_J_KANRI.SYAIN_ID), False, DataSourceUpdateMode.OnPropertyChanged, 0))
                        End If
                        Dim ctrlCOMMENT As Control() = Me.Controls.Find("txtST" & intCurrentTabNo.ToString("00") & "_Comment", True)
                        If ctrlCOMMENT.Length > 0 Then
                            Dim txtCOMMENT As TextBoxEx = ctrlCOMMENT(0)
                            txtCOMMENT.DataBindings.Add(New Binding(NameOf(txtCOMMENT.Text), _D004_SYONIN_J_KANRI, NameOf(_D004_SYONIN_J_KANRI.COMMENT), False, DataSourceUpdateMode.OnPropertyChanged, ""))
                        End If

                    ElseIf Val(page.Name.Substring(8)) > intCurrentTabNo Then
                        'SPEC: 10-2 ②
                        _tabPageManager.ChangeTabPageVisible(page.TabIndex, False)
                    End If

                    'SPEC: 10-2.⑤ 
                    If PrMODE = ENM_DATA_OPERATION_MODE._1_ADD Then
                        '新規作成時
                        'SPEC: (3).B 
                        page.Enabled = True
                    Else
                        'カレントユーザーの以外は参照のみ
                        If PrDataRow("SYONIN_JUN") >= ENM_NCR_STAGE._90_処置実施確認_管理T Then
                            page.Enabled = FunblnOwnCreated(ENM_SYONIN_HOKOKUSYO_ID._1_NCR, PrDataRow("HOKOKU_NO"), PrDataRow("SYONIN_JUN"))
                        End If
                    End If
                End If
            Next page


            '添付資料タブ初期化

            If Not _D003_NCR_J.FILE_PATH.IsNullOrWhiteSpace Then
                lbltmpFile1.Text = IO.Path.GetFileName(_D003_NCR_J.FILE_PATH)
                lbltmpFile1.Links.Clear()
                lbltmpFile1.Links.Add(0, lbltmpFile1.Text.Length, _D003_NCR_J.FILE_PATH)
                _D003_NCR_J.FILE_PATH = _D003_NCR_J.FILE_PATH
                lbltmpFile1.Visible = True
                lbltmpFile1_Clear.Visible = True
            End If
            If Not _D003_NCR_J.G_FILE_PATH1.IsNullOrWhiteSpace Then
                Call SetPict1Data({_D003_NCR_J.G_FILE_PATH1})
            End If
            If Not _D003_NCR_J.G_FILE_PATH2.IsNullOrWhiteSpace Then
                Call SetPict1Data({_D003_NCR_J.G_FILE_PATH2})
            End If

            Return True
        Catch ex As Exception
            EM.ErrorSyori(ex, False, conblnNonMsg)
            Return False
        End Try
    End Function

#End Region

#Region "STAGE別コントロール初期化"
    Private Function FunInitializeSTAGE(ByVal intStageID As Integer) As Boolean
        Dim dt As New DataTable
        Dim _V003 As New MODEL.V003_SYONIN_J_KANRI
        Try

#Region "               10"
            If intStageID >= ENM_NCR_STAGE._10_起草入力 Then
                dt = tblTANTO_SYONIN.AsEnumerable.
                                            Where(Function(r) r.Field(Of Integer)("SYONIN_HOKOKUSYO_ID") = 1 And r.Field(Of Integer)("SYONIN_JUN") = FunGetNextSYONIN_JUN(ENM_NCR_STAGE._10_起草入力)).
                                            CopyToDataTable

                mtxST01_UPD_YMD.Text = Today.ToString("yyyy/MM/dd")
                mtxST01_NextStageName.Text = FunGetNextStageName(ENM_NCR_STAGE._10_起草入力)
                cmbST01_DestTANTO.SetDataSource(dt, ENM_COMBO_SELECT_VALUE_TYPE._0_Required)


                If PrMODE = ENM_DATA_OPERATION_MODE._3_UPDATE Then
                    _D003_NCR_J.YOKYU_NAIYO = _V002_NCR_J.YOKYU_NAIYO
                    _D003_NCR_J.KANSATU_KEKKA = _V002_NCR_J.KANSATU_KEKKA


                    _V003 = _V003_SYONIN_J_KANRI_List.AsEnumerable.
                                Where(Function(r) r.SYONIN_JUN = ENM_NCR_STAGE._10_起草入力).
                                FirstOrDefault

                    If _V003 IsNot Nothing Then
                        If Not _V003.RIYU.IsNullOrWhiteSpace And intStageID = ENM_NCR_STAGE._10_起草入力 Then lblST01_Modoshi_Riyu.Visible = True
                        lblST01_Modoshi_Riyu.Text = "差戻理由：" & _V003.RIYU
                        cmbST01_DestTANTO.SelectedValue = _V003.SYAIN_ID
                    End If
                End If
            End If
#End Region


            If PrMODE = ENM_DATA_OPERATION_MODE._3_UPDATE Then
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

                If _V003 IsNot Nothing Then
                    cmbST07_DestTANTO.SelectedValue = _V003.SYAIN_ID
                    txtST07_Comment.Text = _V003.COMMENT
                    If Not _V003.RIYU.IsNullOrWhiteSpace And intStageID = ENM_NCR_STAGE._70_顧客再審処置_I_tag Then lblST07_Modoshi_Riyu.Visible = True
                    lblST07_Modoshi_Riyu.Text = "差戻理由：" & _V003.RIYU
                End If
            End If
            Else
            '次ステージが取得出来ない場合=登録内容により処理がスキップされた場合等はタブごと非表示
            For Each page As TabPage In TabSTAGE.TabPages
                If Val(page.Name.Substring(8)) = FunConvertSYONIN_JUN_TO_STAGE_NO(ENM_NCR_STAGE._70_顧客再審処置_I_tag).ToString("00") Then
                    _tabPageManager.ChangeTabPageVisible(page.TabIndex, False)
                    Exit For
                End If
            Next
            End If
            End If
#End Region
#Region "               80"

            '80
            If intStageID >= ENM_NCR_STAGE._80_処置実施 Then
                If FunExistAchievement(ENM_SYONIN_HOKOKUSYO_ID._1_NCR, _D003_NCR_J.HOKOKU_NO, ENM_NCR_STAGE._80_処置実施) Then
                    dt = tblTANTO_SYONIN.AsEnumerable.
                          Where(Function(r) r.Field(Of Integer)("SYONIN_HOKOKUSYO_ID") = 1 And r.Field(Of Integer)("SYONIN_JUN") = FunGetNextSYONIN_JUN(ENM_NCR_STAGE._80_処置実施)).
                          CopyToDataTable

                    mtxST08_UPD_YMD.Text = Today.ToString("yyyy/MM/dd")
                    mtxST08_NextStageName.Text = FunGetNextStageName(ENM_NCR_STAGE._80_処置実施)
                    cmbST08_DestTANTO.SetDataSource(dt, ENM_COMBO_SELECT_VALUE_TYPE._0_Required)

                    cmbST08_1_HAIKYAKU_KB.SetDataSource(tblHAIKYAKU_KB, ENM_COMBO_SELECT_VALUE_TYPE._0_Required)
                    cmbST08_1_HAIKYAKU_TANTO.SetDataSource(tblTANTO, ENM_COMBO_SELECT_VALUE_TYPE._0_Required)
                    cmbST08_2_KENSA_KEKKA.SetDataSource(tblKENSA_KEKKA_KB, ENM_COMBO_SELECT_VALUE_TYPE._0_Required)
                    cmbST08_2_TANTO_SEIZO.SetDataSource(tblTANTO, ENM_COMBO_SELECT_VALUE_TYPE._2_Option)
                    cmbST08_2_TANTO_SEIGI.SetDataSource(tblTANTO, ENM_COMBO_SELECT_VALUE_TYPE._2_Option)
                    cmbST08_2_TANTO_KENSA.SetDataSource(tblTANTO, ENM_COMBO_SELECT_VALUE_TYPE._2_Option)
                    cmbST08_3_HENKYAKU_TANTO.SetDataSource(tblTANTO, ENM_COMBO_SELECT_VALUE_TYPE._0_Required)
                    cmbST08_4_KISYU.SetDataSource(tblKISYU, ENM_COMBO_SELECT_VALUE_TYPE._2_Option)
                    cmbST08_4_BUHIN_BANGO.SetDataSource(tblBUHIN, ENM_COMBO_SELECT_VALUE_TYPE._2_Option)

                    If PrMODE = ENM_DATA_OPERATION_MODE._3_UPDATE Then
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
                            cmbST08_DestTANTO.SelectedValue = _V003.SYAIN_ID
                            txtST08_Comment.Text = _V003.COMMENT
                            If Not _V003.RIYU.IsNullOrWhiteSpace And intStageID = ENM_NCR_STAGE._80_処置実施 Then lblST08_Modoshi_Riyu.Visible = True
                            lblST08_Modoshi_Riyu.Text = "差戻理由：" & _V003.RIYU
                        End If

                        'SPEC: 80-2.④
                        _tabPageManagerST08Sub = New TabPageManager(tabST08_SUB)
                        Dim strTabpageName As String
                        Select Case _D003_NCR_J.KOKYAKU_SAISYU_HANTEI_KB
                            Case ENM_KOKYAKU_SAISYU_HANTEI_KB._3_廃却する
                                strTabpageName = "tabSTAGE08_" & ENM_STAGE80_TABPAGES._1_廃却実施記録
                            Case ENM_KOKYAKU_SAISYU_HANTEI_KB._4_返却する
                                strTabpageName = "tabSTAGE08_" & ENM_STAGE80_TABPAGES._2_返却実施記録
                            Case ENM_KOKYAKU_SAISYU_HANTEI_KB._5_転用する
                                strTabpageName = "tabSTAGE08_" & ENM_STAGE80_TABPAGES._3_転用先記録
                            Case ENM_KOKYAKU_SAISYU_HANTEI_KB._6_再加工する
                                strTabpageName = "tabSTAGE08_" & ENM_STAGE80_TABPAGES._4_再加工指示_記録
                            Case Else
                                Select Case _D003_NCR_J.SAISIN_IINKAI_HANTEI_KB
                                    Case ENM_SAISIN_IINKAI_HANTEI_KB._3_廃却する
                                        strTabpageName = "tabSTAGE08_" & ENM_STAGE80_TABPAGES._1_廃却実施記録
                                    Case ENM_SAISIN_IINKAI_HANTEI_KB._4_返却する
                                        strTabpageName = "tabSTAGE08_" & ENM_STAGE80_TABPAGES._2_返却実施記録
                                    Case ENM_SAISIN_IINKAI_HANTEI_KB._5_転用する
                                        strTabpageName = "tabSTAGE08_" & ENM_STAGE80_TABPAGES._3_転用先記録
                                    Case ENM_SAISIN_IINKAI_HANTEI_KB._6_再加工する
                                        strTabpageName = "tabSTAGE08_" & ENM_STAGE80_TABPAGES._4_再加工指示_記録
                                    Case Else
                                        Select Case _D003_NCR_J.JIZEN_SINSA_HANTEI_KB
                                            Case ENM_JIZEN_SINSA_HANTEI_KB._4_廃却する
                                                strTabpageName = "tabSTAGE08_" & ENM_STAGE80_TABPAGES._1_廃却実施記録
                                            Case ENM_JIZEN_SINSA_HANTEI_KB._5_返却する
                                                strTabpageName = "tabSTAGE08_" & ENM_STAGE80_TABPAGES._2_返却実施記録
                                            Case ENM_JIZEN_SINSA_HANTEI_KB._6_転用する
                                                strTabpageName = "tabSTAGE08_" & ENM_STAGE80_TABPAGES._3_転用先記録
                                            Case ENM_JIZEN_SINSA_HANTEI_KB._7_再加工する
                                                strTabpageName = "tabSTAGE08_" & ENM_STAGE80_TABPAGES._4_再加工指示_記録
                                            Case Else
                                                'Err
                                                Throw New ArgumentException("80-2.④ JIZEN_SINSA_HANTEI_KB")
                                        End Select
                                End Select
                        End Select
                        For Each page As TabPage In tabST08_SUB.TabPages
                            If page.Name = strTabpageName Then
                                tabST08_SUB.SelectedIndex = page.TabIndex
                            Else
                                '非表示
                                _tabPageManagerST08Sub.ChangeTabPageVisible(page.TabIndex, False)
                            End If
                        Next page
                        '
                    End If
                Else
                    '次ステージが取得出来ない場合=登録内容により処理がスキップされた場合等はタブごと非表示
                    For Each page As TabPage In TabSTAGE.TabPages
                        If Val(page.Name.Substring(8)) = FunConvertSYONIN_JUN_TO_STAGE_NO(ENM_NCR_STAGE._80_処置実施).ToString("00") Then
                            _tabPageManager.ChangeTabPageVisible(page.TabIndex, False)
                            Exit For
                        End If
                    Next
                End If
            End If

            '81
            If intStageID >= ENM_NCR_STAGE._81_処置実施_生技 Then
                dt = tblTANTO_SYONIN.AsEnumerable.
                          Where(Function(r) r.Field(Of Integer)("SYONIN_HOKOKUSYO_ID") = 1 And r.Field(Of Integer)("SYONIN_JUN") = FunGetNextSYONIN_JUN(ENM_NCR_STAGE._81_処置実施_生技)).
                          CopyToDataTable

                mtxST08_NextStageName.Text = FunGetNextStageName(ENM_NCR_STAGE._81_処置実施_生技)
                cmbST08_DestTANTO.SetDataSource(dt, ENM_COMBO_SELECT_VALUE_TYPE._0_Required)

                If PrMODE = ENM_DATA_OPERATION_MODE._3_UPDATE Then
                    _V003 = _V003_SYONIN_J_KANRI_List.AsEnumerable.
                                Where(Function(r) r.SYONIN_JUN = ENM_NCR_STAGE._81_処置実施_生技).
                                FirstOrDefault

                    If _V003 IsNot Nothing Then
                        cmbST08_DestTANTO.SelectedValue = _V003.SYAIN_ID
                        txtST08_Comment.Text = _V003.COMMENT
                        If Not _V003.RIYU.IsNullOrWhiteSpace And intStageID = ENM_NCR_STAGE._81_処置実施_生技 Then lblST08_Modoshi_Riyu.Visible = True
                        lblST08_Modoshi_Riyu.Text = "差戻理由：" & _V003.RIYU
                    End If
                End If
            End If

            '82
            If intStageID >= ENM_NCR_STAGE._82_処置実施_製造 Then
                dt = tblTANTO_SYONIN.AsEnumerable.
                          Where(Function(r) r.Field(Of Integer)("SYONIN_HOKOKUSYO_ID") = 1 And r.Field(Of Integer)("SYONIN_JUN") = FunGetNextSYONIN_JUN(ENM_NCR_STAGE._82_処置実施_製造)).
                          CopyToDataTable

                mtxST08_NextStageName.Text = FunGetNextStageName(ENM_NCR_STAGE._82_処置実施_製造)
                cmbST08_DestTANTO.SetDataSource(dt, ENM_COMBO_SELECT_VALUE_TYPE._0_Required)

                If PrMODE = ENM_DATA_OPERATION_MODE._3_UPDATE Then
                    _V003 = _V003_SYONIN_J_KANRI_List.AsEnumerable.
                                Where(Function(r) r.SYONIN_JUN = ENM_NCR_STAGE._82_処置実施_製造).
                                FirstOrDefault

                    If _V003 IsNot Nothing Then
                        cmbST08_DestTANTO.SelectedValue = _V003.SYAIN_ID
                        txtST08_Comment.Text = _V003.COMMENT
                        If Not _V003.RIYU.IsNullOrWhiteSpace And intStageID = ENM_NCR_STAGE._82_処置実施_製造 Then lblST08_Modoshi_Riyu.Visible = True
                        lblST08_Modoshi_Riyu.Text = "差戻理由：" & _V003.RIYU
                    End If
                End If
            End If

            '83
            If intStageID >= ENM_NCR_STAGE._83_処置実施_検査 Then
                dt = tblTANTO_SYONIN.AsEnumerable.
                          Where(Function(r) r.Field(Of Integer)("SYONIN_HOKOKUSYO_ID") = 1 And r.Field(Of Integer)("SYONIN_JUN") = FunGetNextSYONIN_JUN(ENM_NCR_STAGE._83_処置実施_検査)).
                          CopyToDataTable

                mtxST08_NextStageName.Text = FunGetNextStageName(ENM_NCR_STAGE._83_処置実施_検査)
                cmbST08_DestTANTO.SetDataSource(dt, ENM_COMBO_SELECT_VALUE_TYPE._0_Required)

                If PrMODE = ENM_DATA_OPERATION_MODE._3_UPDATE Then
                    _V003 = _V003_SYONIN_J_KANRI_List.AsEnumerable.
                                Where(Function(r) r.SYONIN_JUN = ENM_NCR_STAGE._83_処置実施_検査).
                                FirstOrDefault

                    If _V003 IsNot Nothing Then
                        cmbST08_DestTANTO.SelectedValue = _V003.SYAIN_ID
                        txtST08_Comment.Text = _V003.COMMENT
                        If Not _V003.RIYU.IsNullOrWhiteSpace And intStageID = ENM_NCR_STAGE._83_処置実施_検査 Then lblST08_Modoshi_Riyu.Visible = True
                        lblST08_Modoshi_Riyu.Text = "差戻理由：" & _V003.RIYU
                    End If
                End If
            End If

#End Region
#Region "               90"
            If intStageID >= ENM_NCR_STAGE._90_処置実施確認_管理T Then
                dt = tblTANTO_SYONIN.AsEnumerable.
                            Where(Function(r) r.Field(Of Integer)("SYONIN_HOKOKUSYO_ID") = 1 And r.Field(Of Integer)("SYONIN_JUN") = FunGetNextSYONIN_JUN(ENM_NCR_STAGE._90_処置実施確認_管理T)).
                            CopyToDataTable

                mtxST09_UPD_YMD.Text = Today.ToString("yyyy/MM/dd")
                mtxST09_NextStageName.Text = FunGetNextStageName(ENM_NCR_STAGE._90_処置実施確認_管理T)
                cmbST09_DestTANTO.SetDataSource(dt, ENM_COMBO_SELECT_VALUE_TYPE._0_Required)

                If PrMODE = ENM_DATA_OPERATION_MODE._3_UPDATE Then
                    _V003 = _V003_SYONIN_J_KANRI_List.AsEnumerable.
                                Where(Function(r) r.SYONIN_JUN = ENM_NCR_STAGE._90_処置実施確認_管理T).
                                FirstOrDefault

                    If _V003 IsNot Nothing Then
                        cmbST09_DestTANTO.SelectedValue = _V003.SYAIN_ID
                        txtST09_Comment.Text = _V003.COMMENT
                        If Not _V003.RIYU.IsNullOrWhiteSpace And intStageID = ENM_NCR_STAGE._90_処置実施確認_管理T Then lblST09_Modoshi_Riyu.Visible = True
                        lblST09_Modoshi_Riyu.Text = "差戻理由：" & _V003.RIYU
                    End If
                End If
            End If
#End Region
#Region "               100"
            If intStageID >= ENM_NCR_STAGE._100_処置実施決裁_製造課長 Then
                dt = tblTANTO_SYONIN.AsEnumerable.
                    Where(Function(r) r.Field(Of Integer)("SYONIN_HOKOKUSYO_ID") = 1 And r.Field(Of Integer)("SYONIN_JUN") = FunGetNextSYONIN_JUN(ENM_NCR_STAGE._100_処置実施決裁_製造課長)).
                    CopyToDataTable

                mtxST10_UPD_YMD.Text = Today.ToString("yyyy/MM/dd")
                mtxST10_NextStageName.Text = FunGetNextStageName(ENM_NCR_STAGE._100_処置実施決裁_製造課長)
                cmbST10_DestTANTO.SetDataSource(dt, ENM_COMBO_SELECT_VALUE_TYPE._0_Required)

                If PrMODE = ENM_DATA_OPERATION_MODE._3_UPDATE Then
                    _V003 = _V003_SYONIN_J_KANRI_List.AsEnumerable.
                                Where(Function(r) r.SYONIN_JUN = ENM_NCR_STAGE._100_処置実施決裁_製造課長).
                                FirstOrDefault

                    If _V003 IsNot Nothing Then
                        cmbST10_DestTANTO.SelectedValue = _V003.SYAIN_ID
                        txtST10_Comment.Text = _V003.COMMENT
                        If Not _V003.RIYU.IsNullOrWhiteSpace And intStageID = ENM_NCR_STAGE._100_処置実施決裁_製造課長 Then lblST10_Modoshi_Riyu.Visible = True
                        lblST10_Modoshi_Riyu.Text = "差戻理由：" & _V003.RIYU
                    End If
                End If
            End If
#End Region
#Region "               110"
            If intStageID >= ENM_NCR_STAGE._110_abcde処置担当 Then
                dt = tblTANTO_SYONIN.AsEnumerable.
                          Where(Function(r) r.Field(Of Integer)("SYONIN_HOKOKUSYO_ID") = 1 And r.Field(Of Integer)("SYONIN_JUN") = FunGetNextSYONIN_JUN(ENM_NCR_STAGE._110_abcde処置担当)).
                          CopyToDataTable

                mtxST11_UPD_YMD.Text = Today.ToString("yyyy/MM/dd")
                mtxST11_NextStageName.Text = FunGetNextStageName(ENM_NCR_STAGE._110_abcde処置担当)
                cmbST11_DestTANTO.SetDataSource(dt, ENM_COMBO_SELECT_VALUE_TYPE._0_Required)

                If PrMODE = ENM_DATA_OPERATION_MODE._3_UPDATE Then
                    _V003 = _V003_SYONIN_J_KANRI_List.AsEnumerable.
                                Where(Function(r) r.SYONIN_JUN = ENM_NCR_STAGE._110_abcde処置担当).
                                FirstOrDefault

                    _D003_NCR_J.SYOCHI_KEKKA_A = CBool(_V002_NCR_J.SYOCHI_KEKKA_A)
                    _D003_NCR_J.SYOCHI_KEKKA_B = CBool(_V002_NCR_J.SYOCHI_KEKKA_B)
                    _D003_NCR_J.SYOCHI_KEKKA_C = CBool(_V002_NCR_J.SYOCHI_KEKKA_C)
                    _D003_NCR_J.SYOCHI_D_UMU_KB = CBool(_V002_NCR_J.SYOCHI_D_UMU_KB)
                    _D003_NCR_J.SYOCHI_D_YOHI_KB = CBool(_V002_NCR_J.SYOCHI_E_YOHI_KB)
                    _D003_NCR_J.SYOCHI_D_SYOCHI_KIROKU = _V002_NCR_J.SYOCHI_D_SYOCHI_KIROKU
                    _D003_NCR_J.SYOCHI_E_UMU_KB = CBool(_V002_NCR_J.SYOCHI_D_UMU_KB)
                    _D003_NCR_J.SYOCHI_E_YOHI_KB = CBool(_V002_NCR_J.SYOCHI_E_YOHI_KB)
                    _D003_NCR_J.SYOCHI_E_SYOCHI_KIROKU = _V002_NCR_J.SYOCHI_E_SYOCHI_KIROKU

                    If _V003 IsNot Nothing Then
                        cmbST11_DestTANTO.SelectedValue = _V003.SYAIN_ID
                        txtST11_Comment.Text = _V003.COMMENT
                        If Not _V003.RIYU.IsNullOrWhiteSpace And intStageID = ENM_NCR_STAGE._110_abcde処置担当 Then lblST11_Modoshi_Riyu.Visible = True
                        lblST11_Modoshi_Riyu.Text = "差戻理由：" & _V003.RIYU
                    End If
                End If
            End If
#End Region
#Region "               120"
            If intStageID >= ENM_NCR_STAGE._120_abcde処置確認 Then

            End If
#End Region

            Return True
        Catch ex As Exception
            EM.ErrorSyori(ex, False, conblnNonMsg)
            Return False
        End Try
    End Function

#End Region

    Private Sub TabSTAGE_SelectedIndexChanged(sender As Object, e As EventArgs) 'Handles TabSTAGE.SelectedIndexChanged
        If TabSTAGE.SelectedTab.Enabled = False Then
            cmdFunc1.Enabled = False
        End If
    End Sub
#End Region

#End Region

#Region "入力チェック"
    Public Function FunCheckInput() As Boolean
        Try

            '-----共通
            Call CmbBUMON_Validating(cmbBUMON, Nothing)
            Call CmbKISYU_Validating(cmbKISYU, Nothing)
            Call CmbBUHIN_BANGO_Validating(cmbBUHIN_BANGO, Nothing)

            Call MtxGOUKI_Validating(mtxGOUKI, Nothing)
            Call CmbFUTEKIGO_STATUS_Validating(cmbFUTEKIGO_STATUS, Nothing)
            Call MtxFUTEKIGO_NAIYO_Validating(mtxHENKYAKU_RIYU, Nothing)
            Call CmbFUTEKIGO_KB_Validating(cmbFUTEKIGO_KB, Nothing)
            Call CmbFUTEKIGO_S_KB_Validating(cmbFUTEKIGO_S_KB, Nothing)
            Call MtxZUBAN_KIKAKU_Validating(mtxZUBAN_KIKAKU, Nothing)

            '-----ステージ別
            Select Case PrCurrentStage
                Case ENM_NCR_STAGE._10_起草入力
                    Call TxtST01_YOKYU_NAIYO_Validating(txtST01_YOKYU_NAIYO, Nothing)
                    Call TxtST01_KEKKA_Validating(txtST01_KEKKA, Nothing)
                    Call CmbDestTANTO_Validating(cmbST01_DestTANTO, Nothing)

                Case ENM_NCR_STAGE._20_起草確認製造GL
                    Call CmbDestTANTO_Validating(cmbST02_DestTANTO, Nothing)

                Case ENM_NCR_STAGE._30_起草確認検査
                    Call CmbDestTANTO_Validating(cmbST03_DestTANTO, Nothing)

                Case ENM_NCR_STAGE._40_事前審査判定及びCAR要否判定
                    Call CmbDestTANTO_Validating(cmbST04_DestTANTO, Nothing)

                Case ENM_NCR_STAGE._50_事前審査確認
                    Call CmbDestTANTO_Validating(cmbST05_DestTANTO, Nothing)

                Case ENM_NCR_STAGE._60_再審審査判定_技術代表, ENM_NCR_STAGE._61_再審審査判定_品証代表
                    Call CmbDestTANTO_Validating(cmbST06_DestTANTO, Nothing)

                Case ENM_NCR_STAGE._70_顧客再審処置_I_tag
                    Call CmbDestTANTO_Validating(cmbST07_DestTANTO, Nothing)

                Case ENM_NCR_STAGE._80_処置実施, ENM_NCR_STAGE._81_処置実施_生技, ENM_NCR_STAGE._82_処置実施_製造, ENM_NCR_STAGE._83_処置実施_検査
                    Call CmbDestTANTO_Validating(cmbST08_DestTANTO, Nothing)

                Case ENM_NCR_STAGE._90_処置実施確認_管理T
                    Call CmbDestTANTO_Validating(cmbST09_DestTANTO, Nothing)

                Case ENM_NCR_STAGE._100_処置実施決裁_製造課長
                    Call CmbDestTANTO_Validating(cmbST10_DestTANTO, Nothing)

                Case ENM_NCR_STAGE._110_abcde処置担当
                    Call CmbDestTANTO_Validating(cmbST11_DestTANTO, Nothing)

                Case ENM_NCR_STAGE._120_abcde処置確認

                Case Else
                    'Err
            End Select

            '上記各種Validatingイベントでフラグを更新し、全てOKの場合はTrue
            Return pri_blnValidated

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
                    '登録内容に応じて流動的に変化
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
                    If _D003_NCR_J.SAIKAKO_SIJI_FG Then
                        intNextStageID = ENM_NCR_STAGE._80_処置実施
                    Else
                        intNextStageID = ENM_NCR_STAGE._90_処置実施確認_管理T
                    End If

                Case ENM_NCR_STAGE._80_処置実施
                    If _D003_NCR_J.SAIKAKO_SIJI_FG Then
                        intNextStageID = ENM_NCR_STAGE._81_処置実施_生技
                    Else
                        intNextStageID = ENM_NCR_STAGE._90_処置実施確認_管理T
                    End If

                Case ENM_NCR_STAGE._81_処置実施_生技
                    intNextStageID = ENM_NCR_STAGE._82_処置実施_製造

                Case ENM_NCR_STAGE._82_処置実施_製造
                    intNextStageID = ENM_NCR_STAGE._83_処置実施_検査

                Case ENM_NCR_STAGE._83_処置実施_検査
                    intNextStageID = ENM_NCR_STAGE._90_処置実施確認_管理T

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
    Private Function FunConvertSYONIN_JUN_TO_STAGE_NO(ByVal intSYONIN_JUN As Integer) As Integer
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
            Case ENM_NCR_STAGE._60_再審審査判定_技術代表, ENM_NCR_STAGE._61_再審審査判定_品証代表
                intStageTabNo = 6
            Case ENM_NCR_STAGE._70_顧客再審処置_I_tag
                intStageTabNo = 7
            Case ENM_NCR_STAGE._80_処置実施, ENM_NCR_STAGE._81_処置実施_生技, ENM_NCR_STAGE._82_処置実施_製造, ENM_NCR_STAGE._83_処置実施_検査
                intStageTabNo = 8
            Case ENM_NCR_STAGE._90_処置実施確認_管理T
                intStageTabNo = 9
            Case ENM_NCR_STAGE._100_処置実施決裁_製造課長
                intStageTabNo = 10
            Case ENM_NCR_STAGE._110_abcde処置担当
                intStageTabNo = 11
            Case ENM_NCR_STAGE._120_abcde処置確認
                intStageTabNo = 12
            Case Else
                intStageTabNo = 15
        End Select

        Return intStageTabNo
    End Function

    ''' <summary>
    ''' タブNoから該当する承認順Noを取得
    ''' </summary>
    ''' <param name="intSYONIN_JUN">承認順No</param>
    ''' <returns></returns>
    Private Function FunConvertSTAGE_NO_TO_SYONIN_JUN(ByVal intTabNo As Integer) As Integer
        Dim intSTAGE_ID As Integer
        Select Case intTabNo
            Case 1
                intSTAGE_ID = ENM_NCR_STAGE._10_起草入力
            Case 2
                intSTAGE_ID = ENM_NCR_STAGE._20_起草確認製造GL
            Case 3
                intSTAGE_ID = ENM_NCR_STAGE._30_起草確認検査
            Case 4
                intSTAGE_ID = ENM_NCR_STAGE._40_事前審査判定及びCAR要否判定
            Case 5
                intSTAGE_ID = ENM_NCR_STAGE._50_事前審査確認
            Case 6
                intSTAGE_ID = ENM_NCR_STAGE._60_再審審査判定_技術代表
            Case 7
                intSTAGE_ID = ENM_NCR_STAGE._70_顧客再審処置_I_tag
            Case 8
                intSTAGE_ID = ENM_NCR_STAGE._80_処置実施
            Case 9
                intSTAGE_ID = ENM_NCR_STAGE._90_処置実施確認_管理T
            Case 10
                intSTAGE_ID = ENM_NCR_STAGE._100_処置実施決裁_製造課長
            Case 11
                intSTAGE_ID = ENM_NCR_STAGE._110_abcde処置担当
            Case 12
                intSTAGE_ID = ENM_NCR_STAGE._120_abcde処置確認
            Case Else
                intSTAGE_ID = 15
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
            sbSQL.Append("SELECT")
            sbSQL.Append(" *")
            sbSQL.Append(" FROM " & NameOf(MODEL.D003_NCR_J) & " ")
            sbSQL.Append(" WHERE BUHIN_BANGO='" & strBUHIN_BANGO & "'")
            sbSQL.Append(" AND FUTEKIGO_KB='" & strFUTEKIGO_KB & "'")
            sbSQL.Append(" AND FUTEKIGO_S_KB='" & strFUTEKIGO_S_KB & "'")
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
            sbSQL.Append("SELECT")
            sbSQL.Append(" HOKOKU_NO")
            sbSQL.Append(" FROM " & NameOf(MODEL.V003_SYONIN_J_KANRI) & " ")
            sbSQL.Append(" WHERE SYONIN_HOKOKUSYO_ID=" & ENM_SYONIN_HOKOKUSYO_ID._2_CAR & "")
            sbSQL.Append(" AND HOKOKU_NO='" & strHOKOKU_NO & "'")
            sbSQL.Append(" AND SYAIN_ID=" & intSYAIN_ID & "")
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
        sbSQL.Append("SELECT")
        sbSQL.Append(" HOKOKU_NO")
        sbSQL.Append(" FROM " & NameOf(MODEL.V003_SYONIN_J_KANRI) & " ")
        sbSQL.Append(" WHERE SYONIN_HOKOKUSYO_ID=" & intSYONIN_HOKOKUSYO_ID & "")
        sbSQL.Append(" AND HOKOKU_NO='" & strHOKOKU_NO & "'")
        sbSQL.Append(" AND SYONIN_JUN=" & intSYONIN_JUN & "")
        Using DB As ClsDbUtility = DBOpen()
            dsList = DB.GetDataSet(sbSQL.ToString, conblnNonMsg)
        End Using

        Return dsList.Tables(0).Rows.Count > 0
    End Function

#End Region

End Class