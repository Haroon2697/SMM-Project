using System;

namespace SocietiesMS.Models
{
    /// <summary>Represents a society membership record.</summary>
    public class SocietyMember
    {
        public int      MemberID  { get; set; }
        public int      SocietyID { get; set; }
        public int      UserID    { get; set; }
        public string   Role      { get; set; }   // Head | Member | Volunteer
        public string   Status    { get; set; }   // Pending | Approved | Rejected
        public DateTime JoinedAt  { get; set; }
    }
}
