Imports JMS_COMMON.ClsPubMethod


Public Class FrmG0011

#Region "�萔�E�ϐ�"
    ''' <summary>
    ''' �^�u��\���Ǘ��p
    ''' </summary>
    Private _tabPageManager As TabPageManager


    Private Enum ENM_SAVE_MODE
        _1_�ۑ� = 1
        _2_���F�\�� = 2
    End Enum
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
        MyBase.ToolTip.SetToolTip(Me.cmdFunc9, "�V�K�o�^���͎g�p�o���܂���")
        MyBase.ToolTip.SetToolTip(Me.cmdFunc10, "�V�K�o�^���͎g�p�o���܂���")
        MyBase.ToolTip.SetToolTip(Me.cmdFunc11, "�V�K�o�^���͎g�p�o���܂���")

        D003NCRJBindingSource.DataSource = _D003_NCR_J

        mtxHOKUKO_NO.ReadOnly = True
        dtDraft.Enabled = False
        cmbAddTanto.Enabled = False
        pnlPict1.AllowDrop = True
        pnlPict2.AllowDrop = True
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
            cmbAddTanto.SetDataSource(tblTANTO, ENM_COMBO_SELECT_VALUE_TYPE._0_Required)

            cmbBUMON.SetDataSource(tblBUMON.ExcludeDeleted, ENM_COMBO_SELECT_VALUE_TYPE._0_Required)
            cmbKISYU.SetDataSource(tblKISYU.ExcludeDeleted, ENM_COMBO_SELECT_VALUE_TYPE._0_Required)
            cmbBUHIN_BANGO.SetDataSource(tblBUHIN.ExcludeDeleted, ENM_COMBO_SELECT_VALUE_TYPE._0_Required)
            cmbFUTEKIGO_STATUS.SetDataSource(tblFUTEKIGO_STATUS_KB.ExcludeDeleted, ENM_COMBO_SELECT_VALUE_TYPE._0_Required)
            cmbFUTEKIGO_KB.SetDataSource(tblFUTEKIGO_KB.ExcludeDeleted, ENM_COMBO_SELECT_VALUE_TYPE._0_Required)
            cmbSYANAI_CD.SetDataSource(tblSYANAI_CD.ExcludeDeleted, ENM_COMBO_SELECT_VALUE_TYPE._0_Required)

            '�o�C���f�B���O
            _D003_NCR_J.Clear()
            Call FunSetBinding()

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

                        If FunSAVE(ENM_SAVE_MODE._1_�ۑ�) Then
                            Me.DialogResult = DialogResult.OK
                            MessageBox.Show("���͓��e��ۑ����܂���", "�ۑ�����", MessageBoxButtons.OK, MessageBoxIcon.Information)
                        Else
                            MessageBox.Show("�ۑ������Ɏ��s���܂����B", "�ۑ����s", MessageBoxButtons.OK, MessageBoxIcon.Error)
                        End If
                    End If

                Case 2  '���F�\��
                    If MessageBox.Show("�\�����܂����H", "�\�������m�F", MessageBoxButtons.YesNo, MessageBoxIcon.Information) = DialogResult.Yes Then

                        If FunSAVE(ENM_SAVE_MODE._2_���F�\��) Then
                            MessageBox.Show("�\�����܂���", "�\����������", MessageBoxButtons.OK, MessageBoxIcon.Information)
                            Me.DialogResult = DialogResult.OK

                            'SPEC: 2.(3).E.�C
                            Me.Close()
                        Else
                            MessageBox.Show("�ۑ������Ɏ��s���܂����B", "�ۑ����s", MessageBoxButtons.OK, MessageBoxIcon.Error)
                        End If
                    End If

                Case 4  '�]��
                    Call OpenFormTENSO()
                Case 5  '���߂�
                    Call OpenFormSASIMODOSI()
                Case 9  'CAR�ҏW
                    Call OpenFormCAR()

                Case 10  '���|�[�g���
                    MessageBox.Show("������", "", MessageBoxButtons.OK, MessageBoxIcon.Information)

                    'Dim strFileName As String = pub_APP_INFO.strTitle & "_" & DateTime.Today.ToString("yyyyMMdd") & ".CSV"
                    'Call FunCSV_OUT(Me.dgvDATA.DataSource, strFileName, pub_APP_INFO.strOUTPUT_PATH)

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

#Region "�ۑ��E���F�\��"
    Private Function FunSAVE(ByVal enmSAVE_MODE As ENM_SAVE_MODE) As Boolean
        Try
            '-----���̓`�F�b�N
            If FunCheckInput() = False Then
                Return False
            End If

            Using DB As ClsDbUtility = DBOpen()
                Dim blnErr As Boolean
                Try '-----�g�����U�N�V����
                    DB.BeginTransaction()

                    '
                    If FunSAVE_FILE(DB) Then
                    Else
                        Return False
                        blnErr = True
                    End If

                    'SPEC: 2.(3).D.�@.���R�[�h�X�V
                    If FunSAVE_D003(DB) Then
                    Else
                        Return False
                        blnErr = True
                    End If

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
    Private Function FunSAVE_FILE(ByVal DB As ClsDbUtility) As Boolean

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
                    If Not _D003_NCR_J.FILE_PATH.IsNullOrWhiteSpace Then
                        System.IO.File.Copy(_D003_NCR_J.FILE_PATH, strRootDir & System.IO.Path.GetFileName(_D003_NCR_J.FILE_PATH), True)
                        _D003_NCR_J.FILE_PATH = strRootDir & System.IO.Path.GetFileName(_D003_NCR_J.FILE_PATH)
                    End If
                    If Not _D003_NCR_J.G_FILE_PATH1.IsNullOrWhiteSpace Then
                        System.IO.File.Copy(_D003_NCR_J.G_FILE_PATH1, strRootDir & System.IO.Path.GetFileName(_D003_NCR_J.G_FILE_PATH1), True)
                        _D003_NCR_J.G_FILE_PATH1 = strRootDir & System.IO.Path.GetFileName(_D003_NCR_J.G_FILE_PATH1)
                    End If
                    If Not _D003_NCR_J.G_FILE_PATH2.IsNullOrWhiteSpace Then
                        System.IO.File.Copy(_D003_NCR_J.G_FILE_PATH2, strRootDir & System.IO.Path.GetFileName(_D003_NCR_J.G_FILE_PATH2), True)
                        _D003_NCR_J.G_FILE_PATH2 = strRootDir & System.IO.Path.GetFileName(_D003_NCR_J.G_FILE_PATH2)
                    End If
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
    Private Function FunSAVE_D003(ByVal DB As ClsDbUtility) As Boolean
        Dim sbSQL As New System.Text.StringBuilder
        Dim intRET As Integer
        Dim sqlEx As New Exception

        '-----���ۑ����A�񍐏�No�擾
        If _D003_NCR_J.HOKOKU_NO.IsNullOrWhiteSpace Or _D003_NCR_J.HOKOKU_NO = "<�V�K>" Then
            Dim objParam As System.Data.Common.DbParameter = DB.DbCommand.CreateParameter
            Dim lstParam As New List(Of System.Data.Common.DbParameter)
            With objParam
                .ParameterName = "HOKOKU_NO"
                .DbType = DbType.String
                .Direction = ParameterDirection.Output
                .Size = 8
            End With
            lstParam.Add(objParam)
            If DB.Fun_blnExecStored("dbo.ST01_GET_HOKOKU_NO", lstParam) = True Then
                _D003_NCR_J.HOKOKU_NO = DB.DbCommand.Parameters("HOKOKU_NO").Value
            Else
                Return False
            End If
        End If

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
        sbSQL.Append(" ,'" & _D003_NCR_J._SAIKAKO_SIJI_FG & "' AS " & NameOf(_D003_NCR_J.SAIKAKO_SIJI_FG))
        sbSQL.Append(" ,'" & _D003_NCR_J.FILE_PATH & "' AS " & NameOf(_D003_NCR_J.FILE_PATH))
        sbSQL.Append(" ,'" & _D003_NCR_J.G_FILE_PATH1 & "' AS " & NameOf(_D003_NCR_J.G_FILE_PATH1))
        sbSQL.Append(" ,'" & _D003_NCR_J.G_FILE_PATH2 & "' AS " & NameOf(_D003_NCR_J.G_FILE_PATH2))
        sbSQL.Append(" ," & _D003_NCR_J.ADD_SYAIN_ID & " AS " & NameOf(_D003_NCR_J.ADD_SYAIN_ID))
        sbSQL.Append(" ,dbo.GetSysDateString() AS " & NameOf(_D003_NCR_J.ADD_YMDHNS))
        sbSQL.Append(" ," & pub_SYAIN_INFO.SYAIN_ID & " AS " & NameOf(_D003_NCR_J.UPD_SYAIN_ID))
        sbSQL.Append(" ,dbo.GetSysDateString() AS " & NameOf(_D003_NCR_J.UPD_YMDHNS))
        sbSQL.Append(" ,0 AS " & NameOf(_D003_NCR_J.DEL_SYAIN_ID))
        sbSQL.Append(" ,' ' AS " & NameOf(_D003_NCR_J.DEL_YMDHNS))
        sbSQL.Append(" ) AS WK")
        sbSQL.Append(" ON (SrcT.HOKOKU_NO = WK.HOKOKU_NO)")
        'UPDATE
        sbSQL.Append(" WHEN MATCHED THEN")
        sbSQL.Append(" UPDATE SET")
        sbSQL.Append("  SrcT." & NameOf(_D003_NCR_J.KISYU_ID) & " = WK." & NameOf(_D003_NCR_J.KISYU_ID))
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
        sbSQL.Append(" ,SrcT." & NameOf(_D003_NCR_J.SAIKAKO_SIJI_FG) & " = WK." & NameOf(_D003_NCR_J.SAIKAKO_SIJI_FG))
        sbSQL.Append(" ,SrcT." & NameOf(_D003_NCR_J.FILE_PATH) & " = WK." & NameOf(_D003_NCR_J.FILE_PATH))
        sbSQL.Append(" ,SrcT." & NameOf(_D003_NCR_J.G_FILE_PATH1) & " = WK." & NameOf(_D003_NCR_J.G_FILE_PATH1))
        sbSQL.Append(" ,SrcT." & NameOf(_D003_NCR_J.G_FILE_PATH2) & " = WK." & NameOf(_D003_NCR_J.G_FILE_PATH2))
        sbSQL.Append(" ,SrcT." & NameOf(_D003_NCR_J.UPD_SYAIN_ID) & " = WK." & NameOf(_D003_NCR_J.UPD_SYAIN_ID))
        sbSQL.Append(" ,SrcT." & NameOf(_D003_NCR_J.UPD_YMDHNS) & " = WK." & NameOf(_D003_NCR_J.UPD_YMDHNS))
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
        sbSQL.Append(" ,''") 'sbSQL.Append(" ," & NameOf(_D003_NCR_J.ZESEI_SYOCHI_YOHI_KB))
        sbSQL.Append(" ,''") 'sbSQL.Append(" ," & NameOf(_D003_NCR_J.ZESEI_NASI_RIYU))
        sbSQL.Append(" ,''") 'sbSQL.Append(" ," & NameOf(_D003_NCR_J.JIZEN_SINSA_HANTEI_KB))
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
        sbSQL.Append(" ,''") 'sbSQL.Append(" ," & NameOf(_D003_NCR_J.SAIKAKO_SIJI_FG))
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
        sbSQL.Append(" ,''") 'sbSQL.Append(" ," & NameOf(_D003_NCR_J.SYOCHI_KEKKA_A))
        sbSQL.Append(" ,''") 'sbSQL.Append(" ," & NameOf(_D003_NCR_J.SYOCHI_KEKKA_B))
        sbSQL.Append(" ,''") 'sbSQL.Append(" ," & NameOf(_D003_NCR_J.SYOCHI_KEKKA_C))
        sbSQL.Append(" ,''") 'sbSQL.Append(" ," & NameOf(_D003_NCR_J.SYOCHI_D_UMU_KB))
        sbSQL.Append(" ,''") 'sbSQL.Append(" ," & NameOf(_D003_NCR_J.SYOCHI_D_YOHI_KB))
        sbSQL.Append(" ,''") 'sbSQL.Append(" ," & NameOf(_D003_NCR_J.SYOCHI_D_SYOCHI_KIROKU))
        sbSQL.Append(" ,''") 'sbSQL.Append(" ," & NameOf(_D003_NCR_J.SYOCHI_E_UMU_KB))
        sbSQL.Append(" ,''") 'sbSQL.Append(" ," & NameOf(_D003_NCR_J.SYOCHI_E_YOHI_KB))
        sbSQL.Append(" ,''") 'sbSQL.Append(" ," & NameOf(_D003_NCR_J.SYOCHI_E_SYOCHI_KIROKU))
        '---
        sbSQL.Append(" ,WK." & NameOf(_D003_NCR_J.FILE_PATH))
        sbSQL.Append(" ,WK." & NameOf(_D003_NCR_J.G_FILE_PATH1))
        sbSQL.Append(" ,WK." & NameOf(_D003_NCR_J.G_FILE_PATH2))
        sbSQL.Append(" ,WK." & NameOf(_D003_NCR_J.ADD_SYAIN_ID))
        sbSQL.Append(" ,WK." & NameOf(_D003_NCR_J.ADD_YMDHNS))
        sbSQL.Append(" ,WK." & NameOf(_D003_NCR_J.UPD_SYAIN_ID))
        sbSQL.Append(" ,WK." & NameOf(_D003_NCR_J.UPD_YMDHNS))
        sbSQL.Append(" ,WK." & NameOf(_D003_NCR_J.DEL_SYAIN_ID))
        sbSQL.Append(" ,WK." & NameOf(_D003_NCR_J.DEL_YMDHNS))
        sbSQL.Append(" );")

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
    ''' ���F���ъǗ��X�V
    ''' </summary>
    ''' <param name="DB"></param>
    ''' <param name="enmSAVE_MODE"></param>
    ''' <returns></returns>
    Private Function FunSAVE_D004(ByVal DB As ClsDbUtility, ByVal enmSAVE_MODE As ENM_SAVE_MODE) As Boolean
        Dim sbSQL As New System.Text.StringBuilder
        Dim intRET As Integer
        Dim sqlEx As New Exception

        '-----�f�[�^���f���X�V
        _D004_SYONIN_J_KANRI.SYONIN_HOKOKUSYO_ID = ENM_SYONIN_HOKOKU_ID._1_NCR
        _D004_SYONIN_J_KANRI.HOKOKU_NO = _D003_NCR_J.HOKOKU_NO
        _D004_SYONIN_J_KANRI.MAIL_SEND_FG = True
        '-----���R�[�h�ۑ�
        Select Case enmSAVE_MODE
            Case ENM_SAVE_MODE._1_�ۑ�
                _D004_SYONIN_J_KANRI.SYONIN_JUN = PrCurrentStage
                _D004_SYONIN_J_KANRI.SYAIN_ID = pub_SYAIN_INFO.SYAIN_ID
                _D004_SYONIN_J_KANRI.SYONIN_HANTEI_KB = ENM_SYONIN_HANTEI_KB._0_�����F
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
        sbSQL.Append(" ,dbo.GetSysDateString() AS " & NameOf(_D004_SYONIN_J_KANRI.ADD_YMDHNS))
        sbSQL.Append(" ," & pub_SYAIN_INFO.SYAIN_ID & " AS " & NameOf(_D004_SYONIN_J_KANRI.UPD_SYAIN_ID))
        sbSQL.Append(" ,dbo.GetSysDateString() AS " & NameOf(_D004_SYONIN_J_KANRI.UPD_YMDHNS))
        sbSQL.Append(" ) AS WK")
        sbSQL.Append(" ON (SrcT." & NameOf(_D004_SYONIN_J_KANRI.SYONIN_HOKOKUSYO_ID) & " = WK." & NameOf(_D004_SYONIN_J_KANRI.SYONIN_HOKOKUSYO_ID) & "")
        sbSQL.Append(" AND SrcT." & NameOf(_D004_SYONIN_J_KANRI.HOKOKU_NO) & " = WK." & NameOf(_D004_SYONIN_J_KANRI.HOKOKU_NO) & "")
        sbSQL.Append(" AND SrcT." & NameOf(_D004_SYONIN_J_KANRI.SYONIN_JUN) & " = WK." & NameOf(_D004_SYONIN_J_KANRI.SYONIN_JUN) & ")")
        'UPDATE
        sbSQL.Append(" WHEN MATCHED THEN")
        sbSQL.Append(" UPDATE SET")
        sbSQL.Append("  SrcT." & NameOf(_D004_SYONIN_J_KANRI.SYAIN_ID) & " = WK." & NameOf(_D004_SYONIN_J_KANRI.SYAIN_ID))
        sbSQL.Append(" ,SrcT." & NameOf(_D004_SYONIN_J_KANRI.UPD_SYAIN_ID) & " = WK." & NameOf(_D004_SYONIN_J_KANRI.UPD_SYAIN_ID))
        sbSQL.Append(" ,SrcT." & NameOf(_D004_SYONIN_J_KANRI.UPD_YMDHNS) & " = WK." & NameOf(_D004_SYONIN_J_KANRI.UPD_YMDHNS))
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
        sbSQL.Append(" );")
        '-----SQL���s
        intRET = DB.ExecuteNonQuery(sbSQL.ToString, conblnNonMsg, sqlEx)
        If intRET <> 1 Then
            '-----�G���[���O�o��
            Dim strErrMsg As String = My.Resources.ErrLogSqlExecutionFailure & sbSQL.ToString & "|" & sqlEx.Message
            WL.WriteLogDat(strErrMsg)
            Return False
        End If

        '-----���F�\��
        Select Case enmSAVE_MODE
            Case ENM_SAVE_MODE._1_�ۑ�
                '�ۑ����т̂�
                Return True
            Case ENM_SAVE_MODE._2_���F�\��
                _D004_SYONIN_J_KANRI.SYONIN_JUN = FunGetNextSYONIN_JUN(PrCurrentStage)
                _D004_SYONIN_J_KANRI.SYAIN_ID = FunGetNextSYONIN_TANTO_ID(PrCurrentStage)
                _D004_SYONIN_J_KANRI.SYONIN_YMDHNS = ""
                _D004_SYONIN_J_KANRI.MAIL_SEND_FG = False
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
        sbSQL.Append(" ,dbo.GetSysDateString() AS " & NameOf(_D004_SYONIN_J_KANRI.ADD_YMDHNS))
        sbSQL.Append(" ," & pub_SYAIN_INFO.SYAIN_ID & " AS " & NameOf(_D004_SYONIN_J_KANRI.UPD_SYAIN_ID))
        sbSQL.Append(" ,dbo.GetSysDateString() AS " & NameOf(_D004_SYONIN_J_KANRI.UPD_YMDHNS))
        sbSQL.Append(" ) AS WK")
        sbSQL.Append(" ON (SrcT." & NameOf(_D004_SYONIN_J_KANRI.SYONIN_HOKOKUSYO_ID) & " = WK." & NameOf(_D004_SYONIN_J_KANRI.SYONIN_HOKOKUSYO_ID) & "")
        sbSQL.Append(" AND SrcT." & NameOf(_D004_SYONIN_J_KANRI.HOKOKU_NO) & " = WK." & NameOf(_D004_SYONIN_J_KANRI.HOKOKU_NO) & "")
        sbSQL.Append(" AND SrcT." & NameOf(_D004_SYONIN_J_KANRI.SYONIN_JUN) & " = WK." & NameOf(_D004_SYONIN_J_KANRI.SYONIN_JUN) & ")")
        'UPDATE
        sbSQL.Append(" WHEN MATCHED THEN")
        sbSQL.Append(" UPDATE SET")
        sbSQL.Append("  SrcT." & NameOf(_D004_SYONIN_J_KANRI.SYAIN_ID) & " = WK." & NameOf(_D004_SYONIN_J_KANRI.SYAIN_ID))
        sbSQL.Append("  SrcT." & NameOf(_D004_SYONIN_J_KANRI.COMMENT) & " = WK." & NameOf(_D004_SYONIN_J_KANRI.COMMENT))
        sbSQL.Append(" ,SrcT." & NameOf(_D004_SYONIN_J_KANRI.UPD_SYAIN_ID) & " = WK." & NameOf(_D004_SYONIN_J_KANRI.UPD_SYAIN_ID))
        sbSQL.Append(" ,SrcT." & NameOf(_D004_SYONIN_J_KANRI.UPD_YMDHNS) & " = WK." & NameOf(_D004_SYONIN_J_KANRI.UPD_YMDHNS))
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
        sbSQL.Append(" );")

        'UNDOLE OUTPUT���INSERT��UPDATE�����肵INSERT�̏ꍇ�̂݃��[�����M
        'https://qiita.com/ka_to/items/bfceba5b97d25f0d044a
        'https://social.msdn.microsoft.com/Forums/vstudio/ja-JP/2a8a5d6f-0166-4f91-9279-05e1a3de4a90/outputmerge-?forum=sqlserverja

        '-----SQL���s
        intRET = DB.ExecuteNonQuery(sbSQL.ToString, conblnNonMsg, sqlEx)
        If intRET <> 1 Then
            '-----�G���[���O�o��
            Dim strErrMsg As String = My.Resources.ErrLogSqlExecutionFailure & sbSQL.ToString & "|" & sqlEx.Message
            WL.WriteLogDat(strErrMsg)
            Return False
        End If

        If _D004_SYONIN_J_KANRI.MAIL_SEND_FG = False Then
            If FunSendMailFutekigo("�y�e�X�g�z�s�K���Ǘ��V�X�e�� �e�X�g���[��", "���M�e�X�g", _D004_SYONIN_J_KANRI.SYAIN_ID) Then
            Else
                MessageBox.Show("���[�����M�Ɏ��s���܂����B", "���[�����M���s", MessageBoxButtons.OK, MessageBoxIcon.Information)
            End If
        End If

        Return True
    End Function

    ''' <summary>
    ''' �񍐏����엚���X�V
    ''' </summary>
    ''' <param name="DB"></param>
    ''' <param name="enmSAVE_MODE"></param>
    ''' <returns></returns>
    Private Function FunSAVE_R001(ByVal DB As ClsDbUtility, ByVal enmSAVE_MODE As ENM_SAVE_MODE) As Boolean
        Dim sbSQL As New System.Text.StringBuilder
        Dim intRET As Integer
        Dim sqlEx As New Exception

        '---���݊m�F
        Dim dsList As New DataSet
        Dim blnExist As Boolean
        sbSQL.Append("SELECT HOKOKU_NO FROM " & NameOf(MODEL.R001_HOKOKU_SOUSA) & "")
        sbSQL.Append(" WHERE HOKOKU_NO ='" & NameOf(_R001_HOKOKU_SOUSA.HOKOKU_NO) & "'")
        dsList = DB.GetDataSet(sbSQL.ToString, conblnNonMsg)
        If dsList.Tables(0).Rows.Count > 0 Then
            blnExist = True
        End If

        '-----�f�[�^���f���X�V
        _R001_HOKOKU_SOUSA.SYONIN_HOKOKUSYO_ID = ENM_SYONIN_HOKOKU_ID._1_NCR
        _R001_HOKOKU_SOUSA.HOKOKU_NO = _D003_NCR_J.HOKOKU_NO
        _R001_HOKOKU_SOUSA.SYONIN_JUN = PrCurrentStage
        _R001_HOKOKU_SOUSA.SYAIN_ID = pub_SYAIN_INFO.SYAIN_ID

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
        sbSQL.Append("  " & (_R001_HOKOKU_SOUSA.SYONIN_HOKOKUSYO_ID))
        sbSQL.Append(" ,'" & (_R001_HOKOKU_SOUSA.HOKOKU_NO) & "'")
        sbSQL.Append(" ,dbo.GetSysDateString()") 'ADD_YMDHNS
        sbSQL.Append(" ," & (_R001_HOKOKU_SOUSA.SYONIN_JUN))
        sbSQL.Append(" ,'" & (_R001_HOKOKU_SOUSA.SOUSA_KB) & "'")
        sbSQL.Append(" ," & (_R001_HOKOKU_SOUSA.SYAIN_ID))
        sbSQL.Append(" ,'" & (_R001_HOKOKU_SOUSA.SYONIN_HANTEI_KB) & "'")
        sbSQL.Append(" ,'" & (_R001_HOKOKU_SOUSA.RIYU) & "'")
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

