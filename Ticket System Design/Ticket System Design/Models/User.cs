using System;
using System.Collections.Generic;

#nullable disable

namespace Ticket_System_Design.Models
{
    public partial class User
    {
        public int UserId { get; set; }
        public string UserName { get; set; }
        public string UserType { get; set; }
    }
}
