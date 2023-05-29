using AutoMapper;
using ControlPadelClub.Server.BusinessLogic.Interfaces;
using ControlPadelClub.Server.DataAccess.Repositories.Interfaces;
using ControlPadelClub.Shared.DTOs;
using ControlPadelClub.Shared.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ControlPadelClub.Server.BusinessLogic
{
    public class ReservaService : IReservaService
    {
        private readonly IReservaRepository reservaRepository;
        private readonly IMapper mapper;

        public ReservaService(IReservaRepository reservaRepository, IMapper mapper)
        {
            this.reservaRepository = reservaRepository;
            this.mapper = mapper;
        }

        public async Task<bool> CrearReserva(ReservaDTO reservaDTO)
        {
           var reserva = mapper.Map<Reserva>(reservaDTO);
           return await reservaRepository.CrearReserva(reserva);
        }

        public async Task<List<ReservaDTO>> GetAllReservas()
        {
            var reservas = await reservaRepository.GetAllReservas();
           
            var reservasDTO = mapper.Map<List<ReservaDTO>>(reservas); 
            return reservasDTO;
        }

        public async Task<List<ReservaDTO>> GetAllReservasByUsuarioRegistradoNick(string nick)
        {
            var reservas = await reservaRepository.GetAllReservasByUsuarioRegistradoNick(nick);

            var reservasDTO = mapper.Map<List<ReservaDTO>>(reservas); 
            return reservasDTO;
        }

        public async Task<ReservaDTO> GetReservaByUsuarioRegistradoNick(string nick)
        {
            var reserva = await reservaRepository.GetReservaByUsuarioRegistradoNick(nick);
            var reservaDTO = mapper.Map<ReservaDTO>(reserva);
            return reservaDTO;
        }

        public async Task<bool> UpdateReserva(ReservaDTO reservaDTO)
        {
            var reserva = mapper.Map<Reserva>(reservaDTO);
            return await reservaRepository.UpdateReserva(reserva);
        }

        public async Task<bool> DeleteReservaById(int id)
        {
            return await reservaRepository.DeleteReservaById(id);
        }

    }
}
