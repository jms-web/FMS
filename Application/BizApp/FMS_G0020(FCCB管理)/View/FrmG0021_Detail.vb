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
Public Class FrmG0021_Detail

#Region "�萔�E�ϐ�"

    'Private _D009 As New D009_FCCB_J
    Private _V003_SYONIN_J_KANRI_List As New List(Of V003_SYONIN_J_KANRI)

    Private IsEditingClosed As Boolean
    Private IsInitializing As Boolean

    Private USER_GYOMU_KENGEN_LIST As New List(Of ENM_GYOMU_GROUP_ID)

    Private Flx2_DS_DB As DataTable
    Private Flx3_DS_DB As DataTable
    Private Flx4_DS_DB As DataTable

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

        cmbKISYU.NullValue = 0
        cmbKISO_TANTO.NullValue = 0
        cmbCM_TANTO.NullValue = 0

        dtKISO.Nullable = True
        cmbSYOCHI_GM_TANTO.NullValue = 0
        cmbSYOCHI_SEKKEI_TANTO.NullValue = 0
        cmbSYOCHI_SEIZO_TANTO.NullValue = 0
        cmbSYOCHI_SEIGI_TANTO.NullValue = 0
        cmbSYOCHI_EIGYO_TANTO.NullValue = 0
        cmbSYOCHI_KANRI_TANTO.NullValue = 0
        cmbSYOCHI_HINSYO_TANTO.NullValue = 0
        cmbSYOCHI_KENSA_TANTO.NullValue = 0
        cmbSYOCHI_KOBAI_TANTO.NullValue = 0

        cmbKAKUNIN_CM_TANTO.NullValue = 0
        cmbKAKUNIN_GM_TANTO.NullValue = 0

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

                        Call FunInitializeFlexGrid(flxDATA_2)
                        Call FunInitializeFlexGrid(flxDATA_3)
                        Call FunInitializeFlexGrid(flxDATA_4)
                        Call FunInitializeFlexGrid(flxDATA_5)

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

#Region "FlexGrid�֘A"

    Private Function FunInitializeFlexGrid(ByVal flxgrd As C1.Win.C1FlexGrid.C1FlexGrid) As Boolean
        With flxgrd
            .Rows(0).Height = 30
            .AutoGenerateColumns = False
            .AutoResize = False
            .AllowEditing = True
            .AllowDragging = C1.Win.C1FlexGrid.AllowDraggingEnum.None
            .AllowDelete = False
            .AllowResizing = C1.Win.C1FlexGrid.AllowResizingEnum.Columns
            .AllowSorting = C1.Win.C1FlexGrid.AllowSortingEnum.SingleColumn
            '.AllowMerging = C1.Win.C1FlexGrid.AllowMergingEnum.RestrictRows
            .AllowFiltering = True
            .ShowCellLabels = True
            .SelectionMode = C1.Win.C1FlexGrid.SelectionModeEnum.Cell

            .EditOptions = EditFlags.UseNumericEditor

            .FocusRect = C1.Win.C1FlexGrid.FocusRectEnum.None

            .Font = New Font("Meiryo UI", 9, FontStyle.Regular, GraphicsUnit.Point, CType(128, Byte))

            .Styles.Normal.BackColor = clrDeletedRowBackColor
            .Styles.Normal.ForeColor = clrDeletedRowForeColor

            .Styles.Add("DeletedRow")
            .Styles("DeletedRow").BackColor = clrDeletedRowBackColor
            .Styles("DeletedRow").ForeColor = clrDeletedRowForeColor

            .Styles.Add("TANTO_GROUP")
            .Styles("TANTO_GROUP").BackColor = Color.LemonChiffon
            .Styles("TANTO_GROUP").ForeColor = Color.Blue

            .VisualStyle = C1.Win.C1FlexGrid.VisualStyle.Office2010Silver

            .Styles.Normal.Border.Style = C1.Win.C1FlexGrid.BorderStyleEnum.Flat
            .Styles.Normal.Border.Color = Color.Black

            .Rows.DefaultSize = 24

            '�ȉ���K�p����ɂ�VisualStyle��Custom�ɂ���
            .Styles.Focus.BackColor = clrRowEnterColor

            For i As Integer = 1 To .Cols.Count - 1
                If .Cols(i).Name.Contains("YMD") Then
                    .Cols(i).DataType = GetType(Date)
                    '.Cols(i).Format = "yyyy/MM/dd"
                    '.Cols(i).EditMask = "0000/00/00"
                End If
            Next
        End With
    End Function

    Private Sub FlxDATA_AfterAddRow(sender As Object, e As RowColEventArgs) Handles flxDATA_4.AfterAddRow
        Try
            Dim flx = DirectCast(sender, C1FlexGrid)

            flx(e.Row, NameOf(D011.ITEM_NO)) = flx.Rows.Count - 2
            flx(e.Row, NameOf(D011.SURYO)) = 0
        Catch ex As Exception
            Throw
        End Try
    End Sub

    Private Sub Flex_StartEdit(ByVal sender As Object, ByVal e As C1.Win.C1FlexGrid.RowColEventArgs) Handles flxDATA_2.StartEdit,
                                                                                                             flxDATA_3.StartEdit,
                                                                                                             flxDATA_5.StartEdit

        Try

            Dim flx = DirectCast(sender, C1FlexGrid)
            Dim GYOMU_GROUP_ID As ENM_GYOMU_GROUP_ID
            Dim TANTO_COL_INDEX As Integer
            Dim ds As DataTable
            Select Case flx.Name
                Case NameOf(flxDATA_2)
                    GYOMU_GROUP_ID = flx(e.Row, 4).ToString.ToVal
                    TANTO_COL_INDEX = 6
                    ds = Flx2_DS.DataSource
                Case NameOf(flxDATA_3)
                    GYOMU_GROUP_ID = flx(e.Row, 3).ToString.ToVal
                    TANTO_COL_INDEX = 5
                    ds = Flx3_DS.DataSource
                Case NameOf(flxDATA_5)
                    GYOMU_GROUP_ID = flx(e.Row, 3).ToString.ToVal
                    TANTO_COL_INDEX = 4
                    ds = Flx4_DS.DataSource
                Case Else
                    Throw New ArgumentException("�z��O�̃f�[�^�\�[�X�ł�", flx.Name)
            End Select

            '�S���������S���҃��X�g�擾
            Select Case flx.Cols(e.Col).Name
                Case NameOf(D010.TANTO_GYOMU_GROUP_ID)
                    If GYOMU_GROUP_ID <> 0 Then
                        flx.SetCellStyle(e.Row, TANTO_COL_INDEX, flx.Styles($"dtTANTO_{GYOMU_GROUP_ID.Value}"))
                    End If
                Case NameOf(D010.TANTO_ID)
                    If GYOMU_GROUP_ID <> 0 Then
                        flx.SetCellStyle(e.Row, TANTO_COL_INDEX, flx.Styles($"dtTANTO_{GYOMU_GROUP_ID.Value}"))
                    End If
                    If flx.Name <> NameOf(flxDATA_5) AndAlso Not flx(e.Row, NameOf(D010.YOHI_KB)) Then
                        e.Cancel = True
                    End If
                Case NameOf(D010.YOHI_KB)
                    If flx(e.Row, NameOf(D010.YOHI_KB)) Then
                        flx(e.Row, NameOf(D010.TANTO_ID)) = 0
                        flx(e.Row, NameOf(D010.NAIYO)) = ""
                        flx(e.Row, NameOf(D010.YOTEI_YMD)) = ""
                    End If
                Case Else
                    If flx.Name <> NameOf(flxDATA_5) AndAlso Not flx(e.Row, NameOf(D010.YOHI_KB)) Then
                        e.Cancel = True
                    End If
            End Select
        Catch ex As Exception
            Throw
        End Try
    End Sub

    ' ���̓`�F�b�N
    Private Sub Flx_ValidateEdit(ByVal sender As Object, ByVal e As C1.Win.C1FlexGrid.ValidateEditEventArgs) Handles flxDATA_2.ValidateEdit,
                                                                                                                      flxDATA_3.ValidateEdit,
                                                                                                                      flxDATA_5.ValidateEdit

        Dim flx = DirectCast(sender, C1FlexGrid)

        If flx.Cols(e.Col).Name.Contains("YMD") Then
            Dim d As Date
            If Not Date.TryParse(flx.Editor.Text, d) Then
                e.Cancel = True
                MessageBox.Show("�����ȓ��t�ł�")
            End If
        End If
    End Sub

    Private Sub Flx_AfterEdit(ByVal sender As Object, ByVal e As C1.Win.C1FlexGrid.RowColEventArgs) Handles flxDATA_2.AfterEdit,
                                                                                                             flxDATA_3.AfterEdit,
                                                                                                             flxDATA_5.AfterEdit

        Try

            Dim flx = DirectCast(sender, C1FlexGrid)

            Select Case True
                Case flx.Cols(e.Col).Name.Contains("YMD")

                    'flexgrid 2019J�ȑO�̕s��Ή�(�ߘa���t��.format�����������)
                    Dim value As String = Nz(flx(e.Row, e.Col), "")
                    If Not value.IsNulOrWS Then
                        flx(e.Row, e.Col) = CDate(value).ToString("yyyy/MM/dd")
                    End If
                Case flx.Cols(e.Col).Name = "YOHI_KB"

                    If flx(e.Row, e.Col) Then
                        flx.Rows(e.Row).Style = flx.Styles("TANTO_GROUP")
                    Else
                        flx.Rows(e.Row).Style = flx.Styles("DeletedRow")
                    End If

                Case Else

            End Select
        Catch ex As Exception
            Throw
        Finally
            Call FunInitFuncButtonEnabled()
        End Try
    End Sub

    Private Sub FlxDATA_AfterSort(sender As Object, e As SortColEventArgs) Handles flxDATA_2.AfterSort, flxDATA_3.AfterSort, flxDATA_5.AfterSort
        Call SetFlxDATA_EditStatus(sender)
    End Sub

    Private Sub SetFlxDATA_EditStatus(flx As C1FlexGrid)

        Dim InList As New List(Of Integer)
        Dim HasSIKAKARI_KENGEN As Boolean
        If flx.Name = NameOf(flxDATA_4) Then
            Dim dt As DataTable = FunGetSYOZOKU_SYAIN(cmbBUMON.SelectedValue)


            InList.Clear() : InList.AddRange({ENM_GYOMU_GROUP_ID._7_�Ǘ�.Value, ENM_GYOMU_GROUP_ID._8_�c��.Value})
            Dim drs = dt.AsEnumerable.Where(Function(r) InList.Contains(r.Field(Of Integer)(NameOf(M011_SYAIN_GYOMU.GYOMU_GROUP_ID)))).
                                      GroupBy(Function(r) r.Item("VALUE")).Select(Function(g) g.FirstOrDefault)

            HasSIKAKARI_KENGEN = drs.Where(Function(r) r.Item("VALUE") = pub_SYAIN_INFO.SYAIN_ID.ToString).Count > 0
        End If

        '�ҏW�����ݒ�
        For i As Integer = 1 To flx.Rows.Count - 1

            Select Case flx.Name
                Case NameOf(flxDATA_2), NameOf(flxDATA_3)

                    If _D009.CM_TANTO = pub_SYAIN_INFO.SYAIN_ID Or
                        _D009.ADD_SYAIN_ID = pub_SYAIN_INFO.SYAIN_ID Or
                        USER_GYOMU_KENGEN_LIST.Contains(flx.Rows(i).Item(NameOf(D010.TANTO_GYOMU_GROUP_ID))) Then

                        flx.Rows(i).AllowEditing = True
                        If flx.Rows(i).Item("YOHI_KB") Then
                            flx.Rows(i).Style = flx.Styles("TANTO_GROUP")
                        Else
                            flx.Rows(i).Style = Nothing
                        End If
                    Else

                        '�S���Ɩ��ȊO�͕ҏW�s��
                        flx.Rows(i).Style = flx.Styles("DeletedRow")
                        flx.Rows(i).AllowEditing = False
                    End If

                Case Else
                    flx.Rows(i).Style = flx.Styles("TANTO_GROUP")

                    '�Ǘ��E�c�� + �c���E�N����
                    flx.Rows(i).AllowEditing = (_D009.CM_TANTO = pub_SYAIN_INFO.SYAIN_ID Or _D009.ADD_SYAIN_ID = pub_SYAIN_INFO.SYAIN_ID) Or HasSIKAKARI_KENGEN
            End Select

        Next
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

                            '���̒S���҂��܂߂ĕK�{���ړ��͍ς݂̏ꍇ�AFCCB�c���ւ̐\�������ֈڍs
                            Select Case PrCurrentStage
                                Case ENM_FCCB_STAGE._20_���u����������.Value
                                    If IsInputRequired_DB() Then
                                        If FunSendRequestMail(fromUserNAME:="FCCB�Ǘ��V�X�e��", toUserNAME:=cmbCM_TANTO.Text) Then
                                            strMsg &= $"{vbCrLf}�܂��A�S�Ă̗v���͍��ڂ������������߁AFCCB�c���ɏ��u�\���𑗐M���܂����B"
                                        End If
                                    End If
                            End Select

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

                    Call FunOpenReportFCCB()

                Case 11 '����
                    'Call ShowUnimplemented()
                    Call OpenFormHistory(Context.ENM_SYONIN_HOKOKUSYO_ID._4_FCCB, PrFCCB_NO)

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
                    If FunSAVE_D011(DB, enmSAVE_MODE) = False Then blnErr = True : Return False
                    If FunSAVE_D012(DB, enmSAVE_MODE) = False Then blnErr = True : Return False

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

        If _D009.FCCB_NO.IsNulOrWS Or _D009.FCCB_NO = "<�V�K>" Then
            Dim objParam As System.Data.Common.DbParameter = DB.DbCommand.CreateParameter
            Dim lstParam As New List(Of System.Data.Common.DbParameter)
            With objParam
                .ParameterName = "HOKOKU_NO"
                .DbType = DbType.String
                .Direction = ParameterDirection.Output
                .Size = 8
            End With
            lstParam.Add(objParam)
            If DB.Fun_blnExecStored("dbo.ST05_GET_FCCB_NO", lstParam) = True Then
                _D009.FCCB_NO = DB.DbCommand.Parameters("HOKOKU_NO").Value
            Else
                Return False
            End If
        End If

        If (FunGetNextSYONIN_JUN(PrCurrentStage) = ENM_FCCB_STAGE._999_Closed) And enmSAVE_MODE = ENM_SAVE_MODE._2_���F�\�� Then
            _D009._CLOSE_FG = 1
        End If

        _D009.BUMON_KB = cmbBUMON.SelectedValue
        _D009.KISYU_ID = cmbKISYU.SelectedValue
        If dtKISO.Text.IsNulOrWS Then
            _D009.ADD_YMDHNS = strSysDate
        Else
            _D009.ADD_YMDHNS = dtKISO.ValueDate.ToString("yyyyMMdd") & "000000"
        End If
        _D009.CM_TANTO = cmbCM_TANTO.SelectedValue
        _D009.BUHIN_BANGO = cmbBUHIN_BANGO.SelectedValue
        _D009.SYANAI_CD = cmbSYANAI_CD.SelectedValue
        _D009.BUHIN_NAME = If(cmbHINMEI.Text <> "(�I��)", cmbHINMEI.Text, "")
        _D009.INPUT_DOC_NO = mtxINPUT_DOC_NO.Text
        _D009.SNO_APPLY_PERIOD_KISO = mtxSNO_APPLY_PERIOD_KISO.Text
        _D009.SNO_APPLY_PERIOD_HENKO_SINGI = mtxSNO_APPLY_PERIOD_HENKO_SINGI.Text
        _D009.INPUT_NAIYO = txtINPUT_NAIYO.Text

        If cmbKISO_TANTO.IsSelected Then
            _D009.ADD_SYAIN_ID = cmbKISO_TANTO.SelectedValue
        Else
            _D009.ADD_SYAIN_ID = pub_SYAIN_INFO.SYAIN_ID
        End If

        _D009.UPD_YMDHNS = strSysDate
        _D009.UPD_SYAIN_ID = pub_SYAIN_INFO.SYAIN_ID
        _D009.DEL_YMDHNS = ""
        _D009.DEL_SYAIN_ID = 0

