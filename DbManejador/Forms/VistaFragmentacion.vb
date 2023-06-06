Public Class VistaFragmentacion

    Public bs As New BindingSource()
    Private _SQL As String = ""

    Public Property SQL As String
        Get
            Return _SQL
        End Get
        Set(value As String)
            _SQL = value
        End Set
    End Property

    Public Sub New()

        InitializeComponent()
        Me.SQL = ""
    End Sub

    Private Sub Fragmentacion_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        get_fragmentacion()
    End Sub

    Public Sub get_fragmentacion()

        Dim datatable As DataTable
        Dim bs As New BindingSource
        Dim tablasql As New TablaSQL
        Dim esUpdate As Boolean = False
        Dim refresh As Boolean = False
        Dim query As String = "SELECT DB_NAME(ps.database_id) AS [Database Name], OBJECT_NAME(ps.object_id) As [Object Name], i.name As [Index Name], ps.index_id, ps.index_type_desc, ps.avg_fragmentation_in_percent, ps.fragment_count, ps.page_count,
                         i.fill_factor, i.has_filter, i.filter_definition
From sys.dm_db_index_physical_stats(DB_ID(), NULL, NULL, NULL, N'LIMITED') AS ps INNER JOIN
        sys.indexes AS i WITH (NOLOCK) ON ps.object_id = i.object_id And ps.index_id = i.index_id
ORDER BY ps.avg_fragmentation_in_percent desc"

        Using QueryDAO As New QueryDAO()
            datatable = QueryDAO.ExecuteSelectQuery(query)
        End Using
        ' InputText1.RichTextBox1.Text = query

        Fragmentacion_Grid.DataSource = datatable

    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        'Si la framentacion es superior al 30%  entonces rebuild , si esta entre el 10 y el 30 entonces reorganize
        'La fragmentacion solo tiene sentido en aquellos indices que tienen un numero de paginas de mas de 1000
        For Each row As DataGridViewRow In Fragmentacion_Grid.Rows
            If row.Cells(0).Value = True Then
                If row.Cells(5).Value.ToString = "HEAP" Then
                    Dim sqlFrag = $"ALTER INDEX {row.Cells(2).Value.ToString} ON {row.Cells(1).Value.ToString} REBUILD"
                Else
                    If row.Cells(6).Value > 30 Then
                        Select Case row.Cells(7).Value
                            Case 0
                                Dim query = $"ALTER INDEX {row.Cells(2).Value.ToString} ON {row.Cells(1).Value.ToString} REBUILD"
                                SQL += vbNewLine + query + vbNewLine
                            Case Else
                                Dim query = $"ALTER INDEX {row.Cells(2).Value.ToString} ON {row.Cells(1).Value.ToString} REBUILD WITH (FILL_FACTOR = {row.Cells(9).Value})"
                                SQL += vbNewLine + query
                        End Select
                    ElseIf row.Cells(4).Value < 30 Then
                        Select Case row.Cells(7).Value
                            Case 0
                                Dim query = $"ALTER INDEX {row.Cells(2).Value.ToString} ON {row.Cells(1).Value.ToString} REORGANIZE"
                                SQL += vbNewLine + query
                            Case Else
                                Dim query = $"ALTER INDEX {row.Cells(2).Value.ToString} ON {row.Cells(1).Value.ToString} REORGANIZE WITH (FILL_FACTOR = {row.Cells(9).Value})"
                                SQL += vbNewLine + query
                        End Select

                    End If

                End If
            End If

        Next

        Me.Close()
    End Sub

    Public Function desfragmentarHeapIdex(nombreTabla As String)
        Dim defragSql As String = $"ALTER TABLE {nombreTabla} REBUILD"
        Return defragSql
    End Function

    Private Sub TextBox1_TextChanged(sender As Object, e As EventArgs) Handles TextBox1.TextChanged
        bs.DataSource = Fragmentacion_Grid.DataSource
        bs.Filter = $"[Object Name] LIKE '{TextBox1.Text}%'"

    End Sub

    'Private Sub ComboBox1_SelectedIndexChanged(sender As Object, e As EventArgs)
    '    bs.DataSource = DataGridView1.DataSource
    '    bs.Filter = $"[index_type_desc] LIKE '{ComboBox1.SelectedItem}%'"
    'End Sub


    Private Sub DataGridView1_CellMouseEnter(sender As Object, e As DataGridViewCellEventArgs) Handles Fragmentacion_Grid.CellMouseEnter
        If e.RowIndex >= 0 Then
            Dim hoveredColumn As String
            Try

                hoveredColumn = Fragmentacion_Grid(e.ColumnIndex, e.RowIndex).ColumnIndex.ToString
            Catch ex As Exception

                hoveredColumn = Nothing

            End Try

            Select Case hoveredColumn

                Case 6
                    Label4.Text = "Conviene reconstruir un Indice cuando su porcentaje de fragmentacion
sea superior a un 10% y su numero de paginas sea alto"

                Case 8
                    Label4.Text = "Si el total de paginas es menor de 1000 no es necesesario realizar una reconstruccion,
ya que SQL Server considera que es más eficiente escribir los datos de forma desordenada
que reconstruir un índice poco efectivo"
                Case Else
                    Label4.Text = ""

            End Select
        End If

    End Sub

End Class