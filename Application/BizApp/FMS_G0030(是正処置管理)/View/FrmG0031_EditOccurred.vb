Imports System.Threading.Tasks
Imports C1.Win.C1FlexGrid
Imports JMS_COMMON.ClsPubMethod
Imports MODEL
Imports D010 = MODEL.D010_FCCB_SUB_SYOCHI_KOMOKU
Imports D011 = MODEL.D011_FCCB_SUB_SIKAKE_BUHIN
Imports D012 = MODEL.D012_FCCB_SUB_SYOCHI_KAKUNIN

''' <summary>
''' FCCB�o�^���
''' </summary>
Public Class FrmG0031_EditOccurred

#Region "�萔�E�ϐ�"

    'Private _D009 As New D009_FCCB_J
    Private _V003_SYONIN_J_KANRI_List As New List(Of V003_SYONIN_J_KANRI)

    Private IsEditingClosed As Boolean
    Private IsInitializing As Boolean

    Private USER_GYOMU_KENGEN_LIST As New List(Of ENM_GYOMU_GROUP_ID)

    Private Flx2_DS_DB As DataTable
    Private Flx3_DS_DB As DataTable
    Private Flx4_DS_DB As DataTable

    Private dtBUFF As DateTime

    Private SYOCHI_KAKUNIN_Users As New List(Of (userId As Integer, YOHI_KAITO As String))

#End Region

#Region "�v���p�e�B"

    Public Property PrMODE As Integer

    ''' <summary>
    ''' �ꗗ�̑I���s�f�[�^
    ''' </summary>
    Public Property PrDataRow As DataRow

    '���݂̃X�e�[�W ���F��
    Public Property PrCurrentStage As Integer

    '�񍐏�No
    Public Property PrFCCB_NO As String

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
        MyBase.ToolTip.SetToolTip(Me.cmdFunc1, "���쌠��������܂���")
        MyBase.ToolTip.SetToolTip(Me.cmdFunc2, "���쌠��������܂���")
        MyBase.ToolTip.SetToolTip(Me.cmdFunc4, My.Resources.infoToolTipMsgNotFoundData)
        MyBase.ToolTip.SetToolTip(Me.cmdFunc5, My.Resources.infoToolTipMsgNotFoundData)
        MyBase.ToolTip.SetToolTip(Me.cmdFunc10, My.Resources.infoToolTipMsgNotFoundData)
        MyBase.ToolTip.SetToolTip(Me.cmdFunc11, My.Resources.infoToolTipMsgNotFoundData)

        cmbKISO_TANTO.NullValue = 0

        dtKISO.Nullable = True
        cmbSYOCHI_GM_TANTO.NullValue = 0
        cmbSYOCHI_SEKKEI_TANTO.NullValue = 0

        cmbSYOCHI_SEIGI_TANTO.NullValue = 0

    End Sub

#End Region

