Imports System
Imports System.Configuration
Imports System.Data.SqlClient
Public MustInherit Class ConexionBD
    Implements IDisposable

    Protected conexion As SqlConnection
    Protected comando As SqlCommand
    Dim connectionString = My.Settings.ConnectionString
    Private disposedValue As Boolean
#Region "Conexion"

    Public Sub New()
        Me.conexion = New SqlConnection()
        Me.connectionString = connectionString
        conexion.ConnectionString = connectionString
    End Sub

    Public Sub conectar()
        Try

            conexion.Open()
            MessageBox.Show("Conectado")
        Catch ex As Exception
            Console.WriteLine(ex.Message)
        End Try
    End Sub

    Public Sub cerrarConexion()
        If conexion.State = ConnectionState.Open Then
            conexion.Close()
        End If
    End Sub

#End Region


    'Devuelve el numero de registros que tiene una tabla introduciendo el nombre
    Public Function NumeroRegistros(nombreTabla As String) As Object
        Dim resultado As String = 0
        Dim SqlQuery As String = $"SELECT COUNT(*) as numReg FROM {nombreTabla}"
        Try

            If ConnectionState.Open Then
                conexion.Close()

            End If
            conexion.Open()
            Dim comandoSql As New SqlCommand(SqlQuery, conexion)
            Dim lectorResultado As SqlDataReader = comandoSql.ExecuteReader
            Dim adaptador = New SqlDataAdapter(comandoSql)
            If lectorResultado.HasRows Then
                Do While lectorResultado.Read()
                    Try

                        resultado = lectorResultado("numReg")
                    Catch ex As Exception
                        resultado = 0

                    End Try
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

    Public Function checkIdentity(nombreTabla As String)
        Dim listaColumnas As List(Of String) = New List(Of String)
        Dim SqlQuery As String = $"SELECT name, is_identity FROM sys.columns WHERE object_id = OBJECT_ID('{nombreTabla}') AND is_identity= 1"
        Dim nombre As String
        Try

            If ConnectionState.Open Then
                conexion.Close()

            End If
            conexion.Open()
            Dim comandoSql As New SqlCommand(SqlQuery, conexion)
            Dim lectorResultado As SqlDataReader = comandoSql.ExecuteReader
            Dim adaptador = New SqlDataAdapter(comandoSql)
            If lectorResultado.HasRows Then
                Do While lectorResultado.Read()
                    Try
                        nombre = lectorResultado("name").ToString

                        listaColumnas.Add(nombre)
                    Catch ex As Exception

                    End Try
                Loop
            End If
            comandoSql.Dispose()
            comandoSql = Nothing
        Catch _Exception As Exception
            Console.WriteLine(_Exception.Message)
            Return Nothing
        End Try
        conexion.Close()
        Return listaColumnas

    End Function

    'Devuelve las columnas que tiene una tabla
    Public Function GetColumnas(nombreTabla As String) As List(Of Columna)
        Dim resultado As List(Of Columna) = New List(Of Columna)
        Dim columnaAux As New Columna()
        Dim SqlQuery As String = $"SELECT COLUMN_NAME,ORDINAL_POSITION,DATA_TYPE,CHARACTER_MAXIMUM_LENGTH,COLUMN_DEFAULT,IS_NULLABLE FROM INFORMATION_SCHEMA.COLUMNS WHERE TABLE_NAME ='{nombreTabla}'"
        Dim tdato As New Tipo()
        Dim isNullable As Boolean = False
        Dim isIdentity As Boolean = False
        Dim listaIdentity As New List(Of String)
        listaIdentity = checkIdentity(nombreTabla)
        Try
            If ConnectionState.Open Then
                conexion.Close()
            End If

            conexion.Open()
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

                        tdato.numeroCaracteres = CInt(lectorResultado("CHARACTER_MAXIMUM_LENGTH").ToString)
                    Catch ex As Exception

                        tdato.numeroCaracteres = Nothing
                    End Try
                    Try
                        defecto = lectorResultado("COLUMN_DEFAULT")
                    Catch ex As Exception
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

    Function generarTabla(nombre As String) As Tabla
        Dim tabla As New Tabla With {
        .nombreTabla = nombre,
        .totFilas = NumeroRegistros(nombre),
        .columnas = GetColumnas(nombre)}    '    '   Me.indexes = getIndexes(nombre)---->Devuelve la lista de indices

        '    '   Me.restricciones = getRestricciones(nombre) ----> Devuelve las restricciones de la tabla

        '    'Function totalFilas(nombreTabla As String)As Long
        '    ' Dim sql As String = ""
        '    ' Conexion.blablabla
        Return tabla

    End Function

    Function generarTablaSinRegistros(nombre As String)
        Dim tabla As New Tabla With {
        .nombreTabla = nombre,
        .columnas = GetColumnas(nombre),
        .indices = getIndices(nombre)
       }
        Return tabla

    End Function

    Function allNombreTablas()
        Dim nombreTabla As List(Of String) = New List(Of String)
        Dim resultado As List(Of Tabla) = New List(Of Tabla)
        Dim SqlQuery As String = "SELECT TABLE_NAME FROM INFORMATION_SCHEMA.TABLES where TABLE_SCHEMA = 'dbo' and TABLE_TYPE = 'BASE TABLE'"

        Try
            If ConnectionState.Open Then
                conexion.Close()

            End If

            conexion.Open()
            Dim comandoSql As New SqlCommand(SqlQuery, conexion)
            Dim lectorResultado As SqlDataReader = comandoSql.ExecuteReader
            Dim adaptador = New SqlDataAdapter(comandoSql)
            If lectorResultado.HasRows Then
                Do While lectorResultado.Read()
                    Dim nombre = lectorResultado("TABLE_NAME").ToString
                    nombreTabla.Add(nombre)
                    nombre = Nothing

                Loop
            End If
            comandoSql.Dispose()
            comandoSql = Nothing
        Catch _Exception As Exception
            Console.WriteLine(_Exception.Message)
            Return Nothing
        End Try
        conexion.Close()
        Return nombreTabla

    End Function

    Function getIndices(nombreTabla As String)
        Dim listaIndices As New List(Of Indice)
        Dim listaColumnas As New List(Of Columna)
        Dim nombreIndice As String
        Dim SqlQuery As String = $"SELECT a.name AS Index_Name, OBJECT_NAME(a.object_id), COL_NAME(b.object_id,b.column_id) AS Column_Name, b.index_column_id, b.key_ordinal, b.is_included_column, a.type_desc, a.is_unique,a.fill_factor  FROM sys.indexes AS a INNER JOIN sys.index_columns AS b ON a.object_id = b.object_id AND a.index_id = b.index_id WHERE a.object_id = OBJECT_ID('{nombreTabla}');"
        Dim nombreColumna As String
        Dim tipo As String
        Dim fillFactor As Integer
        Dim unico As Boolean
        Try
            If ConnectionState.Open Then
                conexion.Close()

            End If

            conexion.Open()
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
        Catch _Exception As Exception
            Console.WriteLine(_Exception.Message)
            Return Nothing
        End Try
        conexion.Close()
        Return listaIndices
    End Function

    Protected Overridable Sub Dispose(disposing As Boolean)
        If Not disposedValue Then
            If disposing Then
                cerrarConexion()
            End If
            conexion = Nothing
            connectionString = Nothing
            disposedValue = True
        End If
    End Sub

    ' ' TODO: reemplazar el finalizador solo si "Dispose(disposing As Boolean)" tiene código para liberar los recursos no administrados
    ' Protected Overrides Sub Finalize()
    '     ' No cambie este código. Coloque el código de limpieza en el método "Dispose(disposing As Boolean)".
    '     Dispose(disposing:=False)
    '     MyBase.Finalize()
    ' End Sub

    Public Sub Dispose() Implements IDisposable.Dispose
        ' No cambie este código. Coloque el código de limpieza en el método "Dispose(disposing As Boolean)".
        Dispose(disposing:=True)
        GC.SuppressFinalize(Me)
    End Sub
End Class
