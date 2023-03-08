Imports System.Data.SqlClient

Public Class DatabaseDAO
    Inherits ConexionBD
    Implements IDAO(Of Database)



    Public Function FindAll() As List(Of Database) Implements IDAO(Of Database).FindAll
        Dim listaDatabases As New List(Of Database)
        Dim SqlQuery As String = $"SELECT name FROM sys.databases where name = 'GESTIONSQL' "
        'when name not in('master','model','msdb','tempdb')"
        Try
            conectar()
            Dim comandoSql As New SqlCommand(SqlQuery, conexion)
            Dim lectorResultado As SqlDataReader = comandoSql.ExecuteReader
            Dim adaptador = New SqlDataAdapter(comandoSql)
            If lectorResultado.HasRows Then
                Do While lectorResultado.Read()
                    listaDatabases.Add(New Database With {
                                   .Nombre = lectorResultado("name")})
                Loop
            End If
        Catch ex As Exception
        End Try
        cerrarConexion()

        Return listaDatabases
    End Function

    Public Function FindBy(name As Object) As Database Implements IDAO(Of Database).FindBy
        Throw New NotImplementedException()

    End Function
End Class
