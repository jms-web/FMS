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

                    Call FunGetCodeDataTable(DB, "承認担当", tblTANTO_SYONIN)
                    Call FunGetCodeDataTable(DB, "顧客判定指示区分", tblKOKYAKU_HANTEI_SIJI_KB)
                    Call FunGetCodeDataTable(DB, "顧客最終判定区分", tblKOKYAKU_SAISYU_HANTEI_KB)
                    Call FunGetCodeDataTable(DB, "要否区分", tblYOHI_KB)
                    Call FunGetCodeDataTable(DB, "検査結果区分", tblKENSA_KEKKA_KB)
                    Call FunGetCodeDataTable(DB, "根本要因区分", tblKONPON_YOIN_KB)
                    Call FunGetCodeDataTable(DB, "帰責工程区分", tblKISEKI_KOUTEI_KB)

                    Call FunGetCodeDataTable(DB, "原因分析区分", tblGENIN_BUNSEKI_KB)
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

End Module
