Imports System.Resources
Imports System.IO

Namespace My

    Partial Class MyComputer
        Private ResMgr As ResourceManager

        Friend ReadOnly Property ResourceMgr() As ResourceManager

            Get
                'Dim ResourceFilePathPrefix As String

                'Downloaded from https://social.msdn.microsoft.com/Forums/en-US/bc9fa244-b701-4691-8255-91a458be1624/how-to-use-a-relative-path-to-play-a-wave-file-in-vbnet?forum=vblanguage
                'If System.Diagnostics.Debugger.IsAttached() Then
                'In Debugging mode  
                'ResourceFilePathPrefix = System.IO.Path.GetFullPath(Application.StartupPath & "\..\..\Resources\")
                'Else
                'In Published mode  
                'ResourceFilePathPrefix = Application.StartupPath & "\Resources\"
                'End If

                Return ResourceManager.CreateFileBasedResourceManager("resource", Environment.CurrentDirectory, Nothing)
            End Get

            'Set(value As ResourceManager)
            'ResMgr = value
            'End Set
        End Property
    End Class

End Namespace
