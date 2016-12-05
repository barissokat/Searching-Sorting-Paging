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
        public ActionResult Index(string option, string searchString, string bookCategory)
        {
            var categoryList = new List<string>();
            var categoryQuery = from c in db.Categories orderby c.Name select c.Name;
            var books = from b in db.Books select b;

            categoryList.AddRange(categoryQuery.Distinct());
            ViewBag.bookCategory = new SelectList(categoryList);

            if (!String.IsNullOrEmpty(searchString))
            {
                if (!String.IsNullOrEmpty(bookCategory))
                {
                    if (option == "Name")
                    {
                        books = books.Where(b => b.Name.Contains(searchString) && b.Category.Name == bookCategory);
                    }
                    else if (option == "Author")
                    {
                        books = books.Where(b => b.Author.Contains(searchString) && b.Category.Name == bookCategory);
                    }
                    else if (option == "Publisher")
                    {
                        books = books.Where(b => b.Publisher.Contains(searchString) && b.Category.Name == bookCategory);
                    }
                    else
                    {
                        books = books.Where(b => b.Name.Contains(searchString) && b.Category.Name == bookCategory);
                    }
                }
                else
                {
                    if (option == "Name")
                    {
                        books = books.Where(b => b.Name.Contains(searchString));
                    }
                    else if (option == "Author")
                    {
                        books = books.Where(b => b.Author.Contains(searchString));
                    }
                    else if (option == "Publisher")
                    {
                        books = books.Where(b => b.Publisher.Contains(searchString));
                    }
                    else
                    {
                        books = books.Where(b => b.Name.Contains(searchString));
                    }
                }
            }
            return View(books.ToList());
        }
    }
}