namespace SocietiesMS.Forms.Admin
{
    partial class ManageStudentsForm
    {
        private System.ComponentModel.IContainer components = null;
        protected override void Dispose(bool disposing)
        { if (disposing && components != null) components.Dispose(); base.Dispose(disposing); }

        private void InitializeComponent()
        {
            this.lblTitle        = new System.Windows.Forms.Label();
            this.lblSearch       = new System.Windows.Forms.Label();
            this.txtSearch       = new System.Windows.Forms.TextBox();
            this.dgvStudents     = new System.Windows.Forms.DataGridView();
            this.btnToggleActive = new System.Windows.Forms.Button();
            this.btnDelete       = new System.Windows.Forms.Button();
            this.btnRefresh      = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvStudents)).BeginInit();
            this.SuspendLayout();

            this.Text          = "Manage Students";
            this.Size          = new System.Drawing.Size(860, 560);
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.BackColor     = System.Drawing.Color.FromArgb(15, 23, 42);
            this.Font          = new System.Drawing.Font("Segoe UI", 9.5f);

            this.lblTitle.Text      = "👨‍🎓  Manage Student Accounts";
            this.lblTitle.Font      = new System.Drawing.Font("Segoe UI", 16f, System.Drawing.FontStyle.Bold);
            this.lblTitle.ForeColor = System.Drawing.Color.FromArgb(99, 179, 237);
            this.lblTitle.Location  = new System.Drawing.Point(20, 15); this.lblTitle.Size = new System.Drawing.Size(500, 35);

            this.lblSearch.Text      = "🔍";
            this.lblSearch.ForeColor = System.Drawing.Color.FromArgb(148, 163, 184);
            this.lblSearch.Location  = new System.Drawing.Point(20, 63); this.lblSearch.Size = new System.Drawing.Size(22, 28);

            this.txtSearch.Location        = new System.Drawing.Point(45, 60);
            this.txtSearch.Size            = new System.Drawing.Size(300, 28);
            this.txtSearch.BackColor       = System.Drawing.Color.FromArgb(51, 65, 85);
            this.txtSearch.ForeColor       = System.Drawing.Color.White;
            this.txtSearch.BorderStyle     = System.Windows.Forms.BorderStyle.FixedSingle;
            // PlaceholderText not available in .NET Framework 4.8
            this.txtSearch.TextChanged    += new System.EventHandler(this.txtSearch_TextChanged);

            StyleDGV(this.dgvStudents);
            this.dgvStudents.Location = new System.Drawing.Point(20, 102);
            this.dgvStudents.Size     = new System.Drawing.Size(815, 360);

            this.btnToggleActive.Text    = "🔄  Toggle Active";
            this.btnToggleActive.Location= new System.Drawing.Point(20, 476);
            this.btnToggleActive.Size    = new System.Drawing.Size(170, 38);
            StyleBtn(this.btnToggleActive, System.Drawing.Color.FromArgb(59, 130, 246));
            this.btnToggleActive.Click  += new System.EventHandler(this.btnToggleActive_Click);

            this.btnDelete.Text     = "🗑  Delete Account";
            this.btnDelete.Location = new System.Drawing.Point(205, 476);
            this.btnDelete.Size     = new System.Drawing.Size(170, 38);
            StyleBtn(this.btnDelete, System.Drawing.Color.FromArgb(239, 68, 68));
            this.btnDelete.Click   += new System.EventHandler(this.btnDelete_Click);

            this.btnRefresh.Text    = "⟳  Refresh";
            this.btnRefresh.Location= new System.Drawing.Point(390, 476);
            this.btnRefresh.Size    = new System.Drawing.Size(120, 38);
            StyleBtn(this.btnRefresh, System.Drawing.Color.FromArgb(51, 65, 85));
            this.btnRefresh.Click  += new System.EventHandler(this.btnRefresh_Click);

            this.Controls.AddRange(new System.Windows.Forms.Control[] {
                this.lblTitle, this.lblSearch, this.txtSearch,
                this.dgvStudents, this.btnToggleActive, this.btnDelete, this.btnRefresh });
            ((System.ComponentModel.ISupportInitialize)(this.dgvStudents)).EndInit();
            this.ResumeLayout(false);
        }

        private void StyleDGV(System.Windows.Forms.DataGridView dgv)
        { dgv.BackgroundColor = System.Drawing.Color.FromArgb(30, 41, 59); dgv.GridColor = System.Drawing.Color.FromArgb(51, 65, 85); dgv.DefaultCellStyle.BackColor = System.Drawing.Color.FromArgb(30, 41, 59); dgv.DefaultCellStyle.ForeColor = System.Drawing.Color.FromArgb(226, 232, 240); dgv.ColumnHeadersDefaultCellStyle.BackColor = System.Drawing.Color.FromArgb(51, 65, 85); dgv.ColumnHeadersDefaultCellStyle.ForeColor = System.Drawing.Color.White; dgv.ColumnHeadersDefaultCellStyle.Font = new System.Drawing.Font("Segoe UI", 9.5f, System.Drawing.FontStyle.Bold); dgv.EnableHeadersVisualStyles = false; dgv.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect; dgv.MultiSelect = false; dgv.ReadOnly = true; dgv.AllowUserToAddRows = false; dgv.RowHeadersVisible = false; dgv.BorderStyle = System.Windows.Forms.BorderStyle.None; dgv.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill; }
        private void StyleBtn(System.Windows.Forms.Button btn, System.Drawing.Color c) { btn.BackColor = c; btn.ForeColor = System.Drawing.Color.White; btn.FlatStyle = System.Windows.Forms.FlatStyle.Flat; btn.FlatAppearance.BorderSize = 0; btn.Font = new System.Drawing.Font("Segoe UI", 9.5f); btn.Cursor = System.Windows.Forms.Cursors.Hand; }

        private System.Windows.Forms.Label        lblTitle, lblSearch;
        private System.Windows.Forms.TextBox      txtSearch;
        private System.Windows.Forms.DataGridView dgvStudents;
        private System.Windows.Forms.Button       btnToggleActive, btnDelete, btnRefresh;
    }
}
