Imports JMS_COMMON.ClsPubMethod

Module mdlG0010

#Region "定数・変数"

    ''' <summary>
    ''' 一覧画面
    ''' </summary>
    Public frmLIST As FrmG0010

    ''' <summary>
    ''' 起動モード(0:通常,1:新規作成)
    ''' </summary>
    Public pub_intOPEN_MODE As Integer

    Public pub_PrSYONIN_HOKOKUSYO_ID As Integer
    Public pub_PrHOKOKU_NO As String

#Region "列挙型"
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

    Public Enum ENM_SAVE_MODE
        _1_保存 = 1
        _2_承認申請 = 2
    End Enum


    ''' <summary>
    ''' 承認報告書ID
    ''' </summary>
    Public Enum ENM_SYONIN_HOKOKUSYO_ID
        _1_NCR = 1
        _2_CAR = 2
    End Enum

    ''' <summary>
    ''' 検査結果区分
    ''' </summary>
    Public Enum ENM_KENSA_KEKKA_KB
        _0_合格 = 0
        _1_不合格 = 1
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

    ''' <summary>
    ''' 顧客最終判定区分
    ''' </summary>
    Public Enum ENM_KOKYAKU_SAISYU_HANTEI_KB
        _0_完成する = 0
        _1_そのまま使用可 = 1
        _2_顧客再審申請 = 2
        _3_廃却する = 3
        _4_返却する = 4
        _5_転用する = 5
        _6_再加工する = 6
    End Enum

    ''' <summary>
    ''' 不適合状態区分
    ''' </summary>
    Public Enum ENM_FUTEKIGO_JYOTAI_KB
        _0_最終製品 = 0
        _1_仕掛品 = 1
        _2_材料 = 2
        _3_返却品 = 3
    End Enum

    ''' <summary>
    ''' 要否区分
    ''' </summary>
    Public Enum ENM_YOHI_KB
        _0_否 = 0
        _1_要 = 1
    End Enum

    ''' <summary>
    ''' 履歴操作区分
    ''' </summary>
    Public Enum ENM_SOUSA_KB
        _0_新規作成 = 0
        _1_申請依頼 = 1
        _2_更新保存 = 2
        _3_承認差戻 = 3
        _4_メール送信 = 4
        _5_転送 = 5
    End Enum


    Public Enum ENM_SYOUNIN_HANTEI_KB
        _0_未承認 = 0
        _1_承認 = 1
        _9_差戻 = 9
    End Enum

#End Region

#Region "Model"
    Public _D003_NCR_J As New MODEL.D003_NCR_J
    Public _D004_SYONIN_J_KANRI As New MODEL.D004_SYONIN_J_KANRI
    Public _D005_CAR_J As New MODEL.D005_CAR_J
    Public _D006_CAR_GENIN_List As New List(Of MODEL.D006_CAR_GENIN)
    Public _R001_HOKOKU_SOUSA As New MODEL.R001_HOKOKU_SOUSA
    Public _R002_HOKOKU_TENSO As New MODEL.R002_HOKOKU_TENSO
    Public _R003_NCR_SASIMODOSI As New MODEL.R003_NCR_SASIMODOSI
    Public _R004_CAR_SASIMODOSI As New MODEL.R004_CAR_SASIMODOSI
