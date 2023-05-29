using ControlPadelClub.Shared.Entities;
using Microsoft.EntityFrameworkCore;

namespace ControlPadelClub.Server.DataAccess
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }

        public DbSet<UsuarioRegistrado> UsuarioRegistrado { get; set; }
        public DbSet<Role> Rol { get; set; }
        public DbSet<Reserva> Reserva { get; set; }
        public DbSet<Pista> Pista { get; set; }
        public DbSet<JugadorInvitado> JugadorInvitado { get; set; }
        public DbSet<Pago> Pago { get; set; }

    }
}
