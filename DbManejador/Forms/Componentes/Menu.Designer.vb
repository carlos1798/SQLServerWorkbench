<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class Menu
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Menu))
        Me.ToolStrip1 = New System.Windows.Forms.ToolStrip()
        Me.Guardar = New System.Windows.Forms.ToolStripButton()
        Me.Sincronizacion = New System.Windows.Forms.ToolStripButton()
        Me.Fragmentacion = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripButton4 = New System.Windows.Forms.ToolStripDropDownButton()
        Me.IndexSug = New System.Windows.Forms.ToolStripMenuItem()
        Me.IndexPer = New System.Windows.Forms.ToolStripMenuItem()
        Me.AddBaseDatos = New System.Windows.Forms.ToolStripButton()
        Me.Ejecutar = New System.Windows.Forms.ToolStripButton()
        Me.Atras = New System.Windows.Forms.ToolStripButton()
        Me.DBSeleccion = New System.Windows.Forms.ToolStripComboBox()
        Me.SaveFileDialog1 = New System.Windows.Forms.SaveFileDialog()
        Me.ToolStrip1.SuspendLayout()
        Me.SuspendLayout()
        '
        'ToolStrip1
        '
        Me.ToolStrip1.BackColor = System.Drawing.SystemColors.GradientActiveCaption
        Me.ToolStrip1.CanOverflow = False
        Me.ToolStrip1.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden
        Me.ToolStrip1.ImageScalingSize = New System.Drawing.Size(20, 20)
        Me.ToolStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.Guardar, Me.Sincronizacion, Me.Fragmentacion, Me.ToolStripButton4, Me.AddBaseDatos, Me.Ejecutar, Me.Atras, Me.DBSeleccion})
        Me.ToolStrip1.Location = New System.Drawing.Point(0, 0)
        Me.ToolStrip1.Name = "ToolStrip1"
        Me.ToolStrip1.Size = New System.Drawing.Size(729, 52)
        Me.ToolStrip1.Stretch = True
        Me.ToolStrip1.TabIndex = 0
        Me.ToolStrip1.Text = "ToolStrip1"
        '
        'Guardar
        '
        Me.Guardar.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right
        Me.Guardar.AutoToolTip = False
        Me.Guardar.CheckOnClick = True
        Me.Guardar.Image = Global.DbManejador.My.Resources.Resources.save
        Me.Guardar.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.Guardar.Margin = New System.Windows.Forms.Padding(0)
        Me.Guardar.Name = "Guardar"
        Me.Guardar.Overflow = System.Windows.Forms.ToolStripItemOverflow.Never
        Me.Guardar.Size = New System.Drawing.Size(73, 52)
        Me.Guardar.Text = "Guardar"
        '
        'Sincronizacion
        '
        Me.Sincronizacion.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right
        Me.Sincronizacion.AutoToolTip = False
        Me.Sincronizacion.CheckOnClick = True
        Me.Sincronizacion.Image = Global.DbManejador.My.Resources.Resources.aperture
        Me.Sincronizacion.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.Sincronizacion.Margin = New System.Windows.Forms.Padding(0)
        Me.Sincronizacion.Name = "Sincronizacion"
        Me.Sincronizacion.Overflow = System.Windows.Forms.ToolStripItemOverflow.Never
        Me.Sincronizacion.Size = New System.Drawing.Size(108, 52)
        Me.Sincronizacion.Text = "Sincronizacion"
        '
        'Fragmentacion
        '
        Me.Fragmentacion.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right
        Me.Fragmentacion.AutoToolTip = False
        Me.Fragmentacion.CheckOnClick = True
        Me.Fragmentacion.Image = Global.DbManejador.My.Resources.Resources.layers
        Me.Fragmentacion.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.Fragmentacion.Margin = New System.Windows.Forms.Padding(0)
        Me.Fragmentacion.Name = "Fragmentacion"
        Me.Fragmentacion.Overflow = System.Windows.Forms.ToolStripItemOverflow.Never
        Me.Fragmentacion.Size = New System.Drawing.Size(111, 52)
        Me.Fragmentacion.Text = "Fragmentacion"
        '
        'ToolStripButton4
        '
        Me.ToolStripButton4.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right
        Me.ToolStripButton4.AutoToolTip = False
        Me.ToolStripButton4.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.IndexSug, Me.IndexPer})
        Me.ToolStripButton4.Image = Global.DbManejador.My.Resources.Resources.library
        Me.ToolStripButton4.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ToolStripButton4.Margin = New System.Windows.Forms.Padding(0)
        Me.ToolStripButton4.Name = "ToolStripButton4"
        Me.ToolStripButton4.Overflow = System.Windows.Forms.ToolStripItemOverflow.Never
        Me.ToolStripButton4.Size = New System.Drawing.Size(77, 52)
        Me.ToolStripButton4.Text = "Indices"
        '
        'IndexSug
        '
        Me.IndexSug.Name = "IndexSug"
        Me.IndexSug.Size = New System.Drawing.Size(180, 22)
        Me.IndexSug.Text = "Indices Sugerido"
        '
        'IndexPer
        '
        Me.IndexPer.Name = "IndexPer"
        Me.IndexPer.Size = New System.Drawing.Size(180, 22)
        Me.IndexPer.Text = "Indices Perdidos"
        '
        'AddBaseDatos
        '
        Me.AddBaseDatos.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right
        Me.AddBaseDatos.AutoToolTip = False
        Me.AddBaseDatos.CheckOnClick = True
        Me.AddBaseDatos.Image = Global.DbManejador.My.Resources.Resources.add_circle_sharp
        Me.AddBaseDatos.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.AddBaseDatos.Margin = New System.Windows.Forms.Padding(0)
        Me.AddBaseDatos.Name = "AddBaseDatos"
        Me.AddBaseDatos.Overflow = System.Windows.Forms.ToolStripItemOverflow.Never
        Me.AddBaseDatos.Size = New System.Drawing.Size(66, 52)
        Me.AddBaseDatos.Text = "Añadir"
        '
        'Ejecutar
        '
        Me.Ejecutar.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right
        Me.Ejecutar.AutoToolTip = False
        Me.Ejecutar.CheckOnClick = True
        Me.Ejecutar.Image = CType(resources.GetObject("Ejecutar.Image"), System.Drawing.Image)
        Me.Ejecutar.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.Ejecutar.Margin = New System.Windows.Forms.Padding(0)
        Me.Ejecutar.Name = "Ejecutar"
        Me.Ejecutar.Overflow = System.Windows.Forms.ToolStripItemOverflow.Never
        Me.Ejecutar.Size = New System.Drawing.Size(73, 52)
        Me.Ejecutar.Text = "Ejecutar"
        '
        'Atras
        '
        Me.Atras.AutoSize = False
        Me.Atras.AutoToolTip = False
        Me.Atras.Image = Global.DbManejador.My.Resources.Resources.arrow_back_circle
        Me.Atras.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.Atras.Margin = New System.Windows.Forms.Padding(5, 1, 0, 2)
        Me.Atras.Name = "Atras"
        Me.Atras.Overflow = System.Windows.Forms.ToolStripItemOverflow.Never
        Me.Atras.Size = New System.Drawing.Size(70, 49)
        Me.Atras.Text = "Atras"
        '
        'DBSeleccion
        '
        Me.DBSeleccion.MaxDropDownItems = 20
        Me.DBSeleccion.Name = "DBSeleccion"
        Me.DBSeleccion.Size = New System.Drawing.Size(300, 52)
        '
        'Menu
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.Controls.Add(Me.ToolStrip1)
        Me.Name = "Menu"
        Me.Size = New System.Drawing.Size(729, 42)
        Me.ToolStrip1.ResumeLayout(False)
        Me.ToolStrip1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents ToolStrip1 As ToolStrip
    Friend WithEvents Guardar As ToolStripButton
    Friend WithEvents Fragmentacion As ToolStripButton
    Friend WithEvents AddBaseDatos As ToolStripButton
    Friend WithEvents ToolStripButton4 As ToolStripDropDownButton
    Friend WithEvents IndexSug As ToolStripMenuItem
    Friend WithEvents IndexPer As ToolStripMenuItem
    Friend WithEvents Atras As ToolStripButton
    Friend WithEvents Sincronizacion As ToolStripButton
    Friend WithEvents SaveFileDialog1 As SaveFileDialog
    Friend WithEvents Ejecutar As ToolStripButton
    Friend WithEvents DBSeleccion As ToolStripComboBox
End Class
