Imports System
Imports System.Configuration
Imports System.Data.SqlClient
Public MustInherit Class ConexionBD
    Implements IDisposable

    Protected conexion As SqlConnection
    Protected comando As SqlCommand
    Dim connectionString As String = My.Settings.ConnectionString
    Private disposedValue As Boolean
#Region "Conexion"

    Public Sub New()
        Me.conexion = New SqlConnection()
        Me.connectionString = connectionString
        conexion.ConnectionString = connectionString
    End Sub

    Public Sub Conectar()
        Try

            If Not ConnectionState.Open Then
                conexion.Open()
            End If

        Catch ex As Exception
            Console.WriteLine(ex.Message)
        End Try
    End Sub

    Public Sub CerrarConexion()
        If conexion.State = ConnectionState.Open Then
            conexion.Close()
        End If
    End Sub

#End Region

    'TODO:Meter esto en otro lado
    '    'Public Function NumeroRegistros(nombreTabla As String) As Object
    '    Dim resultado As String = 0
    '    Dim SqlQuery As String = $"SELECT COUNT(*) as numReg FROM {nombreTabla}"
    '    Try

    '        If ConnectionState.Open Then
    '            conexion.Close()

    '        End If
    '        conexion.Open()
    '        Dim comandoSql As New SqlCommand(SqlQuery, conexion)
    '        Dim lectorResultado As SqlDataReader = comandoSql.ExecuteReader
    '        Dim adaptador = New SqlDataAdapter(comandoSql)
    '        If lectorResultado.HasRows Then
    '            Do While lectorResultado.Read()
    '                Try

    '                    resultado = lectorResultado("numReg")
    '                Catch ex As Exception
    '                    resultado = 0

    '                End Try
    '            Loop
    '        End If
    '        comandoSql.Dispose()
    '        comandoSql = Nothing
    '    Catch _Exception As Exception
    '        Console.WriteLine(_Exception.Message)
    '        Return Nothing
    '    End Try
    '    conexion.Close()
    '    Return resultado
    'End Function


    'Devuelve las columnas que tiene una tabla
    'Public Function GetColumnas(nombreTabla As String) As List(Of Columna)
    '    Dim resultado As List(Of Columna) = New List(Of Columna)
    '    Dim columnaAux As New Columna()
    '    Dim SqlQuery As String = $"SELECT COLUMN_NAME,ORDINAL_POSITION,DATA_TYPE,CHARACTER_MAXIMUM_LENGTH,COLUMN_DEFAULT,IS_NULLABLE FROM INFORMATION_SCHEMA.COLUMNS WHERE TABLE_NAME ='{nombreTabla}'"
    '    Dim tdato As New Tipo()
    '    Dim isNullable As Boolean = False
    '    Dim isIdentity As Boolean = False
    '    Dim listaIdentity As New List(Of String)
    '    listaIdentity = checkIdentity(nombreTabla)
    '    Try
    '        If ConnectionState.Open Then
    '            conexion.Close()
    '        End If

    '        conexion.Open()
    '        Dim comandoSql As New SqlCommand(SqlQuery, conexion)
    '        Dim lectorResultado As SqlDataReader = comandoSql.ExecuteReader
    '        Dim adaptador = New SqlDataAdapter(comandoSql)
    '        If lectorResultado.HasRows Then

    '            Do While lectorResultado.Read()
    '                isIdentity = False
    '                Dim nombre As String = lectorResultado("COLUMN_NAME").ToString
    '                If listaIdentity IsNot Nothing Then
    '                    For Each nombreIdentidad In listaIdentity
    '                        If nombre.Equals(nombreIdentidad) Then
    '                            isIdentity = True
    '                        End If
    '                    Next
    '                End If

    '                Dim posicion As Integer = lectorResultado("ORDINAL_POSITION")
    '                Dim tipoDato As String = lectorResultado("DATA_TYPE").ToString
    '                tdato.tipoDato = lectorResultado("DATA_TYPE").ToString
    '                Dim defecto As String
    '                If lectorResultado("IS_NULLABLE").ToString = "YES" Then
    '                    isNullable = True

    '                End If



    '                resultado.Add(New Columna With {
    '        .Nombre = nombre,
    '        .ordenColumna = posicion,
    '        .tipoDato = tdato,
    '        .valorDefecto = defecto,
    '        .isNullable = isNullable,
    '        .isIdentity = isIdentity})
    '    posicion = Nothing
    '    nombre = Nothing
    '    tipoDato = Nothing
    '    Loop
    '    End If
    '    comandoSql.Dispose()
    '    comandoSql = Nothing
    '    lectorResultado.Close()
    '    lectorResultado = Nothing
    '    Return resultado

    '    Catch _Exception As Exception
    '    Console.WriteLine(_Exception.Message)
    '    Return Nothing
    '    End Try
    '    conexion.Close()

    '    Return resultado
    'End Function




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


    Public Sub Dispose() Implements IDisposable.Dispose
        ' No cambie este código. Coloque el código de limpieza en el método "Dispose(disposing As Boolean)".
        Dispose(disposing:=True)
        GC.SuppressFinalize(Me)
    End Sub
End Class
