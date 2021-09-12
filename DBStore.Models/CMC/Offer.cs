using System;
using System.Collections.Generic;
using System.Text;

namespace DBStore.Models.CMS
{
    public class Offer : BaseEntity
    {
        public string OfferName { get; set; }
        public string OfferTemplate { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndDateTime { get; set; }

    }
}
