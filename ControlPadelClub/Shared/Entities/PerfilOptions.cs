using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControlPadelClub.Shared.Entities
{
    public class PerfilOptions
    {
        [Key]
        public int PerfilOptionsId { get; set; }
        public bool Publico { get; set; }
        public bool HabilidadesActivas { get; set; }
        
        [ForeignKey("JugadorId")]
        public UsuarioRegistrado User { get; set; }  public int JugadorId { get; set; } //Para habilitar el borrado en cascada


    }
}
