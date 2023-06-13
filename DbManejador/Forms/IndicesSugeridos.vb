Public Class IndicesSugeridos
    Dim tabla As New Tabla
    Public bs As New BindingSource()
    Dim indiceSql
    Private _sqlQuery As String
    Dim sqlBuilder As New IndiceSQL

    Public Sub New()

        ' Esta llamada es exigida por el diseñador.
        InitializeComponent()

        Me.tabla = tabla
        get_Indices()
        Me._sqlQuery = ""
    End Sub

    Public Property SqlQuery As String
        Get
            Return _sqlQuery
        End Get
        Set(value As String)
            _sqlQuery = value
        End Set
    End Property

    Public Sub get_Indices()

        Dim datatable As DataTable
        Dim bs As New BindingSource
        Dim tablasql As New TablaSQL
        Dim esUpdate As Boolean = False
        Dim refresh As Boolean = False

        Dim query As String = $"SELECT
    DB_NAME(dm_mid.database_id) AS DatabaseName,
    OBJECT_NAME(dm_mid.OBJECT_ID,dm_mid.database_id) AS TableName,
    dm_mid.equality_columns,
	dm_mid.inequality_columns,
    dm_migs.avg_user_impact*(dm_migs.user_seeks+dm_migs.user_scans) Avg_Estimated_Impact,
    dm_migs.last_user_seek AS Last_User_Seek,
    'CREATE INDEX [IX_' + OBJECT_NAME(dm_mid.OBJECT_ID,dm_mid.database_id) + '_'
        + REPLACE(REPLACE(REPLACE(ISNULL(dm_mid.equality_columns,''),', ','_'),'[',''),']','')
        + CASE
            WHEN dm_mid.equality_columns IS NOT NULL AND dm_mid.inequality_columns IS NOT NULL THEN '_'
            ELSE ''
        END
        + REPLACE(REPLACE(REPLACE(ISNULL(dm_mid.inequality_columns,''),', ','_'),'[',''),']','')
        + ']'
        + ' ON ' + dm_mid.statement
        + ' (' + ISNULL (dm_mid.equality_columns,'')
        + CASE WHEN dm_mid.equality_columns IS NOT NULL AND dm_mid.inequality_columns
        IS NOT NULL THEN ',' ELSE
        '' END
        + ISNULL (dm_mid.inequality_columns, '')
        + ')'
        + ISNULL (' INCLUDE (' + dm_mid.included_columns + ')', '') AS Create_Statement
FROM sys.dm_db_missing_index_groups dm_mig
INNER JOIN sys.dm_db_missing_index_group_stats dm_migs
    ON dm_migs.group_handle = dm_mig.index_group_handle
INNER JOIN sys.dm_db_missing_index_details dm_mid
    ON dm_mig.index_handle = dm_mid.index_handle
WHERE dm_mid.database_ID = DB_ID()
ORDER BY Avg_Estimated_Impact DESC;"

        Using QueryDAO As New QueryDAO()
            datatable = QueryDAO.ExecuteSelectQuery(query)
        End Using
        ' InputText1.RichTextBox1.Text = query

        Indices_Grid.DataSource = datatable

    End Sub

    Private Sub TextBox1_TextChanged(sender As Object, e As EventArgs) Handles TextBox1.TextChanged
        bs.DataSource = Indices_Grid.DataSource
        bs.Filter = $"[Object Name] Like '{TextBox1.Text}%'"

    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        For Each row As DataGridViewRow In Indices_Grid.Rows
            If row.Cells(0).Value = True Then
                SqlQuery += row.Cells(7).Value

            End If

        Next

        Me.Close()

    End Sub

End Class