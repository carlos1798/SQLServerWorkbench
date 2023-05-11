<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class VistaFragmentacion
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
        Me.Reconstruir = New System.Windows.Forms.DataGridViewCheckBoxColumn()
        Me.ObjectNameDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.IndexNameDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.IndextypedescDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.AvgfragmentationinpercentDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.FragmentcountDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.PagecountDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.FillfactorDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.FragmentacionBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.TextBox1 = New System.Windows.Forms.TextBox()
        Me.Label4 = New System.Windows.Forms.Label()
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.FragmentacionBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'DataGridView1
        '
        Me.DataGridView1.AllowUserToAddRows = False
        Me.DataGridView1.AllowUserToDeleteRows = False
        Me.DataGridView1.AutoGenerateColumns = False
        Me.DataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DataGridView1.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.Reconstruir, Me.ObjectNameDataGridViewTextBoxColumn, Me.IndexNameDataGridViewTextBoxColumn, Me.IndextypedescDataGridViewTextBoxColumn, Me.AvgfragmentationinpercentDataGridViewTextBoxColumn, Me.FragmentcountDataGridViewTextBoxColumn, Me.PagecountDataGridViewTextBoxColumn, Me.FillfactorDataGridViewTextBoxColumn})
        Me.DataGridView1.DataSource = Me.FragmentacionBindingSource
        Me.DataGridView1.Location = New System.Drawing.Point(12, 86)
        Me.DataGridView1.Name = "DataGridView1"
        Me.DataGridView1.RowHeadersVisible = False
        Me.DataGridView1.Size = New System.Drawing.Size(1064, 498)
        Me.DataGridView1.TabIndex = 0
        '
        'Reconstruir
        '
        Me.Reconstruir.FillWeight = 65.0!
        Me.Reconstruir.HeaderText = "Reconstruir"
        Me.Reconstruir.Name = "Reconstruir"
        Me.Reconstruir.Width = 65
        '
        'ObjectNameDataGridViewTextBoxColumn
        '
        Me.ObjectNameDataGridViewTextBoxColumn.DataPropertyName = "Object Name"
        Me.ObjectNameDataGridViewTextBoxColumn.FillWeight = 250.0!
        Me.ObjectNameDataGridViewTextBoxColumn.HeaderText = "NombreTabla"
        Me.ObjectNameDataGridViewTextBoxColumn.Name = "ObjectNameDataGridViewTextBoxColumn"
        Me.ObjectNameDataGridViewTextBoxColumn.ReadOnly = True
        Me.ObjectNameDataGridViewTextBoxColumn.Width = 250
        '
        'IndexNameDataGridViewTextBoxColumn
        '
        Me.IndexNameDataGridViewTextBoxColumn.DataPropertyName = "Index Name"
        Me.IndexNameDataGridViewTextBoxColumn.FillWeight = 170.0!
        Me.IndexNameDataGridViewTextBoxColumn.HeaderText = "Nombre del indice"
        Me.IndexNameDataGridViewTextBoxColumn.Name = "IndexNameDataGridViewTextBoxColumn"
        Me.IndexNameDataGridViewTextBoxColumn.Width = 170
        '
        'IndextypedescDataGridViewTextBoxColumn
        '
        Me.IndextypedescDataGridViewTextBoxColumn.DataPropertyName = "index_type_desc"
        Me.IndextypedescDataGridViewTextBoxColumn.HeaderText = "Tipo de indice"
        Me.IndextypedescDataGridViewTextBoxColumn.Name = "IndextypedescDataGridViewTextBoxColumn"
        '
        'AvgfragmentationinpercentDataGridViewTextBoxColumn
        '
        Me.AvgfragmentationinpercentDataGridViewTextBoxColumn.DataPropertyName = "avg_fragmentation_in_percent"
        Me.AvgfragmentationinpercentDataGridViewTextBoxColumn.FillWeight = 125.0!
        Me.AvgfragmentationinpercentDataGridViewTextBoxColumn.HeaderText = "Fragmentacion en %"
        Me.AvgfragmentationinpercentDataGridViewTextBoxColumn.Name = "AvgfragmentationinpercentDataGridViewTextBoxColumn"
        Me.AvgfragmentationinpercentDataGridViewTextBoxColumn.Width = 125
        '
        'FragmentcountDataGridViewTextBoxColumn
        '
        Me.FragmentcountDataGridViewTextBoxColumn.DataPropertyName = "fragment_count"
        Me.FragmentcountDataGridViewTextBoxColumn.HeaderText = "fragment_count"
        Me.FragmentcountDataGridViewTextBoxColumn.Name = "FragmentcountDataGridViewTextBoxColumn"
        '
        'PagecountDataGridViewTextBoxColumn
        '
        Me.PagecountDataGridViewTextBoxColumn.DataPropertyName = "page_count"
        Me.PagecountDataGridViewTextBoxColumn.HeaderText = "page_count"
        Me.PagecountDataGridViewTextBoxColumn.Name = "PagecountDataGridViewTextBoxColumn"
        '
        'FillfactorDataGridViewTextBoxColumn
        '
        Me.FillfactorDataGridViewTextBoxColumn.DataPropertyName = "fill_factor"
        Me.FillfactorDataGridViewTextBoxColumn.HeaderText = "fill_factor"
        Me.FillfactorDataGridViewTextBoxColumn.Name = "FillfactorDataGridViewTextBoxColumn"
        '
        'FragmentacionBindingSource
        '
        Me.FragmentacionBindingSource.DataMember = "Fragmentacion"
        '
        'GESTIONSQLDataSet
        '
        '
        'FragmentacionTableAdapter
        '
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 20.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(6, 9)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(324, 31)
        Me.Label1.TabIndex = 1
        Me.Label1.Text = "Fragmentacion de indices"
        '
        'Button1
        '
        Me.Button1.Location = New System.Drawing.Point(1000, 590)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(75, 23)
        Me.Button1.TabIndex = 2
        Me.Button1.Text = "Aceptar"
        Me.Button1.UseVisualStyleBackColor = True
        '
        'Label2
        '
        Me.Label2.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(12, 593)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(53, 16)
        Me.Label2.TabIndex = 10
        Me.Label2.Text = "Buscar:"
        '
        'TextBox1
        '
        Me.TextBox1.Location = New System.Drawing.Point(71, 593)
        Me.TextBox1.Name = "TextBox1"
        Me.TextBox1.Size = New System.Drawing.Size(166, 20)
        Me.TextBox1.TabIndex = 9
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(640, 38)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(25, 13)
        Me.Label4.TabIndex = 13
        Me.Label4.Text = "Info"
        '
        'Fragmentacion
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1087, 621)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.TextBox1)
        Me.Controls.Add(Me.Button1)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.DataGridView1)
        Me.Name = "Fragmentacion"
        Me.Text = "Form1"
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.FragmentacionBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents DataGridView1 As DataGridView
    Friend WithEvents FragmentacionBindingSource As BindingSource
    Friend WithEvents Label1 As Label
    Friend WithEvents Button1 As Button
    Friend WithEvents Label2 As Label
    Friend WithEvents TextBox1 As TextBox
    Friend WithEvents Reconstruir As DataGridViewCheckBoxColumn
    Friend WithEvents ObjectNameDataGridViewTextBoxColumn As DataGridViewTextBoxColumn
    Friend WithEvents IndexNameDataGridViewTextBoxColumn As DataGridViewTextBoxColumn
    Friend WithEvents IndextypedescDataGridViewTextBoxColumn As DataGridViewTextBoxColumn
    Friend WithEvents AvgfragmentationinpercentDataGridViewTextBoxColumn As DataGridViewTextBoxColumn
    Friend WithEvents FragmentcountDataGridViewTextBoxColumn As DataGridViewTextBoxColumn
    Friend WithEvents PagecountDataGridViewTextBoxColumn As DataGridViewTextBoxColumn
    Friend WithEvents FillfactorDataGridViewTextBoxColumn As DataGridViewTextBoxColumn
    Friend WithEvents Label4 As Label
End Class
