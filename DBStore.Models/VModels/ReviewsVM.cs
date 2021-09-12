using System;
using System.Collections.Generic;
using System.Text;

namespace DBStore.Models.VModels
{
   public class ReviewsVM
    {
        public int Id { get; set; }
        public DateTime? AddDate { get; set; }
        public string AddBy { get; set; }
        public string Reviews { get; set; }
        public Product Product { get; set; }
        public int ProductId { get; set; }
        public int Rating { get; set; }
        public string ProductImage { get; set; }

    }
}
