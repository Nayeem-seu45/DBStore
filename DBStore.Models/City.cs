using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Net.Mail;
using System.Text;

namespace DBStore.Models
{
   public class City: BaseEntity
    {
        [Required]
        [Display(Name = "City Name")] 
        public string Name { get; set; }

        [Display(Name ="Delivery Fee")]
        public double Amount { get; set; }
        [Required]
        [Display(Name = "Display Order")]
        public int DisplayOrder { get; set; }

        public virtual ICollection<ApplicationUser> Users { get; set; }
        public virtual ICollection<OrderHeader> OrderHeaders { get; set; }

    }
}
