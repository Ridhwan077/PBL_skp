<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class FormVerifikasiPenilaian
    Inherits System.Windows.Forms.Form

    <System.Diagnostics.DebuggerNonUserCode()>
    Protected Overrides Sub Dispose(disposing As Boolean)
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
        Dim DataGridViewCellStyle4 As DataGridViewCellStyle = New DataGridViewCellStyle()
        Dim DataGridViewCellStyle5 As DataGridViewCellStyle = New DataGridViewCellStyle()
        Dim DataGridViewCellStyle6 As DataGridViewCellStyle = New DataGridViewCellStyle()
        pnlHeader = New Panel()
        cboPeriode = New ComboBox()
        cboNamaDosen = New ComboBox()
        lblPeriode = New Label()
        txtProdi = New TextBox()
        lblProdi = New Label()
        txtNip = New TextBox()
        lblNip = New Label()
        lblNamaDosen = New Label()
        lblTitle = New Label()
        dgvVerifikasi = New DataGridView()
        colNo = New DataGridViewTextBoxColumn()
        colAspek = New DataGridViewTextBoxColumn()
        colIndikator = New DataGridViewTextBoxColumn()
        colNilaiDosen = New DataGridViewTextBoxColumn()
        colNilaiPenilai = New DataGridViewTextBoxColumn()
        colStatus = New DataGridViewComboBoxColumn()
        colCatatan = New DataGridViewTextBoxColumn()
        colBukti = New DataGridViewButtonColumn()
        colPenilai = New DataGridViewTextBoxColumn()
        pnlFooter = New Panel()
        btnTutup = New Button()
        btnSimpan = New Button()
        btnSetFinal = New Button()
        BackgroundWorker1 = New ComponentModel.BackgroundWorker()
        pnlHeader.SuspendLayout()
        CType(dgvVerifikasi, ComponentModel.ISupportInitialize).BeginInit()
        pnlFooter.SuspendLayout()
        SuspendLayout()
        ' 
        ' pnlHeader
        ' 
        pnlHeader.BackColor = Color.FromArgb(CByte(240), CByte(233), CByte(221))
        pnlHeader.Controls.Add(cboPeriode)
        pnlHeader.Controls.Add(cboNamaDosen)
        pnlHeader.Controls.Add(lblPeriode)
        pnlHeader.Controls.Add(txtProdi)
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
        pnlHeader.Size = New Size(1857, 309)
        pnlHeader.TabIndex = 0
        ' 
        ' cboPeriode
        ' 
        cboPeriode.FormattingEnabled = True
        cboPeriode.Location = New Point(822, 195)
        cboPeriode.Name = "cboPeriode"
        cboPeriode.Size = New Size(314, 40)
        cboPeriode.TabIndex = 12
        ' 
        ' cboNamaDosen
        ' 
        cboNamaDosen.FormattingEnabled = True
        cboNamaDosen.Location = New Point(205, 125)
        cboNamaDosen.Name = "cboNamaDosen"
        cboNamaDosen.Size = New Size(481, 40)
        cboNamaDosen.TabIndex = 11
        ' 
        ' lblPeriode
        ' 
        lblPeriode.AutoSize = True
        lblPeriode.Font = New Font("Segoe UI", 9.0F)
        lblPeriode.ForeColor = Color.FromArgb(CByte(60), CByte(72), CByte(82))
        lblPeriode.Location = New Point(725, 198)
        lblPeriode.Margin = New Padding(5, 0, 5, 0)
        lblPeriode.Name = "lblPeriode"
        lblPeriode.Size = New Size(94, 32)
        lblPeriode.TabIndex = 7
        lblPeriode.Text = "Periode"
        ' 
        ' txtProdi
        ' 
        txtProdi.BorderStyle = BorderStyle.FixedSingle
        txtProdi.Font = New Font("Segoe UI", 9.0F)
        txtProdi.Location = New Point(205, 190)
        txtProdi.Margin = New Padding(5, 6, 5, 6)
        txtProdi.Name = "txtProdi"
        txtProdi.ReadOnly = True
        txtProdi.Size = New Size(481, 39)
        txtProdi.TabIndex = 6
        ' 
        ' lblProdi
        ' 
        lblProdi.AutoSize = True
        lblProdi.Font = New Font("Segoe UI", 9.0F)
        lblProdi.ForeColor = Color.FromArgb(CByte(60), CByte(72), CByte(82))
        lblProdi.Location = New Point(37, 198)
        lblProdi.Margin = New Padding(5, 0, 5, 0)
        lblProdi.Name = "lblProdi"
        lblProdi.Size = New Size(165, 32)
        lblProdi.TabIndex = 5
        lblProdi.Text = "Program Studi"
        ' 
        ' txtNip
        ' 
        txtNip.BorderStyle = BorderStyle.FixedSingle
        txtNip.Font = New Font("Segoe UI", 9.0F)
        txtNip.Location = New Point(822, 120)
        txtNip.Margin = New Padding(5, 6, 5, 6)
        txtNip.Name = "txtNip"
        txtNip.ReadOnly = True
        txtNip.Size = New Size(314, 39)
        txtNip.TabIndex = 4
        ' 
        ' lblNip
        ' 
        lblNip.AutoSize = True
        lblNip.Font = New Font("Segoe UI", 9.0F)
        lblNip.ForeColor = Color.FromArgb(CByte(60), CByte(72), CByte(82))
        lblNip.Location = New Point(725, 128)
        lblNip.Margin = New Padding(5, 0, 5, 0)
        lblNip.Name = "lblNip"
        lblNip.Size = New Size(51, 32)
        lblNip.TabIndex = 3
        lblNip.Text = "NIP"
        ' 
        ' lblNamaDosen
        ' 
        lblNamaDosen.AutoSize = True
        lblNamaDosen.Font = New Font("Segoe UI", 9.0F)
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
        lblTitle.Font = New Font("Segoe UI Semibold", 14.0F, FontStyle.Bold)
        lblTitle.ForeColor = Color.FromArgb(CByte(60), CByte(72), CByte(82))
        lblTitle.Location = New Point(29, 34)
        lblTitle.Margin = New Padding(5, 0, 5, 0)
        lblTitle.Name = "lblTitle"
        lblTitle.Size = New Size(1799, 64)
        lblTitle.TabIndex = 0
        lblTitle.Text = "Verifikasi Penilaian Perilaku Dosen"
        lblTitle.TextAlign = ContentAlignment.MiddleLeft
        ' 
        ' dgvVerifikasi
        ' 
        dgvVerifikasi.AllowUserToAddRows = False
        dgvVerifikasi.AllowUserToDeleteRows = False
        dgvVerifikasi.AllowUserToResizeRows = False
        DataGridViewCellStyle4.BackColor = Color.FromArgb(CByte(249), CByte(250), CByte(252))
        dgvVerifikasi.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle4
        dgvVerifikasi.BackgroundColor = Color.FromArgb(CByte(245), CByte(240), CByte(232))
        dgvVerifikasi.BorderStyle = BorderStyle.None
        dgvVerifikasi.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.None
        DataGridViewCellStyle5.Alignment = DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle5.BackColor = Color.FromArgb(CByte(207), CByte(208), CByte(200))
        DataGridViewCellStyle5.Font = New Font("Segoe UI", 9.0F, FontStyle.Bold)
        DataGridViewCellStyle5.ForeColor = Color.FromArgb(CByte(60), CByte(72), CByte(82))
        DataGridViewCellStyle5.SelectionBackColor = Color.FromArgb(CByte(194), CByte(210), CByte(221))
        DataGridViewCellStyle5.SelectionForeColor = Color.FromArgb(CByte(60), CByte(72), CByte(82))
        DataGridViewCellStyle5.WrapMode = DataGridViewTriState.False
        dgvVerifikasi.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle5
        dgvVerifikasi.ColumnHeadersHeight = 45
        dgvVerifikasi.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing
        dgvVerifikasi.Columns.AddRange(New DataGridViewColumn() {colNo, colAspek, colIndikator, colNilaiDosen, colNilaiPenilai, colStatus, colCatatan, colBukti, colPenilai})
        DataGridViewCellStyle6.Alignment = DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle6.BackColor = Color.White
        DataGridViewCellStyle6.Font = New Font("Segoe UI", 9.0F)
        DataGridViewCellStyle6.ForeColor = Color.Black
        DataGridViewCellStyle6.SelectionBackColor = Color.FromArgb(CByte(227), CByte(242), CByte(253))
        DataGridViewCellStyle6.SelectionForeColor = Color.Black
        DataGridViewCellStyle6.WrapMode = DataGridViewTriState.False
        dgvVerifikasi.DefaultCellStyle = DataGridViewCellStyle6
        dgvVerifikasi.Dock = DockStyle.Fill
        dgvVerifikasi.EnableHeadersVisualStyles = False
        dgvVerifikasi.GridColor = Color.FromArgb(CByte(207), CByte(208), CByte(200))
        dgvVerifikasi.Location = New Point(0, 309)
        dgvVerifikasi.Margin = New Padding(5, 6, 5, 6)
        dgvVerifikasi.MultiSelect = False
        dgvVerifikasi.Name = "dgvVerifikasi"
        dgvVerifikasi.RowHeadersVisible = False
        dgvVerifikasi.RowHeadersWidth = 51
        dgvVerifikasi.RowTemplate.Height = 26
        dgvVerifikasi.SelectionMode = DataGridViewSelectionMode.FullRowSelect
        dgvVerifikasi.Size = New Size(1857, 864)
        dgvVerifikasi.TabIndex = 1
        ' 
        ' colNo
        ' 
        colNo.HeaderText = "No"
        colNo.MinimumWidth = 6
        colNo.Name = "colNo"
        colNo.ReadOnly = True
        colNo.Width = 40
        ' 
        ' colAspek
        ' 
        colAspek.HeaderText = "Aspek"
        colAspek.MinimumWidth = 6
        colAspek.Name = "colAspek"
        colAspek.ReadOnly = True
        colAspek.Width = 130
        ' 
        ' colIndikator
        ' 
        colIndikator.HeaderText = "Indikator / Pertanyaan"
        colIndikator.MinimumWidth = 6
        colIndikator.Name = "colIndikator"
        colIndikator.ReadOnly = True
        colIndikator.Width = 260
        ' 
        ' colNilaiDosen
        ' 
        colNilaiDosen.HeaderText = "Nilai Dosen"
        colNilaiDosen.MinimumWidth = 6
        colNilaiDosen.Name = "colNilaiDosen"
        colNilaiDosen.ReadOnly = True
        colNilaiDosen.Width = 110
        ' 
        ' colNilaiPenilai
        ' 
        colNilaiPenilai.HeaderText = "Nilai Penilai"
        colNilaiPenilai.MinimumWidth = 6
        colNilaiPenilai.Name = "colNilaiPenilai"
        colNilaiPenilai.Width = 110
        ' 
        ' colStatus
        ' 
        colStatus.DisplayStyle = DataGridViewComboBoxDisplayStyle.ComboBox
        colStatus.HeaderText = "Status"
        colStatus.Items.AddRange(New Object() {"Disetujui", "Ditolak", "Revisi"})
        colStatus.MinimumWidth = 6
        colStatus.Name = "colStatus"
        colStatus.Width = 120
        ' 
        ' colCatatan
        ' 
        colCatatan.HeaderText = "Catatan Penilai"
        colCatatan.MinimumWidth = 6
        colCatatan.Name = "colCatatan"
        colCatatan.Width = 220
        ' 
        ' colBukti
        ' 
        colBukti.HeaderText = "Bukti Pendukung"
        colBukti.MinimumWidth = 6
        colBukti.Name = "colBukti"
        colBukti.Text = "Lihat / Upload..."
        colBukti.UseColumnTextForButtonValue = True
        colBukti.Width = 150
        ' 
        ' colPenilai
        ' 
        colPenilai.HeaderText = "Penilai"
        colPenilai.MinimumWidth = 10
        colPenilai.Name = "colPenilai"
        colPenilai.ReadOnly = True
        colPenilai.Width = 200
        ' 
        ' pnlFooter
        ' 
        pnlFooter.BackColor = Color.FromArgb(CByte(240), CByte(233), CByte(221))
        pnlFooter.Controls.Add(btnTutup)
        pnlFooter.Controls.Add(btnSimpan)
        pnlFooter.Controls.Add(btnSetFinal)
        pnlFooter.Dock = DockStyle.Bottom
        pnlFooter.Location = New Point(0, 1173)
        pnlFooter.Margin = New Padding(5, 6, 5, 6)
        pnlFooter.Name = "pnlFooter"
        pnlFooter.Padding = New Padding(29, 18, 29, 18)
        pnlFooter.Size = New Size(1857, 107)
        pnlFooter.TabIndex = 2
        ' 
        ' btnTutup
        ' 
        btnTutup.Anchor = AnchorStyles.Bottom Or AnchorStyles.Left
        btnTutup.BackColor = Color.White
        btnTutup.FlatAppearance.BorderColor = Color.FromArgb(CByte(211), CByte(47), CByte(47))
        btnTutup.FlatStyle = FlatStyle.Flat
        btnTutup.Font = New Font("Segoe UI", 9.0F)
        btnTutup.ForeColor = Color.FromArgb(CByte(211), CByte(47), CByte(47))
        btnTutup.Location = New Point(29, 24)
        btnTutup.Margin = New Padding(5, 6, 5, 6)
        btnTutup.Name = "btnTutup"
        btnTutup.Size = New Size(167, 59)
        btnTutup.TabIndex = 0
        btnTutup.Text = "Tutup"
        btnTutup.UseVisualStyleBackColor = False
        ' 
        ' btnSimpan
        ' 
        btnSimpan.Anchor = AnchorStyles.Bottom Or AnchorStyles.Right
        btnSimpan.BackColor = Color.FromArgb(CByte(207), CByte(208), CByte(200))
        btnSimpan.FlatAppearance.BorderSize = 0
        btnSimpan.FlatStyle = FlatStyle.Flat
        btnSimpan.Font = New Font("Segoe UI", 9.0F)
        btnSimpan.ForeColor = Color.FromArgb(CByte(60), CByte(72), CByte(82))
        btnSimpan.Location = New Point(1133, 24)
        btnSimpan.Margin = New Padding(5, 6, 5, 6)
        btnSimpan.Name = "btnSimpan"
        btnSimpan.Size = New Size(205, 59)
        btnSimpan.TabIndex = 1
        btnSimpan.Text = "Simpan Draft"
        btnSimpan.UseVisualStyleBackColor = False
        ' 
        ' btnSetFinal
        ' 
        btnSetFinal.Anchor = AnchorStyles.Bottom Or AnchorStyles.Right
        btnSetFinal.BackColor = Color.SkyBlue
        btnSetFinal.FlatAppearance.BorderSize = 0
        btnSetFinal.FlatStyle = FlatStyle.Flat
        btnSetFinal.Font = New Font("Segoe UI", 9.0F, FontStyle.Bold)
        btnSetFinal.ForeColor = Color.White
        btnSetFinal.Location = New Point(1355, 24)
        btnSetFinal.Margin = New Padding(5, 6, 5, 6)
        btnSetFinal.Name = "btnSetFinal"
        btnSetFinal.Size = New Size(471, 59)
        btnSetFinal.TabIndex = 2
        btnSetFinal.Text = "Simpan dan Set Nilai FINAL"
        btnSetFinal.UseVisualStyleBackColor = False
        ' 
        ' FormVerifikasiPenilaian
        ' 
        AcceptButton = btnSetFinal
        AutoScaleDimensions = New SizeF(13.0F, 32.0F)
        AutoScaleMode = AutoScaleMode.Font
        BackColor = Color.FromArgb(CByte(245), CByte(240), CByte(232))
        CancelButton = btnTutup
        ClientSize = New Size(1857, 1280)
        Controls.Add(dgvVerifikasi)
        Controls.Add(pnlFooter)
        Controls.Add(pnlHeader)
        Margin = New Padding(5, 6, 5, 6)
        Name = "FormVerifikasiPenilaian"
        StartPosition = FormStartPosition.CenterScreen
        Text = "Verifikasi Penilaian Perilaku Dosen"
        pnlHeader.ResumeLayout(False)
        pnlHeader.PerformLayout()
        CType(dgvVerifikasi, ComponentModel.ISupportInitialize).EndInit()
        pnlFooter.ResumeLayout(False)
        ResumeLayout(False)

    End Sub

    ' --- Fields ---
    Friend WithEvents pnlHeader As System.Windows.Forms.Panel
    Friend WithEvents lblTitle As System.Windows.Forms.Label
    Friend WithEvents lblNamaDosen As System.Windows.Forms.Label
    Friend WithEvents lblNip As System.Windows.Forms.Label
    Friend WithEvents txtNip As System.Windows.Forms.TextBox
    Friend WithEvents lblProdi As System.Windows.Forms.Label
    Friend WithEvents txtProdi As System.Windows.Forms.TextBox
    Friend WithEvents lblPeriode As System.Windows.Forms.Label

    Friend WithEvents dgvVerifikasi As System.Windows.Forms.DataGridView

    Friend WithEvents pnlFooter As System.Windows.Forms.Panel
    Friend WithEvents btnTutup As System.Windows.Forms.Button
    Friend WithEvents btnSimpan As System.Windows.Forms.Button
    Friend WithEvents btnSetFinal As System.Windows.Forms.Button
    Friend WithEvents BackgroundWorker1 As System.ComponentModel.BackgroundWorker
    Friend WithEvents cboPeriode As ComboBox
    Friend WithEvents cboNamaDosen As ComboBox
    Friend WithEvents colNo As DataGridViewTextBoxColumn
    Friend WithEvents colAspek As DataGridViewTextBoxColumn
    Friend WithEvents colIndikator As DataGridViewTextBoxColumn
    Friend WithEvents colNilaiDosen As DataGridViewTextBoxColumn
    Friend WithEvents colNilaiPenilai As DataGridViewTextBoxColumn
    Friend WithEvents colStatus As DataGridViewComboBoxColumn
    Friend WithEvents colCatatan As DataGridViewTextBoxColumn
    Friend WithEvents colBukti As DataGridViewButtonColumn
    Friend WithEvents colPenilai As DataGridViewTextBoxColumn

End Class
