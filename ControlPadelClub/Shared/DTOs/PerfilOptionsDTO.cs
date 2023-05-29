using ControlPadelClub.Shared.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControlPadelClub.Shared.DTOs
{
    public class PerfilOptionsDTO
    {
        public int PerfilOptionsId { get; set; }
        public bool Publico { get; set; }
        public bool HabilidadesActivas { get; set; }

        public int JugadorId { get; set; }
    }
}
