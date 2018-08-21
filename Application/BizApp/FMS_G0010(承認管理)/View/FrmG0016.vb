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

        Me.Icon = My.Resources._icoAppForm32x32
        Me.ShowIcon = True
        cmbMODOSI_SAKI.NullValue = 0
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
            Me.Height = 300
            Me.Width = 800
            Me.MinimumSize = New Size(800, 300)
            Me.Top = Me.Owner.Top + (Me.Owner.Height - Me.Height) / 2
            Me.Left = Me.Owner.Left + (Me.Owner.Width - Me.Width) / 2

            '-----ダイアログウィンドウ設定
            Me.FormBorderStyle = Windows.Forms.FormBorderStyle.FixedDialog
            Me.ControlBox = False

            '-----各コントロールのデータソースを設定

            cmbMODOSI_SAKI.SetDataSource(FunGetMODISI_SAKI(PrSYONIN_HOKOKUSYO_ID, PrHOKOKU_NO, PrCurrentStage), ENM_COMBO_SELECT_VALUE_TYPE._0_Required)

            _D004_SYONIN_J_KANRI.RIYU = ""

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

            'SPEC: 20-5.�B.レコード更新
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
                    sbSQL.Append(" ," & NameOf(_D004_SYONIN_J_KANRI.SYAIN_ID) & "=" & mtxTANTO_ID.Text & "")
                    sbSQL.Append(" ," & NameOf(_D004_SYONIN_J_KANRI.UPD_SYAIN_ID) & "=" & pub_SYAIN_INFO.SYAIN_ID & "") '
                    sbSQL.Append(" ," & NameOf(_D004_SYONIN_J_KANRI.UPD_YMDHNS) & "=dbo.GetSysDateString()")
                    sbSQL.Append(" WHERE " & NameOf(_D004_SYONIN_J_KANRI.SYONIN_HOKOKUSYO_ID) & "=" & PrSYONIN_HOKOKUSYO_ID & "")
                    sbSQL.Append(" AND " & NameOf(_D004_SYONIN_J_KANRI.HOKOKU_NO) & "='" & PrHOKOKU_NO & "'")
                    sbSQL.Append(" AND " & NameOf(_D004_SYONIN_J_KANRI.SYONIN_JUN) & "=" & cmbMODOSI_SAKI.SelectedValue & "")

                    intRET = DB.ExecuteNonQuery(sbSQL.ToString, conblnNonMsg, sqlEx)
                    If intRET <> 1 Then
                        Dim strErrMsg As String = My.Resources.ErrLogSqlExecutionFailure & sbSQL.ToString & "|" & sqlEx.Message
                        WL.WriteLogDat(strErrMsg)
                        blnErr = True
                        Return False
                    End If

                    '-----差し戻されたステージ以降の承認済み実績を削除
                    sbSQL.Remove(0, sbSQL.Length)
                    sbSQL.Append("DELETE FROM " & NameOf(MODEL.D004_SYONIN_J_KANRI) & "")
                    sbSQL.Append(" WHERE " & NameOf(_D004_SYONIN_J_KANRI.SYONIN_HOKOKUSYO_ID) & "=" & PrSYONIN_HOKOKUSYO_ID & "")
                    sbSQL.Append(" AND RTRIM(" & NameOf(_D004_SYONIN_J_KANRI.HOKOKU_NO) & ")='" & PrHOKOKU_NO & "'")
                    sbSQL.Append(" AND " & NameOf(_D004_SYONIN_J_KANRI.SYONIN_JUN) & ">" & cmbMODOSI_SAKI.SelectedValue & ";")

                    intRET = DB.ExecuteNonQuery(sbSQL.ToString, conblnNonMsg, sqlEx)
                    If sqlEx.Source IsNot Nothing Then

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
                        blnErr = True
                        Return False
                    End If

                    '差し戻し時履歴
                    Select Case PrSYONIN_HOKOKUSYO_ID
                        Case Context.ENM_SYONIN_HOKOKUSYO_ID._1_NCR
                            If FunSAVE_R003(DB, _R001_HOKOKU_SOUSA.ADD_YMDHNS) Then
                            Else
                                blnErr = True
                                Return False
                            End If
                        Case Context.ENM_SYONIN_HOKOKUSYO_ID._2_CAR

                            If FunSAVE_R004(DB, _R001_HOKOKU_SOUSA.ADD_YMDHNS) Then
                            Else
                                blnErr = True
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
        Dim intRET As Integer
        Dim sqlEx As New Exception

        '-----MERGE
        sbSQL.Append(" INSERT INTO " & NameOf(MODEL.R003_NCR_SASIMODOSI) & "(")
        sbSQL.Append(" " & NameOf(_R003_NCR_SASIMODOSI.SASIMODOSI_YMDHNS))
        sbSQL.Append(" ," & NameOf(_R003_NCR_SASIMODOSI.HOKOKU_NO))
        sbSQL.Append(" ," & NameOf(_R003_NCR_SASIMODOSI.BUMON_KB))
        sbSQL.Append(" ," & NameOf(_R003_NCR_SASIMODOSI.CLOSE_FG))
        sbSQL.Append(" ," & NameOf(_R003_NCR_SASIMODOSI.KISYU_ID))
        sbSQL.Append(" ," & NameOf(_R003_NCR_SASIMODOSI.SYANAI_CD))
        sbSQL.Append(" ," & NameOf(_R003_NCR_SASIMODOSI.BUHIN_BANGO))
        sbSQL.Append(" ," & NameOf(_R003_NCR_SASIMODOSI.BUHIN_NAME))
        sbSQL.Append(" ," & NameOf(_R003_NCR_SASIMODOSI.GOKI))
        sbSQL.Append(" ," & NameOf(_R003_NCR_SASIMODOSI.SURYO))
        sbSQL.Append(" ," & NameOf(_R003_NCR_SASIMODOSI.SAIHATU))
        sbSQL.Append(" ," & NameOf(_R003_NCR_SASIMODOSI.FUTEKIGO_JYOTAI_KB))
        sbSQL.Append(" ," & NameOf(_R003_NCR_SASIMODOSI.FUTEKIGO_NAIYO))
        sbSQL.Append(" ," & NameOf(_R003_NCR_SASIMODOSI.FUTEKIGO_KB))
        sbSQL.Append(" ," & NameOf(_R003_NCR_SASIMODOSI.FUTEKIGO_S_KB))
        sbSQL.Append(" ," & NameOf(_R003_NCR_SASIMODOSI.ZUMEN_KIKAKU))
        sbSQL.Append(" ," & NameOf(_R003_NCR_SASIMODOSI.YOKYU_NAIYO))
        sbSQL.Append(" ," & NameOf(_R003_NCR_SASIMODOSI.KANSATU_KEKKA))
        sbSQL.Append(" ," & NameOf(_R003_NCR_SASIMODOSI.ZESEI_SYOCHI_YOHI_KB))
        sbSQL.Append(" ," & NameOf(_R003_NCR_SASIMODOSI.ZESEI_NASI_RIYU))
        sbSQL.Append(" ," & NameOf(_R003_NCR_SASIMODOSI.JIZEN_SINSA_HANTEI_KB))
        sbSQL.Append(" ," & NameOf(_R003_NCR_SASIMODOSI.JIZEN_SINSA_SYAIN_ID))
        sbSQL.Append(" ," & NameOf(_R003_NCR_SASIMODOSI.JIZEN_SINSA_YMD))
        sbSQL.Append(" ," & NameOf(_R003_NCR_SASIMODOSI.SAISIN_KAKUNIN_SYAIN_ID))
        sbSQL.Append(" ," & NameOf(_R003_NCR_SASIMODOSI.SAISIN_KAKUNIN_YMD))
        sbSQL.Append(" ," & NameOf(_R003_NCR_SASIMODOSI.SAISIN_IINKAI_HANTEI_KB))
        sbSQL.Append(" ," & NameOf(_R003_NCR_SASIMODOSI.SAISIN_GIJYUTU_SYAIN_ID))
        sbSQL.Append(" ," & NameOf(_R003_NCR_SASIMODOSI.SAISIN_GIJYUTU_YMD))
        sbSQL.Append(" ," & NameOf(_R003_NCR_SASIMODOSI.SAISIN_HINSYO_SYAIN_ID))
        sbSQL.Append(" ," & NameOf(_R003_NCR_SASIMODOSI.SAISIN_HINSYO_YMD))
        sbSQL.Append(" ," & NameOf(_R003_NCR_SASIMODOSI.SAISIN_IINKAI_SIRYO_NO))
        sbSQL.Append(" ," & NameOf(_R003_NCR_SASIMODOSI.ITAG_NO))
        sbSQL.Append(" ," & NameOf(_R003_NCR_SASIMODOSI.KOKYAKU_SAISIN_TANTO_ID))
        sbSQL.Append(" ," & NameOf(_R003_NCR_SASIMODOSI.KOKYAKU_SAISIN_YMD))
        sbSQL.Append(" ," & NameOf(_R003_NCR_SASIMODOSI.KOKYAKU_HANTEI_SIJI_KB))
        sbSQL.Append(" ," & NameOf(_R003_NCR_SASIMODOSI.KOKYAKU_HANTEI_SIJI_YMD))
        sbSQL.Append(" ," & NameOf(_R003_NCR_SASIMODOSI.KOKYAKU_SAISYU_HANTEI_KB))
        sbSQL.Append(" ," & NameOf(_R003_NCR_SASIMODOSI.KOKYAKU_SAISYU_HANTEI_YMD))
        sbSQL.Append(" ," & NameOf(_R003_NCR_SASIMODOSI.SAIKAKO_SIJI_FG))
        sbSQL.Append(" ," & NameOf(_R003_NCR_SASIMODOSI.HAIKYAKU_YMD))
        sbSQL.Append(" ," & NameOf(_R003_NCR_SASIMODOSI.HAIKYAKU_KB))
        sbSQL.Append(" ," & NameOf(_R003_NCR_SASIMODOSI.HAIKYAKU_HOUHOU))
        sbSQL.Append(" ," & NameOf(_R003_NCR_SASIMODOSI.HAIKYAKU_TANTO_ID))
        sbSQL.Append(" ," & NameOf(_R003_NCR_SASIMODOSI.SAIKAKO_SIJI_NO))
        sbSQL.Append(" ," & NameOf(_R003_NCR_SASIMODOSI.SAIKAKO_SAGYO_KAN_YMD))
        sbSQL.Append(" ," & NameOf(_R003_NCR_SASIMODOSI.SAIKAKO_KENSA_YMD))
        sbSQL.Append(" ," & NameOf(_R003_NCR_SASIMODOSI.KENSA_KEKKA_KB))
        sbSQL.Append(" ," & NameOf(_R003_NCR_SASIMODOSI.SEIGI_TANTO_ID))
        sbSQL.Append(" ," & NameOf(_R003_NCR_SASIMODOSI.SEIZO_TANTO_ID))
        sbSQL.Append(" ," & NameOf(_R003_NCR_SASIMODOSI.KENSA_TANTO_ID))
        sbSQL.Append(" ," & NameOf(_R003_NCR_SASIMODOSI.HENKYAKU_YMD))
        sbSQL.Append(" ," & NameOf(_R003_NCR_SASIMODOSI.HENKYAKU_SAKI))
        sbSQL.Append(" ," & NameOf(_R003_NCR_SASIMODOSI.HENKYAKU_TANTO_ID))
        sbSQL.Append(" ," & NameOf(_R003_NCR_SASIMODOSI.HENKYAKU_BIKO))
        sbSQL.Append(" ," & NameOf(_R003_NCR_SASIMODOSI.TENYO_KISYU_ID))
        sbSQL.Append(" ," & NameOf(_R003_NCR_SASIMODOSI.TENYO_BUHIN_BANGO))
        sbSQL.Append(" ," & NameOf(_R003_NCR_SASIMODOSI.TENYO_GOKI))
        sbSQL.Append(" ," & NameOf(_R003_NCR_SASIMODOSI.TENYO_LOT))
        sbSQL.Append(" ," & NameOf(_R003_NCR_SASIMODOSI.TENYO_YMD))
        sbSQL.Append(" ," & NameOf(_R003_NCR_SASIMODOSI.SYOCHI_KEKKA_A))
        sbSQL.Append(" ," & NameOf(_R003_NCR_SASIMODOSI.SYOCHI_KEKKA_B))
        sbSQL.Append(" ," & NameOf(_R003_NCR_SASIMODOSI.SYOCHI_KEKKA_C))
        sbSQL.Append(" ," & NameOf(_R003_NCR_SASIMODOSI.SYOCHI_D_UMU_KB))
        sbSQL.Append(" ," & NameOf(_R003_NCR_SASIMODOSI.SYOCHI_D_YOHI_KB))
        sbSQL.Append(" ," & NameOf(_R003_NCR_SASIMODOSI.SYOCHI_D_SYOCHI_KIROKU))
        sbSQL.Append(" ," & NameOf(_R003_NCR_SASIMODOSI.SYOCHI_E_UMU_KB))
        sbSQL.Append(" ," & NameOf(_R003_NCR_SASIMODOSI.SYOCHI_E_YOHI_KB))
        sbSQL.Append(" ," & NameOf(_R003_NCR_SASIMODOSI.SYOCHI_E_SYOCHI_KIROKU))
        sbSQL.Append(" ," & NameOf(_R003_NCR_SASIMODOSI.FILE_PATH))
        sbSQL.Append(" ," & NameOf(_R003_NCR_SASIMODOSI.G_FILE_PATH1))
        sbSQL.Append(" ," & NameOf(_R003_NCR_SASIMODOSI.G_FILE_PATH2))
        sbSQL.Append(" ," & NameOf(_R003_NCR_SASIMODOSI.HASSEI_KOTEI_GL_SYAIN_ID))
        sbSQL.Append(" ) VALUES(")
        sbSQL.Append(" '" & strYMDHNS & "'")
        sbSQL.Append(" ,'" & _D003_NCR_J.HOKOKU_NO & "'")
        sbSQL.Append(" ,'" & _D003_NCR_J.BUMON_KB & "'")
        sbSQL.Append(" ,'" & _D003_NCR_J._CLOSE_FG & "'")
        sbSQL.Append(" ," & _D003_NCR_J.KISYU_ID & "")
        sbSQL.Append(" ,'" & _D003_NCR_J.SYANAI_CD & "'")
        sbSQL.Append(" ,'" & _D003_NCR_J.BUHIN_BANGO & "'")
        sbSQL.Append(" ,'" & _D003_NCR_J.BUHIN_NAME & "'")
        sbSQL.Append(" ,'" & _D003_NCR_J.GOKI & "'")
        sbSQL.Append(" ," & _D003_NCR_J.SURYO & "")
        sbSQL.Append(" ,'" & _D003_NCR_J._SAIHATU & "'")
        sbSQL.Append(" ,'" & _D003_NCR_J.FUTEKIGO_JYOTAI_KB & "'")
        sbSQL.Append(" ,'" & _D003_NCR_J.FUTEKIGO_NAIYO & "'")
        sbSQL.Append(" ,'" & _D003_NCR_J.FUTEKIGO_KB & "'")
        sbSQL.Append(" ,'" & _D003_NCR_J.FUTEKIGO_S_KB & "'")
        sbSQL.Append(" ,'" & _D003_NCR_J.ZUMEN_KIKAKU & "'")
        sbSQL.Append(" ,'" & _D003_NCR_J.YOKYU_NAIYO & "'")
        sbSQL.Append(" ,'" & _D003_NCR_J.KANSATU_KEKKA & "'")
        sbSQL.Append(" ,'" & _D003_NCR_J._ZESEI_SYOCHI_YOHI_KB & "'")
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
        sbSQL.Append(" ,'" & _D003_NCR_J._SAIKAKO_SIJI_FG & "'")
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
        sbSQL.Append(" ," & _D003_NCR_J.TENYO_LOT & "")
        sbSQL.Append(" ,'" & _D003_NCR_J.TENYO_YMD & "'")
        sbSQL.Append(" ,'" & _D003_NCR_J._SYOCHI_KEKKA_A & "'")
        sbSQL.Append(" ,'" & _D003_NCR_J._SYOCHI_KEKKA_B & "'")
        sbSQL.Append(" ,'" & _D003_NCR_J._SYOCHI_KEKKA_C & "'")
        sbSQL.Append(" ,'" & _D003_NCR_J._SYOCHI_D_UMU_KB & "'")
        sbSQL.Append(" ,'" & _D003_NCR_J._SYOCHI_D_YOHI_KB & "'")
        sbSQL.Append(" ,'" & _D003_NCR_J.SYOCHI_D_SYOCHI_KIROKU & "'")
        sbSQL.Append(" ,'" & _D003_NCR_J._SYOCHI_E_UMU_KB & "'")
        sbSQL.Append(" ,'" & _D003_NCR_J._SYOCHI_E_YOHI_KB & "'")
        sbSQL.Append(" ,'" & _D003_NCR_J.SYOCHI_E_SYOCHI_KIROKU & "'")
        sbSQL.Append(" ,'" & _D003_NCR_J.FILE_PATH & "'")
        sbSQL.Append(" ,'" & _D003_NCR_J.G_FILE_PATH1 & "'")
        sbSQL.Append(" ,'" & _D003_NCR_J.G_FILE_PATH2 & "'")
        sbSQL.Append(" ,'" & _D003_NCR_J.HASSEI_KOTEI_GL_SYAIN_ID & "'")
        sbSQL.Append(" );")
        intRET = DB.ExecuteNonQuery(sbSQL.ToString, conblnNonMsg, sqlEx)
        If intRET <> 1 Then
            '-----エラーログ出力
            Dim strErrMsg As String = My.Resources.ErrLogSqlExecutionFailure & sbSQL.ToString & "|" & sqlEx.Message
            WL.WriteLogDat(strErrMsg)
            Return False
        Else
            Return True
        End If
    End Function

    Private Function FunSAVE_R004(ByRef DB As ClsDbUtility, ByVal strYMDHNS As String) As Boolean
        Dim sbSQL As New System.Text.StringBuilder
        Dim intRET As Integer
        Dim sqlEx As New Exception

        '-----MERGE
        sbSQL.Append(" INSERT INTO " & NameOf(MODEL.R004_CAR_SASIMODOSI) & "(")
        sbSQL.Append(" " & NameOf(_R004_CAR_SASIMODOSI.SASIMODOSI_YMDHNS))
        sbSQL.Append(" ," & NameOf(_R004_CAR_SASIMODOSI.HOKOKU_NO))
        sbSQL.Append(" ," & NameOf(_R004_CAR_SASIMODOSI.BUMON_KB))
        sbSQL.Append(" ," & NameOf(_R004_CAR_SASIMODOSI.CLOSE_FG))
        sbSQL.Append(" ," & NameOf(_R004_CAR_SASIMODOSI.SETUMON_1))
        sbSQL.Append(" ," & NameOf(_R004_CAR_SASIMODOSI.SETUMON_2))
        sbSQL.Append(" ," & NameOf(_R004_CAR_SASIMODOSI.SETUMON_3))
        sbSQL.Append(" ," & NameOf(_R004_CAR_SASIMODOSI.SETUMON_4))
        sbSQL.Append(" ," & NameOf(_R004_CAR_SASIMODOSI.SETUMON_5))
        sbSQL.Append(" ," & NameOf(_R004_CAR_SASIMODOSI.SETUMON_6))
        sbSQL.Append(" ," & NameOf(_R004_CAR_SASIMODOSI.SETUMON_7))
        sbSQL.Append(" ," & NameOf(_R004_CAR_SASIMODOSI.SETUMON_8))
        sbSQL.Append(" ," & NameOf(_R004_CAR_SASIMODOSI.SETUMON_9))
        sbSQL.Append(" ," & NameOf(_R004_CAR_SASIMODOSI.SETUMON_10))
        sbSQL.Append(" ," & NameOf(_R004_CAR_SASIMODOSI.SETUMON_11))
        sbSQL.Append(" ," & NameOf(_R004_CAR_SASIMODOSI.SETUMON_12))
        sbSQL.Append(" ," & NameOf(_R004_CAR_SASIMODOSI.SETUMON_13))
        sbSQL.Append(" ," & NameOf(_R004_CAR_SASIMODOSI.SETUMON_14))
        sbSQL.Append(" ," & NameOf(_R004_CAR_SASIMODOSI.SETUMON_15))
        sbSQL.Append(" ," & NameOf(_R004_CAR_SASIMODOSI.SETUMON_16))
        sbSQL.Append(" ," & NameOf(_R004_CAR_SASIMODOSI.SETUMON_17))
        sbSQL.Append(" ," & NameOf(_R004_CAR_SASIMODOSI.SETUMON_18))
        sbSQL.Append(" ," & NameOf(_R004_CAR_SASIMODOSI.SETUMON_19))
        sbSQL.Append(" ," & NameOf(_R004_CAR_SASIMODOSI.SETUMON_20))
        sbSQL.Append(" ," & NameOf(_R004_CAR_SASIMODOSI.SETUMON_21))
        sbSQL.Append(" ," & NameOf(_R004_CAR_SASIMODOSI.SETUMON_22))
        sbSQL.Append(" ," & NameOf(_R004_CAR_SASIMODOSI.SETUMON_23))
        sbSQL.Append(" ," & NameOf(_R004_CAR_SASIMODOSI.SETUMON_24))
        sbSQL.Append(" ," & NameOf(_R004_CAR_SASIMODOSI.SETUMON_25))
        sbSQL.Append(" ," & NameOf(_R004_CAR_SASIMODOSI.KAITO_1))
        sbSQL.Append(" ," & NameOf(_R004_CAR_SASIMODOSI.KAITO_2))
        sbSQL.Append(" ," & NameOf(_R004_CAR_SASIMODOSI.KAITO_3))
        sbSQL.Append(" ," & NameOf(_R004_CAR_SASIMODOSI.KAITO_4))
        sbSQL.Append(" ," & NameOf(_R004_CAR_SASIMODOSI.KAITO_5))
        sbSQL.Append(" ," & NameOf(_R004_CAR_SASIMODOSI.KAITO_6))
        sbSQL.Append(" ," & NameOf(_R004_CAR_SASIMODOSI.KAITO_7))
        sbSQL.Append(" ," & NameOf(_R004_CAR_SASIMODOSI.KAITO_8))
        sbSQL.Append(" ," & NameOf(_R004_CAR_SASIMODOSI.KAITO_9))
        sbSQL.Append(" ," & NameOf(_R004_CAR_SASIMODOSI.KAITO_10))
        sbSQL.Append(" ," & NameOf(_R004_CAR_SASIMODOSI.KAITO_11))
        sbSQL.Append(" ," & NameOf(_R004_CAR_SASIMODOSI.KAITO_12))
        sbSQL.Append(" ," & NameOf(_R004_CAR_SASIMODOSI.KAITO_13))
        sbSQL.Append(" ," & NameOf(_R004_CAR_SASIMODOSI.KAITO_14))
        sbSQL.Append(" ," & NameOf(_R004_CAR_SASIMODOSI.KAITO_15))
        sbSQL.Append(" ," & NameOf(_R004_CAR_SASIMODOSI.KAITO_16))
        sbSQL.Append(" ," & NameOf(_R004_CAR_SASIMODOSI.KAITO_17))
        sbSQL.Append(" ," & NameOf(_R004_CAR_SASIMODOSI.KAITO_18))
        sbSQL.Append(" ," & NameOf(_R004_CAR_SASIMODOSI.KAITO_19))
        sbSQL.Append(" ," & NameOf(_R004_CAR_SASIMODOSI.KAITO_20))
        sbSQL.Append(" ," & NameOf(_R004_CAR_SASIMODOSI.KAITO_21))
        sbSQL.Append(" ," & NameOf(_R004_CAR_SASIMODOSI.KAITO_22))
        sbSQL.Append(" ," & NameOf(_R004_CAR_SASIMODOSI.KAITO_23))
        sbSQL.Append(" ," & NameOf(_R004_CAR_SASIMODOSI.KAITO_24))
        sbSQL.Append(" ," & NameOf(_R004_CAR_SASIMODOSI.KAITO_25))
        sbSQL.Append(" ," & NameOf(_R004_CAR_SASIMODOSI.KONPON_YOIN_KB1))
        sbSQL.Append(" ," & NameOf(_R004_CAR_SASIMODOSI.KONPON_YOIN_KB2))
        sbSQL.Append(" ," & NameOf(_R004_CAR_SASIMODOSI.KONPON_YOIN_SYAIN_ID))
        sbSQL.Append(" ," & NameOf(_R004_CAR_SASIMODOSI.KISEKI_KOTEI_KB))
        sbSQL.Append(" ," & NameOf(_R004_CAR_SASIMODOSI.SYOCHI_A_SYAIN_ID))
        sbSQL.Append(" ," & NameOf(_R004_CAR_SASIMODOSI.SYOCHI_A_YMDHNS))
        sbSQL.Append(" ," & NameOf(_R004_CAR_SASIMODOSI.SYOCHI_B_SYAIN_ID))
        sbSQL.Append(" ," & NameOf(_R004_CAR_SASIMODOSI.SYOCHI_B_YMDHNS))
        sbSQL.Append(" ," & NameOf(_R004_CAR_SASIMODOSI.SYOCHI_C_SYAIN_ID))
        sbSQL.Append(" ," & NameOf(_R004_CAR_SASIMODOSI.SYOCHI_C_YMDHNS))
        sbSQL.Append(" ," & NameOf(_R004_CAR_SASIMODOSI.KYOIKU_FILE_PATH))
        sbSQL.Append(" ," & NameOf(_R004_CAR_SASIMODOSI.ZESEI_SYOCHI_YUKO_UMU))
        sbSQL.Append(" ," & NameOf(_R004_CAR_SASIMODOSI.SYOSAI_FILE_PATH))
        sbSQL.Append(" ," & NameOf(_R004_CAR_SASIMODOSI.GOKI))
        sbSQL.Append(" ," & NameOf(_R004_CAR_SASIMODOSI.LOT))
        sbSQL.Append(" ," & NameOf(_R004_CAR_SASIMODOSI.KENSA_TANTO_ID))
        sbSQL.Append(" ," & NameOf(_R004_CAR_SASIMODOSI.KENSA_TOROKU_YMDHNS))
        sbSQL.Append(" ," & NameOf(_R004_CAR_SASIMODOSI.KENSA_GL_SYAIN_ID))
        sbSQL.Append(" ," & NameOf(_R004_CAR_SASIMODOSI.KENSA_GL_YMDHNS))
        sbSQL.Append(" ," & NameOf(_R004_CAR_SASIMODOSI.FILE_PATH1))
        sbSQL.Append(" ," & NameOf(_R004_CAR_SASIMODOSI.FILE_PATH2))
        sbSQL.Append(" ," & NameOf(_R004_CAR_SASIMODOSI.FUTEKIGO_HASSEI_YMD))
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
        sbSQL.Append(" );")
        intRET = DB.ExecuteNonQuery(sbSQL.ToString, conblnNonMsg, sqlEx)
        If intRET <> 1 Then
            '-----エラーログ出力
            Dim strErrMsg As String = My.Resources.ErrLogSqlExecutionFailure & sbSQL.ToString & "|" & sqlEx.Message
            WL.WriteLogDat(strErrMsg)
            Return False
        Else
            Return True
        End If
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

        'SPEC: 20-5.�A
        If cmb.SelectedValue = cmb.NullValue Then
            mtxTANTO_ID.Text = ""
            mtxTANTO_NAME.Text = ""
        Else
            mtxTANTO_NAME.Text = DirectCast(cmbMODOSI_SAKI.DataSource, DataTable).AsEnumerable.Where(Function(r) r.Field(Of Integer)("VALUE") = cmb.SelectedValue).First.Item("SYAIN_NAME")
            mtxTANTO_ID.Text = DirectCast(cmbMODOSI_SAKI.DataSource, DataTable).AsEnumerable.Where(Function(r) r.Field(Of Integer)("VALUE") = cmb.SelectedValue).First.Item("SYAIN_ID")
        End If

    End Sub

    Private Sub CmbMODOSI_SAKI_Validating(sender As Object, e As System.ComponentModel.CancelEventArgs) Handles cmbMODOSI_SAKI.Validating
        Dim cmb As ComboboxEx = DirectCast(sender, ComboboxEx)

        If cmb.Selected Then
            ErrorProvider.ClearError(cmb)
            pri_blnValidated = pri_blnValidated AndAlso True
        Else
            ErrorProvider.SetError(cmb, String.Format(My.Resources.infoMsgRequireSelectOrInput, "差戻し先"))
            ErrorProvider.SetIconAlignment(cmb, ErrorIconAlignment.MiddleLeft)
            pri_blnValidated = False
        End If
    End Sub

    Private Sub MtxMODOSI_RIYU_Validating(sender As Object, e As System.ComponentModel.CancelEventArgs) Handles mtxMODOSI_RIYU.Validating
        Dim mtx As MaskedTextBoxEx = DirectCast(sender, MaskedTextBoxEx)

        If Not mtx.Text.IsNullOrWhiteSpace Then
            ErrorProvider.ClearError(mtx)
            pri_blnValidated = pri_blnValidated AndAlso True
        Else
            ErrorProvider.SetError(mtx, String.Format(My.Resources.infoMsgRequireSelectOrInput, "差戻し理由"))
            ErrorProvider.SetIconAlignment(mtx, ErrorIconAlignment.MiddleLeft)
            pri_blnValidated = False
        End If
    End Sub

