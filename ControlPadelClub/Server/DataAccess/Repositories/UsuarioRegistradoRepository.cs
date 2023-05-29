using ControlPadelClub.Server.DataAccess.Repositories.Interfaces;
using ControlPadelClub.Shared.Entities;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ControlPadelClub.Server.DataAccess.Repositories
{
    public class UsuarioRegistradoRepository : IUsuarioRegistradoRepository
    {
        private readonly ApplicationDbContext contextDB;

        public UsuarioRegistradoRepository(ApplicationDbContext contextDB)
        {
            this.contextDB = contextDB;
        }

        #region Create

        public async Task<bool> CrearUsuarioRegistrado(UsuarioRegistrado user)
        {
            user.Rol = await contextDB.Rol.FirstOrDefaultAsync(x => x.RoleId == (int)Role.rol.User); //Le asignmos al usuario el rol de 'User'
            user.PerfilOptions = new PerfilOptions() //Creamos unas opciones de perfil por defecto
            {
                Publico = true,
                HabilidadesActivas = false
            };

            await contextDB.AddAsync(user);
            return await SaveAsync();
        }

        #endregion


        #region Read

        public async Task<List<UsuarioRegistrado>> GetAllUsuariosRegistrados()
        {
            return await contextDB.UsuarioRegistrado.Include(u => u.Rol).ToListAsync();
        }

        public async Task<UsuarioRegistrado> GetUsuarioRegistradoByNick(string nick)
        {
            return await contextDB.UsuarioRegistrado.
                                    Include(u => u.Rol). //"Includes" para traer en la consulta los datos de las propiedades de navegacion en la Carga diligente de datos relacionados que hace EF Core.
                                    Include(u => u.PerfilOptions).
                                    FirstOrDefaultAsync(u => u.Nick == nick);
        }

        #endregion


        #region Update

        public async Task<bool> UpdateUsuarioRegistrado(UsuarioRegistrado user)
        {
            contextDB.Entry(user.PerfilOptions).State = EntityState.Modified;
            contextDB.Entry(user).State = EntityState.Modified;
            return await SaveAsync();
        }

        #endregion


        #region Delete

        public async Task<bool> DeleteUsuarioRegistradoById(int id)
        {
            var user = contextDB.UsuarioRegistrado.Include(u => u.PerfilOptions).ToList().Find(u => u.JugadorId == id); //Elimina en cascada
            contextDB.Remove(user);

            return await SaveAsync();
        }

        #endregion


        public async Task<bool> SaveAsync()
        {
            return await contextDB.SaveChangesAsync() >= 0 ? true : false;
        }

        public async Task<bool> ExistUsuarioRegistradoNick(string nick)
        {
            return await contextDB.UsuarioRegistrado.AnyAsync(u => u.Nick.Equals(nick));
        }

        public async Task<bool> ExistUsuarioRegistradoEmail(string email)
        {
            return await contextDB.UsuarioRegistrado.AnyAsync(u => u.Email.Equals(email));
        }

        public async Task<bool> ExistUsuarioRegistradoTlf(string tlf)
        {
            return await contextDB.UsuarioRegistrado.AnyAsync(u => u.Telefono.Equals(tlf));
        }

    }
}

