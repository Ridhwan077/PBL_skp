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
        pnlHeader.BackColor = Color.FromArgb(240, 233, 221)
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
        pnlHeader.Name = "pnlHeader"
        pnlHeader.Padding = New Padding(16, 16, 16, 16)
        pnlHeader.Size = New Size(1056, 140)
        pnlHeader.TabIndex = 0
        ' 
        ' cboNamaDosen
        ' 
        cboNamaDosen.DropDownStyle = ComboBoxStyle.DropDownList
        cboNamaDosen.Font = New Font("Segoe UI", 9.0F)
        cboNamaDosen.FormattingEnabled = True
        cboNamaDosen.Location = New Point(120, 59)
        cboNamaDosen.Name = "cboNamaDosen"
        cboNamaDosen.Size = New Size(281, 23)
        cboNamaDosen.TabIndex = 10
        ' 
        ' cboProgramStudi
        ' 
        cboProgramStudi.DropDownStyle = ComboBoxStyle.DropDownList
        cboProgramStudi.Font = New Font("Segoe UI", 9.0F)
        cboProgramStudi.FormattingEnabled = True
        cboProgramStudi.Items.AddRange(New Object() {"TI", "TMD", "TMJ"})
        cboProgramStudi.Location = New Point(120, 92)
        cboProgramStudi.Name = "cboProgramStudi"
        cboProgramStudi.Size = New Size(281, 23)
        cboProgramStudi.TabIndex = 9
        ' 
        ' lblPeriode
        ' 
        lblPeriode.AutoSize = True
        lblPeriode.Font = New Font("Segoe UI", 9.0F)
        lblPeriode.ForeColor = Color.FromArgb(60, 72, 82)
        lblPeriode.Location = New Point(420, 96)
        lblPeriode.Name = "lblPeriode"
        lblPeriode.Size = New Size(47, 15)
        lblPeriode.TabIndex = 7
        lblPeriode.Text = "Periode"
        ' 
        ' cboPeriode
        ' 
        cboPeriode.DropDownStyle = ComboBoxStyle.DropDownList
        cboPeriode.Font = New Font("Segoe UI", 9.0F)
        cboPeriode.FormattingEnabled = True
        cboPeriode.Items.AddRange(New Object() {"2024/2025", "2025/2026"})
        cboPeriode.Location = New Point(473, 92)
        cboPeriode.Name = "cboPeriode"
        cboPeriode.Size = New Size(200, 23)
        cboPeriode.TabIndex = 8
        ' 
        ' lblProdi
        ' 
        lblProdi.AutoSize = True
        lblProdi.Font = New Font("Segoe UI", 9.0F)
        lblProdi.ForeColor = Color.FromArgb(60, 72, 82)
        lblProdi.Location = New Point(20, 96)
        lblProdi.Name = "lblProdi"
        lblProdi.Size = New Size(83, 15)
        lblProdi.TabIndex = 5
        lblProdi.Text = "Program Studi"
        ' 
        ' txtNip
        ' 
        txtNip.BorderStyle = BorderStyle.FixedSingle
        txtNip.Font = New Font("Segoe UI", 9.0F)
        txtNip.Location = New Point(472, 56)
        txtNip.Name = "txtNip"
        txtNip.Size = New Size(200, 23)
        txtNip.TabIndex = 4
        ' 
        ' lblNip
        ' 
        lblNip.AutoSize = True
        lblNip.Font = New Font("Segoe UI", 9.0F)
        lblNip.ForeColor = Color.FromArgb(60, 72, 82)
        lblNip.Location = New Point(420, 60)
        lblNip.Name = "lblNip"
        lblNip.Size = New Size(26, 15)
        lblNip.TabIndex = 3
        lblNip.Text = "NIP"
        ' 
        ' lblNamaDosen
        ' 
        lblNamaDosen.AutoSize = True
        lblNamaDosen.Font = New Font("Segoe UI", 9.0F)
        lblNamaDosen.ForeColor = Color.FromArgb(60, 72, 82)
        lblNamaDosen.Location = New Point(20, 60)
        lblNamaDosen.Name = "lblNamaDosen"
        lblNamaDosen.Size = New Size(75, 15)
        lblNamaDosen.TabIndex = 1
        lblNamaDosen.Text = "Nama Dosen"
        ' 
        ' lblTitle
        ' 
        lblTitle.Dock = DockStyle.Top
        lblTitle.Font = New Font("Segoe UI Semibold", 14.0F, FontStyle.Bold)
        lblTitle.ForeColor = Color.FromArgb(60, 72, 82)
        lblTitle.Location = New Point(16, 16)
        lblTitle.Name = "lblTitle"
        lblTitle.Size = New Size(1024, 32)
        lblTitle.TabIndex = 0
        lblTitle.Text = "Form Penilaian Perilaku Dosen"
        lblTitle.TextAlign = ContentAlignment.MiddleLeft
        ' 
        ' dgvPertanyaan
        ' 
        dgvPertanyaan.AllowUserToAddRows = False
        dgvPertanyaan.AllowUserToDeleteRows = False
        dgvPertanyaan.AllowUserToResizeRows = False
        DataGridViewCellStyle1.BackColor = Color.FromArgb(249, 250, 252)
        dgvPertanyaan.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle1
        dgvPertanyaan.BackgroundColor = Color.FromArgb(245, 240, 232)
        dgvPertanyaan.BorderStyle = BorderStyle.None
        dgvPertanyaan.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.None
        DataGridViewCellStyle2.Alignment = DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle2.BackColor = Color.FromArgb(207, 208, 200)
        DataGridViewCellStyle2.Font = New Font("Segoe UI", 9.0F, FontStyle.Bold)
        DataGridViewCellStyle2.ForeColor = Color.FromArgb(60, 72, 82)
        DataGridViewCellStyle2.SelectionBackColor = Color.FromArgb(194, 210, 221)
        DataGridViewCellStyle2.SelectionForeColor = Color.FromArgb(60, 72, 82)
        DataGridViewCellStyle2.WrapMode = DataGridViewTriState.False
        dgvPertanyaan.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle2
        dgvPertanyaan.ColumnHeadersHeight = 32
        dgvPertanyaan.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing
        dgvPertanyaan.Columns.AddRange(New DataGridViewColumn() {colNo, colAspek, colPertanyaan, colSkor, colCatatan, colBukti})
        DataGridViewCellStyle3.Alignment = DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle3.BackColor = Color.White
        DataGridViewCellStyle3.Font = New Font("Segoe UI", 9.0F)
        DataGridViewCellStyle3.ForeColor = Color.Black
        DataGridViewCellStyle3.SelectionBackColor = Color.FromArgb(227, 242, 253)
        DataGridViewCellStyle3.SelectionForeColor = Color.Black
        DataGridViewCellStyle3.WrapMode = DataGridViewTriState.False
        dgvPertanyaan.DefaultCellStyle = DataGridViewCellStyle3
        dgvPertanyaan.Dock = DockStyle.Fill
        dgvPertanyaan.EnableHeadersVisualStyles = False
        dgvPertanyaan.GridColor = Color.FromArgb(207, 208, 200)
        dgvPertanyaan.Location = New Point(0, 140)
        dgvPertanyaan.MultiSelect = False
        dgvPertanyaan.Name = "dgvPertanyaan"
        dgvPertanyaan.RowHeadersVisible = False
        dgvPertanyaan.RowHeadersWidth = 51
        dgvPertanyaan.RowTemplate.Height = 26
        dgvPertanyaan.SelectionMode = DataGridViewSelectionMode.FullRowSelect
        dgvPertanyaan.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells
        dgvPertanyaan.Size = New Size(1056, 307)
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
        colBukti.Width = 140
        ' 
        ' pnlFooter
        ' 
        pnlFooter.BackColor = Color.FromArgb(240, 233, 221)
        pnlFooter.Controls.Add(btnBatal)
        pnlFooter.Controls.Add(btnSimpanDraft)
        pnlFooter.Controls.Add(btnKirimVerifikasi)
        pnlFooter.Dock = DockStyle.Bottom
        pnlFooter.Location = New Point(0, 447)
        pnlFooter.Name = "pnlFooter"
        pnlFooter.Padding = New Padding(16, 8, 16, 8)
        pnlFooter.Size = New Size(1056, 50)
        pnlFooter.TabIndex = 2
        ' 
        ' btnBatal
        ' 
        btnBatal.Anchor = AnchorStyles.Bottom Or AnchorStyles.Left
        btnBatal.BackColor = Color.White
        btnBatal.FlatAppearance.BorderColor = Color.FromArgb(211, 47, 47)
        btnBatal.FlatStyle = FlatStyle.Flat
        btnBatal.Font = New Font("Segoe UI", 9.0F)
        btnBatal.ForeColor = Color.FromArgb(211, 47, 47)
        btnBatal.Location = New Point(20, 11)
        btnBatal.Name = "btnBatal"
        btnBatal.Size = New Size(90, 28)
        btnBatal.TabIndex = 0
        btnBatal.Text = "Batal"
        btnBatal.UseVisualStyleBackColor = False
        ' 
        ' btnSimpanDraft
        ' 
        btnSimpanDraft.Anchor = AnchorStyles.Bottom Or AnchorStyles.Right
        btnSimpanDraft.BackColor = Color.FromArgb(207, 208, 200)
        btnSimpanDraft.FlatAppearance.BorderSize = 0
        btnSimpanDraft.FlatStyle = FlatStyle.Flat
        btnSimpanDraft.Font = New Font("Segoe UI", 9.0F, FontStyle.Bold)
        btnSimpanDraft.ForeColor = Color.FromArgb(60, 72, 82)
        btnSimpanDraft.Location = New Point(583, 3)
        btnSimpanDraft.Name = "btnSimpanDraft"
        btnSimpanDraft.Size = New Size(253, 34)
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
        btnKirimVerifikasi.Font = New Font("Segoe UI", 9.0F, FontStyle.Bold)
        btnKirimVerifikasi.ForeColor = Color.White
        btnKirimVerifikasi.Location = New Point(846, 3)
        btnKirimVerifikasi.Name = "btnKirimVerifikasi"
        btnKirimVerifikasi.Size = New Size(190, 34)
        btnKirimVerifikasi.TabIndex = 2
        btnKirimVerifikasi.Text = "Kirim untuk Verifikasi"
        btnKirimVerifikasi.UseVisualStyleBackColor = False
        ' 
        ' FormPenilaianPerilakuDosen
        ' 
        AutoScaleDimensions = New SizeF(7.0F, 15.0F)
        AutoScaleMode = AutoScaleMode.Font
        BackColor = Color.FromArgb(245, 240, 232)
        ClientSize = New Size(1056, 497)
        Controls.Add(dgvPertanyaan)
        Controls.Add(pnlFooter)
        Controls.Add(pnlHeader)
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
