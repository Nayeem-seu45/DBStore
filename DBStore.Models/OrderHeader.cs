using Microsoft.EntityFrameworkCore.Query.Internal;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace DBStore.Models
{
    public class OrderHeader
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string UserId { get; set; }

        [ForeignKey("UserId")]
        public virtual ApplicationUser ApplicationUser { get; set; }

        [Required]
        public DateTime OrderDate { get; set; }

        [Required]
        [DisplayFormat(DataFormatString ="{0:C}")]
        [Display(Name ="Order Total")]
        public double OrderTotal { get; set; }

      
        public string Status { get; set; }

        public string PaymentStatus { get; set; }

        public string Comments { get; set; }

        [Display(Name ="Pickup Name")]
        public string PickUpName { get; set; }

        [Display(Name ="Phone Number")]
        public string PhoneNumber { get; set; }
        public string TransactionId { get; set; }

        [Display(Name = "Your City")]
        public int  CityID { get; set; }

        public virtual City City { get; set; }

        public int PaymentMathodID { get; set; }

        public virtual PaymentMathod PaymentMathod { get; set; }

        public string Address { get; set; }
    }
}
