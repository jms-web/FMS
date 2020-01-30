Imports System.Threading.Tasks
Imports JMS_COMMON.ClsPubMethod
Imports MODEL

''' <summary>
''' CAR�o�^���
''' </summary>
Public Class FrmG0021

#Region "�萔�E�ϐ�"

    Private _V002_NCR_J As New V002_NCR_J
    Private _V003_SYONIN_J_KANRI_List As New List(Of V003_SYONIN_J_KANRI)
    Private _V011_FCR_J As New V011_FCR_J

    '���͕K�{�R���g���[�����ؔ���
    Private IsValidated As Boolean

    Private _tabPageManager As TabPageManager

    Private IsEditingClosed As Boolean

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

    'NCR�ҏW��ʂ���J����Ă��邩
    Public Property PrDialog As Boolean

    Public PrRIYU As String = ""

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
        cmbKOKYAKU_EIKYO_HANTEI_COMMENT.NullValue = ""
        dtTUCHI_YMD.Nullable = True
        dtKOKYAKU_NOUNYU_YMD.Nullable = True
        dtZAIKO_SIKAKE_YMD.Nullable = True
        dtOTHER_PROCESS_YMD.Nullable = True
        Me.Height = 750

        rsbtnST99.Enabled = False
        dtFUTEKIGO_HASSEI_YMD.ReadOnly = True

        dtSYOCHI_YOTEI_YMD.MinDate = Date.Today

        dtFUTEKIGO_HASSEI_YMD.ReadOnly = True
    End Sub

#End Region

#Region "Form�֘A"

    'Load�C�x���g
    Private Async Sub FrmLoad(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        Try
            Me.Visible = False
            PrRIYU = ""
            Await Task.Run(
                Sub()
                    Me.Invoke(
                    Sub()
                        '-----�t�H�[�������ݒ�(�e�t�H�[������Ăяo��)
                        Call FunFormCommonSetting(pub_APP_INFO, pub_SYAIN_INFO, My.Application.Info.Version.ToString)
                        Using DB As ClsDbUtility = DBOpen()
                            lblTytle.Text = FunGetCodeMastaValue(DB, "PG_TITLE", Me.GetType.ToString)
                        End Using

                        '--- ���f���N���A
                        _D004_SYONIN_J_KANRI.clear()

                        '-----�R���g���[���f�[�^�\�[�X�ݒ�
                        cmbKOKYAKU_EIKYO_HANTEI_COMMENT.SetDataSource(tblKOKYAKU_EIKYO_COMMENT, ENM_COMBO_SELECT_VALUE_TYPE._2_Option)
                        Dim dt = tblKISYU.AsEnumerable.Where(Function(r) r.Field(Of String)(NameOf(_D003_NCR_J.BUMON_KB)) = PrDataRow.Item("BUMON_KB")).CopyToDataTable
                        cmbKISYU1.SetDataSource(dt, ENM_COMBO_SELECT_VALUE_TYPE._2_Option)
                        cmbKISYU2.SetDataSource(dt, ENM_COMBO_SELECT_VALUE_TYPE._2_Option)
                        cmbKISYU3.SetDataSource(dt, ENM_COMBO_SELECT_VALUE_TYPE._2_Option)
                        cmbKISYU4.SetDataSource(dt, ENM_COMBO_SELECT_VALUE_TYPE._2_Option)
                        cmbKISYU5.SetDataSource(dt, ENM_COMBO_SELECT_VALUE_TYPE._2_Option)
                        cmbKISYU6.SetDataSource(dt, ENM_COMBO_SELECT_VALUE_TYPE._2_Option)

                        '-----��ʏ�����
                        Call FunInitializeControls()

                        AddHandler rbtnKOKYAKU_EIKYO_HANTEI_KB_T.CheckedChanged, AddressOf RbtnSEKKEI_TANTO_YOHI_YES_CheckedChanged
                        AddHandler rbtnKOKYAKU_EIKYO_HANTEI_KB_F.CheckedChanged, AddressOf RbtnSEKKEI_TANTO_YOHI_NO_CheckedChanged

                        Me.tabSTAGE01.Focus()
                    End Sub)
                End Sub)
        Finally
            FunInitFuncButtonEnabled()
            Me.Visible = True
            Me.WindowState = Me.Owner.WindowState
        End Try
    End Sub

    Private Sub TabPageMouseWheel(sender As Object, e As MouseEventArgs)
        tabSTAGE01.Focus()
    End Sub

    'Shown
    Private Sub Frm_Shown(sender As Object, e As EventArgs) Handles MyBase.Shown
        Me.Owner.Visible = False
    End Sub

    Private Sub Frm_Closed(sender As Object, e As EventArgs) Handles Me.Closed
        Me.Owner.Visible = True
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
                        If IsEditingClosed And PrCurrentStage = ENM_NCR_STAGE._999_Closed Then

                            OpenFormEdit()
                            If PrRIYU.IsNulOrWS Then
                                Exit Sub
                            End If
                        Else
                            If MessageBox.Show("���͓��e��ۑ����܂����H", "�o�^�m�F", MessageBoxButtons.YesNo, MessageBoxIcon.Information) <> DialogResult.Yes Then Exit Sub
                        End If

                        If FunSAVE(ENM_SAVE_MODE._1_�ۑ�) Then
                            Me.DialogResult = DialogResult.OK
                            MessageBox.Show("���͓��e��ۑ����܂���", "�ۑ�����", MessageBoxButtons.OK, MessageBoxIcon.Information)
                        Else
                            MessageBox.Show("�ۑ������Ɏ��s���܂����B", "�ۑ����s", MessageBoxButtons.OK, MessageBoxIcon.Error)
                        End If
                    End If

                Case 2  '���F�\��
                    '�\����^�u�ɐ؂�ւ�
                    TabSTAGE.SelectedIndex = 6

                    '���̓`�F�b�N
                    If FunCheckInput(ENM_SAVE_MODE._2_���F�\��) Then
                        If MessageBox.Show("�\�����܂����H", "���F�E�\�������m�F", MessageBoxButtons.YesNo, MessageBoxIcon.Information) = DialogResult.Yes Then
                            If FunSAVE(ENM_SAVE_MODE._2_���F�\��) Then

                                Dim strMsg As String
                                If PrCurrentStage = ENM_NCR_STAGE._120_abcde���u�m�F Then
                                    strMsg = "���F���܂���"
                                Else
                                    strMsg = "���F�E�\�����܂���"
                                End If

                                MessageBox.Show(strMsg, "���F�E�\����������", MessageBoxButtons.OK, MessageBoxIcon.Information)
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

                    If FunCheckInput(ENM_SAVE_MODE._1_�ۑ�) Then
                        If OpenFormTENSO() Then
                            If IsSysAdminUser(pub_SYAIN_INFO.SYAIN_ID) Then
                                Me.DialogResult = DialogResult.OK
                            Else
                                If FunSAVE(ENM_SAVE_MODE._1_�ۑ�, True) Then
                                    Me.DialogResult = DialogResult.OK
                                Else
                                    MessageBox.Show("�ۑ������Ɏ��s���܂����B", "�ۑ����s", MessageBoxButtons.OK, MessageBoxIcon.Error)
                                End If
                            End If
                        End If
                    End If
                Case 5  '�����߂�
                    Call OpenFormSASIMODOSI()

                Case 10  '���

                    Call FunOpenReportCAR()

                Case 11 '����
                    Call OpenFormHistory(Context.ENM_SYONIN_HOKOKUSYO_ID._2_CAR, _V011_FCR_J.HOKOKU_NO)

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
            If intFUNC <> 12 Then Call FunInitFuncButtonEnabled()

            '[�A�N�e�B�u]
            Me.PrPG_STATUS = ENM_PG_STATUS._2_ACTIVE
        End Try

    End Sub

#End Region

#Region "�ۑ��E���F�\��"

#Region "   �ۑ��E���F�\���������C��"

    ''' <summary>
    ''' �ۑ��E���F�\���������C��
    ''' </summary>
    ''' <param name="enmSAVE_MODE"></param>
    ''' <returns></returns>
    Private Function FunSAVE(ByVal enmSAVE_MODE As ENM_SAVE_MODE, Optional blnTENSO As Boolean = False) As Boolean
        Try

            Using DB As ClsDbUtility = DBOpen()
                Dim blnErr As Boolean
                Try
                    DB.BeginTransaction()

                    'SPEC: 2.(3).D.�@.���R�[�h�X�V
                    If FunSAVE_D007(DB, enmSAVE_MODE) = False Then blnErr = True : Return False
                    If FunSAVE_FILE(DB) = False Then blnErr = True : Return False

                    If Not blnTENSO And PrCurrentStage < ENM_FCR_STAGE._999_Closed Then
                        If FunSAVE_D004(DB, enmSAVE_MODE) = False Then blnErr = True : Return False
                    End If
                    If FunSAVE_R001(DB, enmSAVE_MODE) = False Then blnErr = True : Return False
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

#End Region

#Region "   CAR�Y�t�t�@�C���ۑ�"

    ''' <summary>
    ''' CAR�Y�t�t�@�C���ۑ�
    ''' </summary>
    ''' <param name="DB"></param>
    ''' <returns></returns>
    Private Function FunSAVE_FILE(ByRef DB As ClsDbUtility) As Boolean

        If _D005_CAR_J.KYOIKU_FILE_PATH.IsNulOrWS And
            _D005_CAR_J.SYOSAI_FILE_PATH.IsNulOrWS And
            _D005_CAR_J.FILE_PATH1.IsNulOrWS And
            _D005_CAR_J.FILE_PATH2.IsNulOrWS Then
            Return True
        Else
            'SPEC: 2.(3).D.�A.�Y�t�t�@�C���ۑ�
            Dim strRootDir As String
            Dim strMsg As String
            strRootDir = FunConvPathString(FunGetCodeMastaValue(DB, "�Y�t�t�@�C���ۑ���", My.Application.Info.AssemblyName))
            If strRootDir.IsNulOrWS OrElse Not System.IO.Directory.Exists(strRootDir) Then

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
                    If Not _D005_CAR_J.KYOIKU_FILE_PATH.IsNulOrWS AndAlso
                        Not System.IO.File.Exists(strRootDir & _D005_CAR_J.HOKOKU_NO.Trim & "\" & _D005_CAR_J.KYOIKU_FILE_PATH) Then

                        'If System.IO.File.Exists(lblKYOIKU_FILE_PATH.Links.Item(0).LinkData) Then
                        '    System.IO.File.Copy(lblKYOIKU_FILE_PATH.Links.Item(0).LinkData, strRootDir & _D005_CAR_J.HOKOKU_NO.Trim & "\" & _D005_CAR_J.KYOIKU_FILE_PATH, True)
                        'Else
                        '    Throw New IO.FileNotFoundException($"����L�^�����N:{lblKYOIKU_FILE_PATH.Links.Item(0).LinkData}��������܂���B���̏ꏊ�ɖ߂����I���������Ă�������")
                        'End If
                    End If
                    If Not _D005_CAR_J.SYOSAI_FILE_PATH.IsNulOrWS AndAlso
                        Not System.IO.File.Exists(strRootDir & _D005_CAR_J.HOKOKU_NO.Trim & "\" & _D005_CAR_J.SYOSAI_FILE_PATH) Then

                        'If System.IO.File.Exists(lblSYOSAI_FILE_PATH.Links.Item(0).LinkData) Then
                        '    System.IO.File.Copy(lblSYOSAI_FILE_PATH.Links.Item(0).LinkData, strRootDir & _D005_CAR_J.HOKOKU_NO.Trim & "\" & _D005_CAR_J.SYOSAI_FILE_PATH, True)
                        'Else
                        '    Throw New IO.FileNotFoundException($"�������u�ڍ׎���:{lblSYOSAI_FILE_PATH.Links.Item(0).LinkData}��������܂���B���̏ꏊ�ɖ߂����I���������Ă�������")
                        'End If
                    End If
                    If Not _D005_CAR_J.FILE_PATH1.IsNulOrWS AndAlso
                        Not System.IO.File.Exists(strRootDir & _D005_CAR_J.HOKOKU_NO.Trim & "\" & _D005_CAR_J.FILE_PATH1) Then

                        'If System.IO.File.Exists(lbltmpFile1.Links.Item(0).LinkData) Then
                        '    System.IO.File.Copy(lbltmpFile1.Links.Item(0).LinkData, strRootDir & _D005_CAR_J.HOKOKU_NO.Trim & "\" & _D005_CAR_J.FILE_PATH1, True)
                        'Else
                        '    Throw New IO.FileNotFoundException($"�Y�t�t�@�C��1:{lbltmpFile1.Links.Item(0).LinkData}��������܂���B���̏ꏊ�ɖ߂����I���������Ă�������")
                        'End If
                    End If
                    If Not _D005_CAR_J.FILE_PATH2.IsNulOrWS AndAlso
                        Not System.IO.File.Exists(strRootDir & _D005_CAR_J.HOKOKU_NO.Trim & "\" & _D005_CAR_J.FILE_PATH2) Then

                        'If System.IO.File.Exists(lbltmpFile2.Links.Item(0).LinkData) Then
                        '    System.IO.File.Copy(lbltmpFile2.Links.Item(0).LinkData, strRootDir & _D005_CAR_J.HOKOKU_NO.Trim & "\" & _D005_CAR_J.FILE_PATH2, True)
                        'Else
                        '    Throw New IO.FileNotFoundException($"�Y�t�t�@�C��2:{lbltmpFile2.Links.Item(0).LinkData}��������܂���B���̏ꏊ�ɖ߂����I���������Ă�������")
                        'End If
                    End If

                    Return True
                Catch exNF As IO.FileNotFoundException
                    MessageBox.Show(exNF.Message, "�t�@�C�����݃`�F�b�N", MessageBoxButtons.OK, MessageBoxIcon.Error)
                    Return False
                Catch exIO As UnauthorizedAccessException
                    strMsg = $"�Y�t�t�@�C���ۑ���̃A�N�Z�X����������܂���B{vbCrLf}�Y�t�t�@�C���ۑ���:{strRootDir}"
                    MessageBox.Show(strMsg, "�t�@�C���ۑ���A�N�Z�X�s��", MessageBoxButtons.OK, MessageBoxIcon.Error)
                    Return False
                Catch ex As Exception
                    Throw
                    Return False
                End Try
            End If
        End If
    End Function

#End Region

#Region "   D007"

    ''' <summary>
    ''' CAR���эX�V
    ''' </summary>
    ''' <param name="DB"></param>
    ''' <returns></returns>
    Private Function FunSAVE_D007(ByRef DB As ClsDbUtility, ByVal enmSAVE_MODE As ENM_SAVE_MODE) As Boolean
        Dim sbSQL As New System.Text.StringBuilder
        Dim strRET As String
        Dim sqlEx As New Exception
        Dim strSysDate As String = DB.GetSysDateString


