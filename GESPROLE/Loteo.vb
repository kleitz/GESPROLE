Public Class Loteo
    Private Sub Loteo_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ReloadData(Lot.GetFromDB(My.Settings.Establishment))
    End Sub

    Private Sub Lact_CheckedChanged(sender As Object, e As EventArgs) Handles Lact.CheckedChanged
        LactFrom.Enabled = Lact.Checked
        LactTo.Enabled = Lact.Checked

        LactFrom.Value = 0
        LactTo.Value = 0
    End Sub

    Private Sub Prod_CheckedChanged(sender As Object, e As EventArgs) Handles Prod.CheckedChanged
        ProdTo.Enabled = Prod.Checked
        ProdFrom.Enabled = Prod.Checked

        ProdFrom.Value = 0
        ProdTo.Value = 0
    End Sub

    Private Sub Birth_CheckedChanged(sender As Object, e As EventArgs) Handles Birth.CheckedChanged
        BirthTo.Enabled = Birth.Checked
        BirthFrom.Enabled = Birth.Checked

        BirthFrom.Value = 0
        BirthTo.Value = 0
    End Sub

    Private Sub Repr_CheckedChanged(sender As Object, e As EventArgs) Handles Repr.CheckedChanged
        Pregnant.Enabled = Repr.Checked
        Empty.Enabled = Repr.Checked
    End Sub

    Private Sub ListView1_DoubleClick(sender As Object, e As EventArgs) Handles ListView1.DoubleClick
        VerListadoToolStripMenuItem_Click(Nothing, Nothing)
    End Sub

    Private Sub ListView1_MouseClick(sender As Object, e As MouseEventArgs) Handles ListView1.MouseClick
        Select Case e.Button
            Case MouseButtons.Right
                If ListView1.FocusedItem.Bounds.Contains(e.Location) Then
                    ContextMenuStrip1.Show(Cursor.Position)
                End If
        End Select
    End Sub

    Private Sub ListView1_KeyPress(sender As Object, e As KeyPressEventArgs) Handles ListView1.KeyPress
        Select Case e.KeyChar
            Case ControlChars.Back
                Dim Result As DialogResult = MessageBox.Show(My.Computer.ResourceMgr.GetString("0160") & " " & ListView1.FocusedItem.Text & "?", My.Computer.ResourceMgr.GetString("0161"), MessageBoxButtons.OKCancel, MessageBoxIcon.Question)
                If Result = DialogResult.OK Then
                    ListView1.Items.Remove(ListView1.FocusedItem)
                End If
        End Select
    End Sub

    Private Sub VerListadoToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles VerListadoToolStripMenuItem.Click
        If ListView1.FocusedItem IsNot Nothing Then
            Dim ListWin As New List
            ListWin.ShowMe = List.LOT
            ListWin.Value = ListView1.FocusedItem.Text
            ListWin.ShowDialog(Me)
        End If
    End Sub

    Private Sub EditarToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles EditarToolStripMenuItem.Click
        If ListView1.FocusedItem IsNot Nothing Then
            PopulateFields(Lot.GetFromDB(ListView1.FocusedItem.Text, My.Settings.Establishment))
            NameIn.Enabled = False
        End If
    End Sub

    Private Sub EliminarToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles EliminarToolStripMenuItem.Click
        If ListView1.FocusedItem IsNot Nothing Then
            Lot.DeleteFromDB(ListView1.FocusedItem.Text)
            ListView1.Items.Remove(ListView1.FocusedItem)
        End If
    End Sub

    Private Sub Register_Click(sender As Object, e As EventArgs) Handles Button1.Click
        If NameIn.Text.Length > 0 Then
            Dim State As Integer
            If Repr.Checked Then
                If Pregnant.Checked Then
                    State = LifeEvent.PRENADA
                Else
                    State = LifeEvent.VACIA
                End If
            Else
                State = 1
            End If


            If NameIn.Enabled Then
                Lot.InsertIntoDB(New Lot(NameIn.Text, State, BirthFrom.Value, BirthTo.Value, LactFrom.Value, LactTo.Value, ProdFrom.Value, ProdTo.Value))
            Else
                Lot.UpdateInDB(New Lot(NameIn.Text, State, BirthFrom.Value, BirthTo.Value, LactFrom.Value, LactTo.Value, ProdFrom.Value, ProdTo.Value))
            End If

            ReloadData(Lot.GetFromDB(My.Settings.Establishment))
            ClearFields()
        Else
            MessageBox.Show(My.Computer.ResourceMgr.GetString("0262"), My.Computer.ResourceMgr.GetString("0239"), MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return
        End If
    End Sub

    Private Sub ClearButton_Click(sender As Object, e As EventArgs) Handles ClearButton.Click
        ClearFields()
    End Sub

    'ListView1 Adapter'

    Public Sub ReloadData(ByVal Items As Collection)
        ListView1.Items.Clear()

        For Each Item As Lot In Items
            ListView1.Items.Add(Item.Name)
            ListView1.Items(ListView1.Items.Count - 1).SubItems.Add(Item.LactFrom & "-" & Item.LactTo)
            ListView1.Items(ListView1.Items.Count - 1).SubItems.Add(Item.ProductionFrom & "-" & Item.ProductionTo)
            ListView1.Items(ListView1.Items.Count - 1).SubItems.Add(Item.BirthsFrom & "-" & Item.BirthsTo)
            Select Case Item.State
                Case LifeEvent.VACIA
                    ListView1.Items(ListView1.Items.Count - 1).SubItems.Add(My.Computer.ResourceMgr.GetString("0253"))
                Case LifeEvent.PRENADA
                    ListView1.Items(ListView1.Items.Count - 1).SubItems.Add(My.Computer.ResourceMgr.GetString("0254"))
                Case Else
                    ListView1.Items(ListView1.Items.Count - 1).SubItems.Add("-")
            End Select
        Next
    End Sub

    Public Sub PopulateFields(ByVal Lote As Lot)
        NameIn.Text = Lote.Name
        If Lote.LactFrom = 0 And Lote.LactTo = 0 Then
            Lact.Checked = False
        Else
            LactFrom.Value = Lote.LactFrom
            LactTo.Value = Lote.LactTo
        End If
        If Lote.ProductionFrom = 0 And Lote.ProductionTo = 0 Then
            Prod.Checked = False
        Else
            ProdFrom.Value = Lote.ProductionFrom
            ProdTo.Value = Lote.ProductionTo
        End If
        If Lote.BirthsFrom = 0 And Lote.BirthsTo = 0 Then
            Birth.Checked = False
        Else
            BirthFrom.Value = Lote.BirthsFrom
            BirthTo.Value = Lote.BirthsTo
        End If
        Select Case Lote.State
            Case LifeEvent.PRENADA
                Pregnant.Checked = True
            Case LifeEvent.VACIA
                Empty.Checked = True
            Case Else
                Repr.Checked = False
        End Select
    End Sub

    Public Sub ClearFields()
        NameIn.Text = ""
        LactFrom.Value = 0
        LactTo.Value = 0
        ProdFrom.Value = 0
        ProdTo.Value = 0
        BirthFrom.Value = 0
        BirthTo.Value = 0
        Pregnant.Checked = True

        NameIn.Enabled = True
        Lact.Checked = True
        Prod.Checked = True
        Birth.Checked = True
        Repr.Checked = True
    End Sub
End Class