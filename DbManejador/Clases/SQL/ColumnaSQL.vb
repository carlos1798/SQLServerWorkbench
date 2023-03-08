Public Class ColumnaSQL
    Inherits GeneradorSQL


    ''' <summary>
    ''' 
    ''' </summary>
    ''' <param name="Objeto"></param>
    ''' <returns>String</returns>
    Public Function Crear(columna As Columna, nombre_tabla As String) As String
        Dim addColumna As String
        Dim queryGeneral As String = $"ALTER TABLE {nombre_tabla}"
        addColumna = $" ADD {columna.Nombre} {TipoDatoToString(columna.tipoDato)}{GenerarNulo(columna.isNullable)}"
        queryGeneral = queryGeneral + vbCr + addColumna
        Return queryGeneral
    End Function

    Public Function Eliminar(columna As Columna, nombre_tabla As String) As String
        Dim delete_column As String
        Dim queryGeneral As String = $"ALTER TABLE {nombre_tabla}"
        delete_column = $" DROP COLUMN {columna.Nombre}"
        queryGeneral = queryGeneral + vbCr + delete_column
        Return queryGeneral

    End Function

    Public Function Modificar(columna_original As Columna, nueva_columna As Columna) As String

        Throw New NotImplementedException()
    End Function
End Class