#Region "�]��"
    Private Function OpenFormTENSO() As Boolean
        Dim frmDLG As New FrmG0015
        Dim dlgRET As DialogResult

        Try
            frmDLG.PrSYONIN_HOKOKUSYO_ID = ENM_SYONIN_HOKOKU_ID._1_NCR
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

#Region "���߂�"
    Private Function OpenFormSASIMODOSI() As Boolean
        Dim frmDLG As New FrmG0016
        Dim dlgRET As DialogResult

        Try
            frmDLG.PrSYONIN_HOKOKUSYO_ID = ENM_SYONIN_HOKOKU_ID._1_NCR
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

            '�t�@�C����
            strOutputFileName = "NCR_" & _D003_NCR_J.HOKOKU_NO & "_Work.xlsx"

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
            If FunMakeReportNCR(pub_APP_INFO.strOUTPUT_PATH & strOutputFileName) = False Then
                Return False
            End If

            'Excel�N��
            Return FunOpenExcelApp(pub_APP_INFO.strOUTPUT_PATH & strOutputFileName)

        Catch ex As Exception
            EM.ErrorSyori(ex, False, conblnNonMsg)
            Return False
        Finally
            Me.PrPG_STATUS = ENM_PG_STATUS._2_ACTIVE
        End Try
    End Function

    Private Function FunMakeReportNCR(ByVal strFilePath As String) As Boolean

        Dim spWorkbook As SpreadsheetGear.IWorkbook
        Dim spWorksheets As SpreadsheetGear.IWorksheets
        Dim spSheet1 As SpreadsheetGear.IWorksheet
        Dim spRangeFrom As SpreadsheetGear.IRange
        Dim spRangeTo As SpreadsheetGear.IRange

        Try
            spWorkbook = SpreadsheetGear.Factory.GetWorkbook(strFilePath, System.Globalization.CultureInfo.CurrentCulture)

            spWorkbook.WorkbookSet.GetLock()
            spWorksheets = spWorkbook.Worksheets
            spSheet1 = spWorksheets.Item(0) 'sheet1


            Dim spprint As SpreadsheetGear.Printing.PrintWhat = SpreadsheetGear.Printing.PrintWhat.Sheet


            '���R�[�h�t���[��������
            'spWork.Range("RECORD_FRAME").ClearContents()
            spSheet1.Range(NameOf(_D003_NCR_J.HOKOKU_NO)).Value = _D003_NCR_J.HOKOKU_NO


            'spWork.Range("KINGAKU").Formula = "=I2*K2" '������ * �P��

            '-----���R�[�h�t���[����{�V�[�g�ɃR�s�[
            'spRangeFrom = spWork.Cells("RECORD_FRAME").EntireRow
            'strRange = String.Format("A{0}:L{1}", intCurrentRowIndex, intCurrentRowIndex)
            'spRangeTo = spSheet1.Cells(strRange).EntireRow
            'spRangeFrom.Copy(spRangeTo, SpreadsheetGear.PasteType.All, SpreadsheetGear.PasteOperation.None, False, False)


            '����͈͎w��
            'spSheet1.PageSetup.PrintArea = "sheet1!$A$1:$L$" & intCurrentRowIndex
            '����^�C�g���s
            'spSheet1.PageSetup.PrintTitleRows = "sheet1!$1:$3"

            '-----�t�@�C���ۑ�
            'spWork.Delete()
            'spWorksheets(0).Cells("A1").Select()
            spSheet1.SaveAs(filename:=strFilePath, fileFormat:=SpreadsheetGear.FileFormat.OpenXMLWorkbook)
            spWorkbook.WorkbookSet.ReleaseLock()

            Return True

        Catch ex As Exception
            EM.ErrorSyori(ex, False, conblnNonMsg)
            Return False
        Finally
            spRangeFrom = Nothing
            spRangeTo = Nothing
            spSheet1 = Nothing
            spWorksheets = Nothing
            spWorkbook = Nothing

            ''-----�J��
            'dsList.Dispose()
        End Try
    End Function

