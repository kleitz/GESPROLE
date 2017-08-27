Imports System.Text.RegularExpressions

Public Class CowAdd
    Property Mode As Boolean
    Property Mom As Integer

    Private Sub CowAdd_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Breed.SelectedIndex = 0
    End Sub

    Private Sub Accept_Button_Click(sender As Object, e As EventArgs) Handles Accept_Button.Click
        If Not Regex.IsMatch(Name_In.Text, "^[a-zA-Z_ ]*$") Or Name_In.Text.Length <= 0 Then 'Name cannot contain numbers'
            MessageBox.Show(My.Computer.ResourceMgr.GetString("0262"), My.Computer.ResourceMgr.GetString("0239"), MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return
        End If

        If Weight.Value = 0 Or Background.Text.Length = 0 Then
            If (Not Background.Enabled And Weight.Value = 0) Or Background.Enabled Then
                MessageBox.Show(My.Computer.ResourceMgr.GetString("0172"), My.Computer.ResourceMgr.GetString("0239"), MessageBoxButtons.OK, MessageBoxIcon.Error)
                Return
            End If
        End If

        If Not My.Settings.Establishment.Equals("") Then
            Dim RemainingCapacity As Integer = Establishment.GetRemainingCapacity(My.Settings.Establishment, Today)

            If RemainingCapacity <= 0 Then
                MessageBox.Show(My.Computer.ResourceMgr.GetString("0263"), My.Computer.ResourceMgr.GetString("0239"), MessageBoxButtons.OK, MessageBoxIcon.Error)
                Return
            ElseIf RemainingCapacity > 0 And RemainingCapacity <= 10 Then
                MessageBox.Show(My.Computer.ResourceMgr.GetString("0264") & " " & RemainingCapacity - 1 & " " & My.Computer.ResourceMgr.GetString("0265"), My.Computer.ResourceMgr.GetString("0266"), MessageBoxButtons.OK, MessageBoxIcon.Information)
            End If

            If Mom <> 0 Then
                Cow.InsertIntoDB(New Cow(0, Name_In.Text, Mode, Breed.SelectedItem.ToString(), CInt(Weight.Value), Birth.Value, Mom), My.Settings.Establishment)
            Else
                Cow.InsertIntoDB(New Cow(0, Name_In.Text, Mode, Breed.SelectedItem.ToString(), CInt(Weight.Value), Birth.Value, Background.Text), My.Settings.Establishment) 'Used only when the cow is inserted at purchase, at birth discard background and insert mum_rp'
            End If
        Else
            Dim Establishments As Collection = Establishment.GetEstabList()
            Establishments.Remove(1) 'Remove TODOS entry'
            Dim EstabSelect As New ComboDialog.ComboDialog(My.Computer.ResourceMgr.GetString("0065"), Establishments)
            If EstabSelect.ShowDialog() = DialogResult.OK Then
                Dim RemainingCapacity As Integer = Establishment.GetRemainingCapacity(EstabSelect.RetVal, Today)

                If RemainingCapacity <= 0 Then
                    MessageBox.Show(My.Computer.ResourceMgr.GetString("0263"), My.Computer.ResourceMgr.GetString("0239"), MessageBoxButtons.OK, MessageBoxIcon.Error)
                    Return
                ElseIf RemainingCapacity > 0 And RemainingCapacity <= 10 Then
                    MessageBox.Show(My.Computer.ResourceMgr.GetString("0264") & " " & RemainingCapacity - 1 & " " & My.Computer.ResourceMgr.GetString("0265"), My.Computer.ResourceMgr.GetString("0266"), MessageBoxButtons.OK, MessageBoxIcon.Information)
                End If

                If Mom <> 0 Then
                    Cow.InsertIntoDB(New Cow(0, Name_In.Text, Mode, Breed.SelectedItem.ToString(), CInt(Weight.Value), Birth.Value, Mom), EstabSelect.RetVal)
                Else
                    Cow.InsertIntoDB(New Cow(0, Name_In.Text, Mode, Breed.SelectedItem.ToString(), CInt(Weight.Value), Birth.Value, Background.Text), EstabSelect.RetVal)
                End If
            Else
                MessageBox.Show(My.Computer.ResourceMgr.GetString("0267"), My.Computer.ResourceMgr.GetString("0239"), MessageBoxButtons.OK, MessageBoxIcon.Error)
                Return
            End If
        End If
        DialogResult = DialogResult.OK
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Cancel_Button.Click
        Dim Result As DialogResult = MessageBox.Show(My.Computer.ResourceMgr.GetString("0108"), My.Computer.ResourceMgr.GetString("0242"), MessageBoxButtons.OKCancel, MessageBoxIcon.Question)
        Select Case Result
            Case DialogResult.OK
                DialogResult = DialogResult.Cancel
            Case DialogResult.Cancel
                DialogResult = DialogResult.None
        End Select
    End Sub
End Class