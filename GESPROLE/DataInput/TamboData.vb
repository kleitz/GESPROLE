Imports System.Globalization
Imports System.Text.RegularExpressions

Public Class TamboData
    Public Property Mode As Boolean

    Public Const ADDITION As Boolean = True
    Public Const REVISION As Boolean = False

    Private OldCapacity As Integer = 0

    Private Sub TamboData_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        NameIn.Enabled = Mode 'This way in the event of a revision it will be impossible to edit the name'

        If Mode = REVISION Then
            Dim Estab As Establishment

            If My.Settings.Establishment.Equals("") Then
                Dim Establishments As Collection = Establishment.GetEstabList()
                Establishments.Remove(1) 'Remove TODOS entry'
                Dim EstabSelect As New ComboDialog.ComboDialog(My.Computer.ResourceMgr.GetString("0065"), Establishments)
                If EstabSelect.ShowDialog() = DialogResult.OK Then
                    Estab = Establishment.GetEstablishment(EstabSelect.RetVal)
                Else
                    Me.Close()
                    Return
                End If
            Else
                Estab = Establishment.GetEstablishment(My.Settings.Establishment)
            End If


            NameIn.Text = Estab.Name
            MailIn.Text = Estab.Mail
            AddrIn.Text = Estab.Address
            HecIn.Value = Estab.Size
            CapacityIn.Value = Estab.Capacity
        End If

        If My.Settings.Privileges < 2 Then 'Only will the owner of it all be allowed to edit an establishment'
            MailIn.Enabled = False
            AddrIn.Enabled = False
            HecIn.Enabled = False
            CapacityIn.Enabled = False
            Me.Text = My.Computer.ResourceMgr.GetString("0089")
        End If
    End Sub

    Private Sub CapacityIn_GotFocus(sender As Object, e As EventArgs) Handles CapacityIn.GotFocus
        OldCapacity = CapacityIn.Value 'Keeping a record of establishment capacity at runtime'
    End Sub

    Private Sub Accept_Button_Click(sender As Object, e As EventArgs) Handles Accept_Button.Click
        If Not IsValidEmail(MailIn.Text) Then
            MessageBox.Show(My.Computer.ResourceMgr.GetString("0104"), My.Computer.ResourceMgr.GetString("0239"), MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return
        End If

        If NameIn.Text.Length = 0 Or MailIn.Text.Length = 0 Or AddrIn.Text.Length = 0 Or HecIn.Value = 0 Or CapacityIn.Value = 0 Then
            MessageBox.Show(My.Computer.ResourceMgr.GetString("0172"), My.Computer.ResourceMgr.GetString("0239"), MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return
        End If

        If CapacityIn.Value < OldCapacity Then
            If CapacityIn.Value < Establishment.GetCowCount(NameIn.Text, Today) Then
                MessageBox.Show(My.Computer.ResourceMgr.GetString("0105") & " " & CapacityIn.Value & " " & My.Computer.ResourceMgr.GetString("0106"), My.Computer.ResourceMgr.GetString("0239"), MessageBoxButtons.OK, MessageBoxIcon.Error)
                Return
            End If
        End If

        If Mode = ADDITION Then
            Dim Producer As String = Establishment.GetProducer()

            Do While Producer Is Nothing Or Producer.Equals("")
                Producer = InputBox(My.Computer.ResourceMgr.GetString("0107"))
                If Producer.Equals("") Then
                    MessageBox.Show(My.Computer.ResourceMgr.GetString("0010"), My.Computer.ResourceMgr.GetString("0239"), MessageBoxButtons.OK, MessageBoxIcon.Error)
                End If
            Loop

            Establishment.InsertIntoDB(New Establishment(NameIn.Text, MailIn.Text, AddrIn.Text, HecIn.Value, CapacityIn.Value), Producer)
        Else
            Establishment.UpdateInDB(New Establishment(NameIn.Text, MailIn.Text, AddrIn.Text, HecIn.Value, CapacityIn.Value))
        End If

        DialogResult = DialogResult.OK
    End Sub

    Private Sub Cancel_Button_Click(sender As Object, e As EventArgs) Handles Cancel_Button.Click
        Dim Result As DialogResult = MessageBox.Show(My.Computer.ResourceMgr.GetString("0108"), My.Computer.ResourceMgr.GetString("0242"), MessageBoxButtons.OKCancel, MessageBoxIcon.Question)
        Select Case Result
            Case DialogResult.OK
                DialogResult = DialogResult.Cancel
            Case DialogResult.Cancel
                DialogResult = DialogResult.None
        End Select
    End Sub

    'Extra help got from Microsoft'

    Dim invalid As Boolean = False

    Public Function IsValidEmail(strIn As String) As Boolean
        invalid = False
        If String.IsNullOrEmpty(strIn) Then Return False

        ' Use IdnMapping class to convert Unicode domain names.
        Try
            strIn = Regex.Replace(strIn, "(@)(.+)$", AddressOf Me.DomainMapper, RegexOptions.None)
        Catch e As Exception
            Return False
        End Try

        If invalid Then Return False

        ' Return true if strIn is in valid e-mail format.
        Try
            Return Regex.IsMatch(strIn,
                   "^(?("")("".+?(?<!\\)""@)|(([0-9a-z]((\.(?!\.))|[-!#\$%&'\*\+/=\?\^`\{\}\|~\w])*)(?<=[0-9a-z])@))" &
                   "(?(\[)(\[(\d{1,3}\.){3}\d{1,3}\])|(([0-9a-z][-\w]*[0-9a-z]*\.)+[a-z0-9][\-a-z0-9]{0,22}[a-z0-9]))$",
                   RegexOptions.IgnoreCase)
        Catch e As Exception
            Return False
        End Try
    End Function

    Private Function DomainMapper(match As Match) As String
        ' IdnMapping class with default property values.
        Dim idn As New IdnMapping()

        Dim domainName As String = match.Groups(2).Value
        Try
            domainName = idn.GetAscii(domainName)
        Catch e As ArgumentException
            invalid = True
        End Try
        Return match.Groups(1).Value + domainName
    End Function

    'End of extra help'
End Class