<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class BDSelector
    Inherits System.Windows.Forms.UserControl

    'UserControl reemplaza a Dispose para limpiar la lista de componentes.
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
        Me.components = New System.ComponentModel.Container()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.Button2 = New System.Windows.Forms.Button()
        Me.ContextMenuStrip1 = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.GenerarSQLToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.EliminarDeLaListaToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.GenerarLasTablasToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.GenerarLosIndicesToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.GenerarLosLoginsToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.GenerarTodoToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.PropiedadesToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ContextMenuStrip1.SuspendLayout()
        Me.SuspendLayout()
        '
        'Label4
        '
        Me.Label4.BackColor = System.Drawing.Color.Transparent
        Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(47, 3)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(187, 27)
        Me.Label4.TabIndex = 0
        Me.Label4.Text = "Label4"
        '
        'Label5
        '
        Me.Label5.BackColor = System.Drawing.Color.Transparent
        Me.Label5.Location = New System.Drawing.Point(47, 30)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(187, 17)
        Me.Label5.TabIndex = 0
        Me.Label5.Text = "Label5"
        '
        'Panel2
        '
        Me.Panel2.BackColor = System.Drawing.Color.Transparent
        Me.Panel2.BackgroundImage = Global.DbManejador.My.Resources.Resources.server_sharp
        Me.Panel2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.Panel2.Location = New System.Drawing.Point(3, 3)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(38, 40)
        Me.Panel2.TabIndex = 1
        '
        'Button2
        '
        Me.Button2.BackColor = System.Drawing.SystemColors.GradientInactiveCaption
        Me.Button2.Location = New System.Drawing.Point(0, 0)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(239, 49)
        Me.Button2.TabIndex = 2
        Me.Button2.UseVisualStyleBackColor = False
        '
        'ContextMenuStrip1
        '
        Me.ContextMenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.GenerarSQLToolStripMenuItem, Me.EliminarDeLaListaToolStripMenuItem, Me.PropiedadesToolStripMenuItem})
        Me.ContextMenuStrip1.Name = "ContextMenuStrip1"
        Me.ContextMenuStrip1.RenderMode = System.Windows.Forms.ToolStripRenderMode.System
        Me.ContextMenuStrip1.Size = New System.Drawing.Size(181, 92)
        '
        'GenerarSQLToolStripMenuItem
        '
        Me.GenerarSQLToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.GenerarLasTablasToolStripMenuItem, Me.GenerarLosIndicesToolStripMenuItem, Me.GenerarLosLoginsToolStripMenuItem, Me.GenerarTodoToolStripMenuItem})
        Me.GenerarSQLToolStripMenuItem.Name = "GenerarSQLToolStripMenuItem"
        Me.GenerarSQLToolStripMenuItem.Size = New System.Drawing.Size(180, 22)
        Me.GenerarSQLToolStripMenuItem.Text = "Generar SQL"
        '
        'EliminarDeLaListaToolStripMenuItem
        '
        Me.EliminarDeLaListaToolStripMenuItem.Name = "EliminarDeLaListaToolStripMenuItem"
        Me.EliminarDeLaListaToolStripMenuItem.Size = New System.Drawing.Size(180, 22)
        Me.EliminarDeLaListaToolStripMenuItem.Text = "Eliminar de la lista"
        '
        'GenerarLasTablasToolStripMenuItem
        '
        Me.GenerarLasTablasToolStripMenuItem.Name = "GenerarLasTablasToolStripMenuItem"
        Me.GenerarLasTablasToolStripMenuItem.Size = New System.Drawing.Size(180, 22)
        Me.GenerarLasTablasToolStripMenuItem.Text = "Generar las tablas"
        '
        'GenerarLosIndicesToolStripMenuItem
        '
        Me.GenerarLosIndicesToolStripMenuItem.Name = "GenerarLosIndicesToolStripMenuItem"
        Me.GenerarLosIndicesToolStripMenuItem.Size = New System.Drawing.Size(180, 22)
        Me.GenerarLosIndicesToolStripMenuItem.Text = "Generar los indices"
        '
        'GenerarLosLoginsToolStripMenuItem
        '
        Me.GenerarLosLoginsToolStripMenuItem.Name = "GenerarLosLoginsToolStripMenuItem"
        Me.GenerarLosLoginsToolStripMenuItem.Size = New System.Drawing.Size(180, 22)
        Me.GenerarLosLoginsToolStripMenuItem.Text = "Generar los logins"
        '
        'GenerarTodoToolStripMenuItem
        '
        Me.GenerarTodoToolStripMenuItem.Name = "GenerarTodoToolStripMenuItem"
        Me.GenerarTodoToolStripMenuItem.Size = New System.Drawing.Size(180, 22)
        Me.GenerarTodoToolStripMenuItem.Text = "Generar todo"
        '
        'PropiedadesToolStripMenuItem
        '
        Me.PropiedadesToolStripMenuItem.Name = "PropiedadesToolStripMenuItem"
        Me.PropiedadesToolStripMenuItem.Size = New System.Drawing.Size(180, 22)
        Me.PropiedadesToolStripMenuItem.Text = "Propiedades"
        '
        'BDSelector
        '
        Me.BackColor = System.Drawing.SystemColors.GradientInactiveCaption
        Me.Controls.Add(Me.Panel2)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.Button2)
        Me.Name = "BDSelector"
        Me.Size = New System.Drawing.Size(239, 49)
        Me.ContextMenuStrip1.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents Label1 As Label
    Friend WithEvents Panel1 As Panel
    Friend WithEvents Label2 As Label
    Friend WithEvents Label3 As Label
    Friend WithEvents Button1 As Button
    Friend WithEvents Label4 As Label
    Friend WithEvents Label5 As Label
    Friend WithEvents Panel2 As Panel
    Friend WithEvents Button2 As Button
    Friend WithEvents ContextMenuStrip1 As ContextMenuStrip
    Friend WithEvents GenerarSQLToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents GenerarLasTablasToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents GenerarLosIndicesToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents GenerarLosLoginsToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents GenerarTodoToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents EliminarDeLaListaToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents PropiedadesToolStripMenuItem As ToolStripMenuItem
End Class
