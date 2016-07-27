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

Imports System.Text

Imports Elektro.Application.UI.Tools.CLI

#End Region

Namespace Logic

    ''' ----------------------------------------------------------------------------------------------------
    ''' <summary>
    ''' Contains the Help menu and algorithms for this application.
    ''' </summary>
    ''' ----------------------------------------------------------------------------------------------------
    Module Help

#Region " Private Fields "

        ''' ----------------------------------------------------------------------------------------------------
        ''' <summary>
        ''' Gets the name of the current process.
        ''' </summary>
        ''' ----------------------------------------------------------------------------------------------------
        Private ReadOnly processName As String = Process.GetCurrentProcess().MainModule.ModuleName

#End Region

#Region " Colorized Help Text "

        ''' ----------------------------------------------------------------------------------------------------
        ''' <summary>
        ''' Contains help information such as author name, application syntax and example usages.
        ''' </summary>
        ''' ----------------------------------------------------------------------------------------------------
        Public ReadOnly ColorizedHelp As XElement =
<Help>

    <!-- Current process name -->
    <!-- That means even when the user manually changes the executable name -->
    <Process>*F07*<%= processName %>*-F*</Process>

    <!-- Application title -->
    <Title>Shell Info .:: By Elektro ::.</Title>

    <!-- Application name -->
    <Name>*F07*Shell Info*-F*</Name>

    <!-- Application author -->
    <Author>*F07*Elektro*-F*</Author>

    <!-- Application version -->
    <Version>*F07*2.0*-F*</Version>

    <!-- Copyright information -->
    <Copyright>*F07*Copyright © Elektro Studios 2016*-F*</Copyright>

    <!-- Website information -->
    <Website>*F07*http://foro.elhacker.net/profiles/elektrohcker-u436313.html*-F*</Website>

    <!-- Skype contact information -->
    <Skype>*F07*ElektroStudios*-F*</Skype>

    <!-- Email contact information -->
    <Email>*F07*ElektroStudios@ElHacker.Net*-F*</Email>

    <!-- Application Logotype -->
    <Logo>*F10*
          __ _          _ _    _____        __       
         / _\ |__   ___| | |   \_   \_ __  / _| ___  
         \ \| '_ \ / _ \ | |    / /\/ '_ \| |_ / _ \ 
         _\ \ | | |  __/ | | /\/ /_ | | | |  _| (_) |
         \__/_| |_|\___|_|_| \____/ |_| |_|_|  \___/ 
    *-F*</Logo>

    <!-- Separator shape -->
    <Separator>
    *F10*------------------------------------------------------>>>>*-F*
    </Separator>

    <!-- Application Syntax -->
    <Syntax>
    *F10*[+]*-F* *F15*Syntax*-F*

        *F07*<%= processName %> *F10*/Info*F15*=*F07*{VALUE} *F10*/Copy*F15*=*F07*{TRUE or FALSE} *F10*/Path*F15*=*F07*{ITEM PATH}*-F*
    </Syntax>

    <!-- Application Syntax (Additional Specifications) -->
    <SyntaxExtra>
    *F10*[+]*-F* *F15*Switches*-F*
    
        *F10*/Info*-F* *F15*| *F07*Determines the kind of info to retrieve*-F*
        *F10**-F*      *F15*| *F07*from the specified file or directory.*-F*
        *F10**-F*      *F15*|
        *F10*/Path*-F* *F15*| *F07*Indicates the file or directory path.*-F*
        *F10**-F*      *F15*|
        *F10*/Copy*-F* *F15*| *F07*Specifies whether to send or not the info*-F*
        *F10**-F*      *F15*| *F07*to the Windows Clipboard.*-F*
        *F10**-F*      *F15*|
        *F10*/?*-F*    *F15*| *F07*Displays this help.*-F*


    *F10*[+]*-F* *F15*/Info*-F* *F15*values*-F*

        *F10*Path*-F*         *F15*| *F07*Gets the full item path.*-F*
        *F10*Dir*-F*          *F15*| *F07*Gets the item directory path.*-F*
        *F10*Name*-F*         *F15*| *F07*Gets the item name (including extension).*-F*
        *F10*Size*-F*         *F15*| *F07*Gets the item size, in bytes.*-F*
        *F10*CreationTime*-F* *F15*| *F07*Gets the item creation date.*-F*
        *F10*ModifyTime*-F*   *F15*| *F07*Gets the item last modified date.*-F*
        *F10*AccessTime*-F*   *F15*| *F07*Gets the item last accessed date.*-F*
        *F10*FileList*-F*     *F15*| *F07*Gets the directory file list.*-F*
        *F10*Content*-F*      *F15*| *F07*Gets the readable file content.*-F*
    </SyntaxExtra>

    <!-- Application Usage Examples -->
    <UsageExamples>
    *F10*[+]*-F* *F15*Usage examples*-F*

        *F15*<%= processName %> /Info=Path /Copy=True /Path="C:\File.ext"*-F*
        *F07*( Gets the full path of "C:\File.ext" )*-F*
    </UsageExamples>

</Help>

#End Region

#Region " Public Methods "

        ''' ----------------------------------------------------------------------------------------------------
        ''' <summary>
        ''' Prints the help.
        ''' </summary>
        ''' ----------------------------------------------------------------------------------------------------
        Public Sub PrintHelp()

            Dim sb As New StringBuilder
            With sb
                .AppendLine(Help.ColorizedHelp.<Logo>.Value)
                .AppendLine(Help.ColorizedHelp.<Separator>.Value)
                .AppendLine(String.Format("    *F15*Executable Name.......: {0}", Help.ColorizedHelp.<Process>.Value))
                .AppendLine(String.Format("    *F15*Application Name......: {0}", Help.ColorizedHelp.<Name>.Value))
                .AppendLine(String.Format("    *F15*Application Version...: {0}", Help.ColorizedHelp.<Version>.Value))
                .AppendLine(String.Format("    *F15*Application Dev. .....: {0}", Help.ColorizedHelp.<Author>.Value))
                .AppendLine(String.Format("    *F15*Application Copyright.: {0}", Help.ColorizedHelp.<Copyright>.Value))
                .AppendLine(String.Format("    *F15*Contact via Skype.....: {0}", Help.ColorizedHelp.<Skype>.Value))
                .AppendLine(String.Format("    *F15*Contact via Email.....: {0}", Help.ColorizedHelp.<Email>.Value))
                .AppendLine(Help.ColorizedHelp.<Separator>.Value)
                .AppendLine(Help.ColorizedHelp.<Syntax>.Value)
                .AppendLine(Help.ColorizedHelp.<SyntaxExtra>.Value)
                .AppendLine(Help.ColorizedHelp.<UsageExamples>.Value)
            End With

            CLIUtil.WriteColorTextLine(sb.ToString(), {"*"c})
            Console.ReadKey()

        End Sub

#End Region

    End Module

End Namespace
