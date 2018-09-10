
Module mdlFORMAT

#Region "桁数チェック"
    '桁数チェック
    Public Function funNUMCHECK(ByVal strDATA As String, ByVal intSEISUKETA As Integer, ByVal intSYOSUKETA As Integer) As Integer
        Dim lngBUFF As Long
        Dim intCNT As Integer
        Dim strBUFF As String

        Try
            '-----文字列チェック
            For intCNT = 0 To strDATA.Length - 1
                strBUFF = strDATA.Substring(intCNT, 1)
                If InStr("1234567890.-", strBUFF) = 0 Then
                    Return 1
                End If
            Next

            '-----数値かチェック
            If IsNumeric(strDATA) = False Then
                Return 1
            End If


            '-----整数桁長取得
            If Val(strDATA) >= 0 Then '正数時
                lngBUFF = System.Math.Truncate(Val(strDATA))
            ElseIf Val(strDATA) < 0 Then '負数時
                lngBUFF = System.Math.Truncate(Val(strDATA) * -1)
            End If


            '-----整数桁長チェック
            If CStr(lngBUFF).Length > intSEISUKETA Then
                Return 1
            End If

            '-----少数桁長チェック
            If Val(strDATA) >= 0 Then '正数時
                If strDATA.Length - CStr(lngBUFF).Length > intSYOSUKETA + 1 Then
                    Return 1
                End If
            ElseIf Val(strDATA) < 0 Then '負数時
                If strDATA.Length - 1 - CStr(lngBUFF).Length > intSYOSUKETA + 1 Then
                    Return 1
                End If
            End If


            Return 0

        Catch ex As Exception
            EM.ErrorSyori(ex)
            Return -1
        End Try
    End Function

#End Region

#Region "指定した精度の数値に切り捨て"
    ''' ------------------------------------------------------------------------
    ''' <summary>
    '''     指定した精度の数値に切り捨てします。</summary>
    ''' <param name="dValue">
    '''     丸め対象の倍精度浮動小数点数。</param>
    ''' <param name="iDigits">
    '''     戻り値の有効桁数の精度。</param>
    ''' <returns>
    '''     iDigits に等しい精度の数値に切り捨てられた数値。</returns>
    ''' ------------------------------------------------------------------------
    Public Function ToRoundDown(ByVal dValue As Double, ByVal iDigits As Integer) As Double
        Dim dCoef As Double = System.Math.Pow(10, iDigits)

        If dValue > 0 Then
            Return System.Math.Floor(dValue * dCoef) / dCoef
        Else
            Return System.Math.Ceiling(dValue * dCoef) / dCoef
        End If
    End Function

#End Region

#Region "指定した精度の数値に切り上げ"
    ''' ------------------------------------------------------------------------
    ''' <summary>
    '''     指定した精度の数値に切り上げします。</summary>
    ''' <param name="dValue">
    '''     丸め対象の倍精度浮動小数点数。</param>
    ''' <param name="iDigits">
    '''     戻り値の有効桁数の精度。</param>
    ''' <returns>
    '''     iDigits に等しい精度の数値に切り上げられた数値。</returns>
    ''' ------------------------------------------------------------------------
    Public Function ToRoundUp(ByVal dValue As Double, ByVal iDigits As Integer) As Double
        Dim dCoef As Double = System.Math.Pow(10, iDigits)

        If dValue > 0 Then
            Return System.Math.Ceiling(dValue * dCoef) / dCoef
        Else
            Return System.Math.Floor(dValue * dCoef) / dCoef
        End If
    End Function

#End Region

#Region "指定した精度の数値に四捨五入 JIS丸め"
    ''' ------------------------------------------------------------------------
    ''' <summary>
    '''     指定した精度の数値に四捨五入します。</summary>
    ''' <param name="dValue">
    '''     丸め対象の倍精度浮動小数点数。</param>
    ''' <param name="iDigits">
    '''     戻り値の有効桁数の精度。</param>
    ''' <returns>
    '''     iDigits に等しい精度の数値に四捨五入された数値。</returns>
    ''' ------------------------------------------------------------------------
    Public Function ToHalfAdjust(ByVal dValue As Double, ByVal iDigits As Integer) As Double
        'JIS丸め
        Return System.Math.Round(dValue, iDigits)
    End Function

