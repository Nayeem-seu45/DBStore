using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace DBStore.Models
{
   public class ShoppingCart
    {
        public ShoppingCart()
        {
            Count = 1;
        }
        public int Id { get; set; }

        public int ProductId { get; set; }

        [NotMapped ]
        [ForeignKey("ProductId")]
        public virtual Product Product  { get; set; }

        //[NotMapped]
        //[ForeignKey("ReviewsId")]
        //public virtual Reviews Reviews { get; set; }

        public string ApplicationUserId  { get; set; }

        [NotMapped]
        [ForeignKey("ApplicationUserId")]
        public virtual ApplicationUser ApplicationUser { get; set; }

        [Range(1,100, ErrorMessage ="Please Select a count between 1 and 100")]
        public int Count { get; set; }

      
    }
}
