Imports JMS_COMMON.ClsPubMethod
Imports C1.Win.C1FlexGrid

Public Class FrmG0010

    Public Property PrDt As DataTable


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
        MyBase.ToolTip.SetToolTip(Me.cmdFunc7, My.Resources.infoToolTipMsgNotFoundData)
        MyBase.ToolTip.SetToolTip(Me.cmdFunc8, My.Resources.infoToolTipMsgNotFoundData)
        MyBase.ToolTip.SetToolTip(Me.cmdFunc9, My.Resources.infoToolTipMsgNotFoundData)
        MyBase.ToolTip.SetToolTip(Me.cmdFunc10, My.Resources.infoToolTipMsgNotFoundData)
        MyBase.ToolTip.SetToolTip(Me.cmdFunc11, My.Resources.infoToolTipMsgNotFoundData)

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

            '-----�R���g���[���\�[�X�ݒ�
            cmbBUMON.SetDataSource(tblBUMON.ExcludeDeleted, ENM_COMBO_SELECT_VALUE_TYPE._1_Filter)

            cmbKISYU.SetDataSource(tblKISYU.ExcludeDeleted, ENM_COMBO_SELECT_VALUE_TYPE._1_Filter)
            cmbTANTO.SetDataSource(tblTANTO.ExcludeDeleted, ENM_COMBO_SELECT_VALUE_TYPE._1_Filter)
            cmbJIZEN_SINSA_HANTEI_KB.SetDataSource(tblJIZEN_SINSA_HANTEI_KB.ExcludeDeleted, ENM_COMBO_SELECT_VALUE_TYPE._1_Filter)
            cmbSAISIN_IINKAI_HANTEI_KB.SetDataSource(tblSAISIN_IINKAI_HANTEI_KB.ExcludeDeleted, ENM_COMBO_SELECT_VALUE_TYPE._1_Filter)
            cmbBUHIN_BANGO.SetDataSource(tblBUHIN.ExcludeDeleted, ENM_COMBO_SELECT_VALUE_TYPE._1_Filter)

            '����l�ݒ�
            cmbTANTO.SelectedValue = pub_SYAIN_INFO.SYAIN_ID


            ''-----�C�x���g�n���h���ݒ�
            AddHandler Me.cmbTANTO.SelectedValueChanged, AddressOf SearchFilterValueChanged
            AddHandler Me.cmbBUHIN_BANGO.SelectedValueChanged, AddressOf SearchFilterValueChanged
            AddHandler Me.chkClosedRowVisibled.CheckedChanged, AddressOf SearchFilterValueChanged


            '�������s
            Me.cmdFunc1.PerformClick()
        Finally

        End Try
    End Sub

#End Region

