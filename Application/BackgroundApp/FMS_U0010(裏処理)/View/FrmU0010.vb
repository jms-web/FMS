Imports JMS_COMMON.ClsPubMethod

Public Class FrmU0010



#Region "Form関連"

    'Loadイベント
    Private Sub FrmLoad(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        Try

            ''-----フォーム初期設定(親フォームから呼び出し)
            'Call FunFormCommonSetting(pub_APP_INFO, pub_SYAIN_INFO, My.Application.Info.Version.ToString)
            'Using DB As ClsDbUtility = DBOpen()
            '    lblTytle.Text = FunGetCodeMastaValue(DB, "PG_TITLE", Me.GetType.ToString)
            'End Using


        Finally

        End Try
    End Sub

#End Region


End Class