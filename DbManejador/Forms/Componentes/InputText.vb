Imports System.ComponentModel
Imports System.Runtime.CompilerServices
Imports System.Security.Principal
Imports System.Text.RegularExpressions

Public Class InputText
    Dim lexer As New Lexer()


    'TODO: Pasarle el guardado sql a este textbox 
    'TODO: Crear un evento para cuando se pase el sql y que haga el parseo para resaltar las keywords
    Private Sub RichTextBox1_KeyDown(sender As Object, e As KeyEventArgs) Handles RichTextBox1.KeyDown





    End Sub


    Private Sub RichTextBox1_Validating(sender As Object, e As CancelEventArgs) Handles RichTextBox1.Validating

    End Sub

    Private Sub RichTextBox1_KeyPress(sender As Object, e As KeyPressEventArgs) Handles RichTextBox1.KeyPress


    End Sub

    Private Sub RichTextBox1_Validated(sender As Object, e As EventArgs) Handles RichTextBox1.Validated
        RichTextBox1.SelectAll()
        RichTextBox1.SelectionColor = Color.Black
        Dim tokens As List(Of Token) = lexer.evToken(RichTextBox1.Text)
        For Each token In tokens
            RichTextBox1.Select(token.Inicio, token.Final - token.Inicio + 1)
            RichTextBox1.SelectionColor = Color.Blue
            RichTextBox1.DeselectAll()
        Next

        RichTextBox1.SelectionColor = Color.Black
        RichTextBox1.ForeColor = Color.Black

    End Sub
End Class
