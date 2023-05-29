using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControlPadelClub.Shared.Entities
{
    public class Pista
    {
        [Key]
        public int PistaId { get; set; }
        public int Numero { get; set; }
       
        public List<Reserva> Reservas { get; set; }
    }
}
