Imports System.IO
Imports System.Net.NetworkInformation

Public Class Menu
    Dim reg As New Registro()

    Public Event new_server_add(servidor As Servidores)

    Public Event added_sql(SQL As String)

    Private _servidores As New Servidores
    Private _sqlQuery As String = ""

    Public Property Servidores As Servidores
        Get
            Return _servidores
        End Get
        Set(value As Servidores)
            _servidores = value

            Fill_BD_Combo()
        End Set
    End Property

    Public Property SqlQuery As String
        Get
            Return _sqlQuery
        End Get
        Set(value As String)
            _sqlQuery = value
        End Set
    End Property

    Private Sub ToolStrip1_ItemClicked(sender As Object, e As ToolStripItemClickedEventArgs) Handles ToolStrip1.ItemClicked

        Select Case e.ClickedItem.ToString
            Case "Sincronizacion"

                ComparadorEsquemas.Show()
            Case "Atras"
                Main.Close()

            Case "Fragmentacion"
                Using FormFragmentacion As New VistaFragmentacion()
                    FormFragmentacion.ShowDialog()
                    SqlQuery = FormFragmentacion.SQL
                    RaiseEvent added_sql(SqlQuery)

                End Using
            Case "Añadir"
                Using AddDBForm As New AddBd()
                    AddDBForm.ShowDialog()
                    Servidores.ListaServidores.Add(AddDBForm.Servidor)
                    Fill_BD_Combo()
                    RaiseEvent new_server_add(Servidores)
                End Using

            Case "Ejecutar"
                Main.EjecutarSQLTextBox()
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

    Public Sub Fill_BD_Combo()

        For Each servidor In _servidores.ListaServidores
            If servidor Is Nothing Then
                Exit Sub
            End If
            For Each db In servidor.ListaDatabases
                DBSeleccion.Items.Add(db.Servidor.NombreServidor + " / " + db.Nombre)
            Next
        Next

    End Sub

    Private Sub DBSeleccion_SelectedIndexChanged(sender As Object, e As EventArgs) Handles DBSeleccion.SelectedIndexChanged

        Dim index As Integer = DBSeleccion.SelectedIndex

        Dim eleccion As String = DBSeleccion.Items(index)
        Dim nombreBd As String = eleccion.Substring(eleccion.LastIndexOf("/") + 1)

        'Servidor.ModificarConexionString(nombreBd)
    End Sub

    Private Sub Indices_Click(sender As Object, e As EventArgs) Handles Indices.Click
        Try
            Dim coordenadas = get_Coordenadas_Tabla(Servidores, Main.TreeView1.SelectedNode.Text, True)
            Dim Tabla = get_Tabla_Coordenadas(Servidores, coordenadas)

            Using vistaIndices As New VistaIndices(Tabla)
                vistaIndices.ShowDialog()
                SqlQuery = vistaIndices.SQL
                RaiseEvent added_sql(SqlQuery)
            End Using
        Catch ex As Exception
            MsgBox("Para acceder a esta pantalla selecciona una tabla de la base de datos")

        End Try
    End Sub

    Private Sub IndexSug_Click(sender As Object, e As EventArgs) Handles IndexSug.Click
        Using IndicesSugeridos As New IndicesSugeridos()
            IndicesSugeridos.ShowDialog()
            SqlQuery = IndicesSugeridos.SqlQuery
            RaiseEvent added_sql(SqlQuery)
        End Using

    End Sub

    Private Sub IndexPer_Click(sender As Object, e As EventArgs) Handles IndexPer.Click
        Using IndicesDesuso As New IndicesDesuso()
            IndicesDesuso.ShowDialog()
            SqlQuery = IndicesDesuso.SqlQuery
            RaiseEvent added_sql(SqlQuery)
        End Using

    End Sub

End Class