#End Region

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
                    Call FunGetCodeDataTable(DB, "担当", tblTANTO)
                    Call FunGetCodeDataTable(DB, "部門区分", tblBUMON, "DISP_ORDER < 10") '10以降は不適合SYSでは不要
                    Call FunGetCodeDataTable(DB, "機種", tblKISYU)
                    Call FunGetCodeDataTable(DB, "不適合区分", tblFUTEKIGO_KB)
                    Call FunGetCodeDataTable(DB, "不適合状態区分", tblFUTEKIGO_STATUS_KB)
                    Call FunGetCodeDataTable(DB, "事前審査判定区分", tblJIZEN_SINSA_HANTEI_KB)
                    Call FunGetCodeDataTable(DB, "再審委員会判定区分", tblSAISIN_IINKAI_HANTEI_KB)
                    Call FunGetCodeDataTable(DB, "部品番号", tblBUHIN)
                    Call FunGetCodeDataTable(DB, "社内CD", tblSYANAI_CD)

                    Call FunGetCodeDataTable(DB, "承認担当", tblTANTO_SYONIN)
                    'Call FunGetCodeDataTable(DB, "承認担当一覧", tblTANTO_SYONINList)
                    Call FunGetCodeDataTable(DB, "顧客判定指示区分", tblKOKYAKU_HANTEI_SIJI_KB)
                    Call FunGetCodeDataTable(DB, "顧客最終判定区分", tblKOKYAKU_SAISYU_HANTEI_KB)
                    Call FunGetCodeDataTable(DB, "要否区分", tblYOHI_KB)
                    Call FunGetCodeDataTable(DB, "検査結果区分", tblKENSA_KEKKA_KB)
                    Call FunGetCodeDataTable(DB, "根本要因区分", tblKONPON_YOIN_KB)
                    Call FunGetCodeDataTable(DB, "帰責工程区分", tblKISEKI_KOUTEI_KB)

                    Call FunGetCodeDataTable(DB, "原因分析区分", tblGENIN_BUNSEKI_KB)

                    Call FunGetCodeDataTable(DB, "設問内容", tblSETUMON_NAIYO)

                    Call FunGetCodeDataTable(DB, "廃却方法", tblHAIKYAKU_KB)

                    Call FunGetCodeDataTable(DB, "承認判定区分", tblSYONIN_HANTEI_KB)

                End Using

                '起動時パラメータを取得
                Dim cmds() As String
                cmds = System.Environment.GetCommandLineArgs

                If cmds.Length = 5 Then
                    'メールリンク用 
                    pub_PrHOKOKU_NO = Val(cmds(4))
                    pub_PrSYONIN_HOKOKUSYO_ID = Val(cmds(3))
                ElseIf cmds.Length = 3 Then
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

