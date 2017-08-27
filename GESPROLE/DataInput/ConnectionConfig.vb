Public Class ConnectionConfig
    Private Sub AcceptButton_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Try
            If IPIn.Text.Equals("127.0.0.1") Then
                My.Settings.IP = IPIn.Text
                My.Settings.MySQLPort = SQLPortIn.Value
            ElseIf My.Computer.Network.Ping(IPIn.Text) Then
                My.Settings.IP = IPIn.Text
                My.Settings.MySQLPort = SQLPortIn.Value

                Dim Conn As New MySql.Data.MySqlClient.MySqlConnection
                Dim MyConnString As String

                MyConnString = "server=" & My.Settings.IP & ";" _
            & "port=" & My.Settings.MySQLPort & ";" _
            & "uid=" & My.Settings.User & ";" _
            & "pwd=" & KryptUtils.Decrypt() & ";" _
            & "database=" & My.Settings.MySQLUser & ";"

                Try
                    Conn.ConnectionString = MyConnString
                    Conn.Open()

                    Conn.Close()
                Catch ex As MySql.Data.MySqlClient.MySqlException
                    MessageBox.Show(ex.Message, My.Computer.ResourceMgr.GetString("0239"), MessageBoxButtons.OK, MessageBoxIcon.Error)
                    Return
                Finally
                    Conn.Dispose()
                End Try
            Else
                MessageBox.Show(My.Computer.ResourceMgr.GetString("0007"), My.Computer.ResourceMgr.GetString("0239"), MessageBoxButtons.OK, MessageBoxIcon.Error)
                Return
            End If
        Catch ex As Exception
            MessageBox.Show(My.Computer.ResourceMgr.GetString("0012"), My.Computer.ResourceMgr.GetString("0239"), MessageBoxButtons.OK, MessageBoxIcon.Error)
            Console.WriteLine(ex.Message)
            Return
        End Try

        DialogResult = DialogResult.OK
    End Sub

    Private Sub ConectionConfig_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        IPIn.Text = My.Settings.IP
        SQLPortIn.Value = My.Settings.MySQLPort
    End Sub
End Class