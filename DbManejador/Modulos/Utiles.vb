Imports System.Reflection

Public Module Utiles

    Public Sub DoubleBuffered(ByRef dgv As DataGridView, ByVal setting As Boolean)
        Dim dgvType As Type = dgv.[GetType]()
        Dim pi As PropertyInfo = dgvType.GetProperty("DoubleBuffered", BindingFlags.Instance Or BindingFlags.NonPublic)
        pi.SetValue(dgv, setting, Nothing)
    End Sub

    'Devuelve el indice donde esta, en el caso de que no se encuentre se devuelve -1
    Public Function get_BD_Index_ListaDb(ByRef listaBD As List(Of Database), nombreDB As String) As Integer
        Dim index As Integer = -1
        For Each Database In listaBD
            If nombreDB = Database.Nombre Then
                index = listaBD.IndexOf(Database)
            End If
        Next
        Return index
    End Function

    Public Function get_Table_Index_ListaDb(ByRef listaTablas As List(Of Tabla), nombre_tabla As String) As Integer
        Dim index As Integer = -1
        For Each tabla In listaTablas
            If nombre_tabla = tabla.NombreTabla Then
                index = listaTablas.IndexOf(tabla)
            End If
        Next
        Return index
    End Function

    Public Function get_Coordenadas_DB_Tabla(listaDB As List(Of Database), nombre_tabla As String, nombre_db As String) As Integer()
        Dim coordenadas As Integer() = {-1, -1}
        coordenadas(0) = get_BD_Index_ListaDb(listaDB, nombre_db)
        coordenadas(1) = get_Table_Index_ListaDb(listaDB.ElementAt(coordenadas(0)).Tablas, nombre_tabla)
        Return coordenadas
    End Function

    Public Function get_Coordenadas_Tabla(nombre_tabla As String, Optional Set_Servidor As Boolean = False) As Integer()
        Dim coordenadas As Integer() = {-1, -1, -1}
        For Each servidor In Login.servidores.ListaServidores
            For Each db In servidor.ListaDatabases
                For Each tabla In db.Tablas
                    If nombre_tabla = tabla.NombreTabla Then
                        coordenadas(0) = Login.servidores.ListaServidores.IndexOf(servidor)
                        coordenadas(1) = servidor.ListaDatabases.IndexOf(db)
                        coordenadas(2) = db.Tablas.IndexOf(tabla)
                        Exit For
                    End If
                Next
            Next
        Next
        If Set_Servidor Then
            Login.servidores.ListaServidores.ElementAt(0).ModificarConexionString(Login.servidores.ListaServidores.ElementAt(0).ListaDatabases.ElementAt(coordenadas(1)).Nombre)
        End If

        Return coordenadas
    End Function
    Public Function get_Tabla_Coordenadas(coordenadas() As Integer) As Tabla
        Return Login.servidores.ListaServidores.ElementAt(0).ListaDatabases.ElementAt(coordenadas(1)).Tablas.ElementAt(coordenadas(2))
    End Function

End Module