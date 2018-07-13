Imports JMS_COMMON.ClsPubMethod

''' <summary>
''' CAR�o�^���
''' </summary>
Public Class FrmG0012

#Region "�萔�E�ϐ�"
    Private _V002_NCR_J As New MODEL.V002_NCR_J
    Private _V003_SYONIN_J_KANRI_List As New List(Of MODEL.V003_SYONIN_J_KANRI)
    Private _V005_CAR_J As New MODEL.V005_CAR_J
    Private _D006_CAR_GENIN As New MODEL.D006_CAR_GENIN

    '���͕K�{�R���g���[�����ؔ���
    Private pri_blnValidated As Boolean

    Private _tabPageManager As TabPageManager
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

    ''' <summary>
    ''' CAR�������� ����1
    ''' </summary>
    ''' <returns></returns>
    Public Property PrGenin1 As New List(Of (ITEM_NAME As String, ITEM_VALUE As String, ITEM_DISP As String))

    ''' <summary>
    ''' CAR�������� ����2
    ''' </summary>
    ''' <returns></returns>
    Public Property PrGenin2 As New List(Of (ITEM_NAME As String, ITEM_VALUE As String, ITEM_DISP As String))

    'NCR�ҏW��ʂ���J����Ă��邩
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
        Me.Icon = My.Resources._icoAppForm32x32
        Me.ShowIcon = True

        '�c�[���`�b�v���b�Z�[�W
        MyBase.ToolTip.SetToolTip(Me.cmdFunc3, My.Resources.infoToolTipMsgNotFoundData)
        MyBase.ToolTip.SetToolTip(Me.cmdFunc4, My.Resources.infoToolTipMsgNotFoundData)
        MyBase.ToolTip.SetToolTip(Me.cmdFunc5, My.Resources.infoToolTipMsgNotFoundData)
        MyBase.ToolTip.SetToolTip(Me.cmdFunc10, My.Resources.infoToolTipMsgNotFoundData)

        cmbDestTANTO.NullValue = 0
        cmbKAITO_5.NullValue = 0
        cmbKAITO_10.NullValue = 0
        cmbKAITO_17.NullValue = 0
        cmbKONPON_YOIN_TANTO.NullValue = 0

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

            cmbKISEKI_KOTEI.SetDataSource(tblKISEKI_KOUTEI_KB, ENM_COMBO_SELECT_VALUE_TYPE._0_Required)
            cmbKAITO_14.SetDataSource(tblYOHI_KB, ENM_COMBO_SELECT_VALUE_TYPE._0_Required)

            '-----��ʏ�����
            Call FunInitializeControls()
        Finally
            FunInitFuncButtonEnabled()
        End Try
    End Sub

    'Shown
    Private Sub Frm_Shown(sender As Object, e As EventArgs) Handles MyBase.Shown
        Me.Owner.Visible = False
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
                    '�\����^�u�ɐ؂�ւ�
                    TabSTAGE.SelectedIndex = 6

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

                Case 3  'NCR
                    Call OpenFormNCR()

                Case 4  '�]��
                    Call OpenFormTENSO()
                Case 5  '�����߂�
                    Call OpenFormSASIMODOSI()

                Case 10  '���

                    Call FunOpenReportCAR()

                Case 11 '����
                    Call OpenFormHistory(ENM_SYONIN_HOKOKUSYO_ID._2_CAR, _V005_CAR_J.HOKOKU_NO)

                Case 12 '����
                    Me.Close()
                Case Else
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
                        'Case ENM_CAR_STAGE._120_�����L�����m�F_�i��TL, ENM_CAR_STAGE._130_�����L�����m�F_�i�ؒS���ے�
                        '�X�V���Ȃ�
                        Case Else
                            'SPEC: 2.(3).D.�@.���R�[�h�X�V
                            If FunSAVE_D005(DB) Then
                            Else
                                blnErr = True
                                Return False
                            End If
                            If FunSAVE_D006(DB) Then
                            Else
                                blnErr = True
                                Return False
                            End If

                            If FunSAVE_FILE(DB) Then
                            Else
                                blnErr = True
                                Return False
                            End If
                    End Select

                    '
                    If FunSAVE_D004(DB, enmSAVE_MODE) Then
                    Else
                        blnErr = True
                        Return False
                    End If


                    '
                    If FunSAVE_R001(DB, enmSAVE_MODE) Then
                    Else
                        blnErr = True
                        Return False
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
    ''' CAR�Y�t�t�@�C���ۑ�
    ''' </summary>
    ''' <param name="DB"></param>
    ''' <returns></returns>
    Private Function FunSAVE_FILE(ByRef DB As ClsDbUtility) As Boolean

        If _D005_CAR_J.KYOIKU_FILE_PATH.IsNullOrWhiteSpace And
            _D005_CAR_J.SYOSAI_FILE_PATH.IsNullOrWhiteSpace And
            _D005_CAR_J.FILE_PATH1.IsNullOrWhiteSpace And
            _D005_CAR_J.FILE_PATH2.IsNullOrWhiteSpace Then
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
                    System.IO.Directory.CreateDirectory(strRootDir & _D005_CAR_J.HOKOKU_NO)
                    If Not _D005_CAR_J.KYOIKU_FILE_PATH.IsNullOrWhiteSpace AndAlso Not System.IO.File.Exists(strRootDir & _D005_CAR_J.HOKOKU_NO.Trim & "\" & _D005_CAR_J.KYOIKU_FILE_PATH) Then
                        System.IO.File.Copy(lblKYOIKU_FILE_PATH.Links.Item(0).LinkData, strRootDir & _D005_CAR_J.HOKOKU_NO.Trim & "\" & _D005_CAR_J.KYOIKU_FILE_PATH, True)
                    End If
                    If Not _D005_CAR_J.SYOSAI_FILE_PATH.IsNullOrWhiteSpace AndAlso Not System.IO.File.Exists(strRootDir & _D005_CAR_J.HOKOKU_NO.Trim & "\" & _D005_CAR_J.SYOSAI_FILE_PATH) Then
                        System.IO.File.Copy(lblSYOSAI_FILE_PATH.Links.Item(0).LinkData, strRootDir & _D005_CAR_J.HOKOKU_NO.Trim & "\" & _D005_CAR_J.SYOSAI_FILE_PATH, True)
                    End If
                    If Not _D005_CAR_J.FILE_PATH1.IsNullOrWhiteSpace AndAlso Not System.IO.File.Exists(strRootDir & _D005_CAR_J.HOKOKU_NO.Trim & "\" & _D005_CAR_J.FILE_PATH1) Then
                        System.IO.File.Copy(lbltmpFile1.Links.Item(0).LinkData, strRootDir & _D005_CAR_J.HOKOKU_NO.Trim & "\" & _D005_CAR_J.FILE_PATH1, True)
                    End If
                    If Not _D005_CAR_J.FILE_PATH2.IsNullOrWhiteSpace AndAlso Not System.IO.File.Exists(strRootDir & _D005_CAR_J.HOKOKU_NO.Trim & "\" & _D005_CAR_J.FILE_PATH2) Then
                        System.IO.File.Copy(lbltmpFile2.Links.Item(0).LinkData, strRootDir & _D005_CAR_J.HOKOKU_NO.Trim & "\" & _D005_CAR_J.FILE_PATH2, True)
                    End If

                    Return True

                Catch exIO As UnauthorizedAccessException
                    strMsg = "�Y�t�t�@�C���ۑ���̃A�N�Z�X����������܂���B" & vbCrLf &
                             "�Y�t�t�@�C���ۑ���:" & strRootDir
                    MessageBox.Show(strMsg, "�t�@�C���ۑ���A�N�Z�X�s��", MessageBoxButtons.OK, MessageBoxIcon.Error)
                    Return False
                Catch ex As Exception
                    Throw
                    Return False
                End Try
            End If
        End If
    End Function

    ''' <summary>
    ''' CAR���эX�V
    ''' </summary>
    ''' <param name="DB"></param>
    ''' <returns></returns>
    Private Function FunSAVE_D005(ByRef DB As ClsDbUtility) As Boolean
        Dim sbSQL As New System.Text.StringBuilder
        Dim strRET As String
        Dim sqlEx As New Exception

        '���f���X�V
        Select Case PrCurrentStage
            Case ENM_CAR_STAGE._130_�����L�����m�F_�i�ؒS���ے�
                _D005_CAR_J._CLOSE_FG = 1
            Case Else

        End Select

        '-----MERGE
        sbSQL.Remove(0, sbSQL.Length)
        sbSQL.Append("MERGE INTO " & NameOf(MODEL.D005_CAR_J) & " AS SrcT")
        sbSQL.Append(" USING (")
        sbSQL.Append(" SELECT")
        sbSQL.Append(" '" & _D005_CAR_J.HOKOKU_NO & "' AS " & NameOf(_D005_CAR_J.HOKOKU_NO))
        sbSQL.Append(" ,'" & _D005_CAR_J.BUMON_KB & "' AS " & NameOf(_D005_CAR_J.BUMON_KB))
        sbSQL.Append(" ,'" & _D005_CAR_J._CLOSE_FG & "' AS " & NameOf(_D005_CAR_J.CLOSE_FG))
        sbSQL.Append(" ,'" & _D005_CAR_J.SETUMON_1 & "' AS " & NameOf(_D005_CAR_J.SETUMON_1))
        sbSQL.Append(" ,'" & _D005_CAR_J.SETUMON_2 & "' AS " & NameOf(_D005_CAR_J.SETUMON_2))
        sbSQL.Append(" ,'" & _D005_CAR_J.SETUMON_3 & "' AS " & NameOf(_D005_CAR_J.SETUMON_3))
        sbSQL.Append(" ,'" & _D005_CAR_J.SETUMON_4 & "' AS " & NameOf(_D005_CAR_J.SETUMON_4))
        sbSQL.Append(" ,'" & _D005_CAR_J.SETUMON_5 & "' AS " & NameOf(_D005_CAR_J.SETUMON_5))
        sbSQL.Append(" ,'" & _D005_CAR_J.SETUMON_6 & "' AS " & NameOf(_D005_CAR_J.SETUMON_6))
        sbSQL.Append(" ,'" & _D005_CAR_J.SETUMON_7 & "' AS " & NameOf(_D005_CAR_J.SETUMON_7))
        sbSQL.Append(" ,'" & _D005_CAR_J.SETUMON_8 & "' AS " & NameOf(_D005_CAR_J.SETUMON_8))
        sbSQL.Append(" ,'" & _D005_CAR_J.SETUMON_9 & "' AS " & NameOf(_D005_CAR_J.SETUMON_9))
        sbSQL.Append(" ,'" & _D005_CAR_J.SETUMON_10 & "' AS " & NameOf(_D005_CAR_J.SETUMON_10))
        sbSQL.Append(" ,'" & _D005_CAR_J.SETUMON_11 & "' AS " & NameOf(_D005_CAR_J.SETUMON_11))
        sbSQL.Append(" ,'" & _D005_CAR_J.SETUMON_12 & "' AS " & NameOf(_D005_CAR_J.SETUMON_12))
        sbSQL.Append(" ,'" & _D005_CAR_J.SETUMON_13 & "' AS " & NameOf(_D005_CAR_J.SETUMON_13))
        sbSQL.Append(" ,'" & _D005_CAR_J.SETUMON_14 & "' AS " & NameOf(_D005_CAR_J.SETUMON_14))
        sbSQL.Append(" ,'" & _D005_CAR_J.SETUMON_15 & "' AS " & NameOf(_D005_CAR_J.SETUMON_15))
        sbSQL.Append(" ,'" & _D005_CAR_J.SETUMON_16 & "' AS " & NameOf(_D005_CAR_J.SETUMON_16))
        sbSQL.Append(" ,'" & _D005_CAR_J.SETUMON_17 & "' AS " & NameOf(_D005_CAR_J.SETUMON_17))
        sbSQL.Append(" ,'" & _D005_CAR_J.SETUMON_18 & "' AS " & NameOf(_D005_CAR_J.SETUMON_18))
        sbSQL.Append(" ,'" & _D005_CAR_J.SETUMON_19 & "' AS " & NameOf(_D005_CAR_J.SETUMON_19))
        sbSQL.Append(" ,'" & _D005_CAR_J.SETUMON_20 & "' AS " & NameOf(_D005_CAR_J.SETUMON_20))
        sbSQL.Append(" ,'" & _D005_CAR_J.SETUMON_21 & "' AS " & NameOf(_D005_CAR_J.SETUMON_21))
        sbSQL.Append(" ,'" & _D005_CAR_J.SETUMON_22 & "' AS " & NameOf(_D005_CAR_J.SETUMON_22))
        sbSQL.Append(" ,'" & _D005_CAR_J.SETUMON_23 & "' AS " & NameOf(_D005_CAR_J.SETUMON_23))
        sbSQL.Append(" ,'" & _D005_CAR_J.SETUMON_24 & "' AS " & NameOf(_D005_CAR_J.SETUMON_24))
        sbSQL.Append(" ,'" & _D005_CAR_J.SETUMON_25 & "' AS " & NameOf(_D005_CAR_J.SETUMON_25))

        sbSQL.Append(" ,'" & _D005_CAR_J.KAITO_1 & "' AS " & NameOf(_D005_CAR_J.KAITO_1))
        sbSQL.Append(" ,'" & _D005_CAR_J.KAITO_2 & "' AS " & NameOf(_D005_CAR_J.KAITO_2))
        sbSQL.Append(" ,'" & _D005_CAR_J.KAITO_3 & "' AS " & NameOf(_D005_CAR_J.KAITO_3))
        sbSQL.Append(" ,'" & _D005_CAR_J.KAITO_4 & "' AS " & NameOf(_D005_CAR_J.KAITO_4))
        sbSQL.Append(" ," & _D005_CAR_J.KAITO_5 & " AS " & NameOf(_D005_CAR_J.KAITO_5))
        sbSQL.Append(" ,'" & _D005_CAR_J.KAITO_6 & "' AS " & NameOf(_D005_CAR_J.KAITO_6))
        sbSQL.Append(" ,'" & _D005_CAR_J.KAITO_7 & "' AS " & NameOf(_D005_CAR_J.KAITO_7))
        sbSQL.Append(" ,'" & _D005_CAR_J.KAITO_8 & "' AS " & NameOf(_D005_CAR_J.KAITO_8))
        sbSQL.Append(" ,'" & _D005_CAR_J.KAITO_9 & "' AS " & NameOf(_D005_CAR_J.KAITO_9))
        sbSQL.Append(" ," & _D005_CAR_J.KAITO_10 & " AS " & NameOf(_D005_CAR_J.KAITO_10))
        sbSQL.Append(" ,'" & _D005_CAR_J.KAITO_11 & "' AS " & NameOf(_D005_CAR_J.KAITO_11))
        sbSQL.Append(" ,'" & _D005_CAR_J.KAITO_12 & "' AS " & NameOf(_D005_CAR_J.KAITO_12))
        sbSQL.Append(" ,'" & _D005_CAR_J.KAITO_13 & "' AS " & NameOf(_D005_CAR_J.KAITO_13))
        sbSQL.Append(" ,'" & _D005_CAR_J.KAITO_14 & "' AS " & NameOf(_D005_CAR_J.KAITO_14))
        sbSQL.Append(" ,'" & _D005_CAR_J.KAITO_15 & "' AS " & NameOf(_D005_CAR_J.KAITO_15))
        sbSQL.Append(" ,'" & _D005_CAR_J.KAITO_16 & "' AS " & NameOf(_D005_CAR_J.KAITO_16))
        sbSQL.Append(" ," & _D005_CAR_J.KAITO_17 & " AS " & NameOf(_D005_CAR_J.KAITO_17))
        sbSQL.Append(" ,'" & _D005_CAR_J.KAITO_18 & "' AS " & NameOf(_D005_CAR_J.KAITO_18))
        sbSQL.Append(" ,'" & _D005_CAR_J.KAITO_19 & "' AS " & NameOf(_D005_CAR_J.KAITO_19))
        sbSQL.Append(" ,'" & _D005_CAR_J.KAITO_20 & "' AS " & NameOf(_D005_CAR_J.KAITO_20))
        sbSQL.Append(" ,'" & _D005_CAR_J.KAITO_21 & "' AS " & NameOf(_D005_CAR_J.KAITO_21))
        sbSQL.Append(" ,'" & _D005_CAR_J.KAITO_22 & "' AS " & NameOf(_D005_CAR_J.KAITO_22))
        sbSQL.Append(" ,'" & _D005_CAR_J.KAITO_23 & "' AS " & NameOf(_D005_CAR_J.KAITO_23))
        sbSQL.Append(" ,'" & _D005_CAR_J.KAITO_24 & "' AS " & NameOf(_D005_CAR_J.KAITO_24))
        sbSQL.Append(" ,'" & _D005_CAR_J.KAITO_25 & "' AS " & NameOf(_D005_CAR_J.KAITO_25))

        sbSQL.Append(" ,'" & _D005_CAR_J.KONPON_YOIN_KB1 & "' AS " & NameOf(_D005_CAR_J.KONPON_YOIN_KB1))
        sbSQL.Append(" ,'" & _D005_CAR_J.KONPON_YOIN_KB2 & "' AS " & NameOf(_D005_CAR_J.KONPON_YOIN_KB2))
        sbSQL.Append(" ," & _D005_CAR_J.KONPON_YOIN_SYAIN_ID & " AS " & NameOf(_D005_CAR_J.KONPON_YOIN_SYAIN_ID))
        sbSQL.Append(" ,'" & _D005_CAR_J.KISEKI_KOTEI_KB & "' AS " & NameOf(_D005_CAR_J.KISEKI_KOTEI_KB))
        sbSQL.Append(" ," & _D005_CAR_J.SYOCHI_A_SYAIN_ID & " AS " & NameOf(_D005_CAR_J.SYOCHI_A_SYAIN_ID))
        sbSQL.Append(" ,'" & _D005_CAR_J.SYOCHI_A_YMDHNS & "' AS " & NameOf(_D005_CAR_J.SYOCHI_A_YMDHNS))
        sbSQL.Append(" ," & _D005_CAR_J.SYOCHI_B_SYAIN_ID & " AS " & NameOf(_D005_CAR_J.SYOCHI_B_SYAIN_ID))
        sbSQL.Append(" ,'" & _D005_CAR_J.SYOCHI_B_YMDHNS & "' AS " & NameOf(_D005_CAR_J.SYOCHI_B_YMDHNS))
        sbSQL.Append(" ," & _D005_CAR_J.SYOCHI_C_SYAIN_ID & " AS " & NameOf(_D005_CAR_J.SYOCHI_C_SYAIN_ID))
        sbSQL.Append(" ,'" & _D005_CAR_J.SYOCHI_C_YMDHNS & "' AS " & NameOf(_D005_CAR_J.SYOCHI_C_YMDHNS))
        sbSQL.Append(" ,'" & _D005_CAR_J.KYOIKU_FILE_PATH & "' AS " & NameOf(_D005_CAR_J.KYOIKU_FILE_PATH))
        sbSQL.Append(" ,'" & _D005_CAR_J._ZESEI_SYOCHI_YUKO_UMU & "' AS " & NameOf(_D005_CAR_J.ZESEI_SYOCHI_YUKO_UMU))
        sbSQL.Append(" ,'" & _D005_CAR_J.SYOSAI_FILE_PATH & "' AS " & NameOf(_D005_CAR_J.SYOSAI_FILE_PATH))
        sbSQL.Append(" ,'" & _D005_CAR_J.GOKI & "' AS " & NameOf(_D005_CAR_J.GOKI))
        sbSQL.Append(" ,'" & _D005_CAR_J.LOT & "' AS " & NameOf(_D005_CAR_J.LOT))
        sbSQL.Append(" ," & _D005_CAR_J.KENSA_TANTO_ID & " AS " & NameOf(_D005_CAR_J.KENSA_TANTO_ID))
        sbSQL.Append(" ,'" & _D005_CAR_J.KENSA_TOROKU_YMDHNS & "' AS " & NameOf(_D005_CAR_J.KENSA_TOROKU_YMDHNS))
        sbSQL.Append(" ," & _D005_CAR_J.KENSA_GL_SYAIN_ID & " AS " & NameOf(_D005_CAR_J.KENSA_GL_SYAIN_ID))
        sbSQL.Append(" ,'" & _D005_CAR_J.KENSA_GL_YMDHNS & "' AS " & NameOf(_D005_CAR_J.KENSA_GL_YMDHNS))
        sbSQL.Append(" ,'" & _D005_CAR_J.FILE_PATH1 & "' AS " & NameOf(_D005_CAR_J.FILE_PATH1))
        sbSQL.Append(" ,'" & _D005_CAR_J.FILE_PATH2 & "' AS " & NameOf(_D005_CAR_J.FILE_PATH2))
        sbSQL.Append(" ,'" & _D005_CAR_J.FUTEKIGO_HASSEI_YMD & "' AS " & NameOf(_D005_CAR_J.FUTEKIGO_HASSEI_YMD))
        sbSQL.Append(" ," & _D005_CAR_J.ADD_SYAIN_ID & " AS " & NameOf(_D005_CAR_J.ADD_SYAIN_ID))
        sbSQL.Append(" ,'" & _D005_CAR_J.ADD_YMDHNS & "' AS " & NameOf(_D005_CAR_J.ADD_YMDHNS))
        sbSQL.Append(" ," & _D005_CAR_J.UPD_SYAIN_ID & " AS " & NameOf(_D005_CAR_J.UPD_SYAIN_ID))
        sbSQL.Append(" ,'" & _D005_CAR_J.UPD_YMDHNS & "' AS " & NameOf(_D005_CAR_J.UPD_YMDHNS))
        sbSQL.Append(" ," & _D005_CAR_J.DEL_SYAIN_ID & " AS " & NameOf(_D005_CAR_J.DEL_SYAIN_ID))
        sbSQL.Append(" ,'" & _D005_CAR_J.DEL_YMDHNS & "' AS " & NameOf(_D005_CAR_J.DEL_YMDHNS))
        sbSQL.Append(" ) AS WK")
        sbSQL.Append(" ON (SrcT.HOKOKU_NO = WK.HOKOKU_NO)")
        'UPDATE
        sbSQL.Append(" WHEN MATCHED THEN")
        sbSQL.Append(" UPDATE SET")

        Select Case PrCurrentStage
            Case ENM_CAR_STAGE._10_�N������ To ENM_CAR_STAGE._70_�N���m�F_�i�؉ے�
                sbSQL.Append("  SrcT." & NameOf(_D005_CAR_J.SETUMON_1) & " = WK." & NameOf(_D005_CAR_J.SETUMON_1))
                sbSQL.Append(" ,SrcT." & NameOf(_D005_CAR_J.SETUMON_2) & " = WK." & NameOf(_D005_CAR_J.SETUMON_2))
                sbSQL.Append(" ,SrcT." & NameOf(_D005_CAR_J.SETUMON_3) & " = WK." & NameOf(_D005_CAR_J.SETUMON_3))
                sbSQL.Append(" ,SrcT." & NameOf(_D005_CAR_J.SETUMON_4) & " = WK." & NameOf(_D005_CAR_J.SETUMON_4))
                sbSQL.Append(" ,SrcT." & NameOf(_D005_CAR_J.SETUMON_5) & " = WK." & NameOf(_D005_CAR_J.SETUMON_5))
                sbSQL.Append(" ,SrcT." & NameOf(_D005_CAR_J.SETUMON_6) & " = WK." & NameOf(_D005_CAR_J.SETUMON_6))
                sbSQL.Append(" ,SrcT." & NameOf(_D005_CAR_J.SETUMON_7) & " = WK." & NameOf(_D005_CAR_J.SETUMON_7))
                sbSQL.Append(" ,SrcT." & NameOf(_D005_CAR_J.SETUMON_8) & " = WK." & NameOf(_D005_CAR_J.SETUMON_8))
                sbSQL.Append(" ,SrcT." & NameOf(_D005_CAR_J.SETUMON_9) & " = WK." & NameOf(_D005_CAR_J.SETUMON_9))
                sbSQL.Append(" ,SrcT." & NameOf(_D005_CAR_J.SETUMON_10) & " = WK." & NameOf(_D005_CAR_J.SETUMON_10))
                sbSQL.Append(" ,SrcT." & NameOf(_D005_CAR_J.SETUMON_11) & " = WK." & NameOf(_D005_CAR_J.SETUMON_11))
                sbSQL.Append(" ,SrcT." & NameOf(_D005_CAR_J.SETUMON_12) & " = WK." & NameOf(_D005_CAR_J.SETUMON_12))
                sbSQL.Append(" ,SrcT." & NameOf(_D005_CAR_J.SETUMON_13) & " = WK." & NameOf(_D005_CAR_J.SETUMON_13))
                sbSQL.Append(" ,SrcT." & NameOf(_D005_CAR_J.SETUMON_14) & " = WK." & NameOf(_D005_CAR_J.SETUMON_14))
                sbSQL.Append(" ,SrcT." & NameOf(_D005_CAR_J.SETUMON_15) & " = WK." & NameOf(_D005_CAR_J.SETUMON_15))
                sbSQL.Append(" ,SrcT." & NameOf(_D005_CAR_J.SETUMON_16) & " = WK." & NameOf(_D005_CAR_J.SETUMON_16))
                sbSQL.Append(" ,SrcT." & NameOf(_D005_CAR_J.SETUMON_17) & " = WK." & NameOf(_D005_CAR_J.SETUMON_17))
                sbSQL.Append(" ,SrcT." & NameOf(_D005_CAR_J.SETUMON_18) & " = WK." & NameOf(_D005_CAR_J.SETUMON_18))
                sbSQL.Append(" ,SrcT." & NameOf(_D005_CAR_J.SETUMON_19) & " = WK." & NameOf(_D005_CAR_J.SETUMON_19))
                sbSQL.Append(" ,SrcT." & NameOf(_D005_CAR_J.SETUMON_20) & " = WK." & NameOf(_D005_CAR_J.SETUMON_20))
                sbSQL.Append(" ,SrcT." & NameOf(_D005_CAR_J.SETUMON_21) & " = WK." & NameOf(_D005_CAR_J.SETUMON_21))
                sbSQL.Append(" ,SrcT." & NameOf(_D005_CAR_J.SETUMON_22) & " = WK." & NameOf(_D005_CAR_J.SETUMON_22))

                sbSQL.Append(" ,SrcT." & NameOf(_D005_CAR_J.KAITO_1) & " = WK." & NameOf(_D005_CAR_J.KAITO_1))
                sbSQL.Append(" ,SrcT." & NameOf(_D005_CAR_J.KAITO_2) & " = WK." & NameOf(_D005_CAR_J.KAITO_2))
                sbSQL.Append(" ,SrcT." & NameOf(_D005_CAR_J.KAITO_3) & " = WK." & NameOf(_D005_CAR_J.KAITO_3))
                sbSQL.Append(" ,SrcT." & NameOf(_D005_CAR_J.KAITO_4) & " = WK." & NameOf(_D005_CAR_J.KAITO_4))
                sbSQL.Append(" ,SrcT." & NameOf(_D005_CAR_J.KAITO_5) & " = WK." & NameOf(_D005_CAR_J.KAITO_5))
                sbSQL.Append(" ,SrcT." & NameOf(_D005_CAR_J.KAITO_6) & " = WK." & NameOf(_D005_CAR_J.KAITO_6))
                sbSQL.Append(" ,SrcT." & NameOf(_D005_CAR_J.KAITO_7) & " = WK." & NameOf(_D005_CAR_J.KAITO_7))
                sbSQL.Append(" ,SrcT." & NameOf(_D005_CAR_J.KAITO_8) & " = WK." & NameOf(_D005_CAR_J.KAITO_8))
                sbSQL.Append(" ,SrcT." & NameOf(_D005_CAR_J.KAITO_9) & " = WK." & NameOf(_D005_CAR_J.KAITO_9))
                sbSQL.Append(" ,SrcT." & NameOf(_D005_CAR_J.KAITO_10) & " = WK." & NameOf(_D005_CAR_J.KAITO_10))
                sbSQL.Append(" ,SrcT." & NameOf(_D005_CAR_J.KAITO_11) & " = WK." & NameOf(_D005_CAR_J.KAITO_11))
                sbSQL.Append(" ,SrcT." & NameOf(_D005_CAR_J.KAITO_12) & " = WK." & NameOf(_D005_CAR_J.KAITO_12))
                sbSQL.Append(" ,SrcT." & NameOf(_D005_CAR_J.KAITO_13) & " = WK." & NameOf(_D005_CAR_J.KAITO_13))
                sbSQL.Append(" ,SrcT." & NameOf(_D005_CAR_J.KAITO_14) & " = WK." & NameOf(_D005_CAR_J.KAITO_14))
                sbSQL.Append(" ,SrcT." & NameOf(_D005_CAR_J.KAITO_15) & " = WK." & NameOf(_D005_CAR_J.KAITO_15))
                sbSQL.Append(" ,SrcT." & NameOf(_D005_CAR_J.KAITO_16) & " = WK." & NameOf(_D005_CAR_J.KAITO_16))
                sbSQL.Append(" ,SrcT." & NameOf(_D005_CAR_J.KAITO_17) & " = WK." & NameOf(_D005_CAR_J.KAITO_17))
                sbSQL.Append(" ,SrcT." & NameOf(_D005_CAR_J.KAITO_18) & " = WK." & NameOf(_D005_CAR_J.KAITO_18))
                sbSQL.Append(" ,SrcT." & NameOf(_D005_CAR_J.KAITO_19) & " = WK." & NameOf(_D005_CAR_J.KAITO_19))
                sbSQL.Append(" ,SrcT." & NameOf(_D005_CAR_J.KAITO_20) & " = WK." & NameOf(_D005_CAR_J.KAITO_20))
                sbSQL.Append(" ,SrcT." & NameOf(_D005_CAR_J.KAITO_21) & " = WK." & NameOf(_D005_CAR_J.KAITO_21))
                sbSQL.Append(" ,SrcT." & NameOf(_D005_CAR_J.KAITO_22) & " = WK." & NameOf(_D005_CAR_J.KAITO_22))

                sbSQL.Append(" ,SrcT." & NameOf(_D005_CAR_J.KONPON_YOIN_KB1) & " = WK." & NameOf(_D005_CAR_J.KONPON_YOIN_KB1))
                sbSQL.Append(" ,SrcT." & NameOf(_D005_CAR_J.KONPON_YOIN_KB2) & " = WK." & NameOf(_D005_CAR_J.KONPON_YOIN_KB2))
                sbSQL.Append(" ,SrcT." & NameOf(_D005_CAR_J.KONPON_YOIN_SYAIN_ID) & " = WK." & NameOf(_D005_CAR_J.KONPON_YOIN_SYAIN_ID))
                sbSQL.Append(" ,SrcT." & NameOf(_D005_CAR_J.KISEKI_KOTEI_KB) & " = WK." & NameOf(_D005_CAR_J.KISEKI_KOTEI_KB))

                sbSQL.Append(" ,SrcT." & NameOf(_D005_CAR_J.FUTEKIGO_HASSEI_YMD) & " = WK." & NameOf(_D005_CAR_J.FUTEKIGO_HASSEI_YMD))

                sbSQL.Append(" ,SrcT." & NameOf(_D005_CAR_J.ADD_SYAIN_ID) & " = WK." & NameOf(_D005_CAR_J.ADD_SYAIN_ID))
                sbSQL.Append(" ,SrcT." & NameOf(_D005_CAR_J.ADD_YMDHNS) & " = WK." & NameOf(_D005_CAR_J.ADD_YMDHNS))

            Case ENM_CAR_STAGE._80_���u���{�L�^���� To ENM_CAR_STAGE._90_���u���{�m�F
                sbSQL.Append(" SrcT." & NameOf(_D005_CAR_J.SYOCHI_A_SYAIN_ID) & " = WK." & NameOf(_D005_CAR_J.SYOCHI_A_SYAIN_ID))
                sbSQL.Append(" ,SrcT." & NameOf(_D005_CAR_J.SYOCHI_A_YMDHNS) & " = WK." & NameOf(_D005_CAR_J.SYOCHI_A_YMDHNS))
                sbSQL.Append(" ,SrcT." & NameOf(_D005_CAR_J.SYOCHI_B_SYAIN_ID) & " = WK." & NameOf(_D005_CAR_J.SYOCHI_B_SYAIN_ID))
                sbSQL.Append(" ,SrcT." & NameOf(_D005_CAR_J.SYOCHI_B_YMDHNS) & " = WK." & NameOf(_D005_CAR_J.SYOCHI_B_YMDHNS))
                sbSQL.Append(" ,SrcT." & NameOf(_D005_CAR_J.SYOCHI_C_SYAIN_ID) & " = WK." & NameOf(_D005_CAR_J.SYOCHI_C_SYAIN_ID))
                sbSQL.Append(" ,SrcT." & NameOf(_D005_CAR_J.SYOCHI_C_YMDHNS) & " = WK." & NameOf(_D005_CAR_J.SYOCHI_C_YMDHNS))
                sbSQL.Append(" ,SrcT." & NameOf(_D005_CAR_J.KYOIKU_FILE_PATH) & " = WK." & NameOf(_D005_CAR_J.KYOIKU_FILE_PATH))

            Case ENM_CAR_STAGE._100_�����L�����L�� To ENM_CAR_STAGE._110_�����L�����m�F_����GL
                sbSQL.Append(" SrcT." & NameOf(_D005_CAR_J.ZESEI_SYOCHI_YUKO_UMU) & " = WK." & NameOf(_D005_CAR_J.ZESEI_SYOCHI_YUKO_UMU))
                sbSQL.Append(" ,SrcT." & NameOf(_D005_CAR_J.SYOSAI_FILE_PATH) & " = WK." & NameOf(_D005_CAR_J.SYOSAI_FILE_PATH))
                sbSQL.Append(" ,SrcT." & NameOf(_D005_CAR_J.GOKI) & " = WK." & NameOf(_D005_CAR_J.GOKI))
                sbSQL.Append(" ,SrcT." & NameOf(_D005_CAR_J.LOT) & " = WK." & NameOf(_D005_CAR_J.LOT))
                sbSQL.Append(" ,SrcT." & NameOf(_D005_CAR_J.KENSA_TANTO_ID) & " = WK." & NameOf(_D005_CAR_J.KENSA_TANTO_ID))
                sbSQL.Append(" ,SrcT." & NameOf(_D005_CAR_J.KENSA_TOROKU_YMDHNS) & " = WK." & NameOf(_D005_CAR_J.KENSA_TOROKU_YMDHNS))
                sbSQL.Append(" ,SrcT." & NameOf(_D005_CAR_J.KENSA_GL_SYAIN_ID) & " = WK." & NameOf(_D005_CAR_J.KENSA_GL_SYAIN_ID))
                sbSQL.Append(" ,SrcT." & NameOf(_D005_CAR_J.KENSA_GL_YMDHNS) & " = WK." & NameOf(_D005_CAR_J.KENSA_GL_YMDHNS))

            Case Else
                'Err
                Return False
        End Select

        sbSQL.Append(" ,SrcT." & NameOf(_D005_CAR_J.FILE_PATH1) & " = WK." & NameOf(_D005_CAR_J.FILE_PATH1))
        sbSQL.Append(" ,SrcT." & NameOf(_D005_CAR_J.FILE_PATH2) & " = WK." & NameOf(_D005_CAR_J.FILE_PATH2))
        sbSQL.Append(" ,SrcT." & NameOf(_D005_CAR_J.UPD_SYAIN_ID) & " = WK." & NameOf(_D005_CAR_J.UPD_SYAIN_ID))
        sbSQL.Append(" ,SrcT." & NameOf(_D005_CAR_J.UPD_YMDHNS) & " = WK." & NameOf(_D005_CAR_J.UPD_YMDHNS))
        sbSQL.Append(" ,SrcT." & NameOf(_D005_CAR_J.CLOSE_FG) & " = WK." & NameOf(_D005_CAR_J.CLOSE_FG))

        'INSERT
        sbSQL.Append(" WHEN NOT MATCHED THEN ")
        sbSQL.Append("INSERT(")
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
        sbSQL.Append(" ," & NameOf(_D005_CAR_J.FILE_PATH1))
        sbSQL.Append(" ," & NameOf(_D005_CAR_J.FILE_PATH2))
        sbSQL.Append(" ," & NameOf(_D005_CAR_J.FUTEKIGO_HASSEI_YMD))
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
        sbSQL.Append(" ," & _D005_CAR_J.KAITO_5 & "")
        sbSQL.Append(" ,'" & _D005_CAR_J.KAITO_6 & "'")
        sbSQL.Append(" ,'" & _D005_CAR_J.KAITO_7 & "'")
        sbSQL.Append(" ,'" & _D005_CAR_J.KAITO_8 & "'")
        sbSQL.Append(" ,'" & _D005_CAR_J.KAITO_9 & "'")
        sbSQL.Append(" ," & _D005_CAR_J.KAITO_10 & "")
        sbSQL.Append(" ,'" & _D005_CAR_J.KAITO_11 & "'")
        sbSQL.Append(" ,'" & _D005_CAR_J.KAITO_12 & "'")
        sbSQL.Append(" ,'" & _D005_CAR_J.KAITO_13 & "'")
        sbSQL.Append(" ,'" & _D005_CAR_J.KAITO_14 & "'")
        sbSQL.Append(" ,'" & _D005_CAR_J.KAITO_15 & "'")
        sbSQL.Append(" ,'" & _D005_CAR_J.KAITO_16 & "'")
        sbSQL.Append(" ," & _D005_CAR_J.KAITO_17 & "")
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
        sbSQL.Append(" ,'" & _D005_CAR_J.FILE_PATH1 & "'")
        sbSQL.Append(" ,'" & _D005_CAR_J.FILE_PATH2 & "'")
        sbSQL.Append(" ,'" & _D005_CAR_J.FUTEKIGO_HASSEI_YMD & "'")
        sbSQL.Append(" ," & _D005_CAR_J.ADD_SYAIN_ID & "")
        sbSQL.Append(" ,'" & _D005_CAR_J.ADD_YMDHNS & "'")
        sbSQL.Append(" ," & _D005_CAR_J.UPD_SYAIN_ID & "")
        sbSQL.Append(" ,'" & _D005_CAR_J.UPD_YMDHNS & "'")
        sbSQL.Append(" ," & _D005_CAR_J.DEL_SYAIN_ID & "")
        sbSQL.Append(" ,'" & _D005_CAR_J.DEL_YMDHNS & "'")
        sbSQL.Append(")")
        sbSQL.Append("OUTPUT $action AS RESULT")
        sbSQL.Append(";")
        strRET = DB.ExecuteScalar(sbSQL.ToString, conblnNonMsg, sqlEx)
        Select Case strRET
            Case "INSERT"
                'Error ���R�[�h�}����NCR40�Ŏ��{�̂͂�

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
        _D004_SYONIN_J_KANRI.SYONIN_HOKOKUSYO_ID = ENM_SYONIN_HOKOKUSYO_ID._2_CAR
        _D004_SYONIN_J_KANRI.HOKOKU_NO = _V005_CAR_J.HOKOKU_NO
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

        _D004_SYONIN_J_KANRI.ADD_YMDHNS = Now.ToString("yyyyMMddHHmmss")

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
                _D004_SYONIN_J_KANRI.SYAIN_ID = cmbDestTANTO.SelectedValue
                _D004_SYONIN_J_KANRI.SYONIN_YMDHNS = ""
                _D004_SYONIN_J_KANRI.MAIL_SEND_FG = False

            Case Else
                'Err
                Return False
        End Select

        '-----���f���X�V
        Select Case PrCurrentStage
            Case ENM_CAR_STAGE._130_�����L�����m�F_�i�ؒS���ے�
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
                If PrCurrentStage < ENM_CAR_STAGE._130_�����L�����m�F_�i�ؒS���ے� AndAlso _D004_SYONIN_J_KANRI.MAIL_SEND_FG = False Then
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

        If FunSAVE_R004(DB, _D004_SYONIN_J_KANRI.ADD_YMDHNS) Then
        Else
            Return False
        End If

        Return True
    End Function

    ''' <summary>
    ''' �s�K���������u�������͏��X�V
    ''' </summary>
    ''' <param name="DB"></param>
    ''' <returns></returns>
    Private Function FunSAVE_D006(ByRef DB As ClsDbUtility) As Boolean
        Dim sbSQL As New System.Text.StringBuilder
        Dim intRET As Integer
        Dim sqlEx As New Exception

        '-----DELETE
        sbSQL.Remove(0, sbSQL.Length)
        sbSQL.Append("DELETE FROM " & NameOf(MODEL.D006_CAR_GENIN) & "")
        sbSQL.Append(" WHERE HOKOKU_NO='" & _D005_CAR_J.HOKOKU_NO & "'")
        '-----SQL���s
        intRET = DB.ExecuteNonQuery(sbSQL.ToString, conblnNonMsg, sqlEx)
        If sqlEx.Source IsNot Nothing Then
            '-----�G���[���O�o��
            Dim strErrMsg As String = My.Resources.ErrLogSqlExecutionFailure & sbSQL.ToString & "|" & sqlEx.Message
            WL.WriteLogDat(strErrMsg)
            Return False
        End If

        For Each item In PrGenin1
            _D006_CAR_GENIN.Clear()

            '-----�f�[�^���f���X�V
            _D006_CAR_GENIN.HOKOKU_NO = _D005_CAR_J.HOKOKU_NO
            _D006_CAR_GENIN.RENBAN = 1
            _D006_CAR_GENIN.GENIN_BUNSEKI_KB = item.ITEM_NAME
            'If _D005_CAR_J.KONPON_YOIN_KB1 = 0 Then '0:�l
            _D006_CAR_GENIN.GENIN_BUNSEKI_S_KB = item.ITEM_VALUE
            'Else
            '    _D006_CAR_GENIN.GENIN_BUNSEKI_KB = item.ITEM_VALUE
            '    _D006_CAR_GENIN.GENIN_BUNSEKI_S_KB = " "
            'End If
            If mtxGENIN1.Text = item.ITEM_NAME & "," & item.ITEM_VALUE Then
                '��\
                _D006_CAR_GENIN._DAIHYO_FG = 1
            Else
                _D006_CAR_GENIN._DAIHYO_FG = 0
            End If
            _D006_CAR_GENIN.ADD_SYAIN_ID = pub_SYAIN_INFO.SYAIN_ID
            _D006_CAR_GENIN.ADD_YMDHNS = Now.ToString("yyyyMMddHHmmss")

            '-----INSERT
            sbSQL.Remove(0, sbSQL.Length)
            sbSQL.Append("INSERT INTO " & NameOf(MODEL.D006_CAR_GENIN) & "(")
            sbSQL.Append("  " & NameOf(_D006_CAR_GENIN.HOKOKU_NO))
            sbSQL.Append(" ," & NameOf(_D006_CAR_GENIN.RENBAN))
            sbSQL.Append(" ," & NameOf(_D006_CAR_GENIN.GENIN_BUNSEKI_KB))
            sbSQL.Append(" ," & NameOf(_D006_CAR_GENIN.GENIN_BUNSEKI_S_KB))
            sbSQL.Append(" ," & NameOf(_D006_CAR_GENIN.DAIHYO_FG))
            sbSQL.Append(" ," & NameOf(_D006_CAR_GENIN.ADD_SYAIN_ID))
            sbSQL.Append(" ," & NameOf(_D006_CAR_GENIN.ADD_YMDHNS))
            sbSQL.Append(" ) VALUES(")
            sbSQL.Append("  '" & _D006_CAR_GENIN.HOKOKU_NO & "'")
            sbSQL.Append(" ," & _D006_CAR_GENIN.RENBAN & "")
            sbSQL.Append(" ,'" & _D006_CAR_GENIN.GENIN_BUNSEKI_KB & "'")
            sbSQL.Append(" ,'" & _D006_CAR_GENIN.GENIN_BUNSEKI_S_KB & "'")
            sbSQL.Append(" ,'" & _D006_CAR_GENIN._DAIHYO_FG & "'")
            sbSQL.Append(" ," & _D006_CAR_GENIN.ADD_SYAIN_ID)
            sbSQL.Append(" ,'" & _D006_CAR_GENIN.ADD_YMDHNS & "'")
            sbSQL.Append(")")

            '-----SQL���s
            intRET = DB.ExecuteNonQuery(sbSQL.ToString, conblnNonMsg, sqlEx)
            If intRET <> 1 Then
                '-----�G���[���O�o��
                Dim strErrMsg As String = My.Resources.ErrLogSqlExecutionFailure & sbSQL.ToString & "|" & sqlEx.Message
                WL.WriteLogDat(strErrMsg)
                Return False
            End If
        Next item

        For Each item In PrGenin2
            _D006_CAR_GENIN.Clear()

            '-----�f�[�^���f���X�V
            _D006_CAR_GENIN.HOKOKU_NO = _D005_CAR_J.HOKOKU_NO
            _D006_CAR_GENIN.RENBAN = 2
            _D006_CAR_GENIN.GENIN_BUNSEKI_KB = item.ITEM_NAME
            'If _D005_CAR_J.KONPON_YOIN_KB2 = 0 Then '0:�l
            _D006_CAR_GENIN.GENIN_BUNSEKI_S_KB = item.ITEM_VALUE
            'Else
            '    _D006_CAR_GENIN.GENIN_BUNSEKI_KB = item.ITEM_VALUE
            '    _D006_CAR_GENIN.GENIN_BUNSEKI_S_KB = " "
            'End If
            If mtxGENIN2.Text = item.ITEM_NAME & "," & item.ITEM_VALUE Then
                '��\
                _D006_CAR_GENIN._DAIHYO_FG = 1
            Else
                _D006_CAR_GENIN._DAIHYO_FG = 0
            End If
            _D006_CAR_GENIN.ADD_SYAIN_ID = pub_SYAIN_INFO.SYAIN_ID
            _D006_CAR_GENIN.ADD_YMDHNS = Now.ToString("yyyyMMddHHmmss")

            '-----INSERT
            sbSQL.Remove(0, sbSQL.Length)
            sbSQL.Append("INSERT INTO " & NameOf(MODEL.D006_CAR_GENIN) & "(")
            sbSQL.Append("  " & NameOf(_D006_CAR_GENIN.HOKOKU_NO))
            sbSQL.Append(" ," & NameOf(_D006_CAR_GENIN.RENBAN))
            sbSQL.Append(" ," & NameOf(_D006_CAR_GENIN.GENIN_BUNSEKI_KB))
            sbSQL.Append(" ," & NameOf(_D006_CAR_GENIN.GENIN_BUNSEKI_S_KB))
            sbSQL.Append(" ," & NameOf(_D006_CAR_GENIN.DAIHYO_FG))
            sbSQL.Append(" ," & NameOf(_D006_CAR_GENIN.ADD_SYAIN_ID))
            sbSQL.Append(" ," & NameOf(_D006_CAR_GENIN.ADD_YMDHNS))
            sbSQL.Append(" ) VALUES(")
            sbSQL.Append("  '" & _D006_CAR_GENIN.HOKOKU_NO & "'")
            sbSQL.Append(" ," & _D006_CAR_GENIN.RENBAN & "")
            sbSQL.Append(" ,'" & _D006_CAR_GENIN.GENIN_BUNSEKI_KB & "'")
            sbSQL.Append(" ,'" & _D006_CAR_GENIN.GENIN_BUNSEKI_S_KB & "'")
            sbSQL.Append(" ,'" & _D006_CAR_GENIN._DAIHYO_FG & "'")
            sbSQL.Append(" ," & _D006_CAR_GENIN.ADD_SYAIN_ID)
            sbSQL.Append(" ,'" & _D006_CAR_GENIN.ADD_YMDHNS & "'")
            sbSQL.Append(")")

            '-----SQL���s
            intRET = DB.ExecuteNonQuery(sbSQL.ToString, conblnNonMsg, sqlEx)
            If intRET <> 1 Then
                '-----�G���[���O�o��
                Dim strErrMsg As String = My.Resources.ErrLogSqlExecutionFailure & sbSQL.ToString & "|" & sqlEx.Message
                WL.WriteLogDat(strErrMsg)
                Return False
            End If
        Next item

        Return True
    End Function

    ''' <summary>
    ''' ���F�˗����[�����M
    ''' </summary>
    ''' <returns></returns>
    Private Function FunSendRequestMail()
        Dim KISYU_NAME As String = _V002_NCR_J.KISYU_NAME
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

        strSubject = String.Format(strSubject, KISYU_NAME, _V002_NCR_J.BUHIN_BANGO)
        strBody = String.Format(strBody,
                                Fun_GetUSER_NAME(_D004_SYONIN_J_KANRI.SYAIN_ID),
                                _D004_SYONIN_J_KANRI.HOKOKU_NO,
                                FunGetCurrentStageName(ENM_SYONIN_HOKOKUSYO_ID._2_CAR, _D004_SYONIN_J_KANRI.SYONIN_JUN),
                                KISYU_NAME,
                                _V002_NCR_J.BUHIN_BANGO,
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
        _R001_HOKOKU_SOUSA.SYONIN_HOKOKUSYO_ID = ENM_SYONIN_HOKOKUSYO_ID._2_CAR
        _R001_HOKOKU_SOUSA.HOKOKU_NO = _V002_NCR_J.HOKOKU_NO
        _R001_HOKOKU_SOUSA.SYONIN_JUN = PrCurrentStage
        _R001_HOKOKU_SOUSA.SYAIN_ID = pub_SYAIN_INFO.SYAIN_ID
        'UNDONE: getsysdatetime
        _R001_HOKOKU_SOUSA.ADD_YMDHNS = Now.ToString("yyyyMMddHHmmss")


        Select Case enmSAVE_MODE
            Case ENM_SAVE_MODE._1_�ۑ�
                '�ǉ����Ȃ�
                Return True

            Case ENM_SAVE_MODE._2_���F�\��
                _R001_HOKOKU_SOUSA.SYONIN_HANTEI_KB = ENM_SYONIN_HANTEI_KB._1_���F
                _R001_HOKOKU_SOUSA.SOUSA_KB = ENM_HOKOKUSYO_SOUSA_KB._1_�\�����F�˗�
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
    Private Function FunSAVE_D005_(ByRef DB As ClsDbUtility) As Boolean
        Dim sbSQL As New System.Text.StringBuilder
        Dim intRET As Integer
        Dim sqlEx As New Exception

        '-----�f�[�^���f���X�V
        Dim _D005_CAR_J As New MODEL.D005_CAR_J
        _D005_CAR_J.HOKOKU_NO = _V002_NCR_J.HOKOKU_NO
        _D005_CAR_J.BUMON_KB = _V002_NCR_J.BUMON_KB

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
        sbSQL.Append(" ," & NameOf(_D005_CAR_J.FILE_PATH1))
        sbSQL.Append(" ," & NameOf(_D005_CAR_J.FILE_PATH2))
        sbSQL.Append(" ," & NameOf(_D005_CAR_J.FUTEKIGO_HASSEI_YMD))
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
        sbSQL.Append(" ,'" & _D005_CAR_J.FILE_PATH1 & "'")
        sbSQL.Append(" ,'" & _D005_CAR_J.FILE_PATH2 & "'")
        sbSQL.Append(" ,'" & _D005_CAR_J.FUTEKIGO_HASSEI_YMD & "'")
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
        _D004_SYONIN_J_KANRI.HOKOKU_NO = _V002_NCR_J.HOKOKU_NO
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
        sbSQL.Append("OUTPUT $action AS RESULT")
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

    Private Function FunSAVE_R004(ByRef DB As ClsDbUtility, ByVal strYMDHNS As String) As Boolean
        Dim sbSQL As New System.Text.StringBuilder
        Dim intRET As Integer
        Dim sqlEx As New Exception

        '-----MERGE
        sbSQL.Append(" INSERT INTO " & NameOf(MODEL.R004_CAR_SASIMODOSI) & "(")
        sbSQL.Append(" " & NameOf(_R004_CAR_SASIMODOSI.SASIMODOSI_YMDHNS))
        sbSQL.Append(" ," & NameOf(_R004_CAR_SASIMODOSI.HOKOKU_NO))
        sbSQL.Append(" ," & NameOf(_R004_CAR_SASIMODOSI.BUMON_KB))
        sbSQL.Append(" ," & NameOf(_R004_CAR_SASIMODOSI.CLOSE_FG))
        sbSQL.Append(" ," & NameOf(_R004_CAR_SASIMODOSI.SETUMON_1))
        sbSQL.Append(" ," & NameOf(_R004_CAR_SASIMODOSI.SETUMON_2))
        sbSQL.Append(" ," & NameOf(_R004_CAR_SASIMODOSI.SETUMON_3))
        sbSQL.Append(" ," & NameOf(_R004_CAR_SASIMODOSI.SETUMON_4))
        sbSQL.Append(" ," & NameOf(_R004_CAR_SASIMODOSI.SETUMON_5))
        sbSQL.Append(" ," & NameOf(_R004_CAR_SASIMODOSI.SETUMON_6))
        sbSQL.Append(" ," & NameOf(_R004_CAR_SASIMODOSI.SETUMON_7))
        sbSQL.Append(" ," & NameOf(_R004_CAR_SASIMODOSI.SETUMON_8))
        sbSQL.Append(" ," & NameOf(_R004_CAR_SASIMODOSI.SETUMON_9))
        sbSQL.Append(" ," & NameOf(_R004_CAR_SASIMODOSI.SETUMON_10))
        sbSQL.Append(" ," & NameOf(_R004_CAR_SASIMODOSI.SETUMON_11))
        sbSQL.Append(" ," & NameOf(_R004_CAR_SASIMODOSI.SETUMON_12))
        sbSQL.Append(" ," & NameOf(_R004_CAR_SASIMODOSI.SETUMON_13))
        sbSQL.Append(" ," & NameOf(_R004_CAR_SASIMODOSI.SETUMON_14))
        sbSQL.Append(" ," & NameOf(_R004_CAR_SASIMODOSI.SETUMON_15))
        sbSQL.Append(" ," & NameOf(_R004_CAR_SASIMODOSI.SETUMON_16))
        sbSQL.Append(" ," & NameOf(_R004_CAR_SASIMODOSI.SETUMON_17))
        sbSQL.Append(" ," & NameOf(_R004_CAR_SASIMODOSI.SETUMON_18))
        sbSQL.Append(" ," & NameOf(_R004_CAR_SASIMODOSI.SETUMON_19))
        sbSQL.Append(" ," & NameOf(_R004_CAR_SASIMODOSI.SETUMON_20))
        sbSQL.Append(" ," & NameOf(_R004_CAR_SASIMODOSI.SETUMON_21))
        sbSQL.Append(" ," & NameOf(_R004_CAR_SASIMODOSI.SETUMON_22))
        sbSQL.Append(" ," & NameOf(_R004_CAR_SASIMODOSI.SETUMON_23))
        sbSQL.Append(" ," & NameOf(_R004_CAR_SASIMODOSI.SETUMON_24))
        sbSQL.Append(" ," & NameOf(_R004_CAR_SASIMODOSI.SETUMON_25))
        sbSQL.Append(" ," & NameOf(_R004_CAR_SASIMODOSI.KAITO_1))
        sbSQL.Append(" ," & NameOf(_R004_CAR_SASIMODOSI.KAITO_2))
        sbSQL.Append(" ," & NameOf(_R004_CAR_SASIMODOSI.KAITO_3))
        sbSQL.Append(" ," & NameOf(_R004_CAR_SASIMODOSI.KAITO_4))
        sbSQL.Append(" ," & NameOf(_R004_CAR_SASIMODOSI.KAITO_5))
        sbSQL.Append(" ," & NameOf(_R004_CAR_SASIMODOSI.KAITO_6))
        sbSQL.Append(" ," & NameOf(_R004_CAR_SASIMODOSI.KAITO_7))
        sbSQL.Append(" ," & NameOf(_R004_CAR_SASIMODOSI.KAITO_8))
        sbSQL.Append(" ," & NameOf(_R004_CAR_SASIMODOSI.KAITO_9))
        sbSQL.Append(" ," & NameOf(_R004_CAR_SASIMODOSI.KAITO_10))
        sbSQL.Append(" ," & NameOf(_R004_CAR_SASIMODOSI.KAITO_11))
        sbSQL.Append(" ," & NameOf(_R004_CAR_SASIMODOSI.KAITO_12))
        sbSQL.Append(" ," & NameOf(_R004_CAR_SASIMODOSI.KAITO_13))
        sbSQL.Append(" ," & NameOf(_R004_CAR_SASIMODOSI.KAITO_14))
        sbSQL.Append(" ," & NameOf(_R004_CAR_SASIMODOSI.KAITO_15))
        sbSQL.Append(" ," & NameOf(_R004_CAR_SASIMODOSI.KAITO_16))
        sbSQL.Append(" ," & NameOf(_R004_CAR_SASIMODOSI.KAITO_17))
        sbSQL.Append(" ," & NameOf(_R004_CAR_SASIMODOSI.KAITO_18))
        sbSQL.Append(" ," & NameOf(_R004_CAR_SASIMODOSI.KAITO_19))
        sbSQL.Append(" ," & NameOf(_R004_CAR_SASIMODOSI.KAITO_20))
        sbSQL.Append(" ," & NameOf(_R004_CAR_SASIMODOSI.KAITO_21))
        sbSQL.Append(" ," & NameOf(_R004_CAR_SASIMODOSI.KAITO_22))
        sbSQL.Append(" ," & NameOf(_R004_CAR_SASIMODOSI.KAITO_23))
        sbSQL.Append(" ," & NameOf(_R004_CAR_SASIMODOSI.KAITO_24))
        sbSQL.Append(" ," & NameOf(_R004_CAR_SASIMODOSI.KAITO_25))
        sbSQL.Append(" ," & NameOf(_R004_CAR_SASIMODOSI.KONPON_YOIN_KB1))
        sbSQL.Append(" ," & NameOf(_R004_CAR_SASIMODOSI.KONPON_YOIN_KB2))
        sbSQL.Append(" ," & NameOf(_R004_CAR_SASIMODOSI.KONPON_YOIN_SYAIN_ID))
        sbSQL.Append(" ," & NameOf(_R004_CAR_SASIMODOSI.KISEKI_KOTEI_KB))
        sbSQL.Append(" ," & NameOf(_R004_CAR_SASIMODOSI.SYOCHI_A_SYAIN_ID))
        sbSQL.Append(" ," & NameOf(_R004_CAR_SASIMODOSI.SYOCHI_A_YMDHNS))
        sbSQL.Append(" ," & NameOf(_R004_CAR_SASIMODOSI.SYOCHI_B_SYAIN_ID))
        sbSQL.Append(" ," & NameOf(_R004_CAR_SASIMODOSI.SYOCHI_B_YMDHNS))
        sbSQL.Append(" ," & NameOf(_R004_CAR_SASIMODOSI.SYOCHI_C_SYAIN_ID))
        sbSQL.Append(" ," & NameOf(_R004_CAR_SASIMODOSI.SYOCHI_C_YMDHNS))
        sbSQL.Append(" ," & NameOf(_R004_CAR_SASIMODOSI.KYOIKU_FILE_PATH))
        sbSQL.Append(" ," & NameOf(_R004_CAR_SASIMODOSI.ZESEI_SYOCHI_YUKO_UMU))
        sbSQL.Append(" ," & NameOf(_R004_CAR_SASIMODOSI.SYOSAI_FILE_PATH))
        sbSQL.Append(" ," & NameOf(_R004_CAR_SASIMODOSI.GOKI))
        sbSQL.Append(" ," & NameOf(_R004_CAR_SASIMODOSI.LOT))
        sbSQL.Append(" ," & NameOf(_R004_CAR_SASIMODOSI.KENSA_TANTO_ID))
        sbSQL.Append(" ," & NameOf(_R004_CAR_SASIMODOSI.KENSA_TOROKU_YMDHNS))
        sbSQL.Append(" ," & NameOf(_R004_CAR_SASIMODOSI.KENSA_GL_SYAIN_ID))
        sbSQL.Append(" ," & NameOf(_R004_CAR_SASIMODOSI.KENSA_GL_YMDHNS))
        sbSQL.Append(" ," & NameOf(_R004_CAR_SASIMODOSI.FILE_PATH1))
        sbSQL.Append(" ," & NameOf(_R004_CAR_SASIMODOSI.FILE_PATH2))
        sbSQL.Append(" ," & NameOf(_R004_CAR_SASIMODOSI.FUTEKIGO_HASSEI_YMD))

        sbSQL.Append(" ) VALUES(")
        sbSQL.Append(" '" & strYMDHNS & "'")
        sbSQL.Append(" ,'" & _D005_CAR_J.HOKOKU_NO & "'")
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
        sbSQL.Append(" ,'" & _D005_CAR_J.KONPON_YOIN_SYAIN_ID & "'")
        sbSQL.Append(" ,'" & _D005_CAR_J.KISEKI_KOTEI_KB & "'")
        sbSQL.Append(" ,'" & _D005_CAR_J.SYOCHI_A_SYAIN_ID & "'")
        sbSQL.Append(" ,'" & _D005_CAR_J.SYOCHI_A_YMDHNS & "'")
        sbSQL.Append(" ,'" & _D005_CAR_J.SYOCHI_B_SYAIN_ID & "'")
        sbSQL.Append(" ,'" & _D005_CAR_J.SYOCHI_B_YMDHNS & "'")
        sbSQL.Append(" ,'" & _D005_CAR_J.SYOCHI_C_SYAIN_ID & "'")
        sbSQL.Append(" ,'" & _D005_CAR_J.SYOCHI_C_YMDHNS & "'")
        sbSQL.Append(" ,'" & _D005_CAR_J.KYOIKU_FILE_PATH & "'")
        sbSQL.Append(" ,'" & _D005_CAR_J._ZESEI_SYOCHI_YUKO_UMU & "'")
        sbSQL.Append(" ,'" & _D005_CAR_J.SYOSAI_FILE_PATH & "'")
        sbSQL.Append(" ,'" & _D005_CAR_J.GOKI & "'")
        sbSQL.Append(" ,'" & _D005_CAR_J.LOT & "'")
        sbSQL.Append(" ,'" & _D005_CAR_J.KENSA_TANTO_ID & "'")
        sbSQL.Append(" ,'" & _D005_CAR_J.KENSA_TOROKU_YMDHNS & "'")
        sbSQL.Append(" ,'" & _D005_CAR_J.KENSA_GL_SYAIN_ID & "'")
        sbSQL.Append(" ,'" & _D005_CAR_J.KENSA_GL_YMDHNS & "'")
        sbSQL.Append(" ,'" & _D005_CAR_J.FILE_PATH1 & "'")
        sbSQL.Append(" ,'" & _D005_CAR_J.FILE_PATH2 & "'")
        sbSQL.Append(" ,'" & _D005_CAR_J.FUTEKIGO_HASSEI_YMD & "'")
        sbSQL.Append(" );")
        intRET = DB.ExecuteNonQuery(sbSQL.ToString, conblnNonMsg, sqlEx)
        If intRET <> 1 Then
            '-----�G���[���O�o��
            Dim strErrMsg As String = My.Resources.ErrLogSqlExecutionFailure & sbSQL.ToString & "|" & sqlEx.Message
            WL.WriteLogDat(strErrMsg)
            Return False
        Else
            Return True
        End If
    End Function


#End Region

#Region "NCR"
    Private Function OpenFormNCR() As Boolean
        Dim frmDLG As New FrmG0011
        Dim dlgRET As DialogResult

        Try


            Dim sbSQL As New System.Text.StringBuilder
            Dim dsList As New DataSet

            sbSQL.Remove(0, sbSQL.Length)
            sbSQL.Append("SELECT")
            sbSQL.Append(" HOKOKU_NO,SYONIN_JUN")
            sbSQL.Append(" FROM " & NameOf(MODEL.V007_NCR_CAR) & " ")
            sbSQL.Append(" WHERE SYONIN_HOKOKUSYO_ID=" & ENM_SYONIN_HOKOKUSYO_ID._1_NCR & "")
            sbSQL.Append(" AND HOKOKU_NO='" & _D005_CAR_J.HOKOKU_NO & "'")
            Using DB As ClsDbUtility = DBOpen()
                dsList = DB.GetDataSet(sbSQL.ToString, conblnNonMsg)
            End Using

            frmDLG.PrMODE = ENM_DATA_OPERATION_MODE._3_UPDATE
            frmDLG.PrDialog = True
            frmDLG.PrCurrentStage = dsList.Tables(0).Rows(0).Item("SYONIN_JUN")
            frmDLG.PrHOKOKU_NO = dsList.Tables(0).Rows(0).Item("HOKOKU_NO")


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
            frmDLG.PrSYONIN_HOKOKUSYO_ID = ENM_SYONIN_HOKOKUSYO_ID._2_CAR
            frmDLG.PrHOKOKU_NO = _D005_CAR_J.HOKOKU_NO
            frmDLG.PrBUMON_KB = _V002_NCR_J.BUMON_KB
            frmDLG.PrCurrentStage = Me.PrCurrentStage
            dlgRET = frmDLG.ShowDialog(Me)

            If dlgRET = Windows.Forms.DialogResult.Cancel Then
                Return False
            Else
                Me.DialogResult = DialogResult.OK
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
            frmDLG.PrSYONIN_HOKOKUSYO_ID = ENM_SYONIN_HOKOKUSYO_ID._2_CAR
            frmDLG.PrHOKOKU_NO = _D005_CAR_J.HOKOKU_NO
            frmDLG.PrCurrentStage = Me.PrCurrentStage
            dlgRET = frmDLG.ShowDialog(Me)
            If dlgRET = Windows.Forms.DialogResult.Cancel Then
                Return False
            Else
                Me.DialogResult = DialogResult.OK
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
    Private Function FunOpenReportCAR() As Boolean
        Dim strOutputFileName As String
        Dim strTEMPFILE As String
        'Dim intRET As Integer

        Try
            Me.Cursor = Cursors.WaitCursor

            '�t�@�C����
            strOutputFileName = "CAR_" & _D005_CAR_J.HOKOKU_NO & "_Work.xls"

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
            If FunMakeReportCAR(pub_APP_INFO.strOUTPUT_PATH & strOutputFileName, _D005_CAR_J.HOKOKU_NO) = False Then
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

    Private Function _FunMakeReportCAR(ByVal strFilePath As String, ByVal strHOKOKU_NO As String) As Boolean

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
            End If

            Return True
        Catch ex As Exception
            EM.ErrorSyori(ex, False, conblnNonMsg)
            Return False
        Finally
            If frmDLG IsNot Nothing Then
                frmDLG.Dispose()
            End If

            Me.Visible = True
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

            '�J�����g�X�e�[�W�����g�̒S���łȂ��ꍇ�͖���
            If FunblnOwnCreated(ENM_SYONIN_HOKOKUSYO_ID._2_CAR, PrHOKOKU_NO, PrCurrentStage) Then '
                cmdFunc1.Enabled = True
                cmdFunc2.Enabled = True
                cmdFunc4.Enabled = True
                cmdFunc5.Enabled = True

                'SPEC: C10-3
                If PrCurrentStage = ENM_CAR_STAGE._10_�N������ Then
                    cmdFunc5.Enabled = False
                    MyBase.ToolTip.SetToolTip(Me.cmdFunc5, "�N�����͂ō��ߓo�^�͎g�p�o���܂���")
                Else
                    cmdFunc5.Enabled = True
                    MyBase.ToolTip.SetToolTip(Me.cmdFunc5, My.Resources.infoToolTipMsgNotFoundData)
                End If
            Else
                cmdFunc1.Enabled = False
                cmdFunc2.Enabled = False
                cmdFunc4.Enabled = False
                cmdFunc5.Enabled = False

                MyBase.ToolTip.SetToolTip(Me.cmdFunc5, "�o�^����������܂���")

                '#52 �Ǘ��Ҍ��������ꍇ
                Dim blnIsAdmin As Boolean = HasAdminAuth(pub_SYAIN_INFO.SYAIN_ID)
                If blnIsAdmin Then
                    cmdFunc4.Enabled = True
                    cmdFunc5.Enabled = True
                End If
            End If

            If Not PrDialog Then
                cmdFunc3.Enabled = True
                MyBase.ToolTip.SetToolTip(Me.cmdFunc3, My.Resources.infoToolTipMsgNotFoundData)
            Else
                cmdFunc3.Enabled = False
                MyBase.ToolTip.SetToolTip(Me.cmdFunc3, "����NCR��ʂ���Ăяo����Ă��邽�ߎg�p�o���܂���")
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

#Region "   �^�u��"

#Region "�w�b�_"
    Private Sub rbtnSEKKEI_TANTO_YOHI_YES_CheckedChanged(sender As Object, e As EventArgs) Handles rbtnSEKKEI_TANTO_YOHI_YES.CheckedChanged

        Dim blnChecked As Boolean = rbtnSEKKEI_TANTO_YOHI_NO.Checked
        _D005_CAR_J.SETUMON_23 = "1"
    End Sub

    Private Sub rbtnSEKKEI_TANTO_YOHI_NO_CheckedChanged(sender As Object, e As EventArgs) Handles rbtnSEKKEI_TANTO_YOHI_NO.CheckedChanged

        Dim blnChecked As Boolean = rbtnSEKKEI_TANTO_YOHI_NO.Checked
        _D005_CAR_J.SETUMON_23 = "0"
    End Sub

    Private Sub chkSEKKEI_TANTO_YOHI_KB_CheckedChanged(sender As Object, e As EventArgs) Handles chkSEKKEI_TANTO_YOHI_KB.CheckedChanged
        If chkSEKKEI_TANTO_YOHI_KB.Checked Then
            rbtnSEKKEI_TANTO_YOHI_YES.Checked = True
        Else
            rbtnSEKKEI_TANTO_YOHI_NO.Checked = True
        End If
    End Sub
#End Region

#Region "   1.������"

#End Region
#Region "   2.�v��"
    Private Sub CmbKONPON_YOIN_KB1_SelectedValueChanged(sender As Object, e As EventArgs) Handles cmbKONPON_YOIN_KB1.SelectedValueChanged
        If cmbKONPON_YOIN_KB1.SelectedValue = cmbKONPON_YOIN_KB1.NullValue Then
            btnSelectGenin1.Enabled = False
            PrGenin1.Clear()
            mtxGENIN1_DISP.Text = ""
            mtxGENIN1.Text = ""
        Else
            btnSelectGenin1.Enabled = True
        End If
    End Sub

    Private Sub CmbKONPON_YOIN_KB2_SelectedValueChanged(sender As Object, e As EventArgs) Handles cmbKONPON_YOIN_KB2.SelectedValueChanged
        If cmbKONPON_YOIN_KB2.SelectedValue = cmbKONPON_YOIN_KB2.NullValue Then
            btnSelectGenin2.Enabled = False
            PrGenin2.Clear()
            mtxGENIN2_DISP.Text = ""
            mtxGENIN2.Text = ""
        Else
            btnSelectGenin2.Enabled = True
        End If
    End Sub

    'SPEC: 10-1
    Private Sub CmbKONPON_YOIN_KB1_Validating(sender As Object, e As System.ComponentModel.CancelEventArgs) Handles cmbKONPON_YOIN_KB1.Validating

    End Sub

    Private Sub CmbKONPON_YOIN_KB2_Validating(sender As Object, e As System.ComponentModel.CancelEventArgs) Handles cmbKONPON_YOIN_KB2.Validating

    End Sub
#End Region
#Region "   3.���{����"
    Private Sub BtnSelectGenin1_Click(sender As Object, e As EventArgs) Handles btnSelectGenin1.Click
        Dim frmDLG As New Form
        Dim dlgRET As DialogResult
        Try

            If _D005_CAR_J.KONPON_YOIN_KB1 = 0 Then
                frmDLG = New FrmG0013
                DirectCast(frmDLG, FrmG0013).PrMODE = 1
                DirectCast(frmDLG, FrmG0013).PrYOIN = (cmbKONPON_YOIN_KB1.SelectedValue, cmbKONPON_YOIN_KB1.Text)
                DirectCast(frmDLG, FrmG0013).PrSelectedList = PrGenin1
                If Not mtxGENIN1.Text.IsNullOrWhiteSpace Then
                    DirectCast(frmDLG, FrmG0013).PrDAIHYO = (mtxGENIN1.Text.Split(",")(0), mtxGENIN1.Text.Split(",")(1), mtxGENIN1_DISP.Text)
                End If
            Else
                frmDLG = New FrmG0014
                DirectCast(frmDLG, FrmG0014).PrMODE = 1
                DirectCast(frmDLG, FrmG0014).PrYOIN = (cmbKONPON_YOIN_KB1.SelectedValue, cmbKONPON_YOIN_KB1.Text)
                DirectCast(frmDLG, FrmG0014).PrSelectedList = PrGenin1
                If Not mtxGENIN1.Text.IsNullOrWhiteSpace Then
                    DirectCast(frmDLG, FrmG0014).PrDAIHYO = (mtxGENIN1.Text.Split(",")(0), mtxGENIN1.Text.Split(",")(1), mtxGENIN1_DISP.Text)
                End If
            End If

            dlgRET = frmDLG.ShowDialog(Me)

            If dlgRET = Windows.Forms.DialogResult.Cancel Then
                Exit Sub
            Else
                Dim DAIHYO As (ITEM_NAME As String, ITEM_VALUE As String, ITEM_DISP As String)
                If cmbKONPON_YOIN_KB1.SelectedValue = 0 Then
                    DAIHYO = DirectCast(frmDLG, FrmG0013).PrDAIHYO
                Else
                    DAIHYO = DirectCast(frmDLG, FrmG0014).PrDAIHYO
                End If

                If DAIHYO.ITEM_NAME <> "" Then
                    mtxGENIN1_DISP.Text = DAIHYO.ITEM_DISP
                    mtxGENIN1.Text = DAIHYO.ITEM_NAME & "," & DAIHYO.ITEM_VALUE
                Else
                    PrGenin1.Clear()
                    mtxGENIN1_DISP.Text = ""
                    mtxGENIN1.Text = ""
                End If
            End If

        Catch ex As Exception
            EM.ErrorSyori(ex, False, conblnNonMsg)
        Finally
            If frmDLG IsNot Nothing Then
                frmDLG.Dispose()
            End If
        End Try
    End Sub

    Private Sub BtnSelectGenin2_Click(sender As Object, e As EventArgs) Handles btnSelectGenin2.Click
        Dim frmDLG As New Form
        Dim dlgRET As DialogResult
        Try
            If _D005_CAR_J.KONPON_YOIN_KB2 = 0 Then
                frmDLG = New FrmG0013
                DirectCast(frmDLG, FrmG0013).PrMODE = 1
                DirectCast(frmDLG, FrmG0013).PrYOIN = (cmbKONPON_YOIN_KB2.SelectedValue, cmbKONPON_YOIN_KB2.Text)
                DirectCast(frmDLG, FrmG0013).PrSelectedList = PrGenin2
                If Not mtxGENIN2.Text.IsNullOrWhiteSpace Then
                    DirectCast(frmDLG, FrmG0013).PrDAIHYO = (mtxGENIN2.Text.Split(",")(0), mtxGENIN2.Text.Split(",")(1), mtxGENIN2_DISP.Text)
                End If
            Else
                frmDLG = New FrmG0014
                DirectCast(frmDLG, FrmG0014).PrMODE = 1
                DirectCast(frmDLG, FrmG0014).PrYOIN = (cmbKONPON_YOIN_KB2.SelectedValue, cmbKONPON_YOIN_KB2.Text)
                DirectCast(frmDLG, FrmG0014).PrSelectedList = PrGenin2
                If Not mtxGENIN2.Text.IsNullOrWhiteSpace Then
                    DirectCast(frmDLG, FrmG0014).PrDAIHYO = (mtxGENIN2.Text.Split(",")(0), mtxGENIN2.Text.Split(",")(1), mtxGENIN2_DISP.Text)
                End If
            End If

            dlgRET = frmDLG.ShowDialog(Me)

            If dlgRET = Windows.Forms.DialogResult.Cancel Then
                Exit Sub
            Else
                Dim DAIHYO As (ITEM_NAME As String, ITEM_VALUE As String, ITEM_DISP As String)
                If cmbKONPON_YOIN_KB2.SelectedValue = 0 Then
                    DAIHYO = DirectCast(frmDLG, FrmG0013).PrDAIHYO
                Else
                    DAIHYO = DirectCast(frmDLG, FrmG0014).PrDAIHYO
                End If

                If DAIHYO.ITEM_NAME <> "" Then
                    mtxGENIN2_DISP.Text = DAIHYO.ITEM_DISP
                    mtxGENIN2.Text = DAIHYO.ITEM_NAME & "," & DAIHYO.ITEM_VALUE
                Else
                    PrGenin2.Clear()
                    mtxGENIN2_DISP.Text = ""
                    mtxGENIN2.Text = ""
                End If
            End If

        Catch ex As Exception
            EM.ErrorSyori(ex, False, conblnNonMsg)
        Finally
            If frmDLG IsNot Nothing Then
                frmDLG.Dispose()
            End If
        End Try
    End Sub

#End Region
#Region "   4.�C�����}���u"

#End Region
#Region "   5.�������u"

#End Region
#Region "   6.���u�����W�J"
    Private Sub RbtnKAITO14_T_CheckedChanged(sender As Object, e As EventArgs) Handles rbtnKAITO_14_T.CheckedChanged

        Dim blnChecked As Boolean = rbtnSEKKEI_TANTO_YOHI_NO.Checked
        _D005_CAR_J.KAITO_14 = ENM_YOHI_KB._1_�v
    End Sub

    Private Sub RbtnKAITO14_F_CheckedChanged(sender As Object, e As EventArgs) Handles rbtnKAITO_14_T.CheckedChanged

        Dim blnChecked As Boolean = rbtnSEKKEI_TANTO_YOHI_NO.Checked
        _D005_CAR_J.KAITO_14 = ENM_YOHI_KB._0_��
    End Sub

    Private Sub ChkKAITO_14_CheckedChanged(sender As Object, e As EventArgs) Handles chkKAITO_14.CheckedChanged
        If chkKAITO_14.Checked Then
            rbtnKAITO_14_T.Checked = True
        Else
            rbtnKAITO_14_F.Checked = True
        End If
    End Sub
#End Region
#Region "   7.�\������"
    Private Sub CmbDestTANTO_Validating(sender As Object, e As System.ComponentModel.CancelEventArgs) Handles cmbDestTANTO.Validating
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
            lblKYOIKU_FILE_PATH.Text = CompactString(IO.Path.GetFileName(ofd.FileName), lblKYOIKU_FILE_PATH, EllipsisFormat._4_Path)
            lblKYOIKU_FILE_PATH.Links.Clear()
            lblKYOIKU_FILE_PATH.Links.Add(0, lblKYOIKU_FILE_PATH.Text.Length, ofd.FileName)

            _D005_CAR_J.KYOIKU_FILE_PATH = IO.Path.GetFileName(ofd.FileName)
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
        lblKYOIKU_FILE_PATH.Links.Clear()
        lblKYOIKU_FILE_PATH.Visible = False
        lblKYOIKU_FILE_PATH_Clear.Visible = False
        _D005_CAR_J.KYOIKU_FILE_PATH = ""
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
            lblSYOSAI_FILE_PATH.Text = CompactString(IO.Path.GetFileName(ofd.FileName), lblSYOSAI_FILE_PATH, EllipsisFormat._4_Path)
            lblSYOSAI_FILE_PATH.Links.Clear()
            lblSYOSAI_FILE_PATH.Links.Add(0, lblSYOSAI_FILE_PATH.Text.Length, ofd.FileName)

            _D005_CAR_J.SYOSAI_FILE_PATH = IO.Path.GetFileName(ofd.FileName)
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
        lblSYOSAI_FILE_PATH.Text = ""
        lblSYOSAI_FILE_PATH.Tag = ""
        lblSYOSAI_FILE_PATH.Links.Clear()
        lblSYOSAI_FILE_PATH.Visible = False
        lblSYOSAI_FILE_PATH_Clear.Visible = False
        _D005_CAR_J.SYOSAI_FILE_PATH = ""
    End Sub
#End Region

#Region "�������u�L�����̖��̗L��"
    Private Sub rbtnZESEI_SYOCHI_YES_CheckedChanged(sender As Object, e As EventArgs) Handles rbtnZESEI_SYOCHI_YES.CheckedChanged

        Dim blnChecked As Boolean = rbtnZESEI_SYOCHI_NO.Checked
        _D005_CAR_J.ZESEI_SYOCHI_YUKO_UMU = True
    End Sub

    Private Sub rbtnZESEI_SYOCHI_NO_CheckedChanged(sender As Object, e As EventArgs) Handles rbtnZESEI_SYOCHI_NO.CheckedChanged

        Dim blnChecked As Boolean = rbtnZESEI_SYOCHI_NO.Checked
        _D005_CAR_J.ZESEI_SYOCHI_YUKO_UMU = False
    End Sub

    Private Sub chkZESEI_SYOCHI_YUKO_UMU_CheckedChanged(sender As Object, e As EventArgs) Handles chkZESEI_SYOCHI_YUKO_UMU.CheckedChanged
        If chkZESEI_SYOCHI_YUKO_UMU.Checked Then
            rbtnZESEI_SYOCHI_YES.Checked = True
        Else
            rbtnZESEI_SYOCHI_NO.Checked = True
        End If
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
            lbltmpFile1.Text = CompactString(IO.Path.GetFileName(ofd.FileName), lbltmpFile1, EllipsisFormat._4_Path)
            lbltmpFile1.Links.Clear()
            lbltmpFile1.Links.Add(0, lbltmpFile1.Text.Length, ofd.FileName)

            _D005_CAR_J.FILE_PATH1 = IO.Path.GetFileName(ofd.FileName)
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
        _D005_CAR_J.FILE_PATH1 = ""
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
            lbltmpFile2.Text = CompactString(IO.Path.GetFileName(ofd.FileName), lbltmpFile2, EllipsisFormat._4_Path)
            lbltmpFile2.Links.Clear()
            lbltmpFile2.Links.Add(0, lbltmpFile2.Text.Length, ofd.FileName)

            _D005_CAR_J.FILE_PATH2 = IO.Path.GetFileName(ofd.FileName)
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
        _D005_CAR_J.FILE_PATH2 = ""
    End Sub
#End Region

#End Region

#End Region

#End Region

#Region "���[�J���֐�"

    ''' <summary>
    ''' �R���g���[���o�C���f�B���O
    ''' �R���g���[���o�C���f�B���O
    ''' </summary>
    ''' <returns></returns>
    Private Function FunSetBinding() As Boolean

        Try

            '�X�V���Ȃ����̂̓o�C���h���Ȃ����̂Ƃ���

            '�w�b�_
            'mtxHOKUKO_NO.DataBindings.Add(New Binding(NameOf(mtxHOKUKO_NO.Text), _D005_CAR_J, NameOf(_D005_CAR_J.HOKOKU_NO), False, DataSourceUpdateMode.OnPropertyChanged, ""))
            'mtxKISYU.DataBindings.Add(New Binding(NameOf(mtxKISYU.Text), _D005_CAR_J, NameOf(_D005_CAR_J.ki), False, DataSourceUpdateMode.OnPropertyChanged))
            'mtxADD_SYAIN_NAME.DataBindings.Add(New Binding(NameOf(mtxADD_SYAIN_NAME.Text), _D005_CAR_J, NameOf(_D005_CAR_J.HOKOKU_NO), False, DataSourceUpdateMode.OnPropertyChanged))
            'mtxCurrentStageName.DataBindings.Add(New Binding(NameOf(mtxCurrentStageName.Text), _D005_CAR_J, NameOf(_D005_CAR_J.HOKOKU_NO), False, DataSourceUpdateMode.OnPropertyChanged))
            'mtxFUTEKIGO_KB.DataBindings.Add(New Binding(NameOf(mtxFUTEKIGO_KB.Text), _D005_CAR_J, NameOf(_D005_CAR_J), False, DataSourceUpdateMode.OnPropertyChanged))
            'mtxFUTEKIGO_S_KB.DataBindings.Add(New Binding(NameOf(mtxFUTEKIGO_S_KB.Text), _D005_CAR_J, NameOf(_D005_CAR_J.HOKOKU_NO), False, DataSourceUpdateMode.OnPropertyChanged))
            cmbDestTANTO.DataBindings.Add(New Binding(NameOf(cmbDestTANTO.SelectedValue), _D004_SYONIN_J_KANRI, NameOf(_D004_SYONIN_J_KANRI.SYAIN_ID), False, DataSourceUpdateMode.OnPropertyChanged, 0))
            'txtComment.DataBindings.Add(New Binding(NameOf(txtComment.Text), _D004_SYONIN_J_KANRI, NameOf(_D004_SYONIN_J_KANRI.COMMENT), False, DataSourceUpdateMode.OnPropertyChanged, 0))

            'chkSEKKEI_TANTO_YOHI_KB.DataBindings.Add(New Binding(NameOf(cmbDestTANTO.SelectedValue), _D004_SYONIN_J_KANRI, NameOf(_D004_SYONIN_J_KANRI.SYAIN_ID), False, DataSourceUpdateMode.OnPropertyChanged, ""))

            'CAR����
            txtKAITO_1.DataBindings.Add(New Binding(NameOf(txtKAITO_1.Text), _D005_CAR_J, NameOf(_D005_CAR_J.KAITO_1), False, DataSourceUpdateMode.OnPropertyChanged, ""))
            txtKAITO_2.DataBindings.Add(New Binding(NameOf(txtKAITO_2.Text), _D005_CAR_J, NameOf(_D005_CAR_J.KAITO_2), False, DataSourceUpdateMode.OnPropertyChanged, ""))
            dtKAITO_4.DataBindings.Add(New Binding(NameOf(dtKAITO_4.ValueNonFormat), _D005_CAR_J, NameOf(_D005_CAR_J.KAITO_4), False, DataSourceUpdateMode.OnPropertyChanged, ""))
            cmbKAITO_5.DataBindings.Add(New Binding(NameOf(cmbKAITO_5.SelectedValue), _D005_CAR_J, NameOf(_D005_CAR_J.KAITO_5), False, DataSourceUpdateMode.OnPropertyChanged, 0))
            mtxKAITO_6.DataBindings.Add(New Binding(NameOf(mtxKAITO_6.Text), _D005_CAR_J, NameOf(_D005_CAR_J.KAITO_6), False, DataSourceUpdateMode.OnPropertyChanged, ""))
            mtxKAITO_7.DataBindings.Add(New Binding(NameOf(mtxKAITO_7.Text), _D005_CAR_J, NameOf(_D005_CAR_J.KAITO_7), False, DataSourceUpdateMode.OnPropertyChanged, 0))
            dtKAITO_8.DataBindings.Add(New Binding(NameOf(dtKAITO_8.ValueNonFormat), _D005_CAR_J, NameOf(_D005_CAR_J.KAITO_8), False, DataSourceUpdateMode.OnPropertyChanged, ""))
            dtKAITO_9.DataBindings.Add(New Binding(NameOf(dtKAITO_9.ValueNonFormat), _D005_CAR_J, NameOf(_D005_CAR_J.KAITO_9), False, DataSourceUpdateMode.OnPropertyChanged, ""))
            cmbKAITO_10.DataBindings.Add(New Binding(NameOf(cmbKAITO_10.SelectedValue), _D005_CAR_J, NameOf(_D005_CAR_J.KAITO_10), False, DataSourceUpdateMode.OnPropertyChanged, 0))
            mtxKAITO_11.DataBindings.Add(New Binding(NameOf(mtxKAITO_11.Text), _D005_CAR_J, NameOf(_D005_CAR_J.KAITO_11), False, DataSourceUpdateMode.OnPropertyChanged, ""))
            mtxKAITO_12.DataBindings.Add(New Binding(NameOf(mtxKAITO_12.Text), _D005_CAR_J, NameOf(_D005_CAR_J.KAITO_12), False, DataSourceUpdateMode.OnPropertyChanged, 0))
            dtKAITO_13.DataBindings.Add(New Binding(NameOf(dtKAITO_13.ValueNonFormat), _D005_CAR_J, NameOf(_D005_CAR_J.KAITO_13), False, DataSourceUpdateMode.OnPropertyChanged, ""))
            'cmbKAITO_14.DataBindings.Add(New Binding(NameOf(cmbKAITO_14.SelectedValue), _D005_CAR_J, NameOf(_D005_CAR_J.KAITO_14), False, DataSourceUpdateMode.OnPropertyChanged, ""))
            'chkKAITO_14.DataBindings.Add(New Binding(NameOf(chkKAITO_14.Checked), _D005_CAR_J, NameOf(_D005_CAR_J.KAITO_14), False, DataSourceUpdateMode.OnPropertyChanged, False))
            mtxKAITO_15.DataBindings.Add(New Binding(NameOf(mtxKAITO_15.Text), _D005_CAR_J, NameOf(_D005_CAR_J.KAITO_15), False, DataSourceUpdateMode.OnPropertyChanged, ""))
            dtKAITO_16.DataBindings.Add(New Binding(NameOf(dtKAITO_16.ValueNonFormat), _D005_CAR_J, NameOf(_D005_CAR_J.KAITO_16), False, DataSourceUpdateMode.OnPropertyChanged, ""))
            cmbKAITO_17.DataBindings.Add(New Binding(NameOf(cmbKAITO_17.SelectedValue), _D005_CAR_J, NameOf(_D005_CAR_J.KAITO_17), False, DataSourceUpdateMode.OnPropertyChanged, 0))
            mtxKAITO_18.DataBindings.Add(New Binding(NameOf(mtxKAITO_18.Text), _D005_CAR_J, NameOf(_D005_CAR_J.KAITO_18), False, DataSourceUpdateMode.OnPropertyChanged, ""))
            mtxKAITO_19.DataBindings.Add(New Binding(NameOf(mtxKAITO_19.Text), _D005_CAR_J, NameOf(_D005_CAR_J.KAITO_19), False, DataSourceUpdateMode.OnPropertyChanged, ""))
            dtKAITO_20.DataBindings.Add(New Binding(NameOf(dtKAITO_20.ValueNonFormat), _D005_CAR_J, NameOf(_D005_CAR_J.KAITO_20), False, DataSourceUpdateMode.OnPropertyChanged, ""))
            txtKAITO_21.DataBindings.Add(New Binding(NameOf(txtKAITO_21.Text), _D005_CAR_J, NameOf(_D005_CAR_J.KAITO_21), False, DataSourceUpdateMode.OnPropertyChanged, ""))
            txtKAITO_22.DataBindings.Add(New Binding(NameOf(txtKAITO_22.Text), _D005_CAR_J, NameOf(_D005_CAR_J.KAITO_22), False, DataSourceUpdateMode.OnPropertyChanged, ""))

            '���͍���
            cmbKONPON_YOIN_KB1.DataBindings.Add(New Binding(NameOf(cmbKONPON_YOIN_KB1.SelectedValue), _D005_CAR_J, NameOf(_D005_CAR_J.KONPON_YOIN_KB1), False, DataSourceUpdateMode.OnPropertyChanged, ""))
            cmbKONPON_YOIN_KB2.DataBindings.Add(New Binding(NameOf(cmbKONPON_YOIN_KB2.SelectedValue), _D005_CAR_J, NameOf(_D005_CAR_J.KONPON_YOIN_KB2), False, DataSourceUpdateMode.OnPropertyChanged, ""))
            cmbKONPON_YOIN_TANTO.DataBindings.Add(New Binding(NameOf(cmbKONPON_YOIN_TANTO.SelectedValue), _D005_CAR_J, NameOf(_D005_CAR_J.KONPON_YOIN_SYAIN_ID), False, DataSourceUpdateMode.OnPropertyChanged, 0))
            txtKAITO_3.DataBindings.Add(New Binding(NameOf(txtKAITO_3.Text), _D005_CAR_J, NameOf(_D005_CAR_J.KAITO_3), False, DataSourceUpdateMode.OnPropertyChanged, ""))
            cmbKISEKI_KOTEI.DataBindings.Add(New Binding(NameOf(cmbKISEKI_KOTEI.SelectedValue), _D005_CAR_J, NameOf(_D005_CAR_J.KISEKI_KOTEI_KB), False, DataSourceUpdateMode.OnPropertyChanged, ""))
            dtFUTEKIGO_HASSEI_YMD.DataBindings.Add(New Binding(NameOf(dtFUTEKIGO_HASSEI_YMD.ValueNonFormat), _D005_CAR_J, NameOf(_D005_CAR_J.FUTEKIGO_HASSEI_YMD), False, DataSourceUpdateMode.OnPropertyChanged, ""))

            If PrCurrentStage >= ENM_CAR_STAGE._80_���u���{�L�^���� Then
                '���u���{�L�^
                cmbSYOCHI_A_TANTO.DataBindings.Add(New Binding(NameOf(cmbSYOCHI_A_TANTO.SelectedValue), _D005_CAR_J, NameOf(_D005_CAR_J.SYOCHI_A_SYAIN_ID), False, DataSourceUpdateMode.OnPropertyChanged, 0))
                cmbSYOCHI_B_TANTO.DataBindings.Add(New Binding(NameOf(cmbSYOCHI_B_TANTO.SelectedValue), _D005_CAR_J, NameOf(_D005_CAR_J.SYOCHI_B_SYAIN_ID), False, DataSourceUpdateMode.OnPropertyChanged, 0))
                cmbSYOCHI_C_TANTO.DataBindings.Add(New Binding(NameOf(cmbSYOCHI_C_TANTO.SelectedValue), _D005_CAR_J, NameOf(_D005_CAR_J.SYOCHI_C_SYAIN_ID), False, DataSourceUpdateMode.OnPropertyChanged, 0))
                dtSYOCHI_A_YMD.DataBindings.Add(New Binding(NameOf(dtSYOCHI_A_YMD.ValueNonFormat), _D005_CAR_J, NameOf(_D005_CAR_J.SYOCHI_A_YMDHNS), False, DataSourceUpdateMode.OnPropertyChanged, ""))
                dtSYOCHI_B_YMD.DataBindings.Add(New Binding(NameOf(dtSYOCHI_B_YMD.ValueNonFormat), _D005_CAR_J, NameOf(_D005_CAR_J.SYOCHI_B_YMDHNS), False, DataSourceUpdateMode.OnPropertyChanged, ""))
                dtSYOCHI_C_YMD.DataBindings.Add(New Binding(NameOf(dtSYOCHI_C_YMD.ValueNonFormat), _D005_CAR_J, NameOf(_D005_CAR_J.SYOCHI_C_YMDHNS), False, DataSourceUpdateMode.OnPropertyChanged, ""))
                lblKYOIKU_FILE_PATH.DataBindings.Add(New Binding(NameOf(lblKYOIKU_FILE_PATH.Tag), _D005_CAR_J, NameOf(_D005_CAR_J.KYOIKU_FILE_PATH), False, DataSourceUpdateMode.OnPropertyChanged, ""))
            End If

            If PrCurrentStage >= ENM_CAR_STAGE._100_�����L�����L�� Then
                '�������u�L�������r���[
                chkSEKKEI_TANTO_YOHI_KB.DataBindings.Add(New Binding(NameOf(chkSEKKEI_TANTO_YOHI_KB.Checked), _D005_CAR_J, NameOf(_D005_CAR_J.ZESEI_SYOCHI_YUKO_UMU), False, DataSourceUpdateMode.OnPropertyChanged, False))
                mtxGOKI.DataBindings.Add(New Binding(NameOf(mtxGOKI.Text), _D005_CAR_J, NameOf(_D005_CAR_J.GOKI), False, DataSourceUpdateMode.OnPropertyChanged, ""))
                mtxLOT.DataBindings.Add(New Binding(NameOf(mtxLOT.Text), _D005_CAR_J, NameOf(_D005_CAR_J.LOT), False, DataSourceUpdateMode.OnPropertyChanged, 0))
                lblSYOSAI_FILE_PATH.DataBindings.Add(New Binding(NameOf(lblSYOSAI_FILE_PATH.Tag), _D005_CAR_J, NameOf(_D005_CAR_J.SYOSAI_FILE_PATH), False, DataSourceUpdateMode.OnPropertyChanged, ""))
                cmbKENSA_TANTO.DataBindings.Add(New Binding(NameOf(cmbKENSA_TANTO.SelectedValue), _D005_CAR_J, NameOf(_D005_CAR_J.KENSA_TANTO_ID), False, DataSourceUpdateMode.OnPropertyChanged, 0))
                cmbKENSA_GL_TANTO.DataBindings.Add(New Binding(NameOf(cmbKENSA_GL_TANTO.SelectedValue), _D005_CAR_J, NameOf(_D005_CAR_J.KENSA_GL_SYAIN_ID), False, DataSourceUpdateMode.OnPropertyChanged, 0))
                dtKENSA_TOROKU.DataBindings.Add(New Binding(NameOf(dtKENSA_TOROKU.ValueNonFormat), _D005_CAR_J, NameOf(_D005_CAR_J.KENSA_TOROKU_YMDHNS), False, DataSourceUpdateMode.OnPropertyChanged, ""))
                dtKENSA_GL_TOROKU.DataBindings.Add(New Binding(NameOf(dtKENSA_GL_TOROKU.ValueNonFormat), _D005_CAR_J, NameOf(_D005_CAR_J.KENSA_GL_YMDHNS), False, DataSourceUpdateMode.OnPropertyChanged, ""))
            End If

            '�Y�t����
            'lbltmpFile1.DataBindings.Add(New Binding(NameOf(lbltmpFile1.Tag), _D005_CAR_J, NameOf(_D005_CAR_J.FILE_PATH1), False, DataSourceUpdateMode.OnPropertyChanged, ""))
            'lbltmpFile2.DataBindings.Add(New Binding(NameOf(lbltmpFile2.Tag), _D005_CAR_J, NameOf(_D005_CAR_J.FILE_PATH2), False, DataSourceUpdateMode.OnPropertyChanged, ""))


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


            mtxBUMON_KB.Text = _V002_NCR_J.BUMON_NAME
            mtxHOKUKO_NO.Text = _V002_NCR_J.HOKOKU_NO
            mtxKISYU.Text = _V002_NCR_J.KISYU_NAME
            mtxADD_SYAIN_NAME.Text = _V005_CAR_J.SYONIN_NAME10
            mtxFUTEKIGO_KB.Text = _V002_NCR_J.FUTEKIGO_NAME
            mtxFUTEKIGO_S_KB.Text = _V002_NCR_J.FUTEKIGO_S_NAME
            mtxCurrentStageName.Text = FunGetLastStageName(ENM_SYONIN_HOKOKUSYO_ID._2_CAR, _V005_CAR_J.HOKOKU_NO)
            'mtxUPD_YMD.Text = Now.ToString("yyyy/MM/dd")
            mtxNextStageName.Text = FunGetNextStageName(PrCurrentStage)

            Dim blnOwn As Boolean = FunblnOwnCreated(ENM_SYONIN_HOKOKUSYO_ID._2_CAR, _V005_CAR_J.HOKOKU_NO, PrCurrentStage)
            'tabSTAGE07.Enabled = blnOwn

            _tabPageManager = New TabPageManager(TabSTAGE)


            'SPEC: C10-2.�C
            Select Case PrCurrentStage
                Case ENM_CAR_STAGE._10_�N������ To ENM_CAR_STAGE._70_�N���m�F_�i�؉ے�
                    'UNDONE #60 �����ĕ\���̕K�v���Ȃ��̂őޔ��������Ƀ^�u�폜
                    TabSTAGE.TabPages.Remove(tab_CAR_SUB_1_)
                    TabSTAGE.TabPages.Remove(tab_CAR_SUB_2_)
                    '_tabPageManager.ChangeTabPageVisible(1, False) 'tab_CAR_SUB_1_.Visible = False
                    '_tabPageManager.ChangeTabPageVisible(2, False)'tab_CAR_SUB_2_.Visible = False

                Case ENM_CAR_STAGE._80_���u���{�L�^����, ENM_CAR_STAGE._90_���u���{�m�F
                    tabSTAGE01.EnableDisablePages(False)
                    tab_CAR_SUB_1_.Enabled = blnOwn 'tab_CAR_SUB_1_.EnableDisablePages(blnOwn) 
                    TabSTAGE.TabPages.Remove(tab_CAR_SUB_2_)

                Case ENM_CAR_STAGE._100_�����L�����L�� To ENM_CAR_STAGE._130_�����L�����m�F_�i�ؒS���ے�
                    tabSTAGE01.EnableDisablePages(False)
                    tab_CAR_SUB_1_.Enabled = False 'tab_CAR_SUB_1_.EnableDisablePages(False)
                    tab_CAR_SUB_2_.Enabled = blnOwn 'tab_CAR_SUB_2_.EnableDisablePages(blnOwn)
                Case Else
            End Select

            If PrCurrentStage = ENM_CAR_STAGE._130_�����L�����m�F_�i�ؒS���ے� Then
                lblDestTANTO.Visible = False
                cmbDestTANTO.Visible = False
            End If

            Dim _V003 As New MODEL.V003_SYONIN_J_KANRI
            _V003 = _V003_SYONIN_J_KANRI_List.AsEnumerable.
                                Where(Function(r) r.SYONIN_JUN = PrCurrentStage).
                                FirstOrDefault
            If _V003 IsNot Nothing Then
                If Not _V003.RIYU.IsNullOrWhiteSpace Then lbl_Modoshi_Riyu.Visible = True
                If _V003.SASIMODOSI_FG Then
                    lbl_Modoshi_Riyu.Text = "���ߗ��R�F" & _V003.RIYU
                Else
                    '�]����
                    lbl_Modoshi_Riyu.Text = "�]�����R�F" & _V003.RIYU
                End If
            End If

            txtKAITO_1.Focus()
            ErrorProvider.ClearError(cmbDestTANTO)


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
            lblSETUMON_21.Text = tblSETUMON_NAIYO.AsEnumerable.Where(Function(r) r.Field(Of String)("VALUE") = 21).First.Item("DISP")
            lblSETUMON_22.Text = tblSETUMON_NAIYO.AsEnumerable.Where(Function(r) r.Field(Of String)("VALUE") = 22).First.Item("DISP")

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
            _V002_NCR_J = FunGetV002Model(PrHOKOKU_NO)

            _V003_SYONIN_J_KANRI_List = FunGetV003Model(ENM_SYONIN_HOKOKUSYO_ID._2_CAR, PrHOKOKU_NO)

            _D005_CAR_J.Clear()
            _V005_CAR_J = FunGetV005Model(PrHOKOKU_NO)


            '�f�[�^�\�[�X�ݒ�
            Dim dt As DataTable
            dt = FunGetSYOZOKU_SYAIN(_V002_NCR_J.BUMON_KB)
            cmbKONPON_YOIN_TANTO.SetDataSource(dt, ENM_COMBO_SELECT_VALUE_TYPE._0_Required)
            cmbKAITO_5.SetDataSource(dt, ENM_COMBO_SELECT_VALUE_TYPE._0_Required)
            cmbKAITO_10.SetDataSource(dt, ENM_COMBO_SELECT_VALUE_TYPE._0_Required)
            cmbKAITO_17.SetDataSource(dt, ENM_COMBO_SELECT_VALUE_TYPE._0_Required)
            cmbSYOCHI_A_TANTO.SetDataSource(dt, ENM_COMBO_SELECT_VALUE_TYPE._2_Option)
            cmbSYOCHI_B_TANTO.SetDataSource(dt, ENM_COMBO_SELECT_VALUE_TYPE._2_Option)
            cmbSYOCHI_C_TANTO.SetDataSource(dt, ENM_COMBO_SELECT_VALUE_TYPE._2_Option)
            cmbKENSA_TANTO.SetDataSource(dt, ENM_COMBO_SELECT_VALUE_TYPE._0_Required)
            cmbKENSA_GL_TANTO.SetDataSource(dt, ENM_COMBO_SELECT_VALUE_TYPE._0_Required)

            dt = FunGetSYONIN_SYOZOKU_SYAIN(_V002_NCR_J.BUMON_KB, ENM_SYONIN_HOKOKUSYO_ID._2_CAR, FunGetNextSYONIN_JUN(PrCurrentStage))
            cmbDestTANTO.SetDataSource(dt, ENM_COMBO_SELECT_VALUE_TYPE._0_Required)


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
            chkKAITO_14.Checked = IIf(_V005_CAR_J.KAITO_14 = "1", True, False)

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
            If Not _V005_CAR_J.KONPON_YOIN_KB1.IsNullOrWhiteSpace Then
                btnSelectGenin1.Enabled = True
            End If
            _D005_CAR_J.KONPON_YOIN_KB2 = _V005_CAR_J.KONPON_YOIN_KB2
            If Not _V005_CAR_J.KONPON_YOIN_KB2.IsNullOrWhiteSpace Then
                btnSelectGenin2.Enabled = True
            End If

            _D005_CAR_J.FUTEKIGO_HASSEI_YMD = _V005_CAR_J.FUTEKIGO_HASSEI_YMD
            _D005_CAR_J.KONPON_YOIN_SYAIN_ID = _V005_CAR_J.KONPON_YOIN_SYAIN_ID
            _D005_CAR_J.KISEKI_KOTEI_KB = _V005_CAR_J.KISEKI_KOTEI_KB
            _D005_CAR_J.SYOCHI_A_SYAIN_ID = _V005_CAR_J.SYOCHI_A_SYAIN_ID
            _D005_CAR_J.SYOCHI_A_YMDHNS = _V005_CAR_J.SYOCHI_A_YMDHNS.Trim
            _D005_CAR_J.SYOCHI_B_SYAIN_ID = _V005_CAR_J.SYOCHI_B_SYAIN_ID
            _D005_CAR_J.SYOCHI_B_YMDHNS = _V005_CAR_J.SYOCHI_B_YMDHNS.Trim
            _D005_CAR_J.SYOCHI_C_SYAIN_ID = _V005_CAR_J.SYOCHI_C_SYAIN_ID
            _D005_CAR_J.SYOCHI_C_YMDHNS = _V005_CAR_J.SYOCHI_C_YMDHNS.Trim

            _D005_CAR_J.ZESEI_SYOCHI_YUKO_UMU = CBool(_V005_CAR_J.ZESEI_SYOCHI_YUKO_UMU.Trim)

            _D005_CAR_J.GOKI = _V005_CAR_J.GOKI
            _D005_CAR_J.LOT = _V005_CAR_J.LOT
            _D005_CAR_J.KENSA_TANTO_ID = _V005_CAR_J.KENSA_TANTO_ID
            _D005_CAR_J.KENSA_TOROKU_YMDHNS = _V005_CAR_J.KENSA_TOROKU_YMDHNS.Trim
            _D005_CAR_J.KENSA_GL_SYAIN_ID = _V005_CAR_J.KENSA_GL_SYAIN_ID
            _D005_CAR_J.KENSA_GL_YMDHNS = _V005_CAR_J.KENSA_GL_YMDHNS.Trim
            _D005_CAR_J.ADD_SYAIN_ID = _V005_CAR_J.ADD_SYAIN_ID
            _D005_CAR_J.ADD_YMDHNS = _V005_CAR_J.ADD_YMDHNS.Trim
            _D005_CAR_J.UPD_SYAIN_ID = _V005_CAR_J.UPD_SYAIN_ID
            _D005_CAR_J.UPD_YMDHNS = _V005_CAR_J.UPD_YMDHNS.Trim
            _D005_CAR_J.DEL_SYAIN_ID = _V005_CAR_J.DEL_SYAIN_ID
            _D005_CAR_J.DEL_YMDHNS = _V005_CAR_J.DEL_YMDHNS.Trim

            _D005_CAR_J.KYOIKU_FILE_PATH = _V005_CAR_J.KYOIKU_FILE_PATH
            _D005_CAR_J.SYOSAI_FILE_PATH = _V005_CAR_J.SYOSAI_FILE_PATH
            _D005_CAR_J.FILE_PATH1 = _V005_CAR_J.FILE_PATH1
            _D005_CAR_J.FILE_PATH2 = _V005_CAR_J.FILE_PATH2

            '�Y�t�t�@�C��
            Dim strRootDir As String
            Using DB As ClsDbUtility = DBOpen()
                strRootDir = FunConvPathString(FunGetCodeMastaValue(DB, "�Y�t�t�@�C���ۑ���", My.Application.Info.AssemblyName))
            End Using
            If Not _D005_CAR_J.KYOIKU_FILE_PATH.IsNullOrWhiteSpace Then
                _D005_CAR_J.KYOIKU_FILE_PATH = _V005_CAR_J.KYOIKU_FILE_PATH
                lblKYOIKU_FILE_PATH.Text = CompactString(_V005_CAR_J.KYOIKU_FILE_PATH, lblKYOIKU_FILE_PATH, EllipsisFormat._4_Path)
                lblKYOIKU_FILE_PATH.Links.Clear()
                lblKYOIKU_FILE_PATH.Links.Add(0, lblKYOIKU_FILE_PATH.Text.Length, strRootDir & _V005_CAR_J.HOKOKU_NO.Trim & "\" & _V005_CAR_J.KYOIKU_FILE_PATH)
                lblKYOIKU_FILE_PATH.Visible = True
                lblKYOIKU_FILE_PATH_Clear.Visible = True
            End If
            If Not _D005_CAR_J.SYOSAI_FILE_PATH.IsNullOrWhiteSpace Then
                _D005_CAR_J.SYOSAI_FILE_PATH = _V005_CAR_J.SYOSAI_FILE_PATH
                lblSYOSAI_FILE_PATH.Text = CompactString(_V005_CAR_J.SYOSAI_FILE_PATH, lblKYOIKU_FILE_PATH, EllipsisFormat._4_Path)
                lblSYOSAI_FILE_PATH.Links.Clear()
                lblSYOSAI_FILE_PATH.Links.Add(0, lblSYOSAI_FILE_PATH.Text.Length, strRootDir & _V005_CAR_J.HOKOKU_NO.Trim & "\" & _V005_CAR_J.SYOSAI_FILE_PATH)
                lblSYOSAI_FILE_PATH.Visible = True
                lblSYOSAI_FILE_PATH_Clear.Visible = True
            End If
            If Not _D005_CAR_J.FILE_PATH1.IsNullOrWhiteSpace Then
                _D005_CAR_J.FILE_PATH1 = _V005_CAR_J.FILE_PATH1
                lbltmpFile1.Text = CompactString(_V005_CAR_J.FILE_PATH1, lbltmpFile1, EllipsisFormat._4_Path)
                lbltmpFile1.Links.Clear()
                lbltmpFile1.Links.Add(0, lbltmpFile1.Text.Length, strRootDir & _V005_CAR_J.HOKOKU_NO.Trim & "\" & _V005_CAR_J.FILE_PATH1)
                lbltmpFile1.Visible = True
                lbltmpFile1_Clear.Visible = True
            End If
            If Not _D005_CAR_J.FILE_PATH2.IsNullOrWhiteSpace Then
                _D005_CAR_J.FILE_PATH2 = _V005_CAR_J.FILE_PATH2
                lbltmpFile2.Text = CompactString(_V005_CAR_J.FILE_PATH2, lbltmpFile2, EllipsisFormat._4_Path)
                lbltmpFile2.Links.Clear()
                lbltmpFile2.Links.Add(0, lbltmpFile2.Text.Length, strRootDir & _V005_CAR_J.HOKOKU_NO.Trim & "\" & _V005_CAR_J.FILE_PATH2)
                lbltmpFile2.Visible = True
                lbltmpFile2_Clear.Visible = True
            End If

            '�������͋敪
            _D006_CAR_GENIN_List.Clear()

            sbSQL.Remove(0, sbSQL.Length)
            sbSQL.Append("SELECT")
            sbSQL.Append(" *")
            sbSQL.Append(" FROM V006_CAR_GENIN")
            sbSQL.Append(" WHERE HOKOKU_NO='" & PrHOKOKU_NO & "'")
            sbSQL.Append(" ORDER BY RENBAN")
            Using DB As ClsDbUtility = DBOpen()
                dsList = DB.GetDataSet(sbSQL.ToString, conblnNonMsg)
            End Using

            PrGenin1.Clear()
            PrGenin2.Clear()

            For Each row As DataRow In dsList.Tables(0).Rows
                If row.Item(NameOf(_D006_CAR_GENIN.RENBAN)) = 1 Then
                    Dim item As (ITEM_NAME As String, ITEM_VALUE As String, ITEM_DISP As String) = (row.Item("GENIN_BUNSEKI_KB").ToString.Trim, row.Item("GENIN_BUNSEKI_S_KB").ToString.Trim, row.Item("GENIN_BUNSEKI_NAME").ToString.Trim)
                    PrGenin1.Add(item)

                    If row.Item(NameOf(_D006_CAR_GENIN.DAIHYO_FG)) = 1 Then
                        mtxGENIN1_DISP.Text = item.ITEM_DISP
                        mtxGENIN1.Text = item.ITEM_NAME & "," & item.ITEM_VALUE
                    End If
                End If

                If row.Item(NameOf(_D006_CAR_GENIN.RENBAN)) = 2 Then
                    Dim item As (ITEM_NAME As String, ITEM_VALUE As String, ITEM_DISP As String) = (row.Item("GENIN_BUNSEKI_KB").ToString.Trim, row.Item("GENIN_BUNSEKI_S_KB").ToString.Trim, row.Item("GENIN_BUNSEKI_NAME").ToString.Trim)
                    PrGenin2.Add(item)

                    If row.Item(NameOf(_D006_CAR_GENIN.DAIHYO_FG)) = 1 Then
                        mtxGENIN2_DISP.Text = item.ITEM_DISP
                        mtxGENIN2.Text = item.ITEM_NAME & "," & item.ITEM_VALUE
                    End If
                End If

                '_D006_CAR_GENIN_List.Add(New MODEL.D006_CAR_GENIN With {.HOKOKU_NO = row.Item(NameOf(.HOKOKU_NO)),
                '                                                       .RENBAN = row.Item(NameOf(.RENBAN)),
                '                                                       .GENIN_BUNSEKI_KB = row.Item(NameOf(.GENIN_BUNSEKI_KB)),
                '                                                       .GENIN_BUNSEKI_S_KB = row.Item(NameOf(.GENIN_BUNSEKI_S_KB)),
                '                                                       .DAIHYO_FG = row.Item(NameOf(.DAIHYO_FG)),
                '                                                       .ADD_SYAIN_ID = row.Item(NameOf(.ADD_SYAIN_ID)),
                '                                                       .ADD_YMDHNS = row.Item(NameOf(.ADD_YMDHNS))})
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
            pri_blnValidated = True
            '-----����
            If enmSAVE_MODE = ENM_SAVE_MODE._2_���F�\�� Then
                Call CmbDestTANTO_Validating(cmbDestTANTO, Nothing)
                '-----�X�e�[�W��
                Select Case PrCurrentStage
                    Case ENM_CAR_STAGE._80_���u���{�L�^����, ENM_CAR_STAGE._90_���u���{�m�F

                    Case ENM_CAR_STAGE._100_�����L�����L��

                    Case ENM_CAR_STAGE._110_�����L�����m�F_����GL

                    Case ENM_CAR_STAGE._120_�����L�����m�F_�i��TL, ENM_CAR_STAGE._130_�����L�����m�F_�i�ؒS���ے�

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
    ''' �Y���񍐏�No�̌��݂̃X�e�[�W�����擾
    ''' </summary>
    ''' <param name="intSYONIN_HOKOKUSYO_ID"></param>
    ''' <param name="strHOKOKU_NO"></param>
    ''' <returns></returns>
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
    ''' ���X�e�[�W�̏��F��No���擾
    ''' </summary>
    ''' <param name="intCurrentStageID">���X�e�[�WID</param>
    ''' <returns></returns>
    Private Function FunGetNextSYONIN_JUN(ByVal intCurrentStageID As Integer) As Integer
        Try

            Return intCurrentStageID + 10

        Catch ex As Exception
            EM.ErrorSyori(ex, False, conblnNonMsg)
            Return 0
        End Try
    End Function


#End Region

End Class