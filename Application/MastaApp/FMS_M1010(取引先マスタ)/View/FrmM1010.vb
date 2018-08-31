Imports JMS_COMMON.ClsPubMethod

Public Class FrmM1010

#Region "�萔�E�ϐ�"
    Private pri_objPrevCellValue As Object
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

        Me.Icon = My.Resources._icoBase_cog32x32
        Me.ShowIcon = True
    End Sub
#End Region

#Region "Form�֘A"

    'Load�C�x���g
    Private Sub FrmLoad(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        Try
            '-----�t�H�[�������ݒ�(�e�t�H�[������Ăяo��)
            Call FunFormCommonSetting(pub_APP_INFO, pub_SYAIN_INFO, My.Application.Info.Version.ToString)
            '-----�O���b�h�����ݒ�(�e�t�H�[������Ăяo��)
            Call FunInitializeDataGridView(dgvDATA)

            '-----�O���b�h��쐬
            Call FunSetDgvCulumns(dgvDATA)

            '-----�R���g���[���f�[�^�\�[�X�ݒ�
            cmbTORI_KB.SetDataSource(tblTORI_KB.ExcludeDeleted, ENM_COMBO_SELECT_VALUE_TYPE._1_Filter)
            '-----�R���{�{�b�N�X����l�̐ݒ�
            'cmbTORI_KBN.SetDefaultValue()
            '-----�C�x���g�n���h���ݒ�
            AddHandler cmbTORI_KB.SelectedValueChanged, AddressOf SearchFilterValueChanged
            AddHandler chkDeletedRowVisibled.CheckedChanged, AddressOf SearchFilterValueChanged


            '�������s
            Me.cmdFunc1.PerformClick()

        Catch ex As Exception
            EM.ErrorSyori(ex, False, conblnNonMsg)
        Finally

        End Try
    End Sub

#End Region

#Region "DataGridView�֘A"

    '�t�B�[���h��`
    Private Function FunSetDgvCulumns(ByVal dgv As DataGridView) As Boolean

        Try
            With dgv
                .RowCount = 0
                .ColumnCount = 0

                .Columns.Add("TORI_ID", "�����ID")
                .Columns(.ColumnCount - 1).Width = 90
                .Columns(.ColumnCount - 1).DefaultCellStyle.Alignment = Windows.Forms.DataGridViewContentAlignment.MiddleRight

                .Columns.Add("TORI_NAME", "����於")
                .Columns(.ColumnCount - 1).Width = 210
                .Columns(.ColumnCount - 1).DefaultCellStyle.Alignment = Windows.Forms.DataGridViewContentAlignment.MiddleLeft

                .Columns.Add("TORI_KB_DISP", "����敪")
                .Columns(.ColumnCount - 1).Width = 120
                .Columns(.ColumnCount - 1).DefaultCellStyle.Alignment = Windows.Forms.DataGridViewContentAlignment.MiddleCenter

                .Columns.Add("POST", "�X�֔ԍ�")
                .Columns(.ColumnCount - 1).Width = 80
                .Columns(.ColumnCount - 1).DefaultCellStyle.Alignment = Windows.Forms.DataGridViewContentAlignment.MiddleCenter

                .Columns.Add("ADD1", "�Z��1")
                .Columns(.ColumnCount - 1).Width = 180
                .Columns(.ColumnCount - 1).DefaultCellStyle.Alignment = Windows.Forms.DataGridViewContentAlignment.MiddleLeft

                .Columns.Add("ADD2", "�Z��2")
                .Columns(.ColumnCount - 1).Width = 180
                .Columns(.ColumnCount - 1).DefaultCellStyle.Alignment = Windows.Forms.DataGridViewContentAlignment.MiddleLeft

                .Columns.Add("ADD3", "�Z��3")
                .Columns(.ColumnCount - 1).Width = 180
                .Columns(.ColumnCount - 1).DefaultCellStyle.Alignment = Windows.Forms.DataGridViewContentAlignment.MiddleLeft

                .Columns.Add("TEL", "TEL")
                .Columns(.ColumnCount - 1).Width = 120
                .Columns(.ColumnCount - 1).DefaultCellStyle.Alignment = Windows.Forms.DataGridViewContentAlignment.MiddleCenter

                .Columns.Add("FAX", "FAX")
                .Columns(.ColumnCount - 1).Width = 120
                .Columns(.ColumnCount - 1).DefaultCellStyle.Alignment = Windows.Forms.DataGridViewContentAlignment.MiddleCenter


                .Columns.Add("ADD_YMDHNS", "�ǉ�����")
                .Columns(.ColumnCount - 1).Visible = False

                .Columns.Add("ADD_SYAIN_ID", "�ǉ��S��ID")
                .Columns(.ColumnCount - 1).Visible = False

                .Columns.Add("UPD_YMDHNS", "�X�V����")
                .Columns(.ColumnCount - 1).Visible = False

                .Columns.Add("UPD_SYAIN_ID", "�X�V�S��ID")
                .Columns(.ColumnCount - 1).Visible = False

                Dim cmbclmn1 As New DataGridViewCheckBoxColumn With {
                .Name = "DEL_FLG",
                .HeaderText = "�폜��",
                .Width = 30
                }
                cmbclmn1.DefaultCellStyle.Alignment = Windows.Forms.DataGridViewContentAlignment.MiddleCenter
                .Columns.Add(cmbclmn1)
                .Columns(.ColumnCount - 1).SortMode = DataGridViewColumnSortMode.Automatic

                .Columns.Add("DEL_YMDHNS", "�폜����")
                .Columns(.ColumnCount - 1).Visible = False

                .Columns.Add("DEL_SYAIN_ID", "�폜�S��ID")
                .Columns(.ColumnCount - 1).Visible = False

                '-----�o�C���f�B���O
                .AutoGenerateColumns = False
                .Columns("TORI_ID").DataPropertyName = "TORI_ID"
                .Columns("TORI_NAME").DataPropertyName = "TORI_NAME"
                .Columns("TORI_KB_DISP").DataPropertyName = "TORI_KB_DISP"
                .Columns("POST").DataPropertyName = "POST"
                .Columns("ADD1").DataPropertyName = "ADD1"
                .Columns("ADD2").DataPropertyName = "ADD2"
                .Columns("ADD3").DataPropertyName = "ADD3"
                .Columns("TEL").DataPropertyName = "TEL"
                .Columns("FAX").DataPropertyName = "FAX"
                .Columns("ADD_YMDHNS").DataPropertyName = "ADD_YMDHNS"
                .Columns("ADD_SYAIN_ID").DataPropertyName = "ADD_SYAIN_ID"
                .Columns("UPD_YMDHNS").DataPropertyName = "UPD_YMDHNS"
                .Columns("UPD_SYAIN_ID").DataPropertyName = "UPD_SYAIN_ID"
                .Columns("DEL_YMDHNS").DataPropertyName = "DEL_YMDHNS"
                .Columns("DEL_SYAIN_ID").DataPropertyName = "DEL_SYAIN_ID"
                .Columns("DEL_FLG").DataPropertyName = "DEL_FLG"
            End With

            Return True
        Catch ex As Exception
            EM.ErrorSyori(ex, False, conblnNonMsg)
            Return False
        End Try
    End Function

    '�O���b�h�Z��(�s)�_�u���N���b�N���C�x���g
    Private Sub DgvDATA_CellDoubleClick(sender As System.Object, e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvDATA.CellDoubleClick
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
    Private Overloads Sub DgvDATA_SelectionChanged(sender As System.Object, e As System.EventArgs) Handles dgvDATA.SelectionChanged
        Try
        Finally
            Call FunInitFuncButtonEnabled(Me)
        End Try
    End Sub

#End Region

#Region "�ҏW�\�Z��OnMouse���J�[�\���ύX"
    Private Sub Dgv_CellMouseMove(sender As Object, e As DataGridViewCellMouseEventArgs)
        Dim dgv As DataGridView = DirectCast(sender, DataGridView)
        If e.RowIndex >= 0 AndAlso dgv(e.ColumnIndex, e.RowIndex).ReadOnly = False Then
            Select Case dgv.Columns(e.ColumnIndex).Name
                Case "ZOKUSEI_K_CD"
                    dgv.Cursor = Cursors.Hand
                Case Else
                    dgv.Cursor = Cursors.Default
            End Select
        End If
    End Sub

    Private Sub Dgv_CellMouseLeave(sender As Object, e As DataGridViewCellEventArgs)
        Dim dgv As DataGridView = DirectCast(sender, DataGridView)
        dgv.Cursor = Cursors.Default
    End Sub
#End Region

#Region "FunctionButton�֘A"

#Region "�{�^���N���b�N�C�x���g"
    Private Sub CmdFunc_Click(ByVal sender As Object, ByVal e As EventArgs) Handles cmdFunc1.Click, cmdFunc2.Click, cmdFunc3.Click, cmdFunc4.Click, cmdFunc5.Click, cmdFunc6.Click, cmdFunc7.Click, cmdFunc8.Click, cmdFunc9.Click, cmdFunc10.Click, cmdFunc11.Click, cmdFunc12.Click

        Dim intFUNC As Integer
        Dim intCNT As Integer
        Try
            '�{�^���s��/�{�^��INDEX�擾
            For intCNT = 0 To Me.cmdFunc.Length - 1
                Me.cmdFunc(intCNT).Enabled = False
                If cmdFunc(intCNT) Is sender Then intFUNC = intCNT + 1
            Next

            '�{�^��INDEX���̏���
            Select Case intFUNC
                Case 1  '����
                    Call FunSetDgvData(Me.dgvDATA, FunSRCH())
                Case 2  '�ǉ�
                    '[������]
                    Me.PrPG_STATUS = ENM_PG_STATUS._3_PROCESSING

                    If FunUpdateEntity(ENM_DATA_OPERATION_MODE._1_ADD) = True Then
                        Call FunSetDgvData(Me.dgvDATA, FunSRCH())
                    End If

                Case 3  '�Q�ƒǉ�
                    '[������]
                    Me.PrPG_STATUS = ENM_PG_STATUS._3_PROCESSING

                    If FunUpdateEntity(ENM_DATA_OPERATION_MODE._2_ADDREF) = True Then
                        Call FunSetDgvData(Me.dgvDATA, FunSRCH())
                    End If

                Case 4  '�ύX
                    '[������]
                    Me.PrPG_STATUS = ENM_PG_STATUS._3_PROCESSING

                    If FunUpdateEntity(ENM_DATA_OPERATION_MODE._3_UPDATE) = True Then
                        Call FunSetDgvData(Me.dgvDATA, FunSRCH())
                    End If

                Case 5, 6  '�폜/����/���S�폜
                    '[������]
                    Me.PrPG_STATUS = ENM_PG_STATUS._3_PROCESSING

                    Dim btn As Button = DirectCast(sender, Button)
                    Dim ENM_MODE As ENM_DATA_OPERATION_MODE = DirectCast(btn.Tag, ENM_DATA_OPERATION_MODE)
                    If FunDEL(ENM_MODE) = True Then
                        Call FunSetDgvData(Me.dgvDATA, FunSRCH())
                    End If
                Case 10  'CSV�o��
                    '[������]
                    MyBase.PrPG_STATUS = ENM_PG_STATUS._3_PROCESSING

                    Dim strFileName As String = pub_APP_INFO.strTitle & "_" & DateTime.Today.ToString("yyyyMMdd") & ".CSV"
                    Call FunCSV_OUT(Me.dgvDATA.DataSource, strFileName, pub_APP_INFO.strOUTPUT_PATH)
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
            Call FunInitFuncButtonEnabled(Me)

            '[�A�N�e�B�u]
            Me.PrPG_STATUS = ENM_PG_STATUS._2_ACTIVE
        End Try

    End Sub

#End Region

#Region "����"
    Private Function FunSRCH() As DataTable
        Dim dsList As New System.Data.DataSet
        Dim sbSQL As New System.Text.StringBuilder
        Dim sbSQLWHERE As New System.Text.StringBuilder
        Dim waitDlg As WaitDialog = Nothing
        'Dim lngCURROW As Long = 0
        '-----�����m�F
        sbSQL.Remove(0, sbSQL.Length)
        sbSQL.Append("SELECT COUNT(*) FROM " & NameOf(MODEL.VWM101_TORIHIKI) & "")
        sbSQL.Append(sbSQLWHERE)
        '----WHERE��쐬
        sbSQLWHERE.Remove(0, sbSQLWHERE.Length)

        '����敪
        If Me.cmbTORI_KB.Selected Then
            If sbSQLWHERE.Length = 0 Then
                sbSQLWHERE.Append(" WHERE TORI_KB = '" & Me.cmbTORI_KB.SelectedValue & "' ")
            Else
                sbSQLWHERE.Append(" AND TORI_KB =  '" & Me.cmbTORI_KB.SelectedValue & "' ")

            End If
        Else

        End If

        '����於����
        If mtxTORI_NAME.Text.IsNullOrWhiteSpace = False Then

            If sbSQLWHERE.Length = 0 Then
                sbSQLWHERE.Append(" WHERE TORI_NAME LIKE '%" & Me.mtxTORI_NAME.Text.Trim & "%' ")
            Else
                sbSQLWHERE.Append(" AND TORI_NAME LIKE '%" & Me.mtxTORI_NAME.Text.Trim & "%' ")

            End If
        End If

        If Me.chkDeletedRowVisibled.Checked = False Then
            If sbSQLWHERE.Length = 0 Then
                sbSQLWHERE.Append(" WHERE DEL_FLG <> 1 ")
            Else
                sbSQLWHERE.Append(" AND DEL_FLG <> 1 ")
            End If
            dgvDATA.Columns("DEL_FLG").Visible = False
        Else
            dgvDATA.Columns("DEL_FLG").Visible = True
        End If

        'SQL
        sbSQL.Remove(0, sbSQL.Length)
        sbSQL.Append("SELECT")
        sbSQL.Append(" *")
        sbSQL.Append(" FROM " & priTableName & " ")
        sbSQL.Append(sbSQLWHERE)
        sbSQL.Append(" ORDER BY TORI_ID ")

        Using DB As ClsDbUtility = DBOpen()
            dsList = DB.GetDataSet(sbSQL.ToString, conblnNonMsg)
        End Using

        If dsList.Tables(0).Rows.Count > pub_APP_INFO.intSEARCHMAX Then
            If MessageBox.Show(My.Resources.infoSearchCountOver, "", MessageBoxButtons.YesNo, MessageBoxIcon.Information) = Windows.Forms.DialogResult.No Then
                Return Nothing
            End If
        End If


        '------DataTable�ɕϊ�
        Dim _Model As New MODEL.ModelInfo(Of MODEL.VWM101_TORIHIKI)(srcDATA:=dsList.Tables(0))
        Return _Model.Data

    End Function

    Private Function FunSetDgvData(ByVal dgv As DataGridView, ByVal dt As DataTable) As Boolean

        Dim waitDlg As WaitDialog = Nothing
        Dim lngCURROW As Long = 0
        Try
            If dt Is Nothing Then
                Return False
            End If

            '-----�I���s�L��
            If dgv.RowCount > 0 Then
                lngCURROW = dgv.CurrentRow.Index
            End If

            '-----�i�s�󋵃_�C�A���O
            waitDlg = New WaitDialog()
            With waitDlg
                .Owner = Me
                .MainMsg = My.Resources.infoMsgProgressStatus
                .ProgressMax = 0  ' �S�̂̏�������
                .ProgressMin = 0 ' ���������̍ŏ��l�i0������J�n�j
                .ProgressStep = 1 ' �������ƂɃ��[�^�[��i�߂邩
                .ProgressValue = 0 ' �ŏ��̌���
                .SubMsg = ""
                .ProgressMsg = My.Resources.infoToolTipMsgSearching
                '�\��
                waitDlg.Show()
            End With

            Me.dgvDATA.DataSource = dt

            ' Call DgvDATA_SelectionChanged(Me.dgvDATA, Nothing)
            Call FunSetDgvCellFormat(Me.dgvDATA)
            If dgv.RowCount > 0 Then
                '-----�I���s�ݒ�
                Try
                    dgv.CurrentCell = dgv.Rows(lngCURROW).Cells(0)
                Catch dgvEx As Exception
                End Try

                Me.lblRecordCount.Text = String.Format(My.Resources.infoToolTipMsgFoundData, dgv.RowCount.ToString) '.PadLeft(5)
            Else
                Me.lblRecordCount.Text = My.Resources.infoSearchResultNotFound
            End If

            Return True

        Catch ex As Exception
            EM.ErrorSyori(ex, False, conblnNonMsg)
            Return False

        Finally
            '-----�J��
            If waitDlg IsNot Nothing Then
                waitDlg.Close()
            End If

            '-----�ꗗ��
            dgv.Visible = True
        End Try
    End Function

    'Private Function FunGetZOKUSEI_ConditionString(ByVal dgv As DataGridView) As String
    '    Dim strRET As String = ""
    '    Dim sbSQL As New System.Text.StringBuilder

    '    Dim ar = [Enum].GetValues(GetType(Context.ENM_ZOKUSEI_KB))


    '    For Each row As DataGridViewRow In dgv.Rows
    '        If row.Cells("ZOKUSEI_K_CD").Value <> "" Then
    '            If sbSQL.Length > 0 Then
    '                sbSQL.Append(" OR ")
    '            End If
    '            sbSQL.Append(String.Format("(ZOKUSEI_CD={0} AND ZOKUSEI_K_CD={1})",
    '                            row.Cells("ZOKUSEI_CD").Value,
    '                            row.Cells("ZOKUSEI_K_CD").Value.ToString.Split(",")(1)))
    '        End If
    '    Next row

    '    If sbSQL.Length > 0 Then
    '        strRET = " AND (" & sbSQL.ToString & ")"
    '    End If
    '    Return strRET
    'End Function

    Private Function FunSetDgvCellFormat(ByVal dgv As DataGridView) As Boolean
        Try
            Dim strFieldList As New List(Of String)
            strFieldList.AddRange(New String() {"DEL_FLG"})

            For i As Integer = 0 To dgv.Rows.Count - 1
                With dgv.Rows(i)
                    For Each field As String In strFieldList

                        If Me.dgvDATA.Rows(i).Cells("DEL_FLG").Value = True Then
                            Me.dgvDATA.Rows(i).DefaultCellStyle.ForeColor = clrDeletedRowForeColor
                            Me.dgvDATA.Rows(i).DefaultCellStyle.BackColor = clrDeletedRowBackColor
                            Me.dgvDATA.Rows(i).DefaultCellStyle.SelectionForeColor = clrDeletedRowForeColor
                        Else
                        End If
                    Next
                End With
            Next i
        Catch ex As Exception
            EM.ErrorSyori(ex, False, conblnNonMsg)
        End Try
    End Function

#Region "�ǉ��E�ύX"
    ''' <summary>
    ''' ���R�[�h�ǉ��ύX����
    ''' </summary>
    ''' <param name="intMODE">�������[�h</param>
    ''' <returns></returns>
    Private Function FunUpdateEntity(ByVal intMODE As ENM_DATA_OPERATION_MODE) As Boolean

        Dim dlgRET As DialogResult
        Dim PKeys As Integer
        Try
            Using frmDLG As New FrmM1011
                frmDLG.PrMODE = intMODE
                If Me.dgvDATA.CurrentRow IsNot Nothing Then
                    frmDLG.PrDataRow = dgvDATA.GetDataRow
                Else
                    frmDLG.PrDataRow = Nothing
                End If
                dlgRET = frmDLG.ShowDialog(Me)
                PKeys = frmDLG.PrPKeys
            End Using

            If dlgRET = Windows.Forms.DialogResult.Cancel Then
                Return False
            Else

                '�ǉ������R�[�h�̍s��I������
                For i As Integer = 0 To Me.dgvDATA.RowCount - 1
                    With Me.dgvDATA.Rows(i)
                        If .Cells(0).Value = PKeys Then
                            Me.dgvDATA.CurrentCell = .Cells(0)
                            Exit For
                        End If
                    End With
                Next i

            End If

            Return True
        Catch ex As Exception
            EM.ErrorSyori(ex, False, conblnNonMsg)
            Return False
        End Try
    End Function
#End Region

#End Region

#Region "�폜"
    Private Function FunDEL(ByVal ENM_MODE As ENM_DATA_OPERATION_MODE) As Boolean
        Dim sbSQL As New System.Text.StringBuilder
        Dim strMsg As String
        Dim strTitle As String
        Try
            sbSQL.Remove(0, sbSQL.Length)
            Select Case ENM_MODE
                Case ENM_DATA_OPERATION_MODE._4_DISABLE
                    sbSQL.Append("UPDATE " & NameOf(MODEL.VWM101_TORIHIKI) & " SET ")
                    '�ύX����
                    sbSQL.Append(" UPD_YMDHNS = dbo.GetSysDateString() ")
                    '�폜����
                    sbSQL.Append(" ,DEL_YMDHNS = dbo.GetSysDateString() ")
                    '�X�V�Ј�ID
                    sbSQL.Append(" ,DEL_SYAIN_ID = " & pub_SYAIN_INFO.SYAIN_ID & "")

                    strMsg = My.Resources.infoMsgDeleteOperationDisable
                    strTitle = My.Resources.infoTitleDeleteOperationDisable

                Case ENM_DATA_OPERATION_MODE._5_RESTORE
                    sbSQL.Append("UPDATE " & NameOf(MODEL.VWM101_TORIHIKI) & " SET ")
                    '�ύX����
                    sbSQL.Append(" UPD_YMDHNS = dbo.GetSysDateString() ")
                    '�폜����
                    sbSQL.Append(" ,DEL_YMDHNS = ' ' ")
                    '�X�V�Ј�ID
                    sbSQL.Append(" ,DEL_SYAIN_ID = " & pub_SYAIN_INFO.SYAIN_ID & "")

                    strMsg = My.Resources.infoMsgDeleteOperationRestore
                    strTitle = My.Resources.infoTitleDeleteOperationRestore

                Case ENM_DATA_OPERATION_MODE._6_DELETE

                    sbSQL.Append("DELETE FROM " & NameOf(MODEL.VWM101_TORIHIKI) & " ")

                    strMsg = My.Resources.infoMsgDeleteOperationDelete
                    strTitle = My.Resources.infoTitleDeleteOperationDelete

                Case Else
                    'UNDONE: argument null exception
                    Return False
            End Select
            sbSQL.Append(" WHERE")
            sbSQL.Append(" TORI_ID = '" & Me.dgvDATA.CurrentRow.Cells.Item("TORI_ID").Value & "' ")

            '�m�F���b�Z�[�W�\��
            If MessageBox.Show(strMsg, strTitle, MessageBoxButtons.YesNo, MessageBoxIcon.Question) <> Windows.Forms.DialogResult.Yes Then
                Me.DialogResult = Windows.Forms.DialogResult.Cancel
                'Me.Close()
                Return False
            End If

            Using DB As ClsDbUtility = DBOpen()
                Dim intRET As Integer
                Dim blnErr As Boolean
                Dim sqlEx As Exception = Nothing
                Try
                    '-----�g�����U�N�V�����J�n
                    DB.BeginTransaction()

                    intRET = DB.ExecuteNonQuery(sbSQL.ToString, conblnNonMsg, sqlEx)
                    If intRET <> 1 Then
                        '�G���[���O
                        Dim strErrMsg As String = My.Resources.ErrLogSqlExecutionFailure & sbSQL.ToString & "|" & sqlEx.Message
                        WL.WriteLogDat(strErrMsg)
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
    Public Function FunInitFuncButtonEnabled(ByVal frm As FrmM1010) As Boolean

        Try
            For intFunc As Integer = 1 To 12
                With frm.Controls("cmdFunc" & intFunc)
                    If .Text.Length = 0 OrElse .Text.Substring(0, .Text.IndexOf("(")).Trim.IsNullOrWhiteSpace = True Then
                        .Text = ""
                        .Visible = False
                    End If
                End With
            Next intFunc

            If frm.dgvDATA.RowCount > 0 Then
                frm.cmdFunc1.Enabled = True
                frm.cmdFunc2.Enabled = True
                frm.cmdFunc3.Enabled = True
                frm.cmdFunc4.Enabled = True
                frm.cmdFunc5.Enabled = True
                frm.cmdFunc10.Enabled = True
            Else
                frm.cmdFunc1.Enabled = True
                frm.cmdFunc2.Enabled = True
                frm.cmdFunc3.Enabled = False
                frm.cmdFunc4.Enabled = False
                frm.cmdFunc5.Enabled = False
                frm.cmdFunc10.Enabled = False
            End If

            'MyBase.ToolTip.SetToolTip(Me.cmdFunc5, My.Resources.infoToolTipMsgNotFoundData)

            Dim dgv As DataGridView = DirectCast(frm.Controls("dgvDATA"), DataGridView)

            If dgv.SelectedRows.Count > 0 Then
                If dgv.CurrentRow IsNot Nothing AndAlso dgv.CurrentRow.Cells.Item("DEL_FLG").Value = True Then
                    '�폜�σf�[�^�̏ꍇ
                    frm.cmdFunc4.Enabled = False
                    frm.cmdFunc5.Text = "���S�폜(F5)"
                    frm.cmdFunc5.Tag = ENM_DATA_OPERATION_MODE._6_DELETE

                    '����
                    frm.cmdFunc6.Text = "����(F6)"
                    frm.cmdFunc6.Visible = True
                    frm.cmdFunc6.Tag = ENM_DATA_OPERATION_MODE._5_RESTORE
                Else
                    frm.cmdFunc5.Text = "�폜(F5)"
                    frm.cmdFunc5.Tag = ENM_DATA_OPERATION_MODE._4_DISABLE

                    frm.cmdFunc6.Text = ""
                    frm.cmdFunc6.Visible = False
                    frm.cmdFunc6.Tag = ""

                End If
            Else
                frm.cmdFunc6.Visible = False
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
    '�����t�B���^�ύX
    Private Sub SearchFilterValueChanged(sender As System.Object, e As System.EventArgs)
        '����
        Me.cmdFunc1.PerformClick()
    End Sub
    '�����t�B���^�N���A
    Private Sub BtnClearSrchFilter_Click(sender As Object, e As EventArgs) Handles btnClearSrchFilter.Click

        mtxTORI_NAME.Clear()
        chkDeletedRowVisibled.Checked = False
        Me.cmdFunc1.PerformClick()
    End Sub

#End Region

End Class
