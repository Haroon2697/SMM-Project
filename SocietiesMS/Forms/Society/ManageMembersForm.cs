using System;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Windows.Forms;

namespace SocietiesMS.Forms.Society
{
    /// <summary>
    /// Allows Society Head to view all membership requests and approve/reject them.
    /// Also shows the full approved member list.
    /// </summary>
    public partial class ManageMembersForm : Form
    {
        private readonly int _societyId;

        public ManageMembersForm(int societyId)
        {
            InitializeComponent();
            _societyId = societyId;
            LoadPending();
            LoadMembers();
        }

        /// <summary>
        /// Loads all pending membership requests for this society.
        /// Cyclomatic Complexity = 1
        /// </summary>
        private void LoadPending()
        {
            string sql = @"SELECT sm.MemberID, u.FullName, u.Email,
                                  FORMAT(sm.JoinedAt,'yyyy-MM-dd') AS AppliedOn
                           FROM SocietyMembers sm
                           JOIN Users u ON sm.UserID = u.UserID
                           WHERE sm.SocietyID = @SID AND sm.Status = 'Pending'";
            dgvPending.DataSource = DBHelper.ExecuteQuery(sql,
                new SqlParameter("@SID", _societyId));
            if (dgvPending.Columns.Contains("MemberID"))
                dgvPending.Columns["MemberID"].Visible = false;
        }

        /// <summary>
        /// Loads the approved member list for this society.
        /// Cyclomatic Complexity = 1
        /// </summary>
        private void LoadMembers()
        {
            string sql = @"SELECT u.FullName, u.Email, sm.Role,
                                  FORMAT(sm.JoinedAt,'yyyy-MM-dd') AS JoinedOn
                           FROM SocietyMembers sm
                           JOIN Users u ON sm.UserID = u.UserID
                           WHERE sm.SocietyID = @SID AND sm.Status = 'Approved'
                           ORDER BY sm.Role, u.FullName";
            dgvMembers.DataSource = DBHelper.ExecuteQuery(sql,
                new SqlParameter("@SID", _societyId));
        }

        /// <summary>
        /// Approves or rejects the selected pending membership request.
        /// Cyclomatic Complexity = 4
        /// </summary>
        private void UpdateMemberStatus(string newStatus)
        {
            if (dgvPending.SelectedRows.Count == 0)
            {
                MessageBox.Show("Select a request first.", "Notice",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            int memberId = Convert.ToInt32(dgvPending.SelectedRows[0].Cells["MemberID"].Value);
            string name  = dgvPending.SelectedRows[0].Cells["FullName"].Value.ToString();

            var confirm = MessageBox.Show(
                $"{newStatus} the request from '{name}'?", "Confirm",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (confirm != DialogResult.Yes) return;

            DBHelper.ExecuteNonQuery(
                "UPDATE SocietyMembers SET Status=@Status WHERE MemberID=@MID",
                new SqlParameter("@Status", newStatus),
                new SqlParameter("@MID", memberId));

            LoadPending();
            LoadMembers();
        }

        private void btnApprove_Click(object sender, EventArgs e) => UpdateMemberStatus("Approved");
        private void btnReject_Click(object sender, EventArgs e)  => UpdateMemberStatus("Rejected");

        /// <summary>
        /// Removes an approved member from the society.
        /// Cyclomatic Complexity = 3
        /// </summary>
        private void btnRemove_Click(object sender, EventArgs e)
        {
            if (dgvMembers.SelectedRows.Count == 0)
            {
                MessageBox.Show("Select a member to remove.", "Notice",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            string memberEmail = dgvMembers.SelectedRows[0].Cells["Email"].Value.ToString();
            var confirm = MessageBox.Show(
                $"Remove '{dgvMembers.SelectedRows[0].Cells["FullName"].Value}'?",
                "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (confirm != DialogResult.Yes) return;

            DBHelper.ExecuteNonQuery(
                @"DELETE FROM SocietyMembers
                  WHERE SocietyID=@SID AND UserID=(SELECT UserID FROM Users WHERE Email=@Email)",
                new SqlParameter("@SID",   _societyId),
                new SqlParameter("@Email", memberEmail));

            LoadMembers();
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            LoadPending();
            LoadMembers();
        }
    }
}
