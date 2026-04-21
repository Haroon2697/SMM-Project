namespace SocietiesMS.Forms.Admin
{
    partial class AdminDashboard
    {
        private System.ComponentModel.IContainer components = null;
        protected override void Dispose(bool disposing)
        { if (disposing && components != null) components.Dispose(); base.Dispose(disposing); }

        private void InitializeComponent()
        {
            this.pnlSidebar          = new System.Windows.Forms.Panel();
            this.lblAppName          = new System.Windows.Forms.Label();
            this.lblWelcome          = new System.Windows.Forms.Label();
            this.btnManageStudents   = new System.Windows.Forms.Button();
            this.btnManageSocieties  = new System.Windows.Forms.Button();
            this.btnApproveEvents    = new System.Windows.Forms.Button();
            this.btnReports          = new System.Windows.Forms.Button();
            this.btnLogout           = new System.Windows.Forms.Button();
            this.pnlContent          = new System.Windows.Forms.Panel();
            this.lblDashTitle        = new System.Windows.Forms.Label();
            this.lblAdminBadge       = new System.Windows.Forms.Label();
            this.pnlStats            = new System.Windows.Forms.Panel();
            this.lblStatStudents     = new System.Windows.Forms.Label();
            this.lblStatSocieties    = new System.Windows.Forms.Label();
            this.lblStatPending      = new System.Windows.Forms.Label();
            this.lblStatEvents       = new System.Windows.Forms.Label();
            this.lblStatApproved     = new System.Windows.Forms.Label();
            this.lblStatMembers      = new System.Windows.Forms.Label();
            this.btnRefresh          = new System.Windows.Forms.Button();

            this.pnlSidebar.SuspendLayout();
            this.pnlContent.SuspendLayout();
            this.pnlStats.SuspendLayout();
            this.SuspendLayout();

            this.Text          = "Admin Dashboard — FAST Societies MS";
            this.ShowIcon = false;
            this.Size          = new System.Drawing.Size(900, 620);
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.BackColor     = System.Drawing.Color.FromArgb(15, 23, 42);
            this.Font          = new System.Drawing.Font("Segoe UI", 9.5f);

            // Sidebar
            this.pnlSidebar.BackColor = System.Drawing.Color.FromArgb(30, 41, 59);
            this.pnlSidebar.Dock      = System.Windows.Forms.DockStyle.Left;
            this.pnlSidebar.Width     = 220;

            this.lblAppName.Text      = "🎓 FAST SMS";
            this.lblAppName.Font      = new System.Drawing.Font("Segoe UI", 14f, System.Drawing.FontStyle.Bold);
            this.lblAppName.ForeColor = System.Drawing.Color.FromArgb(248, 113, 113);
            this.lblAppName.Location  = new System.Drawing.Point(15, 20);
            this.lblAppName.Size      = new System.Drawing.Size(190, 35);

            this.lblWelcome.Text      = "";
            this.lblWelcome.ForeColor = System.Drawing.Color.FromArgb(148, 163, 184);
            this.lblWelcome.Location  = new System.Drawing.Point(15, 58);
            this.lblWelcome.Size      = new System.Drawing.Size(190, 30);
            this.lblWelcome.Font      = new System.Drawing.Font("Segoe UI", 8.5f);

            UITheme.StyleSidebarBtn(this.btnManageStudents);
            UITheme.StyleSidebarBtn(this.btnManageSocieties);
            UITheme.StyleSidebarBtn(this.btnApproveEvents);
            UITheme.StyleSidebarBtn(this.btnReports);

            this.btnManageStudents.Click  += new System.EventHandler(this.btnManageStudents_Click);
            this.btnManageSocieties.Click += new System.EventHandler(this.btnManageSocieties_Click);
            this.btnApproveEvents.Click   += new System.EventHandler(this.btnApproveEvents_Click);
            this.btnReports.Click         += new System.EventHandler(this.btnReports_Click);

            this.btnLogout.Text      = "⬅  Logout";
            this.btnLogout.Location  = new System.Drawing.Point(15, 500);
            this.btnLogout.Size      = new System.Drawing.Size(190, 38);
            this.btnLogout.BackColor = System.Drawing.Color.FromArgb(127, 29, 29);
            this.btnLogout.ForeColor = System.Drawing.Color.White;
            this.btnLogout.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnLogout.FlatAppearance.BorderSize = 0;
            this.btnLogout.Font      = new System.Drawing.Font("Segoe UI", 9.5f);
            this.btnLogout.Cursor    = System.Windows.Forms.Cursors.Hand;
            this.btnLogout.Click    += new System.EventHandler(this.btnLogout_Click);

            this.pnlSidebar.Controls.AddRange(new System.Windows.Forms.Control[] {
                this.lblAppName, this.lblWelcome,
                this.btnManageStudents, this.btnManageSocieties,
                this.btnApproveEvents, this.btnReports, this.btnLogout });

            // Content
            this.pnlContent.BackColor = System.Drawing.Color.FromArgb(15, 23, 42);
            this.pnlContent.Dock      = System.Windows.Forms.DockStyle.Fill;

            this.lblDashTitle.Text      = "Admin Control Panel";
            this.lblDashTitle.Font      = new System.Drawing.Font("Segoe UI", 20f, System.Drawing.FontStyle.Bold);
            this.lblDashTitle.ForeColor = System.Drawing.Color.White;
            this.lblDashTitle.Location  = new System.Drawing.Point(30, 25); this.lblDashTitle.Size = new System.Drawing.Size(600, 45);

            this.lblAdminBadge.Text      = "🔐 Administrator";
            this.lblAdminBadge.ForeColor = System.Drawing.Color.FromArgb(248, 113, 113);
            this.lblAdminBadge.Font      = new System.Drawing.Font("Segoe UI", 10f, System.Drawing.FontStyle.Bold);
            this.lblAdminBadge.Location  = new System.Drawing.Point(30, 72); this.lblAdminBadge.Size = new System.Drawing.Size(200, 24);

            this.pnlStats.BackColor = System.Drawing.Color.FromArgb(30, 41, 59);
            this.pnlStats.Location  = new System.Drawing.Point(30, 112); this.pnlStats.Size = new System.Drawing.Size(620, 200);

            int sy = 12;
            foreach (var lbl in new[] { this.lblStatStudents, this.lblStatSocieties, this.lblStatPending,
                                        this.lblStatEvents, this.lblStatApproved, this.lblStatMembers })
            {
                lbl.Text = ""; lbl.Location = new System.Drawing.Point(20, sy); lbl.Size = new System.Drawing.Size(580, 26);
                lbl.ForeColor = System.Drawing.Color.FromArgb(226, 232, 240);
                lbl.Font = new System.Drawing.Font("Segoe UI", 10.5f);
                sy += 30;
            }

            this.pnlStats.Controls.AddRange(new System.Windows.Forms.Control[] {
                this.lblStatStudents, this.lblStatSocieties, this.lblStatPending,
                this.lblStatEvents, this.lblStatApproved, this.lblStatMembers });

            this.btnRefresh.Text    = "⟳  Refresh Stats";
            this.btnRefresh.Location= new System.Drawing.Point(30, 328); this.btnRefresh.Size = new System.Drawing.Size(160, 38);
            UITheme.StyleSecondaryBtn(this.btnRefresh);
            this.btnRefresh.Click  += new System.EventHandler(this.btnRefresh_Click);

            this.pnlContent.Controls.AddRange(new System.Windows.Forms.Control[] {
                this.lblDashTitle, this.lblAdminBadge, this.pnlStats, this.btnRefresh });

            this.Controls.Add(this.pnlContent);
            this.Controls.Add(this.pnlSidebar);

            this.pnlSidebar.ResumeLayout(false);
            this.pnlContent.ResumeLayout(false);
            this.pnlStats.ResumeLayout(false);
            this.ResumeLayout(false);
        }

        private void MakeSideBtn(System.Windows.Forms.Button btn, string text, int top)
        { btn.Text = text; btn.Location = new System.Drawing.Point(15, top); btn.Size = new System.Drawing.Size(190, 40); btn.BackColor = System.Drawing.Color.FromArgb(51, 65, 85); btn.ForeColor = System.Drawing.Color.White; btn.FlatStyle = System.Windows.Forms.FlatStyle.Flat; btn.FlatAppearance.BorderSize = 0; btn.Font = new System.Drawing.Font("Segoe UI", 9.5f); btn.TextAlign = System.Drawing.ContentAlignment.MiddleLeft; btn.Cursor = System.Windows.Forms.Cursors.Hand; }

        private System.Windows.Forms.Panel  pnlSidebar, pnlContent, pnlStats;
        private System.Windows.Forms.Label  lblAppName, lblWelcome, lblDashTitle, lblAdminBadge;
        private System.Windows.Forms.Label  lblStatStudents, lblStatSocieties, lblStatPending, lblStatEvents, lblStatApproved, lblStatMembers;
        private System.Windows.Forms.Button btnManageStudents, btnManageSocieties, btnApproveEvents, btnReports, btnLogout, btnRefresh;
    }
}
