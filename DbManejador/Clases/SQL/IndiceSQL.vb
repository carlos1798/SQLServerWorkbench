Public Class IndiceSQL
    Inherits GeneradorSQL
    Implements SQLBuilder

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

    Public Function Crear(ByRef Objeto As Object) As String Implements SQLBuilder.Crear
        Throw New NotImplementedException()
    End Function

    Public Function Eliminar(ByRef Objeto As Object) As String Implements SQLBuilder.Eliminar
        Throw New NotImplementedException()
    End Function

    Public Function Modificar(ByRef ObjetoOrigial As Object, ByRef ObjetoNuevo As Object) As String Implements SQLBuilder.Modificar
        Throw New NotImplementedException()
    End Function

End Class