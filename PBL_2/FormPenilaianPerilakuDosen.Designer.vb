<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class FormPenilaianPerilakuDosen
    Inherits System.Windows.Forms.Form

    <System.Diagnostics.DebuggerNonUserCode()>
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    Private components As System.ComponentModel.IContainer

    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Dim DataGridViewCellStyle1 As DataGridViewCellStyle = New DataGridViewCellStyle()
        Dim DataGridViewCellStyle2 As DataGridViewCellStyle = New DataGridViewCellStyle()
        Dim DataGridViewCellStyle3 As DataGridViewCellStyle = New DataGridViewCellStyle()
        pnlHeader = New Panel()
        cboNamaDosen = New ComboBox()
        cboProgramStudi = New ComboBox()
        lblPeriode = New Label()
        cboPeriode = New ComboBox()
        lblProdi = New Label()
        txtNip = New TextBox()
        lblNip = New Label()
        lblNamaDosen = New Label()
        lblTitle = New Label()
        dgvPertanyaan = New DataGridView()
        colNo = New DataGridViewTextBoxColumn()
        colAspek = New DataGridViewTextBoxColumn()
        colPertanyaan = New DataGridViewTextBoxColumn()
        colSkor = New DataGridViewComboBoxColumn()
        colCatatan = New DataGridViewTextBoxColumn()
        colBukti = New DataGridViewButtonColumn()
        pnlFooter = New Panel()
        btnBatal = New Button()
        btnSimpanDraft = New Button()
        btnKirimVerifikasi = New Button()
        pnlHeader.SuspendLayout()
        CType(dgvPertanyaan, ComponentModel.ISupportInitialize).BeginInit()
        pnlFooter.SuspendLayout()
        SuspendLayout()
        ' 
        ' pnlHeader
        ' 
        pnlHeader.BackColor = Color.FromArgb(CByte(240), CByte(233), CByte(221))
        pnlHeader.Controls.Add(cboNamaDosen)
        pnlHeader.Controls.Add(cboProgramStudi)
        pnlHeader.Controls.Add(lblPeriode)
        pnlHeader.Controls.Add(cboPeriode)
        pnlHeader.Controls.Add(lblProdi)
        pnlHeader.Controls.Add(txtNip)
        pnlHeader.Controls.Add(lblNip)
        pnlHeader.Controls.Add(lblNamaDosen)
        pnlHeader.Controls.Add(lblTitle)
        pnlHeader.Dock = DockStyle.Top
        pnlHeader.Location = New Point(0, 0)
        pnlHeader.Margin = New Padding(5, 6, 5, 6)
        pnlHeader.Name = "pnlHeader"
        pnlHeader.Padding = New Padding(29, 34, 29, 34)
        pnlHeader.Size = New Size(1857, 299)
        pnlHeader.TabIndex = 0
        ' 
        ' cboNamaDosen
        ' 
        cboNamaDosen.DropDownStyle = ComboBoxStyle.DropDownList
        cboNamaDosen.Font = New Font("Segoe UI", 9F)
        cboNamaDosen.FormattingEnabled = True
        cboNamaDosen.Location = New Point(223, 125)
        cboNamaDosen.Margin = New Padding(5, 6, 5, 6)
        cboNamaDosen.Name = "cboNamaDosen"
        cboNamaDosen.Size = New Size(519, 40)
        cboNamaDosen.TabIndex = 10
        ' 
        ' cboProgramStudi
        ' 
        cboProgramStudi.DropDownStyle = ComboBoxStyle.DropDownList
        cboProgramStudi.Font = New Font("Segoe UI", 9F)
        cboProgramStudi.FormattingEnabled = True
        cboProgramStudi.Items.AddRange(New Object() {"TI", "TMD", "TMJ"})
        cboProgramStudi.Location = New Point(223, 197)
        cboProgramStudi.Margin = New Padding(5, 6, 5, 6)
        cboProgramStudi.Name = "cboProgramStudi"
        cboProgramStudi.Size = New Size(519, 40)
        cboProgramStudi.TabIndex = 9
        ' 
        ' lblPeriode
        ' 
        lblPeriode.AutoSize = True
        lblPeriode.Font = New Font("Segoe UI", 9F)
        lblPeriode.ForeColor = Color.FromArgb(CByte(60), CByte(72), CByte(82))
        lblPeriode.Location = New Point(780, 205)
        lblPeriode.Margin = New Padding(5, 0, 5, 0)
        lblPeriode.Name = "lblPeriode"
        lblPeriode.Size = New Size(94, 32)
        lblPeriode.TabIndex = 7
        lblPeriode.Text = "Periode"
        ' 
        ' cboPeriode
        ' 
        cboPeriode.DropDownStyle = ComboBoxStyle.DropDownList
        cboPeriode.Font = New Font("Segoe UI", 9F)
        cboPeriode.FormattingEnabled = True
        cboPeriode.Items.AddRange(New Object() {"2024/2025", "2025/2026"})
        cboPeriode.Location = New Point(879, 197)
        cboPeriode.Margin = New Padding(5, 6, 5, 6)
        cboPeriode.Name = "cboPeriode"
        cboPeriode.Size = New Size(368, 40)
        cboPeriode.TabIndex = 8
        ' 
        ' lblProdi
        ' 
        lblProdi.AutoSize = True
        lblProdi.Font = New Font("Segoe UI", 9F)
        lblProdi.ForeColor = Color.FromArgb(CByte(60), CByte(72), CByte(82))
        lblProdi.Location = New Point(37, 205)
        lblProdi.Margin = New Padding(5, 0, 5, 0)
        lblProdi.Name = "lblProdi"
        lblProdi.Size = New Size(165, 32)
        lblProdi.TabIndex = 5
        lblProdi.Text = "Program Studi"
        ' 
        ' txtNip
        ' 
        txtNip.BorderStyle = BorderStyle.FixedSingle
        txtNip.Font = New Font("Segoe UI", 9F)
        txtNip.Location = New Point(876, 120)
        txtNip.Margin = New Padding(5, 6, 5, 6)
        txtNip.Name = "txtNip"
        txtNip.Size = New Size(369, 39)
        txtNip.TabIndex = 4
        ' 
        ' lblNip
        ' 
        lblNip.AutoSize = True
        lblNip.Font = New Font("Segoe UI", 9F)
        lblNip.ForeColor = Color.FromArgb(CByte(60), CByte(72), CByte(82))
        lblNip.Location = New Point(780, 128)
        lblNip.Margin = New Padding(5, 0, 5, 0)
        lblNip.Name = "lblNip"
        lblNip.Size = New Size(51, 32)
        lblNip.TabIndex = 3
        lblNip.Text = "NIP"
        ' 
        ' lblNamaDosen
        ' 
        lblNamaDosen.AutoSize = True
        lblNamaDosen.Font = New Font("Segoe UI", 9F)
        lblNamaDosen.ForeColor = Color.FromArgb(CByte(60), CByte(72), CByte(82))
        lblNamaDosen.Location = New Point(37, 128)
        lblNamaDosen.Margin = New Padding(5, 0, 5, 0)
        lblNamaDosen.Name = "lblNamaDosen"
        lblNamaDosen.Size = New Size(152, 32)
        lblNamaDosen.TabIndex = 1
        lblNamaDosen.Text = "Nama Dosen"
        ' 
        ' lblTitle
        ' 
        lblTitle.Dock = DockStyle.Top
        lblTitle.Font = New Font("Segoe UI Semibold", 14F, FontStyle.Bold)
        lblTitle.ForeColor = Color.FromArgb(CByte(60), CByte(72), CByte(82))
        lblTitle.Location = New Point(29, 34)
        lblTitle.Margin = New Padding(5, 0, 5, 0)
        lblTitle.Name = "lblTitle"
        lblTitle.Size = New Size(1799, 69)
        lblTitle.TabIndex = 0
        lblTitle.Text = "Form Penilaian Perilaku Dosen"
        lblTitle.TextAlign = ContentAlignment.MiddleLeft
        ' 
        ' dgvPertanyaan
        ' 
        dgvPertanyaan.AllowUserToAddRows = False
        dgvPertanyaan.AllowUserToDeleteRows = False
        dgvPertanyaan.AllowUserToResizeRows = False
        DataGridViewCellStyle1.BackColor = Color.FromArgb(CByte(249), CByte(250), CByte(252))
        dgvPertanyaan.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle1
        dgvPertanyaan.BackgroundColor = Color.FromArgb(CByte(245), CByte(240), CByte(232))
        dgvPertanyaan.BorderStyle = BorderStyle.None
        dgvPertanyaan.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.None
        DataGridViewCellStyle2.Alignment = DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle2.BackColor = Color.FromArgb(CByte(207), CByte(208), CByte(200))
        DataGridViewCellStyle2.Font = New Font("Segoe UI", 9F, FontStyle.Bold)
        DataGridViewCellStyle2.ForeColor = Color.FromArgb(CByte(60), CByte(72), CByte(82))
        DataGridViewCellStyle2.SelectionBackColor = Color.FromArgb(CByte(194), CByte(210), CByte(221))
        DataGridViewCellStyle2.SelectionForeColor = Color.FromArgb(CByte(60), CByte(72), CByte(82))
        DataGridViewCellStyle2.WrapMode = DataGridViewTriState.False
        dgvPertanyaan.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle2
        dgvPertanyaan.ColumnHeadersHeight = 32
        dgvPertanyaan.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing
        dgvPertanyaan.Columns.AddRange(New DataGridViewColumn() {colNo, colAspek, colPertanyaan, colSkor, colCatatan, colBukti})
        DataGridViewCellStyle3.Alignment = DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle3.BackColor = Color.White
        DataGridViewCellStyle3.Font = New Font("Segoe UI", 9F)
        DataGridViewCellStyle3.ForeColor = Color.Black
        DataGridViewCellStyle3.SelectionBackColor = Color.FromArgb(CByte(227), CByte(242), CByte(253))
        DataGridViewCellStyle3.SelectionForeColor = Color.Black
        DataGridViewCellStyle3.WrapMode = DataGridViewTriState.False
        dgvPertanyaan.DefaultCellStyle = DataGridViewCellStyle3
        dgvPertanyaan.Dock = DockStyle.Fill
        dgvPertanyaan.EnableHeadersVisualStyles = False
        dgvPertanyaan.GridColor = Color.FromArgb(CByte(207), CByte(208), CByte(200))
        dgvPertanyaan.Location = New Point(0, 299)
        dgvPertanyaan.Margin = New Padding(5, 6, 5, 6)
        dgvPertanyaan.MultiSelect = False
        dgvPertanyaan.Name = "dgvPertanyaan"
        dgvPertanyaan.RowHeadersVisible = False
        dgvPertanyaan.RowHeadersWidth = 51
        dgvPertanyaan.RowTemplate.Height = 26
        dgvPertanyaan.SelectionMode = DataGridViewSelectionMode.FullRowSelect
        dgvPertanyaan.Size = New Size(1857, 917)
        dgvPertanyaan.TabIndex = 1
        ' 
        ' colNo
        ' 
        colNo.HeaderText = "No"
        colNo.MinimumWidth = 6
        colNo.Name = "colNo"
        colNo.ReadOnly = True
        colNo.Width = 50
        ' 
        ' colAspek
        ' 
        colAspek.HeaderText = "Aspek Perilaku"
        colAspek.MinimumWidth = 6
        colAspek.Name = "colAspek"
        colAspek.ReadOnly = True
        colAspek.Width = 160
        ' 
        ' colPertanyaan
        ' 
        colPertanyaan.HeaderText = "Pertanyaan"
        colPertanyaan.MinimumWidth = 6
        colPertanyaan.Name = "colPertanyaan"
        colPertanyaan.ReadOnly = True
        colPertanyaan.Width = 360
        ' 
        ' colSkor
        ' 
        colSkor.DisplayStyle = DataGridViewComboBoxDisplayStyle.ComboBox
        colSkor.HeaderText = "Skor (1-10)"
        colSkor.Items.AddRange(New Object() {"1", "2", "3", "4", "5", "6", "7", "8", "9", "10"})
        colSkor.MinimumWidth = 6
        colSkor.Name = "colSkor"
        colSkor.Width = 125
        ' 
        ' colCatatan
        ' 
        colCatatan.HeaderText = "Catatan / Contoh Perilaku"
        colCatatan.MinimumWidth = 6
        colCatatan.Name = "colCatatan"
        colCatatan.Width = 220
        ' 
        ' colBukti
        ' 
        colBukti.HeaderText = "Bukti Pendukung"
        colBukti.MinimumWidth = 6
        colBukti.Name = "colBukti"
        colBukti.Text = "Upload File "
        colBukti.UseColumnTextForButtonValue = True
        colBukti.Width = 140
        ' 
        ' pnlFooter
        ' 
        pnlFooter.BackColor = Color.FromArgb(CByte(240), CByte(233), CByte(221))
        pnlFooter.Controls.Add(btnBatal)
        pnlFooter.Controls.Add(btnSimpanDraft)
        pnlFooter.Controls.Add(btnKirimVerifikasi)
        pnlFooter.Dock = DockStyle.Bottom
        pnlFooter.Location = New Point(0, 1216)
        pnlFooter.Margin = New Padding(5, 6, 5, 6)
        pnlFooter.Name = "pnlFooter"
        pnlFooter.Padding = New Padding(29, 18, 29, 18)
        pnlFooter.Size = New Size(1857, 107)
        pnlFooter.TabIndex = 2
        ' 
        ' btnBatal
        ' 
        btnBatal.Anchor = AnchorStyles.Bottom Or AnchorStyles.Left
        btnBatal.BackColor = Color.White
        btnBatal.FlatAppearance.BorderColor = Color.FromArgb(CByte(211), CByte(47), CByte(47))
        btnBatal.FlatStyle = FlatStyle.Flat
        btnBatal.Font = New Font("Segoe UI", 9F)
        btnBatal.ForeColor = Color.FromArgb(CByte(211), CByte(47), CByte(47))
        btnBatal.Location = New Point(37, 24)
        btnBatal.Margin = New Padding(5, 6, 5, 6)
        btnBatal.Name = "btnBatal"
        btnBatal.Size = New Size(167, 59)
        btnBatal.TabIndex = 0
        btnBatal.Text = "Batal"
        btnBatal.UseVisualStyleBackColor = False
        ' 
        ' btnSimpanDraft
        ' 
        btnSimpanDraft.Anchor = AnchorStyles.Bottom Or AnchorStyles.Right
        btnSimpanDraft.BackColor = Color.FromArgb(CByte(207), CByte(208), CByte(200))
        btnSimpanDraft.FlatAppearance.BorderSize = 0
        btnSimpanDraft.FlatStyle = FlatStyle.Flat
        btnSimpanDraft.Font = New Font("Segoe UI", 9F, FontStyle.Bold)
        btnSimpanDraft.ForeColor = Color.FromArgb(CByte(60), CByte(72), CByte(82))
        btnSimpanDraft.Location = New Point(978, 7)
        btnSimpanDraft.Margin = New Padding(5, 6, 5, 6)
        btnSimpanDraft.Name = "btnSimpanDraft"
        btnSimpanDraft.Size = New Size(470, 72)
        btnSimpanDraft.TabIndex = 1
        btnSimpanDraft.Text = "Simpan Draft dan Simpan PDF"
        btnSimpanDraft.UseVisualStyleBackColor = False
        ' 
        ' btnKirimVerifikasi
        ' 
        btnKirimVerifikasi.Anchor = AnchorStyles.Bottom Or AnchorStyles.Right
        btnKirimVerifikasi.BackColor = Color.SkyBlue
        btnKirimVerifikasi.FlatAppearance.BorderSize = 0
        btnKirimVerifikasi.FlatStyle = FlatStyle.Flat
        btnKirimVerifikasi.Font = New Font("Segoe UI", 9F, FontStyle.Bold)
        btnKirimVerifikasi.ForeColor = Color.White
        btnKirimVerifikasi.Location = New Point(1467, 7)
        btnKirimVerifikasi.Margin = New Padding(5, 6, 5, 6)
        btnKirimVerifikasi.Name = "btnKirimVerifikasi"
        btnKirimVerifikasi.Size = New Size(353, 72)
        btnKirimVerifikasi.TabIndex = 2
        btnKirimVerifikasi.Text = "Kirim untuk Verifikasi"
        btnKirimVerifikasi.UseVisualStyleBackColor = False
        ' 
        ' FormPenilaianPerilakuDosen
        ' 
        AutoScaleDimensions = New SizeF(13F, 32F)
        AutoScaleMode = AutoScaleMode.Font
        BackColor = Color.FromArgb(CByte(245), CByte(240), CByte(232))
        ClientSize = New Size(1857, 1323)
        Controls.Add(dgvPertanyaan)
        Controls.Add(pnlFooter)
        Controls.Add(pnlHeader)
        Margin = New Padding(5, 6, 5, 6)
        Name = "FormPenilaianPerilakuDosen"
        StartPosition = FormStartPosition.CenterScreen
        Text = "Penilaian Perilaku Dosen"
        pnlHeader.ResumeLayout(False)
        pnlHeader.PerformLayout()
        CType(dgvPertanyaan, ComponentModel.ISupportInitialize).EndInit()
        pnlFooter.ResumeLayout(False)
        ResumeLayout(False)

    End Sub

    ' --- fields ---
    Friend WithEvents pnlHeader As System.Windows.Forms.Panel
    Friend WithEvents lblTitle As System.Windows.Forms.Label
    Friend WithEvents lblNamaDosen As System.Windows.Forms.Label
    Friend WithEvents lblNip As System.Windows.Forms.Label
    Friend WithEvents txtNip As System.Windows.Forms.TextBox
    Friend WithEvents lblProdi As System.Windows.Forms.Label
    Friend WithEvents lblPeriode As System.Windows.Forms.Label
    Friend WithEvents cboPeriode As System.Windows.Forms.ComboBox

    Friend WithEvents dgvPertanyaan As System.Windows.Forms.DataGridView

    Friend WithEvents pnlFooter As System.Windows.Forms.Panel
    Friend WithEvents btnBatal As System.Windows.Forms.Button
    Friend WithEvents btnSimpanDraft As System.Windows.Forms.Button
    Friend WithEvents btnKirimVerifikasi As System.Windows.Forms.Button
    Friend WithEvents cboProgramStudi As ComboBox
    Friend WithEvents cboNamaDosen As ComboBox
    Friend WithEvents colNo As DataGridViewTextBoxColumn
    Friend WithEvents colAspek As DataGridViewTextBoxColumn
    Friend WithEvents colPertanyaan As DataGridViewTextBoxColumn
    Friend WithEvents colSkor As DataGridViewComboBoxColumn
    Friend WithEvents colCatatan As DataGridViewTextBoxColumn
    Friend WithEvents colBukti As DataGridViewButtonColumn

End Class
