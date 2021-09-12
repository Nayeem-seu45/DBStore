 using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using DBStore.DataAccess.Data.Repository.IRepository;
using DBStore.Models;
using DBStore.Models.CMS;
using DBStore.Utility;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Data.SqlClient;

namespace DBStore.Pages.Customer.Home
{
    public class IndexModel : PageModel
    {
        private readonly IUnitOfWorkRepository _unitOfWork;
       
        public IndexModel(IUnitOfWorkRepository unitOfWork)
        {
            _unitOfWork = unitOfWork;
                
        }
        public IEnumerable<Models.Product> ProductList { get; set; }
        public IEnumerable<Models.Product> FeatureProduct { get; set; }
        public IEnumerable<Category> CategoryList { get; set; }
        public IEnumerable<Brand> BrandList { get; set; }
       // public IEnumerable<OfferZone> OfferList { get; set; }



        public IEnumerable<SlideShow> SlideShows { get; set; }
        public void OnGet()
        {
            var claimsIdentity = (ClaimsIdentity)this.User.Identity;
            var claim = claimsIdentity.FindFirst(ClaimTypes.NameIdentifier);

            if(claim != null)
            {
                int shoppingCartCount = _unitOfWork.ShoppingCart.GetAll(u => u.ApplicationUserId == claim.Value).ToList().Count;
                HttpContext.Session.SetInt32(SD.ShoppingCart, shoppingCartCount);
            }

            ProductList = _unitOfWork.Product.GetAll(null, null, "Category,Brand");
            CategoryList = _unitOfWork.Category.GetAll(null, q => q.OrderBy(c => c.DisplayOrder), null);
            BrandList = _unitOfWork.Brand.GetAll(null, q => q.OrderBy(c => c.DisplayOrder), null);
            SlideShows = _unitOfWork.SlideShow.GetAll();
            FeatureProduct = _unitOfWork.Product.GetAll().Where(s => s.Feature == true).Take(12).ToList();
            
        }

     
    }
}