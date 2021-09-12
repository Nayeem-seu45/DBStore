using DBStore.DataAccess;
using DBStore.Paging;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DBStore.Controllers
{
    public class SearchController : Controller
    {
        private readonly ApplicationDbContext db;

        public SearchController(ApplicationDbContext _db)
        {
            db = _db;
        }
        [HttpGet]
        public IActionResult Index(string query)
        {
            ViewData["QueryString"] = query;
            var allproduct = db.Product.Where(s => s.Name.ToLower().Contains(query.ToLower()) || s.Description.ToLower().Contains(query.ToLower())).ToList();
            ViewData["ResultCount"] = allproduct.Count();
            return View(allproduct);
        }
    }
}
