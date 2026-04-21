using System;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Windows.Forms;
using SocietiesMS.Models;

namespace SocietiesMS.Forms.Society
{
    /// <summary>
    /// Allows Society Head to create, update, and cancel society events.
    /// Events require admin approval before becoming visible to students.
    /// </summary>
    public partial class ManageEventsForm : Form
    {
        private readonly int _societyId;
        private int _editingEventId = -1;

        public ManageEventsForm(int societyId)
        {
            InitializeComponent();
            _societyId = societyId;
            LoadEvents();
        }

        /// <summary>
        /// Loads all events for this society into the grid.
        /// Cyclomatic Complexity = 1
        /// </summary>
        private void LoadEvents()
        {
            string sql = @"SELECT EventID, Title, Venue,
                                  FORMAT(EventDate,'yyyy-MM-dd HH:mm') AS EventDate,
                                  MaxCapacity, ApprovalStatus
                           FROM Events
                           WHERE SocietyID = @SID
                           ORDER BY EventDate DESC";
            dgvEvents.DataSource = DBHelper.ExecuteQuery(sql,
                new SqlParameter("@SID", _societyId));
            if (dgvEvents.Columns.Contains("EventID"))
                dgvEvents.Columns["EventID"].Visible = false;
        }

        /// <summary>
        /// Populates form fields from the selected event for editing.
        /// Cyclomatic Complexity = 2
        /// </summary>
        private void dgvEvents_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvEvents.SelectedRows.Count == 0) return;
            DataGridViewRow row = dgvEvents.SelectedRows[0];
            _editingEventId     = Convert.ToInt32(row.Cells["EventID"].Value);
            txtTitle.Text       = row.Cells["Title"].Value.ToString();
            txtVenue.Text       = row.Cells["Venue"].Value?.ToString() ?? "";
            numCapacity.Value   = Convert.ToInt32(row.Cells["MaxCapacity"].Value);
            if (DateTime.TryParse(row.Cells["EventDate"].Value.ToString(), out DateTime dt))
                dtpEventDate.Value = dt;
        }

        /// <summary>
        /// Creates a new event or updates an existing one.
        /// Cyclomatic Complexity = 5
        /// </summary>
        private void btnSave_Click(object sender, EventArgs e)
        {
            string title = txtTitle.Text.Trim();
            string venue = txtVenue.Text.Trim();
            string desc  = txtDescription.Text.Trim();

            if (string.IsNullOrEmpty(title))
            {
                MessageBox.Show("Event title is required.", "Validation",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (dtpEventDate.Value <= DateTime.Now)
            {
                MessageBox.Show("Event date must be in the future.", "Validation",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (_editingEventId < 0)
            {
                // Create
                DBHelper.ExecuteNonQuery(
                    @"INSERT INTO Events (SocietyID, Title, Description, EventDate, Venue, MaxCapacity, ApprovalStatus)
                      VALUES (@SID, @Title, @Desc, @Date, @Venue, @Cap, 'Pending')",
                    new SqlParameter("@SID",   _societyId),
                    new SqlParameter("@Title", title),
                    new SqlParameter("@Desc",  desc),
                    new SqlParameter("@Date",  dtpEventDate.Value),
                    new SqlParameter("@Venue", venue),
                    new SqlParameter("@Cap",   (int)numCapacity.Value));
                MessageBox.Show("Event created! Awaiting admin approval.", "Created",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                // Update
                DBHelper.ExecuteNonQuery(
                    @"UPDATE Events SET Title=@Title, Description=@Desc, EventDate=@Date,
                      Venue=@Venue, MaxCapacity=@Cap
                      WHERE EventID=@EID",
                    new SqlParameter("@Title", title),
                    new SqlParameter("@Desc",  desc),
                    new SqlParameter("@Date",  dtpEventDate.Value),
                    new SqlParameter("@Venue", venue),
                    new SqlParameter("@Cap",   (int)numCapacity.Value),
                    new SqlParameter("@EID",   _editingEventId));
                MessageBox.Show("Event updated.", "Updated",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                _editingEventId = -1;
            }

            ClearForm();
            LoadEvents();
        }

        /// <summary>
        /// Cancels the selected event (sets status to Cancelled).
        /// Cyclomatic Complexity = 3
        /// </summary>
        private void btnCancel_Click(object sender, EventArgs e)
        {
            if (_editingEventId < 0)
            {
                MessageBox.Show("Select an event to cancel.", "Notice",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            var confirm = MessageBox.Show("Cancel this event?", "Confirm",
                MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (confirm != DialogResult.Yes) return;

            DBHelper.ExecuteNonQuery(
                "UPDATE Events SET ApprovalStatus='Cancelled' WHERE EventID=@EID",
                new SqlParameter("@EID", _editingEventId));

            _editingEventId = -1;
            ClearForm();
            LoadEvents();
        }

        /// <summary>Clears all input fields and resets state for new event entry.</summary>
        private void ClearForm()
        {
            _editingEventId   = -1;
            txtTitle.Text     = "";
            txtVenue.Text     = "";
            txtDescription.Text = "";
            numCapacity.Value = 100;
            dtpEventDate.Value = DateTime.Now.AddDays(7);
        }

        private void btnNew_Click(object sender, EventArgs e)  => ClearForm();
        private void btnRefresh_Click(object sender, EventArgs e) => LoadEvents();
    }
}
