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

Imports ShellInfo.Fields
Imports ShellInfo.Enums
Imports ShellInfo.Logic

#End Region

Namespace Logic

    ''' ----------------------------------------------------------------------------------------------------
    ''' <summary>
    ''' The main application module.
    ''' </summary>
    ''' ----------------------------------------------------------------------------------------------------
    Module Program

        ''' ----------------------------------------------------------------------------------------------------
        ''' <summary>
        ''' The main entry point.
        ''' </summary>
        ''' ----------------------------------------------------------------------------------------------------
        Sub Main()
            Console.Title = Help.ColorizedHelp.<Title>.Value

            Parsing.ParseArguments(Params.ParamCollection,
                                   AddressOf ErrorHandling.OnSyntaxError,
                                   AddressOf ErrorHandling.OnMissingParameterRequired)

            Parsing.GetInfo(CStr(Params.ParamCollection("/InfoKind").Value),
                            CBool(Params.ParamCollection("/SendToClipboard").Value),
                            CStr(Params.ParamCollection("/ItemPath").Value))

            Environment.Exit(0)
        End Sub

    End Module

End Namespace
