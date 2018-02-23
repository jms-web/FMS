Imports System.Runtime.InteropServices

Namespace Util
    Module mdlDWM

        <StructLayout(LayoutKind.Sequential)>
        Public Structure Margins
            Public Sub New(ByVal left As Integer, ByVal right As Integer, ByVal top As Integer, ByVal bottom As Integer)
                _left = left
                _right = right
                _top = top
                _bottom = bottom
            End Sub
            Public Sub New(ByVal allMargins As Integer)
                _left = allMargins
                _right = allMargins
                _top = allMargins
                _bottom = allMargins
            End Sub
            Private _left As Integer
            Private _right As Integer
            Private _top As Integer
            Private _bottom As Integer
            Public Property Left() As Integer
                Get
                    Return _left
                End Get
                Set(ByVal value As Integer)
                    _left = value
                End Set
            End Property
            Public Property Right() As Integer
                Get
                    Return _right
                End Get
                Set(ByVal value As Integer)
                    _right = value
                End Set
            End Property
            Public Property Top() As Integer
                Get
                    Return _top
                End Get
                Set(ByVal value As Integer)
                    _top = value
                End Set
            End Property
            Public Property Bottom() As Integer
                Get
                    Return _bottom
                End Get
                Set(ByVal value As Integer)
                    _bottom = value
                End Set
            End Property
            Public ReadOnly Property IsMarginless() As Boolean
                Get
                    Return (_left < 0 AndAlso _right < 0 AndAlso _top < 0 AndAlso _bottom < 0)
                End Get
            End Property
            Public ReadOnly Property IsNull() As Boolean
                Get
                    Return (_left = 0 AndAlso _right = 0 AndAlso _top = 0 AndAlso _bottom = 0)
                End Get
            End Property
        End Structure
        <StructLayout(LayoutKind.Sequential)>
        Public Structure Rect
            Public stleft, sttop, stright, stbottom As Integer
            Public Sub Rect(ByVal left As Integer, ByVal top As Integer, ByVal right As Integer, ByVal bottom As Integer)
                stleft = left
                sttop = top
                stright = right
                stbottom = bottom
            End Sub
        End Structure
        <StructLayout(LayoutKind.Sequential)>
        Public Structure Dwm_ThumbnailProperties
            Public dwFlags As UInt64
            Public rcDestination As Rect
            Public rcSource As Rect
            Public opacity As Byte
            <MarshalAs(UnmanagedType.Bool)>
            Public fVisible As Boolean
            <MarshalAs(UnmanagedType.Bool)>
            Public fSourceClientAreaOnly As Boolean
            Public Const DWM_TNP_RECTDESTINATION As UInt32 = &H1
            Public Const DWM_TNP_RECTSOURCE As UInt32 = &H2
            Public Const DWM_TNP_OPACITY As UInt32 = &H4
            Public Const DWM_TNP_VISIBLE As UInt32 = &H8
            Public Const DWM_TNP_SOURCECLIENTAREAONLY As UInt32 = &H10
        End Structure
        <StructLayout(LayoutKind.Sequential)>
        Public Structure Dwm_BlurBehind
            Public dwFlags As UInt64
            <MarshalAs(UnmanagedType.Bool)>
            Public fEnable As Boolean
            Public hRegionBlur As IntPtr
            <MarshalAs(UnmanagedType.Bool)>
            Public fTransitionOnMaximized As Boolean
            Public Const DWM_BB_ENABLE As UInt32 = &H1
            Public Const DWM_BB_BLURREGION As UInt32 = &H2
            Public Const DWM_BB_TRANSITIONONMAXIMIZED As UInt32 = &H4
        End Structure
        <DllImport("dwmapi.dll", PreserveSig:=False)>
        Public Function DwmExtendFrameIntoClientArea(ByVal hWnd As IntPtr, ByRef pMarInset As Margins) As Integer
        End Function
        <DllImport("dwmapi.dll", PreserveSig:=False)>
        Public Function DwmIsCompositionEnabled() As Boolean
        End Function
        <DllImport("dwmapi.dll", PreserveSig:=False)>
        Public Function DwmEnableBlurBehindWindow(ByVal hWnd As IntPtr, ByVal pBlurBehind As Dwm_BlurBehind) As Integer
        End Function
        <DllImport("dwmapi.dll", PreserveSig:=False)>
        Public Function DwmEnableComposition(ByVal bEnable As Boolean) As Object
        End Function
        <DllImport("dwmapi.dll", PreserveSig:=False)>
        Public Function DwmGetColorizationColor(ByVal pcrColorization As Integer, <MarshalAs(UnmanagedType.Bool)> ByVal pfOpaqueBlend As Boolean) As Object
        End Function
        <DllImport("dwmapi.dll", PreserveSig:=False)>
        Public Function DwmRegisterThumbnail(ByVal dest As IntPtr, ByVal source As IntPtr) As IntPtr
        End Function
        <DllImport("dwmapi.dll", PreserveSig:=False)>
        Public Function DwmUnregisterThumbnail(ByVal hThumbnail As IntPtr) As Object
        End Function
        <DllImport("dwmapi.dll", PreserveSig:=False)>
        Public Function DwmUpdateThumbnailProperties(ByVal hThumbnail As IntPtr, ByVal props As Dwm_ThumbnailProperties) As Object
        End Function
        <DllImport("dwmapi.dll", PreserveSig:=False)>
        Public Function DwmQueryThumbnailSourceSize(ByVal hThumbnail As IntPtr, ByVal size As Size) As Object
        End Function


        '<DllImport("dwmapi.dll", PreserveSig:=False)>
        'Public Sub DwmExtendFrameIntoClientArea(hWnd As IntPtr, pMargins As MARGINS)
        'End Sub

        '<DllImport("dwmapi.dll", PreserveSig:=False)>
        'Public Function DwmIsCompositionEnabled() As Boolean
        'End Function

        '<StructLayout(LayoutKind.Sequential)>
        'Public Structure MARGINS
        '    Public leftWidth As Integer
        '    Public rightWidth As Integer
        '    Public topHeight As Integer
        '    Public bottomHeight As Integer
        'End Structure

        Public Function GetColorFromInt64(ByVal lngColor As Long) As Color
            Return Color.FromArgb(CByte(lngColor >> 24), CByte(lngColor >> 16), CByte(lngColor >> 8), CByte(lngColor))
        End Function

    End Module

    '黒色にした箇所が透明になる ただし、内部コントロールのテキストまで含めて全て
    'Me.BackColor = Color.Black
    'If Util.clsDWM.DwmIsCompositionEnabled() = True Then
    'Dim margin As Util.clsDWM.MARGINS
    '        margin.leftWidth = 0
    '        margin.rightWidth = 0
    '        margin.topHeight = 0 'Me.lblTytle.Top
    '        margin.bottomHeight = 0
    '        Util.clsDWM.DwmExtendFrameIntoClientArea(Me.Handle, margin)
    'End If

End Namespace