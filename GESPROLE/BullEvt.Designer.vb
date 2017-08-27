Imports System.Globalization
Imports System.Threading

<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class BullEvt
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(BullEvt))
        Me.Label5 = New System.Windows.Forms.Label()
        Me.ComboBox1 = New System.Windows.Forms.ComboBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.DateTimePicker1 = New System.Windows.Forms.DateTimePicker()
        Me.Accept = New System.Windows.Forms.Button()
        Me.Cancel = New System.Windows.Forms.Button()
        Me.BullSearch = New System.Windows.Forms.Button()
        Me.RPIn = New System.Windows.Forms.NumericUpDown()
        Me.ToolTip1 = New System.Windows.Forms.ToolTip(Me.components)
        CType(Me.RPIn, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Label5
        '
        resources.ApplyResources(Me.Label5, "Label5")
        Me.Label5.Name = "Label5"
        Me.ToolTip1.SetToolTip(Me.Label5, resources.GetString("Label5.ToolTip"))
        '
        'ComboBox1
        '
        resources.ApplyResources(Me.ComboBox1, "ComboBox1")
        Me.ComboBox1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.ComboBox1.FormattingEnabled = True
        Me.ComboBox1.Items.AddRange(New Object() {resources.GetString("ComboBox1.Items"), resources.GetString("ComboBox1.Items1")})
        Me.ComboBox1.Name = "ComboBox1"
        Me.ToolTip1.SetToolTip(Me.ComboBox1, resources.GetString("ComboBox1.ToolTip"))
        '
        'Label1
        '
        resources.ApplyResources(Me.Label1, "Label1")
        Me.Label1.Name = "Label1"
        Me.ToolTip1.SetToolTip(Me.Label1, resources.GetString("Label1.ToolTip"))
        '
        'DateTimePicker1
        '
        resources.ApplyResources(Me.DateTimePicker1, "DateTimePicker1")
        Me.DateTimePicker1.Name = "DateTimePicker1"
        Me.ToolTip1.SetToolTip(Me.DateTimePicker1, resources.GetString("DateTimePicker1.ToolTip"))
        '
        'Accept
        '
        resources.ApplyResources(Me.Accept, "Accept")
        Me.Accept.Name = "Accept"
        Me.ToolTip1.SetToolTip(Me.Accept, resources.GetString("Accept.ToolTip"))
        Me.Accept.UseVisualStyleBackColor = True
        '
        'Cancel
        '
        resources.ApplyResources(Me.Cancel, "Cancel")
        Me.Cancel.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.Cancel.Name = "Cancel"
        Me.ToolTip1.SetToolTip(Me.Cancel, resources.GetString("Cancel.ToolTip"))
        Me.Cancel.UseVisualStyleBackColor = True
        '
        'BullSearch
        '
        resources.ApplyResources(Me.BullSearch, "BullSearch")
        Me.BullSearch.Name = "BullSearch"
        Me.ToolTip1.SetToolTip(Me.BullSearch, resources.GetString("BullSearch.ToolTip"))
        Me.BullSearch.UseVisualStyleBackColor = True
        '
        'RPIn
        '
        resources.ApplyResources(Me.RPIn, "RPIn")
        Me.RPIn.Maximum = New Decimal(New Integer() {999999999, 0, 0, 0})
        Me.RPIn.Name = "RPIn"
        Me.ToolTip1.SetToolTip(Me.RPIn, resources.GetString("RPIn.ToolTip"))
        '
        'BullEvt
        '
        Me.AcceptButton = Me.Accept
        resources.ApplyResources(Me, "$this")
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.CancelButton = Me.Cancel
        Me.ControlBox = False
        Me.Controls.Add(Me.BullSearch)
        Me.Controls.Add(Me.RPIn)
        Me.Controls.Add(Me.Cancel)
        Me.Controls.Add(Me.Accept)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.ComboBox1)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.DateTimePicker1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "BullEvt"
        Me.ToolTip1.SetToolTip(Me, resources.GetString("$this.ToolTip"))
        CType(Me.RPIn, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Label5 As Label
    Friend WithEvents ComboBox1 As ComboBox
    Friend WithEvents Label1 As Label
    Friend WithEvents DateTimePicker1 As DateTimePicker
    Friend WithEvents Accept As Button
    Friend WithEvents Cancel As Button
    Friend WithEvents BullSearch As Button
    Friend WithEvents RPIn As NumericUpDown
    Friend WithEvents ToolTip1 As ToolTip
End Class
