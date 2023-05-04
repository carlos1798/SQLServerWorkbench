﻿Imports System.Data.SqlClient

Public Class QueryDAO
    Inherits ConexionBD

    Public Function ExecuteQuery(SQlQuery As String) As DataTable
        Dim tablaDatos As New DataTable
        Try
            Conectar()
            Using comandoSql As New SqlCommand(SQlQuery, conexion)
                Using adaptador As New SqlDataAdapter()
                    adaptador.SelectCommand = comandoSql
                    adaptador.Fill(tablaDatos)
                    Return tablaDatos
                End Using
            End Using


        Catch ex As Exception
            MessageBox.Show(ex.Message)
            Return Nothing
        End Try
    End Function
    Public Async Function ExecuteQueryAsync(SQlQuery As String) As Task(Of DataTable)
        Dim tablaDatos As New DataTable
        Try
            Await ConectarAsync()

            Using comandoSql As New SqlCommand(SQlQuery, conexion)
                Using reader = Await comandoSql.ExecuteReaderAsync
                    Using adaptador As New SqlDataAdapter()
                        adaptador.SelectCommand = comandoSql
                        adaptador.Fill(tablaDatos)
                        Return tablaDatos
                    End Using
                End Using
            End Using


        Catch ex As Exception
            MessageBox.Show(ex.Message)
            Return Nothing
        End Try
    End Function
End Class
