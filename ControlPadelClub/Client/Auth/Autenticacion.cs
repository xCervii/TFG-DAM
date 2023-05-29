using Blazored.SessionStorage;
using Microsoft.AspNetCore.Components.Authorization;
using System.Security.Claims;
using System.Threading.Tasks;

namespace ControlPadelClub.Client.Auth
{
    public class Autenticacion : AuthenticationStateProvider
    {
        private ISessionStorageService almacenarSesionService;

        public Autenticacion(ISessionStorageService almacenarSesionService)
        {
            this.almacenarSesionService = almacenarSesionService;
        }

        public async override Task<AuthenticationState> GetAuthenticationStateAsync()
        {
            var username = await almacenarSesionService.GetItemAsync<string>("username");
            var role = await almacenarSesionService.GetItemAsync<string>("role");

            ClaimsIdentity identity;

            //Usuario autenticado
            if(username != null)
            {
                identity = new ClaimsIdentity(new[] 
                { 
                    new Claim(ClaimTypes.Name, username),
                    new Claim(ClaimTypes.Role, role)
                
                }, "login_Auth");
            }

            //Usuario no autenticado
            else
            {
                identity = new ClaimsIdentity();
            }

            var user = new ClaimsPrincipal(identity);
            return await Task.FromResult(new AuthenticationState(user));
        }

        public void CerrarSesion()
        {
            almacenarSesionService.RemoveItemAsync("username");
            almacenarSesionService.RemoveItemAsync("role");
            var identity = new ClaimsIdentity();
            var user = new ClaimsPrincipal(identity);

            NotifyAuthenticationStateChanged(Task.FromResult(new AuthenticationState(user)));
        }

    }
}
