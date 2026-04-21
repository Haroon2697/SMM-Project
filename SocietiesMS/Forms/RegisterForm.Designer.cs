namespace SocietiesMS.Forms
{
    partial class RegisterForm
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null)) components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.pnlMain            = new System.Windows.Forms.Panel();
            this.lblTitle           = new System.Windows.Forms.Label();
            this.lblName            = new System.Windows.Forms.Label();
            this.txtName            = new System.Windows.Forms.TextBox();
            this.lblEmail           = new System.Windows.Forms.Label();
            this.txtEmail           = new System.Windows.Forms.TextBox();
            this.lblPassword        = new System.Windows.Forms.Label();
            this.txtPassword        = new System.Windows.Forms.TextBox();
            this.lblConfirmPassword = new System.Windows.Forms.Label();
            this.txtConfirmPassword = new System.Windows.Forms.TextBox();
            this.btnRegister        = new System.Windows.Forms.Button();
            this.lblStatus          = new System.Windows.Forms.Label();
            this.pnlMain.SuspendLayout();
            this.SuspendLayout();

            this.Text            = "FAST Societies MS — Register";
            this.Size            = new System.Drawing.Size(480, 580);
            this.StartPosition   = System.Windows.Forms.FormStartPosition.CenterParent;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox     = false;
            this.BackColor       = System.Drawing.Color.FromArgb(15, 23, 42);
            this.Font            = new System.Drawing.Font("Segoe UI", 9.5f);

            this.pnlMain.BackColor = System.Drawing.Color.FromArgb(30, 41, 59);
            this.pnlMain.Location  = new System.Drawing.Point(40, 40);
            this.pnlMain.Size      = new System.Drawing.Size(400, 490);

            this.lblTitle.Text      = "Create Account";
            this.lblTitle.Font      = new System.Drawing.Font("Segoe UI", 18f, System.Drawing.FontStyle.Bold);
            this.lblTitle.ForeColor = System.Drawing.Color.FromArgb(99, 179, 237);
            this.lblTitle.Location  = new System.Drawing.Point(80, 25);
            this.lblTitle.Size      = new System.Drawing.Size(240, 40);
            this.lblTitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;

            // Helper to build label + textbox pairs
            SetupField(this.lblName,    "Full Name",        30, 80);
            SetupTextBox(this.txtName,  "John Doe",         30, 105, false);

            SetupField(this.lblEmail,   "Email Address",    30, 150);
            SetupTextBox(this.txtEmail, "you@fast.edu",     30, 175, false);

            SetupField(this.lblPassword, "Password",        30, 220);
            SetupTextBox(this.txtPassword, "••••••••",      30, 245, true);

            SetupField(this.lblConfirmPassword, "Confirm Password", 30, 290);
            SetupTextBox(this.txtConfirmPassword, "••••••••", 30, 315, true);

            this.btnRegister.Text      = "Create Account";
            this.btnRegister.Location  = new System.Drawing.Point(30, 365);
            this.btnRegister.Size      = new System.Drawing.Size(340, 42);
            this.btnRegister.BackColor = System.Drawing.Color.FromArgb(59, 130, 246);
            this.btnRegister.ForeColor = System.Drawing.Color.White;
            this.btnRegister.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnRegister.Font      = new System.Drawing.Font("Segoe UI", 11f, System.Drawing.FontStyle.Bold);
            this.btnRegister.FlatAppearance.BorderSize = 0;
            this.btnRegister.Cursor    = System.Windows.Forms.Cursors.Hand;
            this.btnRegister.Click    += new System.EventHandler(this.btnRegister_Click);

            this.lblStatus.Text      = "";
            this.lblStatus.Location  = new System.Drawing.Point(30, 420);
            this.lblStatus.Size      = new System.Drawing.Size(340, 40);
            this.lblStatus.ForeColor = System.Drawing.Color.FromArgb(248, 113, 113);
            this.lblStatus.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;

            this.pnlMain.Controls.AddRange(new System.Windows.Forms.Control[] {
                this.lblTitle,
                this.lblName,   this.txtName,
                this.lblEmail,  this.txtEmail,
                this.lblPassword, this.txtPassword,
                this.lblConfirmPassword, this.txtConfirmPassword,
                this.btnRegister, this.lblStatus
            });

            this.Controls.Add(this.pnlMain);
            this.pnlMain.ResumeLayout(false);
            this.ResumeLayout(false);
        }

        private void SetupField(System.Windows.Forms.Label lbl, string text, int x, int y)
        {
            lbl.Text      = text;
            lbl.ForeColor = System.Drawing.Color.FromArgb(148, 163, 184);
            lbl.Location  = new System.Drawing.Point(x, y);
            lbl.Size      = new System.Drawing.Size(340, 20);
        }

        private void SetupTextBox(System.Windows.Forms.TextBox txt, string placeholder, int x, int y, bool isPassword)
        {
            txt.Location        = new System.Drawing.Point(x, y);
            txt.Size            = new System.Drawing.Size(340, 28);
            System.Windows.Forms.Padding padding = txt.Margin;
            padding.Top = 10;
            UITheme.StyleTextBox(txt);
            if (isPassword) txt.UseSystemPasswordChar = true;
        }

        private System.Windows.Forms.Panel   pnlMain;
        private System.Windows.Forms.Label   lblTitle;
        private System.Windows.Forms.Label   lblName;
        private System.Windows.Forms.TextBox txtName;
        private System.Windows.Forms.Label   lblEmail;
        private System.Windows.Forms.TextBox txtEmail;
        private System.Windows.Forms.Label   lblPassword;
        private System.Windows.Forms.TextBox txtPassword;
        private System.Windows.Forms.Label   lblConfirmPassword;
        private System.Windows.Forms.TextBox txtConfirmPassword;
        private System.Windows.Forms.Button  btnRegister;
        private System.Windows.Forms.Label   lblStatus;
    }
}
