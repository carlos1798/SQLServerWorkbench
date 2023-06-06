Public Class DatabaseSQL
    Implements SQLBuilder
    Dim sqlBuilderTablas As New TablaSQL

    Public Function Crear(DB As Database) As String
        Dim query As String
        query += $"CREATE DATABASE {DB.Nombre}" + vbNewLine
        For Each tabla In DB.Tablas
            query += sqlBuilderTablas.Crear(tabla) + vbNewLine
        Next
        Return query
    End Function

End Class