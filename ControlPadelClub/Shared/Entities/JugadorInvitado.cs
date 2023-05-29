using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControlPadelClub.Shared.Entities
{
    public class JugadorInvitado : Jugador
    {

        [ForeignKey("ReservaId")]
        public Reserva Reserva { get; set; }  public int ReservaId { get; set; } //Para habilitar el borrado en cascada

    }
}
