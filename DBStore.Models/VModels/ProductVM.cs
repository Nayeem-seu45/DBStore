using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Text;

namespace DBStore.Models.VModels
{
   public class ProductVM
    {
        public Product Product { get; set; }
        public IEnumerable<SelectListItem> CategoryList { get; set; }
        public IEnumerable<SelectListItem> BrandList { get; set; }
        public IEnumerable<SelectListItem> UnitList { get; set; }
        public IEnumerable<SelectListItem> WarrantyList { get; set; }
        public IEnumerable<SelectListItem> OfferList { get; set; }
        public int CategoryId { get; set; }

        //public IEnumerable<Product> RelatedProductList { get; set; }

       // public Category Category { get; set; }
        //public int CategoryId { get; set; }

        //public IEnumerable<ReviewsVM> ListOfReviews { get; set; }
        //public IEnumerable<SelectListItem> ColorList { get; set; }
    }
}
