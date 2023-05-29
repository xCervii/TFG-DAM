using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControlPadelClub.Shared.Entities
{
    public class Jugador
    {
        [Key]
        [Column(Order = 1)]
        public int JugadorId { get; set; }

        [Column(Order = 2)]
        public string Nick { get; set; }

        [Column(Order = 3)]
        public decimal? Nivel { get; set; }
    }
}
