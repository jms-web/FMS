Imports System.ComponentModel


Public Class RibbonShapeRadioButton
    Inherits RadioButton

#Region "　コンストラクタ　"
    Public Sub New()
        Call InitializeComponent()

    End Sub

    Private Sub InitializeComponent()
        Me.SuspendLayout()
        Me.ResumeLayout(False)

    End Sub

    Protected Overrides Sub OnCheckedChanged(e As EventArgs)

        If Me.Checked Then
            Me.BackColor = Color.FromArgb(0, 140, 255) 'Color.DodgerBlue
            Me.ForeColor = Color.White
        Else
            Me.BackColor = Color.Transparent
            Me.ForeColor = Color.Black
        End If

        MyBase.OnCheckedChanged(e)
    End Sub

    'http://uchukamen.com/Programming1/StarButton/#SEC8

    'UNDONE: リボン型 overrides DrawButton

#End Region

End Class

