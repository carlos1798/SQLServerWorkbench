'Plan para esta clase es meter todos los metodos que sean la conexion con la bd "master" para sacar informacion del servidor
'Test de conexiones, las bases de datos que hay en el servidor ,etc 
Public Class ServidorDAO
    Inherits ConexionBD
    Implements IDAO(Of Servidor)

    Public Function FindBy(servidor As Object) As Servidor Implements IDAO(Of Servidor).FindBy

        Using DatabaseDAO As New DatabaseDAO()
            servidor.listaDatabases = DatabaseDAO.FindAll()
        End Using
        For Each Database In servidor.listaDatabases
            Database.Servidor = servidor
            servidor.ModificarConexionString(Database.Nombre)
            Using TablaDAO As New TablaDAO()
                Database.Tablas = TablaDAO.FindAll()
            End Using
        Next
        For Each Database In servidor.listaDatabases
            servidor.ModificarConexionString(Database.Nombre)
            For Each tabla In Database.Tablas
                Using ColumnaDAO As New ColumnaDAO()
                    tabla.Columnas = ColumnaDAO.LightFindAll(tabla.NombreTabla)
                End Using
                Using IndiceDao As New IndiceDAO
                    tabla.Indices = IndiceDao.FindByTable(tabla.NombreTabla)
                End Using
            Next
        Next
        Return servidor

    End Function


    Public Function FindAll() As List(Of Servidor) Implements IDAO(Of Servidor).FindAll
        Throw New NotImplementedException()
    End Function
End Class
