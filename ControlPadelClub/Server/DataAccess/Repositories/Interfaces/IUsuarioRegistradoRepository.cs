using ControlPadelClub.Shared.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ControlPadelClub.Server.DataAccess.Repositories.Interfaces
{
    public interface IUsuarioRegistradoRepository
    {

        #region Create

        Task<bool> CrearUsuarioRegistrado(UsuarioRegistrado user);

        #endregion


        #region Read

        Task<List<UsuarioRegistrado>> GetAllUsuariosRegistrados();

        Task<UsuarioRegistrado> GetUsuarioRegistradoByNick(string nick);

        #endregion


        #region Update

        Task<bool> UpdateUsuarioRegistrado(UsuarioRegistrado user);

        #endregion


        #region Delete

        Task<bool> DeleteUsuarioRegistradoById(int id);

        #endregion


        Task<bool> ExistUsuarioRegistradoNick(string nick);

        Task<bool> ExistUsuarioRegistradoEmail(string email);

        Task<bool> ExistUsuarioRegistradoTlf(string tlf);



    }
        
}
