Imports System.Threading.Tasks
Imports JMS_COMMON.ClsPubMethod
Imports MODEL

''' <summary>
''' FCCB�o�^���
''' </summary>
Public Class FrmG0021_Detail

#Region "�萔�E�ϐ�"

    Private _V002_NCR_J As New V002_NCR_J
    Private _V003_SYONIN_J_KANRI_List As New List(Of V003_SYONIN_J_KANRI)
    Private IsEditingClosed As Boolean
    Private IsInitializing As Boolean

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
        MyBase.ToolTip.SetToolTip(Me.cmdFunc4, My.Resources.infoToolTipMsgNotFoundData)
        MyBase.ToolTip.SetToolTip(Me.cmdFunc5, My.Resources.infoToolTipMsgNotFoundData)
        MyBase.ToolTip.SetToolTip(Me.cmdFunc10, My.Resources.infoToolTipMsgNotFoundData)
        MyBase.ToolTip.SetToolTip(Me.cmdFunc11, My.Resources.infoToolTipMsgNotFoundData)

        'cmbDestTANTO.NullValue = 0
        'cmbKOKYAKU_EIKYO_HANTEI_COMMENT.NullValue = ""
        'dtTUCHI_YMD.Nullable = True
        'dtKOKYAKU_NOUNYU_YMD.Nullable = True
        'dtZAIKO_SIKAKE_YMD.Nullable = True
        'dtOTHER_PROCESS_YMD.Nullable = True
        'Me.Height = 750

        'rsbtnST99.Enabled = False
        'dtFUTEKIGO_HASSEI_YMD.ReadOnly = True

        'dtSYOCHI_YOTEI_YMD.MinDate = Date.Today

        'dtFUTEKIGO_HASSEI_YMD.ReadOnly = True

    End Sub

#End Region

#Region "Form�֘A"

    'Load�C�x���g
    Private Async Sub FrmLoad(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        Try
            PrRIYU = ""
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
                        _D004_SYONIN_J_KANRI.clear()

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
        End Try
    End Sub

    Private Sub TabPageMouseWheel(sender As Object, e As MouseEventArgs)
        'tabSTAGE01.Focus()
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

                    '���̓`�F�b�N
                    If FunCheckInput(ENM_SAVE_MODE._2_���F�\��) Then
                        Dim strMsg As String
                        If FunGetNextSYONIN_JUN(PrCurrentStage) = ENM_FCCB_STAGE._999_Closed Then
                            strMsg = "���F���܂����H"
                        Else
                            strMsg = "���F�E�\�����܂����H"
                        End If

                        If MessageBox.Show(strMsg, "���F�E�\�������m�F", MessageBoxButtons.YesNo, MessageBoxIcon.Information) = DialogResult.Yes Then
                            If FunSAVE(ENM_SAVE_MODE._2_���F�\��) Then
                                If PrCurrentStage = ENM_FCCB_STAGE._61_���u���������m�F_���� Then
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

                Case 4  '�]��

                    'If FunCheckInput(ENM_SAVE_MODE._1_�ۑ�) Then
                    '    If OpenFormTENSO() Then
                    '        If IsSysAdminUser(pub_SYAIN_INFO.SYAIN_ID) Then
                    '            Me.DialogResult = DialogResult.OK
                    '        Else
                    '            If FunSAVE(ENM_SAVE_MODE._1_�ۑ�, True) Then
                    '                Me.DialogResult = DialogResult.OK
                    '            Else
                    '                MessageBox.Show("�ۑ������Ɏ��s���܂����B", "�ۑ����s", MessageBoxButtons.OK, MessageBoxIcon.Error)
                    '            End If
                    '        End If
                    '    End If
                    'End If

                Case 5  '�����߂�
                    'Call OpenFormSASIMODOSI()

                Case 10  '���

                    'Call FunOpenReportFCCB()

                Case 11 '����

                    'Call OpenFormHistory(Context.ENM_SYONIN_HOKOKUSYO_ID._4_FCCB, _D009_FCCB_J.HOKOKU_NO)

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

                    If FunSAVE_D009(DB, enmSAVE_MODE) = False Then blnErr = True : Return False
                    If FunSAVE_D010(DB, enmSAVE_MODE) = False Then blnErr = True : Return False
                    'If FunSAVE_FILE(DB) = False Then blnErr = True : Return False

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

#Region "   �Y�t�t�@�C���ۑ�"

    ''' <summary>
    ''' CTS�Y�t�t�@�C���ۑ�
    ''' </summary>
    ''' <param name="DB"></param>
    ''' <returns></returns>
    Private Function FunSAVE_FILE(ByRef DB As ClsDbUtility) As Boolean

        If _D009_FCCB_J.FCCB_NO.IsNulOrWS And
            _D009_FCCB_J.FCCB_NO.IsNulOrWS And
            _D009_FCCB_J.FCCB_NO.IsNulOrWS Then
            Return True
        Else

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
                    System.IO.Directory.CreateDirectory($"{strRootDir}{_D009_FCCB_J.FCCB_NO.Trim}\FCCB")

                    'If Not _D009_FCCB_J.SYOCHI_FILEPATH.IsNulOrWS AndAlso
                    '    Not System.IO.File.Exists($"{strRootDir}{_D009_FCCB_J.HOKOKU_NO.Trim}\CTS\{__D009_FCCB_J.SYOCHI_FILEPATH}") Then

                    '    If System.IO.File.Exists(lblSYOCHI_FILEPATH.Links.Item(0).LinkData) Then
                    '        System.IO.File.Copy(lblSYOCHI_FILEPATH.Links.Item(0).LinkData, $"{strRootDir}{_D009_FCCB_J.HOKOKU_NO.Trim}\CTS\{_D009_FCCB_J.SYOCHI_FILEPATH}", True)
                    '    Else
                    '        Throw New IO.FileNotFoundException($"5,���u���{ ����:{lblSYOCHI_FILEPATH.Links.Item(0).LinkData}��������܂���B���̏ꏊ�ɖ߂����I���������Ă�������")
                    '    End If
                    'End If

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

