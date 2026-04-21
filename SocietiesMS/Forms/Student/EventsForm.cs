using System;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Windows.Forms;
using SocietiesMS.Models;

namespace SocietiesMS.Forms.Student
{
    /// <summary>
    /// Displays all upcoming approved events. Students can register for events here.
    /// </summary>
    public partial class EventsForm : Form
    {
        public EventsForm()
        {
            InitializeComponent();
            LoadEvents();
        }

        /// <summary>
        /// Loads all upcoming approved events with registration count.
        /// Cyclomatic Complexity = 1
        /// </summary>
        private void LoadEvents()
        {
            string sql = @"SELECT e.EventID, s.Name AS Society, e.Title, e.Description,
                                  FORMAT(e.EventDate,'yyyy-MM-dd HH:mm') AS EventDate,
                                  e.Venue, e.MaxCapacity,
                                  COUNT(er.RegistrationID) AS Registered
                           FROM Events e
                           JOIN Societies s ON e.SocietyID = s.SocietyID
                           LEFT JOIN EventRegistrations er ON e.EventID = er.EventID
                           WHERE e.ApprovalStatus = 'Approved' AND e.EventDate >= GETDATE()
                           GROUP BY e.EventID, s.Name, e.Title, e.Description,
                                    e.EventDate, e.Venue, e.MaxCapacity
                           ORDER BY e.EventDate";
            var dt = DBHelper.ExecuteQuery(sql);
            dgvEvents.DataSource = dt;
            if (dgvEvents.Columns.Contains("EventID"))
                dgvEvents.Columns["EventID"].Visible = false;
        }

        /// <summary>
        /// Registers the current student for the selected event.
        /// Checks capacity and duplicate registration.
        /// Cyclomatic Complexity = 5
        /// </summary>
        private void btnRegister_Click(object sender, EventArgs e)
        {
            if (dgvEvents.SelectedRows.Count == 0)
            {
                MessageBox.Show("Please select an event.", "Notice",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            int eventId     = Convert.ToInt32(dgvEvents.SelectedRows[0].Cells["EventID"].Value);
            int maxCapacity = Convert.ToInt32(dgvEvents.SelectedRows[0].Cells["MaxCapacity"].Value);
            int registered  = Convert.ToInt32(dgvEvents.SelectedRows[0].Cells["Registered"].Value);
            string title    = dgvEvents.SelectedRows[0].Cells["Title"].Value.ToString();

            // Capacity check
            if (registered >= maxCapacity)
            {
                MessageBox.Show("This event is fully booked.", "Full",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Duplicate check
            object dup = DBHelper.ExecuteScalar(
                "SELECT COUNT(1) FROM EventRegistrations WHERE EventID=@EID AND UserID=@UID",
                new SqlParameter("@EID", eventId),
                new SqlParameter("@UID", User.Current.UserID));

            if (dup != null && Convert.ToInt32(dup) > 0)
            {
                MessageBox.Show("You are already registered for this event.", "Already Registered",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            // Insert registration with unique ticket code
            string ticket = DBHelper.GenerateTicketCode();
            DBHelper.ExecuteNonQuery(
                @"INSERT INTO EventRegistrations (EventID, UserID, TicketCode)
                  VALUES (@EID, @UID, @Code)",
                new SqlParameter("@EID",  eventId),
                new SqlParameter("@UID",  User.Current.UserID),
                new SqlParameter("@Code", ticket));

            MessageBox.Show($"Registered for '{title}'!\nYour ticket code: {ticket}",
                "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            LoadEvents();
        }

        private void btnRefresh_Click(object sender, EventArgs e) => LoadEvents();
    }
}
