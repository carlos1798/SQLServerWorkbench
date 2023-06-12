Public Class IndicesSugeridos
    Private _SQL As String

    Public Property SQL As String
        Get
            Return _SQL
        End Get
        Set(value As String)
            _SQL = value
        End Set
    End Property

End Class