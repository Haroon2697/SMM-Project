using System;
using System.Windows.Forms;

namespace SocietiesMS
{
    /// <summary>
    /// Application entry point.
    /// Sets high-DPI awareness and launches the LoginForm.
    /// </summary>
    static class Program
    {
        [STAThread]
        static void Main()
        {
            // Enable high-DPI support for crisp rendering on modern displays
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            // Verify database connectivity on startup
            if (!DBHelper.TestConnection())
            {
                MessageBox.Show(
                    "Cannot connect to the database.\n\n" +
                    "Please ensure SQL Server LocalDB is installed and the database 'SocietiesMS' exists.\n" +
                    "Run Database\\schema.sql to create the database.",
                    "Database Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
                return;
            }

            Application.Run(new Forms.LoginForm());
        }
    }
}
