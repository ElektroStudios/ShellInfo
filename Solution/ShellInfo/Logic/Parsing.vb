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

Imports System.IO
Imports System.Text

Imports ShellInfo.Enums
Imports ShellInfo.Fields

Imports Elektro.Application.Types
Imports Elektro.Core.IO.Extensions.DirectoryInfo
Imports Elektro.Core.IO.Tools

#End Region

Namespace Logic

    ''' ----------------------------------------------------------------------------------------------------
    ''' <summary>
    ''' Contains the parsing algorithms for the command-line parameters of this application.
    ''' </summary>
    ''' ----------------------------------------------------------------------------------------------------
    Module Parsing

        ''' ----------------------------------------------------------------------------------------------------
        ''' <summary>
        ''' Loop through all the command-line arguments of this application.
        ''' </summary>
        ''' ----------------------------------------------------------------------------------------------------
        ''' <param name="cmds">
        ''' The commandline parameters.
        ''' </param>
        ''' 
        ''' <param name="callbackSyntaxError">
        ''' An encapsulated method that is invoked if a syntax error is found in one of the arguments.
        ''' </param>
        ''' 
        ''' <param name="callbackMissingRequired">
        ''' An encapsulated method that is invoked if a required parameter is missing in the arguments.
        ''' </param>
        ''' ----------------------------------------------------------------------------------------------------
        Public Sub ParseArguments(ByVal cmds As CommandlineParameterCollection,
                                  ByVal callbackSyntaxError As Action(Of CommandlineParameter),
                                  ByVal callbackMissingRequired As Action(Of CommandlineParameter))

            Parsing.ParseArguments(cmds, Environment.GetCommandLineArgs.Skip(1), callbackSyntaxError, callbackMissingRequired)

        End Sub


        ''' ----------------------------------------------------------------------------------------------------
        ''' <summary>
        ''' Loop through all the command-line arguments of this application.
        ''' </summary>
        ''' ----------------------------------------------------------------------------------------------------
        ''' <param name="cmds">
        ''' The commandline parameters.
        ''' </param>
        ''' 
        ''' <param name="args">
        ''' The collection of commandline arguments to examine.
        ''' </param>
        ''' 
        ''' <param name="callbackSyntaxError">
        ''' An encapsulated method that is invoked if a syntax error is found in one of the arguments.
        ''' </param>
        ''' 
        ''' <param name="callbackMissingRequired">
        ''' An encapsulated method that is invoked if a required parameter is missing in the arguments.
        ''' </param>
        ''' ----------------------------------------------------------------------------------------------------
        Public Sub ParseArguments(ByVal cmds As CommandlineParameterCollection,
                                  ByVal args As IEnumerable(Of String),
                                  ByVal callbackSyntaxError As Action(Of CommandlineParameter),
                                  ByVal callbackMissingRequired As Action(Of CommandlineParameter))

            If Not (args.Any) Then
                Help.PrintHelp()
            End If

            Dim cmdRequired As List(Of CommandlineParameter) =
                (From cmd As CommandlineParameter In cmds
                 Where Not cmd.IsOptional).ToList

            For Each arg As String In args

                For Each cmd As CommandlineParameter In cmds

                    If (arg.StartsWith(cmd.Name & cmd.Separator, StringComparison.OrdinalIgnoreCase)) OrElse
                       (arg.StartsWith(cmd.ShortName & cmd.Separator, StringComparison.OrdinalIgnoreCase)) Then

                        Dim value As String = arg.Substring(arg.IndexOf(cmd.Separator) + 1)

                        If (cmdRequired.Contains(cmd)) Then
                            cmdRequired.Remove(cmd)
                        End If

                        If String.IsNullOrEmpty(value) Then
                            cmd.Value = cmd.DefaultValue
                            Continue For

                        Else
                            Try
                                cmd.Value = Convert.ChangeType(value, cmd.DefaultValue.GetType())
                                Continue For

                            Catch ex As Exception
                                callbackSyntaxError.Invoke(cmd)
                                Exit Sub

                            End Try

                        End If

                    ElseIf arg.Equals("/?") Then
                        Help.PrintHelp()

                    End If

                Next cmd

            Next arg

            If (cmdRequired.Any) Then
                callbackMissingRequired.Invoke(cmdRequired.First)
            End If

        End Sub

        ''' ----------------------------------------------------------------------------------------------------
        ''' <summary>
        ''' Gets the information from the specified file or directory.
        ''' </summary>
        ''' ----------------------------------------------------------------------------------------------------
        ''' <param name="info">
        ''' The kind of information to retrieve.
        ''' </param>
        ''' 
        ''' <param name="sendToClipboard">
        ''' If set to <see langword="True"/>, send the obtained info to Windows Clipboard.
        ''' </param>
        ''' 
        ''' <param name="itemPath">
        ''' The file or directory path.
        ''' </param>
        ''' ----------------------------------------------------------------------------------------------------
        Public Sub GetInfo(ByVal info As String, ByVal sendToClipboard As Boolean, ByVal itemPath As String)

            Dim itemType As ItemType = ItemType.Unknown
            Dim data As String = String.Empty

            If Files.IsShortcut(itemPath) Then
                itemPath = Shortcuts.GetFullPath(itemPath)
            End If

            If Files.IsFile(itemPath) Then
                itemType = ItemType.File
            End If

            If Directories.IsDirectory(itemPath) Then
                itemType = ItemType.Directory
            End If

            If (itemType = ItemType.Unknown) Then
                ErrorHandling.OnMissingPath(itemPath)
            End If

            Select Case info.ToLower()

                Case "path"
                    Select Case itemType
                        Case ItemType.File
                            data = New FileInfo(itemPath).FullName
                        Case ItemType.Directory
                            data = New DirectoryInfo(itemPath).FullName
                    End Select

                Case "dir"
                    Select Case itemType
                        Case ItemType.File
                            data = New FileInfo(itemPath).Directory.FullName
                        Case ItemType.Directory
                            data = New DirectoryInfo(itemPath).Parent.FullName
                    End Select

                Case "name"
                    Select Case itemType
                        Case ItemType.File
                            data = New FileInfo(itemPath).Name
                        Case ItemType.Directory
                            data = New DirectoryInfo(itemPath).Name
                    End Select

                Case "size"
                    Select Case itemType
                        Case ItemType.File
                            data = New FileInfo(itemPath).Length.ToString()
                        Case ItemType.Directory
                            data = New DirectoryInfo(itemPath).GetSize(searchOption:=SearchOption.AllDirectories).ToString()
                    End Select

                Case "attrib"
                    Select Case itemType
                        Case ItemType.File
                            data = New FileInfo(itemPath).Attributes.ToString()
                        Case ItemType.Directory
                            data = New DirectoryInfo(itemPath).Attributes.ToString()
                    End Select

                Case "creationtime"
                    Select Case itemType
                        Case ItemType.File
                            data = New FileInfo(itemPath).CreationTime.ToString()
                        Case ItemType.Directory
                            data = New DirectoryInfo(itemPath).CreationTime.ToString()
                    End Select

                Case "modifytime"
                    Select Case itemType
                        Case ItemType.File
                            data = New FileInfo(itemPath).LastWriteTime.ToString()
                        Case ItemType.Directory
                            data = New DirectoryInfo(itemPath).LastWriteTime.ToString()
                    End Select

                Case "accesstime"
                    Select Case itemType
                        Case ItemType.File
                            data = New FileInfo(itemPath).LastAccessTime.ToString()
                        Case ItemType.Directory
                            data = New DirectoryInfo(itemPath).LastAccessTime.ToString()
                    End Select

                Case "filelist"
                    Select Case itemType
                        Case ItemType.Directory
                            data = String.Join(Environment.NewLine, Files.GetFilePaths(itemPath, SearchOption.TopDirectoryOnly))
                    End Select

                Case "content"
                    Select Case itemType
                        Case ItemType.File
                            data = File.ReadAllText(itemPath, Encoding.Default)
                    End Select

                Case Else
                    ErrorHandling.OnSyntaxError(Params.InfoKind)

            End Select

            If (sendToClipboard) AndAlso Not (String.IsNullOrEmpty(data)) Then
                My.Computer.Clipboard.SetText(data)
            End If

            If Not (String.IsNullOrEmpty(data)) Then
                Console.WriteLine(data)
            End If

        End Sub

    End Module

End Namespace