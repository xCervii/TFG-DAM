using ControlPadelClub.Shared.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ControlPadelClub.Server.DataAccess.Repositories.Interfaces
{
    public interface IReservaRepository
    {
        Task<bool> CrearReserva(Reserva reserva);
        Task<List<Reserva>> GetAllReservas();
        Task<List<Reserva>> GetAllReservasByUsuarioRegistradoNick(string nick);
        Task<Reserva> GetReservaByUsuarioRegistradoNick(string nick);
        Task<bool> UpdateReserva(Reserva reserva);
        Task<bool> DeleteReservaById(int id);

    }
}
