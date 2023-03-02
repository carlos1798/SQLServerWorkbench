Imports System.Data.SqlClient

Public Class ColumnaDAO
    Inherits ConexionBD
    Implements IDAO(Of Columna)

    Public Function FindBy(name As Object) As Columna Implements IDAO(Of Columna).FindBy
        Throw New NotImplementedException()
    End Function

    Public Function FindAll() As List(Of Columna) Implements IDAO(Of Columna).FindAll
        Throw New NotImplementedException()
    End Function
    ''' <summary>
    ''' Devuelve todas las columnas de una tabla determinada
    ''' </summary>
    ''' <param name="nombreTabla"></param>
    ''' <returns></returns>
    Public Function LightFindAll(nombreTabla As String) As List(Of Columna)
        Dim resultado As List(Of Columna) = New List(Of Columna)
        Dim columnaAux As New Columna()
        Dim SqlQuery As String = $"SELECT COLUMN_NAME,ORDINAL_POSITION,DATA_TYPE,CHARACTER_MAXIMUM_LENGTH,COLUMN_DEFAULT,IS_NULLABLE FROM INFORMATION_SCHEMA.COLUMNS WHERE TABLE_NAME ='{nombreTabla}'"
        Dim tdato As New Tipo()
        Dim isNullable As Boolean = False
        Dim isIdentity As Boolean = False
        Dim listaIdentity As New List(Of String)
        listaIdentity = checkIdentity(nombreTabla)
        Try

            conectar()
            Dim comandoSql As New SqlCommand(SqlQuery, conexion)
            Dim lectorResultado As SqlDataReader = comandoSql.ExecuteReader
            Dim adaptador = New SqlDataAdapter(comandoSql)
            If lectorResultado.HasRows Then

                Do While lectorResultado.Read()
                    isIdentity = False
                    Dim nombre As String = lectorResultado("COLUMN_NAME").ToString
                    If listaIdentity IsNot Nothing Then
                        For Each nombreIdentidad In listaIdentity
                            If nombre.Equals(nombreIdentidad) Then
                                isIdentity = True
                            End If
                        Next
                    End If

                    Dim posicion As Integer = lectorResultado("ORDINAL_POSITION")
                    Dim tipoDato As String = lectorResultado("DATA_TYPE").ToString
                    tdato.tipoDato = lectorResultado("DATA_TYPE").ToString
                    Dim defecto As String
                    If lectorResultado("IS_NULLABLE").ToString = "YES" Then
                        isNullable = True

                    End If

                    Try
                        defecto = lectorResultado("COLUMN_DEFAULT")
                        tdato.numeroCaracteres = CInt(lectorResultado("CHARACTER_MAXIMUM_LENGTH").ToString)
                    Catch ex As Exception
                        tdato.numeroCaracteres = Nothing
                        defecto = Nothing
                    End Try

                    resultado.Add(New Columna With {
                        .Nombre = nombre,
                        .ordenColumna = posicion,
                        .tipoDato = tdato,
                        .valorDefecto = defecto,
                        .isNullable = isNullable,
                        .isIdentity = isIdentity})
                    posicion = Nothing
                    nombre = Nothing
                    tipoDato = Nothing
                Loop
            End If
            comandoSql.Dispose()
            comandoSql = Nothing
        Catch _Exception As Exception
            Console.WriteLine(_Exception.Message)
            Return Nothing
        End Try
        conexion.Close()

        Return resultado
    End Function


    End Function

End Class
