Imports JMS_COMMON.ClsPubMethod

''' <summary>
''' 部品番号マスタ編集画面
''' </summary>
Public Class FrmM1061

#Region "変数・定数"
    Private IsValidated As Boolean
    Private _M106 As New MODEL.M106_BUHIN
    Private _VWM106 As New MODEL.VWM106_BUHIN
#End Region

#Region "プロパティ"
    ''' <summary>
    ''' 処理モード
    ''' </summary>
    Public Property PrDATA_OP_MODE As Integer

    ''' <summary>
    ''' 新規追加レコードのキー
    ''' </summary>
    Public Property PrPKeys As Integer

    ''' <summary>
    ''' 一覧の選択行データ
    ''' </summary>
    Public Property PrDataRow As DataRow

#End Region

#Region "コンストラクタ"

    ''' <summary>
    ''' コンストラクタ
    ''' </summary>
    ''' <remarks>コンストラクタ</remarks>
    Public Sub New()

        ' この呼び出しはデザイナーで必要です。
        InitializeComponent()

        Me.Height = 300
        Me.FormBorderStyle = Windows.Forms.FormBorderStyle.FixedDialog
        Me.MaximizeBox = False
        Me.MinimizeBox = False

        'Me.cmbBUMON_KB.NullValue = 0
        'Me.cmbKEIYAKU_KB.NullValue = 0
        'Me.cmbRIKUKAIKU_KB.NullValue = 0
        Me.cmbTOKUI_ID.NullValue = 0
        Me.chkTachiai.Checked = False

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
            Me.Top = Me.Owner.Top + (Me.Owner.Height - Me.Height) - 10 ' / 2
            Me.Left = Me.Owner.Left + (Me.Owner.Width - Me.Width) / 2

            '-----コントロールデータソース設定
            cmbBUMON_KB.SetDataSource(tblBUMON.ExcludeDeleted, ENM_COMBO_SELECT_VALUE_TYPE._0_Required)
            cmbTOKUI_ID.SetDataSource(tblTORIHIKI.ExcludeDeleted, ENM_COMBO_SELECT_VALUE_TYPE._0_Required)
            cmbRIKUKAIKU_KB.SetDataSource(tblRIKUKAIKU_KB.ExcludeDeleted, ENM_COMBO_SELECT_VALUE_TYPE._1_Filter)

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

