using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace ControlPadelClub.Shared.Entities
{
    public class UsuarioRegistrado : Jugador
    {
        public string Nombre { get; set; }
        public string Apellidos { get; set; }
        public string Email { get; set; }
        public string Contraseña { get; set; }
        public DateTime? FechaNacimiento{ get; set; }
        public string Telefono { get; set; }
        public string TipoNivel { get; set; }
        public string Sexo { get; set; }
        public string ManoHabil { get; set; }
        public string Posicion { get; set; }
        public string Foto_src { get; set; }

        public Role Rol { get; set; }
        public PerfilOptions PerfilOptions { get; set; }
        public List<Reserva> Reservas { get; set; }

    }
}
