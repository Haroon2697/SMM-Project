using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using SocietiesMS.Models;

namespace SocietiesMS.Forms.Student
{
    /// <summary>
    /// Displays all event tickets/passes belonging to the current student.
    /// </summary>
    public partial class MyTicketsForm : Form
    {
        public MyTicketsForm()
        {
            InitializeComponent();
            LoadTickets();
        }

        /// <summary>
        /// Loads all event registrations for the current student.
        /// Cyclomatic Complexity = 1
        /// </summary>
        private void LoadTickets()
        {
            string sql = @"SELECT er.TicketCode, e.Title AS Event,
                                  s.Name AS Society,
                                  FORMAT(e.EventDate,'yyyy-MM-dd HH:mm') AS EventDate,
                                  e.Venue,
                                  FORMAT(er.RegisteredAt,'yyyy-MM-dd') AS RegisteredOn
                           FROM EventRegistrations er
                           JOIN Events e ON er.EventID = e.EventID
                           JOIN Societies s ON e.SocietyID = s.SocietyID
                           WHERE er.UserID = @UserID
                           ORDER BY e.EventDate DESC";
            var dt = DBHelper.ExecuteQuery(sql,
                new System.Data.SqlClient.SqlParameter("@UserID", User.Current.UserID));
            dgvTickets.DataSource = dt;
        }

        private void btnRefresh_Click(object sender, EventArgs e) => LoadTickets();

        /// <summary>
        /// Prints the selected ticket to a message box (demo print).
        /// Cyclomatic Complexity = 3
        /// </summary>
        private void btnPrint_Click(object sender, EventArgs e)
        {
            if (dgvTickets.SelectedRows.Count == 0)
            {
                MessageBox.Show("Please select a ticket.", "Notice",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            DataGridViewRow row = dgvTickets.SelectedRows[0];
            string ticket  = $"╔══════════════════════════════════╗\n" +
                             $"║   FAST Societies Management System ║\n" +
                             $"╠══════════════════════════════════╣\n" +
                             $"║  EVENT  : {row.Cells["Event"].Value,-24}║\n" +
                             $"║  SOCIETY: {row.Cells["Society"].Value,-24}║\n" +
                             $"║  DATE   : {row.Cells["EventDate"].Value,-24}║\n" +
                             $"║  VENUE  : {row.Cells["Venue"].Value,-24}║\n" +
                             $"║  TICKET : {row.Cells["TicketCode"].Value,-24}║\n" +
                             $"╚══════════════════════════════════╝";

            MessageBox.Show(ticket, "🎫 Event Ticket",
                MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }
}
