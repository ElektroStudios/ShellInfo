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

Imports Elektro.Application.Types

#End Region

Namespace Logic

    ''' ----------------------------------------------------------------------------------------------------
    ''' <summary>
    ''' Contains the error-handling algorithms for this application.
    ''' </summary>
    ''' ----------------------------------------------------------------------------------------------------
    Module ErrorHandling

        ''' ----------------------------------------------------------------------------------------------------
        ''' <summary>
        ''' Called when exists the presence of a syntax error in one of the application parameters.
        ''' </summary>
        ''' ----------------------------------------------------------------------------------------------------
        ''' <param name="cmd">
        ''' The application parameter.
        ''' </param>
        ''' ----------------------------------------------------------------------------------------------------
        Public Sub OnSyntaxError(ByVal cmd As CommandlineParameter)

            Console.WriteLine(String.Format("[X] Syntax error in parameter: {0} (or {1})", cmd.Name, cmd.ShortName))
            Environment.Exit(exitCode:=1)

        End Sub

        ''' ----------------------------------------------------------------------------------------------------
        ''' <summary>
        ''' Called when exists the presence of missing (required) application parameters.
        ''' </summary>
        ''' ----------------------------------------------------------------------------------------------------
        ''' <param name="cmd">
        ''' The application parameter.
        ''' </param>
        ''' ----------------------------------------------------------------------------------------------------
        Public Sub OnMissingParameterRequired(ByVal cmd As CommandlineParameter)

            Console.WriteLine(String.Format("[X] Parameter {0} (or {1}) is required. ", cmd.Name, cmd.ShortName))
            Environment.Exit(exitCode:=1)

        End Sub

        ''' ----------------------------------------------------------------------------------------------------
        ''' <summary>
        ''' Called when the specified file or directory cannot be found.
        ''' </summary>
        ''' ----------------------------------------------------------------------------------------------------
        ''' <param name="itemPath">
        ''' The file or directory path.
        ''' </param>
        ''' ----------------------------------------------------------------------------------------------------
        Public Sub OnMissingPath(ByVal itemPath As String)

            Console.WriteLine(String.Format("[X] Cannot find file or directory: {0}", itemPath))
            Environment.Exit(exitCode:=1)

        End Sub

    End Module

End Namespace