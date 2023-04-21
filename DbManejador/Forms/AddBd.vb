Imports DbManejador.Servidor

Public Class AddBd


    Dim nombreServidor As String = ""
    Private ReadOnly tipoautenticacion As TipoAutentificacion
    Dim nombreUsuario As String = ""
    Dim contrasena As String = ""

    'Se almacenaran todos los servidores que se van añadiendo en la sesion
    Private ReadOnly registo As New Registro
    ReadOnly listaservidores = registo.GetServidores()
    Dim listaDatabases As New List(Of Database)
    Public servidor As Servidor

    Private Sub Cancelar_Click(sender As Object, e As EventArgs) Handles Cancelar.Click
        Me.Close()
    End Sub

    'Hacer para que el sevidor devuelva todos los nombre de las db que hay en el servidor

    Private Function RecuperarDatosForm() As Servidor
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
    Private Sub Autenticacion_SelectedValueChanged(sender As Object, e As EventArgs) Handles Autenticacion.SelectedValueChanged
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


    Private Sub NomServidor_Click(sender As Object, e As EventArgs) Handles nomServidor.Click
        If Not nomServidor.Items.Count = 0 Then nomServidor.Items.Clear()

        Me.nomServidor.TabIndex = listaservidores.listaServidores.Count
        For Each servidor In listaservidores.listaServidores
            nomServidor.Items.Add(servidor.NombreServidor1)
        Next
    End Sub

    Private Sub NomServidor_SelectedValueChanged(sender As Object, e As EventArgs) Handles nomServidor.SelectedValueChanged
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

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        servidor = RecuperarDatosForm()
        servidor.ModificarConexionString("master")
        Try
            If servidor.CheckExistenciaServidor() Then 'Sabemos que esta en alcance el servidor
                Main.Show()
                MessageBox.Show("Conectado")
                registo.SaveServidor(servidor) 'Lo guardamos
            Else
                MsgBox("No se encuentra el nombre de ese servidor")
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

End Class