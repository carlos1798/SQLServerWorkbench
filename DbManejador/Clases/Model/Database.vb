Public Class Database
    Private _Nombre As String
    Private _Tablas As New List(Of Tabla)
    Private _Servidor As Servidor

    Public Sub New()
    End Sub

    Public Sub New(nombre As String)
        Me.Nombre = nombre
    End Sub

    Public Sub New(servidor As Servidor, tablas As List(Of Tabla), nombre As String)
        Me.Servidor = servidor
        Me.Tablas = tablas
        Me.Nombre = nombre
    End Sub

    Public Property Servidor() As Servidor
        Get
            Return _Servidor
        End Get
        Set(ByVal value As Servidor)
            _Servidor = value
        End Set
    End Property

    Public Property Tablas As List(Of Tabla)
        Get
            Return _Tablas
        End Get
        Set(value As List(Of Tabla))
            _Tablas = value
        End Set
    End Property

    Public Property Nombre As String
        Get
            Return _Nombre
        End Get
        Set(value As String)
            _Nombre = value
        End Set
    End Property
End Class