#End Region

#Region "����"

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

#Region "����"

    '�����t�B���^�ύX
    Private Sub SearchFilterValueChanged(sender As System.Object, e As System.EventArgs)
        '����
        Me.cmdFunc1.PerformClick()

    End Sub

    '����ύX��
    Private Sub CmbBUMON_SelectedValueChanged(sender As Object, e As EventArgs) Handles cmbBUMON.SelectedValueChanged
        Select Case cmbBUMON.SelectedValue
            Case Nothing
                '
            Case Context.ENM_BUMON_KB._4_LP
                lblSYANAI_CD.Visible = True
                cmbSYANAI_CD.Visible = True
            Case Else
                lblSYANAI_CD.Visible = False
                cmbSYANAI_CD.Visible = False
                cmbSYANAI_CD.SelectedIndex = 0
        End Select
    End Sub

    '�s�K���敪
    Private Sub CmbFUTEKIGO_KB_SelectedValueChanged(sender As Object, e As EventArgs) Handles cmbFUTEKIGO_KB.SelectedValueChanged

        If cmbFUTEKIGO_KB.SelectedValue <> "" Then
            Dim dt As New DataTableEx
            Using DB As ClsDbUtility = DBOpen()
                FunGetCodeDataTable(DB, "�s�K��" & cmbFUTEKIGO_KB.Text.Replace("�E", "") & "�敪", dt)
            End Using
            cmbFUTEKIGO_S_KB.SetDataSource(dt.ExcludeDeleted, ENM_COMBO_SELECT_VALUE_TYPE._0_Required)
        Else
            cmbFUTEKIGO_S_KB.DataSource = Nothing
        End If

    End Sub

    '���i�ԍ�
    Private Sub CmbBUHIN_BANGO_Validated(sender As Object, e As EventArgs) Handles cmbBUHIN_BANGO.Validated
        'CHECK: SelectedValue�Ƀo�C���h���Ă��邽�߁ASelectedValueChanged�����Ɛݒ�ł��Ȃ�? �v����
        If cmbBUHIN_BANGO.SelectedValue IsNot Nothing Then
            Dim dr As DataRow = DirectCast(cmbBUHIN_BANGO.DataSource, DataTable).AsEnumerable.Where(Function(r) r.Field(Of String)("VALUE") = cmbBUHIN_BANGO.SelectedValue).FirstOrDefault
            _D003_NCR_J.SYANAI_CD = dr.Item("SYANAI_CD")
            _D003_NCR_J.BUHIN_NAME = dr.Item("BUHIN_NAME")
        Else
            _D003_NCR_J.SYANAI_CD = ""
            _D003_NCR_J.BUHIN_NAME = ""
        End If
    End Sub

    '�Г��R�[�h
    Private Sub CmbSYANAI_CD_Validated(sender As Object, e As EventArgs) Handles cmbSYANAI_CD.Validated
        If cmbSYANAI_CD.SelectedValue IsNot Nothing Then
            Dim dr As DataRow = DirectCast(cmbSYANAI_CD.DataSource, DataTable).AsEnumerable.Where(Function(r) r.Field(Of String)("SYANAI_CD") = cmbSYANAI_CD.SelectedValue).FirstOrDefault
            _D003_NCR_J.BUHIN_BANGO = dr.Item("BUHIN_BANGO")
            _D003_NCR_J.BUHIN_NAME = dr.Item("BUHIN_MEI")
        Else
            _D003_NCR_J.BUHIN_BANGO = ""
            _D003_NCR_J.BUHIN_NAME = ""
        End If
    End Sub

