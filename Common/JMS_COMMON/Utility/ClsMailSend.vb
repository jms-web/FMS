Imports System.Collections.Generic

Public Class ClsMailSend
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
                writer.Headers.Add("To", "<" & strAddress & ">")
            Next

            'CC
            For Each strAddress In CCAddress
                writer.ToAddressList.Add(strAddress)
                writer.Headers.Add("Cc", "<" & strAddress & ">")
            Next

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
                If Not attachment.IsNulOrWS And IO.File.Exists(attachment) Then
                    multiPart.AddPart(New TKMP.Writer.FilePart(attachment))
                End If
            Next
            writer.MainPart = multiPart
            writer.Headers.Add("X-MailSender", "TKMP.DLL")

            'メールの送信先サーバー名
            'Dim address() As System.Net.IPAddress = System.Net.Dns.GetHostEntry(strSmtpServer).AddressList
            'SMTPへの接続クラスを作成
            'smtp = New TKMP.Net.SmtpClient(address(0), intSmtpPort)
            Dim address As System.Net.IPAddress = System.Net.IPAddress.Parse(strSmtpServer)
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
                                ByVal ToAddress As String,
                                ByVal CCAddress As String,
                                ByVal BCCAddress As String,
                                ByVal strSubject As String,
                                ByVal strBody As String,
                                ByVal strAttachment As String,
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
            logon = New TKMP.Net.AuthLogin(strUserID, strPassword)

            'AUTH PLAINでログオンを行ないます
            'logon = New TKMP.Net.AuthPlain(strUserID, strPassword)

            'CRAM-MD5 PLAIN LOGINの順で利用可能なものを優先してログオンを行ないます
            'logon = New TKMP.Net.AuthAuto(userid, pass)

            'POP Before SMTPでログオンを行ないます
            '使用するにはPOPへの接続情報が必要です
            'logon = New TKMP.Net.PopBeforeSMTP(popclient)

            'ログオン処理は行ないません
            'logon = Nothing


            'メールの実際の差出人
            writer.FromAddress = "funato@jms-web.co.jp" 'FromAddress
            'メールヘッダの差出人情報
            If strFromName.IsNulOrWS Then
            Else
                writer.Headers.Add("From", strFromName & " <" & FromAddress & ">")
            End If

            'メールの実際の宛先
            writer.ToAddressList.Add(ToAddress)
            'メールヘッダの宛先情報       
            writer.Headers.Add("To", "<" & ToAddress & ">")

            '件名
            writer.Headers.Add("Subject", strSubject)

            '本文のパート
            Dim txtPart As New TKMP.Writer.TextPart(strBody)

            '添付ファイル
            Dim filePart As TKMP.Writer.FilePart
            If strAttachment.IsNulOrWS Then
                filePart = Nothing
                '本文と添付ファイルを持つ、マルチパートクラスを作成
                writer.MainPart = New TKMP.Writer.MultiPart(txtPart)
            Else
                filePart = New TKMP.Writer.FilePart(strAttachment)
                '本文と添付ファイルを持つ、マルチパートクラスを作成
                writer.MainPart = New TKMP.Writer.MultiPart(txtPart, filePart)
            End If

            'メールの送信先サーバー名
            Dim address As System.Net.IPAddress = System.Net.Dns.GetHostEntry(strSmtpServer).AddressList(0)

            'SMTPへの接続クラスを作成
            smtp = New TKMP.Net.SmtpClient(address, intSmtpPort, logon)

            'SSL
            'smtp.AuthenticationProtocol = TKMP.Net.AuthenticationProtocols.SSL
            ''証明書に問題があった場合に独自の処理を追加します
            'AddHandler smtp.CertificateValidation, AddressOf smtp_CertificateValidation

            'サーバーへ接続
            If Not smtp.Connect() Then
                'MessageBox.Show("接続失敗")
                WL.WriteLogDat("メール送信失敗:サーバ接続エラー")
                Return False
            End If
            'メール送信
            smtp.SendMail(writer)
            WL.WriteLogDat(String.Format("メール送信成功:From={0},To={1},送信ファイル={2}", FromAddress, ToAddress, strAttachment))

            Return True
        Catch ex As Exception
            EM.ErrorSyori(ex, False, True)
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
End Class
