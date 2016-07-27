' ***********************************************************************
' Author   : Elektro
' Modified : 27-July-2016
' ***********************************************************************

#Region " Option Statements "

Option Strict On
Option Explicit On
Option Infer Off

#End Region

#Region " Imports "

#End Region

Imports System.Drawing

Imports Elektro.Application.Types

Namespace Fields

    ''' ----------------------------------------------------------------------------------------------------
    ''' <summary>
    ''' Contains the command-line parameters for this application.
    ''' </summary>
    ''' ----------------------------------------------------------------------------------------------------
    Module Params

        ''' ----------------------------------------------------------------------------------------------------
        ''' <summary>
        ''' The "<c>/Info</c>" command-line parameter, 
        ''' which determines the info to retrieve from <see cref="Params.ItemPath"/>.
        ''' </summary>
        ''' ----------------------------------------------------------------------------------------------------
        Public InfoKind As New CommandlineParameter(Of String) With {
            .Name = "/InfoKind",
            .ShortName = "/Info",
            .Separator = "="c,
            .DefaultValue = "/?",
            .IsOptional = False
        }

        ''' ----------------------------------------------------------------------------------------------------
        ''' <summary>
        ''' The "<c>/Copy</c>" command-line parameter, 
        ''' which determines to send to clipboard or not the info retrieved by <see cref="Params.InfoKind"/>.
        ''' </summary>
        ''' ----------------------------------------------------------------------------------------------------
        Public SendToClipboard As New CommandlineParameter(Of Boolean) With {
            .Name = "/SendToClipboard",
            .ShortName = "/Copy",
            .Separator = "="c,
            .DefaultValue = False,
            .IsOptional = True
        }

        ''' ----------------------------------------------------------------------------------------------------
        ''' <summary>
        ''' The "<c>/Path</c>" command-line parameters, 
        ''' which determines the file or directory which to retrieve the type of info sepecified by <see cref="Params.InfoKind"/>.
        ''' </summary>
        ''' ----------------------------------------------------------------------------------------------------
        Public ItemPath As New CommandlineParameter(Of String) With {
            .Name = "/ItemPath",
            .ShortName = "/Path",
            .Separator = "="c,
            .DefaultValue = "",
            .IsOptional = False
        }

        ''' ----------------------------------------------------------------------------------------------------
        ''' <summary>
        ''' A <see cref="CommandlineParameterCollection"/> collection 
        ''' that contains all the declared command-line parameters in <see cref="Params"/> module.
        ''' </summary>
        ''' ----------------------------------------------------------------------------------------------------
        Public ParamCollection As New CommandlineParameterCollection() From {
            Params.InfoKind,
            Params.SendToClipboard,
            Params.ItemPath
        }

    End Module

End Namespace