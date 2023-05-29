using ControlPadelClub.Shared.DTOs;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ControlPadelClub.Server.BusinessLogic.Interfaces
{
    public interface IReservaService
    {
        Task<bool> CrearReserva(ReservaDTO reservaDTO);
        Task<List<ReservaDTO>> GetAllReservas();
        Task<List<ReservaDTO>> GetAllReservasByUsuarioRegistradoNick(string nick);
        Task<ReservaDTO> GetReservaByUsuarioRegistradoNick(string nick);
        Task<bool> UpdateReserva(ReservaDTO reservaDTO);
        Task<bool> DeleteReservaById(int id);
    }
}
