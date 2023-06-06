Public Class Tabla
    Inherits Columna

    Private _nombreTabla As String
    Private _totFilas As Long
    Private _columnas As New List(Of Columna)
    Private _indices As New List(Of Indice)
    Private _restricciones As New List(Of Restriccion)
    Private _sentenciaSQL As String

    Public Sub New(nombreTabla As String, totFilas As Long, columnas As List(Of Columna), indexs As List(Of Indice), restricciones As List(Of Restriccion))
        Me.NombreTabla = nombreTabla
        Me.TotFilas = totFilas
        Me.Columnas = columnas
        Me.Indices = indexs
        Me.Restricciones = restricciones

    End Sub

    Public Sub New(nombreTabla As String)
        Me.NombreTabla = nombreTabla
    End Sub

    Public Sub New()
    End Sub

#Region "Getters y setters"

    Public Property TotFilas As Long
        Get
            Return _totFilas
        End Get
        Set(value As Long)
            _totFilas = value
        End Set
    End Property

    Public Property NombreTabla As String
        Get
            Return _nombreTabla
        End Get
        Set(value As String)
            _nombreTabla = value
        End Set
    End Property

    Public Property Columnas As List(Of Columna)
        Get
            Return _columnas
        End Get
        Set(value As List(Of Columna))
            _columnas = value
        End Set
    End Property

    Public Property Indices As List(Of Indice)
        Get
            Return _indices
        End Get
        Set(value As List(Of Indice))
            _indices = value
        End Set
    End Property

    Public Property Restricciones As List(Of Restriccion)
        Get
            Return _restricciones
        End Get
        Set(value As List(Of Restriccion))
            _restricciones = value
        End Set
    End Property

    Public Property SentenciaSQL As String
        Get
            Return _sentenciaSQL
        End Get
        Set(value As String)
            _sentenciaSQL = value
        End Set
    End Property

#End Region

    Public Sub AsignarClavePrimaria(listaClaves As List(Of String))
        For Each PK In listaClaves
            For Each columna In Columnas
                If columna.Nombre = PK Then
                    columna.IsIdentity = True
                End If
            Next
        Next
    End Sub

End Class