Imports JMS_COMMON.ClsPubMethod

Public Class FrmM1011

#Region "変数・定数"

    Private _M101 As New MODEL.M101_TORIHIKI

#End Region

#Region "プロパティ"

    ''' <summary>
    ''' 新規追加レコードのキー
    ''' </summary>

    ''' <summary>
    ''' 一覧選択レコード
    ''' </summary>
    ''' <returns></returns>
    'Public Property PrDataRow As DataRow

    Public Property PrMODE As Integer

    ''' <summary>
    ''' 新規追加レコードのキー
    ''' </summary>
    Public Property PrPKeys As (ITEM_NAME As String, ITEM_VALUE As String)

    Public Property PrDataRow As C1.Win.C1FlexGrid.Row

#End Region

#Region "FORMイベント"

    Private Sub Frm_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        Try
            '-----フォーム共通設定
            Call FunFormCommonSetting(pub_APP_INFO, pub_SYAIN_INFO)

            '-----位置・サイズ
            Me.Height = 700
            Me.Top = Me.Owner.Top + (Me.Owner.Height - Me.Height) - 26 ' / 2
            Me.Left = Me.Owner.Left + (Me.Owner.Width - Me.Width) / 2

            '-----各コントロールのデータソースを設定
            Me.cmbTORI_KB.SetDataSource(tblTORI_KB.ExcludeDeleted, ENM_COMBO_SELECT_VALUE_TYPE._0_Required)

            Dim intTORI_SYU As Integer
            For Each item As Integer In [Enum].GetValues(GetType(Context.ENM_TORI_SYU))
                intTORI_SYU = intTORI_SYU + item
            Next

            Call FunSetBinding()

            '-----処理モード別画面初期化
            If FunInitializeControls(PrMODE) = False Then
                Me.Close()
            End If
            '-----ダイアログウィンドウ設定
            Me.FormBorderStyle = Windows.Forms.FormBorderStyle.FixedDialog
            Me.ControlBox = False
        Catch ex As Exception
            EM.ErrorSyori(ex, False, conblnNonMsg)
        End Try
    End Sub

#End Region

#Region "FUNCTIONボタン関連"

