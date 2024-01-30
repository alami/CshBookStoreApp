using BookStoreAppBlazorServerUI.Services.Base;

namespace BookStoreAppBlazorServerUI.Services
{
    internal interface IBookService
    {
        Task<Response<List<BookReadOnlyDto>>> Get();
        Task<Response<BookDetailsDto>> Get(int id);
        Task<Response<BookUpdateDto>> GetForUpdate(int id);
        Task<Response<int>> Create(BookCreateDto book);
        Task<Response<int>> Edit(int id, BookUpdateDto book);
        Task<Response<int>> Delete(int id);
    }
}
