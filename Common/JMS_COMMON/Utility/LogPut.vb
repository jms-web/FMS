Imports System.IO
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
        If Trim(strLogFileName).IsNullOrWhiteSpace Then
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
                MsgBox(sbDLGMSG.ToString, MsgBoxStyle.Critical + MsgBoxStyle.SystemModal, strDLGTYTLE)
            End If

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
        If Trim(strLogFileName).IsNullOrWhiteSpace Then
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
    <System.Xml.Serialization.XmlRoot("LOGDATA")> _
    Public Class LogDataClasses
        <System.Xml.Serialization.XmlArrayItem(GetType(LogDataClass))> _
        Public ClassList As New ArrayList
    End Class

    'XML�t�@�C���ɕۑ�����I�u�W�F�N�g�̂��߂̃N���X
    <System.Xml.Serialization.XmlTypeAttribute("LOG")> _
    Public Class LogDataClass
        <System.Xml.Serialization.XmlElement("DATETIME")> _
        Public strLOGDTTM As String
        <System.Xml.Serialization.XmlElement("MESSAGE")> _
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


