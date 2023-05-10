Public Class Fragmentacion
    Public listaCambios As New List(Of String)

    Public bs As New BindingSource()

    Private Sub Fragmentacion_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        'TODO: esta línea de código carga datos en la tabla 'GESTIONSQLDataSet.Fragmentacion' Puede moverla o quitarla según sea necesario.

    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        'Si la framentacion es superior al 30%  entonces rebuild , si esta entre el 10 y el 30 entonces reorganize
        'La fragmentacion solo tiene sentido en aquellos indices que tienen un numero de paginas de mas de 1000
        For Each row As DataGridViewRow In DataGridView1.Rows
            If row.Cells(0).Value = True Then
                If row.Cells(3).Value.ToString = "HEAP" Then
                    Dim sqlFrag = desfragmentarHeapIdex(row.Cells(1).Value.ToString)
                    listaCambios.Add(sqlFrag)
                Else
                    If row.Cells(4).Value > 30 Then
                        Select Case row.Cells(7).Value
                            Case 0

                                Dim query = $"ALTER INDEX {row.Cells(2).Value.ToString} ON {row.Cells(1).Value.ToString} REBUILD"
                                listaCambios.Add(query)
                                Main.InputText1.RichTextBox1.Text.Append(query)
                            Case Else

                                Dim query = $"ALTER INDEX {row.Cells(2).Value.ToString} ON {row.Cells(1).Value.ToString} REBUILD WITH (FILL_FACTOR = {row.Cells(7).Value})"
                                listaCambios.Add(query)

                                Main.InputText1.RichTextBox1.Text.Append(query)
                        End Select
                    ElseIf row.Cells(4).Value < 30 Then
                        Select Case row.Cells(7).Value
                            Case 0
                                Dim query = $"ALTER INDEX {row.Cells(2).Value.ToString} ON {row.Cells(1).Value.ToString} REORGANIZE"
                                listaCambios.Add(query)
                                Main.InputText1.RichTextBox1.Text.Append(query)
                            Case Else
                                Dim query = $"ALTER INDEX {row.Cells(2).Value.ToString} ON {row.Cells(1).Value.ToString} REORGANIZE WITH (FILL_FACTOR = {row.Cells(7).Value})"
                                listaCambios.Add(query)
                                Main.InputText1.RichTextBox1.Text.Append(query)
                        End Select

                    End If

                End If
            End If

        Next

        Fragmentacion.ActiveForm.Close()
        MessageBox.Show("Los cambios se han guardado")
        listaCambios.Clear()
    End Sub

    Public Function desfragmentarHeapIdex(nombreTabla As String)
        Dim defragSql As String = $"ALTER TABLE {nombreTabla} REBUILD"
        Return defragSql
    End Function

    Private Sub TextBox1_TextChanged(sender As Object, e As EventArgs) Handles TextBox1.TextChanged
        bs.DataSource = DataGridView1.DataSource
        bs.Filter = $"[Object Name] LIKE '{TextBox1.Text}%'"

    End Sub

    'Private Sub ComboBox1_SelectedIndexChanged(sender As Object, e As EventArgs)
    '    bs.DataSource = DataGridView1.DataSource
    '    bs.Filter = $"[index_type_desc] LIKE '{ComboBox1.SelectedItem}%'"
    'End Sub

    Private Sub DataGridView1_MouseHover(sender As Object, e As EventArgs) Handles DataGridView1.MouseHover
    End Sub

    Private Sub DataGridView1_CellMouseEnter(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridView1.CellMouseEnter
        If e.RowIndex >= 0 Then
            Dim hoveredColumn As String
            Try

                hoveredColumn = DataGridView1(e.ColumnIndex, e.RowIndex).ColumnIndex.ToString
            Catch ex As Exception

                hoveredColumn = Nothing

            End Try

            Select Case hoveredColumn

                Case 4
                    Label4.Text = "Conviene reconstruir un Indice cuando su porcentaje de fragmentacion
sea superior a un 10% y su numero de paginas sea alto"

                Case 6
                    Label4.Text = "Si el total de paginas es menor de 1000 no es necesesario realizar una reconstruccion,
ya que SQL Server considera que es más eficiente escribir los datos de forma desordenada
que reconstruir un índice poco efectivo"
                Case Else
                    Label4.Text = ""

            End Select
        End If

    End Sub

End Class