Imports System.Text
Public NotInheritable Class SqlFunctions




	Public Async Function ExecuteNonQueryAsync(query As String, ParamArray sqlparams() As SqlClient.SqlParameter) As Task(Of Integer)
			Try
				Dim result As Integer
			Using conn As New SqlClient.SqlConnection(My.Settings.ConnectionString)
				conn.Open()
				Using comm As New SqlClient.SqlCommand(query, conn)
					comm.Parameters.AddRange(sqlparams)
					result = Await comm.ExecuteNonQueryAsync()
				End Using
			End Using
			Return result
			Catch ex As Exception
				Return -1
			Finally
			End Try
		End Function
		Public Async Function ExecuteQueryAsync(query As String, ParamArray sqlparams() As SqlClient.SqlParameter) As Task(Of DataTable)
			Dim dt As New DataTable
			Dim errorCount As Integer = 0
			Try
			Using conn As New SqlClient.SqlConnection(My.Settings.ConnectionString)
				Await conn.OpenAsync
				Using comm As New SqlClient.SqlCommand(query, conn)
					comm.Parameters.AddRange(sqlparams)
					Using reader = Await comm.ExecuteReaderAsync()
						dt.Load(reader)
					End Using
				End Using
			End Using
			Return dt
			Catch ex As Exception
				Return dt
			Finally
			End Try
		End Function
		Public Function SQLWhereInLong(longList As List(Of Long), Optional includeParentheses As Boolean = False) As String
			If longList Is Nothing OrElse longList.Count = 0 Then Return ""
			Dim sb As New StringBuilder
			If includeParentheses Then
				sb.Append("(")
			End If

			For i As Integer = 0 To longList.Count - 1
				sb.Append(longList(i))
				If i < longList.Count - 1 Then
					sb.Append(",")
				End If
			Next

			If includeParentheses Then
				sb.Append(")")
			End If

			Return sb.ToString()
		End Function
		Public Function GetSQLFieldValue(item As Object, ValueNull As Integer) As Integer
			If IsDBNull(item) Then
				Return ValueNull
			Else
				Return item
			End If
		End Function
		Public Function GetSQLFieldValue(item As Object, ValueNull As Long) As Long
			If IsDBNull(item) Then
				Return ValueNull
			Else
				Return item
			End If
		End Function
		Public Function GetSQLFieldValue(item As Object, ValueNull As String) As String
			If IsDBNull(item) Then
				Return ValueNull
			Else
				Return item
			End If
		End Function
		Public Function GetSQLFieldValue(item As Object, ValueNull As Date) As Date
			If IsDBNull(item) Then
				Return ValueNull
			Else
				Return item
			End If
		End Function
		Public Function GetSQLFieldValue(item As Object, ValueNull As Boolean) As Boolean
			If IsDBNull(item) Then
				Return ValueNull
			Else
				Return item
			End If
		End Function
	End Class

