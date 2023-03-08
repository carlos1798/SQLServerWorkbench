Public Class Columna
    Public tipoDato As Tipo

    Private _restriciones As New List(Of Restriccion)
    Private _ordenColumna As Integer
    Private _valorDefecto As String
    Private _isNullable As Boolean
    Private _isPrimaryKey As Boolean
    Private _isIdentity As Boolean
    Private _nombre As String
#Region "Constructores"
    Public Sub New()
    End Sub

    Public Sub New(nombre As String)
        Me.Nombre = nombre
    End Sub

    Public Sub New(nombre As String, ordenColumna As Integer)
        Me.Nombre = nombre
        Me.OrdenColumna = ordenColumna
    End Sub

    Public Sub New(tipoDato As Tipo, ordenColumna As Integer, nomb As String)
        Me.tipoDato = tipoDato
        Me.OrdenColumna = ordenColumna
        Me.Nombre = nomb
    End Sub
#End Region

#Region "Setters y getters"
    Public Property Restriciones As List(Of Restriccion)
        Get
            Return _restriciones
        End Get
        Set(value As List(Of Restriccion))
            _restriciones = value
        End Set
    End Property

    Public Property OrdenColumna As Integer
        Get
            Return _ordenColumna
        End Get
        Set(value As Integer)
            _ordenColumna = value
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

    Public Property IsNullable As Boolean
        Get
            Return _isNullable
        End Get
        Set(value As Boolean)
            _isNullable = value
        End Set
    End Property

    Public Property IsPrimaryKey As Boolean
        Get
            Return _isPrimaryKey
        End Get
        Set(value As Boolean)
            _isPrimaryKey = value
        End Set
    End Property

    Public Property IsIdentity As Boolean
        Get
            Return _isIdentity
        End Get
        Set(value As Boolean)
            _isIdentity = value
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


    Public Function CompariacionColumnas(columna_y As Columna)
        Dim Dif As New Dictionary(Of String, String)
        For Each propiedad In [GetType].GetProperties
            If propiedad.Equals("Restricciones") Then

            Else
                Dim valor1 = propiedad.GetValue(Me)
                Dim valor2 = propiedad.GetValue(columna_y)
                If Not valor1.Equals(valor2) Then
                    Dif.Add(key:=propiedad.Name, value:=valor2.ToString)
                End If

            End If
        Next
        Return Dif
    End Function



End Class
