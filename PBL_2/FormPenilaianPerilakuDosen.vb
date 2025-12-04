Imports System.Drawing.Printing
Imports System.IO
Imports System.Reflection.Metadata
Imports System.Windows.Forms.VisualStyles.VisualStyleElement.ProgressBar
Imports iTextSharp.text
Imports iTextSharp.text.pdf
Imports MySql.Data.MySqlClient
Imports Document = iTextSharp.text.Document
Imports PdfFont = iTextSharp.text.Font
Imports WinFont = System.Drawing.Font

Public Class FormPenilaianPerilakuDosen

    Private Const PEJABAT_NAMA As String = " Dr. ANITA HIDAYATI, S.Kom., M.Kom"
    Private Const PEJABAT_NIP As String = "197908032003122003"
    Private Const PEJABAT_JABATAN As String = "Lektor / Ketuajurusan Teknik Informatika dan Komputer"
    Private Const PEJABAT_UNIT As String = " Politeknik Negeri Jakarta"
    Private ReadOnly buktiFiles As New Dictionary(Of Integer, String)

    Private dtPertanyaan As DataTable

    Private Sub FormPenilaianPerilakuDosen_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ' Layout grid pertanyaan agar cocok untuk teks panjang
        dgvPertanyaan.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells
        colPertanyaan.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
        colPertanyaan.MinimumWidth = 360

        Me.Font = New WinFont("Segoe UI", 9.0F, FontStyle.Regular, GraphicsUnit.Point)
        colBukti.UseColumnTextForButtonValue = False

        SetupHeader()
        LoadPertanyaanUntukRole()
    End Sub

    ' =========================================================
    ' HEADER: DOSEN vs ROLE LAIN
    ' =========================================================

    Private Sub SetupHeader()
        Dim roleNorm = CurrentUserRole.Trim().ToLower()

        If roleNorm = "dosen" Then
            LoadHeaderUntukDosenSendiri()
        Else
            LoadHeaderUntukPenilaiLain()
        End If
    End Sub

    ' --- jika login sebagai DOSEN: auto isi, tidak bisa pilih dosen lain ---
    Private Sub LoadHeaderUntukDosenSendiri()
        Try
            Koneksi()

            Dim sql As String =
                "SELECT nip, nama, prodi, periode " &
                "FROM dosen " &
                "WHERE user_id = @uid " &
                "LIMIT 1"

            Using cmd As New MySqlCommand(sql, Conn)
                cmd.Parameters.AddWithValue("@uid", CurrentUserId)

                Using rd = cmd.ExecuteReader()
                    If rd.Read() Then
                        ' Nama
                        cboNamaDosen.Items.Clear()
                        cboNamaDosen.Items.Add(rd("nama").ToString())
                        cboNamaDosen.SelectedIndex = 0
                        cboNamaDosen.Enabled = False

                        ' NIP
                        txtNip.Text = rd("nip").ToString()
                        txtNip.ReadOnly = True

                        ' Prodi
                        cboProgramStudi.Items.Clear()
                        cboProgramStudi.Items.Add(rd("prodi").ToString())
                        cboProgramStudi.SelectedIndex = 0
                        cboProgramStudi.Enabled = False

                        ' Periode: dari dosen, kalau kosong pakai CurrentPeriode
                        cboPeriode.Items.Clear()
                        Dim periodeVal As String = ""

                        If Not IsDBNull(rd("periode")) AndAlso rd("periode").ToString() <> "" Then
                            periodeVal = rd("periode").ToString()
                        ElseIf Not String.IsNullOrEmpty(CurrentPeriode) Then
                            periodeVal = CurrentPeriode
                        End If

                        If periodeVal <> "" Then
                            cboPeriode.Items.Add(periodeVal)
                            cboPeriode.SelectedIndex = 0
                        End If
                        cboPeriode.Enabled = False
                    Else
                        MessageBox.Show("Data dosen untuk user ini tidak ditemukan di tabel dosen.",
                                        "Informasi", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    End If
                End Using
            End Using

        Catch ex As Exception
            MessageBox.Show("Gagal memuat data dosen: " & ex.Message,
                            "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    ' --- jika login sebagai ADMIN / KPS / PIMPINAN: bisa memilih dosen ---
    Private Sub LoadHeaderUntukPenilaiLain()
        Try
            Koneksi()

            ' 1. Isi list prodi
            Dim sqlProdi As String = "SELECT DISTINCT prodi FROM dosen ORDER BY prodi"

            Using cmd As New MySqlCommand(sqlProdi, Conn)
                Using rd = cmd.ExecuteReader()
                    cboProgramStudi.Items.Clear()
                    While rd.Read()
                        cboProgramStudi.Items.Add(rd("prodi").ToString())
                    End While
                End Using
            End Using

            If cboProgramStudi.Items.Count > 0 Then
                cboProgramStudi.SelectedIndex = 0   ' akan memicu load nama dosen
            End If

            ' 2. Periode → pakai CurrentPeriode kalau ada
            cboPeriode.Items.Clear()
            If Not String.IsNullOrEmpty(CurrentPeriode) Then
                cboPeriode.Items.Add(CurrentPeriode)
                cboPeriode.SelectedIndex = 0
            End If

        Catch ex As Exception
            MessageBox.Show("Gagal memuat header penilaian: " & ex.Message,
                            "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    ' Saat Prodi diganti → reload daftar dosen (untuk non-dosen)
    Private Sub cboProgramStudi_SelectedIndexChanged(sender As Object, e As EventArgs) _
        Handles cboProgramStudi.SelectedIndexChanged

        If CurrentUserRole.Trim().ToLower() = "dosen" Then Return
        If cboProgramStudi.SelectedIndex < 0 Then Return

        Try
            Koneksi()

            Dim sql As String =
                "SELECT nama, nip FROM dosen " &
                "WHERE prodi = @prodi " &
                "ORDER BY nama"

            Using cmd As New MySqlCommand(sql, Conn)
                cmd.Parameters.AddWithValue("@prodi", cboProgramStudi.SelectedItem.ToString())

                Using rd = cmd.ExecuteReader()
                    cboNamaDosen.Items.Clear()
                    While rd.Read()
                        cboNamaDosen.Items.Add(rd("nama").ToString())
                    End While
                End Using
            End Using

            If cboNamaDosen.Items.Count > 0 Then
                cboNamaDosen.SelectedIndex = 0
            End If

        Catch ex As Exception
            MessageBox.Show("Gagal memuat daftar dosen: " & ex.Message,
                            "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    ' Saat Nama Dosen diganti → isi NIP (untuk non-dosen)
    Private Sub cboNamaDosen_SelectedIndexChanged(sender As Object, e As EventArgs) _
        Handles cboNamaDosen.SelectedIndexChanged

        If CurrentUserRole.Trim().ToLower() = "dosen" Then Return
        If cboNamaDosen.SelectedIndex < 0 Then Return

        Try
            Koneksi()

            Dim sql As String =
                "SELECT nip FROM dosen " &
                "WHERE nama = @nama " &
                "LIMIT 1"

            Using cmd As New MySqlCommand(sql, Conn)
                cmd.Parameters.AddWithValue("@nama", cboNamaDosen.SelectedItem.ToString())
                Dim result = cmd.ExecuteScalar()
                If result IsNot Nothing Then
                    txtNip.Text = result.ToString()
                End If
            End Using

        Catch ex As Exception
            MessageBox.Show("Gagal memuat NIP dosen: " & ex.Message,
                            "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    ' =========================================================
    ' PERTANYAAN DARI ms_pertanyaan (dengan tipe_input "proaktif")
    ' =========================================================

    Private Sub LoadPertanyaanUntukRole()
        Try
            Koneksi()

            Dim sql As String =
                "SELECT id, aspek, pertanyaan, tipe_input " &
                "FROM ms_pertanyaan " &
                "WHERE target_role = @role " &
                "ORDER BY id"

            Using cmd As New MySqlCommand(sql, Conn)
                cmd.Parameters.AddWithValue("@role", CurrentUserRole)

                Using da As New MySqlDataAdapter(cmd)
                    dtPertanyaan = New DataTable()
                    da.Fill(dtPertanyaan)
                End Using
            End Using

            dgvPertanyaan.Rows.Clear()

            Dim nomor As Integer = 1

            For i As Integer = 0 To dtPertanyaan.Rows.Count - 1
                Dim dr = dtPertanyaan.Rows(i)
                Dim idx = dgvPertanyaan.Rows.Add()
                Dim row = dgvPertanyaan.Rows(idx)

                row.Cells("colNo").Value = nomor
                row.Cells("colAspek").Value = dr("aspek").ToString()
                row.Cells("colPertanyaan").Value = dr("pertanyaan").ToString()

                ' === set pilihan skor per baris ===
                Dim tipe As String = ""
                If Not IsDBNull(dr("tipe_input")) Then
                    tipe = dr("tipe_input").ToString().Trim().ToLower()
                End If

                Dim teksPertanyaan As String = dr("pertanyaan").ToString().Trim().ToLower()

                Dim cellSkor = DirectCast(row.Cells("colSkor"), DataGridViewComboBoxCell)
                cellSkor.Items.Clear()

                ' Kita anggap proaktif jika:
                ' - tipe_input = 'proaktif'
                '   ATAU
                ' - teks pertanyaan mengandung kata "proaktif"
                If tipe = "proaktif" OrElse teksPertanyaan.Contains("proaktif") Then
                    cellSkor.Items.Add("Tidak mengusulkan")
                    cellSkor.Items.Add("Mengusulkan proposal")
                    cellSkor.Items.Add("Menyusun proposal")
                Else
                    ' fallback umum: 1–10
                    For n As Integer = 1 To 10
                        cellSkor.Items.Add(n.ToString())
                    Next
                End If

                row.Cells("colSkor").Value = Nothing
                row.Cells("colCatatan").Value = ""

                ' simpan ID pertanyaan di Tag
                row.Tag = CInt(dr("id"))
                row.Cells("colBukti").Value = "Upload File"

                nomor += 1
            Next

            For Each col As DataGridViewColumn In dgvPertanyaan.Columns
                col.SortMode = DataGridViewColumnSortMode.NotSortable
            Next

        Catch ex As Exception
            MessageBox.Show("Gagal memuat daftar pertanyaan: " & ex.Message,
                            "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    ' =========================================================
    ' UPLOAD BUKTI PENDUKUNG (hanya DOSEN)
    ' =========================================================

    Private Sub dgvPertanyaan_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) _
        Handles dgvPertanyaan.CellContentClick

        If e.RowIndex < 0 Then Return

        ' Hanya kolom bukti
        If dgvPertanyaan.Columns(e.ColumnIndex).Name <> "colBukti" Then Return

        Dim isLastRow As Boolean = (e.RowIndex = dgvPertanyaan.Rows.Count - 1)

        Dim ofd As New OpenFileDialog()
        ofd.Title = "Pilih bukti pendukung"
        ofd.Multiselect = False

        If isLastRow Then
            ' baris terakhir WAJIB PDF
            ofd.Filter = "PDF files (*.pdf)|*.pdf"
        Else
            ' baris lain: gambar saja
            ofd.Filter =
                "Image Files (*.jpg;*.jpeg;*.png;*.gif;*.bmp)|*.jpg;*.jpeg;*.png;*.gif;*.bmp|" &
                "All Files (*.*)|*.*"
        End If

        If ofd.ShowDialog() <> DialogResult.OK Then Return

        Dim filePath As String = ofd.FileName
        Dim ext As String = Path.GetExtension(filePath).ToLowerInvariant()

        If isLastRow Then
            ' safety check juga
            If ext <> ".pdf" Then
                MessageBox.Show("Bukti pada pertanyaan terakhir wajib berupa file PDF.",
                                "Validasi Bukti", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                Return
            End If
        Else
            Dim allowedImg = New String() {".jpg", ".jpeg", ".png", ".gif", ".bmp"}
            If Not allowedImg.Contains(ext) Then
                MessageBox.Show("Bukti pendukung harus berupa gambar (JPG/PNG/GIF/BMP).",
                                "Validasi Bukti", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                Return
            End If
        End If

        ' Simpan path lengkap untuk nanti disave ke DB / copy ke folder tujuan
        buktiFiles(e.RowIndex) = filePath

        ' Ubah teks tombol menjadi nama file
        Dim fileName As String = Path.GetFileName(filePath)
        dgvPertanyaan.Rows(e.RowIndex).Cells("colBukti").Value = fileName
    End Sub

    ' =========================================================
    ' TOMBOL AKSI
    ' =========================================================

    Private Sub btnBatal_Click(sender As Object, e As EventArgs) Handles btnBatal.Click
        Me.Close()
    End Sub

    ' Simpan draft + PDF ke lokal (tanpa menulis ke DB)
    Private Sub btnSimpanDraft_Click(sender As Object, e As EventArgs) Handles btnSimpanDraft.Click
        Using sfd As New SaveFileDialog()
            sfd.Title = "Simpan Draft Penilaian (PDF)"
            sfd.Filter = "PDF Files|*.pdf"
            Dim nip = txtNip.Text.Trim()
            Dim baseName = If(String.IsNullOrEmpty(nip), "PenilaianDosen", "Penilaian_" & nip)
            sfd.FileName = baseName & "_" & DateTime.Now.ToString("yyyyMMdd_HHmm") & ".pdf"

            If sfd.ShowDialog() = DialogResult.OK Then
                Try
                    ExportPenilaianToPdf(sfd.FileName)
                    MessageBox.Show("Draft penilaian disimpan ke:" & Environment.NewLine & sfd.FileName,
                                    "Sukses", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Catch ex As Exception
                    MessageBox.Show("Gagal menyimpan PDF: " & ex.Message,
                                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                End Try
            End If
        End Using
    End Sub

    ' Kirim → simpan ke tr_penilaian (dengan validasi khusus proaktif + bukti)
    Private Sub btnKirimVerifikasi_Click(sender As Object, e As EventArgs) Handles btnKirimVerifikasi.Click
        Dim nipDosen As String = txtNip.Text.Trim()

        If String.IsNullOrEmpty(nipDosen) Then
            MessageBox.Show("NIP dosen yang dinilai belum diisi.",
                            "Validasi", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            txtNip.Focus()
            Exit Sub
        End If

        If cboPeriode.SelectedIndex < 0 Then
            MessageBox.Show("Periode penilaian belum dipilih.",
                            "Validasi", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            cboPeriode.DroppedDown = True
            Exit Sub
        End If

        Dim periode As String = cboPeriode.SelectedItem.ToString()

        ' ===== VALIDASI SKOR & BUKTI PROAKTIF =====
        For Each row As DataGridViewRow In dgvPertanyaan.Rows
            Dim skorObj = row.Cells("colSkor").Value
            If skorObj Is Nothing OrElse skorObj.ToString().Trim() = "" Then
                MessageBox.Show("Masih ada pertanyaan yang belum diberi skor." &
                                Environment.NewLine & "Silakan lengkapi semua skor.",
                                "Validasi", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                dgvPertanyaan.CurrentCell = row.Cells("colSkor")
                dgvPertanyaan.BeginEdit(True)
                Exit Sub
            End If

            Dim idx As Integer = row.Index
            Dim tipe As String = dtPertanyaan.Rows(idx)("tipe_input").ToString().Trim().ToLower()
            Dim skor As String = skorObj.ToString()

            If tipe = "proaktif" AndAlso skor = "Menyusun proposal" Then
                Dim cellBukti = row.Cells("colBukti")
                Dim buktiPath As String = ""
                If cellBukti IsNot Nothing AndAlso cellBukti.Tag IsNot Nothing Then
                    buktiPath = cellBukti.Tag.ToString()
                End If

                If String.IsNullOrEmpty(buktiPath) Then
                    MessageBox.Show("Untuk jawaban 'Menyusun proposal', bukti pendukung wajib diunggah.",
                                    "Validasi", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                    dgvPertanyaan.CurrentCell = row.Cells("colBukti")
                    Exit Sub
                End If
            End If
        Next

        ' ===== SIMPAN KE tr_penilaian =====
        Try
            Koneksi()

            Using tran = Conn.BeginTransaction()
                Using cmd As New MySqlCommand()
                    cmd.Connection = Conn
                    cmd.Transaction = tran

                    cmd.CommandText =
                        "INSERT INTO tr_penilaian " &
                        "(id_pertanyaan, username_penilai, target_dosen_nip, periode, nilai_skor, catatan, bukti_pendukung) " &
                        "VALUES (@idp, @penilai, @nip, @periode, @skor, @catatan, @bukti)"

                    cmd.Parameters.Add("@idp", MySqlDbType.Int32)
                    cmd.Parameters.Add("@penilai", MySqlDbType.VarChar)
                    cmd.Parameters.Add("@nip", MySqlDbType.VarChar)
                    cmd.Parameters.Add("@periode", MySqlDbType.VarChar)
                    cmd.Parameters.Add("@skor", MySqlDbType.VarChar)
                    cmd.Parameters.Add("@catatan", MySqlDbType.Text)
                    cmd.Parameters.Add("@bukti", MySqlDbType.Text)

                    For Each row As DataGridViewRow In dgvPertanyaan.Rows
                        Dim idx As Integer = row.Index
                        Dim idPertanyaan As Integer = CInt(row.Tag)
                        Dim skor As String = row.Cells("colSkor").Value.ToString()

                        Dim catatan As String = ""
                        If row.Cells("colCatatan").Value IsNot Nothing Then
                            catatan = row.Cells("colCatatan").Value.ToString()
                        End If

                        Dim buktiPath As String = ""
                        Dim cellBukti = row.Cells("colBukti")
                        If cellBukti IsNot Nothing AndAlso cellBukti.Tag IsNot Nothing Then
                            buktiPath = cellBukti.Tag.ToString()
                        End If

                        cmd.Parameters("@idp").Value = idPertanyaan
                        cmd.Parameters("@penilai").Value = CurrentUsername
                        cmd.Parameters("@nip").Value = nipDosen
                        cmd.Parameters("@periode").Value = periode
                        cmd.Parameters("@skor").Value = skor
                        cmd.Parameters("@catatan").Value = catatan
                        cmd.Parameters("@bukti").Value = buktiPath

                        cmd.ExecuteNonQuery()
                    Next
                End Using

                tran.Commit()
            End Using

            MessageBox.Show("Penilaian berhasil disimpan.",
                            "Sukses", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Me.Close()

        Catch ex As Exception
            MessageBox.Show("Terjadi kesalahan saat menyimpan penilaian:" &
                            Environment.NewLine & ex.Message,
                            "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    ' =========================================================
    ' EXPORT PDF (Draft lokal)
    ' =========================================================

    Private Sub ExportPenilaianToPdf(path As String)
        ' Dokumen A4 landscape seperti format SKP
        Dim doc As New Document(PageSize.A4.Rotate(), 36, 36, 36, 36)

        Using fs As New FileStream(path, FileMode.Create, FileAccess.Write, FileShare.None)
            Dim writer = PdfWriter.GetInstance(doc, fs)
            doc.Open()

            ' ---------- FONT ----------
            Dim fontTitle As PdfFont = FontFactory.GetFont(FontFactory.HELVETICA, 14, PdfFont.BOLD)
            Dim fontSub As PdfFont = FontFactory.GetFont(FontFactory.HELVETICA, 11, PdfFont.BOLD)
            Dim fontHeader As PdfFont = FontFactory.GetFont(FontFactory.HELVETICA, 9, PdfFont.BOLD)
            Dim fontText As PdfFont = FontFactory.GetFont(FontFactory.HELVETICA, 9, PdfFont.NORMAL)

            ' ---------- JUDUL ATAS ----------
            Dim pTitle As New Paragraph("PENILAIAN PERILAKU DOSEN", fontTitle)
            pTitle.Alignment = Element.ALIGN_CENTER
            doc.Add(pTitle)

            Dim periodeStr As String = If(cboPeriode.SelectedIndex >= 0,
                                          cboPeriode.SelectedItem.ToString(),
                                          "-")

            Dim pSub As New Paragraph("Periode: " & periodeStr, fontSub)
            pSub.Alignment = Element.ALIGN_CENTER
            doc.Add(pSub)

            doc.Add(New Paragraph(" ", fontText))

            ' ========================================================
            '  TABEL IDENTITAS (Pegawai yang Dinilai vs Pejabat Penilai)
            ' ========================================================
            Dim tblIdent As New PdfPTable(4)
            tblIdent.WidthPercentage = 100
            tblIdent.SetWidths({0.8F, 3.2F, 0.8F, 3.2F})

            Dim cell As PdfPCell

            ' --- header kolom ---
            cell = New PdfPCell(New Phrase("No", fontHeader))
            cell.HorizontalAlignment = Element.ALIGN_CENTER
            cell.VerticalAlignment = Element.ALIGN_MIDDLE
            tblIdent.AddCell(cell)

            cell = New PdfPCell(New Phrase("Pegawai yang Dinilai", fontHeader))
            cell.HorizontalAlignment = Element.ALIGN_CENTER
            cell.VerticalAlignment = Element.ALIGN_MIDDLE
            tblIdent.AddCell(cell)

            cell = New PdfPCell(New Phrase("No", fontHeader))
            cell.HorizontalAlignment = Element.ALIGN_CENTER
            cell.VerticalAlignment = Element.ALIGN_MIDDLE
            tblIdent.AddCell(cell)

            cell = New PdfPCell(New Phrase("Pejabat Penilai Kinerja", fontHeader))
            cell.HorizontalAlignment = Element.ALIGN_CENTER
            cell.VerticalAlignment = Element.ALIGN_MIDDLE
            tblIdent.AddCell(cell)

            ' --- baris 1: Nama ---
            cell = New PdfPCell(New Phrase("1.", fontText))
            cell.HorizontalAlignment = Element.ALIGN_CENTER
            tblIdent.AddCell(cell)

            cell = New PdfPCell(New Phrase("Nama  : " & cboNamaDosen.Text, fontText))
            tblIdent.AddCell(cell)

            cell = New PdfPCell(New Phrase("1.", fontText))
            cell.HorizontalAlignment = Element.ALIGN_CENTER
            tblIdent.AddCell(cell)

            cell = New PdfPCell(New Phrase("Nama  : " & PEJABAT_NAMA, fontText))
            tblIdent.AddCell(cell)

            ' --- baris 2: NIP ---
            cell = New PdfPCell(New Phrase("2.", fontText))
            cell.HorizontalAlignment = Element.ALIGN_CENTER
            tblIdent.AddCell(cell)

            cell = New PdfPCell(New Phrase("NIP   : " & txtNip.Text, fontText))
            tblIdent.AddCell(cell)

            cell = New PdfPCell(New Phrase("2.", fontText))
            cell.HorizontalAlignment = Element.ALIGN_CENTER
            tblIdent.AddCell(cell)

            cell = New PdfPCell(New Phrase(PEJABAT_NIP, fontText))
            tblIdent.AddCell(cell)

            ' --- baris 3: Jabatan / Prodi ---
            cell = New PdfPCell(New Phrase("3.", fontText))
            cell.HorizontalAlignment = Element.ALIGN_CENTER
            tblIdent.AddCell(cell)

            cell = New PdfPCell(New Phrase("Program Studi : " & cboProgramStudi.Text, fontText))
            tblIdent.AddCell(cell)

            cell = New PdfPCell(New Phrase("3.", fontText))
            cell.HorizontalAlignment = Element.ALIGN_CENTER
            tblIdent.AddCell(cell)

            cell = New PdfPCell(New Phrase("Jabatan : " & PEJABAT_JABATAN, fontText))
            tblIdent.AddCell(cell)

            ' --- baris 4: Unit Kerja ---
            cell = New PdfPCell(New Phrase("4.", fontText))
            cell.HorizontalAlignment = Element.ALIGN_CENTER
            tblIdent.AddCell(cell)

            cell = New PdfPCell(New Phrase("Unit Kerja : ......................................", fontText))
            tblIdent.AddCell(cell)

            cell = New PdfPCell(New Phrase("4.", fontText))
            cell.HorizontalAlignment = Element.ALIGN_CENTER
            tblIdent.AddCell(cell)

            cell = New PdfPCell(New Phrase("Unit Kerja : " & PEJABAT_UNIT, fontText))
            tblIdent.AddCell(cell)

            doc.Add(tblIdent)

            doc.Add(New Paragraph(" ", fontText))

            ' ========================================================
            '  PERILAKU KERJA (TANPA HASIL KERJA)
            ' ========================================================
            Dim pPerilaku As New Paragraph("PERILAKU KERJA", fontSub)
            pPerilaku.Alignment = Element.ALIGN_LEFT
            doc.Add(pPerilaku)

            doc.Add(New Paragraph(" ", fontText))

            ' Tabel perilaku: No | Uraian | Skor | Catatan
            Dim tblPerilaku As New PdfPTable(4)
            tblPerilaku.WidthPercentage = 100
            tblPerilaku.SetWidths({0.7F, 4.3F, 0.8F, 2.2F})

            ' header
            tblPerilaku.AddCell(New PdfPCell(New Phrase("No", fontHeader)) With {
                .HorizontalAlignment = Element.ALIGN_CENTER,
                .VerticalAlignment = Element.ALIGN_MIDDLE
            })

            tblPerilaku.AddCell(New PdfPCell(New Phrase("Perilaku Kerja (Aspek & Pertanyaan)", fontHeader)) With {
                .HorizontalAlignment = Element.ALIGN_CENTER,
                .VerticalAlignment = Element.ALIGN_MIDDLE
            })

            tblPerilaku.AddCell(New PdfPCell(New Phrase("Skor / Pilihan", fontHeader)) With {
                .HorizontalAlignment = Element.ALIGN_CENTER,
                .VerticalAlignment = Element.ALIGN_MIDDLE
            })

            tblPerilaku.AddCell(New PdfPCell(New Phrase("Catatan / Bukti Pendukung", fontHeader)) With {
                .HorizontalAlignment = Element.ALIGN_CENTER,
                .VerticalAlignment = Element.ALIGN_MIDDLE
            })

            ' isi dari grid
            Dim nomor As Integer = 1
            For Each row As DataGridViewRow In dgvPertanyaan.Rows
                Dim aspek = If(row.Cells("colAspek").Value, "").ToString()
                Dim pert = If(row.Cells("colPertanyaan").Value, "").ToString()
                Dim skor = If(row.Cells("colSkor").Value, "").ToString()
                Dim catatan = If(row.Cells("colCatatan").Value, "").ToString()

                ' No
                tblPerilaku.AddCell(New PdfPCell(New Phrase(nomor.ToString() & ".", fontText)) With {
                    .HorizontalAlignment = Element.ALIGN_CENTER
                })

                ' Uraian = Aspek + newline + Pertanyaan
                Dim uraian As String = aspek
                If pert <> "" Then
                    If uraian <> "" Then uraian &= Environment.NewLine
                    uraian &= pert
                End If
                tblPerilaku.AddCell(New PdfPCell(New Phrase(uraian, fontText)))

                ' Skor / Pilihan
                tblPerilaku.AddCell(New PdfPCell(New Phrase(skor, fontText)) With {
                    .HorizontalAlignment = Element.ALIGN_CENTER
                })

                ' Catatan / Bukti
                tblPerilaku.AddCell(New PdfPCell(New Phrase(catatan, fontText)))

                nomor += 1
            Next

            doc.Add(tblPerilaku)

            doc.Add(New Paragraph(" ", fontText))
            doc.Add(New Paragraph(" ", fontText))

            ' ========================================================
            '  BLOK TANDA TANGAN
            ' ========================================================
            Dim tglStr As String = Date.Now.ToString("dd MMMM yyyy")

            Dim tblTTD As New PdfPTable(2)
            tblTTD.WidthPercentage = 100
            tblTTD.SetWidths({1.0F, 1.0F})

            ' Pegawai yang Dinilai
            tblTTD.AddCell(New PdfPCell(New Phrase(
                "Pegawai yang Dinilai," & Environment.NewLine &
                Environment.NewLine & Environment.NewLine &
                cboNamaDosen.Text & Environment.NewLine &
                "NIP " & txtNip.Text,
                fontText)) With {
                .Border = Rectangle.NO_BORDER,
                .HorizontalAlignment = Element.ALIGN_LEFT
            })

            ' Pejabat Penilai Kinerja (fix)
            tblTTD.AddCell(New PdfPCell(New Phrase(
                "Pejabat Penilai Kinerja," & Environment.NewLine &
                "( " & tglStr & " )" & Environment.NewLine &
                Environment.NewLine &
                PEJABAT_NAMA & Environment.NewLine &
                PEJABAT_NIP,
                fontText)) With {
                .Border = Rectangle.NO_BORDER,
                .HorizontalAlignment = Element.ALIGN_RIGHT
            })

            doc.Add(tblTTD)

            doc.Close()
        End Using
    End Sub


End Class
