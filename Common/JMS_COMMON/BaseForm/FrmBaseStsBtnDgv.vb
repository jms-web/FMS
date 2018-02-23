Imports JMS_COMMON.ClsPubMethod

''' <summary>
''' DataGridViewコントロールは、アクセス修飾子:Publicで定義しても継承先でプロパティ参照しか出来るため、
''' コントロール本体は継承先に実装し、共通処理・イベントのみこのフォームのものを参照する
''' </summary>
Public Class FrmBaseStsBtnDgv

#Region "変数・定数"
    'DATAGRIDVIEW偶数行の背景色
    Protected clrRowEvenColor As Color = Color.White
    'DATAGRIDVIEW奇数行の背景色
    Protected clrRowOddColor As Color = Color.Bisque  'PaleGreen
    'DATAGRIDVIEW選択行の背景色
    Protected clrRowEnterColor As Color = Color.Cyan
    'DATAGRIDVIEW削除済み行の文字色
    Protected clrDeletedRowForeColor As Color = Color.FromArgb(74, 74, 74)
    'DATAGRIDVIEW削除済み行の背景色
    Protected clrDeletedRowBackColor As Color = Color.FromArgb(200, 200, 200)
    'DATAGRIDVIEW編集無効行の背景色
    Protected clrUnavailableRowBackColor As Color = Color.FromArgb(200, 200, 200)
    'DATAGRIDVIEW編集可能な選択セルの背景色
    Protected clrCanEditCellBackColor As Color = Color.Gold
    'DATAGRIDVIEW編集済みセルの文字色
    Protected clrEditedCellForeColor As Color = Color.Red


    'グリッドデータの選択行を記録
    Public intDgvCurrentRow As Integer = 0

#End Region

#Region "プロパティ"

#End Region

#Region "コンストラクタ"
    ''' <summary>
    ''' コンストラクタ
    ''' </summary>
    ''' <remarks>コンストラクタ</remarks>
    Public Sub New()

        ' この呼び出しはデザイナーで必要です。
        InitializeComponent()
    End Sub
#End Region

