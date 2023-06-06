Public Interface IDAO(Of T)

    Function FindBy(ByVal name) As T

    Function FindAll() As List(Of T)

End Interface