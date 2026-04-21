namespace SocietiesMS.Forms.Student
{
    partial class StudentDashboard
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null)) components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.pnlSidebar           = new System.Windows.Forms.Panel();
            this.lblAppName           = new System.Windows.Forms.Label();
            this.lblWelcome           = new System.Windows.Forms.Label();
            this.btnBrowseSocieties   = new System.Windows.Forms.Button();
            this.btnMyMemberships     = new System.Windows.Forms.Button();
            this.btnEvents            = new System.Windows.Forms.Button();
            this.btnMyTickets         = new System.Windows.Forms.Button();
            this.btnLogout            = new System.Windows.Forms.Button();
            this.pnlContent           = new System.Windows.Forms.Panel();
            this.lblDashTitle         = new System.Windows.Forms.Label();
            this.lblAnnouncementsHdr  = new System.Windows.Forms.Label();
            this.lstAnnouncements     = new System.Windows.Forms.ListBox();
            this.btnRefresh           = new System.Windows.Forms.Button();

            this.pnlSidebar.SuspendLayout();
            this.pnlContent.SuspendLayout();
            this.SuspendLayout();

            // Form
            this.Text            = "Student Dashboard — FAST Societies MS";
            this.Size            = new System.Drawing.Size(900, 620);
            this.StartPosition   = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.BackColor       = System.Drawing.Color.FromArgb(15, 23, 42);
            this.Font            = new System.Drawing.Font("Segoe UI", 9.5f);

            // Sidebar
            this.pnlSidebar.BackColor = System.Drawing.Color.FromArgb(30, 41, 59);
            this.pnlSidebar.Dock      = System.Windows.Forms.DockStyle.Left;
            this.pnlSidebar.Width     = 220;

            this.lblAppName.Text      = "🎓 FAST SMS";
            this.lblAppName.Font      = new System.Drawing.Font("Segoe UI", 14f, System.Drawing.FontStyle.Bold);
            this.lblAppName.ForeColor = System.Drawing.Color.FromArgb(99, 179, 237);
            this.lblAppName.Location  = new System.Drawing.Point(15, 20);
            this.lblAppName.Size      = new System.Drawing.Size(190, 35);

            this.lblWelcome.Text      = "";
            this.lblWelcome.ForeColor = System.Drawing.Color.FromArgb(148, 163, 184);
            this.lblWelcome.Location  = new System.Drawing.Point(15, 58);
            this.lblWelcome.Size      = new System.Drawing.Size(190, 35);
            this.lblWelcome.Font      = new System.Drawing.Font("Segoe UI", 8.5f);

            MakeSidebarButton(this.btnBrowseSocieties,  "🏛  Browse Societies", 100);
            MakeSidebarButton(this.btnMyMemberships,    "📋  My Memberships",  155);
            MakeSidebarButton(this.btnEvents,           "📅  Events",          210);
            MakeSidebarButton(this.btnMyTickets,        "🎫  My Tickets",      265);

            this.btnBrowseSocieties.Click += new System.EventHandler(this.btnBrowseSocieties_Click);
            this.btnMyMemberships.Click   += new System.EventHandler(this.btnMyMemberships_Click);
            this.btnEvents.Click          += new System.EventHandler(this.btnEvents_Click);
            this.btnMyTickets.Click       += new System.EventHandler(this.btnMyTickets_Click);

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
                this.btnBrowseSocieties, this.btnMyMemberships,
                this.btnEvents, this.btnMyTickets, this.btnLogout
            });

            // Content panel
            this.pnlContent.BackColor = System.Drawing.Color.FromArgb(15, 23, 42);
            this.pnlContent.Dock      = System.Windows.Forms.DockStyle.Fill;

            this.lblDashTitle.Text      = "Dashboard";
            this.lblDashTitle.Font      = new System.Drawing.Font("Segoe UI", 20f, System.Drawing.FontStyle.Bold);
            this.lblDashTitle.ForeColor = System.Drawing.Color.White;
            this.lblDashTitle.Location  = new System.Drawing.Point(30, 25);
            this.lblDashTitle.Size      = new System.Drawing.Size(600, 45);

            this.lblAnnouncementsHdr.Text      = "📢  Latest Announcements";
            this.lblAnnouncementsHdr.Font      = new System.Drawing.Font("Segoe UI", 12f, System.Drawing.FontStyle.Bold);
            this.lblAnnouncementsHdr.ForeColor = System.Drawing.Color.FromArgb(99, 179, 237);
            this.lblAnnouncementsHdr.Location  = new System.Drawing.Point(30, 85);
            this.lblAnnouncementsHdr.Size      = new System.Drawing.Size(400, 28);

            this.btnRefresh.Text      = "⟳ Refresh";
            this.btnRefresh.Location  = new System.Drawing.Point(440, 83);
            this.btnRefresh.Size      = new System.Drawing.Size(100, 30);
            this.btnRefresh.BackColor = System.Drawing.Color.FromArgb(51, 65, 85);
            this.btnRefresh.ForeColor = System.Drawing.Color.White;
            this.btnRefresh.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnRefresh.FlatAppearance.BorderSize = 0;
            this.btnRefresh.Cursor    = System.Windows.Forms.Cursors.Hand;
            this.btnRefresh.Click    += new System.EventHandler(this.btnRefresh_Click);

            this.lstAnnouncements.Location  = new System.Drawing.Point(30, 125);
            this.lstAnnouncements.Size      = new System.Drawing.Size(610, 380);
            this.lstAnnouncements.BackColor = System.Drawing.Color.FromArgb(30, 41, 59);
            this.lstAnnouncements.ForeColor = System.Drawing.Color.FromArgb(226, 232, 240);
            this.lstAnnouncements.Font      = new System.Drawing.Font("Segoe UI", 10f);
            this.lstAnnouncements.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.lstAnnouncements.ItemHeight  = 30;

            this.pnlContent.Controls.AddRange(new System.Windows.Forms.Control[] {
                this.lblDashTitle, this.lblAnnouncementsHdr,
                this.btnRefresh, this.lstAnnouncements
            });

            this.Controls.Add(this.pnlContent);
            this.Controls.Add(this.pnlSidebar);

            this.pnlSidebar.ResumeLayout(false);
            this.pnlContent.ResumeLayout(false);
            this.ResumeLayout(false);
        }

        private void MakeSidebarButton(System.Windows.Forms.Button btn, string text, int top)
        {
            btn.Text      = text;
            btn.Location  = new System.Drawing.Point(15, top);
            btn.Size      = new System.Drawing.Size(190, 40);
            btn.BackColor = System.Drawing.Color.FromArgb(51, 65, 85);
            btn.ForeColor = System.Drawing.Color.White;
            btn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            btn.FlatAppearance.BorderSize = 0;
            btn.Font      = new System.Drawing.Font("Segoe UI", 9.5f);
            btn.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            btn.Cursor    = System.Windows.Forms.Cursors.Hand;
        }

        private System.Windows.Forms.Panel   pnlSidebar;
        private System.Windows.Forms.Panel   pnlContent;
        private System.Windows.Forms.Label   lblAppName;
        private System.Windows.Forms.Label   lblWelcome;
        private System.Windows.Forms.Button  btnBrowseSocieties;
        private System.Windows.Forms.Button  btnMyMemberships;
        private System.Windows.Forms.Button  btnEvents;
        private System.Windows.Forms.Button  btnMyTickets;
        private System.Windows.Forms.Button  btnLogout;
        private System.Windows.Forms.Label   lblDashTitle;
        private System.Windows.Forms.Label   lblAnnouncementsHdr;
        private System.Windows.Forms.ListBox lstAnnouncements;
        private System.Windows.Forms.Button  btnRefresh;
    }
}
