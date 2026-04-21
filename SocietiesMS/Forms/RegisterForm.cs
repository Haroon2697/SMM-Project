using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;

namespace SocietiesMS.Forms
{
    /// <summary>
    /// Registration form — allows new students to create an account.
    /// </summary>
    public partial class RegisterForm : Form
    {
        public RegisterForm()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Handles the Register button click.
        /// Validates all fields, checks for duplicate email, then creates a new Student account.
        /// Cyclomatic Complexity = 7
        /// </summary>
        private void btnRegister_Click(object sender, EventArgs e)
        {
            string name     = txtName.Text.Trim();
            string email    = txtEmail.Text.Trim();
            string password = txtPassword.Text;
            string confirm  = txtConfirmPassword.Text;

            // Field validation
            if (string.IsNullOrEmpty(name) || string.IsNullOrEmpty(email) ||
                string.IsNullOrEmpty(password) || string.IsNullOrEmpty(confirm))
            {
                ShowError("All fields are required.");
                return;
            }

            if (!email.Contains("@") || !email.Contains("."))
            {
                ShowError("Please enter a valid email address.");
                return;
            }

            if (password.Length < 6)
            {
                ShowError("Password must be at least 6 characters.");
                return;
            }

            if (password != confirm)
            {
                ShowError("Passwords do not match.");
                return;
            }

            // Check for duplicate email
            object existing = DBHelper.ExecuteScalar(
                "SELECT COUNT(1) FROM Users WHERE Email = @Email",
                new System.Data.SqlClient.SqlParameter("@Email", email));

            if (existing != null && Convert.ToInt32(existing) > 0)
            {
                ShowError("An account with this email already exists.");
                return;
            }

            // Insert new user
            string hash = DBHelper.HashPassword(password);
            int rows = DBHelper.ExecuteNonQuery(
                "INSERT INTO Users (FullName, Email, PasswordHash, Role) VALUES (@Name, @Email, @Hash, 'Student')",
                new System.Data.SqlClient.SqlParameter("@Name",  name),
                new System.Data.SqlClient.SqlParameter("@Email", email),
                new System.Data.SqlClient.SqlParameter("@Hash",  hash));

            if (rows > 0)
            {
                MessageBox.Show("Account created successfully! You can now log in.",
                    "Registration Successful",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Close();
            }
            else
            {
                ShowError("Registration failed. Please try again.");
            }
        }

        /// <summary>
        /// Displays an error message in the status label.
        /// Cyclomatic Complexity = 1
        /// </summary>
        private void ShowError(string message)
        {
            lblStatus.ForeColor = Color.FromArgb(248, 113, 113);
            lblStatus.Text = message;
        }
    }
}
