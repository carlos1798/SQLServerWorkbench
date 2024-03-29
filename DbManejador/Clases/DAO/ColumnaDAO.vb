﻿Imports System.Data.SqlClient

Public Class ColumnaDAO
    Inherits ConexionBD
    Implements IDAO(Of Columna)

    Public Function FindBy(name As Object) As Columna Implements IDAO(Of Columna).FindBy
        Throw New NotImplementedException()
    End Function

    Public Function FindAll() As List(Of Columna) Implements IDAO(Of Columna).FindAll
        Throw New NotImplementedException()
    End Function

    Public Function LightFindAll(nombreTabla As String) As List(Of Columna)
        Dim resultado As New List(Of Columna)
        Dim columnaAux As New Columna()
        Dim SqlQuery As String = $"SELECT COLUMN_NAME,ORDINAL_POSITION,DATA_TYPE,CHARACTER_MAXIMUM_LENGTH,COLUMN_DEFAULT,IS_NULLABLE FROM INFORMATION_SCHEMA.COLUMNS WHERE TABLE_NAME ='{nombreTabla}'"
        Dim isNullable As Boolean = False
        Dim isIdentity As Boolean
        Dim listaIdentity As New List(Of String)
        Try
            Conectar()
            Using comandoSql As New SqlCommand(SqlQuery, conexion)
                Using lectorResultado As SqlDataReader = comandoSql.ExecuteReader
                    Using adaptador As New SqlDataAdapter(comandoSql)
                        If lectorResultado.HasRows Then
                            Do While lectorResultado.Read()

                                Dim tdato As New Tipo()
                                isIdentity = False
                                Dim nombre As String = lectorResultado("COLUMN_NAME").ToString
                                If listaIdentity IsNot Nothing Then
                                    For Each nombreIdentidad In listaIdentity
                                        If nombre.Equals(nombreIdentidad) Then
                                            isIdentity = True
                                        End If
                                    Next
                                End If

                                Dim posicion As Integer = lectorResultado("ORDINAL_POSITION")
                                Dim tipoDato As String = lectorResultado("DATA_TYPE").ToString
                                tdato.TipoDato = lectorResultado("DATA_TYPE").ToString
                                Dim defecto As String
                                If lectorResultado("IS_NULLABLE").ToString = "YES" Then
                                    isNullable = True

                                End If

                                If Not IsDBNull(lectorResultado("CHARACTER_MAXIMUM_LENGTH")) Then

                                    tdato.NumeroCaracteres = CInt(lectorResultado("CHARACTER_MAXIMUM_LENGTH").ToString)
                                Else

                                    tdato.NumeroCaracteres = 0

                                End If

                                If Not IsDBNull(lectorResultado("COLUMN_DEFAULT")) Then
                                    defecto = lectorResultado("COLUMN_DEFAULT")
                                Else
                                    defecto = Nothing
                                End If

                                resultado.Add(New Columna With {
                            .Nombre = nombre,
                            .OrdenColumna = posicion,
                            .tipoDato = tdato,
                            .ValorDefecto = defecto,
                            .IsNullable = isNullable,
                            .IsIdentity = isIdentity})
                                posicion = Nothing
                                nombre = Nothing
                                tipoDato = Nothing
                                tdato = Nothing
                            Loop
                        End If

                    End Using
                End Using

            End Using
        Catch _Exception As Exception

            Console.WriteLine(_Exception.Message)
            Return Nothing
        End Try
        CheckIdentity(nombreTabla)

        Return resultado
    End Function

    Public Function CheckIdentity(nombreTabla As String)
        Dim listaColumnas As New List(Of String)
        Dim SqlQuery As String = $"SELECT name, is_identity FROM sys.columns WHERE object_id = OBJECT_ID('{nombreTabla}') AND is_identity= 1"
        Dim nombre As String
        Try

            Conectar()
            Using comandoSql As New SqlCommand(SqlQuery, conexion)
                Using lectorResultado As SqlDataReader = comandoSql.ExecuteReader
                    Using adaptador As New SqlDataAdapter(comandoSql)
                        If lectorResultado.HasRows Then
                            Do While lectorResultado.Read()
                                Try
                                    nombre = lectorResultado("name").ToString
                                    listaColumnas.Add(nombre)
                                Catch ex As Exception
                                End Try
                            Loop
                        End If
                        comandoSql.Dispose()
                    End Using
                End Using
            End Using
        Catch _Exception As Exception
            Console.WriteLine(_Exception.Message)
            CerrarConexion()
            Return Nothing
        End Try
        Return listaColumnas
    End Function

End Class