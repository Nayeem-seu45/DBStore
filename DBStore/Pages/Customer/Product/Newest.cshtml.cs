using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DBStore.DataAccess.Data.Repository.IRepository;
using DBStore.Paging;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace DBStore.Pages.Customer.Product
{
    public class NewestModel : PageModel
    {
        private IUnitOfWorkRepository productRepository;

        public NewestModel(IUnitOfWorkRepository productRepository)
        {
            this.productRepository = productRepository;
        }
        public List<Models.Product> Products { get; set; }

        public IActionResult OnGet(int id)
        {
            const int pageSize = 12;
            DateTime dt = DateTime.Now;
            dt = dt.AddDays(10);

            if (id < 1)
            {
                id = 1;
            }
            int resCount = productRepository.Product.GetAll().Where(s => s.AddDate < dt).Count();
            var pagers = new PagedList(resCount, id, pageSize);
            int recSkip = (id - 1) * pageSize;
            var data = productRepository.Product.GetAll().Where(s => s.AddDate < dt).Skip(recSkip).Take(pagers.PageSize).ToList();
            ViewData["pager"] = pagers;
            Products = data;
            return Page();


        }

        public virtual PartialViewResult PartialView(string viewname, List<Models.Product> Products)
        {

            int num = Convert.ToInt32(HttpContext.Session.GetInt32("Num")) + 12;
            Products = productRepository.Product.GetAll().Take(num).ToList(); HttpContext.Session.SetInt32("Num", num);
            ViewData["totaldata"] = productRepository.Product.GetAll().Count();
            return PartialView("_LoadMoreProducts", Products);

        }
    }
}