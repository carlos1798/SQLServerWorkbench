Imports System.IO
Imports System.Xml
Imports System.Xml.Serialization

Public Class Registro

    ReadOnly userName As String = My.User.Name.ToString
    ReadOnly trimUsername As String = userName.Remove(0, userName.LastIndexOf("\") + 1)
    Dim filepath As String = $"C:\Users\{trimUsername}\Documents\"
    ReadOnly xmlPath As String = $"{filepath}\DatosServidor.xml"
    Public Sub New()
    End Sub
#Region "Servidor"
    'La idea buena seria generar un json y leerlo 
    'Parseamos un archivo para ver si se ha ejecutado 
    'Public Function checkServerLog() As Boolean
    '    'TODO: Comprobar si existe el log de servidores en el usuario

    'End Function
    Public Function GetServidores() As Servidores

        'Para que esto funcione hay que meter una clase que sea lista de servidores y que deserialize eso en el objeto lista y de ahi ya tienes los objetos 

        Dim fileData As New Servidores()
        Try
            Dim reader = New XmlSerializer(GetType(Servidores))
            Using file As New StreamReader(xmlPath)

                fileData = CType(reader.Deserialize(file), Servidores)
                Return fileData
            End Using



        Catch ex As Exception
            Return fileData
        End Try
        'TODO: Lista que devuelva los servidores almacenados
    End Function
    Public Sub SaveServidor(servidor As Servidor)
        'TODO: Para arreglar que salga bien tengo que leer el xml y sobrescribilo 

        Dim listaServidores = GetServidores()


        listaServidores.listaServidores.Add(servidor)
        Dim reader = New XmlSerializer(GetType(Servidor))

        Dim tipoServidor As Type = GetType(Servidores)
        Dim writer As New XmlSerializer(GetType(Servidores))
        Using file As New StreamWriter($"{filepath}\DatosServidor.xml")
            writer.Serialize(file, listaServidores)
        End Using

    End Sub


#End Region

#Region "Log.txt"


    Public Sub RecordLog(nombreFichero As String)
        Dim fecha As Date
        fecha = Today
        Dim path = $"{filepath}Log.txt"
        Using fs As New FileStream(path, FileMode.Append, FileAccess.Write, FileShare.ReadWrite)
            Using sw As New StreamWriter(fs)
                sw.WriteLine(fecha.ToString & " " & nombreFichero)
                sw.Flush()
                sw.Close()
            End Using

            fs.Close()
        End Using
    End Sub


    Public Function GetUltimoRegistro() As String
        Dim path = $"{filepath}Log.txt"
        Dim fs As New FileStream(path, FileMode.OpenOrCreate, FileAccess.Read, FileShare.None)
        Dim sr As New StreamReader(fs)

        Dim contenidoArchivo As String = ""
        Dim nombreFichero As String = ""
        Try
            While sr.EndOfStream = False
                contenidoArchivo = sr.ReadLine()
            End While

            If Not contenidoArchivo = Nothing Then
                nombreFichero = contenidoArchivo.Substring(contenidoArchivo.LastIndexOf(" ") + 1)
            End If

            sr.Close()
        Catch ex As Exception

        End Try
        Return nombreFichero
    End Function

#End Region

#Region "GeneradorSql"

    Public Function CheckFichero(nombreFichero As String, extension As String) As Boolean
        filepath = $"{filepath}{nombreFichero}.{extension}"
        Return File.Exists(filepath)
    End Function

    Public Sub GenerarFicheroSql(nombreFichero As String)
        filepath = $"{filepath}{nombreFichero}.sql"
        Using fs As New FileStream(filepath, FileMode.Append, FileAccess.Write, FileShare.ReadWrite)
            Using sw As New StreamWriter(fs)
                sw.Flush()
                sw.Close()
            End Using

            fs.Close()
        End Using
    End Sub

    Public Sub InsertarSentencia(nombreFichero As String, sentencia As String)
        Dim path = $"{filepath}{nombreFichero}.sql"
        Dim fs As New FileStream(path, FileMode.Append, FileAccess.Write, FileShare.ReadWrite)
        Dim sw As New StreamWriter(fs)
        sw.WriteLine(sentencia)
        sw.WriteLine()
        sw.Flush()
        sw.Close()
        fs.Close()
    End Sub

    Public Function GenerarString(lista As List(Of String))

        Dim stringPrincipal As String = ""
        For Each item In lista
            stringPrincipal = stringPrincipal + vbCrLf + item

        Next
        Return stringPrincipal

    End Function

#End Region

End Class