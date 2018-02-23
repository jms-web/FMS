Imports JMS_COMMON.ClsPubMethod

Module mdlKTS_COMMON

#Region "定数・変数"

#End Region

#Region "MAIN"
    Public Sub Initialize()

        Try

            '-----共通初期処理
            If FunINTSYR() = False Then
                WL.WriteLogDat(My.Resources.ErrLogMsgSetCommonInit)
                Exit Sub
            End If

            '-----PG設定ファイル読込処理
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
