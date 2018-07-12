Imports JMS_COMMON.ClsPubMethod


''' <summary>
''' �����߂��O��ł̕ύX���ڂ̔�r
''' </summary>
Public Class FrmG0019

#Region "�v���p�e�B"

    Property PrFilePath As String

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

    End Sub

#End Region

#Region "Form�֘A"

    'Load�C�x���g
    Private Sub FrmLoad(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        Try
            '-----�t�H�[�������ݒ�(�e�t�H�[������Ăяo��)
            Call FunFormCommonSetting(pub_APP_INFO, pub_SYAIN_INFO, My.Application.Info.Version.ToString)
            lblTytle.Text = ""
            Me.Text = lblTytle.Text

            Call FunInitFuncButtonEnabled()

            Call FunOpenWorkbook(PrFilePath)

        Finally

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

#Region "FuncButton�L�������ؑ�"


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

    Private Function FunOpenWorkbook(filePath As String) As Boolean
        Try
            WorkbookView.GetLock()
            Dim workbookSet As SpreadsheetGear.IWorkbookSet = SpreadsheetGear.Factory.GetWorkbookSet(System.Globalization.CultureInfo.CurrentCulture)
            Dim workbook As SpreadsheetGear.IWorkbook = workbookSet.Workbooks.Open(filePath)
            Dim worksheet As SpreadsheetGear.IWorksheet = workbook.Worksheets(0)

            'workbook.ReadOnlyRecommended = True
            'WorkbookView.AllowEditCommands = False
            worksheet.ProtectContents = True
            worksheet.WindowInfo.DisplayGridlines = False
            worksheet.WindowInfo.DisplayHeadings = False
            worksheet.WindowInfo.DisplayOutline = False
            worksheet.WindowInfo.DisplayZeros = False

            WorkbookView.ActiveWorkbook = workbook
            WorkbookView.PrintPreview()
            Return True

        Catch ex As Exception
            Throw
            Return False
        Finally
            WorkbookView.ReleaseLock()
        End Try
    End Function

End Class