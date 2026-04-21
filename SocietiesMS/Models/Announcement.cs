using System;

namespace SocietiesMS.Models
{
    /// <summary>Represents a society announcement.</summary>
    public class Announcement
    {
        public int      AnnouncementID { get; set; }
        public int?     SocietyID      { get; set; }  // null = global admin announcement
        public int      PostedBy       { get; set; }
        public string   Title          { get; set; }
        public string   Body           { get; set; }
        public DateTime PostedAt       { get; set; }
    }
}
