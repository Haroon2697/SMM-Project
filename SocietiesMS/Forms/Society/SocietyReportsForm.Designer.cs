namespace SocietiesMS.Forms.Society
{
    partial class SocietyReportsForm
    {
        private System.ComponentModel.IContainer components = null;
        protected override void Dispose(bool disposing)
        { if (disposing && components != null) components.Dispose(); base.Dispose(disposing); }

        private void InitializeComponent()
        {
            this.lblTitle   = new System.Windows.Forms.Label();
            this.txtReport  = new System.Windows.Forms.TextBox();
            this.btnRefresh = new System.Windows.Forms.Button();
            this.btnCopy    = new System.Windows.Forms.Button();
            this.SuspendLayout();

            this.Text          = "Society Report";
            this.ShowIcon = false;
            this.Size          = new System.Drawing.Size(720, 620);
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.BackColor     = System.Drawing.Color.FromArgb(15, 23, 42);
            this.Font          = new System.Drawing.Font("Segoe UI", 9.5f);

            this.lblTitle.Text      = "📋  Society Report";
            this.lblTitle.Font      = new System.Drawing.Font("Segoe UI", 16f, System.Drawing.FontStyle.Bold);
            this.lblTitle.ForeColor = System.Drawing.Color.FromArgb(99, 179, 237);
            this.lblTitle.Location  = new System.Drawing.Point(20, 15);
            this.lblTitle.Size      = new System.Drawing.Size(400, 35);

            this.txtReport.Location   = new System.Drawing.Point(20, 65);
            this.txtReport.Size       = new System.Drawing.Size(670, 475);
            this.txtReport.BackColor  = System.Drawing.Color.FromArgb(30, 41, 59);
            this.txtReport.ForeColor  = System.Drawing.Color.FromArgb(226, 232, 240);
            this.txtReport.Font       = new System.Drawing.Font("Consolas", 10f);
            this.txtReport.Multiline  = true;
            this.txtReport.ReadOnly   = true;
            this.txtReport.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtReport.BorderStyle = System.Windows.Forms.BorderStyle.None;

            this.btnRefresh.Text    = "⟳  Refresh";
            this.btnRefresh.Location= new System.Drawing.Point(20, 558);
            this.btnRefresh.Size    = new System.Drawing.Size(120, 38);
            UITheme.StyleSecondaryBtn(this.btnRefresh);
            this.btnRefresh.Click  += new System.EventHandler(this.btnRefresh_Click);

            this.btnCopy.Text    = "📋  Copy Report";
            this.btnCopy.Location= new System.Drawing.Point(155, 558);
            this.btnCopy.Size    = new System.Drawing.Size(160, 38);
            UITheme.StylePrimaryBtn(this.btnCopy);
            this.btnCopy.Click  += new System.EventHandler(this.btnCopy_Click);

            this.Controls.AddRange(new System.Windows.Forms.Control[] {
                this.lblTitle, this.txtReport, this.btnRefresh, this.btnCopy });
            this.ResumeLayout(false);
        }

        private System.Windows.Forms.Label   lblTitle;
        private System.Windows.Forms.TextBox txtReport;
        private System.Windows.Forms.Button  btnRefresh, btnCopy;
    }
}
