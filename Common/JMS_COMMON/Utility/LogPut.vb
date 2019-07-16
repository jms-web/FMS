Imports System.Collections.Generic
Imports System.IO
Imports System.Net
Imports System.Threading
Imports JMS_COMMON.ClsPubMethod

'エラーログ出力/エラーMSGBOX
Public Class ErrMsg
    Private Const DefaultLogMax As Long = 10000

    Private LogFilePath As String
    Private LogFileName As String
    Private LogMax As Long

    'DEBUG時メッセージ表示
    Private pri_blnNonMsg As Boolean = True

    'コンストラクタ
    Public Sub New(Optional ByVal strLogFileName As String = "", Optional ByVal lngLogMax As Long = 10000)

        '-----ファイルパス
        LogFilePath = FunGetRootPath()
        LogFilePath = LogFilePath & "\LOG"
        '無し時は作成
        If System.IO.Directory.Exists(LogFilePath) = False Then
            System.IO.Directory.CreateDirectory(LogFilePath)
        End If

        '-----ファイル名
        If Trim(strLogFileName).IsNulOrWS Then
            LogFileName = My.Application.Info.AssemblyName & ".ERRLOG"
        Else
            LogFileName = strLogFileName
        End If
        LogFileName = FunValidFileName(LogFileName)

        '-----ファイル行数
        If lngLogMax > 0 Then
            LogMax = lngLogMax
        Else
            LogMax = DefaultLogMax
        End If

    End Sub

    'エラー発生時の処理
    Public Sub Old_20150515_ErrorSyori(ByVal expEX As Exception, Optional ByVal blnNonLog As Boolean = False, Optional ByVal blnNonMsg As Boolean = False)
        Dim LP As New LogPut
        Dim strDLGTYTLE As String
        Dim sbDLGMSG As New System.Text.StringBuilder
        Dim strLOGDTTM As String
        Dim sbLOGMSG As New System.Text.StringBuilder
        Dim sbLOGSTACK As New System.Text.StringBuilder
        Dim strBUFF As String

        Try
            '-----MSG作成
            With expEX
                'ログ日時
                strLOGDTTM = System.DateTime.Now.ToString
                'ログ内容
                sbLOGMSG.Append("[" & .Source() & "  " & .TargetSite().ToString & "]  ")
                sbLOGMSG.Append(.GetType.ToString & "  " & .Message() & " ")
                Try
                    strBUFF = .InnerException.Message
                    sbLOGMSG.Append("(" & strBUFF & ")")
                Catch iexEx As Exception
                End Try
                sbLOGMSG.AppendLine()
                sbLOGMSG.Append(.StackTrace)

                'MSGBOXタイトル
                strDLGTYTLE = .Source() & "  " & .TargetSite.Name
                'MSGBOX内容
                sbDLGMSG.Append(.GetType.ToString & "  " & .Message() & " ")
                Try
                    strBUFF = .InnerException.Message
                    sbDLGMSG.Append("(" & strBUFF & ")")
                Catch iexEx As Exception
                End Try
                sbDLGMSG.AppendLine()
                sbDLGMSG.AppendLine()
                sbDLGMSG.Append("上記のエラー内容を控えた上でシステム開発元へご連絡下さい")
            End With

            '-----エラーログ書込
            If blnNonLog = False Then
                LP.LogPut(strLOGDTTM, sbLOGMSG.ToString, LogFilePath & "\" & LogFileName, LogMax)
            End If

            '-----エラーメッセージ表示
            If blnNonMsg = False Then
                System.Windows.Forms.Cursor.Current = Cursors.Default
                MsgBox(sbDLGMSG.ToString, MsgBoxStyle.Critical + MsgBoxStyle.SystemModal, strDLGTYTLE)
            End If
        Catch Ex As Exception
        End Try

    End Sub

    Public Shared Function FunGetErrMsg(ByVal ex As Exception) As String
        Dim strBUFF As String
        Dim sbLOGMSG As New System.Text.StringBuilder

        With ex
            strBUFF = ""
            'ログ内容
            sbLOGMSG.Append("[" & .Source() & "  " & .TargetSite().ToString & "]  ")
            sbLOGMSG.Append(.GetType.ToString & "  " & .Message() & " ")
            Try
                strBUFF = .InnerException.Message
                sbLOGMSG.Append("(" & strBUFF & ")")
            Catch iexEx As Exception
            End Try
            sbLOGMSG.AppendLine()
            sbLOGMSG.Append(.StackTrace)

            Return sbLOGMSG.ToString
        End With
    End Function

    ''' <summary>
    ''' エラー発生時の処理
    ''' </summary>
    ''' <param name="expEX">Exception</param>
    ''' <param name="blnNonLog">ログ登録判定…規定値:False</param>
    ''' <param name="blnNonMsg">メッセージ表示判定…規定値:False</param>
    ''' <param name="ConProductName"></param>
    Public Sub ErrorSyori(ByVal expEX As Exception, Optional ByVal blnNonLog As Boolean = False, Optional ByVal blnNonMsg As Boolean = False, Optional ByVal ConProductName As String = "")
        Dim LP As New LogPut
        Dim strDLGTYTLE As String
        Dim sbDLGMSG As New System.Text.StringBuilder
        Dim strLOGDTTM As String
        Dim sbLOGMSG As New System.Text.StringBuilder
        Dim sbLOGSTACK As New System.Text.StringBuilder
        Dim strBUFF As String

        Try
            '-----MSG作成
            With expEX
                'ログ日時
                strLOGDTTM = System.DateTime.Now.ToString
                'ログ内容
                sbLOGMSG.Append("[" & .Source() & "  " & .TargetSite().ToString & "]  ")
                sbLOGMSG.Append(.GetType.ToString & "  " & .Message() & " ")
                Try
                    strBUFF = .InnerException.Message
                    sbLOGMSG.Append("(" & strBUFF & ")")
                Catch iexEx As Exception
                End Try
                sbLOGMSG.AppendLine()
                sbLOGMSG.Append(.StackTrace)

                'MSGBOXタイトル
                strDLGTYTLE = pub_APP_INFO.strTitle '　My.Application.Info.AssemblyName

                'MSGBOX内容
                sbDLGMSG.Append(String.Format("OSVersion：{0}", System.Environment.OSVersion))
                sbDLGMSG.AppendLine()
                sbDLGMSG.Append(String.Format("端末名：{0}", System.Environment.MachineName))
                sbDLGMSG.AppendLine()
                sbDLGMSG.Append(String.Format("処理名：「{0}」にて例外エラーが発生しました", .Source() & ":" & .TargetSite.Name))
                sbDLGMSG.AppendLine()
                sbDLGMSG.Append("上記情報を控えて、システム管理者へご連絡下さい")
                sbDLGMSG.AppendLine()
                sbDLGMSG.AppendLine()
                sbDLGMSG.Append("<エラー情報詳細>")
                sbDLGMSG.AppendLine()
                sbDLGMSG.Append(.GetType.ToString & "  " & .Message() & " ")
                Try
                    strBUFF = .InnerException.Message
                    sbDLGMSG.Append("(" & strBUFF & ")")
                Catch iexEx As Exception
                End Try
            End With

            '-----エラーログファイル書込
            If blnNonLog = False Then
                LP.LogPut(strLOGDTTM, sbLOGMSG.ToString, LogFilePath & "\" & LogFileName, LogMax)
            End If

            '-----エラーメッセージ表示
            If blnNonMsg = False Then
                System.Windows.Forms.Cursor.Current = Cursors.Default

                Fun_GetSystemIniFile()
                Using DB As ClsDbUtility = DBOpen()
                    If FunGetCodeMastaValue(DB, "メール設定", "ENABLE").ToString.Trim.ToUpper = "FALSE" Then
                        MsgBox(sbDLGMSG.ToString, MsgBoxStyle.Critical + MsgBoxStyle.SystemModal, strDLGTYTLE)
                    Else
                        Call SendFeedback(expEX)

                        Dim msg As String = $"システム例外エラーが発生しました。{vbCrLf}システム担当者にフィードバック情報を送信します。{vbCrLf}"
                        MsgBox(msg, MsgBoxStyle.Critical + MsgBoxStyle.SystemModal, strDLGTYTLE)

                        Dim imgDlg As New ImageDialog
                        imgDlg.Show("\\sv04\FMS\RESOURCE\sendmail_256.gif", 4200)
                    End If
                End Using
            End If
        Catch Ex As Exception
        End Try
    End Sub

    Private Function SendFeedback(expEX As Exception) As Boolean
        Dim sbSQL As New System.Text.StringBuilder
        Dim dsList As New DataSet
        Try
            'スクリーンショット取得
            Dim screenshot As Bitmap = CaptureScreen.CaptureActiveWindow
            Dim captureFile As String = $"{FunGetRootPath()}\LOG\スクリーンショット.png"
            screenshot.Save(captureFile, System.Drawing.Imaging.ImageFormat.Png)
            screenshot.Dispose()

            ''Base64文字列に変換して埋め込み
            'Dim fi As New FileInfo(captureFile)
            'Dim fs As FileStream = fi.OpenRead
            'Dim nBytes As Integer = fi.Length
            'Dim ByteArray(nBytes) As Byte
            'Dim nBytesRead As Integer = fs.Read(ByteArray, 0, nBytes)
            'fs.Close()
            'fs.Dispose()
            'Dim base64String As String
            'base64String = System.Convert.ToBase64String(ByteArray)

            'ログファイル
            Dim errlogFile As String = $"{FunGetRootPath()}\LOG\{CON_ERR_LOG}"
            Dim applogFile As String = $"{FunGetRootPath()}\LOG\FMS_G0010.LOG"

            'メール送信
            Fun_GetSystemIniFile()
            Using DB As ClsDbUtility = DBOpen()
                Dim strSmtpServer As String = FunGetCodeMastaValue(DB, "メール設定", "SMTP_SERVER")
                Dim intSmtpPort As String = Val(FunGetCodeMastaValue(DB, "メール設定", "SMTP_PORT"))
                Dim strFromAddress As String = FunGetCodeMastaValue(DB, "メール設定", "FROM")
                Dim ToAddressList As New List(Of String)
                Dim CCAddressList As New List(Of String)
                Dim BCCAddressList As New List(Of String)

                Dim strSubject As String = "不適合管理システム 例外エラー発生"
                Dim strBody As String = <body><![CDATA[
                    <br />
                    フジワラシステムにて下記の例外エラーが発生しました。<br />                    　
                    <br />
                    <b>【発生日時】</b><br />
                        {0}<br />
                        <br />
                    <b>【端末情報】</b><br />
                        {1}:{2}<br />
                        <br />
                    <b>【ユーザー情報】</b><br />
                        部門：{3}<br />
                        <a href = "mailto:{4}" >{5}</a><br />
                        <br />
                    <b>【処理名】</b><br />
                        {6}<br />
                        <br />
                    <b>【エラー詳細】</b><br />
                        {7}<br />
                        {8}<br />
                        {9}<br />
                        <br />
                    ]]></body>.Value.Trim
                Dim stacktrace As String = expEX.StackTrace.Replace("場所", $"<br />{vbCrLf}場所")

                '<b>【スクリーンショット】<br />
                ' <img src = "data:image/png;base64,{10}" /<> br />


                'ユーザー情報取得
                sbSQL.Clear()
                sbSQL.Append($"SELECT")
                sbSQL.Append($" M4.SIMEI")
                sbSQL.Append($",M4.MAIL_ADDRESS")
                sbSQL.Append($",M5.BUSYO_ID")
                sbSQL.Append($",M2.BUSYO_NAME")
                sbSQL.Append($",GL.SIMEI AS GL_SIMEI")
                sbSQL.Append($",GL.MAIL_ADDRESS AS GL_ADDRESS")
                sbSQL.Append($" FROM M004_SYAIN AS M4")
                sbSQL.Append($" LEFT JOIN dbo.M005_SYOZOKU_BUSYO AS M5 ON (M4.SYAIN_ID = M5.SYAIN_ID)")
                sbSQL.Append($" LEFT JOIN dbo.M002_BUSYO AS M2 ON (M2.BUSYO_ID = M5.BUSYO_ID)")
                sbSQL.Append($" LEFT JOIN dbo.M004_SYAIN AS GL ON (GL.SYAIN_ID = M2.SYOZOKUCYO_ID)")
                sbSQL.Append($" WHERE M4.SYAIN_ID={JMS_COMMON.Parameter.PrSyainId}")
                sbSQL.Append($" AND M5.KENMU_FLG='0'")
                dsList = DB.GetDataSet(sbSQL.ToString, True)

                Dim address As IPHostEntry = System.Net.Dns.GetHostEntry(System.Environment.MachineName)
                Dim ip4Address As String = "-"
                For Each ip As IPAddress In address.AddressList
                    If ip.AddressFamily = Net.Sockets.AddressFamily.InterNetwork Then
                        ip4Address = ip.ToString
                        Exit For
                    End If
                Next

                Dim strBusyoName As String = dsList.Tables(0).Rows(0).Item("BUSYO_NAME")
                Dim strSyainName As String = dsList.Tables(0).Rows(0).Item("SIMEI")
                Dim strMailAddress As String = dsList.Tables(0).Rows(0).Item("MAIL_ADDRESS")

                '通知先
                sbSQL.Clear()
                sbSQL.Append($"SELECT M004.{NameOf(MODEL.M004_SYAIN.MAIL_ADDRESS)} ")
                sbSQL.Append($" FROM {NameOf(MODEL.M001_SETTING)} M001")
                sbSQL.Append($" LEFT JOIN {NameOf(MODEL.M004_SYAIN)} M004")
                sbSQL.Append($" ON(M001.{NameOf(MODEL.M001_SETTING.ITEM_DISP)} = M004.{NameOf(MODEL.M004_SYAIN.SYAIN_ID)})")
                sbSQL.Append($" WHERE M001.{NameOf(MODEL.M001_SETTING.ITEM_NAME)}='エラー通知先'")
                sbSQL.Append($" AND M001.{NameOf(MODEL.M001_SETTING.DEL_SYAIN_ID)}=0")
                sbSQL.Append($" AND M001.{NameOf(MODEL.M001_SETTING.ITEM_VALUE)}=1") 'DEBUG

                dsList = DB.GetDataSet(sbSQL.ToString, True)
                For Each row As DataRow In dsList.Tables(0).Rows
                    If Not row.Item(0).ToString.IsNulOrWS AndAlso Not ToAddressList.Contains(row.Item(0)) Then
                        ToAddressList.Add(row.Item(0))
                    End If
                Next

                strBody = String.Format(strBody,
                                          Now.ToString("yyyy/MM/dd HH:mm:ss"),'日時
                                          System.Environment.MachineName,'端末名
                                          ip4Address,'IPアドレス
                                          strBusyoName,'部署名
                                          strMailAddress,'メールアドレス
                                          strSyainName,'社員名
                                          $"{expEX.Source()}：{expEX.TargetSite.Name}",'処理名(関数)
                                          expEX.GetType,'エラー型
                                          expEX.Message,'エラーメッセージ
                                          stacktrace'スタックトレース
                                          )

                ClsMailSend.FunSendMail(strSmtpServer:=strSmtpServer,
                    intSmtpPort:=intSmtpPort,
                    FromAddress:=strFromAddress,
                    ToAddress:=ToAddressList,
                    CCAddress:=CCAddressList,
                    BCCAddress:=BCCAddressList,
                    strSubject:=strSubject,
                    strBody:=strBody,
                    AttachmentList:=New List(Of String) From {captureFile, errlogFile, applogFile},
                    strFromName:="フジワラシステム",
                    isHTML:=True)
            End Using

            If IO.File.Exists(captureFile) Then IO.File.Delete(captureFile)

            Return True
        Catch ex As Exception
            Return False
        End Try
    End Function

    'ファイル名チェック
    Private Function FunValidFileName(ByVal strFileName As String) As String
        Dim chrInvalid As Char()
        Dim strValidFileName As String

        Try
            '不正文字取得
            chrInvalid = System.IO.Path.GetInvalidFileNameChars()

            '不正文字→｢_｣
            strValidFileName = strFileName
            For Each c As Char In chrInvalid
                strValidFileName = strValidFileName.Replace(c, "_")
            Next

            Return strValidFileName
        Catch ex As Exception
            Return ""
        End Try

    End Function

End Class

'ログ出力
Public Class WriteLog
    Private Const DefaultLogMax As Long = 10000

    Private LogFilePath As String
    Private LogFileName As String
    Private LogMax As Long

    'マルチスレッドロックに使用するオブジェクト
    Private ReadOnly syncObject As New Object

    'コンストラクタ
    Public Sub New(Optional ByVal strLogFileName As String = "", Optional ByVal lngLogMax As Long = 10000)

        '-----ファイルパス
        LogFilePath = FunGetRootPath()
        LogFilePath = LogFilePath & "\LOG"
        '無し時は作成
        If System.IO.Directory.Exists(LogFilePath) = False Then
            System.IO.Directory.CreateDirectory(LogFilePath)
        End If

        '-----ファイル名
        If Trim(strLogFileName).IsNulOrWS Then
            LogFileName = My.Application.Info.AssemblyName & ".LOG"
        Else
            LogFileName = strLogFileName
        End If
        LogFileName = FunValidFileName(LogFileName)

        '-----ファイル行数
        If lngLogMax > 0 Then
            LogMax = lngLogMax
        Else
            LogMax = DefaultLogMax
        End If

    End Sub

    'ログ出力時の処理
    Public Sub WriteLogDat(ByVal strMSG As String)
        Dim LP As New LogPut

        Try
            'マルチスレッド実行時排他ロック制御
            SyncLock syncObject
                '-----ログ書込
                LP.LogPut(System.DateTime.Now.ToString, strMSG, LogFilePath & "\" & LogFileName, LogMax)

            End SyncLock
        Catch Ex As Exception
        End Try

    End Sub

    'ファイル名チェック
    Private Function FunValidFileName(ByVal strFileName As String) As String
        Dim chrInvalid As Char()
        Dim strValidFileName As String

        Try
            '不正文字取得
            chrInvalid = System.IO.Path.GetInvalidFileNameChars()

            '不正文字→｢_｣
            strValidFileName = strFileName
            For Each c As Char In chrInvalid
                strValidFileName = strValidFileName.Replace(c, "_")
            Next

            Return strValidFileName
        Catch ex As Exception
            Return ""
        End Try

    End Function

End Class

'ログ
Public Class LogPut
    Private strLOGDTTM As String
    Private strLOGMSG As String
    Private LogFile As String
    Private LogMax As Long

    'XMLファイルに保存するオブジェクトのためのクラス
    <System.Xml.Serialization.XmlRoot("LOGDATA")>
    Public Class LogDataClasses

        <System.Xml.Serialization.XmlArrayItem(GetType(LogDataClass))>
        Public ClassList As New ArrayList

    End Class

    'XMLファイルに保存するオブジェクトのためのクラス
    <System.Xml.Serialization.XmlTypeAttribute("LOG")>
    Public Class LogDataClass

        <System.Xml.Serialization.XmlElement("DATETIME")>
        Public strLOGDTTM As String

        <System.Xml.Serialization.XmlElement("MESSAGE")>
        Public strLOGMSG As String

    End Class

    'ログソート
    Public Class LogDataComparer
        Implements IComparer

        Public Function Compare(ByVal x As Object, ByVal y As Object) As Integer Implements IComparer.Compare
            Dim logData1 As LogDataClass = CType(x, LogDataClass)
            Dim logData2 As LogDataClass = CType(y, LogDataClass)
            Dim strBUFF1 As String
            Dim strBUFF2 As String

            strBUFF1 = logData1.strLOGDTTM
            strBUFF2 = logData2.strLOGDTTM

            If strBUFF1 < strBUFF2 Then
                Return -1
            ElseIf strBUFF1 > strBUFF2 Then
                Return 1
            ElseIf strBUFF1 = strBUFF2 Then
                Return 0
            End If

        End Function

    End Class

    '出力
    Public Sub LogPut(ByVal strDTTM As String, ByVal strMSG As String, ByVal sFile As String, ByVal lMax As Long)

        Try
            strLOGDTTM = strDTTM
            strLOGMSG = strMSG
            LogFile = sFile
            LogMax = lMax

            '-----出力スレッド開始
            Dim thread As New Thread(New ThreadStart(AddressOf SubLogPut))
            thread.Start()
        Catch ex As Exception

        End Try

    End Sub

    '出力スレッド
    Private Sub SubLogPut()
        Dim fsFile As IO.FileStream = Nothing
        Dim xsLogData As System.Xml.Serialization.XmlSerializer
        Dim logClasses As LogDataClasses
        Dim logClass As New LogDataClass

        Try
            '-----ログファイルOPEN
            Do
                Application.DoEvents()
                System.Threading.Thread.Sleep(5)
                Try
                    'OPEN
                    fsFile = New IO.FileStream(LogFile, IO.FileMode.OpenOrCreate, FileAccess.ReadWrite, FileShare.None)
                Catch openEx As System.IO.IOException 'LOCK時
                    Continue Do
                End Try

                Exit Do
            Loop

            '-----ログ取得
            xsLogData = New System.Xml.Serialization.XmlSerializer(GetType(LogDataClasses))
            Try
                '取得
                logClasses = xsLogData.Deserialize(fsFile)
            Catch dsEx As System.InvalidOperationException '新規ファイル時
                logClasses = New LogDataClasses
            End Try

            '-----ログ削除
            If logClasses.ClassList.Count = LogMax Then '最大件数時
                logClasses.ClassList.RemoveAt(0)
            ElseIf logClasses.ClassList.Count > LogMax Then '最大件数超え時
                logClasses.ClassList.RemoveRange(0, logClasses.ClassList.Count - LogMax + 1)
            End If

            '-----ログ追加
            logClass.strLOGDTTM = strLOGDTTM
            logClass.strLOGMSG = strLOGMSG
            logClasses.ClassList.Add(logClass)
            'TEST
            'For lngCNT As Long = 1 To 99990
            '    logClasses.ClassList.Add(logClass)
            'Next

            '-----ログソート
            'Dim LogDataComp As IComparer = New LogDataComparer()
            'logClasses.ClassList.Sort(LogDataComp)

            '-----ログファイル書込
            '先頭ポインタ移動
            fsFile.Seek(0, SeekOrigin.Begin)
            '書込
            xsLogData.Serialize(fsFile, logClasses)
            fsFile.SetLength(fsFile.Position)
            fsFile.Flush()
        Catch Ex As Exception
        Finally
            '-----ログファイルCLOSE
            If Not fsFile Is Nothing Then
                fsFile.Close()
            End If
        End Try

    End Sub

End Class