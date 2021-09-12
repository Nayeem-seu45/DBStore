using System;
using System.ComponentModel.DataAnnotations;
using System.Reflection.Metadata.Ecma335;

namespace DBStore.Models
{
    public class BaseEntity
    {
        //[Key]
        public int Id { get; set; }
        public DateTime? AddDate { get; set; }
        public string AddedBy { get; set; }
        public DateTime? UpdateDate { get; set; }
        public string UpdateBy { get; set; }
        public DateTime? DeleteDate { get; set; }
        public string DeleteBy { get; set; }
        public int Status { get; set; }
    }
}
