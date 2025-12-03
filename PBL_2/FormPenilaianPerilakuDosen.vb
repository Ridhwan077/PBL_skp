Imports MySql.Data.MySqlClient

Public Class FormPenilaianPerilakuDosen

    Public Sub New()
        InitializeComponent()
    End Sub

    Private _roleUser As String
    Private _namaUser As String

    Dim cmd As MySqlCommand
    Dim dr As MySqlDataReader

    Public Sub New(role As String, nama As String)
        InitializeComponent()
        _roleUser = role
        _namaUser = nama
    End Sub
    Private Sub dgvPertanyaan_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgvPertanyaan.CellContentClick
        Dim indexKolomBukti As Integer = 5

        If e.ColumnIndex = indexKolomBukti AndAlso e.RowIndex >= 0 Then

            ' Siapkan Dialog untuk pilih file
            Dim openFile As New OpenFileDialog()
            openFile.Filter = "File Dokumen|*.pdf;*.jpg;*.png;*.docx"
            openFile.Title = "Pilih Bukti Pendukung"

            If openFile.ShowDialog() = DialogResult.OK Then
                ' Ambil nama file saja (biar gak kepanjangan)
                Dim namaFile As String = System.IO.Path.GetFileName(openFile.FileName)

                ' Tampilkan nama file di tombol tersebut (biar user tau sudah upload)
                dgvPertanyaan.Rows(e.RowIndex).Cells(indexKolomBukti).Value = namaFile

                ' Opsional: Simpan Path lengkap di 'Tag' (disembunyikan) untuk keperluan save nanti
                dgvPertanyaan.Rows(e.RowIndex).Cells(indexKolomBukti).Tag = openFile.FileName

                MessageBox.Show("File berhasil dipilih: " & namaFile, "Sukses")
            End If
        End If
    End Sub

    Private Sub dgvPertanyaan_CellValidating(sender As Object, e As DataGridViewCellValidatingEventArgs) Handles dgvPertanyaan.CellValidating
        If e.ColumnIndex = 3 Then

            ' 1. Ambil Tipe Input dari Tag (Yang disimpan saat LoadPertanyaan)
            Dim tipe As String = ""
            If dgvPertanyaan.Rows(e.RowIndex).Cells(3).Tag IsNot Nothing Then
                tipe = dgvPertanyaan.Rows(e.RowIndex).Cells(3).Tag.ToString()
            End If

            ' Jika tipe YaTidak (Dropdown), tidak perlu divalidasi angka
            If tipe = "YaTidak" Then Exit Sub


            ' 2. Cek Inputan User
            Dim nilaiBaru As String = e.FormattedValue.ToString()

            ' Kalau kosong, biarkan saja (siapa tau user mau hapus dulu)
            If nilaiBaru = "" Then Exit Sub

            ' Pastikan user mengetik ANGKA
            If Not IsNumeric(nilaiBaru) Then
                e.Cancel = True
                MessageBox.Show("Harap isi dengan angka!", "Error Input")
                Exit Sub
            End If

            Dim angka As Double = Convert.ToDouble(nilaiBaru)

            ' 3. VALIDASI SESUAI TIPE
            Select Case tipe
                Case "Persen"
                    ' Aturan Persen: Boleh 0 sampai 100
                    If angka < 0 Or angka > 100 Then
                        e.Cancel = True
                        MessageBox.Show("Untuk Persentase, masukkan angka 0 sampai 100.", "Salah Input")
                    End If

                Case "Skala"
                    ' Aturan Skala: Boleh 1 sampai 10
                    If angka < 1 Or angka > 10 Then
                        e.Cancel = True
                        MessageBox.Show("Untuk Skala, masukkan angka 1 sampai 10.", "Salah Input")
                    End If

                Case Else
                    ' Jaga-jaga kalau di database kosong/typo, kita anggap Skala (Default)
                    If angka < 1 Or angka > 10 Then
                        e.Cancel = True
                        MessageBox.Show("Nilai harus 1 - 10", "Salah Input")
                    End If
            End Select

        End If
    End Sub

    Private Sub LoadPertanyaan()
        dgvPertanyaan.Rows.Clear()

        Try
            If Conn.State = ConnectionState.Closed Then Conn.Open()

            ' QUERY: Menggunakan UPPER agar tidak peduli huruf besar/kecil
            Dim query As String = "SELECT * FROM ms_pertanyaan WHERE UPPER(target_role) = UPPER(@role)"

            cmd = New MySqlCommand(query, Conn)
            cmd.Parameters.AddWithValue("@role", _roleUser)

            dr = cmd.ExecuteReader()

            Dim nomor As Integer = 1
            While dr.Read()
                ' Masukkan ke Grid (Pastikan ada 6 kolom di desain)
                Dim i As Integer = dgvPertanyaan.Rows.Add(
                    nomor,
                    dr("aspek").ToString(),
                    dr("pertanyaan").ToString(),
                    "", "", ""
                )

                ' Simpan ID (Hidden)
                dgvPertanyaan.Rows(i).Cells(0).Tag = dr("id").ToString()

                ' Ambil Tipe Input & Validasi Tooltip
                Dim tipe As String = ""
                If Not IsDBNull(dr("tipe_input")) Then tipe = dr("tipe_input").ToString()
                dgvPertanyaan.Rows(i).Cells(3).Tag = tipe ' Simpan tipe input

                If tipe = "YaTidak" Then
                    ' Buat sel tipe ComboBox baru
                    Dim comboCell As New DataGridViewComboBoxCell()

                    ' Isi pilihannya
                    comboCell.Items.Add("Ya")
                    comboCell.Items.Add("Tidak")

                    ' Ganti sel Textbox standar (Index 3) dengan sel ComboBox ini
                    dgvPertanyaan.Rows(i).Cells(3) = comboCell

                    ' Set nilai default (Opsional)
                    dgvPertanyaan.Rows(i).Cells(3).Value = "Ya"
                    dgvPertanyaan.Rows(i).Cells(3).Style.BackColor = Color.LightYellow

                ElseIf tipe = "Persen" Then
                    ' Kalau persen tetap Textbox biasa, cuma kasih warna/tooltip
                    dgvPertanyaan.Rows(i).Cells(3).ToolTipText = "Isi angka 0-100"
                    dgvPertanyaan.Rows(i).Cells(3).Style.BackColor = Color.AliceBlue
                Else
                    ' Skala biasa
                    dgvPertanyaan.Rows(i).Cells(3).ToolTipText = "Isi angka 1-10"
                End If

                nomor += 1
            End While
            dr.Close()

        Catch ex As Exception
            MessageBox.Show("Gagal memuat pertanyaan: " & ex.Message)
        End Try
    End Sub

    Private Sub IsiListDosen()
        Try
            ' Bersihkan daftar lama biar gak dobel
            cboNamaDosen.Items.Clear()

            If Conn.State = ConnectionState.Closed Then Conn.Open()

            ' Ambil nama dosen saja, urut abjad
            ' PASTIKAN NAMA TABEL & KOLOM SESUAI DATABASE KAMU (misal: dosen / ms_dosen)
            Dim query As String = "SELECT nama FROM dosen ORDER BY nama ASC"

            cmd = New MySqlCommand(query, Conn)
            dr = cmd.ExecuteReader()

            While dr.Read()
                ' Masukkan nama ke dalam ComboBox
                cboNamaDosen.Items.Add(dr("nama").ToString())
            End While
            dr.Close()

        Catch ex As Exception
            MessageBox.Show("Gagal memuat daftar dosen: " & ex.Message)
        End Try
    End Sub

    ' ==========================================
    ' 1. SAAT FORM DIBUKA -> ISI DAFTAR DOSEN
    ' ==========================================
    Private Sub FormPenilaian_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ' Cek apakah data sampai? (Nanti kalau sudah fix, baris ini boleh dihapus)
        ' MessageBox.Show("Login sebagai: " & _namaUser & " | Role: " & _roleUser)

        ' Panggil Pertanyaan
        LoadPertanyaan()
        IsiListDosen()

        ' Setting Tampilan Awal
        txtNip.ReadOnly = True
        cboProgramStudi.Enabled = False

        ' Isi Pilihan Periode
        cboPeriode.Items.Clear()
        cboPeriode.Items.Add("2024/2025 Ganjil")
        cboPeriode.Items.Add("2024/2025 Genap")
        cboPeriode.SelectedIndex = 0

        ' Load Daftar Dosen ke ComboBox
        IsiComboDosen()
    End Sub

    ' ====================================================
    ' 2. SAAT NAMA DIPILIH -> OTOMATIS ISI NIP & PRODI
    ' ====================================================
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
                    cboProgramStudi.Text = dr("prodi").ToString()
                Else
                    cboProgramStudi.Text = "-"
                End If
            End If
            dr.Close()

        Catch ex As Exception
            MessageBox.Show("Error ambil data: " & ex.Message)
        End Try
    End Sub

    Private Sub IsiComboDosen()
        Try
            If Conn.State = ConnectionState.Closed Then Conn.Open()
            cboNamaDosen.Items.Clear()

            cmd = New MySqlCommand("SELECT nama FROM dosen ORDER BY nama ASC", Conn)
            dr = cmd.ExecuteReader()
            While dr.Read()
                cboNamaDosen.Items.Add(dr("nama").ToString())
            End While
            dr.Close()
        Catch ex As Exception
            ' Abaikan error saat load dosen
        End Try
    End Sub

    Private Sub btnBatal_Click(sender As Object, e As EventArgs) Handles btnBatal.Click
        Dim tanya = MessageBox.Show("Yakin ingin membatalkan penilaian? Data yang belum disimpan akan hilang.", "Konfirmasi", MessageBoxButtons.YesNo, MessageBoxIcon.Question)

        If tanya = DialogResult.Yes Then
            Me.Close() ' Menutup form penilaian
        End If
    End Sub

    Private Sub HitungDanSimpan()

        ' --- VARIABEL PERHITUNGAN ---
        Dim m_old As Double = 0.0      ' Belief DST
        Dim theta_old As Double = 1.0  ' Uncertainty DST

        Dim totalPersen As Double = 0
        Dim jumlahSoalPersen As Integer = 0

        Dim jumlahYa As Integer = 0
        Dim jumlahSoalYaTidak As Integer = 0


        ' 1. LOOPING DATA GRID (MEMISAHKAN JENIS SOAL)
        For Each row As DataGridViewRow In dgvPertanyaan.Rows
            If row.IsNewRow Then Continue For

            ' Ambil Inputan
            Dim inputUser As String = ""
            If row.Cells(3).Value IsNot Nothing Then inputUser = row.Cells(3).Value.ToString()
            If inputUser = "" Then Continue For

            ' Ambil Tipe
            Dim tipe As String = "skala"
            If row.Cells(3).Tag IsNot Nothing Then tipe = row.Cells(3).Tag.ToString().ToLower().Trim()

            ' PROSES HITUNG SESUAI TIPE
            Select Case tipe

            ' === KOMPONEN 1: METODE DST (Bobot 50%) ===
                Case "skala"
                    Dim angka As Double = Convert.ToDouble(inputUser)
                    Dim m_new As Double = angka / 10.0 ' Konversi ke densitas 0.1 - 1.0
                    Dim theta_new As Double = 1.0 - m_new

                    ' Rumus Kombinasi Dempster
                    Dim m_kombinasi As Double = (m_old * m_new) + (m_old * theta_new) + (theta_old * m_new)
                    Dim theta_kombinasi As Double = theta_old * theta_new

                    m_old = m_kombinasi
                    theta_old = theta_kombinasi

            ' === KOMPONEN 2: RATA-RATA PERSEN (Bobot 30%) ===
                Case "persen"
                    Dim angka As Double = Convert.ToDouble(inputUser)
                    totalPersen += angka
                    jumlahSoalPersen += 1

            ' === KOMPONEN 3: KEPATUHAN YA/TIDAK (Bobot 20%) ===
                Case "yatidak"
                    jumlahSoalYaTidak += 1
                    If inputUser.ToLower() = "ya" Then jumlahYa += 1

            End Select
        Next


        ' 2. DAPATKAN NILAI MENTAH (Skala 0-100)

        ' A. Nilai DST (0-100)
        Dim skorDST As Double = m_old * 100

        ' B. Nilai Rata-rata Persen (0-100)
        Dim skorPersen As Double = 0
        If jumlahSoalPersen > 0 Then skorPersen = totalPersen / jumlahSoalPersen

        ' C. Nilai Ya/Tidak (0-100)
        Dim skorYaTidak As Double = 0
        If jumlahSoalYaTidak > 0 Then skorYaTidak = (jumlahYa / jumlahSoalYaTidak) * 100


        ' 3. HITUNG NILAI AKHIR (PENGGABUNGAN DENGAN BOBOT)
        ' Bobot: DST=50%, Persen=30%, YaTidak=20%

        Dim NilaiAkhirTotal As Double = (skorDST * 0.5) + (skorPersen * 0.3) + (skorYaTidak * 0.2)


        ' 4. TENTUKAN PREDIKAT / LABEL OUTPUT
        Dim Predikat As String = ""
        Dim WarnaPredikat As String = "" ' Cuma buat info

        If NilaiAkhirTotal >= 90 Then
            Predikat = "DI ATAS EKSPEKTASI"
        ElseIf NilaiAkhirTotal >= 76 Then
            Predikat = "SESUAI EKSPEKTASI"
        Else
            Predikat = "DI BAWAH EKSPEKTASI"
        End If


        ' 5. TAMPILKAN HASIL (POPUP LAPORAN)
        Dim pesan As String = "DETAIL PERHITUNGAN:" & vbCrLf &
                              "----------------------------------" & vbCrLf &
                              "1. Perilaku (Metode DST) : " & skorDST.ToString("F2") & " (Bobot 50%)" & vbCrLf &
                              "2. Capaian (Rata-rata)   : " & skorPersen.ToString("F2") & " (Bobot 30%)" & vbCrLf &
                              "3. Kepatuhan (Ya/Tidak)  : " & skorYaTidak.ToString("F2") & " (Bobot 20%)" & vbCrLf &
                              "----------------------------------" & vbCrLf &
                              "NILAI AKHIR: " & NilaiAkhirTotal.ToString("F2") & vbCrLf &
                              "PREDIKAT   : " & Predikat

        MessageBox.Show(pesan, "Hasil Penilaian Kinerja")


        ' 6. SIMPAN KE DATABASE
        Try
            If Conn.State = ConnectionState.Closed Then Conn.Open()

            ' A. Simpan Detail Jawaban (Looping row)
            For Each row As DataGridViewRow In dgvPertanyaan.Rows
                If row.IsNewRow Then Continue For
                ' ... (Kode INSERT INTO tr_penilaian kamu yang lama) ...
            Next

            ' B. Simpan Rekap Nilai Akhir (PENTING!)
            ' Pastikan kamu punya tabel 'rekap_nilai'
            ' Query contoh:
            ' INSERT INTO rekap_nilai (nama_dosen, periode, nilai_dst, nilai_persen, nilai_yt, nilai_akhir, predikat) 
            ' VALUES (@nama, @per, @dst, @prsn, @yt, @akhir, @pred)

            MessageBox.Show("Data dan Predikat berhasil disimpan!", "Sukses")
            Me.Close()

        Catch ex As Exception
            MessageBox.Show("Gagal Simpan: " & ex.Message)
        End Try

    End Sub

    Private Sub btnKirimVerifikasi_Click(sender As Object, e As EventArgs) Handles btnKirimVerifikasi.Click
        ' 1. CEK DULU: APAKAH DOSEN SUDAH DIPILIH? (Anti Error Null)
        If cboNamaDosen.Text = "" Or txtNip.Text = "" Or txtNip.Text = "-" Then
            MessageBox.Show("Harap pilih Nama Dosen terlebih dahulu!", "Peringatan", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return
        End If

        ' 2. CEK APAKAH SEMUA PERTANYAAN SUDAH DIISI?
        For Each row As DataGridViewRow In dgvPertanyaan.Rows
            If row.IsNewRow Then Continue For

            Dim isi As String = ""
            If row.Cells(3).Value IsNot Nothing Then isi = row.Cells(3).Value.ToString()

            If isi = "" Then
                MessageBox.Show("Maaf, pertanyaan nomor " & row.Cells(0).Value & " belum diisi!", "Belum Lengkap", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                Return
            End If
        Next

        ' 3. KONFIRMASI KIRIM
        Dim tanya = MessageBox.Show("Apakah Anda yakin data sudah benar? Data yang sudah dikirim tidak dapat diubah lagi.", "Konfirmasi", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
        If tanya = DialogResult.No Then Return

        Try
            If Conn.State = ConnectionState.Closed Then Conn.Open()

            ' A. HAPUS DATA LAMA (Biar bersih)
            Dim sqlHapus As String = "DELETE FROM tr_penilaian WHERE username_penilai=@penilai AND target_dosen_nip=@nip AND periode=@per"
            cmd = New MySqlCommand(sqlHapus, Conn)
            cmd.Parameters.AddWithValue("@penilai", _namaUser)
            cmd.Parameters.AddWithValue("@nip", txtNip.Text)
            cmd.Parameters.AddWithValue("@per", cboPeriode.Text)
            cmd.ExecuteNonQuery()

            ' B. SIMPAN JAWABAN BARU
            For Each row As DataGridViewRow In dgvPertanyaan.Rows
                If row.IsNewRow Then Continue For

                Dim idTanya As String = row.Cells(0).Tag.ToString()
                Dim jawaban As String = row.Cells(3).Value.ToString()

                Dim query As String = "INSERT INTO tr_penilaian (id_pertanyaan, username_penilai, periode, nilai_skor, target_dosen_nip) VALUES (@id, @penilai, @per, @nilai, @nip)"
                cmd = New MySqlCommand(query, Conn)
                cmd.Parameters.AddWithValue("@id", idTanya)
                cmd.Parameters.AddWithValue("@penilai", _namaUser)
                cmd.Parameters.AddWithValue("@per", cboPeriode.Text)
                cmd.Parameters.AddWithValue("@nilai", jawaban)
                cmd.Parameters.AddWithValue("@nip", txtNip.Text)
                cmd.ExecuteNonQuery()
            Next

            ' C. UPDATE STATUS (Tandai selesai)
            UpdateStatusSelesai()

            MessageBox.Show("Data berhasil dikirim untuk verifikasi!", "Sukses")
            Me.Close()

        Catch ex As Exception
            MessageBox.Show("Gagal Kirim: " & ex.Message)
        End Try
    End Sub

    ' --- SUB UPDATE STATUS (Sama seperti sebelumnya) ---
    Private Sub UpdateStatusSelesai()
        ' Cek dulu apakah data di tabel status ada?
        Dim sqlCek As String = "SELECT count(*) FROM tr_status_penilaian WHERE nip=@nip AND periode=@per"
        cmd = New MySqlCommand(sqlCek, Conn)
        cmd.Parameters.AddWithValue("@nip", txtNip.Text)
        cmd.Parameters.AddWithValue("@per", cboPeriode.Text)

        Dim adaData As Integer = Convert.ToInt32(cmd.ExecuteScalar())

        ' Kalau belum ada di tabel status, insert baris baru
        If adaData = 0 Then
            Dim sqlInsert As String = "INSERT INTO tr_status_penilaian (nip, periode) VALUES (@nip, @per)"
            cmd = New MySqlCommand(sqlInsert, Conn)
            cmd.Parameters.AddWithValue("@nip", txtNip.Text)
            cmd.Parameters.AddWithValue("@per", cboPeriode.Text)
            cmd.ExecuteNonQuery()
        End If

        ' Update kolom status sesuai Role yang Login
        Dim sqlUpdate As String = ""
        Select Case _roleUser
            Case "Dosen"
                sqlUpdate = "UPDATE tr_status_penilaian SET status_dosen=1 WHERE nip=@nip AND periode=@per"
            Case "Admin"
                sqlUpdate = "UPDATE tr_status_penilaian SET status_admin=1 WHERE nip=@nip AND periode=@per"
            Case "KPS"
                sqlUpdate = "UPDATE tr_status_penilaian SET status_kps=1 WHERE nip=@nip AND periode=@per"
        End Select

        If sqlUpdate <> "" Then
            cmd = New MySqlCommand(sqlUpdate, Conn)
            cmd.Parameters.AddWithValue("@nip", txtNip.Text)
            cmd.Parameters.AddWithValue("@per", cboPeriode.Text)
            cmd.ExecuteNonQuery()
        End If
    End Sub

    Private Sub btnSimpanDraft_Click(sender As Object, e As EventArgs) Handles btnSimpanDraft.Click
        If cboNamaDosen.Text = "" Or txtNip.Text = "" Or txtNip.Text = "-" Then
            MessageBox.Show("Harap pilih Nama Dosen terlebih dahulu!", "Peringatan")
            Return
        End If

        Try
            If Conn.State = ConnectionState.Closed Then Conn.Open()

            ' A. HAPUS DULU JAWABAN LAMA (Biar tidak duplikat saat simpan ulang)
            ' Hapus jawaban milik penilai ini, untuk dosen ini, di periode ini
            Dim sqlHapus As String = "DELETE FROM tr_penilaian WHERE username_penilai=@penilai AND target_dosen_nip=@nip AND periode=@per"
            cmd = New MySqlCommand(sqlHapus, Conn)
            cmd.Parameters.AddWithValue("@penilai", _namaUser)
            cmd.Parameters.AddWithValue("@nip", txtNip.Text)
            cmd.Parameters.AddWithValue("@per", cboPeriode.Text)
            cmd.ExecuteNonQuery()

            ' B. SIMPAN JAWABAN BARU (LOOPING)
            For Each row As DataGridViewRow In dgvPertanyaan.Rows
                If row.IsNewRow Then Continue For

                ' Ambil data
                Dim idTanya As String = row.Cells(0).Tag.ToString()
                Dim jawaban As String = ""
                If row.Cells(3).Value IsNot Nothing Then jawaban = row.Cells(3).Value.ToString()

                ' Insert Jawaban (Walaupun kosong tetap disimpan sebagai draft)
                Dim query As String = "INSERT INTO tr_penilaian (id_pertanyaan, username_penilai, periode, nilai_skor, target_dosen_nip) VALUES (@id, @penilai, @per, @nilai, @nip)"

                cmd = New MySqlCommand(query, Conn)
                cmd.Parameters.AddWithValue("@id", idTanya)
                cmd.Parameters.AddWithValue("@penilai", _namaUser)
                cmd.Parameters.AddWithValue("@per", cboPeriode.Text)
                cmd.Parameters.AddWithValue("@nilai", jawaban)
                cmd.Parameters.AddWithValue("@nip", txtNip.Text)
                cmd.ExecuteNonQuery()
            Next

            MessageBox.Show("Draft berhasil disimpan. Anda bisa melanjutkannya nanti.", "Draft Tersimpan")

            ' Form JANGAN ditutup, siapa tau mau lanjut ngisi
        Catch ex As Exception
            MessageBox.Show("Gagal Simpan Draft: " & ex.Message)
        End Try
    End Sub

    Private Sub cboPeriode_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cboPeriode.SelectedIndexChanged

    End Sub
End Class