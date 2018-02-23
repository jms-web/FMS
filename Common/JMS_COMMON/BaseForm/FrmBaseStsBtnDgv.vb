Imports JMS_COMMON.ClsPubMethod

''' <summary>
''' DataGridView�R���g���[���́A�A�N�Z�X�C���q:Public�Œ�`���Ă��p����Ńv���p�e�B�Q�Ƃ����o���邽�߁A
''' �R���g���[���{�̂͌p����Ɏ������A���ʏ����E�C�x���g�݂̂��̃t�H�[���̂��̂��Q�Ƃ���
''' </summary>
Public Class FrmBaseStsBtnDgv

#Region "�ϐ��E�萔"
    'DATAGRIDVIEW�����s�̔w�i�F
    Protected clrRowEvenColor As Color = Color.White
    'DATAGRIDVIEW��s�̔w�i�F
    Protected clrRowOddColor As Color = Color.Bisque  'PaleGreen
    'DATAGRIDVIEW�I���s�̔w�i�F
    Protected clrRowEnterColor As Color = Color.Cyan
    'DATAGRIDVIEW�폜�ςݍs�̕����F
    Protected clrDeletedRowForeColor As Color = Color.FromArgb(74, 74, 74)
    'DATAGRIDVIEW�폜�ςݍs�̔w�i�F
    Protected clrDeletedRowBackColor As Color = Color.FromArgb(200, 200, 200)
    'DATAGRIDVIEW�ҏW�����s�̔w�i�F
    Protected clrUnavailableRowBackColor As Color = Color.FromArgb(200, 200, 200)
    'DATAGRIDVIEW�ҏW�\�ȑI���Z���̔w�i�F
    Protected clrCanEditCellBackColor As Color = Color.Gold
    'DATAGRIDVIEW�ҏW�ς݃Z���̕����F
    Protected clrEditedCellForeColor As Color = Color.Red


    '�O���b�h�f�[�^�̑I���s���L�^
    Public intDgvCurrentRow As Integer = 0

#End Region

#Region "�v���p�e�B"

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

#Region "FORM�C�x���g"
    Private Sub Frm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        If Me.DesignMode = False Then
            lblRecordCount.BorderStyle = BorderStyle.None
        End If
    End Sub

    Overrides Sub FrmBaseStsBtn_Resize(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Resize
        If Me.Visible = False Then Exit Sub

        If Me.DesignMode = True Then Exit Sub

        ''===================================
        ''   �{�^���ʒu�A�T�C�Y�ݒ�
        ''===================================
        Call SetButtonSize(Me.Width, cmdFunc)

        MyBase.FrmBaseStsBtn_Resize(Me, e)

    End Sub
#End Region

#Region "DATAGRIDVIEW�֘A"

    ''' <summary>
    ''' DATAGRIDVIEW�����ݒ�
    ''' </summary>
    ''' <param name="dgv">�p����t�H�[����DataGridView</param>
    ''' <returns></returns>
    Protected Function FunInitializeDataGridView(ByVal dgv As DataGridView) As Boolean
        Try

            '�K��̃R���g���[���ݒ�
            With dgv
                '���T�C�Y
                .Anchor = AnchorStyles.Top Or AnchorStyles.Bottom Or AnchorStyles.Left Or AnchorStyles.Right
                '���ڕҏWMODE
                .ReadOnly = True
                '�s�w�b�_�\��
                .RowHeadersVisible = False
                '���[�U�[�̍s���ύX
                .AllowUserToResizeRows = False
                '���[�U�[�̗񕝕ύX
                '.AllowUserToResizeColumns = False
                '�ŏI�s�Ƀf�[�^���͍s�\��
                .AllowUserToAddRows = False
                '�����Z���I��
                .MultiSelect = False
                'TAB�Ńt�H�[�J�X�ړ�
                .StandardTab = True
                'FONT
                .Font = New Font("Meiryo UI", 9, FontStyle.Bold, GraphicsUnit.Point, CType(128, Byte))
                '��w�b�_����
                .ColumnHeadersHeight = 38
                .ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing
                '�ǉ������s�̍���
                .RowTemplate.Height = 26
                '��w�b�_TEXT��
                .ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
                '�Z��TEXT��
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
                '��s�w�i�F
                .AlternatingRowsDefaultCellStyle.BackColor = clrRowOddColor
                '�����s�w�i�F
                .RowsDefaultCellStyle.BackColor = clrRowEvenColor
                '�I���Z���w�i�F
                .DefaultCellStyle.SelectionBackColor = clrRowEnterColor
                '�I���Z���O�i�F
                .DefaultCellStyle.SelectionForeColor = Color.Black
                '��s�I��
                .MultiSelect = False
                .SelectionMode = DataGridViewSelectionMode.FullRowSelect
                '�ҏW�J�n���@
                .EditMode = DataGridViewEditMode.EditOnKeystroke
                '�s��DELETE�L�[�ō폜
                .AllowUserToDeleteRows = False
            End With

            AddHandler dgv.SelectionChanged, AddressOf dgvDATA_SelectionChanged
            'AddHandler dgv.CellPainting, AddressOf dgvDATA_CellPainting

            Return True

        Catch ex As Exception
            EM.ErrorSyori(ex, False, conblnNonMsg)
            Return False
        End Try
    End Function

    '�I���s�ύX���C�x���g
    Protected Sub dgvDATA_SelectionChanged(sender As Object, e As System.EventArgs)
        Dim dgv As DataGridView = DirectCast(sender, DataGridView)
        If dgv.CurrentCell IsNot Nothing Then
            intDgvCurrentRow = dgv.CurrentCell.RowIndex
        End If
    End Sub

    '�Z���`�掞�C�x���g
    Protected Sub dgvDATA_CellPainting(sender As System.Object, e As System.Windows.Forms.DataGridViewCellPaintingEventArgs) 'Handles dgvDATA.CellPainting
        Dim blnSelected As Boolean
        Dim strText As String
        Dim fcolor As Color
        'Dim bcolor As Color
        Dim flags As TextFormatFlags

        Try

            '-----�ŗL�ݒ�
            'Dim dgv As DataGridView = DirectCast(sender, DataGridView)
            'Dim dgvCell As DataGridViewCell = DirectCast(dgv.CurrentCell, DataGridViewCell)
            'If TypeOf dgvCell Is DataGridViewCheckBoxCell Then
            '    Exit Sub
            'End If
            '-----�ŗL�ݒ�


            If e.RowIndex >= 0 Then
                '�Z���I�𔻒�
                If (e.PaintParts And DataGridViewPaintParts.SelectionBackground) = DataGridViewPaintParts.SelectionBackground AndAlso
                    (e.State And DataGridViewElementStates.Selected) = DataGridViewElementStates.Selected Then
                    'If (e.State & DataGridViewElementStates.Selected) <> DataGridViewElementStates.None Then

                    blnSelected = True
                End If

                '�Z���w�i�̕`��
                e.PaintBackground(e.ClipBounds, blnSelected)

                '�`�悷��e�L�X�g
                If e.Value IsNot Nothing AndAlso e.Value.ToString <> "" Then
                    If e.CellStyle.Format <> "" Then

                        '�����t�̃Z���̏ꍇ
                        If IsNumeric(e.Value) = True Then
                            strText = Val(e.Value).ToString(e.CellStyle.Format)
                        Else
                            strText = e.Value.ToString(e.CellStyle.Format)
                        End If

                    Else
                        '�����Ȃ��̃Z���̏ꍇ
                        strText = e.Value.ToString
                    End If

                Else
                    strText = ""
                End If

                '�e�L�X�g�̐F
                If blnSelected = True Then
                    fcolor = e.CellStyle.SelectionForeColor
                    'bcolor = e.CellStyle.SelectionBackColor
                Else
                    fcolor = e.CellStyle.ForeColor
                    'bcolor = e.CellStyle.BackColor
                End If



                '�e�L�X�g�̔z�u
                Select Case e.CellStyle.Alignment
                    Case 16  'MiddleLeft
                        flags = TextFormatFlags.Left Or TextFormatFlags.VerticalCenter Or TextFormatFlags.SingleLine Or TextFormatFlags.PreserveGraphicsClipping
                    Case 32  'MiddleCenter
                        flags = TextFormatFlags.HorizontalCenter Or TextFormatFlags.VerticalCenter Or TextFormatFlags.SingleLine Or TextFormatFlags.PreserveGraphicsClipping
                    Case 64  'MiddleRight
                        flags = TextFormatFlags.Right Or TextFormatFlags.VerticalCenter Or TextFormatFlags.SingleLine Or TextFormatFlags.PreserveGraphicsClipping
                    Case Else
                        flags = TextFormatFlags.Default Or TextFormatFlags.SingleLine Or TextFormatFlags.PreserveGraphicsClipping
                End Select

                '������̕`��
                TextRenderer.DrawText(e.Graphics, strText, e.CellStyle.Font, e.CellBounds, fcolor, flags:=flags)

                '�`�揈���������ōs�����ꍇ��True
                e.Handled = True

            End If

        Catch ex As Exception
            EM.ErrorSyori(ex, False, conblnNonMsg)
        End Try
    End Sub

#End Region

End Class