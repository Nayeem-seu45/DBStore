using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using DBStore.DataAccess;
using DBStore.Models;

namespace DBStore.Pages.Customer.Account
{
    public class IndexModel : PageModel
    {
        private readonly DBStore.DataAccess.ApplicationDbContext _context;

        public IndexModel(DBStore.DataAccess.ApplicationDbContext context)
        {
            _context = context;
        }

        public IList<Category> Category { get;set; }

        public async Task OnGetAsync()
        {
            Category = await _context.Category.ToListAsync();
        }
    }
}
