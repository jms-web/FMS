Imports System.Threading.Tasks
Imports JMS_COMMON.ClsPubMethod
Imports MODEL
Imports D013 = MODEL.D013_ZESEI_HASSEI_J

''' <summary>
''' �������u���
''' </summary>
Public Class FrmG0031_EditOccurred

#Region "�萔�E�ϐ�"

    Private _D013 As New D013
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
        MyBase.ToolTip.SetToolTip(Me.cmdFunc1, "���쌠��������܂���")
        MyBase.ToolTip.SetToolTip(Me.cmdFunc2, "���쌠��������܂���")
        MyBase.ToolTip.SetToolTip(Me.cmdFunc4, My.Resources.infoToolTipMsgNotFoundData)
        MyBase.ToolTip.SetToolTip(Me.cmdFunc5, My.Resources.infoToolTipMsgNotFoundData)
        MyBase.ToolTip.SetToolTip(Me.cmdFunc10, My.Resources.infoToolTipMsgNotFoundData)
        MyBase.ToolTip.SetToolTip(Me.cmdFunc11, My.Resources.infoToolTipMsgNotFoundData)

        cmbKA.NullValue = 0
        cmbTANTO.NullValue = 0

        cmbST01_SAKUSEI_TANTO.NullValue = 0
        cmbST01_TENKEN_TANTO.NullValue = 0
        cmbST01_NINKA_TANTO.NullValue = 0

        cmbST02_SAKUSEI_TANTO.NullValue = 0
        cmbST02_TENKEN_TANTO.NullValue = 0
        cmbST02_NINKA_TANTO.NullValue = 0
        cmbST02_HINSYO_TENKEN_TANTO.NullValue = 0
        cmbST02_HINSYO_NINKA_TANTO.NullValue = 0

        cmbST03_SAKUSEI_TANTO.NullValue = 0
        cmbST03_TENKEN_TANTO.NullValue = 0
        cmbST03_NINKA_TANTO.NullValue = 0

        cmbST04_SAKUSEI_TANTO.NullValue = 0
        cmbST04_TENKEN_TANTO.NullValue = 0
        cmbST04_NINKA_TANTO.NullValue = 0

        cmbST05_SAKUSEI_TANTO.NullValue = 0
        cmbST05_TENKEN_TANTO.NullValue = 0
        cmbST05_NINKA_TANTO.NullValue = 0

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
                        _D013.Clear()
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
                        cmbKA.SetDataSource(tblKA.ExcludeDeleted, ENM_COMBO_SELECT_VALUE_TYPE._2_Option)
                        'Call FunSetBinding()
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

    Overrides Sub FrmBaseStsBtn_Resize(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Resize
        If Me.Visible = False Then Exit Sub

        If Me.DesignMode = True Then Exit Sub

        ''===================================
        ''   �{�^���ʒu�A�T�C�Y�ݒ�
        ''===================================
        'Call SetButtonSize(Me.Width, cmdFunc)
        'MyBase.FrmBaseStsBtn_Resize(Me, e)
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
                        If IsEditingClosed And PrCurrentStage = ENM_ZESEI_STAGE._999_Closed Then

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

                            MessageBox.Show(strMsg, "�ۑ�����", MessageBoxButtons.OK, MessageBoxIcon.Information)
                        Else
                            MessageBox.Show("�ۑ������Ɏ��s���܂����B", "�ۑ����s", MessageBoxButtons.OK, MessageBoxIcon.Error)
                        End If
                    End If

                Case 2  '���F�\��

                    '���̓`�F�b�N
                    If FunCheckInput(ENM_SAVE_MODE._2_���F�\��) Then
                        Dim strMsg As String
                        If FunGetNextSYONIN_JUN(PrCurrentStage) = ENM_ZESEI_STAGE._999_Closed Then
                            strMsg = "���F�ECLOSE���܂����H"
                        Else
                            strMsg = "���F�E�\�����܂����H"
                        End If

                        If MessageBox.Show(strMsg, "���F�E�\�������m�F", MessageBoxButtons.YesNo, MessageBoxIcon.Information) = DialogResult.Yes Then
                            If FunSAVE(ENM_SAVE_MODE._2_���F�\��) Then
                                If PrCurrentStage = ENM_ZESEI_STAGE._52_�v���������m�F_�F�� Then
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
                Case 4
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

                    Call FunOpenReport()

                Case 11 '����
                    Call OpenFormHistory(Context.ENM_SYONIN_HOKOKUSYO_ID._4_FCCB, PrHOKOKU_NO)

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

                    If FunSAVE_D013(DB, enmSAVE_MODE) = False Then blnErr = True : Return False
                    If FunSAVE_FILE(DB) = False Then blnErr = True : Return False

                    If Not blnTENSO And PrCurrentStage < ENM_ZESEI_STAGE._999_Closed Then
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

        If _D013.FILE_PATH1.IsNulOrWS And
            _D013.FILE_PATH2.IsNulOrWS And
            _D013.FILE_PATH3.IsNulOrWS And
            _D013.FILE_PATH4.IsNulOrWS And
            _D013.FILE_PATH5.IsNulOrWS Then
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
                    System.IO.Directory.CreateDirectory(strRootDir & _D013.HOKOKU_NO)

#Region "1"

                    If Not _D013.FILE_PATH1.IsNulOrWS AndAlso
                        Not System.IO.File.Exists(strRootDir & _D013.HOKOKU_NO.Trim & "\" & _D013.FILE_PATH1) Then

                        If System.IO.File.Exists(lbltmpFile1.Links.Item(0).LinkData) Then
                            System.IO.File.Copy(lbltmpFile1.Links.Item(0).LinkData, strRootDir & _D013.HOKOKU_NO.Trim & "\" & _D013.FILE_PATH1, True)
                        Else
                            Throw New IO.FileNotFoundException($"�Y�t����1:{lbltmpFile1.Links.Item(0).LinkData}��������܂���B���̏ꏊ�ɖ߂����I���������Ă�������")
                        End If
                    End If

#End Region

#Region "2"

                    If Not _D013.FILE_PATH2.IsNulOrWS AndAlso
                        Not System.IO.File.Exists(strRootDir & _D013.HOKOKU_NO.Trim & "\" & _D013.FILE_PATH2) Then

                        If System.IO.File.Exists(lbltmpFile2.Links.Item(0).LinkData) Then
                            System.IO.File.Copy(lbltmpFile2.Links.Item(0).LinkData, strRootDir & _D013.HOKOKU_NO.Trim & "\" & _D013.FILE_PATH2, True)
                        Else
                            Throw New IO.FileNotFoundException($"�Y�t����2:{lbltmpFile2.Links.Item(0).LinkData}��������܂���B���̏ꏊ�ɖ߂����I���������Ă�������")
                        End If
                    End If

#End Region

#Region "3"

                    If Not _D013.FILE_PATH3.IsNulOrWS AndAlso
                        Not System.IO.File.Exists(strRootDir & _D013.HOKOKU_NO.Trim & "\" & _D013.FILE_PATH3) Then

                        If System.IO.File.Exists(lbltmpFile3.Links.Item(0).LinkData) Then
                            System.IO.File.Copy(lbltmpFile3.Links.Item(0).LinkData, strRootDir & _D013.HOKOKU_NO.Trim & "\" & _D013.FILE_PATH3, True)
                        Else
                            Throw New IO.FileNotFoundException($"�Y�t����3:{lbltmpFile3.Links.Item(0).LinkData}��������܂���B���̏ꏊ�ɖ߂����I���������Ă�������")
                        End If
                    End If

#End Region

#Region "4"

                    If Not _D013.FILE_PATH4.IsNulOrWS AndAlso
                        Not System.IO.File.Exists(strRootDir & _D013.HOKOKU_NO.Trim & "\" & _D013.FILE_PATH4) Then

                        If System.IO.File.Exists(lbltmpFile4.Links.Item(0).LinkData) Then
                            System.IO.File.Copy(lbltmpFile4.Links.Item(0).LinkData, strRootDir & _D013.HOKOKU_NO.Trim & "\" & _D013.FILE_PATH4, True)
                        Else
                            Throw New IO.FileNotFoundException($"�Y�t����4:{lbltmpFile4.Links.Item(0).LinkData}��������܂���B���̏ꏊ�ɖ߂����I���������Ă�������")
                        End If
                    End If

#End Region

#Region "5"

                    If Not _D013.FILE_PATH5.IsNulOrWS AndAlso
                        Not System.IO.File.Exists(strRootDir & _D013.HOKOKU_NO.Trim & "\" & _D013.FILE_PATH5) Then

                        If System.IO.File.Exists(lbltmpFile5.Links.Item(0).LinkData) Then
                            System.IO.File.Copy(lbltmpFile5.Links.Item(0).LinkData, strRootDir & _D013.HOKOKU_NO.Trim & "\" & _D013.FILE_PATH5, True)
                        Else
                            Throw New IO.FileNotFoundException($"�Y�t����5:{lbltmpFile5.Links.Item(0).LinkData}��������܂���B���̏ꏊ�ɖ߂����I���������Ă�������")
                        End If
                    End If

#End Region

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

#Region "   D013"

    ''' <summary>
    ''' FCCB�X�V
    ''' </summary>
    ''' <param name="DB"></param>
    ''' <returns></returns>
    Private Function FunSAVE_D013(ByRef DB As ClsDbUtility, ByVal enmSAVE_MODE As ENM_SAVE_MODE) As Boolean
        Dim sbSQL As New System.Text.StringBuilder
        Dim strRET As String
        Dim sqlEx As New Exception
        Dim strSysDate As String = DB.GetSysDateString

#Region "���f���X�V"

        If _D013.HOKOKU_NO.IsNulOrWS Or _D013.HOKOKU_NO = "<�V�K>" Then
            Dim objParam As System.Data.Common.DbParameter = DB.DbCommand.CreateParameter
            Dim lstParam As New List(Of System.Data.Common.DbParameter)
            With objParam
                .ParameterName = "HOKOKU_NO"
                .DbType = DbType.String
                .Direction = ParameterDirection.Output
                .Size = 8
            End With
            lstParam.Add(objParam)
            If DB.Fun_blnExecStored("dbo.ST06_GET_ZESEI_NO", lstParam) = True Then
                _D013.HOKOKU_NO = DB.DbCommand.Parameters("HOKOKU_NO").Value
            Else
                Return False
            End If
        End If

        If (FunGetNextSYONIN_JUN(PrCurrentStage) = ENM_ZESEI_STAGE._999_Closed) And enmSAVE_MODE = ENM_SAVE_MODE._2_���F�\�� Then
            _D013._CLOSE_FG = 1
        End If
        _D013.ADD_YMDHNS = strSysDate
        _D013.ADD_SYAIN_ID = pub_SYAIN_INFO.SYAIN_ID
        _D013.UPD_YMDHNS = strSysDate
        _D013.UPD_SYAIN_ID = pub_SYAIN_INFO.SYAIN_ID
        _D013.DEL_YMDHNS = ""
        _D013.DEL_SYAIN_ID = 0

#Region "���t�t�H�[�}�b�g���H"

        'CHECK: �{���s�v�̂͂��H
        Dim dt As DateTime
        If DateTime.TryParse(_D013.KAITOU_KIBOU_YMD, dt) Then
            _D013.KAITOU_KIBOU_YMD = CDate(_D013.KAITOU_KIBOU_YMD).ToString("yyyyMMdd")
        End If
        If DateTime.TryParse(_D013.KAITOU_YMD, dt) Then
            _D013.KAITOU_YMD = CDate(_D013.KAITOU_YMD).ToString("yyyyMMdd")
        End If

        If DateTime.TryParse(_D013.OUKYU_SYOCHI_YMD, dt) Then
            _D013.OUKYU_SYOCHI_YMD = CDate(_D013.OUKYU_SYOCHI_YMD).ToString("yyyyMMdd")
        End If
        If DateTime.TryParse(_D013.OUKYU_SYOCHI_YOTEI_YMD, dt) Then
            _D013.OUKYU_SYOCHI_YOTEI_YMD = CDate(_D013.OUKYU_SYOCHI_YOTEI_YMD).ToString("yyyyMMdd")
        End If
        If DateTime.TryParse(_D013.ZESEI_SYOCHI_YMD, dt) Then
            _D013.ZESEI_SYOCHI_YMD = CDate(_D013.ZESEI_SYOCHI_YMD).ToString("yyyyMMdd")
        End If
        If DateTime.TryParse(_D013.ZESEI_SYOCHI_YOTEI_YMD, dt) Then
            _D013.ZESEI_SYOCHI_YOTEI_YMD = CDate(_D013.ZESEI_SYOCHI_YOTEI_YMD).ToString("yyyyMMdd")
        End If

#End Region

#End Region

        '-----MERGE
        sbSQL.Remove(0, sbSQL.Length)
        sbSQL.Append($"MERGE INTO {NameOf(D013_ZESEI_HASSEI_J)} AS TARGET")
        sbSQL.Append($" USING (")
        sbSQL.Append($"{_D013.ToSelectSqlString}")
        sbSQL.Append($" ) AS WK")
        sbSQL.Append($" ON (TARGET.{NameOf(_D013.HOKOKU_NO)} = WK.{NameOf(_D013.HOKOKU_NO)})")
        '---UPDATE
        sbSQL.Append($" WHEN MATCHED THEN")
        sbSQL.Append($" {_D013.ToUpdateSqlString("TARGET", "WK")}")
        '---INSERT
        sbSQL.Append($" WHEN NOT MATCHED THEN")
        sbSQL.Append($" {_D013.ToInsertSqlString("WK")}")
        sbSQL.Append(" OUTPUT $action As RESULT;")
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
        WL.WriteLogDat($"[DEBUG]FCCB �񍐏�NO:{_D013.HOKOKU_NO}�AMERGE D013_ZESEI_HASSEI_J")

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

        Try

