using System;

namespace SocietiesMS.Models
{
    /// <summary>Represents a student society.</summary>
    public class Society
    {
        public int    SocietyID   { get; set; }
        public string Name        { get; set; }
        public string Description { get; set; }
        public int?   HeadUserID  { get; set; }
        public string Status      { get; set; }   // Pending | Active | Suspended | Deleted
        public DateTime CreatedAt { get; set; }
    }
}
