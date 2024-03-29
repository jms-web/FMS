Imports JMS_COMMON.ClsPubMethod

Public Class FrmM0031

#Region "変数・定数"

    Private _M003 As MODEL.M003_GYOMU_GROUP

#End Region

#Region "プロパティ"

    ''' <summary>
    ''' 処理モード
    ''' </summary>
    Public Property PrMODE As Integer

    ''' <summary>
    ''' 新規追加レコードのキー
    ''' </summary>
    Public Property PrPKeys As (ITEM_NAME As String, ITEM_VALUE As String)

    Public Property PrDataRow As C1.Win.C1FlexGrid.Row
    'Public Property PrDataRow As DataRow

#End Region

#Region "コンストラクタ"

    Public Sub New()

        ' この呼び出しはデザイナーで必要です。
        InitializeComponent()

    End Sub

#End Region

#Region "FORMイベント"

    Private Sub Frm_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        Try
            '-----フォーム共通設定
            Call FunFormCommonSetting(pub_APP_INFO, pub_SYAIN_INFO)

            '-----位置・サイズ
            Me.Height = 250
            Me.MinimumSize = New Size(1280, 250)
            Me.Top = Me.Owner.Top + (Me.Owner.Height - Me.Height) - 30 ' / 2
            Me.Left = Me.Owner.Left + (Me.Owner.Width - Me.Width) / 2

            '-----各コントロールのデータソースを設定
            'Me.cmbBUSYO_KB.SetDataSource(tblBUSYO_KB.ExcludeDeleted, ENM_COMBO_SELECT_VALUE_TYPE._0_Required)
            'Me.cmbBUMON_KB.SetDataSource(tblBUMON.ExcludeDeleted, ENM_COMBO_SELECT_VALUE_TYPE._0_Required)
            'Me.cmbOYA_BUSYO_KB.SetDataSource(tblBUSYO_KB.ExcludeDeleted, ENM_COMBO_SELECT_VALUE_TYPE._2_Option)
            'Me.cmbSYOZOKUCYO.SetDataSource(tblSYAIN.ExcludeDeleted, ENM_COMBO_SELECT_VALUE_TYPE._2_Option)

            'イベントハンドラ設定
            'AddHandler cmbOYA_BUSYO_KB.TextChanged, AddressOf CmbOYA_BUSYO_KB_TextChanged
            'AddHandler chkYUKO_YMD.CheckedChanged, AddressOf chkYUKO_YMD_CheckedChanged

            '-----処理モード別画面初期化
            Call FunInitializeControls(PrMODE)

            '-----ダイアログウィンドウ設定
            Me.FormBorderStyle = Windows.Forms.FormBorderStyle.FixedDialog
            Me.ControlBox = False
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
        Dim blnRET As Boolean
        Try
            'ボタン不可/ボタンINDEX取得
            For intCNT = 0 To Me.cmdFunc.Length - 1
                Me.cmdFunc(intCNT).Enabled = False
                If cmdFunc(intCNT) Is sender Then intFUNC = intCNT + 1
            Next

            'ボタンINDEX毎の処理
            Select Case intFUNC
                Case 1  '追加変更
                    Select Case PrMODE
                        Case ENM_DATA_OPERATION_MODE._1_ADD, ENM_DATA_OPERATION_MODE._2_ADDREF
                            blnRET = FunINS()
                        Case ENM_DATA_OPERATION_MODE._3_UPDATE
                            blnRET = FunUPD()
                        Case Else
                            Throw New ArgumentException(My.Resources.ErrMsgException, PrMODE.ToString)
                    End Select

                    If blnRET = True Then
                        'プロパティに対象レコードのキーを設定
                        'Me.PrPKeys = Me.mtxTANTO_CD.Text.Trim
                        Me.DialogResult = Windows.Forms.DialogResult.OK
                        Me.Close()
                    End If

                    'If FunSAVE() Then
                    '    'プロパティに対象レコードのキーを設定
                    '    'Me.PrPKeys = (cmbKOMO_NM.Text.Trim, mtxVALUE.Text.Trim)

                    '    Me.DialogResult = Windows.Forms.DialogResult.OK
                    '    Me.Close()
                    'End If

                Case 12 '戻る
                    Me.DialogResult = Windows.Forms.DialogResult.Cancel
                    Me.Close()
            End Select
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

