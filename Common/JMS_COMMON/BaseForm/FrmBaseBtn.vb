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




#Region "定数・変数"
    Public cmdFunc() As System.Windows.Forms.Button 'ボタン配列

#End Region

#Region "FORMイベント"
    Private Sub FrmBaseBtn_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

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
    End Sub

    Private Sub FrmBaseBtn_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        Dim KeyCode As Short = e.KeyCode


        '押下されたキーコード取得
        KeyCode = e.KeyCode

        'F1～F12
        If KeyCode >= Windows.Forms.Keys.F1 And KeyCode <= Windows.Forms.Keys.F12 Then
            'F10時に異常動作するのでゴミ消し
            e.Handled = True
            '該当ボタンCLICKイベント生成
            cmdFunc(KeyCode - 112).PerformClick()
        End If

        'ENTERキー
        If KeyCode = Windows.Forms.Keys.Return Then
            System.Windows.Forms.SendKeys.Send("{TAB}")
        End If

    End Sub

    Public Overridable Sub FrmBaseBtn_Resize(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Resize
        If Me.Visible = False Then Exit Sub

        If Me.DesignMode = True Then Exit Sub

        If Me.FormBorderStyle = Windows.Forms.FormBorderStyle.FixedDialog Then Exit Sub

        ''===================================
        ''   ボタン位置、サイズ設定
        ''===================================
        Call SetButtonSize(Me.Width, cmdFunc)
    End Sub

    Protected Function FunFormCommonSetting(ByVal objPG_INFO As Object, ByVal objUSER_INFO As Object) As Boolean
        Try
            'Dim _PG_INFO As PG_INFO = TryCast(objPG_INFO, PG_INFO)
            'Dim _USER_INFO As PG_INFO = TryCast(objUSER_INFO, PG_INFO)

            '-----フォーム共通設定
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