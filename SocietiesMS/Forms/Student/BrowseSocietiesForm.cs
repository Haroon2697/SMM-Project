using System;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Windows.Forms;
using SocietiesMS.Models;

namespace SocietiesMS.Forms.Student
{
    /// <summary>
    /// Browse all active societies and apply for membership.
    /// </summary>
    public partial class BrowseSocietiesForm : Form
    {
        public BrowseSocietiesForm()
        {
            InitializeComponent();
            LoadSocieties();
        }

        /// <summary>
        /// Loads all active societies into the DataGridView.
        /// Cyclomatic Complexity = 1
        /// </summary>
        private void LoadSocieties()
        {
            string sql = @"SELECT s.SocietyID, s.Name, s.Description, s.Status,
                                  ISNULL(u.FullName,'—') AS HeadName,
                                  COUNT(sm.MemberID) AS Members
                           FROM Societies s
                           LEFT JOIN Users u ON s.HeadUserID = u.UserID
                           LEFT JOIN SocietyMembers sm ON s.SocietyID = sm.SocietyID AND sm.Status='Approved'
                           WHERE s.Status = 'Active'
                           GROUP BY s.SocietyID, s.Name, s.Description, s.Status, u.FullName";
            var dt = DBHelper.ExecuteQuery(sql);
            dgvSocieties.DataSource = dt;
            // Hide ID column
            if (dgvSocieties.Columns.Contains("SocietyID"))
                dgvSocieties.Columns["SocietyID"].Visible = false;
        }

        /// <summary>
        /// Applies the current student to the selected society.
        /// Checks for existing/pending/approved memberships before inserting.
        /// Cyclomatic Complexity = 5
        /// </summary>
        private void btnApply_Click(object sender, EventArgs e)
        {
            if (dgvSocieties.SelectedRows.Count == 0)
            {
                MessageBox.Show("Please select a society.", "Notice",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            int societyId = Convert.ToInt32(dgvSocieties.SelectedRows[0].Cells["SocietyID"].Value);
            string societyName = dgvSocieties.SelectedRows[0].Cells["Name"].Value.ToString();

            // Check if already applied
            object existing = DBHelper.ExecuteScalar(
                "SELECT Status FROM SocietyMembers WHERE SocietyID=@SID AND UserID=@UID",
                new SqlParameter("@SID", societyId),
                new SqlParameter("@UID", User.Current.UserID));

            if (existing != null)
            {
                string status = existing.ToString();
                if (status == "Approved")
                    MessageBox.Show("You are already a member of this society.", "Info",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                else if (status == "Pending")
                    MessageBox.Show("Your application is already pending approval.", "Info",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                else
                    MessageBox.Show("Your previous application was rejected. Contact the society head.", "Info",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            int rows = DBHelper.ExecuteNonQuery(
                @"INSERT INTO SocietyMembers (SocietyID, UserID, Role, Status)
                  VALUES (@SID, @UID, 'Member', 'Pending')",
                new SqlParameter("@SID", societyId),
                new SqlParameter("@UID", User.Current.UserID));

            if (rows > 0)
            {
                MessageBox.Show($"Application submitted to '{societyName}'! Wait for approval.",
                    "Application Sent", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        /// <summary>Refreshes the society list.</summary>
        private void btnRefresh_Click(object sender, EventArgs e) => LoadSocieties();
    }
}