#End Region

        '-----MERGE
        sbSQL.Remove(0, sbSQL.Length)
        sbSQL.Append($"MERGE INTO {NameOf(D009_FCCB_J)} AS TARGET")
        sbSQL.Append($" USING (")
        sbSQL.Append($"{_D009.ToSelectSqlString}")
        sbSQL.Append($" ) AS WK")
        sbSQL.Append($" ON (TARGET.{NameOf(_D009.FCCB_NO)} = WK.{NameOf(_D009.FCCB_NO)})")
        '---UPDATE
        sbSQL.Append($" WHEN MATCHED THEN")
        sbSQL.Append($" {_D009.ToUpdateSqlString("TARGET", "WK")}")
        '---INSERT
        sbSQL.Append($" WHEN NOT MATCHED THEN")
        sbSQL.Append($" {_D009.ToInsertSqlString("WK")}")
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
        WL.WriteLogDat($"[DEBUG]FCCB �񍐏�NO:{_D009.FCCB_NO}�AMERGE D009_FCCB_J")

        Return True
    End Function

#End Region

#Region "   D010"

    Private Function FunSAVE_D010(ByRef DB As ClsDbUtility, ByVal enmSAVE_MODE As ENM_SAVE_MODE) As Boolean

        Try

            Dim sbSQL As New System.Text.StringBuilder
            Dim strRET As String
            Dim sqlEx As New Exception
            Dim strSysDate As String = DB.GetSysDateString
            Dim _D010 As New D010
            Dim groups = GetSYAIN_GYOMUGroups(pub_SYAIN_INFO.SYAIN_ID)

            For Each dr As DataRow In DirectCast(Flx2_DS.DataSource, DataTable).Rows

                If _D009.CM_TANTO = pub_SYAIN_INFO.SYAIN_ID Or _D009.ADD_SYAIN_ID = pub_SYAIN_INFO.SYAIN_ID Then
                    '�N���� or FCCB�c���͑S���X�V�\
                Else
                    If Not groups.Contains(dr.Item(NameOf(D010.TANTO_GYOMU_GROUP_ID))) Then

                        '���g�̋Ɩ��O���[�v���ڈȊO�͍X�V���Ȃ�
                        Continue For
                    End If
                End If

                Dim drOrg As DataRow = Flx2_DS_DB?.AsEnumerable.Where(Function(r) r.Item(NameOf(D010.ITEM_NO)) = dr.Item(NameOf(D010.ITEM_NO))).FirstOrDefault
                If drOrg IsNot Nothing AndAlso drOrg.Equals(dr) Then
                    '���[�h���ȍ~�ύX���ꂽ�ꍇ�̂ݍX�V
                    Continue For
                End If

#Region "   ���f���X�V"

                _D010.Clear()
                _D010.FCCB_NO = _D009.FCCB_NO
                _D010.ITEM_NO = dr.Item(NameOf(_D010.ITEM_NO))
                _D010.ITEM_GROUP_NAME = dr.Item(NameOf(_D010.ITEM_GROUP_NAME))
                _D010.ITEM_NAME = dr.Item(NameOf(_D010.ITEM_NAME))
                _D010.TANTO_GYOMU_GROUP_ID = dr.Item(NameOf(_D010.TANTO_GYOMU_GROUP_ID))
                _D010.YOHI_KB = dr.Item(NameOf(_D010.YOHI_KB))
                _D010.TANTO_ID = dr.Item(NameOf(_D010.TANTO_ID))
                _D010.NAIYO = dr.Item(NameOf(_D010.NAIYO))
                If Not dr.Item(NameOf(_D010.YOTEI_YMD)).ToString.IsNulOrWS Then
                    _D010.YOTEI_YMD = CDate(dr.Item(NameOf(_D010.YOTEI_YMD))).ToString("yyyyMMdd")
                End If
                If Not dr.Item(NameOf(_D010.CLOSE_YMD)).ToString.IsNulOrWS Then
                    _D010.CLOSE_YMD = CDate(dr.Item(NameOf(_D010.CLOSE_YMD))).ToString("yyyyMMdd")
                End If

#End Region

                sbSQL.Clear()
                sbSQL.Append($"MERGE INTO {NameOf(D010_FCCB_SUB_SYOCHI_KOMOKU)} AS TARGET")
                sbSQL.Append($" USING (")
                sbSQL.Append($"{_D010.ToSelectSqlString}")
                sbSQL.Append($" ) AS WK")
                sbSQL.Append($" ON (TARGET.{NameOf(_D010.FCCB_NO)} = WK.{NameOf(_D010.FCCB_NO)}")
                sbSQL.Append($" AND TARGET.{NameOf(_D010.ITEM_NO)} = WK.{NameOf(_D010.ITEM_NO)})")
                '---UPDATE
                sbSQL.Append($" WHEN MATCHED THEN")
                sbSQL.Append($" {_D010.ToUpdateSqlString("TARGET", "WK")}")
                '---INSERT
                sbSQL.Append($" WHEN NOT MATCHED THEN")
                sbSQL.Append($" {_D010.ToInsertSqlString("WK")}")
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
            Next

            For Each dr As DataRow In DirectCast(Flx3_DS.DataSource, DataTable).Rows

#Region "   ���f���X�V"

                _D010.Clear()
                _D010.FCCB_NO = _D009.FCCB_NO
                _D010.ITEM_NO = dr.Item(NameOf(_D010.ITEM_NO))
                _D010.ITEM_GROUP_NAME = dr.Item(NameOf(_D010.ITEM_GROUP_NAME))
                _D010.ITEM_NAME = dr.Item(NameOf(_D010.ITEM_NAME))
                _D010.TANTO_GYOMU_GROUP_ID = dr.Item(NameOf(_D010.TANTO_GYOMU_GROUP_ID))
                _D010.YOHI_KB = dr.Item(NameOf(_D010.YOHI_KB))
                _D010.TANTO_ID = dr.Item(NameOf(_D010.TANTO_ID))
                _D010.NAIYO = dr.Item(NameOf(_D010.NAIYO))
                If Not dr.Item(NameOf(_D010.YOTEI_YMD)).ToString.IsNulOrWS Then
                    _D010.YOTEI_YMD = CDate(dr.Item(NameOf(_D010.YOTEI_YMD))).ToString("yyyyMMdd")
                End If
                If Not dr.Item(NameOf(_D010.CLOSE_YMD)).ToString.IsNulOrWS Then
                    _D010.CLOSE_YMD = CDate(dr.Item(NameOf(_D010.CLOSE_YMD))).ToString("yyyyMMdd")
                End If

#End Region

                sbSQL.Clear()
                sbSQL.Append($"MERGE INTO {NameOf(D010_FCCB_SUB_SYOCHI_KOMOKU)} AS TARGET")
                sbSQL.Append($" USING (")
                sbSQL.Append($"{_D010.ToSelectSqlString}")
                sbSQL.Append($" ) AS WK")
                sbSQL.Append($" ON (TARGET.{NameOf(_D010.FCCB_NO)} = WK.{NameOf(_D010.FCCB_NO)}")
                sbSQL.Append($" AND TARGET.{NameOf(_D010.ITEM_NO)} = WK.{NameOf(_D010.ITEM_NO)})")
                '---UPDATE
                sbSQL.Append($" WHEN MATCHED THEN")
                sbSQL.Append($" {_D010.ToUpdateSqlString("TARGET", "WK")}")
                '---INSERT
                sbSQL.Append($" WHEN NOT MATCHED THEN")
                sbSQL.Append($" {_D010.ToInsertSqlString("WK")}")
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
            Next

            WL.WriteLogDat($"[DEBUG]FCCB �񍐏�NO:{_D010.FCCB_NO}�AMERGE D010")

            Return True
        Catch ex As Exception
            Throw ex
        End Try
    End Function

#End Region

#Region "   D011"

    Private Function FunSAVE_D011(ByRef DB As ClsDbUtility, ByVal enmSAVE_MODE As ENM_SAVE_MODE) As Boolean
        Dim sbSQL As New System.Text.StringBuilder
        Dim strRET As String
        Dim sqlEx As New Exception
        Dim strSysDate As String = DB.GetSysDateString
        Dim _D011 As New D011_FCCB_SUB_SIKAKE_BUHIN

        Try

            For Each dr As DataRow In DirectCast(Flx4_DS.DataSource, DataTable).Rows

#Region "   ���f���X�V"

                _D011.Clear()
                _D011.FCCB_NO = _D009.FCCB_NO
                _D011.ITEM_NO = dr.Item(NameOf(_D011.ITEM_NO))
                _D011.BUHIN_HINBAN = dr.Item(NameOf(_D011.BUHIN_HINBAN))
                _D011.MEMO1 = dr.Item(NameOf(_D011.MEMO1))
                _D011.MEMO2 = dr.Item(NameOf(_D011.MEMO2))
                _D011.SURYO = dr.Item(NameOf(_D011.SURYO))
                _D011.SYOCHI_NAIYO = dr.Item(NameOf(_D011.SYOCHI_NAIYO))
                _D011.TANTO_GYOMU_GROUP_ID = dr.Item(NameOf(_D011.TANTO_GYOMU_GROUP_ID))
                _D011.TANTO_ID = dr.Item(NameOf(_D011.TANTO_ID))
                If Not dr.Item(NameOf(_D011.YOTEI_YMD)).ToString.IsNulOrWS Then
                    _D011.YOTEI_YMD = CDate(dr.Item(NameOf(_D011.YOTEI_YMD))).ToString("yyyyMMdd")
                End If
                If Not dr.Item(NameOf(_D011.CLOSE_YMD)).ToString.IsNulOrWS Then
                    _D011.CLOSE_YMD = CDate(dr.Item(NameOf(_D011.CLOSE_YMD))).ToString("yyyyMMdd")
                End If

#End Region

                sbSQL.Clear()
                sbSQL.Append($"MERGE INTO {NameOf(D011_FCCB_SUB_SIKAKE_BUHIN)} AS TARGET")
                sbSQL.Append($" USING (")
                sbSQL.Append($"{_D011.ToSelectSqlString}")
                sbSQL.Append($" ) AS WK")
                sbSQL.Append($" ON (TARGET.{NameOf(_D011.FCCB_NO)} = WK.{NameOf(_D011.FCCB_NO)}")
                sbSQL.Append($" AND TARGET.{NameOf(_D011.ITEM_NO)} = WK.{NameOf(_D011.ITEM_NO)})")
                '---UPDATE
                sbSQL.Append($" WHEN MATCHED THEN")
                sbSQL.Append($" {_D011.ToUpdateSqlString("TARGET", "WK")}")
                '---INSERT
                sbSQL.Append($" WHEN NOT MATCHED THEN")
                sbSQL.Append($" {_D011.ToInsertSqlString("WK")}")
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
            Next

            WL.WriteLogDat($"[DEBUG]FCCB �񍐏�NO:{_D011.FCCB_NO}�AMERGE D010")

            Return True
        Catch ex As Exception
            Throw
        End Try

    End Function

#End Region

