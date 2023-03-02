Public Class Columna
    Public tipoDato As Tipo

    Public Restriciones As New List(Of Restriccion)
    Public ordenColumna As Integer
    Public valorDefecto As String
    Public isNullable As Boolean
    Public isPrimaryKey As Boolean
    Public isIdentity As Boolean

    Public Nombre As String

    Public Sub New()
    End Sub

    Public Sub New(nombre As String)
        Me.Nombre = nombre
    End Sub

    Public Sub New(nombre As String, ordenColumna As Integer)
        Me.Nombre = nombre
        Me.ordenColumna = ordenColumna
    End Sub

    Public Sub New(tipoDato As Tipo, ordenColumna As Integer, nomb As String)
        Me.tipoDato = tipoDato
        Me.ordenColumna = ordenColumna
        Me.Nombre = nomb
    End Sub


End Class
