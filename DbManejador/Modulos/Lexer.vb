Imports DbManejador.Token
Imports System.Reflection

Public Class Lexer
    Dim repoKeywords As New SQLKeywordsRepo()
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

            Else 'Keyword




            End If

        Next


    End Sub
    Public Function evToken(texto) As List(Of Token)
        Dim UpperText As String = texto.ToUpper()
        Dim tokens As New List(Of Token)()
        Dim palabra As String = ""
        Dim inicioPalabra As Integer = 0
        Dim finalPalabra As Integer = 0
        Dim index As Integer = 0
        While index < UpperText.Length
            Dim c As Char = UpperText(index)

            If c = "'"c Then
                ' Encontramos una comilla
                inicioPalabra = index
                finalPalabra = UpperText.IndexOf("'"c, index + 1)
                If finalPalabra = -1 Then
                    finalPalabra = UpperText.Length - 1
                End If
                tokens.Add(New Token(TipoToken.TOKEN_COMILLAS, inicioPalabra, finalPalabra))
                index = finalPalabra + 1
            ElseIf c = "*"c Or c = "-"c Or c = "+"c Or c = "/"c Or c = "="c Then
                ' Encontramos un operador
                tokens.Add(New Token(TipoToken.TOKEN_OPERADORES, index, index))
                index += 1
            Else
                ' Encontramos una palabra
                inicioPalabra = index
                While index < UpperText.Length AndAlso Not Char.IsWhiteSpace(UpperText(index)) AndAlso UpperText(index) <> "'"c AndAlso UpperText(index) <> "*"c AndAlso UpperText(index) <> "-"c AndAlso UpperText(index) <> "+"c AndAlso UpperText(index) <> "/"c AndAlso UpperText(index) <> "="c
                    palabra += UpperText(index)
                    index += 1
                End While
                finalPalabra = index - 1
                If palabra <> "" Then
                    ' Verificamos si la palabra es una palabra clave
                    If repoKeywords.keywords.Contains(palabra) Then
                        tokens.Add(New Token(palabra, inicioPalabra, finalPalabra, TipoToken.TOKEN_KEYWORD))

                    End If
                End If
                palabra = ""
            End If
            index += 1

        End While
        Return tokens


    End Function







End Class
