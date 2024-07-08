using bookstore.Memory;
using bookstore.Models;
using bookstore.Services.Interfaces;
using Microsoft.AspNetCore.Server.Kestrel.Transport.NamedPipes;

namespace bookstore.Services
{
    public class BookService : IBookService
    {
        public BookService()
        {

        }

        public bool AddBook(int id, string name)
        {
            var exists = GetBookById(id);
            if (exists is not null)
                return false;

            var added = BooksMemory.AddBook(id, name);
            return added;
        }

        public bool AutoAdd()
        {
            var added = BooksMemory.AddBook(0, null, true);
            return added;
        }

        public Book? GetBookById(int id)
        {
            var bookToReturn = BooksMemory.BooksList
                .Where(x => x.Id == id)
                .FirstOrDefault();
            return bookToReturn;
        }

        public List<Book> GetAllBooks()
        {
            return BooksMemory.BooksList;
        }

        public bool UpdateBookName(int id, string newName)
        {
            var bookToUpdate = GetBookById(id);
            if(bookToUpdate == null)
                return false;

            bookToUpdate.Name = newName;
            return true;
        }

        public bool DeleteBookName(int id)
        {
            var bookToDelete = GetBookById(id);
            if (bookToDelete == null)
                return false;

            BooksMemory.BooksList.Remove(bookToDelete);
            return true;
        }
    }
}