#Region "ボタンクリックイベント"

    Private Sub CmdFunc_Click(ByVal sender As Object, ByVal e As EventArgs) Handles cmdFunc1.Click, cmdFunc2.Click, cmdFunc3.Click, cmdFunc4.Click, cmdFunc5.Click, cmdFunc6.Click, cmdFunc7.Click, cmdFunc8.Click, cmdFunc9.Click, cmdFunc10.Click, cmdFunc11.Click, cmdFunc12.Click
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
                        'Me.PrPKeys = _M101.TORI_ID

                        Me.DialogResult = Windows.Forms.DialogResult.OK
                        Me.Close()
                    End If

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

                    Dim ModelInfo As New MODEL.ModelInfo(Of MODEL.M101_TORIHIKI) With {.OnlyAutoGenerateField = True}
                    _M101.ADD_YMDHNS = strSysDate
                    _M101.ADD_SYAIN_ID = pub_SYAIN_INFO.SYAIN_ID
                    _M101.UPD_SYAIN_ID = pub_SYAIN_INFO.SYAIN_ID

                    _M101.UPD_YMDHNS = _M101.UPD_YMDHNS.Replace("/", "").Replace(":", "").Replace(" ", "")

                    _M101.POST = _M101.POST.ToString.Replace("〒", "")

                    Select Case PrMODE
                        Case ENM_DATA_OPERATION_MODE._1_ADD, ENM_DATA_OPERATION_MODE._2_ADDREF
                            _M101.TORI_ID = FunGetNextTORI_ID()
                        Case Else
                    End Select

                    '-----MERGE
                    sbSQL.Remove(0, sbSQL.Length)
                    sbSQL.Append($"MERGE INTO {ModelInfo.Name} AS TARGET")
                    sbSQL.Append($" USING (SELECT")

                    sbSQL.Append($" {_M101.TORI_ID} AS {NameOf(_M101.TORI_ID)}")
                    sbSQL.Append($",'{_M101.TORI_NAME.Trim}' AS {NameOf(_M101.TORI_NAME)}")

                    'UNDONE: すべてのフィールドを追加
                    sbSQL.Append($",'{_M101.TORI_KB}' AS {NameOf(_M101.TORI_KB)}")
                    sbSQL.Append($",'{_M101.POST.Trim}' AS {NameOf(_M101.POST)}")
                    sbSQL.Append($",'{_M101.ADD1.Trim}' AS {NameOf(_M101.ADD1)}")
                    sbSQL.Append($",'{_M101.ADD2.Trim}' AS {NameOf(_M101.ADD2)}")
                    sbSQL.Append($",'{_M101.ADD3.Trim}' AS {NameOf(_M101.ADD3)}")
                    sbSQL.Append($",'{_M101.TEL.Trim}' AS {NameOf(_M101.TEL)}")
                    sbSQL.Append($",'{_M101.FAX.Trim}' AS {NameOf(_M101.FAX)}")

                    sbSQL.Append($",'{_M101.ADD_YMDHNS}' AS {NameOf(_M101.ADD_YMDHNS)}")
                    sbSQL.Append($",{_M101.ADD_SYAIN_ID} AS {NameOf(_M101.ADD_SYAIN_ID)}")
                    sbSQL.Append($",'{_M101.UPD_YMDHNS}' AS {NameOf(_M101.UPD_YMDHNS)}")
                    sbSQL.Append($",{_M101.UPD_SYAIN_ID} AS {NameOf(_M101.UPD_SYAIN_ID)}")
                    sbSQL.Append($",'{_M101.DEL_YMDHNS}' AS {NameOf(_M101.DEL_YMDHNS)}")
                    sbSQL.Append($",{_M101.DEL_SYAIN_ID} AS {NameOf(_M101.DEL_SYAIN_ID)}")

                    sbSQL.Append($" ) AS WK")
                    'テーブルのキー
                    sbSQL.Append($" ON (TARGET.{NameOf(_M101.TORI_ID)} = WK.{NameOf(_M101.TORI_ID)})")

                    '---UPDATE 排他制御 更新日時が変更されていない場合のみ
                    sbSQL.Append($" WHEN MATCHED AND TARGET.{NameOf(_M101.UPD_YMDHNS)} = WK.{NameOf(_M101.UPD_YMDHNS)} THEN")
                    sbSQL.Append($" UPDATE SET")
                    sbSQL.Append($" TARGET.{NameOf(_M101.TORI_NAME)} = WK.{NameOf(_M101.TORI_NAME)}")
                    sbSQL.Append($" ,TARGET.{NameOf(_M101.TORI_KB)} = WK.{NameOf(_M101.TORI_KB)}")
                    sbSQL.Append($" ,TARGET.{NameOf(_M101.POST)} = WK.{NameOf(_M101.POST)}")
                    sbSQL.Append($" ,TARGET.{NameOf(_M101.ADD1)} = WK.{NameOf(_M101.ADD1)}")
                    sbSQL.Append($" ,TARGET.{NameOf(_M101.ADD2)} = WK.{NameOf(_M101.ADD2)}")
                    sbSQL.Append($" ,TARGET.{NameOf(_M101.ADD3)} = WK.{NameOf(_M101.ADD3)}")
                    sbSQL.Append($" ,TARGET.{NameOf(_M101.TEL)} = WK.{NameOf(_M101.TEL)}")
                    sbSQL.Append($" ,TARGET.{NameOf(_M101.FAX)} = WK.{NameOf(_M101.FAX)}")

                    sbSQL.Append($",TARGET.{NameOf(_M101.UPD_YMDHNS)} = '{strSysDate}'")
                    sbSQL.Append($",TARGET.{NameOf(_M101.UPD_SYAIN_ID)} = WK.{NameOf(_M101.UPD_SYAIN_ID)}")

                    '---INSERT
                    sbSQL.Append($" WHEN NOT MATCHED THEN")
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
        Finally
        End Try
    End Function

#End Region

#End Region

