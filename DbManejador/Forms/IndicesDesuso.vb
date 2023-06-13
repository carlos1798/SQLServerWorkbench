Public Class IndicesDesuso
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
    objects.name AS Table_name,
    indexes.name AS Index_name,
    dm_db_index_usage_stats.user_seeks,
    dm_db_index_usage_stats.user_scans,
    dm_db_index_usage_stats.user_updates
FROM
    sys.dm_db_index_usage_stats
    INNER JOIN sys.objects ON dm_db_index_usage_stats.OBJECT_ID = objects.OBJECT_ID
    INNER JOIN sys.indexes ON indexes.index_id = dm_db_index_usage_stats.index_id AND dm_db_index_usage_stats.OBJECT_ID = indexes.OBJECT_ID
WHERE
    indexes.is_primary_key = 0 --This line excludes primary key constarint
    AND
    indexes. is_unique = 0 --This line excludes unique key constarint
    AND
    dm_db_index_usage_stats.user_updates <> 0 -- This line excludes indexes SQL Server hasn’t done any work with
    AND
    dm_db_index_usage_stats. user_lookups = 0
    AND
    dm_db_index_usage_stats.user_seeks = 0
    AND
    dm_db_index_usage_stats.user_scans = 0
ORDER BY
    dm_db_index_usage_stats.user_updates DESC"

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

            End If

        Next

        Me.Close()

    End Sub

End Class