#Region "���f���X�V"

        Dim _D007 As New D007_FCR_J
        _D007.Clear()
        _D007.HOKOKU_NO = mtxHOKUKO_NO.Text
        If PrCurrentStage = ENM_FCR_STAGE._60_�i�؉ے� And enmSAVE_MODE = ENM_SAVE_MODE._2_���F�\�� Then
            _D007._CLOSE_FG = 1
        End If
        _D007._KOKYAKU_EIKYO_HANTEI_KB = If(rbtnKOKYAKU_EIKYO_HANTEI_KB_T.Checked, "1", "0")
        _D007.TAISYOU_KOKYAKU = txtTAISYO_KOKYAKU.Text
        _D007.KOKYAKU_EIKYO_ETC_COMMENT = cmbKOKYAKU_EIKYO_HANTEI_COMMENT.Text
        _D007.KOKYAKU_EIKYO_NAIYO = txtKOKYAKU_EIKYO_NAIYO.Text
        _D007.KAKUNIN_SYUDAN = txtKAKUNIN_SYUDAN.Text
        _D007._KOKYAKU_EIKYO_TUCHI_HANTEI_KB = If(rbtnKOKYAKU_EIKYO_TUCHI_HANTEI_KB_T.Checked, "1", "0")
        _D007.TUCHI_YMD = dtTUCHI_YMD.ValueNonFormat
        _D007.TUCHI_SYUDAN = txtTUCHI_SYUDAN.Text
        _D007.HITUYO_TETUDUKI_ZIKO = txtHITUYO_TETUDUKI_ZIKO.Text
        _D007.KOKYAKU_EIKYO_ETC_COMMENT = txtKOKYAKU_EIKYO_ETC_COMMENT.Text
        _D007._OTHER_PROCESS_INFLUENCE_KB = If(rbtnOTHER_PROCESS_INFLUENCE_KB_T.Checked, "1", "0")
        _D007._FOLLOW_PROCESS_OUTFLOW_KB = If(rbtnFOLLOW_PROCESS_OUTFLOW_KB_T.Checked, "1", "0")
        _D007.KOKYAKU_NOUNYU_NAIYOU = txtKOKYAKU_NOUNYU_NAIYOU.Text
        _D007.KOKYAKU_NOUNYU_YMD = dtKOKYAKU_NOUNYU_YMD.ValueNonFormat
        _D007.ZAIKO_SIKAKE_NAIYOU = txtZAIKO_SIKAKE_NAIYOU.Text
        _D007.ZAIKO_SIKAKE_YMD = dtZAIKO_SIKAKE_YMD.ValueNonFormat
        _D007.OTHER_PROCESS_NAIYOU = txtOTHER_PROCESS_NAIYOU.Text
        _D007.OTHER_PROCESS_YMD = dtOTHER_PROCESS_YMD.ValueNonFormat
        _D007.ADD_YMDHNS = strSysDate
        _D007.ADD_SYAIN_ID = pub_SYAIN_INFO.SYAIN_ID

#End Region

        '-----MERGE
        sbSQL.Remove(0, sbSQL.Length)
        sbSQL.Append($"MERGE INTO {NameOf(D007_FCR_J)} AS SrcT")
        sbSQL.Append($" USING (")
        sbSQL.Append($"{_D007.ToSelectSqlString}")
        sbSQL.Append($" ) AS WK")
        sbSQL.Append($" ON (SrcT.{NameOf(_D007.HOKOKU_NO)} = WK.{NameOf(_D007.HOKOKU_NO)})")
        'UPDATE
        sbSQL.Append($" WHEN MATCHED THEN")
        sbSQL.Append($" UPDATE SET")
        sbSQL.Append($"  SrcT.{NameOf(_D007.CLOSE_FG)} = WK.{NameOf(_D007.CLOSE_FG)}")
        sbSQL.Append($" ,SrcT.{NameOf(_D007.KOKYAKU_EIKYO_HANTEI_KB)} = WK.{NameOf(_D007.KOKYAKU_EIKYO_HANTEI_KB)}")
        sbSQL.Append($" ,SrcT.{NameOf(_D007.TAISYOU_KOKYAKU)} = WK.{NameOf(_D007.TAISYOU_KOKYAKU)}")
        sbSQL.Append($" ,SrcT.{NameOf(_D007.KOKYAKU_EIKYO_HANTEI_COMMENT)} = WK.{NameOf(_D007.KOKYAKU_EIKYO_HANTEI_COMMENT)}")
        sbSQL.Append($" ,SrcT.{NameOf(_D007.KOKYAKU_EIKYO_NAIYO)} = WK.{NameOf(_D007.KOKYAKU_EIKYO_NAIYO)}")
        sbSQL.Append($" ,SrcT.{NameOf(_D007.KAKUNIN_SYUDAN)} = WK.{NameOf(_D007.KAKUNIN_SYUDAN)}")
        sbSQL.Append($" ,SrcT.{NameOf(_D007.KOKYAKU_EIKYO_TUCHI_HANTEI_KB)} = WK.{NameOf(_D007.KOKYAKU_EIKYO_TUCHI_HANTEI_KB)}")
        sbSQL.Append($" ,SrcT.{NameOf(_D007.TUCHI_YMD)} = WK.{NameOf(_D007.TUCHI_YMD)}")
        sbSQL.Append($" ,SrcT.{NameOf(_D007.TUCHI_SYUDAN)} = WK.{NameOf(_D007.TUCHI_SYUDAN)}")
        sbSQL.Append($" ,SrcT.{NameOf(_D007.HITUYO_TETUDUKI_ZIKO)} = WK.{NameOf(_D007.HITUYO_TETUDUKI_ZIKO)}")
        sbSQL.Append($" ,SrcT.{NameOf(_D007.KOKYAKU_EIKYO_ETC_COMMENT)} = WK.{NameOf(_D007.KOKYAKU_EIKYO_ETC_COMMENT)}")
        sbSQL.Append($" ,SrcT.{NameOf(_D007.OTHER_PROCESS_INFLUENCE_KB)} = WK.{NameOf(_D007.OTHER_PROCESS_INFLUENCE_KB)}")
        sbSQL.Append($" ,SrcT.{NameOf(_D007.FOLLOW_PROCESS_OUTFLOW_KB)} = WK.{NameOf(_D007.FOLLOW_PROCESS_OUTFLOW_KB)}")
        sbSQL.Append($" ,SrcT.{NameOf(_D007.KOKYAKU_NOUNYU_NAIYOU)} = WK.{NameOf(_D007.KOKYAKU_NOUNYU_NAIYOU)}")
        sbSQL.Append($" ,SrcT.{NameOf(_D007.KOKYAKU_NOUNYU_YMD)} = WK.{NameOf(_D007.KOKYAKU_NOUNYU_YMD)}")
        sbSQL.Append($" ,SrcT.{NameOf(_D007.ZAIKO_SIKAKE_NAIYOU)} = WK.{NameOf(_D007.ZAIKO_SIKAKE_NAIYOU)}")
        sbSQL.Append($" ,SrcT.{NameOf(_D007.ZAIKO_SIKAKE_YMD)} = WK.{NameOf(_D007.ZAIKO_SIKAKE_YMD)}")
        sbSQL.Append($" ,SrcT.{NameOf(_D007.OTHER_PROCESS_NAIYOU)} = WK.{NameOf(_D007.OTHER_PROCESS_NAIYOU)}")
        sbSQL.Append($" ,SrcT.{NameOf(_D007.OTHER_PROCESS_YMD)} = WK.{NameOf(_D007.OTHER_PROCESS_YMD)}")
        sbSQL.Append($" ,SrcT.{NameOf(_D007.UPD_SYAIN_ID)} = WK.{NameOf(_D007.UPD_SYAIN_ID)}")
        sbSQL.Append($" ,SrcT.{NameOf(_D007.UPD_YMDHNS)} = WK.{NameOf(_D007.UPD_YMDHNS)}")
        'INSERT
        sbSQL.Append($" WHEN NOT MATCHED THEN ")
        sbSQL.Append($"INSERT(")
        _D007.Properties.Take(1).ForEach(Sub(p) sbSQL.Append($" {p.Name}"))
        _D007.Properties.Skip(1).ForEach(Sub(p) sbSQL.Append($",{p.Name}"))
        sbSQL.Append($" ) VALUES(")
        _D007.Properties.Take(1).ForEach(Sub(p) sbSQL.Append($" WK.{p.Name}"))
        _D007.Properties.Skip(1).ForEach(Sub(p) sbSQL.Append($",WK.{p.Name}"))
        sbSQL.Append($" ) ")
        sbSQL.Append($"OUTPUT $action AS RESULT;")
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
        WL.WriteLogDat($"[DEBUG]CAR �񍐏�NO:{_D007.HOKOKU_NO}�AMERGE D007")

        Return True
    End Function

#End Region

#Region "D008"
    Private Function FunSAVE_D008(ByRef DB As ClsDbUtility, ByVal enmSAVE_MODE As ENM_SAVE_MODE) As Boolean
        Dim sbSQL As New System.Text.StringBuilder
        Dim strRET As String
        Dim sqlEx As New Exception
        Dim strSysDate As String = DB.GetSysDateString

        Dim _D008 As New D008_FCR_J_SUB

#Region "Section1"

#End Region

#Region "   ���f���X�V"
        If cmbKISYU1.IsSelected Then
            _D008.Clear()
            _D008.HOKOKU_NO = mtxHOKUKO_NO.Text
            _D008.ROW_NO = 1
            _D008.KISYU_ID = cmbKISYU1.SelectedValue
            _D008.BUHIN_INFO = txtBUHIN_INFO1.Text
            _D008.SURYO = nupSURYO1.Value
            _D008.RANGE_FROM = txtFROM1.Text
            _D008.RANGE_TO = txtTO1.Text
            _D008.ADD_YMDHNS = strSysDate
            _D008.ADD_SYAIN_ID = pub_SYAIN_INFO.SYAIN_ID
        End If

#End Region

        '-----MERGE
        sbSQL.Remove(0, sbSQL.Length)
        sbSQL.Append($"MERGE INTO {NameOf(D008_FCR_J_SUB)} AS SrcT")
        sbSQL.Append($" USING (")
        sbSQL.Append($"{_D008.ToSelectSqlString}")
        sbSQL.Append($" ) AS WK")
        sbSQL.Append($" ON (SrcT.{NameOf(_D008.HOKOKU_NO)} = WK.{NameOf(_D008.HOKOKU_NO)}")
        sbSQL.Append($" AND SrcT.{NameOf(_D008.ROW_NO)} = WK.{NameOf(_D008.ROW_NO)})")
        'UPDATE
        sbSQL.Append($" WHEN MATCHED THEN")
        sbSQL.Append($" UPDATE SET")
        sbSQL.Append($"  SrcT.{NameOf(_D008.KISYU_ID)} = WK.{NameOf(_D008.KISYU_ID)}")
        sbSQL.Append($" ,SrcT.{NameOf(_D008.BUHIN_INFO)} = WK.{NameOf(_D008.BUHIN_INFO)}")
        sbSQL.Append($" ,SrcT.{NameOf(_D008.SURYO)} = WK.{NameOf(_D008.SURYO)}")
        sbSQL.Append($" ,SrcT.{NameOf(_D008.RANGE_FROM)} = WK.{NameOf(_D008.RANGE_FROM)}")
        sbSQL.Append($" ,SrcT.{NameOf(_D008.RANGE_TO)} = WK.{NameOf(_D008.RANGE_TO)}")
        sbSQL.Append($" ,SrcT.{NameOf(_D008.UPD_SYAIN_ID)} = WK.{NameOf(_D008.UPD_SYAIN_ID)}")
        sbSQL.Append($" ,SrcT.{NameOf(_D008.UPD_YMDHNS)} = WK.{NameOf(_D008.UPD_YMDHNS)}")
        'INSERT
        sbSQL.Append($" WHEN NOT MATCHED THEN ")
        sbSQL.Append($"INSERT(")
        _D008.Properties.Take(1).ForEach(Sub(p) sbSQL.Append($" {p.Name}"))
        _D008.Properties.Skip(1).ForEach(Sub(p) sbSQL.Append($",{p.Name}"))
        sbSQL.Append($" ) VALUES(")
        _D008.Properties.Take(1).ForEach(Sub(p) sbSQL.Append($" WK.{p.Name}"))
        _D008.Properties.Skip(1).ForEach(Sub(p) sbSQL.Append($",WK.{p.Name}"))
        sbSQL.Append($" ) ")
        sbSQL.Append($"OUTPUT $action AS RESULT;")
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
        WL.WriteLogDat($"[DEBUG]CAR �񍐏�NO:{_D007.HOKOKU_NO}�AMERGE D007")

        Return True
    End Function

#End Region

