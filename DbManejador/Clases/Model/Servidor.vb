Imports System.Net.NetworkInformation

Public Class Servidor

    Dim nombreServidor As String
    Dim tipoLogin As TipoAutentificacion
    Dim usuario As String
    Dim contrasena As String
    Dim listaBaseDatos As List(Of Database)
    '    Dim nombreTest As String = "DESKTOP-LAV1DTM"

#Region "Setters y getters"
    Public Property NombreServidor1 As String
        Get
            Return nombreServidor
        End Get
        Set(value As String)
            nombreServidor = value
        End Set
    End Property

    Public Property TipoLogin1 As TipoAutentificacion
        Get
            Return tipoLogin
        End Get
        Set(value As TipoAutentificacion)
            tipoLogin = value
        End Set
    End Property

    Public Property Usuario1 As String
        Get
            Return usuario
        End Get
        Set(value As String)
            usuario = value
        End Set
    End Property

    Public Property Contrasena1 As String
        Get
            Return contrasena
        End Get
        Set(value As String)
            contrasena = value
        End Set
    End Property
#End Region
    Public Enum TipoAutentificacion
        WINDOWS
        SQLSERVER
    End Enum


    Public Sub New(nombreServidor As String, usuario As String, contrasena As String)
        Me.nombreServidor = nombreServidor
        Me.usuario = usuario
        Me.tipoLogin = TipoAutentificacion.SQLSERVER
        Me.contrasena = contrasena
    End Sub
    Public Sub New(nombreServidor As String)
        Dim userName As String = My.User.Name.ToString
        Dim trimUsername As String = userName.Remove(0, userName.LastIndexOf("\") + 1)

        Me.tipoLogin = TipoAutentificacion.WINDOWS
        Me.NombreServidor1 = nombreServidor
        Me.usuario = trimUsername

    End Sub
    Public Sub New()

    End Sub
    'Ejecutar funciones asincronas 
    '
    Public Function CheckExistenciaServidor()
        Dim exito As Boolean = False
        Dim ping As New Ping()
        Try
            Dim respuesta = ping.Send(Me.nombreServidor, 1000)
            exito = True
        Catch ex As Exception
            Debug.Write(ex.Message)
        End Try
        Return exito
    End Function
    Public Function CrearConexionString() As String
        Dim conexion As String
        If tipoLogin = TipoAutentificacion.WINDOWS Then
            conexion = $"Data Source={nombreServidor} ;Initial Catalog=master;Integrated Security=True"


        Else
            conexion = $"Server={nombreServidor} ;Database=master;User Id={usuario};Password={contrasena};"
        End If
        Return conexion
    End Function
    Public Function ModificarConexionString(dbName As String) As String
        Dim conexion As String
        If tipoLogin = TipoAutentificacion.WINDOWS Then
            conexion = $"Data Source={nombreServidor} ;Initial Catalog={dbName};Integrated Security=True"
            My.Settings.ConnectionString = conexion
        Else
            conexion = $"Server={nombreServidor} ;Database=master;User Id={dbName};Password={contrasena};"
            My.Settings.ConnectionString = conexion
        End If
        Return conexion
    End Function


End Class
