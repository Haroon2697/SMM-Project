namespace SocietiesMS.Forms.Society
{
    partial class TasksForm
    {
        private System.ComponentModel.IContainer components = null;
        protected override void Dispose(bool disposing)
        { if (disposing && components != null) components.Dispose(); base.Dispose(disposing); }

        private void InitializeComponent()
        {
            this.lblTitle       = new System.Windows.Forms.Label();
            this.dgvTasks       = new System.Windows.Forms.DataGridView();
            this.pnlAssign      = new System.Windows.Forms.Panel();
            this.lblAssignHdr   = new System.Windows.Forms.Label();
            this.lblMember      = new System.Windows.Forms.Label();
            this.cmbMember      = new System.Windows.Forms.ComboBox();
            this.lblTaskTitle   = new System.Windows.Forms.Label();
            this.txtTaskTitle   = new System.Windows.Forms.TextBox();
            this.lblTaskDesc    = new System.Windows.Forms.Label();
            this.txtTaskDesc    = new System.Windows.Forms.TextBox();
            this.chkDueDate     = new System.Windows.Forms.CheckBox();
            this.dtpDueDate     = new System.Windows.Forms.DateTimePicker();
            this.btnAssign      = new System.Windows.Forms.Button();
            this.lblStatusHdr   = new System.Windows.Forms.Label();
            this.cmbStatus      = new System.Windows.Forms.ComboBox();
            this.btnUpdateStatus= new System.Windows.Forms.Button();
            this.btnRefresh     = new System.Windows.Forms.Button();

            ((System.ComponentModel.ISupportInitialize)(this.dgvTasks)).BeginInit();
            this.pnlAssign.SuspendLayout();
            this.SuspendLayout();

            this.Text          = "Task Management";
            this.Size          = new System.Drawing.Size(1060, 680);
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.BackColor     = System.Drawing.Color.FromArgb(15, 23, 42);
            this.Font          = new System.Drawing.Font("Segoe UI", 9.5f);

            this.lblTitle.Text      = "✔  Task Management";
            this.lblTitle.Font      = new System.Drawing.Font("Segoe UI", 16f, System.Drawing.FontStyle.Bold);
            this.lblTitle.ForeColor = System.Drawing.Color.FromArgb(99, 179, 237);
            this.lblTitle.Location  = new System.Drawing.Point(20, 15); this.lblTitle.Size = new System.Drawing.Size(400, 35);

            StyleDGV(this.dgvTasks);
            this.dgvTasks.Location = new System.Drawing.Point(20, 65);
            this.dgvTasks.Size     = new System.Drawing.Size(590, 510);

            // Assign panel
            this.pnlAssign.BackColor = System.Drawing.Color.FromArgb(30, 41, 59);
            this.pnlAssign.Location  = new System.Drawing.Point(625, 65);
            this.pnlAssign.Size      = new System.Drawing.Size(415, 510);

            this.lblAssignHdr.Text = "Assign New Task";
            this.lblAssignHdr.Font = new System.Drawing.Font("Segoe UI", 12f, System.Drawing.FontStyle.Bold);
            this.lblAssignHdr.ForeColor = System.Drawing.Color.FromArgb(251, 191, 36);
            this.lblAssignHdr.Location  = new System.Drawing.Point(15, 15); this.lblAssignHdr.Size = new System.Drawing.Size(380, 28);

            MakeField(this.lblMember, "Assign To", 15, 55);
            this.cmbMember.Location  = new System.Drawing.Point(15, 78);
            this.cmbMember.Size      = new System.Drawing.Size(385, 28);
            this.cmbMember.BackColor = System.Drawing.Color.FromArgb(51, 65, 85);
            this.cmbMember.ForeColor = System.Drawing.Color.White;
            this.cmbMember.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cmbMember.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;

            MakeField(this.lblTaskTitle, "Task Title", 15, 118);
            this.txtTaskTitle.Location = new System.Drawing.Point(15, 141);
            this.txtTaskTitle.Size     = new System.Drawing.Size(385, 28);
            StyleTxt(this.txtTaskTitle);

            MakeField(this.lblTaskDesc, "Description", 15, 181);
            this.txtTaskDesc.Location  = new System.Drawing.Point(15, 204);
            this.txtTaskDesc.Size      = new System.Drawing.Size(385, 70);
            this.txtTaskDesc.Multiline = true;
            StyleTxt(this.txtTaskDesc);

            this.chkDueDate.Text      = "Set Due Date";
            this.chkDueDate.ForeColor = System.Drawing.Color.FromArgb(148, 163, 184);
            this.chkDueDate.Location  = new System.Drawing.Point(15, 286);
            this.chkDueDate.Size      = new System.Drawing.Size(150, 24);

            this.dtpDueDate.Location = new System.Drawing.Point(15, 312);
            this.dtpDueDate.Size     = new System.Drawing.Size(240, 28);
            this.dtpDueDate.Format   = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpDueDate.Value    = System.DateTime.Now.AddDays(7);

            this.btnAssign.Text    = "➕  Assign Task";
            this.btnAssign.Location= new System.Drawing.Point(15, 358);
            this.btnAssign.Size    = new System.Drawing.Size(180, 38);
            StyleBtn(this.btnAssign, System.Drawing.Color.FromArgb(59, 130, 246));
            this.btnAssign.Click  += new System.EventHandler(this.btnAssign_Click);

            MakeField(this.lblStatusHdr, "Update Selected Task Status:", 15, 415);
            this.cmbStatus.Items.AddRange(new object[] { "Pending","InProgress","Completed","Cancelled" });
            this.cmbStatus.SelectedIndex = 0;
            this.cmbStatus.Location  = new System.Drawing.Point(15, 438);
            this.cmbStatus.Size      = new System.Drawing.Size(200, 28);
            this.cmbStatus.BackColor = System.Drawing.Color.FromArgb(51, 65, 85);
            this.cmbStatus.ForeColor = System.Drawing.Color.White;
            this.cmbStatus.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cmbStatus.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;

            this.btnUpdateStatus.Text    = "✔  Update";
            this.btnUpdateStatus.Location= new System.Drawing.Point(230, 438);
            this.btnUpdateStatus.Size    = new System.Drawing.Size(120, 28);
            StyleBtn(this.btnUpdateStatus, System.Drawing.Color.FromArgb(34, 197, 94));
            this.btnUpdateStatus.Click  += new System.EventHandler(this.btnUpdateStatus_Click);

            this.pnlAssign.Controls.AddRange(new System.Windows.Forms.Control[] {
                this.lblAssignHdr, this.lblMember, this.cmbMember,
                this.lblTaskTitle, this.txtTaskTitle,
                this.lblTaskDesc,  this.txtTaskDesc,
                this.chkDueDate,   this.dtpDueDate,
                this.btnAssign,    this.lblStatusHdr,
                this.cmbStatus,    this.btnUpdateStatus });

            this.btnRefresh.Text    = "⟳  Refresh";
            this.btnRefresh.Location= new System.Drawing.Point(20, 590);
            this.btnRefresh.Size    = new System.Drawing.Size(120, 36);
            StyleBtn(this.btnRefresh, System.Drawing.Color.FromArgb(51, 65, 85));
            this.btnRefresh.Click  += new System.EventHandler(this.btnRefresh_Click);

            this.Controls.AddRange(new System.Windows.Forms.Control[] {
                this.lblTitle, this.dgvTasks, this.pnlAssign, this.btnRefresh });

            ((System.ComponentModel.ISupportInitialize)(this.dgvTasks)).EndInit();
            this.pnlAssign.ResumeLayout(false);
            this.ResumeLayout(false);
        }

        private void StyleDGV(System.Windows.Forms.DataGridView dgv)
        { dgv.BackgroundColor = System.Drawing.Color.FromArgb(30, 41, 59); dgv.GridColor = System.Drawing.Color.FromArgb(51, 65, 85); dgv.DefaultCellStyle.BackColor = System.Drawing.Color.FromArgb(30, 41, 59); dgv.DefaultCellStyle.ForeColor = System.Drawing.Color.FromArgb(226, 232, 240); dgv.ColumnHeadersDefaultCellStyle.BackColor = System.Drawing.Color.FromArgb(51, 65, 85); dgv.ColumnHeadersDefaultCellStyle.ForeColor = System.Drawing.Color.White; dgv.ColumnHeadersDefaultCellStyle.Font = new System.Drawing.Font("Segoe UI", 9.5f, System.Drawing.FontStyle.Bold); dgv.EnableHeadersVisualStyles = false; dgv.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect; dgv.MultiSelect = false; dgv.ReadOnly = true; dgv.AllowUserToAddRows = false; dgv.RowHeadersVisible = false; dgv.BorderStyle = System.Windows.Forms.BorderStyle.None; dgv.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill; }
        private void StyleBtn(System.Windows.Forms.Button btn, System.Drawing.Color c) { btn.BackColor = c; btn.ForeColor = System.Drawing.Color.White; btn.FlatStyle = System.Windows.Forms.FlatStyle.Flat; btn.FlatAppearance.BorderSize = 0; btn.Font = new System.Drawing.Font("Segoe UI", 9.5f); btn.Cursor = System.Windows.Forms.Cursors.Hand; }
        private void StyleTxt(System.Windows.Forms.TextBox txt) { txt.BackColor = System.Drawing.Color.FromArgb(51, 65, 85); txt.ForeColor = System.Drawing.Color.White; txt.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle; }
        private void MakeField(System.Windows.Forms.Label lbl, string text, int x, int y) { lbl.Text = text; lbl.Location = new System.Drawing.Point(x, y); lbl.Size = new System.Drawing.Size(385, 20); lbl.ForeColor = System.Drawing.Color.FromArgb(148, 163, 184); }

        private System.Windows.Forms.Label          lblTitle, lblAssignHdr, lblMember, lblTaskTitle, lblTaskDesc, lblStatusHdr;
        private System.Windows.Forms.DataGridView   dgvTasks;
        private System.Windows.Forms.Panel          pnlAssign;
        private System.Windows.Forms.ComboBox       cmbMember, cmbStatus;
        private System.Windows.Forms.TextBox        txtTaskTitle, txtTaskDesc;
        private System.Windows.Forms.CheckBox       chkDueDate;
        private System.Windows.Forms.DateTimePicker dtpDueDate;
        private System.Windows.Forms.Button         btnAssign, btnUpdateStatus, btnRefresh;
    }
}
