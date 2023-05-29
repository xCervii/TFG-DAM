using ControlPadelClub.Server.DataAccess.Repositories.Interfaces;
using ControlPadelClub.Shared.Entities;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ControlPadelClub.Server.DataAccess.Repositories
{
    public class ReservaRepository : IReservaRepository
    {
        private readonly ApplicationDbContext contextDB;

        public ReservaRepository(ApplicationDbContext contextDB)
        {
            this.contextDB = contextDB;
        }

        public async Task<bool> CrearReserva(Reserva reserva)
        {
            reserva.Pista = await contextDB.Pista.FirstOrDefaultAsync(p => p.PistaId == reserva.Pista.PistaId);

            if (reserva.User != null) {
                reserva.User = await contextDB.UsuarioRegistrado.FirstOrDefaultAsync(u => u.Nick == reserva.User.Nick);
            }

            await contextDB.AddAsync(reserva);
            return await SaveAsync();
        }

        public async Task<List<Reserva>> GetAllReservas()
        {
            return await contextDB.Reserva
                .Include(r => r.Pista)
                .Include(r => r.Partida)
                .Include(r => r.User)
                .Include(r => r.JugadoresInvitados)
                .Include(r => r.Pago)
                .ToListAsync();
        }

        public async Task<List<Reserva>> GetAllReservasByUsuarioRegistradoNick(string nick)
        {
            return await contextDB.Reserva
                .Include(r => r.Pista)
                .Include(r => r.Partida)
                .Include(r => r.User)
                .Include(r => r.JugadoresInvitados)
                .Include(r => r.Pago)
                .Where(r => r.User.Nick == nick)
                .ToListAsync();
        }


        public async Task<Reserva> GetReservaByUsuarioRegistradoNick(string nick)
        {
            return await contextDB.Reserva
                .Include(r => r.Pista)
                .Include(r => r.Partida)
                .Include(r => r.User)
                .Include(r => r.JugadoresInvitados)
                .Include(r => r.Pago)
                .FirstOrDefaultAsync(r => r.User.Nick == nick);
        }

        public async Task<bool> UpdateReserva(Reserva reserva)
        {
            contextDB.Entry(reserva).State = EntityState.Modified;
            contextDB.Entry(reserva.Pago).State = EntityState.Modified;
            return await SaveAsync();
        }

        public async Task<bool> DeleteReservaById(int id)
        {
            var reserva = contextDB.Reserva.Include(r => r.JugadoresInvitados) //Elimina en cascada
                                           .Include(r => r.Pago)
                                           .ToList()
                                           .Find(r => r.ReservaId == id);

            contextDB.Remove(reserva);

            return await SaveAsync();
        }


        public async Task<bool> SaveAsync()
        {
            return await contextDB.SaveChangesAsync() >= 0 ? true : false;
        }
    }
}
