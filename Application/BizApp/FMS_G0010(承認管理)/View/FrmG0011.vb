Imports JMS_COMMON.ClsPubMethod


Public Class FrmG0011

#Region "�萔�E�ϐ�"
    Private _tabPageManager As TabPageManager

#End Region

#Region "�v���p�e�B"
    ''' <summary>
    ''' �������[�h
    ''' </summary>
    Public Property PrMODE As Integer

    ''' <summary>
    ''' �ǉ��X�V���R�[�h�̃L�[
    ''' </summary>
    Public Property PrPKeys As String

    ''' <summary>
    ''' �ꗗ�̑I���s�f�[�^
    ''' </summary>
    Public Property PrdgvCellCollection As DataGridViewCellCollection

    Public Property PrDataRow As DataRow


    'DEBUG:
    Public Property PrDt As DataTable
#End Region

#Region "�R���X�g���N�^"

    ''' <summary>
    ''' �R���X�g���N�^
    ''' </summary>
    ''' <remarks>�R���X�g���N�^</remarks>
    Public Sub New()

        ' ���̌Ăяo���̓f�U�C�i�[�ŕK�v�ł��B
        InitializeComponent()
        '�c�[���`�b�v���b�Z�[�W
        MyBase.ToolTip.SetToolTip(Me.cmdFunc3, My.Resources.infoToolTipMsgNotFoundData)
        MyBase.ToolTip.SetToolTip(Me.cmdFunc4, "�V�K�o�^���͎g�p�o���܂���")
        MyBase.ToolTip.SetToolTip(Me.cmdFunc5, "�V�K�o�^���͎g�p�o���܂���")
        MyBase.ToolTip.SetToolTip(Me.cmdFunc10, "�V�K�o�^���͎g�p�o���܂���")
        MyBase.ToolTip.SetToolTip(Me.cmdFunc11, "�V�K�o�^���͎g�p�o���܂���")


    End Sub

#End Region

#Region "Form�֘A"

    'Load�C�x���g
    Private Sub FrmLoad(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        Try
            '-----�t�H�[�������ݒ�(�e�t�H�[������Ăяo��)
            Call FunFormCommonSetting(pub_APP_INFO, pub_SYAIN_INFO, My.Application.Info.Version.ToString)
            Me.Text = "�s�K�����i���u�񍐏�(Non-Conformance Report)"
            lblTytle.Text = Me.Text

            '-----�R���g���[���f�[�^�\�[�X�ݒ�
            cmbBUMON.SetDataSource(tblBUMON.ExcludeDeleted, ENM_COMBO_SELECT_VALUE_TYPE._0_Required)
            cmbKISYU.SetDataSource(tblKISYU.ExcludeDeleted, ENM_COMBO_SELECT_VALUE_TYPE._0_Required)
            cmbBUHIN_BANGO.SetDataSource(tblBUHIN.ExcludeDeleted, ENM_COMBO_SELECT_VALUE_TYPE._0_Required)
            cmbFUTEKIGO_STATUS.SetDataSource(tblFUTEKIGO_STATUS_KB.ExcludeDeleted, ENM_COMBO_SELECT_VALUE_TYPE._0_Required)
            cmbFUTEKIGO_KB.SetDataSource(tblFUTEKIGO_KB.ExcludeDeleted, ENM_COMBO_SELECT_VALUE_TYPE._0_Required)


            '����l�̐ݒ�

            '''-----�C�x���g�n���h���ݒ�
            'AddHandler Me.cmbKOMO_NM.SelectedValueChanged, AddressOf SearchFilterValueChanged
            'AddHandler Me.chkDeletedRowVisibled.CheckedChanged, AddressOf SearchFilterValueChanged

            '-----�������[�h�ʉ�ʏ�����
            Call FunInitializeControls(PrMODE)
        Finally
            Call FunInitFuncButtonEnabled()
        End Try
    End Sub

#Region "KEYDOWN"
    'KEYDOWN
    Private Sub FrmMBCA000MENU_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        Dim KeyCode As Short = e.KeyCode

        Try
            '�������ꂽ�L�[�R�[�h�擾
            KeyCode = e.KeyCode

            If (KeyCode = Windows.Forms.Keys.A) And (e.Modifiers = Keys.Control + Keys.Shift) Then

                Call FunSetAllTabPages()
            End If

        Catch ex As Exception
            EM.ErrorSyori(ex, False, conblnNonMsg)
        End Try

    End Sub
#End Region

#End Region

#Region "�������[�h�ʉ�ʏ�����"
    Private Function FunInitializeControls(ByVal intMODE As Integer) As Boolean

        Try
            Select Case intMODE
                Case ENM_DATA_OPERATION_MODE._1_ADD

                    mtxHOKUKO_NO.Text = "<�V�K>"
                    mtxHOKUKO_NO.Enabled = True
                    mtxHOKUKO_NO.ReadOnly = True

                    mtxADD_SYAIN_NAME.Text = pub_SYAIN_INFO.SYAIN_NAME
                    mtxADD_SYAIN_NAME.Enabled = False

                    dtDraft.Text = Today.ToString("yyyy/MM/dd")
                    dtDraft.Enabled = False

                    numSU.Value = 1


                    Call FunInitializeTabControl(FunConvertSYONIN_JUN_TO_STAGE_NO(ENM_NCR_STAGE._10_�N������))
                    Call FunInitializeSTAGE(ENM_NCR_STAGE._10_�N������)

                Case ENM_DATA_OPERATION_MODE._3_UPDATE


                    'SPEC: 10-2.�@
                    Call FunSetEntityValues(PrDataRow)

                    Call FunInitializeTabControl(FunConvertSYONIN_JUN_TO_STAGE_NO(PrDataRow.Item("SYONIN_JUN")))
                    Call FunInitializeSTAGE(PrDataRow.Item("SYONIN_JUN"))
                    mtxHOKUKO_NO.Enabled = False

                    For Each page As TabPage In TabSTAGE.TabPages
                        If page.text = "���X�e�[�W" Then
                            TabSTAGE.SelectedIndex = page.TabIndex
                            Exit For
                        End If
                    Next page

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
    ''' <param name="dgvCol"></param>
    ''' <returns></returns>
    Private Function FunSetEntityValues(dr As DataRow) As Boolean

        Try
            '-----�R���g���[���ɒl���Z�b�g
            Dim sbSQL As New System.Text.StringBuilder
            Dim dsList As New DataSet
            sbSQL.Remove(0, sbSQL.Length)
            sbSQL.Append("SELECT")
            sbSQL.Append(" *")
            sbSQL.Append(" FROM " & NameOf(MODEL.V002_FUTEKIGO_HOKOKU_J) & " ")
            sbSQL.Append(" WHERE HOKOKU_NO='" & dr.Item("HOKOKUSYO_NO") & "'")
            Using DBa As ClsDbUtility = DBOpen()
                dsList = DBa.GetDataSet(sbSQL.ToString, conblnNonMsg)
            End Using

            With dsList.Tables(0).Rows(0)

                '�񍐏�No
                mtxHOKUKO_NO.Text = .Item("")
                '�N����
                mtxADD_SYAIN_NAME.Text = .Item("")
                '�N����
                dtDraft.Text = .Item("")
                '�@��
                cmbKISYU.SelectedValue = .Item("")
                '���i�ԍ�
                cmbBUHIN_BANGO.SelectedValue = .Item("")
                '���i����
                mtxHINMEI.Text = .Item("")
                '���@
                mtxGOUKI.Text = .Item("")
                '��
                numSU.Value = .Item("")
                '�Ĕ�
                chkSAIHATU.Checked = CBool(.Item(""))

                '��ԋ敪
                cmbFUTEKIGO_STATUS.SelectedValue = .Item("")
                '�ԋp���̏ꍇ
                cmbFUTEKIGO_KB.SelectedValue = .Item("")
                '�ۗ����R
                mtxHENKYAKU.Text = .Item("")
                '�}��/�K�i
                mtxZUBAN_KIKAKU.Text = .Item("")
            End With

            Return True
        Catch ex As Exception
            EM.ErrorSyori(ex, False, conblnNonMsg)
            Return False
        End Try
    End Function

#End Region

#Region "�^�u�R���g���[������"

#Region "������"
    Private Function FunInitializeTabControl(ByVal intSTAGE As Integer) As Boolean

        Try
            _tabPageManager = New TabPageManager(TabSTAGE)

            For Each page As TabPage In TabSTAGE.TabPages
                If page.Name <> "tabAttachment" Then
                    If Val(page.Name.Substring(8)) < intSTAGE Then
                        'SPEC: 10-2.�B
                        page.Text = tblNCR.AsEnumerable.Where(Function(r) r.Field(Of String)("VALUE") = PrDataRow("SYONIN_JUN")).FirstOrDefault.Item("DISP")
                    ElseIf Val(page.Name.Substring(8)) = intSTAGE Then
                        page.Text = "���X�e�[�W" 'tblNCR.AsEnumerable.Where(Function(r) r.Field(Of String)("VALUE") = PrDataRow("SYONIN_JUN")).FirstOrDefault.Item("DISP")
                        'SPEC: 10-2.�C
                        TabSTAGE.SelectedIndex = page.TabIndex
                    ElseIf Val(page.Name.Substring(8)) > intSTAGE Then
                        'SPEC: 10-2 �A
                        _tabPageManager.ChangeTabPageVisible(page.TabIndex, False)
                    End If

                    'SPEC: 10-2.�D
                    page.Enabled = FunblnOwnCreated(ENM_SYONIN_HOKOKU_ID._1_NCR, PrDataRow("HOKOKUSYO_NO"), PrDataRow("SYONIN_JUN"))
                End If
            Next page

            'mtxST01_NextStageName.Text = FunGetNextStageName(ENM_NCR_STAGE._10_�N������)
            'mtxST02_NextStageName.Text = FunGetNextStageName(ENM_NCR_STAGE._20_�N���m�F����GL)
            'mtxST03_NextStageName.Text = FunGetNextStageName(ENM_NCR_STAGE._30_�N���m�F����)
            'mtxST04_NextStageName.Text = FunGetNextStageName(ENM_NCR_STAGE._40_���O�R������y��CAR�v�۔���)
            'mtxST05_NextStageName.Text = FunGetNextStageName(ENM_NCR_STAGE._50_���O�R���m�F)
            'mtxST06_NextStageName.Text = FunGetNextStageName(ENM_NCR_STAGE._61_�ĐR�R������_�i�ؑ�\)
            'mtxST07_NextStageName.Text = FunGetNextStageName(ENM_NCR_STAGE._70_�ڋq�ĐR���u_I_tag)
            'mtxST08_NextStageName.Text = FunGetNextStageName(ENM_NCR_STAGE._83_���u���{_����)
            'mtxST09_NextStageName.Text = FunGetNextStageName(ENM_NCR_STAGE._90_���u���{�m�F_�Ǘ�T)
            'mtxST10_NextStageName.Text = FunGetNextStageName(ENM_NCR_STAGE._100_���u���{����_�����ے�)
            'mtxST11_NextStageName.Text = FunGetNextStageName(ENM_NCR_STAGE._110_abcde���u�S��)

            Return True
        Catch ex As Exception
            EM.ErrorSyori(ex, False, conblnNonMsg)
            Return False
        End Try
    End Function

#End Region

#Region "STAGE�ʃR���g���[��������"
    Private Function FunInitializeSTAGE(ByVal intStageID As Integer) As Boolean

        Try

            Select Case intStageID
#Region "               10"
                Case ENM_NCR_STAGE._10_�N������
                    Dim dt As DataTable = tblTANTO_SYONIN.AsEnumerable.
                                            Where(Function(r) r.Field(Of Integer)("SYONIN_HOKOKUSYO_ID") = 1 And r.Field(Of Integer)("SYONIN_JUN") = FunGetNextSYONIN_JUN(intStageID)).
                                            CopyToDataTable

                    mtxST01_UPD_YMD.Text = Today.ToString("yyyy/MM/dd")
                    mtxST01_NextStageName.Text = FunGetNextStageName(intStageID)
                    cmbST01_DestTANTO.SetDataSource(dt, ENM_COMBO_SELECT_VALUE_TYPE._0_Required)

#End Region
#Region "               20"
                Case ENM_NCR_STAGE._20_�N���m�F����GL
                    Dim dt As DataTable = tblTANTO_SYONIN.AsEnumerable.
                                            Where(Function(r) r.Field(Of Integer)("SYONIN_HOKOKUSYO_ID") = 1 And r.Field(Of Integer)("SYONIN_JUN") = FunGetNextSYONIN_JUN(intStageID)).
                                            CopyToDataTable

                    mtxST02_UPD_YMD.Text = Today.ToString("yyyy/MM/dd")
                    mtxST02_NextStageName.Text = FunGetNextStageName(intStageID)
                    cmbST02_DestTANTO.SetDataSource(dt, ENM_COMBO_SELECT_VALUE_TYPE._0_Required)

#End Region
#Region "               30"
                Case ENM_NCR_STAGE._30_�N���m�F����
                    Dim dt As DataTable = tblTANTO_SYONIN.AsEnumerable.
                                            Where(Function(r) r.Field(Of Integer)("SYONIN_HOKOKUSYO_ID") = 1 And r.Field(Of Integer)("SYONIN_JUN") = FunGetNextSYONIN_JUN(intStageID)).
                                            CopyToDataTable

                    mtxST03_UPD_YMD.Text = Today.ToString("yyyy/MM/dd")
                    mtxST03_NextStageName.Text = FunGetNextStageName(intStageID)
                    cmbST03_DestTANTO.SetDataSource(dt, ENM_COMBO_SELECT_VALUE_TYPE._0_Required)

#End Region
#Region "               40"
                Case ENM_NCR_STAGE._40_���O�R������y��CAR�v�۔���
                    Dim dt As DataTable = tblTANTO_SYONIN.AsEnumerable.
                                            Where(Function(r) r.Field(Of Integer)("SYONIN_HOKOKUSYO_ID") = 1 And r.Field(Of Integer)("SYONIN_JUN") = FunGetNextSYONIN_JUN(intStageID)).
                                            CopyToDataTable

                    mtxST04_UPD_YMD.Text = Today.ToString("yyyy/MM/dd")
                    mtxST04_NextStageName.Text = FunGetNextStageName(intStageID)
                    cmbST04_DestTANTO.SetDataSource(dt, ENM_COMBO_SELECT_VALUE_TYPE._0_Required)

                    cmbST04_ZIZENSINSA_HANTEI.SetDataSource(tblJIZEN_SINSA_HANTEI_KB.ExcludeDeleted, ENM_COMBO_SELECT_VALUE_TYPE._0_Required)

#End Region
#Region "               50"
                Case ENM_NCR_STAGE._50_���O�R���m�F
                    Dim dt As DataTable = tblTANTO_SYONIN.AsEnumerable.
                                        Where(Function(r) r.Field(Of Integer)("SYONIN_HOKOKUSYO_ID") = 1 And r.Field(Of Integer)("SYONIN_JUN") = FunGetNextSYONIN_JUN(intStageID)).
                                        CopyToDataTable

                    mtxST05_UPD_YMD.Text = Today.ToString("yyyy/MM/dd")
                    mtxST05_NextStageName.Text = FunGetNextStageName(intStageID)
                    cmbST05_DestTANTO.SetDataSource(dt, ENM_COMBO_SELECT_VALUE_TYPE._0_Required)

#End Region
#Region "               60"
                Case ENM_NCR_STAGE._60_�ĐR�R������_�Z�p��\, ENM_NCR_STAGE._61_�ĐR�R������_�i�ؑ�\
                    Dim dt As DataTable = tblTANTO_SYONIN.AsEnumerable.
                                        Where(Function(r) r.Field(Of Integer)("SYONIN_HOKOKUSYO_ID") = 1 And r.Field(Of Integer)("SYONIN_JUN") = FunGetNextSYONIN_JUN(intStageID)).
                                        CopyToDataTable

                    mtxST06_UPD_YMD.Text = Today.ToString("yyyy/MM/dd")
                    mtxST06_NextStageName.Text = FunGetNextStageName(intStageID)
                    cmbST06_DestTANTO.SetDataSource(dt, ENM_COMBO_SELECT_VALUE_TYPE._0_Required)

                    cmbST06_SAISIN_IINKAI_HANTEI.SetDataSource(tblSAISIN_IINKAI_HANTEI_KB.ExcludeDeleted, ENM_COMBO_SELECT_VALUE_TYPE._0_Required)

#End Region
#Region "               70"
                Case ENM_NCR_STAGE._70_�ڋq�ĐR���u_I_tag
#End Region
#Region "               80"
                Case ENM_NCR_STAGE._80_���u���{
                Case ENM_NCR_STAGE._81_���u���{_���Z
                Case ENM_NCR_STAGE._82_���u���{_����
                Case ENM_NCR_STAGE._83_���u���{_����
#End Region
#Region "               90"
                Case ENM_NCR_STAGE._90_���u���{�m�F_�Ǘ�T
#End Region
#Region "               100"
                Case ENM_NCR_STAGE._100_���u���{����_�����ے�
#End Region
#Region "               110"
                Case ENM_NCR_STAGE._110_abcde���u�S��
#End Region
#Region "               120"
                Case ENM_NCR_STAGE._120_abcde���u�m�F
#End Region

                Case Else

            End Select

            Return True
        Catch ex As Exception
            EM.ErrorSyori(ex, False, conblnNonMsg)
            Return False
        End Try
    End Function

#End Region

#End Region

#Region "FunctionButton�֘A"

#Region "�{�^���N���b�N�C�x���g"

    Private Sub CmdFunc_Click(ByVal sender As Object, ByVal e As EventArgs) Handles cmdFunc1.Click, cmdFunc2.Click, cmdFunc3.Click, cmdFunc4.Click, cmdFunc5.Click, cmdFunc6.Click, cmdFunc7.Click, cmdFunc8.Click, cmdFunc9.Click, cmdFunc10.Click, cmdFunc11.Click, cmdFunc12.Click
        Dim intFUNC As Integer
        Dim intCNT As Integer

        Try
            '[������]
            Me.PrPG_STATUS = ENM_PG_STATUS._3_PROCESSING

            '�{�^���s��/�{�^��INDEX�擾
            For intCNT = 0 To Me.cmdFunc.Length - 1
                Me.cmdFunc(intCNT).Enabled = False
                If cmdFunc(intCNT) Is sender Then intFUNC = intCNT + 1
            Next

            '�{�^��INDEX���̏���
            Select Case intFUNC
                Case 1  '�ۑ�
                    If MessageBox.Show("���͓��e��ۑ����܂����H", "�o�^�m�F", MessageBoxButtons.YesNo, MessageBoxIcon.Information) = DialogResult.Yes Then
                        If FunSAVE() Then
                            Me.DialogResult = DialogResult.OK
                            MessageBox.Show("���͓��e��ۑ����܂���", "�ۑ�����", MessageBoxButtons.OK, MessageBoxIcon.Information)
                        End If
                    End If

                Case 2  '���F�\��
                    If MessageBox.Show("�\�����܂����H", "�\�������m�F", MessageBoxButtons.YesNo, MessageBoxIcon.Information) = DialogResult.Yes Then
                        If FunREQUEST() Then
                            MessageBox.Show("�\�����܂���", "�\����������", MessageBoxButtons.OK, MessageBoxIcon.Information)
                            Me.DialogResult = DialogResult.OK
                            Me.Close()
                        End If
                    End If

                Case 4  '�]��
                    MessageBox.Show("������", "", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Case 5  '���߂�
                    MessageBox.Show("������", "", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Case 9  'CAR�ҏW
                    Call OpenFormCAR()
                    'Dim strFileName As String = pub_APP_INFO.strTitle & "_" & DateTime.Today.ToString("yyyyMMdd") & ".CSV"
                    'Call FunCSV_OUT(Me.dgvDATA.DataSource, strFileName, pub_APP_INFO.strOUTPUT_PATH)

                Case 10  '���|�[�g���
                    MessageBox.Show("������", "", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Case 11 '����\��
                    MessageBox.Show("������", "", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Case 12 '����
                    Me.Close()
            End Select
        Catch ex As Exception
            EM.ErrorSyori(ex, False, conblnNonMsg)
        Finally
            '�{�^����
            System.Windows.Forms.Application.DoEvents()
            For intCNT = 0 To Me.cmdFunc.Length - 1
                Me.cmdFunc(intCNT).Enabled = True
            Next

            '�t�@���N�V�����L�[�L����������
            Call FunInitFuncButtonEnabled()

            '[�A�N�e�B�u]
            Me.PrPG_STATUS = ENM_PG_STATUS._2_ACTIVE
        End Try

    End Sub

#End Region

#Region "�ۑ�"
    Private Function FunSAVE() As Boolean
        Dim dsList As New DataSet
        Dim sbSQL As New System.Text.StringBuilder


        Try
            '-----���̓`�F�b�N
            If FunCheckInput() = False Then
                Return False
            End If

            '���݃`�F�b�N
            'If PrDt.AsEnumerable.Where(Function(r) r.Field(Of Integer)("HOKOKUSYO_NO") = 18011).ToList.Count = 0 Then
            '    Dim dr As DataRow = PrDt.NewRow
            '    Dim intNextHOKOKUSYO_NO As Integer
            '    Using DB As ClsDbUtility = DBOpen()
            '        intNextHOKOKUSYO_NO = FunGetCodeMastaValue(DB, "�񍐏�NO�Ǘ�", "1")
            '    End Using

            '    'dr("HOKOKUSYO_NO") = intNextHOKOKUSYO_NO
            '    'dr("CLOSE_FLG") = "0"
            '    'dr("SYONIN_JUN") = 10
            '    'dr("SYONIN_NAIYO") = mtxST01_NextStageName.Text.Split(" ")(1)
            '    'dr("SYONIN_HOKOKUSYO_ID") = "1"
            '    'dr("SYONIN_HOKOKUSYO_NAME") = "�s�K�����i���u�񍐏�"
            '    'dr("SYONIN_HOKOKUSYO_R_NAME") = "NCR"
            '    'dr("SYOCHI_SYAIN_ID") = pub_SYAIN_INFO.SYAIN_ID
            '    'dr("SYOCHI_SYAIN_NAME") = pub_SYAIN_INFO.SYAIN_NAME
            '    'dr("TAIRYU") = 0
            '    'dr("KISYU_ID") = ""
            '    'dr("KISYU") = ""
            '    'dr("KISYU_NAME") = ""
            '    'dr("BUHIN_BANGO") = ""
            '    'dr("BUHIN_NAME") = ""
            '    'dr("JIZEN_SINSA_HANTEI_KB") = ""
            '    'dr("JIZEN_SINSA_HANTEI_KB_DISP") = ""
            '    'dr("SAISIN_IINKAI_HANTEI_KB") = ""
            '    'dr("SAISIN_IINKAI_HANTEI_KB_DISP") = ""
            '    'dr("ADD_YMD") = dtDraft.ValueDate.ToString("yyyyMMdd")
            '    'dr("SYOCHI_YMD") = " "
            '    'dr("MODOSI_SYONIN_JUN") = 0
            '    'dr("MODOSI_SYONIN_NAIYO") = ""
            '    'dr("MODOSI_RIYU") = ""
            '    'dr("MODOSI_TAIRYU") = 6
            '    'PrDt.Rows.Add(dr)
            'Else

            'End If

            'Using DB As ClsDbUtility = DBOpen()
            '    Dim intRET As Integer
            '    Dim sqlEx As New Exception
            '    Dim blnErr As Boolean

            '    Try
            '        DB.BeginTransaction()

            '        ''-----���݃`�F�b�N
            '        'sbSQL.Remove(0, sbSQL.Length)
            '        'sbSQL.Append("SELECT * FROM " & NameOf(MODEL.M001_SETTING) & "")
            '        'sbSQL.Append(" WHERE ITEM_NAME ='" & Me.cmbKOMO_NM.Text.Trim & "' ")
            '        'sbSQL.Append(" AND ITEM_VALUE ='" & Me.mtxVALUE.Text.Trim & "' ")
            '        'dsList = DB.GetDataSet(sbSQL.ToString, conblnNonMsg)
            '        'If dsList.Tables(0).Rows.Count > 0 Then '���ݎ�
            '        '    MessageBox.Show("���ɓo�^�ς݂̃f�[�^�ł��B" & vbCrLf & "���̓f�[�^���m�F���ĉ������B", "���݃`�F�b�N", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            '        '    Return False
            '        'End If


            '        '-----INSERT
            '        'sbSQL.Remove(0, sbSQL.Length)
            '        'sbSQL.Append("INSERT INTO " & NameOf(MODEL.D003_NCR_J) & " ")
            '        'sbSQL.Append(" VALUES ( ")
            '        ''���ڃO���[�v
            '        'sbSQL.Append(" '" & Me.mtxKOMO_GROUP.Text.Trim & "'")
            '        ''���ږ�
            '        'sbSQL.Append(" ,'" & Me.cmbKOMO_NM.Text.Trim & "'")
            '        ''���ڒl
            '        'sbSQL.Append(" ,'" & Me.mtxVALUE.Text.Trim & "'")
            '        ''�\���l
            '        'sbSQL.Append(" ,'" & Nz(Me.mtxDISP.Text.Trim, " ") & "'")
            '        ''�\����
            '        'sbSQL.Append(" ," & Me.cmbJYUN.SelectedValue & "")
            '        ''����l�t���O
            '        'sbSQL.Append(" ,'" & IIf(Me.chkDefaultVaue.Checked = True, "1", "0") & "'")
            '        ''���l
            '        'sbSQL.Append(" ,'" & Nz(Me.mtxBIKOU.Text.Trim, " ") & "'")
            '        ''�ǉ�����
            '        'sbSQL.Append(" ,dbo.GetSysDateString()")
            '        ''�ǉ�����
            '        'sbSQL.Append(" ," & pub_SYAIN_INFO.SYAIN_ID & "")
            '        ''�ǉ��S����
            '        'sbSQL.Append(" ,dbo.GetSysDateString()")
            '        ''�X�V�S����
            '        'sbSQL.Append(" ," & pub_SYAIN_INFO.SYAIN_ID & "")
            '        ''�폜����
            '        'sbSQL.Append(" ,' '")
            '        ''�폜�S����
            '        'sbSQL.Append(" ,0")
            '        'sbSQL.Append(" )")

            '        intRET = DB.ExecuteNonQuery(sbSQL.ToString, conblnNonMsg, sqlEx)
            '        If intRET <> 1 Then
            '            '�G���[���O�o��
            '            Dim strErrMsg As String = My.Resources.ErrLogSqlExecutionFailure & sbSQL.ToString & "|" & sqlEx.Message
            '            WL.WriteLogDat(strErrMsg)
            '            blnErr = True
            '            Return False
            '        End If
            '    Finally
            '        '�g�����U�N�V����
            '        DB.Commit(Not blnErr)
            '    End Try
            'End Using

            Return True
        Catch ex As Exception
            Throw
            Return False
        Finally
            dsList.Dispose()
        End Try
    End Function
#End Region

#Region "�\��"
    Private Function FunREQUEST() As Boolean
        Dim sbSQL As New System.Text.StringBuilder
        Dim dsList As New System.Data.DataSet

        Try



            '���̓`�F�b�N
            If FunCheckInput() = False Then
                Return False
            End If

            Using DB As ClsDbUtility = DBOpen()
                Dim intRET As Integer
                Dim sqlEx As Exception = Nothing
                Dim blnErr As Boolean

                Try
                    '�g�����U�N�V����
                    DB.BeginTransaction()

                    ''-----���݃`�F�b�N
                    'sbSQL.Append("SELECT * FROM " & NameOf(MODEL.M001_SETTING) & " ")
                    'sbSQL.Append("WHERE")
                    'sbSQL.Append(" ITEM_NAME ='" & Me.cmbKOMO_NM.Text.Trim & "' ")
                    'sbSQL.Append(" AND ITEM_VALUE ='" & Me.mtxVALUE.Text.Trim & "' ")
                    'sbSQL.Append(" AND UPD_YMDHNS ='" & PrDataRow.Item("UPD_YMDHNS").ToString & "' ")
                    'dsList = DB.GetDataSet(sbSQL.ToString)
                    'If dsList.Tables(0).Rows.Count = 0 Then '�񑶍ݎ�
                    '    MessageBox.Show(String.Format(My.Resources.infoSearchDataChange), My.Resources.infoTilteDuplicateCheck, MessageBoxButtons.OK, MessageBoxIcon.Information)
                    '    Return False
                    'End If

                    '-----UPDATE(�\�����ȊO)
                    'sbSQL.Remove(0, sbSQL.Length)
                    'sbSQL.Append("UPDATE " & NameOf(MODEL.M001_SETTING) & " SET")
                    'sbSQL.Append(" ITEM_DISP ='" & Me.mtxDISP.Text.Trim & "'")
                    'sbSQL.Append(" ,DEF_FLG ='" & IIf(Me.chkDefaultVaue.Checked = True, "1", "0") & "'")
                    'sbSQL.Append(" ,BIKOU ='" & Me.mtxBIKOU.Text.Trim & "'")
                    'sbSQL.Append(" ,UPD_SYAIN_ID = " & pub_SYAIN_INFO.SYAIN_ID)
                    'sbSQL.Append(" ,UPD_YMDHNS = dbo.GetSysDateString()")
                    'sbSQL.Append("WHERE")
                    'sbSQL.Append(" ITEM_NAME ='" & Me.cmbKOMO_NM.Text.Trim & "' ")
                    'sbSQL.Append(" AND ITEM_VALUE ='" & Me.mtxVALUE.Text.Trim & "' ")

                    intRET = DB.ExecuteNonQuery(sbSQL.ToString, conblnNonMsg, sqlEx)
                    If intRET <> 1 Then
                        '�G���[���O
                        Dim strErrMsg As String = My.Resources.ErrLogSqlExecutionFailure & sbSQL.ToString & "|" & sqlEx.Message
                        WL.WriteLogDat(strErrMsg)
                        blnErr = True
                        Return False
                    End If
                Finally
                    '�g�����U�N�V����
                    DB.Commit(Not blnErr)
                End Try
            End Using

            Return True
        Catch ex As Exception
            Throw
            Return False
        Finally
            dsList.Dispose()
        End Try
    End Function
#End Region

#Region "CAR"
    Private Function OpenFormCAR() As Boolean
        Dim frmDLG As New FrmG0012
        Dim dlgRET As DialogResult
        'Dim PKeys As String

        Try


            dlgRET = frmDLG.ShowDialog(Me)


            If dlgRET = Windows.Forms.DialogResult.Cancel Then
                Return False
            Else
                '�ǉ��I���s�I��
            End If


            Return True
        Catch ex As Exception
            EM.ErrorSyori(ex, False, conblnNonMsg)
            Return False
        Finally
            If frmDLG IsNot Nothing Then
                frmDLG.Dispose()
            End If
        End Try
    End Function

#End Region

#Region "���̓`�F�b�N"
    Public Function FunCheckInput() As Boolean
        Try

            '���ږ�
            'If cmbKOMO_NM.Text.IsNullOrWhiteSpace Then
            '    MessageBox.Show(String.Format(My.Resources.infoMsgRequireSelectOrInput, "���ږ�"), My.Resources.infoTitleInputCheck, MessageBoxButtons.OK, MessageBoxIcon.Information)
            '    Me.cmbKOMO_NM.Focus()
            '    Return False
            'End If

            ''���ڒl
            'If Me.mtxVALUE.Text.IsNullOrWhiteSpace Then
            '    MessageBox.Show(String.Format(My.Resources.infoMsgRequireInput, "���ڒl"), My.Resources.infoTitleInputCheck, MessageBoxButtons.OK, MessageBoxIcon.Information)
            '    Me.mtxVALUE.Focus()
            '    Return False
            'End If

            Return True
        Catch ex As Exception
            EM.ErrorSyori(ex, False, conblnNonMsg)
            Return False
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
                With Me.Controls("cmdFunc" & intFunc)
                    If .Text.Length = 0 OrElse .Text.Substring(0, .Text.IndexOf("(")).IsNullOrWhiteSpace Then
                        .Text = ""
                        .Visible = False
                    End If
                End With
            Next intFunc

            If PrMODE = ENM_DATA_OPERATION_MODE._1_ADD Then
                cmdFunc4.Enabled = False
                cmdFunc5.Enabled = False
                cmdFunc9.Enabled = False
                cmdFunc10.Enabled = False
                cmdFunc11.Enabled = False
            Else
                cmdFunc4.Enabled = True
                cmdFunc5.Enabled = True
                cmdFunc9.Enabled = True
                cmdFunc10.Enabled = True
                cmdFunc11.Enabled = True
            End If


            'UNDONE: ���[�U�[�����ɂ�鐧��

            Return True
        Catch ex As Exception
            EM.ErrorSyori(ex, False, conblnNonMsg)
            Return False
        End Try
    End Function

#End Region

#End Region

#Region "�R���g���[���C�x���g"

    '�����t�B���^�ύX
    Private Sub SearchFilterValueChanged(sender As System.Object, e As System.EventArgs)
        '����
        Me.cmdFunc1.PerformClick()

    End Sub

    Private Sub CmbFUTEKIGO_STATUS_SelectedValueChanged(sender As Object, e As EventArgs) Handles cmbFUTEKIGO_STATUS.SelectedValueChanged
        'If cmbFUTEKIGO_STATUS.SelectedValue = 1 Then

        'End If
    End Sub

#Region "STAGE��"

#Region "   STAGE1"

#End Region
#Region "   STAGE2"

#End Region
#Region "   STAGE3"

#End Region
#Region "   STAGE4"
    Private Sub rbtnST04_ZESEI_YES_CheckedChanged(sender As Object, e As EventArgs) Handles rbtnST04_ZESEI_YES.CheckedChanged
        If rbtnST04_ZESEI_YES.Checked Then
            lbltxtST04_RIYU.Visible = False
            txtST04_RIYU.Visible = False
        Else
            lbltxtST04_RIYU.Visible = True
            txtST04_RIYU.Visible = True
        End If
    End Sub

#End Region
#Region "   STAGE5"

#End Region
#Region "   STAGE6"

#End Region
#Region "   STAGE7"

#End Region
#Region "   STAGE8"

#End Region
#Region "   STAGE9"

#End Region
#Region "   STAGE10"

#End Region
#Region "   STAGE11"

#End Region
#Region "   STAGE12"

#End Region
#Region "�Y�t����"

    '�Y�t�t�@�C���I��
    Private Sub BtnOpenTempFileDialog_Click(sender As Object, e As EventArgs) Handles btnOpenTempFileDialog.Click
        Dim ofd As New OpenFileDialog With {
            .Filter = "Excel(*.xls;*.xlsx)|*.xls;*.xlsx|Word(*.doc;*.docx)|*.doc;*.docx|���ׂẴt�@�C��(*.*)|*.*",
            .FilterIndex = 1,
            .Title = "�Y�t����t�@�C����I�����Ă�������",
            .RestoreDirectory = True
        }
        If lbltmpFile1.Links.Count = 0 Then
        Else
            ofd.InitialDirectory = IO.Path.GetDirectoryName(lbltmpFile1.Links(0).ToString)
        End If
        If ofd.ShowDialog() = DialogResult.OK Then
            lbltmpFile1.Text = IO.Path.GetFileName(ofd.FileName)
            lbltmpFile1.Links.Add(0, lbltmpFile1.Text.Length, ofd.FileName)
            lbltmpFile1.Visible = True
            lbltmpFile1_Clear.Visible = True
        End If
    End Sub

    '�����N�N���b�N
    Private Sub LbltmpFile1_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles lbltmpFile1.LinkClicked
        Dim hProcess As New System.Diagnostics.Process
        Dim strEXE As String
        'Dim strARG As String
        Try

            strEXE = lbltmpFile1.Links(0).LinkData
            If strEXE.IsNullOrWhiteSpace Then
            Else
                If System.IO.File.Exists(strEXE) = True Then
                    hProcess.StartInfo.FileName = strEXE
                    'hProcess.StartInfo.Arguments = strARG
                    hProcess.SynchronizingObject = Me
                    'AddHandler hProcess.Exited, AddressOf ProcessExited
                    hProcess.EnableRaisingEvents = True
                    hProcess.Start()

                    '�őO��
                    Call SetForegroundWindow(hProcess.Handle)

                    'Call SetTaskbarInfo(ENM_TASKBAR_STATE._2_Normal, 100)
                    'Call SetTaskbarOverlayIcon(System.Drawing.SystemIcons.Application)
                Else
                    Dim strMsg As String
                    strMsg = "�t�@�C����������܂���B" & vbCrLf & "�V�X�e���Ǘ��҂ɂ��A���������B" &
                                vbCrLf & vbCrLf & strEXE
                    MessageBox.Show(strMsg, My.Application.Info.AssemblyName, MessageBoxButtons.OK, MessageBoxIcon.Information)
                End If
            End If
        Catch exInvalid As InvalidOperationException
            'EM.ErrorSyori(exInvalid, False, conblnNonMsg)
        Finally
            '�v���Z�X�I����ҋ@���Ȃ�------------------------------------
            ''-----�����\��
            'Me.Show()
            'Me.lstGYOMU.Focus()
            'Me.Activate()
            'Me.BringToFront()
            '------------------------------------------------------------

            '-----�J��
            If hProcess IsNot Nothing Then
                hProcess.Close()
            End If
        End Try
    End Sub

    '�����N�N���A
    Private Sub LbltmpFile1_Clear_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles lbltmpFile1_Clear.LinkClicked
        lbltmpFile1.Text = ""
        lbltmpFile1.Links.Clear()
        lbltmpFile1.Visible = False
        lbltmpFile1_Clear.Visible = False
    End Sub

    Private Sub ProcessExited(ByVal sender As Object, ByVal e As EventArgs)
        'Call SetTaskbarOverlayIcon(Nothing)
        'Call SetTaskbarInfo(ENM_TASKBAR_STATE._0_NoProgress)
    End Sub

#Region "�摜1"

    '�摜1�I��
    Private Sub BtnOpenPict1Dialog_Click(sender As Object, e As EventArgs) Handles btnOpenPict1Dialog.Click
        Dim ofd As New OpenFileDialog With {
         .Filter = "�摜(*.bmp;*.gif;*.jpg;*.png)|*.bmp;*.gif;*.jpg;*.png",
         .FilterIndex = 1,
         .Title = "�Y�t����摜�t�@�C����I�����Ă�������",
         .RestoreDirectory = True
        }
        If mtxPict1Path.Tag Is Nothing OrElse mtxPict1Path.Tag.ToString.IsNullOrWhiteSpace Then
        Else
            ofd.InitialDirectory = IO.Path.GetDirectoryName(mtxPict1Path.Tag)
        End If

        If ofd.ShowDialog() = DialogResult.OK Then
            Call SetPict1Data(ofd.FileName)
        End If
    End Sub

    '�摜1�N���b�N
    Private Sub PnlPict1_Click(sender As Object, e As EventArgs) Handles pnlPict1.Click
        If pnlPict1.Image IsNot Nothing Then
            picZoom.Image = pnlPict1.Image
            picZoom.BringToFront()
            picZoom.Visible = True
        End If
    End Sub

    Private Sub PnlPict1_DragEnter(sender As Object, e As DragEventArgs) Handles pnlPict1.DragEnter
        '�h���b�O���ꂽ�f�[�^�`���𒲂ׁA�t�@�C���̂Ƃ��̓R�s�[�Ƃ���
        If e.Data.GetDataPresent(DataFormats.FileDrop) Then
            e.Effect = DragDropEffects.Copy
        Else
            e.Effect = DragDropEffects.None
        End If
    End Sub

    Private Sub PnlPict1_DragDrop(sender As Object, e As DragEventArgs) Handles pnlPict1.DragDrop
        Call SetPict1Data(e.Data.GetData(DataFormats.FileDrop, False))
    End Sub

    Private Sub MtxPict1Path_DragEnter(sender As Object, e As DragEventArgs) Handles mtxPict1Path.DragEnter
        '�h���b�O���ꂽ�f�[�^�`���𒲂ׁA�t�@�C���̂Ƃ��̓R�s�[�Ƃ���
        If e.Data.GetDataPresent(DataFormats.FileDrop) Then
            e.Effect = DragDropEffects.Copy
        Else
            e.Effect = DragDropEffects.None
        End If
    End Sub

    Private Sub MtxPict1Path_DragDrop(sender As Object, e As DragEventArgs) Handles mtxPict1Path.DragDrop
        Call SetPict1Data(CType(e.Data.GetData(DataFormats.FileDrop, False), String())(0))
    End Sub

    Private Sub SetPict1Data(ByVal strFileName As String)
        mtxPict1Path.Text = CompactString(strFileName, mtxPict1Path, EllipsisFormat._4_Path)
        mtxPict1Path.Tag = strFileName
        pnlPict1.Image = Image.FromFile(strFileName)
        pnlPict1.Cursor = Cursors.Hand
    End Sub

#End Region

#Region "�摜2"

    '�摜2�I��
    Private Sub BtnOpenPict2Dialog_Click(sender As Object, e As EventArgs) Handles btnOpenPict2Dialog.Click
        Dim ofd As New OpenFileDialog With {
            .Filter = "�摜(*.bmp;*.gif;*.jpg;*.png)|*.bmp;*.gif;*.jpg;*.png",
            .FilterIndex = 1,
            .Title = "�Y�t����摜�t�@�C����I�����Ă�������",
            .RestoreDirectory = True
        }
        If mtxPict2Path.Tag Is Nothing OrElse mtxPict2Path.Tag.ToString.IsNullOrWhiteSpace Then
        Else
            ofd.InitialDirectory = IO.Path.GetDirectoryName(mtxPict2Path.Tag)
        End If

        If ofd.ShowDialog() = DialogResult.OK Then
            mtxPict2Path.Text = CompactString(ofd.FileName, mtxPict2Path, EllipsisFormat._4_Path)
            mtxPict2Path.Tag = ofd.FileName
            pnlPict2.Image = Image.FromFile(ofd.FileName)
            pnlPict2.Cursor = Cursors.Hand
        End If
    End Sub

    '�摜2�N���b�N
    Private Sub PnlPict2_Click(sender As Object, e As EventArgs) Handles pnlPict2.Click
        If pnlPict2.Image IsNot Nothing Then
            picZoom.Image = pnlPict2.Image
            picZoom.BringToFront()
            picZoom.Visible = True
        End If
    End Sub

    Private Sub PnlPict2_DragEnter(sender As Object, e As DragEventArgs) Handles pnlPict2.DragEnter
        '�h���b�O���ꂽ�f�[�^�`���𒲂ׁA�t�@�C���̂Ƃ��̓R�s�[�Ƃ���
        If e.Data.GetDataPresent(DataFormats.FileDrop) Then
            e.Effect = DragDropEffects.Copy
        Else
            e.Effect = DragDropEffects.None
        End If
    End Sub

    Private Sub PnlPict2_DragDrop(sender As Object, e As DragEventArgs) Handles pnlPict2.DragDrop
        Call SetPict2Data(e.Data.GetData(DataFormats.FileDrop, False))
    End Sub

    Private Sub MtxPict2Path_DragEnter(sender As Object, e As DragEventArgs) Handles mtxPict2Path.DragEnter
        '�h���b�O���ꂽ�f�[�^�`���𒲂ׁA�t�@�C���̂Ƃ��̓R�s�[�Ƃ���
        If e.Data.GetDataPresent(DataFormats.FileDrop) Then
            e.Effect = DragDropEffects.Copy
        Else
            e.Effect = DragDropEffects.None
        End If
    End Sub

    Private Sub MtxPict2Path_DragDrop(sender As Object, e As DragEventArgs) Handles mtxPict2Path.DragDrop
        Call SetPict2Data(e.Data.GetData(DataFormats.FileDrop, False))
    End Sub

    Private Sub SetPict2Data(ByVal strFileName As String)
        mtxPict2Path.Text = CompactString(strFileName, mtxPict1Path, EllipsisFormat._4_Path)
        mtxPict2Path.Tag = strFileName
        pnlPict2.Image = Image.FromFile(strFileName)
        pnlPict2.Cursor = Cursors.Hand
    End Sub

#End Region

    '�g��摜�N���b�N
    Private Sub PicZoom_Click(sender As Object, e As EventArgs) Handles picZoom.Click
        picZoom.Image = Nothing
        picZoom.Visible = False
        picZoom.SendToBack()
    End Sub

#End Region

#End Region


#End Region

#Region "���[�J���֐�"

    ''' <summary>
    ''' ���X�e�[�W�����擾
    ''' </summary>
    ''' <param name="intCurrentStageID">���X�e�[�WID</param>
    ''' <returns></returns>
    Private Function FunGetNextStageName(ByVal intCurrentStageID As Integer) As String
        Try

            Dim drList As List(Of DataRow) = tblNCR.AsEnumerable().
                                                Where(Function(r) Val(r.Field(Of String)("VALUE")) > intCurrentStageID).ToList
            Dim strBUFF As String = ""
            If drList.Count > 0 Then
                strBUFF = drList(0).Item("DISP")
            End If

            Return strBUFF
        Catch ex As Exception
            EM.ErrorSyori(ex, False, conblnNonMsg)
            Return vbEmpty
        End Try
    End Function

    ''' <summary>
    ''' ���X�e�[�W�̏��F��No���擾
    ''' </summary>
    ''' <param name="intCurrentStageID">���X�e�[�WID</param>
    ''' <returns></returns>
    Private Function FunGetNextSYONIN_JUN(ByVal intCurrentStageID As Integer) As Integer
        Try

            Dim drList As List(Of DataRow) = tblNCR.AsEnumerable().
                                                Where(Function(r) Val(r.Field(Of String)("VALUE")) > intCurrentStageID).ToList
            Dim intBUFF As Integer
            If drList.Count > 0 Then
                intBUFF = Val(drList(0).Item("VALUE"))
            End If

            Return intBUFF
        Catch ex As Exception
            EM.ErrorSyori(ex, False, conblnNonMsg)
            Return 0
        End Try
    End Function

    ''' <summary>
    ''' ���F��No����Y������^�uNo���擾
    ''' </summary>
    ''' <param name="intSYONIN_JUN">���F��No</param>
    ''' <returns></returns>
    Private Function FunConvertSYONIN_JUN_TO_STAGE_NO(ByVal intSYONIN_JUN As Integer) As Integer
        Dim intBUFF As Integer
        Select Case intSYONIN_JUN
            Case ENM_NCR_STAGE._10_�N������
                intBUFF = 1
            Case ENM_NCR_STAGE._20_�N���m�F����GL
                intBUFF = 2
            Case ENM_NCR_STAGE._30_�N���m�F����
                intBUFF = 3
            Case ENM_NCR_STAGE._40_���O�R������y��CAR�v�۔���
                intBUFF = 4
            Case ENM_NCR_STAGE._50_���O�R���m�F
                intBUFF = 5
            Case ENM_NCR_STAGE._60_�ĐR�R������_�Z�p��\, ENM_NCR_STAGE._61_�ĐR�R������_�i�ؑ�\
                intBUFF = 6
            Case ENM_NCR_STAGE._70_�ڋq�ĐR���u_I_tag
                intBUFF = 7
            Case ENM_NCR_STAGE._80_���u���{, ENM_NCR_STAGE._81_���u���{_���Z, ENM_NCR_STAGE._82_���u���{_����, ENM_NCR_STAGE._83_���u���{_����
                intBUFF = 8
            Case ENM_NCR_STAGE._90_���u���{�m�F_�Ǘ�T
                intBUFF = 9
            Case ENM_NCR_STAGE._100_���u���{����_�����ے�
                intBUFF = 10
            Case ENM_NCR_STAGE._110_abcde���u�S��
                intBUFF = 11
            Case ENM_NCR_STAGE._120_abcde���u�m�F
                intBUFF = 12
            Case Else
                intBUFF = 15
        End Select

        Return intBUFF
    End Function


    ''' <summary>
    ''' ���O�C�����[�U�[�����For�\�������X�e�[�W������
    ''' </summary>
    ''' <param name="intHOKOKUSYO_ID">���F�񍐏�ID</param>
    ''' <param name="strHOKOKUSYO_NO">�񍐏�No</param>
    ''' <param name="intSYONIN_JUN">���F��No</param>
    ''' <returns></returns>
    Private Function FunblnOwnCreated(ByVal intHOKOKUSYO_ID As Integer, ByVal strHOKOKUSYO_NO As String, ByVal intSYONIN_JUN As Integer) As Boolean
        Dim sbSQL As New System.Text.StringBuilder
        Dim dsList As New DataSet
        sbSQL.Remove(0, sbSQL.Length)
        sbSQL.Append("SELECT")
        sbSQL.Append(" *")
        sbSQL.Append(" FROM D004_SYONIN_J_KANRI ")
        sbSQL.Append(" WHERE SYONIN_HOKOKUSYO_ID=" & intHOKOKUSYO_ID & "")
        sbSQL.Append(" AND HOKOKU_NO=" & intHOKOKUSYO_ID & "")
        sbSQL.Append(" AND SYONIN_JUN=" & intHOKOKUSYO_ID & "")
        sbSQL.Append(" AND SYAIN_ID=" & pub_SYAIN_INFO.SYAIN_ID & "")
        Using DBa As ClsDbUtility = DBOpen()
            dsList = DBa.GetDataSet(sbSQL.ToString, conblnNonMsg)
        End Using

        Return dsList.Tables(0).Rows.Count > 0

    End Function


    ''' <summary>
    ''' demo�p�S�^�u�Z�b�g
    ''' </summary>
    ''' <returns></returns>
    Private Function FunSetAllTabPages() As Boolean
        For i As Integer = 1 To 12
            _tabPageManager.ChangeTabPageVisible(i, True)
        Next
        Dim dt As DataTable = tblTANTO_SYONIN.AsEnumerable.
                                         Where(Function(r) r.Field(Of Integer)("SYONIN_HOKOKUSYO_ID") = 1 And r.Field(Of Integer)("SYONIN_JUN") = FunGetNextSYONIN_JUN(ENM_NCR_STAGE._10_�N������)).
                                         CopyToDataTable
        mtxST01_NextStageName.Text = FunGetNextStageName(ENM_NCR_STAGE._10_�N������)
        cmbST01_DestTANTO.SetDataSource(dt, ENM_COMBO_SELECT_VALUE_TYPE._0_Required)

        dt = tblTANTO_SYONIN.AsEnumerable.
                                         Where(Function(r) r.Field(Of Integer)("SYONIN_HOKOKUSYO_ID") = 1 And r.Field(Of Integer)("SYONIN_JUN") = FunGetNextSYONIN_JUN(ENM_NCR_STAGE._20_�N���m�F����GL)).
                                         CopyToDataTable
        'mtxST02_UPD_YMD.Text = Today.ToString("yyyy/MM/dd")
        mtxST02_NextStageName.Text = FunGetNextStageName(ENM_NCR_STAGE._20_�N���m�F����GL)
        cmbST02_DestTANTO.SetDataSource(dt, ENM_COMBO_SELECT_VALUE_TYPE._0_Required)

        dt = tblTANTO_SYONIN.AsEnumerable.
                                 Where(Function(r) r.Field(Of Integer)("SYONIN_HOKOKUSYO_ID") = 1 And r.Field(Of Integer)("SYONIN_JUN") = FunGetNextSYONIN_JUN(ENM_NCR_STAGE._30_�N���m�F����)).
                                 CopyToDataTable
        'mtxST03_UPD_YMD.Text = Today.ToString("yyyy/MM/dd")
        mtxST03_NextStageName.Text = FunGetNextStageName(ENM_NCR_STAGE._30_�N���m�F����)
        cmbST03_DestTANTO.SetDataSource(dt, ENM_COMBO_SELECT_VALUE_TYPE._0_Required)

        dt = tblTANTO_SYONIN.AsEnumerable.
                                      Where(Function(r) r.Field(Of Integer)("SYONIN_HOKOKUSYO_ID") = 1 And r.Field(Of Integer)("SYONIN_JUN") = FunGetNextSYONIN_JUN(ENM_NCR_STAGE._40_���O�R������y��CAR�v�۔���)).
                                      CopyToDataTable
        'mtxST04_UPD_YMD.Text = Today.ToString("yyyy/MM/dd")
        mtxST04_NextStageName.Text = FunGetNextStageName(ENM_NCR_STAGE._40_���O�R������y��CAR�v�۔���)
        cmbST04_DestTANTO.SetDataSource(dt, ENM_COMBO_SELECT_VALUE_TYPE._0_Required)
        cmbST04_ZIZENSINSA_HANTEI.SetDataSource(tblJIZEN_SINSA_HANTEI_KB.ExcludeDeleted, ENM_COMBO_SELECT_VALUE_TYPE._0_Required)

        dt = tblTANTO_SYONIN.AsEnumerable.
                                Where(Function(r) r.Field(Of Integer)("SYONIN_HOKOKUSYO_ID") = 1 And r.Field(Of Integer)("SYONIN_JUN") = FunGetNextSYONIN_JUN(ENM_NCR_STAGE._50_���O�R���m�F)).
                                CopyToDataTable
        'mtxST05_UPD_YMD.Text = Today.ToString("yyyy/MM/dd")
        mtxST05_NextStageName.Text = FunGetNextStageName(ENM_NCR_STAGE._50_���O�R���m�F)
        cmbST05_DestTANTO.SetDataSource(dt, ENM_COMBO_SELECT_VALUE_TYPE._0_Required)

        dt = tblTANTO_SYONIN.AsEnumerable.
                                   Where(Function(r) r.Field(Of Integer)("SYONIN_HOKOKUSYO_ID") = 1 And r.Field(Of Integer)("SYONIN_JUN") = FunGetNextSYONIN_JUN(ENM_NCR_STAGE._61_�ĐR�R������_�i�ؑ�\)).
                                   CopyToDataTable
        'mtxST06_UPD_YMD.Text = Today.ToString("yyyy/MM/dd")
        mtxST06_NextStageName.Text = FunGetNextStageName(ENM_NCR_STAGE._61_�ĐR�R������_�i�ؑ�\)
        cmbST06_DestTANTO.SetDataSource(dt, ENM_COMBO_SELECT_VALUE_TYPE._0_Required)
        cmbST06_SAISIN_IINKAI_HANTEI.SetDataSource(tblSAISIN_IINKAI_HANTEI_KB.ExcludeDeleted, ENM_COMBO_SELECT_VALUE_TYPE._0_Required)

        'mtxST07_UPD_YMD.Text = Today.ToString("yyyy/MM/dd")
        mtxST07_NextStageName.Text = FunGetNextStageName(ENM_NCR_STAGE._70_�ڋq�ĐR���u_I_tag)
        cmbST07_DestTANTO.SetDataSource(dt, ENM_COMBO_SELECT_VALUE_TYPE._0_Required)


        'DEBUG:
        Dim strTabNameList As New List(Of String)
        strTabNameList.Add("����� �q�v") '23
        strTabNameList.Add("���R �΋�") '31
        strTabNameList.Add("���R ���L") '21
        strTabNameList.Add("���c��") '157
        strTabNameList.Add("����G�H") '122
        strTabNameList.Add("���c��") '157
        strTabNameList.Add("���V�N�k") '
        strTabNameList.Add("�����q�v") '
        strTabNameList.Add("�� �ӌ�") '
        strTabNameList.Add("���c�����F") '
        strTabNameList.Add("���R ���L") '
        strTabNameList.Add("���R �΋�") '

        '�����ς݃X�e�[�W���̎擾
        For i As Integer = 1 To 12
            TabSTAGE.Controls("tabSTAGE" & i.ToString("00")).Visible = True
            TabSTAGE.Controls("tabSTAGE" & i.ToString("00")).Text = strTabNameList(i - 1)
        Next i

        cmbST01_DestTANTO.Text = strTabNameList(0)
        cmbST02_DestTANTO.Text = strTabNameList(1)
        cmbST03_DestTANTO.Text = strTabNameList(2)
        cmbST04_DestTANTO.Text = strTabNameList(3)
        cmbST05_DestTANTO.Text = strTabNameList(4)
        cmbST06_DestTANTO.Text = strTabNameList(5)
        cmbST07_DestTANTO.Text = strTabNameList(6)
        cmbST08_DestTANTO.Text = strTabNameList(7)
        cmbST09_DestTANTO.Text = strTabNameList(8)
        cmbST10_DestTANTO.Text = strTabNameList(9)
        cmbST11_DestTANTO.Text = strTabNameList(10)

    End Function

#End Region

End Class