using DBStore.DataAccess.Data.Repository.IRepository;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DBStore.Components
{
    public class SearchComponentViewComponent : ViewComponent
    {
        private readonly IUnitOfWorkRepository _unitOfWork;
        public SearchComponentViewComponent(IUnitOfWorkRepository unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public async Task<IViewComponentResult> InvokeAsync(int productid)
        {
            return View();

        }
    }
}
