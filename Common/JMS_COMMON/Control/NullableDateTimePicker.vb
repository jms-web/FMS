' This software is distributed under the license of NYSL.
' ( http://www.kmonos.net/nysl/ )

''' <summary>
''' NULL値が設定可能なDateTimePicker
''' </summary>
Public Class NullableDateTimePicker
    Inherits DateTimePicker

    ''' <summary>NULL値の表示用フォーマット</summary>
    Private Const NULL_FORMAT As String = " "

    ''' <summary>コンポーネントの入力値がNULL値の場合True</summary>
    Private _null As Boolean

    ''' <summary>表示用フォーマット</summary>
    Private _customFormat As String

    ''' <summary>
    ''' </summary>
    Public Sub New()

        _customFormat = MyBase.CustomFormat
        _null = True
        Me.Format = DateTimePickerFormat.Custom
        Me.Value = Nothing

    End Sub

    Protected Overrides Sub OnPreviewKeyDown(e As System.Windows.Forms.PreviewKeyDownEventArgs)

        Select Case e.KeyCode

            Case Keys.Delete
                ' DELETEで入力値のクリア
                Me.Value = Nothing
                _null = True

            Case Keys.D0 To Keys.D9,
                Keys.NumPad0 To Keys.NumPad9,
                Keys.Up, Keys.Down
                ' 0～9、上下矢印キーの入力で日付入力状態
                If _null Then
                    MyBase.CustomFormat = _customFormat
                    _null = False
                End If

        End Select

        MyBase.OnPreviewKeyDown(e)

    End Sub

    Protected Overrides Sub OnCloseUp(e As EventArgs)

        ' ダイアログを閉じると、値が設定されてしまうので、
        ' その値が表示されるよう、退避していたフォーマットを
        ' セットし、値が表示されるようにする
        MyBase.CustomFormat = _customFormat
        _null = False

        MyBase.OnCloseUp(e)

    End Sub


    ''' <summary>
    ''' コントロールに設定されている値はNULL値か?
    ''' </summary>
    ''' <returns></returns>
    Public Function IsNull() As Boolean
        Return _null
    End Function

#Region "プロパティ"

    ''' <summary>
    ''' 
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Shadows Property Value As Nullable(Of Date)
        Get
            If _null Then
                Return Nothing
            End If
            Return MyBase.Value
        End Get

        Set(value As Nullable(Of Date))
            If value Is Nothing Then
                ' Meで設定すると退避していた値を壊してしまうのでMyBaseで設定
                MyBase.CustomFormat = NULL_FORMAT
                _null = True
            Else
                MyBase.Value = value
                Me.CustomFormat = _customFormat
                _null = False
            End If
        End Set
    End Property

    ''' <summary>
    ''' 
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Overrides Property Text As String
        Get
            If _null Then
                Return ""
            End If
            Return MyBase.Text
        End Get

        Set(value As String)

            Try

                MyBase.Text = value
                If String.IsNullOrEmpty(Trim(value)) Then
                    ' Meで設定すると退避していた値を壊してしまうのでMyBaseで設定
                    MyBase.CustomFormat = NULL_FORMAT
                    _null = True
                Else
                    Me.CustomFormat = _customFormat
                    _null = False
                End If

            Catch
                ' 例外(System.FormatExceptionなど)が発生した場合はNULL値扱い
                MyBase.Text = ""
                ' Meで設定すると退避していた値を壊してしまうのでMyBaseで設定
                MyBase.CustomFormat = NULL_FORMAT
                _null = True
            End Try

        End Set
    End Property

    ''' <summary>
    ''' 
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Shadows Property CustomFormat As String
        Get
            Return _customFormat
        End Get
        Set(value As String)
            ' フォーマットを退避して保持
            _customFormat = value
            ' 親にフォーマットを設定
            MyBase.CustomFormat = value
            ' フォーマットに何らかの文字が入っていればnull状態にはならないはず
            If Not String.IsNullOrEmpty(Trim(value)) Then
                _null = False
            End If
        End Set
    End Property

#End Region

End Class
