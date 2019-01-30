Imports JMS_COMMON.ClsPubMethod

''' <summary>
''' �@��}�X�^�ҏW���
''' </summary>
Public Class FrmM1071

#Region "�ϐ��E�萔"
    Private IsValidated As Boolean
    Private _VWM107 As New MODEL.VWM107_BUHIN_KISYU
#End Region

#Region "�v���p�e�B"
    ''' <summary>
    ''' �������[�h
    ''' </summary>
    Public Property PrDATA_OP_MODE As Integer

    ''' <summary>
    ''' �V�K�ǉ����R�[�h�̃L�[
    ''' </summary>
    Public Property PrPKeys As Integer

    ''' <summary>
    ''' �ꗗ�̑I���s�f�[�^
    ''' </summary>
    Public Property PrDataRow As DataRow

#End Region

#Region "�R���X�g���N�^"

    ''' <summary>
    ''' �R���X�g���N�^
    ''' </summary>
    ''' <remarks>�R���X�g���N�^</remarks>
    Public Sub New()

        ' ���̌Ăяo���̓f�U�C�i�[�ŕK�v�ł��B
        InitializeComponent()

        Me.Height = 560
        Me.FormBorderStyle = Windows.Forms.FormBorderStyle.FixedDialog
        Me.MaximizeBox = False
        Me.MinimizeBox = False

    End Sub

#End Region

#Region "FORM�C�x���g"
    Private Sub Frm_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        Try
            '-----�t�H�[�����ʐݒ�
            Call FunFormCommonSetting(pub_APP_INFO, pub_SYAIN_INFO)
            Using DB As ClsDbUtility = DBOpen()
                lblTytle.Text = FunGetCodeMastaValue(DB, "PG_TITLE", Me.GetType.ToString)
            End Using

            '-----�ʒu�E�T�C�Y

            Me.Top = Me.Owner.Top + (Me.Owner.Height - Me.Height) - 26 ' / 2
            Me.Left = Me.Owner.Left + (Me.Owner.Width - Me.Width) / 2

            '-----�R���g���[���f�[�^�\�[�X�ݒ�
            'cmbBUMON_KB.SetDataSource(tblBUMON.ExcludeDeleted, ENM_COMBO_SELECT_VALUE_TYPE._0_Required)
            '-----�O���b�h�����ݒ�
            Call FunInitializeFlexGrid(flxDATA)

            Call FunSetBinding()

            '-----�������[�h�ʉ�ʏ�����
            Call FunInitializeControls()

        Catch ex As Exception
            EM.ErrorSyori(ex, False, conblnNonMsg)
        Finally
            Call FunInitFuncButtonEnabled()
        End Try
    End Sub

#End Region

#Region "FUNCTION�{�^��CLICK"

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
                Case 1  '�ǉ�
                    If FunSAVE() Then
                        '�v���p�e�B�ɑΏۃ��R�[�h�̃L�[��ݒ�
                        Me.PrPKeys = _VWM107.KISYU_ID

                        Me.DialogResult = Windows.Forms.DialogResult.OK
                        Me.Close()
                    End If

                Case 12 '�߂�
                    Me.DialogResult = Windows.Forms.DialogResult.Cancel
                    Me.Close()
            End Select

        Catch ex As Exception
            EM.ErrorSyori(ex)
        Finally
            '�{�^����
            System.Windows.Forms.Application.DoEvents()
            For intCNT = 0 To Me.cmdFunc.Length - 1
                Me.cmdFunc(intCNT).Enabled = True
            Next
        End Try
    End Sub

#End Region

#Region "�X�V"

    Private Function FunSAVE() As Boolean
        Dim sbSQL As New System.Text.StringBuilder
        Dim intRET As Integer
        Dim sqlEx As New Exception
        Dim strSysDate As String
        Dim dsList As New DataSet
        Try

            '���̓`�F�b�N
            'If FunCheckInput() = False Then Return False

            Using DB As ClsDbUtility = DBOpen()
                Dim blnErr As Boolean
                Try
                    DB.BeginTransaction()

                    strSysDate = DB.GetSysDateString()

                    Dim ModelInfo As New MODEL.ModelInfo(Of MODEL.M107_BUHIN_KISYU)(_OnlyAutoGenerateField:=True)

                    sbSQL.Remove(0, sbSQL.Length)
                    sbSQL.Append("SELECT * FROM " & ModelInfo.Name & " ")
                    sbSQL.Append(" WHERE ")
                    sbSQL.Append("     BUMON_KB    = '" & _VWM107.BUMON_KB & "'")
                    sbSQL.Append(" AND TOKUI_ID    =  " & _VWM107.TOKUI_ID & " ")
                    sbSQL.Append(" AND BUHIN_BANGO = '" & _VWM107.BUHIN_BANGO.Trim & "'")
                    sbSQL.Append(" AND KISYU_ID    =  " & Me.flxDATA.Rows(Me.flxDATA.RowSel).Item("KISYU_ID") & " ")

                    dsList = DB.GetDataSet(sbSQL.ToString, conblnNonMsg)

                    If dsList.Tables(0).Rows.Count > 0 Then
                        Call MsgBox("���ɒǉ�����Ă���@��ł��B�ʂ̋@���I�����Ă��������B", vbExclamation + vbOKOnly, "�d���o�^")
                        Return False
                    End If

                    sbSQL.Remove(0, sbSQL.Length)
                    sbSQL.Append("INSERT INTO " & ModelInfo.Name & "(")
                    sbSQL.Append(" BUMON_KB")
                    sbSQL.Append(",TOKUI_ID")
                    sbSQL.Append(",BUHIN_BANGO")
                    sbSQL.Append(",KISYU_ID")
                    sbSQL.Append(",ADD_YMDHNS")
                    sbSQL.Append(",ADD_SYAIN_ID")
                    sbSQL.Append(",UPD_YMDHNS")
                    sbSQL.Append(",UPD_SYAIN_ID")
                    sbSQL.Append(",DEL_YMDHNS")
                    sbSQL.Append(",DEL_SYAIN_ID")
                    sbSQL.Append(") VALUES (")
                    sbSQL.Append(" '" & _VWM107.BUMON_KB & "'")
                    sbSQL.Append(", " & _VWM107.TOKUI_ID & " ")
                    sbSQL.Append(",'" & _VWM107.BUHIN_BANGO.Trim & "'")
                    sbSQL.Append(", " & Me.flxDATA.Rows(Me.flxDATA.RowSel).Item("KISYU_ID") & " ")
                    sbSQL.Append(",'" & strSysDate & "'")
                    sbSQL.Append(", " & pub_SYAIN_INFO.SYAIN_ID & " ")
                    sbSQL.Append(",' '")
                    sbSQL.Append(", " & 0 & " ")
                    sbSQL.Append(",' '")
                    sbSQL.Append(", " & 0 & " ")
                    sbSQL.Append(")")

                    intRET = DB.ExecuteNonQuery(sbSQL.ToString, conblnNonMsg, sqlEx)

                    If intRET <> 1 Then
                        Dim strErrMsg As String = $"{My.Resources.ErrLogSqlExecutionFailure}{sbSQL.ToString}|{sqlEx.Message}"
                        WL.WriteLogDat(strErrMsg)
                        blnErr = True
                        Return False
                    End If

                    blnErr = False

                    Return True

                Finally
                    DB.Commit(Not blnErr)
                End Try
            End Using

            Return True
        Catch ex As Exception
            EM.ErrorSyori(ex, False, conblnNonMsg)
            Return False
        Finally

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
    Public Function FunInitFuncButtonEnabled() As Boolean

        Try
            For intFunc As Integer = 1 To 12
                With Me.Controls("cmdFunc" & intFunc)
                    If .Text.Length = 0 OrElse .Text.Substring(0, .Text.IndexOf("(")).IsNulOrWS Then
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

#Region "���[�J���֐�"

#Region "�o�C���f�B���O"
    Private Function FunSetBinding() As Boolean
        mtxBumon_KB.DataBindings.Add(New Binding(NameOf(mtxBumon_KB.Text), _VWM107, NameOf(_VWM107.BUMON_KB_DISP), False, DataSourceUpdateMode.OnPropertyChanged, ""))
        mtxTORI_NAME.DataBindings.Add(New Binding(NameOf(mtxTORI_NAME.Text), _VWM107, NameOf(_VWM107.TORI_NAME), False, DataSourceUpdateMode.OnPropertyChanged, ""))
        mtxBUHIN_BANGO.DataBindings.Add(New Binding(NameOf(mtxBUHIN_BANGO.Text), _VWM107, NameOf(_VWM107.BUHIN_BANGO), False, DataSourceUpdateMode.OnPropertyChanged, ""))
        mtxBUHIN_NAME.DataBindings.Add(New Binding(NameOf(mtxBUHIN_NAME.Text), _VWM107, NameOf(_VWM107.BUHIN_NAME), False, DataSourceUpdateMode.OnPropertyChanged, ""))

    End Function

#End Region

#Region "�������[�h�ʉ�ʏ�����"
    Private Function FunInitializeControls() As Boolean
        Dim _Model = New MODEL.ModelInfo(Of MODEL.VWM107_BUHIN_KISYU)(_OnlyAutoGenerateField:=True)

        Try
            Select Case PrDATA_OP_MODE
                Case ENM_DATA_OPERATION_MODE._1_ADD
                    lblTytle.Text &= "�i�ǉ��j"
                    cmdFunc1.Text = "�ǉ�(F1)"

                    _Model.Properties.ForEach(Sub(p)
                                                  Select Case p.PropertyType
                                                      Case GetType(Boolean)
                                                          _VWM107(p.Name) = CBool(PrDataRow.Item(p.Name))
                                                      Case Else
                                                          _VWM107(p.Name) = PrDataRow.Item(p.Name)
                                                  End Select
                                              End Sub)

                    lbllblEDIT_YMDHNS.Visible = False
                    lblEDIT_YMDHNS.Visible = False
                    lbllblEDIT_SYAIN_ID.Visible = False
                    lblEDIT_SYAIN_ID.Visible = False

                Case ENM_DATA_OPERATION_MODE._2_ADDREF


                    'lblTytle.Text &= "�i�ގ��ǉ��j"
                    'cmdFunc1.Text = "�ǉ�(F1)"

                    'mtxKISYU_ID.Text = "<�V�K>"
                    'mtxKISYU_ID.ReadOnly = True

                    'lbllblEDIT_YMDHNS.Visible = False
                    'lblEDIT_YMDHNS.Visible = False
                    'lbllblEDIT_SYAIN_ID.Visible = False
                    'lblEDIT_SYAIN_ID.Visible = False

                Case ENM_DATA_OPERATION_MODE._3_UPDATE
                    '_Model.Properties.ForEach(Sub(p)
                    '                              Select Case p.PropertyType
                    '                                  Case GetType(Boolean)
                    '                                      _M105(p.Name) = CBool(PrDataRow.Item(p.Name))
                    '                                  Case Else
                    '                                      _M105(p.Name) = PrDataRow.Item(p.Name)
                    '                              End Select
                    '                          End Sub)

                    'lblTytle.Text &= "�i�ύX�j"
                    'Me.cmdFunc1.Text = "�ύX(F1)"

                    ''mtxKISYU_ID.ReadOnly = True

                    'lbllblEDIT_YMDHNS.Visible = True
                    'lblEDIT_YMDHNS.Visible = True
                    'lbllblEDIT_SYAIN_ID.Visible = True
                    'lblEDIT_SYAIN_ID.Visible = True

                    ''�X�V����
                    'lblEDIT_YMDHNS.Text = DateTime.ParseExact(PrDataRow.Item(NameOf(_M105.UPD_YMDHNS)), "yyyyMMddHHmmss", Nothing).ToString("yyyy/MM/dd HH:mm:ss")
                    ''�X�V�S����CD
                    'lblEDIT_SYAIN_ID.Text = PrDataRow.Item(NameOf(_M105.UPD_SYAIN_ID)) & " " & Fun_GetUSER_NAME(PrDataRow.Item(NameOf(_M105.UPD_SYAIN_ID)))

                Case Else
                    Throw New ArgumentException(My.Resources.ErrMsgException, PrDATA_OP_MODE.ToString)
            End Select

            Return True

        Catch ex As Exception
            EM.ErrorSyori(ex, False, conblnNonMsg)
            Return False
        End Try
    End Function

#End Region

#Region "���̓`�F�b�N"
    Public Function FunCheckInput() As Boolean

        Try
            IsValidated = True

            Return IsValidated
        Catch ex As Exception
            EM.ErrorSyori(ex, False, conblnNonMsg)
            Return False
        End Try
    End Function

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
            .AllowSorting = C1.Win.C1FlexGrid.AllowSortingEnum.SingleColumn
            '.AllowMerging = C1.Win.C1FlexGrid.AllowMergingEnum.RestrictRows
            .AllowFiltering = True

            .ShowCellLabels = True
            .SelectionMode = C1.Win.C1FlexGrid.SelectionModeEnum.Row
            .FocusRect = C1.Win.C1FlexGrid.FocusRectEnum.None

            .Font = New Font("Meiryo UI", 9, FontStyle.Regular, GraphicsUnit.Point, CType(128, Byte))

            .Styles.Add("DeletedRow")
            .Styles("DeletedRow").BackColor = Color.FromArgb(200, 200, 200)
            .Styles("DeletedRow").ForeColor = Color.FromArgb(74, 74, 74)

            .VisualStyle = C1.Win.C1FlexGrid.VisualStyle.Office2010Silver 'Custom

            '�ȉ���K�p����ɂ�VisualStyle��Custom�ɂ���
            .Styles.Alternate.BackColor = Color.White
            .Styles.Normal.BackColor = Color.Bisque
            .Styles.Focus.BackColor = Color.Cyan
        End With
    End Function


#End Region

    Private Function FunGetNextIdentity() As Integer

        Dim dsList As New System.Data.DataSet
        Try
            Dim intRET As Integer
            Dim sbSQL As New System.Text.StringBuilder

            sbSQL.Remove(0, sbSQL.Length)
            sbSQL.Append($"SELECT MAX(KISYU_ID) FROM {NameOf(MODEL.M105_KISYU)}")
            Using DB As ClsDbUtility = DBOpen()
                dsList = DB.GetDataSet(sbSQL.ToString, conblnNonMsg)
            End Using

            intRET = Val(dsList.Tables(0).Rows(0).Item(0)) + 1

            Return intRET
        Catch ex As Exception
            EM.ErrorSyori(ex, False, conblnNonMsg)
            Return -1
        Finally
            dsList.Dispose()
        End Try
    End Function


    Private Sub btnSRCH_Click(sender As Object, e As EventArgs) Handles btnSRCH.Click
        Call FunSRCH(Me.flxDATA, FunGetListData())
    End Sub


    Private Function FunSRCH(flx As C1.Win.C1FlexGrid.C1FlexGrid, dt As DataTable) As Boolean
        Dim intCURROW As Integer
        Try

            '-----�I���s�L��
            If flx.Rows.Count > 0 Then
                intCURROW = flx.RowSel
            End If

            flx.BeginUpdate()
            flx.DataSource = dt

            'Call FunSetGridCellFormat(flx)

            If flx.Rows.Count > 0 Then
                '-----�I���s�ݒ�
                Try
                    flx.RowSel = intCURROW
                Catch dgvEx As Exception
                End Try
                'lblRecordCount.Text = String.Format(My.Resources.infoToolTipMsgFoundData, flx.Rows.Count - flx.Rows.Fixed.ToString)
            Else
                'lblRecordCount.Text = My.Resources.infoSearchResultNotFound
            End If

            Return True

        Catch ex As Exception
            EM.ErrorSyori(ex, False, conblnNonMsg)
            Return False
        Finally
            flx.EndUpdate()
        End Try
    End Function

    Private Function FunGetListData() As DataTable
        Try
            Dim sbSQL As New System.Text.StringBuilder
            Dim dsList As New DataSet
            Dim sbSQLWHERE As New System.Text.StringBuilder

            sbSQLWHERE.Append(" WHERE  DEL_FLG = 0 ")
            sbSQLWHERE.Append(" AND BUMON_KB ='" & _VWM107.BUMON_KB & "'")
            If Not mtxKISYU_NAME.Text.IsNulOrWS Then sbSQLWHERE.Append(" AND " & $"KISYU_NAME LIKE '%{mtxKISYU_NAME.Text.Trim}%'")

            sbSQL.Append($"SELECT")
            sbSQL.Append($" * ")
            sbSQL.Append($" FROM {NameOf(MODEL.VWM105_KISYU)} ")
            sbSQL.Append(sbSQLWHERE)
            sbSQL.Append($" ORDER BY KISYU_NAME ")
            Using DB As ClsDbUtility = DBOpen()
                dsList = DB.GetDataSet(sbSQL.ToString, conblnNonMsg)
            End Using

            If dsList.Tables(0).Rows.Count > pub_APP_INFO.intSEARCHMAX Then
                If MessageBox.Show(My.Resources.infoSearchCountOver, "", MessageBoxButtons.YesNo, MessageBoxIcon.Information) = Windows.Forms.DialogResult.No Then
                    Return Nothing
                End If
            End If

            Dim _Model As New MODEL.ModelInfo(Of MODEL.VWM105_KISYU)(srcDATA:=dsList.Tables(0))
            Return _Model.Data

        Catch ex As Exception
            EM.ErrorSyori(ex, False, conblnNonMsg)
            Return Nothing
        End Try
    End Function




#End Region



End Class
