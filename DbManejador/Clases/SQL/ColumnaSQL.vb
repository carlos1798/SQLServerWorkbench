Public Class ColumnaSQL
    Inherits GeneradorSQL


    Public Function Crear(columna As Columna, nombre_tabla As String) As String
        Dim addColumna As String
        Dim queryGeneral As String = $"ALTER TABLE {nombre_tabla}"
        addColumna = $" ADD {columna.Nombre} {TipoDatoToString(columna.tipoDato)}{GenerarNulo(columna.IsNullable)}"
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
        'TODO:
        'Para que funcione debe de tener el mismo nombre
        '1.Comparar el tipo de dato
        '2.Numero de caracterares
        '3.El orden
        '4.Las restricciones que tiene asignadas
        '5.Si es nullable
        '6.Si tiene valor por defecto

        Throw New NotImplementedException()
    End Function
End Class
