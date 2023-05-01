Imports System.Data.SqlClient

Public Class DatabaseDAO
    Inherits ConexionBD
    Implements IDAO(Of Database)



    Public Function FindAll() As List(Of Database) Implements IDAO(Of Database).FindAll
        Dim listaDatabases As New List(Of Database)
        Dim SqlQuery As String = $"SELECT name FROM sys.databases " 'where name = 'GESTIONSQL' "
        'when name not in('master','model','msdb','tempdb')"
        Try
            conectar()
            Using comandoSql As New SqlCommand(SqlQuery, conexion)
                Using lectorResultado As SqlDataReader = comandoSql.ExecuteReader
                    Using adaptador As New SqlDataAdapter(comandoSql)

                        If lectorResultado.HasRows Then
                            Do While lectorResultado.Read()
                                listaDatabases.Add(New Database With {
                                               .Nombre = lectorResultado("name")})
                            Loop
                        End If
                    End Using
                End Using
            End Using

        Catch ex As Exception

        End Try

        Return listaDatabases
    End Function

    Public Function FindBy(name As Object) As Database Implements IDAO(Of Database).FindBy
        Dim db As New Database
        Dim SqlQuery As String = $"SELECT {name} FROM sys.databases " 'where name = 'GESTIONSQL' "
        'when name not in('master','model','msdb','tempdb')"
        Try
            Conectar()
            Using comandoSql As New SqlCommand(SqlQuery, conexion)
                Using lectorResultado As SqlDataReader = comandoSql.ExecuteReader
                    Using adaptador As New SqlDataAdapter(comandoSql)

                        If lectorResultado.HasRows Then
                            Do While lectorResultado.Read()
                                If lectorResultado("name") = name Then
                                    db = New Database With {
                                               .Nombre = lectorResultado("name")}
                                End If
                            Loop
                        End If

                    End Using
                End Using
            End Using

        Catch ex As Exception
            Return Nothing
        End Try
        Return db
    End Function
End Class
