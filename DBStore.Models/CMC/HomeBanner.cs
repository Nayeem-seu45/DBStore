using System;
using System.Collections.Generic;
using System.Text;

namespace DBStore.Models.CMS
{
    public class HomeBanner : BaseEntity
    {
        public string ImgUrl { get; set; }
        public string PrimaryText { get; set; }
        public string RawHtmlCode { get; set; }
        public string OtherText { get; set; }

    }
}
