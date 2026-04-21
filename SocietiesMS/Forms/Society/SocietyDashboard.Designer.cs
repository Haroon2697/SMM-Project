namespace SocietiesMS.Forms.Society
{
    partial class SocietyDashboard
    {
        private System.ComponentModel.IContainer components = null;
        protected override void Dispose(bool disposing)
        { if (disposing && components != null) components.Dispose(); base.Dispose(disposing); }

        private void InitializeComponent()
        {
            this.pnlSidebar        = new System.Windows.Forms.Panel();
            this.lblAppName        = new System.Windows.Forms.Label();
            this.lblWelcome        = new System.Windows.Forms.Label();
            this.btnManageMembers  = new System.Windows.Forms.Button();
            this.btnManageEvents   = new System.Windows.Forms.Button();
            this.btnTasks          = new System.Windows.Forms.Button();
            this.btnReports        = new System.Windows.Forms.Button();
            this.btnLogout         = new System.Windows.Forms.Button();
            this.pnlContent        = new System.Windows.Forms.Panel();
            this.lblSocietyName    = new System.Windows.Forms.Label();
            this.lblStatus         = new System.Windows.Forms.Label();
            this.pnlStats          = new System.Windows.Forms.Panel();
            this.lblStatMembers    = new System.Windows.Forms.Label();
            this.lblStatPending    = new System.Windows.Forms.Label();
            this.lblStatEvents     = new System.Windows.Forms.Label();

            this.pnlSidebar.SuspendLayout();
            this.pnlContent.SuspendLayout();
            this.pnlStats.SuspendLayout();
            this.SuspendLayout();

            this.Text          = "Society Dashboard — FAST Societies MS";
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
            this.lblAppName.ForeColor = System.Drawing.Color.FromArgb(251, 191, 36);
            this.lblAppName.Location  = new System.Drawing.Point(15, 20);
            this.lblAppName.Size      = new System.Drawing.Size(190, 35);

            this.lblWelcome.Text      = "";
            this.lblWelcome.ForeColor = System.Drawing.Color.FromArgb(148, 163, 184);
            this.lblWelcome.Location  = new System.Drawing.Point(15, 58);
            this.lblWelcome.Size      = new System.Drawing.Size(190, 30);
            this.lblWelcome.Font      = new System.Drawing.Font("Segoe UI", 8.5f);

            MakeSideBtn(this.btnManageMembers, "👥  Manage Members", 105);
            MakeSideBtn(this.btnManageEvents,  "📅  Manage Events",  155);
            MakeSideBtn(this.btnTasks,         "✔  Assign Tasks",    205);
            MakeSideBtn(this.btnReports,       "📋  Reports",         255);

            this.btnManageMembers.Click += new System.EventHandler(this.btnManageMembers_Click);
            this.btnManageEvents.Click  += new System.EventHandler(this.btnManageEvents_Click);
            this.btnTasks.Click         += new System.EventHandler(this.btnTasks_Click);
            this.btnReports.Click       += new System.EventHandler(this.btnReports_Click);

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
                this.btnManageMembers, this.btnManageEvents,
                this.btnTasks, this.btnReports, this.btnLogout });

            // Content
            this.pnlContent.BackColor = System.Drawing.Color.FromArgb(15, 23, 42);
            this.pnlContent.Dock      = System.Windows.Forms.DockStyle.Fill;

            this.lblSocietyName.Text      = "";
            this.lblSocietyName.Font      = new System.Drawing.Font("Segoe UI", 20f, System.Drawing.FontStyle.Bold);
            this.lblSocietyName.ForeColor = System.Drawing.Color.White;
            this.lblSocietyName.Location  = new System.Drawing.Point(30, 25);
            this.lblSocietyName.Size      = new System.Drawing.Size(620, 45);

            this.lblStatus.Text      = "";
            this.lblStatus.ForeColor = System.Drawing.Color.FromArgb(74, 222, 128);
            this.lblStatus.Font      = new System.Drawing.Font("Segoe UI", 10f);
            this.lblStatus.Location  = new System.Drawing.Point(30, 72);
            this.lblStatus.Size      = new System.Drawing.Size(300, 24);

            // Stats panel
            this.pnlStats.BackColor = System.Drawing.Color.FromArgb(30, 41, 59);
            this.pnlStats.Location  = new System.Drawing.Point(30, 110);
            this.pnlStats.Size      = new System.Drawing.Size(620, 100);

            MakeStatLabel(this.lblStatMembers, "", 20, 15);
            MakeStatLabel(this.lblStatPending, "", 20, 45);
            MakeStatLabel(this.lblStatEvents,  "", 20, 75);

            this.pnlStats.Controls.AddRange(new System.Windows.Forms.Control[] {
                this.lblStatMembers, this.lblStatPending, this.lblStatEvents });

            this.pnlContent.Controls.AddRange(new System.Windows.Forms.Control[] {
                this.lblSocietyName, this.lblStatus, this.pnlStats });

            this.Controls.Add(this.pnlContent);
            this.Controls.Add(this.pnlSidebar);

            this.pnlSidebar.ResumeLayout(false);
            this.pnlContent.ResumeLayout(false);
            this.pnlStats.ResumeLayout(false);
            this.ResumeLayout(false);
        }

        private void MakeSideBtn(System.Windows.Forms.Button btn, string text, int top)
        {
            btn.Text = text; btn.Location = new System.Drawing.Point(15, top);
            btn.Size = new System.Drawing.Size(190, 40);
            btn.BackColor = System.Drawing.Color.FromArgb(51, 65, 85);
            btn.ForeColor = System.Drawing.Color.White;
            btn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            btn.FlatAppearance.BorderSize = 0;
            btn.Font = new System.Drawing.Font("Segoe UI", 9.5f);
            btn.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            btn.Cursor = System.Windows.Forms.Cursors.Hand;
        }
        private void MakeStatLabel(System.Windows.Forms.Label lbl, string text, int x, int y)
        {
            lbl.Text = text; lbl.Location = new System.Drawing.Point(x, y);
            lbl.Size = new System.Drawing.Size(580, 24);
            lbl.ForeColor = System.Drawing.Color.FromArgb(226, 232, 240);
            lbl.Font = new System.Drawing.Font("Segoe UI", 10.5f);
        }

        private System.Windows.Forms.Panel  pnlSidebar, pnlContent, pnlStats;
        private System.Windows.Forms.Label  lblAppName, lblWelcome, lblSocietyName, lblStatus;
        private System.Windows.Forms.Label  lblStatMembers, lblStatPending, lblStatEvents;
        private System.Windows.Forms.Button btnManageMembers, btnManageEvents, btnTasks, btnReports, btnLogout;
    }
}
