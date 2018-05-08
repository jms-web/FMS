Imports System.Globalization
Imports System.Windows.Data

Public Class BoolToStringConverter
    Implements IValueConverter

    Public Function Convert(value As Object, targetType As Type, parameter As Object, culture As CultureInfo) As Object Implements IValueConverter.Convert

        Dim bln As Boolean
        bln = Boolean.Parse(value.ToString)
        Return IIf(bln, "1", "0")

    End Function

    Public Function ConvertBack(value As Object, targetType As Type, parameter As Object, culture As CultureInfo) As Object Implements IValueConverter.ConvertBack
        Return Boolean.Parse(value.ToString)
    End Function

End Class
