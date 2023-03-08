Public Class IndiceSQL
    Public Function EliminarIndiceSQL(nombreTabla As String, nombreIndice As String) As String
        Dim sql = $"DROP INDEX {nombreTabla}.{nombreIndice}"
        Return sql
    End Function

    Public Function CrearIndiceSQL(indice As Indice, nombre_tabla As String) As String
        If indice.Unico = True Then

        Else

            Dim sql = $"CREATE INDEX ON {}{nombre_tabla}"
        End If
        Return Sql

    End Function
End Class