Public Class GeneradorSQL

    Public Sub New()
    End Sub

    'Sub GenerarSql(nombreFichero As String, tablas As Tabla())
    '    For Each tabla In tablas

    '    Next

    'End Sub

    Public Function TipoDatoToString(dato As Tipo)
        Dim tipoDatoString As String
        If dato.numeroCaracteres = Nothing Then
            tipoDatoString = $"{dato.tipoDato}"
        Else
            tipoDatoString = $"{dato.tipoDato} ({dato.numeroCaracteres})"
        End If
        Return tipoDatoString
    End Function


    Function GenerarIdentity(isIdentity As Boolean)
        Dim sentenciaIdentity As String
        If isIdentity Then
            sentenciaIdentity = "IDENTITY (1, 1)"
        Else
            sentenciaIdentity = ""
        End If
        Return sentenciaIdentity
    End Function

    Function GenerarNulo(isNull As Boolean)
        Dim sentenciaNull As String
        If isNull Then
            sentenciaNull = "NULL"
        Else
            sentenciaNull = "NOT NULL"
        End If
        Return sentenciaNull

    End Function


    Public Function ColumnasIndices(indice As Indice)
        Dim stringColumnas As String = ""

        For Each columna In indice.Columnas
            If indice.Columnas.Last Is columna Then

                stringColumnas += $"[{columna.Nombre}]"
            Else
                stringColumnas += $"[{columna.Nombre}],"

            End If

        Next
        Return stringColumnas
    End Function

    Public Function CrearIndice(indice As Indice)
        Dim addIndice As String = $"CREATE {indice.TipoIndice} INDEX {indice.Nombre} ON [dbo].[{indice.NombreTabla}]({ColumnasIndices(indice)}) WITH FILLFACTOR ={indice.FillFactor} ON [PRIMARY]"
        Return addIndice
    End Function

End Class