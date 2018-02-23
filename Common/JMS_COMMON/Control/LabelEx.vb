Imports System.ComponentModel


Public Class LabelEx
    Inherits Label

#Region "　コンストラクタ　"
    Public Sub New()
        Call InitializeComponent()
        Me.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.Font = New System.Drawing.Font("Meiryo UI", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.AutoSize = False
    End Sub

    Private Sub InitializeComponent()
        Me.SuspendLayout()
        Me.ResumeLayout(False)

    End Sub


#End Region

End Class

