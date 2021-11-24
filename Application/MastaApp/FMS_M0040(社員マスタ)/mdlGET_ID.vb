Module mdlGET_ID
    Declare Function GetCardID Lib "OrangeEasyAPI.dll" (ByRef id As Byte, ByRef length As Integer) As Integer

    Private pub_strCARD_ID As String

    Enum ENM_GET_ID_STATUS
        _0_GET_ID_SUCCESS = 0
        _1_GET_ID_FAILURE = 1
        _2_GET_ID_SERVICE = 2
        _3_GET_ID_NO_READERS = 3
        _4_GET_ID_NO_CARD = 4
        _5_GET_ID_REMOVE_TIMEOUT = 5
        _6_GET_ID_REMOVE_READERS = 6
        _7_GET_ID_REMOVE_CARD = 7
        _8_GET_ID_CARD_TIMEOUT = 8
        _9_GET_ID_COMMAND_ERROR = 9
        _10_GET_ID_RELEASE_ERROR = 10
    End Enum

    Public Function FunGET_ID(ByVal blnErrDisp As Boolean) As String
        Try
            Dim id(10) As Byte
            Dim length As Integer
            Dim result As String
            Dim intRET As ENM_GET_ID_STATUS
            result = ""

            intRET = GetCardID(id(0), length)

            Select Case intRET
                Case ENM_GET_ID_STATUS._0_GET_ID_SUCCESS
                    '読取り成功時にICのIDを1バイトごと読み出します
                    Dim i As Integer
                    For i = 0 To (length - 1)
                        result += id(i).ToString("X2")
                    Next

                    pub_strCARD_ID = result
                    Return result

                Case ENM_GET_ID_STATUS._1_GET_ID_FAILURE
                    result = "読取りに失敗しました"
                Case ENM_GET_ID_STATUS._2_GET_ID_SERVICE
                    result = "スマートカードサービスが起動していません"
                Case ENM_GET_ID_STATUS._3_GET_ID_NO_READERS
                    result = "リーダーが接続されていません。接続してご利用ください。"
                Case ENM_GET_ID_STATUS._4_GET_ID_NO_CARD
                    result = "ICカードがかざされていません。または利用できないカードをかざしています。"
                Case ENM_GET_ID_STATUS._5_GET_ID_REMOVE_TIMEOUT
                    'result = "同じカードが100ms以上かざされたままになっています。"
                    'カードを置いたまま読取る運用のためエラーとしない
                    Dim i As Integer
                    For i = 0 To (length - 1)
                        result += id(i).ToString("X2")
                    Next

                    pub_strCARD_ID = result

                    Return pub_strCARD_ID
                Case ENM_GET_ID_STATUS._6_GET_ID_REMOVE_READERS
                    result = "リーダーの切断に失敗しました。"
                Case ENM_GET_ID_STATUS._7_GET_ID_REMOVE_CARD
                    result = "カードの切断に失敗しました。"
                Case ENM_GET_ID_STATUS._8_GET_ID_CARD_TIMEOUT
                    result = "カード接続待機時間1msを超えました。"
                Case ENM_GET_ID_STATUS._9_GET_ID_COMMAND_ERROR
                    result = "ICカードへのコマンドでエラーが発生しました。"
                Case ENM_GET_ID_STATUS._10_GET_ID_RELEASE_ERROR
                    result = "スマートカードサービスの開放に失敗しました。"
                Case Else
                    'UNDONE: argument exception
                    result = "読取りに失敗しました"
            End Select

            MessageBox.Show(result, "ICカード読取エラー", MessageBoxButtons.OK, MessageBoxIcon.Information)

            Return ""
        Catch ex As Exception
            MessageBox.Show(ex.Message)
            Return ""
        End Try
    End Function

End Module