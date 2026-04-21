using System;
using System.Drawing;
using System.Windows.Forms;
using SocietiesMS.Models;

namespace SocietiesMS.Forms.Student
{
    /// <summary>
    /// Student dashboard — main navigation hub after login.
    /// Displays a welcome message and navigation cards to all student features.
    /// </summary>
    public partial class StudentDashboard : Form
    {
        public StudentDashboard()
        {
            InitializeComponent();
            lblWelcome.Text = $"Welcome back, {User.Current.FullName}!";
            LoadAnnouncements();
        }

        /// <summary>
        /// Loads the latest global + society announcements into the listbox.
        /// Cyclomatic Complexity = 1
        /// </summary>
        private void LoadAnnouncements()
        {
            string sql = @"SELECT TOP 5 a.Title, a.Body, ISNULL(s.Name,'Global') AS Source, a.PostedAt
                           FROM Announcements a
                           LEFT JOIN Societies s ON a.SocietyID = s.SocietyID
                           ORDER BY a.PostedAt DESC";
            var dt = DBHelper.ExecuteQuery(sql);
            lstAnnouncements.Items.Clear();
            foreach (System.Data.DataRow row in dt.Rows)
            {
                lstAnnouncements.Items.Add(
                    $"[{row["Source"]}]  {row["Title"]}  —  {Convert.ToDateTime(row["PostedAt"]):MMM dd}");
            }
        }

        // ---------------------------------------------------------------
        // Navigation buttons
        // ---------------------------------------------------------------

        private void btnBrowseSocieties_Click(object sender, EventArgs e)
            => new BrowseSocietiesForm().ShowDialog();

        private void btnMyMemberships_Click(object sender, EventArgs e)
            => new MyMembershipsForm().ShowDialog();

        private void btnEvents_Click(object sender, EventArgs e)
            => new EventsForm().ShowDialog();

        private void btnMyTickets_Click(object sender, EventArgs e)
            => new MyTicketsForm().ShowDialog();

        /// <summary>
        /// Logs out the current user and returns to the login screen.
        /// Cyclomatic Complexity = 1
        /// </summary>
        private void btnLogout_Click(object sender, EventArgs e)
        {
            User.Current = null;
            this.Close();
        }

        /// <summary>
        /// Refreshes the announcement list when the refresh button is clicked.
        /// Cyclomatic Complexity = 1
        /// </summary>
        private void btnRefresh_Click(object sender, EventArgs e)
        {
            LoadAnnouncements();
        }
    }
}
