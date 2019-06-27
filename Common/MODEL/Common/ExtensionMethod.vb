Imports System.Runtime.CompilerServices

Public Module ExtensionMethod
    ''' <summary>
    ''' 文字列中の特定文字を置換
    ''' </summary>
    ''' <param name="this"></param>
    ''' <returns></returns>
    <Extension()>
    Public Function EscapeLiteral(this As String) As String
        Dim strRET As String

        strRET = this.Replace("'", "''")

        Return strRET
    End Function
End Module