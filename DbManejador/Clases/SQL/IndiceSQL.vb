Public Class IndiceSQL
    Public Function EliminarIndiceSQL(nombreTabla As String, nombreIndice As String) As String
        Dim sql = $"DROP INDEX {nombreTabla}.{nombreIndice}"
        Return sql
    End Function

    Public Function CrearIndiceSQL(indice As Indice)
        Dim addIndice As String = $"CREATE {indice.TipoIndice} INDEX {indice.Nombre} ON [dbo].[{indice.NombreTabla}]({columnasIndices(indice)}) WITH FILLFACTOR ={indice.FillFactor} ON [PRIMARY]"
        Return addIndice
    End Function
    Public Function columnasIndices(indice As Indice)
        Dim stringColumnas As String = ""

        For Each columna In indice.Columnas
            If indice.Columnas.Last Is columna Then
                stringColumnas = stringColumnas + $"[{columna.Nombre}]"
            Else
                stringColumnas = stringColumnas + $"[{columna.Nombre}],"
            End If
        Next
        Return stringColumnas
    End Function


End Class