#Region "共通関数"

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
        sbParam.Append(",'" & IIf(ParamModel._VISIBLE_CLOSE = 1, "", ParamModel._VISIBLE_CLOSE) & "'")
        sbParam.Append(",'" & IIf(ParamModel._VISIBLE_TAIRYU = 1, ParamModel._VISIBLE_TAIRYU, "") & "'")
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
            Dim t As Type = GetType(MODEL.V002_NCR_J)
            Dim properties As Reflection.PropertyInfo() = t.GetProperties(
                 Reflection.BindingFlags.Public Or
                 Reflection.BindingFlags.Instance Or
                 Reflection.BindingFlags.Static).Where(Function(p) p.Name <> "Item").ToArray

            With dsList.Tables(0).Rows(0)
                For Each p As Reflection.PropertyInfo In properties
                    _model(p.Name) = .Item(p.Name)
                Next p

                '_model.ADD_SYAIN_ID = .Item(NameOf(_model.ADD_SYAIN_ID))
                '_model.ADD_SYAIN_NAME = .Item(NameOf(_model.ADD_SYAIN_NAME))
                '_model.ADD_YMDHNS = .Item(NameOf(_model.ADD_YMDHNS))
                '_model.BUMON_KB = .Item(NameOf(_model.BUMON_KB))
                '_model.BUMON_NAME = .Item(NameOf(_model.BUMON_NAME))
                '_model.BUHIN_BANGO = .Item(NameOf(_model.BUHIN_BANGO))
                '_model.BUHIN_NAME = .Item(NameOf(_model.BUHIN_NAME))
                '_model.FUTEKIGO_JYOTAI_KB = .Item(NameOf(_model.FUTEKIGO_JYOTAI_KB))
                '_model.FUTEKIGO_NAIYO = .Item(NameOf(_model.FUTEKIGO_NAIYO))
                '_model.GOKI = .Item(NameOf(_model.GOKI))
                '_model.HAIKYAKU_HOUHOU = .Item(NameOf(_model.HAIKYAKU_HOUHOU))
                '_model.HAIKYAKU_KB_NAME = .Item(NameOf(_model.HAIKYAKU_KB_NAME))
                '_model.HAIKYAKU_TANTO_NAME = .Item(NameOf(_model.HAIKYAKU_TANTO_NAME))
                '_model.HAIKYAKU_YMD = .Item(NameOf(_model.HAIKYAKU_YMD))
                '_model.HASSEI_KOTEI_GL_NAME = .Item(NameOf(_model.HASSEI_KOTEI_GL_NAME))
                '_model.HASSEI_KOTEI_GL_YMD = .Item(NameOf(_model.HASSEI_KOTEI_GL_YMD))
                '_model.HENKYAKU_BIKO = .Item(NameOf(_model.HENKYAKU_BIKO))
                '_model.HENKYAKU_TANTO_NAME = .Item(NameOf(_model.HENKYAKU_TANTO_NAME))
                '_model.HENKYAKU_YMD = .Item(NameOf(_model.HENKYAKU_YMD))
                '_model.HOKOKU_NO = .Item(NameOf(_model.HOKOKU_NO))
                '_model.ITAG_NO = .Item(NameOf(_model.ITAG_NO))
                '_model.JIZEN_SINSA_HANTEI_KB = .Item(NameOf(_model.JIZEN_SINSA_HANTEI_KB))
                '_model.JIZEN_SINSA_SYAIN_NAME = .Item(NameOf(_model.JIZEN_SINSA_SYAIN_NAME))
                '_model.JIZEN_SINSA_YMD = .Item(NameOf(_model.JIZEN_SINSA_YMD))
                '_model.KANSATU_KEKKA = .Item(NameOf(_model.KANSATU_KEKKA))
                '_model.KENSA_KEKKA_NAME = .Item(NameOf(_model.KENSA_KEKKA_NAME))
                '_model.KENSA_TANTO_NAME = .Item(NameOf(_model.KENSA_TANTO_NAME))
                '_model.KISYU = .Item(NameOf(_model.KISYU))
                '_model.KISYU_ID = .Item(NameOf(_model.KISYU_ID))
                '_model.KISYU_NAME = .Item(NameOf(_model.KISYU_NAME))
                '_model.KOKYAKU_HANTEI_SIJI_NAME = .Item(NameOf(_model.KOKYAKU_HANTEI_SIJI_NAME))
                '_model.KOKYAKU_HANTEI_SIJI_YMD = .Item(NameOf(_model.KOKYAKU_HANTEI_SIJI_YMD))
                '_model.SAIHATU = .Item(NameOf(_model.SAIHATU))
                '_model.SAIKAKO_KENSA_YMD = .Item(NameOf(_model.SAIKAKO_KENSA_YMD))
                '_model.SAIKAKO_SAGYO_KAN_YMD = .Item(NameOf(_model.SAIKAKO_SAGYO_KAN_YMD))
                '_model.SAIKAKO_SIJI_NO = .Item(NameOf(_model.SAIKAKO_SIJI_NO))
                '_model.SAISIN_GIJYUTU_SYAIN_NAME = .Item(NameOf(_model.SAISIN_GIJYUTU_SYAIN_NAME))
                '_model.SAISIN_HINSYO_SYAIN_NAME = .Item(NameOf(_model.SAISIN_HINSYO_SYAIN_NAME))
                '_model.SAISIN_HINSYO_YMD = .Item(NameOf(_model.SAISIN_HINSYO_YMD))
                '_model.SAISIN_IINKAI_HANTEI_KB = .Item(NameOf(_model.SAISIN_IINKAI_HANTEI_KB))
                '_model.SAISIN_IINKAI_SIRYO_NO = .Item(NameOf(_model.SAISIN_IINKAI_SIRYO_NO))
                '_model.SAISIN_KAKUNIN_SYAIN_NAME = .Item(NameOf(_model.SAISIN_KAKUNIN_SYAIN_NAME))
                '_model.SAISIN_KAKUNIN_YMD = .Item(NameOf(_model.SAISIN_KAKUNIN_YMD))
                '_model.SEIGI_TANTO_NAME = .Item(NameOf(_model.SEIGI_TANTO_NAME))
                '_model.SEIZO_TANTO_NAME = .Item(NameOf(_model.SEIZO_TANTO_NAME))
                '_model.SURYO = .Item(NameOf(_model.SURYO))
                '_model.SYOCHI_D_SYOCHI_KIROKU = .Item(NameOf(_model.SYOCHI_D_SYOCHI_KIROKU))
                '_model.SYOCHI_D_UMU_NAME = .Item(NameOf(_model.SYOCHI_D_UMU_NAME))
                '_model.SYOCHI_D_YOHI_NAME = .Item(NameOf(_model.SYOCHI_D_YOHI_NAME))
                '_model.SYOCHI_E_SYOCHI_KIROKU = .Item(NameOf(_model.SYOCHI_E_SYOCHI_KIROKU))
                '_model.SYOCHI_E_UMU_NAME = .Item(NameOf(_model.SYOCHI_E_UMU_NAME))
                '_model.SYOCHI_E_YOHI_NAME = .Item(NameOf(_model.SYOCHI_E_YOHI_NAME))
                '_model.TENYO_BUHIN_BANGO = .Item(NameOf(_model.TENYO_BUHIN_BANGO))
                '_model.TENYO_GOKI = .Item(NameOf(_model.TENYO_GOKI))
                '_model.TENYO_KISYU = .Item(NameOf(_model.TENYO_KISYU))
                '_model.TENYO_YMD = .Item(NameOf(_model.TENYO_YMD))
                '_model.YOKYU_NAIYO = .Item(NameOf(_model.YOKYU_NAIYO))
                '_model.ZUMEN_KIKAKU = .Item(NameOf(_model.ZUMEN_KIKAKU))

            End With

            Return _model
        End If




    End Function

    Public Function FunGetV003Model(ByVal intSYONIN_HOKOKUSYO_ID As Integer, ByVal strHOKOKU_NO As String) As List(Of MODEL.V003_SYONIN_J_KANRI)

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
            Dim t As Type = GetType(MODEL.V003_SYONIN_J_KANRI)
            Dim properties As Reflection.PropertyInfo() = t.GetProperties(
                         Reflection.BindingFlags.Public Or
                         Reflection.BindingFlags.Instance Or
                         Reflection.BindingFlags.Static).Where(Function(p) p.Name <> "Item").ToArray

            Dim entities As New List(Of MODEL.V003_SYONIN_J_KANRI)
            For Each row As DataRow In dsList.Tables(0).Rows
                With row
                    Dim _model As New MODEL.V003_SYONIN_J_KANRI
                    For Each p As Reflection.PropertyInfo In properties

                        Select Case p.PropertyType
                            Case GetType(Integer)
                                _model(p.Name) = row.Item(p.Name)
                            Case GetType(Decimal)
                                _model(p.Name) = CDec(row.Item(p.Name))
                            Case GetType(Boolean)
                                _model(p.Name) = CBool(row.Item(p.Name))

                            Case GetType(Date), GetType(DateTime)
                                If row.Item(p.Name).ToString.IsNullOrWhiteSpace = False Then
                                    Select Case row.Item(p.Name).ToString.Length
                                        Case 8 'yyyyMMdd
                                            _model(p.Name) = DateTime.ParseExact(row.Item(p.Name), "yyyyMMdd", Nothing)
                                        Case 14 'yyyyMMddHHmmss
                                            _model(p.Name) = DateTime.ParseExact(row.Item(p.Name), "yyyyMMddHHmmss", Nothing)
                                        Case Else
                                            'Err
                                            _model(p.Name) = Nothing
                                    End Select
                                End If
                            Case Else
                                _model(p.Name) = row.Item(p.Name).ToString.Trim
                        End Select
                    Next p
                    entities.Add(_model)
                End With
            Next row

            Return entities
        End If
    End Function

    Public Function FunGetV005Model(ByVal strHOKOKU_NO As String) As MODEL.V005_CAR_J

        Dim sbSQL As New System.Text.StringBuilder
        Dim dsList As New DataSet

        sbSQL.Remove(0, sbSQL.Length)
        sbSQL.Append("SELECT")
        sbSQL.Append(" *")
        sbSQL.Append(" FROM " & NameOf(MODEL.V005_CAR_J) & " ")
        sbSQL.Append(" WHERE HOKOKU_NO='" & strHOKOKU_NO & "'")
        Using DB As ClsDbUtility = DBOpen()
            dsList = DB.GetDataSet(sbSQL.ToString, conblnNonMsg)
        End Using

        If dsList.Tables(0).Rows.Count = 0 Then
            Return Nothing
        Else

            Dim _model As New MODEL.V005_CAR_J
            With dsList.Tables(0).Rows(0)
                _model.HOKOKU_NO = .Item(NameOf(_model.HOKOKU_NO))
                _model.BUMON_KB = .Item(NameOf(_model.BUMON_KB))
                _model.BUMON_NAME = .Item(NameOf(_model.BUMON_NAME))
                _model.KISYU_ID = .Item(NameOf(_model.KISYU_ID))
                _model.KISYU = .Item(NameOf(_model.KISYU))
                _model.KISYU_NAME = .Item(NameOf(_model.KISYU_NAME))
                _model.CLOSE_FG = CBool(.Item(NameOf(_model.CLOSE_FG)))
                _model.KAITO_1 = .Item(NameOf(_model.KAITO_1))
                _model.KAITO_2 = .Item(NameOf(_model.KAITO_2))
                _model.KAITO_3 = .Item(NameOf(_model.KAITO_3))
                _model.KAITO_4 = .Item(NameOf(_model.KAITO_4))
                _model.KAITO_5 = .Item(NameOf(_model.KAITO_5))
                _model.KAITO_6 = .Item(NameOf(_model.KAITO_6))
                _model.KAITO_7 = .Item(NameOf(_model.KAITO_7))
                _model.KAITO_8 = .Item(NameOf(_model.KAITO_8))
                _model.KAITO_9 = .Item(NameOf(_model.KAITO_9))
                _model.KAITO_10 = .Item(NameOf(_model.KAITO_10))
                _model.KAITO_11 = .Item(NameOf(_model.KAITO_11))
                _model.KAITO_12 = .Item(NameOf(_model.KAITO_12))
                _model.KAITO_13 = .Item(NameOf(_model.KAITO_13))
                _model.KAITO_14 = .Item(NameOf(_model.KAITO_14))
                _model.KAITO_15 = .Item(NameOf(_model.KAITO_15))
                _model.KAITO_16 = .Item(NameOf(_model.KAITO_16))
                _model.KAITO_17 = .Item(NameOf(_model.KAITO_17))
                _model.KAITO_18 = .Item(NameOf(_model.KAITO_18))
                _model.KAITO_19 = .Item(NameOf(_model.KAITO_19))
                _model.KAITO_20 = .Item(NameOf(_model.KAITO_20))
                _model.KAITO_21 = .Item(NameOf(_model.KAITO_21))
                _model.KAITO_22 = .Item(NameOf(_model.KAITO_22))
                _model.KAITO_23 = .Item(NameOf(_model.KAITO_23))
                _model.KAITO_24 = .Item(NameOf(_model.KAITO_24))
                _model.KAITO_25 = .Item(NameOf(_model.KAITO_25))
                _model.KONPON_YOIN_KB1 = .Item(NameOf(_model.KONPON_YOIN_KB1))
                _model.KONPON_YOIN_NAME1 = .Item(NameOf(_model.KONPON_YOIN_NAME1))
                _model.KONPON_YOIN_KB2 = .Item(NameOf(_model.KONPON_YOIN_KB2))
                _model.KONPON_YOIN_NAME2 = .Item(NameOf(_model.KONPON_YOIN_NAME2))
                _model.KONPON_YOIN_SYAIN_ID = .Item(NameOf(_model.KONPON_YOIN_SYAIN_ID))
                _model.KONPON_YOIN_SYAIN_NAME = .Item(NameOf(_model.KONPON_YOIN_SYAIN_NAME))
                _model.KISEKI_KOTEI_KB = .Item(NameOf(_model.KISEKI_KOTEI_KB))
                _model.KISEKI_KOTEI_NAME = .Item(NameOf(_model.KISEKI_KOTEI_NAME))
                _model.SYOCHI_A_SYAIN_ID = .Item(NameOf(_model.SYOCHI_A_SYAIN_ID))
                _model.SYOCHI_A_SYAIN_NAME = .Item(NameOf(_model.SYOCHI_A_SYAIN_NAME))
                _model.SYOCHI_A_YMDHNS = .Item(NameOf(_model.SYOCHI_A_YMDHNS))
                _model.SYOCHI_B_SYAIN_ID = .Item(NameOf(_model.SYOCHI_B_SYAIN_ID))
                _model.SYOCHI_B_SYAIN_NAME = .Item(NameOf(_model.SYOCHI_B_SYAIN_NAME))
                _model.SYOCHI_B_YMDHNS = .Item(NameOf(_model.SYOCHI_B_YMDHNS))
                _model.SYOCHI_C_SYAIN_ID = .Item(NameOf(_model.SYOCHI_C_SYAIN_ID))
                _model.SYOCHI_C_SYAIN_NAME = .Item(NameOf(_model.SYOCHI_C_SYAIN_NAME))
                _model.SYOCHI_C_YMDHNS = .Item(NameOf(_model.SYOCHI_C_YMDHNS))
                _model.KYOIKU_FILE_PATH = .Item(NameOf(_model.KYOIKU_FILE_PATH))
                _model.ZESEI_SYOCHI_YUKO_UMU = .Item(NameOf(_model.ZESEI_SYOCHI_YUKO_UMU))
                _model.ZESEI_SYOCHI_YUKO_UMU_NAME = .Item(NameOf(_model.ZESEI_SYOCHI_YUKO_UMU_NAME))
                _model.SYOSAI_FILE_PATH = .Item(NameOf(_model.SYOSAI_FILE_PATH))
                _model.GOKI = .Item(NameOf(_model.GOKI))
                _model.LOT = .Item(NameOf(_model.LOT))
                _model.KENSA_TANTO_ID = .Item(NameOf(_model.KENSA_TANTO_ID))
                _model.KENSA_TANTO_NAME = .Item(NameOf(_model.KENSA_TANTO_NAME))
                _model.KENSA_TOROKU_YMDHNS = .Item(NameOf(_model.KENSA_TOROKU_YMDHNS))
                _model.KENSA_GL_SYAIN_ID = .Item(NameOf(_model.KENSA_GL_SYAIN_ID))
                _model.KENSA_GL_SYAIN_NAME = .Item(NameOf(_model.KENSA_GL_SYAIN_NAME))
                _model.KENSA_GL_YMDHNS = .Item(NameOf(_model.KENSA_GL_YMDHNS))
                _model.ADD_SYAIN_ID = .Item(NameOf(_model.ADD_SYAIN_ID))
                _model.ADD_SYAIN_NAME = .Item(NameOf(_model.ADD_SYAIN_NAME))
                _model.ADD_YMDHNS = .Item(NameOf(_model.ADD_YMDHNS))
                _model.UPD_SYAIN_ID = .Item(NameOf(_model.UPD_SYAIN_ID))
                _model.UPD_SYAIN_NAME = .Item(NameOf(_model.UPD_SYAIN_NAME))
                _model.UPD_YMDHNS = .Item(NameOf(_model.UPD_YMDHNS))
                _model.DEL_SYAIN_ID = .Item(NameOf(_model.DEL_SYAIN_ID))
                _model.DEL_SYAIN_NAME = .Item(NameOf(_model.DEL_SYAIN_NAME))
                _model.DEL_YMDHNS = .Item(NameOf(_model.DEL_YMDHNS))

                _model.SYONIN_NAME10 = .Item(NameOf(_model.SYONIN_NAME10))
                _model.SYONIN_YMD10 = .Item(NameOf(_model.SYONIN_YMD10))
                _model.SYONIN_NAME20 = .Item(NameOf(_model.SYONIN_NAME20))
                _model.SYONIN_YMD20 = .Item(NameOf(_model.SYONIN_YMD20))
                _model.SYONIN_NAME30 = .Item(NameOf(_model.SYONIN_NAME30))
                _model.SYONIN_YMD30 = .Item(NameOf(_model.SYONIN_YMD30))
                _model.SYONIN_NAME40 = .Item(NameOf(_model.SYONIN_NAME40))
                _model.SYONIN_YMD40 = .Item(NameOf(_model.SYONIN_YMD40))
                _model.SYONIN_NAME50 = .Item(NameOf(_model.SYONIN_NAME50))
                _model.SYONIN_YMD50 = .Item(NameOf(_model.SYONIN_YMD50))
                _model.SYONIN_NAME60 = .Item(NameOf(_model.SYONIN_NAME60))
                _model.SYONIN_YMD60 = .Item(NameOf(_model.SYONIN_YMD60))
                _model.SYONIN_NAME90 = .Item(NameOf(_model.SYONIN_NAME90))
                _model.SYONIN_YMD90 = .Item(NameOf(_model.SYONIN_YMD90))
                _model.SYONIN_NAME100 = .Item(NameOf(_model.SYONIN_NAME100))
                _model.SYONIN_YMD100 = .Item(NameOf(_model.SYONIN_YMD100))
                _model.SYONIN_NAME120 = .Item(NameOf(_model.SYONIN_NAME120))
                _model.SYONIN_YMD120 = .Item(NameOf(_model.SYONIN_YMD120))

            End With

            Return _model
        End If




    End Function

    '現在のステージ名を取得
    Public Function FunGetCurrentStageName(ByVal intCurrentStageID As Integer) As String
        Try

            Dim drList As List(Of DataRow) = tblNCR.AsEnumerable().
                                                Where(Function(r) Val(r.Field(Of Integer)("VALUE")) = intCurrentStageID).ToList
            Dim strBUFF As String = ""
            If drList.Count > 0 Then
                strBUFF = drList(0).Item("DISP")
            End If

            Return strBUFF
        Catch ex As Exception
            EM.ErrorSyori(ex, False, conblnNonMsg)
            Return vbEmpty
        End Try
    End Function

    ''' <summary>
    ''' 次ステージ名を取得
    ''' </summary>
    ''' <param name="intCurrentStageID">現ステージID</param>
    ''' <returns></returns>
    Public Function FunGetNextStageName(ByVal intCurrentStageID As Integer) As String
        Try

            Dim drList As List(Of DataRow) = tblNCR.AsEnumerable().
                                                Where(Function(r) Val(r.Field(Of Integer)("VALUE")) > intCurrentStageID).ToList
            Dim strBUFF As String = ""
            If drList.Count > 0 Then
                strBUFF = drList(0).Item("DISP")
            End If

            Return strBUFF
        Catch ex As Exception
            EM.ErrorSyori(ex, False, conblnNonMsg)
            Return vbEmpty
        End Try
    End Function

    ''' <summary>
    ''' ログインユーザーが承認or申請したステージか判定
    ''' </summary>
    ''' <param name="intSYONIN_HOKOKUSYO_ID">承認報告書ID</param>
    ''' <param name="strHOKOKU_NO">報告書No</param>
    ''' <param name="intSYONIN_JUN">承認順No</param>
    ''' <returns></returns>
    Public Function FunblnOwnCreated(ByVal intSYONIN_HOKOKUSYO_ID As Integer, ByVal strHOKOKU_NO As String, ByVal intSYONIN_JUN As Integer) As Boolean
        Dim sbSQL As New System.Text.StringBuilder
        Dim dsList As New DataSet
        sbSQL.Remove(0, sbSQL.Length)
        sbSQL.Append("SELECT")
        sbSQL.Append(" *")
        sbSQL.Append(" FROM " & NameOf(MODEL.D004_SYONIN_J_KANRI) & " ")
        sbSQL.Append(" WHERE SYONIN_HOKOKUSYO_ID=" & intSYONIN_HOKOKUSYO_ID & "")
        sbSQL.Append(" AND HOKOKU_NO='" & strHOKOKU_NO & "'")
        sbSQL.Append(" AND SYONIN_JUN=" & intSYONIN_JUN & "")
        sbSQL.Append(" AND SYAIN_ID=" & pub_SYAIN_INFO.SYAIN_ID & "")
        Using DBa As ClsDbUtility = DBOpen()
            dsList = DBa.GetDataSet(sbSQL.ToString, conblnNonMsg)
        End Using

        Return dsList.Tables(0).Rows.Count > 0

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
        Dim strToSyainName As String
        Dim strFromSyainName As String

        Dim strMsg As String
        Try



            Using DB As ClsDbUtility = DBOpen()
                strSmtpServer = FunGetCodeMastaValue(DB, "メール設定", "SMTP_SERVER")
                intSmtpPort = Val(FunGetCodeMastaValue(DB, "メール設定", "SMTP_PORT"))
                strUserID = FunGetCodeMastaValue(DB, "メール設定", "SMTP_USER")
                strPassword = FunGetCodeMastaValue(DB, "メール設定", "SMTP_PASS")

                '---申請先担当者のメールアドレス取得
                Dim sbSQL As New System.Text.StringBuilder
                Dim dsList As New DataSet
                sbSQL.Remove(0, sbSQL.Length)
                sbSQL.Append("SELECT")
                sbSQL.Append(" SIMEI")
                sbSQL.Append(" ,MAIL_ADDRESS")
                sbSQL.Append(" FROM " & NameOf(MODEL.M004_SYAIN) & " ")
                sbSQL.Append(" WHERE SYAIN_ID=" & ToSYAIN_ID & "")
                Using DBa As ClsDbUtility = DBOpen()
                    dsList = DBa.GetDataSet(sbSQL.ToString, conblnNonMsg)
                End Using
                If dsList.Tables(0).Rows.Count > 0 Then
                    strToAddress = dsList.Tables(0).Rows(0).Item("MAIL_ADDRESS")
                    strToSyainName = dsList.Tables(0).Rows(0).Item("SIMEI")
                Else
                    Return False
                End If

                '---申請元担当者のメールアドレス取得
                sbSQL.Remove(0, sbSQL.Length)
                sbSQL.Append("SELECT")
                sbSQL.Append(" SIMEI")
                sbSQL.Append(" ,MAIL_ADDRESS")
                sbSQL.Append(" FROM " & NameOf(MODEL.M004_SYAIN) & " ")
                sbSQL.Append(" WHERE SYAIN_ID=" & pub_SYAIN_INFO.SYAIN_ID & "")
                Using DBa As ClsDbUtility = DBOpen()
                    dsList = DBa.GetDataSet(sbSQL.ToString, conblnNonMsg)
                End Using
                If dsList.Tables(0).Rows.Count > 0 Then

