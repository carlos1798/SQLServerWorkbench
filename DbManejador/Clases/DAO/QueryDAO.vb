Imports System.Data.SqlClient

Public Class QueryDAO
    Inherits ConexionBD

    Dim sqlTablabuilder As New TablaSQL
    'Devuelvo la query que me de devuelve el valor modificado
    Public Function ExecuteUpdateQuery(SQlQuery As String) As Integer
        Dim filas_afectadas As Integer = 0
        Try
            Conectar()
            Using comandoSql As New SqlCommand(SQlQuery, conexion)
                filas_afectadas = comandoSql.ExecuteNonQuery()
            End Using

            Return filas_afectadas
            ' sqlTablabuilder.SelectWhere()
        Catch ex As Exception
            MessageBox.Show(ex.Message)
            Return Nothing
        End Try

    End Function
    Public Function ExecuteSelectQuery(SQlQuery As String) As DataTable
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

End Class
