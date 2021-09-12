using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace DBStore.Models.VModels
{
   public class UnitVM
    {
      
        [Key]
        public int Id { get; set; }
        [Required]
        [Display(Name = "Unit Name")]
        public string Name { get; set; }
        [Required]
        [Display(Name = "Unit")]
        public string ShortName { get; set; }
        public Unit Unit { get; set; }
    }
}
