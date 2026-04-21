namespace SocietiesMS.Forms.Student
{
    partial class EventsForm
    {
        private System.ComponentModel.IContainer components = null;
        protected override void Dispose(bool disposing)
        { if (disposing && components != null) components.Dispose(); base.Dispose(disposing); }

        private void InitializeComponent()
        {
            this.lblTitle   = new System.Windows.Forms.Label();
            this.dgvEvents  = new System.Windows.Forms.DataGridView();
            this.btnRegister= new System.Windows.Forms.Button();
            this.btnRefresh = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvEvents)).BeginInit();
            this.SuspendLayout();

            this.Text          = "Upcoming Events";
            this.Size          = new System.Drawing.Size(900, 520);
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.BackColor     = System.Drawing.Color.FromArgb(15, 23, 42);

            this.lblTitle.Text      = "📅  Upcoming Events";
            this.lblTitle.Font      = new System.Drawing.Font("Segoe UI", 16f, System.Drawing.FontStyle.Bold);
            this.lblTitle.ForeColor = System.Drawing.Color.FromArgb(99, 179, 237);
            this.lblTitle.Location  = new System.Drawing.Point(20, 15);
            this.lblTitle.Size      = new System.Drawing.Size(400, 35);

            StyleDGV(this.dgvEvents);
            this.dgvEvents.Location = new System.Drawing.Point(20, 65);
            this.dgvEvents.Size     = new System.Drawing.Size(855, 360);

            this.btnRegister.Text    = "🎟  Register for Event";
            this.btnRegister.Location= new System.Drawing.Point(20, 440);
            this.btnRegister.Size    = new System.Drawing.Size(200, 38);
            StyleBtn(this.btnRegister, System.Drawing.Color.FromArgb(59, 130, 246));
            this.btnRegister.Click  += new System.EventHandler(this.btnRegister_Click);

            this.btnRefresh.Text    = "⟳  Refresh";
            this.btnRefresh.Location= new System.Drawing.Point(235, 440);
            this.btnRefresh.Size    = new System.Drawing.Size(120, 38);
            StyleBtn(this.btnRefresh, System.Drawing.Color.FromArgb(51, 65, 85));
            this.btnRefresh.Click  += new System.EventHandler(this.btnRefresh_Click);

            this.Controls.AddRange(new System.Windows.Forms.Control[] {
                this.lblTitle, this.dgvEvents, this.btnRegister, this.btnRefresh });
            ((System.ComponentModel.ISupportInitialize)(this.dgvEvents)).EndInit();
            this.ResumeLayout(false);
        }
        private void StyleDGV(System.Windows.Forms.DataGridView dgv)
        {
            dgv.BackgroundColor = System.Drawing.Color.FromArgb(30, 41, 59);
            dgv.GridColor       = System.Drawing.Color.FromArgb(51, 65, 85);
            dgv.DefaultCellStyle.BackColor = System.Drawing.Color.FromArgb(30, 41, 59);
            dgv.DefaultCellStyle.ForeColor = System.Drawing.Color.FromArgb(226, 232, 240);
            dgv.ColumnHeadersDefaultCellStyle.BackColor = System.Drawing.Color.FromArgb(51, 65, 85);
            dgv.ColumnHeadersDefaultCellStyle.ForeColor = System.Drawing.Color.White;
            dgv.ColumnHeadersDefaultCellStyle.Font = new System.Drawing.Font("Segoe UI", 9.5f, System.Drawing.FontStyle.Bold);
            dgv.EnableHeadersVisualStyles = false;
            dgv.SelectionMode   = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            dgv.MultiSelect     = false; dgv.ReadOnly = true;
            dgv.AllowUserToAddRows = false; dgv.RowHeadersVisible = false;
            dgv.BorderStyle = System.Windows.Forms.BorderStyle.None;
            dgv.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
        }
        private void StyleBtn(System.Windows.Forms.Button btn, System.Drawing.Color c)
        {
            btn.BackColor = c; btn.ForeColor = System.Drawing.Color.White;
            btn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            btn.FlatAppearance.BorderSize = 0;
            btn.Font = new System.Drawing.Font("Segoe UI", 9.5f);
            btn.Cursor = System.Windows.Forms.Cursors.Hand;
        }
        private System.Windows.Forms.Label        lblTitle;
        private System.Windows.Forms.DataGridView dgvEvents;
        private System.Windows.Forms.Button       btnRegister;
        private System.Windows.Forms.Button       btnRefresh;
    }
}
