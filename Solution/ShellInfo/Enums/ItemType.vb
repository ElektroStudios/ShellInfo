' ***********************************************************************
' Author   : Elektro
' Modified : 27-July-2016
' ***********************************************************************

#Region " Option Statements "

Option Strict On
Option Explicit On
Option Infer Off

#End Region

Namespace Enums

    ''' ----------------------------------------------------------------------------------------------------
    ''' <summary>
    ''' Specifies the type of a filesystem item.
    ''' </summary>
    ''' ----------------------------------------------------------------------------------------------------
    Public Enum ItemType As Integer

        ''' <summary>
        ''' The item is a file.
        ''' </summary>
        File = 1

        ''' <summary>
        ''' The item is a directory.
        ''' </summary>
        Directory = 2

        ''' <summary>
        ''' Unknown item type.
        ''' </summary>
        Unknown = -1

    End Enum

End Namespace