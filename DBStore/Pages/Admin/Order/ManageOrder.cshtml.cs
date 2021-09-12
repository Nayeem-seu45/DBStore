using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DBStore.DataAccess.Data.Repository.IRepository;
using DBStore.Models;
using DBStore.Models.VModels;
using DBStore.Utility;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace DBStore.Pages.Admin.Order
{
    public class ManageOrderModel : PageModel
    {
        private readonly IUnitOfWorkRepository _unitOfWork;
        public ManageOrderModel(IUnitOfWorkRepository unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        [BindProperty]
        public List<OrderDetailsVM> orderDetailsVM { get; set; }

      
        public void OnGet()
        {
            orderDetailsVM = new List<OrderDetailsVM>();
            List<OrderHeader> OrderHeaderList = _unitOfWork.OrderHeader.GetAll().Where(o => o.Status.ToLower() == SD.StatusSubmitted.ToLower() || o.Status.ToLower() == SD.StatusInProcess.ToLower()).OrderByDescending(u => u.PickUpName).ToList();

            foreach (OrderHeader item in OrderHeaderList)
            {
                OrderDetailsVM individual = new OrderDetailsVM
                {
                    OrderHeader = item,
                    OrderDetails = _unitOfWork.OrderDetails.GetAll(o => o.OrderId == item.Id).ToList()
                };

                orderDetailsVM.Add(individual);
            }
        }
 
    }
}