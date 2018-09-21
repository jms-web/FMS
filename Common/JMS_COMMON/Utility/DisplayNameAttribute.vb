Imports System
Imports System.Linq
Imports System.Linq.Expressions
Imports System.Reflection
Imports Base = System.ComponentModel.DisplayNameAttribute
Imports This = JMS_COMMON.ModelEx.DisplayNameAttribute

Namespace ModelEx
    <AttributeUsage(AttributeTargets.All, AllowMultiple:=False)>
    Public NotInheritable Class DisplayNameAttribute
        Inherits Base

        Public Sub New(name As String)
            MyBase.New(name)
        End Sub

        ''--- ほとんどコレでカバー
        Public Shared Function GetAttribute(ByVal provider As ICustomAttributeProvider) As String

            If provider Is Nothing Then
                Throw New ArgumentNullException(NameOf(provider))
            Else
                Dim Attributes As This() =
                    provider.GetCustomAttributes(GetType(This), False)

                If Attributes IsNot Nothing AndAlso Attributes.Any() Then
                    Return Attributes(0).DisplayNameValue
                Else
                    Return Nothing
                End If

            End If
        End Function

        '--- enumは特別
        Public Shared Function GetAttribute(ByVal value As [Enum]) As String
            Dim Type As Type = value.GetType()
            Dim Name As String = [Enum].GetName(Type, value)
            Dim info As FieldInfo = Type.GetField(Name)
            Return This.GetAttribute(info)
        End Function

        '--- フィールド/プロパティ/戻り値のあるメソッド用
        Public Shared Function GetAttribute(Of T)(ByVal expression As Expression(Of T)) As String
            Dim strRET As String
            strRET = This.GetAttribute(DirectCast(expression, LambdaExpression))
            If strRET.IsNullOrEmpty = True Then
                strRET = This.GetAttribute(GetType(T))  '--- エラーのときは型情報でリトライ
            End If

            Return strRET
        End Function


        '--- 戻り値のないメソッド/イベント用
        Public Shared Function GetAttribute(ByVal expression As Expression(Of Action)) As String

            Return This.GetAttribute(DirectCast(expression, LambdaExpression))
        End Function

        '--- まとめて処理しちゃえ作戦
        Private Shared Function GetAttribute(ByVal expression As LambdaExpression) As String

            If expression Is Nothing Then
                Throw New ArgumentNullException(NameOf(expression))
            Else
                Dim body As Object = expression.Body
                Dim info As MemberInfo
                Select Case True
                    Case TypeOf body Is MemberExpression
                        info = DirectCast(body, MemberExpression).Member
                    Case TypeOf body Is MethodCallExpression
                        info = DirectCast(body, MethodCallExpression).Method
                    Case Else
                        info = Nothing
                End Select

                Return IIf(info IsNot Nothing, This.GetAttribute(info), Nothing)
            End If

        End Function
    End Class

End Namespace

