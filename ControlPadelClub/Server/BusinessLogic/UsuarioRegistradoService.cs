using AutoMapper;
using ControlPadelClub.Server.BusinessLogic.Interfaces;
using ControlPadelClub.Server.DataAccess.Repositories.Interfaces;
using ControlPadelClub.Shared.DTOs;
using ControlPadelClub.Shared.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ControlPadelClub.Server.BusinessLogic
{
    public class UsuarioRegistradoService : IUsuarioRegistradoService
    {
        private readonly IUsuarioRegistradoRepository userRepository;
        private readonly IMapper mapper;

        public UsuarioRegistradoService(IUsuarioRegistradoRepository userRepository, IMapper mapper)
        {
            this.userRepository = userRepository;
            this.mapper = mapper;
        }


        #region Create

        public async Task<bool> CrearUsuarioRegistrado(UsuarioRegistradoDTO userDTO)
        {
            var nick = userDTO.Nick;
            var email = userDTO.Email;
            var tlf = userDTO.Telefono;
            //Validación 1 : Comprueba si ya existe el nick en la base de datos
            if (await userRepository.ExistUsuarioRegistradoNick(nick)) { return false; }
            //Validación 2 : Comprueba si ya existe el email en la base de datos
            if (await userRepository.ExistUsuarioRegistradoEmail(email)) { return false; }
            //Validación 3 : Comprueba si ya existe el teléfono en la base de datos
            if (await userRepository.ExistUsuarioRegistradoTlf(tlf)) { return false; }

            else
            {
                var user = mapper.Map<UsuarioRegistrado>(userDTO);
                return await userRepository.CrearUsuarioRegistrado(user);
            }

        }

        #endregion


        #region Read

        public async Task<List<UsuarioRegistradoDTO>> GetAllUsuariosRegistrados()
        {
            var userList = await userRepository.GetAllUsuariosRegistrados();
            var userDTOlist = mapper.Map<List<UsuarioRegistradoDTO>>(userList);

            return userDTOlist;
        }


        public async Task<UsuarioRegistradoDTO> GetUsuarioRegistradoByNick(string nick)
        {
            var user = await userRepository.GetUsuarioRegistradoByNick(nick);
            var userDTO = mapper.Map<UsuarioRegistradoDTO>(user);

            return userDTO;
        }


        #endregion


        #region Update

        public async Task<bool> UpdateUsuarioRegistrado(UsuarioRegistradoDTO userDTO)
        {
            var user = mapper.Map<UsuarioRegistrado>(userDTO);
            return await userRepository.UpdateUsuarioRegistrado(user);

        }

        #endregion


        #region Delete

        public async Task<bool> DeleteUsuarioRegistradoById(int id)
        {
            return await userRepository.DeleteUsuarioRegistradoById(id);
        }

        #endregion


        public async Task<LoginDTO> ValidarIniciarSesion(LoginDTO loginDTO)
        {
            var username = loginDTO.Username;
            var password = loginDTO.Password;

            if (await userRepository.ExistUsuarioRegistradoNick(username))
            {
                UsuarioRegistrado user = await userRepository.GetUsuarioRegistradoByNick(username);

                if (password == user.Contraseña)
                {
                    loginDTO.Role = user.Rol; //Le insertamos el rol para que se lo devuelva a la vista
                }
            }

            return loginDTO;
        }

    }
}