#End Region

#Region "指定した精度の数値に四捨五入 !=JIS丸め"
    '四捨五入
    Public Function ToHalfAdjust_NOTJIS(ByVal dValue As Double, ByVal iDigits As Integer) As Double
        Dim dCoef As Double = System.Math.Pow(10, iDigits)

        If dValue > 0 Then
            Return System.Math.Floor((dValue * dCoef) + 0.5) / dCoef
        Else
            Return System.Math.Ceiling((dValue * dCoef) - 0.5) / dCoef
        End If
    End Function
#End Region


#Region "有効桁数に丸める"
    '有効桁数に丸める（５桁まで対応）
    Public Function ToYuukouKeta(ByVal dValue As Double, ByVal iDigits As Integer) As Double
        Dim dblWORK As Double

        dblWORK = dValue

        If dblWORK < 1 Then
            dblWORK = ToHalfAdjust(dblWORK, iDigits) '四捨五入
        ElseIf dblWORK < 10 Or iDigits = 1 Then
            dblWORK = ToHalfAdjust(dblWORK, iDigits - 1) '四捨五入
        ElseIf dblWORK < 100 Or iDigits = 2 Then
            dblWORK = ToHalfAdjust(dblWORK, iDigits - 2) '四捨五入
        ElseIf dblWORK < 1000 And iDigits = 3 Then
            dblWORK = ToHalfAdjust(dblWORK, iDigits - 3) '四捨五入
        ElseIf dblWORK < 10000 And iDigits = 4 Then
            dblWORK = ToHalfAdjust(dblWORK, iDigits - 4) '四捨五入
        ElseIf dblWORK < 100000 And iDigits = 5 Then
            dblWORK = ToHalfAdjust(dblWORK, iDigits - 5) '四捨五入
        Else
            dblWORK = ToHalfAdjust(dblWORK, 0) '四捨五入
        End If

        Return dblWORK
    End Function

#End Region

#Region "単重の数字３つ化"
    ''' ------------------------------------------------------------------------
    ''' <summary>
    '''     単重の数字３つ化</summary>
    ''' <param name="sDATA">
    '''     編集前単重</param>
    ''' <returns>
    '''     数字３つ化した単重</returns>
    ''' ------------------------------------------------------------------------
    Public Function funTANJYU_FMT(ByVal sDATA As String) As String
        Dim strBUFF As String
        Dim intBUFF As Integer
        Dim strRET As String
        Dim decBUFF As Decimal

        Try
            strBUFF = Val(sDATA).ToString("0.000")
            intBUFF = strBUFF.IndexOf(".")

            'decBUFF = Decimal.Parse(sDATA)
            'strBUFF = decBUFF.ToString("0.00000")
            'intBUFF = strBUFF.IndexOf(".")


            Select Case intBUFF
                Case 1 'x.234時
                    If strBUFF.Substring(0, 1) = "0" Then '0.234時
                        strRET = strBUFF.Substring(0, 5) '0.123へ

                    ElseIf strBUFF.Substring(0, 1) <> "0" Then '1.234時
                        strRET = strBUFF.Substring(0, 4) '1.23へ
                    End If

                Case 2 '12.34時
                    strRET = strBUFF.Substring(0, 4) '12.3へ

                Case 3 '123.4時
                    strRET = strBUFF.Substring(0, 3) '123へ

                Case Else '123時
                    strRET = sDATA '123のまま
            End Select

            Return strRET


        Catch ex As Exception
            EM.ErrorSyori(ex)
            Return sDATA
        End Try
    End Function

#End Region

