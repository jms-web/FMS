Imports JMS_COMMON.ClsPubMethod

'UNDONE: ログイン・ログアウトパネルをManagedPanelに置き換え

Public Class FrmM0000

#Region "定数・変数"
    Private cmdFunc() As Button 'ボタン配列
    Private pnlFunc() As Panel  'ボタンパネル配列

    Private arrNOW_CMDS(11) As CMDS_TYPE
    'Private hsAUTHORITY As New Hashtable

    Private memoryImage As Bitmap
    Private blnALTPRT As Boolean 'TRUE:最前面WINDOW、FALSE:DESKTOP

    Private blnLogin As Boolean
#End Region

#Region "コンストラクタ"
    ''' <summary>
    ''' コンストラクタ
    ''' </summary>
    ''' <remarks>コンストラクタ</remarks>
    Public Sub New()

        ' この呼び出しはデザイナーで必要です。
        InitializeComponent()

        Me.Icon = My.Resources._icoMENU128x128
    End Sub
#End Region

#Region "Formイベント"

#Region "ROAD"
    Private Sub FrmLoad(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Dim strBUFF As String
        Dim intL As Integer

        Try
            '画面共通設定
            Call FunFormCommonSetting(pub_APP_INFO, pub_SYAIN_INFO, My.Application.Info.Version.ToString)

            '-----ログイン表示
            Me.grbLOGOUT.Visible = False
            Me.grbLOGIN.BringToFront()
            Me.grbLOGIN.Visible = True

            '-----ボタン配列
            'ボタン配列の作成
            Me.cmdFunc = New System.Windows.Forms.Button(11) {}

            'ボタン配列に画面に置いたボタンを代入
            Me.cmdFunc(0) = Me.cmdFunc1
            Me.cmdFunc(1) = Me.cmdFunc2
            Me.cmdFunc(2) = Me.cmdFunc3
            Me.cmdFunc(3) = Me.cmdFunc4
            Me.cmdFunc(4) = Me.cmdFunc5
            Me.cmdFunc(5) = Me.cmdFunc6
            Me.cmdFunc(6) = Me.cmdFunc7
            Me.cmdFunc(7) = Me.cmdFunc8
            Me.cmdFunc(8) = Me.cmdFunc9
            Me.cmdFunc(9) = Me.cmdFunc10
            Me.cmdFunc(10) = Me.cmdFunc11
            Me.cmdFunc(11) = Me.cmdFunc12

            '-----ボタンパネル配列
            'ボタンパネル配列の作成
            Me.pnlFunc = New System.Windows.Forms.Panel(11) {}

            'ボタンパネル配列に画面に置いたパネルを代入
            Me.pnlFunc(0) = Me.pnlFunc1
            Me.pnlFunc(1) = Me.pnlFunc2
            Me.pnlFunc(2) = Me.pnlFunc3
            Me.pnlFunc(3) = Me.pnlFunc4
            Me.pnlFunc(4) = Me.pnlFunc5
            Me.pnlFunc(5) = Me.pnlFunc6
            Me.pnlFunc(6) = Me.pnlFunc7
            Me.pnlFunc(7) = Me.pnlFunc8
            Me.pnlFunc(8) = Me.pnlFunc9
            Me.pnlFunc(9) = Me.pnlFunc10
            Me.pnlFunc(10) = Me.pnlFunc11
            Me.pnlFunc(11) = Me.pnlFunc12

            '-----メニュー設定
            For intL = 0 To 11
                arrNOW_CMDS(intL) = arrCMDS_FUNC(intL)
            Next intL
            Call Sub_MenuSet()


            '業務分類セット
            Dim imgList As New ImageList
            imgList.Images.Add(My.Resources._imgBilling1)
            'imgList.Images.Add(My.Resources._imgBasket)
            'imgList.Images.Add(My.Resources._imgBox)
            'imgList.Images.Add(My.Resources._imgBarcode_reader)
            'imgList.Images.Add(My.Resources._imgMachiningCenter)
            'imgList.Images.Add(My.Resources._imgMachiningCenter)
            'imgList.Images.Add(My.Resources._imgDelivery)
            'imgList.Images.Add(My.Resources._imgShelf)
            'imgList.Images.Add(My.Resources._imgCalculator)
            'imgList.Images.Add(My.Resources._imgBase_cog32x32)
            imgList.Images.Add(My.Resources._imgBase_cog32x32)
            imgList.ImageSize = New Size(32, 32)
            imgList.ColorDepth = ColorDepth.Depth32Bit
            lstGYOMU.SmallImageList = imgList
            lstGYOMU.View = View.List
            lstGYOMU.Items.Clear()
            For i As Integer = 0 To tblMenuSection.Rows.Count - 1
                Dim item As New ListViewItem(tblMenuSection.Rows(i).Item("DISP").ToString, i)
                lstGYOMU.Items.Add(item)
                'lstGYOMU.Items.Add(tblMenuSection.Rows(i).Item("DISP"))
            Next i

            '-----表示
            Call FunLOGIN(False) 'ログインパネル表示
            Me.Show()
            Application.DoEvents()


            '-----先回ログインユーザー表示
            Using iniIF As New IniFile(pub_SYSTEM_INI_FILE)
                strBUFF = iniIF.GetIniString("SYSTEM", "USERID")
                If strBUFF <> "" Then
                    Me.txtUSER.Text = strBUFF
                    Me.txtPASSWORD.Focus()
                End If
            End Using

        Catch ex As Exception
            EM.ErrorSyori(ex, False, conblnNonMsg)
        End Try
    End Sub
#End Region

#Region "KEYDOWN"
    'KEYDOWN
    Private Sub FrmMBCA000MENU_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        Dim KeyCode As Short = e.KeyCode

        Try
            '押下されたキーコード取得
            KeyCode = e.KeyCode

            'F1～F12
            If KeyCode >= Windows.Forms.Keys.F1 And KeyCode <= Windows.Forms.Keys.F12 Then
                'F10時に異常動作するのでゴミ消し
                e.Handled = True
                '該当ボタンCLICKイベント生成
                cmdFunc(KeyCode - 112).PerformClick()
            End If

            'ESC
            If KeyCode = Windows.Forms.Keys.Escape Then
                'ログアウト
                cmdLOGOUT.PerformClick()
            End If

            'ENTERキー
            If KeyCode = Windows.Forms.Keys.Return Then
                System.Windows.Forms.SendKeys.Send("{TAB}")
            End If

        Catch ex As Exception
            EM.ErrorSyori(ex)
        End Try

    End Sub
#End Region

#Region "ACTIVATED"

    Private Sub FrmIDA_M000_Activated(sender As Object, e As EventArgs) Handles MyBase.Activated

        If blnLogin = True Then
            Using DB As ClsDbUtility = DBOpen()
                Call SubCheckSime(DB)

                Call SubCheckKADOMasta(DB)

            End Using
        End If
    End Sub
#End Region

#End Region

#Region "FUNCTIONボタン関連"

#Region "ボタンクリックイベント"
    Private Sub CmdFunc_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdFunc9.Click, cmdFunc8.Click, cmdFunc7.Click, cmdFunc6.Click, cmdFunc5.Click, cmdFunc4.Click, cmdFunc3.Click, cmdFunc2.Click, cmdFunc12.Click, cmdFunc11.Click, cmdFunc10.Click, cmdFunc1.Click
        Dim intFUNC As Integer
        Dim intCNT As Integer
        Dim strFUNC As String
        Dim strWKCATEGORY As String
        Dim intCNTWK As Integer
        Try
            '-----ボタン不可/ボタンINDEX取得
            For intCNT = 0 To Me.cmdFunc.Length - 1
                Me.cmdFunc(intCNT).Enabled = False
                If cmdFunc(intCNT) Is sender Then intFUNC = intCNT + 1
            Next

            '-----パス取得
            strFUNC = arrNOW_CMDS(intFUNC - 1).Path

            '-----処理起動
            If Mid(strFUNC, 1, 1) = "<" Then
                '実行ファイルパスが "<" で始まる時は特殊処理
                Sub_SFunc(intFUNC - 1)
            ElseIf Mid(strFUNC, 1, 1) = "[" Then '実行ファイルパスが "[" で始まる時はサブメニュー
                If strFUNC = "[MAIN]" Then 'メインメニュー
                    'タイトルの設定
                    Me.lblTytle.Text = " " & pub_MenuTitle & " "

                    '
                    For intCNT = 0 To 11
                        arrNOW_CMDS(intCNT) = arrCMDS_FUNC(intCNT)
                    Next

                    'メニュー設定
                    Call Sub_MenuSet()

                Else 'サブメニュー
                    '"[]" 抜き
                    strWKCATEGORY = strFUNC.Substring(1, strFUNC.Length - 2)

                    For intCNT = 1 To intCMDS_SUBFUNC 'すべてのサブメニュー記憶に対して
                        '記憶のサブメニューと一致時
                        If strWKCATEGORY = arrCMDS_SUBFUNC(intCNT).Category Then
                            'タイトルの設定
                            Me.lblTytle.Text = " " & arrCMDS_SUBFUNC(intCNT).MenuTitle & " "
                            '
                            For intCNTWK = 0 To 11
                                arrNOW_CMDS(intCNTWK) = arrCMDS_SUBFUNC(intCNT).Cmds(intCNTWK)
                            Next
                            'メニュー設定
                            Call Sub_MenuSet()
                        End If
                    Next

                    'For intCNT = 0 To 11
                    '    If cmdFunc(intCNT).Enabled = True Then
                    '        pnlFunc(intCNT).Focus = True
                    '        Exit For
                    '    End If
                    'Next
                End If
            Else
                'それぞれの実行ファイルを起動する
                Sub_FuncExec(intFUNC - 1)
            End If

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

#Region "コントロールイベント"

#Region "ログインボタンクリック時"
    'ログインボタン
    Private Sub CmdLOGIN_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdLOGIN.Click
        Dim sbSQL As New System.Text.StringBuilder

        Try

            Using DB As ClsDbUtility = DBOpen()
                '-----USER登録チェック
                'SQL
                sbSQL.Append("SELECT * FROM " & NameOf(MODEL.VWM004_SYAIN) & " ")
                sbSQL.Append(" WHERE SYAIN_NO ='" & Me.txtUSER.Text & "' ")
                sbSQL.Append(" AND DEL_FLG ='0' ")

                Using DS As DataSet = DB.GetDataSet(sbSQL.ToString)

                    If DS.Tables(0).Rows.Count = 0 Then
                        MessageBox.Show("該当する社員CDが存在しません。", "ログイン失敗", MessageBoxButtons.OK, MessageBoxIcon.Information)
                        Me.txtPASSWORD.Text = ""
                        Me.txtUSER.Focus()
                        Exit Sub
                    End If

                    '-----PASSWORDチェック
                    With DS.Tables(0).Rows(0)
                        If .Item("PASS").ToString.TrimEnd <> "" AndAlso
                        Me.txtPASSWORD.Text.Trim = .Item("PASS").ToString.Trim Then '入力PASSWORD一致時
                            '記憶
                            pub_SYAIN_INFO = New SYAIN_INFO With {
                            .SYAIN_ID = DS.Tables(0).Rows(0).Item("SYAIN_ID"),
                            .SYAIN_CD = DS.Tables(0).Rows(0).Item("SYAIN_NO"),
                            .SYAIN_NAME = DS.Tables(0).Rows(0).Item("SIMEI"),
                            .PASSWORD = DS.Tables(0).Rows(0).Item("PASS")
                            }

                            'pub_USER_INFO.KENGEN_KB = .Item("KENGEN_KB").ToString.TrimEnd

                            '-----システムINIへログインユーザー記憶
                            Using iniIF As New IniFile(pub_SYSTEM_INI_FILE)
                                iniIF.SetIniString("SYSTEM", "USERID", pub_SYAIN_INFO.SYAIN_CD.Trim)
                            End Using

                        Else '入力PASSWORD不一致時
                            MessageBox.Show("ログインできません。社員IDとパスワードを確認して、もう一度入力して下さい。", "ログイン失敗", MessageBoxButtons.OK, MessageBoxIcon.Information)
                            Me.txtPASSWORD.Text = ""
                            Me.txtPASSWORD.Focus()
                            Exit Sub
                        End If

                        If .Item("DEL_FLG") = "1" Then
                            MessageBox.Show("このユーザーは削除されているためログイン出来ません。", "ログイン無効", MessageBoxButtons.OK, MessageBoxIcon.Information)
                            Exit Sub
                        End If
                    End With
                End Using

                Call SubCheckSime(DB)

                Call SubCheckKADOMasta(DB)

            End Using

            '-----ステータスバー更新
            Me.ToolStripStatusLabelBLANK.Text = "ログイン:" & pub_SYAIN_INFO.SYAIN_CD & " " & pub_SYAIN_INFO.SYAIN_NAME

            '-----ログオフ表示
            Call FunLOGIN(True) 'ログオフパネル表示

            '-----業務選択リスト初期化
            If Me.lstGYOMU.Items.Count > 0 Then
                lstGYOMU.Items(0).Selected = True
                'Me.lstGYOMU.SelectedIndex = -1
                'Me.lstGYOMU.SelectedIndex = 0
                Me.lstGYOMU.Focus()
            End If

            blnLogin = True

        Catch ex As Exception
            EM.ErrorSyori(ex, False, conblnNonMsg)
        End Try
    End Sub
#End Region

#Region "ログインボタンGOTFOCUS"
    'ログインボタンGOTFOCUS
    Private Sub CmdLOGIN_Enter(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmdLOGIN.Enter
        Try
            CmdLOGIN_Click(Nothing, Nothing)
        Catch ex As Exception
            EM.ErrorSyori(ex)
        End Try
    End Sub
#End Region

#Region "ログアウトボタンクリック時"
    'ログアウトボタン
    Private Sub CmdLOGOUT_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdLOGOUT.Click
        Dim strBUFF As String
        Dim intL As Integer

        Try
            '-----他のアプリが起動中時
            If FunProcessCheck() <> "0" Then
                MsgBox("他のアプリを終了させてから、ログアウトして下さい", MsgBoxStyle.Information)
                '抜ける
                Exit Sub
            End If

            '-----ログイン表示
            Call FunLOGIN(False) 'ログインパネル表示

            '画面共通設定
            Call FunFormCommonSetting(pub_APP_INFO, pub_SYAIN_INFO, My.Application.Info.Version.ToString)

            '-----ログイン初期化
            Me.txtUSER.Text = ""
            Me.txtPASSWORD.Text = ""
            Me.txtUSER.Focus()

            '-----先回ログインユーザー表示
            Using iniIF As New IniFile(pub_SYSTEM_INI_FILE)
                strBUFF = iniIF.GetIniString("SYSTEM", "USERID")
                If strBUFF <> "" Then
                    Me.txtUSER.Text = strBUFF
                    Me.txtPASSWORD.Focus()
                End If
            End Using

            '-----メニューボタン初期値セット
            Call Fun_GetMenuIniFile("MAIN", 0)

            '-----メニュー設定
            For intL = 0 To 11
                arrNOW_CMDS(intL) = arrCMDS_FUNC(intL)
            Next intL
            Call Sub_MenuSet()

            '-----ボタン色初期化
            For intL = 0 To Me.pnlFunc.Length - 1
                pnlFunc(intL).BackColor = Me.BackColor
            Next

            blnLogin = False

        Catch ex As Exception
            EM.ErrorSyori(ex, False, conblnNonMsg)
        End Try
    End Sub
#End Region

#Region "変更履歴ボタンクリック時"
    '変更履歴ボタン
    Private Sub BtnRIREKI_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnRIREKI.Click

        Try
            '-----確認画面表示
            Dim dlgRET As DialogResult
            Using frmDLG = New FrmM0010
                dlgRET = frmDLG.ShowDialog(Me)
            End Using

        Catch ex As Exception
            EM.ErrorSyori(ex)
        Finally
        End Try
    End Sub
#End Region

#Region "業務選択リスト選択時"
    '業務選択リスト
    Private Sub LstGYOMU_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lstGYOMU.SelectedIndexChanged
        Dim intL As Integer

        Try
            If Me.Visible = False Then
                Exit Sub
            End If

            If Me.lstGYOMU.SelectedItems.Count > 0 Then

                '-----メニューボタン初期値セット
                Call Fun_GetMenuIniFile(Me.lstGYOMU.SelectedItems(0).Text, Me.lstGYOMU.SelectedItems(0).Index + 1)

                'メニュー設定
                For intL = 0 To 11
                    arrNOW_CMDS(intL) = arrCMDS_FUNC(intL)
                Next intL
                Call Sub_MenuSet()

                '-----タイトルの設定
                Me.lblTytle.Text = " " & pub_MenuTitle & " "

                '-----ボタン色初期化
                For intL = 0 To Me.pnlFunc.Length - 1
                    pnlFunc(intL).BackColor = Me.BackColor
                Next
            End If

        Catch ex As Exception
            EM.ErrorSyori(ex, False, conblnNonMsg)
        End Try
    End Sub
#End Region

#Region "業務リストMouseMoveイベント"
    '業務リストMouseMoveイベント
    Private Sub LstGYOMU_MouseMove(sender As Object, e As MouseEventArgs)
        Try
            'Dim r As Rectangle
            'For x As Int32 = 0 To lstGYOMU.Items.Count - 1
            '    r = lstGYOMU.GetItemRectangle(x)
            '    If r.Contains(e.Location) AndAlso lstGYOMU.Items(x).ToString <> "" Then
            '        lstGYOMU.Cursor = Cursors.Hand
            '        Exit Sub
            '    End If
            'Next
            'lstGYOMU.Cursor = Cursors.Default

        Catch ex As Exception
            EM.ErrorSyori(ex, False, conblnNonMsg)
        End Try
    End Sub
#End Region

#Region "業務リスト 描画"
    Private Sub ListBox_DrawItem(ByVal sender As Object, ByVal e As System.Windows.Forms.DrawItemEventArgs) ' Handles lstGYOMU.DrawItem

        ''▼項目がない場合は何もしない

        'If e.Index = -1 Then
        '    Exit Sub
        'End If

        ''▼アイコンとブラシの用意

        'Dim myBrush As Brush = New SolidBrush(lstGYOMU.ForeColor)
        'Dim Icon As Icon

        ''描画するアイコンを３つごとに適当に決定
        ''実際にはスピード向上のためアイコンを先に読み込んでおくことが望ましい。
        'Select Case e.Index
        '    Case Else
        '        Icon = New Icon(My.Resources._icoMENU128x128, New Size(32, 32))
        'End Select

        ''▼描画実行
        ''e.Graphics.SmoothingMode = Drawing2D.SmoothingMode.HighQuality
        ''e.Graphics.PixelOffsetMode = Drawing2D.PixelOffsetMode.HighQuality
        'e.DrawBackground()

        'Dim g As Graphics = e.Graphics

        'g.DrawIcon(Icon, New Rectangle(e.Bounds.X, e.Bounds.Y, 16, 16))
        'g.TextRenderingHint = Drawing.Text.TextRenderingHint.AntiAlias
        'g.DrawString(lstGYOMU.Items(e.Index), e.Font, myBrush, New RectangleF(e.Bounds.X + 16, e.Bounds.Y + 2, e.Bounds.Width, e.Bounds.Height))
        'e.DrawFocusRectangle()

    End Sub
#End Region

#Region "ボタンFOCUS色設定"
    'FUNCTIONボタン
    Private Sub CmdFunc_MouseMove(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles cmdFunc9.MouseMove, cmdFunc8.MouseMove, cmdFunc7.MouseMove, cmdFunc6.MouseMove, cmdFunc5.MouseMove, cmdFunc4.MouseMove, cmdFunc3.MouseMove, cmdFunc2.MouseMove, cmdFunc12.MouseMove, cmdFunc11.MouseMove, cmdFunc10.MouseMove, cmdFunc1.MouseMove
        Dim intCNT As Integer

        Try
            For intCNT = 0 To Me.cmdFunc.Length - 1
                If cmdFunc(intCNT) Is sender Then
                    PnlFunc_MouseEnter(pnlFunc(intCNT), System.EventArgs.Empty)
                End If
            Next
        Catch ex As Exception
            EM.ErrorSyori(ex, False, conblnNonMsg)
        End Try
    End Sub

    'ボタンのパネル
    Private Sub PnlFunc_MouseEnter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles pnlFunc9.MouseEnter, pnlFunc8.MouseEnter, pnlFunc7.MouseEnter, pnlFunc6.MouseEnter, pnlFunc5.MouseEnter, pnlFunc4.MouseEnter, pnlFunc3.MouseEnter, pnlFunc2.MouseEnter, pnlFunc12.MouseEnter, pnlFunc11.MouseEnter, pnlFunc10.MouseEnter, pnlFunc1.MouseEnter
        Dim intCNT As Integer

        Try
            For intCNT = 0 To Me.pnlFunc.Length - 1
                If pnlFunc(intCNT) Is sender Then
                    pnlFunc(intCNT).BackColor = Color.Cyan
                Else
                    pnlFunc(intCNT).BackColor = Me.BackColor
                End If
            Next
        Catch ex As Exception
            EM.ErrorSyori(ex, False, conblnNonMsg)
        End Try
    End Sub

#End Region

#Region "通知リンクラベルクリックイベント"
    '材料在庫ラベル
    Private Sub LblZAIRYO_ZAIKO_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs)
        'Dim tplResult As (targetDate As Date?, intSIIRE_CD As Integer) = FunExistZairyoMinusYosokuZaiko()
        'With tplResult
        '    If .targetDate.HasValue = True Then
        '        Call FunOpenAppHacyuKeikaku(.targetDate, .intSIIRE_CD)
        '    End If
        'End With
    End Sub

    '製品在庫ラベル
    Private Sub LblSYUKKA_KEIKAKU_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles LinkLabel3.LinkClicked
        'Dim tplResult As (targetDate As Date?, intTOKUI_CD As Integer) = FunExistSeihinMinusYosokuZaiko()
        'With tplResult
        '    If .targetDate.HasValue = True Then
        '        Call FunOpenAppSyuKkaKeikaku(.targetDate, .intTOKUI_CD)
        '    End If
        'End With
    End Sub

    '締め処理ラベル
    Private Sub LblSIME_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles lblSIME.LinkClicked
        Call FunOpenAppSiharai()
    End Sub

    '稼働日マスタラベル
    Private Sub LblCALENDER_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles lblCALENDER.LinkClicked
        Call FunOpenAppKADOMasta()
    End Sub
#End Region

#End Region

#Region "ローカル関数"

#Region "ログインパネル表示"
    'ログインパネル表示
    Private Function FunLOGIN(ByVal blnLOGIN As Boolean) As Boolean
        Try
            If blnLOGIN = False Then
                'ログアウト
                Me.grbLOGIN.BringToFront()
                Me.grbLOGIN.Top = 60 '50
                Me.grbLOGIN.Left = 12 '5
                Me.grbLOGIN.Visible = True

                Me.grbLOGOUT.Visible = False
                Me.grbLOGOUT.Top = 50
                Me.grbLOGOUT.Left = 100

                'ログイン社員情報クリア
                pub_SYAIN_INFO = New SYAIN_INFO

            Else
                'ログイン
                Me.grbLOGOUT.BringToFront()
                Me.grbLOGOUT.Top = 60
                Me.grbLOGOUT.Left = 12
                Me.grbLOGOUT.Visible = True

                Me.grbLOGIN.Visible = False
                Me.grbLOGIN.Top = 50
                Me.grbLOGIN.Left = 100

            End If

            Return True

        Catch ex As Exception
            EM.ErrorSyori(ex, False, conblnNonMsg)
            Return False
        End Try
    End Function
#End Region

#Region "メニュー設定"
    'メニュー設定
    Private Sub Sub_MenuSet()
        Dim lngL As Long
        Dim strBUFF As String

        Try
            For lngL = 0 To 11
                '-----文言設定
                strBUFF = arrNOW_CMDS(lngL).Title
                Me.cmdFunc(lngL).Text = strBUFF

                '-----使用可不可
                'ボタンタイトルなし
                If arrNOW_CMDS(lngL).Title = "" Then
                    Me.cmdFunc(lngL).Enabled = False
                    Me.pnlFunc(lngL).Enabled = False

                    'PASSなし
                ElseIf arrNOW_CMDS(lngL).Path = "" Then
                    Me.cmdFunc(lngL).Enabled = False
                    Me.pnlFunc(lngL).Enabled = False

                    '通常のボタン
                Else
                    Me.cmdFunc(lngL).Enabled = True
                    Me.pnlFunc(lngL).Enabled = True
                End If
            Next lngL

        Catch ex As Exception
            EM.ErrorSyori(ex, False, conblnNonMsg)
        End Try
    End Sub
#End Region

#Region "ファンクションに割り当てられた実行ファイルを起動する"
    'ファンクションに割り当てられた実行ファイルを起動する
    Private Sub Sub_FuncExec(ByVal intIndex As Integer)
        Dim hProcess As New System.Diagnostics.Process
        Dim strEXE As String
        Dim strARG As String
        Dim strBUFF As String
        Dim intBUFF As Integer

        Try
            '-----EXE名にブランク位置取得
            intBUFF = arrNOW_CMDS(intIndex).Path.IndexOf(" ")


            'EXE名にブランク無し時
            If intBUFF = -1 Then
                '-----実行ファイルパス取得
                strEXE = FunGetRootPath() & FunGetEXEPath() & arrNOW_CMDS(intIndex).Path

                '-----引数作成
                '担当コード
                strARG = pub_SYAIN_INFO.SYAIN_ID & Space(1)
                '担当名
                'strARG = strARG & pub_SYAIN_INFO.SYAIN_NAME & Space(1)
                ''権限(0:権限無し,1:参照権限,2:更新権限)
                'strARG = strARG & pub_USER_INFO.KENGEN_KB
                ''strARG = strARG & hsAUTHORITY(Me.lstGYOMU.SelectedItem.ToString.Trim)

            Else 'EXE名にブランク有時
                strBUFF = arrNOW_CMDS(intIndex).Path.Substring(0, intBUFF)

                '-----実行ファイルパス取得
                strEXE = FunGetRootPath() & FunGetEXEPath() & arrNOW_CMDS(intIndex).Path.Substring(0, intBUFF)


                '-----引数取得
                '｢HANYO.INI｣とか
                strARG = arrNOW_CMDS(intIndex).Path.Substring(intBUFF + 1)
            End If

            '-----起動
            If System.IO.File.Exists(strEXE) = True Then
                'hProcess = System.Diagnostics.Process.Start(strEXE, strARG)
                hProcess.StartInfo.FileName = strEXE
                hProcess.StartInfo.Arguments = strARG
                hProcess.SynchronizingObject = Me
                AddHandler hProcess.Exited, AddressOf ProcessExited
                hProcess.EnableRaisingEvents = True
                hProcess.Start()

                Call SetTaskbarInfo(ENM_TASKBAR_STATE._2_Normal, 100)
                Call SetTaskbarOverlayIcon(System.Drawing.SystemIcons.Application)
            Else
                Dim strMsg As String
                strMsg = "下記プログラムファイルが見つかりません。" & vbCrLf & "システム管理者にご連絡下さい。" &
                            vbCrLf & vbCrLf & strEXE
                MessageBox.Show(strMsg, My.Application.Info.AssemblyName, MessageBoxButtons.OK, MessageBoxIcon.Information)
            End If

            'プロセス終了を待機しない------------------------------------
            ''-----子がアイドル状態になるまで待機
            'hProcess.WaitForInputIdle()

            ''-----自分非表示
            'Me.Hide()

            ''-----子が終了するまで待機
            'hProcess.WaitForExit()
            '------------------------------------------------------------

        Catch ex As Exception
            EM.ErrorSyori(ex, False, conblnNonMsg)

        Finally
            'プロセス終了を待機しない------------------------------------
            ''-----自分表示
            'Me.Show()
            'Me.lstGYOMU.Focus()
            'Me.Activate()
            'Me.BringToFront()
            '------------------------------------------------------------

            ''-----開放
            'If hProcess IsNot Nothing Then
            '    hProcess.Close()
            'End If
        End Try

    End Sub

    Private Sub ProcessExited(ByVal sender As Object, ByVal e As EventArgs)
        Call SetTaskbarOverlayIcon(Nothing)
        Call SetTaskbarInfo(ENM_TASKBAR_STATE._0_NoProgress)
    End Sub

#End Region

#Region "割り当てられた特殊処理を行う"
    '割り当てられた特殊処理を行う
    Private Sub Sub_SFunc(ByVal intIndex As Integer)
        Dim strFUNC As String
        Dim strBUFF As String

        Try
            '-----処理名取得
            strFUNC = arrNOW_CMDS(intIndex).Path

            If InStr(1, UCase(strFUNC), "<END>") > 0 Then  '終了ボタン時

                '他のアプリが起動中時
                strBUFF = FunProcessCheck()

                If strBUFF <> "0" Then
                    'If MsgBox("他のアプリがまだ起動中ですが、メニューを閉じますか？" & vbCrLf & strBUFF, MsgBoxStyle.Information + MsgBoxStyle.YesNo + MsgBoxStyle.DefaultButton2) = MsgBoxResult.No Then
                    If MsgBox("他のアプリがまだ起動中ですが、メニューを閉じますか？", MsgBoxStyle.Information + MsgBoxStyle.YesNo + MsgBoxStyle.DefaultButton2) = MsgBoxResult.No Then
                        '抜ける
                        Exit Sub
                    End If
                End If


                '-----終了
                Me.Close()

            End If


        Catch ex As Exception
            EM.ErrorSyori(ex)
        End Try
    End Sub
#End Region

#Region "他のアプリ起動中チェック"
    '他のアプリ起動中チェック
    Private Function Fun_ProcessCheck() As String
        Dim strBUFF As String
        'Dim intRET As Integer

        Try
            'ROOTPATH取得
#If DEBUG Then
            strBUFF = FunGetRootPath() & "\EXE_DEBUG\"
#Else
            strBUFF = FunGetRootPath() & "\EXE\"
#End If

            Using mc As New System.Management.ManagementClass("Win32_Process")
                Using moc As System.Management.ManagementObjectCollection = mc.GetInstances()
                    For Each mo As System.Management.ManagementObject In moc
                        If mo("Name").Contains(My.Application.Info.AssemblyName) = True Then
                            Continue For
                        End If
                        If mo("ExecutablePath") IsNot Nothing AndAlso mo("ExecutablePath").ToString.Contains(strBUFF) = True Then
                            Return mo("ExecutablePath")
                        End If
                    Next mo
                End Using
            End Using

            Return 0

        Catch ex As Exception
            EM.ErrorSyori(ex, False, conblnNonMsg)
            Return -1
        End Try
    End Function

    Private Function FunProcessCheck() As String
        Dim ps As System.Diagnostics.Process()
        Dim strBUFF As String
        'Dim intRET As Integer

        Try
            'ROOTPATH取得
#If DEBUG Then
            strBUFF = FunGetRootPath() & "\EXE_DEBUG\"
#Else
            strBUFF = FunGetRootPath() & "\EXE\"
#End If


            'ローカルコンピュータ上で実行されているすべてのプロセスを取得
            ps = System.Diagnostics.Process.GetProcesses

            'Dim strMyApp As String = My.Application.Info.AssemblyName
            'Dim p As List(Of Process) = ps.AsEnumerable().Where(Function(r) r.ProcessName.Contains(strMyApp) = False And r.MainModule.FileName.Contains(strBUFF)).ToList
            'If p.Count > 0 Then
            '    Return p(0).MainModule.FileName
            'End If

            Dim p As System.Diagnostics.Process
            For Each p In ps.AsQueryable().Where(Function(process) process.MainModule.FileName.Contains(strBUFF))


                'メインモジュールが、自アプリ時
                If p.ProcessName.Contains(My.Application.Info.AssemblyName) = True Then
                    '次へ
                    Continue For
                Else
                    ''裏処理モジュールはスキップ
                    'If p.ProcessName.Contains("MBCT010TIMEREC") = True Then
                    '    '次へ
                    '    Continue For
                    'End If
                    '抜ける
                    Return p.MainModule.FileName
                End If
            Next p

            Return 0
        Catch exWin32 As System.ComponentModel.Win32Exception
            'プロセスアクセス拒否 64bitプロセスから32bitプロセスにアクセス(またはその逆)等
            Return 0
        Catch ex As Exception
            EM.ErrorSyori(ex, False, conblnNonMsg)
            Return -1
        End Try
    End Function
#End Region

#Region "締め処理チェック"
    Private Sub SubCheckSime(ByVal DB As ClsDbUtility)
        'Dim strYM As String
        Try
            ''-----締め処理状況取得
            'strYM = FunGetCodeMastaValue(DB, "締処理", "締処理月")

            ''前月の締処理が未実施の場合、通知
            'If strYM < Today.AddMonths(-1).ToString("yyyyMM") Then
            '    Me.lblSIME.Text = "前月の締め処理が実施されていません。" & vbCrLf & "(" & DateTime.ParseExact(strYM, "yyyyMM", Nothing).ToString("yyyy年MM月度") & "まで締め処理済)"
            '    Me.lblSIME.Cursor = Cursors.Hand
            'Else
            Me.lblSIME.Text = ""
            Me.lblSIME.Cursor = Cursors.Default
            'End If

        Catch ex As Exception
            EM.ErrorSyori(ex, False, conblnNonMsg)
        End Try

    End Sub

#Region "支払処理画面表示"

    Private Function FunOpenAppSiharai() As Boolean

        'Try
        '    Dim strEXE As String = FunGetRootPath() & FunGetEXEPath() & Context.CON_PG_G090
        '    Dim strParam As String = pub_SYAIN_INFO.SYAIN_ID & Space(1)

        '    Return FunCallEXE(strEXE, strParam, 1)

        'Catch ex As Exception
        '    EM.ErrorSyori(ex, False, conblnNonMsg)
        '    Return False
        'End Try
    End Function

#End Region
#End Region

#Region "稼働日マスタチェック"
    Private Sub SubCheckKADOMasta(ByVal DB As ClsDbUtility)
        Dim sbSQL As New System.Text.StringBuilder

        Try
            '-----カレンダー登録状況取得
            sbSQL.Remove(0, sbSQL.Length)
            sbSQL.Append("SELECT")
            sbSQL.Append(" MAX(SUBSTRING(YMD,1,4)+'/'+SUBSTRING(YMD,5,2)+'/'+SUBSTRING(YMD,7,2)) MAX_YMD ")
            sbSQL.Append(" FROM " & NameOf(MODEL.M006_CALENDAR) & " ")

            Using dsList As DataSet = DB.GetDataSet(sbSQL.ToString)
                '表示
                Me.lblCALENDER.Text = ""
                Me.lblCALENDER.Cursor = Cursors.Default
                With dsList.Tables(0)
                    If .Rows(0).Item("MAX_YMD").ToString.TrimEnd = "" Then
                        Me.lblCALENDER.Text = "稼働日マスタを登録して下さい。"
                        Me.lblCALENDER.Cursor = Cursors.Hand
                    Else
                        '最大登録日がシステム日＋３月以内時
                        If System.DateTime.Now.AddMonths(3).ToString("yyyy/MM/dd") > .Rows(0).Item("MAX_YMD").ToString.TrimEnd Then
                            Me.lblCALENDER.Text = "近く稼働日マスタを登録して下さい。" & vbCrLf & "(" & .Rows(0).Item("MAX_YMD").ToString.TrimEnd & "まで登録済)"
                            Me.lblCALENDER.Cursor = Cursors.Hand
                        End If
                    End If
                End With
            End Using


        Catch ex As Exception
            EM.ErrorSyori(ex, False, conblnNonMsg)
        End Try
    End Sub

#Region "稼働日マスタ画面表示"

    Private Function FunOpenAppKADOMasta() As Boolean

        Try
            Dim strEXE As String = FunGetRootPath() & FunGetEXEPath() & "Context.CON_PG_M120"
            Dim strParam As String = pub_SYAIN_INFO.SYAIN_ID & Space(1)

            Return FunCallEXE(strEXE, strParam, 1)

        Catch ex As Exception
            EM.ErrorSyori(ex, False, conblnNonMsg)
            Return False
        End Try
    End Function


#End Region

#End Region


#End Region


End Class
