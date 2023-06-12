Public Class Indice
    Inherits IndiceSQL

    Private _nombreTabla As String
    Private _nombre As String
    Private _columnas As New List(Of Columna)
    Private _unico As Boolean
    Private _tipoIndice As String
    Private _autoCreado As Boolean
    Private _fragmentacion As Long
    Private _fillFactor As Integer

#Region "Constructores"

    Public Sub New(columnas As List(Of Columna))
        _columnas = columnas
    End Sub

    Public Sub New(nombre As String, columnas As List(Of Columna), unico As Boolean, tipoIndice As String, autoCreado As Boolean)
        Me.Nombre = nombre
        Me.Columnas = columnas
        Me.Unico = unico
        Me.TipoIndice = tipoIndice
        Me.AutoCreado = autoCreado
    End Sub

    Public Sub New()
    End Sub

    Public Sub New(nombre As String, columnas As List(Of Columna))
        Me.Nombre = nombre
        Me.Columnas = columnas
    End Sub

    Public Sub New(nombre As String, unico As Boolean, tipoIndice As String, autoCreado As Boolean, fragmentacion As Long, columnas As List(Of Columna))
        Me.Nombre = nombre
        Me.Unico = unico
        Me.TipoIndice = tipoIndice
        Me.AutoCreado = autoCreado
        Me.Fragmentacion = fragmentacion
        Me.Columnas = columnas
    End Sub

    Public Sub New(nombre As String, columnas As List(Of Columna), unico As Boolean, tipoIndice As String, autoCreado As Boolean, fragmentacion As Long)
        Me.New(nombre, columnas, unico, tipoIndice, autoCreado)
        _fragmentacion = fragmentacion
    End Sub

#End Region

#Region "Getters y setters"

    Public Property Nombre As String
        Get
            Return _nombre
        End Get
        Set(value As String)
            _nombre = value
        End Set
    End Property

    Public Property Unico As Boolean
        Get
            Return _unico
        End Get
        Set(value As Boolean)
            _unico = value
        End Set
    End Property

    Public Property TipoIndice As String
        Get
            Return _tipoIndice
        End Get
        Set(value As String)
            _tipoIndice = value
        End Set
    End Property

    Public Property AutoCreado As Boolean
        Get
            Return _autoCreado
        End Get
        Set(value As Boolean)
            _autoCreado = value
        End Set
    End Property

    Public Property Fragmentacion As Long
        Get
            Return _fragmentacion
        End Get
        Set(value As Long)
            _fragmentacion = value
        End Set
    End Property

    Public Property Columnas As List(Of Columna)
        Get
            Return _columnas
        End Get
        Set(value As List(Of Columna))
            _columnas = value
        End Set
    End Property

    Public Property FillFactor As Integer
        Get
            Return _fillFactor
        End Get
        Set(value As Integer)
            _fillFactor = value
        End Set
    End Property

    Public Property NombreTabla As String
        Get
            Return _nombreTabla
        End Get
        Set(value As String)
            _nombreTabla = value
        End Set
    End Property

#End Region

End Class