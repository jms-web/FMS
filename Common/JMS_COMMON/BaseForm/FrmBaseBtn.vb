Imports JMS_COMMON.ClsPubMethod

Public Class FrmBaseBtn

    'Public Enum ENM_WindowPosition
    '    _0_Center = 0
    '    _1_Bottom = 1
    '    _2_Top = 2
    '    _3_Left = 3
    '    _4_Right = 4
    'End Enum

    'Public Property WindowPosition As ENM_WindowPosition




#Region "�萔�E�ϐ�"
    Public cmdFunc() As System.Windows.Forms.Button '�{�^���z��

#End Region

#Region "FORM�C�x���g"
    Private Sub FrmBaseBtn_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

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
    End Sub

    Private Sub FrmBaseBtn_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        Dim KeyCode As Short = e.KeyCode


        '�������ꂽ�L�[�R�[�h�擾
        KeyCode = e.KeyCode

        'F1�`F12
        If KeyCode >= Windows.Forms.Keys.F1 And KeyCode <= Windows.Forms.Keys.F12 Then
            'F10���Ɉُ퓮�삷��̂ŃS�~����
            e.Handled = True
            '�Y���{�^��CLICK�C�x���g����
            cmdFunc(KeyCode - 112).PerformClick()
        End If

        'ENTER�L�[
        If KeyCode = Windows.Forms.Keys.Return Then
            System.Windows.Forms.SendKeys.Send("{TAB}")
        End If

    End Sub

    Public Overridable Sub FrmBaseBtn_Resize(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Resize
        If Me.Visible = False Then Exit Sub

        If Me.DesignMode = True Then Exit Sub

        If Me.FormBorderStyle = Windows.Forms.FormBorderStyle.FixedDialog Then Exit Sub

        ''===================================
        ''   �{�^���ʒu�A�T�C�Y�ݒ�
        ''===================================
        Call SetButtonSize(Me.Width, cmdFunc)
    End Sub

    Protected Function FunFormCommonSetting(ByVal objPG_INFO As Object, ByVal objUSER_INFO As Object) As Boolean
        Try
            'Dim _PG_INFO As PG_INFO = TryCast(objPG_INFO, PG_INFO)
            'Dim _USER_INFO As PG_INFO = TryCast(objUSER_INFO, PG_INFO)

            '-----�t�H�[�����ʐݒ�
            Me.lblTytle.Text = objPG_INFO.strTitle
            'Me.DataBindings.Clear()
            'Me.DataBindings.Add(New Binding(NameOf(Me.Text), lblTytle, NameOf(lblTytle.Text), False, DataSourceUpdateMode.OnPropertyChanged, ""))

            'If Owner IsNot Nothing And Me.FormBorderStyle = FormBorderStyle.FixedDialog Then
            '    'Me.Height = Owner.Height - 26
            '    Me.Top = Owner.Top + (Owner.Height - Me.Height) / 2
            '    Me.Left = Owner.Left + (Owner.Width - Me.Width) / 2
            'End If

            Me.BackColor = objPG_INFO.clrFORM_BACK
            Me.lblTytle.BackColor = objPG_INFO.clrTITLE_LABEL

        Catch ex As Exception
            EM.ErrorSyori(ex, False, conblnNonMsg)
        End Try
    End Function

#End Region


End Class