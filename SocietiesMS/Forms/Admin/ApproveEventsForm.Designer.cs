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

            StyleDGV(this.dgvEvents);
            this.dgvEvents.Location = new System.Drawing.Point(20, 88);
            this.dgvEvents.Size     = new System.Drawing.Size(875, 390);

            this.btnApprove.Text    = "✅  Approve Event";
            this.btnApprove.Location= new System.Drawing.Point(20, 494);
            this.btnApprove.Size    = new System.Drawing.Size(190, 38);
            StyleBtn(this.btnApprove, System.Drawing.Color.FromArgb(34, 197, 94));
            this.btnApprove.Click  += new System.EventHandler(this.btnApprove_Click);

            this.btnReject.Text    = "✖  Reject Event";
            this.btnReject.Location= new System.Drawing.Point(225, 494);
            this.btnReject.Size    = new System.Drawing.Size(190, 38);
            StyleBtn(this.btnReject, System.Drawing.Color.FromArgb(239, 68, 68));
            this.btnReject.Click  += new System.EventHandler(this.btnReject_Click);

            this.btnRefresh.Text    = "⟳  Refresh";
            this.btnRefresh.Location= new System.Drawing.Point(430, 494);
            this.btnRefresh.Size    = new System.Drawing.Size(120, 38);
            StyleBtn(this.btnRefresh, System.Drawing.Color.FromArgb(51, 65, 85));
            this.btnRefresh.Click  += new System.EventHandler(this.btnRefresh_Click);

            this.Controls.AddRange(new System.Windows.Forms.Control[] {
                this.lblTitle, this.lblHint, this.dgvEvents,
                this.btnApprove, this.btnReject, this.btnRefresh });
            ((System.ComponentModel.ISupportInitialize)(this.dgvEvents)).EndInit();
            this.ResumeLayout(false);
        }

        private void StyleDGV(System.Windows.Forms.DataGridView dgv)
        { dgv.BackgroundColor = System.Drawing.Color.FromArgb(30, 41, 59); dgv.GridColor = System.Drawing.Color.FromArgb(51, 65, 85); dgv.DefaultCellStyle.BackColor = System.Drawing.Color.FromArgb(30, 41, 59); dgv.DefaultCellStyle.ForeColor = System.Drawing.Color.FromArgb(226, 232, 240); dgv.ColumnHeadersDefaultCellStyle.BackColor = System.Drawing.Color.FromArgb(51, 65, 85); dgv.ColumnHeadersDefaultCellStyle.ForeColor = System.Drawing.Color.White; dgv.ColumnHeadersDefaultCellStyle.Font = new System.Drawing.Font("Segoe UI", 9.5f, System.Drawing.FontStyle.Bold); dgv.EnableHeadersVisualStyles = false; dgv.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect; dgv.MultiSelect = false; dgv.ReadOnly = true; dgv.AllowUserToAddRows = false; dgv.RowHeadersVisible = false; dgv.BorderStyle = System.Windows.Forms.BorderStyle.None; dgv.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill; }
        private void StyleBtn(System.Windows.Forms.Button btn, System.Drawing.Color c) { btn.BackColor = c; btn.ForeColor = System.Drawing.Color.White; btn.FlatStyle = System.Windows.Forms.FlatStyle.Flat; btn.FlatAppearance.BorderSize = 0; btn.Font = new System.Drawing.Font("Segoe UI", 9.5f); btn.Cursor = System.Windows.Forms.Cursors.Hand; }

        private System.Windows.Forms.Label        lblTitle, lblHint;
        private System.Windows.Forms.DataGridView dgvEvents;
        private System.Windows.Forms.Button       btnApprove, btnReject, btnRefresh;
    }
}
