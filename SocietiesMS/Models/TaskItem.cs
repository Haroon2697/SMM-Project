using System;

namespace SocietiesMS.Models
{
    /// <summary>Represents a task assigned to a society member.</summary>
    public class TaskItem
    {
        public int      TaskID      { get; set; }
        public int      SocietyID   { get; set; }
        public int      AssignedTo  { get; set; }
        public int      AssignedBy  { get; set; }
        public string   Title       { get; set; }
        public string   Description { get; set; }
        public DateTime? DueDate    { get; set; }
        public string   Status      { get; set; }  // Pending | InProgress | Completed | Cancelled
        public DateTime CreatedAt   { get; set; }
    }
}
