using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using DBStore.DataAccess.Data.Repository.IRepository;
using DBStore.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace DBStore.Pages.Customer.Account
{
    public class OrderDetailsModel : PageModel
    {
        private readonly IUnitOfWorkRepository _unitOfWork;
        public OrderDetailsModel(IUnitOfWorkRepository unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public OrderDetails orderDetails { get; set; }
        public OrderHeader orderHeaders { get; set; }

        public double DeliveryFee { get; set; }
        public double Subtotal { get; set; }
        public void OnGet(int id)
        {
            List<OrderDetails> OrderDetailsList = new List<OrderDetails>();
            orderHeaders = _unitOfWork.OrderHeader.Get(id);
            if (orderHeaders != null)
            {
                var details = _unitOfWork.OrderDetails.GetAll(s => s.OrderId == orderHeaders.Id).FirstOrDefault();

                if (details != null)
                    orderDetails = details;
                      
            }
            var city = _unitOfWork.City.Get(orderHeaders.CityID);
            DeliveryFee = city.Amount;

        }
    }
}