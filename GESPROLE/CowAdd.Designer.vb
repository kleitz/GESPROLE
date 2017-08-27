Imports System.Globalization
Imports System.Threading

<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class CowAdd
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(CowAdd))
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Name_In = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Birth = New System.Windows.Forms.DateTimePicker()
        Me.Weight = New System.Windows.Forms.NumericUpDown()
        Me.Accept_Button = New System.Windows.Forms.Button()
        Me.Cancel_Button = New System.Windows.Forms.Button()
        Me.Background = New System.Windows.Forms.TextBox()
        Me.Procedencia_Label = New System.Windows.Forms.Label()
        Me.Breed = New System.Windows.Forms.ComboBox()
        Me.Info = New System.Windows.Forms.ToolTip(Me.components)
        CType(Me.Weight, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Label1
        '
        resources.ApplyResources(Me.Label1, "Label1")
        Me.Label1.Name = "Label1"
        Me.Info.SetToolTip(Me.Label1, resources.GetString("Label1.ToolTip"))
        '
        'Name_In
        '
        resources.ApplyResources(Me.Name_In, "Name_In")
        Me.Name_In.Name = "Name_In"
        Me.Info.SetToolTip(Me.Name_In, resources.GetString("Name_In.ToolTip"))
        '
        'Label2
        '
        resources.ApplyResources(Me.Label2, "Label2")
        Me.Label2.Name = "Label2"
        Me.Info.SetToolTip(Me.Label2, resources.GetString("Label2.ToolTip"))
        '
        'Label3
        '
        resources.ApplyResources(Me.Label3, "Label3")
        Me.Label3.Name = "Label3"
        Me.Info.SetToolTip(Me.Label3, resources.GetString("Label3.ToolTip"))
        '
        'Label4
        '
        resources.ApplyResources(Me.Label4, "Label4")
        Me.Label4.Name = "Label4"
        Me.Info.SetToolTip(Me.Label4, resources.GetString("Label4.ToolTip"))
        '
        'Birth
        '
        resources.ApplyResources(Me.Birth, "Birth")
        Me.Birth.Name = "Birth"
        Me.Info.SetToolTip(Me.Birth, resources.GetString("Birth.ToolTip"))
        '
        'Weight
        '
        resources.ApplyResources(Me.Weight, "Weight")
        Me.Weight.Maximum = New Decimal(New Integer() {500, 0, 0, 0})
        Me.Weight.Name = "Weight"
        Me.Info.SetToolTip(Me.Weight, resources.GetString("Weight.ToolTip"))
        '
        'Accept_Button
        '
        resources.ApplyResources(Me.Accept_Button, "Accept_Button")
        Me.Accept_Button.Name = "Accept_Button"
        Me.Info.SetToolTip(Me.Accept_Button, resources.GetString("Accept_Button.ToolTip"))
        Me.Accept_Button.UseVisualStyleBackColor = True
        '
        'Cancel_Button
        '
        resources.ApplyResources(Me.Cancel_Button, "Cancel_Button")
        Me.Cancel_Button.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.Cancel_Button.Name = "Cancel_Button"
        Me.Info.SetToolTip(Me.Cancel_Button, resources.GetString("Cancel_Button.ToolTip"))
        Me.Cancel_Button.UseVisualStyleBackColor = True
        '
        'Background
        '
        resources.ApplyResources(Me.Background, "Background")
        Me.Background.Name = "Background"
        Me.Info.SetToolTip(Me.Background, resources.GetString("Background.ToolTip"))
        '
        'Procedencia_Label
        '
        resources.ApplyResources(Me.Procedencia_Label, "Procedencia_Label")
        Me.Procedencia_Label.Name = "Procedencia_Label"
        Me.Info.SetToolTip(Me.Procedencia_Label, resources.GetString("Procedencia_Label.ToolTip"))
        '
        'Breed
        '
        resources.ApplyResources(Me.Breed, "Breed")
        Me.Breed.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.Breed.FormattingEnabled = True
        Me.Breed.Items.AddRange(New Object() {resources.GetString("Breed.Items"), resources.GetString("Breed.Items1"), resources.GetString("Breed.Items2"), resources.GetString("Breed.Items3")})
        Me.Breed.Name = "Breed"
        Me.Info.SetToolTip(Me.Breed, resources.GetString("Breed.ToolTip"))
        '
        'CowAdd
        '
        Me.AcceptButton = Me.Accept_Button
        resources.ApplyResources(Me, "$this")
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.CancelButton = Me.Cancel_Button
        Me.ControlBox = False
        Me.Controls.Add(Me.Breed)
        Me.Controls.Add(Me.Background)
        Me.Controls.Add(Me.Procedencia_Label)
        Me.Controls.Add(Me.Cancel_Button)
        Me.Controls.Add(Me.Accept_Button)
        Me.Controls.Add(Me.Weight)
        Me.Controls.Add(Me.Birth)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Name_In)
        Me.Controls.Add(Me.Label1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.Name = "CowAdd"
        Me.Info.SetToolTip(Me, resources.GetString("$this.ToolTip"))
        CType(Me.Weight, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Name_In As System.Windows.Forms.TextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Birth As System.Windows.Forms.DateTimePicker
    Friend WithEvents Weight As System.Windows.Forms.NumericUpDown
    Friend WithEvents Accept_Button As System.Windows.Forms.Button
    Friend WithEvents Cancel_Button As System.Windows.Forms.Button
    Friend WithEvents Background As TextBox
    Friend WithEvents Procedencia_Label As Label
    Friend WithEvents Breed As ComboBox
    Friend WithEvents Info As ToolTip
End Class
