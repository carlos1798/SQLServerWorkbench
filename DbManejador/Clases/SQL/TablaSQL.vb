Public Class TablaSQL
    Inherits GeneradorSQL
    Implements SQLBuilder

    Public Function CrearTabla(tabla As Tabla)
    End Function

    Public Function Crear(ByRef Objeto As Object) As String Implements SQLBuilder.Crear

        Dim sentenciaCompleta As String
        Dim iniCrearTabla As String = $"CREATE TABLE {Objeto.NombreTabla}("
        sentenciaCompleta = iniCrearTabla + CrearColumnasTablasSQL(Objeto) + ");"
        sentenciaCompleta += CrearIndicesColumnasTablasSQL(Objeto)

        Return sentenciaCompleta
    End Function

    Public Function Eliminar(ByRef Objeto As Object) As String Implements SQLBuilder.Eliminar
        Return Drop(Objeto)
    End Function

    Public Function Modificar(ByRef ObjetoOrigial As Object, ByRef ObjetoNuevo As Object) As String Implements SQLBuilder.Modificar
        Throw New NotImplementedException()
    End Function

    Private Function Drop(tabla As Tabla) As String
        Return $"DROP TABLE {tabla.NombreTabla}"
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

    Public Function CrearIndicesColumnasTablasSQL(tabla As Tabla) As String
        Dim query As String = ""
        Dim indiceBuilder As New IndiceSQL
        For Each indice In tabla.Indices
            query += vbNewLine + indiceBuilder.CrearIndiceSQL(indice)
        Next
        Return query

    End Function

    Public Function Selecttop100Query(tabla As Tabla) As String
        Dim Query As String = ""
        Query += "SELECT TOP 1000" + vbCrLf
        For Each columna In tabla.Columnas

            If columna.Equals(tabla.Columnas.Last) Then
                Query += vbTab + $"[{columna.Nombre}]" + vbCrLf
            Else
                Query += vbTab + $"[{columna.Nombre}]," + vbCrLf
            End If

        Next
        Query += $"FROM {tabla.NombreTabla}"

        Return Query
    End Function

    'Parametros(columna,valor)
    Public Function SelectWhere(tabla As Tabla, parametros As Dictionary(Of String(), String)) As String
        Dim Query As String = ""
        Query += "SELECT *" + vbCrLf

        Query += $"FROM {tabla.NombreTabla}" + vbCrLf
        Query += " WHERE " + vbCrLf
        For Each parametro In parametros
            If parametro.Equals(parametros.First) Then
                Query += $"{parametro.Key} = '{parametro.Value}'" + vbCrLf
            Else
                Query += $"AND {parametro.Key} = '{parametro.Value}'" + vbCrLf
            End If
        Next
        Return Query

    End Function

    Public Function SelectWhereDesdeUpdateTokens(tokenes As List(Of Token)) As String
        Dim nombre_tabla As String = tokenes.ElementAt(1).Contenido
        Dim parametros As New Dictionary(Of String(), String)

        Try
            For i As Integer = 3 To tokenes.Count - 1
                If tokenes(i).Contenido.ToUpper = "WHERE" Or tokenes(i).Contenido.ToUpper = "AND" Then
                    Continue For
                End If
                If tokenes(i + 2).Tipo = Token.TipoToken.TOKEN_COMILLAS_SIMPLES Then

                    tokenes(i + 2).Contenido += "'"
                ElseIf tokenes(i + 2).Tipo = Token.TipoToken.TOKEN_COMILLAS_SIMPLES Then

                End If

                parametros.Add({tokenes(i).Contenido, tokenes(i + 1).Contenido}, tokenes(i + 2).Contenido)

                i += 2
            Next

            Dim Query As String = ""

            Query += "SELECT *" + vbCrLf
            Query += $"FROM {nombre_tabla}" + vbCrLf
            Query += " WHERE " + vbCrLf
            For Each parametro In parametros
                If parametro.Equals(parametros.First) Then
                    Query += $"{parametro.Key(0)} {parametro.Key(1)} {parametro.Value}" + vbCrLf
                Else
                    Query += $"AND {parametro.Key(0)} {parametro.Key(1)} {parametro.Value}" + vbCrLf
                End If
            Next
            Return Query
        Catch ex As Exception

            Return Nothing

        End Try

    End Function

End Class