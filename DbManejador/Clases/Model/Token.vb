Imports System.Net.Security

Public Class Token
    Private _contenido As String
    Private _inicio As Integer
    Private _final As Integer
    Private _tipo As TipoToken
    Public Enum TipoToken
        TOKEN_KEYWORD
        TOKEN_COMILLAS
        TOKEN_OPERADORES
        TOKEN_COMILLAS_SIMPLES
    End Enum

    Public Sub New(inicio As Integer, final As Integer, tipoToken As TipoToken)
        Me.Inicio = inicio
        Me.Final = final
        Me.Tipo = tipoToken
    End Sub
    Public Sub New(contenido As String, inicio As Integer, final As Integer, tipoToken As TipoToken)
        Me.Contenido = contenido
        Me.Inicio = inicio
        Me.Final = final
        Me.Tipo = tipoToken
    End Sub


#Region "Getters y setters"
    Public Property Contenido As String
        Get
            Return _contenido
        End Get
        Set(value As String)
            _contenido = value
        End Set
    End Property

    Public Property Inicio As Integer
        Get
            Return _inicio
        End Get
        Set(value As Integer)
            _inicio = value
        End Set
    End Property

    Public Property Final As Integer
        Get
            Return _final
        End Get
        Set(value As Integer)
            _final = value
        End Set
    End Property

    Public Property Tipo As TipoToken
        Get
            Return _tipo
        End Get
        Set(value As TipoToken)
            _tipo = value
        End Set
    End Property
#End Region

End Class
