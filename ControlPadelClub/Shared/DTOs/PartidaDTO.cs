using ControlPadelClub.Shared.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControlPadelClub.Shared.DTOs
{
    public class PartidaDTO
    {
        public int PartidaId { get; set; }
        public string Marcador { get; set; } 
    }
}
