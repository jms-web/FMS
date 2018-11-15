Imports System.ComponentModel

'' カスタム列ヘッダクラスを使用するカスタム列クラス
Public Class DataGridViewCustomCheckBoxHeaderColumn
    Inherits DataGridViewCheckBoxColumn

    Public Sub New()
        MyBase.DefaultHeaderCellType = GetType(_DataGridViewCustomCheckBoxHeaderCell)

        '' ソート方向を示すグリフ表示をさせないためにソート不可（コード上からのソートのみ）に設定
        Me.SortMode = DataGridViewColumnSortMode.NotSortable
    End Sub

    <EditorBrowsable(EditorBrowsableState.Never), Browsable(False),
        DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)>
    Public Shadows ReadOnly Property DefaultHeaderCellType() As Type
        Get
            Return GetType(_DataGridViewCustomCheckBoxHeaderCell)
        End Get
    End Property

End Class

