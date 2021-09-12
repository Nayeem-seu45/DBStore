using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using DBStore.DataAccess.Data.Repository.IRepository;
using DBStore.Models;
using DBStore.Models.VModels;
using DBStore.Utility;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace DBStore.Pages.Customer.Account
{
    public class DashboardModel : PageModel
    {
        private readonly IUnitOfWorkRepository _unitOfWork;
        public DashboardModel(IUnitOfWorkRepository unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }


        public IEnumerable<OrderViewModel> Orders { get; set; }
        public IEnumerable<OrderHeader> OrderHeaders { get; set; }


        public void OnGet()
        {
            List<OrderViewModel> OrderList = new List<OrderViewModel>();

            var claimsIdentity = (ClaimsIdentity)this.User.Identity;
            var claim = claimsIdentity.FindFirst(ClaimTypes.NameIdentifier);
            OrderHeaders = _unitOfWork.OrderHeader.GetAll().Where(s => s.UserId == claim.Value && s.Status.ToLower() != SD.StatusCompleted.ToLower()).ToList();
            if (OrderHeaders != null)
            {
                foreach (var item in OrderHeaders)
                {
                    OrderViewModel model = new OrderViewModel();
                    //if(item.Status.ToLower()== SD.StatusShipping || item.Status.ToLower() == SD.StatusSubmitted)
                    //{ 
                    var details = _unitOfWork.OrderDetails.GetAll(s => s.OrderId == item.Id).FirstOrDefault();
                    if (details != null)
                    {
                        model.Id = item.Id;
                        model.OrderId = details.OrderId;
                        model.OrderDate = item.OrderDate;
                        model.OrderTotal = item.OrderTotal;
                        model.Quantity = details.Count;
                        model.ProductImnage = _unitOfWork.Product.Get(details.ProductId).Image;

                        OrderList.Add(model);
                    }
                    //}

                }
                Orders = OrderList.AsEnumerable();
            }

        }

    }
}