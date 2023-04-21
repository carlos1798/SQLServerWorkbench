Public Class Servidores
    Implements IDisposable
    Private _listaServidores As List(Of Servidor)
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

    Public Sub Dispose() Implements IDisposable.Dispose
        ListaServidores = Nothing
    End Sub
End Class
