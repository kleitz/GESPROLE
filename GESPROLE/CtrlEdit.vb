Imports System.ComponentModel

Public Class CtrlEdit
    Public Property Mode As Integer = 1 'In this property the number of milkings is to be passed...'
    Private Property Index As Integer
    Public Property MilkControls As Collection

    Sub New(ByVal NewIndex As Integer, ByVal NewControls As Collection)

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.

        Index = NewIndex
        MilkControls = NewControls

    End Sub

    Private Sub CtrlEdit_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Select Case Mode
            Case 1
            Case 2
                OrdeneTwoIn.Visible = True
                OrdeneTwoLabel.Visible = True
            Case 3
                OrdeneTwoIn.Visible = True
                OrdeneTwoLabel.Visible = True
                OrdeneThreeIn.Visible = True
                OrdeneThreeLabel.Visible = True
            Case Else
                Throw New Exception
        End Select
        ChangeIndex(Index)
    End Sub

    Private Sub AcceptClick(sender As Object, e As EventArgs) Handles Accept_Button.Click
        If Ready() Then
            UpdateControlForCurrentCow()
            DialogResult = DialogResult.OK
        Else
            MessageBox.Show(My.Computer.ResourceMgr.GetString("0172"), My.Computer.ResourceMgr.GetString("0239"), MessageBoxButtons.OK, MessageBoxIcon.Error)
        End If
    End Sub

    Private Sub NextCowClick(sender As Object, e As EventArgs) Handles NextCowButton.Click
        If Ready() Then
            UpdateControlForCurrentCow()
            Index += 1
            Try
                ChangeIndex(Index)
            Catch ex As System.IndexOutOfRangeException
                Index -= 1
                MessageBox.Show(My.Computer.ResourceMgr.GetString("0285"), My.Computer.ResourceMgr.GetString("0239"), MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try
        Else
            MessageBox.Show(My.Computer.ResourceMgr.GetString("0172"), My.Computer.ResourceMgr.GetString("0239"), MessageBoxButtons.OK, MessageBoxIcon.Error)
        End If
    End Sub

    Private Sub PreviousCowButton_Click(sender As Object, e As EventArgs) Handles PreviousCowButton.Click
        If Ready() Then
            UpdateControlForCurrentCow()
            Index -= 1
            Try
                ChangeIndex(Index)
            Catch ex As System.IndexOutOfRangeException
                Index += 1
                MessageBox.Show(My.Computer.ResourceMgr.GetString("0285"), My.Computer.ResourceMgr.GetString("0239"), MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try
        Else
            MessageBox.Show(My.Computer.ResourceMgr.GetString("0172"), My.Computer.ResourceMgr.GetString("0239"), MessageBoxButtons.OK, MessageBoxIcon.Error)
        End If
    End Sub

    Public Sub ChangeIndex(ByVal NewIndex As Integer)
        TextBox1.Text = Convert.ToString(CType(MilkControls(NewIndex), MilkControl).RP)

        If CType(MilkControls(NewIndex), MilkControl).Milkings.Count > 0 Then
            Select Case Mode
                Case 1
                    If CType(MilkControls(NewIndex), MilkControl).Milkings(1) IsNot Nothing Then
                        OrdeneOneIn.Value = CType(CType(MilkControls(NewIndex), MilkControl).Milkings(1), MilkControl.Milking).Qty
                    End If
                Case 2
                    If CType(MilkControls(NewIndex), MilkControl).Milkings(1) IsNot Nothing Then
                        OrdeneOneIn.Value = CType(CType(MilkControls(NewIndex), MilkControl).Milkings(1), MilkControl.Milking).Qty
                    End If
                    If CType(MilkControls(NewIndex), MilkControl).Milkings(2) IsNot Nothing Then
                        OrdeneTwoIn.Value = CType(CType(MilkControls(NewIndex), MilkControl).Milkings(2), MilkControl.Milking).Qty
                    End If
                Case 3
                    If CType(MilkControls(NewIndex), MilkControl).Milkings(1) IsNot Nothing Then
                        OrdeneOneIn.Value = CType(CType(MilkControls(NewIndex), MilkControl).Milkings(1), MilkControl.Milking).Qty
                    End If
                    If CType(MilkControls(NewIndex), MilkControl).Milkings(2) IsNot Nothing Then
                        OrdeneTwoIn.Value = CType(CType(MilkControls(NewIndex), MilkControl).Milkings(2), MilkControl.Milking).Qty
                    End If
                    If CType(MilkControls(NewIndex), MilkControl).Milkings(3) IsNot Nothing Then
                        OrdeneThreeIn.Value = CType(CType(MilkControls(NewIndex), MilkControl).Milkings(3), MilkControl.Milking).Qty
                    End If
            End Select
        End If


        Protein.Value = CType(MilkControls(NewIndex), MilkControl).Proteins
        Fat.Value = CType(MilkControls(NewIndex), MilkControl).Fat
        Lactose.Value = CType(MilkControls(NewIndex), MilkControl).Lactose
        SomCell.Value = CType(MilkControls(NewIndex), MilkControl).SomCel
        SMB.Value = CType(MilkControls(NewIndex), MilkControl).Water
        Bact.Value = CType(MilkControls(NewIndex), MilkControl).Bacteria
    End Sub

    Private Sub UpdateControlForCurrentCow()
        CType(MilkControls(Index), MilkControl).EditMilking(1, Nothing, Nothing, OrdeneOneIn.Value)
        If OrdeneTwoIn.Visible Then
            CType(MilkControls(Index), MilkControl).EditMilking(2, Nothing, Nothing, OrdeneTwoIn.Value)
        End If
        If OrdeneThreeIn.Visible Then
            CType(MilkControls(Index), MilkControl).EditMilking(3, Nothing, Nothing, OrdeneThreeIn.Value)
        End If

        CType(MilkControls(Index), MilkControl).Proteins = Protein.Value
        CType(MilkControls(Index), MilkControl).Fat = Fat.Value
        CType(MilkControls(Index), MilkControl).Lactose = Lactose.Value
        CType(MilkControls(Index), MilkControl).SomCel = SomCell.Value
        CType(MilkControls(Index), MilkControl).Water = SMB.Value
        CType(MilkControls(Index), MilkControl).Bacteria = Bact.Value
    End Sub

    Private Function Ready() As Boolean 'Returns true if all fields have been filled'
        If OrdeneOneIn.Value = 0 Then
            Return False
        End If
        If OrdeneTwoIn.Visible And OrdeneTwoIn.Value = 0 Then
            Return False
        End If
        If OrdeneThreeIn.Visible And OrdeneThreeIn.Value = 0 Then
            Return False
        End If
        If Protein.Value = 0 Then
            Return False
        End If
        If Fat.Value = 0 Then
            Return False
        End If
        If Lactose.Value = 0 Then
            Return False
        End If
        If SomCell.Value = 0 Then
            Return False
        End If
        If SMB.Value = 0 Then
            Return False
        End If
        If Bact.Value = 0 Then
            Return False
        End If
        Return True
    End Function

    Public Sub ClearWindow()
        Select Case Mode
            Case 1
                OrdeneOneIn.Value = 0
            Case 2
                OrdeneOneIn.Value = 0
                OrdeneTwoIn.Value = 0
            Case 3
                OrdeneOneIn.Value = 0
                OrdeneTwoIn.Value = 0
                OrdeneThreeIn.Value = 0
        End Select

        Protein.Value = 0
        Fat.Value = 0
        Lactose.Value = 0
        SomCell.Value = 0
        SMB.Value = 0
        Bact.Value = 0
    End Sub

    Private Sub CtrlEdit_Closing(sender As Object, e As CancelEventArgs) Handles Me.Closing
        If OrdeneOneIn.Value <> 0 Or OrdeneTwoIn.Value <> 0 Or OrdeneThreeIn.Value <> 0 Or Protein.Value <> 0 Or Fat.Value <> 0 Or SomCell.Value <> 0 Or Bact.Value <> 0 Or SMB.Value <> 0 Or Lactose.Value <> 0 Then
            Dim Result As DialogResult = MessageBox.Show(My.Computer.ResourceMgr.GetString("0196"), My.Computer.ResourceMgr.GetString("0242"), MessageBoxButtons.OKCancel, MessageBoxIcon.Warning)
            Select Case Result
                Case DialogResult.Cancel
                    e.Cancel = True
            End Select
        End If
    End Sub
End Class