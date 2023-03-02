Public Class Tipo
    Public tipoDato As String
    Public numeroCaracteres As Integer

    Public Sub New()
    End Sub

    Public Sub New(tipoDato As String)
        Me.tipoDato = tipoDato
    End Sub

    Public Sub New(tipoDato As String, numeroCaracteres As Integer)
        Me.tipoDato = tipoDato
        Me.numeroCaracteres = numeroCaracteres
    End Sub
End Class
