using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Text;

namespace DBStore.Models.VModels
{
   public class OrderDetailsCart
    {
        public List<ShoppingCart> listCart { get; set; }

        public IEnumerable<SelectListItem> CityList { get; set; }

        public IEnumerable<SelectListItem> PaymnetList { get; set; }

        public OrderHeader OrderHeader { get; set; }
    }
}
