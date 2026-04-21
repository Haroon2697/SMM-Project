using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Security.Cryptography;
using System.Text;

namespace SocietiesMS
{
    /// <summary>
    /// Static database helper — single point of contact for all SQL Server operations.
    /// Wraps SqlConnection, exposes Execute / Query helpers, and utility methods.
    /// </summary>
    public static class DBHelper
    {
        // ----------------------------------------------------------------
        // Connection string (loaded from App.config)
        // ----------------------------------------------------------------
        private static readonly string _connectionString =
            ConfigurationManager.ConnectionStrings["SocietiesDB"].ConnectionString;

        /// <summary>
        /// Returns a new, open SqlConnection.
        /// Caller is responsible for Dispose (use in using block).
        /// </summary>
        public static SqlConnection GetConnection()
        {
            // Cyclomatic Complexity = 1
            var conn = new SqlConnection(_connectionString);
            conn.Open();
            return conn;
        }

        /// <summary>
        /// Tests connectivity to the database.
        /// Returns true if connection succeeds, false otherwise.
        /// </summary>
        public static bool TestConnection()
        {
            // Cyclomatic Complexity = 2 (try/catch = 2 paths)
            try
            {
                using (var conn = GetConnection())
                {
                    return conn.State == ConnectionState.Open;
                }
            }
            catch
            {
                return false;
            }
        }

        /// <summary>
        /// Executes a non-query SQL command (INSERT / UPDATE / DELETE).
        /// Returns the number of rows affected.
        /// </summary>
        public static int ExecuteNonQuery(string sql, params SqlParameter[] parameters)
        {
            // Cyclomatic Complexity = 1
            using (var conn = GetConnection())
            using (var cmd = new SqlCommand(sql, conn))
            {
                cmd.Parameters.AddRange(parameters);
                return cmd.ExecuteNonQuery();
            }
        }

        /// <summary>
        /// Executes a SELECT query and returns a DataTable.
        /// </summary>
        public static DataTable ExecuteQuery(string sql, params SqlParameter[] parameters)
        {
            // Cyclomatic Complexity = 1
            using (var conn = GetConnection())
            using (var cmd = new SqlCommand(sql, conn))
            {
                cmd.Parameters.AddRange(parameters);
                var adapter = new SqlDataAdapter(cmd);
                var table = new DataTable();
                adapter.Fill(table);
                return table;
            }
        }

        /// <summary>
        /// Executes a query and returns the first column of the first row (scalar).
        /// Returns null if no rows are returned.
        /// </summary>
        public static object ExecuteScalar(string sql, params SqlParameter[] parameters)
        {
            // Cyclomatic Complexity = 2
            using (var conn = GetConnection())
            using (var cmd = new SqlCommand(sql, conn))
            {
                cmd.Parameters.AddRange(parameters);
                var result = cmd.ExecuteScalar();
                return (result == DBNull.Value) ? null : result;
            }
        }

        // ----------------------------------------------------------------
        // Password hashing  (SHA-256 hex)
        // ----------------------------------------------------------------

        /// <summary>
        /// Computes SHA-256 hash of the given plain-text password.
        /// Returns lowercase hex string.
        /// </summary>
        public static string HashPassword(string password)
        {
            // Cyclomatic Complexity = 1
            using (var sha = SHA256.Create())
            {
                byte[] bytes = sha.ComputeHash(Encoding.UTF8.GetBytes(password));
                var sb = new StringBuilder();
                foreach (byte b in bytes)
                    sb.Append(b.ToString("x2"));
                return sb.ToString();
            }
        }

        // ----------------------------------------------------------------
        // Ticket code generator
        // ----------------------------------------------------------------

        /// <summary>
        /// Generates a unique alphanumeric ticket code (8 characters).
        /// </summary>
        public static string GenerateTicketCode()
        {
            // Cyclomatic Complexity = 1
            return Guid.NewGuid().ToString("N").Substring(0, 8).ToUpper();
        }

        // ----------------------------------------------------------------
        // Auth helper
        // ----------------------------------------------------------------

        /// <summary>
        /// Authenticates a user by email and SHA-256 hashed password.
        /// Returns the matching DataRow or null if credentials are invalid.
        /// </summary>
        public static DataRow AuthenticateUser(string email, string password)
        {
            // Cyclomatic Complexity = 3
            string hash = HashPassword(password);
            string sql = @"SELECT UserID, FullName, Email, Role, IsActive
                           FROM Users
                           WHERE Email = @Email AND PasswordHash = @Hash";

            DataTable dt = ExecuteQuery(sql,
                new SqlParameter("@Email", email),
                new SqlParameter("@Hash", hash));

            if (dt.Rows.Count == 0)
                return null;

            DataRow row = dt.Rows[0];
            if (!(bool)row["IsActive"])
                return null;

            return row;
        }
    }
}