#If DEBUG Then
                    strFromAddress = FunGetCodeMastaValue(DB, "メール設定", "FROM")
                    'DEBUG: mail送信無効
                    strToAddress = "funato@jms-web.co.jp"
                    'strToAddress = "i2u5r6p1d7l9o6s3@jms-web.slack.com"
#Else
                    strFromAddress = dsList.Tables(0).Rows(0).Item("MAIL_ADDRESS")
#End If

                    strFromSyainName = dsList.Tables(0).Rows(0).Item("SIMEI")
                Else
                    Return False
                End If
            End Using


            strMsg = String.Format("【メール送信成功】TO:{0}({1}) SUBJECT:{2}", strToSyainName, strToAddress, strSubject)
            WL.WriteLogDat(strMsg)

            'DEBUG:
            Return True


            ''認証なし
            'blnSend = ClsMailSend.FunSendMail(strSmtpServer,
            '               intSmtpPort,
            '               strFromAddress,
            '               strToAddress,
            '               CCAddress:=strFromAddress,
            '               BCCAddress:="",
            '               strSubject:=strSubject,
            '               strBody:=strBody,
            '               strAttachment:="",
            '               strFromName:="不適合管理システム")

            '認証あり
            blnSend = ClsMailSend.FunSendMailoverAUTH(strSmtpServer,
                           intSmtpPort,
                           strUserID,
                           strPassword,
                           strFromAddress,
                           strToAddress,
                           strFromAddress,
                           "",
                           strSubject,
                           strBody,
                           "",
                           "不適合管理システム")

            Return blnSend
        Catch ex As Exception
            Throw
            strMsg = String.Format("【メール送信失敗】TO:{0}({1}) SUBJECT:{2}" & vbCrLf & Err.Description, strToSyainName, strToAddress, strSubject)
            WL.WriteLogDat(strMsg)
        End Try
    End Function

