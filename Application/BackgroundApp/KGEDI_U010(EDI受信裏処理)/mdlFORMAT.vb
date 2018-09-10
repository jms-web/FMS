
Module mdlFORMAT

#Region "�����`�F�b�N"
    '�����`�F�b�N
    Public Function funNUMCHECK(ByVal strDATA As String, ByVal intSEISUKETA As Integer, ByVal intSYOSUKETA As Integer) As Integer
        Dim lngBUFF As Long
        Dim intCNT As Integer
        Dim strBUFF As String

        Try
            '-----������`�F�b�N
            For intCNT = 0 To strDATA.Length - 1
                strBUFF = strDATA.Substring(intCNT, 1)
                If InStr("1234567890.-", strBUFF) = 0 Then
                    Return 1
                End If
            Next

            '-----���l���`�F�b�N
            If IsNumeric(strDATA) = False Then
                Return 1
            End If


            '-----���������擾
            If Val(strDATA) >= 0 Then '������
                lngBUFF = System.Math.Truncate(Val(strDATA))
            ElseIf Val(strDATA) < 0 Then '������
                lngBUFF = System.Math.Truncate(Val(strDATA) * -1)
            End If


            '-----���������`�F�b�N
            If CStr(lngBUFF).Length > intSEISUKETA Then
                Return 1
            End If

            '-----���������`�F�b�N
            If Val(strDATA) >= 0 Then '������
                If strDATA.Length - CStr(lngBUFF).Length > intSYOSUKETA + 1 Then
                    Return 1
                End If
            ElseIf Val(strDATA) < 0 Then '������
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

