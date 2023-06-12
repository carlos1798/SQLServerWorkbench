Public Class VistaIndices
    Dim tabla As New Tabla
    Public bs As New BindingSource()
    Private _SQL As String
    Dim indiceSql
    Dim sqlBuilder As New IndiceSQL

    Public Sub New(Tabla As Tabla)

        ' Esta llamada es exigida por el diseñador.
        InitializeComponent()

        Me.tabla = Tabla
        NTabla.Text = Tabla.NombreTabla
        get_Indices()

    End Sub

    Public Property SQL As String
        Get
            Return _SQL
        End Get
        Set(value As String)
            _SQL = value
        End Set
    End Property

    Public Sub get_Indices()

        Dim datatable As DataTable
        Dim bs As New BindingSource
        Dim tablasql As New TablaSQL
        Dim esUpdate As Boolean = False
        Dim refresh As Boolean = False

        Dim SqlQuery As String = $"SELECT a.name AS Index_Name, OBJECT_NAME(a.object_id), COL_NAME(b.object_id,b.column_id) AS Column_Name, b.index_column_id, b.key_ordinal, b.is_included_column, a.type_desc, a.is_unique,a.fill_factor  FROM sys.indexes AS a INNER JOIN sys.index_columns AS b ON a.object_id = b.object_id AND a.index_id = b.index_id WHERE a.object_id = OBJECT_ID('{tabla.NombreTabla}');"
        Using QueryDAO As New QueryDAO()
            datatable = QueryDAO.ExecuteSelectQuery(SqlQuery)
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
                SQL += sqlBuilder.EliminarIndiceSQL(row.Cells(1).Value, tabla.NombreTabla)

            End If

        Next

        Me.Close()

    End Sub

End Class