#Region "���̓`�F�b�N�֘A"
    'UNDONE: �K�{���̓R���g���[���̓��̓`�F�b�N�p ErrorProvider�ݒ�
#End Region


#End Region

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

    Private Sub ChkZESEI_SYOCHI_YOHI_KB_CheckedChanged(sender As Object, e As EventArgs) Handles chkST04_ZESEI_SYOCHI_YOHI_KB.CheckedChanged
        If chkST04_ZESEI_SYOCHI_YOHI_KB.Checked Then
            rbtnST04_ZESEI_YES.Checked = True
        Else
            rbtnST04_ZESEI_NO.Checked = True
        End If
    End Sub

#End Region
#Region "   STAGE5"

#End Region
#Region "   STAGE6"

#End Region
#Region "   STAGE7"

    Private Sub ChkST07_SAIKAKO_SIJI_FLG_CheckedChanged(sender As Object, e As EventArgs) Handles chkST07_SAIKAKO_SIJI_FLG.CheckedChanged
        If chkST07_SAIKAKO_SIJI_FLG.Checked Then
            rbtnST07_Yes.Checked = True
        Else
            rbtnST07_No.Checked = True
        End If
    End Sub

#End Region
#Region "   STAGE8"

#End Region
#Region "   STAGE9"

#End Region
#Region "   STAGE10"

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
        If chk.Checked Then
            DirectCast(tlpST08.Controls("rbtnST11_" & chk.Name.Substring(8, 2) & "_T"), RadioButton).Checked = True
        Else
            DirectCast(tlpST08.Controls("rbtnST11_" & chk.Name.Substring(8, 2) & "_F"), RadioButton).Checked = True
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

            _D003_NCR_J.FILE_PATH = ofd.FileName
            'lbltmpFile1.Tag = ofd.FileName
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
        lbltmpFile1.Tag = ""
        lbltmpFile1.Links.Clear()
        lbltmpFile1.Visible = False
        lbltmpFile1_Clear.Visible = False
    End Sub

    Private Sub ProcessExited(ByVal sender As Object, ByVal e As EventArgs)
        'Call SetTaskbarOverlayIcon(Nothing)
        'Call SetTaskbarInfo(ENM_TASKBAR_STATE._0_NoProgress)
    End Sub
