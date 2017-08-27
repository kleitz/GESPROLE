Public Class Semen
    Private Sub Semen_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ReloadData(Cow.Semen.GetList())
    End Sub

    Private Sub Search_Click(sender As Object, e As EventArgs) Handles Search.Click
        Dim CowSearchWin As New CowSearch
        CowSearchWin.Mode = Cow.BULL
        CowSearchWin.ModeTwo = CowSearch.SELECTION
        CowSearchWin.WhenDoISearch = DateTimePicker1.Value
        If CowSearchWin.ShowDialog(Me) = DialogResult.OK Then
            IDIn.Value = CowSearchWin.ReturnValue
        End If
    End Sub

    Private Sub ReloadData(ByVal Items As Collection)
        ListView1.Items.Clear()

        Dim LowerPrivileges As String = ""

        If Not My.Settings.Establishment.Equals("") Then
            LowerPrivileges = My.Settings.Establishment
            My.Settings.Establishment = ""
        End If

        For Each Item As Cow.Semen In Items
            ListView1.Items.Add(Item.ID)
            ListView1.Items(ListView1.Items.Count - 1).SubItems.Add(Item.RP & " - " & Cow.GetFromDB(Item.RP, Cow.BULL).Name)
            ListView1.Items(ListView1.Items.Count - 1).SubItems.Add(Item.Time.ToString(My.Computer.ResourceMgr.GetString("0245")))
        Next

        If Not LowerPrivileges.Equals("") Then
            My.Settings.Establishment = LowerPrivileges
        End If
    End Sub

    Private Sub ClearFields()
        IDIn.Value = 0
        QtyIn.Value = 0
    End Sub

    Private Sub OKButton_Click(sender As Object, e As EventArgs) Handles OKButton.Click
        If IDIn.Value <> 0 And QtyIn.Value <> 0 Then
            If DateDiff(DateInterval.Day, Cow.GetFromDB(IDIn.Value, Cow.BULL).Birth, DateTimePicker1.Value) < 0 Then
                MessageBox.Show(My.Computer.ResourceMgr.GetString("0145"), My.Computer.ResourceMgr.GetString("0239"), MessageBoxButtons.OK, MessageBoxIcon.Error)
                Return
            End If

            For Index As Integer = 1 To QtyIn.Value
                Cow.Semen.InsertIntoDB(New Cow.Semen(0, DateTimePicker1.Value, IDIn.Value))
            Next

            ReloadData(Cow.Semen.GetList())
            ClearFields()
        Else
            MessageBox.Show(My.Computer.ResourceMgr.GetString("0169"), My.Computer.ResourceMgr.GetString("0239"), MessageBoxButtons.OK, MessageBoxIcon.Error)
        End If
    End Sub

    Private Sub DateTimePicker1_ValueChanged(sender As Object, e As EventArgs) Handles DateTimePicker1.ValueChanged
        IDIn.Value = 0
    End Sub
End Class