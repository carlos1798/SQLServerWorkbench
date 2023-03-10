Public Class BDSelector
    Public Event Eleccion(nombredb As String, nombreServidor As String)
    Public Event EleccionBD(db As Database)
    Dim Database As New Database
    Dim nombredb As String
    Dim nombreServidor As String
    Public Sub New(nombreDB As String, nombreServidor As String, bd As Database)

        ' Esta llamada es exigida por el diseñador.
        InitializeComponent()
        Me.Database = bd

        Label4.Text = nombreDB
        Me.nombredb = nombreDB

        Label5.Text = nombreServidor
        Me.nombreServidor = nombreServidor
        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().

    End Sub


    Private Sub eventoClick() Handles Label1.Click, Label2.Click, Label3.Click, Label4.Click, Button1.Click, Label5.Click, Panel2.Click
        RaiseEvent Eleccion(nombredb, nombreServidor)
        RaiseEvent EleccionBD(Database)

    End Sub
End Class
