using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using SocietiesMS.Models;

namespace SocietiesMS.Forms.Student
{
    /// <summary>
    /// Shows all society membership applications for the current student,
    /// including their current status (Pending / Approved / Rejected).
    /// </summary>
    public partial class MyMembershipsForm : Form
    {
        public MyMembershipsForm()
        {
            InitializeComponent();
            LoadMemberships();
        }

        /// <summary>
        /// Loads all membership records for the current student.
        /// Cyclomatic Complexity = 1
        /// </summary>
        private void LoadMemberships()
        {
            string sql = @"SELECT s.Name AS Society, sm.Role, sm.Status,
                                  FORMAT(sm.JoinedAt,'yyyy-MM-dd') AS AppliedOn
                           FROM SocietyMembers sm
                           JOIN Societies s ON sm.SocietyID = s.SocietyID
                           WHERE sm.UserID = @UserID
                           ORDER BY sm.JoinedAt DESC";
            var dt = DBHelper.ExecuteQuery(sql,
                new System.Data.SqlClient.SqlParameter("@UserID", User.Current.UserID));
            dgvMemberships.DataSource = dt;

            // Colour-code status column
            foreach (DataGridViewRow row in dgvMemberships.Rows)
            {
                if (row.Cells["Status"].Value?.ToString() == "Approved")
                    row.DefaultCellStyle.ForeColor = Color.FromArgb(74, 222, 128);
                else if (row.Cells["Status"].Value?.ToString() == "Rejected")
                    row.DefaultCellStyle.ForeColor = Color.FromArgb(248, 113, 113);
                else
                    row.DefaultCellStyle.ForeColor = Color.FromArgb(251, 191, 36);
            }
        }

        private void btnRefresh_Click(object sender, EventArgs e) => LoadMemberships();

        /// <summary>
        /// Cancels (withdraws) a pending membership application.
        /// Cyclomatic Complexity = 4
        /// </summary>
        private void btnCancel_Click(object sender, EventArgs e)
        {
            if (dgvMemberships.SelectedRows.Count == 0)
            {
                MessageBox.Show("Select a membership to cancel.", "Notice",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            string status = dgvMemberships.SelectedRows[0].Cells["Status"].Value?.ToString();
            if (status != "Pending")
            {
                MessageBox.Show("Only pending applications can be cancelled.", "Notice",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            string society = dgvMemberships.SelectedRows[0].Cells["Society"].Value.ToString();
            var confirm = MessageBox.Show($"Cancel application to '{society}'?", "Confirm",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (confirm != DialogResult.Yes) return;

            DBHelper.ExecuteNonQuery(
                @"DELETE FROM SocietyMembers
                  WHERE UserID=@UID AND SocietyID=(SELECT SocietyID FROM Societies WHERE Name=@Name)",
                new System.Data.SqlClient.SqlParameter("@UID",  User.Current.UserID),
                new System.Data.SqlClient.SqlParameter("@Name", society));

            LoadMemberships();
        }
    }
}
