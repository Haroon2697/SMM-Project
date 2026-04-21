using System;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace SocietiesMS.Forms.Society
{
    /// <summary>
    /// Generates summary reports for a society:
    /// member count, event count, task completion rate.
    /// </summary>
    public partial class SocietyReportsForm : Form
    {
        private readonly int _societyId;

        public SocietyReportsForm(int societyId)
        {
            InitializeComponent();
            _societyId = societyId;
            GenerateReport();
        }

        /// <summary>
        /// Generates a comprehensive text report for the society.
        /// Cyclomatic Complexity = 2
        /// </summary>
        private void GenerateReport()
        {
            // Member stats
            object totalMembers = DBHelper.ExecuteScalar(
                "SELECT COUNT(*) FROM SocietyMembers WHERE SocietyID=@SID AND Status='Approved'",
                new SqlParameter("@SID", _societyId));

            object pendingMembers = DBHelper.ExecuteScalar(
                "SELECT COUNT(*) FROM SocietyMembers WHERE SocietyID=@SID AND Status='Pending'",
                new SqlParameter("@SID", _societyId));

            // Event stats
            object totalEvents = DBHelper.ExecuteScalar(
                "SELECT COUNT(*) FROM Events WHERE SocietyID=@SID",
                new SqlParameter("@SID", _societyId));

            object approvedEvents = DBHelper.ExecuteScalar(
                "SELECT COUNT(*) FROM Events WHERE SocietyID=@SID AND ApprovalStatus='Approved'",
                new SqlParameter("@SID", _societyId));

            // Task stats
            object totalTasks     = DBHelper.ExecuteScalar("SELECT COUNT(*) FROM Tasks WHERE SocietyID=@SID", new SqlParameter("@SID", _societyId));
            object completedTasks = DBHelper.ExecuteScalar("SELECT COUNT(*) FROM Tasks WHERE SocietyID=@SID AND Status='Completed'", new SqlParameter("@SID", _societyId));

            // Member list
            DataTable memberList = DBHelper.ExecuteQuery(
                @"SELECT u.FullName, u.Email, sm.Role, FORMAT(sm.JoinedAt,'yyyy-MM-dd') AS JoinedOn
                  FROM SocietyMembers sm JOIN Users u ON sm.UserID=u.UserID
                  WHERE sm.SocietyID=@SID AND sm.Status='Approved'",
                new SqlParameter("@SID", _societyId));

            // Build report text
            var sb = new StringBuilder();
            sb.AppendLine("═══════════════════════════════════════════════");
            sb.AppendLine("         SOCIETY MANAGEMENT REPORT");
            sb.AppendLine($"         Generated: {DateTime.Now:yyyy-MM-dd HH:mm}");
            sb.AppendLine("═══════════════════════════════════════════════");
            sb.AppendLine();
            sb.AppendLine("▶  MEMBERSHIP SUMMARY");
            sb.AppendLine($"   Total Approved Members : {totalMembers}");
            sb.AppendLine($"   Pending Applications   : {pendingMembers}");
            sb.AppendLine();
            sb.AppendLine("▶  EVENT SUMMARY");
            sb.AppendLine($"   Total Events Created   : {totalEvents}");
            sb.AppendLine($"   Admin-Approved Events  : {approvedEvents}");
            sb.AppendLine();
            sb.AppendLine("▶  TASK SUMMARY");
            sb.AppendLine($"   Total Tasks Assigned   : {totalTasks}");
            sb.AppendLine($"   Completed Tasks        : {completedTasks}");

            int t = Convert.ToInt32(totalTasks);
            int c = Convert.ToInt32(completedTasks);
            double rate = t > 0 ? Math.Round((double)c / t * 100, 1) : 0;
            sb.AppendLine($"   Completion Rate        : {rate}%");
            sb.AppendLine();
            sb.AppendLine("▶  APPROVED MEMBER LIST");
            sb.AppendLine("   ─────────────────────────────────────────");
            foreach (DataRow row in memberList.Rows)
                sb.AppendLine($"   {row["FullName"],-22} {row["Role"],-12} joined {row["JoinedOn"]}");

            txtReport.Text = sb.ToString();
        }

        private void btnRefresh_Click(object sender, EventArgs e) => GenerateReport();

        /// <summary>
        /// Copies the report text to clipboard.
        /// Cyclomatic Complexity = 1
        /// </summary>
        private void btnCopy_Click(object sender, EventArgs e)
        {
            System.Windows.Forms.Clipboard.SetText(txtReport.Text);
            MessageBox.Show("Report copied to clipboard.", "Copied",
                MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }
}
