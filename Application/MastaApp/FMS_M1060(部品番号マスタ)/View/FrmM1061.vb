Imports JMS_COMMON.ClsPubMethod

''' <summary>
''' ���i�ԍ��}�X�^�ҏW���
''' </summary>
Public Class FrmM1061

#Region "�ϐ��E�萔"
    Private IsValidated As Boolean
    Private _M106 As New MODEL.M106_BUHIN
    Private _VWM106 As New MODEL.VWM106_BUHIN
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

        'Me.cmbBUMON_KB.NullValue = 0
        'Me.cmbKEIYAKU_KB.NullValue = 0
        'Me.cmbRIKUKAIKU_KB.NullValue = 0
        Me.cmbTOKUI_ID.NullValue = 0
        Me.chkTachiai.Checked = False

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
            Me.Top = Me.Owner.Top + (Me.Owner.Height - Me.Height) - 10 ' / 2
            Me.Left = Me.Owner.Left + (Me.Owner.Width - Me.Width) / 2

            '-----�R���g���[���f�[�^�\�[�X�ݒ�
            cmbBUMON_KB.SetDataSource(tblBUMON.ExcludeDeleted, ENM_COMBO_SELECT_VALUE_TYPE._0_Required)
            cmbTOKUI_ID.SetDataSource(tblTORIHIKI.ExcludeDeleted, ENM_COMBO_SELECT_VALUE_TYPE._0_Required)
            cmbRIKUKAIKU_KB.SetDataSource(tblRIKUKAIKU_KB.ExcludeDeleted, ENM_COMBO_SELECT_VALUE_TYPE._1_Filter)

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
                        'Me.PrPKeys() = _M106.BUMON_KB

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

    '�J���[�̑I��
    Private Sub btnCOLOR_SELECT_Click(sender As Object, e As EventArgs) Handles btnCOLOR_SELECT.Click
        Dim ColorDialog1 As New ColorDialog()

        ' �����I������F��ݒ肷��
        ColorDialog1.Color = lblSELECTED_COLOR.BackColor

        ' �J�X�^�� �J���[���`�\�ɂ��� (�����l True)
        'ColorDialog1.AllowFullOpen = True

        ' �J�X�^�� �J���[��\��������Ԃɂ��� (�����l False)
        ColorDialog1.FullOpen = True

        ' �g�p�\�Ȃ��ׂĂ̐F����{�Z�b�g�ɕ\������ (�����l False)
        ColorDialog1.AnyColor = True

        ' ���F�̂ݕ\������ (�����l False)
        ColorDialog1.SolidColorOnly = True

        ' �J�X�^�� �J���[��C�ӂ̐F�Őݒ肷��
        ColorDialog1.CustomColors = New Integer() {&H8040FF, &HFF8040, &H80FF40, &H4080FF}

        ' [�w���v] �{�^����\������
        ColorDialog1.ShowHelp = True

        ' �_�C�A���O��\�����A�߂�l�� [OK] �̏ꍇ�͑I�������F�� TextBox1 �ɓK�p����
        If ColorDialog1.ShowDialog() = DialogResult.OK Then
            lblSELECTED_COLOR.BackColor = ColorDialog1.Color
        End If

        ' �s�v�ɂȂ������_�Ŕj������ (�������� �I�u�W�F�N�g�̔j����ۏ؂��� ���Q��)
        ColorDialog1.Dispose()
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

                    Dim ModelInfo As New MODEL.ModelInfo(Of MODEL.M106_BUHIN)(_OnlyAutoGenerateField:=True)

                    '�����f���X�V��
                    '����t���O
                    If Me.chkTachiai.Checked = True Then
                        _M106.TACHIAI_FLG = "1"
                    Else
                        _M106.TACHIAI_FLG = "0"
                    End If

                    '�F�I��
                    _M106.COLOR_CD = "#" & Hex(lblSELECTED_COLOR.BackColor.R).ToString.PadLeft(2, "0"c) & Hex(lblSELECTED_COLOR.BackColor.G).ToString.PadLeft(2, "0"c) & Hex(lblSELECTED_COLOR.BackColor.B).ToString.PadLeft(2, "0"c)

                    _M106.ADD_SYAIN_ID = pub_SYAIN_INFO.SYAIN_ID
                    _M106.ADD_YMDHNS = strSysDate
                    _M106.UPD_SYAIN_ID = pub_SYAIN_INFO.SYAIN_ID
                    '_M106.UPD_YMDHNS = strSysDate

                    '-----MERGE
                    sbSQL.Remove(0, sbSQL.Length)
                    sbSQL.Append($"MERGE INTO {ModelInfo.Name} AS TARGET")
                    sbSQL.Append($" USING (SELECT")

                    sbSQL.Append($" '{_M106.BUMON_KB}' AS {NameOf(_M106.BUMON_KB)}")
                    sbSQL.Append($", {_M106.TOKUI_ID} AS {NameOf(_M106.TOKUI_ID)}")
                    sbSQL.Append($",'{_M106.BUHIN_BANGO}' AS {NameOf(_M106.BUHIN_BANGO)}")
                    sbSQL.Append($",'{_M106.SYANAI_CD}' AS {NameOf(_M106.SYANAI_CD)}")
                    sbSQL.Append($",'{_M106.BUHIN_NAME}' AS {NameOf(_M106.BUHIN_NAME)}")
                    sbSQL.Append($",'{_M106.KEIYAKU_KB}' AS {NameOf(_M106.KEIYAKU_KB)}")
                    sbSQL.Append($",'{_M106.ZUBAN_C}' AS {NameOf(_M106.ZUBAN_C)}")
                    sbSQL.Append($",'{_M106.HINSYU_BANGO}' AS {NameOf(_M106.HINSYU_BANGO)}")
                    sbSQL.Append($",'{_M106.RIKUKAIKU_KB}' AS {NameOf(_M106.RIKUKAIKU_KB)}")
                    sbSQL.Append($",'{_M106.TANKA}' AS {NameOf(_M106.TANKA)}")
                    sbSQL.Append($",'{_M106._TACHIAI_FLG}' AS {NameOf(_M106.TACHIAI_FLG)}")
                    sbSQL.Append($",'{_M106.COLOR_CD}' AS {NameOf(_M106.COLOR_CD)}")
                    sbSQL.Append($",'{_M106.ADD_YMDHNS}' AS {NameOf(_M106.ADD_YMDHNS)}")
                    sbSQL.Append($", {_M106.ADD_SYAIN_ID} AS {NameOf(_M106.ADD_SYAIN_ID)}")
                    sbSQL.Append($",'{_M106.UPD_YMDHNS}' AS {NameOf(_M106.UPD_YMDHNS)}")
                    sbSQL.Append($", {_M106.UPD_SYAIN_ID} AS {NameOf(_M106.UPD_SYAIN_ID)}")
                    sbSQL.Append($",'{_M106.DEL_YMDHNS}' AS {NameOf(_M106.DEL_YMDHNS)}")
                    sbSQL.Append($", {_M106.DEL_SYAIN_ID} AS {NameOf(_M106.DEL_SYAIN_ID)}")

                    sbSQL.Append($" ) AS WK ON (")
                    sbSQL.Append($" TARGET.{NameOf(_M106.BUMON_KB)} = WK.{NameOf(_M106.BUMON_KB)}")
                    sbSQL.Append($" AND TARGET.{NameOf(_M106.TOKUI_ID)} = WK.{NameOf(_M106.TOKUI_ID)}")
                    sbSQL.Append($" AND TARGET.{NameOf(_M106.BUHIN_BANGO)} = WK.{NameOf(_M106.BUHIN_BANGO)}")
                    sbSQL.Append($" )")

                    '---UPDATE �r������ �X�V�������ύX����Ă��Ȃ��ꍇ�̂�
                    sbSQL.Append($" WHEN MATCHED AND TARGET.{NameOf(_M106.UPD_YMDHNS)} = WK.{NameOf(_M106.UPD_YMDHNS)} THEN ")
                    sbSQL.Append($" UPDATE SET")
                    sbSQL.Append($" TARGET.{NameOf(_M106.SYANAI_CD)} = WK.{NameOf(_M106.SYANAI_CD)}")
                    sbSQL.Append($",TARGET.{NameOf(_M106.BUHIN_NAME)} = WK.{NameOf(_M106.BUHIN_NAME)}")
                    sbSQL.Append($",TARGET.{NameOf(_M106.KEIYAKU_KB)} = WK.{NameOf(_M106.KEIYAKU_KB)}")
                    sbSQL.Append($",TARGET.{NameOf(_M106.ZUBAN_C)} = WK.{NameOf(_M106.ZUBAN_C)}")
                    sbSQL.Append($",TARGET.{NameOf(_M106.HINSYU_BANGO)} = WK.{NameOf(_M106.HINSYU_BANGO)}")
                    sbSQL.Append($",TARGET.{NameOf(_M106.RIKUKAIKU_KB)} = WK.{NameOf(_M106.RIKUKAIKU_KB)}")
                    sbSQL.Append($",TARGET.{NameOf(_M106.TANKA)} = WK.{NameOf(_M106.TANKA)}")
                    sbSQL.Append($",TARGET.{NameOf(_M106.TACHIAI_FLG)} = WK.{NameOf(_M106.TACHIAI_FLG)}")
                    sbSQL.Append($",TARGET.{NameOf(_M106.COLOR_CD)} = WK.{NameOf(_M106.COLOR_CD)}")
                    sbSQL.Append($",TARGET.{NameOf(_M106.UPD_YMDHNS)} = '{strSysDate}'")
                    sbSQL.Append($",TARGET.{NameOf(_M106.UPD_SYAIN_ID)} = WK.{NameOf(_M106.UPD_SYAIN_ID)}")

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
#End Region

#End Region

#Region "�R���g���[���C�x���g"

#End Region

#Region "���[�J���֐�"

#Region "�o�C���f�B���O"
    Private Function FunSetBinding() As Boolean
        cmbBUMON_KB.DataBindings.Add(New Binding(NameOf(cmbBUMON_KB.SelectedValue), _M106, NameOf(_M106.BUMON_KB), False, DataSourceUpdateMode.OnPropertyChanged, ""))
        cmbTOKUI_ID.DataBindings.Add(New Binding(NameOf(cmbTOKUI_ID.SelectedValue), _M106, NameOf(_M106.TOKUI_ID), False, DataSourceUpdateMode.OnPropertyChanged, ""))
        mtxBUHIN_BANGO.DataBindings.Add(New Binding(NameOf(mtxBUHIN_BANGO.Text), _M106, NameOf(_M106.BUHIN_BANGO), False, DataSourceUpdateMode.OnPropertyChanged, ""))
        mtxBUHIN_NAME.DataBindings.Add(New Binding(NameOf(mtxBUHIN_NAME.Text), _M106, NameOf(_M106.BUHIN_NAME), False, DataSourceUpdateMode.OnPropertyChanged, ""))
        mtxSYANAI_CD.DataBindings.Add(New Binding(NameOf(mtxSYANAI_CD.Text), _M106, NameOf(_M106.SYANAI_CD), False, DataSourceUpdateMode.OnPropertyChanged, ""))

        cmbKEIYAKU_KB.DataBindings.Add(New Binding(NameOf(cmbKEIYAKU_KB.SelectedValue), _M106, NameOf(_M106.KEIYAKU_KB), False, DataSourceUpdateMode.OnPropertyChanged, ""))

        cmbRIKUKAIKU_KB.DataBindings.Add(New Binding(NameOf(cmbRIKUKAIKU_KB.SelectedValue), _M106, NameOf(_M106.RIKUKAIKU_KB), False, DataSourceUpdateMode.OnPropertyChanged, ""))
        mtxZUBAN_C.DataBindings.Add(New Binding(NameOf(mtxZUBAN_C.Text), _M106, NameOf(_M106.ZUBAN_C), False, DataSourceUpdateMode.OnPropertyChanged, ""))
        mtxTANKA.DataBindings.Add(New Binding(NameOf(mtxTANKA.Text), _M106, NameOf(_M106.TANKA), True, DataSourceUpdateMode.OnPropertyChanged, "", "0.00"))
        mtxHINSYU_BANGO.DataBindings.Add(New Binding(NameOf(mtxHINSYU_BANGO.Text), _M106, NameOf(_M106.HINSYU_BANGO), False, DataSourceUpdateMode.OnPropertyChanged, ""))
        chkTachiai.DataBindings.Add(New Binding(NameOf(chkTachiai.Checked), _M106, NameOf(_M106.TACHIAI_FLG), False, DataSourceUpdateMode.OnPropertyChanged, False))


    End Function

#End Region

#Region "�������[�h�ʉ�ʏ�����"
    Private Function FunInitializeControls() As Boolean
        Dim _Model = New MODEL.ModelInfo(Of MODEL.VWM106_BUHIN)(_OnlyAutoGenerateField:=True)
        Dim C_R As Integer
        Dim C_G As Integer
        Dim C_B As Integer

        Try
            Select Case PrDATA_OP_MODE
                Case ENM_DATA_OPERATION_MODE._1_ADD
                    lblTytle.Text &= "�i�ǉ��j"
                    cmdFunc1.Text = "�ǉ�(F1)"

                    lbllblEDIT_YMDHNS.Visible = False
                    lblEDIT_YMDHNS.Visible = False
                    lbllblEDIT_SYAIN_ID.Visible = False
                    lblEDIT_SYAIN_ID.Visible = False

                Case ENM_DATA_OPERATION_MODE._2_ADDREF

                    _M106.Properties.ForEach(Sub(p)
                                                 Select Case p.PropertyType
                                                     Case GetType(Boolean)
                                                         _M106(p.Name) = CBool(PrDataRow.Item(p.Name))
                                                     Case Else
                                                         _M106(p.Name) = PrDataRow.Item(p.Name)
                                                 End Select
                                             End Sub)

                    lblTytle.Text &= "�i�ގ��ǉ��j"
                    cmdFunc1.Text = "�ǉ�(F1)"

                    lblEDIT_YMDHNS.Visible = False
                    lbllblEDIT_SYAIN_ID.Visible = False
                    lblEDIT_SYAIN_ID.Visible = False

                Case ENM_DATA_OPERATION_MODE._2_ADDREF, ENM_DATA_OPERATION_MODE._3_UPDATE

                    _M106.Properties.ForEach(Sub(p)
                                                 Select Case p.PropertyType
                                                     Case GetType(Boolean)
                                                         _M106(p.Name) = CBool(PrDataRow.Item(p.Name))
                                                     Case Else
                                                         _M106(p.Name) = PrDataRow.Item(p.Name)
                                                 End Select
                                             End Sub)

                    lblTytle.Text &= "�i�ύX�j"
                    Me.cmdFunc1.Text = "�ύX(F1)"



                    Using DB As ClsDbUtility = DBOpen()

                        cmbKEIYAKU_KB.DataBindings.Clear()

                        Select Case cmbBUMON_KB.SelectedValue
                            Case ENM_BUMON_KB._1_���h
                                mtxBUHIN_NAME.Enabled = True

                                Call FunGetCodeDataTable(DB, "���h�_��敪", tblKK_KEIYAKU_KB)
                                cmbKEIYAKU_KB.SetDataSource(tblKK_KEIYAKU_KB.ExcludeDeleted, ENM_COMBO_SELECT_VALUE_TYPE._1_Filter)
                                cmbKEIYAKU_KB.Enabled = True
                                _M106.ZUBAN_C = ""
                                mtxZUBAN_C.Enabled = False

                            Case ENM_BUMON_KB._2_LP
                                mtxBUHIN_NAME.Enabled = True

                                Call FunGetCodeDataTable(DB, "LP�_��敪", tblLP_KEIYAKU_KB)
                                cmbKEIYAKU_KB.SetDataSource(tblLP_KEIYAKU_KB.ExcludeDeleted, ENM_COMBO_SELECT_VALUE_TYPE._1_Filter)
                                mtxZUBAN_C.Enabled = True

                            Case ENM_BUMON_KB._3_������
                                mtxBUHIN_NAME.Enabled = False
                                _M106.BUHIN_NAME = ""
                                Call FunGetCodeDataTable(DB, "�����ތ_��敪", tblFK_KEIYAKU_KB)
                                cmbKEIYAKU_KB.SetDataSource(tblFK_KEIYAKU_KB.ExcludeDeleted, ENM_COMBO_SELECT_VALUE_TYPE._1_Filter)

                                _M106.ZUBAN_C = ""
                                mtxZUBAN_C.Enabled = False

                            Case Else

                        End Select
                    End Using
                    cmbKEIYAKU_KB.DataBindings.Add(New Binding(NameOf(cmbKEIYAKU_KB.SelectedValue), _M106, NameOf(_M106.KEIYAKU_KB), False, DataSourceUpdateMode.OnPropertyChanged, ""))

                    cmbBUMON_KB.Enabled = False


                    If _M106.COLOR_CD.Trim <> "" Then
                        C_R = CInt("&h" & _M106.COLOR_CD.Substring(1, 2))
                        C_G = CInt("&h" & _M106.COLOR_CD.Substring(3, 2))
                        C_B = CInt("&h" & _M106.COLOR_CD.Substring(5, 2))
                        lblSELECTED_COLOR.BackColor = Color.FromArgb(C_R, C_G, C_B)
                    End If

                    If PrDATA_OP_MODE = ENM_DATA_OPERATION_MODE._2_ADDREF Then
                        lblEDIT_YMDHNS.Visible = False
                        lbllblEDIT_SYAIN_ID.Visible = False
                        lblEDIT_SYAIN_ID.Visible = False
                    Else
                        cmbTOKUI_ID.Enabled = False
                        mtxBUHIN_BANGO.Enabled = False

                        lbllblEDIT_YMDHNS.Visible = True
                        lblEDIT_YMDHNS.Visible = True
                        lbllblEDIT_SYAIN_ID.Visible = True
                        lblEDIT_SYAIN_ID.Visible = True
                        '�X�V����
                        If _M106.UPD_YMDHNS.ToString.Trim <> "" Then
                            lblEDIT_YMDHNS.Text = DateTime.ParseExact(PrDataRow.Item(NameOf(_M106.UPD_YMDHNS)), "yyyyMMddHHmmss", Nothing).ToString("yyyy/MM/dd HH:mm:ss")
                            '�X�V�S����CD
                            lblEDIT_SYAIN_ID.Text = PrDataRow.Item(NameOf(_M106.UPD_SYAIN_ID)) & " " & Fun_GetUSER_NAME(PrDataRow.Item(NameOf(_M106.UPD_SYAIN_ID)))
                        Else
                            lblEDIT_YMDHNS.Text = ""
                            lblEDIT_SYAIN_ID.Text = ""
                        End If


                    End If

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
    '���̓`�F�b�N�@���C��
    Public Function FunCheckInput() As Boolean

        Try
            IsValidated = True

            Call CmbBUMON_KB_Validating(cmbBUMON_KB, Nothing)
            Call CmbTOKUI_ID_Validating(cmbTOKUI_ID, Nothing)
            Call MtxBUHIN_BANGO_Validating(mtxBUHIN_BANGO, Nothing)

            Return IsValidated
        Catch ex As Exception
            EM.ErrorSyori(ex, False, conblnNonMsg)
            Return False
        End Try
    End Function

    '����敪�@���̓`�F�b�N
    Private Sub CmbBUMON_KB_Validating(sender As Object, e As System.EventArgs) Handles cmbBUMON_KB.Validated
        Dim cmb As ComboboxEx = DirectCast(sender, ComboboxEx)

        If cmb.IsSelected Then
            ErrorProvider.ClearError(cmb)
            IsValidated = (IsValidated AndAlso True)

            '����敪�̑I�����̏���
            Using DB As ClsDbUtility = DBOpen()

                cmbKEIYAKU_KB.DataBindings.Clear()

                Select Case cmbBUMON_KB.SelectedValue
                    Case ENM_BUMON_KB._1_���h
                        mtxBUHIN_NAME.Enabled = True

                        Call FunGetCodeDataTable(DB, "���h�_��敪", tblKK_KEIYAKU_KB)
                        cmbKEIYAKU_KB.SetDataSource(tblKK_KEIYAKU_KB.ExcludeDeleted, ENM_COMBO_SELECT_VALUE_TYPE._1_Filter)
                        cmbKEIYAKU_KB.Enabled = True
                        _M106.ZUBAN_C = ""
                        mtxZUBAN_C.Enabled = False

                    Case ENM_BUMON_KB._2_LP
                        mtxBUHIN_NAME.Enabled = True

                        Call FunGetCodeDataTable(DB, "LP�_��敪", tblLP_KEIYAKU_KB)
                        cmbKEIYAKU_KB.SetDataSource(tblLP_KEIYAKU_KB.ExcludeDeleted, ENM_COMBO_SELECT_VALUE_TYPE._1_Filter)
                        mtxZUBAN_C.Enabled = True

                    Case ENM_BUMON_KB._3_������
                        mtxBUHIN_NAME.Enabled = False
                        _M106.BUHIN_NAME = ""
                        Call FunGetCodeDataTable(DB, "�����ތ_��敪", tblFK_KEIYAKU_KB)
                        cmbKEIYAKU_KB.SetDataSource(tblFK_KEIYAKU_KB.ExcludeDeleted, ENM_COMBO_SELECT_VALUE_TYPE._1_Filter)

                        _M106.ZUBAN_C = ""
                        mtxZUBAN_C.Enabled = False

                    Case Else

                End Select

                cmbKEIYAKU_KB.DataBindings.Add(New Binding(NameOf(cmbKEIYAKU_KB.SelectedValue), _M106, NameOf(_M106.KEIYAKU_KB), False, DataSourceUpdateMode.OnPropertyChanged, ""))

                cmbKEIYAKU_KB.SelectedValue = _M106.KEIYAKU_KB
                'If PrDATA_OP_MODE = ENM_DATA_OPERATION_MODE._2_ADDREF Or PrDATA_OP_MODE = ENM_DATA_OPERATION_MODE._3_UPDATE Then
                '    cmbBUMON_KB.Enabled = False
                'End If

            End Using

        Else
            ErrorProvider.SetError(cmb, String.Format(My.Resources.infoMsgRequireSelectOrInput, "����敪"), ErrorIconAlignment.MiddleLeft)
            IsValidated = False
        End If
    End Sub
    '���Ӑ�@���̓`�F�b�N
    Private Sub CmbTOKUI_ID_Validating(sender As Object, e As System.ComponentModel.CancelEventArgs) Handles cmbTOKUI_ID.Validating
        Dim cmb As ComboboxEx = DirectCast(sender, ComboboxEx)

        If cmb.IsSelected Then
            ErrorProvider.ClearError(cmb)
            IsValidated = (IsValidated AndAlso True)
        Else
            ErrorProvider.SetError(cmb, String.Format(My.Resources.infoMsgRequireSelectOrInput, "���Ӑ�"), ErrorIconAlignment.MiddleLeft)
            IsValidated = False
        End If
    End Sub
    '���i�ԍ��@���̓`�F�b�N
    Private Sub MtxBUHIN_BANGO_Validating(sender As Object, e As System.ComponentModel.CancelEventArgs) Handles mtxBUHIN_BANGO.Validating
        Dim mtx As MaskedTextBoxEx = DirectCast(sender, MaskedTextBoxEx)

        If mtx.Text.IsNullOrWhiteSpace = False Then
            ErrorProvider.ClearError(mtx)
            IsValidated = (IsValidated AndAlso True)
        Else
            ErrorProvider.SetError(mtx, String.Format(My.Resources.infoMsgRequireSelectOrInput, "���i�ԍ�"), ErrorIconAlignment.MiddleLeft)
            IsValidated = False
        End If
    End Sub

    '���i�ԍ��@���̓`�F�b�N
    Private Sub MtxTANKA_Validating(sender As Object, e As System.ComponentModel.CancelEventArgs) Handles mtxTANKA.Validating
        Dim mtx As MaskedTextBoxEx = DirectCast(sender, MaskedTextBoxEx)

        If mtx.Text.IsNullOrWhiteSpace = False Then
            ErrorProvider.ClearError(mtx)
            IsValidated = (IsValidated AndAlso True)
        Else
            ErrorProvider.SetError(mtx, String.Format(My.Resources.infoMsgRequireSelectOrInput, "�P��"), ErrorIconAlignment.MiddleLeft)
            IsValidated = False
        End If

    End Sub



#End Region

#End Region



End Class