#Region "DataGridView�֘A"

    '�t�B�[���h��`()
    Private Shared Function FunSetDgvCulumns(ByVal dgv As DataGridView) As Boolean
        Dim _Model As New MODEL.TV01_FUTEKIGO_ICHIRAN
        Try
            With dgv
                .AutoGenerateColumns = False
                .ReadOnly = False

                .RowsDefaultCellStyle.BackColor = Color.White
                .AlternatingRowsDefaultCellStyle.BackColor = Color.White

                Dim cmbclmn1 As New DataGridViewCheckBoxColumn With {
                .Name = NameOf(_Model.SELECTED),
                .HeaderText = "�I��",
                .DataPropertyName = .Name
                }
                cmbclmn1.DefaultCellStyle.Alignment = Windows.Forms.DataGridViewContentAlignment.MiddleCenter
                .Columns.Add(cmbclmn1)
                .Columns(.ColumnCount - 1).SortMode = DataGridViewColumnSortMode.Automatic
                .Columns(.ColumnCount - 1).Width = 30

                .Columns.Add(NameOf(_Model.HOKOKUSYO_NO), "�񍐏�No")
                .Columns(.ColumnCount - 1).Width = 70
                .Columns(.ColumnCount - 1).DefaultCellStyle.Alignment = Windows.Forms.DataGridViewContentAlignment.MiddleLeft
                .Columns(.ColumnCount - 1).DataPropertyName = .Columns(.ColumnCount - 1).Name
                .Columns(.ColumnCount - 1).ReadOnly = True

                .Columns.Add(NameOf(_Model.CLOSE_FLG), "Closed")
                .Columns(.ColumnCount - 1).DataPropertyName = .Columns(.ColumnCount - 1).Name
                .Columns(.ColumnCount - 1).Visible = False

                .Columns.Add(NameOf(_Model.SYONIN_JUN), "���F��")
                .Columns(.ColumnCount - 1).DataPropertyName = .Columns(.ColumnCount - 1).Name
                .Columns(.ColumnCount - 1).Visible = False

                .Columns.Add(NameOf(_Model.SYONIN_NAIYO), "�X�e�[�W")
                .Columns(.ColumnCount - 1).Width = 180
                .Columns(.ColumnCount - 1).DefaultCellStyle.Alignment = Windows.Forms.DataGridViewContentAlignment.MiddleLeft
                .Columns(.ColumnCount - 1).DataPropertyName = .Columns(.ColumnCount - 1).Name
                .Columns(.ColumnCount - 1).ReadOnly = True

                .Columns.Add(NameOf(_Model.SYONIN_HOKOKUSYO_R_NAME), "����")
                .Columns(.ColumnCount - 1).Width = 70
                .Columns(.ColumnCount - 1).DefaultCellStyle.Alignment = Windows.Forms.DataGridViewContentAlignment.MiddleCenter
                .Columns(.ColumnCount - 1).DataPropertyName = .Columns(.ColumnCount - 1).Name
                .Columns(.ColumnCount - 1).ReadOnly = True

                .Columns.Add(NameOf(_Model.SYOCHI_SYAIN_NAME), "���u�S����")
                .Columns(.ColumnCount - 1).Width = 120
                .Columns(.ColumnCount - 1).DefaultCellStyle.Alignment = Windows.Forms.DataGridViewContentAlignment.MiddleLeft
                .Columns(.ColumnCount - 1).DataPropertyName = .Columns(.ColumnCount - 1).Name
                .Columns(.ColumnCount - 1).ReadOnly = True

                .Columns.Add(NameOf(_Model.TAIRYU), "�ؗ�����")
                .Columns(.ColumnCount - 1).Width = 80
                .Columns(.ColumnCount - 1).DefaultCellStyle.Alignment = Windows.Forms.DataGridViewContentAlignment.MiddleRight
                .Columns(.ColumnCount - 1).DataPropertyName = .Columns(.ColumnCount - 1).Name
                .Columns(.ColumnCount - 1).ReadOnly = True

                .Columns.Add(NameOf(_Model.KISYU), "�@��")
                .Columns(.ColumnCount - 1).Width = 120
                .Columns(.ColumnCount - 1).DefaultCellStyle.Alignment = Windows.Forms.DataGridViewContentAlignment.MiddleLeft
                .Columns(.ColumnCount - 1).DataPropertyName = .Columns(.ColumnCount - 1).Name
                .Columns(.ColumnCount - 1).ReadOnly = True

                .Columns.Add(NameOf(_Model.BUHIN_BANGO), "���i�ԍ�")
                .Columns(.ColumnCount - 1).Width = 180
                .Columns(.ColumnCount - 1).DefaultCellStyle.Alignment = Windows.Forms.DataGridViewContentAlignment.MiddleLeft
                .Columns(.ColumnCount - 1).DataPropertyName = .Columns(.ColumnCount - 1).Name
                .Columns(.ColumnCount - 1).ReadOnly = True

                .Columns.Add(NameOf(_Model.BUHIN_NAME), "���i��")
                .Columns(.ColumnCount - 1).Width = 180
                .Columns(.ColumnCount - 1).DefaultCellStyle.Alignment = Windows.Forms.DataGridViewContentAlignment.MiddleLeft
                .Columns(.ColumnCount - 1).DataPropertyName = .Columns(.ColumnCount - 1).Name
                .Columns(.ColumnCount - 1).ReadOnly = True

                .Columns.Add(NameOf(_Model.SYONIN_HOKOKUSYO_NAME), "����")
                .Columns(.ColumnCount - 1).Width = 180
                .Columns(.ColumnCount - 1).DefaultCellStyle.Alignment = Windows.Forms.DataGridViewContentAlignment.MiddleLeft
                .Columns(.ColumnCount - 1).DataPropertyName = .Columns(.ColumnCount - 1).Name
                .Columns(.ColumnCount - 1).ReadOnly = True

                .Columns.Add(NameOf(_Model.JIZEN_SINSA_HANTEI_KB_DISP), "���O����敪")
                .Columns(.ColumnCount - 1).Width = 180
                .Columns(.ColumnCount - 1).DefaultCellStyle.Alignment = Windows.Forms.DataGridViewContentAlignment.MiddleLeft
                .Columns(.ColumnCount - 1).DataPropertyName = .Columns(.ColumnCount - 1).Name
                .Columns(.ColumnCount - 1).ReadOnly = True

                .Columns.Add(NameOf(_Model.SAISIN_IINKAI_HANTEI_KB_DISP), "�ĐR����敪")
                .Columns(.ColumnCount - 1).Width = 180
                .Columns(.ColumnCount - 1).DefaultCellStyle.Alignment = Windows.Forms.DataGridViewContentAlignment.MiddleLeft
                .Columns(.ColumnCount - 1).DataPropertyName = .Columns(.ColumnCount - 1).Name
                .Columns(.ColumnCount - 1).ReadOnly = True

                .Columns.Add(NameOf(_Model.ADD_YMD), "�N����")
                .Columns(.ColumnCount - 1).Width = 180
                .Columns(.ColumnCount - 1).DefaultCellStyle.Alignment = Windows.Forms.DataGridViewContentAlignment.MiddleLeft
                .Columns(.ColumnCount - 1).DataPropertyName = .Columns(.ColumnCount - 1).Name
                .Columns(.ColumnCount - 1).ReadOnly = True

                .Columns.Add(NameOf(_Model.SYOCHI_YMD), "�O�������{��")
                .Columns(.ColumnCount - 1).Width = 180
                .Columns(.ColumnCount - 1).DefaultCellStyle.Alignment = Windows.Forms.DataGridViewContentAlignment.MiddleLeft
                .Columns(.ColumnCount - 1).DataPropertyName = .Columns(.ColumnCount - 1).Name
                .Columns(.ColumnCount - 1).ReadOnly = True

                .Columns.Add(NameOf(_Model.MODOSI_SYONIN_NAIYO), "���ߌ��X�e�[�W")
                .Columns(.ColumnCount - 1).Width = 180
                .Columns(.ColumnCount - 1).DefaultCellStyle.Alignment = Windows.Forms.DataGridViewContentAlignment.MiddleLeft
                .Columns(.ColumnCount - 1).DataPropertyName = .Columns(.ColumnCount - 1).Name
                .Columns(.ColumnCount - 1).ReadOnly = True

                .Columns.Add(NameOf(_Model.MODOSI_RIYU), "���ߗ��R")
                .Columns(.ColumnCount - 1).Width = 180
                .Columns(.ColumnCount - 1).DefaultCellStyle.Alignment = Windows.Forms.DataGridViewContentAlignment.MiddleLeft
                .Columns(.ColumnCount - 1).DataPropertyName = .Columns(.ColumnCount - 1).Name
                .Columns(.ColumnCount - 1).ReadOnly = True

                .Columns.Add(NameOf(_Model.MODOSI_SYONIN_JUN), "���ߏ��F��")
                .Columns(.ColumnCount - 1).Visible = False
                .Columns(.ColumnCount - 1).DataPropertyName = .Columns(.ColumnCount - 1).Name
                .Columns(.ColumnCount - 1).ReadOnly = True

                '.Columns(.ColumnCount - 1).DefaultCellStyle.Format = "#,0"
            End With


            Return True
        Finally

        End Try
    End Function

    '�O���b�h�Z��(�s)�_�u���N���b�N���C�x���g
    Private Sub DgvDATA_CellDoubleClick(sender As System.Object, e As DataGridViewCellEventArgs) Handles dgvDATA.CellDoubleClick
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
            Dim dgv As DataGridView = DirectCast(sender, DataGridView)

        Finally
            Call FunInitFuncButtonEnabled()
        End Try
    End Sub

    '�\�[�g���C�x���g
    Private Sub DgvDATA_Sorted(sender As Object, e As EventArgs) Handles dgvDATA.Sorted
        Call FunSetDgvCellFormat(sender)
    End Sub