#Region "追加"

    Private Function FunINS() As Boolean

        Dim dsList As New System.Data.DataSet
        Dim sbSQL As New System.Text.StringBuilder
        Try
            '-----入力チェック
            If FunCheckInput() = False Then
                Return False
            End If

            Using DB As ClsDbUtility = DBOpen()
                Dim intRET As Integer
                Dim sqlEx As New Exception
                Dim blnErr As Boolean
                Try
                    'トランザクション
                    DB.BeginTransaction()

                    '-----INSERT
                    sbSQL.Remove(0, sbSQL.Length)
                    sbSQL.Append("INSERT INTO M003_GYOMU_GROUP(")
                    sbSQL.Append("  GYOMU_GROUP_ID ")
                    sbSQL.Append(" ,GYOMU_GROUP_NAME ")
                    sbSQL.Append(" ,ADD_YMDHNS")
                    sbSQL.Append(" ,ADD_SYAIN_ID")
                    sbSQL.Append(" ,UPD_YMDHNS")
                    sbSQL.Append(" ,UPD_SYAIN_ID")
                    sbSQL.Append(" ,DEL_YMDHNS")
                    sbSQL.Append(" ,DEL_SYAIN_ID")
                    sbSQL.Append(" ) VALUES ( ")
                    '業務グループID
                    If Me.mtxGYOMU_GROUP_ID.Text.IsNulOrWS Then
                        sbSQL.Append(" (SELECT MAX(GYOMU_GROUP_ID)+1 FROM M003_GYOMU_GROUP)")
                    Else
                        sbSQL.Append($"{Me.mtxGYOMU_GROUP_ID.Text.ToVal}")
                    End If
                    '業務グループ名
                    sbSQL.Append(" ,'" & Me.mtxBUSYO_NAME.Text.Trim & "'")
                    '追加日時
                    sbSQL.Append(" ,dbo.GetSysDateString()")
                    '追加担当者
                    sbSQL.Append(" ," & pub_SYAIN_INFO.SYAIN_ID & "")
                    '更新日時
                    sbSQL.Append(" ,dbo.GetSysDateString()")
                    '更新担当者
                    sbSQL.Append(" ," & pub_SYAIN_INFO.SYAIN_ID & "")
                    '削除日時
                    sbSQL.Append(" ,''")
                    '削除担当者
                    sbSQL.Append(" ,0")
                    sbSQL.Append(" )")

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

            Return True
        Catch ex As Exception
            Throw
            Return False
        Finally
            dsList.Dispose()
        End Try
    End Function

#End Region