#Region "FUNCTIONボタンCLICK"

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
                Case 1  '追加
                    If FunSAVE() Then
                        'プロパティに対象レコードのキーを設定
                        'Me.PrPKeys() = _M106.BUMON_KB

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

    'カラーの選択
    Private Sub btnCOLOR_SELECT_Click(sender As Object, e As EventArgs) Handles btnCOLOR_SELECT.Click
        Dim ColorDialog1 As New ColorDialog()

        ' 初期選択する色を設定する
        ColorDialog1.Color = lblSELECTED_COLOR.BackColor

        ' カスタム カラーを定義可能にする (初期値 True)
        'ColorDialog1.AllowFullOpen = True

        ' カスタム カラーを表示した状態にする (初期値 False)
        ColorDialog1.FullOpen = True

        ' 使用可能なすべての色を基本セットに表示する (初期値 False)
        ColorDialog1.AnyColor = True

        ' 純色のみ表示する (初期値 False)
        ColorDialog1.SolidColorOnly = True

        ' カスタム カラーを任意の色で設定する
        ColorDialog1.CustomColors = New Integer() {&H8040FF, &HFF8040, &H80FF40, &H4080FF}

        ' [ヘルプ] ボタンを表示する
        ColorDialog1.ShowHelp = True

        ' ダイアログを表示し、戻り値が [OK] の場合は選択した色を TextBox1 に適用する
        If ColorDialog1.ShowDialog() = DialogResult.OK Then
            lblSELECTED_COLOR.BackColor = ColorDialog1.Color
        End If

        ' 不要になった時点で破棄する (正しくは オブジェクトの破棄を保証する を参照)
        ColorDialog1.Dispose()
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

                    Dim ModelInfo As New MODEL.ModelInfo(Of MODEL.M106_BUHIN)(_OnlyAutoGenerateField:=True)

                    '＜モデル更新＞
                    '立会フラグ
                    If Me.chkTachiai.Checked = True Then
                        _M106.TACHIAI_FLG = "1"
                    Else
                        _M106.TACHIAI_FLG = "0"
                    End If

                    '色選択
                    _M106.COLOR_CD = "#" & Hex(lblSELECTED_COLOR.BackColor.R).ToString.PadLeft(2, "0"c) & Hex(lblSELECTED_COLOR.BackColor.G).ToString.PadLeft(2, "0"c) & Hex(lblSELECTED_COLOR.BackColor.B).ToString.PadLeft(2, "0"c)

                    _M106.ADD_SYAIN_ID = pub_SYAIN_INFO.SYAIN_ID
                    _M106.ADD_YMDHNS = strSysDate
                    _M106.UPD_SYAIN_ID = pub_SYAIN_INFO.SYAIN_ID
                    '_M106.UPD_YMDHNS = strSysDate

                    '-----MERGE
                    sbSQL.Remove(0, sbSQL.Length)
                    sbSQL.Append($"MERGE INTO {ModelInfo.Name} AS TARGET")
                    sbSQL.Append($" USING (SELECT")

                    sbSQL.Append($" '{_M106.BUMON_KB}' AS {NameOf(_M106.BUMON_KB)}")
                    sbSQL.Append($", {_M106.TOKUI_ID} AS {NameOf(_M106.TOKUI_ID)}")
                    sbSQL.Append($",'{_M106.BUHIN_BANGO}' AS {NameOf(_M106.BUHIN_BANGO)}")
                    sbSQL.Append($",'{_M106.SYANAI_CD}' AS {NameOf(_M106.SYANAI_CD)}")
                    sbSQL.Append($",'{_M106.BUHIN_NAME}' AS {NameOf(_M106.BUHIN_NAME)}")
                    sbSQL.Append($",'{_M106.KEIYAKU_KB}' AS {NameOf(_M106.KEIYAKU_KB)}")
                    sbSQL.Append($",'{_M106.ZUBAN_C}' AS {NameOf(_M106.ZUBAN_C)}")
                    sbSQL.Append($",'{_M106.HINSYU_BANGO}' AS {NameOf(_M106.HINSYU_BANGO)}")
                    sbSQL.Append($",'{_M106.RIKUKAIKU_KB}' AS {NameOf(_M106.RIKUKAIKU_KB)}")
                    sbSQL.Append($",'{_M106.TANKA}' AS {NameOf(_M106.TANKA)}")
                    sbSQL.Append($",'{_M106._TACHIAI_FLG}' AS {NameOf(_M106.TACHIAI_FLG)}")
                    sbSQL.Append($",'{_M106.COLOR_CD}' AS {NameOf(_M106.COLOR_CD)}")
                    sbSQL.Append($",'{_M106.ADD_YMDHNS}' AS {NameOf(_M106.ADD_YMDHNS)}")
                    sbSQL.Append($", {_M106.ADD_SYAIN_ID} AS {NameOf(_M106.ADD_SYAIN_ID)}")
                    sbSQL.Append($",'{_M106.UPD_YMDHNS}' AS {NameOf(_M106.UPD_YMDHNS)}")
                    sbSQL.Append($", {_M106.UPD_SYAIN_ID} AS {NameOf(_M106.UPD_SYAIN_ID)}")
                    sbSQL.Append($",'{_M106.DEL_YMDHNS}' AS {NameOf(_M106.DEL_YMDHNS)}")
                    sbSQL.Append($", {_M106.DEL_SYAIN_ID} AS {NameOf(_M106.DEL_SYAIN_ID)}")

                    sbSQL.Append($" ) AS WK ON (")
                    sbSQL.Append($" TARGET.{NameOf(_M106.BUMON_KB)} = WK.{NameOf(_M106.BUMON_KB)}")
                    sbSQL.Append($" AND TARGET.{NameOf(_M106.TOKUI_ID)} = WK.{NameOf(_M106.TOKUI_ID)}")
                    sbSQL.Append($" AND TARGET.{NameOf(_M106.BUHIN_BANGO)} = WK.{NameOf(_M106.BUHIN_BANGO)}")
                    sbSQL.Append($" )")

                    '---UPDATE 排他制御 更新日時が変更されていない場合のみ
                    sbSQL.Append($" WHEN MATCHED AND TARGET.{NameOf(_M106.UPD_YMDHNS)} = WK.{NameOf(_M106.UPD_YMDHNS)} THEN ")
                    sbSQL.Append($" UPDATE SET")
                    sbSQL.Append($" TARGET.{NameOf(_M106.SYANAI_CD)} = WK.{NameOf(_M106.SYANAI_CD)}")
                    sbSQL.Append($",TARGET.{NameOf(_M106.BUHIN_NAME)} = WK.{NameOf(_M106.BUHIN_NAME)}")
                    sbSQL.Append($",TARGET.{NameOf(_M106.KEIYAKU_KB)} = WK.{NameOf(_M106.KEIYAKU_KB)}")
                    sbSQL.Append($",TARGET.{NameOf(_M106.ZUBAN_C)} = WK.{NameOf(_M106.ZUBAN_C)}")
                    sbSQL.Append($",TARGET.{NameOf(_M106.HINSYU_BANGO)} = WK.{NameOf(_M106.HINSYU_BANGO)}")
                    sbSQL.Append($",TARGET.{NameOf(_M106.RIKUKAIKU_KB)} = WK.{NameOf(_M106.RIKUKAIKU_KB)}")
                    sbSQL.Append($",TARGET.{NameOf(_M106.TANKA)} = WK.{NameOf(_M106.TANKA)}")
                    sbSQL.Append($",TARGET.{NameOf(_M106.TACHIAI_FLG)} = WK.{NameOf(_M106.TACHIAI_FLG)}")
                    sbSQL.Append($",TARGET.{NameOf(_M106.COLOR_CD)} = WK.{NameOf(_M106.COLOR_CD)}")
                    sbSQL.Append($",TARGET.{NameOf(_M106.UPD_YMDHNS)} = '{strSysDate}'")
                    sbSQL.Append($",TARGET.{NameOf(_M106.UPD_SYAIN_ID)} = WK.{NameOf(_M106.UPD_SYAIN_ID)}")

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
    ''' <param name="frm">対象フォーム</param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function FunInitFuncButtonEnabled() As Boolean

        Try
            For intFunc As Integer = 1 To 12
                With Me.Controls("cmdFunc" & intFunc)
                    If .Text.Length = 0 OrElse .Text.Substring(0, .Text.IndexOf("(")).IsNullOrWhiteSpace Then
                        .Text = ""
                        .Visible = False
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

#End Region

#Region "コントロールイベント"

#End Region

#Region "ローカル関数"

#Region "バインディング"
    Private Function FunSetBinding() As Boolean
        cmbBUMON_KB.DataBindings.Add(New Binding(NameOf(cmbBUMON_KB.SelectedValue), _M106, NameOf(_M106.BUMON_KB), False, DataSourceUpdateMode.OnPropertyChanged, ""))
        cmbTOKUI_ID.DataBindings.Add(New Binding(NameOf(cmbTOKUI_ID.SelectedValue), _M106, NameOf(_M106.TOKUI_ID), False, DataSourceUpdateMode.OnPropertyChanged, ""))
        mtxBUHIN_BANGO.DataBindings.Add(New Binding(NameOf(mtxBUHIN_BANGO.Text), _M106, NameOf(_M106.BUHIN_BANGO), False, DataSourceUpdateMode.OnPropertyChanged, ""))
        mtxBUHIN_NAME.DataBindings.Add(New Binding(NameOf(mtxBUHIN_NAME.Text), _M106, NameOf(_M106.BUHIN_NAME), False, DataSourceUpdateMode.OnPropertyChanged, ""))
        mtxSYANAI_CD.DataBindings.Add(New Binding(NameOf(mtxSYANAI_CD.Text), _M106, NameOf(_M106.SYANAI_CD), False, DataSourceUpdateMode.OnPropertyChanged, ""))

        cmbKEIYAKU_KB.DataBindings.Add(New Binding(NameOf(cmbKEIYAKU_KB.SelectedValue), _M106, NameOf(_M106.KEIYAKU_KB), False, DataSourceUpdateMode.OnPropertyChanged, ""))

        cmbRIKUKAIKU_KB.DataBindings.Add(New Binding(NameOf(cmbRIKUKAIKU_KB.SelectedValue), _M106, NameOf(_M106.RIKUKAIKU_KB), False, DataSourceUpdateMode.OnPropertyChanged, ""))
        mtxZUBAN_C.DataBindings.Add(New Binding(NameOf(mtxZUBAN_C.Text), _M106, NameOf(_M106.ZUBAN_C), False, DataSourceUpdateMode.OnPropertyChanged, ""))
        mtxTANKA.DataBindings.Add(New Binding(NameOf(mtxTANKA.Text), _M106, NameOf(_M106.TANKA), True, DataSourceUpdateMode.OnPropertyChanged, "", "0.00"))
        mtxHINSYU_BANGO.DataBindings.Add(New Binding(NameOf(mtxHINSYU_BANGO.Text), _M106, NameOf(_M106.HINSYU_BANGO), False, DataSourceUpdateMode.OnPropertyChanged, ""))
        chkTachiai.DataBindings.Add(New Binding(NameOf(chkTachiai.Checked), _M106, NameOf(_M106.TACHIAI_FLG), False, DataSourceUpdateMode.OnPropertyChanged, False))


    End Function

#End Region

#Region "処理モード別画面初期化"
    Private Function FunInitializeControls() As Boolean
        Dim _Model = New MODEL.ModelInfo(Of MODEL.VWM106_BUHIN)(_OnlyAutoGenerateField:=True)
        Dim C_R As Integer
        Dim C_G As Integer
        Dim C_B As Integer

        Try
            Select Case PrDATA_OP_MODE
                Case ENM_DATA_OPERATION_MODE._1_ADD
                    lblTytle.Text &= "（追加）"
                    cmdFunc1.Text = "追加(F1)"

                    lbllblEDIT_YMDHNS.Visible = False
                    lblEDIT_YMDHNS.Visible = False
                    lbllblEDIT_SYAIN_ID.Visible = False
                    lblEDIT_SYAIN_ID.Visible = False

                Case ENM_DATA_OPERATION_MODE._2_ADDREF

                    _M106.Properties.ForEach(Sub(p)
                                                 Select Case p.PropertyType
                                                     Case GetType(Boolean)
                                                         _M106(p.Name) = CBool(PrDataRow.Item(p.Name))
                                                     Case Else
                                                         _M106(p.Name) = PrDataRow.Item(p.Name)
                                                 End Select
                                             End Sub)

                    lblTytle.Text &= "（類似追加）"
                    cmdFunc1.Text = "追加(F1)"

                    lblEDIT_YMDHNS.Visible = False
                    lbllblEDIT_SYAIN_ID.Visible = False
                    lblEDIT_SYAIN_ID.Visible = False

                Case ENM_DATA_OPERATION_MODE._2_ADDREF, ENM_DATA_OPERATION_MODE._3_UPDATE

                    _M106.Properties.ForEach(Sub(p)
                                                 Select Case p.PropertyType
                                                     Case GetType(Boolean)
                                                         _M106(p.Name) = CBool(PrDataRow.Item(p.Name))
                                                     Case Else
                                                         _M106(p.Name) = PrDataRow.Item(p.Name)
                                                 End Select
                                             End Sub)

                    lblTytle.Text &= "（変更）"
                    Me.cmdFunc1.Text = "変更(F1)"



                    Using DB As ClsDbUtility = DBOpen()

                        cmbKEIYAKU_KB.DataBindings.Clear()

                        Select Case cmbBUMON_KB.SelectedValue
                            Case ENM_BUMON_KB._1_風防
                                mtxBUHIN_NAME.Enabled = True

                                Call FunGetCodeDataTable(DB, "風防契約区分", tblKK_KEIYAKU_KB)
                                cmbKEIYAKU_KB.SetDataSource(tblKK_KEIYAKU_KB.ExcludeDeleted, ENM_COMBO_SELECT_VALUE_TYPE._1_Filter)
                                cmbKEIYAKU_KB.Enabled = True
                                _M106.ZUBAN_C = ""
                                mtxZUBAN_C.Enabled = False

                            Case ENM_BUMON_KB._2_LP
                                mtxBUHIN_NAME.Enabled = True

                                Call FunGetCodeDataTable(DB, "LP契約区分", tblLP_KEIYAKU_KB)
                                cmbKEIYAKU_KB.SetDataSource(tblLP_KEIYAKU_KB.ExcludeDeleted, ENM_COMBO_SELECT_VALUE_TYPE._1_Filter)
                                mtxZUBAN_C.Enabled = True

                            Case ENM_BUMON_KB._3_複合材
                                mtxBUHIN_NAME.Enabled = False
                                _M106.BUHIN_NAME = ""
                                Call FunGetCodeDataTable(DB, "複合材契約区分", tblFK_KEIYAKU_KB)
                                cmbKEIYAKU_KB.SetDataSource(tblFK_KEIYAKU_KB.ExcludeDeleted, ENM_COMBO_SELECT_VALUE_TYPE._1_Filter)

                                _M106.ZUBAN_C = ""
                                mtxZUBAN_C.Enabled = False

                            Case Else

                        End Select
                    End Using
                    cmbKEIYAKU_KB.DataBindings.Add(New Binding(NameOf(cmbKEIYAKU_KB.SelectedValue), _M106, NameOf(_M106.KEIYAKU_KB), False, DataSourceUpdateMode.OnPropertyChanged, ""))

                    cmbBUMON_KB.Enabled = False


                    If _M106.COLOR_CD.Trim <> "" Then
                        C_R = CInt("&h" & _M106.COLOR_CD.Substring(1, 2))
                        C_G = CInt("&h" & _M106.COLOR_CD.Substring(3, 2))
                        C_B = CInt("&h" & _M106.COLOR_CD.Substring(5, 2))
                        lblSELECTED_COLOR.BackColor = Color.FromArgb(C_R, C_G, C_B)
                    End If

                    If PrDATA_OP_MODE = ENM_DATA_OPERATION_MODE._2_ADDREF Then
                        lblEDIT_YMDHNS.Visible = False
                        lbllblEDIT_SYAIN_ID.Visible = False
                        lblEDIT_SYAIN_ID.Visible = False
                    Else
                        cmbTOKUI_ID.Enabled = False
                        mtxBUHIN_BANGO.Enabled = False

                        lbllblEDIT_YMDHNS.Visible = True
                        lblEDIT_YMDHNS.Visible = True
                        lbllblEDIT_SYAIN_ID.Visible = True
                        lblEDIT_SYAIN_ID.Visible = True
                        '更新日時
                        If _M106.UPD_YMDHNS.ToString.Trim <> "" Then
                            lblEDIT_YMDHNS.Text = DateTime.ParseExact(PrDataRow.Item(NameOf(_M106.UPD_YMDHNS)), "yyyyMMddHHmmss", Nothing).ToString("yyyy/MM/dd HH:mm:ss")
                            '更新担当者CD
                            lblEDIT_SYAIN_ID.Text = PrDataRow.Item(NameOf(_M106.UPD_SYAIN_ID)) & " " & Fun_GetUSER_NAME(PrDataRow.Item(NameOf(_M106.UPD_SYAIN_ID)))
                        Else
                            lblEDIT_YMDHNS.Text = ""
                            lblEDIT_SYAIN_ID.Text = ""
                        End If


                    End If

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
    '入力チェック　メイン
    Public Function FunCheckInput() As Boolean

        Try
            IsValidated = True

            Call CmbBUMON_KB_Validating(cmbBUMON_KB, Nothing)
            Call CmbTOKUI_ID_Validating(cmbTOKUI_ID, Nothing)
            Call MtxBUHIN_BANGO_Validating(mtxBUHIN_BANGO, Nothing)

            Return IsValidated
        Catch ex As Exception
            EM.ErrorSyori(ex, False, conblnNonMsg)
            Return False
        End Try
    End Function

    '部門区分　入力チェック
    Private Sub CmbBUMON_KB_Validating(sender As Object, e As System.EventArgs) Handles cmbBUMON_KB.Validated
        Dim cmb As ComboboxEx = DirectCast(sender, ComboboxEx)

        If cmb.IsSelected Then
            ErrorProvider.ClearError(cmb)
            IsValidated = (IsValidated AndAlso True)

            '部門区分の選択時の処理
            Using DB As ClsDbUtility = DBOpen()

                cmbKEIYAKU_KB.DataBindings.Clear()

                Select Case cmbBUMON_KB.SelectedValue
                    Case ENM_BUMON_KB._1_風防
                        mtxBUHIN_NAME.Enabled = True

                        Call FunGetCodeDataTable(DB, "風防契約区分", tblKK_KEIYAKU_KB)
                        cmbKEIYAKU_KB.SetDataSource(tblKK_KEIYAKU_KB.ExcludeDeleted, ENM_COMBO_SELECT_VALUE_TYPE._1_Filter)
                        cmbKEIYAKU_KB.Enabled = True
                        _M106.ZUBAN_C = ""
                        mtxZUBAN_C.Enabled = False

                    Case ENM_BUMON_KB._2_LP
                        mtxBUHIN_NAME.Enabled = True

                        Call FunGetCodeDataTable(DB, "LP契約区分", tblLP_KEIYAKU_KB)
                        cmbKEIYAKU_KB.SetDataSource(tblLP_KEIYAKU_KB.ExcludeDeleted, ENM_COMBO_SELECT_VALUE_TYPE._1_Filter)
                        mtxZUBAN_C.Enabled = True

                    Case ENM_BUMON_KB._3_複合材
                        mtxBUHIN_NAME.Enabled = False
                        _M106.BUHIN_NAME = ""
                        Call FunGetCodeDataTable(DB, "複合材契約区分", tblFK_KEIYAKU_KB)
                        cmbKEIYAKU_KB.SetDataSource(tblFK_KEIYAKU_KB.ExcludeDeleted, ENM_COMBO_SELECT_VALUE_TYPE._1_Filter)

                        _M106.ZUBAN_C = ""
                        mtxZUBAN_C.Enabled = False

                    Case Else

                End Select

                cmbKEIYAKU_KB.DataBindings.Add(New Binding(NameOf(cmbKEIYAKU_KB.SelectedValue), _M106, NameOf(_M106.KEIYAKU_KB), False, DataSourceUpdateMode.OnPropertyChanged, ""))

                cmbKEIYAKU_KB.SelectedValue = _M106.KEIYAKU_KB
                'If PrDATA_OP_MODE = ENM_DATA_OPERATION_MODE._2_ADDREF Or PrDATA_OP_MODE = ENM_DATA_OPERATION_MODE._3_UPDATE Then
                '    cmbBUMON_KB.Enabled = False
                'End If

            End Using

        Else
            ErrorProvider.SetError(cmb, String.Format(My.Resources.infoMsgRequireSelectOrInput, "部門区分"), ErrorIconAlignment.MiddleLeft)
            IsValidated = False
        End If
    End Sub
    '得意先　入力チェック
    Private Sub CmbTOKUI_ID_Validating(sender As Object, e As System.ComponentModel.CancelEventArgs) Handles cmbTOKUI_ID.Validating
        Dim cmb As ComboboxEx = DirectCast(sender, ComboboxEx)

        If cmb.IsSelected Then
            ErrorProvider.ClearError(cmb)
            IsValidated = (IsValidated AndAlso True)
        Else
            ErrorProvider.SetError(cmb, String.Format(My.Resources.infoMsgRequireSelectOrInput, "得意先"), ErrorIconAlignment.MiddleLeft)
            IsValidated = False
        End If
    End Sub
    '部品番号　入力チェック
    Private Sub MtxBUHIN_BANGO_Validating(sender As Object, e As System.ComponentModel.CancelEventArgs) Handles mtxBUHIN_BANGO.Validating
        Dim mtx As MaskedTextBoxEx = DirectCast(sender, MaskedTextBoxEx)

        If mtx.Text.IsNullOrWhiteSpace = False Then
            ErrorProvider.ClearError(mtx)
            IsValidated = (IsValidated AndAlso True)
        Else
            ErrorProvider.SetError(mtx, String.Format(My.Resources.infoMsgRequireSelectOrInput, "部品番号"), ErrorIconAlignment.MiddleLeft)
            IsValidated = False
        End If
    End Sub

    '部品番号　入力チェック
    Private Sub MtxTANKA_Validating(sender As Object, e As System.ComponentModel.CancelEventArgs) Handles mtxTANKA.Validating
        Dim mtx As MaskedTextBoxEx = DirectCast(sender, MaskedTextBoxEx)

        If mtx.Text.IsNullOrWhiteSpace = False Then
            ErrorProvider.ClearError(mtx)
            IsValidated = (IsValidated AndAlso True)
        Else
            ErrorProvider.SetError(mtx, String.Format(My.Resources.infoMsgRequireSelectOrInput, "単価"), ErrorIconAlignment.MiddleLeft)
            IsValidated = False
        End If

    End Sub



#End Region

#End Region



End Class
