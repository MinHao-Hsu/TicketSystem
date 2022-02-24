using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Ticket_System_Design.Models
{
    public class UserLogin
    {
        public static User _user = null;
        public static User user
        {
            get
            {
                if (_user == null)
                    _user = new User();
                return _user;
            }
            set
            {
                _user = value;
            }
        }
    }
}
