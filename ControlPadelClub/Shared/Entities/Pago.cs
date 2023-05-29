using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControlPadelClub.Shared.Entities
{
    public class Pago
    {
        [Key]
        public int PagoId { get; set; }
        public float CantidadPago { get; set; }
        public bool PagoRealizado { get; set; }
        public string FormaPago { get; set; }

        [ForeignKey("ReservaId")]
        public Reserva Reserva { get; set; } public int ReservaId { get; set; } //Para habilitar el borrado en cascada

    }
}