#Region "   D012"

    Private Function FunSAVE_D012(ByRef DB As ClsDbUtility, ByVal enmSAVE_MODE As ENM_SAVE_MODE) As Boolean

        Dim strSysDate As String = DB.GetSysDateString

        Try

            If cmbSYOCHI_SEIZO_TANTO.IsSelected Then
                If FunSAVE_D012_SUB(DB, ENM_GYOMU_GROUP_ID._2_����, cmbSYOCHI_SEIZO_TANTO.SelectedValue, dtSYOCHI_SEIZO_TANTO.ValueDate) = False Then
                    Return False
                End If
            End If
            If cmbSYOCHI_KENSA_TANTO.IsSelected Then
                If FunSAVE_D012_SUB(DB, ENM_GYOMU_GROUP_ID._3_����, cmbSYOCHI_KENSA_TANTO.SelectedValue, dtSYOCHI_KENSA_TANTO.ValueDate) = False Then
                    Return False
                End If
            End If
            If cmbSYOCHI_HINSYO_TANTO.IsSelected Then
                If FunSAVE_D012_SUB(DB, ENM_GYOMU_GROUP_ID._4_�i��, cmbSYOCHI_HINSYO_TANTO.SelectedValue, dtSYOCHI_HINSYO_TANTO.ValueDate) = False Then
                    Return False
                End If
            End If
            If cmbSYOCHI_SEKKEI_TANTO.IsSelected Then
                If FunSAVE_D012_SUB(DB, ENM_GYOMU_GROUP_ID._5_�݌v, cmbSYOCHI_SEKKEI_TANTO.SelectedValue, dtSYOCHI_SEKKEI_TANTO.ValueDate) = False Then
                    Return False
                End If
            End If
            If cmbSYOCHI_SEIGI_TANTO.IsSelected Then
                If FunSAVE_D012_SUB(DB, ENM_GYOMU_GROUP_ID._6_���Z, cmbSYOCHI_SEIGI_TANTO.SelectedValue, dtSYOCHI_SEIGI_TANTO.ValueDate) = False Then
                    Return False
                End If
            End If
            If cmbSYOCHI_KANRI_TANTO.IsSelected Then
                If FunSAVE_D012_SUB(DB, ENM_GYOMU_GROUP_ID._7_�Ǘ�, cmbSYOCHI_KANRI_TANTO.SelectedValue, dtSYOCHI_KANRI_TANTO.ValueDate) = False Then
                    Return False
                End If
            End If
            If cmbSYOCHI_EIGYO_TANTO.IsSelected Then
                If FunSAVE_D012_SUB(DB, ENM_GYOMU_GROUP_ID._8_�c��, cmbSYOCHI_EIGYO_TANTO.SelectedValue, dtSYOCHI_EIGYO_TANTO.ValueDate) = False Then
                    Return False
                End If
            End If
            If cmbSYOCHI_GM_TANTO.IsSelected Then
                If FunSAVE_D012_SUB(DB, ENM_GYOMU_GROUP_ID._91_QMS�Ǘ��ӔC��, cmbSYOCHI_GM_TANTO.SelectedValue, dtSYOCHI_GM_TANTO.ValueDate) = False Then
                    Return False
                End If
            End If

            '
            If PrCurrentStage = ENM_FCCB_STAGE._60_���u���������m�F Then
                If cmbKAKUNIN_CM_TANTO.IsSelected Then
                    If FunSAVE_D012_SUB(DB, "92", cmbKAKUNIN_CM_TANTO.SelectedValue, dtKAKUNIN_CM_TANTO.ValueDate) = False Then
                        Return False
                    End If
                End If
                If cmbKAKUNIN_GM_TANTO.IsSelected Then
                    If FunSAVE_D012_SUB(DB, "93", cmbKAKUNIN_GM_TANTO.SelectedValue, dtKAKUNIN_GM_TANTO.ValueDate) = False Then
                        Return False
                    End If
                End If
            End If

            WL.WriteLogDat($"[DEBUG]FCCB �񍐏�NO:{_D009.FCCB_NO}�AMERGE D012")

            Return True
        Catch ex As Exception
            Throw
        End Try

    End Function

    Private Function FunSAVE_D012_SUB(ByRef DB As ClsDbUtility, GYOMU_GROUP_ID As Integer, TANTO_ID As Integer, AddDate As Date) As Boolean
        Dim sbSQL As New System.Text.StringBuilder
        Dim strRET As String
        Dim sqlEx As New Exception
        Dim _D012 As New D012

        Try

#Region "   ���f���X�V"

            _D012.Clear()
            _D012.FCCB_NO = _D009.FCCB_NO
            _D012.GYOMU_GROUP_ID = GYOMU_GROUP_ID
            _D012.TANTO_ID = TANTO_ID
            _D012.ADD_YMDHNS = AddDate.ToString("yyyyMMddHHmmss")
            _D012.ADD_SYAIN_ID = pub_SYAIN_INFO.SYAIN_ID

