using Microsoft.AspNetCore.SignalR;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace DBStore.Models
{
    public class Question : BaseEntity
    {
        [Display(Name = "Your Name")]
        public string YourName { get; set; }
        [Display(Name = "Your Review")]
        public string Description { get; set; }
        [Display(Name = "Email Address")]
        public string EmailAddress { get; set; }

        public string Answer { get; set; }
        public string UserId { get; set; }
        [ForeignKey("UserId")]
        public ApplicationUser ApplicationUser { get; set; }

        public int ProductId { get; set; }

        [ForeignKey("ProductId")]
        public Product Product { get; set; }


    }
}

