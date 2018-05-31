Imports JMS_COMMON.ClsPubMethod


Public Class FrmG0012

#Region "�萔�E�ϐ�"
    Private _V002_NCR_J As New MODEL.V002_NCR_J
    Private _V005_CAR_J As New MODEL.V005_CAR_J

    '���͕K�{�R���g���[�����ؔ���
    Private pri_blnValidated As Boolean
#End Region


#Region "�v���p�e�B"
    ''' <summary>
    ''' �ꗗ�̑I���s�f�[�^
    ''' </summary>
    Public Property PrDataRow As DataRow

    '���݂̃X�e�[�W ���F��
    Public Property PrCurrentStage As Integer

    '�񍐏�No
    Public Property PrHOKOKU_NO As String
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
        MyBase.ToolTip.SetToolTip(Me.cmdFunc4, My.Resources.infoToolTipMsgNotFoundData)
        MyBase.ToolTip.SetToolTip(Me.cmdFunc5, My.Resources.infoToolTipMsgNotFoundData)
        MyBase.ToolTip.SetToolTip(Me.cmdFunc10, My.Resources.infoToolTipMsgNotFoundData)



    End Sub

#End Region

#Region "Form�֘A"

    'Load�C�x���g
    Private Sub FrmLoad(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        Try
            '-----�t�H�[�������ݒ�(�e�t�H�[������Ăяo��)
            Call FunFormCommonSetting(pub_APP_INFO, pub_SYAIN_INFO, My.Application.Info.Version.ToString)
            lblTytle.Text = "�s�K���������u�񍐏��iCorrective Action Report�j"
            Me.Text = lblTytle.Text
            '-----�O���b�h�����ݒ�(�e�t�H�[������Ăяo��)
            'Call FunInitializeDataGridView(Me.dgvDATA)

            '-----�O���b�h��쐬
            'Call FunSetDgvCulumns(Me.dgvDATA)

            '-----�R���g���[���f�[�^�\�[�X�ݒ�
            cmbKONPON_YOIN_KB1.SetDataSource(tblKONPON_YOIN_KB, ENM_COMBO_SELECT_VALUE_TYPE._2_Option)
            cmbKONPON_YOIN_KB2.SetDataSource(tblKONPON_YOIN_KB, ENM_COMBO_SELECT_VALUE_TYPE._2_Option)


            '-----��ʏ�����
            Call FunInitializeControls()
        Finally
            FunInitFuncButtonEnabled()
        End Try
    End Sub

#End Region

#Region "DataGridView�֘A"

    '�t�B�[���h��`()
    Private Shared Function FunSetDgvCulumns(ByVal dgv As DataGridView) As Boolean
        Dim _Model As New MODEL.M001_SETTING
        Try
            With dgv
                .AutoGenerateColumns = False

                '.Columns.Add(NameOf(_Model.KOMO_NM), GetDisplayName(_Model.GetType, NameOf(_Model.KOMO_NM)))
                '.Columns(.ColumnCount - 1).Width = 150
                '.Columns(.ColumnCount - 1).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
                '.Columns(.ColumnCount - 1).DataPropertyName = NameOf(_Model.KOMO_NM)

                '.Columns.Add(NameOf(_Model.VALUE), GetDisplayName(_Model.GetType, NameOf(_Model.VALUE)))
                '.Columns(.ColumnCount - 1).Width = 200
                '.Columns(.ColumnCount - 1).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
                '.Columns(.ColumnCount - 1).Frozen = True
                '.Columns(.ColumnCount - 1).DataPropertyName = NameOf(_Model.VALUE)

                '.Columns.Add(NameOf(_Model.DISP), GetDisplayName(_Model.GetType, NameOf(_Model.DISP)))
                '.Columns(.ColumnCount - 1).Width = 300
                '.Columns(.ColumnCount - 1).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
                '.Columns(.ColumnCount - 1).DataPropertyName = NameOf(_Model.DISP)

                '.Columns.Add(NameOf(_Model.DISP_ORDER), GetDisplayName(_Model.GetType, NameOf(_Model.DISP_ORDER)))
                '.Columns(.ColumnCount - 1).Width = 70
                '.Columns(.ColumnCount - 1).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                '.Columns(.ColumnCount - 1).DataPropertyName = NameOf(_Model.DISP_ORDER)

                '.Columns.Add(NameOf(_Model.BIKOU), GetDisplayName(_Model.GetType, NameOf(_Model.BIKOU)))
                '.Columns(.ColumnCount - 1).Width = 430
                '.Columns(.ColumnCount - 1).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
                '.Columns(.ColumnCount - 1).DataPropertyName = NameOf(_Model.BIKOU)

                'Using cmbclmn1 As New DataGridViewCheckBoxColumn
                '    cmbclmn1.Name = NameOf(_Model.DEF_FLG)
                '    cmbclmn1.HeaderText = GetDisplayName(_Model.GetType, NameOf(_Model.DEF_FLG))
                '    cmbclmn1.Width = 30

                '    cmbclmn1.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
                '    .Columns.Add(cmbclmn1)
                '    .Columns(.ColumnCount - 1).SortMode = DataGridViewColumnSortMode.Automatic
                '    .Columns(.ColumnCount - 1).DataPropertyName = NameOf(_Model.DEF_FLG)
                'End Using

                'Using cmbclmn2 As New DataGridViewCheckBoxColumn
                '    cmbclmn2.Name = NameOf(_Model.DEL_FLG)
                '    cmbclmn2.HeaderText = GetDisplayName(_Model.GetType, NameOf(_Model.DEL_FLG))
                '    cmbclmn2.Width = 30
                '    cmbclmn2.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
                '    .Columns.Add(cmbclmn2)
                '    .Columns(.ColumnCount - 1).SortMode = DataGridViewColumnSortMode.Automatic
                '    .Columns(.ColumnCount - 1).DataPropertyName = NameOf(_Model.DEL_FLG)
                'End Using

                '.Columns.Add(NameOf(_Model.ADD_YMDHNS), GetDisplayName(_Model.GetType, NameOf(_Model.ADD_YMDHNS)))
                '.Columns(.ColumnCount - 1).DataPropertyName = NameOf(_Model.ADD_YMDHNS)
                '.Columns(.ColumnCount - 1).Visible = False

                '.Columns.Add(NameOf(_Model.ADD_TANTO_CD), GetDisplayName(_Model.GetType, NameOf(_Model.ADD_TANTO_CD)))
                '.Columns(.ColumnCount - 1).DataPropertyName = NameOf(_Model.ADD_TANTO_CD)
                '.Columns(.ColumnCount - 1).Visible = False

                '.Columns.Add(NameOf(_Model.ADD_TANTO_NAME), GetDisplayName(_Model.GetType, NameOf(_Model.ADD_TANTO_NAME)))
                '.Columns(.ColumnCount - 1).DataPropertyName = NameOf(_Model.ADD_TANTO_NAME)
                '.Columns(.ColumnCount - 1).Visible = False

                '.Columns.Add(NameOf(_Model.EDIT_YMDHNS), GetDisplayName(_Model.GetType, NameOf(_Model.EDIT_YMDHNS)))
                '.Columns(.ColumnCount - 1).DataPropertyName = NameOf(_Model.EDIT_YMDHNS)
                '.Columns(.ColumnCount - 1).Visible = False

                '.Columns.Add(NameOf(_Model.EDIT_TANTO_CD), GetDisplayName(_Model.GetType, NameOf(_Model.EDIT_TANTO_CD)))
                '.Columns(.ColumnCount - 1).DataPropertyName = NameOf(_Model.EDIT_TANTO_CD)
                '.Columns(.ColumnCount - 1).Visible = False

                '.Columns.Add(NameOf(_Model.EDIT_TANTO_NAME), GetDisplayName(_Model.GetType, NameOf(_Model.EDIT_TANTO_NAME)))
                '.Columns(.ColumnCount - 1).DataPropertyName = NameOf(_Model.EDIT_TANTO_NAME)
                '.Columns(.ColumnCount - 1).Visible = False

                '.Columns.Add(NameOf(_Model.DEL_YMDHNS), GetDisplayName(_Model.GetType, NameOf(_Model.DEL_YMDHNS)))
                '.Columns(.ColumnCount - 1).DataPropertyName = NameOf(_Model.DEL_YMDHNS)
                '.Columns(.ColumnCount - 1).Visible = False

                '.Columns.Add(NameOf(_Model.DEL_YMDHNS), GetDisplayName(_Model.GetType, NameOf(_Model.DEL_YMDHNS)))
                '.Columns(.ColumnCount - 1).DataPropertyName = NameOf(_Model.DEL_YMDHNS)
                '.Columns(.ColumnCount - 1).Visible = False

                '.Columns.Add(NameOf(_Model.DEL_TANTO_NAME), GetDisplayName(_Model.GetType, NameOf(_Model.DEL_TANTO_NAME)))
                '.Columns(.ColumnCount - 1).DataPropertyName = NameOf(_Model.DEL_TANTO_NAME)
                '.Columns(.ColumnCount - 1).Visible = False
            End With

            Return True
        Finally

        End Try
    End Function

    '�O���b�h�Z��(�s)�_�u���N���b�N���C�x���g
    Private Sub DgvDATA_CellDoubleClick(sender As System.Object, e As DataGridViewCellEventArgs)
        Try
            '�w�b�_�ȊO�̃Z���_�u���N���b�N��
            If e.RowIndex >= 0 Then
                '�Y���s�̕ύX���������s����
                Me.cmdFunc4.PerformClick()
            End If
        Catch ex As Exception
            EM.ErrorSyori(ex, False, conblnNonMsg)
        End Try
    End Sub

    '�s�I�����C�x���g
    Private Overloads Sub DgvDATA_SelectionChanged(sender As System.Object, e As System.EventArgs)
        Try
        Finally
            'Call FunInitFuncButtonEnabled(Me)
        End Try
    End Sub

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

                    'DEBUG:
                    MessageBox.Show("�s��C����", "�g�p�s��")
                    Exit Sub

                    '���̓`�F�b�N
                    If FunCheckInput(ENM_SAVE_MODE._1_�ۑ�) Then
                        If MessageBox.Show("���͓��e��ۑ����܂����H", "�o�^�m�F", MessageBoxButtons.YesNo, MessageBoxIcon.Information) = DialogResult.Yes Then

                            If FunSAVE(ENM_SAVE_MODE._1_�ۑ�) Then
                                Me.DialogResult = DialogResult.OK
                                MessageBox.Show("���͓��e��ۑ����܂���", "�ۑ�����", MessageBoxButtons.OK, MessageBoxIcon.Information)
                            Else
                                MessageBox.Show("�ۑ������Ɏ��s���܂����B", "�ۑ����s", MessageBoxButtons.OK, MessageBoxIcon.Error)
                            End If
                        End If
                    End If

                Case 2  '���F�\��

                    'DEBUG:
                    MessageBox.Show("�s��C����", "�g�p�s��")
                    Exit Sub

                    '���̓`�F�b�N
                    If FunCheckInput(ENM_SAVE_MODE._2_���F�\��) Then
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
                    End If

                    'If FunUpdateEntity(ENM_DATA_OPERATION_MODE._1_ADD) = True Then
                    '    'Call FunSRCH(Me.dgvDATA, FunGetListData())
                    'End If
                Case 3  'NCR
                    Call OpenFormNCR()

                Case 4  '�]��
                    Call OpenFormTENSO()
                Case 5  '�����߂�
                    Call OpenFormSASIMODOSI()

                Case 10  'CSV�o��

                    'DEBUG:
                    MessageBox.Show("�s��C����", "�g�p�s��")
                    Exit Sub

                    Call FunOpenReportNCR()

                Case 11 '����
                    Call OpenFormHistory(ENM_SYONIN_HOKOKUSYO_ID._2_CAR, _V005_CAR_J.HOKOKU_NO)

                Case 12 '����
                    Me.Close()
                Case Else
                    MessageBox.Show("������", "", MessageBoxButtons.OK, MessageBoxIcon.Information)
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
            'Call FunInitFuncButtonEnabled(Me)

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
                    If Not _D003_NCR_J.FILE_PATH.IsNullOrWhiteSpace AndAlso _D003_NCR_J.FILE_PATH <> strRootDir & System.IO.Path.GetFileName(_D003_NCR_J.FILE_PATH) Then
                        System.IO.File.Copy(_D003_NCR_J.FILE_PATH, strRootDir & System.IO.Path.GetFileName(_D003_NCR_J.FILE_PATH), True)
                        _D003_NCR_J.FILE_PATH = strRootDir & System.IO.Path.GetFileName(_D003_NCR_J.FILE_PATH)
                    End If
                    If Not _D003_NCR_J.G_FILE_PATH1.IsNullOrWhiteSpace AndAlso _D003_NCR_J.G_FILE_PATH1 <> strRootDir & System.IO.Path.GetFileName(_D003_NCR_J.G_FILE_PATH1) Then
                        System.IO.File.Copy(_D003_NCR_J.G_FILE_PATH1, strRootDir & System.IO.Path.GetFileName(_D003_NCR_J.G_FILE_PATH1), True)
                        _D003_NCR_J.G_FILE_PATH1 = strRootDir & System.IO.Path.GetFileName(_D003_NCR_J.G_FILE_PATH1)
                    End If
                    If Not _D003_NCR_J.G_FILE_PATH2.IsNullOrWhiteSpace AndAlso _D003_NCR_J.G_FILE_PATH2 <> strRootDir & System.IO.Path.GetFileName(_D003_NCR_J.G_FILE_PATH2) Then
                        System.IO.File.Copy(_D003_NCR_J.G_FILE_PATH2, strRootDir & System.IO.Path.GetFileName(_D003_NCR_J.G_FILE_PATH2), True)
                        _D003_NCR_J.G_FILE_PATH2 = strRootDir & System.IO.Path.GetFileName(_D003_NCR_J.G_FILE_PATH2)
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
                _D003_NCR_J.HOKOKU_NO = DB.DbCommand.Parameters("HOKOKU_NO").Value
            Else
                Return False
            End If
        End If

        '-----���f���X�V
        If (PrCurrentStage = ENM_NCR_STAGE._80_���u���{ AndAlso _D003_NCR_J.KENSA_KEKKA_KB = ENM_KENSA_KEKKA_KB._1_�s���i) Or PrCurrentStage = ENM_NCR_STAGE._120_abcde���u�m�F Then
            _D003_NCR_J.CLOSE_FG = 1
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
        sbSQL.Append(" ,dbo.GetSysDateString() AS " & NameOf(_D003_NCR_J.UPD_YMDHNS))
        sbSQL.Append(" ,0 AS " & NameOf(_D003_NCR_J.DEL_SYAIN_ID))
        sbSQL.Append(" ,' ' AS " & NameOf(_D003_NCR_J.DEL_YMDHNS))
        sbSQL.Append(" ) AS WK")
        sbSQL.Append(" ON (SrcT.HOKOKU_NO = WK.HOKOKU_NO)")
        'UPDATE
        sbSQL.Append(" WHEN MATCHED THEN")
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
        sbSQL.Append(" ,WK." & NameOf(_D003_NCR_J.ADD_YMDHNS))
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
                '-----�G���[���O�o��
                Dim strErrMsg As String = My.Resources.ErrLogSqlExecutionFailure & sbSQL.ToString & "|" & sqlEx.Message
                WL.WriteLogDat(strErrMsg)
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
        sbSQL.Append(" ,SrcT." & NameOf(_D004_SYONIN_J_KANRI.COMMENT) & " = WK." & NameOf(_D004_SYONIN_J_KANRI.COMMENT))
        sbSQL.Append(" ,SrcT." & NameOf(_D004_SYONIN_J_KANRI.UPD_YMDHNS) & " = WK." & NameOf(_D004_SYONIN_J_KANRI.UPD_YMDHNS))
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
                '-----�G���[���O�o��
                Dim strErrMsg As String = My.Resources.ErrLogSqlExecutionFailure & sbSQL.ToString & "|" & sqlEx.Message
                WL.WriteLogDat(strErrMsg)
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
        sbSQL.Append(" ,dbo.GetSysDateString() AS " & NameOf(_D004_SYONIN_J_KANRI.UPD_YMDHNS))
        sbSQL.Append(" ) AS WK")
        sbSQL.Append(" ON (SrcT." & NameOf(_D004_SYONIN_J_KANRI.SYONIN_HOKOKUSYO_ID) & " = WK." & NameOf(_D004_SYONIN_J_KANRI.SYONIN_HOKOKUSYO_ID) & "")
        sbSQL.Append(" AND SrcT." & NameOf(_D004_SYONIN_J_KANRI.HOKOKU_NO) & " = WK." & NameOf(_D004_SYONIN_J_KANRI.HOKOKU_NO) & "")
        sbSQL.Append(" AND SrcT." & NameOf(_D004_SYONIN_J_KANRI.SYONIN_JUN) & " = WK." & NameOf(_D004_SYONIN_J_KANRI.SYONIN_JUN) & ")")
        'UPDATE
        sbSQL.Append(" WHEN MATCHED THEN")
        sbSQL.Append(" UPDATE SET")
        sbSQL.Append("  SrcT." & NameOf(_D004_SYONIN_J_KANRI.SYAIN_ID) & " = WK." & NameOf(_D004_SYONIN_J_KANRI.SYAIN_ID))
        sbSQL.Append(" ,SrcT." & NameOf(_D004_SYONIN_J_KANRI.COMMENT) & " = WK." & NameOf(_D004_SYONIN_J_KANRI.COMMENT))
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
        sbSQL.Append(" )")
        sbSQL.Append("OUTPUT $action AS RESULT") 'INSERT OR UPDATE ��ncarchar(10)�Ŏ擾����ꍇ
        sbSQL.Append(";")

        ''-----MERGE���s&���s���ʎ擾
        strRET = DB.ExecuteScalar(sbSQL.ToString, conblnNonMsg, sqlEx)
        Select Case strRET
            Case "INSERT"
                If _D004_SYONIN_J_KANRI.MAIL_SEND_FG = False Then
                    '���F�˗����[�����M
                    Call FunSendRequestMail()
                End If


            Case "UPDATE"

            Case Else
                '-----�G���[���O�o��
                Dim strErrMsg As String = My.Resources.ErrLogSqlExecutionFailure & sbSQL.ToString & "|" & sqlEx.Message
                WL.WriteLogDat(strErrMsg)
                Return False
        End Select


        'SPEC: 40-1
        If enmSAVE_MODE = ENM_SAVE_MODE._2_���F�\�� And
            PrCurrentStage = ENM_NCR_STAGE._40_���O�R������y��CAR�v�۔��� And
            _D003_NCR_J._ZESEI_SYOCHI_YOHI_KB = ENM_YOHI_KB._1_�v Then

            If FunSAVE_D005(DB) Then
                'blnEnableCAREdit = True
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
        sbSQL.Append(" ,'" & _D005_CAR_J.ZESEI_SYOCHI_YUKO_UMU & "'")
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
        sbSQL.Append(" ,SrcT." & NameOf(_D004_SYONIN_J_KANRI.COMMENT) & " = WK." & NameOf(_D004_SYONIN_J_KANRI.COMMENT))
        sbSQL.Append(" ,SrcT." & NameOf(_D004_SYONIN_J_KANRI.UPD_YMDHNS) & " = WK." & NameOf(_D004_SYONIN_J_KANRI.UPD_YMDHNS))
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
        Dim strRET As String
        strRET = DB.ExecuteScalar(sbSQL.ToString, conblnNonMsg, sqlEx)
        Select Case strRET
            Case "INSERT"

            Case "UPDATE"

            Case Else
                '-----�G���[���O�o��
                Dim strErrMsg As String = My.Resources.ErrLogSqlExecutionFailure & sbSQL.ToString & "|" & sqlEx.Message
                WL.WriteLogDat(strErrMsg)
                Return False
        End Select

        Return True
    End Function

#End Region

#Region "NCR"
    Private Function OpenFormNCR() As Boolean
        Dim frmDLG As New FrmG0011
        Dim dlgRET As DialogResult

        Try

            frmDLG.PrMODE = ENM_DATA_OPERATION_MODE._3_UPDATE
            frmDLG.PrDataRow = PrDataRow
            dlgRET = frmDLG.ShowDialog(Me)
            If dlgRET = Windows.Forms.DialogResult.Cancel Then
                Return False
            Else
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

            '�t�@�C����
            strOutputFileName = "CAR_" & _D003_NCR_J.HOKOKU_NO & "_Work.xlsx"

            '�����t�@�C���폜
            If FunDELETE_FILE(pub_APP_INFO.strOUTPUT_PATH & strOutputFileName) = False Then
                Return False
            End If

            Using iniIF As New IniFile(FunGetRootPath() & "\INI\" & CON_TEMPLATE_INI)
                strTEMPFILE = FunConvRootPath(iniIF.GetIniString("CAR", "FILEPATH"))
            End Using

            '�G�N�Z���o�̓t�@�C���p��
            If OUT_EXCEL_READY(strTEMPFILE, pub_APP_INFO.strOUTPUT_PATH, strOutputFileName) = False Then
                Return False
            End If
            '-----��������
            If FunMakeReportCAR(pub_APP_INFO.strOUTPUT_PATH & strOutputFileName, _D003_NCR_J.HOKOKU_NO) = False Then
                Return False
            End If

            'Excel�N��
            Return FunOpenExcelApp(pub_APP_INFO.strOUTPUT_PATH & strOutputFileName)

        Catch ex As Exception
            EM.ErrorSyori(ex, False, conblnNonMsg)
            Return False
        Finally

        End Try
    End Function

    Private Function FunMakeReportCAR(ByVal strFilePath As String, ByVal strHOKOKU_NO As String) As Boolean

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

            Dim _V005_CAR_J As MODEL.V005_CAR_J = FunGetV005Model(strHOKOKU_NO)

            spSheet1.Range(NameOf(_V005_CAR_J.GOKI)).Value = _V005_CAR_J.GOKI
            spSheet1.Range(NameOf(_V005_CAR_J.HOKOKU_NO)).Value = _V005_CAR_J.HOKOKU_NO
            spSheet1.Range(NameOf(_V005_CAR_J.KAITO_1)).Value = _V005_CAR_J.KAITO_1
            spSheet1.Range(NameOf(_V005_CAR_J.KAITO_2)).Value = _V005_CAR_J.KAITO_2
            spSheet1.Range(NameOf(_V005_CAR_J.KAITO_3)).Value = _V005_CAR_J.KAITO_3
            spSheet1.Range(NameOf(_V005_CAR_J.KAITO_4)).Value = _V005_CAR_J.KAITO_4
            spSheet1.Range(NameOf(_V005_CAR_J.KAITO_5)).Value = _V005_CAR_J.KAITO_5
            spSheet1.Range(NameOf(_V005_CAR_J.KAITO_6)).Value = _V005_CAR_J.KAITO_6
            spSheet1.Range(NameOf(_V005_CAR_J.KAITO_7)).Value = _V005_CAR_J.KAITO_7
            spSheet1.Range(NameOf(_V005_CAR_J.KAITO_8)).Value = _V005_CAR_J.KAITO_8
            spSheet1.Range(NameOf(_V005_CAR_J.KAITO_9)).Value = _V005_CAR_J.KAITO_9
            spSheet1.Range(NameOf(_V005_CAR_J.KAITO_10)).Value = _V005_CAR_J.KAITO_10
            spSheet1.Range(NameOf(_V005_CAR_J.KAITO_11)).Value = _V005_CAR_J.KAITO_11
            spSheet1.Range(NameOf(_V005_CAR_J.KAITO_12)).Value = _V005_CAR_J.KAITO_12
            spSheet1.Range(NameOf(_V005_CAR_J.KAITO_13)).Value = _V005_CAR_J.KAITO_13
            If CBool(_V005_CAR_J.KAITO_14) Then
                spSheet1.Range(NameOf(_V005_CAR_J.KAITO_14) & "_YOU").Value = "TRUE"
            Else
                spSheet1.Range(NameOf(_V005_CAR_J.KAITO_14) & "_HI").Value = "TRUE"
            End If
            spSheet1.Range(NameOf(_V005_CAR_J.KAITO_15)).Value = _V005_CAR_J.KAITO_15
            spSheet1.Range(NameOf(_V005_CAR_J.KAITO_16)).Value = _V005_CAR_J.KAITO_16
            spSheet1.Range(NameOf(_V005_CAR_J.KAITO_17)).Value = _V005_CAR_J.KAITO_17
            spSheet1.Range(NameOf(_V005_CAR_J.KAITO_18)).Value = _V005_CAR_J.KAITO_18
            spSheet1.Range(NameOf(_V005_CAR_J.KAITO_19)).Value = _V005_CAR_J.KAITO_19
            spSheet1.Range(NameOf(_V005_CAR_J.KAITO_20)).Value = _V005_CAR_J.KAITO_20
            spSheet1.Range(NameOf(_V005_CAR_J.KAITO_21)).Value = _V005_CAR_J.KAITO_21
            spSheet1.Range(NameOf(_V005_CAR_J.KAITO_22)).Value = _V005_CAR_J.KAITO_22
            spSheet1.Range(NameOf(_V005_CAR_J.KAITO_23)).Value = _V005_CAR_J.KAITO_23
            spSheet1.Range(NameOf(_V005_CAR_J.KAITO_24)).Value = _V005_CAR_J.KAITO_24
            spSheet1.Range(NameOf(_V005_CAR_J.KAITO_25)).Value = _V005_CAR_J.KAITO_25

            spSheet1.Range(NameOf(_V005_CAR_J.KENSA_GL_SYAIN_NAME)).Value = _V005_CAR_J.KENSA_GL_SYAIN_NAME
            spSheet1.Range(NameOf(_V005_CAR_J.KENSA_GL_YMDHNS)).Value = _V005_CAR_J.KENSA_GL_YMDHNS
            spSheet1.Range(NameOf(_V005_CAR_J.KENSA_TANTO_NAME)).Value = _V005_CAR_J.KENSA_TANTO_NAME
            spSheet1.Range(NameOf(_V005_CAR_J.KENSA_TOROKU_YMDHNS)).Value = _V005_CAR_J.KENSA_TOROKU_YMDHNS
            spSheet1.Range(NameOf(_V005_CAR_J.KISYU)).Value = _V005_CAR_J.KISYU
            spSheet1.Range(NameOf(_V005_CAR_J.SYOCHI_A_SYAIN_NAME)).Value = _V005_CAR_J.SYOCHI_A_SYAIN_NAME
            spSheet1.Range(NameOf(_V005_CAR_J.SYOCHI_A_YMDHNS)).Value = _V005_CAR_J.SYOCHI_A_YMDHNS
            spSheet1.Range(NameOf(_V005_CAR_J.SYOCHI_B_SYAIN_NAME)).Value = _V005_CAR_J.SYOCHI_B_SYAIN_NAME
            spSheet1.Range(NameOf(_V005_CAR_J.SYOCHI_B_YMDHNS)).Value = _V005_CAR_J.SYOCHI_B_YMDHNS
            spSheet1.Range(NameOf(_V005_CAR_J.SYOCHI_C_SYAIN_NAME)).Value = _V005_CAR_J.SYOCHI_C_SYAIN_NAME
            spSheet1.Range(NameOf(_V005_CAR_J.SYOCHI_C_YMDHNS)).Value = _V005_CAR_J.SYOCHI_C_YMDHNS
            spSheet1.Range("SYONIN_NAME10").Value = _V005_CAR_J.GOKI
            spSheet1.Range("SYONIN_NAME20").Value = _V005_CAR_J.GOKI
            spSheet1.Range("SYONIN_NAME30").Value = _V005_CAR_J.GOKI
            spSheet1.Range("SYONIN_NAME40").Value = _V005_CAR_J.GOKI
            spSheet1.Range("SYONIN_NAME50").Value = _V005_CAR_J.GOKI
            spSheet1.Range("SYONIN_NAME60").Value = _V005_CAR_J.GOKI
            spSheet1.Range("SYONIN_NAME90").Value = _V005_CAR_J.GOKI
            spSheet1.Range("SYONIN_NAME100").Value = _V005_CAR_J.GOKI
            spSheet1.Range("SYONIN_NAME120").Value = _V005_CAR_J.GOKI
            spSheet1.Range("SYONIN_YMD10").Value = _V005_CAR_J.GOKI
            spSheet1.Range("SYONIN_YMD20").Value = _V005_CAR_J.GOKI
            spSheet1.Range("SYONIN_YMD30").Value = _V005_CAR_J.GOKI
            spSheet1.Range("SYONIN_YMD40").Value = _V005_CAR_J.GOKI
            spSheet1.Range("SYONIN_YMD50").Value = _V005_CAR_J.GOKI
            spSheet1.Range("SYONIN_YMD60").Value = _V005_CAR_J.GOKI
            spSheet1.Range("SYONIN_YMD90").Value = _V005_CAR_J.GOKI
            spSheet1.Range("SYONIN_YMD100").Value = _V005_CAR_J.GOKI
            spSheet1.Range("SYONIN_YMD120").Value = _V005_CAR_J.GOKI
            spSheet1.Range(NameOf(_V005_CAR_J.SYOSAI_FILE_PATH)).Value = _V005_CAR_J.SYOSAI_FILE_PATH
            spSheet1.Range(NameOf(_V005_CAR_J.ZESEI_SYOCHI_YUKO_UMU_NAME)).Value = _V005_CAR_J.ZESEI_SYOCHI_YUKO_UMU_NAME

            '-----SpereasheetGera���
            Dim ssgPrintDocument As SpreadsheetGear.Drawing.Printing.WorkbookPrintDocument = New SpreadsheetGear.Drawing.Printing.WorkbookPrintDocument(spSheet1, SpreadsheetGear.Printing.PrintWhat.Sheet)
            'printDocument.PrinterSettings.PrinterName = "PrinterName"
            'ssgPrintDocument.Print()

            '-----�t�@�C���ۑ�
            'spWork.Delete()
            'spWorksheets(0).Cells("A1").Select()
            spSheet1.SaveAs(filename:=strFilePath, fileFormat:=SpreadsheetGear.FileFormat.OpenXMLWorkbook)
            spWorkbook.WorkbookSet.ReleaseLock()

            '-----Spire�� ����PDF���s����Ȃ炱����
            'Dim workbook As New Spire.Xls.Workbook
            'workbook.LoadFromFile(strFilePath)
            'Dim pdfFilePath As String
            'pdfFilePath = System.IO.Path.GetDirectoryName(strFilePath) & "\" & System.IO.Path.GetFileNameWithoutExtension(strFilePath) & ".pdf"
            'workbook.SaveToFile(pdfFilePath, Spire.Xls.FileFormat.PDF)

            ''Spire PDF�ҏW
            ''Dim pdfDoc As New Spire.Pdf.PdfDocument
            ''pdfDoc.PageSettings.Orientation = Spire.Pdf.PdfPageOrientation.Landscape
            ''pdfDoc.PageSettings.Width = "970"
            ''pdfDoc.PageSettings.Height = "850"

            ''PDF�\��
            'System.Diagnostics.Process.Start(pdfFilePath)

            'Excel��ƃt�@�C�����폜
            Try
                'System.IO.File.Delete(strFilePath)
            Catch ex As UnauthorizedAccessException
            End Try

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
                    If .Text.Length = 0 OrElse .Text.Substring(0, .Text.IndexOf("(")).Trim = "" Then
                        .Text = ""
                        .Visible = False
                    End If
                End With
            Next intFunc

            Dim dgv As DataGridView = DirectCast(Me.Controls("dgvDATA"), DataGridView)


            'SPEC: C10-3
            Select Case PrCurrentStage
                Case ENM_CAR_STAGE._10_�N������
                    cmdFunc5.Enabled = False
                    cmdFunc6.Enabled = False
                Case Else
                    cmdFunc5.Enabled = True
                    cmdFunc6.Enabled = True
            End Select


            Return True
        Catch ex As Exception
            EM.ErrorSyori(ex, False, conblnNonMsg)
            Return False
        End Try
    End Function

#End Region

#End Region

#Region "�R���g���[���C�x���g"

#Region "   �^�u��"

#Region "   1.������"

#End Region
#Region "   2.�v��"

    'SPEC: 10-1
    Private Sub cmbKONPON_YOIN_KB1_Validating(sender As Object, e As System.ComponentModel.CancelEventArgs) Handles cmbKONPON_YOIN_KB1.Validating
        'If _D005_CAR_J.
    End Sub

    Private Sub cmbKONPON_YOIN_KB2_Validating(sender As Object, e As System.ComponentModel.CancelEventArgs) Handles cmbKONPON_YOIN_KB2.Validating

    End Sub
#End Region
#Region "   3.���{����"

#End Region
#Region "   4.�C�����}���u"

#End Region
#Region "   5.�������u"

#End Region
#Region "   6.���u�����W�J"

#End Region
#Region "   7.�\������"

#End Region

#Region "   ���u���{�L�^"

#Region "       ����L�^"
    '�t�@�C���I��
    Private Sub btnOpenKYOIKU_FILE_PATH_Click(sender As Object, e As EventArgs) Handles btnOpenKYOIKU_FILE_PATH.Click
        Dim ofd As New OpenFileDialog With {
            .Filter = "Excel(*.xls;*.xlsx)|*.xls;*.xlsx|Word(*.doc;*.docx)|*.doc;*.docx|���ׂẴt�@�C��(*.*)|*.*",
            .FilterIndex = 1,
            .Title = "�Y�t����t�@�C����I�����Ă�������",
            .RestoreDirectory = True
        }
        If lblKYOIKU_FILE_PATH.Links.Count = 0 Then
        Else
            ofd.InitialDirectory = IO.Path.GetDirectoryName(lblKYOIKU_FILE_PATH.Links(0).ToString)
        End If
        If ofd.ShowDialog() = DialogResult.OK Then
            lblKYOIKU_FILE_PATH.Text = IO.Path.GetFileName(ofd.FileName)
            lblKYOIKU_FILE_PATH.Links.Clear()
            lblKYOIKU_FILE_PATH.Links.Add(0, lblKYOIKU_FILE_PATH.Text.Length, ofd.FileName)

            _D003_NCR_J.FILE_PATH = ofd.FileName
            'lbltmpFile1.Tag = ofd.FileName
            lblKYOIKU_FILE_PATH.Visible = True
            lblKYOIKU_FILE_PATH_Clear.Visible = True
        End If
    End Sub

    '�����N�N���b�N
    Private Sub lblKYOIKU_FILE_PATH_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles lblKYOIKU_FILE_PATH.LinkClicked
        Dim hProcess As New System.Diagnostics.Process
        Dim strEXE As String
        'Dim strARG As String
        Try

            strEXE = lblKYOIKU_FILE_PATH.Links(0).LinkData
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
    Private Sub lblKYOIKU_FILE_PATH_Clear_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles lblKYOIKU_FILE_PATH_Clear.LinkClicked
        lblKYOIKU_FILE_PATH.Text = ""
        lblKYOIKU_FILE_PATH.Tag = ""
        lblKYOIKU_FILE_PATH.Links.Clear()
        lblKYOIKU_FILE_PATH.Visible = False
        lblKYOIKU_FILE_PATH_Clear.Visible = False
    End Sub

    Private Sub ProcessExited(ByVal sender As Object, ByVal e As EventArgs)
        'Call SetTaskbarOverlayIcon(Nothing)
        'Call SetTaskbarInfo(ENM_TASKBAR_STATE._0_NoProgress)
    End Sub
#End Region

#End Region
#Region "   �������u�L�������r���["

#Region "       �ڍ׎���"
    '�t�@�C���I��
    Private Sub BtnOpenSYOSAI_FILE_PATH_Click(sender As Object, e As EventArgs) Handles btnOpenSYOSAI_FILE_PATH.Click
        Dim ofd As New OpenFileDialog With {
            .Filter = "Excel(*.xls;*.xlsx)|*.xls;*.xlsx|Word(*.doc;*.docx)|*.doc;*.docx|���ׂẴt�@�C��(*.*)|*.*",
            .FilterIndex = 1,
            .Title = "�Y�t����t�@�C����I�����Ă�������",
            .RestoreDirectory = True
        }
        If lblSYOSAI_FILE_PATH.Links.Count = 0 Then
        Else
            ofd.InitialDirectory = IO.Path.GetDirectoryName(lblSYOSAI_FILE_PATH.Links(0).ToString)
        End If
        If ofd.ShowDialog() = DialogResult.OK Then
            lblSYOSAI_FILE_PATH.Text = IO.Path.GetFileName(ofd.FileName)
            lblSYOSAI_FILE_PATH.Links.Clear()
            lblSYOSAI_FILE_PATH.Links.Add(0, lblSYOSAI_FILE_PATH.Text.Length, ofd.FileName)

            _D005_CAR_J.KYOIKU_FILE_PATH = ofd.FileName
            lblSYOSAI_FILE_PATH.Visible = True
            lblSYOSAI_FILE_PATH_Clear.Visible = True
        End If
    End Sub

    '�����N�N���b�N
    Private Sub LblSYOSAI_FILE_PATH_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles lblSYOSAI_FILE_PATH.LinkClicked
        Dim hProcess As New System.Diagnostics.Process
        Dim strEXE As String
        'Dim strARG As String
        Try

            strEXE = lblSYOSAI_FILE_PATH.Links(0).LinkData
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
    Private Sub LblSYOSAI_FILE_PATH_Clear_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles lblSYOSAI_FILE_PATH_Clear.LinkClicked
        lblKYOIKU_FILE_PATH.Text = ""
        lblKYOIKU_FILE_PATH.Tag = ""
        lblKYOIKU_FILE_PATH.Links.Clear()
        lblKYOIKU_FILE_PATH.Visible = False
        lblKYOIKU_FILE_PATH_Clear.Visible = False
    End Sub
#End Region

#End Region
#Region "   �Y�t����"

#Region "       �Y�t����1"
    '�t�@�C���I��
    Private Sub BtnOpentmpFile1_Click(sender As Object, e As EventArgs) Handles btnOpentmpFile1.Click
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

            _D005_CAR_J.FILE_PATH1 = ofd.FileName
            lbltmpFile1.Visible = True
            lbltmpFile1_Clear.Visible = True
        End If
    End Sub

    '�����N�N���b�N
    Private Sub lbltmpFile1_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles lbltmpFile1.LinkClicked
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

#End Region
#Region "       �Y�t����2"
    '�t�@�C���I��
    Private Sub btnOpentmpFile2_Click(sender As Object, e As EventArgs) Handles btnOpentmpFile2.Click
        Dim ofd As New OpenFileDialog With {
            .Filter = "Excel(*.xls;*.xlsx)|*.xls;*.xlsx|Word(*.doc;*.docx)|*.doc;*.docx|���ׂẴt�@�C��(*.*)|*.*",
            .FilterIndex = 1,
            .Title = "�Y�t����t�@�C����I�����Ă�������",
            .RestoreDirectory = True
        }
        If lbltmpFile2.Links.Count = 0 Then
        Else
            ofd.InitialDirectory = IO.Path.GetDirectoryName(lbltmpFile2.Links(0).ToString)
        End If
        If ofd.ShowDialog() = DialogResult.OK Then
            lbltmpFile2.Text = IO.Path.GetFileName(ofd.FileName)
            lbltmpFile2.Links.Clear()
            lbltmpFile2.Links.Add(0, lbltmpFile2.Text.Length, ofd.FileName)

            _D005_CAR_J.FILE_PATH2 = ofd.FileName
            'lbltmpFile1.Tag = ofd.FileName
            lbltmpFile2.Visible = True
            lbltmpFile2_Clear.Visible = True
        End If
    End Sub

    '�����N�N���b�N
    Private Sub lbltmpFile2_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles lbltmpFile2.LinkClicked
        Dim hProcess As New System.Diagnostics.Process
        Dim strEXE As String
        'Dim strARG As String
        Try

            strEXE = lbltmpFile2.Links(0).LinkData
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
    Private Sub lbltmpFile2_Clear_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles lbltmpFile2_Clear.LinkClicked
        lbltmpFile2.Text = ""
        lbltmpFile2.Tag = ""
        lbltmpFile2.Links.Clear()
        lbltmpFile2.Visible = False
        lbltmpFile2_Clear.Visible = False
    End Sub
#End Region

#End Region

#End Region


#End Region


#Region "���[�J���֐�"

    Private Function FunSetBinding() As Boolean

        Try

            '�X�V���Ȃ����̂̓o�C���h���Ȃ����̂Ƃ���

            '�w�b�_
            mtxHOKUKO_NO.DataBindings.Add(New Binding(NameOf(mtxHOKUKO_NO.Text), _D005_CAR_J, NameOf(_D005_CAR_J.HOKOKU_NO), False, DataSourceUpdateMode.OnPropertyChanged, ""))
            'mtxKISYU.DataBindings.Add(New Binding(NameOf(mtxKISYU.Text), _D005_CAR_J, NameOf(_D005_CAR_J.ki), False, DataSourceUpdateMode.OnPropertyChanged))
            'mtxADD_SYAIN_NAME.DataBindings.Add(New Binding(NameOf(mtxADD_SYAIN_NAME.Text), _D005_CAR_J, NameOf(_D005_CAR_J.HOKOKU_NO), False, DataSourceUpdateMode.OnPropertyChanged))
            'mtxCurrentStageName.DataBindings.Add(New Binding(NameOf(mtxCurrentStageName.Text), _D005_CAR_J, NameOf(_D005_CAR_J.HOKOKU_NO), False, DataSourceUpdateMode.OnPropertyChanged))

            '������
            txtKAITO_1.DataBindings.Add(New Binding(NameOf(txtKAITO_1.Text), _D005_CAR_J, NameOf(_D005_CAR_J.KAITO_1), False, DataSourceUpdateMode.OnPropertyChanged, ""))
            'mtxFUTEKIGO_KB.DataBindings.Add(New Binding(NameOf(mtxFUTEKIGO_KB.Text), _D005_CAR_J, NameOf(_D005_CAR_J), False, DataSourceUpdateMode.OnPropertyChanged))
            'mtxFUTEKIGO_S_KB.DataBindings.Add(New Binding(NameOf(mtxFUTEKIGO_S_KB.Text), _D005_CAR_J, NameOf(_D005_CAR_J.HOKOKU_NO), False, DataSourceUpdateMode.OnPropertyChanged))

            '�v��
            txtKAITO_2.DataBindings.Add(New Binding(NameOf(txtKAITO_2.Text), _D005_CAR_J, NameOf(_D005_CAR_J.KAITO_2), False, DataSourceUpdateMode.OnPropertyChanged, ""))
            cmbKONPON_YOIN_KB1.DataBindings.Add(New Binding(NameOf(cmbKONPON_YOIN_KB1.SelectedValue), _D005_CAR_J, NameOf(_D005_CAR_J.KONPON_YOIN_KB1), False, DataSourceUpdateMode.OnPropertyChanged, ""))
            cmbKONPON_YOIN_KB2.DataBindings.Add(New Binding(NameOf(cmbKONPON_YOIN_KB2.SelectedValue), _D005_CAR_J, NameOf(_D005_CAR_J.KONPON_YOIN_KB2), False, DataSourceUpdateMode.OnPropertyChanged, ""))
            cmbKONPON_YOIN_TANTO.DataBindings.Add(New Binding(NameOf(cmbKONPON_YOIN_TANTO.SelectedValue), _D005_CAR_J, NameOf(_D005_CAR_J.KONPON_YOIN_SYAIN_ID), False, DataSourceUpdateMode.OnPropertyChanged, 0))

            '���{����
            txtKAITO_3.DataBindings.Add(New Binding(NameOf(txtKAITO_3.Text), _D005_CAR_J, NameOf(_D005_CAR_J.KAITO_3), False, DataSourceUpdateMode.OnPropertyChanged, ""))
            'cmbGENIN1.DataBindings.Add(New Binding(NameOf(cmbGENIN1.SelectedValue), _D005_CAR_J, NameOf(_D005_CAR_J), False, DataSourceUpdateMode.OnPropertyChanged))
            'cmbGENIN2.DataBindings.Add(New Binding(NameOf(cmbGENIN2.SelectedValue), _D005_CAR_J, NameOf(_D005_CAR_J.HOKOKU_NO), False, DataSourceUpdateMode.OnPropertyChanged))
            cmbKISEKI_KOTEI.DataBindings.Add(New Binding(NameOf(cmbKISEKI_KOTEI.SelectedValue), _D005_CAR_J, NameOf(_D005_CAR_J.KISEKI_KOTEI_KB), False, DataSourceUpdateMode.OnPropertyChanged, ""))

            '�C���E���}���u
            dtKAITO_4.DataBindings.Add(New Binding(NameOf(dtKAITO_4.ValueNonFormat), _D005_CAR_J, NameOf(_D005_CAR_J.KAITO_4), False, DataSourceUpdateMode.OnPropertyChanged, ""))
            cmbKAITO_5.DataBindings.Add(New Binding(NameOf(cmbKAITO_5.SelectedValue), _D005_CAR_J, NameOf(_D005_CAR_J.KAITO_5), False, DataSourceUpdateMode.OnPropertyChanged, 0))
            cmbKAITO_6.DataBindings.Add(New Binding(NameOf(cmbKAITO_6.SelectedValue), _D005_CAR_J, NameOf(_D005_CAR_J.KAITO_6), False, DataSourceUpdateMode.OnPropertyChanged, ""))
            mtxKAITO_7.DataBindings.Add(New Binding(NameOf(mtxKAITO_7.Text), _D005_CAR_J, NameOf(_D005_CAR_J.KAITO_7), False, DataSourceUpdateMode.OnPropertyChanged, 0))
            dtKAITO_8.DataBindings.Add(New Binding(NameOf(dtKAITO_8.ValueNonFormat), _D005_CAR_J, NameOf(_D005_CAR_J.KAITO_7), False, DataSourceUpdateMode.OnPropertyChanged, ""))

            '�������u
            dtKAITO_9.DataBindings.Add(New Binding(NameOf(dtKAITO_9.ValueNonFormat), _D005_CAR_J, NameOf(_D005_CAR_J.KAITO_9), False, DataSourceUpdateMode.OnPropertyChanged, ""))
            cmbKAITO_10.DataBindings.Add(New Binding(NameOf(cmbKAITO_10.SelectedValue), _D005_CAR_J, NameOf(_D005_CAR_J.KAITO_10), False, DataSourceUpdateMode.OnPropertyChanged, 0))
            cmbKAITO_11.DataBindings.Add(New Binding(NameOf(cmbKAITO_11.SelectedValue), _D005_CAR_J, NameOf(_D005_CAR_J.KAITO_11), False, DataSourceUpdateMode.OnPropertyChanged, ""))
            mtxKAITO_12.DataBindings.Add(New Binding(NameOf(mtxKAITO_12.Text), _D005_CAR_J, NameOf(_D005_CAR_J.KAITO_12), False, DataSourceUpdateMode.OnPropertyChanged, 0))
            dtKAITO_13.DataBindings.Add(New Binding(NameOf(dtKAITO_13.ValueNonFormat), _D005_CAR_J, NameOf(_D005_CAR_J.KAITO_13), False, DataSourceUpdateMode.OnPropertyChanged, ""))

            '���u�����W�J
            cmbKAITO_14.DataBindings.Add(New Binding(NameOf(cmbKAITO_14.SelectedValue), _D005_CAR_J, NameOf(_D005_CAR_J.KAITO_14), False, DataSourceUpdateMode.OnPropertyChanged, ""))
            mtxKAITO_15.DataBindings.Add(New Binding(NameOf(mtxKAITO_15.Text), _D005_CAR_J, NameOf(_D005_CAR_J.KAITO_15), False, DataSourceUpdateMode.OnPropertyChanged, ""))
            dtKAITO_16.DataBindings.Add(New Binding(NameOf(dtKAITO_16.ValueNonFormat), _D005_CAR_J, NameOf(_D005_CAR_J.KAITO_16), False, DataSourceUpdateMode.OnPropertyChanged, ""))
            cmbKAITO_17.DataBindings.Add(New Binding(NameOf(cmbKAITO_17.SelectedValue), _D005_CAR_J, NameOf(_D005_CAR_J.KAITO_17), False, DataSourceUpdateMode.OnPropertyChanged, 0))
            cmbKAITO_18.DataBindings.Add(New Binding(NameOf(cmbKAITO_18.SelectedValue), _D005_CAR_J, NameOf(_D005_CAR_J.KAITO_18), False, DataSourceUpdateMode.OnPropertyChanged, ""))
            mtxKAITO_19.DataBindings.Add(New Binding(NameOf(mtxKAITO_19.Text), _D005_CAR_J, NameOf(_D005_CAR_J.KAITO_19), False, DataSourceUpdateMode.OnPropertyChanged, ""))
            dtKAITO_20.DataBindings.Add(New Binding(NameOf(dtKAITO_20.ValueNonFormat), _D005_CAR_J, NameOf(_D005_CAR_J.KAITO_20), False, DataSourceUpdateMode.OnPropertyChanged, ""))

            '���u���{�L�^
            cmbSYOCHI_A_TANTO.DataBindings.Add(New Binding(NameOf(cmbSYOCHI_A_TANTO.SelectedValue), _D005_CAR_J, NameOf(_D005_CAR_J.SYOCHI_A_SYAIN_ID), False, DataSourceUpdateMode.OnPropertyChanged, 0))
            cmbSYOCHI_B_TANTO.DataBindings.Add(New Binding(NameOf(cmbSYOCHI_B_TANTO.SelectedValue), _D005_CAR_J, NameOf(_D005_CAR_J.SYOCHI_B_SYAIN_ID), False, DataSourceUpdateMode.OnPropertyChanged, 0))
            cmbSYOCHI_C_TANTO.DataBindings.Add(New Binding(NameOf(cmbSYOCHI_C_TANTO.SelectedValue), _D005_CAR_J, NameOf(_D005_CAR_J.SYOCHI_C_SYAIN_ID), False, DataSourceUpdateMode.OnPropertyChanged, 0))
            dtSYOCHI_A_YMD.DataBindings.Add(New Binding(NameOf(dtSYOCHI_A_YMD.ValueNonFormat), _D005_CAR_J, NameOf(_D005_CAR_J.SYOCHI_A_YMDHNS), False, DataSourceUpdateMode.OnPropertyChanged, ""))
            dtSYOCHI_B_YMD.DataBindings.Add(New Binding(NameOf(dtSYOCHI_B_YMD.ValueNonFormat), _D005_CAR_J, NameOf(_D005_CAR_J.SYOCHI_B_YMDHNS), False, DataSourceUpdateMode.OnPropertyChanged, ""))
            dtSYOCHI_C_YMD.DataBindings.Add(New Binding(NameOf(dtSYOCHI_C_YMD.ValueNonFormat), _D005_CAR_J, NameOf(_D005_CAR_J.SYOCHI_C_YMDHNS), False, DataSourceUpdateMode.OnPropertyChanged, ""))
            lblKYOIKU_FILE_PATH.DataBindings.Add(New Binding(NameOf(lblKYOIKU_FILE_PATH.Tag), _D005_CAR_J, NameOf(_D005_CAR_J.KYOIKU_FILE_PATH), False, DataSourceUpdateMode.OnPropertyChanged, ""))

            '�������u�L�������r���[
            chkZESEI_SYOCHI_YUKO_UMU.DataBindings.Add(New Binding(NameOf(chkZESEI_SYOCHI_YUKO_UMU.Checked), _D005_CAR_J, NameOf(_D005_CAR_J.ZESEI_SYOCHI_YUKO_UMU), False, DataSourceUpdateMode.OnPropertyChanged, False))
            mtxGOKI.DataBindings.Add(New Binding(NameOf(mtxGOKI.Text), _D005_CAR_J, NameOf(_D005_CAR_J.GOKI), False, DataSourceUpdateMode.OnPropertyChanged, ""))
            mtxLOT.DataBindings.Add(New Binding(NameOf(mtxLOT.Text), _D005_CAR_J, NameOf(_D005_CAR_J.LOT), False, DataSourceUpdateMode.OnPropertyChanged, 0))
            lblSYOSAI_FILE_PATH.DataBindings.Add(New Binding(NameOf(lblSYOSAI_FILE_PATH.Tag), _D005_CAR_J, NameOf(_D005_CAR_J.SYOSAI_FILE_PATH), False, DataSourceUpdateMode.OnPropertyChanged, ""))
            cmbKENSA_TANTO.DataBindings.Add(New Binding(NameOf(cmbKENSA_TANTO.SelectedValue), _D005_CAR_J, NameOf(_D005_CAR_J.KENSA_TANTO_ID), False, DataSourceUpdateMode.OnPropertyChanged, 0))
            cmbKENSA_GL_TANTO.DataBindings.Add(New Binding(NameOf(cmbKENSA_GL_TANTO.SelectedValue), _D005_CAR_J, NameOf(_D005_CAR_J.KENSA_GL_SYAIN_ID), False, DataSourceUpdateMode.OnPropertyChanged, 0))
            dtKENSA_TOROKU.DataBindings.Add(New Binding(NameOf(dtKENSA_TOROKU.ValueNonFormat), _D005_CAR_J, NameOf(_D005_CAR_J.KENSA_TOROKU_YMDHNS), False, DataSourceUpdateMode.OnPropertyChanged, ""))
            dtKENSA_GL_TOROKU.DataBindings.Add(New Binding(NameOf(dtKENSA_GL_TOROKU.ValueNonFormat), _D005_CAR_J, NameOf(_D005_CAR_J.KENSA_GL_YMDHNS), False, DataSourceUpdateMode.OnPropertyChanged, ""))

            '�Y�t����
            lbltmpFile1.DataBindings.Add(New Binding(NameOf(lbltmpFile1.Tag), _D005_CAR_J, NameOf(_D005_CAR_J.FILE_PATH1), False, DataSourceUpdateMode.OnPropertyChanged, ""))
            lbltmpFile2.DataBindings.Add(New Binding(NameOf(lbltmpFile2.Tag), _D005_CAR_J, NameOf(_D005_CAR_J.FILE_PATH2), False, DataSourceUpdateMode.OnPropertyChanged, ""))

            Return True

        Catch ex As Exception
            Throw
            Return False
        End Try
    End Function


#Region "�������[�h�ʉ�ʏ�����"
    Private Function FunInitializeControls() As Boolean

        Try
            If FunSetBinding() Then
            Else
                Return False
            End If

            If FunSetSETUMON_NAIYO() Then
            Else
                Return False
            End If

            If FunSetModel() Then
            Else
                Return False
            End If

            mtxKISYU.Text = _V002_NCR_J.KISYU_NAME
            mtxADD_SYAIN_NAME.Text = _V005_CAR_J.SYONIN_NAME10
            mtxFUTEKIGO_KB.Text = _V002_NCR_J.FUTEKIGO_NAME
            mtxFUTEKIGO_S_KB.Text = _V002_NCR_J.FUTEKIGO_S_NAME
            mtxCurrentStageName.Text = FunGetLastStageName(ENM_SYONIN_HOKOKUSYO_ID._2_CAR, _V005_CAR_J.HOKOKU_NO)


            PrCurrentStage = PrDataRow.Item("SYONIN_JUN")

            'SPEC: C10-2.�C
            Select Case PrCurrentStage
                Case ENM_CAR_STAGE._10_�N������ To ENM_CAR_STAGE._70_�N���m�F_�i�؉ے�
                    tabCAR_SUB_1.Enabled = False
                    tabCAR_SUB_2.Enabled = False
                Case Else

            End Select

            Return True

        Catch ex As Exception
            EM.ErrorSyori(ex, False, conblnNonMsg)
            Return False
        End Try
    End Function


    Private Function FunSetSETUMON_NAIYO() As Boolean
        Try


            lblSETUMON_1.Text = tblSETUMON_NAIYO.AsEnumerable.Where(Function(r) r.Field(Of String)("VALUE") = 1).First.Item("DISP")
            lblSETUMON_2.Text = tblSETUMON_NAIYO.AsEnumerable.Where(Function(r) r.Field(Of String)("VALUE") = 2).First.Item("DISP")
            lblSETUMON_3.Text = tblSETUMON_NAIYO.AsEnumerable.Where(Function(r) r.Field(Of String)("VALUE") = 3).First.Item("DISP")
            lblSETUMON_4.Text = tblSETUMON_NAIYO.AsEnumerable.Where(Function(r) r.Field(Of String)("VALUE") = 4).First.Item("DISP")
            lblSETUMON_5.Text = tblSETUMON_NAIYO.AsEnumerable.Where(Function(r) r.Field(Of String)("VALUE") = 5).First.Item("DISP")
            lblSETUMON_6.Text = tblSETUMON_NAIYO.AsEnumerable.Where(Function(r) r.Field(Of String)("VALUE") = 6).First.Item("DISP")
            lblSETUMON_7.Text = tblSETUMON_NAIYO.AsEnumerable.Where(Function(r) r.Field(Of String)("VALUE") = 7).First.Item("DISP")
            lblSETUMON_8.Text = tblSETUMON_NAIYO.AsEnumerable.Where(Function(r) r.Field(Of String)("VALUE") = 8).First.Item("DISP")
            lblSETUMON_9.Text = tblSETUMON_NAIYO.AsEnumerable.Where(Function(r) r.Field(Of String)("VALUE") = 9).First.Item("DISP")
            lblSETUMON_10.Text = tblSETUMON_NAIYO.AsEnumerable.Where(Function(r) r.Field(Of String)("VALUE") = 10).First.Item("DISP")
            lblSETUMON_11.Text = tblSETUMON_NAIYO.AsEnumerable.Where(Function(r) r.Field(Of String)("VALUE") = 11).First.Item("DISP")
            lblSETUMON_12.Text = tblSETUMON_NAIYO.AsEnumerable.Where(Function(r) r.Field(Of String)("VALUE") = 12).First.Item("DISP")
            lblSETUMON_13.Text = tblSETUMON_NAIYO.AsEnumerable.Where(Function(r) r.Field(Of String)("VALUE") = 13).First.Item("DISP")
            lblSETUMON_14.Text = tblSETUMON_NAIYO.AsEnumerable.Where(Function(r) r.Field(Of String)("VALUE") = 14).First.Item("DISP")
            lblSETUMON_15.Text = tblSETUMON_NAIYO.AsEnumerable.Where(Function(r) r.Field(Of String)("VALUE") = 15).First.Item("DISP")
            lblSETUMON_16.Text = tblSETUMON_NAIYO.AsEnumerable.Where(Function(r) r.Field(Of String)("VALUE") = 16).First.Item("DISP")
            lblSETUMON_17.Text = tblSETUMON_NAIYO.AsEnumerable.Where(Function(r) r.Field(Of String)("VALUE") = 17).First.Item("DISP")
            lblSETUMON_18.Text = tblSETUMON_NAIYO.AsEnumerable.Where(Function(r) r.Field(Of String)("VALUE") = 18).First.Item("DISP")
            lblSETUMON_19.Text = tblSETUMON_NAIYO.AsEnumerable.Where(Function(r) r.Field(Of String)("VALUE") = 19).First.Item("DISP")
            lblSETUMON_20.Text = tblSETUMON_NAIYO.AsEnumerable.Where(Function(r) r.Field(Of String)("VALUE") = 20).First.Item("DISP")

            Return True
        Catch ex As Exception
            EM.ErrorSyori(ex, False, conblnNonMsg)
            Return False
        End Try
    End Function

    Private Function FunSetModel() As Boolean
        Try
            Dim sbSQL As New System.Text.StringBuilder
            Dim dsList As New DataSet

            _V002_NCR_J.Clear()
            _V002_NCR_J = FunGetV002Model(PrDataRow.Item("HOKOKU_NO"))

            _D005_CAR_J.Clear()
            _V005_CAR_J = FunGetV005Model(PrDataRow.Item("HOKOKU_NO"))

            'sbSQL.Remove(0, sbSQL.Length)
            'sbSQL.Append("SELECT")
            'sbSQL.Append(" *")
            'sbSQL.Append(" FROM V005_CAR_J")
            'sbSQL.Append(" WHERE HOKOKU_NO='" & PrHOKOKU_NO & "'")
            'Using DBa As ClsDbUtility = DBOpen()
            '    dsList = DBa.GetDataSet(sbSQL.ToString, conblnNonMsg)
            'End Using

            'If dsList.Tables(0).Rows.Count > 0 Then
            '    With dsList.Tables(0).Rows(0)
            _D005_CAR_J.HOKOKU_NO = _V005_CAR_J.HOKOKU_NO
            _D005_CAR_J.BUMON_KB = _V005_CAR_J.BUMON_KB
            _D005_CAR_J.CLOSE_FG = _V005_CAR_J.CLOSE_FG

            _D005_CAR_J.SETUMON_1 = _V005_CAR_J.SETUMON_1
            _D005_CAR_J.KAITO_1 = _V005_CAR_J.KAITO_1
            _D005_CAR_J.SETUMON_2 = _V005_CAR_J.SETUMON_2
            _D005_CAR_J.KAITO_2 = _V005_CAR_J.KAITO_2
            _D005_CAR_J.SETUMON_3 = _V005_CAR_J.SETUMON_3
            _D005_CAR_J.KAITO_3 = _V005_CAR_J.KAITO_3
            _D005_CAR_J.SETUMON_4 = _V005_CAR_J.SETUMON_4
            _D005_CAR_J.KAITO_4 = _V005_CAR_J.KAITO_4
            _D005_CAR_J.SETUMON_5 = _V005_CAR_J.SETUMON_5
            _D005_CAR_J.KAITO_5 = _V005_CAR_J.KAITO_5
            _D005_CAR_J.SETUMON_6 = _V005_CAR_J.SETUMON_6
            _D005_CAR_J.KAITO_6 = _V005_CAR_J.KAITO_6
            _D005_CAR_J.SETUMON_7 = _V005_CAR_J.SETUMON_7
            _D005_CAR_J.KAITO_7 = _V005_CAR_J.KAITO_7
            _D005_CAR_J.SETUMON_8 = _V005_CAR_J.SETUMON_8
            _D005_CAR_J.KAITO_8 = _V005_CAR_J.KAITO_8
            _D005_CAR_J.SETUMON_9 = _V005_CAR_J.SETUMON_9
            _D005_CAR_J.KAITO_9 = _V005_CAR_J.KAITO_9
            _D005_CAR_J.SETUMON_10 = _V005_CAR_J.SETUMON_10
            _D005_CAR_J.KAITO_10 = _V005_CAR_J.KAITO_10
            _D005_CAR_J.SETUMON_11 = _V005_CAR_J.SETUMON_11
            _D005_CAR_J.KAITO_11 = _V005_CAR_J.KAITO_11
            _D005_CAR_J.SETUMON_12 = _V005_CAR_J.SETUMON_12
            _D005_CAR_J.KAITO_12 = _V005_CAR_J.KAITO_12
            _D005_CAR_J.SETUMON_13 = _V005_CAR_J.SETUMON_13
            _D005_CAR_J.KAITO_13 = _V005_CAR_J.KAITO_13
            _D005_CAR_J.SETUMON_14 = _V005_CAR_J.SETUMON_14
            _D005_CAR_J.KAITO_14 = _V005_CAR_J.KAITO_14
            _D005_CAR_J.SETUMON_15 = _V005_CAR_J.SETUMON_15
            _D005_CAR_J.KAITO_15 = _V005_CAR_J.KAITO_15
            _D005_CAR_J.SETUMON_16 = _V005_CAR_J.SETUMON_16
            _D005_CAR_J.KAITO_16 = _V005_CAR_J.KAITO_16
            _D005_CAR_J.SETUMON_17 = _V005_CAR_J.SETUMON_17
            _D005_CAR_J.KAITO_17 = _V005_CAR_J.KAITO_17
            _D005_CAR_J.SETUMON_18 = _V005_CAR_J.SETUMON_18
            _D005_CAR_J.KAITO_18 = _V005_CAR_J.KAITO_18
            _D005_CAR_J.SETUMON_19 = _V005_CAR_J.SETUMON_19
            _D005_CAR_J.KAITO_19 = _V005_CAR_J.KAITO_19
            _D005_CAR_J.SETUMON_20 = _V005_CAR_J.SETUMON_20
            _D005_CAR_J.KAITO_20 = _V005_CAR_J.KAITO_20
            _D005_CAR_J.SETUMON_21 = _V005_CAR_J.SETUMON_21
            _D005_CAR_J.KAITO_21 = _V005_CAR_J.KAITO_21
            _D005_CAR_J.SETUMON_22 = _V005_CAR_J.SETUMON_22
            _D005_CAR_J.KAITO_22 = _V005_CAR_J.KAITO_22
            _D005_CAR_J.SETUMON_23 = _V005_CAR_J.SETUMON_23
            _D005_CAR_J.KAITO_23 = _V005_CAR_J.KAITO_23
            _D005_CAR_J.SETUMON_24 = _V005_CAR_J.SETUMON_24
            _D005_CAR_J.KAITO_24 = _V005_CAR_J.KAITO_24
            _D005_CAR_J.SETUMON_25 = _V005_CAR_J.SETUMON_25
            _D005_CAR_J.KAITO_25 = _V005_CAR_J.KAITO_25

            _D005_CAR_J.KONPON_YOIN_KB1 = _V005_CAR_J.KONPON_YOIN_KB1
            _D005_CAR_J.KONPON_YOIN_KB2 = _V005_CAR_J.KONPON_YOIN_KB2
            _D005_CAR_J.KONPON_YOIN_SYAIN_ID = _V005_CAR_J.KONPON_YOIN_SYAIN_ID
            _D005_CAR_J.KISEKI_KOTEI_KB = _V005_CAR_J.KISEKI_KOTEI_KB
            _D005_CAR_J.SYOCHI_A_SYAIN_ID = _V005_CAR_J.SYOCHI_A_SYAIN_ID
            _D005_CAR_J.SYOCHI_A_YMDHNS = _V005_CAR_J.SYOCHI_A_YMDHNS
            _D005_CAR_J.SYOCHI_B_SYAIN_ID = _V005_CAR_J.SYOCHI_B_SYAIN_ID
            _D005_CAR_J.SYOCHI_B_YMDHNS = _V005_CAR_J.SYOCHI_B_YMDHNS
            _D005_CAR_J.SYOCHI_C_SYAIN_ID = _V005_CAR_J.SYOCHI_C_SYAIN_ID
            _D005_CAR_J.SYOCHI_C_YMDHNS = _V005_CAR_J.SYOCHI_C_YMDHNS
            _D005_CAR_J.KYOIKU_FILE_PATH = _V005_CAR_J.KYOIKU_FILE_PATH
            _D005_CAR_J.ZESEI_SYOCHI_YUKO_UMU = _V005_CAR_J.ZESEI_SYOCHI_YUKO_UMU
            _D005_CAR_J.SYOSAI_FILE_PATH = _V005_CAR_J.SYOSAI_FILE_PATH
            _D005_CAR_J.GOKI = _V005_CAR_J.GOKI
            _D005_CAR_J.LOT = _V005_CAR_J.LOT
            _D005_CAR_J.KENSA_TANTO_ID = _V005_CAR_J.KENSA_TANTO_ID
            _D005_CAR_J.KENSA_TOROKU_YMDHNS = _V005_CAR_J.KENSA_TOROKU_YMDHNS
            _D005_CAR_J.KENSA_GL_SYAIN_ID = _V005_CAR_J.KENSA_GL_SYAIN_ID
            _D005_CAR_J.KENSA_GL_YMDHNS = _V005_CAR_J.KENSA_GL_YMDHNS
            _D005_CAR_J.ADD_SYAIN_ID = _V005_CAR_J.ADD_SYAIN_ID
            _D005_CAR_J.ADD_YMDHNS = _V005_CAR_J.ADD_YMDHNS
            _D005_CAR_J.UPD_SYAIN_ID = _V005_CAR_J.UPD_SYAIN_ID
            _D005_CAR_J.UPD_YMDHNS = _V005_CAR_J.UPD_YMDHNS
            _D005_CAR_J.DEL_SYAIN_ID = _V005_CAR_J.DEL_SYAIN_ID
            _D005_CAR_J.DEL_YMDHNS = _V005_CAR_J.DEL_YMDHNS
            '    End With
            'Else
            '    'Error
            '    MessageBox.Show("�Y���񍐏�No�̃f�[�^�����܂�܂���ł����B" & vbCrLf & "�񍐏�No=" & PrHOKOKU_NO, "�Y���f�[�^�Ȃ�", MessageBoxButtons.OK, MessageBoxIcon.Error)
            '    Return False
            'End If


            '�������͋敪
            _D006_CAR_GENIN_List.Clear()

            sbSQL.Remove(0, sbSQL.Length)
            sbSQL.Append("SELECT")
            sbSQL.Append(" *")
            sbSQL.Append(" FROM V006_CAR_GENIN")
            sbSQL.Append(" WHERE HOKOKU_NO='" & PrDataRow.Item("HOKOKU_NO") & "'")
            sbSQL.Append(" ORDER BY RENBAN")
            Using DB As ClsDbUtility = DBOpen()
                dsList = DB.GetDataSet(sbSQL.ToString, conblnNonMsg)
            End Using

            For Each row As DataRow In dsList.Tables(0).Rows
                _D006_CAR_GENIN_List.Add(New MODEL.D006_CAR_GENIN With {.HOKOKU_NO = dsList.Tables(0).Rows(0).Item(NameOf(.HOKOKU_NO)),
                                                                       .RENBAN = dsList.Tables(0).Rows(0).Item(NameOf(.RENBAN)),
                                                                       .GENIN_BUNSEKI_KB = dsList.Tables(0).Rows(0).Item(NameOf(.GENIN_BUNSEKI_KB)),
                                                                       .GENIN_BUNSEKI_S_KB = dsList.Tables(0).Rows(0).Item(NameOf(.GENIN_BUNSEKI_S_KB)),
                                                                       .DAIHYO_FG = dsList.Tables(0).Rows(0).Item(NameOf(.DAIHYO_FG)),
                                                                       .ADD_SYAIN_ID = dsList.Tables(0).Rows(0).Item(NameOf(.ADD_SYAIN_ID)),
                                                                       .ADD_YMDHNS = dsList.Tables(0).Rows(0).Item(NameOf(.ADD_YMDHNS))})
            Next row


            Return True

        Catch ex As Exception
            EM.ErrorSyori(ex, False, conblnNonMsg)
            Return False
        End Try
    End Function

#End Region

#Region "���̓`�F�b�N"
    Private Function FunCheckInput(ByVal enmSAVE_MODE As ENM_SAVE_MODE) As Boolean
        Try

            '-----����
            'Call CmbBUMON_Validating(cmbBUMON, Nothing)
            'Call CmbKISYU_Validating(cmbKISYU, Nothing)
            'Call CmbBUHIN_BANGO_Validating(cmbBUHIN_BANGO, Nothing)

            'Call MtxGOUKI_Validating(mtxGOUKI, Nothing)
            ''Call CmbFUTEKIGO_STATUS_Validating(cmbFUTEKIGO_STATUS, Nothing)
            ''Call MtxFUTEKIGO_NAIYO_Validating(mtxHENKYAKU_RIYU, Nothing)
            ''Call CmbFUTEKIGO_KB_Validating(cmbFUTEKIGO_KB, Nothing)
            ''Call CmbFUTEKIGO_S_KB_Validating(cmbFUTEKIGO_S_KB, Nothing)
            'Call MtxZUBAN_KIKAKU_Validating(mtxZUBAN_KIKAKU, Nothing)

            If enmSAVE_MODE = ENM_SAVE_MODE._2_���F�\�� Then
                '-----�X�e�[�W��
                Select Case PrCurrentStage


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


    Private Function FunGetLastStageName(ByVal intSYONIN_HOKOKUSYO_ID As Integer, ByVal strHOKOKU_NO As String) As String
        Dim sbSQL As New System.Text.StringBuilder
        Dim dsList As New DataSet

        sbSQL.Remove(0, sbSQL.Length)
        sbSQL.Append("SELECT")
        sbSQL.Append(" *")
        sbSQL.Append(" FROM " & NameOf(MODEL.V003_SYONIN_J_KANRI) & " ")
        sbSQL.Append(" WHERE SYONIN_HOKOKUSYO_ID=" & intSYONIN_HOKOKUSYO_ID & "")
        sbSQL.Append(" AND HOKOKU_NO='" & strHOKOKU_NO.Trim & "'")
        sbSQL.Append(" ORDER BY SYONIN_JUN DESC")
        Using DB As ClsDbUtility = DBOpen()
            dsList = DB.GetDataSet(sbSQL.ToString, conblnNonMsg)
        End Using

        With dsList.Tables(0)
            If .Rows.Count = 0 Then
                Return ""
            Else
                Return .Rows(0).Item("SYONIN_JUN") & "." & .Rows(0).Item("SYONIN_NAIYO")
            End If
        End With
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

#End Region


End Class