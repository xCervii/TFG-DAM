using ControlPadelClub.Server.BusinessLogic.Interfaces;
using ControlPadelClub.Shared.DTOs;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ControlPadelClub.Server.Controllers
{
    [ApiController]
    public class UsuarioRegistradoController : ControllerBase
    {
        private readonly IUsuarioRegistradoService userService;

        public UsuarioRegistradoController(IUsuarioRegistradoService userService)
        {
            this.userService = userService;
        }

        #region HttpPost

        [Route("api/CrearUsuarioRegistrado")]
        [HttpPost]
        public async Task<ActionResult> CrearUsuarioRegistrado(UsuarioRegistradoDTO userDTO)
        {
            await userService.CrearUsuarioRegistrado(userDTO);
            return NoContent();
        }

        [Route("api/ValidarIniciarSesion")]
        [HttpPost]
        public async Task<ActionResult<LoginDTO>> ValidarInicioSesion(LoginDTO loginDTO)
        {
            LoginDTO loginData = await userService.ValidarIniciarSesion(loginDTO);

            if (loginData.Role != null)
            {
                return Ok(loginData);
            }

            else
            {
                return BadRequest();
            }
        }

        #endregion


        #region HttpGet

        [Route("api/GetAllUsuariosRegistrados")]
        [HttpGet]
        public async Task<ActionResult<List<UsuarioRegistradoDTO>>> GetAllUsuariosRegistrados()
        {
            return await userService.GetAllUsuariosRegistrados();
        }

        [Route("api/GetUsuarioRegistradoByNick/{nick}")]
        [HttpGet]
        public async Task<ActionResult<UsuarioRegistradoDTO>> GetUsuarioRegistradoByNick(string nick)
        {
            return await userService.GetUsuarioRegistradoByNick(nick);
        }

        #endregion


        #region HttpPut

        [Route("api/UpdateUsuarioRegistrado")]
        [HttpPut]
        public async Task<ActionResult> UpdateUsuarioRegistrado(UsuarioRegistradoDTO userDTO)
        {
            await userService.UpdateUsuarioRegistrado(userDTO);
            return NoContent();
        }

        #endregion


        #region HttpDelete

        [Route("api/DeleteUsuarioRegistradoById/{id}")]
        [HttpDelete]
        public async Task<ActionResult> DeleteUsuarioRegistradoById(int id)
        {
            await userService.DeleteUsuarioRegistradoById(id);
            return NoContent();
        }

        #endregion

    }
}
