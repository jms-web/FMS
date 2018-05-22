Imports JMS_COMMON.ClsPubMethod

''' <summary>
''' 差戻し画面
''' </summary>
Public Class FrmG0016

#Region "変数・定数"
    '入力必須コントロール検証判定
    Private pri_blnValidated As Boolean
#End Region

#Region "プロパティ"
    Public Property PrSYONIN_HOKOKUSYO_ID As Integer

    Public Property PrCurrentStage As Integer

    Public Property PrHOKOKU_NO As String

#End Region

#Region "コンストラクタ"

    ''' <summary>
    ''' コンストラクタ
    ''' </summary>
    ''' <remarks>コンストラクタ</remarks>
    Public Sub New()

        ' この呼び出しはデザイナーで必要です。
        InitializeComponent()


        cmbMODOSI_SAKI.NullValue = 0
    End Sub

#End Region

#Region "FORMイベント"
    Private Sub Frm_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        Try
            '-----フォーム共通設定
            Call FunFormCommonSetting(pub_APP_INFO, pub_SYAIN_INFO)
            Me.Text = "差戻し登録"
            Me.lblTytle.Text = Me.Text

            '-----位置・サイズ
            Me.Height = 300
            Me.Width = 800
            Me.MinimumSize = New Size(800, 300)
            Me.Top = Me.Owner.Top + (Me.Owner.Height - Me.Height) / 2
            Me.Left = Me.Owner.Left + (Me.Owner.Width - Me.Width) / 2

            '-----ダイアログウィンドウ設定
            Me.FormBorderStyle = Windows.Forms.FormBorderStyle.FixedDialog
            Me.ControlBox = False

            '-----各コントロールのデータソースを設定
            Dim tbl As New DataTableEx
            Using DB As ClsDbUtility = DBOpen()
                Dim strWhere As String
                strWhere = "SYONIN_HOKOKUSYO_ID=" & PrSYONIN_HOKOKUSYO_ID & " AND HOKOKU_NO='" & PrHOKOKU_NO & "' AND (SYONIN_JUN=20 OR SYONIN_JUN<" & PrCurrentStage & ")"
                Call FunGetCodeDataTable(DB, "差戻し先", tbl, strWhere)
            End Using
            cmbMODOSI_SAKI.SetDataSource(tbl, ENM_COMBO_SELECT_VALUE_TYPE._0_Required)

            'バインディング
            Call FunSetBinding()
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
                Case 1  '
                    If FunCheckInput() Then

                        If FunSAVE() Then

                            Me.DialogResult = Windows.Forms.DialogResult.OK
                            Me.Close()
                        End If
                    End If
                Case 12 '戻る
                    Me.DialogResult = Windows.Forms.DialogResult.Cancel
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
        End Try
    End Sub

#End Region

#Region "更新"
    Private Function FunSAVE() As Boolean
        Dim dsList As New DataSet
        Dim sbSQL As New System.Text.StringBuilder

        Try
            '-----入力チェック
            If FunCheckInput() = False Then
                Return False
            End If

            'SPEC: 20-5.③.レコード更新
            Using DB As ClsDbUtility = DBOpen()
                Dim intRET As Integer
                Dim sqlEx As New Exception
                Dim blnErr As Boolean

                Try
                    '-----トランザクション
                    DB.BeginTransaction()

                    '-----UPDATE
                    sbSQL.Append("UPDATE " & NameOf(MODEL.D004_SYONIN_J_KANRI) & " SET")
                    sbSQL.Append(" " & NameOf(_D004_SYONIN_J_KANRI.SYONIN_YMDHNS) & "=' '")
                    sbSQL.Append(" ," & NameOf(_D004_SYONIN_J_KANRI.SYONIN_HANTEI_KB) & "='" & 0 & "'") '未承認
                    sbSQL.Append(" ," & NameOf(_D004_SYONIN_J_KANRI.SASIMODOSI_FG) & "='" & 1 & "'")
                    sbSQL.Append(" ," & NameOf(_D004_SYONIN_J_KANRI.RIYU) & "='" & _D004_SYONIN_J_KANRI.RIYU & "'")
                    sbSQL.Append(" ," & NameOf(_D004_SYONIN_J_KANRI.MAIL_SEND_FG) & "='" & 0 & "'")
                    sbSQL.Append(" ," & NameOf(_D004_SYONIN_J_KANRI.UPD_SYAIN_ID) & "=" & pub_SYAIN_INFO.SYAIN_ID & "")
                    sbSQL.Append(" ," & NameOf(_D004_SYONIN_J_KANRI.UPD_YMDHNS) & "=dbo.GetSysDateString()")
                    sbSQL.Append(" WHERE " & NameOf(_D004_SYONIN_J_KANRI.SYONIN_HOKOKUSYO_ID) & "=" & PrSYONIN_HOKOKUSYO_ID & "")
                    sbSQL.Append(" AND " & NameOf(_D004_SYONIN_J_KANRI.HOKOKU_NO) & "='" & _D003_NCR_J.HOKOKU_NO & "'")
                    sbSQL.Append(" AND " & NameOf(_D004_SYONIN_J_KANRI.SYONIN_JUN) & "=" & cmbMODOSI_SAKI.SelectedValue & "")
                    '-----SQL実行
                    intRET = DB.ExecuteNonQuery(sbSQL.ToString, conblnNonMsg, sqlEx)
                    If intRET <> 1 Then
                        '-----エラーログ出力
                        Dim strErrMsg As String = My.Resources.ErrLogSqlExecutionFailure & sbSQL.ToString & "|" & sqlEx.Message
                        WL.WriteLogDat(strErrMsg)
                        blnErr = True
                        Return False
                    End If

                    '-----差し戻されたステージ以降の承認済み実績を削除
                    sbSQL.Append("DELETE FROM" & NameOf(MODEL.D004_SYONIN_J_KANRI) & "")
                    sbSQL.Append(" WHERE " & NameOf(_D004_SYONIN_J_KANRI.SYONIN_JUN) & ">" & cmbMODOSI_SAKI.SelectedValue & "")
                    '-----SQL実行
                    intRET = DB.ExecuteNonQuery(sbSQL.ToString, conblnNonMsg, sqlEx)
                    If intRET <> 1 Then
                        '-----エラーログ出力
                        Dim strErrMsg As String = My.Resources.ErrLogSqlExecutionFailure & sbSQL.ToString & "|" & sqlEx.Message
                        WL.WriteLogDat(strErrMsg)
                        blnErr = True
                        Return False
                    End If

                    '-----データモデル更新
                    _R001_HOKOKU_SOUSA.SYONIN_HOKOKUSYO_ID = PrSYONIN_HOKOKUSYO_ID
                    _R001_HOKOKU_SOUSA.HOKOKU_NO = PrHOKOKU_NO
                    _R001_HOKOKU_SOUSA.SYONIN_JUN = PrCurrentStage
                    _R001_HOKOKU_SOUSA.SYAIN_ID = pub_SYAIN_INFO.SYAIN_ID
                    _R001_HOKOKU_SOUSA.SOUSA_KB = ENM_SOUSA_KB._3_承認差戻
                    _R001_HOKOKU_SOUSA.SYONIN_HANTEI_KB = ""
                    _R001_HOKOKU_SOUSA.RIYU = mtxMODOSI_RIYU.Text
                    _R001_HOKOKU_SOUSA.ADD_YMDHNS = Now.ToString("yyyyMMddHHmmss")
                    '-----INSERT R001
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
                    sbSQL.Append("  " & (_R001_HOKOKU_SOUSA.SYONIN_HOKOKUSYO_ID))
                    sbSQL.Append(" ,'" & (_R001_HOKOKU_SOUSA.HOKOKU_NO) & "'")
                    sbSQL.Append(" ,'" & (_R001_HOKOKU_SOUSA.ADD_YMDHNS) & "'")
                    sbSQL.Append(" ," & (_R001_HOKOKU_SOUSA.SYONIN_JUN))
                    sbSQL.Append(" ,'" & (_R001_HOKOKU_SOUSA.SOUSA_KB) & "'")
                    sbSQL.Append(" ," & (_R001_HOKOKU_SOUSA.SYAIN_ID))
                    sbSQL.Append(" ,'" & (_R001_HOKOKU_SOUSA.SYONIN_HANTEI_KB) & "'")
                    sbSQL.Append(" ,'" & (_R001_HOKOKU_SOUSA.RIYU) & "'")
                    sbSQL.Append(")")

                    '-----SQL実行
                    intRET = DB.ExecuteNonQuery(sbSQL.ToString, conblnNonMsg, sqlEx)
                    If intRET <> 1 Then
                        '-----エラーログ出力
                        Dim strErrMsg As String = My.Resources.ErrLogSqlExecutionFailure & sbSQL.ToString & "|" & sqlEx.Message
                        WL.WriteLogDat(strErrMsg)
                        Return False
                    End If

                    '差し戻し時履歴
                    Select Case PrSYONIN_HOKOKUSYO_ID
                        Case ENM_SYONIN_HOKOKUSYO_ID._1_NCR
                            If FunSAVE_R003(DB, _R001_HOKOKU_SOUSA.ADD_YMDHNS) Then
                            Else
                                Return False
                            End If
                        Case ENM_SYONIN_HOKOKUSYO_ID._2_CAR
                            'UNDONE: FunSAVE_R004
                            If FunSAVE_R003(DB, _R001_HOKOKU_SOUSA.ADD_YMDHNS) Then
                            Else
                                Return False
                            End If
                        Case Else
                            Throw New ArgumentException()
                    End Select


                Finally
                    '-----トランザクション
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

    Private Function FunSAVE_R003(ByRef DB As ClsDbUtility, ByVal strYMDHNS As String) As Boolean
        Dim sbSQL As New System.Text.StringBuilder
        Dim strRET As String
        Dim sqlEx As New Exception

        '-----MERGE
        sbSQL.Append(" INSERT INTO " & NameOf(MODEL.R003_NCR_SASIMODOSI) & "(")
        sbSQL.Append(" " & NameOf(_R003_NCR_SASIMODOSI.SASIMODOSI_YMDHNS))
        sbSQL.Append(" ," & NameOf(_D003_NCR_J.HOKOKU_NO))
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
        sbSQL.Append(" '" & strYMDHNS & "'")
        sbSQL.Append(" ,'" & _D003_NCR_J.HOKOKU_NO & "'")
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
        sbSQL.Append(" );")
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

        Return True
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
                Dim cmd As Button = DirectCast(Me.Controls.Find("cmdFunc" & intFunc, True)(0), Button)
                With cmd
                    If cmd IsNot Nothing AndAlso .Text.Length = 0 OrElse .Text.Substring(0, .Text.IndexOf("(")).IsNullOrWhiteSpace Then
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

#End Region

#Region "コントロールイベント"

    '差し戻し先
    Private Sub CmbMODOSI_SAKI_SelectedValueChanged(sender As Object, e As EventArgs) Handles cmbMODOSI_SAKI.SelectedValueChanged
        Dim cmb As ComboboxEx = DirectCast(sender, ComboboxEx)

        'SPEC: 20-5.②
        If cmb.SelectedValue = cmb.NullValue Then
            mtxTANTO_NAME.Text = ""
        Else
            mtxTANTO_NAME.Text = DirectCast(cmbMODOSI_SAKI.DataSource, DataTable).AsEnumerable.Where(Function(r) r.Field(Of Integer)("VALUE") = cmb.SelectedValue).First.Item("SYAIN_NAME")
        End If

    End Sub

    Private Sub CmbMODOSI_SAKI_Validating(sender As Object, e As System.ComponentModel.CancelEventArgs) Handles cmbMODOSI_SAKI.Validating
        Dim cmb As ComboboxEx = DirectCast(sender, ComboboxEx)

        If cmb.SelectedValue Is Nothing And cmb.Text.IsNullOrWhiteSpace = True Then
            'e.Cancel = True
            ErrorProvider.SetError(cmb, String.Format(My.Resources.infoMsgRequireSelectOrInput, "差戻し先"))
            ErrorProvider.SetIconAlignment(cmb, ErrorIconAlignment.MiddleLeft)
            pri_blnValidated = False
        Else
            ErrorProvider.ClearError(cmb)
            pri_blnValidated = True
        End If
    End Sub

    Private Sub MtxMODOSI_RIYU_Validating(sender As Object, e As System.ComponentModel.CancelEventArgs) Handles mtxMODOSI_RIYU.Validating
        Dim mtx As MaskedTextBoxEx = DirectCast(sender, MaskedTextBoxEx)

        If mtx.Text.IsNullOrWhiteSpace = True Then
            'e.Cancel = True
            ErrorProvider.SetError(mtx, String.Format(My.Resources.infoMsgRequireSelectOrInput, "差戻し理由"))
            ErrorProvider.SetIconAlignment(mtx, ErrorIconAlignment.MiddleLeft)
            pri_blnValidated = False
        Else
            ErrorProvider.ClearError(mtx)
            pri_blnValidated = True
        End If
    End Sub

#End Region

#Region "入力チェック"
    Public Function FunCheckInput() As Boolean
        Try
            Call CmbMODOSI_SAKI_Validating(cmbMODOSI_SAKI, Nothing)
            Call MtxMODOSI_RIYU_Validating(mtxMODOSI_RIYU, Nothing)

            Return pri_blnValidated
        Catch ex As Exception
            EM.ErrorSyori(ex, False, conblnNonMsg)
            Return False
        End Try
    End Function

#End Region

#Region "ローカル関数"
    Private Function FunSetBinding() As Boolean
        'cmbMODOSI_SAKI.DataBindings.Add(New Binding(NameOf(cmbMODOSI_SAKI.SelectedValue), _D003_NCR_J, NameOf(_D004_SYONIN_J_KANRI.SYAIN_ID)))
        mtxMODOSI_RIYU.DataBindings.Add(New Binding(NameOf(mtxMODOSI_RIYU.Text), _D004_SYONIN_J_KANRI, NameOf(_D004_SYONIN_J_KANRI.RIYU), False, DataSourceUpdateMode.OnPropertyChanged, ""))
    End Function




#End Region


End Class