#Region "�w�肵�����x�̐��l�ɐ؂�̂�"
    ''' ------------------------------------------------------------------------
    ''' <summary>
    '''     �w�肵�����x�̐��l�ɐ؂�̂Ă��܂��B</summary>
    ''' <param name="dValue">
    '''     �ۂߑΏۂ̔{���x���������_���B</param>
    ''' <param name="iDigits">
    '''     �߂�l�̗L�������̐��x�B</param>
    ''' <returns>
    '''     iDigits �ɓ��������x�̐��l�ɐ؂�̂Ă�ꂽ���l�B</returns>
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

#Region "�w�肵�����x�̐��l�ɐ؂�グ"
    ''' ------------------------------------------------------------------------
    ''' <summary>
    '''     �w�肵�����x�̐��l�ɐ؂�グ���܂��B</summary>
    ''' <param name="dValue">
    '''     �ۂߑΏۂ̔{���x���������_���B</param>
    ''' <param name="iDigits">
    '''     �߂�l�̗L�������̐��x�B</param>
    ''' <returns>
    '''     iDigits �ɓ��������x�̐��l�ɐ؂�グ��ꂽ���l�B</returns>
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

#Region "�w�肵�����x�̐��l�Ɏl�̌ܓ� JIS�ۂ�"
    ''' ------------------------------------------------------------------------
    ''' <summary>
    '''     �w�肵�����x�̐��l�Ɏl�̌ܓ����܂��B</summary>
    ''' <param name="dValue">
    '''     �ۂߑΏۂ̔{���x���������_���B</param>
    ''' <param name="iDigits">
    '''     �߂�l�̗L�������̐��x�B</param>
    ''' <returns>
    '''     iDigits �ɓ��������x�̐��l�Ɏl�̌ܓ����ꂽ���l�B</returns>
    ''' ------------------------------------------------------------------------
    Public Function ToHalfAdjust(ByVal dValue As Double, ByVal iDigits As Integer) As Double
        'JIS�ۂ�
        Return System.Math.Round(dValue, iDigits)
    End Function

#End Region

#Region "�w�肵�����x�̐��l�Ɏl�̌ܓ� !=JIS�ۂ�"
    '�l�̌ܓ�
    Public Function ToHalfAdjust_NOTJIS(ByVal dValue As Double, ByVal iDigits As Integer) As Double
        Dim dCoef As Double = System.Math.Pow(10, iDigits)

        If dValue > 0 Then
            Return System.Math.Floor((dValue * dCoef) + 0.5) / dCoef
        Else
            Return System.Math.Ceiling((dValue * dCoef) - 0.5) / dCoef
        End If
    End Function
#End Region


#Region "�L�������Ɋۂ߂�"
    '�L�������Ɋۂ߂�i�T���܂őΉ��j
    Public Function ToYuukouKeta(ByVal dValue As Double, ByVal iDigits As Integer) As Double
        Dim dblWORK As Double

        dblWORK = dValue

        If dblWORK < 1 Then
            dblWORK = ToHalfAdjust(dblWORK, iDigits) '�l�̌ܓ�
        ElseIf dblWORK < 10 Or iDigits = 1 Then
            dblWORK = ToHalfAdjust(dblWORK, iDigits - 1) '�l�̌ܓ�
        ElseIf dblWORK < 100 Or iDigits = 2 Then
            dblWORK = ToHalfAdjust(dblWORK, iDigits - 2) '�l�̌ܓ�
        ElseIf dblWORK < 1000 And iDigits = 3 Then
            dblWORK = ToHalfAdjust(dblWORK, iDigits - 3) '�l�̌ܓ�
        ElseIf dblWORK < 10000 And iDigits = 4 Then
            dblWORK = ToHalfAdjust(dblWORK, iDigits - 4) '�l�̌ܓ�
        ElseIf dblWORK < 100000 And iDigits = 5 Then
            dblWORK = ToHalfAdjust(dblWORK, iDigits - 5) '�l�̌ܓ�
        Else
            dblWORK = ToHalfAdjust(dblWORK, 0) '�l�̌ܓ�
        End If

        Return dblWORK
    End Function

#End Region

#Region "�P�d�̐����R��"
    ''' ------------------------------------------------------------------------
    ''' <summary>
    '''     �P�d�̐����R��</summary>
    ''' <param name="sDATA">
    '''     �ҏW�O�P�d</param>
    ''' <returns>
    '''     �����R�������P�d</returns>
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
                Case 1 'x.234��
                    If strBUFF.Substring(0, 1) = "0" Then '0.234��
                        strRET = strBUFF.Substring(0, 5) '0.123��

                    ElseIf strBUFF.Substring(0, 1) <> "0" Then '1.234��
                        strRET = strBUFF.Substring(0, 4) '1.23��
                    End If

                Case 2 '12.34��
                    strRET = strBUFF.Substring(0, 4) '12.3��

                Case 3 '123.4��
                    strRET = strBUFF.Substring(0, 3) '123��

                Case Else '123��
                    strRET = sDATA '123�̂܂�
            End Select

            Return strRET


        Catch ex As Exception
            EM.ErrorSyori(ex)
            Return sDATA
        End Try
    End Function

#End Region

#Region "�Q�̎����Ԃ̕��Z�o"
    ''' ------------------------------------------------------------------------
    ''' <summary>
    '''     �Q�̎����Ԃ̕��Z�o</summary>
    ''' <param name="sHM1">
    '''     �����P</param>
    ''' <param name="sHM2">
    '''     �����Q</param>
    ''' <returns>
    '''     ��</returns>
    ''' ------------------------------------------------------------------------
    Public Function funMINUTE(ByVal sHM1 As String, ByVal sHM2 As String) As Integer
        Dim dteBUFF1 As DateTime
        Dim dteBUFF2 As DateTime
        Dim strBUFF As String
        Dim intRET As Integer

        Try
            If sHM1 <= sHM2 Then '�钆24�����܂����ł��Ȃ���
                strBUFF = "2008/01/01 " & sHM1.Substring(0, 2) & ":" & sHM1.Substring(2, 2)
                dteBUFF1 = Date.Parse(strBUFF)

                strBUFF = "2008/01/01 " & sHM2.Substring(0, 2) & ":" & sHM2.Substring(2, 2)
                dteBUFF2 = Date.Parse(strBUFF)

            Else '�钆24�����܂�������
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

        Dim ret As String = ""          ' �؂�o����������
        Dim start As Integer = 0
        Dim sjis As System.Text.Encoding
        sjis = System.Text.Encoding.GetEncoding("Shift-JIS")
        Dim i As Integer = 0

        If startindex < 0 Then startindex = 0

        ' �J�n�ʒu���擾
        If startindex = 0 Then
            ' �擪���w�肳�ꂽ
            start = 0
        Else
            ' �擪�ȊO���w�肳�ꂽ
            Dim bytecnt As Integer = 0
            For i = 0 To value.Length - 1
                ' �擪����̃o�C�g�����擾
                Dim tmp As String = value.Substring(i, 1)
                bytecnt += sjis.GetByteCount(tmp)

                If bytecnt >= startindex Then
                    ' �擪����̃o�C�g�����J�n�ʒu�ȏ�ɂȂ镶���̎��̕������J�n�ʒu
                    start = i + 1
                    Exit For
                End If

            Next i
        End If

        ' ���肵���J�n�ʒu����1�������擾���A�w��o�C�g���𒴂���܂Ŏ擾
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

#Region "�S�p/���p��"
    '�S�p��/���p��/�o�C�g����߂�
    '   ���f�[�^
    '   Z:�S�p���AH:���p���AB�FBYTE��
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

#Region "���t�͈̓`�F�b�N"
    Public Function funDATESPAN(ByVal strYMD As String, Optional ByVal strNAME As String = "") As Integer

        Try
            If strNAME = "" Then
                strNAME = "���t"
            End If

            '10��(yyyy/MM/dd)�ȊO
            If strYMD.Replace(" ", "").Length <> 10 Then
                MsgBox(strNAME & "�� YYYY/MM/DD �`���œ��͂��Ă�������", MsgBoxStyle.Information)
                Return -1
            End If


            '�ߋ�15���ȏ�O
            If strYMD < System.DateTime.Now.AddDays(-15).ToString("yyyy/MM/dd") Then
                If MsgBox(strNAME & "�� �����ȏ�O �ł����A��낵���ł����H", MsgBoxStyle.YesNo + MsgBoxStyle.DefaultButton2 + MsgBoxStyle.Information) = MsgBoxResult.No Then
                    Return -1
                End If
            End If

            '�ߋ�365���ȏ�O
            If strYMD < System.DateTime.Now.AddDays(-365).ToString("yyyy/MM/dd") Then
                If MsgBox(strNAME & "�� �P�N�ȏ�O �ɂȂ�܂��A�{���ɂ�낵���ł����H", MsgBoxStyle.YesNo + MsgBoxStyle.DefaultButton2 + MsgBoxStyle.Information) = MsgBoxResult.No Then
                    Return -1
                End If
            End If

            '60���ȏ��
            If strYMD > System.DateTime.Now.AddDays(60).ToString("yyyy/MM/dd") Then
                If MsgBox(strNAME & "�� �Q�J���ȏ�� �ł����A��낵���ł����H", MsgBoxStyle.YesNo + MsgBoxStyle.DefaultButton2 + MsgBoxStyle.Information) = MsgBoxResult.No Then
                    Return -1
                End If
            End If

            '365���ȏ��
            If strYMD > System.DateTime.Now.AddDays(365).ToString("yyyy/MM/dd") Then
                If MsgBox(strNAME & "�� �P�N�ȏ�� �ɂȂ�܂��A�{���ɂ�낵���ł����H", MsgBoxStyle.YesNo + MsgBoxStyle.DefaultButton2 + MsgBoxStyle.Information) = MsgBoxResult.No Then
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

#Region "QR�؂�o��"
    Public Function funQRKANGET(ByVal strQR As String) As String
        Dim strRET As String

        Try
            strRET = ""


            '-----�����`�F�b�N
            If strQR.Length < 19 Then
                MsgBox("JAMAQR�ł͂���܂���", MsgBoxStyle.Information)
                Return strRET
            End If

            If strQR.Substring(0, 4) <> "JAMA" Then
                MsgBox("JAMAQR�ł͂���܂���", MsgBoxStyle.Information)
                Return strRET
            End If



            Dim lngKOMOKUSU As Long
            Dim lngKAISI As Long
            Dim intCNT As Integer
            Dim strIDBLOCK As String

            '���ڐ�
            lngKOMOKUSU = Val(strQR.Substring(16, 3))
            '�f�[�^�J�n�ʒu
            lngKAISI = 16 + 3 + lngKOMOKUSU * 5


            For intCNT = 0 To lngKOMOKUSU - 1
                strIDBLOCK = strQR.Substring(16 + 3 + intCNT * 5, 5)

                If strIDBLOCK.Substring(0, 3) = "104" Then '104:�P�O���i��
                    strRET = strQR.Substring(lngKAISI, Val(strIDBLOCK.Substring(3, 2)))
                    ' Mid$(iQR$(1), J%, Val(Right$(BUFF$, 2)))
                End If

                '�f�[�^�J�n�ʒu
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
