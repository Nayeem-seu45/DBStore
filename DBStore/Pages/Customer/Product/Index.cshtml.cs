using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DBStore.DataAccess.Data.Repository;
using DBStore.DataAccess.Data.Repository.IRepository;
using DBStore.Models;
using DBStore.Paging;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace DBStore.Pages.Customer.Product

{
    public class IndexModel : PageModel
    {
        private IUnitOfWorkRepository productRepository;

        public IndexModel(IUnitOfWorkRepository productRepository)
        {
            this.productRepository = productRepository;
        }

        public IEnumerable<Models.Product> Products { get; set; }





        public IActionResult OnGet(int id)
        {
            const int pageSize = 12;
            if (id < 1)
            {
                id = 1;
            }
            int resCount = productRepository.Product.GetAll().Count();
            var pagers = new PagedList(resCount, id, pageSize);
            int recSkip = (id - 1) * pageSize;
            var data = productRepository.Product.GetAll().Skip(recSkip).Take(pagers.PageSize).ToList();
            ViewData["pager"] = pagers;
            Products = data;
            //return View(data);
            return Page();

            //int num = 12;
            //HttpContext.Session.SetInt32("Num", 12);
            //Products = productRepository.Product.GetAll().Take(num).ToList();
            //ViewData["totaldata"] = productRepository.Product.GetAll().Count();
        }
        //[HttpPost]
        //public Page GetList(Models.Product product)
        //{
        //    int num = 12;
        //    HttpContext.Session.SetInt32("Num", 12);
        //    Products = productRepository.Product.GetAll().Take(num).ToList();
        //    ViewData["totaldata"] = productRepository.Product.GetAll().Count();
        //    return PartialView("_LoadMoreProducts", Products);
        //    //    //return Partial("_LoadMoreProducts", Products);
        //}
        //[NonAction]
        public virtual PartialViewResult PartialView(string viewname, List<Models.Product> Products)
        {
            int num = Convert.ToInt32(HttpContext.Session.GetInt32("Num")) + 12;
            Products = productRepository.Product.GetAll().Take(num).ToList(); HttpContext.Session.SetInt32("Num", num);
            ViewData["totaldata"] = productRepository.Product.GetAll().Count();
            return PartialView("_LoadMoreProducts", Products);

        }
        //public void OnPost()
        //{

        //}

    }
}