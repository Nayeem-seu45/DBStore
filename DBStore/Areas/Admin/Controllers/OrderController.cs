using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using DBStore.DataAccess.Data.Repository.IRepository;
using DBStore.Models;
using DBStore.Models.VModels;
using DBStore.Utility;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DBStore.Areas.Admin.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    
    public class OrderController : Controller
    {
        private readonly IUnitOfWorkRepository _unitOfWork;
        public OrderController(IUnitOfWorkRepository unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }


        [HttpGet]
        public IActionResult Get(string status = null/*, string paymentStatus = null*/)
        {
            List<OrderDetailsVM> orderListVM = new List<OrderDetailsVM>();
            IEnumerable<OrderHeader> OrderHeaderList;

            if(User.IsInRole(SD.CustomerRole))
            {
                var claimsIdentity = (ClaimsIdentity)this.User.Identity;
                var claim = claimsIdentity.FindFirst(ClaimTypes.NameIdentifier);
                OrderHeaderList = _unitOfWork.OrderHeader.GetAll(u => u.UserId == claim.Value, null, "ApplicationUser");


            }

            else
            {
                OrderHeaderList = _unitOfWork.OrderHeader.GetAll(null, null, "ApplicationUser,PaymentMathod");
                
            }

            if (status == "cancelled")
            {
                OrderHeaderList = OrderHeaderList.Where(o => o.Status == SD.StatusCancelled || o.Status == SD.StatusRefunded || o.Status == SD.PaymentStatusRejected);
            }

           
          else if (status == "completed")
                {
                    OrderHeaderList = OrderHeaderList.Where(o => o.Status == SD.StatusCompleted);

                }
            else if(status == "shipping")
            {
                OrderHeaderList = OrderHeaderList.Where(o => o.Status == SD.StatusShipping);
            }
                else
                {
                    OrderHeaderList = OrderHeaderList.Where(o => o.Status == SD.StatusReady || o.Status == SD.StatusInProcess|| o.Status == SD.StatusSubmitted || o.Status == SD.PaymentStatusPending);
                }
            

            //if (paymentStatus == "cOD")
            //{
            //    OrderHeaderList = OrderHeaderList.Where(o => o.PaymentStatus == SD.PaymentMethodCOD);

            //}
            //else
            //{
            //    if (paymentStatus == "bkash")
            //    {
            //        OrderHeaderList = OrderHeaderList.Where(o => o.PaymentStatus == SD.PaymentMethodBkash);
            //    }

            //    OrderHeaderList = OrderHeaderList.Where(o => o.PaymentStatus == SD.PaymentMethodRocket);
            //}
            foreach (OrderHeader item in OrderHeaderList)
            {
                OrderDetailsVM individual = new OrderDetailsVM
                {
                    OrderHeader = item,
                    OrderDetails = _unitOfWork.OrderDetails.GetAll(null,null, "Product").Where(o => o.OrderId == item.Id).ToList(),

                };

                orderListVM.Add(individual);
            }

            return Json(new { data = orderListVM });
        }
    }
}