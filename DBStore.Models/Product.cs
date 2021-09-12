 using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace DBStore.Models
{
   public class Product : BaseEntity
    {
      
        [Required]
        public string Name { get; set; }
        public string Description { get; set; }
        public string Image { get; set; }
        public string Image1 { get; set; }
        public string Image2 { get; set; }
        public string Image3 { get; set; }
       
        public string KeyFeature { get; set; }
        public bool Feature { get; set; }

        [Display(Name = "Warranty Type")]
        public int? WarrantyTypeId { get; set; }

        [ForeignKey("WarrantyTypeId")]
        public virtual WarrantyType WarrantyType { get; set; }
        public string WarrantyDetails { get; set; }
        public double Height { get; set; }
        public double Length { get; set; }
        public double Width { get; set; }
        public double? Ratting { get; set; }

        [Range(1, int.MaxValue, ErrorMessage ="Price shuould be greater than 10TK")]
        public double Price { get; set; }
        public bool InStock { get; set; }
        public double DisPrice { get; set; }

        public string Tag { get; set; }

        [Display(Name="Category Type")]
        public int CategoryId { get; set; }

        [ForeignKey("CategoryId")]
        public virtual Category Category { get; set; }

        [Display(Name = "Brand Type")]
        public int BrandId { get; set; }

        [ForeignKey("BrandId")]
        public virtual Brand Brand { get; set; }

        [Display(Name = "Unit Type")]
        public int UnitId { get; set; }

        [ForeignKey("UnitId")]
        public virtual Unit Unit { get; set; }
        [Display(Name = "Offer Type")]
        public int? OfferZoneId { get; set; }

        [ForeignKey("OfferZoneId")]
        public virtual OfferZone OfferZone { get; set; }

        public ICollection<Reviews> Reviews { get; set; }

    }
}