#Region "   D004 ���F���ъǗ��X�V"

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
        Dim strSysDate As String = DB.GetSysDateString
        '-----�f�[�^���f���X�V
        _D004_SYONIN_J_KANRI.SYONIN_HOKOKUSYO_ID = Context.ENM_SYONIN_HOKOKUSYO_ID._3_FCR
        _D004_SYONIN_J_KANRI.HOKOKU_NO = _V011_FCR_J.HOKOKU_NO
        _D004_SYONIN_J_KANRI.MAIL_SEND_FG = True
        _D004_SYONIN_J_KANRI.ADD_SYAIN_ID = pub_SYAIN_INFO.SYAIN_ID
        _D004_SYONIN_J_KANRI.ADD_YMDHNS = strSysDate

        If PrCurrentStage = ENM_FCR_STAGE._10_�N������ Then
            _D004_SYONIN_J_KANRI.UPD_SYAIN_ID = pub_SYAIN_INFO.SYAIN_ID
        End If

        '#80 ���F�\�����͉�ʂœ���
        If _D004_SYONIN_J_KANRI.SYONIN_YMDHNS.IsNulOrWS Then
            _D004_SYONIN_J_KANRI.SYONIN_YMDHNS = strSysDate
        ElseIf _D004_SYONIN_J_KANRI.SYONIN_YMDHNS.Trim.Length = 8 Then
            'datetextbox�Ƀo�C���h���͎�����������
            _D004_SYONIN_J_KANRI.SYONIN_YMDHNS &= "000000"
        End If
        Select Case enmSAVE_MODE
            Case ENM_SAVE_MODE._1_�ۑ�
                _D004_SYONIN_J_KANRI.SYONIN_JUN = PrCurrentStage
                _D004_SYONIN_J_KANRI.SYONIN_HANTEI_KB = ENM_SYONIN_HANTEI_KB._0_�����F
                _D004_SYONIN_J_KANRI.SYAIN_ID = pub_SYAIN_INFO.SYAIN_ID

            Case ENM_SAVE_MODE._2_���F�\��
                _D004_SYONIN_J_KANRI.SYONIN_JUN = PrCurrentStage
                _D004_SYONIN_J_KANRI.SYONIN_HANTEI_KB = ENM_SYONIN_HANTEI_KB._1_���F
            Case Else
                'Err
                Return False
        End Select

        _D004_SYONIN_J_KANRI.ADD_YMDHNS = strSysDate 'Now.ToString("yyyyMMddHHmmss")

        '-----MERGE
        sbSQL.Remove(0, sbSQL.Length)
        sbSQL.Append($"MERGE INTO {NameOf(D004_SYONIN_J_KANRI)} AS SrcT")
        sbSQL.Append($" USING (")
        sbSQL.Append($" SELECT")
        sbSQL.Append($"   {_D004_SYONIN_J_KANRI.SYONIN_HOKOKUSYO_ID} AS {NameOf(_D004_SYONIN_J_KANRI.SYONIN_HOKOKUSYO_ID)}")
        sbSQL.Append($" ,'{_D004_SYONIN_J_KANRI.HOKOKU_NO}' AS {NameOf(_D004_SYONIN_J_KANRI.HOKOKU_NO)}")
        sbSQL.Append($" , {_D004_SYONIN_J_KANRI.SYONIN_JUN} AS {NameOf(_D004_SYONIN_J_KANRI.SYONIN_JUN)}")
        sbSQL.Append($" ,'{_D004_SYONIN_J_KANRI.SYAIN_ID}' AS {NameOf(_D004_SYONIN_J_KANRI.SYAIN_ID)}")
        sbSQL.Append($" ,'{_D004_SYONIN_J_KANRI.SYONIN_YMDHNS}' AS {NameOf(_D004_SYONIN_J_KANRI.SYONIN_YMDHNS)}")
        sbSQL.Append($" ,'{_D004_SYONIN_J_KANRI.SYONIN_HANTEI_KB}' AS {NameOf(_D004_SYONIN_J_KANRI.SYONIN_HANTEI_KB)}")
        sbSQL.Append($" ,'{_D004_SYONIN_J_KANRI._SASIMODOSI_FG}' AS {NameOf(_D004_SYONIN_J_KANRI.SASIMODOSI_FG)}")
        sbSQL.Append($" ,'{_D004_SYONIN_J_KANRI.RIYU}' AS {NameOf(_D004_SYONIN_J_KANRI.RIYU)}")
        sbSQL.Append($" ,'{_D004_SYONIN_J_KANRI.COMMENT}' AS {NameOf(_D004_SYONIN_J_KANRI.COMMENT)}")
        sbSQL.Append($" ,'{_D004_SYONIN_J_KANRI._MAIL_SEND_FG}' AS {NameOf(_D004_SYONIN_J_KANRI.MAIL_SEND_FG)}")
        sbSQL.Append($" , {_D004_SYONIN_J_KANRI.ADD_SYAIN_ID} AS {NameOf(_D004_SYONIN_J_KANRI.ADD_SYAIN_ID)}")
        sbSQL.Append($" ,'{_D004_SYONIN_J_KANRI.ADD_YMDHNS}' AS {NameOf(_D004_SYONIN_J_KANRI.ADD_YMDHNS)}")
        sbSQL.Append($" , {_D004_SYONIN_J_KANRI.UPD_SYAIN_ID} AS {NameOf(_D004_SYONIN_J_KANRI.UPD_SYAIN_ID)}")
        sbSQL.Append($" ,'{_D004_SYONIN_J_KANRI.UPD_YMDHNS}' AS {NameOf(_D004_SYONIN_J_KANRI.UPD_YMDHNS)}")
        sbSQL.Append($" ) AS WK")
        sbSQL.Append($" ON (SrcT.{NameOf(_D004_SYONIN_J_KANRI.SYONIN_HOKOKUSYO_ID)} = WK.{NameOf(_D004_SYONIN_J_KANRI.SYONIN_HOKOKUSYO_ID)}")
        sbSQL.Append($" AND SrcT.{NameOf(_D004_SYONIN_J_KANRI.HOKOKU_NO)} = WK.{NameOf(_D004_SYONIN_J_KANRI.HOKOKU_NO)}")
        sbSQL.Append($" AND SrcT.{NameOf(_D004_SYONIN_J_KANRI.SYONIN_JUN)} = WK.{NameOf(_D004_SYONIN_J_KANRI.SYONIN_JUN)})")
        'UPDATE
        sbSQL.Append($" WHEN MATCHED THEN")
        sbSQL.Append($" UPDATE SET")
        sbSQL.Append($"  SrcT.{NameOf(_D004_SYONIN_J_KANRI.SYAIN_ID)} = WK.{NameOf(_D004_SYONIN_J_KANRI.SYAIN_ID)}")
        sbSQL.Append($" ,SrcT.{NameOf(_D004_SYONIN_J_KANRI.COMMENT)} = WK.{NameOf(_D004_SYONIN_J_KANRI.COMMENT)}")
        sbSQL.Append($" ,SrcT.{NameOf(_D004_SYONIN_J_KANRI.SASIMODOSI_FG)} = WK.{NameOf(_D004_SYONIN_J_KANRI.SASIMODOSI_FG)}")
        sbSQL.Append($" ,SrcT.{NameOf(_D004_SYONIN_J_KANRI.SYONIN_YMDHNS)} = WK.{NameOf(_D004_SYONIN_J_KANRI.SYONIN_YMDHNS)}")
        sbSQL.Append($" ,SrcT.{NameOf(_D004_SYONIN_J_KANRI.SYONIN_HANTEI_KB)} = WK.{NameOf(_D004_SYONIN_J_KANRI.SYONIN_HANTEI_KB)}")
        sbSQL.Append($" ,SrcT.{NameOf(_D004_SYONIN_J_KANRI.MAIL_SEND_FG)} = WK.{NameOf(_D004_SYONIN_J_KANRI.MAIL_SEND_FG)}")
        sbSQL.Append($" ,SrcT.{NameOf(_D004_SYONIN_J_KANRI.RIYU)} = WK.{NameOf(_D004_SYONIN_J_KANRI.RIYU)}")
        sbSQL.Append($" ,SrcT.{NameOf(_D004_SYONIN_J_KANRI.UPD_SYAIN_ID)} = {pub_SYAIN_INFO.SYAIN_ID}")
        sbSQL.Append($" ,SrcT.{NameOf(_D004_SYONIN_J_KANRI.UPD_YMDHNS)} = '{strSysDate}'")
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
        sbSQL.Append($" ,'{strSysDate}'")
        sbSQL.Append(" ,WK." & NameOf(_D004_SYONIN_J_KANRI.UPD_SYAIN_ID))
        sbSQL.Append($" ,'{strSysDate}'")
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
                _D004_SYONIN_J_KANRI.SYONIN_HANTEI_KB = ENM_SYONIN_HANTEI_KB._0_�����F

            Case Else
                'Err
                Return False
        End Select

        '-----���f���X�V
        Select Case PrCurrentStage
            Case ENM_FCR_STAGE._60_�i�؉ے�
                _D004_SYONIN_J_KANRI.SYONIN_JUN = 999 'Close
                _D004_SYONIN_J_KANRI.SYONIN_HANTEI_KB = ENM_SYONIN_HANTEI_KB._1_���F
                _D004_SYONIN_J_KANRI.SYONIN_YMDHNS = strSysDate
        End Select
        _D004_SYONIN_J_KANRI.ADD_YMDHNS = strSysDate

        '-----MERGE
        sbSQL.Remove(0, sbSQL.Length)
        sbSQL.Append($"MERGE INTO {NameOf(D004_SYONIN_J_KANRI)} AS SrcT")
        sbSQL.Append($" USING (")
        sbSQL.Append($" SELECT")
        sbSQL.Append($" {_D004_SYONIN_J_KANRI.SYONIN_HOKOKUSYO_ID} AS {NameOf(_D004_SYONIN_J_KANRI.SYONIN_HOKOKUSYO_ID)}")
        sbSQL.Append($" ,'{_D004_SYONIN_J_KANRI.HOKOKU_NO}' AS {NameOf(_D004_SYONIN_J_KANRI.HOKOKU_NO)}")
        sbSQL.Append($" ,{_D004_SYONIN_J_KANRI.SYONIN_JUN} AS {NameOf(_D004_SYONIN_J_KANRI.SYONIN_JUN)}")
        sbSQL.Append($" ,'{_D004_SYONIN_J_KANRI.SYAIN_ID}' AS {NameOf(_D004_SYONIN_J_KANRI.SYAIN_ID)}")
        sbSQL.Append($" ,'{_D004_SYONIN_J_KANRI.SYONIN_YMDHNS}' AS {NameOf(_D004_SYONIN_J_KANRI.SYONIN_YMDHNS)}")
        sbSQL.Append($" ,'{_D004_SYONIN_J_KANRI.SYONIN_HANTEI_KB}' AS {NameOf(_D004_SYONIN_J_KANRI.SYONIN_HANTEI_KB)}")
        sbSQL.Append($" ,'{_D004_SYONIN_J_KANRI._SASIMODOSI_FG}' AS {NameOf(_D004_SYONIN_J_KANRI.SASIMODOSI_FG)}")
        sbSQL.Append($" ,'{_D004_SYONIN_J_KANRI.RIYU}' AS {NameOf(_D004_SYONIN_J_KANRI.RIYU)}")
        sbSQL.Append($" ,'{_D004_SYONIN_J_KANRI.COMMENT}' AS {NameOf(_D004_SYONIN_J_KANRI.COMMENT)}")
        sbSQL.Append($" ,'{_D004_SYONIN_J_KANRI._MAIL_SEND_FG}' AS {NameOf(_D004_SYONIN_J_KANRI.MAIL_SEND_FG)}")
        sbSQL.Append($" ,{_D004_SYONIN_J_KANRI.ADD_SYAIN_ID} AS {NameOf(_D004_SYONIN_J_KANRI.ADD_SYAIN_ID)}")
        sbSQL.Append($" ,'{_D004_SYONIN_J_KANRI.ADD_YMDHNS}' AS {NameOf(_D004_SYONIN_J_KANRI.ADD_YMDHNS)}")
        sbSQL.Append($" ,{pub_SYAIN_INFO.SYAIN_ID} AS {NameOf(_D004_SYONIN_J_KANRI.UPD_SYAIN_ID)}")
        sbSQL.Append($" ,'{_D004_SYONIN_J_KANRI.UPD_YMDHNS}' AS {NameOf(_D004_SYONIN_J_KANRI.UPD_YMDHNS)}")
        sbSQL.Append($" ) AS WK")
        sbSQL.Append($" ON (SrcT.{NameOf(_D004_SYONIN_J_KANRI.SYONIN_HOKOKUSYO_ID)} = WK.{NameOf(_D004_SYONIN_J_KANRI.SYONIN_HOKOKUSYO_ID)}")
        sbSQL.Append($" AND SrcT.{NameOf(_D004_SYONIN_J_KANRI.HOKOKU_NO)} = WK.{NameOf(_D004_SYONIN_J_KANRI.HOKOKU_NO)}")
        sbSQL.Append($" AND SrcT.{NameOf(_D004_SYONIN_J_KANRI.SYONIN_JUN)} = WK.{NameOf(_D004_SYONIN_J_KANRI.SYONIN_JUN)})")
        'UPDATE
        sbSQL.Append($" WHEN MATCHED THEN")
        sbSQL.Append($" UPDATE SET")
        sbSQL.Append($"  SrcT.{NameOf(_D004_SYONIN_J_KANRI.SYAIN_ID)} = WK.{NameOf(_D004_SYONIN_J_KANRI.SYAIN_ID)}")
        sbSQL.Append($" ,SrcT.{NameOf(_D004_SYONIN_J_KANRI.COMMENT)} = WK.{NameOf(_D004_SYONIN_J_KANRI.COMMENT)}")
        sbSQL.Append($" ,SrcT.{NameOf(_D004_SYONIN_J_KANRI.UPD_SYAIN_ID)} = {pub_SYAIN_INFO.SYAIN_ID}")
        sbSQL.Append($" ,SrcT.{NameOf(_D004_SYONIN_J_KANRI.UPD_YMDHNS)} = '{strSysDate}'")
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
        sbSQL.Append($" ,'{strSysDate}'")
        sbSQL.Append(" ,WK." & NameOf(_D004_SYONIN_J_KANRI.UPD_SYAIN_ID))
        sbSQL.Append($" ,'{strSysDate}'")
        sbSQL.Append(" )")
        sbSQL.Append("OUTPUT $action AS RESULT") 'INSERT OR UPDATE ��ncarchar(10)�Ŏ擾����ꍇ
        sbSQL.Append(";")

        ''-----MERGE���s&���s���ʎ擾
        strRET = DB.ExecuteScalar(sbSQL.ToString, conblnNonMsg, sqlEx)
        Select Case strRET
            Case "INSERT"
                If PrCurrentStage < ENM_FCR_STAGE._60_�i�؉ے� AndAlso _D004_SYONIN_J_KANRI.MAIL_SEND_FG = False Then
                    '���F�˗����[�����M
                    If FunSendRequestMail() Then
                        WL.WriteLogDat($"[DEBUG]CTS �񍐏�NO:{_V011_FCR_J.HOKOKU_NO}�ASend Request Mail")
                    End If
                End If

            Case "UPDATE"

            Case Else
                '-----�G���[���O�o��
                Dim strErrMsg As String = My.Resources.ErrLogSqlExecutionFailure & sbSQL.ToString & "|" & sqlEx.Message
                WL.WriteLogDat(strErrMsg)
                Return False
        End Select

        WL.WriteLogDat($"[DEBUG]CTS �񍐏�NO:{_V011_FCR_J.HOKOKU_NO}�AMERGE D004")

        Return True
    End Function

#End Region

