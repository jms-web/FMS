Imports JMS_COMMON.ClsPubMethod

Module mdlG0010

#Region "定数・変数"

    ''' <summary>
    ''' 一覧画面
    ''' </summary>
    Public frmLIST As FrmG0010

    ''' <summary>
    ''' 起動モード
    ''' </summary>
    Public Enum ENM_OPEN_MODE As Integer

        ''' <summary>
        ''' 通常モード…検索画面を表示
        ''' </summary>
        _0_通常 = 0

        ''' <summary>
        ''' 新規作成モード…新規登録画面を直接表示、登録後検索画面に戻らず
        ''' </summary>
        _1_新規作成 = 1
    End Enum
    ''' <summary>
    ''' 起動モード(0:通常,1:新規作成)
    ''' </summary>
    Public pub_intOPEN_MODE As ENM_OPEN_MODE

    ''' <summary>
    ''' 承認報告書ID
    ''' </summary>
    Public Enum ENM_SYONIN_HOKOKU_ID
        _1_NCR = 1
        _2_CAR = 2
    End Enum

    ''' <summary>
    ''' NCRステージ
    ''' </summary>
    Public Enum ENM_NCR_STAGE
        _10_起草入力 = 10
        _20_起草確認製造GL = 20
        _30_起草確認検査 = 30
        _40_事前審査判定及びCAR要否判定 = 40
        _50_事前審査確認 = 50
        _60_再審審査判定_技術代表 = 60
        _61_再審審査判定_品証代表 = 61
        _70_顧客再審処置_I_tag = 70
        _80_処置実施 = 80
        _81_処置実施_生技 = 81
        _82_処置実施_製造 = 82
        _83_処置実施_検査 = 83
        _90_処置実施確認_管理T = 90
        _100_処置実施決裁_製造課長 = 100
        _110_abcde処置担当 = 110
        _120_abcde処置確認 = 120
        _990_Closed = 990
    End Enum

    ''' <summary>
    ''' CARステージ
    ''' </summary>
    Public Enum ENM_CAR_STAGE
        _10_起草入力 = 10
        _20_起草確認_起草元GL = 20
        _30_起草確認_担当課長 = 30
        _40_起草確認_生産技術 = 40
        _50_起草確認_設計開発 = 50
        _60_起草確認_検査員 = 60
        _70_起草確認_品証課長 = 70
        _80_処置実施記録入力 = 80
        _90_処置実施確認 = 90
        _100_是正有効性記入 = 100
        _110_是正有効性確認_検査GL = 110
        _120_是正有効性確認_品証TL = 120
        _130_是正有効性確認_品証担当課長 = 130
        _990_Closed = 990

    End Enum

    ''' <summary>
    ''' 原因分析区分
    ''' </summary>
    Public Enum ENM_GENIN_BUNSEKI_KB
        _0_m_マネジメント = 0
        _1_S_ソフトウェア = 1
        _2_h_ハードウェア = 2
        _3_e_作業環境 = 3
        _4_L1_本人 = 4
        _5_L2_関係者_支援体制 = 5
        _11_材料 = 11
        _12_設備_治具 = 12
        _13_方法 = 13
    End Enum

    ''' <summary>
    ''' 承認判定区分
    ''' </summary>
    Public Enum ENM_SYONIN_HANTEI_KB
        _0_未承認 = 0
        _1_承認 = 1
    End Enum

    ''' <summary>
    ''' 報告書操作区分
    ''' </summary>
    Public Enum ENM_HOKOKUSYO_SOUSA_KB
        _0_起草 = 0
        _1_申請承認依頼 = 1
        _2_更新保存 = 2
    End Enum

    ''' <summary>
    ''' 事前審査判定区分
    ''' </summary>
    Public Enum ENM_JIZEN_SINSA_HANTEI_KB
        _0_完成する = 0
        _1_そのまま使用可 = 1
        _2_再審委員会送り = 2
        _3_顧客再審申請 = 3
        _4_廃却する = 4
        _5_返却する = 5
        _6_転用する = 6
        _7_再加工する = 7
    End Enum

    ''' <summary>
    ''' 再審委員会判定区分
    ''' </summary>
    Public Enum ENM_SAISIN_IINKAI_HANTEI_KB
        _0_完成する = 0
        _1_そのまま使用可 = 1
        _2_顧客再審申請 = 2
        _3_廃却する = 3
        _4_返却する = 4
        _5_転用する = 5
        _6_再加工する = 6
    End Enum

    Public Enum ENM_FUTEKIGO_JYOTAI_KB
        _0_最終製品 = 0
        _1_仕掛品 = 1
        _2_材料 = 2
        _3_返却品 = 3
    End Enum

    'Model
    Public _D003_NCR_J As New MODEL.D003_NCR_J
    Public _D004_SYONIN_J_KANRI As New MODEL.D004_SYONIN_J_KANRI
    Public _D005_CAR_J As New MODEL.D005_CAR_J
    Public _D006_CAR_GENIN_List As New List(Of MODEL.D006_CAR_GENIN)
    Public _R001_HOKOKU_SOUSA As New MODEL.R001_HOKOKU_SOUSA

#End Region

#Region "MAIN"
    <STAThread()>
    Public Sub Main()
        Try
            '-----二重起動抑制
            Using objMutex = New System.Threading.Mutex(False, My.Application.Info.AssemblyName)
                If objMutex.WaitOne(0, False) = False Then
                    'MsgBox("既に起動されています", MsgBoxStyle.Information, My.Application.Info.AssemblyName)
                    Exit Sub
                End If

                '-----共通初期処理
                If FunINTSYR() = False Then
                    WL.WriteLogDat(My.Resources.ErrLogMsgSetCommonInit)
                    Exit Sub
                End If

                '-----PG設定ファイル読込処理
                If FunGetPGIniFile(My.Application.Info.AssemblyName) = False Then
                    WL.WriteLogDat(My.Resources.ErrLogMsgSetPGInit)
                    Exit Sub
                End If

                '-----出力先設定ファイル読込処理
                If FunGetOutputIniFile() = False Then
                    MsgBox(My.Resources.ErrLogMsgSetOutput, MsgBoxStyle.Critical, My.Application.Info.AssemblyName)
                    Exit Sub
                End If

                '-----Visualスタイル有効
                Application.EnableVisualStyles()
                '-----GDIを使用
                Application.SetCompatibleTextRenderingDefault(False)

                '-----共通データ取得
                Using DB As ClsDbUtility = DBOpen()
                    Call FunGetCodeDataTable(DB, "NCR", tblNCR)
                    Call FunGetCodeDataTable(DB, "CAR", tblCAR)
                    'UNDONE: ステージ別の担当者取得に置き換え
                    Call FunGetCodeDataTable(DB, "担当", tblTANTO)
                    Call FunGetCodeDataTable(DB, "部門区分", tblBUMON, "DISP_ORDER < 10")
                    Call FunGetCodeDataTable(DB, "機種", tblKISYU)
                    Call FunGetCodeDataTable(DB, "不適合区分", tblFUTEKIGO_KB)
                    Call FunGetCodeDataTable(DB, "不適合状態区分", tblFUTEKIGO_STATUS_KB)
                    Call FunGetCodeDataTable(DB, "事前審査判定区分", tblJIZEN_SINSA_HANTEI_KB)
                    Call FunGetCodeDataTable(DB, "再審委員会判定区分", tblSAISIN_IINKAI_HANTEI_KB)
                    Call FunGetCodeDataTable(DB, "部品番号", tblBUHIN)
                    Call FunGetCodeDataTable(DB, "社内CD", tblSYANAI_CD)

                    Call FunGetCodeDataTable(DB, "承認担当", tblTANTO_SYONIN)
                    Call FunGetCodeDataTable(DB, "顧客判定指示区分", tblKOKYAKU_HANTEI_SIJI_KB)
                    Call FunGetCodeDataTable(DB, "顧客最終判定区分", tblKOKYAKU_SAISYU_HANTEI_KB)
                    Call FunGetCodeDataTable(DB, "要否区分", tblYOHI_KB)
                    Call FunGetCodeDataTable(DB, "検査結果区分", tblKENSA_KEKKA_KB)
                    Call FunGetCodeDataTable(DB, "根本要因区分", tblKONPON_YOIN_KB)
                    Call FunGetCodeDataTable(DB, "帰責工程区分", tblKISEKI_KOUTEI_KB)

                    Call FunGetCodeDataTable(DB, "原因分析区分", tblGENIN_BUNSEKI_KB)

                    Call FunGetCodeDataTable(DB, "設問内容", tblSETUMON_NAIYO)
                End Using

                '起動時パラメータを取得
                Dim cmds() As String
                cmds = System.Environment.GetCommandLineArgs
                If cmds.Length = 3 Then
                    pub_intOPEN_MODE = Val(cmds(2))
                Else
                    pub_intOPEN_MODE = ENM_OPEN_MODE._0_通常
                End If

                '-----一覧画面表示
                frmLIST = New FrmG0010
                Application.Run(frmLIST)
            End Using
        Catch ex As Exception
            EM.ErrorSyori(ex, False, conblnNonMsg)
            MsgBox(My.Resources.ErrMsgInit, MsgBoxStyle.Critical, My.Application.Info.AssemblyName)
        Finally

        End Try
    End Sub
#End Region

#Region "ST02 不適合報告書一覧"

    ''' <summary>
    ''' 引数の検索条件を一覧取得ストアドに渡して検索結果のテーブルデータを取得
    ''' </summary>
    ''' <param name="ParamModel"></param>
    ''' <returns></returns>
    Public Function FunGetDtST02_FUTEKIGO_ICHIRAN(ByVal ParamModel As ST02_ParamModel) As DataTable

        Dim sbSQL As New System.Text.StringBuilder
        Dim sbParam As New System.Text.StringBuilder
        Dim dsList As New DataSet

        '共通
        sbParam.Append(" '" & ParamModel.BUMON_KB & "'")
        sbParam.Append("," & ParamModel.SYONIN_HOKOKUSYO_ID & "")
        sbParam.Append("," & ParamModel.KISYU_ID & "")
        sbParam.Append(",'" & ParamModel.BUHIN_BANGO & "'")
        sbParam.Append(",'" & ParamModel.SYANAI_CD & "'")
        sbParam.Append(",'" & ParamModel.BUHIN_NAME & "'")
        sbParam.Append(",'" & ParamModel.GOUKI & "'")
        sbParam.Append("," & ParamModel.SYOCHI_TANTO & "")
        sbParam.Append(",'" & ParamModel.JISI_YMD_FROM & "'")
        sbParam.Append(",'" & ParamModel.JISI_YMD_TO & "'")
        sbParam.Append(",'" & ParamModel.HOKOKU_NO & "'")
        sbParam.Append("," & ParamModel.ADD_TANTO & "")
        sbParam.Append(",'" & ParamModel._VISIBLE_CLOSE & "'")
        sbParam.Append(",'" & ParamModel._VISIBLE_TAIRYU & "'")
        sbParam.Append(",'" & ParamModel.FUTEKIGO_KB & "'")
        sbParam.Append(",'" & ParamModel.FUTEKIGO_S_KB & "'")
        sbParam.Append(",'" & ParamModel.FUTEKIGO_JYOTAI_KB & "'")

        'NCR
        sbParam.Append(",'" & ParamModel.JIZEN_SINSA_HANTEI_KB & "'")
        sbParam.Append(",'" & ParamModel.ZESEI_SYOCHI_YOHI_KB & "'")
        sbParam.Append(",'" & ParamModel.SAISIN_IINKAI_HANTEI_KB & "'")
        sbParam.Append(",'" & ParamModel.KENSA_KEKKA_KB & "'")

        'CAR
        sbParam.Append(",'" & ParamModel.KONPON_YOIN_KB1 & "'")
        sbParam.Append(",'" & ParamModel.KONPON_YOIN_KB2 & "'")
        sbParam.Append(",'" & ParamModel.KISEKI_KOTEI_KB & "'")
        sbParam.Append(",'" & ParamModel.KOKYAKU_HANTEI_SIJI_KB & "'")
        sbParam.Append(",'" & ParamModel.KOKYAKU_SAISYU_HANTEI_KB & "'")
        sbParam.Append(",'" & ParamModel.GENIN1 & "'")
        sbParam.Append(",'" & ParamModel.GENIN2 & "'")


        sbSQL.Append("EXEC dbo." & NameOf(MODEL.ST02_FUTEKIGO_ICHIRAN) & " " & sbParam.ToString & "")
        Using DB As ClsDbUtility = DBOpen()
            dsList = DB.GetDataSet(sbSQL.ToString, conblnNonMsg)
        End Using

        Return dsList?.Tables(0)
    End Function


    Public Function FunGetV002Model(ByVal strHOKOKU_NO As String) As MODEL.V002_NCR_J

        Dim sbSQL As New System.Text.StringBuilder
        Dim dsList As New DataSet

        sbSQL.Remove(0, sbSQL.Length)
        sbSQL.Append("SELECT")
        sbSQL.Append(" *")
        sbSQL.Append(" FROM " & NameOf(MODEL.V002_NCR_J) & " ")
        sbSQL.Append(" WHERE HOKOKU_NO='" & strHOKOKU_NO & "'")
        Using DB As ClsDbUtility = DBOpen()
            dsList = DB.GetDataSet(sbSQL.ToString, conblnNonMsg)
        End Using

        If dsList.Tables(0).Rows.Count = 0 Then
            Return Nothing
        Else

            Dim _model As New MODEL.V002_NCR_J
            With dsList.Tables(0).Rows(0)
                _model.BUHIN_BANGO = .Item(NameOf(_model.BUHIN_BANGO))
                _model.BUHIN_NAME = .Item(NameOf(_model.BUHIN_NAME))
                _model.FUTEKIGO_JYOTAI_KB = .Item(NameOf(_model.FUTEKIGO_JYOTAI_KB))
                _model.FUTEKIGO_NAIYO = .Item(NameOf(_model.FUTEKIGO_NAIYO))
                _model.GOKI = .Item(NameOf(_model.GOKI))
                _model.HAIKYAKU_HOUHOU = .Item(NameOf(_model.HAIKYAKU_HOUHOU))
                _model.HAIKYAKU_KB_NAME = .Item(NameOf(_model.HAIKYAKU_KB_NAME))
                _model.HAIKYAKU_TANTO_NAME = .Item(NameOf(_model.HAIKYAKU_TANTO_NAME))
                _model.HAIKYAKU_YMD = .Item(NameOf(_model.HAIKYAKU_YMD))
                '_model.HASSEI_KOTEI_GL_NAME = .Item(NameOf(_model.HASSEI_KOTEI_GL_NAME))
                '_model.HASSEI_KOTEI_GL_YMD = .Item(NameOf(_model.HASSEI_KOTEI_GL_YMD))
                _model.HENKYAKU_BIKO = .Item(NameOf(_model.HENKYAKU_BIKO))
                _model.HENKYAKU_TANTO_NAME = .Item(NameOf(_model.HENKYAKU_TANTO_NAME))
                _model.HENKYAKU_YMD = .Item(NameOf(_model.HENKYAKU_YMD))
                _model.HOKOKU_NO = .Item(NameOf(_model.HOKOKU_NO))
                _model.ITAG_NO = .Item(NameOf(_model.ITAG_NO))
                _model.JIZEN_SINSA_HANTEI_KB = .Item(NameOf(_model.JIZEN_SINSA_HANTEI_KB))
                _model.JIZEN_SINSA_SYAIN_NAME = .Item(NameOf(_model.JIZEN_SINSA_SYAIN_NAME))
                _model.JIZEN_SINSA_YMD = .Item(NameOf(_model.JIZEN_SINSA_YMD))
                _model.KANSATU_KEKKA = .Item(NameOf(_model.KANSATU_KEKKA))
                _model.KENSA_KEKKA_NAME = .Item(NameOf(_model.KENSA_KEKKA_NAME))
                _model.KENSA_TANTO_NAME = .Item(NameOf(_model.KENSA_TANTO_NAME))
                _model.KISYU = .Item(NameOf(_model.KISYU))
                _model.KOKYAKU_HANTEI_SIJI_NAME = .Item(NameOf(_model.KOKYAKU_HANTEI_SIJI_NAME))
                _model.KOKYAKU_HANTEI_SIJI_YMD = .Item(NameOf(_model.KOKYAKU_HANTEI_SIJI_YMD))
                _model.SAIHATU = .Item(NameOf(_model.SAIHATU))
                _model.SAIKAKO_KENSA_YMD = .Item(NameOf(_model.SAIKAKO_KENSA_YMD))
                _model.SAIKAKO_SAGYO_KAN_YMD = .Item(NameOf(_model.SAIKAKO_SAGYO_KAN_YMD))
                _model.SAIKAKO_SIJI_NO = .Item(NameOf(_model.SAIKAKO_SIJI_NO))
                _model.SAISIN_GIJYUTU_SYAIN_NAME = .Item(NameOf(_model.SAISIN_GIJYUTU_SYAIN_NAME))
                _model.SAISIN_HINSYO_SYAIN_NAME = .Item(NameOf(_model.SAISIN_HINSYO_SYAIN_NAME))
                _model.SAISIN_HINSYO_YMD = .Item(NameOf(_model.SAISIN_HINSYO_YMD))
                _model.SAISIN_IINKAI_HANTEI_KB = .Item(NameOf(_model.SAISIN_IINKAI_HANTEI_KB))
                _model.SAISIN_IINKAI_SIRYO_NO = .Item(NameOf(_model.SAISIN_IINKAI_SIRYO_NO))
                _model.SAISIN_KAKUNIN_SYAIN_NAME = .Item(NameOf(_model.SAISIN_KAKUNIN_SYAIN_NAME))
                _model.SAISIN_KAKUNIN_YMD = .Item(NameOf(_model.SAISIN_KAKUNIN_YMD))
                _model.SEIGI_TANTO_NAME = .Item(NameOf(_model.SEIGI_TANTO_NAME))
                _model.SEIZO_TANTO_NAME = .Item(NameOf(_model.SEIZO_TANTO_NAME))
                _model.SURYO = .Item(NameOf(_model.SURYO))
                _model.SYOCHI_D_SYOCHI_KIROKU = .Item(NameOf(_model.SYOCHI_D_SYOCHI_KIROKU))
                _model.SYOCHI_D_UMU_NAME = .Item(NameOf(_model.SYOCHI_D_UMU_NAME))
                _model.SYOCHI_D_YOHI_NAME = .Item(NameOf(_model.SYOCHI_D_YOHI_NAME))
                _model.SYOCHI_E_SYOCHI_KIROKU = .Item(NameOf(_model.SYOCHI_E_SYOCHI_KIROKU))
                _model.SYOCHI_E_UMU_NAME = .Item(NameOf(_model.SYOCHI_E_UMU_NAME))
                _model.SYOCHI_E_YOHI_NAME = .Item(NameOf(_model.SYOCHI_E_YOHI_NAME))
                _model.TENYO_BUHIN_BANGO = .Item(NameOf(_model.TENYO_BUHIN_BANGO))
                _model.TENYO_GOKI = .Item(NameOf(_model.TENYO_GOKI))
                _model.TENYO_KISYU = .Item(NameOf(_model.TENYO_KISYU))
                _model.TENYO_YMD = .Item(NameOf(_model.TENYO_YMD))
                _model.YOKYU_NAIYO = .Item(NameOf(_model.YOKYU_NAIYO))
                _model.ZUMEN_KIKAKU = .Item(NameOf(_model.ZUMEN_KIKAKU))

            End With

            Return _model
        End If




    End Function

    Public Function FunGetV003Model(ByVal intSYONIN_HOKOKUSYO_ID As Integer, ByVal strHOKOKU_NO As String) As MODEL.V003_SYONIN_J_KANRI

        Dim sbSQL As New System.Text.StringBuilder
        Dim dsList As New DataSet

        sbSQL.Remove(0, sbSQL.Length)
        sbSQL.Append("SELECT")
        sbSQL.Append(" *")
        sbSQL.Append(" FROM " & NameOf(MODEL.V003_SYONIN_J_KANRI) & " ")
        sbSQL.Append(" WHERE SYONIN_HOKOKUSYO_ID = " & intSYONIN_HOKOKUSYO_ID & "")
        sbSQL.Append(" AND HOKOKU_NO='" & strHOKOKU_NO & "'")
        Using DB As ClsDbUtility = DBOpen()
            dsList = DB.GetDataSet(sbSQL.ToString, conblnNonMsg)
        End Using

        If dsList.Tables(0).Rows.Count = 0 Then
            Return Nothing
        Else

            Dim _model As New MODEL.V003_SYONIN_J_KANRI
            With dsList.Tables(0).Rows(0)
                _model.BUHIN_BANGO = .Item(NameOf(_model.BUHIN_BANGO))
                _model.BUHIN_BANGO = .Item(NameOf(_model.BUHIN_BANGO))
                _model.BUHIN_BANGO = .Item(NameOf(_model.BUHIN_BANGO))
                _model.BUHIN_BANGO = .Item(NameOf(_model.BUHIN_BANGO))
                _model.BUHIN_BANGO = .Item(NameOf(_model.BUHIN_BANGO))
                _model.BUHIN_BANGO = .Item(NameOf(_model.BUHIN_BANGO))
                _model.BUHIN_BANGO = .Item(NameOf(_model.BUHIN_BANGO))
                _model.BUHIN_BANGO = .Item(NameOf(_model.BUHIN_BANGO))
                _model.BUHIN_BANGO = .Item(NameOf(_model.BUHIN_BANGO))
                _model.BUHIN_BANGO = .Item(NameOf(_model.BUHIN_BANGO))
                _model.BUHIN_BANGO = .Item(NameOf(_model.BUHIN_BANGO))
                _model.BUHIN_BANGO = .Item(NameOf(_model.BUHIN_BANGO))
                _model.BUHIN_BANGO = .Item(NameOf(_model.BUHIN_BANGO))
                _model.BUHIN_BANGO = .Item(NameOf(_model.BUHIN_BANGO))
                _model.BUHIN_BANGO = .Item(NameOf(_model.BUHIN_BANGO))


            End With

            Return _model
        End If




    End Function
