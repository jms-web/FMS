Imports JMS_COMMON.ClsPubMethod

Module mdlM00101

#Region "定数・変数"

    ''' <summary>
    ''' 一覧画面
    ''' </summary>
    Public frmLIST As FrmM00101

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
                    Call FunGetCodeDataTable(DB, "部門区分", tblBUMON, "ITEM_VALUE<8 ")
                End Using

                '-----一覧画面表示
                frmLIST = New FrmM00101
                Application.Run(frmLIST)

            End Using
        Catch ex As Exception
            EM.ErrorSyori(ex, False, conblnNonMsg)
            MsgBox(My.Resources.ErrMsgInit, MsgBoxStyle.Critical, My.Application.Info.AssemblyName)
        Finally

        End Try
    End Sub
#End Region

    Public Function pub_FUTEKIGO_KB_HENKAN(strSEIHIN_KB As String, strFUTEKIGO_KB As String) As String
        Dim strWork As String
        Try
            Select Case strSEIHIN_KB
                Case "1"    '風防
                    strWork = "風防_"
                    Select Case strFUTEKIGO_KB
                        Case "0"    '外観
                            strWork = strWork & "不適合外観区分"
                        Case "1"    '寸法 
                            strWork = strWork & "不適合寸法区分"
                        Case "2"    '形状
                            strWork = strWork & "不適合形状区分"
                        Case "3"    '機能・性能
                            strWork = strWork & "不適合機能性能区分"
                        Case Else '"9"    'その他
                            strWork = strWork & "不適合その他区分"
                    End Select

                Case "2"    'LP
                    strWork = "LP_"
                    Select Case strFUTEKIGO_KB
                        Case "0"    '外観
                            strWork = strWork & "不適合外観区分"
                        Case "1"    '寸法 
                            strWork = strWork & "不適合寸法区分"
                        Case "2"    '形状
                            strWork = strWork & "不適合形状区分"
                        Case "3"    '機能・性能
                            strWork = strWork & "不適合機能性能区分"
                        Case Else '"9"    'その他
                            strWork = strWork & "不適合その他区分"
                    End Select

                Case "3"    '複合材
                    strWork = "複合材_"
                    Select Case strFUTEKIGO_KB
                        Case "0"    '寸法
                            strWork = strWork & "不適合寸法区分"
                        Case "1"    '形状 
                            strWork = strWork & "不適合形状区分"
                        Case "2"    '穿孔
                            strWork = strWork & "不適合穿孔区分"
                        Case "3"    '外観
                            strWork = strWork & "不適合外観区分"
                        Case "4"    '内部欠陥
                            strWork = strWork & "不適合内部欠陥区分"
                        Case "5"
                            strWork = strWork & "不適合硬化条件区分"
                        Case "6"
                            strWork = strWork & "不適合プロセス区分"
                        Case Else '"9"    'その他
                            strWork = strWork & "不適合その他区分"
                    End Select
                Case Else
                    strWork = ""
            End Select

            Return strWork

        Catch ex As Exception
            EM.ErrorSyori(ex, False, conblnNonMsg)
            Return False
        End Try
    End Function


End Module
