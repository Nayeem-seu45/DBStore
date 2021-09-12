using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace DBStore.Models.VModels
{
   public class CityVM
    {
      
        public int Id { get; set; }
        public string Name { get; set; }
        public double Amount { get; set; }
        public int DisplayOrder { get; set; }
        public City City { get; set; }
    }
}
