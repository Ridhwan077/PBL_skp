Imports MySql.Data.MySqlClient

Partial Public Class FormLihatNilai

    Private _nipDosen As String = ""

    ' =========================================================
    ' FORM LOAD
    ' =========================================================
    Private Sub FormLihatNilai_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Try
            Me.Text = "Laporan Kinerja Dosen"

            ' Reset tampilan awal
            lblNIP.Text = "-"
            lblNamaDosen.Text = "-"
            lblProgramStudi.Text = "-"
            lblStatus.Text = "-"
            lblScore.Text = "0.00"
            lblPredikat.Text = "-"

            ' 1. Ambil identitas dosen dari tabel DOSEN (berdasar CurrentUserId)
            LoadIdentitasDosen()

            ' 2. Isi daftar periode yang tersedia di tr_status_penilaian
            If Not String.IsNullOrEmpty(_nipDosen) Then
                LoadPeriodeUntukDosen(_nipDosen)
            End If

        Catch ex As Exception
            MessageBox.Show("Gagal memuat form Lihat Nilai:" & Environment.NewLine & ex.Message,
                            "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    ' =========================================================
    ' LOAD IDENTITAS DOSEN
    ' =========================================================
    Private Sub LoadIdentitasDosen()
        Try
            Koneksi()

            Dim sql As String =
                "SELECT nip, nama, prodi " &
                "FROM dosen " &
                "WHERE user_id = @uid " &
                "LIMIT 1"

            Using cmd As New MySqlCommand(sql, Conn)
                cmd.Parameters.AddWithValue("@uid", CurrentUserId)

                Using rd = cmd.ExecuteReader()
                    If rd.Read() Then
                        _nipDosen = rd("nip").ToString()

                        lblNIP.Text = _nipDosen
                        lblNamaDosen.Text = rd("nama").ToString()
                        lblProgramStudi.Text = rd("prodi").ToString()
                    Else
                        MessageBox.Show("Data dosen untuk user ini tidak ditemukan.",
                                        "Informasi", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    End If
                End Using
            End Using

        Catch ex As Exception
            MessageBox.Show("Gagal memuat identitas dosen:" & Environment.NewLine & ex.Message,
                            "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    ' =========================================================
    ' LOAD PERIODE DARI tr_status_penilaian
    ' =========================================================
    Private Sub LoadPeriodeUntukDosen(nip As String)
        Try
            Koneksi()

            Dim sql As String =
                "SELECT DISTINCT periode " &
                "FROM tr_status_penilaian " &
                "WHERE nip = @nip " &
                "ORDER BY periode"

            Using cmd As New MySqlCommand(sql, Conn)
                cmd.Parameters.AddWithValue("@nip", nip)

                Using rd = cmd.ExecuteReader()
                    cboPeriode.Items.Clear()

                    While rd.Read()
                        Dim p As String = rd("periode").ToString()
                        If Not String.IsNullOrWhiteSpace(p) Then
                            cboPeriode.Items.Add(p)
                        End If
                    End While
                End Using
            End Using

            ' Optional: jika CurrentPeriode ada di list → auto pilih
            If cboPeriode.Items.Count > 0 Then
                Dim idx As Integer = -1
                If Not String.IsNullOrEmpty(CurrentPeriode) Then
                    idx = cboPeriode.Items.IndexOf(CurrentPeriode)
                End If

                If idx >= 0 Then
                    cboPeriode.SelectedIndex = idx
                Else
                    cboPeriode.SelectedIndex = 0
                End If
            End If

        Catch ex As Exception
            MessageBox.Show("Gagal memuat daftar periode:" & Environment.NewLine & ex.Message,
                            "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    ' =========================================================
    ' TOMBOL "LIHAT HASIL"
    ' =========================================================
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        If String.IsNullOrEmpty(_nipDosen) Then
            MessageBox.Show("NIP dosen tidak ditemukan. Silakan cek data dosen terlebih dahulu.",
                            "Validasi", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return
        End If

        If cboPeriode.SelectedIndex < 0 Then
            MessageBox.Show("Silakan pilih periode terlebih dahulu.",
                            "Validasi", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            cboPeriode.DroppedDown = True
            Return
        End If

        Dim periode As String = cboPeriode.SelectedItem.ToString()
        TampilkanHasilStatus(_nipDosen, periode)
    End Sub

    ' =========================================================
    ' AMBIL DATA tr_status_penilaian & TAMPILKAN
    ' =========================================================
    Private Sub TampilkanHasilStatus(nip As String, periode As String)
        Try
            Koneksi()

            Dim sql As String =
                "SELECT status_dosen, status_admin, status_kps, " &
                "       nilai_akhir, predikat " &
                "FROM tr_status_penilaian " &
                "WHERE nip = @nip AND periode = @periode " &
                "LIMIT 1"

            Using cmd As New MySqlCommand(sql, Conn)
                cmd.Parameters.AddWithValue("@nip", nip)
                cmd.Parameters.AddWithValue("@periode", periode)

                Using rd = cmd.ExecuteReader()
                    If rd.Read() Then
                        ' Status
                        Dim sDosen As Integer = If(IsDBNull(rd("status_dosen")), 0, Convert.ToInt32(rd("status_dosen")))
                        Dim sAdmin As Integer = If(IsDBNull(rd("status_admin")), 0, Convert.ToInt32(rd("status_admin")))
                        Dim sKps As Integer = If(IsDBNull(rd("status_kps")), 0, Convert.ToInt32(rd("status_kps")))

                        lblStatus.Text = GetStatusText(sDosen, sAdmin, sKps)

                        ' Nilai akhir
                        If IsDBNull(rd("nilai_akhir")) Then
                            lblScore.Text = "0.00"
                        Else
                            Dim nilai As Double = Convert.ToDouble(rd("nilai_akhir"))
                            lblScore.Text = nilai.ToString("0.00")
                        End If

                        ' Predikat
                        If IsDBNull(rd("predikat")) Then
                            lblPredikat.Text = "-"
                        Else
                            lblPredikat.Text = rd("predikat").ToString()
                        End If
                    Else
                        MessageBox.Show("Belum ada data status penilaian untuk periode yang dipilih.",
                                        "Informasi", MessageBoxButtons.OK, MessageBoxIcon.Information)

                        lblStatus.Text = "-"
                        lblScore.Text = "0.00"
                        lblPredikat.Text = "-"
                    End If
                End Using
            End Using

        Catch ex As Exception
            MessageBox.Show("Gagal mengambil hasil penilaian:" & Environment.NewLine & ex.Message,
                            "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    ' =========================================================
    ' KONVERSI STATUS INT → TEKS STATUS
    ' (Silakan sesuaikan mapping dengan aturan status di sistem Anda)
    ' =========================================================
    Private Function GetStatusText(statusDosen As Integer,
                                   statusAdmin As Integer,
                                   statusKps As Integer) As String

        ' Contoh mapping:
        ' 0 = belum ada / draft
        ' 1 = diajukan / menunggu verifikasi
        ' 2 = disetujui / final

        If statusKps >= 2 Then
            Return "Sah (Final oleh KPS)"
        ElseIf statusKps = 1 OrElse statusAdmin >= 1 Then
            Return "Dalam proses verifikasi"
        ElseIf statusDosen >= 1 Then
            Return "Diajukan, menunggu verifikasi"
        Else
            Return "Belum ada penilaian"
        End If
    End Function

End Class