#Region "Form�֘A"

    'Load�C�x���g
    Private Async Sub FrmLoad(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        Try
            PrRIYU = ""
            IsInitializing = True

            Await Task.Run(
                Sub()
                    Me.Invoke(
                    Sub()
                        Me.Cursor = Cursors.WaitCursor

                        '-----�t�H�[�������ݒ�(�e�t�H�[������Ăяo��)
                        Call FunFormCommonSetting(pub_APP_INFO, pub_SYAIN_INFO, My.Application.Info.Version.ToString)
                        Using DB As ClsDbUtility = DBOpen()
                            lblTytle.Text = FunGetCodeMastaValue(DB, "PG_TITLE", Me.GetType.ToString)
                        End Using

                        '--- ���f���N���A
                        _D009.Clear()
                        _D004_SYONIN_J_KANRI.clear()

                        cmbBUMON.SetDataSource(tblBUMON.ExcludeDeleted, ENM_COMBO_SELECT_VALUE_TYPE._0_Required)
                        Dim blnIsAdmin As Boolean = IsSysAdminUser(pub_SYAIN_INFO.SYAIN_ID)
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
                                    'Err
                            End Select
                        End If

                        IsEditingClosed = HasEditingRight(pub_SYAIN_INFO.SYAIN_ID)

                        '-----��ʏ�����
                        Call FunInitializeControls(PrMODE)

                    End Sub)
                End Sub)
        Finally
            FunInitFuncButtonEnabled()
            Me.Cursor = Cursors.Default
            Me.WindowState = FormWindowState.Maximized
            IsInitializing = False
        End Try
    End Sub

    'Shown
    Private Sub Frm_Shown(sender As Object, e As EventArgs) Handles MyBase.Shown
        Me.Owner.Visible = False
    End Sub

    Private Sub Frm_Closed(sender As Object, e As EventArgs) Handles MyBase.Closed
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
                        If IsEditingClosed And PrCurrentStage = ENM_FCCB_STAGE._999_Closed Then

                            Call OpenFormEdit()
                            If PrRIYU.IsNulOrWS Then
                                Exit Sub
                            End If
                        Else
                            If MessageBox.Show("���͓��e��ۑ����܂����H", "�o�^�m�F", MessageBoxButtons.YesNo, MessageBoxIcon.Information) <> DialogResult.Yes Then Exit Sub
                        End If

                        If FunSAVE(ENM_SAVE_MODE._1_�ۑ�) Then
                            Me.DialogResult = DialogResult.OK
                            Dim strMsg As String = "���͓��e��ۑ����܂����B"

                            ''���̒S���҂��܂߂ĕK�{���ړ��͍ς݂̏ꍇ�AFCCB�c���ւ̐\�������ֈڍs
                            'Select Case PrCurrentStage
                            '    Case ENM_FCCB_STAGE._20_���u����������.Value
                            '        If IsInputRequired_DB() Then
                            '            If FunSendRequestMail(fromUserNAME:="FCCB�Ǘ��V�X�e��", toUserNAME:=cmbCM_TANTO.Text) Then
                            '                strMsg &= $"{vbCrLf}�܂��A�S�Ă̗v���͍��ڂ������������߁AFCCB�c���ɏ��u�\���𑗐M���܂����B"
                            '            End If
                            '        End If
                            'End Select

                            MessageBox.Show(strMsg, "�ۑ�����", MessageBoxButtons.OK, MessageBoxIcon.Information)
                        Else
                            MessageBox.Show("�ۑ������Ɏ��s���܂����B", "�ۑ����s", MessageBoxButtons.OK, MessageBoxIcon.Error)
                        End If
                    End If

                Case 2  '���F�\��

                    '���̓`�F�b�N
                    If FunCheckInput(ENM_SAVE_MODE._2_���F�\��) Then
                        Dim strMsg As String
                        If FunGetNextSYONIN_JUN(PrCurrentStage) = ENM_FCCB_STAGE._999_Closed Then
                            strMsg = "���F�ECLOSE���܂����H"
                        Else
                            strMsg = "���F�E�\�����܂����H"
                        End If

                        If MessageBox.Show(strMsg, "���F�E�\�������m�F", MessageBoxButtons.YesNo, MessageBoxIcon.Information) = DialogResult.Yes Then
                            If FunSAVE(ENM_SAVE_MODE._2_���F�\��) Then
                                If PrCurrentStage = ENM_FCCB_STAGE._60_���u���������m�F Then
                                    strMsg = "���F�ECLOSE���܂���"
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

                Case 4  '���c�v�ۊm�F�@���c�J�Òʒm���[�����M

                    If IsNeedMeeting() Then
                        If FunCheckInput(ENM_SAVE_MODE._1_�ۑ�) Then
                            If OpenFormSendMail() Then
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
                    Else
                        '���c�v�ۈ˗����[��
                        If MessageBox.Show("���c�v�ۈ˗����[���𑗐M���܂����H", "���[�����M�m�F", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes Then
                            If FunSendJudgeReplyMail(blnNonMessage:=True) Then
                                Dim imgDlg As New ImageDialog
                                imgDlg.Show("\\sv04\FMS\RESOURCE\sendmail_256.gif", 4000)
                            End If
                        End If
                    End If

                Case 5  '�����߂�

                    Call OpenFormSASIMODOSI()

                Case 10  '���

                    Call FunOpenReportFCCB()

                Case 11 '����
                    'Call ShowUnimplemented()
                    Call OpenFormHistory(Context.ENM_SYONIN_HOKOKUSYO_ID._4_FCCB, PrFCCB_NO)

                Case 12 '����
                    Me.Close()
                Case Else
            End Select
        Catch exDispose As ObjectDisposedException
            System.Console.WriteLine(exDispose.Message)
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

                    'If FunSAVE_D009(DB, enmSAVE_MODE) = False Then blnErr = True : Return False
                    If FunSAVE_FILE(DB) = False Then blnErr = True : Return False

                    If Not blnTENSO And PrCurrentStage < ENM_FCCB_STAGE._999_Closed Then
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

#Region "   �t�@�C���ۑ�"

    ''' <summary>
    ''' NCR�Y�t�t�@�C���ۑ�
    ''' </summary>
    ''' <param name="DB"></param>
    ''' <returns></returns>
    Private Function FunSAVE_FILE(ByRef DB As ClsDbUtility) As Boolean

        If _D009.FILE_PATH.IsNulOrWS Then
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
                    _D009.FILE_PATH = ""
                    Return True
                Else
                    Me.DialogResult = DialogResult.Abort
                    Return True
                End If
            Else
                Try
                    System.IO.Directory.CreateDirectory(strRootDir & _D009.FCCB_NO)

                    If Not _D009.FILE_PATH.IsNulOrWS AndAlso
                        Not System.IO.File.Exists(strRootDir & _D009.FCCB_NO.Trim & "\" & _D009.FILE_PATH) Then

                        If System.IO.File.Exists(lbltmpFile1.Links.Item(0).LinkData) Then
                            System.IO.File.Copy(lbltmpFile1.Links.Item(0).LinkData, strRootDir & _D009.FCCB_NO.Trim & "\" & _D009.FILE_PATH, True)
                        Else
                            Throw New IO.FileNotFoundException($"�Y�t�t�@�C��:{lbltmpFile1.Links.Item(0).LinkData}��������܂���B���̏ꏊ�ɖ߂����I���������Ă�������")
                        End If
                    End If

                    Return True
                Catch exNF As IO.FileNotFoundException
                    MessageBox.Show(exNF.Message, "�t�@�C�����݃`�F�b�N", MessageBoxButtons.OK, MessageBoxIcon.Error)
                    Return False
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

        Try

#Region "   CurrentStage"

            '-----�f�[�^���f���X�V
            _D004_SYONIN_J_KANRI.SYONIN_HOKOKUSYO_ID = Context.ENM_SYONIN_HOKOKUSYO_ID._4_FCCB
            _D004_SYONIN_J_KANRI.HOKOKU_NO = _D009.FCCB_NO
            _D004_SYONIN_J_KANRI.MAIL_SEND_FG = True
            _D004_SYONIN_J_KANRI.ADD_SYAIN_ID = pub_SYAIN_INFO.SYAIN_ID
            _D004_SYONIN_J_KANRI.ADD_YMDHNS = strSysDate

            If PrCurrentStage = ENM_FCCB_STAGE._10_�N������ Then
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

#End Region

#Region "   NextStage"

            '-----���F�\��
            Select Case enmSAVE_MODE
                Case ENM_SAVE_MODE._1_�ۑ�
                    '�ۑ����т̂�
                    Return True
                Case ENM_SAVE_MODE._2_���F�\��
                    _D004_SYONIN_J_KANRI.SYONIN_JUN = FunGetNextSYONIN_JUN(PrCurrentStage)
                    _D004_SYONIN_J_KANRI.SYONIN_YMDHNS = ""
                    _D004_SYONIN_J_KANRI.MAIL_SEND_FG = False
                    _D004_SYONIN_J_KANRI.SYONIN_HANTEI_KB = ENM_SYONIN_HANTEI_KB._0_�����F
                    _D004_SYONIN_J_KANRI.ADD_YMDHNS = strSysDate

                    '�X�e�[�W�ʏ��F����
                    Select Case PrCurrentStage
                        Case ENM_FCCB_STAGE._10_�N������

                        Case ENM_FCCB_STAGE._20_���u����������

                        Case ENM_FCCB_STAGE._30_�ύX�R�c

                        Case ENM_FCCB_STAGE._40_���u�m�F

                        Case ENM_FCCB_STAGE._50_���u��������
                            _D004_SYONIN_J_KANRI.SYAIN_ID = cmbSYOCHI_GM_TANTO.SelectedValue
                        Case ENM_FCCB_STAGE._60_���u���������m�F

                        Case Else
                            Throw New ArgumentException("�z��O�̏��F�X�e�[�W�ł�", PrCurrentStage)
                    End Select

                Case Else
                    'Err
                    Return False
            End Select

            '-----Close����
            If _D004_SYONIN_J_KANRI.SYONIN_JUN = ENM_FCCB_STAGE._999_Closed Then
                _D004_SYONIN_J_KANRI.SYONIN_HANTEI_KB = ENM_SYONIN_HANTEI_KB._1_���F
                _D004_SYONIN_J_KANRI.SYONIN_YMDHNS = strSysDate
            End If

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
                    If PrCurrentStage < ENM_FCCB_STAGE._60_���u���������m�F AndAlso FunSendRequestMail() Then
                        WL.WriteLogDat($"[DEBUG]FCCB �񍐏�NO:{_D009.FCCB_NO}�ASend Request Mail")
                    End If

                Case "UPDATE"

                Case Else
                    '-----�G���[���O�o��
                    Dim strErrMsg As String = My.Resources.ErrLogSqlExecutionFailure & sbSQL.ToString & "|" & sqlEx.Message
                    WL.WriteLogDat(strErrMsg)
                    Return False
            End Select

            WL.WriteLogDat($"[DEBUG]FCCB �񍐏�NO:{_D009.FCCB_NO}�AMERGE D004")

#End Region

            Return True
        Catch ex As Exception
            Throw
        End Try
    End Function

#End Region

#Region "���F�˗����[�����M"

    ''' <summary>
    ''' ���F�˗����[�����M
    ''' </summary>
    ''' <returns></returns>
    Private Function FunSendJudgeReplyMail(Optional toUserNAME As String = "", Optional fromUserNAME As String = "", Optional blnNonMessage As Boolean = False) As Boolean

        Try

            Dim strSubject As String = $"�yFCCB�L�^��-���c�v�ۊm�F�zFCCB-NO:{_D004_SYONIN_J_KANRI.HOKOKU_NO}"
            Dim strBody As String = <sql><![CDATA[
                �e��<br />
                <br />
        �@      FCCB�L�^���̋��c�v�ۈ˗������܂����̂őΉ������肢���܂��B<br />
                <br />
        �@�@        �y�� �� ���zFCCB<br />
        �@�@        �yFCCB-No�z{0}<br />
        �@�@        �y�N �� ���z{1}<br />
                <br />        �@�@
                FCCB�c��
                <br />
                <a href = "http://sv04:8000/CLICKONCE_FMS.application" > �V�X�e���N��</a><br />
                <br />
                �����̃��[���͔z�M��p�ł��B(�ԐM�ł��܂���)<br />
                �ԐM����ꍇ�́A�e�S���҂̃��[���A�h���X���g�p���ĉ������B<br />
                ]]></sql>.Value.Trim

            'http://sv116:8000/CLICKONCE_FMS.application?SYAIN_ID={8}&EXEPATH={9}&PARAMS={10}

            Dim dt As DateTime
            If DateTime.TryParse(_D009.ADD_YMDHNS, dt) Then
            Else
                dt = DateTime.ParseExact(_D009.ADD_YMDHNS, "yyyyMMddHHmmss", Nothing)
            End If

            strBody = String.Format(strBody,
                                _D004_SYONIN_J_KANRI.HOKOKU_NO,
                                dt.ToString("yyyy/MM/dd"))

            Dim ToUsers As New List(Of Integer)

            Dim sbSQL As New System.Text.StringBuilder
            Dim dsList As New DataSet

            sbSQL.Clear()
            sbSQL.Append($"SELECT")
            sbSQL.Append($" {NameOf(D012.TANTO_ID)}")
            sbSQL.Append($" FROM {NameOf(D012_FCCB_SUB_SYOCHI_KAKUNIN)} ")
            sbSQL.Append($" WHERE {NameOf(D012.FCCB_NO)}='{_D009.FCCB_NO}' ")
            sbSQL.Append($" AND {NameOf(D012.TANTO_ID)}<>0 ")
            sbSQL.Append($" AND RTRIM({NameOf(D012.KYOGI_YOHI_KAITO)})='' ")
            Using DB = DBOpen()
                dsList = DB.GetDataSet(sbSQL.ToString, conblnNonMsg)
            End Using

            For Each row As DataRow In dsList.Tables(0).Rows
                If Not ToUsers.Contains(row.Item(0).ToString.ToVal) Then
                    ToUsers.Add(row.Item(0).ToString.ToVal)
                End If
            Next

            If ToUsers.Count = 0 Then
                If Not blnNonMessage Then MessageBox.Show("���M�҂�������Ȃ����߁A�˗����[���𑗐M�ł��܂���", "�˗����[�����M", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Return False
            Else
                If FunSendMailFCCB(strSubject, strBody, ToUsers) Then
                    Return True
                Else
                    MessageBox.Show("���[�����M�Ɏ��s���܂����B", "���[�����M���s", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    Return False
                End If
            End If
        Catch ex As Exception
            Throw
        End Try
    End Function

#End Region

#Region "���F�˗����[�����M"

    ''' <summary>
    ''' ���F�˗����[�����M
    ''' </summary>
    ''' <returns></returns>
    Private Function FunSendRequestMail(Optional toUserNAME As String = "", Optional fromUserNAME As String = "") As Boolean

        Try

            Dim KISYU_NAME As String = tblKISYU.LazyLoad("�@��").
                                                AsEnumerable.
                                                Where(Function(r) r.Field(Of Integer)("VALUE") = _D009.KISYU_ID).
                                                FirstOrDefault?.Item("DISP")

            Dim SYONIN_HANTEI_NAME As String = tblSYONIN_HANTEI_KB.LazyLoad("���F����敪").
                                                                   AsEnumerable.
                                                                   Where(Function(r) r.Field(Of String)("VALUE") = _D004_SYONIN_J_KANRI.SYONIN_HANTEI_KB).
                                                                   FirstOrDefault?.Item("DISP")

            Dim strEXEParam As String = $"{_D004_SYONIN_J_KANRI.SYAIN_ID},{ENM_OPEN_MODE._2_���u��ʋN��.Value},{Context.ENM_SYONIN_HOKOKUSYO_ID._4_FCCB.Value},{_D004_SYONIN_J_KANRI.HOKOKU_NO}"
            Dim strSubject As String = $"�yFCCB���u�˗��zFCCB-NO:{_D004_SYONIN_J_KANRI.HOKOKU_NO}"
            Dim ToUsers As New List(Of Integer)

            'Select Case PrCurrentStage
            '    Case ENM_FCCB_STAGE._10_�N������
            '        'Dim dt = FunGetSYONIN_SYOZOKU_SYAIN(_D009.BUMON_KB, Context.ENM_SYONIN_HOKOKUSYO_ID._4_FCCB, ENM_FCCB_STAGE._20_���u����������)
            '        'ToUsers = dt.AsEnumerable.Select(Function(r) r.Field(Of Integer)("VALUE")).ToList

            '        '����̖�E�敪GL�ATL�S����
            '        ToUsers.AddRange(GetTLGLUsers(_D009.BUMON_KB))
            '    Case ENM_FCCB_STAGE._20_���u����������

            '        ToUsers.Add(_D009.CM_TANTO)

            '    Case ENM_FCCB_STAGE._30_�ύX�R�c
            '        If cmbSYOCHI_SEKKEI_TANTO.IsSelected Then
            '            ToUsers.Add(cmbSYOCHI_SEKKEI_TANTO.SelectedValue)
            '        End If
            '        If cmbSYOCHI_SEIGI_TANTO.IsSelected Then
            '            ToUsers.Add(cmbSYOCHI_SEIGI_TANTO.SelectedValue)
            '        End If
            '        If cmbSYOCHI_EIGYO_TANTO.IsSelected Then
            '            ToUsers.Add(cmbSYOCHI_EIGYO_TANTO.SelectedValue)
            '        End If
            '        If cmbSYOCHI_KANRI_TANTO.IsSelected Then
            '            ToUsers.Add(cmbSYOCHI_KANRI_TANTO.SelectedValue)
            '        End If
            '        If cmbSYOCHI_SEIZO_TANTO.IsSelected Then
            '            ToUsers.Add(cmbSYOCHI_SEIZO_TANTO.SelectedValue)
            '        End If
            '        If cmbSYOCHI_HINSYO_TANTO.IsSelected Then
            '            ToUsers.Add(cmbSYOCHI_HINSYO_TANTO.SelectedValue)
            '        End If

            '    Case ENM_FCCB_STAGE._40_���u�m�F

            '        Dim IsAllChecked As Boolean = True
            '        If cmbSYOCHI_SEKKEI_TANTO.IsSelected AndAlso dtSYOCHI_SEKKEI_TANTO.Text.IsNulOrWS Then
            '            IsAllChecked *= False
            '        End If
            '        If cmbSYOCHI_SEIGI_TANTO.IsSelected AndAlso dtSYOCHI_SEIGI_TANTO.Text.IsNulOrWS Then
            '            IsAllChecked *= False
            '        End If
            '        If cmbSYOCHI_EIGYO_TANTO.IsSelected AndAlso dtSYOCHI_EIGYO_TANTO.Text.IsNulOrWS Then
            '            IsAllChecked *= False
            '        End If
            '        If cmbSYOCHI_KANRI_TANTO.IsSelected AndAlso dtSYOCHI_KANRI_TANTO.Text.IsNulOrWS Then
            '            IsAllChecked *= False
            '        End If
            '        If cmbSYOCHI_SEIZO_TANTO.IsSelected AndAlso dtSYOCHI_SEIZO_TANTO.Text.IsNulOrWS Then
            '            IsAllChecked *= False
            '        End If
            '        If cmbSYOCHI_HINSYO_TANTO.IsSelected AndAlso dtSYOCHI_HINSYO_TANTO.Text.IsNulOrWS Then
            '            IsAllChecked *= False
            '        End If
            '        If IsAllChecked AndAlso dtSYOCHI_GM_TANTO.Text.IsNulOrWS Then
            '            '�S�Ă̒S���҂̃`�F�b�N�����������瓝���ӔC�҂Ɉ˗����M
            '            ToUsers.Add(cmbSYOCHI_GM_TANTO.SelectedValue)
            '        Else
            '            '�����ӔC�҂̃`�F�b�N������������A�e�v���u�����̒S���҂Ɉ˗����M
            '            Dim targetUsers = DirectCast(Flx2_DS.DataSource, DataTable).
            '                                    AsEnumerable.
            '                                    Where(Function(r) r.Field(Of Boolean)(NameOf(D010.YOHI_KB)) And Not r.Item(NameOf(D010.YOTEI_YMD)).ToString.IsNulOrWS).
            '                                    Select(Function(r) r.Field(Of Integer)(NameOf(D010.TANTO_ID)))

            '            For Each usr In targetUsers
            '                If Not ToUsers.Contains(usr) Then
            '                    ToUsers.Add(usr)
            '                End If
            '            Next

            '            targetUsers = DirectCast(Flx3_DS.DataSource, DataTable).
            '                                    AsEnumerable.
            '                                    Where(Function(r) r.Field(Of Boolean)(NameOf(D010.YOHI_KB)) And Not r.Item(NameOf(D010.YOTEI_YMD)).ToString.IsNulOrWS).
            '                                    Select(Function(r) r.Field(Of Integer)(NameOf(D010.TANTO_ID)))

            '            For Each usr In targetUsers
            '                If Not ToUsers.Contains(usr) Then
            '                    ToUsers.Add(usr)
            '                End If
            '            Next

            '            targetUsers = DirectCast(Flx4_DS.DataSource, DataTable).
            '                                    AsEnumerable.
            '                                    Where(Function(r) Not r.Item(NameOf(D011.YOTEI_YMD)).ToString.IsNulOrWS).
            '                                    Select(Function(r) r.Field(Of Integer)(NameOf(D011.TANTO_ID)))

            '            For Each usr In targetUsers
            '                If Not ToUsers.Contains(usr) Then
            '                    ToUsers.Add(usr)
            '                End If
            '            Next
            '        End If

            '    Case ENM_FCCB_STAGE._50_���u��������
            '        '�������ɂĊe�v���u�����̊�������1�T�ԑO�ɂȂ��Ă������u�̏ꍇ�A���u�S���҂ɑؗ��ʒm

            '        '�\�������̃`�F�b�N
            '        Dim IsClosed As Boolean = True
            '        IsClosed *= DirectCast(Flx2_DS.DataSource, DataTable).
            '                                   AsEnumerable.
            '                                   Where(Function(r) r.Field(Of Boolean)(NameOf(D010.YOHI_KB)) And r.Item(NameOf(D010.CLOSE_YMD)).ToString.IsNulOrWS).Count = 0

            '        IsClosed *= DirectCast(Flx3_DS.DataSource, DataTable).
            '                                AsEnumerable.
            '                                Where(Function(r) r.Field(Of Boolean)(NameOf(D010.YOHI_KB)) And r.Item(NameOf(D010.CLOSE_YMD)).ToString.IsNulOrWS).Count = 0

            '        IsClosed *= DirectCast(Flx4_DS.DataSource, DataTable).
            '                                AsEnumerable.
            '                                Where(Function(r) Not r.Item(NameOf(D011.YOTEI_YMD)).ToString.IsNulOrWS And r.Item(NameOf(D011.CLOSE_YMD)).ToString.IsNulOrWS).Count = 0

            '        '�S�v���u�����̏��u����
            '        If IsClosed Then
            '            'FCCB�c���Ɉ˗��ʒm
            '            If dtKAKUNIN_CM_TANTO.Text.IsNulOrWS Then
            '                ToUsers.Add(_D009.CM_TANTO)
            '            Else
            '                ToUsers.Add(cmbSYOCHI_GM_TANTO.SelectedValue)
            '            End If
            '        End If

            '    Case Else
            '        Throw New ArgumentException("�z��O�̏��F���[�g�ł�", PrCurrentStage)
            'End Select

            Dim strBody As String = <sql><![CDATA[
                {0}<br />
                <br />
        �@        FCCB�L�^���̏��u���e�̊m�F�Ə��F�����肢���܂��B<br />
                <br />
        �@�@        �y�� �� ���zFCCB<br />
        �@�@        �yFCCB-No�z{1}<br />
        �@�@        �y�N �� ���z{2}<br />
        �@�@        �y�@�@  ��z{3}<br />
        �@�@        �y�� �� �ҁz{5}<br />
        �@�@        �y�˗��ҏ��u���e�z{6}<br />
        �@�@        �y�R�����g�z{7}<br />
                <br />
                <a href = "http://sv04:8000/CLICKONCE_FMS.application" > �V�X�e���N��</a><br />
                <br />
                �����̃��[���͔z�M��p�ł��B(�ԐM�ł��܂���)<br />
                �ԐM����ꍇ�́A�e�S���҂̃��[���A�h���X���g�p���ĉ������B<br />
                ]]></sql>.Value.Trim

            'http://sv116:8000/CLICKONCE_FMS.application?SYAIN_ID={8}&EXEPATH={9}&PARAMS={10}

            Dim username As String

            If (ToUsers.Count > 1) Then
                username = "�e��"
            Else
                username = If(toUserNAME.IsNulOrWS, $"{Fun_GetUSER_NAME(_D004_SYONIN_J_KANRI.SYAIN_ID)} �a", toUserNAME)
            End If

            strBody = String.Format(strBody,
                                username,
                                _D004_SYONIN_J_KANRI.HOKOKU_NO,
                                DateTime.ParseExact(_D009.ADD_YMDHNS, "yyyyMMddHHmmss", Nothing).ToString("yyyy/MM/dd"),
                                KISYU_NAME,
                                "",
                                If(fromUserNAME = "", Fun_GetUSER_NAME(pub_SYAIN_INFO.SYAIN_ID), fromUserNAME),
                                SYONIN_HANTEI_NAME,
                                _D004_SYONIN_J_KANRI.COMMENT,
                                _D004_SYONIN_J_KANRI.SYAIN_ID,
                                "FMS_G0020.exe",
                                strEXEParam)

            If ToUsers.Count = 0 Then
                MessageBox.Show("���M�҂�������Ȃ����߁A�˗����[���𑗐M�ł��܂���", "�˗����[�����M", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Return False
            Else
                If FunSendMailFCCB(strSubject, strBody, ToUsers, blnSendSenior:=False) Then
                    Return True
                Else
                    MessageBox.Show("���[�����M�Ɏ��s���܂����B", "���[�����M���s", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    Return False
                End If
            End If
        Catch ex As Exception
            Throw
        End Try
    End Function

    Private Function GetTLGLUsers(BUMON_KB As String) As IEnumerable(Of Integer)
        Dim retList As New List(Of Integer)
        Try
            Dim sbSQL As New System.Text.StringBuilder
            Dim dsList As New DataSet
            If (BUMON_KB = ENM_BUMON_KB._1_���h.Value) Then
                sbSQL.Append($"SELECT M04.SYAIN_ID,M04.SIMEI FROM M004_SYAIN M04")
                sbSQL.Append($" INNER JOIN M011_SYAIN_GYOMU M11")
                sbSQL.Append($" ON M04.SYAIN_ID = M11.SYAIN_ID And M11.GYOMU_GROUP_ID <> '{ENM_GYOMU_GROUP_ID._2_����.Value}'")
                sbSQL.Append($" WHERE M04.SYAIN_ID IN ((SELECT SYOZOKUCYO_ID FROM M002_BUSYO WHERE BUMON_KB='{ENM_BUMON_KB._1_���h.Value}') )")
                sbSQL.Append($" AND M04.YAKUSYOKU_KB IN ('{ENM_YAKUSYOKU_KB._2_GL.Value}','{ENM_YAKUSYOKU_KB._5_TL.Value}')")
                sbSQL.Append($" UNION")
                sbSQL.Append($" SELECT M04.SYAIN_ID,M04.SIMEI FROM M004_SYAIN M04")
                sbSQL.Append($" INNER JOIN M011_SYAIN_GYOMU M11")
                sbSQL.Append($" ON M04.SYAIN_ID = M11.SYAIN_ID AND M11.GYOMU_GROUP_ID = '{ENM_GYOMU_GROUP_ID._2_����.Value}'")
                sbSQL.Append($" WHERE M04.SYAIN_ID IN (SELECT SYOZOKUCYO_ID FROM M002_BUSYO WHERE BUMON_KB='{ENM_BUMON_KB._1_���h.Value}')")
                sbSQL.Append($" AND YAKUSYOKU_KB ='{ENM_YAKUSYOKU_KB._1_�ے�.Value}'")
            Else
                sbSQL.Append($"SELECT SYAIN_ID,SIMEI FROM M004_SYAIN")
                sbSQL.Append($" WHERE SYAIN_ID IN ((SELECT SYOZOKUCYO_ID FROM M002_BUSYO WHERE BUMON_KB='{BUMON_KB}') )")
                sbSQL.Append($" AND YAKUSYOKU_KB IN ('{ENM_YAKUSYOKU_KB._2_GL.Value}','{ENM_YAKUSYOKU_KB._5_TL.Value}')")
                sbSQL.Append($" Except")
                sbSQL.Append($" SELECT M04.SYAIN_ID,M04.SIMEI FROM M004_SYAIN M04")
                sbSQL.Append($" LEFT JOIN M011_SYAIN_GYOMU M11")
                sbSQL.Append($" ON M04.SYAIN_ID = M11.SYAIN_ID AND M11.GYOMU_GROUP_ID = '{ENM_GYOMU_GROUP_ID._2_����.Value}'")
                sbSQL.Append($" WHERE M04.SYAIN_ID IN (SELECT SYOZOKUCYO_ID FROM M002_BUSYO WHERE BUMON_KB='{BUMON_KB}')")
                sbSQL.Append($" AND YAKUSYOKU_KB ='{ENM_YAKUSYOKU_KB._2_GL.Value}'")
            End If

            Using DB = DBOpen()
                dsList = DB.GetDataSet(sbSQL.ToString, conblnNonMsg)
            End Using
            For Each r As DataRow In dsList.Tables(0).Rows
                retList.Add(r.Item(0).ToString.ToVal)
            Next

            Return retList
        Catch ex As Exception
            Throw
        End Try
    End Function

#End Region

#Region "R001"

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
        _R001_HOKOKU_SOUSA.SYONIN_HOKOKUSYO_ID = Context.ENM_SYONIN_HOKOKUSYO_ID._4_FCCB
        _R001_HOKOKU_SOUSA.HOKOKU_NO = _D009.FCCB_NO
        _R001_HOKOKU_SOUSA.SYONIN_JUN = PrCurrentStage
        _R001_HOKOKU_SOUSA.SYAIN_ID = pub_SYAIN_INFO.SYAIN_ID
        _R001_HOKOKU_SOUSA.RIYU = PrRIYU
        _R001_HOKOKU_SOUSA.ADD_YMDHNS = strSysDate 'Now.ToString("yyyyMMddHHmmss")

        Select Case enmSAVE_MODE
            Case ENM_SAVE_MODE._1_�ۑ�

                If PrCurrentStage = ENM_FCCB_STAGE._999_Closed Then
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

        WL.WriteLogDat($"[DEBUG]CTS �񍐏�NO:{_D009.FCCB_NO}�AINSERT R001")

        Return True
    End Function

#End Region

#End Region

#Region "�]��"

    Private Function OpenFormTENSO() As Boolean
        Dim frmDLG As New FrmG0035_Tenso
        Dim dlgRET As DialogResult

        Try
            frmDLG.PrSYONIN_HOKOKUSYO_ID = Context.ENM_SYONIN_HOKOKUSYO_ID._4_FCCB
            frmDLG.PrHOKOKU_NO = PrFCCB_NO
            frmDLG.PrBUMON_KB = _D009.BUMON_KB
            frmDLG.PrBUHIN_BANGO = _D009.BUHIN_BANGO
            frmDLG.PrKISO_YMD = DateTime.ParseExact(_D009.ADD_YMD, "yyyyMMdd", Nothing).ToString("yyyy/MM/dd")
            frmDLG.PrKISYU_NAME = tblKISYU.LazyLoad("�@��").AsEnumerable.Where(Function(r) r.Field(Of Integer)("VALUE") = _D009.KISYU_ID).FirstOrDefault?.Item("DISP")
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
        Dim frmDLG As New FrmG0036_Sasimodosi
        Dim dlgRET As DialogResult

        Try
            frmDLG.PrSYONIN_HOKOKUSYO_ID = Context.ENM_SYONIN_HOKOKUSYO_ID._4_FCCB
            frmDLG.PrHOKOKU_NO = PrFCCB_NO
            frmDLG.PrBUHIN_BANGO = _D009.BUHIN_BANGO
            frmDLG.PrKISO_YMD = CDate(_D009.ADD_YMDHNS).ToString("yyyy/MM/dd")
            frmDLG.PrKISYU_NAME = tblKISYU.LazyLoad("�@��").AsEnumerable.Where(Function(r) r.Field(Of Integer)("VALUE") = _D009.KISYU_ID).FirstOrDefault?.Item("DISP")
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

    Private Function FunOpenReportFCCB() As Boolean
        Dim strOutputFileName As String
        Dim strTEMPFILE As String
        'Dim intRET As Integer

        Try
            Me.Cursor = Cursors.WaitCursor

            '�t�@�C����
            strOutputFileName = "CTS_" & _D009.FCCB_NO & "_Work.xls"

            '�����t�@�C���폜
            If FunDELETE_FILE(pub_APP_INFO.strOUTPUT_PATH & strOutputFileName) = False Then
                Return False
            End If

            Using iniIF As New IniFile(FunGetRootPath() & "\INI\" & CON_TEMPLATE_INI)
                strTEMPFILE = FunConvRootPath(iniIF.GetIniString("FCCB", "FILEPATH"))
            End Using

            '�G�N�Z���o�̓t�@�C���p��
            If OUT_EXCEL_READY(strTEMPFILE, pub_APP_INFO.strOUTPUT_PATH, strOutputFileName) = False Then
                Return False
            End If
            '-----��������
            If FunMakeReportFCCB(pub_APP_INFO.strOUTPUT_PATH & strOutputFileName, _D009.FCCB_NO) = False Then
                Return False
            End If

            'Excel�N��
            Return FunOpenExcelApp(pub_APP_INFO.strOUTPUT_PATH & strOutputFileName)
        Catch ex As Exception
            EM.ErrorSyori(ex, False, conblnNonMsg)
            Return False
        Finally
            Me.Cursor = Cursors.Default
        End Try
    End Function

#End Region

#Region "����"

    Private Function OpenFormHistory(ByVal SYONIN_HOKOKU_ID As Integer, ByVal HOKOKU_NO As String) As Boolean
        Dim frmDLG As New FrmG0032_Rireki
        Dim dlgRET As DialogResult

        Try
            frmDLG.PrSYONIN_HOKOKUSYO_ID = SYONIN_HOKOKU_ID
            frmDLG.PrHOKOKU_NO = HOKOKU_NO
            frmDLG.PrDatarow = PrDataRow
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
        Dim frmDLG As New FrmG0034_EditComment
        Dim dlgRET As DialogResult

        Try
            frmDLG.PrSYONIN_HOKOKUSYO_ID = Context.ENM_SYONIN_HOKOKUSYO_ID._4_FCCB
            frmDLG.PrHOKOKU_NO = _D009.FCCB_NO
            frmDLG.PrBUMON_KB = _D009.BUMON_KB
            frmDLG.PrBUHIN_BANGO = _D009.BUHIN_BANGO
            frmDLG.PrKISO_YMD = DateTime.ParseExact(_D009.ADD_YMD, "yyyyMMdd", Nothing).ToString("yyyy/MM/dd")
            frmDLG.PrKISYU_NAME = tblKISYU.LazyLoad("�@��").AsEnumerable.Where(Function(r) r.Field(Of Integer)("VALUE") = _D009.KISYU_ID).FirstOrDefault?.Item("DISP")
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

#Region "���[�����M"

    Private Function OpenFormSendMail() As Boolean
        Dim frmDLG As New FrmG0037_MailForm
        Dim dlgRET As DialogResult

        Try
            frmDLG.PrSYONIN_HOKOKUSYO_ID = Context.ENM_SYONIN_HOKOKUSYO_ID._4_FCCB
            frmDLG.PrHOKOKU_NO = PrFCCB_NO
            frmDLG.PrSYORI_NAME = "���c�m�F�˗����[�����M"

            Dim userlist As New List(Of Integer)

            'userlist.Add(cmbCM_TANTO.SelectedValue)
            'If cmbSYOCHI_GM_TANTO.IsSelected AndAlso Not userlist.Contains(cmbSYOCHI_GM_TANTO.SelectedValue) Then
            '    userlist.Add(cmbSYOCHI_GM_TANTO.SelectedValue)
            'End If
            'If cmbSYOCHI_SEIZO_TANTO.IsSelected AndAlso Not userlist.Contains(cmbSYOCHI_SEIZO_TANTO.SelectedValue) Then
            '    userlist.Add(cmbSYOCHI_SEIZO_TANTO.SelectedValue)
            'End If
            'If cmbSYOCHI_KENSA_TANTO.IsSelected AndAlso Not userlist.Contains(cmbSYOCHI_KENSA_TANTO.SelectedValue) Then
            '    userlist.Add(cmbSYOCHI_KENSA_TANTO.SelectedValue)
            'End If
            'If cmbSYOCHI_HINSYO_TANTO.IsSelected AndAlso Not userlist.Contains(cmbSYOCHI_HINSYO_TANTO.SelectedValue) Then
            '    userlist.Add(cmbSYOCHI_HINSYO_TANTO.SelectedValue)
            'End If
            'If cmbSYOCHI_SEKKEI_TANTO.IsSelected AndAlso Not userlist.Contains(cmbSYOCHI_SEKKEI_TANTO.SelectedValue) Then
            '    userlist.Add(cmbSYOCHI_SEKKEI_TANTO.SelectedValue)
            'End If
            'If cmbSYOCHI_SEIGI_TANTO.IsSelected AndAlso Not userlist.Contains(cmbSYOCHI_SEIGI_TANTO.SelectedValue) Then
            '    userlist.Add(cmbSYOCHI_SEIGI_TANTO.SelectedValue)
            'End If
            'If cmbSYOCHI_KANRI_TANTO.IsSelected AndAlso Not userlist.Contains(cmbSYOCHI_KANRI_TANTO.SelectedValue) Then
            '    userlist.Add(cmbSYOCHI_KANRI_TANTO.SelectedValue)
            'End If
            'If cmbSYOCHI_EIGYO_TANTO.IsSelected AndAlso Not userlist.Contains(cmbSYOCHI_EIGYO_TANTO.SelectedValue) Then
            '    userlist.Add(cmbSYOCHI_EIGYO_TANTO.SelectedValue)
            'End If

            If userlist.Count > 1 Then
                frmDLG.PrToUsers = userlist
                dlgRET = frmDLG.ShowDialog(Me)

                If dlgRET = Windows.Forms.DialogResult.OK Then
                    Me.DialogResult = DialogResult.OK
                    Me.Close()
                    Return True
                Else
                    Return False
                End If
            Else
                MessageBox.Show($"�m�F�˗��S���҂��I������Ă��܂���{vbCrLf}��ɁA�D�ύX�R�c �e����̒S���҂�I�����ĉ�����", "���c�m�F�˗����[�����M", MessageBoxButtons.OK, MessageBoxIcon.Information)
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

            '�J�����g�X�e�[�W�����g�̒S���łȂ��ꍇ�͖���
            Dim IsOwnCreated As Boolean = FunblnOwnCreated(Context.ENM_SYONIN_HOKOKUSYO_ID._4_FCCB.Value, _D009.FCCB_NO, PrCurrentStage)

            If PrMODE = ENM_DATA_OPERATION_MODE._1_ADD Then

                cmdFunc1.Enabled = IsOwnCreated
                cmdFunc2.Enabled = IsOwnCreated

                cmdFunc4.Enabled = False
                cmdFunc4.Visible = False
                cmdFunc5.Enabled = False
                cmdFunc10.Enabled = False
                cmdFunc11.Enabled = False
            Else

                cmdFunc1.Enabled = IsOwnCreated
                cmdFunc2.Enabled = IsOwnCreated

                cmdFunc5.Enabled = IsOwnCreated

                cmdFunc10.Enabled = True
                cmdFunc11.Enabled = True

                Dim blnIsAdmin As Boolean = IsSysAdminUser(pub_SYAIN_INFO.SYAIN_ID)
                cmdFunc5.Enabled = blnIsAdmin

                cmdFunc4.Visible = False

                Select Case PrCurrentStage
                    Case ENM_FCCB_STAGE._10_�N������
                        cmdFunc5.Enabled = False
                    Case ENM_FCCB_STAGE._20_���u����������
                        cmdFunc2.Enabled = pub_SYAIN_INFO.SYAIN_ID = _D009.CM_TANTO
                    Case ENM_FCCB_STAGE._30_�ύX�R�c

                        cmdFunc4.Visible = True

                        cmdFunc4.Enabled = pub_SYAIN_INFO.SYAIN_ID = _D009.CM_TANTO

                        If IsNeedMeeting() Then
                            cmdFunc4.Text = $"���c�J��{vbCrLf}���[�����M(F4)"
                        Else
                            cmdFunc4.Text = $"���c�v�ۊm�F{vbCrLf}���[�����M(F4)"
                        End If

                    Case ENM_FCCB_STAGE._50_���u��������

                    Case ENM_FCCB_STAGE._999_Closed
                        If IsEditingClosed Then
                            cmdFunc1.Enabled = True
                            cmdFunc1.Text = "�ۑ�(F1)"
                        Else
                            cmdFunc1.Enabled = False
                            cmdFunc1.Text = "�ۑ�(F1)"
                        End If

                        cmdFunc2.Enabled = False
                        cmdFunc4.Enabled = False
                        cmdFunc5.Enabled = False
                        MyBase.ToolTip.SetToolTip(cmdFunc1, "Close�ς݂̂��ߎg�p�o���܂���")
                        MyBase.ToolTip.SetToolTip(cmdFunc2, "Close�ς݂̂��ߎg�p�o���܂���")
                        MyBase.ToolTip.SetToolTip(cmdFunc4, "Close�ς݂̂��ߎg�p�o���܂���")
                        MyBase.ToolTip.SetToolTip(cmdFunc5, "Close�ς݂̂��ߎg�p�o���܂���")
                    Case Else
                End Select

            End If

            Return True
        Catch ex As Exception
            EM.ErrorSyori(ex, False, conblnNonMsg)
        End Try
    End Function

#End Region

#End Region

#Region "�R���g���[���C�x���g"

#Region "�\����Ј�"

    Private Sub CmbDestTANTO_Validating(sender As Object, e As System.ComponentModel.CancelEventArgs)

    End Sub

#End Region

#Region "�w�b�_"

    Private Sub RsbtnST_CheckedChanged(sender As Object, e As EventArgs)

        Dim btn As RibbonShapeRadioButton = DirectCast(sender, RibbonShapeRadioButton)
        Dim intStageID As Integer = Val(btn.Name.Substring(7))

    End Sub

#Region "����"

    Private Sub CmbBUMON_SelectedValueChanged(sender As Object, e As EventArgs) Handles cmbBUMON.SelectedValueChanged

    End Sub

#End Region

    Private Sub cmbBUMON_Validated(sender As Object, e As EventArgs) Handles cmbBUMON.Validated
        IsValidated *= ErrorProvider.UpdateErrorInfo(cmbBUMON, cmbBUMON.IsSelected, String.Format(My.Resources.infoMsgRequireSelectOrInput, "���i�敪"))
    End Sub

    Private Sub cmbKISO_TANTO_Validated(sender As Object, e As EventArgs) Handles cmbKISO_TANTO.Validated
        IsValidated *= ErrorProvider.UpdateErrorInfo(cmbKISO_TANTO, cmbKISO_TANTO.IsSelected, String.Format(My.Resources.infoMsgRequireSelectOrInput, "�N����"))
    End Sub

#End Region

#End Region

#Region "���[�J���֐�"

#Region "�������[�h�ʉ�ʏ�����"

    ''' <summary>
    ''' ��ʏ�����
    ''' </summary>
    ''' <param name="intMODE"></param>
    ''' <returns></returns>
    Private Function FunInitializeControls(intMODE As ENM_DATA_OPERATION_MODE) As Boolean

        Try

            '�i�r�Q�[�g�����N�I��
            If PrCurrentStage = ENM_FCCB_STAGE._999_Closed Then
                rsbtnST99.Checked = True
            Else
                Dim rbtn As RibbonShapeRadioButton = DirectCast(flpnlStageIndex.Controls("rsbtnST" & (PrCurrentStage / 10).ToString("00")), RibbonShapeRadioButton)
                rbtn.Checked = True
            End If

            Call SetTANTO_TooltipInfo()

            '-----�R���g���[���f�[�^�\�[�X�ݒ�
            cmbBUMON.SetDataSource(tblBUMON, ENM_COMBO_SELECT_VALUE_TYPE._0_Required)

            '���s�X�e�[�W��
            lblCurrentStageName.Text = FunGetLastStageName(Context.ENM_SYONIN_HOKOKUSYO_ID._4_FCCB, _D009.FCCB_NO)

            '���u�m�F�S����

            Return True
        Catch ex As Exception
            EM.ErrorSyori(ex, False, conblnNonMsg)
        End Try
    End Function

    ''' <summary>
    ''' �S���҂̃f�[�^�\�[�X�������x���ɕ\��
    ''' </summary>
    ''' <returns></returns>
    Private Function SetTANTO_TooltipInfo() As Boolean

        Call SetInfoLabelFormat(lblKISO_TANTO, $"�Ј��Ɩ��O���[�v�}�X�^{vbCr}�ȉ��̋Ɩ��O���[�v�ɓo�^���ꂽ�S����{vbCrLf}{vbCrLf}QMS�Ǘ��ӔC�ҁE�݌v�E�i�؁E���Z")
        'Call SetInfoLabelFormat(lblCM_TANTO, $"���F�S���҃}�X�^{vbCr}���������ST1.�ɓo�^���ꂽ�S����")
        'Call SetInfoLabelFormat(lblDestTanto, $"���F�S���҃}�X�^{vbCr}��������̓��Y�X�e�[�W�ɓo�^���ꂽ�S����")

    End Function

    Private Function SetInfoLabelFormat(lbl As System.Windows.Forms.Label, caption As String) As Boolean
        lbl.ForeColor = Color.Blue
        'lbl.Cursor = Cursors.Hand
        lbl.Font = New Font("Meiryo UI", 9, FontStyle.Bold + FontStyle.Underline, lbl.Font.Unit, CType(128, Byte))
        InfoToolTip.SetToolTip(lbl, caption)
    End Function

#End Region

#Region "���̓`�F�b�N"

    Private Function FunCheckInput(ByVal enmSAVE_MODE As ENM_SAVE_MODE) As Boolean
        Try
            '�t���O���Z�b�g
            IsValidated = True

            Call cmbBUMON_Validated(cmbBUMON, Nothing)
            Call cmbKISO_TANTO_Validated(cmbKISO_TANTO, Nothing)

            If Not IsValidated Then Return False

            If enmSAVE_MODE = ENM_SAVE_MODE._2_���F�\�� Then

            End If

            '��L�e��Validating�C�x���g�Ńt���O���X�V���A�S��OK�̏ꍇ��True
            Return IsValidated
        Catch ex As Exception
            Throw
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
        sbSQL.Append($"SELECT")
        sbSQL.Append($" {NameOf(V003_SYONIN_J_KANRI)}.*")
        sbSQL.Append($" FROM {NameOf(V003_SYONIN_J_KANRI)} ")
        sbSQL.Append($" WHERE {NameOf(V003_SYONIN_J_KANRI.SYONIN_HOKOKUSYO_ID)}={intSYONIN_HOKOKUSYO_ID}")
        sbSQL.Append($" And {NameOf(V003_SYONIN_J_KANRI.HOKOKU_NO)}='{strHOKOKU_NO.Trim}'")
        sbSQL.Append($" ORDER BY {NameOf(V003_SYONIN_J_KANRI.SYONIN_JUN)} DESC")
        Using DB As ClsDbUtility = DBOpen()
            dsList = DB.GetDataSet(sbSQL.ToString, conblnNonMsg)
        End Using

        With dsList.Tables(0)
            If .Rows.Count = 0 Then
                Return "ST01.�N��"
            Else
                Return .Rows(0).Item(NameOf(V003_SYONIN_J_KANRI.SYONIN_NAIYO)) '.Rows(0).Item("SYONIN_JUN") & "." & .Rows(0).Item("SYONIN_NAIYO")
            End If
        End With
    End Function

    ''' <summary>
    ''' ���X�e�[�W�̏��F��No���擾
    ''' </summary>
    ''' <param name="CurrentStageID">���X�e�[�WID</param>
    ''' <returns></returns>
    Private Function FunGetNextSYONIN_JUN(CurrentStageID As Integer) As Integer
        Try

            Select Case CurrentStageID
                Case ENM_FCCB_STAGE._10_�N������
                    Return ENM_FCCB_STAGE._20_���u����������
                Case ENM_FCCB_STAGE._20_���u����������
                    Return ENM_FCCB_STAGE._30_�ύX�R�c
                Case ENM_FCCB_STAGE._30_�ύX�R�c
                    Return ENM_FCCB_STAGE._40_���u�m�F
                Case ENM_FCCB_STAGE._40_���u�m�F, ENM_FCCB_STAGE._41_���u�m�F_����
                    Return ENM_FCCB_STAGE._50_���u��������
                Case ENM_FCCB_STAGE._50_���u��������
                    Return ENM_FCCB_STAGE._60_���u���������m�F
                Case ENM_FCCB_STAGE._60_���u���������m�F, ENM_FCCB_STAGE._61_���u���������m�F_����
                    Return ENM_FCCB_STAGE._999_Closed
                Case Else
                    Return 0
            End Select
        Catch ex As Exception
            Throw
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
            sbSQL.Append($" COUNT({NameOf(R005_FCR_SASIMODOSI.HOKOKU_NO)})")
            sbSQL.Append($" FROM {NameOf(R005_FCR_SASIMODOSI)} ")
            sbSQL.Append($" WHERE {NameOf(R005_FCR_SASIMODOSI.HOKOKU_NO)}='{strHOKOKU_NO}'")
            Using DB As ClsDbUtility = DBOpen()
                intRET = DB.ExecuteScalar(sbSQL.ToString, conblnNonMsg)
            End Using

            Return intRET > 0
        End If
    End Function

    ''' <summary>
    ''' ���O�C�����[�U�[�����For�\�������X�e�[�W������
    ''' </summary>
    ''' <param name="intSYONIN_HOKOKUSYO_ID">���F�񍐏�ID</param>
    ''' <param name="strHOKOKU_NO">�񍐏�No</param>
    ''' <param name="intSYONIN_JUN">���F��No</param>
    ''' <returns></returns>
    Public Function FunblnOwnCreated(ByVal intSYONIN_HOKOKUSYO_ID As Integer, ByVal strHOKOKU_NO As String, ByVal intSYONIN_JUN As Integer) As Boolean

        Try
            Dim ToUsers As New List(Of Integer)

            'Select Case intSYONIN_JUN
            '    Case ENM_FCCB_STAGE._10_�N������
            '        Dim dt = FunGetSYONIN_SYOZOKU_SYAIN(_D009.BUMON_KB, Context.ENM_SYONIN_HOKOKUSYO_ID._4_FCCB, ENM_FCCB_STAGE._10_�N������)
            '        ToUsers = dt.AsEnumerable.Select(Function(r) r.Field(Of Integer)("VALUE")).ToList

            '    Case ENM_FCCB_STAGE._20_���u����������
            '        'FCCB�c�� �N����
            '        ToUsers.Add(_D009.CM_TANTO)
            '        ToUsers.Add(_D009.ADD_SYAIN_ID)
            '        '����\
            '        ToUsers.Add(pub_SYAIN_INFO.SYAIN_ID)

            '    Case ENM_FCCB_STAGE._30_�ύX�R�c

            '        ToUsers.Add(cmbCM_TANTO.SelectedValue)

            '        If cmbSYOCHI_SEKKEI_TANTO.IsSelected Then
            '            ToUsers.Add(cmbSYOCHI_SEKKEI_TANTO.SelectedValue)
            '        End If
            '        If cmbSYOCHI_SEIGI_TANTO.IsSelected Then
            '            ToUsers.Add(cmbSYOCHI_SEIGI_TANTO.SelectedValue)
            '        End If
            '        If cmbSYOCHI_EIGYO_TANTO.IsSelected Then
            '            ToUsers.Add(cmbSYOCHI_EIGYO_TANTO.SelectedValue)
            '        End If
            '        If cmbSYOCHI_KANRI_TANTO.IsSelected Then
            '            ToUsers.Add(cmbSYOCHI_KANRI_TANTO.SelectedValue)
            '        End If
            '        If cmbSYOCHI_SEIZO_TANTO.IsSelected Then
            '            ToUsers.Add(cmbSYOCHI_SEIZO_TANTO.SelectedValue)
            '        End If
            '        If cmbSYOCHI_HINSYO_TANTO.IsSelected Then
            '            ToUsers.Add(cmbSYOCHI_HINSYO_TANTO.SelectedValue)
            '        End If

            '    Case ENM_FCCB_STAGE._40_���u�m�F

            '        ToUsers.Add(cmbCM_TANTO.SelectedValue)

            '        Dim IsAllChecked As Boolean = True
            '        If cmbSYOCHI_SEKKEI_TANTO.IsSelected AndAlso dtSYOCHI_SEKKEI_TANTO.Text.IsNulOrWS Then
            '            IsAllChecked *= False
            '        End If
            '        If cmbSYOCHI_SEIGI_TANTO.IsSelected AndAlso dtSYOCHI_SEIGI_TANTO.Text.IsNulOrWS Then
            '            IsAllChecked *= False
            '        End If
            '        If cmbSYOCHI_EIGYO_TANTO.IsSelected AndAlso dtSYOCHI_EIGYO_TANTO.Text.IsNulOrWS Then
            '            IsAllChecked *= False
            '        End If
            '        If cmbSYOCHI_KANRI_TANTO.IsSelected AndAlso dtSYOCHI_KANRI_TANTO.Text.IsNulOrWS Then
            '            IsAllChecked *= False
            '        End If
            '        If cmbSYOCHI_SEIZO_TANTO.IsSelected AndAlso dtSYOCHI_SEIZO_TANTO.Text.IsNulOrWS Then
            '            IsAllChecked *= False
            '        End If
            '        If cmbSYOCHI_HINSYO_TANTO.IsSelected AndAlso dtSYOCHI_HINSYO_TANTO.Text.IsNulOrWS Then
            '            IsAllChecked *= False
            '        End If
            '        If IsAllChecked AndAlso dtSYOCHI_GM_TANTO.Text.IsNulOrWS Then
            '            '�S�Ă̒S���҂̃`�F�b�N�����������瓝���ӔC�҂Ɉ˗����M
            '            ToUsers.Add(cmbSYOCHI_GM_TANTO.SelectedValue)
            '        Else
            '            '�����ӔC�҂̃`�F�b�N������������A�e�v���u�����̒S���҂Ɉ˗����M
            '            Dim targetUsers = DirectCast(Flx2_DS.DataSource, DataTable).
            '                                    AsEnumerable.
            '                                    Where(Function(r) r.Field(Of Boolean)(NameOf(D010.YOHI_KB)) And Not r.Item(NameOf(D010.YOTEI_YMD)).ToString.IsNulOrWS).
            '                                    Select(Function(r) r.Field(Of Integer)(NameOf(D010.TANTO_ID)))

            '            For Each usr In targetUsers
            '                If Not ToUsers.Contains(usr) Then
            '                    ToUsers.Add(usr)
            '                End If
            '            Next

            '            targetUsers = DirectCast(Flx3_DS.DataSource, DataTable).
            '                                    AsEnumerable.
            '                                    Where(Function(r) r.Field(Of Boolean)(NameOf(D010.YOHI_KB)) And Not r.Item(NameOf(D010.YOTEI_YMD)).ToString.IsNulOrWS).
            '                                    Select(Function(r) r.Field(Of Integer)(NameOf(D010.TANTO_ID)))

            '            For Each usr In targetUsers
            '                If Not ToUsers.Contains(usr) Then
            '                    ToUsers.Add(usr)
            '                End If
            '            Next

            '            targetUsers = DirectCast(Flx4_DS.DataSource, DataTable).
            '                                    AsEnumerable.
            '                                    Where(Function(r) Not r.Item(NameOf(D011.YOTEI_YMD)).ToString.IsNulOrWS).
            '                                    Select(Function(r) r.Field(Of Integer)(NameOf(D011.TANTO_ID)))

            '            For Each usr In targetUsers
            '                If Not ToUsers.Contains(usr) Then
            '                    ToUsers.Add(usr)
            '                End If
            '            Next
            '        End If

            '    Case ENM_FCCB_STAGE._50_���u��������
            '        '�������ɂĊe�v���u�����̊�������1�T�ԑO�ɂȂ��Ă������u�̏ꍇ�A���u�S���҂ɑؗ��ʒm

            '        '�\�������̃`�F�b�N
            '        Dim IsClosed As Boolean = True
            '        IsClosed *= DirectCast(Flx2_DS.DataSource, DataTable).
            '                                   AsEnumerable.
            '                                   Where(Function(r) r.Field(Of Boolean)(NameOf(D010.YOHI_KB)) And r.Item(NameOf(D010.CLOSE_YMD)).ToString.IsNulOrWS).Count = 0

            '        IsClosed *= DirectCast(Flx3_DS.DataSource, DataTable).
            '                                AsEnumerable.
            '                                Where(Function(r) r.Field(Of Boolean)(NameOf(D010.YOHI_KB)) And r.Item(NameOf(D010.CLOSE_YMD)).ToString.IsNulOrWS).Count = 0

            '        IsClosed *= DirectCast(Flx4_DS.DataSource, DataTable).
            '                                AsEnumerable.
            '                                Where(Function(r) Not r.Item(NameOf(D011.YOTEI_YMD)).ToString.IsNulOrWS And r.Item(NameOf(D011.CLOSE_YMD)).ToString.IsNulOrWS).Count = 0

            '        '�S�v���u�����̏��u����
            '        If IsClosed Then
            '            'FCCB�c���Ɉ˗��ʒm
            '            'If dtKAKUNIN_CM_TANTO.Text.IsNulOrWS Then
            '            ToUsers.Add(_D009.CM_TANTO)
            '            'Else
            '            '    ToUsers.Add(cmbSYOCHI_GM_TANTO.SelectedValue)
            '            'End If
            '        End If
            '    Case ENM_FCCB_STAGE._60_���u���������m�F
            '        'ToUsers.Add(_D009.CM_TANTO)
            '        ToUsers.Add(cmbSYOCHI_GM_TANTO.SelectedValue)

            '    Case Else
            '        Throw New ArgumentException("�z��O�̏��F���[�g�ł�", PrCurrentStage)
            'End Select

            Return ToUsers.Contains(pub_SYAIN_INFO.SYAIN_ID)
        Catch ex As Exception
            Throw
        End Try

    End Function

    Private Function IsNeedMeeting() As Boolean

        Dim sbSQL As New System.Text.StringBuilder
        Dim sqlEx As New Exception
        Dim intRET As Integer

        sbSQL.Append($"SELECT")
        sbSQL.Append($" COUNT({NameOf(D012.TANTO_ID)})")
        sbSQL.Append($" FROM {NameOf(D012_FCCB_SUB_SYOCHI_KAKUNIN)} ")
        sbSQL.Append($" WHERE {NameOf(D012.FCCB_NO)}='{_D009.FCCB_NO}' ")
        sbSQL.Append($" AND {NameOf(D012.TANTO_ID)}<>0 ")
        sbSQL.Append($" AND RTRIM({NameOf(D012.KYOGI_YOHI_KAITO)})='1' ")
        Using DB = DBOpen()
            intRET = DB.ExecuteScalar(sbSQL.ToString, conblnNonMsg, sqlEx).ToVal()
        End Using

        Return intRET > 0
    End Function

#End Region

#Region "�Y�t�t�@�C��"

    '�Y�t�t�@�C���I��
    Private Sub BtnOpenTempFileDialog_Click(sender As Object, e As EventArgs)
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

            _D009.FILE_PATH = IO.Path.GetFileName(ofd.FileName)
            lbltmpFile1.Visible = True
            lbltmpFile1_Clear.Visible = True
        End If
    End Sub

    '�����N�N���b�N
    Private Sub LbltmpFile1_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs)
        Dim hProcess As New System.Diagnostics.Process
        Dim strEXE As String
        'Dim strARG As String
        Try

            strEXE = lbltmpFile1.Links(0).LinkData
            If strEXE.IsNulOrWS Then
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
    Private Sub LbltmpFile1_Clear_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs)
        lbltmpFile1.Text = ""
        _D009.FILE_PATH = ""
        lbltmpFile1.Links.Clear()
        lbltmpFile1.Visible = False
        lbltmpFile1_Clear.Visible = False
    End Sub

#End Region

End Class