#Region "FORMイベント"
    Private Sub Frm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        If Me.DesignMode = False Then
            lblRecordCount.BorderStyle = BorderStyle.None
        End If
    End Sub

    Overrides Sub FrmBaseStsBtn_Resize(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Resize
        If Me.Visible = False Then Exit Sub

        If Me.DesignMode = True Then Exit Sub

        ''===================================
        ''   ボタン位置、サイズ設定
        ''===================================
        Call SetButtonSize(Me.Width, cmdFunc)

        MyBase.FrmBaseStsBtn_Resize(Me, e)

    End Sub
#End Region

#Region "DATAGRIDVIEW関連"

    ''' <summary>
    ''' DATAGRIDVIEW初期設定
    ''' </summary>
    ''' <param name="dgv">継承先フォームのDataGridView</param>
    ''' <returns></returns>
    Protected Function FunInitializeDataGridView(ByVal dgv As DataGridView) As Boolean
        Try

            '規定のコントロール設定
            With dgv
                'リサイズ
                .Anchor = AnchorStyles.Top Or AnchorStyles.Bottom Or AnchorStyles.Left Or AnchorStyles.Right
                '直接編集MODE
                .ReadOnly = True
                '行ヘッダ表示
                .RowHeadersVisible = False
                'ユーザーの行幅変更
                .AllowUserToResizeRows = False
                'ユーザーの列幅変更
                '.AllowUserToResizeColumns = False
                '最終行にデータ入力行表示
                .AllowUserToAddRows = False
                '複数セル選択
                .MultiSelect = False
                'TABでフォーカス移動
                .StandardTab = True
                'FONT
                .Font = New Font("Meiryo UI", 9, FontStyle.Bold, GraphicsUnit.Point, CType(128, Byte))
                '列ヘッダ高さ
                .ColumnHeadersHeight = 38
                .ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing
                '追加される行の高さ
                .RowTemplate.Height = 26
                '列ヘッダTEXT寄せ
                .ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
                'セルTEXT寄せ
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
                '奇数行背景色
                .AlternatingRowsDefaultCellStyle.BackColor = clrRowOddColor
                '偶数行背景色
                .RowsDefaultCellStyle.BackColor = clrRowEvenColor
                '選択セル背景色
                .DefaultCellStyle.SelectionBackColor = clrRowEnterColor
                '選択セル前景色
                .DefaultCellStyle.SelectionForeColor = Color.Black
                '一行選択
                .MultiSelect = False
                .SelectionMode = DataGridViewSelectionMode.FullRowSelect
                '編集開始方法
                .EditMode = DataGridViewEditMode.EditOnKeystroke
                '行をDELETEキーで削除
                .AllowUserToDeleteRows = False
            End With

            AddHandler dgv.SelectionChanged, AddressOf dgvDATA_SelectionChanged
            'AddHandler dgv.CellPainting, AddressOf dgvDATA_CellPainting

            Return True

        Catch ex As Exception
            EM.ErrorSyori(ex, False, conblnNonMsg)
            Return False
        End Try
    End Function

    '選択行変更時イベント
    Protected Sub dgvDATA_SelectionChanged(sender As Object, e As System.EventArgs)
        Dim dgv As DataGridView = DirectCast(sender, DataGridView)
        If dgv.CurrentCell IsNot Nothing Then
            intDgvCurrentRow = dgv.CurrentCell.RowIndex
        End If
    End Sub

    'セル描画時イベント
    Protected Sub dgvDATA_CellPainting(sender As System.Object, e As System.Windows.Forms.DataGridViewCellPaintingEventArgs) 'Handles dgvDATA.CellPainting
        Dim blnSelected As Boolean
        Dim strText As String
        Dim fcolor As Color
        'Dim bcolor As Color
        Dim flags As TextFormatFlags

        Try

            '-----固有設定
            'Dim dgv As DataGridView = DirectCast(sender, DataGridView)
            'Dim dgvCell As DataGridViewCell = DirectCast(dgv.CurrentCell, DataGridViewCell)
            'If TypeOf dgvCell Is DataGridViewCheckBoxCell Then
            '    Exit Sub
            'End If
            '-----固有設定


            If e.RowIndex >= 0 Then
                'セル選択判定
                If (e.PaintParts And DataGridViewPaintParts.SelectionBackground) = DataGridViewPaintParts.SelectionBackground AndAlso
                    (e.State And DataGridViewElementStates.Selected) = DataGridViewElementStates.Selected Then
                    'If (e.State & DataGridViewElementStates.Selected) <> DataGridViewElementStates.None Then

                    blnSelected = True
                End If

                'セル背景の描画
                e.PaintBackground(e.ClipBounds, blnSelected)

                '描画するテキスト
                If e.Value IsNot Nothing AndAlso e.Value.ToString <> "" Then
                    If e.CellStyle.Format <> "" Then

                        '書式付のセルの場合
                        If IsNumeric(e.Value) = True Then
                            strText = Val(e.Value).ToString(e.CellStyle.Format)
                        Else
                            strText = e.Value.ToString(e.CellStyle.Format)
                        End If

                    Else
                        '書式なしのセルの場合
                        strText = e.Value.ToString
                    End If

                Else
                    strText = ""
                End If

                'テキストの色
                If blnSelected = True Then
                    fcolor = e.CellStyle.SelectionForeColor
                    'bcolor = e.CellStyle.SelectionBackColor
                Else
                    fcolor = e.CellStyle.ForeColor
                    'bcolor = e.CellStyle.BackColor
                End If



                'テキストの配置
                Select Case e.CellStyle.Alignment
                    Case 16  'MiddleLeft
                        flags = TextFormatFlags.Left Or TextFormatFlags.VerticalCenter Or TextFormatFlags.SingleLine Or TextFormatFlags.PreserveGraphicsClipping
                    Case 32  'MiddleCenter
                        flags = TextFormatFlags.HorizontalCenter Or TextFormatFlags.VerticalCenter Or TextFormatFlags.SingleLine Or TextFormatFlags.PreserveGraphicsClipping
                    Case 64  'MiddleRight
                        flags = TextFormatFlags.Right Or TextFormatFlags.VerticalCenter Or TextFormatFlags.SingleLine Or TextFormatFlags.PreserveGraphicsClipping
                    Case Else
                        flags = TextFormatFlags.Default Or TextFormatFlags.SingleLine Or TextFormatFlags.PreserveGraphicsClipping
                End Select

                '文字列の描画
                TextRenderer.DrawText(e.Graphics, strText, e.CellStyle.Font, e.CellBounds, fcolor, flags:=flags)

                '描画処理を自分で行った場合はTrue
                e.Handled = True

            End If

        Catch ex As Exception
            EM.ErrorSyori(ex, False, conblnNonMsg)
        End Try
    End Sub

#End Region

End Class