using Blazored.LocalStorage;
using System.Net.Http.Headers;

namespace BookStoreAppBlazorServerUI.Services.Base
{
    public class BaseHttpService
    {
        private readonly IClient client;
        private readonly ILocalStorageService localStorage;

        public BaseHttpService(IClient client, ILocalStorageService localStorage)
        {
            this.client = client;
            this.localStorage = localStorage;
        }
        protected Response<Guid> ConvertApiExceptions<Guid>(ApiException apiException)
        {
            if (apiException.StatusCode == 400)
            {
                return new Response<Guid>() {
                    Message="[400] Validation errors have occured",
                    ValidationError=apiException.Response.ToString(),
                    Success=false
                };
            }
            if (apiException.StatusCode == 400)
            {
                return new Response<Guid>() {
                    Message="[404] Requested item could not be found",
                    Success=false
                };
            }
            return new Response<Guid>()
            {
                Message = "[any] Domething went wrong, pls try again",
                Success = false
            };
        }
        protected async Task GetBearerToken ()
        {
            var token = await localStorage.GetItemAsync<string>("accessToken");
            if (token != null)
            {
                client.HttpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("bearer", token);
            }
        }
    }
}
