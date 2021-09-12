using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DBStore.Areas.Admin.Controllers
{
    
    [Area("Admin")]
    [Route("api/[controller]")]
    [ApiController]
    public class AdminController : Controller
    {
        public IActionResult Index()
        {
            
            return View();
        }
    }
}