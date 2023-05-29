using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControlPadelClub.Shared.Entities
{
    public class Role
    {
        [Key]
        public int RoleId { get; set; }
        public string RolName { get; set; }
        public ICollection<UsuarioRegistrado> Users { get; set; }

        public enum rol
        {
            Admin = 1,
            User = 2
        }
    }
}
