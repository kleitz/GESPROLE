Imports System.Security.Cryptography

Public Class KryptUtils
    Public Shared Function Decrypt() As String
        Dim ResourceFilePathPrefix As String

        'Downloaded from https://social.msdn.microsoft.com/Forums/en-US/bc9fa244-b701-4691-8255-91a458be1624/how-to-use-a-relative-path-to-play-a-wave-file-in-vbnet?forum=vblanguage
        If System.Diagnostics.Debugger.IsAttached() Then
            'In Debugging mode  
            ResourceFilePathPrefix = System.IO.Path.GetFullPath(Application.StartupPath & "\..\..\Resources\")
        Else
            'In Published mode  
            ResourceFilePathPrefix = Application.StartupPath & "\Resources\"
        End If

        'Downloaded from http://www.vb-helper.com/howto_net_run_dos.html

        'MsgBox(ResourceFilePathPrefix)

        ' Set start information.
        Dim start_info As New ProcessStartInfo("java", " -jar """ & ResourceFilePathPrefix & "NKRyptr.jar"" FALSE ÕºatÑat¹Ctp£yt¿®x¢Ë¼a?Nºt¢a?èa¬2äª¸a?Éat´ayt°Õtwa¥@?taaÌÂ2ta³·pa°tÂ")
        start_info.UseShellExecute = False
        start_info.CreateNoWindow = True
        start_info.RedirectStandardOutput = True
        start_info.RedirectStandardError = True

        ' Make the process and set its start information.
        Dim proc As New Process()
        proc.StartInfo = start_info

        ' Start the process.
        proc.Start()

        ' Attach to stdout and stderr.
        Dim std_out As IO.StreamReader = proc.StandardOutput()
        'Dim err_out As IO.StreamReader = proc.StandardError()

        ' Display the results.
        Dim txtStdout As String = std_out.ReadToEnd()

        ' Clean up.
        std_out.Close()
        proc.Close()

        'MsgBox(err_out.ReadToEnd())
        Return txtStdout
    End Function

    Public Shared Function UnicodeBytesToString(ByVal bytes() As Byte) As String
        Return System.Text.Encoding.Unicode.GetString(bytes)
    End Function

    Public Shared Function UnicodeStringToBytes(ByVal str As String) As Byte()
        Return System.Text.Encoding.Unicode.GetBytes(str)
    End Function

    Public Shared Function GenerateSalt() As Byte()
        Using RandomNumberGen As New RNGCryptoServiceProvider
            Dim RandomNumber(32) As Byte
            RandomNumberGen.GetBytes(RandomNumber)

            Return RandomNumber
        End Using
    End Function

    Public Shared Function HashPassword(ByVal ToBeHashed As String, ByVal Salt As Byte(), NumOfIterations As Integer) As String
        Using RFC2898 As New Rfc2898DeriveBytes(UnicodeStringToBytes(ToBeHashed), Salt, NumOfIterations)
            Return UnicodeBytesToString(RFC2898.GetBytes(32))
        End Using
    End Function

End Class
