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
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Options;
using Org.BouncyCastle.Crypto.Tls;
using Stripe;

namespace DBStore.Pages.Customer.Cat
{
    public class SummaryModel : PageModel
    {
        private readonly IUnitOfWorkRepository _unitOfWork;
        private readonly RoleManager<IdentityRole> _roleManager;
        public SummaryModel(IUnitOfWorkRepository unitOfWork, RoleManager<IdentityRole> roleManager)
        {
            _unitOfWork = unitOfWork;
            _roleManager = roleManager;
        }

        [BindProperty]
        public OrderDetailsCart detailCart { get; set; }
        public IActionResult OnGet(string status = null)
        {
            detailCart = new OrderDetailsCart()
            {
                OrderHeader = new Models.OrderHeader(),
                  CityList = _unitOfWork.City.GetCityListForDropDown(),
                  PaymnetList = _unitOfWork.PaymentMathod.GetPaymentMathodListForDropDown()
            };

            detailCart.OrderHeader.OrderTotal = 0;
            var claimsIdentity = (ClaimsIdentity)this.User.Identity;
            var claim = claimsIdentity.FindFirst(ClaimTypes.NameIdentifier);

            IEnumerable<ShoppingCart> cart = _unitOfWork.ShoppingCart.GetAll(c => c.ApplicationUserId == claim.Value);
            if (cart != null)
            {
                detailCart.listCart = cart.ToList();
            }

            foreach (var cartList in detailCart.listCart)
            {
                cartList.Product = _unitOfWork.Product.GetFirstOrDefault(m => m.Id == cartList.ProductId);
                detailCart.OrderHeader.OrderTotal += (cartList.Product.Price * cartList.Count);
            }

            ApplicationUser applicationUser = _unitOfWork.ApplicationUser.GetFirstOrDefault(c => c.Id == claim.Value);
            detailCart.OrderHeader.PickUpName = applicationUser.FullName;
          
            detailCart.OrderHeader.PhoneNumber = applicationUser.PhoneNumber;
          
           
            
          
            return Page();

        }

        public IActionResult  OnPost()
        {
            var claimsIdentity = (ClaimsIdentity)this.User.Identity;
            var claim = claimsIdentity.FindFirst(ClaimTypes.NameIdentifier);
            detailCart.listCart = _unitOfWork.ShoppingCart.GetAll(c => c.ApplicationUserId == claim.Value).ToList();
            detailCart.OrderHeader.OrderDate = DateTime.Now;
            detailCart.OrderHeader.UserId = claim.Value;
            detailCart.OrderHeader.Status = SD.StatusSubmitted;
        
            List<OrderDetails> orderDetailsList = new List<OrderDetails>();
            _unitOfWork.OrderHeader.Add(detailCart.OrderHeader);
            _unitOfWork.Save(); 


            foreach(var item in detailCart.listCart)
            {
                item.Product = _unitOfWork.Product.GetFirstOrDefault(m => m.Id == item.ProductId);
                OrderDetails orderDetails = new OrderDetails
                {
                    ProductId = item.ProductId,
                    OrderId = detailCart.OrderHeader.Id,
                    Discription = item.Product.Description,
                    Name = item.Product.Name,
                    Price = item.Product.Price,
                    Count = item.Count,
                };

                detailCart.OrderHeader.OrderTotal += (orderDetails.Count * orderDetails.Price);
                _unitOfWork.OrderDetails.Add(orderDetails);
            }

           //detailCart.OrderHeader.OrderTotal = Convert.ToDouble( String.Format("0:.##", detailCart.OrderHeader.OrderTotal));
            _unitOfWork.ShoppingCart.RemoveRange(detailCart.listCart);
            HttpContext.Session.SetInt32(SD.ShoppingCart, 0);
            _unitOfWork.Save();

            return RedirectToPage("/Customer/Cat/Orderconfirmation", new { id = detailCart.OrderHeader.Id });

        }
    }
}