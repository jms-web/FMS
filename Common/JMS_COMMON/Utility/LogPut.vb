Imports System.IO
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
        If Trim(strLogFileName).IsNullOrWhiteSpace Then
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
                MsgBox(sbDLGMSG.ToString, MsgBoxStyle.Critical + MsgBoxStyle.SystemModal, strDLGTYTLE)
            End If

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
        If Trim(strLogFileName).IsNullOrWhiteSpace Then
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
    <System.Xml.Serialization.XmlRoot("LOGDATA")> _
    Public Class LogDataClasses
        <System.Xml.Serialization.XmlArrayItem(GetType(LogDataClass))> _
        Public ClassList As New ArrayList
    End Class

    'XMLファイルに保存するオブジェクトのためのクラス
    <System.Xml.Serialization.XmlTypeAttribute("LOG")> _
    Public Class LogDataClass
        <System.Xml.Serialization.XmlElement("DATETIME")> _
        Public strLOGDTTM As String
        <System.Xml.Serialization.XmlElement("MESSAGE")> _
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


