using cet322_hw1.Models;
using Microsoft.AspNetCore.Mvc;

namespace cet322_hw1.Controllers
{
    public class BookController : Controller
    {
        private static List<BookModel> _books = new List<BookModel>();

        static BookController() //mockdata
        {
            _books.Add(new BookModel { Name = "Outliers", Writer = "Malcolm Gladwell", Available = true, DeliveryTime = null });
            _books.Add(new BookModel { Name = "The House of Morgan", Writer = "Ron Chernow", Available = false, DeliveryTime = DateTime.Now.AddDays(5) });
            _books.Add(new BookModel { Name = "Frankenstein", Writer = "Mary Shelley", Available = true, DeliveryTime = null });
            _books.Add(new BookModel { Name = "The Merchant of Venice", Writer = "William Shakespeare", Available = false, DeliveryTime = DateTime.Now.AddDays(0.5) });
        }
        public IActionResult ListBooks()
        {
            return View(_books);
        }
        public ActionResult AddBook(BookModel newBook)
        {
            newBook.Available = true;
            newBook.DeliveryTime = null;

            _books.Add(newBook);

            return RedirectToAction("ListBooks");
        }
        public ActionResult RentBook(string bookName, string firstName, string lastName, DateTime deliveryTime)
        {
            var book = _books.FirstOrDefault(b => b.Name == bookName);
            if (book != null)
            {
                book.DeliveryTime = deliveryTime;
                book.Available = false;
            }

            return RedirectToAction("ListBooks");
        }
    }
}
