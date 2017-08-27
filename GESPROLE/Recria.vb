Public Class Recria
    Property RPs As Collection

    Private Sub Recria_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        If RPs IsNot Nothing Then
            RPLabel.Visible = False
            RPIn.Visible = False
            CowSearch.Visible = False
        End If

        DateTimePicker3.Value = DateTimePicker1.Value.AddMonths(12)
    End Sub

    Private Sub CowSearch_Click(sender As Object, e As EventArgs) Handles CowSearch.Click
        Dim CowSearchWin As New CowSearch
        CowSearchWin.Mode = Cow.COW
        CowSearchWin.ModeTwo = GESPROLE.CowSearch.SELECTION
        CowSearchWin.WhenDoISearch = DateTimePicker1.Value
        If CowSearchWin.ShowDialog(Me) = DialogResult.OK Then
            RPIn.Value = CowSearchWin.ReturnValue
        End If
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

    Private Sub Accept_Click(sender As Object, e As EventArgs) Handles Accept.Click
        If RPs IsNot Nothing Then
            If TextBox1.Text.Length > 0 And DateTime.Compare(DateTimePicker1.Value, DateTimePicker3.Value) < 0 Then
                For Each RP As Integer In RPs
                    If ValidateEvent(RPIn.Value) Then
                        LifeEvent.InsertIntoDB(New LifeEvent(RP, DateTimePicker1.Value, LifeEvent.IDA_RECRIA, Nothing, TextBox1.Text, DateTimePicker3.Value.ToString("yyyy-MM-dd"), Nothing))
                        DialogResult = DialogResult.OK
                    Else
                        MessageBox.Show(My.Computer.ResourceMgr.GetString("0147") & " " & RP & " - " & Cow.GetFromDB(RP, Cow.COW).Name, My.Computer.ResourceMgr.GetString("0239"), MessageBoxButtons.OK, MessageBoxIcon.Error)
                    End If
                Next


            Else
                MessageBox.Show(My.Computer.ResourceMgr.GetString("0169"), My.Computer.ResourceMgr.GetString("0239"), MessageBoxButtons.OK, MessageBoxIcon.Error)
            End If
        Else
            If RPIn.Value > 0 And TextBox1.Text.Length > 0 And DateTime.Compare(DateTimePicker1.Value, DateTimePicker3.Value) < 0 Then
                If ValidateEvent(RPIn.Value) Then
                    LifeEvent.InsertIntoDB(New LifeEvent(RPIn.Value, DateTimePicker1.Value, LifeEvent.IDA_RECRIA, Nothing, TextBox1.Text, DateTimePicker3.Value.ToString("yyyy-MM-dd"), Nothing))
                    DialogResult = DialogResult.OK
                Else
                    MessageBox.Show(My.Computer.ResourceMgr.GetString("0169"), My.Computer.ResourceMgr.GetString("0239"), MessageBoxButtons.OK, MessageBoxIcon.Error)
                End If

            Else
                MessageBox.Show(My.Computer.ResourceMgr.GetString("0169"), My.Computer.ResourceMgr.GetString("0239"), MessageBoxButtons.OK, MessageBoxIcon.Error)
            End If
        End If

    End Sub

    Private Function ValidateEvent(ByVal RP As Integer) As Boolean
        If LifeEvent.GetLastEvtOfType(RP, LifeEvent.IDA_RECRIA, DateTimePicker1.Value) IsNot Nothing Then
            Return False
        End If
        If DateDiff(DateInterval.Day, Cow.GetFromDB(RP, Cow.COW).Birth, DateTimePicker1.Value) > My.Settings.Vaquillona Then
            Return False
        End If
        If DateDiff(DateInterval.Day, Cow.GetFromDB(RP, Cow.COW).Birth, DateTimePicker1.Value) < 0 Then
            Return False
        End If
        Return True
    End Function

    Private Sub DateTimePicker1_ValueChanged(sender As Object, e As EventArgs) Handles DateTimePicker1.ValueChanged
        RPIn.Value = 0
        DateTimePicker3.Value = DateTimePicker1.Value
    End Sub
End Class