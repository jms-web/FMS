Imports System.ComponentModel


Public Class RibbonShapeButton
    Inherits Button

#Region "　コンストラクタ　"
    Public Sub New()
        Call InitializeComponent()

    End Sub

    Private Sub InitializeComponent()
        Me.SuspendLayout()
        Me.ResumeLayout(False)

    End Sub

    'http://uchukamen.com/Programming1/StarButton/#SEC8

    'UNDONE: リボン型 overrides DrawButton

#End Region

End Class

