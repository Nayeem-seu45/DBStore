using System;
using System.Collections.Generic;
using System.Text;

namespace DBStore.Models.VModels
{
   public class QuestionVM
    {
        public int Id { get; set; }
        public DateTime? AddDate { get; set; }
        public string AddBy { get; set; }
        public string Reviews { get; set; }
        public Product Product { get; set; }
        public int ProductId { get; set; }
        public string Answer { get; set; }
    }
}
