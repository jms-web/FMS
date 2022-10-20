Imports System.Collections.Generic
Imports System.IO
Imports System.Linq
Imports System.Text
Imports MailKit.Net.Smtp
Imports MailKit.Security
Imports MimeKit
Imports MimeKit.Text

Public Class ClsMailSend
    Implements IDisposable

    Public Shared Function FunSendMail(ByVal strSmtpServer As String,
                                ByVal intSmtpPort As Integer,
                                ByVal FromAddress As String,
                                ByVal ToAddress As List(Of String),
                                ByVal CCAddress As List(Of String),
                                ByVal BCCAddress As List(Of String),
                                ByVal strSubject As String,
                                ByVal strBody As String,
                                ByVal AttachmentList As List(Of String),
                                ByVal Optional strFromName As String = "",
                                ByVal Optional isHTML As Boolean = False) As Boolean

        Dim smtp As TKMP.Net.SmtpClient = Nothing
        'Dim logon As TKMP.Net.ISmtpLogon
        Dim strAddress As String
        Try

            '送信メールの作成クラスを定義
            Dim writer As New TKMP.Writer.MailWriter

            'メールの実際の差出人
            writer.FromAddress = FromAddress
            'メールヘッダの差出人情報
            If strFromName.IsNulOrWS = False Then
                writer.Headers.Add("From", strFromName & " <" & FromAddress & ">")
            End If

            'メールの実際の宛先,メールヘッダの宛先情報
            For Each strAddress In ToAddress
                writer.ToAddressList.Add(strAddress)
            Next
            If (ToAddress.Count = 1) Then
                writer.Headers.Add("To", " <" & ToAddress.First & ">")
            ElseIf (ToAddress.Count > 1) Then
                writer.Headers.Add("To", $"<{ToAddress.Aggregate(Function(a, b) a & "," & b)}>")
            End If

            'CC
            For Each strAddress In CCAddress
                writer.ToAddressList.Add(strAddress)
            Next
            If CCAddress.Count = 1 Then
                writer.Headers.Add("Cc", " <" & CCAddress.First & ">")
            ElseIf CCAddress.Count > 1 Then
                writer.Headers.Add("Cc", $"<{CCAddress.Aggregate(Function(a, b) a & "," & b)}>")
            Else
            End If

            'BCC
            For Each strAddress In BCCAddress
                writer.ToAddressList.Add(strAddress)
            Next

            '件名
            writer.Headers.Add("Subject", strSubject)

            '本文のパート
            Dim headerPart As New TKMP.Writer.TextPart(strBody) ', TKMP.Writer.Charsets.UTF8)
            headerPart.Headers.Add("Content-Type", headerPart.Headers("Content-Type").Replace("plain", "html"))

            'Content-Type: Text/ plain; charset=UTF-8

            Dim multiPart As New TKMP.Writer.MultiPart
            multiPart.AddPart(headerPart)

            For Each attachment As String In AttachmentList
                If Not attachment.IsNulOrWS And System.IO.File.Exists(attachment) Then
                    multiPart.AddPart(New TKMP.Writer.FilePart(attachment))
                End If
            Next
            writer.MainPart = multiPart
            writer.Headers.Add("X-MailSender", "TKMP.DLL")

            'メールの送信先サーバー名
            Dim address As System.Net.IPAddress = System.Net.Dns.GetHostEntry(strSmtpServer).AddressList(0)
            'Dim address As System.Net.IPAddress = System.Net.IPAddress.Parse(strSmtpServer)
            'SMTPへの接続クラスを作成
            smtp = New TKMP.Net.SmtpClient(address, intSmtpPort)

            'サーバーへ接続
            If Not smtp.Connect() Then
                'MessageBox.Show("接続失敗")
                WL.WriteLogDat("メール送信失敗:サーバ接続エラー")
                MessageBox.Show($"メールサーバに接続出来ませんでした{vbCrLf}{vbCrLf}MailServer{vbCrLf}{strSmtpServer}", "メール送信失敗", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Return False
            End If
            'メール送信
            smtp.SendMail(writer)
            'WL.WriteLogDat(String.Format("メール送信成功:From={0},To={1},送信ファイル={2}", FromAddress, ToAddress, strAttachment))

            Return True
        Catch ex As Exception
            MessageBox.Show($"メールサーバに接続出来ませんでした{vbCrLf}{vbCrLf}MailServer{vbCrLf}{strSmtpServer}", "メール送信失敗", MessageBoxButtons.OK, MessageBoxIcon.Information)
            'EM.ErrorSyori(ex, False, True)
            Return False
        Finally
            'サーバーから切断
            smtp.Close()
        End Try
    End Function

    Public Shared Function FunSendMailoverAUTH(ByVal strSmtpServer As String,
                                ByVal intSmtpPort As Integer,
                                ByVal strUserID As String,
                                ByVal strPassword As String,
                                ByVal FromAddress As String,
                                ByVal ToAddress As List(Of String),
                                ByVal CCAddress As List(Of String),
                                ByVal BCCAddress As List(Of String),
                                ByVal strSubject As String,
                                ByVal strBody As String,
                                ByVal AttachmentList As List(Of String),
                                ByVal Optional strFromName As String = "",
                                ByVal Optional isHTML As Boolean = False) As Boolean

        Try
            EM = New ErrMsg(CON_ERR_LOG)
            WL = New WriteLog()

            '送信メールの作成クラスを定義
            Dim message As New MimeMessage
            Dim adrs As MailboxAddress

            adrs = MailboxAddress.Parse(FromAddress)
            If Not strFromName.IsNulOrWS Then
                adrs.Name = strFromName
            End If
            'メールの実際の差出人
            message.From.Add(adrs)

            'メールの実際の宛先
            Dim strAddress As String
            For Each strAddress In ToAddress
                message.To.Add(MailboxAddress.Parse(strAddress))
            Next

            'CC
            For Each strAddress In CCAddress
                message.Cc.Add(MailboxAddress.Parse(strAddress))
            Next

            'BCC
            For Each strAddress In BCCAddress
                message.Bcc.Add(MailboxAddress.Parse(strAddress))
            Next

            '件名
            message.Subject = strSubject

            Dim builder As New BodyBuilder
            builder.HtmlBody = strBody

            For Each attachment As String In AttachmentList
                If Not attachment.IsNulOrWS And File.Exists(attachment) Then
                    Dim buffer As Byte() = File.ReadAllBytes(attachment)
                    builder.Attachments.Add(Path.GetFileName(attachment), buffer)
                End If
            Next
            message.Body = builder.ToMessageBody()

            Using client As New MailKit.Net.Smtp.SmtpClient
                client.Connect(strSmtpServer, intSmtpPort, SecureSocketOptions.Auto)
                client.Authenticate(strUserID, strPassword)
                client.Send(message)
                client.Disconnect(True)
            End Using

            Return True
        Catch ex As Exception
            MessageBox.Show($"メールサーバに接続出来ませんでした{vbCrLf}{vbCrLf}MailServer{vbCrLf}{strSmtpServer}{vbCrLf}{ex.Message}", "メール送信失敗", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Return False
        Finally

        End Try
    End Function

    Public Function FunSendMailoverAUTH_(ByVal strSmtpServer As String,
                                ByVal intSmtpPort As Integer,
                                ByVal strUserID As String,
                                ByVal strPassword As String,
                                ByVal FromAddress As String,
                                ByVal ToAddress As List(Of String),
                                ByVal CCAddress As List(Of String),
                                ByVal BCCAddress As List(Of String),
                                ByVal strSubject As String,
                                ByVal strBody As String,
                                ByVal AttachmentList As List(Of String),
                                ByVal Optional strFromName As String = "",
                                ByVal Optional isHTML As Boolean = False) As Boolean

        Dim smtp As TKMP.Net.SmtpClient = Nothing
        Dim logon As TKMP.Net.ISmtpLogon

        Try
            EM = New ErrMsg(CON_ERR_LOG)
            WL = New WriteLog()

            '送信メールの作成クラスを定義
            Dim writer As New TKMP.Writer.MailWriter

            'AUTH CRAM-MD5でログオンを行ないます
            'logon = New TKMP.Net.AuthCramMd5(userid, pass)

            'AUTH LOGINでログオンを行ないます
            'logon = New TKMP.Net.AuthLogin(strUserID, strPassword)

            'AUTH PLAINでログオンを行ないます
            'logon = New TKMP.Net.AuthPlain(strUserID, strPassword)

            'CRAM-MD5 PLAIN LOGINの順で利用可能なものを優先してログオンを行ないます
            logon = New TKMP.Net.AuthAuto(strUserID, strPassword)

            'POP Before SMTPでログオンを行ないます
            '使用するにはPOPへの接続情報が必要です
            'logon = New TKMP.Net.PopBeforeSMTP(popclient)

            'ログオン処理は行ないません
            'logon = Nothing

            'メールの実際の差出人
            writer.FromAddress = FromAddress
            'メールヘッダの差出人情報
            If strFromName.IsNulOrWS Then
            Else
                writer.Headers.Add("From", strFromName & " <" & FromAddress & ">")
            End If

            'メールの実際の宛先
            Dim strAddress As String
            For Each strAddress In ToAddress
                writer.ToAddressList.Add(strAddress)
            Next
            If (ToAddress.Count = 1) Then
                writer.Headers.Add("To", " <" & ToAddress.First & ">")
            ElseIf (ToAddress.Count > 1) Then
                writer.Headers.Add("To", $"<{ToAddress.Aggregate(Function(a, b) a & "," & b)}>")
            End If
            'CC
            For Each strAddress In CCAddress
                writer.ToAddressList.Add(strAddress)
            Next
            If CCAddress.Count = 1 Then
                writer.Headers.Add("Cc", " <" & CCAddress.First & ">")
            ElseIf CCAddress.Count > 1 Then
                writer.Headers.Add("Cc", $"<{CCAddress.Aggregate(Function(a, b) a & "," & b)}>")
            Else
            End If

            'BCC
            For Each strAddress In BCCAddress
                writer.ToAddressList.Add(strAddress)
            Next

            '件名
            writer.Headers.Add("Subject", strSubject)

            '本文のパート
            'Dim txtPart As New TKMP.Writer.TextPart(strBody)
            '添付ファイル
            'Dim filePart As TKMP.Writer.FilePart
            'If strAttachment.IsNulOrWS Then
            '    filePart = Nothing
            '    '本文と添付ファイルを持つ、マルチパートクラスを作成
            '    writer.MainPart = New TKMP.Writer.MultiPart(txtPart)
            'Else
            '    filePart = New TKMP.Writer.FilePart(strAttachment)
            '    '本文と添付ファイルを持つ、マルチパートクラスを作成
            '    writer.MainPart = New TKMP.Writer.MultiPart(txtPart, filePart)
            'End If
            '本文のパート
            Dim headerPart As New TKMP.Writer.TextPart(strBody) ', TKMP.Writer.Charsets.UTF8)
            headerPart.Headers.Add("Content-Type", headerPart.Headers("Content-Type").Replace("plain", "html"))

            'Content-Type: Text/ plain; charset=UTF-8

            Dim multiPart As New TKMP.Writer.MultiPart
            multiPart.AddPart(headerPart)

            For Each attachment As String In AttachmentList
                If Not attachment.IsNulOrWS And System.IO.File.Exists(attachment) Then
                    multiPart.AddPart(New TKMP.Writer.FilePart(attachment))
                End If
            Next
            writer.MainPart = multiPart
            writer.Headers.Add("X-MailSender", "TKMP.DLL")

            'メールの送信先サーバー名
            Dim address As System.Net.IPAddress = System.Net.Dns.GetHostByName(strSmtpServer).AddressList(0)
            'Dim address As System.Net.IPAddress = System.Net.IPAddress.Parse(strSmtpServer)

            'SMTPへの接続クラスを作成
            smtp = New TKMP.Net.SmtpClient(address, intSmtpPort, logon)

            'SSL
            smtp.AuthenticationProtocol = TKMP.Net.AuthenticationProtocols.TryTLS
            ''証明書に問題があった場合に独自の処理を追加します
            AddHandler smtp.CertificateValidation, AddressOf smtp_CertificateValidation

            'サーバーへ接続
            If Not smtp.Connect() Then
                'MessageBox.Show("接続失敗")
                MessageBox.Show($"メールサーバに接続出来ませんでした{vbCrLf}{vbCrLf}MailServer{vbCrLf}{strSmtpServer}", "メール送信失敗", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Return False
            End If
            'メール送信
            smtp.SendMail(writer)

            Return True
        Catch ex As Exception
            MessageBox.Show($"メールサーバに接続出来ませんでした{vbCrLf}{vbCrLf}MailServer{vbCrLf}{strSmtpServer}{vbCrLf}{ex.Message}", "メール送信失敗", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Return False
        Finally
            'サーバーから切断
            smtp.Close()
        End Try
    End Function

    Private Sub smtp_CertificateValidation(ByVal sender As Object, ByVal e As TKMP.Net.CertificateValidationArgs)
        '全ての証明書を信用します
        e.Cancel = False
    End Sub

    Public Sub Dispose() Implements IDisposable.Dispose
        'Throw New NotImplementedException()
    End Sub

End Class