#End Region

#Region "�摜1"

    '�摜1�I��
    Private Sub BtnOpenPict1Dialog_Click(sender As Object, e As EventArgs) Handles btnOpenPict1Dialog.Click
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
        lblPict1Path.Tag = ""
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
        pnlPict1.Image = Image.FromFile(strFileName(0))
        pnlPict1.Cursor = Cursors.Hand

        lblPict1Path.Text = CompactString(strFileName(0), lblPict1Path, EllipsisFormat._4_Path) 'IO.Path.GetFileName(strFileName)
        'lblPict1Path.Tag = strFileName(0)
        _D003_NCR_J.G_FILE_PATH1 = strFileName(0)
        lblPict1Path.Links.Clear()
        lblPict1Path.Links.Add(0, lblPict1Path.Text.Length, strFileName(0))
        lblPict1Path.Visible = True
        lblPict1Path_Clear.Visible = True
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
        lblPict2Path.Tag = ""
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
        pnlPict2.Image = Image.FromFile(strFileName(0))
        pnlPict2.Cursor = Cursors.Hand

        lblPict2Path.Text = CompactString(strFileName(0), lblPict2Path, EllipsisFormat._4_Path) 'IO.Path.GetFileName(strFileName)
        'lblPict2Path.Tag = strFileName(0)
        _D003_NCR_J.G_FILE_PATH2 = strFileName(0)
        lblPict2Path.Links.Clear()
        lblPict2Path.Links.Add(0, lblPict2Path.Text.Length, strFileName)
        lblPict2Path.Visible = True
        lblPict2Path_Clear.Visible = True
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
    Private Function FunSetBinding() As Boolean

        '����
        mtxHOKUKO_NO.DataBindings.Add(New Binding(NameOf(mtxHOKUKO_NO.Text), _D003_NCR_J, NameOf(_D003_NCR_J.HOKOKU_NO)))
        cmbBUMON.DataBindings.Add(New Binding(NameOf(cmbBUMON.SelectedValue), _D003_NCR_J, NameOf(_D003_NCR_J.BUMON_KB)))
        chkClosed.DataBindings.Add(New Binding(NameOf(chkClosed.Checked), _D003_NCR_J, NameOf(_D003_NCR_J.CLOSE_FG)))
        dtDraft.DataBindings.Add(New Binding(NameOf(dtDraft.ValueNonFormat), _D003_NCR_J, NameOf(_D003_NCR_J.ADD_YMD)))
        cmbAddTanto.DataBindings.Add(New Binding(NameOf(cmbAddTanto.SelectedValue), _D003_NCR_J, NameOf(_D003_NCR_J.ADD_SYAIN_ID)))
        cmbKISYU.DataBindings.Add(New Binding(NameOf(cmbKISYU.SelectedValue), _D003_NCR_J, NameOf(_D003_NCR_J.KISYU_ID)))
        mtxGOUKI.DataBindings.Add(New Binding(NameOf(mtxGOUKI.Text), _D003_NCR_J, NameOf(_D003_NCR_J.GOKI)))
        cmbSYANAI_CD.DataBindings.Add(New Binding(NameOf(cmbSYANAI_CD.SelectedValue), _D003_NCR_J, NameOf(_D003_NCR_J.SYANAI_CD)))
        cmbBUHIN_BANGO.DataBindings.Add(New Binding(NameOf(cmbBUHIN_BANGO.SelectedValue), _D003_NCR_J, NameOf(_D003_NCR_J.BUHIN_BANGO)))
        mtxHINMEI.DataBindings.Add(New Binding(NameOf(mtxHINMEI.Text), _D003_NCR_J, NameOf(_D003_NCR_J.BUHIN_NAME)))
        numSU.DataBindings.Add(New Binding(NameOf(numSU.Value), _D003_NCR_J, NameOf(_D003_NCR_J.SURYO)))
        cmbFUTEKIGO_STATUS.DataBindings.Add(New Binding(NameOf(cmbFUTEKIGO_STATUS.SelectedValue), _D003_NCR_J, NameOf(_D003_NCR_J.FUTEKIGO_JYOTAI_KB)))
        chkSAIHATU.DataBindings.Add(New Binding(NameOf(chkSAIHATU.Checked), _D003_NCR_J, NameOf(_D003_NCR_J.SAIHATU)))
        cmbFUTEKIGO_KB.DataBindings.Add(New Binding(NameOf(cmbFUTEKIGO_KB.SelectedValue), _D003_NCR_J, NameOf(_D003_NCR_J.FUTEKIGO_KB)))
        cmbFUTEKIGO_S_KB.DataBindings.Add(New Binding(NameOf(cmbFUTEKIGO_S_KB.SelectedValue), _D003_NCR_J, NameOf(_D003_NCR_J.FUTEKIGO_S_KB)))
        mtxZUBAN_KIKAKU.DataBindings.Add(New Binding(NameOf(mtxZUBAN_KIKAKU.Text), _D003_NCR_J, NameOf(_D003_NCR_J.ZUMEN_KIKAKU)))

        '�Y�t����
        lbltmpFile1.DataBindings.Add(New Binding(NameOf(lbltmpFile1.Tag), _D003_NCR_J, NameOf(_D003_NCR_J.FILE_PATH)))
        lblPict1Path.DataBindings.Add(New Binding(NameOf(lblPict1Path.Tag), _D003_NCR_J, NameOf(_D003_NCR_J.G_FILE_PATH1)))
        lblPict2Path.DataBindings.Add(New Binding(NameOf(lblPict2Path.Tag), _D003_NCR_J, NameOf(_D003_NCR_J.G_FILE_PATH2)))


        'STAGE01
        txtST01_YOKYU_NAIYO.DataBindings.Add(New Binding(NameOf(txtST01_YOKYU_NAIYO.Text), _D003_NCR_J, NameOf(_D003_NCR_J.YOKYU_NAIYO)))
        txtST01_KEKKA.DataBindings.Add(New Binding(NameOf(txtST01_KEKKA.Text), _D003_NCR_J, NameOf(_D003_NCR_J.KANSATU_KEKKA)))

        'STAGE02
        'mtxHOKUKO_NO.DataBindings.Add(New Binding(NameOf(mtxHOKUKO_NO.Text), _D003_NCR_J, NameOf(_D003_NCR_J.HOKOKU_NO)))

        'STAGE03
        'mtxHOKUKO_NO.DataBindings.Add(New Binding(NameOf(mtxHOKUKO_NO.Text), _D003_NCR_J, NameOf(_D003_NCR_J.HOKOKU_NO)))

        'STAGE04
        cmbST04_ZIZENSINSA_HANTEI.DataBindings.Add(New Binding(NameOf(cmbST04_ZIZENSINSA_HANTEI.SelectedValue), _D003_NCR_J, NameOf(_D003_NCR_J.JIZEN_SINSA_HANTEI_KB)))
        chkST04_ZESEI_SYOCHI_YOHI_KB.DataBindings.Add(New Binding(NameOf(chkST04_ZESEI_SYOCHI_YOHI_KB.Checked), _D003_NCR_J, NameOf(_D003_NCR_J.ZESEI_SYOCHI_YOHI_KB)))
        txtST04_RIYU.DataBindings.Add(New Binding(NameOf(txtST04_RIYU.Text), _D003_NCR_J, NameOf(_D003_NCR_J.ZESEI_NASI_RIYU)))

        'STAGE05
        'mtxHOKUKO_NO.DataBindings.Add(New Binding(NameOf(mtxHOKUKO_NO.Text), _D003_NCR_J, NameOf(_D003_NCR_J.HOKOKU_NO)))

        'STAGE06
        cmbST06_SAISIN_IINKAI_HANTEI.DataBindings.Add(New Binding(NameOf(cmbST06_SAISIN_IINKAI_HANTEI.SelectedValue), _D003_NCR_J, NameOf(_D003_NCR_J.SAISIN_IINKAI_HANTEI_KB)))
        mtxST06_SAISIN_IINKAI_SIRYO_NO.DataBindings.Add(New Binding(NameOf(mtxST06_SAISIN_IINKAI_SIRYO_NO.Text), _D003_NCR_J, NameOf(_D003_NCR_J.SAISIN_IINKAI_SIRYO_NO)))

        'STAGE07
        mtxST07_ITAG_NO.DataBindings.Add(New Binding(NameOf(mtxST07_ITAG_NO.Text), _D003_NCR_J, NameOf(_D003_NCR_J.ITAG_NO)))
        cmbST07_SAISIN_TANTO.DataBindings.Add(New Binding(NameOf(cmbST07_SAISIN_TANTO.SelectedValue), _D003_NCR_J, NameOf(_D003_NCR_J.KOKYAKU_SAISIN_TANTO_ID)))
        cmbST07_KOKYAKU_HANTEI_SIJI.DataBindings.Add(New Binding(NameOf(cmbST07_KOKYAKU_HANTEI_SIJI.SelectedValue), _D003_NCR_J, NameOf(_D003_NCR_J.KOKYAKU_HANTEI_SIJI_KB)))
        dtST07_KOKYAKU_HANTEI_SIJI.DataBindings.Add(New Binding(NameOf(dtST07_KOKYAKU_HANTEI_SIJI.ValueNonFormat), _D003_NCR_J, NameOf(_D003_NCR_J.KOKYAKU_HANTEI_SIJI_YMD)))
        cmbST07_KOKYAKU_SAISYU_HANTEI.DataBindings.Add(New Binding(NameOf(cmbST07_KOKYAKU_SAISYU_HANTEI.SelectedValue), _D003_NCR_J, NameOf(_D003_NCR_J.KOKYAKU_SAISYU_HANTEI_KB)))
        dtST07_KOKYAKU_SAISYU_HANTEI.DataBindings.Add(New Binding(NameOf(dtST07_KOKYAKU_SAISYU_HANTEI.ValueNonFormat), _D003_NCR_J, NameOf(_D003_NCR_J.KOKYAKU_SAISYU_HANTEI_YMD)))
        chkST07_SAIKAKO_SIJI_FLG.DataBindings.Add(New Binding(NameOf(chkST07_SAIKAKO_SIJI_FLG.Checked), _D003_NCR_J, NameOf(_D003_NCR_J.SAIKAKO_SIJI_FG)))

        'STAGE08
        dtST08_1_HAIKYAKU_YMD.DataBindings.Add(New Binding(NameOf(dtST08_1_HAIKYAKU_YMD.ValueNonFormat), _D003_NCR_J, NameOf(_D003_NCR_J.HAIKYAKU_YMD)))
        cmbST08_1_HAIKYAKU_KB.DataBindings.Add(New Binding(NameOf(cmbST08_1_HAIKYAKU_KB.SelectedValue), _D003_NCR_J, NameOf(_D003_NCR_J.HAIKYAKU_KB)))
        mtxST08_1_BIKO.DataBindings.Add(New Binding(NameOf(mtxST08_1_BIKO.Text), _D003_NCR_J, NameOf(_D003_NCR_J.HAIKYAKU_HOUHOU)))
        cmbST08_1_HAIKYAKU_TANTO.DataBindings.Add(New Binding(NameOf(cmbST08_1_HAIKYAKU_TANTO.SelectedValue), _D003_NCR_J, NameOf(_D003_NCR_J.HAIKYAKU_TANTO_ID)))

        mtxST08_2_DOC_NO.DataBindings.Add(New Binding(NameOf(mtxST08_2_DOC_NO.Text), _D003_NCR_J, NameOf(_D003_NCR_J.SAIKAKO_SIJI_NO)))
        dtST08_2_WorkOutYMD.DataBindings.Add(New Binding(NameOf(dtST08_2_WorkOutYMD.ValueNonFormat), _D003_NCR_J, NameOf(_D003_NCR_J.SAIKAKO_SAGYO_KAN_YMD)))
        dtST08_2_KENSA_YMD.DataBindings.Add(New Binding(NameOf(dtST08_2_KENSA_YMD.ValueNonFormat), _D003_NCR_J, NameOf(_D003_NCR_J.SAIKAKO_KENSA_YMD)))
        cmbST08_2_KENSA_KEKKA.DataBindings.Add(New Binding(NameOf(cmbST08_2_KENSA_KEKKA.SelectedValue), _D003_NCR_J, NameOf(_D003_NCR_J.KENSA_KEKKA_KB)))
        cmbST08_2_TANTO_SEIZO.DataBindings.Add(New Binding(NameOf(cmbST08_2_TANTO_SEIZO.SelectedValue), _D003_NCR_J, NameOf(_D003_NCR_J.SEIZO_TANTO_ID)))
        cmbST08_2_TANTO_SEIGI.DataBindings.Add(New Binding(NameOf(cmbST08_2_TANTO_SEIGI.SelectedValue), _D003_NCR_J, NameOf(_D003_NCR_J.SEIGI_TANTO_ID)))
        cmbST08_2_TANTO_KENSA.DataBindings.Add(New Binding(NameOf(cmbST08_2_TANTO_KENSA.SelectedValue), _D003_NCR_J, NameOf(_D003_NCR_J.KENSA_TANTO_ID)))

        dtST08_3_HENKYAKU_YMD.DataBindings.Add(New Binding(NameOf(dtST08_3_HENKYAKU_YMD.ValueNonFormat), _D003_NCR_J, NameOf(_D003_NCR_J.HAIKYAKU_YMD)))
        mtxST08_3_HENKYAKU_SAKI.DataBindings.Add(New Binding(NameOf(mtxST08_3_HENKYAKU_SAKI.Text), _D003_NCR_J, NameOf(_D003_NCR_J.HENKYAKU_SAKI)))
        txtST08_3_BIKO.DataBindings.Add(New Binding(NameOf(txtST08_3_BIKO.Text), _D003_NCR_J, NameOf(_D003_NCR_J.HENKYAKU_BIKO)))

        cmbST08_4_KISYU.DataBindings.Add(New Binding(NameOf(cmbST08_4_KISYU.SelectedValue), _D003_NCR_J, NameOf(_D003_NCR_J.TENYO_KISYU_ID)))
        cmbST08_4_BUHIN_BANGO.DataBindings.Add(New Binding(NameOf(cmbST08_4_BUHIN_BANGO.SelectedValue), _D003_NCR_J, NameOf(_D003_NCR_J.TENYO_BUHIN_BANGO)))
        mtxST08_4_GOUKI.DataBindings.Add(New Binding(NameOf(mtxST08_4_GOUKI.Text), _D003_NCR_J, NameOf(_D003_NCR_J.TENYO_GOKI)))
        mtxST08_4_LOT.DataBindings.Add(New Binding(NameOf(mtxST08_4_LOT.Text), _D003_NCR_J, NameOf(_D003_NCR_J.TENYO_LOT)))
        dtST08_4_TENYO_YMD.DataBindings.Add(New Binding(NameOf(dtST08_4_TENYO_YMD.ValueNonFormat), _D003_NCR_J, NameOf(_D003_NCR_J.TENYO_YMD)))

        'STAGE09
        'mtxHOKUKO_NO.DataBindings.Add(New Binding(NameOf(mtxHOKUKO_NO.Text), _D003_NCR_J, NameOf(_D003_NCR_J.HOKOKU_NO)))

        'STAGE10
        'mtxHOKUKO_NO.DataBindings.Add(New Binding(NameOf(mtxHOKUKO_NO.Text), _D003_NCR_J, NameOf(_D003_NCR_J.HOKOKU_NO)))

        'STAGE11
        chkST11_A1.DataBindings.Add(New Binding(NameOf(chkST11_A1.Checked), _D003_NCR_J, NameOf(_D003_NCR_J.SYOCHI_KEKKA_A)))
        chkST11_B1.DataBindings.Add(New Binding(NameOf(chkST11_B1.Checked), _D003_NCR_J, NameOf(_D003_NCR_J.SYOCHI_KEKKA_B)))
        chkST11_C1.DataBindings.Add(New Binding(NameOf(chkST11_C1.Checked), _D003_NCR_J, NameOf(_D003_NCR_J.SYOCHI_KEKKA_C)))
        chkST11_D1.DataBindings.Add(New Binding(NameOf(chkST11_D1.Checked), _D003_NCR_J, NameOf(_D003_NCR_J.SYOCHI_D_UMU_KB)))
        chkST11_D2.DataBindings.Add(New Binding(NameOf(chkST11_D2.Checked), _D003_NCR_J, NameOf(_D003_NCR_J.SYOCHI_D_YOHI_KB)))
        mtxST11_D_Comment.DataBindings.Add(New Binding(NameOf(mtxST11_D_Comment.Text), _D003_NCR_J, NameOf(_D003_NCR_J.SYOCHI_D_SYOCHI_KIROKU)))
        chkST11_E1.DataBindings.Add(New Binding(NameOf(chkST11_E1.Checked), _D003_NCR_J, NameOf(_D003_NCR_J.SYOCHI_E_UMU_KB)))
        chkST11_E2.DataBindings.Add(New Binding(NameOf(chkST11_E2.Checked), _D003_NCR_J, NameOf(_D003_NCR_J.SYOCHI_E_YOHI_KB)))
        mtxST11_E_Comment.DataBindings.Add(New Binding(NameOf(mtxST11_E_Comment.Text), _D003_NCR_J, NameOf(_D003_NCR_J.SYOCHI_E_SYOCHI_KIROKU)))

        'STAGE12



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
                    _D003_NCR_J.BUMON_KB = pub_SYAIN_INFO.BUMON_KB
                    _D003_NCR_J.SURYO = 1


                    'SPEC: 2.(3).B.�A
                    PrCurrentStage = ENM_NCR_STAGE._10_�N������

                    Call FunInitializeTabControl(FunConvertSYONIN_JUN_TO_STAGE_NO(PrCurrentStage))
                    Call FunInitializeSTAGE(PrCurrentStage)

                Case ENM_DATA_OPERATION_MODE._3_UPDATE


                    'SPEC: 10-2.�@
                    Call FunSetEntityValues(PrDataRow)

                    Call FunInitializeTabControl(FunConvertSYONIN_JUN_TO_STAGE_NO(PrDataRow.Item("SYONIN_JUN")))
                    Call FunInitializeSTAGE(PrDataRow.Item("SYONIN_JUN"))
                    mtxHOKUKO_NO.Enabled = False

                    For Each page As TabPage In TabSTAGE.TabPages
                        If page.Text = "���X�e�[�W" Then
                            TabSTAGE.SelectedIndex = page.TabIndex
                            Exit For
                        End If
                    Next page
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
                mtxFUTEKIGO_NAIYO.Text = .Item("")
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
                    If PrDataRow Is Nothing Then
                        '�V�K�쐬��
                        'SPEC: (3).B 
                        page.Enabled = True
                    Else
                        page.Enabled = FunblnOwnCreated(ENM_SYONIN_HOKOKU_ID._1_NCR, PrDataRow("HOKOKUSYO_NO"), PrDataRow("SYONIN_JUN"))
                    End If
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

            Dim intNextStageID As Integer

            'SPEC: 50-3 50�ȍ~�̏��F���J��
            Select Case intCurrentStageID
                Case Is < ENM_NCR_STAGE._50_���O�R���m�F
                    '50�ȑO�̏ꍇ�͓o�^���Ԓʂ�

                    Dim drList As List(Of DataRow) = tblNCR.AsEnumerable().
                                                    Where(Function(r) Val(r.Field(Of String)("VALUE")) > intCurrentStageID).ToList
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
        Dim currentStageTabNo As Integer = FunConvertSYONIN_JUN_TO_STAGE_NO(intCurrentStageID).ToString("00")
        Dim cmbTANTO As ComboboxEx = Me.Controls("tabSTAGE" & currentStageTabNo).Controls("cmbST" & currentStageTabNo & "_DestTANTO")

        If cmbTANTO IsNot Nothing Then
            Return cmbTANTO.SelectedValue
        Else
            Return 0
        End If
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

