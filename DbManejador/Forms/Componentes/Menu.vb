Imports System.IO
Imports System.Net.NetworkInformation

Public Class Menu
    Dim reg As New Registro()

    Private Sub ToolStrip1_ItemClicked(sender As Object, e As ToolStripItemClickedEventArgs) Handles ToolStrip1.ItemClicked

        Select Case e.ClickedItem.ToString
            Case "Sincronizacion"

                ComparadorEsquemas.Show()
            Case "Atras"
                Main.Close()
            Case "IndexPer"
                Dim IndicesDesuso As New IndicesDesuso()
                IndicesDesuso.Show()
            Case "IndexSug"
                Dim IndicesSugeridos As New IndicesSugeridos()
                IndicesSugeridos.Show()
            Case "Fragmentacion"
                Dim FormFragmentacion As New VistaFragmentacion()
                FormFragmentacion.Show()
            Case "AddBaseDatos"
                Dim AddDBForm As New AddBd()

            Case "Ejecutar"
                Main.ejecutarSQLTextBox()
            Case "Guardar"
                SaveFileDialog1.Filter = "Sql files (*.sql)|*.sql|All files (*.*)|*.*"
                SaveFileDialog1.ShowDialog()
                If SaveFileDialog1.ShowDialog.OK Then
                    Try
                        Dim sw As New StreamWriter(SaveFileDialog1.FileName)
                        If sw IsNot Nothing Then
                            sw.Write(Main.InputText1.RichTextBox1.Text)
                        End If
                        sw.Close()
                        MessageBox.Show("Tu archivo se a guardado de forma correcta")
                    Catch ex As Exception

                    End Try
                End If

        End Select

    End Sub

    Public Sub Fill_BD_Combo(listaDatabases As List(Of Database))
        For Each db In listaDatabases
            DBSeleccion.Items.Add(db.Servidor.NombreServidor + " / " + db.Nombre)
        Next

    End Sub

    Private Sub DBSeleccion_SelectedIndexChanged(sender As Object, e As EventArgs) Handles DBSeleccion.SelectedIndexChanged

        Dim index As Integer = DBSeleccion.SelectedIndex

        Dim eleccion As String = DBSeleccion.Items(index)
        Dim nombreBd As String = eleccion.Substring(eleccion.LastIndexOf("/") + 1)
        Login.servidor.ModificarConexionString(nombreBd)
    End Sub

End Class