Imports System.Collections.Generic

Public Class DatarowEqualityComparer
    Implements IComparer(Of DataRow)

    Public Shadows Function Equals(dr1 As DataRow, dr2 As DataRow) As Boolean
        Return dr1.Item(0).ToString = dr2.Item(0).ToString And dr1.Item(1).ToString = dr2.Item(1).ToString
    End Function

    Public Shadows Function GetHashCode(dr As DataRow) As Integer
        Dim hCode As String = dr.Item(0).ToString & "|" & dr.Item(1).ToString
        Return hCode.GetHashCode
    End Function

    Public Function Compare(x As DataRow, y As DataRow) As Integer Implements IComparer(Of DataRow).Compare
        'Return dr1.Item(0).ToString = dr2.Item(0).ToString And dr1.Item(1).ToString = dr2.Item(1).ToString
    End Function
End Class
