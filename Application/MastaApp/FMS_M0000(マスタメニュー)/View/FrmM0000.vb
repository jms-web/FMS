Imports JMS_COMMON.ClsPubMethod

'UNDONE: ���O�C���E���O�A�E�g�p�l����ManagedPanel�ɒu������

Public Class FrmM0000

#Region "�萔�E�ϐ�"
    Private cmdFunc() As Button '�{�^���z��
    Private pnlFunc() As Panel  '�{�^���p�l���z��

    Private arrNOW_CMDS(11) As CMDS_TYPE
    'Private hsAUTHORITY As New Hashtable

    Private memoryImage As Bitmap
    Private blnALTPRT As Boolean 'TRUE:�őO��WINDOW�AFALSE:DESKTOP

    Private blnLogin As Boolean
#End Region

#Region "�R���X�g���N�^"
    ''' <summary>
    ''' �R���X�g���N�^
    ''' </summary>
    ''' <remarks>�R���X�g���N�^</remarks>
    Public Sub New()

        ' ���̌Ăяo���̓f�U�C�i�[�ŕK�v�ł��B
        InitializeComponent()

        Me.Icon = My.Resources._icoMENU128x128
    End Sub
#End Region

#Region "Form�C�x���g"

#Region "ROAD"
    Private Sub FrmLoad(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Dim strBUFF As String
        Dim intL As Integer

        Try
            '��ʋ��ʐݒ�
            Call FunFormCommonSetting(pub_APP_INFO, pub_SYAIN_INFO, My.Application.Info.Version.ToString)

            '-----���O�C���\��
            Me.grbLOGOUT.Visible = False
            Me.grbLOGIN.BringToFront()
            Me.grbLOGIN.Visible = True

            '-----�{�^���z��
            '�{�^���z��̍쐬
            Me.cmdFunc = New System.Windows.Forms.Button(11) {}

            '�{�^���z��ɉ�ʂɒu�����{�^������
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

            '-----�{�^���p�l���z��
            '�{�^���p�l���z��̍쐬
            Me.pnlFunc = New System.Windows.Forms.Panel(11) {}

            '�{�^���p�l���z��ɉ�ʂɒu�����p�l������
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

            '-----���j���[�ݒ�
            For intL = 0 To 11
                arrNOW_CMDS(intL) = arrCMDS_FUNC(intL)
            Next intL
            Call Sub_MenuSet()


            '�Ɩ����ރZ�b�g
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

            '-----�\��
            Call FunLOGIN(False) '���O�C���p�l���\��
            Me.Show()
            Application.DoEvents()


            '-----��񃍃O�C�����[�U�[�\��
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
            '�������ꂽ�L�[�R�[�h�擾
            KeyCode = e.KeyCode

            'F1�`F12
            If KeyCode >= Windows.Forms.Keys.F1 And KeyCode <= Windows.Forms.Keys.F12 Then
                'F10���Ɉُ퓮�삷��̂ŃS�~����
                e.Handled = True
                '�Y���{�^��CLICK�C�x���g����
                cmdFunc(KeyCode - 112).PerformClick()
            End If

            'ESC
            If KeyCode = Windows.Forms.Keys.Escape Then
                '���O�A�E�g
                cmdLOGOUT.PerformClick()
            End If

            'ENTER�L�[
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

#Region "FUNCTION�{�^���֘A"

#Region "�{�^���N���b�N�C�x���g"
    Private Sub CmdFunc_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdFunc9.Click, cmdFunc8.Click, cmdFunc7.Click, cmdFunc6.Click, cmdFunc5.Click, cmdFunc4.Click, cmdFunc3.Click, cmdFunc2.Click, cmdFunc12.Click, cmdFunc11.Click, cmdFunc10.Click, cmdFunc1.Click
        Dim intFUNC As Integer
        Dim intCNT As Integer
        Dim strFUNC As String
        Dim strWKCATEGORY As String
        Dim intCNTWK As Integer
        Try
            '-----�{�^���s��/�{�^��INDEX�擾
            For intCNT = 0 To Me.cmdFunc.Length - 1
                Me.cmdFunc(intCNT).Enabled = False
                If cmdFunc(intCNT) Is sender Then intFUNC = intCNT + 1
            Next

            '-----�p�X�擾
            strFUNC = arrNOW_CMDS(intFUNC - 1).Path

            '-----�����N��
            If Mid(strFUNC, 1, 1) = "<" Then
                '���s�t�@�C���p�X�� "<" �Ŏn�܂鎞�͓��ꏈ��
                Sub_SFunc(intFUNC - 1)
            ElseIf Mid(strFUNC, 1, 1) = "[" Then '���s�t�@�C���p�X�� "[" �Ŏn�܂鎞�̓T�u���j���[
                If strFUNC = "[MAIN]" Then '���C�����j���[
                    '�^�C�g���̐ݒ�
                    Me.lblTytle.Text = " " & pub_MenuTitle & " "

                    '
                    For intCNT = 0 To 11
                        arrNOW_CMDS(intCNT) = arrCMDS_FUNC(intCNT)
                    Next

                    '���j���[�ݒ�
                    Call Sub_MenuSet()

                Else '�T�u���j���[
                    '"[]" ����
                    strWKCATEGORY = strFUNC.Substring(1, strFUNC.Length - 2)

                    For intCNT = 1 To intCMDS_SUBFUNC '���ׂẴT�u���j���[�L���ɑ΂���
                        '�L���̃T�u���j���[�ƈ�v��
                        If strWKCATEGORY = arrCMDS_SUBFUNC(intCNT).Category Then
                            '�^�C�g���̐ݒ�
                            Me.lblTytle.Text = " " & arrCMDS_SUBFUNC(intCNT).MenuTitle & " "
                            '
                            For intCNTWK = 0 To 11
                                arrNOW_CMDS(intCNTWK) = arrCMDS_SUBFUNC(intCNT).Cmds(intCNTWK)
                            Next
                            '���j���[�ݒ�
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
                '���ꂼ��̎��s�t�@�C�����N������
                Sub_FuncExec(intFUNC - 1)
            End If

        Catch ex As Exception
            EM.ErrorSyori(ex)

        Finally
            '�{�^����
            System.Windows.Forms.Application.DoEvents()
            For intCNT = 0 To Me.cmdFunc.Length - 1
                Me.cmdFunc(intCNT).Enabled = True
            Next
        End Try

    End Sub
#End Region

#End Region

#Region "�R���g���[���C�x���g"

#Region "���O�C���{�^���N���b�N��"
    '���O�C���{�^��
    Private Sub CmdLOGIN_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdLOGIN.Click
        Dim sbSQL As New System.Text.StringBuilder

        Try

            Using DB As ClsDbUtility = DBOpen()
                '-----USER�o�^�`�F�b�N
                'SQL
                sbSQL.Append("SELECT * FROM " & NameOf(MODEL.VWM004_SYAIN) & " ")
                sbSQL.Append(" WHERE SYAIN_NO ='" & Me.txtUSER.Text & "' ")
                sbSQL.Append(" AND DEL_FLG ='0' ")

                Using DS As DataSet = DB.GetDataSet(sbSQL.ToString)

                    If DS.Tables(0).Rows.Count = 0 Then
                        MessageBox.Show("�Y������Ј�CD�����݂��܂���B", "���O�C�����s", MessageBoxButtons.OK, MessageBoxIcon.Information)
                        Me.txtPASSWORD.Text = ""
                        Me.txtUSER.Focus()
                        Exit Sub
                    End If

                    '-----PASSWORD�`�F�b�N
                    With DS.Tables(0).Rows(0)
                        If .Item("PASS").ToString.TrimEnd <> "" AndAlso
                        Me.txtPASSWORD.Text.Trim = .Item("PASS").ToString.Trim Then '����PASSWORD��v��
                            '�L��
                            pub_SYAIN_INFO = New SYAIN_INFO With {
                            .SYAIN_ID = DS.Tables(0).Rows(0).Item("SYAIN_ID"),
                            .SYAIN_CD = DS.Tables(0).Rows(0).Item("SYAIN_NO"),
                            .SYAIN_NAME = DS.Tables(0).Rows(0).Item("SIMEI"),
                            .PASSWORD = DS.Tables(0).Rows(0).Item("PASS")
                            }

                            'pub_USER_INFO.KENGEN_KB = .Item("KENGEN_KB").ToString.TrimEnd

                            '-----�V�X�e��INI�փ��O�C�����[�U�[�L��
                            Using iniIF As New IniFile(pub_SYSTEM_INI_FILE)
                                iniIF.SetIniString("SYSTEM", "USERID", pub_SYAIN_INFO.SYAIN_CD.Trim)
                            End Using

                        Else '����PASSWORD�s��v��
                            MessageBox.Show("���O�C���ł��܂���B�Ј�ID�ƃp�X���[�h���m�F���āA������x���͂��ĉ������B", "���O�C�����s", MessageBoxButtons.OK, MessageBoxIcon.Information)
                            Me.txtPASSWORD.Text = ""
                            Me.txtPASSWORD.Focus()
                            Exit Sub
                        End If

                        If .Item("DEL_FLG") = "1" Then
                            MessageBox.Show("���̃��[�U�[�͍폜����Ă��邽�߃��O�C���o���܂���B", "���O�C������", MessageBoxButtons.OK, MessageBoxIcon.Information)
                            Exit Sub
                        End If
                    End With
                End Using

                Call SubCheckSime(DB)

                Call SubCheckKADOMasta(DB)

            End Using

            '-----�X�e�[�^�X�o�[�X�V
            Me.ToolStripStatusLabelBLANK.Text = "���O�C��:" & pub_SYAIN_INFO.SYAIN_CD & " " & pub_SYAIN_INFO.SYAIN_NAME

            '-----���O�I�t�\��
            Call FunLOGIN(True) '���O�I�t�p�l���\��

            '-----�Ɩ��I�����X�g������
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

#Region "���O�C���{�^��GOTFOCUS"
    '���O�C���{�^��GOTFOCUS
    Private Sub CmdLOGIN_Enter(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmdLOGIN.Enter
        Try
            CmdLOGIN_Click(Nothing, Nothing)
        Catch ex As Exception
            EM.ErrorSyori(ex)
        End Try
    End Sub
#End Region

#Region "���O�A�E�g�{�^���N���b�N��"
    '���O�A�E�g�{�^��
    Private Sub CmdLOGOUT_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdLOGOUT.Click
        Dim strBUFF As String
        Dim intL As Integer

        Try
            '-----���̃A�v�����N������
            If FunProcessCheck() <> "0" Then
                MsgBox("���̃A�v�����I�������Ă���A���O�A�E�g���ĉ�����", MsgBoxStyle.Information)
                '������
                Exit Sub
            End If

            '-----���O�C���\��
            Call FunLOGIN(False) '���O�C���p�l���\��

            '��ʋ��ʐݒ�
            Call FunFormCommonSetting(pub_APP_INFO, pub_SYAIN_INFO, My.Application.Info.Version.ToString)

            '-----���O�C��������
            Me.txtUSER.Text = ""
            Me.txtPASSWORD.Text = ""
            Me.txtUSER.Focus()

            '-----��񃍃O�C�����[�U�[�\��
            Using iniIF As New IniFile(pub_SYSTEM_INI_FILE)
                strBUFF = iniIF.GetIniString("SYSTEM", "USERID")
                If strBUFF <> "" Then
                    Me.txtUSER.Text = strBUFF
                    Me.txtPASSWORD.Focus()
                End If
            End Using

            '-----���j���[�{�^�������l�Z�b�g
            Call Fun_GetMenuIniFile("MAIN", 0)

            '-----���j���[�ݒ�
            For intL = 0 To 11
                arrNOW_CMDS(intL) = arrCMDS_FUNC(intL)
            Next intL
            Call Sub_MenuSet()

            '-----�{�^���F������
            For intL = 0 To Me.pnlFunc.Length - 1
                pnlFunc(intL).BackColor = Me.BackColor
            Next

            blnLogin = False

        Catch ex As Exception
            EM.ErrorSyori(ex, False, conblnNonMsg)
        End Try
    End Sub
#End Region

#Region "�ύX�����{�^���N���b�N��"
    '�ύX�����{�^��
    Private Sub BtnRIREKI_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnRIREKI.Click

        Try
            '-----�m�F��ʕ\��
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

#Region "�Ɩ��I�����X�g�I����"
    '�Ɩ��I�����X�g
    Private Sub LstGYOMU_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lstGYOMU.SelectedIndexChanged
        Dim intL As Integer

        Try
            If Me.Visible = False Then
                Exit Sub
            End If

            If Me.lstGYOMU.SelectedItems.Count > 0 Then

                '-----���j���[�{�^�������l�Z�b�g
                Call Fun_GetMenuIniFile(Me.lstGYOMU.SelectedItems(0).Text, Me.lstGYOMU.SelectedItems(0).Index + 1)

                '���j���[�ݒ�
                For intL = 0 To 11
                    arrNOW_CMDS(intL) = arrCMDS_FUNC(intL)
                Next intL
                Call Sub_MenuSet()

                '-----�^�C�g���̐ݒ�
                Me.lblTytle.Text = " " & pub_MenuTitle & " "

                '-----�{�^���F������
                For intL = 0 To Me.pnlFunc.Length - 1
                    pnlFunc(intL).BackColor = Me.BackColor
                Next
            End If

        Catch ex As Exception
            EM.ErrorSyori(ex, False, conblnNonMsg)
        End Try
    End Sub
#End Region

#Region "�Ɩ����X�gMouseMove�C�x���g"
    '�Ɩ����X�gMouseMove�C�x���g
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

#Region "�Ɩ����X�g �`��"
    Private Sub ListBox_DrawItem(ByVal sender As Object, ByVal e As System.Windows.Forms.DrawItemEventArgs) ' Handles lstGYOMU.DrawItem

        ''�����ڂ��Ȃ��ꍇ�͉������Ȃ�

        'If e.Index = -1 Then
        '    Exit Sub
        'End If

        ''���A�C�R���ƃu���V�̗p��

        'Dim myBrush As Brush = New SolidBrush(lstGYOMU.ForeColor)
        'Dim Icon As Icon

        ''�`�悷��A�C�R�����R���ƂɓK���Ɍ���
        ''���ۂɂ̓X�s�[�h����̂��߃A�C�R�����ɓǂݍ���ł������Ƃ��]�܂����B
        'Select Case e.Index
        '    Case Else
        '        Icon = New Icon(My.Resources._icoMENU128x128, New Size(32, 32))
        'End Select

        ''���`����s
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

#Region "�{�^��FOCUS�F�ݒ�"
    'FUNCTION�{�^��
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

    '�{�^���̃p�l��
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

#Region "�ʒm�����N���x���N���b�N�C�x���g"
    '�ޗ��݌Ƀ��x��
    Private Sub LblZAIRYO_ZAIKO_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs)
        'Dim tplResult As (targetDate As Date?, intSIIRE_CD As Integer) = FunExistZairyoMinusYosokuZaiko()
        'With tplResult
        '    If .targetDate.HasValue = True Then
        '        Call FunOpenAppHacyuKeikaku(.targetDate, .intSIIRE_CD)
        '    End If
        'End With
    End Sub

    '���i�݌Ƀ��x��
    Private Sub LblSYUKKA_KEIKAKU_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles LinkLabel3.LinkClicked
        'Dim tplResult As (targetDate As Date?, intTOKUI_CD As Integer) = FunExistSeihinMinusYosokuZaiko()
        'With tplResult
        '    If .targetDate.HasValue = True Then
        '        Call FunOpenAppSyuKkaKeikaku(.targetDate, .intTOKUI_CD)
        '    End If
        'End With
    End Sub

    '���ߏ������x��
    Private Sub LblSIME_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles lblSIME.LinkClicked
        Call FunOpenAppSiharai()
    End Sub

    '�ғ����}�X�^���x��
    Private Sub LblCALENDER_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles lblCALENDER.LinkClicked
        Call FunOpenAppKADOMasta()
    End Sub
#End Region

#End Region

#Region "���[�J���֐�"

#Region "���O�C���p�l���\��"
    '���O�C���p�l���\��
    Private Function FunLOGIN(ByVal blnLOGIN As Boolean) As Boolean
        Try
            If blnLOGIN = False Then
                '���O�A�E�g
                Me.grbLOGIN.BringToFront()
                Me.grbLOGIN.Top = 60 '50
                Me.grbLOGIN.Left = 12 '5
                Me.grbLOGIN.Visible = True

                Me.grbLOGOUT.Visible = False
                Me.grbLOGOUT.Top = 50
                Me.grbLOGOUT.Left = 100

                '���O�C���Ј����N���A
                pub_SYAIN_INFO = New SYAIN_INFO

            Else
                '���O�C��
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

#Region "���j���[�ݒ�"
    '���j���[�ݒ�
    Private Sub Sub_MenuSet()
        Dim lngL As Long
        Dim strBUFF As String

        Try
            For lngL = 0 To 11
                '-----�����ݒ�
                strBUFF = arrNOW_CMDS(lngL).Title
                Me.cmdFunc(lngL).Text = strBUFF

                '-----�g�p�s��
                '�{�^���^�C�g���Ȃ�
                If arrNOW_CMDS(lngL).Title = "" Then
                    Me.cmdFunc(lngL).Enabled = False
                    Me.pnlFunc(lngL).Enabled = False

                    'PASS�Ȃ�
                ElseIf arrNOW_CMDS(lngL).Path = "" Then
                    Me.cmdFunc(lngL).Enabled = False
                    Me.pnlFunc(lngL).Enabled = False

                    '�ʏ�̃{�^��
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

#Region "�t�@���N�V�����Ɋ��蓖�Ă�ꂽ���s�t�@�C�����N������"
    '�t�@���N�V�����Ɋ��蓖�Ă�ꂽ���s�t�@�C�����N������
    Private Sub Sub_FuncExec(ByVal intIndex As Integer)
        Dim hProcess As New System.Diagnostics.Process
        Dim strEXE As String
        Dim strARG As String
        Dim strBUFF As String
        Dim intBUFF As Integer

        Try
            '-----EXE���Ƀu�����N�ʒu�擾
            intBUFF = arrNOW_CMDS(intIndex).Path.IndexOf(" ")


            'EXE���Ƀu�����N������
            If intBUFF = -1 Then
                '-----���s�t�@�C���p�X�擾
                strEXE = FunGetRootPath() & FunGetEXEPath() & arrNOW_CMDS(intIndex).Path

                '-----�����쐬
                '�S���R�[�h
                strARG = pub_SYAIN_INFO.SYAIN_ID & Space(1)
                '�S����
                'strARG = strARG & pub_SYAIN_INFO.SYAIN_NAME & Space(1)
                ''����(0:��������,1:�Q�ƌ���,2:�X�V����)
                'strARG = strARG & pub_USER_INFO.KENGEN_KB
                ''strARG = strARG & hsAUTHORITY(Me.lstGYOMU.SelectedItem.ToString.Trim)

            Else 'EXE���Ƀu�����N�L��
                strBUFF = arrNOW_CMDS(intIndex).Path.Substring(0, intBUFF)

                '-----���s�t�@�C���p�X�擾
                strEXE = FunGetRootPath() & FunGetEXEPath() & arrNOW_CMDS(intIndex).Path.Substring(0, intBUFF)


                '-----�����擾
                '�HANYO.INI��Ƃ�
                strARG = arrNOW_CMDS(intIndex).Path.Substring(intBUFF + 1)
            End If

            '-----�N��
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
                strMsg = "���L�v���O�����t�@�C����������܂���B" & vbCrLf & "�V�X�e���Ǘ��҂ɂ��A���������B" &
                            vbCrLf & vbCrLf & strEXE
                MessageBox.Show(strMsg, My.Application.Info.AssemblyName, MessageBoxButtons.OK, MessageBoxIcon.Information)
            End If

            '�v���Z�X�I����ҋ@���Ȃ�------------------------------------
            ''-----�q���A�C�h����ԂɂȂ�܂őҋ@
            'hProcess.WaitForInputIdle()

            ''-----������\��
            'Me.Hide()

            ''-----�q���I������܂őҋ@
            'hProcess.WaitForExit()
            '------------------------------------------------------------

        Catch ex As Exception
            EM.ErrorSyori(ex, False, conblnNonMsg)

        Finally
            '�v���Z�X�I����ҋ@���Ȃ�------------------------------------
            ''-----�����\��
            'Me.Show()
            'Me.lstGYOMU.Focus()
            'Me.Activate()
            'Me.BringToFront()
            '------------------------------------------------------------

            ''-----�J��
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

#Region "���蓖�Ă�ꂽ���ꏈ�����s��"
    '���蓖�Ă�ꂽ���ꏈ�����s��
    Private Sub Sub_SFunc(ByVal intIndex As Integer)
        Dim strFUNC As String
        Dim strBUFF As String

        Try
            '-----�������擾
            strFUNC = arrNOW_CMDS(intIndex).Path

            If InStr(1, UCase(strFUNC), "<END>") > 0 Then  '�I���{�^����

                '���̃A�v�����N������
                strBUFF = FunProcessCheck()

                If strBUFF <> "0" Then
                    'If MsgBox("���̃A�v�����܂��N�����ł����A���j���[����܂����H" & vbCrLf & strBUFF, MsgBoxStyle.Information + MsgBoxStyle.YesNo + MsgBoxStyle.DefaultButton2) = MsgBoxResult.No Then
                    If MsgBox("���̃A�v�����܂��N�����ł����A���j���[����܂����H", MsgBoxStyle.Information + MsgBoxStyle.YesNo + MsgBoxStyle.DefaultButton2) = MsgBoxResult.No Then
                        '������
                        Exit Sub
                    End If
                End If


                '-----�I��
                Me.Close()

            End If


        Catch ex As Exception
            EM.ErrorSyori(ex)
        End Try
    End Sub
#End Region

#Region "���̃A�v���N�����`�F�b�N"
    '���̃A�v���N�����`�F�b�N
    Private Function Fun_ProcessCheck() As String
        Dim strBUFF As String
        'Dim intRET As Integer

        Try
            'ROOTPATH�擾
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
            'ROOTPATH�擾
#If DEBUG Then
            strBUFF = FunGetRootPath() & "\EXE_DEBUG\"
#Else
            strBUFF = FunGetRootPath() & "\EXE\"
#End If


            '���[�J���R���s���[�^��Ŏ��s����Ă��邷�ׂẴv���Z�X���擾
            ps = System.Diagnostics.Process.GetProcesses

            'Dim strMyApp As String = My.Application.Info.AssemblyName
            'Dim p As List(Of Process) = ps.AsEnumerable().Where(Function(r) r.ProcessName.Contains(strMyApp) = False And r.MainModule.FileName.Contains(strBUFF)).ToList
            'If p.Count > 0 Then
            '    Return p(0).MainModule.FileName
            'End If

            Dim p As System.Diagnostics.Process
            For Each p In ps.AsQueryable().Where(Function(process) process.MainModule.FileName.Contains(strBUFF))


                '���C�����W���[�����A���A�v����
                If p.ProcessName.Contains(My.Application.Info.AssemblyName) = True Then
                    '����
                    Continue For
                Else
                    ''���������W���[���̓X�L�b�v
                    'If p.ProcessName.Contains("MBCT010TIMEREC") = True Then
                    '    '����
                    '    Continue For
                    'End If
                    '������
                    Return p.MainModule.FileName
                End If
            Next p

            Return 0
        Catch exWin32 As System.ComponentModel.Win32Exception
            '�v���Z�X�A�N�Z�X���� 64bit�v���Z�X����32bit�v���Z�X�ɃA�N�Z�X(�܂��͂��̋t)��
            Return 0
        Catch ex As Exception
            EM.ErrorSyori(ex, False, conblnNonMsg)
            Return -1
        End Try
    End Function
#End Region

#Region "���ߏ����`�F�b�N"
    Private Sub SubCheckSime(ByVal DB As ClsDbUtility)
        'Dim strYM As String
        Try
            ''-----���ߏ����󋵎擾
            'strYM = FunGetCodeMastaValue(DB, "������", "��������")

            ''�O���̒������������{�̏ꍇ�A�ʒm
            'If strYM < Today.AddMonths(-1).ToString("yyyyMM") Then
            '    Me.lblSIME.Text = "�O���̒��ߏ��������{����Ă��܂���B" & vbCrLf & "(" & DateTime.ParseExact(strYM, "yyyyMM", Nothing).ToString("yyyy�NMM���x") & "�܂Œ��ߏ�����)"
            '    Me.lblSIME.Cursor = Cursors.Hand
            'Else
            Me.lblSIME.Text = ""
            Me.lblSIME.Cursor = Cursors.Default
            'End If

        Catch ex As Exception
            EM.ErrorSyori(ex, False, conblnNonMsg)
        End Try

    End Sub

#Region "�x��������ʕ\��"

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

#Region "�ғ����}�X�^�`�F�b�N"
    Private Sub SubCheckKADOMasta(ByVal DB As ClsDbUtility)
        Dim sbSQL As New System.Text.StringBuilder

        Try
            '-----�J�����_�[�o�^�󋵎擾
            sbSQL.Remove(0, sbSQL.Length)
            sbSQL.Append("SELECT")
            sbSQL.Append(" MAX(SUBSTRING(YMD,1,4)+'/'+SUBSTRING(YMD,5,2)+'/'+SUBSTRING(YMD,7,2)) MAX_YMD ")
            sbSQL.Append(" FROM " & NameOf(MODEL.M006_CALENDAR) & " ")

            Using dsList As DataSet = DB.GetDataSet(sbSQL.ToString)
                '�\��
                Me.lblCALENDER.Text = ""
                Me.lblCALENDER.Cursor = Cursors.Default
                With dsList.Tables(0)
                    If .Rows(0).Item("MAX_YMD").ToString.TrimEnd = "" Then
                        Me.lblCALENDER.Text = "�ғ����}�X�^��o�^���ĉ������B"
                        Me.lblCALENDER.Cursor = Cursors.Hand
                    Else
                        '�ő�o�^�����V�X�e�����{�R���ȓ���
                        If System.DateTime.Now.AddMonths(3).ToString("yyyy/MM/dd") > .Rows(0).Item("MAX_YMD").ToString.TrimEnd Then
                            Me.lblCALENDER.Text = "�߂��ғ����}�X�^��o�^���ĉ������B" & vbCrLf & "(" & .Rows(0).Item("MAX_YMD").ToString.TrimEnd & "�܂œo�^��)"
                            Me.lblCALENDER.Cursor = Cursors.Hand
                        End If
                    End If
                End With
            End Using


        Catch ex As Exception
            EM.ErrorSyori(ex, False, conblnNonMsg)
        End Try
    End Sub

#Region "�ғ����}�X�^��ʕ\��"

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
