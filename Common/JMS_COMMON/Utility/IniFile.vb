'*******************************************************************************
'* �h�m�h�t�@�C������p�N���X
'*******************************************************************************
'* �g�p��(����) * 
'*   Dim m_cIni As New IniFile(�t�@�C����)
'*  �擾
'*   m_cIni.GetIniString(�Z�N�V������, �L�[��, �擾���s���̖߂�l[�ȗ���])
'*  ����
'*   m_cIni.SetIniString(�Z�N�V������, �L�[��, �������ޒl)
'*******************************************************************************

Imports System.Text
Imports System.Runtime.InteropServices
Imports System.Collections.Generic

Public Class IniFile
    Implements IDisposable

    '* DEFINE
    Private Const BUFF_LEN As Integer = 256 '256����

    '* API�錾
    '--- ini̧�ٓǍ���
    Private Declare Auto Function GetPrivateProfileString Lib "kernel32.dll" _
        Alias "GetPrivateProfileString" (
        <MarshalAs(UnmanagedType.LPWStr)> ByVal lpApplicationName As String,
        <MarshalAs(UnmanagedType.LPWStr)> ByVal lpKeyName As String,
        <MarshalAs(UnmanagedType.LPWStr)> ByVal lpDefault As String,
        <MarshalAs(UnmanagedType.LPWStr)> ByVal lpReturnedString As StringBuilder,
        ByVal nSize As UInt32,
        <MarshalAs(UnmanagedType.LPWStr)> ByVal lpFileName As String) As UInt32

    '--- ini̧�ُ�����
    <DllImport("kernel32.dll", CharSet:=CharSet.Unicode)>
    Private Shared Function WritePrivateProfileString _
      (ByVal lpApplicationName As String, ByVal lpKeyName As String, ByVal lpString As String, ByVal lpFilename As String) As Boolean
    End Function

    '* �����o�ϐ�
    Private m_strIniFileName As String

    '* �����o�֐�

    '--- �C���X�^���X�쐬
    '* ���� : ini�t�@�C���̃t���p�X
    Public Sub New(ByVal strIniFileName As String)
        '�����o�ϐ��ɃZ�b�g
        m_strIniFileName = strIniFileName
    End Sub


    '--- Get ini String���
    Public Function GetIniString(
            ByVal lpszSection As String,
            ByVal lpszEntry As String,
            Optional ByVal lpszDefault As String = Nothing
        ) As String

        Dim sb As StringBuilder = New StringBuilder(BUFF_LEN)
        Dim ret As UInt32 = GetPrivateProfileString(lpszSection, lpszEntry, lpszDefault, sb, Convert.ToUInt32(sb.Capacity), m_strIniFileName)

        Return sb.ToString
    End Function

    '--- Set ini String���
    Public Function SetIniString(
            ByVal lpszSection As String,
            ByVal lpszEntry As String,
            ByVal lpszString As String
        ) As Boolean

        Return WritePrivateProfileString(lpszSection, lpszEntry, lpszString, m_strIniFileName)
    End Function

    '--- Get ini section�ꗗ
    Public Function GetSectionNames() As List(Of String)

        Dim sbbuf As New System.Text.StringBuilder
        sbbuf.Append(Strings.StrDup(4096, vbNullChar))
        Dim ret As Integer = GetPrivateProfileString(Nothing, Nothing, Nothing, sbbuf, sbbuf.Length, m_strIniFileName)
        Dim sections() As String = Left(sbbuf.ToString, ret).TrimEnd(vbNullChar).Split(vbNullChar)

        Dim lst As New List(Of String)
        lst.AddRange(sections)

        Return lst
    End Function

#Region "IDisposable Support"
    Private disposedValue As Boolean ' �d������Ăяo�������o����ɂ�

    ' IDisposable
    Protected Overridable Sub Dispose(disposing As Boolean)
        If Not disposedValue Then
            If disposing Then
                '�}�l�[�W��Ԃ�j�����܂� (�}�l�[�W �I�u�W�F�N�g)�B
            End If

            ' �A���}�l�[�W ���\�[�X (�A���}�l�[�W �I�u�W�F�N�g) ��������A���� Finalize() ���I�[�o�[���C�h���܂��B
            ' �傫�ȃt�B�[���h�� null �ɐݒ肵�܂��B
        End If
        disposedValue = True
    End Sub

    ' ��� Dispose(disposing As Boolean) �ɃA���}�l�[�W ���\�[�X���������R�[�h���܂܂��ꍇ�ɂ̂� Finalize() ���I�[�o�[���C�h���܂��B
    'Protected Overrides Sub Finalize()
    '    ' ���̃R�[�h��ύX���Ȃ��ł��������B�N���[���A�b�v �R�[�h����� Dispose(disposing As Boolean) �ɋL�q���܂��B
    '    Dispose(False)
    '    MyBase.Finalize()
    'End Sub

    ' ���̃R�[�h�́A�j���\�ȃp�^�[���𐳂��������ł���悤�� Visual Basic �ɂ���Ēǉ�����܂����B
    Public Sub Dispose() Implements IDisposable.Dispose
        ' ���̃R�[�h��ύX���Ȃ��ł��������B�N���[���A�b�v �R�[�h����� Dispose(disposing As Boolean) �ɋL�q���܂��B
        Dispose(True)
        ' ��� Finalize() ���I�[�o�[���C�h����Ă���ꍇ�́A���̍s�̃R�����g���������Ă��������B
        ' GC.SuppressFinalize(Me)
    End Sub
#End Region

End Class
