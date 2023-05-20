<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class Login
    Inherits System.Windows.Forms.Form

    'Form reemplaza a Dispose para limpiar la lista de componentes.
    <System.Diagnostics.DebuggerNonUserCode()>
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
        Me.nombreServidorLabel = New System.Windows.Forms.Label()
        Me.autenticacionLabel = New System.Windows.Forms.Label()
        Me.nomServidor = New System.Windows.Forms.ComboBox()
        Me.Autenticacion = New System.Windows.Forms.ComboBox()
        Me.Username_label = New System.Windows.Forms.Label()
        Me.Contrasena_pass = New System.Windows.Forms.Label()
        Me.usrComboBox = New System.Windows.Forms.ComboBox()
        Me.passwdTextBox = New System.Windows.Forms.TextBox()
        Me.Aceptar = New System.Windows.Forms.Button()
        Me.Cancelar = New System.Windows.Forms.Button()
        Me.OpenFileDialog1 = New System.Windows.Forms.OpenFileDialog()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.HelpProvider1 = New System.Windows.Forms.HelpProvider()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.SuspendLayout()
        '
        'nombreServidorLabel
        '
        Me.nombreServidorLabel.AutoSize = True
        Me.nombreServidorLabel.Font = New System.Drawing.Font("Microsoft JhengHei", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.nombreServidorLabel.Location = New System.Drawing.Point(236, 180)
        Me.nombreServidorLabel.Name = "nombreServidorLabel"
        Me.nombreServidorLabel.Size = New System.Drawing.Size(50, 15)
        Me.nombreServidorLabel.TabIndex = 0
        Me.nombreServidorLabel.Text = "Servidor" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10)
        '
        'autenticacionLabel
        '
        Me.autenticacionLabel.AutoSize = True
        Me.autenticacionLabel.Font = New System.Drawing.Font("Microsoft JhengHei", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.autenticacionLabel.Location = New System.Drawing.Point(207, 208)
        Me.autenticacionLabel.Name = "autenticacionLabel"
        Me.autenticacionLabel.Size = New System.Drawing.Size(79, 15)
        Me.autenticacionLabel.TabIndex = 1
        Me.autenticacionLabel.Text = "Autenticacion"
        '
        'nomServidor
        '
        Me.nomServidor.FormattingEnabled = True
        Me.nomServidor.Location = New System.Drawing.Point(303, 174)
        Me.nomServidor.Name = "nomServidor"
        Me.nomServidor.Size = New System.Drawing.Size(274, 21)
        Me.nomServidor.TabIndex = 2
        '
        'Autenticacion
        '
        Me.Autenticacion.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.Autenticacion.FormattingEnabled = True
        Me.Autenticacion.Items.AddRange(New Object() {"Autentificacion de Windows", "Autentificacion de SQL Server"})
        Me.Autenticacion.Location = New System.Drawing.Point(303, 202)
        Me.Autenticacion.Name = "Autenticacion"
        Me.Autenticacion.Size = New System.Drawing.Size(274, 21)
        Me.Autenticacion.TabIndex = 3
        '
        'Username_label
        '
        Me.Username_label.AutoSize = True
        Me.Username_label.Font = New System.Drawing.Font("Microsoft JhengHei", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Username_label.Location = New System.Drawing.Point(215, 235)
        Me.Username_label.Name = "Username_label"
        Me.Username_label.Size = New System.Drawing.Size(96, 15)
        Me.Username_label.TabIndex = 4
        Me.Username_label.Text = "Nombre Usuario:"
        '
        'Contrasena_pass
        '
        Me.Contrasena_pass.AutoSize = True
        Me.Contrasena_pass.Font = New System.Drawing.Font("Microsoft JhengHei", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Contrasena_pass.Location = New System.Drawing.Point(242, 261)
        Me.Contrasena_pass.Name = "Contrasena_pass"
        Me.Contrasena_pass.Size = New System.Drawing.Size(69, 15)
        Me.Contrasena_pass.TabIndex = 5
        Me.Contrasena_pass.Text = "Contraseña:"
        '
        'usrComboBox
        '
        Me.usrComboBox.FormattingEnabled = True
        Me.usrComboBox.Location = New System.Drawing.Point(350, 229)
        Me.usrComboBox.Name = "usrComboBox"
        Me.usrComboBox.Size = New System.Drawing.Size(227, 21)
        Me.usrComboBox.TabIndex = 6
        '
        'passwdTextBox
        '
        Me.passwdTextBox.Location = New System.Drawing.Point(350, 256)
        Me.passwdTextBox.Name = "passwdTextBox"
        Me.passwdTextBox.PasswordChar = Global.Microsoft.VisualBasic.ChrW(42)
        Me.passwdTextBox.Size = New System.Drawing.Size(226, 20)
        Me.passwdTextBox.TabIndex = 7
        '
        'Aceptar
        '
        Me.Aceptar.Location = New System.Drawing.Point(481, 314)
        Me.Aceptar.Name = "Aceptar"
        Me.Aceptar.Size = New System.Drawing.Size(75, 33)
        Me.Aceptar.TabIndex = 8
        Me.Aceptar.Text = "Aceptar"
        Me.Aceptar.UseVisualStyleBackColor = True
        '
        'Cancelar
        '
        Me.Cancelar.Location = New System.Drawing.Point(375, 314)
        Me.Cancelar.Name = "Cancelar"
        Me.Cancelar.Size = New System.Drawing.Size(75, 33)
        Me.Cancelar.TabIndex = 9
        Me.Cancelar.Text = "Cancelar"
        Me.Cancelar.UseVisualStyleBackColor = True
        '
        'OpenFileDialog1
        '
        Me.OpenFileDialog1.FileName = "OpenFileDialog1"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("MingLiU_HKSCS-ExtB", 48.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(204, 50)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(411, 64)
        Me.Label1.TabIndex = 11
        Me.Label1.Text = "SQLWorkbench"
        '
        'Panel2
        '
        Me.Panel2.BackColor = System.Drawing.Color.DimGray
        Me.Panel2.Location = New System.Drawing.Point(-11, 0)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(184, 368)
        Me.Panel2.TabIndex = 12
        '
        'Login
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(96.0!, 96.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi
        Me.BackColor = System.Drawing.Color.White
        Me.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.ClientSize = New System.Drawing.Size(627, 369)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.Panel2)
        Me.Controls.Add(Me.Cancelar)
        Me.Controls.Add(Me.Aceptar)
        Me.Controls.Add(Me.passwdTextBox)
        Me.Controls.Add(Me.usrComboBox)
        Me.Controls.Add(Me.Contrasena_pass)
        Me.Controls.Add(Me.Username_label)
        Me.Controls.Add(Me.Autenticacion)
        Me.Controls.Add(Me.nomServidor)
        Me.Controls.Add(Me.autenticacionLabel)
        Me.Controls.Add(Me.nombreServidorLabel)
        Me.Font = New System.Drawing.Font("Consolas", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Name = "Login"
        Me.Text = "Login"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents nombreServidorLabel As Label
    Friend WithEvents autenticacionLabel As Label
    Friend WithEvents nomServidor As ComboBox
    Friend WithEvents Autenticacion As ComboBox
    Friend WithEvents Username_label As Label
    Friend WithEvents Contrasena_pass As Label
    Friend WithEvents usrComboBox As ComboBox
    Friend WithEvents passwdTextBox As TextBox
    Friend WithEvents Aceptar As Button
    Friend WithEvents Cancelar As Button
    Friend WithEvents OpenFileDialog1 As OpenFileDialog
    Friend WithEvents Label1 As Label
    Friend WithEvents HelpProvider1 As HelpProvider
    Friend WithEvents Panel2 As Panel
End Class
