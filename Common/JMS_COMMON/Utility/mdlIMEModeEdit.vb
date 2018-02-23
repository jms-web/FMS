Module mdlIMEMODE
    '=========================================================================
    '   み～くんパパのAPIサンプル
    '-------------------------------------------------------------------------
    '   [IME関連] IME入力・変換モードの設定／取得
    '-------------------------------------------------------------------------
    '   [作成日]    2000年05月15日
    '-------------------------------------------------------------------------
    '   [動作確認環境]
    '       Windows 98 Second Edition
    '       Windows NT Workstation SP6a
    '       Windows 2000 Professional
    '       ※ すべて VB 6.0 SP3 で実行 (IME2000で確認)
    '-------------------------------------------------------------------------
    '   [NOTE]
    '       恐らくIME98、IME97でも動作可能かと思われます。
    '       (環境が無いので確認はしていません。)
    '=========================================================================

    '// 入力モード
    Public Const IME_CMODE_NATIVE As Int32 = &H1
    Public Const IME_CMODE_CHINESE As Int32 = IME_CMODE_NATIVE
    Public Const IME_CMODE_HANGEUL As Int32 = IME_CMODE_NATIVE
    Public Const IME_CMODE_HANGUL As Int32 = IME_CMODE_NATIVE

    ''' <summary>
    ''' IME 入力モード
    ''' </summary>
    ''' <remarks></remarks>
    <Flags>
    Public Enum IME_CMODE_ENUM
        IME_CMODE_ALPHANUMERIC = &H0
        IME_CMODE_JAPANESE = IME_CMODE_NATIVE
        IME_CMODE_KATAKANA = &H2               '// カタカナ(IME_CMODE_NATIVEの指定時のみ有効)
        IME_CMODE_LANGUAGE = &H3
        IME_CMODE_FULLSHAPE = &H8              '// 全角
        IME_CMODE_ROMAN = &H10                 '// ローマ字入力
        IME_CMODE_CHARCODE = &H20
        IME_CMODE_HANJACONVERT = &H40
        IME_CMODE_SOFTKBD = &H80               '// ソフトキーボード
        IME_CMODE_NOCONVERSION = &H100
        IME_CMODE_EUDC = &H200
        IME_CMODE_SYMBOL = &H400
        IME_CMODE_FIXED = &H800
    End Enum

    ''' <summary>
    ''' IME 変換モード
    ''' </summary>
    ''' <remarks></remarks>
    <Flags>
    Public Enum IME_SMODE_ENUM
        IME_SMODE_NONE = &H0                   '// 無変換
        IME_SMODE_PLAURALCLAUSE = &H1          '// 人名／地名
        IME_SMODE_SINGLECONVERT = &H2          '// シングルキャラクタモード(?)
        IME_SMODE_AUTOMATIC = &H4              '// 自動
        IME_SMODE_PHRASEPREDICT = &H8          '// 次のフレーズを予測(?)
        IME_SMODE_CONVERSATION = &H10          '// 話し言葉優先
    End Enum

    '// IME クラスの既定のウィンドウハンドルを取得
    Public Declare Function ImmGetDefaultIMEWnd Lib "Imm32.dll" (ByVal hwnd As Integer) As Integer

    '// 指定されたウィンドウに関連付けられている入力コンテキストを取得
    Public Declare Function ImmGetContext Lib "Imm32.dll" (ByVal hwnd As Integer) As Integer

    '// 入力コンテキストを解放し、コンテキスト内の関連メモリのロックを解除 (ImmGetContextを実行後は必ず起動)
    Public Declare Function ImmReleaseContext Lib "Imm32.dll" (ByVal hwnd As Integer, ByVal hIMC As Integer) As Integer

    '// IMEの入力・変換モードを設定
    Public Declare Function ImmSetConversionStatus Lib "Imm32.dll" (ByVal hIMC As Integer, ByVal fdwConversion As IME_CMODE_ENUM, ByVal fdwSentence As IME_SMODE_ENUM) As Integer

    '// IMEの入力・変換モードを取得
    Public Declare Function ImmGetConversionStatus Lib "Imm32.dll" (ByVal hIMC As Integer, lpfdwConversion As IME_CMODE_ENUM, lpfdwSentence As IME_SMODE_ENUM) As Integer

    '==============================================================================
    '   IMEの入力・変換モードを設定する
    '------------------------------------------------------------------------------
    '   引　数  hwnd            --  対象ウィンドウのハンドル
    '           lngConversion   --  入力モード
    '           lngSentence     --  変換モード
    '==============================================================================
    Public Function SetIMEConversionStatus(ByVal hwnd As Integer, ByVal enmConversion As IME_CMODE_ENUM, ByVal enmSentence As IME_SMODE_ENUM) As Integer

        Dim hwndIME As Long
        Dim hIMC As Long

        Try
            '-- IMEのデフォルトウィンドウのハンドルを取得
            hwndIME = ImmGetDefaultIMEWnd(hwnd)

            If hwndIME Then
                '-- 入力コンテキストの取得
                hIMC = ImmGetContext(hwndIME)

                If hIMC Then
                    '-- 入力・変換モードの設定
                    Return ImmSetConversionStatus(hIMC, enmConversion, enmSentence)
                End If
            End If

            Return -1

        Catch ex As Exception
            EM.ErrorSyori(ex)
            Return -1
        Finally
            '-- コンテキストの開放
            ImmReleaseContext(hwndIME, hIMC)
        End Try

    End Function

    '==============================================================================
    '   IMEの入力・変換モードを取得する
    '------------------------------------------------------------------------------
    '   引　数  hwnd            --  対象ウィンドウのハンドル
    '           lngConversion   --  入力モード
    '           lngSentence     --  変換モード
    '==============================================================================
    Public Function GetIMEConversionStatus(ByVal hwnd As Integer, enmConversion As IME_CMODE_ENUM, enmSentence As IME_SMODE_ENUM) As Integer

        Dim hwndIME As Integer
        Dim hIMC As Integer

        Try
            '-- IMEのデフォルトウィンドウのハンドルを取得
            hwndIME = ImmGetDefaultIMEWnd(hwnd)

            If hwndIME Then
                '-- 入力コンテキストの取得
                hIMC = ImmGetContext(hwndIME)

                If hIMC Then
                    '-- 入力・変換モードの取得
                    Return ImmGetConversionStatus(hIMC, enmConversion, enmSentence)
                End If
            End If

            Return -1

        Catch ex As Exception
            EM.ErrorSyori(ex)
            Return -1
        Finally
            '-- コンテキストの開放
            ImmReleaseContext(hwndIME, hIMC)
        End Try


    End Function
End Module