#End Region

#Region "入力チェック"
    Public Function FunCheckInput() As Boolean
        Try
            pri_blnValidated = True
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

    Private Function FunGetMODISI_SAKI(ByVal intSYONIN_HOKOKU_ID As Integer, ByVal strHOKOKU_NO As String, ByVal intCurrentStage As Integer) As DataTable
        Dim dt As New DataTableEx("System.Int32")
        Dim sbSQL As New System.Text.StringBuilder
        Dim dsList As New DataSet

        sbSQL.Append($"SELECT * FROM {NameOf(MODEL.V003_SYONIN_J_KANRI)} MAIN")
        sbSQL.Append($" WHERE SYONIN_HOKOKUSYO_ID={intSYONIN_HOKOKU_ID}")
        sbSQL.Append($" AND HOKOKU_NO='{strHOKOKU_NO}'")
        'カレントステージが20以外の場合は差し戻し先として20も追加
        If intCurrentStage = 20 Then
            sbSQL.Append($" AND (SYONIN_JUN=(SELECT MAX(SYONIN_JUN) FROM V003_SYONIN_J_KANRI AS SUB WHERE SUB.SYONIN_JUN<{intCurrentStage}))")
        Else
            sbSQL.Append($" AND (SYONIN_JUN=20 OR SYONIN_JUN=(SELECT MAX(SYONIN_JUN) FROM V003_SYONIN_J_KANRI AS SUB WHERE SUB.SYONIN_JUN<{intCurrentStage}")
            sbSQL.Append($" AND SUB.SYONIN_HOKOKUSYO_ID={intSYONIN_HOKOKU_ID}")
            sbSQL.Append($" AND SUB.HOKOKU_NO='{strHOKOKU_NO}'))")
        End If
        Using DB As ClsDbUtility = DBOpen()
            dsList = DB.GetDataSet(sbSQL.ToString, False)
        End Using

        dt.Columns.Add("SYONIN_HOKOKUSYO_ID", GetType(Integer))
        dt.Columns.Add("SYAIN_ID", GetType(Integer))
        dt.Columns.Add("SYAIN_NAME", GetType(String))
        dt.Columns.Add("HOKOKU_NO", GetType(String))

        '主キー設定
        dt.PrimaryKey = {dt.Columns("SYONIN_JUN"), dt.Columns("HOKOKU_NO")}


        With dsList.Tables(0)
            For intCNT = 0 To .Rows.Count - 1
                Dim Trow As DataRow = dt.NewRow()
                Trow("DISP") = .Rows(intCNT).Item("SYONIN_NAIYO") & " " & .Rows(intCNT).Item("UPD_SYAIN_NAME") '.Rows(intCNT).Item("SYONIN_JUN") & "." & .Rows(intCNT).Item("SYONIN_NAIYO") & " " & .Rows(intCNT).Item("UPD_SYAIN_NAME")
                Trow("VALUE") = .Rows(intCNT).Item("SYONIN_JUN")
                Trow("SYAIN_NAME") = .Rows(intCNT).Item("UPD_SYAIN_NAME")
                'Trow("DEL_FLG") = CBool(.Rows(intCNT).Item("DEL_FLG"))
                Trow("SYONIN_HOKOKUSYO_ID") = .Rows(intCNT).Item("SYONIN_HOKOKUSYO_ID")
                Trow("SYAIN_ID") = .Rows(intCNT).Item("UPD_SYAIN_ID")
                Trow("HOKOKU_NO") = .Rows(intCNT).Item("HOKOKU_NO")

                dt.Rows.Add(Trow)
            Next intCNT
        End With

        Return dt
    End Function


#End Region


End Class
