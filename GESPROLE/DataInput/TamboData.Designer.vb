Imports System.Globalization
Imports System.Threading

<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class TamboData
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(TamboData))
        Me.NameIn = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.MailIn = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.AddrIn = New System.Windows.Forms.TextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.HecIn = New System.Windows.Forms.NumericUpDown()
        Me.Cancel_Button = New System.Windows.Forms.Button()
        Me.Accept_Button = New System.Windows.Forms.Button()
        Me.CapacityIn = New System.Windows.Forms.NumericUpDown()
        Me.Label5 = New System.Windows.Forms.Label()
        CType(Me.HecIn, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.CapacityIn, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'NameIn
        '
        resources.ApplyResources(Me.NameIn, "NameIn")
        Me.NameIn.Name = "NameIn"
        '
        'Label1
        '
        resources.ApplyResources(Me.Label1, "Label1")
        Me.Label1.Name = "Label1"
        '
        'MailIn
        '
        resources.ApplyResources(Me.MailIn, "MailIn")
        Me.MailIn.Name = "MailIn"
        '
        'Label2
        '
        resources.ApplyResources(Me.Label2, "Label2")
        Me.Label2.Name = "Label2"
        '
        'AddrIn
        '
        resources.ApplyResources(Me.AddrIn, "AddrIn")
        Me.AddrIn.Name = "AddrIn"
        '
        'Label3
        '
        resources.ApplyResources(Me.Label3, "Label3")
        Me.Label3.Name = "Label3"
        '
        'Label4
        '
        resources.ApplyResources(Me.Label4, "Label4")
        Me.Label4.Name = "Label4"
        '
        'HecIn
        '
        resources.ApplyResources(Me.HecIn, "HecIn")
        Me.HecIn.Maximum = New Decimal(New Integer() {9999999, 0, 0, 0})
        Me.HecIn.Name = "HecIn"
        '
        'Cancel_Button
        '
        resources.ApplyResources(Me.Cancel_Button, "Cancel_Button")
        Me.Cancel_Button.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.Cancel_Button.Name = "Cancel_Button"
        Me.Cancel_Button.UseVisualStyleBackColor = True
        '
        'Accept_Button
        '
        resources.ApplyResources(Me.Accept_Button, "Accept_Button")
        Me.Accept_Button.Name = "Accept_Button"
        Me.Accept_Button.UseVisualStyleBackColor = True
        '
        'CapacityIn
        '
        resources.ApplyResources(Me.CapacityIn, "CapacityIn")
        Me.CapacityIn.Maximum = New Decimal(New Integer() {9999999, 0, 0, 0})
        Me.CapacityIn.Name = "CapacityIn"
        '
        'Label5
        '
        resources.ApplyResources(Me.Label5, "Label5")
        Me.Label5.Name = "Label5"
        '
        'TamboData
        '
        Me.AcceptButton = Me.Accept_Button
        resources.ApplyResources(Me, "$this")
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.CancelButton = Me.Cancel_Button
        Me.ControlBox = False
        Me.Controls.Add(Me.CapacityIn)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.Cancel_Button)
        Me.Controls.Add(Me.Accept_Button)
        Me.Controls.Add(Me.HecIn)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.AddrIn)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.MailIn)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.NameIn)
        Me.Controls.Add(Me.Label1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.Name = "TamboData"
        CType(Me.HecIn, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.CapacityIn, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents NameIn As TextBox
    Friend WithEvents Label1 As Label
    Friend WithEvents MailIn As TextBox
    Friend WithEvents Label2 As Label
    Friend WithEvents AddrIn As TextBox
    Friend WithEvents Label3 As Label
    Friend WithEvents Label4 As Label
    Friend WithEvents HecIn As NumericUpDown
    Friend WithEvents Cancel_Button As Button
    Friend WithEvents Accept_Button As Button
    Friend WithEvents CapacityIn As NumericUpDown
    Friend WithEvents Label5 As Label
End Class
