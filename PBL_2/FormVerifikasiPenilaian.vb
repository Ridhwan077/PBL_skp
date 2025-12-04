Imports MySql.Data.MySqlClient

Public Class FormVerifikasiPenilaian

    Dim cmd As MySqlCommand
    Dim dr As MySqlDataReader
    Private Sub dgvVerifikasi_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgvVerifikasi.CellContentClick

    End Sub

    Private Sub ComboBox1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cboNamaDosen.SelectedIndexChanged
        Try
            If Conn.State = ConnectionState.Closed Then Conn.Open()

            ' Ambil nama yang dipilih user
            Dim namaPilihan As String = cboNamaDosen.Text

            ' Cari nip dan Prodi orang tersebut
            Dim query As String = "SELECT nip, prodi FROM dosen WHERE nama = @nama"

            cmd = New MySqlCommand(query, Conn)
            cmd.Parameters.AddWithValue("@nama", namaPilihan)

            dr = cmd.ExecuteReader()

            If dr.Read() Then
                ' Isi Textbox NIP (Cek null biar gak error)
                If Not IsDBNull(dr("nip")) Then
                    txtNip.Text = dr("nip").ToString()
                Else
                    txtNip.Text = "-"
                End If

                ' Isi Textbox/Combo Prodi
                If Not IsDBNull(dr("prodi")) Then
                    txtProdi.Text = dr("prodi").ToString()
                Else
                    txtProdi.Text = "-"
                End If
            End If
            dr.Close()

        Catch ex As Exception
            MessageBox.Show("Error ambil data: " & ex.Message)
        End Try
    End Sub

    Private Sub cboPeriode_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cboPeriode.SelectedIndexChanged

    End Sub

    Private Sub btnTutup_Click(sender As Object, e As EventArgs) Handles btnTutup.Click

    End Sub

    Private Sub btnSetFinal_Click(sender As Object, e As EventArgs) Handles btnSetFinal.Click

    End Sub
End Class