#End Region

            sbSQL.Clear()
            sbSQL.Append($"MERGE INTO {NameOf(D012_FCCB_SUB_SYOCHI_KAKUNIN)} AS TARGET")
            sbSQL.Append($" USING (")
            sbSQL.Append($"{_D012.ToSelectSqlString}")
            sbSQL.Append($" ) AS WK")
            sbSQL.Append($" ON (TARGET.{NameOf(_D012.FCCB_NO)} = WK.{NameOf(_D012.FCCB_NO)}")
            sbSQL.Append($" AND TARGET.{NameOf(_D012.GYOMU_GROUP_ID)} = WK.{NameOf(_D012.GYOMU_GROUP_ID)})")
            '---UPDATE
            sbSQL.Append($" WHEN MATCHED THEN")
            sbSQL.Append($" {_D012.ToUpdateSqlString("TARGET", "WK")}")
            '---INSERT
            sbSQL.Append($" WHEN NOT MATCHED THEN")
            sbSQL.Append($" {_D012.ToInsertSqlString("WK")}")

            sbSQL.Append(" OUTPUT $action As RESULT;")
            strRET = DB.ExecuteScalar(sbSQL.ToString, conblnNonMsg, sqlEx)
            Select Case strRET
                Case "INSERT", "UPDATE"

                Case Else
                    If sqlEx IsNot Nothing Then
                        '-----�G���[���O�o��
                        Dim strErrMsg As String = My.Resources.ErrLogSqlExecutionFailure & sbSQL.ToString & "|" & sqlEx.Message
                        WL.WriteLogDat(strErrMsg)
                        Return False
                    End If
            End Select

            Return True
        Catch ex As Exception
            Throw
        End Try

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
                    If FunSendRequestMail() Then
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
            Dim strSubject As String = $"�yFCCB�v���u�����˗��z{KISYU_NAME}"
            Dim strBody As String = <sql><![CDATA[
                {0} �a<br />
                <br />
        �@        FCCB�������̏��u�˗������܂����̂őΉ������肢���܂��B<br />
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

            strBody = String.Format(strBody,
                                If(toUserNAME = "", Fun_GetUSER_NAME(_D004_SYONIN_J_KANRI.SYAIN_ID), toUserNAME),
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

            Dim ToUsers As New List(Of Integer)

            Select Case PrCurrentStage
                Case ENM_FCCB_STAGE._10_�N������
                    Dim dt = FunGetSYONIN_SYOZOKU_SYAIN(_D009.BUMON_KB, Context.ENM_SYONIN_HOKOKUSYO_ID._4_FCCB, ENM_FCCB_STAGE._20_���u����������)
                    ToUsers = dt.AsEnumerable.Select(Function(r) r.Field(Of Integer)("VALUE")).ToList

                Case ENM_FCCB_STAGE._20_���u����������
                    'FCCB�c���̂�
                    ToUsers.Add(_D009.CM_TANTO)

                Case ENM_FCCB_STAGE._30_�ύX�R�c
                    If cmbSYOCHI_SEKKEI_TANTO.IsSelected Then
                        ToUsers.Add(cmbSYOCHI_SEKKEI_TANTO.SelectedValue)
                    End If
                    If cmbSYOCHI_SEIGI_TANTO.IsSelected Then
                        ToUsers.Add(cmbSYOCHI_SEIGI_TANTO.SelectedValue)
                    End If
                    If cmbSYOCHI_EIGYO_TANTO.IsSelected Then
                        ToUsers.Add(cmbSYOCHI_EIGYO_TANTO.SelectedValue)
                    End If
                    If cmbSYOCHI_KANRI_TANTO.IsSelected Then
                        ToUsers.Add(cmbSYOCHI_KANRI_TANTO.SelectedValue)
                    End If
                    If cmbSYOCHI_SEIZO_TANTO.IsSelected Then
                        ToUsers.Add(cmbSYOCHI_SEIZO_TANTO.SelectedValue)
                    End If
                    If cmbSYOCHI_HINSYO_TANTO.IsSelected Then
                        ToUsers.Add(cmbSYOCHI_HINSYO_TANTO.SelectedValue)
                    End If

                Case ENM_FCCB_STAGE._40_���u�m�F

                    Dim IsAllChecked As Boolean = True
                    If cmbSYOCHI_SEKKEI_TANTO.IsSelected AndAlso dtSYOCHI_SEKKEI_TANTO.Text.IsNulOrWS Then
                        IsAllChecked *= False
                    End If
                    If cmbSYOCHI_SEIGI_TANTO.IsSelected AndAlso dtSYOCHI_SEIGI_TANTO.Text.IsNulOrWS Then
                        IsAllChecked *= False
                    End If
                    If cmbSYOCHI_EIGYO_TANTO.IsSelected AndAlso dtSYOCHI_EIGYO_TANTO.Text.IsNulOrWS Then
                        IsAllChecked *= False
                    End If
                    If cmbSYOCHI_KANRI_TANTO.IsSelected AndAlso dtSYOCHI_KANRI_TANTO.Text.IsNulOrWS Then
                        IsAllChecked *= False
                    End If
                    If cmbSYOCHI_SEIZO_TANTO.IsSelected AndAlso dtSYOCHI_SEIZO_TANTO.Text.IsNulOrWS Then
                        IsAllChecked *= False
                    End If
                    If cmbSYOCHI_HINSYO_TANTO.IsSelected AndAlso dtSYOCHI_HINSYO_TANTO.Text.IsNulOrWS Then
                        IsAllChecked *= False
                    End If
                    If IsAllChecked AndAlso dtSYOCHI_GM_TANTO.Text.IsNulOrWS Then
                        '�S�Ă̒S���҂̃`�F�b�N�����������瓝���ӔC�҂Ɉ˗����M
                        ToUsers.Add(cmbSYOCHI_GM_TANTO.SelectedValue)
                    Else
                        '�����ӔC�҂̃`�F�b�N������������A�e�v���u�����̒S���҂Ɉ˗����M
                        Dim targetUsers = DirectCast(Flx2_DS.DataSource, DataTable).
                                                AsEnumerable.
                                                Where(Function(r) r.Field(Of Boolean)(NameOf(D010.YOHI_KB)) And Not r.Item(NameOf(D010.YOTEI_YMD)).ToString.IsNulOrWS).
                                                Select(Function(r) r.Field(Of Integer)(NameOf(D010.TANTO_ID)))

                        For Each usr In targetUsers
                            If Not ToUsers.Contains(usr) Then
                                ToUsers.Add(usr)
                            End If
                        Next

                        targetUsers = DirectCast(Flx3_DS.DataSource, DataTable).
                                                AsEnumerable.
                                                Where(Function(r) r.Field(Of Boolean)(NameOf(D010.YOHI_KB)) And Not r.Item(NameOf(D010.YOTEI_YMD)).ToString.IsNulOrWS).
                                                Select(Function(r) r.Field(Of Integer)(NameOf(D010.TANTO_ID)))

                        For Each usr In targetUsers
                            If Not ToUsers.Contains(usr) Then
                                ToUsers.Add(usr)
                            End If
                        Next

                        targetUsers = DirectCast(Flx4_DS.DataSource, DataTable).
                                                AsEnumerable.
                                                Where(Function(r) Not r.Item(NameOf(D011.YOTEI_YMD)).ToString.IsNulOrWS).
                                                Select(Function(r) r.Field(Of Integer)(NameOf(D011.TANTO_ID)))

                        For Each usr In targetUsers
                            If Not ToUsers.Contains(usr) Then
                                ToUsers.Add(usr)
                            End If
                        Next
                    End If

                Case ENM_FCCB_STAGE._50_���u��������
                    '�������ɂĊe�v���u�����̊�������1�T�ԑO�ɂȂ��Ă������u�̏ꍇ�A���u�S���҂ɑؗ��ʒm

                    Dim IsClosed As Boolean = True
                    IsClosed *= DirectCast(Flx2_DS.DataSource, DataTable).
                                               AsEnumerable.
                                               Where(Function(r) r.Field(Of Boolean)(NameOf(D010.YOHI_KB)) And r.Item(NameOf(D010.CLOSE_YMD)).ToString.IsNulOrWS).Count = 0

                    IsClosed *= DirectCast(Flx3_DS.DataSource, DataTable).
                                            AsEnumerable.
                                            Where(Function(r) r.Field(Of Boolean)(NameOf(D010.YOHI_KB)) And r.Item(NameOf(D010.CLOSE_YMD)).ToString.IsNulOrWS).Count = 0

                    IsClosed *= DirectCast(Flx4_DS.DataSource, DataTable).
                                            AsEnumerable.
                                            Where(Function(r) r.Item(NameOf(D011.CLOSE_YMD)).ToString.IsNulOrWS).Count = 0

                    '�S�v���u�����̏��u����
                    If IsClosed Then
                        'FCCB�c���Ɉ˗��ʒm
                        If dtKAKUNIN_CM_TANTO.Text.IsNulOrWS Then
                            ToUsers.Add(_D009.CM_TANTO)
                        Else
                            ToUsers.Add(cmbSYOCHI_GM_TANTO.SelectedValue)
                        End If
                    End If

                Case Else
                    Throw New ArgumentException("�z��O�̏��F���[�g�ł�", PrCurrentStage)
            End Select

            If ToUsers.Count = 0 Then
                MessageBox.Show("���M�҂�������Ȃ����߁A�˗����[���𑗐M�ł��܂���", "�˗����[�����M", MessageBoxButtons.OK, MessageBoxIcon.Information)
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
        Dim frmDLG As New FrmG0025_Tenso
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
        Dim frmDLG As New FrmG0026_Sasimodosi
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
        Dim frmDLG As New FrmG0022_Rireki
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
        Dim frmDLG As New FrmG0024_EditComment
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

            If PrMODE = ENM_DATA_OPERATION_MODE._1_ADD Then
                cmdFunc4.Enabled = False
                cmdFunc5.Enabled = False
                cmdFunc10.Enabled = False
                cmdFunc11.Enabled = False
            Else

                cmdFunc4.Enabled = True
                cmdFunc5.Enabled = True
                cmdFunc10.Enabled = True
                cmdFunc11.Enabled = True

                '�J�����g�X�e�[�W�����g�̒S���łȂ��ꍇ�͖���
                Dim IsOwnCreated As Boolean = FunblnOwnCreated(Context.ENM_SYONIN_HOKOKUSYO_ID._4_FCCB.Value, _D009.FCCB_NO, PrCurrentStage)
                If IsOwnCreated Then
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

                Dim blnIsAdmin As Boolean = IsSysAdminUser(pub_SYAIN_INFO.SYAIN_ID)
                If blnIsAdmin Then
                    cmdFunc4.Enabled = True
                    cmdFunc5.Enabled = True
                End If

                Select Case PrCurrentStage
                    Case ENM_FCCB_STAGE._10_�N������
                        cmdFunc5.Enabled = False

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

#Region "����"

    Private Sub CmbBUMON_SelectedValueChanged(sender As Object, e As EventArgs) Handles cmbBUMON.SelectedValueChanged

        'If IsInitializing Then Exit Sub

        If cmbBUMON.IsSelected Then
            Call SetTantoColumnDataList(cmbBUMON.SelectedValue)

            Dim dt As DataTable = FunGetSYOZOKU_SYAIN(cmbBUMON.SelectedValue)
            Dim drs As IEnumerable(Of DataRow)
            Dim InList As New List(Of Integer)

            InList.Clear() : InList.AddRange({ENM_GYOMU_GROUP_ID._4_�i��.Value, ENM_GYOMU_GROUP_ID._5_�݌v.Value, ENM_GYOMU_GROUP_ID._6_���Z.Value, ENM_GYOMU_GROUP_ID._91_QMS�Ǘ��ӔC��.Value})
            drs = dt.AsEnumerable.Where(Function(r) InList.Contains(r.Field(Of Integer)(NameOf(M011_SYAIN_GYOMU.GYOMU_GROUP_ID)))).
                                  GroupBy(Function(r) r.Item("VALUE")).Select(Function(g) g.FirstOrDefault)

            cmbKISO_TANTO.SetDataSource(drs.CopyToDataTable, ENM_COMBO_SELECT_VALUE_TYPE._0_Required)

            drs = dt.AsEnumerable.Where(Function(r) r.Item(NameOf(M011_SYAIN_GYOMU.GYOMU_GROUP_ID)) = ENM_GYOMU_GROUP_ID._2_����.Value)
            If drs.Count > 0 Then cmbSYOCHI_SEIZO_TANTO.SetDataSource(drs.CopyToDataTable, ENM_COMBO_SELECT_VALUE_TYPE._2_Option)

            drs = dt.AsEnumerable.Where(Function(r) r.Item(NameOf(M011_SYAIN_GYOMU.GYOMU_GROUP_ID)) = ENM_GYOMU_GROUP_ID._3_����.Value)
            If drs.Count > 0 Then cmbSYOCHI_KENSA_TANTO.SetDataSource(drs.CopyToDataTable, ENM_COMBO_SELECT_VALUE_TYPE._2_Option)

            drs = dt.AsEnumerable.Where(Function(r) r.Item(NameOf(M011_SYAIN_GYOMU.GYOMU_GROUP_ID)) = ENM_GYOMU_GROUP_ID._4_�i��.Value)
            If drs.Count > 0 Then cmbSYOCHI_HINSYO_TANTO.SetDataSource(drs.CopyToDataTable, ENM_COMBO_SELECT_VALUE_TYPE._2_Option)

            drs = dt.AsEnumerable.Where(Function(r) r.Item(NameOf(M011_SYAIN_GYOMU.GYOMU_GROUP_ID)) = ENM_GYOMU_GROUP_ID._5_�݌v.Value)
            If drs.Count > 0 Then cmbSYOCHI_SEKKEI_TANTO.SetDataSource(drs.CopyToDataTable, ENM_COMBO_SELECT_VALUE_TYPE._2_Option)

            drs = dt.AsEnumerable.Where(Function(r) r.Item(NameOf(M011_SYAIN_GYOMU.GYOMU_GROUP_ID)) = ENM_GYOMU_GROUP_ID._6_���Z.Value)
            If drs.Count > 0 Then cmbSYOCHI_SEIGI_TANTO.SetDataSource(drs.CopyToDataTable, ENM_COMBO_SELECT_VALUE_TYPE._2_Option)

            drs = dt.AsEnumerable.Where(Function(r) r.Item(NameOf(M011_SYAIN_GYOMU.GYOMU_GROUP_ID)) = ENM_GYOMU_GROUP_ID._7_�Ǘ�.Value)
            If drs.Count > 0 Then cmbSYOCHI_KANRI_TANTO.SetDataSource(drs.CopyToDataTable, ENM_COMBO_SELECT_VALUE_TYPE._2_Option)

            drs = dt.AsEnumerable.Where(Function(r) r.Item(NameOf(M011_SYAIN_GYOMU.GYOMU_GROUP_ID)) = ENM_GYOMU_GROUP_ID._8_�c��.Value)
            If drs.Count > 0 Then cmbSYOCHI_EIGYO_TANTO.SetDataSource(drs.CopyToDataTable, ENM_COMBO_SELECT_VALUE_TYPE._2_Option)

            drs = dt.AsEnumerable.Where(Function(r) r.Item(NameOf(M011_SYAIN_GYOMU.GYOMU_GROUP_ID)) = ENM_GYOMU_GROUP_ID._9_�w��.Value)
            If drs.Count > 0 Then cmbSYOCHI_KOBAI_TANTO.SetDataSource(drs.CopyToDataTable, ENM_COMBO_SELECT_VALUE_TYPE._2_Option)

            drs = dt.AsEnumerable.Where(Function(r) r.Item(NameOf(M011_SYAIN_GYOMU.GYOMU_GROUP_ID)) = ENM_GYOMU_GROUP_ID._91_QMS�Ǘ��ӔC��.Value)
            If drs.Count > 0 Then cmbSYOCHI_GM_TANTO.SetDataSource(drs.CopyToDataTable, ENM_COMBO_SELECT_VALUE_TYPE._2_Option)

            dt = FunGetSYONIN_SYOZOKU_SYAIN(cmbBUMON.SelectedValue, Context.ENM_SYONIN_HOKOKUSYO_ID._4_FCCB.Value, ENM_FCCB_STAGE._10_�N������)
            cmbCM_TANTO.SetDataSource(dt, ENM_COMBO_SELECT_VALUE_TYPE._0_Required)

            tabMain.Visible = True
        Else
            tabMain.Visible = False
        End If
    End Sub

#End Region

#Region "�@��"

    Private Sub CmbKISYU_SelectedValueChanged(sender As Object, e As EventArgs) Handles cmbKISYU.SelectedValueChanged
        Dim cmb As ComboboxEx = DirectCast(sender, ComboboxEx)

        If IsInitializing Then Exit Sub

        Try

            cmbSYANAI_CD.ValueMember = "VALUE"
            cmbSYANAI_CD.DisplayMember = "DISP"

            '���i�ԍ�
            RemoveHandler cmbBUHIN_BANGO.SelectedValueChanged, AddressOf CmbBUHIN_BANGO_SelectedValueChanged
            If cmb.IsSelected Then
                Dim drs = tblBUHIN.LazyLoad("���i�ԍ�").AsEnumerable.Where(Function(r) r.Field(Of Integer)(NameOf(_D009.KISYU_ID)) = cmb.SelectedValue).ToList
                If drs.Count > 0 Then
                    Dim _selectedValue As String = cmbBUHIN_BANGO.SelectedValue

                    cmbBUHIN_BANGO.SetDataSource(drs.CopyToDataTable, ENM_COMBO_SELECT_VALUE_TYPE._0_Required)
                    If Not cmbBUHIN_BANGO.NullValue = _selectedValue Then _D009.BUHIN_BANGO = _selectedValue
                Else
                    drs = tblBUHIN.LazyLoad("���i�ԍ�").AsEnumerable.Where(Function(r) r.Field(Of String)(NameOf(_D009.BUMON_KB)) = cmbBUMON.SelectedValue).ToList
                    If drs.Count > 0 Then
                        cmbBUHIN_BANGO.SetDataSource(drs.CopyToDataTable, ENM_COMBO_SELECT_VALUE_TYPE._0_Required)
                    End If
                End If
            Else
                Dim drs = tblBUHIN.LazyLoad("���i�ԍ�").AsEnumerable.Where(Function(r) r.Field(Of String)(NameOf(_D009.BUMON_KB)) = cmbBUMON.SelectedValue).ToList
                If drs.Count > 0 Then
                    cmbBUHIN_BANGO.SetDataSource(drs.CopyToDataTable, ENM_COMBO_SELECT_VALUE_TYPE._0_Required)
                End If
            End If
            AddHandler cmbBUHIN_BANGO.SelectedValueChanged, AddressOf CmbBUHIN_BANGO_SelectedValueChanged

            '�Г��R�[�h
            RemoveHandler cmbSYANAI_CD.SelectedValueChanged, AddressOf CmbSYANAI_CD_SelectedValueChanged
            If cmb.IsSelected Then
                If Val(cmbBUMON.SelectedValue) = Context.ENM_BUMON_KB._2_LP Then
                    Dim drs = tblSYANAI_CD.LazyLoad("�Г�CD").AsEnumerable.Where(Function(r) r.Field(Of Integer)(NameOf(_D009.KISYU_ID)) = cmb.SelectedValue).ToList
                    If drs.Count > 0 Then
                        Dim _selectedValue As String = cmbSYANAI_CD.SelectedValue
                        cmbSYANAI_CD.SetDataSource(drs.CopyToDataTable, ENM_COMBO_SELECT_VALUE_TYPE._1_Filter)
                        If Val(_selectedValue) > 0 Then _D009.SYANAI_CD = _selectedValue
                    End If
                Else
                    'cmbSYANAI_CD.DataSource = Nothing
                End If
                '_D003_NCR_J.SYANAI_CD = ""
            Else
                Dim drs = tblSYANAI_CD.LazyLoad("�Г�CD").AsEnumerable.Where(Function(r) r.Field(Of String)(NameOf(_D009.BUMON_KB)) = cmbBUMON.SelectedValue).ToList
                If drs.Count > 0 Then
                    cmbSYANAI_CD.SetDataSource(drs.CopyToDataTable, ENM_COMBO_SELECT_VALUE_TYPE._0_Required)
                End If
            End If
            AddHandler cmbSYANAI_CD.SelectedValueChanged, AddressOf CmbSYANAI_CD_SelectedValueChanged
        Catch ex As Exception
            Throw
        End Try
    End Sub

    Private Sub CmbKISYU_Validating(sender As Object, e As System.ComponentModel.CancelEventArgs) Handles cmbKISYU.Validating
        If IsInitializing Then Exit Sub

        Try
            Dim cmb As ComboboxEx = DirectCast(sender, ComboboxEx)
            If IsCheckRequired Then
                IsValidated *= ErrorProvider.UpdateErrorInfo(cmb, cmb.IsSelected, String.Format(My.Resources.infoMsgRequireSelectOrInput, "�@��"))
            End If
        Catch ex As Exception
            Throw
        End Try
    End Sub

#End Region

#Region "�Г��R�[�h"

    Private Sub CmbSYANAI_CD_SelectedValueChanged(sender As Object, e As EventArgs) Handles cmbSYANAI_CD.SelectedValueChanged
        Try

            If IsInitializing Then Exit Sub

            Dim cmb As ComboboxEx = DirectCast(sender, ComboboxEx)

            If cmbBUMON.SelectedValue.ToString.ToVal <> ENM_BUMON_KB._2_LP Then Exit Sub

            RemoveHandler cmbSYANAI_CD.SelectedValueChanged, AddressOf CmbSYANAI_CD_SelectedValueChanged

            ''���i�ԍ�
            RemoveHandler cmbBUHIN_BANGO.SelectedValueChanged, AddressOf CmbBUHIN_BANGO_SelectedValueChanged

            If cmb.IsSelected Then
                Dim drs = tblBUHIN.LazyLoad("���i�ԍ�").AsEnumerable.Where(Function(r) r.Field(Of String)(NameOf(_D009.SYANAI_CD)) = cmb.SelectedValue).ToList
                If drs.Count > 0 Then
                    cmbBUHIN_BANGO.SetDataSource(drs.CopyToDataTable, ENM_COMBO_SELECT_VALUE_TYPE._0_Required)
                    'If drs.Count = 1 Then
                    '    _D003_NCR_J.BUHIN_BANGO = drs(0).Item("DISP")
                    'Else
                    '    _D003_NCR_J.BUHIN_BANGO = ""
                    'End If
                End If
            Else
                cmbBUHIN_BANGO.SetDataSource(tblBUHIN.LazyLoad("���i�ԍ�").ExcludeDeleted, ENM_COMBO_SELECT_VALUE_TYPE._0_Required)
            End If

            AddHandler cmbBUHIN_BANGO.SelectedValueChanged, AddressOf CmbBUHIN_BANGO_SelectedValueChanged

            ''���o
            RemoveHandler cmbBUHIN_BANGO.SelectedValueChanged, AddressOf CmbBUHIN_BANGO_SelectedValueChanged
            RemoveHandler cmbKISYU.SelectedValueChanged, AddressOf CmbKISYU_SelectedValueChanged
            cmbKISYU.DataBindings.Clear()
            cmbBUHIN_BANGO.DataBindings.Clear()
            If cmb.IsSelected Then
                Dim dr = DirectCast(cmbSYANAI_CD.DataSource, DataTable).AsEnumerable.Where(Function(r) r.Field(Of String)("VALUE") = cmb.SelectedValue).FirstOrDefault
                If dr IsNot Nothing Then
                    cmbBUHIN_BANGO.SelectedValue = dr.Item(NameOf(D003_NCR_J.BUHIN_BANGO))
                    If cmbHINMEI.IsSelected Then cmbHINMEI.SelectedValue = dr.Item(NameOf(D003_NCR_J.BUHIN_NAME))
                    If dr.Item(NameOf(D003_NCR_J.KISYU_ID)) <> 0 Then cmbKISYU.SelectedValue = dr.Item(NameOf(D003_NCR_J.KISYU_ID))
                Else
                    cmbBUHIN_BANGO.IsSelected = False
                    cmbHINMEI.IsSelected = False
                    cmbKISYU.IsSelected = False
                End If
            Else
                cmbBUHIN_BANGO.IsSelected = False
                cmbHINMEI.IsSelected = False
                cmbKISYU.IsSelected = False
            End If
            AddHandler cmbBUHIN_BANGO.SelectedValueChanged, AddressOf CmbBUHIN_BANGO_SelectedValueChanged
            AddHandler cmbKISYU.SelectedValueChanged, AddressOf CmbKISYU_SelectedValueChanged
        Finally
            AddHandler cmbSYANAI_CD.SelectedValueChanged, AddressOf CmbSYANAI_CD_SelectedValueChanged
        End Try
    End Sub

    Private Sub CmbSYANAI_CD_Validating(sender As Object, e As System.ComponentModel.CancelEventArgs) Handles cmbSYANAI_CD.Validating
        If IsInitializing Then Exit Sub

        Dim cmb As ComboboxEx = DirectCast(sender, ComboboxEx)
        If cmbBUMON.SelectedValue.ToString.ToVal = Context.ENM_BUMON_KB._2_LP.Value Then
            If IsCheckRequired Then
                IsValidated *= ErrorProvider.UpdateErrorInfo(cmb, cmb.IsSelected, String.Format(My.Resources.infoMsgRequireSelectOrInput, "�Г��R�[�h"))
            End If
        End If
    End Sub

#End Region

#Region "���i�ԍ�"

    Private Sub CmbBUHIN_BANGO_SelectedValueChanged(sender As Object, e As EventArgs) Handles cmbBUHIN_BANGO.SelectedValueChanged
        If IsInitializing Then Exit Sub

        Dim cmb As ComboboxEx = DirectCast(sender, ComboboxEx)

        RemoveHandler cmbBUHIN_BANGO.SelectedValueChanged, AddressOf CmbBUHIN_BANGO_SelectedValueChanged
        RemoveHandler cmbSYANAI_CD.SelectedValueChanged, AddressOf CmbSYANAI_CD_SelectedValueChanged

        '�Г��R�[�h
        If cmb.IsSelected Then

            If Val(cmbBUMON.SelectedValue) = Context.ENM_BUMON_KB._2_LP Then
                Dim drs = tblSYANAI_CD.LazyLoad("�Г�CD").AsEnumerable.Where(Function(r) r.Field(Of String)(NameOf(_D009.BUHIN_BANGO)) = cmb.SelectedValue).ToList
                If drs.Count > 0 Then
                    Dim _selectedValue As String = cmbSYANAI_CD.SelectedValue
                    cmbSYANAI_CD.DisplayMember = "DISP"
                    cmbSYANAI_CD.ValueMember = "VALUE"
                    cmbSYANAI_CD.SetDataSource(drs.CopyToDataTable, ENM_COMBO_SELECT_VALUE_TYPE._0_Required)
                    If Not cmbSYANAI_CD.NullValue = _selectedValue Then cmbSYANAI_CD.SelectedValue = _selectedValue
                End If
            Else
                cmbSYANAI_CD.SelectedValue = ""
                'cmbSYANAI_CD.DataSource = Nothing
            End If
        Else
            cmbSYANAI_CD.SetDataSource(tblSYANAI_CD.LazyLoad("�Г�CD").ExcludeDeleted, ENM_COMBO_SELECT_VALUE_TYPE._0_Required)
        End If
        AddHandler cmbSYANAI_CD.SelectedValueChanged, AddressOf CmbSYANAI_CD_SelectedValueChanged

        '���o ����
        If cmb.IsSelected Then
            Dim dr As DataRow = DirectCast(cmbBUHIN_BANGO.DataSource, DataTable).AsEnumerable.Where(Function(r) r.Field(Of String)("VALUE") = cmb.SelectedValue).FirstOrDefault
            If Val(cmbBUMON.SelectedValue) = Context.ENM_BUMON_KB._2_LP Then
                cmbSYANAI_CD.SelectedValue = dr.Item("SYANAI_CD")
                If dr.Item("BUHIN_NAME").ToString.IsNulOrWS = False Then cmbHINMEI.Text = dr.Item("BUHIN_NAME")
            Else
                cmbHINMEI.Text = dr?.Item("BUHIN_NAME")
            End If

            RemoveHandler cmbKISYU.SelectedValueChanged, AddressOf CmbKISYU_SelectedValueChanged
            If dr?.Item("KISYU_ID") <> 0 Then cmbKISYU.SelectedValue = dr?.Item("KISYU_ID")
            AddHandler cmbKISYU.SelectedValueChanged, AddressOf CmbKISYU_SelectedValueChanged
        Else
            cmbSYANAI_CD.SelectedValue = ""
            cmbHINMEI.Text = ""
            cmbKISYU.SelectedValue = 0
        End If

        AddHandler cmbBUHIN_BANGO.SelectedValueChanged, AddressOf CmbBUHIN_BANGO_SelectedValueChanged
    End Sub

    Private Sub CmbBUHIN_BANGO_Validating(sender As Object, e As System.ComponentModel.CancelEventArgs) Handles cmbBUHIN_BANGO.Validating
        If IsInitializing Then Exit Sub

        Dim cmb As ComboboxEx = DirectCast(sender, ComboboxEx)
        If IsCheckRequired Then
            IsValidated *= ErrorProvider.UpdateErrorInfo(cmb, cmb.IsSelected, String.Format(My.Resources.infoMsgRequireSelectOrInput, "���i�ԍ�"))
        End If
    End Sub

#End Region

    Private Sub cmbBUMON_Validated(sender As Object, e As EventArgs) Handles cmbBUMON.Validated
        IsValidated *= ErrorProvider.UpdateErrorInfo(cmbBUMON, cmbBUMON.IsSelected, String.Format(My.Resources.infoMsgRequireSelectOrInput, "���i�敪"))
    End Sub

    Private Sub cmbKISO_TANTO_Validated(sender As Object, e As EventArgs) Handles cmbKISO_TANTO.Validated
        IsValidated *= ErrorProvider.UpdateErrorInfo(cmbKISO_TANTO, cmbKISO_TANTO.IsSelected, String.Format(My.Resources.infoMsgRequireSelectOrInput, "�N����"))
    End Sub

    Private Sub cmbCM_TANTO_Validated(sender As Object, e As EventArgs) Handles cmbCM_TANTO.Validated
        IsValidated *= ErrorProvider.UpdateErrorInfo(cmbCM_TANTO, cmbCM_TANTO.IsSelected, String.Format(My.Resources.infoMsgRequireSelectOrInput, "FCCB�c��"))
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
            cmbKISO_TANTO.SetDataSource(tblTANTO, ENM_COMBO_SELECT_VALUE_TYPE._0_Required)
            cmbKISYU.SetDataSource(tblKISYU.LazyLoad("�@��"), ENM_COMBO_SELECT_VALUE_TYPE._2_Option)
            cmbBUHIN_BANGO.SetDataSource(tblBUHIN.LazyLoad("���i�ԍ�"), ENM_COMBO_SELECT_VALUE_TYPE._2_Option)
            cmbSYANAI_CD.SetDataSource(tblSYANAI_CD.LazyLoad("�Г�CD").ExcludeDeleted, ENM_COMBO_SELECT_VALUE_TYPE._2_Option)

            'UNDONE: �Ɩ��O���[�v���X�g�\�[�X�擾�֐���
            Dim BUSYOList As New SortedList(Of Integer, String)
            BUSYOList.Add(0, "(���I��)")
            BUSYOList.Add(ENM_GYOMU_GROUP_ID._1_�Z�p.Value, "�Z�p")
            BUSYOList.Add(ENM_GYOMU_GROUP_ID._2_����.Value, "����")
            BUSYOList.Add(ENM_GYOMU_GROUP_ID._3_����.Value, "����")
            BUSYOList.Add(ENM_GYOMU_GROUP_ID._4_�i��.Value, "�i��")
            BUSYOList.Add(ENM_GYOMU_GROUP_ID._5_�݌v.Value, "�݌v")
            BUSYOList.Add(ENM_GYOMU_GROUP_ID._6_���Z.Value, "���Z")
            BUSYOList.Add(ENM_GYOMU_GROUP_ID._7_�Ǘ�.Value, "�Ǘ�")
            BUSYOList.Add(ENM_GYOMU_GROUP_ID._8_�c��.Value, "�c��")
            BUSYOList.Add(ENM_GYOMU_GROUP_ID._9_�w��.Value, "�w��")
            BUSYOList.Add(ENM_GYOMU_GROUP_ID._43_�i��.Value, "�i/��")
            flxDATA_2.Cols(4).DataMap = BUSYOList
            flxDATA_3.Cols(3).DataMap = BUSYOList
            flxDATA_5.Cols(3).DataMap = BUSYOList

            Select Case intMODE
                Case ENM_DATA_OPERATION_MODE._1_ADD

#Region "                  ADD"

                    mtxFCCB_NO.Text = "<�V�K>"
                    _D009.ADD_SYAIN_ID = pub_SYAIN_INFO.SYAIN_ID
                    _D009.ADD_YMDHNS = Now.ToString("yyyyMMddHHmmss")

                    If IsSysAdminUser(pub_SYAIN_INFO.SYAIN_ID) Then
                    Else
                        _D009.BUMON_KB = pub_SYAIN_INFO.BUMON_KB
                    End If

#Region "InitDS"

                    Using DB As ClsDbUtility = DBOpen()
                        Dim sbSQL As New System.Text.StringBuilder
                        Dim dsList As DataSet

                        sbSQL.Clear()
                        sbSQL.Append($"SELECT")
                        sbSQL.Append($" *")
                        sbSQL.Append($" ,'' AS {NameOf(D010.FCCB_NO)}")
                        sbSQL.Append($" ,'0' AS {NameOf(D010.YOHI_KB)}")
                        sbSQL.Append($" , 0 AS {NameOf(D010.TANTO_ID)}")
                        sbSQL.Append($" ,'' AS {NameOf(D010.NAIYO)}")
                        sbSQL.Append($" ,'' AS {NameOf(D010.GOKI)}")
                        sbSQL.Append($" ,'' AS {NameOf(D010.YOTEI_YMD)}")
                        sbSQL.Append($" ,'' AS {NameOf(D010.CLOSE_YMD)}")
                        sbSQL.Append($" FROM {NameOf(M017_FCCB_SUB_SYOCHI_KOMOKU)} ")
                        sbSQL.Append($" WHERE {NameOf(M017_FCCB_SUB_SYOCHI_KOMOKU.ITEM_NO)}<100 ")

                        dsList = DB.GetDataSet(sbSQL.ToString, conblnNonMsg)
                        Dim Sec2 As New ModelInfo(Of D010)(srcDATA:=dsList.Tables(0))
                        Flx2_DS.DataSource = Sec2.Data
                        Flx2_DS_DB = Sec2.Data.Copy

                        sbSQL.Clear()
                        sbSQL.Append($"SELECT")
                        sbSQL.Append($" *")
                        sbSQL.Append($" ,'' AS {NameOf(D010.FCCB_NO)}")
                        sbSQL.Append($" ,'0' AS {NameOf(D010.YOHI_KB)}")
                        sbSQL.Append($" , 0 AS {NameOf(D010.TANTO_ID)}")
                        sbSQL.Append($" ,'' AS {NameOf(D010.NAIYO)}")
                        sbSQL.Append($" ,'' AS {NameOf(D010.GOKI)}")
                        sbSQL.Append($" ,'' AS {NameOf(D010.YOTEI_YMD)}")
                        sbSQL.Append($" ,'' AS {NameOf(D010.CLOSE_YMD)}")
                        sbSQL.Append($" FROM {NameOf(M017_FCCB_SUB_SYOCHI_KOMOKU)} ")
                        sbSQL.Append($" WHERE {NameOf(M017_FCCB_SUB_SYOCHI_KOMOKU.ITEM_NO)}>100 ")

                        dsList = DB.GetDataSet(sbSQL.ToString, conblnNonMsg)

                        Dim Sec3 As New ModelInfo(Of D010)(srcDATA:=dsList.Tables(0))
                        Flx3_DS.DataSource = Sec3.Data
                        Flx3_DS_DB = Sec3.Data.Copy

                        sbSQL.Clear()
                        sbSQL.Append($"SELECT")
                        sbSQL.Append($"  '' AS {NameOf(D011.FCCB_NO)}")
                        sbSQL.Append($" , 0 AS {NameOf(D011.ITEM_NO)}")
                        sbSQL.Append($" ,'' AS {NameOf(D011.BUHIN_HINBAN)}")
                        sbSQL.Append($" ,'' AS {NameOf(D011.BUHIN_NAME)}")
                        sbSQL.Append($" ,'' AS {NameOf(D011.MEMO1)}")
                        sbSQL.Append($" ,'' AS {NameOf(D011.MEMO2)}")
                        sbSQL.Append($" , 0 AS {NameOf(D011.SURYO)}")
                        sbSQL.Append($" ,'' AS {NameOf(D011.SYOCHI_NAIYO)}")
                        sbSQL.Append($" , 0 AS {NameOf(D011.TANTO_GYOMU_GROUP_ID)}")
                        sbSQL.Append($" , 0 AS {NameOf(D011.TANTO_ID)}")
                        sbSQL.Append($" ,'' AS {NameOf(D011.YOTEI_YMD)}")
                        sbSQL.Append($" ,'' AS {NameOf(D011.CLOSE_YMD)}")

                        dsList = DB.GetDataSet(sbSQL.ToString, conblnNonMsg)

                        Dim Sec4 As New ModelInfo(Of D011)(srcDATA:=dsList.Tables(0))
                        For i As Integer = 1 To 4
                            Dim dr As DataRow = Sec4.Data.NewRow
                            dr.ItemArray = Sec4.Data.Rows(0).ItemArray
                            dr.Item(NameOf(D011.ITEM_NO)) = i
                            Sec4.Data.Rows.Add(dr)
                        Next
                        Sec4.Data.Rows(0).Delete()
                        Sec4.Data.AcceptChanges()
                        Flx4_DS.DataSource = Sec4.Data
                    End Using

#End Region

#End Region

                Case ENM_DATA_OPERATION_MODE._3_UPDATE

#Region "                   UPDATE"

                    _V003_SYONIN_J_KANRI_List = FunGetV003Model(Context.ENM_SYONIN_HOKOKUSYO_ID._4_FCCB, PrFCCB_NO)
                    _D009 = FunGetD009Model(PrFCCB_NO)

                    mtxFCCB_NO.Text = PrFCCB_NO
                    cmbBUMON.SelectedValue = _D009.BUMON_KB
                    Call CmbBUMON_SelectedValueChanged(cmbBUMON, Nothing)
                    cmbKISYU.SelectedValue = _D009.KISYU_ID
                    Call CmbKISYU_SelectedValueChanged(cmbKISYU, Nothing)
                    dtKISO.Value = DateTime.Parse(_D009.ADD_YMDHNS).ToString("yyyy/MM/dd")
                    cmbCM_TANTO.SelectedValue = _D009.CM_TANTO
                    cmbKISO_TANTO.SelectedValue = _D009.ADD_SYAIN_ID
                    cmbBUHIN_BANGO.SelectedValue = _D009.BUHIN_BANGO
                    Call CmbBUHIN_BANGO_SelectedValueChanged(cmbBUHIN_BANGO, Nothing)

                    If _D009.BUMON_KB = ENM_BUMON_KB._2_LP.Value Then
                        cmbSYANAI_CD.SelectedValue = _D009.SYANAI_CD
                    End If

                    cmbHINMEI.Text = _D009.BUHIN_NAME
                    mtxINPUT_DOC_NO.Text = _D009.INPUT_DOC_NO
                    mtxSNO_APPLY_PERIOD_KISO.Text = _D009.SNO_APPLY_PERIOD_KISO
                    mtxSNO_APPLY_PERIOD_HENKO_SINGI.Text = _D009.SNO_APPLY_PERIOD_HENKO_SINGI
                    txtINPUT_NAIYO.Text = _D009.INPUT_NAIYO

                    Call SetTantoColumnDataList(_D009.BUMON_KB)

                    Dim dt = FunGetSYONIN_SYOZOKU_SYAIN(_D009.BUMON_KB, Context.ENM_SYONIN_HOKOKUSYO_ID._4_FCCB, FunGetNextSYONIN_JUN(PrCurrentStage))
                    cmbDestTANTO.SetDataSource(dt, ENM_COMBO_SELECT_VALUE_TYPE._0_Required)

#Region "InitDS"

                    Using DB As ClsDbUtility = DBOpen()
                        Dim sbSQL As New System.Text.StringBuilder
                        Dim dsList As DataSet

                        sbSQL.Clear()
                        sbSQL.Append($"SELECT")
                        sbSQL.Append($"  {NameOf(D010.FCCB_NO)}")
                        sbSQL.Append($" ,{NameOf(D010.ITEM_NO)}")
                        sbSQL.Append($" ,{NameOf(D010.ITEM_GROUP_NAME)}")
                        sbSQL.Append($" ,{NameOf(D010.ITEM_NAME)}")
                        sbSQL.Append($" ,{NameOf(D010.TANTO_GYOMU_GROUP_ID)}")
                        sbSQL.Append($" ,{NameOf(D010.YOHI_KB)}")
                        sbSQL.Append($" ,{NameOf(D010.TANTO_ID)}")
                        sbSQL.Append($" ,{NameOf(D010.NAIYO)}")
                        sbSQL.Append($" ,{NameOf(D010.GOKI)}")
                        sbSQL.Append($" ,IIF({NameOf(D010.YOTEI_YMD)}='','',FORMAT(CONVERT(DATETIME, {NameOf(D010.YOTEI_YMD)}),'yyyy/MM/dd')) AS {NameOf(D010.YOTEI_YMD)}")
                        sbSQL.Append($" ,IIF({NameOf(D010.CLOSE_YMD)}='','',FORMAT(CONVERT(DATETIME, {NameOf(D010.CLOSE_YMD)}),'yyyy/MM/dd')) AS {NameOf(D010.CLOSE_YMD)}")
                        sbSQL.Append($" FROM {NameOf(D010_FCCB_SUB_SYOCHI_KOMOKU)} ")
                        sbSQL.Append($" WHERE {NameOf(D010.ITEM_NO)}<100 ")
                        sbSQL.Append($" AND {NameOf(D010.FCCB_NO)}='{_D009.FCCB_NO}' ")
                        dsList = DB.GetDataSet(sbSQL.ToString, conblnNonMsg)
                        Dim Sec2 As New ModelInfo(Of D010)(srcDATA:=dsList.Tables(0))
                        Flx2_DS.DataSource = Sec2.Data
                        Flx2_DS_DB = Sec2.Data.Copy

                        sbSQL.Clear()
                        sbSQL.Append($"SELECT")
                        sbSQL.Append($"  {NameOf(D010.FCCB_NO)}")
                        sbSQL.Append($" ,{NameOf(D010.ITEM_NO)}")
                        sbSQL.Append($" ,{NameOf(D010.ITEM_GROUP_NAME)}")
                        sbSQL.Append($" ,{NameOf(D010.ITEM_NAME)}")
                        sbSQL.Append($" ,{NameOf(D010.TANTO_GYOMU_GROUP_ID)}")
                        sbSQL.Append($" ,{NameOf(D010.YOHI_KB)}")
                        sbSQL.Append($" ,{NameOf(D010.TANTO_ID)}")
                        sbSQL.Append($" ,{NameOf(D010.NAIYO)}")
                        sbSQL.Append($" ,{NameOf(D010.GOKI)}")
                        sbSQL.Append($" ,IIF({NameOf(D010.YOTEI_YMD)}='','',FORMAT(CONVERT(DATETIME, {NameOf(D010.YOTEI_YMD)}),'yyyy/MM/dd')) AS {NameOf(D010.YOTEI_YMD)}")
                        sbSQL.Append($" ,IIF({NameOf(D010.CLOSE_YMD)}='','',FORMAT(CONVERT(DATETIME, {NameOf(D010.CLOSE_YMD)}),'yyyy/MM/dd')) AS {NameOf(D010.CLOSE_YMD)}")
                        sbSQL.Append($" FROM {NameOf(D010_FCCB_SUB_SYOCHI_KOMOKU)} ")
                        sbSQL.Append($" WHERE {NameOf(D010.ITEM_NO)}>100 ")
                        sbSQL.Append($" AND {NameOf(D010.FCCB_NO)}='{_D009.FCCB_NO}' ")
                        dsList = DB.GetDataSet(sbSQL.ToString, conblnNonMsg)

                        Dim Sec3 As New ModelInfo(Of D010)(srcDATA:=dsList.Tables(0))
                        Flx3_DS.DataSource = Sec3.Data
                        Flx3_DS_DB = Sec3.Data.Copy

                        sbSQL.Clear()
                        sbSQL.Append($"SELECT")
                        sbSQL.Append($"  {NameOf(D011.FCCB_NO)}")
                        sbSQL.Append($" ,{NameOf(D011.ITEM_NO)}")
                        sbSQL.Append($" ,{NameOf(D011.BUHIN_HINBAN)}")
                        sbSQL.Append($" ,{NameOf(D011.BUHIN_NAME)}")
                        sbSQL.Append($" ,{NameOf(D011.MEMO1)}")
                        sbSQL.Append($" ,{NameOf(D011.MEMO2)}")
                        sbSQL.Append($" ,{NameOf(D011.SURYO)}")
                        sbSQL.Append($" ,{NameOf(D011.SYOCHI_NAIYO)}")
                        sbSQL.Append($" ,{NameOf(D011.TANTO_GYOMU_GROUP_ID)}")
                        sbSQL.Append($" ,{NameOf(D011.TANTO_ID)}")
                        sbSQL.Append($" ,IIF({NameOf(D011.YOTEI_YMD)}='','',FORMAT(CONVERT(DATETIME, {NameOf(D011.YOTEI_YMD)}),'yyyy/MM/dd')) AS {NameOf(D011.YOTEI_YMD)}")
                        sbSQL.Append($" ,IIF({NameOf(D011.CLOSE_YMD)}='','',FORMAT(CONVERT(DATETIME, {NameOf(D011.CLOSE_YMD)}),'yyyy/MM/dd')) AS {NameOf(D011.CLOSE_YMD)}")
                        sbSQL.Append($" FROM {NameOf(D011_FCCB_SUB_SIKAKE_BUHIN)} ")
                        sbSQL.Append($" WHERE {NameOf(D011.FCCB_NO)}='{_D009.FCCB_NO}' ")
                        dsList = DB.GetDataSet(sbSQL.ToString, conblnNonMsg)

                        Dim Sec4 As New ModelInfo(Of D011)(srcDATA:=dsList.Tables(0))
                        Flx4_DS.DataSource = Sec4.Data
                        Flx4_DS_DB = Sec4.Data.Copy

#Region "���u�m�F�S����"

                        sbSQL.Clear()
                        sbSQL.Append($"SELECT")
                        sbSQL.Append($" *")
                        sbSQL.Append($" FROM {NameOf(D012_FCCB_SUB_SYOCHI_KAKUNIN)} ")
                        sbSQL.Append($" WHERE {NameOf(D012.FCCB_NO)}='{_D009.FCCB_NO}' ")
                        dsList = DB.GetDataSet(sbSQL.ToString, conblnNonMsg)

                        If dsList.Tables(0).Rows.Count > 0 Then

                            Dim Sec5 As New ModelInfo(Of D012)(srcDATA:=dsList.Tables(0))

                            For Each dr As DataRow In Sec5.Data.Rows
                                Dim cmb As New ComboboxEx
                                Dim dte As New DateTextBoxEx

                                Select Case dr.Item(NameOf(D012.GYOMU_GROUP_ID))
                                    Case ENM_GYOMU_GROUP_ID._2_����.Value
                                        cmb = cmbSYOCHI_SEIZO_TANTO
                                        dte = dtSYOCHI_SEIZO_TANTO

                                    Case ENM_GYOMU_GROUP_ID._3_����.Value
                                        cmb = cmbSYOCHI_KENSA_TANTO
                                        dte = dtSYOCHI_KENSA_TANTO

                                    Case ENM_GYOMU_GROUP_ID._4_�i��.Value
                                        cmb = cmbSYOCHI_HINSYO_TANTO
                                        dte = dtSYOCHI_HINSYO_TANTO

                                    Case ENM_GYOMU_GROUP_ID._5_�݌v.Value
                                        cmb = cmbSYOCHI_SEKKEI_TANTO
                                        dte = dtSYOCHI_SEKKEI_TANTO

                                    Case ENM_GYOMU_GROUP_ID._6_���Z.Value
                                        cmb = cmbSYOCHI_SEIGI_TANTO
                                        dte = dtSYOCHI_SEIGI_TANTO

                                    Case ENM_GYOMU_GROUP_ID._7_�Ǘ�.Value
                                        cmb = cmbSYOCHI_KANRI_TANTO
                                        dte = dtSYOCHI_KANRI_TANTO

                                    Case ENM_GYOMU_GROUP_ID._8_�c��.Value
                                        cmb = cmbSYOCHI_EIGYO_TANTO
                                        dte = dtSYOCHI_EIGYO_TANTO

                                    Case ENM_GYOMU_GROUP_ID._9_�w��.Value
                                        cmb = cmbSYOCHI_KOBAI_TANTO
                                        dte = dtSYOCHI_KOBAI_TANTO

                                    Case ENM_GYOMU_GROUP_ID._91_QMS�Ǘ��ӔC��.Value '�����ӔC��
                                        cmb = cmbSYOCHI_GM_TANTO
                                        dte = dtSYOCHI_GM_TANTO

                                    Case 92
                                        cmb = cmbKAKUNIN_CM_TANTO
                                        dte = dtKAKUNIN_CM_TANTO

                                    Case 93
                                        cmb = cmbKAKUNIN_GM_TANTO
                                        dte = dtKAKUNIN_GM_TANTO

                                End Select

                                cmb.SelectedValue = dr.Item(NameOf(D012.TANTO_ID))
                                If Not dr.Item(NameOf(D012.ADD_YMDHNS)).ToString.IsNulOrWS Then
                                    dte.Value = DateTime.ParseExact(dr.Item(NameOf(D012.ADD_YMDHNS)), "yyyyMMddHHmmss", Nothing).ToString("yyyy/MM/dd")
                                End If
                            Next
                        End If

#End Region

                    End Using

#End Region

                    tabMain.Visible = True

#End Region

                Case Else
                    Throw New ArgumentException("�z��O�̋N�����[�h�ł�")
            End Select



            '���s�X�e�[�W��
            lblCurrentStageName.Text = FunGetLastStageName(Context.ENM_SYONIN_HOKOKUSYO_ID._4_FCCB, _D009.FCCB_NO)

            '���u�m�F�S����

            Dim groupList = GetRequiredGyomuGroups()
            For Each gg As ENM_GYOMU_GROUP_ID In groupList
                Select Case gg
                    Case ENM_GYOMU_GROUP_ID._1_�Z�p

                    Case ENM_GYOMU_GROUP_ID._2_����
                        lblSYOCHI_SEIZO_TANTO.BackColor = Color.LemonChiffon

                    Case ENM_GYOMU_GROUP_ID._3_����
                        lblSYOCHI_KENSA_TANTO.BackColor = Color.LemonChiffon

                    Case ENM_GYOMU_GROUP_ID._4_�i��
                        lblSYOCHI_HINSYO_TANTO.BackColor = Color.LemonChiffon

                    Case ENM_GYOMU_GROUP_ID._5_�݌v
                        lblSYOCHI_SEKKEI_TANTO.BackColor = Color.LemonChiffon

                    Case ENM_GYOMU_GROUP_ID._6_���Z
                        lblSYOCHI_SEIGI_TANTO.BackColor = Color.LemonChiffon

                    Case ENM_GYOMU_GROUP_ID._7_�Ǘ�
                        lblSYOCHI_KANRI_TANTO.BackColor = Color.LemonChiffon

                    Case ENM_GYOMU_GROUP_ID._8_�c��
                        lblSYOCHI_EIGYO_TANTO.BackColor = Color.LemonChiffon

                    Case ENM_GYOMU_GROUP_ID._9_�w��
                        lblSYOCHI_KOBAI_TANTO.BackColor = Color.LemonChiffon

                    Case Else
                End Select
            Next

            '�ҏW�����ݒ�
            If _D009.ADD_SYAIN_ID = pub_SYAIN_INFO.SYAIN_ID Then
                '�N���҂͑S�ҏW��������
            Else
                USER_GYOMU_KENGEN_LIST = GetSYAIN_GYOMUGroups(pub_SYAIN_INFO.SYAIN_ID)

                '�S���Ɩ��ȊO�͕ҏW�s��
                For i As Integer = 1 To flxDATA_2.Rows.Count - 1
                    If USER_GYOMU_KENGEN_LIST.Contains(flxDATA_2.Rows(i).Item(NameOf(D010.TANTO_GYOMU_GROUP_ID))) Then
                        flxDATA_2.Rows(i).Style = Nothing
                        flxDATA_2.Rows(i).AllowEditing = True
                    Else
                        flxDATA_2.Rows(i).Style = flxDATA_2.Styles("DeletedRow")
                        flxDATA_2.Rows(i).AllowEditing = False
                    End If
                Next
                For i As Integer = 1 To flxDATA_3.Rows.Count - 1
                    If USER_GYOMU_KENGEN_LIST.Contains(flxDATA_3.Rows(i).Item(NameOf(D010.TANTO_GYOMU_GROUP_ID))) Then
                        flxDATA_3.Rows(i).Style = Nothing
                        flxDATA_3.Rows(i).AllowEditing = True
                    Else
                        flxDATA_3.Rows(i).Style = flxDATA_3.Styles("DeletedRow")
                        flxDATA_3.Rows(i).AllowEditing = False
                    End If
                Next
                For i As Integer = 1 To flxDATA_5.Rows.Count - 1
                    If USER_GYOMU_KENGEN_LIST.Contains(flxDATA_5.Rows(i).Item(NameOf(D011.TANTO_GYOMU_GROUP_ID))) Then
                        flxDATA_5.Rows(i).Style = Nothing
                        flxDATA_5.Rows(i).AllowEditing = True
                    Else
                        flxDATA_5.Rows(i).Style = flxDATA_5.Styles("DeletedRow")
                        flxDATA_5.Rows(i).AllowEditing = False
                    End If
                Next
            End If

            '�ҏW����
            Call SetFlxDATA_EditStatus(flxDATA_2)
            Call SetFlxDATA_EditStatus(flxDATA_3)
            Call SetFlxDATA_EditStatus(flxDATA_4)
            Call SetFlxDATA_EditStatus(flxDATA_5)

            '�������\��
            Dim blnCloseColumnVisibled = (PrCurrentStage >= ENM_FCCB_STAGE._40_���u�m�F.Value)
            flxDATA_2.Cols(NameOf(D010.CLOSE_YMD)).Visible = blnCloseColumnVisibled
            flxDATA_3.Cols(NameOf(D010.CLOSE_YMD)).Visible = blnCloseColumnVisibled
            flxDATA_5.Cols(NameOf(D010.CLOSE_YMD)).Visible = blnCloseColumnVisibled

            '�ҏW����
            Select Case PrCurrentStage
                Case ENM_FCCB_STAGE._10_�N������
                    tlpHeader.Enabled = (_D009.ADD_SYAIN_ID = pub_SYAIN_INFO.SYAIN_ID)
                    C1SplitterPanel5.Enabled = False

                Case ENM_FCCB_STAGE._20_���u����������
                    tlpHeader.Enabled = (_D009.ADD_SYAIN_ID = pub_SYAIN_INFO.SYAIN_ID)
                    C1SplitterPanel5.Enabled = False
                    cmdFunc2.Enabled = False

                Case ENM_FCCB_STAGE._30_�ύX�R�c
                    tlpHeader.Enabled = (_D009.ADD_SYAIN_ID = pub_SYAIN_INFO.SYAIN_ID)
                    C1SplitterPanel5.Enabled = False

                Case ENM_FCCB_STAGE._40_���u�m�F, ENM_FCCB_STAGE._41_���u�m�F_����
                    tlpHeader.Enabled = False
                    C1SplitterPanel1.Enabled = False
                    C1SplitterPanel2.Enabled = False
                    C1SplitterPanel5.Enabled = True

                Case ENM_FCCB_STAGE._50_���u��������
                    C1SplitterPanel1.Enabled = False
                    C1SplitterPanel2.Enabled = False
                    C1SplitterPanel5.Enabled = True
                    tlpHeader.Enabled = False

                Case ENM_FCCB_STAGE._60_���u���������m�F, ENM_FCCB_STAGE._61_���u���������m�F_����
                    C1SplitterPanel1.Enabled = False
                    C1SplitterPanel2.Enabled = False
                    C1SplitterPanel5.Enabled = True
                    tlpHeader.Enabled = False

                Case ENM_FCCB_STAGE._999_Closed
                    tlpHeader.Enabled = False
            End Select

            If FunGetNextSYONIN_JUN(PrCurrentStage) = ENM_FCCB_STAGE._999_Closed Then
                '�ŏI�X�e�[�W�̏ꍇ�A�\����S���җ��͔�\��

                lblDestTanto.Visible = False
                cmbDestTANTO.Visible = False
                cmdFunc2.Text = "���F(F2)"
            Else
                cmdFunc2.Text = "���F�E�\��(F2)"

                'C1SplitterPanel4.Collapsed = False
                'C1SplitterPanel4.Collapsible = True
                'C1SplitterPanel4.Enabled = False
            End If

            Return True
        Catch ex As Exception
            EM.ErrorSyori(ex, False, conblnNonMsg)
        End Try
    End Function

    '���u�ꗗ �Ɩ��O���[�v�ʒS���҃��X�g�̐ݒ�
    Private Sub SetTantoColumnDataList(selectedValue As String)

        Try

            Dim grp = [Enum].GetValues(GetType(ENM_GYOMU_GROUP_ID)).Cast(Of ENM_GYOMU_GROUP_ID)().
                             Where(Function(e) e.Value < ENM_GYOMU_GROUP_ID._91_QMS�Ǘ��ӔC��.Value)

            '���������S�̂̎Ј����擾
            Dim dt = FunGetSYOZOKU_SYAIN(selectedValue)
            Dim dtTANTO As New SortedList
            dtTANTO.Add(0, "���I��")
            For Each dr In dt.Rows
                If Not dtTANTO.Contains(dr.Item("VALUE").ToString.ToVal) Then
                    dtTANTO.Add(dr.Item("VALUE").ToString.ToVal, dr.Item("DISP"))
                End If
            Next
            flxDATA_2.Cols(NameOf(D010.TANTO_ID)).DataMap = dtTANTO
            flxDATA_3.Cols(NameOf(D010.TANTO_ID)).DataMap = dtTANTO
            flxDATA_5.Cols(NameOf(D010.TANTO_ID)).DataMap = dtTANTO

            For Each GROUP_ID In grp

                '�����Ɩ��O���[�v�𕪊�
                Dim ids = GROUP_ID.Value.ToString.ToArray

                '�ΏۋƖ��O���[�v�̎Ј��𒊏o
                Dim drs = dt.AsEnumerable.
                         Where(Function(r) ids.Contains(r.Item(NameOf(M011_SYAIN_GYOMU.GYOMU_GROUP_ID)).ToString)).
                         GroupBy(Function(r) r.Item("VALUE")).
                         Select(Function(g) g.FirstOrDefault)

                dtTANTO = New SortedList
                dtTANTO.Add(0, "���I��")
                For Each dr In drs
                    If Not dtTANTO.Contains(dr.Item("VALUE").ToString.ToVal) Then
                        dtTANTO.Add(dr.Item("VALUE").ToString.ToVal, dr.Item("DISP"))
                    End If
                Next
                If Not flxDATA_2.Styles.Contains($"dtTANTO_{GROUP_ID.Value}") Then
                    flxDATA_2.Styles.Add($"dtTANTO_{GROUP_ID.Value}")
                End If
                flxDATA_2.Styles($"dtTANTO_{GROUP_ID.Value}").DataMap = dtTANTO

                If Not flxDATA_3.Styles.Contains($"dtTANTO_{GROUP_ID.Value}") Then
                    flxDATA_3.Styles.Add($"dtTANTO_{GROUP_ID.Value}")
                End If
                flxDATA_3.Styles($"dtTANTO_{GROUP_ID.Value}").DataMap = dtTANTO

                If Not flxDATA_5.Styles.Contains($"dtTANTO_{GROUP_ID.Value}") Then
                    flxDATA_5.Styles.Add($"dtTANTO_{GROUP_ID.Value}")
                End If
                flxDATA_5.Styles($"dtTANTO_{GROUP_ID.Value}").DataMap = dtTANTO

            Next
        Catch ex As Exception
            Throw
        End Try
    End Sub

    ''' <summary>
    ''' �S���҂̃f�[�^�\�[�X�������x���ɕ\��
    ''' </summary>
    ''' <returns></returns>
    Private Function SetTANTO_TooltipInfo() As Boolean

        Call SetInfoLabelFormat(lblKISO_TANTO, $"�Ј��Ɩ��O���[�v�}�X�^{vbCr}�ȉ��̋Ɩ��O���[�v�ɓo�^���ꂽ�S����{vbCrLf}{vbCrLf}QMS�Ǘ��ӔC�ҁE�݌v�E�i�؁E���Z")
        Call SetInfoLabelFormat(lblCM_TANTO, $"���F�S���҃}�X�^{vbCr}���������ST1.�ɓo�^���ꂽ�S����")
        Call SetInfoLabelFormat(lblDestTanto, $"���F�S���҃}�X�^{vbCr}��������̓��Y�X�e�[�W�ɓo�^���ꂽ�S����")

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
            Call cmbCM_TANTO_Validated(cmbCM_TANTO, Nothing)

            If Not IsValidated Then Return False

            If enmSAVE_MODE = ENM_SAVE_MODE._2_���F�\�� Then

                Dim groupList = GetRequiredGyomuGroups()

                Select Case PrCurrentStage
                    Case ENM_FCCB_STAGE._10_�N������.Value
                    Case ENM_FCCB_STAGE._20_���u����������.Value
                        IsValidated = IsInputRequired(DisplayAlart:=True)

                    Case ENM_FCCB_STAGE._30_�ύX�R�c.Value
                        'ST2�őI�����ꂽ�����R���{�̂ݕK�{

                        For Each gg As ENM_GYOMU_GROUP_ID In groupList

                            Select Case gg
                                Case ENM_GYOMU_GROUP_ID._1_�Z�p

                                Case ENM_GYOMU_GROUP_ID._2_����
                                    IsValidated *= ErrorProvider.UpdateErrorInfo(cmbSYOCHI_SEIZO_TANTO, cmbSYOCHI_SEIZO_TANTO.IsSelected, String.Format(My.Resources.infoMsgRequireSelectOrInput, "����G�m�F�S����"))

                                Case ENM_GYOMU_GROUP_ID._3_����
                                    IsValidated *= ErrorProvider.UpdateErrorInfo(cmbSYOCHI_KENSA_TANTO, cmbSYOCHI_KENSA_TANTO.IsSelected, String.Format(My.Resources.infoMsgRequireSelectOrInput, "����G�m�F�S����"))

                                Case ENM_GYOMU_GROUP_ID._4_�i��
                                    IsValidated *= ErrorProvider.UpdateErrorInfo(cmbSYOCHI_HINSYO_TANTO, cmbSYOCHI_HINSYO_TANTO.IsSelected, String.Format(My.Resources.infoMsgRequireSelectOrInput, "�i��G�m�F�S����"))

                                Case ENM_GYOMU_GROUP_ID._5_�݌v
                                    IsValidated *= ErrorProvider.UpdateErrorInfo(cmbSYOCHI_SEKKEI_TANTO, cmbSYOCHI_SEKKEI_TANTO.IsSelected, String.Format(My.Resources.infoMsgRequireSelectOrInput, "�݌vG�m�F�S����"))

                                Case ENM_GYOMU_GROUP_ID._6_���Z
                                    IsValidated *= ErrorProvider.UpdateErrorInfo(cmbSYOCHI_SEIGI_TANTO, cmbSYOCHI_SEIGI_TANTO.IsSelected, String.Format(My.Resources.infoMsgRequireSelectOrInput, "���ZG�m�F�S����"))

                                Case ENM_GYOMU_GROUP_ID._7_�Ǘ�
                                    IsValidated *= ErrorProvider.UpdateErrorInfo(cmbSYOCHI_KANRI_TANTO, cmbSYOCHI_KANRI_TANTO.IsSelected, String.Format(My.Resources.infoMsgRequireSelectOrInput, "�Ǘ�G�m�F�S����"))

                                Case ENM_GYOMU_GROUP_ID._8_�c��
                                    IsValidated *= ErrorProvider.UpdateErrorInfo(cmbSYOCHI_EIGYO_TANTO, cmbSYOCHI_EIGYO_TANTO.IsSelected, String.Format(My.Resources.infoMsgRequireSelectOrInput, "�c��G�m�F�S����"))

                                Case ENM_GYOMU_GROUP_ID._9_�w��
                                    IsValidated *= ErrorProvider.UpdateErrorInfo(cmbSYOCHI_KOBAI_TANTO, cmbSYOCHI_KOBAI_TANTO.IsSelected, String.Format(My.Resources.infoMsgRequireSelectOrInput, "�w��G�m�F�S����"))

                                Case Else
                            End Select
                        Next

                        '�����ӔC�҂͏�ɕK�{
                        IsValidated *= ErrorProvider.UpdateErrorInfo(cmbSYOCHI_GM_TANTO, cmbSYOCHI_GM_TANTO.IsSelected, String.Format(My.Resources.infoMsgRequireSelectOrInput, "�����ӔC��"))
                End Select
            End If

            '��L�e��Validating�C�x���g�Ńt���O���X�V���A�S��OK�̏ꍇ��True
            Return IsValidated
        Catch ex As Exception
            Throw
        End Try
    End Function

#End Region

#Region "���u���ړ��̓`�F�b�N"

    ''' <summary>
    ''' �v�̑S���ڂɒS���ҁA�\��������͂���Ă��邩�`�F�b�N
    ''' </summary>
    ''' <returns></returns>
    Private Function IsInputRequired(Optional DisplayAlart As Boolean = False) As Boolean
        Try

            Dim requiredItems = DirectCast(Flx2_DS.DataSource, DataTable).
                                          AsEnumerable.
                                          Where(Function(r) r.Field(Of Boolean)(NameOf(D010.YOHI_KB)))

            For Each r As DataRow In requiredItems
                If r.Item(NameOf(D010.TANTO_ID)) = 0 Then
                    If DisplayAlart Then MessageBox.Show("�v���ڂŒS���Җ��I���̍��ڂ�����܂��B", "���̓`�F�b�N", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                    Return False

                End If

                If r.Item(NameOf(D010.YOTEI_YMD)) = "" Then
                    If DisplayAlart Then MessageBox.Show("�v���ڂŊ����\��������͂̍��ڂ�����܂��B", "���̓`�F�b�N", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                    Return False
                End If
            Next

            Dim requiredItems2 = DirectCast(Flx3_DS.DataSource, DataTable).
                                                                AsEnumerable.
                                                                Where(Function(r) r.Field(Of Boolean)(NameOf(D010.YOHI_KB)))

            Return True
        Catch ex As Exception
            Throw
        End Try
    End Function

    ''' <summary>
    ''' �v�̑S���ڂɒS���ҁA�\��������͂���Ă��邩�`�F�b�N
    ''' </summary>
    ''' <returns></returns>
    Private Function IsInputRequired_DB() As Boolean
        Try
            Dim sbSQL As New System.Text.StringBuilder
            Dim intRET As Integer

            sbSQL.Append($"SELECT")
            sbSQL.Append($" COUNT(FCCB_NO)")
            sbSQL.Append($" FROM {NameOf(D010_FCCB_SUB_SYOCHI_KOMOKU)} ")
            sbSQL.Append($" WHERE {NameOf(D010.FCCB_NO)}={_D009.FCCB_NO}")
            sbSQL.Append($" AND {NameOf(D010.YOHI_KB)}='1'")
            sbSQL.Append($" AND ({NameOf(D010.TANTO_ID)}=0 OR TRIM({NameOf(D010.YOTEI_YMD)})='')")

            Using DB As ClsDbUtility = DBOpen()
                intRET = DB.ExecuteScalar(sbSQL.ToString, conblnNonMsg).ToVal
            End Using

            Return (intRET = 0)
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

    Private Function GetRequiredGyomuGroups() As List(Of ENM_GYOMU_GROUP_ID)

        Try
            Dim groups = DirectCast(Flx2_DS.DataSource, DataTable).
                                      AsEnumerable.
                                      Where(Function(r) r.Field(Of Boolean)(NameOf(D010.YOHI_KB))).
                                      Select(Function(r) r.Field(Of ENM_GYOMU_GROUP_ID)(NameOf(D010.TANTO_GYOMU_GROUP_ID))).
                                      Distinct

            Dim groups2 = DirectCast(Flx3_DS.DataSource, DataTable).
                                            AsEnumerable.
                                            Where(Function(r) r.Field(Of Boolean)(NameOf(D010.YOHI_KB))).
                                            Select(Function(r) r.Field(Of ENM_GYOMU_GROUP_ID)(NameOf(D010.TANTO_GYOMU_GROUP_ID))).
                                            Distinct

            Dim groupList = groups.Union(groups2).ToList
            If groupList.Contains(ENM_GYOMU_GROUP_ID._43_�i��) Then
                '�Ɩ��O���[�v��W�J
                If Not groupList.Contains(ENM_GYOMU_GROUP_ID._4_�i��) Then
                    groupList.Add(ENM_GYOMU_GROUP_ID._4_�i��)
                End If
                If Not groupList.Contains(ENM_GYOMU_GROUP_ID._3_����) Then
                    groupList.Add(ENM_GYOMU_GROUP_ID._3_����)
                End If
            End If

            Return groupList
        Catch ex As Exception
            Throw
        End Try
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

            Select Case intSYONIN_JUN
                Case ENM_FCCB_STAGE._10_�N������
                    Dim dt = FunGetSYONIN_SYOZOKU_SYAIN(_D009.BUMON_KB, Context.ENM_SYONIN_HOKOKUSYO_ID._4_FCCB, ENM_FCCB_STAGE._20_���u����������)
                    ToUsers = dt.AsEnumerable.Select(Function(r) r.Field(Of Integer)("VALUE")).ToList

                Case ENM_FCCB_STAGE._20_���u����������
                    'FCCB�c�� �N����
                    ToUsers.Add(_D009.CM_TANTO)
                    ToUsers.Add(_D009.ADD_SYAIN_ID)
                    '����\
                    ToUsers.Add(pub_SYAIN_INFO.SYAIN_ID)

                Case ENM_FCCB_STAGE._30_�ύX�R�c

                    ToUsers.Add(cmbCM_TANTO.SelectedValue)

                    If cmbSYOCHI_SEKKEI_TANTO.IsSelected Then
                        ToUsers.Add(cmbSYOCHI_SEKKEI_TANTO.SelectedValue)
                    End If
                    If cmbSYOCHI_SEIGI_TANTO.IsSelected Then
                        ToUsers.Add(cmbSYOCHI_SEIGI_TANTO.SelectedValue)
                    End If
                    If cmbSYOCHI_EIGYO_TANTO.IsSelected Then
                        ToUsers.Add(cmbSYOCHI_EIGYO_TANTO.SelectedValue)
                    End If
                    If cmbSYOCHI_KANRI_TANTO.IsSelected Then
                        ToUsers.Add(cmbSYOCHI_KANRI_TANTO.SelectedValue)
                    End If
                    If cmbSYOCHI_SEIZO_TANTO.IsSelected Then
                        ToUsers.Add(cmbSYOCHI_SEIZO_TANTO.SelectedValue)
                    End If
                    If cmbSYOCHI_HINSYO_TANTO.IsSelected Then
                        ToUsers.Add(cmbSYOCHI_HINSYO_TANTO.SelectedValue)
                    End If

                Case ENM_FCCB_STAGE._40_���u�m�F

                    ToUsers.Add(cmbCM_TANTO.SelectedValue)

                    Dim IsAllChecked As Boolean = True
                    If cmbSYOCHI_SEKKEI_TANTO.IsSelected AndAlso dtSYOCHI_SEKKEI_TANTO.Text.IsNulOrWS Then
                        IsAllChecked *= False
                    End If
                    If cmbSYOCHI_SEIGI_TANTO.IsSelected AndAlso dtSYOCHI_SEIGI_TANTO.Text.IsNulOrWS Then
                        IsAllChecked *= False
                    End If
                    If cmbSYOCHI_EIGYO_TANTO.IsSelected AndAlso dtSYOCHI_EIGYO_TANTO.Text.IsNulOrWS Then
                        IsAllChecked *= False
                    End If
                    If cmbSYOCHI_KANRI_TANTO.IsSelected AndAlso dtSYOCHI_KANRI_TANTO.Text.IsNulOrWS Then
                        IsAllChecked *= False
                    End If
                    If cmbSYOCHI_SEIZO_TANTO.IsSelected AndAlso dtSYOCHI_SEIZO_TANTO.Text.IsNulOrWS Then
                        IsAllChecked *= False
                    End If
                    If cmbSYOCHI_HINSYO_TANTO.IsSelected AndAlso dtSYOCHI_HINSYO_TANTO.Text.IsNulOrWS Then
                        IsAllChecked *= False
                    End If
                    If IsAllChecked AndAlso dtSYOCHI_GM_TANTO.Text.IsNulOrWS Then
                        '�S�Ă̒S���҂̃`�F�b�N�����������瓝���ӔC�҂Ɉ˗����M
                        ToUsers.Add(cmbSYOCHI_GM_TANTO.SelectedValue)
                    Else
                        '�����ӔC�҂̃`�F�b�N������������A�e�v���u�����̒S���҂Ɉ˗����M
                        Dim targetUsers = DirectCast(Flx2_DS.DataSource, DataTable).
                                                AsEnumerable.
                                                Where(Function(r) r.Field(Of Boolean)(NameOf(D010.YOHI_KB)) And Not r.Item(NameOf(D010.YOTEI_YMD)).ToString.IsNulOrWS).
                                                Select(Function(r) r.Field(Of Integer)(NameOf(D010.TANTO_ID)))

                        For Each usr In targetUsers
                            If Not ToUsers.Contains(usr) Then
                                ToUsers.Add(usr)
                            End If
                        Next

                        targetUsers = DirectCast(Flx3_DS.DataSource, DataTable).
                                                AsEnumerable.
                                                Where(Function(r) r.Field(Of Boolean)(NameOf(D010.YOHI_KB)) And Not r.Item(NameOf(D010.YOTEI_YMD)).ToString.IsNulOrWS).
                                                Select(Function(r) r.Field(Of Integer)(NameOf(D010.TANTO_ID)))

                        For Each usr In targetUsers
                            If Not ToUsers.Contains(usr) Then
                                ToUsers.Add(usr)
                            End If
                        Next

                        targetUsers = DirectCast(Flx4_DS.DataSource, DataTable).
                                                AsEnumerable.
                                                Where(Function(r) Not r.Item(NameOf(D011.YOTEI_YMD)).ToString.IsNulOrWS).
                                                Select(Function(r) r.Field(Of Integer)(NameOf(D011.TANTO_ID)))

                        For Each usr In targetUsers
                            If Not ToUsers.Contains(usr) Then
                                ToUsers.Add(usr)
                            End If
                        Next
                    End If

                Case ENM_FCCB_STAGE._50_���u��������
                    '�������ɂĊe�v���u�����̊�������1�T�ԑO�ɂȂ��Ă������u�̏ꍇ�A���u�S���҂ɑؗ��ʒm

                    Dim IsClosed As Boolean = True
                    IsClosed *= DirectCast(Flx2_DS.DataSource, DataTable).
                                               AsEnumerable.
                                               Where(Function(r) r.Field(Of Boolean)(NameOf(D010.YOHI_KB)) And r.Item(NameOf(D010.CLOSE_YMD)).ToString.IsNulOrWS).Count = 0

                    IsClosed *= DirectCast(Flx3_DS.DataSource, DataTable).
                                            AsEnumerable.
                                            Where(Function(r) r.Field(Of Boolean)(NameOf(D010.YOHI_KB)) And r.Item(NameOf(D010.CLOSE_YMD)).ToString.IsNulOrWS).Count = 0

                    IsClosed *= DirectCast(Flx4_DS.DataSource, DataTable).
                                            AsEnumerable.
                                            Where(Function(r) r.Item(NameOf(D011.CLOSE_YMD)).ToString.IsNulOrWS).Count = 0

                    '�S�v���u�����̏��u����
                    If IsClosed Then
                        'FCCB�c���Ɉ˗��ʒm
                        If dtKAKUNIN_CM_TANTO.Text.IsNulOrWS Then
                            ToUsers.Add(_D009.CM_TANTO)
                        Else
                            ToUsers.Add(cmbSYOCHI_GM_TANTO.SelectedValue)
                        End If
                    End If

                Case Else
                    Throw New ArgumentException("�z��O�̏��F���[�g�ł�", PrCurrentStage)
            End Select

            Return ToUsers.Contains(pub_SYAIN_INFO.SYAIN_ID)
        Catch ex As Exception
            Throw
        End Try

    End Function

#End Region

End Class