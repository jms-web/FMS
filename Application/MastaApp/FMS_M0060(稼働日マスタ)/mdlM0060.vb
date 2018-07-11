Imports JMS_COMMON.ClsPubMethod

Module mdlM0060

#Region "定数・変数"

    ''' <summary>
    ''' 一覧画面
    ''' </summary>
    Public frmLIST As FrmM0060

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

                '-----一覧画面表示
                frmLIST = New FrmM0060
                Application.Run(frmLIST)
            End Using
        Catch ex As Exception
            EM.ErrorSyori(ex, False, conblnNonMsg)
            MsgBox(My.Resources.ErrMsgInit, MsgBoxStyle.Critical, My.Application.Info.AssemblyName)
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
    Public Function FunInitFuncButtonEnabled(ByRef frm As FrmM0060) As Boolean
        Try

            For intFunc As Integer = 1 To 12
                With frm.Controls("cmdFunc" & intFunc)
                    If .Text.Length = 0 OrElse .Text.Substring(0, .Text.IndexOf("(")).IsNullOrWhiteSpace Then
                        .Text = ""
                        .Visible = False
                    End If
                End With
            Next intFunc




            Return True
        Catch ex As Exception
            EM.ErrorSyori(ex, False, conblnNonMsg)
            Return False
        End Try
    End Function


    ''' <summary>
    ''' FUNCTIONボタンの有効無効を設定する
    ''' </summary>
    ''' <param name="frm">対象フォーム</param>
    ''' <param name="blnAryEnabled">各ボタンの有効無効設定(ブール型)を格納した配列</param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function FunSetFuncButtonEnabled(ByRef frm As Form, ByVal blnAryEnabled() As Boolean) As Integer
        Try

            For intCNT As Integer = 1 To 12
                '検索結果により使用不可になるボタンはスキップする
                If blnAryEnabled(intCNT - 1) = False Then
                    frm.Controls("cmdFunc" & intCNT).Enabled = False
                Else
                    '機能が割り当てられているボタンを活性化させる
                    If frm.Controls("cmdFunc" & intCNT).Text.Length >= 6 Then
                        frm.Controls("cmdFunc" & intCNT).Enabled = True
                    Else
                        frm.Controls("cmdFunc" & intCNT).Enabled = False
                    End If
                End If
            Next intCNT

            Return 0
        Catch ex As Exception
            EM.ErrorSyori(ex)
            Return -1
        End Try
    End Function
#End Region

End Module
