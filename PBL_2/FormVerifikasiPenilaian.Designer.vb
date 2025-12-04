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
        Dim DataGridViewCellStyle1 As DataGridViewCellStyle = New DataGridViewCellStyle()
        Dim DataGridViewCellStyle2 As DataGridViewCellStyle = New DataGridViewCellStyle()
        Dim DataGridViewCellStyle3 As DataGridViewCellStyle = New DataGridViewCellStyle()
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
        pnlHeader.Name = "pnlHeader"

        pnlHeader.Padding = New Padding(16)
        pnlHeader.Size = New Size(1233, 145)

        pnlHeader.Padding = New Padding(16, 16, 16, 16)
        pnlHeader.Size = New Size(738, 145)

        pnlHeader.TabIndex = 0
        ' 
        ' cboPeriode
        ' 
        cboPeriode.FormattingEnabled = True
        cboPeriode.Location = New Point(443, 91)
        cboPeriode.Margin = New Padding(2, 1, 2, 1)
        cboPeriode.Name = "cboPeriode"
        cboPeriode.Size = New Size(171, 23)
        cboPeriode.TabIndex = 12
        ' 
        ' cboNamaDosen
        ' 
        cboNamaDosen.FormattingEnabled = True
        cboNamaDosen.Location = New Point(110, 59)
        cboNamaDosen.Margin = New Padding(2, 1, 2, 1)
        cboNamaDosen.Name = "cboNamaDosen"
        cboNamaDosen.Size = New Size(261, 23)
        cboNamaDosen.TabIndex = 11
        ' 
        ' lblPeriode
        ' 
        lblPeriode.AutoSize = True
        lblPeriode.Font = New Font("Segoe UI", 9F)
        lblPeriode.ForeColor = Color.FromArgb(CByte(60), CByte(72), CByte(82))
        lblPeriode.Location = New Point(390, 93)
        lblPeriode.Name = "lblPeriode"
        lblPeriode.Size = New Size(47, 15)
        lblPeriode.TabIndex = 7
        lblPeriode.Text = "Periode"
        ' 
        ' txtProdi
        ' 
        txtProdi.BorderStyle = BorderStyle.FixedSingle
        txtProdi.Font = New Font("Segoe UI", 9F)
        txtProdi.Location = New Point(110, 89)
        txtProdi.Name = "txtProdi"
        txtProdi.ReadOnly = True
        txtProdi.Size = New Size(260, 23)
        txtProdi.TabIndex = 6
        ' 
        ' lblProdi
        ' 
        lblProdi.AutoSize = True
        lblProdi.Font = New Font("Segoe UI", 9F)
        lblProdi.ForeColor = Color.FromArgb(CByte(60), CByte(72), CByte(82))
        lblProdi.Location = New Point(20, 93)
        lblProdi.Name = "lblProdi"
        lblProdi.Size = New Size(83, 15)
        lblProdi.TabIndex = 5
        lblProdi.Text = "Program Studi"
        ' 
        ' txtNip
        ' 
        txtNip.BorderStyle = BorderStyle.FixedSingle
        txtNip.Font = New Font("Segoe UI", 9F)
        txtNip.Location = New Point(443, 56)
        txtNip.Name = "txtNip"
        txtNip.ReadOnly = True
        txtNip.Size = New Size(170, 23)
        txtNip.TabIndex = 4
        ' 
        ' lblNip
        ' 
        lblNip.AutoSize = True
        lblNip.Font = New Font("Segoe UI", 9F)
        lblNip.ForeColor = Color.FromArgb(CByte(60), CByte(72), CByte(82))
        lblNip.Location = New Point(390, 60)
        lblNip.Name = "lblNip"
        lblNip.Size = New Size(26, 15)
        lblNip.TabIndex = 3
        lblNip.Text = "NIP"
        ' 
        ' lblNamaDosen
        ' 
        lblNamaDosen.AutoSize = True
        lblNamaDosen.Font = New Font("Segoe UI", 9F)
        lblNamaDosen.ForeColor = Color.FromArgb(CByte(60), CByte(72), CByte(82))
        lblNamaDosen.Location = New Point(20, 60)
        lblNamaDosen.Name = "lblNamaDosen"
        lblNamaDosen.Size = New Size(75, 15)
        lblNamaDosen.TabIndex = 1
        lblNamaDosen.Text = "Nama Dosen"
        ' 
        ' lblTitle
        ' 
        lblTitle.Dock = DockStyle.Top
        lblTitle.Font = New Font("Segoe UI Semibold", 14F, FontStyle.Bold)
        lblTitle.ForeColor = Color.FromArgb(CByte(60), CByte(72), CByte(82))
        lblTitle.Location = New Point(16, 16)
        lblTitle.Name = "lblTitle"

        lblTitle.Size = New Size(1201, 30)

        lblTitle.Size = New Size(706, 30)

        lblTitle.TabIndex = 0
        lblTitle.Text = "Verifikasi Penilaian Perilaku Dosen"
        lblTitle.TextAlign = ContentAlignment.MiddleLeft
        ' 
        ' dgvVerifikasi
        ' 
        dgvVerifikasi.AllowUserToAddRows = False
        dgvVerifikasi.AllowUserToDeleteRows = False
        dgvVerifikasi.AllowUserToResizeRows = False
        DataGridViewCellStyle1.BackColor = Color.FromArgb(CByte(249), CByte(250), CByte(252))
        dgvVerifikasi.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle1
        dgvVerifikasi.BackgroundColor = Color.FromArgb(CByte(245), CByte(240), CByte(232))
        dgvVerifikasi.BorderStyle = BorderStyle.None
        dgvVerifikasi.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.None
        DataGridViewCellStyle2.Alignment = DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle2.BackColor = Color.FromArgb(CByte(207), CByte(208), CByte(200))
        DataGridViewCellStyle2.Font = New Font("Segoe UI", 9F, FontStyle.Bold)
        DataGridViewCellStyle2.ForeColor = Color.FromArgb(CByte(60), CByte(72), CByte(82))
        DataGridViewCellStyle2.SelectionBackColor = Color.FromArgb(CByte(194), CByte(210), CByte(221))
        DataGridViewCellStyle2.SelectionForeColor = Color.FromArgb(CByte(60), CByte(72), CByte(82))
        DataGridViewCellStyle2.WrapMode = DataGridViewTriState.False
        dgvVerifikasi.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle2
        dgvVerifikasi.ColumnHeadersHeight = 45
        dgvVerifikasi.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing
        dgvVerifikasi.Columns.AddRange(New DataGridViewColumn() {colNo, colAspek, colIndikator, colNilaiDosen, colNilaiPenilai, colStatus, colCatatan, colBukti, colPenilai})
        DataGridViewCellStyle3.Alignment = DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle3.BackColor = Color.White
        DataGridViewCellStyle3.Font = New Font("Segoe UI", 9F)
        DataGridViewCellStyle3.ForeColor = Color.Black
        DataGridViewCellStyle3.SelectionBackColor = Color.FromArgb(CByte(227), CByte(242), CByte(253))
        DataGridViewCellStyle3.SelectionForeColor = Color.Black
        DataGridViewCellStyle3.WrapMode = DataGridViewTriState.False
        dgvVerifikasi.DefaultCellStyle = DataGridViewCellStyle3
        dgvVerifikasi.Dock = DockStyle.Fill
        dgvVerifikasi.EnableHeadersVisualStyles = False
        dgvVerifikasi.GridColor = Color.FromArgb(CByte(207), CByte(208), CByte(200))
        dgvVerifikasi.Location = New Point(0, 145)
        dgvVerifikasi.MultiSelect = False
        dgvVerifikasi.Name = "dgvVerifikasi"
        dgvVerifikasi.RowHeadersVisible = False
        dgvVerifikasi.RowHeadersWidth = 51
        dgvVerifikasi.RowTemplate.Height = 26
        dgvVerifikasi.SelectionMode = DataGridViewSelectionMode.FullRowSelect

        dgvVerifikasi.Size = New Size(1233, 302)

        dgvVerifikasi.Size = New Size(738, 156)

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

        pnlFooter.Location = New Point(0, 447)
        pnlFooter.Name = "pnlFooter"
        pnlFooter.Padding = New Padding(16, 8, 16, 8)
        pnlFooter.Size = New Size(1233, 50)

        pnlFooter.Location = New Point(0, 301)
        pnlFooter.Name = "pnlFooter"
        pnlFooter.Padding = New Padding(16, 8, 16, 8)
        pnlFooter.Size = New Size(738, 50)

        pnlFooter.TabIndex = 2
        ' 
        ' btnTutup
        ' 
        btnTutup.Anchor = AnchorStyles.Bottom Or AnchorStyles.Left
        btnTutup.BackColor = Color.White
        btnTutup.FlatAppearance.BorderColor = Color.FromArgb(CByte(211), CByte(47), CByte(47))
        btnTutup.FlatStyle = FlatStyle.Flat
        btnTutup.Font = New Font("Segoe UI", 9F)
        btnTutup.ForeColor = Color.FromArgb(CByte(211), CByte(47), CByte(47))
        btnTutup.Location = New Point(16, 11)
        btnTutup.Name = "btnTutup"
        btnTutup.Size = New Size(90, 28)
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
        btnSimpan.Font = New Font("Segoe UI", 9F)
        btnSimpan.ForeColor = Color.FromArgb(CByte(60), CByte(72), CByte(82))

        btnSimpan.Location = New Point(843, 11)

        btnSimpan.Location = New Point(348, 11)

        btnSimpan.Name = "btnSimpan"
        btnSimpan.Size = New Size(110, 28)
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
        btnSetFinal.Font = New Font("Segoe UI", 9F, FontStyle.Bold)
        btnSetFinal.ForeColor = Color.White

        btnSetFinal.Location = New Point(963, 11)

        btnSetFinal.Location = New Point(468, 11)

        btnSetFinal.Name = "btnSetFinal"
        btnSetFinal.Size = New Size(254, 28)
        btnSetFinal.TabIndex = 2
        btnSetFinal.Text = "Simpan dan Set Nilai FINAL"
        btnSetFinal.UseVisualStyleBackColor = False
        ' 
        ' FormVerifikasiPenilaian
        ' 
        AcceptButton = btnSetFinal
        AutoScaleDimensions = New SizeF(7F, 15F)
        AutoScaleMode = AutoScaleMode.Font
        BackColor = Color.FromArgb(CByte(245), CByte(240), CByte(232))
        CancelButton = btnTutup

        ClientSize = New Size(1233, 497)

        ClientSize = New Size(738, 351)

        Controls.Add(dgvVerifikasi)
        Controls.Add(pnlFooter)
        Controls.Add(pnlHeader)
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
