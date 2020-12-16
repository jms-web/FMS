Imports JMS_COMMON.ClsPubMethod
Imports MODEL

''' <summary>
''' ���߂����
''' </summary>
Public Class FrmG0016

#Region "�ϐ��E�萔"

#End Region

#Region "�v���p�e�B"

    Public Property PrSYONIN_HOKOKUSYO_ID As Integer

    Public Property PrCurrentStage As Integer

    Public Property PrHOKOKU_NO As String

    Public Property PrBUHIN_BANGO As String

    Public Property PrKISYU_NAME As String

    Public Property PrKISO_YMD As String

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
        cmbMODOSI_SAKI.NullValue = 0
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
            Me.Height = 300
            Me.Width = 800
            Me.MinimumSize = New Size(800, 300)
            Me.Top = Me.Owner.Top + (Me.Owner.Height - Me.Height) / 2
            Me.Left = Me.Owner.Left + (Me.Owner.Width - Me.Width) / 2

            '-----�_�C�A���O�E�B���h�E�ݒ�
            Me.FormBorderStyle = Windows.Forms.FormBorderStyle.FixedDialog
            Me.ControlBox = False

            '-----�e�R���g���[���̃f�[�^�\�[�X��ݒ�

            cmbMODOSI_SAKI.SetDataSource(FunGetMODISI_SAKI(PrSYONIN_HOKOKUSYO_ID, PrHOKOKU_NO, PrCurrentStage), ENM_COMBO_SELECT_VALUE_TYPE._0_Required)
            '�o�C���f�B���O
            Call FunSetBinding()
            _D004_SYONIN_J_KANRI.RIYU = ""
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
                Case 1  '
                    If FunSAVE() Then

                        Me.DialogResult = Windows.Forms.DialogResult.OK
                        Me.Close()
                    End If

                Case 12 '�߂�
                    Me.DialogResult = Windows.Forms.DialogResult.Cancel
                    Me.Close()
            End Select
        Catch exDispose As ObjectDisposedException
            System.Console.WriteLine(exDispose.Message)
        Catch ex As Exception
            EM.ErrorSyori(ex, False, conblnNonMsg)
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
        Dim dsList As New DataSet
        Dim sbSQL As New System.Text.StringBuilder

        Try
            '-----���̓`�F�b�N
            If FunCheckInput() = False Then
                Return False
            End If

            'SPEC: 20-5.�B.���R�[�h�X�V
            Using DB As ClsDbUtility = DBOpen()
                Dim intRET As Integer
                Dim sqlEx As New Exception
                Dim blnErr As Boolean
                Dim strSysDate As String = DB.GetSysDateString

                Try
                    '-----�g�����U�N�V����
                    DB.BeginTransaction()

                    '-----UPDATE
                    sbSQL.Append($"UPDATE {NameOf(MODEL.D004_SYONIN_J_KANRI)} SET")
                    sbSQL.Append($" {NameOf(_D004_SYONIN_J_KANRI.SYONIN_YMDHNS)}=' '")
                    sbSQL.Append($" ,{NameOf(_D004_SYONIN_J_KANRI.SYONIN_HANTEI_KB)}='{ENM_SYONIN_HANTEI_KB._0_�����F.Value}'") '
                    sbSQL.Append($" ,{NameOf(_D004_SYONIN_J_KANRI.SASIMODOSI_FG)}='1'")
                    sbSQL.Append($" ,{NameOf(_D004_SYONIN_J_KANRI.RIYU)}='{_D004_SYONIN_J_KANRI.RIYU}'")
                    sbSQL.Append($" ,{NameOf(_D004_SYONIN_J_KANRI.MAIL_SEND_FG)}='0'")
                    sbSQL.Append($" ,{NameOf(_D004_SYONIN_J_KANRI.SYAIN_ID)}={mtxTANTO_ID.Text}")
                    sbSQL.Append($" ,{NameOf(_D004_SYONIN_J_KANRI.UPD_SYAIN_ID)}={pub_SYAIN_INFO.SYAIN_ID}") '
                    sbSQL.Append($" ,{NameOf(_D004_SYONIN_J_KANRI.UPD_YMDHNS)}='{strSysDate}'")
                    sbSQL.Append($" WHERE {NameOf(_D004_SYONIN_J_KANRI.SYONIN_HOKOKUSYO_ID)}={PrSYONIN_HOKOKUSYO_ID}")
                    sbSQL.Append($" AND {NameOf(_D004_SYONIN_J_KANRI.HOKOKU_NO)}='{PrHOKOKU_NO}'")
                    sbSQL.Append($" AND {NameOf(_D004_SYONIN_J_KANRI.SYONIN_JUN)}={cmbMODOSI_SAKI.SelectedValue}")

                    intRET = DB.ExecuteNonQuery(sbSQL.ToString, conblnNonMsg, sqlEx)
                    If intRET <> 1 Then
                        Dim strErrMsg As String = My.Resources.ErrLogSqlExecutionFailure & sbSQL.ToString & "|" & sqlEx.Message
                        WL.WriteLogDat(strErrMsg)
                        blnErr = True
                        Return False
                    End If

                    '-----�����߂��ꂽ�X�e�[�W�ȍ~�̏��F�ςݎ��т��폜
                    sbSQL.Remove(0, sbSQL.Length)
                    sbSQL.Append($"DELETE FROM {NameOf(MODEL.D004_SYONIN_J_KANRI)}")
                    sbSQL.Append($" WHERE {NameOf(_D004_SYONIN_J_KANRI.SYONIN_HOKOKUSYO_ID)}={PrSYONIN_HOKOKUSYO_ID}")
                    sbSQL.Append($" AND RTRIM({NameOf(_D004_SYONIN_J_KANRI.HOKOKU_NO)})='{PrHOKOKU_NO}'")
                    sbSQL.Append($" AND {NameOf(_D004_SYONIN_J_KANRI.SYONIN_JUN)}>{cmbMODOSI_SAKI.SelectedValue};")

                    intRET = DB.ExecuteNonQuery(sbSQL.ToString, conblnNonMsg, sqlEx)
                    If sqlEx.Source IsNot Nothing Then

                        Dim strErrMsg As String = My.Resources.ErrLogSqlExecutionFailure & sbSQL.ToString & "|" & sqlEx.Message
                        WL.WriteLogDat(strErrMsg)
                        blnErr = True
                        Return False
                    End If

                    '-----�f�[�^���f���X�V
                    _R001_HOKOKU_SOUSA.SYONIN_HOKOKUSYO_ID = PrSYONIN_HOKOKUSYO_ID
                    _R001_HOKOKU_SOUSA.HOKOKU_NO = PrHOKOKU_NO
                    _R001_HOKOKU_SOUSA.SYONIN_JUN = PrCurrentStage
                    _R001_HOKOKU_SOUSA.SYAIN_ID = pub_SYAIN_INFO.SYAIN_ID
                    _R001_HOKOKU_SOUSA.SOUSA_KB = ENM_SOUSA_KB._3_���F����
                    _R001_HOKOKU_SOUSA.SYONIN_HANTEI_KB = ""
                    _R001_HOKOKU_SOUSA.RIYU = mtxMODOSI_RIYU.Text
                    _R001_HOKOKU_SOUSA.ADD_YMDHNS = strSysDate 'Now.ToString("yyyyMMddHHmmss")
                    '-----INSERT R001
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
                    sbSQL.Append("  " & (_R001_HOKOKU_SOUSA.SYONIN_HOKOKUSYO_ID))
                    sbSQL.Append(" ,'" & (_R001_HOKOKU_SOUSA.HOKOKU_NO) & "'")
                    sbSQL.Append(" ,dbo.GetSysDateString()")
                    sbSQL.Append(" ," & (_R001_HOKOKU_SOUSA.SYONIN_JUN))
                    sbSQL.Append(" ,'" & (_R001_HOKOKU_SOUSA.SOUSA_KB) & "'")
                    sbSQL.Append(" ," & (_R001_HOKOKU_SOUSA.SYAIN_ID))
                    sbSQL.Append(" ,'" & (_R001_HOKOKU_SOUSA.SYONIN_HANTEI_KB) & "'")
                    sbSQL.Append(" ,'" & (_R001_HOKOKU_SOUSA.RIYU) & "'")
                    sbSQL.Append(")")

                    '-----SQL���s
                    intRET = DB.ExecuteNonQuery(sbSQL.ToString, conblnNonMsg, sqlEx)
                    If intRET <> 1 Then
                        '-----�G���[���O�o��
                        Dim strErrMsg As String = My.Resources.ErrLogSqlExecutionFailure & sbSQL.ToString & "|" & sqlEx.Message
                        WL.WriteLogDat(strErrMsg)
                        blnErr = True
                        Return False
                    End If

                    '�����߂�������
                    Select Case PrSYONIN_HOKOKUSYO_ID
                        Case Context.ENM_SYONIN_HOKOKUSYO_ID._1_NCR
                            If FunSAVE_R003(DB, _R001_HOKOKU_SOUSA.ADD_YMDHNS) Then
                            Else
                                blnErr = True
                                Return False
                            End If
                        Case Context.ENM_SYONIN_HOKOKUSYO_ID._2_CAR

                            If FunSAVE_R004(DB, _R001_HOKOKU_SOUSA.ADD_YMDHNS) Then
                            Else
                                blnErr = True
                                Return False
                            End If
                        Case Context.ENM_SYONIN_HOKOKUSYO_ID._3_CTS

                            If FunSAVE_R005(DB, _R001_HOKOKU_SOUSA.ADD_YMDHNS) Then
                            Else
                                blnErr = True
                                Return False
                            End If
                            If FunSAVE_R006(DB, _R001_HOKOKU_SOUSA.ADD_YMDHNS) Then
                            Else
                                blnErr = True
                                Return False
                            End If
                        Case Else
                            Throw New ArgumentException()
                    End Select

                    '�ʒm���[�����M
                    If blnErr = False Then Call FunSendRequestMail()
                Finally
                    '-----�g�����U�N�V����
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

    Private Function FunSAVE_R003(ByRef DB As ClsDbUtility, ByVal strYMDHNS As String) As Boolean
        Dim sbSQL As New System.Text.StringBuilder
        Dim intRET As Integer
        Dim sqlEx As New Exception

        '-----MERGE
        sbSQL.Append(" INSERT INTO " & NameOf(MODEL.R003_NCR_SASIMODOSI) & "(")
        sbSQL.Append(" " & NameOf(_R003_NCR_SASIMODOSI.SASIMODOSI_YMDHNS))
        sbSQL.Append(" ," & NameOf(_R003_NCR_SASIMODOSI.HOKOKU_NO))
        sbSQL.Append(" ," & NameOf(_R003_NCR_SASIMODOSI.BUMON_KB))
        sbSQL.Append(" ," & NameOf(_R003_NCR_SASIMODOSI.CLOSE_FG))
        sbSQL.Append(" ," & NameOf(_R003_NCR_SASIMODOSI.KISYU_ID))
        sbSQL.Append(" ," & NameOf(_R003_NCR_SASIMODOSI.SYANAI_CD))
        sbSQL.Append(" ," & NameOf(_R003_NCR_SASIMODOSI.BUHIN_BANGO))
        sbSQL.Append(" ," & NameOf(_R003_NCR_SASIMODOSI.BUHIN_NAME))
        sbSQL.Append(" ," & NameOf(_R003_NCR_SASIMODOSI.GOKI))
        sbSQL.Append(" ," & NameOf(_R003_NCR_SASIMODOSI.SURYO))
        sbSQL.Append(" ," & NameOf(_R003_NCR_SASIMODOSI.SAIHATU))
        sbSQL.Append(" ," & NameOf(_R003_NCR_SASIMODOSI.FUTEKIGO_JYOTAI_KB))
        sbSQL.Append(" ," & NameOf(_R003_NCR_SASIMODOSI.FUTEKIGO_NAIYO))
        sbSQL.Append(" ," & NameOf(_R003_NCR_SASIMODOSI.FUTEKIGO_KB))
        sbSQL.Append(" ," & NameOf(_R003_NCR_SASIMODOSI.FUTEKIGO_S_KB))
        sbSQL.Append(" ," & NameOf(_R003_NCR_SASIMODOSI.ZUMEN_KIKAKU))
        sbSQL.Append(" ," & NameOf(_R003_NCR_SASIMODOSI.YOKYU_NAIYO))
        sbSQL.Append(" ," & NameOf(_R003_NCR_SASIMODOSI.KANSATU_KEKKA))
        sbSQL.Append(" ," & NameOf(_R003_NCR_SASIMODOSI.ZESEI_SYOCHI_YOHI_KB))
        sbSQL.Append(" ," & NameOf(_R003_NCR_SASIMODOSI.ZESEI_NASI_RIYU))
        sbSQL.Append(" ," & NameOf(_R003_NCR_SASIMODOSI.JIZEN_SINSA_HANTEI_KB))
        sbSQL.Append(" ," & NameOf(_R003_NCR_SASIMODOSI.JIZEN_SINSA_SYAIN_ID))
        sbSQL.Append(" ," & NameOf(_R003_NCR_SASIMODOSI.JIZEN_SINSA_YMD))
        sbSQL.Append(" ," & NameOf(_R003_NCR_SASIMODOSI.SAISIN_KAKUNIN_SYAIN_ID))
        sbSQL.Append(" ," & NameOf(_R003_NCR_SASIMODOSI.SAISIN_KAKUNIN_YMD))
        sbSQL.Append(" ," & NameOf(_R003_NCR_SASIMODOSI.SAISIN_IINKAI_HANTEI_KB))
        sbSQL.Append(" ," & NameOf(_R003_NCR_SASIMODOSI.SAISIN_GIJYUTU_SYAIN_ID))
        sbSQL.Append(" ," & NameOf(_R003_NCR_SASIMODOSI.SAISIN_GIJYUTU_YMD))
        sbSQL.Append(" ," & NameOf(_R003_NCR_SASIMODOSI.SAISIN_HINSYO_SYAIN_ID))
        sbSQL.Append(" ," & NameOf(_R003_NCR_SASIMODOSI.SAISIN_HINSYO_YMD))
        sbSQL.Append(" ," & NameOf(_R003_NCR_SASIMODOSI.SAISIN_IINKAI_SIRYO_NO))
        sbSQL.Append(" ," & NameOf(_R003_NCR_SASIMODOSI.ITAG_NO))
        sbSQL.Append(" ," & NameOf(_R003_NCR_SASIMODOSI.KOKYAKU_SAISIN_TANTO_ID))
        sbSQL.Append(" ," & NameOf(_R003_NCR_SASIMODOSI.KOKYAKU_SAISIN_YMD))
        sbSQL.Append(" ," & NameOf(_R003_NCR_SASIMODOSI.KOKYAKU_HANTEI_SIJI_KB))
        sbSQL.Append(" ," & NameOf(_R003_NCR_SASIMODOSI.KOKYAKU_HANTEI_SIJI_YMD))
        sbSQL.Append(" ," & NameOf(_R003_NCR_SASIMODOSI.KOKYAKU_SAISYU_HANTEI_KB))
        sbSQL.Append(" ," & NameOf(_R003_NCR_SASIMODOSI.KOKYAKU_SAISYU_HANTEI_YMD))
        sbSQL.Append(" ," & NameOf(_R003_NCR_SASIMODOSI.SAIKAKO_SIJI_FG))
        sbSQL.Append(" ," & NameOf(_R003_NCR_SASIMODOSI.HAIKYAKU_YMD))
        sbSQL.Append(" ," & NameOf(_R003_NCR_SASIMODOSI.HAIKYAKU_KB))
        sbSQL.Append(" ," & NameOf(_R003_NCR_SASIMODOSI.HAIKYAKU_HOUHOU))
        sbSQL.Append(" ," & NameOf(_R003_NCR_SASIMODOSI.HAIKYAKU_TANTO_ID))
        sbSQL.Append(" ," & NameOf(_R003_NCR_SASIMODOSI.SAIKAKO_SIJI_NO))
        sbSQL.Append(" ," & NameOf(_R003_NCR_SASIMODOSI.SAIKAKO_SAGYO_KAN_YMD))
        sbSQL.Append(" ," & NameOf(_R003_NCR_SASIMODOSI.SAIKAKO_KENSA_YMD))
        sbSQL.Append(" ," & NameOf(_R003_NCR_SASIMODOSI.KENSA_KEKKA_KB))
        sbSQL.Append(" ," & NameOf(_R003_NCR_SASIMODOSI.SEIGI_TANTO_ID))
        sbSQL.Append(" ," & NameOf(_R003_NCR_SASIMODOSI.SEIZO_TANTO_ID))
        sbSQL.Append(" ," & NameOf(_R003_NCR_SASIMODOSI.KENSA_TANTO_ID))
        sbSQL.Append(" ," & NameOf(_R003_NCR_SASIMODOSI.HENKYAKU_YMD))
        sbSQL.Append(" ," & NameOf(_R003_NCR_SASIMODOSI.HENKYAKU_SAKI))
        sbSQL.Append(" ," & NameOf(_R003_NCR_SASIMODOSI.HENKYAKU_TANTO_ID))
        sbSQL.Append(" ," & NameOf(_R003_NCR_SASIMODOSI.HENKYAKU_BIKO))
        sbSQL.Append(" ," & NameOf(_R003_NCR_SASIMODOSI.TENYO_KISYU_ID))
        sbSQL.Append(" ," & NameOf(_R003_NCR_SASIMODOSI.TENYO_BUHIN_BANGO))
        sbSQL.Append(" ," & NameOf(_R003_NCR_SASIMODOSI.TENYO_GOKI))
        sbSQL.Append(" ," & NameOf(_R003_NCR_SASIMODOSI.TENYO_LOT))
        sbSQL.Append(" ," & NameOf(_R003_NCR_SASIMODOSI.TENYO_YMD))
        sbSQL.Append(" ," & NameOf(_R003_NCR_SASIMODOSI.SYOCHI_KEKKA_A))
        sbSQL.Append(" ," & NameOf(_R003_NCR_SASIMODOSI.SYOCHI_KEKKA_B))
        sbSQL.Append(" ," & NameOf(_R003_NCR_SASIMODOSI.SYOCHI_KEKKA_C))
        sbSQL.Append(" ," & NameOf(_R003_NCR_SASIMODOSI.SYOCHI_D_UMU_KB))
        sbSQL.Append(" ," & NameOf(_R003_NCR_SASIMODOSI.SYOCHI_D_YOHI_KB))
        sbSQL.Append(" ," & NameOf(_R003_NCR_SASIMODOSI.SYOCHI_D_SYOCHI_KIROKU))
        sbSQL.Append(" ," & NameOf(_R003_NCR_SASIMODOSI.SYOCHI_E_UMU_KB))
        sbSQL.Append(" ," & NameOf(_R003_NCR_SASIMODOSI.SYOCHI_E_YOHI_KB))
        sbSQL.Append(" ," & NameOf(_R003_NCR_SASIMODOSI.SYOCHI_E_SYOCHI_KIROKU))
        sbSQL.Append(" ," & NameOf(_R003_NCR_SASIMODOSI.FILE_PATH))
        sbSQL.Append(" ," & NameOf(_R003_NCR_SASIMODOSI.HASSEI_YMD))
        sbSQL.Append(" ," & NameOf(_R003_NCR_SASIMODOSI.G_FILE_PATH1))
        sbSQL.Append(" ," & NameOf(_R003_NCR_SASIMODOSI.G_FILE_PATH2))
        sbSQL.Append(" ," & NameOf(_R003_NCR_SASIMODOSI.HASSEI_KOTEI_GL_SYAIN_ID))
        sbSQL.Append(" ," & NameOf(_R003_NCR_SASIMODOSI.FCR_KISO_TANTO_ID))
        sbSQL.Append(" ) VALUES(")
        sbSQL.Append(" '" & strYMDHNS & "'")
        sbSQL.Append(" ,'" & _D003_NCR_J.HOKOKU_NO & "'")
        sbSQL.Append(" ,'" & _D003_NCR_J.BUMON_KB & "'")
        sbSQL.Append(" ,'" & _D003_NCR_J._CLOSE_FG & "'")
        sbSQL.Append(" ," & _D003_NCR_J.KISYU_ID & "")
        sbSQL.Append(" ,'" & _D003_NCR_J.SYANAI_CD & "'")
        sbSQL.Append(" ,'" & _D003_NCR_J.BUHIN_BANGO & "'")
        sbSQL.Append(" ,'" & _D003_NCR_J.BUHIN_NAME & "'")
        sbSQL.Append(" ,'" & _D003_NCR_J.GOKI & "'")
        sbSQL.Append(" ," & _D003_NCR_J.SURYO & "")
        sbSQL.Append(" ,'" & _D003_NCR_J._SAIHATU & "'")
        sbSQL.Append(" ,'" & _D003_NCR_J.FUTEKIGO_JYOTAI_KB & "'")
        sbSQL.Append(" ,'" & _D003_NCR_J.FUTEKIGO_NAIYO & "'")
        sbSQL.Append(" ,'" & _D003_NCR_J.FUTEKIGO_KB & "'")
        sbSQL.Append(" ,'" & _D003_NCR_J.FUTEKIGO_S_KB & "'")
        sbSQL.Append(" ,'" & _D003_NCR_J.ZUMEN_KIKAKU & "'")
        sbSQL.Append(" ,'" & _D003_NCR_J.YOKYU_NAIYO & "'")
        sbSQL.Append(" ,'" & _D003_NCR_J.KANSATU_KEKKA & "'")
        sbSQL.Append(" ,'" & _D003_NCR_J._ZESEI_SYOCHI_YOHI_KB & "'")
        sbSQL.Append(" ,'" & _D003_NCR_J.ZESEI_NASI_RIYU & "'")
        sbSQL.Append(" ,'" & _D003_NCR_J.JIZEN_SINSA_HANTEI_KB & "'")
        sbSQL.Append(" ," & _D003_NCR_J.JIZEN_SINSA_SYAIN_ID & "")
        sbSQL.Append(" ,'" & _D003_NCR_J.JIZEN_SINSA_YMD & "'")
        sbSQL.Append(" ," & _D003_NCR_J.SAISIN_KAKUNIN_SYAIN_ID & "")
        sbSQL.Append(" ,'" & _D003_NCR_J.SAISIN_KAKUNIN_YMD & "'")
        sbSQL.Append(" ,'" & _D003_NCR_J.SAISIN_IINKAI_HANTEI_KB & "'")
        sbSQL.Append(" ," & _D003_NCR_J.SAISIN_GIJYUTU_SYAIN_ID & "")
        sbSQL.Append(" ,'" & _D003_NCR_J.SAISIN_GIJYUTU_YMD & "'")
        sbSQL.Append(" ," & _D003_NCR_J.SAISIN_HINSYO_SYAIN_ID & "")
        sbSQL.Append(" ,'" & _D003_NCR_J.SAISIN_HINSYO_YMD & "'")
        sbSQL.Append(" ,'" & _D003_NCR_J.SAISIN_IINKAI_SIRYO_NO & "'")
        sbSQL.Append(" ,'" & _D003_NCR_J.ITAG_NO & "'")
        sbSQL.Append(" ," & _D003_NCR_J.KOKYAKU_SAISIN_TANTO_ID & "")
        sbSQL.Append(" ,'" & _D003_NCR_J.KOKYAKU_SAISIN_YMD & "'")
        sbSQL.Append(" ,'" & _D003_NCR_J.KOKYAKU_HANTEI_SIJI_KB & "'")
        sbSQL.Append(" ,'" & _D003_NCR_J.KOKYAKU_HANTEI_SIJI_YMD & "'")
        sbSQL.Append(" ,'" & _D003_NCR_J.KOKYAKU_SAISYU_HANTEI_KB & "'")
        sbSQL.Append(" ,'" & _D003_NCR_J.KOKYAKU_SAISYU_HANTEI_YMD & "'")
        sbSQL.Append(" ,'" & _D003_NCR_J._SAIKAKO_SIJI_FG & "'")
        sbSQL.Append(" ,'" & _D003_NCR_J.HAIKYAKU_YMD & "'")
        sbSQL.Append(" ,'" & _D003_NCR_J.HAIKYAKU_KB & "'")
        sbSQL.Append(" ,'" & _D003_NCR_J.HAIKYAKU_HOUHOU & "'")
        sbSQL.Append(" ," & _D003_NCR_J.HAIKYAKU_TANTO_ID & "")
        sbSQL.Append(" ,'" & _D003_NCR_J.SAIKAKO_SIJI_NO & "'")
        sbSQL.Append(" ,'" & _D003_NCR_J.SAIKAKO_SAGYO_KAN_YMD & "'")
        sbSQL.Append(" ,'" & _D003_NCR_J.SAIKAKO_KENSA_YMD & "'")
        sbSQL.Append(" ,'" & _D003_NCR_J.KENSA_KEKKA_KB & "'")
        sbSQL.Append(" ," & _D003_NCR_J.SEIGI_TANTO_ID & "")
        sbSQL.Append(" ," & _D003_NCR_J.SEIZO_TANTO_ID & "")
        sbSQL.Append(" ," & _D003_NCR_J.KENSA_TANTO_ID & "")
        sbSQL.Append(" ,'" & _D003_NCR_J.HENKYAKU_YMD & "'")
        sbSQL.Append(" ,'" & _D003_NCR_J.HENKYAKU_SAKI & "'")
        sbSQL.Append(" ," & _D003_NCR_J.HENKYAKU_TANTO_ID & "")
        sbSQL.Append(" ,'" & _D003_NCR_J.HENKYAKU_BIKO & "'")
        sbSQL.Append(" ," & _D003_NCR_J.TENYO_KISYU_ID & "")
        sbSQL.Append(" ,'" & _D003_NCR_J.TENYO_BUHIN_BANGO & "'")
        sbSQL.Append(" ,'" & _D003_NCR_J.TENYO_GOKI & "'")
        sbSQL.Append(" ,'" & _D003_NCR_J.TENYO_LOT & "'")
        sbSQL.Append(" ,'" & _D003_NCR_J.TENYO_YMD & "'")
        sbSQL.Append(" ,'" & _D003_NCR_J._SYOCHI_KEKKA_A & "'")
        sbSQL.Append(" ,'" & _D003_NCR_J._SYOCHI_KEKKA_B & "'")
        sbSQL.Append(" ,'" & _D003_NCR_J._SYOCHI_KEKKA_C & "'")
        sbSQL.Append(" ,'" & _D003_NCR_J._SYOCHI_D_UMU_KB & "'")
        sbSQL.Append(" ,'" & _D003_NCR_J._SYOCHI_D_YOHI_KB & "'")
        sbSQL.Append(" ,'" & _D003_NCR_J.SYOCHI_D_SYOCHI_KIROKU & "'")
        sbSQL.Append(" ,'" & _D003_NCR_J._SYOCHI_E_UMU_KB & "'")
        sbSQL.Append(" ,'" & _D003_NCR_J._SYOCHI_E_YOHI_KB & "'")
        sbSQL.Append(" ,'" & _D003_NCR_J.SYOCHI_E_SYOCHI_KIROKU & "'")
        sbSQL.Append(" ,'" & _D003_NCR_J.FILE_PATH & "'")
        sbSQL.Append(" ,'" & _D003_NCR_J.HASSEI_YMD & "'")
        sbSQL.Append(" ,'" & _D003_NCR_J.G_FILE_PATH1 & "'")
        sbSQL.Append(" ,'" & _D003_NCR_J.G_FILE_PATH2 & "'")
        sbSQL.Append(" ,'" & _D003_NCR_J.HASSEI_KOTEI_GL_SYAIN_ID & "'")
        sbSQL.Append(" ,'" & _D003_NCR_J.FCR_KISO_TANTO_ID & "'")
        sbSQL.Append(" );")
        intRET = DB.ExecuteNonQuery(sbSQL.ToString, conblnNonMsg, sqlEx)
        If intRET <> 1 Then
            '-----�G���[���O�o��
            Dim strErrMsg As String = My.Resources.ErrLogSqlExecutionFailure & sbSQL.ToString & "|" & sqlEx.Message
            WL.WriteLogDat(strErrMsg)
            Return False
        Else
            Return True
        End If
    End Function

    Private Function FunSAVE_R004(ByRef DB As ClsDbUtility, ByVal strYMDHNS As String) As Boolean
        Dim sbSQL As New System.Text.StringBuilder
        Dim intRET As Integer
        Dim sqlEx As New Exception

        '-----MERGE
        sbSQL.Append(" INSERT INTO " & NameOf(MODEL.R004_CAR_SASIMODOSI) & "(")
        sbSQL.Append(" " & NameOf(_R004.SASIMODOSI_YMDHNS))
        sbSQL.Append(" ," & NameOf(_R004.HOKOKU_NO))
        sbSQL.Append(" ," & NameOf(_R004.BUMON_KB))
        sbSQL.Append(" ," & NameOf(_R004.CLOSE_FG))
        sbSQL.Append(" ," & NameOf(_R004.SETUMON_1))
        sbSQL.Append(" ," & NameOf(_R004.SETUMON_2))
        sbSQL.Append(" ," & NameOf(_R004.SETUMON_3))
        sbSQL.Append(" ," & NameOf(_R004.SETUMON_4))
        sbSQL.Append(" ," & NameOf(_R004.SETUMON_5))
        sbSQL.Append(" ," & NameOf(_R004.SETUMON_6))
        sbSQL.Append(" ," & NameOf(_R004.SETUMON_7))
        sbSQL.Append(" ," & NameOf(_R004.SETUMON_8))
        sbSQL.Append(" ," & NameOf(_R004.SETUMON_9))
        sbSQL.Append(" ," & NameOf(_R004.SETUMON_10))
        sbSQL.Append(" ," & NameOf(_R004.SETUMON_11))
        sbSQL.Append(" ," & NameOf(_R004.SETUMON_12))
        sbSQL.Append(" ," & NameOf(_R004.SETUMON_13))
        sbSQL.Append(" ," & NameOf(_R004.SETUMON_14))
        sbSQL.Append(" ," & NameOf(_R004.SETUMON_15))
        sbSQL.Append(" ," & NameOf(_R004.SETUMON_16))
        sbSQL.Append(" ," & NameOf(_R004.SETUMON_17))
        sbSQL.Append(" ," & NameOf(_R004.SETUMON_18))
        sbSQL.Append(" ," & NameOf(_R004.SETUMON_19))
        sbSQL.Append(" ," & NameOf(_R004.SETUMON_20))
        sbSQL.Append(" ," & NameOf(_R004.SETUMON_21))
        sbSQL.Append(" ," & NameOf(_R004.SETUMON_22))
        sbSQL.Append(" ," & NameOf(_R004.SETUMON_23))
        sbSQL.Append(" ," & NameOf(_R004.SETUMON_24))
        sbSQL.Append(" ," & NameOf(_R004.SETUMON_25))
        sbSQL.Append(" ," & NameOf(_R004.KAITO_1))
        sbSQL.Append(" ," & NameOf(_R004.KAITO_2))
        sbSQL.Append(" ," & NameOf(_R004.KAITO_3))
        sbSQL.Append(" ," & NameOf(_R004.KAITO_4))
        sbSQL.Append(" ," & NameOf(_R004.KAITO_5))
        sbSQL.Append(" ," & NameOf(_R004.KAITO_6))
        sbSQL.Append(" ," & NameOf(_R004.KAITO_7))
        sbSQL.Append(" ," & NameOf(_R004.KAITO_8))
        sbSQL.Append(" ," & NameOf(_R004.KAITO_9))
        sbSQL.Append(" ," & NameOf(_R004.KAITO_10))
        sbSQL.Append(" ," & NameOf(_R004.KAITO_11))
        sbSQL.Append(" ," & NameOf(_R004.KAITO_12))
        sbSQL.Append(" ," & NameOf(_R004.KAITO_13))
        sbSQL.Append(" ," & NameOf(_R004.KAITO_14))
        sbSQL.Append(" ," & NameOf(_R004.KAITO_15))
        sbSQL.Append(" ," & NameOf(_R004.KAITO_16))
        sbSQL.Append(" ," & NameOf(_R004.KAITO_17))
        sbSQL.Append(" ," & NameOf(_R004.KAITO_18))
        sbSQL.Append(" ," & NameOf(_R004.KAITO_19))
        sbSQL.Append(" ," & NameOf(_R004.KAITO_20))
        sbSQL.Append(" ," & NameOf(_R004.KAITO_21))
        sbSQL.Append(" ," & NameOf(_R004.KAITO_22))
        sbSQL.Append(" ," & NameOf(_R004.KAITO_23))
        sbSQL.Append(" ," & NameOf(_R004.KAITO_24))
        sbSQL.Append(" ," & NameOf(_R004.KAITO_25))
        sbSQL.Append(" ," & NameOf(_R004.KONPON_YOIN_KB1))
        sbSQL.Append(" ," & NameOf(_R004.KONPON_YOIN_KB2))
        sbSQL.Append(" ," & NameOf(_R004.KONPON_YOIN_SYAIN_ID))
        sbSQL.Append(" ," & NameOf(_R004.KISEKI_KOTEI_KB))
        sbSQL.Append(" ," & NameOf(_R004.SYOCHI_A_SYAIN_ID))
        sbSQL.Append(" ," & NameOf(_R004.SYOCHI_A_YMDHNS))
        sbSQL.Append(" ," & NameOf(_R004.SYOCHI_B_SYAIN_ID))
        sbSQL.Append(" ," & NameOf(_R004.SYOCHI_B_YMDHNS))
        sbSQL.Append(" ," & NameOf(_R004.SYOCHI_C_SYAIN_ID))
        sbSQL.Append(" ," & NameOf(_R004.SYOCHI_C_YMDHNS))
        sbSQL.Append(" ," & NameOf(_R004.KYOIKU_FILE_PATH))
        sbSQL.Append(" ," & NameOf(_R004.ZESEI_SYOCHI_YUKO_UMU))
        sbSQL.Append(" ," & NameOf(_R004.SYOSAI_FILE_PATH))
        sbSQL.Append(" ," & NameOf(_R004.GOKI))
        sbSQL.Append(" ," & NameOf(_R004.LOT))
        sbSQL.Append(" ," & NameOf(_R004.KENSA_TANTO_ID))
        sbSQL.Append(" ," & NameOf(_R004.KENSA_TOROKU_YMDHNS))
        sbSQL.Append(" ," & NameOf(_R004.KENSA_GL_SYAIN_ID))
        sbSQL.Append(" ," & NameOf(_R004.KENSA_GL_YMDHNS))
        sbSQL.Append(" ," & NameOf(_R004.FILE_PATH1))
        sbSQL.Append(" ," & NameOf(_R004.FILE_PATH2))
        sbSQL.Append(" ," & NameOf(_R004.FUTEKIGO_HASSEI_YMD))
        sbSQL.Append(" ," & NameOf(_R004.SYOCHI_YOTEI_YMD))
        sbSQL.Append(" ) VALUES(")
        sbSQL.Append(" '" & strYMDHNS & "'")
        sbSQL.Append(" ,'" & _D005_CAR_J.HOKOKU_NO & "'")
        sbSQL.Append(" ,'" & _D005_CAR_J.BUMON_KB & "'")
        sbSQL.Append(" ,'" & _D005_CAR_J._CLOSE_FG & "'")
        sbSQL.Append(" ,'" & _D005_CAR_J.SETUMON_1 & "'")
        sbSQL.Append(" ,'" & _D005_CAR_J.SETUMON_2 & "'")
        sbSQL.Append(" ,'" & _D005_CAR_J.SETUMON_3 & "'")
        sbSQL.Append(" ,'" & _D005_CAR_J.SETUMON_4 & "'")
        sbSQL.Append(" ,'" & _D005_CAR_J.SETUMON_5 & "'")
        sbSQL.Append(" ,'" & _D005_CAR_J.SETUMON_6 & "'")
        sbSQL.Append(" ,'" & _D005_CAR_J.SETUMON_7 & "'")
        sbSQL.Append(" ,'" & _D005_CAR_J.SETUMON_8 & "'")
        sbSQL.Append(" ,'" & _D005_CAR_J.SETUMON_9 & "'")
        sbSQL.Append(" ,'" & _D005_CAR_J.SETUMON_10 & "'")
        sbSQL.Append(" ,'" & _D005_CAR_J.SETUMON_11 & "'")
        sbSQL.Append(" ,'" & _D005_CAR_J.SETUMON_12 & "'")
        sbSQL.Append(" ,'" & _D005_CAR_J.SETUMON_13 & "'")
        sbSQL.Append(" ,'" & _D005_CAR_J.SETUMON_14 & "'")
        sbSQL.Append(" ,'" & _D005_CAR_J.SETUMON_15 & "'")
        sbSQL.Append(" ,'" & _D005_CAR_J.SETUMON_16 & "'")
        sbSQL.Append(" ,'" & _D005_CAR_J.SETUMON_17 & "'")
        sbSQL.Append(" ,'" & _D005_CAR_J.SETUMON_18 & "'")
        sbSQL.Append(" ,'" & _D005_CAR_J.SETUMON_19 & "'")
        sbSQL.Append(" ,'" & _D005_CAR_J.SETUMON_20 & "'")
        sbSQL.Append(" ,'" & _D005_CAR_J.SETUMON_21 & "'")
        sbSQL.Append(" ,'" & _D005_CAR_J.SETUMON_22 & "'")
        sbSQL.Append(" ,'" & _D005_CAR_J.SETUMON_23 & "'")
        sbSQL.Append(" ,'" & _D005_CAR_J.SETUMON_24 & "'")
        sbSQL.Append(" ,'" & _D005_CAR_J.SETUMON_25 & "'")
        sbSQL.Append(" ,'" & _D005_CAR_J.KAITO_1 & "'")
        sbSQL.Append(" ,'" & _D005_CAR_J.KAITO_2 & "'")
        sbSQL.Append(" ,'" & _D005_CAR_J.KAITO_3 & "'")
        sbSQL.Append(" ,'" & _D005_CAR_J.KAITO_4 & "'")
        sbSQL.Append(" ,'" & _D005_CAR_J.KAITO_5 & "'")
        sbSQL.Append(" ,'" & _D005_CAR_J.KAITO_6 & "'")
        sbSQL.Append(" ,'" & _D005_CAR_J.KAITO_7 & "'")
        sbSQL.Append(" ,'" & _D005_CAR_J.KAITO_8 & "'")
        sbSQL.Append(" ,'" & _D005_CAR_J.KAITO_9 & "'")
        sbSQL.Append(" ,'" & _D005_CAR_J.KAITO_10 & "'")
        sbSQL.Append(" ,'" & _D005_CAR_J.KAITO_11 & "'")
        sbSQL.Append(" ,'" & _D005_CAR_J.KAITO_12 & "'")
        sbSQL.Append(" ,'" & _D005_CAR_J.KAITO_13 & "'")
        sbSQL.Append(" ,'" & _D005_CAR_J.KAITO_14 & "'")
        sbSQL.Append(" ,'" & _D005_CAR_J.KAITO_15 & "'")
        sbSQL.Append(" ,'" & _D005_CAR_J.KAITO_16 & "'")
        sbSQL.Append(" ,'" & _D005_CAR_J.KAITO_17 & "'")
        sbSQL.Append(" ,'" & _D005_CAR_J.KAITO_18 & "'")
        sbSQL.Append(" ,'" & _D005_CAR_J.KAITO_19 & "'")
        sbSQL.Append(" ,'" & _D005_CAR_J.KAITO_20 & "'")
        sbSQL.Append(" ,'" & _D005_CAR_J.KAITO_21 & "'")
        sbSQL.Append(" ,'" & _D005_CAR_J.KAITO_22 & "'")
        sbSQL.Append(" ,'" & _D005_CAR_J._KAITO_23 & "'")
        sbSQL.Append(" ,'" & _D005_CAR_J.KAITO_24 & "'")
        sbSQL.Append(" ,'" & _D005_CAR_J.KAITO_25 & "'")

        sbSQL.Append(" ,'" & _D005_CAR_J.KONPON_YOIN_KB1 & "'")
        sbSQL.Append(" ,'" & _D005_CAR_J.KONPON_YOIN_KB2 & "'")
        sbSQL.Append(" ,'" & _D005_CAR_J.KONPON_YOIN_SYAIN_ID & "'")
        sbSQL.Append(" ,'" & _D005_CAR_J.KISEKI_KOTEI_KB & "'")
        sbSQL.Append(" ,'" & _D005_CAR_J.SYOCHI_A_SYAIN_ID & "'")
        sbSQL.Append(" ,'" & _D005_CAR_J.SYOCHI_A_YMDHNS & "'")
        sbSQL.Append(" ,'" & _D005_CAR_J.SYOCHI_B_SYAIN_ID & "'")
        sbSQL.Append(" ,'" & _D005_CAR_J.SYOCHI_B_YMDHNS & "'")
        sbSQL.Append(" ,'" & _D005_CAR_J.SYOCHI_C_SYAIN_ID & "'")
        sbSQL.Append(" ,'" & _D005_CAR_J.SYOCHI_C_YMDHNS & "'")
        sbSQL.Append(" ,'" & _D005_CAR_J.KYOIKU_FILE_PATH & "'")
        sbSQL.Append(" ,'" & _D005_CAR_J._ZESEI_SYOCHI_YUKO_UMU & "'")
        sbSQL.Append(" ,'" & _D005_CAR_J.SYOSAI_FILE_PATH & "'")
        sbSQL.Append(" ,'" & _D005_CAR_J.GOKI & "'")
        sbSQL.Append(" ,'" & _D005_CAR_J.LOT & "'")
        sbSQL.Append(" ,'" & _D005_CAR_J.KENSA_TANTO_ID & "'")
        sbSQL.Append(" ,'" & _D005_CAR_J.KENSA_TOROKU_YMDHNS & "'")
        sbSQL.Append(" ,'" & _D005_CAR_J.KENSA_GL_SYAIN_ID & "'")
        sbSQL.Append(" ,'" & _D005_CAR_J.KENSA_GL_YMDHNS & "'")
        sbSQL.Append(" ,'" & _D005_CAR_J.FILE_PATH1 & "'")
        sbSQL.Append(" ,'" & _D005_CAR_J.FILE_PATH2 & "'")
        sbSQL.Append(" ,'" & _D005_CAR_J.FUTEKIGO_HASSEI_YMD & "'")
        sbSQL.Append(" ,'" & _D005_CAR_J.SYOCHI_YOTEI_YMD & "'")
        sbSQL.Append(" );")
        intRET = DB.ExecuteNonQuery(sbSQL.ToString, conblnNonMsg, sqlEx)
        If intRET <> 1 Then
            '-----�G���[���O�o��
            Dim strErrMsg As String = My.Resources.ErrLogSqlExecutionFailure & sbSQL.ToString & "|" & sqlEx.Message
            WL.WriteLogDat(strErrMsg)
            Return False
        Else
            Return True
        End If
    End Function

    Private Function FunSAVE_R005(ByRef DB As ClsDbUtility, ByVal strYMDHNS As String) As Boolean
        Dim sbSQL As New System.Text.StringBuilder
        Dim intRET As Integer
        Dim sqlEx As New Exception

        '-----MERGE
        sbSQL.Append($" INSERT INTO {NameOf(R005_FCR_SASIMODOSI)}(")
        sbSQL.Append($"  {NameOf(_R005.SASIMODOSI_YMDHNS)}")
        sbSQL.Append($" ,{NameOf(_R005.HOKOKU_NO)}")
        sbSQL.Append($" ,{NameOf(_R005.CLOSE_FG)}")
        sbSQL.Append($" ,{NameOf(_R005.KOKYAKU_EIKYO_HANTEI_KB)}")
        sbSQL.Append($" ,{NameOf(_R005.TAISYOU_KOKYAKU)}")
        sbSQL.Append($" ,{NameOf(_R005.KOKYAKU_EIKYO_HANTEI_COMMENT)}")
        sbSQL.Append($" ,{NameOf(_R005.KOKYAKU_EIKYO_NAIYO)}")
        sbSQL.Append($" ,{NameOf(_R005.KAKUNIN_SYUDAN)}")
        sbSQL.Append($" ,{NameOf(_R005.KOKYAKU_EIKYO_TUCHI_HANTEI_KB)}")
        sbSQL.Append($" ,{NameOf(_R005.TUCHI_YMD)}")
        sbSQL.Append($" ,{NameOf(_R005.TUCHI_SYUDAN)}")
        sbSQL.Append($" ,{NameOf(_R005.HITUYO_TETUDUKI_ZIKO)}")
        sbSQL.Append($" ,{NameOf(_R005.KOKYAKU_EIKYO_ETC_COMMENT)}")
        sbSQL.Append($" ,{NameOf(_R005.OTHER_PROCESS_INFLUENCE_KB)}")
        sbSQL.Append($" ,{NameOf(_R005.FOLLOW_PROCESS_OUTFLOW_KB)}")
        sbSQL.Append($" ,{NameOf(_R005.KOKYAKU_NOUNYU_NAIYOU)}")
        sbSQL.Append($" ,{NameOf(_R005.KOKYAKU_NOUNYU_YMD)}")
        sbSQL.Append($" ,{NameOf(_R005.ZAIKO_SIKAKE_NAIYOU)}")
        sbSQL.Append($" ,{NameOf(_R005.ZAIKO_SIKAKE_YMD)}")
        sbSQL.Append($" ,{NameOf(_R005.OTHER_PROCESS_NAIYOU)}")
        sbSQL.Append($" ,{NameOf(_R005.OTHER_PROCESS_YMD)}")

        sbSQL.Append($" ,{NameOf(_R005.KOKYAKU_EIKYO_HANTEI_FILEPATH)}")
        sbSQL.Append($" ,{NameOf(_R005.FUTEKIGO_SEIHIN_MEMO)}")
        sbSQL.Append($" ,{NameOf(_R005.KOKYAKU_EIKYO_MEMO)}")
        sbSQL.Append($" ,{NameOf(_R005.OTHER_PROCESS_INFLUENCE_MEMO)}")
        sbSQL.Append($" ,{NameOf(_R005.OTHER_PROCESS_INFLUENCE_FILEPATH)}")
        sbSQL.Append($" ,{NameOf(_R005.FOLLOW_PROCESS_OUTFLOW_MEMO)}")
        sbSQL.Append($" ,{NameOf(_R005.FOLLOW_PROCESS_OUTFLOW_FILEPATH)}")
        sbSQL.Append($" ,{NameOf(_R005.FUTEKIGO_SEIHIN_FILEPATH)}")
        sbSQL.Append($" ,{NameOf(_R005.KOKYAKU_EIKYO_FILEPATH)}")
        sbSQL.Append($" ,{NameOf(_R005.SYOCHI_MEMO)}")
        sbSQL.Append($" ,{NameOf(_R005.SYOCHI_FILEPATH)}")
        sbSQL.Append(" ) VALUES(")
        sbSQL.Append($" '{strYMDHNS}'")
        sbSQL.Append($" ,'{_D007.HOKOKU_NO}'")
        sbSQL.Append($" ,'{_D007._CLOSE_FG}'")
        sbSQL.Append($" ,'{_D007._KOKYAKU_EIKYO_HANTEI_KB}'")
        sbSQL.Append($" ,'{_D007.TAISYOU_KOKYAKU}'")
        sbSQL.Append($" ,'{_D007.KOKYAKU_EIKYO_HANTEI_COMMENT}'")
        sbSQL.Append($" ,'{_D007.KOKYAKU_EIKYO_NAIYO}'")
        sbSQL.Append($" ,'{_D007.KAKUNIN_SYUDAN}'")
        sbSQL.Append($" ,'{_D007._KOKYAKU_EIKYO_TUCHI_HANTEI_KB}'")
        sbSQL.Append($" ,'{_D007.TUCHI_YMD}'")
        sbSQL.Append($" ,'{_D007.TUCHI_SYUDAN}'")
        sbSQL.Append($" ,'{_D007.HITUYO_TETUDUKI_ZIKO}'")
        sbSQL.Append($" ,'{_D007.KOKYAKU_EIKYO_ETC_COMMENT}'")
        sbSQL.Append($" ,'{_D007._OTHER_PROCESS_INFLUENCE_KB}'")
        sbSQL.Append($" ,'{_D007._FOLLOW_PROCESS_OUTFLOW_KB}'")
        sbSQL.Append($" ,'{_D007.KOKYAKU_NOUNYU_NAIYOU}'")
        sbSQL.Append($" ,'{_D007.KOKYAKU_NOUNYU_YMD}'")
        sbSQL.Append($" ,'{_D007.ZAIKO_SIKAKE_NAIYOU}'")
        sbSQL.Append($" ,'{_D007.ZAIKO_SIKAKE_YMD}'")
        sbSQL.Append($" ,'{_D007.OTHER_PROCESS_NAIYOU}'")
        sbSQL.Append($" ,'{_D007.OTHER_PROCESS_YMD}'")

        sbSQL.Append($" ,'{_D007.KOKYAKU_EIKYO_HANTEI_FILEPATH}'")
        sbSQL.Append($" ,'{_D007.FUTEKIGO_SEIHIN_MEMO}'")
        sbSQL.Append($" ,'{_D007.KOKYAKU_EIKYO_MEMO}'")
        sbSQL.Append($" ,'{_D007.OTHER_PROCESS_INFLUENCE_MEMO}'")
        sbSQL.Append($" ,'{_D007.OTHER_PROCESS_INFLUENCE_FILEPATH}'")
        sbSQL.Append($" ,'{_D007.FOLLOW_PROCESS_OUTFLOW_MEMO}'")
        sbSQL.Append($" ,'{_D007.FOLLOW_PROCESS_OUTFLOW_FILEPATH}'")
        sbSQL.Append($" ,'{_D007.FUTEKIGO_SEIHIN_FILEPATH}'")
        sbSQL.Append($" ,'{_D007.KOKYAKU_EIKYO_FILEPATH}'")
        sbSQL.Append($" ,'{_D007.SYOCHI_MEMO}'")
        sbSQL.Append($" ,'{_D007.SYOCHI_FILEPATH}'")
        sbSQL.Append(" );")
        intRET = DB.ExecuteNonQuery(sbSQL.ToString, conblnNonMsg, sqlEx)
        If intRET <> 1 Then
            '-----�G���[���O�o��
            Dim strErrMsg As String = My.Resources.ErrLogSqlExecutionFailure & sbSQL.ToString & "|" & sqlEx.Message
            WL.WriteLogDat(strErrMsg)
            Return False
        Else
            Return True
        End If
    End Function

    Private Function FunSAVE_R006(ByRef DB As ClsDbUtility, ByVal strYMDHNS As String) As Boolean
        Dim sbSQL As New System.Text.StringBuilder
        Dim intRET As Integer
        Dim sqlEx As New Exception

        Try
            _V011_FCR_J.Clear()
            _V011_FCR_J = FunGetV011Model(PrHOKOKU_NO)

            For i As Integer = 1 To 6
                sbSQL.Clear()
                sbSQL.Append($" INSERT INTO {NameOf(R006_FCR_J_SUB_SASIMODOSI)}(")
                sbSQL.Append($"  {NameOf(R006_FCR_J_SUB_SASIMODOSI.SASIMODOSI_YMDHNS)}")
                sbSQL.Append($" ,{NameOf(R006_FCR_J_SUB_SASIMODOSI.HOKOKU_NO)}")
                sbSQL.Append($" ,{NameOf(R006_FCR_J_SUB_SASIMODOSI.ROW_NO)}")
                sbSQL.Append($" ,{NameOf(R006_FCR_J_SUB_SASIMODOSI.KISYU_ID)}")
                sbSQL.Append($" ,{NameOf(R006_FCR_J_SUB_SASIMODOSI.BUHIN_INFO)}")
                sbSQL.Append($" ,{NameOf(R006_FCR_J_SUB_SASIMODOSI.SURYO)}")
                sbSQL.Append($" ,{NameOf(R006_FCR_J_SUB_SASIMODOSI.RANGE_FROM)}")
                sbSQL.Append($" ,{NameOf(R006_FCR_J_SUB_SASIMODOSI.RANGE_TO)}")
                sbSQL.Append(" ) VALUES(")
                sbSQL.Append($" '{strYMDHNS}'")
                sbSQL.Append($" ,'{PrHOKOKU_NO}'")
                sbSQL.Append($" , {i}")
                sbSQL.Append($" , {_V011_FCR_J.Item("KISYU_ID" & i)}")
                sbSQL.Append($" ,'{_V011_FCR_J.Item("BUHIN_INFO" & i)}'")
                sbSQL.Append($" , {_V011_FCR_J.Item("SURYO" & i)}")
                sbSQL.Append($" ,'{_V011_FCR_J.Item("RANGE_FROM" & i)}'")
                sbSQL.Append($" ,'{_V011_FCR_J.Item("RANGE_TO" & i)}'")
                sbSQL.Append(" );")
                intRET = DB.ExecuteNonQuery(sbSQL.ToString, conblnNonMsg, sqlEx)
                If intRET <> 1 Then
                    '-----�G���[���O�o��
                    Dim strErrMsg As String = My.Resources.ErrLogSqlExecutionFailure & sbSQL.ToString & "|" & sqlEx.Message
                    WL.WriteLogDat(strErrMsg)
                    Return False
                End If
            Next

            Return True
        Catch ex As Exception
            Throw
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
                Dim cmd As Button = DirectCast(Me.Controls.Find("cmdFunc" & intFunc, True)(0), Button)
                With cmd
                    If cmd IsNot Nothing AndAlso .Text.Length = 0 OrElse .Text.Substring(0, .Text.IndexOf("(")).IsNulOrWS Then
                        .Text = ""
                        '.Visible = False
                        .Enabled = False
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

    '�����߂���
    Private Sub CmbMODOSI_SAKI_SelectedValueChanged(sender As Object, e As EventArgs) Handles cmbMODOSI_SAKI.SelectedValueChanged
        Dim cmb As ComboboxEx = DirectCast(sender, ComboboxEx)

        'SPEC: 20-5.�A
        If cmb.IsSelected Then
            mtxTANTO_NAME.Text = DirectCast(cmbMODOSI_SAKI.DataSource, DataTable).AsEnumerable.Where(Function(r) r.Field(Of Integer)("VALUE") = cmb.SelectedValue).First.Item("SYAIN_NAME")
            mtxTANTO_ID.Text = DirectCast(cmbMODOSI_SAKI.DataSource, DataTable).AsEnumerable.Where(Function(r) r.Field(Of Integer)("VALUE") = cmb.SelectedValue).First.Item("SYAIN_ID")
        Else
            mtxTANTO_ID.Text = ""
            mtxTANTO_NAME.Text = ""
        End If

    End Sub

    Private Sub CmbMODOSI_SAKI_Validating(sender As Object, e As System.ComponentModel.CancelEventArgs) Handles cmbMODOSI_SAKI.Validating
        Dim cmb As ComboboxEx = DirectCast(sender, ComboboxEx)
        If IsCheckRequired Then
            IsValidated *= ErrorProvider.UpdateErrorInfo(cmb, cmb.IsSelected, String.Format(My.Resources.infoMsgRequireSelectOrInput, "���߂���"))
        End If
    End Sub

    Private Sub MtxMODOSI_RIYU_Validating(sender As Object, e As System.ComponentModel.CancelEventArgs) Handles mtxMODOSI_RIYU.Validating
        Dim mtx As MaskedTextBoxEx = DirectCast(sender, MaskedTextBoxEx)
        If IsCheckRequired Then
            IsValidated *= ErrorProvider.UpdateErrorInfo(mtx, Not mtx.Text.IsNulOrWS, String.Format(My.Resources.infoMsgRequireSelectOrInput, "���߂����R"))
        End If
    End Sub

#End Region

#Region "���̓`�F�b�N"

    Public Function FunCheckInput() As Boolean
        Try
            IsValidated = True
            IsCheckRequired = True
            Call CmbMODOSI_SAKI_Validating(cmbMODOSI_SAKI, Nothing)
            Call MtxMODOSI_RIYU_Validating(mtxMODOSI_RIYU, Nothing)

            Return IsValidated
        Catch ex As Exception
            Throw
        Finally
            IsCheckRequired = False
        End Try
    End Function

#End Region

#Region "���[�J���֐�"

    Private Function FunSetBinding() As Boolean

        mtxMODOSI_RIYU.DataBindings.Add(New Binding(NameOf(mtxMODOSI_RIYU.Text), _D004_SYONIN_J_KANRI, NameOf(_D004_SYONIN_J_KANRI.RIYU), False, DataSourceUpdateMode.OnPropertyChanged, ""))
    End Function

    Private Function FunGetMODISI_SAKI(ByVal intSYONIN_HOKOKU_ID As Integer, ByVal strHOKOKU_NO As String, ByVal intCurrentStage As Integer) As DataTable
        Dim dt As New DataTableEx("System.Int32")
        Dim sbSQL As New System.Text.StringBuilder
        Dim dsList As New DataSet

        sbSQL.Append($"SELECT * FROM {NameOf(MODEL.V003_SYONIN_J_KANRI)} MAIN")
        sbSQL.Append($" WHERE {NameOf(MODEL.V003_SYONIN_J_KANRI.SYONIN_HOKOKUSYO_ID)}={intSYONIN_HOKOKU_ID}")
        sbSQL.Append($" AND {NameOf(MODEL.V003_SYONIN_J_KANRI.HOKOKU_NO)}='{strHOKOKU_NO}'")

        Select Case intCurrentStage
            Case 20
                sbSQL.Append($" AND ({NameOf(MODEL.V003_SYONIN_J_KANRI.SYONIN_JUN)}=(SELECT MAX({NameOf(MODEL.V003_SYONIN_J_KANRI.SYONIN_JUN)}) FROM {NameOf(MODEL.V003_SYONIN_J_KANRI)} AS SUB WHERE SUB.{NameOf(MODEL.V003_SYONIN_J_KANRI.SYONIN_JUN)}<{intCurrentStage}))")

            Case Else
                '�J�����g�X�e�[�W��20�ȊO�̏ꍇ�͍����߂���Ƃ���20���ǉ�
                sbSQL.Append($" AND ({NameOf(MODEL.V003_SYONIN_J_KANRI.SYONIN_JUN)}=20")
                sbSQL.Append($" OR {NameOf(MODEL.V003_SYONIN_J_KANRI.SYONIN_JUN)}=(SELECT MAX({NameOf(MODEL.V003_SYONIN_J_KANRI.SYONIN_JUN)})")
                sbSQL.Append($" FROM {NameOf(MODEL.V003_SYONIN_J_KANRI)} AS SUB")
                sbSQL.Append($" WHERE SUB.{NameOf(MODEL.V003_SYONIN_J_KANRI.SYONIN_JUN)}<{intCurrentStage}")
                sbSQL.Append($" AND SUB.{NameOf(MODEL.V003_SYONIN_J_KANRI.SYONIN_HOKOKUSYO_ID)}={intSYONIN_HOKOKU_ID}")
                sbSQL.Append($" AND SUB.{NameOf(MODEL.V003_SYONIN_J_KANRI.HOKOKU_NO)}='{strHOKOKU_NO}'))")
        End Select

        Using DB As ClsDbUtility = DBOpen()
            dsList = DB.GetDataSet(sbSQL.ToString, False)
        End Using

        dt.Columns.Add("SYONIN_HOKOKUSYO_ID", GetType(Integer))
        dt.Columns.Add("SYAIN_ID", GetType(Integer))
        dt.Columns.Add("SYAIN_NAME", GetType(String))
        dt.Columns.Add("HOKOKU_NO", GetType(String))

        '��L�[�ݒ�
        dt.PrimaryKey = {dt.Columns("SYONIN_JUN"), dt.Columns("HOKOKU_NO")}

        With dsList.Tables(0)
            For intCNT = 0 To .Rows.Count - 1
                Dim Trow As DataRow = dt.NewRow()

                If .Rows(intCNT).Item("SYONIN_JUN") = ENM_NCR_STAGE._10_�N������ Then
                    Trow("DISP") = .Rows(intCNT).Item("SYONIN_NAIYO") & " " & .Rows(intCNT).Item("UPD_SYAIN_NAME")
                    Trow("SYAIN_ID") = .Rows(intCNT).Item("UPD_SYAIN_ID")
                    Trow("SYAIN_NAME") = .Rows(intCNT).Item("UPD_SYAIN_NAME")
                Else
                    Trow("DISP") = .Rows(intCNT).Item("SYONIN_NAIYO") & " " & .Rows(intCNT).Item("UPD_SYAIN_NAME")
                    Trow("SYAIN_ID") = .Rows(intCNT).Item("UPD_SYAIN_ID")
                    Trow("SYAIN_NAME") = .Rows(intCNT).Item("UPD_SYAIN_NAME")
                End If

                Trow("VALUE") = .Rows(intCNT).Item("SYONIN_JUN")
                Trow("SYONIN_HOKOKUSYO_ID") = .Rows(intCNT).Item("SYONIN_HOKOKUSYO_ID")
                Trow("HOKOKU_NO") = .Rows(intCNT).Item("HOKOKU_NO")

                dt.Rows.Add(Trow)
            Next intCNT
        End With

        Return dt
    End Function

    ''' <summary>
    ''' ���F�˗����[�����M
    ''' </summary>
    ''' <returns></returns>
    Private Function FunSendRequestMail()
        Dim KISYU_NAME As String = PrKISYU_NAME 'tblKISYU.AsEnumerable.Where(Function(r) r.Field(Of Integer)("VALUE") = _D003_NCR_J.KISYU_ID).FirstOrDefault?.Item("DISP")
        Dim SYONIN_HANTEI_NAME As String = tblSYONIN_HANTEI_KB.LazyLoad("���F����敪").AsEnumerable.Where(Function(r) r.Field(Of String)("VALUE") = _D004_SYONIN_J_KANRI.SYONIN_HANTEI_KB).FirstOrDefault?.Item("DISP")
        Dim SYONIN_HOKOKUSYO_NAME As String = If(PrSYONIN_HOKOKUSYO_ID = 1, "NCR", "CAR")
        Dim strEXEParam As String = $"{_D004_SYONIN_J_KANRI.SYAIN_ID},{Val(ENM_OPEN_MODE._2_���u��ʋN��)},{PrSYONIN_HOKOKUSYO_ID},{PrHOKOKU_NO}"
        Dim strSubject As String = $"�y�s�K���i���u�˗��z[{SYONIN_HOKOKUSYO_NAME}] {KISYU_NAME}�E{PrBUHIN_BANGO}"
        Dim strBody As String = <html><![CDATA[
        {0} �a<br />
        <br />
        �@�s�K�����i�̍��߈˗������܂����̂őΉ������肢���܂��B<br />
        <br />
        �@�@�y�� �� ���z{1}<br />
        �@�@�y�񍐏�No�z{2}<br />
        �@�@�y�N�����@�z{3}<br />
        �@�@�y�@��@�@�z{4}<br />
        �@�@�y���i�ԍ��z{5}<br />
        �@�@�y�˗��ҁ@�z{6}<br />
        �@�@�y�˗��ҏ��u���e�z{7}<br />
        �@�@�y�R�����g�z{8}<br />
        <br />
        <a href = "http://sv04:8000/CLICKONCE_FMS.application" >�V�X�e���N��</a><br />
        <br />
        �����̃��[���͔z�M��p�ł��B(�ԐM�ł��܂���)<br />
        �ԐM����ꍇ�́A�e�S���҂̃��[���A�h���X���g�p���ĉ������B<br />
        ]]></html>.Value.Trim

        'http://sv116:8000/CLICKONCE_FMS.application?SYAIN_ID={8}&EXEPATH={9}&PARAMS={10}

        strBody = String.Format(strBody,
                                Fun_GetUSER_NAME(mtxTANTO_ID.Text),
                                SYONIN_HOKOKUSYO_NAME,
                                PrHOKOKU_NO,
                                PrKISO_YMD,
                                KISYU_NAME,
                                PrBUHIN_BANGO,
                                Fun_GetUSER_NAME(pub_SYAIN_INFO.SYAIN_ID),
                                SYONIN_HANTEI_NAME,
                                _D004_SYONIN_J_KANRI.RIYU,
                                mtxTANTO_ID.Text,
                                "FMS_G0010.exe",
                                strEXEParam)

        If FunSendMailFutekigo(strSubject, strBody, ToSYAIN_ID:=mtxTANTO_ID.Text) Then
            Using DB As ClsDbUtility = DBOpen()
                If FunGetCodeMastaValue(DB, "���[���ݒ�", "ENABLE").ToString.Trim.ToUpper = "FALSE" Then
                Else
                    MessageBox.Show("���u�˗����[���𑗐M���܂����B", "���[�����M����", MessageBoxButtons.OK, MessageBoxIcon.Information)
                End If
            End Using

            Return True
        Else
            MessageBox.Show("���[�����M�Ɏ��s���܂����B", "���[�����M���s", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Return False
        End If
    End Function

#End Region

End Class