Imports System.Globalization
Imports System.Threading

<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class CtrlEdit
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(CtrlEdit))
        Me.Label1 = New System.Windows.Forms.Label()
        Me.TextBox1 = New System.Windows.Forms.TextBox()
        Me.OrdeneOneIn = New System.Windows.Forms.NumericUpDown()
        Me.OrdeneTwoIn = New System.Windows.Forms.NumericUpDown()
        Me.OrdeneThreeIn = New System.Windows.Forms.NumericUpDown()
        Me.Protein = New System.Windows.Forms.NumericUpDown()
        Me.Fat = New System.Windows.Forms.NumericUpDown()
        Me.SomCell = New System.Windows.Forms.NumericUpDown()
        Me.Lactose = New System.Windows.Forms.NumericUpDown()
        Me.SMB = New System.Windows.Forms.NumericUpDown()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.OrdeneTwoLabel = New System.Windows.Forms.Label()
        Me.OrdeneThreeLabel = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.Bact = New System.Windows.Forms.NumericUpDown()
        Me.Accept_Button = New System.Windows.Forms.Button()
        Me.NextCowButton = New System.Windows.Forms.Button()
        Me.PreviousCowButton = New System.Windows.Forms.Button()
        CType(Me.OrdeneOneIn, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.OrdeneTwoIn, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.OrdeneThreeIn, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Protein, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Fat, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.SomCell, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Lactose, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.SMB, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox1.SuspendLayout()
        CType(Me.Bact, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Label1
        '
        resources.ApplyResources(Me.Label1, "Label1")
        Me.Label1.Name = "Label1"
        '
        'TextBox1
        '
        resources.ApplyResources(Me.TextBox1, "TextBox1")
        Me.TextBox1.Name = "TextBox1"
        '
        'OrdeneOneIn
        '
        resources.ApplyResources(Me.OrdeneOneIn, "OrdeneOneIn")
        Me.OrdeneOneIn.Name = "OrdeneOneIn"
        '
        'OrdeneTwoIn
        '
        resources.ApplyResources(Me.OrdeneTwoIn, "OrdeneTwoIn")
        Me.OrdeneTwoIn.Name = "OrdeneTwoIn"
        '
        'OrdeneThreeIn
        '
        resources.ApplyResources(Me.OrdeneThreeIn, "OrdeneThreeIn")
        Me.OrdeneThreeIn.Name = "OrdeneThreeIn"
        '
        'Protein
        '
        resources.ApplyResources(Me.Protein, "Protein")
        Me.Protein.Name = "Protein"
        '
        'Fat
        '
        resources.ApplyResources(Me.Fat, "Fat")
        Me.Fat.Name = "Fat"
        '
        'SomCell
        '
        resources.ApplyResources(Me.SomCell, "SomCell")
        Me.SomCell.Name = "SomCell"
        '
        'Lactose
        '
        resources.ApplyResources(Me.Lactose, "Lactose")
        Me.Lactose.Name = "Lactose"
        '
        'SMB
        '
        resources.ApplyResources(Me.SMB, "SMB")
        Me.SMB.Name = "SMB"
        '
        'Label2
        '
        resources.ApplyResources(Me.Label2, "Label2")
        Me.Label2.Name = "Label2"
        '
        'OrdeneTwoLabel
        '
        resources.ApplyResources(Me.OrdeneTwoLabel, "OrdeneTwoLabel")
        Me.OrdeneTwoLabel.Name = "OrdeneTwoLabel"
        '
        'OrdeneThreeLabel
        '
        resources.ApplyResources(Me.OrdeneThreeLabel, "OrdeneThreeLabel")
        Me.OrdeneThreeLabel.Name = "OrdeneThreeLabel"
        '
        'Label5
        '
        resources.ApplyResources(Me.Label5, "Label5")
        Me.Label5.Name = "Label5"
        '
        'Label6
        '
        resources.ApplyResources(Me.Label6, "Label6")
        Me.Label6.Name = "Label6"
        '
        'Label7
        '
        resources.ApplyResources(Me.Label7, "Label7")
        Me.Label7.Name = "Label7"
        '
        'Label8
        '
        resources.ApplyResources(Me.Label8, "Label8")
        Me.Label8.Name = "Label8"
        '
        'Label9
        '
        resources.ApplyResources(Me.Label9, "Label9")
        Me.Label9.Name = "Label9"
        '
        'GroupBox1
        '
        resources.ApplyResources(Me.GroupBox1, "GroupBox1")
        Me.GroupBox1.Controls.Add(Me.Label10)
        Me.GroupBox1.Controls.Add(Me.Bact)
        Me.GroupBox1.Controls.Add(Me.Fat)
        Me.GroupBox1.Controls.Add(Me.Label6)
        Me.GroupBox1.Controls.Add(Me.Label7)
        Me.GroupBox1.Controls.Add(Me.Label9)
        Me.GroupBox1.Controls.Add(Me.Label1)
        Me.GroupBox1.Controls.Add(Me.Lactose)
        Me.GroupBox1.Controls.Add(Me.SMB)
        Me.GroupBox1.Controls.Add(Me.Label8)
        Me.GroupBox1.Controls.Add(Me.TextBox1)
        Me.GroupBox1.Controls.Add(Me.OrdeneOneIn)
        Me.GroupBox1.Controls.Add(Me.Label2)
        Me.GroupBox1.Controls.Add(Me.Label5)
        Me.GroupBox1.Controls.Add(Me.OrdeneTwoIn)
        Me.GroupBox1.Controls.Add(Me.SomCell)
        Me.GroupBox1.Controls.Add(Me.OrdeneThreeLabel)
        Me.GroupBox1.Controls.Add(Me.OrdeneThreeIn)
        Me.GroupBox1.Controls.Add(Me.OrdeneTwoLabel)
        Me.GroupBox1.Controls.Add(Me.Protein)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.TabStop = False
        '
        'Label10
        '
        resources.ApplyResources(Me.Label10, "Label10")
        Me.Label10.Name = "Label10"
        '
        'Bact
        '
        resources.ApplyResources(Me.Bact, "Bact")
        Me.Bact.Name = "Bact"
        '
        'Accept_Button
        '
        resources.ApplyResources(Me.Accept_Button, "Accept_Button")
        Me.Accept_Button.Name = "Accept_Button"
        Me.Accept_Button.UseVisualStyleBackColor = True
        '
        'NextCowButton
        '
        resources.ApplyResources(Me.NextCowButton, "NextCowButton")
        Me.NextCowButton.Name = "NextCowButton"
        Me.NextCowButton.UseVisualStyleBackColor = True
        '
        'PreviousCowButton
        '
        resources.ApplyResources(Me.PreviousCowButton, "PreviousCowButton")
        Me.PreviousCowButton.Name = "PreviousCowButton"
        Me.PreviousCowButton.UseVisualStyleBackColor = True
        '
        'CtrlEdit
        '
        resources.ApplyResources(Me, "$this")
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.Controls.Add(Me.PreviousCowButton)
        Me.Controls.Add(Me.NextCowButton)
        Me.Controls.Add(Me.Accept_Button)
        Me.Controls.Add(Me.GroupBox1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "CtrlEdit"
        CType(Me.OrdeneOneIn, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.OrdeneTwoIn, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.OrdeneThreeIn, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Protein, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Fat, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.SomCell, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Lactose, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.SMB, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        CType(Me.Bact, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents Label1 As Label
    Friend WithEvents TextBox1 As TextBox
    Friend WithEvents OrdeneOneIn As NumericUpDown
    Friend WithEvents OrdeneTwoIn As NumericUpDown
    Friend WithEvents OrdeneThreeIn As NumericUpDown
    Friend WithEvents Protein As NumericUpDown
    Friend WithEvents Fat As NumericUpDown
    Friend WithEvents SomCell As NumericUpDown
    Friend WithEvents Lactose As NumericUpDown
    Friend WithEvents SMB As NumericUpDown
    Friend WithEvents Label2 As Label
    Friend WithEvents OrdeneTwoLabel As Label
    Friend WithEvents OrdeneThreeLabel As Label
    Friend WithEvents Label5 As Label
    Friend WithEvents Label6 As Label
    Friend WithEvents Label7 As Label
    Friend WithEvents Label8 As Label
    Friend WithEvents Label9 As Label
    Friend WithEvents GroupBox1 As GroupBox
    Friend WithEvents Label10 As Label
    Friend WithEvents Bact As NumericUpDown
    Friend WithEvents Accept_Button As Button
    Friend WithEvents NextCowButton As Button
    Friend WithEvents PreviousCowButton As Button
End Class
