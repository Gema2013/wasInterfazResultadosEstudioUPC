<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Form2
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
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.txtPacienteID = New System.Windows.Forms.TextBox()
        Me.txtCodigoUPC = New System.Windows.Forms.TextBox()
        Me.txtPsw = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.txtRespuesta = New System.Windows.Forms.TextBox()
        Me.SuspendLayout()
        '
        'Button1
        '
        Me.Button1.Location = New System.Drawing.Point(309, 33)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(75, 51)
        Me.Button1.TabIndex = 0
        Me.Button1.Text = "Consumir"
        Me.Button1.UseVisualStyleBackColor = True
        '
        'txtPacienteID
        '
        Me.txtPacienteID.Location = New System.Drawing.Point(85, 65)
        Me.txtPacienteID.Name = "txtPacienteID"
        Me.txtPacienteID.Size = New System.Drawing.Size(100, 20)
        Me.txtPacienteID.TabIndex = 1
        Me.txtPacienteID.Text = "354078"
        '
        'txtCodigoUPC
        '
        Me.txtCodigoUPC.Location = New System.Drawing.Point(85, 12)
        Me.txtCodigoUPC.Name = "txtCodigoUPC"
        Me.txtCodigoUPC.Size = New System.Drawing.Size(100, 20)
        Me.txtCodigoUPC.TabIndex = 2
        Me.txtCodigoUPC.Text = "3599"
        '
        'txtPsw
        '
        Me.txtPsw.Location = New System.Drawing.Point(85, 38)
        Me.txtPsw.Name = "txtPsw"
        Me.txtPsw.Size = New System.Drawing.Size(100, 20)
        Me.txtPsw.TabIndex = 3
        Me.txtPsw.Text = "ION"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(12, 19)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(62, 13)
        Me.Label1.TabIndex = 4
        Me.Label1.Text = "Clave UPC:"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(12, 45)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(27, 13)
        Me.Label2.TabIndex = 5
        Me.Label2.Text = "Psw"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(12, 71)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(63, 13)
        Me.Label3.TabIndex = 6
        Me.Label3.Text = "Paciente ID"
        '
        'txtRespuesta
        '
        Me.txtRespuesta.Location = New System.Drawing.Point(15, 119)
        Me.txtRespuesta.Multiline = True
        Me.txtRespuesta.Name = "txtRespuesta"
        Me.txtRespuesta.Size = New System.Drawing.Size(369, 159)
        Me.txtRespuesta.TabIndex = 7
        Me.txtRespuesta.Text = "Respuesta"
        '
        'Form2
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(396, 290)
        Me.Controls.Add(Me.txtRespuesta)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.txtPsw)
        Me.Controls.Add(Me.txtCodigoUPC)
        Me.Controls.Add(Me.txtPacienteID)
        Me.Controls.Add(Me.Button1)
        Me.Name = "Form2"
        Me.Text = "Form2"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents Button1 As Button
    Friend WithEvents txtPacienteID As TextBox
    Friend WithEvents txtCodigoUPC As TextBox
    Friend WithEvents txtPsw As TextBox
    Friend WithEvents Label1 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents Label3 As Label
    Friend WithEvents txtRespuesta As TextBox
End Class
