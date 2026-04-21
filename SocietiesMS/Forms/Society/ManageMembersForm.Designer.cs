namespace SocietiesMS.Forms.Society
{
    partial class ManageMembersForm
    {
        private System.ComponentModel.IContainer components = null;
        protected override void Dispose(bool disposing)
        { if (disposing && components != null) components.Dispose(); base.Dispose(disposing); }

        private void InitializeComponent()
        {
            this.lblTitle      = new System.Windows.Forms.Label();
            this.lblPending    = new System.Windows.Forms.Label();
            this.dgvPending    = new System.Windows.Forms.DataGridView();
            this.btnApprove    = new System.Windows.Forms.Button();
            this.btnReject     = new System.Windows.Forms.Button();
            this.lblMembers    = new System.Windows.Forms.Label();
            this.dgvMembers    = new System.Windows.Forms.DataGridView();
            this.btnRemove     = new System.Windows.Forms.Button();
            this.btnRefresh    = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPending)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvMembers)).BeginInit();
            this.SuspendLayout();

            this.Text          = "Manage Members";
            this.ShowIcon = false;
            this.Size          = new System.Drawing.Size(860, 680);
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.BackColor     = System.Drawing.Color.FromArgb(15, 23, 42);
            this.Font          = new System.Drawing.Font("Segoe UI", 9.5f);

            this.lblTitle.Text      = "👥  Manage Society Members";
            this.lblTitle.Font      = new System.Drawing.Font("Segoe UI", 16f, System.Drawing.FontStyle.Bold);
            this.lblTitle.ForeColor = System.Drawing.Color.FromArgb(99, 179, 237);
            this.lblTitle.Location  = new System.Drawing.Point(20, 15);
            this.lblTitle.Size      = new System.Drawing.Size(500, 35);

            // Pending section
            MakeLabel(this.lblPending, "⏳  Pending Requests", 20, 62, System.Drawing.Color.FromArgb(251, 191, 36));

            UITheme.StyleGrid(this.dgvPending);
            this.dgvPending.Location = new System.Drawing.Point(20, 90);
            this.dgvPending.Size     = new System.Drawing.Size(815, 160);

            this.btnApprove.Text    = "✅  Approve";
            this.btnApprove.Location= new System.Drawing.Point(20, 265);
            this.btnApprove.Size    = new System.Drawing.Size(140, 36);
            UITheme.StyleSuccessBtn(this.btnApprove);
            this.btnApprove.Click  += new System.EventHandler(this.btnApprove_Click);

            this.btnReject.Text     = "✖  Reject";
            this.btnReject.Location = new System.Drawing.Point(170, 265);
            this.btnReject.Size     = new System.Drawing.Size(140, 36);
            UITheme.StyleDangerBtn(this.btnReject);
            this.btnReject.Click   += new System.EventHandler(this.btnReject_Click);

            // Members section
            MakeLabel(this.lblMembers, "✅  Approved Members", 20, 318, System.Drawing.Color.FromArgb(74, 222, 128));

            UITheme.StyleGrid(this.dgvMembers);
            this.dgvMembers.Location = new System.Drawing.Point(20, 345);
            this.dgvMembers.Size     = new System.Drawing.Size(815, 210);

            this.btnRemove.Text     = "🗑  Remove Member";
            this.btnRemove.Location = new System.Drawing.Point(20, 568);
            this.btnRemove.Size     = new System.Drawing.Size(180, 36);
            UITheme.StyleDangerBtn(this.btnRemove);
            this.btnRemove.Click   += new System.EventHandler(this.btnRemove_Click);

            this.btnRefresh.Text    = "⟳  Refresh";
            this.btnRefresh.Location= new System.Drawing.Point(215, 568);
            this.btnRefresh.Size    = new System.Drawing.Size(120, 36);
            UITheme.StyleSecondaryBtn(this.btnRefresh);
            this.btnRefresh.Click  += new System.EventHandler(this.btnRefresh_Click);

            this.Controls.AddRange(new System.Windows.Forms.Control[] {
                this.lblTitle, this.lblPending, this.dgvPending,
                this.btnApprove, this.btnReject,
                this.lblMembers, this.dgvMembers,
                this.btnRemove, this.btnRefresh });

            ((System.ComponentModel.ISupportInitialize)(this.dgvPending)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvMembers)).EndInit();
            this.ResumeLayout(false);
        }
        private void MakeLabel(System.Windows.Forms.Label lbl, string text, int x, int y, System.Drawing.Color color)
        { lbl.Text = text; lbl.Location = new System.Drawing.Point(x, y); lbl.Size = new System.Drawing.Size(400, 24); lbl.ForeColor = color; lbl.Font = new System.Drawing.Font("Segoe UI", 11f, System.Drawing.FontStyle.Bold); }

        private System.Windows.Forms.Label        lblTitle, lblPending, lblMembers;
        private System.Windows.Forms.DataGridView dgvPending, dgvMembers;
        private System.Windows.Forms.Button       btnApprove, btnReject, btnRemove, btnRefresh;
    }
}