#Region "�@�O���b�h�ҏW�֘A"

    ''' <summary>
    ''' �O���b�h�ҏW�O����
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks>�O���b�h�ҏW�O����</remarks>
    Private Sub DgvDATA_CellBeginEdit(sender As Object, e As System.Windows.Forms.DataGridViewCellCancelEventArgs) Handles dgvDATA.CellBeginEdit

        ' �ҏW�O�̒l��Ҕ����Ă���
        'pri_intPrevCellValue = Val(Me.dgvDATA.CurrentCell.Value)
    End Sub

    '�Z���ҏW�����C�x���g
    Private Sub DgvDATA_CellEndEdit(sender As Object, e As DataGridViewCellEventArgs) Handles dgvDATA.CellEndEdit
        Try

            'Dim intEditedCellValue As Integer
            'intEditedCellValue = Val(Me.dgvDATA.CurrentCell.Value)

            'If pri_intPrevCellValue <> intEditedCellValue Then
            '    '�J�����g�Z�������ύX
            '    Me.dgvDATA.CurrentCell.Style.ForeColor = clrEditedCellForeColor
            '    Me.dgvDATA.CurrentCell.Style.SelectionForeColor = clrEditedCellForeColor

            '    If Me.dgvDATA.Columns(e.ColumnIndex).Name = "SELECTROW" Then
            '    Else
            '        Me.dgvDATA.CurrentRow.Cells("MODIFIED_STATUS").Value = True
            '        Me.pri_blnUpdateCellValue = True
            '    End If
            'End If

        Catch ex As Exception
            EM.ErrorSyori(ex, False, conblnNonMsg)
        Finally
            'FunInitFuncButtonEnabled(Me)
        End Try
    End Sub

    '�Z���N���b�N���C�x���g
    Private Sub DgvDATA_CellClick(sender As System.Object, e As DataGridViewCellEventArgs) Handles dgvDATA.CellClick

        Try
            Dim dgv As DataGridView = DirectCast(sender, DataGridView)

            If e.RowIndex >= 0 Then
                Select Case dgv.Columns(e.ColumnIndex).Name
                    Case "SELECTED"
                        'If Me.dgvDATA.CurrentRow.Cells("STATUS").Value = Context.ENM_HACCYU_STATUS._0_������ Then
                        '    If Me.dgvDATA.CurrentRow.Cells("MODIFIED_STATUS").Value = True Then
                        '        '���ʁE�P���ύX���A�͍X�V����܂őI�������͕s��
                        '        Me.dgvDATA.CurrentRow.Cells("SELECTROW").Value = False
                        '        MessageBox.Show("���ʁE�P�����ύX����Ă��܂��B��ɕύX���e���m�肵�ĉ�����", "�ύX���m��", MessageBoxButtons.OK, MessageBoxIcon.Information)
                        '        Exit Sub
                        '    Else
                        Me.dgvDATA.CurrentRow.Cells("SELECTED").Value = Not CBool(Me.dgvDATA.CurrentRow.Cells("SELECTED").Value)
                        '    End If
                        'Else
                        '    '�I��s��
                        '    Me.dgvDATA.CurrentRow.Cells("SELECTED").Value = False
                        '    MessageBox.Show("�������f�[�^�ȊO�͑I���o���܂���B", "�I��s��", MessageBoxButtons.OK, MessageBoxIcon.Information)
                        'End If

                        'Case "HACYU_SU", "TANKA"
                        '    If dgv(e.ColumnIndex, e.RowIndex).ReadOnly = True Then
                        '        Select Case Me.dgvDATA.CurrentRow.Cells("STATUS").Value
                        '            Case Context.ENM_HACCYU_STATUS._1_������, Context.ENM_HACCYU_STATUS._2_���׍�
                        '                MessageBox.Show("���ɔ����ς݂̂��ߐ��ʁE�P���͕ύX�ł��܂���B" & vbCrLf & "�ύX���K�v�ȏꍇ�͊����̔����������A�����v����ēo�^���ĉ������B", "�ύX�s��", MessageBoxButtons.OK, MessageBoxIcon.Information)
                        '            Case Context.ENM_HACCYU_STATUS._9_���
                        '                MessageBox.Show("���Ɏ���ς݂̂��ߐ��ʁE�P���͕ύX�ł��܂���B" & vbCrLf & "�ύX���K�v�ȏꍇ�́A�����v����ēo�^���ĉ������B", "�ύX�s��", MessageBoxButtons.OK, MessageBoxIcon.Information)
                        '        End Select
                        '        Exit Sub
                        '    Else
                        '        Me.dgvDATA.BeginEdit(True)
                        '    End If
                End Select

            End If
        Catch ex As Exception
            EM.ErrorSyori(ex, False, conblnNonMsg)
        Finally
            FunInitFuncButtonEnabled()
        End Try
    End Sub


