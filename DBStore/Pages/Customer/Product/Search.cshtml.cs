using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DBStore.DataAccess.Data.Repository.IRepository;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace DBStore.Pages.Customer.Product
{
    public class SearchModel : PageModel
    {
        private IUnitOfWorkRepository repository;

        public SearchModel(IUnitOfWorkRepository repository)
        {
            this.repository = repository;
        }
        public IEnumerable<DBStore.Models.Product> Products { get; set; }
        public int totalCount { get; set; }
        public string QueryString { get; set; }
        public IActionResult OnGet(string query)
        {
            Products = repository.Product.GetAll().Where(s => s.Name.ToLower().Contains(query.ToLower()) || s.Description.ToLower().Contains(query.ToLower())).ToList();
            totalCount = Products.Count();
            QueryString = query;
            return Page();
        }
    }
}
