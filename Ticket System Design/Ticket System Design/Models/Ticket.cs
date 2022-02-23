using System;
using System.Collections.Generic;

#nullable disable

namespace Ticket_System_Design.Models
{
    public partial class Ticket
    {
        public int TicketId { get; set; }
        public string TicketStatus { get; set; }
        public string TicketSummary { get; set; }
        public string TicketDescription { get; set; }
        public string AlertLevel { get; set; }
        public string Priority { get; set; }
    }
}
