using System;
using System.Collections.Generic;
using System.Text;

namespace DBStore.Models.VModels
{
 public   class ProductIdModel
    {
        public int ProductId { get; set; }

        //public Reviews Reviews { get; set; }
        public IEnumerable<Reviews> Reviews { get; set; }
    }
}
