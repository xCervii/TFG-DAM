using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControlPadelClub.Shared.Entities
{
    public class Partida
    {
        [Key]
        public int PartidaId { get; set; }
        public string Marcador { get; set; }

        public List<Reserva>? Reservas { get; set; }

        //public Reserva[] ReservaList { get; set; }
        //public Jugador[] Pareja1 { get; set; }
        //public Jugador[] Pareja2 { get; set; }
        //public Jugador[] Ganador{ get; set; }

    }
}
