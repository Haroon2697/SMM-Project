namespace SocietiesMS.Forms.Student
{
    partial class BrowseSocietiesForm
    {
        private System.ComponentModel.IContainer components = null;
        protected override void Dispose(bool disposing)
        { if (disposing && components != null) components.Dispose(); base.Dispose(disposing); }

        private void InitializeComponent()
        {
            this.lblTitle       = new System.Windows.Forms.Label();
            this.dgvSocieties   = new System.Windows.Forms.DataGridView();
            this.btnApply       = new System.Windows.Forms.Button();
            this.btnRefresh     = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvSocieties)).BeginInit();
            this.SuspendLayout();

            this.Text          = "Browse Societies";
            this.ShowIcon = false;
            this.Size          = new System.Drawing.Size(820, 540);
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.BackColor     = System.Drawing.Color.FromArgb(15, 23, 42);
            this.Font          = new System.Drawing.Font("Segoe UI", 9.5f);

            this.lblTitle.Text      = "🏛  Browse Societies";
            this.lblTitle.Font      = new System.Drawing.Font("Segoe UI", 16f, System.Drawing.FontStyle.Bold);
            this.lblTitle.ForeColor = System.Drawing.Color.FromArgb(99, 179, 237);
            this.lblTitle.Location  = new System.Drawing.Point(20, 15);
            this.lblTitle.Size      = new System.Drawing.Size(400, 35);

            UITheme.StyleGrid(this.dgvSocieties);
            this.dgvSocieties.Location = new System.Drawing.Point(20, 65);
            this.dgvSocieties.Size     = new System.Drawing.Size(770, 380);

            this.btnApply.Text      = "✅  Apply for Membership";
            this.btnApply.Location  = new System.Drawing.Point(20, 460);
            this.btnApply.Size      = new System.Drawing.Size(220, 38);
            StyleButton(this.btnApply, System.Drawing.Color.FromArgb(34, 197, 94));
            this.btnApply.Click    += new System.EventHandler(this.btnApply_Click);

            this.btnRefresh.Text    = "⟳  Refresh";
            this.btnRefresh.Location= new System.Drawing.Point(255, 460);
            this.btnRefresh.Size    = new System.Drawing.Size(120, 38);
            StyleButton(this.btnRefresh, System.Drawing.Color.FromArgb(51, 65, 85));
            this.btnRefresh.Click  += new System.EventHandler(this.btnRefresh_Click);

            this.Controls.AddRange(new System.Windows.Forms.Control[] {
                this.lblTitle, this.dgvSocieties, this.btnApply, this.btnRefresh });
            ((System.ComponentModel.ISupportInitialize)(this.dgvSocieties)).EndInit();
            this.ResumeLayout(false);
        }

        private void StyleButton(System.Windows.Forms.Button btn, System.Drawing.Color color)
        {
            btn.BackColor = color;
            btn.ForeColor = System.Drawing.Color.White;
            btn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            btn.FlatAppearance.BorderSize = 0;
            btn.Font      = new System.Drawing.Font("Segoe UI", 9.5f);
            btn.Cursor    = System.Windows.Forms.Cursors.Hand;
        }

        private System.Windows.Forms.Label            lblTitle;
        private System.Windows.Forms.DataGridView     dgvSocieties;
        private System.Windows.Forms.Button           btnApply;
        private System.Windows.Forms.Button           btnRefresh;
    }
}
