Public Class Form1
    Private listaDatabases As List(Of Database)


    Public Sub New()

        ' Esta llamada es exigida por el diseñador.
        InitializeComponent()
        Using DatabaseDAO As New DatabaseDAO()
            listaDatabases = DatabaseDAO.FindAll()
        End Using
        For Each Database In listaDatabases
            Login.servidor.ModificarConexionString(Database.Nombre)

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
            Dim asd As New BDSelector(db.Nombre)
            FlowLayoutPanel1.Controls.Add(asd)


            If db.Nombre = "GESTIONSQL" Then
                For Each tabla In db.Tablas

                    Dim bs As New BindingSource()

                    TablaBindingSource.Add(tabla)
                Next

            End If
        Next
        DataGridView1.DataSource = TablaBindingSource()





        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().

    End Sub

    Private Sub BdSelector1_Load(sender As Object, e As EventArgs)

    End Sub

    Private Sub FlowLayoutPanel1_Paint(sender As Object, e As PaintEventArgs) Handles FlowLayoutPanel1.Paint

    End Sub
End Class