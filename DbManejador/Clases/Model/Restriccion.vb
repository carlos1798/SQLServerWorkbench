Public Class Restriccion
    Private _nombre As String
    Private _tipoRestriccion As Tipo
    Private _valorDefecto As String
    Enum Tipo
        NOTNULL
        UNIQUE
        PRIMARYKEY
        FOREINGKEY
        CHECK
        DEFECTO
    End Enum

    Public Sub New(nombre As String, tipoRestriccion As Tipo, valorDefecto As String)
        Me.nombre = nombre
        Me.TipoRestriccion = tipoRestriccion
        If tipoRestriccion.Equals(Tipo.DEFECTO) Then
            Me.ValorDefecto = valorDefecto
        End If

    End Sub
#Region "Getters y setters"

    Public Property TipoRestriccion As Tipo
        Get
            Return _tipoRestriccion
        End Get
        Set(value As Tipo)
            _tipoRestriccion = value
        End Set
    End Property

    Public Property ValorDefecto As String
        Get
            Return _valorDefecto
        End Get
        Set(value As String)
            _valorDefecto = value
        End Set
    End Property

    Public Property Nombre As String
        Get
            Return _nombre
        End Get
        Set(value As String)
            _nombre = value
        End Set
    End Property
#End Region





End Class
