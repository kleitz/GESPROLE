Imports System.ComponentModel
Imports System.Globalization
Imports System.IO
Imports System.Resources
Imports System.Threading

Public Class Login

    ' TODO: inserte el código para realizar autenticación personalizada usando el nombre de usuario y la contraseña proporcionada 
    ' (Consulte http://go.microsoft.com/fwlink/?LinkId=35339).  
    ' El objeto principal personalizado se puede adjuntar al objeto principal del subproceso actual como se indica a continuación: 
    '     My.User.CurrentPrincipal = CustomPrincipal
    ' donde CustomPrincipal es la implementación de IPrincipal utilizada para realizar la autenticación. 
    ' Posteriormente, My.User devolverá la información de identidad encapsulada en el objeto CustomPrincipal
    ' como el nombre de usuario, nombre para mostrar, etc.

    Private Cnt As Integer = 0

    Private Sub Login_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        'My.Settings.Reset()

        'Prepare resource route'
        Dim ResourceFilePathPrefix As String = ""

        If System.Diagnostics.Debugger.IsAttached() Then
            'In Debugging mode  
            ResourceFilePathPrefix = System.IO.Path.GetFullPath(Application.StartupPath & "\..\..\Resources\")
        Else
            'In Published mode  
            ResourceFilePathPrefix = Application.StartupPath & "\Resources\"
        End If

        Environment.CurrentDirectory = ResourceFilePathPrefix

        'My.Computer.ResourceMgr = ResourceManager.CreateFileBasedResourceManager("resource", ResourceFilePathPrefix, Nothing)

        If My.Settings.Language.Contains("es") Then
            Lang_Select.BackgroundImage = My.Resources.brit
        End If
    End Sub

    Private Sub Captcha_View(State As Boolean) 'True is to activate the captcha, False is to deactivate it
        Captcha.Visible = State
        Captcha_In.Visible = State
        Unlock.Visible = State
        UsernameTextBox.Enabled = Not State
        PasswordTextBox.Enabled = Not State
        OK.Enabled = Not State
        If State Then
            Me.Height += 128
            Me.AcceptButton = Unlock 'This is what has to be done for an enter click to work, change the accept button property'
        Else
            Me.Height -= 128
            Me.AcceptButton = OK
        End If
    End Sub

    Private Sub MakeCaptcha()
        Dim Random As New Random
        My.Settings.Captcha = Random.Next(1000000, 5000000)
        Captcha.Text = My.Settings.Captcha
        Captcha_In.Text = ""
    End Sub

    Private Sub OK_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles OK.Click
        Cnt += 1

        'Check user and pass
        Dim GoodToGo As Boolean = Login(UsernameTextBox.Text, PasswordTextBox.Text)

        If Cnt <= 3 And GoodToGo Then
            Dim MainMenu As New Main
            If My.Computer.Network.Ping(My.Settings.IP) Then
                MainMenu.Show()
                Me.Close()
            ElseIf My.Settings.IP.Equals("") Then
                MessageBox.Show(My.Computer.ResourceMgr.GetString("0006"), My.Computer.ResourceMgr.GetString("0239"), MessageBoxButtons.OK, MessageBoxIcon.Error)
                Cnt -= 1
            Else
                MessageBox.Show(My.Computer.ResourceMgr.GetString("0007"), My.Computer.ResourceMgr.GetString("0239"), MessageBoxButtons.OK, MessageBoxIcon.Error)
                Cnt -= 1
            End If
        ElseIf Not GoodToGo And Cnt <= 3 Then
            PasswordTextBox.Text = ""
            MessageBox.Show(My.Computer.ResourceMgr.GetString("0008"), My.Computer.ResourceMgr.GetString("0239"), MessageBoxButtons.OK, MessageBoxIcon.Error)
        Else
            MakeCaptcha()
            Captcha_View(True)
            MessageBox.Show(My.Computer.ResourceMgr.GetString("0009"), My.Computer.ResourceMgr.GetString("0239"), MessageBoxButtons.OK, MessageBoxIcon.Error)
        End If
    End Sub

    Private Sub Unlock_Click(sender As Object, e As EventArgs) Handles Unlock.Click
        Try
            If CInt(Captcha_In.Text) = My.Settings.Captcha Then
                Captcha_View(False)
                Cnt = 0
            Else
                Throw New Exception
            End If
        Catch ex As Exception
            MessageBox.Show(My.Computer.ResourceMgr.GetString("0010"), My.Computer.ResourceMgr.GetString("0239"), MessageBoxButtons.OK, MessageBoxIcon.Error)
            MakeCaptcha()
        End Try
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Dim ConnConfig As New ConnectionConfig
        ConnConfig.ShowDialog(Me)
    End Sub

    Public Shared Function Login(ByVal Username As String, ByVal Pass As String) As Boolean
        Dim Conn As New MySql.Data.MySqlClient.MySqlConnection
        Dim Cmd As New MySql.Data.MySqlClient.MySqlCommand
        Dim Reader As MySql.Data.MySqlClient.MySqlDataReader
        Dim MyConnString As String

        MyConnString = "server=" & My.Settings.IP & ";" _
            & "port=" & My.Settings.MySQLPort & ";" _
            & "uid=" & My.Settings.User & ";" _
            & "pwd=" & KryptUtils.Decrypt() & ";" _
            & "database=" & My.Settings.MySQLUser & ";" _
            & "charset=utf8mb4;"

        Try

            Conn.ConnectionString = MyConnString
            Conn.Open()

            Cmd.Connection = Conn

            Cmd.CommandText = "SELECT Sal FROM usuario WHERE Username=@username"
            Cmd.Prepare()

            Cmd.Parameters.AddWithValue("@username", Username)

            Reader = Cmd.ExecuteReader

            If Reader.Read Then
                Dim Salt(32) As Byte
                Dim bytesRead As Long = Reader.GetBytes(Reader.GetOrdinal("Sal"), 0, Salt, 0, 33)

                Try
                    Cmd.CommandText = "SELECT COUNT(*), Privilegios, Establecimiento FROM usuario WHERE Username=@username AND Pass=@pass"
                    Cmd.Prepare()

                    'Cmd.Parameters.AddWithValue("@username", Username)
                    Cmd.Parameters.AddWithValue("@pass", KryptUtils.HashPassword(Pass, Salt, 78659))

                    Reader.Close()
                    Reader = Cmd.ExecuteReader

                    If Reader.Read Then
                        If Reader.GetInt32("COUNT(*)") > 0 Then
                            My.Settings.Privileges = Reader.GetInt32("Privilegios")
                            My.Settings.Establishment = Reader.GetString("Establecimiento")
                            My.Settings.LogName = Username
                            Return True
                        End If
                    End If
                Catch e As Exception
                    Console.WriteLine(e.Message)
                End Try
            End If

            Conn.Close()
        Catch ex As MySql.Data.MySqlClient.MySqlException
            Console.WriteLine(ex.Message)
            Select Case ex.Number
                Case 0
                    MessageBox.Show(My.Computer.ResourceMgr.GetString("0011"))
                Case 1045
                    MessageBox.Show(My.Computer.ResourceMgr.GetString("0008") & ", " & My.Computer.ResourceMgr.GetString("0010"))
            End Select
        Finally
            Conn.Dispose()
        End Try
        Return False
    End Function

    Private Sub LangSelect_Click(sender As Object, e As EventArgs) Handles Lang_Select.Click
        If My.Settings.Language.Contains("es") Then
            Dim Result As DialogResult = MessageBox.Show("Do you really wish to change the language to English?", "Changing to English...", MessageBoxButtons.YesNo, MessageBoxIcon.Question)

            If Result = DialogResult.Yes Then
                'Lang_Select.BackgroundImage = My.Resources.spain
                My.Settings.Language = "en-US"
                MessageBox.Show("The application will restart...", "Changing to English...", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Application.Restart()
            End If
        ElseIf My.Settings.Language.Contains("en") Then
            Dim Result As DialogResult = MessageBox.Show("¿Seguro que deseas cambiar el idioma a español?", "Cambiando a español...", MessageBoxButtons.YesNo, MessageBoxIcon.Question)

            If Result = DialogResult.Yes Then
                'Lang_Select.BackgroundImage = My.Resources.brit
                My.Settings.Language = "es-ES"
                MessageBox.Show("La aplicación se reiniciará...", "Cambiando a español...", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Application.Restart()
            End If
        End If
    End Sub
End Class
