using BookStoreAppBlazorServerUI.Services.Base;

namespace BookStoreAppBlazorServerUI.Services.Authentication
{
    public interface IAuthenticationService
    {
        Task<bool> AuthenticateAsync(LoginUserDto LoginModel);
    }
}
