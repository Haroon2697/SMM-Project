namespace SocietiesMS.Forms.Admin
{
    partial class ApproveEventsForm
    {
        private System.ComponentModel.IContainer components = null;
        protected override void Dispose(bool disposing)
        { if (disposing && components != null) components.Dispose(); base.Dispose(disposing); }

        private void InitializeComponent()
        {
            this.lblTitle   = new System.Windows.Forms.Label();
            this.lblHint    = new System.Windows.Forms.Label();
            this.dgvEvents  = new System.Windows.Forms.DataGridView();
            this.btnApprove = new System.Windows.Forms.Button();
            this.btnReject  = new System.Windows.Forms.Button();
            this.btnRefresh = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvEvents)).BeginInit();
            this.SuspendLayout();

            this.Text          = "Approve Events";
            this.Size          = new System.Drawing.Size(920, 560);
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.BackColor     = System.Drawing.Color.FromArgb(15, 23, 42);
            this.Font          = new System.Drawing.Font("Segoe UI", 9.5f);

            this.lblTitle.Text      = "📅  Event Approval Queue";
            this.lblTitle.Font      = new System.Drawing.Font("Segoe UI", 16f, System.Drawing.FontStyle.Bold);
            this.lblTitle.ForeColor = System.Drawing.Color.FromArgb(99, 179, 237);
            this.lblTitle.Location  = new System.Drawing.Point(20, 15); this.lblTitle.Size = new System.Drawing.Size(500, 35);

            this.lblHint.Text      = "⚠  Yellow = Pending  |  Green = Approved  |  Red = Rejected/Cancelled";
            this.lblHint.ForeColor = System.Drawing.Color.FromArgb(148, 163, 184);
            this.lblHint.Location  = new System.Drawing.Point(20, 56); this.lblHint.Size = new System.Drawing.Size(600, 22);

            UITheme.StyleGrid(this.dgvEvents);
            this.dgvEvents.Location = new System.Drawing.Point(20, 88);
            this.dgvEvents.Size     = new System.Drawing.Size(875, 390);

            this.btnApprove.Text    = "✅  Approve Event";
            this.btnApprove.Location= new System.Drawing.Point(20, 494);
            this.btnApprove.Size    = new System.Drawing.Size(190, 38);
            UITheme.StyleSuccessBtn(this.btnApprove);
            this.btnApprove.Click  += new System.EventHandler(this.btnApprove_Click);

            this.btnReject.Text    = "✖  Reject Event";
            this.btnReject.Location= new System.Drawing.Point(225, 494);
            this.btnReject.Size    = new System.Drawing.Size(190, 38);
            UITheme.StyleDangerBtn(this.btnReject);
            this.btnReject.Click  += new System.EventHandler(this.btnReject_Click);

            this.btnRefresh.Text    = "⟳  Refresh";
            this.btnRefresh.Location= new System.Drawing.Point(430, 494);
            this.btnRefresh.Size    = new System.Drawing.Size(120, 38);
            UITheme.StyleSecondaryBtn(this.btnRefresh);
            this.btnRefresh.Click  += new System.EventHandler(this.btnRefresh_Click);

            this.Controls.AddRange(new System.Windows.Forms.Control[] {
                this.lblTitle, this.lblHint, this.dgvEvents,
                this.btnApprove, this.btnReject, this.btnRefresh });
            ((System.ComponentModel.ISupportInitialize)(this.dgvEvents)).EndInit();
            this.ResumeLayout(false);
        }

        private System.Windows.Forms.Label        lblTitle, lblHint;
        private System.Windows.Forms.DataGridView dgvEvents;
        private System.Windows.Forms.Button       btnApprove, btnReject, btnRefresh;
    }
}
