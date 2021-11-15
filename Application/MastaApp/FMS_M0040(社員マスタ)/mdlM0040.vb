Imports JMS_COMMON.ClsPubMethod

Module mdlM0040

#Region "定数・変数"

    ''' <summary>
    ''' 一覧画面
    ''' </summary>
    Public frmLIST As FrmM0040

    Public player As System.Media.SoundPlayer = Nothing
    Public pub_buttonSound As String

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
                    WL.WriteLogDat(My.Resources.ErrLogMsgSetOutput)
                    Exit Sub
                End If

                '-----Visualスタイル有効
                Application.EnableVisualStyles()
                '-----GDIを使用
                Application.SetCompatibleTextRenderingDefault(False)

                '-----共通データ取得
                Using DB As ClsDbUtility = DBOpen()
                    Call FunGetCodeDataTable(DB, "社員区分", tblSYAIN_KB, "ITEM_NAME = '社員区分'")
                    Call FunGetCodeDataTable(DB, "役職区分", tblYAKUSYOKU_KB)
                    Call FunGetCodeDataTable(DB, "承認代行区分", tblDAIKO_KB)
                End Using
                pub_buttonSound = FunGetRootPath() & "\buttonSound.wav"
                '-----一覧画面表示
                frmLIST = New FrmM0040
                Application.Run(frmLIST)
            End Using
        Catch ex As Exception
            EM.ErrorSyori(ex, False, conblnNonMsg)
            MsgBox(My.Resources.ErrMsgInit, MsgBoxStyle.Critical, My.Application.Info.AssemblyName)
        End Try
    End Sub

#End Region

#Region "サウンド再生"

    'WAVEファイルを再生する
    Public Sub PlaySound(ByVal waveFile As String)
        '再生されているときは止める
        If Not (player Is Nothing) Then
            StopSound()
        End If

        '読み込む
        player = New System.Media.SoundPlayer(waveFile)
        '非同期再生する
        player.Play()

        '次のようにすると、ループ再生される
        'player.PlayLooping()

        '次のようにすると、最後まで再生し終えるまで待機する
        'player.PlaySync()
    End Sub

    '再生されている音を止める
    Public Sub StopSound()
        If Not (player Is Nothing) Then
            player.Stop()
            player.Dispose()
            player = Nothing
        End If
    End Sub

#End Region

#Region "ユーザーID検索"

    Public Function FunGetUSER(ByVal strCARD_ID As String) As DataRow
        Dim sbSQL As New System.Text.StringBuilder
        Dim dsList As System.Data.DataSet = Nothing

        Try
            '検索
            sbSQL.Append("SELECT IC_CARD_ID")
            sbSQL.Append(" FROM M004_SYAIN")
            sbSQL.Append($" WHERE IC_CARD_ID = '{strCARD_ID}'")

            Using DB As ClsDbUtility = DBOpen()
                dsList = DB.GetDataSet(sbSQL.ToString)
            End Using

            If dsList.Tables(0).Rows.Count > 0 Then
                Return dsList.Tables(0).Rows(0)
            Else
                Return Nothing
            End If
        Catch ex As Exception
            EM.ErrorSyori(ex)
            Return Nothing
        End Try
    End Function

    Public Function FunGetUSER_byUSERID(ByVal SYAIN_NO As String) As DataRow
        Dim sbSQL As New System.Text.StringBuilder
        Dim dsList As System.Data.DataSet = Nothing

        Try
            sbSQL.Append("SELECT IC_CARD_ID")
            sbSQL.Append(" FROM M004_SYAIN")
            sbSQL.Append($" WHERE SYAIN_NO = '{SYAIN_NO}'")
            Using DB As ClsDbUtility = DBOpen()
                dsList = DB.GetDataSet(sbSQL.ToString)
            End Using

            If dsList.Tables(0).Rows.Count > 0 Then
                Return dsList.Tables(0).Rows(0)
            Else
                Return Nothing
            End If
        Catch ex As Exception
            EM.ErrorSyori(ex)
            Return Nothing
        End Try
    End Function

#End Region

End Module