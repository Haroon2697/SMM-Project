using System;

namespace SocietiesMS.Models
{
    /// <summary>Represents a student's registration (ticket) for an event.</summary>
    public class EventRegistration
    {
        public int      RegistrationID { get; set; }
        public int      EventID        { get; set; }
        public int      UserID         { get; set; }
        public DateTime RegisteredAt   { get; set; }
        public string   TicketCode     { get; set; }
    }
}
