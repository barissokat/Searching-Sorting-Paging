using SearchingSortingPaging.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PagedList;
using SearchingSortingPaging.Models;

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
        // GET: Category/Create
        public ActionResult Create()
        {
            return View();
        }
        // POST: Category/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id, Name")] Category category)
        {
            if (ModelState.IsValid)
            {
                db.Categories.Add(category);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(category);
        }
    }
}