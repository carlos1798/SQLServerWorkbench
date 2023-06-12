Imports System.Reflection

Public Module Utiles

    Public Sub DoubleBuffered(ByRef dgv As DataGridView, ByVal setting As Boolean)
        Dim dgvType As Type = dgv.[GetType]()
        Dim pi As PropertyInfo = dgvType.GetProperty("DoubleBuffered", BindingFlags.Instance Or BindingFlags.NonPublic)
        pi.SetValue(dgv, setting, Nothing)
    End Sub

    'Devuelve el indice donde esta, en el caso de que no se encuentre se devuelve -1
    Public Function get_BD_Index_Servidores(ByRef servidores As Servidores, nombreBD As String) As Integer()

        Dim coordenadas As Integer() = {-1, -1, -1}
        For Each servidor In servidores.ListaServidores
            For Each Database In servidor.ListaDatabases
                If nombreBD = Database.Nombre Then
                    coordenadas(0) = servidores.ListaServidores.IndexOf(servidor)
                    coordenadas(1) = servidores.ListaServidores.ElementAt(coordenadas(0)).ListaDatabases.IndexOf(Database)

                End If
            Next
        Next
        Return coordenadas
    End Function

    Public Function get_Coordenadas_Tabla(servidores As Servidores, nombre_tabla As String, Optional Set_Servidor As Boolean = False) As Integer()
        Dim coordenadas As Integer() = {-1, -1, -1}
        For Each servidor In servidores.ListaServidores
            For Each db In servidor.ListaDatabases
                For Each tabla In db.Tablas
                    If nombre_tabla = tabla.NombreTabla Then
                        coordenadas(0) = servidores.ListaServidores.IndexOf(servidor)
                        coordenadas(1) = servidor.ListaDatabases.IndexOf(db)
                        coordenadas(2) = db.Tablas.IndexOf(tabla)
                        Exit For
                    End If
                Next
            Next
        Next
        If Set_Servidor Then
            servidores.ListaServidores.ElementAt(0).
                ModificarConexionString(servidores.ListaServidores.ElementAt(0).
                ListaDatabases.ElementAt(coordenadas(1)).Nombre)
        End If

        Return coordenadas
    End Function

    Public Function get_Db_Coordenadas(servidores As Servidores, coordenadas() As Integer) As Database

        Return servidores.ListaServidores.ElementAt(coordenadas(0)).ListaDatabases.ElementAt(coordenadas(1))
    End Function

    Public Function get_Tabla_Coordenadas(servidores As Servidores, coordenadas() As Integer) As Tabla
        Return servidores.ListaServidores.ElementAt(0).ListaDatabases.ElementAt(coordenadas(1)).Tablas.ElementAt(coordenadas(2))
    End Function

End Module