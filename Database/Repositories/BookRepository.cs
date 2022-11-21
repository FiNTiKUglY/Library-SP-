using Library.Models;
using Library.Services;
using Microsoft.EntityFrameworkCore;

namespace Library.Database.Repositories
{
    public class BookRepository : ILibraryService
	{
		private readonly AppDBContent appDBContent;

		public BookRepository(AppDBContent appDBContent)
		{
			this.appDBContent = appDBContent;
		}

		public IEnumerable<Book> Books => appDBContent.Books.ToList();

		public void AddBook(Book book)
		{
			appDBContent.Books.Add(book);
			appDBContent.SaveChanges();
		}

		public void EditBook(Book newBook)
		{
			appDBContent.Books.Add(newBook);
			appDBContent.SaveChanges();
		}

		public void RemoveBook(int bookId)
		{
			var deleteBook = appDBContent.Books.Find(bookId);
			appDBContent.Books.Remove(deleteBook);
			appDBContent.SaveChanges();
		}

		public Book Find(int bookId)
        {
			var book = appDBContent.Books.Find(bookId);
			return book;
		}
	}
}
