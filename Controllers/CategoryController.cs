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
        public ActionResult Index(string searchString, int? pageNumber)
        {
            var query = db.Categories.AsQueryable();
            query = query.Where(c => c.Name.Contains(searchString) || searchString == null);
            return View(query.ToList().ToPagedList(pageNumber ?? 1, 3));
        }
    }
}