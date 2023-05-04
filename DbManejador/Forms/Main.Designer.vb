<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class Main
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
        Me.components = New System.ComponentModel.Container()
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle4 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Main))
        Me.DataGridView1 = New System.Windows.Forms.DataGridView()
        Me.NumCol = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.TablaNombre = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.NumeroIndices = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.SaveFileDialog1 = New System.Windows.Forms.SaveFileDialog()
        Me.ImageList1 = New System.Windows.Forms.ImageList(Me.components)
        Me.Query_Result_Container = New System.Windows.Forms.TableLayoutPanel()
        Me.SplitContainer1 = New System.Windows.Forms.SplitContainer()
        Me.MainSplitter = New System.Windows.Forms.SplitContainer()
        Me.DBObjetos_Splitter = New System.Windows.Forms.SplitContainer()
        Me.TreeView1 = New System.Windows.Forms.TreeView()
        Me.InputText1 = New DbManejador.InputText()
        Me.Menu1 = New DbManejador.Menu()
        Me.QueryResult = New System.Windows.Forms.DataGridView()
        Me.Button1 = New System.Windows.Forms.Button()
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Query_Result_Container.SuspendLayout()
        CType(Me.SplitContainer1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SplitContainer1.Panel1.SuspendLayout()
        Me.SplitContainer1.Panel2.SuspendLayout()
        Me.SplitContainer1.SuspendLayout()
        CType(Me.MainSplitter, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.MainSplitter.Panel1.SuspendLayout()
        Me.MainSplitter.Panel2.SuspendLayout()
        Me.MainSplitter.SuspendLayout()
        CType(Me.DBObjetos_Splitter, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.DBObjetos_Splitter.Panel1.SuspendLayout()
        Me.DBObjetos_Splitter.Panel2.SuspendLayout()
        Me.DBObjetos_Splitter.SuspendLayout()
        CType(Me.QueryResult, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'DataGridView1
        '
        Me.DataGridView1.AllowUserToAddRows = False
        Me.DataGridView1.BackgroundColor = System.Drawing.Color.DarkGray
        Me.DataGridView1.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.[Single]
        DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Desktop
        DataGridViewCellStyle1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.DataGridView1.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle1
        Me.DataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DataGridView1.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.NumCol, Me.TablaNombre, Me.NumeroIndices})
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Menu
        DataGridViewCellStyle2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.DataGridView1.DefaultCellStyle = DataGridViewCellStyle2
        resources.ApplyResources(Me.DataGridView1, "DataGridView1")
        Me.DataGridView1.GridColor = System.Drawing.SystemColors.Control
        Me.DataGridView1.Name = "DataGridView1"
        Me.DataGridView1.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None
        DataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.ControlLightLight
        DataGridViewCellStyle3.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.InfoText
        DataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.ControlLightLight
        DataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.DataGridView1.RowHeadersDefaultCellStyle = DataGridViewCellStyle3
        Me.DataGridView1.RowHeadersVisible = False
        DataGridViewCellStyle4.ForeColor = System.Drawing.Color.Black
        Me.DataGridView1.RowsDefaultCellStyle = DataGridViewCellStyle4
        Me.DataGridView1.RowTemplate.DefaultCellStyle.BackColor = System.Drawing.Color.White
        Me.DataGridView1.RowTemplate.DefaultCellStyle.ForeColor = System.Drawing.Color.Black
        Me.DataGridView1.RowTemplate.DefaultCellStyle.SelectionBackColor = System.Drawing.SystemColors.MenuHighlight
        Me.DataGridView1.RowTemplate.DefaultCellStyle.SelectionForeColor = System.Drawing.Color.Black
        '
        'NumCol
        '
        Me.NumCol.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill
        resources.ApplyResources(Me.NumCol, "NumCol")
        Me.NumCol.Name = "NumCol"
        '
        'TablaNombre
        '
        Me.TablaNombre.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells
        resources.ApplyResources(Me.TablaNombre, "TablaNombre")
        Me.TablaNombre.Name = "TablaNombre"
        '
        'NumeroIndices
        '
        Me.NumeroIndices.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill
        resources.ApplyResources(Me.NumeroIndices, "NumeroIndices")
        Me.NumeroIndices.Name = "NumeroIndices"
        '
        'ImageList1
        '
        Me.ImageList1.ImageStream = CType(resources.GetObject("ImageList1.ImageStream"), System.Windows.Forms.ImageListStreamer)
        Me.ImageList1.TransparentColor = System.Drawing.Color.Transparent
        Me.ImageList1.Images.SetKeyName(0, "layers.png")
        Me.ImageList1.Images.SetKeyName(1, "library.png")
        Me.ImageList1.Images.SetKeyName(2, "server1.png")
        Me.ImageList1.Images.SetKeyName(3, "File_32.png")
        '
        'Query_Result_Container
        '
        resources.ApplyResources(Me.Query_Result_Container, "Query_Result_Container")
        Me.Query_Result_Container.Controls.Add(Me.SplitContainer1, 0, 0)
        Me.Query_Result_Container.Name = "Query_Result_Container"
        '
        'SplitContainer1
        '
        resources.ApplyResources(Me.SplitContainer1, "SplitContainer1")
        Me.SplitContainer1.Name = "SplitContainer1"
        '
        'SplitContainer1.Panel1
        '
        Me.SplitContainer1.Panel1.Controls.Add(Me.InputText1)
        '
        'SplitContainer1.Panel2
        '
        Me.SplitContainer1.Panel2.Controls.Add(Me.QueryResult)
        '
        'MainSplitter
        '
        resources.ApplyResources(Me.MainSplitter, "MainSplitter")
        Me.MainSplitter.Name = "MainSplitter"
        '
        'MainSplitter.Panel1
        '
        Me.MainSplitter.Panel1.Controls.Add(Me.DBObjetos_Splitter)
        '
        'MainSplitter.Panel2
        '
        Me.MainSplitter.Panel2.Controls.Add(Me.Query_Result_Container)
        '
        'DBObjetos_Splitter
        '
        resources.ApplyResources(Me.DBObjetos_Splitter, "DBObjetos_Splitter")
        Me.DBObjetos_Splitter.Name = "DBObjetos_Splitter"
        '
        'DBObjetos_Splitter.Panel1
        '
        Me.DBObjetos_Splitter.Panel1.Controls.Add(Me.TreeView1)
        '
        'DBObjetos_Splitter.Panel2
        '
        Me.DBObjetos_Splitter.Panel2.Controls.Add(Me.DataGridView1)
        '
        'TreeView1
        '
        resources.ApplyResources(Me.TreeView1, "TreeView1")
        Me.TreeView1.ImageList = Me.ImageList1
        Me.TreeView1.Name = "TreeView1"
        '
        'InputText1
        '
        resources.ApplyResources(Me.InputText1, "InputText1")
        Me.InputText1.BackColor = System.Drawing.Color.DimGray
        Me.InputText1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.InputText1.ForeColor = System.Drawing.SystemColors.Window
        Me.InputText1.Name = "InputText1"
        '
        'Menu1
        '
        resources.ApplyResources(Me.Menu1, "Menu1")
        Me.Menu1.Name = "Menu1"
        '
        'QueryResult
        '
        Me.QueryResult.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        resources.ApplyResources(Me.QueryResult, "QueryResult")
        Me.QueryResult.Name = "QueryResult"
        '
        'Button1
        '
        resources.ApplyResources(Me.Button1, "Button1")
        Me.Button1.Name = "Button1"
        Me.Button1.UseVisualStyleBackColor = True
        '
        'Main
        '
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None
        resources.ApplyResources(Me, "$this")
        Me.BackColor = System.Drawing.Color.White
        Me.Controls.Add(Me.Button1)
        Me.Controls.Add(Me.MainSplitter)
        Me.Controls.Add(Me.Menu1)
        Me.DoubleBuffered = True
        Me.Name = "Main"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Query_Result_Container.ResumeLayout(False)
        Me.SplitContainer1.Panel1.ResumeLayout(False)
        Me.SplitContainer1.Panel1.PerformLayout()
        Me.SplitContainer1.Panel2.ResumeLayout(False)
        CType(Me.SplitContainer1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.SplitContainer1.ResumeLayout(False)
        Me.MainSplitter.Panel1.ResumeLayout(False)
        Me.MainSplitter.Panel2.ResumeLayout(False)
        CType(Me.MainSplitter, System.ComponentModel.ISupportInitialize).EndInit()
        Me.MainSplitter.ResumeLayout(False)
        Me.DBObjetos_Splitter.Panel1.ResumeLayout(False)
        Me.DBObjetos_Splitter.Panel2.ResumeLayout(False)
        CType(Me.DBObjetos_Splitter, System.ComponentModel.ISupportInitialize).EndInit()
        Me.DBObjetos_Splitter.ResumeLayout(False)
        CType(Me.QueryResult, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents DataGridView1 As DataGridView
    Friend WithEvents SaveFileDialog1 As SaveFileDialog
    Friend WithEvents InputText1 As InputText
    Friend WithEvents ImageList1 As ImageList
    Friend WithEvents Menu1 As Menu
    Friend WithEvents Query_Result_Container As TableLayoutPanel
    Friend WithEvents SplitContainer1 As SplitContainer
    Friend WithEvents MainSplitter As SplitContainer
    Friend WithEvents TreeView1 As TreeView
    Friend WithEvents DBObjetos_Splitter As SplitContainer
    Friend WithEvents NumCol As DataGridViewTextBoxColumn
    Friend WithEvents TablaNombre As DataGridViewTextBoxColumn
    Friend WithEvents NumeroIndices As DataGridViewTextBoxColumn
    Friend WithEvents QueryResult As DataGridView
    Friend WithEvents Button1 As Button
End Class
