Imports System.Globalization
Imports System.Threading

<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class EvtAdd
    Inherits System.Windows.Forms.Form

    'Form reemplaza a Dispose para limpiar la lista de componentes.
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

    'Requerido por el Diseñador de Windows Forms
    Private components As System.ComponentModel.IContainer

    'NOTA: el Diseñador de Windows Forms necesita el siguiente procedimiento
    'Se puede modificar usando el Diseñador de Windows Forms.  
    'No lo modifique con el editor de código.
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(EvtAdd))
        Me.DateTimePicker1 = New System.Windows.Forms.DateTimePicker()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.ComboBox1 = New System.Windows.Forms.ComboBox()
        Me.ComboBox2 = New System.Windows.Forms.ComboBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.Button2 = New System.Windows.Forms.Button()
        Me.Button4 = New System.Windows.Forms.Button()
        Me.Button3 = New System.Windows.Forms.Button()
        Me.ComboBox4 = New System.Windows.Forms.ComboBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.ComboBox3 = New System.Windows.Forms.ComboBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Accept_Button = New System.Windows.Forms.Button()
        Me.Cancel_Button = New System.Windows.Forms.Button()
        Me.RPLabel = New System.Windows.Forms.Label()
        Me.RPIn = New System.Windows.Forms.NumericUpDown()
        Me.CowSearch = New System.Windows.Forms.Button()
        Me.Info = New System.Windows.Forms.ToolTip(Me.components)
        Me.SearchBull = New System.Windows.Forms.Button()
        Me.BullIDIn = New System.Windows.Forms.NumericUpDown()
        Me.Noti = New System.Windows.Forms.CheckBox()
        CType(Me.RPIn, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.BullIDIn, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'DateTimePicker1
        '
        resources.ApplyResources(Me.DateTimePicker1, "DateTimePicker1")
        Me.DateTimePicker1.Name = "DateTimePicker1"
        Me.Info.SetToolTip(Me.DateTimePicker1, resources.GetString("DateTimePicker1.ToolTip"))
        '
        'Label1
        '
        resources.ApplyResources(Me.Label1, "Label1")
        Me.Label1.Name = "Label1"
        '
        'ComboBox1
        '
        Me.ComboBox1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        resources.ApplyResources(Me.ComboBox1, "ComboBox1")
        Me.ComboBox1.FormattingEnabled = True
        Me.ComboBox1.Name = "ComboBox1"
        '
        'ComboBox2
        '
        Me.ComboBox2.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        resources.ApplyResources(Me.ComboBox2, "ComboBox2")
        Me.ComboBox2.FormattingEnabled = True
        Me.ComboBox2.Name = "ComboBox2"
        '
        'Label2
        '
        resources.ApplyResources(Me.Label2, "Label2")
        Me.Label2.Name = "Label2"
        '
        'Button1
        '
        resources.ApplyResources(Me.Button1, "Button1")
        Me.Button1.Name = "Button1"
        Me.Info.SetToolTip(Me.Button1, resources.GetString("Button1.ToolTip"))
        Me.Button1.UseVisualStyleBackColor = True
        '
        'Button2
        '
        resources.ApplyResources(Me.Button2, "Button2")
        Me.Button2.Name = "Button2"
        Me.Info.SetToolTip(Me.Button2, resources.GetString("Button2.ToolTip"))
        Me.Button2.UseVisualStyleBackColor = True
        '
        'Button4
        '
        resources.ApplyResources(Me.Button4, "Button4")
        Me.Button4.Name = "Button4"
        Me.Info.SetToolTip(Me.Button4, resources.GetString("Button4.ToolTip"))
        Me.Button4.UseVisualStyleBackColor = True
        '
        'Button3
        '
        resources.ApplyResources(Me.Button3, "Button3")
        Me.Button3.Name = "Button3"
        Me.Info.SetToolTip(Me.Button3, resources.GetString("Button3.ToolTip"))
        Me.Button3.UseVisualStyleBackColor = True
        '
        'ComboBox4
        '
        Me.ComboBox4.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        resources.ApplyResources(Me.ComboBox4, "ComboBox4")
        Me.ComboBox4.FormattingEnabled = True
        Me.ComboBox4.Name = "ComboBox4"
        '
        'Label4
        '
        resources.ApplyResources(Me.Label4, "Label4")
        Me.Label4.Name = "Label4"
        '
        'ComboBox3
        '
        Me.ComboBox3.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        resources.ApplyResources(Me.ComboBox3, "ComboBox3")
        Me.ComboBox3.FormattingEnabled = True
        Me.ComboBox3.Name = "ComboBox3"
        '
        'Label3
        '
        resources.ApplyResources(Me.Label3, "Label3")
        Me.Label3.Name = "Label3"
        '
        'Accept_Button
        '
        resources.ApplyResources(Me.Accept_Button, "Accept_Button")
        Me.Accept_Button.Name = "Accept_Button"
        Me.Accept_Button.UseVisualStyleBackColor = True
        '
        'Cancel_Button
        '
        Me.Cancel_Button.DialogResult = System.Windows.Forms.DialogResult.Cancel
        resources.ApplyResources(Me.Cancel_Button, "Cancel_Button")
        Me.Cancel_Button.Name = "Cancel_Button"
        Me.Cancel_Button.UseVisualStyleBackColor = True
        '
        'RPLabel
        '
        resources.ApplyResources(Me.RPLabel, "RPLabel")
        Me.RPLabel.Name = "RPLabel"
        '
        'RPIn
        '
        resources.ApplyResources(Me.RPIn, "RPIn")
        Me.RPIn.Maximum = New Decimal(New Integer() {999999999, 0, 0, 0})
        Me.RPIn.Name = "RPIn"
        '
        'CowSearch
        '
        resources.ApplyResources(Me.CowSearch, "CowSearch")
        Me.CowSearch.Name = "CowSearch"
        Me.CowSearch.UseVisualStyleBackColor = True
        '
        'SearchBull
        '
        resources.ApplyResources(Me.SearchBull, "SearchBull")
        Me.SearchBull.Name = "SearchBull"
        Me.SearchBull.UseVisualStyleBackColor = True
        '
        'BullIDIn
        '
        resources.ApplyResources(Me.BullIDIn, "BullIDIn")
        Me.BullIDIn.Maximum = New Decimal(New Integer() {999999999, 0, 0, 0})
        Me.BullIDIn.Name = "BullIDIn"
        '
        'Noti
        '
        resources.ApplyResources(Me.Noti, "Noti")
        Me.Noti.Name = "Noti"
        Me.Noti.UseVisualStyleBackColor = True
        '
        'EvtAdd
        '
        Me.AcceptButton = Me.Accept_Button
        resources.ApplyResources(Me, "$this")
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.CancelButton = Me.Cancel_Button
        Me.ControlBox = False
        Me.Controls.Add(Me.Noti)
        Me.Controls.Add(Me.SearchBull)
        Me.Controls.Add(Me.BullIDIn)
        Me.Controls.Add(Me.CowSearch)
        Me.Controls.Add(Me.RPIn)
        Me.Controls.Add(Me.RPLabel)
        Me.Controls.Add(Me.Cancel_Button)
        Me.Controls.Add(Me.Accept_Button)
        Me.Controls.Add(Me.Button4)
        Me.Controls.Add(Me.Button3)
        Me.Controls.Add(Me.ComboBox4)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.ComboBox3)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Button2)
        Me.Controls.Add(Me.Button1)
        Me.Controls.Add(Me.ComboBox2)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.ComboBox1)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.DateTimePicker1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.Name = "EvtAdd"
        CType(Me.RPIn, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.BullIDIn, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents DateTimePicker1 As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents ComboBox1 As System.Windows.Forms.ComboBox
    Friend WithEvents ComboBox2 As System.Windows.Forms.ComboBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents Button2 As System.Windows.Forms.Button
    Friend WithEvents Button4 As System.Windows.Forms.Button
    Friend WithEvents Button3 As System.Windows.Forms.Button
    Friend WithEvents ComboBox4 As System.Windows.Forms.ComboBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents ComboBox3 As System.Windows.Forms.ComboBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Accept_Button As System.Windows.Forms.Button
    Friend WithEvents Cancel_Button As System.Windows.Forms.Button
    Friend WithEvents RPLabel As Label
    Friend WithEvents RPIn As NumericUpDown
    Friend WithEvents CowSearch As Button
    Friend WithEvents Info As ToolTip
    Friend WithEvents SearchBull As Button
    Friend WithEvents BullIDIn As NumericUpDown
    Friend WithEvents Noti As CheckBox
End Class