#Region "���F�˗����[�����M"

    ''' <summary>
    ''' ���F�˗����[�����M
    ''' </summary>
    ''' <returns></returns>
    Private Function FunSendRequestMail()
        Dim KISYU_NAME As String = _V011_FCR_J.KISYU_NAME
        Dim SYONIN_HANTEI_NAME As String = tblSYONIN_HANTEI_KB.AsEnumerable.Where(Function(r) r.Field(Of String)("VALUE") = _D004_SYONIN_J_KANRI.SYONIN_HANTEI_KB).FirstOrDefault?.Item("DISP")
        Dim strEXEParam As String = _D004_SYONIN_J_KANRI.SYAIN_ID & "," & ENM_OPEN_MODE._2_���u��ʋN�� & "," & Context.ENM_SYONIN_HOKOKUSYO_ID._2_CAR & "," & _D004_SYONIN_J_KANRI.HOKOKU_NO
        Dim strSubject As String = $"�y�s�K���i���u�˗��z[CTS] {KISYU_NAME}"
        Dim strBody As String = <sql><![CDATA[
        {0} �a<br />
        <br />
        �@�s�K���������ߒ������̏��u�˗������܂����̂őΉ������肢���܂��B<br />
        <br />
        �@�@�y�� �� ���zCTS<br />
        �@�@�y�񍐏�No�z{1}<br />
        �@�@�y�N �� ���z{2}<br />
        �@�@�y�@�@  ��z{3}<br />        �@�@
        �@�@�y�� �� �ҁz{5}<br />
        �@�@�y�˗��ҏ��u���e�z{6}<br />
        �@�@�y�R�����g�z{7}<br />
        <br />
        <a href = "http://sv04:8000/CLICKONCE_FMS.application" > �V�X�e���N��</a><br />
        <br />
        �����̃��[���͔z�M��p�ł��B(�ԐM�ł��܂���)<br />
        �ԐM����ꍇ�́A�e�S���҂̃��[���A�h���X���g�p���ĉ������B<br />
        ]]></sql>.Value.Trim

        'http://sv116:8000/CLICKONCE_FMS.application?SYAIN_ID={8}&EXEPATH={9}&PARAMS={10}

        strBody = String.Format(strBody,
                                Fun_GetUSER_NAME(_D004_SYONIN_J_KANRI.SYAIN_ID),
                                _D004_SYONIN_J_KANRI.HOKOKU_NO,
                                DateTime.ParseExact(_V011_FCR_J.ADD_YMD, "yyyyMMdd", Nothing).ToString("yyyy/MM/dd"),
                                KISYU_NAME,
                                "",
                                Fun_GetUSER_NAME(pub_SYAIN_INFO.SYAIN_ID),
                                SYONIN_HANTEI_NAME,
                                _D004_SYONIN_J_KANRI.COMMENT,
                                _D004_SYONIN_J_KANRI.SYAIN_ID,
                                "FMS_G0010.exe",
                                strEXEParam)

        If FunSendMailFutekigo(strSubject, strBody, ToSYAIN_ID:=_D004_SYONIN_J_KANRI.SYAIN_ID) Then
            Return True
        Else
            MessageBox.Show("���[�����M�Ɏ��s���܂����B", "���[�����M���s", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Return False
        End If
    End Function

#End Region

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
        Dim strSysDate As String = DB.GetSysDateString
        '---���݊m�F
        Dim dsList As New DataSet
        Dim blnExist As Boolean
        sbSQL.Append($"SELECT {NameOf(R001_HOKOKU_SOUSA.HOKOKU_NO)} FROM {NameOf(R001_HOKOKU_SOUSA)}")
        sbSQL.Append($" WHERE {NameOf(R001_HOKOKU_SOUSA.HOKOKU_NO)} ='{_R001_HOKOKU_SOUSA.HOKOKU_NO}'")
        dsList = DB.GetDataSet(sbSQL.ToString, conblnNonMsg)
        If dsList.Tables(0).Rows.Count > 0 Then
            blnExist = True
        End If

        '-----�f�[�^���f���X�V
        _R001_HOKOKU_SOUSA.SYONIN_HOKOKUSYO_ID = Context.ENM_SYONIN_HOKOKUSYO_ID._3_FCR
        _R001_HOKOKU_SOUSA.HOKOKU_NO = _V011_FCR_J.HOKOKU_NO
        _R001_HOKOKU_SOUSA.SYONIN_JUN = PrCurrentStage
        _R001_HOKOKU_SOUSA.SYAIN_ID = pub_SYAIN_INFO.SYAIN_ID
        _R001_HOKOKU_SOUSA.RIYU = PrRIYU
        'UNDONE: getsysdatetime
        _R001_HOKOKU_SOUSA.ADD_YMDHNS = strSysDate 'Now.ToString("yyyyMMddHHmmss")

        Select Case enmSAVE_MODE
            Case ENM_SAVE_MODE._1_�ۑ�

                If PrCurrentStage = ENM_FCR_STAGE._999_Closed Then
                    _R001_HOKOKU_SOUSA.SYONIN_HANTEI_KB = ENM_SYONIN_HANTEI_KB._1_���F
                    _R001_HOKOKU_SOUSA.SOUSA_KB = ENM_HOKOKUSYO_SOUSA_KB._2_�X�V�ۑ�
                Else
                    Return True
                End If

            Case ENM_SAVE_MODE._2_���F�\��
                _R001_HOKOKU_SOUSA.SYONIN_HANTEI_KB = ENM_SYONIN_HANTEI_KB._1_���F
                _R001_HOKOKU_SOUSA.SOUSA_KB = ENM_HOKOKUSYO_SOUSA_KB._1_�\��
        End Select

        '-----

        '-----INSERT
        sbSQL.Remove(0, sbSQL.Length)
        sbSQL.Append("INSERT INTO " & NameOf(R001_HOKOKU_SOUSA) & "(")
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

        WL.WriteLogDat($"[DEBUG]CTS �񍐏�NO:{_V011_FCR_J.HOKOKU_NO}�AINSERT R001")

        If FunSAVE_R005(DB, _R001_HOKOKU_SOUSA.ADD_YMDHNS) Then
        Else
            Return False
        End If

        Return True
    End Function

    Private Function FunSAVE_R005(ByRef DB As ClsDbUtility, ByVal strYMDHNS As String) As Boolean
        Dim sbSQL As New System.Text.StringBuilder
        Dim intRET As Integer
        Dim sqlEx As New Exception

        sbSQL.Append($"INSERT(")
        sbSQL.Append($" {NameOf(_R005.SASIMODOSI_YMDHNS)}")
        sbSQL.Append($",{NameOf(_R005.HOKOKU_NO)}")
        sbSQL.Append($",{NameOf(_R005.CLOSE_FG)}")
        sbSQL.Append($",{NameOf(_R005.KOKYAKU_EIKYO_HANTEI_KB)}")
        sbSQL.Append($",{NameOf(_R005.TAISYOU_KOKYAKU)}")
        sbSQL.Append($",{NameOf(_R005.KOKYAKU_EIKYO_HANTEI_COMMENT)}")
        sbSQL.Append($",{NameOf(_R005.KOKYAKU_EIKYO_NAIYO)}")
        sbSQL.Append($",{NameOf(_R005.KAKUNIN_SYUDAN)}")
        sbSQL.Append($",{NameOf(_R005.KOKYAKU_EIKYO_TUCHI_HANTEI_KB)}")
        sbSQL.Append($",{NameOf(_R005.TUCHI_YMD)}")
        sbSQL.Append($",{NameOf(_R005.TUCHI_SYUDAN)}")
        sbSQL.Append($",{NameOf(_R005.HITUYO_TETUDUKI_ZIKO)}")
        sbSQL.Append($",{NameOf(_R005.KOKYAKU_EIKYO_ETC_COMMENT)}")
        sbSQL.Append($",{NameOf(_R005.OTHER_PROCESS_INFLUENCE_KB)}")
        sbSQL.Append($",{NameOf(_R005.FOLLOW_PROCESS_OUTFLOW_KB)}")
        sbSQL.Append($",{NameOf(_R005.KOKYAKU_NOUNYU_NAIYOU)}")
        sbSQL.Append($",{NameOf(_R005.KOKYAKU_NOUNYU_YMD)}")
        sbSQL.Append($",{NameOf(_R005.ZAIKO_SIKAKE_NAIYOU)}")
        sbSQL.Append($",{NameOf(_R005.ZAIKO_SIKAKE_YMD)}")
        sbSQL.Append($",{NameOf(_R005.OTHER_PROCESS_NAIYOU)}")
        sbSQL.Append($",{NameOf(_R005.OTHER_PROCESS_YMD)}")
        sbSQL.Append($" ) VALUES(")
        sbSQL.Append($" '{strYMDHNS}'")
        sbSQL.Append($",{NameOf(_R005.HOKOKU_NO)}")
        sbSQL.Append($",'{_D007.HOKOKU_NO}'")
        sbSQL.Append($",'{_D007.CLOSE_FG}'")
        sbSQL.Append($",'{_D007.KOKYAKU_EIKYO_HANTEI_KB}'")
        sbSQL.Append($",'{_D007.TAISYOU_KOKYAKU}'")
        sbSQL.Append($",'{_D007.KOKYAKU_EIKYO_HANTEI_COMMENT}'")
        sbSQL.Append($",'{_D007.KOKYAKU_EIKYO_NAIYO}'")
        sbSQL.Append($",'{_D007.KAKUNIN_SYUDAN}'")
        sbSQL.Append($",'{_D007.KOKYAKU_EIKYO_TUCHI_HANTEI_KB}'")
        sbSQL.Append($",'{_D007.TUCHI_YMD}'")
        sbSQL.Append($",'{_D007.TUCHI_SYUDAN}'")
        sbSQL.Append($",'{_D007.HITUYO_TETUDUKI_ZIKO}'")
        sbSQL.Append($",'{_D007.KOKYAKU_EIKYO_ETC_COMMENT}'")
        sbSQL.Append($",'{_D007.OTHER_PROCESS_INFLUENCE_KB}'")
        sbSQL.Append($",'{_D007.FOLLOW_PROCESS_OUTFLOW_KB}'")
        sbSQL.Append($",'{_D007.KOKYAKU_NOUNYU_NAIYOU}'")
        sbSQL.Append($",'{_D007.KOKYAKU_NOUNYU_YMD}'")
        sbSQL.Append($",'{_D007.ZAIKO_SIKAKE_NAIYOU}'")
        sbSQL.Append($",'{_D007.ZAIKO_SIKAKE_YMD}'")
        sbSQL.Append($",'{_D007.OTHER_PROCESS_NAIYOU}'")
        sbSQL.Append($",'{_D007.OTHER_PROCESS_YMD}'")
        sbSQL.Append(" );")
        intRET = DB.ExecuteNonQuery(sbSQL.ToString, conblnNonMsg, sqlEx)
        If intRET <> 1 Then
            '-----�G���[���O�o��
            Dim strErrMsg As String = My.Resources.ErrLogSqlExecutionFailure & sbSQL.ToString & "|" & sqlEx.Message
            WL.WriteLogDat(strErrMsg)
            Return False
        Else
            WL.WriteLogDat($"[DEBUG]CTS �񍐏�NO:{_D005_CAR_J.HOKOKU_NO}�AINSERT R005")
            Return True
        End If
    End Function

#End Region

#Region "NCR"

    Private Function OpenFormNCR() As Boolean

        Dim dlgRET As DialogResult

        Try

            Dim sbSQL As New System.Text.StringBuilder
            Dim dsList As New DataSet

            sbSQL.Remove(0, sbSQL.Length)
            sbSQL.Append($"SELECT")
            sbSQL.Append($" {NameOf(V007_NCR_CAR.HOKOKU_NO)},{NameOf(V007_NCR_CAR.SYONIN_JUN)}")
            sbSQL.Append($" FROM {NameOf(V007_NCR_CAR)} ")
            sbSQL.Append($" WHERE {NameOf(V007_NCR_CAR.SYONIN_HOKOKUSYO_ID)}={Context.ENM_SYONIN_HOKOKUSYO_ID._1_NCR.Value}")
            sbSQL.Append($" AND {NameOf(V007_NCR_CAR.HOKOKU_NO)}='{_D005_CAR_J.HOKOKU_NO}'")
            Using DB As ClsDbUtility = DBOpen()
                dsList = DB.GetDataSet(sbSQL.ToString, conblnNonMsg)
            End Using

            Using frmDLG As New FrmG0011
                frmDLG.PrMODE = ENM_DATA_OPERATION_MODE._3_UPDATE
                frmDLG.PrIsDialog = True
                frmDLG.PrCurrentStage = dsList.Tables(0).Rows(0).Item(NameOf(V007_NCR_CAR.SYONIN_JUN))
                frmDLG.PrHOKOKU_NO = dsList.Tables(0).Rows(0).Item(NameOf(V007_NCR_CAR.HOKOKU_NO))

                dlgRET = frmDLG.ShowDialog(Me)
            End Using

            If dlgRET = Windows.Forms.DialogResult.Cancel Then
                Return False
            Else
            End If

            Return True
        Catch ex As Exception
            EM.ErrorSyori(ex, False, conblnNonMsg)
            Return False
        Finally

        End Try
    End Function

#End Region

#Region "�]��"

    Private Function OpenFormTENSO() As Boolean
        Dim frmDLG As New FrmG0015
        Dim dlgRET As DialogResult

        Try
            frmDLG.PrSYONIN_HOKOKUSYO_ID = Context.ENM_SYONIN_HOKOKUSYO_ID._2_CAR
            frmDLG.PrHOKOKU_NO = _D005_CAR_J.HOKOKU_NO
            frmDLG.PrBUMON_KB = _V002_NCR_J.BUMON_KB
            frmDLG.PrBUHIN_BANGO = _V002_NCR_J.BUHIN_BANGO
            frmDLG.PrKISO_YMD = DateTime.ParseExact(_V002_NCR_J.ADD_YMD, "yyyyMMdd", Nothing).ToString("yyyy/MM/dd")
            frmDLG.PrKISYU_NAME = tblKISYU.AsEnumerable.Where(Function(r) r.Field(Of Integer)("VALUE") = _V002_NCR_J.KISYU_ID).FirstOrDefault?.Item("DISP")
            frmDLG.PrCurrentStage = Me.PrCurrentStage
            dlgRET = frmDLG.ShowDialog(Me)

            If dlgRET = Windows.Forms.DialogResult.OK Then
                Me.DialogResult = DialogResult.OK
                Me.Close()
            Else
                Return False
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
            frmDLG.PrSYONIN_HOKOKUSYO_ID = Context.ENM_SYONIN_HOKOKUSYO_ID._2_CAR
            frmDLG.PrHOKOKU_NO = _D005_CAR_J.HOKOKU_NO
            frmDLG.PrBUHIN_BANGO = _V002_NCR_J.BUHIN_BANGO
            frmDLG.PrKISO_YMD = DateTime.ParseExact(_V002_NCR_J.ADD_YMD, "yyyyMMdd", Nothing).ToString("yyyy/MM/dd")
            frmDLG.PrKISYU_NAME = tblKISYU.AsEnumerable.Where(Function(r) r.Field(Of Integer)("VALUE") = _V002_NCR_J.KISYU_ID).FirstOrDefault?.Item("DISP")
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
            If FunMakeReportFCR(pub_APP_INFO.strOUTPUT_PATH & strOutputFileName, _D005_CAR_J.HOKOKU_NO) = False Then
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

    Private Function FunMakeReportFCR(ByVal strFilePath As String, ByVal strHOKOKU_NO As String) As Boolean

        Dim spWorkbook As SpreadsheetGear.IWorkbook
        Dim spWorksheets As SpreadsheetGear.IWorksheets
        Dim spSheet1 As SpreadsheetGear.IWorksheet
        Dim spRangeFrom As SpreadsheetGear.IRange
        Dim spRangeTo As SpreadsheetGear.IRange
        Dim ssgShapes As SpreadsheetGear.Shapes.IShapes
        Try
            spWorkbook = SpreadsheetGear.Factory.GetWorkbook(strFilePath, System.Globalization.CultureInfo.CurrentCulture)

            spWorkbook.WorkbookSet.GetLock()
            spWorksheets = spWorkbook.Worksheets
            spSheet1 = spWorksheets.Item(0) 'sheet1

            Dim spprint As SpreadsheetGear.Printing.PrintWhat = SpreadsheetGear.Printing.PrintWhat.Sheet

            Dim shLINE_KOKYAKU_EIKYO_NAIYO As SpreadsheetGear.Shapes.IShape = Nothing
            Dim shLINE_KAKUNIN_SYUDAN As SpreadsheetGear.Shapes.IShape = Nothing
            Dim shLINE_TUCHI As SpreadsheetGear.Shapes.IShape = Nothing
            Dim shLINE_KOKYAKU_EIKYO_ETC_COMMENT As SpreadsheetGear.Shapes.IShape = Nothing
            Dim shLINE_KISYU1 As SpreadsheetGear.Shapes.IShape = Nothing
            Dim shLINE_RANGE1 As SpreadsheetGear.Shapes.IShape = Nothing
            Dim shLINE_KISYU2 As SpreadsheetGear.Shapes.IShape = Nothing
            Dim shLINE_RANGE2 As SpreadsheetGear.Shapes.IShape = Nothing
            Dim shLINE_NAIYO As SpreadsheetGear.Shapes.IShape = Nothing
            Dim shLINE_YMD As SpreadsheetGear.Shapes.IShape = Nothing
            Dim shSCR_KOKYAKU_EIKYO_HANTEI_KB_T As SpreadsheetGear.Shapes.IShape = Nothing
            Dim shSCR_KOKYAKU_EIKYO_HANTEI_KB_F As SpreadsheetGear.Shapes.IShape = Nothing
            Dim shSCR_KOKYAKU_EIKYO_TUCHI_HANTEI_KB_T As SpreadsheetGear.Shapes.IShape = Nothing
            Dim shSCR_KOKYAKU_EIKYO_TUCHI_HANTEI_KB_F As SpreadsheetGear.Shapes.IShape = Nothing
            Dim shSCR_OTHER_PROCESS_INFLUENCE_KB_T As SpreadsheetGear.Shapes.IShape = Nothing
            Dim shSCR_OTHER_PROCESS_INFLUENCE_KB_F As SpreadsheetGear.Shapes.IShape = Nothing
            Dim shSCR_FOLLOW_PROCESS_OUTFLOW_KB_T As SpreadsheetGear.Shapes.IShape = Nothing
            Dim shSCR_FOLLOW_PROCESS_OUTFLOW_KB_F As SpreadsheetGear.Shapes.IShape = Nothing

            Dim strYMDHNS As String
            ssgShapes = spSheet1.Shapes
            For Each shape As SpreadsheetGear.Shapes.IShape In ssgShapes
                Select Case shape.Name
                    Case "LINE_KOKYAKU_EIKYO_NAIYO"
                        shLINE_KOKYAKU_EIKYO_NAIYO = shape
                    Case "LINE_KAKUNIN_SYUDAN"
                        shLINE_KAKUNIN_SYUDAN = shape
                    Case "LINE_TUCHI"
                        shLINE_TUCHI = shape
                    Case "LINE_KOKYAKU_EIKYO_ETC_COMMENT"
                        shLINE_KOKYAKU_EIKYO_ETC_COMMENT = shape
                    Case "LINE_KISYU1"
                        shLINE_KISYU1 = shape
                    Case "LINE_RANGE1"
                        shLINE_RANGE1 = shape
                    Case "LINE_KISYU2"
                        shLINE_KISYU2 = shape
                    Case "LINE_RANGE2"
                        shLINE_RANGE2 = shape
                    Case "LINE_NAIYO"
                        shLINE_NAIYO = shape
                    Case "LINE_YMD"
                        shLINE_YMD = shape
                    Case "SCR_KOKYAKU_EIKYO_HANTEI_KB_T"
                        shSCR_KOKYAKU_EIKYO_HANTEI_KB_T = shape
                    Case "SCR_KOKYAKU_EIKYO_HANTEI_KB_F"
                        shSCR_KOKYAKU_EIKYO_HANTEI_KB_F = shape
                    Case "SCR_KOKYAKU_EIKYO_TUCHI_HANTEI_KB_T"
                        shSCR_KOKYAKU_EIKYO_TUCHI_HANTEI_KB_T = shape
                    Case "SCR_KOKYAKU_EIKYO_TUCHI_HANTEI_KB_F"
                        shSCR_KOKYAKU_EIKYO_TUCHI_HANTEI_KB_F = shape
                    Case "SCR_OTHER_PROCESS_INFLUENCE_KB_T"
                        shSCR_OTHER_PROCESS_INFLUENCE_KB_T = shape
                    Case "SCR_OTHER_PROCESS_INFLUENCE_KB_F"
                        shSCR_OTHER_PROCESS_INFLUENCE_KB_F = shape
                    Case "SCR_FOLLOW_PROCESS_OUTFLOW_KB_T"
                        shSCR_FOLLOW_PROCESS_OUTFLOW_KB_T = shape
                    Case "SCR_FOLLOW_PROCESS_OUTFLOW_KB_F"
                        shSCR_FOLLOW_PROCESS_OUTFLOW_KB_F = shape
                End Select
            Next shape

            '���R�[�h�t���[��������

            Dim _V11 As V011_FCR_J = FunGetV011Model(strHOKOKU_NO)
            Dim _V003_SYONIN_J_KANRI_List As List(Of V003_SYONIN_J_KANRI) = FunGetV003Model(Context.ENM_SYONIN_HOKOKUSYO_ID._3_FCR, strHOKOKU_NO)

            spSheet1.Range(NameOf(V011_FCR_J.HOKOKU_NO)).Value = _V11.HOKOKU_NO
            spSheet1.Range(NameOf(V011_FCR_J.TAISYOU_KOKYAKU)).Value = _V11.TAISYOU_KOKYAKU
            spSheet1.Range(NameOf(V011_FCR_J.KOKYAKU_EIKYO_HANTEI_COMMENT)).Value = _V11.KOKYAKU_EIKYO_HANTEI_COMMENT

            Dim blnHANTEI As Boolean = (_V11.KOKYAKU_EIKYO_HANTEI_KB = "1")
            shSCR_KOKYAKU_EIKYO_HANTEI_KB_T.Visible = blnHANTEI
            shSCR_KOKYAKU_EIKYO_HANTEI_KB_F.Visible = Not blnHANTEI
            shLINE_KOKYAKU_EIKYO_NAIYO.Visible = Not blnHANTEI
            shLINE_KAKUNIN_SYUDAN.Visible = Not blnHANTEI
            shLINE_TUCHI.Visible = Not blnHANTEI
            shLINE_KOKYAKU_EIKYO_ETC_COMMENT.Visible = Not blnHANTEI
            shLINE_KISYU1.Visible = Not blnHANTEI
            shLINE_KISYU2.Visible = Not blnHANTEI
            shLINE_RANGE1.Visible = Not blnHANTEI
            shLINE_RANGE2.Visible = Not blnHANTEI
            shLINE_NAIYO.Visible = Not blnHANTEI
            shLINE_YMD.Visible = Not blnHANTEI

            shSCR_OTHER_PROCESS_INFLUENCE_KB_T.Visible = (_V11.OTHER_PROCESS_INFLUENCE_KB = "1")
            shSCR_OTHER_PROCESS_INFLUENCE_KB_F.Visible = Not (_V11.OTHER_PROCESS_INFLUENCE_KB = "1")
            shSCR_FOLLOW_PROCESS_OUTFLOW_KB_T.Visible = (_V11.FOLLOW_PROCESS_OUTFLOW_KB = "1")
            shSCR_FOLLOW_PROCESS_OUTFLOW_KB_F.Visible = Not (_V11.FOLLOW_PROCESS_OUTFLOW_KB = "1")

            spSheet1.Range(NameOf(V011_FCR_J.KOKYAKU_EIKYO_NAIYO)).Value = _V11.KOKYAKU_EIKYO_NAIYO
            spSheet1.Range(NameOf(V011_FCR_J.KAKUNIN_SYUDAN)).Value = _V11.KAKUNIN_SYUDAN
            spSheet1.Range(NameOf(V011_FCR_J.KOKYAKU_EIKYO_ETC_COMMENT)).Value = _V11.KOKYAKU_EIKYO_ETC_COMMENT
            spSheet1.Range(NameOf(V011_FCR_J.KISYU1_NAME)).Value = _V11.KISYU1_NAME
            spSheet1.Range(NameOf(V011_FCR_J.KISYU2_NAME)).Value = _V11.KISYU2_NAME
            spSheet1.Range(NameOf(V011_FCR_J.KISYU3_NAME)).Value = _V11.KISYU3_NAME
            spSheet1.Range(NameOf(V011_FCR_J.KISYU4_NAME)).Value = _V11.KISYU4_NAME
            spSheet1.Range(NameOf(V011_FCR_J.KISYU5_NAME)).Value = _V11.KISYU5_NAME
            spSheet1.Range(NameOf(V011_FCR_J.KISYU6_NAME)).Value = _V11.KISYU6_NAME
            spSheet1.Range(NameOf(V011_FCR_J.BUHIN_INFO1)).Value = _V11.BUHIN_INFO1
            spSheet1.Range(NameOf(V011_FCR_J.BUHIN_INFO2)).Value = _V11.BUHIN_INFO2
            spSheet1.Range(NameOf(V011_FCR_J.BUHIN_INFO3)).Value = _V11.BUHIN_INFO3
            spSheet1.Range(NameOf(V011_FCR_J.BUHIN_INFO4)).Value = _V11.BUHIN_INFO4
            spSheet1.Range(NameOf(V011_FCR_J.BUHIN_INFO5)).Value = _V11.BUHIN_INFO5
            spSheet1.Range(NameOf(V011_FCR_J.BUHIN_INFO6)).Value = _V11.BUHIN_INFO6
            spSheet1.Range(NameOf(V011_FCR_J.SURYO1)).Value = _V11.SURYO1
            spSheet1.Range(NameOf(V011_FCR_J.SURYO2)).Value = _V11.SURYO2
            spSheet1.Range(NameOf(V011_FCR_J.SURYO3)).Value = _V11.SURYO3
            spSheet1.Range(NameOf(V011_FCR_J.SURYO4)).Value = _V11.SURYO4
            spSheet1.Range(NameOf(V011_FCR_J.SURYO5)).Value = _V11.SURYO5
            spSheet1.Range(NameOf(V011_FCR_J.SURYO6)).Value = _V11.SURYO6
            spSheet1.Range(NameOf(V011_FCR_J.RANGE_FROM1)).Value = _V11.RANGE_FROM1
            spSheet1.Range(NameOf(V011_FCR_J.RANGE_FROM2)).Value = _V11.RANGE_FROM2
            spSheet1.Range(NameOf(V011_FCR_J.RANGE_FROM3)).Value = _V11.RANGE_FROM3
            spSheet1.Range(NameOf(V011_FCR_J.RANGE_FROM4)).Value = _V11.RANGE_FROM4
            spSheet1.Range(NameOf(V011_FCR_J.RANGE_FROM5)).Value = _V11.RANGE_FROM5
            spSheet1.Range(NameOf(V011_FCR_J.RANGE_FROM6)).Value = _V11.RANGE_FROM6
            spSheet1.Range(NameOf(V011_FCR_J.RANGE_TO1)).Value = _V11.RANGE_TO1
            spSheet1.Range(NameOf(V011_FCR_J.RANGE_TO2)).Value = _V11.RANGE_TO2
            spSheet1.Range(NameOf(V011_FCR_J.RANGE_TO3)).Value = _V11.RANGE_TO3
            spSheet1.Range(NameOf(V011_FCR_J.RANGE_TO4)).Value = _V11.RANGE_TO4
            spSheet1.Range(NameOf(V011_FCR_J.RANGE_TO5)).Value = _V11.RANGE_TO5
            spSheet1.Range(NameOf(V011_FCR_J.RANGE_TO6)).Value = _V11.RANGE_TO6
            spSheet1.Range(NameOf(V011_FCR_J.KOKYAKU_NOUNYU_NAIYOU)).Value = _V11.KOKYAKU_NOUNYU_NAIYOU
            spSheet1.Range(NameOf(V011_FCR_J.KOKYAKU_NOUNYU_YMD)).Value = _V11.KOKYAKU_NOUNYU_YMD
            spSheet1.Range(NameOf(V011_FCR_J.ZAIKO_SIKAKE_NAIYOU)).Value = _V11.ZAIKO_SIKAKE_NAIYOU
            spSheet1.Range(NameOf(V011_FCR_J.ZAIKO_SIKAKE_YMD)).Value = _V11.ZAIKO_SIKAKE_YMD
            spSheet1.Range(NameOf(V011_FCR_J.OTHER_PROCESS_NAIYOU)).Value = _V11.OTHER_PROCESS_NAIYOU
            spSheet1.Range(NameOf(V011_FCR_J.OTHER_PROCESS_YMD)).Value = _V11.OTHER_PROCESS_YMD

            strYMDHNS = _V003_SYONIN_J_KANRI_List.Where(Function(r) r.SYONIN_JUN = ENM_FCR_STAGE._10_�N������ And r.SYONIN_HANTEI_KB = ENM_SYONIN_HANTEI_KB._1_���F).FirstOrDefault?.SYONIN_YMDHNS
            If Not strYMDHNS.IsNulOrWS Then
                spSheet1.Range("SYONIN_YMD" & ENM_FCR_STAGE._10_�N������).Value = DateTime.ParseExact(strYMDHNS, "yyyyMMddHHmmss", Nothing).ToString("yyyy/MM/dd")
                spSheet1.Range("SYONIN_NAME" & ENM_FCR_STAGE._10_�N������).Value = _V003_SYONIN_J_KANRI_List.Where(Function(r) r.SYONIN_JUN = ENM_FCR_STAGE._10_�N������).FirstOrDefault?.UPD_SYAIN_NAME
            End If

            strYMDHNS = _V003_SYONIN_J_KANRI_List.Where(Function(r) r.SYONIN_JUN = ENM_FCR_STAGE._20_�i��_���� And r.SYONIN_HANTEI_KB = ENM_SYONIN_HANTEI_KB._1_���F).FirstOrDefault?.SYONIN_YMDHNS
            If Not strYMDHNS.IsNulOrWS Then
                spSheet1.Range("SYONIN_YMD" & ENM_FCR_STAGE._20_�i��_����).Value = DateTime.ParseExact(strYMDHNS, "yyyyMMddHHmmss", Nothing).ToString("yyyy/MM/dd")
                spSheet1.Range("SYONIN_NAME" & ENM_FCR_STAGE._20_�i��_����).Value = _V003_SYONIN_J_KANRI_List.Where(Function(r) r.SYONIN_JUN = ENM_FCR_STAGE._20_�i��_����).FirstOrDefault?.UPD_SYAIN_NAME
            End If

            strYMDHNS = _V003_SYONIN_J_KANRI_List.Where(Function(r) r.SYONIN_JUN = ENM_FCR_STAGE._30_�Ǘ�TL And r.SYONIN_HANTEI_KB = ENM_SYONIN_HANTEI_KB._1_���F).FirstOrDefault?.SYONIN_YMDHNS
            If Not strYMDHNS.IsNulOrWS Then
                spSheet1.Range("SYONIN_YMD" & ENM_FCR_STAGE._30_�Ǘ�TL).Value = DateTime.ParseExact(strYMDHNS, "yyyyMMddHHmmss", Nothing).ToString("yyyy/MM/dd")
                spSheet1.Range("SYONIN_NAME" & ENM_FCR_STAGE._30_�Ǘ�TL).Value = _V003_SYONIN_J_KANRI_List.Where(Function(r) r.SYONIN_JUN = ENM_FCR_STAGE._30_�Ǘ�TL).FirstOrDefault?.UPD_SYAIN_NAME
            End If

            strYMDHNS = _V003_SYONIN_J_KANRI_List.Where(Function(r) r.SYONIN_JUN = ENM_FCR_STAGE._40_���ZTL And r.SYONIN_HANTEI_KB = ENM_SYONIN_HANTEI_KB._1_���F).FirstOrDefault?.SYONIN_YMDHNS
            If Not strYMDHNS.IsNulOrWS Then
                spSheet1.Range("SYONIN_YMD" & ENM_FCR_STAGE._40_���ZTL).Value = DateTime.ParseExact(strYMDHNS, "yyyyMMddHHmmss", Nothing).ToString("yyyy/MM/dd")
                spSheet1.Range("SYONIN_NAME" & ENM_FCR_STAGE._40_���ZTL).Value = _V003_SYONIN_J_KANRI_List.Where(Function(r) r.SYONIN_JUN = ENM_FCR_STAGE._40_���ZTL).FirstOrDefault?.UPD_SYAIN_NAME
            End If

            strYMDHNS = _V003_SYONIN_J_KANRI_List.Where(Function(r) r.SYONIN_JUN = ENM_FCR_STAGE._50_�c��TL And r.SYONIN_HANTEI_KB = ENM_SYONIN_HANTEI_KB._1_���F).FirstOrDefault?.SYONIN_YMDHNS
            If Not strYMDHNS.IsNulOrWS Then
                spSheet1.Range("SYONIN_YMD" & ENM_FCR_STAGE._50_�c��TL).Value = DateTime.ParseExact(strYMDHNS, "yyyyMMddHHmmss", Nothing).ToString("yyyy/MM/dd")
                spSheet1.Range("SYONIN_NAME" & ENM_FCR_STAGE._50_�c��TL).Value = _V003_SYONIN_J_KANRI_List.Where(Function(r) r.SYONIN_JUN = ENM_FCR_STAGE._50_�c��TL).FirstOrDefault?.UPD_SYAIN_NAME
            End If

            strYMDHNS = _V003_SYONIN_J_KANRI_List.Where(Function(r) r.SYONIN_JUN = ENM_FCR_STAGE._60_�i�؉ے� And r.SYONIN_HANTEI_KB = ENM_SYONIN_HANTEI_KB._1_���F).FirstOrDefault?.SYONIN_YMDHNS
            If Not strYMDHNS.IsNulOrWS Then
                spSheet1.Range("SYONIN_YMD" & ENM_FCR_STAGE._60_�i�؉ے�).Value = DateTime.ParseExact(strYMDHNS, "yyyyMMddHHmmss", Nothing).ToString("yyyy/MM/dd")
                spSheet1.Range("SYONIN_NAME" & ENM_FCR_STAGE._60_�i�؉ے�).Value = _V003_SYONIN_J_KANRI_List.Where(Function(r) r.SYONIN_JUN = ENM_FCR_STAGE._60_�i�؉ے�).FirstOrDefault?.UPD_SYAIN_NAME
            End If

            '-----�t�@�C���ۑ�
            spSheet1.SaveAs(filename:=strFilePath, fileFormat:=SpreadsheetGear.FileFormat.Excel8)
            spWorkbook.WorkbookSet.ReleaseLock()

            ''-----Spire�� ����PDF���s����Ȃ炱����
            'Dim workbook As New Spire.Xls.Workbook
            'workbook.LoadFromFile(strFilePath)
            'Dim pdfFilePath As String
            'pdfFilePath = System.IO.Path.GetDirectoryName(strFilePath) & "\" & System.IO.Path.GetFileNameWithoutExtension(strFilePath) & ".pdf"
            'workbook.SaveToFile(pdfFilePath, Spire.Xls.FileFormat.PDF)
            '''PDF�\��
            'System.Diagnostics.Process.Start(pdfFilePath)

            Call FunOpenWorkbook(strFilePath)

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

#Region "�C��"

    Private Function OpenFormEdit() As Boolean
        Dim frmDLG As New FrmG0020
        Dim dlgRET As DialogResult

        Try
            frmDLG.PrSYONIN_HOKOKUSYO_ID = Context.ENM_SYONIN_HOKOKUSYO_ID._1_NCR
            frmDLG.PrHOKOKU_NO = _D003_NCR_J.HOKOKU_NO
            frmDLG.PrBUMON_KB = _D003_NCR_J.BUMON_KB
            frmDLG.PrBUHIN_BANGO = _D003_NCR_J.BUHIN_BANGO
            frmDLG.PrKISO_YMD = DateTime.ParseExact(_D003_NCR_J.ADD_YMD, "yyyyMMdd", Nothing).ToString("yyyy/MM/dd")
            frmDLG.PrKISYU_NAME = tblKISYU.AsEnumerable.Where(Function(r) r.Field(Of Integer)("VALUE") = _D003_NCR_J.KISYU_ID).FirstOrDefault?.Item("DISP")
            frmDLG.PrCurrentStage = Me.PrCurrentStage

            dlgRET = frmDLG.ShowDialog(Me)

            If dlgRET = Windows.Forms.DialogResult.OK Then
                PrRIYU = frmDLG.PrRIYU
                Me.DialogResult = DialogResult.OK
                Me.Close()
                Return True
            Else
                Return False
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
                    If .Text.Length = 0 OrElse .Text.Substring(0, .Text.IndexOf("(")).IsNulOrWS Then
                        .Text = ""
                        .Visible = False
                    End If
                End With
            Next intFunc

            If FunblnOwnCreated(Context.ENM_SYONIN_HOKOKUSYO_ID._3_FCR, PrHOKOKU_NO, PrCurrentStage) Then '
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
                '�J�����g�X�e�[�W�����g�̒S���łȂ��ꍇ�͖���
                cmdFunc1.Enabled = False
                cmdFunc2.Enabled = False
                cmdFunc4.Enabled = False
                cmdFunc5.Enabled = False

                dtUPD_YMD.ReadOnly = True

                MyBase.ToolTip.SetToolTip(Me.cmdFunc5, "�o�^����������܂���")

                '#52 �Ǘ��Ҍ��������ꍇ
                Dim blnIsAdmin As Boolean = IsSysAdminUser(pub_SYAIN_INFO.SYAIN_ID)
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

            If PrCurrentStage = ENM_FCR_STAGE._999_Closed Then

                '#181
                If IsEditingClosed Then
                    cmdFunc1.Enabled = True
                    cmdFunc1.Text = "�ۑ�(F1)"
                Else
                    cmdFunc1.Enabled = False
                    cmdFunc1.Text = "�ꎞ�ۑ�(F1)"
                End If

                cmdFunc2.Enabled = False
                cmdFunc4.Enabled = False
                cmdFunc5.Enabled = False
                MyBase.ToolTip.SetToolTip(cmdFunc1, "Close�ς݂̂��ߎg�p�o���܂���")
                MyBase.ToolTip.SetToolTip(cmdFunc2, "Close�ς݂̂��ߎg�p�o���܂���")
                MyBase.ToolTip.SetToolTip(cmdFunc4, "Close�ς݂̂��ߎg�p�o���܂���")
                MyBase.ToolTip.SetToolTip(cmdFunc5, "Close�ς݂̂��ߎg�p�o���܂���")
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

#Region "�\����Ј�"

    Private Sub CmbDestTANTO_Validating(sender As Object, e As System.ComponentModel.CancelEventArgs) Handles cmbDestTANTO.Validating


        Dim cmb As ComboboxEx = DirectCast(sender, ComboboxEx)
        IsValidated *= ErrorProvider.UpdateErrorInfo(cmb, cmb.IsSelected, String.Format(My.Resources.infoMsgRequireSelectOrInput, "�\����Ј�"))
    End Sub

#End Region

#Region "�w�b�_"

    Private Sub RsbtnST_CheckedChanged(sender As Object, e As EventArgs) Handles rsbtnST01.CheckedChanged,
                                                                        rsbtnST02.CheckedChanged,
                                                                        rsbtnST03.CheckedChanged,
                                                                        rsbtnST04.CheckedChanged,
                                                                        rsbtnST05.CheckedChanged,
                                                                        rsbtnST06.CheckedChanged

        Dim btn As RibbonShapeRadioButton = DirectCast(sender, RibbonShapeRadioButton)
        Dim intStageID As Integer = Val(btn.Name.Substring(7))
        tabSTAGE01.AutoScrollControlIntoView = True
        Select Case intStageID
            Case ENM_CAR_STAGE2._1_�N������ To ENM_CAR_STAGE2._7_�N���m�F_�i�؉ے�
                tabSTAGE01.ScrollControlIntoView(lblSETUMON_1)

                pnlFCR.BorderStyle = BorderStyle.FixedSingle
                pnlSYOCHI_KIROKU.BorderStyle = BorderStyle.None
                pnlZESEI_SYOCHI.BorderStyle = BorderStyle.None
                pnlSYOCHI_JISSI.BorderStyle = BorderStyle.None

            Case ENM_CAR_STAGE2._8_���u���{�L�^����, ENM_CAR_STAGE2._9_���u���{�m�F
                tabSTAGE01.ScrollControlIntoView(lblSYOCHI_KIROKUFlame)

                pnlFCR.BorderStyle = BorderStyle.None
                pnlSYOCHI_KIROKU.BorderStyle = BorderStyle.FixedSingle
                pnlZESEI_SYOCHI.BorderStyle = BorderStyle.None
                pnlSYOCHI_JISSI.BorderStyle = BorderStyle.None

            Case ENM_CAR_STAGE2._10_�����L�����L�� To ENM_CAR_STAGE2._12_�����L�����m�F_�i��TL
                tabSTAGE01.ScrollControlIntoView(lblZESEI_SYOCHIFlame)

                pnlFCR.BorderStyle = BorderStyle.None
                pnlSYOCHI_KIROKU.BorderStyle = BorderStyle.None
                pnlZESEI_SYOCHI.BorderStyle = BorderStyle.FixedSingle
                pnlSYOCHI_JISSI.BorderStyle = BorderStyle.None

            Case ENM_CAR_STAGE2._13_�����L�����m�F_�i�ؒS���ے�
                tabSTAGE01.ScrollControlIntoView(lblSTAGEFlame13)
                pnlFCR.BorderStyle = BorderStyle.None
                pnlSYOCHI_KIROKU.BorderStyle = BorderStyle.None
                pnlZESEI_SYOCHI.BorderStyle = BorderStyle.None
                pnlSYOCHI_JISSI.BorderStyle = BorderStyle.FixedSingle

        End Select
        tabSTAGE01.AutoScrollControlIntoView = False

    End Sub

    Private Sub tabSTAGE01_Click(sender As Object, e As EventArgs) Handles tabSTAGE01.Click
        sender.Focus
    End Sub

    Private Sub RbtnSEKKEI_TANTO_YOHI_YES_CheckedChanged(sender As Object, e As EventArgs) 'Handles rbtnSEKKEI_TANTO_YOHI_YES.CheckedChanged
        _D005_CAR_J._KAITO_23 = 1
        'mtxNextStageName.Text = FunGetStageName(Context.ENM_SYONIN_HOKOKUSYO_ID._2_CAR, FunGetNextSYONIN_JUN(PrCurrentStage))
        'Dim dt As DataTable = FunGetSYONIN_SYOZOKU_SYAIN(_V002_NCR_J.BUMON_KB, Context.ENM_SYONIN_HOKOKUSYO_ID._2_CAR, FunGetNextSYONIN_JUN(PrCurrentStage))
        'cmbDestTANTO.SetDataSource(dt, ENM_COMBO_SELECT_VALUE_TYPE._0_Required)
    End Sub

    Private Sub RbtnSEKKEI_TANTO_YOHI_NO_CheckedChanged(sender As Object, e As EventArgs) 'Handles rbtnSEKKEI_TANTO_YOHI_NO.CheckedChanged
        _D005_CAR_J._KAITO_23 = 0
        'mtxNextStageName.Text = FunGetStageName(Context.ENM_SYONIN_HOKOKUSYO_ID._2_CAR, FunGetNextSYONIN_JUN(PrCurrentStage))
        'Dim dt As DataTable = FunGetSYONIN_SYOZOKU_SYAIN(_V002_NCR_J.BUMON_KB, Context.ENM_SYONIN_HOKOKUSYO_ID._2_CAR, FunGetNextSYONIN_JUN(PrCurrentStage))
        'cmbDestTANTO.SetDataSource(dt, ENM_COMBO_SELECT_VALUE_TYPE._0_Required)
    End Sub

    Private Sub ChkSEKKEI_TANTO_YOHI_KB_CheckedChanged(sender As Object, e As EventArgs)
        'If chkSEKKEI_TANTO_YOHI_KB.Checked Then
        '    rbtnSEKKEI_TANTO_YOHI_YES.Checked = True
        'Else
        '    rbtnSEKKEI_TANTO_YOHI_NO.Checked = True
        'End If

    End Sub



#End Region

    Private Sub RbtnKOKYAKU_EIKYO_HANTEI_KB_CheckedChanged(sender As Object, e As EventArgs) Handles rbtnKOKYAKU_EIKYO_HANTEI_KB_T.CheckedChanged, rbtnKOKYAKU_EIKYO_HANTEI_KB_F.CheckedChanged

        Dim blnChecked As Boolean = rbtnKOKYAKU_EIKYO_HANTEI_KB_T.Checked

        If blnChecked Then
            cmbKOKYAKU_EIKYO_HANTEI_COMMENT.SelectedIndex = 0
        End If
        lblKOKYAKU_EIKYO_HANTEI_COMMENT.Visible = Not blnChecked
        cmbKOKYAKU_EIKYO_HANTEI_COMMENT.Visible = Not blnChecked

        txtKOKYAKU_EIKYO_NAIYO.Enabled = blnChecked
        txtKAKUNIN_SYUDAN.Enabled = blnChecked
        rbtnKOKYAKU_EIKYO_TUCHI_HANTEI_KB_T.Checked = False
        dtTUCHI_YMD.Enabled = blnChecked
        txtTUCHI_SYUDAN.Enabled = blnChecked
        txtHITUYO_TETUDUKI_ZIKO.Enabled = blnChecked
        txtKOKYAKU_EIKYO_ETC_COMMENT.Enabled = blnChecked

        txtKOKYAKU_EIKYO_NAIYO.Text = ""
        txtKAKUNIN_SYUDAN.Text = ""
        dtTUCHI_YMD.Value = ""
        txtTUCHI_SYUDAN.Text = ""
        txtHITUYO_TETUDUKI_ZIKO.Text = ""
        txtKOKYAKU_EIKYO_ETC_COMMENT.Text = ""

        pnlrbtnTUCHI.DisableContaints(blnChecked, PanelEx.ENM_PROPERTY._1_Enabled)
        pnlSYOCHI_KIROKU.DisableContaints(blnChecked, PanelEx.ENM_PROPERTY._1_Enabled)
        pnlZESEI_SYOCHI.DisableContaints(blnChecked, PanelEx.ENM_PROPERTY._1_Enabled)
        PnlPROCESS.DisableContaints(blnChecked, PanelEx.ENM_PROPERTY._1_Enabled)
        pnlSYOCHI_JISSI.DisableContaints(blnChecked, PanelEx.ENM_PROPERTY._1_Enabled)

        cmbKISYU1.SelectedIndex = 0
        cmbKISYU2.SelectedIndex = 0
        cmbKISYU3.SelectedIndex = 0
        cmbKISYU4.SelectedIndex = 0
        cmbKISYU5.SelectedIndex = 0
        cmbKISYU6.SelectedIndex = 0

        txtBUHIN_INFO1.Text = ""
        txtBUHIN_INFO2.Text = ""
        txtBUHIN_INFO3.Text = ""
        txtBUHIN_INFO4.Text = ""
        txtBUHIN_INFO5.Text = ""
        txtBUHIN_INFO6.Text = ""
        nupSURYO1.Value = 0
        nupSURYO2.Value = 0
        nupSURYO3.Value = 0
        nupSURYO4.Value = 0
        nupSURYO5.Value = 0
        nupSURYO6.Value = 0
        txtFROM1.Text = ""
        txtFROM2.Text = ""
        txtFROM3.Text = ""
        txtFROM4.Text = ""
        txtFROM5.Text = ""
        txtFROM6.Text = ""

        txtTO1.Text = ""
        txtTO2.Text = ""
        txtTO3.Text = ""
        txtTO4.Text = ""
        txtTO5.Text = ""
        txtTO6.Text = ""

        rbtnOTHER_PROCESS_INFLUENCE_KB_F.Checked = True
        rbtnFOLLOW_PROCESS_OUTFLOW_KB_F.Checked = True

        txtKOKYAKU_NOUNYU_NAIYOU.Text = ""
        txtZAIKO_SIKAKE_NAIYOU.Text = ""
        txtOTHER_PROCESS_NAIYOU.Text = ""
        dtKOKYAKU_NOUNYU_YMD.Value = ""
        dtZAIKO_SIKAKE_YMD.Value = ""
        dtOTHER_PROCESS_YMD.Value = ""
    End Sub

    Private Sub RbtnKOKYAKU_EIKYO_TUCHI_HANTEI_KB_CheckedChanged(sender As Object, e As EventArgs) Handles rbtnKOKYAKU_EIKYO_TUCHI_HANTEI_KB_T.CheckedChanged, rbtnKOKYAKU_EIKYO_TUCHI_HANTEI_KB_F.CheckedChanged

        Dim blnChecked As Boolean = rbtnKOKYAKU_EIKYO_TUCHI_HANTEI_KB_T.Checked

        dtTUCHI_YMD.Enabled = blnChecked
        txtTUCHI_SYUDAN.Enabled = blnChecked
        txtHITUYO_TETUDUKI_ZIKO.Enabled = blnChecked

    End Sub

    Private Sub CmbKISYU1_Validated(sender As Object, e As EventArgs) Handles cmbKISYU1.Validated
        Dim cmb = DirectCast(sender, ComboboxEx)
        If Not cmb.Text.IsNulOrWS Then
            pnlInfo2.Enabled = True
        Else
            pnlInfo2.Enabled = False
            cmbKISYU2.SelectedIndex = 0
            txtBUHIN_INFO2.Text = ""
            nupSURYO2.Value = 0
            txtFROM2.Text = ""
            txtTO2.Text = ""
        End If

    End Sub

    Private Sub CmbKISYU2_Validated(sender As Object, e As EventArgs) Handles cmbKISYU2.Validated
        Dim cmb = DirectCast(sender, ComboboxEx)
        If Not cmb.Text.IsNulOrWS Then
            pnlInfo3.Enabled = True
        Else
            pnlInfo3.Enabled = False
            cmbKISYU3.SelectedIndex = 0
            txtBUHIN_INFO3.Text = ""
            nupSURYO3.Value = 0
            txtFROM3.Text = ""
            txtTO3.Text = ""
        End If
    End Sub

    Private Sub CmbKISYU4_Validated(sender As Object, e As EventArgs) Handles cmbKISYU4.Validated
        Dim cmb = DirectCast(sender, ComboboxEx)
        If Not cmb.Text.IsNulOrWS Then
            pnlInfo5.Enabled = True
        Else
            pnlInfo5.Enabled = False
            cmbKISYU5.SelectedIndex = 0
            txtBUHIN_INFO5.Text = ""
            nupSURYO5.Value = 0
            txtFROM5.Text = ""
            txtTO5.Text = ""
        End If
    End Sub

    Private Sub CmbKISYU5_Validated(sender As Object, e As EventArgs) Handles cmbKISYU5.Validated
        Dim cmb = DirectCast(sender, ComboboxEx)
        If Not cmb.Text.IsNulOrWS Then
            pnlInfo6.Enabled = True
        Else
            pnlInfo6.Enabled = False
            cmbKISYU6.SelectedIndex = 0
            txtBUHIN_INFO6.Text = ""
            nupSURYO6.Value = 0
            txtFROM6.Text = ""
            txtTO6.Text = ""
        End If
    End Sub

#End Region

#Region "���[�J���֐�"

#Region "�o�C���f�B���O"

    Private Function FunSetBinding() As Boolean

        Try

            Return True
        Catch ex As Exception
            Throw
            Return False
        End Try
    End Function

#End Region

#Region "�������[�h�ʉ�ʏ�����"

    Private Function FunInitializeControls() As Boolean

        Try
            If Not FunSetBinding() Then Return False
            If Not FunSetModel() Then Return False

            '�i�r�Q�[�g�����N�I��
            If PrCurrentStage = ENM_CAR_STAGE._999_Closed Then
                rsbtnST99.Checked = True
            Else
                Dim rbtn As RibbonShapeRadioButton = DirectCast(flpnlStageIndex.Controls("rsbtnST" & (PrCurrentStage / 10).ToString("00")), RibbonShapeRadioButton)
                rbtn.Checked = True
            End If

            mtxHOKUKO_NO.Text = _V011_FCR_J.HOKOKU_NO
            mtxBUMON_KB.Text = _V011_FCR_J.BUMON_NAME
            mtxKISYU.Text = _V011_FCR_J.KISYU_NAME
            mtxFUTEKIGO_KB.Text = _V011_FCR_J.FUTEKIGO_NAME
            mtxFUTEKIGO_S_KB.Text = _V011_FCR_J.FUTEKIGO_S_NAME
            mtxADD_SYAIN_NAME_NCR.Text = _V011_FCR_J.ADD_SYAIN_NAME_NCR
            mtxADD_SYAIN_NAME.Text = _V011_FCR_J.ADD_SYAIN_NAME
            dtFUTEKIGO_HASSEI_YMD.Value = _V011_FCR_J.HASSEI_YMD

            rbtnFOLLOW_PROCESS_OUTFLOW_KB_T.Checked = (_V011_FCR_J.FOLLOW_PROCESS_OUTFLOW_KB = "1")
            rbtnKOKYAKU_EIKYO_HANTEI_KB_T.Checked = (_V011_FCR_J.KOKYAKU_EIKYO_HANTEI_KB = "1")
            rbtnKOKYAKU_EIKYO_TUCHI_HANTEI_KB_T.Checked = (_V011_FCR_J.KOKYAKU_EIKYO_TUCHI_HANTEI_KB = "1")
            rbtnOTHER_PROCESS_INFLUENCE_KB_T.Checked = (_V011_FCR_J.OTHER_PROCESS_INFLUENCE_KB = "1")

            mtxCurrentStageName.Text = FunGetLastStageName(Context.ENM_SYONIN_HOKOKUSYO_ID._3_FCR, _V011_FCR_J.HOKOKU_NO)

            mtxNextStageName.Text = FunGetStageName(Context.ENM_SYONIN_HOKOKUSYO_ID._3_FCR, FunGetNextSYONIN_JUN(PrCurrentStage))

            Dim blnOwn As Boolean = FunblnOwnCreated(Context.ENM_SYONIN_HOKOKUSYO_ID._3_FCR, _V011_FCR_J.HOKOKU_NO, PrCurrentStage)
            'tabSTAGE07.Enabled = blnOwn

            _tabPageManager = New TabPageManager(TabSTAGE)

            Select Case PrCurrentStage
                Case ENM_FCR_STAGE._999_Closed
                    pnlFCR.DisableContaints(IsEditingClosed, PanelEx.ENM_PROPERTY._2_ReadOnly)
                    pnlSYOCHI_KIROKU.DisableContaints(IsEditingClosed, PanelEx.ENM_PROPERTY._2_ReadOnly)
                    pnlZESEI_SYOCHI.DisableContaints(IsEditingClosed, PanelEx.ENM_PROPERTY._2_ReadOnly)
                    PnlPROCESS.DisableContaints(IsEditingClosed, PanelEx.ENM_PROPERTY._2_ReadOnly)
                    pnlSYOCHI_JISSI.DisableContaints(IsEditingClosed, PanelEx.ENM_PROPERTY._2_ReadOnly)

                Case Else
            End Select

            '��ʏ㕔�̃J�����g�X�e�[�W�J�ڃ{�^��
            For Each val As Integer In [Enum].GetValues(GetType(ENM_FCR_STAGE2))
                flpnlStageIndex.Controls("rsbtnST" & val.ToString("00")).Enabled = (PrCurrentStage / 10) >= val
                If (PrCurrentStage / 10) >= val Then
                Else
                    flpnlStageIndex.Controls("rsbtnST" & val.ToString("00")).BackColor = Color.Silver
                End If
            Next val
            'rsbtnST05.Enabled = CBool(_V005_CAR_J.KAITO_23)
            If _V011_FCR_J.CLOSE_FG = False Then
                flpnlStageIndex.Controls("rsbtnST99").Enabled = False
                flpnlStageIndex.Controls("rsbtnST99").BackColor = Color.Silver
            End If

            '�ŏI�X�e�[�W�̏ꍇ�A�\����S���җ��͔�\��
            If PrCurrentStage >= ENM_FCR_STAGE._60_�i�؉ے� Then
                lblDestTANTO.Visible = False
                cmbDestTANTO.Visible = False
            End If

            Dim _V003 As New V003_SYONIN_J_KANRI
            _V003 = _V003_SYONIN_J_KANRI_List.AsEnumerable.
                                Where(Function(r) r.SYONIN_JUN = PrCurrentStage).
                                FirstOrDefault
            If _V003 IsNot Nothing Then
                If Not _V003.RIYU.IsNulOrWS Then lbl_Modoshi_Riyu.Visible = True
                If _V003.SASIMODOSI_FG Then
                    lbl_Modoshi_Riyu.Text = "���ߗ��R�F" & _V003.RIYU
                Else
                    '�]����
                    lbl_Modoshi_Riyu.Text = "�]�����R�F" & _V003.RIYU
                End If

                Dim dtSYONIN_YMD As Date
                If DateTime.TryParseExact(_V003.SYONIN_YMDHNS, "yyyyMMddHHmmss", Nothing, Nothing, dtSYONIN_YMD) Then
                    '_D004_SYONIN_J_KANRI.SYONIN_YMDHNS = _V003.SYONIN_YMDHNS
                    dtUPD_YMD.ValueNonFormat = dtSYONIN_YMD.ToString("yyyyMMdd")
                Else
                    '_D004_SYONIN_J_KANRI.SYONIN_YMDHNS = Now.ToString("yyyyMMddHHmmss")
                    dtUPD_YMD.Text = Now.ToString("yyyy/MM/dd")
                End If
            End If



            ErrorProvider.ClearError(cmbDestTANTO)

            Return True
        Catch ex As Exception
            EM.ErrorSyori(ex, False, conblnNonMsg)
            Return False
        End Try
    End Function

    Private Function FunSetModel() As Boolean
        Try
            _V003_SYONIN_J_KANRI_List = FunGetV003Model(Context.ENM_SYONIN_HOKOKUSYO_ID._3_FCR, PrHOKOKU_NO)

            _V011_FCR_J.Clear()
            _V011_FCR_J = FunGetV011Model(PrHOKOKU_NO)

            '�f�[�^�\�[�X�ݒ�
            Dim dt As DataTable = FunGetSYOZOKU_SYAIN(_V011_FCR_J.BUMON_KB)

            dt = FunGetSYONIN_SYOZOKU_SYAIN(_V011_FCR_J.BUMON_KB, Context.ENM_SYONIN_HOKOKUSYO_ID._3_FCR, FunGetNextSYONIN_JUN(PrCurrentStage))
            cmbDestTANTO.SetDataSource(dt, ENM_COMBO_SELECT_VALUE_TYPE._0_Required)

            '#128
            If PrCurrentStage = ENM_CAR_STAGE._10_�N������ AndAlso Not IsRemanded(_V011_FCR_J.HOKOKU_NO) Then
                _V011_FCR_J.ADD_SYAIN_ID = pub_SYAIN_INFO.SYAIN_ID
            End If

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
            '�t���O���Z�b�g
            IsValidated = True
            '-----����
            If enmSAVE_MODE = ENM_SAVE_MODE._2_���F�\�� Then
                Call CmbDestTANTO_Validating(cmbDestTANTO, Nothing)
            End If

            If cmbKOKYAKU_EIKYO_HANTEI_COMMENT.Visible Then
                IsValidated *= ErrorProvider.UpdateErrorInfo(cmbKOKYAKU_EIKYO_HANTEI_COMMENT, Not cmbKOKYAKU_EIKYO_HANTEI_COMMENT.Text.IsNulOrWS, String.Format(My.Resources.infoMsgRequireSelectOrInput, "�ۂ̗��R"))
            End If

            '��L�e��Validating�C�x���g�Ńt���O���X�V���A�S��OK�̏ꍇ��True
            Return IsValidated
        Catch ex As Exception
            EM.ErrorSyori(ex, False, conblnNonMsg)
            Return False
        End Try
    End Function

    Private Sub TxtKAITO_21_Validating(sender As Object, e As System.ComponentModel.CancelEventArgs)
        Dim txt As TextBoxEx = DirectCast(sender, TextBoxEx)

        IsValidated *= ErrorProvider.UpdateErrorInfo(txt, txt.ReadOnly OrElse Not txt.Text.IsNulOrWS, String.Format(My.Resources.infoMsgRequireSelectOrInput, "�C�����}���u:���e"))

    End Sub

    Private Sub TxtKAITO_22_Validating(sender As Object, e As System.ComponentModel.CancelEventArgs) Handles txtTUCHI_SYUDAN.Validating, txtHITUYO_TETUDUKI_ZIKO.Validating, txtTO1.Validating, txtFROM1.Validating
        Dim txt As TextBoxEx = DirectCast(sender, TextBoxEx)

        IsValidated *= ErrorProvider.UpdateErrorInfo(txt, txt.ReadOnly OrElse Not txt.Text.IsNulOrWS, String.Format(My.Resources.infoMsgRequireSelectOrInput, "�������u:���e"))

    End Sub

    Private Sub �ctKAITO_4_Validating(sender As Object, e As System.ComponentModel.CancelEventArgs)
        Dim dtx As DateTextBoxEx = DirectCast(sender, DateTextBoxEx)

        IsValidated *= ErrorProvider.UpdateErrorInfo(dtx, Not dtx.ValueNonFormat.IsNulOrWS, String.Format(My.Resources.infoMsgRequireSelectOrInput, "�C�����}���u:���܂�"))

    End Sub

    Private Sub CmbKAITO_5_Validating(sender As Object, e As System.ComponentModel.CancelEventArgs)
        Dim cmb As ComboboxEx = DirectCast(sender, ComboboxEx)

        IsValidated *= ErrorProvider.UpdateErrorInfo(cmb, cmb.IsSelected, String.Format(My.Resources.infoMsgRequireSelectOrInput, "�C�����}���u:�N��"))

    End Sub

    Private Sub KAITO_678_Validating(sender As Object, e As System.ComponentModel.CancelEventArgs) Handles dtTUCHI_YMD.Validating
        'Dim mtxGOKI As MaskedTextBoxEx = mtxKAITO_6
        'Dim mtxLOT As MaskedTextBoxEx = mtxKAITO_7
        'Dim dtYMD As DateTextBoxEx = dtKAITO_8

        'Dim result As Boolean = Not (mtxGOKI.Text.IsNulOrWS AndAlso mtxLOT.Text.IsNulOrWS AndAlso dtYMD.ValueNonFormat.IsNulOrWS)
        'IsValidated *= ErrorProvider.UpdateErrorInfo(mtxGOKI, result, String.Format(My.Resources.infoMsgRequireSelectOrInput, "�C�����}���u:�L�����@�ELOT�E���t�̂��Âꂩ�̓��͂��K�v�ł�"))
        'IsValidated *= ErrorProvider.UpdateErrorInfo(mtxLOT, result, String.Format(My.Resources.infoMsgRequireSelectOrInput, "�C�����}���u:�L�����@�ELOT�E���t�̂��Âꂩ�̓��͂��K�v�ł�"))
        'IsValidated *= ErrorProvider.UpdateErrorInfo(dtYMD, result, String.Format(My.Resources.infoMsgRequireSelectOrInput, "�C�����}���u:�L�����@�ELOT�E���t�̂��Âꂩ�̓��͂��K�v�ł�"))

    End Sub

    Private Sub DtKAITO_9_Validating(sender As Object, e As System.ComponentModel.CancelEventArgs)
        Dim dtx As DateTextBoxEx = DirectCast(sender, DateTextBoxEx)

        IsValidated *= ErrorProvider.UpdateErrorInfo(dtx, Not dtx.ValueNonFormat.IsNulOrWS, String.Format(My.Resources.infoMsgRequireSelectOrInput, "�������u:���܂�"))

    End Sub

    Private Sub cmbKAITO_10_Validating(sender As Object, e As System.ComponentModel.CancelEventArgs)
        Dim cmb As ComboboxEx = DirectCast(sender, ComboboxEx)

        IsValidated *= ErrorProvider.UpdateErrorInfo(cmb, cmb.IsSelected, String.Format(My.Resources.infoMsgRequireSelectOrInput, "�������u:�N��"))

    End Sub

    Private Sub KAITO_111213_Validating(sender As Object, e As System.ComponentModel.CancelEventArgs)
        'Dim mtxGOKI As MaskedTextBoxEx = mtxKAITO_11
        'Dim mtxLOT As MaskedTextBoxEx = mtxKAITO_12
        'Dim dtYMD As DateTextBoxEx = dtKAITO_13

        'Dim result As Boolean = Not (mtxGOKI.Text.IsNulOrWS AndAlso mtxLOT.Text.IsNulOrWS AndAlso dtYMD.ValueNonFormat.IsNulOrWS)
        'IsValidated *= ErrorProvider.UpdateErrorInfo(mtxGOKI, result, String.Format(My.Resources.infoMsgRequireSelectOrInput, "�������u:�L�����@�ELOT�E���t�̂��Âꂩ�̓��͂��K�v�ł�"))
        'IsValidated *= ErrorProvider.UpdateErrorInfo(mtxLOT, result, String.Format(My.Resources.infoMsgRequireSelectOrInput, "�������u:�L�����@�ELOT�E���t�̂��Âꂩ�̓��͂��K�v�ł�"))
        'IsValidated *= ErrorProvider.UpdateErrorInfo(dtYMD, result, String.Format(My.Resources.infoMsgRequireSelectOrInput, "�������u:�L�����@�ELOT�E���t�̂��Âꂩ�̓��͂��K�v�ł�"))

    End Sub

    Private Sub dtKAITO_16_Validating(sender As Object, e As System.ComponentModel.CancelEventArgs)
        Dim dtx As DateTextBoxEx = DirectCast(sender, DateTextBoxEx)

        IsValidated *= ErrorProvider.UpdateErrorInfo(dtx, dtx.ReadOnly OrElse Not dtx.ValueNonFormat.IsNulOrWS, String.Format(My.Resources.infoMsgRequireSelectOrInput, "�����W�J:���܂�"))

    End Sub

    Private Sub cmbKAITO_17_Validating(sender As Object, e As System.ComponentModel.CancelEventArgs)
        Dim cmb As ComboboxEx = DirectCast(sender, ComboboxEx)

        IsValidated *= ErrorProvider.UpdateErrorInfo(cmb, cmb.ReadOnly OrElse cmb.IsSelected, String.Format(My.Resources.infoMsgRequireSelectOrInput, "�����W�J:�N��"))

    End Sub

    Private Sub KAITO_181920_Validating(sender As Object, e As System.ComponentModel.CancelEventArgs)
        'Dim mtxGOKI As MaskedTextBoxEx = mtxKAITO_18
        'Dim mtxLOT As MaskedTextBoxEx = mtxKAITO_19
        'Dim dtYMD As DateTextBoxEx = dtKAITO_20

        'Dim result As Boolean = (mtxGOKI.ReadOnly OrElse Not (mtxGOKI.Text.IsNulOrWS AndAlso mtxLOT.Text.IsNulOrWS AndAlso dtYMD.ValueNonFormat.IsNulOrWS))
        'IsValidated *= ErrorProvider.UpdateErrorInfo(mtxGOKI, result, String.Format(My.Resources.infoMsgRequireSelectOrInput, "�����W�J:�L�����@�ELOT�E���t�̂��Âꂩ�̓��͂��K�v�ł�"))
        'IsValidated *= ErrorProvider.UpdateErrorInfo(mtxLOT, result, String.Format(My.Resources.infoMsgRequireSelectOrInput, "�����W�J:�L�����@�ELOT�E���t�̂��Âꂩ�̓��͂��K�v�ł�"))
        'IsValidated *= ErrorProvider.UpdateErrorInfo(dtYMD, result, String.Format(My.Resources.infoMsgRequireSelectOrInput, "�����W�J:�L�����@�ELOT�E���t�̂��Âꂩ�̓��͂��K�v�ł�"))

    End Sub

    Private Sub mtxGOKI_Validating(sender As Object, e As System.ComponentModel.CancelEventArgs)
        Dim mtx As MaskedTextBoxEx = DirectCast(sender, MaskedTextBoxEx)

        IsValidated *= ErrorProvider.UpdateErrorInfo(mtx, mtx.ReadOnly OrElse Not mtx.Text.IsNulOrWS, String.Format(My.Resources.infoMsgRequireSelectOrInput, "�������u�L�������r���[�F���@�ELOT"))

    End Sub

    Private Sub cmbKONPON_YOIN_TANTO_Validating(sender As Object, e As System.ComponentModel.CancelEventArgs)
        Dim cmb As ComboboxEx = DirectCast(sender, ComboboxEx)

        IsValidated *= ErrorProvider.UpdateErrorInfo(cmb, cmb.ReadOnly OrElse cmb.IsSelected, String.Format(My.Resources.infoMsgRequireSelectOrInput, "���́F��ƒS��"))

    End Sub

    Private Sub cmbKISEKI_KOTEI_Validating(sender As Object, e As System.ComponentModel.CancelEventArgs)
        Dim cmb As ComboboxEx = DirectCast(sender, ComboboxEx)

        IsValidated *= ErrorProvider.UpdateErrorInfo(cmb, cmb.ReadOnly OrElse cmb.IsSelected, String.Format(My.Resources.infoMsgRequireSelectOrInput, "���́F�A�ӍH��"))

    End Sub

    Private Sub �ctST13_Validating(sender As Object, e As System.ComponentModel.CancelEventArgs)
        Dim dtx As DateTextBoxEx = DirectCast(sender, DateTextBoxEx)

        IsValidated *= ErrorProvider.UpdateErrorInfo(dtx, Not dtx.ValueNonFormat.IsNulOrWS, String.Format(My.Resources.infoMsgRequireSelectOrInput, "�����L�����m�F:�m�F��"))

    End Sub

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
        sbSQL.Append($"SELECT")
        sbSQL.Append($" *")
        sbSQL.Append($" FROM {NameOf(V003_SYONIN_J_KANRI)} ")
        sbSQL.Append($" WHERE {NameOf(V003_SYONIN_J_KANRI.SYONIN_HOKOKUSYO_ID)}={intSYONIN_HOKOKUSYO_ID}")
        sbSQL.Append($" AND {NameOf(V003_SYONIN_J_KANRI.HOKOKU_NO)}='{strHOKOKU_NO.Trim}'")
        sbSQL.Append($" ORDER BY {NameOf(V003_SYONIN_J_KANRI.SYONIN_JUN)} DESC")
        Using DB As ClsDbUtility = DBOpen()
            dsList = DB.GetDataSet(sbSQL.ToString, conblnNonMsg)
        End Using

        With dsList.Tables(0)
            If .Rows.Count = 0 Then
                Return ""
            Else
                Return .Rows(0).Item(NameOf(V003_SYONIN_J_KANRI.SYONIN_NAIYO)) '.Rows(0).Item("SYONIN_JUN") & "." & .Rows(0).Item("SYONIN_NAIYO")
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
            Const stageLength As Integer = 10

            'If PrCurrentStage = ENM_CAR_STAGE._40_�N���m�F_���Y�Z�p And _D005_CAR_J.KAITO_23 = False Then
            '    '�X�e�[�W50�X�L�b�v
            '    Return intCurrentStageID + (stageLength * 2)
            'Else
            Select Case intCurrentStageID
                Case ENM_FCR_STAGE._60_�i�؉ے�, ENM_FCR_STAGE._999_Closed
                    Return ENM_FCR_STAGE._999_Closed
                Case Else
                    Return intCurrentStageID + stageLength
            End Select

            'End If
        Catch ex As Exception
            EM.ErrorSyori(ex, False, conblnNonMsg)
            Return 0
        End Try
    End Function

    Private Function IsRemanded(strHOKOKU_NO As String) As Boolean
        Dim sbSQL As New System.Text.StringBuilder
        Dim intRET As Integer

        If strHOKOKU_NO.IsNulOrWS Then
            Return False
        Else
            sbSQL.Remove(0, sbSQL.Length)
            sbSQL.Append($"SELECT")
            sbSQL.Append($" COUNT({NameOf(R004_CAR_SASIMODOSI.HOKOKU_NO)})")
            sbSQL.Append($" FROM {NameOf(R004_CAR_SASIMODOSI)} ")
            sbSQL.Append($" WHERE {NameOf(R004_CAR_SASIMODOSI.HOKOKU_NO)}='{strHOKOKU_NO}'")
            Using DB As ClsDbUtility = DBOpen()
                intRET = DB.ExecuteScalar(sbSQL.ToString, conblnNonMsg)
            End Using

            Return intRET > 0
        End If
    End Function

#End Region

End Class