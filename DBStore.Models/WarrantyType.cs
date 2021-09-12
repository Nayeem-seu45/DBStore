using System;
using System.Collections.Generic;
using System.Text;

namespace DBStore.Models
{
   public class WarrantyType : BaseEntity
    {
        public string Name { get; set; }
        public string Description { get; set; }
        //public virtual ICollection<Product> Product { get; set; }
    }
}
