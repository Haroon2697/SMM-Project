using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using SocietiesMS.Models;

namespace SocietiesMS.Forms
{
    /// <summary>
    /// Login form — authenticates students, society heads, and admins.
    /// Role-based redirect to the correct dashboard after successful login.
    /// </summary>
    public partial class LoginForm : Form
    {
        public LoginForm()
        {
            InitializeComponent();
        }

        // ---------------------------------------------------------------
        // Event Handlers
        // ---------------------------------------------------------------

        /// <summary>
        /// Handles the Login button click.
        /// Validates input fields, authenticates against the database,
        /// and redirects to the appropriate dashboard based on user role.
        /// Cyclomatic Complexity = 6
        /// </summary>
        private void btnLogin_Click(object sender, EventArgs e)
        {
            string email    = txtEmail.Text.Trim();
            string password = txtPassword.Text;

            // Input validation
            if (string.IsNullOrEmpty(email) || string.IsNullOrEmpty(password))
            {
                lblStatus.ForeColor = Color.Red;
                lblStatus.Text = "Please enter both email and password.";
                return;
            }

            // Authenticate
            DataRow row = DBHelper.AuthenticateUser(email, password);
            if (row == null)
            {
                lblStatus.ForeColor = Color.Red;
                lblStatus.Text = "Invalid credentials or account is inactive.";
                return;
            }

            // Populate session user
            User.Current = new User
            {
                UserID   = (int)row["UserID"],
                FullName = row["FullName"].ToString(),
                Email    = row["Email"].ToString(),
                Role     = row["Role"].ToString(),
                IsActive = (bool)row["IsActive"]
            };

            // Role-based redirect
            Form dashboard;
            switch (User.Current.Role)
            {
                case "Admin":
                    dashboard = new Admin.AdminDashboard();
                    break;
                case "SocietyHead":
                    dashboard = new Society.SocietyDashboard();
                    break;
                default:  // Student
                    dashboard = new Student.StudentDashboard();
                    break;
            }

            this.Hide();
            dashboard.FormClosed += (s, args) => this.Close();
            dashboard.Show();
        }

        /// <summary>
        /// Navigates to the registration form.
        /// Cyclomatic Complexity = 1
        /// </summary>
        private void lnkRegister_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            var registerForm = new RegisterForm();
            registerForm.ShowDialog();
        }

        /// <summary>
        /// Allows pressing Enter in the password field to trigger login.
        /// Cyclomatic Complexity = 2
        /// </summary>
        private void txtPassword_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
                btnLogin_Click(sender, EventArgs.Empty);
        }
    }
}