#Region "更新"

    Private Function FunUPD() As Boolean

        Dim sbSQL As New System.Text.StringBuilder
        Dim dsList As New DataSet
        Dim intRET As Integer
        Dim sqlEx As Exception = Nothing
        Dim blnErr As Boolean
        Try
            '入力チェック
            If FunCheckInput() = False Then
                Return False
            End If

            Using DB As ClsDbUtility = DBOpen()
                Try
                    'トランザクション
                    DB.BeginTransaction()
                    '-----存在チェック
                    sbSQL.Append("SELECT * FROM M003_GYOMU_GROUP ")
                    sbSQL.Append(" WHERE")
                    sbSQL.Append(" GYOMU_GROUP_ID =" & Nz(Me.mtxGYOMU_GROUP_ID.Text.Trim & ""))

                    dsList = DB.GetDataSet(sbSQL.ToString)
                    If dsList.Tables(0).Rows.Count = 0 Then '非存在時
                        MessageBox.Show(String.Format(My.Resources.infoSearchDataChange), My.Resources.infoTilteDuplicateCheck, MessageBoxButtons.OK, MessageBoxIcon.Information)
                        Return False
                    End If

                    '-----UPDATE
                    sbSQL.Remove(0, sbSQL.Length)
                    sbSQL.Append("UPDATE M003_GYOMU_GROUP SET")
                    sbSQL.Append("  GYOMU_GROUP_NAME ='" & Me.mtxBUSYO_NAME.Text.Trim & "'")
                    sbSQL.Append(" ,UPD_YMDHNS   = dbo.GetSysDateString() ")
                    sbSQL.Append(" ,UPD_SYAIN_ID = " & pub_SYAIN_INFO.SYAIN_ID & " ")
                    sbSQL.Append(" WHERE")
                    sbSQL.Append(" GYOMU_GROUP_ID =" & Nz(Me.mtxGYOMU_GROUP_ID.Text.Trim, " "))

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

    '#Region "更新"

    '    Private Function FunSAVE() As Boolean
    '        Dim sbSQL As New System.Text.StringBuilder
    '        Dim strRET As String
    '        Dim sqlEx As New Exception
    '        Dim strSysDate As String
    '        Try

    '            '入力チェック
    '            If FunCheckInput() = False Then Return False

    '            Using DB As ClsDbUtility = DBOpen()
    '                Dim blnErr As Boolean
    '                Try
    '                    DB.BeginTransaction()

    '                    strSysDate = DB.GetSysDateString()

    '                    '-----MERGE
    '                    sbSQL.Remove(0, sbSQL.Length)
    '                    sbSQL.Append($"MERGE INTO {NameOf(MODEL.M003_GYOMU_GROUP)} AS TARGET")
    '                    sbSQL.Append($" USING (SELECT")

    '                    If PrMODE = ENM_DATA_OPERATION_MODE._1_ADD Or PrMODE = ENM_DATA_OPERATION_MODE._2_ADDREF Then
    '                        sbSQL.Append($"  (SELECT GYOMU_GROUP_ID + 1 FROM {NameOf(MODEL.M003_GYOMU_GROUP)} ) AS {NameOf(_M003.GYOMU_GROUP_ID)}")
    '                    Else
    '                        sbSQL.Append($"  {_M003.GYOMU_GROUP_ID} AS {NameOf(_M003.GYOMU_GROUP_ID)}")
    '                    End If

    '                    sbSQL.Append($",'{_M003.GYOMU_GROUP_NAME}' AS {NameOf(_M003.GYOMU_GROUP_NAME)}")
    '                    sbSQL.Append($",'{_M003.ADD_YMDHNS}' AS {NameOf(_M003.ADD_YMDHNS)}")
    '                    sbSQL.Append($",{_M003.ADD_SYAIN_ID} AS {NameOf(_M003.ADD_SYAIN_ID)}")
    '                    sbSQL.Append($",'{_M003.UPD_YMDHNS}' AS {NameOf(_M003.UPD_YMDHNS)}")
    '                    sbSQL.Append($",{_M003.UPD_SYAIN_ID} AS {NameOf(_M003.UPD_SYAIN_ID)}")
    '                    sbSQL.Append($",'{_M003.DEL_YMDHNS}' AS {NameOf(_M003.DEL_YMDHNS)}")
    '                    sbSQL.Append($",{_M003.DEL_SYAIN_ID} AS {NameOf(_M003.DEL_SYAIN_ID)}")

    '                    sbSQL.Append($" ) AS WK ON (")
    '                    sbSQL.Append($" TARGET.{NameOf(_M003.GYOMU_GROUP_ID)} = WK.{NameOf(_M003.GYOMU_GROUP_ID)}")
    '                    sbSQL.Append($" )")

    '                    '---UPDATE 排他制御 更新日時が変更されていない場合のみ
    '                    sbSQL.Append($" WHEN MATCHED AND TARGET.{NameOf(_M003.UPD_YMDHNS)} = WK.{NameOf(_M003.UPD_YMDHNS)} THEN ")
    '                    sbSQL.Append($" UPDATE SET")
    '                    sbSQL.Append($" TARGET.{NameOf(_M003.GYOMU_GROUP_NAME)} = WK.{NameOf(_M003.GYOMU_GROUP_NAME)}")
    '                    sbSQL.Append($",TARGET.{NameOf(_M003.UPD_YMDHNS)} = '{strSysDate}'")
    '                    sbSQL.Append($",TARGET.{NameOf(_M003.UPD_SYAIN_ID)} = WK.{NameOf(_M003.UPD_SYAIN_ID)}")

    '                    '---INSERT
    '                    sbSQL.Append($" WHEN NOT MATCHED THEN ")
    '                    sbSQL.Append($" INSERT(")
    '                    _M003.Properties.Take(1).ForEach(Sub(p) sbSQL.Append($" {p.Name}"))
    '                    _M003.Properties.Skip(1).ForEach(Sub(p) sbSQL.Append($",{p.Name}"))
    '                    sbSQL.Append($" ) VALUES(")
    '                    _M003.Properties.Take(1).ForEach(Sub(p) sbSQL.Append($" WK.{p.Name}"))
    '                    _M003.Properties.Skip(1).ForEach(Sub(p) sbSQL.Append($",WK.{p.Name}"))
    '                    sbSQL.Append(" )")
    '                    sbSQL.Append("OUTPUT $action As RESULT;")

    '                    strRET = DB.ExecuteScalar(sbSQL.ToString, conblnNonMsg, sqlEx)
    '                    Select Case strRET
    '                        Case "INSERT"

    '                        Case "UPDATE"

    '                            Select Case PrMODE
    '                                Case ENM_DATA_OPERATION_MODE._1_ADD, ENM_DATA_OPERATION_MODE._2_ADDREF
    '                                    '新規追加・類似追加でUPDATEは無効
    '                                    Dim strMsg As String = $"({_M003.GYOMU_GROUP_NAME})は既に登録されています。"

    '                                    'If MessageBox.Show(strMsg, "重複チェック", MessageBoxButtons.YesNo, MessageBoxIcon.Information) = DialogResult.Yes Then
    '                                    'Else
    '                                    '    blnErr = True
    '                                    '    Return False
    '                                    'End If
    '                            End Select
    '                        Case Else
    '                            If sqlEx.Source IsNot Nothing Then
    '                                '-----エラーログ出力
    '                                Dim strErrMsg As String = $"{My.Resources.ErrLogSqlExecutionFailure}{sbSQL.ToString}|{sqlEx.Message}"
    '                                WL.WriteLogDat(strErrMsg)
    '                            Else
    '                                '---排他制御
    '                                Dim strMsg As String = $"既に他の担当者によって変更されているため保存出来ません。{vbCrLf}再度登録し直して下さい。"
    '                                MessageBox.Show(strMsg, "同時更新無効", MessageBoxButtons.OK, MessageBoxIcon.Warning)
    '                            End If
    '                            blnErr = True
    '                            Return False
    '                    End Select
    '                Finally
    '                    DB.Commit(Not blnErr)
    '                End Try
    '            End Using

    '            Return True
    '        Catch ex As Exception
    '            EM.ErrorSyori(ex, False, conblnNonMsg)
    '            Return False
    '        Finally
    '        End Try
    '    End Function

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
                Dim cmd As Button = DirectCast(Me.Controls.Find("cmdFunc" & intFunc, True)(0), Button)
                With cmd
                    If cmd IsNot Nothing AndAlso .Text.Length = 0 OrElse .Text.Substring(0, .Text.IndexOf("(")).IsNulOrWS Then
                        .Text = ""
                        '.Visible = False
                        .Enabled = False
                    End If
                End With
            Next intFunc

            Return True
        Catch ex As Exception
            EM.ErrorSyori(ex, False, conblnNonMsg)
            Return False
        End Try
    End Function

