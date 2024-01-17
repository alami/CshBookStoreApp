using Blazored.LocalStorage;
using Blazored.LocalStorage.StorageOptions;
using BookStoreAppBlazorServerUI.Providers;
using BookStoreAppBlazorServerUI.Services.Base;

namespace BookStoreAppBlazorServerUI.Services.Authentication
{
    public class AuthenticationService : IAuthenticationService
    {
        private readonly IClient httpClient;
        private readonly ILocalStorageService localStorage;
        private readonly ApiAuthenticationStateProvider authenticationStateProvider;

        public AuthenticationService(IClient httpClient, ILocalStorageService localStorage,
            ApiAuthenticationStateProvider authenticationStateProvider)
        {
            this.httpClient = httpClient;
            this.localStorage = localStorage;
            this.authenticationStateProvider = authenticationStateProvider;
        }
        public async Task<bool> AuthenticateAsync(LoginUserDto LoginModel)
        {
            var response = await httpClient.LoginAsync(LoginModel);
            //Store token
            await localStorage.SetItemAsync("accessToken", response.Token );
            //Change auth of state
            await ((ApiAuthenticationStateProvider)authenticationStateProvider).LoggedIn();
            return true;
        }
    }
}
