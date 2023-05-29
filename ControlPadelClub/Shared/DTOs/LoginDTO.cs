using ControlPadelClub.Shared.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControlPadelClub.Shared.DTOs
{
    public class LoginDTO
    {
        public int Id { get; set; }
        public string Username { get; set; } //Nick o Email
        public string Password { get; set; }
        public Role Role { get; set; }

    }
}
