using SearchingSortingPaging.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PagedList;

namespace SearchingSortingPaging.Controllers
{
    public class BookController : Controller
    {
        private BookContext db = new BookContext();
        // GET: Book
        public ActionResult Index(string option, string searchString, string bookCategory, int? pageNumber, string sort)
        {
            var categoryList = new List<string>();
            var categoryQuery = from c in db.Categories orderby c.Name select c.Name;
            var books = from b in db.Books select b;

            categoryList.AddRange(categoryQuery.Distinct());
            ViewBag.bookCategory = new SelectList(categoryList);

            ViewBag.SortByCategoryName = string.IsNullOrEmpty(sort) ? "Desc Category Name" : "";
            ViewBag.SortByBookName = sort == "Book Name" ? "Desc Book Name" : "Book Name";
            ViewBag.SortByAuthor = sort == "Author" ? "Desc Author" : "Author";
            ViewBag.SortByPublisher = sort == "Publisher" ? "Desc Publisher" : "Publisher";
            ViewBag.SortByPublicationDate = sort == "Publication Date" ? "Desc Publication Date" : "Publication Date";
            ViewBag.SortByPrice = sort == "Price" ? "Desc Price" : "Price";
            ViewBag.SortByReducedPrice = sort == "Reduced Price" ? "Desc Reduced Price" : "Reduced Price";

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
            switch (sort)
            {
                case "Desc Category Name":
                    books = books.OrderByDescending(b => b.Category.Name);
                    break;
                case "Desc Book Name":
                    books = books.OrderByDescending(b => b.Name);
                    break;
                case "Desc Author":
                    books = books.OrderByDescending(b => b.Author);
                    break;
                case "Desc Publisher":
                    books = books.OrderByDescending(b => b.Publisher);
                    break;
                case "Desc Publication Date":
                    books = books.OrderByDescending(b => b.PublicationDate);
                    break;
                case "Desc Price":
                    books = books.OrderByDescending(b => b.Price);
                    break;
                case "Desc Reduced Price":
                    books = books.OrderByDescending(b => b.ReducedPrice);
                    break;
                case "Book Name":
                    books = books.OrderBy(b => b.Name);
                    break;
                case "Author":
                    books = books.OrderBy(b => b.Author);
                    break;
                case "Publisher":
                    books = books.OrderBy(b => b.Publisher);
                    break;
                case "Publication Date":
                    books = books.OrderBy(b => b.PublicationDate);
                    break;
                case "Price":
                    books = books.OrderBy(b => b.Price);
                    break;
                case "Reduced Price":
                    books = books.OrderBy(b => b.ReducedPrice);
                    break;
                default:
                    books = books.OrderBy(b => b.Category.Name);
                    break;
            }
            return View(books.ToList().ToPagedList(pageNumber ?? 1, 3));
        }
    }
}