using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace DBStore.Models
{
  public class RequestProduct : BaseEntity
    {
        [Display(Name ="Product Name")]
        public string ProductName { get; set; }
        [Display(Name ="Brand")]
        public string ProductModel { get; set; }
        public string Description { get; set; }
        public string RequestBy { get; set; }

        [Display(Name ="Product Image")]
        public string ImgUrl { get; set; }

        [Display(Name ="Your Name")]
        public string YourName { get; set; }
        public string Email { get; set; }
        public string UserId { get; set; }

        [ForeignKey("UserId")]
        public virtual ApplicationUser ApplicationUser { get; set; }
    }
}
