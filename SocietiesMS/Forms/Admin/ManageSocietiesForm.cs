using System;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Windows.Forms;

namespace SocietiesMS.Forms.Admin
{
    /// <summary>
    /// Admin form — create, approve, suspend, and delete societies.
    /// Also allows assigning a society head to any existing user.
    /// </summary>
    public partial class ManageSocietiesForm : Form
    {
        private int _editingSocietyId = -1;

        public ManageSocietiesForm()
        {
            InitializeComponent();
            LoadSocieties();
            LoadHeadCandidates();
        }

        /// <summary>
        /// Loads all non-deleted societies into the grid.
        /// Cyclomatic Complexity = 1
        /// </summary>
        private void LoadSocieties()
        {
            string sql = @"SELECT s.SocietyID, s.Name, s.Status,
                                  ISNULL(u.FullName,'— Unassigned —') AS Head,
                                  FORMAT(s.CreatedAt,'yyyy-MM-dd') AS CreatedOn
                           FROM Societies s
                           LEFT JOIN Users u ON s.HeadUserID = u.UserID
                           WHERE s.Status != 'Deleted'
                           ORDER BY s.Status, s.Name";
            dgvSocieties.DataSource = DBHelper.ExecuteQuery(sql);
            if (dgvSocieties.Columns.Contains("SocietyID"))
                dgvSocieties.Columns["SocietyID"].Visible = false;
        }

        /// <summary>
        /// Populates the Head dropdown with users who have the SocietyHead role.
        /// Cyclomatic Complexity = 1
        /// </summary>
        private void LoadHeadCandidates()
        {
            var dt = DBHelper.ExecuteQuery(
                "SELECT UserID, FullName FROM Users WHERE Role IN ('SocietyHead','Admin') AND IsActive=1");
            cmbHead.DisplayMember = "FullName";
            cmbHead.ValueMember   = "UserID";
            cmbHead.DataSource    = dt;
        }

        /// <summary>
        /// Populates the edit form fields when a society is selected in the grid.
        /// Cyclomatic Complexity = 2
        /// </summary>
        private void dgvSocieties_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvSocieties.SelectedRows.Count == 0) return;
            _editingSocietyId = Convert.ToInt32(dgvSocieties.SelectedRows[0].Cells["SocietyID"].Value);
            txtName.Text = dgvSocieties.SelectedRows[0].Cells["Name"].Value.ToString();
        }

        /// <summary>
        /// Creates a new society or updates the selected one.
        /// Cyclomatic Complexity = 4
        /// </summary>
        private void btnSave_Click(object sender, EventArgs e)
        {
            string name = txtName.Text.Trim();
            string desc = txtDesc.Text.Trim();
            if (string.IsNullOrEmpty(name))
            {
                MessageBox.Show("Society name is required.", "Validation",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            object headId = (cmbHead.SelectedValue != null)
                ? (object)Convert.ToInt32(cmbHead.SelectedValue)
                : DBNull.Value;

            if (_editingSocietyId < 0)
            {
                // Create
                DBHelper.ExecuteNonQuery(
                    @"INSERT INTO Societies (Name, Description, HeadUserID, Status)
                      VALUES (@Name, @Desc, @Head, 'Pending')",
                    new SqlParameter("@Name", name),
                    new SqlParameter("@Desc", desc),
                    new SqlParameter("@Head", headId));
                MessageBox.Show("Society created with Pending status.", "Created",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                DBHelper.ExecuteNonQuery(
                    "UPDATE Societies SET Name=@Name, Description=@Desc, HeadUserID=@Head WHERE SocietyID=@SID",
                    new SqlParameter("@Name", name),
                    new SqlParameter("@Desc", desc),
                    new SqlParameter("@Head", headId),
                    new SqlParameter("@SID",  _editingSocietyId));
                MessageBox.Show("Society updated.", "Updated",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                _editingSocietyId = -1;
            }

            txtName.Text = "";
            txtDesc.Text = "";
            LoadSocieties();
        }

        /// <summary>
        /// Changes the status of the selected society.
        /// Cyclomatic Complexity = 3
        /// </summary>
        private void SetStatus(string status)
        {
            if (_editingSocietyId < 0)
            {
                MessageBox.Show("Select a society first.", "Notice",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            var confirm = MessageBox.Show($"Set status to '{status}'?", "Confirm",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (confirm != DialogResult.Yes) return;

            DBHelper.ExecuteNonQuery(
                "UPDATE Societies SET Status=@Status WHERE SocietyID=@SID",
                new SqlParameter("@Status", status),
                new SqlParameter("@SID",    _editingSocietyId));

            _editingSocietyId = -1;
            LoadSocieties();
        }

        private void btnApprove_Click(object sender, EventArgs e)  => SetStatus("Active");
        private void btnSuspend_Click(object sender, EventArgs e)  => SetStatus("Suspended");
        private void btnDelete_Click(object sender, EventArgs e)   => SetStatus("Deleted");
        private void btnNew_Click(object sender, EventArgs e)      { _editingSocietyId = -1; txtName.Text = ""; txtDesc.Text = ""; }
        private void btnRefresh_Click(object sender, EventArgs e)  => LoadSocieties();
    }
}
