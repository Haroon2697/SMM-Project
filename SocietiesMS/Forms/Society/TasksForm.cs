using System;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Windows.Forms;
using SocietiesMS.Models;

namespace SocietiesMS.Forms.Society
{
    /// <summary>
    /// Allows Society Head to assign tasks to approved members,
    /// view all tasks, and update their status.
    /// </summary>
    public partial class TasksForm : Form
    {
        private readonly int _societyId;

        public TasksForm(int societyId)
        {
            InitializeComponent();
            _societyId = societyId;
            LoadMembers();
            LoadTasks();
        }

        /// <summary>
        /// Loads approved members into the assignee dropdown.
        /// Cyclomatic Complexity = 1
        /// </summary>
        private void LoadMembers()
        {
            string sql = @"SELECT u.UserID, u.FullName
                           FROM SocietyMembers sm
                           JOIN Users u ON sm.UserID = u.UserID
                           WHERE sm.SocietyID=@SID AND sm.Status='Approved'";
            var dt = DBHelper.ExecuteQuery(sql, new SqlParameter("@SID", _societyId));
            cmbMember.DisplayMember = "FullName";
            cmbMember.ValueMember   = "UserID";
            cmbMember.DataSource    = dt;
        }

        /// <summary>
        /// Loads all tasks for this society.
        /// Cyclomatic Complexity = 1
        /// </summary>
        private void LoadTasks()
        {
            string sql = @"SELECT t.TaskID, t.Title, u.FullName AS AssignedTo,
                                  FORMAT(t.DueDate,'yyyy-MM-dd') AS DueDate, t.Status,
                                  FORMAT(t.CreatedAt,'yyyy-MM-dd') AS CreatedOn
                           FROM Tasks t
                           JOIN Users u ON t.AssignedTo = u.UserID
                           WHERE t.SocietyID = @SID
                           ORDER BY t.CreatedAt DESC";
            dgvTasks.DataSource = DBHelper.ExecuteQuery(sql,
                new SqlParameter("@SID", _societyId));
            if (dgvTasks.Columns.Contains("TaskID"))
                dgvTasks.Columns["TaskID"].Visible = false;
        }

        /// <summary>
        /// Assigns a new task to the selected member.
        /// Cyclomatic Complexity = 4
        /// </summary>
        private void btnAssign_Click(object sender, EventArgs e)
        {
            string title = txtTaskTitle.Text.Trim();
            if (string.IsNullOrEmpty(title))
            {
                MessageBox.Show("Task title is required.", "Validation",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (cmbMember.SelectedValue == null)
            {
                MessageBox.Show("Please select a member to assign this task.",
                    "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            int assignedTo = Convert.ToInt32(cmbMember.SelectedValue);
            object dueDate = chkDueDate.Checked ? (object)dtpDueDate.Value.Date : DBNull.Value;

            DBHelper.ExecuteNonQuery(
                @"INSERT INTO Tasks (SocietyID, AssignedTo, AssignedBy, Title, Description, DueDate, Status)
                  VALUES (@SID, @To, @By, @Title, @Desc, @Due, 'Pending')",
                new SqlParameter("@SID",   _societyId),
                new SqlParameter("@To",    assignedTo),
                new SqlParameter("@By",    User.Current.UserID),
                new SqlParameter("@Title", title),
                new SqlParameter("@Desc",  txtTaskDesc.Text.Trim()),
                new SqlParameter("@Due",   dueDate));

            txtTaskTitle.Text = "";
            txtTaskDesc.Text  = "";
            MessageBox.Show("Task assigned successfully.", "Done",
                MessageBoxButtons.OK, MessageBoxIcon.Information);
            LoadTasks();
        }

        /// <summary>
        /// Updates the status of the selected task.
        /// Cyclomatic Complexity = 3
        /// </summary>
        private void btnUpdateStatus_Click(object sender, EventArgs e)
        {
            if (dgvTasks.SelectedRows.Count == 0)
            {
                MessageBox.Show("Select a task first.", "Notice",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            int taskId = Convert.ToInt32(dgvTasks.SelectedRows[0].Cells["TaskID"].Value);
            string newStatus = cmbStatus.SelectedItem.ToString();

            DBHelper.ExecuteNonQuery(
                "UPDATE Tasks SET Status=@Status WHERE TaskID=@TID",
                new SqlParameter("@Status", newStatus),
                new SqlParameter("@TID",    taskId));

            LoadTasks();
        }

        private void btnRefresh_Click(object sender, EventArgs e) => LoadTasks();
    }
}
