using System;

namespace SocietiesMS.Models
{
    /// <summary>Represents a society event.</summary>
    public class Event
    {
        public int      EventID        { get; set; }
        public int      SocietyID      { get; set; }
        public string   Title          { get; set; }
        public string   Description    { get; set; }
        public DateTime EventDate      { get; set; }
        public string   Venue          { get; set; }
        public int      MaxCapacity    { get; set; }
        public string   ApprovalStatus { get; set; }  // Pending | Approved | Rejected | Cancelled
        public DateTime CreatedAt      { get; set; }
    }
}
