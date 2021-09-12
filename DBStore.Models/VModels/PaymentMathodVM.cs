using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace DBStore.Models.VModels
{
  public  class PaymentMathodVM
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [Display(Name = "Payment Mathod Name")]
        public string Name { get; set; }
       
        [Display(Name = "Payment")]
        public string Description { get; set; }

        public PaymentMathod PaymentMathod { get; set; }
    }
}
