using bookstore.Models;

namespace bookstore.Services.Interfaces
{
    public interface IBookService
    {
        bool AddBook(int id, string name);
        bool AutoAdd();
        Book? GetBookById(int id);
        List<Book> GetAllBooks();
        bool UpdateBookName(int id, string newName);
        bool DeleteBookName(int id);
    }
}
