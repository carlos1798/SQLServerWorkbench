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
        Me.ToolStrip1 = New System.Windows.Forms.ToolStrip()
        Me.ToolStripButton3 = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripButton6 = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripButton2 = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripButton4 = New System.Windows.Forms.ToolStripDropDownButton()
        Me.IndicesSugeridoToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.IndicesPerdidosToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripButton1 = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripButton5 = New System.Windows.Forms.ToolStripButton()
        Me.SerBDSeleccionados1 = New DbManejador.SerBDSeleccionados()
        Me.ToolStrip1.SuspendLayout()
        Me.SuspendLayout()
        '
        'ToolStrip1
        '
        Me.ToolStrip1.BackColor = System.Drawing.SystemColors.GradientActiveCaption
        Me.ToolStrip1.CanOverflow = False
        Me.ToolStrip1.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden
        Me.ToolStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripButton3, Me.ToolStripButton6, Me.ToolStripButton2, Me.ToolStripButton4, Me.ToolStripButton1, Me.ToolStripButton5})
        Me.ToolStrip1.Location = New System.Drawing.Point(0, 0)
        Me.ToolStrip1.Name = "ToolStrip1"
        Me.ToolStrip1.Size = New System.Drawing.Size(729, 52)
        Me.ToolStrip1.TabIndex = 0
        Me.ToolStrip1.Text = "ToolStrip1"
        '
        'ToolStripButton3
        '
        Me.ToolStripButton3.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right
        Me.ToolStripButton3.AutoToolTip = False
        Me.ToolStripButton3.CheckOnClick = True
        Me.ToolStripButton3.Image = Global.DbManejador.My.Resources.Resources.save
        Me.ToolStripButton3.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ToolStripButton3.Margin = New System.Windows.Forms.Padding(0)
        Me.ToolStripButton3.Name = "ToolStripButton3"
        Me.ToolStripButton3.Overflow = System.Windows.Forms.ToolStripItemOverflow.Never
        Me.ToolStripButton3.Size = New System.Drawing.Size(69, 52)
        Me.ToolStripButton3.Text = "Guardar"
        '
        'ToolStripButton6
        '
        Me.ToolStripButton6.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right
        Me.ToolStripButton6.AutoToolTip = False
        Me.ToolStripButton6.CheckOnClick = True
        Me.ToolStripButton6.Image = Global.DbManejador.My.Resources.Resources.aperture
        Me.ToolStripButton6.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ToolStripButton6.Margin = New System.Windows.Forms.Padding(0)
        Me.ToolStripButton6.Name = "ToolStripButton6"
        Me.ToolStripButton6.Overflow = System.Windows.Forms.ToolStripItemOverflow.Never
        Me.ToolStripButton6.Size = New System.Drawing.Size(107, 52)
        Me.ToolStripButton6.Text = "Fragmentacion"
        '
        'ToolStripButton2
        '
        Me.ToolStripButton2.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right
        Me.ToolStripButton2.AutoToolTip = False
        Me.ToolStripButton2.CheckOnClick = True
        Me.ToolStripButton2.Image = Global.DbManejador.My.Resources.Resources.aperture
        Me.ToolStripButton2.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ToolStripButton2.Margin = New System.Windows.Forms.Padding(0)
        Me.ToolStripButton2.Name = "ToolStripButton2"
        Me.ToolStripButton2.Overflow = System.Windows.Forms.ToolStripItemOverflow.Never
        Me.ToolStripButton2.Size = New System.Drawing.Size(107, 52)
        Me.ToolStripButton2.Text = "Fragmentacion"
        '
        'ToolStripButton4
        '
        Me.ToolStripButton4.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right
        Me.ToolStripButton4.AutoToolTip = False
        Me.ToolStripButton4.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.IndicesSugeridoToolStripMenuItem, Me.IndicesPerdidosToolStripMenuItem})
        Me.ToolStripButton4.Image = Global.DbManejador.My.Resources.Resources.library
        Me.ToolStripButton4.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ToolStripButton4.Margin = New System.Windows.Forms.Padding(0)
        Me.ToolStripButton4.Name = "ToolStripButton4"
        Me.ToolStripButton4.Overflow = System.Windows.Forms.ToolStripItemOverflow.Never
        Me.ToolStripButton4.Size = New System.Drawing.Size(73, 52)
        Me.ToolStripButton4.Text = "Indices"
        '
        'IndicesSugeridoToolStripMenuItem
        '
        Me.IndicesSugeridoToolStripMenuItem.Name = "IndicesSugeridoToolStripMenuItem"
        Me.IndicesSugeridoToolStripMenuItem.Size = New System.Drawing.Size(161, 22)
        Me.IndicesSugeridoToolStripMenuItem.Text = "Indices Sugerido"
        '
        'IndicesPerdidosToolStripMenuItem
        '
        Me.IndicesPerdidosToolStripMenuItem.Name = "IndicesPerdidosToolStripMenuItem"
        Me.IndicesPerdidosToolStripMenuItem.Size = New System.Drawing.Size(161, 22)
        Me.IndicesPerdidosToolStripMenuItem.Text = "Indices Perdidos"
        '
        'ToolStripButton1
        '
        Me.ToolStripButton1.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right
        Me.ToolStripButton1.AutoToolTip = False
        Me.ToolStripButton1.CheckOnClick = True
        Me.ToolStripButton1.Image = Global.DbManejador.My.Resources.Resources.add_circle_sharp
        Me.ToolStripButton1.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ToolStripButton1.Margin = New System.Windows.Forms.Padding(0)
        Me.ToolStripButton1.Name = "ToolStripButton1"
        Me.ToolStripButton1.Overflow = System.Windows.Forms.ToolStripItemOverflow.Never
        Me.ToolStripButton1.Size = New System.Drawing.Size(103, 52)
        Me.ToolStripButton1.Text = "Añadir una BD"
        '
        'ToolStripButton5
        '
        Me.ToolStripButton5.AutoSize = False
        Me.ToolStripButton5.AutoToolTip = False
        Me.ToolStripButton5.Image = Global.DbManejador.My.Resources.Resources.arrow_back_circle
        Me.ToolStripButton5.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ToolStripButton5.Margin = New System.Windows.Forms.Padding(5, 1, 0, 2)
        Me.ToolStripButton5.Name = "ToolStripButton5"
        Me.ToolStripButton5.Overflow = System.Windows.Forms.ToolStripItemOverflow.Never
        Me.ToolStripButton5.Size = New System.Drawing.Size(54, 49)
        Me.ToolStripButton5.Text = "Atras"
        '
        'SerBDSeleccionados1
        '
        Me.SerBDSeleccionados1.BackColor = System.Drawing.SystemColors.GradientActiveCaption
        Me.SerBDSeleccionados1.Location = New System.Drawing.Point(61, 12)
        Me.SerBDSeleccionados1.Name = "SerBDSeleccionados1"
        Me.SerBDSeleccionados1.Size = New System.Drawing.Size(177, 36)
        Me.SerBDSeleccionados1.TabIndex = 1
        '
        'Menu
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.Controls.Add(Me.SerBDSeleccionados1)
        Me.Controls.Add(Me.ToolStrip1)
        Me.Name = "Menu"
        Me.Size = New System.Drawing.Size(729, 51)
        Me.ToolStrip1.ResumeLayout(False)
        Me.ToolStrip1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents ToolStrip1 As ToolStrip
    Friend WithEvents ToolStripButton3 As ToolStripButton
    Friend WithEvents ToolStripButton2 As ToolStripButton
    Friend WithEvents ToolStripButton1 As ToolStripButton
    Friend WithEvents ToolStripButton4 As ToolStripDropDownButton
    Friend WithEvents IndicesSugeridoToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents IndicesPerdidosToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents ToolStripButton5 As ToolStripButton
    Friend WithEvents ToolStripButton6 As ToolStripButton
    Friend WithEvents SerBDSeleccionados1 As SerBDSeleccionados
End Class