#Region "�f���p(���g�p)"
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

#End Region

    ''#Region "�[���\��ꗗ"
    '    Private Function FunOpenReportNonyuList() As Boolean
    '        Dim strOutputFileName As String
    '        Dim strTEMPFILE As String
    '        'Dim intRET As Integer

    '        Try
    '            '�t�@�C����
    '            strOutputFileName = "�[���\��ꗗ_" & DateTime.ParseExact(Me.dtYM.Value, "yyyy/MM/dd", Nothing).ToString("yyyy�NMM��") &
    '                                      "_" & Me.cmbSYUBETU.Text & "_" & Me.cmbSIIRE.Text & ".xlsx"

    '            '�����t�@�C���폜
    '            If FunDELETE_FILE(pub_APP_INFO.strOUTPUT_PATH & strOutputFileName) = False Then
    '                Return False
    '            End If

    '            Using iniIF As New IniFile(FunGetRootPath() & "\INI\" & CON_TEMPLATE_INI)
    '                strTEMPFILE = FunConvRootPath(iniIF.GetIniString("�����m��", "FILEPATH2"))
    '            End Using

    '            '�G�N�Z���o�̓t�@�C���p��
    '            If OUT_EXCEL_READY(strTEMPFILE, pub_APP_INFO.strOUTPUT_PATH, strOutputFileName) = False Then
    '                Return False
    '            End If
    '            '-----��������
    '            Dim rows As List(Of DataRow) = DirectCast(Me.dgvDATA.DataSource, DataTable).AsEnumerable().ToList
    '            If FunMakeReportNonyuList(rows, pub_APP_INFO.strOUTPUT_PATH & strOutputFileName) = False Then
    '                Return False
    '            End If

    '            'Excel�N��
    '            Return FunOpenExcelApp(pub_APP_INFO.strOUTPUT_PATH & strOutputFileName)

    '        Catch ex As Exception
    '            EM.ErrorSyori(ex, False, conblnNonMsg)
    '            Return False
    '        Finally
    '            Me.PrPG_STATUS = ENM_PG_STATUS._2_ACTIVE
    '        End Try
    '    End Function

    '    Private Function FunMakeReportNonyuList(ByVal rows As List(Of DataRow), ByVal strFilePath As String) As Boolean
    '        'Dim dsList As New DataSet
    '        'Dim sbSQL As New System.Text.StringBuilder

    '        Dim intCurrentRowIndex As Integer = 4
    '        Dim strRange As String

    '        Dim spWorkbook As SpreadsheetGear.IWorkbook
    '        Dim spWorksheets As SpreadsheetGear.IWorksheets
    '        Dim spSheet1 As SpreadsheetGear.IWorksheet
    '        Dim spWork As SpreadsheetGear.IWorksheet
    '        Dim spRangeFrom As SpreadsheetGear.IRange
    '        Dim spRangeTo As SpreadsheetGear.IRange

    '        Try
    '            spWorkbook = SpreadsheetGear.Factory.GetWorkbook(strFilePath, System.Globalization.CultureInfo.CurrentCulture)

    '            spWorkbook.WorkbookSet.GetLock()
    '            spWorksheets = spWorkbook.Worksheets
    '            spSheet1 = spWorksheets.Item(0) 'sheet1
    '            spWork = spWorksheets.Item(1) 'Work

    '            Dim spprint As SpreadsheetGear.Printing.PrintWhat = SpreadsheetGear.Printing.PrintWhat.Sheet

    '            'sbSQL.Remove(0, sbSQL.Length)
    '            'sbSQL.Append(" SELECT * FROM " & Context.CON_S_TB07_HACCYU_STATUS & " ")
    '            ''[�N��],[���],[�ð��],[����No],[�i��],[�[���\���From],[�[���\���To]
    '            'sbSQL.Append(String.Format("('{0}','{1}','{2}','{3}','{4}','{5}','{6}')",
    '            '                       Me.dtYM.ValueNonFormat,
    '            '                       Me.cmbSYUBETU.SelectedValue,
    '            '                       Me.cmbSTATUS.SelectedValue,
    '            '                       strHacyuNo,
    '            '                       Me.mtxHINMEI.Text,
    '            '                       Me.mtxDayFrom.Text,
    '            '                       Me.mtxDayTo.Text))
    '            'If chkDeletedRowVisibled.Checked = False Then
    '            '    sbSQL.Append(" WHERE STATUS <> '" & Context.ENM_HACCYU_STATUS._9_��� & "'")
    '            'End If
    '            'sbSQL.Append(" ORDER BY HACYU_NO,E_NO")

    '            'Using DB As ClsDbUtility = DBOpen()
    '            '    dsList = DB.GetDataSet(sbSQL.ToString)
    '            'End Using

    '            For Each row In rows
    '                With row
    '                    '���R�[�h�t���[��������
    '                    spWork.Range("RECORD_FRAME").ClearContents()
    '                    If .Item("NONYU_Y_YMD").ToString.Trim <> "" Then
    '                        spWork.Range("NONYU_Y_YMD").Value = CDate(.Item("NONYU_Y_YMD")).ToString("yyyy/MM/dd")
    '                    End If
    '                    spWork.Range("STATUS").Value = .Item("STATUS_NAME")

    '                    If .Item("HACYU_NO").ToString.Trim <> "" Then
    '                        spWork.Range("HACYU_E_NO").Value = .Item("HACYU_NO") & "-" & Val(.Item("E_NO")).ToString("000")
    '                    End If
    '                    If .Item("NONYU_YMD").ToString.Trim <> "" Then
    '                        spWork.Range("NONYU_YMD").Value = CDate(.Item("NONYU_YMD")).ToString("yyyy/MM/dd")
    '                    End If

    '                    If .Item("KEIJYO_YMD").ToString.Trim <> "" Then
    '                        spWork.Range("KEIJYO_YMD").Value = CDate(.Item("KEIJYO_YMD")).ToString("yyyy/MM/dd")
    '                    End If

    '                    spWork.Range("SIIRE").Value = .Item("SIIRE_NAME")
    '                    spWork.Range("MAKER").Value = .Item("MAKER_NAME")
    '                    spWork.Range("HINMEI").Value = .Item("HINMEI")
    '                    spWork.Range("HACYU_SU").Value = .Item("HACYU_SU")
    '                    spWork.Range("NONYU_SU").Value = If(.Item("NONYU_SU") = 0, "", .Item("NONYU_SU"))
    '                    spWork.Range("TANKA").Value = .Item("TANKA")
    '                    spWork.Range("KINGAKU").Formula = "=I2*K2" '������ * �P��

    '                    '-----���R�[�h�t���[����{�V�[�g�ɃR�s�[
    '                    spRangeFrom = spWork.Cells("RECORD_FRAME").EntireRow
    '                    strRange = String.Format("A{0}:L{1}", intCurrentRowIndex, intCurrentRowIndex)
    '                    spRangeTo = spSheet1.Cells(strRange).EntireRow
    '                    spRangeFrom.Copy(spRangeTo, SpreadsheetGear.PasteType.All, SpreadsheetGear.PasteOperation.None, False, False)

    '                    '�J�����g�s���X�V
    '                    intCurrentRowIndex += 1
    '                End With
    '            Next row

    '            '����͈͎w��
    '            spSheet1.PageSetup.PrintArea = "sheet1!$A$1:$L$" & intCurrentRowIndex
    '            '����^�C�g���s
    '            spSheet1.PageSetup.PrintTitleRows = "sheet1!$1:$3"

    '            '-----�t�@�C���ۑ�
    '            spWork.Delete()
    '            spWorksheets(0).Cells("A1").Select()
    '            spSheet1.SaveAs(filename:=strFilePath, fileFormat:=SpreadsheetGear.FileFormat.OpenXMLWorkbook)
    '            spWorkbook.WorkbookSet.ReleaseLock()

    '            Return True

    '        Catch ex As Exception
    '            EM.ErrorSyori(ex, False, conblnNonMsg)
    '            Return False
    '        Finally
    '            spRangeFrom = Nothing
    '            spRangeTo = Nothing
    '            spSheet1 = Nothing
    '            spWork = Nothing
    '            spWorksheets = Nothing
    '            spWorkbook = Nothing

    '            ''-----�J��
    '            'dsList.Dispose()
    '        End Try
    '    End Function

    '#End Region


End Class