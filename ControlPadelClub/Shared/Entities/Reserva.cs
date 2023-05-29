using ControlPadelClub.Shared.DTOs;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace ControlPadelClub.Shared.Entities
{
    public class Reserva
    {
        [Key]
        public int ReservaId { get; set; }
        public DateTime Fecha { get; set; }
        public DateTime HoraInicio { get; set; }
        public DateTime HoraFin { get; set; }
        public float Precio { get; set; }


        public Pista Pista { get; set; }
        public EstadoReserva Estado { get; set; }
       
        public Pago Pago { get; set; }
        public Partida? Partida { get; set; }

        [ForeignKey("JugadorId")]
        public UsuarioRegistrado User { get; set; }
        public List<JugadorInvitado> JugadoresInvitados { get; set; }
        public enum EstadoReserva
        {
            CONFIRMADA_INCOMPLETA = 1,
            CONFIRMADA_COMPLETA = 2,
            ESPERA = 3
        }

    }
}
