<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class FormLogin
    Inherits Global.System.Windows.Forms.Form

    <Global.System.Diagnostics.DebuggerNonUserCode()>
    Protected Overrides Sub Dispose(disposing As Boolean)
        Try
            If disposing AndAlso (components IsNot Nothing) Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    Private components As Global.System.ComponentModel.IContainer

    <Global.System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        pnlLeft = New Panel()
        lblWelcomeSubtitle = New Label()
        lblWelcomeTitle = New Label()
        pnlRight = New Panel()
        lnkSignup = New LinkLabel()
        lblNewUser = New Label()
        btnLogin = New Button()
        lnkForgot = New LinkLabel()
        chkRemember = New CheckBox()
        txtPassword = New TextBox()
        lblPassword = New Label()
        txtUsername = New TextBox()
        lblUsername = New Label()
        lblLoginSubtitle = New Label()
        lblLoginTitle = New Label()
        pnlLeft.SuspendLayout()
        pnlRight.SuspendLayout()
        SuspendLayout()
        ' 
        ' pnlLeft
        ' 
        pnlLeft.BackColor = Color.FromArgb(CByte(109), CByte(148), CByte(197))
        pnlLeft.Controls.Add(lblWelcomeSubtitle)
        pnlLeft.Controls.Add(lblWelcomeTitle)
        pnlLeft.Dock = DockStyle.Left
        pnlLeft.Location = New Point(0, 0)
        pnlLeft.Margin = New Padding(5)
        pnlLeft.Name = "pnlLeft"
        pnlLeft.Size = New Size(585, 800)
        pnlLeft.TabIndex = 0
        ' 
        ' lblWelcomeSubtitle
        ' 
        lblWelcomeSubtitle.Font = New Font("Segoe UI", 10.0F)
        lblWelcomeSubtitle.ForeColor = Color.White
        lblWelcomeSubtitle.Location = New Point(65, 408)
        lblWelcomeSubtitle.Margin = New Padding(5, 0, 5, 0)
        lblWelcomeSubtitle.Name = "lblWelcomeSubtitle"
        lblWelcomeSubtitle.Size = New Size(455, 96)
        lblWelcomeSubtitle.TabIndex = 1
        lblWelcomeSubtitle.Text = "Senang melihat Anda kembali!"
        ' 
        ' lblWelcomeTitle
        ' 
        lblWelcomeTitle.Font = New Font("Segoe UI Semibold", 26.0F, FontStyle.Bold)
        lblWelcomeTitle.ForeColor = Color.White
        lblWelcomeTitle.Location = New Point(65, 216)
        lblWelcomeTitle.Margin = New Padding(5, 0, 5, 0)
        lblWelcomeTitle.Name = "lblWelcomeTitle"
        lblWelcomeTitle.Size = New Size(455, 192)
        lblWelcomeTitle.TabIndex = 0
        lblWelcomeTitle.Text = "Selamat Datang!"
        ' 
        ' pnlRight
        ' 
        pnlRight.BackColor = Color.White
        pnlRight.Controls.Add(lnkSignup)
        pnlRight.Controls.Add(lblNewUser)
        pnlRight.Controls.Add(btnLogin)
        pnlRight.Controls.Add(lnkForgot)
        pnlRight.Controls.Add(chkRemember)
        pnlRight.Controls.Add(txtPassword)
        pnlRight.Controls.Add(lblPassword)
        pnlRight.Controls.Add(txtUsername)
        pnlRight.Controls.Add(lblUsername)
        pnlRight.Controls.Add(lblLoginSubtitle)
        pnlRight.Controls.Add(lblLoginTitle)
        pnlRight.Dock = DockStyle.Fill
        pnlRight.Location = New Point(585, 0)
        pnlRight.Margin = New Padding(5)
        pnlRight.Name = "pnlRight"
        pnlRight.Padding = New Padding(81, 96, 81, 64)
        pnlRight.Size = New Size(715, 800)
        pnlRight.TabIndex = 1
        ' 
        ' lnkSignup
        ' 
        lnkSignup.AutoSize = True
        lnkSignup.Font = New Font("Segoe UI", 9.0F, FontStyle.Bold)
        lnkSignup.LinkColor = Color.FromArgb(CByte(109), CByte(148), CByte(197))
        lnkSignup.Location = New Point(406, 672)
        lnkSignup.Margin = New Padding(5, 0, 5, 0)
        lnkSignup.Name = "lnkSignup"
        lnkSignup.Size = New Size(106, 32)
        lnkSignup.TabIndex = 8
        lnkSignup.TabStop = True
        lnkSignup.Text = "DAFTAR"
        ' 
        ' lblNewUser
        ' 
        lblNewUser.AutoSize = True
        lblNewUser.Font = New Font("Segoe UI", 9.0F)
        lblNewUser.ForeColor = Color.Gray
        lblNewUser.Location = New Point(138, 672)
        lblNewUser.Margin = New Padding(5, 0, 5, 0)
        lblNewUser.Name = "lblNewUser"
        lblNewUser.Size = New Size(225, 32)
        lblNewUser.TabIndex = 7
        lblNewUser.Text = "Belum punya akun?"
        ' 
        ' btnLogin
        ' 
        btnLogin.BackColor = Color.FromArgb(CByte(109), CByte(148), CByte(197))
        btnLogin.FlatAppearance.BorderSize = 0
        btnLogin.FlatStyle = FlatStyle.Flat
        btnLogin.Font = New Font("Segoe UI Semibold", 10.0F, FontStyle.Bold)
        btnLogin.ForeColor = Color.White
        btnLogin.Location = New Point(138, 576)
        btnLogin.Margin = New Padding(5)
        btnLogin.Name = "btnLogin"
        btnLogin.Size = New Size(439, 67)
        btnLogin.TabIndex = 6
        btnLogin.Text = "Login"
        btnLogin.UseVisualStyleBackColor = False
        ' 
        ' lnkForgot
        ' 
        lnkForgot.AutoSize = True
        lnkForgot.Font = New Font("Segoe UI", 8.5F)
        lnkForgot.LinkColor = Color.Gray
        lnkForgot.Location = New Point(406, 520)
        lnkForgot.Margin = New Padding(5, 0, 5, 0)
        lnkForgot.Name = "lnkForgot"
        lnkForgot.Size = New Size(176, 31)
        lnkForgot.TabIndex = 5
        lnkForgot.TabStop = True
        lnkForgot.Text = "Lupa Password?"
        ' 
        ' chkRemember
        ' 
        chkRemember.AutoSize = True
        chkRemember.Font = New Font("Segoe UI", 8.5F)
        chkRemember.ForeColor = Color.DimGray
        chkRemember.Location = New Point(138, 517)
        chkRemember.Margin = New Padding(5)
        chkRemember.Name = "chkRemember"
        chkRemember.Size = New Size(152, 35)
        chkRemember.TabIndex = 4
        chkRemember.Text = "Ingat Saya"
        chkRemember.UseVisualStyleBackColor = True
        ' 
        ' txtPassword
        ' 
        txtPassword.BorderStyle = BorderStyle.FixedSingle
        txtPassword.Font = New Font("Segoe UI", 9.0F)
        txtPassword.Location = New Point(138, 448)
        txtPassword.Margin = New Padding(5)
        txtPassword.Name = "txtPassword"
        txtPassword.PasswordChar = "*"c
        txtPassword.Size = New Size(450, 39)
        txtPassword.TabIndex = 3
        ' 
        ' lblPassword
        ' 
        lblPassword.AutoSize = True
        lblPassword.Font = New Font("Segoe UI", 9.0F)
        lblPassword.ForeColor = Color.FromArgb(CByte(90), CByte(90), CByte(90))
        lblPassword.Location = New Point(138, 408)
        lblPassword.Margin = New Padding(5, 0, 5, 0)
        lblPassword.Name = "lblPassword"
        lblPassword.Size = New Size(111, 32)
        lblPassword.TabIndex = 3
        lblPassword.Text = "Password"
        ' 
        ' txtUsername
        ' 
        txtUsername.BorderStyle = BorderStyle.FixedSingle
        txtUsername.Font = New Font("Segoe UI", 9.0F)
        txtUsername.Location = New Point(138, 336)
        txtUsername.Margin = New Padding(5)
        txtUsername.Name = "txtUsername"
        txtUsername.Size = New Size(450, 39)
        txtUsername.TabIndex = 2
        ' 
        ' lblUsername
        ' 
        lblUsername.AutoSize = True
        lblUsername.Font = New Font("Segoe UI", 9.0F)
        lblUsername.ForeColor = Color.FromArgb(CByte(90), CByte(90), CByte(90))
        lblUsername.Location = New Point(138, 296)
        lblUsername.Margin = New Padding(5, 0, 5, 0)
        lblUsername.Name = "lblUsername"
        lblUsername.Size = New Size(132, 32)
        lblUsername.TabIndex = 2
        lblUsername.Text = "User Name"
        ' 
        ' lblLoginSubtitle
        ' 
        lblLoginSubtitle.Font = New Font("Segoe UI", 9.0F)
        lblLoginSubtitle.ForeColor = Color.Gray
        lblLoginSubtitle.Location = New Point(138, 216)
        lblLoginSubtitle.Margin = New Padding(5, 0, 5, 0)
        lblLoginSubtitle.Name = "lblLoginSubtitle"
        lblLoginSubtitle.Size = New Size(439, 64)
        lblLoginSubtitle.TabIndex = 1
        lblLoginSubtitle.Text = "Selamat datang! Silahkan login menggunakan akun anda."
        ' 
        ' lblLoginTitle
        ' 
        lblLoginTitle.AutoSize = True
        lblLoginTitle.Font = New Font("Segoe UI Semibold", 18.0F, FontStyle.Bold)
        lblLoginTitle.ForeColor = Color.FromArgb(CByte(40), CByte(40), CByte(40))
        lblLoginTitle.Location = New Point(133, 144)
        lblLoginTitle.Margin = New Padding(5, 0, 5, 0)
        lblLoginTitle.Name = "lblLoginTitle"
        lblLoginTitle.Size = New Size(150, 65)
        lblLoginTitle.TabIndex = 0
        lblLoginTitle.Text = "Login"
        ' 
        ' FormLogin
        ' 
        AcceptButton = btnLogin
        AutoScaleDimensions = New SizeF(13.0F, 32.0F)
        AutoScaleMode = AutoScaleMode.Font
        BackColor = Color.FromArgb(CByte(244), CByte(238), CByte(230))
        ClientSize = New Size(1300, 800)
        Controls.Add(pnlRight)
        Controls.Add(pnlLeft)
        Font = New Font("Segoe UI", 9.0F)
        FormBorderStyle = FormBorderStyle.FixedDialog
        Margin = New Padding(5)
        MaximizeBox = False
        Name = "FormLogin"
        StartPosition = FormStartPosition.CenterScreen
        Text = "Login - Sistem Penilaian Perilaku Dosen"
        pnlLeft.ResumeLayout(False)
        pnlRight.ResumeLayout(False)
        pnlRight.PerformLayout()
        ResumeLayout(False)

    End Sub

    Friend WithEvents pnlLeft As Global.System.Windows.Forms.Panel
    Friend WithEvents lblWelcomeTitle As Global.System.Windows.Forms.Label
    Friend WithEvents lblWelcomeSubtitle As Global.System.Windows.Forms.Label
    Friend WithEvents pnlRight As Global.System.Windows.Forms.Panel
    Friend WithEvents lblLoginTitle As Global.System.Windows.Forms.Label
    Friend WithEvents lblLoginSubtitle As Global.System.Windows.Forms.Label
    Friend WithEvents lblUsername As Global.System.Windows.Forms.Label
    Friend WithEvents txtUsername As Global.System.Windows.Forms.TextBox
    Friend WithEvents lblPassword As Global.System.Windows.Forms.Label
    Friend WithEvents txtPassword As Global.System.Windows.Forms.TextBox
    Friend WithEvents chkRemember As Global.System.Windows.Forms.CheckBox
    Friend WithEvents lnkForgot As Global.System.Windows.Forms.LinkLabel
    Friend WithEvents btnLogin As Global.System.Windows.Forms.Button
    Friend WithEvents lblNewUser As Global.System.Windows.Forms.Label
    Friend WithEvents lnkSignup As Global.System.Windows.Forms.LinkLabel

End Class
