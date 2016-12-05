using SearchingSortingPaging.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SearchingSortingPaging.Controllers
{
    public class BookController : Controller
    {
        private BookContext db = new BookContext();
        // GET: Book
        public ActionResult Index(string option, string searchString)
        {
            if (option == "Name")
            {
                return View(db.Books.Where(b => b.Name.Contains(searchString) || searchString == null).ToList());
            }
            else if (option == "Author")
            {
                return View(db.Books.Where(b => b.Author.Contains(searchString) || searchString == null).ToList());
            }
            else if (option == "Publisher")
            {
                return View(db.Books.Where(b => b.Publisher.Contains(searchString) || searchString == null).ToList());
            }
            else
            {
                return View(db.Books.Where(b => b.Name.StartsWith(searchString) || searchString == null).ToList());
            }
        }
    }
}