#Region "   CurrentStage"

            '-----�f�[�^���f���X�V
            _D004_SYONIN_J_KANRI.clear()
            _D004_SYONIN_J_KANRI.SYONIN_HOKOKUSYO_ID = Context.ENM_SYONIN_HOKOKUSYO_ID._5_ZESEI
            _D004_SYONIN_J_KANRI.HOKOKU_NO = _D013.HOKOKU_NO
            _D004_SYONIN_J_KANRI.MAIL_SEND_FG = True
            _D004_SYONIN_J_KANRI.ADD_SYAIN_ID = pub_SYAIN_INFO.SYAIN_ID
            _D004_SYONIN_J_KANRI.ADD_YMDHNS = strSysDate

            If PrCurrentStage = ENM_ZESEI_STAGE._10_�N������ Then
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
                    _D004_SYONIN_J_KANRI.SYONIN_HANTEI_KB = ENM_SYONIN_HANTEI_KB._0_�����F
                Case ENM_SAVE_MODE._2_���F�\��
                    _D004_SYONIN_J_KANRI.SYONIN_HANTEI_KB = ENM_SYONIN_HANTEI_KB._1_���F
                Case Else
                    'Err
                    Return False
            End Select
            _D004_SYONIN_J_KANRI.SYONIN_JUN = PrCurrentStage
            _D004_SYONIN_J_KANRI.SYAIN_ID = pub_SYAIN_INFO.SYAIN_ID
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

                    _D004_SYONIN_J_KANRI.SYAIN_ID = FunGetNextSYONIN_TANTO_ID(PrCurrentStage)

                Case Else
                    'Err
                    Return False
            End Select

            '-----Close����
            If _D004_SYONIN_J_KANRI.SYONIN_JUN = ENM_ZESEI_STAGE._999_Closed Then
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
                    If PrCurrentStage < ENM_ZESEI_STAGE._52_�v���������m�F_�F�� AndAlso FunSendRequestMail() Then
                        WL.WriteLogDat($"[DEBUG]�������u �񍐏�NO:{_D013.HOKOKU_NO}�ASend Request Mail")
                    End If

                Case "UPDATE"

                Case Else
                    '-----�G���[���O�o��
                    Dim strErrMsg As String = My.Resources.ErrLogSqlExecutionFailure & sbSQL.ToString & "|" & sqlEx.Message
                    WL.WriteLogDat(strErrMsg)
                    Return False
            End Select

            WL.WriteLogDat($"[DEBUG]�������u �񍐏�NO:{_D013.HOKOKU_NO}�AMERGE D004")

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
    Private Function FunSendRequestMail(Optional toUserNAME As String = "", Optional fromUserNAME As String = "") As Boolean

        Try

            Dim SYONIN_HANTEI_NAME As String = tblSYONIN_HANTEI_KB.LazyLoad("���F����敪").
                                                                   AsEnumerable.
                                                                   Where(Function(r) r.Field(Of String)("VALUE") = _D004_SYONIN_J_KANRI.SYONIN_HANTEI_KB).
                                                                   FirstOrDefault?.Item("DISP")

            Dim strEXEParam As String = $"{_D004_SYONIN_J_KANRI.SYAIN_ID},{ENM_OPEN_MODE._2_���u��ʋN��.Value},{Context.ENM_SYONIN_HOKOKUSYO_ID._5_ZESEI.Value},{_D004_SYONIN_J_KANRI.HOKOKU_NO}"
            Dim strSubject As String = $"�y�������u�˗��z:{_D004_SYONIN_J_KANRI.HOKOKU_NO}"
            Dim ToUsers As New List(Of Integer)

            ToUsers.Add(_D004_SYONIN_J_KANRI.SYAIN_ID)

            Dim strBody As String = <sql><![CDATA[
                {0}<br />
                <br />
        �@        �������u�v�����̏��u���e�̊m�F�Ə��F�����肢���܂��B<br />
                <br />        �@�@
        �@�@        �y�񍐏�No�z{1}<br />
        �@�@        �y�N �� ���z{2}<br />        �@�@
        �@�@        �y�� �� �ҁz{5}<br />        �@�@
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
                                DateTime.ParseExact(_D013.ADD_YMDHNS, "yyyyMMddHHmmss", Nothing).ToString("yyyy/MM/dd"),
                                "",
                                "",
                                If(fromUserNAME = "", Fun_GetUSER_NAME(pub_SYAIN_INFO.SYAIN_ID), fromUserNAME),
                                SYONIN_HANTEI_NAME,
                                _D004_SYONIN_J_KANRI.COMMENT,
                                _D004_SYONIN_J_KANRI.SYAIN_ID,
                                "FMS_G0030.exe",
                                strEXEParam)

            If ToUsers.Count = 0 Then
                MessageBox.Show("���M�҂�������Ȃ����߁A�˗����[���𑗐M�ł��܂���", "�˗����[�����M", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Return False
            Else
                If FunSendMailZESEI(strSubject, strBody, ToUsers, blnSendSenior:=False) Then
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
        _R001_HOKOKU_SOUSA.SYONIN_HOKOKUSYO_ID = Context.ENM_SYONIN_HOKOKUSYO_ID._5_ZESEI
        _R001_HOKOKU_SOUSA.HOKOKU_NO = _D013.HOKOKU_NO
        _R001_HOKOKU_SOUSA.SYONIN_JUN = PrCurrentStage
        _R001_HOKOKU_SOUSA.SYAIN_ID = pub_SYAIN_INFO.SYAIN_ID
        _R001_HOKOKU_SOUSA.RIYU = PrRIYU
        _R001_HOKOKU_SOUSA.ADD_YMDHNS = strSysDate 'Now.ToString("yyyyMMddHHmmss")

        Select Case enmSAVE_MODE
            Case ENM_SAVE_MODE._1_�ۑ�

                If PrCurrentStage = ENM_ZESEI_STAGE._999_Closed Then
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

        'WL.WriteLogDat($"[DEBUG]CTS �񍐏�NO:{_D013.HOKOKU_NO}�AINSERT R001")

        Return True
    End Function

#End Region

#End Region

#Region "�]��"

    Private Function OpenFormTENSO() As Boolean
        Dim frmDLG As New FrmG0035_Tenso
        Dim dlgRET As DialogResult

        Try
            frmDLG.PrUsers = FunGetCurrentSYONIN_TANTO(PrCurrentStage)
            frmDLG.PrSYONIN_HOKOKUSYO_ID = Context.ENM_SYONIN_HOKOKUSYO_ID._5_ZESEI
            frmDLG.PrHOKOKU_NO = PrHOKOKU_NO
            frmDLG.PrBUMON_KB = _D013.BUMON_KB
            'frmDLG.PrKISO_YMD = DateTime.ParseExact(_D013.ADD_YMD, "yyyyMMdd", Nothing).ToString("yyyy/MM/dd")
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
            frmDLG.PrSYONIN_HOKOKUSYO_ID = Context.ENM_SYONIN_HOKOKUSYO_ID._5_ZESEI
            frmDLG.PrHOKOKU_NO = PrHOKOKU_NO
            frmDLG.PrBUHIN_BANGO = ""
            frmDLG.PrKISO_YMD = CDate(_D013.ADD_YMDHNS).ToString("yyyy/MM/dd")
            frmDLG.PrKISYU_NAME = ""
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

    Private Function FunOpenReport() As Boolean
        Dim strOutputFileName As String
        Dim strTEMPFILE As String
        'Dim intRET As Integer

        Try
            Me.Cursor = Cursors.WaitCursor

            '�t�@�C����
            strOutputFileName = "ZESEI_" & _D013.HOKOKU_NO & "_Work.xls"

            '�����t�@�C���폜
            If FunDELETE_FILE(pub_APP_INFO.strOUTPUT_PATH & strOutputFileName) = False Then
                Return False
            End If

            Using iniIF As New IniFile(FunGetRootPath() & "\INI\" & CON_TEMPLATE_INI)
                strTEMPFILE = FunConvRootPath(iniIF.GetIniString("ZESEI_HASSEI", "FILEPATH"))
            End Using

            '�G�N�Z���o�̓t�@�C���p��
            If OUT_EXCEL_READY(strTEMPFILE, pub_APP_INFO.strOUTPUT_PATH, strOutputFileName) = False Then
                Return False
            End If
            '-----��������
            If FunMakeReportZESEI_HASSEI(pub_APP_INFO.strOUTPUT_PATH & strOutputFileName, _D013.HOKOKU_NO) = False Then
                Return False
            End If

            Return True 'FunOpenExcelApp(pub_APP_INFO.strOUTPUT_PATH & strOutputFileName)
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
            frmDLG.PrSYONIN_HOKOKUSYO_ID = Context.ENM_SYONIN_HOKOKUSYO_ID._5_ZESEI
            frmDLG.PrHOKOKU_NO = _D013.HOKOKU_NO
            frmDLG.PrBUMON_KB = _D013.BUMON_KB
            frmDLG.PrKISO_YMD = DateTime.ParseExact(_D013.ADD_YMD, "yyyyMMdd", Nothing).ToString("yyyy/MM/dd")
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

            '�J�����g�X�e�[�W�����g�̒S���łȂ��ꍇ�͖���
            Dim IsOwnCreated As Boolean = FunblnOwnCreated(Context.ENM_SYONIN_HOKOKUSYO_ID._5_ZESEI.Value, _D013.HOKOKU_NO, PrCurrentStage)

            If PrMODE = ENM_DATA_OPERATION_MODE._1_ADD Then

                cmdFunc1.Enabled = True
                cmdFunc2.Enabled = IsOwnCreated

                cmdFunc4.Enabled = False
                cmdFunc5.Enabled = False
                cmdFunc10.Enabled = False
                cmdFunc11.Enabled = False
            Else

                cmdFunc1.Enabled = True
                cmdFunc2.Enabled = IsOwnCreated

                cmdFunc5.Enabled = IsOwnCreated

                cmdFunc10.Enabled = True
                cmdFunc11.Enabled = True

                Dim blnIsAdmin As Boolean = IsSysAdminUser(pub_SYAIN_INFO.SYAIN_ID)
                cmdFunc5.Enabled = blnIsAdmin

                cmdFunc4.Visible = True

                Select Case PrCurrentStage
                    Case ENM_ZESEI_STAGE._10_�N������
                        cmdFunc5.Enabled = False

                    Case ENM_ZESEI_STAGE._20_�������u����

                    Case ENM_ZESEI_STAGE._30_���u���ʓ���
                    Case ENM_ZESEI_STAGE._40_���u���ʃ��r���[

                    Case ENM_ZESEI_STAGE._50_�v���������m�F

                    Case ENM_ZESEI_STAGE._999_Closed
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

#Region "�X�e�[�W���X�g"

    Private Sub RsbtnST_CheckedChanged(sender As Object, e As EventArgs) Handles rsbtnST01.CheckedChanged,
                                                                        rsbtnST02.CheckedChanged,
                                                                        rsbtnST03.CheckedChanged,
                                                                        rsbtnST04.CheckedChanged,
                                                                        rsbtnST05.CheckedChanged

        Dim btn As RibbonShapeRadioButton = DirectCast(sender, RibbonShapeRadioButton)
        Dim intStageID As Integer = Val(btn.Name.Substring(7))
        TabPageEx1.AutoScrollControlIntoView = True
        Dim pnl As PanelEx = DirectCast(TabPageEx1.Controls("pnlST" & intStageID.ToString("00")), PanelEx)
        Me.TabPageEx1.ScrollControlIntoView(pnl.Controls("lblSTAGEFlame" & intStageID.ToString("00")))
        TabPageEx1.AutoScrollControlIntoView = False

        For Each ctrl As Control In TabPageEx1.Controls
            If ctrl.GetType Is GetType(PanelEx) Then
                Dim panel As PanelEx = DirectCast(ctrl, PanelEx)
                If panel.Name = "pnlST" & intStageID.ToString("00") Then
                    panel.BorderStyle = BorderStyle.FixedSingle
                Else
                    panel.BorderStyle = BorderStyle.None
                End If
            End If
        Next ctrl

    End Sub

#End Region

#Region "�\����Ј�"

    Private Sub CmbDestTANTO_SelectedvalueChanged(sender As Object, e As EventArgs)
        Dim cmb As ComboboxEx = DirectCast(sender, ComboboxEx)
        Dim caption As String = [Enum].GetName(GetType(ENM_SAVE_MODE), PrCurrentStage)
        IsValidated *= ErrorProvider.UpdateErrorInfo(cmb, cmb.IsSelected, String.Format(My.Resources.infoMsgRequireSelectOrInput, caption))
        Call FunInitFuncButtonEnabled()
    End Sub

#End Region

#Region "�w�b�_"

    Private Sub cmbBUMON_SelectedValueChanged(sender As Object, e As EventArgs) Handles cmbBUMON.SelectedValueChanged
        Dim dtKA As DataTable
        Dim dtTANTO As DataTableEx

        Try

            If cmbBUMON.SelectedValue.ToString.IsNulOrWS Then
                dtKA = tblKA
                dtTANTO = Nothing
            Else
                Dim dr As List(Of DataRow)
                dr = tblKA.AsEnumerable.Where(Function(r) r.Item("BUMON_KB") = cmbBUMON.SelectedValue).ToList
                If dr.Count > 0 Then
                    dtKA = dr.CopyToDataTable
                Else
                    dtKA = Nothing
                End If

                dtTANTO = GetExcludeyakusyokuUsers(cmbBUMON.SelectedValue, {ENM_YAKUSYOKU_KB._14_SL.Value, ENM_YAKUSYOKU_KB._99_�Ȃ�.Value}.ToList)

            End If
            If dtKA IsNot Nothing Then
                cmbKA.SetDataSource(dtKA.ExcludeDeleted, ENM_COMBO_SELECT_VALUE_TYPE._2_Option)
            Else
                cmbKA.DataSource = Nothing
                cmbKA.DisplayMember = "DISP"
                cmbKA.ValueMember = "VALUE"
            End If
            If dtTANTO IsNot Nothing Then
                cmbTANTO.SetDataSource(dtTANTO.ExcludeDeleted, ENM_COMBO_SELECT_VALUE_TYPE._0_Required)
            Else
                cmbTANTO.DataSource = Nothing
                cmbTANTO.DisplayMember = "DISP"
                cmbTANTO.ValueMember = "VALUE"
            End If

            _D013.BUMON_KB = cmbBUMON.SelectedValue
            Call FunInitializeSTAGE(PrCurrentStage)
        Catch ex As Exception
            Throw
        End Try

    End Sub

    Private Sub cmbKA_SelectedValueChanged(sender As Object, e As EventArgs) Handles cmbKA.SelectedValueChanged
        Dim dt As DataTable
        If cmbKA.SelectedValue.ToString.IsNulOrWS Then
            Dim dr As List(Of DataRow)
            dr = tblTANTO.AsEnumerable.Where(Function(r) r.Item("BUMON_KB") = cmbBUMON.SelectedValue).ToList
            If dr.Count > 0 Then
                dt = dr.CopyToDataTable
            Else
                dt = tblTANTO
            End If
        Else
            Dim drs = tblTANTO.AsEnumerable.Where(Function(r) r.Item("BUSYO_ID") = cmbKA.SelectedValue Or r.Item("OYA_BUSYO_ID") = cmbKA.SelectedValue).ToList
            If drs.Count > 0 Then
                dt = drs.CopyToDataTable
            End If
            If dt IsNot Nothing Then
                cmbTANTO.SetDataSource(dt.ExcludeDeleted, ENM_COMBO_SELECT_VALUE_TYPE._0_Required)
            Else
                cmbTANTO.DataSource = Nothing
                cmbTANTO.DisplayMember = "DISP"
                cmbTANTO.ValueMember = "VALUE"
            End If
        End If
    End Sub

    Private Sub cmbBUMON_Validated(sender As Object, e As EventArgs) Handles cmbBUMON.Validated
        Dim cmb As ComboboxEx = DirectCast(sender, ComboboxEx)
        IsValidated *= ErrorProvider.UpdateErrorInfo(cmb, cmb.IsSelected, String.Format(My.Resources.infoMsgRequireSelectOrInput, "���i�敪"))
    End Sub

    'Private Sub cmbKA_Validated(sender As Object, e As EventArgs) Handles cmbKA.Validated
    '    Dim cmb As ComboboxEx = DirectCast(sender, ComboboxEx)
    '    IsValidated *= ErrorProvider.UpdateErrorInfo(cmb, cmb.IsSelected, String.Format(My.Resources.infoMsgRequireSelectOrInput, "��"))
    'End Sub

    Private Sub cmbTANTO_Validated(sender As Object, e As EventArgs) Handles cmbTANTO.Validated
        Dim cmb As ComboboxEx = DirectCast(sender, ComboboxEx)
        IsValidated *= ErrorProvider.UpdateErrorInfo(cmb, cmb.IsSelected, String.Format(My.Resources.infoMsgRequireSelectOrInput, "�ӔC��"))
    End Sub

    Private Sub cmbKISO_TANTO_Validated(sender As Object, e As EventArgs)
        Dim cmb As ComboboxEx = DirectCast(sender, ComboboxEx)
        IsValidated *= ErrorProvider.UpdateErrorInfo(cmb, cmb.IsSelected, String.Format(My.Resources.infoMsgRequireSelectOrInput, "�N����"))
    End Sub

#End Region

#Region "ST1"

    Private Sub dtKAITOU_KIBOU_YMD_Validating(sender As Object, e As System.ComponentModel.CancelEventArgs) Handles dtKAITOU_KIBOU_YMD.Validating
        Dim dtx As DateTextBoxEx = DirectCast(sender, DateTextBoxEx)
        If IsCheckRequired Then
            IsValidated *= ErrorProvider.UpdateErrorInfo(dtx, Not dtx.ValueNonFormat.IsNulOrWS, String.Format(My.Resources.infoMsgRequireSelectOrInput, "������"))
        End If
    End Sub

    Private Sub txtKANSATU_HOUKOKU_Validated(sender As Object, e As EventArgs) Handles txtKANSATU_HOUKOKU.Validated
        Dim txt As TextBoxEx = DirectCast(sender, TextBoxEx)
        If IsCheckRequired Then
            IsValidated *= ErrorProvider.UpdateErrorInfo(txt, Not txt.Text.IsNulOrWS, String.Format(My.Resources.infoMsgRequireSelectOrInput, "�ώ@�^�񍐎���"))
        End If
    End Sub

    Private Sub txtZESEI_RIYU_Validated(sender As Object, e As EventArgs) Handles txtZESEI_RIYU.Validated
        Dim txt As TextBoxEx = DirectCast(sender, TextBoxEx)
        If IsCheckRequired Then
            IsValidated *= ErrorProvider.UpdateErrorInfo(txt, Not txt.Text.IsNulOrWS, String.Format(My.Resources.infoMsgRequireSelectOrInput, "�������u��K�v�Ƃ��闝�R"))
        End If
    End Sub

    Private Sub txtZESEI_COMMENT_Validated(sender As Object, e As EventArgs) Handles txtZESEI_COMMENT.Validated
        Dim txt As TextBoxEx = DirectCast(sender, TextBoxEx)
        If IsCheckRequired Then
            IsValidated *= ErrorProvider.UpdateErrorInfo(txt, Not txt.Text.IsNulOrWS, String.Format(My.Resources.infoMsgRequireSelectOrInput, "�������͉��P���ɂ��Ă̗v�]�A���̑��̃R�����g"))
        End If
    End Sub

    Private Sub txtDOC_NO_Validated(sender As Object, e As EventArgs) Handles txtDOC_NO.Validated
        Dim txt As TextBoxEx = DirectCast(sender, TextBoxEx)
        If IsCheckRequired Then
            IsValidated *= ErrorProvider.UpdateErrorInfo(txt, Not txt.Text.IsNulOrWS, String.Format(My.Resources.infoMsgRequireSelectOrInput, "�����ԍ�"))
        End If
    End Sub

#End Region

#Region "ST2"

    Private Sub txtFUTEKIGO_TAISYOU_Validated(sender As Object, e As EventArgs) Handles txtFUTEKIGO_TAISYOU.Validated
        Dim txt As TextBoxEx = DirectCast(sender, TextBoxEx)
        If IsCheckRequired Then
            IsValidated *= ErrorProvider.UpdateErrorInfo(txt, Not txt.Text.IsNulOrWS, String.Format(My.Resources.infoMsgRequireSelectOrInput, "�s�K���Ώ�(���ڂ̑Ώ�)"))
        End If
    End Sub

    Private Sub txtCHOUSA_HANI_Validated(sender As Object, e As EventArgs) Handles txtCHOUSA_HANI.Validated
        Dim txt As TextBoxEx = DirectCast(sender, TextBoxEx)
        If IsCheckRequired Then
            IsValidated *= ErrorProvider.UpdateErrorInfo(txt, Not txt.Text.IsNulOrWS, String.Format(My.Resources.infoMsgRequireSelectOrInput, "�����͈�"))
        End If
    End Sub

    Private Sub txtEIKYOU_HANI_Validated(sender As Object, e As EventArgs) Handles txtEIKYOU_HANI.Validated
        Dim txt As TextBoxEx = DirectCast(sender, TextBoxEx)
        If IsCheckRequired Then
            IsValidated *= ErrorProvider.UpdateErrorInfo(txt, Not txt.Text.IsNulOrWS, String.Format(My.Resources.infoMsgRequireSelectOrInput, "�e�������肳�ꂽ�͈�"))
        End If
    End Sub

    Private Sub txtOUKYU_SYOCHI_Validated(sender As Object, e As EventArgs) Handles txtOUKYU_SYOCHI.Validated
        Dim txt As TextBoxEx = DirectCast(sender, TextBoxEx)
        If IsCheckRequired Then
            IsValidated *= ErrorProvider.UpdateErrorInfo(txt, Not txt.Text.IsNulOrWS, String.Format(My.Resources.infoMsgRequireSelectOrInput, "��������"))
        End If
    End Sub

    Private Sub txtHASSEI_GENIN_Validated(sender As Object, e As EventArgs) Handles txtHASSEI_GENIN.Validated
        Dim txt As TextBoxEx = DirectCast(sender, TextBoxEx)
        If IsCheckRequired Then
            IsValidated *= ErrorProvider.UpdateErrorInfo(txt, Not txt.Text.IsNulOrWS, String.Format(My.Resources.infoMsgRequireSelectOrInput, "��������"))
        End If
    End Sub

    Private Sub txtZESEI_SYOCHI_Validated(sender As Object, e As EventArgs) Handles txtZESEI_SYOCHI.Validated
        Dim txt As TextBoxEx = DirectCast(sender, TextBoxEx)
        If IsCheckRequired Then
            IsValidated *= ErrorProvider.UpdateErrorInfo(txt, Not txt.Text.IsNulOrWS, String.Format(My.Resources.infoMsgRequireSelectOrInput, "�������u"))
        End If
    End Sub

#End Region

#Region "ST3"

    Private Sub txtOUKYU_SYOCHI_KEKKA_Validated(sender As Object, e As EventArgs) Handles txtOUKYU_SYOCHI_KEKKA.Validated
        Dim txt As TextBoxEx = DirectCast(sender, TextBoxEx)
        If IsCheckRequired Then
            IsValidated *= ErrorProvider.UpdateErrorInfo(txt, Not txt.Text.IsNulOrWS, String.Format(My.Resources.infoMsgRequireSelectOrInput, "���}���u���{����"))
        End If
    End Sub

    Private Sub txtZESEI_SYOCHI_KEKKA_Validated(sender As Object, e As EventArgs) Handles txtZESEI_SYOCHI_KEKKA.Validated
        Dim txt As TextBoxEx = DirectCast(sender, TextBoxEx)
        If IsCheckRequired Then
            IsValidated *= ErrorProvider.UpdateErrorInfo(txt, Not txt.Text.IsNulOrWS, String.Format(My.Resources.infoMsgRequireSelectOrInput, "�������u���{����"))
        End If
    End Sub

#End Region

#Region "�`�F�b�N����"

    Private Sub rbtnINPUT_TYPE_CheckedChanged(sender As Object, e As EventArgs) Handles rbtnINPUT_TYPE1.CheckedChanged,
                                                                                          rbtnINPUT_TYPE2.CheckedChanged,
                                                                                          rbtnINPUT_TYPE3.CheckedChanged
        Dim val As String
        Select Case True
            Case rbtnINPUT_TYPE1.Checked
                val = "1"
            Case rbtnINPUT_TYPE2.Checked
                val = "2"
            Case rbtnINPUT_TYPE3.Checked
                val = "3"
            Case Else
                val = ""
        End Select
        txtINPUT_TYPE.Text = val

        If IsCheckRequired Then
            IsValidated *= ErrorProvider.UpdateErrorInfo(pnlINPUT_TYPE, Not txtINPUT_TYPE.Text.IsNulOrWS, String.Format(My.Resources.infoMsgRequireSelectOrInput, "�C���v�b�g���"))
        End If
    End Sub

    Private Sub chkST02_FUTEKIGO_UMU_CheckedChanged(sender As Object, e As EventArgs) Handles rbtnST02_FUTEKIGO_YES.CheckedChanged,
                                                                                          rbtnST02_FUTEKIGO_NO.CheckedChanged

        Select Case True
            Case rbtnST02_FUTEKIGO_YES.Checked
                chkST02_FUTEKIGO_UMU.Checked = True
            Case Else
                chkST02_FUTEKIGO_UMU.Checked = False
        End Select
    End Sub

    Private Sub chkJINTEKI_YOUIN_UMU_CheckedChanged(sender As Object, e As EventArgs) Handles rbtnFUTEKIGO_YOUIN_T.CheckedChanged,
                                                                                          rbtnFUTEKIGO_YOUIN_F.CheckedChanged

        Select Case True
            Case rbtnFUTEKIGO_YOUIN_T.Checked
                chkJINTEKI_YOUIN_UMU.Checked = True
            Case Else
                chkJINTEKI_YOUIN_UMU.Checked = False
        End Select
    End Sub

    Private Sub chkZESEI_SYOCHI_HANTEI_CheckedChanged(sender As Object, e As EventArgs) Handles rbtnZESEI_SYOCHI_YES.CheckedChanged,
                                                                                          rbtnZESEI_SYOCHI_NO.CheckedChanged

        Select Case True
            Case rbtnZESEI_SYOCHI_YES.Checked
                chkZESEI_SYOCHI_HANTEI.Checked = True
            Case Else
                chkZESEI_SYOCHI_HANTEI.Checked = False
        End Select
    End Sub

#End Region

    Private Sub dtKAITOU_KIBOU_YMD_Validated(sender As Object, e As EventArgs) Handles dtKAITOU_KIBOU_YMD.Validated
        _D013.KAITOU_KIBOU_YMD = dtKAITOU_KIBOU_YMD.Text
    End Sub

    Private Sub dtKAITOU_YMD_Validated(sender As Object, e As EventArgs) Handles dtKAITOU_YMD.Validated
        _D013.KAITOU_YMD = dtKAITOU_YMD.Text
    End Sub

    Private Sub dtOUKYU_SYOCHI_YOTEI_YMD_Validated(sender As Object, e As EventArgs) Handles dtOUKYU_SYOCHI_YOTEI_YMD.Validated
        _D013.OUKYU_SYOCHI_YOTEI_YMD = dtOUKYU_SYOCHI_YOTEI_YMD.Text
    End Sub

    Private Sub dtZESEI_SYOCHI_YOTEI_YMD_Validated(sender As Object, e As EventArgs) Handles dtZESEI_SYOCHI_YOTEI_YMD.Validated
        _D013.ZESEI_SYOCHI_YOTEI_YMD = dtZESEI_SYOCHI_YOTEI_YMD.Text
    End Sub

    Private Sub dtOUKYU_SYOCHI_YMD_Validated(sender As Object, e As EventArgs) Handles dtOUKYU_SYOCHI_YMD.Validated
        _D013.OUKYU_SYOCHI_YMD = dtOUKYU_SYOCHI_YMD.Text
    End Sub

    Private Sub dtZESEI_SYOCHI_YMD_Validated(sender As Object, e As EventArgs) Handles dtZESEI_SYOCHI_YMD.Validated
        _D013.ZESEI_SYOCHI_YMD = dtZESEI_SYOCHI_YMD.Text
    End Sub

#End Region

#Region "���[�J���֐�"

#Region "�o�C���f�B���O"

    Private Sub ClearBinding()
        mtxHOKOKU_NO.DataBindings.Clear()
        cmbBUMON.DataBindings.Clear()
        cmbKA.DataBindings.Clear()
        cmbTANTO.DataBindings.Clear()
        txtINPUT_TYPE.DataBindings.Clear()
        txtDOC_NO.DataBindings.Clear()
        dtKAITOU_KIBOU_YMD.DataBindings.Clear()
        txtKANSATU_HOUKOKU.DataBindings.Clear()
        txtZESEI_RIYU.DataBindings.Clear()
        txtZESEI_COMMENT.DataBindings.Clear()
        dtKAITOU_YMD.DataBindings.Clear()
        chkST02_FUTEKIGO_UMU.DataBindings.Clear()
        txtFUTEKIGO_TAISYOU.DataBindings.Clear()
        txtCHOUSA_HANI.DataBindings.Clear()

        txtEIKYOU_HANI.DataBindings.Clear()
        txtOUKYU_SYOCHI.DataBindings.Clear()
        dtOUKYU_SYOCHI_YOTEI_YMD.DataBindings.Clear()
        chkJINTEKI_YOUIN_UMU.DataBindings.Clear()
        txtHASSEI_GENIN.DataBindings.Clear()
        txtZESEI_SYOCHI.DataBindings.Clear()
        dtZESEI_SYOCHI_YOTEI_YMD.DataBindings.Clear()
        dtZESEI_SYOCHI_YMD.DataBindings.Clear()
        dtOUKYU_SYOCHI_YMD.DataBindings.Clear()
        txtOUKYU_SYOCHI_KEKKA.DataBindings.Clear()
        txtZESEI_SYOCHI_KEKKA.DataBindings.Clear()
        chkZESEI_SYOCHI_HANTEI.DataBindings.Clear()

        txtCOMMENT1.DataBindings.Clear()
        txtCOMMENT2.DataBindings.Clear()
        txtCOMMENT3.DataBindings.Clear()
        txtCOMMENT4.DataBindings.Clear()
        txtCOMMENT5.DataBindings.Clear()

        lbltmpFile1.DataBindings.Clear()
        lbltmpFile2.DataBindings.Clear()
        lbltmpFile3.DataBindings.Clear()
        lbltmpFile4.DataBindings.Clear()
        lbltmpFile5.DataBindings.Clear()
    End Sub

    Private Function FunSetBinding() As Boolean

        Try

            mtxHOKOKU_NO.DataBindings.Add(New Binding(NameOf(mtxHOKOKU_NO.Text), _D013, NameOf(_D013.HOKOKU_NO), False, DataSourceUpdateMode.OnPropertyChanged, ""))
            cmbBUMON.DataBindings.Add(New Binding(NameOf(cmbBUMON.SelectedValue), _D013, NameOf(_D013.BUMON_KB), False, DataSourceUpdateMode.OnPropertyChanged, ""))
            cmbKA.DataBindings.Add(New Binding(NameOf(cmbKA.SelectedValue), _D013, NameOf(_D013.BUSYO_ID), False, DataSourceUpdateMode.OnPropertyChanged, 0))
            cmbTANTO.DataBindings.Add(New Binding(NameOf(cmbTANTO.SelectedValue), _D013, NameOf(_D013.TANTO_ID), False, DataSourceUpdateMode.OnPropertyChanged, 0))
            txtINPUT_TYPE.DataBindings.Add(New Binding(NameOf(txtINPUT_TYPE.Text), _D013, NameOf(_D013.INPUT_TYPE), False, DataSourceUpdateMode.OnPropertyChanged, ""))
            txtDOC_NO.DataBindings.Add(New Binding(NameOf(txtDOC_NO.Text), _D013, NameOf(_D013.DOC_NO), False, DataSourceUpdateMode.OnPropertyChanged, ""))
            dtKAITOU_KIBOU_YMD.DataBindings.Add(New Binding(NameOf(dtKAITOU_KIBOU_YMD.Text), _D013, NameOf(_D013.KAITOU_KIBOU_YMD), False, DataSourceUpdateMode.OnPropertyChanged, ""))
            txtKANSATU_HOUKOKU.DataBindings.Add(New Binding(NameOf(txtKANSATU_HOUKOKU.Text), _D013, NameOf(_D013.KANSATU_HOUKOKU), False, DataSourceUpdateMode.OnPropertyChanged, ""))
            txtZESEI_RIYU.DataBindings.Add(New Binding(NameOf(txtZESEI_RIYU.Text), _D013, NameOf(_D013.ZESEI_RIYU), False, DataSourceUpdateMode.OnPropertyChanged, ""))
            txtZESEI_COMMENT.DataBindings.Add(New Binding(NameOf(txtZESEI_COMMENT.Text), _D013, NameOf(_D013.ZESEI_COMMENT), False, DataSourceUpdateMode.OnPropertyChanged, ""))
            dtKAITOU_YMD.DataBindings.Add(New Binding(NameOf(dtKAITOU_YMD.Text), _D013, NameOf(_D013.KAITOU_YMD), False, DataSourceUpdateMode.OnPropertyChanged, ""))
            chkST02_FUTEKIGO_UMU.DataBindings.Add(New Binding(NameOf(chkST02_FUTEKIGO_UMU.Checked), _D013, NameOf(_D013.FUTEKIGO_UMU), False, DataSourceUpdateMode.OnPropertyChanged, False))
            txtFUTEKIGO_TAISYOU.DataBindings.Add(New Binding(NameOf(txtFUTEKIGO_TAISYOU.Text), _D013, NameOf(_D013.FUTEKIGO_TAISYOU), False, DataSourceUpdateMode.OnPropertyChanged, ""))
            txtCHOUSA_HANI.DataBindings.Add(New Binding(NameOf(txtCHOUSA_HANI.Text), _D013, NameOf(_D013.CHOUSA_HANI), False, DataSourceUpdateMode.OnPropertyChanged, ""))

            txtEIKYOU_HANI.DataBindings.Add(New Binding(NameOf(txtEIKYOU_HANI.Text), _D013, NameOf(_D013.EIKYOU_HANI), False, DataSourceUpdateMode.OnPropertyChanged, ""))
            txtOUKYU_SYOCHI.DataBindings.Add(New Binding(NameOf(txtOUKYU_SYOCHI.Text), _D013, NameOf(_D013.OUKYU_SYOCHI), False, DataSourceUpdateMode.OnPropertyChanged, ""))
            dtOUKYU_SYOCHI_YOTEI_YMD.DataBindings.Add(New Binding(NameOf(dtOUKYU_SYOCHI_YOTEI_YMD.Text), _D013, NameOf(_D013.OUKYU_SYOCHI_YOTEI_YMD), False, DataSourceUpdateMode.OnPropertyChanged, ""))
            chkJINTEKI_YOUIN_UMU.DataBindings.Add(New Binding(NameOf(chkJINTEKI_YOUIN_UMU.Checked), _D013, NameOf(_D013.JINTEKI_YOUIN_UMU), False, DataSourceUpdateMode.OnPropertyChanged, False))
            txtHASSEI_GENIN.DataBindings.Add(New Binding(NameOf(txtHASSEI_GENIN.Text), _D013, NameOf(_D013.HASSEI_GENIN), False, DataSourceUpdateMode.OnPropertyChanged, ""))
            txtZESEI_SYOCHI.DataBindings.Add(New Binding(NameOf(txtZESEI_SYOCHI.Text), _D013, NameOf(_D013.ZESEI_SYOCHI), False, DataSourceUpdateMode.OnPropertyChanged, ""))
            dtZESEI_SYOCHI_YOTEI_YMD.DataBindings.Add(New Binding(NameOf(dtZESEI_SYOCHI_YOTEI_YMD.Text), _D013, NameOf(_D013.ZESEI_SYOCHI_YOTEI_YMD), False, DataSourceUpdateMode.OnPropertyChanged, ""))
            dtZESEI_SYOCHI_YMD.DataBindings.Add(New Binding(NameOf(dtZESEI_SYOCHI_YMD.Text), _D013, NameOf(_D013.ZESEI_SYOCHI_YMD), False, DataSourceUpdateMode.OnPropertyChanged, ""))
            dtOUKYU_SYOCHI_YMD.DataBindings.Add(New Binding(NameOf(dtOUKYU_SYOCHI_YMD.Text), _D013, NameOf(_D013.OUKYU_SYOCHI_YMD), False, DataSourceUpdateMode.OnPropertyChanged, ""))
            txtOUKYU_SYOCHI_KEKKA.DataBindings.Add(New Binding(NameOf(txtOUKYU_SYOCHI_KEKKA.Text), _D013, NameOf(_D013.OUKYU_SYOCHI_KEKKA), False, DataSourceUpdateMode.OnPropertyChanged, ""))
            txtZESEI_SYOCHI_KEKKA.DataBindings.Add(New Binding(NameOf(txtZESEI_SYOCHI_KEKKA.Text), _D013, NameOf(_D013.ZESEI_SYOCHI_KEKKA), False, DataSourceUpdateMode.OnPropertyChanged, ""))
            chkZESEI_SYOCHI_HANTEI.DataBindings.Add(New Binding(NameOf(chkZESEI_SYOCHI_HANTEI.Checked), _D013, NameOf(_D013.ZESEI_SYOCHI_HANTEI), False, DataSourceUpdateMode.OnPropertyChanged, False))

            txtCOMMENT1.DataBindings.Add(New Binding(NameOf(txtCOMMENT1.Text), _D013, NameOf(_D013.COMMENT1), False, DataSourceUpdateMode.OnPropertyChanged, ""))
            txtCOMMENT2.DataBindings.Add(New Binding(NameOf(txtCOMMENT2.Text), _D013, NameOf(_D013.COMMENT2), False, DataSourceUpdateMode.OnPropertyChanged, ""))
            txtCOMMENT3.DataBindings.Add(New Binding(NameOf(txtCOMMENT3.Text), _D013, NameOf(_D013.COMMENT3), False, DataSourceUpdateMode.OnPropertyChanged, ""))
            txtCOMMENT4.DataBindings.Add(New Binding(NameOf(txtCOMMENT4.Text), _D013, NameOf(_D013.COMMENT4), False, DataSourceUpdateMode.OnPropertyChanged, ""))
            txtCOMMENT5.DataBindings.Add(New Binding(NameOf(txtCOMMENT5.Text), _D013, NameOf(_D013.COMMENT5), False, DataSourceUpdateMode.OnPropertyChanged, ""))

            lbltmpFile1.DataBindings.Add(New Binding(NameOf(lbltmpFile1.Tag), _D013, NameOf(_D013.FILE_PATH1), False, DataSourceUpdateMode.OnPropertyChanged, ""))
            lbltmpFile2.DataBindings.Add(New Binding(NameOf(lbltmpFile2.Tag), _D013, NameOf(_D013.FILE_PATH2), False, DataSourceUpdateMode.OnPropertyChanged, ""))
            lbltmpFile3.DataBindings.Add(New Binding(NameOf(lbltmpFile3.Tag), _D013, NameOf(_D013.FILE_PATH3), False, DataSourceUpdateMode.OnPropertyChanged, ""))
            lbltmpFile4.DataBindings.Add(New Binding(NameOf(lbltmpFile4.Tag), _D013, NameOf(_D013.FILE_PATH4), False, DataSourceUpdateMode.OnPropertyChanged, ""))
            lbltmpFile5.DataBindings.Add(New Binding(NameOf(lbltmpFile5.Tag), _D013, NameOf(_D013.FILE_PATH5), False, DataSourceUpdateMode.OnPropertyChanged, ""))

            Return True
        Catch ex As Exception
            Throw
            Return False
        End Try
    End Function

#End Region

#Region "�������[�h�ʉ�ʏ�����"

    ''' <summary>
    ''' ��ʏ�����
    ''' </summary>
    ''' <param name="intMODE"></param>
    ''' <returns></returns>
    Private Function FunInitializeControls(intMODE As ENM_DATA_OPERATION_MODE) As Boolean

        Try

            pnlST01.BackColor = Color.Transparent
            pnlST02.BackColor = Color.Transparent
            pnlST03.BackColor = Color.Transparent
            pnlST05.BackColor = Color.Transparent
            pnlST04.BackColor = Color.Transparent

            '�i�r�Q�[�g�����N�I��
            If PrCurrentStage = ENM_ZESEI_STAGE._999_Closed Then
                rsbtnST99.Checked = True
            Else
                Dim rbtn As RibbonShapeRadioButton = DirectCast(flpnlStageIndex.Controls("rsbtnST" & (PrCurrentStage / 10).ToString("00")), RibbonShapeRadioButton)
                rbtn.Checked = True
            End If

            Call SetTANTO_TooltipInfo()

            '-----�R���g���[���f�[�^�\�[�X�ݒ�
            cmbBUMON.SetDataSource(tblBUMON, ENM_COMBO_SELECT_VALUE_TYPE._0_Required)

            '���s�X�e�[�W��
            lblCurrentStageName.Text = If(PrHOKOKU_NO.IsNulOrWS, "ST01.�N��", FunGetLastStageName(Context.ENM_SYONIN_HOKOKUSYO_ID._5_ZESEI, PrHOKOKU_NO))

            Select Case intMODE
                Case ENM_DATA_OPERATION_MODE._1_ADD

                    mtxHOKOKU_NO.Text = "<�V�K>"
                    _D013.ADD_SYAIN_ID = pub_SYAIN_INFO.SYAIN_ID
                    _D013.ADD_YMDHNS = Now.ToString("yyyyMMddHHmmss")

                    If IsSysAdminUser(pub_SYAIN_INFO.SYAIN_ID) Then
                    Else
                        _D013.BUMON_KB = pub_SYAIN_INFO.BUMON_KB
                    End If

                    tabMain.Visible = False '������h�~
                    Application.DoEvents()
                    Call FunInitializeSTAGE(PrCurrentStage)
                    Application.DoEvents()
                    tabMain.Visible = True

                Case ENM_DATA_OPERATION_MODE._3_UPDATE

                    'mtxHOKOKU_NO.DataBindings.Add(New Binding(NameOf(mtxHOKOKU_NO.Text), _D013, NameOf(_D013.HOKOKU_NO), False, DataSourceUpdateMode.OnPropertyChanged, ""))

                    'SPEC: 10-2.�@
                    Call FunSetEntityModel(PrHOKOKU_NO, PrCurrentStage)

                    tabMain.Visible = False
                    Application.DoEvents()
                    Call FunInitializeSTAGE(PrCurrentStage)
                    Application.DoEvents()
                    tabMain.Visible = True

                    '�J�����g�X�e�[�W�I��
                    'For Each page As TabPage In tabMain.TabPages
                    '    If page.Text = "���X�e�[�W" Then
                    '        'SPEC: 10-2.�C
                    '        tabMain.SelectedTab = page
                    '        Exit For
                    '    End If
                    'Next page
                    'Me.tabMain.Visible = True

                    Dim HeaderItemReadOnly As Boolean
                    If PrCurrentStage = ENM_ZESEI_STAGE._10_�N������ Then
                        HeaderItemReadOnly = False
                    Else
                        HeaderItemReadOnly = True
                    End If
                    mtxHOKOKU_NO.ReadOnly = HeaderItemReadOnly
                    cmbBUMON.ReadOnly = HeaderItemReadOnly
                    cmbTANTO.ReadOnly = HeaderItemReadOnly
                    cmbKA.ReadOnly = HeaderItemReadOnly

            End Select

            Call ClearBinding()
            Call FunSetBinding()

            Return True
        Catch ex As Exception
            EM.ErrorSyori(ex, False, conblnNonMsg)
        End Try
    End Function

    Private Function FunSetEntityModel(HOKOKU_NO As String, SYONIN_JUN As Integer) As Boolean

        Try
            '�r���[���f�������[�h
            _D013 = FunGetD013Model(HOKOKU_NO)
            _V003_SYONIN_J_KANRI_List = FunGetV003Model(Context.ENM_SYONIN_HOKOKUSYO_ID._5_ZESEI, HOKOKU_NO)

#Region "D003"

            Dim t As Type = GetType(D013_ZESEI_HASSEI_J)
            Dim properties As Reflection.PropertyInfo() = t.GetProperties(
                 Reflection.BindingFlags.Public Or
                 Reflection.BindingFlags.Instance Or
                 Reflection.BindingFlags.Static)

            Dim blnFieldList As New List(Of String) From {NameOf(D013.CLOSE_FG),
                                                          NameOf(D013.FUTEKIGO_UMU),
                                                          NameOf(D013.JINTEKI_YOUIN_UMU),
                                                          NameOf(D013.ZESEI_SYOCHI_HANTEI)}

            'UNDONE: �ϊ��s�v�H
            'For Each p As Reflection.PropertyInfo In properties
            '    If IsAutoGenerateField(t, p.Name) = True Then
            '        Select Case True
            '            Case blnFieldList.Contains(p.Name)
            '                _D013(p.Name) = CBool(_V002_NCR_J(p.Name))
            '            Case Else
            '                If p.PropertyType Is GetType(String) Then
            '                    _D013(p.Name) = _V002_NCR_J(p.Name).ToString.Trim
            '                Else
            '                    _D013(p.Name) = _V002_NCR_J(p.Name)
            '                End If

            '        End Select
            '    End If
            'Next p

            '#128
            If PrCurrentStage = ENM_ZESEI_STAGE._10_�N������ AndAlso Not IsRemanded(_D013.HOKOKU_NO) Then
                _D013.ADD_SYAIN_ID = pub_SYAIN_INFO.SYAIN_ID
            End If

#End Region

#Region "D004"

            Dim _V003 As New V003_SYONIN_J_KANRI
            _V003 = _V003_SYONIN_J_KANRI_List.AsEnumerable.
                                Where(Function(r) r.SYONIN_JUN = SYONIN_JUN).
                                FirstOrDefault

            t = GetType(D004_SYONIN_J_KANRI)
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

#Region "�Y�t����"

            Dim strRootDir As String
            Using DB As ClsDbUtility = DBOpen()
                strRootDir = FunConvPathString(FunGetCodeMastaValue(DB, "�Y�t�t�@�C���ۑ���", My.Application.Info.AssemblyName))
            End Using

            If Not _D013.FILE_PATH1.IsNulOrWS Then
                lbltmpFile1.Text = CompactString(_D013.FILE_PATH1, lbltmpFile1, EllipsisFormat._4_Path)
                lbltmpFile1.Links.Clear()
                lbltmpFile1.Links.Add(0, lbltmpFile1.Text.Length, strRootDir & _D013.HOKOKU_NO.Trim & "\" & _D013.FILE_PATH1)
                lbltmpFile1.Visible = True
                lbltmpFile1_Clear.Visible = True
            End If
            If Not _D013.FILE_PATH2.IsNulOrWS Then
                lbltmpFile2.Text = CompactString(_D013.FILE_PATH2, lbltmpFile2, EllipsisFormat._4_Path)
                lbltmpFile2.Links.Clear()
                lbltmpFile2.Links.Add(0, lbltmpFile2.Text.Length, strRootDir & _D013.HOKOKU_NO.Trim & "\" & _D013.FILE_PATH2)
                lbltmpFile2.Visible = True
                lbltmpFile2_Clear.Visible = True
            End If
            If Not _D013.FILE_PATH3.IsNulOrWS Then
                lbltmpFile3.Text = CompactString(_D013.FILE_PATH3, lbltmpFile3, EllipsisFormat._4_Path)
                lbltmpFile3.Links.Clear()
                lbltmpFile3.Links.Add(0, lbltmpFile3.Text.Length, strRootDir & _D013.HOKOKU_NO.Trim & "\" & _D013.FILE_PATH3)
                lbltmpFile3.Visible = True
                lbltmpFile3_Clear.Visible = True
            End If
            If Not _D013.FILE_PATH4.IsNulOrWS Then
                lbltmpFile4.Text = CompactString(_D013.FILE_PATH4, lbltmpFile4, EllipsisFormat._4_Path)
                lbltmpFile4.Links.Clear()
                lbltmpFile4.Links.Add(0, lbltmpFile4.Text.Length, strRootDir & _D013.HOKOKU_NO.Trim & "\" & _D013.FILE_PATH4)
                lbltmpFile4.Visible = True
                lbltmpFile4_Clear.Visible = True
            End If
            If Not _D013.FILE_PATH5.IsNulOrWS Then
                lbltmpFile5.Text = CompactString(_D013.FILE_PATH5, lbltmpFile5, EllipsisFormat._4_Path)
                lbltmpFile5.Links.Clear()
                lbltmpFile5.Links.Add(0, lbltmpFile5.Text.Length, strRootDir & _D013.HOKOKU_NO.Trim & "\" & _D013.FILE_PATH5)
                lbltmpFile5.Visible = True
                lbltmpFile5_Clear.Visible = True
            End If

#End Region

            Return True
        Catch ex As Exception
            EM.ErrorSyori(ex, False, conblnNonMsg)
            Return False
        End Try
    End Function

    Private Function FunInitializeSTAGE(ByVal intStageID As Integer) As Boolean
        Dim dt As DataTable
        Dim dtUser As DataTable
        Dim drs As IEnumerable(Of DataRow)
        Dim V003 As V003_SYONIN_J_KANRI
        Try

            If _D013.BUMON_KB.IsNulOrWS Then
                Return False
            End If

            If intStageID >= ENM_ZESEI_STAGE._10_�N������ Then

                dtUser = FunGetSYOZOKU_SYAIN(_D013.BUMON_KB)
                pnlST01.Visible = True

                Select Case _D013.INPUT_TYPE
                    Case "1"
                        rbtnINPUT_TYPE1.Checked = True
                    Case "2"
                        rbtnINPUT_TYPE2.Checked = True
                    Case "3"
                        rbtnINPUT_TYPE3.Checked = True
                End Select

#Region "           ���F�S����"

                drs = dtUser.AsEnumerable.Where(Function(r) r.Item(NameOf(M011_SYAIN_GYOMU.GYOMU_GROUP_ID)) = ENM_GYOMU_GROUP_ID._4_�i��.Value)
                If drs.Count > 0 Then cmbST01_SAKUSEI_TANTO.SetDataSource(drs.CopyToDataTable, ENM_COMBO_SELECT_VALUE_TYPE._0_Required)

                dt = FunGetSYONIN_SYOZOKU_SYAIN(_D013.BUMON_KB, Context.ENM_SYONIN_HOKOKUSYO_ID._5_ZESEI.Value, ENM_ZESEI_STAGE._11_�N������_�_��)
                cmbST01_TENKEN_TANTO.SetDataSource(dt, ENM_COMBO_SELECT_VALUE_TYPE._0_Required)
                cmbST01_TENKEN_TANTO.Visible = True
                lblST01_TENKEN_TANTO.Visible = True
                dtST01_TENKEN_YMD.Visible = True

                dt = FunGetSYONIN_SYOZOKU_SYAIN(_D013.BUMON_KB, Context.ENM_SYONIN_HOKOKUSYO_ID._5_ZESEI.Value, ENM_ZESEI_STAGE._12_�N������_�F��)
                cmbST01_NINKA_TANTO.SetDataSource(dt, ENM_COMBO_SELECT_VALUE_TYPE._0_Required)

                V003 = _V003_SYONIN_J_KANRI_List.AsEnumerable.Where(Function(r) r.SYONIN_JUN = ENM_ZESEI_STAGE._10_�N������).FirstOrDefault
                If V003 IsNot Nothing Then
                    cmbST01_SAKUSEI_TANTO.SelectedValue = V003.SYAIN_ID
                    dtST01_SAKUSEI_YMD.Text = V003.SYONIN_YMDHNS.ToDateTimeWithFormat("yyyyMMddHHmmss", "yyyy/MM/dd")
                End If
                V003 = _V003_SYONIN_J_KANRI_List.AsEnumerable.Where(Function(r) r.SYONIN_JUN = ENM_ZESEI_STAGE._11_�N������_�_��).FirstOrDefault
                If V003 IsNot Nothing Then
                    cmbST01_TENKEN_TANTO.SelectedValue = V003.SYAIN_ID
                    dtST01_TENKEN_YMD.Text = V003.SYONIN_YMDHNS.ToDateTimeWithFormat("yyyyMMddHHmmss", "yyyy/MM/dd")
                End If
                V003 = _V003_SYONIN_J_KANRI_List.AsEnumerable.Where(Function(r) r.SYONIN_JUN = ENM_ZESEI_STAGE._12_�N������_�F��).FirstOrDefault
                If V003 IsNot Nothing Then
                    cmbST01_NINKA_TANTO.SelectedValue = V003.SYAIN_ID
                    dtST01_NINKA_YMD.Text = V003.SYONIN_YMDHNS.ToDateTimeWithFormat("yyyyMMddHHmmss", "yyyy/MM/dd")
                End If

#End Region

            End If

            If intStageID >= ENM_ZESEI_STAGE._11_�N������_�_�� Then
                cmbST01_SAKUSEI_TANTO.ReadOnly = True

                cmbST01_NINKA_TANTO.Visible = True
                lblST01_NINKA_TANTO.Visible = True
                dtST01_NINKA_YMD.Visible = True
            End If

            If intStageID >= ENM_ZESEI_STAGE._12_�N������_�F�� Then
                dt = GetExcludeyakusyokuUsers(_D013.BUMON_KB, {ENM_YAKUSYOKU_KB._99_�Ȃ�.Value}.ToList)
                cmbST02_SAKUSEI_TANTO.SetDataSource(dt, ENM_COMBO_SELECT_VALUE_TYPE._0_Required)
                cmbST02_SAKUSEI_TANTO.SelectedValue = _D013.TANTO_ID

                cmbST01_TENKEN_TANTO.ReadOnly = True
            End If

            If intStageID >= ENM_ZESEI_STAGE._20_�������u���� Then
                pnlST02.Visible = True
                cmbST02_SAKUSEI_TANTO.Visible = True
                lblST02_SAKUSEI_TANTO.Visible = True
                dtST02_SAKUSEI_YMD.Visible = True

                mtxHOKOKU_NO.ReadOnly = True
                cmbBUMON.ReadOnly = True
                cmbKA.ReadOnly = True
                cmbTANTO.ReadOnly = True
                pnlST01.DisableContaints(False, PanelEx.ENM_PROPERTY._2_ReadOnly)
                txtCOMMENT1.ReadOnly = False

                If _D013.FUTEKIGO_UMU Then
                    rbtnST02_FUTEKIGO_YES.Checked = True
                Else
                    rbtnST02_FUTEKIGO_NO.Checked = True
                End If

                If _D013.JINTEKI_YOUIN_UMU Then
                    rbtnFUTEKIGO_YOUIN_T.Checked = True
                Else
                    rbtnFUTEKIGO_YOUIN_F.Checked = True
                End If

#Region "           ���F�S����"

                'dt = FunGetSYONIN_SYOZOKU_SYAIN(_D013.BUMON_KB, Context.ENM_SYONIN_HOKOKUSYO_ID._5_ZESEI.Value, ENM_ZESEI_STAGE._21_�������u����_�_��)
                'If drs IsNot Nothing Then dt.Merge(drs.CopyToDataTable)
                dt = GetExcludeyakusyokuUsers(_D013.BUMON_KB, {ENM_YAKUSYOKU_KB._99_�Ȃ�.Value}.ToList)
                cmbST02_TENKEN_TANTO.SetDataSource(dt, ENM_COMBO_SELECT_VALUE_TYPE._0_Required)
                cmbST02_TENKEN_TANTO.Visible = True
                lblST02_TENKEN_TANTO.Visible = True
                dtST02_TENKEN_YMD.Visible = True

                cmbST01_NINKA_TANTO.ReadOnly = True

                dt = FunGetSYONIN_SYOZOKU_SYAIN(_D013.BUMON_KB, Context.ENM_SYONIN_HOKOKUSYO_ID._5_ZESEI.Value, ENM_ZESEI_STAGE._22_�������u����_�F��)
                cmbST02_NINKA_TANTO.SetDataSource(dt, ENM_COMBO_SELECT_VALUE_TYPE._0_Required)

                V003 = _V003_SYONIN_J_KANRI_List.AsEnumerable.Where(Function(r) r.SYONIN_JUN = ENM_ZESEI_STAGE._20_�������u����).FirstOrDefault
                If V003 IsNot Nothing Then
                    cmbST02_SAKUSEI_TANTO.SelectedValue = V003.SYAIN_ID
                    dtST02_SAKUSEI_YMD.Text = V003.SYONIN_YMDHNS.ToDateTimeWithFormat("yyyyMMddHHmmss", "yyyy/MM/dd")
                End If

                V003 = _V003_SYONIN_J_KANRI_List.AsEnumerable.Where(Function(r) r.SYONIN_JUN = ENM_ZESEI_STAGE._21_�������u����_�_��).FirstOrDefault
                If V003 IsNot Nothing Then
                    cmbST02_TENKEN_TANTO.SelectedValue = V003.SYAIN_ID
                    dtST02_TENKEN_YMD.Text = V003.SYONIN_YMDHNS.ToDateTimeWithFormat("yyyyMMddHHmmss", "yyyy/MM/dd")
                End If

                V003 = _V003_SYONIN_J_KANRI_List.AsEnumerable.Where(Function(r) r.SYONIN_JUN = ENM_ZESEI_STAGE._22_�������u����_�F��).FirstOrDefault
                If V003 IsNot Nothing Then
                    cmbST02_NINKA_TANTO.SelectedValue = V003.SYAIN_ID
                    dtST02_NINKA_YMD.Text = V003.SYONIN_YMDHNS.ToDateTimeWithFormat("yyyyMMddHHmmss", "yyyy/MM/dd")
                End If

#End Region

            End If

            If intStageID >= ENM_ZESEI_STAGE._21_�������u����_�_�� Then
                cmbST02_NINKA_TANTO.Visible = True
                lblST02_NINKA_TANTO.Visible = True
                dtST02_NINKA_YMD.Visible = True

                cmbST02_SAKUSEI_TANTO.ReadOnly = True
            End If

            If intStageID >= ENM_ZESEI_STAGE._22_�������u����_�F�� Then
                dt = GetExcludeyakusyokuUsers(_D013.BUMON_KB, {ENM_YAKUSYOKU_KB._99_�Ȃ�.Value}.ToList)
                cmbST03_SAKUSEI_TANTO.SetDataSource(dt, ENM_COMBO_SELECT_VALUE_TYPE._0_Required)
                cmbST03_SAKUSEI_TANTO.SelectedValue = _D013.TANTO_ID
                cmbST03_SAKUSEI_TANTO.Visible = True
                lblST03_SAKUSEI_TANTO.Visible = True
                dtST03_SAKUSEI_YMD.Visible = True

                cmbST02_TENKEN_TANTO.ReadOnly = True

                Select Case _D013.INPUT_TYPE
                    Case "1", "2"
                        cmbST02_HINSYO_TENKEN_TANTO.Visible = True
                        lblST02_HINSYO_TENKEN_TANTO.Visible = True
                        dtST02_HINSYO_TENKEN_YMD.Visible = True

                        cmbST02_HINSYO_NINKA_TANTO.Visible = True
                        lblST02_HINSYO_NINKA_TANTO.Visible = True
                        dtST02_HINSYO_NINKA_YMD.Visible = True

                        dt = FunGetSYONIN_SYOZOKU_SYAIN(_D013.BUMON_KB, Context.ENM_SYONIN_HOKOKUSYO_ID._5_ZESEI.Value, ENM_ZESEI_STAGE._11_�N������_�_��)
                        cmbST02_HINSYO_TENKEN_TANTO.SetDataSource(dt, ENM_COMBO_SELECT_VALUE_TYPE._0_Required)
                        cmbST02_HINSYO_TENKEN_TANTO.SelectedValue = cmbST01_TENKEN_TANTO.SelectedValue

                        dt = FunGetSYONIN_SYOZOKU_SYAIN(_D013.BUMON_KB, Context.ENM_SYONIN_HOKOKUSYO_ID._5_ZESEI.Value, ENM_ZESEI_STAGE._12_�N������_�F��)
                        cmbST02_HINSYO_NINKA_TANTO.SetDataSource(dt, ENM_COMBO_SELECT_VALUE_TYPE._0_Required)
                        cmbST02_HINSYO_NINKA_TANTO.SelectedValue = cmbST01_NINKA_TANTO.SelectedValue

                        V003 = _V003_SYONIN_J_KANRI_List.AsEnumerable.Where(Function(r) r.SYONIN_JUN = ENM_ZESEI_STAGE._23_�������u����_�i��_�_��).FirstOrDefault
                        If V003 IsNot Nothing Then
                            cmbST02_HINSYO_TENKEN_TANTO.SelectedValue = V003.SYAIN_ID
                            dtST02_HINSYO_TENKEN_YMD.Text = V003.SYONIN_YMDHNS.ToDateTimeWithFormat("yyyyMMddHHmmss", "yyyy/MM/dd")
                        End If

                        V003 = _V003_SYONIN_J_KANRI_List.AsEnumerable.Where(Function(r) r.SYONIN_JUN = ENM_ZESEI_STAGE._24_�������u����_�i��_�F��).FirstOrDefault
                        If V003 IsNot Nothing Then
                            cmbST02_HINSYO_NINKA_TANTO.SelectedValue = V003.SYAIN_ID
                            dtST02_HINSYO_NINKA_YMD.Text = V003.SYONIN_YMDHNS.ToDateTimeWithFormat("yyyyMMddHHmmss", "yyyy/MM/dd")
                        End If
                    Case Else
                End Select
            End If

            If intStageID >= ENM_ZESEI_STAGE._23_�������u����_�i��_�_�� Then
                cmbST02_NINKA_TANTO.ReadOnly = True
            End If

            If intStageID >= ENM_ZESEI_STAGE._24_�������u����_�i��_�F�� Then
                cmbST02_HINSYO_TENKEN_TANTO.ReadOnly = True

            End If

            If intStageID >= ENM_ZESEI_STAGE._30_���u���ʓ��� Then
                pnlST03.Visible = True
                pnlST02.DisableContaints(False, PanelEx.ENM_PROPERTY._2_ReadOnly)
                txtCOMMENT2.ReadOnly = False

#Region "           ���F�S����"

                dt = FunGetSYONIN_SYOZOKU_SYAIN(_D013.BUMON_KB, Context.ENM_SYONIN_HOKOKUSYO_ID._5_ZESEI.Value, ENM_ZESEI_STAGE._21_�������u����_�_��)
                cmbST03_TENKEN_TANTO.SetDataSource(dt, ENM_COMBO_SELECT_VALUE_TYPE._0_Required)
                cmbST03_TENKEN_TANTO.Visible = True
                lblST03_TENKEN_TANTO.Visible = True
                dtST03_TENKEN_YMD.Visible = True

                cmbST02_NINKA_TANTO.ReadOnly = True

                dt = FunGetSYONIN_SYOZOKU_SYAIN(_D013.BUMON_KB, Context.ENM_SYONIN_HOKOKUSYO_ID._5_ZESEI.Value, ENM_ZESEI_STAGE._22_�������u����_�F��)
                cmbST03_NINKA_TANTO.SetDataSource(dt, ENM_COMBO_SELECT_VALUE_TYPE._0_Required)

                V003 = _V003_SYONIN_J_KANRI_List.AsEnumerable.Where(Function(r) r.SYONIN_JUN = ENM_ZESEI_STAGE._30_���u���ʓ���).FirstOrDefault
                If V003 IsNot Nothing Then
                    cmbST03_SAKUSEI_TANTO.SelectedValue = V003.SYAIN_ID
                    dtST03_SAKUSEI_YMD.Text = V003.SYONIN_YMDHNS.ToDateTimeWithFormat("yyyyMMddHHmmss", "yyyy/MM/dd")
                End If

                V003 = _V003_SYONIN_J_KANRI_List.AsEnumerable.Where(Function(r) r.SYONIN_JUN = ENM_ZESEI_STAGE._31_���u���ʓ���_�_��).FirstOrDefault
                If V003 IsNot Nothing Then
                    cmbST03_TENKEN_TANTO.SelectedValue = V003.SYAIN_ID
                    dtST03_TENKEN_YMD.Text = V003.SYONIN_YMDHNS.ToDateTimeWithFormat("yyyyMMddHHmmss", "yyyy/MM/dd")
                Else
                    cmbST03_TENKEN_TANTO.SelectedValue = cmbST02_TENKEN_TANTO.SelectedValue
                End If

                V003 = _V003_SYONIN_J_KANRI_List.AsEnumerable.Where(Function(r) r.SYONIN_JUN = ENM_ZESEI_STAGE._32_���u���ʓ���_�F��).FirstOrDefault
                If V003 IsNot Nothing Then
                    cmbST03_NINKA_TANTO.SelectedValue = V003.SYAIN_ID
                    dtST03_NINKA_YMD.Text = V003.SYONIN_YMDHNS.ToDateTimeWithFormat("yyyyMMddHHmmss", "yyyy/MM/dd")
                Else
                    cmbST03_NINKA_TANTO.SelectedValue = cmbST02_NINKA_TANTO.SelectedValue
                End If

#End Region

            End If

            If intStageID >= ENM_ZESEI_STAGE._31_���u���ʓ���_�_�� Then
                cmbST03_NINKA_TANTO.Visible = True
                lblST03_NINKA_TANTO.Visible = True
                dtST03_NINKA_YMD.Visible = True

                cmbST03_SAKUSEI_TANTO.ReadOnly = True
            End If

            If intStageID >= ENM_ZESEI_STAGE._32_���u���ʓ���_�F�� Then
                pnlST04.Visible = True
                dt = GetExcludeyakusyokuUsers(_D013.BUMON_KB, {ENM_YAKUSYOKU_KB._99_�Ȃ�.Value}.ToList)
                cmbST04_SAKUSEI_TANTO.SetDataSource(dt, ENM_COMBO_SELECT_VALUE_TYPE._0_Required)
                cmbST04_SAKUSEI_TANTO.SelectedValue = _D013.TANTO_ID

                cmbST04_SAKUSEI_TANTO.Visible = True
                lblST04_SAKUSEI_TANTO.Visible = True
                dtST04_SAKUSEI_YMD.Visible = True

                cmbST03_TENKEN_TANTO.ReadOnly = True
            End If

            If intStageID >= ENM_ZESEI_STAGE._40_���u���ʃ��r���[ Then
                pnlST03.DisableContaints(False, PanelEx.ENM_PROPERTY._2_ReadOnly)
                txtCOMMENT3.ReadOnly = False
                pnlST04.Visible = True

                If _D013.ZESEI_SYOCHI_HANTEI Then
                    rbtnZESEI_SYOCHI_YES.Checked = True
                Else
                    rbtnZESEI_SYOCHI_NO.Checked = True
                End If

#Region "           ���F�S����"

                dt = FunGetSYONIN_SYOZOKU_SYAIN(_D013.BUMON_KB, Context.ENM_SYONIN_HOKOKUSYO_ID._5_ZESEI.Value, ENM_ZESEI_STAGE._21_�������u����_�_��)
                cmbST04_TENKEN_TANTO.SetDataSource(dt, ENM_COMBO_SELECT_VALUE_TYPE._0_Required)
                cmbST04_TENKEN_TANTO.Visible = True
                lblST04_TENKEN_TANTO.Visible = True
                dtST04_TENKEN_YMD.Visible = True

                cmbST03_NINKA_TANTO.ReadOnly = True

                dt = FunGetSYONIN_SYOZOKU_SYAIN(_D013.BUMON_KB, Context.ENM_SYONIN_HOKOKUSYO_ID._5_ZESEI.Value, ENM_ZESEI_STAGE._22_�������u����_�F��)
                cmbST04_NINKA_TANTO.SetDataSource(dt, ENM_COMBO_SELECT_VALUE_TYPE._0_Required)

                V003 = _V003_SYONIN_J_KANRI_List.AsEnumerable.Where(Function(r) r.SYONIN_JUN = ENM_ZESEI_STAGE._40_���u���ʃ��r���[).FirstOrDefault
                If V003 IsNot Nothing Then
                    cmbST04_SAKUSEI_TANTO.SelectedValue = V003.SYAIN_ID
                    dtST04_SAKUSEI_YMD.Text = V003.SYONIN_YMDHNS.ToDateTimeWithFormat("yyyyMMddHHmmss", "yyyy/MM/dd")
                End If

                V003 = _V003_SYONIN_J_KANRI_List.AsEnumerable.Where(Function(r) r.SYONIN_JUN = ENM_ZESEI_STAGE._41_���u���ʃ��r���[_�_��).FirstOrDefault
                If V003 IsNot Nothing Then
                    cmbST04_TENKEN_TANTO.SelectedValue = V003.SYAIN_ID
                    dtST04_TENKEN_YMD.Text = V003.SYONIN_YMDHNS.ToDateTimeWithFormat("yyyyMMddHHmmss", "yyyy/MM/dd")
                Else
                    cmbST04_TENKEN_TANTO.SelectedValue = cmbST02_TENKEN_TANTO.SelectedValue
                End If

                V003 = _V003_SYONIN_J_KANRI_List.AsEnumerable.Where(Function(r) r.SYONIN_JUN = ENM_ZESEI_STAGE._42_���u���ʃ��r���[_�F��).FirstOrDefault
                If V003 IsNot Nothing Then
                    cmbST04_NINKA_TANTO.SelectedValue = V003.SYAIN_ID
                    dtST04_NINKA_YMD.Text = V003.SYONIN_YMDHNS.ToDateTimeWithFormat("yyyyMMddHHmmss", "yyyy/MM/dd")
                Else
                    cmbST04_NINKA_TANTO.SelectedValue = cmbST02_NINKA_TANTO.SelectedValue
                End If

#End Region

            End If

            If intStageID >= ENM_ZESEI_STAGE._41_���u���ʃ��r���[_�_�� Then
                cmbST04_NINKA_TANTO.Visible = True
                lblST04_NINKA_TANTO.Visible = True
                dtST04_NINKA_YMD.Visible = True

                cmbST04_SAKUSEI_TANTO.ReadOnly = True
            End If

            If intStageID >= ENM_ZESEI_STAGE._42_���u���ʃ��r���[_�F�� Then
                pnlST05.Visible = True

                drs = dtUser.AsEnumerable.Where(Function(r) r.Item(NameOf(M011_SYAIN_GYOMU.GYOMU_GROUP_ID)) = ENM_GYOMU_GROUP_ID._4_�i��.Value)
                If drs.Count > 0 Then cmbST05_SAKUSEI_TANTO.SetDataSource(drs.CopyToDataTable, ENM_COMBO_SELECT_VALUE_TYPE._0_Required)
                cmbST05_SAKUSEI_TANTO.SelectedValue = cmbST01_SAKUSEI_TANTO.SelectedValue
                cmbST05_SAKUSEI_TANTO.Visible = True
                lblST05_SAKUSEI_TANTO.Visible = True
                dtST05_SAKUSEI_YMD.Visible = True
                cmbST04_TENKEN_TANTO.ReadOnly = True
            End If

            If intStageID >= ENM_ZESEI_STAGE._50_�v���������m�F Then
                pnlST04.DisableContaints(False, PanelEx.ENM_PROPERTY._2_ReadOnly)
                txtCOMMENT4.ReadOnly = False

#Region "           ���F�S����"

                dt = FunGetSYONIN_SYOZOKU_SYAIN(_D013.BUMON_KB, Context.ENM_SYONIN_HOKOKUSYO_ID._5_ZESEI.Value, ENM_ZESEI_STAGE._11_�N������_�_��)
                cmbST05_TENKEN_TANTO.SetDataSource(dt, ENM_COMBO_SELECT_VALUE_TYPE._0_Required)
                cmbST05_TENKEN_TANTO.Visible = True
                lblST05_TENKEN_TANTO.Visible = True
                dtST05_TENKEN_YMD.Visible = True
                cmbST04_NINKA_TANTO.ReadOnly = True

                dt = FunGetSYONIN_SYOZOKU_SYAIN(_D013.BUMON_KB, Context.ENM_SYONIN_HOKOKUSYO_ID._5_ZESEI.Value, ENM_ZESEI_STAGE._12_�N������_�F��)
                cmbST05_NINKA_TANTO.SetDataSource(dt, ENM_COMBO_SELECT_VALUE_TYPE._0_Required)

                V003 = _V003_SYONIN_J_KANRI_List.AsEnumerable.Where(Function(r) r.SYONIN_JUN = ENM_ZESEI_STAGE._50_�v���������m�F).FirstOrDefault
                If V003 IsNot Nothing Then
                    cmbST05_SAKUSEI_TANTO.SelectedValue = V003.SYAIN_ID
                    dtST05_SAKUSEI_YMD.Text = V003.SYONIN_YMDHNS.ToDateTimeWithFormat("yyyyMMddHHmmss", "yyyy/MM/dd")
                End If

                V003 = _V003_SYONIN_J_KANRI_List.AsEnumerable.Where(Function(r) r.SYONIN_JUN = ENM_ZESEI_STAGE._51_�v���������m�F_�_��).FirstOrDefault
                If V003 IsNot Nothing Then
                    cmbST05_TENKEN_TANTO.SelectedValue = V003.SYAIN_ID
                    dtST05_TENKEN_YMD.Text = V003.SYONIN_YMDHNS.ToDateTimeWithFormat("yyyyMMddHHmmss", "yyyy/MM/dd")
                Else
                    cmbST05_TENKEN_TANTO.SelectedValue = cmbST01_TENKEN_TANTO.SelectedValue
                End If

                V003 = _V003_SYONIN_J_KANRI_List.AsEnumerable.Where(Function(r) r.SYONIN_JUN = ENM_ZESEI_STAGE._52_�v���������m�F_�F��).FirstOrDefault
                If V003 IsNot Nothing Then
                    cmbST05_NINKA_TANTO.SelectedValue = V003.SYAIN_ID
                    dtST05_NINKA_YMD.Text = V003.SYONIN_YMDHNS.ToDateTimeWithFormat("yyyyMMddHHmmss", "yyyy/MM/dd")
                Else
                    cmbST05_NINKA_TANTO.SelectedValue = cmbST01_NINKA_TANTO.SelectedValue
                End If

#End Region

            End If

            If intStageID >= ENM_ZESEI_STAGE._51_�v���������m�F_�_�� Then
                cmbST05_NINKA_TANTO.Visible = True
                lblST05_NINKA_TANTO.Visible = True
                dtST05_NINKA_YMD.Visible = True

                cmbST05_SAKUSEI_TANTO.ReadOnly = True
            End If

            If intStageID >= ENM_ZESEI_STAGE._52_�v���������m�F_�F�� Then
                cmbST05_NINKA_TANTO.ReadOnly = True
            End If

            '�����߂����R
            Call SetSashimodoshiInfo(intStageID)

            For intTabNo = 1 To 5
                If (intStageID / 10) < intTabNo Then
                    flpnlStageIndex.Controls("rsbtnST" & intTabNo.ToString("00")).Enabled = False
                    flpnlStageIndex.Controls("rsbtnST" & intTabNo.ToString("00")).BackColor = Color.Silver
                End If
            Next

#Region "Set EventHandler"

            Select Case DirectCast(intStageID, ENM_ZESEI_STAGE)
                Case ENM_ZESEI_STAGE._10_�N������
                    AddHandler cmbST01_SAKUSEI_TANTO.SelectedValueChanged, AddressOf CmbDestTANTO_SelectedvalueChanged

                    If cmbST01_SAKUSEI_TANTO.SelectedValue Is Nothing OrElse cmbST01_SAKUSEI_TANTO.SelectedValue = 0 Then
                        cmbST01_SAKUSEI_TANTO.SelectedValue = pub_SYAIN_INFO.SYAIN_ID
                    End If
                Case ENM_ZESEI_STAGE._11_�N������_�_��
                    AddHandler cmbST01_TENKEN_TANTO.SelectedValueChanged, AddressOf CmbDestTANTO_SelectedvalueChanged
                    If cmbST01_TENKEN_TANTO.SelectedValue Is Nothing OrElse cmbST01_TENKEN_TANTO.SelectedValue = 0 Then
                        cmbST01_TENKEN_TANTO.SelectedValue = pub_SYAIN_INFO.SYAIN_ID
                    End If
                Case ENM_ZESEI_STAGE._12_�N������_�F��
                    AddHandler cmbST01_NINKA_TANTO.SelectedValueChanged, AddressOf CmbDestTANTO_SelectedvalueChanged
                    If cmbST01_NINKA_TANTO.SelectedValue Is Nothing OrElse cmbST01_NINKA_TANTO.SelectedValue = 0 Then
                        cmbST01_NINKA_TANTO.SelectedValue = pub_SYAIN_INFO.SYAIN_ID
                    End If

                Case ENM_ZESEI_STAGE._20_�������u����
                    AddHandler cmbST02_SAKUSEI_TANTO.SelectedValueChanged, AddressOf CmbDestTANTO_SelectedvalueChanged

                Case ENM_ZESEI_STAGE._21_�������u����_�_��
                    AddHandler cmbST02_TENKEN_TANTO.SelectedValueChanged, AddressOf CmbDestTANTO_SelectedvalueChanged
                    If cmbST02_TENKEN_TANTO.SelectedValue Is Nothing OrElse cmbST02_TENKEN_TANTO.SelectedValue = 0 Then
                        cmbST02_TENKEN_TANTO.SelectedValue = pub_SYAIN_INFO.SYAIN_ID
                    End If
                Case ENM_ZESEI_STAGE._22_�������u����_�F��
                    AddHandler cmbST02_NINKA_TANTO.SelectedValueChanged, AddressOf CmbDestTANTO_SelectedvalueChanged
                    If cmbST01_SAKUSEI_TANTO.SelectedValue Is Nothing OrElse cmbST01_SAKUSEI_TANTO.SelectedValue = 0 Then
                        cmbST02_NINKA_TANTO.SelectedValue = pub_SYAIN_INFO.SYAIN_ID
                    End If

                Case ENM_ZESEI_STAGE._23_�������u����_�i��_�_��
                    AddHandler cmbST02_HINSYO_TENKEN_TANTO.SelectedValueChanged, AddressOf CmbDestTANTO_SelectedvalueChanged
                    If cmbST02_HINSYO_TENKEN_TANTO.SelectedValue Is Nothing OrElse cmbST02_HINSYO_TENKEN_TANTO.SelectedValue = 0 Then
                        cmbST02_HINSYO_TENKEN_TANTO.SelectedValue = pub_SYAIN_INFO.SYAIN_ID
                    End If

                Case ENM_ZESEI_STAGE._24_�������u����_�i��_�F��
                    AddHandler cmbST02_HINSYO_NINKA_TANTO.SelectedValueChanged, AddressOf CmbDestTANTO_SelectedvalueChanged
                    If cmbST02_HINSYO_NINKA_TANTO.SelectedValue Is Nothing OrElse cmbST02_HINSYO_NINKA_TANTO.SelectedValue = 0 Then
                        cmbST02_HINSYO_NINKA_TANTO.SelectedValue = pub_SYAIN_INFO.SYAIN_ID
                    End If
                Case ENM_ZESEI_STAGE._30_���u���ʓ���
                    AddHandler cmbST03_SAKUSEI_TANTO.SelectedValueChanged, AddressOf CmbDestTANTO_SelectedvalueChanged
                    If cmbST03_SAKUSEI_TANTO.SelectedValue Is Nothing OrElse cmbST03_SAKUSEI_TANTO.SelectedValue = 0 Then
                        cmbST03_SAKUSEI_TANTO.SelectedValue = pub_SYAIN_INFO.SYAIN_ID
                    End If
                Case ENM_ZESEI_STAGE._31_���u���ʓ���_�_��
                    AddHandler cmbST03_TENKEN_TANTO.SelectedValueChanged, AddressOf CmbDestTANTO_SelectedvalueChanged
                    If cmbST03_TENKEN_TANTO.SelectedValue Is Nothing OrElse cmbST03_TENKEN_TANTO.SelectedValue = 0 Then
                        cmbST03_TENKEN_TANTO.SelectedValue = pub_SYAIN_INFO.SYAIN_ID
                    End If
                Case ENM_ZESEI_STAGE._32_���u���ʓ���_�F��
                    AddHandler cmbST03_NINKA_TANTO.SelectedValueChanged, AddressOf CmbDestTANTO_SelectedvalueChanged
                    If cmbST03_NINKA_TANTO.SelectedValue Is Nothing OrElse cmbST03_NINKA_TANTO.SelectedValue = 0 Then
                        cmbST03_NINKA_TANTO.SelectedValue = pub_SYAIN_INFO.SYAIN_ID
                    End If
                Case ENM_ZESEI_STAGE._40_���u���ʃ��r���[
                    AddHandler cmbST04_SAKUSEI_TANTO.SelectedValueChanged, AddressOf CmbDestTANTO_SelectedvalueChanged
                    If cmbST04_SAKUSEI_TANTO.SelectedValue Is Nothing OrElse cmbST04_SAKUSEI_TANTO.SelectedValue = 0 Then
                        cmbST04_SAKUSEI_TANTO.SelectedValue = pub_SYAIN_INFO.SYAIN_ID
                    End If
                Case ENM_ZESEI_STAGE._41_���u���ʃ��r���[_�_��
                    AddHandler cmbST04_TENKEN_TANTO.SelectedValueChanged, AddressOf CmbDestTANTO_SelectedvalueChanged
                    If cmbST04_TENKEN_TANTO.SelectedValue Is Nothing OrElse cmbST04_TENKEN_TANTO.SelectedValue = 0 Then
                        cmbST04_TENKEN_TANTO.SelectedValue = pub_SYAIN_INFO.SYAIN_ID
                    End If
                Case ENM_ZESEI_STAGE._42_���u���ʃ��r���[_�F��
                    AddHandler cmbST04_NINKA_TANTO.SelectedValueChanged, AddressOf CmbDestTANTO_SelectedvalueChanged
                    If cmbST04_NINKA_TANTO.SelectedValue Is Nothing OrElse cmbST04_NINKA_TANTO.SelectedValue = 0 Then
                        cmbST04_NINKA_TANTO.SelectedValue = pub_SYAIN_INFO.SYAIN_ID
                    End If
                Case ENM_ZESEI_STAGE._50_�v���������m�F
                    AddHandler cmbST05_SAKUSEI_TANTO.SelectedValueChanged, AddressOf CmbDestTANTO_SelectedvalueChanged
                    If cmbST05_SAKUSEI_TANTO.SelectedValue Is Nothing OrElse cmbST05_SAKUSEI_TANTO.SelectedValue = 0 Then
                        cmbST05_SAKUSEI_TANTO.SelectedValue = pub_SYAIN_INFO.SYAIN_ID
                    End If
                Case ENM_ZESEI_STAGE._51_�v���������m�F_�_��
                    AddHandler cmbST05_TENKEN_TANTO.SelectedValueChanged, AddressOf CmbDestTANTO_SelectedvalueChanged
                    If cmbST05_TENKEN_TANTO.SelectedValue Is Nothing OrElse cmbST05_TENKEN_TANTO.SelectedValue = 0 Then
                        cmbST05_TENKEN_TANTO.SelectedValue = pub_SYAIN_INFO.SYAIN_ID
                    End If
                Case ENM_ZESEI_STAGE._52_�v���������m�F_�F��
                    AddHandler cmbST05_NINKA_TANTO.SelectedValueChanged, AddressOf CmbDestTANTO_SelectedvalueChanged
                    If cmbST05_NINKA_TANTO.SelectedValue Is Nothing OrElse cmbST05_NINKA_TANTO.SelectedValue = 0 Then
                        cmbST05_NINKA_TANTO.SelectedValue = pub_SYAIN_INFO.SYAIN_ID
                    End If
                Case ENM_ZESEI_STAGE._999_Closed
            End Select

#End Region

            Return True
        Catch ex As Exception
            EM.ErrorSyori(ex, False, conblnNonMsg)
            Return False
        End Try
    End Function

    ''' <summary>
    ''' �S���҂̃f�[�^�\�[�X�������x���ɕ\��
    ''' </summary>
    ''' <returns></returns>
    Private Function SetTANTO_TooltipInfo() As Boolean

        Call SetInfoLabelFormat(lblTANTO, $"�I����������E�ۂ̖�E�敪:SL�A��E�Ȃ�)�ȊO�̒S����")

        Call SetInfoLabelFormat(lblST01_SAKUSEI_TANTO, $"�Ј��Ɩ��O���[�v�}�X�^{vbCr}�ȉ��̋Ɩ��O���[�v�ɓo�^���ꂽ�S����{vbCrLf}{vbCrLf}QMS�Ǘ��ӔC�ҁE�i��")
        Call SetInfoLabelFormat(lblST01_TENKEN_TANTO, $"���F�S���҃}�X�^{vbCr}���������ST11.�ɓo�^���ꂽ�S����")
        Call SetInfoLabelFormat(lblST01_NINKA_TANTO, $"���F�S���҃}�X�^{vbCr}���������ST12.�ɓo�^���ꂽ�S����")

        Call SetInfoLabelFormat(lblST02_SAKUSEI_TANTO, $"�I����������E�ۂ̖�E�敪:�Ȃ�)�ȊO�̒S����")
        Call SetInfoLabelFormat(lblST02_TENKEN_TANTO, $"�I����������E�ۂ̖�E�敪:�Ȃ�)�ȊO�̒S����")
        Call SetInfoLabelFormat(lblST02_NINKA_TANTO, $"���F�S���҃}�X�^{vbCr}���������ST22.�ɓo�^���ꂽ�S����")
        Call SetInfoLabelFormat(lblST02_HINSYO_TENKEN_TANTO, $"���F�S���҃}�X�^{vbCr}���������ST11.�ɓo�^���ꂽ�S����")
        Call SetInfoLabelFormat(lblST02_HINSYO_NINKA_TANTO, $"���F�S���҃}�X�^{vbCr}���������ST12.�ɓo�^���ꂽ�S����")

        Call SetInfoLabelFormat(lblST03_SAKUSEI_TANTO, $"�I����������E�ۂ̖�E�敪:�Ȃ�)�ȊO�̒S����")
        Call SetInfoLabelFormat(lblST03_TENKEN_TANTO, $"�I����������E�ۂ̖�E�敪:�Ȃ�)�ȊO�̒S����")
        Call SetInfoLabelFormat(lblST03_NINKA_TANTO, $"���F�S���҃}�X�^{vbCr}���������ST22.�ɓo�^���ꂽ�S����")

        Call SetInfoLabelFormat(lblST04_SAKUSEI_TANTO, $"�I����������E�ۂ̖�E�敪:�Ȃ�)�ȊO�̒S����")
        Call SetInfoLabelFormat(lblST04_TENKEN_TANTO, $"�I����������E�ۂ̖�E�敪:�Ȃ�)�ȊO�̒S����")
        Call SetInfoLabelFormat(lblST04_NINKA_TANTO, $"���F�S���҃}�X�^{vbCr}���������ST22.�ɓo�^���ꂽ�S����")

        Call SetInfoLabelFormat(lblST05_SAKUSEI_TANTO, $"�Ј��Ɩ��O���[�v�}�X�^{vbCr}�ȉ��̋Ɩ��O���[�v�ɓo�^���ꂽ�S����{vbCrLf}{vbCrLf}QMS�Ǘ��ӔC�ҁE�i��")
        Call SetInfoLabelFormat(lblST05_TENKEN_TANTO, $"���F�S���҃}�X�^{vbCr}���������ST11.�ɓo�^���ꂽ�S����")
        Call SetInfoLabelFormat(lblST05_NINKA_TANTO, $"���F�S���҃}�X�^{vbCr}���������ST12.�ɓo�^���ꂽ�S����")

    End Function

    Private Function SetInfoLabelFormat(lbl As System.Windows.Forms.Label, caption As String) As Boolean
        lbl.ForeColor = Color.Blue
        'lbl.Cursor = Cursors.Hand
        lbl.Font = New Font("Meiryo UI", 9, FontStyle.Bold + FontStyle.Underline, lbl.Font.Unit, CType(128, Byte))
        InfoToolTip.SetToolTip(lbl, caption)
    End Function

    Private Sub SetSashimodoshiInfo(StageID As Integer)
        Dim lbl As Label
        Dim V003 As V003_SYONIN_J_KANRI

        Try
            Select Case StageID
                Case ENM_ZESEI_STAGE._10_�N������ To ENM_ZESEI_STAGE._12_�N������_�F��
                    lbl = lblST01_Modoshi_Riyu
                Case ENM_ZESEI_STAGE._20_�������u���� To ENM_ZESEI_STAGE._24_�������u����_�i��_�F��
                    lbl = lblST02_Modoshi_Riyu
                Case ENM_ZESEI_STAGE._30_���u���ʓ��� To ENM_ZESEI_STAGE._32_���u���ʓ���_�F��
                    lbl = lblST03_Modoshi_Riyu
                Case ENM_ZESEI_STAGE._40_���u���ʃ��r���[ To ENM_ZESEI_STAGE._42_���u���ʃ��r���[_�F��
                    lbl = lblST04_Modoshi_Riyu
                Case ENM_ZESEI_STAGE._50_�v���������m�F To ENM_ZESEI_STAGE._52_�v���������m�F_�F��
                    lbl = lblST05_Modoshi_Riyu
                Case Else
                    Exit Sub
            End Select
            V003 = _V003_SYONIN_J_KANRI_List.
                    AsEnumerable.
                    Where(Function(r) r.SYONIN_JUN = StageID And
                                      r.SASIMODOSI_FG And
                                      Not r.RIYU.ToString.Trim.IsNulOrWS).FirstOrDefault

            If V003 IsNot Nothing Then
                lbl.Text = $"���ߗ��R�F{V003.RIYU}"
                lbl.Visible = True
            Else
                lbl.Text = ""
                lbl.Visible = False
            End If
        Catch ex As Exception
            Throw
        End Try
    End Sub

#End Region

#Region "���̓`�F�b�N"

    Private Function FunCheckInput(ByVal enmSAVE_MODE As ENM_SAVE_MODE) As Boolean
        Try
            '�t���O���Z�b�g
            IsValidated = True
            IsCheckRequired = True

#Region "�w�b�_"

            Call cmbBUMON_Validated(cmbBUMON, Nothing)
            'all cmbKA_Validated(cmbKA, Nothing)
            Call cmbTANTO_Validated(cmbTANTO, Nothing)

#End Region

            If Not IsValidated Then Return False

            If enmSAVE_MODE = ENM_SAVE_MODE._2_���F�\�� Then
                Select Case PrCurrentStage
                    Case ENM_ZESEI_STAGE._10_�N������
                        Call dtKAITOU_KIBOU_YMD_Validating(dtKAITOU_KIBOU_YMD, Nothing)
                        Call CmbDestTANTO_SelectedvalueChanged(cmbTANTO, Nothing)
                        Call CmbDestTANTO_SelectedvalueChanged(cmbST01_SAKUSEI_TANTO, Nothing)
                        Call CmbDestTANTO_SelectedvalueChanged(cmbST01_TENKEN_TANTO, Nothing)
                        Call rbtnINPUT_TYPE_CheckedChanged(pnlINPUT_TYPE, Nothing)
                        Call txtDOC_NO_Validated(txtDOC_NO, Nothing)
                        Call txtKANSATU_HOUKOKU_Validated(txtKANSATU_HOUKOKU, Nothing)
                        Call txtZESEI_RIYU_Validated(txtZESEI_RIYU, Nothing)
                        Call txtZESEI_COMMENT_Validated(txtZESEI_COMMENT, Nothing)

                    Case ENM_ZESEI_STAGE._11_�N������_�_��
                        Call CmbDestTANTO_SelectedvalueChanged(cmbST01_TENKEN_TANTO, Nothing)
                        Call CmbDestTANTO_SelectedvalueChanged(cmbST01_NINKA_TANTO, Nothing)

                        Call txtKANSATU_HOUKOKU_Validated(txtKANSATU_HOUKOKU, Nothing)
                        Call txtZESEI_RIYU_Validated(txtZESEI_RIYU, Nothing)
                        Call txtZESEI_COMMENT_Validated(txtZESEI_COMMENT, Nothing)
                    Case ENM_ZESEI_STAGE._12_�N������_�F��
                        Call CmbDestTANTO_SelectedvalueChanged(cmbST01_NINKA_TANTO, Nothing)
                        Call CmbDestTANTO_SelectedvalueChanged(cmbST02_SAKUSEI_TANTO, Nothing)

                        Call txtKANSATU_HOUKOKU_Validated(txtKANSATU_HOUKOKU, Nothing)
                        Call txtZESEI_RIYU_Validated(txtZESEI_RIYU, Nothing)
                        Call txtZESEI_COMMENT_Validated(txtZESEI_COMMENT, Nothing)

                    Case ENM_ZESEI_STAGE._20_�������u����
                        Call dtKAITOU_KIBOU_YMD_Validating(dtKAITOU_YMD, Nothing)
                        Call CmbDestTANTO_SelectedvalueChanged(cmbST02_SAKUSEI_TANTO, Nothing)
                        Call CmbDestTANTO_SelectedvalueChanged(cmbST02_TENKEN_TANTO, Nothing)

                        Call txtFUTEKIGO_TAISYOU_Validated(txtFUTEKIGO_TAISYOU, Nothing)
                        Call txtCHOUSA_HANI_Validated(txtCHOUSA_HANI, Nothing)
                        Call txtEIKYOU_HANI_Validated(txtEIKYOU_HANI, Nothing)
                        Call txtOUKYU_SYOCHI_Validated(txtOUKYU_SYOCHI, Nothing)
                        Call txtHASSEI_GENIN_Validated(txtHASSEI_GENIN, Nothing)
                        Call txtZESEI_SYOCHI_Validated(txtZESEI_SYOCHI, Nothing)
                    Case ENM_ZESEI_STAGE._21_�������u����_�_��
                        Call CmbDestTANTO_SelectedvalueChanged(cmbST02_TENKEN_TANTO, Nothing)
                        Call CmbDestTANTO_SelectedvalueChanged(cmbST02_NINKA_TANTO, Nothing)

                        Call txtFUTEKIGO_TAISYOU_Validated(txtFUTEKIGO_TAISYOU, Nothing)
                        Call txtCHOUSA_HANI_Validated(txtCHOUSA_HANI, Nothing)
                        Call txtEIKYOU_HANI_Validated(txtEIKYOU_HANI, Nothing)
                        Call txtOUKYU_SYOCHI_Validated(txtOUKYU_SYOCHI, Nothing)
                        Call txtHASSEI_GENIN_Validated(txtHASSEI_GENIN, Nothing)
                        Call txtZESEI_SYOCHI_Validated(txtZESEI_SYOCHI, Nothing)
                    Case ENM_ZESEI_STAGE._22_�������u����_�F��
                        Call CmbDestTANTO_SelectedvalueChanged(cmbST02_NINKA_TANTO, Nothing)

                        Call txtFUTEKIGO_TAISYOU_Validated(txtFUTEKIGO_TAISYOU, Nothing)
                        Call txtCHOUSA_HANI_Validated(txtCHOUSA_HANI, Nothing)
                        Call txtEIKYOU_HANI_Validated(txtEIKYOU_HANI, Nothing)
                        Call txtOUKYU_SYOCHI_Validated(txtOUKYU_SYOCHI, Nothing)
                        Call txtHASSEI_GENIN_Validated(txtHASSEI_GENIN, Nothing)
                        Call txtZESEI_SYOCHI_Validated(txtZESEI_SYOCHI, Nothing)
                    Case ENM_ZESEI_STAGE._23_�������u����_�i��_�_��
                        Call CmbDestTANTO_SelectedvalueChanged(cmbST02_HINSYO_TENKEN_TANTO, Nothing)
                        Call CmbDestTANTO_SelectedvalueChanged(cmbST02_HINSYO_NINKA_TANTO, Nothing)

                        Call txtFUTEKIGO_TAISYOU_Validated(txtFUTEKIGO_TAISYOU, Nothing)
                        Call txtCHOUSA_HANI_Validated(txtCHOUSA_HANI, Nothing)
                        Call txtEIKYOU_HANI_Validated(txtEIKYOU_HANI, Nothing)
                        Call txtOUKYU_SYOCHI_Validated(txtOUKYU_SYOCHI, Nothing)
                        Call txtHASSEI_GENIN_Validated(txtHASSEI_GENIN, Nothing)
                        Call txtZESEI_SYOCHI_Validated(txtZESEI_SYOCHI, Nothing)
                    Case ENM_ZESEI_STAGE._24_�������u����_�i��_�F��
                        Call CmbDestTANTO_SelectedvalueChanged(cmbST02_HINSYO_NINKA_TANTO, Nothing)
                        Call CmbDestTANTO_SelectedvalueChanged(cmbST03_SAKUSEI_TANTO, Nothing)

                        Call txtFUTEKIGO_TAISYOU_Validated(txtFUTEKIGO_TAISYOU, Nothing)
                        Call txtCHOUSA_HANI_Validated(txtCHOUSA_HANI, Nothing)
                        Call txtEIKYOU_HANI_Validated(txtEIKYOU_HANI, Nothing)
                        Call txtOUKYU_SYOCHI_Validated(txtOUKYU_SYOCHI, Nothing)
                        Call txtHASSEI_GENIN_Validated(txtHASSEI_GENIN, Nothing)
                        Call txtZESEI_SYOCHI_Validated(txtZESEI_SYOCHI, Nothing)
                    Case ENM_ZESEI_STAGE._30_���u���ʓ���
                        Call CmbDestTANTO_SelectedvalueChanged(cmbST03_SAKUSEI_TANTO, Nothing)

                        Call txtOUKYU_SYOCHI_KEKKA_Validated(txtOUKYU_SYOCHI_KEKKA, Nothing)
                        Call txtZESEI_SYOCHI_KEKKA_Validated(txtZESEI_SYOCHI_KEKKA, Nothing)
                    Case ENM_ZESEI_STAGE._31_���u���ʓ���_�_��
                        Call CmbDestTANTO_SelectedvalueChanged(cmbST03_TENKEN_TANTO, Nothing)
                    Case ENM_ZESEI_STAGE._32_���u���ʓ���_�F��
                        Call CmbDestTANTO_SelectedvalueChanged(cmbST03_NINKA_TANTO, Nothing)
                    Case ENM_ZESEI_STAGE._40_���u���ʃ��r���[
                        Call CmbDestTANTO_SelectedvalueChanged(cmbST04_SAKUSEI_TANTO, Nothing)
                    Case ENM_ZESEI_STAGE._41_���u���ʃ��r���[_�_��
                        Call CmbDestTANTO_SelectedvalueChanged(cmbST04_TENKEN_TANTO, Nothing)
                    Case ENM_ZESEI_STAGE._42_���u���ʃ��r���[_�F��
                        Call CmbDestTANTO_SelectedvalueChanged(cmbST04_NINKA_TANTO, Nothing)
                    Case ENM_ZESEI_STAGE._50_�v���������m�F
                        Call CmbDestTANTO_SelectedvalueChanged(cmbST05_SAKUSEI_TANTO, Nothing)
                    Case ENM_ZESEI_STAGE._51_�v���������m�F_�_��
                        Call CmbDestTANTO_SelectedvalueChanged(cmbST05_TENKEN_TANTO, Nothing)
                    Case ENM_ZESEI_STAGE._52_�v���������m�F_�F��
                        Call CmbDestTANTO_SelectedvalueChanged(cmbST05_NINKA_TANTO, Nothing)
                End Select
            End If

            '��L�e��Validating�C�x���g�Ńt���O���X�V���A�S��OK�̏ꍇ��True
            Return IsValidated
        Catch ex As Exception
            Throw
        Finally
            'IsCheckRequired = False
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
        sbSQL.Append($"Select")
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
                Case ENM_ZESEI_STAGE._10_�N������
                    Return ENM_ZESEI_STAGE._11_�N������_�_��
                Case ENM_ZESEI_STAGE._11_�N������_�_��
                    Return ENM_ZESEI_STAGE._12_�N������_�F��
                Case ENM_ZESEI_STAGE._12_�N������_�F��
                    Return ENM_ZESEI_STAGE._20_�������u����
                Case ENM_ZESEI_STAGE._20_�������u����
                    Return ENM_ZESEI_STAGE._21_�������u����_�_��
                Case ENM_ZESEI_STAGE._21_�������u����_�_��
                    Return ENM_ZESEI_STAGE._22_�������u����_�F��
                Case ENM_ZESEI_STAGE._22_�������u����_�F��

                    Select Case _D013.INPUT_TYPE
                        Case 1, 2
                            Return ENM_ZESEI_STAGE._23_�������u����_�i��_�_��
                        Case Else
                            Return ENM_ZESEI_STAGE._30_���u���ʓ���
                    End Select

                Case ENM_ZESEI_STAGE._23_�������u����_�i��_�_��
                    Return ENM_ZESEI_STAGE._24_�������u����_�i��_�F��
                Case ENM_ZESEI_STAGE._24_�������u����_�i��_�F��
                    Return ENM_ZESEI_STAGE._30_���u���ʓ���
                Case ENM_ZESEI_STAGE._30_���u���ʓ���
                    Return ENM_ZESEI_STAGE._31_���u���ʓ���_�_��
                Case ENM_ZESEI_STAGE._31_���u���ʓ���_�_��
                    Return ENM_ZESEI_STAGE._32_���u���ʓ���_�F��
                Case ENM_ZESEI_STAGE._32_���u���ʓ���_�F��
                    Return ENM_ZESEI_STAGE._40_���u���ʃ��r���[
                Case ENM_ZESEI_STAGE._40_���u���ʃ��r���[
                    Return ENM_ZESEI_STAGE._41_���u���ʃ��r���[_�_��
                Case ENM_ZESEI_STAGE._41_���u���ʃ��r���[_�_��
                    Return ENM_ZESEI_STAGE._42_���u���ʃ��r���[_�F��
                Case ENM_ZESEI_STAGE._42_���u���ʃ��r���[_�F��
                    Return ENM_ZESEI_STAGE._50_�v���������m�F
                Case ENM_ZESEI_STAGE._50_�v���������m�F
                    Return ENM_ZESEI_STAGE._51_�v���������m�F_�_��
                Case ENM_ZESEI_STAGE._51_�v���������m�F_�_��
                    Return ENM_ZESEI_STAGE._52_�v���������m�F_�F��
                Case ENM_ZESEI_STAGE._52_�v���������m�F_�F��
                    Return ENM_ZESEI_STAGE._999_Closed
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
            Dim cmb As ComboboxEx

            Select Case intSYONIN_JUN
                Case ENM_ZESEI_STAGE._10_�N������
                    cmb = cmbST01_SAKUSEI_TANTO
                Case ENM_ZESEI_STAGE._11_�N������_�_��
                    cmb = cmbST01_TENKEN_TANTO
                Case ENM_ZESEI_STAGE._12_�N������_�F��
                    cmb = cmbST01_NINKA_TANTO
                Case ENM_ZESEI_STAGE._20_�������u����
                    cmb = cmbST02_SAKUSEI_TANTO
                Case ENM_ZESEI_STAGE._21_�������u����_�_��
                    cmb = cmbST02_TENKEN_TANTO
                Case ENM_ZESEI_STAGE._22_�������u����_�F��
                    cmb = cmbST02_NINKA_TANTO
                Case ENM_ZESEI_STAGE._23_�������u����_�i��_�_��
                    cmb = cmbST02_HINSYO_TENKEN_TANTO
                Case ENM_ZESEI_STAGE._24_�������u����_�i��_�F��
                    cmb = cmbST02_HINSYO_NINKA_TANTO
                Case ENM_ZESEI_STAGE._30_���u���ʓ���
                    cmb = cmbST03_SAKUSEI_TANTO
                Case ENM_ZESEI_STAGE._31_���u���ʓ���_�_��
                    cmb = cmbST03_TENKEN_TANTO
                Case ENM_ZESEI_STAGE._32_���u���ʓ���_�F��
                    cmb = cmbST03_NINKA_TANTO
                Case ENM_ZESEI_STAGE._40_���u���ʃ��r���[
                    cmb = cmbST04_SAKUSEI_TANTO
                Case ENM_ZESEI_STAGE._41_���u���ʃ��r���[_�_��
                    cmb = cmbST04_TENKEN_TANTO
                Case ENM_ZESEI_STAGE._42_���u���ʃ��r���[_�F��
                    cmb = cmbST04_NINKA_TANTO
                Case ENM_ZESEI_STAGE._50_�v���������m�F
                    cmb = cmbST05_SAKUSEI_TANTO
                Case ENM_ZESEI_STAGE._51_�v���������m�F_�_��
                    cmb = cmbST05_TENKEN_TANTO
                Case ENM_ZESEI_STAGE._52_�v���������m�F_�F��
                    cmb = cmbST05_NINKA_TANTO
                Case Else

                    'close �ς݁@�V�X�e���S���҂̂ݕҏW����
                    Return False
            End Select
            Dim users = DirectCast(cmb.DataSource, DataTable)
            If users IsNot Nothing AndAlso users.Rows.Count > 0 Then
                Return users.AsEnumerable.Any(Function(r) r.Item("VALUE") = pub_SYAIN_INFO.SYAIN_ID)
            Else
                Return False
            End If
        Catch ex As Exception
            Throw
        End Try

    End Function

    Private Function IsNeedMeeting() As Boolean

        Dim sbSQL As New System.Text.StringBuilder
        Dim sqlEx As New Exception
        Dim intRET As Integer

        'sbSQL.Append($"SELECT")
        'sbSQL.Append($" COUNT({NameOf(D012.TANTO_ID)})")
        'sbSQL.Append($" FROM {NameOf(D012_FCCB_SUB_SYOCHI_KAKUNIN)} ")
        'sbSQL.Append($" WHERE {NameOf(D012.FCCB_NO)}='{_D009.FCCB_NO}' ")
        'sbSQL.Append($" AND {NameOf(D012.TANTO_ID)}<>0 ")
        'sbSQL.Append($" AND RTRIM({NameOf(D012.KYOGI_YOHI_KAITO)})='1' ")
        Using DB = DBOpen()
            intRET = DB.ExecuteScalar(sbSQL.ToString, conblnNonMsg, sqlEx).ToVal()
        End Using

        Return intRET > 0
    End Function

    ''' <summary>
    ''' �\����Ј�ID���擾
    ''' </summary>
    ''' <param name="intCurrentStageID"></param>
    ''' <returns></returns>
    Private Function FunGetNextSYONIN_TANTO_ID(ByVal intCurrentStageID As Integer) As Integer
        Try
            Dim cmb As ComboboxEx = Nothing

            Select Case PrCurrentStage
                Case ENM_ZESEI_STAGE._10_�N������
                    cmb = cmbST01_TENKEN_TANTO
                Case ENM_ZESEI_STAGE._11_�N������_�_��
                    cmb = cmbST01_NINKA_TANTO
                Case ENM_ZESEI_STAGE._12_�N������_�F��
                    cmb = cmbST02_SAKUSEI_TANTO
                Case ENM_ZESEI_STAGE._20_�������u����
                    cmb = cmbST02_TENKEN_TANTO
                Case ENM_ZESEI_STAGE._21_�������u����_�_��
                    cmb = cmbST02_NINKA_TANTO
                Case ENM_ZESEI_STAGE._22_�������u����_�F��
                    Select Case _D013.INPUT_TYPE
                        Case "1", "2"
                            cmb = cmbST02_HINSYO_TENKEN_TANTO
                        Case Else
                            cmb = cmbST03_SAKUSEI_TANTO
                    End Select
                Case ENM_ZESEI_STAGE._23_�������u����_�i��_�_��
                    cmb = cmbST02_HINSYO_NINKA_TANTO
                Case ENM_ZESEI_STAGE._24_�������u����_�i��_�F��
                    cmb = cmbST03_SAKUSEI_TANTO
                Case ENM_ZESEI_STAGE._30_���u���ʓ���
                    cmb = cmbST03_TENKEN_TANTO
                Case ENM_ZESEI_STAGE._31_���u���ʓ���_�_��
                    cmb = cmbST03_NINKA_TANTO
                Case ENM_ZESEI_STAGE._32_���u���ʓ���_�F��
                    cmb = cmbST04_SAKUSEI_TANTO
                Case ENM_ZESEI_STAGE._40_���u���ʃ��r���[
                    cmb = cmbST04_TENKEN_TANTO
                Case ENM_ZESEI_STAGE._41_���u���ʃ��r���[_�_��
                    cmb = cmbST04_NINKA_TANTO
                Case ENM_ZESEI_STAGE._42_���u���ʃ��r���[_�F��
                    cmb = cmbST05_SAKUSEI_TANTO
                Case ENM_ZESEI_STAGE._50_�v���������m�F
                    cmb = cmbST05_TENKEN_TANTO
                Case ENM_ZESEI_STAGE._51_�v���������m�F_�_��
                    cmb = cmbST05_NINKA_TANTO
                Case ENM_ZESEI_STAGE._52_�v���������m�F_�F��
                    cmb = Nothing
            End Select

            If cmb IsNot Nothing Then
                Return cmb.SelectedValue
            Else
                Return 0
            End If
        Catch ex As Exception
            Throw
        End Try
    End Function

    ''' <summary>
    ''' �\����Ј�ID���擾
    ''' </summary>
    ''' <param name="intCurrentStageID"></param>
    ''' <returns></returns>
    Private Function FunGetCurrentSYONIN_TANTO(ByVal intCurrentStageID As Integer) As DataTable
        Try
            Dim cmb As ComboboxEx = Nothing

            Select Case PrCurrentStage
                Case ENM_ZESEI_STAGE._10_�N������
                    cmb = cmbST01_SAKUSEI_TANTO
                Case ENM_ZESEI_STAGE._11_�N������_�_��
                    cmb = cmbST01_TENKEN_TANTO
                Case ENM_ZESEI_STAGE._12_�N������_�F��
                    cmb = cmbST01_NINKA_TANTO
                Case ENM_ZESEI_STAGE._20_�������u����
                    cmb = cmbST02_SAKUSEI_TANTO
                Case ENM_ZESEI_STAGE._21_�������u����_�_��
                    cmb = cmbST02_TENKEN_TANTO
                Case ENM_ZESEI_STAGE._22_�������u����_�F��
                    cmb = cmbST02_NINKA_TANTO
                Case ENM_ZESEI_STAGE._23_�������u����_�i��_�_��
                    cmb = cmbST02_HINSYO_TENKEN_TANTO
                Case ENM_ZESEI_STAGE._24_�������u����_�i��_�F��
                    cmb = cmbST02_HINSYO_NINKA_TANTO
                Case ENM_ZESEI_STAGE._30_���u���ʓ���
                    cmb = cmbST03_SAKUSEI_TANTO
                Case ENM_ZESEI_STAGE._31_���u���ʓ���_�_��
                    cmb = cmbST03_TENKEN_TANTO
                Case ENM_ZESEI_STAGE._32_���u���ʓ���_�F��
                    cmb = cmbST03_NINKA_TANTO
                Case ENM_ZESEI_STAGE._40_���u���ʃ��r���[
                    cmb = cmbST04_SAKUSEI_TANTO
                Case ENM_ZESEI_STAGE._41_���u���ʃ��r���[_�_��
                    cmb = cmbST04_TENKEN_TANTO
                Case ENM_ZESEI_STAGE._42_���u���ʃ��r���[_�F��
                    cmb = cmbST04_NINKA_TANTO
                Case ENM_ZESEI_STAGE._50_�v���������m�F
                    cmb = cmbST05_SAKUSEI_TANTO
                Case ENM_ZESEI_STAGE._51_�v���������m�F_�_��
                    cmb = cmbST05_TENKEN_TANTO
                Case ENM_ZESEI_STAGE._52_�v���������m�F_�F��
                    cmb = cmbST05_NINKA_TANTO
            End Select

            If cmb IsNot Nothing Then
                Return cmb.DataSource
            Else
                Return Nothing
            End If
        Catch ex As Exception
            Throw
        End Try
    End Function

#End Region

#Region "�Y�t�t�@�C��"

#Region "1"

    '�Y�t�t�@�C���I��
    Private Sub BtnOpenTempFileDialog_Click(sender As Object, e As EventArgs) Handles btnOpenTempFileDialog.Click
        Dim ofd As New OpenFileDialog With {
            .Filter = "���ׂẴt�@�C��(*.*)|*.*|Excel(*.xls;*.xlsx)|*.xls;*.xlsx|Word(*.doc;*.docx)|*.doc;*.docx",
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

            _D013.FILE_PATH1 = IO.Path.GetFileName(ofd.FileName)
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
            If strEXE.IsNulOrWS Then
            Else
                If System.IO.File.Exists(strEXE) = True Then
                    hProcess.StartInfo.FileName = strEXE
                    hProcess.SynchronizingObject = Me
                    hProcess.EnableRaisingEvents = True
                    hProcess.Start()

                    '�őO��
                    Call SetForegroundWindow(hProcess.Handle)
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
        _D013.FILE_PATH1 = ""
        lbltmpFile1.Links.Clear()
        lbltmpFile1.Visible = False
        lbltmpFile1_Clear.Visible = False
    End Sub

#End Region

#Region "2"

    '�Y�t�t�@�C���I��
    Private Sub BtnOpenTempFileDialog2_Click(sender As Object, e As EventArgs) Handles btnOpenTempFileDialog2.Click
        Dim ofd As New OpenFileDialog With {
            .Filter = "���ׂẴt�@�C��(*.*)|*.*|Excel(*.xls;*.xlsx)|*.xls;*.xlsx|Word(*.doc;*.docx)|*.doc;*.docx",
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

            _D013.FILE_PATH2 = IO.Path.GetFileName(ofd.FileName)
            lbltmpFile2.Visible = True
            lbltmpFile2_Clear.Visible = True
        End If
    End Sub

    '�����N�N���b�N
    Private Sub LbltmpFile2_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles lbltmpFile2.LinkClicked
        Dim hProcess As New System.Diagnostics.Process
        Dim strEXE As String

        Try

            strEXE = lbltmpFile2.Links(0).LinkData
            If strEXE.IsNulOrWS Then
            Else
                If System.IO.File.Exists(strEXE) = True Then
                    hProcess.StartInfo.FileName = strEXE
                    hProcess.SynchronizingObject = Me
                    hProcess.EnableRaisingEvents = True
                    hProcess.Start()

                    '�őO��
                    Call SetForegroundWindow(hProcess.Handle)
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
            '-----�J��
            If hProcess IsNot Nothing Then
                hProcess.Close()
            End If
        End Try
    End Sub

    '�����N�N���A
    Private Sub LbltmpFile2_Clear_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles lbltmpFile2_Clear.LinkClicked
        lbltmpFile2.Text = ""
        _D013.FILE_PATH2 = ""
        lbltmpFile2.Links.Clear()
        lbltmpFile2.Visible = False
        lbltmpFile2_Clear.Visible = False
    End Sub

#End Region

#Region "3"

    '�Y�t�t�@�C���I��
    Private Sub BtnOpenTempFileDialog3_Click(sender As Object, e As EventArgs) Handles btnOpenTempFileDialog3.Click
        Dim ofd As New OpenFileDialog With {
            .Filter = "���ׂẴt�@�C��(*.*)|*.*|Excel(*.xls;*.xlsx)|*.xls;*.xlsx|Word(*.doc;*.docx)|*.doc;*.docx",
            .FilterIndex = 1,
            .Title = "�Y�t����t�@�C����I�����Ă�������",
            .RestoreDirectory = True
        }
        If lbltmpFile3.Links.Count = 0 Then
        Else
            ofd.InitialDirectory = IO.Path.GetDirectoryName(lbltmpFile3.Links(0).ToString)
        End If
        If ofd.ShowDialog() = DialogResult.OK Then
            lbltmpFile3.Text = IO.Path.GetFileName(ofd.FileName)
            lbltmpFile3.Links.Clear()
            lbltmpFile3.Links.Add(0, lbltmpFile3.Text.Length, ofd.FileName)

            _D013.FILE_PATH3 = IO.Path.GetFileName(ofd.FileName)
            lbltmpFile3.Visible = True
            lbltmpFile3_Clear.Visible = True
        End If
    End Sub

    '�����N�N���b�N
    Private Sub LbltmpFile3_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles lbltmpFile3.LinkClicked
        Dim hProcess As New System.Diagnostics.Process
        Dim strEXE As String
        Try

            strEXE = lbltmpFile3.Links(0).LinkData
            If strEXE.IsNulOrWS Then
            Else
                If System.IO.File.Exists(strEXE) = True Then
                    hProcess.StartInfo.FileName = strEXE
                    hProcess.SynchronizingObject = Me
                    hProcess.EnableRaisingEvents = True
                    hProcess.Start()

                    '�őO��
                    Call SetForegroundWindow(hProcess.Handle)
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

            '-----�J��
            If hProcess IsNot Nothing Then
                hProcess.Close()
            End If
        End Try
    End Sub

    '�����N�N���A
    Private Sub LbltmpFile3_Clear_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles lbltmpFile3_Clear.LinkClicked
        lbltmpFile3.Text = ""
        _D013.FILE_PATH3 = ""
        lbltmpFile3.Links.Clear()
        lbltmpFile3.Visible = False
        lbltmpFile3_Clear.Visible = False
    End Sub

#End Region

#Region "4"

    '�Y�t�t�@�C���I��
    Private Sub BtnOpenTempFileDialog4_Click(sender As Object, e As EventArgs) Handles btnOpenTempFileDialog4.Click
        Dim ofd As New OpenFileDialog With {
            .Filter = "���ׂẴt�@�C��(*.*)|*.*|Excel(*.xls;*.xlsx)|*.xls;*.xlsx|Word(*.doc;*.docx)|*.doc;*.docx",
            .FilterIndex = 1,
            .Title = "�Y�t����t�@�C����I�����Ă�������",
            .RestoreDirectory = True
        }
        If lbltmpFile4.Links.Count = 0 Then
        Else
            ofd.InitialDirectory = IO.Path.GetDirectoryName(lbltmpFile4.Links(0).ToString)
        End If
        If ofd.ShowDialog() = DialogResult.OK Then
            lbltmpFile4.Text = IO.Path.GetFileName(ofd.FileName)
            lbltmpFile4.Links.Clear()
            lbltmpFile4.Links.Add(0, lbltmpFile4.Text.Length, ofd.FileName)

            _D013.FILE_PATH4 = IO.Path.GetFileName(ofd.FileName)
            lbltmpFile4.Visible = True
            lbltmpFile4_Clear.Visible = True
        End If
    End Sub

    '�����N�N���b�N
    Private Sub LbltmpFile4_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles lbltmpFile4.LinkClicked
        Dim hProcess As New System.Diagnostics.Process
        Dim strEXE As String
        Try

            strEXE = lbltmpFile4.Links(0).LinkData
            If strEXE.IsNulOrWS Then
            Else
                If System.IO.File.Exists(strEXE) = True Then
                    hProcess.StartInfo.FileName = strEXE
                    hProcess.SynchronizingObject = Me
                    hProcess.EnableRaisingEvents = True
                    hProcess.Start()

                    '�őO��
                    Call SetForegroundWindow(hProcess.Handle)
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

            '-----�J��
            If hProcess IsNot Nothing Then
                hProcess.Close()
            End If
        End Try
    End Sub

    '�����N�N���A
    Private Sub LbltmpFile4_Clear_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles lbltmpFile4_Clear.LinkClicked
        lbltmpFile4.Text = ""
        _D013.FILE_PATH4 = ""
        lbltmpFile4.Links.Clear()
        lbltmpFile4.Visible = False
        lbltmpFile4_Clear.Visible = False
    End Sub

#End Region

#Region "5"

    '�Y�t�t�@�C���I��
    Private Sub BtnOpenTempFileDialog5_Click(sender As Object, e As EventArgs) Handles btnOpenTempFileDialog5.Click
        Dim ofd As New OpenFileDialog With {
            .Filter = "���ׂẴt�@�C��(*.*)|*.*|Excel(*.xls;*.xlsx)|*.xls;*.xlsx|Word(*.doc;*.docx)|*.doc;*.docx",
            .FilterIndex = 1,
            .Title = "�Y�t����t�@�C����I�����Ă�������",
            .RestoreDirectory = True
        }
        If lbltmpFile5.Links.Count = 0 Then
        Else
            ofd.InitialDirectory = IO.Path.GetDirectoryName(lbltmpFile5.Links(0).ToString)
        End If
        If ofd.ShowDialog() = DialogResult.OK Then
            lbltmpFile5.Text = IO.Path.GetFileName(ofd.FileName)
            lbltmpFile5.Links.Clear()
            lbltmpFile5.Links.Add(0, lbltmpFile5.Text.Length, ofd.FileName)

            _D013.FILE_PATH5 = IO.Path.GetFileName(ofd.FileName)
            lbltmpFile5.Visible = True
            lbltmpFile5_Clear.Visible = True
        End If
    End Sub

    '�����N�N���b�N
    Private Sub LbltmpFile5_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles lbltmpFile5.LinkClicked
        Dim hProcess As New System.Diagnostics.Process
        Dim strEXE As String
        'Dim strARG As String
        Try

            strEXE = lbltmpFile5.Links(0).LinkData
            If strEXE.IsNulOrWS Then
            Else
                If System.IO.File.Exists(strEXE) = True Then
                    hProcess.StartInfo.FileName = strEXE
                    hProcess.SynchronizingObject = Me
                    hProcess.EnableRaisingEvents = True
                    hProcess.Start()

                    '�őO��
                    Call SetForegroundWindow(hProcess.Handle)
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
    Private Sub LbltmpFile5_Clear_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles lbltmpFile5_Clear.LinkClicked
        lbltmpFile5.Text = ""
        _D013.FILE_PATH5 = ""
        lbltmpFile5.Links.Clear()
        lbltmpFile5.Visible = False
        lbltmpFile5_Clear.Visible = False
    End Sub

#End Region

#End Region

End Class