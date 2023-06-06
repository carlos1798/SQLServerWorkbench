Public Class Servidores
    Inherits Servidor
    Implements IDisposable

    Private _listaServidores As List(Of Servidor)

    Public Sub New(listaServidores As List(Of Servidor))
        Me.ListaServidores = listaServidores
    End Sub

    Public Sub New()
        Me.ListaServidores = New List(Of Servidor)
    End Sub

    Public Property ListaServidores As List(Of Servidor)
        Get
            Return _listaServidores
        End Get
        Set(value As List(Of Servidor))
            _listaServidores = value
        End Set
    End Property

    Public Function ExisteEnArchivo(servidor As Servidor) As Boolean
        For Each server In Me.ListaServidores
            If server.NombreServidor = servidor.NombreServidor Then
                Return True
            End If
        Next
        Return False

    End Function

    Public Sub Dispose() Implements IDisposable.Dispose
        ListaServidores = Nothing
    End Sub

End Class