#End Region

#Region "管理者権限確認"

    Public Function HasAdminAuth(ByVal intSYAIN_ID As Integer) As Boolean
        Dim sbSQL As New System.Text.StringBuilder
        Dim dsList As New DataSet

        sbSQL.Remove(0, sbSQL.Length)
        sbSQL.Append("SELECT")
        sbSQL.Append(" *")
        sbSQL.Append(" FROM " & NameOf(MODEL.VWM001_SETTING) & " ")
        sbSQL.Append(" WHERE ITEM_NAME='管理者権限'")
        sbSQL.Append(" AND ITEM_DISP='" & intSYAIN_ID & "'")
        Using DBa As ClsDbUtility = DBOpen()
            dsList = DBa.GetDataSet(sbSQL.ToString, conblnNonMsg)
        End Using

        If dsList.Tables(0).Rows.Count > 0 Then
            Return True
        Else
            Return False
        End If
    End Function
#End Region

#Region "承認所属社員取得"
    'TV02_SYONIN_SYOZOKU_SYAIN

    Public Function FunGetSYONIN_SYOZOKU_SYAIN(ByVal Optional BUMON_KB As String = "", ByVal Optional SYONIN_HOUKOKUSYO_ID As Integer = 0, ByVal Optional SYONIN_JUN As Integer = 0) As DataTable
        Dim sbSQL As New System.Text.StringBuilder
        Dim dsList As New DataSet

        Dim dt As DataTableEx

        dt = New DataTableEx("System.Int32")

        sbSQL.Append("SELECT * FROM TV02_SYONIN_SYOZOKU_SYAIN('" & BUMON_KB & "')")
        If SYONIN_HOUKOKUSYO_ID > 0 Then
            sbSQL.Append(" WHERE SYONIN_HOKOKUSYO_ID=" & SYONIN_HOUKOKUSYO_ID & "")
            sbSQL.Append(" AND SYONIN_JUN=" & SYONIN_JUN & "")
        End If
        sbSQL.Append(" ORDER BY SYONIN_HOKOKUSYO_ID,SYONIN_JUN,SYAIN_ID")
        Using DB As ClsDbUtility = DBOpen()
            dsList = DB.GetDataSet(sbSQL.ToString, False)
        End Using

        'dt.Columns.Add("SYONIN_HOKOKUSYO_ID", GetType(Integer))
        'dt.Columns.Add("SYONIN_JUN", GetType(Integer))

        dt.PrimaryKey = {dt.Columns("VALUE")} ', dt.Columns("SYONIN_JUN"), dt.Columns("SYONIN_HOKOKUSYO_ID")

        With dsList.Tables(0)
            For intCNT = 0 To .Rows.Count - 1
                Dim Trow As DataRow = dt.NewRow()
                If Not dt.Rows.Contains(.Rows(intCNT).Item("SYAIN_ID")) Then
                    Trow("VALUE") = .Rows(intCNT).Item("SYAIN_ID")
                    Trow("DISP") = .Rows(intCNT).Item("SIMEI")
                    'Trow("DEF_FLG") = False
                    'Trow("DEL_FLG") = False
                    'Trow("SYONIN_HOKOKUSYO_ID") = .Rows(intCNT).Item("SYONIN_HOKOKUSYO_ID")
                    'Trow("SYONIN_JUN") = .Rows(intCNT).Item("SYONIN_JUN")
                    dt.Rows.Add(Trow)
                End If
            Next intCNT
        End With

        Return dt
    End Function

#End Region




End Module
