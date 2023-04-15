Imports DbManejador.Token
Imports System.Reflection

Public Class Lexer
    Dim repoKeywords As New SQLKeywordsRepo()
    Public Sub New()
    End Sub

    Public Function getCharFromTIPO_TOKEN(TipodeToken As TipoToken) As Char
        Select Case TipodeToken
            Case TipoToken.TOKEN_COMILLAS_SIMPLES
                Return "'"c
            Case TipoToken.TOKEN_COMILLAS
                Return """"c
        End Select
    End Function

    Public Function TokenizarDelimitadoresDeCadenas(ByRef index As Integer, texto As String, TipodeToken As TipoToken) As Token
        Dim inicioPalabra As Integer
        Dim finalpalabra As Integer
        Dim palabra As String
        Dim char_a_revisar As Char = getCharFromTIPO_TOKEN(TipodeToken)
        Dim token As Token

        inicioPalabra = index
        finalpalabra = texto.IndexOf(char_a_revisar, index + 1)
        If finalpalabra = -1 Then
            finalpalabra = texto.Length - 1
        End If
        palabra = texto.Substring(inicioPalabra, finalpalabra - inicioPalabra)
        token = New Token(palabra, inicioPalabra, finalpalabra, TipodeToken)

        index = finalpalabra + 1
        Return token
    End Function
    Public Function TokenizarKeyword(ByRef index As Integer, texto As String) As Token

        Dim token As Token
        Dim palabra As String = ""
        Dim inicioPalabra As Integer = index
        Dim finalPalabra As Integer

        While index < texto.Length AndAlso Not Char.IsWhiteSpace(texto(index)) AndAlso texto(index) <> "'"c AndAlso texto(index) <> "*"c AndAlso texto(index) <> "-"c AndAlso texto(index) <> "+"c AndAlso texto(index) <> "/"c AndAlso texto(index) <> "="c
            palabra += texto(index)
            index += 1
        End While
        finalPalabra = index - 1
        If palabra <> "" Then
            ' Verificamos si la palabra es una palabra clave
            If repoKeywords.keywords.Contains(palabra) Then
                Token = New Token(palabra, inicioPalabra, finalPalabra, TipoToken.TOKEN_KEYWORD)
                Return token
            End If
        End If

    End Function

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
                tokens.Add(TokenizarDelimitadoresDeCadenas(index, UpperText, TipoToken.TOKEN_COMILLAS_SIMPLES))
            ElseIf c = "*"c Or c = "-"c Or c = "+"c Or c = "/"c Or c = "="c Then
                tokens.Add(New Token(TipoToken.TOKEN_OPERADORES, index, index))
                index += 1
            ElseIf c = """"c Then
                tokens.Add(TokenizarDelimitadoresDeCadenas(index, UpperText, TipoToken.TOKEN_COMILLAS_SIMPLES))
            Else
                If Not TokenizarKeyword(index, UpperText) Is Nothing Then
                    tokens.Add(TokenizarKeyword(index, UpperText))
                End If
            End If
        End While
        Return tokens


    End Function







End Class
