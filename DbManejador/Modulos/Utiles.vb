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

    Public Function get_Coordenadas_Tabla(listaDB As List(Of Database), nombre_tabla As String) As Integer()
        Dim coordenadas As Integer() = {-1, -1}
        For Each db In listaDB
            For Each tabla In db.Tablas
                If nombre_tabla = tabla.NombreTabla Then
                    coordenadas(0) = listaDB.IndexOf(db)
                    coordenadas(1) = db.Tablas.IndexOf(tabla)
                    Exit For
                End If
            Next

        Next

        Return coordenadas
    End Function

    Public Function get_Tabla_Por_Coordenadas(listabd As List(Of Database), coordenadas As Integer()) As Tabla
        Dim Tabla As Tabla = listabd.ElementAt(coordenadas(0)).Tablas.ElementAt(coordenadas(1))
        Return Tabla

    End Function

End Module