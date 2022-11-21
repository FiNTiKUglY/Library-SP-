using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Library.Models;
using Library.ViewModels;
using Library.Services;

namespace Library.Controllers
{
    public enum SortState
    {
        TitleAsc,   
        TitleDesc,  
        AuthorAsc, 
        AuthorDesc,   
        YearAsc, 
        YearDesc 
    }

    public class BooksController : Controller
    {
        private readonly ILibraryService _allBooks;

        public BooksController(ILibraryService IAllBooks)
        {
            _allBooks = IAllBooks;
        }

        public ViewResult List(SortState sortOrder = SortState.TitleAsc)
        {
            var model = new BooksView();
            model.Books = _allBooks.Books;

            ViewData["TitleSort"] = sortOrder == SortState.TitleAsc ? SortState.TitleDesc : SortState.TitleAsc;
            ViewData["AuthorSort"] = sortOrder == SortState.AuthorAsc ? SortState.AuthorDesc : SortState.AuthorAsc;
            ViewData["YearSort"] = sortOrder == SortState.YearAsc ? SortState.YearDesc : SortState.YearAsc;

            model.Books = sortOrder switch
            {
                SortState.TitleDesc => model.Books.OrderByDescending(s => s.Title),
                SortState.AuthorAsc => model.Books.OrderBy(s => s.Author),
                SortState.AuthorDesc => model.Books.OrderByDescending(s => s.Author),
                SortState.YearAsc => model.Books.OrderBy(s => s.Year),
                SortState.YearDesc => model.Books.OrderByDescending(s => s.Year),
                _ => model.Books.OrderBy(s => s.Title),
            };

            return View(model);
        }

        [HttpPost]
        public IActionResult List(BooksView model)
        {
            model.Books = _allBooks.Books.OrderBy(s => s.Title);
            model.Books = model.Books.Where(book => book.ToString().ToLower().Contains(model.Text.ToLower()));

            return View(model);
        }

        [Authorize(Roles = "admin")]
        public ViewResult Add()
        {
            return View();
        }

        [Authorize(Roles = "admin")]
        [HttpPost]
        public IActionResult Add(Book book)
        {
            _allBooks.AddBook(book);
            return RedirectToAction("List");
        }

        [Authorize(Roles = "admin")]
        public ViewResult Edit(int bookId)
        {
            var editBook = _allBooks.Find(bookId);
            return View(editBook);
        }

        [Authorize(Roles = "admin")]
        [HttpPost]
        public IActionResult Edit(Book editedBook, int bookId)
        {
            _allBooks.RemoveBook(bookId);
            _allBooks.EditBook(editedBook);
            return RedirectToAction("List");
        }

        [Authorize(Roles = "admin")]
        public IActionResult Remove(int bookId)
        {
            _allBooks.RemoveBook(bookId);
            return RedirectToAction("List"); ;
        }
    }
}
