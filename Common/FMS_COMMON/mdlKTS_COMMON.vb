Imports JMS_COMMON.ClsPubMethod

Module mdlKTS_COMMON

#Region "�萔�E�ϐ�"

#End Region

#Region "MAIN"
    Public Sub Initialize()

        Try

            '-----���ʏ�������
            If FunINTSYR() = False Then
                WL.WriteLogDat(My.Resources.ErrLogMsgSetCommonInit)
                Exit Sub
            End If

            '-----PG�ݒ�t�@�C���Ǎ�����
            If FunGetPGIniFile(My.Application.Info.AssemblyName) = False Then
                WL.WriteLogDat(My.Resources.ErrLogMsgSetPGInit)
                Exit Sub
            End If

        Catch ex As Exception
            EM.ErrorSyori(ex, False, conblnNonMsg)
            MsgBox(My.Resources.ErrMsgInit, MsgBoxStyle.Critical, My.Application.Info.AssemblyName)
        End Try
    End Sub
#End Region

End Module
