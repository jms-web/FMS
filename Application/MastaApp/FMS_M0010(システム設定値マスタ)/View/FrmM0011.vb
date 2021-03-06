Imports JMS_COMMON.ClsPubMethod

''' <summary>
''' コードマスタ編集画面
''' </summary>
Public Class FrmM0011

#Region "変数・定数"

    Private _M001 As New MODEL.M001_SETTING

#End Region

#Region "プロパティ"

    ''' <summary>
    ''' 処理モード
    ''' </summary>
    Public Property PrDATA_OP_MODE As Integer

    ''' <summary>
    ''' 新規追加レコードのキー
    ''' </summary>
    Public Property PrPKeys As (ITEM_NAME As String, ITEM_VALUE As String)

    'Public Property PrDataRow As DataRow

    Public Property PrViewModel As MODEL.VWM001_SETTING

#End Region

#Region "コンストラクタ"

    ''' <summary>
    ''' コンストラクタ
    ''' </summary>
    ''' <remarks>コンストラクタ</remarks>
    Public Sub New()

        ' この呼び出しはデザイナーで必要です。
        InitializeComponent()

        Me.Height = 380
        Me.FormBorderStyle = Windows.Forms.FormBorderStyle.FixedDialog
        Me.MaximizeBox = False
        Me.MinimizeBox = False

        cmbJYUN.NullValue = 0
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
            cmbKOMO_NM.SetDataSource(tblKOMO_NM.ExcludeDeleted, ENM_COMBO_SELECT_VALUE_TYPE._0_Required)

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

#Region "FUNCTIONボタン関連"

#Region "FUNCTIONボタンCLICKイベント"

    Private Sub CmdFunc_Click(ByVal sender As Object, ByVal e As EventArgs) Handles cmdFunc9.Click, cmdFunc8.Click, cmdFunc7.Click, cmdFunc6.Click, cmdFunc5.Click, cmdFunc4.Click, cmdFunc3.Click, cmdFunc2.Click, cmdFunc12.Click, cmdFunc11.Click, cmdFunc10.Click, cmdFunc1.Click
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
                Case 1  '追加変更
                    If FunSAVE() Then
                        'プロパティに対象レコードのキーを設定
                        Me.PrPKeys = (cmbKOMO_NM.Text.Trim, mtxVALUE.Text.Trim)

                        Me.DialogResult = Windows.Forms.DialogResult.OK
                        Me.Close()
                    End If

                Case 12 '戻る
                    Me.DialogResult = Windows.Forms.DialogResult.Cancel
                    Me.Close()
            End Select
        Catch exDispose As ObjectDisposedException
            System.Console.WriteLine(exDispose.Message)
        Catch ex As Exception
            EM.ErrorSyori(ex)
        Finally
            'ボタン可
            System.Windows.Forms.Application.DoEvents()
            For intCNT = 0 To Me.cmdFunc.Length - 1
                Me.cmdFunc(intCNT).Enabled = True
            Next

            If intFUNC <> 12 Then Call FunInitFuncButtonEnabled()
        End Try
    End Sub

#End Region

#Region "更新"

    Private Function FunSAVE() As Boolean
        Dim sbSQL As New System.Text.StringBuilder
        Dim strRET As String
        Dim sqlEx As New Exception
        Dim strSysDate As String
        Try

            '入力チェック
            If FunCheckInput() = False Then Return False

            Using DB As ClsDbUtility = DBOpen()
                Dim blnErr As Boolean
                Try
                    DB.BeginTransaction()

                    strSysDate = DB.GetSysDateString()

                    Dim ModelInfo As New MODEL.ModelInfo(Of MODEL.M001_SETTING)(_OnlyAutoGenerateField:=True)

                    '-----同一項目名の既定値を解除
                    If _M001.DEF_FLG Then
                        sbSQL.Append($"UPDATE {ModelInfo.Name} SET")
                        sbSQL.Append($" DEF_FLG='0' ")
                        sbSQL.Append($" WHERE ITEM_NAME ='{_M001.ITEM_NAME}' ")
                        sbSQL.Append($" AND ITEM_VALUE <>'{_M001.ITEM_VALUE}' ")

                        DB.ExecuteNonQuery(sbSQL.ToString, conblnNonMsg, sqlEx)
                        If sqlEx IsNot Nothing Then
                            'エラーログ
                            Dim strErrMsg As String = My.Resources.ErrLogSqlExecutionFailure & sbSQL.ToString & "|" & sqlEx.Message
                            WL.WriteLogDat(strErrMsg)
                            blnErr = True
                            Return False
                        End If
                    End If

                    '-----UPDATE(表示順)
                    If PrViewModel.DISP_ORDER <> _M001.DISP_ORDER Then
                        If FunUpdateDispOrder(DB, PrViewModel.DISP_ORDER, _M001.DISP_ORDER) = False Then
                            blnErr = True
                            Return False
                        End If
                    End If

                    '-----MERGE
                    sbSQL.Remove(0, sbSQL.Length)
                    sbSQL.Append($"MERGE INTO {ModelInfo.Name} AS TARGET")
                    sbSQL.Append($" USING (SELECT")

                    sbSQL.Append($" '{_M001.ITEM_NAME.Trim}' AS {NameOf(_M001.ITEM_NAME)}")
                    sbSQL.Append($",'{_M001.ITEM_VALUE.Trim}' AS {NameOf(_M001.ITEM_VALUE)}")
                    sbSQL.Append($",'{_M001.ITEM_GROUP.Trim}' AS {NameOf(_M001.ITEM_GROUP)}")
                    sbSQL.Append($",'{_M001.ITEM_DISP.Trim}' AS {NameOf(_M001.ITEM_DISP)}")
                    sbSQL.Append($",'{_M001.DEF_FLG}' AS {NameOf(_M001.DEF_FLG)}")
                    sbSQL.Append($",{_M001.DISP_ORDER} AS {NameOf(_M001.DISP_ORDER)}")
                    sbSQL.Append($",'{_M001.BIKOU}' AS {NameOf(_M001.BIKOU)}")
                    sbSQL.Append($",'{_M001.ADD_YMDHNS.Replace("/", "").Replace(":", "").Replace(" ", "")}' AS {NameOf(_M001.ADD_YMDHNS)}")
                    sbSQL.Append($",{_M001.ADD_SYAIN_ID} AS {NameOf(_M001.ADD_SYAIN_ID)}")
                    sbSQL.Append($",'{_M001.UPD_YMDHNS.Replace("/", "").Replace(":", "").Replace(" ", "")}' AS {NameOf(_M001.UPD_YMDHNS)}")
                    sbSQL.Append($",{_M001.UPD_SYAIN_ID} AS {NameOf(_M001.UPD_SYAIN_ID)}")
                    sbSQL.Append($",'{_M001.DEL_YMDHNS.Replace("/", "").Replace(":", "").Replace(" ", "")}' AS {NameOf(_M001.DEL_YMDHNS)}")
                    sbSQL.Append($",{_M001.DEL_SYAIN_ID} AS {NameOf(_M001.DEL_SYAIN_ID)}")

                    sbSQL.Append($" ) AS WK ON (")
                    sbSQL.Append($" TARGET.{NameOf(_M001.ITEM_NAME)} = WK.{NameOf(_M001.ITEM_NAME)}")
                    sbSQL.Append($" AND TARGET.{NameOf(_M001.ITEM_VALUE)} = WK.{NameOf(_M001.ITEM_VALUE)}")
                    sbSQL.Append($" )")

                    '---UPDATE 排他制御 更新日時が変更されていない場合のみ
                    sbSQL.Append($" WHEN MATCHED AND TARGET.{NameOf(_M001.UPD_YMDHNS)} = WK.{NameOf(_M001.UPD_YMDHNS)} THEN ")
                    sbSQL.Append($" UPDATE SET")
                    sbSQL.Append($" TARGET.{NameOf(_M001.ITEM_DISP)} = WK.{NameOf(_M001.ITEM_DISP)}")
                    sbSQL.Append($",TARGET.{NameOf(_M001.ITEM_GROUP)} = WK.{NameOf(_M001.ITEM_GROUP)}")
                    sbSQL.Append($",TARGET.{NameOf(_M001.DEF_FLG)} = WK.{NameOf(_M001.DEF_FLG)}")
                    sbSQL.Append($",TARGET.{NameOf(_M001.BIKOU)} = WK.{NameOf(_M001.BIKOU)}")
                    sbSQL.Append($",TARGET.{NameOf(_M001.UPD_YMDHNS)} = '{strSysDate}'")
                    sbSQL.Append($",TARGET.{NameOf(_M001.UPD_SYAIN_ID)} = WK.{NameOf(_M001.UPD_SYAIN_ID)}")

                    '---INSERT
                    sbSQL.Append($" WHEN NOT MATCHED THEN ")
                    sbSQL.Append($" INSERT(")
                    ModelInfo.Properties.Take(1).ForEach(Sub(p) sbSQL.Append($" {p.Name}"))
                    ModelInfo.Properties.Skip(1).ForEach(Sub(p) sbSQL.Append($",{p.Name}"))
                    sbSQL.Append($" ) VALUES(")
                    ModelInfo.Properties.Take(1).ForEach(Sub(p) sbSQL.Append($" WK.{p.Name}"))
                    ModelInfo.Properties.Skip(1).ForEach(Sub(p) sbSQL.Append($",WK.{p.Name}"))
                    sbSQL.Append(" )")
                    sbSQL.Append("OUTPUT $action As RESULT;")

                    strRET = DB.ExecuteScalar(sbSQL.ToString, conblnNonMsg, sqlEx)
                    Select Case strRET
                        Case "INSERT"

                        Case "UPDATE"

                            Select Case PrDATA_OP_MODE
                                Case ENM_DATA_OPERATION_MODE._1_ADD, ENM_DATA_OPERATION_MODE._2_ADDREF
                                    '新規追加・類似追加でUPDATEは無効
                                    Dim strMsg As String = $"({_M001.ITEM_NAME},{_M001.ITEM_VALUE})は既に登録されています。{vbCrLf}現在の登録内容で上書きしますか？"

                                    If MessageBox.Show(strMsg, "重複チェック", MessageBoxButtons.YesNo, MessageBoxIcon.Information) = DialogResult.Yes Then
                                    Else
                                        blnErr = True
                                        Return False
                                    End If
                            End Select
                        Case Else
                            If sqlEx.Source IsNot Nothing Then
                                '-----エラーログ出力
                                Dim strErrMsg As String = $"{My.Resources.ErrLogSqlExecutionFailure}{sbSQL.ToString}|{sqlEx.Message}"
                                WL.WriteLogDat(strErrMsg)
                            Else
                                '---排他制御
                                Dim strMsg As String = $"既に他の担当者によって変更されているため保存出来ません。{vbCrLf}再度登録し直して下さい。"
                                MessageBox.Show(strMsg, "同時更新無効", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                            End If
                            blnErr = True
                            Return False
                    End Select
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
    ''' <returns></returns>
    ''' <remarks></remarks>
    Private Function FunInitFuncButtonEnabled() As Boolean
        Try

            For intCNT = 0 To Me.cmdFunc.Length - 1
                If Me.cmdFunc(intCNT) IsNot Nothing AndAlso Me.cmdFunc(intCNT).Text.Length = 0 OrElse Me.cmdFunc(intCNT).Text.Substring(0, Me.cmdFunc(intCNT).Text.IndexOf("(")).IsNulOrWS = True Then
                    Me.cmdFunc(intCNT).Text = ""
                    Me.cmdFunc(intCNT).Visible = False
                End If
            Next

            Return True
        Catch ex As Exception
            EM.ErrorSyori(ex, False, conblnNonMsg)
            Return False
        End Try
    End Function

#End Region

#End Region

#Region "コントロールイベント"

    Private Sub CmbKOMO_NM_Validated(sender As Object, e As EventArgs) Handles cmbKOMO_NM.Validated
        Dim dsList As New DataSet
        Dim sbSQL As New System.Text.StringBuilder
        Dim intMaxOrder As Integer

        Try

            If Not cmbKOMO_NM.Text.IsNulOrWS Then

                Using DB As ClsDbUtility = DBOpen()
                    sbSQL.Append("SELECT ITEM_VALUE")
                    sbSQL.Append(" FROM " & NameOf(MODEL.M001_SETTING) & "")
                    sbSQL.Append(" WHERE ITEM_NAME ='" & cmbKOMO_NM.Text & "'")
                    dsList = DB.GetDataSet(sbSQL.ToString, conblnNonMsg)
                End Using

                intMaxOrder = dsList.Tables(0).Rows.Count

                Dim intModeDiff As Integer
                Select Case PrDATA_OP_MODE
                    Case ENM_DATA_OPERATION_MODE._1_ADD, ENM_DATA_OPERATION_MODE._2_ADDREF
                        intModeDiff = 1
                    Case ENM_DATA_OPERATION_MODE._3_UPDATE
                        intModeDiff = 0
                    Case Else
                        Throw New ArgumentException(My.Resources.ErrMsgException, PrDATA_OP_MODE.ToString)
                End Select

                Dim dt As New DataTableEx("System.Int32")
                For i As Integer = 1 To intMaxOrder + intModeDiff
                    Dim Trow As DataRow = dt.NewRow()
                    Trow("DISP") = i
                    Trow("VALUE") = i
                    Trow("DEL_FLG") = False
                    dt.Rows.Add(Trow)
                Next i
                dt.AcceptChanges()

                Call cmbJYUN.SetDataSource(dt, ENM_COMBO_SELECT_VALUE_TYPE._2_Option)

                Select Case PrDATA_OP_MODE
                    Case ENM_DATA_OPERATION_MODE._1_ADD, ENM_DATA_OPERATION_MODE._2_ADDREF
                        cmbJYUN.SelectedValue = intMaxOrder + intModeDiff
                    Case ENM_DATA_OPERATION_MODE._3_UPDATE
                        cmbJYUN.SelectedValue = PrViewModel.DISP_ORDER
                    Case Else
                        Throw New ArgumentException(My.Resources.ErrMsgException, PrDATA_OP_MODE.ToString)
                End Select
            End If
        Catch ex As Exception
            EM.ErrorSyori(ex, False, conblnNonMsg)
        Finally
            dsList.Dispose()
        End Try
    End Sub

#End Region

#Region "ローカル関数"

#Region "バインディング"

    Private Function FunSetBinding() As Boolean
        cmbKOMO_NM.DataBindings.Add(New Binding(NameOf(cmbKOMO_NM.SelectedValue), _M001, NameOf(_M001.ITEM_NAME), False, DataSourceUpdateMode.OnPropertyChanged, ""))
        mtxVALUE.DataBindings.Add(New Binding(NameOf(mtxVALUE.Text), _M001, NameOf(_M001.ITEM_VALUE), False, DataSourceUpdateMode.OnPropertyChanged, ""))
        mtxKOMO_GROUP.DataBindings.Add(New Binding(NameOf(mtxKOMO_GROUP.Text), _M001, NameOf(_M001.ITEM_GROUP), False, DataSourceUpdateMode.OnPropertyChanged, ""))
        mtxDISP.DataBindings.Add(New Binding(NameOf(mtxDISP.Text), _M001, NameOf(_M001.ITEM_DISP), False, DataSourceUpdateMode.OnPropertyChanged, ""))
        cmbJYUN.DataBindings.Add(New Binding(NameOf(cmbJYUN.SelectedValue), _M001, NameOf(_M001.DISP_ORDER), False, DataSourceUpdateMode.OnPropertyChanged, 0))
        mtxBIKOU.DataBindings.Add(New Binding(NameOf(mtxBIKOU.Text), _M001, NameOf(_M001.BIKOU), False, DataSourceUpdateMode.OnPropertyChanged, ""))
        chkDefaultVaue.DataBindings.Add(New Binding(NameOf(chkDefaultVaue.Checked), _M001, NameOf(_M001.DEF_FLG_), False, DataSourceUpdateMode.OnPropertyChanged, False))

    End Function

#End Region

#Region "処理モード別画面初期化"

    Private Function FunInitializeControls() As Boolean
        Try
            Select Case PrDATA_OP_MODE
                Case ENM_DATA_OPERATION_MODE._1_ADD
                    lblTytle.Text &= "（追加）"
                    cmdFunc1.Text = "追加(F1)"

                    cmbKOMO_NM.ReadOnly = False
                    mtxVALUE.ReadOnly = False
                    mtxDISP.ReadOnly = False

                    lbllblEDIT_YMDHNS.Visible = False
                    lblEDIT_YMDHNS.Visible = False
                    lbllblEDIT_SYAIN_ID.Visible = False
                    lblEDIT_SYAIN_ID.Visible = False

                Case ENM_DATA_OPERATION_MODE._2_ADDREF

                    lblTytle.Text &= "（類似追加）"
                    cmdFunc1.Text = "追加(F1)"

                    cmbKOMO_NM.ReadOnly = False
                    mtxVALUE.ReadOnly = False
                    mtxDISP.ReadOnly = False

                    '一覧選択行のデータをモデルに読込
                    _M001.Properties.ForEach(Sub(p) _M001(p.Name) = PrViewModel(p.Name))

                    Call CmbKOMO_NM_Validated(cmbKOMO_NM, Nothing)
                    lbllblEDIT_YMDHNS.Visible = False
                    lblEDIT_YMDHNS.Visible = False
                    lbllblEDIT_SYAIN_ID.Visible = False
                    lblEDIT_SYAIN_ID.Visible = False

                Case ENM_DATA_OPERATION_MODE._3_UPDATE
                    lblTytle.Text &= "（変更）"
                    cmdFunc1.Text = "変更(F1)"

                    cmbKOMO_NM.ReadOnly = True
                    mtxVALUE.ReadOnly = True
                    mtxDISP.ReadOnly = False

                    '一覧選択行のデータをモデルに読込
                    _M001.Properties.ForEach(Sub(p) _M001(p.Name) = PrViewModel(p.Name))
                    Call CmbKOMO_NM_Validated(cmbKOMO_NM, Nothing)
                    lbllblEDIT_YMDHNS.Visible = True
                    lblEDIT_YMDHNS.Visible = True
                    lbllblEDIT_SYAIN_ID.Visible = True
                    lblEDIT_SYAIN_ID.Visible = True
                    '更新日時
                    lblEDIT_YMDHNS.Text = PrViewModel.UPD_YMDHNS.ToString 'DateTime.ParseExact(PrViewModel.UPD_YMDHNS, "yyyyMMddHHmmss", Nothing).ToString("yyyy/MM/dd HH:mm:ss")
                    '更新担当者CD
                    lblEDIT_SYAIN_ID.Text = PrViewModel.UPD_SYAIN_ID & " " & Fun_GetUSER_NAME(_M001.UPD_SYAIN_ID)

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

    Private Function FunCheckInput() As Boolean
        Try
            'フラグ初期化
            IsValidated = True
            IsCheckRequired = True

            Call CmbKOMO_NM_Validating(cmbKOMO_NM, Nothing)
            Call MtxVALUE_Validating(mtxVALUE, Nothing)

            Return IsValidated
        Catch ex As Exception
            Throw
        Finally
            IsCheckRequired = False
        End Try
    End Function

    Private Sub CmbKOMO_NM_Validating(sender As Object, e As System.ComponentModel.CancelEventArgs) Handles cmbKOMO_NM.Validating
        Dim cmb As ComboboxEx = DirectCast(sender, ComboboxEx)
        If IsCheckRequired Then
            IsValidated *= ErrorProvider.UpdateErrorInfo(cmb, cmb.IsSelected, String.Format(My.Resources.infoMsgRequireSelectOrInput, "項目名"))
        End If
    End Sub

    Private Sub MtxVALUE_Validating(sender As Object, e As System.ComponentModel.CancelEventArgs) Handles mtxVALUE.Validating
        Dim mtx As MaskedTextBoxEx = DirectCast(sender, MaskedTextBoxEx)
        If IsCheckRequired Then
            IsValidated *= ErrorProvider.UpdateErrorInfo(mtx, Not mtx.Text.IsNulOrWS, String.Format(My.Resources.infoMsgRequireSelectOrInput, "項目値"))
        End If
    End Sub

#End Region

#Region "表示順更新"

    Private Function FunUpdateDispOrder(ByRef DB As ClsDbUtility, ByVal intBeforeValue As Integer, ByVal intAfterValue As Integer) As Boolean
        Dim sbSQL As New System.Text.StringBuilder
        Dim sqlEx As New Exception

        Try

            '同一項目名内に同じ表示順が存在する場合、intTergetJyun以降の表示順を全て更新する
            If intBeforeValue < intAfterValue Then
                sbSQL.Append($"UPDATE {NameOf(MODEL.M001_SETTING)} SET")
                sbSQL.Append($" DISP_ORDER = DISP_ORDER-1 ")
                sbSQL.Append($"WHERE")
                sbSQL.Append($" ITEM_NAME ='{_M001.ITEM_NAME}' ")
                sbSQL.Append($" AND {NameOf(MODEL.M001_SETTING.ITEM_VALUE)} <> '{_M001.ITEM_VALUE}' ")
                sbSQL.Append($" AND DISP_ORDER >{intBeforeValue} ")
                sbSQL.Append($" AND DISP_ORDER <={intAfterValue} ")
            Else
                '元の表示順より小さくした場合、他の項目を1つ後ろにずらす
                sbSQL.Append($"UPDATE {NameOf(MODEL.M001_SETTING)} SET")
                sbSQL.Append($" DISP_ORDER = DISP_ORDER+1 ")
                sbSQL.Append($"WHERE")
                sbSQL.Append($" ITEM_NAME ='{_M001.ITEM_NAME}' ")
                sbSQL.Append($" AND {NameOf(MODEL.M001_SETTING.ITEM_VALUE)} <> '{_M001.ITEM_VALUE}' ")
                sbSQL.Append($" AND DISP_ORDER >={intAfterValue} ")
                sbSQL.Append($" AND DISP_ORDER <{intBeforeValue} ")
            End If

            DB.ExecuteNonQuery(sbSQL.ToString, conblnNonMsg, sqlEx)
            If sqlEx.Source IsNot Nothing Then
                'エラーログ
                Dim strErrMsg As String = My.Resources.ErrLogSqlExecutionFailure & sbSQL.ToString & "|" & sqlEx.Message
                WL.WriteLogDat(strErrMsg)
                Return False
            End If

            '変更対象の更新
            sbSQL.Remove(0, sbSQL.Length)
            sbSQL.Append($"UPDATE {NameOf(MODEL.M001_SETTING)} SET")
            sbSQL.Append($" DISP_ORDER ='{intAfterValue}' ")
            sbSQL.Append($"WHERE")
            sbSQL.Append($" ITEM_NAME ='{_M001.ITEM_NAME}' ")
            sbSQL.Append($" AND ITEM_VALUE ='{_M001.ITEM_VALUE}' ")
            sbSQL.Append($" AND DISP_ORDER ={intBeforeValue}")

            DB.ExecuteNonQuery(sbSQL.ToString, conblnNonMsg, sqlEx)
            If sqlEx.Source IsNot Nothing Then
                'エラーログ
                Dim strErrMsg As String = My.Resources.ErrLogSqlExecutionFailure & sbSQL.ToString & "|" & sqlEx.Message
                WL.WriteLogDat(strErrMsg)
                Return False
            End If

            Return True
        Catch ex As Exception
            Throw
            Return False
        End Try
    End Function

#End Region

#End Region

End Class