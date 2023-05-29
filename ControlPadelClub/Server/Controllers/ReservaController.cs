using ControlPadelClub.Server.BusinessLogic.Interfaces;
using ControlPadelClub.Shared.DTOs;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ControlPadelClub.Server.Controllers
{
    [ApiController]
    public class ReservaController : ControllerBase
    {
        private readonly IReservaService reservaService;

        public ReservaController(IReservaService reserva)
        {
            this.reservaService = reserva;

        }

        #region HttpPost
        [Route("api/CrearReserva")]
        [HttpPost]
        public async Task<ActionResult> CrearReserva(ReservaDTO reservaDTO)
        {
            await reservaService.CrearReserva(reservaDTO);
            return NoContent();
        }
        #endregion


        #region HttpGet
        [Route("api/GetAllReservas")]
        [HttpGet]
        public async Task<ActionResult<List<ReservaDTO>>> GetAllReservas()
        {
            return await reservaService.GetAllReservas();
        }

        [Route("api/GetAllReservasByUsuarioRegistradoNick/{nick}")]
        [HttpGet]
        public async Task<ActionResult<List<ReservaDTO>>> GetAllReservasByUsuarioRegistradoNick(string nick)
        {
            return await reservaService.GetAllReservasByUsuarioRegistradoNick(nick);
        }

        [Route("api/GetReservaByUsuarioRegistradoNick/{nick}")]
        [HttpGet]
        public async Task<ActionResult<ReservaDTO>> GetReservaByUsuarioRegistradoNick(string nick)
        {
            return await reservaService.GetReservaByUsuarioRegistradoNick(nick);
        }
        #endregion


        #region HttpPut

        [Route("api/UpdateReserva")]
        [HttpPut]
        public async Task<ActionResult> UpdateReserva(ReservaDTO reservaDTO)
        {
            await reservaService.UpdateReserva(reservaDTO);
            return NoContent();
        }

        #endregion


        #region HttpDelete

        [Route("api/DeleteReservaById/{id}")]
        [HttpDelete]
        public async Task<ActionResult> DeleteReservaById(int id)
        {
            await reservaService.DeleteReservaById(id);
            return NoContent();
        }

        #endregion

    }
}
