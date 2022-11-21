using Library.Models;

namespace Library.ViewModels
{
    public class BooksView
    {
        public IEnumerable<Book> Books { get; set; }
        public string? Text { get; set; } = string.Empty;
    }
}
