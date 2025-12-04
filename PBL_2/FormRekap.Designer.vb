<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FormRekap
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Dim DataGridViewCellStyle1 As DataGridViewCellStyle = New DataGridViewCellStyle()
        Dim DataGridViewCellStyle2 As DataGridViewCellStyle = New DataGridViewCellStyle()
        Dim DataGridViewCellStyle3 As DataGridViewCellStyle = New DataGridViewCellStyle()
        pnlHeader = New Panel()
        btnRefresh = New Button()
        cboNamaDosen = New ComboBox()
        cboPeriode = New ComboBox()
        lblPeriode = New Label()
        txtProdi = New TextBox()
        lblProdi = New Label()
        txtNip = New TextBox()
        lblNip = New Label()
        lblNamaDosen = New Label()
        lblTitle = New Label()
        dgvRekap = New DataGridView()
        colNo = New DataGridViewTextBoxColumn()
        colNIP = New DataGridViewTextBoxColumn()
        colNamaDosen = New DataGridViewTextBoxColumn()
        colNilai = New DataGridViewTextBoxColumn()
        colPredikat = New DataGridViewTextBoxColumn()
        pnlFooter = New Panel()
        btnValidasi = New Button()
        btnTutup = New Button()
        btnSimpan = New Button()
        btnSetFinal = New Button()
        pnlHeader.SuspendLayout()
        CType(dgvRekap, ComponentModel.ISupportInitialize).BeginInit()
        pnlFooter.SuspendLayout()
        SuspendLayout()
        ' 
        ' pnlHeader
        ' 
        pnlHeader.BackColor = Color.FromArgb(CByte(240), CByte(233), CByte(221))
        pnlHeader.Controls.Add(btnRefresh)
        pnlHeader.Controls.Add(cboNamaDosen)
        pnlHeader.Controls.Add(cboPeriode)
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
        pnlHeader.Padding = New Padding(16, 16, 16, 16)
        pnlHeader.Size = New Size(1000, 145)
        pnlHeader.TabIndex = 3
        ' 
        ' btnRefresh
        ' 
        btnRefresh.Location = New Point(899, 84)
        btnRefresh.Margin = New Padding(2, 1, 2, 1)
        btnRefresh.Name = "btnRefresh"
        btnRefresh.Size = New Size(75, 44)
        btnRefresh.TabIndex = 13
        btnRefresh.Text = "🔁" & vbCrLf & "Refresh" & vbCrLf
        btnRefresh.UseVisualStyleBackColor = True
        ' 
        ' cboNamaDosen
        ' 
        cboNamaDosen.FormattingEnabled = True
        cboNamaDosen.Location = New Point(110, 57)
        cboNamaDosen.Margin = New Padding(2, 1, 2, 1)
        cboNamaDosen.Name = "cboNamaDosen"
        cboNamaDosen.Size = New Size(261, 23)
        cboNamaDosen.TabIndex = 12
        ' 
        ' cboPeriode
        ' 
        cboPeriode.FormattingEnabled = True
        cboPeriode.Location = New Point(453, 92)
        cboPeriode.Margin = New Padding(2, 1, 2, 1)
        cboPeriode.Name = "cboPeriode"
        cboPeriode.Size = New Size(171, 23)
        cboPeriode.TabIndex = 11
        ' 
        ' lblPeriode
        ' 
        lblPeriode.AutoSize = True
        lblPeriode.Font = New Font("Segoe UI", 9F)
        lblPeriode.ForeColor = Color.FromArgb(CByte(60), CByte(72), CByte(82))
        lblPeriode.Location = New Point(397, 92)
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
        lblProdi.Location = New Point(16, 89)
        lblProdi.Name = "lblProdi"
        lblProdi.Size = New Size(83, 15)
        lblProdi.TabIndex = 5
        lblProdi.Text = "Program Studi"
        ' 
        ' txtNip
        ' 
        txtNip.BorderStyle = BorderStyle.FixedSingle
        txtNip.Font = New Font("Segoe UI", 9F)
        txtNip.Location = New Point(453, 59)
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
        lblNip.Location = New Point(397, 60)
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
        lblNamaDosen.Location = New Point(16, 57)
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
        lblTitle.Size = New Size(968, 30)
        lblTitle.TabIndex = 0
        lblTitle.Text = "VALIDASI PENILAIAN KINERJA DOSEN"
        lblTitle.TextAlign = ContentAlignment.MiddleLeft
        ' 
        ' dgvRekap
        ' 
        dgvRekap.AllowUserToAddRows = False
        dgvRekap.AllowUserToDeleteRows = False
        dgvRekap.AllowUserToResizeRows = False
        DataGridViewCellStyle1.BackColor = Color.FromArgb(CByte(249), CByte(250), CByte(252))
        dgvRekap.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle1
        dgvRekap.BackgroundColor = Color.FromArgb(CByte(245), CByte(240), CByte(232))
        dgvRekap.BorderStyle = BorderStyle.None
        dgvRekap.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.None
        DataGridViewCellStyle2.Alignment = DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle2.BackColor = Color.FromArgb(CByte(207), CByte(208), CByte(200))
        DataGridViewCellStyle2.Font = New Font("Segoe UI", 9F, FontStyle.Bold)
        DataGridViewCellStyle2.ForeColor = Color.FromArgb(CByte(60), CByte(72), CByte(82))
        DataGridViewCellStyle2.SelectionBackColor = Color.FromArgb(CByte(194), CByte(210), CByte(221))
        DataGridViewCellStyle2.SelectionForeColor = Color.FromArgb(CByte(60), CByte(72), CByte(82))
        DataGridViewCellStyle2.WrapMode = DataGridViewTriState.False
        dgvRekap.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle2
        dgvRekap.ColumnHeadersHeight = 45
        dgvRekap.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing
        dgvRekap.Columns.AddRange(New DataGridViewColumn() {colNo, colNIP, colNamaDosen, colNilai, colPredikat})
        DataGridViewCellStyle3.Alignment = DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle3.BackColor = Color.White
        DataGridViewCellStyle3.Font = New Font("Segoe UI", 9F)
        DataGridViewCellStyle3.ForeColor = Color.Black
        DataGridViewCellStyle3.SelectionBackColor = Color.FromArgb(CByte(227), CByte(242), CByte(253))
        DataGridViewCellStyle3.SelectionForeColor = Color.Black
        DataGridViewCellStyle3.WrapMode = DataGridViewTriState.False
        dgvRekap.DefaultCellStyle = DataGridViewCellStyle3
        dgvRekap.Dock = DockStyle.Fill
        dgvRekap.EnableHeadersVisualStyles = False
        dgvRekap.GridColor = Color.FromArgb(CByte(207), CByte(208), CByte(200))
        dgvRekap.Location = New Point(0, 145)
        dgvRekap.MultiSelect = False
        dgvRekap.Name = "dgvRekap"
        dgvRekap.RowHeadersVisible = False
        dgvRekap.RowHeadersWidth = 51
        dgvRekap.RowTemplate.Height = 26
        dgvRekap.SelectionMode = DataGridViewSelectionMode.FullRowSelect
        dgvRekap.Size = New Size(1000, 352)
        dgvRekap.TabIndex = 4
        ' 
        ' colNo
        ' 
        colNo.HeaderText = "No"
        colNo.MinimumWidth = 6
        colNo.Name = "colNo"
        colNo.ReadOnly = True
        colNo.Width = 40
        ' 
        ' colNIP
        ' 
        colNIP.HeaderText = "NIP"
        colNIP.MinimumWidth = 6
        colNIP.Name = "colNIP"
        colNIP.ReadOnly = True
        colNIP.Width = 130
        ' 
        ' colNamaDosen
        ' 
        colNamaDosen.HeaderText = "Nama Dosen"
        colNamaDosen.MinimumWidth = 6
        colNamaDosen.Name = "colNamaDosen"
        colNamaDosen.ReadOnly = True
        colNamaDosen.Width = 260
        ' 
        ' colNilai
        ' 
        colNilai.HeaderText = "Nilai "
        colNilai.MinimumWidth = 6
        colNilai.Name = "colNilai"
        colNilai.ReadOnly = True
        colNilai.Width = 110
        ' 
        ' colPredikat
        ' 
        colPredikat.HeaderText = "Predikat"
        colPredikat.MinimumWidth = 6
        colPredikat.Name = "colPredikat"
        colPredikat.Width = 110
        ' 
        ' pnlFooter
        ' 
        pnlFooter.BackColor = Color.FromArgb(CByte(240), CByte(233), CByte(221))
        pnlFooter.Controls.Add(btnValidasi)
        pnlFooter.Controls.Add(btnTutup)
        pnlFooter.Controls.Add(btnSimpan)
        pnlFooter.Controls.Add(btnSetFinal)
        pnlFooter.Dock = DockStyle.Bottom
        pnlFooter.Location = New Point(0, 447)
        pnlFooter.Name = "pnlFooter"
        pnlFooter.Padding = New Padding(16, 8, 16, 8)
        pnlFooter.Size = New Size(1000, 50)
        pnlFooter.TabIndex = 5
        ' 
        ' btnValidasi
        ' 
        btnValidasi.BackColor = Color.SkyBlue
        btnValidasi.ForeColor = Color.White
        btnValidasi.Location = New Point(782, 8)
        btnValidasi.Margin = New Padding(2, 1, 2, 1)
        btnValidasi.Name = "btnValidasi"
        btnValidasi.Size = New Size(172, 32)
        btnValidasi.TabIndex = 3
        btnValidasi.Text = "Validasi"
        btnValidasi.UseVisualStyleBackColor = False
        ' 
        ' btnTutup
        ' 
        btnTutup.Anchor = AnchorStyles.Bottom Or AnchorStyles.Left
        btnTutup.BackColor = Color.White
        btnTutup.FlatAppearance.BorderColor = Color.FromArgb(CByte(211), CByte(47), CByte(47))
        btnTutup.FlatStyle = FlatStyle.Flat
        btnTutup.Font = New Font("Segoe UI", 9F)
        btnTutup.ForeColor = Color.FromArgb(CByte(211), CByte(47), CByte(47))
        btnTutup.Location = New Point(31, 6)
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
        btnSimpan.Location = New Point(1487, 6)
        btnSimpan.Name = "btnSimpan"
        btnSimpan.Size = New Size(110, 28)
        btnSimpan.TabIndex = 1
        btnSimpan.Text = "Simpan Draft"
        btnSimpan.UseVisualStyleBackColor = False
        ' 
        ' btnSetFinal
        ' 
        btnSetFinal.Anchor = AnchorStyles.Bottom Or AnchorStyles.Right
        btnSetFinal.BackColor = Color.FromArgb(CByte(194), CByte(210), CByte(221))
        btnSetFinal.FlatAppearance.BorderSize = 0
        btnSetFinal.FlatStyle = FlatStyle.Flat
        btnSetFinal.Font = New Font("Segoe UI", 9F, FontStyle.Bold)
        btnSetFinal.ForeColor = Color.White
        btnSetFinal.Location = New Point(1606, 6)
        btnSetFinal.Name = "btnSetFinal"
        btnSetFinal.Size = New Size(254, 28)
        btnSetFinal.TabIndex = 2
        btnSetFinal.Text = "Simpan dan Set Nilai FINAL"
        btnSetFinal.UseVisualStyleBackColor = False
        ' 
        ' FormRekap
        ' 
        AutoScaleDimensions = New SizeF(7F, 15F)
        AutoScaleMode = AutoScaleMode.Font
        ClientSize = New Size(1000, 497)
        Controls.Add(pnlFooter)
        Controls.Add(dgvRekap)
        Controls.Add(pnlHeader)
        Margin = New Padding(2, 1, 2, 1)
        Name = "FormRekap"
        Text = "FormRekap"
        pnlHeader.ResumeLayout(False)
        pnlHeader.PerformLayout()
        CType(dgvRekap, ComponentModel.ISupportInitialize).EndInit()
        pnlFooter.ResumeLayout(False)
        ResumeLayout(False)
    End Sub
    Friend WithEvents pnlHeader As Panel
    Friend WithEvents cboNamaDosen As ComboBox
    Friend WithEvents cboPeriode As ComboBox
    Friend WithEvents lblPeriode As Label
    Friend WithEvents txtProdi As TextBox
    Friend WithEvents lblProdi As Label
    Friend WithEvents txtNip As TextBox
    Friend WithEvents lblNip As Label
    Friend WithEvents lblNamaDosen As Label
    Friend WithEvents lblTitle As Label
    Friend WithEvents btnRefresh As Button
    Friend WithEvents dgvRekap As DataGridView
    Friend WithEvents colNo As DataGridViewTextBoxColumn
    Friend WithEvents colNIP As DataGridViewTextBoxColumn
    Friend WithEvents colNamaDosen As DataGridViewTextBoxColumn
    Friend WithEvents colNilai As DataGridViewTextBoxColumn
    Friend WithEvents colPredikat As DataGridViewTextBoxColumn
    Friend WithEvents pnlFooter As Panel
    Friend WithEvents btnTutup As Button
    Friend WithEvents btnSimpan As Button
    Friend WithEvents btnSetFinal As Button
    Friend WithEvents btnValidasi As Button
End Class
