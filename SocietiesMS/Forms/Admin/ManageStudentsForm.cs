using System;
using System.Data.SqlClient;
using System.Drawing;
using System.Windows.Forms;

namespace SocietiesMS.Forms.Admin
{
    /// <summary>
    /// Admin form — view all student accounts and manage their active status.
    /// </summary>
    public partial class ManageStudentsForm : Form
    {
        public ManageStudentsForm()
        {
            InitializeComponent();
            LoadStudents();
        }

        /// <summary>
        /// Loads all student users into the grid.
        /// Cyclomatic Complexity = 1
        /// </summary>
        private void LoadStudents()
        {
            string sql = @"SELECT UserID, FullName, Email,
                                  CASE IsActive WHEN 1 THEN 'Active' ELSE 'Inactive' END AS Status,
                                  FORMAT(CreatedAt,'yyyy-MM-dd') AS RegisteredOn
                           FROM Users
                           WHERE Role = 'Student'
                           ORDER BY CreatedAt DESC";
            dgvStudents.DataSource = DBHelper.ExecuteQuery(sql);
            if (dgvStudents.Columns.Contains("UserID"))
                dgvStudents.Columns["UserID"].Visible = false;
        }

        /// <summary>
        /// Toggles the active status of the selected student (activate/deactivate).
        /// Cyclomatic Complexity = 4
        /// </summary>
        private void btnToggleActive_Click(object sender, EventArgs e)
        {
            if (dgvStudents.SelectedRows.Count == 0)
            {
                MessageBox.Show("Select a student first.", "Notice",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            int userId       = Convert.ToInt32(dgvStudents.SelectedRows[0].Cells["UserID"].Value);
            string name      = dgvStudents.SelectedRows[0].Cells["FullName"].Value.ToString();
            string curStatus = dgvStudents.SelectedRows[0].Cells["Status"].Value.ToString();
            bool   newActive = curStatus == "Inactive";

            string action = newActive ? "Activate" : "Deactivate";
            var confirm = MessageBox.Show($"{action} account for '{name}'?", "Confirm",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (confirm != DialogResult.Yes) return;

            DBHelper.ExecuteNonQuery(
                "UPDATE Users SET IsActive=@Active WHERE UserID=@UID",
                new SqlParameter("@Active", newActive),
                new SqlParameter("@UID",    userId));

            LoadStudents();
        }

        /// <summary>
        /// Permanently deletes a student account and all their memberships/registrations.
        /// Cyclomatic Complexity = 3
        /// </summary>
        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (dgvStudents.SelectedRows.Count == 0)
            {
                MessageBox.Show("Select a student to delete.", "Notice",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            int userId = Convert.ToInt32(dgvStudents.SelectedRows[0].Cells["UserID"].Value);
            string name = dgvStudents.SelectedRows[0].Cells["FullName"].Value.ToString();

            var confirm = MessageBox.Show(
                $"Permanently delete account for '{name}'?\nThis will also remove all memberships and event registrations.",
                "Confirm Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (confirm != DialogResult.Yes) return;

            // Cascade deletes handle SocietyMembers and EventRegistrations via FK
            DBHelper.ExecuteNonQuery(
                "DELETE FROM Users WHERE UserID=@UID",
                new SqlParameter("@UID", userId));

            LoadStudents();
        }

        private void btnRefresh_Click(object sender, EventArgs e) => LoadStudents();

        /// <summary>
        /// Searches students by name or email.
        /// Cyclomatic Complexity = 2
        /// </summary>
        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            string keyword = txtSearch.Text.Trim();
            if (string.IsNullOrEmpty(keyword))
            {
                LoadStudents();
                return;
            }

            string sql = @"SELECT UserID, FullName, Email,
                                  CASE IsActive WHEN 1 THEN 'Active' ELSE 'Inactive' END AS Status,
                                  FORMAT(CreatedAt,'yyyy-MM-dd') AS RegisteredOn
                           FROM Users
                           WHERE Role='Student' AND (FullName LIKE @K OR Email LIKE @K)";
            dgvStudents.DataSource = DBHelper.ExecuteQuery(sql,
                new SqlParameter("@K", "%" + keyword + "%"));
            if (dgvStudents.Columns.Contains("UserID"))
                dgvStudents.Columns["UserID"].Visible = false;
        }
    }
}
