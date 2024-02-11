using AutoMapper;
using AutoMapper.QueryableExtensions;
using BookStoreAppAPI.Data;
using BookStoreAppAPI.Models.Book;
using Microsoft.EntityFrameworkCore;

namespace BookStoreAppAPI.Repositories
{
    public class BookRepository : GenericRepository<Book>, IBookRepository
    {
        private readonly BookStoreDbContext context;
        private readonly IMapper mapper;

        public BookRepository(BookStoreDbContext context, IMapper mapper) : base(context)
        {
            this.context = context;
            this.mapper = mapper;
        }

        public async Task<List<BookReadOnlyDto>> GetAllBookAsync()
        {
            return await context.Books
                    .Include(q => q.Author)
                    .ProjectTo<BookReadOnlyDto>(mapper.ConfigurationProvider)
                    .ToListAsync();
        }

        public async Task<BookDetailsDto> GetBookAsync(int id)
        {
            return  await context.Books
                .Include(q => q.Author)
                .ProjectTo<BookDetailsDto>(mapper.ConfigurationProvider)
                .FirstOrDefaultAsync(q => q.Id == id);
        }
    }
}
