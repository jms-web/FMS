Imports JMS_COMMON.ClsPubMethod

''' <summary>
''' ���u����
''' </summary>
Public Class FrmG0017

#Region "�v���p�e�B"

    Public Property PrSYONIN_HOKOKUSYO_ID As Integer

    Public Property PrHOKOKUSYO_NO As String
#End Region

#Region "�R���X�g���N�^"

    ''' <summary>
    ''' �R���X�g���N�^
    ''' </summary>
    ''' <remarks>�R���X�g���N�^</remarks>
    Public Sub New()

        ' ���̌Ăяo���̓f�U�C�i�[�ŕK�v�ł��B
        InitializeComponent()

    End Sub

#End Region

#Region "Form�֘A"

    'Load�C�x���g
    Private Sub FrmLoad(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        Try
            '-----�t�H�[�������ݒ�(�e�t�H�[������Ăяo��)
            Call FunFormCommonSetting(pub_APP_INFO, pub_SYAIN_INFO, My.Application.Info.Version.ToString)

            '-----�O���b�h�����ݒ�(�e�t�H�[������Ăяo��)
            Call FunInitializeDataGridView(Me.dgvDATA)

            '-----�O���b�h��쐬
            Call FunSetDgvCulumns(Me.dgvDATA)

            '�������s
            Call FunSRCH(Me.dgvDATA, FunGetListData())
        Finally
            Call FunInitFuncButtonEnabled()
        End Try
    End Sub

#End Region

#Region "DataGridView�֘A"

    '�t�B�[���h��`()
    Private Shared Function FunSetDgvCulumns(ByVal dgv As DataGridView) As Boolean

        Try
            With dgv
                .AutoGenerateColumns = False


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
                Me.cmdFunc1.PerformClick()
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

            dt.Columns.Add("SYONIN_HOKOKUSYO_ID", GetType(Integer))
            dt.Columns.Add("SYONIN_JUN", GetType(Integer))

            '��L�[�ݒ�
            dt.PrimaryKey = {dt.Columns("SYONIN_JUN"), dt.Columns("VALUE")}

            With dsList.Tables(0)
                For intCNT = 0 To .Rows.Count - 1
                    Dim Trow As DataRow = dt.NewRow()
                    '
                    Trow("DISP") = .Rows(intCNT).Item("SIMEI")
                    Trow("VALUE") = .Rows(intCNT).Item("SYAIN_ID")
                    Trow("DEL_FLG") = CBool(.Rows(intCNT).Item("DEL_FLG"))
                    Trow("SYONIN_HOKOKUSYO_ID") = .Rows(intCNT).Item("SYONIN_HOKOKUSYO_ID")
                    Trow("SYONIN_JUN") = .Rows(intCNT).Item("SYONIN_JUN")

                    dt.Rows.Add(Trow)
                Next intCNT
            End With

            Return dt
        Catch ex As Exception
            EM.ErrorSyori(ex, False, conblnNonMsg)
            Return Nothing
        End Try
    End Function

    Private Function FunSRCH(ByVal dgv As DataGridView, ByVal dt As DataTable) As Boolean

        Try
            dgv.DataSource = dt

            Call FunSetDgvCellFormat(dgv)

            If dgv.RowCount > 0 Then
                '-----�I���s�ݒ�
                Try
                    dgv.CurrentCell = dgv.Rows(intDgvCurrentRow).Cells(0)
                Catch dgvEx As Exception
                End Try
                lblRecordCount.Text = String.Format(My.Resources.infoToolTipMsgFoundData, dgv.RowCount.ToString)
            Else
                lblRecordCount.Text = My.Resources.infoSearchResultNotFound
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
        'Dim PKeys As Tuple(Of String, String)
        'Dim strComboVal As String

        Try
            ' �Q�ƌ^��System.Tuple��l�^��System.ValueTuple�ɒu��������

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

#Region "FuncButton�L�������ؑ�"

    ''' <summary>
    ''' �g�p���Ȃ��{�^���̃L���v�V�������Ȃ����A���񊈐��ɂ���B
    ''' �t�@���N�V�����L�[������(F**)�ȊO�̕������Ȃ��ꍇ�́A���g�p�Ƃ݂Ȃ�
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Private Function FunInitFuncButtonEnabled() As Boolean
        Try

            For intFunc As Integer = 1 To 12
                With Me.Controls("cmdFunc" & intFunc)
                    If .Text.Length = 0 OrElse .Text.Substring(0, .Text.IndexOf("(")).IsNullOrWhiteSpace Then
                        .Text = ""
                        .Visible = False
                    End If
                End With
            Next intFunc

            Return True
        Catch ex As Exception
            EM.ErrorSyori(ex, False, conblnNonMsg)
            Return False
        End Try
    End Function

#End Region

#End Region

#Region "�R���g���[���C�x���g"

#End Region



End Class