#Region "２つの時分間の分算出"
    ''' ------------------------------------------------------------------------
    ''' <summary>
    '''     ２つの時分間の分算出</summary>
    ''' <param name="sHM1">
    '''     時分１</param>
    ''' <param name="sHM2">
    '''     時分２</param>
    ''' <returns>
    '''     分</returns>
    ''' ------------------------------------------------------------------------
    Public Function funMINUTE(ByVal sHM1 As String, ByVal sHM2 As String) As Integer
        Dim dteBUFF1 As DateTime
        Dim dteBUFF2 As DateTime
        Dim strBUFF As String
        Dim intRET As Integer

        Try
            If sHM1 <= sHM2 Then '夜中24時をまたいでいない時
                strBUFF = "2008/01/01 " & sHM1.Substring(0, 2) & ":" & sHM1.Substring(2, 2)
                dteBUFF1 = Date.Parse(strBUFF)

                strBUFF = "2008/01/01 " & sHM2.Substring(0, 2) & ":" & sHM2.Substring(2, 2)
                dteBUFF2 = Date.Parse(strBUFF)

            Else '夜中24時をまたいだ時
                strBUFF = "2008/01/01 " & sHM1.Substring(0, 2) & ":" & sHM1.Substring(2, 2)
                dteBUFF1 = Date.Parse(strBUFF)

                strBUFF = "2008/01/02 " & sHM2.Substring(0, 2) & ":" & sHM2.Substring(2, 2)
                dteBUFF2 = Date.Parse(strBUFF)
            End If

            intRET = DateDiff(DateInterval.Minute, dteBUFF1, dteBUFF2)

        Catch ex As Exception
            Return 0
        End Try

        Return intRET
    End Function

#End Region

#Region "ByteSubstring"
    Public Function ByteSubstring(ByVal value As String, ByVal startindex As Integer, ByVal length As Integer) As String

        Dim ret As String = ""          ' 切り出した文字列
        Dim start As Integer = 0
        Dim sjis As System.Text.Encoding
        sjis = System.Text.Encoding.GetEncoding("Shift-JIS")
        Dim i As Integer = 0

        If startindex < 0 Then startindex = 0

        ' 開始位置を取得
        If startindex = 0 Then
            ' 先頭を指定された
            start = 0
        Else
            ' 先頭以外を指定された
            Dim bytecnt As Integer = 0
            For i = 0 To value.Length - 1
                ' 先頭からのバイト数を取得
                Dim tmp As String = value.Substring(i, 1)
                bytecnt += sjis.GetByteCount(tmp)

                If bytecnt >= startindex Then
                    ' 先頭からのバイト数が開始位置以上になる文字の次の文字が開始位置
                    start = i + 1
                    Exit For
                End If

            Next i
        End If

        ' 決定した開始位置から1文字ずつ取得し、指定バイト数を超えるまで取得
        For i = 0 To value.Length - 1
            If i >= start Then
                Dim temp As String = value.Substring(i, 1)
                If sjis.GetByteCount(ret & temp) <= length Then
                    ret &= temp
                End If
            End If
        Next i

        Return ret

    End Function

#End Region

#Region "全角/半角数"
    '全角数/半角数/バイト数を戻す
    '   元データ
    '   Z:全角数、H:半角数、B：BYTE数
    Public Function funZHCNT(ByVal strDATA As String, ByVal strMODE As String) As Integer
        Dim intStrLen As Integer
        Dim intStrByte As Integer
        Dim intHankaku As Integer
        Dim intZenkaku As Integer

        Try
            'strStr = TextBox1.Text
            ''System.Text.Encoding.GetEncoding("Shift_JIS")
            'sjisEnc = sjisEnc.GetEncoding("Shift_JIS")

            intStrByte = System.Text.Encoding.GetEncoding("Shift_JIS").GetByteCount(strDATA)
            intStrLen = strDATA.Length

            intHankaku = intStrLen * 2 - intStrByte
            intZenkaku = intStrLen - intHankaku

            If strMODE = "Z" Then
                Return intZenkaku

            ElseIf strMODE = "H" Then
                Return intHankaku

            ElseIf strMODE = "B" Then
                Return intZenkaku * 2 + intHankaku
            End If


        Catch ex As Exception
            EM.ErrorSyori(ex)
        Finally
        End Try
    End Function
