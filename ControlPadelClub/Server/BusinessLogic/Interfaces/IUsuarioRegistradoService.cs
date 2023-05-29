using ControlPadelClub.Shared.DTOs;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ControlPadelClub.Server.BusinessLogic.Interfaces
{
    public interface IUsuarioRegistradoService
    {
        #region Create

        Task<bool> CrearUsuarioRegistrado(UsuarioRegistradoDTO userDTO);

        #endregion


        #region Read

        Task<List<UsuarioRegistradoDTO>> GetAllUsuariosRegistrados();

        Task<UsuarioRegistradoDTO> GetUsuarioRegistradoByNick(string nick);

        #endregion


        #region Update

        Task<bool> UpdateUsuarioRegistrado(UsuarioRegistradoDTO userDTO);

        #endregion


        #region Delete

        Task<bool> DeleteUsuarioRegistradoById(int id);

        #endregion

        Task<LoginDTO> ValidarIniciarSesion(LoginDTO loginDTO);
    }
}