#End Region

#Region "メール送信"

    Public Function FunSendMailFutekigo(ByVal strSubject As String, ByVal strBody As String, ByVal ToSYAIN_ID As Integer) As Boolean
        Dim strSmtpServer As String
        Dim intSmtpPort As Integer
        Dim strFromAddress As String
        Dim strToAddress As String
        Dim strUserID As String
        Dim strPassword As String
        Dim blnSend As Boolean

        Using DB As ClsDbUtility = DBOpen()
            strSmtpServer = FunGetCodeMastaValue(DB, "メール設定", "SMTP_SERVER")
            intSmtpPort = Val(FunGetCodeMastaValue(DB, "メール設定", "SMTP_PORT"))
            strFromAddress = FunGetCodeMastaValue(DB, "メール設定", "FROM")
            'strUserID = FunGetCodeMastaValue("メール設定", "SMTP_USER")
            'strPassword = FunGetCodeMastaValue("メール設定", "SMTP_PASS")


            '---申請先担当者のメールアドレス取得
            Dim sbSQL As New System.Text.StringBuilder
            Dim dsList As New DataSet
            sbSQL.Remove(0, sbSQL.Length)
            sbSQL.Append("SELECT")
            sbSQL.Append(" MAIL_ADDRESS")
            sbSQL.Append(" FROM " & NameOf(MODEL.M004_SYAIN) & " ")
            sbSQL.Append(" WHERE SYAIN_ID=" & ToSYAIN_ID & "")
            Using DBa As ClsDbUtility = DBOpen()
                dsList = DBa.GetDataSet(sbSQL.ToString, conblnNonMsg)
            End Using
            If dsList.Tables(0).Rows.Count > 0 Then
                strToAddress = dsList.Tables(0).Rows(0).Item(0)
            Else
                Return False
            End If

        End Using

        'DEBUG: mail送信無効
        Return True


        '認証なし
        blnSend = ClsMailSend.FunSendMail(strSmtpServer,
                       intSmtpPort,
                       strFromAddress,
                       strToAddress,
                       CCAddress:=strFromAddress,
                       BCCAddress:="",
                       strSubject:=strSubject,
                       strBody:=strBody,
                       strAttachment:="",
                       strFromName:="不適合管理システム")

        '認証あり
        'blnSend = ClsMailSend.FunSendMailoverAUTH(strSmtpServer,
        '               intSmtpPort,
        '               strUserID,
        '               strPassword,
        '               strFromAddress,
        '               strToAddress,
        '               strSubject,
        '               "タイムカード集計",
        '               strSendFilePath)

        Return blnSend

    End Function

#End Region

End Module
