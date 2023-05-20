Imports System.IO

Public Class Main
    Public listaDatabases As List(Of Database)
    Dim reg As New Registro
    Public lista As New List(Of String)
    Dim tablaSql As New TablaSQL
    Public bdseleccionada As String = ""
    Public servidorSelec As String = ""


    Public Sub New()

        Dim root As New TreeNode(Login.servidor.NombreServidor)

        ' Esta llamada es exigida por el diseñador.
        InitializeComponent()

        SplitContainer1.Panel2Collapsed = True

        TreeView1.Nodes.Add(root)
        Using DatabaseDAO As New DatabaseDAO()
            listaDatabases = DatabaseDAO.FindAll()
        End Using
        For Each Database In listaDatabases
            Database.Servidor = Login.servidor
            Login.servidor.ModificarConexionString(Database.Nombre)
            TreeView1.Nodes(0).Nodes.Add(New TreeNode(Database.Nombre))

            Using TablaDAO As New TablaDAO()
                Database.Tablas = TablaDAO.LightFindAll()
            End Using
        Next
        For Each Database In listaDatabases
            Login.servidor.ModificarConexionString(Database.Nombre)
            For Each tabla In Database.Tablas
                Using ColumnaDAO As New ColumnaDAO()
                    tabla.Columnas = ColumnaDAO.LightFindAll(tabla.NombreTabla)
                End Using
                Using IndiceDao As New IndiceDAO
                    tabla.Indices = IndiceDao.FindByTable(tabla.NombreTabla)
                End Using
            Next
        Next
        For Each db In listaDatabases
            Dim asd As New BDSelector(db.Nombre, db.Servidor.NombreServidor, db)
            AddHandler asd.Eleccion, AddressOf seleccionServidor
            AddHandler asd.EleccionBD, AddressOf seleccionarBD

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
    Private Sub seleccionServidor(servidor As String, baseDatos As String)
        Menu1.SerBDSeleccionados1.Label3.Text = servidor
        Menu1.SerBDSeleccionados1.Label4.Text = baseDatos
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
        For Each Database In listaDatabases

            For Each tabla In Database.Tablas

                If TreeView1.SelectedNode.Text = tabla.NombreTabla Then
                    For Each columna In tabla.Columnas
                        DataGridView1.Rows.Add(columna.Nombre, columna.OrdenColumna, columna.tipoDato.ToString)

                        Label1.Text = TreeView1.SelectedNode.Text
                    Next

                End If
            Next
        Next

    End Sub


    Public Sub ejecutarSQLTextBox()
        Dim datatable As DataTable
        Dim bs As New BindingSource

        GC.Collect()
        Using QueryDAO As New QueryDAO()
            datatable = QueryDAO.ExecuteQuery(InputText1.RichTextBox1.Text)
        End Using

        QueryResult.DataSource = datatable



        SplitContainer1.Panel2Collapsed = False

    End Sub


    Private Sub TreeView1_NodeMouseClick(sender As Object, e As TreeNodeMouseClickEventArgs) Handles TreeView1.NodeMouseClick

        If e.Button = MouseButtons.Right Then

            TreeView1.SelectedNode = e.Node

            For Each db In listaDatabases

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
        End If
    End Sub

    Private Sub SelecionarTOP1000ToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles SelecionarTOP1000ToolStripMenuItem.Click

        Dim tablaSQL As New TablaSQL
        Dim query As String
        Dim coordenadas As Integer()
        Dim tabla As New Tabla

        coordenadas = get_Coordenadas_Tabla(listaDatabases, TreeView1.SelectedNode.Text)
        tabla = listaDatabases.ElementAt(coordenadas(0)).Tablas.ElementAt(coordenadas(1))
        query = tablaSQL.Selecttop100Query(tabla)


        InputText1.RichTextBox1.Text = query
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
