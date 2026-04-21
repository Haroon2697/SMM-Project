using System;
using System.Data.SqlClient;
using System.Drawing;
using System.Windows.Forms;
using SocietiesMS.Models;

namespace SocietiesMS.Forms.Admin
{
    /// <summary>
    /// Admin dashboard — system-wide management hub.
    /// Displays key statistics across all societies, events, and users.
    /// </summary>
    public partial class AdminDashboard : Form
    {
        public AdminDashboard()
        {
            InitializeComponent();
            lblWelcome.Text = $"Welcome, {User.Current.FullName}";
            LoadStats();
        }

        /// <summary>
        /// Loads system-wide statistics for the admin dashboard.
        /// Cyclomatic Complexity = 1
        /// </summary>
        private void LoadStats()
        {
            object students   = DBHelper.ExecuteScalar("SELECT COUNT(*) FROM Users WHERE Role='Student' AND IsActive=1");
            object societies  = DBHelper.ExecuteScalar("SELECT COUNT(*) FROM Societies WHERE Status='Active'");
            object pending    = DBHelper.ExecuteScalar("SELECT COUNT(*) FROM Societies WHERE Status='Pending'");
            object events     = DBHelper.ExecuteScalar("SELECT COUNT(*) FROM Events WHERE ApprovalStatus='Pending'");
            object evApproved = DBHelper.ExecuteScalar("SELECT COUNT(*) FROM Events WHERE ApprovalStatus='Approved'");
            object members    = DBHelper.ExecuteScalar("SELECT COUNT(*) FROM SocietyMembers WHERE Status='Approved'");

            lblStatStudents.Text  = $"👨‍🎓  Total Students      : {students}";
            lblStatSocieties.Text = $"🏛   Active Societies    : {societies}";
            lblStatPending.Text   = $"⏳  Pending Societies   : {pending}";
            lblStatEvents.Text    = $"📅  Pending Events      : {events}";
            lblStatApproved.Text  = $"✅  Approved Events     : {evApproved}";
            lblStatMembers.Text   = $"👥  Total Memberships   : {members}";
        }

        // Navigation
        private void btnManageStudents_Click(object sender, EventArgs e)  => new ManageStudentsForm().ShowDialog();
        private void btnManageSocieties_Click(object sender, EventArgs e) { new ManageSocietiesForm().ShowDialog(); LoadStats(); }
        private void btnApproveEvents_Click(object sender, EventArgs e)   { new ApproveEventsForm().ShowDialog(); LoadStats(); }
        private void btnReports_Click(object sender, EventArgs e)         => new AdminReportsForm().ShowDialog();

        /// <summary>Logs out admin and closes dashboard.</summary>
        private void btnLogout_Click(object sender, EventArgs e)
        {
            User.Current = null;
            this.Close();
        }

        private void btnRefresh_Click(object sender, EventArgs e) => LoadStats();
    }
}
