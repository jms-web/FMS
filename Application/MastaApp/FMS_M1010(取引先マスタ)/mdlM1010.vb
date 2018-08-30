Imports JMS_COMMON.ClsPubMethod

Module mdlM1010

#Region "定数・変数"

    ''' <summary>
    ''' 一覧画面
    ''' </summary>
    Public frmLIST As FrmM1010

    Public priTableName As String = NameOf(Model.VWM02_TORIHIKI)

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
                    Call FunGetCodeDataTable(DB, "取引種別", tblTORI_SYU)
                    Call FunGetCodeDataTable(DB, "発注先CD", tblHACYU_CD)
                    Call FunGetCodeDataTable(DB, "仕入外注区分", tblNAIGAI_KB)
                    Call FunGetCodeDataTable(DB, "税区分", tblURI_KBN)
                    Call FunGetCodeDataTable(DB, "税区分", tblSHI_KBN)
                    Call FunGetCodeDataTable(DB, "端数処理区分", tblTAX_HASU_KB)
                    Call FunGetCodeDataTable(DB, "取引先略名", tblTORI_SAKI)
                    Call FunGetCodeDataTable(DB, "取引先CD", tblTORI_SAKI_CD)
                    Call FunGetCodeDataTable(DB, "担当", tblTANTO)
                    Call FunGetCodeDataTable(DB, "属性", tblZOKUSEI, "ZOKUSEI_FLG & " & Context.ENM_ZOKUSEI_FLG._1_製品 & "<>0 ")
                    Call FunGetCodeDataTable(DB, "属性項目", tblZOKUSEI_K)
                End Using

                '-----一覧画面表示
                frmLIST = New FrmM1010
                Application.Run(frmLIST)

            End Using
        Catch ex As Exception
            EM.ErrorSyori(ex, False, conblnNonMsg)
            MsgBox(My.Resources.ErrMsgInit, MsgBoxStyle.Critical, My.Application.Info.AssemblyName)
        End Try
    End Sub
#End Region

End Module
