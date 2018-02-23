Imports JMS_COMMON.ClsPubMethod

Public Class FrmBaseSts

#Region "変数・定数"
    Private WithEvents TssTime As New Windows.Forms.ToolStripStatusLabel

    Protected clrPG_STATUS_INACTIVE As Color = SystemColors.InactiveBorder
    Public Shared clrPG_STATUS_ACTIVE As Color = Color.FromArgb(0, 140, 255) 'Color.FromArgb(0, 161, 255)
    Public Shared clrPG_STATUS_PROCESSING As Color = Color.FromArgb(255, 110, 30) 'Color.OrangeRed 'Color.DarkOrange
    Public Shared clrPG_STATUS_ERROR As Color = Color.Red

    Private priblnMode As Boolean
#End Region

#Region "プロパティ"

    Private _blnEventHandled As Boolean

    ''' <summary>
    ''' PGステータス
    ''' </summary>
    Public Property PrPG_STATUS As ENM_PG_STATUS
        Get
            Dim intRET As Integer
            Select Case True
                Case Me.StatusStrip.BackColor = clrPG_STATUS_INACTIVE
                    intRET = ENM_PG_STATUS._1_INACTIVE
                Case Me.StatusStrip.BackColor = clrPG_STATUS_ACTIVE
                    intRET = ENM_PG_STATUS._2_ACTIVE
                Case Me.StatusStrip.BackColor = clrPG_STATUS_PROCESSING
                    intRET = ENM_PG_STATUS._3_PROCESSING
                Case Me.StatusStrip.BackColor = clrPG_STATUS_ERROR
                    intRET = ENM_PG_STATUS._9_ERROR
            End Select

            Return intRET
        End Get
        Set(value As ENM_PG_STATUS)
            Select Case value
                Case ENM_PG_STATUS._1_INACTIVE
                    Me.StatusStrip.BackColor = clrPG_STATUS_INACTIVE
                    _blnEventHandled = True
                Case ENM_PG_STATUS._2_ACTIVE
                    Me.StatusStrip.BackColor = clrPG_STATUS_ACTIVE
                    _blnEventHandled = False
                Case ENM_PG_STATUS._3_PROCESSING
                    Me.StatusStrip.BackColor = clrPG_STATUS_PROCESSING
                    _blnEventHandled = True
                Case ENM_PG_STATUS._9_ERROR
                    Me.StatusStrip.BackColor = clrPG_STATUS_ERROR
                    _blnEventHandled = True
            End Select
            Application.DoEvents()
        End Set
    End Property

    Public Property ShowStatusBar As Boolean
        Get
            Return Me.StatusStrip.Visible
        End Get
        Set(value As Boolean)
            Me.StatusStrip.Visible = value
        End Set
    End Property


#End Region


#Region "FORMイベント"

    Private Sub Form_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        '-----ステータスバー

        Me.ToolStripStatusLabelVERSION.Width = 155
        Me.ToolStripStatusLabelVERSION.IsLink = True
        ToolStripStatusLabelPCNAME.Width = 190


        'PCNAME
        Me.ToolStripStatusLabelPCNAME.Text = "端末:" & System.Net.Dns.GetHostName


        'CAPS
        Dim kspCAPS As New KeyStatePanel(KeyStatePanel.KeyStatePanelStyle.CapsLock) With {
            .Name = "ToolStripStatusLabelCAPS",
            .Text = "CAPS",
            .Font = New System.Drawing.Font("Meiryo UI", 10, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        }
        Me.StatusStrip.Items.Add(kspCAPS)

        'NUM
        Dim kspNUM As New KeyStatePanel(KeyStatePanel.KeyStatePanelStyle.NumLock) With {
            .Name = "ToolStripStatusLabelNUM",
            .Text = "NUM",
            .Font = New System.Drawing.Font("Meiryo UI", 10, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        }
        Me.StatusStrip.Items.Add(kspNUM)

        'カナ
        Dim kspKANA As New KeyStatePanel(KeyStatePanel.KeyStatePanelStyle.KanaLock) With {
            .Name = "ToolStripStatusLabelKANA",
            .Text = "ｶﾅ",
            .Font = New System.Drawing.Font("Meiryo UI", 10, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        }
        Me.StatusStrip.Items.Add(kspKANA)

        'INS
        Dim kspINS As New KeyStatePanel(KeyStatePanel.KeyStatePanelStyle.Insert) With {
            .Name = "ToolStripStatusLabelINS",
            .Text = "INS",
            .Font = New System.Drawing.Font("Meiryo UI", 10, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        }
        Me.StatusStrip.Items.Add(kspINS)

        'SCRL
        Dim kspSCRL As New KeyStatePanel(KeyStatePanel.KeyStatePanelStyle.ScrollLock) With {
            .Name = "ToolStripStatusLabelSCRL",
            .Text = "SCRL",
            .Font = New System.Drawing.Font("Meiryo UI", 10, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        }
        Me.StatusStrip.Items.Add(kspSCRL)

        TssTime.Name = "ToolStripStatusLabelTIME"
        TssTime.Spring = True
        TssTime.AutoSize = False
        TssTime.BorderSides = ToolStripStatusLabelBorderSides.All
        TssTime.BorderStyle = Border3DStyle.SunkenOuter
        TssTime.TextAlign = ContentAlignment.MiddleCenter
        TssTime.Font = New System.Drawing.Font("Meiryo UI", 10, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        TssTime.IsLink = True
        TssTime.LinkBehavior = LinkBehavior.NeverUnderline
        TssTime.LinkColor = Color.Black
        TssTime.ActiveLinkColor = Color.Black
        Me.StatusStrip.Items.Add(TssTime)

        Call TimerTime_Tick(Nothing, Nothing)

        If _blnEventHandled = False Then
            PrPG_STATUS = ENM_PG_STATUS._2_ACTIVE
            For Each item As ToolStripStatusLabel In Me.StatusStrip.Items
                item.BorderSides = ToolStripStatusLabelBorderSides.None
                item.ForeColor = Color.White
                item.Font = New Font("Meiryo UI", 9, FontStyle.Regular, GraphicsUnit.Point, CType(128, Byte))
                item.LinkColor = item.ForeColor
            Next item
        End If

    End Sub

    Private Sub FrmBaseStsBtn_Resize(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Resize
        If Me.Visible = False Then Exit Sub

        '-----ステータスバー描画
        Me.ToolStripStatusLabelBLANK.Width = Me.Width - 810 '624

    End Sub

    Protected Function FunFormCommonSetting(ByVal objPG_INFO As Object, ByVal objUSER_INFO As Object, ByVal strVersion As String) As Boolean
        Try
            'Dim _PG_INFO As PG_INFO = TryCast(objPG_INFO, PG_INFO)
            'Dim _USER_INFO As PG_INFO = TryCast(objUSER_INFO, PG_INFO)

            '-----フォーム共通設定
            Me.lblTytle.Text = objPG_INFO.strTitle
            Me.Text = Me.lblTytle.Text
            Me.BackColor = objPG_INFO.clrFORM_BACK
            Me.lblTytle.BackColor = objPG_INFO.clrTITLE_LABEL

            '-----ステータスバー:ログインユーザー名
            If objUSER_INFO.SYAIN_NAME <> "" Then
                Me.ToolStripStatusLabelBLANK.Text = "ログイン:" & objUSER_INFO.SYAIN_ID & " " & objUSER_INFO.SYAIN_NAME
            End If

            'VERSION
            Me.ToolStripStatusLabelVERSION.Text = "Ver " & strVersion

        Catch ex As Exception
            EM.ErrorSyori(ex, False, conblnNonMsg)
        End Try
    End Function

    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub Frm_Deactivate(sender As Object, e As EventArgs) Handles MyBase.Deactivate
        If _blnEventHandled = False Then
            PrPG_STATUS = ENM_PG_STATUS._1_INACTIVE
            _blnEventHandled = False
            For Each item As ToolStripStatusLabel In Me.StatusStrip.Items
                item.BorderSides = ToolStripStatusLabelBorderSides.None
                item.ForeColor = Color.Black
                item.Font = New Font("Meiryo UI", 9, FontStyle.Regular, GraphicsUnit.Point, CType(128, Byte))
                item.LinkColor = item.ForeColor
            Next item
        End If
    End Sub

    Private Sub Frm_Activated(sender As Object, e As EventArgs) Handles MyBase.Activated
        If _blnEventHandled = False Then
            PrPG_STATUS = ENM_PG_STATUS._2_ACTIVE
            For Each item As ToolStripStatusLabel In Me.StatusStrip.Items
                item.BorderSides = ToolStripStatusLabelBorderSides.None
                item.ForeColor = Color.White
                item.Font = New Font("Meiryo UI", 9, FontStyle.Regular, GraphicsUnit.Point, CType(128, Byte))
                item.LinkColor = item.ForeColor
            Next item
        End If
    End Sub


    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub TimerTime_Tick(sender As Object, e As EventArgs) Handles TimerTime.Tick
        If DesignMode = False Then
            If priblnMode Then
                TssTime.Text = FunGetWarekiFormat(DateTime.Now, "gyy年MM月dd日 (ddd) HH:mm:ss")
            Else
                TssTime.Text = DateTime.Now.ToString("yyyy/MM/dd (ddd) HH:mm:ss")
            End If
        End If
    End Sub
    Private Sub TssTime_Click(sender As Object, e As EventArgs) Handles TssTime.Click
        priblnMode = Not priblnMode
        Call TimerTime_Tick(Nothing, Nothing)
    End Sub

    Private Sub Frm_StyleChanged(sender As Object, e As EventArgs) Handles MyBase.StyleChanged

        Select Case Me.FormBorderStyle
            Case FormBorderStyle.FixedDialog
                Me.StatusStrip.SizingGrip = False
            Case Else
                Me.StatusStrip.SizingGrip = True
        End Select
    End Sub

    Private Sub ToolStripStatusLabelVERSION_Click(sender As Object, e As EventArgs) Handles ToolStripStatusLabelVERSION.Click
        Dim strMsg As String
#If DEBUG = True Then
        strMsg = String.Format("ビルド日時：{0}" & vbCrLf & "ビルド構成：{1}", FunGetBuildDatetime(My.Application.Info.Version).ToString("yyyy/MM/dd(ddd) HH:mm:ss"), "Debug")
#Else
        'strMsg = String.Format("バージョン:{0}" & vbCrLf & "ビルド構成：{1}", My.Application.Info.Version.ToString, "Release")
        strMsg = String.Format("ビルド日時：{0}" & vbCrLf & "ビルド構成：{1}", FunGetBuildDatetime(My.Application.Info.Version).ToString("yyyy/MM/dd(ddd) HH:mm:ss"), "Release")
#End If

        MessageBox.Show(strMsg, "バージョン情報", MessageBoxButtons.OK, MessageBoxIcon.Information)
    End Sub
#End Region


End Class