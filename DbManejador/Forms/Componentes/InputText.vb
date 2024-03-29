﻿Imports System.ComponentModel
Imports System.Runtime.CompilerServices
Imports System.Security.Principal
Imports System.Text.RegularExpressions

Public Class InputText
    Dim lexer As New Lexer()
    Public tokenes As New List(Of Token)

    'TODO: Pasarle el guardado sql a este textbox
    'TODO: Crear un evento para cuando se pase el sql y que haga el parseo para resaltar las keywords
    Private Sub RichTextBox1_TextChanged(sender As Object, e As EventArgs) Handles RichTextBox1.TextChanged
        Dim originalIndex As Integer
        Dim originalLength As Integer
        originalIndex = RichTextBox1.SelectionStart
        originalLength = RichTextBox1.SelectionLength
        Label1.Focus()

        RichTextBox1.SelectAll()
        RichTextBox1.SelectionColor = Color.Black
        Dim tokens As List(Of Token) = lexer.evToken(RichTextBox1.Text)
        For Each token In tokens
            RichTextBox1.Select(token.Inicio, token.Final - token.Inicio + 1)
            If token.Tipo = Token.TipoToken.TOKEN_COMILLAS Or token.Tipo = Token.TipoToken.TOKEN_COMILLAS_SIMPLES Then

                RichTextBox1.SelectionColor = Color.Green
            Else
                If Not token.Contenido = Nothing Then
                    If token.Contenido.ToUpper = "WHERE" Then
                        RichTextBox1.SelectionColor = Color.DeepSkyBlue

                    ElseIf token.Contenido.ToUpper = "NULL" Then

                        RichTextBox1.SelectionColor = Color.Gray
                    ElseIf token.Tipo = Token.TipoToken.TOKEN_NUMERICO Then
                        RichTextBox1.SelectionColor = Color.BlueViolet

                    ElseIf token.Tipo = Token.TipoToken.TOKEN_KEYWORD Then
                        RichTextBox1.SelectionColor = Color.DeepPink
                    End If
                End If
                RichTextBox1.DeselectAll()
            End If
        Next

        RichTextBox1.SelectionStart = originalIndex
        RichTextBox1.SelectionLength = originalLength
        RichTextBox1.SelectionColor = Color.Black
        RichTextBox1.ForeColor = Color.Black
        RichTextBox1.Focus()

        RichTextBox1.DeselectAll()
        tokenes = tokens
    End Sub

End Class