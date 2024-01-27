using BookStoreAppAPI.Models.Book;

namespace BookStoreAppAPI.Models.Author
{
    public class AuthorDetailsDto : AuthorReadOnlyDto
    {
        public List<BookReadOnlyDto> Books { get; set; }
    }
}
