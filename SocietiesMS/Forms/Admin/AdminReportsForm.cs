using System;
using System.Data;
using System.Text;
using System.Windows.Forms;

namespace SocietiesMS.Forms.Admin
{
    /// <summary>
    /// Admin university-wide report — aggregates data across all societies,
    /// events, memberships, and tasks into a readable summary.
    /// </summary>
    public partial class AdminReportsForm : Form
    {
        public AdminReportsForm()
        {
            InitializeComponent();
            GenerateReport();
        }

        /// <summary>
        /// Builds a comprehensive university-wide report as formatted text.
        /// Also populates the society breakdown DataGridView.
        /// Cyclomatic Complexity = 2
        /// </summary>
        private void GenerateReport()
        {
            // Totals
            object totalStudents   = DBHelper.ExecuteScalar("SELECT COUNT(*) FROM Users WHERE Role='Student' AND IsActive=1");
            object totalSocieties  = DBHelper.ExecuteScalar("SELECT COUNT(*) FROM Societies WHERE Status='Active'");
            object totalEvents     = DBHelper.ExecuteScalar("SELECT COUNT(*) FROM Events WHERE ApprovalStatus='Approved'");
            object totalMembers    = DBHelper.ExecuteScalar("SELECT COUNT(*) FROM SocietyMembers WHERE Status='Approved'");
            object totalTasks      = DBHelper.ExecuteScalar("SELECT COUNT(*) FROM Tasks");
            object completedTasks  = DBHelper.ExecuteScalar("SELECT COUNT(*) FROM Tasks WHERE Status='Completed'");
            object totalTickets    = DBHelper.ExecuteScalar("SELECT COUNT(*) FROM EventRegistrations");

            // Per-society breakdown
            DataTable breakdown = DBHelper.ExecuteQuery(
                @"SELECT s.Name AS Society, s.Status,
                         ISNULL(u.FullName,'—') AS Head,
                         COUNT(DISTINCT sm.MemberID) AS Members,
                         COUNT(DISTINCT e.EventID)   AS Events
                  FROM Societies s
                  LEFT JOIN Users u ON s.HeadUserID = u.UserID
                  LEFT JOIN SocietyMembers sm ON s.SocietyID = sm.SocietyID AND sm.Status='Approved'
                  LEFT JOIN Events e ON s.SocietyID = e.SocietyID AND e.ApprovalStatus='Approved'
                  WHERE s.Status != 'Deleted'
                  GROUP BY s.Name, s.Status, u.FullName
                  ORDER BY Members DESC");

            dgvBreakdown.DataSource = breakdown;

            // Summary text
            int t = Convert.ToInt32(totalTasks);
            int c = Convert.ToInt32(completedTasks);
            double rate = t > 0 ? Math.Round((double)c / t * 100, 1) : 0;

            var sb = new StringBuilder();
            sb.AppendLine("═══════════════════════════════════════════════════");
            sb.AppendLine("       FAST UNIVERSITY — SOCIETIES REPORT");
            sb.AppendLine($"       Generated: {DateTime.Now:yyyy-MM-dd  HH:mm:ss}");
            sb.AppendLine("═══════════════════════════════════════════════════");
            sb.AppendLine();
            sb.AppendLine($"  👨‍🎓  Active Students          : {totalStudents}");
            sb.AppendLine($"  🏛   Active Societies          : {totalSocieties}");
            sb.AppendLine($"  📅   Approved Events           : {totalEvents}");
            sb.AppendLine($"  👥   Total Memberships         : {totalMembers}");
            sb.AppendLine($"  🎫   Event Registrations       : {totalTickets}");
            sb.AppendLine($"  ✔    Tasks Assigned            : {totalTasks}");
            sb.AppendLine($"  ✅   Tasks Completed           : {completedTasks}");
            sb.AppendLine($"  📊   Overall Task Completion   : {rate}%");
            sb.AppendLine();
            sb.AppendLine("  See the table below for per-society breakdown.");

            txtSummary.Text = sb.ToString();
        }

        private void btnRefresh_Click(object sender, EventArgs e) => GenerateReport();

        /// <summary>
        /// Copies the summary text to clipboard.
        /// Cyclomatic Complexity = 1
        /// </summary>
        private void btnCopy_Click(object sender, EventArgs e)
        {
            System.Windows.Forms.Clipboard.SetText(txtSummary.Text);
            MessageBox.Show("Summary copied to clipboard.", "Copied",
                MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }
}
