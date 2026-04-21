namespace SocietiesMS.Models
{
    /// <summary>Represents a system user (Student, SocietyHead, or Admin).</summary>
    public class User
    {
        public int    UserID       { get; set; }
        public string FullName     { get; set; }
        public string Email        { get; set; }
        public string Role         { get; set; }   // Student | SocietyHead | Admin
        public bool   IsActive     { get; set; }

        // Singleton session holder — set on login, cleared on logout
        public static User Current { get; set; }
    }
}
