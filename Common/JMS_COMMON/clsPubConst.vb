''' <summary>
''' 定数
''' </summary>
Public NotInheritable Class ClsPubConst

#Region "WindowsAPI WindowMessage"

    'UNDONE: 小山さんへ依頼 下記URLのウィンドウメッセージの定数を作成
    'ウィンドウ、マウス操作、キー操作、コントロールメニュー
    'http://note.phyllo.net/?eid=1106271

    Public Enum ENM_WND_MESSAGE
#Region "   ウィンドウ"
        ''' <summary>
        ''' ウィンドウの描画時
        ''' </summary>
        WM_PAINT = &HF

#End Region
#Region "   マウス操作・カーソル"

        ''' <summary>
        ''' マウス左クリック開始時
        ''' </summary>
        WM_LBUTTONDOWN = &H201

        ''' <summary>
        ''' マウス右クリック開始時
        ''' </summary>
        WM_RBUTTONDOWN = &H204

        ''' <summary>
        ''' 縦マウスホイール時
        ''' </summary>
        WM_MOUSEWHEEL = &H20A

#End Region
#Region "   キー操作"

        ''' <summary>
        ''' キー押下開始時
        ''' </summary>
        WM_KEYDOWN = &H100

        ''' <summary>
        ''' 仮想キーコード(UTF-16)を文字変換時
        ''' </summary>
        WM_CHAR = &H102

#End Region
#Region "   コントロール・メニュー"
        ''' <summary>
        ''' テキストボックス等で「切り取り」の実行時
        ''' </summary>
        WM_CUT = &H300

        ''' <summary>
        ''' テキストボックス等で「コピー」の実行時
        ''' </summary>
        WM_COPY = &H301

        ''' <summary>
        ''' テキストボックス等で「貼り付け」の実行時
        ''' </summary>
        WM_PASTE = &H302

        ''' <summary>
        ''' テキストボックス等で「削除」の実行時
        ''' </summary>
        WM_CLEAR = &H303

#End Region
    End Enum


#End Region


End Class
