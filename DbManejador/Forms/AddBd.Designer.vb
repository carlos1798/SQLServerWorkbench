﻿<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class AddBd
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
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.passwdTextBox = New System.Windows.Forms.TextBox()
        Me.usrComboBox = New System.Windows.Forms.ComboBox()
        Me.Contrasena_pass = New System.Windows.Forms.Label()
        Me.Username_label = New System.Windows.Forms.Label()
        Me.Autenticacion = New System.Windows.Forms.ComboBox()
        Me.nomServidor = New System.Windows.Forms.ComboBox()
        Me.autenticacionLabel = New System.Windows.Forms.Label()
        Me.nombreServidorLabel = New System.Windows.Forms.Label()
        Me.ComboBox1 = New System.Windows.Forms.ComboBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.Button2 = New System.Windows.Forms.Button()
        Me.SuspendLayout()
        '
        'passwdTextBox
        '
        Me.passwdTextBox.Location = New System.Drawing.Point(242, 211)
        Me.passwdTextBox.Name = "passwdTextBox"
        Me.passwdTextBox.PasswordChar = Global.Microsoft.VisualBasic.ChrW(42)
        Me.passwdTextBox.Size = New System.Drawing.Size(226, 20)
        Me.passwdTextBox.TabIndex = 15
        '
        'usrComboBox
        '
        Me.usrComboBox.FormattingEnabled = True
        Me.usrComboBox.Location = New System.Drawing.Point(241, 184)
        Me.usrComboBox.Name = "usrComboBox"
        Me.usrComboBox.Size = New System.Drawing.Size(227, 21)
        Me.usrComboBox.TabIndex = 14
        '
        'Contrasena_pass
        '
        Me.Contrasena_pass.AutoSize = True
        Me.Contrasena_pass.Location = New System.Drawing.Point(93, 211)
        Me.Contrasena_pass.Name = "Contrasena_pass"
        Me.Contrasena_pass.Size = New System.Drawing.Size(61, 13)
        Me.Contrasena_pass.TabIndex = 13
        Me.Contrasena_pass.Text = "Contraseña"
        '
        'Username_label
        '
        Me.Username_label.AutoSize = True
        Me.Username_label.Location = New System.Drawing.Point(71, 184)
        Me.Username_label.Name = "Username_label"
        Me.Username_label.Size = New System.Drawing.Size(83, 13)
        Me.Username_label.TabIndex = 12
        Me.Username_label.Text = "Nombre Usuario"
        '
        'Autenticacion
        '
        Me.Autenticacion.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.Autenticacion.FormattingEnabled = True
        Me.Autenticacion.Items.AddRange(New Object() {"Autentificacion de Windows", "Autentificacion de SQL Server"})
        Me.Autenticacion.Location = New System.Drawing.Point(194, 108)
        Me.Autenticacion.Name = "Autenticacion"
        Me.Autenticacion.Size = New System.Drawing.Size(274, 21)
        Me.Autenticacion.TabIndex = 11
        '
        'nomServidor
        '
        Me.nomServidor.FormattingEnabled = True
        Me.nomServidor.Location = New System.Drawing.Point(194, 67)
        Me.nomServidor.Name = "nomServidor"
        Me.nomServidor.Size = New System.Drawing.Size(274, 21)
        Me.nomServidor.TabIndex = 10
        '
        'autenticacionLabel
        '
        Me.autenticacionLabel.AutoSize = True
        Me.autenticacionLabel.Location = New System.Drawing.Point(13, 108)
        Me.autenticacionLabel.Name = "autenticacionLabel"
        Me.autenticacionLabel.Size = New System.Drawing.Size(75, 13)
        Me.autenticacionLabel.TabIndex = 9
        Me.autenticacionLabel.Text = "Base de datos"
        '
        'nombreServidorLabel
        '
        Me.nombreServidorLabel.AutoSize = True
        Me.nombreServidorLabel.Location = New System.Drawing.Point(12, 67)
        Me.nombreServidorLabel.Name = "nombreServidorLabel"
        Me.nombreServidorLabel.Size = New System.Drawing.Size(104, 13)
        Me.nombreServidorLabel.TabIndex = 8
        Me.nombreServidorLabel.Text = "Nombre del servidor:"
        '
        'ComboBox1
        '
        Me.ComboBox1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.ComboBox1.FormattingEnabled = True
        Me.ComboBox1.Items.AddRange(New Object() {"Autentificacion de Windows", "Autentificacion de SQL Server"})
        Me.ComboBox1.Location = New System.Drawing.Point(194, 149)
        Me.ComboBox1.Name = "ComboBox1"
        Me.ComboBox1.Size = New System.Drawing.Size(274, 21)
        Me.ComboBox1.TabIndex = 17
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(12, 152)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(72, 13)
        Me.Label1.TabIndex = 16
        Me.Label1.Text = "Autenticacion"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(66, 12)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(191, 20)
        Me.Label2.TabIndex = 18
        Me.Label2.Text = "Añadir una base de datos"
        '
        'Panel1
        '
        Me.Panel1.BackgroundImage = Global.DbManejador.My.Resources.Resources.add_circle_sharp
        Me.Panel1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.Panel1.Location = New System.Drawing.Point(16, 2)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(44, 43)
        Me.Panel1.TabIndex = 19
        '
        'Button1
        '
        Me.Button1.Location = New System.Drawing.Point(380, 244)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(87, 27)
        Me.Button1.TabIndex = 20
        Me.Button1.Text = "Aceptar"
        Me.Button1.UseVisualStyleBackColor = True
        '
        'Button2
        '
        Me.Button2.Location = New System.Drawing.Point(287, 244)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(87, 27)
        Me.Button2.TabIndex = 21
        Me.Button2.Text = "Cancelar"
        Me.Button2.UseVisualStyleBackColor = True
        '
        'AddBd
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(491, 277)
        Me.Controls.Add(Me.Button2)
        Me.Controls.Add(Me.Button1)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.ComboBox1)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.passwdTextBox)
        Me.Controls.Add(Me.usrComboBox)
        Me.Controls.Add(Me.Contrasena_pass)
        Me.Controls.Add(Me.Username_label)
        Me.Controls.Add(Me.Autenticacion)
        Me.Controls.Add(Me.nomServidor)
        Me.Controls.Add(Me.autenticacionLabel)
        Me.Controls.Add(Me.nombreServidorLabel)
        Me.Name = "AddBd"
        Me.Text = "AddBd"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents passwdTextBox As TextBox
    Friend WithEvents usrComboBox As ComboBox
    Friend WithEvents Contrasena_pass As Label
    Friend WithEvents Username_label As Label
    Friend WithEvents Autenticacion As ComboBox
    Friend WithEvents nomServidor As ComboBox
    Friend WithEvents autenticacionLabel As Label
    Friend WithEvents nombreServidorLabel As Label
    Friend WithEvents ComboBox1 As ComboBox
    Friend WithEvents Label1 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents Panel1 As Panel
    Friend WithEvents Button1 As Button
    Friend WithEvents Button2 As Button
End Class
