Public Class Main
    Public listaDatabases As List(Of Database)
    Dim listaAuxDB As List(Of Database)
    Dim reg As New Registro
    Public lista As New List(Of String)
    Dim tablaSql As New TablaSQL
    Public bdseleccionada As String = ""
    Private servidores As New Servidores()
    Public servidorSelec As String = ""
    Private _sqlquery As String = ""

    Public Property Sqlquery As String
        Get
            Return _sqlquery
        End Get
        Set(value As String)
            _sqlquery = value
        End Set
    End Property

    Private Sub Main_Load(sender As Object, e As EventArgs) Handles Me.Load
        Using LoginForm As New Login(servidores)
            LoginForm.ShowDialog()
            servidores = LoginForm.Servidores
        End Using

        fillTreeNode()
        SplitContainer1.Panel2Collapsed = True

        Menu1.Servidores = servidores

    End Sub

    Public Sub New()
        ' Esta llamada es exigida por el diseñador.
        InitializeComponent()

    End Sub

    Public Sub fill_TreeView(listadb As List(Of Database))
        For Each db In listaDatabases
            Dim asd As New BDSelector(db.Nombre, db.Servidor.NombreServidor, db)
            TreeView1.Nodes(0).ImageIndex = 1
            For Each nodo As TreeNode In TreeView1.Nodes(0).Nodes
                If db.Nombre.Equals(nodo.Text) Then
                    For Each tabla In db.Tablas
                        nodo.Nodes.Add(New TreeNode(tabla.NombreTabla))
                        nodo.SelectedImageIndex = 3
                    Next
                End If
            Next
        Next
    End Sub

    Public Sub print_sql_editor()
        InputText1.RichTextBox1.Text = Sqlquery
    End Sub

    Public Sub Add_Server(servidor As Servidor)
        Dim root As New TreeNode(servidor.NombreServidor)
        TreeView1.Nodes.Add(root)

        For Each bd In servidor.ListaDatabases

            TreeView1.Nodes(TreeView1.Nodes.Count - 1).Nodes.Add(New TreeNode(bd.Nombre))
            Dim asd As New BDSelector(bd.Nombre, bd.Servidor.NombreServidor, bd)

            TreeView1.Nodes(0).ImageIndex = 1
            For Each nodo As TreeNode In TreeView1.Nodes(0).Nodes
                If bd.Nombre.Equals(nodo.Text) Then
                    For Each tabla In bd.Tablas
                        nodo.Nodes.Add(New TreeNode(tabla.NombreTabla))
                        nodo.SelectedImageIndex = 3
                    Next
                End If
            Next
        Next

    End Sub

    Public Sub fillTreeNode()

        TreeView1.Nodes.Clear()

        For Each servidor In servidores.ListaServidores
            Dim root As New TreeNode(servidor.NombreServidor)
            TreeView1.Nodes.Add(root)
            For Each bd In servidor.ListaDatabases
                TreeView1.Nodes(TreeView1.Nodes.Count - 1).Nodes.Add(New TreeNode(bd.Nombre))
                Dim asd As New BDSelector(bd.Nombre, bd.Servidor.NombreServidor, bd)

                TreeView1.Nodes(0).ImageIndex = 1
                For Each nodo As TreeNode In TreeView1.Nodes(0).Nodes
                    If bd.Nombre.Equals(nodo.Text) Then
                        For Each tabla In bd.Tablas
                            nodo.Nodes.Add(New TreeNode(tabla.NombreTabla))
                            nodo.SelectedImageIndex = 3
                        Next
                    End If
                Next
            Next
        Next

    End Sub

    Private Sub seleccionarBD(basedatos As Database)
        DataGridView1.Rows.Clear()

        For Each tabla In basedatos.Tablas

            DataGridView1.Rows.Add(tabla.NombreTabla, tabla.Indices.Count, tabla.Columnas.Count, tabla.TotFilas)
            lista.Add(tablaSql.Crear(tabla))
        Next
        For Each tabla In lista
            InputText1.RichTextBox1.AppendText(vbCrLf + tabla)
        Next

    End Sub

    Private Sub TreeView1_AfterSelect(sender As Object, e As TreeViewEventArgs) Handles TreeView1.AfterSelect

        DataGridView1.Rows.Clear()
        For Each servidor In servidores.ListaServidores.FindAll(Function(x) x IsNot Nothing)
            For Each Database In servidor.ListaDatabases
                For Each tabla In Database.Tablas

                    If TreeView1.SelectedNode.Text = tabla.NombreTabla Then
                        For Each columna In tabla.Columnas
                            DataGridView1.Rows.Add(columna.Nombre, columna.OrdenColumna, columna.tipoDato.ToString)
                            Label1.Text = TreeView1.SelectedNode.Text
                        Next

                    End If
                Next
            Next
        Next

    End Sub

    Public Sub EjecutarSQLTextBox()
        Dim datatable As DataTable
        Dim bs As New BindingSource
        Dim tablasql As New TablaSQL
        Dim esUpdate As Boolean = False
        Dim refresh As Boolean = False
        Dim query As String = InputText1.RichTextBox1.Text

        If Not InputText1.RichTextBox1.Text = Nothing Then
            GC.Collect()
            For Each token In InputText1.tokenes
                If token.Contenido IsNot Nothing Then
                    If token.Contenido.ToUpper = "UPDATE" Then
                        esUpdate = True
                        Exit For
                    ElseIf token.Contenido.ToUpper = "CREATE" Or token.Contenido.ToUpper = "DROP" Then
                        refresh = True
                    End If
                Else
                    Exit Sub
                End If

            Next
            If esUpdate Then
                Using QueryDAO As New QueryDAO()
                    Dim filas_afectadas As Integer = QueryDAO.ExecuteUpdateQuery(query)
                    Dim mensaje As String = $"{filas_afectadas} filas han sido afectadas."
                    MsgBox(mensaje)
                End Using
                query = tablasql.SelectWhereDesdeUpdateTokens(InputText1.tokenes)
            End If

            Using QueryDAO As New QueryDAO()
                datatable = QueryDAO.ExecuteSelectQuery(query)
            End Using
            If refresh Then
                fillTreeNode()
            End If

            ' InputText1.RichTextBox1.Text = query

            QueryResult.DataSource = datatable
            SplitContainer1.Panel2Collapsed = False
        End If

    End Sub

    Private Sub TreeView1_NodeMouseClick(sender As Object, e As TreeNodeMouseClickEventArgs) Handles TreeView1.NodeMouseClick

        If e.Button = MouseButtons.Right Then
            TreeView1.SelectedNode = e.Node

            For Each servidor In servidores.ListaServidores
                For Each db In servidor.ListaDatabases
                    If Not TreeView1.SelectedNode.Text = Nothing Then
                        If db.Nombre = TreeView1.SelectedNode.Text Then
                            EdicionDb.Show(System.Windows.Forms.Cursor.Position)
                        Else
                            For Each tabla In db.Tablas
                                If TreeView1.SelectedNode.Text = tabla.NombreTabla Then
                                    EdicionTablas.Show(System.Windows.Forms.Cursor.Position)
                                End If

                            Next

                        End If
                    End If
                Next
            Next
        End If
    End Sub

    Private Sub SelecionarTOP1000ToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles SelecionarTOP1000ToolStripMenuItem.Click

        Dim tablaSQL As New TablaSQL
        Dim query As String
        Dim coordenadas As Integer()
        Dim tabla As Tabla

        coordenadas = get_Coordenadas_Tabla(servidores, TreeView1.SelectedNode.Text, True)
        tabla = get_Tabla_Coordenadas(servidores, coordenadas)

        query = tablaSQL.Selecttop100Query(tabla)
        InputText1.RichTextBox1.Text = query

        EjecutarSQLTextBox()
    End Sub

    Private Sub GenerarSQLToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles GenerarSQLToolStripMenuItem.Click
        Dim tablaSQL As New TablaSQL
        Dim query As String
        Dim coordenadas As Integer()
        Dim tabla As Tabla

        coordenadas = get_Coordenadas_Tabla(servidores, TreeView1.SelectedNode.Text)

        tabla = listaDatabases.ElementAt(coordenadas(0)).Tablas.ElementAt(coordenadas(1))
        query = tablaSQL.Crear(tabla)
        InputText1.RichTextBox1.Text = query
    End Sub

    Private Sub EliminarTablaToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles EliminarTablaToolStripMenuItem.Click
        Dim tablaSQL As New TablaSQL
        Dim query As String
        Dim coordenadas As Integer()
        Dim tabla As New Tabla

        coordenadas = get_Coordenadas_Tabla(servidores, TreeView1.SelectedNode.Text)

        tabla = listaDatabases.ElementAt(coordenadas(0)).Tablas.ElementAt(coordenadas(1))
        query = tablaSQL.Eliminar(tabla)
        InputText1.RichTextBox1.Text = query

    End Sub

    Private Sub GenerarSQLToolStripMenuItem1_Click(sender As Object, e As EventArgs) Handles GenerarSQLToolStripMenuItem1.Click
        Dim db As Database
        Dim query As String
        Dim coordenadas As Integer
        Dim dbSQLbuilder As New DatabaseSQL

        coordenadas = get_BD_Index_ListaDb(listaDatabases, TreeView1.SelectedNode.Text)

        db = listaDatabases.ElementAt(coordenadas)
        query = dbSQLbuilder.Crear(db)
        InputText1.RichTextBox1.Text = query

    End Sub

    Private Sub Menu1_new_server_add(servidor As Servidores) Handles Menu1.new_server_add
        servidores = Menu1.Servidores
        fillTreeNode()
    End Sub

    Private Sub Menu1_added_sql(SQL As String) Handles Menu1.added_sql
        Sqlquery = SQL
        print_sql_editor()

    End Sub

    'Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
    '    For Each db In listaDatabases
    '        If db.Nombre = "" Then
    '            For Each tabla In db.Tablas
    '                lista.Add(tablaSql.Crear(tabla))
    '            Next

    '        End If
    '    Next
    '    SaveFileDialog1.Filter = "Sql files (*.sql)|*.sql|All files (*.*)|*.*"
    '    SaveFileDialog1.ShowDialog()
    '    If SaveFileDialog1.ShowDialog.OK Then

    '        Dim sw As StreamWriter = New StreamWriter(SaveFileDialog1.FileName)
    '        If sw IsNot Nothing Then
    '            sw.Write(reg.generarString(lista))
    '        End If

    '        sw.Close()
    '        MessageBox.Show("Tu archivo se a guardado de forma correcta")
    '    End If
    'End Sub

End Class