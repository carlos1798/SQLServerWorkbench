Public Class Tabla
    Public nombreTabla As String

    Public Sub New(nombreTabla As String)
        Me.nombreTabla = nombreTabla
    End Sub

    Public totFilas As Long
    Public columnas As List(Of Columna) = New List(Of Columna)
    Public indices As List(Of Indice) = New List(Of Indice)
    Public restricciones As List(Of Restriccion) = New List(Of Restriccion)
    Public sentenciaSQL As String

    Public Sub New()
    End Sub

    Public Sub New(nombreTabla As String, totFilas As Long, columnas As List(Of Columna), indexes As List(Of Indice), restricciones As List(Of Restriccion))
        Me.nombreTabla = nombreTabla
        Me.totFilas = totFilas
        Me.columnas = columnas
        Me.indices = indices
        Me.restricciones = restricciones
    End Sub

End Class
