Imports JMS_COMMON.ClsPubMethod


Public Class FrmG0011

    'TODO: Form Load�C�x���g��Catch���O��

    'TODO: (�}�X�^�S��) �폜�ς݃`�F�b�N���Adgv �����s�I���ɂ��āA�ꊇ���S�폜�E�����o����悤�ɂ���

    'TODO: �]�T����������ButtonBaseForm��ButtonPanel������GcFlowLayoutPanel�ɂ���

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

            '-----�O���b�h�����ݒ�(�e�t�H�[������Ăяo��)
            'Call FunInitializeDataGridView(Me.dgvDATA)

            '-----�O���b�h��쐬
            'Call FunSetDgvCulumns(Me.dgvDATA)

            '-----�R���g���[���f�[�^�\�[�X�ݒ�
            'Me.cmbKOMO_NM.SetDataSource(tblKOMO_NM.ExcludeDeleted, True)

            '''-----�C�x���g�n���h���ݒ�
            'AddHandler Me.cmbKOMO_NM.SelectedValueChanged, AddressOf SearchFilterValueChanged
            'AddHandler Me.chkDeletedRowVisibled.CheckedChanged, AddressOf SearchFilterValueChanged


            '�������s
            Me.cmdFunc1.PerformClick()
        Finally

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
                Case 1  '����
                    'Call FunSRCH(Me.dgvDATA, FunGetListData())
                Case 2  '�ǉ�

                    If FunUpdateEntity(ENM_DATA_OPERATION_MODE._1_ADD) = True Then
                        'Call FunSRCH(Me.dgvDATA, FunGetListData())
                    End If
                Case 3  '�Q�ƒǉ�

                    If FunUpdateEntity(ENM_DATA_OPERATION_MODE._2_ADDREF) = True Then
                        'Call FunSRCH(Me.dgvDATA, FunGetListData())
                    End If
                Case 4  '�ύX

                    If FunUpdateEntity(ENM_DATA_OPERATION_MODE._3_UPDATE) = True Then
                        'Call FunSRCH(Me.dgvDATA, FunGetListData())
                    End If
                Case 5, 6  '�폜/����/���S�폜

                    Dim btn As Button = DirectCast(sender, Button)
                    Dim ENM_MODE As ENM_DATA_OPERATION_MODE = DirectCast(btn.Tag, ENM_DATA_OPERATION_MODE)
                    If FunDEL(ENM_MODE) = True Then
                        'Call FunSRCH(Me.dgvDATA, FunGetListData())
                    End If

                Case 10  'CSV�o��

                    Dim strFileName As String = pub_APP_INFO.strTitle & "_" & DateTime.Today.ToString("yyyyMMdd") & ".CSV"
                    'Call FunCSV_OUT(Me.dgvDATA.DataSource, strFileName, pub_APP_INFO.strOUTPUT_PATH)


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
            'Call FunInitFuncButtonEnabled(Me)

            '[�A�N�e�B�u]
            Me.PrPG_STATUS = ENM_PG_STATUS._2_ACTIVE
        End Try

    End Sub

#End Region

#Region "����"

    Private Function FunGetListData() As DataTable
        Try
            Dim sbSQL As New System.Text.StringBuilder
            Dim dsList As New DataSet
            Dim sbSQLWHERE As New System.Text.StringBuilder

            ''----DB�f�[�^�擾
            'sbSQLWHERE.Remove(0, sbSQLWHERE.Length)
            'If Me.cmbKOMO_NM.SelectedValue <> "" Then
            '    sbSQLWHERE.Append(" WHERE KOMO_NM ='" & Me.cmbKOMO_NM.SelectedValue & "' ")
            'Else
            '    If cmbKOMO_NM.Text.ToString.IsNullOrWhiteSpace = False Then
            '        sbSQLWHERE.Append("  WHERE KOMO_NM  LIKE '%" & Me.cmbKOMO_NM.Text.Trim & "%' ")
            '    End If
            'End If

            'If Me.chkDeletedRowVisibled.Checked = False Then
            '    If sbSQLWHERE.Length = 0 Then
            '        sbSQLWHERE.Append(" WHERE DEL_FLG <> 1 ")
            '    Else
            '        sbSQLWHERE.Append(" AND DEL_FLG <> 1 ")
            '    End If
            '    'dgvDATA.Columns("DEL_FLG").Visible = False
            'Else
            '    'dgvDATA.Columns("DEL_FLG").Visible = True
            'End If

            sbSQL.Remove(0, sbSQL.Length)
            sbSQL.Append("SELECT")
            sbSQL.Append(" *")
            sbSQL.Append(" FROM " & NameOf(MODEL.M001_SETTING) & " ")
            sbSQL.Append(sbSQLWHERE)
            sbSQL.Append(" ORDER BY KOMO_NM, DISP_ORDER ")
            Using DBa As ClsDbUtility = DBOpen()
                dsList = DBa.GetDataSet(sbSQL.ToString, conblnNonMsg)
            End Using

            If dsList.Tables(0).Rows.Count > pub_APP_INFO.intSEARCHMAX Then
                If MessageBox.Show(My.Resources.infoSearchCountOver, "", MessageBoxButtons.YesNo, MessageBoxIcon.Information) = Windows.Forms.DialogResult.No Then
                    Return Nothing
                End If
            End If


            '------DataTable�ɕϊ�
            Dim dt As New DataTable

            Dim t As Type = GetType(MODEL.M001_SETTING)
            Dim properties As Reflection.PropertyInfo() = t.GetProperties(
                 Reflection.BindingFlags.Public Or
                 Reflection.BindingFlags.NonPublic Or
                 Reflection.BindingFlags.Instance Or
                 Reflection.BindingFlags.Static)

            For Each p As Reflection.PropertyInfo In properties
                'If IsAutoGenerateField(t, p.Name) = True Then
                dt.Columns.Add(p.Name, p.PropertyType)
                'End If
            Next p

            With dsList.Tables(0)
                For Each row As DataRow In .Rows
                    Dim Trow As DataRow = dt.NewRow()
                    For Each p As Reflection.PropertyInfo In properties
                        'If IsAutoGenerateField(t, p.Name) = True Then
                        Select Case p.PropertyType
                            Case GetType(Integer)
                                Trow(p.Name) = Val(row.Item(p.Name))
                            Case GetType(Decimal)
                                Trow(p.Name) = CDec(row.Item(p.Name))
                            Case GetType(Boolean)
                                Trow(p.Name) = CBool(row.Item(p.Name))
                            Case Else
                                Trow(p.Name) = row.Item(p.Name)
                        End Select
                        'End If
                    Next p
                    dt.Rows.Add(Trow)
                Next row
                dt.AcceptChanges()
            End With

            Return dt
        Catch ex As Exception
            EM.ErrorSyori(ex, False, conblnNonMsg)
            Return Nothing
        End Try
    End Function

    Private Function FunSRCH(ByVal dgv As DataGridView, ByVal dt As DataTable) As Boolean
        Dim intCURROW As Integer
        Try

            'EntityFramework6��
            'Dim _model As Model.VWM01_CODE
            'DB.Database.Log = Sub(s)
            '                      Debug.WriteLine(s)
            '                  End Sub

            'Dim query As IQueryable(Of Model.VWM01_CODE) = DB.VWM01_CODE.AsNoTracking
            'If Me.cmbKOMO_NM.SelectedValue <> "" Then
            '    query = query.Where(Function(e) e.KOMO_NM = Me.cmbKOMO_NM.SelectedValue.ToString)
            'Else
            '    If Me.cmbKOMO_NM.Text.Trim <> "" Then
            '        query = query.Where(Function(e) e.KOMO_NM.Contains(Me.cmbKOMO_NM.Text.Trim))
            '    End If
            'End If
            'If Me.chkDeletedRowVisibled.Checked = False Then
            '    query = query.Where(Function(e) e.DEL_YMDHNS.Trim = "")
            '    dgv.Columns(NameOf(_model.DEL_FLG)).Visible = False
            'Else
            '    dgv.Columns(NameOf(_model.DEL_FLG)).Visible = True
            'End If
            'dgv.DataSource = query.ToList


            '-----�I���s�L��
            If dgv.RowCount > 0 Then
                intCURROW = dgv.CurrentRow.Index
            End If

            dgv.DataSource = dt



            Call FunSetDgvCellFormat(dgv)

            If dgv.RowCount > 0 Then
                '-----�I���s�ݒ�
                Try
                    dgv.CurrentCell = dgv.Rows(intCURROW).Cells(0)
                Catch dgvEx As Exception
                End Try
                Me.lblRecordCount.Text = String.Format(My.Resources.infoToolTipMsgFoundData, dgv.RowCount.ToString)
            Else
                Me.lblRecordCount.Text = My.Resources.infoSearchResultNotFound
            End If

            Return True
        Catch ex As Exception
            EM.ErrorSyori(ex, False, conblnNonMsg)
            Return False
        Finally

            '-----�ꗗ��
            dgv.Visible = True
        End Try
    End Function

    Private Function FunSetDgvCellFormat(ByVal dgv As DataGridView) As Boolean

        Try
            Dim _Model As New MODEL.M001_SETTING
            For i As Integer = 0 To dgv.Rows.Count - 1
                With dgv.Rows(i)
                    'If CBool(Me.dgvDATA.Rows(i).Cells(NameOf(_Model.DEL_FLG)).Value) = True Then
                    '    Me.dgvDATA.Rows(i).DefaultCellStyle.ForeColor = clrDeletedRowForeColor
                    '    Me.dgvDATA.Rows(i).DefaultCellStyle.BackColor = clrDeletedRowBackColor
                    '    Me.dgvDATA.Rows(i).DefaultCellStyle.SelectionForeColor = clrDeletedRowForeColor
                    'End If
                End With
            Next i
        Catch ex As Exception
            EM.ErrorSyori(ex, False, conblnNonMsg)
        End Try
    End Function

#End Region

#Region "�ǉ��E�ύX"

    ''' <summary>
    ''' ���R�[�h�ǉ��ύX����
    ''' </summary>
    ''' <param name="intMODE">�������[�h</param>
    ''' <returns></returns>
    Private Function FunUpdateEntity(ByVal intMODE As ENM_DATA_OPERATION_MODE) As Boolean
        Dim frmDLG As New FrmG0011
        Dim dlgRET As DialogResult
        Dim PKeys As Tuple(Of String, String)
        Dim strComboVal As String

        Try
            'TODO: �Q�ƌ^��System.Tuple��l�^��System.ValueTuple�ɒu��������

            '�R���{�{�b�N�X�̑I��l���L��
            'If cmbKOMO_NM.SelectedValue IsNot Nothing Then
            '    strComboVal = cmbKOMO_NM.SelectedValue
            'Else
            '    strComboVal = ""
            'End If

            'frmDLG.PrMODE = intMODE
            'If Me.dgvDATA.CurrentRow IsNot Nothing Then
            '    frmDLG.PrdgvCellCollection = Me.dgvDATA.CurrentRow.Cells
            '    frmDLG.PrDataRow = Me.dgvDATA.GetDataRow()
            'Else
            '    frmDLG.PrdgvCellCollection = Nothing
            '    frmDLG.PrDataRow = Nothing
            'End If
            dlgRET = frmDLG.ShowDialog(Me)
            'PKeys = frmDLG.PrPKeys

            If dlgRET = Windows.Forms.DialogResult.Cancel Then
                Return False
            Else

                '-----���ږ����ǉ��ɂȂ����ꍇ�A�����t�B���^�̃R���{�{�b�N�X�̃f�[�^�\�[�X���Đݒ�
                Using DB As ClsDbUtility = DBOpen()
                    Call FunGetCodeDataTable(DB, "���ږ�", tblKOMO_NM)
                End Using
                'Me.cmbKOMO_NM.SetDataSource(tblKOMO_NM.ExcludeDeleted, True)
                'Me.cmbKOMO_NM.SelectedValue = strComboVal


                '�ǉ������R�[�h�̍s��I������
                'For i As Integer = 0 To Me.dgvDATA.RowCount - 1
                '    With Me.dgvDATA.Rows(i)
                '        If .Cells(0).Value = PKeys.Item1 And
                '            .Cells(1).Value = PKeys.Item2 Then

                '            Me.dgvDATA.CurrentCell = .Cells(0)
                '            Exit For
                '        End If
                '    End With
                'Next i
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

