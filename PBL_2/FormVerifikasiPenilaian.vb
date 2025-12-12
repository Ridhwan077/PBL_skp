Imports MySql.Data.MySqlClient
Imports System.IO

Public Class FormVerifikasiPenilaian

    Private currentNip As String = ""
    Private currentPeriode As String = ""

    ' =========================================================
    ' FORM LOAD
    ' =========================================================
    Private Sub FormVerifikasiPenilaian_Load(sender As Object, e As EventArgs) _
        Handles MyBase.Load

        Me.Font = New Font("Segoe UI", 9.0F, FontStyle.Regular, GraphicsUnit.Point)

        ' Auto-size baris & wrap teks indikator
        dgvVerifikasi.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells
        dgvVerifikasi.DefaultCellStyle.WrapMode = DataGridViewTriState.True
        colIndikator.DefaultCellStyle.WrapMode = DataGridViewTriState.True
        colIndikator.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill

        colNo.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
        colAspek.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
        colNilaiDosen.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
        colNilaiPenilai.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
        colStatus.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
        colBukti.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
        colPenilai.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells

        colBukti.UseColumnTextForButtonValue = True

        LoadPeriodeList()
    End Sub

    ' =========================================================
    ' LOAD PERIODE & DOSEN
    ' =========================================================
    Private Sub LoadPeriodeList()
        Try
            Koneksi()

            Dim sql As String =
                "SELECT DISTINCT periode " &
                "FROM tr_penilaian " &
                "WHERE periode IS NOT NULL AND periode <> '' " &
                "ORDER BY periode DESC"

            Using cmd As New MySqlCommand(sql, Conn)
                Using rd = cmd.ExecuteReader()
                    cboPeriode.Items.Clear()
                    While rd.Read()
                        cboPeriode.Items.Add(rd("periode").ToString())
                    End While
                End Using
            End Using

            If cboPeriode.Items.Count > 0 Then
                ' Kalau CurrentPeriode ada di list, pakai itu
                If Not String.IsNullOrEmpty(currentPeriode) AndAlso
                   cboPeriode.Items.Contains(currentPeriode) Then
                    cboPeriode.SelectedItem = currentPeriode
                Else
                    cboPeriode.SelectedIndex = 0
                End If
            End If

        Catch ex As Exception
            MessageBox.Show("Gagal memuat daftar periode: " & ex.Message,
                            "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub cboPeriode_SelectedIndexChanged(sender As Object, e As EventArgs) _
        Handles cboPeriode.SelectedIndexChanged

        If cboPeriode.SelectedIndex < 0 Then Return
        currentPeriode = cboPeriode.SelectedItem.ToString()
        LoadDosenUntukPeriode()
    End Sub

    Private Sub LoadDosenUntukPeriode()
        If String.IsNullOrEmpty(currentPeriode) Then Return

        Try
            Koneksi()

            Dim sql As String =
                "SELECT DISTINCT d.nip, d.nama, d.prodi " &
                "FROM tr_penilaian p " &
                "JOIN dosen d ON d.nip = p.target_dosen_nip " &
                "WHERE p.periode = @periode " &
                "ORDER BY d.nama"

            Using cmd As New MySqlCommand(sql, Conn)
                cmd.Parameters.AddWithValue("@periode", currentPeriode)

                Using da As New MySqlDataAdapter(cmd)
                    Dim dt As New DataTable()
                    da.Fill(dt)

                    cboNamaDosen.DataSource = Nothing
                    cboNamaDosen.Items.Clear()

                    If dt.Rows.Count > 0 Then
                        cboNamaDosen.DataSource = dt
                        cboNamaDosen.DisplayMember = "nama"
                        cboNamaDosen.ValueMember = "nip"
                    End If
                End Using
            End Using

            If cboNamaDosen.Items.Count > 0 Then
                cboNamaDosen.SelectedIndex = 0
            Else
                dgvVerifikasi.Rows.Clear()
                txtNip.Clear()
                txtProdi.Clear()
            End If

        Catch ex As Exception
            MessageBox.Show("Gagal memuat daftar dosen: " & ex.Message,
                            "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub cboNamaDosen_SelectedIndexChanged(sender As Object, e As EventArgs) _
        Handles cboNamaDosen.SelectedIndexChanged

        If cboNamaDosen.SelectedIndex < 0 Then Return
        Dim drv As DataRowView = TryCast(cboNamaDosen.SelectedItem, DataRowView)
        If drv Is Nothing Then Return

        currentNip = drv("nip").ToString()
        txtNip.Text = currentNip
        txtProdi.Text = drv("prodi").ToString()

        LoadDataVerifikasi()
    End Sub

    ' =========================================================
    ' LOAD DATA VERIFIKASI DARI tr_penilaian
    ' =========================================================
    Private Sub LoadDataVerifikasi()
        dgvVerifikasi.Rows.Clear()
        If String.IsNullOrEmpty(currentNip) OrElse String.IsNullOrEmpty(currentPeriode) Then Return

        Try
            Koneksi()

            Dim sql As String =
                "SELECT " &
                "  mp.id          AS id_pertanyaan, " &
                "  mp.aspek, " &
                "  mp.pertanyaan, " &
                "  MAX(CASE WHEN u.role = 'Dosen' THEN CAST(p.nilai_skor AS DECIMAL(10,2)) END) AS nilai_dosen, " &
                "  MAX(CASE WHEN u.role <> 'Dosen' THEN CAST(p.nilai_skor AS DECIMAL(10,2)) END) AS nilai_penilai_awal, " &
                "  GROUP_CONCAT(DISTINCT CONCAT(u.username,' (',u.role,')') SEPARATOR ', ') AS penilai, " &
                "  MAX(CASE WHEN p.bukti_pendukung IS NOT NULL AND p.bukti_pendukung <> '' " &
                "      THEN p.bukti_pendukung END) AS bukti_path " &
                "FROM tr_penilaian p " &
                "JOIN ms_pertanyaan mp ON mp.id = p.id_pertanyaan " &
                "JOIN users u ON u.username = p.username_penilai " &
                "WHERE p.target_dosen_nip = @nip AND p.periode = @periode " &
                "GROUP BY mp.id, mp.aspek, mp.pertanyaan " &
                "ORDER BY mp.id"

            Using cmd As New MySqlCommand(sql, Conn)
                cmd.Parameters.AddWithValue("@nip", currentNip)
                cmd.Parameters.AddWithValue("@periode", currentPeriode)

                Using da As New MySqlDataAdapter(cmd)
                    Dim dt As New DataTable()
                    da.Fill(dt)

                    Dim nomor As Integer = 1
                    For Each dr As DataRow In dt.Rows
                        Dim idx As Integer = dgvVerifikasi.Rows.Add()
                        Dim row As DataGridViewRow = dgvVerifikasi.Rows(idx)

                        row.Cells("colNo").Value = nomor
                        row.Cells("colAspek").Value = dr("aspek").ToString()
                        row.Cells("colIndikator").Value = dr("pertanyaan").ToString()

                        If Not IsDBNull(dr("nilai_dosen")) Then
                            row.Cells("colNilaiDosen").Value = Convert.ToDouble(dr("nilai_dosen")).ToString("0.##")
                        Else
                            row.Cells("colNilaiDosen").Value = ""
                        End If

                        If Not IsDBNull(dr("nilai_penilai_awal")) Then
                            row.Cells("colNilaiPenilai").Value = Convert.ToDouble(dr("nilai_penilai_awal")).ToString("0.##")
                        Else
                            row.Cells("colNilaiPenilai").Value = ""
                        End If

                        row.Cells("colStatus").Value = "Disetujui"  ' default
                        row.Cells("colCatatan").Value = ""
                        row.Cells("colPenilai").Value = dr("penilai").ToString()

                        ' Simpan id_pertanyaan & bukti di Tag
                        row.Tag = Convert.ToInt32(dr("id_pertanyaan"))
                        row.Cells("colBukti").Tag = If(IsDBNull(dr("bukti_path")), Nothing, dr("bukti_path").ToString())

                        nomor += 1
                    Next
                End Using
            End Using

            ' Cek apakah sudah pernah final
            If IsSudahFinal(currentNip, currentPeriode) Then
                dgvVerifikasi.ReadOnly = True
                btnSetFinal.Enabled = False
                btnSimpan.Enabled = False
                MessageBox.Show("Penilaian untuk dosen dan periode ini sudah berstatus FINAL.",
                                "Informasi", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Else
                dgvVerifikasi.ReadOnly = False
                dgvVerifikasi.Columns("colNo").ReadOnly = True
                dgvVerifikasi.Columns("colAspek").ReadOnly = True
                dgvVerifikasi.Columns("colIndikator").ReadOnly = True
                dgvVerifikasi.Columns("colNilaiDosen").ReadOnly = True
                dgvVerifikasi.Columns("colPenilai").ReadOnly = True
            End If

        Catch ex As Exception
            MessageBox.Show("Gagal memuat data verifikasi: " & ex.Message,
                            "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Function IsSudahFinal(nip As String, periode As String) As Boolean
        Try
            Koneksi()

            Dim sql As String =
                "SELECT status_kps " &
                "FROM tr_status_penilaian " &
                "WHERE nip = @nip AND periode = @periode " &
                "LIMIT 1"

            Using cmd As New MySqlCommand(sql, Conn)
                cmd.Parameters.AddWithValue("@nip", nip)
                cmd.Parameters.AddWithValue("@periode", periode)

                Dim obj = cmd.ExecuteScalar()
                If obj Is Nothing OrElse IsDBNull(obj) Then
                    Return False
                End If

                Dim val As Integer = Convert.ToInt32(obj)
                Return (val = 1)
            End Using

        Catch
            Return False
        End Try
    End Function

    ' =========================================================
    ' AKSI GRID: LIHAT BUKTI
    ' =========================================================
    Private Sub dgvVerifikasi_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) _
        Handles dgvVerifikasi.CellContentClick

        If e.RowIndex < 0 Then Return
        If dgvVerifikasi.Columns(e.ColumnIndex).Name <> "colBukti" Then Return

        Dim cell = dgvVerifikasi.Rows(e.RowIndex).Cells("colBukti")
        Dim path As String = TryCast(cell.Tag, String)

        If String.IsNullOrEmpty(path) Then
            MessageBox.Show("Belum ada bukti pendukung yang tersimpan untuk indikator ini.",
                            "Informasi", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Return
        End If

        Try
            If File.Exists(path) Then
                Process.Start(New ProcessStartInfo(path) With {.UseShellExecute = True})
            Else
                MessageBox.Show("File bukti tidak ditemukan di lokasi: " & path,
                                "Informasi", MessageBoxButtons.OK, MessageBoxIcon.Information)
            End If
        Catch ex As Exception
            MessageBox.Show("Gagal membuka file bukti: " & ex.Message,
                            "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    ' =========================================================
    ' BUTTON: TUTUP / SIMPAN DRAFT / SET FINAL
    ' =========================================================
    Private Sub btnTutup_Click(sender As Object, e As EventArgs) Handles btnTutup.Click
        Me.Close()
    End Sub

    ' Draft → di contoh ini tidak menyimpan ke DB, hanya placeholder
    Private Sub btnSimpan_Click(sender As Object, e As EventArgs) Handles btnSimpan.Click
        MessageBox.Show("Draft verifikasi belum disimpan ke database (tidak ada kolom detail verifikasi per pertanyaan). " &
                        "Jika ingin menyimpan detail per-pertanyaan, tambahkan kolom di tabel atau buat tabel baru khusus verifikasi.",
                        "Informasi", MessageBoxButtons.OK, MessageBoxIcon.Information)
    End Sub

    Private Sub btnSetFinal_Click(sender As Object, e As EventArgs) Handles btnSetFinal.Click
        If String.IsNullOrEmpty(currentNip) OrElse String.IsNullOrEmpty(currentPeriode) Then
            MessageBox.Show("Pilih dosen dan periode terlebih dahulu.",
                            "Validasi", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return
        End If

        If dgvVerifikasi.Rows.Count = 0 Then
            MessageBox.Show("Tidak ada data penilaian untuk diverifikasi.",
                            "Validasi", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return
        End If

        ' Validasi nilai penilai dan kumpulkan sebagai skor KPS
        Dim listNilaiKps As New List(Of Double)()
        For Each row As DataGridViewRow In dgvVerifikasi.Rows
            Dim valObj = row.Cells("colNilaiPenilai").Value
            If valObj Is Nothing OrElse valObj.ToString().Trim() = "" Then
                MessageBox.Show("Masih ada indikator yang belum diisi Nilai Penilai.",
                                "Validasi", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                dgvVerifikasi.CurrentCell = row.Cells("colNilaiPenilai")
                dgvVerifikasi.BeginEdit(True)
                Return
            End If

            Dim d As Double
            If Not Double.TryParse(valObj.ToString(), d) Then
                MessageBox.Show("Nilai Penilai harus berupa angka.",
                                "Validasi", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                dgvVerifikasi.CurrentCell = row.Cells("colNilaiPenilai")
                dgvVerifikasi.BeginEdit(True)
                Return
            End If

            listNilaiKps.Add(d)
        Next

        ' Hitung skor rata-rata Self dan Admin dari tr_penilaian
        Dim avgSelf As Double = GetAverageNilaiByRole("Dosen", currentNip, currentPeriode)
        Dim avgAdmin As Double = GetAverageNilaiByRole("Admin", currentNip, currentPeriode)

        If avgSelf = 0 AndAlso avgAdmin = 0 Then
            MessageBox.Show("Tidak ditemukan data penilaian dari Dosen/Admin di tr_penilaian untuk dosen dan periode ini.",
                            "Validasi", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return
        End If

        Dim avgKps As Double = 0
        If listNilaiKps.Count > 0 Then
            Dim sum As Double = 0
            For Each d In listNilaiKps
                sum += d
            Next
            avgKps = sum / listNilaiKps.Count
        End If

        ' --- Perhitungan DST ---
        Dim mFinal As DSTCalculator.BPA = DSTCalculator.CalculateFinalDecision(avgSelf, avgAdmin, avgKps)
        Dim predikat As String = DSTCalculator.DecideLabel(mFinal)

        ' Mapping sederhana AE/SE/BE → 3/2/1
        Dim nilaiAkhir As Double
        If mFinal.AE > mFinal.SE AndAlso mFinal.AE > mFinal.BE Then
            nilaiAkhir = 3.0
        ElseIf mFinal.SE >= mFinal.AE AndAlso mFinal.SE >= mFinal.BE Then
            nilaiAkhir = 2.0
        Else
            nilaiAkhir = 1.0
        End If

        ' Simpan ke tr_status_penilaian
        Try
            Koneksi()

            Using tran = Conn.BeginTransaction()
                SimpanStatusPenilaian(tran, currentNip, currentPeriode, nilaiAkhir, predikat)
                tran.Commit()
            End Using

            MessageBox.Show("Nilai FINAL berhasil disimpan." & Environment.NewLine &
                            "Nilai Akhir: " & nilaiAkhir.ToString("0.##") & Environment.NewLine &
                            "Predikat : " & predikat,
                            "Sukses", MessageBoxButtons.OK, MessageBoxIcon.Information)

            dgvVerifikasi.ReadOnly = True
            btnSetFinal.Enabled = False
            btnSimpan.Enabled = False

        Catch ex As Exception
            MessageBox.Show("Terjadi kesalahan saat menyimpan nilai final: " & ex.Message,
                            "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    ' =========================================================
    ' HELPER: RATA-RATA NILAI BERDASARKAN ROLE
    ' =========================================================
    Private Function GetAverageNilaiByRole(roleName As String,
                                           nip As String,
                                           periode As String) As Double
        Try
            Koneksi()

            Dim sql As String =
                "SELECT AVG(CAST(p.nilai_skor AS DECIMAL(10,2))) AS avg_score " &
                "FROM tr_penilaian p " &
                "JOIN users u ON u.username = p.username_penilai " &
                "WHERE p.target_dosen_nip = @nip " &
                "  AND p.periode = @periode " &
                "  AND u.role = @role"

            Using cmd As New MySqlCommand(sql, Conn)
                cmd.Parameters.AddWithValue("@nip", nip)
                cmd.Parameters.AddWithValue("@periode", periode)
                cmd.Parameters.AddWithValue("@role", roleName)

                Dim obj = cmd.ExecuteScalar()
                If obj Is Nothing OrElse IsDBNull(obj) Then
                    Return 0
                End If
                Return Convert.ToDouble(obj)
            End Using

        Catch
            Return 0
        End Try
    End Function

    ' =========================================================
    ' HELPER: UPSERT tr_status_penilaian
    ' =========================================================
    Private Sub SimpanStatusPenilaian(tran As MySqlTransaction,
                                      nip As String,
                                      periode As String,
                                      nilaiAkhir As Double,
                                      predikat As String)

        Dim existingId As Integer = 0

        Using cmdCheck As New MySqlCommand()
            cmdCheck.Connection = tran.Connection
            cmdCheck.Transaction = tran
            cmdCheck.CommandText =
                "SELECT id FROM tr_status_penilaian " &
                "WHERE nip = @nip AND periode = @periode " &
                "LIMIT 1"
            cmdCheck.Parameters.AddWithValue("@nip", nip)
            cmdCheck.Parameters.AddWithValue("@periode", periode)

            Dim obj = cmdCheck.ExecuteScalar()
            If obj IsNot Nothing AndAlso Not IsDBNull(obj) Then
                existingId = Convert.ToInt32(obj)
            End If
        End Using

        If existingId = 0 Then
            ' Insert baru
            Using cmdInsert As New MySqlCommand()
                cmdInsert.Connection = tran.Connection
                cmdInsert.Transaction = tran
                cmdInsert.CommandText =
                    "INSERT INTO tr_status_penilaian " &
                    "(nip, periode, status_dosen, status_admin, status_kps, nilai_akhir, predikat) " &
                    "VALUES (@nip, @periode, @sd, @sa, @sk, @nilai, @pred)"
                cmdInsert.Parameters.AddWithValue("@nip", nip)
                cmdInsert.Parameters.AddWithValue("@periode", periode)
                cmdInsert.Parameters.AddWithValue("@sd", 1) ' diasumsikan sudah diisi
                cmdInsert.Parameters.AddWithValue("@sa", 1)
                cmdInsert.Parameters.AddWithValue("@sk", 1)
                cmdInsert.Parameters.AddWithValue("@nilai", nilaiAkhir)
                cmdInsert.Parameters.AddWithValue("@pred", predikat)
                cmdInsert.ExecuteNonQuery()
            End Using
        Else
            ' Update existing
            Using cmdUpd As New MySqlCommand()
                cmdUpd.Connection = tran.Connection
                cmdUpd.Transaction = tran
                cmdUpd.CommandText =
                    "UPDATE tr_status_penilaian " &
                    "SET status_kps = 1, nilai_akhir = @nilai, predikat = @pred " &
                    "WHERE id = @id"
                cmdUpd.Parameters.AddWithValue("@id", existingId)
                cmdUpd.Parameters.AddWithValue("@nilai", nilaiAkhir)
                cmdUpd.Parameters.AddWithValue("@pred", predikat)
                cmdUpd.ExecuteNonQuery()
            End Using
        End If
    End Sub

End Class
