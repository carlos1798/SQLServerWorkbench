Imports System.Runtime.CompilerServices

Public Class InputText

    'TODO: Pasarle el guardado sql a este textbox 
    'TODO: Crear un evento para cuando se pase el sql y que haga el parseo para resaltar las keywords
    Private Sub RichTextBox1_KeyDown(sender As Object, e As KeyEventArgs) Handles RichTextBox1.KeyDown
        Dim sqlrepo As New SQLKeywordsRepo()
        Dim keywords = sqlrepo.keywords
        Dim posicionCursor As Integer = RichTextBox1.SelectionStart

        If e.KeyCode = Keys.Space Then
            Dim i As Integer
            Dim j As Integer
            Dim cadenaLower As String = RichTextBox1.Text
            Dim cadena = cadenaLower.ToUpper()

            For i = 0 To keywords.Length - 1
                For j = 0 To RichTextBox1.TextLength - keywords(i).Length
                    If cadena.Substring(j, keywords(i).Length) = keywords(i) Then
                        If cadena.Substring(j, keywords(i).Length).Trim() = keywords(i) Then

                            RichTextBox1.Select(j, keywords(i).Length)
                            RichTextBox1.SelectionColor = Color.Blue

                            j += 1
                        End If
                    End If
                Next
            Next
            RichTextBox1.SelectionStart = posicionCursor
            RichTextBox1.SelectionLength = 0
            RichTextBox1.SelectionColor = Color.Black




        End If
    End Sub
End Class
