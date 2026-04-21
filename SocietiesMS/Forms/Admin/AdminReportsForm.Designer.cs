namespace SocietiesMS.Forms.Admin
{
    partial class AdminReportsForm
    {
        private System.ComponentModel.IContainer components = null;
        protected override void Dispose(bool disposing)
        { if (disposing && components != null) components.Dispose(); base.Dispose(disposing); }

        private void InitializeComponent()
        {
            this.lblTitle    = new System.Windows.Forms.Label();
            this.txtSummary  = new System.Windows.Forms.TextBox();
            this.lblBreakdown= new System.Windows.Forms.Label();
            this.dgvBreakdown= new System.Windows.Forms.DataGridView();
            this.btnRefresh  = new System.Windows.Forms.Button();
            this.btnCopy     = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvBreakdown)).BeginInit();
            this.SuspendLayout();

            this.Text          = "University Report";
            this.Size          = new System.Drawing.Size(920, 720);
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.BackColor     = System.Drawing.Color.FromArgb(15, 23, 42);
            this.Font          = new System.Drawing.Font("Segoe UI", 9.5f);

            this.lblTitle.Text      = "📊  University-Wide Report";
            this.lblTitle.Font      = new System.Drawing.Font("Segoe UI", 16f, System.Drawing.FontStyle.Bold);
            this.lblTitle.ForeColor = System.Drawing.Color.FromArgb(99, 179, 237);
            this.lblTitle.Location  = new System.Drawing.Point(20, 15); this.lblTitle.Size = new System.Drawing.Size(500, 35);

            // Summary textbox
            this.txtSummary.Location   = new System.Drawing.Point(20, 65);
            this.txtSummary.Size       = new System.Drawing.Size(875, 220);
            this.txtSummary.BackColor  = System.Drawing.Color.FromArgb(30, 41, 59);
            this.txtSummary.ForeColor  = System.Drawing.Color.FromArgb(226, 232, 240);
            this.txtSummary.Font       = new System.Drawing.Font("Consolas", 10f);
            this.txtSummary.Multiline  = true;
            this.txtSummary.ReadOnly   = true;
            this.txtSummary.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtSummary.BorderStyle = System.Windows.Forms.BorderStyle.None;

            // Breakdown grid label
            this.lblBreakdown.Text      = "Per-Society Breakdown";
            this.lblBreakdown.Font      = new System.Drawing.Font("Segoe UI", 11f, System.Drawing.FontStyle.Bold);
            this.lblBreakdown.ForeColor = System.Drawing.Color.FromArgb(251, 191, 36);
            this.lblBreakdown.Location  = new System.Drawing.Point(20, 300); this.lblBreakdown.Size = new System.Drawing.Size(400, 26);

            // Breakdown DGV
            UITheme.StyleGrid(this.dgvBreakdown);
            this.dgvBreakdown.Location = new System.Drawing.Point(20, 332);
            this.dgvBreakdown.Size     = new System.Drawing.Size(875, 300);

            // Buttons
            this.btnRefresh.Text    = "⟳  Refresh";
            this.btnRefresh.Location= new System.Drawing.Point(20, 648);
            this.btnRefresh.Size    = new System.Drawing.Size(130, 38);
            UITheme.StyleSecondaryBtn(this.btnRefresh);
            this.btnRefresh.Click  += new System.EventHandler(this.btnRefresh_Click);

            this.btnCopy.Text    = "📋  Copy Summary";
            this.btnCopy.Location= new System.Drawing.Point(165, 648);
            this.btnCopy.Size    = new System.Drawing.Size(160, 38);
            UITheme.StylePrimaryBtn(this.btnCopy);
            this.btnCopy.Click  += new System.EventHandler(this.btnCopy_Click);

            this.Controls.AddRange(new System.Windows.Forms.Control[] {
                this.lblTitle, this.txtSummary, this.lblBreakdown,
                this.dgvBreakdown, this.btnRefresh, this.btnCopy });
            ((System.ComponentModel.ISupportInitialize)(this.dgvBreakdown)).EndInit();
            this.ResumeLayout(false);
        }

        private System.Windows.Forms.Label        lblTitle, lblBreakdown;
        private System.Windows.Forms.TextBox      txtSummary;
        private System.Windows.Forms.DataGridView dgvBreakdown;
        private System.Windows.Forms.Button       btnRefresh, btnCopy;
    }
}
