namespace SocietiesMS.Forms.Student
{
    partial class MyMembershipsForm
    {
        private System.ComponentModel.IContainer components = null;
        protected override void Dispose(bool disposing)
        { if (disposing && components != null) components.Dispose(); base.Dispose(disposing); }

        private void InitializeComponent()
        {
            this.lblTitle       = new System.Windows.Forms.Label();
            this.dgvMemberships = new System.Windows.Forms.DataGridView();
            this.btnRefresh     = new System.Windows.Forms.Button();
            this.btnCancel      = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvMemberships)).BeginInit();
            this.SuspendLayout();

            this.Text          = "My Memberships";
            this.Size          = new System.Drawing.Size(700, 480);
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.BackColor     = System.Drawing.Color.FromArgb(15, 23, 42);

            this.lblTitle.Text      = "📋  My Society Memberships";
            this.lblTitle.Font      = new System.Drawing.Font("Segoe UI", 16f, System.Drawing.FontStyle.Bold);
            this.lblTitle.ForeColor = System.Drawing.Color.FromArgb(99, 179, 237);
            this.lblTitle.Location  = new System.Drawing.Point(20, 15);
            this.lblTitle.Size      = new System.Drawing.Size(400, 35);

            UITheme.StyleGrid(this.dgvMemberships);
            this.dgvMemberships.Location = new System.Drawing.Point(20, 65);
            this.dgvMemberships.Size     = new System.Drawing.Size(650, 320);

            this.btnRefresh.Text    = "⟳  Refresh";
            this.btnRefresh.Location= new System.Drawing.Point(20, 400);
            this.btnRefresh.Size    = new System.Drawing.Size(120, 38);
            UITheme.StyleSecondaryBtn(this.btnRefresh);
            this.btnRefresh.Click  += new System.EventHandler(this.btnRefresh_Click);

            this.btnCancel.Text     = "✖  Cancel Application";
            this.btnCancel.Location = new System.Drawing.Point(155, 400);
            this.btnCancel.Size     = new System.Drawing.Size(190, 38);
            UITheme.StyleDangerBtn(this.btnCancel);
            this.btnCancel.Click   += new System.EventHandler(this.btnCancel_Click);

            this.Controls.AddRange(new System.Windows.Forms.Control[] {
                this.lblTitle, this.dgvMemberships, this.btnRefresh, this.btnCancel });
            ((System.ComponentModel.ISupportInitialize)(this.dgvMemberships)).EndInit();
            this.ResumeLayout(false);
        }

        private System.Windows.Forms.Label        lblTitle;
        private System.Windows.Forms.DataGridView dgvMemberships;
        private System.Windows.Forms.Button       btnRefresh;
        private System.Windows.Forms.Button       btnCancel;
    }
}
