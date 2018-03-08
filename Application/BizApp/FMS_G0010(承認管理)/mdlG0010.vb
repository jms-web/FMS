Imports JMS_COMMON.ClsPubMethod

Module mdlG0010

#Region "定数・変数"

    ''' <summary>
    ''' 一覧画面
    ''' </summary>
    Public frmLIST As FrmG0010

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
