using BookStoreAppAPI.Data;
using BookStoreAppAPI.Models.Author;

namespace BookStoreAppAPI.Repositories
{
    public interface IAuthorRepository : IGenericRepository<Author>
    {
        Task<AuthorDetailsDto> GetAuthorDetailsAsync(int id);
    }
}
