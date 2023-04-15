﻿Imports System.ComponentModel
Imports System.Runtime.CompilerServices
Imports System.Security.Principal
Imports System.Text.RegularExpressions

Public Class InputText
    Dim lexer As New Lexer()

    'TODO: Pasarle el guardado sql a este textbox 
    'TODO: Crear un evento para cuando se pase el sql y que haga el parseo para resaltar las keywords
    Private Sub RichTextBox1_TextChanged(sender As Object, e As EventArgs) Handles RichTextBox1.TextChanged
        Dim originalIndex As Integer
        Dim originalLength As Integer
        originalIndex = RichTextBox1.SelectionStart
        originalLength = RichTextBox1.SelectionLength


        RichTextBox1.SelectAll()
        RichTextBox1.SelectionColor = Color.Black
        Dim tokens As List(Of Token) = lexer.evToken(RichTextBox1.Text)
        For Each token In tokens
            RichTextBox1.Select(token.Inicio, token.Final - token.Inicio + 1)
            If token.Tipo = Token.TipoToken.TOKEN_COMILLAS Then

                RichTextBox1.SelectionColor = Color.LightGreen
            Else
                RichTextBox1.SelectionColor = Color.DeepPink
            End If
            RichTextBox1.DeselectAll()
        Next

        RichTextBox1.SelectionColor = Color.Black
        RichTextBox1.ForeColor = Color.Black
    End Sub
End Class
