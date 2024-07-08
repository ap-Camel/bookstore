
using bookstore.Models;

namespace bookstore.Memory
{
    public static class BooksMemory
    {
        private static int index = 1;
        public static List<Book> BooksList = new List<Book>
        {
            new Book { Id = index++, Name = "books01" },
            new Book { Id = index++, Name = "books02" },
            new Book { Id = index++, Name = "books03" },
            new Book { Id = index++, Name = "books04" },
            new Book { Id = index++, Name = "books05" },
            new Book { Id = index++, Name = "books06" },
            new Book { Id = index++, Name = "books07" },
            new Book { Id = index++, Name = "books08" },
            new Book { Id = index++, Name = "books09" }
        };

        public static bool AddBook(int id, string name, bool auto = false)
        {
            if(auto)
            {
                BooksList.Add(new Book { Id = ++index, Name = "book auto " + index });
                return true;
            }

            if (id < index)
                return false;

            BooksList.Add(new Book { Id = id, Name = name });
            index = id;
            return true;
        }
    }
}
