Imports JMS_COMMON.ClsPubMethod

''' <summary>
''' 修正画面
''' </summary>
Public Class FrmG0037_MailForm

#Region "プロパティ"

    Public Property PrSYONIN_HOKOKUSYO_ID As Integer

    Public Property PrHOKOKU_NO As String

    'Public Property PrCurrentStage As Integer

    'Public Property PrBUMON_KB As String

    'Public Property PrBUHIN_BANGO As String

    'Public Property PrKISYU_NAME As String

    'Public Property PrKISO_YMD As String

    Public Property PrSYORI_NAME As String

    Public Property PrToUsers As List(Of Integer)

#End Region

#Region "コンストラクタ"

    ''' <summary>
    ''' コンストラクタ
    ''' </summary>
    ''' <remarks>コンストラクタ</remarks>
    Public Sub New()

        ' この呼び出しはデザイナーで必要です。
        InitializeComponent()
        Me.Icon = My.Resources._icoAppForm32x32
        Me.ShowIcon = True

    End Sub

#End Region

#Region "FORMイベント"

    Private Sub Frm_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        Try
            '-----フォーム共通設定
            Call FunFormCommonSetting(pub_APP_INFO, pub_SYAIN_INFO)
            Using DB As ClsDbUtility = DBOpen()
                lblTytle.Text = FunGetCodeMastaValue(DB, "PG_TITLE", Me.GetType.ToString)
            End Using
            lblTytle.Text = PrSYORI_NAME
            Me.Text = lblTytle.Text

            '-----位置・サイズ
            Me.Height = 600
            Me.Width = 1000
            Me.MinimumSize = New Size(1000, 600)
            Me.Top = Me.Owner.Top + (Me.Owner.Height - Me.Height) / 2
            Me.Left = Me.Owner.Left + (Me.Owner.Width - Me.Width) / 2

            '-----ダイアログウィンドウ設定
            Me.FormBorderStyle = Windows.Forms.FormBorderStyle.FixedDialog
            Me.ControlBox = False

            Dim strBody As String = ""
            Dim strSubject As String = ""
            Select Case PrSYORI_NAME
                Case "協議確認依頼メール送信"
                    strSubject = $"FCCB会議招集の件 FCCB-NO:{PrHOKOKU_NO}"
                    strBody = "各位
FCCB記録書に記載された内容を確認すると、協議が必要と
判断しますので、下記日程で、FCCB会議を実施しますので
ご参集をお願い致します。

日時：　　　年　　月　　日　　　：　　～　　：
場所：第　　会議室

FCCB　議長"

            End Select

            mtxTo.Text = GetUserNames(PrToUsers).Aggregate(Function(a, b) a & ", " & b)
            mtxTitle.Text = strSubject
            mtxBody.Text = strBody
        Catch ex As Exception
            EM.ErrorSyori(ex, False, conblnNonMsg)
        Finally
            Call FunInitFuncButtonEnabled()
        End Try
    End Sub

    ''' <summary>
    ''' ユーザーIDリストから名前リストを取得
    ''' </summary>
    ''' <param name="prToUsers"></param>
    ''' <returns></returns>
    Private Function GetUserNames(prToUsers As List(Of Integer)) As List(Of String)
        Dim strList As New List(Of String)
        Try
            If prToUsers IsNot Nothing AndAlso prToUsers.Count > 0 Then
                For Each userID As Integer In prToUsers
                    strList.Add(tblTANTO.AsEnumerable.
                                         Where(Function(r) r.Item("VALUE") = userID.ToString).
                                         Select(Function(r) r.Item("DISP")).
                                         FirstOrDefault)
                Next
            End If

            Return strList
        Catch ex As Exception
            Throw
        End Try
    End Function

#End Region

#Region "FUNCTIONボタン関連"

