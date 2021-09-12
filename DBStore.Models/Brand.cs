using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace DBStore.Models
{
  public class Brand : BaseEntity
    {
        [Required]
        [Display(Name = "Brand Name")]
        public string Name { get; set; }
        public string BrandIcon { get; set; }
        [Required]
        [Display(Name = "Display Order")]
        public int DisplayOrder { get; set; }
      
    }
}