#End Region

#Region "入力チェック"

    Public Function FunCheckInput() As Boolean
        Try
            IsValidated = True
            IsCheckRequired = True

            Call MtxBUSYO_NAME_Validating(mtxBUSYO_NAME, Nothing)

            Return IsValidated
        Catch ex As Exception
            Throw
        Finally
            IsCheckRequired = False
        End Try
    End Function

    Private Sub CmbBUMON_KB_Validating(sender As Object, e As System.ComponentModel.CancelEventArgs)
        Dim cmb As ComboboxEx = DirectCast(sender, ComboboxEx)
        If IsCheckRequired Then
            IsValidated *= ErrorProvider.UpdateErrorInfo(cmb, cmb.IsSelected, String.Format(My.Resources.infoMsgRequireSelectOrInput, "部門区分"))
        End If
    End Sub

    Private Sub CmbBUSYO_KB_Validating(sender As Object, e As System.ComponentModel.CancelEventArgs)
        Dim cmb As ComboboxEx = DirectCast(sender, ComboboxEx)
        If IsCheckRequired Then
            IsValidated *= ErrorProvider.UpdateErrorInfo(cmb, cmb.IsSelected, String.Format(My.Resources.infoMsgRequireSelectOrInput, "部署区分"))
        End If
    End Sub

    Private Sub DatYUKO_YMD_Validating(sender As Object, e As System.ComponentModel.CancelEventArgs)
        Dim dtx As DateTextBoxEx = DirectCast(sender, DateTextBoxEx)
        If IsCheckRequired Then
            IsValidated *= ErrorProvider.UpdateErrorInfo(dtx, Not dtx.ValueNonFormat.IsNulOrWS, String.Format(My.Resources.infoMsgRequireSelectOrInput, "有効期限"))
        End If
    End Sub

    Private Sub MtxBUSYO_NAME_Validating(sender As Object, e As System.ComponentModel.CancelEventArgs) Handles mtxBUSYO_NAME.Validating
        Dim mtx As MaskedTextBoxEx = DirectCast(sender, MaskedTextBoxEx)
        If IsCheckRequired Then
            IsValidated *= ErrorProvider.UpdateErrorInfo(mtx, Not mtx.Text.IsNulOrWS, String.Format(My.Resources.infoMsgRequireSelectOrInput, "部署名"))
        End If
    End Sub

