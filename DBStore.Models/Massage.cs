using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace DBStore.Models
{
   public class Massage : BaseEntity
    {
        [Display(Name = "Your Name")]
        public string YourName { get; set; }

        [Display(Name ="Phone Number")]
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
        public string Subject { get; set; }

        public string Message { get; set; }

        public string UserId { get; set; }

        [ForeignKey("UserId")]
        public virtual ApplicationUser ApplicationUser { get; set; }
    }
}
