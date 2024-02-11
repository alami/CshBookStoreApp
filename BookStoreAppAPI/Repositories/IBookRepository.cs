using BookStoreAppAPI.Data;
using BookStoreAppAPI.Models.Book;

namespace BookStoreAppAPI.Repositories
{
    public interface IBookRepository : IGenericRepository<Book>
    {
        Task<List<BookReadOnlyDto>> GetAllBookAsync();
        Task<BookDetailsDto> GetBookAsync(int id);
    }
}
