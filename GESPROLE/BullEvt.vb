Public Class BullEvt
    Private Sub BullEvt_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ComboBox1.SelectedIndex = 0
    End Sub

    Private Sub BullSearch_Click(sender As Object, e As EventArgs) Handles BullSearch.Click
        Dim CowSearchWin As New CowSearch
        CowSearchWin.Mode = Cow.BULL
        CowSearchWin.ModeTwo = GESPROLE.CowSearch.SELECTION
        If CowSearchWin.ShowDialog(Me) = DialogResult.OK Then
            RPIn.Value = CowSearchWin.ReturnValue
        End If
    End Sub

    Private Sub Accept_Click(sender As Object, e As EventArgs) Handles Accept.Click
        If RPIn.Value > 0 And My.Settings.Privileges = 2 Then
            If DateDiff(DateInterval.Day, Cow.GetFromDB(RPIn.Value, Cow.BULL).Birth, DateTimePicker1.Value) < 0 Then
                MessageBox.Show(My.Computer.ResourceMgr.GetString("0145"), My.Computer.ResourceMgr.GetString("0239"), MessageBoxButtons.OK, MessageBoxIcon.Error)
                Return
            End If

            Select Case ComboBox1.SelectedItem.ToString
                Case My.Computer.ResourceMgr.GetString("0030").ToUpper
                    LifeEvent.InsertIntoDB(New LifeEvent(RPIn.Value, DateTimePicker1.Value, LifeEvent.MUERTE, Nothing, Nothing, Nothing, Nothing))
                Case My.Computer.ResourceMgr.GetString("0036").ToUpper
                    LifeEvent.InsertIntoDB(New LifeEvent(RPIn.Value, DateTimePicker1.Value, LifeEvent.VENTA, Nothing, Nothing, Nothing, Nothing))
            End Select

            DialogResult = DialogResult.OK
        ElseIf RPIn.Value = 0 Then
            MessageBox.Show(My.Computer.ResourceMgr.GetString("0279"), My.Computer.ResourceMgr.GetString("0239"), MessageBoxButtons.OK, MessageBoxIcon.Error)
        End If
    End Sub

    Private Sub Cancel_Click(sender As Object, e As EventArgs) Handles Cancel.Click
        Dim Result As DialogResult = MessageBox.Show(My.Computer.ResourceMgr.GetString("0108"), My.Computer.ResourceMgr.GetString("0242"), MessageBoxButtons.OKCancel, MessageBoxIcon.Question)
        Select Case Result
            Case DialogResult.OK
                DialogResult = DialogResult.Cancel
            Case DialogResult.Cancel
                DialogResult = DialogResult.None
        End Select
    End Sub

    Private Sub DateTimePicker1_ValueChanged(sender As Object, e As EventArgs) Handles DateTimePicker1.ValueChanged
        RPIn.Value = 0
    End Sub
End Class