#Region "�ҏW�\�Z��OnMouse���J�[�\���ύX"
    Private Sub Dgv_CellMouseMove(sender As Object, e As DataGridViewCellMouseEventArgs) Handles dgvDATA.CellMouseMove
        Dim dgv As DataGridView = DirectCast(sender, DataGridView)
        If e.RowIndex >= 0 Then
            Select Case dgv.Columns(e.ColumnIndex).Name
                Case "SELECTED"
                    dgv.Cursor = Cursors.Hand
                    'Case "TANKA", "HACYU_SU"
                    '    If dgv(e.ColumnIndex, e.RowIndex).ReadOnly = False Then
                    '        dgv.Cursor = Cursors.IBeam
                    '    Else
                    '        dgv.Cursor = Cursors.No
                    '    End If
                Case Else
                    dgv.Cursor = Cursors.Default
            End Select
        End If
    End Sub

    Private Sub Dgv_CellMouseLeave(sender As Object, e As DataGridViewCellEventArgs) Handles dgvDATA.CellMouseLeave
        Dim dgv As DataGridView = DirectCast(sender, DataGridView)
        dgv.Cursor = Cursors.Default
    End Sub

#End Region

#Region "���͐���"
    'EditingControlShowing�C�x���g
    Private Sub DataGridView1_EditingControlShowing(ByVal sender As Object, ByVal e As DataGridViewEditingControlShowingEventArgs) Handles dgvDATA.EditingControlShowing
        '�\������Ă���R���g���[����DataGridViewTextBoxEditingControl�����ׂ�
        If TypeOf e.Control Is DataGridViewTextBoxEditingControl Then
            Dim dgv As DataGridView = CType(sender, DataGridView)

            '�ҏW�̂��߂ɕ\������Ă���R���g���[�����擾
            Dim tb As DataGridViewTextBoxEditingControl =
                CType(e.Control, DataGridViewTextBoxEditingControl)

            '�C�x���g�n���h�����폜
            RemoveHandler tb.KeyPress, AddressOf DataGridViewTextBox_KeyPress

            '�Y������񂩒��ׂ�
            Select Case dgv.CurrentCell.OwningColumn.Name
                Case "TANKA", "HACYU_SU"
                    'KeyPress�C�x���g�n���h����ǉ�
                    AddHandler tb.KeyPress, AddressOf DataGridViewTextBox_KeyPress
                Case Else
                    '
            End Select
        End If
    End Sub

    'DataGridView�ɕ\������Ă���e�L�X�g�{�b�N�X��KeyPress�C�x���g�n���h��
    Private Sub DataGridViewTextBox_KeyPress(ByVal sender As Object, ByVal e As KeyPressEventArgs)
        '����(+BACKSPACE)�������͂ł��Ȃ��悤�ɂ���
        Dim tb As DataGridViewTextBoxEditingControl = DirectCast(sender, DataGridViewTextBoxEditingControl)

        If (e.KeyChar < "0"c Or e.KeyChar > "9"c) _
            AndAlso e.KeyChar <> ControlChars.Back _
            AndAlso e.KeyChar <> "."c _
            AndAlso (e.KeyChar = "."c And tb.Text.Contains("."c)) Then
            e.Handled = True
        End If
    End Sub

