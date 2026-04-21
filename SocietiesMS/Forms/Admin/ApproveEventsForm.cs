using System;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Windows.Forms;

namespace SocietiesMS.Forms.Admin
{
    /// <summary>
    /// Admin form — review all pending event requests and approve or reject them.
    /// Shows event details and current registration count.
    /// </summary>
    public partial class ApproveEventsForm : Form
    {
        public ApproveEventsForm()
        {
            InitializeComponent();
            LoadEvents();
        }

        /// <summary>
        /// Loads all events with their approval status into the grid.
        /// Cyclomatic Complexity = 1
        /// </summary>
        private void LoadEvents()
        {
            string sql = @"SELECT e.EventID, s.Name AS Society, e.Title, e.Venue,
                                  FORMAT(e.EventDate,'yyyy-MM-dd HH:mm') AS EventDate,
                                  e.MaxCapacity, e.ApprovalStatus,
                                  COUNT(er.RegistrationID) AS Registrations
                           FROM Events e
                           JOIN Societies s ON e.SocietyID = s.SocietyID
                           LEFT JOIN EventRegistrations er ON e.EventID = er.EventID
                           GROUP BY e.EventID, s.Name, e.Title, e.Venue,
                                    e.EventDate, e.MaxCapacity, e.ApprovalStatus
                           ORDER BY
                               CASE e.ApprovalStatus WHEN 'Pending' THEN 0 ELSE 1 END,
                               e.EventDate DESC";
            dgvEvents.DataSource = DBHelper.ExecuteQuery(sql);
            if (dgvEvents.Columns.Contains("EventID"))
                dgvEvents.Columns["EventID"].Visible = false;

            // Highlight pending rows
            foreach (DataGridViewRow row in dgvEvents.Rows)
            {
                string status = row.Cells["ApprovalStatus"].Value?.ToString();
                if (status == "Pending")
                    row.DefaultCellStyle.ForeColor = Color.FromArgb(251, 191, 36);
                else if (status == "Approved")
                    row.DefaultCellStyle.ForeColor = Color.FromArgb(74, 222, 128);
                else if (status == "Rejected" || status == "Cancelled")
                    row.DefaultCellStyle.ForeColor = Color.FromArgb(248, 113, 113);
            }
        }

        /// <summary>
        /// Approves or rejects the selected event.
        /// Cyclomatic Complexity = 4
        /// </summary>
        private void UpdateEventStatus(string newStatus)
        {
            if (dgvEvents.SelectedRows.Count == 0)
            {
                MessageBox.Show("Select an event first.", "Notice",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            int eventId    = Convert.ToInt32(dgvEvents.SelectedRows[0].Cells["EventID"].Value);
            string title   = dgvEvents.SelectedRows[0].Cells["Title"].Value.ToString();
            string current = dgvEvents.SelectedRows[0].Cells["ApprovalStatus"].Value.ToString();

            if (current != "Pending")
            {
                MessageBox.Show("Only Pending events can be approved or rejected.", "Notice",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            var confirm = MessageBox.Show($"Set '{title}' to {newStatus}?", "Confirm",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (confirm != DialogResult.Yes) return;

            DBHelper.ExecuteNonQuery(
                "UPDATE Events SET ApprovalStatus=@Status WHERE EventID=@EID",
                new SqlParameter("@Status", newStatus),
                new SqlParameter("@EID",    eventId));

            LoadEvents();
        }

        private void btnApprove_Click(object sender, EventArgs e) => UpdateEventStatus("Approved");
        private void btnReject_Click(object sender, EventArgs e)  => UpdateEventStatus("Rejected");
        private void btnRefresh_Click(object sender, EventArgs e) => LoadEvents();
    }
}
