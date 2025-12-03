Imports MySql.Data.MySqlClient

Module ModuleKoneksi
    Public Conn As MySqlConnection

    Public Sub Koneksi()
        Try
            Conn = New MySqlConnection("server=localhost;user id=root;password=;database=skp_pv;")
            If Conn.State = ConnectionState.Closed Then
                Conn.Open()
            End If
        Catch ex As Exception
            MsgBox("Gagal koneksi ke database: " & ex.Message)
        End Try
    End Sub
End Module
