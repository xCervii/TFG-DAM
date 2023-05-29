using ControlPadelClub.Shared.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static ControlPadelClub.Shared.Entities.Reserva;

namespace ControlPadelClub.Shared.DTOs
{
    public class ReservaDTO
    {
        public int ReservaId { get; set; }
        public DateTime Fecha { get; set; }
        public DateTime HoraInicio { get; set; }
        public DateTime HoraFin { get; set; }


        public EstadoReserva Estado { get; set; }
        public PistaDTO Pista { get; set; }
        public PagoDTO Pago { get; set; }
        public PartidaDTO Partida { get; set; }
        public UsuarioRegistradoDTO User { get; set; }
        public List<JugadorInvitadoDTO> JugadoresInvitados { get; set; }

        public enum EstadoReserva
        {
            CONFIRMADA_INCOMPLETA = 1,
            CONFIRMADA_COMPLETA = 2,
            ESPERA = 3
        }

    }
}
