using BookStoreAppBlazorServerUI.Services.Base;

namespace BookStoreAppBlazorServerUI.Services
{
    internal interface IAuthorService
    {
        Task<Response<List<AuthorReadOnlyDto>>> GetAuthors();
        Task<Response<AuthorDetailsDto>> GetAuthor (int id);
        Task<Response<AuthorUpdateDto>> GetForUpdate(int id);
        Task<Response<int>> CreateAuthor(AuthorCreateDto author);
        Task<Response<int>> Edit(int id, AuthorUpdateDto author);
    }
}