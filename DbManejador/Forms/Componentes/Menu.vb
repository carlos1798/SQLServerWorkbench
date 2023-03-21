Imports System.IO

 Public Class Menu
    Dim reg As New Registro()
    Private Sub ToolStrip1_ItemClicked(sender As Object, e As ToolStripItemClickedEventArgs) Handles ToolStrip1.ItemClicked

        Select Case e.ClickedItem.ToString
            Case "Sincronizacion"

                ComparadorEsquemas.Show()
            Case "Atras"
                Main.Close()

            Case "IndexPer"

            Case "IndexSug"

            Case "AddBd"

            Case "Guardar"
                SaveFileDialog1.Filter = "Sql files (*.sql)|*.sql|All files (*.*)|*.*"
                SaveFileDialog1.ShowDialog()
                If SaveFileDialog1.ShowDialog.OK Then

                    Dim sw As New StreamWriter(SaveFileDialog1.FileName)
                    If sw IsNot Nothing Then
                        sw.Write(reg.generarString(Main.lista))
                    End If

                    sw.Close()
                    MessageBox.Show("Tu archivo se a guardado de forma correcta")
                End If



        End Select



    End Sub

End Class
