Public Class Navigators(Of T As Control)
    Private list As New Generic.Dictionary(Of T, Navigator)
    Public Sub Add(ByVal target As T, ByVal up As T, ByVal right As T, ByVal down As T, ByVal left As T)
        'list.Add(New Navigator(target, up, right, down, left))
        list.Add(target, New Navigator(Me, target, up, right, down, left))
    End Sub

    Private Class Navigator
        Private owner As Navigators(Of T)
        Private self As T
        Private up, right, down, left As T
        Private Sub PreviewKeyDown(ByVal sender As Object, ByVal e As PreviewKeyDownEventArgs)
            Dim nextNavi As Navigator
            Dim ctrl As T

            Select Case e.KeyCode
                Case Keys.Up
                    ctrl = up
                Case Keys.Right
                    ctrl = right
                Case Keys.Down
                    ctrl = down
                Case Keys.Left
                    ctrl = left
                Case Else
                    e.IsInputKey = False
                    Exit Sub
            End Select

            If ctrl.Enabled = True Then
                ctrl.Focus()
                e.IsInputKey = True
            Else
                nextNavi = owner.list(ctrl)
                Call nextNavi.PreviewKeyDown(ctrl, e)
            End If
        End Sub

        Public Sub New(ByRef list As Navigators(Of T), ByVal target As T, ByVal up As T, ByVal right As T, ByVal down As T, ByVal left As T)
            Me.owner = list
            Me.self = target
#If VBC_VER < 9 Then
　　　　Me.up = IIf(IsNothing(up), target, up)
　　　　Me.right = IIf(IsNothing(right), target, right)
　　　　Me.down = IIf(IsNothing(down), target, down)
　　　　Me.left = IIf(IsNothing(left), target, left)
#Else
            Me.up = If(up, target)
            Me.right = If(right, target)
            Me.down = If(down, target)
            Me.left = If(left, target)
#End If
            AddHandler target.PreviewKeyDown, AddressOf PreviewKeyDown
        End Sub
    End Class
End Class
