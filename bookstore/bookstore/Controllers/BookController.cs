using bookstore.Models;
using bookstore.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace bookstore.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class BookController : ControllerBase
    {
        private readonly IBookService _bookService;

        public BookController(IBookService bookService)
        {
            _bookService = bookService;
        }

        [HttpGet]
        public async Task<List<Book>> GetAllBooks()
        {
            var booksToReturn = _bookService.GetAllBooks();
            return booksToReturn;
        }

        [HttpGet("{id}")]
        public async Task<Book?> GetBookById(int id)
        {
            var bookToReturn = _bookService.GetBookById(id);
            return bookToReturn;
        }

        [HttpPost]
        public async Task<bool> AddBook([FromBody]Book book)
        {
            var added = _bookService.AddBook(book.Id, book.Name);
            return added;
        }

        [HttpPost("auto")]
        public async Task<bool> AddBookAuto()
        {
            var added = _bookService.AutoAdd();
            return added;
        }

        [HttpPatch]
        public async Task<bool> UpdateBook([FromBody]Book book)
        {
            var updated = _bookService.UpdateBookName(book.Id, book.Name);
            return updated;
        }

        [HttpDelete("{id}")]
        public async Task<bool> DeleteBook(int id)
        {
            var deleted = _bookService.DeleteBookName(id);
            return deleted;
        }

        
    }
}