#Region "コントロールイベント"

    Private Sub MtxPOST_Validated(sender As Object, e As EventArgs) Handles mtxPOST.Validated
        Call BtnSrchYubin_Click(Nothing, Nothing)
    End Sub

    '住所検索
    Private Sub BtnSrchYubin_Click(sender As Object, e As EventArgs) Handles btnSrchYubin.Click
        Dim sbSQL As New System.Text.StringBuilder
        Dim dsList As New System.Data.DataSet

        Try
            If Me.mtxPOST.Text.Replace("〒", "").Replace(" ", "").Replace("-", "").Length < 7 And Me.mtxPOST.Text.Replace("〒", "").Replace(" ", "").Replace("-", "").Length > 0 Then
                MessageBox.Show("郵便番号が不正です。", "住所検索", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Me.mtxPOST.Focus()
                Exit Sub
            ElseIf Me.mtxPOST.Text.Replace("〒", "").Replace(" ", "").Replace("-", "").Length = 0 Then
                Exit Sub
            End If

            'SQL
            sbSQL.Remove(0, sbSQL.Length)
            sbSQL.Append("SELECT ")
            sbSQL.Append(" 郵便番号7, ")
            sbSQL.Append(" 都道府県名, ")
            sbSQL.Append(" 市区町村名, ")
            sbSQL.Append(" 町域名 ")
            sbSQL.Append(" FROM " & "PostalCode" & " ")
            sbSQL.Append(" Where 郵便番号7='" & Me.mtxPOST.Text.Replace("〒", "").Replace("-", "") & "' ")
            Using DB As ClsDbUtility = DBOpen()
                dsList = DB.GetDataSet(sbSQL.ToString, conblnNonMsg)
            End Using

            If dsList IsNot Nothing Then
                With dsList.Tables(0)
                    If .Rows.Count > 0 Then
                        Me.mtxADD1.Text = .Rows(0).Item("都道府県名").ToString & .Rows(0).Item("市区町村名").ToString & .Rows(0).Item("町域名").ToString
                        Me.mtxADD1.Focus()
                        SendKeys.Send("{RIGHT}")
                    Else
                        MessageBox.Show("入力された郵便番号に該当する住所が存在しません。", "住所検索", MessageBoxButtons.OK, MessageBoxIcon.Information)
                        Me.mtxPOST.Focus()
                    End If
                End With
            End If
        Catch ex As Exception
            EM.ErrorSyori(ex, False, conblnNonMsg)
        Finally
            If dsList IsNot Nothing Then
                dsList.Dispose()
            End If

        End Try
    End Sub

    '取引区分
    Private Sub CmbTORI_KB_Validating(sender As Object, e As System.ComponentModel.CancelEventArgs) Handles cmbTORI_KB.Validating
        Dim cmb As ComboboxEx = DirectCast(sender, ComboboxEx)
        If IsCheckRequired Then
            IsValidated *= ErrorProvider.UpdateErrorInfo(cmb, cmb.IsSelected, String.Format(My.Resources.infoMsgRequireSelectOrInput, "取引区分"))
        End If
    End Sub

    '取引先名
    Private Sub MtxTORI_NAME_Validating(sender As Object, e As System.ComponentModel.CancelEventArgs) Handles mtxTORI_NAME.Validating
        Dim mtx As MaskedTextBoxEx = DirectCast(sender, MaskedTextBoxEx)
        If IsCheckRequired Then
            IsValidated *= ErrorProvider.UpdateErrorInfo(mtx, Not mtx.Text.IsNulOrWS, String.Format(My.Resources.infoMsgRequireSelectOrInput, "取引先名"))
        End If
    End Sub

#End Region

#Region "入力チェック"

    Public Function FunCheckInput() As Boolean

        Try
            IsValidated = True
            IsCheckRequired = True

            '取引区分
            Call CmbTORI_KB_Validating(cmbTORI_KB, Nothing)

            '取引先名
            Call MtxTORI_NAME_Validating(mtxTORI_NAME, Nothing)

            Return IsValidated
        Catch ex As Exception
            Throw
        Finally
            IsCheckRequired = False

        End Try
    End Function

#End Region

#Region "ローカル関数"

    Private Function FunGetNextTORI_ID() As Integer
        Dim dsList As New System.Data.DataSet
        Try
            Dim intRET As Integer
            Dim sbSQL As New System.Text.StringBuilder
            Using DB As ClsDbUtility = DBOpen()
                sbSQL.Remove(0, sbSQL.Length)
                sbSQL.Append("SELECT TORI_ID FROM " & NameOf(MODEL.VWM101_TORIHIKI) & "")
                dsList = DB.GetDataSet(sbSQL.ToString, conblnNonMsg)

                If dsList.Tables(0).Rows.Count > 0 Then
                    sbSQL.Remove(0, sbSQL.Length)
                    sbSQL.Append("SELECT MAX(TORI_ID) FROM " & NameOf(MODEL.VWM101_TORIHIKI) & "")

                    dsList = DB.GetDataSet(sbSQL.ToString, conblnNonMsg)

                    intRET = Val(dsList.Tables(0).Rows(0).Item(0)) + 1
                Else
                    intRET = 1
                End If
            End Using
            Return intRET
        Catch ex As Exception
            EM.ErrorSyori(ex, False, conblnNonMsg)
            Return -1
        Finally
            dsList.Dispose()
        End Try
    End Function

#Region "バインディング"

    Private Function FunSetBinding() As Boolean

        mtxTORI_ID.DataBindings.Add(New Binding(NameOf(mtxTORI_ID.Text), _M101, NameOf(_M101.TORI_ID), False, DataSourceUpdateMode.OnPropertyChanged, ""))

        cmbTORI_KB.DataBindings.Add(New Binding(NameOf(cmbTORI_KB.SelectedValue), _M101, NameOf(_M101.TORI_KB), False, DataSourceUpdateMode.OnPropertyChanged, ""))
        mtxTORI_NAME.DataBindings.Add(New Binding(NameOf(mtxTORI_NAME.Text), _M101, NameOf(_M101.TORI_NAME), False, DataSourceUpdateMode.OnPropertyChanged, ""))

        mtxPOST.DataBindings.Add(New Binding(NameOf(mtxPOST.Text), _M101, NameOf(_M101.POST), False, DataSourceUpdateMode.OnPropertyChanged, ""))
        mtxADD1.DataBindings.Add(New Binding(NameOf(mtxADD1.Text), _M101, NameOf(_M101.ADD1), False, DataSourceUpdateMode.OnPropertyChanged, ""))
        mtxADD2.DataBindings.Add(New Binding(NameOf(mtxADD2.Text), _M101, NameOf(_M101.ADD2), False, DataSourceUpdateMode.OnPropertyChanged, ""))
        mtxADD3.DataBindings.Add(New Binding(NameOf(mtxADD3.Text), _M101, NameOf(_M101.ADD3), False, DataSourceUpdateMode.OnPropertyChanged, ""))

        mtxTEL1.DataBindings.Add(New Binding(NameOf(mtxTEL1.Text), _M101, NameOf(_M101.TEL_P1), False, DataSourceUpdateMode.OnPropertyChanged, ""))
        mtxTEL2.DataBindings.Add(New Binding(NameOf(mtxTEL2.Text), _M101, NameOf(_M101.TEL_P2), False, DataSourceUpdateMode.OnPropertyChanged, ""))
        mtxTEL3.DataBindings.Add(New Binding(NameOf(mtxTEL3.Text), _M101, NameOf(_M101.TEL_P3), False, DataSourceUpdateMode.OnPropertyChanged, ""))
        mtxFAX1.DataBindings.Add(New Binding(NameOf(mtxFAX1.Text), _M101, NameOf(_M101.FAX_P1), False, DataSourceUpdateMode.OnPropertyChanged, ""))
        mtxFAX2.DataBindings.Add(New Binding(NameOf(mtxFAX2.Text), _M101, NameOf(_M101.FAX_P2), False, DataSourceUpdateMode.OnPropertyChanged, ""))
        mtxFAX3.DataBindings.Add(New Binding(NameOf(mtxFAX3.Text), _M101, NameOf(_M101.FAX_P3), False, DataSourceUpdateMode.OnPropertyChanged, ""))

        lblEDIT_YMDHNS.DataBindings.Add(New Binding(NameOf(lblEDIT_YMDHNS.Text), _M101, NameOf(_M101.UPD_YMDHNS), False, DataSourceUpdateMode.OnPropertyChanged, ""))

    End Function

#End Region

#Region "処理モード別画面初期化"

    ''' <summary>
    ''' 処理モード別画面初期化
    ''' </summary>
    ''' <param name="intMODE"></param>
    ''' <returns></returns>
    Private Function FunInitializeControls(ByVal intMODE As Integer) As Boolean

        Try
            Dim _Model = New MODEL.ModelInfo(Of MODEL.M101_TORIHIKI)(_OnlyAutoGenerateField:=True)

            Select Case intMODE
                Case ENM_DATA_OPERATION_MODE._1_ADD
                    lblTytle.Text &= "（追加）"
                    Me.cmdFunc1.Text = "追加(F1)"
                    Me.lblEDIT_YMDHNS.Visible = False
                    Me.cmbTORI_KB.SelectedValue = "1"

                    'Me.mtxTORI_ID.Text = "<新規>"
                    'Me.mtxTORI_ID.ReadOnly = True
                Case ENM_DATA_OPERATION_MODE._2_ADDREF
                    '一覧選択行のデータをモデルに読込
                    Call FunSetEntityValues(PrDataRow)

                    lblTytle.Text &= "（類似追加）"
                    Me.cmdFunc1.Text = "追加(F1)"
                    Me.lblEDIT_YMDHNS.Visible = False
                    Me.lblEDIT_YMDHNS.Visible = False

                Case ENM_DATA_OPERATION_MODE._3_UPDATE

                    Call FunSetEntityValues(PrDataRow)

                    lblTytle.Text &= "（変更）"
                    Me.cmdFunc1.Text = "変更(F1)"

                    Me.mtxTORI_ID.Enabled = False
                    Me.mtxTORI_NAME.Enabled = True
                    Me.lbllblUPD_YMDHNS.Visible = True
                    Me.lblEDIT_YMDHNS.Visible = True
                    Me.lblEDIT_SYAIN_ID.Visible = True
                    Me.lbllblEDIT_SYAIN_ID.Visible = True

                Case Else
                    'UNDONE:エラーMsg
                    Return False
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
    Private Function FunSetEntityValues(row As C1.Win.C1FlexGrid.Row) As Boolean
        Try
            '-----コントロールに値をセット
            With row
                '取引先CD
                Me.mtxTORI_ID.Text = .Item("TORI_ID")
                '取引種別
                Me.cmbTORI_KB.Text = .Item("TORI_KB_DISP")
                '取引先名称
                Me.mtxTORI_NAME.Text = .Item("TORI_NAME")
                '郵便番号
                Me.mtxPOST.Text = .Item("POST")
                '住所1-3
                Me.mtxADD1.Text = .Item("ADD1")
                Me.mtxADD2.Text = .Item("ADD2")
                Me.mtxADD3.Text = .Item("ADD3")
                'TEL
                If .Item("TEL").ToString.IsNulOrWS = False Then
                    Me.mtxTEL1.Text = .Item("TEL").ToString.Split("-")(0)
                    Me.mtxTEL2.Text = .Item("TEL").ToString.Split("-")(1)
                    Me.mtxTEL3.Text = .Item("TEL").ToString.Split("-")(2)
                End If
                'FAX
                If .Item("FAX").ToString.IsNulOrWS = False Then
                    Me.mtxFAX1.Text = .Item("FAX").ToString.Split("-")(0)
                    Me.mtxFAX2.Text = .Item("FAX").ToString.Split("-")(1)
                    Me.mtxFAX3.Text = .Item("FAX").ToString.Split("-")(2)
                End If
                '更新日時
                Dim dt As DateTime
                If .Item("UPD_YMDHNS").ToString.Replace("/", "").Replace(":", "").Trim = "" Then
                    'dt = DateTime.Now
                    Me.lblEDIT_YMDHNS.Text = ""
                Else
                    dt = DateTime.ParseExact(.Item("UPD_YMDHNS").ToString, "yyyy/MM/dd HH:mm:ss", Nothing)
                    Me.lblEDIT_YMDHNS.Text = dt.ToString("yyyy/MM/dd HH:mm:ss")
                End If

                '更新担当者コード
                Me.lblEDIT_SYAIN_ID.Text = .Item("UPD_SYAIN_ID").ToString.Trim & " " & Fun_GetUSER_NAME(.Item("UPD_SYAIN_ID").ToString.Trim)

            End With

            Return True
        Catch ex As Exception
            Throw
            Return False
        End Try
    End Function

#End Region

#End Region

End Class