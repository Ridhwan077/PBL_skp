<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class FormRegistrasiDosen
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
        pnlForm = New Panel()
        lblTitle = New Label()
        lblSubTitle = New Label()
        lblNIP = New Label()
        txtNIP = New TextBox()
        lblNama = New Label()
        txtNama = New TextBox()
        lblProdi = New Label()
        cboProdi = New ComboBox()
        lblEmail = New Label()
        txtEmail = New TextBox()
        lblNoHP = New Label()
        txtNoHP = New TextBox()
        lblPassword = New Label()
        txtPassword = New TextBox()
        lblKonfirmasi = New Label()
        txtKonfirmasi = New TextBox()
        btnBatal = New Button()
        btnReset = New Button()
        btnSimpan = New Button()
        pnlSide = New Panel()
        lblWelcomeTitle = New Label()
        lblWelcomeSub = New Label()
        pnlForm.SuspendLayout()
        pnlSide.SuspendLayout()
        SuspendLayout()
        ' 
        ' pnlForm
        ' 
        pnlForm.BackColor = Color.FromArgb(CByte(245), CByte(240), CByte(232))
        pnlForm.Controls.Add(lblTitle)
        pnlForm.Controls.Add(lblSubTitle)
        pnlForm.Controls.Add(lblNIP)
        pnlForm.Controls.Add(txtNIP)
        pnlForm.Controls.Add(lblNama)
        pnlForm.Controls.Add(txtNama)
        pnlForm.Controls.Add(lblProdi)
        pnlForm.Controls.Add(cboProdi)
        pnlForm.Controls.Add(lblEmail)
        pnlForm.Controls.Add(txtEmail)
        pnlForm.Controls.Add(lblNoHP)
        pnlForm.Controls.Add(txtNoHP)
        pnlForm.Controls.Add(lblPassword)
        pnlForm.Controls.Add(txtPassword)
        pnlForm.Controls.Add(lblKonfirmasi)
        pnlForm.Controls.Add(txtKonfirmasi)
        pnlForm.Controls.Add(btnBatal)
        pnlForm.Controls.Add(btnReset)
        pnlForm.Controls.Add(btnSimpan)
        pnlForm.Dock = DockStyle.Fill
        pnlForm.Location = New Point(0, 0)
        pnlForm.Margin = New Padding(5)
        pnlForm.Name = "pnlForm"
        pnlForm.Padding = New Padding(65, 64, 65, 64)
        pnlForm.Size = New Size(749, 832)
        pnlForm.TabIndex = 0
        ' 
        ' lblTitle
        ' 
        lblTitle.AutoSize = True
        lblTitle.Font = New Font("Segoe UI Semibold", 16F, FontStyle.Bold)
        lblTitle.ForeColor = Color.FromArgb(CByte(60), CByte(72), CByte(82))
        lblTitle.Location = New Point(65, 64)
        lblTitle.Margin = New Padding(5, 0, 5, 0)
        lblTitle.Name = "lblTitle"
        lblTitle.Size = New Size(350, 59)
        lblTitle.TabIndex = 0
        lblTitle.Text = "Registrasi Dosen"
        ' 
        ' lblSubTitle
        ' 
        lblSubTitle.AutoSize = True
        lblSubTitle.Font = New Font("Segoe UI", 9F)
        lblSubTitle.ForeColor = Color.FromArgb(CByte(120), CByte(120), CByte(120))
        lblSubTitle.Location = New Point(68, 128)
        lblSubTitle.Margin = New Padding(5, 0, 5, 0)
        lblSubTitle.Name = "lblSubTitle"
        lblSubTitle.Size = New Size(554, 32)
        lblSubTitle.TabIndex = 1
        lblSubTitle.Text = "Masukkan data di bawah ini untuk membuat akun."
        ' 
        ' lblNIP
        ' 
        lblNIP.AutoSize = True
        lblNIP.Font = New Font("Segoe UI", 9F)
        lblNIP.ForeColor = Color.FromArgb(CByte(60), CByte(72), CByte(82))
        lblNIP.Location = New Point(68, 192)
        lblNIP.Margin = New Padding(5, 0, 5, 0)
        lblNIP.Name = "lblNIP"
        lblNIP.Size = New Size(51, 32)
        lblNIP.TabIndex = 2
        lblNIP.Text = "NIP"
        ' 
        ' txtNIP
        ' 
        txtNIP.Anchor = AnchorStyles.Top Or AnchorStyles.Left Or AnchorStyles.Right
        txtNIP.BorderStyle = BorderStyle.FixedSingle
        txtNIP.Font = New Font("Segoe UI", 9F)
        txtNIP.Location = New Point(260, 184)
        txtNIP.Margin = New Padding(5)
        txtNIP.Name = "txtNIP"
        txtNIP.Size = New Size(358, 39)
        txtNIP.TabIndex = 3
        ' 
        ' lblNama
        ' 
        lblNama.AutoSize = True
        lblNama.Font = New Font("Segoe UI", 9F)
        lblNama.ForeColor = Color.FromArgb(CByte(60), CByte(72), CByte(82))
        lblNama.Location = New Point(68, 256)
        lblNama.Margin = New Padding(5, 0, 5, 0)
        lblNama.Name = "lblNama"
        lblNama.Size = New Size(152, 32)
        lblNama.TabIndex = 4
        lblNama.Text = "Nama Dosen"
        ' 
        ' txtNama
        ' 
        txtNama.Anchor = AnchorStyles.Top Or AnchorStyles.Left Or AnchorStyles.Right
        txtNama.BorderStyle = BorderStyle.FixedSingle
        txtNama.Font = New Font("Segoe UI", 9F)
        txtNama.Location = New Point(260, 248)
        txtNama.Margin = New Padding(5)
        txtNama.Name = "txtNama"
        txtNama.Size = New Size(358, 39)
        txtNama.TabIndex = 5
        ' 
        ' lblProdi
        ' 
        lblProdi.AutoSize = True
        lblProdi.Font = New Font("Segoe UI", 9F)
        lblProdi.ForeColor = Color.FromArgb(CByte(60), CByte(72), CByte(82))
        lblProdi.Location = New Point(68, 320)
        lblProdi.Margin = New Padding(5, 0, 5, 0)
        lblProdi.Name = "lblProdi"
        lblProdi.Size = New Size(165, 32)
        lblProdi.TabIndex = 6
        lblProdi.Text = "Program Studi"
        ' 
        ' cboProdi
        ' 
        cboProdi.Anchor = AnchorStyles.Top Or AnchorStyles.Left Or AnchorStyles.Right
        cboProdi.DropDownStyle = ComboBoxStyle.DropDownList
        cboProdi.Font = New Font("Segoe UI", 9F)
        cboProdi.Items.AddRange(New Object() {"TI", "TMD", "TMJ"})
        cboProdi.Location = New Point(260, 312)
        cboProdi.Margin = New Padding(5)
        cboProdi.Name = "cboProdi"
        cboProdi.Size = New Size(357, 40)
        cboProdi.TabIndex = 7
        ' 
        ' lblEmail
        ' 
        lblEmail.AutoSize = True
        lblEmail.Font = New Font("Segoe UI", 9F)
        lblEmail.ForeColor = Color.FromArgb(CByte(60), CByte(72), CByte(82))
        lblEmail.Location = New Point(68, 384)
        lblEmail.Margin = New Padding(5, 0, 5, 0)
        lblEmail.Name = "lblEmail"
        lblEmail.Size = New Size(71, 32)
        lblEmail.TabIndex = 8
        lblEmail.Text = "Email"
        ' 
        ' txtEmail
        ' 
        txtEmail.Anchor = AnchorStyles.Top Or AnchorStyles.Left Or AnchorStyles.Right
        txtEmail.BorderStyle = BorderStyle.FixedSingle
        txtEmail.Font = New Font("Segoe UI", 9F)
        txtEmail.Location = New Point(260, 376)
        txtEmail.Margin = New Padding(5)
        txtEmail.Name = "txtEmail"
        txtEmail.Size = New Size(358, 39)
        txtEmail.TabIndex = 9
        ' 
        ' lblNoHP
        ' 
        lblNoHP.AutoSize = True
        lblNoHP.Font = New Font("Segoe UI", 9F)
        lblNoHP.ForeColor = Color.FromArgb(CByte(60), CByte(72), CByte(82))
        lblNoHP.Location = New Point(68, 448)
        lblNoHP.Margin = New Padding(5, 0, 5, 0)
        lblNoHP.Name = "lblNoHP"
        lblNoHP.Size = New Size(155, 32)
        lblNoHP.TabIndex = 10
        lblNoHP.Text = "No. HP / Telp"
        ' 
        ' txtNoHP
        ' 
        txtNoHP.Anchor = AnchorStyles.Top Or AnchorStyles.Left Or AnchorStyles.Right
        txtNoHP.BorderStyle = BorderStyle.FixedSingle
        txtNoHP.Font = New Font("Segoe UI", 9F)
        txtNoHP.Location = New Point(260, 440)
        txtNoHP.Margin = New Padding(5)
        txtNoHP.Name = "txtNoHP"
        txtNoHP.Size = New Size(358, 39)
        txtNoHP.TabIndex = 11
        ' 
        ' lblPassword
        ' 
        lblPassword.AutoSize = True
        lblPassword.Font = New Font("Segoe UI", 9F)
        lblPassword.ForeColor = Color.FromArgb(CByte(60), CByte(72), CByte(82))
        lblPassword.Location = New Point(68, 512)
        lblPassword.Margin = New Padding(5, 0, 5, 0)
        lblPassword.Name = "lblPassword"
        lblPassword.Size = New Size(111, 32)
        lblPassword.TabIndex = 12
        lblPassword.Text = "Password"
        ' 
        ' txtPassword
        ' 
        txtPassword.Anchor = AnchorStyles.Top Or AnchorStyles.Left Or AnchorStyles.Right
        txtPassword.BorderStyle = BorderStyle.FixedSingle
        txtPassword.Font = New Font("Segoe UI", 9F)
        txtPassword.Location = New Point(260, 504)
        txtPassword.Margin = New Padding(5)
        txtPassword.Name = "txtPassword"
        txtPassword.PasswordChar = "*"c
        txtPassword.Size = New Size(358, 39)
        txtPassword.TabIndex = 13
        ' 
        ' lblKonfirmasi
        ' 
        lblKonfirmasi.AutoSize = True
        lblKonfirmasi.Font = New Font("Segoe UI", 9F)
        lblKonfirmasi.ForeColor = Color.FromArgb(CByte(60), CByte(72), CByte(82))
        lblKonfirmasi.Location = New Point(68, 576)
        lblKonfirmasi.Margin = New Padding(5, 0, 5, 0)
        lblKonfirmasi.Name = "lblKonfirmasi"
        lblKonfirmasi.Size = New Size(230, 32)
        lblKonfirmasi.TabIndex = 14
        lblKonfirmasi.Text = "Konfirmasi Password"
        ' 
        ' txtKonfirmasi
        ' 
        txtKonfirmasi.Anchor = AnchorStyles.Top Or AnchorStyles.Left Or AnchorStyles.Right
        txtKonfirmasi.BorderStyle = BorderStyle.FixedSingle
        txtKonfirmasi.Font = New Font("Segoe UI", 9F)
        txtKonfirmasi.Location = New Point(312, 568)
        txtKonfirmasi.Margin = New Padding(5)
        txtKonfirmasi.Name = "txtKonfirmasi"
        txtKonfirmasi.PasswordChar = "*"c
        txtKonfirmasi.Size = New Size(306, 39)
        txtKonfirmasi.TabIndex = 15
        ' 
        ' btnBatal
        ' 
        btnBatal.Anchor = AnchorStyles.Bottom Or AnchorStyles.Left
        btnBatal.BackColor = Color.White
        btnBatal.FlatAppearance.BorderColor = Color.FromArgb(CByte(211), CByte(47), CByte(47))
        btnBatal.FlatStyle = FlatStyle.Flat
        btnBatal.Font = New Font("Segoe UI", 9F)
        btnBatal.ForeColor = Color.FromArgb(CByte(211), CByte(47), CByte(47))
        btnBatal.Location = New Point(65, 688)
        btnBatal.Margin = New Padding(5)
        btnBatal.Name = "btnBatal"
        btnBatal.Size = New Size(146, 54)
        btnBatal.TabIndex = 16
        btnBatal.Text = "Batal"
        btnBatal.UseVisualStyleBackColor = False
        ' 
        ' btnReset
        ' 
        btnReset.Anchor = AnchorStyles.Bottom Or AnchorStyles.Right
        btnReset.BackColor = Color.White
        btnReset.FlatAppearance.BorderColor = Color.FromArgb(CByte(194), CByte(210), CByte(221))
        btnReset.FlatStyle = FlatStyle.Flat
        btnReset.Font = New Font("Segoe UI", 9F)
        btnReset.ForeColor = Color.FromArgb(CByte(60), CByte(72), CByte(82))
        btnReset.Location = New Point(271, 688)
        btnReset.Margin = New Padding(5)
        btnReset.Name = "btnReset"
        btnReset.Size = New Size(146, 54)
        btnReset.TabIndex = 17
        btnReset.Text = "Reset"
        btnReset.UseVisualStyleBackColor = False
        ' 
        ' btnSimpan
        ' 
        btnSimpan.Anchor = AnchorStyles.Bottom Or AnchorStyles.Right
        btnSimpan.BackColor = Color.LightSteelBlue
        btnSimpan.FlatAppearance.BorderSize = 0
        btnSimpan.FlatStyle = FlatStyle.Flat
        btnSimpan.Font = New Font("Segoe UI", 9F, FontStyle.Bold)
        btnSimpan.ForeColor = Color.White
        btnSimpan.Location = New Point(427, 688)
        btnSimpan.Margin = New Padding(5)
        btnSimpan.Name = "btnSimpan"
        btnSimpan.Size = New Size(192, 54)
        btnSimpan.TabIndex = 18
        btnSimpan.Text = "Daftar"
        btnSimpan.UseVisualStyleBackColor = False
        ' 
        ' pnlSide
        ' 
        pnlSide.BackColor = Color.FromArgb(CByte(119), CByte(149), CByte(189))
        pnlSide.Controls.Add(lblWelcomeTitle)
        pnlSide.Controls.Add(lblWelcomeSub)
        pnlSide.Dock = DockStyle.Right
        pnlSide.Location = New Point(749, 0)
        pnlSide.Margin = New Padding(5)
        pnlSide.Name = "pnlSide"
        pnlSide.Padding = New Padding(52, 64, 52, 64)
        pnlSide.Size = New Size(551, 832)
        pnlSide.TabIndex = 1
        ' 
        ' lblWelcomeTitle
        ' 
        lblWelcomeTitle.Anchor = AnchorStyles.None
        lblWelcomeTitle.Font = New Font("Segoe UI Semibold", 20.0F, FontStyle.Bold)
        lblWelcomeTitle.ForeColor = Color.White
        lblWelcomeTitle.Location = New Point(99, 256)
        lblWelcomeTitle.Margin = New Padding(5, 0, 5, 0)
        lblWelcomeTitle.Name = "lblWelcomeTitle"
        lblWelcomeTitle.Size = New Size(403, 96)
        lblWelcomeTitle.TabIndex = 0
        lblWelcomeTitle.Text = "Hallo, Dosen!"
        lblWelcomeTitle.TextAlign = ContentAlignment.MiddleLeft
        ' 
        ' lblWelcomeSub
        ' 
        lblWelcomeSub.Anchor = AnchorStyles.None
        lblWelcomeSub.Font = New Font("Segoe UI", 10F)
        lblWelcomeSub.ForeColor = Color.WhiteSmoke
        lblWelcomeSub.Location = New Point(99, 352)
        lblWelcomeSub.Margin = New Padding(5, 0, 5, 0)
        lblWelcomeSub.Name = "lblWelcomeSub"
        lblWelcomeSub.Size = New Size(403, 112)
        lblWelcomeSub.TabIndex = 1
        lblWelcomeSub.Text = "Lengkapi registrasi Anda untuk mulai menggunakan sistem."
        ' 
        ' FormRegistrasiDosen
        ' 
        AcceptButton = btnSimpan
        AutoScaleDimensions = New SizeF(13F, 32F)
        AutoScaleMode = AutoScaleMode.Font
        BackColor = Color.FromArgb(CByte(245), CByte(240), CByte(232))
        CancelButton = btnBatal
        ClientSize = New Size(1300, 832)
        Controls.Add(pnlForm)
        Controls.Add(pnlSide)
        FormBorderStyle = FormBorderStyle.FixedDialog
        Margin = New Padding(5)
        MaximizeBox = False
        Name = "FormRegistrasiDosen"
        StartPosition = FormStartPosition.CenterScreen
        Text = "Registrasi Dosen"
        pnlForm.ResumeLayout(False)
        pnlForm.PerformLayout()
        pnlSide.ResumeLayout(False)
        ResumeLayout(False)

    End Sub

    Friend WithEvents pnlForm As System.Windows.Forms.Panel
    Friend WithEvents pnlSide As System.Windows.Forms.Panel

    Friend WithEvents lblTitle As System.Windows.Forms.Label
    Friend WithEvents lblSubTitle As System.Windows.Forms.Label
    Friend WithEvents lblNIP As System.Windows.Forms.Label
    Friend WithEvents txtNIP As System.Windows.Forms.TextBox
    Friend WithEvents lblNama As System.Windows.Forms.Label
    Friend WithEvents txtNama As System.Windows.Forms.TextBox
    Friend WithEvents lblProdi As System.Windows.Forms.Label
    Friend WithEvents cboProdi As System.Windows.Forms.ComboBox
    Friend WithEvents lblEmail As System.Windows.Forms.Label
    Friend WithEvents txtEmail As System.Windows.Forms.TextBox
    Friend WithEvents lblNoHP As System.Windows.Forms.Label
    Friend WithEvents txtNoHP As System.Windows.Forms.TextBox
    Friend WithEvents lblPassword As System.Windows.Forms.Label
    Friend WithEvents txtPassword As System.Windows.Forms.TextBox
    Friend WithEvents lblKonfirmasi As System.Windows.Forms.Label
    Friend WithEvents txtKonfirmasi As System.Windows.Forms.TextBox

    Friend WithEvents btnBatal As System.Windows.Forms.Button
    Friend WithEvents btnReset As System.Windows.Forms.Button
    Friend WithEvents btnSimpan As System.Windows.Forms.Button

    Friend WithEvents lblWelcomeTitle As System.Windows.Forms.Label
    Friend WithEvents lblWelcomeSub As System.Windows.Forms.Label

End Class
