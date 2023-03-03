Public Class BDSelector
    Dim Database As New Database
    Public Sub New(nombreDB As String)

        ' Esta llamada es exigida por el diseñador.
        InitializeComponent()

        Label1.Text = nombreDB
        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().

    End Sub

    Private Sub Label1_Click(sender As Object, e As EventArgs) Handles Label1.Click

    End Sub
End Class
