using Library.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Services
{
    public interface ILibraryService
    {
        IEnumerable<Book> Books { get; }
        public void AddBook(Book book);
        public void RemoveBook(int bookId);
        public void EditBook(Book newBook);

        public Book Find(int bookId);
    }
}
