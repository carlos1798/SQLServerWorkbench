Public Class Lexer
    Public Sub New()
    End Sub

    'Hay que encontrar una manera de tokenizar el texto
    'Plabras clave esta claro --> PalabraClave = Token
    'Palabras clave dentro de una palabra != Token (Por ejemplo 'As'tilla) <-  no se debe tokenizar
    'Comillas
    ';

    'Deberia devolver un diccionario con la palabra tokenizada 
    'El token tendria que tener el valor del string a tokenizar el index de donde empieza y el index de hasta donde deberia tokenizarse.

    Public Sub EvalTokens(text As String) ' As Token()
        Dim UpperText As String = text.ToUpper
        For Each caracter In UpperText
            If caracter.Equals("'") Then

            ElseIf caracter.Equals("*") Or caracter.Equals("-") Or caracter.Equals("+") Or caracter.Equals("=") Or caracter.Equals("=") Then

            Else




            End If

        Next


    End Sub





End Class
