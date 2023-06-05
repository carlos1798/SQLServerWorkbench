Imports System.Runtime.CompilerServices

Public Class SubMenu

    Private Sub Atras_Click(sender As Object, e As EventArgs) Handles Atras.Click
        Dim form As Form = Me.FindForm()
        form.Close()
    End Sub

    Private Sub ToolStrip1_ItemClicked(sender As Object, e As ToolStripItemClickedEventArgs) Handles ToolStrip1.ItemClicked

    End Sub

End Class