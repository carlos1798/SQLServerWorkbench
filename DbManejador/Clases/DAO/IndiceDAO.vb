Imports System.Data.SqlClient

Public Class IndiceDAO
    Inherits ConexionBD
    Implements IDAO(Of Indice)

    Public Function FindBy(name As Object) As Indice Implements IDAO(Of Indice).FindBy
        Throw New NotImplementedException()
    End Function

    Public Function FindAll() As List(Of Indice) Implements IDAO(Of Indice).FindAll
        Throw New NotImplementedException()
    End Function

    Public Function FindByTable(nombreTabla As String) As List(Of Indice)
        Dim listaIndices As New List(Of Indice)
        Dim listaColumnas As New List(Of Columna)
        Dim nombreIndice As String
        Dim SqlQuery As String = $"SELECT a.name AS Index_Name, OBJECT_NAME(a.object_id), COL_NAME(b.object_id,b.column_id) AS Column_Name, b.index_column_id, b.key_ordinal, b.is_included_column, a.type_desc, a.is_unique,a.fill_factor  FROM sys.indexes AS a INNER JOIN sys.index_columns AS b ON a.object_id = b.object_id AND a.index_id = b.index_id WHERE a.object_id = OBJECT_ID('{nombreTabla}');"
        Dim nombreColumna As String
        Dim tipo As String
        Dim fillFactor As Integer
        Dim unico As Boolean
        Try

            conectar()
            Dim comandoSql As New SqlCommand(SqlQuery, conexion)
            Dim lectorResultado As SqlDataReader = comandoSql.ExecuteReader
            Dim adaptador = New SqlDataAdapter(comandoSql)
            If lectorResultado.HasRows Then
                Do While lectorResultado.Read()
                    nombreIndice = lectorResultado("Index_Name").ToString
                    nombreColumna = lectorResultado("Column_Name").ToString
                    tipo = lectorResultado("type_desc").ToString
                    Dim esUnico = lectorResultado("is_unique").ToString
                    fillFactor = lectorResultado("fill_factor").ToString

                    If listaIndices.Count = 0 Then
                        listaIndices.Add(New Indice With {.Nombre = nombreIndice, .Columnas = New List(Of Columna), .TipoIndice = tipo, .Unico = esUnico, .FillFactor = fillFactor, .NombreTabla = nombreTabla})
                        listaIndices.Last.Columnas.Add(New Columna With {.Nombre = nombreColumna})
                    ElseIf listaIndices.Last.Nombre.Equals(nombreIndice, StringComparison.Ordinal) Then
                        For Each indice In listaIndices
                            If indice.Nombre.Equals(nombreIndice, StringComparison.Ordinal) Then
                                indice.Columnas.Add(New Columna With {.Nombre = nombreColumna})
                            End If
                        Next
                    ElseIf Not listaIndices.Last.Nombre.Equals(nombreIndice) Then
                        listaIndices.Add(New Indice With {.Nombre = nombreIndice, .Columnas = New List(Of Columna), .TipoIndice = tipo, .Unico = esUnico, .FillFactor = fillFactor, .NombreTabla = nombreTabla})
                        listaIndices.Last.Columnas.Add(New Columna With {.Nombre = nombreColumna})
                    End If
                    unico = False
                Loop
            End If
            comandoSql.Dispose()
            comandoSql = Nothing
            lectorResultado.Close()
            lectorResultado = Nothing

        Catch _Exception As Exception
            Console.WriteLine(_Exception.Message)
            Return Nothing
        End Try
        cerrarConexion()
        Return listaIndices

    End Function
End Class