#End Region

#Region "ローカル関数"

#Region "処理モード別画面初期化"

    Private Function FunInitializeControls(ByVal intMODE As Integer) As Boolean
        Try

            Select Case intMODE
                Case ENM_DATA_OPERATION_MODE._1_ADD
                    Me.Text = pub_APP_INFO.strTitle & "（追加）"
                    Me.lblTytle.Text = Me.Text
                    Me.cmdFunc1.Text = "追加(F1)"

                    Me.lbllblEDIT_YMDHNS.Visible = False
                    Me.lblEDIT_YMDHNS.Visible = False
                    Me.lbllblEDIT_SYAIN_ID.Visible = False
                    Me.lblEDIT_SYAIN_ID.Visible = False

                Case ENM_DATA_OPERATION_MODE._2_ADDREF
                    Call FunSetEntityValues(PrDataRow)

                    Me.Text = pub_APP_INFO.strTitle & "（類似追加）"
                    Me.lblTytle.Text = Me.Text
                    Me.cmdFunc1.Text = "追加(F1)"

                    Me.lbllblEDIT_YMDHNS.Visible = False
                    Me.lblEDIT_YMDHNS.Visible = False
                    Me.lbllblEDIT_SYAIN_ID.Visible = False
                    Me.lblEDIT_SYAIN_ID.Visible = False

                Case ENM_DATA_OPERATION_MODE._3_UPDATE
                    Call FunSetEntityValues(PrDataRow)

                    Me.Text = pub_APP_INFO.strTitle & "（変更）"
                    Me.lblTytle.Text = Me.Text
                    Me.cmdFunc1.Text = "変更(F1)"

                    Me.lbllblEDIT_YMDHNS.Visible = True
                    Me.lblEDIT_YMDHNS.Visible = True
                    Me.lbllblEDIT_SYAIN_ID.Visible = True
                    Me.lblEDIT_SYAIN_ID.Visible = True

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
    ''' <param name="row"></param>
    ''' <returns></returns>
    Private Function FunSetEntityValues(row As C1.Win.C1FlexGrid.Row) As Boolean
        Dim _model As New MODEL.M003_GYOMU_GROUP
        Try

            '-----コントロールに値をセット
            With row

                'Me.cmbSYOZOKUCYO.SelectedValue = .Item(NameOf(_model.SYOZOKUCYO_ID))

                '更新日時
                Dim dt As DateTime
                dt = DateTime.ParseExact(.Item(NameOf(_model.UPD_YMDHNS)).ToString, "yyyy/MM/dd HH:mm:ss", Nothing)
                Me.lblEDIT_YMDHNS.Text = dt.ToString("yyyy/MM/dd HH:mm:ss")

                Me.mtxGYOMU_GROUP_ID.Text = .Item(NameOf(_model.GYOMU_GROUP_ID))
                Me.mtxBUSYO_NAME.Text = .Item(NameOf(_model.GYOMU_GROUP_NAME))

                '更新担当
                'Me.lblEDIT_SYAIN_ID.Text = .Item(NameOf(_model.UPD_SYAIN_NAME)).ToString

            End With

            Return True
        Catch ex As Exception
            EM.ErrorSyori(ex, False, conblnNonMsg)
            Return False
        End Try
    End Function

#End Region

#End Region

End Class