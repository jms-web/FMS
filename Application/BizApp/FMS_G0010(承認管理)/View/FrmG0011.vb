Imports JMS_COMMON.ClsPubMethod


Public Class FrmG0011

#Region "�萔�E�ϐ�"
    ''' <summary>
    ''' �^�u��\���Ǘ��p
    ''' </summary>
    Private _tabPageManager As TabPageManager
    Private _tabPageManagerST08Sub As TabPageManager


    '80 NCR���u���{ �^�u�y�[�W
    Private Enum ENM_STAGE80_TABPAGES
        _1_�p�p���{�L�^ = 1
        _2_�ĉ��H�w��_�L�^ = 2
        _3_�ԋp���{�L�^ = 3
        _4_�]�p��L�^ = 4
    End Enum


    'Model
    Private _V002_NCR_J As New MODEL.V002_NCR_J
    Private _V003_SYONIN_J_KANRI_List As New List(Of MODEL.V003_SYONIN_J_KANRI)
    Private _V004_HOKOKU_SOUSA As New MODEL.V004_HOKOKU_SOUSA

    '���͕K�{�R���g���[�����ؔ���
    Private pri_blnValidated As Boolean = True

    '�������u�v�۔���=CAR�ҏW��ʋN������
    Private blnEnableCAREdit As Boolean

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
    Public Property PrDataRow As DataRow

    '���݂̃X�e�[�W ���F��
    Public Property PrCurrentStage As Integer


    'CAR�ҏW��ʂ���J����Ă��邩
    Public Property PrDialog As Boolean

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
        'MyBase.ToolTip.SetToolTip(Me.cmdFunc3, My.Resources.infoToolTipMsgNotFoundData)
        MyBase.ToolTip.SetToolTip(Me.cmdFunc4, "�V�K�o�^���͎g�p�o���܂���")
        MyBase.ToolTip.SetToolTip(Me.cmdFunc5, "�V�K�o�^���͎g�p�o���܂���")
        MyBase.ToolTip.SetToolTip(Me.cmdFunc10, "�V�K�o�^���͎g�p�o���܂���")
        MyBase.ToolTip.SetToolTip(Me.cmdFunc11, "�V�K�o�^���͎g�p�o���܂���")


        If PrMODE = ENM_DATA_OPERATION_MODE._1_ADD Then
            MyBase.ToolTip.SetToolTip(Me.cmdFunc9, "�V�K�o�^���͎g�p�o���܂���")
        Else
            MyBase.ToolTip.SetToolTip(Me.cmdFunc9, "�ҏW����������܂���")
        End If
        Me.ShowIcon = True

        D003NCRJBindingSource.DataSource = _D003_NCR_J

        mtxHOKUKO_NO.Enabled = False
        dtDraft.Enabled = False
        cmbKISO_TANTO.Enabled = False
        mtxHINMEI.Enabled = False
        pnlPict1.AllowDrop = True
        pnlPict2.AllowDrop = True

        'UNDONE: Enable False����ForeColor���w�肵����

        '���I�����E�H�[�^�[�}�[�N+�o�C���h���K�v�ȃR���{�{�b�N�X�̂��߂̐ݒ�
        cmbKISO_TANTO.NullValue = 0
        cmbKISYU.NullValue = 0
        cmbST07_SAISIN_TANTO.NullValue = 0
        cmbST08_1_HAIKYAKU_TANTO.NullValue = 0
        cmbST08_2_TANTO_SEIZO.NullValue = 0
        cmbST08_2_TANTO_SEIGI.NullValue = 0
        cmbST08_2_TANTO_KENSA.NullValue = 0
        cmbST08_4_KISYU.NullValue = 0
        cmbST01_DestTANTO.NullValue = 0
        cmbST02_DestTANTO.NullValue = 0
        cmbST03_DestTANTO.NullValue = 0
        cmbST04_DestTANTO.NullValue = 0
        cmbST05_DestTANTO.NullValue = 0
        cmbST06_DestTANTO.NullValue = 0
        cmbST07_DestTANTO.NullValue = 0
        cmbST08_DestTANTO.NullValue = 0
        cmbST09_DestTANTO.NullValue = 0
        cmbST10_DestTANTO.NullValue = 0
        cmbST11_DestTANTO.NullValue = 0

    End Sub

#End Region

#Region "Form�֘A"

#Region "LOAD"
    Private Sub FrmLoad(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        Try
            '-----�t�H�[�������ݒ�(�e�t�H�[������Ăяo��)
            Call FunFormCommonSetting(pub_APP_INFO, pub_SYAIN_INFO, My.Application.Info.Version.ToString)
            Me.Text = "�s�K�����i���u�񍐏�(Non-Conformance Report)"
            lblTytle.Text = Me.Text

            '-----�R���g���[���f�[�^�\�[�X�ݒ�
            'Dim dtAddTANTO As DataTable = tblTANTO_SYONIN.
            '                                ExcludeDeleted.
            '                                AsEnumerable.
            '                                Where(Function(r) r.Field(Of Integer)("SYONIN_JUN") = ENM_NCR_STAGE._10_�N������ And r.Field(Of Integer)("SYONIN_HOKOKUSYO_ID") = ENM_SYONIN_HOKOKU_ID._1_NCR).
            '                                CopyToDataTable
            cmbKISO_TANTO.SetDataSource(tblTANTO, ENM_COMBO_SELECT_VALUE_TYPE._0_Required)
            cmbKISYU.SetDataSource(tblKISYU.ExcludeDeleted, ENM_COMBO_SELECT_VALUE_TYPE._0_Required)
            cmbBUHIN_BANGO.SetDataSource(tblBUHIN.ExcludeDeleted, ENM_COMBO_SELECT_VALUE_TYPE._0_Required)
            cmbFUTEKIGO_STATUS.SetDataSource(tblFUTEKIGO_STATUS_KB.ExcludeDeleted, ENM_COMBO_SELECT_VALUE_TYPE._0_Required)
            cmbFUTEKIGO_KB.SetDataSource(tblFUTEKIGO_KB.ExcludeDeleted, ENM_COMBO_SELECT_VALUE_TYPE._0_Required)
            cmbSYANAI_CD.SetDataSource(tblSYANAI_CD.ExcludeDeleted, ENM_COMBO_SELECT_VALUE_TYPE._0_Required)

            cmbBUMON.SetDataSource(tblBUMON.ExcludeDeleted, ENM_COMBO_SELECT_VALUE_TYPE._0_Required)
            Dim blnIsAdmin As Boolean = HasAdminAuth(pub_SYAIN_INFO.SYAIN_ID)
            If blnIsAdmin Then
                '�V�X�e���Ǘ��҂̂ݐ�������
            Else
                Select Case pub_SYAIN_INFO.BUMON_KB
                    Case Context.ENM_BUMON_KB._1_���h, Context.ENM_BUMON_KB._2_LP
                        Dim dt As DataTable = DirectCast(cmbBUMON.DataSource, DataTable).
                                                    AsEnumerable.
                                                    Where(Function(r) r.Field(Of String)("VALUE") = "1" Or r.Field(Of String)("VALUE") = "2").
                                                    CopyToDataTable
                        cmbBUMON.SetDataSource(dt, ENM_COMBO_SELECT_VALUE_TYPE._1_Filter)

                        cmbBUMON.SelectedValue = pub_SYAIN_INFO.BUMON_KB

                    Case Context.ENM_BUMON_KB._3_������
                        Dim dt As DataTable = DirectCast(cmbBUMON.DataSource, DataTable).
                                                    AsEnumerable.
                                                    Where(Function(r) r.Field(Of String)("VALUE") = pub_SYAIN_INFO.BUMON_KB).
                                                    CopyToDataTable
                        cmbBUMON.SetDataSource(dt, ENM_COMBO_SELECT_VALUE_TYPE._1_Filter)

                        cmbBUMON.SelectedValue = pub_SYAIN_INFO.BUMON_KB
                    Case Else

                End Select
            End If

            '���f�����Z�b�g
            _D003_NCR_J.Clear()
            _D004_SYONIN_J_KANRI.clear()
            '_D005_CAR_J.Clear()
            _R001_HOKOKU_SOUSA.clear()
            _R002_HOKOKU_TENSO.clear()

            '�o�C���f�B���O
            Call FunSetBindingD003()

            '-----�������[�h�ʉ�ʏ�����
            Call FunInitializeControls(PrMODE)
        Finally
            Call FunInitFuncButtonEnabled()
        End Try
    End Sub

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

                    '���̓`�F�b�N
                    If FunCheckInput(ENM_SAVE_MODE._1_�ۑ�) Then
                        If MessageBox.Show("���͓��e��ۑ����܂����H", "�o�^�m�F", MessageBoxButtons.YesNo, MessageBoxIcon.Information) = DialogResult.Yes Then

                            If FunSAVE(ENM_SAVE_MODE._1_�ۑ�) Then
                                Me.DialogResult = DialogResult.OK
                                MessageBox.Show("���͓��e��ۑ����܂���", "�ۑ�����", MessageBoxButtons.OK, MessageBoxIcon.Information)

                                If blnEnableCAREdit Then
                                    If MessageBox.Show("CAR�N�����͉�ʂ�\�����܂���?", "CAR�N������", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes Then
                                        Call OpenFormCAR()
                                        blnEnableCAREdit = False
                                    End If
                                End If
                            Else
                                MessageBox.Show("�ۑ������Ɏ��s���܂����B", "�ۑ����s", MessageBoxButtons.OK, MessageBoxIcon.Error)
                            End If
                        End If
                    End If

                Case 2  '���F�\��
                    '���̓`�F�b�N
                    If FunCheckInput(ENM_SAVE_MODE._2_���F�\��) Then
                        If MessageBox.Show("�\�����܂����H", "�\�������m�F", MessageBoxButtons.YesNo, MessageBoxIcon.Information) = DialogResult.Yes Then
                            If FunSAVE(ENM_SAVE_MODE._2_���F�\��) Then
                                MessageBox.Show("�\�����܂���", "�\����������", MessageBoxButtons.OK, MessageBoxIcon.Information)
                                Me.DialogResult = DialogResult.OK

                                'CAR�ҏW�\����
                                If blnEnableCAREdit Then
                                    If MessageBox.Show("CAR�N�����͉�ʂ�\�����܂���?", "CAR�N������", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes Then
                                        Call OpenFormCAR()
                                        blnEnableCAREdit = False
                                    End If
                                End If

                                'SPEC: 80-3.�B
                                If PrCurrentStage = ENM_NCR_STAGE._80_���u���{ AndAlso Val(_D003_NCR_J.KENSA_KEKKA_KB) = ENM_KENSA_KEKKA_KB._1_�s���i Then
                                    If MessageBox.Show("�ĕs�K�����u�f�[�^�𑱂��č쐬���܂���?", "�ĕs�K�����u�m�F", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes Then
                                        Call FunSAVE_D003_SAI_FUTEKIGO()
                                    End If
                                End If

                                'SPEC: 2.(3).E.�C
                                Me.Close()
                            Else
                                MessageBox.Show("�ۑ������Ɏ��s���܂����B", "�ۑ����s", MessageBoxButtons.OK, MessageBoxIcon.Error)
                            End If
                        End If
                    End If

                Case 4  '�]��
                    Call OpenFormTENSO()
                Case 5  '���߂�
                    Call OpenFormSASIMODOSI()
                Case 9  'CAR�ҏW

                    'SPEC: 40-6
                    If PrCurrentStage <= ENM_NCR_STAGE._40_���O�R������y��CAR�v�۔��� AndAlso FunHasAuthCAREdit(_D003_NCR_J.HOKOKU_NO, pub_SYAIN_INFO.SYAIN_ID) = False Then
                        MessageBox.Show("CAR�͋N������Ă��܂���B" & vbCrLf & "�����̂���Ј��ɂċN����ɊJ���ĉ�����", "�����Ȃ�", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    Else
                        Call OpenFormCAR()
                    End If

                Case 10  '���|�[�g���
                    Call FunOpenReportNCR()

                Case 11 '����\��
                    Call OpenFormHistory(ENM_SYONIN_HOKOKUSYO_ID._1_NCR, _D003_NCR_J.HOKOKU_NO)

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

#Region "�ۑ��E���F�\��"

    ''' <summary>
    ''' �ۑ��E���F�\���������C��
    ''' </summary>
    ''' <param name="enmSAVE_MODE"></param>
    ''' <returns></returns>
    Private Function FunSAVE(ByVal enmSAVE_MODE As ENM_SAVE_MODE) As Boolean
        Try

            Using DB As ClsDbUtility = DBOpen()
                Dim blnErr As Boolean
                Try '-----�g�����U�N�V����
                    DB.BeginTransaction()

                    Select Case PrCurrentStage
                        Case ENM_NCR_STAGE._81_���u���{_���Z To ENM_NCR_STAGE._100_���u���{����_�����ے�
                            '�f�[�^�͍X�V���Ȃ�
                        Case Else
                            'SPEC: 2.(3).D.�@.���R�[�h�X�V
                            If FunSAVE_D003(DB) Then
                            Else
                                Return False
                                blnErr = True
                            End If
                            If FunSAVE_FILE(DB) Then
                            Else
                                Return False
                                blnErr = True
                            End If
                    End Select

                    '
                    If FunSAVE_D004(DB, enmSAVE_MODE) Then
                    Else
                        Return False
                        blnErr = True
                    End If

                    '
                    If FunSAVE_R001(DB, enmSAVE_MODE) Then
                    Else
                        Return False
                        blnErr = True
                    End If

                Finally
                    DB.Commit(Not blnErr)
                End Try
            End Using

            Return True
        Catch ex As Exception
            Throw
            Return False
        Finally
        End Try
    End Function

    ''' <summary>
    ''' NCR�Y�t�t�@�C���ۑ�
    ''' </summary>
    ''' <param name="DB"></param>
    ''' <returns></returns>
    Private Function FunSAVE_FILE(ByRef DB As ClsDbUtility) As Boolean

        If _D003_NCR_J.FILE_PATH.IsNullOrWhiteSpace And _D003_NCR_J.G_FILE_PATH1.IsNullOrWhiteSpace And _D003_NCR_J.G_FILE_PATH2.IsNullOrWhiteSpace Then
            Return True
        Else
            'SPEC: 2.(3).D.�A.�Y�t�t�@�C���ۑ�
            Dim strRootDir As String
            Dim strMsg As String
            strRootDir = FunConvPathString(FunGetCodeMastaValue(DB, "�Y�t�t�@�C���ۑ���", My.Application.Info.AssemblyName))
            If strRootDir.IsNullOrWhiteSpace OrElse Not System.IO.Directory.Exists(strRootDir) Then

                strMsg = "�Y�t�t�@�C���ۑ��悪�ݒ肳��Ă��Ȃ����A�A�N�Z�X�o���܂���B" & vbCrLf &
                         "�Y�t�t�@�C���̓V�X�e���ɕۑ�����܂��񂪁A" & vbCrLf &
                         "�o�^�����𑱍s���܂����H"

                If MessageBox.Show(strMsg, "�t�@�C���ۑ���A�N�Z�X�s��", MessageBoxButtons.OKCancel, MessageBoxIcon.Exclamation) <> vbOK Then
                    Me.DialogResult = DialogResult.Abort
                    Return True
                End If
            Else
                Try
                    System.IO.Directory.CreateDirectory(strRootDir & _D003_NCR_J.HOKOKU_NO)
                    If Not _D003_NCR_J.FILE_PATH.IsNullOrWhiteSpace AndAlso Not System.IO.File.Exists(strRootDir & _D003_NCR_J.HOKOKU_NO.Trim & "\" & _D003_NCR_J.FILE_PATH) Then
                        System.IO.File.Copy(lbltmpFile1.Links.Item(0).LinkData(0), strRootDir & _D003_NCR_J.HOKOKU_NO.Trim & "\" & _D003_NCR_J.FILE_PATH, True)
                        '_D003_NCR_J.FILE_PATH = strRootDir & System.IO.Path.GetFileName(_D003_NCR_J.FILE_PATH)
                    End If
                    If Not _D003_NCR_J.G_FILE_PATH1.IsNullOrWhiteSpace AndAlso Not System.IO.File.Exists(strRootDir & _D003_NCR_J.HOKOKU_NO.Trim & "\" & _D003_NCR_J.G_FILE_PATH1) Then
                        System.IO.File.Copy(lblPict1Path.Links.Item(0).LinkData(0), strRootDir & _D003_NCR_J.HOKOKU_NO.Trim & "\" & _D003_NCR_J.G_FILE_PATH1, True)
                        '_D003_NCR_J.G_FILE_PATH1 = strRootDir & System.IO.Path.GetFileName(_D003_NCR_J.G_FILE_PATH1)
                    End If
                    If Not _D003_NCR_J.G_FILE_PATH2.IsNullOrWhiteSpace AndAlso Not System.IO.File.Exists(strRootDir & _D003_NCR_J.HOKOKU_NO.Trim & "\" & _D003_NCR_J.G_FILE_PATH2) Then
                        System.IO.File.Copy(lblPict2Path.Links.Item(0).LinkData(0), strRootDir & _D003_NCR_J.HOKOKU_NO.Trim & "\" & _D003_NCR_J.G_FILE_PATH2, True)
                        '_D003_NCR_J.G_FILE_PATH2 = strRootDir & System.IO.Path.GetFileName(_D003_NCR_J.G_FILE_PATH2)
                    End If

                    Return True

                Catch exIO As UnauthorizedAccessException
                    strMsg = "�Y�t�t�@�C���ۑ���̃A�N�Z�X����������܂���B" & vbCrLf &
                             "�Y�t�t�@�C���ۑ���:" & strRootDir
                    MessageBox.Show(strMsg, "�t�@�C���ۑ���A�N�Z�X�s��", MessageBoxButtons.OK, MessageBoxIcon.Error)
                End Try
            End If
        End If
    End Function

    ''' <summary>
    ''' NCR���эX�V
    ''' </summary>
    ''' <param name="DB"></param>
    ''' <returns></returns>
    Private Function FunSAVE_D003(ByRef DB As ClsDbUtility) As Boolean
        Dim sbSQL As New System.Text.StringBuilder
        Dim strRET As String
        Dim sqlEx As New Exception

        '-----���ۑ����A�񍐏�No�擾
        If _D003_NCR_J.HOKOKU_NO.IsNullOrWhiteSpace Or _D003_NCR_J.HOKOKU_NO = "<�V�K>" Then
            Dim objParam As System.Data.Common.DbParameter = DB.DbCommand.CreateParameter
            Dim lstParam As New List(Of System.Data.Common.DbParameter)
            With objParam
                .ParameterName = NameOf(_D003_NCR_J.HOKOKU_NO)
                .DbType = DbType.String
                .Direction = ParameterDirection.Output
                .Size = 8
            End With
            lstParam.Add(objParam)
            If DB.Fun_blnExecStored("dbo.ST01_GET_HOKOKU_NO", lstParam) = True Then
                _D003_NCR_J.HOKOKU_NO = DB.DbCommand.Parameters(NameOf(_D003_NCR_J.HOKOKU_NO)).Value
            Else
                Return False
            End If
        End If

        '-----���f���X�V
        If (PrCurrentStage = ENM_NCR_STAGE._80_���u���{ AndAlso Val(_D003_NCR_J.KENSA_KEKKA_KB) = ENM_KENSA_KEKKA_KB._1_�s���i) Or PrCurrentStage = ENM_NCR_STAGE._120_abcde���u�m�F Then
            _D003_NCR_J._CLOSE_FG = 1
        End If

        Select Case PrCurrentStage
            Case ENM_NCR_STAGE._40_���O�R������y��CAR�v�۔���
                _D003_NCR_J.JIZEN_SINSA_SYAIN_ID = pub_SYAIN_INFO.SYAIN_ID
                'UNDONE: getdbsysdate
                _D003_NCR_J.JIZEN_SINSA_YMD = Now.ToString("yyyyMMdd")
            Case ENM_NCR_STAGE._50_���O�R���m�F
                _D003_NCR_J.SAISIN_KAKUNIN_SYAIN_ID = pub_SYAIN_INFO.SYAIN_ID
                _D003_NCR_J.SAISIN_KAKUNIN_YMD = Now.ToString("yyyyMMdd")
            Case ENM_NCR_STAGE._60_�ĐR�R������_�Z�p��\
                _D003_NCR_J.SAISIN_GIJYUTU_SYAIN_ID = pub_SYAIN_INFO.SYAIN_ID
                _D003_NCR_J.SAISIN_GIJYUTU_YMD = Now.ToString("yyyyMMdd")
            Case ENM_NCR_STAGE._61_�ĐR�R������_�i�ؑ�\
                _D003_NCR_J.SAISIN_HINSYO_SYAIN_ID = pub_SYAIN_INFO.SYAIN_ID
                _D003_NCR_J.SAISIN_HINSYO_YMD = Now.ToString("yyyyMMdd")
            Case ENM_NCR_STAGE._70_�ڋq�ĐR���u_I_tag
                _D003_NCR_J.KOKYAKU_SAISIN_TANTO_ID = pub_SYAIN_INFO.SYAIN_ID
                _D003_NCR_J.KOKYAKU_SAISIN_YMD = Now.ToString("yyyyMMdd")
            Case ENM_NCR_STAGE._110_abcde���u�S��


            Case Else
                'UNDONE: 
        End Select

        '-----MERGE
        sbSQL.Remove(0, sbSQL.Length)
        sbSQL.Append("MERGE INTO " & NameOf(MODEL.D003_NCR_J) & " AS SrcT")
        sbSQL.Append(" USING (")
        sbSQL.Append(" SELECT")
        sbSQL.Append(" '" & _D003_NCR_J.HOKOKU_NO & "' AS " & NameOf(_D003_NCR_J.HOKOKU_NO))
        sbSQL.Append(" ,'" & _D003_NCR_J.BUMON_KB & "' AS " & NameOf(_D003_NCR_J.BUMON_KB))
        sbSQL.Append(" ,'" & _D003_NCR_J._CLOSE_FG & "' AS " & NameOf(_D003_NCR_J.CLOSE_FG))
        sbSQL.Append(" ," & _D003_NCR_J.KISYU_ID & " AS " & NameOf(_D003_NCR_J.KISYU_ID))
        sbSQL.Append(" ,'" & _D003_NCR_J.SYANAI_CD & "' AS " & NameOf(_D003_NCR_J.SYANAI_CD))
        sbSQL.Append(" ,'" & _D003_NCR_J.BUHIN_BANGO & "' AS " & NameOf(_D003_NCR_J.BUHIN_BANGO))
        sbSQL.Append(" ,'" & _D003_NCR_J.BUHIN_NAME.ParseSqlEscape & "' AS " & NameOf(_D003_NCR_J.BUHIN_NAME))
        sbSQL.Append(" ,'" & _D003_NCR_J.GOKI.ParseSqlEscape & "' AS " & NameOf(_D003_NCR_J.GOKI))
        sbSQL.Append(" ," & _D003_NCR_J.SURYO & " AS " & NameOf(_D003_NCR_J.SURYO))
        sbSQL.Append(" ,'" & _D003_NCR_J._SAIHATU & "' AS " & NameOf(_D003_NCR_J.SAIHATU))
        sbSQL.Append(" ,'" & _D003_NCR_J.FUTEKIGO_JYOTAI_KB & "' AS " & NameOf(_D003_NCR_J.FUTEKIGO_JYOTAI_KB))
        sbSQL.Append(" ,'" & _D003_NCR_J.FUTEKIGO_NAIYO.ParseSqlEscape & "' AS " & NameOf(_D003_NCR_J.FUTEKIGO_NAIYO))
        sbSQL.Append(" ,'" & _D003_NCR_J.FUTEKIGO_KB & "' AS " & NameOf(_D003_NCR_J.FUTEKIGO_KB))
        sbSQL.Append(" ,'" & _D003_NCR_J.FUTEKIGO_S_KB & "' AS " & NameOf(_D003_NCR_J.FUTEKIGO_S_KB))
        sbSQL.Append(" ,'" & _D003_NCR_J.ZUMEN_KIKAKU.ParseSqlEscape & "' AS " & NameOf(_D003_NCR_J.ZUMEN_KIKAKU))
        sbSQL.Append(" ,'" & _D003_NCR_J.YOKYU_NAIYO.ParseSqlEscape & "' AS " & NameOf(_D003_NCR_J.YOKYU_NAIYO))
        sbSQL.Append(" ,'" & _D003_NCR_J.KANSATU_KEKKA.ParseSqlEscape & "' AS " & NameOf(_D003_NCR_J.KANSATU_KEKKA))
        sbSQL.Append(" ,'" & _D003_NCR_J._ZESEI_SYOCHI_YOHI_KB & "' AS " & NameOf(_D003_NCR_J.ZESEI_SYOCHI_YOHI_KB))
        sbSQL.Append(" ,'" & _D003_NCR_J.ZESEI_NASI_RIYU.ParseSqlEscape & "' AS " & NameOf(_D003_NCR_J.ZESEI_NASI_RIYU))
        sbSQL.Append(" ,'" & _D003_NCR_J.JIZEN_SINSA_HANTEI_KB & "' AS " & NameOf(_D003_NCR_J.JIZEN_SINSA_HANTEI_KB))
        sbSQL.Append(" ," & _D003_NCR_J.JIZEN_SINSA_SYAIN_ID & " AS " & NameOf(_D003_NCR_J.JIZEN_SINSA_SYAIN_ID))

        sbSQL.Append(" ,'" & _D003_NCR_J.JIZEN_SINSA_YMD & "' AS " & NameOf(_D003_NCR_J.JIZEN_SINSA_YMD))
        sbSQL.Append(" ," & _D003_NCR_J.SAISIN_KAKUNIN_SYAIN_ID & " AS " & NameOf(_D003_NCR_J.SAISIN_KAKUNIN_SYAIN_ID))
        sbSQL.Append(" ,'" & _D003_NCR_J.SAISIN_KAKUNIN_YMD & "' AS " & NameOf(_D003_NCR_J.SAISIN_KAKUNIN_YMD))
        sbSQL.Append(" ,'" & _D003_NCR_J.SAISIN_IINKAI_HANTEI_KB & "' AS " & NameOf(_D003_NCR_J.SAISIN_IINKAI_HANTEI_KB))
        sbSQL.Append(" ," & _D003_NCR_J.SAISIN_GIJYUTU_SYAIN_ID & " AS " & NameOf(_D003_NCR_J.SAISIN_GIJYUTU_SYAIN_ID))
        sbSQL.Append(" ,'" & _D003_NCR_J.SAISIN_GIJYUTU_YMD & "' AS " & NameOf(_D003_NCR_J.SAISIN_GIJYUTU_YMD))
        sbSQL.Append(" ," & _D003_NCR_J.SAISIN_HINSYO_SYAIN_ID & " AS " & NameOf(_D003_NCR_J.SAISIN_HINSYO_SYAIN_ID))
        sbSQL.Append(" ,'" & _D003_NCR_J.SAISIN_HINSYO_YMD & "' AS " & NameOf(_D003_NCR_J.SAISIN_HINSYO_YMD))
        sbSQL.Append(" ,'" & _D003_NCR_J.SAISIN_IINKAI_SIRYO_NO.ParseSqlEscape & "' AS " & NameOf(_D003_NCR_J.SAISIN_IINKAI_SIRYO_NO))
        sbSQL.Append(" ,'" & _D003_NCR_J.ITAG_NO.ParseSqlEscape & "' AS " & NameOf(_D003_NCR_J.ITAG_NO))
        sbSQL.Append(" ," & _D003_NCR_J.KOKYAKU_SAISIN_TANTO_ID & " AS " & NameOf(_D003_NCR_J.KOKYAKU_SAISIN_TANTO_ID))
        sbSQL.Append(" ,'" & _D003_NCR_J.KOKYAKU_SAISIN_YMD & "' AS " & NameOf(_D003_NCR_J.KOKYAKU_SAISIN_YMD))
        sbSQL.Append(" ,'" & _D003_NCR_J.KOKYAKU_HANTEI_SIJI_KB & "' AS " & NameOf(_D003_NCR_J.KOKYAKU_HANTEI_SIJI_KB))
        sbSQL.Append(" ,'" & _D003_NCR_J.KOKYAKU_HANTEI_SIJI_YMD & "' AS " & NameOf(_D003_NCR_J.KOKYAKU_HANTEI_SIJI_YMD))
        sbSQL.Append(" ,'" & _D003_NCR_J.KOKYAKU_SAISYU_HANTEI_KB & "' AS " & NameOf(_D003_NCR_J.KOKYAKU_SAISYU_HANTEI_KB))
        sbSQL.Append(" ,'" & _D003_NCR_J.KOKYAKU_SAISYU_HANTEI_YMD & "' AS " & NameOf(_D003_NCR_J.KOKYAKU_SAISYU_HANTEI_YMD))
        sbSQL.Append(" ,'" & _D003_NCR_J._SAIKAKO_SIJI_FG & "' AS " & NameOf(_D003_NCR_J.SAIKAKO_SIJI_FG))
        sbSQL.Append(" ,'" & _D003_NCR_J.HAIKYAKU_YMD & "' AS " & NameOf(_D003_NCR_J.HAIKYAKU_YMD))
        sbSQL.Append(" ,'" & _D003_NCR_J.HAIKYAKU_KB & "' AS " & NameOf(_D003_NCR_J.HAIKYAKU_KB))
        sbSQL.Append(" ,'" & _D003_NCR_J.HAIKYAKU_HOUHOU.ParseSqlEscape & "' AS " & NameOf(_D003_NCR_J.HAIKYAKU_HOUHOU))
        sbSQL.Append(" ," & _D003_NCR_J.HAIKYAKU_TANTO_ID & " AS " & NameOf(_D003_NCR_J.HAIKYAKU_TANTO_ID))
        sbSQL.Append(" ,'" & _D003_NCR_J.SAIKAKO_SIJI_NO.ParseSqlEscape & "' AS " & NameOf(_D003_NCR_J.SAIKAKO_SIJI_NO))
        sbSQL.Append(" ,'" & _D003_NCR_J.SAIKAKO_SAGYO_KAN_YMD & "' AS " & NameOf(_D003_NCR_J.SAIKAKO_SAGYO_KAN_YMD))
        sbSQL.Append(" ,'" & _D003_NCR_J.SAIKAKO_KENSA_YMD & "' AS " & NameOf(_D003_NCR_J.SAIKAKO_KENSA_YMD))
        sbSQL.Append(" ,'" & _D003_NCR_J.KENSA_KEKKA_KB & "' AS " & NameOf(_D003_NCR_J.KENSA_KEKKA_KB))
        sbSQL.Append(" ," & _D003_NCR_J.SEIGI_TANTO_ID & " AS " & NameOf(_D003_NCR_J.SEIGI_TANTO_ID))
        sbSQL.Append(" ," & _D003_NCR_J.SEIZO_TANTO_ID & " AS " & NameOf(_D003_NCR_J.SEIZO_TANTO_ID))
        sbSQL.Append(" ," & _D003_NCR_J.KENSA_TANTO_ID & " AS " & NameOf(_D003_NCR_J.KENSA_TANTO_ID))
        sbSQL.Append(" ,'" & _D003_NCR_J.HENKYAKU_YMD & "' AS " & NameOf(_D003_NCR_J.HENKYAKU_YMD))
        sbSQL.Append(" ,'" & _D003_NCR_J.HENKYAKU_SAKI.ParseSqlEscape & "' AS " & NameOf(_D003_NCR_J.HENKYAKU_SAKI))
        sbSQL.Append(" ," & _D003_NCR_J.HENKYAKU_TANTO_ID & " AS " & NameOf(_D003_NCR_J.HENKYAKU_TANTO_ID))
        sbSQL.Append(" ,'" & _D003_NCR_J.HENKYAKU_BIKO.ParseSqlEscape & "' AS " & NameOf(_D003_NCR_J.HENKYAKU_BIKO))
        sbSQL.Append(" ," & _D003_NCR_J.TENYO_KISYU_ID & " AS " & NameOf(_D003_NCR_J.TENYO_KISYU_ID))
        sbSQL.Append(" ,'" & _D003_NCR_J.TENYO_BUHIN_BANGO.ParseSqlEscape & "' AS " & NameOf(_D003_NCR_J.TENYO_BUHIN_BANGO))
        sbSQL.Append(" ,'" & _D003_NCR_J.TENYO_GOKI.ParseSqlEscape & "' AS " & NameOf(_D003_NCR_J.TENYO_GOKI))
        sbSQL.Append(" ," & _D003_NCR_J.TENYO_LOT & " AS " & NameOf(_D003_NCR_J.TENYO_LOT))
        sbSQL.Append(" ,'" & _D003_NCR_J.TENYO_YMD & "' AS " & NameOf(_D003_NCR_J.TENYO_YMD))
        sbSQL.Append(" ,'" & _D003_NCR_J._SYOCHI_KEKKA_A & "' AS " & NameOf(_D003_NCR_J.SYOCHI_KEKKA_A))
        sbSQL.Append(" ,'" & _D003_NCR_J._SYOCHI_KEKKA_B & "' AS " & NameOf(_D003_NCR_J.SYOCHI_KEKKA_B))
        sbSQL.Append(" ,'" & _D003_NCR_J._SYOCHI_KEKKA_C & "' AS " & NameOf(_D003_NCR_J.SYOCHI_KEKKA_C))
        sbSQL.Append(" ,'" & _D003_NCR_J._SYOCHI_D_UMU_KB & "' AS " & NameOf(_D003_NCR_J.SYOCHI_D_UMU_KB))
        sbSQL.Append(" ,'" & _D003_NCR_J._SYOCHI_D_YOHI_KB & "' AS " & NameOf(_D003_NCR_J.SYOCHI_D_YOHI_KB))
        sbSQL.Append(" ,'" & _D003_NCR_J.SYOCHI_D_SYOCHI_KIROKU.ParseSqlEscape & "' AS " & NameOf(_D003_NCR_J.SYOCHI_D_SYOCHI_KIROKU))
        sbSQL.Append(" ,'" & _D003_NCR_J._SYOCHI_E_UMU_KB & "' AS " & NameOf(_D003_NCR_J.SYOCHI_E_UMU_KB))
        sbSQL.Append(" ,'" & _D003_NCR_J._SYOCHI_E_YOHI_KB & "' AS " & NameOf(_D003_NCR_J.SYOCHI_E_YOHI_KB))
        sbSQL.Append(" ,'" & _D003_NCR_J.SYOCHI_E_SYOCHI_KIROKU.ParseSqlEscape & "' AS " & NameOf(_D003_NCR_J.SYOCHI_E_SYOCHI_KIROKU))

        sbSQL.Append(" ,'" & _D003_NCR_J.FILE_PATH.ParseSqlEscape & "' AS " & NameOf(_D003_NCR_J.FILE_PATH))
        sbSQL.Append(" ,'" & _D003_NCR_J.G_FILE_PATH1.ParseSqlEscape & "' AS " & NameOf(_D003_NCR_J.G_FILE_PATH1))
        sbSQL.Append(" ,'" & _D003_NCR_J.G_FILE_PATH2.ParseSqlEscape & "' AS " & NameOf(_D003_NCR_J.G_FILE_PATH2))
        sbSQL.Append(" ," & _D003_NCR_J.ADD_SYAIN_ID & " AS " & NameOf(_D003_NCR_J.ADD_SYAIN_ID))
        sbSQL.Append(" ,'" & _D003_NCR_J.ADD_YMDHNS & "' AS " & NameOf(_D003_NCR_J.ADD_YMDHNS))
        sbSQL.Append(" ," & pub_SYAIN_INFO.SYAIN_ID & " AS " & NameOf(_D003_NCR_J.UPD_SYAIN_ID))
        sbSQL.Append(" ,'" & _D003_NCR_J.UPD_YMDHNS & "' AS " & NameOf(_D003_NCR_J.UPD_YMDHNS))
        sbSQL.Append(" ,0 AS " & NameOf(_D003_NCR_J.DEL_SYAIN_ID))
        sbSQL.Append(" ,' ' AS " & NameOf(_D003_NCR_J.DEL_YMDHNS))
        sbSQL.Append(" ) AS WK")
        sbSQL.Append(" ON (SrcT.HOKOKU_NO = WK.HOKOKU_NO)")

        'UPDATE �r������ �X�V�������ύX����Ă��Ȃ��ꍇ�̂�
        sbSQL.Append(" WHEN MATCHED AND SrcT." & NameOf(_D003_NCR_J.UPD_YMDHNS) & " = WK." & NameOf(_D003_NCR_J.UPD_YMDHNS) & " THEN ")
        sbSQL.Append(" UPDATE SET")
        sbSQL.Append("  SrcT." & NameOf(_D003_NCR_J.KISYU_ID) & " = WK." & NameOf(_D003_NCR_J.KISYU_ID))
        sbSQL.Append(" ,SrcT." & NameOf(_D003_NCR_J.CLOSE_FG) & " = WK." & NameOf(_D003_NCR_J.CLOSE_FG))
        sbSQL.Append(" ,SrcT." & NameOf(_D003_NCR_J.SYANAI_CD) & " = WK." & NameOf(_D003_NCR_J.SYANAI_CD))
        sbSQL.Append(" ,SrcT." & NameOf(_D003_NCR_J.BUHIN_BANGO) & " = WK." & NameOf(_D003_NCR_J.BUHIN_BANGO))
        sbSQL.Append(" ,SrcT." & NameOf(_D003_NCR_J.BUHIN_NAME) & " = WK." & NameOf(_D003_NCR_J.BUHIN_NAME))
        sbSQL.Append(" ,SrcT." & NameOf(_D003_NCR_J.GOKI) & " = WK." & NameOf(_D003_NCR_J.GOKI))
        sbSQL.Append(" ,SrcT." & NameOf(_D003_NCR_J.SURYO) & " = WK." & NameOf(_D003_NCR_J.SURYO))
        sbSQL.Append(" ,SrcT." & NameOf(_D003_NCR_J.SAIHATU) & " = WK." & NameOf(_D003_NCR_J.SAIHATU))
        sbSQL.Append(" ,SrcT." & NameOf(_D003_NCR_J.FUTEKIGO_JYOTAI_KB) & " = WK." & NameOf(_D003_NCR_J.FUTEKIGO_JYOTAI_KB))
        sbSQL.Append(" ,SrcT." & NameOf(_D003_NCR_J.FUTEKIGO_NAIYO) & " = WK." & NameOf(_D003_NCR_J.FUTEKIGO_NAIYO))
        sbSQL.Append(" ,SrcT." & NameOf(_D003_NCR_J.FUTEKIGO_KB) & " = WK." & NameOf(_D003_NCR_J.FUTEKIGO_KB))
        sbSQL.Append(" ,SrcT." & NameOf(_D003_NCR_J.FUTEKIGO_S_KB) & " = WK." & NameOf(_D003_NCR_J.FUTEKIGO_S_KB))
        sbSQL.Append(" ,SrcT." & NameOf(_D003_NCR_J.ZUMEN_KIKAKU) & " = WK." & NameOf(_D003_NCR_J.ZUMEN_KIKAKU))
        sbSQL.Append(" ,SrcT." & NameOf(_D003_NCR_J.YOKYU_NAIYO) & " = WK." & NameOf(_D003_NCR_J.YOKYU_NAIYO))
        sbSQL.Append(" ,SrcT." & NameOf(_D003_NCR_J.KANSATU_KEKKA) & " = WK." & NameOf(_D003_NCR_J.KANSATU_KEKKA))

        sbSQL.Append(" ,SrcT." & NameOf(_D003_NCR_J.ZESEI_SYOCHI_YOHI_KB) & " = WK." & NameOf(_D003_NCR_J.ZESEI_SYOCHI_YOHI_KB))
        sbSQL.Append(" ,SrcT." & NameOf(_D003_NCR_J.ZESEI_NASI_RIYU) & " = WK." & NameOf(_D003_NCR_J.ZESEI_NASI_RIYU))
        sbSQL.Append(" ,SrcT." & NameOf(_D003_NCR_J.JIZEN_SINSA_HANTEI_KB) & " = WK." & NameOf(_D003_NCR_J.JIZEN_SINSA_HANTEI_KB))
        sbSQL.Append(" ,SrcT." & NameOf(_D003_NCR_J.JIZEN_SINSA_SYAIN_ID) & " = WK." & NameOf(_D003_NCR_J.JIZEN_SINSA_SYAIN_ID))
        sbSQL.Append(" ,SrcT." & NameOf(_D003_NCR_J.JIZEN_SINSA_YMD) & " = WK." & NameOf(_D003_NCR_J.JIZEN_SINSA_YMD))
        sbSQL.Append(" ,SrcT." & NameOf(_D003_NCR_J.SAISIN_KAKUNIN_SYAIN_ID) & " = WK." & NameOf(_D003_NCR_J.SAISIN_KAKUNIN_SYAIN_ID))
        sbSQL.Append(" ,SrcT." & NameOf(_D003_NCR_J.SAISIN_KAKUNIN_YMD) & " = WK." & NameOf(_D003_NCR_J.SAISIN_KAKUNIN_YMD))
        sbSQL.Append(" ,SrcT." & NameOf(_D003_NCR_J.SAISIN_IINKAI_HANTEI_KB) & " = WK." & NameOf(_D003_NCR_J.SAISIN_IINKAI_HANTEI_KB))
        sbSQL.Append(" ,SrcT." & NameOf(_D003_NCR_J.SAISIN_GIJYUTU_SYAIN_ID) & " = WK." & NameOf(_D003_NCR_J.SAISIN_GIJYUTU_SYAIN_ID))
        sbSQL.Append(" ,SrcT." & NameOf(_D003_NCR_J.SAISIN_GIJYUTU_YMD) & " = WK." & NameOf(_D003_NCR_J.SAISIN_GIJYUTU_YMD))
        sbSQL.Append(" ,SrcT." & NameOf(_D003_NCR_J.SAISIN_HINSYO_SYAIN_ID) & " = WK." & NameOf(_D003_NCR_J.SAISIN_HINSYO_SYAIN_ID))
        sbSQL.Append(" ,SrcT." & NameOf(_D003_NCR_J.SAISIN_HINSYO_YMD) & " = WK." & NameOf(_D003_NCR_J.SAISIN_HINSYO_YMD))
        sbSQL.Append(" ,SrcT." & NameOf(_D003_NCR_J.SAISIN_IINKAI_SIRYO_NO) & " = WK." & NameOf(_D003_NCR_J.SAISIN_IINKAI_SIRYO_NO))
        sbSQL.Append(" ,SrcT." & NameOf(_D003_NCR_J.ITAG_NO) & " = WK." & NameOf(_D003_NCR_J.ITAG_NO))
        sbSQL.Append(" ,SrcT." & NameOf(_D003_NCR_J.KOKYAKU_SAISIN_TANTO_ID) & " = WK." & NameOf(_D003_NCR_J.KOKYAKU_SAISIN_TANTO_ID))
        sbSQL.Append(" ,SrcT." & NameOf(_D003_NCR_J.KOKYAKU_SAISIN_YMD) & " = WK." & NameOf(_D003_NCR_J.KOKYAKU_SAISIN_YMD))
        sbSQL.Append(" ,SrcT." & NameOf(_D003_NCR_J.KOKYAKU_HANTEI_SIJI_KB) & " = WK." & NameOf(_D003_NCR_J.KOKYAKU_HANTEI_SIJI_KB))
        sbSQL.Append(" ,SrcT." & NameOf(_D003_NCR_J.KOKYAKU_HANTEI_SIJI_YMD) & " = WK." & NameOf(_D003_NCR_J.KOKYAKU_HANTEI_SIJI_YMD))
        sbSQL.Append(" ,SrcT." & NameOf(_D003_NCR_J.KOKYAKU_SAISYU_HANTEI_KB) & " = WK." & NameOf(_D003_NCR_J.KOKYAKU_SAISYU_HANTEI_KB))
        sbSQL.Append(" ,SrcT." & NameOf(_D003_NCR_J.KOKYAKU_SAISYU_HANTEI_YMD) & " = WK." & NameOf(_D003_NCR_J.KOKYAKU_SAISYU_HANTEI_YMD))
        sbSQL.Append(" ,SrcT." & NameOf(_D003_NCR_J.SAIKAKO_SIJI_FG) & " = WK." & NameOf(_D003_NCR_J.SAIKAKO_SIJI_FG))
        sbSQL.Append(" ,SrcT." & NameOf(_D003_NCR_J.HAIKYAKU_YMD) & " = WK." & NameOf(_D003_NCR_J.HAIKYAKU_YMD))
        sbSQL.Append(" ,SrcT." & NameOf(_D003_NCR_J.HAIKYAKU_KB) & " = WK." & NameOf(_D003_NCR_J.HAIKYAKU_KB))
        sbSQL.Append(" ,SrcT." & NameOf(_D003_NCR_J.HAIKYAKU_HOUHOU) & " = WK." & NameOf(_D003_NCR_J.HAIKYAKU_HOUHOU))
        sbSQL.Append(" ,SrcT." & NameOf(_D003_NCR_J.HAIKYAKU_TANTO_ID) & " = WK." & NameOf(_D003_NCR_J.HAIKYAKU_TANTO_ID))
        sbSQL.Append(" ,SrcT." & NameOf(_D003_NCR_J.SAIKAKO_SIJI_NO) & " = WK." & NameOf(_D003_NCR_J.SAIKAKO_SIJI_NO))
        sbSQL.Append(" ,SrcT." & NameOf(_D003_NCR_J.SAIKAKO_SAGYO_KAN_YMD) & " = WK." & NameOf(_D003_NCR_J.SAIKAKO_SAGYO_KAN_YMD))
        sbSQL.Append(" ,SrcT." & NameOf(_D003_NCR_J.SAIKAKO_KENSA_YMD) & " = WK." & NameOf(_D003_NCR_J.SAIKAKO_KENSA_YMD))
        sbSQL.Append(" ,SrcT." & NameOf(_D003_NCR_J.KENSA_KEKKA_KB) & " = WK." & NameOf(_D003_NCR_J.KENSA_KEKKA_KB))
        sbSQL.Append(" ,SrcT." & NameOf(_D003_NCR_J.SEIGI_TANTO_ID) & " = WK." & NameOf(_D003_NCR_J.SEIGI_TANTO_ID))
        sbSQL.Append(" ,SrcT." & NameOf(_D003_NCR_J.SEIZO_TANTO_ID) & " = WK." & NameOf(_D003_NCR_J.SEIZO_TANTO_ID))
        sbSQL.Append(" ,SrcT." & NameOf(_D003_NCR_J.KENSA_TANTO_ID) & " = WK." & NameOf(_D003_NCR_J.KENSA_TANTO_ID))
        sbSQL.Append(" ,SrcT." & NameOf(_D003_NCR_J.HENKYAKU_YMD) & " = WK." & NameOf(_D003_NCR_J.HENKYAKU_YMD))
        sbSQL.Append(" ,SrcT." & NameOf(_D003_NCR_J.HENKYAKU_SAKI) & " = WK." & NameOf(_D003_NCR_J.HENKYAKU_SAKI))
        sbSQL.Append(" ,SrcT." & NameOf(_D003_NCR_J.HENKYAKU_TANTO_ID) & " = WK." & NameOf(_D003_NCR_J.HENKYAKU_TANTO_ID))
        sbSQL.Append(" ,SrcT." & NameOf(_D003_NCR_J.HENKYAKU_BIKO) & " = WK." & NameOf(_D003_NCR_J.HENKYAKU_BIKO))
        sbSQL.Append(" ,SrcT." & NameOf(_D003_NCR_J.TENYO_KISYU_ID) & " = WK." & NameOf(_D003_NCR_J.TENYO_KISYU_ID))
        sbSQL.Append(" ,SrcT." & NameOf(_D003_NCR_J.TENYO_BUHIN_BANGO) & " = WK." & NameOf(_D003_NCR_J.TENYO_BUHIN_BANGO))
        sbSQL.Append(" ,SrcT." & NameOf(_D003_NCR_J.TENYO_GOKI) & " = WK." & NameOf(_D003_NCR_J.TENYO_GOKI))
        sbSQL.Append(" ,SrcT." & NameOf(_D003_NCR_J.TENYO_LOT) & " = WK." & NameOf(_D003_NCR_J.TENYO_LOT))
        sbSQL.Append(" ,SrcT." & NameOf(_D003_NCR_J.TENYO_YMD) & " = WK." & NameOf(_D003_NCR_J.TENYO_YMD))
        sbSQL.Append(" ,SrcT." & NameOf(_D003_NCR_J.SYOCHI_KEKKA_A) & " = WK." & NameOf(_D003_NCR_J.SYOCHI_KEKKA_A))
        sbSQL.Append(" ,SrcT." & NameOf(_D003_NCR_J.SYOCHI_KEKKA_B) & " = WK." & NameOf(_D003_NCR_J.SYOCHI_KEKKA_B))
        sbSQL.Append(" ,SrcT." & NameOf(_D003_NCR_J.SYOCHI_KEKKA_C) & " = WK." & NameOf(_D003_NCR_J.SYOCHI_KEKKA_C))
        sbSQL.Append(" ,SrcT." & NameOf(_D003_NCR_J.SYOCHI_D_UMU_KB) & " = WK." & NameOf(_D003_NCR_J.SYOCHI_D_UMU_KB))
        sbSQL.Append(" ,SrcT." & NameOf(_D003_NCR_J.SYOCHI_D_YOHI_KB) & " = WK." & NameOf(_D003_NCR_J.SYOCHI_D_YOHI_KB))
        sbSQL.Append(" ,SrcT." & NameOf(_D003_NCR_J.SYOCHI_D_SYOCHI_KIROKU) & " = WK." & NameOf(_D003_NCR_J.SYOCHI_D_SYOCHI_KIROKU))
        sbSQL.Append(" ,SrcT." & NameOf(_D003_NCR_J.SYOCHI_E_UMU_KB) & " = WK." & NameOf(_D003_NCR_J.SYOCHI_E_UMU_KB))
        sbSQL.Append(" ,SrcT." & NameOf(_D003_NCR_J.SYOCHI_E_YOHI_KB) & " = WK." & NameOf(_D003_NCR_J.SYOCHI_E_YOHI_KB))
        sbSQL.Append(" ,SrcT." & NameOf(_D003_NCR_J.SYOCHI_E_SYOCHI_KIROKU) & " = WK." & NameOf(_D003_NCR_J.SYOCHI_E_SYOCHI_KIROKU))

        sbSQL.Append(" ,SrcT." & NameOf(_D003_NCR_J.FILE_PATH) & " = WK." & NameOf(_D003_NCR_J.FILE_PATH))
        sbSQL.Append(" ,SrcT." & NameOf(_D003_NCR_J.G_FILE_PATH1) & " = WK." & NameOf(_D003_NCR_J.G_FILE_PATH1))
        sbSQL.Append(" ,SrcT." & NameOf(_D003_NCR_J.G_FILE_PATH2) & " = WK." & NameOf(_D003_NCR_J.G_FILE_PATH2))
        sbSQL.Append(" ,SrcT." & NameOf(_D003_NCR_J.UPD_SYAIN_ID) & " = WK." & NameOf(_D003_NCR_J.UPD_SYAIN_ID))
        sbSQL.Append(" ,SrcT." & NameOf(_D003_NCR_J.UPD_YMDHNS) & " = dbo.GetSysDateString()")

        'INSERT
        sbSQL.Append(" WHEN NOT MATCHED THEN ")
        sbSQL.Append(" INSERT(")
        sbSQL.Append("  " & NameOf(_D003_NCR_J.HOKOKU_NO))
        sbSQL.Append(" ," & NameOf(_D003_NCR_J.BUMON_KB))
        sbSQL.Append(" ," & NameOf(_D003_NCR_J.CLOSE_FG))
        sbSQL.Append(" ," & NameOf(_D003_NCR_J.KISYU_ID))
        sbSQL.Append(" ," & NameOf(_D003_NCR_J.SYANAI_CD))
        sbSQL.Append(" ," & NameOf(_D003_NCR_J.BUHIN_BANGO))
        sbSQL.Append(" ," & NameOf(_D003_NCR_J.BUHIN_NAME))
        sbSQL.Append(" ," & NameOf(_D003_NCR_J.GOKI))
        sbSQL.Append(" ," & NameOf(_D003_NCR_J.SURYO))
        sbSQL.Append(" ," & NameOf(_D003_NCR_J.SAIHATU))
        sbSQL.Append(" ," & NameOf(_D003_NCR_J.FUTEKIGO_JYOTAI_KB))
        sbSQL.Append(" ," & NameOf(_D003_NCR_J.FUTEKIGO_NAIYO))
        sbSQL.Append(" ," & NameOf(_D003_NCR_J.FUTEKIGO_KB))
        sbSQL.Append(" ," & NameOf(_D003_NCR_J.FUTEKIGO_S_KB))
        sbSQL.Append(" ," & NameOf(_D003_NCR_J.ZUMEN_KIKAKU))
        sbSQL.Append(" ," & NameOf(_D003_NCR_J.YOKYU_NAIYO))
        sbSQL.Append(" ," & NameOf(_D003_NCR_J.KANSATU_KEKKA))
        '---defaultValue
        sbSQL.Append(" ," & NameOf(_D003_NCR_J.ZESEI_SYOCHI_YOHI_KB))
        sbSQL.Append(" ," & NameOf(_D003_NCR_J.ZESEI_NASI_RIYU))
        sbSQL.Append(" ," & NameOf(_D003_NCR_J.JIZEN_SINSA_HANTEI_KB))
        sbSQL.Append(" ," & NameOf(_D003_NCR_J.JIZEN_SINSA_SYAIN_ID))
        sbSQL.Append(" ," & NameOf(_D003_NCR_J.JIZEN_SINSA_YMD))
        sbSQL.Append(" ," & NameOf(_D003_NCR_J.SAISIN_KAKUNIN_SYAIN_ID))
        sbSQL.Append(" ," & NameOf(_D003_NCR_J.SAISIN_KAKUNIN_YMD))
        sbSQL.Append(" ," & NameOf(_D003_NCR_J.SAISIN_IINKAI_HANTEI_KB))
        sbSQL.Append(" ," & NameOf(_D003_NCR_J.SAISIN_GIJYUTU_SYAIN_ID))
        sbSQL.Append(" ," & NameOf(_D003_NCR_J.SAISIN_GIJYUTU_YMD))
        sbSQL.Append(" ," & NameOf(_D003_NCR_J.SAISIN_HINSYO_SYAIN_ID))
        sbSQL.Append(" ," & NameOf(_D003_NCR_J.SAISIN_HINSYO_YMD))
        sbSQL.Append(" ," & NameOf(_D003_NCR_J.SAISIN_IINKAI_SIRYO_NO))
        sbSQL.Append(" ," & NameOf(_D003_NCR_J.ITAG_NO))
        sbSQL.Append(" ," & NameOf(_D003_NCR_J.KOKYAKU_SAISIN_TANTO_ID))
        sbSQL.Append(" ," & NameOf(_D003_NCR_J.KOKYAKU_SAISIN_YMD))
        sbSQL.Append(" ," & NameOf(_D003_NCR_J.KOKYAKU_HANTEI_SIJI_KB))
        sbSQL.Append(" ," & NameOf(_D003_NCR_J.KOKYAKU_HANTEI_SIJI_YMD))
        sbSQL.Append(" ," & NameOf(_D003_NCR_J.KOKYAKU_SAISYU_HANTEI_KB))
        sbSQL.Append(" ," & NameOf(_D003_NCR_J.KOKYAKU_SAISYU_HANTEI_YMD))
        sbSQL.Append(" ," & NameOf(_D003_NCR_J.SAIKAKO_SIJI_FG))
        sbSQL.Append(" ," & NameOf(_D003_NCR_J.HAIKYAKU_YMD))
        sbSQL.Append(" ," & NameOf(_D003_NCR_J.HAIKYAKU_KB))
        sbSQL.Append(" ," & NameOf(_D003_NCR_J.HAIKYAKU_HOUHOU))
        sbSQL.Append(" ," & NameOf(_D003_NCR_J.HAIKYAKU_TANTO_ID))
        sbSQL.Append(" ," & NameOf(_D003_NCR_J.SAIKAKO_SIJI_NO))
        sbSQL.Append(" ," & NameOf(_D003_NCR_J.SAIKAKO_SAGYO_KAN_YMD))
        sbSQL.Append(" ," & NameOf(_D003_NCR_J.SAIKAKO_KENSA_YMD))
        sbSQL.Append(" ," & NameOf(_D003_NCR_J.KENSA_KEKKA_KB))
        sbSQL.Append(" ," & NameOf(_D003_NCR_J.SEIGI_TANTO_ID))
        sbSQL.Append(" ," & NameOf(_D003_NCR_J.SEIZO_TANTO_ID))
        sbSQL.Append(" ," & NameOf(_D003_NCR_J.KENSA_TANTO_ID))
        sbSQL.Append(" ," & NameOf(_D003_NCR_J.HENKYAKU_YMD))
        sbSQL.Append(" ," & NameOf(_D003_NCR_J.HENKYAKU_SAKI))
        sbSQL.Append(" ," & NameOf(_D003_NCR_J.HENKYAKU_TANTO_ID))
        sbSQL.Append(" ," & NameOf(_D003_NCR_J.HENKYAKU_BIKO))
        sbSQL.Append(" ," & NameOf(_D003_NCR_J.TENYO_KISYU_ID))
        sbSQL.Append(" ," & NameOf(_D003_NCR_J.TENYO_BUHIN_BANGO))
        sbSQL.Append(" ," & NameOf(_D003_NCR_J.TENYO_GOKI))
        sbSQL.Append(" ," & NameOf(_D003_NCR_J.TENYO_LOT))
        sbSQL.Append(" ," & NameOf(_D003_NCR_J.TENYO_YMD))
        sbSQL.Append(" ," & NameOf(_D003_NCR_J.SYOCHI_KEKKA_A))
        sbSQL.Append(" ," & NameOf(_D003_NCR_J.SYOCHI_KEKKA_B))
        sbSQL.Append(" ," & NameOf(_D003_NCR_J.SYOCHI_KEKKA_C))
        sbSQL.Append(" ," & NameOf(_D003_NCR_J.SYOCHI_D_UMU_KB))
        sbSQL.Append(" ," & NameOf(_D003_NCR_J.SYOCHI_D_YOHI_KB))
        sbSQL.Append(" ," & NameOf(_D003_NCR_J.SYOCHI_D_SYOCHI_KIROKU))
        sbSQL.Append(" ," & NameOf(_D003_NCR_J.SYOCHI_E_UMU_KB))
        sbSQL.Append(" ," & NameOf(_D003_NCR_J.SYOCHI_E_YOHI_KB))
        sbSQL.Append(" ," & NameOf(_D003_NCR_J.SYOCHI_E_SYOCHI_KIROKU))
        '---
        sbSQL.Append(" ," & NameOf(_D003_NCR_J.FILE_PATH))
        sbSQL.Append(" ," & NameOf(_D003_NCR_J.G_FILE_PATH1))
        sbSQL.Append(" ," & NameOf(_D003_NCR_J.G_FILE_PATH2))
        sbSQL.Append(" ," & NameOf(_D003_NCR_J.ADD_SYAIN_ID))
        sbSQL.Append(" ," & NameOf(_D003_NCR_J.ADD_YMDHNS))
        sbSQL.Append(" ," & NameOf(_D003_NCR_J.UPD_SYAIN_ID))
        sbSQL.Append(" ," & NameOf(_D003_NCR_J.UPD_YMDHNS))
        sbSQL.Append(" ," & NameOf(_D003_NCR_J.DEL_SYAIN_ID))
        sbSQL.Append(" ," & NameOf(_D003_NCR_J.DEL_YMDHNS))
        sbSQL.Append(" ) VALUES(")
        sbSQL.Append("  WK." & NameOf(_D003_NCR_J.HOKOKU_NO))
        sbSQL.Append(" ,WK." & NameOf(_D003_NCR_J.BUMON_KB))
        sbSQL.Append(" ,WK." & NameOf(_D003_NCR_J.CLOSE_FG))
        sbSQL.Append(" ,WK." & NameOf(_D003_NCR_J.KISYU_ID))
        sbSQL.Append(" ,WK." & NameOf(_D003_NCR_J.SYANAI_CD))
        sbSQL.Append(" ,WK." & NameOf(_D003_NCR_J.BUHIN_BANGO))
        sbSQL.Append(" ,WK." & NameOf(_D003_NCR_J.BUHIN_NAME))
        sbSQL.Append(" ,WK." & NameOf(_D003_NCR_J.GOKI))
        sbSQL.Append(" ,WK." & NameOf(_D003_NCR_J.SURYO))
        sbSQL.Append(" ,WK." & NameOf(_D003_NCR_J.SAIHATU))
        sbSQL.Append(" ,WK." & NameOf(_D003_NCR_J.FUTEKIGO_JYOTAI_KB))
        sbSQL.Append(" ,WK." & NameOf(_D003_NCR_J.FUTEKIGO_NAIYO))
        sbSQL.Append(" ,WK." & NameOf(_D003_NCR_J.FUTEKIGO_KB))
        sbSQL.Append(" ,WK." & NameOf(_D003_NCR_J.FUTEKIGO_S_KB))
        sbSQL.Append(" ,WK." & NameOf(_D003_NCR_J.ZUMEN_KIKAKU))
        sbSQL.Append(" ,WK." & NameOf(_D003_NCR_J.YOKYU_NAIYO))
        sbSQL.Append(" ,WK." & NameOf(_D003_NCR_J.KANSATU_KEKKA))
        '---defaultValue
        sbSQL.Append(" ,'0'") 'sbSQL.Append(" ," & NameOf(_D003_NCR_J.ZESEI_SYOCHI_YOHI_KB))
        sbSQL.Append(" ,''") 'sbSQL.Append(" ," & NameOf(_D003_NCR_J.ZESEI_NASI_RIYU))
        sbSQL.Append(" ,' '") 'sbSQL.Append(" ," & NameOf(_D003_NCR_J.JIZEN_SINSA_HANTEI_KB))
        sbSQL.Append(" ,0") 'sbSQL.Append(" ," & NameOf(_D003_NCR_J.JIZEN_SINSA_SYAIN_ID))
        sbSQL.Append(" ,''") 'sbSQL.Append(" ," & NameOf(_D003_NCR_J.JIZEN_SINSA_YMD))
        sbSQL.Append(" ,0") 'sbSQL.Append(" ," & NameOf(_D003_NCR_J.SAISIN_KAKUNIN_SYAIN_ID))
        sbSQL.Append(" ,''") 'sbSQL.Append(" ," & NameOf(_D003_NCR_J.SAISIN_KAKUNIN_YMD))
        sbSQL.Append(" ,''") 'sbSQL.Append(" ," & NameOf(_D003_NCR_J.SAISIN_IINKAI_HANTEI_KB))
        sbSQL.Append(" ,0") 'sbSQL.Append(" ," & NameOf(_D003_NCR_J.SAISIN_GIJYUTU_SYAIN_ID))
        sbSQL.Append(" ,''") 'sbSQL.Append(" ," & NameOf(_D003_NCR_J.SAISIN_GIJYUTU_YMD))
        sbSQL.Append(" ,0") 'sbSQL.Append(" ," & NameOf(_D003_NCR_J.SAISIN_HINSYO_SYAIN_ID))
        sbSQL.Append(" ,''") 'sbSQL.Append(" ," & NameOf(_D003_NCR_J.SAISIN_HINSYO_YMD))
        sbSQL.Append(" ,''") 'sbSQL.Append(" ," & NameOf(_D003_NCR_J.SAISIN_IINKAI_SIRYO_NO))
        sbSQL.Append(" ,''") 'sbSQL.Append(" ," & NameOf(_D003_NCR_J.ITAG_NO))
        sbSQL.Append(" ,0") 'sbSQL.Append(" ," & NameOf(_D003_NCR_J.KOKYAKU_SAISIN_TANTO_ID))
        sbSQL.Append(" ,''") 'sbSQL.Append(" ," & NameOf(_D003_NCR_J.KOKYAKU_SAISIN_YMD))
        sbSQL.Append(" ,''") 'sbSQL.Append(" ," & NameOf(_D003_NCR_J.KOKYAKU_HANTEI_SIJI_KB))
        sbSQL.Append(" ,''") 'sbSQL.Append(" ," & NameOf(_D003_NCR_J.KOKYAKU_HANTEI_SIJI_YMD))
        sbSQL.Append(" ,''") 'sbSQL.Append(" ," & NameOf(_D003_NCR_J.KOKYAKU_SAISYU_HANTEI_KB))
        sbSQL.Append(" ,''") 'sbSQL.Append(" ," & NameOf(_D003_NCR_J.KOKYAKU_SAISYU_HANTEI_YMD))
        sbSQL.Append(" ,'0'") 'sbSQL.Append(" ," & NameOf(_D003_NCR_J.SAIKAKO_SIJI_FG))
        sbSQL.Append(" ,''") 'sbSQL.Append(" ," & NameOf(_D003_NCR_J.HAIKYAKU_YMD))
        sbSQL.Append(" ,''") 'sbSQL.Append(" ," & NameOf(_D003_NCR_J.HAIKYAKU_KB))
        sbSQL.Append(" ,''") 'sbSQL.Append(" ," & NameOf(_D003_NCR_J.HAIKYAKU_HOUHOU))
        sbSQL.Append(" ,0") 'sbSQL.Append(" ," & NameOf(_D003_NCR_J.HAIKYAKU_TANTO_ID))
        sbSQL.Append(" ,''") 'sbSQL.Append(" ," & NameOf(_D003_NCR_J.SAIKAKO_SIJI_NO))
        sbSQL.Append(" ,''") 'sbSQL.Append(" ," & NameOf(_D003_NCR_J.SAIKAKO_SAGYO_KAN_YMD))
        sbSQL.Append(" ,''") 'sbSQL.Append(" ," & NameOf(_D003_NCR_J.SAIKAKO_KENSA_YMD))
        sbSQL.Append(" ,''") 'sbSQL.Append(" ," & NameOf(_D003_NCR_J.KENSA_KEKKA_KB))
        sbSQL.Append(" ,0") 'sbSQL.Append(" ," & NameOf(_D003_NCR_J.SEIGI_TANTO_ID))
        sbSQL.Append(" ,0") 'sbSQL.Append(" ," & NameOf(_D003_NCR_J.SEIZO_TANTO_ID))
        sbSQL.Append(" ,0") 'sbSQL.Append(" ," & NameOf(_D003_NCR_J.KENSA_TANTO_ID))
        sbSQL.Append(" ,''") 'sbSQL.Append(" ," & NameOf(_D003_NCR_J.HENKYAKU_YMD))
        sbSQL.Append(" ,''") 'sbSQL.Append(" ," & NameOf(_D003_NCR_J.HENKYAKU_SAKI))
        sbSQL.Append(" ,0") 'sbSQL.Append(" ," & NameOf(_D003_NCR_J.HENKYAKU_TANTO_ID))
        sbSQL.Append(" ,''") 'sbSQL.Append(" ," & NameOf(_D003_NCR_J.HENKYAKU_BIKO))
        sbSQL.Append(" ,0") 'sbSQL.Append(" ," & NameOf(_D003_NCR_J.TENYO_KISYU_ID))
        sbSQL.Append(" ,''") 'sbSQL.Append(" ," & NameOf(_D003_NCR_J.TENYO_BUHIN_BANGO))
        sbSQL.Append(" ,''") 'sbSQL.Append(" ," & NameOf(_D003_NCR_J.TENYO_GOKI))
        sbSQL.Append(" ,0") 'sbSQL.Append(" ," & NameOf(_D003_NCR_J.TENYO_LOT))
        sbSQL.Append(" ,''") 'sbSQL.Append(" ," & NameOf(_D003_NCR_J.TENYO_YMD))
        sbSQL.Append(" ,'0'") 'sbSQL.Append(" ," & NameOf(_D003_NCR_J.SYOCHI_KEKKA_A))
        sbSQL.Append(" ,'0'") 'sbSQL.Append(" ," & NameOf(_D003_NCR_J.SYOCHI_KEKKA_B))
        sbSQL.Append(" ,'0'") 'sbSQL.Append(" ," & NameOf(_D003_NCR_J.SYOCHI_KEKKA_C))
        sbSQL.Append(" ,'0'") 'sbSQL.Append(" ," & NameOf(_D003_NCR_J.SYOCHI_D_UMU_KB))
        sbSQL.Append(" ,'0'") 'sbSQL.Append(" ," & NameOf(_D003_NCR_J.SYOCHI_D_YOHI_KB))
        sbSQL.Append(" ,''") 'sbSQL.Append(" ," & NameOf(_D003_NCR_J.SYOCHI_D_SYOCHI_KIROKU))
        sbSQL.Append(" ,'0'") 'sbSQL.Append(" ," & NameOf(_D003_NCR_J.SYOCHI_E_UMU_KB))
        sbSQL.Append(" ,'0'") 'sbSQL.Append(" ," & NameOf(_D003_NCR_J.SYOCHI_E_YOHI_KB))
        sbSQL.Append(" ,''") 'sbSQL.Append(" ," & NameOf(_D003_NCR_J.SYOCHI_E_SYOCHI_KIROKU))
        '---
        sbSQL.Append(" ,WK." & NameOf(_D003_NCR_J.FILE_PATH))
        sbSQL.Append(" ,WK." & NameOf(_D003_NCR_J.G_FILE_PATH1))
        sbSQL.Append(" ,WK." & NameOf(_D003_NCR_J.G_FILE_PATH2))
        sbSQL.Append(" ,WK." & NameOf(_D003_NCR_J.ADD_SYAIN_ID))
        sbSQL.Append(" ,dbo.GetSysDateString()") 'ADD_YMDHNS
        sbSQL.Append(" ,WK." & NameOf(_D003_NCR_J.UPD_SYAIN_ID))
        sbSQL.Append(" ,WK." & NameOf(_D003_NCR_J.UPD_YMDHNS))
        sbSQL.Append(" ,WK." & NameOf(_D003_NCR_J.DEL_SYAIN_ID))
        sbSQL.Append(" ,WK." & NameOf(_D003_NCR_J.DEL_YMDHNS))
        sbSQL.Append(" )")
        sbSQL.Append("OUTPUT $action AS RESULT") 'INSERT OR UPDATE ��ncarchar(10)�Ŏ擾����ꍇ
        sbSQL.Append(";")
        strRET = DB.ExecuteScalar(sbSQL.ToString, conblnNonMsg, sqlEx)
        Select Case strRET
            Case "INSERT"

            Case "UPDATE"

            Case Else
                If sqlEx.Source IsNot Nothing Then
                    '-----�G���[���O�o��
                    Dim strErrMsg As String = My.Resources.ErrLogSqlExecutionFailure & sbSQL.ToString & "|" & sqlEx.Message
                    WL.WriteLogDat(strErrMsg)
                Else
                    '---�r������
                    Dim strMsg As String
                    strMsg = "���ɑ��̒S���҂ɂ���ĕύX����Ă��邽�ߕۑ��o���܂���B" & vbCrLf &
                                "�ēx�o�^�������ĉ������B"

                    MessageBox.Show(strMsg, "�����X�V����", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                End If
                Return False
        End Select

        Return True
    End Function

    ''' <summary>
    ''' ���F���ъǗ��X�V
    ''' </summary>
    ''' <param name="DB"></param>
    ''' <param name="enmSAVE_MODE"></param>
    ''' <returns></returns>
    Private Function FunSAVE_D004(ByRef DB As ClsDbUtility, ByVal enmSAVE_MODE As ENM_SAVE_MODE) As Boolean
        Dim sbSQL As New System.Text.StringBuilder
        Dim strRET As String
        Dim sqlEx As New Exception

        '-----�f�[�^���f���X�V
        _D004_SYONIN_J_KANRI.SYONIN_HOKOKUSYO_ID = ENM_SYONIN_HOKOKUSYO_ID._1_NCR
        _D004_SYONIN_J_KANRI.HOKOKU_NO = _D003_NCR_J.HOKOKU_NO
        _D004_SYONIN_J_KANRI.MAIL_SEND_FG = True
        _D004_SYONIN_J_KANRI.ADD_SYAIN_ID = pub_SYAIN_INFO.SYAIN_ID
        '-----���R�[�h�ۑ�
        Select Case enmSAVE_MODE
            Case ENM_SAVE_MODE._1_�ۑ�
                _D004_SYONIN_J_KANRI.SYONIN_JUN = PrCurrentStage
                _D004_SYONIN_J_KANRI.SYONIN_HANTEI_KB = ENM_SYONIN_HANTEI_KB._0_�����F
                _D004_SYONIN_J_KANRI.SYAIN_ID = pub_SYAIN_INFO.SYAIN_ID
            Case ENM_SAVE_MODE._2_���F�\��
                _D004_SYONIN_J_KANRI.SYONIN_JUN = PrCurrentStage
                _D004_SYONIN_J_KANRI.SYONIN_HANTEI_KB = ENM_SYONIN_HANTEI_KB._1_���F
                'UNDONE: getsysdate server
                _D004_SYONIN_J_KANRI.SYONIN_YMDHNS = Now.ToString("yyyyMMddHHmmss")
            Case Else
                'Err
                Return False
        End Select

        '-----MERGE
        sbSQL.Remove(0, sbSQL.Length)
        sbSQL.Append("MERGE INTO " & NameOf(MODEL.D004_SYONIN_J_KANRI) & " AS SrcT")
        sbSQL.Append(" USING (")
        sbSQL.Append(" SELECT")
        sbSQL.Append(" " & _D004_SYONIN_J_KANRI.SYONIN_HOKOKUSYO_ID & " AS " & NameOf(_D004_SYONIN_J_KANRI.SYONIN_HOKOKUSYO_ID))
        sbSQL.Append(" ,'" & _D004_SYONIN_J_KANRI.HOKOKU_NO & "' AS " & NameOf(_D004_SYONIN_J_KANRI.HOKOKU_NO))
        sbSQL.Append(" ," & _D004_SYONIN_J_KANRI.SYONIN_JUN & " AS " & NameOf(_D004_SYONIN_J_KANRI.SYONIN_JUN))
        sbSQL.Append(" ,'" & _D004_SYONIN_J_KANRI.SYAIN_ID & "' AS " & NameOf(_D004_SYONIN_J_KANRI.SYAIN_ID))
        sbSQL.Append(" ,'" & _D004_SYONIN_J_KANRI.SYONIN_YMDHNS & "' AS " & NameOf(_D004_SYONIN_J_KANRI.SYONIN_YMDHNS))
        sbSQL.Append(" ,'" & _D004_SYONIN_J_KANRI.SYONIN_HANTEI_KB & "' AS " & NameOf(_D004_SYONIN_J_KANRI.SYONIN_HANTEI_KB))
        sbSQL.Append(" ,'" & _D004_SYONIN_J_KANRI._SASIMODOSI_FG & "' AS " & NameOf(_D004_SYONIN_J_KANRI.SASIMODOSI_FG))
        sbSQL.Append(" ,'" & _D004_SYONIN_J_KANRI.RIYU & "' AS " & NameOf(_D004_SYONIN_J_KANRI.RIYU))
        sbSQL.Append(" ,'" & _D004_SYONIN_J_KANRI.COMMENT & "' AS " & NameOf(_D004_SYONIN_J_KANRI.COMMENT))
        sbSQL.Append(" ,'" & _D004_SYONIN_J_KANRI._MAIL_SEND_FG & "' AS " & NameOf(_D004_SYONIN_J_KANRI.MAIL_SEND_FG))
        sbSQL.Append(" ," & _D004_SYONIN_J_KANRI.ADD_SYAIN_ID & " AS " & NameOf(_D004_SYONIN_J_KANRI.ADD_SYAIN_ID))
        sbSQL.Append(" ,'" & _D004_SYONIN_J_KANRI.ADD_YMDHNS & "' AS " & NameOf(_D004_SYONIN_J_KANRI.ADD_YMDHNS))
        sbSQL.Append(" ," & pub_SYAIN_INFO.SYAIN_ID & " AS " & NameOf(_D004_SYONIN_J_KANRI.UPD_SYAIN_ID))
        sbSQL.Append(" ,'" & _D004_SYONIN_J_KANRI.UPD_YMDHNS & "' AS " & NameOf(_D004_SYONIN_J_KANRI.UPD_YMDHNS))
        sbSQL.Append(" ) AS WK")
        sbSQL.Append(" ON (SrcT." & NameOf(_D004_SYONIN_J_KANRI.SYONIN_HOKOKUSYO_ID) & " = WK." & NameOf(_D004_SYONIN_J_KANRI.SYONIN_HOKOKUSYO_ID) & "")
        sbSQL.Append(" AND SrcT." & NameOf(_D004_SYONIN_J_KANRI.HOKOKU_NO) & " = WK." & NameOf(_D004_SYONIN_J_KANRI.HOKOKU_NO) & "")
        sbSQL.Append(" AND SrcT." & NameOf(_D004_SYONIN_J_KANRI.SYONIN_JUN) & " = WK." & NameOf(_D004_SYONIN_J_KANRI.SYONIN_JUN) & ")")
        'UPDATE
        '�r������ �X�V�������ύX����Ă���ꍇ�A�ύX����Ȃ��t�B�[���h����UPDATE�������s(=�����X�V���Ȃ�)
        sbSQL.Append(" WHEN MATCHED AND SrcT." & NameOf(_D004_SYONIN_J_KANRI.UPD_YMDHNS) & " = WK." & NameOf(_D004_SYONIN_J_KANRI.UPD_YMDHNS) & " THEN ")
        sbSQL.Append(" UPDATE SET")
        sbSQL.Append("  SrcT." & NameOf(_D004_SYONIN_J_KANRI.SYAIN_ID) & " = WK." & NameOf(_D004_SYONIN_J_KANRI.SYAIN_ID))
        sbSQL.Append(" ,SrcT." & NameOf(_D004_SYONIN_J_KANRI.UPD_SYAIN_ID) & " = WK." & NameOf(_D004_SYONIN_J_KANRI.UPD_SYAIN_ID))
        sbSQL.Append(" ,SrcT." & NameOf(_D004_SYONIN_J_KANRI.COMMENT) & " = WK." & NameOf(_D004_SYONIN_J_KANRI.COMMENT))
        sbSQL.Append(" ,SrcT." & NameOf(_D004_SYONIN_J_KANRI.UPD_YMDHNS) & " = dbo.GetSysDateString()")
        sbSQL.Append(" ,SrcT." & NameOf(_D004_SYONIN_J_KANRI.SASIMODOSI_FG) & " = WK." & NameOf(_D004_SYONIN_J_KANRI.SASIMODOSI_FG))
        sbSQL.Append(" ,SrcT." & NameOf(_D004_SYONIN_J_KANRI.SYONIN_YMDHNS) & " = WK." & NameOf(_D004_SYONIN_J_KANRI.SYONIN_YMDHNS))
        sbSQL.Append(" ,SrcT." & NameOf(_D004_SYONIN_J_KANRI.SYONIN_HANTEI_KB) & " = WK." & NameOf(_D004_SYONIN_J_KANRI.SYONIN_HANTEI_KB))
        sbSQL.Append(" ,SrcT." & NameOf(_D004_SYONIN_J_KANRI.MAIL_SEND_FG) & " = WK." & NameOf(_D004_SYONIN_J_KANRI.MAIL_SEND_FG))
        sbSQL.Append(" ,SrcT." & NameOf(_D004_SYONIN_J_KANRI.RIYU) & " = WK." & NameOf(_D004_SYONIN_J_KANRI.RIYU))
        'INSERT
        sbSQL.Append(" WHEN NOT MATCHED THEN ")
        sbSQL.Append(" INSERT(")
        sbSQL.Append("  " & NameOf(_D004_SYONIN_J_KANRI.SYONIN_HOKOKUSYO_ID))
        sbSQL.Append(" ," & NameOf(_D004_SYONIN_J_KANRI.HOKOKU_NO))
        sbSQL.Append(" ," & NameOf(_D004_SYONIN_J_KANRI.SYONIN_JUN))
        sbSQL.Append(" ," & NameOf(_D004_SYONIN_J_KANRI.SYAIN_ID))
        sbSQL.Append(" ," & NameOf(_D004_SYONIN_J_KANRI.SYONIN_YMDHNS))
        sbSQL.Append(" ," & NameOf(_D004_SYONIN_J_KANRI.SYONIN_HANTEI_KB))
        sbSQL.Append(" ," & NameOf(_D004_SYONIN_J_KANRI.SASIMODOSI_FG))
        sbSQL.Append(" ," & NameOf(_D004_SYONIN_J_KANRI.RIYU))
        sbSQL.Append(" ," & NameOf(_D004_SYONIN_J_KANRI.COMMENT))
        sbSQL.Append(" ," & NameOf(_D004_SYONIN_J_KANRI.MAIL_SEND_FG))
        sbSQL.Append(" ," & NameOf(_D004_SYONIN_J_KANRI.ADD_SYAIN_ID))
        sbSQL.Append(" ," & NameOf(_D004_SYONIN_J_KANRI.ADD_YMDHNS))
        sbSQL.Append(" ," & NameOf(_D004_SYONIN_J_KANRI.UPD_SYAIN_ID))
        sbSQL.Append(" ," & NameOf(_D004_SYONIN_J_KANRI.UPD_YMDHNS))
        sbSQL.Append(" ) VALUES(")
        sbSQL.Append("  WK." & NameOf(_D004_SYONIN_J_KANRI.SYONIN_HOKOKUSYO_ID))
        sbSQL.Append(" ,WK." & NameOf(_D004_SYONIN_J_KANRI.HOKOKU_NO))
        sbSQL.Append(" ,WK." & NameOf(_D004_SYONIN_J_KANRI.SYONIN_JUN))
        sbSQL.Append(" ,WK." & NameOf(_D004_SYONIN_J_KANRI.SYAIN_ID))
        sbSQL.Append(" ,WK." & NameOf(_D004_SYONIN_J_KANRI.SYONIN_YMDHNS))
        sbSQL.Append(" ,WK." & NameOf(_D004_SYONIN_J_KANRI.SYONIN_HANTEI_KB))
        sbSQL.Append(" ,WK." & NameOf(_D004_SYONIN_J_KANRI.SASIMODOSI_FG))
        sbSQL.Append(" ,WK." & NameOf(_D004_SYONIN_J_KANRI.RIYU))
        sbSQL.Append(" ,WK." & NameOf(_D004_SYONIN_J_KANRI.COMMENT))
        sbSQL.Append(" ,WK." & NameOf(_D004_SYONIN_J_KANRI.MAIL_SEND_FG))
        sbSQL.Append(" ,WK." & NameOf(_D004_SYONIN_J_KANRI.ADD_SYAIN_ID))
        sbSQL.Append(" ,WK." & NameOf(_D004_SYONIN_J_KANRI.ADD_YMDHNS))
        sbSQL.Append(" ,WK." & NameOf(_D004_SYONIN_J_KANRI.UPD_SYAIN_ID))
        sbSQL.Append(" ,WK." & NameOf(_D004_SYONIN_J_KANRI.UPD_YMDHNS))
        sbSQL.Append(" )")
        sbSQL.Append("OUTPUT $action AS RESULT") 'INSERT OR UPDATE ��ncarchar(10)�Ŏ擾����ꍇ
        sbSQL.Append(";")
        strRET = DB.ExecuteScalar(sbSQL.ToString, conblnNonMsg, sqlEx)
        Select Case strRET
            Case "INSERT"

            Case "UPDATE"

            Case Else
                If sqlEx.Source IsNot Nothing Then
                    '-----�G���[���O�o��
                    Dim strErrMsg As String = My.Resources.ErrLogSqlExecutionFailure & sbSQL.ToString & "|" & sqlEx.Message
                    WL.WriteLogDat(strErrMsg)
                Else
                    '---�r������
                    Dim strMsg As String
                    strMsg = "���ɑ��̒S���҂ɂ���ĕύX����Ă��邽�ߕۑ��o���܂���B" & vbCrLf &
                                "�ēx�o�^�������ĉ������B"

                    MessageBox.Show(strMsg, "�����X�V����", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                End If
                Return False
        End Select

        '-----���F�\��
        Select Case enmSAVE_MODE
            Case ENM_SAVE_MODE._1_�ۑ�
                '�ۑ����т̂�
                Return True
            Case ENM_SAVE_MODE._2_���F�\��
                _D004_SYONIN_J_KANRI.SYONIN_JUN = FunGetNextSYONIN_JUN(PrCurrentStage)

                If PrCurrentStage = ENM_NCR_STAGE._120_abcde���u�m�F Then
                    _D004_SYONIN_J_KANRI.SYAIN_ID = 0
                Else
                    _D004_SYONIN_J_KANRI.SYAIN_ID = FunGetNextSYONIN_TANTO_ID(PrCurrentStage)
                End If
                _D004_SYONIN_J_KANRI.SYONIN_YMDHNS = ""
                _D004_SYONIN_J_KANRI.RIYU = ""
                _D004_SYONIN_J_KANRI.COMMENT = ""
                _D004_SYONIN_J_KANRI.MAIL_SEND_FG = False

            Case Else
                'Err
                Return False
        End Select

        '-----���f���X�V
        Select Case PrCurrentStage
            Case ENM_NCR_STAGE._120_abcde���u�m�F
                _D004_SYONIN_J_KANRI.SYONIN_JUN = 999 'Close
                _D004_SYONIN_J_KANRI.SYONIN_HANTEI_KB = ENM_SYONIN_HANTEI_KB._1_���F
        End Select



        '-----MERGE
        sbSQL.Remove(0, sbSQL.Length)
        sbSQL.Append("MERGE INTO " & NameOf(MODEL.D004_SYONIN_J_KANRI) & " AS SrcT")
        sbSQL.Append(" USING (")
        sbSQL.Append(" SELECT")
        sbSQL.Append(" " & _D004_SYONIN_J_KANRI.SYONIN_HOKOKUSYO_ID & " AS " & NameOf(_D004_SYONIN_J_KANRI.SYONIN_HOKOKUSYO_ID))
        sbSQL.Append(" ,'" & _D004_SYONIN_J_KANRI.HOKOKU_NO & "' AS " & NameOf(_D004_SYONIN_J_KANRI.HOKOKU_NO))
        sbSQL.Append(" ," & _D004_SYONIN_J_KANRI.SYONIN_JUN & " AS " & NameOf(_D004_SYONIN_J_KANRI.SYONIN_JUN))
        sbSQL.Append(" ,'" & _D004_SYONIN_J_KANRI.SYAIN_ID & "' AS " & NameOf(_D004_SYONIN_J_KANRI.SYAIN_ID))
        sbSQL.Append(" ,'" & _D004_SYONIN_J_KANRI.SYONIN_YMDHNS & "' AS " & NameOf(_D004_SYONIN_J_KANRI.SYONIN_YMDHNS))
        sbSQL.Append(" ,'" & _D004_SYONIN_J_KANRI.SYONIN_HANTEI_KB & "' AS " & NameOf(_D004_SYONIN_J_KANRI.SYONIN_HANTEI_KB))
        sbSQL.Append(" ,'" & _D004_SYONIN_J_KANRI._SASIMODOSI_FG & "' AS " & NameOf(_D004_SYONIN_J_KANRI.SASIMODOSI_FG))
        sbSQL.Append(" ,'" & _D004_SYONIN_J_KANRI.RIYU & "' AS " & NameOf(_D004_SYONIN_J_KANRI.RIYU))
        sbSQL.Append(" ,'" & _D004_SYONIN_J_KANRI.COMMENT & "' AS " & NameOf(_D004_SYONIN_J_KANRI.COMMENT))
        sbSQL.Append(" ,'" & _D004_SYONIN_J_KANRI._MAIL_SEND_FG & "' AS " & NameOf(_D004_SYONIN_J_KANRI.MAIL_SEND_FG))
        sbSQL.Append(" ," & _D004_SYONIN_J_KANRI.ADD_SYAIN_ID & " AS " & NameOf(_D004_SYONIN_J_KANRI.ADD_SYAIN_ID))
        sbSQL.Append(" ,dbo.GetSysDateString() AS " & NameOf(_D004_SYONIN_J_KANRI.ADD_YMDHNS))
        sbSQL.Append(" ," & pub_SYAIN_INFO.SYAIN_ID & " AS " & NameOf(_D004_SYONIN_J_KANRI.UPD_SYAIN_ID))
        sbSQL.Append(" ,'" & _D004_SYONIN_J_KANRI.UPD_YMDHNS & "' AS " & NameOf(_D004_SYONIN_J_KANRI.UPD_YMDHNS))
        sbSQL.Append(" ) AS WK")
        sbSQL.Append(" ON (SrcT." & NameOf(_D004_SYONIN_J_KANRI.SYONIN_HOKOKUSYO_ID) & " = WK." & NameOf(_D004_SYONIN_J_KANRI.SYONIN_HOKOKUSYO_ID) & "")
        sbSQL.Append(" AND SrcT." & NameOf(_D004_SYONIN_J_KANRI.HOKOKU_NO) & " = WK." & NameOf(_D004_SYONIN_J_KANRI.HOKOKU_NO) & "")
        sbSQL.Append(" AND SrcT." & NameOf(_D004_SYONIN_J_KANRI.SYONIN_JUN) & " = WK." & NameOf(_D004_SYONIN_J_KANRI.SYONIN_JUN) & ")")

        'UPDATE �r������ �X�V�������ύX����Ă��Ȃ��ꍇ�̂�
        sbSQL.Append(" WHEN MATCHED AND SrcT." & NameOf(_D004_SYONIN_J_KANRI.UPD_YMDHNS) & " = WK." & NameOf(_D004_SYONIN_J_KANRI.UPD_YMDHNS) & " THEN ")
        sbSQL.Append(" UPDATE SET")
        sbSQL.Append("  SrcT." & NameOf(_D004_SYONIN_J_KANRI.SYAIN_ID) & " = WK." & NameOf(_D004_SYONIN_J_KANRI.SYAIN_ID))
        sbSQL.Append(" ,SrcT." & NameOf(_D004_SYONIN_J_KANRI.COMMENT) & " = WK." & NameOf(_D004_SYONIN_J_KANRI.COMMENT))
        sbSQL.Append(" ,SrcT." & NameOf(_D004_SYONIN_J_KANRI.UPD_SYAIN_ID) & " = WK." & NameOf(_D004_SYONIN_J_KANRI.UPD_SYAIN_ID))
        sbSQL.Append(" ,SrcT." & NameOf(_D004_SYONIN_J_KANRI.UPD_YMDHNS) & " = dbo.GetSysDateString()")
        'INSERT
        sbSQL.Append(" WHEN NOT MATCHED THEN ")
        sbSQL.Append(" INSERT(")
        sbSQL.Append("  " & NameOf(_D004_SYONIN_J_KANRI.SYONIN_HOKOKUSYO_ID))
        sbSQL.Append(" ," & NameOf(_D004_SYONIN_J_KANRI.HOKOKU_NO))
        sbSQL.Append(" ," & NameOf(_D004_SYONIN_J_KANRI.SYONIN_JUN))
        sbSQL.Append(" ," & NameOf(_D004_SYONIN_J_KANRI.SYAIN_ID))
        sbSQL.Append(" ," & NameOf(_D004_SYONIN_J_KANRI.SYONIN_YMDHNS))
        sbSQL.Append(" ," & NameOf(_D004_SYONIN_J_KANRI.SYONIN_HANTEI_KB))
        sbSQL.Append(" ," & NameOf(_D004_SYONIN_J_KANRI.SASIMODOSI_FG))
        sbSQL.Append(" ," & NameOf(_D004_SYONIN_J_KANRI.RIYU))
        sbSQL.Append(" ," & NameOf(_D004_SYONIN_J_KANRI.COMMENT))
        sbSQL.Append(" ," & NameOf(_D004_SYONIN_J_KANRI.MAIL_SEND_FG))
        sbSQL.Append(" ," & NameOf(_D004_SYONIN_J_KANRI.ADD_SYAIN_ID))
        sbSQL.Append(" ," & NameOf(_D004_SYONIN_J_KANRI.ADD_YMDHNS))
        sbSQL.Append(" ," & NameOf(_D004_SYONIN_J_KANRI.UPD_SYAIN_ID))
        sbSQL.Append(" ," & NameOf(_D004_SYONIN_J_KANRI.UPD_YMDHNS))
        sbSQL.Append(" ) VALUES(")
        sbSQL.Append("  WK." & NameOf(_D004_SYONIN_J_KANRI.SYONIN_HOKOKUSYO_ID))
        sbSQL.Append(" ,WK." & NameOf(_D004_SYONIN_J_KANRI.HOKOKU_NO))
        sbSQL.Append(" ,WK." & NameOf(_D004_SYONIN_J_KANRI.SYONIN_JUN))
        sbSQL.Append(" ,WK." & NameOf(_D004_SYONIN_J_KANRI.SYAIN_ID))
        sbSQL.Append(" ,WK." & NameOf(_D004_SYONIN_J_KANRI.SYONIN_YMDHNS))
        sbSQL.Append(" ,WK." & NameOf(_D004_SYONIN_J_KANRI.SYONIN_HANTEI_KB))
        sbSQL.Append(" ,WK." & NameOf(_D004_SYONIN_J_KANRI.SASIMODOSI_FG))
        sbSQL.Append(" ,WK." & NameOf(_D004_SYONIN_J_KANRI.RIYU))
        sbSQL.Append(" ,WK." & NameOf(_D004_SYONIN_J_KANRI.COMMENT))
        sbSQL.Append(" ,WK." & NameOf(_D004_SYONIN_J_KANRI.MAIL_SEND_FG))
        sbSQL.Append(" ,WK." & NameOf(_D004_SYONIN_J_KANRI.ADD_SYAIN_ID))
        sbSQL.Append(" ,WK." & NameOf(_D004_SYONIN_J_KANRI.ADD_YMDHNS))
        sbSQL.Append(" ,WK." & NameOf(_D004_SYONIN_J_KANRI.UPD_SYAIN_ID))
        sbSQL.Append(" ,WK." & NameOf(_D004_SYONIN_J_KANRI.UPD_YMDHNS))
        sbSQL.Append(" )")
        sbSQL.Append("OUTPUT $action AS RESULT") 'INSERT OR UPDATE ��ncarchar(10)�Ŏ擾����ꍇ
        sbSQL.Append(";")

        ''-----MERGE���s&���s���ʎ擾
        strRET = DB.ExecuteScalar(sbSQL.ToString, conblnNonMsg, sqlEx)
        Select Case strRET
            Case "INSERT"
                If PrCurrentStage < ENM_NCR_STAGE._120_abcde���u�m�F AndAlso _D004_SYONIN_J_KANRI.MAIL_SEND_FG = False Then
                    '���F�˗����[�����M
                    Call FunSendRequestMail()
                End If

            Case "UPDATE"

            Case Else
                If sqlEx.Source IsNot Nothing Then
                    '-----�G���[���O�o��
                    Dim strErrMsg As String = My.Resources.ErrLogSqlExecutionFailure & sbSQL.ToString & "|" & sqlEx.Message
                    WL.WriteLogDat(strErrMsg)
                Else
                    '---�r������
                    Dim strMsg As String
                    strMsg = "���ɑ��̒S���҂ɂ���ĕύX����Ă��邽�ߕۑ��o���܂���B" & vbCrLf &
                                "�ēx�o�^�������ĉ������B"

                    MessageBox.Show(strMsg, "�����X�V����", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                End If
                Return False
        End Select


        'SPEC: 40-1
        If enmSAVE_MODE = ENM_SAVE_MODE._2_���F�\�� And
            PrCurrentStage = ENM_NCR_STAGE._40_���O�R������y��CAR�v�۔��� And
            _D003_NCR_J._ZESEI_SYOCHI_YOHI_KB = ENM_YOHI_KB._1_�v Then

            If FunSAVE_D005(DB) Then
                blnEnableCAREdit = True
            Else
                Return False
            End If
        End If

        Return True
    End Function

    ''' <summary>
    ''' ���F�˗����[�����M
    ''' </summary>
    ''' <returns></returns>
    Private Function FunSendRequestMail()
        Dim KISYU_NAME As String = tblKISYU.AsEnumerable.Where(Function(r) r.Field(Of Integer)("VALUE") = _D003_NCR_J.KISYU_ID).FirstOrDefault?.Item("DISP")
        Dim SYONIN_HANTEI_NAME As String = tblSYONIN_HANTEI_KB.AsEnumerable.Where(Function(r) r.Field(Of String)("VALUE") = _D004_SYONIN_J_KANRI.SYONIN_HANTEI_KB).FirstOrDefault?.Item("DISP")
        Dim strSubject As String = "�y�s�K���i���u�˗��z{0}�E{1}"
        Dim strBody As String = <sql><![CDATA[
        {0} �a
        �s�K�����i�̏��u�˗������܂����̂őΉ������肢���܂��B
        
        �y�񍐏�No�z{1}
        �y���F���e(�X�e�[�W)�z{2}
        �y�@��z{3}
        �y���i�ԍ��z{4}
        �y�˗��ҁz{5}
        �y�˗��ҏ��u���e�z{6}
        �y�R�����g�z{7}                        
        ]]></sql>.Value.Trim

        strSubject = String.Format(strSubject, KISYU_NAME, _D003_NCR_J.BUHIN_BANGO)
        strBody = String.Format(strBody,
                                Fun_GetUSER_NAME(_D004_SYONIN_J_KANRI.SYAIN_ID),
                                _D004_SYONIN_J_KANRI.HOKOKU_NO,
                                FunGetCurrentStageName(_D004_SYONIN_J_KANRI.SYONIN_JUN),
                                KISYU_NAME,
                                _D003_NCR_J.BUHIN_BANGO,
                                Fun_GetUSER_NAME(pub_SYAIN_INFO.SYAIN_ID),
                                SYONIN_HANTEI_NAME,
                                _D004_SYONIN_J_KANRI.COMMENT)


        If FunSendMailFutekigo(strSubject, strBody, ToSYAIN_ID:=_D004_SYONIN_J_KANRI.SYAIN_ID) Then
            Return True
        Else
            MessageBox.Show("���[�����M�Ɏ��s���܂����B", "���[�����M���s", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Return False
        End If
    End Function

    ''' <summary>
    ''' �񍐏����엚���X�V
    ''' </summary>
    ''' <param name="DB"></param>
    ''' <param name="enmSAVE_MODE"></param>
    ''' <returns></returns>
    Private Function FunSAVE_R001(ByRef DB As ClsDbUtility, ByVal enmSAVE_MODE As ENM_SAVE_MODE) As Boolean
        Dim sbSQL As New System.Text.StringBuilder
        Dim intRET As Integer
        Dim sqlEx As New Exception

        'UNDONE: MERGE INTO �ɕύX

        '---���݊m�F
        Dim dsList As New DataSet
        Dim blnExist As Boolean
        sbSQL.Append("SELECT HOKOKU_NO FROM " & NameOf(MODEL.R001_HOKOKU_SOUSA) & "")
        sbSQL.Append(" WHERE HOKOKU_NO ='" & _R001_HOKOKU_SOUSA.HOKOKU_NO & "'")
        dsList = DB.GetDataSet(sbSQL.ToString, conblnNonMsg)
        If dsList.Tables(0).Rows.Count > 0 Then
            blnExist = True
        End If

        '-----�f�[�^���f���X�V
        _R001_HOKOKU_SOUSA.SYONIN_HOKOKUSYO_ID = ENM_SYONIN_HOKOKUSYO_ID._1_NCR
        _R001_HOKOKU_SOUSA.HOKOKU_NO = _D003_NCR_J.HOKOKU_NO
        _R001_HOKOKU_SOUSA.SYONIN_JUN = PrCurrentStage
        _R001_HOKOKU_SOUSA.SYAIN_ID = pub_SYAIN_INFO.SYAIN_ID
        'UNDONE: getsysdatetime
        _R001_HOKOKU_SOUSA.ADD_YMDHNS = Now.ToString("yyyyMMddHHmmss")

        Select Case _R001_HOKOKU_SOUSA.SYONIN_JUN
            Case ENM_NCR_STAGE._10_�N������
                Select Case enmSAVE_MODE
                    Case ENM_SAVE_MODE._1_�ۑ�
                        _R001_HOKOKU_SOUSA.SYONIN_HANTEI_KB = ENM_SYONIN_HANTEI_KB._0_�����F

                        If blnExist Then
                            _R001_HOKOKU_SOUSA.SOUSA_KB = ENM_HOKOKUSYO_SOUSA_KB._2_�X�V�ۑ�
                        Else
                            _R001_HOKOKU_SOUSA.SOUSA_KB = ENM_HOKOKUSYO_SOUSA_KB._0_�N��
                        End If

                    Case ENM_SAVE_MODE._2_���F�\��
                        _R001_HOKOKU_SOUSA.SYONIN_HANTEI_KB = ENM_SYONIN_HANTEI_KB._1_���F

                        If blnExist Then
                            '�ǉ����Ȃ�
                            Return True
                        Else
                            _R001_HOKOKU_SOUSA.SOUSA_KB = ENM_HOKOKUSYO_SOUSA_KB._0_�N��
                        End If
                End Select
            Case Else
                Select Case enmSAVE_MODE
                    Case ENM_SAVE_MODE._1_�ۑ�
                        '�ǉ����Ȃ�
                        Return True

                    Case ENM_SAVE_MODE._2_���F�\��
                        _R001_HOKOKU_SOUSA.SYONIN_HANTEI_KB = ENM_SYONIN_HANTEI_KB._1_���F
                        _R001_HOKOKU_SOUSA.SOUSA_KB = ENM_HOKOKUSYO_SOUSA_KB._1_�\�����F�˗�
                End Select
        End Select
        '-----

        '-----INSERT
        sbSQL.Remove(0, sbSQL.Length)
        sbSQL.Append("INSERT INTO " & NameOf(MODEL.R001_HOKOKU_SOUSA) & "(")
        sbSQL.Append("  " & NameOf(_R001_HOKOKU_SOUSA.SYONIN_HOKOKUSYO_ID))
        sbSQL.Append(" ," & NameOf(_R001_HOKOKU_SOUSA.HOKOKU_NO))
        sbSQL.Append(" ," & NameOf(_R001_HOKOKU_SOUSA.ADD_YMDHNS))
        sbSQL.Append(" ," & NameOf(_R001_HOKOKU_SOUSA.SYONIN_JUN))
        sbSQL.Append(" ," & NameOf(_R001_HOKOKU_SOUSA.SOUSA_KB))
        sbSQL.Append(" ," & NameOf(_R001_HOKOKU_SOUSA.SYAIN_ID))
        sbSQL.Append(" ," & NameOf(_R001_HOKOKU_SOUSA.SYONIN_HANTEI_KB))
        sbSQL.Append(" ," & NameOf(_R001_HOKOKU_SOUSA.RIYU))
        sbSQL.Append(" ) VALUES(")
        sbSQL.Append("  " & _R001_HOKOKU_SOUSA.SYONIN_HOKOKUSYO_ID)
        sbSQL.Append(" ,'" & _R001_HOKOKU_SOUSA.HOKOKU_NO & "'")
        sbSQL.Append(" ,'" & _R001_HOKOKU_SOUSA.ADD_YMDHNS & "'")
        sbSQL.Append(" ," & _R001_HOKOKU_SOUSA.SYONIN_JUN)
        sbSQL.Append(" ,'" & _R001_HOKOKU_SOUSA.SOUSA_KB & "'")
        sbSQL.Append(" ," & _R001_HOKOKU_SOUSA.SYAIN_ID)
        sbSQL.Append(" ,'" & _R001_HOKOKU_SOUSA.SYONIN_HANTEI_KB & "'")
        sbSQL.Append(" ,'" & _R001_HOKOKU_SOUSA.RIYU & "'")
        sbSQL.Append(")")

        '-----SQL���s
        intRET = DB.ExecuteNonQuery(sbSQL.ToString, conblnNonMsg, sqlEx)
        If intRET <> 1 Then
            '-----�G���[���O�o��
            Dim strErrMsg As String = My.Resources.ErrLogSqlExecutionFailure & sbSQL.ToString & "|" & sqlEx.Message
            WL.WriteLogDat(strErrMsg)
            Return False
        End If

        Return True
    End Function

    ''' <summary>
    ''' D005_CAR_J�X�V
    ''' </summary>
    ''' <param name="DB"></param>
    ''' <returns></returns>
    Private Function FunSAVE_D005(ByRef DB As ClsDbUtility) As Boolean
        Dim sbSQL As New System.Text.StringBuilder
        Dim intRET As Integer
        Dim sqlEx As New Exception

        '-----�f�[�^���f���X�V
        Dim _D005_CAR_J As New MODEL.D005_CAR_J
        _D005_CAR_J.HOKOKU_NO = _D003_NCR_J.HOKOKU_NO
        _D005_CAR_J.BUMON_KB = _D003_NCR_J.BUMON_KB

        '-----INSERT
        sbSQL.Remove(0, sbSQL.Length)
        sbSQL.Append("INSERT INTO " & NameOf(MODEL.D005_CAR_J) & "(")
        sbSQL.Append("  " & NameOf(_D005_CAR_J.HOKOKU_NO))
        sbSQL.Append(" ," & NameOf(_D005_CAR_J.BUMON_KB))
        sbSQL.Append(" ," & NameOf(_D005_CAR_J.CLOSE_FG))
        sbSQL.Append(" ," & NameOf(_D005_CAR_J.SETUMON_1))
        sbSQL.Append(" ," & NameOf(_D005_CAR_J.SETUMON_2))
        sbSQL.Append(" ," & NameOf(_D005_CAR_J.SETUMON_3))
        sbSQL.Append(" ," & NameOf(_D005_CAR_J.SETUMON_4))
        sbSQL.Append(" ," & NameOf(_D005_CAR_J.SETUMON_5))
        sbSQL.Append(" ," & NameOf(_D005_CAR_J.SETUMON_6))
        sbSQL.Append(" ," & NameOf(_D005_CAR_J.SETUMON_7))
        sbSQL.Append(" ," & NameOf(_D005_CAR_J.SETUMON_8))
        sbSQL.Append(" ," & NameOf(_D005_CAR_J.SETUMON_9))
        sbSQL.Append(" ," & NameOf(_D005_CAR_J.SETUMON_10))
        sbSQL.Append(" ," & NameOf(_D005_CAR_J.SETUMON_11))
        sbSQL.Append(" ," & NameOf(_D005_CAR_J.SETUMON_12))
        sbSQL.Append(" ," & NameOf(_D005_CAR_J.SETUMON_13))
        sbSQL.Append(" ," & NameOf(_D005_CAR_J.SETUMON_14))
        sbSQL.Append(" ," & NameOf(_D005_CAR_J.SETUMON_15))
        sbSQL.Append(" ," & NameOf(_D005_CAR_J.SETUMON_16))
        sbSQL.Append(" ," & NameOf(_D005_CAR_J.SETUMON_17))
        sbSQL.Append(" ," & NameOf(_D005_CAR_J.SETUMON_18))
        sbSQL.Append(" ," & NameOf(_D005_CAR_J.SETUMON_19))
        sbSQL.Append(" ," & NameOf(_D005_CAR_J.SETUMON_20))
        sbSQL.Append(" ," & NameOf(_D005_CAR_J.SETUMON_21))
        sbSQL.Append(" ," & NameOf(_D005_CAR_J.SETUMON_22))
        sbSQL.Append(" ," & NameOf(_D005_CAR_J.SETUMON_23))
        sbSQL.Append(" ," & NameOf(_D005_CAR_J.SETUMON_24))
        sbSQL.Append(" ," & NameOf(_D005_CAR_J.SETUMON_25))
        sbSQL.Append(" ," & NameOf(_D005_CAR_J.KAITO_1))
        sbSQL.Append(" ," & NameOf(_D005_CAR_J.KAITO_2))
        sbSQL.Append(" ," & NameOf(_D005_CAR_J.KAITO_3))
        sbSQL.Append(" ," & NameOf(_D005_CAR_J.KAITO_4))
        sbSQL.Append(" ," & NameOf(_D005_CAR_J.KAITO_5))
        sbSQL.Append(" ," & NameOf(_D005_CAR_J.KAITO_6))
        sbSQL.Append(" ," & NameOf(_D005_CAR_J.KAITO_7))
        sbSQL.Append(" ," & NameOf(_D005_CAR_J.KAITO_8))
        sbSQL.Append(" ," & NameOf(_D005_CAR_J.KAITO_9))
        sbSQL.Append(" ," & NameOf(_D005_CAR_J.KAITO_10))
        sbSQL.Append(" ," & NameOf(_D005_CAR_J.KAITO_11))
        sbSQL.Append(" ," & NameOf(_D005_CAR_J.KAITO_12))
        sbSQL.Append(" ," & NameOf(_D005_CAR_J.KAITO_13))
        sbSQL.Append(" ," & NameOf(_D005_CAR_J.KAITO_14))
        sbSQL.Append(" ," & NameOf(_D005_CAR_J.KAITO_15))
        sbSQL.Append(" ," & NameOf(_D005_CAR_J.KAITO_16))
        sbSQL.Append(" ," & NameOf(_D005_CAR_J.KAITO_17))
        sbSQL.Append(" ," & NameOf(_D005_CAR_J.KAITO_18))
        sbSQL.Append(" ," & NameOf(_D005_CAR_J.KAITO_19))
        sbSQL.Append(" ," & NameOf(_D005_CAR_J.KAITO_20))
        sbSQL.Append(" ," & NameOf(_D005_CAR_J.KAITO_21))
        sbSQL.Append(" ," & NameOf(_D005_CAR_J.KAITO_22))
        sbSQL.Append(" ," & NameOf(_D005_CAR_J.KAITO_23))
        sbSQL.Append(" ," & NameOf(_D005_CAR_J.KAITO_24))
        sbSQL.Append(" ," & NameOf(_D005_CAR_J.KAITO_25))
        sbSQL.Append(" ," & NameOf(_D005_CAR_J.KONPON_YOIN_KB1))
        sbSQL.Append(" ," & NameOf(_D005_CAR_J.KONPON_YOIN_KB2))
        sbSQL.Append(" ," & NameOf(_D005_CAR_J.KONPON_YOIN_SYAIN_ID))
        sbSQL.Append(" ," & NameOf(_D005_CAR_J.KISEKI_KOTEI_KB))
        sbSQL.Append(" ," & NameOf(_D005_CAR_J.SYOCHI_A_SYAIN_ID))
        sbSQL.Append(" ," & NameOf(_D005_CAR_J.SYOCHI_A_YMDHNS))
        sbSQL.Append(" ," & NameOf(_D005_CAR_J.SYOCHI_B_SYAIN_ID))
        sbSQL.Append(" ," & NameOf(_D005_CAR_J.SYOCHI_B_YMDHNS))
        sbSQL.Append(" ," & NameOf(_D005_CAR_J.SYOCHI_C_SYAIN_ID))
        sbSQL.Append(" ," & NameOf(_D005_CAR_J.SYOCHI_C_YMDHNS))
        sbSQL.Append(" ," & NameOf(_D005_CAR_J.KYOIKU_FILE_PATH))
        sbSQL.Append(" ," & NameOf(_D005_CAR_J.ZESEI_SYOCHI_YUKO_UMU))
        sbSQL.Append(" ," & NameOf(_D005_CAR_J.SYOSAI_FILE_PATH))
        sbSQL.Append(" ," & NameOf(_D005_CAR_J.GOKI))
        sbSQL.Append(" ," & NameOf(_D005_CAR_J.LOT))
        sbSQL.Append(" ," & NameOf(_D005_CAR_J.KENSA_TANTO_ID))
        sbSQL.Append(" ," & NameOf(_D005_CAR_J.KENSA_TOROKU_YMDHNS))
        sbSQL.Append(" ," & NameOf(_D005_CAR_J.KENSA_GL_SYAIN_ID))
        sbSQL.Append(" ," & NameOf(_D005_CAR_J.KENSA_GL_YMDHNS))
        sbSQL.Append(" ," & NameOf(_D005_CAR_J.ADD_SYAIN_ID))
        sbSQL.Append(" ," & NameOf(_D005_CAR_J.ADD_YMDHNS))
        sbSQL.Append(" ," & NameOf(_D005_CAR_J.UPD_SYAIN_ID))
        sbSQL.Append(" ," & NameOf(_D005_CAR_J.UPD_YMDHNS))
        sbSQL.Append(" ," & NameOf(_D005_CAR_J.DEL_SYAIN_ID))
        sbSQL.Append(" ," & NameOf(_D005_CAR_J.DEL_YMDHNS))
        sbSQL.Append(" ," & NameOf(_D005_CAR_J.FILE_PATH1))
        sbSQL.Append(" ," & NameOf(_D005_CAR_J.FILE_PATH2))
        sbSQL.Append(" ) VALUES(")
        sbSQL.Append(" '" & _D005_CAR_J.HOKOKU_NO & "'")
        sbSQL.Append(" ,'" & _D005_CAR_J.BUMON_KB & "'")
        sbSQL.Append(" ,'" & _D005_CAR_J._CLOSE_FG & "'")
        sbSQL.Append(" ,'" & _D005_CAR_J.SETUMON_1 & "'")
        sbSQL.Append(" ,'" & _D005_CAR_J.SETUMON_2 & "'")
        sbSQL.Append(" ,'" & _D005_CAR_J.SETUMON_3 & "'")
        sbSQL.Append(" ,'" & _D005_CAR_J.SETUMON_4 & "'")
        sbSQL.Append(" ,'" & _D005_CAR_J.SETUMON_5 & "'")
        sbSQL.Append(" ,'" & _D005_CAR_J.SETUMON_6 & "'")
        sbSQL.Append(" ,'" & _D005_CAR_J.SETUMON_7 & "'")
        sbSQL.Append(" ,'" & _D005_CAR_J.SETUMON_8 & "'")
        sbSQL.Append(" ,'" & _D005_CAR_J.SETUMON_9 & "'")
        sbSQL.Append(" ,'" & _D005_CAR_J.SETUMON_10 & "'")
        sbSQL.Append(" ,'" & _D005_CAR_J.SETUMON_11 & "'")
        sbSQL.Append(" ,'" & _D005_CAR_J.SETUMON_12 & "'")
        sbSQL.Append(" ,'" & _D005_CAR_J.SETUMON_13 & "'")
        sbSQL.Append(" ,'" & _D005_CAR_J.SETUMON_14 & "'")
        sbSQL.Append(" ,'" & _D005_CAR_J.SETUMON_15 & "'")
        sbSQL.Append(" ,'" & _D005_CAR_J.SETUMON_16 & "'")
        sbSQL.Append(" ,'" & _D005_CAR_J.SETUMON_17 & "'")
        sbSQL.Append(" ,'" & _D005_CAR_J.SETUMON_18 & "'")
        sbSQL.Append(" ,'" & _D005_CAR_J.SETUMON_19 & "'")
        sbSQL.Append(" ,'" & _D005_CAR_J.SETUMON_20 & "'")
        sbSQL.Append(" ,'" & _D005_CAR_J.SETUMON_21 & "'")
        sbSQL.Append(" ,'" & _D005_CAR_J.SETUMON_22 & "'")
        sbSQL.Append(" ,'" & _D005_CAR_J.SETUMON_23 & "'")
        sbSQL.Append(" ,'" & _D005_CAR_J.SETUMON_24 & "'")
        sbSQL.Append(" ,'" & _D005_CAR_J.SETUMON_25 & "'")
        sbSQL.Append(" ,'" & _D005_CAR_J.KAITO_1 & "'")
        sbSQL.Append(" ,'" & _D005_CAR_J.KAITO_2 & "'")
        sbSQL.Append(" ,'" & _D005_CAR_J.KAITO_3 & "'")
        sbSQL.Append(" ,'" & _D005_CAR_J.KAITO_4 & "'")
        sbSQL.Append(" ,'" & _D005_CAR_J.KAITO_5 & "'")
        sbSQL.Append(" ,'" & _D005_CAR_J.KAITO_6 & "'")
        sbSQL.Append(" ,'" & _D005_CAR_J.KAITO_7 & "'")
        sbSQL.Append(" ,'" & _D005_CAR_J.KAITO_8 & "'")
        sbSQL.Append(" ,'" & _D005_CAR_J.KAITO_9 & "'")
        sbSQL.Append(" ,'" & _D005_CAR_J.KAITO_10 & "'")
        sbSQL.Append(" ,'" & _D005_CAR_J.KAITO_11 & "'")
        sbSQL.Append(" ,'" & _D005_CAR_J.KAITO_12 & "'")
        sbSQL.Append(" ,'" & _D005_CAR_J.KAITO_13 & "'")
        sbSQL.Append(" ,'" & _D005_CAR_J.KAITO_14 & "'")
        sbSQL.Append(" ,'" & _D005_CAR_J.KAITO_15 & "'")
        sbSQL.Append(" ,'" & _D005_CAR_J.KAITO_16 & "'")
        sbSQL.Append(" ,'" & _D005_CAR_J.KAITO_17 & "'")
        sbSQL.Append(" ,'" & _D005_CAR_J.KAITO_18 & "'")
        sbSQL.Append(" ,'" & _D005_CAR_J.KAITO_19 & "'")
        sbSQL.Append(" ,'" & _D005_CAR_J.KAITO_20 & "'")
        sbSQL.Append(" ,'" & _D005_CAR_J.KAITO_21 & "'")
        sbSQL.Append(" ,'" & _D005_CAR_J.KAITO_22 & "'")
        sbSQL.Append(" ,'" & _D005_CAR_J.KAITO_23 & "'")
        sbSQL.Append(" ,'" & _D005_CAR_J.KAITO_24 & "'")
        sbSQL.Append(" ,'" & _D005_CAR_J.KAITO_25 & "'")
        sbSQL.Append(" ,'" & _D005_CAR_J.KONPON_YOIN_KB1 & "'")
        sbSQL.Append(" ,'" & _D005_CAR_J.KONPON_YOIN_KB2 & "'")
        sbSQL.Append(" ," & _D005_CAR_J.KONPON_YOIN_SYAIN_ID & "")
        sbSQL.Append(" ,'" & _D005_CAR_J.KISEKI_KOTEI_KB & "'")
        sbSQL.Append(" ," & _D005_CAR_J.SYOCHI_A_SYAIN_ID & "")
        sbSQL.Append(" ,'" & _D005_CAR_J.SYOCHI_A_YMDHNS & "'")
        sbSQL.Append(" ," & _D005_CAR_J.SYOCHI_B_SYAIN_ID & "")
        sbSQL.Append(" ,'" & _D005_CAR_J.SYOCHI_B_YMDHNS & "'")
        sbSQL.Append(" ," & _D005_CAR_J.SYOCHI_C_SYAIN_ID & "")
        sbSQL.Append(" ,'" & _D005_CAR_J.SYOCHI_C_YMDHNS & "'")
        sbSQL.Append(" ,'" & _D005_CAR_J.KYOIKU_FILE_PATH & "'")
        sbSQL.Append(" ,'" & _D005_CAR_J._ZESEI_SYOCHI_YUKO_UMU & "'")
        sbSQL.Append(" ,'" & _D005_CAR_J.SYOSAI_FILE_PATH & "'")
        sbSQL.Append(" ,'" & _D005_CAR_J.GOKI & "'")
        sbSQL.Append(" ,'" & _D005_CAR_J.LOT & "'")
        sbSQL.Append(" ," & _D005_CAR_J.KENSA_TANTO_ID & "")
        sbSQL.Append(" ,'" & _D005_CAR_J.KENSA_TOROKU_YMDHNS & "'")
        sbSQL.Append(" ," & _D005_CAR_J.KENSA_GL_SYAIN_ID & "")
        sbSQL.Append(" ,'" & _D005_CAR_J.KENSA_GL_YMDHNS & "'")
        sbSQL.Append(" ," & _D005_CAR_J.ADD_SYAIN_ID & "")
        sbSQL.Append(" ,'" & _D005_CAR_J.ADD_YMDHNS & "'")
        sbSQL.Append(" ," & _D005_CAR_J.UPD_SYAIN_ID & "")
        sbSQL.Append(" ,'" & _D005_CAR_J.UPD_YMDHNS & "'")
        sbSQL.Append(" ," & _D005_CAR_J.DEL_SYAIN_ID & "")
        sbSQL.Append(" ,'" & _D005_CAR_J.DEL_YMDHNS & "'")
        sbSQL.Append(" ,'" & _D005_CAR_J.FILE_PATH1 & "'")
        sbSQL.Append(" ,'" & _D005_CAR_J.FILE_PATH2 & "'")
        sbSQL.Append(")")

        '-----SQL���s
        intRET = DB.ExecuteNonQuery(sbSQL.ToString, conblnNonMsg, sqlEx)
        If intRET <> 1 Then
            '-----�G���[���O�o��
            Dim strErrMsg As String = My.Resources.ErrLogSqlExecutionFailure & sbSQL.ToString & "|" & sqlEx.Message
            WL.WriteLogDat(strErrMsg)
            Return False
        End If


        '----D004
        '-----�f�[�^���f���X�V
        _D004_SYONIN_J_KANRI.SYONIN_HOKOKUSYO_ID = ENM_SYONIN_HOKOKUSYO_ID._2_CAR
        _D004_SYONIN_J_KANRI.HOKOKU_NO = _D003_NCR_J.HOKOKU_NO
        _D004_SYONIN_J_KANRI.SYONIN_JUN = ENM_CAR_STAGE._10_�N������
        _D004_SYONIN_J_KANRI.SYAIN_ID = pub_SYAIN_INFO.SYAIN_ID
        _D004_SYONIN_J_KANRI.SYONIN_YMDHNS = ""
        _D004_SYONIN_J_KANRI.SYONIN_HANTEI_KB = ENM_SYONIN_HANTEI_KB._0_�����F
        _D004_SYONIN_J_KANRI.SASIMODOSI_FG = False
        _D004_SYONIN_J_KANRI.RIYU = ""
        _D004_SYONIN_J_KANRI.COMMENT = ""
        _D004_SYONIN_J_KANRI.MAIL_SEND_FG = True
        _D004_SYONIN_J_KANRI.ADD_SYAIN_ID = pub_SYAIN_INFO.SYAIN_ID

        '-----MERGE
        sbSQL.Remove(0, sbSQL.Length)
        sbSQL.Append("MERGE INTO " & NameOf(MODEL.D004_SYONIN_J_KANRI) & " AS SrcT")
        sbSQL.Append(" USING (")
        sbSQL.Append(" SELECT")
        sbSQL.Append(" " & _D004_SYONIN_J_KANRI.SYONIN_HOKOKUSYO_ID & " AS " & NameOf(_D004_SYONIN_J_KANRI.SYONIN_HOKOKUSYO_ID))
        sbSQL.Append(" ,'" & _D004_SYONIN_J_KANRI.HOKOKU_NO & "' AS " & NameOf(_D004_SYONIN_J_KANRI.HOKOKU_NO))
        sbSQL.Append(" ," & _D004_SYONIN_J_KANRI.SYONIN_JUN & " AS " & NameOf(_D004_SYONIN_J_KANRI.SYONIN_JUN))
        sbSQL.Append(" ,'" & _D004_SYONIN_J_KANRI.SYAIN_ID & "' AS " & NameOf(_D004_SYONIN_J_KANRI.SYAIN_ID))
        sbSQL.Append(" ,'" & _D004_SYONIN_J_KANRI.SYONIN_YMDHNS & "' AS " & NameOf(_D004_SYONIN_J_KANRI.SYONIN_YMDHNS))
        sbSQL.Append(" ,'" & _D004_SYONIN_J_KANRI.SYONIN_HANTEI_KB & "' AS " & NameOf(_D004_SYONIN_J_KANRI.SYONIN_HANTEI_KB))
        sbSQL.Append(" ,'" & _D004_SYONIN_J_KANRI._SASIMODOSI_FG & "' AS " & NameOf(_D004_SYONIN_J_KANRI.SASIMODOSI_FG))
        sbSQL.Append(" ,'" & _D004_SYONIN_J_KANRI.RIYU & "' AS " & NameOf(_D004_SYONIN_J_KANRI.RIYU))
        sbSQL.Append(" ,'" & _D004_SYONIN_J_KANRI.COMMENT & "' AS " & NameOf(_D004_SYONIN_J_KANRI.COMMENT))
        sbSQL.Append(" ,'" & _D004_SYONIN_J_KANRI._MAIL_SEND_FG & "' AS " & NameOf(_D004_SYONIN_J_KANRI.MAIL_SEND_FG))
        sbSQL.Append(" ," & _D004_SYONIN_J_KANRI.ADD_SYAIN_ID & " AS " & NameOf(_D004_SYONIN_J_KANRI.ADD_SYAIN_ID))
        sbSQL.Append(" ,dbo.GetSysDateString() AS " & NameOf(_D004_SYONIN_J_KANRI.ADD_YMDHNS))
        sbSQL.Append(" ," & pub_SYAIN_INFO.SYAIN_ID & " AS " & NameOf(_D004_SYONIN_J_KANRI.UPD_SYAIN_ID))
        sbSQL.Append(" ,'" & _D004_SYONIN_J_KANRI.UPD_YMDHNS & "' AS " & NameOf(_D004_SYONIN_J_KANRI.UPD_YMDHNS))
        sbSQL.Append(" ) AS WK")
        sbSQL.Append(" ON (SrcT." & NameOf(_D004_SYONIN_J_KANRI.SYONIN_HOKOKUSYO_ID) & " = WK." & NameOf(_D004_SYONIN_J_KANRI.SYONIN_HOKOKUSYO_ID) & "")
        sbSQL.Append(" AND SrcT." & NameOf(_D004_SYONIN_J_KANRI.HOKOKU_NO) & " = WK." & NameOf(_D004_SYONIN_J_KANRI.HOKOKU_NO) & "")
        sbSQL.Append(" AND SrcT." & NameOf(_D004_SYONIN_J_KANRI.SYONIN_JUN) & " = WK." & NameOf(_D004_SYONIN_J_KANRI.SYONIN_JUN) & ")")

        'UPDATE �r������ �X�V�������ύX����Ă��Ȃ��ꍇ�̂�
        sbSQL.Append(" WHEN MATCHED AND SrcT." & NameOf(_D004_SYONIN_J_KANRI.UPD_YMDHNS) & " = WK." & NameOf(_D004_SYONIN_J_KANRI.UPD_YMDHNS) & " THEN ")
        sbSQL.Append(" UPDATE SET")
        sbSQL.Append("  SrcT." & NameOf(_D004_SYONIN_J_KANRI.SYAIN_ID) & " = WK." & NameOf(_D004_SYONIN_J_KANRI.SYAIN_ID))
        sbSQL.Append(" ,SrcT." & NameOf(_D004_SYONIN_J_KANRI.UPD_SYAIN_ID) & " = WK." & NameOf(_D004_SYONIN_J_KANRI.UPD_SYAIN_ID))
        sbSQL.Append(" ,SrcT." & NameOf(_D004_SYONIN_J_KANRI.COMMENT) & " = WK." & NameOf(_D004_SYONIN_J_KANRI.COMMENT))
        sbSQL.Append(" ,SrcT." & NameOf(_D004_SYONIN_J_KANRI.UPD_YMDHNS) & " = dbo.GetSysDateString()")
        sbSQL.Append(" ,SrcT." & NameOf(_D004_SYONIN_J_KANRI.SASIMODOSI_FG) & " = WK." & NameOf(_D004_SYONIN_J_KANRI.SASIMODOSI_FG))
        sbSQL.Append(" ,SrcT." & NameOf(_D004_SYONIN_J_KANRI.SYONIN_YMDHNS) & " = WK." & NameOf(_D004_SYONIN_J_KANRI.SYONIN_YMDHNS))
        sbSQL.Append(" ,SrcT." & NameOf(_D004_SYONIN_J_KANRI.SYONIN_HANTEI_KB) & " = WK." & NameOf(_D004_SYONIN_J_KANRI.SYONIN_HANTEI_KB))
        sbSQL.Append(" ,SrcT." & NameOf(_D004_SYONIN_J_KANRI.MAIL_SEND_FG) & " = WK." & NameOf(_D004_SYONIN_J_KANRI.MAIL_SEND_FG))
        sbSQL.Append(" ,SrcT." & NameOf(_D004_SYONIN_J_KANRI.RIYU) & " = WK." & NameOf(_D004_SYONIN_J_KANRI.RIYU))
        'INSERT
        sbSQL.Append(" WHEN NOT MATCHED THEN ")
        sbSQL.Append(" INSERT(")
        sbSQL.Append("  " & NameOf(_D004_SYONIN_J_KANRI.SYONIN_HOKOKUSYO_ID))
        sbSQL.Append(" ," & NameOf(_D004_SYONIN_J_KANRI.HOKOKU_NO))
        sbSQL.Append(" ," & NameOf(_D004_SYONIN_J_KANRI.SYONIN_JUN))
        sbSQL.Append(" ," & NameOf(_D004_SYONIN_J_KANRI.SYAIN_ID))
        sbSQL.Append(" ," & NameOf(_D004_SYONIN_J_KANRI.SYONIN_YMDHNS))
        sbSQL.Append(" ," & NameOf(_D004_SYONIN_J_KANRI.SYONIN_HANTEI_KB))
        sbSQL.Append(" ," & NameOf(_D004_SYONIN_J_KANRI.SASIMODOSI_FG))
        sbSQL.Append(" ," & NameOf(_D004_SYONIN_J_KANRI.RIYU))
        sbSQL.Append(" ," & NameOf(_D004_SYONIN_J_KANRI.COMMENT))
        sbSQL.Append(" ," & NameOf(_D004_SYONIN_J_KANRI.MAIL_SEND_FG))
        sbSQL.Append(" ," & NameOf(_D004_SYONIN_J_KANRI.ADD_SYAIN_ID))
        sbSQL.Append(" ," & NameOf(_D004_SYONIN_J_KANRI.ADD_YMDHNS))
        sbSQL.Append(" ," & NameOf(_D004_SYONIN_J_KANRI.UPD_SYAIN_ID))
        sbSQL.Append(" ," & NameOf(_D004_SYONIN_J_KANRI.UPD_YMDHNS))
        sbSQL.Append(" ) VALUES(")
        sbSQL.Append("  WK." & NameOf(_D004_SYONIN_J_KANRI.SYONIN_HOKOKUSYO_ID))
        sbSQL.Append(" ,WK." & NameOf(_D004_SYONIN_J_KANRI.HOKOKU_NO))
        sbSQL.Append(" ,WK." & NameOf(_D004_SYONIN_J_KANRI.SYONIN_JUN))
        sbSQL.Append(" ,WK." & NameOf(_D004_SYONIN_J_KANRI.SYAIN_ID))
        sbSQL.Append(" ,WK." & NameOf(_D004_SYONIN_J_KANRI.SYONIN_YMDHNS))
        sbSQL.Append(" ,WK." & NameOf(_D004_SYONIN_J_KANRI.SYONIN_HANTEI_KB))
        sbSQL.Append(" ,WK." & NameOf(_D004_SYONIN_J_KANRI.SASIMODOSI_FG))
        sbSQL.Append(" ,WK." & NameOf(_D004_SYONIN_J_KANRI.RIYU))
        sbSQL.Append(" ,WK." & NameOf(_D004_SYONIN_J_KANRI.COMMENT))
        sbSQL.Append(" ,WK." & NameOf(_D004_SYONIN_J_KANRI.MAIL_SEND_FG))
        sbSQL.Append(" ,WK." & NameOf(_D004_SYONIN_J_KANRI.ADD_SYAIN_ID))
        sbSQL.Append(" ,WK." & NameOf(_D004_SYONIN_J_KANRI.ADD_YMDHNS))
        sbSQL.Append(" ,WK." & NameOf(_D004_SYONIN_J_KANRI.UPD_SYAIN_ID))
        sbSQL.Append(" ,WK." & NameOf(_D004_SYONIN_J_KANRI.UPD_YMDHNS))
        sbSQL.Append(" )")
        sbSQL.Append("OUTPUT $action AS RESULT;")
        Dim strRET As String
        strRET = DB.ExecuteScalar(sbSQL.ToString, conblnNonMsg, sqlEx)
        Select Case strRET
            Case "INSERT"

            Case "UPDATE"

            Case Else
                If sqlEx.Source IsNot Nothing Then
                    '-----�G���[���O�o��
                    Dim strErrMsg As String = My.Resources.ErrLogSqlExecutionFailure & sbSQL.ToString & "|" & sqlEx.Message
                    WL.WriteLogDat(strErrMsg)
                Else
                    '---�r������
                    Dim strMsg As String
                    strMsg = "���ɑ��̒S���҂ɂ���ĕύX����Ă��邽�ߕۑ��o���܂���B" & vbCrLf &
                                "�ēx�o�^�������ĉ������B"

                    MessageBox.Show(strMsg, "�����X�V����", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                End If

                Return False
        End Select

        Return True
    End Function

    ''' <summary>
    ''' NCR�ĕs�K���o�^
    ''' </summary>
    ''' <param name="DB"></param>
    ''' <returns></returns>
    Private Function FunSAVE_D003_SAI_FUTEKIGO() As Boolean
        Dim sbSQL As New System.Text.StringBuilder
        Dim strRET As String
        Dim sqlEx As New Exception


        _D003_NCR_J.HOKOKU_NO = Val(_D003_NCR_J.HOKOKU_NO) + 1

        '-----MERGE
        sbSQL.Remove(0, sbSQL.Length)
        sbSQL.Append("MERGE INTO " & NameOf(MODEL.D003_NCR_J) & " AS SrcT")
        sbSQL.Append(" USING (")
        sbSQL.Append(" SELECT")
        sbSQL.Append(" '" & _D003_NCR_J.HOKOKU_NO & "' AS " & NameOf(_D003_NCR_J.HOKOKU_NO))
        sbSQL.Append(" ,'" & _D003_NCR_J.BUMON_KB & "' AS " & NameOf(_D003_NCR_J.BUMON_KB))
        sbSQL.Append(" ,'" & _D003_NCR_J._CLOSE_FG & "' AS " & NameOf(_D003_NCR_J.CLOSE_FG))
        sbSQL.Append(" ," & _D003_NCR_J.KISYU_ID & " AS " & NameOf(_D003_NCR_J.KISYU_ID))
        sbSQL.Append(" ,'" & _D003_NCR_J.SYANAI_CD & "' AS " & NameOf(_D003_NCR_J.SYANAI_CD))
        sbSQL.Append(" ,'" & _D003_NCR_J.BUHIN_BANGO & "' AS " & NameOf(_D003_NCR_J.BUHIN_BANGO))
        sbSQL.Append(" ,'" & _D003_NCR_J.BUHIN_NAME & "' AS " & NameOf(_D003_NCR_J.BUHIN_NAME))
        sbSQL.Append(" ,'" & _D003_NCR_J.GOKI & "' AS " & NameOf(_D003_NCR_J.GOKI))
        sbSQL.Append(" ," & _D003_NCR_J.SURYO & " AS " & NameOf(_D003_NCR_J.SURYO))
        sbSQL.Append(" ,'" & _D003_NCR_J._SAIHATU & "' AS " & NameOf(_D003_NCR_J.SAIHATU))
        sbSQL.Append(" ,'" & _D003_NCR_J.FUTEKIGO_JYOTAI_KB & "' AS " & NameOf(_D003_NCR_J.FUTEKIGO_JYOTAI_KB))
        sbSQL.Append(" ,'" & _D003_NCR_J.FUTEKIGO_NAIYO & "' AS " & NameOf(_D003_NCR_J.FUTEKIGO_NAIYO))
        sbSQL.Append(" ,'" & _D003_NCR_J.FUTEKIGO_KB & "' AS " & NameOf(_D003_NCR_J.FUTEKIGO_KB))
        sbSQL.Append(" ,'" & _D003_NCR_J.FUTEKIGO_S_KB & "' AS " & NameOf(_D003_NCR_J.FUTEKIGO_S_KB))
        sbSQL.Append(" ,'" & _D003_NCR_J.ZUMEN_KIKAKU & "' AS " & NameOf(_D003_NCR_J.ZUMEN_KIKAKU))
        sbSQL.Append(" ,'" & _D003_NCR_J.YOKYU_NAIYO & "' AS " & NameOf(_D003_NCR_J.YOKYU_NAIYO))
        sbSQL.Append(" ,'" & _D003_NCR_J.KANSATU_KEKKA & "' AS " & NameOf(_D003_NCR_J.KANSATU_KEKKA))
        sbSQL.Append(" ,'" & _D003_NCR_J._ZESEI_SYOCHI_YOHI_KB & "' AS " & NameOf(_D003_NCR_J.ZESEI_SYOCHI_YOHI_KB))
        sbSQL.Append(" ,'" & _D003_NCR_J.ZESEI_NASI_RIYU & "' AS " & NameOf(_D003_NCR_J.ZESEI_NASI_RIYU))
        sbSQL.Append(" ,'" & _D003_NCR_J.JIZEN_SINSA_HANTEI_KB & "' AS " & NameOf(_D003_NCR_J.JIZEN_SINSA_HANTEI_KB))
        sbSQL.Append(" ," & _D003_NCR_J.JIZEN_SINSA_SYAIN_ID & " AS " & NameOf(_D003_NCR_J.JIZEN_SINSA_SYAIN_ID))

        sbSQL.Append(" ,'" & _D003_NCR_J.JIZEN_SINSA_YMD & "' AS " & NameOf(_D003_NCR_J.JIZEN_SINSA_YMD))
        sbSQL.Append(" ," & _D003_NCR_J.SAISIN_KAKUNIN_SYAIN_ID & " AS " & NameOf(_D003_NCR_J.SAISIN_KAKUNIN_SYAIN_ID))
        sbSQL.Append(" ,'" & _D003_NCR_J.SAISIN_KAKUNIN_YMD & "' AS " & NameOf(_D003_NCR_J.SAISIN_KAKUNIN_YMD))
        sbSQL.Append(" ,'" & _D003_NCR_J.SAISIN_IINKAI_HANTEI_KB & "' AS " & NameOf(_D003_NCR_J.SAISIN_IINKAI_HANTEI_KB))
        sbSQL.Append(" ," & _D003_NCR_J.SAISIN_GIJYUTU_SYAIN_ID & " AS " & NameOf(_D003_NCR_J.SAISIN_GIJYUTU_SYAIN_ID))
        sbSQL.Append(" ,'" & _D003_NCR_J.SAISIN_GIJYUTU_YMD & "' AS " & NameOf(_D003_NCR_J.SAISIN_GIJYUTU_YMD))
        sbSQL.Append(" ," & _D003_NCR_J.SAISIN_HINSYO_SYAIN_ID & " AS " & NameOf(_D003_NCR_J.SAISIN_HINSYO_SYAIN_ID))
        sbSQL.Append(" ,'" & _D003_NCR_J.SAISIN_HINSYO_YMD & "' AS " & NameOf(_D003_NCR_J.SAISIN_HINSYO_YMD))
        sbSQL.Append(" ,'" & _D003_NCR_J.SAISIN_IINKAI_SIRYO_NO & "' AS " & NameOf(_D003_NCR_J.SAISIN_IINKAI_SIRYO_NO))
        sbSQL.Append(" ,'" & _D003_NCR_J.ITAG_NO & "' AS " & NameOf(_D003_NCR_J.ITAG_NO))
        sbSQL.Append(" ," & _D003_NCR_J.KOKYAKU_SAISIN_TANTO_ID & " AS " & NameOf(_D003_NCR_J.KOKYAKU_SAISIN_TANTO_ID))
        sbSQL.Append(" ,'" & _D003_NCR_J.KOKYAKU_SAISIN_YMD & "' AS " & NameOf(_D003_NCR_J.KOKYAKU_SAISIN_YMD))
        sbSQL.Append(" ,'" & _D003_NCR_J.KOKYAKU_HANTEI_SIJI_KB & "' AS " & NameOf(_D003_NCR_J.KOKYAKU_HANTEI_SIJI_KB))
        sbSQL.Append(" ,'" & _D003_NCR_J.KOKYAKU_HANTEI_SIJI_YMD & "' AS " & NameOf(_D003_NCR_J.KOKYAKU_HANTEI_SIJI_YMD))
        sbSQL.Append(" ,'" & _D003_NCR_J.KOKYAKU_SAISYU_HANTEI_KB & "' AS " & NameOf(_D003_NCR_J.KOKYAKU_SAISYU_HANTEI_KB))
        sbSQL.Append(" ,'" & _D003_NCR_J.KOKYAKU_SAISYU_HANTEI_YMD & "' AS " & NameOf(_D003_NCR_J.KOKYAKU_SAISYU_HANTEI_YMD))
        sbSQL.Append(" ,'" & _D003_NCR_J._SAIKAKO_SIJI_FG & "' AS " & NameOf(_D003_NCR_J.SAIKAKO_SIJI_FG))
        sbSQL.Append(" ,'" & _D003_NCR_J.HAIKYAKU_YMD & "' AS " & NameOf(_D003_NCR_J.HAIKYAKU_YMD))
        sbSQL.Append(" ,'" & _D003_NCR_J.HAIKYAKU_KB & "' AS " & NameOf(_D003_NCR_J.HAIKYAKU_KB))
        sbSQL.Append(" ,'" & _D003_NCR_J.HAIKYAKU_HOUHOU & "' AS " & NameOf(_D003_NCR_J.HAIKYAKU_HOUHOU))
        sbSQL.Append(" ," & _D003_NCR_J.HAIKYAKU_TANTO_ID & " AS " & NameOf(_D003_NCR_J.HAIKYAKU_TANTO_ID))
        sbSQL.Append(" ,'" & _D003_NCR_J.SAIKAKO_SIJI_NO & "' AS " & NameOf(_D003_NCR_J.SAIKAKO_SIJI_NO))
        sbSQL.Append(" ,'" & _D003_NCR_J.SAIKAKO_SAGYO_KAN_YMD & "' AS " & NameOf(_D003_NCR_J.SAIKAKO_SAGYO_KAN_YMD))
        sbSQL.Append(" ,'" & _D003_NCR_J.SAIKAKO_KENSA_YMD & "' AS " & NameOf(_D003_NCR_J.SAIKAKO_KENSA_YMD))
        sbSQL.Append(" ,'" & _D003_NCR_J.KENSA_KEKKA_KB & "' AS " & NameOf(_D003_NCR_J.KENSA_KEKKA_KB))
        sbSQL.Append(" ," & _D003_NCR_J.SEIGI_TANTO_ID & " AS " & NameOf(_D003_NCR_J.SEIGI_TANTO_ID))
        sbSQL.Append(" ," & _D003_NCR_J.SEIZO_TANTO_ID & " AS " & NameOf(_D003_NCR_J.SEIZO_TANTO_ID))
        sbSQL.Append(" ," & _D003_NCR_J.KENSA_TANTO_ID & " AS " & NameOf(_D003_NCR_J.KENSA_TANTO_ID))
        sbSQL.Append(" ,'" & _D003_NCR_J.HENKYAKU_YMD & "' AS " & NameOf(_D003_NCR_J.HENKYAKU_YMD))
        sbSQL.Append(" ,'" & _D003_NCR_J.HENKYAKU_SAKI & "' AS " & NameOf(_D003_NCR_J.HENKYAKU_SAKI))
        sbSQL.Append(" ," & _D003_NCR_J.HENKYAKU_TANTO_ID & " AS " & NameOf(_D003_NCR_J.HENKYAKU_TANTO_ID))
        sbSQL.Append(" ,'" & _D003_NCR_J.HENKYAKU_BIKO & "' AS " & NameOf(_D003_NCR_J.HENKYAKU_BIKO))
        sbSQL.Append(" ," & _D003_NCR_J.TENYO_KISYU_ID & " AS " & NameOf(_D003_NCR_J.TENYO_KISYU_ID))
        sbSQL.Append(" ,'" & _D003_NCR_J.TENYO_BUHIN_BANGO & "' AS " & NameOf(_D003_NCR_J.TENYO_BUHIN_BANGO))
        sbSQL.Append(" ,'" & _D003_NCR_J.TENYO_GOKI & "' AS " & NameOf(_D003_NCR_J.TENYO_GOKI))
        sbSQL.Append(" ," & _D003_NCR_J.TENYO_LOT & " AS " & NameOf(_D003_NCR_J.TENYO_LOT))
        sbSQL.Append(" ,'" & _D003_NCR_J.TENYO_YMD & "' AS " & NameOf(_D003_NCR_J.TENYO_YMD))
        sbSQL.Append(" ,'" & _D003_NCR_J._SYOCHI_KEKKA_A & "' AS " & NameOf(_D003_NCR_J.SYOCHI_KEKKA_A))
        sbSQL.Append(" ,'" & _D003_NCR_J._SYOCHI_KEKKA_B & "' AS " & NameOf(_D003_NCR_J.SYOCHI_KEKKA_B))
        sbSQL.Append(" ,'" & _D003_NCR_J._SYOCHI_KEKKA_C & "' AS " & NameOf(_D003_NCR_J.SYOCHI_KEKKA_C))
        sbSQL.Append(" ,'" & _D003_NCR_J._SYOCHI_D_UMU_KB & "' AS " & NameOf(_D003_NCR_J.SYOCHI_D_UMU_KB))
        sbSQL.Append(" ,'" & _D003_NCR_J._SYOCHI_D_YOHI_KB & "' AS " & NameOf(_D003_NCR_J.SYOCHI_D_YOHI_KB))
        sbSQL.Append(" ,'" & _D003_NCR_J.SYOCHI_D_SYOCHI_KIROKU & "' AS " & NameOf(_D003_NCR_J.SYOCHI_D_SYOCHI_KIROKU))
        sbSQL.Append(" ,'" & _D003_NCR_J._SYOCHI_E_UMU_KB & "' AS " & NameOf(_D003_NCR_J.SYOCHI_E_UMU_KB))
        sbSQL.Append(" ,'" & _D003_NCR_J._SYOCHI_E_YOHI_KB & "' AS " & NameOf(_D003_NCR_J.SYOCHI_E_YOHI_KB))
        sbSQL.Append(" ,'" & _D003_NCR_J.SYOCHI_E_SYOCHI_KIROKU & "' AS " & NameOf(_D003_NCR_J.SYOCHI_E_SYOCHI_KIROKU))

        sbSQL.Append(" ,'" & _D003_NCR_J.FILE_PATH & "' AS " & NameOf(_D003_NCR_J.FILE_PATH))
        sbSQL.Append(" ,'" & _D003_NCR_J.G_FILE_PATH1 & "' AS " & NameOf(_D003_NCR_J.G_FILE_PATH1))
        sbSQL.Append(" ,'" & _D003_NCR_J.G_FILE_PATH2 & "' AS " & NameOf(_D003_NCR_J.G_FILE_PATH2))
        sbSQL.Append(" ," & _D003_NCR_J.ADD_SYAIN_ID & " AS " & NameOf(_D003_NCR_J.ADD_SYAIN_ID))
        sbSQL.Append(" ,dbo.GetSysDateString() AS " & NameOf(_D003_NCR_J.ADD_YMDHNS))
        sbSQL.Append(" ," & pub_SYAIN_INFO.SYAIN_ID & " AS " & NameOf(_D003_NCR_J.UPD_SYAIN_ID))
        sbSQL.Append(" ,'" & _D003_NCR_J.UPD_YMDHNS & "' AS " & NameOf(_D003_NCR_J.UPD_YMDHNS))
        sbSQL.Append(" ,0 AS " & NameOf(_D003_NCR_J.DEL_SYAIN_ID))
        sbSQL.Append(" ,' ' AS " & NameOf(_D003_NCR_J.DEL_YMDHNS))
        sbSQL.Append(" ) AS WK")
        sbSQL.Append(" ON (SrcT.HOKOKU_NO = WK.HOKOKU_NO)")

        'UPDATE �r������ �X�V�������ύX����Ă��Ȃ��ꍇ�̂�
        sbSQL.Append(" WHEN MATCHED AND SrcT." & NameOf(_D003_NCR_J.UPD_YMDHNS) & " = WK." & NameOf(_D003_NCR_J.UPD_YMDHNS) & " THEN ")
        sbSQL.Append(" UPDATE SET")
        sbSQL.Append("  SrcT." & NameOf(_D003_NCR_J.KISYU_ID) & " = WK." & NameOf(_D003_NCR_J.KISYU_ID))
        sbSQL.Append(" ,SrcT." & NameOf(_D003_NCR_J.CLOSE_FG) & " = WK." & NameOf(_D003_NCR_J.CLOSE_FG))
        sbSQL.Append(" ,SrcT." & NameOf(_D003_NCR_J.SYANAI_CD) & " = WK." & NameOf(_D003_NCR_J.SYANAI_CD))
        sbSQL.Append(" ,SrcT." & NameOf(_D003_NCR_J.BUHIN_BANGO) & " = WK." & NameOf(_D003_NCR_J.BUHIN_BANGO))
        sbSQL.Append(" ,SrcT." & NameOf(_D003_NCR_J.BUHIN_NAME) & " = WK." & NameOf(_D003_NCR_J.BUHIN_NAME))
        sbSQL.Append(" ,SrcT." & NameOf(_D003_NCR_J.GOKI) & " = WK." & NameOf(_D003_NCR_J.GOKI))
        sbSQL.Append(" ,SrcT." & NameOf(_D003_NCR_J.SURYO) & " = WK." & NameOf(_D003_NCR_J.SURYO))
        sbSQL.Append(" ,SrcT." & NameOf(_D003_NCR_J.SAIHATU) & " = WK." & NameOf(_D003_NCR_J.SAIHATU))
        sbSQL.Append(" ,SrcT." & NameOf(_D003_NCR_J.FUTEKIGO_JYOTAI_KB) & " = WK." & NameOf(_D003_NCR_J.FUTEKIGO_JYOTAI_KB))
        sbSQL.Append(" ,SrcT." & NameOf(_D003_NCR_J.FUTEKIGO_NAIYO) & " = WK." & NameOf(_D003_NCR_J.FUTEKIGO_NAIYO))
        sbSQL.Append(" ,SrcT." & NameOf(_D003_NCR_J.FUTEKIGO_KB) & " = WK." & NameOf(_D003_NCR_J.FUTEKIGO_KB))
        sbSQL.Append(" ,SrcT." & NameOf(_D003_NCR_J.FUTEKIGO_S_KB) & " = WK." & NameOf(_D003_NCR_J.FUTEKIGO_S_KB))
        sbSQL.Append(" ,SrcT." & NameOf(_D003_NCR_J.ZUMEN_KIKAKU) & " = WK." & NameOf(_D003_NCR_J.ZUMEN_KIKAKU))
        sbSQL.Append(" ,SrcT." & NameOf(_D003_NCR_J.YOKYU_NAIYO) & " = WK." & NameOf(_D003_NCR_J.YOKYU_NAIYO))
        sbSQL.Append(" ,SrcT." & NameOf(_D003_NCR_J.KANSATU_KEKKA) & " = WK." & NameOf(_D003_NCR_J.KANSATU_KEKKA))

        sbSQL.Append(" ,SrcT." & NameOf(_D003_NCR_J.ZESEI_SYOCHI_YOHI_KB) & " = WK." & NameOf(_D003_NCR_J.ZESEI_SYOCHI_YOHI_KB))
        sbSQL.Append(" ,SrcT." & NameOf(_D003_NCR_J.ZESEI_NASI_RIYU) & " = WK." & NameOf(_D003_NCR_J.ZESEI_NASI_RIYU))
        sbSQL.Append(" ,SrcT." & NameOf(_D003_NCR_J.JIZEN_SINSA_HANTEI_KB) & " = WK." & NameOf(_D003_NCR_J.JIZEN_SINSA_HANTEI_KB))
        sbSQL.Append(" ,SrcT." & NameOf(_D003_NCR_J.JIZEN_SINSA_SYAIN_ID) & " = WK." & NameOf(_D003_NCR_J.JIZEN_SINSA_SYAIN_ID))
        sbSQL.Append(" ,SrcT." & NameOf(_D003_NCR_J.JIZEN_SINSA_YMD) & " = WK." & NameOf(_D003_NCR_J.JIZEN_SINSA_YMD))
        sbSQL.Append(" ,SrcT." & NameOf(_D003_NCR_J.SAISIN_KAKUNIN_SYAIN_ID) & " = WK." & NameOf(_D003_NCR_J.SAISIN_KAKUNIN_SYAIN_ID))
        sbSQL.Append(" ,SrcT." & NameOf(_D003_NCR_J.SAISIN_KAKUNIN_YMD) & " = WK." & NameOf(_D003_NCR_J.SAISIN_KAKUNIN_YMD))
        sbSQL.Append(" ,SrcT." & NameOf(_D003_NCR_J.SAISIN_IINKAI_HANTEI_KB) & " = WK." & NameOf(_D003_NCR_J.SAISIN_IINKAI_HANTEI_KB))
        sbSQL.Append(" ,SrcT." & NameOf(_D003_NCR_J.SAISIN_GIJYUTU_SYAIN_ID) & " = WK." & NameOf(_D003_NCR_J.SAISIN_GIJYUTU_SYAIN_ID))
        sbSQL.Append(" ,SrcT." & NameOf(_D003_NCR_J.SAISIN_GIJYUTU_YMD) & " = WK." & NameOf(_D003_NCR_J.SAISIN_GIJYUTU_YMD))
        sbSQL.Append(" ,SrcT." & NameOf(_D003_NCR_J.SAISIN_HINSYO_SYAIN_ID) & " = WK." & NameOf(_D003_NCR_J.SAISIN_HINSYO_SYAIN_ID))
        sbSQL.Append(" ,SrcT." & NameOf(_D003_NCR_J.SAISIN_HINSYO_YMD) & " = WK." & NameOf(_D003_NCR_J.SAISIN_HINSYO_YMD))
        sbSQL.Append(" ,SrcT." & NameOf(_D003_NCR_J.SAISIN_IINKAI_SIRYO_NO) & " = WK." & NameOf(_D003_NCR_J.SAISIN_IINKAI_SIRYO_NO))
        sbSQL.Append(" ,SrcT." & NameOf(_D003_NCR_J.ITAG_NO) & " = WK." & NameOf(_D003_NCR_J.ITAG_NO))
        sbSQL.Append(" ,SrcT." & NameOf(_D003_NCR_J.KOKYAKU_SAISIN_TANTO_ID) & " = WK." & NameOf(_D003_NCR_J.KOKYAKU_SAISIN_TANTO_ID))
        sbSQL.Append(" ,SrcT." & NameOf(_D003_NCR_J.KOKYAKU_SAISIN_YMD) & " = WK." & NameOf(_D003_NCR_J.KOKYAKU_SAISIN_YMD))
        sbSQL.Append(" ,SrcT." & NameOf(_D003_NCR_J.KOKYAKU_HANTEI_SIJI_KB) & " = WK." & NameOf(_D003_NCR_J.KOKYAKU_HANTEI_SIJI_KB))
        sbSQL.Append(" ,SrcT." & NameOf(_D003_NCR_J.KOKYAKU_HANTEI_SIJI_YMD) & " = WK." & NameOf(_D003_NCR_J.KOKYAKU_HANTEI_SIJI_YMD))
        sbSQL.Append(" ,SrcT." & NameOf(_D003_NCR_J.KOKYAKU_SAISYU_HANTEI_KB) & " = WK." & NameOf(_D003_NCR_J.KOKYAKU_SAISYU_HANTEI_KB))
        sbSQL.Append(" ,SrcT." & NameOf(_D003_NCR_J.KOKYAKU_SAISYU_HANTEI_YMD) & " = WK." & NameOf(_D003_NCR_J.KOKYAKU_SAISYU_HANTEI_YMD))
        sbSQL.Append(" ,SrcT." & NameOf(_D003_NCR_J.SAIKAKO_SIJI_FG) & " = WK." & NameOf(_D003_NCR_J.SAIKAKO_SIJI_FG))
        sbSQL.Append(" ,SrcT." & NameOf(_D003_NCR_J.HAIKYAKU_YMD) & " = WK." & NameOf(_D003_NCR_J.HAIKYAKU_YMD))
        sbSQL.Append(" ,SrcT." & NameOf(_D003_NCR_J.HAIKYAKU_KB) & " = WK." & NameOf(_D003_NCR_J.HAIKYAKU_KB))
        sbSQL.Append(" ,SrcT." & NameOf(_D003_NCR_J.HAIKYAKU_HOUHOU) & " = WK." & NameOf(_D003_NCR_J.HAIKYAKU_HOUHOU))
        sbSQL.Append(" ,SrcT." & NameOf(_D003_NCR_J.HAIKYAKU_TANTO_ID) & " = WK." & NameOf(_D003_NCR_J.HAIKYAKU_TANTO_ID))
        sbSQL.Append(" ,SrcT." & NameOf(_D003_NCR_J.SAIKAKO_SIJI_NO) & " = WK." & NameOf(_D003_NCR_J.SAIKAKO_SIJI_NO))
        sbSQL.Append(" ,SrcT." & NameOf(_D003_NCR_J.SAIKAKO_SAGYO_KAN_YMD) & " = WK." & NameOf(_D003_NCR_J.SAIKAKO_SAGYO_KAN_YMD))
        sbSQL.Append(" ,SrcT." & NameOf(_D003_NCR_J.SAIKAKO_KENSA_YMD) & " = WK." & NameOf(_D003_NCR_J.SAIKAKO_KENSA_YMD))
        sbSQL.Append(" ,SrcT." & NameOf(_D003_NCR_J.KENSA_KEKKA_KB) & " = WK." & NameOf(_D003_NCR_J.KENSA_KEKKA_KB))
        sbSQL.Append(" ,SrcT." & NameOf(_D003_NCR_J.SEIGI_TANTO_ID) & " = WK." & NameOf(_D003_NCR_J.SEIGI_TANTO_ID))
        sbSQL.Append(" ,SrcT." & NameOf(_D003_NCR_J.SEIZO_TANTO_ID) & " = WK." & NameOf(_D003_NCR_J.SEIZO_TANTO_ID))
        sbSQL.Append(" ,SrcT." & NameOf(_D003_NCR_J.KENSA_TANTO_ID) & " = WK." & NameOf(_D003_NCR_J.KENSA_TANTO_ID))
        sbSQL.Append(" ,SrcT." & NameOf(_D003_NCR_J.HENKYAKU_YMD) & " = WK." & NameOf(_D003_NCR_J.HENKYAKU_YMD))
        sbSQL.Append(" ,SrcT." & NameOf(_D003_NCR_J.HENKYAKU_SAKI) & " = WK." & NameOf(_D003_NCR_J.HENKYAKU_SAKI))
        sbSQL.Append(" ,SrcT." & NameOf(_D003_NCR_J.HENKYAKU_TANTO_ID) & " = WK." & NameOf(_D003_NCR_J.HENKYAKU_TANTO_ID))
        sbSQL.Append(" ,SrcT." & NameOf(_D003_NCR_J.HENKYAKU_BIKO) & " = WK." & NameOf(_D003_NCR_J.HENKYAKU_BIKO))
        sbSQL.Append(" ,SrcT." & NameOf(_D003_NCR_J.TENYO_KISYU_ID) & " = WK." & NameOf(_D003_NCR_J.TENYO_KISYU_ID))
        sbSQL.Append(" ,SrcT." & NameOf(_D003_NCR_J.TENYO_BUHIN_BANGO) & " = WK." & NameOf(_D003_NCR_J.TENYO_BUHIN_BANGO))
        sbSQL.Append(" ,SrcT." & NameOf(_D003_NCR_J.TENYO_GOKI) & " = WK." & NameOf(_D003_NCR_J.TENYO_GOKI))
        sbSQL.Append(" ,SrcT." & NameOf(_D003_NCR_J.TENYO_LOT) & " = WK." & NameOf(_D003_NCR_J.TENYO_LOT))
        sbSQL.Append(" ,SrcT." & NameOf(_D003_NCR_J.TENYO_YMD) & " = WK." & NameOf(_D003_NCR_J.TENYO_YMD))
        sbSQL.Append(" ,SrcT." & NameOf(_D003_NCR_J.SYOCHI_KEKKA_A) & " = WK." & NameOf(_D003_NCR_J.SYOCHI_KEKKA_A))
        sbSQL.Append(" ,SrcT." & NameOf(_D003_NCR_J.SYOCHI_KEKKA_B) & " = WK." & NameOf(_D003_NCR_J.SYOCHI_KEKKA_B))
        sbSQL.Append(" ,SrcT." & NameOf(_D003_NCR_J.SYOCHI_KEKKA_C) & " = WK." & NameOf(_D003_NCR_J.SYOCHI_KEKKA_C))
        sbSQL.Append(" ,SrcT." & NameOf(_D003_NCR_J.SYOCHI_D_UMU_KB) & " = WK." & NameOf(_D003_NCR_J.SYOCHI_D_UMU_KB))
        sbSQL.Append(" ,SrcT." & NameOf(_D003_NCR_J.SYOCHI_D_YOHI_KB) & " = WK." & NameOf(_D003_NCR_J.SYOCHI_D_YOHI_KB))
        sbSQL.Append(" ,SrcT." & NameOf(_D003_NCR_J.SYOCHI_D_SYOCHI_KIROKU) & " = WK." & NameOf(_D003_NCR_J.SYOCHI_D_SYOCHI_KIROKU))
        sbSQL.Append(" ,SrcT." & NameOf(_D003_NCR_J.SYOCHI_E_UMU_KB) & " = WK." & NameOf(_D003_NCR_J.SYOCHI_E_UMU_KB))
        sbSQL.Append(" ,SrcT." & NameOf(_D003_NCR_J.SYOCHI_E_YOHI_KB) & " = WK." & NameOf(_D003_NCR_J.SYOCHI_E_YOHI_KB))
        sbSQL.Append(" ,SrcT." & NameOf(_D003_NCR_J.SYOCHI_E_SYOCHI_KIROKU) & " = WK." & NameOf(_D003_NCR_J.SYOCHI_E_SYOCHI_KIROKU))

        sbSQL.Append(" ,SrcT." & NameOf(_D003_NCR_J.FILE_PATH) & " = WK." & NameOf(_D003_NCR_J.FILE_PATH))
        sbSQL.Append(" ,SrcT." & NameOf(_D003_NCR_J.G_FILE_PATH1) & " = WK." & NameOf(_D003_NCR_J.G_FILE_PATH1))
        sbSQL.Append(" ,SrcT." & NameOf(_D003_NCR_J.G_FILE_PATH2) & " = WK." & NameOf(_D003_NCR_J.G_FILE_PATH2))
        sbSQL.Append(" ,SrcT." & NameOf(_D003_NCR_J.UPD_SYAIN_ID) & " = " & pub_SYAIN_INFO.SYAIN_ID)
        sbSQL.Append(" ,SrcT." & NameOf(_D003_NCR_J.UPD_YMDHNS) & " = dbo.GetSysDateString()")

        'INSERT
        sbSQL.Append(" WHEN NOT MATCHED THEN ")
        sbSQL.Append(" INSERT(")
        sbSQL.Append("  " & NameOf(_D003_NCR_J.HOKOKU_NO))
        sbSQL.Append(" ," & NameOf(_D003_NCR_J.BUMON_KB))
        sbSQL.Append(" ," & NameOf(_D003_NCR_J.CLOSE_FG))
        sbSQL.Append(" ," & NameOf(_D003_NCR_J.KISYU_ID))
        sbSQL.Append(" ," & NameOf(_D003_NCR_J.SYANAI_CD))
        sbSQL.Append(" ," & NameOf(_D003_NCR_J.BUHIN_BANGO))
        sbSQL.Append(" ," & NameOf(_D003_NCR_J.BUHIN_NAME))
        sbSQL.Append(" ," & NameOf(_D003_NCR_J.GOKI))
        sbSQL.Append(" ," & NameOf(_D003_NCR_J.SURYO))
        sbSQL.Append(" ," & NameOf(_D003_NCR_J.SAIHATU))
        sbSQL.Append(" ," & NameOf(_D003_NCR_J.FUTEKIGO_JYOTAI_KB))
        sbSQL.Append(" ," & NameOf(_D003_NCR_J.FUTEKIGO_NAIYO))
        sbSQL.Append(" ," & NameOf(_D003_NCR_J.FUTEKIGO_KB))
        sbSQL.Append(" ," & NameOf(_D003_NCR_J.FUTEKIGO_S_KB))
        sbSQL.Append(" ," & NameOf(_D003_NCR_J.ZUMEN_KIKAKU))
        sbSQL.Append(" ," & NameOf(_D003_NCR_J.YOKYU_NAIYO))
        sbSQL.Append(" ," & NameOf(_D003_NCR_J.KANSATU_KEKKA))
        sbSQL.Append(" ," & NameOf(_D003_NCR_J.ZESEI_SYOCHI_YOHI_KB))
        sbSQL.Append(" ," & NameOf(_D003_NCR_J.ZESEI_NASI_RIYU))
        sbSQL.Append(" ," & NameOf(_D003_NCR_J.JIZEN_SINSA_HANTEI_KB))
        sbSQL.Append(" ," & NameOf(_D003_NCR_J.JIZEN_SINSA_SYAIN_ID))
        sbSQL.Append(" ," & NameOf(_D003_NCR_J.JIZEN_SINSA_YMD))
        sbSQL.Append(" ," & NameOf(_D003_NCR_J.SAISIN_KAKUNIN_SYAIN_ID))
        sbSQL.Append(" ," & NameOf(_D003_NCR_J.SAISIN_KAKUNIN_YMD))
        sbSQL.Append(" ," & NameOf(_D003_NCR_J.SAISIN_IINKAI_HANTEI_KB))
        sbSQL.Append(" ," & NameOf(_D003_NCR_J.SAISIN_GIJYUTU_SYAIN_ID))
        sbSQL.Append(" ," & NameOf(_D003_NCR_J.SAISIN_GIJYUTU_YMD))
        sbSQL.Append(" ," & NameOf(_D003_NCR_J.SAISIN_HINSYO_SYAIN_ID))
        sbSQL.Append(" ," & NameOf(_D003_NCR_J.SAISIN_HINSYO_YMD))
        sbSQL.Append(" ," & NameOf(_D003_NCR_J.SAISIN_IINKAI_SIRYO_NO))
        sbSQL.Append(" ," & NameOf(_D003_NCR_J.ITAG_NO))
        sbSQL.Append(" ," & NameOf(_D003_NCR_J.KOKYAKU_SAISIN_TANTO_ID))
        sbSQL.Append(" ," & NameOf(_D003_NCR_J.KOKYAKU_SAISIN_YMD))
        sbSQL.Append(" ," & NameOf(_D003_NCR_J.KOKYAKU_HANTEI_SIJI_KB))
        sbSQL.Append(" ," & NameOf(_D003_NCR_J.KOKYAKU_HANTEI_SIJI_YMD))
        sbSQL.Append(" ," & NameOf(_D003_NCR_J.KOKYAKU_SAISYU_HANTEI_KB))
        sbSQL.Append(" ," & NameOf(_D003_NCR_J.KOKYAKU_SAISYU_HANTEI_YMD))
        sbSQL.Append(" ," & NameOf(_D003_NCR_J.SAIKAKO_SIJI_FG))
        sbSQL.Append(" ," & NameOf(_D003_NCR_J.HAIKYAKU_YMD))
        sbSQL.Append(" ," & NameOf(_D003_NCR_J.HAIKYAKU_KB))
        sbSQL.Append(" ," & NameOf(_D003_NCR_J.HAIKYAKU_HOUHOU))
        sbSQL.Append(" ," & NameOf(_D003_NCR_J.HAIKYAKU_TANTO_ID))
        sbSQL.Append(" ," & NameOf(_D003_NCR_J.SAIKAKO_SIJI_NO))
        sbSQL.Append(" ," & NameOf(_D003_NCR_J.SAIKAKO_SAGYO_KAN_YMD))
        sbSQL.Append(" ," & NameOf(_D003_NCR_J.SAIKAKO_KENSA_YMD))
        sbSQL.Append(" ," & NameOf(_D003_NCR_J.KENSA_KEKKA_KB))
        sbSQL.Append(" ," & NameOf(_D003_NCR_J.SEIGI_TANTO_ID))
        sbSQL.Append(" ," & NameOf(_D003_NCR_J.SEIZO_TANTO_ID))
        sbSQL.Append(" ," & NameOf(_D003_NCR_J.KENSA_TANTO_ID))
        sbSQL.Append(" ," & NameOf(_D003_NCR_J.HENKYAKU_YMD))
        sbSQL.Append(" ," & NameOf(_D003_NCR_J.HENKYAKU_SAKI))
        sbSQL.Append(" ," & NameOf(_D003_NCR_J.HENKYAKU_TANTO_ID))
        sbSQL.Append(" ," & NameOf(_D003_NCR_J.HENKYAKU_BIKO))
        sbSQL.Append(" ," & NameOf(_D003_NCR_J.TENYO_KISYU_ID))
        sbSQL.Append(" ," & NameOf(_D003_NCR_J.TENYO_BUHIN_BANGO))
        sbSQL.Append(" ," & NameOf(_D003_NCR_J.TENYO_GOKI))
        sbSQL.Append(" ," & NameOf(_D003_NCR_J.TENYO_LOT))
        sbSQL.Append(" ," & NameOf(_D003_NCR_J.TENYO_YMD))
        sbSQL.Append(" ," & NameOf(_D003_NCR_J.SYOCHI_KEKKA_A))
        sbSQL.Append(" ," & NameOf(_D003_NCR_J.SYOCHI_KEKKA_B))
        sbSQL.Append(" ," & NameOf(_D003_NCR_J.SYOCHI_KEKKA_C))
        sbSQL.Append(" ," & NameOf(_D003_NCR_J.SYOCHI_D_UMU_KB))
        sbSQL.Append(" ," & NameOf(_D003_NCR_J.SYOCHI_D_YOHI_KB))
        sbSQL.Append(" ," & NameOf(_D003_NCR_J.SYOCHI_D_SYOCHI_KIROKU))
        sbSQL.Append(" ," & NameOf(_D003_NCR_J.SYOCHI_E_UMU_KB))
        sbSQL.Append(" ," & NameOf(_D003_NCR_J.SYOCHI_E_YOHI_KB))
        sbSQL.Append(" ," & NameOf(_D003_NCR_J.SYOCHI_E_SYOCHI_KIROKU))
        sbSQL.Append(" ," & NameOf(_D003_NCR_J.FILE_PATH))
        sbSQL.Append(" ," & NameOf(_D003_NCR_J.G_FILE_PATH1))
        sbSQL.Append(" ," & NameOf(_D003_NCR_J.G_FILE_PATH2))
        sbSQL.Append(" ," & NameOf(_D003_NCR_J.ADD_SYAIN_ID))
        sbSQL.Append(" ," & NameOf(_D003_NCR_J.ADD_YMDHNS))
        sbSQL.Append(" ," & NameOf(_D003_NCR_J.UPD_SYAIN_ID))
        sbSQL.Append(" ," & NameOf(_D003_NCR_J.UPD_YMDHNS))
        sbSQL.Append(" ," & NameOf(_D003_NCR_J.DEL_SYAIN_ID))
        sbSQL.Append(" ," & NameOf(_D003_NCR_J.DEL_YMDHNS))
        sbSQL.Append(" ) VALUES(")
        sbSQL.Append(" '" & _D003_NCR_J.HOKOKU_NO & "'")
        sbSQL.Append(" ,'" & _D003_NCR_J.BUMON_KB & "'")
        sbSQL.Append(" ,'" & _D003_NCR_J.CLOSE_FG & "'")
        sbSQL.Append(" ," & _D003_NCR_J.KISYU_ID & "")
        sbSQL.Append(" ,'" & _D003_NCR_J.SYANAI_CD & "'")
        sbSQL.Append(" ,'" & _D003_NCR_J.BUHIN_BANGO & "'")
        sbSQL.Append(" ,'" & _D003_NCR_J.BUHIN_NAME & "'")
        sbSQL.Append(" ,'" & _D003_NCR_J.GOKI & "'")
        sbSQL.Append(" ," & _D003_NCR_J.SURYO & "")
        sbSQL.Append(" ,'" & _D003_NCR_J.SAIHATU & "'")
        sbSQL.Append(" ,'" & _D003_NCR_J.FUTEKIGO_JYOTAI_KB & "'")
        sbSQL.Append(" ,'" & _D003_NCR_J.FUTEKIGO_NAIYO & "'")
        sbSQL.Append(" ,'" & _D003_NCR_J.FUTEKIGO_KB & "'")
        sbSQL.Append(" ,'" & _D003_NCR_J.FUTEKIGO_S_KB & "'")
        sbSQL.Append(" ,'" & _D003_NCR_J.ZUMEN_KIKAKU & "'")
        sbSQL.Append(" ,'" & _D003_NCR_J.YOKYU_NAIYO & "'")
        sbSQL.Append(" ,'" & _D003_NCR_J.KANSATU_KEKKA & "'")
        sbSQL.Append(" ,'" & _D003_NCR_J.ZESEI_SYOCHI_YOHI_KB & "'")
        sbSQL.Append(" ,'" & _D003_NCR_J.ZESEI_NASI_RIYU & "'")
        sbSQL.Append(" ,'" & _D003_NCR_J.JIZEN_SINSA_HANTEI_KB & "'")
        sbSQL.Append(" ," & _D003_NCR_J.JIZEN_SINSA_SYAIN_ID & "")
        sbSQL.Append(" ,'" & _D003_NCR_J.JIZEN_SINSA_YMD & "'")
        sbSQL.Append(" ," & _D003_NCR_J.SAISIN_KAKUNIN_SYAIN_ID & "")
        sbSQL.Append(" ,'" & _D003_NCR_J.SAISIN_KAKUNIN_YMD & "'")
        sbSQL.Append(" ,'" & _D003_NCR_J.SAISIN_IINKAI_HANTEI_KB & "'")
        sbSQL.Append(" ," & _D003_NCR_J.SAISIN_GIJYUTU_SYAIN_ID & "")
        sbSQL.Append(" ,'" & _D003_NCR_J.SAISIN_GIJYUTU_YMD & "'")
        sbSQL.Append(" ," & _D003_NCR_J.SAISIN_HINSYO_SYAIN_ID & "")
        sbSQL.Append(" ,'" & _D003_NCR_J.SAISIN_HINSYO_YMD & "'")
        sbSQL.Append(" ,'" & _D003_NCR_J.SAISIN_IINKAI_SIRYO_NO & "'")
        sbSQL.Append(" ,'" & _D003_NCR_J.ITAG_NO & "'")
        sbSQL.Append(" ," & _D003_NCR_J.KOKYAKU_SAISIN_TANTO_ID & "")
        sbSQL.Append(" ,'" & _D003_NCR_J.KOKYAKU_SAISIN_YMD & "'")
        sbSQL.Append(" ,'" & _D003_NCR_J.KOKYAKU_HANTEI_SIJI_KB & "'")
        sbSQL.Append(" ,'" & _D003_NCR_J.KOKYAKU_HANTEI_SIJI_YMD & "'")
        sbSQL.Append(" ,'" & _D003_NCR_J.KOKYAKU_SAISYU_HANTEI_KB & "'")
        sbSQL.Append(" ,'" & _D003_NCR_J.KOKYAKU_SAISYU_HANTEI_YMD & "'")
        sbSQL.Append(" ,'" & _D003_NCR_J.SAIKAKO_SIJI_FG & "'")
        sbSQL.Append(" ,'" & _D003_NCR_J.HAIKYAKU_YMD & "'")
        sbSQL.Append(" ,'" & _D003_NCR_J.HAIKYAKU_KB & "'")
        sbSQL.Append(" ,'" & _D003_NCR_J.HAIKYAKU_HOUHOU & "'")
        sbSQL.Append(" ," & _D003_NCR_J.HAIKYAKU_TANTO_ID & "")
        sbSQL.Append(" ,'" & _D003_NCR_J.SAIKAKO_SIJI_NO & "'")
        sbSQL.Append(" ,'" & _D003_NCR_J.SAIKAKO_SAGYO_KAN_YMD & "'")
        sbSQL.Append(" ,'" & _D003_NCR_J.SAIKAKO_KENSA_YMD & "'")
        sbSQL.Append(" ,'" & _D003_NCR_J.KENSA_KEKKA_KB & "'")
        sbSQL.Append(" ," & _D003_NCR_J.SEIGI_TANTO_ID & "")
        sbSQL.Append(" ," & _D003_NCR_J.SEIZO_TANTO_ID & "")
        sbSQL.Append(" ," & _D003_NCR_J.KENSA_TANTO_ID & "")
        sbSQL.Append(" ,'" & _D003_NCR_J.HENKYAKU_YMD & "'")
        sbSQL.Append(" ,'" & _D003_NCR_J.HENKYAKU_SAKI & "'")
        sbSQL.Append(" ," & _D003_NCR_J.HENKYAKU_TANTO_ID & "")
        sbSQL.Append(" ,'" & _D003_NCR_J.HENKYAKU_BIKO & "'")
        sbSQL.Append(" ," & _D003_NCR_J.TENYO_KISYU_ID & "")
        sbSQL.Append(" ,'" & _D003_NCR_J.TENYO_BUHIN_BANGO & "'")
        sbSQL.Append(" ,'" & _D003_NCR_J.TENYO_GOKI & "'")
        sbSQL.Append(" ,'" & _D003_NCR_J.TENYO_LOT & "'")
        sbSQL.Append(" ,'" & _D003_NCR_J.TENYO_YMD & "'")
        sbSQL.Append(" ,'" & _D003_NCR_J.SYOCHI_KEKKA_A & "'")
        sbSQL.Append(" ,'" & _D003_NCR_J.SYOCHI_KEKKA_B & "'")
        sbSQL.Append(" ,'" & _D003_NCR_J.SYOCHI_KEKKA_C & "'")
        sbSQL.Append(" ,'" & _D003_NCR_J.SYOCHI_D_UMU_KB & "'")
        sbSQL.Append(" ,'" & _D003_NCR_J.SYOCHI_D_YOHI_KB & "'")
        sbSQL.Append(" ,'" & _D003_NCR_J.SYOCHI_D_SYOCHI_KIROKU & "'")
        sbSQL.Append(" ,'" & _D003_NCR_J.SYOCHI_E_UMU_KB & "'")
        sbSQL.Append(" ,'" & _D003_NCR_J.SYOCHI_E_YOHI_KB & "'")
        sbSQL.Append(" ,'" & _D003_NCR_J.SYOCHI_E_SYOCHI_KIROKU & "'")
        sbSQL.Append(" ,'" & _D003_NCR_J.FILE_PATH & "'")
        sbSQL.Append(" ,'" & _D003_NCR_J.G_FILE_PATH1 & "'")
        sbSQL.Append(" ,'" & _D003_NCR_J.G_FILE_PATH2 & "'")
        sbSQL.Append(" ," & _D003_NCR_J.ADD_SYAIN_ID & "")
        sbSQL.Append(" ,'" & _D003_NCR_J.ADD_YMDHNS & "'")
        sbSQL.Append(" ," & _D003_NCR_J.UPD_SYAIN_ID & "")
        sbSQL.Append(" ,'" & _D003_NCR_J.UPD_YMDHNS & "'")
        sbSQL.Append(" ," & _D003_NCR_J.DEL_SYAIN_ID & "")
        sbSQL.Append(" ,'" & _D003_NCR_J.DEL_YMDHNS & "'")
        sbSQL.Append(" )")
        sbSQL.Append("OUTPUT $action AS RESULT;")

        Using DB As ClsDbUtility = DBOpen()
            Dim blnErr As Boolean
            Try
                DB.BeginTransaction()
                strRET = DB.ExecuteScalar(sbSQL.ToString, conblnNonMsg, sqlEx)
                Select Case strRET
                    Case "INSERT"

                    Case "UPDATE"
                        '���ɑ��݂���ꍇ���G���[
                        Dim strMsg As String
                        strMsg = "���ɑ��̒S���҂ɂ���čĕs�K���o�^����Ă��邽�߁A�ۑ��o���܂���B"

                        MessageBox.Show(strMsg, "�����X�V����", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                        Return False
                    Case Else
                        If sqlEx.Source IsNot Nothing Then
                            '-----�G���[���O�o��
                            Dim strErrMsg As String = My.Resources.ErrLogSqlExecutionFailure & sbSQL.ToString & "|" & sqlEx.Message
                            WL.WriteLogDat(strErrMsg)
                            blnErr = True
                        Else
                            '---�r������
                            Dim strMsg As String
                            strMsg = "���ɑ��̒S���҂ɂ���ĕύX����Ă��邽�ߕۑ��o���܂���B" & vbCrLf &
                                "�ēx�o�^�������ĉ������B"

                            MessageBox.Show(strMsg, "�����X�V����", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                        End If
                        Return False
                End Select
            Finally
                DB.Commit(Not blnErr)
            End Try
        End Using

        Return True
    End Function

#End Region

#Region "CAR"
    Private Function OpenFormCAR() As Boolean
        Dim frmDLG As New FrmG0012
        Dim dlgRET As DialogResult

        Try
            frmDLG.PrDialog = True
            frmDLG.PrHOKOKU_NO = _D003_NCR_J.HOKOKU_NO
            frmDLG.PrCurrentStage = ENM_CAR_STAGE._10_�N������
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

#Region "�]��"
    Private Function OpenFormTENSO() As Boolean
        Dim frmDLG As New FrmG0015
        Dim dlgRET As DialogResult

        Try
            frmDLG.PrSYONIN_HOKOKUSYO_ID = ENM_SYONIN_HOKOKUSYO_ID._1_NCR
            frmDLG.PrHOKOKU_NO = _D003_NCR_J.HOKOKU_NO
            frmDLG.PrBUMON_KB = _D003_NCR_J.BUMON_KB
            frmDLG.PrCurrentStage = Me.PrCurrentStage
            dlgRET = frmDLG.ShowDialog(Me)

            If dlgRET = Windows.Forms.DialogResult.Cancel Then
                Return False
            Else
                Me.DialogResult = DialogResult.OK
                Me.Close()
                Return True
            End If

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

#Region "���߂�"
    Private Function OpenFormSASIMODOSI() As Boolean
        Dim frmDLG As New FrmG0016
        Dim dlgRET As DialogResult

        Try
            frmDLG.PrSYONIN_HOKOKUSYO_ID = ENM_SYONIN_HOKOKUSYO_ID._1_NCR
            frmDLG.PrHOKOKU_NO = _D003_NCR_J.HOKOKU_NO
            frmDLG.PrCurrentStage = Me.PrCurrentStage
            dlgRET = frmDLG.ShowDialog(Me)
            If dlgRET = Windows.Forms.DialogResult.Cancel Then
                Return False
            Else
                Me.Close()
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

#Region "���"
    Private Function FunOpenReportNCR() As Boolean
        Dim strOutputFileName As String
        Dim strTEMPFILE As String
        'Dim intRET As Integer

        Try
            Me.Cursor = Cursors.WaitCursor

            '�t�@�C����
            strOutputFileName = "NCR_" & _D003_NCR_J.HOKOKU_NO & "_Work.xls"

            '�����t�@�C���폜
            If FunDELETE_FILE(pub_APP_INFO.strOUTPUT_PATH & strOutputFileName) = False Then
                Return False
            End If

            Using iniIF As New IniFile(FunGetRootPath() & "\INI\" & CON_TEMPLATE_INI)
                strTEMPFILE = FunConvRootPath(iniIF.GetIniString("NCR", "FILEPATH"))
            End Using

            '�G�N�Z���o�̓t�@�C���p��
            If OUT_EXCEL_READY(strTEMPFILE, pub_APP_INFO.strOUTPUT_PATH, strOutputFileName) = False Then
                Return False
            End If
            '-----��������
            If FunMakeReportNCR(pub_APP_INFO.strOUTPUT_PATH & strOutputFileName, _D003_NCR_J.HOKOKU_NO) = False Then
                Return False
            End If

            'Excel�N��
            'Return FunOpenExcelApp(pub_APP_INFO.strOUTPUT_PATH & strOutputFileName)

        Catch ex As Exception
            EM.ErrorSyori(ex, False, conblnNonMsg)
            Return False
        Finally
            Me.Cursor = Cursors.Default
        End Try
    End Function

    Private Function _FunMakeReportNCR(ByVal strFilePath As String, ByVal strHOKOKU_NO As String) As Boolean

        Dim ssgWorkbook As SpreadsheetGear.IWorkbook
        Dim ssgWorksheets As SpreadsheetGear.IWorksheets
        Dim ssgSheet1 As SpreadsheetGear.IWorksheet


        Try
            Dim _V002_NCR_J As MODEL.V002_NCR_J = FunGetV002Model(strHOKOKU_NO)

            ssgWorkbook = SpreadsheetGear.Factory.GetWorkbook(strFilePath, System.Globalization.CultureInfo.CurrentCulture)
            ssgWorkbook.WorkbookSet.GetLock()
            ssgWorksheets = ssgWorkbook.Worksheets
            ssgSheet1 = ssgWorksheets.Item(0) 'sheet1

            '���R�[�h�t���[��������
            'spWork.Range("RECORD_FRAME").ClearContents()
            ssgSheet1.Range(NameOf(_V002_NCR_J.BUHIN_BANGO)).Value = _V002_NCR_J.BUHIN_BANGO
            ssgSheet1.Range(NameOf(_V002_NCR_J.BUHIN_NAME)).Value = _V002_NCR_J.BUHIN_NAME
            If Not _V002_NCR_J.FUTEKIGO_JYOTAI_KB.IsNullOrWhiteSpace Then
                ssgSheet1.Range(NameOf(_V002_NCR_J.FUTEKIGO_JYOTAI_KB) & _V002_NCR_J.FUTEKIGO_JYOTAI_KB).Value = "TRUE"
            End If
            ssgSheet1.Range(NameOf(_V002_NCR_J.FUTEKIGO_NAIYO)).Value = _V002_NCR_J.FUTEKIGO_NAIYO
            ssgSheet1.Range(NameOf(_V002_NCR_J.GOKI)).Value = _V002_NCR_J.GOKI
            ssgSheet1.Range(NameOf(_V002_NCR_J.HAIKYAKU_HOUHOU)).Value = "(���̑��̓��e�F" & _V002_NCR_J.HAIKYAKU_HOUHOU.PadRight(30) & ")"
            ssgSheet1.Range(NameOf(_V002_NCR_J.HAIKYAKU_KB_NAME)).Value = _V002_NCR_J.HAIKYAKU_KB_NAME
            ssgSheet1.Range(NameOf(_V002_NCR_J.HAIKYAKU_TANTO_NAME)).Value = _V002_NCR_J.HAIKYAKU_TANTO_NAME
            ssgSheet1.Range(NameOf(_V002_NCR_J.HAIKYAKU_YMD)).Value = _V002_NCR_J.HAIKYAKU_YMD
            ssgSheet1.Range(NameOf(_V002_NCR_J.HASSEI_KOTEI_GL_NAME)).Value = _V002_NCR_J.HASSEI_KOTEI_GL_NAME
            ssgSheet1.Range(NameOf(_V002_NCR_J.HASSEI_KOTEI_GL_YMD)).Value = _V002_NCR_J.HASSEI_KOTEI_GL_YMD
            ssgSheet1.Range(NameOf(_V002_NCR_J.HENKYAKU_BIKO)).Value = _V002_NCR_J.HENKYAKU_BIKO
            ssgSheet1.Range(NameOf(_V002_NCR_J.HENKYAKU_SAKI)).Value = _V002_NCR_J.HENKYAKU_SAKI
            ssgSheet1.Range(NameOf(_V002_NCR_J.HENKYAKU_TANTO_NAME)).Value = _V002_NCR_J.HENKYAKU_TANTO_NAME
            ssgSheet1.Range(NameOf(_V002_NCR_J.HENKYAKU_YMD)).Value = _V002_NCR_J.HENKYAKU_YMD
            ssgSheet1.Range(NameOf(_V002_NCR_J.HOKOKU_NO)).Value = _V002_NCR_J.HOKOKU_NO
            ssgSheet1.Range(NameOf(_V002_NCR_J.ITAG_NO)).Value = _V002_NCR_J.ITAG_NO
            If Not _V002_NCR_J.JIZEN_SINSA_HANTEI_KB.IsNullOrWhiteSpace Then
                ssgSheet1.Range(NameOf(_V002_NCR_J.JIZEN_SINSA_HANTEI_KB) & _V002_NCR_J.JIZEN_SINSA_HANTEI_KB).Value = "TRUE"
            End If
            ssgSheet1.Range(NameOf(_V002_NCR_J.JIZEN_SINSA_SYAIN_NAME)).Value = _V002_NCR_J.JIZEN_SINSA_SYAIN_NAME
            ssgSheet1.Range(NameOf(_V002_NCR_J.JIZEN_SINSA_YMD)).Value = _V002_NCR_J.JIZEN_SINSA_YMD
            ssgSheet1.Range(NameOf(_V002_NCR_J.KANSATU_KEKKA)).Value = _V002_NCR_J.KANSATU_KEKKA
            ssgSheet1.Range(NameOf(_V002_NCR_J.KENSA_KEKKA_NAME)).Value = _V002_NCR_J.KENSA_KEKKA_NAME
            ssgSheet1.Range(NameOf(_V002_NCR_J.KENSA_TANTO_NAME)).Value = _V002_NCR_J.KENSA_TANTO_NAME
            ssgSheet1.Range(NameOf(_V002_NCR_J.KISYU)).Value = _V002_NCR_J.KISYU
            ssgSheet1.Range(NameOf(_V002_NCR_J.KOKYAKU_HANTEI_SIJI_NAME)).Value = _V002_NCR_J.KOKYAKU_HANTEI_SIJI_NAME
            ssgSheet1.Range(NameOf(_V002_NCR_J.KOKYAKU_HANTEI_SIJI_YMD)).Value = _V002_NCR_J.KOKYAKU_HANTEI_SIJI_YMD
            ssgSheet1.Range(NameOf(_V002_NCR_J.SAIHATU)).Value = _V002_NCR_J.SAIHATU
            ssgSheet1.Range(NameOf(_V002_NCR_J.SAIKAKO_KENSA_YMD)).Value = _V002_NCR_J.SAIKAKO_KENSA_YMD
            ssgSheet1.Range(NameOf(_V002_NCR_J.SAIKAKO_SAGYO_KAN_YMD)).Value = _V002_NCR_J.SAIKAKO_SAGYO_KAN_YMD
            ssgSheet1.Range(NameOf(_V002_NCR_J.SAIKAKO_SIJI_NO)).Value = _V002_NCR_J.SAIKAKO_SIJI_NO
            ssgSheet1.Range(NameOf(_V002_NCR_J.SAISIN_GIJYUTU_SYAIN_NAME)).Value = _V002_NCR_J.SAISIN_GIJYUTU_SYAIN_NAME
            ssgSheet1.Range(NameOf(_V002_NCR_J.SAISIN_HINSYO_SYAIN_NAME)).Value = _V002_NCR_J.SAISIN_HINSYO_SYAIN_NAME
            ssgSheet1.Range(NameOf(_V002_NCR_J.SAISIN_HINSYO_YMD)).Value = _V002_NCR_J.SAISIN_HINSYO_YMD
            If Not _V002_NCR_J.SAISIN_IINKAI_HANTEI_KB.IsNullOrWhiteSpace Then
                ssgSheet1.Range(NameOf(_V002_NCR_J.SAISIN_IINKAI_HANTEI_KB) & _V002_NCR_J.SAISIN_IINKAI_HANTEI_KB).Value = "TRUE"
            End If
            ssgSheet1.Range(NameOf(_V002_NCR_J.SAISIN_IINKAI_SIRYO_NO)).Value = _V002_NCR_J.SAISIN_IINKAI_SIRYO_NO
            ssgSheet1.Range(NameOf(_V002_NCR_J.SAISIN_KAKUNIN_SYAIN_NAME)).Value = _V002_NCR_J.SAISIN_KAKUNIN_SYAIN_NAME
            ssgSheet1.Range(NameOf(_V002_NCR_J.SAISIN_KAKUNIN_YMD)).Value = _V002_NCR_J.SAISIN_KAKUNIN_YMD
            ssgSheet1.Range(NameOf(_V002_NCR_J.SEIGI_TANTO_NAME)).Value = _V002_NCR_J.SEIGI_TANTO_NAME
            ssgSheet1.Range(NameOf(_V002_NCR_J.SEIZO_TANTO_NAME)).Value = _V002_NCR_J.SEIZO_TANTO_NAME
            ssgSheet1.Range(NameOf(_V002_NCR_J.SURYO)).Value = _V002_NCR_J.SURYO
            ssgSheet1.Range(NameOf(_V002_NCR_J.SYOCHI_D_SYOCHI_KIROKU)).Value = _V002_NCR_J.SYOCHI_D_SYOCHI_KIROKU
            ssgSheet1.Range(NameOf(_V002_NCR_J.SYOCHI_D_UMU_NAME)).Value = _V002_NCR_J.SYOCHI_D_UMU_NAME
            ssgSheet1.Range(NameOf(_V002_NCR_J.SYOCHI_D_YOHI_NAME)).Value = _V002_NCR_J.SYOCHI_D_YOHI_NAME
            ssgSheet1.Range(NameOf(_V002_NCR_J.SYOCHI_E_SYOCHI_KIROKU)).Value = _V002_NCR_J.SYOCHI_E_SYOCHI_KIROKU
            ssgSheet1.Range(NameOf(_V002_NCR_J.SYOCHI_E_UMU_NAME)).Value = _V002_NCR_J.SYOCHI_E_UMU_NAME
            ssgSheet1.Range(NameOf(_V002_NCR_J.SYOCHI_E_YOHI_NAME)).Value = _V002_NCR_J.SYOCHI_E_YOHI_NAME
            ssgSheet1.Range(NameOf(_V002_NCR_J.SYOCHI_KEKKA_A_NAME)).Value = _V002_NCR_J.SYOCHI_KEKKA_A_NAME
            ssgSheet1.Range(NameOf(_V002_NCR_J.SYOCHI_KEKKA_B_NAME)).Value = _V002_NCR_J.SYOCHI_KEKKA_B_NAME
            ssgSheet1.Range(NameOf(_V002_NCR_J.SYOCHI_KEKKA_C_NAME)).Value = _V002_NCR_J.SYOCHI_KEKKA_C_NAME
            ssgSheet1.Range(NameOf(_V002_NCR_J.TENYO_BUHIN_BANGO)).Value = _V002_NCR_J.TENYO_BUHIN_BANGO
            ssgSheet1.Range(NameOf(_V002_NCR_J.TENYO_GOKI)).Value = _V002_NCR_J.TENYO_GOKI
            ssgSheet1.Range(NameOf(_V002_NCR_J.TENYO_KISYU)).Value = _V002_NCR_J.TENYO_KISYU
            ssgSheet1.Range(NameOf(_V002_NCR_J.TENYO_YMD)).Value = _V002_NCR_J.TENYO_YMD
            ssgSheet1.Range(NameOf(_V002_NCR_J.YOKYU_NAIYO)).Value = _V002_NCR_J.YOKYU_NAIYO
            ssgSheet1.Range(NameOf(_V002_NCR_J.ZUMEN_KIKAKU)).Value = "(�}��/�K�i�@�F " & _V002_NCR_J.ZUMEN_KIKAKU.PadRight(50) & ")"

            ssgSheet1.Range("SYONIN_NAME10").Value = _V003_SYONIN_J_KANRI_List.Where(Function(r) r.SYONIN_JUN = ENM_NCR_STAGE._10_�N������).FirstOrDefault?.SYAIN_NAME
            ssgSheet1.Range("SYONIN_NAME20").Value = _V003_SYONIN_J_KANRI_List.Where(Function(r) r.SYONIN_JUN = ENM_NCR_STAGE._20_�N���m�F����GL).FirstOrDefault?.SYAIN_NAME
            ssgSheet1.Range("SYONIN_NAME30").Value = _V003_SYONIN_J_KANRI_List.Where(Function(r) r.SYONIN_JUN = ENM_NCR_STAGE._30_�N���m�F����).FirstOrDefault?.SYAIN_NAME
            ssgSheet1.Range("SYONIN_NAME90").Value = _V003_SYONIN_J_KANRI_List.Where(Function(r) r.SYONIN_JUN = ENM_NCR_STAGE._90_���u���{�m�F_�Ǘ�T).FirstOrDefault?.SYAIN_NAME
            ssgSheet1.Range("SYONIN_NAME100").Value = _V003_SYONIN_J_KANRI_List.Where(Function(r) r.SYONIN_JUN = ENM_NCR_STAGE._100_���u���{����_�����ے�).FirstOrDefault?.SYAIN_NAME
            ssgSheet1.Range("SYONIN_NAME110").Value = _V003_SYONIN_J_KANRI_List.Where(Function(r) r.SYONIN_JUN = ENM_NCR_STAGE._110_abcde���u�S��).FirstOrDefault?.SYAIN_NAME
            ssgSheet1.Range("SYONIN_NAME120").Value = _V003_SYONIN_J_KANRI_List.Where(Function(r) r.SYONIN_JUN = ENM_NCR_STAGE._120_abcde���u�m�F).FirstOrDefault?.SYAIN_NAME
            ssgSheet1.Range("SYONIN_YMD20").Value = _V003_SYONIN_J_KANRI_List.Where(Function(r) r.SYONIN_JUN = ENM_NCR_STAGE._20_�N���m�F����GL And r.SYONIN_HANTEI_KB = ENM_SYONIN_HANTEI_KB._1_���F).FirstOrDefault?.SYONIN_YMDHNS
            ssgSheet1.Range("SYONIN_YMD30").Value = _V003_SYONIN_J_KANRI_List.Where(Function(r) r.SYONIN_JUN = ENM_NCR_STAGE._30_�N���m�F���� And r.SYONIN_HANTEI_KB = ENM_SYONIN_HANTEI_KB._1_���F).FirstOrDefault?.SYONIN_YMDHNS
            ssgSheet1.Range("SYONIN_YMD90").Value = _V003_SYONIN_J_KANRI_List.Where(Function(r) r.SYONIN_JUN = ENM_NCR_STAGE._90_���u���{�m�F_�Ǘ�T And r.SYONIN_HANTEI_KB = ENM_SYONIN_HANTEI_KB._1_���F).FirstOrDefault?.SYONIN_YMDHNS
            ssgSheet1.Range("SYONIN_YMD100").Value = _V003_SYONIN_J_KANRI_List.Where(Function(r) r.SYONIN_JUN = ENM_NCR_STAGE._100_���u���{����_�����ے� And r.SYONIN_HANTEI_KB = ENM_SYONIN_HANTEI_KB._1_���F).FirstOrDefault?.SYONIN_YMDHNS
            ssgSheet1.Range("SYONIN_YMD110").Value = _V003_SYONIN_J_KANRI_List.Where(Function(r) r.SYONIN_JUN = ENM_NCR_STAGE._110_abcde���u�S�� And r.SYONIN_HANTEI_KB = ENM_SYONIN_HANTEI_KB._1_���F).FirstOrDefault?.SYONIN_YMDHNS

            '-----�t�@�C���ۑ�
            ssgSheet1.SaveAs(filename:=strFilePath, fileFormat:=SpreadsheetGear.FileFormat.Excel8)
            ssgWorkbook.WorkbookSet.ReleaseLock()

            '-----Spire�� ����PDF���s����Ȃ炱����
            Dim workbook As New Spire.Xls.Workbook
            workbook.LoadFromFile(strFilePath)
            Dim pdfFilePath As String
            pdfFilePath = System.IO.Path.GetDirectoryName(strFilePath) & "\" & System.IO.Path.GetFileNameWithoutExtension(strFilePath) & ".pdf"
            workbook.SaveToFile(pdfFilePath, Spire.Xls.FileFormat.PDF)

            ''PDF�\��
            System.Diagnostics.Process.Start(pdfFilePath)

            'Excel��ƃt�@�C�����폜
            Try
                System.IO.File.Delete(strFilePath)
            Catch ex As UnauthorizedAccessException
            End Try

            Return True

        Catch ex As Exception
            EM.ErrorSyori(ex, False, conblnNonMsg)
            Return False
        Finally
            ssgSheet1 = Nothing
            ssgWorksheets = Nothing
            ssgWorkbook = Nothing
        End Try
    End Function

#End Region

#Region "����"
    Private Function OpenFormHistory(ByVal SYONIN_HOKOKU_ID As Integer, ByVal HOKOKU_NO As String) As Boolean
        Dim frmDLG As New FrmG0017
        Dim dlgRET As DialogResult

        Try
            frmDLG.PrSYONIN_HOKOKUSYO_ID = SYONIN_HOKOKU_ID
            frmDLG.PrHOKOKU_NO = HOKOKU_NO
            dlgRET = frmDLG.ShowDialog(Me)
            If dlgRET = Windows.Forms.DialogResult.Cancel Then
                Return False
            Else
                Me.Close()
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
                cmdFunc10.Enabled = True
                cmdFunc11.Enabled = True

                'SPEC: 40-3.�C
                If PrDialog = False AndAlso (_D003_NCR_J._ZESEI_SYOCHI_YOHI_KB = ENM_YOHI_KB._1_�v) Then

                    If PrMODE = ENM_DATA_OPERATION_MODE._1_ADD Then
                        MyBase.ToolTip.SetToolTip(Me.cmdFunc9, "�V�K�o�^���͎g�p�o���܂���")
                    Else
                        MyBase.ToolTip.SetToolTip(Me.cmdFunc9, "�ҏW����������܂���")
                    End If
                    cmdFunc9.Enabled = True
                Else
                    cmdFunc9.Enabled = False
                    MyBase.ToolTip.SetToolTip(Me.cmdFunc9, "����CAR��ʂ���Ăяo����Ă��邽�ߎg�p�o���܂���")
                End If

                '�J�����g�X�e�[�W�����g�̒S���łȂ��ꍇ�͖���
                If FunblnOwnCreated(ENM_SYONIN_HOKOKUSYO_ID._1_NCR, _D003_NCR_J.HOKOKU_NO, PrDataRow.Item("SYONIN_JUN")) Then 'If TabSTAGE.TabPages(TabSTAGE.SelectedIndex).Enabled = False Then
                    cmdFunc1.Enabled = True
                    cmdFunc2.Enabled = True
                    cmdFunc4.Enabled = True
                    cmdFunc5.Enabled = True
                Else
                    cmdFunc1.Enabled = False
                    cmdFunc2.Enabled = False
                    cmdFunc4.Enabled = False
                    cmdFunc5.Enabled = False
                End If

                'SPEC: 80-2.�D
                Select Case PrCurrentStage
                    Case ENM_NCR_STAGE._10_�N������
                        cmdFunc5.Enabled = False
                    Case ENM_NCR_STAGE._81_���u���{_���Z, ENM_NCR_STAGE._82_���u���{_����, ENM_NCR_STAGE._83_���u���{_����
                        cmdFunc1.Enabled = False
                    Case Else
                End Select

            End If


            Return True
        Catch ex As Exception
            EM.ErrorSyori(ex, False, conblnNonMsg)
            Return False
        End Try
    End Function

#End Region

#End Region

#Region "�R���g���[���C�x���g"

#Region "�^�u�֘A"

#Region "������"
    Private Function FunInitializeTabControl(ByVal intCurrentTabNo As Integer) As Boolean
        Dim strStageName As String
        Try
            _tabPageManager = New TabPageManager(TabSTAGE)

            For Each page As TabPageEx In TabSTAGE.TabPages
                If page.Name <> "tabAttachment" Then
                    Dim intTabNo As Integer = Val(page.Name.Substring(8))

                    If intTabNo < intCurrentTabNo Then
                        'SPEC: 10-2.�B
                        strStageName = tblNCR.AsEnumerable.Where(Function(r) r.Field(Of Integer)("VALUE") = FunConvertSTAGE_NO_TO_SYONIN_JUN2(Val(page.Name.Substring(8)))).FirstOrDefault.Item("DISP")
                        page.Text = strStageName

                        Dim ctrlLabel As Control() = Me.Controls.Find("lblSTAGE" & intTabNo.ToString("00"), True)
                        If ctrlLabel.Length > 0 Then
                            Dim lblSTAGE As Label = ctrlLabel(0)
                            lblSTAGE.Text = strStageName
                        End If

                    ElseIf intTabNo = intCurrentTabNo Then
                        page.Text = "���X�e�[�W"
                        strStageName = tblNCR.AsEnumerable.Where(Function(r) r.Field(Of Integer)("VALUE") = FunConvertSTAGE_NO_TO_SYONIN_JUN2(Val(page.Name.Substring(8)))).FirstOrDefault.Item("DISP")
                        Dim ctrlLabel As Control() = Me.Controls.Find("lblSTAGE" & intTabNo.ToString("00"), True)
                        If ctrlLabel.Length > 0 Then
                            Dim lblSTAGE As Label = ctrlLabel(0)
                            lblSTAGE.Text = strStageName
                        End If

                        '���X�e�[�W�̏��F�S���ҁE�R�����g�����o�C���h
                        Dim ctrlTANTO As Control() = Me.Controls.Find("cmbST" & intCurrentTabNo.ToString("00") & "_DestTANTO", True)
                        If ctrlTANTO.Length > 0 Then
                            Dim cmbTANTO As ComboboxEx = ctrlTANTO(0)
                            cmbTANTO.NullValue = 0
                            cmbTANTO.DataBindings.Add(New Binding(NameOf(cmbTANTO.SelectedValue), _D004_SYONIN_J_KANRI, NameOf(_D004_SYONIN_J_KANRI.SYAIN_ID), False, DataSourceUpdateMode.OnPropertyChanged, 0))
                        End If
                        Dim ctrlCOMMENT As Control() = Me.Controls.Find("txtST" & intCurrentTabNo.ToString("00") & "_Comment", True)
                        If ctrlCOMMENT.Length > 0 Then
                            Dim txtCOMMENT As TextBoxEx = ctrlCOMMENT(0)
                            txtCOMMENT.DataBindings.Add(New Binding(NameOf(txtCOMMENT.Text), _D004_SYONIN_J_KANRI, NameOf(_D004_SYONIN_J_KANRI.COMMENT), False, DataSourceUpdateMode.OnPropertyChanged, ""))
                        End If

                    ElseIf intTabNo > intCurrentTabNo Then
                        'SPEC: 10-2 �A
                        _tabPageManager.ChangeTabPageVisible(page.TabIndex, False)
                    End If

                    'SPEC: 10-2.�D 
                    If PrMODE = ENM_DATA_OPERATION_MODE._1_ADD Then
                        '�V�K�쐬��
                        'SPEC: (3).B 
                        page.Enabled = True
                    Else
                        If PrDataRow("SYONIN_JUN") >= ENM_NCR_STAGE._90_���u���{�m�F_�Ǘ�T Then
                            If Val(page.Name.Substring(8)) = intCurrentTabNo Then
                                page.Enabled = True
                            Else
                                page.Enabled = False
                            End If
                        Else
                            '�J�����g���[�U�[�ȊO�͎Q�Ƃ̂�

                            'page.Enabled = FunblnOwnCreated(ENM_SYONIN_HOKOKUSYO_ID._1_NCR, PrDataRow("HOKOKU_NO"), FunConvertSTAGE_NO_TO_SYONIN_JUN(intTabNo))
                            page.EnableDisablePages(FunblnOwnCreated(ENM_SYONIN_HOKOKUSYO_ID._1_NCR, PrDataRow("HOKOKU_NO"), FunConvertSTAGE_NO_TO_SYONIN_JUN2(intTabNo)))
                            'page.EnableDisablePages(FunblnOwnCreated(ENM_SYONIN_HOKOKUSYO_ID._1_NCR, PrDataRow("HOKOKU_NO"), PrCurrentStage))
                        End If
                    End If
                End If
            Next page


            '�Y�t�����^�u������
            Dim strRootDir As String
            Using DB As ClsDbUtility = DBOpen()
                strRootDir = FunConvPathString(FunGetCodeMastaValue(DB, "�Y�t�t�@�C���ۑ���", My.Application.Info.AssemblyName))
            End Using
            If Not _D003_NCR_J.FILE_PATH.IsNullOrWhiteSpace Then
                lbltmpFile1.Text = CompactString(_D003_NCR_J.FILE_PATH, lbltmpFile1, EllipsisFormat._4_Path)
                lbltmpFile1.Links.Clear()
                lbltmpFile1.Links.Add(0, lbltmpFile1.Text.Length, strRootDir & _D003_NCR_J.HOKOKU_NO.Trim & "\" & _D003_NCR_J.FILE_PATH)
                lbltmpFile1.Visible = True
                lbltmpFile1_Clear.Visible = True
            End If
            If Not _D003_NCR_J.G_FILE_PATH1.IsNullOrWhiteSpace Then
                Call SetPict1Data({strRootDir & _D003_NCR_J.HOKOKU_NO.Trim & "\" & _D003_NCR_J.G_FILE_PATH1})
            End If
            If Not _D003_NCR_J.G_FILE_PATH2.IsNullOrWhiteSpace Then
                Call SetPict2Data({strRootDir & _D003_NCR_J.HOKOKU_NO.Trim & "\" & _D003_NCR_J.G_FILE_PATH2})
            End If

            Return True
        Catch ex As Exception
            EM.ErrorSyori(ex, False, conblnNonMsg)
            Return False
        Finally
        End Try
    End Function

#End Region

#Region "STAGE�ʃR���g���[��������"
    Private Function FunInitializeSTAGE(ByVal intStageID As Integer) As Boolean
        Dim dt As New DataTable
        Dim _V003 As New MODEL.V003_SYONIN_J_KANRI
        Try

#Region "               10"
            If intStageID >= ENM_NCR_STAGE._10_�N������ Then
                dt = FunGetSYONIN_SYOZOKU_SYAIN(cmbBUMON.SelectedValue, ENM_SYONIN_HOKOKUSYO_ID._1_NCR, FunGetNextSYONIN_JUN(ENM_NCR_STAGE._10_�N������))
                'dt = tblTANTO_SYONIN.AsEnumerable.
                '                            Where(Function(r) r.Field(Of Integer)("SYONIN_HOKOKUSYO_ID") = 1 And r.Field(Of Integer)("SYONIN_JUN") = FunGetNextSYONIN_JUN(ENM_NCR_STAGE._10_�N������)).
                '                            CopyToDataTable
                cmbST01_DestTANTO.SetDataSource(dt, ENM_COMBO_SELECT_VALUE_TYPE._0_Required)

                mtxST01_UPD_YMD.Text = Today.ToString("yyyy/MM/dd")
                mtxST01_UPD_YMD.Enabled = False
                mtxST01_NextStageName.Text = FunGetCurrentStageName(FunGetNextSYONIN_JUN(ENM_NCR_STAGE._10_�N������))
                mtxST01_NextStageName.Enabled = False

                If PrMODE = ENM_DATA_OPERATION_MODE._3_UPDATE Then
                    _D003_NCR_J.YOKYU_NAIYO = _V002_NCR_J.YOKYU_NAIYO
                    _D003_NCR_J.KANSATU_KEKKA = _V002_NCR_J.KANSATU_KEKKA

                    _V003 = _V003_SYONIN_J_KANRI_List.AsEnumerable.
                                Where(Function(r) r.SYONIN_JUN = ENM_NCR_STAGE._10_�N������).
                                FirstOrDefault

                    If _V003 IsNot Nothing Then
                        If Not _V003.RIYU.IsNullOrWhiteSpace And intStageID = ENM_NCR_STAGE._10_�N������ Then lblST01_Modoshi_Riyu.Visible = True
                        If _V003.SASIMODOSI_FG Then
                            lblST01_Modoshi_Riyu.Text = "���ߗ��R�F" & _V003.RIYU
                        Else
                            '�]����
                            lblST01_Modoshi_Riyu.Text = "�]�����R�F" & _V003.RIYU
                        End If
                        cmbST01_DestTANTO.SelectedValue = _V003.SYAIN_ID
                        If intStageID > ENM_NCR_STAGE._10_�N������ Then
                            cmbST01_DestTANTO.Enabled = False
                        End If
                    End If
                End If
            End If
#End Region
#Region "               20"
            If intStageID >= ENM_NCR_STAGE._20_�N���m�F����GL Then
                dt = FunGetSYONIN_SYOZOKU_SYAIN(cmbBUMON.SelectedValue, ENM_SYONIN_HOKOKUSYO_ID._1_NCR, FunGetNextSYONIN_JUN(ENM_NCR_STAGE._20_�N���m�F����GL))
                'dt = tblTANTO_SYONIN.AsEnumerable.
                'Where(Function(r) r.Field(Of Integer)("SYONIN_HOKOKUSYO_ID") = 1 And r.Field(Of Integer)("SYONIN_JUN") = FunGetNextSYONIN_JUN(ENM_NCR_STAGE._20_�N���m�F����GL)).
                'CopyToDataTable
                cmbST02_DestTANTO.SetDataSource(dt, ENM_COMBO_SELECT_VALUE_TYPE._0_Required)


                mtxST02_UPD_YMD.Enabled = False
                mtxST02_NextStageName.Text = FunGetCurrentStageName(FunGetNextSYONIN_JUN(ENM_NCR_STAGE._20_�N���m�F����GL))
                mtxST02_NextStageName.Enabled = False

                If PrMODE = ENM_DATA_OPERATION_MODE._3_UPDATE Then
                    _V003 = _V003_SYONIN_J_KANRI_List.AsEnumerable.
                                Where(Function(r) r.SYONIN_JUN = ENM_NCR_STAGE._20_�N���m�F����GL).
                                FirstOrDefault

                    cmbST02_DestTANTO.SelectedValue = _V003.SYAIN_ID
                    txtST02_Comment.Text = _V003.COMMENT

                    If _V003 IsNot Nothing Then
                        If Not _V003.RIYU.IsNullOrWhiteSpace And intStageID = ENM_NCR_STAGE._20_�N���m�F����GL Then lblST02_Modoshi_Riyu.Visible = True
                        If _V003.SASIMODOSI_FG Then
                            lblST02_Modoshi_Riyu.Text = "���ߗ��R�F" & _V003.RIYU
                        Else
                            '�]����
                            lblST02_Modoshi_Riyu.Text = "�]�����R�F" & _V003.RIYU
                        End If

                        mtxST02_UPD_YMD.Text = DateTime.ParseExact(_V003.ADD_YMDHNS, "yyyyMMddHHmmss", Nothing).ToString("yyy/MM/dd")

                        If intStageID > ENM_NCR_STAGE._20_�N���m�F����GL Then
                            cmbST02_DestTANTO.Enabled = False
                            txtST02_Comment.Enabled = False
                        End If
                    Else
                        mtxST02_UPD_YMD.Text = Today.ToString("yyyy/MM/dd")
                    End If
                End If
            End If
#End Region
#Region "               30"
            If intStageID >= ENM_NCR_STAGE._30_�N���m�F���� Then
                dt = FunGetSYONIN_SYOZOKU_SYAIN(cmbBUMON.SelectedValue, ENM_SYONIN_HOKOKUSYO_ID._1_NCR, FunGetNextSYONIN_JUN(ENM_NCR_STAGE._30_�N���m�F����))
                'dt = tblTANTO_SYONIN.AsEnumerable.
                '                Where(Function(r) r.Field(Of Integer)("SYONIN_HOKOKUSYO_ID") = 1 And r.Field(Of Integer)("SYONIN_JUN") = FunGetNextSYONIN_JUN(ENM_NCR_STAGE._30_�N���m�F����)).
                '                CopyToDataTable
                cmbST03_DestTANTO.SetDataSource(dt, ENM_COMBO_SELECT_VALUE_TYPE._0_Required)


                mtxST03_NextStageName.Text = FunGetCurrentStageName(FunGetNextSYONIN_JUN(ENM_NCR_STAGE._30_�N���m�F����))
                mtxST03_UPD_YMD.Enabled = False
                mtxST03_NextStageName.Enabled = False

                If PrMODE = ENM_DATA_OPERATION_MODE._3_UPDATE Then
                    _V003 = _V003_SYONIN_J_KANRI_List.AsEnumerable.
                                Where(Function(r) r.SYONIN_JUN = ENM_NCR_STAGE._30_�N���m�F����).
                                FirstOrDefault

                    If _V003 IsNot Nothing Then
                        cmbST03_DestTANTO.SelectedValue = _V003.SYAIN_ID
                        txtST03_Comment.Text = _V003.COMMENT

                        mtxST03_UPD_YMD.Text = DateTime.ParseExact(_V003.ADD_YMDHNS, "yyyyMMddHHmmss", Nothing).ToString("yyy/MM/dd")

                        If Not _V003.RIYU.IsNullOrWhiteSpace And intStageID = ENM_NCR_STAGE._30_�N���m�F���� Then lblST03_Modoshi_Riyu.Visible = True

                        If _V003.SASIMODOSI_FG Then
                            lblST03_Modoshi_Riyu.Text = "���ߗ��R�F" & _V003.RIYU
                        Else
                            '�]����
                            lblST03_Modoshi_Riyu.Text = "�]�����R�F" & _V003.RIYU
                        End If
                        If intStageID > ENM_NCR_STAGE._30_�N���m�F���� Then
                            cmbST03_DestTANTO.Enabled = False
                            txtST03_Comment.Enabled = False
                        End If
                    Else
                        mtxST03_UPD_YMD.Text = Today.ToString("yyyy/MM/dd")
                    End If
                End If
            End If
#End Region
#Region "               40"
            If intStageID >= ENM_NCR_STAGE._40_���O�R������y��CAR�v�۔��� Then
                dt = FunGetSYONIN_SYOZOKU_SYAIN(cmbBUMON.SelectedValue, ENM_SYONIN_HOKOKUSYO_ID._1_NCR, FunGetNextSYONIN_JUN(ENM_NCR_STAGE._40_���O�R������y��CAR�v�۔���))
                'dt = tblTANTO_SYONIN.AsEnumerable.
                '                            Where(Function(r) r.Field(Of Integer)("SYONIN_HOKOKUSYO_ID") = 1 And r.Field(Of Integer)("SYONIN_JUN") = FunGetNextSYONIN_JUN(ENM_NCR_STAGE._40_���O�R������y��CAR�v�۔���)).
                '                            CopyToDataTable
                cmbST04_DestTANTO.SetDataSource(dt, ENM_COMBO_SELECT_VALUE_TYPE._0_Required)


                mtxST04_NextStageName.Text = FunGetCurrentStageName(FunGetNextSYONIN_JUN(ENM_NCR_STAGE._40_���O�R������y��CAR�v�۔���))
                mtxST04_UPD_YMD.Enabled = False
                mtxST04_NextStageName.Enabled = False

                cmbST04_JIZENSINSA_HANTEI.SetDataSource(tblJIZEN_SINSA_HANTEI_KB.ExcludeDeleted, ENM_COMBO_SELECT_VALUE_TYPE._0_Required)

                If PrMODE = ENM_DATA_OPERATION_MODE._3_UPDATE Then
                    _V003 = _V003_SYONIN_J_KANRI_List.AsEnumerable.
                                Where(Function(r) r.SYONIN_JUN = ENM_NCR_STAGE._40_���O�R������y��CAR�v�۔���).
                                FirstOrDefault

                    _D003_NCR_J.JIZEN_SINSA_HANTEI_KB = _V002_NCR_J.JIZEN_SINSA_HANTEI_KB
                    _D003_NCR_J.ZESEI_SYOCHI_YOHI_KB = CBool(_V002_NCR_J.ZESEI_SYOCHI_YOHI_KB)
                    If _D003_NCR_J.ZESEI_SYOCHI_YOHI_KB Then
                        rbtnST04_ZESEI_YES.Checked = True
                    Else
                        rbtnST04_ZESEI_NO.Checked = True
                    End If

                    _D003_NCR_J.ZESEI_NASI_RIYU = _V002_NCR_J.ZESEI_NASI_RIYU

                    If _V003 IsNot Nothing Then
                        cmbST04_DestTANTO.SelectedValue = _V003.SYAIN_ID
                        txtST04_Comment.Text = _V003.COMMENT
                        mtxST04_UPD_YMD.Text = DateTime.ParseExact(_V003.ADD_YMDHNS, "yyyyMMddHHmmss", Nothing).ToString("yyy/MM/dd")
                        If Not _V003.RIYU.IsNullOrWhiteSpace And intStageID = ENM_NCR_STAGE._40_���O�R������y��CAR�v�۔��� Then lblST04_Modoshi_Riyu.Visible = True
                        If _V003.SASIMODOSI_FG Then
                            lblST04_Modoshi_Riyu.Text = "���ߗ��R�F" & _V003.RIYU
                        Else
                            '�]����
                            lblST04_Modoshi_Riyu.Text = "�]�����R�F" & _V003.RIYU
                        End If

                        If intStageID > ENM_NCR_STAGE._40_���O�R������y��CAR�v�۔��� Then
                            cmbST04_DestTANTO.Enabled = False
                            txtST04_Comment.Enabled = False
                            cmbST04_JIZENSINSA_HANTEI.Enabled = False
                            pnlST04_ZESEI.Enabled = False

                        End If
                    Else
                        mtxST04_UPD_YMD.Text = Today.ToString("yyyy/MM/dd")
                    End If
                End If
            End If

#End Region
#Region "               50"
            If intStageID >= ENM_NCR_STAGE._50_���O�R���m�F Then
                dt = FunGetSYONIN_SYOZOKU_SYAIN(cmbBUMON.SelectedValue, ENM_SYONIN_HOKOKUSYO_ID._1_NCR, FunGetNextSYONIN_JUN(ENM_NCR_STAGE._50_���O�R���m�F))
                'dt = tblTANTO_SYONIN.AsEnumerable.
                '                        Where(Function(r) r.Field(Of Integer)("SYONIN_HOKOKUSYO_ID") = 1 And r.Field(Of Integer)("SYONIN_JUN") = FunGetNextSYONIN_JUN(ENM_NCR_STAGE._50_���O�R���m�F)).
                '                        CopyToDataTable
                cmbST05_DestTANTO.SetDataSource(dt, ENM_COMBO_SELECT_VALUE_TYPE._0_Required)

                mtxST05_NextStageName.Text = FunGetCurrentStageName(FunGetNextSYONIN_JUN(ENM_NCR_STAGE._50_���O�R���m�F))
                mtxST05_UPD_YMD.Enabled = False
                mtxST05_NextStageName.Enabled = False

                If PrMODE = ENM_DATA_OPERATION_MODE._3_UPDATE Then
                    _V003 = _V003_SYONIN_J_KANRI_List.AsEnumerable.
                                Where(Function(r) r.SYONIN_JUN = ENM_NCR_STAGE._50_���O�R���m�F).
                                FirstOrDefault

                    If _V003 IsNot Nothing Then
                        cmbST05_DestTANTO.SelectedValue = _V003.SYAIN_ID
                        txtST05_Comment.Text = _V003.COMMENT
                        mtxST05_UPD_YMD.Text = DateTime.ParseExact(_V003.ADD_YMDHNS, "yyyyMMddHHmmss", Nothing).ToString("yyy/MM/dd")
                        If Not _V003.RIYU.IsNullOrWhiteSpace And intStageID = ENM_NCR_STAGE._50_���O�R���m�F Then lblST05_Modoshi_Riyu.Visible = True
                        If _V003.SASIMODOSI_FG Then
                            lblST05_Modoshi_Riyu.Text = "���ߗ��R�F" & _V003.RIYU
                        Else
                            '�]����
                            lblST05_Modoshi_Riyu.Text = "�]�����R�F" & _V003.RIYU
                        End If
                        If intStageID > ENM_NCR_STAGE._50_���O�R���m�F Then
                            cmbST05_DestTANTO.Enabled = False
                            txtST05_Comment.Enabled = False
                        End If
                    Else
                        mtxST05_UPD_YMD.Text = Today.ToString("yyyy/MM/dd")
                    End If
                End If
            End If
#End Region
#Region "               60"
            If intStageID = ENM_NCR_STAGE._60_�ĐR�R������_�Z�p��\ Then
                dt = FunGetSYONIN_SYOZOKU_SYAIN(cmbBUMON.SelectedValue, ENM_SYONIN_HOKOKUSYO_ID._1_NCR, FunGetNextSYONIN_JUN(ENM_NCR_STAGE._60_�ĐR�R������_�Z�p��\))
                'dt = tblTANTO_SYONIN.AsEnumerable.
                '                        Where(Function(r) r.Field(Of Integer)("SYONIN_HOKOKUSYO_ID") = 1 And r.Field(Of Integer)("SYONIN_JUN") = FunGetNextSYONIN_JUN(ENM_NCR_STAGE._60_�ĐR�R������_�Z�p��\)).
                '                        CopyToDataTable
                cmbST06_DestTANTO.SetDataSource(dt, ENM_COMBO_SELECT_VALUE_TYPE._0_Required)

                mtxST06_NextStageName.Text = FunGetCurrentStageName(FunGetNextSYONIN_JUN(ENM_NCR_STAGE._60_�ĐR�R������_�Z�p��\))
                cmbST06_SAISIN_IINKAI_HANTEI.SetDataSource(tblSAISIN_IINKAI_HANTEI_KB.ExcludeDeleted, ENM_COMBO_SELECT_VALUE_TYPE._0_Required)
                mtxST06_NextStageName.Enabled = False
                mtxST06_UPD_YMD.Enabled = False

                'SPEC: 60-2.�B
                cmbKISYU.Enabled = False
                cmbSYANAI_CD.Enabled = False
                cmbFUTEKIGO_STATUS.Enabled = False
                cmbFUTEKIGO_KB.Enabled = False
                cmbFUTEKIGO_S_KB.Enabled = False
                cmbBUMON.Enabled = False
                mtxGOUKI.Enabled = False
                cmbBUHIN_BANGO.Enabled = False
                mtxHENKYAKU_RIYU.Enabled = False
                cmbFUTEKIGO_S_KB.Enabled = False
                cmbKISO_TANTO.Enabled = False
                mtxHINMEI.Enabled = False
                mtxZUBAN_KIKAKU.Enabled = False
                numSU.Enabled = False

                If PrMODE = ENM_DATA_OPERATION_MODE._3_UPDATE Then
                    _V003 = _V003_SYONIN_J_KANRI_List.AsEnumerable.
                                Where(Function(r) r.SYONIN_JUN = ENM_NCR_STAGE._60_�ĐR�R������_�Z�p��\).
                                FirstOrDefault

                    _D003_NCR_J.SAISIN_IINKAI_HANTEI_KB = _V002_NCR_J.SAISIN_IINKAI_HANTEI_KB
                    _D003_NCR_J.SAISIN_IINKAI_SIRYO_NO = _V002_NCR_J.SAISIN_IINKAI_SIRYO_NO

                    If _V003 IsNot Nothing Then
                        cmbST06_DestTANTO.SelectedValue = _V003.SYAIN_ID
                        txtST06_Comment.Text = _V003.COMMENT
                        mtxST06_UPD_YMD.Text = DateTime.ParseExact(_V003.ADD_YMDHNS, "yyyyMMddHHmmss", Nothing).ToString("yyy/MM/dd")
                        If Not _V003.RIYU.IsNullOrWhiteSpace And intStageID = ENM_NCR_STAGE._60_�ĐR�R������_�Z�p��\ Then lblST06_Modoshi_Riyu.Visible = True
                        If _V003.SASIMODOSI_FG Then
                            lblST06_Modoshi_Riyu.Text = "���ߗ��R�F" & _V003.RIYU
                        Else
                            '�]����
                            lblST06_Modoshi_Riyu.Text = "�]�����R�F" & _V003.RIYU
                        End If
                        If intStageID > ENM_NCR_STAGE._60_�ĐR�R������_�Z�p��\ Then
                            cmbST06_DestTANTO.Enabled = False
                            txtST06_Comment.Enabled = False
                        End If
                    Else
                        mtxST06_UPD_YMD.Text = Today.ToString("yyyy/MM/dd")
                    End If
                End If

            End If
#End Region
#Region "               61"
            If intStageID >= ENM_NCR_STAGE._61_�ĐR�R������_�i�ؑ�\ Then
                If FunExistAchievement(ENM_SYONIN_HOKOKUSYO_ID._1_NCR, _D003_NCR_J.HOKOKU_NO, ENM_NCR_STAGE._61_�ĐR�R������_�i�ؑ�\) Then
                    dt = FunGetSYONIN_SYOZOKU_SYAIN(cmbBUMON.SelectedValue, ENM_SYONIN_HOKOKUSYO_ID._1_NCR, FunGetNextSYONIN_JUN(ENM_NCR_STAGE._61_�ĐR�R������_�i�ؑ�\))
                    'dt = tblTANTO_SYONIN.AsEnumerable.
                    '                    Where(Function(r) r.Field(Of Integer)("SYONIN_HOKOKUSYO_ID") = 1 And r.Field(Of Integer)("SYONIN_JUN") = FunGetNextSYONIN_JUN(ENM_NCR_STAGE._61_�ĐR�R������_�i�ؑ�\)).
                    '                    CopyToDataTable
                    cmbST06_DestTANTO.SetDataSource(dt, ENM_COMBO_SELECT_VALUE_TYPE._0_Required)

                    mtxST06_NextStageName.Text = FunGetCurrentStageName(FunGetNextSYONIN_JUN(ENM_NCR_STAGE._61_�ĐR�R������_�i�ؑ�\))
                    cmbST06_SAISIN_IINKAI_HANTEI.SetDataSource(tblSAISIN_IINKAI_HANTEI_KB.ExcludeDeleted, ENM_COMBO_SELECT_VALUE_TYPE._0_Required)
                    mtxST06_UPD_YMD.Enabled = False
                    mtxST06_NextStageName.Enabled = False

                    'SPEC: 60-2.�C
                    cmbST06_SAISIN_IINKAI_HANTEI.Enabled = False
                    mtxST06_SAISIN_IINKAI_SIRYO_NO.Enabled = False

                    If PrMODE = ENM_DATA_OPERATION_MODE._3_UPDATE Then
                        _V003 = _V003_SYONIN_J_KANRI_List.AsEnumerable.
                                    Where(Function(r) r.SYONIN_JUN = ENM_NCR_STAGE._61_�ĐR�R������_�i�ؑ�\).
                                    FirstOrDefault

                        _D003_NCR_J.SAISIN_IINKAI_HANTEI_KB = _V002_NCR_J.SAISIN_IINKAI_HANTEI_KB
                        _D003_NCR_J.SAISIN_IINKAI_SIRYO_NO = _V002_NCR_J.SAISIN_IINKAI_SIRYO_NO

                        If _V003 IsNot Nothing Then
                            cmbST06_DestTANTO.SelectedValue = _V003.SYAIN_ID
                            txtST06_Comment.Text = _V003.COMMENT
                            mtxST06_UPD_YMD.Text = DateTime.ParseExact(_V003.ADD_YMDHNS, "yyyyMMddHHmmss", Nothing).ToString("yyy/MM/dd")
                            If Not _V003.RIYU.IsNullOrWhiteSpace And intStageID = ENM_NCR_STAGE._61_�ĐR�R������_�i�ؑ�\ Then lblST06_Modoshi_Riyu.Visible = True
                            If _V003.SASIMODOSI_FG Then
                                lblST06_Modoshi_Riyu.Text = "���ߗ��R�F" & _V003.RIYU
                            Else
                                '�]����
                                lblST06_Modoshi_Riyu.Text = "�]�����R�F" & _V003.RIYU
                            End If
                            If intStageID > ENM_NCR_STAGE._61_�ĐR�R������_�i�ؑ�\ Then
                                cmbST06_DestTANTO.Enabled = False
                                txtST06_Comment.Enabled = False
                            End If
                        Else
                            mtxST06_UPD_YMD.Text = Today.ToString("yyyy/MM/dd")
                        End If
                    End If
                Else
                    '���X�e�[�W���擾�o���Ȃ��ꍇ=�o�^���e�ɂ�菈�����X�L�b�v���ꂽ�ꍇ���̓^�u���Ɣ�\��
                    For Each page As TabPage In TabSTAGE.TabPages
                        If Val(page.Name.Substring(8)) = FunConvertSYONIN_JUN_TO_STAGE_NO(ENM_NCR_STAGE._61_�ĐR�R������_�i�ؑ�\).ToString("00") Then
                            _tabPageManager.ChangeTabPageVisible(page.TabIndex, False)
                            Exit For
                        End If
                    Next
                End If
            End If
#End Region
#Region "               70"
            If intStageID >= ENM_NCR_STAGE._70_�ڋq�ĐR���u_I_tag Then
                If FunExistAchievement(ENM_SYONIN_HOKOKUSYO_ID._1_NCR, _D003_NCR_J.HOKOKU_NO, ENM_NCR_STAGE._70_�ڋq�ĐR���u_I_tag) Then
                    dt = FunGetSYONIN_SYOZOKU_SYAIN(cmbBUMON.SelectedValue, ENM_SYONIN_HOKOKUSYO_ID._1_NCR, FunGetNextSYONIN_JUN(ENM_NCR_STAGE._70_�ڋq�ĐR���u_I_tag))
                    'dt = tblTANTO_SYONIN.AsEnumerable.
                    '            Where(Function(r) r.Field(Of Integer)("SYONIN_HOKOKUSYO_ID") = 1 And r.Field(Of Integer)("SYONIN_JUN") = FunGetNextSYONIN_JUN(ENM_NCR_STAGE._70_�ڋq�ĐR���u_I_tag)).
                    '            CopyToDataTable
                    cmbST07_DestTANTO.SetDataSource(dt, ENM_COMBO_SELECT_VALUE_TYPE._0_Required)

                    mtxST07_NextStageName.Text = FunGetCurrentStageName(FunGetNextSYONIN_JUN(ENM_NCR_STAGE._70_�ڋq�ĐR���u_I_tag))
                    mtxST07_UPD_YMD.Enabled = False
                    mtxST07_NextStageName.Enabled = False

                    '���及���Ј��擾
                    dt = FunGetSYOZOKU_SYAIN(_D003_NCR_J.BUMON_KB)

                    cmbST07_SAISIN_TANTO.SetDataSource(dt, ENM_COMBO_SELECT_VALUE_TYPE._0_Required)
                    cmbST07_KOKYAKU_HANTEI_SIJI.SetDataSource(tblKOKYAKU_HANTEI_SIJI_KB, ENM_COMBO_SELECT_VALUE_TYPE._0_Required)
                    cmbST07_KOKYAKU_SAISYU_HANTEI.SetDataSource(tblKOKYAKU_SAISYU_HANTEI_KB, ENM_COMBO_SELECT_VALUE_TYPE._0_Required)


                    If PrMODE = ENM_DATA_OPERATION_MODE._3_UPDATE Then
                        _V003 = _V003_SYONIN_J_KANRI_List.AsEnumerable.
                                    Where(Function(r) r.SYONIN_JUN = ENM_NCR_STAGE._70_�ڋq�ĐR���u_I_tag).
                                    FirstOrDefault

                        _D003_NCR_J.ITAG_NO = _V002_NCR_J.ITAG_NO
                        _D003_NCR_J.KOKYAKU_SAISIN_TANTO_ID = _V002_NCR_J.KOKYAKU_SAISIN_TANTO_ID
                        _D003_NCR_J.KOKYAKU_HANTEI_SIJI_KB = _V002_NCR_J.KOKYAKU_HANTEI_SIJI_KB
                        _D003_NCR_J.KOKYAKU_HANTEI_SIJI_YMD = _V002_NCR_J.KOKYAKU_HANTEI_SIJI_YMD
                        _D003_NCR_J.KOKYAKU_SAISYU_HANTEI_KB = _V002_NCR_J.KOKYAKU_SAISYU_HANTEI_KB
                        _D003_NCR_J.KOKYAKU_SAISYU_HANTEI_YMD = _V002_NCR_J.KOKYAKU_SAISYU_HANTEI_YMD
                        _D003_NCR_J.SAIKAKO_SIJI_FG = CBool(_V002_NCR_J.SAIKAKO_SIJI_FG)
                        If _D003_NCR_J.SAIKAKO_SIJI_FG Then
                            rbtnST07_Yes.Checked = True
                        Else
                            rbtnST07_No.Checked = True
                        End If

                        If _V003 IsNot Nothing Then
                            cmbST07_DestTANTO.SelectedValue = _V003.SYAIN_ID
                            txtST07_Comment.Text = _V003.COMMENT
                            mtxST07_UPD_YMD.Text = DateTime.ParseExact(_V003.ADD_YMDHNS, "yyyyMMddHHmmss", Nothing).ToString("yyy/MM/dd")
                            If Not _V003.RIYU.IsNullOrWhiteSpace And intStageID = ENM_NCR_STAGE._70_�ڋq�ĐR���u_I_tag Then lblST07_Modoshi_Riyu.Visible = True
                            If _V003.SASIMODOSI_FG Then
                                lblST07_Modoshi_Riyu.Text = "���ߗ��R�F" & _V003.RIYU
                            Else
                                '�]����
                                lblST07_Modoshi_Riyu.Text = "�]�����R�F" & _V003.RIYU
                            End If
                            If intStageID > ENM_NCR_STAGE._70_�ڋq�ĐR���u_I_tag Then
                                cmbST07_DestTANTO.Enabled = False
                                txtST07_Comment.Enabled = False
                            End If
                        Else
                            mtxST07_UPD_YMD.Text = Today.ToString("yyyy/MM/dd")
                        End If
                    End If
                Else
                    '���X�e�[�W���擾�o���Ȃ��ꍇ=�o�^���e�ɂ�菈�����X�L�b�v���ꂽ�ꍇ���̓^�u���Ɣ�\��
                    For Each page As TabPage In TabSTAGE.TabPages
                        If Val(page.Name.Substring(8)) = FunConvertSYONIN_JUN_TO_STAGE_NO(ENM_NCR_STAGE._70_�ڋq�ĐR���u_I_tag).ToString("00") Then
                            _tabPageManager.ChangeTabPageVisible(page.TabIndex, False)
                            Exit For
                        End If
                    Next
                End If
            End If
#End Region
#Region "               80"

            '80
            If intStageID >= ENM_NCR_STAGE._80_���u���{ Then
                If FunExistAchievement(ENM_SYONIN_HOKOKUSYO_ID._1_NCR, _D003_NCR_J.HOKOKU_NO, ENM_NCR_STAGE._80_���u���{) Then
                    dt = FunGetSYONIN_SYOZOKU_SYAIN(cmbBUMON.SelectedValue, ENM_SYONIN_HOKOKUSYO_ID._1_NCR, FunGetNextSYONIN_JUN(ENM_NCR_STAGE._80_���u���{))
                    'dt = tblTANTO_SYONIN.AsEnumerable.
                    '      Where(Function(r) r.Field(Of Integer)("SYONIN_HOKOKUSYO_ID") = 1 And r.Field(Of Integer)("SYONIN_JUN") = FunGetNextSYONIN_JUN(ENM_NCR_STAGE._80_���u���{)).
                    '      CopyToDataTable
                    cmbST08_DestTANTO.SetDataSource(dt, ENM_COMBO_SELECT_VALUE_TYPE._0_Required)

                    mtxST08_NextStageName.Text = FunGetCurrentStageName(FunGetNextSYONIN_JUN(ENM_NCR_STAGE._80_���u���{))
                    mtxST08_UPD_YMD.Enabled = False
                    mtxST08_NextStageName.Enabled = False
                    cmbST08_1_HAIKYAKU_KB.SetDataSource(tblHAIKYAKU_KB, ENM_COMBO_SELECT_VALUE_TYPE._0_Required)

                    cmbST08_2_KENSA_KEKKA.SetDataSource(tblKENSA_KEKKA_KB, ENM_COMBO_SELECT_VALUE_TYPE._0_Required)

                    '���及���Ј��擾
                    dt = FunGetSYOZOKU_SYAIN(_D003_NCR_J.BUMON_KB)
                    cmbST08_1_HAIKYAKU_TANTO.SetDataSource(dt, ENM_COMBO_SELECT_VALUE_TYPE._0_Required)
                    cmbST08_2_TANTO_SEIZO.SetDataSource(dt, ENM_COMBO_SELECT_VALUE_TYPE._2_Option)
                    cmbST08_2_TANTO_SEIGI.SetDataSource(dt, ENM_COMBO_SELECT_VALUE_TYPE._2_Option)
                    cmbST08_2_TANTO_KENSA.SetDataSource(dt, ENM_COMBO_SELECT_VALUE_TYPE._2_Option)
                    cmbST08_3_HENKYAKU_TANTO.SetDataSource(dt, ENM_COMBO_SELECT_VALUE_TYPE._0_Required)

                    Dim drs = tblKISYU.AsEnumerable.Where(Function(r) r.Field(Of String)(NameOf(_D003_NCR_J.BUMON_KB)) = _D003_NCR_J.BUMON_KB).ToList
                    If drs.Count > 0 Then
                        dt = drs.CopyToDataTable
                        cmbST08_4_KISYU.SetDataSource(dt, ENM_COMBO_SELECT_VALUE_TYPE._2_Option)
                        '_D003_NCR_J.KISYU_ID = 0
                    End If

                    drs = tblBUHIN.AsEnumerable.Where(Function(r) r.Field(Of String)(NameOf(_D003_NCR_J.BUMON_KB)) = _D003_NCR_J.BUMON_KB).ToList
                    If drs.Count > 0 Then
                        dt = drs.CopyToDataTable
                        cmbST08_4_BUHIN_BANGO.SetDataSource(dt, ENM_COMBO_SELECT_VALUE_TYPE._2_Option)
                        '_D003_NCR_J.BUHIN_BANGO = ""
                    End If

                    If PrMODE = ENM_DATA_OPERATION_MODE._3_UPDATE Then
                        _V003 = _V003_SYONIN_J_KANRI_List.AsEnumerable.
                                    Where(Function(r) r.SYONIN_JUN = ENM_NCR_STAGE._80_���u���{).
                                    FirstOrDefault

                        _D003_NCR_J.HAIKYAKU_YMD = _V002_NCR_J.HAIKYAKU_YMD
                        _D003_NCR_J.HAIKYAKU_HOUHOU = _V002_NCR_J.HAIKYAKU_HOUHOU
                        _D003_NCR_J.HENKYAKU_BIKO = _V002_NCR_J.HENKYAKU_BIKO
                        _D003_NCR_J.HAIKYAKU_TANTO_ID = _V002_NCR_J.HAIKYAKU_TANTO_ID
                        _D003_NCR_J.SAIKAKO_SIJI_NO = _V002_NCR_J.SAIKAKO_SIJI_NO
                        _D003_NCR_J.SAIKAKO_SAGYO_KAN_YMD = _V002_NCR_J.SAIKAKO_SAGYO_KAN_YMD
                        _D003_NCR_J.SAIKAKO_KENSA_YMD = _V002_NCR_J.SAIKAKO_KENSA_YMD

                        _D003_NCR_J.KENSA_KEKKA_KB = _V002_NCR_J.KENSA_KEKKA_KB
                        _D003_NCR_J.SEIZO_TANTO_ID = _V002_NCR_J.SEIZO_TANTO_ID
                        _D003_NCR_J.SEIGI_TANTO_ID = _V002_NCR_J.SEIGI_TANTO_ID
                        _D003_NCR_J.KENSA_TANTO_ID = _V002_NCR_J.KENSA_TANTO_ID

                        _D003_NCR_J.HENKYAKU_YMD = _V002_NCR_J.HENKYAKU_YMD
                        _D003_NCR_J.HENKYAKU_SAKI = _V002_NCR_J.HENKYAKU_SAKI
                        _D003_NCR_J.HENKYAKU_BIKO = _V002_NCR_J.HENKYAKU_BIKO
                        _D003_NCR_J.HENKYAKU_TANTO_ID = _V002_NCR_J.HENKYAKU_TANTO_ID

                        _D003_NCR_J.TENYO_KISYU_ID = _V002_NCR_J.TENYO_KISYU_ID
                        _D003_NCR_J.TENYO_BUHIN_BANGO = _V002_NCR_J.TENYO_BUHIN_BANGO
                        _D003_NCR_J.TENYO_GOKI = _V002_NCR_J.TENYO_GOKI
                        _D003_NCR_J.TENYO_LOT = _V002_NCR_J.TENYO_LOT
                        _D003_NCR_J.TENYO_YMD = _V002_NCR_J.TENYO_YMD

                        If _V003 IsNot Nothing Then
                            cmbST08_DestTANTO.SelectedValue = _V003.SYAIN_ID
                            txtST08_Comment.Text = _V003.COMMENT
                            mtxST08_UPD_YMD.Text = DateTime.ParseExact(_V003.ADD_YMDHNS, "yyyyMMddHHmmss", Nothing).ToString("yyy/MM/dd")
                            If Not _V003.RIYU.IsNullOrWhiteSpace And intStageID = ENM_NCR_STAGE._80_���u���{ Then lblST08_Modoshi_Riyu.Visible = True
                            If _V003.SASIMODOSI_FG Then
                                lblST08_Modoshi_Riyu.Text = "���ߗ��R�F" & _V003.RIYU
                            Else
                                '�]����
                                lblST08_Modoshi_Riyu.Text = "�]�����R�F" & _V003.RIYU
                            End If
                            If intStageID > ENM_NCR_STAGE._80_���u���{ Then
                                'cmbST08_DestTANTO.Enabled = False
                                'txtST08_Comment.Enabled = False
                                tabST08_SUB.Enabled = False
                            End If
                        Else
                            mtxST08_UPD_YMD.Text = Today.ToString("yyyy/MM/dd")
                        End If

                        'SPEC: 80-2.�C
                        _tabPageManagerST08Sub = New TabPageManager(tabST08_SUB)
                        Dim strTabpageName As String
                        strTabpageName = FunGetST08SubPageName()
                        For Each page As TabPage In tabST08_SUB.TabPages
                            If page.Name = strTabpageName Then
                                tabST08_SUB.SelectedIndex = page.TabIndex
                            Else
                                '��\��
                                _tabPageManagerST08Sub.ChangeTabPageVisible(page.TabIndex, False)
                            End If
                        Next page
                        '
                    End If
                Else
                    '���X�e�[�W���擾�o���Ȃ��ꍇ=�o�^���e�ɂ�菈�����X�L�b�v���ꂽ�ꍇ���̓^�u���Ɣ�\��
                    For Each page As TabPage In TabSTAGE.TabPages
                        If Val(page.Name.Substring(8)) = FunConvertSYONIN_JUN_TO_STAGE_NO(ENM_NCR_STAGE._80_���u���{).ToString("00") Then
                            _tabPageManager.ChangeTabPageVisible(page.TabIndex, False)
                            Exit For
                        End If
                    Next
                End If
            End If





#End Region
#Region "               81"
            '81
            If intStageID = ENM_NCR_STAGE._81_���u���{_���Z Then
                dt = FunGetSYONIN_SYOZOKU_SYAIN(cmbBUMON.SelectedValue, ENM_SYONIN_HOKOKUSYO_ID._1_NCR, FunGetNextSYONIN_JUN(ENM_NCR_STAGE._81_���u���{_���Z))
                'dt = tblTANTO_SYONIN.AsEnumerable.
                '          Where(Function(r) r.Field(Of Integer)("SYONIN_HOKOKUSYO_ID") = 1 And r.Field(Of Integer)("SYONIN_JUN") = FunGetNextSYONIN_JUN(ENM_NCR_STAGE._81_���u���{_���Z)).
                '          CopyToDataTable
                cmbST08_DestTANTO.SetDataSource(dt, ENM_COMBO_SELECT_VALUE_TYPE._0_Required)

                mtxST08_NextStageName.Text = FunGetCurrentStageName(FunGetNextSYONIN_JUN(ENM_NCR_STAGE._81_���u���{_���Z))

                If PrMODE = ENM_DATA_OPERATION_MODE._3_UPDATE Then
                    _V003 = _V003_SYONIN_J_KANRI_List.AsEnumerable.
                                Where(Function(r) r.SYONIN_JUN = ENM_NCR_STAGE._81_���u���{_���Z).
                                FirstOrDefault

                    If _V003 IsNot Nothing Then
                        cmbST08_DestTANTO.SelectedValue = _V003.SYAIN_ID
                        txtST08_Comment.Text = _V003.COMMENT
                        mtxST08_UPD_YMD.Text = DateTime.ParseExact(_V003.ADD_YMDHNS, "yyyyMMddHHmmss", Nothing).ToString("yyy/MM/dd")
                        If Not _V003.RIYU.IsNullOrWhiteSpace And intStageID = ENM_NCR_STAGE._81_���u���{_���Z Then lblST08_Modoshi_Riyu.Visible = True
                        If _V003.SASIMODOSI_FG Then
                            lblST08_Modoshi_Riyu.Text = "���ߗ��R�F" & _V003.RIYU
                        Else
                            '�]����
                            lblST08_Modoshi_Riyu.Text = "�]�����R�F" & _V003.RIYU
                        End If
                    End If
                End If
            End If
#End Region
#Region "               82"
            '82
            If intStageID = ENM_NCR_STAGE._82_���u���{_���� Then
                dt = FunGetSYONIN_SYOZOKU_SYAIN(cmbBUMON.SelectedValue, ENM_SYONIN_HOKOKUSYO_ID._1_NCR, FunGetNextSYONIN_JUN(ENM_NCR_STAGE._82_���u���{_����))
                'dt = tblTANTO_SYONIN.AsEnumerable.
                '          Where(Function(r) r.Field(Of Integer)("SYONIN_HOKOKUSYO_ID") = 1 And r.Field(Of Integer)("SYONIN_JUN") = FunGetNextSYONIN_JUN(ENM_NCR_STAGE._82_���u���{_����)).
                '          CopyToDataTable
                cmbST08_DestTANTO.SetDataSource(dt, ENM_COMBO_SELECT_VALUE_TYPE._0_Required)

                mtxST08_NextStageName.Text = FunGetCurrentStageName(FunGetNextSYONIN_JUN(ENM_NCR_STAGE._82_���u���{_����))

                If PrMODE = ENM_DATA_OPERATION_MODE._3_UPDATE Then
                    _V003 = _V003_SYONIN_J_KANRI_List.AsEnumerable.
                                Where(Function(r) r.SYONIN_JUN = ENM_NCR_STAGE._82_���u���{_����).
                                FirstOrDefault

                    If _V003 IsNot Nothing Then
                        cmbST08_DestTANTO.SelectedValue = _V003.SYAIN_ID
                        txtST08_Comment.Text = _V003.COMMENT
                        mtxST08_UPD_YMD.Text = DateTime.ParseExact(_V003.ADD_YMDHNS, "yyyyMMddHHmmss", Nothing).ToString("yyy/MM/dd")
                        If Not _V003.RIYU.IsNullOrWhiteSpace And intStageID = ENM_NCR_STAGE._82_���u���{_���� Then lblST08_Modoshi_Riyu.Visible = True
                        If _V003.SASIMODOSI_FG Then
                            lblST08_Modoshi_Riyu.Text = "���ߗ��R�F" & _V003.RIYU
                        Else
                            '�]����
                            lblST08_Modoshi_Riyu.Text = "�]�����R�F" & _V003.RIYU
                        End If
                    End If
                End If
            End If
#End Region
#Region "               83"
            '83
            If intStageID >= ENM_NCR_STAGE._83_���u���{_���� Then
                dt = FunGetSYONIN_SYOZOKU_SYAIN(cmbBUMON.SelectedValue, ENM_SYONIN_HOKOKUSYO_ID._1_NCR, FunGetNextSYONIN_JUN(ENM_NCR_STAGE._83_���u���{_����))
                'dt = tblTANTO_SYONIN.AsEnumerable.
                '          Where(Function(r) r.Field(Of Integer)("SYONIN_HOKOKUSYO_ID") = 1 And r.Field(Of Integer)("SYONIN_JUN") = FunGetNextSYONIN_JUN(ENM_NCR_STAGE._83_���u���{_����)).
                '          CopyToDataTable

                cmbST08_DestTANTO.SetDataSource(dt, ENM_COMBO_SELECT_VALUE_TYPE._0_Required)

                mtxST08_NextStageName.Text = FunGetCurrentStageName(FunGetNextSYONIN_JUN(ENM_NCR_STAGE._83_���u���{_����))

                If PrMODE = ENM_DATA_OPERATION_MODE._3_UPDATE Then
                    _V003 = _V003_SYONIN_J_KANRI_List.AsEnumerable.
                                Where(Function(r) r.SYONIN_JUN = ENM_NCR_STAGE._83_���u���{_����).
                                FirstOrDefault

                    If _V003 IsNot Nothing Then
                        cmbST08_DestTANTO.SelectedValue = _V003.SYAIN_ID
                        txtST08_Comment.Text = _V003.COMMENT
                        mtxST08_UPD_YMD.Text = DateTime.ParseExact(_V003.ADD_YMDHNS, "yyyyMMddHHmmss", Nothing).ToString("yyy/MM/dd")
                        If Not _V003.RIYU.IsNullOrWhiteSpace And intStageID = ENM_NCR_STAGE._83_���u���{_���� Then lblST08_Modoshi_Riyu.Visible = True
                        If _V003.SASIMODOSI_FG Then
                            lblST08_Modoshi_Riyu.Text = "���ߗ��R�F" & _V003.RIYU
                        Else
                            '�]����
                            lblST08_Modoshi_Riyu.Text = "�]�����R�F" & _V003.RIYU
                        End If
                    End If
                End If
            End If
#End Region
#Region "               90"
            If intStageID >= ENM_NCR_STAGE._90_���u���{�m�F_�Ǘ�T Then
                dt = FunGetSYONIN_SYOZOKU_SYAIN(cmbBUMON.SelectedValue, ENM_SYONIN_HOKOKUSYO_ID._1_NCR, FunGetNextSYONIN_JUN(ENM_NCR_STAGE._90_���u���{�m�F_�Ǘ�T))
                'dt = tblTANTO_SYONIN.AsEnumerable.
                '            Where(Function(r) r.Field(Of Integer)("SYONIN_HOKOKUSYO_ID") = 1 And r.Field(Of Integer)("SYONIN_JUN") = FunGetNextSYONIN_JUN(ENM_NCR_STAGE._90_���u���{�m�F_�Ǘ�T)).
                '            CopyToDataTable
                cmbST09_DestTANTO.SetDataSource(dt, ENM_COMBO_SELECT_VALUE_TYPE._0_Required)

                mtxST09_NextStageName.Text = FunGetCurrentStageName(FunGetNextSYONIN_JUN(ENM_NCR_STAGE._90_���u���{�m�F_�Ǘ�T))
                mtxST09_UPD_YMD.Enabled = False
                mtxST09_NextStageName.Enabled = False

                If PrMODE = ENM_DATA_OPERATION_MODE._3_UPDATE Then
                    _V003 = _V003_SYONIN_J_KANRI_List.AsEnumerable.
                                Where(Function(r) r.SYONIN_JUN = ENM_NCR_STAGE._90_���u���{�m�F_�Ǘ�T).
                                FirstOrDefault

                    If _V003 IsNot Nothing Then
                        cmbST09_DestTANTO.SelectedValue = _V003.SYAIN_ID
                        txtST09_Comment.Text = _V003.COMMENT
                        mtxST09_UPD_YMD.Text = DateTime.ParseExact(_V003.ADD_YMDHNS, "yyyyMMddHHmmss", Nothing).ToString("yyy/MM/dd")
                        If Not _V003.RIYU.IsNullOrWhiteSpace And intStageID = ENM_NCR_STAGE._90_���u���{�m�F_�Ǘ�T Then lblST09_Modoshi_Riyu.Visible = True
                        If _V003.SASIMODOSI_FG Then
                            lblST09_Modoshi_Riyu.Text = "���ߗ��R�F" & _V003.RIYU
                        Else
                            '�]����
                            lblST09_Modoshi_Riyu.Text = "�]�����R�F" & _V003.RIYU
                        End If
                        If intStageID > ENM_NCR_STAGE._90_���u���{�m�F_�Ǘ�T Then
                            cmbST09_DestTANTO.Enabled = False
                            txtST09_Comment.Enabled = False
                        End If
                    Else
                        mtxST09_UPD_YMD.Text = Today.ToString("yyyy/MM/dd")
                    End If
                End If
            End If
#End Region
#Region "               100"
            If intStageID >= ENM_NCR_STAGE._100_���u���{����_�����ے� Then
                dt = FunGetSYONIN_SYOZOKU_SYAIN(cmbBUMON.SelectedValue, ENM_SYONIN_HOKOKUSYO_ID._1_NCR, FunGetNextSYONIN_JUN(ENM_NCR_STAGE._100_���u���{����_�����ے�))
                'dt = tblTANTO_SYONIN.AsEnumerable.
                '    Where(Function(r) r.Field(Of Integer)("SYONIN_HOKOKUSYO_ID") = 1 And r.Field(Of Integer)("SYONIN_JUN") = FunGetNextSYONIN_JUN(ENM_NCR_STAGE._100_���u���{����_�����ے�)).
                '    CopyToDataTable
                cmbST10_DestTANTO.SetDataSource(dt, ENM_COMBO_SELECT_VALUE_TYPE._0_Required)

                mtxST10_NextStageName.Text = FunGetCurrentStageName(FunGetNextSYONIN_JUN(ENM_NCR_STAGE._100_���u���{����_�����ے�))
                mtxST10_UPD_YMD.Enabled = False
                mtxST10_NextStageName.Enabled = False

                If PrMODE = ENM_DATA_OPERATION_MODE._3_UPDATE Then
                    _V003 = _V003_SYONIN_J_KANRI_List.AsEnumerable.
                                Where(Function(r) r.SYONIN_JUN = ENM_NCR_STAGE._100_���u���{����_�����ے�).
                                FirstOrDefault

                    If _V003 IsNot Nothing Then
                        cmbST10_DestTANTO.SelectedValue = _V003.SYAIN_ID
                        txtST10_Comment.Text = _V003.COMMENT
                        mtxST10_UPD_YMD.Text = DateTime.ParseExact(_V003.ADD_YMDHNS, "yyyyMMddHHmmss", Nothing).ToString("yyy/MM/dd")
                        If Not _V003.RIYU.IsNullOrWhiteSpace And intStageID = ENM_NCR_STAGE._100_���u���{����_�����ے� Then lblST10_Modoshi_Riyu.Visible = True
                        If _V003.SASIMODOSI_FG Then
                            lblST10_Modoshi_Riyu.Text = "���ߗ��R�F" & _V003.RIYU
                        Else
                            '�]����
                            lblST10_Modoshi_Riyu.Text = "�]�����R�F" & _V003.RIYU
                        End If
                        If intStageID > ENM_NCR_STAGE._100_���u���{����_�����ے� Then
                            cmbST10_DestTANTO.Enabled = False
                            txtST10_Comment.Enabled = False
                        End If
                    Else
                        mtxST10_UPD_YMD.Text = Today.ToString("yyyy/MM/dd")
                    End If
                End If
            End If
#End Region
#Region "               110"
            If intStageID >= ENM_NCR_STAGE._110_abcde���u�S�� Then
                dt = FunGetSYONIN_SYOZOKU_SYAIN(cmbBUMON.SelectedValue, ENM_SYONIN_HOKOKUSYO_ID._1_NCR, FunGetNextSYONIN_JUN(ENM_NCR_STAGE._110_abcde���u�S��))
                'dt = tblTANTO_SYONIN.AsEnumerable.
                '          Where(Function(r) r.Field(Of Integer)("SYONIN_HOKOKUSYO_ID") = 1 And r.Field(Of Integer)("SYONIN_JUN") = FunGetNextSYONIN_JUN(ENM_NCR_STAGE._110_abcde���u�S��)).
                '          CopyToDataTable
                cmbST11_DestTANTO.SetDataSource(dt, ENM_COMBO_SELECT_VALUE_TYPE._0_Required)

                mtxST11_NextStageName.Text = FunGetCurrentStageName(FunGetNextSYONIN_JUN(ENM_NCR_STAGE._110_abcde���u�S��))
                mtxST11_UPD_YMD.Enabled = False
                mtxST11_NextStageName.Enabled = False

                If PrMODE = ENM_DATA_OPERATION_MODE._3_UPDATE Then
                    _V003 = _V003_SYONIN_J_KANRI_List.AsEnumerable.
                                Where(Function(r) r.SYONIN_JUN = ENM_NCR_STAGE._110_abcde���u�S��).
                                FirstOrDefault


                    _D003_NCR_J.SYOCHI_KEKKA_A = CBool(_V002_NCR_J.SYOCHI_KEKKA_A)
                    If _D003_NCR_J.SYOCHI_KEKKA_A Then
                        rbtnST11_A1_T.Checked = True
                    Else
                        rbtnST11_A1_F.Checked = True
                    End If

                    _D003_NCR_J.SYOCHI_KEKKA_B = CBool(_V002_NCR_J.SYOCHI_KEKKA_B)
                    If _D003_NCR_J.SYOCHI_KEKKA_B Then
                        rbtnST11_B1_T.Checked = True
                    Else
                        rbtnST11_B1_F.Checked = True
                    End If

                    _D003_NCR_J.SYOCHI_KEKKA_C = CBool(_V002_NCR_J.SYOCHI_KEKKA_C)
                    If _D003_NCR_J.SYOCHI_KEKKA_C Then
                        rbtnST11_C1_T.Checked = True
                    Else
                        rbtnST11_C1_F.Checked = True
                    End If

                    _D003_NCR_J.SYOCHI_D_UMU_KB = CBool(_V002_NCR_J.SYOCHI_D_UMU_KB)
                    If _D003_NCR_J.SYOCHI_D_UMU_KB Then
                        rbtnST11_D1_T.Checked = True
                    Else
                        rbtnST11_D1_F.Checked = True
                    End If

                    _D003_NCR_J.SYOCHI_D_YOHI_KB = CBool(_V002_NCR_J.SYOCHI_E_YOHI_KB)
                    If _D003_NCR_J.SYOCHI_E_YOHI_KB Then
                        rbtnST11_D2_T.Checked = True
                    Else
                        rbtnST11_D2_F.Checked = True
                    End If

                    _D003_NCR_J.SYOCHI_D_SYOCHI_KIROKU = _V002_NCR_J.SYOCHI_D_SYOCHI_KIROKU

                    _D003_NCR_J.SYOCHI_E_UMU_KB = CBool(_V002_NCR_J.SYOCHI_D_UMU_KB)
                    If _D003_NCR_J.SYOCHI_D_UMU_KB Then
                        rbtnST11_E1_T.Checked = True
                    Else
                        rbtnST11_E1_F.Checked = True
                    End If

                    _D003_NCR_J.SYOCHI_E_YOHI_KB = CBool(_V002_NCR_J.SYOCHI_E_YOHI_KB)
                    If _D003_NCR_J.SYOCHI_E_YOHI_KB Then
                        rbtnST11_E2_T.Checked = True
                    Else
                        rbtnST11_E2_F.Checked = True
                    End If

                    _D003_NCR_J.SYOCHI_E_SYOCHI_KIROKU = _V002_NCR_J.SYOCHI_E_SYOCHI_KIROKU

                    If _V003 IsNot Nothing Then
                        cmbST11_DestTANTO.SelectedValue = _V003.SYAIN_ID
                        txtST11_Comment.Text = _V003.COMMENT
                        mtxST11_UPD_YMD.Text = DateTime.ParseExact(_V003.ADD_YMDHNS, "yyyyMMddHHmmss", Nothing).ToString("yyy/MM/dd")
                        If Not _V003.RIYU.IsNullOrWhiteSpace And intStageID = ENM_NCR_STAGE._110_abcde���u�S�� Then lblST11_Modoshi_Riyu.Visible = True
                        If _V003.SASIMODOSI_FG Then
                            lblST11_Modoshi_Riyu.Text = "���ߗ��R�F" & _V003.RIYU
                        Else
                            '�]����
                            lblST11_Modoshi_Riyu.Text = "�]�����R�F" & _V003.RIYU
                        End If
                        If intStageID > ENM_NCR_STAGE._110_abcde���u�S�� Then
                            cmbST11_DestTANTO.Enabled = False
                            txtST11_Comment.Enabled = False
                        End If
                    Else
                        mtxST11_UPD_YMD.Text = Today.ToString("yyyy/MM/dd")
                    End If
                End If
            End If
#End Region
#Region "               120"
            If intStageID >= ENM_NCR_STAGE._120_abcde���u�m�F Then
                _D004_SYONIN_J_KANRI.SYAIN_ID = pub_SYAIN_INFO.SYAIN_ID
            End If
#End Region

            Return True
        Catch ex As Exception
            EM.ErrorSyori(ex, False, conblnNonMsg)
            Return False
        Finally

        End Try
    End Function

    Private Function FunGetST08SubPageName() As String
        Select Case _D003_NCR_J.KOKYAKU_SAISYU_HANTEI_KB
            Case ENM_KOKYAKU_SAISYU_HANTEI_KB._3_�p�p����
                Return "tabSTAGE08_" & ENM_STAGE80_TABPAGES._1_�p�p���{�L�^
            Case ENM_KOKYAKU_SAISYU_HANTEI_KB._4_�ԋp����
                Return "tabSTAGE08_" & ENM_STAGE80_TABPAGES._3_�ԋp���{�L�^
            Case ENM_KOKYAKU_SAISYU_HANTEI_KB._5_�]�p����
                Return "tabSTAGE08_" & ENM_STAGE80_TABPAGES._4_�]�p��L�^
            Case ENM_KOKYAKU_SAISYU_HANTEI_KB._6_�ĉ��H����
                Return "tabSTAGE08_" & ENM_STAGE80_TABPAGES._2_�ĉ��H�w��_�L�^
            Case Else
                Select Case _D003_NCR_J.SAISIN_IINKAI_HANTEI_KB
                    Case ENM_SAISIN_IINKAI_HANTEI_KB._3_�p�p����
                        Return "tabSTAGE08_" & ENM_STAGE80_TABPAGES._1_�p�p���{�L�^
                    Case ENM_SAISIN_IINKAI_HANTEI_KB._4_�ԋp����
                        Return "tabSTAGE08_" & ENM_STAGE80_TABPAGES._3_�ԋp���{�L�^
                    Case ENM_SAISIN_IINKAI_HANTEI_KB._5_�]�p����
                        Return "tabSTAGE08_" & ENM_STAGE80_TABPAGES._4_�]�p��L�^
                    Case ENM_SAISIN_IINKAI_HANTEI_KB._6_�ĉ��H����
                        Return "tabSTAGE08_" & ENM_STAGE80_TABPAGES._2_�ĉ��H�w��_�L�^
                    Case Else
                        Select Case _D003_NCR_J.JIZEN_SINSA_HANTEI_KB
                            Case ENM_JIZEN_SINSA_HANTEI_KB._4_�p�p����
                                Return "tabSTAGE08_" & ENM_STAGE80_TABPAGES._1_�p�p���{�L�^
                            Case ENM_JIZEN_SINSA_HANTEI_KB._5_�ԋp����
                                Return "tabSTAGE08_" & ENM_STAGE80_TABPAGES._3_�ԋp���{�L�^
                            Case ENM_JIZEN_SINSA_HANTEI_KB._6_�]�p����
                                Return "tabSTAGE08_" & ENM_STAGE80_TABPAGES._4_�]�p��L�^
                            Case ENM_JIZEN_SINSA_HANTEI_KB._7_�ĉ��H����
                                Return "tabSTAGE08_" & ENM_STAGE80_TABPAGES._2_�ĉ��H�w��_�L�^
                            Case Else
                                'Err
                                Throw New ArgumentException("80-2.�C JIZEN_SINSA_HANTEI_KB")
                        End Select
                End Select
        End Select
    End Function

#End Region

#Region "�^�u�C�x���g"
    Private Sub TabSTAGE_SelectedIndexChanged(sender As Object, e As EventArgs) Handles TabSTAGE.SelectedIndexChanged
        Call FunInitFuncButtonEnabled()
    End Sub
#End Region

#End Region

#Region "����"

#Region "����敪"
    Private Sub CmbBUMON_SelectedValueChanged(sender As Object, e As EventArgs) Handles cmbBUMON.SelectedValueChanged
        Dim cmb As ComboboxEx = DirectCast(sender, ComboboxEx)

        Select Case cmb.SelectedValue?.ToString.Trim
            Case ""
            Case Context.ENM_BUMON_KB._2_LP
                lblSYANAI_CD.Visible = True
                cmbSYANAI_CD.Visible = True
            Case Else
                lblSYANAI_CD.Visible = False
                cmbSYANAI_CD.Visible = False
        End Select

        Dim blnSelected As Boolean = (cmb.SelectedValue IsNot Nothing AndAlso Not cmb.SelectedValue.ToString.IsNullOrWhiteSpace)

        '�@��
        RemoveHandler cmbKISYU.SelectedValueChanged, AddressOf CmbKISYU_SelectedValueChanged
        cmbKISYU.DataBindings.Clear()
        If blnSelected Then
            Dim drs = tblKISYU.AsEnumerable.Where(Function(r) r.Field(Of String)(NameOf(_D003_NCR_J.BUMON_KB)) = cmb.SelectedValue).ToList
            If drs.Count > 0 Then
                Dim dt As DataTable = drs.CopyToDataTable
                cmbKISYU.SetDataSource(dt, ENM_COMBO_SELECT_VALUE_TYPE._0_Required)
                _D003_NCR_J.KISYU_ID = 0
            End If
        Else
            cmbKISYU.SetDataSource(tblKISYU.ExcludeDeleted, ENM_COMBO_SELECT_VALUE_TYPE._0_Required)
        End If
        AddHandler cmbKISYU.SelectedValueChanged, AddressOf CmbKISYU_SelectedValueChanged
        cmbKISYU.DataBindings.Add(New Binding(NameOf(cmbKISYU.SelectedValue), _D003_NCR_J, NameOf(_D003_NCR_J.KISYU_ID), False, DataSourceUpdateMode.OnPropertyChanged, 0))

        '���i�ԍ�
        RemoveHandler cmbBUHIN_BANGO.SelectedValueChanged, AddressOf CmbBUHIN_BANGO_SelectedValueChanged
        cmbBUHIN_BANGO.DataBindings.Clear()
        If blnSelected Then
            Dim drs = tblBUHIN.AsEnumerable.Where(Function(r) r.Field(Of String)(NameOf(_D003_NCR_J.BUMON_KB)) = cmb.SelectedValue).ToList
            If drs.Count > 0 Then
                Dim dt As DataTable = drs.CopyToDataTable
                cmbBUHIN_BANGO.SetDataSource(dt, ENM_COMBO_SELECT_VALUE_TYPE._0_Required)
                _D003_NCR_J.BUHIN_BANGO = ""
            End If
        Else
            cmbBUHIN_BANGO.SetDataSource(tblBUHIN.ExcludeDeleted, ENM_COMBO_SELECT_VALUE_TYPE._0_Required)
        End If
        AddHandler cmbBUHIN_BANGO.SelectedValueChanged, AddressOf CmbBUHIN_BANGO_SelectedValueChanged
        cmbBUHIN_BANGO.DataBindings.Add(New Binding(NameOf(cmbBUHIN_BANGO.SelectedValue), _D003_NCR_J, NameOf(_D003_NCR_J.BUHIN_BANGO), False, DataSourceUpdateMode.OnPropertyChanged, ""))

        '�Г��R�[�h
        RemoveHandler cmbSYANAI_CD.SelectedValueChanged, AddressOf CmbSYANAI_CD_SelectedValueChanged
        cmbSYANAI_CD.DataBindings.Clear()
        If blnSelected Then
            If Val(cmb.SelectedValue) = Context.ENM_BUMON_KB._2_LP Then
                Dim drs = tblSYANAI_CD.AsEnumerable.Where(Function(r) r.Field(Of String)(NameOf(_D003_NCR_J.BUMON_KB)) = cmb.SelectedValue).ToList
                If drs.Count > 0 Then
                    Dim dt As DataTable = drs.CopyToDataTable
                    cmbSYANAI_CD.DisplayMember = "DISP"
                    cmbSYANAI_CD.ValueMember = "VALUE"
                    cmbSYANAI_CD.SetDataSource(dt, ENM_COMBO_SELECT_VALUE_TYPE._0_Required)
                End If
            Else
                'cmbSYANAI_CD.DataSource = Nothing
            End If
            _D003_NCR_J.SYANAI_CD = ""
        Else
            cmbSYANAI_CD.SetDataSource(tblSYANAI_CD.ExcludeDeleted, ENM_COMBO_SELECT_VALUE_TYPE._0_Required)
        End If
        AddHandler cmbSYANAI_CD.SelectedValueChanged, AddressOf CmbSYANAI_CD_SelectedValueChanged
        cmbSYANAI_CD.DataBindings.Add(New Binding(NameOf(cmbSYANAI_CD.SelectedValue), _D003_NCR_J, NameOf(_D003_NCR_J.SYANAI_CD), False, DataSourceUpdateMode.OnPropertyChanged, ""))
    End Sub

    'UNDONE: ErrorProvider �\������K�؂� �I�� ���́@�I���܂��͓���

    Private Sub CmbBUMON_Validating(sender As Object, e As System.ComponentModel.CancelEventArgs) Handles cmbBUMON.Validating
        Dim cmb As ComboboxEx = DirectCast(sender, ComboboxEx)

        If cmb.SelectedValue = cmb.NullValue Then
            'e.Cancel = True
            ErrorProvider.SetError(cmb, String.Format(My.Resources.infoMsgRequireSelectOrInput, "���i�敪"))
            ErrorProvider.SetIconAlignment(cmb, ErrorIconAlignment.MiddleLeft)
            pri_blnValidated = False
        Else
            ErrorProvider.ClearError(cmb)
            pri_blnValidated = pri_blnValidated AndAlso True
        End If
    End Sub
#End Region

#Region "�@��"
    Private Sub CmbKISYU_SelectedValueChanged(sender As Object, e As EventArgs) Handles cmbKISYU.SelectedValueChanged
        Dim cmb As ComboboxEx = DirectCast(sender, ComboboxEx)
        Dim blnSelected As Boolean = (cmb.SelectedValue IsNot Nothing AndAlso Not cmb.SelectedValue.ToString.IsNullOrWhiteSpace)

        '���i�ԍ�
        RemoveHandler cmbBUHIN_BANGO.SelectedValueChanged, AddressOf CmbBUHIN_BANGO_SelectedValueChanged
        If blnSelected Then
            Dim drs = tblBUHIN.AsEnumerable.Where(Function(r) r.Field(Of Integer)(NameOf(_D003_NCR_J.KISYU_ID)) = cmb.SelectedValue).ToList
            If drs.Count > 0 Then
                Dim dt As DataTable = drs.CopyToDataTable
                Dim _selectedValue As String = cmbBUHIN_BANGO.SelectedValue

                cmbBUHIN_BANGO.SetDataSource(dt, ENM_COMBO_SELECT_VALUE_TYPE._0_Required)
                If Not cmbBUHIN_BANGO.NullValue = _selectedValue Then
                    _D003_NCR_J.BUHIN_BANGO = _selectedValue
                End If
            Else
                cmbBUHIN_BANGO.SetDataSource(tblBUHIN.ExcludeDeleted, ENM_COMBO_SELECT_VALUE_TYPE._0_Required)
            End If
        Else
            cmbBUHIN_BANGO.SetDataSource(tblBUHIN.ExcludeDeleted, ENM_COMBO_SELECT_VALUE_TYPE._0_Required)
        End If
        AddHandler cmbBUHIN_BANGO.SelectedValueChanged, AddressOf CmbBUHIN_BANGO_SelectedValueChanged

        '�Г��R�[�h
        RemoveHandler cmbSYANAI_CD.SelectedValueChanged, AddressOf CmbSYANAI_CD_SelectedValueChanged
        If blnSelected Then
            If Val(cmb.SelectedValue) = Context.ENM_BUMON_KB._2_LP Then
                Dim drs = tblSYANAI_CD.AsEnumerable.Where(Function(r) r.Field(Of Integer)(NameOf(_D003_NCR_J.KISYU_ID)) = cmb.SelectedValue).ToList
                If drs.Count > 0 Then
                    Dim dt As DataTable = drs.CopyToDataTable
                    Dim _selectedValue As String = cmbSYANAI_CD.SelectedValue
                    cmbSYANAI_CD.SetDataSource(dt, ENM_COMBO_SELECT_VALUE_TYPE._1_Filter)
                    If Not cmbSYANAI_CD.NullValue = _selectedValue Then
                        _D003_NCR_J.SYANAI_CD = _selectedValue
                    End If
                End If
            Else
                'cmbSYANAI_CD.DataSource = Nothing
            End If
            _D003_NCR_J.SYANAI_CD = ""
        Else
            cmbSYANAI_CD.SetDataSource(tblSYANAI_CD.ExcludeDeleted, ENM_COMBO_SELECT_VALUE_TYPE._0_Required)
        End If
        AddHandler cmbSYANAI_CD.SelectedValueChanged, AddressOf CmbSYANAI_CD_SelectedValueChanged
    End Sub

    Private Sub CmbKISYU_Validating(sender As Object, e As System.ComponentModel.CancelEventArgs) Handles cmbKISYU.Validating
        Dim cmb As ComboboxEx = DirectCast(sender, ComboboxEx)

        If cmb.SelectedValue = cmb.NullValue Then
            'e.Cancel = True
            ErrorProvider.SetError(cmb, String.Format(My.Resources.infoMsgRequireSelectOrInput, "�@��"))
            ErrorProvider.SetIconAlignment(cmb, ErrorIconAlignment.MiddleLeft)
            pri_blnValidated = False
        Else
            ErrorProvider.ClearError(cmb)
            pri_blnValidated = pri_blnValidated AndAlso True
        End If
    End Sub
#End Region

#Region "�Г��R�[�h"
    Private Sub CmbSYANAI_CD_SelectedValueChanged(sender As Object, e As EventArgs)
        Try
            Dim cmb As ComboboxEx = DirectCast(sender, ComboboxEx)
            Dim blnSelected As Boolean = (cmb.SelectedValue <> cmb.NullValue AndAlso Not cmb.SelectedValue.ToString.IsNullOrWhiteSpace)

            RemoveHandler cmbSYANAI_CD.SelectedValueChanged, AddressOf CmbSYANAI_CD_SelectedValueChanged

            '���i�ԍ�
            RemoveHandler cmbBUHIN_BANGO.SelectedValueChanged, AddressOf CmbBUHIN_BANGO_SelectedValueChanged
            cmbBUHIN_BANGO.DataBindings.Clear()
            If blnSelected Then
                Dim drs = tblBUHIN.AsEnumerable.Where(Function(r) r.Field(Of String)(NameOf(_D003_NCR_J.SYANAI_CD)) = cmb.SelectedValue).ToList
                If drs.Count > 0 Then
                    Dim dt As DataTable = drs.CopyToDataTable
                    cmbBUHIN_BANGO.SetDataSource(dt, ENM_COMBO_SELECT_VALUE_TYPE._0_Required)
                    _D003_NCR_J.BUHIN_BANGO = ""
                End If
            Else
                cmbBUHIN_BANGO.SetDataSource(tblBUHIN.ExcludeDeleted, ENM_COMBO_SELECT_VALUE_TYPE._0_Required)
            End If
            cmbBUHIN_BANGO.DataBindings.Add(New Binding(NameOf(cmbBUHIN_BANGO.SelectedValue), _D003_NCR_J, NameOf(_D003_NCR_J.BUHIN_BANGO), False, DataSourceUpdateMode.OnPropertyChanged, ""))
            AddHandler cmbBUHIN_BANGO.SelectedValueChanged, AddressOf CmbBUHIN_BANGO_SelectedValueChanged


            '���o
            RemoveHandler cmbBUHIN_BANGO.SelectedValueChanged, AddressOf CmbBUHIN_BANGO_SelectedValueChanged
            RemoveHandler cmbKISYU.SelectedValueChanged, AddressOf CmbKISYU_SelectedValueChanged
            cmbKISYU.DataBindings.Clear()
            cmbBUHIN_BANGO.DataBindings.Clear()
            If blnSelected Then
                Dim dr As DataRow = DirectCast(cmbSYANAI_CD.DataSource, DataTable).AsEnumerable.Where(Function(r) r.Field(Of String)("VALUE") = cmbSYANAI_CD.SelectedValue).FirstOrDefault
                _D003_NCR_J.BUHIN_BANGO = dr.Item("BUHIN_BANGO")
                _D003_NCR_J.BUHIN_NAME = dr.Item("BUHIN_NAME")
                If dr.Item("KISYU_ID") <> 0 Then _D003_NCR_J.KISYU_ID = dr.Item("KISYU_ID")

            Else
                _D003_NCR_J.BUHIN_BANGO = ""
                _D003_NCR_J.BUHIN_NAME = ""
                _D003_NCR_J.KISYU_ID = 0
            End If
            cmbKISYU.DataBindings.Add(New Binding(NameOf(cmbKISYU.SelectedValue), _D003_NCR_J, NameOf(_D003_NCR_J.KISYU_ID), False, DataSourceUpdateMode.OnPropertyChanged, 0))
            cmbBUHIN_BANGO.DataBindings.Add(New Binding(NameOf(cmbBUHIN_BANGO.SelectedValue), _D003_NCR_J, NameOf(_D003_NCR_J.BUHIN_BANGO), False, DataSourceUpdateMode.OnPropertyChanged, ""))
            AddHandler cmbBUHIN_BANGO.SelectedValueChanged, AddressOf CmbBUHIN_BANGO_SelectedValueChanged
            AddHandler cmbKISYU.SelectedValueChanged, AddressOf CmbKISYU_SelectedValueChanged


        Finally
            AddHandler cmbSYANAI_CD.SelectedValueChanged, AddressOf CmbSYANAI_CD_SelectedValueChanged
        End Try
    End Sub

#End Region

#Region "���i�ԍ�"
    Private Sub CmbBUHIN_BANGO_SelectedValueChanged(sender As Object, e As EventArgs)
        Dim cmb As ComboboxEx = DirectCast(sender, ComboboxEx)
        Dim blnSelected As Boolean = (cmb.SelectedValue IsNot Nothing AndAlso Not cmb.SelectedValue.ToString.IsNullOrWhiteSpace)

        RemoveHandler cmbBUHIN_BANGO.SelectedValueChanged, AddressOf CmbBUHIN_BANGO_SelectedValueChanged
        RemoveHandler cmbSYANAI_CD.SelectedValueChanged, AddressOf CmbSYANAI_CD_SelectedValueChanged

        '�Г��R�[�h
        If blnSelected Then
            cmbSYANAI_CD.DataBindings.Clear()
            If Val(cmb.SelectedValue) = Context.ENM_BUMON_KB._2_LP Then
                Dim drs = tblSYANAI_CD.AsEnumerable.Where(Function(r) r.Field(Of String)(NameOf(_D003_NCR_J.BUHIN_BANGO)) = cmb.SelectedValue).ToList
                If drs.Count > 0 Then
                    Dim dt As DataTable = drs.CopyToDataTable
                    Dim _selectedValue As String = cmbSYANAI_CD.SelectedValue
                    cmbSYANAI_CD.DisplayMember = "DISP"
                    cmbSYANAI_CD.ValueMember = "VALUE"
                    cmbSYANAI_CD.SetDataSource(dt, ENM_COMBO_SELECT_VALUE_TYPE._0_Required)
                    If Not cmbSYANAI_CD.NullValue = _selectedValue Then
                        _D003_NCR_J.SYANAI_CD = _selectedValue
                    End If
                End If
            Else
                _D003_NCR_J.SYANAI_CD = ""
                'cmbSYANAI_CD.DataSource = Nothing
            End If
            cmbSYANAI_CD.DataBindings.Add(New Binding(NameOf(cmbSYANAI_CD.SelectedValue), _D003_NCR_J, NameOf(_D003_NCR_J.SYANAI_CD), False, DataSourceUpdateMode.OnPropertyChanged, ""))
        Else
            cmbSYANAI_CD.SetDataSource(tblSYANAI_CD.ExcludeDeleted, ENM_COMBO_SELECT_VALUE_TYPE._0_Required)
        End If
        AddHandler cmbSYANAI_CD.SelectedValueChanged, AddressOf CmbSYANAI_CD_SelectedValueChanged

        '���o
        If blnSelected Then
            Dim dr As DataRow = DirectCast(cmbBUHIN_BANGO.DataSource, DataTable).AsEnumerable.Where(Function(r) r.Field(Of String)("VALUE") = cmbBUHIN_BANGO.SelectedValue).FirstOrDefault
            If Val(cmb.SelectedValue) = Context.ENM_BUMON_KB._2_LP Then
                _D003_NCR_J.SYANAI_CD = dr.Item("SYANAI_CD")
            End If
            _D003_NCR_J.BUHIN_NAME = dr.Item("BUHIN_NAME")

            RemoveHandler cmbKISYU.SelectedValueChanged, AddressOf CmbKISYU_SelectedValueChanged
            If dr.Item("KISYU_ID") <> 0 Then _D003_NCR_J.KISYU_ID = dr.Item("KISYU_ID")
            AddHandler cmbKISYU.SelectedValueChanged, AddressOf CmbKISYU_SelectedValueChanged

            '�Ĕ��`�F�b�N
            _D003_NCR_J.SAIHATU = FunIsReIssue(_D003_NCR_J.BUHIN_BANGO, _D003_NCR_J.FUTEKIGO_KB, _D003_NCR_J.FUTEKIGO_S_KB)

        Else
            _D003_NCR_J.SYANAI_CD = ""
            _D003_NCR_J.BUHIN_NAME = ""
            _D003_NCR_J.KISYU_ID = 0
        End If

        AddHandler cmbBUHIN_BANGO.SelectedValueChanged, AddressOf CmbBUHIN_BANGO_SelectedValueChanged
    End Sub

    Private Sub CmbBUHIN_BANGO_Validating(sender As Object, e As System.ComponentModel.CancelEventArgs) Handles cmbBUHIN_BANGO.Validating
        Dim cmb As ComboboxEx = DirectCast(sender, ComboboxEx)

        If cmb.SelectedValue = cmb.NullValue Then
            'e.Cancel = True
            ErrorProvider.SetError(cmb, String.Format(My.Resources.infoMsgRequireSelectOrInput, "���i�ԍ�"))
            ErrorProvider.SetIconAlignment(cmb, ErrorIconAlignment.MiddleLeft)
            pri_blnValidated = False
        Else
            ErrorProvider.ClearError(cmb)
            pri_blnValidated = pri_blnValidated AndAlso True
        End If
    End Sub
#End Region

#Region "�����ԍ�(���@)"
    Private Sub MtxGOUKI_Validating(sender As Object, e As System.ComponentModel.CancelEventArgs) 'Handles mtxGOUKI.Validating
        Dim mtx As MaskedTextBoxEx = DirectCast(sender, MaskedTextBoxEx)

        If mtx.Text.IsNullOrWhiteSpace = True Then
            'e.Cancel = True
            ErrorProvider.SetError(mtx, String.Format(My.Resources.infoMsgRequireSelectOrInput, "�����ԍ�(���@)"))
            ErrorProvider.SetIconAlignment(mtx, ErrorIconAlignment.MiddleLeft)
            pri_blnValidated = False
        Else
            ErrorProvider.ClearError(mtx)
            pri_blnValidated = True
        End If
    End Sub
#End Region

#Region "��ԋ敪"
    Private Sub CmbFUTEKIGO_STATUS_SelectedValueChanged(sender As Object, e As EventArgs) Handles cmbFUTEKIGO_STATUS.SelectedValueChanged
        Dim cmb As ComboboxEx = DirectCast(sender, ComboboxEx)

        Dim blnRET As Boolean = (cmb.SelectedValue = ENM_FUTEKIGO_JYOTAI_KB._3_�ԋp�i.ToString)
        lblFUTEKIGO_NAIYO.Visible = blnRET
        mtxHENKYAKU_RIYU.Visible = blnRET
        mtxHENKYAKU_RIYU.Enabled = blnRET
    End Sub

    Private Sub CmbFUTEKIGO_STATUS_Validating(sender As Object, e As System.ComponentModel.CancelEventArgs) Handles cmbFUTEKIGO_STATUS.Validating
        Dim cmb As ComboboxEx = DirectCast(sender, ComboboxEx)

        If cmb.SelectedValue = cmb.NullValue Then
            'e.Cancel = True
            ErrorProvider.SetError(cmb, String.Format(My.Resources.infoMsgRequireSelectOrInput, "��ԋ敪"))
            ErrorProvider.SetIconAlignment(cmb, ErrorIconAlignment.MiddleLeft)
            pri_blnValidated = False
        Else
            ErrorProvider.ClearError(cmb)
            pri_blnValidated = pri_blnValidated AndAlso True
        End If
    End Sub
#End Region

#Region "�ԋp���R"
    Private Sub MtxFUTEKIGO_NAIYO_Validating(sender As Object, e As System.ComponentModel.CancelEventArgs) Handles mtxHENKYAKU_RIYU.Validating
        Dim mtx As MaskedTextBoxEx = DirectCast(sender, MaskedTextBoxEx)

        If mtx.Enabled = True AndAlso mtx.Text.IsNullOrWhiteSpace = True Then
            'e.Cancel = True
            ErrorProvider.SetError(mtx, String.Format(My.Resources.infoMsgRequireSelectOrInput, "�ԋp���R"))
            ErrorProvider.SetIconAlignment(mtx, ErrorIconAlignment.MiddleLeft)
            pri_blnValidated = False
        Else
            ErrorProvider.ClearError(mtx)
            pri_blnValidated = pri_blnValidated AndAlso True
        End If
    End Sub
#End Region

#Region "�s�K���敪"
    Private Sub CmbFUTEKIGO_KB_SelectedValueChanged(sender As Object, e As EventArgs) Handles cmbFUTEKIGO_KB.SelectedValueChanged

        Dim cmb As ComboboxEx = DirectCast(sender, ComboboxEx)

        cmbFUTEKIGO_S_KB.DataBindings.Clear()
        If cmb.SelectedValue IsNot Nothing AndAlso Not cmb.SelectedValue.ToString.IsNullOrWhiteSpace Then
            Dim dt As New DataTableEx
            Using DB As ClsDbUtility = DBOpen()
                FunGetCodeDataTable(DB, "�s�K��" & cmb.Text.Replace("�E", "") & "�敪", dt)
            End Using
            cmbFUTEKIGO_S_KB.SetDataSource(dt.ExcludeDeleted, ENM_COMBO_SELECT_VALUE_TYPE._0_Required)
            _D003_NCR_J.FUTEKIGO_S_KB = ""
        Else
            cmbFUTEKIGO_S_KB.DataSource = Nothing
        End If
        cmbFUTEKIGO_S_KB.DataBindings.Add(New Binding(NameOf(cmbFUTEKIGO_S_KB.SelectedValue), _D003_NCR_J, NameOf(_D003_NCR_J.FUTEKIGO_S_KB), False, DataSourceUpdateMode.OnPropertyChanged, ""))
    End Sub

    Private Sub CmbFUTEKIGO_KB_Validating(sender As Object, e As System.ComponentModel.CancelEventArgs) Handles cmbFUTEKIGO_KB.Validating
        Dim cmb As ComboboxEx = DirectCast(sender, ComboboxEx)

        If cmb.SelectedValue = cmb.NullValue Then
            'e.Cancel = True
            ErrorProvider.SetError(cmb, String.Format(My.Resources.infoMsgRequireSelectOrInput, "�s�K���敪"))
            ErrorProvider.SetIconAlignment(cmb, ErrorIconAlignment.MiddleLeft)
            pri_blnValidated = False
        Else
            ErrorProvider.ClearError(cmb)
            pri_blnValidated = pri_blnValidated AndAlso True
        End If
    End Sub
#End Region

#Region "�s�K���ڍ׋敪"
    Private Sub CmbFUTEKIGO_S_KB_SelectedValueChanged(sender As Object, e As EventArgs) Handles cmbFUTEKIGO_S_KB.SelectedValueChanged
        '�Ĕ��`�F�b�N
        _D003_NCR_J.SAIHATU = FunIsReIssue(_D003_NCR_J.BUHIN_BANGO, _D003_NCR_J.FUTEKIGO_KB, _D003_NCR_J.FUTEKIGO_S_KB)
    End Sub

    Private Sub CmbFUTEKIGO_S_KB_Validating(sender As Object, e As System.ComponentModel.CancelEventArgs) Handles cmbFUTEKIGO_S_KB.Validating
        Dim cmb As ComboboxEx = DirectCast(sender, ComboboxEx)

        If cmb.SelectedValue = cmb.NullValue Then
            'e.Cancel = True
            ErrorProvider.SetError(cmb, String.Format(My.Resources.infoMsgRequireSelectOrInput, "�s�K���ڍ׋敪"))
            ErrorProvider.SetIconAlignment(cmb, ErrorIconAlignment.MiddleLeft)
            pri_blnValidated = False
        Else
            ErrorProvider.ClearError(cmb)
            pri_blnValidated = pri_blnValidated AndAlso True
        End If
    End Sub
#End Region

#Region "�}��"
    Private Sub MtxZUBAN_KIKAKU_Validating(sender As Object, e As System.ComponentModel.CancelEventArgs) 'Handles mtxZUBAN_KIKAKU.Validating
        Dim mtx As MaskedTextBoxEx = DirectCast(sender, MaskedTextBoxEx)

        If mtx.Text.IsNullOrWhiteSpace = True Then
            'e.Cancel = True
            ErrorProvider.SetError(mtx, String.Format(My.Resources.infoMsgRequireSelectOrInput, "�}��"))
            ErrorProvider.SetIconAlignment(mtx, ErrorIconAlignment.MiddleLeft)
            pri_blnValidated = False
        Else
            ErrorProvider.ClearError(mtx)
            pri_blnValidated = True
        End If
    End Sub

#End Region

#Region "����"
    Private Sub NumSU_Validated(sender As Object, e As EventArgs) Handles numSU.Validated

        If Val(numSU.Text) = 0 Then
            numSU.Text = numSU.Minimum
        End If
    End Sub

#End Region

#End Region

#Region "STAGE��"

#Region "�\����Ј�"
    Private Sub CmbDestTANTO_Validating(sender As Object, e As System.ComponentModel.CancelEventArgs) Handles cmbST01_DestTANTO.Validating,
                                                                                                              cmbST02_DestTANTO.Validating,
                                                                                                              cmbST03_DestTANTO.Validating,
                                                                                                              cmbST04_DestTANTO.Validating,
                                                                                                              cmbST05_DestTANTO.Validating,
                                                                                                              cmbST06_DestTANTO.Validating,
                                                                                                              cmbST07_DestTANTO.Validating,
                                                                                                              cmbST08_DestTANTO.Validating,
                                                                                                              cmbST09_DestTANTO.Validating,
                                                                                                              cmbST10_DestTANTO.Validating,
                                                                                                              cmbST11_DestTANTO.Validating
        Dim cmb As ComboboxEx = DirectCast(sender, ComboboxEx)
        If cmb.SelectedValue = cmb.NullValue Then
            'e.Cancel = True
            ErrorProvider.SetError(cmb, String.Format(My.Resources.infoMsgRequireSelectOrInput, "�\����Ј�"))
            ErrorProvider.SetIconAlignment(cmb, ErrorIconAlignment.MiddleLeft)
            pri_blnValidated = False
        Else
            ErrorProvider.ClearError(cmb)
            pri_blnValidated = pri_blnValidated AndAlso True
        End If
    End Sub
#End Region

#Region "   STAGE1"
    Private Sub TxtST01_YOKYU_NAIYO_Validating(sender As Object, e As System.ComponentModel.CancelEventArgs) Handles txtST01_YOKYU_NAIYO.Validating
        Dim txt As TextBoxEx = DirectCast(sender, TextBoxEx)

        If txt.Text.IsNullOrWhiteSpace = True Then
            'e.Cancel = True
            ErrorProvider.SetError(txt, String.Format(My.Resources.infoMsgRequireSelectOrInput, "�v�����e"))
            ErrorProvider.SetIconAlignment(txt, ErrorIconAlignment.MiddleLeft)
            pri_blnValidated = False
        Else
            ErrorProvider.ClearError(txt)
            pri_blnValidated = pri_blnValidated AndAlso True
        End If
    End Sub

    Private Sub TxtST01_KEKKA_Validating(sender As Object, e As System.ComponentModel.CancelEventArgs) Handles txtST01_KEKKA.Validating
        Dim txt As TextBoxEx = DirectCast(sender, TextBoxEx)

        If txt.Text.IsNullOrWhiteSpace = True Then
            'e.Cancel = True
            ErrorProvider.SetError(txt, String.Format(My.Resources.infoMsgRequireSelectOrInput, "�ώ@����"))
            ErrorProvider.SetIconAlignment(txt, ErrorIconAlignment.MiddleLeft)
            pri_blnValidated = False
        Else
            ErrorProvider.ClearError(txt)
            pri_blnValidated = pri_blnValidated AndAlso True
        End If
    End Sub

#End Region
#Region "   STAGE2"
    '���ʍ��ڂ̂�
#End Region
#Region "   STAGE3"
    '���ʍ��ڂ̂�
#End Region
#Region "   STAGE4"

    Private Sub RbtnST04_ZESEI_YES_CheckedChanged(sender As Object, e As EventArgs) Handles rbtnST04_ZESEI_YES.CheckedChanged

        Dim blnChecked As Boolean = rbtnST04_ZESEI_NO.Checked
        lbltxtST04_RIYU.Visible = blnChecked
        txtST04_RIYU.Visible = blnChecked
        txtST04_RIYU.Enabled = blnChecked
        _D003_NCR_J.ZESEI_SYOCHI_YOHI_KB = True
    End Sub

    Private Sub RbtnST04_ZESEI_NO_CheckedChanged(sender As Object, e As EventArgs) Handles rbtnST04_ZESEI_NO.CheckedChanged

        Dim blnChecked As Boolean = rbtnST04_ZESEI_NO.Checked
        lbltxtST04_RIYU.Visible = blnChecked
        txtST04_RIYU.Visible = blnChecked
        txtST04_RIYU.Enabled = blnChecked
        _D003_NCR_J.ZESEI_SYOCHI_YOHI_KB = False
    End Sub

    Private Sub ChkZESEI_SYOCHI_YOHI_KB_CheckedChanged(sender As Object, e As EventArgs) Handles chkST04_ZESEI_SYOCHI_YOHI_KB.CheckedChanged
        If chkST04_ZESEI_SYOCHI_YOHI_KB.Checked Then
            rbtnST04_ZESEI_YES.Checked = True
        Else
            rbtnST04_ZESEI_NO.Checked = True
        End If
    End Sub

    Private Sub TxtST04_RIYU_Validating(sender As Object, e As System.ComponentModel.CancelEventArgs) Handles txtST04_RIYU.Validating
        Dim txt As TextBoxEx = DirectCast(sender, TextBoxEx)

        If txt.Enabled = True AndAlso txt.Text.IsNullOrWhiteSpace = True Then
            'e.Cancel = True
            ErrorProvider.SetError(txt, String.Format(My.Resources.infoMsgRequireSelectOrInput, "�ۂ̗��R"))
            ErrorProvider.SetIconAlignment(txt, ErrorIconAlignment.MiddleLeft)
            pri_blnValidated = False
        Else
            ErrorProvider.ClearError(txt)
            pri_blnValidated = True
        End If
    End Sub

    Private Sub CmbST04_JIZENSINSA_HANTEI_Validating(sender As Object, e As System.ComponentModel.CancelEventArgs) Handles cmbST04_JIZENSINSA_HANTEI.Validating
        Dim cmb As ComboboxEx = DirectCast(sender, ComboboxEx)

        If cmb.SelectedValue = cmb.NullValue Then
            'e.Cancel = True
            ErrorProvider.SetError(cmb, String.Format(My.Resources.infoMsgRequireSelectOrInput, "���O�R������"))
            ErrorProvider.SetIconAlignment(cmb, ErrorIconAlignment.MiddleLeft)
            pri_blnValidated = False
        Else
            ErrorProvider.ClearError(cmb)
            pri_blnValidated = pri_blnValidated AndAlso True
        End If
    End Sub

#End Region
#Region "   STAGE5"
    '���ʍ��ڂ̂�
#End Region
#Region "   STAGE6"
    Private Sub CmbST06_SAISIN_IINKAI_HANTEI_SelectedValueChanged(sender As Object, e As EventArgs) Handles cmbST06_SAISIN_IINKAI_HANTEI.SelectedValueChanged
        '���X�e�[�W���X�V
        mtxST06_NextStageName.Text = FunGetCurrentStageName(FunGetNextSYONIN_JUN(PrCurrentStage))
        Dim dt As DataTable
        dt = FunGetSYONIN_SYOZOKU_SYAIN(cmbBUMON.SelectedValue, ENM_SYONIN_HOKOKUSYO_ID._1_NCR, FunGetNextSYONIN_JUN(PrCurrentStage))
        cmbST06_DestTANTO.SetDataSource(dt, ENM_COMBO_SELECT_VALUE_TYPE._0_Required)
    End Sub

    Private Sub CmbST06_SAISIN_IINKAI_HANTEI_Validating(sender As Object, e As System.ComponentModel.CancelEventArgs) Handles cmbST06_SAISIN_IINKAI_HANTEI.Validating
        Dim cmb As ComboboxEx = DirectCast(sender, ComboboxEx)

        If cmb.SelectedValue = cmb.NullValue Then
            'e.Cancel = True
            ErrorProvider.SetError(cmb, String.Format(My.Resources.infoMsgRequireSelectOrInput, "���O�R������"))
            ErrorProvider.SetIconAlignment(cmb, ErrorIconAlignment.MiddleLeft)
            pri_blnValidated = False
        Else
            ErrorProvider.ClearError(cmb)
            pri_blnValidated = pri_blnValidated AndAlso True
        End If
    End Sub

#End Region
#Region "   STAGE7"
    Private Sub rbtnST07_Yes_CheckedChanged(sender As Object, e As EventArgs) Handles rbtnST07_Yes.CheckedChanged

        Dim blnChecked As Boolean = rbtnST07_No.Checked
        _D003_NCR_J.SAIKAKO_SIJI_FG = True
    End Sub

    Private Sub rbtnST07_No_CheckedChanged(sender As Object, e As EventArgs) Handles rbtnST07_No.CheckedChanged

        Dim blnChecked As Boolean = rbtnST07_No.Checked
        _D003_NCR_J.SAIKAKO_SIJI_FG = False
    End Sub

    Private Sub ChkST07_SAIKAKO_SIJI_FLG_CheckedChanged(sender As Object, e As EventArgs) Handles chkST07_SAIKAKO_SIJI_FLG.CheckedChanged
        If chkST07_SAIKAKO_SIJI_FLG.Checked Then
            rbtnST07_Yes.Checked = True
        Else
            rbtnST07_No.Checked = True
        End If
    End Sub

    Private Sub CmbST07_SAISIN_TANTO_Validating(sender As Object, e As System.ComponentModel.CancelEventArgs) Handles cmbST07_SAISIN_TANTO.Validating
        Dim cmb As ComboboxEx = DirectCast(sender, ComboboxEx)

        If cmb.SelectedValue = cmb.NullValue Then
            'e.Cancel = True
            ErrorProvider.SetError(cmb, String.Format(My.Resources.infoMsgRequireSelectOrInput, "���O�R������"))
            ErrorProvider.SetIconAlignment(cmb, ErrorIconAlignment.MiddleLeft)
            pri_blnValidated = False
        Else
            ErrorProvider.ClearError(cmb)
            pri_blnValidated = pri_blnValidated AndAlso True
        End If
    End Sub

    Private Sub CmbST07_KOKYAKU_HANTEI_SIJI_Validating(sender As Object, e As System.ComponentModel.CancelEventArgs) Handles cmbST07_KOKYAKU_HANTEI_SIJI.Validating
        Dim cmb As ComboboxEx = DirectCast(sender, ComboboxEx)

        If cmb.SelectedValue = cmb.NullValue Then
            'e.Cancel = True
            ErrorProvider.SetError(cmb, String.Format(My.Resources.infoMsgRequireSelectOrInput, "���O�R������"))
            ErrorProvider.SetIconAlignment(cmb, ErrorIconAlignment.MiddleLeft)
            pri_blnValidated = False
        Else
            ErrorProvider.ClearError(cmb)
            pri_blnValidated = pri_blnValidated AndAlso True
        End If
    End Sub

    Private Sub CmbST07_KOKYAKU_SAISYU_HANTEI_Validating(sender As Object, e As System.ComponentModel.CancelEventArgs) Handles cmbST07_KOKYAKU_SAISYU_HANTEI.Validating
        Dim cmb As ComboboxEx = DirectCast(sender, ComboboxEx)

        If cmb.SelectedValue = cmb.NullValue Then
            'e.Cancel = True
            ErrorProvider.SetError(cmb, String.Format(My.Resources.infoMsgRequireSelectOrInput, "���O�R������"))
            ErrorProvider.SetIconAlignment(cmb, ErrorIconAlignment.MiddleLeft)
            pri_blnValidated = False
        Else
            ErrorProvider.ClearError(cmb)
            pri_blnValidated = pri_blnValidated AndAlso True
        End If
    End Sub

#End Region
#Region "   STAGE8"

#Region "       8-1"
    Private Sub CmbST08_1_HAIKYAKU_KB_Validating(sender As Object, e As System.ComponentModel.CancelEventArgs) Handles cmbST08_1_HAIKYAKU_KB.Validating
        Dim cmb As ComboboxEx = DirectCast(sender, ComboboxEx)

        If tabST08_SUB.SelectedIndex = 0 AndAlso cmb.SelectedValue = cmb.NullValue Then
            'e.Cancel = True
            ErrorProvider.SetError(cmb, String.Format(My.Resources.infoMsgRequireSelectOrInput, "���O�R������"))
            ErrorProvider.SetIconAlignment(cmb, ErrorIconAlignment.MiddleLeft)
            pri_blnValidated = False
        Else
            ErrorProvider.ClearError(cmb)
            pri_blnValidated = pri_blnValidated AndAlso True
        End If
    End Sub

    Private Sub CmbST08_1_HAIKYAKU_TANTO_Validating(sender As Object, e As System.ComponentModel.CancelEventArgs) Handles cmbST08_1_HAIKYAKU_TANTO.Validating
        Dim cmb As ComboboxEx = DirectCast(sender, ComboboxEx)

        If tabST08_SUB.SelectedIndex = 0 AndAlso cmb.SelectedValue = cmb.NullValue Then
            'e.Cancel = True
            ErrorProvider.SetError(cmb, String.Format(My.Resources.infoMsgRequireSelectOrInput, "���O�R������"))
            ErrorProvider.SetIconAlignment(cmb, ErrorIconAlignment.MiddleLeft)
            pri_blnValidated = False
        Else
            ErrorProvider.ClearError(cmb)
            pri_blnValidated = pri_blnValidated AndAlso True
        End If
    End Sub
#End Region
#Region "       8-2"
    Private Sub CmbST08_2_KENSA_KEKKA_Validating(sender As Object, e As System.ComponentModel.CancelEventArgs) Handles cmbST08_2_KENSA_KEKKA.Validating
        Dim cmb As ComboboxEx = DirectCast(sender, ComboboxEx)

        If tabST08_SUB.SelectedIndex = 1 AndAlso cmb.SelectedValue = cmb.NullValue Then
            'e.Cancel = True
            ErrorProvider.SetError(cmb, String.Format(My.Resources.infoMsgRequireSelectOrInput, "���O�R������"))
            ErrorProvider.SetIconAlignment(cmb, ErrorIconAlignment.MiddleLeft)
            pri_blnValidated = False
        Else
            ErrorProvider.ClearError(cmb)
            pri_blnValidated = pri_blnValidated AndAlso True
        End If
    End Sub
    Private Sub CmbST08_2_TANTO_SEIZO_Validating(sender As Object, e As System.ComponentModel.CancelEventArgs) Handles cmbST08_2_TANTO_SEIZO.Validating
        Dim cmb As ComboboxEx = DirectCast(sender, ComboboxEx)

        If tabST08_SUB.SelectedIndex = 1 AndAlso cmb.SelectedValue = cmb.NullValue Then
            'e.Cancel = True
            ErrorProvider.SetError(cmb, String.Format(My.Resources.infoMsgRequireSelectOrInput, "���O�R������"))
            ErrorProvider.SetIconAlignment(cmb, ErrorIconAlignment.MiddleLeft)
            pri_blnValidated = False
        Else
            ErrorProvider.ClearError(cmb)
            pri_blnValidated = pri_blnValidated AndAlso True
        End If
    End Sub
    Private Sub CmbST08_2_TANTO_SEIGI_Validating(sender As Object, e As System.ComponentModel.CancelEventArgs) Handles cmbST08_2_TANTO_SEIGI.Validating
        Dim cmb As ComboboxEx = DirectCast(sender, ComboboxEx)

        If tabST08_SUB.SelectedIndex = 1 AndAlso cmb.SelectedValue = cmb.NullValue Then
            'e.Cancel = True
            ErrorProvider.SetError(cmb, String.Format(My.Resources.infoMsgRequireSelectOrInput, "���O�R������"))
            ErrorProvider.SetIconAlignment(cmb, ErrorIconAlignment.MiddleLeft)
            pri_blnValidated = False
        Else
            ErrorProvider.ClearError(cmb)
            pri_blnValidated = pri_blnValidated AndAlso True
        End If
    End Sub
    Private Sub CmbST08_2_TANTO_KENSA_Validating(sender As Object, e As System.ComponentModel.CancelEventArgs) Handles cmbST08_2_TANTO_KENSA.Validating
        Dim cmb As ComboboxEx = DirectCast(sender, ComboboxEx)

        If tabST08_SUB.SelectedIndex = 1 AndAlso cmb.SelectedValue = cmb.NullValue Then
            'e.Cancel = True
            ErrorProvider.SetError(cmb, String.Format(My.Resources.infoMsgRequireSelectOrInput, "���O�R������"))
            ErrorProvider.SetIconAlignment(cmb, ErrorIconAlignment.MiddleLeft)
            pri_blnValidated = False
        Else
            ErrorProvider.ClearError(cmb)
            pri_blnValidated = pri_blnValidated AndAlso True
        End If
    End Sub
#End Region
#Region "       8-3"
    Private Sub CmbST08_3_HENKYAKU_TANTO_Validating(sender As Object, e As System.ComponentModel.CancelEventArgs) Handles cmbST08_3_HENKYAKU_TANTO.Validating
        Dim cmb As ComboboxEx = DirectCast(sender, ComboboxEx)

        If tabST08_SUB.SelectedIndex = 2 AndAlso cmb.SelectedValue = cmb.NullValue Then
            'e.Cancel = True
            ErrorProvider.SetError(cmb, String.Format(My.Resources.infoMsgRequireSelectOrInput, "���O�R������"))
            ErrorProvider.SetIconAlignment(cmb, ErrorIconAlignment.MiddleLeft)
            pri_blnValidated = False
        Else
            ErrorProvider.ClearError(cmb)
            pri_blnValidated = pri_blnValidated AndAlso True
        End If
    End Sub
#End Region
#Region "       8-4"
    Private Sub CmbST08_4_KISYU_Validating(sender As Object, e As System.ComponentModel.CancelEventArgs) Handles cmbST08_4_KISYU.Validating
        Dim cmb As ComboboxEx = DirectCast(sender, ComboboxEx)

        If tabST08_SUB.SelectedIndex = 3 AndAlso cmb.SelectedValue = cmb.NullValue Then
            'e.Cancel = True
            ErrorProvider.SetError(cmb, String.Format(My.Resources.infoMsgRequireSelectOrInput, "���O�R������"))
            ErrorProvider.SetIconAlignment(cmb, ErrorIconAlignment.MiddleLeft)
            pri_blnValidated = False
        Else
            ErrorProvider.ClearError(cmb)
            pri_blnValidated = pri_blnValidated AndAlso True
        End If
    End Sub
    Private Sub CmbST08_4_BUHIN_BANGO_Validating(sender As Object, e As System.ComponentModel.CancelEventArgs) Handles cmbST08_4_BUHIN_BANGO.Validating
        Dim cmb As ComboboxEx = DirectCast(sender, ComboboxEx)

        If tabST08_SUB.SelectedIndex = 3 AndAlso cmb.SelectedValue = cmb.NullValue Then
            'e.Cancel = True
            ErrorProvider.SetError(cmb, String.Format(My.Resources.infoMsgRequireSelectOrInput, "���O�R������"))
            ErrorProvider.SetIconAlignment(cmb, ErrorIconAlignment.MiddleLeft)
            pri_blnValidated = False
        Else
            ErrorProvider.ClearError(cmb)
            pri_blnValidated = pri_blnValidated AndAlso True
        End If
    End Sub
#End Region

#End Region
#Region "   STAGE9"
    '���ʍ��ڂ̂�
#End Region
#Region "   STAGE10"
    '���ʍ��ڂ̂�
#End Region
#Region "   STAGE11"
    Private Sub ChkST11_CheckedChanged(sender As Object, e As EventArgs) Handles chkST11_A1.CheckedChanged,
        chkST11_B1.CheckedChanged,
        chkST11_C1.CheckedChanged,
        chkST11_D1.CheckedChanged,
        chkST11_D2.CheckedChanged,
        chkST11_E1.CheckedChanged,
        chkST11_E2.CheckedChanged


        Dim chk As CheckBox = DirectCast(sender, CheckBox)
        Dim strNameSuffix As String
        If chk.Checked Then
            strNameSuffix = "T"
        Else
            strNameSuffix = "F"
        End If
        Dim ctrlLabel As Control() = Me.Controls.Find("rbtnST11_" & chk.Name.Substring(8, 2) & "_" & strNameSuffix, True)
        If ctrlLabel.Length > 0 Then
            Dim rbtn As RadioButton = ctrlLabel(0)
            rbtn.Checked = True
        End If
    End Sub

    Private Sub RbtnST11_CheckedChanged(sender As Object, e As EventArgs) Handles rbtnST11_A1_T.CheckedChanged,
                                                                                      rbtnST11_B1_T.CheckedChanged,
                                                                                      rbtnST11_C1_T.CheckedChanged,
                                                                                      rbtnST11_D1_T.CheckedChanged,
                                                                                      rbtnST11_D2_T.CheckedChanged,
                                                                                      rbtnST11_E1_T.CheckedChanged,
                                                                                      rbtnST11_E2_T.CheckedChanged,
                                                                                      rbtnST11_A1_F.CheckedChanged,
                                                                                      rbtnST11_B1_F.CheckedChanged,
                                                                                      rbtnST11_C1_F.CheckedChanged,
                                                                                      rbtnST11_D1_F.CheckedChanged,
                                                                                      rbtnST11_D2_F.CheckedChanged,
                                                                                      rbtnST11_E1_F.CheckedChanged,
                                                                                      rbtnST11_E2_F.CheckedChanged
        Dim rbtn As RadioButton = DirectCast(sender, RadioButton)
        Dim strNameSuffix As String = rbtn.Name.Substring(12, 1)

        Dim ctrlLabel As Control() = Me.Controls.Find("chkST11_" & rbtn.Name.Substring(9, 2), True)
        If ctrlLabel.Length > 0 Then
            Dim chk As CheckBox = ctrlLabel(0)
            chk.Checked = IIf(strNameSuffix = "T", True, False)
        End If
    End Sub



#End Region
#Region "   STAGE12"

#End Region
#Region "�Y�t����"

#Region "�Y�t�t�@�C��"
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
            lbltmpFile1.Links.Clear()
            lbltmpFile1.Links.Add(0, lbltmpFile1.Text.Length, ofd.FileName)

            _D003_NCR_J.FILE_PATH = IO.Path.GetFileName(ofd.FileName)
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

                    'Private Sub ProcessExited(ByVal sender As Object, ByVal e As EventArgs)
                    '    Call SetTaskbarOverlayIcon(Nothing)
                    '    Call SetTaskbarInfo(ENM_TASKBAR_STATE._0_NoProgress)
                    'End Sub

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
        _D003_NCR_J.FILE_PATH = ""
        lbltmpFile1.Links.Clear()
        lbltmpFile1.Visible = False
        lbltmpFile1_Clear.Visible = False
    End Sub

#End Region

#Region "�摜1"

    '�摜1�I��
    Private Sub BtnOpenPict1Dialog_Click(sender As Object, e As EventArgs) Handles btnOpenPict1Dialog.Click
        Try
            Dim ofd As New OpenFileDialog With {
         .Filter = "�摜(*.bmp;*.gif;*.jpg;*.png)|*.bmp;*.gif;*.jpg;*.png",
         .FilterIndex = 1,
         .Title = "�Y�t����摜�t�@�C����I�����Ă�������",
         .RestoreDirectory = True
        }
            If lblPict1Path.Links.Count = 0 Then
            Else
                ofd.InitialDirectory = IO.Path.GetDirectoryName(lblPict1Path.Links(0).ToString)
            End If

            If ofd.ShowDialog() = DialogResult.OK Then
                Call SetPict1Data({ofd.FileName})
            End If
        Catch ex As Exception
            Throw
        End Try
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

    '�����N�N���A
    Private Sub LblPict1Path_Clear_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles lblPict1Path_Clear.LinkClicked
        lblPict1Path.Text = ""
        _D003_NCR_J.G_FILE_PATH1 = ""
        lblPict1Path.Links.Clear()
        lblPict1Path.Visible = False
        lblPict1Path_Clear.Visible = False
        pnlPict1.Image = Nothing
        pnlPict1.Cursor = Cursors.Default
    End Sub

    'Private Sub MtxPict1Path_DragEnter(sender As Object, e As DragEventArgs) Handles mtxPict1Path.DragEnter
    '    '�h���b�O���ꂽ�f�[�^�`���𒲂ׁA�t�@�C���̂Ƃ��̓R�s�[�Ƃ���
    '    If e.Data.GetDataPresent(DataFormats.FileDrop) Then
    '        e.Effect = DragDropEffects.Copy
    '    Else
    '        e.Effect = DragDropEffects.None
    '    End If
    'End Sub

    'Private Sub MtxPict1Path_DragDrop(sender As Object, e As DragEventArgs) Handles mtxPict1Path.DragDrop
    '    Call SetPict1Data(CType(e.Data.GetData(DataFormats.FileDrop, False), String())(0))
    'End Sub

    Private Sub SetPict1Data(ByVal strFileName() As String)

        Try
            pnlPict1.Cursor = Cursors.Hand

            lblPict1Path.Text = CompactString(IO.Path.GetFileName(strFileName(0)), lblPict1Path, EllipsisFormat._4_Path) 'IO.Path.GetFileName(strFileName)
            'lblPict1Path.Tag = strFileName(0)
            _D003_NCR_J.G_FILE_PATH1 = IO.Path.GetFileName(strFileName(0))
            lblPict1Path.Links.Clear()
            lblPict1Path.Links.Add(0, lblPict1Path.Text.Length, strFileName(0))
            lblPict1Path.Visible = True
            lblPict1Path_Clear.Visible = True

            'Dim img As Image = New Bitmap(Image.FromFile(strFileName(0)), New Size(pnlPict1.Width, pnlPict1.Height))
            pnlPict1.Image = Image.FromFile(strFileName(0))
            'End Using

        Catch ex As OutOfMemoryException
            '
        End Try
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
        If lblPict2Path.Links.Count = 0 Then
        Else
            ofd.InitialDirectory = IO.Path.GetDirectoryName(lblPict2Path.Links(0).ToString)
        End If

        If ofd.ShowDialog() = DialogResult.OK Then
            Call SetPict2Data({ofd.FileName})
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

    '�����N�N���A
    Private Sub LblPict2Path_Clear_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles lblPict2Path_Clear.LinkClicked
        lblPict2Path.Text = ""
        _D003_NCR_J.G_FILE_PATH2 = ""
        lblPict2Path.Links.Clear()
        lblPict2Path.Visible = False
        lblPict2Path_Clear.Visible = False
        pnlPict2.Image = Nothing
        pnlPict2.Cursor = Cursors.Default
    End Sub

    'Private Sub PnlPict2_DragEnter(sender As Object, e As DragEventArgs) Handles pnlPict2.DragEnter
    '    '�h���b�O���ꂽ�f�[�^�`���𒲂ׁA�t�@�C���̂Ƃ��̓R�s�[�Ƃ���
    '    If e.Data.GetDataPresent(DataFormats.FileDrop) Then
    '        e.Effect = DragDropEffects.Copy
    '    Else
    '        e.Effect = DragDropEffects.None
    '    End If
    'End Sub

    'Private Sub PnlPict2_DragDrop(sender As Object, e As DragEventArgs) Handles pnlPict2.DragDrop
    '    Call SetPict2Data(e.Data.GetData(DataFormats.FileDrop, False))
    'End Sub

    Private Sub MtxPict2Path_DragEnter(sender As Object, e As DragEventArgs)
        '�h���b�O���ꂽ�f�[�^�`���𒲂ׁA�t�@�C���̂Ƃ��̓R�s�[�Ƃ���
        If e.Data.GetDataPresent(DataFormats.FileDrop) Then
            e.Effect = DragDropEffects.Copy
        Else
            e.Effect = DragDropEffects.None
        End If
    End Sub

    Private Sub MtxPict2Path_DragDrop(sender As Object, e As DragEventArgs)
        Call SetPict2Data(e.Data.GetData(DataFormats.FileDrop, False))
    End Sub

    Private Sub SetPict2Data(ByVal strFileName() As String)
        Try
            pnlPict2.Cursor = Cursors.Hand

            lblPict2Path.Text = CompactString(IO.Path.GetFileName(strFileName(0)), lblPict2Path, EllipsisFormat._4_Path) 'IO.Path.GetFileName(strFileName)
            'lblPict2Path.Tag = strFileName(0)
            _D003_NCR_J.G_FILE_PATH2 = IO.Path.GetFileName(strFileName(0))
            lblPict2Path.Links.Clear()
            lblPict2Path.Links.Add(0, lblPict2Path.Text.Length, strFileName)
            lblPict2Path.Visible = True
            lblPict2Path_Clear.Visible = True

            'UNDONE: �o�^��̓Ǎ����A���̂܂܂��ƃ������G���[����������̂�bmp�T�C�Y�w��̕K�v����H
            'Dim img As Image = New Bitmap(Image.FromFile(strFileName(0)), New Size(pnlPict2.Width, pnlPict1.Height))
            pnlPict2.Image = Image.FromFile(strFileName(0))
            'End Using
        Catch ex As OutOfMemoryException
            '
        End Try
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

#Region "Model - Control �o�C���f�B���O"
    Private Function FunSetBindingD003() As Boolean

        mtxHOKUKO_NO.DataBindings.Clear()
        cmbBUMON.DataBindings.Clear()
        chkClosed.DataBindings.Clear()
        dtDraft.DataBindings.Clear()
        cmbKISO_TANTO.DataBindings.Clear()
        mtxGOUKI.DataBindings.Clear()
        mtxHINMEI.DataBindings.Clear()
        numSU.DataBindings.Clear()
        cmbFUTEKIGO_STATUS.DataBindings.Clear()
        chkSAIHATU.DataBindings.Clear()
        mtxHENKYAKU_RIYU.DataBindings.Clear()
        cmbFUTEKIGO_KB.DataBindings.Clear()
        mtxZUBAN_KIKAKU.DataBindings.Clear()

        lbltmpFile1.DataBindings.Clear()
        lblPict1Path.DataBindings.Clear()
        lblPict2Path.DataBindings.Clear()

        txtST01_YOKYU_NAIYO.DataBindings.Clear()
        txtST01_KEKKA.DataBindings.Clear()

        cmbST04_JIZENSINSA_HANTEI.DataBindings.Clear()
        chkST04_ZESEI_SYOCHI_YOHI_KB.DataBindings.Clear()
        txtST04_RIYU.DataBindings.Clear()

        cmbST06_SAISIN_IINKAI_HANTEI.DataBindings.Clear()
        mtxST06_SAISIN_IINKAI_SIRYO_NO.DataBindings.Clear()

        mtxST07_ITAG_NO.DataBindings.Clear()
        cmbST07_SAISIN_TANTO.DataBindings.Clear()
        cmbST07_KOKYAKU_HANTEI_SIJI.DataBindings.Clear()
        dtST07_KOKYAKU_HANTEI_SIJI.DataBindings.Clear()
        cmbST07_KOKYAKU_SAISYU_HANTEI.DataBindings.Clear()
        dtST07_KOKYAKU_SAISYU_HANTEI.DataBindings.Clear()
        chkST07_SAIKAKO_SIJI_FLG.DataBindings.Clear()

        dtST08_1_HAIKYAKU_YMD.DataBindings.Clear()
        cmbST08_1_HAIKYAKU_KB.DataBindings.Clear()
        mtxST08_1_BIKO.DataBindings.Clear()
        cmbST08_1_HAIKYAKU_TANTO.DataBindings.Clear()

        mtxST08_2_DOC_NO.DataBindings.Clear()
        dtST08_2_WorkOutYMD.DataBindings.Clear()
        dtST08_2_KENSA_YMD.DataBindings.Clear()
        cmbST08_2_KENSA_KEKKA.DataBindings.Clear()
        cmbST08_2_TANTO_SEIZO.DataBindings.Clear()
        cmbST08_2_TANTO_SEIGI.DataBindings.Clear()
        cmbST08_2_TANTO_KENSA.DataBindings.Clear()

        dtST08_3_HENKYAKU_YMD.DataBindings.Clear()
        mtxST08_3_HENKYAKU_SAKI.DataBindings.Clear()
        txtST08_3_BIKO.DataBindings.Clear()

        cmbST08_4_KISYU.DataBindings.Clear()
        cmbST08_4_BUHIN_BANGO.DataBindings.Clear()
        mtxST08_4_GOUKI.DataBindings.Clear()
        mtxST08_4_LOT.DataBindings.Clear()
        dtST08_4_TENYO_YMD.DataBindings.Clear()

        chkST11_A1.DataBindings.Clear()
        chkST11_B1.DataBindings.Clear()
        chkST11_C1.DataBindings.Clear()
        chkST11_D1.DataBindings.Clear()
        chkST11_D2.DataBindings.Clear()
        mtxST11_D_Comment.DataBindings.Clear()
        chkST11_E1.DataBindings.Clear()
        chkST11_E2.DataBindings.Clear()
        mtxST11_E_Comment.DataBindings.Clear()

        '����
        mtxHOKUKO_NO.DataBindings.Add(New Binding(NameOf(mtxHOKUKO_NO.Text), _D003_NCR_J, NameOf(_D003_NCR_J.HOKOKU_NO), False, DataSourceUpdateMode.OnPropertyChanged, ""))
        cmbBUMON.DataBindings.Add(New Binding(NameOf(cmbBUMON.SelectedValue), _D003_NCR_J, NameOf(_D003_NCR_J.BUMON_KB), False, DataSourceUpdateMode.OnPropertyChanged, ""))
        chkClosed.DataBindings.Add(New Binding(NameOf(chkClosed.Checked), _D003_NCR_J, NameOf(_D003_NCR_J.CLOSE_FG), False, DataSourceUpdateMode.OnPropertyChanged, False))
        dtDraft.DataBindings.Add(New Binding(NameOf(dtDraft.ValueNonFormat), _D003_NCR_J, NameOf(_D003_NCR_J.ADD_YMD), False, DataSourceUpdateMode.OnPropertyChanged, ""))
        cmbKISO_TANTO.DataBindings.Add(New Binding(NameOf(cmbKISO_TANTO.SelectedValue), _D003_NCR_J, NameOf(_D003_NCR_J.ADD_SYAIN_ID), False, DataSourceUpdateMode.OnPropertyChanged, 0))
        'cmbKISYU.DataBindings.Add(New Binding(NameOf(cmbKISYU.SelectedValue), _D003_NCR_J, NameOf(_D003_NCR_J.KISYU_ID), False, DataSourceUpdateMode.OnPropertyChanged, 0))
        mtxGOUKI.DataBindings.Add(New Binding(NameOf(mtxGOUKI.Text), _D003_NCR_J, NameOf(_D003_NCR_J.GOKI), False, DataSourceUpdateMode.OnPropertyChanged, ""))
        'cmbSYANAI_CD.DataBindings.Add(New Binding(NameOf(cmbSYANAI_CD.SelectedValue), _D003_NCR_J, NameOf(_D003_NCR_J.SYANAI_CD), False, DataSourceUpdateMode.OnPropertyChanged, ""))
        'cmbBUHIN_BANGO.DataBindings.Add(New Binding(NameOf(cmbBUHIN_BANGO.SelectedValue), _D003_NCR_J, NameOf(_D003_NCR_J.BUHIN_BANGO), False, DataSourceUpdateMode.OnPropertyChanged, ""))
        mtxHINMEI.DataBindings.Add(New Binding(NameOf(mtxHINMEI.Text), _D003_NCR_J, NameOf(_D003_NCR_J.BUHIN_NAME), False, DataSourceUpdateMode.OnPropertyChanged, ""))
        numSU.DataBindings.Add(New Binding(NameOf(numSU.Value), _D003_NCR_J, NameOf(_D003_NCR_J.SURYO), False, DataSourceUpdateMode.OnPropertyChanged, 1))
        cmbFUTEKIGO_STATUS.DataBindings.Add(New Binding(NameOf(cmbFUTEKIGO_STATUS.SelectedValue), _D003_NCR_J, NameOf(_D003_NCR_J.FUTEKIGO_JYOTAI_KB), False, DataSourceUpdateMode.OnPropertyChanged, ""))
        chkSAIHATU.DataBindings.Add(New Binding(NameOf(chkSAIHATU.Checked), _D003_NCR_J, NameOf(_D003_NCR_J.SAIHATU), False, DataSourceUpdateMode.OnPropertyChanged, ""))
        mtxHENKYAKU_RIYU.DataBindings.Add(New Binding(NameOf(mtxHENKYAKU_RIYU.Text), _D003_NCR_J, NameOf(_D003_NCR_J.FUTEKIGO_NAIYO), False, DataSourceUpdateMode.OnPropertyChanged, ""))
        cmbFUTEKIGO_KB.DataBindings.Add(New Binding(NameOf(cmbFUTEKIGO_KB.SelectedValue), _D003_NCR_J, NameOf(_D003_NCR_J.FUTEKIGO_KB), False, DataSourceUpdateMode.OnPropertyChanged, ""))
        'FUTEKIGO_S_KB��FUTEKIGO_KB�ύX���Ƀo�C���h
        mtxZUBAN_KIKAKU.DataBindings.Add(New Binding(NameOf(mtxZUBAN_KIKAKU.Text), _D003_NCR_J, NameOf(_D003_NCR_J.ZUMEN_KIKAKU), False, DataSourceUpdateMode.OnPropertyChanged, ""))

        '�Y�t����
        lbltmpFile1.DataBindings.Add(New Binding(NameOf(lbltmpFile1.Tag), _D003_NCR_J, NameOf(_D003_NCR_J.FILE_PATH), False, DataSourceUpdateMode.OnPropertyChanged, ""))
        lblPict1Path.DataBindings.Add(New Binding(NameOf(lblPict1Path.Tag), _D003_NCR_J, NameOf(_D003_NCR_J.G_FILE_PATH1), False, DataSourceUpdateMode.OnPropertyChanged, ""))
        lblPict2Path.DataBindings.Add(New Binding(NameOf(lblPict2Path.Tag), _D003_NCR_J, NameOf(_D003_NCR_J.G_FILE_PATH2), False, DataSourceUpdateMode.OnPropertyChanged, ""))


        'STAGE01
        txtST01_YOKYU_NAIYO.DataBindings.Add(New Binding(NameOf(txtST01_YOKYU_NAIYO.Text), _D003_NCR_J, NameOf(_D003_NCR_J.YOKYU_NAIYO), False, DataSourceUpdateMode.OnPropertyChanged, ""))
        txtST01_KEKKA.DataBindings.Add(New Binding(NameOf(txtST01_KEKKA.Text), _D003_NCR_J, NameOf(_D003_NCR_J.KANSATU_KEKKA), False, DataSourceUpdateMode.OnPropertyChanged, ""))


        'STAGE02
        'mtxHOKUKO_NO.DataBindings.Add(New Binding(NameOf(mtxHOKUKO_NO.Text), _D003_NCR_J, NameOf(_D003_NCR_J.HOKOKU_NO)))

        'STAGE03
        'mtxHOKUKO_NO.DataBindings.Add(New Binding(NameOf(mtxHOKUKO_NO.Text), _D003_NCR_J, NameOf(_D003_NCR_J.HOKOKU_NO)))

        'STAGE04
        cmbST04_JIZENSINSA_HANTEI.DataBindings.Add(New Binding(NameOf(cmbST04_JIZENSINSA_HANTEI.SelectedValue), _D003_NCR_J, NameOf(_D003_NCR_J.JIZEN_SINSA_HANTEI_KB), False, DataSourceUpdateMode.OnPropertyChanged, ""))
        chkST04_ZESEI_SYOCHI_YOHI_KB.DataBindings.Add(New Binding(NameOf(chkST04_ZESEI_SYOCHI_YOHI_KB.Checked), _D003_NCR_J, NameOf(_D003_NCR_J.ZESEI_SYOCHI_YOHI_KB), False, DataSourceUpdateMode.OnPropertyChanged, False))
        txtST04_RIYU.DataBindings.Add(New Binding(NameOf(txtST04_RIYU.Text), _D003_NCR_J, NameOf(_D003_NCR_J.ZESEI_NASI_RIYU), False, DataSourceUpdateMode.OnPropertyChanged, ""))

        'cmbST04_DestTANTO.DataBindings.Add(New Binding(NameOf(cmbST04_DestTANTO.SelectedValue), _D003_NCR_J, NameOf(_D003_NCR_J.JIZEN_SINSA_SYAIN_ID), False, DataSourceUpdateMode.OnPropertyChanged, 0))

        'STAGE05
        'mtxHOKUKO_NO.DataBindings.Add(New Binding(NameOf(mtxHOKUKO_NO.Text), _D003_NCR_J, NameOf(_D003_NCR_J.HOKOKU_NO)))
        'cmbST05_DestTANTO.DataBindings.Add(New Binding(NameOf(cmbST05_DestTANTO.SelectedValue), _D003_NCR_J, NameOf(_D003_NCR_J.SAISIN_KAKUNIN_SYAIN_ID), False, DataSourceUpdateMode.OnPropertyChanged, 0))


        'STAGE06
        cmbST06_SAISIN_IINKAI_HANTEI.DataBindings.Add(New Binding(NameOf(cmbST06_SAISIN_IINKAI_HANTEI.SelectedValue), _D003_NCR_J, NameOf(_D003_NCR_J.SAISIN_IINKAI_HANTEI_KB), False, DataSourceUpdateMode.OnPropertyChanged, ""))
        mtxST06_SAISIN_IINKAI_SIRYO_NO.DataBindings.Add(New Binding(NameOf(mtxST06_SAISIN_IINKAI_SIRYO_NO.Text), _D003_NCR_J, NameOf(_D003_NCR_J.SAISIN_IINKAI_SIRYO_NO), False, DataSourceUpdateMode.OnPropertyChanged, ""))
        'If PrCurrentStage = ENM_NCR_STAGE._60_�ĐR�R������_�Z�p��\ Then
        '    cmbST06_DestTANTO.DataBindings.Add(New Binding(NameOf(cmbST06_DestTANTO.SelectedValue), _D003_NCR_J, NameOf(_D003_NCR_J.SAISIN_GIJYUTU_SYAIN_ID), False, DataSourceUpdateMode.OnPropertyChanged, 0))
        'Else
        '    cmbST06_DestTANTO.DataBindings.Add(New Binding(NameOf(cmbST06_DestTANTO.SelectedValue), _D003_NCR_J, NameOf(_D003_NCR_J.SAISIN_HINSYO_SYAIN_ID), False, DataSourceUpdateMode.OnPropertyChanged, 0))
        'End If

        'STAGE07
        mtxST07_ITAG_NO.DataBindings.Add(New Binding(NameOf(mtxST07_ITAG_NO.Text), _D003_NCR_J, NameOf(_D003_NCR_J.ITAG_NO), False, DataSourceUpdateMode.OnPropertyChanged, ""))
        cmbST07_SAISIN_TANTO.DataBindings.Add(New Binding(NameOf(cmbST07_SAISIN_TANTO.SelectedValue), _D003_NCR_J, NameOf(_D003_NCR_J.KOKYAKU_SAISIN_TANTO_ID), False, DataSourceUpdateMode.OnPropertyChanged, ""))
        cmbST07_KOKYAKU_HANTEI_SIJI.DataBindings.Add(New Binding(NameOf(cmbST07_KOKYAKU_HANTEI_SIJI.SelectedValue), _D003_NCR_J, NameOf(_D003_NCR_J.KOKYAKU_HANTEI_SIJI_KB), False, DataSourceUpdateMode.OnPropertyChanged, ""))
        dtST07_KOKYAKU_HANTEI_SIJI.DataBindings.Add(New Binding(NameOf(dtST07_KOKYAKU_HANTEI_SIJI.ValueNonFormat), _D003_NCR_J, NameOf(_D003_NCR_J.KOKYAKU_HANTEI_SIJI_YMD), False, DataSourceUpdateMode.OnPropertyChanged, ""))
        cmbST07_KOKYAKU_SAISYU_HANTEI.DataBindings.Add(New Binding(NameOf(cmbST07_KOKYAKU_SAISYU_HANTEI.SelectedValue), _D003_NCR_J, NameOf(_D003_NCR_J.KOKYAKU_SAISYU_HANTEI_KB), False, DataSourceUpdateMode.OnPropertyChanged, ""))
        dtST07_KOKYAKU_SAISYU_HANTEI.DataBindings.Add(New Binding(NameOf(dtST07_KOKYAKU_SAISYU_HANTEI.ValueNonFormat), _D003_NCR_J, NameOf(_D003_NCR_J.KOKYAKU_SAISYU_HANTEI_YMD), False, DataSourceUpdateMode.OnPropertyChanged, ""))
        chkST07_SAIKAKO_SIJI_FLG.DataBindings.Add(New Binding(NameOf(chkST07_SAIKAKO_SIJI_FLG.Checked), _D003_NCR_J, NameOf(_D003_NCR_J.SAIKAKO_SIJI_FG), False, DataSourceUpdateMode.OnPropertyChanged, False))
        'cmbST07_DestTANTO.DataBindings.Add(New Binding(NameOf(cmbST07_DestTANTO.SelectedValue), _D003_NCR_J, NameOf(_D003_NCR_J.KOKYAKU_SAISIN_TANTO_ID), False, DataSourceUpdateMode.OnPropertyChanged, 0))


        'STAGE08
        dtST08_1_HAIKYAKU_YMD.DataBindings.Add(New Binding(NameOf(dtST08_1_HAIKYAKU_YMD.ValueNonFormat), _D003_NCR_J, NameOf(_D003_NCR_J.HAIKYAKU_YMD), False, DataSourceUpdateMode.OnPropertyChanged, ""))
        cmbST08_1_HAIKYAKU_KB.DataBindings.Add(New Binding(NameOf(cmbST08_1_HAIKYAKU_KB.SelectedValue), _D003_NCR_J, NameOf(_D003_NCR_J.HAIKYAKU_KB), False, DataSourceUpdateMode.OnPropertyChanged, ""))
        mtxST08_1_BIKO.DataBindings.Add(New Binding(NameOf(mtxST08_1_BIKO.Text), _D003_NCR_J, NameOf(_D003_NCR_J.HAIKYAKU_HOUHOU), False, DataSourceUpdateMode.OnPropertyChanged, ""))
        cmbST08_1_HAIKYAKU_TANTO.DataBindings.Add(New Binding(NameOf(cmbST08_1_HAIKYAKU_TANTO.SelectedValue), _D003_NCR_J, NameOf(_D003_NCR_J.HAIKYAKU_TANTO_ID), False, DataSourceUpdateMode.OnPropertyChanged, 0))

        mtxST08_2_DOC_NO.DataBindings.Add(New Binding(NameOf(mtxST08_2_DOC_NO.Text), _D003_NCR_J, NameOf(_D003_NCR_J.SAIKAKO_SIJI_NO), False, DataSourceUpdateMode.OnPropertyChanged, ""))
        dtST08_2_WorkOutYMD.DataBindings.Add(New Binding(NameOf(dtST08_2_WorkOutYMD.ValueNonFormat), _D003_NCR_J, NameOf(_D003_NCR_J.SAIKAKO_SAGYO_KAN_YMD), False, DataSourceUpdateMode.OnPropertyChanged, ""))
        dtST08_2_KENSA_YMD.DataBindings.Add(New Binding(NameOf(dtST08_2_KENSA_YMD.ValueNonFormat), _D003_NCR_J, NameOf(_D003_NCR_J.SAIKAKO_KENSA_YMD), False, DataSourceUpdateMode.OnPropertyChanged, ""))
        cmbST08_2_KENSA_KEKKA.DataBindings.Add(New Binding(NameOf(cmbST08_2_KENSA_KEKKA.SelectedValue), _D003_NCR_J, NameOf(_D003_NCR_J.KENSA_KEKKA_KB), False, DataSourceUpdateMode.OnPropertyChanged, ""))
        cmbST08_2_TANTO_SEIZO.DataBindings.Add(New Binding(NameOf(cmbST08_2_TANTO_SEIZO.SelectedValue), _D003_NCR_J, NameOf(_D003_NCR_J.SEIZO_TANTO_ID), False, DataSourceUpdateMode.OnPropertyChanged, 0))
        cmbST08_2_TANTO_SEIGI.DataBindings.Add(New Binding(NameOf(cmbST08_2_TANTO_SEIGI.SelectedValue), _D003_NCR_J, NameOf(_D003_NCR_J.SEIGI_TANTO_ID), False, DataSourceUpdateMode.OnPropertyChanged, 0))
        cmbST08_2_TANTO_KENSA.DataBindings.Add(New Binding(NameOf(cmbST08_2_TANTO_KENSA.SelectedValue), _D003_NCR_J, NameOf(_D003_NCR_J.KENSA_TANTO_ID), False, DataSourceUpdateMode.OnPropertyChanged, 0))

        dtST08_3_HENKYAKU_YMD.DataBindings.Add(New Binding(NameOf(dtST08_3_HENKYAKU_YMD.ValueNonFormat), _D003_NCR_J, NameOf(_D003_NCR_J.HENKYAKU_YMD), False, DataSourceUpdateMode.OnPropertyChanged, ""))
        mtxST08_3_HENKYAKU_SAKI.DataBindings.Add(New Binding(NameOf(mtxST08_3_HENKYAKU_SAKI.Text), _D003_NCR_J, NameOf(_D003_NCR_J.HENKYAKU_SAKI), False, DataSourceUpdateMode.OnPropertyChanged, ""))
        txtST08_3_BIKO.DataBindings.Add(New Binding(NameOf(txtST08_3_BIKO.Text), _D003_NCR_J, NameOf(_D003_NCR_J.HENKYAKU_BIKO), False, DataSourceUpdateMode.OnPropertyChanged, ""))

        cmbST08_4_KISYU.DataBindings.Add(New Binding(NameOf(cmbST08_4_KISYU.SelectedValue), _D003_NCR_J, NameOf(_D003_NCR_J.TENYO_KISYU_ID), False, DataSourceUpdateMode.OnPropertyChanged, 0))
        cmbST08_4_BUHIN_BANGO.DataBindings.Add(New Binding(NameOf(cmbST08_4_BUHIN_BANGO.SelectedValue), _D003_NCR_J, NameOf(_D003_NCR_J.TENYO_BUHIN_BANGO), False, DataSourceUpdateMode.OnPropertyChanged, ""))
        mtxST08_4_GOUKI.DataBindings.Add(New Binding(NameOf(mtxST08_4_GOUKI.Text), _D003_NCR_J, NameOf(_D003_NCR_J.TENYO_GOKI), False, DataSourceUpdateMode.OnPropertyChanged, ""))
        mtxST08_4_LOT.DataBindings.Add(New Binding(NameOf(mtxST08_4_LOT.Text), _D003_NCR_J, NameOf(_D003_NCR_J.TENYO_LOT), False, DataSourceUpdateMode.OnPropertyChanged, ""))
        dtST08_4_TENYO_YMD.DataBindings.Add(New Binding(NameOf(dtST08_4_TENYO_YMD.ValueNonFormat), _D003_NCR_J, NameOf(_D003_NCR_J.TENYO_YMD), False, DataSourceUpdateMode.OnPropertyChanged, ""))


        'STAGE09
        'mtxHOKUKO_NO.DataBindings.Add(New Binding(NameOf(mtxHOKUKO_NO.Text), _D003_NCR_J, NameOf(_D003_NCR_J.HOKOKU_NO)))

        'STAGE10
        'mtxHOKUKO_NO.DataBindings.Add(New Binding(NameOf(mtxHOKUKO_NO.Text), _D003_NCR_J, NameOf(_D003_NCR_J.HOKOKU_NO)))

        'STAGE11
        chkST11_A1.DataBindings.Add(New Binding(NameOf(chkST11_A1.Checked), _D003_NCR_J, NameOf(_D003_NCR_J.SYOCHI_KEKKA_A), False, DataSourceUpdateMode.OnPropertyChanged, False))
        chkST11_B1.DataBindings.Add(New Binding(NameOf(chkST11_B1.Checked), _D003_NCR_J, NameOf(_D003_NCR_J.SYOCHI_KEKKA_B), False, DataSourceUpdateMode.OnPropertyChanged, False))
        chkST11_C1.DataBindings.Add(New Binding(NameOf(chkST11_C1.Checked), _D003_NCR_J, NameOf(_D003_NCR_J.SYOCHI_KEKKA_C), False, DataSourceUpdateMode.OnPropertyChanged, False))
        chkST11_D1.DataBindings.Add(New Binding(NameOf(chkST11_D1.Checked), _D003_NCR_J, NameOf(_D003_NCR_J.SYOCHI_D_UMU_KB), False, DataSourceUpdateMode.OnPropertyChanged, False))
        chkST11_D2.DataBindings.Add(New Binding(NameOf(chkST11_D2.Checked), _D003_NCR_J, NameOf(_D003_NCR_J.SYOCHI_D_YOHI_KB), False, DataSourceUpdateMode.OnPropertyChanged, False))
        mtxST11_D_Comment.DataBindings.Add(New Binding(NameOf(mtxST11_D_Comment.Text), _D003_NCR_J, NameOf(_D003_NCR_J.SYOCHI_D_SYOCHI_KIROKU), False, DataSourceUpdateMode.OnPropertyChanged, ""))
        chkST11_E1.DataBindings.Add(New Binding(NameOf(chkST11_E1.Checked), _D003_NCR_J, NameOf(_D003_NCR_J.SYOCHI_E_UMU_KB), False, DataSourceUpdateMode.OnPropertyChanged, False))
        chkST11_E2.DataBindings.Add(New Binding(NameOf(chkST11_E2.Checked), _D003_NCR_J, NameOf(_D003_NCR_J.SYOCHI_E_YOHI_KB), False, DataSourceUpdateMode.OnPropertyChanged, False))
        mtxST11_E_Comment.DataBindings.Add(New Binding(NameOf(mtxST11_E_Comment.Text), _D003_NCR_J, NameOf(_D003_NCR_J.SYOCHI_E_SYOCHI_KIROKU), False, DataSourceUpdateMode.OnPropertyChanged, ""))

        'STAGE12

    End Function

    Private Function FunSetBindingD004(ByVal intTabNo) As Boolean
        Dim ctrlTANTO As Control() = Me.Controls.Find("cmbST" & intTabNo.ToString("00") & "_DestTANTO", True)
        If ctrlTANTO.Length > 0 Then
            Dim cmbTANTO As ComboboxEx = ctrlTANTO(0)
            cmbTANTO.NullValue = 0
            cmbTANTO.DataBindings.Add(New Binding(NameOf(cmbTANTO.SelectedValue), _D004_SYONIN_J_KANRI, NameOf(_D004_SYONIN_J_KANRI.SYAIN_ID), False, DataSourceUpdateMode.OnPropertyChanged, 0))
        End If
    End Function
#End Region

#Region "�������[�h�ʉ�ʏ�����"
    Private Function FunInitializeControls(ByVal intMODE As Integer) As Boolean

        Try
            Select Case intMODE
                Case ENM_DATA_OPERATION_MODE._1_ADD

                    _D003_NCR_J.HOKOKU_NO = "<�V�K>"
                    _D003_NCR_J.ADD_SYAIN_ID = pub_SYAIN_INFO.SYAIN_ID
                    _D003_NCR_J.ADD_YMDHNS = Now.ToString("yyyyMMddHHmmss")
                    Select Case pub_SYAIN_INFO.BUMON_KB
                        Case Context.ENM_BUMON_KB._1_���h, Context.ENM_BUMON_KB._2_LP, Context.ENM_BUMON_KB._3_������
                            _D003_NCR_J.BUMON_KB = pub_SYAIN_INFO.BUMON_KB
                        Case Else
                    End Select
                    _D003_NCR_J.SURYO = 1

                    'SPEC: 2.(3).B.�A
                    PrCurrentStage = ENM_NCR_STAGE._10_�N������

                    Me.TabSTAGE.Visible = False '������h�~
                    Call FunInitializeTabControl(FunConvertSYONIN_JUN_TO_STAGE_NO(PrCurrentStage))
                    Call FunInitializeSTAGE(PrCurrentStage)
                    Me.TabSTAGE.Visible = True

                Case ENM_DATA_OPERATION_MODE._3_UPDATE

                    PrCurrentStage = PrDataRow.Item("SYONIN_JUN")

                    'SPEC: 10-2.�@
                    Call FunSetEntityModel(PrDataRow)

                    If PrCurrentStage > ENM_NCR_STAGE._20_�N���m�F����GL Then
                        cmbBUMON.Enabled = False

                        'UNDONE: �w�b�_���ڂ��ύX�s�� �Ƃ肠�����R���g���[���𒼐ڐ��� �\�Ȃ�p�l���P�ʂŐ��䂵����
                        mtxHOKUKO_NO.Enabled = False
                        cmbBUMON.Enabled = False
                        cmbKISO_TANTO.Enabled = False
                        dtDraft.Enabled = False
                        cmbKISYU.Enabled = False
                        cmbBUHIN_BANGO.Enabled = False
                        mtxGOUKI.Enabled = False
                        cmbSYANAI_CD.Enabled = False
                        cmbFUTEKIGO_STATUS.Enabled = False
                        mtxHENKYAKU_RIYU.Enabled = False
                        cmbFUTEKIGO_KB.Enabled = False
                        cmbFUTEKIGO_S_KB.Enabled = False
                        mtxZUBAN_KIKAKU.Enabled = False
                        numSU.Enabled = False
                    End If

                    Me.TabSTAGE.Visible = False
                    Call FunInitializeTabControl(FunConvertSYONIN_JUN_TO_STAGE_NO(PrDataRow.Item("SYONIN_JUN")))
                    Call FunInitializeSTAGE(PrDataRow.Item("SYONIN_JUN"))
                    mtxHOKUKO_NO.Enabled = False

                    For Each page As TabPage In TabSTAGE.TabPages
                        If page.Text = "���X�e�[�W" Then
                            'SPEC: 10-2.�C
                            TabSTAGE.SelectedTab = page
                            Exit For
                        End If
                    Next page
                    Me.TabSTAGE.Visible = True

                Case Else
                    'Throw New ArgumentException(My.Resources.ErrMsgException, intMODE.ToString)
            End Select

            Return True

        Catch ex As Exception
            EM.ErrorSyori(ex, False, conblnNonMsg)
            Return False
        End Try
    End Function

    ''' <summary>
    ''' �ꗗ�I���s�̒l���e��r���[���������A���f���f�[�^�ɃZ�b�g����
    ''' </summary>
    ''' <param name="dr">�ꗗ�I���s�̃f�[�^</param>
    ''' <returns></returns>
    Private Function FunSetEntityModel(dr As DataRow) As Boolean

        Try
            '�r���[���f�������[�h
            _V002_NCR_J = FunGetV002Model(dr.Item(NameOf(_D003_NCR_J.HOKOKU_NO)))
            _V003_SYONIN_J_KANRI_List = FunGetV003Model(ENM_SYONIN_HOKOKUSYO_ID._1_NCR, dr.Item(NameOf(_D003_NCR_J.HOKOKU_NO)))


#Region "D003"
            Dim t As Type = GetType(MODEL.D003_NCR_J)
            Dim properties As Reflection.PropertyInfo() = t.GetProperties(
                 Reflection.BindingFlags.Public Or
                 Reflection.BindingFlags.Instance Or
                 Reflection.BindingFlags.Static)

            Dim blnFieldList As New List(Of String) From {NameOf(_V002_NCR_J.CLOSE_FG),
                                                          NameOf(_V002_NCR_J.ZESEI_SYOCHI_YOHI_KB),
                                                          NameOf(_V002_NCR_J.SAIHATU),
                                                          NameOf(_V002_NCR_J.SAIKAKO_SIJI_FG),
                                                          NameOf(_V002_NCR_J.SYOCHI_KEKKA_A),
                                                          NameOf(_V002_NCR_J.SYOCHI_KEKKA_B),
                                                          NameOf(_V002_NCR_J.SYOCHI_KEKKA_C),
                                                          NameOf(_V002_NCR_J.SYOCHI_D_UMU_KB),
                                                          NameOf(_V002_NCR_J.SYOCHI_D_YOHI_KB),
                                                          NameOf(_V002_NCR_J.SYOCHI_E_UMU_KB),
                                                          NameOf(_V002_NCR_J.SYOCHI_E_YOHI_KB)}

            For Each p As Reflection.PropertyInfo In properties
                If IsAutoGenerateField(t, p.Name) = True Then
                    Select Case True
                        Case blnFieldList.Contains(p.Name)
                            _D003_NCR_J(p.Name) = CBool(_V002_NCR_J(p.Name))
                        Case Else
                            _D003_NCR_J(p.Name) = _V002_NCR_J(p.Name)
                    End Select
                End If
            Next p
#End Region

#Region "D004"

            Dim _V003 As New MODEL.V003_SYONIN_J_KANRI
            _V003 = _V003_SYONIN_J_KANRI_List.AsEnumerable.
                                Where(Function(r) r.SYONIN_JUN = dr.Item("SYONIN_JUN")).
                                FirstOrDefault

            t = GetType(MODEL.D004_SYONIN_J_KANRI)
            properties = t.GetProperties(
                 Reflection.BindingFlags.Public Or
                 Reflection.BindingFlags.Instance Or
                 Reflection.BindingFlags.Static)

            Dim blnFieldList2 As New List(Of String) From {NameOf(_V003.SASIMODOSI_FG),
                                                          NameOf(_V003.MAIL_SEND_FG)}

            For Each p As Reflection.PropertyInfo In properties
                If IsAutoGenerateField(t, p.Name) = True Then
                    Select Case True
                        Case blnFieldList2.Contains(p.Name)
                            _D004_SYONIN_J_KANRI(p.Name) = CBool(_V003(p.Name))
                        Case Else
                            _D004_SYONIN_J_KANRI(p.Name) = _V003(p.Name)
                    End Select
                End If
            Next p
#End Region

            Return True
        Catch ex As Exception
            EM.ErrorSyori(ex, False, conblnNonMsg)
            Return False
        End Try
    End Function

#End Region

#Region "���̓`�F�b�N"

    ''' <summary>
    ''' ���̓`�F�b�N �K�{���ڂ�Validation���Ăяo�����ƂŔ���
    ''' AndAlso�Ńr�b�g���Z���A1�ł�False����������false��Ԃ�
    ''' </summary>
    ''' <param name="enmSAVE_MODE"></param>
    ''' <returns></returns>
    Private Function FunCheckInput(ByVal enmSAVE_MODE As ENM_SAVE_MODE) As Boolean
        Try
            '�t���O���Z�b�g
            pri_blnValidated = True

            '-----����
            Call CmbBUMON_Validating(cmbBUMON, Nothing)
            Call CmbKISYU_Validating(cmbKISYU, Nothing)
            Call CmbBUHIN_BANGO_Validating(cmbBUHIN_BANGO, Nothing)

            Call CmbFUTEKIGO_STATUS_Validating(cmbFUTEKIGO_STATUS, Nothing)
            Call MtxFUTEKIGO_NAIYO_Validating(mtxHENKYAKU_RIYU, Nothing)
            Call CmbFUTEKIGO_KB_Validating(cmbFUTEKIGO_KB, Nothing)
            Call CmbFUTEKIGO_S_KB_Validating(cmbFUTEKIGO_S_KB, Nothing)

            If enmSAVE_MODE = ENM_SAVE_MODE._2_���F�\�� Then
                '-----�X�e�[�W��
                Select Case PrCurrentStage
                    Case ENM_NCR_STAGE._10_�N������
                        Call TxtST01_YOKYU_NAIYO_Validating(txtST01_YOKYU_NAIYO, Nothing)
                        Call TxtST01_KEKKA_Validating(txtST01_KEKKA, Nothing)
                        Call CmbDestTANTO_Validating(cmbST01_DestTANTO, Nothing)

                    Case ENM_NCR_STAGE._20_�N���m�F����GL
                        Call CmbDestTANTO_Validating(cmbST02_DestTANTO, Nothing)

                    Case ENM_NCR_STAGE._30_�N���m�F����
                        Call CmbDestTANTO_Validating(cmbST03_DestTANTO, Nothing)

                    Case ENM_NCR_STAGE._40_���O�R������y��CAR�v�۔���
                        Call CmbST04_JIZENSINSA_HANTEI_Validating(cmbST04_JIZENSINSA_HANTEI, Nothing)
                        Call CmbDestTANTO_Validating(cmbST04_DestTANTO, Nothing)

                    Case ENM_NCR_STAGE._50_���O�R���m�F
                        Call CmbDestTANTO_Validating(cmbST05_DestTANTO, Nothing)

                    Case ENM_NCR_STAGE._60_�ĐR�R������_�Z�p��\, ENM_NCR_STAGE._61_�ĐR�R������_�i�ؑ�\
                        Call CmbST06_SAISIN_IINKAI_HANTEI_Validating(cmbST06_SAISIN_IINKAI_HANTEI, Nothing)
                        Call CmbDestTANTO_Validating(cmbST06_DestTANTO, Nothing)

                    Case ENM_NCR_STAGE._70_�ڋq�ĐR���u_I_tag
                        Call CmbST07_SAISIN_TANTO_Validating(cmbST07_SAISIN_TANTO, Nothing)
                        Call CmbST07_KOKYAKU_HANTEI_SIJI_Validating(cmbST07_KOKYAKU_HANTEI_SIJI, Nothing)
                        Call CmbST07_KOKYAKU_SAISYU_HANTEI_Validating(cmbST07_KOKYAKU_SAISYU_HANTEI, Nothing)
                        Call CmbDestTANTO_Validating(cmbST07_DestTANTO, Nothing)

                    Case ENM_NCR_STAGE._80_���u���{, ENM_NCR_STAGE._81_���u���{_���Z, ENM_NCR_STAGE._82_���u���{_����, ENM_NCR_STAGE._83_���u���{_����

                        Dim strPageName As String = FunGetST08SubPageName()
                        Select Case Val(strPageName.Substring(11, 1))
                            Case ENM_STAGE80_TABPAGES._1_�p�p���{�L�^
                                Call CmbST08_1_HAIKYAKU_KB_Validating(cmbST08_1_HAIKYAKU_KB, Nothing)
                                Call CmbST08_1_HAIKYAKU_TANTO_Validating(cmbST08_1_HAIKYAKU_TANTO, Nothing)
                            Case ENM_STAGE80_TABPAGES._3_�ԋp���{�L�^
                                Call CmbST08_2_KENSA_KEKKA_Validating(cmbST08_2_KENSA_KEKKA, Nothing)
                                Call CmbST08_2_TANTO_KENSA_Validating(cmbST08_2_TANTO_KENSA, Nothing)
                                Call CmbST08_2_TANTO_SEIGI_Validating(cmbST08_2_TANTO_SEIGI, Nothing)
                                Call CmbST08_2_TANTO_SEIZO_Validating(cmbST08_2_TANTO_SEIZO, Nothing)
                            Case ENM_STAGE80_TABPAGES._4_�]�p��L�^
                                Call CmbST08_3_HENKYAKU_TANTO_Validating(cmbST08_3_HENKYAKU_TANTO, Nothing)
                            Case ENM_STAGE80_TABPAGES._2_�ĉ��H�w��_�L�^
                                Call CmbST08_4_BUHIN_BANGO_Validating(cmbST08_4_BUHIN_BANGO, Nothing)
                                Call CmbST08_4_KISYU_Validating(cmbST08_4_KISYU, Nothing)
                            Case Else
                                Throw New ArgumentException("80-2.�C JIZEN_SINSA_HANTEI_KB")
                        End Select

                        Call CmbDestTANTO_Validating(cmbST08_DestTANTO, Nothing)

                    Case ENM_NCR_STAGE._90_���u���{�m�F_�Ǘ�T
                        Call CmbDestTANTO_Validating(cmbST09_DestTANTO, Nothing)

                    Case ENM_NCR_STAGE._100_���u���{����_�����ے�
                        Call CmbDestTANTO_Validating(cmbST10_DestTANTO, Nothing)

                    Case ENM_NCR_STAGE._110_abcde���u�S��
                        Call CmbDestTANTO_Validating(cmbST11_DestTANTO, Nothing)

                    Case ENM_NCR_STAGE._120_abcde���u�m�F

                    Case Else
                        'Err
                End Select
            End If

            '��L�e��Validating�C�x���g�Ńt���O���X�V���A�S��OK�̏ꍇ��True
            Return pri_blnValidated

        Catch ex As Exception
            EM.ErrorSyori(ex, False, conblnNonMsg)
            Return False
        End Try
    End Function

#End Region

    ''' <summary>
    ''' ���X�e�[�W�̏��F��No���擾
    ''' </summary>
    ''' <param name="intCurrentStageID">���X�e�[�WID</param>
    ''' <returns></returns>
    Private Function FunGetNextSYONIN_JUN(ByVal intCurrentStageID As Integer) As Integer
        Try

            Dim intNextStageID As Integer

            'SPEC: 50-3 50�ȍ~�̏��F���J��
            Select Case intCurrentStageID
                Case Is < ENM_NCR_STAGE._50_���O�R���m�F
                    '50�ȑO�̏ꍇ�͓o�^���Ԓʂ�

                    Dim drList As List(Of DataRow) = tblNCR.AsEnumerable().
                                                    Where(Function(r) Val(r.Field(Of Integer)("VALUE")) > intCurrentStageID).ToList
                    If drList.Count > 0 Then
                        intNextStageID = Val(drList(0).Item("VALUE"))
                    End If
                Case ENM_NCR_STAGE._50_���O�R���m�F
                    '�o�^���e�ɉ����ė����I�ɕω�
                    Select Case _D003_NCR_J.JIZEN_SINSA_HANTEI_KB
                        Case ENM_JIZEN_SINSA_HANTEI_KB._0_��������, ENM_JIZEN_SINSA_HANTEI_KB._1_���̂܂܎g�p��
                            intNextStageID = ENM_NCR_STAGE._90_���u���{�m�F_�Ǘ�T
                        Case ENM_JIZEN_SINSA_HANTEI_KB._2_�ĐR�ψ����
                            intNextStageID = ENM_NCR_STAGE._60_�ĐR�R������_�Z�p��\
                        Case ENM_JIZEN_SINSA_HANTEI_KB._3_�ڋq�ĐR�\��
                            intNextStageID = ENM_NCR_STAGE._70_�ڋq�ĐR���u_I_tag
                        Case ENM_JIZEN_SINSA_HANTEI_KB._4_�p�p����, ENM_JIZEN_SINSA_HANTEI_KB._5_�ԋp����, ENM_JIZEN_SINSA_HANTEI_KB._6_�]�p����, ENM_JIZEN_SINSA_HANTEI_KB._7_�ĉ��H����
                            intNextStageID = ENM_NCR_STAGE._80_���u���{
                        Case Else
                            'Err
                    End Select

                Case ENM_NCR_STAGE._60_�ĐR�R������_�Z�p��\
                    intNextStageID = ENM_NCR_STAGE._61_�ĐR�R������_�i�ؑ�\

                Case ENM_NCR_STAGE._61_�ĐR�R������_�i�ؑ�\

                    Select Case _D003_NCR_J.SAISIN_IINKAI_HANTEI_KB
                        Case ENM_SAISIN_IINKAI_HANTEI_KB._0_��������, ENM_SAISIN_IINKAI_HANTEI_KB._1_���̂܂܎g�p��
                            intNextStageID = ENM_NCR_STAGE._90_���u���{�m�F_�Ǘ�T
                        Case ENM_SAISIN_IINKAI_HANTEI_KB._2_�ڋq�ĐR�\��
                            intNextStageID = ENM_NCR_STAGE._70_�ڋq�ĐR���u_I_tag
                        Case ENM_SAISIN_IINKAI_HANTEI_KB._3_�p�p����, ENM_SAISIN_IINKAI_HANTEI_KB._4_�ԋp����, ENM_SAISIN_IINKAI_HANTEI_KB._5_�]�p����, ENM_SAISIN_IINKAI_HANTEI_KB._6_�ĉ��H����
                            intNextStageID = ENM_NCR_STAGE._80_���u���{
                        Case Else
                            'Err
                    End Select

                Case ENM_NCR_STAGE._70_�ڋq�ĐR���u_I_tag
                    If _D003_NCR_J.SAIKAKO_SIJI_FG Then
                        intNextStageID = ENM_NCR_STAGE._80_���u���{
                    Else
                        intNextStageID = ENM_NCR_STAGE._90_���u���{�m�F_�Ǘ�T
                    End If

                Case ENM_NCR_STAGE._80_���u���{
                    If _D003_NCR_J.SAIKAKO_SIJI_FG Then
                        intNextStageID = ENM_NCR_STAGE._81_���u���{_���Z
                    Else
                        intNextStageID = ENM_NCR_STAGE._90_���u���{�m�F_�Ǘ�T
                    End If

                Case ENM_NCR_STAGE._81_���u���{_���Z
                    intNextStageID = ENM_NCR_STAGE._82_���u���{_����

                Case ENM_NCR_STAGE._82_���u���{_����
                    intNextStageID = ENM_NCR_STAGE._83_���u���{_����

                Case ENM_NCR_STAGE._83_���u���{_����
                    intNextStageID = ENM_NCR_STAGE._90_���u���{�m�F_�Ǘ�T

                Case ENM_NCR_STAGE._90_���u���{�m�F_�Ǘ�T
                    intNextStageID = ENM_NCR_STAGE._100_���u���{����_�����ے�

                Case ENM_NCR_STAGE._100_���u���{����_�����ے�
                    intNextStageID = ENM_NCR_STAGE._110_abcde���u�S��
                Case ENM_NCR_STAGE._110_abcde���u�S��
                    intNextStageID = ENM_NCR_STAGE._120_abcde���u�m�F
                Case Else

            End Select

            Return intNextStageID
        Catch ex As Exception
            EM.ErrorSyori(ex, False, conblnNonMsg)
            Return 0
        End Try
    End Function

    ''' <summary>
    ''' �\����Ј�ID���擾
    ''' </summary>
    ''' <param name="intCurrentStageID"></param>
    ''' <returns></returns>
    Private Function FunGetNextSYONIN_TANTO_ID(ByVal intCurrentStageID As Integer) As Integer
        Try

            Dim currentStageTabNo As String = FunConvertSYONIN_JUN_TO_STAGE_NO(intCurrentStageID).ToString("00")
            Dim ctrl As Control() = Me.Controls.Find("cmbST" & currentStageTabNo & "_DestTANTO", True)
            Dim cmbTANTO As ComboboxEx = ctrl(0)

            If cmbTANTO IsNot Nothing Then
                Return cmbTANTO.SelectedValue
            Else
                Return 0
            End If
        Catch ex As Exception
            Throw
        End Try
    End Function

    ''' <summary>
    ''' ���F��No����Y������^�uNo���擾
    ''' </summary>
    ''' <param name="intSYONIN_JUN">���F��No</param>
    ''' <returns></returns>
    Private Function FunConvertSYONIN_JUN_TO_STAGE_NO(ByVal intSYONIN_JUN As Integer) As Integer
        Dim intStageTabNo As Integer
        Select Case intSYONIN_JUN
            Case ENM_NCR_STAGE._10_�N������
                intStageTabNo = 1
            Case ENM_NCR_STAGE._20_�N���m�F����GL
                intStageTabNo = 2
            Case ENM_NCR_STAGE._30_�N���m�F����
                intStageTabNo = 3
            Case ENM_NCR_STAGE._40_���O�R������y��CAR�v�۔���
                intStageTabNo = 4
            Case ENM_NCR_STAGE._50_���O�R���m�F
                intStageTabNo = 5
            Case ENM_NCR_STAGE._60_�ĐR�R������_�Z�p��\, ENM_NCR_STAGE._61_�ĐR�R������_�i�ؑ�\
                intStageTabNo = 6
            Case ENM_NCR_STAGE._70_�ڋq�ĐR���u_I_tag
                intStageTabNo = 7
            Case ENM_NCR_STAGE._80_���u���{, ENM_NCR_STAGE._81_���u���{_���Z, ENM_NCR_STAGE._82_���u���{_����, ENM_NCR_STAGE._83_���u���{_����
                intStageTabNo = 8
            Case ENM_NCR_STAGE._90_���u���{�m�F_�Ǘ�T
                intStageTabNo = 9
            Case ENM_NCR_STAGE._100_���u���{����_�����ے�
                intStageTabNo = 10
            Case ENM_NCR_STAGE._110_abcde���u�S��
                intStageTabNo = 11
            Case ENM_NCR_STAGE._120_abcde���u�m�F
                intStageTabNo = 12
            Case Else
                intStageTabNo = 15
        End Select

        Return intStageTabNo
    End Function

    ''' <summary>
    ''' �^�uNo����Y�����鏳�F��No���擾
    ''' </summary>
    ''' <param name="intSYONIN_JUN">���F��No</param>
    ''' <returns></returns>
    Private Function FunConvertSTAGE_NO_TO_SYONIN_JUN(ByVal intTabNo As Integer) As Integer
        Dim intSTAGE_ID As Integer
        Select Case intTabNo
            Case 1
                intSTAGE_ID = ENM_NCR_STAGE._10_�N������
            Case 2
                intSTAGE_ID = ENM_NCR_STAGE._20_�N���m�F����GL
            Case 3
                intSTAGE_ID = ENM_NCR_STAGE._30_�N���m�F����
            Case 4
                intSTAGE_ID = ENM_NCR_STAGE._40_���O�R������y��CAR�v�۔���
            Case 5
                intSTAGE_ID = ENM_NCR_STAGE._50_���O�R���m�F
            Case 6
                'If PrCurrentStage = ENM_NCR_STAGE._60_�ĐR�R������_�Z�p��\ Or PrCurrentStage = ENM_NCR_STAGE._61_�ĐR�R������_�i�ؑ�\ Then
                '    intSTAGE_ID = PrCurrentStage
                'Else
                intSTAGE_ID = ENM_NCR_STAGE._60_�ĐR�R������_�Z�p��\
                'End If
            Case 7
                intSTAGE_ID = ENM_NCR_STAGE._70_�ڋq�ĐR���u_I_tag
            Case 8
                intSTAGE_ID = ENM_NCR_STAGE._80_���u���{
            Case 9
                intSTAGE_ID = ENM_NCR_STAGE._90_���u���{�m�F_�Ǘ�T
            Case 10
                intSTAGE_ID = ENM_NCR_STAGE._100_���u���{����_�����ے�
            Case 11
                intSTAGE_ID = ENM_NCR_STAGE._110_abcde���u�S��
            Case 12
                intSTAGE_ID = ENM_NCR_STAGE._120_abcde���u�m�F
            Case Else
                intSTAGE_ID = 15
        End Select

        Return intSTAGE_ID
    End Function

    Private Function FunConvertSTAGE_NO_TO_SYONIN_JUN2(ByVal intTabNo As Integer) As Integer
        Dim intSTAGE_ID As Integer
        Select Case intTabNo
            Case 1
                intSTAGE_ID = ENM_NCR_STAGE._10_�N������
            Case 2
                intSTAGE_ID = ENM_NCR_STAGE._20_�N���m�F����GL
            Case 3
                intSTAGE_ID = ENM_NCR_STAGE._30_�N���m�F����
            Case 4
                intSTAGE_ID = ENM_NCR_STAGE._40_���O�R������y��CAR�v�۔���
            Case 5
                intSTAGE_ID = ENM_NCR_STAGE._50_���O�R���m�F
            Case 6
                If PrCurrentStage <= ENM_NCR_STAGE._60_�ĐR�R������_�Z�p��\ Then
                    intSTAGE_ID = ENM_NCR_STAGE._60_�ĐR�R������_�Z�p��\
                Else
                    intSTAGE_ID = ENM_NCR_STAGE._61_�ĐR�R������_�i�ؑ�\
                End If
            Case 7
                intSTAGE_ID = ENM_NCR_STAGE._70_�ڋq�ĐR���u_I_tag
            Case 8
                Select Case PrCurrentStage
                    Case ENM_NCR_STAGE._80_���u���{ To ENM_NCR_STAGE._83_���u���{_����
                        intSTAGE_ID = PrCurrentStage
                    Case Else
                        intSTAGE_ID = ENM_NCR_STAGE._80_���u���{
                End Select
            Case 9
                intSTAGE_ID = ENM_NCR_STAGE._90_���u���{�m�F_�Ǘ�T
            Case 10
                intSTAGE_ID = ENM_NCR_STAGE._100_���u���{����_�����ے�
            Case 11
                intSTAGE_ID = ENM_NCR_STAGE._110_abcde���u�S��
            Case 12
                intSTAGE_ID = ENM_NCR_STAGE._120_abcde���u�m�F
            Case Else
                intSTAGE_ID = 15
        End Select

        Return intSTAGE_ID
    End Function


    ''' <summary>
    ''' �Ĕ�����
    ''' </summary>
    ''' <returns></returns>
    Private Function FunIsReIssue(ByVal strBUHIN_BANGO As String, ByVal strFUTEKIGO_KB As String, ByVal strFUTEKIGO_S_KB As String) As Boolean

        Dim sbSQL As New System.Text.StringBuilder
        Dim dsList As New DataSet

        If strBUHIN_BANGO.IsNullOrWhiteSpace Or strFUTEKIGO_KB.IsNullOrWhiteSpace Or strFUTEKIGO_S_KB.IsNullOrWhiteSpace Then
            Return False
        Else
            sbSQL.Remove(0, sbSQL.Length)
            sbSQL.Append("SELECT")
            sbSQL.Append(" *")
            sbSQL.Append(" FROM " & NameOf(MODEL.D003_NCR_J) & " ")
            sbSQL.Append(" WHERE BUHIN_BANGO='" & strBUHIN_BANGO & "'")
            sbSQL.Append(" AND FUTEKIGO_KB='" & strFUTEKIGO_KB & "'")
            sbSQL.Append(" AND FUTEKIGO_S_KB='" & strFUTEKIGO_S_KB & "'")
            Using DB As ClsDbUtility = DBOpen()
                dsList = DB.GetDataSet(sbSQL.ToString, conblnNonMsg)
            End Using

            Return dsList.Tables(0).Rows.Count > 0
        End If
    End Function

    ''' <summary>
    ''' CAR�ҏW��������
    ''' </summary>
    ''' <returns></returns>
    Private Function FunHasAuthCAREdit(ByVal strHOKOKU_NO As String, ByVal intSYAIN_ID As Integer) As Boolean
        Dim sbSQL As New System.Text.StringBuilder
        Dim dsList As New DataSet

        If strHOKOKU_NO.IsNullOrWhiteSpace Or intSYAIN_ID = 0 Then
            Return False
        Else
            sbSQL.Remove(0, sbSQL.Length)
            sbSQL.Append("SELECT")
            sbSQL.Append(" HOKOKU_NO")
            sbSQL.Append(" FROM " & NameOf(MODEL.V003_SYONIN_J_KANRI) & " ")
            sbSQL.Append(" WHERE SYONIN_HOKOKUSYO_ID=" & ENM_SYONIN_HOKOKUSYO_ID._2_CAR & "")
            sbSQL.Append(" AND HOKOKU_NO='" & strHOKOKU_NO & "'")
            sbSQL.Append(" AND SYAIN_ID=" & intSYAIN_ID & "")
            Using DB As ClsDbUtility = DBOpen()
                dsList = DB.GetDataSet(sbSQL.ToString, conblnNonMsg)
            End Using

            Return dsList.Tables(0).Rows.Count > 0
        End If

    End Function

    ''' <summary>
    ''' D004���ъm�F
    ''' </summary>
    ''' <param name="intSYONIN_HOKOKUSYO_ID"></param>
    ''' <param name="strHOKOKU_NO"></param>
    ''' <param name="intSYONIN_JUN"></param>
    ''' <returns></returns>
    Private Function FunExistAchievement(ByVal intSYONIN_HOKOKUSYO_ID As Integer, ByVal strHOKOKU_NO As String, ByVal intSYONIN_JUN As Integer) As Boolean
        Dim sbSQL As New System.Text.StringBuilder
        Dim dsList As New DataSet

        sbSQL.Remove(0, sbSQL.Length)
        sbSQL.Append("SELECT")
        sbSQL.Append(" HOKOKU_NO")
        sbSQL.Append(" FROM " & NameOf(MODEL.V003_SYONIN_J_KANRI) & " ")
        sbSQL.Append(" WHERE SYONIN_HOKOKUSYO_ID=" & intSYONIN_HOKOKUSYO_ID & "")
        sbSQL.Append(" AND HOKOKU_NO='" & strHOKOKU_NO & "'")
        sbSQL.Append(" AND SYONIN_JUN=" & intSYONIN_JUN & "")
        Using DB As ClsDbUtility = DBOpen()
            dsList = DB.GetDataSet(sbSQL.ToString, conblnNonMsg)
        End Using

        Return dsList.Tables(0).Rows.Count > 0
    End Function




#End Region

End Class