#End Region

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
                Case 1  '����
                    Call FunSRCH(dgvDATA, FunGetListData())
                Case 2  '�ǉ�

                    If FunUpdateEntity(ENM_DATA_OPERATION_MODE._1_ADD) = True Then
                        Call FunSRCH(dgvDATA, FunGetListData())
                    End If

                Case 4  '�ύX

                    If FunUpdateEntity(ENM_DATA_OPERATION_MODE._3_UPDATE) = True Then
                        Call FunSRCH(dgvDATA, FunGetListData())
                    End If
                Case 5, 6  '�폜/����/���S�폜

                    'Dim btn As Button = DirectCast(sender, Button)
                    'Dim ENM_MODE As ENM_DATA_OPERATION_MODE = DirectCast(btn.Tag, ENM_DATA_OPERATION_MODE)
                    If FunDEL() = True Then
                        'Call FunSRCH(dgvDATA, FunGetListData())
                    End If

                Case 7 '�S�I��

                    Call FunSelectAll()

                Case 8 '�S�I������

                    Call FunUnSelectAll()

                Case 9 '���[�����M
                    MessageBox.Show("������")
                Case 10  '���
                    Call OpenReport()

                    'Dim strFileName As String = pub_APP_INFO.strTitle & "_" & DateTime.Today.ToString("yyyyMMdd") & ".CSV"
                    'Call FunCSV_OUT(Me.dgvDATA.DataSource, strFileName, pub_APP_INFO.strOUTPUT_PATH)

                Case 11 '����\��
                    Call OpenFormRIREKI()

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

