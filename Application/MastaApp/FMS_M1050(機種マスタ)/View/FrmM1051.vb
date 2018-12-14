Imports JMS_COMMON.ClsPubMethod

''' <summary>
''' �@��}�X�^�ҏW���
''' </summary>
Public Class FrmM1051

#Region "�ϐ��E�萔"
    Private IsValidated As Boolean
    Private _M105 As New MODEL.M105_KISYU
#End Region

#Region "�v���p�e�B"
    ''' <summary>
    ''' �������[�h
    ''' </summary>
    Public Property PrDATA_OP_MODE As Integer

    ''' <summary>
    ''' �V�K�ǉ����R�[�h�̃L�[
    ''' </summary>
    Public Property PrPKeys As Integer

    ''' <summary>
    ''' �ꗗ�̑I���s�f�[�^
    ''' </summary>
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

        Me.Height = 300
        Me.FormBorderStyle = Windows.Forms.FormBorderStyle.FixedDialog
        Me.MaximizeBox = False
        Me.MinimizeBox = False

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
            Me.Top = Me.Owner.Top + (Me.Owner.Height - Me.Height) - 26 ' / 2
            Me.Left = Me.Owner.Left + (Me.Owner.Width - Me.Width) / 2

            '-----�R���g���[���f�[�^�\�[�X�ݒ�
            CmbBUMON_KB.SetDataSource(tblBUMON.ExcludeDeleted, ENM_COMBO_SELECT_VALUE_TYPE._0_Required)

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

#Region "FUNCTION�{�^��CLICK"

#Region "�{�^���N���b�N�C�x���g"
    Private Sub CmdFunc_Click(ByVal sender As Object, ByVal e As EventArgs) Handles cmdFunc1.Click, cmdFunc2.Click, cmdFunc3.Click, cmdFunc4.Click, cmdFunc5.Click, cmdFunc6.Click, cmdFunc7.Click, cmdFunc8.Click, cmdFunc9.Click, cmdFunc10.Click, cmdFunc11.Click, cmdFunc12.Click
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
                Case 1  '�ǉ�
                    If FunSAVE() Then
                        '�v���p�e�B�ɑΏۃ��R�[�h�̃L�[��ݒ�
                        Me.PrPKeys = _M105.KISYU_ID

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

                    strSysDate = DB.GetSysDateString

                    Dim ModelInfo As New MODEL.ModelInfo(Of MODEL.M105_KISYU)(_OnlyAutoGenerateField:=True)

                    '���f���X�V
                    If PrDATA_OP_MODE <> ENM_DATA_OPERATION_MODE._3_UPDATE Then _M105.KISYU_ID = FunGetNextIdentity()
                    _M105.ADD_SYAIN_ID = pub_SYAIN_INFO.SYAIN_ID
                    _M105.ADD_YMDHNS = strSysDate
                    _M105.UPD_SYAIN_ID = pub_SYAIN_INFO.SYAIN_ID
                    '_M105.UPD_YMDHNS = strSysDate

                    '-----MERGE
                    sbSQL.Remove(0, sbSQL.Length)
                    sbSQL.Append($"MERGE INTO {ModelInfo.Name} AS TARGET")
                    sbSQL.Append($" USING (SELECT")

                    sbSQL.Append($" {_M105.KISYU_ID} AS {NameOf(_M105.KISYU_ID)}")
                    sbSQL.Append($",'{_M105.BUMON_KB}' AS {NameOf(_M105.BUMON_KB)}")
                    sbSQL.Append($",'{_M105.KISYU_NAME}' AS {NameOf(_M105.KISYU_NAME)}")
                    sbSQL.Append($",'{_M105.ADD_YMDHNS}' AS {NameOf(_M105.ADD_YMDHNS)}")
                    sbSQL.Append($",{_M105.ADD_SYAIN_ID} AS {NameOf(_M105.ADD_SYAIN_ID)}")
                    sbSQL.Append($",'{_M105.UPD_YMDHNS}' AS {NameOf(_M105.UPD_YMDHNS)}")
                    sbSQL.Append($",{_M105.UPD_SYAIN_ID} AS {NameOf(_M105.UPD_SYAIN_ID)}")
                    sbSQL.Append($",'{_M105.DEL_YMDHNS}' AS {NameOf(_M105.DEL_YMDHNS)}")
                    sbSQL.Append($",{_M105.DEL_SYAIN_ID} AS {NameOf(_M105.DEL_SYAIN_ID)}")

                    sbSQL.Append($" ) AS WK ON (")
                    sbSQL.Append($" TARGET.{NameOf(_M105.KISYU_ID)} = WK.{NameOf(_M105.KISYU_ID)}")
                    sbSQL.Append($" )")

                    '---UPDATE �r������ �X�V�������ύX����Ă��Ȃ��ꍇ�̂�
                    sbSQL.Append($" WHEN MATCHED AND TARGET.{NameOf(_M105.UPD_YMDHNS)} = WK.{NameOf(_M105.UPD_YMDHNS)} THEN ")
                    sbSQL.Append($" UPDATE SET")
                    sbSQL.Append($" TARGET.{NameOf(_M105.BUMON_KB)} = WK.{NameOf(_M105.BUMON_KB)}")
                    sbSQL.Append($",TARGET.{NameOf(_M105.KISYU_NAME)} = WK.{NameOf(_M105.KISYU_NAME)}")
                    sbSQL.Append($",TARGET.{NameOf(_M105.UPD_YMDHNS)} = '{strSysDate}'")
                    sbSQL.Append($",TARGET.{NameOf(_M105.UPD_SYAIN_ID)} = WK.{NameOf(_M105.UPD_SYAIN_ID)}")

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
    ''' <param name="frm">�Ώۃt�H�[��</param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function FunInitFuncButtonEnabled() As Boolean

        Try
            For intFunc As Integer = 1 To 12
                With Me.Controls("cmdFunc" & intFunc)
                    If .Text.Length = 0 OrElse .Text.Substring(0, .Text.IndexOf("(")).IsNulOrWS Then
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
#End Region

#End Region

#Region "�R���g���[���C�x���g"

#End Region

#Region "���[�J���֐�"

#Region "�o�C���f�B���O"
    Private Function FunSetBinding() As Boolean
        CmbBUMON_KB.DataBindings.Add(New Binding(NameOf(CmbBUMON_KB.SelectedValue), _M105, NameOf(_M105.BUMON_KB), False, DataSourceUpdateMode.OnPropertyChanged, ""))
        mtxKISYU_NAME.DataBindings.Add(New Binding(NameOf(mtxKISYU_NAME.Text), _M105, NameOf(_M105.KISYU_NAME), False, DataSourceUpdateMode.OnPropertyChanged, ""))

    End Function

#End Region

#Region "�������[�h�ʉ�ʏ�����"
    Private Function FunInitializeControls() As Boolean
        Dim _Model = New MODEL.ModelInfo(Of MODEL.M105_KISYU)(_OnlyAutoGenerateField:=True)

        Try
            Select Case PrDATA_OP_MODE
                Case ENM_DATA_OPERATION_MODE._1_ADD
                    lblTytle.Text &= "�i�ǉ��j"
                    cmdFunc1.Text = "�ǉ�(F1)"

                    mtxKISYU_ID.Text = "<�V�K>"
                    mtxKISYU_ID.ReadOnly = True

                    lbllblEDIT_YMDHNS.Visible = False
                    lblEDIT_YMDHNS.Visible = False
                    lbllblEDIT_SYAIN_ID.Visible = False
                    lblEDIT_SYAIN_ID.Visible = False

                Case ENM_DATA_OPERATION_MODE._2_ADDREF
                    _Model.Properties.ForEach(Sub(p)
                                                  Select Case p.PropertyType
                                                      Case GetType(Boolean)
                                                          _M105(p.Name) = CBool(PrDataRow.Item(p.Name))
                                                      Case Else
                                                          _M105(p.Name) = PrDataRow.Item(p.Name)
                                                  End Select
                                              End Sub)

                    lblTytle.Text &= "�i�ގ��ǉ��j"
                    cmdFunc1.Text = "�ǉ�(F1)"

                    mtxKISYU_ID.Text = "<�V�K>"
                    mtxKISYU_ID.ReadOnly = True

                    lbllblEDIT_YMDHNS.Visible = False
                    lblEDIT_YMDHNS.Visible = False
                    lbllblEDIT_SYAIN_ID.Visible = False
                    lblEDIT_SYAIN_ID.Visible = False

                Case ENM_DATA_OPERATION_MODE._3_UPDATE
                    mtxKISYU_ID.DataBindings.Add(New Binding(NameOf(mtxKISYU_ID.Text), _M105, NameOf(_M105.KISYU_ID), False, DataSourceUpdateMode.OnPropertyChanged, 0))
                    _Model.Properties.ForEach(Sub(p)
                                                  Select Case p.PropertyType
                                                      Case GetType(Boolean)
                                                          _M105(p.Name) = CBool(PrDataRow.Item(p.Name))
                                                      Case Else
                                                          _M105(p.Name) = PrDataRow.Item(p.Name)
                                                  End Select
                                              End Sub)

                    lblTytle.Text &= "�i�ύX�j"
                    Me.cmdFunc1.Text = "�ύX(F1)"

                    mtxKISYU_ID.ReadOnly = True

                    lbllblEDIT_YMDHNS.Visible = True
                    lblEDIT_YMDHNS.Visible = True
                    lbllblEDIT_SYAIN_ID.Visible = True
                    lblEDIT_SYAIN_ID.Visible = True

                    '�X�V����
                    'lblEDIT_YMDHNS.Text = DateTime.ParseExact(PrDataRow.Item(NameOf(_M105.UPD_YMDHNS)), "yyyyMMddHHmmss", Nothing).ToString("yyyy/MM/dd HH:mm:ss")
                    lblEDIT_YMDHNS.Text = PrDataRow.Item(NameOf(_M105.UPD_YMDHNS)).ToString
                    '�X�V�S����CD
                    lblEDIT_SYAIN_ID.Text = PrDataRow.Item(NameOf(_M105.UPD_SYAIN_ID)) & " " & Fun_GetUSER_NAME(PrDataRow.Item(NameOf(_M105.UPD_SYAIN_ID)))

                Case Else
                    Throw New ArgumentException(My.Resources.ErrMsgException, PrDATA_OP_MODE.ToString)
            End Select

            Return True

        Catch ex As Exception
            EM.ErrorSyori(ex, False, conblnNonMsg)
            Return False
        End Try
    End Function

#End Region

#Region "���̓`�F�b�N"
    Public Function FunCheckInput() As Boolean

        Try
            IsValidated = True

            Call CmbBUMON_KB_Validating(CmbBUMON_KB, Nothing)
            Call mtxKISYU_NAME_Validating(mtxKISYU_NAME, Nothing)

            Return IsValidated
        Catch ex As Exception
            EM.ErrorSyori(ex, False, conblnNonMsg)
            Return False
        End Try
    End Function

    Private Sub CmbBUMON_KB_Validating(sender As Object, e As System.ComponentModel.CancelEventArgs) Handles CmbBUMON_KB.Validating
        Dim cmb As ComboboxEx = DirectCast(sender, ComboboxEx)
        IsValidated *= ErrorProvider.UpdateErrorInfo(cmb, cmb.IsSelected, String.Format(My.Resources.infoMsgRequireSelectOrInput, "����敪"))

    End Sub

    Private Sub MtxKISYU_NAME_Validating(sender As Object, e As System.ComponentModel.CancelEventArgs) Handles mtxKISYU_NAME.Validating
        Dim mtx As MaskedTextBoxEx = DirectCast(sender, MaskedTextBoxEx)
        IsValidated *= ErrorProvider.UpdateErrorInfo(mtx, Not mtx.Text.IsNulOrWS, String.Format(My.Resources.infoMsgRequireSelectOrInput, "�@�햼"))

    End Sub


#End Region

    Private Function FunGetNextIdentity() As Integer

        Dim dsList As New System.Data.DataSet
        Try
            Dim intRET As Integer
            Dim sbSQL As New System.Text.StringBuilder

            sbSQL.Remove(0, sbSQL.Length)
            sbSQL.Append($"SELECT MAX(KISYU_ID) FROM {NameOf(MODEL.M105_KISYU)}")
            Using DB As ClsDbUtility = DBOpen()
                dsList = DB.GetDataSet(sbSQL.ToString, conblnNonMsg)
            End Using

            intRET = Val(dsList.Tables(0).Rows(0).Item(0)) + 1

            Return intRET
        Catch ex As Exception
            EM.ErrorSyori(ex, False, conblnNonMsg)
            Return -1
        Finally
            dsList.Dispose()
        End Try
    End Function

#End Region



End Class
