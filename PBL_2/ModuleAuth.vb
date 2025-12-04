Imports MySql.Data.MySqlClient
Imports System.Windows.Forms

Module ModuleAuth

    Public Function GetRole(username As String, password As String) As String
        Try
            Koneksi()   ' pastikan Conn sudah open

            Dim sql As String =
                "SELECT role FROM users " &
                "WHERE username = @u AND password = @p " &
                "LIMIT 1"

            Using cmd As New MySqlCommand(sql, Conn)
                cmd.Parameters.AddWithValue("@u", username)
                cmd.Parameters.AddWithValue("@p", password)

                Dim result = cmd.ExecuteScalar()

                If result IsNot Nothing AndAlso result IsNot DBNull.Value Then
                    Return result.ToString()
                End If
            End Using

        Catch ex As Exception
            MessageBox.Show("Terjadi kesalahan saat memeriksa login:" & Environment.NewLine &
                            ex.Message,
                            "Error Login",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Error)
        End Try

        ' Kalau gagal (tidak ketemu / error), kembalikan Nothing atau string kosong
        Return Nothing
    End Function
    Public Function GetUserInfo(username As String, password As String) As DataRow
        Koneksi()

        Dim sql As String =
            "SELECT u.id, u.username, u.role, d.periode " &
            "FROM users u " &
            "LEFT JOIN dosen d ON d.user_id = u.id " &
            "WHERE u.username=@u AND u.password=@p " &
            "LIMIT 1"

        Using cmd As New MySqlCommand(sql, Conn)
            cmd.Parameters.AddWithValue("@u", username)
            cmd.Parameters.AddWithValue("@p", password)

            Using da As New MySqlDataAdapter(cmd)
                Dim dt As New DataTable()
                da.Fill(dt)
                If dt.Rows.Count > 0 Then
                    Return dt.Rows(0)
                End If
            End Using
        End Using

        Return Nothing
    End Function


End Module
