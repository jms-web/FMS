Imports JMS_COMMON.ClsPubMethod

Public Class FrmM0001

#Region "Formイベント"
    'FORM_LOAD
    Private Sub FrmMBCM002MENU_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        'Dim strBUFF As String
        Dim lngCNT As Long
        'Dim lngCNTWK As Long

        'Dim intRET As Integer

        Dim strRIREKI_NAME As String
        Dim encRIREKI As System.Text.Encoding
        Dim strLINES() As String

        Try
            '-----位置
            If Not Me.Owner Is Nothing Then '有時
                '-----位置
                Me.Top = Me.Owner.Top + (Me.Owner.Height - Me.Height) / 2
                Me.Left = Me.Owner.Left + (Me.Owner.Width - Me.Width) / 2

            Else '無時
                Me.Top = 0
                Me.Left = 0
            End If


            '-----ダイアログWINDOW
            Me.FormBorderStyle = Windows.Forms.FormBorderStyle.FixedDialog
            Me.ControlBox = False


            '-----タイトル
            Using DB As ClsDbUtility = DBOpen()
                lblTytle.Text = FunGetCodeMastaValue(DB, "PG_TITLE", Me.GetType.ToString)
            End Using


            '-----履歴表示
            strRIREKI_NAME = FunGetRootPath() & "\INI\" & CON_TXT_UPDATE_HISTORY
            encRIREKI = System.Text.Encoding.GetEncoding(932) 'Shift JIS
            '読込
            strLINES = System.IO.File.ReadAllLines(strRIREKI_NAME, encRIREKI)
            '表示
            Me.lstRIREKI.Items.AddRange(strLINES)
            'フォーカス
            Me.lstRIREKI.SelectedIndex = strLINES.GetLength(0) - 1
            For lngCNT = strLINES.GetLength(0) - 1 To 0 Step -1
                If strLINES(lngCNT).Contains("●") = True Then
                    Me.lstRIREKI.SelectedIndex = lngCNT
                    Exit For
                End If
            Next lngCNT

        Catch ex As Exception
            EM.ErrorSyori(ex, False, conblnNonMsg)
        End Try
    End Sub

    'FORM_Activated
    Private Sub FrmMBCM002MENU_Activated(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Activated
        Dim i As Integer

        Try
            '-----位置
            If Not Me.Owner Is Nothing Then '有時
                Me.Opacity = 1

            Else '無時
                If Me.Opacity = 1 Then
                    Exit Sub
                End If

                '徐々に現れる
                For i = 0 To 10
                    'フォームの不透明度を変更する
                    Me.Opacity = 0.1 * i
                    '一時停止
                    System.Threading.Thread.Sleep(50)
                Next
            End If

        Catch ex As Exception
            EM.ErrorSyori(ex, False, conblnNonMsg)
        End Try
    End Sub

#End Region

#Region "FUNCTIONボタン関連"

#Region "ボタンクリックイベント"
    Private Sub CmdFunc_Click(ByVal sender As Object, ByVal e As EventArgs) Handles cmdFunc1.Click, cmdFunc2.Click, cmdFunc3.Click, cmdFunc4.Click, cmdFunc5.Click, cmdFunc6.Click, cmdFunc7.Click, cmdFunc8.Click, cmdFunc9.Click, cmdFunc10.Click, cmdFunc11.Click, cmdFunc12.Click
        Dim intFUNC As Integer
        Dim intCNT As Integer

        Try
            'ボタン不可/ボタンINDEX取得
            For intCNT = 0 To Me.cmdFunc.Length - 1
                Me.cmdFunc(intCNT).Enabled = False
                If cmdFunc(intCNT) Is sender Then intFUNC = intCNT + 1
            Next

            'ボタンINDEX毎の処理
            Select Case intFUNC
                Case 1 '確認
                    Me.DialogResult = Windows.Forms.DialogResult.Cancel
                    Me.Close()
            End Select

        Catch ex As Exception
            EM.ErrorSyori(ex)

        Finally
            'ボタン可
            System.Windows.Forms.Application.DoEvents()
            For intCNT = 0 To Me.cmdFunc.Length - 1
                Me.cmdFunc(intCNT).Enabled = True
            Next
        End Try
    End Sub

#End Region

#End Region


End Class
