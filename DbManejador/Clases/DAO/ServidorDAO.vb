'Plan para esta clase es meter todos los metodos que sean la conexion con la bd "master" para sacar informacion del servidor
'Test de conexiones, las bases de datos que hay en el servidor ,etc 
Public Class ServidorDAO
    Implements IDAO(Of Servidor)

    Public Function FindBy(name As Object) As Servidor Implements IDAO(Of Servidor).FindBy
        Throw New NotImplementedException()
    End Function

    Public Function FindAll() As List(Of Servidor) Implements IDAO(Of Servidor).FindAll
        Throw New NotImplementedException()
    End Function
End Class
