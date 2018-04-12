Imports JMS_COMMON.ClsPubMethod


Public Class FrmG0013

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

#Region "�v���p�e�B"

    ''' <summary>
    ''' �v��
    ''' </summary>
    Public Property PrYOIN As (Value As String, Name As String)

    ''' <summary>
    ''' �I�����������̒l���X�g
    ''' </summary>
    ''' <returns></returns>
    Public Property PrSelectedList As List(Of (ITEM_NAME As String, ITEM_VALUE As String))

#End Region

#Region "Form�֘A"

    'Load�C�x���g
    Private Sub FrmLoad(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        Try
            '-----�t�H�[�������ݒ�(�e�t�H�[������Ăяo��)
            Call FunFormCommonSetting(pub_APP_INFO, pub_SYAIN_INFO, My.Application.Info.Version.ToString)
            lblTytle.Text = "�������͋敪�̑I��(" & PrYOIN.Name & ")"
            Me.Text = lblTytle.Text
            Me.Width = 1024
            Me.Height = 570

            '-----�O���b�h�����ݒ�(�e�t�H�[������Ăяo��)
            Call FunInitializeDataGridView(Me.dgvDATA)
            Call FunInitializeDataGridView(Me.dgvDetail)

            '-----�O���b�h��쐬
            Call FunSetDgvCulumns(Me.dgvDATA)
            Call FunSetDgvCulumns(Me.dgvDetail)

            '-----�R���g���[���f�[�^�\�[�X�ݒ�

            '�������s
            Me.cmdFunc1.PerformClick()
        Finally

        End Try
    End Sub

#End Region

#Region "DataGridView�֘A"

    '�t�B�[���h��`
    Private Shared Function FunSetDgvCulumns(ByVal dgv As DataGridView) As Boolean
        Try
            With dgv
                Select Case dgv.Name
                    Case "dgvDATA"
                        .AutoGenerateColumns = False
                        .ReadOnly = False

                        .RowsDefaultCellStyle.BackColor = Color.White
                        .AlternatingRowsDefaultCellStyle.BackColor = Color.White

                        .Columns.Add("ITEM_VALUE", "ITEM_VALUE")
                        .Columns(.ColumnCount - 1).DataPropertyName = .Columns(.ColumnCount - 1).Name
                        .Columns(.ColumnCount - 1).Visible = False

                        .Columns.Add("ITEM_DISP", "���ږ�")
                        .Columns(.ColumnCount - 1).Width = 280
                        .Columns(.ColumnCount - 1).DefaultCellStyle.Alignment = Windows.Forms.DataGridViewContentAlignment.MiddleLeft
                        .Columns(.ColumnCount - 1).DataPropertyName = .Columns(.ColumnCount - 1).Name
                        .Columns(.ColumnCount - 1).ReadOnly = True

                        Dim cmbclmn1 As New DataGridViewCheckBoxColumn With {
                        .Name = "SELECT_COUNT",
                        .HeaderText = "�I������",
                        .DataPropertyName = .Name
                        }
                        cmbclmn1.DefaultCellStyle.Alignment = Windows.Forms.DataGridViewContentAlignment.MiddleCenter
                        .Columns.Add(cmbclmn1)
                        .Columns(.ColumnCount - 1).SortMode = DataGridViewColumnSortMode.Automatic
                        .Columns(.ColumnCount - 1).Width = 30

                    Case "dgvDetail"
                        .AutoGenerateColumns = False
                        .ReadOnly = False

                        .RowsDefaultCellStyle.BackColor = Color.White
                        .AlternatingRowsDefaultCellStyle.BackColor = Color.White

                        Dim cmbclmn1 As New DataGridViewCheckBoxColumn With {
                        .Name = "SELECTED",
                        .HeaderText = "�I��",
                        .DataPropertyName = .Name
                        }
                        cmbclmn1.DefaultCellStyle.Alignment = Windows.Forms.DataGridViewContentAlignment.MiddleCenter
                        .Columns.Add(cmbclmn1)
                        .Columns(.ColumnCount - 1).SortMode = DataGridViewColumnSortMode.Automatic
                        .Columns(.ColumnCount - 1).Width = 30

                        .Columns.Add("ITEM_NAME", "ITEM_NAME")
                        .Columns(.ColumnCount - 1).DataPropertyName = .Columns(.ColumnCount - 1).Name
                        .Columns(.ColumnCount - 1).Visible = False

                        .Columns.Add("ITEM_VALUE", "ITEM_VALUE")
                        .Columns(.ColumnCount - 1).DataPropertyName = .Columns(.ColumnCount - 1).Name
                        .Columns(.ColumnCount - 1).Visible = False

                        .Columns.Add("ITEM_DISP", "���ږ�")
                        .Columns(.ColumnCount - 1).Width = 280
                        .Columns(.ColumnCount - 1).DefaultCellStyle.Alignment = Windows.Forms.DataGridViewContentAlignment.MiddleLeft
                        .Columns(.ColumnCount - 1).DataPropertyName = .Columns(.ColumnCount - 1).Name
                        .Columns(.ColumnCount - 1).ReadOnly = True
                End Select
            End With

            Return True
        Finally

        End Try
    End Function

    '�O���b�h�Z��(�s)�_�u���N���b�N���C�x���g
    Private Sub DgvDATA_CellDoubleClick(sender As System.Object, e As DataGridViewCellEventArgs)

    End Sub

    '�s�I�����C�x���g
    Private Overloads Sub DgvDATA_SelectionChanged(sender As System.Object, e As System.EventArgs) Handles dgvDATA.SelectionChanged
        Try
            If dgvDATA.CurrentRow IsNot Nothing Then
                Call FunSRCH(dgvDetail, FunGetDgvDetail(dgvDATA.CurrentRow.Cells("ITEM_VALUE").Value))
            End If
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
                Case 1  '
                    Call FunSRCH(dgvDATA, FunGetListData())
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

    '���C��(���͋敪)�O���b�h�̃f�[�^�\�[�擾
    Private Function FunGetListData() As DataTable
        Try
            Dim sbSQL As New System.Text.StringBuilder
            Dim dsList As New DataSet

            sbSQL.Remove(0, sbSQL.Length)
            sbSQL.Append("SELECT")
            sbSQL.Append(" *")
            sbSQL.Append(" FROM " & NameOf(MODEL.M001_SETTING) & " ")
            sbSQL.Append(" WHERE ITEM_NAME='�������͋敪'")
            sbSQL.Append(" ORDER BY DISP_ORDER ")
            Using DBa As ClsDbUtility = DBOpen()
                dsList = DBa.GetDataSet(sbSQL.ToString, conblnNonMsg)
            End Using

            'If dsList.Tables(0).Rows.Count > pub_APP_INFO.intSEARCHMAX Then
            '    If MessageBox.Show(My.Resources.infoSearchCountOver, "", MessageBoxButtons.YesNo, MessageBoxIcon.Information) = Windows.Forms.DialogResult.No Then
            '        Return Nothing
            '    End If
            'End If

            '------DataTable�ɕϊ�
            Dim dt As New DataTable
            dt.Columns.Add("ITEM_NAME", GetType(String))
            dt.Columns.Add("ITEM_VALUE", GetType(String))
            dt.Columns.Add("ITEM_DISP", GetType(String))
            dt.Columns.Add("SELECT_COUNT", GetType(Integer))
            dt.PrimaryKey = {dt.Columns("ITEM_NAME"), dt.Columns("ITEM_VALUE")}

            With dsList.Tables(0)
                For Each row As DataRow In .Rows
                    Dim Trow As DataRow = dt.NewRow()
                    Trow("ITEM_NAME") = row.Item("ITEM_NAME")
                    Trow("ITEM_VALUE") = row.Item("ITEM_VALUE")
                    Trow("ITEM_DISP") = row.Item("ITEM_DISP")
                    Trow("SELECT_COUNT") = 0
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

            dgv.DataSource = dt

            'Call FunSetDgvCellFormat(dgv)

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
            'Dim _Model As New MODEL.M001_SETTING
            'For i As Integer = 0 To dgv.Rows.Count - 1
            '    With dgv.Rows(i)
            '        'If CBool(Me.dgvDATA.Rows(i).Cells(NameOf(_Model.DEL_FLG)).Value) = True Then
            '        '    Me.dgvDATA.Rows(i).DefaultCellStyle.ForeColor = clrDeletedRowForeColor
            '        '    Me.dgvDATA.Rows(i).DefaultCellStyle.BackColor = clrDeletedRowBackColor
            '        '    Me.dgvDATA.Rows(i).DefaultCellStyle.SelectionForeColor = clrDeletedRowForeColor
            '        'End If
            '    End With
            'Next i
        Catch ex As Exception
            EM.ErrorSyori(ex, False, conblnNonMsg)
        End Try
    End Function

    '�ڍ׃O���b�h�̃f�[�^�\�[�X�擾
    Private Function FunGetDgvDetail(ByVal strValue As String) As DataTable
        Try

            Dim strItemName As String
            Select Case strValue
                Case ENM_GENIN_BUNSEKI_KB._0_m_�}�l�W�����g
                    strItemName = "m-�}�l�W�����g"
                Case ENM_GENIN_BUNSEKI_KB._1_S_�\�t�g�E�F�A
                    strItemName = "S-�\�t�g�E�F�A"
                Case ENM_GENIN_BUNSEKI_KB._2_h_�n�[�h�E�F�A
                    strItemName = "h-�n�[�h�E�F�A"
                Case ENM_GENIN_BUNSEKI_KB._3_e_��Ɗ�
                    strItemName = "e-��Ɗ�"
                Case ENM_GENIN_BUNSEKI_KB._4_L1_�{�l
                    strItemName = "L1-�{�l"
                Case ENM_GENIN_BUNSEKI_KB._5_L2_�֌W��_�x���̐�
                    strItemName = "L2-�֌W�ҁE�x���̐�"
                Case Else
                    strItemName = ""
                    'err
            End Select

            Dim sbSQL As New System.Text.StringBuilder
            Dim dsList As New DataSet
            sbSQL.Remove(0, sbSQL.Length)
            sbSQL.Append("SELECT")
            sbSQL.Append(" *")
            sbSQL.Append(" FROM " & NameOf(MODEL.M001_SETTING) & " ")
            sbSQL.Append(" WHERE ITEM_NAME='" & strItemName & "'")
            sbSQL.Append(" ORDER BY DISP_ORDER ")
            Using DBa As ClsDbUtility = DBOpen()
                dsList = DBa.GetDataSet(sbSQL.ToString, conblnNonMsg)
            End Using

            'If dsList.Tables(0).Rows.Count > pub_APP_INFO.intSEARCHMAX Then
            '    If MessageBox.Show(My.Resources.infoSearchCountOver, "", MessageBoxButtons.YesNo, MessageBoxIcon.Information) = Windows.Forms.DialogResult.No Then
            '        Return Nothing
            '    End If
            'End If

            '------DataTable�ɕϊ�
            Dim dt As New DataTable

            Dim t As Type = GetType(MODEL.M001_SETTING)
            Dim properties As Reflection.PropertyInfo() = t.GetProperties(
                 Reflection.BindingFlags.Public Or
                 Reflection.BindingFlags.NonPublic Or
                 Reflection.BindingFlags.Instance Or
                 Reflection.BindingFlags.Static)

            For Each p As Reflection.PropertyInfo In properties
                dt.Columns.Add(p.Name, p.PropertyType)
            Next p

            dt.Columns.Add("SELECTED", GetType(Boolean))

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

            'Dim dgv As DataGridView = DirectCast(Controls("dgvDATA"), DataGridView)

            'If dgv.RowCount > 0 Then
            '    cmdFunc3.Enabled = True
            '    cmdFunc4.Enabled = True
            '    cmdFunc5.Enabled = True
            '    cmdFunc10.Enabled = True
            'Else
            '    cmdFunc3.Enabled = False
            '    cmdFunc4.Enabled = False
            '    cmdFunc5.Enabled = False
            '    cmdFunc10.Enabled = False
            'End If

            'If dgv.SelectedRows.Count > 0 Then
            '    If dgv.CurrentRow IsNot Nothing AndAlso dgv.CurrentRow.Cells.Item("DEL_FLG").Value = True Then
            '        '�폜�σf�[�^�̏ꍇ
            '        cmdFunc4.Enabled = False
            '        cmdFunc5.Text = "���S�폜(F5)"
            '        cmdFunc5.Tag = ENM_DATA_OPERATION_MODE._6_DELETE

            '        '����
            '        cmdFunc6.Text = "����(F6)"
            '        cmdFunc6.Visible = True
            '        cmdFunc6.Tag = ENM_DATA_OPERATION_MODE._5_RESTORE
            '    Else
            '        cmdFunc5.Text = "�폜(F5)"
            '        cmdFunc5.Tag = ENM_DATA_OPERATION_MODE._4_DISABLE

            '        cmdFunc6.Text = ""
            '        cmdFunc6.Visible = False
            '        cmdFunc6.Tag = ""
            '    End If
            'Else
            '    cmdFunc6.Visible = False
            'End If

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