

Imports DbManejador.Servidor

Public Class Login

    Dim nombreServidor As String = ""
    Private ReadOnly tipoautenticacion As TipoAutentificacion
    Dim nombreUsuario As String = ""
    Dim contrasena As String = ""

    'Se almacenaran todos los servidores que se van añadiendo en la sesion
    Private ReadOnly registro As New Registro
    Dim servidores As Servidores = registro.GetServidores()
    Dim listaDatabases As New List(Of Database)
    Public servidor As Servidor


    Private Sub Aceptar_Click(sender As Object, e As EventArgs) Handles Aceptar.Click
        Try
            servidor = RecuperarDatosForm()
            servidor.ModificarConexionString("master")

            If servidor.CheckExistenciaServidor() Then 'Sabemos que esta en alcance el servidor
                Main.Show()
                MessageBox.Show("Conectado")
                If Not servidores.ExisteEnArchivo(servidor) Then
                    registro.SaveServidor(servidor)
                    servidores.ListaServidores.Add(servidor)
                End If
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

    Private Function RecuperarDatosForm() As Servidor
        nombreServidor = nomServidor.Text
        Select Case Autenticacion.SelectedIndex
            Case 0
                Dim servidor As New Servidor(nombreServidor)
                usrComboBox.Text = servidor.Usuario
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
        If nomServidor.Items.Count = 0 Then
            nomServidor.Items.Clear()

            Me.nomServidor.TabIndex = servidores.ListaServidores.Count
            For Each servidor In servidores.ListaServidores
                If Not servidor.NombreServidor = "" Then

                    nomServidor.Items.Add(servidor.NombreServidor)

                End If

            Next

        End If

    End Sub

    Private Sub NomServidor_SelectedValueChanged(sender As Object, e As EventArgs) Handles nomServidor.SelectedValueChanged
        If servidores IsNot Nothing Then
            Dim servidorSeleccionado As New Servidor()
            For Each servidor As Servidor In servidores.ListaServidores
                If nomServidor.SelectedItem IsNot Nothing Then


                    If nomServidor.SelectedItem.Equals(servidor.NombreServidor) Then
                        If servidor.TipoLogin.Equals(TipoAutentificacion.WINDOWS) Then
                            Autenticacion.SelectedIndex = 0
                            Me.usrComboBox.Text = ""
                            Me.passwdTextBox.Text = ""
                            Me.usrComboBox.Enabled = False
                            Me.passwdTextBox.Enabled = False

                            Exit For
                        Else
                            Autenticacion.SelectedIndex = 1
                            Me.usrComboBox.Text = servidor.Usuario
                            Me.passwdTextBox.Text = servidor.Contrasena

                            Exit For
                        End If


                    End If

                End If

            Next
        End If
    End Sub
End Class
