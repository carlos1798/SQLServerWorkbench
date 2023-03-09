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

    ''' <summary>
    ''' Devuelve una lista de Objetos tabla solo con el nombre cargado
    ''' </summary>
    ''' <returns></returns>
    'Falta anadir las restrcciones
    Public Function LightFindAll() As List(Of Tabla)
        Dim listaTablas As New List(Of Tabla)
        Dim SqlQuery As String = "SELECT TABLE_NAME FROM INFORMATION_SCHEMA.TABLES where TABLE_SCHEMA = 'dbo' and TABLE_TYPE = 'BASE TABLE'"

        Try
            Conectar()
            Dim comandoSql As New SqlCommand(SqlQuery, conexion)
            Dim lectorResultado As SqlDataReader = comandoSql.ExecuteReader
            Dim adaptador = New SqlDataAdapter(comandoSql)
            If lectorResultado.HasRows Then
                Do While lectorResultado.Read()
                    listaTablas.Add(New Tabla With {
                        .NombreTabla = lectorResultado("TABLE_NAME")
                        })

                Loop
            End If
            comandoSql.Dispose()
            comandoSql = Nothing
            lectorResultado.Close()
            lectorResultado = Nothing
            Return listaTablas
        Catch _Exception As Exception
            Console.WriteLine(_Exception.Message)

            Return Nothing
        End Try
    End Function
End Class