#Region "   D009"

    ''' <summary>
    ''' FCCB�X�V
    ''' </summary>
    ''' <param name="DB"></param>
    ''' <returns></returns>
    Private Function FunSAVE_D009(ByRef DB As ClsDbUtility, ByVal enmSAVE_MODE As ENM_SAVE_MODE) As Boolean
        Dim sbSQL As New System.Text.StringBuilder
        Dim strRET As String
        Dim sqlEx As New Exception
        Dim strSysDate As String = DB.GetSysDateString

#Region "���f���X�V"

        _D009_FCCB_J.Clear()
        _D009_FCCB_J.FCCB_NO = PrFCCB_NO

        If (FunGetNextSYONIN_JUN(PrCurrentStage) = ENM_FCCB_STAGE._999_Closed) And enmSAVE_MODE = ENM_SAVE_MODE._2_���F�\�� Then
            _D009_FCCB_J._CLOSE_FG = 1
        End If


        _D009_FCCB_J.ADD_YMDHNS = strSysDate
        _D009_FCCB_J.ADD_SYAIN_ID = pub_SYAIN_INFO.SYAIN_ID

#End Region

        '-----MERGE
        sbSQL.Remove(0, sbSQL.Length)
        sbSQL.Append($"MERGE INTO {NameOf(D009_FCCB_J)} AS SrcT")
        sbSQL.Append($" USING (")
        sbSQL.Append($"{_D009_FCCB_J.ToSelectSqlString}")
        sbSQL.Append($" ) AS WK")
        sbSQL.Append($" ON (SrcT.{NameOf(_D009_FCCB_J.FCCB_NO)} = WK.{NameOf(_D009_FCCB_J.FCCB_NO)})")
        'UPDATE
        sbSQL.Append($" WHEN MATCHED THEN")
        sbSQL.Append($" UPDATE SET")
        sbSQL.Append($"  SrcT.{NameOf(_D009_FCCB_J.BUMON_KB)}               = WK.{NameOf(_D009_FCCB_J.BUMON_KB)}")
        sbSQL.Append($" ,SrcT.{NameOf(_D009_FCCB_J.CLOSE_FG)}               = WK.{NameOf(_D009_FCCB_J.CLOSE_FG)}")
        sbSQL.Append($" ,SrcT.{NameOf(_D009_FCCB_J.CM_TANTO)}               = WK.{NameOf(_D009_FCCB_J.CM_TANTO)}")
        sbSQL.Append($" ,SrcT.{NameOf(_D009_FCCB_J.KISYU_ID)}               = WK.{NameOf(_D009_FCCB_J.KISYU_ID)}")
        sbSQL.Append($" ,SrcT.{NameOf(_D009_FCCB_J.SYANAI_CD)}              = WK.{NameOf(_D009_FCCB_J.SYANAI_CD)}")
        sbSQL.Append($" ,SrcT.{NameOf(_D009_FCCB_J.BUHIN_BANGO)}            = WK.{NameOf(_D009_FCCB_J.BUHIN_BANGO)}")
        sbSQL.Append($" ,SrcT.{NameOf(_D009_FCCB_J.BUHIN_NAME)}             = WK.{NameOf(_D009_FCCB_J.BUHIN_NAME)}")
        sbSQL.Append($" ,SrcT.{NameOf(_D009_FCCB_J.INPUT_DOC_NO)}           = WK.{NameOf(_D009_FCCB_J.INPUT_DOC_NO)}")
        sbSQL.Append($" ,SrcT.{NameOf(_D009_FCCB_J.SNO_APPLY_PERIOD_KISO)}  = WK.{NameOf(_D009_FCCB_J.SNO_APPLY_PERIOD_KISO)}")
        sbSQL.Append($" ,SrcT.{NameOf(_D009_FCCB_J.SNO_APPLY_PERIOD_SINGI)} = WK.{NameOf(_D009_FCCB_J.SNO_APPLY_PERIOD_SINGI)}")
        sbSQL.Append($" ,SrcT.{NameOf(_D009_FCCB_J.UPD_SYAIN_ID)}           = WK.{NameOf(_D009_FCCB_J.UPD_SYAIN_ID)}")
        sbSQL.Append($" ,SrcT.{NameOf(_D009_FCCB_J.UPD_YMDHNS)}             = WK.{NameOf(_D009_FCCB_J.UPD_YMDHNS)}")
        'INSERT
        sbSQL.Append($" WHEN NOT MATCHED THEN ")
        sbSQL.Append($"INSERT(")
        _D009_FCCB_J.Properties.Take(1).ForEach(Sub(p) sbSQL.Append($" {p.Name}"))
        _D009_FCCB_J.Properties.Skip(1).ForEach(Sub(p) sbSQL.Append($",{p.Name}"))
        sbSQL.Append($" ) VALUES(")
        _D009_FCCB_J.Properties.Take(1).ForEach(Sub(p) sbSQL.Append($" WK.{p.Name}"))
        _D009_FCCB_J.Properties.Skip(1).ForEach(Sub(p) sbSQL.Append($",WK.{p.Name}"))
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
        WL.WriteLogDat($"[DEBUG]FCCB �񍐏�NO:{_D009_FCCB_J.FCCB_NO}�AMERGE D009_FCCB_J")

        Return True
    End Function

#End Region

#Region "   D010"

    Private Function FunSAVE_D010(ByRef DB As ClsDbUtility, ByVal enmSAVE_MODE As ENM_SAVE_MODE) As Boolean
        Dim sbSQL As New System.Text.StringBuilder
        Dim strRET As String
        Dim sqlEx As New Exception
        Dim strSysDate As String = DB.GetSysDateString

        Dim _D010 As New D010_FCCB_SUB_SYOCHI_KOMOKU

        For Each dr As DataRow In DirectCast(Flx2_DS.DataSource, DataTable).Rows

#Region "   ���f���X�V"

            _D010.Clear()
            _D010.FCCB_NO = dr.Item(NameOf(_D010.FCCB_NO))
            _D010.ITEM_NO = dr.Item(NameOf(_D010.ITEM_NO))
            _D010.ITEM_GROUP_NAME = dr.Item(NameOf(_D010.ITEM_GROUP_NAME))
            _D010.ITEM_NAME = dr.Item(NameOf(_D010.ITEM_NAME))
            _D010.TANTO_GYOMU_GROUP_ID = dr.Item(NameOf(_D010.TANTO_GYOMU_GROUP_ID))
            _D010.NAIYO = dr.Item(NameOf(_D010.NAIYO))
            _D010.YOTEI_YMD = dr.Item(NameOf(_D010.YOTEI_YMD))
            _D010.CLOSE_YMD = dr.Item(NameOf(_D010.CLOSE_YMD))

#End Region

            sbSQL.Clear()
            sbSQL.Append($"MERGE INTO {NameOf(D010_FCCB_SUB_SYOCHI_KOMOKU)} AS SrcT")
            sbSQL.Append($" USING (")
            sbSQL.Append($"{_D010.ToSelectSqlString}")
            sbSQL.Append($" ) AS WK")
            sbSQL.Append($" ON (SrcT.{NameOf(_D010.FCCB_NO)} = WK.{NameOf(_D010.FCCB_NO)}")
            sbSQL.Append($" AND SrcT.{NameOf(_D010.ITEM_NO)} = WK.{NameOf(_D010.ITEM_NO)})")
            'UPDATE
            sbSQL.Append($" WHEN MATCHED THEN")
            sbSQL.Append($" UPDATE SET")
            sbSQL.Append($"  SrcT.{NameOf(_D010.ITEM_GROUP_NAME)} = WK.{NameOf(_D010.ITEM_GROUP_NAME)}")
            sbSQL.Append($" ,SrcT.{NameOf(_D010.ITEM_NAME)} = WK.{NameOf(_D010.ITEM_NAME)}")
            sbSQL.Append($" ,SrcT.{NameOf(_D010.TANTO_GYOMU_GROUP_ID)} = WK.{NameOf(_D010.TANTO_GYOMU_GROUP_ID)}")
            sbSQL.Append($" ,SrcT.{NameOf(_D010._YOHI_KB)} = WK.{NameOf(_D010.YOHI_KB)}")
            sbSQL.Append($" ,SrcT.{NameOf(_D010.TANTO_ID)} = WK.{NameOf(_D010.TANTO_ID)}")
            sbSQL.Append($" ,SrcT.{NameOf(_D010.NAIYO)} = WK.{NameOf(_D010.NAIYO)}")
            sbSQL.Append($" ,SrcT.{NameOf(_D010.GOKI)} = WK.{NameOf(_D010.GOKI)}")
            sbSQL.Append($" ,SrcT.{NameOf(_D010.YOTEI_YMD)} = WK.{NameOf(_D010.YOTEI_YMD)}")
            sbSQL.Append($" ,SrcT.{NameOf(_D010.CLOSE_YMD)} = WK.{NameOf(_D010.CLOSE_YMD)}")
            'INSERT
            sbSQL.Append($" WHEN NOT MATCHED THEN ")
            sbSQL.Append($"INSERT(")
            _D010.Properties.Take(1).ForEach(Sub(p) sbSQL.Append($" {p.Name}"))
            _D010.Properties.Skip(1).ForEach(Sub(p) sbSQL.Append($",{p.Name}"))
            sbSQL.Append($" ) VALUES(")
            _D010.Properties.Take(1).ForEach(Sub(p) sbSQL.Append($" WK.{p.Name}"))
            _D010.Properties.Skip(1).ForEach(Sub(p) sbSQL.Append($",WK.{p.Name}"))
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
        Next

        WL.WriteLogDat($"[DEBUG]FCCB �񍐏�NO:{_D010.FCCB_NO}�AMERGE D010")

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
            _D004_SYONIN_J_KANRI.SYONIN_HOKOKUSYO_ID = Context.ENM_SYONIN_HOKOKUSYO_ID._4_FCCB
            _D004_SYONIN_J_KANRI.HOKOKU_NO = _D009_FCCB_J.FCCB_NO
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
                    _D004_SYONIN_J_KANRI.SYAIN_ID = cmbDestTANTO.SelectedValue
                    _D004_SYONIN_J_KANRI.SYONIN_YMDHNS = ""
                    _D004_SYONIN_J_KANRI.MAIL_SEND_FG = False
                    _D004_SYONIN_J_KANRI.SYONIN_HANTEI_KB = ENM_SYONIN_HANTEI_KB._0_�����F
                    _D004_SYONIN_J_KANRI.ADD_YMDHNS = strSysDate
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
                    If _D004_SYONIN_J_KANRI.SYONIN_HANTEI_KB = ENM_SYONIN_HANTEI_KB._0_�����F Then
                        '���F�˗����[�����M
                        If FunSendRequestMail() Then
                            WL.WriteLogDat($"[DEBUG]FCCB �񍐏�NO:{_D009_FCCB_J.FCCB_NO}�ASend Request Mail")
                        End If
                    End If

                Case "UPDATE"

                Case Else
                    '-----�G���[���O�o��
                    Dim strErrMsg As String = My.Resources.ErrLogSqlExecutionFailure & sbSQL.ToString & "|" & sqlEx.Message
                    WL.WriteLogDat(strErrMsg)
                    Return False
            End Select

            WL.WriteLogDat($"[DEBUG]FCCB �񍐏�NO:{_D009_FCCB_J.FCCB_NO}�AMERGE D004")

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
    Private Function FunSendRequestMail()
        Dim KISYU_NAME As String = _D009_FCCB_J.KISYU_ID
        Dim SYONIN_HANTEI_NAME As String = tblSYONIN_HANTEI_KB.LazyLoad("���F����敪").AsEnumerable.Where(Function(r) r.Field(Of String)("VALUE") = _D004_SYONIN_J_KANRI.SYONIN_HANTEI_KB).FirstOrDefault?.Item("DISP")
        Dim strEXEParam As String = _D004_SYONIN_J_KANRI.SYAIN_ID & "," & ENM_OPEN_MODE._2_���u��ʋN�� & "," & Context.ENM_SYONIN_HOKOKUSYO_ID._2_CAR & "," & _D004_SYONIN_J_KANRI.HOKOKU_NO
        Dim strSubject As String = $"�y�s�K���i���u�˗��z[CTS] {KISYU_NAME}"
        Dim strBody As String = <sql><![CDATA[
        {0} �a<br />
        <br />
        �@FCCB�������̏��u�˗������܂����̂őΉ������肢���܂��B<br />
        <br />
        �@�@�y�� �� ���zFCCB<br />
        �@�@�y�񍐏�No�z{1}<br />
        �@�@�y�N �� ���z{2}<br />
        �@�@�y�@�@  ��z{3}<br />
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
                                CDate(_D009_FCCB_J.ADD_YMDHNS).ToString("yyyy/MM/dd"),
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

#Region "SAVE R001"

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
        _R001_HOKOKU_SOUSA.HOKOKU_NO = _D009_FCCB_J.FCCB_NO
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

        WL.WriteLogDat($"[DEBUG]CTS �񍐏�NO:{_D009_FCCB_J.FCCB_NO}�AINSERT R001")

        'If FunSAVE_R005(DB, _R001_HOKOKU_SOUSA.ADD_YMDHNS) Then
        'Else
        '    Return False
        'End If

        'If FunSAVE_R006(DB, _R001_HOKOKU_SOUSA.ADD_YMDHNS) Then
        'Else
        '    Return False
        'End If

        Return True
    End Function

#End Region

#Region "SAVE R005"

    Private Function FunSAVE_R005(ByRef DB As ClsDbUtility, ByVal strYMDHNS As String) As Boolean
        Dim sbSQL As New System.Text.StringBuilder
        Dim intRET As Integer
        Dim sqlEx As New Exception

        sbSQL.Append($"INSERT INTO {NameOf(R005_FCR_SASIMODOSI)}(")
        'sbSQL.Append($" {NameOf(_R005.SASIMODOSI_YMDHNS)}")
        'sbSQL.Append($",{NameOf(_R005.HOKOKU_NO)}")
        'sbSQL.Append($",{NameOf(_R005.CLOSE_FG)}")
        'sbSQL.Append($",{NameOf(_R005.KOKYAKU_EIKYO_HANTEI_KB)}")
        'sbSQL.Append($",{NameOf(_R005.TAISYOU_KOKYAKU)}")
        'sbSQL.Append($",{NameOf(_R005.KOKYAKU_EIKYO_HANTEI_COMMENT)}")
        'sbSQL.Append($",{NameOf(_R005.KOKYAKU_EIKYO_NAIYO)}")
        'sbSQL.Append($",{NameOf(_R005.KAKUNIN_SYUDAN)}")
        'sbSQL.Append($",{NameOf(_R005.KOKYAKU_EIKYO_TUCHI_HANTEI_KB)}")
        'sbSQL.Append($",{NameOf(_R005.TUCHI_YMD)}")
        'sbSQL.Append($",{NameOf(_R005.TUCHI_SYUDAN)}")
        'sbSQL.Append($",{NameOf(_R005.HITUYO_TETUDUKI_ZIKO)}")
        'sbSQL.Append($",{NameOf(_R005.KOKYAKU_EIKYO_ETC_COMMENT)}")
        'sbSQL.Append($",{NameOf(_R005.OTHER_PROCESS_INFLUENCE_KB)}")
        'sbSQL.Append($",{NameOf(_R005.FOLLOW_PROCESS_OUTFLOW_KB)}")
        'sbSQL.Append($",{NameOf(_R005.KOKYAKU_NOUNYU_NAIYOU)}")
        'sbSQL.Append($",{NameOf(_R005.KOKYAKU_NOUNYU_YMD)}")
        'sbSQL.Append($",{NameOf(_R005.ZAIKO_SIKAKE_NAIYOU)}")
        'sbSQL.Append($",{NameOf(_R005.ZAIKO_SIKAKE_YMD)}")
        'sbSQL.Append($",{NameOf(_R005.OTHER_PROCESS_NAIYOU)}")
        'sbSQL.Append($",{NameOf(_R005.OTHER_PROCESS_YMD)}")

        'sbSQL.Append($",{NameOf(_R005.KOKYAKU_EIKYO_HANTEI_FILEPATH)}")
        'sbSQL.Append($",{NameOf(_R005.FUTEKIGO_SEIHIN_MEMO)}")
        'sbSQL.Append($",{NameOf(_R005.KOKYAKU_EIKYO_MEMO)}")
        'sbSQL.Append($",{NameOf(_R005.OTHER_PROCESS_INFLUENCE_MEMO)}")
        'sbSQL.Append($",{NameOf(_R005.OTHER_PROCESS_INFLUENCE_FILEPATH)}")
        'sbSQL.Append($",{NameOf(_R005.FOLLOW_PROCESS_OUTFLOW_MEMO)}")
        'sbSQL.Append($",{NameOf(_R005.FOLLOW_PROCESS_OUTFLOW_FILEPATH)}")
        'sbSQL.Append($",{NameOf(_R005.FUTEKIGO_SEIHIN_FILEPATH)}")
        'sbSQL.Append($",{NameOf(_R005.KOKYAKU_EIKYO_FILEPATH)}")
        'sbSQL.Append($",{NameOf(_R005.SYOCHI_MEMO)}")
        'sbSQL.Append($",{NameOf(_R005.SYOCHI_FILEPATH)}")

        'sbSQL.Append($" ) VALUES(")
        'sbSQL.Append($" '{strYMDHNS}'")
        'sbSQL.Append($",'{_D007.HOKOKU_NO}'")
        'sbSQL.Append($",'{If(_D007.CLOSE_FG, "1", "0")}'")
        'sbSQL.Append($",'{If(_D007.KOKYAKU_EIKYO_HANTEI_KB, "1", "0")}'")
        'sbSQL.Append($",'{_D007.TAISYOU_KOKYAKU.ConvertSqlEscape}'")
        'sbSQL.Append($",'{_D007.KOKYAKU_EIKYO_HANTEI_COMMENT.ConvertSqlEscape}'")
        'sbSQL.Append($",'{_D007.KOKYAKU_EIKYO_NAIYO.ConvertSqlEscape}'")
        'sbSQL.Append($",'{_D007.KAKUNIN_SYUDAN}'")
        'sbSQL.Append($",'{If(_D007.KOKYAKU_EIKYO_TUCHI_HANTEI_KB, "1", "0")}'")
        'sbSQL.Append($",'{_D007.TUCHI_YMD}'")
        'sbSQL.Append($",'{_D007.TUCHI_SYUDAN.ConvertSqlEscape}'")
        'sbSQL.Append($",'{_D007.HITUYO_TETUDUKI_ZIKO.ConvertSqlEscape}'")
        'sbSQL.Append($",'{_D007.KOKYAKU_EIKYO_ETC_COMMENT.ConvertSqlEscape}'")
        'sbSQL.Append($",'{If(_D007.OTHER_PROCESS_INFLUENCE_KB, "1", "0")}'")
        'sbSQL.Append($",'{If(_D007.FOLLOW_PROCESS_OUTFLOW_KB, "1", "0")}'")
        'sbSQL.Append($",'{_D007.KOKYAKU_NOUNYU_NAIYOU.ConvertSqlEscape}'")
        'sbSQL.Append($",'{_D007.KOKYAKU_NOUNYU_YMD}'")
        'sbSQL.Append($",'{_D007.ZAIKO_SIKAKE_NAIYOU.ConvertSqlEscape}'")
        'sbSQL.Append($",'{_D007.ZAIKO_SIKAKE_YMD}'")
        'sbSQL.Append($",'{_D007.OTHER_PROCESS_NAIYOU.ConvertSqlEscape}'")
        'sbSQL.Append($",'{_D007.OTHER_PROCESS_YMD}'")

        'sbSQL.Append($",'{_D007.KOKYAKU_EIKYO_HANTEI_FILEPATH.ConvertSqlEscape}'")
        'sbSQL.Append($",'{_D007.FUTEKIGO_SEIHIN_MEMO.ConvertSqlEscape}'")
        'sbSQL.Append($",'{_D007.KOKYAKU_EIKYO_MEMO.ConvertSqlEscape}'")
        'sbSQL.Append($",'{_D007.OTHER_PROCESS_INFLUENCE_MEMO.ConvertSqlEscape}'")
        'sbSQL.Append($",'{_D007.OTHER_PROCESS_INFLUENCE_FILEPATH.ConvertSqlEscape}'")
        'sbSQL.Append($",'{_D007.FOLLOW_PROCESS_OUTFLOW_MEMO.ConvertSqlEscape}'")
        'sbSQL.Append($",'{_D007.FOLLOW_PROCESS_OUTFLOW_FILEPATH.ConvertSqlEscape}'")
        'sbSQL.Append($",'{_D007.FUTEKIGO_SEIHIN_FILEPATH.ConvertSqlEscape}'")
        'sbSQL.Append($",'{_D007.KOKYAKU_EIKYO_FILEPATH.ConvertSqlEscape}'")
        'sbSQL.Append($",'{_D007.SYOCHI_MEMO.ConvertSqlEscape}'")
        'sbSQL.Append($",'{_D007.SYOCHI_FILEPATH.ConvertSqlEscape}'")

        sbSQL.Append(" );")
        intRET = DB.ExecuteNonQuery(sbSQL.ToString, conblnNonMsg, sqlEx)
        If intRET <> 1 Then
            '-----�G���[���O�o��
            Dim strErrMsg As String = My.Resources.ErrLogSqlExecutionFailure & sbSQL.ToString & "|" & sqlEx.Message
            WL.WriteLogDat(strErrMsg)
            Return False
        Else
            WL.WriteLogDat($"[DEBUG]CTS �񍐏�NO:{_D009_FCCB_J.FCCB_NO}�AINSERT R005")
            Return True
        End If
    End Function

#End Region

#Region "SAVE R006"

    Private Function FunSAVE_R006(ByRef DB As ClsDbUtility, strYMDHNS As String) As Boolean
        Dim sbSQL As New System.Text.StringBuilder
        Dim strRET As String
        Dim sqlEx As New Exception

        Dim _R006 As New R006_FCR_J_SUB_SASIMODOSI

        For i As Integer = 1 To 6

#Region "   ���f���X�V"

            If _D009_FCCB_J.Item("KISYU_ID" & i) > 0 Then
                _R006.Clear()
                _R006.SASIMODOSI_YMDHNS = strYMDHNS
                _R006.HOKOKU_NO = _D009_FCCB_J.FCCB_NO
                _R006.ROW_NO = i
                _R006.KISYU_ID = _D009_FCCB_J.Item("KISYU_ID" & i)
                _R006.BUHIN_INFO = _D009_FCCB_J.Item("BUHIN_INFO" & i)
                _R006.SURYO = _D009_FCCB_J.Item("SURYO" & i)
                _R006.RANGE_FROM = _D009_FCCB_J.Item("RANGE_FROM" & i)
                _R006.RANGE_TO = _D009_FCCB_J.Item("RANGE_TO" & i)
            End If

#End Region

            '-----MERGE
            sbSQL.Remove(0, sbSQL.Length)
            sbSQL.Append($"MERGE INTO {NameOf(R006_FCR_J_SUB_SASIMODOSI)} AS SrcT")
            sbSQL.Append($" USING (")
            sbSQL.Append($"{_R006.ToSelectSqlString}")
            sbSQL.Append($" ) AS WK")
            sbSQL.Append($" ON (SrcT.{NameOf(_R006.HOKOKU_NO)} = WK.{NameOf(_R006.HOKOKU_NO)}")
            sbSQL.Append($" AND SrcT.{NameOf(_R006.ROW_NO)} = WK.{NameOf(_R006.ROW_NO)}")
            sbSQL.Append($" AND SrcT.{NameOf(_R006.SASIMODOSI_YMDHNS)} = WK.{NameOf(_R006.SASIMODOSI_YMDHNS)})")
            'INSERT
            sbSQL.Append($" WHEN NOT MATCHED THEN ")
            sbSQL.Append($"INSERT(")
            _R006.Properties.Take(1).ForEach(Sub(p) sbSQL.Append($" {p.Name}"))
            _R006.Properties.Skip(1).ForEach(Sub(p) sbSQL.Append($",{p.Name}"))
            sbSQL.Append($" ) VALUES(")
            _R006.Properties.Take(1).ForEach(Sub(p) sbSQL.Append($" WK.{p.Name}"))
            _R006.Properties.Skip(1).ForEach(Sub(p) sbSQL.Append($",WK.{p.Name}"))
            sbSQL.Append($" ) ")
            sbSQL.Append($"OUTPUT $action AS RESULT;")
            strRET = DB.ExecuteScalar(sbSQL.ToString, conblnNonMsg, sqlEx)
            Select Case strRET
                Case "INSERT"

                Case "UPDATE"

                Case Else

                    If sqlEx.Source IsNot Nothing Then
                        '-----�G���[���O�o��
                        Dim strErrMsg As String = My.Resources.ErrLogSqlExecutionFailure & sbSQL.ToString & "|" & sqlEx.Message
                        WL.WriteLogDat(strErrMsg)
                        Return False
                    End If
            End Select
        Next

        WL.WriteLogDat($"[DEBUG]CTS �񍐏�NO:{_R006.HOKOKU_NO}�AMERGE R006")

        Return True
    End Function

#End Region

#End Region

#Region "�]��"

    Private Function OpenFormTENSO() As Boolean
        Dim frmDLG As New FrmG0025_Tenso
        Dim dlgRET As DialogResult

        Try
            frmDLG.PrSYONIN_HOKOKUSYO_ID = Context.ENM_SYONIN_HOKOKUSYO_ID._4_FCCB
            frmDLG.PrHOKOKU_NO = PrFCCB_NO
            frmDLG.PrBUMON_KB = _V002_NCR_J.BUMON_KB
            frmDLG.PrBUHIN_BANGO = _V002_NCR_J.BUHIN_BANGO
            frmDLG.PrKISO_YMD = DateTime.ParseExact(_V002_NCR_J.ADD_YMD, "yyyyMMdd", Nothing).ToString("yyyy/MM/dd")
            frmDLG.PrKISYU_NAME = tblKISYU.LazyLoad("�@��").AsEnumerable.Where(Function(r) r.Field(Of Integer)("VALUE") = _V002_NCR_J.KISYU_ID).FirstOrDefault?.Item("DISP")
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
        Dim frmDLG As New FrmG0026_Sasimodosi
        Dim dlgRET As DialogResult

        Try
            frmDLG.PrSYONIN_HOKOKUSYO_ID = Context.ENM_SYONIN_HOKOKUSYO_ID._4_FCCB
            frmDLG.PrHOKOKU_NO = PrFCCB_NO
            frmDLG.PrBUHIN_BANGO = _V002_NCR_J.BUHIN_BANGO
            frmDLG.PrKISO_YMD = DateTime.ParseExact(_V002_NCR_J.ADD_YMD, "yyyyMMdd", Nothing).ToString("yyyy/MM/dd")
            frmDLG.PrKISYU_NAME = tblKISYU.LazyLoad("�@��").AsEnumerable.Where(Function(r) r.Field(Of Integer)("VALUE") = _V002_NCR_J.KISYU_ID).FirstOrDefault?.Item("DISP")
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
            strOutputFileName = "CTS_" & _D009_FCCB_J.FCCB_NO & "_Work.xls"

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
            'If FunMakeReportFCCB(pub_APP_INFO.strOUTPUT_PATH & strOutputFileName, _D009_FCCB_J.HOKOKU_NO) = False Then
            '    Return False
            'End If

            'Excel�N��
            'Return FunOpenExcelApp(pub_APP_INFO.strOUTPUT_PATH & strOutputFileName)
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
        Dim frmDLG As New FrmG0022_Rireki
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
        Dim frmDLG As New FrmG0024_EditComment
        Dim dlgRET As DialogResult

        Try
            frmDLG.PrSYONIN_HOKOKUSYO_ID = Context.ENM_SYONIN_HOKOKUSYO_ID._1_NCR
            frmDLG.PrHOKOKU_NO = _D009_FCCB_J.FCCB_NO
            frmDLG.PrBUMON_KB = _D009_FCCB_J.BUMON_KB
            frmDLG.PrBUHIN_BANGO = _D009_FCCB_J.BUHIN_BANGO
            frmDLG.PrKISO_YMD = DateTime.ParseExact(_D009_FCCB_J.ADD_YMD, "yyyyMMdd", Nothing).ToString("yyyy/MM/dd")
            frmDLG.PrKISYU_NAME = tblKISYU.LazyLoad("�@��").AsEnumerable.Where(Function(r) r.Field(Of Integer)("VALUE") = _D009_FCCB_J.KISYU_ID).FirstOrDefault?.Item("DISP")
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

            If FunblnOwnCreated(Context.ENM_SYONIN_HOKOKUSYO_ID._4_FCCB, PrFCCB_NO, PrCurrentStage) Then '
                cmdFunc1.Enabled = True
                cmdFunc4.Enabled = True
                cmdFunc5.Enabled = True

                'SPEC: C10-3
                If PrCurrentStage = ENM_FCCB_STAGE._10_�N������ Then
                    cmdFunc5.Enabled = False
                    MyBase.ToolTip.SetToolTip(Me.cmdFunc5, "�N�����͂ō��ߓo�^�͎g�p�o���܂���")
                Else
                    cmdFunc5.Enabled = True
                    MyBase.ToolTip.SetToolTip(Me.cmdFunc5, My.Resources.infoToolTipMsgNotFoundData)
                End If
            Else
                '�J�����g�X�e�[�W�����g�̒S���łȂ��ꍇ�͖���
                cmdFunc1.Enabled = False
                cmdFunc4.Enabled = False
                cmdFunc5.Enabled = False

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
                cmdFunc9.Enabled = True
                MyBase.ToolTip.SetToolTip(Me.cmdFunc9, My.Resources.infoToolTipMsgNotFoundData)
            Else
                cmdFunc3.Enabled = False
                MyBase.ToolTip.SetToolTip(Me.cmdFunc3, "����NCR��ʂ���Ăяo����Ă��邽�ߎg�p�o���܂���")
                cmdFunc9.Enabled = False
                MyBase.ToolTip.SetToolTip(Me.cmdFunc9, "����CAR��ʂ���Ăяo����Ă��邽�ߎg�p�o���܂���")
            End If

            Select Case PrCurrentStage
                Case ENM_FCCB_STAGE._61_���u���������m�F_����
                    cmdFunc2.Text = "���F(F2)"
                Case ENM_FCCB_STAGE._999_Closed

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

#Region "�R���g���[���C�x���g"

#Region "�\����Ј�"

    Private Sub CmbDestTANTO_Validating(sender As Object, e As System.ComponentModel.CancelEventArgs)

    End Sub

#End Region

#Region "�w�b�_"

    Private Sub RsbtnST_CheckedChanged(sender As Object, e As EventArgs)

        Dim btn As RibbonShapeRadioButton = DirectCast(sender, RibbonShapeRadioButton)
        Dim intStageID As Integer = Val(btn.Name.Substring(7))
        'tabSTAGE01.AutoScrollControlIntoView = True
        'Select Case intStageID
        '    Case ENM_CAR_STAGE2._1_�N������ To ENM_CAR_STAGE2._7_�N���m�F_�i�؉ے�
        '        tabSTAGE01.ScrollControlIntoView(lblSETUMON_1)

        '        pnlFCR.BorderStyle = BorderStyle.FixedSingle
        '        pnlSYOCHI_KIROKU.BorderStyle = BorderStyle.None
        '        pnlZESEI_SYOCHI.BorderStyle = BorderStyle.None
        '        pnlSYOCHI_JISSI.BorderStyle = BorderStyle.None

        '    Case ENM_CAR_STAGE2._8_���u���{�L�^����, ENM_CAR_STAGE2._9_���u���{�m�F
        '        tabSTAGE01.ScrollControlIntoView(lblSYOCHI_KIROKUFlame)

        '        pnlFCR.BorderStyle = BorderStyle.None
        '        pnlSYOCHI_KIROKU.BorderStyle = BorderStyle.FixedSingle
        '        pnlZESEI_SYOCHI.BorderStyle = BorderStyle.None
        '        pnlSYOCHI_JISSI.BorderStyle = BorderStyle.None

        '    Case ENM_CAR_STAGE2._10_�����L�����L�� To ENM_CAR_STAGE2._12_�����L�����m�F_�i��TL
        '        tabSTAGE01.ScrollControlIntoView(lblZESEI_SYOCHIFlame)

        '        pnlFCR.BorderStyle = BorderStyle.None
        '        pnlSYOCHI_KIROKU.BorderStyle = BorderStyle.None
        '        pnlZESEI_SYOCHI.BorderStyle = BorderStyle.FixedSingle
        '        pnlSYOCHI_JISSI.BorderStyle = BorderStyle.None

        '    Case ENM_CAR_STAGE2._13_�����L�����m�F_�i�ؒS���ے�
        '        tabSTAGE01.ScrollControlIntoView(lblSTAGEFlame13)
        '        pnlFCR.BorderStyle = BorderStyle.None
        '        pnlSYOCHI_KIROKU.BorderStyle = BorderStyle.None
        '        pnlZESEI_SYOCHI.BorderStyle = BorderStyle.None
        '        pnlSYOCHI_JISSI.BorderStyle = BorderStyle.FixedSingle

        'End Select
        'tabSTAGE01.AutoScrollControlIntoView = False

    End Sub

    Private Sub tabSTAGE01_Click(sender As Object, e As EventArgs) Handles TabPageEx1.Click
        sender.Focus
    End Sub

#End Region

#Region "SUB_DATA"

    Private Sub CmbKISYU1_Validated(sender As Object, e As EventArgs)
        Dim cmb = DirectCast(sender, ComboboxEx)
        'If cmb.SelectedValue <> 0 Then
        '    pnlInfo2.Enabled = True
        'Else
        '    pnlInfo2.Enabled = False
        '    cmbKISYU2.SelectedIndex = 0
        '    txtBUHIN_INFO2.Text = ""
        '    nupSURYO2.Value = 0
        '    txtFROM2.Text = ""
        '    txtTO2.Text = ""
        'End If
    End Sub

    Private Sub CmbKISYU_SelectedValueChanged(sender As Object, e As EventArgs)
        Dim cmb = DirectCast(sender, ComboboxEx)
        Dim idx As Integer = cmb.Name.Substring(cmb.Name.Length - 1).ToVal
        If cmb.IsSelected Then
            _D009_FCCB_J.Item($"KISYU_ID{idx}") = cmb.SelectedValue.ToString.ToVal
        Else
            _D009_FCCB_J.Item($"KISYU_ID{idx}") = 0
        End If
    End Sub

    Private Sub TxtBUHIN_INFO_Validated(sender As Object, e As EventArgs)
        Dim txt = DirectCast(sender, TextBoxEx)
        Dim idx As Integer = txt.Name.Substring(txt.Name.Length - 1).ToVal
        If Not txt.Text.IsNulOrWS Then
            _D009_FCCB_J.Item($"BUHIN_INFO{idx}") = txt.Text
        Else
            _D009_FCCB_J.Item($"BUHIN_INFO{idx}") = ""
        End If
    End Sub

    Private Sub TxtFROM_Validated(sender As Object, e As EventArgs)
        Dim txt = DirectCast(sender, TextBoxEx)
        Dim idx As Integer = txt.Name.Substring(txt.Name.Length - 1).ToVal
        If Not txt.Text.IsNulOrWS Then
            _D009_FCCB_J.Item($"RANGE_FROM{idx}") = txt.Text
        Else
            _D009_FCCB_J.Item($"RANGE_FROM{idx}") = ""
        End If
    End Sub

    Private Sub TxtTO_Validated(sender As Object, e As EventArgs)
        Dim txt = DirectCast(sender, TextBoxEx)
        Dim idx As Integer = txt.Name.Substring(txt.Name.Length - 1).ToVal
        If Not txt.Text.IsNulOrWS Then
            _D009_FCCB_J.Item($"RANGE_TO{idx}") = txt.Text
        Else
            _D009_FCCB_J.Item($"RANGE_TO{idx}") = ""
        End If
    End Sub

    Private Sub NupSURYO_ValueChanged(sender As Object, e As EventArgs)
        Dim nup = DirectCast(sender, NumericUpDown)
        Dim idx As Integer = nup.Name.Substring(nup.Name.Length - 1).ToVal
        _D009_FCCB_J.Item($"SURYO{idx}") = CInt(nup.Value)
    End Sub

#End Region

    Private Sub RbtnOTHER_PROCESS_INFLUENCE_KB_CheckedChanged(sender As Object, e As EventArgs)
        'Dim blnChecked As Boolean = rbtnOTHER_PROCESS_INFLUENCE_KB_T.Checked

        'txtOTHER_PROCESS_INFLUENCE_MEMO.Enabled = blnChecked
        'pnlOTHER_PROCESS_INFLUENCE_FILEPATH.Enabled = blnChecked

        'If Not blnChecked And Not IsInitializing Then
        '    txtOTHER_PROCESS_INFLUENCE_MEMO.Text = ""
        '    _D009_FCCB_J.OTHER_PROCESS_INFLUENCE_FILEPATH = ""
        '    lblOTHER_PROCESS_INFLUENCE_FILEPATH.Visible = False
        '    lblOTHER_PROCESS_INFLUENCE_FILEPATH_Clear.Visible = False
        'End If

        ''#256
        'lblOTHER_PROCESS_NAIYOU.Enabled = Not (rbtnFOLLOW_PROCESS_OUTFLOW_KB_F.Checked And rbtnOTHER_PROCESS_INFLUENCE_KB_F.Checked)
        'txtOTHER_PROCESS_NAIYOU.Enabled = Not (rbtnFOLLOW_PROCESS_OUTFLOW_KB_F.Checked And rbtnOTHER_PROCESS_INFLUENCE_KB_F.Checked)
        'dtOTHER_PROCESS_YMD.Enabled = Not (rbtnFOLLOW_PROCESS_OUTFLOW_KB_F.Checked And rbtnOTHER_PROCESS_INFLUENCE_KB_F.Checked)
        'If (rbtnFOLLOW_PROCESS_OUTFLOW_KB_F.Checked And rbtnOTHER_PROCESS_INFLUENCE_KB_F.Checked) Then
        '    txtOTHER_PROCESS_NAIYOU.Text = ""
        '    dtOTHER_PROCESS_YMD.Text = ""
        'End If
    End Sub

    Private Sub RbtnFOLLOW_PROCESS_OUTFLOW_KB_CheckedChanged(sender As Object, e As EventArgs)
        'Dim blnChecked As Boolean = rbtnFOLLOW_PROCESS_OUTFLOW_KB_T.Checked

        'txtFOLLOW_PROCESS_OUTFLOW_MEMO.Enabled = blnChecked
        'pnlFOLLOW_PROCESS_OUTFLOW_FILEPATH.Enabled = blnChecked

        'If Not blnChecked And Not IsInitializing Then
        '    txtFOLLOW_PROCESS_OUTFLOW_MEMO.Text = ""
        '    _D009_FCCB_J.FOLLOW_PROCESS_OUTFLOW_FILEPATH = ""
        '    lblFOLLOW_PROCESS_OUTFLOW_FILEPATH.Visible = False
        '    lblFOLLOW_PROCESS_OUTFLOW_FILEPATH_Clear.Visible = False
        'End If

        ''#256
        'lblOTHER_PROCESS_NAIYOU.Enabled = Not (rbtnFOLLOW_PROCESS_OUTFLOW_KB_F.Checked And rbtnOTHER_PROCESS_INFLUENCE_KB_F.Checked)
        'txtOTHER_PROCESS_NAIYOU.Enabled = Not (rbtnFOLLOW_PROCESS_OUTFLOW_KB_F.Checked And rbtnOTHER_PROCESS_INFLUENCE_KB_F.Checked)
        'dtOTHER_PROCESS_YMD.Enabled = Not (rbtnFOLLOW_PROCESS_OUTFLOW_KB_F.Checked And rbtnOTHER_PROCESS_INFLUENCE_KB_F.Checked)
        'If (rbtnFOLLOW_PROCESS_OUTFLOW_KB_F.Checked And rbtnOTHER_PROCESS_INFLUENCE_KB_F.Checked) Then
        '    txtOTHER_PROCESS_NAIYOU.Text = ""
        '    dtOTHER_PROCESS_YMD.Text = ""
        'End If
    End Sub

    ''' <summary>
    ''' 2.�s�K�����i�͈� �R�����g
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    Private Sub TxtFUTEKIGO_SEIHIN_MEMO_Validated(sender As Object, e As EventArgs)
        Dim txt = DirectCast(sender, TextBoxEx)
        Dim blnEnabled As Boolean = (txt.Text.Length = 0)

        'pnlFUTEKIGO_SEIHIN_FILEPATH.Enabled = blnEnabled
        'pnlInfo1.Enabled = blnEnabled
        'Call CmbKISYU1_Validated(cmbKISYU1, Nothing)
        'pnlInfo2.Enabled = blnEnabled
        'Call CmbKISYU2_Validated(cmbKISYU2, Nothing)
        'pnlInfo3.Enabled = blnEnabled

    End Sub

    ''' <summary>
    ''' 3.�ڋq�e���͈� �R�����g
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    Private Sub TxtKOKYAKU_EIKYO_MEMO_Validated(sender As Object, e As EventArgs)
        Dim txt = DirectCast(sender, TextBoxEx)
        Dim blnEnabled As Boolean = (txt.Text.Length = 0)

        'pnlKOKYAKU_EIKYO_FILEPATH.Enabled = blnEnabled
        'pnlInfo4.Enabled = blnEnabled
        'Call CmbKISYU4_Validated(cmbKISYU4, Nothing)
        'pnlInfo5.Enabled = blnEnabled
        'Call CmbKISYU5_Validated(cmbKISYU5, Nothing)
        'pnlInfo6.Enabled = blnEnabled
    End Sub

#End Region

#Region "���[�J���֐�"

#Region "�������[�h�ʉ�ʏ�����"

    Private Function FunInitializeControls(intMODE As ENM_DATA_OPERATION_MODE) As Boolean

        Try
            Dim dt As DataTable

            IsInitializing = True
            '�i�r�Q�[�g�����N�I��
            If PrCurrentStage = ENM_FCCB_STAGE._999_Closed Then
                rsbtnST99.Checked = True
            Else
                Dim rbtn As RibbonShapeRadioButton = DirectCast(flpnlStageIndex.Controls("rsbtnST" & (PrCurrentStage / 10).ToString("00")), RibbonShapeRadioButton)
                rbtn.Checked = True
            End If

            Call SetTANTO_TooltipInfo()

            '-----�R���g���[���f�[�^�\�[�X�ݒ�
            'Dim dt As DataTable
            'dt = FunGetSYONIN_SYOZOKU_SYAIN(_D009_FCCB_J.BUMON_KB, Context.ENM_SYONIN_HOKOKUSYO_ID._4_FCCB.Value, FunGetNextSYONIN_JUN(ENM_FCCB_STAGE._10_�N������))
            'cmbKISO_TANTO.SetDataSource(dt.ExcludeDeleted, ENM_COMBO_SELECT_VALUE_TYPE._0_Required)
            'dt = GetCM_TANTO(cmbBUMON.SelectedValue)
            'cmbCM_TANTO.SetDataSource(tblTANTO.ExcludeDeleted, ENM_COMBO_SELECT_VALUE_TYPE._0_Required)

            'UNDONE: �Ɩ��O���[�v���X�g�\�[�X�擾�֐���
            Dim dtMap As New Hashtable
            dtMap.Add(ENM_GYOMU_GROUP_ID._1_�Z�p.Value, "�Z�p")
            dtMap.Add(ENM_GYOMU_GROUP_ID._2_����.Value, "����")
            dtMap.Add(ENM_GYOMU_GROUP_ID._3_����.Value, "����")
            dtMap.Add(ENM_GYOMU_GROUP_ID._4_�i��.Value, "�i��")
            dtMap.Add(ENM_GYOMU_GROUP_ID._5_�݌v.Value, "�݌v")
            dtMap.Add(ENM_GYOMU_GROUP_ID._6_���Z.Value, "���Z")
            dtMap.Add(ENM_GYOMU_GROUP_ID._7_�Ǘ�.Value, "�Ǘ�")
            dtMap.Add(ENM_GYOMU_GROUP_ID._8_�c��.Value, "�c��")
            dtMap.Add(ENM_GYOMU_GROUP_ID._9_�w��.Value, "�w��")
            dtMap.Add(ENM_GYOMU_GROUP_ID._46_�i��.Value, "�i/��")
            flxDATA_2.Cols(5).DataMap = dtMap


            Dim dtMapTANTO As New Hashtable
            dtMapTANTO.Add(0, "")
            dtMapTANTO.Add(999999, "SYSTEM_USER")
            flxDATA_2.Cols(7).DataMap = dtMapTANTO

#Region "flexStyle"
            flxDATA_2.Styles.Normal.Border.Style = C1.Win.C1FlexGrid.BorderStyleEnum.Flat
            flxDATA_2.Styles.Normal.Border.Color = Color.Black

            flxDATA_3.Styles.Normal.Border.Style = C1.Win.C1FlexGrid.BorderStyleEnum.Flat
            flxDATA_3.Styles.Normal.Border.Color = Color.Black

            flxDATA_4.Styles.Normal.Border.Style = C1.Win.C1FlexGrid.BorderStyleEnum.Flat
            flxDATA_4.Styles.Normal.Border.Color = Color.Black

            flxDATA_5.Styles.Normal.Border.Style = C1.Win.C1FlexGrid.BorderStyleEnum.Flat
            flxDATA_5.Styles.Normal.Border.Color = Color.Black

#End Region




            Select Case intMODE
                Case ENM_DATA_OPERATION_MODE._1_ADD
                    mtxFCCB_NO.Text = "<�V�K>"
                    _D009_FCCB_J.ADD_SYAIN_ID = pub_SYAIN_INFO.SYAIN_ID
                    _D009_FCCB_J.ADD_YMDHNS = Now.ToString("yyyyMMddHHmmss")

                    If IsSysAdminUser(pub_SYAIN_INFO.SYAIN_ID) Then
                    Else
                        _D009_FCCB_J.BUMON_KB = pub_SYAIN_INFO.BUMON_KB
                    End If


#Region "InitDS"
                    Dim sbSQL As New System.Text.StringBuilder
                    Dim dsList As DataSet

                    sbSQL.Clear()
                    sbSQL.Append($"SELECT")
                    sbSQL.Append($" *")
                    sbSQL.Append($" ,'' AS {NameOf(D010_FCCB_SUB_SYOCHI_KOMOKU.FCCB_NO)}")
                    sbSQL.Append($" ,'0' AS {NameOf(D010_FCCB_SUB_SYOCHI_KOMOKU.YOHI_KB)}")
                    sbSQL.Append($" , 0 AS {NameOf(D010_FCCB_SUB_SYOCHI_KOMOKU.TANTO_ID)}")
                    sbSQL.Append($" ,'' AS {NameOf(D010_FCCB_SUB_SYOCHI_KOMOKU.NAIYO)}")
                    sbSQL.Append($" ,'' AS {NameOf(D010_FCCB_SUB_SYOCHI_KOMOKU.GOKI)}")
                    sbSQL.Append($" ,'' AS {NameOf(D010_FCCB_SUB_SYOCHI_KOMOKU.YOTEI_YMD)}")
                    sbSQL.Append($" ,'' AS {NameOf(D010_FCCB_SUB_SYOCHI_KOMOKU.CLOSE_YMD)}")
                    sbSQL.Append($" FROM {NameOf(M017_FCCB_SUB_SYOCHI_KOMOKU)} ")
                    sbSQL.Append($" WHERE {NameOf(M017_FCCB_SUB_SYOCHI_KOMOKU.ITEM_NO)}<100 ")

                    Using DB As ClsDbUtility = DBOpen()
                        dsList = DB.GetDataSet(sbSQL.ToString, conblnNonMsg)
                    End Using

                    Dim Sec2 As New ModelInfo(Of D010_FCCB_SUB_SYOCHI_KOMOKU)(srcDATA:=dsList.Tables(0))
                    Flx2_DS.DataSource = Sec2.Data

                    sbSQL.Clear()
                    sbSQL.Append($"SELECT")
                    sbSQL.Append($" *")
                    sbSQL.Append($" ,'' AS {NameOf(D010_FCCB_SUB_SYOCHI_KOMOKU.FCCB_NO)}")
                    sbSQL.Append($" ,'0' AS {NameOf(D010_FCCB_SUB_SYOCHI_KOMOKU.YOHI_KB)}")
                    sbSQL.Append($" , 0 AS {NameOf(D010_FCCB_SUB_SYOCHI_KOMOKU.TANTO_ID)}")
                    sbSQL.Append($" ,'' AS {NameOf(D010_FCCB_SUB_SYOCHI_KOMOKU.NAIYO)}")
                    sbSQL.Append($" ,'' AS {NameOf(D010_FCCB_SUB_SYOCHI_KOMOKU.GOKI)}")
                    sbSQL.Append($" ,'' AS {NameOf(D010_FCCB_SUB_SYOCHI_KOMOKU.YOTEI_YMD)}")
                    sbSQL.Append($" ,'' AS {NameOf(D010_FCCB_SUB_SYOCHI_KOMOKU.CLOSE_YMD)}")
                    sbSQL.Append($" FROM {NameOf(M017_FCCB_SUB_SYOCHI_KOMOKU)} ")
                    sbSQL.Append($" WHERE {NameOf(M017_FCCB_SUB_SYOCHI_KOMOKU.ITEM_NO)}>100 ")

                    Using DB As ClsDbUtility = DBOpen()
                        dsList = DB.GetDataSet(sbSQL.ToString, conblnNonMsg)
                    End Using

                    Dim Sec3 As New ModelInfo(Of D010_FCCB_SUB_SYOCHI_KOMOKU)(srcDATA:=dsList.Tables(0))
                    Flx3_DS.DataSource = Sec3.Data

                    sbSQL.Clear()
                    sbSQL.Append($"SELECT")
                    sbSQL.Append($"  '' AS {NameOf(D011_FCCB_SUB_SIKAKE_BUHIN.FCCB_NO)}")
                    sbSQL.Append($" , 0 AS {NameOf(D011_FCCB_SUB_SIKAKE_BUHIN.ITEM_NO)}")
                    sbSQL.Append($" ,'' AS {NameOf(D011_FCCB_SUB_SIKAKE_BUHIN.BUHIN_HINBAN)}")
                    sbSQL.Append($" ,'' AS {NameOf(D011_FCCB_SUB_SIKAKE_BUHIN.MEMO1)}")
                    sbSQL.Append($" ,'' AS {NameOf(D011_FCCB_SUB_SIKAKE_BUHIN.MEMO2)}")
                    sbSQL.Append($" , 0 AS {NameOf(D011_FCCB_SUB_SIKAKE_BUHIN.SURYO)}")
                    sbSQL.Append($" ,'' AS {NameOf(D011_FCCB_SUB_SIKAKE_BUHIN.SYOCHI_NAIYO)}")
                    sbSQL.Append($" , 0 AS {NameOf(D011_FCCB_SUB_SIKAKE_BUHIN.TANTO_GYOMU_GROUP_ID)}")
                    sbSQL.Append($" , 0 AS {NameOf(D011_FCCB_SUB_SIKAKE_BUHIN.TANTO_ID)}")
                    sbSQL.Append($" ,'' AS {NameOf(D011_FCCB_SUB_SIKAKE_BUHIN.YOTEI_YMD)}")
                    sbSQL.Append($" ,'' AS {NameOf(D011_FCCB_SUB_SIKAKE_BUHIN.CLOSE_YMD)}")
                    Using DB As ClsDbUtility = DBOpen()
                        dsList = DB.GetDataSet(sbSQL.ToString, conblnNonMsg)
                    End Using
                    Dim Sec4 As New ModelInfo(Of D011_FCCB_SUB_SIKAKE_BUHIN)(srcDATA:=dsList.Tables(0))

                    For i As Integer = 1 To 4
                        Dim dr As DataRow = Sec4.Data.NewRow
                        dr.ItemArray = Sec4.Data.Rows(0).ItemArray
                        dr.Item(NameOf(D011_FCCB_SUB_SIKAKE_BUHIN.ITEM_NO)) = i
                        Sec4.Data.Rows.Add(dr)
                    Next
                    Sec4.Data.Rows(0).Delete()
                    Sec4.Data.AcceptChanges()
                    Flx4_DS.DataSource = Sec4.Data

#End Region


                Case ENM_DATA_OPERATION_MODE._3_UPDATE

                    _V003_SYONIN_J_KANRI_List = FunGetV003Model(Context.ENM_SYONIN_HOKOKUSYO_ID._4_FCCB, PrFCCB_NO)
                    _D009_FCCB_J = FunGetD009Model(PrFCCB_NO)

                    '�f�[�^�\�[�X�ݒ�
                    dt = FunGetSYONIN_SYOZOKU_SYAIN(_D009_FCCB_J.BUMON_KB, Context.ENM_SYONIN_HOKOKUSYO_ID._4_FCCB, FunGetNextSYONIN_JUN(PrCurrentStage))
                    cmbDestTANTO.SetDataSource(dt, ENM_COMBO_SELECT_VALUE_TYPE._0_Required)

#Region "   �w�b�_"

                    'mtxHOKUKO_NO.Text = _D009_FCCB_J.HOKOKU_NO
                    'mtxBUMON_KB.Text = _D009_FCCB_J.BUMON_NAME
                    'mtxKISYU.Text = _D009_FCCB_J.KISYU_NAME
                    'mtxFUTEKIGO_KB.Text = _D009_FCCB_J.FUTEKIGO_NAME
                    'mtxFUTEKIGO_S_KB.Text = _D009_FCCB_J.FUTEKIGO_S_NAME
                    'mtxADD_SYAIN_NAME_NCR.Text = _D009_FCCB_J.ADD_SYAIN_NAME_NCR
                    'mtxADD_SYAIN_NAME.Text = _D009_FCCB_J.ADD_SYAIN_NAME
                    'dtFUTEKIGO_HASSEI_YMD.Value = _D009_FCCB_J.HASSEI_YMD

#End Region


                    dt = tblKISYU.LazyLoad("�@��").AsEnumerable.Where(Function(r) r.Field(Of String)(NameOf(_D009_FCCB_J.BUMON_KB)) = PrDataRow.Item("BUMON_KB")).CopyToDataTable
                    If _D009_FCCB_J.BUMON_KB = "2" Then 'LP
                        dt = dt.AsEnumerable.Where(Function(r) r.Item("DISP") = "LP").CopyToDataTable
                    End If


                    'txtFUTEKIGO_SEIHIN_MEMO.Text = _D009_FCCB_J.FUTEKIGO_SEIHIN_MEMO
                    'Call TxtFUTEKIGO_SEIHIN_MEMO_Validated(txtFUTEKIGO_SEIHIN_MEMO, Nothing)
                    'txtKOKYAKU_EIKYO_MEMO.Text = _D009_FCCB_J.KOKYAKU_EIKYO_MEMO
                    'Call TxtKOKYAKU_EIKYO_MEMO_Validated(txtKOKYAKU_EIKYO_MEMO, Nothing)

                    'If _D009_FCCB_J.FOLLOW_PROCESS_OUTFLOW_KB Then
                    '    targetCtrl = rbtnFOLLOW_PROCESS_OUTFLOW_KB_T
                    'Else
                    '    targetCtrl = rbtnFOLLOW_PROCESS_OUTFLOW_KB_F
                    'End If
                    'DirectCast(targetCtrl, RadioButton).Checked = True
                    'Call RbtnFOLLOW_PROCESS_OUTFLOW_KB_CheckedChanged(targetCtrl, Nothing)

                    'If _D009_FCCB_J.OTHER_PROCESS_INFLUENCE_KB Then
                    '    targetCtrl = rbtnOTHER_PROCESS_INFLUENCE_KB_T
                    'Else
                    '    targetCtrl = rbtnOTHER_PROCESS_INFLUENCE_KB_F
                    'End If
                    'DirectCast(targetCtrl, RadioButton).Checked = True
                    'Call RbtnOTHER_PROCESS_INFLUENCE_KB_CheckedChanged(targetCtrl, Nothing)
                    'txtOTHER_PROCESS_INFLUENCE_MEMO.Text = _D009_FCCB_J.OTHER_PROCESS_INFLUENCE_MEMO
                    'txtFOLLOW_PROCESS_OUTFLOW_MEMO.Text = _D009_FCCB_J.FOLLOW_PROCESS_OUTFLOW_MEMO

                    'txtOTHER_PROCESS_NAIYOU.Text = _D009_FCCB_J.OTHER_PROCESS_NAIYOU
                    'dtOTHER_PROCESS_YMD.Value = _D009_FCCB_J.OTHER_PROCESS_YMD

                    'mtxCurrentStageName.Text = FunGetLastStageName(Context.ENM_SYONIN_HOKOKUSYO_ID._3_CTS, _D009_FCCB_J.HOKOKU_NO)
                    'mtxNextStageName.Text = FunGetStageName(Context.ENM_SYONIN_HOKOKUSYO_ID._3_CTS, FunGetNextSYONIN_JUN(PrCurrentStage, _D009_FCCB_J.KOKYAKU_EIKYO_HANTEI_KB))
                    'Dim blnOwn As Boolean = FunblnOwnCreated(Context.ENM_SYONIN_HOKOKUSYO_ID._3_CTS, _D009_FCCB_J.HOKOKU_NO, PrCurrentStage)

                    '_tabPageManager = New TabPageManager(TabSTAGE)

                    'Select Case PrCurrentStage
                    '    Case ENM_CTS_STAGE._999_Closed
                    '        pnlFCR.DisableContaints(IsEditingClosed, PanelEx.ENM_PROPERTY._2_ReadOnly)
                    '        pnlSYOCHI_KIROKU.DisableContaints(IsEditingClosed, PanelEx.ENM_PROPERTY._2_ReadOnly)
                    '        pnlZESEI_SYOCHI.DisableContaints(IsEditingClosed, PanelEx.ENM_PROPERTY._2_ReadOnly)
                    '        PnlPROCESS.DisableContaints(IsEditingClosed, PanelEx.ENM_PROPERTY._2_ReadOnly)
                    '        pnlSYOCHI_JISSI.DisableContaints(IsEditingClosed, PanelEx.ENM_PROPERTY._2_ReadOnly)

                    '    Case Else
                    'End Select

                    ''��ʏ㕔�̃J�����g�X�e�[�W�J�ڃ{�^��
                    'For Each val As Integer In [Enum].GetValues(GetType(ENM_CTS_STAGE2))
                    '    flpnlStageIndex.Controls("rsbtnST" & val.ToString("00")).Enabled = (PrCurrentStage / 10) >= val
                    '    If (PrCurrentStage / 10) >= val Then
                    '    Else
                    '        flpnlStageIndex.Controls("rsbtnST" & val.ToString("00")).BackColor = Color.Silver
                    '    End If
                    'Next val
                    ''rsbtnST05.Enabled = CBool(_V005_CAR_J.KAITO_23)
                    'If _D009_FCCB_J.CLOSE_FG = False Then
                    '    flpnlStageIndex.Controls("rsbtnST99").Enabled = False
                    '    flpnlStageIndex.Controls("rsbtnST99").BackColor = Color.Silver
                    'End If

                    'Dim _V003 As New V003_SYONIN_J_KANRI
                    '_V003 = _V003_SYONIN_J_KANRI_List.AsEnumerable.
                    '                    Where(Function(r) r.SYONIN_JUN = PrCurrentStage).
                    '                    FirstOrDefault
                    'If _V003 IsNot Nothing Then
                    '    If Not _V003.RIYU.IsNulOrWS Then lbl_Modoshi_Riyu.Visible = True
                    '    If _V003.SASIMODOSI_FG Then
                    '        lbl_Modoshi_Riyu.Text = "���ߗ��R�F" & _V003.RIYU
                    '    Else
                    '        '�]����
                    '        lbl_Modoshi_Riyu.Text = "�]�����R�F" & _V003.RIYU
                    '    End If

                    '    Dim dtSYONIN_YMD As Date
                    '    If DateTime.TryParseExact(_V003.SYONIN_YMDHNS, "yyyyMMddHHmmss", Nothing, Nothing, dtSYONIN_YMD) Then
                    '        '_D004_SYONIN_J_KANRI.SYONIN_YMDHNS = _V003.SYONIN_YMDHNS
                    '        dtUPD_YMD.ValueNonFormat = dtSYONIN_YMD.ToString("yyyyMMdd")
                    '    Else
                    '        '_D004_SYONIN_J_KANRI.SYONIN_YMDHNS = Now.ToString("yyyyMMddHHmmss")
                    '        dtUPD_YMD.Text = Now.ToString("yyyy/MM/dd")
                    '    End If
                    'End If

#Region "   �Y�t�t�@�C��"

                    'Dim strRootDir As String
                    'Using DB = DBOpen()
                    '    strRootDir = FunConvPathString(FunGetCodeMastaValue(DB, "�Y�t�t�@�C���ۑ���", My.Application.Info.AssemblyName))
                    'End Using

                    'If Not _D009_FCCB_J.SYOCHI_FILEPATH.IsNulOrWS Then
                    '    'lblSYOCHI_FILEPATH.Text = CompactString(_V011_FCR_J.SYOCHI_FILEPATH, lblSYOCHI_FILEPATH, EllipsisFormat._4_Path)
                    '    'lblSYOCHI_FILEPATH.Links.Clear()
                    '    'lblSYOCHI_FILEPATH.Links.Add(0, lblSYOCHI_FILEPATH.Text.Length, $"{strRootDir}{_V011_FCR_J.HOKOKU_NO.Trim}\CTS\{_V011_FCR_J.SYOCHI_FILEPATH}")
                    '    'lblSYOCHI_FILEPATH.Visible = True
                    '    'lblSYOCHI_FILEPATH_Clear.Visible = True
                    'End If

#End Region

            End Select



            If FunGetNextSYONIN_JUN(PrCurrentStage) = ENM_FCCB_STAGE._999_Closed Then
                '�ŏI�X�e�[�W�̏ꍇ�A�\����S���җ��͔�\��

                lblDestTanto.Visible = False
                cmbDestTANTO.Visible = False
                cmdFunc2.Text = "���F(F2)"
            Else
                cmdFunc2.Text = "���F�E�\��(F2)"
            End If

            ErrorProvider.ClearError(cmbDestTANTO)

            Return True
        Catch ex As Exception
            EM.ErrorSyori(ex, False, conblnNonMsg)
            Return False
        Finally
            IsInitializing = False
        End Try
    End Function

    Private Function GetCM_TANTO(BUMON_KB As String) As DataTable

        Try
            Dim dt As DataTable = FunGetSYOZOKU_SYAIN(BUMON_KB)
            Dim drs As IEnumerable(Of DataRow)
            Dim InList As New List(Of Integer)

            InList.Clear() : InList.AddRange({ENM_GYOMU_GROUP_ID._4_�i��.Value, ENM_GYOMU_GROUP_ID._5_�݌v.Value, ENM_GYOMU_GROUP_ID._6_���Z.Value, ENM_GYOMU_GROUP_ID._91_QMS�Ǘ��ӔC��.Value})
            drs = dt.AsEnumerable.Where(Function(r) InList.Contains(r.Field(Of Integer)(NameOf(M011_SYAIN_GYOMU.GYOMU_GROUP_ID)))).
                                  GroupBy(Function(r) r.Item("VALUE")).Select(Function(g) g.FirstOrDefault)

            Return dt
        Catch ex As Exception
            Throw
        End Try
    End Function

    Private Function SetTANTO_TooltipInfo() As Boolean

        Call SetInfoLabelFormat(lblKISO_TANTO, $"�Ј��Ɩ��O���[�v�}�X�^{vbCr}�ȉ��̋Ɩ��O���[�v�ɓo�^���ꂽ�S����{vbCrLf}{vbCrLf}QMS�Ǘ��ӔC�ҁE�݌v�E�i�؁E���Z")
        Call SetInfoLabelFormat(lblDestTanto, $"���F�S���҃}�X�^{vbCr}��������̓��Y�X�e�[�W�ɓo�^���ꂽ�S����")

    End Function

    Private Function SetInfoLabelFormat(lbl As Label, caption As String) As Boolean
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
            '-----����
            If enmSAVE_MODE = ENM_SAVE_MODE._2_���F�\�� And FunGetNextSYONIN_JUN(PrCurrentStage) < ENM_FCCB_STAGE._999_Closed Then
                Call CmbDestTANTO_Validating(cmbDestTANTO, Nothing)
            End If

            'If cmbKOKYAKU_EIKYO_HANTEI_COMMENT.Visible Then
            '    Dim IsEntered As Boolean = (Not cmbKOKYAKU_EIKYO_HANTEI_COMMENT.Text.IsNulOrWS) Or cmbKOKYAKU_EIKYO_HANTEI_COMMENT.SelectedIndex > 0
            '    IsValidated *= ErrorProvider.UpdateErrorInfo(cmbKOKYAKU_EIKYO_HANTEI_COMMENT, IsEntered, String.Format(My.Resources.infoMsgRequireSelectOrInput, "�ۂ̗��R"))
            'End If

            '��L�e��Validating�C�x���g�Ńt���O���X�V���A�S��OK�̏ꍇ��True
            Return IsValidated
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
        sbSQL.Append($"SELECT")
        sbSQL.Append($" *")
        sbSQL.Append($" FROM {NameOf(V003_SYONIN_J_KANRI)} ")
        sbSQL.Append($" WHERE {NameOf(V003_SYONIN_J_KANRI.SYONIN_HOKOKUSYO_ID)}={intSYONIN_HOKOKUSYO_ID}")
        sbSQL.Append($" And {NameOf(V003_SYONIN_J_KANRI.HOKOKU_NO)}='{strHOKOKU_NO.Trim}'")
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
    ''' <param name="CurrentStageID">���X�e�[�WID</param>
    ''' <returns></returns>
    Private Function FunGetNextSYONIN_JUN(CurrentStageID As Integer) As Integer
        Try
            Const stageLength As Integer = 10

            'If KOKYAKU_HANTEI_KB = False Then
            '    '�Ȃ��� #256
            '    If CurrentStageID >= ENM_FCCB_STAGE._70_�i�؉� Then
            '        Return ENM_FCCB_STAGE._999_Closed
            '    Else
            '        Return CurrentStageID + stageLength
            '    End If
            'Else
            '    Select Case CurrentStageID
            '        Case ENM_CTS_STAGE._90_���咷, ENM_CTS_STAGE._999_Closed
            '            Return ENM_CTS_STAGE._999_Closed
            '        Case Else
            Return CurrentStageID + stageLength
            '    End Select
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
            sbSQL.Append($" COUNT({NameOf(R005_FCR_SASIMODOSI.HOKOKU_NO)})")
            sbSQL.Append($" FROM {NameOf(R005_FCR_SASIMODOSI)} ")
            sbSQL.Append($" WHERE {NameOf(R005_FCR_SASIMODOSI.HOKOKU_NO)}='{strHOKOKU_NO}'")
            Using DB As ClsDbUtility = DBOpen()
                intRET = DB.ExecuteScalar(sbSQL.ToString, conblnNonMsg)
            End Using

            Return intRET > 0
        End If
    End Function

#End Region

    Private Sub ShowUnimplemented()
        MessageBox.Show("������", "������", MessageBoxButtons.OK, MessageBoxIcon.Information)
    End Sub

End Class