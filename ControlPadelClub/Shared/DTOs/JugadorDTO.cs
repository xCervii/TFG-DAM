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
    public class JugadorDTO
    {
        public int JugadorId { get; set; }
        public string Nick { get; set; }
        public decimal? Nivel { get; set;}
    }
}
