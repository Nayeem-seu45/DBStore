using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using DBStore.DataAccess.Data.Repository.IRepository;
using DBStore.Models.VModels;
using DBStore.Paging;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace DBStore.Pages.Customer.Home
{
    public class ReviewsModel : PageModel
    {
        private readonly IUnitOfWorkRepository _unitOfWork;
        public ReviewsModel(IUnitOfWorkRepository unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public IEnumerable<Models.Reviews> ProductReviews { get; set; }

        public IActionResult OnGet(int id)
        {
            const int pageSize = 5;
            if (id < 1)
            {
                id = 1;
            }
            int resCount = _unitOfWork.Reviews.GetAll().Count();
            var pagers = new PagedList(resCount, id, pageSize);
            int recSkip = (id - 1) * pageSize;
            var data = _unitOfWork.Reviews.GetAll().Skip(recSkip).Take(pagers.PageSize).ToList();
            ViewData["pager"] = pagers;
            ProductReviews = data;
           
            return Page();
        }
    }
}