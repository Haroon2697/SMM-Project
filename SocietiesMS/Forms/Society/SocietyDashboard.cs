using System;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Windows.Forms;
using SocietiesMS.Models;

namespace SocietiesMS.Forms.Society
{
    /// <summary>
    /// Society Head dashboard — main navigation hub for society management.
    /// Loads the head's society automatically based on their UserID.
    /// </summary>
    public partial class SocietyDashboard : Form
    {
        private int _societyId;
        private string _societyName;

        public SocietyDashboard()
        {
            InitializeComponent();
            LoadSocietyInfo();
        }

        /// <summary>
        /// Finds the society managed by the logged-in head and populates dashboard stats.
        /// Cyclomatic Complexity = 3
        /// </summary>
        private void LoadSocietyInfo()
        {
            string sql = @"SELECT SocietyID, Name, Description, Status
                           FROM Societies
                           WHERE HeadUserID = @UID AND Status != 'Deleted'";
            DataTable dt = DBHelper.ExecuteQuery(sql,
                new SqlParameter("@UID", User.Current.UserID));

            if (dt.Rows.Count == 0)
            {
                MessageBox.Show("No society assigned to your account. Contact the admin.",
                    "No Society", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                this.Close();
                return;
            }

            _societyId   = Convert.ToInt32(dt.Rows[0]["SocietyID"]);
            _societyName = dt.Rows[0]["Name"].ToString();

            lblWelcome.Text     = $"Welcome, {User.Current.FullName}";
            lblSocietyName.Text = $"🏛  {_societyName}";
            lblStatus.Text      = $"Status: {dt.Rows[0]["Status"]}";

            LoadStats();
        }

        /// <summary>
        /// Loads quick stats (member count, event count, pending count).
        /// Cyclomatic Complexity = 1
        /// </summary>
        private void LoadStats()
        {
            object members = DBHelper.ExecuteScalar(
                "SELECT COUNT(*) FROM SocietyMembers WHERE SocietyID=@SID AND Status='Approved'",
                new SqlParameter("@SID", _societyId));

            object pending = DBHelper.ExecuteScalar(
                "SELECT COUNT(*) FROM SocietyMembers WHERE SocietyID=@SID AND Status='Pending'",
                new SqlParameter("@SID", _societyId));

            object events = DBHelper.ExecuteScalar(
                "SELECT COUNT(*) FROM Events WHERE SocietyID=@SID AND ApprovalStatus='Approved'",
                new SqlParameter("@SID", _societyId));

            lblStatMembers.Text = $"👥  Members: {members}";
            lblStatPending.Text = $"⏳  Pending Requests: {pending}";
            lblStatEvents.Text  = $"📅  Active Events: {events}";
        }

        // Navigation handlers
        private void btnManageMembers_Click(object sender, EventArgs e)
        {
            new ManageMembersForm(_societyId).ShowDialog();
            LoadStats();
        }
        private void btnManageEvents_Click(object sender, EventArgs e)
        {
            new ManageEventsForm(_societyId).ShowDialog();
            LoadStats();
        }
        private void btnTasks_Click(object sender, EventArgs e)
            => new TasksForm(_societyId).ShowDialog();

        private void btnReports_Click(object sender, EventArgs e)
            => new SocietyReportsForm(_societyId).ShowDialog();

        /// <summary>Logs out and closes the dashboard.</summary>
        private void btnLogout_Click(object sender, EventArgs e)
        {
            User.Current = null;
            this.Close();
        }
    }
}
