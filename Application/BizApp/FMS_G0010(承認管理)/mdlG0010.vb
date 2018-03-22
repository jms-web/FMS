Imports JMS_COMMON.ClsPubMethod

Module mdlG0010

#Region "定数・変数"

    ''' <summary>
    ''' 一覧画面
    ''' </summary>
    Public frmLIST As FrmG0010


    'DEBUG:
    Public ST01_REGISTERED As Boolean
    Public ST02_REGISTERED As Boolean
    Public ST03_REGISTERED As Boolean
    Public ST04_REGISTERED As Boolean

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
                    Call FunGetCodeDataTable(DB, "部門区分", tblBUMON)
                    Call FunGetCodeDataTable(DB, "機種", tblKISYU)
                    Call FunGetCodeDataTable(DB, "不適合区分", tblFUTEKIGO_KB)
                    Call FunGetCodeDataTable(DB, "不適合状態区分", tblFUTEKIGO_STATUS_KB)
                    Call FunGetCodeDataTable(DB, "事前審査判定区分", tblJIZEN_SINSA_HANTEI_KB)
                    Call FunGetCodeDataTable(DB, "再審委員会判定区分", tblSAISIN_IINKAI_HANTEI_KB)
                    Call FunGetCodeDataTable(DB, "部品番号", tblBUHIN)
                    Call FunGetCodeDataTable(DB, "承認担当", tblTANTO_SYONIN)

                End Using

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
