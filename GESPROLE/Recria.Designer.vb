Imports System.Globalization
Imports System.Threading

<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class Recria
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
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Recria))
        Me.CowSearch = New System.Windows.Forms.Button()
        Me.RPIn = New System.Windows.Forms.NumericUpDown()
        Me.RPLabel = New System.Windows.Forms.Label()
        Me.DateTimePicker1 = New System.Windows.Forms.DateTimePicker()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Accept = New System.Windows.Forms.Button()
        Me.TextBox1 = New System.Windows.Forms.TextBox()
        Me.DateTimePicker3 = New System.Windows.Forms.DateTimePicker()
        Me.Cancel_Button = New System.Windows.Forms.Button()
        Me.Info = New System.Windows.Forms.ToolTip(Me.components)
        CType(Me.RPIn, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'CowSearch
        '
        resources.ApplyResources(Me.CowSearch, "CowSearch")
        Me.CowSearch.Name = "CowSearch"
        Me.Info.SetToolTip(Me.CowSearch, resources.GetString("CowSearch.ToolTip"))
        Me.CowSearch.UseVisualStyleBackColor = True
        '
        'RPIn
        '
        resources.ApplyResources(Me.RPIn, "RPIn")
        Me.RPIn.Maximum = New Decimal(New Integer() {999999999, 0, 0, 0})
        Me.RPIn.Name = "RPIn"
        Me.Info.SetToolTip(Me.RPIn, resources.GetString("RPIn.ToolTip"))
        '
        'RPLabel
        '
        resources.ApplyResources(Me.RPLabel, "RPLabel")
        Me.RPLabel.Name = "RPLabel"
        Me.Info.SetToolTip(Me.RPLabel, resources.GetString("RPLabel.ToolTip"))
        '
        'DateTimePicker1
        '
        resources.ApplyResources(Me.DateTimePicker1, "DateTimePicker1")
        Me.DateTimePicker1.Name = "DateTimePicker1"
        Me.Info.SetToolTip(Me.DateTimePicker1, resources.GetString("DateTimePicker1.ToolTip"))
        '
        'Label3
        '
        resources.ApplyResources(Me.Label3, "Label3")
        Me.Label3.Name = "Label3"
        Me.Info.SetToolTip(Me.Label3, resources.GetString("Label3.ToolTip"))
        '
        'Label1
        '
        resources.ApplyResources(Me.Label1, "Label1")
        Me.Label1.Name = "Label1"
        Me.Info.SetToolTip(Me.Label1, resources.GetString("Label1.ToolTip"))
        '
        'Accept
        '
        resources.ApplyResources(Me.Accept, "Accept")
        Me.Accept.Name = "Accept"
        Me.Info.SetToolTip(Me.Accept, resources.GetString("Accept.ToolTip"))
        Me.Accept.UseVisualStyleBackColor = True
        '
        'TextBox1
        '
        resources.ApplyResources(Me.TextBox1, "TextBox1")
        Me.TextBox1.Name = "TextBox1"
        Me.Info.SetToolTip(Me.TextBox1, resources.GetString("TextBox1.ToolTip"))
        '
        'DateTimePicker3
        '
        resources.ApplyResources(Me.DateTimePicker3, "DateTimePicker3")
        Me.DateTimePicker3.Name = "DateTimePicker3"
        Me.Info.SetToolTip(Me.DateTimePicker3, resources.GetString("DateTimePicker3.ToolTip"))
        '
        'Cancel_Button
        '
        resources.ApplyResources(Me.Cancel_Button, "Cancel_Button")
        Me.Cancel_Button.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.Cancel_Button.Name = "Cancel_Button"
        Me.Info.SetToolTip(Me.Cancel_Button, resources.GetString("Cancel_Button.ToolTip"))
        Me.Cancel_Button.UseVisualStyleBackColor = True
        '
        'Recria
        '
        Me.AcceptButton = Me.Accept
        resources.ApplyResources(Me, "$this")
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.CancelButton = Me.Cancel_Button
        Me.ControlBox = False
        Me.Controls.Add(Me.Cancel_Button)
        Me.Controls.Add(Me.DateTimePicker3)
        Me.Controls.Add(Me.TextBox1)
        Me.Controls.Add(Me.Accept)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.CowSearch)
        Me.Controls.Add(Me.RPIn)
        Me.Controls.Add(Me.RPLabel)
        Me.Controls.Add(Me.DateTimePicker1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.Name = "Recria"
        Me.Info.SetToolTip(Me, resources.GetString("$this.ToolTip"))
        CType(Me.RPIn, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents CowSearch As Button
    Friend WithEvents RPIn As NumericUpDown
    Friend WithEvents RPLabel As Label
    Friend WithEvents DateTimePicker1 As DateTimePicker
    Friend WithEvents Label3 As Label
    Friend WithEvents Label1 As Label
    Friend WithEvents Accept As Button
    Friend WithEvents TextBox1 As TextBox
    Friend WithEvents DateTimePicker3 As DateTimePicker
    Friend WithEvents Cancel_Button As Button
    Friend WithEvents Info As ToolTip
End Class
