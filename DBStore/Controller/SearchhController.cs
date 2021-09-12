using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DBStore.DataAccess;
using DBStore.DataAccess.Data.Repository.IRepository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis.Operations;

namespace DBStore.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SearchhController : Controller
    {
        private readonly ApplicationDbContext db;

        public SearchhController(ApplicationDbContext _db)
        {
            db = _db;
        }

        [Produces("application/json")]
        [HttpGet("search")]
        public async Task<IActionResult> Search()
        {
            try
            {
                string term = HttpContext.Request.Query["term"].ToString();
                var productTilte = db.Product.Where(p=>p.Name.Contains(term)).Select(p=>p.Name).ToList();
                return Ok(productTilte);

            }
            catch
            {
                return BadRequest();
            }
        }

     
    }
}