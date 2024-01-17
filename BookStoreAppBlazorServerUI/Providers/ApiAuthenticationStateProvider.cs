using Blazored.LocalStorage;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;

namespace BookStoreAppBlazorServerUI.Providers
{
    public class ApiAuthenticationStateProvider : AuthenticationStateProvider
    {
        private readonly ILocalStorageService localStorage;
        private readonly JwtSecurityTokenHandler jwtSecurityTokenHandler;
        public ApiAuthenticationStateProvider(ILocalStorageService localStorage)
        {
            this.localStorage = localStorage;
            jwtSecurityTokenHandler = new JwtSecurityTokenHandler();
        }
        public override async Task<AuthenticationState> GetAuthenticationStateAsync()
        {
            var user = new ClaimsPrincipal(new ClaimsIdentity());
            var savedToken = await localStorage.GetItemAsync<string>("accessToken");
            if (savedToken == null) 
            {
                return new AuthenticationState(user);
            }
            var tokenContent = jwtSecurityTokenHandler.ReadJwtToken(savedToken);

            if (tokenContent.ValidTo < DateTime.Now)
            {
                return new AuthenticationState(user);
            }
            
            var claims = tokenContent.Claims;

            user = new ClaimsPrincipal(new ClaimsIdentity(claims, "jwt"));

            return new AuthenticationState(user) ;
        }
        public async Task LoggedIn()
        {
            var savedToken = await localStorage.GetItemAsync<string>("accessToken");
            var tokenContent = jwtSecurityTokenHandler.ReadJwtToken(savedToken);
            var claims = tokenContent.Claims;
            var user = new ClaimsPrincipal(new ClaimsIdentity(claims, "jwt"));
            var authState = Task.FromResult(new AuthenticationState(user));
            NotifyAuthenticationStateChanged(authState);
        }
        public async Task LoggedOut()
        {            
            var nobody = new ClaimsPrincipal(new ClaimsIdentity());
            var authState = Task.FromResult(new AuthenticationState(nobody));
            NotifyAuthenticationStateChanged(authState);
        }
    }
}
