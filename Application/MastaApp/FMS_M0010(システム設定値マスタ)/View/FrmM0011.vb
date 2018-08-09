Imports JMS_COMMON.ClsPubMethod

''' <summary>
''' �R�[�h�}�X�^�ҏW���
''' </summary>
Public Class FrmM0011

#Region "�ϐ��E�萔"
    Private IsValidated As Boolean
    Private _M001 As New MODEL.M001_SETTING
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

    Public Property PrDataRow As DataRow

#End Region

#Region "�R���X�g���N�^"

    ''' <summary>
    ''' �R���X�g���N�^
    ''' </summary>
    ''' <remarks>�R���X�g���N�^</remarks>
    Public Sub New()

        ' ���̌Ăяo���̓f�U�C�i�[�ŕK�v�ł��B
        InitializeComponent()

        cmbJYUN.NullValue = 0
    End Sub

#End Region

#Region "FORM�C�x���g"
    Private Sub Frm_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        Try
            '-----�t�H�[�����ʐݒ�
            Call FunFormCommonSetting(pub_APP_INFO, pub_SYAIN_INFO)
            Using DB As ClsDbUtility = DBOpen()
                lblTytle.Text = FunGetCodeMastaValue(DB, "PG_TITLE", Me.GetType.ToString)
            End Using

            '-----�ʒu�E�T�C�Y
            Me.Height = 380
            Me.Top = Me.Owner.Top + (Me.Owner.Height - Me.Height) - 26 ' / 2
            Me.Left = Me.Owner.Left + (Me.Owner.Width - Me.Width) / 2
            Me.FormBorderStyle = Windows.Forms.FormBorderStyle.FixedDialog
            Me.MaximizeBox = False
            Me.MinimizeBox = False

            '-----�f�[�^�\�[�X��ݒ�
            cmbKOMO_NM.SetDataSource(tblKOMO_NM.ExcludeDeleted, ENM_COMBO_SELECT_VALUE_TYPE._0_Required)

            Call FunSetBinding()

            '-----�������[�h�ʉ�ʏ�����
            Call FunInitializeControls()

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
                        Me.PrPKeys = (Me.cmbKOMO_NM.Text.Trim, Me.mtxVALUE.Text.Trim)

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

                    Dim ModelInfo As New MODEL.ModelInfo(Of MODEL.M001_SETTING)(_OnlyAutoGenerateField:=True)

                    '-----���ꍀ�ږ��̊���l������
                    If _M001.DEF_FLG Then
                        sbSQL.Append($"UPDATE {ModelInfo.Name} SET")
                        sbSQL.Append($" DEF_FLG='0' ")
                        sbSQL.Append($" WHERE KOMO_NM ='{_M001.ITEM_NAME}' ")
                        sbSQL.Append($" AND VALUE <>'{_M001.ITEM_VALUE}' ")

                        DB.ExecuteNonQuery(sbSQL.ToString, conblnNonMsg, sqlEx)
                        If sqlEx IsNot Nothing Then
                            '�G���[���O
                            Dim strErrMsg As String = My.Resources.ErrLogSqlExecutionFailure & sbSQL.ToString & "|" & sqlEx.Message
                            WL.WriteLogDat(strErrMsg)
                            blnErr = True
                            Return False
                        End If
                    End If

                    '-----UPDATE(�\����)
                    If PrDataRow.Item("DISP_ORDER") <> _M001.DISP_ORDER Then
                        If FunUpdateDispOrder(DB, PrDataRow.Item("DISP_ORDER"), _M001.DISP_ORDER) = False Then
                            blnErr = True
                            Return False
                        End If
                    End If

                    '-----MERGE
                    sbSQL.Remove(0, sbSQL.Length)
                    sbSQL.Append($"MERGE INTO {ModelInfo.Name} AS TARGET")
                    sbSQL.Append($" USING (SELECT")

                    'Merge Source����Select������ �擪���ڂƈȍ~�ŕ����Ă���(�Ⴂ�̓J���}�̂�)
                    ModelInfo.Properties.Take(1).ForEach(Sub(p)
                                                             Select Case p.PropertyType
                                                                 Case GetType(Boolean)
                                                                     sbSQL.Append($" '{_M001("_" & p.Name)}' AS {p.Name}")
                                                                 Case GetType(Integer), GetType(Decimal)
                                                                     sbSQL.Append($" {_M001(p.Name)} AS {p.Name}")
                                                                 Case Else
                                                                     '����String�̂�
                                                                     sbSQL.Append($" '{_M001(p.Name).ToString.ConvertSqlEscape}' AS {p.Name}")
                                                             End Select
                                                         End Sub)
                    ModelInfo.Properties.Skip(1).ForEach(Sub(p)
                                                             Select Case p.PropertyType
                                                                 Case GetType(Boolean)
                                                                     sbSQL.Append($" ,'{_M001("_" & p.Name)}' AS {p.Name}")
                                                                 Case GetType(Integer), GetType(Decimal)
                                                                     sbSQL.Append($",{_M001(p.Name)} AS {p.Name}")
                                                                 Case Else
                                                                     '����String�̂�
                                                                     sbSQL.Append($",'{_M001(p.Name).ToString.ConvertSqlEscape}' AS {p.Name}")
                                                             End Select
                                                         End Sub)
                    sbSQL.Append($" ) AS WK ON (")
                    sbSQL.Append($" TARGET.{NameOf(_M001.ITEM_NAME)} = WK.{NameOf(_M001.ITEM_NAME)}")
                    sbSQL.Append($" AND TARGET.{NameOf(_M001.ITEM_VALUE)} = WK.{NameOf(_M001.ITEM_VALUE)}")
                    sbSQL.Append($" )")

                    '---UPDATE �r������ �X�V�������ύX����Ă��Ȃ��ꍇ�̂�
                    sbSQL.Append($" WHEN MATCHED AND TARGET.{NameOf(_M001.UPD_YMDHNS)} = WK.{NameOf(_M001.UPD_YMDHNS)} THEN ")
                    sbSQL.Append($" UPDATE SET")
                    sbSQL.Append($" TARGET.{NameOf(_M001.ITEM_DISP)} = WK.{NameOf(_M001.ITEM_DISP)}")
                    sbSQL.Append($",TARGET.{NameOf(_M001.ITEM_GROUP)} = WK.{NameOf(_M001.ITEM_GROUP)}")
                    sbSQL.Append($",TARGET.{NameOf(_M001.DEF_FLG)} = WK.{NameOf(_M001.DEF_FLG)}")
                    sbSQL.Append($",TARGET.{NameOf(_M001.BIKOU)} = WK.{NameOf(_M001.BIKOU)}")
                    sbSQL.Append($",TARGET.{NameOf(_M001.UPD_YMDHNS)} = '{strSysDate}'")
                    sbSQL.Append($",TARGET.{NameOf(_M001.UPD_SYAIN_ID)} = WK.{NameOf(_M001.UPD_SYAIN_ID)}")

                    '---INSERT
                    sbSQL.Append($" WHEN NOT MATCHED THEN ")
                    sbSQL.Append($" INSERT(")
                    ModelInfo.Properties.Take(1).ForEach(Sub(p) sbSQL.Append($" {p.Name}"))
                    ModelInfo.Properties.Skip(1).ForEach(Sub(p) sbSQL.Append($",{p.Name}"))
                    sbSQL.Append($" ) VALUES(")
                    ModelInfo.Properties.Take(1).ForEach(Sub(p) sbSQL.Append($" WK.{p.Name}"))
                    ModelInfo.Properties.Skip(1).ForEach(Sub(p) sbSQL.Append($",WK.{p.Name}"))
                    sbSQL.Append(" )")
                    sbSQL.Append("OUTPUT $action As RESULT;")

                    strRET = DB.ExecuteScalar(sbSQL.ToString, conblnNonMsg, sqlEx)
                    Select Case strRET
                        Case "INSERT"

                        Case "UPDATE"

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
    ''' <returns></returns>
    ''' <remarks></remarks>
    Private Function FunInitFuncButtonEnabled() As Boolean
        Try

            For intCNT = 0 To Me.cmdFunc.Length - 1
                If Me.cmdFunc(intCNT) IsNot Nothing AndAlso Me.cmdFunc(intCNT).Text.Length = 0 OrElse Me.cmdFunc(intCNT).Text.Substring(0, Me.cmdFunc(intCNT).Text.IndexOf("(")).IsNullOrWhiteSpace = True Then
                    Me.cmdFunc(intCNT).Text = ""
                    Me.cmdFunc(intCNT).Visible = False
                End If
            Next

            Return True
        Catch ex As Exception
            EM.ErrorSyori(ex, False, conblnNonMsg)
            Return False
        End Try
    End Function

#End Region

#End Region

#Region "�R���g���[���C�x���g"


    Private Sub cmbKOMO_NM_Validated(sender As Object, e As EventArgs) Handles cmbKOMO_NM.Validated
        Dim dsList As New DataSet
        Dim sbSQL As New System.Text.StringBuilder
        Dim intMaxOrder As Integer

        Try

            If Not cmbKOMO_NM.Text.IsNullOrWhiteSpace Then

                'Me.cmbJYUN.DataSource = Nothing

                Using DB As ClsDbUtility = DBOpen()
                    sbSQL.Append("SELECT ITEM_VALUE")
                    sbSQL.Append(" FROM " & NameOf(MODEL.M001_SETTING) & "")
                    sbSQL.Append(" WHERE ITEM_NAME ='" & cmbKOMO_NM.Text & "'")
                    dsList = DB.GetDataSet(sbSQL.ToString, conblnNonMsg)
                End Using

                intMaxOrder = dsList.Tables(0).Rows.Count

                Dim intModeDiff As Integer
                Select Case PrMODE
                    Case ENM_DATA_OPERATION_MODE._1_ADD, ENM_DATA_OPERATION_MODE._2_ADDREF
                        intModeDiff = 1
                    Case ENM_DATA_OPERATION_MODE._3_UPDATE
                        intModeDiff = 0
                    Case Else
                        Throw New ArgumentException(My.Resources.ErrMsgException, PrMODE.ToString)
                End Select

                Dim dt As New DataTableEx
                For i As Integer = 1 To intMaxOrder + intModeDiff
                    Dim Trow As DataRow = dt.NewRow()
                    Trow("DISP") = i
                    Trow("VALUE") = i
                    Trow("DEL_FLG") = False
                    dt.Rows.Add(Trow)
                Next i
                dt.AcceptChanges()

                Call cmbJYUN.SetDataSource(dt, False)

                Select Case PrMODE
                    Case ENM_DATA_OPERATION_MODE._1_ADD, ENM_DATA_OPERATION_MODE._2_ADDREF
                        cmbJYUN.SelectedValue = intMaxOrder + intModeDiff
                    Case ENM_DATA_OPERATION_MODE._3_UPDATE
                        cmbJYUN.SelectedValue = PrDataRow.Item("DISP_ORDER")
                    Case Else
                        Throw New ArgumentException(My.Resources.ErrMsgException, PrMODE.ToString)
                End Select
            End If

        Catch ex As Exception
            EM.ErrorSyori(ex, False, conblnNonMsg)
        Finally
            dsList.Dispose()
        End Try
    End Sub

#End Region

#Region "���̓`�F�b�N"

    Private Function FunCheckInput() As Boolean
        Try
            '�t���O������
            IsValidated = True

            Call CmbKOMO_NM_Validating(cmbKOMO_NM, Nothing)
            Call MtxVALUE_Validating(mtxVALUE, Nothing)

            Return IsValidated
        Catch ex As Exception
            EM.ErrorSyori(ex, False, conblnNonMsg)
            Return False
        End Try
    End Function

    Private Sub CmbKOMO_NM_Validating(sender As Object, e As System.ComponentModel.CancelEventArgs) Handles cmbKOMO_NM.Validating
        Dim cmb As ComboboxEx = DirectCast(sender, ComboboxEx)

        If cmb.Selected Then
            ErrorProvider.ClearError(cmb)
            IsValidated = (IsValidated AndAlso True)
        Else
            ErrorProvider.SetError(cmb, String.Format(My.Resources.infoMsgRequireSelectOrInput, "���ږ�"), ErrorIconAlignment.MiddleLeft)
            IsValidated = False
        End If
    End Sub

    Private Sub MtxVALUE_Validating(sender As Object, e As System.ComponentModel.CancelEventArgs) Handles mtxVALUE.Validating
        Dim mtx As MaskedTextBoxEx = DirectCast(sender, MaskedTextBoxEx)

        If mtx.Text.IsNullOrWhiteSpace = False Then
            ErrorProvider.ClearError(mtx)
            IsValidated = (IsValidated AndAlso True)
        Else
            ErrorProvider.SetError(mtx, String.Format(My.Resources.infoMsgRequireSelectOrInput, "���ڒl"), ErrorIconAlignment.MiddleLeft)
            IsValidated = False
        End If
    End Sub

#End Region

#Region "���[�J���֐�"

#Region "�o�C���f�B���O"

    Private Function FunSetBinding() As Boolean
        cmbKOMO_NM.DataBindings.Add(New Binding(NameOf(cmbKOMO_NM.SelectedValue), _M001, NameOf(_M001.ITEM_NAME), False, DataSourceUpdateMode.OnPropertyChanged, ""))
        mtxVALUE.DataBindings.Add(New Binding(NameOf(mtxVALUE.Text), _M001, NameOf(_M001.ITEM_VALUE), False, DataSourceUpdateMode.OnPropertyChanged, ""))
        mtxKOMO_GROUP.DataBindings.Add(New Binding(NameOf(mtxKOMO_GROUP.Text), _M001, NameOf(_M001.ITEM_GROUP), False, DataSourceUpdateMode.OnPropertyChanged, ""))
        mtxDISP.DataBindings.Add(New Binding(NameOf(mtxDISP.Text), _M001, NameOf(_M001.ITEM_DISP), False, DataSourceUpdateMode.OnPropertyChanged, ""))
        cmbJYUN.DataBindings.Add(New Binding(NameOf(cmbJYUN.SelectedValue), _M001, NameOf(_M001.DISP_ORDER), False, DataSourceUpdateMode.OnPropertyChanged, 0))
        mtxBIKOU.DataBindings.Add(New Binding(NameOf(mtxBIKOU.Text), _M001, NameOf(_M001.BIKOU), False, DataSourceUpdateMode.OnPropertyChanged, ""))
        chkDefaultVaue.DataBindings.Add(New Binding(NameOf(chkDefaultVaue.Checked), _M001, NameOf(_M001.DEF_FLG), False, DataSourceUpdateMode.OnPropertyChanged, False))

    End Function

#End Region

#Region "�������[�h�ʉ�ʏ�����"
    Private Function FunInitializeControls() As Boolean
        Try
            Dim _Model = New MODEL.ModelInfo(Of MODEL.M001_SETTING)(_OnlyAutoGenerateField:=True)

            Select Case PrMODE
                Case ENM_DATA_OPERATION_MODE._1_ADD
                    lblTytle.Text &= "�i�ǉ��j"
                    cmdFunc1.Text = "�ǉ�(F1)"

                    cmbKOMO_NM.ReadOnly = False
                    mtxVALUE.ReadOnly = False
                    mtxDISP.ReadOnly = False

                    lbllblEDIT_YMDHNS.Visible = False
                    lblEDIT_YMDHNS.Visible = False
                    lbllblEDIT_SYAIN_ID.Visible = False
                    lblEDIT_SYAIN_ID.Visible = False

                Case ENM_DATA_OPERATION_MODE._2_ADDREF

                    lblTytle.Text &= "�i�ގ��ǉ��j"
                    cmdFunc1.Text = "�ǉ�(F1)"

                    cmbKOMO_NM.ReadOnly = False
                    mtxVALUE.ReadOnly = False
                    mtxDISP.ReadOnly = False

                    '�ꗗ�I���s�̃f�[�^�����f���ɓǍ�
                    _Model.Properties.ForEach(Sub(p)
                                                  Select Case p.PropertyType
                                                      Case GetType(Boolean)
                                                          _M001(p.Name) = CBool(PrDataRow.Item(p.Name))
                                                      Case Else
                                                          _M001(p.Name) = PrDataRow.Item(p.Name)
                                                  End Select
                                              End Sub)
                    Call cmbKOMO_NM_Validated(cmbKOMO_NM, Nothing)
                    lbllblEDIT_YMDHNS.Visible = False
                    lblEDIT_YMDHNS.Visible = False
                    lbllblEDIT_SYAIN_ID.Visible = False
                    lblEDIT_SYAIN_ID.Visible = False

                Case ENM_DATA_OPERATION_MODE._3_UPDATE
                    lblTytle.Text &= "�i�ύX�j"
                    cmdFunc1.Text = "�ύX(F1)"

                    cmbKOMO_NM.ReadOnly = True
                    mtxVALUE.ReadOnly = True
                    mtxDISP.ReadOnly = False

                    '�ꗗ�I���s�̃f�[�^�����f���ɓǍ�
                    _Model.Properties.ForEach(Sub(p)
                                                  Select Case p.PropertyType
                                                      Case GetType(Boolean)
                                                          _M001(p.Name) = CBool(PrDataRow.Item(p.Name))
                                                      Case Else
                                                          _M001(p.Name) = PrDataRow.Item(p.Name)
                                                  End Select
                                              End Sub)
                    Call cmbKOMO_NM_Validated(cmbKOMO_NM, Nothing)
                    lbllblEDIT_YMDHNS.Visible = True
                    lblEDIT_YMDHNS.Visible = True
                    lbllblEDIT_SYAIN_ID.Visible = True
                    lblEDIT_SYAIN_ID.Visible = True
                    '�X�V����
                    lblEDIT_YMDHNS.Text = DateTime.ParseExact(PrDataRow.Item(NameOf(_M001.UPD_YMDHNS)), "yyyyMMddHHmmss", Nothing).ToString("yyyy/MM/dd HH:mm:ss")
                    '�X�V�S����CD
                    lblEDIT_SYAIN_ID.Text = PrDataRow.Item(NameOf(_M001.UPD_SYAIN_ID)) & " " & Fun_GetUSER_NAME(PrDataRow.Item(NameOf(_M001.UPD_SYAIN_ID)))

                Case Else
                    Throw New ArgumentException(My.Resources.ErrMsgException, PrMODE.ToString)
            End Select

            Return True

        Catch ex As Exception
            EM.ErrorSyori(ex, False, conblnNonMsg)
            Return False
        End Try
    End Function

#End Region

#Region "�\�����X�V"
    Private Function FunUpdateDispOrder(ByRef DB As ClsDbUtility, ByVal intBeforeValue As Integer, ByVal intAfterValue As Integer) As Boolean
        Dim sbSQL As New System.Text.StringBuilder
        Dim intRET As Integer
        Dim sqlEx As New Exception

        Try

            '���ꍀ�ږ����ɓ����\���������݂���ꍇ�AintTergetJyun�ȍ~�̕\������S�čX�V����
            If intBeforeValue < intAfterValue Then
                sbSQL.Append($"UPDATE {NameOf(MODEL.M001_SETTING)} SET")
                sbSQL.Append($" DISP_ORDER = DISP_ORDER-1 ")
                sbSQL.Append($"WHERE")
                sbSQL.Append($" ITEM_NAME ='{_M001.ITEM_NAME}' ")
                sbSQL.Append($" AND DISP_ORDER >{intBeforeValue} ")
                sbSQL.Append($" AND DISP_ORDER <={intAfterValue} ")
            Else
                '���̕\������菬���������ꍇ�A���̍��ڂ�1���ɂ��炷
                sbSQL.Append($"UPDATE {NameOf(MODEL.M001_SETTING)} SET")
                sbSQL.Append($" DISP_ORDER = DISP_ORDER+1 ")
                sbSQL.Append($"WHERE")
                sbSQL.Append($" ITEM_NAME ='{_M001.ITEM_NAME}' ")
                sbSQL.Append($" AND DISP_ORDER >={intAfterValue} ")
                sbSQL.Append($" AND DISP_ORDER <{intBeforeValue} ")
            End If

            intRET = DB.ExecuteNonQuery(sbSQL.ToString, conblnNonMsg, sqlEx)
            If intRET = 0 Then
                '�G���[���O
                Dim strErrMsg As String = My.Resources.ErrLogSqlExecutionFailure & sbSQL.ToString & "|" & sqlEx.Message
                WL.WriteLogDat(strErrMsg)
                Return False
            End If

            '�ύX�Ώۂ̍X�V
            sbSQL.Remove(0, sbSQL.Length)
            sbSQL.Append($"UPDATE {NameOf(MODEL.M001_SETTING)} SET")
            sbSQL.Append($" DISP_ORDER ='{intAfterValue}' ")
            sbSQL.Append($"WHERE")
            sbSQL.Append($" ITEM_NAME ='{_M001.ITEM_NAME}' ")
            sbSQL.Append($" AND ITEM_VALUE ='{_M001.ITEM_VALUE}' ")
            sbSQL.Append($" AND DISP_ORDER ={intBeforeValue}")

            intRET = DB.ExecuteNonQuery(sbSQL.ToString, conblnNonMsg, sqlEx)
            If intRET <> 1 Then
                '�G���[���O
                Dim strErrMsg As String = My.Resources.ErrLogSqlExecutionFailure & sbSQL.ToString & "|" & sqlEx.Message
                WL.WriteLogDat(strErrMsg)
                Return False
            End If

            Return True
        Catch ex As Exception
            Throw
            Return False
        End Try
    End Function


#End Region


#End Region


End Class