#Region "�폜"

    Private Function FunDEL(ByVal ENM_MODE As ENM_DATA_OPERATION_MODE) As Boolean
        Dim sbSQL As New System.Text.StringBuilder
        Dim strComboVal As String
        Dim strMsg As String
        Dim strTitle As String

        Try

            '�R���{�{�b�N�X�̑I��l
            'strComboVal = Me.cmbKOMO_NM.Text.Trim

            '-----SQL
            sbSQL.Remove(0, sbSQL.Length)
            Select Case ENM_MODE
                Case ENM_DATA_OPERATION_MODE._4_DISABLE
                    '-----�X�V
                    sbSQL.Append("UPDATE " & NameOf(MODEL.M001_SETTING) & " SET ")
                    '�폜����
                    sbSQL.Append(" DEL_YMDHNS = dbo.GetSysDateString(), ")
                    '�폜�S����
                    sbSQL.Append(" DEL_TANTO_CD = " & pub_SYAIN_INFO.SYAIN_ID & "")



                    strMsg = My.Resources.infoMsgDeleteOperationDisable
                    strTitle = My.Resources.infoTitleDeleteOperationDisable

                Case ENM_DATA_OPERATION_MODE._5_RESTORE
                    '-----�X�V
                    sbSQL.Append("UPDATE " & NameOf(MODEL.M001_SETTING) & " SET ")
                    '�폜����
                    sbSQL.Append(" DEL_YMDHNS = ' ', ")
                    '�폜�S����
                    sbSQL.Append(" DEL_TANTO_CD = " & pub_SYAIN_INFO.SYAIN_ID & "")

                    strMsg = My.Resources.infoMsgDeleteOperationRestore
                    strTitle = My.Resources.infoTitleDeleteOperationRestore

                Case ENM_DATA_OPERATION_MODE._6_DELETE

                    '-----�폜
                    sbSQL.Append("DELETE FROM " & NameOf(MODEL.M001_SETTING) & " ")

                    strMsg = My.Resources.infoMsgDeleteOperationDelete
                    strTitle = My.Resources.infoTitleDeleteOperationDelete

                Case Else
                    'UNDONE: argument null exception
                    Return False
            End Select
            sbSQL.Append("WHERE")
            'sbSQL.Append(" KOMO_NM = '" & Me.dgvDATA.CurrentRow.Cells.Item("KOMO_NM").Value.ToString & "' ")
            'sbSQL.Append(" AND VALUE = '" & Me.dgvDATA.CurrentRow.Cells.Item("VALUE").Value.ToString & "' ")

            '�m�F���b�Z�[�W�\��
            If MessageBox.Show(strMsg, strTitle, MessageBoxButtons.YesNo, MessageBoxIcon.Question) <> Windows.Forms.DialogResult.Yes Then
                Me.DialogResult = Windows.Forms.DialogResult.Cancel
                'Me.Close()
                Return False
            End If

            Using DB As ClsDbUtility = DBOpen()
                Dim blnErr As Boolean
                Dim intRET As Integer
                Dim sqlEx As Exception = Nothing

                Try
                    DB.BeginTransaction()

                    '-----SQL���s
                    intRET = DB.ExecuteNonQuery(sbSQL.ToString, conblnNonMsg, sqlEx)
                    If intRET <> 1 Then
                        '�G���[���O
                        Dim strErrMsg As String = My.Resources.ErrLogSqlExecutionFailure & "|" & sbSQL.ToString & "|" & sqlEx.Message
                        WL.WriteLogDat(strErrMsg)
                        blnErr = True
                        Return False
                    End If
                Finally
                    DB.Commit(Not blnErr)
                End Try

                '�����t�B���^�f�[�^�\�[�X�X�V
                Call FunGetCodeDataTable(DB, "���ږ�", tblKOMO_NM)
            End Using
            'Me.cmbKOMO_NM.SetDataSource(tblKOMO_NM.ExcludeDeleted, True)

            'If strComboVal <> "" Then
            '    Me.cmbKOMO_NM.Text = strComboVal
            'End If
            'If Me.cmbKOMO_NM.SelectedIndex <= 0 Then
            '    Me.cmbKOMO_NM.Text = ""
            'End If

            Return True
        Catch ex As Exception
            EM.ErrorSyori(ex, False, conblnNonMsg)
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
    Private Function FunInitFuncButtonEnabled(ByVal frm As FrmG0010) As Boolean
        Try

            For intFunc As Integer = 1 To 12
                With frm.Controls("cmdFunc" & intFunc)
                    If .Text.Length = 0 OrElse .Text.Substring(0, .Text.IndexOf("(")).Trim = "" Then
                        .Text = ""
                        .Visible = False
                    End If
                End With
            Next intFunc

            Dim dgv As DataGridView = DirectCast(frm.Controls("dgvDATA"), DataGridView)

            If dgv.RowCount > 0 Then
                frm.cmdFunc3.Enabled = True
                frm.cmdFunc4.Enabled = True
                frm.cmdFunc5.Enabled = True
                frm.cmdFunc10.Enabled = True
            Else
                frm.cmdFunc3.Enabled = False
                frm.cmdFunc4.Enabled = False
                frm.cmdFunc5.Enabled = False
                frm.cmdFunc10.Enabled = False
            End If

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



#End Region



End Class