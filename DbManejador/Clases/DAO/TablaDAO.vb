Imports System.Data.SqlClient

Public Class TablaDAO
    Inherits ConexionBD
    Implements IDAO(Of Tabla)

    Public Function FindBy(name As Object) As Tabla Implements IDAO(Of Tabla).FindBy
        Throw New NotImplementedException()
    End Function

    Public Function FindAll() As List(Of Tabla) Implements IDAO(Of Tabla).FindAll
        Throw New NotImplementedException()
    End Function

    Public Function LightFindAll() As List(Of Tabla)
        Dim listaTablas As New List(Of Tabla)
        Dim SqlQuery As String = "SELECT TABLE_NAME FROM INFORMATION_SCHEMA.TABLES where TABLE_SCHEMA = 'dbo' and TABLE_TYPE = 'BASE TABLE'"

        Try
            Conectar()
            Using comandoSql As New SqlCommand(SqlQuery, conexion)
                Using lectorResultado As SqlDataReader = comandoSql.ExecuteReader
                    Using adaptador As New SqlDataAdapter(comandoSql)
                        If lectorResultado.HasRows Then
                            Do While lectorResultado.Read()
                                listaTablas.Add(New Tabla With {
                                    .NombreTabla = lectorResultado("TABLE_NAME")
                                    })

                            Loop
                        End If
                    End Using
                End Using
            End Using
            Return listaTablas
        Catch _Exception As Exception
            Console.WriteLine(_Exception.Message)

            Return Nothing
        End Try

    End Function
End Class
