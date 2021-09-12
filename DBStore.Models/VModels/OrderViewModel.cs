using System;
using System.Collections.Generic;
using System.Text;

namespace DBStore.Models.VModels
{
   public class OrderViewModel
    {
        public int Id { get; set; }
        public int OrderId { get; set; }
        public int Quantity { get; set; }
        public DateTime OrderDate { get; set; }
        public double OrderTotal { get; set; }
        public string ProductImnage { get; set; }
        public string OrderStatus { get; set; }
    }
}
