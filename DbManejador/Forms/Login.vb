

Imports DbManejador.Servidor

Public Class Login

    Dim nombreServidor As String = ""
    Dim tipoautenticacion As TipoAutentificacion
    Dim nombreUsuario As String = ""
    Dim contrasena As String = ""

    'Se almacenaran todos los servidores que se van añadiendo en la sesion
    Dim registo As New Registro
    Dim listaservidores = registo.getServidores()
    Dim listaDatabases As New List(Of Database)

    Private Sub Aceptar_Click(sender As Object, e As EventArgs) Handles Aceptar.Click
        Dim servidor As Servidor = recuperarDatosForm()
        Dim conexionString As String




        Try
            If servidor.checkExistenciaServidor() Then 'Sabemos que esta en alcance el servidor
                Using DatabaseDAO As New DatabaseDAO()
                    listaDatabases = DatabaseDAO.FindAll()
                End Using
                For Each Database In listaDatabases
                    servidor.modificarConexionString(Database.Nombre)

                    Using TablaDAO As New TablaDAO()
                        Database.Tablas = TablaDAO.LightFindAll()
                    End Using

                Next
                For Each Database In listaDatabases
                    servidor.modificarConexionString(Database.Nombre)
                    For Each tabla In Database.Tablas

                        Using ColumnaDAO As New ColumnaDAO()
                            tabla.Columnas = ColumnaDAO.GetColumnas(tabla.NombreTabla)
                        End Using

                    Next
                Next




                MessageBox.Show("Conectado")
                registo.saveServidor(servidor) 'Lo guardamos



            Else
                MsgBox("No se encuentra el nombre de ese servidor")

            End If


        Catch ex As Exception
            MessageBox.Show(ex.Message)

        End Try
        'Comprobamos que hay conexion
        'Si la hay solo queda hacer de esa nueva Conexion la conexion general de la aplicacion 

    End Sub

    Private Sub Cancelar_Click(sender As Object, e As EventArgs) Handles Cancelar.Click
        Me.Close()

    End Sub

    Private Function recuperarDatosForm() As Servidor
        nombreServidor = nomServidor.Text
        Select Case Autenticacion.SelectedIndex
            Case 0
                Dim servidor As New Servidor(nombreServidor)
                usrComboBox.Text = servidor.Usuario1
                Return servidor
            Case 1
                nombreUsuario = usrComboBox.Text
                contrasena = passwdTextBox.Text

                Dim servidor As New Servidor(nombreServidor, nombreUsuario, contrasena)
                Return servidor

            Case Else
                MessageBox.Show("Debes seleccionar un tipo de autentificacion para poder conectarte al servidor")
                Return Nothing

        End Select
    End Function

    'Eliminamos la posibilidad de que se indtroduzca el nombre de usuario y contrasena si el metodo de Login es con la autentificacion de windows
    Private Sub autenticacion_SelectedValueChanged(sender As Object, e As EventArgs) Handles Autenticacion.SelectedValueChanged
        If Autenticacion.SelectedItem = "autenticacion de Windows" Then

            Me.usrComboBox.Text = ""
            Me.passwdTextBox.Text = ""
            Me.usrComboBox.Enabled = False
            Me.passwdTextBox.Enabled = False
        Else
            Me.usrComboBox.Enabled = True
            Me.passwdTextBox.Enabled = True
        End If
    End Sub


    Private Sub nomServidor_Click(sender As Object, e As EventArgs) Handles nomServidor.Click
        If Not nomServidor.Items.Count = 0 Then nomServidor.Items.Clear()

        Me.nomServidor.TabIndex = listaservidores.listaServidores.Count
        For Each servidor In listaservidores.listaServidores
            nomServidor.Items.Add(servidor.NombreServidor1)
        Next
    End Sub

    Private Sub nomServidor_SelectedValueChanged(sender As Object, e As EventArgs) Handles nomServidor.SelectedValueChanged
        Dim servidorSeleccionado As New Servidor()
        For Each servidor As Servidor In listaservidores.listaServidores
            If nomServidor.SelectedItem.Equals(servidor.NombreServidor1) Then
                If servidor.TipoLogin1.Equals(TipoAutentificacion.WINDOWS) Then
                    Autenticacion.SelectedIndex = 0
                    Me.usrComboBox.Text = ""
                    Me.passwdTextBox.Text = ""
                    Me.usrComboBox.Enabled = False
                    Me.passwdTextBox.Enabled = False

                    Exit For
                Else
                    Autenticacion.SelectedIndex = 1
                    Me.usrComboBox.Text = servidor.Usuario1
                    Me.passwdTextBox.Text = servidor.Contrasena1

                    Exit For
                End If

            End If

        Next
    End Sub
End Class
