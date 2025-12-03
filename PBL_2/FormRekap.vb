Imports MySql.Data.MySqlClient


Public Class FormRekap

    Dim cmd As MySqlCommand
    Dim dr As MySqlDataReader

    Private Sub LoadDataKajur()
        Try
            If Conn.State = ConnectionState.Closed Then Conn.Open()

            ' --- QUERY PINTAR ---
            ' Kita pakai CASE WHEN untuk mengubah angka 0/1 menjadi teks "Belum Sah"/"SAH"
            ' Kita pakai AS '...' untuk memberi judul kolom otomatis

            Dim query As String = "SELECT " &
                                  "d.nama AS 'Nama Dosen', " &
                                  "s.nilai_akhir AS 'Nilai Akhir', " &
                                  "s.predikat AS 'Predikat', " &
                                  "CASE WHEN s.status_verifikasi_kajur = 1 THEN 'SAH' ELSE 'Belum Disetujui' END AS 'Status Kajur', " &
                                  "s.nip AS 'NIP' " &  ' Kolom NIP disembunyikan/ditaruh belakang buat referensi
                                  "FROM tr_status_penilaian s " &
                                  "JOIN dosen d ON s.nip = d.nip " &
                                  "WHERE s.periode = @per AND s.nilai_akhir > 0"

            cmd = New MySqlCommand(query, Conn)
            cmd.Parameters.AddWithValue("@per", cboPeriode.Text)

            Dim da As New MySqlDataAdapter(cmd)
            Dim dt As New DataTable()
            da.Fill(dt)

            ' TEMPELKAN DATA KE GRID
            dgvRekap.DataSource = dt

            ' --- KOSMETIK (OPSIONAL: Biar Rapi) ---
            ' Sembunyikan kolom NIP (karena Kajur cuma butuh lihat Nama)
            If dgvRekap.Columns.Contains("NIP") Then
                dgvRekap.Columns("NIP").Visible = False
            End If

            ' Atur Lebar Kolom
            dgvRekap.Columns("Nama Dosen").Width = 200
            dgvRekap.Columns("Nilai Akhir").Width = 80
            dgvRekap.Columns("Predikat").Width = 150
            dgvRekap.Columns("Status Kajur").Width = 120

        Catch ex As Exception
            MessageBox.Show("Gagal tampil data: " & ex.Message)
        End Try
    End Sub
    Private Sub dgvRekap_CellContentClick(sender As Object, e As DataGridViewCellEventArgs)

    End Sub

    Private Sub cboNamaDosen_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cboNamaDosen.SelectedIndexChanged
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

    Private Sub dgvRekap_CellContentClick_1(sender As Object, e As DataGridViewCellEventArgs) Handles dgvRekap.CellContentClick

    End Sub
End Class