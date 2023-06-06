Public Class ColumnaSQL
    Inherits GeneradorSQL
    Implements SQLBuilder

    Public Function Crear(columna As Columna, nombre_tabla As String) As String
        Dim addColumna As String
        Dim queryGeneral As String = $"ALTER TABLE {nombre_tabla}"
        addColumna = $" ADD {columna.Nombre} {TipoDatoToString(columna.tipoDato)}{GenerarNulo(columna.IsNullable)}"
        queryGeneral = queryGeneral + vbCr + addColumna
        Return queryGeneral
    End Function

    Public Function Crear(ByRef Objeto As Object) As String Implements SQLBuilder.Crear
        Throw New NotImplementedException()
    End Function

    Public Function Eliminar(columna As Columna, nombre_tabla As String) As String
        Dim delete_column As String
        Dim queryGeneral As String = $"ALTER TABLE {nombre_tabla}"
        delete_column = $" DROP COLUMN {columna.Nombre}"
        queryGeneral = queryGeneral + vbCr + delete_column
        Return queryGeneral

    End Function

    Public Function Eliminar(ByRef Objeto As Object) As String Implements SQLBuilder.Eliminar
        Throw New NotImplementedException()
    End Function

    Public Function Modificar(ByRef ObjetoOrigial As Object, ByRef ObjetoNuevo As Object) As String Implements SQLBuilder.Modificar
        Throw New NotImplementedException()
    End Function

End Class