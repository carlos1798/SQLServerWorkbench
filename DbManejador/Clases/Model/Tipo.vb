Public Class Tipo
    Private _tipoDato As String
    Private _numeroCaracteres As Integer

    Public Property TipoDato As String
        Get
            Return _tipoDato
        End Get
        Set(value As String)
            _tipoDato = value
        End Set
    End Property

    Public Property NumeroCaracteres As Integer
        Get
            Return _numeroCaracteres
        End Get
        Set(value As Integer)
            _numeroCaracteres = value
        End Set
    End Property

    Public Sub New()
    End Sub

    Public Sub New(tipoDato As String)
        Me.TipoDato = tipoDato
    End Sub

    Public Sub New(tipoDato As String, numeroCaracteres As Integer)
        Me.TipoDato = tipoDato
        Me.NumeroCaracteres = numeroCaracteres
    End Sub

    Public Overrides Function Equals(obj As Object) As Boolean
        Dim tipo = TryCast(obj, Tipo)
        Return tipo IsNot Nothing AndAlso
               _tipoDato = tipo._tipoDato AndAlso
               _numeroCaracteres = tipo._numeroCaracteres AndAlso
               TipoDato = tipo.TipoDato AndAlso
               NumeroCaracteres = tipo.NumeroCaracteres
    End Function

    Public Overrides Function ToString() As String
        If NumeroCaracteres <= 0 Then
            If TipoDato.Equals("NVARCHAR") Then
                Return $"{TipoDato}(MAX)".ToUpper
            Else
                Return $"{TipoDato}".ToUpper
            End If
        Else
            Return $"{TipoDato}({NumeroCaracteres})".ToUpper
        End If
    End Function

    Public Overrides Function GetHashCode() As Integer
        Return MyBase.GetHashCode()
    End Function

    Protected Overrides Sub Finalize()
        MyBase.Finalize()
    End Sub
End Class
