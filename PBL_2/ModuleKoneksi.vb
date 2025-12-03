Imports MySql.Data.MySqlClient
Imports System.Windows.Forms

Module ModuleKoneksi

    Public Conn As MySqlConnection

    Public Sub Koneksi()
        Try
            If Conn Is Nothing Then
                Conn = New MySqlConnection("server=localhost;user id=root;password=;database=skp_pv;")
            End If

            If Conn.State <> ConnectionState.Open Then
                Conn.Open()
            End If

        Catch ex As Exception
            MessageBox.Show("Gagal koneksi ke database: " & ex.Message,
                            "Error Koneksi",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Error)
        End Try
    End Sub

End Module
