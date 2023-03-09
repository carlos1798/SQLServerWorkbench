Public Class TablaSQL
    Inherits GeneradorSQL
    Implements SQLBuilder


    Public Function CrearTabla(tabla As Tabla)
    End Function

    Public Function Crear(ByRef Objeto As Object) As String Implements SQLBuilder.Crear

        Dim sentenciaCompleta As String
        Dim iniCrearTabla As String = $"CREATE TABLE {Objeto.NombreTabla}("
        sentenciaCompleta = iniCrearTabla + CrearColumnasTablasSQL(Objeto) + ");"

        Return sentenciaCompleta
    End Function

    Public Function Eliminar(ByRef Objeto As Object) As String Implements SQLBuilder.Eliminar
        Throw New NotImplementedException()
    End Function

    Public Function Modificar(ByRef ObjetoOrigial As Object, ByRef ObjetoNuevo As Object) As String Implements SQLBuilder.Modificar
        Throw New NotImplementedException()
    End Function
    Public Function CrearColumnasTablasSQL(tabla As Tabla) As String
        Dim addColumna As String
        Dim queryGeneral As String = ""
        For Each columna In tabla.Columnas
            If tabla.Columnas.Last.Equals(columna) Then
                addColumna = $"{columna.Nombre} {TipoDatoToString(columna.tipoDato)} {GenerarIdentity(columna.IsIdentity)} {GenerarNulo(columna.IsNullable)}"
            Else
                addColumna = $"{columna.Nombre} {TipoDatoToString(columna.tipoDato)} {GenerarIdentity(columna.IsIdentity)} {GenerarNulo(columna.IsNullable)},"
            End If
            queryGeneral = queryGeneral + vbCr + addColumna
            addColumna = Nothing
            'Faltan las restricciones
        Next
        Return queryGeneral

    End Function
End Class
