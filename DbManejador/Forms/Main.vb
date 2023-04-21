Imports System.IO

Public Class Main
    Public listaDatabases As List(Of Database)
    Dim reg As New Registro
    Public lista As New List(Of String)
    Dim tablaSql As New TablaSQL
    Public bdseleccionada As String = ""
    Public servidorSelec As String = ""


    Public Sub New()

        Dim root As New TreeNode(Login.servidor.NombreServidor1)

        ' Esta llamada es exigida por el diseñador.
        InitializeComponent()

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
            Dim asd As New BDSelector(db.Nombre, db.Servidor.NombreServidor1, db)
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



        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().

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
                        DataGridView1.Rows.Add(columna.Nombre, columna.OrdenColumna, columna.tipoDato.ToString, columna.IsNullable)
                    Next

                End If
            Next
        Next

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