#Region "����"

    Private Function FunGetListData() As DataTable
        Try
            Dim sbSQL As New System.Text.StringBuilder
            Dim dsList As New DataSet
            Dim sbSQLWHERE As New System.Text.StringBuilder
            Dim sbParam As New System.Text.StringBuilder


            sbParam.Append("'','',0,'','','','" & intREGISTERED_STAGE & "',''")

            If chkClosedRowVisibled.Checked Then
            Else
                If sbSQLWHERE.Length = 0 Then
                    sbSQLWHERE.Append(" WHERE CLOSE_FLG = '0'")
                Else
                    sbSQLWHERE.Append(" AND CLOSE_FLG = '0'")
                End If
            End If

            If cmbTANTO.SelectedValue <> "" Then
                If sbSQLWHERE.Length = 0 Then
                    sbSQLWHERE.Append(" WHERE SYOCHI_SYAIN_ID = " & cmbTANTO.SelectedValue)
                Else
                    sbSQLWHERE.Append(" AND SYOCHI_SYAIN_ID = " & cmbTANTO.SelectedValue)
                End If
            Else
            End If

            If cmbBUHIN_BANGO.SelectedValue <> "" Then
                If sbSQLWHERE.Length = 0 Then
                    sbSQLWHERE.Append(" WHERE BUHIN_BANGO = '" & cmbBUHIN_BANGO.SelectedValue & "'")
                Else
                    sbSQLWHERE.Append(" AND BUHIN_BANGO = '" & cmbBUHIN_BANGO.SelectedValue & "'")
                End If
            Else
            End If

            sbSQL.Remove(0, sbSQL.Length)
            sbSQL.Append("SELECT")
            sbSQL.Append(" *")
            sbSQL.Append(" FROM " & NameOf(MODEL.TV01_FUTEKIGO_ICHIRAN) & "(" & sbParam.ToString & ")")
            sbSQL.Append(" " & sbSQLWHERE.ToString)
            sbSQL.Append(" ORDER BY HOKOKUSYO_NO ")
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

            Dim t As Type = GetType(MODEL.TV01_FUTEKIGO_ICHIRAN)
            Dim properties As Reflection.PropertyInfo() = t.GetProperties(
                 Reflection.BindingFlags.Public Or
                 Reflection.BindingFlags.NonPublic Or
                 Reflection.BindingFlags.Instance Or
                 Reflection.BindingFlags.Static)

            For Each p As Reflection.PropertyInfo In properties
                If IsAutoGenerateField(t, p.Name) = True Then
                    Dim dc As New DataColumn With {.ColumnName = p.Name,
                                                   .DataType = p.PropertyType,
                                                   .Caption = p.DisplayName}
                    dt.Columns.Add(dc)
                End If
            Next p

            With dsList.Tables(0)
                For Each row As DataRow In .Rows
                    Dim Trow As DataRow = dt.NewRow()
                    For Each p As Reflection.PropertyInfo In properties
                        If IsAutoGenerateField(t, p.Name) = True Then
                            Select Case p.PropertyType
                                Case GetType(Integer)
                                    Trow(p.Name) = Val(row.Item(p.Name))
                                Case GetType(Decimal)
                                    Trow(p.Name) = CDec(row.Item(p.Name))
                                Case GetType(Boolean)
                                    If p.Name = "SELECTED" Then
                                        Trow(p.Name) = False
                                    Else
                                        Trow(p.Name) = CBool(row.Item(p.Name))
                                    End If

                                Case GetType(Date), GetType(DateTime)
                                    If row.Item(p.Name).ToString.IsNullOrWhiteSpace = False Then
                                        Select Case row.Item(p.Name).ToString.Length
                                            Case 8
                                                Trow(p.Name) = DateTime.ParseExact(row.Item(p.Name), "yyyyMMdd", Nothing)
                                            Case 14
                                                Trow(p.Name) = DateTime.ParseExact(row.Item(p.Name), "yyyyMMddHHmmss", Nothing)
                                            Case Else
                                                'Err
                                                Trow(p.Name) = Nothing
                                        End Select
                                    End If
                                Case Else
                                    Trow(p.Name) = row.Item(p.Name)
                            End Select
                        End If
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
            '-----�I���s�L��
            If dgv.RowCount > 0 Then
                intCURROW = dgv.CurrentRow.Index
            End If
            PrDt = dt
            dgv.DataSource = dt

            Call FunSetDgvCellFormat(dgv)

            If dgv.RowCount > 1 Then
                '-----�I���s�ݒ�
                Try
                    dgv.CurrentCell = dgv.Rows(intCURROW).Cells(0)
                Catch dgvEx As Exception
                End Try
                Me.lblRecordCount.Text = String.Format(My.Resources.infoToolTipMsgFoundData, dgv.Rows.Count)
            Else
                Me.lblRecordCount.Text = My.Resources.infoSearchResultNotFound
            End If

            Return True
        Catch ex As Exception
            EM.ErrorSyori(ex, False, conblnNonMsg)
            Return False
        Finally
        End Try
    End Function

    Private Function FunSetDgvCellFormat(ByVal dgv As DataGridView) As Boolean

        Try
            'UNDONE: �X�e�[�W�ʂ̑ؗ��x���������擾
            Dim intWarningNotification As Integer
            Using DB As ClsDbUtility = DBOpen()
                intWarningNotification = FunGetCodeMastaValue(DB, "���F�֘A�ݒ�", "�ؗ��x������")
            End Using

            Dim _Model As New MODEL.TV01_FUTEKIGO_ICHIRAN
            For i As Integer = 0 To dgv.Rows.Count - 1
                With dgv.Rows(i)
                    If Me.dgvDATA.Rows(i).Cells(NameOf(_Model.TAIRYU)).Value >= intWarningNotification Then
                        Me.dgvDATA.Rows(i).DefaultCellStyle.BackColor = clrWarningCellBackColor
                    End If

                    If Me.dgvDATA.Rows(i).Cells(NameOf(_Model.MODOSI_SYONIN_JUN)).Value > 0 Then
                        Me.dgvDATA.Rows(i).DefaultCellStyle.BackColor = clrCautionCellBackColor
                    End If

                    If Me.dgvDATA.Rows(i).Cells(NameOf(_Model.CLOSE_FLG)).Value > 0 Then
                        Me.dgvDATA.Rows(i).DefaultCellStyle.ForeColor = clrDeletedRowForeColor
                        Me.dgvDATA.Rows(i).DefaultCellStyle.BackColor = clrDeletedRowBackColor
                        Me.dgvDATA.Rows(i).DefaultCellStyle.SelectionForeColor = clrDeletedRowForeColor
                    End If

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
        Dim frmCAR As New FrmG0012
        Dim dlgRET As DialogResult

        Try
            If intMODE = ENM_DATA_OPERATION_MODE._3_UPDATE And dgvDATA.CurrentRow.Cells(5).Value = "CAR" Then
                dlgRET = frmCAR.ShowDialog(Me)

                If dlgRET = Windows.Forms.DialogResult.Cancel Then
                    Return False
                Else

                End If
            Else
                frmDLG.PrMODE = intMODE
                If dgvDATA.CurrentRow IsNot Nothing Then
                    frmDLG.PrdgvCellCollection = dgvDATA.CurrentRow.Cells
                    frmDLG.PrDataRow = dgvDATA.GetDataRow()
                Else
                    frmDLG.PrdgvCellCollection = Nothing
                    frmDLG.PrDataRow = Nothing
                End If
                frmDLG.PrDt = Me.PrDt
                dlgRET = frmDLG.ShowDialog(Me)

                If dlgRET = Windows.Forms.DialogResult.Cancel Then
                    Return False
                Else
                    dgvDATA.DataSource = frmDLG.PrDt
                End If
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

    Private Function FunDEL() As Boolean
        Dim sbSQL As New System.Text.StringBuilder
        Dim strComboVal As String
        Dim strMsg As String
        Dim strTitle As String

        Try
            MessageBox.Show("������")

            ''�R���{�{�b�N�X�̑I��l
            'strComboVal = Me.cmbSTAGE_NCR.Text.Trim

            ''-----SQL
            'sbSQL.Remove(0, sbSQL.Length)
            'Select Case ENM_MODE
            '    Case ENM_DATA_OPERATION_MODE._4_DISABLE
            '        '-----�X�V
            '        sbSQL.Append("UPDATE " & NameOf(MODEL.M001_SETTING) & " SET ")
            '        '�폜����
            '        sbSQL.Append(" DEL_YMDHNS = dbo.GetSysDateString(), ")
            '        '�폜�S����
            '        sbSQL.Append(" DEL_TANTO_CD = " & pub_SYAIN_INFO.SYAIN_ID & "")



            '        strMsg = My.Resources.infoMsgDeleteOperationDisable
            '        strTitle = My.Resources.infoTitleDeleteOperationDisable

            '    Case ENM_DATA_OPERATION_MODE._5_RESTORE
            '        '-----�X�V
            '        sbSQL.Append("UPDATE " & NameOf(MODEL.M001_SETTING) & " SET ")
            '        '�폜����
            '        sbSQL.Append(" DEL_YMDHNS = ' ', ")
            '        '�폜�S����
            '        sbSQL.Append(" DEL_TANTO_CD = " & pub_SYAIN_INFO.SYAIN_ID & "")

            '        strMsg = My.Resources.infoMsgDeleteOperationRestore
            '        strTitle = My.Resources.infoTitleDeleteOperationRestore

            '    Case ENM_DATA_OPERATION_MODE._6_DELETE

            '        '-----�폜
            '        sbSQL.Append("DELETE FROM " & NameOf(MODEL.M001_SETTING) & " ")

            '        strMsg = My.Resources.infoMsgDeleteOperationDelete
            '        strTitle = My.Resources.infoTitleDeleteOperationDelete

            '    Case Else
            '        'UNDONE: argument null exception
            '        Return False
            'End Select
            'sbSQL.Append("WHERE")
            ''sbSQL.Append(" KOMO_NM = '" & Me.dgvDATA.CurrentRow.Cells.Item("KOMO_NM").Value.ToString & "' ")
            ''sbSQL.Append(" AND VALUE = '" & Me.dgvDATA.CurrentRow.Cells.Item("VALUE").Value.ToString & "' ")

            ''�m�F���b�Z�[�W�\��
            'If MessageBox.Show(strMsg, strTitle, MessageBoxButtons.YesNo, MessageBoxIcon.Question) <> Windows.Forms.DialogResult.Yes Then
            '    Me.DialogResult = Windows.Forms.DialogResult.Cancel
            '    'Me.Close()
            '    Return False
            'End If

            'Using DB As ClsDbUtility = DBOpen()
            '    Dim blnErr As Boolean
            '    Dim intRET As Integer
            '    Dim sqlEx As Exception = Nothing

            '    Try
            '        DB.BeginTransaction()

            '        '-----SQL���s
            '        intRET = DB.ExecuteNonQuery(sbSQL.ToString, conblnNonMsg, sqlEx)
            '        If intRET <> 1 Then
            '            '�G���[���O
            '            Dim strErrMsg As String = My.Resources.ErrLogSqlExecutionFailure & "|" & sbSQL.ToString & "|" & sqlEx.Message
            '            WL.WriteLogDat(strErrMsg)
            '            blnErr = True
            '            Return False
            '        End If
            '    Finally
            '        DB.Commit(Not blnErr)
            '    End Try

            '    '�����t�B���^�f�[�^�\�[�X�X�V
            '    Call FunGetCodeDataTable(DB, "���ږ�", tblKOMO_NM)
            'End Using
            'Me.cmbSTAGE_NCR.SetDataSource(tblKOMO_NM.ExcludeDeleted, True)

            'If strComboVal <> "" Then
            '    Me.cmbSTAGE_NCR.Text = strComboVal
            'End If
            'If Me.cmbSTAGE_NCR.SelectedIndex <= 0 Then
            '    Me.cmbSTAGE_NCR.Text = ""
            'End If

            Return True
        Catch ex As Exception
            EM.ErrorSyori(ex, False, conblnNonMsg)
            Return False
        End Try
    End Function

#End Region

#Region "�S�I��"

    Private Function FunSelectAll() As Boolean

        Try
            'UNDONE: G050 �S�I������
            Dim dt As DataTable = DirectCast(Me.dgvDATA.DataSource, DataTable)
            Dim rows = dt.Rows 'AsEnumerable().Where(Function(r) r.Field(Of String)("STA") = Context.ENM_HACCYU_STATUS._0_������)

            If rows.Count > 0 Then
                For Each row As DataRow In rows
                    row.Item("SELECTED") = True '"��"
                Next row

                '�\���X�V
                FunSetDgvCellFormat(Me.dgvDATA)
            Else
                'MessageBox.Show("�������f�[�^�͂���܂���B", "�S�I��", MessageBoxButtons.OK, MessageBoxIcon.Information)
            End If

            Return True
        Catch ex As Exception
            EM.ErrorSyori(ex, False, conblnNonMsg)
            Return False
        End Try
    End Function

#End Region

#Region "�S�I������"

    Private Function FunUnSelectAll() As Boolean

        Try
            'UNDONE: G050 �S�I������
            Dim dt As DataTable = DirectCast(Me.dgvDATA.DataSource, DataTable)
            Dim rows = dt.Rows 'AsEnumerable().Where(Function(r) r.Field(Of String)("STA") = Context.ENM_HACCYU_STATUS._0_������)

            If rows.Count > 0 Then
                For Each row As DataRow In rows
                    row.Item("SELECTED") = False '"��"
                Next row

                '�\���X�V
                FunSetDgvCellFormat(Me.dgvDATA)
            Else
                'MessageBox.Show("�������f�[�^�͂���܂���B", "�S�I��", MessageBoxButtons.OK, MessageBoxIcon.Information)
            End If

            Return True
        Catch ex As Exception
            EM.ErrorSyori(ex, False, conblnNonMsg)
            Return False
        End Try
    End Function

#End Region

#Region "���|�[�g���"
    Private Function OpenReport() As Boolean
        Dim frmDLG As New FrmG0013
        'Dim dlgRET As DialogResult
        'Dim PKeys As String

        Try

            'If Me.dgvDATA.CurrentRow IsNot Nothing Then
            '    frmDLG.PrdgvCellCollection = Me.dgvDATA.CurrentRow.Cells
            '    frmDLG.PrDataRow = Me.dgvDATA.GetDataRow()
            'Else
            '    frmDLG.PrdgvCellCollection = Nothing
            '    frmDLG.PrDataRow = Nothing
            'End If
            'dlgRET = frmDLG.ShowDialog(Me)
            'PKeys = frmDLG.PrPKeys

            'If dlgRET = Windows.Forms.DialogResult.Cancel Then
            '    Return False
            'Else
            '    '�ǉ��I���s�I��
            'End If

            Dim strFilePath As String = FunGetRootPath() & "\TEMPLATE\17065 T-4FC�c�s��.pdf"

            Dim hProcess As New System.Diagnostics.Process
            If System.IO.File.Exists(strFilePath) = True Then
                'hProcess = System.Diagnostics.Process.Start(strEXE, strARG)
                hProcess.StartInfo.FileName = strFilePath
                hProcess.SynchronizingObject = Me
                hProcess.EnableRaisingEvents = True
                hProcess.Start()

            Else
                Dim strMsg As String
                strMsg = "���L�t�@�C����������܂���B" & vbCrLf & "�V�X�e���Ǘ��҂ɂ��A���������B" &
                            vbCrLf & vbCrLf & strFilePath
                MessageBox.Show(strMsg, My.Application.Info.AssemblyName, MessageBoxButtons.OK, MessageBoxIcon.Information)
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

#Region "����"
    Private Function OpenFormRIREKI() As Boolean
        Dim frmDLG As New FrmG0013
        Dim dlgRET As DialogResult
        Dim PKeys As String

        Try

            'If Me.dgvDATA.CurrentRow IsNot Nothing Then
            '    frmDLG.PrdgvCellCollection = Me.dgvDATA.CurrentRow.Cells
            '    frmDLG.PrDataRow = Me.dgvDATA.GetDataRow()
            'Else
            '    frmDLG.PrdgvCellCollection = Nothing
            '    frmDLG.PrDataRow = Nothing
            'End If
            'dlgRET = frmDLG.ShowDialog(Me)
            'PKeys = frmDLG.PrPKeys

            'If dlgRET = Windows.Forms.DialogResult.Cancel Then
            '    Return False
            'Else
            '    '�ǉ��I���s�I��
            'End If

            Dim strFilePath As String = FunGetRootPath() & "\TEMPLATE\���u����.xlsx"

            Dim hProcess As New System.Diagnostics.Process
            If System.IO.File.Exists(strFilePath) = True Then
                'hProcess = System.Diagnostics.Process.Start(strEXE, strARG)
                hProcess.StartInfo.FileName = strFilePath
                hProcess.SynchronizingObject = Me
                hProcess.EnableRaisingEvents = True
                hProcess.Start()

            Else
                Dim strMsg As String
                strMsg = "���L�t�@�C����������܂���B" & vbCrLf & "�V�X�e���Ǘ��҂ɂ��A���������B" &
                            vbCrLf & vbCrLf & strFilePath
                MessageBox.Show(strMsg, My.Application.Info.AssemblyName, MessageBoxButtons.OK, MessageBoxIcon.Information)
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

            If dgvDATA.RowCount > 0 Then
                cmdFunc3.Enabled = True
                cmdFunc4.Enabled = True
                cmdFunc5.Enabled = True
                'cmdFunc6.Enabled = True
                cmdFunc7.Enabled = True
                cmdFunc8.Enabled = True
                cmdFunc9.Enabled = True
                cmdFunc10.Enabled = True
                cmdFunc11.Enabled = True


                '�I���s��Closed�̏ꍇ
                If dgvDATA.CurrentRow.Cells.Item("CLOSE_FLG").Value = 1 Then
                    cmdFunc4.Enabled = False
                    cmdFunc5.Enabled = False
                    MyBase.ToolTip.SetToolTip(Me.cmdFunc4, "�N���[�Y�ς̂��ߕύX�o���܂���")
                    MyBase.ToolTip.SetToolTip(Me.cmdFunc5, "�N���[�Y�ς̂��ߍ폜�o���܂���")
                Else
                    MyBase.ToolTip.SetToolTip(Me.cmdFunc4, My.Resources.infoToolTipMsgNotFoundData)
                    MyBase.ToolTip.SetToolTip(Me.cmdFunc5, My.Resources.infoToolTipMsgNotFoundData)
                End If

                'If dgvDATA.CurrentRow IsNot Nothing AndAlso dgvDATA.CurrentRow.Cells.Item("DEL_FLG").Value = True Then
                '    '�폜�σf�[�^�̏ꍇ
                '    cmdFunc4.Enabled = False
                '    cmdFunc5.Text = "���S�폜(F5)"
                '    cmdFunc5.Tag = ENM_DATA_OPERATION_MODE._6_DELETE

                '    '����
                '    cmdFunc6.Text = "����(F6)"
                '    cmdFunc6.Visible = True
                '    cmdFunc6.Tag = ENM_DATA_OPERATION_MODE._5_RESTORE
                'Else
                '    cmdFunc5.Text = "�폜(F5)"
                '    cmdFunc5.Tag = ENM_DATA_OPERATION_MODE._4_DISABLE

                '    cmdFunc6.Text = ""
                '    cmdFunc6.Visible = False
                '    cmdFunc6.Tag = ""
                'End If

            Else
                cmdFunc3.Enabled = False
                cmdFunc4.Enabled = False
                cmdFunc5.Enabled = False
                cmdFunc7.Enabled = False
                cmdFunc6.Enabled = False
                cmdFunc6.Visible = False
                cmdFunc8.Enabled = False
                cmdFunc9.Enabled = False
                cmdFunc10.Enabled = False
                cmdFunc11.Enabled = False
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

    '


#End Region


End Class