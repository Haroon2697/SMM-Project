namespace SocietiesMS.Forms
{
    partial class LoginForm
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null)) components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.pnlMain        = new System.Windows.Forms.Panel();
            this.lblTitle       = new System.Windows.Forms.Label();
            this.lblSubtitle    = new System.Windows.Forms.Label();
            this.lblEmailIcon   = new System.Windows.Forms.Label();
            this.txtEmail       = new System.Windows.Forms.TextBox();
            this.lblPassIcon    = new System.Windows.Forms.Label();
            this.txtPassword    = new System.Windows.Forms.TextBox();
            this.btnLogin       = new System.Windows.Forms.Button();
            this.lblStatus      = new System.Windows.Forms.Label();
            this.lnkRegister    = new System.Windows.Forms.LinkLabel();
            this.lblRegisterHint= new System.Windows.Forms.Label();
            this.pnlMain.SuspendLayout();
            this.SuspendLayout();

            // Form
            this.Text            = "FAST Societies MS — Login";
            this.Size            = new System.Drawing.Size(480, 560);
            this.StartPosition   = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox     = false;
            this.BackColor       = System.Drawing.Color.FromArgb(15, 23, 42);
            this.Font            = new System.Drawing.Font("Segoe UI", 9.5f);

            // pnlMain — card
            this.pnlMain.BackColor   = System.Drawing.Color.FromArgb(30, 41, 59);
            this.pnlMain.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.pnlMain.Location    = new System.Drawing.Point(50, 60);
            this.pnlMain.Size        = new System.Drawing.Size(380, 420);
            this.pnlMain.BackColor   = System.Drawing.Color.FromArgb(30, 41, 59);

            // lblTitle
            this.lblTitle.Text      = "FAST Societies";
            this.lblTitle.Font      = new System.Drawing.Font("Segoe UI", 22f, System.Drawing.FontStyle.Bold);
            this.lblTitle.ForeColor = System.Drawing.Color.FromArgb(99, 179, 237);
            this.lblTitle.Location  = new System.Drawing.Point(60, 30);
            this.lblTitle.Size      = new System.Drawing.Size(260, 45);
            this.lblTitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;

            // lblSubtitle
            this.lblSubtitle.Text      = "Management System";
            this.lblSubtitle.Font      = new System.Drawing.Font("Segoe UI", 11f);
            this.lblSubtitle.ForeColor = System.Drawing.Color.FromArgb(148, 163, 184);
            this.lblSubtitle.Location  = new System.Drawing.Point(60, 78);
            this.lblSubtitle.Size      = new System.Drawing.Size(260, 28);
            this.lblSubtitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;

            // Email label
            this.lblEmailIcon.Text      = "Email Address";
            this.lblEmailIcon.ForeColor = System.Drawing.Color.FromArgb(148, 163, 184);
            this.lblEmailIcon.Location  = new System.Drawing.Point(30, 130);
            this.lblEmailIcon.Size      = new System.Drawing.Size(320, 20);

            // Email textbox
            this.txtEmail.Location        = new System.Drawing.Point(30, 155);
            this.txtEmail.Size            = new System.Drawing.Size(320, 30);
            this.txtEmail.BackColor       = System.Drawing.Color.FromArgb(51, 65, 85);
            this.txtEmail.ForeColor       = System.Drawing.Color.White;
            this.txtEmail.BorderStyle     = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtEmail.Font            = new System.Drawing.Font("Segoe UI", 10f);
            // PlaceholderText not available in .NET Framework 4.8

            // Password label
            this.lblPassIcon.Text      = "Password";
            this.lblPassIcon.ForeColor = System.Drawing.Color.FromArgb(148, 163, 184);
            this.lblPassIcon.Location  = new System.Drawing.Point(30, 200);
            this.lblPassIcon.Size      = new System.Drawing.Size(320, 20);

            // Password textbox
            this.txtPassword.Location        = new System.Drawing.Point(30, 225);
            this.txtPassword.Size            = new System.Drawing.Size(320, 30);
            this.txtPassword.BackColor       = System.Drawing.Color.FromArgb(51, 65, 85);
            this.txtPassword.ForeColor       = System.Drawing.Color.White;
            this.txtPassword.BorderStyle     = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtPassword.Font            = new System.Drawing.Font("Segoe UI", 10f);
            this.txtPassword.UseSystemPasswordChar = true;
            // PlaceholderText not available in .NET Framework 4.8
            this.txtPassword.KeyPress       += new System.Windows.Forms.KeyPressEventHandler(this.txtPassword_KeyPress);

            // Login button
            this.btnLogin.Text      = "Sign In";
            this.btnLogin.Location  = new System.Drawing.Point(30, 275);
            this.btnLogin.Size      = new System.Drawing.Size(320, 42);
            this.btnLogin.BackColor = System.Drawing.Color.FromArgb(59, 130, 246);
            this.btnLogin.ForeColor = System.Drawing.Color.White;
            this.btnLogin.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnLogin.Font      = new System.Drawing.Font("Segoe UI", 11f, System.Drawing.FontStyle.Bold);
            this.btnLogin.FlatAppearance.BorderSize = 0;
            this.btnLogin.Cursor    = System.Windows.Forms.Cursors.Hand;
            this.btnLogin.Click    += new System.EventHandler(this.btnLogin_Click);

            // Status label
            this.lblStatus.Text      = "";
            this.lblStatus.Location  = new System.Drawing.Point(30, 328);
            this.lblStatus.Size      = new System.Drawing.Size(320, 22);
            this.lblStatus.ForeColor = System.Drawing.Color.FromArgb(248, 113, 113);
            this.lblStatus.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;

            // Register hint
            this.lblRegisterHint.Text      = "Don't have an account?";
            this.lblRegisterHint.ForeColor = System.Drawing.Color.FromArgb(148, 163, 184);
            this.lblRegisterHint.Location  = new System.Drawing.Point(70, 360);
            this.lblRegisterHint.Size      = new System.Drawing.Size(150, 22);

            // Register link
            this.lnkRegister.Text         = "Register here";
            this.lnkRegister.Location     = new System.Drawing.Point(222, 360);
            this.lnkRegister.Size         = new System.Drawing.Size(100, 22);
            this.lnkRegister.LinkColor    = System.Drawing.Color.FromArgb(99, 179, 237);
            this.lnkRegister.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lnkRegister_LinkClicked);

            // Add to panel
            this.pnlMain.Controls.AddRange(new System.Windows.Forms.Control[] {
                this.lblTitle, this.lblSubtitle,
                this.lblEmailIcon, this.txtEmail,
                this.lblPassIcon,  this.txtPassword,
                this.btnLogin,     this.lblStatus,
                this.lblRegisterHint, this.lnkRegister
            });

            this.Controls.Add(this.pnlMain);
            this.pnlMain.ResumeLayout(false);
            this.ResumeLayout(false);
        }

        private System.Windows.Forms.Panel    pnlMain;
        private System.Windows.Forms.Label    lblTitle;
        private System.Windows.Forms.Label    lblSubtitle;
        private System.Windows.Forms.Label    lblEmailIcon;
        private System.Windows.Forms.TextBox  txtEmail;
        private System.Windows.Forms.Label    lblPassIcon;
        private System.Windows.Forms.TextBox  txtPassword;
        private System.Windows.Forms.Button   btnLogin;
        private System.Windows.Forms.Label    lblStatus;
        private System.Windows.Forms.Label    lblRegisterHint;
        private System.Windows.Forms.LinkLabel lnkRegister;
    }
}