#Region "FUNCTIONボタンCLICKイベント"

    Private Sub CmdFunc_Click(ByVal sender As Object, ByVal e As EventArgs) Handles cmdFunc9.Click, cmdFunc8.Click, cmdFunc7.Click, cmdFunc6.Click, cmdFunc5.Click, cmdFunc4.Click, cmdFunc3.Click, cmdFunc2.Click, cmdFunc12.Click, cmdFunc11.Click, cmdFunc10.Click, cmdFunc1.Click
        Dim intFUNC As Integer
        Dim intCNT As Integer
        'Dim blnRET As Boolean

        Try
            'ボタン不可/ボタンINDEX取得
            For intCNT = 0 To Me.cmdFunc.Length - 1
                Me.cmdFunc(intCNT).Enabled = False
                If cmdFunc(intCNT) Is sender Then intFUNC = intCNT + 1
            Next

            'ボタンINDEX毎の処理
            Select Case intFUNC
                Case 1  '追加
                    If FunCheckInput() Then
                        If FunSendJudgeRequestMail() Then
                            Dim imgDlg As New ImageDialog
                            imgDlg.Show("\\sv04\FMS\RESOURCE\sendmail_256.gif", 4200)
                            Me.DialogResult = Windows.Forms.DialogResult.OK
                        End If
                    End If

                Case 12 '戻る
                    Me.DialogResult = Windows.Forms.DialogResult.Cancel
                    Me.Close()
            End Select
        Catch exDispose As ObjectDisposedException
            System.Console.WriteLine(exDispose.Message)
        Catch ex As Exception
            EM.ErrorSyori(ex, False, conblnNonMsg)
        Finally
            'ボタン可
            System.Windows.Forms.Application.DoEvents()
            For intCNT = 0 To Me.cmdFunc.Length - 1
                Me.cmdFunc(intCNT).Enabled = True
            Next
        End Try
    End Sub

#End Region

#Region "FuncButton有効無効切替"

    ''' <summary>
    ''' 使用しないボタンのキャプションをなくす、かつ非活性にする。
    ''' ファンクションキーを示す(F**)以外の文字がない場合は、未使用とみなす
    ''' </summary>
    ''' <param name="frm">対象フォーム</param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Private Function FunInitFuncButtonEnabled() As Boolean
        Try

            For intFunc As Integer = 1 To 12
                Dim cmd As Button = DirectCast(Me.Controls.Find("cmdFunc" & intFunc, True)(0), Button)
                With cmd
                    If cmd IsNot Nothing AndAlso .Text.Length = 0 OrElse .Text.Substring(0, .Text.IndexOf("(")).IsNulOrWS Then
                        .Text = ""
                        '.Visible = False
                        .Enabled = False
                    End If
                End With
            Next intFunc

            Return True
        Catch ex As Exception
            EM.ErrorSyori(ex, False, conblnNonMsg)
            Return False
        End Try
    End Function

#End Region

#End Region

#Region "コントロールイベント"

    Private Sub mtxBody_Validating(sender As Object, e As EventArgs) Handles mtxBody.Validating
        IsValidated *= ErrorProvider.UpdateErrorInfo(mtxBody, Not mtxBody.Text.IsNulOrWS, String.Format(My.Resources.infoMsgRequireSelectOrInput, "本文"))
    End Sub

    Private Sub mtxTitle_Validating(sender As Object, e As EventArgs) Handles mtxTitle.Validating
        IsValidated *= ErrorProvider.UpdateErrorInfo(mtxTitle, Not mtxTitle.Text.IsNulOrWS, String.Format(My.Resources.infoMsgRequireSelectOrInput, "件名"))
    End Sub

#End Region

#Region "入力チェック"

    Public Function FunCheckInput() As Boolean
        Try
            IsValidated = True
            IsCheckRequired = True

            Call mtxBody_Validating(mtxBody, Nothing)
            Call mtxTitle_Validating(mtxTitle, Nothing)

            Return IsValidated
        Catch ex As Exception
            Throw
        Finally
            IsCheckRequired = False
        End Try
    End Function

#End Region

#Region "ローカル関数"

    ''' <summary>
    ''' 協議確認依頼メール送信
    ''' </summary>
    ''' <returns></returns>
    Private Function FunSendJudgeRequestMail(Optional toUserNAME As String = "", Optional fromUserNAME As String = "") As Boolean

        Try

            Dim strBody As String = mtxBody.Text.Replace(Environment.NewLine, "<br />") & <sql><![CDATA[
                <br />
                <a href = "http://sv04:8000/CLICKONCE_FMS.application" > システム起動</a><br />
                <br />
                ※このメールは配信専用です。(返信できません)<br />
                返信する場合は、各担当者のメールアドレスを使用して下さい。<br />
                ]]></sql>.Value.Trim

            If PrToUsers.Count = 0 Then
                MessageBox.Show("送信者が見つからないため、依頼メールを送信できません", "依頼メール送信", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Return False
            Else
                If FunSendMailZESEI(mtxTitle.Text, strBody, PrToUsers, False) Then
                    Return True
                Else
                    MessageBox.Show("メール送信に失敗しました。", "メール送信失敗", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    Return False
                End If
            End If
        Catch ex As Exception
            Throw
        End Try
    End Function

#End Region

End Class