Imports JMS_COMMON.ClsPubMethod

''' <summary>
''' �R�[�h�}�X�^�������
''' </summary>
Public Class FrmM0010

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

    Private Sub FrmLoad(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Try
            '-----�t�H�[�������ݒ�(�e�t�H�[������Ăяo��)
            Call FunFormCommonSetting(pub_APP_INFO, pub_SYAIN_INFO, My.Application.Info.Version.ToString)
            Using DB As ClsDbUtility = DBOpen()
                lblTytle.Text = FunGetCodeMastaValue(DB, "PG_TITLE", Me.GetType.ToString)
            End Using

            '-----�O���b�h�����ݒ�
            Call FunInitializeFlexGrid(flxDATA)

            '-----�R���g���[���f�[�^�\�[�X�ݒ�
            cmbKOMO_NM.SetDataSource(tblKOMO_NM.ExcludeDeleted, True)

            '-----�C�x���g�n���h���ݒ�
            AddHandler cmbKOMO_NM.SelectedValueChanged, AddressOf SearchFilterValueChanged
            AddHandler chkDeletedRowVisibled.CheckedChanged, AddressOf SearchFilterValueChanged

        Finally
            Call SubInitFuncButtonEnabled()

            '�������s
            cmdFunc1.PerformClick()
        End Try
    End Sub

#End Region

#Region "DataGridView�֘A"

    '������
    Private Function FunInitializeFlexGrid(ByVal flxgrd As C1.Win.C1FlexGrid.C1FlexGrid) As Boolean
        With flxgrd
            .Rows(0).Height = 30

            .AutoGenerateColumns = False
            .AutoResize = True
            .AllowEditing = False
            .AllowDragging = C1.Win.C1FlexGrid.AllowDraggingEnum.None
            .AllowDelete = False
            .AllowResizing = C1.Win.C1FlexGrid.AllowResizingEnum.Columns
            .AllowSorting = C1.Win.C1FlexGrid.AllowSortingEnum.MultiColumn
            '.AllowMerging = C1.Win.C1FlexGrid.AllowMergingEnum.RestrictRows
            .AllowFiltering = True

            .ShowCellLabels = True
            .SelectionMode = C1.Win.C1FlexGrid.SelectionModeEnum.Row
            .FocusRect = C1.Win.C1FlexGrid.FocusRectEnum.None

            .Font = New Font("Meiryo UI", 9, FontStyle.Regular, GraphicsUnit.Point, CType(128, Byte))

            .Styles.Add("DeletedRow")
            .Styles("DeletedRow").BackColor = clrDeletedRowBackColor
            .Styles("DeletedRow").ForeColor = clrDeletedRowForeColor

            .VisualStyle = C1.Win.C1FlexGrid.VisualStyle.Office2010Silver 'Custom

            '�ȉ���K�p����ɂ�VisualStyle��Custom�ɂ���
            .Styles.Alternate.BackColor = clrRowEvenColor
            .Styles.Normal.BackColor = clrRowOddColor
            .Styles.Focus.BackColor = clrRowEnterColor
        End With
    End Function

    '�s�I�����C�x���g
    Private Sub FlxDATA_RowColChange(sender As Object, e As EventArgs) Handles flxDATA.RowColChange
        Call SubInitFuncButtonEnabled()
    End Sub
    '��t�B���^�K�p
    Private Sub FlxDATA_AfterFilter(sender As Object, e As EventArgs) Handles flxDATA.AfterFilter
        Dim flx As C1.Win.C1FlexGrid.C1FlexGrid = DirectCast(sender, C1.Win.C1FlexGrid.C1FlexGrid)
        Dim intCNT As Integer

        For Each r As C1.Win.C1FlexGrid.Row In flx.Rows
            If r.Visible = True Then
                intCNT += 1
            End If
        Next
        intCNT -= flx.Rows.Fixed

        If intCNT > 0 Then
            Me.lblRecordCount.Text = String.Format(My.Resources.infoToolTipMsgFoundData, intCNT)
        Else
            Me.lblRecordCount.Text = My.Resources.infoSearchResultNotFound
        End If
    End Sub

    '�O���b�h�Z��(�s)�_�u���N���b�N���C�x���g
    Private Sub FlxDATA_DoubleClick(sender As Object, e As EventArgs) Handles flxDATA.DoubleClick
        If flxDATA.RowSel > 1 Then
            Me.cmdFunc4.PerformClick()
        End If
    End Sub

#End Region

#Region "FunctionButton�֘A"

#Region "�{�^���N���b�N�C�x���g"

    Private Sub CmdFunc_Click(ByVal sender As Object, ByVal e As EventArgs) Handles cmdFunc1.Click, cmdFunc2.Click, cmdFunc3.Click, cmdFunc4.Click, cmdFunc5.Click, cmdFunc6.Click, cmdFunc7.Click, cmdFunc8.Click, cmdFunc9.Click, cmdFunc10.Click, cmdFunc11.Click, cmdFunc12.Click
        Dim intFUNC As Integer
        Dim intCNT As Integer

        Try
            '[������]
            MyBase.PrPG_STATUS = ENM_PG_STATUS._3_PROCESSING

            '�{�^���s��/�{�^��INDEX�擾
            For intCNT = 0 To cmdFunc.Length - 1
                Me.cmdFunc(intCNT).Enabled = False
                If cmdFunc(intCNT) Is sender Then intFUNC = intCNT + 1
            Next

            '�{�^��INDEX���̏���
            Select Case intFUNC
                Case 1  '����
                    Call FunSRCH(flxDATA, FunGetListData())
                Case 2  '�ǉ�
                    If FunUpdateEntity(ENM_DATA_OPERATION_MODE._1_ADD) Then Call FunSRCH(flxDATA, FunGetListData())

                Case 3  '�Q�ƒǉ�
                    If FunUpdateEntity(ENM_DATA_OPERATION_MODE._2_ADDREF) Then Call FunSRCH(flxDATA, FunGetListData())

                Case 4  '�ύX
                    If FunUpdateEntity(ENM_DATA_OPERATION_MODE._3_UPDATE) Then Call FunSRCH(flxDATA, FunGetListData())

                Case 5, 6  '�폜/����/���S�폜
                    Dim ENM_MODE As ENM_DATA_OPERATION_MODE = DirectCast(sender, Button).Tag
                    If FunDEL(ENM_MODE) Then Call FunSRCH(flxDATA, FunGetListData())

                Case 10  'CSV�o��
                    Dim strFileName As String = pub_APP_INFO.strTitle & "_" & DateTime.Today.ToString("yyyyMMdd") & ".CSV"
                    Call FunCSV_OUT(flxDATA.DataSource, strFileName, pub_APP_INFO.strOUTPUT_PATH)

                Case 12 '����
                    Me.Close()
            End Select
        Catch ex As Exception
            EM.ErrorSyori(ex, False, conblnNonMsg)
        Finally
            '�{�^����
            System.Windows.Forms.Application.DoEvents()
            For intCNT = 0 To cmdFunc.Length - 1
                cmdFunc(intCNT).Enabled = True
            Next

            '�t�@���N�V�����L�[�L����������
            Call SubInitFuncButtonEnabled()

            '[�A�N�e�B�u]
            MyBase.PrPG_STATUS = ENM_PG_STATUS._2_ACTIVE
        End Try
    End Sub

#End Region

#Region "����"

    Private Function FunGetListData() As DataTable
        Try
            Dim sbSQL As New System.Text.StringBuilder
            Dim dsList As New DataSet
            Dim sbSQLWHERE As New System.Text.StringBuilder

            If cmbKOMO_NM.Selected Then
                sbSQLWHERE.Append(" WHERE ITEM_NAME ='" & cmbKOMO_NM.SelectedValue & "' ")
            Else
                If cmbKOMO_NM.Text.IsNullOrWhiteSpace = False Then
                    sbSQLWHERE.Append("  WHERE ITEM_NAME  LIKE '%" & cmbKOMO_NM.Text.Trim & "%' ")
                End If
            End If

            If chkDeletedRowVisibled.Checked Then
                flxDATA.Cols("DEL_FLG").Visible = True
            Else
                flxDATA.Cols("DEL_FLG").Visible = False
                sbSQLWHERE.Append(IIf(sbSQLWHERE.Length = 0, " WHERE ", " AND ") & "DEL_FLG <> 1 ")
            End If

            sbSQL.Append("SELECT")
            sbSQL.Append(" *")
            sbSQL.Append(" FROM " & NameOf(MODEL.VWM001_SETTING) & " ")
            sbSQL.Append(sbSQLWHERE)
            sbSQL.Append(" ORDER BY ITEM_NAME, DISP_ORDER ")
            Using DBa As ClsDbUtility = DBOpen()
                dsList = DBa.GetDataSet(sbSQL.ToString, conblnNonMsg)
            End Using

            If dsList.Tables(0).Rows.Count > pub_APP_INFO.intSEARCHMAX Then
                If MessageBox.Show(My.Resources.infoSearchCountOver, "", MessageBoxButtons.YesNo, MessageBoxIcon.Information) = Windows.Forms.DialogResult.No Then
                    Return Nothing
                End If
            End If

            Dim _Model As New MODEL.ModelInfo(Of MODEL.VWM001_SETTING)(srcDATA:=dsList.Tables(0))
            Return _Model.Data

        Catch ex As Exception
            EM.ErrorSyori(ex, False, conblnNonMsg)
            Return Nothing
        End Try
    End Function

    Private Function FunSRCH(ByVal flx As C1.Win.C1FlexGrid.C1FlexGrid, ByVal dt As DataTable) As Boolean
        Dim intCURROW As Integer
        Try

            '-----�I���s�L��
            If flx.Rows.Count > 0 Then
                intCURROW = flx.RowSel
            End If

            flx.BeginUpdate()
            flx.DataSource = dt

            Call FunSetGridCellFormat(flx)

            If flx.Rows.Count > 0 Then
                '-----�I���s�ݒ�
                Try
                    flx.RowSel = intCURROW
                Catch dgvEx As Exception
                End Try
                lblRecordCount.Text = String.Format(My.Resources.infoToolTipMsgFoundData, flx.Rows.Count - flx.Rows.Fixed.ToString)
            Else
                lblRecordCount.Text = My.Resources.infoSearchResultNotFound
            End If

            Return True

        Catch ex As Exception
            EM.ErrorSyori(ex, False, conblnNonMsg)
            Return False
        Finally

            flx.EndUpdate()
        End Try
    End Function

    Private Function FunSetGridCellFormat(ByVal flx As C1.Win.C1FlexGrid.C1FlexGrid) As Boolean

        Try

            For Each r As C1.Win.C1FlexGrid.Row In flx.Rows
                If r.Index > 0 AndAlso CBool(r.Item("DEL_FLG")) = True Then
                    r.Style = flx.Styles("DeletedRow")
                End If
            Next

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
        Dim dlgRET As DialogResult
        Dim PKeys As (ITEM_NAME As String, ITEM_VALUE As String)
        Dim strComboVal As String

        Try

            '�R���{�{�b�N�X�̑I��l���L��
            If cmbKOMO_NM.SelectedValue IsNot Nothing Then
                strComboVal = cmbKOMO_NM.SelectedValue
            Else
                strComboVal = ""
            End If

            Using frmDLG As New FrmM0011
                frmDLG.PrMODE = intMODE
                If flxDATA.RowSel > 0 Then
                    frmDLG.PrDataRow = DirectCast(flxDATA.Rows(flxDATA.Row).DataSource, DataRowView).Row 'flxDATA.Rows(flxDATA.Row)
                Else
                    frmDLG.PrDataRow = Nothing
                End If
                dlgRET = frmDLG.ShowDialog(Me)
                PKeys = frmDLG.PrPKeys
            End Using

            If dlgRET = Windows.Forms.DialogResult.Cancel Then
                Return False
            Else

                '-----���ږ����ǉ��ɂȂ����ꍇ�A�����t�B���^�̃R���{�{�b�N�X�̃f�[�^�\�[�X���Đݒ�
                Using DB As ClsDbUtility = DBOpen()
                    Call FunGetCodeDataTable(DB, "���ږ�", tblKOMO_NM)
                End Using
                Me.cmbKOMO_NM.SetDataSource(tblKOMO_NM.ExcludeDeleted, True)
                Me.cmbKOMO_NM.SelectedValue = strComboVal


                '�ǉ������R�[�h�̍s��I������
                For i As Integer = 0 To flxDATA.Rows.Count
                    With flxDATA.Rows(i)
                        If .Item("ITEM_NAME") = PKeys.ITEM_NAME And
                            .Item("ITEM_VALUE") = PKeys.ITEM_VALUE Then

                            flxDATA.RowSel = i
                            Exit For
                        End If
                    End With
                Next i
            End If

            Return True
        Catch ex As Exception
            EM.ErrorSyori(ex, False, conblnNonMsg)
            Return False
        Finally
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
            strComboVal = Me.cmbKOMO_NM.Text.Trim

            '-----SQL
            sbSQL.Remove(0, sbSQL.Length)
            Select Case ENM_MODE
                Case ENM_DATA_OPERATION_MODE._4_DISABLE
                    '-----�X�V
                    sbSQL.Append("UPDATE " & NameOf(MODEL.M001_SETTING) & " SET ")
                    '�폜����
                    sbSQL.Append(" DEL_YMDHNS = dbo.GetSysDateString(), ")
                    '�폜�S����
                    sbSQL.Append(" DEL_SYAIN_ID = " & pub_SYAIN_INFO.SYAIN_ID & "")

                    strMsg = My.Resources.infoMsgDeleteOperationDisable
                    strTitle = My.Resources.infoTitleDeleteOperationDisable

                Case ENM_DATA_OPERATION_MODE._5_RESTORE
                    '-----�X�V
                    sbSQL.Append("UPDATE " & NameOf(MODEL.M001_SETTING) & " SET ")
                    '�폜����
                    sbSQL.Append(" DEL_YMDHNS = ' ', ")
                    '�폜�S����
                    sbSQL.Append(" DEL_SYAIN_ID = " & pub_SYAIN_INFO.SYAIN_ID & "")

                    strMsg = My.Resources.infoMsgDeleteOperationRestore
                    strTitle = My.Resources.infoTitleDeleteOperationRestore

                Case ENM_DATA_OPERATION_MODE._6_DELETE

                    '-----�폜
                    sbSQL.Append("DELETE FROM " & NameOf(MODEL.M001_SETTING) & " ")

                    strMsg = My.Resources.infoMsgDeleteOperationDelete
                    strTitle = My.Resources.infoTitleDeleteOperationDelete

                Case Else
                    ' argument null exception
                    Return False
            End Select
            sbSQL.Append(" WHERE")
            sbSQL.Append(" ITEM_NAME = '" & flxDATA.Rows(flxDATA.RowSel).Item("ITEM_NAME").ToString & "' ")
            sbSQL.Append(" AND ITEM_VALUE = '" & flxDATA.Rows(flxDATA.RowSel).Item("ITEM_VALUE").ToString & "' ")

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
            Me.cmbKOMO_NM.SetDataSource(tblKOMO_NM.ExcludeDeleted, True)

            If strComboVal.IsNullOrWhiteSpace Then
            Else
                Me.cmbKOMO_NM.Text = strComboVal
            End If
            If Me.cmbKOMO_NM.SelectedIndex <= 0 Then
                Me.cmbKOMO_NM.Text = ""
            End If

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
    Private Function SubInitFuncButtonEnabled() As Boolean

        For intFunc As Integer = 1 To 12
            With Me.Controls("cmdFunc" & intFunc)
                If .Text.Length = 0 OrElse .Text.Substring(0, .Text.IndexOf("(")).IsNullOrWhiteSpace Then
                    .Text = ""
                    .Visible = False
                End If
            End With
        Next intFunc

        If flxDATA.Rows.Count > 0 Then
            cmdFunc3.Enabled = True
            cmdFunc4.Enabled = True
            cmdFunc5.Enabled = True
            cmdFunc10.Enabled = True
        Else
            cmdFunc3.Enabled = False
            cmdFunc4.Enabled = False
            cmdFunc5.Enabled = False
            cmdFunc10.Enabled = False
        End If

        If flxDATA.RowSel > 0 Then
            If flxDATA(flxDATA.RowSel, "DEL_FLG") = True Then
                '�폜�σf�[�^�̏ꍇ
                cmdFunc4.Enabled = False
                cmdFunc5.Text = "���S�폜(F5)"
                cmdFunc5.Tag = ENM_DATA_OPERATION_MODE._6_DELETE

                '����
                cmdFunc6.Text = "����(F6)"
                cmdFunc6.Visible = True
                cmdFunc6.Tag = ENM_DATA_OPERATION_MODE._5_RESTORE
            Else
                cmdFunc5.Text = "�폜(F5)"
                cmdFunc5.Tag = ENM_DATA_OPERATION_MODE._4_DISABLE

                cmdFunc6.Text = ""
                cmdFunc6.Visible = False
                cmdFunc6.Tag = ""
            End If
        Else
            cmdFunc6.Visible = False
        End If

    End Function

#End Region

#End Region

#Region "�R���g���[���C�x���g"

    '�����t�B���^�ύX
    Private Sub SearchFilterValueChanged(sender As System.Object, e As System.EventArgs)
        '����
        cmdFunc1.PerformClick()

    End Sub

#End Region

End Class