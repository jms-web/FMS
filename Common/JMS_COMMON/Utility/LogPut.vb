Imports System.Collections.Generic
Imports System.IO
Imports System.Net
Imports System.Threading
Imports JMS_COMMON.ClsPubMethod

'�G���[���O�o��/�G���[MSGBOX
Public Class ErrMsg
    Private Const DefaultLogMax As Long = 10000

    Private LogFilePath As String
    Private LogFileName As String
    Private LogMax As Long

    'DEBUG�����b�Z�[�W�\��
    Private pri_blnNonMsg As Boolean = True

    '�R���X�g���N�^
    Public Sub New(Optional ByVal strLogFileName As String = "", Optional ByVal lngLogMax As Long = 10000)

        '-----�t�@�C���p�X
        LogFilePath = FunGetRootPath()
        LogFilePath = LogFilePath & "\LOG"
        '�������͍쐬
        If System.IO.Directory.Exists(LogFilePath) = False Then
            System.IO.Directory.CreateDirectory(LogFilePath)
        End If

        '-----�t�@�C����
        If Trim(strLogFileName).IsNulOrWS Then
            LogFileName = My.Application.Info.AssemblyName & ".ERRLOG"
        Else
            LogFileName = strLogFileName
        End If
        LogFileName = FunValidFileName(LogFileName)

        '-----�t�@�C���s��
        If lngLogMax > 0 Then
            LogMax = lngLogMax
        Else
            LogMax = DefaultLogMax
        End If

    End Sub

    '�G���[�������̏���
    Public Sub Old_20150515_ErrorSyori(ByVal expEX As Exception, Optional ByVal blnNonLog As Boolean = False, Optional ByVal blnNonMsg As Boolean = False)
        Dim LP As New LogPut
        Dim strDLGTYTLE As String
        Dim sbDLGMSG As New System.Text.StringBuilder
        Dim strLOGDTTM As String
        Dim sbLOGMSG As New System.Text.StringBuilder
        Dim sbLOGSTACK As New System.Text.StringBuilder
        Dim strBUFF As String

        Try
            '-----MSG�쐬
            With expEX
                '���O����
                strLOGDTTM = System.DateTime.Now.ToString
                '���O���e
                sbLOGMSG.Append("[" & .Source() & "  " & .TargetSite().ToString & "]  ")
                sbLOGMSG.Append(.GetType.ToString & "  " & .Message() & " ")
                Try
                    strBUFF = .InnerException.Message
                    sbLOGMSG.Append("(" & strBUFF & ")")
                Catch iexEx As Exception
                End Try
                sbLOGMSG.AppendLine()
                sbLOGMSG.Append(.StackTrace)

                'MSGBOX�^�C�g��
                strDLGTYTLE = .Source() & "  " & .TargetSite.Name
                'MSGBOX���e
                sbDLGMSG.Append(.GetType.ToString & "  " & .Message() & " ")
                Try
                    strBUFF = .InnerException.Message
                    sbDLGMSG.Append("(" & strBUFF & ")")
                Catch iexEx As Exception
                End Try
                sbDLGMSG.AppendLine()
                sbDLGMSG.AppendLine()
                sbDLGMSG.Append("��L�̃G���[���e���T������ŃV�X�e���J�����ւ��A��������")
            End With

            '-----�G���[���O����
            If blnNonLog = False Then
                LP.LogPut(strLOGDTTM, sbLOGMSG.ToString, LogFilePath & "\" & LogFileName, LogMax)
            End If

            '-----�G���[���b�Z�[�W�\��
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
            '���O���e
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
    ''' �G���[�������̏���
    ''' </summary>
    ''' <param name="expEX">Exception</param>
    ''' <param name="blnNonLog">���O�o�^����c�K��l:False</param>
    ''' <param name="blnNonMsg">���b�Z�[�W�\������c�K��l:False</param>
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
            '-----MSG�쐬
            With expEX
                '���O����
                strLOGDTTM = System.DateTime.Now.ToString
                '���O���e
                sbLOGMSG.Append("[" & .Source() & "  " & .TargetSite().ToString & "]  ")
                sbLOGMSG.Append(.GetType.ToString & "  " & .Message() & " ")
                Try
                    strBUFF = .InnerException.Message
                    sbLOGMSG.Append("(" & strBUFF & ")")
                Catch iexEx As Exception
                End Try
                sbLOGMSG.AppendLine()
                sbLOGMSG.Append(.StackTrace)

                'MSGBOX�^�C�g��
                strDLGTYTLE = pub_APP_INFO.strTitle '�@My.Application.Info.AssemblyName

                'MSGBOX���e
                sbDLGMSG.Append(String.Format("OSVersion�F{0}", System.Environment.OSVersion))
                sbDLGMSG.AppendLine()
                sbDLGMSG.Append(String.Format("�[�����F{0}", System.Environment.MachineName))
                sbDLGMSG.AppendLine()
                sbDLGMSG.Append(String.Format("�������F�u{0}�v�ɂė�O�G���[���������܂���", .Source() & ":" & .TargetSite.Name))
                sbDLGMSG.AppendLine()
                sbDLGMSG.Append("��L�����T���āA�V�X�e���Ǘ��҂ւ��A��������")
                sbDLGMSG.AppendLine()
                sbDLGMSG.AppendLine()
                sbDLGMSG.Append("<�G���[���ڍ�>")
                sbDLGMSG.AppendLine()
                sbDLGMSG.Append(.GetType.ToString & "  " & .Message() & " ")
                Try
                    strBUFF = .InnerException.Message
                    sbDLGMSG.Append("(" & strBUFF & ")")
                Catch iexEx As Exception
                End Try
            End With

            '-----�G���[���O�t�@�C������
            If blnNonLog = False Then
                LP.LogPut(strLOGDTTM, sbLOGMSG.ToString, LogFilePath & "\" & LogFileName, LogMax)
            End If

            '-----�G���[���b�Z�[�W�\��
            If blnNonMsg = False Then
                System.Windows.Forms.Cursor.Current = Cursors.Default

                Fun_GetSystemIniFile()
                Using DB As ClsDbUtility = DBOpen()
                    If FunGetCodeMastaValue(DB, "���[���ݒ�", "ENABLE").ToString.Trim.ToUpper = "FALSE" Then
                        MsgBox(sbDLGMSG.ToString, MsgBoxStyle.Critical + MsgBoxStyle.SystemModal, strDLGTYTLE)
                    Else
                        Call SendFeedback(expEX)

                        Dim msg As String = $"�V�X�e����O�G���[���������܂����B{vbCrLf}�V�X�e���S���҂Ƀt�B�[�h�o�b�N���𑗐M���܂��B{vbCrLf}"
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
            '�X�N���[���V���b�g�擾
            Dim screenshot As Bitmap = CaptureScreen.CaptureActiveWindow
            Dim captureFile As String = $"{FunGetRootPath()}\LOG\�X�N���[���V���b�g.png"
            screenshot.Save(captureFile, System.Drawing.Imaging.ImageFormat.Png)
            screenshot.Dispose()

            ''Base64������ɕϊ����Ė��ߍ���
            'Dim fi As New FileInfo(captureFile)
            'Dim fs As FileStream = fi.OpenRead
            'Dim nBytes As Integer = fi.Length
            'Dim ByteArray(nBytes) As Byte
            'Dim nBytesRead As Integer = fs.Read(ByteArray, 0, nBytes)
            'fs.Close()
            'fs.Dispose()
            'Dim base64String As String
            'base64String = System.Convert.ToBase64String(ByteArray)

            '���O�t�@�C��
            Dim errlogFile As String = $"{FunGetRootPath()}\LOG\{CON_ERR_LOG}"
            Dim applogFile As String = $"{FunGetRootPath()}\LOG\FMS_G0010.LOG"

            '���[�����M
            Fun_GetSystemIniFile()
            Using DB As ClsDbUtility = DBOpen()
                Dim strSmtpServer As String = FunGetCodeMastaValue(DB, "���[���ݒ�", "SMTP_SERVER")
                Dim intSmtpPort As String = Val(FunGetCodeMastaValue(DB, "���[���ݒ�", "SMTP_PORT"))
                Dim strFromAddress As String = FunGetCodeMastaValue(DB, "���[���ݒ�", "FROM")
                Dim ToAddressList As New List(Of String)
                Dim CCAddressList As New List(Of String)
                Dim BCCAddressList As New List(Of String)

                Dim strSubject As String = "�s�K���Ǘ��V�X�e�� ��O�G���[����"
                Dim strBody As String = <body><![CDATA[
                    <br />
                    �t�W�����V�X�e���ɂĉ��L�̗�O�G���[���������܂����B<br />                    �@
                    <br />
                    <b>�y���������z</b><br />
                        {0}<br />
                        <br />
                    <b>�y�[�����z</b><br />
                        {1}:{2}<br />
                        <br />
                    <b>�y���[�U�[���z</b><br />
                        ����F{3}<br />
                        <a href = "mailto:{4}" >{5}</a><br />
                        <br />
                    <b>�y�������z</b><br />
                        {6}<br />
                        <br />
                    <b>�y�G���[�ڍׁz</b><br />
                        {7}<br />
                        {8}<br />
                        {9}<br />
                        <br />
                    ]]></body>.Value.Trim
                Dim stacktrace As String = expEX.StackTrace.Replace("�ꏊ", $"<br />{vbCrLf}�ꏊ")

                '<b>�y�X�N���[���V���b�g�z<br />
                ' <img src = "data:image/png;base64,{10}" /<> br />


                '���[�U�[���擾
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

                '�ʒm��
                sbSQL.Clear()
                sbSQL.Append($"SELECT M004.{NameOf(MODEL.M004_SYAIN.MAIL_ADDRESS)} ")
                sbSQL.Append($" FROM {NameOf(MODEL.M001_SETTING)} M001")
                sbSQL.Append($" LEFT JOIN {NameOf(MODEL.M004_SYAIN)} M004")
                sbSQL.Append($" ON(M001.{NameOf(MODEL.M001_SETTING.ITEM_DISP)} = M004.{NameOf(MODEL.M004_SYAIN.SYAIN_ID)})")
                sbSQL.Append($" WHERE M001.{NameOf(MODEL.M001_SETTING.ITEM_NAME)}='�G���[�ʒm��'")
                sbSQL.Append($" AND M001.{NameOf(MODEL.M001_SETTING.DEL_SYAIN_ID)}=0")
                sbSQL.Append($" AND M001.{NameOf(MODEL.M001_SETTING.ITEM_VALUE)}=1") 'DEBUG

                dsList = DB.GetDataSet(sbSQL.ToString, True)
                For Each row As DataRow In dsList.Tables(0).Rows
                    If Not row.Item(0).ToString.IsNulOrWS AndAlso Not ToAddressList.Contains(row.Item(0)) Then
                        ToAddressList.Add(row.Item(0))
                    End If
                Next

                strBody = String.Format(strBody,
                                          Now.ToString("yyyy/MM/dd HH:mm:ss"),'����
                                          System.Environment.MachineName,'�[����
                                          ip4Address,'IP�A�h���X
                                          strBusyoName,'������
                                          strMailAddress,'���[���A�h���X
                                          strSyainName,'�Ј���
                                          $"{expEX.Source()}�F{expEX.TargetSite.Name}",'������(�֐�)
                                          expEX.GetType,'�G���[�^
                                          expEX.Message,'�G���[���b�Z�[�W
                                          stacktrace'�X�^�b�N�g���[�X
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
                    strFromName:="�t�W�����V�X�e��",
                    isHTML:=True)
            End Using

            If IO.File.Exists(captureFile) Then IO.File.Delete(captureFile)

            Return True
        Catch ex As Exception
            Return False
        End Try
    End Function

    '�t�@�C�����`�F�b�N
    Private Function FunValidFileName(ByVal strFileName As String) As String
        Dim chrInvalid As Char()
        Dim strValidFileName As String

        Try
            '�s�������擾
            chrInvalid = System.IO.Path.GetInvalidFileNameChars()

            '�s���������_�
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

'���O�o��
Public Class WriteLog
    Private Const DefaultLogMax As Long = 10000

    Private LogFilePath As String
    Private LogFileName As String
    Private LogMax As Long

    '�}���`�X���b�h���b�N�Ɏg�p����I�u�W�F�N�g
    Private ReadOnly syncObject As New Object

    '�R���X�g���N�^
    Public Sub New(Optional ByVal strLogFileName As String = "", Optional ByVal lngLogMax As Long = 10000)

        '-----�t�@�C���p�X
        LogFilePath = FunGetRootPath()
        LogFilePath = LogFilePath & "\LOG"
        '�������͍쐬
        If System.IO.Directory.Exists(LogFilePath) = False Then
            System.IO.Directory.CreateDirectory(LogFilePath)
        End If

        '-----�t�@�C����
        If Trim(strLogFileName).IsNulOrWS Then
            LogFileName = My.Application.Info.AssemblyName & ".LOG"
        Else
            LogFileName = strLogFileName
        End If
        LogFileName = FunValidFileName(LogFileName)

        '-----�t�@�C���s��
        If lngLogMax > 0 Then
            LogMax = lngLogMax
        Else
            LogMax = DefaultLogMax
        End If

    End Sub

    '���O�o�͎��̏���
    Public Sub WriteLogDat(ByVal strMSG As String)
        Dim LP As New LogPut

        Try
            '�}���`�X���b�h���s���r�����b�N����
            SyncLock syncObject
                '-----���O����
                LP.LogPut(System.DateTime.Now.ToString, strMSG, LogFilePath & "\" & LogFileName, LogMax)

            End SyncLock
        Catch Ex As Exception
        End Try

    End Sub

    '�t�@�C�����`�F�b�N
    Private Function FunValidFileName(ByVal strFileName As String) As String
        Dim chrInvalid As Char()
        Dim strValidFileName As String

        Try
            '�s�������擾
            chrInvalid = System.IO.Path.GetInvalidFileNameChars()

            '�s���������_�
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

'���O
Public Class LogPut
    Private strLOGDTTM As String
    Private strLOGMSG As String
    Private LogFile As String
    Private LogMax As Long

    'XML�t�@�C���ɕۑ�����I�u�W�F�N�g�̂��߂̃N���X
    <System.Xml.Serialization.XmlRoot("LOGDATA")>
    Public Class LogDataClasses

        <System.Xml.Serialization.XmlArrayItem(GetType(LogDataClass))>
        Public ClassList As New ArrayList

    End Class

    'XML�t�@�C���ɕۑ�����I�u�W�F�N�g�̂��߂̃N���X
    <System.Xml.Serialization.XmlTypeAttribute("LOG")>
    Public Class LogDataClass

        <System.Xml.Serialization.XmlElement("DATETIME")>
        Public strLOGDTTM As String

        <System.Xml.Serialization.XmlElement("MESSAGE")>
        Public strLOGMSG As String

    End Class

    '���O�\�[�g
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

    '�o��
    Public Sub LogPut(ByVal strDTTM As String, ByVal strMSG As String, ByVal sFile As String, ByVal lMax As Long)

        Try
            strLOGDTTM = strDTTM
            strLOGMSG = strMSG
            LogFile = sFile
            LogMax = lMax

            '-----�o�̓X���b�h�J�n
            Dim thread As New Thread(New ThreadStart(AddressOf SubLogPut))
            thread.Start()
        Catch ex As Exception

        End Try

    End Sub

    '�o�̓X���b�h
    Private Sub SubLogPut()
        Dim fsFile As IO.FileStream = Nothing
        Dim xsLogData As System.Xml.Serialization.XmlSerializer
        Dim logClasses As LogDataClasses
        Dim logClass As New LogDataClass

        Try
            '-----���O�t�@�C��OPEN
            Do
                Application.DoEvents()
                System.Threading.Thread.Sleep(5)
                Try
                    'OPEN
                    fsFile = New IO.FileStream(LogFile, IO.FileMode.OpenOrCreate, FileAccess.ReadWrite, FileShare.None)
                Catch openEx As System.IO.IOException 'LOCK��
                    Continue Do
                End Try

                Exit Do
            Loop

            '-----���O�擾
            xsLogData = New System.Xml.Serialization.XmlSerializer(GetType(LogDataClasses))
            Try
                '�擾
                logClasses = xsLogData.Deserialize(fsFile)
            Catch dsEx As System.InvalidOperationException '�V�K�t�@�C����
                logClasses = New LogDataClasses
            End Try

            '-----���O�폜
            If logClasses.ClassList.Count = LogMax Then '�ő匏����
                logClasses.ClassList.RemoveAt(0)
            ElseIf logClasses.ClassList.Count > LogMax Then '�ő匏��������
                logClasses.ClassList.RemoveRange(0, logClasses.ClassList.Count - LogMax + 1)
            End If

            '-----���O�ǉ�
            logClass.strLOGDTTM = strLOGDTTM
            logClass.strLOGMSG = strLOGMSG
            logClasses.ClassList.Add(logClass)
            'TEST
            'For lngCNT As Long = 1 To 99990
            '    logClasses.ClassList.Add(logClass)
            'Next

            '-----���O�\�[�g
            'Dim LogDataComp As IComparer = New LogDataComparer()
            'logClasses.ClassList.Sort(LogDataComp)

            '-----���O�t�@�C������
            '�擪�|�C���^�ړ�
            fsFile.Seek(0, SeekOrigin.Begin)
            '����
            xsLogData.Serialize(fsFile, logClasses)
            fsFile.SetLength(fsFile.Position)
            fsFile.Flush()
        Catch Ex As Exception
        Finally
            '-----���O�t�@�C��CLOSE
            If Not fsFile Is Nothing Then
                fsFile.Close()
            End If
        End Try

    End Sub

End Class