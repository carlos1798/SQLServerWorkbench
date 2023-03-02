Public Class Servidores
    Implements IDisposable
    Public listaServidores As List(Of Servidor)
    Public Sub New()
        Me.listaServidores = New List(Of Servidor)

    End Sub

    Public Sub Dispose() Implements IDisposable.Dispose
        listaServidores = Nothing
    End Sub
End Class
