Imports JMS_COMMON.ClsPubMethod

Public Class FrmM0031

#Region "�ϐ��E�萔"
    Private IsValidated As Boolean

    Private _M003 As MODEL.M003_GYOMU_GROUP
#End Region

#Region "�v���p�e�B"
    ''' <summary>
    ''' �������[�h
    ''' </summary>
    Public Property PrMODE As Integer

    ''' <summary>
    ''' �V�K�ǉ����R�[�h�̃L�[
    ''' </summary>
    Public Property PrPKeys As (ITEM_NAME As String, ITEM_VALUE As String)

    Public Property PrDataRow As C1.Win.C1FlexGrid.Row
    'Public Property PrDataRow As DataRow

#End Region

#Region "�R���X�g���N�^"
    Public Sub New()

        ' ���̌Ăяo���̓f�U�C�i�[�ŕK�v�ł��B
        InitializeComponent()


    End Sub
#End Region

#Region "FORM�C�x���g"
    Private Sub Frm_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        Try
            '-----�t�H�[�����ʐݒ�
            Call FunFormCommonSetting(pub_APP_INFO, pub_SYAIN_INFO)

            '-----�ʒu�E�T�C�Y
            Me.Height = 250
            Me.MinimumSize = New Size(1280, 250)
            Me.Top = Me.Owner.Top + (Me.Owner.Height - Me.Height) - 30 ' / 2
            Me.Left = Me.Owner.Left + (Me.Owner.Width - Me.Width) / 2


            '-----�e�R���g���[���̃f�[�^�\�[�X��ݒ�
            'Me.cmbBUSYO_KB.SetDataSource(tblBUSYO_KB.ExcludeDeleted, ENM_COMBO_SELECT_VALUE_TYPE._0_Required)
            'Me.cmbBUMON_KB.SetDataSource(tblBUMON.ExcludeDeleted, ENM_COMBO_SELECT_VALUE_TYPE._0_Required)
            'Me.cmbOYA_BUSYO_KB.SetDataSource(tblBUSYO_KB.ExcludeDeleted, ENM_COMBO_SELECT_VALUE_TYPE._2_Option)
            'Me.cmbSYOZOKUCYO.SetDataSource(tblSYAIN.ExcludeDeleted, ENM_COMBO_SELECT_VALUE_TYPE._2_Option)

            '�C�x���g�n���h���ݒ�
            'AddHandler cmbOYA_BUSYO_KB.TextChanged, AddressOf CmbOYA_BUSYO_KB_TextChanged
            'AddHandler chkYUKO_YMD.CheckedChanged, AddressOf chkYUKO_YMD_CheckedChanged

            '-----�������[�h�ʉ�ʏ�����
            Call FunInitializeControls(PrMODE)

            '-----�_�C�A���O�E�B���h�E�ݒ�
            Me.FormBorderStyle = Windows.Forms.FormBorderStyle.FixedDialog
            Me.ControlBox = False

        Catch ex As Exception
            EM.ErrorSyori(ex, False, conblnNonMsg)
        Finally
            Call FunInitFuncButtonEnabled()
        End Try
    End Sub

#End Region

#Region "FUNCTION�{�^���֘A"

#Region "FUNCTION�{�^��CLICK�C�x���g"

    Private Sub CmdFunc_Click(ByVal sender As Object, ByVal e As EventArgs) Handles cmdFunc9.Click, cmdFunc8.Click, cmdFunc7.Click, cmdFunc6.Click, cmdFunc5.Click, cmdFunc4.Click, cmdFunc3.Click, cmdFunc2.Click, cmdFunc12.Click, cmdFunc11.Click, cmdFunc10.Click, cmdFunc1.Click
        Dim intFUNC As Integer
        Dim intCNT As Integer

        Try
            '�{�^���s��/�{�^��INDEX�擾
            For intCNT = 0 To Me.cmdFunc.Length - 1
                Me.cmdFunc(intCNT).Enabled = False
                If cmdFunc(intCNT) Is sender Then intFUNC = intCNT + 1
            Next

            '�{�^��INDEX���̏���
            Select Case intFUNC
                Case 1  '�ǉ��ύX
                    If FunSAVE() Then
                        '�v���p�e�B�ɑΏۃ��R�[�h�̃L�[��ݒ�
                        'Me.PrPKeys = (cmbKOMO_NM.Text.Trim, mtxVALUE.Text.Trim)

                        Me.DialogResult = Windows.Forms.DialogResult.OK
                        Me.Close()
                    End If

                Case 12 '�߂�
                    Me.DialogResult = Windows.Forms.DialogResult.Cancel
                    Me.Close()
            End Select
        Catch ex As Exception
            EM.ErrorSyori(ex)
        Finally
            '�{�^����
            System.Windows.Forms.Application.DoEvents()
            For intCNT = 0 To Me.cmdFunc.Length - 1
                Me.cmdFunc(intCNT).Enabled = True
            Next

            Call FunInitFuncButtonEnabled()
        End Try
    End Sub

#End Region

#Region "�X�V"

    Private Function FunSAVE() As Boolean
        Dim sbSQL As New System.Text.StringBuilder
        Dim strRET As String
        Dim sqlEx As New Exception
        Dim strSysDate As String
        Try

            '���̓`�F�b�N
            If FunCheckInput() = False Then Return False

            Using DB As ClsDbUtility = DBOpen()
                Dim blnErr As Boolean
                Try
                    DB.BeginTransaction()

                    strSysDate = DB.GetSysDateString()

                    '-----MERGE
                    sbSQL.Remove(0, sbSQL.Length)
                    sbSQL.Append($"MERGE INTO {NameOf(MODEL.M003_GYOMU_GROUP)} AS TARGET")
                    sbSQL.Append($" USING (SELECT")
                    sbSQL.Append($"  {_M003.GYOMU_GROUP_ID} AS {NameOf(_M003.GYOMU_GROUP_ID)}")
                    sbSQL.Append($",'{_M003.GYOMU_GROUP_NAME}' AS {NameOf(_M003.GYOMU_GROUP_NAME)}")
                    sbSQL.Append($",'{_M003.ADD_YMDHNS}' AS {NameOf(_M003.ADD_YMDHNS)}")
                    sbSQL.Append($",{_M003.ADD_SYAIN_ID} AS {NameOf(_M003.ADD_SYAIN_ID)}")
                    sbSQL.Append($",'{_M003.UPD_YMDHNS}' AS {NameOf(_M003.UPD_YMDHNS)}")
                    sbSQL.Append($",{_M003.UPD_SYAIN_ID} AS {NameOf(_M003.UPD_SYAIN_ID)}")
                    sbSQL.Append($",'{_M003.DEL_YMDHNS}' AS {NameOf(_M003.DEL_YMDHNS)}")
                    sbSQL.Append($",{_M003.DEL_SYAIN_ID} AS {NameOf(_M003.DEL_SYAIN_ID)}")

                    sbSQL.Append($" ) AS WK ON (")
                    sbSQL.Append($" TARGET.{NameOf(_M003.GYOMU_GROUP_ID)} = WK.{NameOf(_M003.GYOMU_GROUP_ID)}")
                    sbSQL.Append($" )")

                    '---UPDATE �r������ �X�V�������ύX����Ă��Ȃ��ꍇ�̂�
                    sbSQL.Append($" WHEN MATCHED AND TARGET.{NameOf(_M003.UPD_YMDHNS)} = WK.{NameOf(_M003.UPD_YMDHNS)} THEN ")
                    sbSQL.Append($" UPDATE SET")
                    sbSQL.Append($" TARGET.{NameOf(_M003.GYOMU_GROUP_NAME)} = WK.{NameOf(_M003.GYOMU_GROUP_NAME)}")
                    sbSQL.Append($",TARGET.{NameOf(_M003.UPD_YMDHNS)} = '{strSysDate}'")
                    sbSQL.Append($",TARGET.{NameOf(_M003.UPD_SYAIN_ID)} = WK.{NameOf(_M003.UPD_SYAIN_ID)}")


                    '---INSERT
                    sbSQL.Append($" WHEN NOT MATCHED THEN ")
                    sbSQL.Append($" INSERT(")
                    _M003.Properties.Take(1).ForEach(Sub(p) sbSQL.Append($" {p.Name}"))
                    _M003.Properties.Skip(1).ForEach(Sub(p) sbSQL.Append($",{p.Name}"))
                    sbSQL.Append($" ) VALUES(")
                    _M003.Properties.Take(1).ForEach(Sub(p) sbSQL.Append($" WK.{p.Name}"))
                    _M003.Properties.Skip(1).ForEach(Sub(p) sbSQL.Append($",WK.{p.Name}"))
                    sbSQL.Append(" )")
                    sbSQL.Append("OUTPUT $action As RESULT;")

                    strRET = DB.ExecuteScalar(sbSQL.ToString, conblnNonMsg, sqlEx)
                    Select Case strRET
                        Case "INSERT"

                        Case "UPDATE"

                            Select Case PrMODE
                                Case ENM_DATA_OPERATION_MODE._1_ADD, ENM_DATA_OPERATION_MODE._2_ADDREF
                                    '�V�K�ǉ��E�ގ��ǉ���UPDATE�͖���
                                    Dim strMsg As String = $"({_M003.GYOMU_GROUP_NAME})�͊��ɓo�^����Ă��܂��B"

                                    'If MessageBox.Show(strMsg, "�d���`�F�b�N", MessageBoxButtons.YesNo, MessageBoxIcon.Information) = DialogResult.Yes Then
                                    'Else
                                    '    blnErr = True
                                    '    Return False
                                    'End If
                            End Select
                        Case Else
                            If sqlEx.Source IsNot Nothing Then
                                '-----�G���[���O�o��
                                Dim strErrMsg As String = $"{My.Resources.ErrLogSqlExecutionFailure}{sbSQL.ToString}|{sqlEx.Message}"
                                WL.WriteLogDat(strErrMsg)
                            Else
                                '---�r������
                                Dim strMsg As String = $"���ɑ��̒S���҂ɂ���ĕύX����Ă��邽�ߕۑ��o���܂���B{vbCrLf}�ēx�o�^�������ĉ������B"
                                MessageBox.Show(strMsg, "�����X�V����", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                            End If
                            blnErr = True
                            Return False
                    End Select
                Finally
                    DB.Commit(Not blnErr)
                End Try
            End Using

            Return True
        Catch ex As Exception
            EM.ErrorSyori(ex, False, conblnNonMsg)
            Return False
        Finally
        End Try
    End Function

#End Region

#Region "FuncButton�L�������ؑ�"

    ''' <summary>
    ''' �g�p���Ȃ��{�^���̃L���v�V�������Ȃ����A���񊈐��ɂ���B
    ''' �t�@���N�V�����L�[������(F**)�ȊO�̕������Ȃ��ꍇ�́A���g�p�Ƃ݂Ȃ�
    ''' </summary>
    ''' <param name="frm">�Ώۃt�H�[��</param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Private Function FunInitFuncButtonEnabled() As Boolean
        Try

            For intFunc As Integer = 1 To 12
                Dim cmd As Button = DirectCast(Me.Controls.Find("cmdFunc" & intFunc, True)(0), Button)
                With cmd
                    If cmd IsNot Nothing AndAlso .Text.Length = 0 OrElse .Text.Substring(0, .Text.IndexOf("(")).IsNullOrWhiteSpace Then
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

#Region "�R���g���[���C�x���g"


#End Region

#Region "���̓`�F�b�N"
    Public Function FunCheckInput() As Boolean
        Try
            IsValidated = True

            Call mtxBUSYO_NAME_Validating(mtxBUSYO_NAME, Nothing)

            Return IsValidated
        Catch ex As Exception
            EM.ErrorSyori(ex, False, conblnNonMsg)
            Return False
        End Try

    End Function

    Private Sub cmbBUMON_KB_Validating(sender As Object, e As System.ComponentModel.CancelEventArgs)
        Dim cmb As ComboboxEx = DirectCast(sender, ComboboxEx)
        IsValidated *= ErrorProvider.UpdateErrorInfo(cmb, cmb.IsSelected, String.Format(My.Resources.infoMsgRequireSelectOrInput, "����敪"))
    End Sub

    Private Sub cmbBUSYO_KB_Validating(sender As Object, e As System.ComponentModel.CancelEventArgs)
        Dim cmb As ComboboxEx = DirectCast(sender, ComboboxEx)
        IsValidated *= ErrorProvider.UpdateErrorInfo(cmb, cmb.IsSelected, String.Format(My.Resources.infoMsgRequireSelectOrInput, "�����敪"))
    End Sub

    Private Sub datYUKO_YMD_Validating(sender As Object, e As System.ComponentModel.CancelEventArgs)
        Dim dtx As DateTextBoxEx = DirectCast(sender, DateTextBoxEx)
        IsValidated *= ErrorProvider.UpdateErrorInfo(dtx, Not dtx.ValueNonFormat.IsNullOrWhiteSpace, String.Format(My.Resources.infoMsgRequireSelectOrInput, "�L������"))
    End Sub

    Private Sub mtxBUSYO_NAME_Validating(sender As Object, e As System.ComponentModel.CancelEventArgs) Handles mtxBUSYO_NAME.Validating
        Dim mtx As MaskedTextBoxEx = DirectCast(sender, MaskedTextBoxEx)
        IsValidated *= ErrorProvider.UpdateErrorInfo(mtx, Not mtx.Text.IsNullOrWhiteSpace, String.Format(My.Resources.infoMsgRequireSelectOrInput, "������"))
    End Sub


#End Region

#Region "���[�J���֐�"

#Region "�������[�h�ʉ�ʏ�����"
    Private Function FunInitializeControls(ByVal intMODE As Integer) As Boolean
        Try

            Select Case intMODE
                Case ENM_DATA_OPERATION_MODE._1_ADD
                    Me.Text = pub_APP_INFO.strTitle & "�i�ǉ��j"
                    Me.lblTytle.Text = Me.Text
                    Me.cmdFunc1.Text = "�ǉ�(F1)"

                    Me.lbllblEDIT_YMDHNS.Visible = False
                    Me.lblEDIT_YMDHNS.Visible = False
                    Me.lbllblEDIT_SYAIN_ID.Visible = False
                    Me.lblEDIT_SYAIN_ID.Visible = False

                Case ENM_DATA_OPERATION_MODE._2_ADDREF
                    Call FunSetEntityValues(PrDataRow)

                    Me.Text = pub_APP_INFO.strTitle & "�i�ގ��ǉ��j"
                    Me.lblTytle.Text = Me.Text
                    Me.cmdFunc1.Text = "�ǉ�(F1)"

                    Me.lbllblEDIT_YMDHNS.Visible = False
                    Me.lblEDIT_YMDHNS.Visible = False
                    Me.lbllblEDIT_SYAIN_ID.Visible = False
                    Me.lblEDIT_SYAIN_ID.Visible = False

                Case ENM_DATA_OPERATION_MODE._3_UPDATE
                    Call FunSetEntityValues(PrDataRow)

                    Me.Text = pub_APP_INFO.strTitle & "�i�ύX�j"
                    Me.lblTytle.Text = Me.Text
                    Me.cmdFunc1.Text = "�ύX(F1)"



                    Me.lbllblEDIT_YMDHNS.Visible = True
                    Me.lblEDIT_YMDHNS.Visible = True
                    Me.lbllblEDIT_SYAIN_ID.Visible = True
                    Me.lblEDIT_SYAIN_ID.Visible = True

                Case Else
                    Throw New ArgumentException(My.Resources.ErrMsgException, intMODE.ToString)
            End Select

            Return True

        Catch ex As Exception
            EM.ErrorSyori(ex, False, conblnNonMsg)
            Return False
        End Try
    End Function

    ''' <summary>
    ''' �ꗗ�I���s�̒l���Z�b�g
    ''' </summary>
    ''' <param name="row"></param>
    ''' <returns></returns>
    Private Function FunSetEntityValues(row As C1.Win.C1FlexGrid.Row) As Boolean
        Dim _model As New MODEL.VWM002_BUSYO
        Try

            '-----�R���g���[���ɒl���Z�b�g
            With row

                'Me.cmbSYOZOKUCYO.SelectedValue = .Item(NameOf(_model.SYOZOKUCYO_ID))

                '�X�V����
                Dim dt As DateTime
                dt = DateTime.ParseExact(.Item(NameOf(_model.UPD_YMDHNS)).ToString, "yyyy/MM/dd HH:mm:ss", Nothing)
                Me.lblEDIT_YMDHNS.Text = dt.ToString("yyyy/MM/dd HH:mm:ss")

                '�X�V�S��
                Me.lblEDIT_SYAIN_ID.Text = .Item(NameOf(_model.UPD_SYAIN_NAME)).ToString

            End With

            Return True
        Catch ex As Exception
            EM.ErrorSyori(ex, False, conblnNonMsg)
            Return False
        End Try
    End Function

#End Region



#End Region



End Class
