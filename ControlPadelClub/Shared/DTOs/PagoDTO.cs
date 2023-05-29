using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControlPadelClub.Shared.DTOs
{
    public class PagoDTO
    {
        public int PagoId { get; set; }
        public float CantidadPago { get; set; }
        public bool PagoRealizado { get; set; }
        public string FormaPago { get; set; }
    }
}