#End Region

#Region "日付範囲チェック"
    Public Function funDATESPAN(ByVal strYMD As String, Optional ByVal strNAME As String = "") As Integer

        Try
            If strNAME = "" Then
                strNAME = "日付"
            End If

            '10桁(yyyy/MM/dd)以外
            If strYMD.Replace(" ", "").Length <> 10 Then
                MsgBox(strNAME & "は YYYY/MM/DD 形式で入力してください", MsgBoxStyle.Information)
                Return -1
            End If


            '過去15日以上前
            If strYMD < System.DateTime.Now.AddDays(-15).ToString("yyyy/MM/dd") Then
                If MsgBox(strNAME & "が 半月以上前 ですが、よろしいですか？", MsgBoxStyle.YesNo + MsgBoxStyle.DefaultButton2 + MsgBoxStyle.Information) = MsgBoxResult.No Then
                    Return -1
                End If
            End If

            '過去365日以上前
            If strYMD < System.DateTime.Now.AddDays(-365).ToString("yyyy/MM/dd") Then
                If MsgBox(strNAME & "が １年以上前 になります、本当によろしいですか？", MsgBoxStyle.YesNo + MsgBoxStyle.DefaultButton2 + MsgBoxStyle.Information) = MsgBoxResult.No Then
                    Return -1
                End If
            End If

            '60日以上先
            If strYMD > System.DateTime.Now.AddDays(60).ToString("yyyy/MM/dd") Then
                If MsgBox(strNAME & "が ２カ月以上先 ですが、よろしいですか？", MsgBoxStyle.YesNo + MsgBoxStyle.DefaultButton2 + MsgBoxStyle.Information) = MsgBoxResult.No Then
                    Return -1
                End If
            End If

            '365日以上先
            If strYMD > System.DateTime.Now.AddDays(365).ToString("yyyy/MM/dd") Then
                If MsgBox(strNAME & "が １年以上先 になります、本当によろしいですか？", MsgBoxStyle.YesNo + MsgBoxStyle.DefaultButton2 + MsgBoxStyle.Information) = MsgBoxResult.No Then
                    Return -1
                End If
            End If


            Return 0


        Catch ex As Exception
            EM.ErrorSyori(ex)
            Return -1
        Finally
        End Try
    End Function
#End Region

#Region "QR切り出し"
    Public Function funQRKANGET(ByVal strQR As String) As String
        Dim strRET As String

        Try
            strRET = ""


            '-----桁数チェック
            If strQR.Length < 19 Then
                MsgBox("JAMAQRではありません", MsgBoxStyle.Information)
                Return strRET
            End If

            If strQR.Substring(0, 4) <> "JAMA" Then
                MsgBox("JAMAQRではありません", MsgBoxStyle.Information)
                Return strRET
            End If



            Dim lngKOMOKUSU As Long
            Dim lngKAISI As Long
            Dim intCNT As Integer
            Dim strIDBLOCK As String

            '項目数
            lngKOMOKUSU = Val(strQR.Substring(16, 3))
            'データ開始位置
            lngKAISI = 16 + 3 + lngKOMOKUSU * 5


            For intCNT = 0 To lngKOMOKUSU - 1
                strIDBLOCK = strQR.Substring(16 + 3 + intCNT * 5, 5)

                If strIDBLOCK.Substring(0, 3) = "104" Then '104:１０桁品番
                    strRET = strQR.Substring(lngKAISI, Val(strIDBLOCK.Substring(3, 2)))
                    ' Mid$(iQR$(1), J%, Val(Right$(BUFF$, 2)))
                End If

                'データ開始位置
                lngKAISI = lngKAISI + Val(strIDBLOCK.Substring(3, 2))
            Next

            Return strRET


        Catch ex As Exception
            EM.ErrorSyori(ex)
            Return ""
        Finally
        End Try
    End Function
#End Region

End Module
