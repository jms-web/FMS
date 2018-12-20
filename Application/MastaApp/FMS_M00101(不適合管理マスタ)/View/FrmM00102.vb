Imports JMS_COMMON.ClsPubMethod

''' <summary>
''' �R�[�h�}�X�^�ҏW���
''' </summary>
Public Class FrmM00102

#Region "�ϐ��E�萔"
    Private IsValidated As Boolean
    Private _TV05 As New MODEL.TV05_FUTEKIGO_CODE
    Private _M001 As New MODEL.M001_SETTING
#End Region

#Region "�v���p�e�B"
    ''' <summary>
    ''' �������[�h
    ''' </summary>
    Public Property PrDATA_OP_MODE As Integer

    ''' <summary>
    ''' �V�K�ǉ����R�[�h�̃L�[
    ''' </summary>
    Public Property PrPKeys As (ITEM_NAME As String, ITEM_VALUE As String)

    'Public Property PrDataRow As DataRow

    Public Property PrViewModel As MODEL.TV05_FUTEKIGO_CODE

#End Region

#Region "�R���X�g���N�^"

    ''' <summary>
    ''' �R���X�g���N�^
    ''' </summary>
    ''' <remarks>�R���X�g���N�^</remarks>
    Public Sub New()

        ' ���̌Ăяo���̓f�U�C�i�[�ŕK�v�ł��B
        InitializeComponent()

        Me.Height = 380
        Me.FormBorderStyle = Windows.Forms.FormBorderStyle.FixedDialog
        Me.MaximizeBox = False
        Me.MinimizeBox = False

        cmbJYUN.NullValue = 0
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
            'cmbKOMO_NM.SetDataSource(tblKOMO_NM.ExcludeDeleted, ENM_COMBO_SELECT_VALUE_TYPE._0_Required)

            Using DB As ClsDbUtility = DBOpen()

                Select Case _TV05.SEIHIN_KB
                    Case "1"    '���h
                        Call FunGetCodeDataTable(DB, "���h_�s�K���敪", tblKOMO_NM)
                    Case "2"    'LP
                        Call FunGetCodeDataTable(DB, "LP_�s�K���敪", tblKOMO_NM)
                    Case "3"    '������
                        Call FunGetCodeDataTable(DB, "������_�s�K���敪", tblKOMO_NM)
                End Select
                cmbFUTEKIGO_KB.SetDataSource(tblKOMO_NM.ExcludeDeleted, ENM_COMBO_SELECT_VALUE_TYPE._0_Required)

            End Using

            If PrDATA_OP_MODE = ENM_DATA_OPERATION_MODE._1_ADD Then
                Me.cmbFUTEKIGO_KB.SelectedIndex = 0
                Me.mtxVALUE.Text = ""
                Me.mtxDISP.Text = ""
                'Me.cmbJYUN.SelectedIndex = 0
            End If

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

#Region "FUNCTION�{�^���֘A"

#Region "FUNCTION�{�^��CLICK�C�x���g"

    Private Sub CmdFunc_Click(ByVal sender As Object, ByVal e As EventArgs) Handles cmdFunc9.Click, cmdFunc8.Click, cmdFunc7.Click, cmdFunc6.Click, cmdFunc5.Click, cmdFunc4.Click, cmdFunc3.Click, cmdFunc2.Click, cmdFunc12.Click, cmdFunc11.Click, cmdFunc10.Click, cmdFunc1.Click
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
                Case 1  '�ǉ��ύX
                    If FunSAVE() Then
                        '�v���p�e�B�ɑΏۃ��R�[�h�̃L�[��ݒ�
                        'Me.PrPKeys = (cmbKOMO_NM.Text.Trim, mtxVALUE.Text.Trim)

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

            Call FunInitFuncButtonEnabled()
        End Try
    End Sub

#End Region

#Region "�X�V"

    Private Function FunSAVE() As Boolean
        Dim sbSQL As New System.Text.StringBuilder
        Dim strRET As String
        Dim sqlEx As New Exception
        Dim strSysDate As String
        Dim strWork As String
        Try

            '���̓`�F�b�N
            If FunCheckInput() = False Then Return False

            Using DB As ClsDbUtility = DBOpen()
                Dim blnErr As Boolean
                Try
                    DB.BeginTransaction()

                    strSysDate = DB.GetSysDateString()

                    Dim ModelInfo As New MODEL.ModelInfo(Of MODEL.M001_SETTING)(_OnlyAutoGenerateField:=True)

                    _M001.ADD_YMDHNS = strSysDate
                    _M001.ADD_SYAIN_ID = pub_SYAIN_INFO.SYAIN_ID

                    _M001.UPD_SYAIN_ID = pub_SYAIN_INFO.SYAIN_ID
                    _M001.DEF_FLG = "0"

                    If Not _TV05.ADD_YMDHNS.IsNulOrWS Then _M001.ADD_YMDHNS = CType(_TV05.ADD_YMDHNS, DateTime).ToString("yyyyMMddHHmmss")
                    If Not _TV05.UPD_YMDHNS.IsNulOrWS Then _M001.UPD_YMDHNS = CType(_TV05.UPD_YMDHNS, DateTime).ToString("yyyyMMddHHmmss")
                    If Not _TV05.DEL_YMDHNS.IsNulOrWS Then _M001.DEL_YMDHNS = CType(_TV05.DEL_YMDHNS, DateTime).ToString("yyyyMMddHHmmss")

                    '-----UPDATE(�\����)
                    If PrViewModel.DISP_ORDER <> _M001.DISP_ORDER Then
                        If FunUpdateDispOrder(DB, PrViewModel.DISP_ORDER, _M001.DISP_ORDER) = False Then
                            blnErr = True
                            Return False
                        End If
                    End If

                    '-----MERGE
                    sbSQL.Remove(0, sbSQL.Length)
                    sbSQL.Append($"MERGE INTO {ModelInfo.Name} AS TARGET")
                    sbSQL.Append($" USING (SELECT")
                    sbSQL.Append($" '{pub_FUTEKIGO_KB_HENKAN(_TV05.SEIHIN_KB.Trim, _TV05.FUTEKIGO_KB.Trim)}' AS {NameOf(_M001.ITEM_NAME)}")
                    sbSQL.Append($",'{_TV05.FUTEKIGO_S_KB}' AS {NameOf(_M001.ITEM_VALUE)}")
                    sbSQL.Append($",'���F�֘A' AS {NameOf(_M001.ITEM_GROUP)}")
                    sbSQL.Append($",'{_TV05.FUTEKIGO_S_KB_NAME.Trim}' AS {NameOf(_M001.ITEM_DISP)}")
                    sbSQL.Append($",'{_M001.DEF_FLG}' AS {NameOf(_M001.DEF_FLG)}")
                    sbSQL.Append($",{_TV05.DISP_ORDER} AS {NameOf(_M001.DISP_ORDER)}")
                    sbSQL.Append($",' ' AS {NameOf(_M001.BIKOU)}")
                    sbSQL.Append($",'{_M001.ADD_YMDHNS}' AS {NameOf(_M001.ADD_YMDHNS)}")
                    sbSQL.Append($",{_M001.ADD_SYAIN_ID} AS {NameOf(_M001.ADD_SYAIN_ID)}")
                    sbSQL.Append($",'{_M001.UPD_YMDHNS}' AS {NameOf(_M001.UPD_YMDHNS)}")
                    sbSQL.Append($",{_TV05.UPD_SYAIN_ID} AS {NameOf(_M001.UPD_SYAIN_ID)}")
                    sbSQL.Append($",'{_M001.DEL_YMDHNS}' AS {NameOf(_M001.DEL_YMDHNS)}")
                    sbSQL.Append($",{_TV05.DEL_SYAIN_ID} AS {NameOf(_M001.DEL_SYAIN_ID)}")

                    sbSQL.Append($" ) AS WK ON (")
                    sbSQL.Append($" TARGET.{NameOf(_M001.ITEM_NAME)} = WK.{NameOf(_M001.ITEM_NAME)}")
                    sbSQL.Append($" AND TARGET.{NameOf(_M001.ITEM_VALUE)} = WK.{NameOf(_M001.ITEM_VALUE)}")
                    sbSQL.Append($" )")

                    '---UPDATE �r������ �X�V�������ύX����Ă��Ȃ��ꍇ�̂�
                    sbSQL.Append($" WHEN MATCHED AND TARGET.{NameOf(_M001.UPD_YMDHNS)} = WK.{NameOf(_M001.UPD_YMDHNS)} THEN ")
                    sbSQL.Append($" UPDATE SET")
                    sbSQL.Append($" TARGET.{NameOf(_M001.ITEM_DISP)}    = WK.{NameOf(_M001.ITEM_DISP)}")
                    sbSQL.Append($",TARGET.{NameOf(_M001.ITEM_GROUP)}   = WK.{NameOf(_M001.ITEM_GROUP)}")
                    sbSQL.Append($",TARGET.{NameOf(_M001.DISP_ORDER)}   = WK.{NameOf(_M001.DISP_ORDER)}")
                    sbSQL.Append($",TARGET.{NameOf(_M001.DEF_FLG)}      = WK.{NameOf(_M001.DEF_FLG)}")
                    sbSQL.Append($",TARGET.{NameOf(_M001.BIKOU)}        = WK.{NameOf(_M001.BIKOU)}")
                    sbSQL.Append($",TARGET.{NameOf(_M001.UPD_YMDHNS)}   = '{strSysDate}'")
                    sbSQL.Append($",TARGET.{NameOf(_M001.UPD_SYAIN_ID)} = WK.{NameOf(_M001.UPD_SYAIN_ID)}")

                    '---INSERT
                    sbSQL.Append($" WHEN NOT MATCHED THEN ")
                    sbSQL.Append($" INSERT(")
                    ModelInfo.Properties.Take(1).ForEach(Sub(p) sbSQL.Append($" {p.Name}"))
                    ModelInfo.Properties.Skip(1).ForEach(Sub(p) sbSQL.Append($",{p.Name}"))
                    sbSQL.Append($" ) VALUES(")
                    ModelInfo.Properties.Take(1).ForEach(Sub(p) sbSQL.Append($" WK.{p.Name}"))
                    ModelInfo.Properties.Skip(1).ForEach(Sub(p) sbSQL.Append($",WK.{p.Name}"))
                    sbSQL.Append(" )")
                    sbSQL.Append("OUTPUT $action As RESULT;")

                    strRET = DB.ExecuteScalar(sbSQL.ToString, conblnNonMsg, sqlEx)
                    Select Case strRET
                        Case "INSERT"

                        Case "UPDATE"

                        Case Else
                            If sqlEx.Source IsNot Nothing Then
                                '-----�G���[���O�o��
                                Dim strErrMsg As String = $"{My.Resources.ErrLogSqlExecutionFailure}{sbSQL.ToString}|{sqlEx.Message}"
                                WL.WriteLogDat(strErrMsg)
                            Else
                                '---�r������
                                Dim strMsg As String = $"���ɑ��̒S���҂ɂ���ĕύX����Ă��邽�ߕۑ��o���܂���B{vbCrLf}�ēx�o�^�������ĉ������B"
                                MessageBox.Show(strMsg, "�����X�V����", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                            End If
                            Return False
                    End Select
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
    ''' <returns></returns>
    ''' <remarks></remarks>
    Private Function FunInitFuncButtonEnabled() As Boolean
        Try

            For intCNT = 0 To Me.cmdFunc.Length - 1
                If Me.cmdFunc(intCNT) IsNot Nothing AndAlso Me.cmdFunc(intCNT).Text.Length = 0 OrElse Me.cmdFunc(intCNT).Text.Substring(0, Me.cmdFunc(intCNT).Text.IndexOf("(")).IsNulOrWS = True Then
                    Me.cmdFunc(intCNT).Text = ""
                    Me.cmdFunc(intCNT).Visible = False
                End If
            Next

            Return True
        Catch ex As Exception
            EM.ErrorSyori(ex, False, conblnNonMsg)
            Return False
        End Try
    End Function

#End Region

#End Region

#Region "�R���g���[���C�x���g"


    Private Sub CmbFUTEKIGO_KB_Validated(sender As Object, e As EventArgs) Handles cmbFUTEKIGO_KB.Validated
        Dim dsList As New DataSet
        Dim sbSQL As New System.Text.StringBuilder
        Dim intMaxOrder As Integer

        Try

            'If Not cmbKOMO_NM.Text.IsNullOrWhiteSpace Then

            Using DB As ClsDbUtility = DBOpen()
                sbSQL.Append("SELECT FUTEKIGO_S_KB")
                sbSQL.Append(" FROM " & NameOf(MODEL.TV05_FUTEKIGO_CODE) & "('" & _TV05.SEIHIN_KB & "')")
                sbSQL.Append(" WHERE FUTEKIGO_KB ='" & _TV05.FUTEKIGO_KB & "'")
                sbSQL.Append(" AND DEL_FLG = 0")
                dsList = DB.GetDataSet(sbSQL.ToString, conblnNonMsg)
            End Using

            intMaxOrder = dsList.Tables(0).Rows.Count

            Dim intModeDiff As Integer
            Select Case PrDATA_OP_MODE
                Case ENM_DATA_OPERATION_MODE._1_ADD, ENM_DATA_OPERATION_MODE._2_ADDREF
                    intModeDiff = 1
                Case ENM_DATA_OPERATION_MODE._3_UPDATE
                    intModeDiff = 0
                Case Else
                    Throw New ArgumentException(My.Resources.ErrMsgException, PrDATA_OP_MODE.ToString)
            End Select

            Dim dt As New DataTableEx("System.Int32")
            For i As Integer = 1 To intMaxOrder + intModeDiff
                Dim Trow As DataRow = dt.NewRow()
                Trow("DISP") = i
                Trow("VALUE") = i
                Trow("DEL_FLG") = False
                dt.Rows.Add(Trow)
            Next i
            dt.AcceptChanges()

            Call cmbJYUN.SetDataSource(dt, ENM_COMBO_SELECT_VALUE_TYPE._2_Option)

            Select Case PrDATA_OP_MODE
                Case ENM_DATA_OPERATION_MODE._1_ADD, ENM_DATA_OPERATION_MODE._2_ADDREF
                    cmbJYUN.SelectedValue = intMaxOrder + intModeDiff
                Case ENM_DATA_OPERATION_MODE._3_UPDATE
                    cmbJYUN.SelectedValue = PrViewModel.DISP_ORDER
                Case Else
                    Throw New ArgumentException(My.Resources.ErrMsgException, PrDATA_OP_MODE.ToString)
            End Select
            'End If

        Catch ex As Exception
            EM.ErrorSyori(ex, False, conblnNonMsg)
        Finally
            dsList.Dispose()
        End Try
    End Sub

#End Region

#Region "���[�J���֐�"

#Region "�o�C���f�B���O"

    Private Function FunSetBinding() As Boolean

        '���i�敪
        mtxSEIHIN_KB_NAME.DataBindings.Add(New Binding(NameOf(mtxSEIHIN_KB_NAME.Text), _TV05, NameOf(_TV05.SEIHIN_KB_NAME), False, DataSourceUpdateMode.OnPropertyChanged, ""))

        '�s�K���敪
        cmbFUTEKIGO_KB.DataBindings.Add(New Binding(NameOf(cmbFUTEKIGO_KB.SelectedValue), _TV05, NameOf(_TV05.FUTEKIGO_KB), False, DataSourceUpdateMode.OnPropertyChanged, 0))
        '�s�K���ڍ׋敪�l
        mtxVALUE.DataBindings.Add(New Binding(NameOf(mtxVALUE.Text), _TV05, NameOf(_TV05.FUTEKIGO_S_KB), False, DataSourceUpdateMode.OnPropertyChanged, ""))
        '�s�K���ڍ׋敪��
        mtxDISP.DataBindings.Add(New Binding(NameOf(mtxDISP.Text), _TV05, NameOf(_TV05.FUTEKIGO_S_KB_NAME), False, DataSourceUpdateMode.OnPropertyChanged, ""))
        '�\����
        cmbJYUN.DataBindings.Add(New Binding(NameOf(cmbJYUN.SelectedValue), _TV05, NameOf(_TV05.DISP_ORDER), False, DataSourceUpdateMode.OnPropertyChanged, 0))

    End Function

#End Region

#Region "�������[�h�ʉ�ʏ�����"
    Private Function FunInitializeControls() As Boolean
        Try
            Select Case PrDATA_OP_MODE
                Case ENM_DATA_OPERATION_MODE._1_ADD
                    lblTytle.Text &= "�i�ǉ��j"
                    cmdFunc1.Text = "�ǉ�(F1)"

                    _TV05.Properties.ForEach(Sub(p) _TV05(p.Name) = PrViewModel(p.Name))

                    'cmbKOMO_NM.ReadOnly = False
                    mtxVALUE.ReadOnly = False
                    mtxDISP.ReadOnly = False

                    mtxVALUE.Text = ""
                    mtxDISP.Text = ""

                    lbllblEDIT_YMDHNS.Visible = False
                    lblEDIT_YMDHNS.Visible = False
                    lbllblEDIT_SYAIN_ID.Visible = False
                    lblEDIT_SYAIN_ID.Visible = False

                Case ENM_DATA_OPERATION_MODE._2_ADDREF

                    lblTytle.Text &= "�i�ގ��ǉ��j"
                    cmdFunc1.Text = "�ǉ�(F1)"

                    'cmbKOMO_NM.ReadOnly = False
                    mtxVALUE.ReadOnly = False
                    mtxDISP.ReadOnly = False

                    '�ꗗ�I���s�̃f�[�^�����f���ɓǍ�
                    _TV05.Properties.ForEach(Sub(p) _TV05(p.Name) = PrViewModel(p.Name))

                    'Call CmbKOMO_NM_Validated(cmbKOMO_NM, Nothing)
                    lbllblEDIT_YMDHNS.Visible = False
                    lblEDIT_YMDHNS.Visible = False
                    lbllblEDIT_SYAIN_ID.Visible = False
                    lblEDIT_SYAIN_ID.Visible = False

                Case ENM_DATA_OPERATION_MODE._3_UPDATE
                    lblTytle.Text &= "�i�ύX�j"
                    cmdFunc1.Text = "�ύX(F1)"

                    'cmbKOMO_NM.ReadOnly = True
                    mtxVALUE.Enabled = False
                    mtxDISP.ReadOnly = False

                    '�ꗗ�I���s�̃f�[�^�����f���ɓǍ�
                    _TV05.Properties.ForEach(Sub(p) _TV05(p.Name) = PrViewModel(p.Name))
                    'Call CmbKOMO_NM_Validated(cmbKOMO_NM, Nothing)
                    Me.cmbFUTEKIGO_KB.Enabled = False


                    lbllblEDIT_YMDHNS.Visible = True
                    lblEDIT_YMDHNS.Visible = True
                    lbllblEDIT_SYAIN_ID.Visible = True
                    lblEDIT_SYAIN_ID.Visible = True
                    '�X�V����
                    If PrViewModel.UPD_YMDHNS.Trim <> "" Then
                        lblEDIT_YMDHNS.Text = DateTime.ParseExact(PrViewModel.UPD_YMDHNS.Replace("/", "").Replace(":", "").Replace(" ", ""), "yyyyMMddHHmmss", Nothing).ToString("yyyy/MM/dd HH:mm:ss")
                    End If

                    '�X�V�S����CD
                    lblEDIT_SYAIN_ID.Text = PrViewModel.UPD_SYAIN_ID & " " & Fun_GetUSER_NAME(_M001.UPD_SYAIN_ID)

                    Call CmbFUTEKIGO_KB_Validated(Me.cmbFUTEKIGO_KB, Nothing)


                Case Else
                    Throw New ArgumentException(My.Resources.ErrMsgException, PrDATA_OP_MODE.ToString)
            End Select
            _TV05.FUTEKIGO_S_KB_NAME = _TV05.FUTEKIGO_S_KB_NAME.Trim

            Return True

        Catch ex As Exception
            EM.ErrorSyori(ex, False, conblnNonMsg)
            Return False
        End Try
    End Function

#End Region

#Region "���̓`�F�b�N"

    Private Function FunCheckInput() As Boolean
        Try
            '�t���O������
            IsValidated = True

            Return IsValidated
        Catch ex As Exception
            EM.ErrorSyori(ex, False, conblnNonMsg)
            Return False
        End Try
    End Function

#End Region

#Region "�\�����X�V"
    Private Function FunUpdateDispOrder(ByRef DB As ClsDbUtility, ByVal intBeforeValue As Integer, ByVal intAfterValue As Integer) As Boolean
        Dim sbSQL As New System.Text.StringBuilder
        Dim sqlEx As New Exception

        Try

            '���ꍀ�ږ����ɓ����\���������݂���ꍇ�AintTergetJyun�ȍ~�̕\������S�čX�V����
            If intBeforeValue < intAfterValue Then
                sbSQL.Append($"UPDATE {NameOf(MODEL.M001_SETTING)} SET")
                sbSQL.Append($" DISP_ORDER = DISP_ORDER-1 ")
                sbSQL.Append($"WHERE")
                sbSQL.Append($" ITEM_NAME ='{_M001.ITEM_NAME}' ")
                sbSQL.Append($" AND DISP_ORDER >{intBeforeValue} ")
                sbSQL.Append($" AND DISP_ORDER <={intAfterValue} ")
            Else
                '���̕\������菬���������ꍇ�A���̍��ڂ�1���ɂ��炷
                sbSQL.Append($"UPDATE {NameOf(MODEL.M001_SETTING)} SET")
                sbSQL.Append($" DISP_ORDER = DISP_ORDER+1 ")
                sbSQL.Append($"WHERE")
                sbSQL.Append($" ITEM_NAME ='{_M001.ITEM_NAME}' ")
                sbSQL.Append($" AND DISP_ORDER >={intAfterValue} ")
                sbSQL.Append($" AND DISP_ORDER <{intBeforeValue} ")
            End If

            DB.ExecuteNonQuery(sbSQL.ToString, conblnNonMsg, sqlEx)
            If sqlEx.Source IsNot Nothing Then
                '�G���[���O
                Dim strErrMsg As String = My.Resources.ErrLogSqlExecutionFailure & sbSQL.ToString & "|" & sqlEx.Message
                WL.WriteLogDat(strErrMsg)
                Return False
            End If

            '�ύX�Ώۂ̍X�V
            sbSQL.Remove(0, sbSQL.Length)
            sbSQL.Append($"UPDATE {NameOf(MODEL.M001_SETTING)} SET")
            sbSQL.Append($" DISP_ORDER ='{intAfterValue}' ")
            sbSQL.Append($"WHERE")
            sbSQL.Append($" ITEM_NAME ='{_M001.ITEM_NAME}' ")
            sbSQL.Append($" AND ITEM_VALUE ='{_M001.ITEM_VALUE}' ")
            sbSQL.Append($" AND DISP_ORDER ={intBeforeValue}")

            DB.ExecuteNonQuery(sbSQL.ToString, conblnNonMsg, sqlEx)
            If sqlEx.Source IsNot Nothing Then
                '�G���[���O
                Dim strErrMsg As String = My.Resources.ErrLogSqlExecutionFailure & sbSQL.ToString & "|" & sqlEx.Message
                WL.WriteLogDat(strErrMsg)
                Return False
            End If

            Return True
        Catch ex As Exception
            Throw
            Return False
        End Try
    End Function


#End Region

#End Region


End Class
