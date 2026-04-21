namespace SocietiesMS.Forms.Society
{
    partial class ManageEventsForm
    {
        private System.ComponentModel.IContainer components = null;
        protected override void Dispose(bool disposing)
        { if (disposing && components != null) components.Dispose(); base.Dispose(disposing); }

        private void InitializeComponent()
        {
            this.lblTitle       = new System.Windows.Forms.Label();
            this.dgvEvents      = new System.Windows.Forms.DataGridView();
            this.pnlForm        = new System.Windows.Forms.Panel();
            this.lblFormHeader  = new System.Windows.Forms.Label();
            this.lblTitleF      = new System.Windows.Forms.Label();
            this.txtTitle       = new System.Windows.Forms.TextBox();
            this.lblVenue       = new System.Windows.Forms.Label();
            this.txtVenue       = new System.Windows.Forms.TextBox();
            this.lblDesc        = new System.Windows.Forms.Label();
            this.txtDescription = new System.Windows.Forms.TextBox();
            this.lblDate        = new System.Windows.Forms.Label();
            this.dtpEventDate   = new System.Windows.Forms.DateTimePicker();
            this.lblCap         = new System.Windows.Forms.Label();
            this.numCapacity    = new System.Windows.Forms.NumericUpDown();
            this.btnSave        = new System.Windows.Forms.Button();
            this.btnNew         = new System.Windows.Forms.Button();
            this.btnCancel      = new System.Windows.Forms.Button();
            this.btnRefresh     = new System.Windows.Forms.Button();

            ((System.ComponentModel.ISupportInitialize)(this.dgvEvents)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numCapacity)).BeginInit();
            this.pnlForm.SuspendLayout();
            this.SuspendLayout();

            this.Text          = "Manage Events";
            this.Size          = new System.Drawing.Size(1060, 680);
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.BackColor     = System.Drawing.Color.FromArgb(15, 23, 42);
            this.Font          = new System.Drawing.Font("Segoe UI", 9.5f);

            this.lblTitle.Text      = "📅  Manage Society Events";
            this.lblTitle.Font      = new System.Drawing.Font("Segoe UI", 16f, System.Drawing.FontStyle.Bold);
            this.lblTitle.ForeColor = System.Drawing.Color.FromArgb(99, 179, 237);
            this.lblTitle.Location  = new System.Drawing.Point(20, 15); this.lblTitle.Size = new System.Drawing.Size(400, 35);

            // Events grid (left side)
            UITheme.StyleGrid(this.dgvEvents);
            this.dgvEvents.Location  = new System.Drawing.Point(20, 65);
            this.dgvEvents.Size      = new System.Drawing.Size(590, 540);
            this.dgvEvents.SelectionChanged += new System.EventHandler(this.dgvEvents_SelectionChanged);

            // Form panel (right side)
            this.pnlForm.BackColor = System.Drawing.Color.FromArgb(30, 41, 59);
            this.pnlForm.Location  = new System.Drawing.Point(625, 65);
            this.pnlForm.Size      = new System.Drawing.Size(415, 540);

            this.lblFormHeader.Text      = "Event Details";
            this.lblFormHeader.Font      = new System.Drawing.Font("Segoe UI", 12f, System.Drawing.FontStyle.Bold);
            this.lblFormHeader.ForeColor = System.Drawing.Color.FromArgb(251, 191, 36);
            this.lblFormHeader.Location  = new System.Drawing.Point(15, 15); this.lblFormHeader.Size = new System.Drawing.Size(380, 28);

            MakeField(this.lblTitleF, "Title", 15, 55);
            MakeTxt(this.txtTitle, 15, 78, false);

            MakeField(this.lblVenue, "Venue", 15, 118);
            MakeTxt(this.txtVenue, 15, 141, false);

            MakeField(this.lblDesc, "Description", 15, 181);
            this.txtDescription.Location  = new System.Drawing.Point(15, 204);
            this.txtDescription.Size      = new System.Drawing.Size(385, 80);
            this.txtDescription.BackColor = System.Drawing.Color.FromArgb(51, 65, 85);
            this.txtDescription.ForeColor = System.Drawing.Color.White;
            this.txtDescription.Multiline = true;
            this.txtDescription.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;

            MakeField(this.lblDate, "Event Date & Time", 15, 296);
            this.dtpEventDate.Location  = new System.Drawing.Point(15, 318);
            this.dtpEventDate.Size      = new System.Drawing.Size(385, 30);
            this.dtpEventDate.Format    = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpEventDate.CustomFormat = "yyyy-MM-dd  HH:mm";
            this.dtpEventDate.ShowUpDown = false;
            this.dtpEventDate.CalendarForeColor = System.Drawing.Color.White;
            this.dtpEventDate.Value     = System.DateTime.Now.AddDays(7);

            MakeField(this.lblCap, "Max Capacity", 15, 360);
            this.numCapacity.Location  = new System.Drawing.Point(15, 382);
            this.numCapacity.Size      = new System.Drawing.Size(150, 30);
            this.numCapacity.Minimum   = 1; this.numCapacity.Maximum = 5000; this.numCapacity.Value = 100;
            this.numCapacity.BackColor = System.Drawing.Color.FromArgb(51, 65, 85);
            this.numCapacity.ForeColor = System.Drawing.Color.White;

            this.btnSave.Text    = "💾  Save"; this.btnSave.Location = new System.Drawing.Point(15, 430);
            this.btnSave.Size    = new System.Drawing.Size(120, 36);
            UITheme.StylePrimaryBtn(this.btnSave);
            this.btnSave.Click  += new System.EventHandler(this.btnSave_Click);

            this.btnNew.Text     = "➕  New";  this.btnNew.Location = new System.Drawing.Point(145, 430);
            this.btnNew.Size     = new System.Drawing.Size(100, 36);
            UITheme.StyleSuccessBtn(this.btnNew);
            this.btnNew.Click   += new System.EventHandler(this.btnNew_Click);

            this.btnCancel.Text  = "✖  Cancel Event"; this.btnCancel.Location = new System.Drawing.Point(255, 430);
            this.btnCancel.Size  = new System.Drawing.Size(145, 36);
            UITheme.StyleDangerBtn(this.btnCancel);
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);

            this.pnlForm.Controls.AddRange(new System.Windows.Forms.Control[] {
                this.lblFormHeader, this.lblTitleF, this.txtTitle,
                this.lblVenue, this.txtVenue, this.lblDesc, this.txtDescription,
                this.lblDate, this.dtpEventDate, this.lblCap, this.numCapacity,
                this.btnSave, this.btnNew, this.btnCancel });

            this.btnRefresh.Text    = "⟳  Refresh"; this.btnRefresh.Location = new System.Drawing.Point(20, 624);
            this.btnRefresh.Size    = new System.Drawing.Size(120, 36);
            UITheme.StyleSecondaryBtn(this.btnRefresh);
            this.btnRefresh.Click  += new System.EventHandler(this.btnRefresh_Click);

            this.Controls.AddRange(new System.Windows.Forms.Control[] {
                this.lblTitle, this.dgvEvents, this.pnlForm, this.btnRefresh });

            ((System.ComponentModel.ISupportInitialize)(this.dgvEvents)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numCapacity)).EndInit();
            this.pnlForm.ResumeLayout(false);
            this.ResumeLayout(false);
        }
        private void MakeField(System.Windows.Forms.Label lbl, string text, int x, int y) { lbl.Text = text; lbl.Location = new System.Drawing.Point(x, y); lbl.Size = new System.Drawing.Size(385, 20); lbl.ForeColor = System.Drawing.Color.FromArgb(148, 163, 184); }
        private void MakeTxt(System.Windows.Forms.TextBox txt, int x, int y, bool pw) { txt.Location = new System.Drawing.Point(x, y); txt.Size = new System.Drawing.Size(385, 30); txt.BackColor = System.Drawing.Color.FromArgb(51, 65, 85); txt.ForeColor = System.Drawing.Color.White; txt.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle; txt.UseSystemPasswordChar = pw; }

        private System.Windows.Forms.Label              lblTitle, lblFormHeader, lblTitleF, lblVenue, lblDesc, lblDate, lblCap;
        private System.Windows.Forms.DataGridView       dgvEvents;
        private System.Windows.Forms.Panel              pnlForm;
        private System.Windows.Forms.TextBox            txtTitle, txtVenue, txtDescription;
        private System.Windows.Forms.DateTimePicker     dtpEventDate;
        private System.Windows.Forms.NumericUpDown      numCapacity;
        private System.Windows.Forms.Button             btnSave, btnNew, btnCancel, btnRefresh;
    }
}
