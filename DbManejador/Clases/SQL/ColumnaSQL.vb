Public Class ColumnaSQL
    Inherits GeneradorSQL
    Implements SQLBuilder


    ''' <summary>
    '''  La introducimos una tabla y creamos las columnas 
    ''' </summary>
    ''' <param name="Tabla"></param>
    ''' <returns></returns>
    Public Function Crear(ByRef Objeto As Object) As String Implements SQLBuilder.Crear
        Dim addColumna As String
        Dim queryGeneral As String = ""
        For Each columna In Objeto.columnas
            addColumna = $"{columna.Nombre} {TipoDatoToString(columna.tipoDato)} {GenerarIdentity(columna.isIdentity)} {GenerarNulo(columna.isNullable)},"
            queryGeneral = queryGeneral + vbCr + addColumna
        Next
        Return queryGeneral
    End Function

    Public Function Eliminar(ByRef Objeto As Object) As String Implements SQLBuilder.Eliminar
        Throw New NotImplementedException()
    End Function

    Public Function Modificar(ByRef ObjetoOrigial As Object, ByRef ObjetoNuevo As Object) As String Implements SQLBuilder.Modificar
        Throw New NotImplementedException()
    End Function
End Class
