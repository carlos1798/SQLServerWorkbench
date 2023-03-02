Public Class Restriccion
    Dim nombre As String
    Dim tipoRestriccion As Tipo
    Dim valorDefecto As String

    Public Sub New(nombre As String, tipoRestriccion As Tipo, valorDefecto As String)
        Me.nombre = nombre
        Me.tipoRestriccion = tipoRestriccion
        If tipoRestriccion.Equals(Tipo.DEFECTO) Then
            Me.valorDefecto = valorDefecto
        End If

    End Sub

    Enum Tipo
        NOTNULL
        UNIQUE
        PRIMARYKEY
        FOREINGKEY
        CHECK
        DEFECTO
    End Enum
End Class
