<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Form1
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
        Me.components = New System.ComponentModel.Container()
        Me.DataGridView1 = New System.Windows.Forms.DataGridView()
        Me.TotFilasDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.NombreTablaDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.SentenciaSQLDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.TablaBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.TablaDAOBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TablaBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TablaDAOBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'DataGridView1
        '
        Me.DataGridView1.AutoGenerateColumns = False
        Me.DataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DataGridView1.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.TotFilasDataGridViewTextBoxColumn, Me.NombreTablaDataGridViewTextBoxColumn, Me.SentenciaSQLDataGridViewTextBoxColumn})
        Me.DataGridView1.DataSource = Me.TablaBindingSource
        Me.DataGridView1.Location = New System.Drawing.Point(323, 12)
        Me.DataGridView1.Name = "DataGridView1"
        Me.DataGridView1.Size = New System.Drawing.Size(928, 608)
        Me.DataGridView1.TabIndex = 0
        '
        'TotFilasDataGridViewTextBoxColumn
        '
        Me.TotFilasDataGridViewTextBoxColumn.DataPropertyName = "TotFilas"
        Me.TotFilasDataGridViewTextBoxColumn.HeaderText = "TotFilas"
        Me.TotFilasDataGridViewTextBoxColumn.Name = "TotFilasDataGridViewTextBoxColumn"
        '
        'NombreTablaDataGridViewTextBoxColumn
        '
        Me.NombreTablaDataGridViewTextBoxColumn.DataPropertyName = "NombreTabla"
        Me.NombreTablaDataGridViewTextBoxColumn.HeaderText = "NombreTabla"
        Me.NombreTablaDataGridViewTextBoxColumn.Name = "NombreTablaDataGridViewTextBoxColumn"
        '
        'SentenciaSQLDataGridViewTextBoxColumn
        '
        Me.SentenciaSQLDataGridViewTextBoxColumn.DataPropertyName = "SentenciaSQL"
        Me.SentenciaSQLDataGridViewTextBoxColumn.HeaderText = "SentenciaSQL"
        Me.SentenciaSQLDataGridViewTextBoxColumn.Name = "SentenciaSQLDataGridViewTextBoxColumn"
        '
        'TablaBindingSource
        '
        Me.TablaBindingSource.DataSource = GetType(DbManejador.Tabla)
        '
        'TablaDAOBindingSource
        '
        Me.TablaDAOBindingSource.DataSource = GetType(DbManejador.TablaDAO)
        '
        'Form1
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1263, 632)
        Me.Controls.Add(Me.DataGridView1)
        Me.Name = "Form1"
        Me.Text = "Form1"
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TablaBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TablaDAOBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents DataGridView1 As DataGridView
    Friend WithEvents TotFilasDataGridViewTextBoxColumn As DataGridViewTextBoxColumn
    Friend WithEvents NombreTablaDataGridViewTextBoxColumn As DataGridViewTextBoxColumn
    Friend WithEvents SentenciaSQLDataGridViewTextBoxColumn As DataGridViewTextBoxColumn
    Friend WithEvents TablaBindingSource As BindingSource
    Friend WithEvents TablaDAOBindingSource As BindingSource
End Class
