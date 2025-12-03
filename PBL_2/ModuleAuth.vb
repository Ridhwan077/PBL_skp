Imports MySql.Data.MySqlClient

Module ModuleAuth
    Public Function GetRole(username As String, password As String) As String
        Koneksi()

        Dim cmd As New MySqlCommand("SELECT role FROM users WHERE username=@u AND password=@p", Conn)
        cmd.Parameters.AddWithValue("@u", username)
        cmd.Parameters.AddWithValue("@p", password)

        Dim result = cmd.ExecuteScalar()

        If result IsNot Nothing Then
            Return result.ToString()
        Else
            Return Nothing
        End If
    End Function
End Module
