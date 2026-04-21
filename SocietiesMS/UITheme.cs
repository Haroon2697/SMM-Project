using System;
using System.Drawing;
using System.Windows.Forms;

namespace SocietiesMS
{
    /// <summary>
    /// Centralized UI styling hub for the FAST Societies MS.
    /// Provides consistent colors, hover effects, and control styles.
    /// </summary>
    public static class UITheme
    {
        // Modern Color Palette
        public static readonly Color BgBase      = Color.FromArgb(15, 23, 42);   // Slate 900
        public static readonly Color BgPanel     = Color.FromArgb(30, 41, 59);   // Slate 800
        public static readonly Color MutedBorder = Color.FromArgb(51, 65, 85);   // Slate 700
        
        public static readonly Color TextMain    = Color.White;
        public static readonly Color TextMuted   = Color.FromArgb(148, 163, 184); // Slate 400

        public static readonly Color Primary     = Color.FromArgb(79, 70, 229);  // Indigo 600
        public static readonly Color PrimaryHover= Color.FromArgb(99, 102, 241); // Indigo 500
        
        public static readonly Color Success     = Color.FromArgb(16, 185, 129); // Emerald 500
        public static readonly Color SuccessHover= Color.FromArgb(52, 211, 153); // Emerald 400
        
        public static readonly Color Danger      = Color.FromArgb(225, 29, 72);  // Rose 600
        public static readonly Color DangerHover = Color.FromArgb(244, 63, 94);  // Rose 500
        
        public static readonly Color Secondary      = Color.FromArgb(71, 85, 105);   // Slate 600
        public static readonly Color SecondaryHover = Color.FromArgb(100, 116, 139); // Slate 500

        /// <summary>Applies standard styling and hover effects to a button.</summary>
        public static void StyleButton(Button btn, Color baseColor, Color hoverColor)
        {
            btn.BackColor = baseColor;
            btn.ForeColor = TextMain;
            btn.FlatStyle = FlatStyle.Flat;
            btn.FlatAppearance.BorderSize = 0;
            btn.Font = new Font("Segoe UI", 9.5f, FontStyle.Regular);
            btn.Cursor = Cursors.Hand;
            
            // Interaction effects
            btn.MouseEnter += (s, e) => btn.BackColor = hoverColor;
            btn.MouseLeave += (s, e) => btn.BackColor = baseColor;
        }

        public static void StylePrimaryBtn(Button btn)   => StyleButton(btn, Primary, PrimaryHover);
        public static void StyleSuccessBtn(Button btn)   => StyleButton(btn, Success, SuccessHover);
        public static void StyleDangerBtn(Button btn)    => StyleButton(btn, Danger, DangerHover);
        public static void StyleSecondaryBtn(Button btn) => StyleButton(btn, Secondary, SecondaryHover);
        
        /// <summary>Specific styling for Sidebar navigation buttons</summary>
        public static void StyleSidebarBtn(Button btn)
        {
            btn.BackColor = Secondary;
            btn.ForeColor = TextMain;
            btn.FlatStyle = FlatStyle.Flat;
            btn.FlatAppearance.BorderSize = 0;
            btn.Font = new Font("Segoe UI", 9.5f, FontStyle.Regular);
            btn.TextAlign = ContentAlignment.MiddleLeft;
            btn.Cursor = Cursors.Hand;
            
            btn.MouseEnter += (s, e) => btn.BackColor = SecondaryHover;
            btn.MouseLeave += (s, e) => btn.BackColor = Secondary;
        }

        /// <summary>Applies standard clean styling to a DataGridView.</summary>
        public static void StyleGrid(DataGridView dgv)
        {
            dgv.BackgroundColor = BgPanel;
            dgv.GridColor = MutedBorder;
            dgv.BorderStyle = BorderStyle.None;
            
            dgv.DefaultCellStyle.BackColor = BgPanel;
            dgv.DefaultCellStyle.ForeColor = Color.FromArgb(226, 232, 240);
            dgv.DefaultCellStyle.SelectionBackColor = Primary;
            dgv.DefaultCellStyle.SelectionForeColor = TextMain;

            dgv.ColumnHeadersDefaultCellStyle.BackColor = MutedBorder;
            dgv.ColumnHeadersDefaultCellStyle.ForeColor = TextMain;
            dgv.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 9.5f, FontStyle.Bold);
            dgv.ColumnHeadersDefaultCellStyle.SelectionBackColor = MutedBorder;
            dgv.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.Single;

            dgv.EnableHeadersVisualStyles = false;
            dgv.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgv.MultiSelect = false;
            dgv.ReadOnly = true;
            dgv.AllowUserToAddRows = false;
            dgv.AllowUserToDeleteRows = false;
            dgv.AllowUserToResizeRows = false;
            dgv.RowHeadersVisible = false;
            dgv.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgv.RowTemplate.Height = 35;
        }

        /// <summary>Applies dark styling to a TextBox.</summary>
        public static void StyleTextBox(TextBox txt)
        {
            txt.BackColor = MutedBorder; // using muted border color as field bg for contrast against panel
            txt.ForeColor = TextMain;
            txt.BorderStyle = BorderStyle.FixedSingle;
            txt.Font = new Font("Segoe UI", 10f);
        }
    }
}
