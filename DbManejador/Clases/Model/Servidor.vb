﻿Imports System.Net.NetworkInformation
Imports System.Runtime.Serialization
Imports System.Xml.Serialization

Public Class Servidor

    Private _nombreServidor As String
    Private _tipoLogin As TipoAutentificacion
    Private _usuario As String
    Private _contrasena As String
    Private _listaDatabases As List(Of Database)
    Private _seleccionado As Boolean
    Public Enum TipoAutentificacion
        WINDOWS
        SQLSERVER
    End Enum

#Region "Getters y setters"
    Public Property NombreServidor As String
        Get
            Return _nombreServidor
        End Get
        Set(value As String)
            _nombreServidor = value
        End Set
    End Property

    Public Property TipoLogin As TipoAutentificacion
        Get
            Return _tipoLogin
        End Get
        Set(value As TipoAutentificacion)
            _tipoLogin = value
        End Set
    End Property

    Public Property Usuario As String
        Get
            Return _usuario
        End Get
        Set(value As String)
            _usuario = value
        End Set
    End Property

    Public Property Contrasena As String
        Get
            Return _contrasena
        End Get
        Set(value As String)
            _contrasena = value
        End Set
    End Property

    Public Property ListaDatabases As List(Of Database)
        Get
            Return _listaDatabases
        End Get
        Set(value As List(Of Database))
            _listaDatabases = value
        End Set
    End Property

    Public Property Seleccionado As Boolean
        Get
            Return _seleccionado
        End Get
        Set(value As Boolean)
            _seleccionado = value
        End Set
    End Property

    '    Dim nombreTest As String = "DESKTOP-LAV1DTM"
#End Region

#Region "Constructores"
    Public Sub New(nombreServidor As String, usuario As String, contrasena As String)
        Me.NombreServidor = nombreServidor
        Me.Usuario = usuario
        Me.TipoLogin = TipoAutentificacion.SQLSERVER
        Me.Contrasena = contrasena
    End Sub
    Public Sub New(nombreServidor As String)
        Dim userName As String = My.User.Name.ToString
        Dim trimUsername As String = userName.Remove(0, userName.LastIndexOf("\") + 1)

        Me.TipoLogin = TipoAutentificacion.WINDOWS
        Me.NombreServidor = nombreServidor
        Me.Usuario = trimUsername

    End Sub
    Public Sub New()

    End Sub

#End Region
    Public Function CheckExistenciaServidor()
        Dim exito As Boolean = False
        Dim ping As New Ping()
        Try
            Dim respuesta = ping.Send(Me.NombreServidor, 1000)
            exito = True
        Catch ex As Exception
            Debug.Write(ex.Message)
        End Try
        Return exito
    End Function
    Public Function CrearConexionString() As String
        Dim conexion As String
        If TipoLogin = TipoAutentificacion.WINDOWS Then
            conexion = $"Data Source={NombreServidor} ;Initial Catalog=master;Integrated Security=True;MultipleActiveResultSets=true"
        Else
            conexion = $"Server={NombreServidor} ;Database=master;User Id={Usuario};Password={Contrasena};"
        End If
        Return conexion
    End Function
    Public Function ModificarConexionString(dbName As String) As String
        Dim conexion As String
        If TipoLogin = TipoAutentificacion.WINDOWS Then
            conexion = $"Data Source={NombreServidor} ;Initial Catalog={dbName};Integrated Security=True;MultipleActiveResultSets=true"
            My.Settings.ConnectionString = conexion
        Else
            conexion = $"Server={NombreServidor} ;Database=master;User Id={dbName};Password={Contrasena};MultipleActiveResultSets=true"
            My.Settings.ConnectionString = conexion
        End If
        Return conexion
    End Function

End Class
