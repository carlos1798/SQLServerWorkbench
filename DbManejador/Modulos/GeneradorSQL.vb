Public Class GeneradorSQL

    Public Sub New()
    End Sub

    Sub GenerarSql(nombreFichero As String, tablas As Tabla())
        For Each tabla In tablas

        Next

    End Sub

    Public Function tipoDatoToString(dato As Tipo)
        Dim tipoDatoString As String
        If dato.numeroCaracteres = Nothing Then
            tipoDatoString = $"{dato.tipoDato}"
        Else
            tipoDatoString = $"{dato.tipoDato} ({dato.numeroCaracteres})"
        End If
        Return tipoDatoString
    End Function

    Public Function crearTabla(tabla As Tabla)
        Dim sentenciaCompleta As String
        Dim iniCrearTabla As String = $"CREATE TABLE {tabla.nombreTabla}("
        sentenciaCompleta = iniCrearTabla + crearColumnas(tabla) + ")"

        Return sentenciaCompleta
    End Function

    Function generarIdentity(isIdentity As Boolean)
        Dim sentenciaIdentity As String
        If isIdentity Then
            sentenciaIdentity = "IDENTITY (1, 1)"
        Else
            sentenciaIdentity = ""
        End If
        Return sentenciaIdentity
    End Function

    Function generarNulo(isNull As Boolean)
        Dim sentenciaNull As String
        If isNull Then
            sentenciaNull = "NULL"
        Else
            sentenciaNull = "NOT NULL"
        End If
        Return sentenciaNull

    End Function

    Public Function crearColumnas(tabla As Tabla)
        Dim addColumna As String
        Dim queryGeneral As String = Nothing
        For Each columna In tabla.columnas
            addColumna = $"{columna.Nombre} {tipoDatoToString(columna.tipoDato)} {generarIdentity(columna.isIdentity)} {generarNulo(columna.isNullable)},"
            queryGeneral = queryGeneral + vbCr + addColumna
            addColumna = Nothing
        Next
        Return queryGeneral
    End Function

    Public Function columnasIndices(indice As Indice)
        Dim stringColumnas As String

        For Each columna In indice.Columnas
            If indice.Columnas.Last Is columna Then

                stringColumnas = stringColumnas + $"[{columna.Nombre}]"
            Else
                stringColumnas = stringColumnas + $"[{columna.Nombre}],"

            End If

        Next
        Return stringColumnas
    End Function

    Public Function crearIndice(indice As Indice)
        Dim addIndice As String = $"CREATE {indice.TipoIndice} INDEX {indice.Nombre} ON [dbo].[{indice.NombreTabla}]({columnasIndices(indice)}) WITH FILLFACTOR ={indice.FillFactor} ON [PRIMARY]"
        Return addIndice
    End Function

End Class