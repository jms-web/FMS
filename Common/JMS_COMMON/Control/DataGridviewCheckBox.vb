'' カスタム列ヘッダセル
Public Class _DataGridViewCustomCheckBoxHeaderCell
    Inherits DataGridViewColumnHeaderCell

    Private _checkState As Boolean = True

    Protected Overrides Sub Paint(
        ByVal graphics As Graphics,
        ByVal clipBounds As Rectangle,
        ByVal cellBounds As Rectangle,
        ByVal rowIndex As Integer,
        ByVal cellState As DataGridViewElementStates,
        ByVal value As Object,
        ByVal formattedValue As Object,
        ByVal errorText As String,
        ByVal cellStyle As DataGridViewCellStyle,
        ByVal advancedBorderStyle As DataGridViewAdvancedBorderStyle,
        ByVal paintParts As DataGridViewPaintParts)

        '' 既存のヘッダーは背景や枠だけ描画すればいいので、テキストは空指定
        MyBase.Paint(graphics, clipBounds, cellBounds, rowIndex,
            cellState, String.Empty, String.Empty, String.Empty, cellStyle,
             advancedBorderStyle, paintParts)

        '' 文字描画の必要領域を求める
        Dim drawTextSize As SizeF
        drawTextSize = graphics.MeasureString(formattedValue, cellStyle.Font)

        '' チェックボックス本体の描画位置を求める
        Dim location As New Point
        location.X = cellBounds.X + (cellBounds.Width - drawTextSize.Width) / 2 - 6
        location.Y = cellBounds.Y + (cellBounds.Height - 12) / 2

        '' チェック状態からCheckBoxStateを求める
        Dim checkBoxState As VisualStyles.CheckBoxState
        checkBoxState = IIf(Me._checkState,
            VisualStyles.CheckBoxState.CheckedNormal, VisualStyles.CheckBoxState.UncheckedNormal)
        'Console.WriteLine("Paint: checkBoxState=" & checkBoxState.ToString())
        '' チェックボックスを描画
        System.Windows.Forms.CheckBoxRenderer.DrawCheckBox(
            graphics, location, cellBounds, formattedValue, cellStyle.Font, False, checkBoxState)
    End Sub

    Protected Overrides Sub OnClick(ByVal e As System.Windows.Forms.DataGridViewCellEventArgs)
        _checkState = _checkState Xor True
        'Console.WriteLine("_checkState=" & _checkState.ToString())
        MyBase.OnClick(e)
        Me.RaiseCheckBoxCheckedChanged(EventArgs.Empty)
        Me.DataGridView.InvalidateCell(Me)
    End Sub

    Protected Overrides Sub OnDoubleClick(ByVal e As System.Windows.Forms.DataGridViewCellEventArgs)
        _checkState = _checkState Xor True
        MyBase.OnDoubleClick(e)
        Me.RaiseCheckBoxCheckedChanged(EventArgs.Empty)
        Me.DataGridView.InvalidateCell(Me)
    End Sub

    Private Sub RaiseCheckBoxCheckedChanged(ByVal e As EventArgs)
        '' チェックボックスの状態(On/Off)が変化した時の処理は以下に記述
        '' サンプル
        'Console.WriteLine(String.Format("チェックボックスが[{0}]になりました。", IIf(Me._checkState, "On", "Off")))
    End Sub

    Public Property Checked() As Boolean
        Get
            Return _checkState
        End Get
        Set(ByVal value As Boolean)
            _checkState = value
        End Set
    End Property

End Class