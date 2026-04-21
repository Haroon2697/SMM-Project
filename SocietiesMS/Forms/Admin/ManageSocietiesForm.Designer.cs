namespace SocietiesMS.Forms.Admin
{
    partial class ManageSocietiesForm
    {
        private System.ComponentModel.IContainer components = null;
        protected override void Dispose(bool disposing)
        { if (disposing && components != null) components.Dispose(); base.Dispose(disposing); }

        private void InitializeComponent()
        {
            this.lblTitle      = new System.Windows.Forms.Label();
            this.dgvSocieties  = new System.Windows.Forms.DataGridView();
            this.pnlForm       = new System.Windows.Forms.Panel();
            this.lblFormHdr    = new System.Windows.Forms.Label();
            this.lblName       = new System.Windows.Forms.Label();
            this.txtName       = new System.Windows.Forms.TextBox();
            this.lblDesc       = new System.Windows.Forms.Label();
            this.txtDesc       = new System.Windows.Forms.TextBox();
            this.lblHead       = new System.Windows.Forms.Label();
            this.cmbHead       = new System.Windows.Forms.ComboBox();
            this.btnSave       = new System.Windows.Forms.Button();
            this.btnNew        = new System.Windows.Forms.Button();
            this.btnApprove    = new System.Windows.Forms.Button();
            this.btnSuspend    = new System.Windows.Forms.Button();
            this.btnDelete     = new System.Windows.Forms.Button();
            this.btnRefresh    = new System.Windows.Forms.Button();

            ((System.ComponentModel.ISupportInitialize)(this.dgvSocieties)).BeginInit();
            this.pnlForm.SuspendLayout();
            this.SuspendLayout();

            this.Text          = "Manage Societies";
            this.Size          = new System.Drawing.Size(1060, 660);
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.BackColor     = System.Drawing.Color.FromArgb(15, 23, 42);
            this.Font          = new System.Drawing.Font("Segoe UI", 9.5f);

            this.lblTitle.Text      = "🏛  Manage Societies";
            this.lblTitle.Font      = new System.Drawing.Font("Segoe UI", 16f, System.Drawing.FontStyle.Bold);
            this.lblTitle.ForeColor = System.Drawing.Color.FromArgb(99, 179, 237);
            this.lblTitle.Location  = new System.Drawing.Point(20, 15); this.lblTitle.Size = new System.Drawing.Size(400, 35);

            // Left grid
            UITheme.StyleGrid(this.dgvSocieties);
            this.dgvSocieties.Location = new System.Drawing.Point(20, 65);
            this.dgvSocieties.Size     = new System.Drawing.Size(590, 540);
            this.dgvSocieties.SelectionChanged += new System.EventHandler(this.dgvSocieties_SelectionChanged);

            // Right form panel
            this.pnlForm.BackColor = System.Drawing.Color.FromArgb(30, 41, 59);
            this.pnlForm.Location  = new System.Drawing.Point(625, 65);
            this.pnlForm.Size      = new System.Drawing.Size(415, 540);

            this.lblFormHdr.Text = "Society Details";
            this.lblFormHdr.Font = new System.Drawing.Font("Segoe UI", 12f, System.Drawing.FontStyle.Bold);
            this.lblFormHdr.ForeColor = System.Drawing.Color.FromArgb(248, 113, 113);
            this.lblFormHdr.Location  = new System.Drawing.Point(15, 15); this.lblFormHdr.Size = new System.Drawing.Size(380, 28);

            MakeField(this.lblName, "Society Name", 15, 55);
            MakeTxt(this.txtName,  15, 78); // PlaceholderText not available in .NET Framework 4.8

            MakeField(this.lblDesc, "Description", 15, 118);
            this.txtDesc.Location  = new System.Drawing.Point(15, 141);
            this.txtDesc.Size      = new System.Drawing.Size(385, 80);
            this.txtDesc.Multiline = true;
            this.txtDesc.BackColor = System.Drawing.Color.FromArgb(51, 65, 85);
            this.txtDesc.ForeColor = System.Drawing.Color.White;
            this.txtDesc.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;

            MakeField(this.lblHead, "Assign Head (optional)", 15, 235);
            this.cmbHead.Location  = new System.Drawing.Point(15, 258);
            this.cmbHead.Size      = new System.Drawing.Size(385, 28);
            this.cmbHead.BackColor = System.Drawing.Color.FromArgb(51, 65, 85);
            this.cmbHead.ForeColor = System.Drawing.Color.White;
            this.cmbHead.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cmbHead.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;

            this.btnSave.Text    = "💾  Save";   this.btnSave.Location = new System.Drawing.Point(15, 310);
            this.btnSave.Size    = new System.Drawing.Size(110, 36);
            UITheme.StylePrimaryBtn(this.btnSave);
            this.btnSave.Click  += new System.EventHandler(this.btnSave_Click);

            this.btnNew.Text     = "➕  New";    this.btnNew.Location = new System.Drawing.Point(135, 310);
            this.btnNew.Size     = new System.Drawing.Size(100, 36);
            UITheme.StyleSuccessBtn(this.btnNew);
            this.btnNew.Click   += new System.EventHandler(this.btnNew_Click);

            this.btnApprove.Text  = "✅  Approve"; this.btnApprove.Location = new System.Drawing.Point(15, 368);
            this.btnApprove.Size  = new System.Drawing.Size(120, 36);
            UITheme.StyleSuccessBtn(this.btnApprove);
            this.btnApprove.Click += new System.EventHandler(this.btnApprove_Click);

            this.btnSuspend.Text  = "⏸  Suspend"; this.btnSuspend.Location = new System.Drawing.Point(148, 368);
            this.btnSuspend.Size  = new System.Drawing.Size(120, 36);
            UITheme.StyleSecondaryBtn(this.btnSuspend);
            this.btnSuspend.Click += new System.EventHandler(this.btnSuspend_Click);

            this.btnDelete.Text   = "🗑  Delete";  this.btnDelete.Location = new System.Drawing.Point(281, 368);
            this.btnDelete.Size   = new System.Drawing.Size(120, 36);
            UITheme.StyleDangerBtn(this.btnDelete);
            this.btnDelete.Click  += new System.EventHandler(this.btnDelete_Click);

            this.pnlForm.Controls.AddRange(new System.Windows.Forms.Control[] {
                this.lblFormHdr, this.lblName, this.txtName, this.lblDesc, this.txtDesc,
                this.lblHead, this.cmbHead, this.btnSave, this.btnNew,
                this.btnApprove, this.btnSuspend, this.btnDelete });

            this.btnRefresh.Text    = "⟳  Refresh"; this.btnRefresh.Location = new System.Drawing.Point(20, 620);
            this.btnRefresh.Size    = new System.Drawing.Size(120, 36);
            UITheme.StyleSecondaryBtn(this.btnRefresh);
            this.btnRefresh.Click  += new System.EventHandler(this.btnRefresh_Click);

            this.Controls.AddRange(new System.Windows.Forms.Control[] {
                this.lblTitle, this.dgvSocieties, this.pnlForm, this.btnRefresh });

            ((System.ComponentModel.ISupportInitialize)(this.dgvSocieties)).EndInit();
            this.pnlForm.ResumeLayout(false);
            this.ResumeLayout(false);
        }
        private void MakeField(System.Windows.Forms.Label lbl, string text, int x, int y) { lbl.Text = text; lbl.Location = new System.Drawing.Point(x, y); lbl.Size = new System.Drawing.Size(385, 20); lbl.ForeColor = System.Drawing.Color.FromArgb(148, 163, 184); }
        private void MakeTxt(System.Windows.Forms.TextBox txt, int x, int y) { txt.Location = new System.Drawing.Point(x, y); txt.Size = new System.Drawing.Size(385, 28); txt.BackColor = System.Drawing.Color.FromArgb(51, 65, 85); txt.ForeColor = System.Drawing.Color.White; txt.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle; }

        private System.Windows.Forms.Label        lblTitle, lblFormHdr, lblName, lblDesc, lblHead;
        private System.Windows.Forms.TextBox      txtName, txtDesc;
        private System.Windows.Forms.ComboBox     cmbHead;
        private System.Windows.Forms.DataGridView dgvSocieties;
        private System.Windows.Forms.Panel        pnlForm;
        private System.Windows.Forms.Button       btnSave, btnNew, btnApprove, btnSuspend, btnDelete, btnRefresh;
    }
}
