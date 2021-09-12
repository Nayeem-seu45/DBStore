using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Text;

namespace DBStore.Models.VModels
{
   public class OrderDetailsVM
    {
        public OrderHeader OrderHeader  { get; set; }
        public List<OrderDetails> OrderDetails { get; set; }

       

    }
}
