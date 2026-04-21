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
            this.ShowIcon = false;
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

            UITheme.StyleGrid(this.dgvStudents);
            this.dgvStudents.Location = new System.Drawing.Point(20, 102);
            this.dgvStudents.Size     = new System.Drawing.Size(815, 360);

            this.btnToggleActive.Text    = "🔄  Toggle Active";
            this.btnToggleActive.Location= new System.Drawing.Point(20, 476);
            this.btnToggleActive.Size    = new System.Drawing.Size(170, 38);
            UITheme.StylePrimaryBtn(this.btnToggleActive);
            this.btnToggleActive.Click  += new System.EventHandler(this.btnToggleActive_Click);

            this.btnDelete.Text     = "🗑  Delete Account";
            this.btnDelete.Location = new System.Drawing.Point(205, 476);
            this.btnDelete.Size     = new System.Drawing.Size(170, 38);
            UITheme.StyleDangerBtn(this.btnDelete);
            this.btnDelete.Click   += new System.EventHandler(this.btnDelete_Click);

            this.btnRefresh.Text    = "⟳  Refresh";
            this.btnRefresh.Location= new System.Drawing.Point(390, 476);
            this.btnRefresh.Size    = new System.Drawing.Size(120, 38);
            UITheme.StyleSecondaryBtn(this.btnRefresh);
            this.btnRefresh.Click  += new System.EventHandler(this.btnRefresh_Click);

            this.Controls.AddRange(new System.Windows.Forms.Control[] {
                this.lblTitle, this.lblSearch, this.txtSearch,
                this.dgvStudents, this.btnToggleActive, this.btnDelete, this.btnRefresh });
            ((System.ComponentModel.ISupportInitialize)(this.dgvStudents)).EndInit();
            this.ResumeLayout(false);
        }

        private System.Windows.Forms.Label        lblTitle, lblSearch;
        private System.Windows.Forms.TextBox      txtSearch;
        private System.Windows.Forms.DataGridView dgvStudents;
        private System.Windows.Forms.Button       btnToggleActive, btnDelete, btnRefresh;
    }
}
