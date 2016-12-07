using SearchingSortingPaging.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PagedList;

namespace SearchingSortingPaging.Controllers
{
    public class CategoryController : Controller
    {
        private BookContext db = new BookContext();
        // GET: Category
        public ActionResult Index(string searchString, int? pageNumber, string sort)
        {
            var categories = db.Categories.AsQueryable();
            ViewBag.SortByCategoryName = string.IsNullOrEmpty(sort) ? "Desc Category Name" : "";
            categories = categories.Where(c => c.Name.Contains(searchString) || searchString == null);
            switch (sort)
            {
                case "Desc Category Name":
                    categories = categories.OrderByDescending(c => c.Name);
                    break;
                default:
                    categories = categories.OrderBy(c => c.Name);
                    break;
            }
            return View(categories.ToList().ToPagedList(pageNumber ?? 1, 3));
        }
    }
}