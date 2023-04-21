Imports System.Windows.Forms.VisualStyles

Public Class BDSelector
    Public Event Eleccion(nombredb As String, nombreServidor As String)
    Public Event EleccionBD(db As Database)
    Dim Database As New Database
    Dim nombredb As String
    Dim nombreServidor As String

    Public Sub New(nombreDB As String, nombreServidor As String, bd As Database)

        InitializeComponent()
        Me.Database = bd
        Label4.Text = nombreDB
        Me.nombredb = nombreDB
        Label5.Text = nombreServidor
        Me.nombreServidor = nombreServidor

    End Sub

    Private Sub eventoClick(Clicksender As Object, e As TreeNodeMouseClickEventArgs) Handles TreeView.AfterSelect

        If e.Button = MouseButtons.Left Then
            RaiseEvent Eleccion(nombredb, nombreServidor)
            RaiseEvent EleccionBD(Database)
            'Hacer que cambie de color si has seleccionado una


        Else

            ContextMenuStrip1.Show(CType(Clicksender, Control), e.Location)

        End If

    End Sub

End Class
