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

    Private Sub eventoClick(Clicksender As Object, e As MouseEventArgs) Handles Label1.MouseDown, Label2.MouseDown, Label3.MouseDown, Label4.MouseDown, Button1.MouseDown, Label5.MouseDown, Panel2.MouseDown


        If e.Button = MouseButtons.Left Then
            RaiseEvent Eleccion(nombredb, nombreServidor)
            RaiseEvent EleccionBD(Database)
            'Hacer que cambie de color si has seleccionado una


        Else

            ContextMenuStrip1.Show(CType(Clicksender, Control), e.Location)

        End If

    End Sub

End Class
