Public Class VistaIndices
    Dim tabla As New Tabla

    Public Sub New(Tabla As Tabla)

        ' Esta llamada es exigida por el diseñador.
        InitializeComponent()
        Me.tabla = Tabla
        Debug.Print(Tabla.NombreTabla)

        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().

    End Sub

End Class